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
using Sias.VidaEmGrupo.DB2.VP5706B;

namespace Code
{
    public class VP5706B
    {
        public bool IsCall { get; set; }

        public VP5706B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *   CALCULA E GERA COMISSOES DE AGENCIAMENTO PARA A APOLICE      *      */
        /*"      *                  * EXCLUSIVO *     A PARTIR DE 01/12/2001.     *      */
        /*"      ******************************************************************      */
        /*"      *                                 FREDERICO J FONSECA 26.11.01   *      */
        /*"      *                                 * GERADO A PARTIR DO VP0706B   *      */
        /*"      ******************************************************************      */
        /*"      * 003 - 7/02/2019 - GERALDO NAKAJIMA                             *      */
        /*"      *   PREPARAR   PROGRAMA PARA PROCESSAMENTO DA JV1                *      */
        /*"      *                                        PROCURE POR JV1         *      */
        /*"      ******************************************************************      */
        /*"      * 002 - 1/06/2004 - MANOEL MESSIAS                               *      */
        /*"      *   ESTAVA MOVENDO O RAMO 81 PARA O INSERT DA V0COMISSAO E FOI   *      */
        /*"      * MUDADO PARA O RAMO 82 O QUE E CORRETO.                         *      */
        /*"      *                                       PROCURE POR MM0604       *      */
        /*"      ******************************************************************      */
        /*"      * 001 - 1/01/2002 - MANOEL MESSIAS                               *      */
        /*"      *   LIBERAR COMISSAO PARA TODOS, INDEPENDENTE DO PAGAMENTO DA    *      */
        /*"      * PARCELA, POIS, A COMISSAO DEVE SER PAGA NO ATO DA VENDA E NAO  *      */
        /*"      * QUANDO A PARCELA FOR PAGA.                                     *      */
        /*"      *                                       PROCURE POR MM0102       *      */
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  SQL-PAGAS                    PIC S9(004)     COMP VALUE 0.*/
        public IntBasis SQL_PAGAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  SQL-NOT-NULL                 PIC S9(004)     COMP VALUE +1.*/
        public IntBasis SQL_NOT_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +1);
        /*"01  SQL-DTMOVABE                 PIC  X(010).*/
        public StringBasis SQL_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  SQL-DTMOVTO                  PIC  X(010).*/
        public StringBasis SQL_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
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
        /*"01  SQL-MATRICULA                PIC S9(015)     COMP-3.*/
        public IntBasis SQL_MATRICULA { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01  SQL-NUM-CERT                 PIC S9(015)     COMP-3.*/
        public IntBasis SQL_NUM_CERT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01  SQL-DAC-CERT                 PIC  X(001).*/
        public StringBasis SQL_DAC_CERT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  SQL-SITUACAO                 PIC  X(001).*/
        public StringBasis SQL_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  SQL-COD-CLIE                 PIC S9(009)     COMP.*/
        public IntBasis SQL_COD_CLIE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  SQL-COD-AGEN                 PIC S9(009)     COMP.*/
        public IntBasis SQL_COD_AGEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  SQL-PRM-VG                   PIC S9(013)V99  COMP-3.*/
        public DoubleBasis SQL_PRM_VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  SQL-PRM-AP                   PIC S9(013)V99  COMP-3.*/
        public DoubleBasis SQL_PRM_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
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
        /*"01  SQL-FAIXA                    PIC S9(004)     COMP.*/
        public IntBasis SQL_FAIXA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  SQL-DATSEL                   PIC  X(010).*/
        public StringBasis SQL_DATSEL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
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
        /*"01  SQL-PCIOF                    PIC S9(003)V99  COMP-3.*/
        public DoubleBasis SQL_PCIOF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"01  SQL-DTADMIS                  PIC  X(010).*/
        public StringBasis SQL_DTADMIS { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01           AREA-DE-WORK.*/
        public VP5706B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VP5706B_AREA_DE_WORK();
        public class VP5706B_AREA_DE_WORK : VarBasis
        {
            /*"    05 WS-PCIOF                PIC S9(001)V9999.*/
            public DoubleBasis WS_PCIOF { get; set; } = new DoubleBasis(new PIC("S9", "1", "S9(001)V9999."), 4);
            /*"    05 WS-APOL-ANT             PIC S9(013)      COMP-3.*/
            public IntBasis WS_APOL_ANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"    05 WS-SUBGR-ANT            PIC S9(004)      COMP.*/
            public IntBasis WS_SUBGR_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05       WSL-SQLCODE       PIC  9(009)    VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05       WFIM-V0MOVIMENTO  PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V0MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05       AC-L-V0MOVIMENTO  PIC  9(005)    VALUE ZEROS.*/
            public IntBasis AC_L_V0MOVIMENTO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    05       AC-I-V0COMISSAO   PIC  9(005)    VALUE ZEROS.*/
            public IntBasis AC_I_V0COMISSAO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    05       WDATA-REL         PIC  X(010)    VALUE SPACES.*/
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    05       FILLER            REDEFINES      WDATA-REL.*/
            private _REDEF_VP5706B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_VP5706B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_VP5706B_FILLER_0(); _.Move(WDATA_REL, _filler_0); VarBasis.RedefinePassValue(WDATA_REL, _filler_0, WDATA_REL); _filler_0.ValueChanged += () => { _.Move(_filler_0, WDATA_REL); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WDATA_REL); }
            }  //Redefines
            public class _REDEF_VP5706B_FILLER_0 : VarBasis
            {
                /*"      10     WDAT-REL-ANO      PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10     FILLER            PIC  X(001).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10     WDAT-REL-MES      PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     FILLER            PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10     WDAT-REL-DIA      PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05       WDAT-REL-LIT.*/

                public _REDEF_VP5706B_FILLER_0()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public VP5706B_WDAT_REL_LIT WDAT_REL_LIT { get; set; } = new VP5706B_WDAT_REL_LIT();
            public class VP5706B_WDAT_REL_LIT : VarBasis
            {
                /*"      10     WDAT-LIT-DIA      PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDAT_LIT_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"      10     FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10     WDAT-LIT-MES      PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDAT_LIT_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"      10     FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10     WDAT-LIT-ANO      PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDAT_LIT_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    05       W01DTSQL.*/
            }
            public VP5706B_W01DTSQL W01DTSQL { get; set; } = new VP5706B_W01DTSQL();
            public class VP5706B_W01DTSQL : VarBasis
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
            public VP5706B_WTIME_DAY WTIME_DAY { get; set; } = new VP5706B_WTIME_DAY();
            public class VP5706B_WTIME_DAY : VarBasis
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
            public VP5706B_WHORA WHORA { get; set; } = new VP5706B_WHORA();
            public class VP5706B_WHORA : VarBasis
            {
                /*"      10     WHH               PIC  9(002).*/
                public IntBasis WHH_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     FILLER            PIC  X(001) VALUE '.'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"      10     WMM               PIC  9(002).*/
                public IntBasis WMM_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     FILLER            PIC  X(001) VALUE '.'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"      10     WSS               PIC  9(002).*/
                public IntBasis WSS_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05      WABEND.*/
            }
            public VP5706B_WABEND WABEND { get; set; } = new VP5706B_WABEND();
            public class VP5706B_WABEND : VarBasis
            {
                /*"      10    FILLER              PIC  X(010) VALUE           ' VP5706B'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VP5706B");
                /*"      10    FILLER              PIC  X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"      10    WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"      10    FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"      10    WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            }
        }


        public VP5706B_V0MOVIMENTO V0MOVIMENTO { get; set; } = new VP5706B_V0MOVIMENTO();
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
            /*" -158- MOVE '001' TO WNR-EXEC-SQL. */
            _.Move("001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -159- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -162- EXEC SQL WHENEVER SQLERROR GO TO 9999-ERRO END-EXEC. */

            /*" -165- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -177- MOVE '9999-12-31' TO SQL-DATSEL. */
            _.Move("9999-12-31", SQL_DATSEL);

            /*" -179- MOVE '005' TO WNR-EXEC-SQL. */
            _.Move("005", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -184- PERFORM M_0000_INICIO_DB_SELECT_1 */

            M_0000_INICIO_DB_SELECT_1();

            /*" -187- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -188- DISPLAY '*** VP5706B *** SISTEMA PREF VIDA NAO CADASTRADO' */
                _.Display($"*** VP5706B *** SISTEMA PREF VIDA NAO CADASTRADO");

                /*" -190- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -197- PERFORM M_0000_INICIO_DB_SELECT_2 */

            M_0000_INICIO_DB_SELECT_2();

            /*" -200- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -201- DISPLAY '*** VP5706B *** SEM PERCENTUAL DE IOF - RAMOIND ' */
                _.Display($"*** VP5706B *** SEM PERCENTUAL DE IOF - RAMOIND ");

                /*" -203- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -209- COMPUTE WS-PCIOF = 1 + (SQL-PCIOF / 100). */
            AREA_DE_WORK.WS_PCIOF.Value = 1 + (SQL_PCIOF / 100f);

            /*" -211- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -239- PERFORM M_0000_INICIO_DB_DECLARE_1 */

            M_0000_INICIO_DB_DECLARE_1();

            /*" -243- MOVE '011' TO WNR-EXEC-SQL. */
            _.Move("011", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -244- DISPLAY '*** VP5706B *** ABRINDO CURSOR ...' . */
            _.Display($"*** VP5706B *** ABRINDO CURSOR ...");

            /*" -244- PERFORM M_0000_INICIO_DB_OPEN_1 */

            M_0000_INICIO_DB_OPEN_1();

            /*" -252- PERFORM 1100-FETCH THRU 1100-FIM. */

            M_1100_FETCH(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1100_FIM*/


            /*" -253- IF WFIM-V0MOVIMENTO EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_V0MOVIMENTO == "S")
            {

                /*" -254- PERFORM 9000-ENCERRA-SEM-MOVTO THRU 9000-FIM */

                M_9000_ENCERRA_SEM_MOVTO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9000_FIM*/


                /*" -256- GO TO 0002-FINALIZA. */

                M_0002_FINALIZA(); //GOTO
                return;
            }


            /*" -257- DISPLAY '*** VP5706B *** PROCESSANDO ...' . */
            _.Display($"*** VP5706B *** PROCESSANDO ...");

            /*" -260- PERFORM M-1000-PROCESSA-MOVIMENTO THRU 1000-FIM UNTIL WFIM-V0MOVIMENTO EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_V0MOVIMENTO == "S"))
            {

                M_1000_PROCESSA_MOVIMENTO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1000_FIM*/

            }

            /*" -261- DISPLAY '*** VP5706B *** MOV LIDOS       ' AC-L-V0MOVIMENTO. */
            _.Display($"*** VP5706B *** MOV LIDOS       {AREA_DE_WORK.AC_L_V0MOVIMENTO}");

            /*" -261- DISPLAY '*** VP5706B *** COMIS INSERIDAS ' AC-I-V0COMISSAO. */
            _.Display($"*** VP5706B *** COMIS INSERIDAS {AREA_DE_WORK.AC_I_V0COMISSAO}");

        }

        [StopWatch]
        /*" M-0000-INICIO-DB-SELECT-1 */
        public void M_0000_INICIO_DB_SELECT_1()
        {
            /*" -184- EXEC SQL SELECT DTMOVABE INTO :SQL-DTMOVABE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VP' END-EXEC. */

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
        /*" M-0002-FINALIZA */
        private void M_0002_FINALIZA(bool isPerform = false)
        {
            /*" -267- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -267- PERFORM M_0002_FINALIZA_DB_CLOSE_1 */

            M_0002_FINALIZA_DB_CLOSE_1();

            /*" -271- MOVE '091' TO WNR-EXEC-SQL. */
            _.Move("091", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -271- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -275- DISPLAY '*** VP5706B *** TERMINO NORMAL' . */
            _.Display($"*** VP5706B *** TERMINO NORMAL");

            /*" -277- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -277- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-0002-FINALIZA-DB-CLOSE-1 */
        public void M_0002_FINALIZA_DB_CLOSE_1()
        {
            /*" -267- EXEC SQL CLOSE V0MOVIMENTO END-EXEC. */

            V0MOVIMENTO.Close();

        }

        [StopWatch]
        /*" M-0000-INICIO-DB-DECLARE-1 */
        public void M_0000_INICIO_DB_DECLARE_1()
        {
            /*" -239- EXEC SQL DECLARE V0MOVIMENTO CURSOR FOR SELECT A.NUM_APOLICE, A.COD_SUBGRUPO, A.COD_FONTE, A.NUM_PROPOSTA, A.TIPO_SEGURADO, A.NUM_CERTIFICADO, A.DAC_CERTIFICADO, A.COD_CLIENTE, A.COD_AGENCIADOR, A.NUM_MATRICULA, B.PREMIO_VG, B.PREMIO_AP, B.COD_OPERACAO, A.FAIXA, B.PERC_COMISSAO, B.NUM_PARCELA, B.DATA_MOVIMENTO, B.SITUACAO FROM SEGUROS.V0MOVIMENTO A, SEGUROS.COMISSOES_VP B WHERE B.SITUACAO = '0' AND B.FONTE = A.COD_FONTE AND B.NUM_PROPOSTA = A.NUM_PROPOSTA AND A.NUM_APOLICE IN (109300000559, 3009300000559) ORDER BY 1,2 END-EXEC. */
            V0MOVIMENTO = new VP5706B_V0MOVIMENTO(false);
            string GetQuery_V0MOVIMENTO()
            {
                var query = @$"SELECT A.NUM_APOLICE
							, 
							A.COD_SUBGRUPO
							, 
							A.COD_FONTE
							, 
							A.NUM_PROPOSTA
							, 
							A.TIPO_SEGURADO
							, 
							A.NUM_CERTIFICADO
							, 
							A.DAC_CERTIFICADO
							, 
							A.COD_CLIENTE
							, 
							A.COD_AGENCIADOR
							, 
							A.NUM_MATRICULA
							, 
							B.PREMIO_VG
							, 
							B.PREMIO_AP
							, 
							B.COD_OPERACAO
							, 
							A.FAIXA
							, 
							B.PERC_COMISSAO
							, 
							B.NUM_PARCELA
							, 
							B.DATA_MOVIMENTO
							, 
							B.SITUACAO 
							FROM SEGUROS.V0MOVIMENTO A
							, 
							SEGUROS.COMISSOES_VP B 
							WHERE 
							B.SITUACAO = '0' 
							AND B.FONTE = A.COD_FONTE 
							AND B.NUM_PROPOSTA = A.NUM_PROPOSTA 
							AND A.NUM_APOLICE IN (109300000559
							, 3009300000559) 
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
            /*" -244- EXEC SQL OPEN V0MOVIMENTO END-EXEC. */

            V0MOVIMENTO.Open();

        }

        [StopWatch]
        /*" M-0000-INICIO-DB-SELECT-2 */
        public void M_0000_INICIO_DB_SELECT_2()
        {
            /*" -197- EXEC SQL SELECT PCIOF INTO :SQL-PCIOF FROM SEGUROS.V1RAMOIND WHERE RAMO = 93 AND DTINIVIG <= :SQL-DTMOVABE AND DTTERVIG >= :SQL-DTMOVABE END-EXEC. */

            var m_0000_INICIO_DB_SELECT_2_Query1 = new M_0000_INICIO_DB_SELECT_2_Query1()
            {
                SQL_DTMOVABE = SQL_DTMOVABE.ToString(),
            };

            var executed_1 = M_0000_INICIO_DB_SELECT_2_Query1.Execute(m_0000_INICIO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SQL_PCIOF, SQL_PCIOF);
            }


        }

        [StopWatch]
        /*" M-1000-PROCESSA-MOVIMENTO */
        private void M_1000_PROCESSA_MOVIMENTO(bool isPerform = false)
        {
            /*" -285- PERFORM 1200-LE-PLANO-AGENC THRU 1200-FIM. */

            M_1200_LE_PLANO_AGENC(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1200_FIM*/


            /*" -288- PERFORM 1300-PROC-COMIS-SUBGR THRU 1300-FIM UNTIL SQL-NUM-APOL NOT EQUAL WS-APOL-ANT OR SQL-COD-SUB NOT EQUAL WS-SUBGR-ANT OR WFIM-V0MOVIMENTO EQUAL 'S' . */

            while (!(SQL_NUM_APOL != AREA_DE_WORK.WS_APOL_ANT || SQL_COD_SUB != AREA_DE_WORK.WS_SUBGR_ANT || AREA_DE_WORK.WFIM_V0MOVIMENTO == "S"))
            {

                M_1300_PROC_COMIS_SUBGR(true);

                M_1300_UPDATE(true);

                M_1300_NEXT(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1300_FIM*/

            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1000_FIM*/

        [StopWatch]
        /*" M-1100-FETCH */
        private void M_1100_FETCH(bool isPerform = false)
        {
            /*" -298- MOVE '110' TO WNR-EXEC-SQL. */
            _.Move("110", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -318- PERFORM M_1100_FETCH_DB_FETCH_1 */

            M_1100_FETCH_DB_FETCH_1();

            /*" -321- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -322- MOVE 'S' TO WFIM-V0MOVIMENTO */
                _.Move("S", AREA_DE_WORK.WFIM_V0MOVIMENTO);

                /*" -323- ELSE */
            }
            else
            {


                /*" -323- ADD 1 TO AC-L-V0MOVIMENTO. */
                AREA_DE_WORK.AC_L_V0MOVIMENTO.Value = AREA_DE_WORK.AC_L_V0MOVIMENTO + 1;
            }


        }

        [StopWatch]
        /*" M-1100-FETCH-DB-FETCH-1 */
        public void M_1100_FETCH_DB_FETCH_1()
        {
            /*" -318- EXEC SQL FETCH V0MOVIMENTO INTO :SQL-NUM-APOL, :SQL-COD-SUB, :SQL-COD-FONTE, :SQL-PROPOSTA, :SQL-TIPO-SEG, :SQL-NUM-CERT, :SQL-DAC-CERT, :SQL-COD-CLIE, :SQL-COD-AGEN, :SQL-MATRICULA, :SQL-PRM-VG, :SQL-PRM-AP, :SQL-COD-OPERAC, :SQL-FAIXA, :SQL-PERC-COMIS, :SQL-NRPARCEL, :SQL-DTMOVTO, :SQL-SITUACAO END-EXEC. */

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
                _.Move(V0MOVIMENTO.SQL_MATRICULA, SQL_MATRICULA);
                _.Move(V0MOVIMENTO.SQL_PRM_VG, SQL_PRM_VG);
                _.Move(V0MOVIMENTO.SQL_PRM_AP, SQL_PRM_AP);
                _.Move(V0MOVIMENTO.SQL_COD_OPERAC, SQL_COD_OPERAC);
                _.Move(V0MOVIMENTO.SQL_FAIXA, SQL_FAIXA);
                _.Move(V0MOVIMENTO.SQL_PERC_COMIS, SQL_PERC_COMIS);
                _.Move(V0MOVIMENTO.SQL_NRPARCEL, SQL_NRPARCEL);
                _.Move(V0MOVIMENTO.SQL_DTMOVTO, SQL_DTMOVTO);
                _.Move(V0MOVIMENTO.SQL_SITUACAO, SQL_SITUACAO);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1100_FIM*/

        [StopWatch]
        /*" M-1200-LE-PLANO-AGENC */
        private void M_1200_LE_PLANO_AGENC(bool isPerform = false)
        {
            /*" -332- MOVE SQL-NUM-APOL TO WS-APOL-ANT. */
            _.Move(SQL_NUM_APOL, AREA_DE_WORK.WS_APOL_ANT);

            /*" -332- MOVE SQL-COD-SUB TO WS-SUBGR-ANT. */
            _.Move(SQL_COD_SUB, AREA_DE_WORK.WS_SUBGR_ANT);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1200_FIM*/

        [StopWatch]
        /*" M-1300-PROC-COMIS-SUBGR */
        private void M_1300_PROC_COMIS_SUBGR(bool isPerform = false)
        {
            /*" -342- MOVE 'A17' TO WNR-EXEC-SQL. */
            _.Move("A17", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -347- PERFORM M_1300_PROC_COMIS_SUBGR_DB_SELECT_1 */

            M_1300_PROC_COMIS_SUBGR_DB_SELECT_1();

            /*" -350- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -352- DISPLAY 'PROBLEMAS NO ACESSO AO SEGURADO - V0PROPOSTAVA ' SQL-NUM-CERT ' ' SQLCODE */

                $"PROBLEMAS NO ACESSO AO SEGURADO - V0PROPOSTAVA {SQL_NUM_CERT} {DB.SQLCODE}"
                .Display();

                /*" -358- GO TO 1300-NEXT. */

                M_1300_NEXT(); //GOTO
                return;
            }


            /*" -359- IF SQL-PRM-VG > ZEROES */

            if (SQL_PRM_VG > 00)
            {

                /*" -361- PERFORM 1310-PROC-COMIS-VG THRU 1310-FIM. */

                M_1310_PROC_COMIS_VG(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1310_FIM*/

            }


            /*" -362- IF SQL-PRM-AP > ZEROES */

            if (SQL_PRM_AP > 00)
            {

                /*" -364- PERFORM 1320-PROC-COMIS-AP THRU 1320-FIM. */

                M_1320_PROC_COMIS_AP(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1320_FIM*/

            }


            /*" -365- IF SQL-SITUACAO = '0' */

            if (SQL_SITUACAO == "0")
            {

                /*" -365- GO TO 1300-NEXT. */

                M_1300_NEXT(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-1300-PROC-COMIS-SUBGR-DB-SELECT-1 */
        public void M_1300_PROC_COMIS_SUBGR_DB_SELECT_1()
        {
            /*" -347- EXEC SQL SELECT VALUE(DATA_ADMISSAO, DATE( '1900-01-01' )) INTO :SQL-DTADMIS FROM SEGUROS.V0PROPOSTAVA WHERE NRCERTIF = :SQL-NUM-CERT END-EXEC. */

            var m_1300_PROC_COMIS_SUBGR_DB_SELECT_1_Query1 = new M_1300_PROC_COMIS_SUBGR_DB_SELECT_1_Query1()
            {
                SQL_NUM_CERT = SQL_NUM_CERT.ToString(),
            };

            var executed_1 = M_1300_PROC_COMIS_SUBGR_DB_SELECT_1_Query1.Execute(m_1300_PROC_COMIS_SUBGR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SQL_DTADMIS, SQL_DTADMIS);
            }


        }

        [StopWatch]
        /*" M-1300-UPDATE */
        private void M_1300_UPDATE(bool isPerform = false)
        {
            /*" -371- MOVE '017' TO WNR-EXEC-SQL. */
            _.Move("017", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -382- PERFORM M_1300_UPDATE_DB_UPDATE_1 */

            M_1300_UPDATE_DB_UPDATE_1();

        }

        [StopWatch]
        /*" M-1300-UPDATE-DB-UPDATE-1 */
        public void M_1300_UPDATE_DB_UPDATE_1()
        {
            /*" -382- EXEC SQL UPDATE SEGUROS.COMISSOES_VP SET SITUACAO = :SQL-SITUACAO, DATA_COMISSAO = :SQL-DTMOVABE, COD_USUARIO = 'VP5706B' , TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_CERTIFICADO = :SQL-NUM-CERT AND NUM_PARCELA = :SQL-NRPARCEL AND COD_OPERACAO = :SQL-COD-OPERAC AND DATA_MOVIMENTO = :SQL-DTMOVTO AND SITUACAO = '0' END-EXEC. */

            var m_1300_UPDATE_DB_UPDATE_1_Update1 = new M_1300_UPDATE_DB_UPDATE_1_Update1()
            {
                SQL_SITUACAO = SQL_SITUACAO.ToString(),
                SQL_DTMOVABE = SQL_DTMOVABE.ToString(),
                SQL_COD_OPERAC = SQL_COD_OPERAC.ToString(),
                SQL_NUM_CERT = SQL_NUM_CERT.ToString(),
                SQL_NRPARCEL = SQL_NRPARCEL.ToString(),
                SQL_DTMOVTO = SQL_DTMOVTO.ToString(),
            };

            M_1300_UPDATE_DB_UPDATE_1_Update1.Execute(m_1300_UPDATE_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-1300-NEXT */
        private void M_1300_NEXT(bool isPerform = false)
        {
            /*" -387- PERFORM 1100-FETCH THRU 1100-FIM. */

            M_1100_FETCH(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1100_FIM*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1300_FIM*/

        [StopWatch]
        /*" M-1310-PROC-COMIS-VG */
        private void M_1310_PROC_COMIS_VG(bool isPerform = false)
        {
            /*" -397- MOVE 93 TO SQL-RAMOFR. */
            _.Move(93, SQL_RAMOFR);

            /*" -398- COMPUTE SQL-PRM-VG ROUNDED = SQL-PRM-VG / WS-PCIOF. */
            SQL_PRM_VG.Value = SQL_PRM_VG / AREA_DE_WORK.WS_PCIOF;

            /*" -400- MOVE SQL-PRM-VG TO SQL-VALBAS. */
            _.Move(SQL_PRM_VG, SQL_VALBAS);

            /*" -400- PERFORM 1350-CALCULA-COMISSAO THRU 1350-FIM. */

            M_1350_CALCULA_COMISSAO(true);

            M_1350_CALCULA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1350_FIM*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1310_FIM*/

        [StopWatch]
        /*" M-1320-PROC-COMIS-AP */
        private void M_1320_PROC_COMIS_AP(bool isPerform = false)
        {
            /*" -410- MOVE 82 TO SQL-RAMOFR. */
            _.Move(82, SQL_RAMOFR);

            /*" -411- COMPUTE SQL-PRM-AP ROUNDED = SQL-PRM-AP / WS-PCIOF. */
            SQL_PRM_AP.Value = SQL_PRM_AP / AREA_DE_WORK.WS_PCIOF;

            /*" -413- MOVE SQL-PRM-AP TO SQL-VALBAS. */
            _.Move(SQL_PRM_AP, SQL_VALBAS);

            /*" -413- PERFORM 1350-CALCULA-COMISSAO THRU 1350-FIM. */

            M_1350_CALCULA_COMISSAO(true);

            M_1350_CALCULA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1350_FIM*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1320_FIM*/

        [StopWatch]
        /*" M-1350-CALCULA-COMISSAO */
        private void M_1350_CALCULA_COMISSAO(bool isPerform = false)
        {
            /*" -442- MOVE '1' TO SQL-SITUACAO. */
            _.Move("1", SQL_SITUACAO);

            /*" -442- MOVE SQL-PERC-COMIS TO SQL-PCT-AGENC. */
            _.Move(SQL_PERC_COMIS, SQL_PCT_AGENC);

        }

        [StopWatch]
        /*" M-1350-CALCULA */
        private void M_1350_CALCULA(bool isPerform = false)
        {
            /*" -449- COMPUTE SQL-VLCOMIS ROUNDED = (SQL-VALBAS * SQL-PCT-AGENC) / 100. */
            SQL_VLCOMIS.Value = (SQL_VALBAS * SQL_PCT_AGENC) / 100f;

            /*" -449- PERFORM 1400-GRAVA-COMIS THRU 1400-FIM. */

            M_1400_GRAVA_COMIS(true);

            M_1400_LOOP_GRAVA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1400_FIM*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1350_FIM*/

        [StopWatch]
        /*" M-1400-GRAVA-COMIS */
        private void M_1400_GRAVA_COMIS(bool isPerform = false)
        {
            /*" -458- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

        }

        [StopWatch]
        /*" M-1400-LOOP-GRAVA */
        private void M_1400_LOOP_GRAVA(bool isPerform = false)
        {
            /*" -463- ACCEPT WTIME-DAY FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WTIME_DAY);

            /*" -465- MOVE CORR WTIME-DAY TO WHORA */
            _.MoveCorr(AREA_DE_WORK.WTIME_DAY, AREA_DE_WORK.WHORA);

            /*" -467- MOVE WHORA TO SQL-HORAOPER. */
            _.Move(AREA_DE_WORK.WHORA, SQL_HORAOPER);

            /*" -469- MOVE '140' TO WNR-EXEC-SQL. */
            _.Move("140", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -471- MOVE -1 TO SQL-NUMBILI. */
            _.Move(-1, SQL_NUMBILI);

            /*" -505- PERFORM M_1400_LOOP_GRAVA_DB_INSERT_1 */

            M_1400_LOOP_GRAVA_DB_INSERT_1();

            /*" -508- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -509- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -510- GO TO 1400-LOOP-GRAVA */
                    new Task(() => M_1400_LOOP_GRAVA()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -511- ELSE */
                }
                else
                {


                    /*" -513- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -515- ADD +1 TO AC-I-V0COMISSAO. */
            AREA_DE_WORK.AC_I_V0COMISSAO.Value = AREA_DE_WORK.AC_I_V0COMISSAO + +1;

            /*" -516- EXEC SQL WHENEVER SQLERROR GO TO 9999-ERRO END-EXEC. */

        }

        [StopWatch]
        /*" M-1400-LOOP-GRAVA-DB-INSERT-1 */
        public void M_1400_LOOP_GRAVA_DB_INSERT_1()
        {
            /*" -505- EXEC SQL INSERT INTO SEGUROS.V0COMISSAO VALUES (:SQL-NUM-APOL , 0, :SQL-NUM-CERT , :SQL-DAC-CERT , :SQL-TIPO-SEG , 0 , 1101, :SQL-COD-AGEN , :SQL-RAMOFR , 0, 0, :SQL-COD-FONTE, :SQL-COD-CLIE , :SQL-VLCOMIS , :SQL-DTMOVABE , 0, :SQL-VALBAS , '8' , 0, :SQL-PCT-AGENC, 0, :SQL-COD-SUB, :SQL-HORAOPER, NULL, :SQL-DATSEL:SQL-NOT-NULL, NULL, :SQL-PROPOSTA:SQL-NOT-NULL, CURRENT TIMESTAMP, :SQL-NUMBIL:SQL-NUMBILI, 0, NULL) END-EXEC. */

            var m_1400_LOOP_GRAVA_DB_INSERT_1_Insert1 = new M_1400_LOOP_GRAVA_DB_INSERT_1_Insert1()
            {
                SQL_NUM_APOL = SQL_NUM_APOL.ToString(),
                SQL_NUM_CERT = SQL_NUM_CERT.ToString(),
                SQL_DAC_CERT = SQL_DAC_CERT.ToString(),
                SQL_TIPO_SEG = SQL_TIPO_SEG.ToString(),
                SQL_COD_AGEN = SQL_COD_AGEN.ToString(),
                SQL_RAMOFR = SQL_RAMOFR.ToString(),
                SQL_COD_FONTE = SQL_COD_FONTE.ToString(),
                SQL_COD_CLIE = SQL_COD_CLIE.ToString(),
                SQL_VLCOMIS = SQL_VLCOMIS.ToString(),
                SQL_DTMOVABE = SQL_DTMOVABE.ToString(),
                SQL_VALBAS = SQL_VALBAS.ToString(),
                SQL_PCT_AGENC = SQL_PCT_AGENC.ToString(),
                SQL_COD_SUB = SQL_COD_SUB.ToString(),
                SQL_HORAOPER = SQL_HORAOPER.ToString(),
                SQL_DATSEL = SQL_DATSEL.ToString(),
                SQL_NOT_NULL = SQL_NOT_NULL.ToString(),
                SQL_PROPOSTA = SQL_PROPOSTA.ToString(),
                SQL_NUMBIL = SQL_NUMBIL.ToString(),
                SQL_NUMBILI = SQL_NUMBILI.ToString(),
            };

            M_1400_LOOP_GRAVA_DB_INSERT_1_Insert1.Execute(m_1400_LOOP_GRAVA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1400_FIM*/

        [StopWatch]
        /*" M-9000-ENCERRA-SEM-MOVTO */
        private void M_9000_ENCERRA_SEM_MOVTO(bool isPerform = false)
        {
            /*" -527- MOVE SQL-DTMOVABE TO WDATA-REL. */
            _.Move(SQL_DTMOVABE, AREA_DE_WORK.WDATA_REL);

            /*" -528- MOVE WDAT-REL-DIA TO WDAT-LIT-DIA. */
            _.Move(AREA_DE_WORK.FILLER_0.WDAT_REL_DIA, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_DIA);

            /*" -529- MOVE WDAT-REL-MES TO WDAT-LIT-MES. */
            _.Move(AREA_DE_WORK.FILLER_0.WDAT_REL_MES, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_MES);

            /*" -531- MOVE WDAT-REL-ANO TO WDAT-LIT-ANO. */
            _.Move(AREA_DE_WORK.FILLER_0.WDAT_REL_ANO, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_ANO);

            /*" -532- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -533- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -534- DISPLAY '*   VP5706B - ATUALIZACAO DB COMISSOES     *' */
            _.Display($"*   VP5706B - ATUALIZACAO DB COMISSOES     *");

            /*" -535- DISPLAY '*   -------   ----------- -- ---------     *' */
            _.Display($"*   -------   ----------- -- ---------     *");

            /*" -536- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -537- DISPLAY '*   NAO HOUVE MOVIMENTACAO                 *' */
            _.Display($"*   NAO HOUVE MOVIMENTACAO                 *");

            /*" -539- DISPLAY '*   NESTA DATA ' WDAT-REL-LIT '                    *' */

            $"*   NESTA DATA {AREA_DE_WORK.WDAT_REL_LIT}                    *"
            .Display();

            /*" -540- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -540- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9000_FIM*/

        [StopWatch]
        /*" M-9999-ERRO */
        private void M_9999_ERRO(bool isPerform = false)
        {
            /*" -552- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -554- DISPLAY WABEND. */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -556- DISPLAY 'NUM-CERT ' SQL-NUM-CERT. */
            _.Display($"NUM-CERT {SQL_NUM_CERT}");

            /*" -556- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -558- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -561- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -561- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}