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
using Sias.VidaEmpresarial.DB2.VE1111B;

namespace Code
{
    public class VE1111B
    {
        public bool IsCall { get; set; }

        public VE1111B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  ACERTA MENSALMENTE OS CODIGOS DE   *      */
        /*"      *                             PRODUTO DO EMPRESARIAL.            *      */
        /*"      *                             (NOVO FATURAMENTO).                *      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA ...............  FREDERICO FONSECA                  *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  VE1111B                            *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  22/07/2003                         *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *                   A L T E R A C O E S                          *      */
        /*"      ******************************************************************      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01                                                    *      */
        /*"      *             - CAD 19.164                                       *      */
        /*"      *               PROBLEMA NA LEITURA DA PROPOSTAS_VA SQLCODE 100  *      */
        /*"      *                                                                *      */
        /*"      *   EM 02/01/2009 - FAST COMPUTER            PROCURE POR V.01    *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * PROJETO FGV (ALTERACOES)     (WELLINGTON VERAS (POLITEC))      *      */
        /*"      *                                                                *      */
        /*"      * 13/10/2008 - INCLUIR CLAUSULA WITH UR NO SELECT     - WV1008   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
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
        /*"01  WS-WORK-AREAS.*/
        public VE1111B_WS_WORK_AREAS WS_WORK_AREAS { get; set; } = new VE1111B_WS_WORK_AREAS();
        public class VE1111B_WS_WORK_AREAS : VarBasis
        {
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
            public VE1111B_WS_DATA_BASE WS_DATA_BASE { get; set; } = new VE1111B_WS_DATA_BASE();
            public class VE1111B_WS_DATA_BASE : VarBasis
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
                /*"    03 W01DTSQL                      PIC  X(010).*/
            }
            public StringBasis W01DTSQL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    03 W01DTSQL-R REDEFINES W01DTSQL.*/
            private _REDEF_VE1111B_W01DTSQL_R _w01dtsql_r { get; set; }
            public _REDEF_VE1111B_W01DTSQL_R W01DTSQL_R
            {
                get { _w01dtsql_r = new _REDEF_VE1111B_W01DTSQL_R(); _.Move(W01DTSQL, _w01dtsql_r); VarBasis.RedefinePassValue(W01DTSQL, _w01dtsql_r, W01DTSQL); _w01dtsql_r.ValueChanged += () => { _.Move(_w01dtsql_r, W01DTSQL); }; return _w01dtsql_r; }
                set { VarBasis.RedefinePassValue(value, _w01dtsql_r, W01DTSQL); }
            }  //Redefines
            public class _REDEF_VE1111B_W01DTSQL_R : VarBasis
            {
                /*"       05 W01AASQL                   PIC  9(004).*/
                public IntBasis W01AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05 FILLER                     PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05 W01MMSQL                   PIC  9(002).*/
                public IntBasis W01MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05 FILLER                     PIC  X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05 W01DDSQL                   PIC  9(002).*/
                public IntBasis W01DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03 W02DTSQL                      PIC  X(010).*/

                public _REDEF_VE1111B_W01DTSQL_R()
                {
                    W01AASQL.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    W01MMSQL.ValueChanged += OnValueChanged;
                    FILLER_3.ValueChanged += OnValueChanged;
                    W01DDSQL.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W02DTSQL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    03 W02DTSQL-R REDEFINES W02DTSQL.*/
            private _REDEF_VE1111B_W02DTSQL_R _w02dtsql_r { get; set; }
            public _REDEF_VE1111B_W02DTSQL_R W02DTSQL_R
            {
                get { _w02dtsql_r = new _REDEF_VE1111B_W02DTSQL_R(); _.Move(W02DTSQL, _w02dtsql_r); VarBasis.RedefinePassValue(W02DTSQL, _w02dtsql_r, W02DTSQL); _w02dtsql_r.ValueChanged += () => { _.Move(_w02dtsql_r, W02DTSQL); }; return _w02dtsql_r; }
                set { VarBasis.RedefinePassValue(value, _w02dtsql_r, W02DTSQL); }
            }  //Redefines
            public class _REDEF_VE1111B_W02DTSQL_R : VarBasis
            {
                /*"       05 W02AASQL                   PIC  9(004).*/
                public IntBasis W02AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05 FILLER                     PIC  X(001).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05 W02MMSQL                   PIC  9(002).*/
                public IntBasis W02MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05 FILLER                     PIC  X(001).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05 W02DDSQL                   PIC  9(002).*/
                public IntBasis W02DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03 WS-ACHEI-PROPOVA              PIC  X(001)   VALUE SPACES.*/

                public _REDEF_VE1111B_W02DTSQL_R()
                {
                    W02AASQL.ValueChanged += OnValueChanged;
                    FILLER_4.ValueChanged += OnValueChanged;
                    W02MMSQL.ValueChanged += OnValueChanged;
                    FILLER_5.ValueChanged += OnValueChanged;
                    W02DDSQL.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_ACHEI_PROPOVA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    03 WCERTIFICADO                  PIC  9(015)   VALUE ZEROS.*/
            public IntBasis WCERTIFICADO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"    03 FILLER                        REDEFINES     WCERTIFICADO.*/
            private _REDEF_VE1111B_FILLER_6 _filler_6 { get; set; }
            public _REDEF_VE1111B_FILLER_6 FILLER_6
            {
                get { _filler_6 = new _REDEF_VE1111B_FILLER_6(); _.Move(WCERTIFICADO, _filler_6); VarBasis.RedefinePassValue(WCERTIFICADO, _filler_6, WCERTIFICADO); _filler_6.ValueChanged += () => { _.Move(_filler_6, WCERTIFICADO); }; return _filler_6; }
                set { VarBasis.RedefinePassValue(value, _filler_6, WCERTIFICADO); }
            }  //Redefines
            public class _REDEF_VE1111B_FILLER_6 : VarBasis
            {
                /*"       05 WNRCERTIF                  PIC  9(014).*/
                public IntBasis WNRCERTIF { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                /*"       05 WDVCERTIF                  PIC  9(001).*/
                public IntBasis WDVCERTIF { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    03 WFIM-V1RCAP                   PIC X VALUE SPACES.*/

                public _REDEF_VE1111B_FILLER_6()
                {
                    WNRCERTIF.ValueChanged += OnValueChanged;
                    WDVCERTIF.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WFIM_V1RCAP { get; set; } = new StringBasis(new PIC("X", "1", "X"), @"");
            /*"    03 WFIM-PRODUTOS                 PIC X VALUE SPACES.*/
            public StringBasis WFIM_PRODUTOS { get; set; } = new StringBasis(new PIC("X", "1", "X"), @"");
            /*"    03 WTEM-COBERTURA                PIC X VALUE SPACES.*/
            public StringBasis WTEM_COBERTURA { get; set; } = new StringBasis(new PIC("X", "1", "X"), @"");
            /*"    03 AC-L-PRODUVG                  PIC  9(006) VALUE  0.*/
            public IntBasis AC_L_PRODUVG { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-L-COMMIT                   PIC  9(006) VALUE  0.*/
            public IntBasis AC_L_COMMIT { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-L-PARCELASVG               PIC  9(006) VALUE  0.*/
            public IntBasis AC_L_PARCELASVG { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-A-PROPOSTAVA               PIC  9(006) VALUE  0.*/
            public IntBasis AC_A_PROPOSTAVA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-A-PRODUVG                  PIC  9(006) VALUE  0.*/
            public IntBasis AC_A_PRODUVG { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-W-CONTA                    PIC  9(006) VALUE  0.*/
            public IntBasis AC_W_CONTA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-ACEITOS                    PIC  9(006) VALUE  0.*/
            public IntBasis AC_ACEITOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 WS-TIME                       PIC  X(008).*/
            public StringBasis WS_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    03 WDIFERENCA                    PIC S9(13)V99 COMP VALUE +0*/
            public DoubleBasis WDIFERENCA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    03 WDATA-INIVIG.*/
            public VE1111B_WDATA_INIVIG WDATA_INIVIG { get; set; } = new VE1111B_WDATA_INIVIG();
            public class VE1111B_WDATA_INIVIG : VarBasis
            {
                /*"       05 ANO-INIVIG                 PIC 9(04).*/
                public IntBasis ANO_INIVIG { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       05 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 MES-INIVIG                 PIC 9(02).*/
                public IntBasis MES_INIVIG { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       05 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 DIA-INIVIG                 PIC 9(02).*/
                public IntBasis DIA_INIVIG { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    03 WDATA-NASC.*/
            }
            public VE1111B_WDATA_NASC WDATA_NASC { get; set; } = new VE1111B_WDATA_NASC();
            public class VE1111B_WDATA_NASC : VarBasis
            {
                /*"       05 ANO-NASC                   PIC 9(04).*/
                public IntBasis ANO_NASC { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       05 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 MES-NASC                   PIC 9(02).*/
                public IntBasis MES_NASC { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       05 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 DIA-NASC                   PIC 9(02).*/
                public IntBasis DIA_NASC { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    03 WS-DATA-SQL.*/
            }
            public VE1111B_WS_DATA_SQL WS_DATA_SQL { get; set; } = new VE1111B_WS_DATA_SQL();
            public class VE1111B_WS_DATA_SQL : VarBasis
            {
                /*"       05 WS-ANO-SQL                 PIC 9(04).*/
                public IntBasis WS_ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       05 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 WS-MES-SQL                 PIC 9(02).*/
                public IntBasis WS_MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       05 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 WS-DIA-SQL                 PIC 9(02).*/
                public IntBasis WS_DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    03 WDATA-PARC-ATU.*/
            }
            public VE1111B_WDATA_PARC_ATU WDATA_PARC_ATU { get; set; } = new VE1111B_WDATA_PARC_ATU();
            public class VE1111B_WDATA_PARC_ATU : VarBasis
            {
                /*"       05 WDATA-PAR-ANO              PIC 9(04).*/
                public IntBasis WDATA_PAR_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       05 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 WDATA-PAR-MES              PIC 9(02).*/
                public IntBasis WDATA_PAR_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       05 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 WDATA-PAR-DIA              PIC 9(02).*/
                public IntBasis WDATA_PAR_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    03 WDATA-PARC-PRX.*/
            }
            public VE1111B_WDATA_PARC_PRX WDATA_PARC_PRX { get; set; } = new VE1111B_WDATA_PARC_PRX();
            public class VE1111B_WDATA_PARC_PRX : VarBasis
            {
                /*"       05 WDATA-PRX-ANO              PIC 9(04).*/
                public IntBasis WDATA_PRX_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       05 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 WDATA-PRX-MES              PIC 9(02).*/
                public IntBasis WDATA_PRX_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       05 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 WDATA-PRX-DIA              PIC 9(02).*/
                public IntBasis WDATA_PRX_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    03 WDATA-INIVIGENCIA.*/
            }
            public VE1111B_WDATA_INIVIGENCIA WDATA_INIVIGENCIA { get; set; } = new VE1111B_WDATA_INIVIGENCIA();
            public class VE1111B_WDATA_INIVIGENCIA : VarBasis
            {
                /*"       05 WDATA-INI-ANO              PIC 9(04).*/
                public IntBasis WDATA_INI_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       05 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 WDATA-INI-MES              PIC 9(02).*/
                public IntBasis WDATA_INI_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       05 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 WDATA-INI-DIA              PIC 9(02).*/
                public IntBasis WDATA_INI_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"01  WABEND.*/
            }
        }
        public VE1111B_WABEND WABEND { get; set; } = new VE1111B_WABEND();
        public class VE1111B_WABEND : VarBasis
        {
            /*"      10    FILLER                   PIC  X(016) VALUE            '*** VE1111B *** '.*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"*** VE1111B *** ");
            /*"      10    FILLER                   PIC  X(013) VALUE            'ERRO SQL *** '.*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"ERRO SQL *** ");
            /*"      10    FILLER                   PIC  X(010) VALUE            'SQLCODE = '.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"SQLCODE = ");
            /*"      10    WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10    FILLER                   PIC  X(011)   VALUE            'SQLERRD1 = '.*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"SQLERRD1 = ");
            /*"      10    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10    FILLER                   PIC  X(011)   VALUE            'SQLERRD2 = '.*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"SQLERRD2 = ");
            /*"      10    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
            /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
            public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"      10    FILLER                   PIC  X(012)   VALUE            'COMANDO   = '.*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
            /*"      10    COMANDO                  PIC  X(060)   VALUE SPACES.*/
            public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.BANCOS BANCOS { get; set; } = new Dclgens.BANCOS();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.SUBGVGAP SUBGVGAP { get; set; } = new Dclgens.SUBGVGAP();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.OPCPAGVI OPCPAGVI { get; set; } = new Dclgens.OPCPAGVI();
        public Dclgens.HISCOBPR HISCOBPR { get; set; } = new Dclgens.HISCOBPR();
        public Dclgens.NUMEROUT NUMEROUT { get; set; } = new Dclgens.NUMEROUT();
        public Dclgens.VGSOLFAT VGSOLFAT { get; set; } = new Dclgens.VGSOLFAT();
        public Dclgens.MOEDACOT MOEDACOT { get; set; } = new Dclgens.MOEDACOT();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.PARCEVID PARCEVID { get; set; } = new Dclgens.PARCEVID();
        public Dclgens.COBHISVI COBHISVI { get; set; } = new Dclgens.COBHISVI();
        public Dclgens.RCAPS RCAPS { get; set; } = new Dclgens.RCAPS();
        public Dclgens.RCAPCOMP RCAPCOMP { get; set; } = new Dclgens.RCAPCOMP();
        public Dclgens.HISLANCT HISLANCT { get; set; } = new Dclgens.HISLANCT();
        public Dclgens.HISCONPA HISCONPA { get; set; } = new Dclgens.HISCONPA();
        public Dclgens.FATURAS FATURAS { get; set; } = new Dclgens.FATURAS();
        public Dclgens.PRODUVG PRODUVG { get; set; } = new Dclgens.PRODUVG();
        public Dclgens.CONVEVG CONVEVG { get; set; } = new Dclgens.CONVEVG();
        public Dclgens.RAMOCOMP RAMOCOMP { get; set; } = new Dclgens.RAMOCOMP();
        public Dclgens.AVISOSAL AVISOSAL { get; set; } = new Dclgens.AVISOSAL();
        public Dclgens.PRODUTO PRODUTO { get; set; } = new Dclgens.PRODUTO();
        public Dclgens.VGPROSIA VGPROSIA { get; set; } = new Dclgens.VGPROSIA();
        public VE1111B_CPRODUTOS CPRODUTOS { get; set; } = new VE1111B_CPRODUTOS();
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
            /*" -237- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -239- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -241- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -245- MOVE '0000-PRINCIPAL' TO PARAGRAFO. */
            _.Move("0000-PRINCIPAL", WABEND.PARAGRAFO);

            /*" -247- PERFORM 0889-SELECT-SISTEMAS. */

            M_0889_SELECT_SISTEMAS_SECTION();

            /*" -249- PERFORM 0900-DECLA-PRODU-VG */

            M_0900_DECLA_PRODU_VG_SECTION();

            /*" -251- PERFORM 0910-FETCH-PRODU-VG */

            M_0910_FETCH_PRODU_VG_SECTION();

            /*" -252- IF WFIM-PRODUTOS NOT EQUAL SPACES */

            if (!WS_WORK_AREAS.WFIM_PRODUTOS.IsEmpty())
            {

                /*" -253- DISPLAY '*** SEM MOVIMENTO NA PRODUTOS VG   ' */
                _.Display($"*** SEM MOVIMENTO NA PRODUTOS VG   ");

                /*" -255- GO TO 0000-FIM-NORMAL. */

                M_0000_FIM_NORMAL(); //GOTO
                return;
            }


            /*" -257- ACCEPT WS-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WS_WORK_AREAS.WS_TIME);

            /*" -259- DISPLAY '** VE1111B - PROCESSANDO ...' WS-TIME. */
            _.Display($"** VE1111B - PROCESSANDO ...{WS_WORK_AREAS.WS_TIME}");

            /*" -260- PERFORM 1000-PROCESSA UNTIL WFIM-PRODUTOS EQUAL 'S' . */

            while (!(WS_WORK_AREAS.WFIM_PRODUTOS == "S"))
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
            /*" -265- MOVE 'COMMIT WORK' TO COMANDO. */
            _.Move("COMMIT WORK", WABEND.COMANDO);

            /*" -265- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -268- DISPLAY '** VE1111B ** LIDOS PRODUTOSVG  ' AC-L-PRODUVG */
            _.Display($"** VE1111B ** LIDOS PRODUTOSVG  {WS_WORK_AREAS.AC_L_PRODUVG}");

            /*" -269- DISPLAY '                                ' . */
            _.Display($"                                ");

            /*" -270- DISPLAY '** VE1111B ** ALT.  PROPOSTAVA  ' AC-A-PROPOSTAVA */
            _.Display($"** VE1111B ** ALT.  PROPOSTAVA  {WS_WORK_AREAS.AC_A_PROPOSTAVA}");

            /*" -271- DISPLAY '** VE1111B ** ALT.  PRODUTOSVG  ' AC-A-PRODUVG. */
            _.Display($"** VE1111B ** ALT.  PRODUTOSVG  {WS_WORK_AREAS.AC_A_PRODUVG}");

            /*" -272- DISPLAY '                                ' . */
            _.Display($"                                ");

            /*" -274- DISPLAY '** VE1111B ** TERMINO NORMAL    ' . */
            _.Display($"** VE1111B ** TERMINO NORMAL    ");

            /*" -276- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -276- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_FIM*/

        [StopWatch]
        /*" M-0889-SELECT-SISTEMAS-SECTION */
        private void M_0889_SELECT_SISTEMAS_SECTION()
        {
            /*" -285- MOVE '0889' TO PARAGRAFO. */
            _.Move("0889", WABEND.PARAGRAFO);

            /*" -287- MOVE 'SELECT SISTEMAS1' TO COMANDO. */
            _.Move("SELECT SISTEMAS1", WABEND.COMANDO);

            /*" -293- PERFORM M_0889_SELECT_SISTEMAS_DB_SELECT_1 */

            M_0889_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -296- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -297- DISPLAY '0889 - PROBLEMAS SELECT SISTEMAS - VE ..' */
                _.Display($"0889 - PROBLEMAS SELECT SISTEMAS - VE ..");

                /*" -298- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -300- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -301- MOVE SISTEMAS-DATA-MOV-ABERTO TO W01DTSQL. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WS_WORK_AREAS.W01DTSQL);

            /*" -303- MOVE 01 TO W01DDSQL. */
            _.Move(01, WS_WORK_AREAS.W01DTSQL_R.W01DDSQL);

            /*" -305- MOVE 'SELECT SISTEMAS2' TO COMANDO. */
            _.Move("SELECT SISTEMAS2", WABEND.COMANDO);

            /*" -311- PERFORM M_0889_SELECT_SISTEMAS_DB_SELECT_2 */

            M_0889_SELECT_SISTEMAS_DB_SELECT_2();

            /*" -314- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -315- DISPLAY '0889 - PROBLEMAS SELECT SISTEMAS - VE ..' */
                _.Display($"0889 - PROBLEMAS SELECT SISTEMAS - VE ..");

                /*" -316- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -318- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -318- DISPLAY 'PERIODO A SER APURADO ' W01DTSQL ' ' W02DTSQL. */

            $"PERIODO A SER APURADO {WS_WORK_AREAS.W01DTSQL} {WS_WORK_AREAS.W02DTSQL}"
            .Display();

        }

        [StopWatch]
        /*" M-0889-SELECT-SISTEMAS-DB-SELECT-1 */
        public void M_0889_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -293- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VE' WITH UR END-EXEC. */

            var m_0889_SELECT_SISTEMAS_DB_SELECT_1_Query1 = new M_0889_SELECT_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_0889_SELECT_SISTEMAS_DB_SELECT_1_Query1.Execute(m_0889_SELECT_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0889_FIM*/

        [StopWatch]
        /*" M-0889-SELECT-SISTEMAS-DB-SELECT-2 */
        public void M_0889_SELECT_SISTEMAS_DB_SELECT_2()
        {
            /*" -311- EXEC SQL SELECT DATE(:W01DTSQL) + 1 MONTH - 1 DAY INTO :W02DTSQL FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VE' WITH UR END-EXEC. */

            var m_0889_SELECT_SISTEMAS_DB_SELECT_2_Query1 = new M_0889_SELECT_SISTEMAS_DB_SELECT_2_Query1()
            {
                W01DTSQL = WS_WORK_AREAS.W01DTSQL.ToString(),
            };

            var executed_1 = M_0889_SELECT_SISTEMAS_DB_SELECT_2_Query1.Execute(m_0889_SELECT_SISTEMAS_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.W02DTSQL, WS_WORK_AREAS.W02DTSQL);
            }


        }

        [StopWatch]
        /*" M-0900-DECLA-PRODU-VG-SECTION */
        private void M_0900_DECLA_PRODU_VG_SECTION()
        {
            /*" -327- MOVE '0900' TO PARAGRAFO. */
            _.Move("0900", WABEND.PARAGRAFO);

            /*" -329- MOVE 'DECLA-PRODU-VG' TO COMANDO. */
            _.Move("DECLA-PRODU-VG", WABEND.COMANDO);

            /*" -331- ACCEPT WS-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WS_WORK_AREAS.WS_TIME);

            /*" -333- DISPLAY 'INICIO DECLARE CPRODUTOS.. ' WS-TIME. */
            _.Display($"INICIO DECLARE CPRODUTOS.. {WS_WORK_AREAS.WS_TIME}");

            /*" -344- PERFORM M_0900_DECLA_PRODU_VG_DB_DECLARE_1 */

            M_0900_DECLA_PRODU_VG_DB_DECLARE_1();

            /*" -346- PERFORM M_0900_DECLA_PRODU_VG_DB_OPEN_1 */

            M_0900_DECLA_PRODU_VG_DB_OPEN_1();

            /*" -349- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -350- DISPLAY '0900 - PROBLEMAS DECLARE PRODUTOS_VG       ' */
                _.Display($"0900 - PROBLEMAS DECLARE PRODUTOS_VG       ");

                /*" -351- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -353- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -355- ACCEPT WS-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WS_WORK_AREAS.WS_TIME);

            /*" -355- DISPLAY 'FINAL DECLARE CPRODUTOS.. ' WS-TIME. */
            _.Display($"FINAL DECLARE CPRODUTOS.. {WS_WORK_AREAS.WS_TIME}");

        }

        [StopWatch]
        /*" M-0900-DECLA-PRODU-VG-DB-DECLARE-1 */
        public void M_0900_DECLA_PRODU_VG_DB_DECLARE_1()
        {
            /*" -344- EXEC SQL DECLARE CPRODUTOS CURSOR WITH HOLD FOR SELECT NUM_APOLICE, COD_SUBGRUPO, COD_PRODUTO, PERI_PAGAMENTO, NOME_PRODUTO FROM SEGUROS.PRODUTOS_VG WHERE ORIG_PRODU = 'EMPRE' AND COD_SUBGRUPO > 0 FOR UPDATE OF COD_PRODUTO, NOME_PRODUTO END-EXEC. */
            CPRODUTOS = new VE1111B_CPRODUTOS(false);
            string GetQuery_CPRODUTOS()
            {
                var query = @$"SELECT NUM_APOLICE
							, 
							COD_SUBGRUPO
							, 
							COD_PRODUTO
							, 
							PERI_PAGAMENTO
							, 
							NOME_PRODUTO 
							FROM SEGUROS.PRODUTOS_VG 
							WHERE ORIG_PRODU = 'EMPRE' 
							AND COD_SUBGRUPO > 0";

                return query;
            }
            CPRODUTOS.GetQueryEvent += GetQuery_CPRODUTOS;

        }

        [StopWatch]
        /*" M-0900-DECLA-PRODU-VG-DB-OPEN-1 */
        public void M_0900_DECLA_PRODU_VG_DB_OPEN_1()
        {
            /*" -346- EXEC SQL OPEN CPRODUTOS END-EXEC. */

            CPRODUTOS.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0900_FIM*/

        [StopWatch]
        /*" M-0910-FETCH-PRODU-VG-SECTION */
        private void M_0910_FETCH_PRODU_VG_SECTION()
        {
            /*" -364- MOVE '0910' TO PARAGRAFO. */
            _.Move("0910", WABEND.PARAGRAFO);

            /*" -366- MOVE 'FETCH-VGSOLFAT' TO COMANDO. */
            _.Move("FETCH-VGSOLFAT", WABEND.COMANDO);

            /*" -373- PERFORM M_0910_FETCH_PRODU_VG_DB_FETCH_1 */

            M_0910_FETCH_PRODU_VG_DB_FETCH_1();

            /*" -376- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -377- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -378- MOVE 'S' TO WFIM-PRODUTOS */
                    _.Move("S", WS_WORK_AREAS.WFIM_PRODUTOS);

                    /*" -378- PERFORM M_0910_FETCH_PRODU_VG_DB_CLOSE_1 */

                    M_0910_FETCH_PRODU_VG_DB_CLOSE_1();

                    /*" -380- GO TO 0910-FIM */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0910_FIM*/ //GOTO
                    return;

                    /*" -381- ELSE */
                }
                else
                {


                    /*" -381- PERFORM M_0910_FETCH_PRODU_VG_DB_CLOSE_2 */

                    M_0910_FETCH_PRODU_VG_DB_CLOSE_2();

                    /*" -383- DISPLAY '0900 - (PROBLEMAS NO FETCH PRODUTOS_VG' */
                    _.Display($"0900 - (PROBLEMAS NO FETCH PRODUTOS_VG");

                    /*" -384- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -385- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -386- ELSE */
                }

            }
            else
            {


                /*" -388- ADD 1 TO AC-L-PRODUVG AC-W-CONTA */
                WS_WORK_AREAS.AC_L_PRODUVG.Value = WS_WORK_AREAS.AC_L_PRODUVG + 1;
                WS_WORK_AREAS.AC_W_CONTA.Value = WS_WORK_AREAS.AC_W_CONTA + 1;

                /*" -390- ADD 1 TO AC-L-COMMIT. */
                WS_WORK_AREAS.AC_L_COMMIT.Value = WS_WORK_AREAS.AC_L_COMMIT + 1;
            }


            /*" -391- IF AC-W-CONTA > 999 */

            if (WS_WORK_AREAS.AC_W_CONTA > 999)
            {

                /*" -392- MOVE ZEROS TO AC-W-CONTA */
                _.Move(0, WS_WORK_AREAS.AC_W_CONTA);

                /*" -393- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), WS_WORK_AREAS.WS_TIME);

                /*" -393- DISPLAY 'LIDOS PRODUTOS_VG ' AC-L-PRODUVG ' ' WS-TIME. */

                $"LIDOS PRODUTOS_VG {WS_WORK_AREAS.AC_L_PRODUVG} {WS_WORK_AREAS.WS_TIME}"
                .Display();
            }


        }

        [StopWatch]
        /*" M-0910-FETCH-PRODU-VG-DB-FETCH-1 */
        public void M_0910_FETCH_PRODU_VG_DB_FETCH_1()
        {
            /*" -373- EXEC SQL FETCH CPRODUTOS INTO :PRODUVG-NUM-APOLICE, :PRODUVG-COD-SUBGRUPO, :PRODUVG-COD-PRODUTO, :PRODUVG-PERI-PAGAMENTO, :PRODUVG-NOME-PRODUTO END-EXEC. */

            if (CPRODUTOS.Fetch())
            {
                _.Move(CPRODUTOS.PRODUVG_NUM_APOLICE, PRODUVG.DCLPRODUTOS_VG.PRODUVG_NUM_APOLICE);
                _.Move(CPRODUTOS.PRODUVG_COD_SUBGRUPO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_SUBGRUPO);
                _.Move(CPRODUTOS.PRODUVG_COD_PRODUTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO);
                _.Move(CPRODUTOS.PRODUVG_PERI_PAGAMENTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO);
                _.Move(CPRODUTOS.PRODUVG_NOME_PRODUTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_NOME_PRODUTO);
            }

        }

        [StopWatch]
        /*" M-0910-FETCH-PRODU-VG-DB-CLOSE-1 */
        public void M_0910_FETCH_PRODU_VG_DB_CLOSE_1()
        {
            /*" -378- EXEC SQL CLOSE CPRODUTOS END-EXEC */

            CPRODUTOS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0910_FIM*/

        [StopWatch]
        /*" M-0910-FETCH-PRODU-VG-DB-CLOSE-2 */
        public void M_0910_FETCH_PRODU_VG_DB_CLOSE_2()
        {
            /*" -381- EXEC SQL CLOSE CPRODUTOS END-EXEC */

            CPRODUTOS.Close();

        }

        [StopWatch]
        /*" M-1000-PROCESSA-SECTION */
        private void M_1000_PROCESSA_SECTION()
        {
            /*" -403- MOVE '1000' TO PARAGRAFO. */
            _.Move("1000", WABEND.PARAGRAFO);

            /*" -405- MOVE 'SELECT SUBGVGAP ' TO COMANDO. */
            _.Move("SELECT SUBGVGAP ", WABEND.COMANDO);

            /*" -412- PERFORM M_1000_PROCESSA_DB_SELECT_1 */

            M_1000_PROCESSA_DB_SELECT_1();

            /*" -415- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -416- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -417- GO TO 1000-NEXT */

                    M_1000_NEXT(); //GOTO
                    return;

                    /*" -418- ELSE */
                }
                else
                {


                    /*" -420- DISPLAY 'PROBLEMAS NA LEITURA DA SUBGRUPOS    ' PRODUVG-NUM-APOLICE ' ' PRODUVG-COD-SUBGRUPO */

                    $"PROBLEMAS NA LEITURA DA SUBGRUPOS    {PRODUVG.DCLPRODUTOS_VG.PRODUVG_NUM_APOLICE} {PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_SUBGRUPO}"
                    .Display();

                    /*" -422- GO TO 9999-ERRO. */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -424- MOVE 'SELECT PROPOSTA ' TO COMANDO. */
            _.Move("SELECT PROPOSTA ", WABEND.COMANDO);

            /*" -431- PERFORM M_1000_PROCESSA_DB_SELECT_2 */

            M_1000_PROCESSA_DB_SELECT_2();

            /*" -434- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -435- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -436- GO TO 1000-NEXT */

                    M_1000_NEXT(); //GOTO
                    return;

                    /*" -437- ELSE */
                }
                else
                {


                    /*" -439- DISPLAY 'PROBLEMAS NA LEITURA DA PROPOSTAS_VA ' PRODUVG-NUM-APOLICE ' ' PRODUVG-COD-SUBGRUPO */

                    $"PROBLEMAS NA LEITURA DA PROPOSTAS_VA {PRODUVG.DCLPRODUTOS_VG.PRODUVG_NUM_APOLICE} {PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_SUBGRUPO}"
                    .Display();

                    /*" -441- GO TO 9999-ERRO. */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -443- PERFORM 2000-UPDATE-PROPOSTAVA. */

            M_2000_UPDATE_PROPOSTAVA_SECTION();

            /*" -445- PERFORM 3100-SELECT-PRODUTO. */

            M_3100_SELECT_PRODUTO_SECTION();

            /*" -446- MOVE '1000' TO PARAGRAFO. */
            _.Move("1000", WABEND.PARAGRAFO);

            /*" -448- MOVE 'UPDATE CURSOR CPRODUTOS ' TO COMANDO. */
            _.Move("UPDATE CURSOR CPRODUTOS ", WABEND.COMANDO);

            /*" -455- PERFORM M_1000_PROCESSA_DB_UPDATE_1 */

            M_1000_PROCESSA_DB_UPDATE_1();

            /*" -458- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -460- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -462- MOVE 'COMMIT WORK LOOP ' TO COMANDO. */
            _.Move("COMMIT WORK LOOP ", WABEND.COMANDO);

            /*" -462- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -465- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -465- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM M_1000_NEXT */

            M_1000_NEXT();

        }

        [StopWatch]
        /*" M-1000-PROCESSA-DB-SELECT-1 */
        public void M_1000_PROCESSA_DB_SELECT_1()
        {
            /*" -412- EXEC SQL SELECT COD_CLIENTE INTO :SUBGVGAP-COD-CLIENTE FROM SEGUROS.SUBGRUPOS_VGAP WHERE NUM_APOLICE = :PRODUVG-NUM-APOLICE AND COD_SUBGRUPO = :PRODUVG-COD-SUBGRUPO WITH UR END-EXEC. */

            var m_1000_PROCESSA_DB_SELECT_1_Query1 = new M_1000_PROCESSA_DB_SELECT_1_Query1()
            {
                PRODUVG_COD_SUBGRUPO = PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_SUBGRUPO.ToString(),
                PRODUVG_NUM_APOLICE = PRODUVG.DCLPRODUTOS_VG.PRODUVG_NUM_APOLICE.ToString(),
            };

            var executed_1 = M_1000_PROCESSA_DB_SELECT_1_Query1.Execute(m_1000_PROCESSA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SUBGVGAP_COD_CLIENTE, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_CLIENTE);
            }


        }

        [StopWatch]
        /*" M-1000-NEXT */
        private void M_1000_NEXT(bool isPerform = false)
        {
            /*" -469- PERFORM 0910-FETCH-PRODU-VG. */

            M_0910_FETCH_PRODU_VG_SECTION();

        }

        [StopWatch]
        /*" M-1000-PROCESSA-DB-UPDATE-1 */
        public void M_1000_PROCESSA_DB_UPDATE_1()
        {
            /*" -455- EXEC SQL UPDATE SEGUROS.PRODUTOS_VG SET COD_PRODUTO = :PRODUVG-COD-PRODUTO, NOME_PRODUTO = :PRODUVG-NOME-PRODUTO WHERE CURRENT OF CPRODUTOS END-EXEC. */

            var m_1000_PROCESSA_DB_UPDATE_1_Update1 = new M_1000_PROCESSA_DB_UPDATE_1_Update1(CPRODUTOS)
            {
                PRODUVG_NOME_PRODUTO = PRODUVG.DCLPRODUTOS_VG.PRODUVG_NOME_PRODUTO.ToString(),
                PRODUVG_COD_PRODUTO = PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.ToString(),
            };

            M_1000_PROCESSA_DB_UPDATE_1_Update1.Execute(m_1000_PROCESSA_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-1000-PROCESSA-DB-SELECT-2 */
        public void M_1000_PROCESSA_DB_SELECT_2()
        {
            /*" -431- EXEC SQL SELECT NUM_CERTIFICADO INTO :PROPOVA-NUM-CERTIFICADO FROM SEGUROS.PROPOSTAS_VA WHERE NUM_APOLICE = :PRODUVG-NUM-APOLICE AND COD_SUBGRUPO = :PRODUVG-COD-SUBGRUPO AND COD_CLIENTE = :SUBGVGAP-COD-CLIENTE END-EXEC. */

            var m_1000_PROCESSA_DB_SELECT_2_Query1 = new M_1000_PROCESSA_DB_SELECT_2_Query1()
            {
                PRODUVG_COD_SUBGRUPO = PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_SUBGRUPO.ToString(),
                SUBGVGAP_COD_CLIENTE = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_CLIENTE.ToString(),
                PRODUVG_NUM_APOLICE = PRODUVG.DCLPRODUTOS_VG.PRODUVG_NUM_APOLICE.ToString(),
            };

            var executed_1 = M_1000_PROCESSA_DB_SELECT_2_Query1.Execute(m_1000_PROCESSA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOVA_NUM_CERTIFICADO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1000_FIM*/

        [StopWatch]
        /*" M-2000-UPDATE-PROPOSTAVA-SECTION */
        private void M_2000_UPDATE_PROPOSTAVA_SECTION()
        {
            /*" -478- MOVE '2000' TO PARAGRAFO. */
            _.Move("2000", WABEND.PARAGRAFO);

            /*" -481- MOVE 'SELECT VG_PRODUTO_SIAS ' TO COMANDO. */
            _.Move("SELECT VG_PRODUTO_SIAS ", WABEND.COMANDO);

            /*" -483- MOVE 'N' TO WS-TEM-ERRO. */
            _.Move("N", WS_WORK_AREAS.WS_TEM_ERRO);

            /*" -484- MOVE PRODUVG-NUM-APOLICE TO VGPROSIA-NUM-APOLICE. */
            _.Move(PRODUVG.DCLPRODUTOS_VG.PRODUVG_NUM_APOLICE, VGPROSIA.DCLVG_PRODUTO_SIAS.VGPROSIA_NUM_APOLICE);

            /*" -486- MOVE PRODUVG-PERI-PAGAMENTO TO VGPROSIA-NUM-PERIODO-PAG. */
            _.Move(PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO, VGPROSIA.DCLVG_PRODUTO_SIAS.VGPROSIA_NUM_PERIODO_PAG);

            /*" -494- PERFORM M_2000_UPDATE_PROPOSTAVA_DB_SELECT_1 */

            M_2000_UPDATE_PROPOSTAVA_DB_SELECT_1();

            /*" -497- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -500- DISPLAY '2000 - PROBLEMA SELECT VG_PRODUTO_SIAS ..' VGPROSIA-NUM-APOLICE ' ' VGPROSIA-NUM-PERIODO-PAG ' ' SQLCODE */

                $"2000 - PROBLEMA SELECT VG_PRODUTO_SIAS ..{VGPROSIA.DCLVG_PRODUTO_SIAS.VGPROSIA_NUM_APOLICE} {VGPROSIA.DCLVG_PRODUTO_SIAS.VGPROSIA_NUM_PERIODO_PAG} {DB.SQLCODE}"
                .Display();

                /*" -502- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -503- MOVE VGPROSIA-COD-PRODUTO TO PRODUVG-COD-PRODUTO. */
            _.Move(VGPROSIA.DCLVG_PRODUTO_SIAS.VGPROSIA_COD_PRODUTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO);

            /*" -0- FLUXCONTROL_PERFORM M_2000_UPDATE */

            M_2000_UPDATE();

        }

        [StopWatch]
        /*" M-2000-UPDATE-PROPOSTAVA-DB-SELECT-1 */
        public void M_2000_UPDATE_PROPOSTAVA_DB_SELECT_1()
        {
            /*" -494- EXEC SQL SELECT COD_PRODUTO INTO :VGPROSIA-COD-PRODUTO FROM SEGUROS.VG_PRODUTO_SIAS WHERE NUM_APOLICE = :VGPROSIA-NUM-APOLICE AND NUM_PERIODO_PAG = :VGPROSIA-NUM-PERIODO-PAG WITH UR END-EXEC. */

            var m_2000_UPDATE_PROPOSTAVA_DB_SELECT_1_Query1 = new M_2000_UPDATE_PROPOSTAVA_DB_SELECT_1_Query1()
            {
                VGPROSIA_NUM_PERIODO_PAG = VGPROSIA.DCLVG_PRODUTO_SIAS.VGPROSIA_NUM_PERIODO_PAG.ToString(),
                VGPROSIA_NUM_APOLICE = VGPROSIA.DCLVG_PRODUTO_SIAS.VGPROSIA_NUM_APOLICE.ToString(),
            };

            var executed_1 = M_2000_UPDATE_PROPOSTAVA_DB_SELECT_1_Query1.Execute(m_2000_UPDATE_PROPOSTAVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VGPROSIA_COD_PRODUTO, VGPROSIA.DCLVG_PRODUTO_SIAS.VGPROSIA_COD_PRODUTO);
            }


        }

        [StopWatch]
        /*" M-2000-UPDATE */
        private void M_2000_UPDATE(bool isPerform = false)
        {
            /*" -510- MOVE 'UPDATE PROPOSTAS_VA' TO COMANDO. */
            _.Move("UPDATE PROPOSTAS_VA", WABEND.COMANDO);

            /*" -515- PERFORM M_2000_UPDATE_DB_UPDATE_1 */

            M_2000_UPDATE_DB_UPDATE_1();

            /*" -518- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -520- DISPLAY '2000 - PROBLEMA UPDATE DA PROPOSTAS_VA ..' PROPOVA-NUM-CERTIFICADO ' ' SQLCODE */

                $"2000 - PROBLEMA UPDATE DA PROPOSTAS_VA ..{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO} {DB.SQLCODE}"
                .Display();

                /*" -522- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -522- ADD 1 TO AC-A-PROPOSTAVA. */
            WS_WORK_AREAS.AC_A_PROPOSTAVA.Value = WS_WORK_AREAS.AC_A_PROPOSTAVA + 1;

        }

        [StopWatch]
        /*" M-2000-UPDATE-DB-UPDATE-1 */
        public void M_2000_UPDATE_DB_UPDATE_1()
        {
            /*" -515- EXEC SQL UPDATE SEGUROS.PROPOSTAS_VA SET COD_PRODUTO = :PRODUVG-COD-PRODUTO WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO END-EXEC. */

            var m_2000_UPDATE_DB_UPDATE_1_Update1 = new M_2000_UPDATE_DB_UPDATE_1_Update1()
            {
                PRODUVG_COD_PRODUTO = PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            M_2000_UPDATE_DB_UPDATE_1_Update1.Execute(m_2000_UPDATE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2000_FIM*/

        [StopWatch]
        /*" M-3100-SELECT-PRODUTO-SECTION */
        private void M_3100_SELECT_PRODUTO_SECTION()
        {
            /*" -533- MOVE '3100' TO PARAGRAFO. */
            _.Move("3100", WABEND.PARAGRAFO);

            /*" -535- MOVE 'SELECT  PRODUTO         ' TO COMANDO. */
            _.Move("SELECT  PRODUTO         ", WABEND.COMANDO);

            /*" -543- PERFORM M_3100_SELECT_PRODUTO_DB_SELECT_1 */

            M_3100_SELECT_PRODUTO_DB_SELECT_1();

            /*" -546- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -550- DISPLAY 'PROBLEMAS NA LEITURA DA PRODUTO ' PRODUVG-NUM-APOLICE ' ' PRODUVG-COD-SUBGRUPO ' ' PRODUVG-COD-PRODUTO */

                $"PROBLEMAS NA LEITURA DA PRODUTO {PRODUVG.DCLPRODUTOS_VG.PRODUVG_NUM_APOLICE} {PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_SUBGRUPO} {PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO}"
                .Display();

                /*" -553- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -556- MOVE PRODUTO-DESCR-PRODUTO TO PRODUVG-NOME-PRODUTO */
            _.Move(PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_NOME_PRODUTO);

            /*" -556- ADD 1 TO AC-A-PRODUVG. */
            WS_WORK_AREAS.AC_A_PRODUVG.Value = WS_WORK_AREAS.AC_A_PRODUVG + 1;

        }

        [StopWatch]
        /*" M-3100-SELECT-PRODUTO-DB-SELECT-1 */
        public void M_3100_SELECT_PRODUTO_DB_SELECT_1()
        {
            /*" -543- EXEC SQL SELECT DESCR_PRODUTO INTO :PRODUTO-DESCR-PRODUTO FROM SEGUROS.PRODUTO WHERE COD_PRODUTO = :PRODUVG-COD-PRODUTO WITH UR END-EXEC. */

            var m_3100_SELECT_PRODUTO_DB_SELECT_1_Query1 = new M_3100_SELECT_PRODUTO_DB_SELECT_1_Query1()
            {
                PRODUVG_COD_PRODUTO = PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.ToString(),
            };

            var executed_1 = M_3100_SELECT_PRODUTO_DB_SELECT_1_Query1.Execute(m_3100_SELECT_PRODUTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUTO_DESCR_PRODUTO, PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3100_FIM*/

        [StopWatch]
        /*" M-9999-ERRO-SECTION */
        private void M_9999_ERRO_SECTION()
        {
            /*" -568- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -569- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], WABEND.WSQLERRD1);

            /*" -570- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], WABEND.WSQLERRD2);

            /*" -571- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -575- DISPLAY PRODUVG-COD-PRODUTO ' ' PRODUVG-NUM-APOLICE ' ' PRODUVG-COD-SUBGRUPO. */

            $"{PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO} {PRODUVG.DCLPRODUTOS_VG.PRODUVG_NUM_APOLICE} {PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_SUBGRUPO}"
            .Display();

            /*" -577- DISPLAY '*** VE1111B *** ROLLBACK EM ANDAMENTO ...' . */
            _.Display($"*** VE1111B *** ROLLBACK EM ANDAMENTO ...");

            /*" -577- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -580- MOVE '9999' TO PARAGRAFO. */
            _.Move("9999", WABEND.PARAGRAFO);

            /*" -581- MOVE 'ROLLBACK WORK' TO COMANDO. */
            _.Move("ROLLBACK WORK", WABEND.COMANDO);

            /*" -581- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -585- DISPLAY '*** VE1111B *** ERRO DE EXECUCAO' . */
            _.Display($"*** VE1111B *** ERRO DE EXECUCAO");

            /*" -586- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -586- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}