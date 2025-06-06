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
using Sias.VidaEmGrupo.DB2.VG0000B;

namespace Code
{
    public class VG0000B
    {
        public bool IsCall { get; set; }

        public VG0000B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  ATUALIZAR A BASE EM QUALQUER SITU- *      */
        /*"      *                             ACAO.                              *      */
        /*"      *                                                                *      */
        /*"      *            ARGUS  ======>>> VERSAO PARA ACERTA A FATURA DA     *      */
        /*"      *                             MARISA                             *      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA ...............  MANOEL MESSIAS                     *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  VG0000B                            *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  28/04/2004                         *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *                   A L T E R A C O E S                          *      */
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  VGFUNCOB-QTD-VIDAS               PIC S9(04)    COMP VALUE +0*/
        public IntBasis VGFUNCOB_QTD_VIDAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  VIND-DTQITBCO                    PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_DTQITBCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  VIND-AGECTADEB                   PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_AGECTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  VIND-OPRCTADEB                   PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_OPRCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  VIND-NUMCTADEB                   PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_NUMCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  VIND-DIGCTADEB                   PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_DIGCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  VIND-INDRCAP                     PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_INDRCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  VIND-TEM-CDG                     PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_TEM_CDG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  VIND-TEM-SAF                     PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_TEM_SAF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  VIND-ROT-SAF                     PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_ROT_SAF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  VIND-COD-PROD-EA                 PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_COD_PROD_EA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HOST-IND                         PIC S9(04)    COMP VALUE +0*/
        public IntBasis HOST_IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  CLIENTES-DATA-NASCIMENTO-I       PIC S9(04)    COMP.*/
        public IntBasis CLIENTES_DATA_NASCIMENTO_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HISCONPA-DTFATUR-I               PIC S9(04)    COMP.*/
        public IntBasis HISCONPA_DTFATUR_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  SISTEMAS-DATA-ANTERIOR           PIC  X(10).*/
        public StringBasis SISTEMAS_DATA_ANTERIOR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  H-NUM-CERTIFICADO                PIC S9(015)   COMP-3.*/
        public IntBasis H_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77  H-DAC-CERTIFICADO                PIC  X(001).*/
        public StringBasis H_DAC_CERTIFICADO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  WHOST-PCT-IOCC-RAMO              PIC S9(003)V9(05).*/
        public DoubleBasis WHOST_PCT_IOCC_RAMO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(05)."), 5);
        /*"77  VGSOLFAT-PRM-TOTAL               PIC S9(013)V9(02) COMP-3.*/
        public DoubleBasis VGSOLFAT_PRM_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"01  DCLSISTEMAS.*/
        public VG0000B_DCLSISTEMAS DCLSISTEMAS { get; set; } = new VG0000B_DCLSISTEMAS();
        public class VG0000B_DCLSISTEMAS : VarBasis
        {
            /*"    10 SISTEMAS-IDE-SISTEMA          PIC X(2).*/
            public StringBasis SISTEMAS_IDE_SISTEMA { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
            /*"    10 SISTEMAS-DATA-MOV-ABERTO      PIC X(10).*/
            public StringBasis SISTEMAS_DATA_MOV_ABERTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    10 SISTEMAS-COD-EMPRESA          PIC S9(9) USAGE COMP.*/
            public IntBasis SISTEMAS_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
            /*"    10 SISTEMAS-DATULT-PROCESSAMEN   PIC X(10).*/
            public StringBasis SISTEMAS_DATULT_PROCESSAMEN { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"01  WS-WORK-AREAS.*/
        }
        public VG0000B_WS_WORK_AREAS WS_WORK_AREAS { get; set; } = new VG0000B_WS_WORK_AREAS();
        public class VG0000B_WS_WORK_AREAS : VarBasis
        {
            /*"    03 WS-ORIG-PRODU                 PIC  X(010) VALUE SPACES.*/
            public StringBasis WS_ORIG_PRODU { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    03 WANO                          PIC  9(002) VALUE ZEROES.*/
            public IntBasis WANO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"    03 WS-PRODU                      PIC  9(004) VALUE ZEROES.*/
            public IntBasis WS_PRODU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    03 WS-PERIPGTO                   PIC  9(002) VALUE ZEROES.*/
            public IntBasis WS_PERIPGTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"    03 WS-TEM-ERRO                   PIC  X(001) VALUE 'N'.*/
            public StringBasis WS_TEM_ERRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"    03 WS-PCT-VG                     PIC S9(013)V99  COMP-3.*/
            public DoubleBasis WS_PCT_VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    03 WS-PCT-AP                     PIC S9(013)V99  COMP-3.*/
            public DoubleBasis WS_PCT_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    03 WS-DATA-BASE.*/
            public VG0000B_WS_DATA_BASE WS_DATA_BASE { get; set; } = new VG0000B_WS_DATA_BASE();
            public class VG0000B_WS_DATA_BASE : VarBasis
            {
                /*"       05 WS-ANO-BASE                PIC  9(004).*/
                public IntBasis WS_ANO_BASE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05 FILLER                     PIC  X(001).*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05 WS-MES-BASE                PIC  9(002).*/
                public IntBasis WS_MES_BASE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05 FILLER                     PIC  X(001).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05 WS-DIA-BASE                PIC  9(002).*/
                public IntBasis WS_DIA_BASE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03 WS-ACHEI-PROPOVA              PIC  X(001)   VALUE SPACES.*/
            }
            public StringBasis WS_ACHEI_PROPOVA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    03 WCERTIFICADO                  PIC  9(015)   VALUE ZEROS.*/
            public IntBasis WCERTIFICADO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"    03 FILLER                        REDEFINES     WCERTIFICADO.*/
            private _REDEF_VG0000B_FILLER_2 _filler_2 { get; set; }
            public _REDEF_VG0000B_FILLER_2 FILLER_2
            {
                get { _filler_2 = new _REDEF_VG0000B_FILLER_2(); _.Move(WCERTIFICADO, _filler_2); VarBasis.RedefinePassValue(WCERTIFICADO, _filler_2, WCERTIFICADO); _filler_2.ValueChanged += () => { _.Move(_filler_2, WCERTIFICADO); }; return _filler_2; }
                set { VarBasis.RedefinePassValue(value, _filler_2, WCERTIFICADO); }
            }  //Redefines
            public class _REDEF_VG0000B_FILLER_2 : VarBasis
            {
                /*"       05 WNRCERTIF                  PIC  9(014).*/
                public IntBasis WNRCERTIF { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                /*"       05 WDVCERTIF                  PIC  9(001).*/
                public IntBasis WDVCERTIF { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    03 WFIM-V1RCAP                   PIC X VALUE SPACES.*/

                public _REDEF_VG0000B_FILLER_2()
                {
                    WNRCERTIF.ValueChanged += OnValueChanged;
                    WDVCERTIF.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WFIM_V1RCAP { get; set; } = new StringBasis(new PIC("X", "1", "X"), @"");
            /*"    03 WFIM-SEGURAVG                 PIC X VALUE SPACES.*/
            public StringBasis WFIM_SEGURAVG { get; set; } = new StringBasis(new PIC("X", "1", "X"), @"");
            /*"    03 WTEM-COBERTURA                PIC X VALUE SPACES.*/
            public StringBasis WTEM_COBERTURA { get; set; } = new StringBasis(new PIC("X", "1", "X"), @"");
            /*"    03 AC-L-SOLICITA                 PIC  9(006) VALUE  0.*/
            public IntBasis AC_L_SOLICITA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-L-COMMIT                   PIC  9(006) VALUE  0.*/
            public IntBasis AC_L_COMMIT { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-L-PARCELASVG               PIC  9(006) VALUE  0.*/
            public IntBasis AC_L_PARCELASVG { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-I-PROPOSTAVA               PIC  9(006) VALUE  0.*/
            public IntBasis AC_I_PROPOSTAVA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-I-COBERPROPVA              PIC  9(006) VALUE  0.*/
            public IntBasis AC_I_COBERPROPVA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-I-OPCAOPAGVA               PIC  9(006) VALUE  0.*/
            public IntBasis AC_I_OPCAOPAGVA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-I-PARCELVA                 PIC  9(006) VALUE  0.*/
            public IntBasis AC_I_PARCELVA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-I-HISTCOBVA                PIC  9(006) VALUE  0.*/
            public IntBasis AC_I_HISTCOBVA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-I-HISTCTAVA                PIC  9(006) VALUE  0.*/
            public IntBasis AC_I_HISTCTAVA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-I-HISTCTABI                PIC  9(006) VALUE  0.*/
            public IntBasis AC_I_HISTCTABI { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-I-CONVEVG                  PIC  9(006) VALUE  0.*/
            public IntBasis AC_I_CONVEVG { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-I-PRODUVG                  PIC  9(006) VALUE  0.*/
            public IntBasis AC_I_PRODUVG { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-W-CONTA                    PIC  9(006) VALUE  0.*/
            public IntBasis AC_W_CONTA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-ACEITOS                    PIC  9(006) VALUE  0.*/
            public IntBasis AC_ACEITOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 WS-TIME                       PIC  X(008).*/
            public StringBasis WS_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    03 WDIFERENCA                    PIC S9(13)V99 COMP VALUE +0*/
            public DoubleBasis WDIFERENCA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    03 WDATA-INIVIG.*/
            public VG0000B_WDATA_INIVIG WDATA_INIVIG { get; set; } = new VG0000B_WDATA_INIVIG();
            public class VG0000B_WDATA_INIVIG : VarBasis
            {
                /*"       05 ANO-INIVIG                 PIC 9(04).*/
                public IntBasis ANO_INIVIG { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       05 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 MES-INIVIG                 PIC 9(02).*/
                public IntBasis MES_INIVIG { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       05 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 DIA-INIVIG                 PIC 9(02).*/
                public IntBasis DIA_INIVIG { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    03 WDATA-NASC.*/
            }
            public VG0000B_WDATA_NASC WDATA_NASC { get; set; } = new VG0000B_WDATA_NASC();
            public class VG0000B_WDATA_NASC : VarBasis
            {
                /*"       05 ANO-NASC                   PIC 9(04).*/
                public IntBasis ANO_NASC { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       05 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 MES-NASC                   PIC 9(02).*/
                public IntBasis MES_NASC { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       05 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 DIA-NASC                   PIC 9(02).*/
                public IntBasis DIA_NASC { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    03 WS-DATA-SQL.*/
            }
            public VG0000B_WS_DATA_SQL WS_DATA_SQL { get; set; } = new VG0000B_WS_DATA_SQL();
            public class VG0000B_WS_DATA_SQL : VarBasis
            {
                /*"       05 WS-ANO-SQL                 PIC 9(04).*/
                public IntBasis WS_ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       05 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 WS-MES-SQL                 PIC 9(02).*/
                public IntBasis WS_MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       05 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 WS-DIA-SQL                 PIC 9(02).*/
                public IntBasis WS_DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    03 WDATA-PARC-ATU.*/
            }
            public VG0000B_WDATA_PARC_ATU WDATA_PARC_ATU { get; set; } = new VG0000B_WDATA_PARC_ATU();
            public class VG0000B_WDATA_PARC_ATU : VarBasis
            {
                /*"       05 WDATA-PAR-ANO              PIC 9(04).*/
                public IntBasis WDATA_PAR_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       05 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 WDATA-PAR-MES              PIC 9(02).*/
                public IntBasis WDATA_PAR_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       05 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 WDATA-PAR-DIA              PIC 9(02).*/
                public IntBasis WDATA_PAR_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    03 WDATA-PARC-PRX.*/
            }
            public VG0000B_WDATA_PARC_PRX WDATA_PARC_PRX { get; set; } = new VG0000B_WDATA_PARC_PRX();
            public class VG0000B_WDATA_PARC_PRX : VarBasis
            {
                /*"       05 WDATA-PRX-ANO              PIC 9(04).*/
                public IntBasis WDATA_PRX_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       05 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 WDATA-PRX-MES              PIC 9(02).*/
                public IntBasis WDATA_PRX_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       05 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 WDATA-PRX-DIA              PIC 9(02).*/
                public IntBasis WDATA_PRX_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    03 WDATA-INIVIGENCIA.*/
            }
            public VG0000B_WDATA_INIVIGENCIA WDATA_INIVIGENCIA { get; set; } = new VG0000B_WDATA_INIVIGENCIA();
            public class VG0000B_WDATA_INIVIGENCIA : VarBasis
            {
                /*"       05 WDATA-INI-ANO              PIC 9(04).*/
                public IntBasis WDATA_INI_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       05 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 WDATA-INI-MES              PIC 9(02).*/
                public IntBasis WDATA_INI_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       05 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 WDATA-INI-DIA              PIC 9(02).*/
                public IntBasis WDATA_INI_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    03  W-NUMR-TITULO                PIC  9(013)   VALUE ZEROS.*/
            }
            public IntBasis W_NUMR_TITULO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"    03  FILLER                       REDEFINES    W-NUMR-TITULO.*/
            private _REDEF_VG0000B_FILLER_15 _filler_15 { get; set; }
            public _REDEF_VG0000B_FILLER_15 FILLER_15
            {
                get { _filler_15 = new _REDEF_VG0000B_FILLER_15(); _.Move(W_NUMR_TITULO, _filler_15); VarBasis.RedefinePassValue(W_NUMR_TITULO, _filler_15, W_NUMR_TITULO); _filler_15.ValueChanged += () => { _.Move(_filler_15, W_NUMR_TITULO); }; return _filler_15; }
                set { VarBasis.RedefinePassValue(value, _filler_15, W_NUMR_TITULO); }
            }  //Redefines
            public class _REDEF_VG0000B_FILLER_15 : VarBasis
            {
                /*"      05    WTITL-ZEROS              PIC  9(002).*/
                public IntBasis WTITL_ZEROS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05    WTITL-SEQUENCIA          PIC  9(010).*/
                public IntBasis WTITL_SEQUENCIA { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"      05    WTITL-DIGITO             PIC  9(001).*/
                public IntBasis WTITL_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    03              DPARM01X.*/

                public _REDEF_VG0000B_FILLER_15()
                {
                    WTITL_ZEROS.ValueChanged += OnValueChanged;
                    WTITL_SEQUENCIA.ValueChanged += OnValueChanged;
                    WTITL_DIGITO.ValueChanged += OnValueChanged;
                }

            }
            public VG0000B_DPARM01X DPARM01X { get; set; } = new VG0000B_DPARM01X();
            public class VG0000B_DPARM01X : VarBasis
            {
                /*"      05            DPARM01          PIC  9(010).*/
                public IntBasis DPARM01 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"      05            DPARM01-R        REDEFINES   DPARM01.*/
                private _REDEF_VG0000B_DPARM01_R _dparm01_r { get; set; }
                public _REDEF_VG0000B_DPARM01_R DPARM01_R
                {
                    get { _dparm01_r = new _REDEF_VG0000B_DPARM01_R(); _.Move(DPARM01, _dparm01_r); VarBasis.RedefinePassValue(DPARM01, _dparm01_r, DPARM01); _dparm01_r.ValueChanged += () => { _.Move(_dparm01_r, DPARM01); }; return _dparm01_r; }
                    set { VarBasis.RedefinePassValue(value, _dparm01_r, DPARM01); }
                }  //Redefines
                public class _REDEF_VG0000B_DPARM01_R : VarBasis
                {
                    /*"        10          DPARM01-1        PIC  9(001).*/
                    public IntBasis DPARM01_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-2        PIC  9(001).*/
                    public IntBasis DPARM01_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-3        PIC  9(001).*/
                    public IntBasis DPARM01_3 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-4        PIC  9(001).*/
                    public IntBasis DPARM01_4 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-5        PIC  9(001).*/
                    public IntBasis DPARM01_5 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-6        PIC  9(001).*/
                    public IntBasis DPARM01_6 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-7        PIC  9(001).*/
                    public IntBasis DPARM01_7 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-8        PIC  9(001).*/
                    public IntBasis DPARM01_8 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-9        PIC  9(001).*/
                    public IntBasis DPARM01_9 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-10       PIC  9(001).*/
                    public IntBasis DPARM01_10 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      05            DPARM01-D1       PIC  9(001).*/

                    public _REDEF_VG0000B_DPARM01_R()
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
                /*"      05            DPARM01-RC       PIC S9(004) COMP VALUE +0.*/
                public IntBasis DPARM01_RC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    03          W01DIGCERT.*/
            }
            public VG0000B_W01DIGCERT W01DIGCERT { get; set; } = new VG0000B_W01DIGCERT();
            public class VG0000B_W01DIGCERT : VarBasis
            {
                /*"      05        WCERTIFICADO    PIC  9(015)        VALUE  0.*/
                public IntBasis WCERTIFICADO_0 { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
                /*"      05        WNUMERO         PIC S9(004)  COMP  VALUE +15.*/
                public IntBasis WNUMERO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +15);
                /*"      05        WDIG            PIC  X(001)  VALUE SPACES.*/
                public StringBasis WDIG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"01  TABELA-ULTIMOS-DIAS.*/
            }
        }
        public VG0000B_TABELA_ULTIMOS_DIAS TABELA_ULTIMOS_DIAS { get; set; } = new VG0000B_TABELA_ULTIMOS_DIAS();
        public class VG0000B_TABELA_ULTIMOS_DIAS : VarBasis
        {
            /*"    05 FILLER                      PIC  X(024)  VALUE                                  '312831303130313130313031'.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"312831303130313130313031");
            /*"01  TAB-ULTIMOS-DIAS               REDEFINES                                   TABELA-ULTIMOS-DIAS.*/
        }
        private _REDEF_VG0000B_TAB_ULTIMOS_DIAS _tab_ultimos_dias { get; set; }
        public _REDEF_VG0000B_TAB_ULTIMOS_DIAS TAB_ULTIMOS_DIAS
        {
            get { _tab_ultimos_dias = new _REDEF_VG0000B_TAB_ULTIMOS_DIAS(); _.Move(TABELA_ULTIMOS_DIAS, _tab_ultimos_dias); VarBasis.RedefinePassValue(TABELA_ULTIMOS_DIAS, _tab_ultimos_dias, TABELA_ULTIMOS_DIAS); _tab_ultimos_dias.ValueChanged += () => { _.Move(_tab_ultimos_dias, TABELA_ULTIMOS_DIAS); }; return _tab_ultimos_dias; }
            set { VarBasis.RedefinePassValue(value, _tab_ultimos_dias, TABELA_ULTIMOS_DIAS); }
        }  //Redefines
        public class _REDEF_VG0000B_TAB_ULTIMOS_DIAS : VarBasis
        {
            /*"    05 TAB-DIA-MESES               OCCURS 12.*/
            public ListBasis<VG0000B_TAB_DIA_MESES> TAB_DIA_MESES { get; set; } = new ListBasis<VG0000B_TAB_DIA_MESES>(12);
            public class VG0000B_TAB_DIA_MESES : VarBasis
            {
                /*"      07 TAB-DIA-MES               PIC  9(002).*/
                public IntBasis TAB_DIA_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"01  TABELA-PRODUTOS.*/

                public VG0000B_TAB_DIA_MESES()
                {
                    TAB_DIA_MES.ValueChanged += OnValueChanged;
                }

            }

            public _REDEF_VG0000B_TAB_ULTIMOS_DIAS()
            {
                TAB_DIA_MESES.ValueChanged += OnValueChanged;
            }

        }
        public VG0000B_TABELA_PRODUTOS TABELA_PRODUTOS { get; set; } = new VG0000B_TABELA_PRODUTOS();
        public class VG0000B_TABELA_PRODUTOS : VarBasis
        {
            /*"    05 FILLER                      PIC  X(010)  VALUE                                  '9706019712'.*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"9706019712");
            /*"    05 FILLER                      PIC  X(010)  VALUE                                  '9706039713'.*/
            public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"9706039713");
            /*"    05 FILLER                      PIC  X(010)  VALUE                                  '9706069714'.*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"9706069714");
            /*"    05 FILLER                      PIC  X(010)  VALUE                                  '9706129715'.*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"9706129715");
            /*"01  TAB-PRODUTOS-NOVOS             REDEFINES                                   TABELA-PRODUTOS.*/
        }
        private _REDEF_VG0000B_TAB_PRODUTOS_NOVOS _tab_produtos_novos { get; set; }
        public _REDEF_VG0000B_TAB_PRODUTOS_NOVOS TAB_PRODUTOS_NOVOS
        {
            get { _tab_produtos_novos = new _REDEF_VG0000B_TAB_PRODUTOS_NOVOS(); _.Move(TABELA_PRODUTOS, _tab_produtos_novos); VarBasis.RedefinePassValue(TABELA_PRODUTOS, _tab_produtos_novos, TABELA_PRODUTOS); _tab_produtos_novos.ValueChanged += () => { _.Move(_tab_produtos_novos, TABELA_PRODUTOS); }; return _tab_produtos_novos; }
            set { VarBasis.RedefinePassValue(value, _tab_produtos_novos, TABELA_PRODUTOS); }
        }  //Redefines
        public class _REDEF_VG0000B_TAB_PRODUTOS_NOVOS : VarBasis
        {
            /*"    05 TAB-NOVOS-PRODUTOS          OCCURS 04 TIMES         ASCENDING TAB-PROD-ANT TAB-PERIPGTO         INDEXED BY IDX-PROD.*/
            public ListBasis<VG0000B_TAB_NOVOS_PRODUTOS> TAB_NOVOS_PRODUTOS { get; set; } = new ListBasis<VG0000B_TAB_NOVOS_PRODUTOS>(04);
            public class VG0000B_TAB_NOVOS_PRODUTOS : VarBasis
            {
                /*"      07 TAB-PROD-ANT              PIC  9(004).*/
                public IntBasis TAB_PROD_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      07 TAB-PERIPGTO              PIC  9(002).*/
                public IntBasis TAB_PERIPGTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      07 TAB-PROD-NEW              PIC  9(004).*/
                public IntBasis TAB_PROD_NEW { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"01  WABEND.*/

                public VG0000B_TAB_NOVOS_PRODUTOS()
                {
                    TAB_PROD_ANT.ValueChanged += OnValueChanged;
                    TAB_PERIPGTO.ValueChanged += OnValueChanged;
                    TAB_PROD_NEW.ValueChanged += OnValueChanged;
                }

            }

            public _REDEF_VG0000B_TAB_PRODUTOS_NOVOS()
            {
                TAB_NOVOS_PRODUTOS.ValueChanged += OnValueChanged;
            }

        }
        public VG0000B_WABEND WABEND { get; set; } = new VG0000B_WABEND();
        public class VG0000B_WABEND : VarBasis
        {
            /*"      10    FILLER                   PIC  X(016) VALUE            '*** VG0000B *** '.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"*** VG0000B *** ");
            /*"      10    FILLER                   PIC  X(013) VALUE            'ERRO SQL *** '.*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"ERRO SQL *** ");
            /*"      10    FILLER                   PIC  X(010) VALUE            'SQLCODE = '.*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"SQLCODE = ");
            /*"      10    WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10    FILLER                   PIC  X(011)   VALUE            'SQLERRD1 = '.*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"SQLERRD1 = ");
            /*"      10    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10    FILLER                   PIC  X(011)   VALUE            'SQLERRD2 = '.*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"SQLERRD2 = ");
            /*"      10    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"05  LOCALIZA-ABEND-1.*/
        }
        public VG0000B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new VG0000B_LOCALIZA_ABEND_1();
        public class VG0000B_LOCALIZA_ABEND_1 : VarBasis
        {
            /*"      10    FILLER           PIC  X(012)   VALUE 'PARAGRAFO = '.*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
            /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
            public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"05  LOCALIZA-ABEND-2.*/
        }
        public VG0000B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new VG0000B_LOCALIZA_ABEND_2();
        public class VG0000B_LOCALIZA_ABEND_2 : VarBasis
        {
            /*"      10    FILLER           PIC  X(012)   VALUE 'COMANDO   = '.*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
            /*"      10    COMANDO                  PIC  X(060)   VALUE SPACES.*/
            public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
        }

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
            /*" -257- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -259- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -261- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -265- MOVE '0000-PRINCIPAL' TO PARAGRAFO. */
            _.Move("0000-PRINCIPAL", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -270- PERFORM M_0000_PRINCIPAL_DB_SELECT_1 */

            M_0000_PRINCIPAL_DB_SELECT_1();

            /*" -273- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -274- DISPLAY 'ERRO SELECT SISTEMAS ' SQLCODE */
                _.Display($"ERRO SELECT SISTEMAS {DB.SQLCODE}");

                /*" -276- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -278- IF SISTEMAS-DATA-MOV-ABERTO NOT EQUAL '2005-09-09' */

            if (DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO != "2005-09-09")
            {

                /*" -279- DISPLAY 'SEM MOVIMENTACAO NO PERIODO' */
                _.Display($"SEM MOVIMENTACAO NO PERIODO");

                /*" -281- GO TO 0000-FIM-NORMAL. */

                M_0000_FIM_NORMAL(); //GOTO
                return;
            }


            /*" -283- DISPLAY '*** INICIANDO ATUALIZACAO  ***' . */
            _.Display($"*** INICIANDO ATUALIZACAO  ***");

            /*" -287- PERFORM M_0000_PRINCIPAL_DB_UPDATE_1 */

            M_0000_PRINCIPAL_DB_UPDATE_1();

            /*" -290- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -291- DISPLAY 'ERRO NO UPDATE V0PROPOSTAVA' */
                _.Display($"ERRO NO UPDATE V0PROPOSTAVA");

                /*" -293- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -293- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -0- FLUXCONTROL_PERFORM M_0000_FIM_NORMAL */

            M_0000_FIM_NORMAL();

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-SELECT-1 */
        public void M_0000_PRINCIPAL_DB_SELECT_1()
        {
            /*" -270- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VG' END-EXEC. */

            var m_0000_PRINCIPAL_DB_SELECT_1_Query1 = new M_0000_PRINCIPAL_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_0000_PRINCIPAL_DB_SELECT_1_Query1.Execute(m_0000_PRINCIPAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-UPDATE-1 */
        public void M_0000_PRINCIPAL_DB_UPDATE_1()
        {
            /*" -287- EXEC SQL UPDATE SEGUROS.V0PROPOSTAVA SET OCORHIST = 17 WHERE NRCERTIF = 10020079849 END-EXEC */

            var m_0000_PRINCIPAL_DB_UPDATE_1_Update1 = new M_0000_PRINCIPAL_DB_UPDATE_1_Update1()
            {
            };

            M_0000_PRINCIPAL_DB_UPDATE_1_Update1.Execute(m_0000_PRINCIPAL_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-0000-FIM-NORMAL */
        private void M_0000_FIM_NORMAL(bool isPerform = false)
        {
            /*" -299- MOVE 'COMMIT WORK' TO COMANDO. */
            _.Move("COMMIT WORK", LOCALIZA_ABEND_2.COMANDO);

            /*" -299- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -303- DISPLAY '** VG0000B ** TERMINO NORMAL    ' . */
            _.Display($"** VG0000B ** TERMINO NORMAL    ");

            /*" -305- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -305- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_FIM*/

        [StopWatch]
        /*" M-9999-ERRO-SECTION */
        private void M_9999_ERRO_SECTION()
        {
            /*" -318- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -319- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], WABEND.WSQLERRD1);

            /*" -320- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], WABEND.WSQLERRD2);

            /*" -322- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -324- DISPLAY '*** VG0000B *** ROLLBACK EM ANDAMENTO ...' . */
            _.Display($"*** VG0000B *** ROLLBACK EM ANDAMENTO ...");

            /*" -324- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -327- MOVE '9999' TO PARAGRAFO. */
            _.Move("9999", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -328- MOVE 'ROLLBACK WORK' TO COMANDO. */
            _.Move("ROLLBACK WORK", LOCALIZA_ABEND_2.COMANDO);

            /*" -328- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -332- DISPLAY '*** VG0000B *** ERRO DE EXECUCAO' . */
            _.Display($"*** VG0000B *** ERRO DE EXECUCAO");

            /*" -333- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -333- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}