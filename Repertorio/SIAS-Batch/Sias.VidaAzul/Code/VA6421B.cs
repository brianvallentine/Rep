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
using Sias.VidaAzul.DB2.VA6421B;

namespace Code
{
    public class VA6421B
    {
        public bool IsCall { get; set; }

        public VA6421B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO ................  GERA MOVIMENTO DOS SEGURADOS DAS    *      */
        /*"      *                            APOLICES ESPECIFICAS QUE POSSUEM    *      */
        /*"      *                            CDG.                                *      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA/PROGRAMADOR.... FREDERICO FONSECA.                  *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  VA6421B                            *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  15/06/2000                         *      */
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
        /*"77  V0PROP-NUM-APOLICE               PIC S9(13)    COMP-3.*/
        public IntBasis V0PROP_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0PROP-DTQITBCO                  PIC  X(10).*/
        public StringBasis V0PROP_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0PROP-DTMOVTO                   PIC  X(10).*/
        public StringBasis V0PROP_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
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
        /*"01     WACHEI-SAF1                   PIC X(01) VALUE SPACES.*/
        public StringBasis WACHEI_SAF1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
        /*"01     WACHEI-SAF2                   PIC X(01) VALUE SPACES.*/
        public StringBasis WACHEI_SAF2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
        /*"01     WDATA-WORK.*/
        public VA6421B_WDATA_WORK WDATA_WORK { get; set; } = new VA6421B_WDATA_WORK();
        public class VA6421B_WDATA_WORK : VarBasis
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
        public VA6421B_WDATA_INIVIG WDATA_INIVIG { get; set; } = new VA6421B_WDATA_INIVIG();
        public class VA6421B_WDATA_INIVIG : VarBasis
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
        private _REDEF_VA6421B_WMES_VIG_R _wmes_vig_r { get; set; }
        public _REDEF_VA6421B_WMES_VIG_R WMES_VIG_R
        {
            get { _wmes_vig_r = new _REDEF_VA6421B_WMES_VIG_R(); _.Move(WMES_VIG, _wmes_vig_r); VarBasis.RedefinePassValue(WMES_VIG, _wmes_vig_r, WMES_VIG); _wmes_vig_r.ValueChanged += () => { _.Move(_wmes_vig_r, WMES_VIG); }; return _wmes_vig_r; }
            set { VarBasis.RedefinePassValue(value, _wmes_vig_r, WMES_VIG); }
        }  //Redefines
        public class _REDEF_VA6421B_WMES_VIG_R : VarBasis
        {
            /*"    05 MES-VIG                    PIC 9(02).*/
            public IntBasis MES_VIG { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    05 ANO-VIG                    PIC 9(04).*/
            public IntBasis ANO_VIG { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"01     WS-TIME                       PIC X(08).*/

            public _REDEF_VA6421B_WMES_VIG_R()
            {
                MES_VIG.ValueChanged += OnValueChanged;
                ANO_VIG.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
        /*"01     WS-DATA-SQL.*/
        public VA6421B_WS_DATA_SQL WS_DATA_SQL { get; set; } = new VA6421B_WS_DATA_SQL();
        public class VA6421B_WS_DATA_SQL : VarBasis
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
        private _REDEF_VA6421B_FILLER_6 _filler_6 { get; set; }
        public _REDEF_VA6421B_FILLER_6 FILLER_6
        {
            get { _filler_6 = new _REDEF_VA6421B_FILLER_6(); _.Move(WS_DTQITBCO, _filler_6); VarBasis.RedefinePassValue(WS_DTQITBCO, _filler_6, WS_DTQITBCO); _filler_6.ValueChanged += () => { _.Move(_filler_6, WS_DTQITBCO); }; return _filler_6; }
            set { VarBasis.RedefinePassValue(value, _filler_6, WS_DTQITBCO); }
        }  //Redefines
        public class _REDEF_VA6421B_FILLER_6 : VarBasis
        {
            /*"    05 WS-AAQITBCO                PIC 9(04).*/
            public IntBasis WS_AAQITBCO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"    05 WS-MMQITBCO                PIC 9(02).*/
            public IntBasis WS_MMQITBCO { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    05 WS-DDQITBCO                PIC 9(02).*/
            public IntBasis WS_DDQITBCO { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"01     WS-DTREFER                    PIC 9(008).*/

            public _REDEF_VA6421B_FILLER_6()
            {
                WS_AAQITBCO.ValueChanged += OnValueChanged;
                WS_MMQITBCO.ValueChanged += OnValueChanged;
                WS_DDQITBCO.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis WS_DTREFER { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
        /*"01     FILLER REDEFINES WS-DTREFER.*/
        private _REDEF_VA6421B_FILLER_7 _filler_7 { get; set; }
        public _REDEF_VA6421B_FILLER_7 FILLER_7
        {
            get { _filler_7 = new _REDEF_VA6421B_FILLER_7(); _.Move(WS_DTREFER, _filler_7); VarBasis.RedefinePassValue(WS_DTREFER, _filler_7, WS_DTREFER); _filler_7.ValueChanged += () => { _.Move(_filler_7, WS_DTREFER); }; return _filler_7; }
            set { VarBasis.RedefinePassValue(value, _filler_7, WS_DTREFER); }
        }  //Redefines
        public class _REDEF_VA6421B_FILLER_7 : VarBasis
        {
            /*"    05 WS-AAREFER                 PIC 9(04).*/
            public IntBasis WS_AAREFER { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"    05 WS-MMREFER                 PIC 9(02).*/
            public IntBasis WS_MMREFER { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    05 WS-DDREFER                 PIC 9(02).*/
            public IntBasis WS_DDREFER { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"01  WABEND*/

            public _REDEF_VA6421B_FILLER_7()
            {
                WS_AAREFER.ValueChanged += OnValueChanged;
                WS_MMREFER.ValueChanged += OnValueChanged;
                WS_DDREFER.ValueChanged += OnValueChanged;
            }

        }
        public VA6421B_WABEND WABEND { get; set; } = new VA6421B_WABEND();
        public class VA6421B_WABEND : VarBasis
        {
            /*"    05    FILLER.*/
            public VA6421B_FILLER_8 FILLER_8 { get; set; } = new VA6421B_FILLER_8();
            public class VA6421B_FILLER_8 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(016) VALUE            '*** VA6421B *** '.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"*** VA6421B *** ");
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
            public VA6421B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new VA6421B_LOCALIZA_ABEND_1();
            public class VA6421B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05      LOCALIZA-ABEND-2.*/
            }
            public VA6421B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new VA6421B_LOCALIZA_ABEND_2();
            public class VA6421B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'COMANDO   = '.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"      10    COMANDO                  PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
            }
        }


        public VA6421B_CPROPOVA CPROPOVA { get; set; } = new VA6421B_CPROPOVA();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -239- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -241- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -243- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -247- MOVE 'R000-VA6421B  ' TO PARAGRAFO. */
                _.Move("R000-VA6421B  ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

                /*" -249- PERFORM R001-SELECT-SISTEMA. */

                R001_SELECT_SISTEMA_SECTION();

                /*" -251- PERFORM R010-DECLARE-PROPOVA. */

                R010_DECLARE_PROPOVA_SECTION();

                /*" -253- PERFORM R020-FETCH-PROPOVA. */

                R020_FETCH_PROPOVA_SECTION();

                /*" -254- IF WFIM-CPROPOVA EQUAL ' ' */

                if (WFIM_CPROPOVA == " ")
                {

                    /*" -256- DISPLAY '** VA6421B ** PROCESSANDO ...' . */
                    _.Display($"** VA6421B ** PROCESSANDO ...");
                }


                /*" -259- PERFORM R030-PROCESSAMENTO THRU R030-EXIT UNTIL WFIM-CPROPOVA EQUAL 'S' . */

                while (!(WFIM_CPROPOVA == "S"))
                {

                    R030_PROCESSAMENTO_SECTION();

                    R030_NEXT(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R030_EXIT*/

                }

                /*" -260- MOVE 'COMMIT WORK' TO COMANDO. */
                _.Move("COMMIT WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -260- EXEC SQL COMMIT WORK END-EXEC. */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -263- DISPLAY '** VA6421B ** LIDOS PROPOVA     ' AC-L-PROPOVA */
                _.Display($"** VA6421B ** LIDOS PROPOVA     {AC_L_PROPOVA}");

                /*" -264- DISPLAY '** VA6421B ** LIDOS COBERPROP   ' AC-L-COBERPROPVA */
                _.Display($"** VA6421B ** LIDOS COBERPROP   {AC_L_COBERPROPVA}");

                /*" -265- DISPLAY '** VA6421B ** LIDOS CDGCOBER    ' AC-L-CDGCOBER */
                _.Display($"** VA6421B ** LIDOS CDGCOBER    {AC_L_CDGCOBER}");

                /*" -266- DISPLAY '** VA6421B ** LIDOS SEGURAVG    ' AC-L-SEGURAVG */
                _.Display($"** VA6421B ** LIDOS SEGURAVG    {AC_L_SEGURAVG}");

                /*" -267- DISPLAY '** VA6421B ** LIDOS HISTSEGVG   ' AC-L-HISTSEGVG */
                _.Display($"** VA6421B ** LIDOS HISTSEGVG   {AC_L_HISTSEGVG}");

                /*" -268- DISPLAY '                                ' . */
                _.Display($"                                ");

                /*" -269- DISPLAY '** VA6421B ** INCL. REPASSECDG  ' AC-I-REPASSECDG */
                _.Display($"** VA6421B ** INCL. REPASSECDG  {AC_I_REPASSECDG}");

                /*" -270- DISPLAY '                                ' . */
                _.Display($"                                ");

                /*" -272- DISPLAY '** VA6421B ** TERMINO NORMAL    ' . */
                _.Display($"** VA6421B ** TERMINO NORMAL    ");

                /*" -274- MOVE ZEROS TO RETURN-CODE. */
                _.Move(0, RETURN_CODE);

                /*" -274- STOP RUN. */

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
            /*" -282- MOVE 'R001-SELECT-SISTEMA ' TO PARAGRAFO. */
            _.Move("R001-SELECT-SISTEMA ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -289- PERFORM R001_SELECT_SISTEMA_DB_SELECT_1 */

            R001_SELECT_SISTEMA_DB_SELECT_1();

            /*" -292- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -293- DISPLAY 'R001 - PROBLEMAS SELECT V0SISTEMA ....' */
                _.Display($"R001 - PROBLEMAS SELECT V0SISTEMA ....");

                /*" -294- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -296- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -297- MOVE V0FATUR-DTREFER TO WS-DATA-SQL. */
            _.Move(V0FATUR_DTREFER, WS_DATA_SQL);

            /*" -298- MOVE 01 TO WS-DIA-SQL. */
            _.Move(01, WS_DATA_SQL.WS_DIA_SQL);

            /*" -298- MOVE WS-DATA-SQL TO V0FATUR-DTREFER. */
            _.Move(WS_DATA_SQL, V0FATUR_DTREFER);

        }

        [StopWatch]
        /*" R001-SELECT-SISTEMA-DB-SELECT-1 */
        public void R001_SELECT_SISTEMA_DB_SELECT_1()
        {
            /*" -289- EXEC SQL SELECT DTMOVABE, DTMOVABE INTO :V0SIST-DTMOVABE, :V0FATUR-DTREFER FROM SEGUROS.V0SISTEMA WHERE IDSISTEM = 'VG' END-EXEC. */

            var r001_SELECT_SISTEMA_DB_SELECT_1_Query1 = new R001_SELECT_SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R001_SELECT_SISTEMA_DB_SELECT_1_Query1.Execute(r001_SELECT_SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SIST_DTMOVABE, V0SIST_DTMOVABE);
                _.Move(executed_1.V0FATUR_DTREFER, V0FATUR_DTREFER);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R001_EXIT*/

        [StopWatch]
        /*" R010-DECLARE-PROPOVA-SECTION */
        private void R010_DECLARE_PROPOVA_SECTION()
        {
            /*" -308- MOVE 'R010-DECLARE-PROPOVA' TO PARAGRAFO. */
            _.Move("R010-DECLARE-PROPOVA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -327- PERFORM R010_DECLARE_PROPOVA_DB_DECLARE_1 */

            R010_DECLARE_PROPOVA_DB_DECLARE_1();

            /*" -329- PERFORM R010_DECLARE_PROPOVA_DB_OPEN_1 */

            R010_DECLARE_PROPOVA_DB_OPEN_1();

            /*" -332- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -333- DISPLAY 'R010 - PROBLEMAS DECLARE CPROPOVA ....' */
                _.Display($"R010 - PROBLEMAS DECLARE CPROPOVA ....");

                /*" -334- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -334- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R010-DECLARE-PROPOVA-DB-DECLARE-1 */
        public void R010_DECLARE_PROPOVA_DB_DECLARE_1()
        {
            /*" -327- EXEC SQL DECLARE CPROPOVA CURSOR FOR SELECT A.NRCERTIF, A.CODCLIEN, A.CODOPER, A.SITUACAO, A.OCORHIST, VALUE(A.NUM_MATRICULA,0), A.DTQITBCO + 6 MONTHS, A.DTQITBCO, A.DTMOVTO, A.NUM_APOLICE FROM SEGUROS.V0PROPOSTAVA A, SEGUROS.V0PRODUTOSVG B WHERE A.NUM_APOLICE = B.NUM_APOLICE AND A.CODSUBES = B.CODSUBES AND A.SITUACAO IN ( '3' , '6' ) AND B.CODPRODAZ = 'AES' AND B.TEM_CDG = 'S' ORDER BY A.NRCERTIF END-EXEC. */
            CPROPOVA = new VA6421B_CPROPOVA(false);
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
							VALUE(A.NUM_MATRICULA
							,0)
							, 
							A.DTQITBCO + 6 MONTHS
							, 
							A.DTQITBCO
							, 
							A.DTMOVTO
							, 
							A.NUM_APOLICE 
							FROM SEGUROS.V0PROPOSTAVA A
							, 
							SEGUROS.V0PRODUTOSVG B 
							WHERE A.NUM_APOLICE = B.NUM_APOLICE 
							AND A.CODSUBES = B.CODSUBES 
							AND A.SITUACAO IN ( '3'
							, '6' ) 
							AND B.CODPRODAZ = 'AES' 
							AND B.TEM_CDG = 'S' 
							ORDER BY A.NRCERTIF";

                return query;
            }
            CPROPOVA.GetQueryEvent += GetQuery_CPROPOVA;

        }

        [StopWatch]
        /*" R010-DECLARE-PROPOVA-DB-OPEN-1 */
        public void R010_DECLARE_PROPOVA_DB_OPEN_1()
        {
            /*" -329- EXEC SQL OPEN CPROPOVA END-EXEC. */

            CPROPOVA.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_EXIT*/

        [StopWatch]
        /*" R020-FETCH-PROPOVA-SECTION */
        private void R020_FETCH_PROPOVA_SECTION()
        {
            /*" -344- MOVE 'R020-FETCH-PROPOVA ' TO PARAGRAFO. */
            _.Move("R020-FETCH-PROPOVA ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -355- PERFORM R020_FETCH_PROPOVA_DB_FETCH_1 */

            R020_FETCH_PROPOVA_DB_FETCH_1();

            /*" -358- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -359- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -360- MOVE 'S' TO WFIM-CPROPOVA */
                    _.Move("S", WFIM_CPROPOVA);

                    /*" -360- PERFORM R020_FETCH_PROPOVA_DB_CLOSE_1 */

                    R020_FETCH_PROPOVA_DB_CLOSE_1();

                    /*" -362- ELSE */
                }
                else
                {


                    /*" -363- DISPLAY 'R020 - (PROBLEMAS NO FETCH CPROPOVA ....' */
                    _.Display($"R020 - (PROBLEMAS NO FETCH CPROPOVA ....");

                    /*" -364- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -364- PERFORM R020_FETCH_PROPOVA_DB_CLOSE_2 */

                    R020_FETCH_PROPOVA_DB_CLOSE_2();

                    /*" -366- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -367- ELSE */
                }

            }
            else
            {


                /*" -369- ADD 1 TO AC-L-PROPOVA AC-CONTA. */
                AC_L_PROPOVA.Value = AC_L_PROPOVA + 1;
                AC_CONTA.Value = AC_CONTA + 1;
            }


            /*" -370- IF AC-CONTA > 999 */

            if (AC_CONTA > 999)
            {

                /*" -371- MOVE ZEROS TO AC-CONTA */
                _.Move(0, AC_CONTA);

                /*" -372- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), WS_TIME);

                /*" -372- DISPLAY 'LIDOS ' AC-L-PROPOVA ' ' WS-TIME. */

                $"LIDOS {AC_L_PROPOVA} {WS_TIME}"
                .Display();
            }


        }

        [StopWatch]
        /*" R020-FETCH-PROPOVA-DB-FETCH-1 */
        public void R020_FETCH_PROPOVA_DB_FETCH_1()
        {
            /*" -355- EXEC SQL FETCH CPROPOVA INTO :V0PROP-NRCERTIF, :V0PROP-CODCLIEN, :V0PROP-CODOPER, :V0PROP-SITUACAO, :V0PROP-OCORHIST, :V0PROP-NUM-MATRICULA, :V0CDGC-DTINICDG, :V0PROP-DTQITBCO, :V0PROP-DTMOVTO, :V0PROP-NUM-APOLICE END-EXEC. */

            if (CPROPOVA.Fetch())
            {
                _.Move(CPROPOVA.V0PROP_NRCERTIF, V0PROP_NRCERTIF);
                _.Move(CPROPOVA.V0PROP_CODCLIEN, V0PROP_CODCLIEN);
                _.Move(CPROPOVA.V0PROP_CODOPER, V0PROP_CODOPER);
                _.Move(CPROPOVA.V0PROP_SITUACAO, V0PROP_SITUACAO);
                _.Move(CPROPOVA.V0PROP_OCORHIST, V0PROP_OCORHIST);
                _.Move(CPROPOVA.V0PROP_NUM_MATRICULA, V0PROP_NUM_MATRICULA);
                _.Move(CPROPOVA.V0CDGC_DTINICDG, V0CDGC_DTINICDG);
                _.Move(CPROPOVA.V0PROP_DTQITBCO, V0PROP_DTQITBCO);
                _.Move(CPROPOVA.V0PROP_DTMOVTO, V0PROP_DTMOVTO);
                _.Move(CPROPOVA.V0PROP_NUM_APOLICE, V0PROP_NUM_APOLICE);
            }

        }

        [StopWatch]
        /*" R020-FETCH-PROPOVA-DB-CLOSE-1 */
        public void R020_FETCH_PROPOVA_DB_CLOSE_1()
        {
            /*" -360- EXEC SQL CLOSE CPROPOVA END-EXEC */

            CPROPOVA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R020_EXIT*/

        [StopWatch]
        /*" R020-FETCH-PROPOVA-DB-CLOSE-2 */
        public void R020_FETCH_PROPOVA_DB_CLOSE_2()
        {
            /*" -364- EXEC SQL CLOSE CPROPOVA END-EXEC */

            CPROPOVA.Close();

        }

        [StopWatch]
        /*" R030-PROCESSAMENTO-SECTION */
        private void R030_PROCESSAMENTO_SECTION()
        {
            /*" -386- IF V0SIST-DTMOVABE LESS V0PROP-DTQITBCO */

            if (V0SIST_DTMOVABE < V0PROP_DTQITBCO)
            {

                /*" -391- GO TO R030-NEXT. */

                R030_NEXT(); //GOTO
                return;
            }


            /*" -392- IF V0CDGC-DTINICDG GREATER V0SIST-DTMOVABE */

            if (V0CDGC_DTINICDG > V0SIST_DTMOVABE)
            {

                /*" -394- GO TO R030-NEXT. */

                R030_NEXT(); //GOTO
                return;
            }


            /*" -396- MOVE 'SIM' TO WTEM-COB-OPCIONAIS. */
            _.Move("SIM", WTEM_COB_OPCIONAIS);

            /*" -398- PERFORM R040-SELECT-COBERPROPVA. */

            R040_SELECT_COBERPROPVA_SECTION();

            /*" -399- IF V0COBV-VLCUSTCDG EQUAL ZEROS */

            if (V0COBV_VLCUSTCDG == 00)
            {

                /*" -401- MOVE 'NAO' TO WTEM-COB-OPCIONAIS. */
                _.Move("NAO", WTEM_COB_OPCIONAIS);
            }


            /*" -402- IF WTEM-COB-OPCIONAIS EQUAL 'NAO' */

            if (WTEM_COB_OPCIONAIS == "NAO")
            {

                /*" -403- DISPLAY '*----------------------------------*' */
                _.Display($"*----------------------------------*");

                /*" -405- DISPLAY '  SEGURADO NAO POSSUI COB. OPCIONAL ' V0PROP-NRCERTIF */
                _.Display($"  SEGURADO NAO POSSUI COB. OPCIONAL {V0PROP_NRCERTIF}");

                /*" -406- DISPLAY '*----------------------------------*' */
                _.Display($"*----------------------------------*");

                /*" -408- GO TO R030-NEXT. */

                R030_NEXT(); //GOTO
                return;
            }


            /*" -410- PERFORM R060-SELECT-SEGURAVG. */

            R060_SELECT_SEGURAVG_SECTION();

            /*" -412- PERFORM R070-SELECT-HISTSEGVG. */

            R070_SELECT_HISTSEGVG_SECTION();

            /*" -412- PERFORM R110-PROCESSA-COB-CDG. */

            R110_PROCESSA_COB_CDG_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R030_NEXT */

            R030_NEXT();

        }

        [StopWatch]
        /*" R030-NEXT */
        private void R030_NEXT(bool isPerform = false)
        {
            /*" -416- PERFORM R020-FETCH-PROPOVA. */

            R020_FETCH_PROPOVA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R030_EXIT*/

        [StopWatch]
        /*" R040-SELECT-COBERPROPVA-SECTION */
        private void R040_SELECT_COBERPROPVA_SECTION()
        {
            /*" -426- MOVE 'SELECT R040-COBERPROPVA' TO PARAGRAFO. */
            _.Move("SELECT R040-COBERPROPVA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -434- PERFORM R040_SELECT_COBERPROPVA_DB_SELECT_1 */

            R040_SELECT_COBERPROPVA_DB_SELECT_1();

            /*" -437- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -440- DISPLAY 'R040 - PROBLEMAS SELECT V0COBERPROPVA.' ' CERT ' V0PROP-NRCERTIF ' ' ' OCOH ' V0PROP-OCORHIST */

                $"R040 - PROBLEMAS SELECT V0COBERPROPVA. CERT {V0PROP_NRCERTIF}  OCOH {V0PROP_OCORHIST}"
                .Display();

                /*" -442- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -442- ADD 1 TO AC-L-COBERPROPVA. */
            AC_L_COBERPROPVA.Value = AC_L_COBERPROPVA + 1;

        }

        [StopWatch]
        /*" R040-SELECT-COBERPROPVA-DB-SELECT-1 */
        public void R040_SELECT_COBERPROPVA_DB_SELECT_1()
        {
            /*" -434- EXEC SQL SELECT IMPSEGCDC, VLCUSTCDG INTO :V0COBV-IMPSEGCDG, :V0COBV-VLCUSTCDG FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND OCORHIST = :V0PROP-OCORHIST END-EXEC. */

            var r040_SELECT_COBERPROPVA_DB_SELECT_1_Query1 = new R040_SELECT_COBERPROPVA_DB_SELECT_1_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_OCORHIST = V0PROP_OCORHIST.ToString(),
            };

            var executed_1 = R040_SELECT_COBERPROPVA_DB_SELECT_1_Query1.Execute(r040_SELECT_COBERPROPVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBV_IMPSEGCDG, V0COBV_IMPSEGCDG);
                _.Move(executed_1.V0COBV_VLCUSTCDG, V0COBV_VLCUSTCDG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R040_EXIT*/

        [StopWatch]
        /*" R060-SELECT-SEGURAVG-SECTION */
        private void R060_SELECT_SEGURAVG_SECTION()
        {
            /*" -451- MOVE 'SELECT R060-SEGURAVG   ' TO PARAGRAFO. */
            _.Move("SELECT R060-SEGURAVG   ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -461- PERFORM R060_SELECT_SEGURAVG_DB_SELECT_1 */

            R060_SELECT_SEGURAVG_DB_SELECT_1();

            /*" -464- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -466- DISPLAY 'R060 - PROBLEMAS SELECT V0SEGURAVG  ..' ' CERT ' V0PROP-NRCERTIF */

                $"R060 - PROBLEMAS SELECT V0SEGURAVG  .. CERT {V0PROP_NRCERTIF}"
                .Display();

                /*" -468- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -468- ADD 1 TO AC-L-SEGURAVG. */
            AC_L_SEGURAVG.Value = AC_L_SEGURAVG + 1;

        }

        [StopWatch]
        /*" R060-SELECT-SEGURAVG-DB-SELECT-1 */
        public void R060_SELECT_SEGURAVG_DB_SELECT_1()
        {
            /*" -461- EXEC SQL SELECT SIT_REGISTRO, OCORR_HISTORICO, NUM_ITEM INTO :V0SEGV-SITUACAO, :V0SEGV-OCORHIST, :V0SEGV-NUMITEM FROM SEGUROS.V0SEGURAVG WHERE NUM_CERTIFICADO = :V0PROP-NRCERTIF AND TIPO_SEGURADO = '1' END-EXEC. */

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
            /*" -480- MOVE 'R070-SELECT V0HISTSEGVG' TO PARAGRAFO. */
            _.Move("R070-SELECT V0HISTSEGVG", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -489- PERFORM R070_SELECT_HISTSEGVG_DB_SELECT_1 */

            R070_SELECT_HISTSEGVG_DB_SELECT_1();

            /*" -492- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -496- DISPLAY 'R070 - PROBLEMAS SELECT V0HISTSEGVG ..' ' CERT ' V0PROP-NRCERTIF ' ' ' ITEM ' V0SEGV-NUMITEM ' ' ' OCOH ' V0SEGV-OCORHIST */

                $"R070 - PROBLEMAS SELECT V0HISTSEGVG .. CERT {V0PROP_NRCERTIF}  ITEM {V0SEGV_NUMITEM}  OCOH {V0SEGV_OCORHIST}"
                .Display();

                /*" -498- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -498- ADD 1 TO AC-L-HISTSEGVG. */
            AC_L_HISTSEGVG.Value = AC_L_HISTSEGVG + 1;

        }

        [StopWatch]
        /*" R070-SELECT-HISTSEGVG-DB-SELECT-1 */
        public void R070_SELECT_HISTSEGVG_DB_SELECT_1()
        {
            /*" -489- EXEC SQL SELECT COD_OPERACAO, DATA_MOVIMENTO INTO :V0HSEG-CODOPER, :V0HSEG-DTMOVTO FROM SEGUROS.V0HISTSEGVG WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE AND NUM_ITEM = :V0SEGV-NUMITEM AND OCORR_HISTORICO = :V0SEGV-OCORHIST END-EXEC. */

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
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R070_EXIT*/

        [StopWatch]
        /*" R110-PROCESSA-COB-CDG-SECTION */
        private void R110_PROCESSA_COB_CDG_SECTION()
        {
            /*" -510- PERFORM R120-SELECT-CDGCOBER. */

            R120_SELECT_CDGCOBER_SECTION();

            /*" -510- PERFORM R130-GERA-REPASSE-CDG. */

            R130_GERA_REPASSE_CDG_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R110_EXIT*/

        [StopWatch]
        /*" R120-SELECT-CDGCOBER-SECTION */
        private void R120_SELECT_CDGCOBER_SECTION()
        {
            /*" -522- MOVE 'SELECT I120-CDGCOBER   ' TO PARAGRAFO. */
            _.Move("SELECT I120-CDGCOBER   ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -532- PERFORM R120_SELECT_CDGCOBER_DB_SELECT_1 */

            R120_SELECT_CDGCOBER_DB_SELECT_1();

            /*" -535- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -536- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -548- PERFORM R120_SELECT_CDGCOBER_DB_INSERT_1 */

                    R120_SELECT_CDGCOBER_DB_INSERT_1();

                    /*" -550- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -551- DISPLAY 'R120 - PROBLEMAS INSERT   V0CDGCOBER' */
                        _.Display($"R120 - PROBLEMAS INSERT   V0CDGCOBER");

                        /*" -552- DISPLAY 'NRCERTIF    ' V0PROP-NRCERTIF */
                        _.Display($"NRCERTIF    {V0PROP_NRCERTIF}");

                        /*" -553- DISPLAY 'CODCLIEN    ' V0PROP-CODCLIEN */
                        _.Display($"CODCLIEN    {V0PROP_CODCLIEN}");

                        /*" -554- DISPLAY 'SQLCODE     ' SQLCODE */
                        _.Display($"SQLCODE     {DB.SQLCODE}");

                        /*" -555- GO TO 9999-ERRO */

                        M_9999_ERRO_SECTION(); //GOTO
                        return;

                        /*" -556- END-IF */
                    }


                    /*" -557- ELSE */
                }
                else
                {


                    /*" -558- DISPLAY 'R120 - PROBLEMAS ACESSO A V0CDGCOBER' */
                    _.Display($"R120 - PROBLEMAS ACESSO A V0CDGCOBER");

                    /*" -559- DISPLAY 'NRCERTIF    ' V0PROP-NRCERTIF */
                    _.Display($"NRCERTIF    {V0PROP_NRCERTIF}");

                    /*" -560- DISPLAY 'CODCLIEN    ' V0PROP-CODCLIEN */
                    _.Display($"CODCLIEN    {V0PROP_CODCLIEN}");

                    /*" -561- DISPLAY 'SQLCODE     ' SQLCODE */
                    _.Display($"SQLCODE     {DB.SQLCODE}");

                    /*" -563- GO TO 9999-ERRO. */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -563- ADD 1 TO AC-L-CDGCOBER. */
            AC_L_CDGCOBER.Value = AC_L_CDGCOBER + 1;

        }

        [StopWatch]
        /*" R120-SELECT-CDGCOBER-DB-SELECT-1 */
        public void R120_SELECT_CDGCOBER_DB_SELECT_1()
        {
            /*" -532- EXEC SQL SELECT DTTERVIG, OCORHIST, NRCERTIF INTO :V0CDGC-DTTERVIG, :V0CDGC-OCORHIST, :V0CDGC-NRCERTIF FROM SEGUROS.V0CDGCOBER WHERE CODCLIEN = :V0PROP-CODCLIEN AND DTTERVIG = '9999-12-31' END-EXEC. */

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

        [StopWatch]
        /*" R120-SELECT-CDGCOBER-DB-INSERT-1 */
        public void R120_SELECT_CDGCOBER_DB_INSERT_1()
        {
            /*" -548- EXEC SQL INSERT INTO SEGUROS.V0CDGCOBER VALUES (:V0PROP-CODCLIEN, :V0FATUR-DTREFER, '9999-12-31' , :V0COBV-IMPSEGCDG, :V0COBV-VLCUSTCDG, :V0PROP-NRCERTIF, 0, '0' , 'VA6421B' , CURRENT TIMESTAMP) END-EXEC */

            var r120_SELECT_CDGCOBER_DB_INSERT_1_Insert1 = new R120_SELECT_CDGCOBER_DB_INSERT_1_Insert1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0FATUR_DTREFER = V0FATUR_DTREFER.ToString(),
                V0COBV_IMPSEGCDG = V0COBV_IMPSEGCDG.ToString(),
                V0COBV_VLCUSTCDG = V0COBV_VLCUSTCDG.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            R120_SELECT_CDGCOBER_DB_INSERT_1_Insert1.Execute(r120_SELECT_CDGCOBER_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/

        [StopWatch]
        /*" R130-GERA-REPASSE-CDG-SECTION */
        private void R130_GERA_REPASSE_CDG_SECTION()
        {
            /*" -576- MOVE 'R130-GERA-REPASSE-CDG' TO PARAGRAFO. */
            _.Move("R130-GERA-REPASSE-CDG", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -586- PERFORM R130_GERA_REPASSE_CDG_DB_INSERT_1 */

            R130_GERA_REPASSE_CDG_DB_INSERT_1();

            /*" -589- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -590- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -591- GO TO R130-EXIT */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R130_EXIT*/ //GOTO
                    return;

                    /*" -592- ELSE */
                }
                else
                {


                    /*" -593- DISPLAY 'PROBLEMA INSERT DA V0REPASSECDG...' */
                    _.Display($"PROBLEMA INSERT DA V0REPASSECDG...");

                    /*" -594- DISPLAY ' CERTIF    ' V0PROP-NRCERTIF */
                    _.Display($" CERTIF    {V0PROP_NRCERTIF}");

                    /*" -595- DISPLAY ' CODCLI    ' V0PROP-CODCLIEN */
                    _.Display($" CODCLI    {V0PROP_CODCLIEN}");

                    /*" -596- DISPLAY ' DTINIVIG  ' V0CDGC-DTINIVIG */
                    _.Display($" DTINIVIG  {V0CDGC_DTINIVIG}");

                    /*" -597- DISPLAY ' SQLCODE   ' SQLCODE */
                    _.Display($" SQLCODE   {DB.SQLCODE}");

                    /*" -599- GO TO 9999-ERRO. */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -599- ADD 1 TO AC-I-REPASSECDG. */
            AC_I_REPASSECDG.Value = AC_I_REPASSECDG + 1;

        }

        [StopWatch]
        /*" R130-GERA-REPASSE-CDG-DB-INSERT-1 */
        public void R130_GERA_REPASSE_CDG_DB_INSERT_1()
        {
            /*" -586- EXEC SQL INSERT INTO SEGUROS.V0REPASSECDG VALUES (:V0PROP-CODCLIEN, :V0FATUR-DTREFER, :V0COBV-VLCUSTCDG, :V0PROP-NRCERTIF, 0, '0' , :V0SIST-DTMOVABE, CURRENT TIMESTAMP) END-EXEC. */

            var r130_GERA_REPASSE_CDG_DB_INSERT_1_Insert1 = new R130_GERA_REPASSE_CDG_DB_INSERT_1_Insert1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0FATUR_DTREFER = V0FATUR_DTREFER.ToString(),
                V0COBV_VLCUSTCDG = V0COBV_VLCUSTCDG.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0SIST_DTMOVABE = V0SIST_DTMOVABE.ToString(),
            };

            R130_GERA_REPASSE_CDG_DB_INSERT_1_Insert1.Execute(r130_GERA_REPASSE_CDG_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R130_EXIT*/

        [StopWatch]
        /*" M-9999-ERRO-SECTION */
        private void M_9999_ERRO_SECTION()
        {
            /*" -614- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.FILLER_8.WSQLCODE);

            /*" -615- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], WABEND.FILLER_8.WSQLERRD1);

            /*" -616- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], WABEND.FILLER_8.WSQLERRD2);

            /*" -618- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -619- DISPLAY '** VA6421B ** LIDOS PROPOVA     ' AC-L-PROPOVA */
            _.Display($"** VA6421B ** LIDOS PROPOVA     {AC_L_PROPOVA}");

            /*" -620- DISPLAY '** VA6421B ** LIDOS COBERPROP   ' AC-L-COBERPROPVA */
            _.Display($"** VA6421B ** LIDOS COBERPROP   {AC_L_COBERPROPVA}");

            /*" -621- DISPLAY '** VA6421B ** LIDOS CDGCOBER    ' AC-L-CDGCOBER */
            _.Display($"** VA6421B ** LIDOS CDGCOBER    {AC_L_CDGCOBER}");

            /*" -622- DISPLAY '** VA6421B ** LIDOS SEGURAVG    ' AC-L-SEGURAVG */
            _.Display($"** VA6421B ** LIDOS SEGURAVG    {AC_L_SEGURAVG}");

            /*" -623- DISPLAY '** VA6421B ** LIDOS HISTSEGVG   ' AC-L-HISTSEGVG */
            _.Display($"** VA6421B ** LIDOS HISTSEGVG   {AC_L_HISTSEGVG}");

            /*" -624- DISPLAY '                                ' . */
            _.Display($"                                ");

            /*" -625- DISPLAY '** VA6421B ** INCL. REPASSECDG  ' AC-I-REPASSECDG */
            _.Display($"** VA6421B ** INCL. REPASSECDG  {AC_I_REPASSECDG}");

            /*" -626- DISPLAY '                                ' . */
            _.Display($"                                ");

            /*" -627- DISPLAY '** VA6421B ** TERMINO ANORMAL   ' . */
            _.Display($"** VA6421B ** TERMINO ANORMAL   ");

            /*" -629- DISPLAY '                                ' . */
            _.Display($"                                ");

            /*" -631- DISPLAY '*** VA6421B *** ROLLBACK EM ANDAMENTO ...' . */
            _.Display($"*** VA6421B *** ROLLBACK EM ANDAMENTO ...");

            /*" -631- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -634- MOVE '9999-ERRO' TO PARAGRAFO. */
            _.Move("9999-ERRO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -635- MOVE 'ROLLBACK WORK' TO COMANDO. */
            _.Move("ROLLBACK WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -635- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -639- DISPLAY '*** VA6421B *** ERRO DE EXECUCAO' . */
            _.Display($"*** VA6421B *** ERRO DE EXECUCAO");

            /*" -640- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -640- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9999_FIM*/
    }
}