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
using Sias.VidaEmGrupo.DB2.VP5705B;

namespace Code
{
    public class VP5705B
    {
        public bool IsCall { get; set; }

        public VP5705B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *   CALCULA E GERA COMISSOES DE AGENCIAMENTO PARA A APOLICE      *      */
        /*"      *                  EXCLUSIVO                                     *      */
        /*"      *   GRAVA A TABELA COMISSOES_VP QUE SERVIRA DE ENTRADA PARA O    *      */
        /*"      *                  PROGRAMA VP5706B.                             *      */
        /*"      ******************************************************************      */
        /*"      *                                 FREDERICO J FONSECA 23.11.01   *      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO 01 -  ADAILTON DIAS                                   *      */
        /*"      *               - PREPARAR PROGRAMA PARA PROCESSAMENTO DA JV1    *      */
        /*"      *   EM 06/02/2019 - ATOS BR                                      *      */
        /*"      *                                       PROCURE POR JV1          *      */
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  V1CLIE-DTNASCIM              PIC  X(010).*/
        public StringBasis V1CLIE_DTNASCIM { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  V1CLIE-DTNASCIM-I            PIC S9(004)     COMP.*/
        public IntBasis V1CLIE_DTNASCIM_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  V1SEGV-CODCLI                PIC S9(009)     COMP.*/
        public IntBasis V1SEGV_CODCLI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  V1SEGV-DTNASCIM              PIC  X(010).*/
        public StringBasis V1SEGV_DTNASCIM { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  V1SEGV-DTNASCIM-I            PIC S9(004)     COMP.*/
        public IntBasis V1SEGV_DTNASCIM_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  HOST-IDADE                   PIC S9(004)     COMP VALUE  0.*/
        public IntBasis HOST_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  SQL-NOT-NULL                 PIC S9(004)     COMP VALUE +1.*/
        public IntBasis SQL_NOT_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +1);
        /*"01  SQL-DTMOVABE                 PIC  X(010).*/
        public StringBasis SQL_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  SQL-PERC-COMIS               PIC S9(003)V99  COMP-3.*/
        public DoubleBasis SQL_PERC_COMIS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"01  SQL-NRPARCEL                 PIC S9(004)     COMP.*/
        public IntBasis SQL_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  SQL-NUM-APOL                 PIC S9(013)     COMP-3.*/
        public IntBasis SQL_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01  SQL-COD-SUB                  PIC S9(004)     COMP.*/
        public IntBasis SQL_COD_SUB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  SQL-COD-FONTE                PIC S9(004)     COMP.*/
        public IntBasis SQL_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  SQL-PROPOSTA                 PIC S9(009)     COMP.*/
        public IntBasis SQL_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  SQL-TIPO-SEG                 PIC  X(001).*/
        public StringBasis SQL_TIPO_SEG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  SQL-NUM-CERT                 PIC S9(015)     COMP-3.*/
        public IntBasis SQL_NUM_CERT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01  SQL-DAC-CERT                 PIC  X(001).*/
        public StringBasis SQL_DAC_CERT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  SQL-COD-CLIE                 PIC S9(009)     COMP.*/
        public IntBasis SQL_COD_CLIE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  SQL-COD-AGEN                 PIC S9(009)     COMP.*/
        public IntBasis SQL_COD_AGEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  SQL-PRM-VG-CO                PIC S9(013)V99  COMP-3.*/
        public DoubleBasis SQL_PRM_VG_CO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  SQL-PRM-AP-CO                PIC S9(013)V99  COMP-3.*/
        public DoubleBasis SQL_PRM_AP_CO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  SQL-PRM-VG                   PIC S9(013)V99  COMP-3.*/
        public DoubleBasis SQL_PRM_VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  SQL-PRM-AP                   PIC S9(013)V99  COMP-3.*/
        public DoubleBasis SQL_PRM_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  SQL-PRM-VG-ATU               PIC S9(013)V99  COMP-3.*/
        public DoubleBasis SQL_PRM_VG_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  SQL-PRM-AP-ATU               PIC S9(013)V99  COMP-3.*/
        public DoubleBasis SQL_PRM_AP_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  SQL-VLCUSTCDG                PIC S9(013)V99  COMP-3.*/
        public DoubleBasis SQL_VLCUSTCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  SQL-VLCUSTCAP                PIC S9(013)V99  COMP-3.*/
        public DoubleBasis SQL_VLCUSTCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  SQL-VLCUSTAUXF               PIC S9(013)V99  COMP-3.*/
        public DoubleBasis SQL_VLCUSTAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  SQL-VLCUSTADI-ATU            PIC S9(013)V99  COMP-3.*/
        public DoubleBasis SQL_VLCUSTADI_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  SQL-VLCUSTADI-ANT            PIC S9(013)V99  COMP-3.*/
        public DoubleBasis SQL_VLCUSTADI_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  SQL-COD-OPERAC               PIC S9(004)     COMP.*/
        public IntBasis SQL_COD_OPERAC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  SQL-CODOPER-PLANOS           PIC S9(004)     COMP.*/
        public IntBasis SQL_CODOPER_PLANOS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  SQL-TIPO-COMISSAO            PIC  X(001).*/
        public StringBasis SQL_TIPO_COMISSAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  SQL-FAIXA                    PIC S9(004)     COMP.*/
        public IntBasis SQL_FAIXA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  SQL-DATSEL                   PIC  X(010).*/
        public StringBasis SQL_DATSEL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  SQL-DTMOVTO                  PIC  X(010).*/
        public StringBasis SQL_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  SQL-PCT-AGENC                PIC S9(003)V99  COMP-3.*/
        public DoubleBasis SQL_PCT_AGENC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"01  SQL-PCT-PLAN-AGENC           PIC S9(003)V99  COMP-3.*/
        public DoubleBasis SQL_PCT_PLAN_AGENC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"01  SQL-VLCOMIS                  PIC S9(013)V99  COMP-3.*/
        public DoubleBasis SQL_VLCOMIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  SQL-VALBAS                   PIC S9(013)V99  COMP-3.*/
        public DoubleBasis SQL_VALBAS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  SQL-RAMOFR                   PIC S9(004)     COMP.*/
        public IntBasis SQL_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  SQL-PCCOMCOR                 PIC S9(003)V99  COMP-3.*/
        public DoubleBasis SQL_PCCOMCOR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"01  SQL-HORAOPER                 PIC  X(008).*/
        public StringBasis SQL_HORAOPER { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"01  SQL-NUMBIL                   PIC S9(015)     COMP-3.*/
        public IntBasis SQL_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01  SQL-NUMBILI                  PIC S9(004)     COMP.*/
        public IntBasis SQL_NUMBILI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  SQL-OCORHIST                 PIC S9(004)     COMP.*/
        public IntBasis SQL_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01           WORK-AREA.*/
        public VP5705B_WORK_AREA WORK_AREA { get; set; } = new VP5705B_WORK_AREA();
        public class VP5705B_WORK_AREA : VarBasis
        {
            /*"    03 WS-DATA-BASE.*/
            public VP5705B_WS_DATA_BASE WS_DATA_BASE { get; set; } = new VP5705B_WS_DATA_BASE();
            public class VP5705B_WS_DATA_BASE : VarBasis
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
                /*"    03 WDATA-NASC.*/
            }
            public VP5705B_WDATA_NASC WDATA_NASC { get; set; } = new VP5705B_WDATA_NASC();
            public class VP5705B_WDATA_NASC : VarBasis
            {
                /*"       05 ANO-NASC                   PIC 9(04).*/
                public IntBasis ANO_NASC { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       05 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 MES-NASC                   PIC 9(02).*/
                public IntBasis MES_NASC { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       05 FILLER                     PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 DIA-NASC                   PIC 9(02).*/
                public IntBasis DIA_NASC { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"01           AREA-DE-WORK.*/
            }
        }
        public VP5705B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VP5705B_AREA_DE_WORK();
        public class VP5705B_AREA_DE_WORK : VarBasis
        {
            /*"    05 WS-APOL-ANT             PIC S9(013)     COMP-3.*/
            public IntBasis WS_APOL_ANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"    05 WS-SUBGR-ANT            PIC S9(004)     COMP.*/
            public IntBasis WS_SUBGR_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05       WSL-SQLCODE       PIC  9(009)    VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05       WFIM-V0MOVIMENTO  PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V0MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05       WFIM-PLANOS       PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_PLANOS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05       AC-L-V0MOVIMENTO  PIC  9(005)    VALUE ZEROS.*/
            public IntBasis AC_L_V0MOVIMENTO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    05       AC-I-V0COMISSAO   PIC  9(005)    VALUE ZEROS.*/
            public IntBasis AC_I_V0COMISSAO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    05       AC-I-COMISVP      PIC  9(005)    VALUE ZEROS.*/
            public IntBasis AC_I_COMISVP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    05       WDATA-REL         PIC  X(010)    VALUE SPACES.*/
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    05       FILLER            REDEFINES      WDATA-REL.*/
            private _REDEF_VP5705B_FILLER_4 _filler_4 { get; set; }
            public _REDEF_VP5705B_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_VP5705B_FILLER_4(); _.Move(WDATA_REL, _filler_4); VarBasis.RedefinePassValue(WDATA_REL, _filler_4, WDATA_REL); _filler_4.ValueChanged += () => { _.Move(_filler_4, WDATA_REL); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, WDATA_REL); }
            }  //Redefines
            public class _REDEF_VP5705B_FILLER_4 : VarBasis
            {
                /*"      10     WDAT-REL-ANO      PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10     FILLER            PIC  X(001).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10     WDAT-REL-MES      PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     FILLER            PIC  X(001).*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10     WDAT-REL-DIA      PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05       WDAT-REL-LIT.*/

                public _REDEF_VP5705B_FILLER_4()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_5.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_6.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public VP5705B_WDAT_REL_LIT WDAT_REL_LIT { get; set; } = new VP5705B_WDAT_REL_LIT();
            public class VP5705B_WDAT_REL_LIT : VarBasis
            {
                /*"      10     WDAT-LIT-DIA      PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDAT_LIT_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"      10     FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10     WDAT-LIT-MES      PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDAT_LIT_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"      10     FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10     WDAT-LIT-ANO      PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDAT_LIT_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    05       W01DTSQL.*/
            }
            public VP5705B_W01DTSQL W01DTSQL { get; set; } = new VP5705B_W01DTSQL();
            public class VP5705B_W01DTSQL : VarBasis
            {
                /*"      10     W01AASQL          PIC  9(004).*/
                public IntBasis W01AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10     W01T1SQL          PIC  X(001).*/
                public StringBasis W01T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10     W01MMSQL          PIC  9(002).*/
                public IntBasis W01MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     W01T2SQL          PIC  X(001).*/
                public StringBasis W01T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10     W01DDSQL          PIC  9(002).*/
                public IntBasis W01DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05       WTIME-DAY.*/
            }
            public VP5705B_WTIME_DAY WTIME_DAY { get; set; } = new VP5705B_WTIME_DAY();
            public class VP5705B_WTIME_DAY : VarBasis
            {
                /*"      10     WHH               PIC  9(002).*/
                public IntBasis WHH { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WMM               PIC  9(002).*/
                public IntBasis WMM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WSS               PIC  9(002).*/
                public IntBasis WSS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WCC               PIC  9(002).*/
                public IntBasis WCC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05       WHORA.*/
            }
            public VP5705B_WHORA WHORA { get; set; } = new VP5705B_WHORA();
            public class VP5705B_WHORA : VarBasis
            {
                /*"      10     WHH               PIC  9(002).*/
                public IntBasis WHH_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     FILLER            PIC  X(001) VALUE '.'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"      10     WMM               PIC  9(002).*/
                public IntBasis WMM_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     FILLER            PIC  X(001) VALUE '.'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"      10     WSS               PIC  9(002).*/
                public IntBasis WSS_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05      WABEND.*/
            }
            public VP5705B_WABEND WABEND { get; set; } = new VP5705B_WABEND();
            public class VP5705B_WABEND : VarBasis
            {
                /*"      10    FILLER              PIC  X(010) VALUE           ' VP5705B'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VP5705B");
                /*"      10    FILLER              PIC  X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"      10    WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"      10    FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"      10    WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            }
        }


        public VP5705B_V0MOVIMENTO V0MOVIMENTO { get; set; } = new VP5705B_V0MOVIMENTO();
        public VP5705B_PLANOS PLANOS { get; set; } = new VP5705B_PLANOS();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -0- FLUXCONTROL_PERFORM M-0000-INICIO */

                M_0000_INICIO();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            return Result;
        }

        [StopWatch]
        /*" M-0000-INICIO */
        private void M_0000_INICIO(bool isPerform = false)
        {
            /*" -173- MOVE '001' TO WNR-EXEC-SQL. */
            _.Move("001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -174- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -177- EXEC SQL WHENEVER SQLERROR GO TO 9999-ERRO END-EXEC. */

            /*" -180- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -188- MOVE '005' TO WNR-EXEC-SQL. */
            _.Move("005", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -193- PERFORM M_0000_INICIO_DB_SELECT_1 */

            M_0000_INICIO_DB_SELECT_1();

            /*" -196- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -197- DISPLAY '*** VP5705B *** SISTEMA VP NAO CADASTRADO' */
                _.Display($"*** VP5705B *** SISTEMA VP NAO CADASTRADO");

                /*" -203- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -205- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -233- PERFORM M_0000_INICIO_DB_DECLARE_1 */

            M_0000_INICIO_DB_DECLARE_1();

            /*" -237- MOVE '011' TO WNR-EXEC-SQL. */
            _.Move("011", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -238- DISPLAY '*** VP5705B *** ABRINDO CURSOR ...' . */
            _.Display($"*** VP5705B *** ABRINDO CURSOR ...");

            /*" -238- PERFORM M_0000_INICIO_DB_OPEN_1 */

            M_0000_INICIO_DB_OPEN_1();

            /*" -246- PERFORM 1100-FETCH THRU 1100-FIM. */

            M_1100_FETCH(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1100_FIM*/


            /*" -247- IF WFIM-V0MOVIMENTO EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_V0MOVIMENTO == "S")
            {

                /*" -248- PERFORM 9000-ENCERRA-SEM-MOVTO THRU 9000-FIM */

                M_9000_ENCERRA_SEM_MOVTO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9000_FIM*/


                /*" -250- GO TO 0002-FINALIZA. */

                M_0002_FINALIZA(); //GOTO
                return;
            }


            /*" -251- DISPLAY '*** VP5705B *** PROCESSANDO ...' . */
            _.Display($"*** VP5705B *** PROCESSANDO ...");

            /*" -254- PERFORM M-1000-PROCESSA-MOVIMENTO THRU 1000-FIM UNTIL WFIM-V0MOVIMENTO EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_V0MOVIMENTO == "S"))
            {

                M_1000_PROCESSA_MOVIMENTO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1000_FIM*/

            }

            /*" -256- MOVE '017' TO WNR-EXEC-SQL. */
            _.Move("017", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -268- PERFORM M_0000_INICIO_DB_UPDATE_1 */

            M_0000_INICIO_DB_UPDATE_1();

            /*" -271- DISPLAY '*** VP5705B *** MOV LIDOS       ' AC-L-V0MOVIMENTO. */
            _.Display($"*** VP5705B *** MOV LIDOS       {AREA_DE_WORK.AC_L_V0MOVIMENTO}");

            /*" -271- DISPLAY '*** VP5705B *** INS. COMIS_VP   ' AC-I-COMISVP. */
            _.Display($"*** VP5705B *** INS. COMIS_VP   {AREA_DE_WORK.AC_I_COMISVP}");

        }

        [StopWatch]
        /*" M-0000-INICIO-DB-SELECT-1 */
        public void M_0000_INICIO_DB_SELECT_1()
        {
            /*" -193- EXEC SQL SELECT DTMOVABE INTO :SQL-DTMOVABE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VP' END-EXEC. */

            var m_0000_INICIO_DB_SELECT_1_Query1 = new M_0000_INICIO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_0000_INICIO_DB_SELECT_1_Query1.Execute(m_0000_INICIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SQL_DTMOVABE, SQL_DTMOVABE);
            }


        }

        [StopWatch]
        /*" M-0000-INICIO-DB-DECLARE-1 */
        public void M_0000_INICIO_DB_DECLARE_1()
        {
            /*" -233- EXEC SQL DECLARE V0MOVIMENTO CURSOR FOR SELECT NUM_APOLICE, COD_SUBGRUPO, COD_FONTE, NUM_PROPOSTA, TIPO_SEGURADO, NUM_CERTIFICADO, DAC_CERTIFICADO, COD_CLIENTE, COD_AGENCIADOR, PRM_VG_ATU - PRM_VG_ANT, PRM_AP_ATU - PRM_AP_ANT, PRM_VG_ATU, PRM_AP_ATU, COD_OPERACAO, FAIXA, DATA_MOVIMENTO FROM SEGUROS.V0MOVIMENTO WHERE DATA_INCLUSAO = :SQL-DTMOVABE AND SIT_REGISTRO IN ( '0' , '1' ) AND NUM_APOLICE IN (109300000559, 3009300000559) AND COD_AGENCIADOR NOT IN (0,999105) AND ((COD_OPERACAO >= 0100 AND COD_OPERACAO <= 0199) OR (COD_OPERACAO >= 0800 AND COD_OPERACAO <= 0809)) ORDER BY 1,2 END-EXEC. */
            V0MOVIMENTO = new VP5705B_V0MOVIMENTO(true);
            string GetQuery_V0MOVIMENTO()
            {
                var query = @$"SELECT NUM_APOLICE
							, 
							COD_SUBGRUPO
							, 
							COD_FONTE
							, 
							NUM_PROPOSTA
							, 
							TIPO_SEGURADO
							, 
							NUM_CERTIFICADO
							, 
							DAC_CERTIFICADO
							, 
							COD_CLIENTE
							, 
							COD_AGENCIADOR
							, 
							PRM_VG_ATU - PRM_VG_ANT
							, 
							PRM_AP_ATU - PRM_AP_ANT
							, 
							PRM_VG_ATU
							, 
							PRM_AP_ATU
							, 
							COD_OPERACAO
							, 
							FAIXA
							, 
							DATA_MOVIMENTO 
							FROM SEGUROS.V0MOVIMENTO 
							WHERE DATA_INCLUSAO = '{SQL_DTMOVABE}' 
							AND SIT_REGISTRO IN ( '0'
							, '1' ) 
							AND NUM_APOLICE IN (109300000559
							, 3009300000559) 
							AND COD_AGENCIADOR NOT IN (0
							,999105) 
							AND ((COD_OPERACAO >= 0100 AND 
							COD_OPERACAO <= 0199) OR 
							(COD_OPERACAO >= 0800 AND 
							COD_OPERACAO <= 0809)) 
							ORDER BY 1
							,2";

                return query;
            }
            V0MOVIMENTO.GetQueryEvent += GetQuery_V0MOVIMENTO;

        }

        [StopWatch]
        /*" M-0000-INICIO-DB-OPEN-1 */
        public void M_0000_INICIO_DB_OPEN_1()
        {
            /*" -238- EXEC SQL OPEN V0MOVIMENTO END-EXEC. */

            V0MOVIMENTO.Open();

        }

        [StopWatch]
        /*" M-1500-NOVAS-COMISSOES-DB-DECLARE-1 */
        public void M_1500_NOVAS_COMISSOES_DB_DECLARE_1()
        {
            /*" -434- EXEC SQL DECLARE PLANOS CURSOR FOR SELECT NUM_PARCELA, PERC_COMISSAO FROM SEGUROS.PLANOS_COMISSAO_VP WHERE NUM_APOLICE = :SQL-NUM-APOL AND COD_SUBGRUPO = :SQL-COD-SUB AND COD_PRODUTOR = 471208 AND COD_OPERACAO = :SQL-CODOPER-PLANOS AND IDADE_INICIAL <= :HOST-IDADE AND IDADE_FINAL >= :HOST-IDADE AND DATA_INIVIGENCIA <= :SQL-DTMOVTO AND DATA_TERVIGENCIA >= :SQL-DTMOVTO AND TIPO_COMISSAO = '1' ORDER BY 1 END-EXEC. */
            PLANOS = new VP5705B_PLANOS(true);
            string GetQuery_PLANOS()
            {
                var query = @$"SELECT NUM_PARCELA
							, 
							PERC_COMISSAO 
							FROM SEGUROS.PLANOS_COMISSAO_VP 
							WHERE NUM_APOLICE = '{SQL_NUM_APOL}' 
							AND COD_SUBGRUPO = '{SQL_COD_SUB}' 
							AND COD_PRODUTOR = 471208 
							AND COD_OPERACAO = '{SQL_CODOPER_PLANOS}' 
							AND IDADE_INICIAL <= '{HOST_IDADE}' 
							AND IDADE_FINAL >= '{HOST_IDADE}' 
							AND DATA_INIVIGENCIA <= '{SQL_DTMOVTO}' 
							AND DATA_TERVIGENCIA >= '{SQL_DTMOVTO}' 
							AND TIPO_COMISSAO = '1' 
							ORDER BY 1";

                return query;
            }
            PLANOS.GetQueryEvent += GetQuery_PLANOS;

        }

        [StopWatch]
        /*" M-0000-INICIO-DB-UPDATE-1 */
        public void M_0000_INICIO_DB_UPDATE_1()
        {
            /*" -268- EXEC SQL UPDATE SEGUROS.V0MOVIMENTO SET SIT_REGISTRO = '3' WHERE DATA_INCLUSAO = :SQL-DTMOVABE AND SIT_REGISTRO IN ( '0' , '1' ) AND NUM_APOLICE IN (109300000559, 3009300000559) AND COD_AGENCIADOR NOT IN (0,999105) AND ((COD_OPERACAO >= 0100 AND COD_OPERACAO <= 0199) OR (COD_OPERACAO >= 0800 AND COD_OPERACAO <= 0809)) END-EXEC. */

            var m_0000_INICIO_DB_UPDATE_1_Update1 = new M_0000_INICIO_DB_UPDATE_1_Update1()
            {
                SQL_DTMOVABE = SQL_DTMOVABE.ToString(),
            };

            M_0000_INICIO_DB_UPDATE_1_Update1.Execute(m_0000_INICIO_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-0002-FINALIZA */
        private void M_0002_FINALIZA(bool isPerform = false)
        {
            /*" -277- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -277- PERFORM M_0002_FINALIZA_DB_CLOSE_1 */

            M_0002_FINALIZA_DB_CLOSE_1();

            /*" -281- MOVE '091' TO WNR-EXEC-SQL. */
            _.Move("091", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -281- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -285- DISPLAY '*** VP5705B *** TERMINO NORMAL' . */
            _.Display($"*** VP5705B *** TERMINO NORMAL");

            /*" -287- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -287- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-0002-FINALIZA-DB-CLOSE-1 */
        public void M_0002_FINALIZA_DB_CLOSE_1()
        {
            /*" -277- EXEC SQL CLOSE V0MOVIMENTO END-EXEC. */

            V0MOVIMENTO.Close();

        }

        [StopWatch]
        /*" M-1000-PROCESSA-MOVIMENTO */
        private void M_1000_PROCESSA_MOVIMENTO(bool isPerform = false)
        {
            /*" -294- PERFORM 1300-PROC-COMIS-SUBGR THRU 1300-FIM UNTIL WFIM-V0MOVIMENTO EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_V0MOVIMENTO == "S"))
            {

                M_1300_PROC_COMIS_SUBGR(true);

                M_1300_NEXT(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1300_FIM*/

            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1000_FIM*/

        [StopWatch]
        /*" M-1100-FETCH */
        private void M_1100_FETCH(bool isPerform = false)
        {
            /*" -304- MOVE '110' TO WNR-EXEC-SQL. */
            _.Move("110", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -322- PERFORM M_1100_FETCH_DB_FETCH_1 */

            M_1100_FETCH_DB_FETCH_1();

            /*" -325- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -326- MOVE 'S' TO WFIM-V0MOVIMENTO */
                _.Move("S", AREA_DE_WORK.WFIM_V0MOVIMENTO);

                /*" -327- ELSE */
            }
            else
            {


                /*" -327- ADD 1 TO AC-L-V0MOVIMENTO. */
                AREA_DE_WORK.AC_L_V0MOVIMENTO.Value = AREA_DE_WORK.AC_L_V0MOVIMENTO + 1;
            }


        }

        [StopWatch]
        /*" M-1100-FETCH-DB-FETCH-1 */
        public void M_1100_FETCH_DB_FETCH_1()
        {
            /*" -322- EXEC SQL FETCH V0MOVIMENTO INTO :SQL-NUM-APOL, :SQL-COD-SUB, :SQL-COD-FONTE, :SQL-PROPOSTA, :SQL-TIPO-SEG, :SQL-NUM-CERT, :SQL-DAC-CERT, :SQL-COD-CLIE, :SQL-COD-AGEN, :SQL-PRM-VG, :SQL-PRM-AP, :SQL-PRM-VG-ATU, :SQL-PRM-AP-ATU, :SQL-COD-OPERAC, :SQL-FAIXA, :SQL-DTMOVTO END-EXEC. */

            if (V0MOVIMENTO.Fetch())
            {
                _.Move(V0MOVIMENTO.SQL_NUM_APOL, SQL_NUM_APOL);
                _.Move(V0MOVIMENTO.SQL_COD_SUB, SQL_COD_SUB);
                _.Move(V0MOVIMENTO.SQL_COD_FONTE, SQL_COD_FONTE);
                _.Move(V0MOVIMENTO.SQL_PROPOSTA, SQL_PROPOSTA);
                _.Move(V0MOVIMENTO.SQL_TIPO_SEG, SQL_TIPO_SEG);
                _.Move(V0MOVIMENTO.SQL_NUM_CERT, SQL_NUM_CERT);
                _.Move(V0MOVIMENTO.SQL_DAC_CERT, SQL_DAC_CERT);
                _.Move(V0MOVIMENTO.SQL_COD_CLIE, SQL_COD_CLIE);
                _.Move(V0MOVIMENTO.SQL_COD_AGEN, SQL_COD_AGEN);
                _.Move(V0MOVIMENTO.SQL_PRM_VG, SQL_PRM_VG);
                _.Move(V0MOVIMENTO.SQL_PRM_AP, SQL_PRM_AP);
                _.Move(V0MOVIMENTO.SQL_PRM_VG_ATU, SQL_PRM_VG_ATU);
                _.Move(V0MOVIMENTO.SQL_PRM_AP_ATU, SQL_PRM_AP_ATU);
                _.Move(V0MOVIMENTO.SQL_COD_OPERAC, SQL_COD_OPERAC);
                _.Move(V0MOVIMENTO.SQL_FAIXA, SQL_FAIXA);
                _.Move(V0MOVIMENTO.SQL_DTMOVTO, SQL_DTMOVTO);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1100_FIM*/

        [StopWatch]
        /*" M-1300-PROC-COMIS-SUBGR */
        private void M_1300_PROC_COMIS_SUBGR(bool isPerform = false)
        {
            /*" -335- PERFORM 1500-NOVAS-COMISSOES THRU 1500-FIM. */

            M_1500_NOVAS_COMISSOES(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1500_FIM*/


        }

        [StopWatch]
        /*" M-1300-NEXT */
        private void M_1300_NEXT(bool isPerform = false)
        {
            /*" -339- PERFORM 1100-FETCH THRU 1100-FIM. */

            M_1100_FETCH(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1100_FIM*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1300_FIM*/

        [StopWatch]
        /*" M-1500-NOVAS-COMISSOES */
        private void M_1500_NOVAS_COMISSOES(bool isPerform = false)
        {
            /*" -349- MOVE '150' TO WNR-EXEC-SQL. */
            _.Move("150", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -359- PERFORM M_1500_NOVAS_COMISSOES_DB_SELECT_1 */

            M_1500_NOVAS_COMISSOES_DB_SELECT_1();

            /*" -362- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -364- DISPLAY '1500 - PROBLEMAS SELECT V0SEGURAVG  ..' ' CERT ' SQL-NUM-CERT */

                $"1500 - PROBLEMAS SELECT V0SEGURAVG  .. CERT {SQL_NUM_CERT}"
                .Display();

                /*" -366- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -368- MOVE '151' TO WNR-EXEC-SQL. */
            _.Move("151", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -373- PERFORM M_1500_NOVAS_COMISSOES_DB_SELECT_2 */

            M_1500_NOVAS_COMISSOES_DB_SELECT_2();

            /*" -376- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -377- DISPLAY ' CLIENTE INVALIDO  ' SQL-NUM-CERT ' ' SQLCODE */

                $" CLIENTE INVALIDO  {SQL_NUM_CERT} {DB.SQLCODE}"
                .Display();

                /*" -380- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -381- IF V1SEGV-DTNASCIM-I = 0 */

            if (V1SEGV_DTNASCIM_I == 0)
            {

                /*" -382- IF V1CLIE-DTNASCIM-I = 0 */

                if (V1CLIE_DTNASCIM_I == 0)
                {

                    /*" -383- IF V1SEGV-DTNASCIM = V1CLIE-DTNASCIM */

                    if (V1SEGV_DTNASCIM == V1CLIE_DTNASCIM)
                    {

                        /*" -384- MOVE V1SEGV-DTNASCIM TO WDATA-NASC */
                        _.Move(V1SEGV_DTNASCIM, WORK_AREA.WDATA_NASC);

                        /*" -385- ELSE */
                    }
                    else
                    {


                        /*" -386- MOVE V1CLIE-DTNASCIM TO WDATA-NASC */
                        _.Move(V1CLIE_DTNASCIM, WORK_AREA.WDATA_NASC);

                        /*" -387- ELSE */
                    }

                }
                else
                {


                    /*" -388- MOVE V1SEGV-DTNASCIM TO WDATA-NASC */
                    _.Move(V1SEGV_DTNASCIM, WORK_AREA.WDATA_NASC);

                    /*" -389- MOVE V1SEGV-DTNASCIM TO V1CLIE-DTNASCIM */
                    _.Move(V1SEGV_DTNASCIM, V1CLIE_DTNASCIM);

                    /*" -390- ELSE */
                }

            }
            else
            {


                /*" -391- IF V1CLIE-DTNASCIM-I = 0 */

                if (V1CLIE_DTNASCIM_I == 0)
                {

                    /*" -392- MOVE V1CLIE-DTNASCIM TO WDATA-NASC */
                    _.Move(V1CLIE_DTNASCIM, WORK_AREA.WDATA_NASC);

                    /*" -393- ELSE */
                }
                else
                {


                    /*" -395- DISPLAY 'DATA DE NASCIMENTO NULA ' SQL-NUM-CERT */
                    _.Display($"DATA DE NASCIMENTO NULA {SQL_NUM_CERT}");

                    /*" -399- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -401- MOVE SQL-DTMOVTO TO WS-DATA-BASE. */
            _.Move(SQL_DTMOVTO, WORK_AREA.WS_DATA_BASE);

            /*" -403- COMPUTE HOST-IDADE = WS-ANO-BASE - ANO-NASC. */
            HOST_IDADE.Value = WORK_AREA.WS_DATA_BASE.WS_ANO_BASE - WORK_AREA.WDATA_NASC.ANO_NASC;

            /*" -404- IF MES-NASC GREATER WS-MES-BASE */

            if (WORK_AREA.WDATA_NASC.MES_NASC > WORK_AREA.WS_DATA_BASE.WS_MES_BASE)
            {

                /*" -405- SUBTRACT 1 FROM HOST-IDADE */
                HOST_IDADE.Value = HOST_IDADE - 1;

                /*" -406- ELSE */
            }
            else
            {


                /*" -407- IF MES-NASC EQUAL WS-MES-BASE */

                if (WORK_AREA.WDATA_NASC.MES_NASC == WORK_AREA.WS_DATA_BASE.WS_MES_BASE)
                {

                    /*" -408- IF DIA-NASC GREATER WS-DIA-BASE */

                    if (WORK_AREA.WDATA_NASC.DIA_NASC > WORK_AREA.WS_DATA_BASE.WS_DIA_BASE)
                    {

                        /*" -410- SUBTRACT 1 FROM HOST-IDADE. */
                        HOST_IDADE.Value = HOST_IDADE - 1;
                    }

                }

            }


            /*" -412- IF SQL-COD-OPERAC GREATER 99 AND SQL-COD-OPERAC LESS 200 */

            if (SQL_COD_OPERAC > 99 && SQL_COD_OPERAC < 200)
            {

                /*" -414- MOVE 100 TO SQL-CODOPER-PLANOS. */
                _.Move(100, SQL_CODOPER_PLANOS);
            }


            /*" -416- IF SQL-COD-OPERAC GREATER 799 AND SQL-COD-OPERAC LESS 810 */

            if (SQL_COD_OPERAC > 799 && SQL_COD_OPERAC < 810)
            {

                /*" -418- MOVE 800 TO SQL-CODOPER-PLANOS. */
                _.Move(800, SQL_CODOPER_PLANOS);
            }


            /*" -420- MOVE '1' TO SQL-TIPO-COMISSAO. */
            _.Move("1", SQL_TIPO_COMISSAO);

            /*" -434- PERFORM M_1500_NOVAS_COMISSOES_DB_DECLARE_1 */

            M_1500_NOVAS_COMISSOES_DB_DECLARE_1();

            /*" -438- MOVE 'N' TO WFIM-PLANOS. */
            _.Move("N", AREA_DE_WORK.WFIM_PLANOS);

            /*" -440- MOVE '152' TO WNR-EXEC-SQL. */
            _.Move("152", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -440- PERFORM M_1500_NOVAS_COMISSOES_DB_OPEN_1 */

            M_1500_NOVAS_COMISSOES_DB_OPEN_1();

            /*" -444- PERFORM 1501-FETCH-PLANOS THRU 1501-FIM. */

            M_1501_FETCH_PLANOS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1501_FIM*/


            /*" -447- PERFORM 1600-PROCESSA-PLANOS THRU 1600-FIM UNTIL WFIM-PLANOS EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_PLANOS == "S"))
            {

                M_1600_PROCESSA_PLANOS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1600_FIM*/

            }

            /*" -447- PERFORM M_1500_NOVAS_COMISSOES_DB_CLOSE_1 */

            M_1500_NOVAS_COMISSOES_DB_CLOSE_1();

        }

        [StopWatch]
        /*" M-1500-NOVAS-COMISSOES-DB-SELECT-1 */
        public void M_1500_NOVAS_COMISSOES_DB_SELECT_1()
        {
            /*" -359- EXEC SQL SELECT COD_CLIENTE, DATA_NASCIMENTO INTO :V1SEGV-CODCLI, :V1SEGV-DTNASCIM :V1SEGV-DTNASCIM-I FROM SEGUROS.V0SEGURAVG WHERE NUM_CERTIFICADO = :SQL-NUM-CERT AND TIPO_SEGURADO = '1' END-EXEC. */

            var m_1500_NOVAS_COMISSOES_DB_SELECT_1_Query1 = new M_1500_NOVAS_COMISSOES_DB_SELECT_1_Query1()
            {
                SQL_NUM_CERT = SQL_NUM_CERT.ToString(),
            };

            var executed_1 = M_1500_NOVAS_COMISSOES_DB_SELECT_1_Query1.Execute(m_1500_NOVAS_COMISSOES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SEGV_CODCLI, V1SEGV_CODCLI);
                _.Move(executed_1.V1SEGV_DTNASCIM, V1SEGV_DTNASCIM);
                _.Move(executed_1.V1SEGV_DTNASCIM_I, V1SEGV_DTNASCIM_I);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1500_FIM*/

        [StopWatch]
        /*" M-1500-NOVAS-COMISSOES-DB-OPEN-1 */
        public void M_1500_NOVAS_COMISSOES_DB_OPEN_1()
        {
            /*" -440- EXEC SQL OPEN PLANOS END-EXEC. */

            PLANOS.Open();

        }

        [StopWatch]
        /*" M-1500-NOVAS-COMISSOES-DB-CLOSE-1 */
        public void M_1500_NOVAS_COMISSOES_DB_CLOSE_1()
        {
            /*" -447- EXEC SQL CLOSE PLANOS END-EXEC. */

            PLANOS.Close();

        }

        [StopWatch]
        /*" M-1500-NOVAS-COMISSOES-DB-SELECT-2 */
        public void M_1500_NOVAS_COMISSOES_DB_SELECT_2()
        {
            /*" -373- EXEC SQL SELECT DATA_NASCIMENTO INTO :V1CLIE-DTNASCIM:V1CLIE-DTNASCIM-I FROM SEGUROS.V0CLIENTE WHERE COD_CLIENTE = :V1SEGV-CODCLI END-EXEC. */

            var m_1500_NOVAS_COMISSOES_DB_SELECT_2_Query1 = new M_1500_NOVAS_COMISSOES_DB_SELECT_2_Query1()
            {
                V1SEGV_CODCLI = V1SEGV_CODCLI.ToString(),
            };

            var executed_1 = M_1500_NOVAS_COMISSOES_DB_SELECT_2_Query1.Execute(m_1500_NOVAS_COMISSOES_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1CLIE_DTNASCIM, V1CLIE_DTNASCIM);
                _.Move(executed_1.V1CLIE_DTNASCIM_I, V1CLIE_DTNASCIM_I);
            }


        }

        [StopWatch]
        /*" M-1501-FETCH-PLANOS */
        private void M_1501_FETCH_PLANOS(bool isPerform = false)
        {
            /*" -457- MOVE '159' TO WNR-EXEC-SQL. */
            _.Move("159", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -461- PERFORM M_1501_FETCH_PLANOS_DB_FETCH_1 */

            M_1501_FETCH_PLANOS_DB_FETCH_1();

            /*" -464- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -464- MOVE 'S' TO WFIM-PLANOS. */
                _.Move("S", AREA_DE_WORK.WFIM_PLANOS);
            }


        }

        [StopWatch]
        /*" M-1501-FETCH-PLANOS-DB-FETCH-1 */
        public void M_1501_FETCH_PLANOS_DB_FETCH_1()
        {
            /*" -461- EXEC SQL FETCH PLANOS INTO :SQL-NRPARCEL, :SQL-PERC-COMIS END-EXEC. */

            if (PLANOS.Fetch())
            {
                _.Move(PLANOS.SQL_NRPARCEL, SQL_NRPARCEL);
                _.Move(PLANOS.SQL_PERC_COMIS, SQL_PERC_COMIS);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1501_FIM*/

        [StopWatch]
        /*" M-1600-PROCESSA-PLANOS */
        private void M_1600_PROCESSA_PLANOS(bool isPerform = false)
        {
            /*" -473- IF SQL-CODOPER-PLANOS EQUAL 800 */

            if (SQL_CODOPER_PLANOS == 800)
            {

                /*" -474- MOVE SQL-PRM-VG TO SQL-PRM-VG-CO */
                _.Move(SQL_PRM_VG, SQL_PRM_VG_CO);

                /*" -475- MOVE SQL-PRM-AP TO SQL-PRM-AP-CO */
                _.Move(SQL_PRM_AP, SQL_PRM_AP_CO);

                /*" -476- ELSE */
            }
            else
            {


                /*" -477- MOVE SQL-PRM-VG-ATU TO SQL-PRM-VG-CO */
                _.Move(SQL_PRM_VG_ATU, SQL_PRM_VG_CO);

                /*" -479- MOVE SQL-PRM-AP-ATU TO SQL-PRM-AP-CO. */
                _.Move(SQL_PRM_AP_ATU, SQL_PRM_AP_CO);
            }


            /*" -481- MOVE '160' TO WNR-EXEC-SQL. */
            _.Move("160", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -497- PERFORM M_1600_PROCESSA_PLANOS_DB_INSERT_1 */

            M_1600_PROCESSA_PLANOS_DB_INSERT_1();

            /*" -501- ADD +1 TO AC-I-COMISVP. */
            AREA_DE_WORK.AC_I_COMISVP.Value = AREA_DE_WORK.AC_I_COMISVP + +1;

            /*" -501- PERFORM 1501-FETCH-PLANOS THRU 1501-FIM. */

            M_1501_FETCH_PLANOS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1501_FIM*/


        }

        [StopWatch]
        /*" M-1600-PROCESSA-PLANOS-DB-INSERT-1 */
        public void M_1600_PROCESSA_PLANOS_DB_INSERT_1()
        {
            /*" -497- EXEC SQL INSERT INTO SEGUROS.COMISSOES_VP VALUES (:SQL-NUM-CERT , :SQL-NRPARCEL , :SQL-CODOPER-PLANOS , :SQL-DTMOVABE , :SQL-DTMOVABE , :SQL-PRM-VG-CO , :SQL-PRM-AP-CO , '1' , :SQL-PERC-COMIS , :SQL-COD-FONTE , :SQL-PROPOSTA , '0' , 'VP5705B' , CURRENT TIMESTAMP ) END-EXEC. */

            var m_1600_PROCESSA_PLANOS_DB_INSERT_1_Insert1 = new M_1600_PROCESSA_PLANOS_DB_INSERT_1_Insert1()
            {
                SQL_NUM_CERT = SQL_NUM_CERT.ToString(),
                SQL_NRPARCEL = SQL_NRPARCEL.ToString(),
                SQL_CODOPER_PLANOS = SQL_CODOPER_PLANOS.ToString(),
                SQL_DTMOVABE = SQL_DTMOVABE.ToString(),
                SQL_PRM_VG_CO = SQL_PRM_VG_CO.ToString(),
                SQL_PRM_AP_CO = SQL_PRM_AP_CO.ToString(),
                SQL_PERC_COMIS = SQL_PERC_COMIS.ToString(),
                SQL_COD_FONTE = SQL_COD_FONTE.ToString(),
                SQL_PROPOSTA = SQL_PROPOSTA.ToString(),
            };

            M_1600_PROCESSA_PLANOS_DB_INSERT_1_Insert1.Execute(m_1600_PROCESSA_PLANOS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1600_FIM*/

        [StopWatch]
        /*" M-9000-ENCERRA-SEM-MOVTO */
        private void M_9000_ENCERRA_SEM_MOVTO(bool isPerform = false)
        {
            /*" -513- MOVE SQL-DTMOVABE TO WDATA-REL. */
            _.Move(SQL_DTMOVABE, AREA_DE_WORK.WDATA_REL);

            /*" -514- MOVE WDAT-REL-DIA TO WDAT-LIT-DIA. */
            _.Move(AREA_DE_WORK.FILLER_4.WDAT_REL_DIA, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_DIA);

            /*" -515- MOVE WDAT-REL-MES TO WDAT-LIT-MES. */
            _.Move(AREA_DE_WORK.FILLER_4.WDAT_REL_MES, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_MES);

            /*" -517- MOVE WDAT-REL-ANO TO WDAT-LIT-ANO. */
            _.Move(AREA_DE_WORK.FILLER_4.WDAT_REL_ANO, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_ANO);

            /*" -518- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -519- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -520- DISPLAY '*   VP5705B - ATUALIZACAO DB COMISSOES     *' */
            _.Display($"*   VP5705B - ATUALIZACAO DB COMISSOES     *");

            /*" -521- DISPLAY '*   -------   ----------- -- ---------     *' */
            _.Display($"*   -------   ----------- -- ---------     *");

            /*" -522- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -523- DISPLAY '*   NAO HOUVE MOVIMENTACAO                 *' */
            _.Display($"*   NAO HOUVE MOVIMENTACAO                 *");

            /*" -525- DISPLAY '*   NESTA DATA ' WDAT-REL-LIT '                    *' */

            $"*   NESTA DATA {AREA_DE_WORK.WDAT_REL_LIT}                    *"
            .Display();

            /*" -526- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -526- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9000_FIM*/

        [StopWatch]
        /*" M-9999-ERRO */
        private void M_9999_ERRO(bool isPerform = false)
        {
            /*" -538- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -540- DISPLAY WABEND. */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -540- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -542- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -545- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -545- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}