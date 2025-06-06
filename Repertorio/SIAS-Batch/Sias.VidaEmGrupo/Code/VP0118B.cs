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
using Sias.VidaEmGrupo.DB2.VP0118B;

namespace Code
{
    public class VP0118B
    {
        public bool IsCall { get; set; }

        public VP0118B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *   FAZ A ATUALIZACAO DA COBERTURA DE DOENCAS GRAVES PARA OS SE -*      */
        /*"      *   GURADOS DO GRUPO DO EXCLUSIVO. 30% DA COBERTURA DE MORTE NA -*      */
        /*"      *   TURAL LIMITADO AO MINIMO DE 20.000,00 E MAXIMO DE 60.000,00. *      */
        /*"      *                                                                *      */
        /*"      *   AUTHOR ........ FREDERICO J FONSECA.                         *      */
        /*"      *                                                                *      */
        /*"      *   DATA .......... 20/11/2003                                   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                  A L T E R A C O E S                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.03  *VERSAO V.03-DEMANDA 281754-KINKAS 29/03/2021-ESTIPULANTE FENAE  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 02 - HIST 181.577                                     *      */
        /*"      *             - PREPARAR PROGRAMA PARA PROCESSAMENTO DA JV1      *      */
        /*"      *                                                                *      */
        /*"      *   EM 24/01/2019 - HUSNI ALI HUSNI                              *      */
        /*"      *                                       PROCURE POR JV101        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 001 - MANOEL MESSIAS - 06/05/2004     (PROCURE POR MM0504)            */
        /*"      *                                                                *      */
        /*"      *    INCLUIDAS AS APOLICES 109300000566 E 109300000680 NO CURSOR *      */
        /*"      * PRINCIPAL.                                                     *      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  AREA-WORK.*/
        public VP0118B_AREA_WORK AREA_WORK { get; set; } = new VP0118B_AREA_WORK();
        public class VP0118B_AREA_WORK : VarBasis
        {
            /*"    05 V0SIST-DTMOVABE            PIC  X(10).*/
            public StringBasis V0SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 V0MOVF-NRCERTIF            PIC S9(15)    COMP-3.*/
            public IntBasis V0MOVF_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
            /*"    05 V0TITF-NRCERTIF            PIC S9(15)    COMP-3.*/
            public IntBasis V0TITF_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
            /*"    05 V0COMU-NRCERTIF            PIC S9(15)    COMP-3.*/
            public IntBasis V0COMU_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
            /*"    05 V0PROP-NRCERTIF            PIC S9(15)    COMP-3.*/
            public IntBasis V0PROP_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
            /*"    05 V0PROP-OCORHIST            PIC S9(04)    COMP.*/
            public IntBasis V0PROP_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 V0PROP-CODSUBES            PIC S9(04)    COMP.*/
            public IntBasis V0PROP_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 V0PROP-CODPRODU            PIC S9(04)    COMP.*/
            public IntBasis V0PROP_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 V0PROP-CODCLIEN            PIC S9(09)    COMP.*/
            public IntBasis V0PROP_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"    05 V0PROP-APOLICE             PIC S9(13)    COMP-3.*/
            public IntBasis V0PROP_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
            /*"    05 V0RELA-NUM-APOLICE         PIC S9(13)    COMP-3.*/
            public IntBasis V0RELA_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
            /*"    05 HOST-DTINIVIG-PARM         PIC X(10).*/
            public StringBasis HOST_DTINIVIG_PARM { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 HOST-DTINIVIG-1DAY         PIC X(10).*/
            public StringBasis HOST_DTINIVIG_1DAY { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 HOST-DTINIVIG              PIC X(10).*/
            public StringBasis HOST_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 HOST-DTTERVIG              PIC X(10).*/
            public StringBasis HOST_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 V0CDGC-VLCUSTCDG           PIC S9(13)V99 COMP-3.*/
            public DoubleBasis V0CDGC_VLCUSTCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 V0CDGC-DTINIVIG            PIC  X(10).*/
            public StringBasis V0CDGC_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 V0CDGC-DTTERVIG            PIC  X(10).*/
            public StringBasis V0CDGC_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 HOST-IMPSEGCDC             PIC S9(13)V99 COMP-3.*/
            public DoubleBasis HOST_IMPSEGCDC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 HOST-VLCUSTCDG             PIC S9(13)V99 COMP-3.*/
            public DoubleBasis HOST_VLCUSTCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 HOST-IMPSEGCDC-NEW         PIC S9(13)V99 COMP-3.*/
            public DoubleBasis HOST_IMPSEGCDC_NEW { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 HOST-IMPMORNATU            PIC S9(13)V99 COMP-3.*/
            public DoubleBasis HOST_IMPMORNATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 HOST-OCORHIST              PIC S9(04)    COMP.*/
            public IntBasis HOST_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 V0PARC-COUNT               PIC S9(09)    COMP.*/
            public IntBasis V0PARC_COUNT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"    05 WS-EOF                     PIC 9(001) VALUE 0.*/
            public IntBasis WS_EOF { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05 WS-EOF-COB                 PIC 9(001) VALUE 0.*/
            public IntBasis WS_EOF_COB { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05 AC-LIDOS                   PIC  9(07) VALUE ZEROES.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
            /*"    05 AC-LIDOS-COB               PIC  9(07) VALUE ZEROES.*/
            public IntBasis AC_LIDOS_COB { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
            /*"    05 AC-SORT-APROP              PIC  9(07) VALUE ZEROES.*/
            public IntBasis AC_SORT_APROP { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
            /*"    05 AC-PARC-PAGA               PIC  9(07) VALUE ZEROES.*/
            public IntBasis AC_PARC_PAGA { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
            /*"    05 AC-SORT-DISPO              PIC  9(07) VALUE ZEROES.*/
            public IntBasis AC_SORT_DISPO { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
            /*"    05 AC-SORT-POSSUI             PIC  9(07) VALUE ZEROES.*/
            public IntBasis AC_SORT_POSSUI { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
            /*"    05        DATA-SQL.*/
            public VP0118B_DATA_SQL DATA_SQL { get; set; } = new VP0118B_DATA_SQL();
            public class VP0118B_DATA_SQL : VarBasis
            {
                /*"      10      ANO-SQL             PIC  9(004).*/
                public IntBasis ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      TR01-SQL            PIC  X(001).*/
                public StringBasis TR01_SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      MES-SQL             PIC  9(002).*/
                public IntBasis MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      TR02-SQL            PIC  X(001).*/
                public StringBasis TR02_SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      DIA-SQL             PIC  9(002).*/
                public IntBasis DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05        WHORA-CURR.*/
            }
            public VP0118B_WHORA_CURR WHORA_CURR { get; set; } = new VP0118B_WHORA_CURR();
            public class VP0118B_WHORA_CURR : VarBasis
            {
                /*"      10      WHORA-HH-CURR       PIC  9(002).*/
                public IntBasis WHORA_HH_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      WHORA-MM-CURR       PIC  9(002).*/
                public IntBasis WHORA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      WHORA-SS-CURR       PIC  9(002).*/
                public IntBasis WHORA_SS_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      WHORA-CC-CURR       PIC  9(002).*/
                public IntBasis WHORA_CC_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05        WS-TIME             PIC  X(008).*/
            }
            public StringBasis WS_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05        WS-TIME-R           REDEFINES WS-TIME.*/
            private _REDEF_VP0118B_WS_TIME_R _ws_time_r { get; set; }
            public _REDEF_VP0118B_WS_TIME_R WS_TIME_R
            {
                get { _ws_time_r = new _REDEF_VP0118B_WS_TIME_R(); _.Move(WS_TIME, _ws_time_r); VarBasis.RedefinePassValue(WS_TIME, _ws_time_r, WS_TIME); _ws_time_r.ValueChanged += () => { _.Move(_ws_time_r, WS_TIME); }; return _ws_time_r; }
                set { VarBasis.RedefinePassValue(value, _ws_time_r, WS_TIME); }
            }  //Redefines
            public class _REDEF_VP0118B_WS_TIME_R : VarBasis
            {
                /*"      10      WS-HOR              PIC  9(002).*/
                public IntBasis WS_HOR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      WS-MIN              PIC  9(002).*/
                public IntBasis WS_MIN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      WS-SEG              PIC  9(002).*/
                public IntBasis WS_SEG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  9(002).*/
                public IntBasis FILLER_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05        WABEND.*/
                public VP0118B_WABEND WABEND { get; set; } = new VP0118B_WABEND();
                public class VP0118B_WABEND : VarBasis
                {
                    /*"    10      FILLER              PIC  X(010) VALUE           ' VA0184B'.*/
                }

                public _REDEF_VP0118B_WS_TIME_R()
                {
                    WS_HOR.ValueChanged += OnValueChanged;
                    WS_MIN.ValueChanged += OnValueChanged;
                    WS_SEG.ValueChanged += OnValueChanged;
                    FILLER_0.ValueChanged += OnValueChanged;
                    WABEND.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VA0184B");
            /*"    10      FILLER              PIC  X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"    10      WNR-EXEC-SQL        PIC  X(004) VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"    10      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
        }


        public VP0118B_CPROPOS CPROPOS { get; set; } = new VP0118B_CPROPOS();
        public VP0118B_CCOB CCOB { get; set; } = new VP0118B_CCOB();
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
            /*" -125- DISPLAY ' ' */
            _.Display($" ");

            /*" -127- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -135- DISPLAY 'PROGRAMA EM EXECUCAO VP0118B-' 'VERSAO V.03- DEMANDA 281754 - ' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) '-' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) */

            $"PROGRAMA EM EXECUCAO VP0118B-VERSAO V.03- DEMANDA 281754 - FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)}-FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}"
            .Display();

            /*" -137- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -139- DISPLAY '                               ' */
            _.Display($"                               ");

            /*" -141- MOVE '001' TO WNR-EXEC-SQL. */
            _.Move("001", AREA_WORK.WNR_EXEC_SQL);

            /*" -146- PERFORM R0000_00_PRINCIPAL_DB_SELECT_1 */

            R0000_00_PRINCIPAL_DB_SELECT_1();

            /*" -149- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -150- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -152- END-IF */
            }


            /*" -154- ACCEPT WHORA-CURR FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_WORK.WHORA_CURR);

            /*" -156- MOVE '002' TO WNR-EXEC-SQL. */
            _.Move("002", AREA_WORK.WNR_EXEC_SQL);

            /*" -166- PERFORM R0000_00_PRINCIPAL_DB_DECLARE_1 */

            R0000_00_PRINCIPAL_DB_DECLARE_1();

            /*" -169- MOVE '006' TO WNR-EXEC-SQL. */
            _.Move("006", AREA_WORK.WNR_EXEC_SQL);

            /*" -169- PERFORM R0000_00_PRINCIPAL_DB_OPEN_1 */

            R0000_00_PRINCIPAL_DB_OPEN_1();

            /*" -172- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -173- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -175- END-IF */
            }


            /*" -177- PERFORM R0110-00-FETCH. */

            R0110_00_FETCH_SECTION();

            /*" -178- IF WS-EOF = 1 */

            if (AREA_WORK.WS_EOF == 1)
            {

                /*" -180- DISPLAY '*** VP0118B *** NENHUM REGISTRO SELECIONADO' ' PRODUTO EXCLUSIVO ' */
                _.Display($"*** VP0118B *** NENHUM REGISTRO SELECIONADO PRODUTO EXCLUSIVO ");

                /*" -181- GO TO R0000-00-TERMINO-NORMAL */

                R0000_00_TERMINO_NORMAL(); //GOTO
                return;

                /*" -183- END-IF */
            }


            /*" -185- MOVE '004' TO WNR-EXEC-SQL. */
            _.Move("004", AREA_WORK.WNR_EXEC_SQL);

            /*" -186- PERFORM R0100-00-GERA-MOVIMENTO UNTIL WS-EOF = 1. */

            while (!(AREA_WORK.WS_EOF == 1))
            {

                R0100_00_GERA_MOVIMENTO_SECTION();
            }

            /*" -0- FLUXCONTROL_PERFORM R0000_00_TERMINO_NORMAL */

            R0000_00_TERMINO_NORMAL();

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-SELECT-1 */
        public void R0000_00_PRINCIPAL_DB_SELECT_1()
        {
            /*" -146- EXEC SQL SELECT CURRENT DATE INTO :V0SIST-DTMOVABE FROM SEGUROS.V0SISTEMA WHERE IDSISTEM = 'VP' END-EXEC. */

            var r0000_00_PRINCIPAL_DB_SELECT_1_Query1 = new R0000_00_PRINCIPAL_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0000_00_PRINCIPAL_DB_SELECT_1_Query1.Execute(r0000_00_PRINCIPAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SIST_DTMOVABE, AREA_WORK.V0SIST_DTMOVABE);
            }


        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-DECLARE-1 */
        public void R0000_00_PRINCIPAL_DB_DECLARE_1()
        {
            /*" -166- EXEC SQL DECLARE CPROPOS CURSOR WITH HOLD FOR SELECT NRCERTIF, OCORHIST, CODCLIEN, NUM_APOLICE FROM SEGUROS.V0PROPOSTAVA WHERE SITUACAO IN ( '3' , '6' ) AND NUM_APOLICE IN ( 109300000559, 109300000566, 109300000680, 3009300000559, 3009300001559 ) WITH UR END-EXEC. */
            CPROPOS = new VP0118B_CPROPOS(false);
            string GetQuery_CPROPOS()
            {
                var query = @$"SELECT NRCERTIF
							, OCORHIST
							, CODCLIEN
							, NUM_APOLICE 
							FROM SEGUROS.V0PROPOSTAVA 
							WHERE SITUACAO IN ( '3'
							, '6' ) 
							AND NUM_APOLICE IN ( 109300000559
							, 109300000566
							, 
							109300000680
							, 
							3009300000559
							, 
							3009300001559 )";

                return query;
            }
            CPROPOS.GetQueryEvent += GetQuery_CPROPOS;

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-OPEN-1 */
        public void R0000_00_PRINCIPAL_DB_OPEN_1()
        {
            /*" -169- EXEC SQL OPEN CPROPOS END-EXEC. */

            CPROPOS.Open();

        }

        [StopWatch]
        /*" R0100-00-GERA-MOVIMENTO-DB-DECLARE-1 */
        public void R0100_00_GERA_MOVIMENTO_DB_DECLARE_1()
        {
            /*" -249- EXEC SQL DECLARE CCOB CURSOR FOR SELECT IMPSEGCDC, IMPMORNATU, OCORHIST, DTINIVIG, DTTERVIG, VLCUSTCDG, DTINIVIG - 1 DAY FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND DTINIVIG >= :HOST-DTINIVIG-PARM ORDER BY DTINIVIG END-EXEC. */
            CCOB = new VP0118B_CCOB(true);
            string GetQuery_CCOB()
            {
                var query = @$"SELECT IMPSEGCDC
							, IMPMORNATU
							, OCORHIST
							, 
							DTINIVIG
							, DTTERVIG
							, VLCUSTCDG
							, 
							DTINIVIG - 1 DAY 
							FROM SEGUROS.V0COBERPROPVA 
							WHERE NRCERTIF = '{AREA_WORK.V0PROP_NRCERTIF}' 
							AND DTINIVIG >= '{AREA_WORK.HOST_DTINIVIG_PARM}' 
							ORDER BY DTINIVIG";

                return query;
            }
            CCOB.GetQueryEvent += GetQuery_CCOB;

        }

        [StopWatch]
        /*" R0000-00-TERMINO-NORMAL */
        private void R0000_00_TERMINO_NORMAL(bool isPerform = false)
        {
            /*" -192- MOVE '008' TO WNR-EXEC-SQL. */
            _.Move("008", AREA_WORK.WNR_EXEC_SQL);

            /*" -192- PERFORM R0000_00_TERMINO_NORMAL_DB_CLOSE_1 */

            R0000_00_TERMINO_NORMAL_DB_CLOSE_1();

            /*" -195- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -196- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -198- END-IF */
            }


            /*" -200- MOVE '022' TO WNR-EXEC-SQL. */
            _.Move("022", AREA_WORK.WNR_EXEC_SQL);

            /*" -200- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -203- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -204- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -206- END-IF */
            }


            /*" -207- DISPLAY ' ' . */
            _.Display($" ");

            /*" -208- DISPLAY '*** VP0118B ******************' */
            _.Display($"*** VP0118B ******************");

            /*" -209- DISPLAY ' ' . */
            _.Display($" ");

            /*" -210- DISPLAY '*** PROPOSTAS  LIDAS         ' AC-LIDOS. */
            _.Display($"*** PROPOSTAS  LIDAS         {AREA_WORK.AC_LIDOS}");

            /*" -211- DISPLAY '*** COBERTURAS LIDAS         ' AC-LIDOS-COB. */
            _.Display($"*** COBERTURAS LIDAS         {AREA_WORK.AC_LIDOS_COB}");

            /*" -212- DISPLAY ' ' . */
            _.Display($" ");

            /*" -213- DISPLAY '*** VP0118B ******************' */
            _.Display($"*** VP0118B ******************");

            /*" -214- DISPLAY '*** VP0118B - FIM NORMAL   ***' */
            _.Display($"*** VP0118B - FIM NORMAL   ***");

            /*" -216- DISPLAY ' ' . */
            _.Display($" ");

            /*" -218- MOVE ZEROES TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -218- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0000-00-TERMINO-NORMAL-DB-CLOSE-1 */
        public void R0000_00_TERMINO_NORMAL_DB_CLOSE_1()
        {
            /*" -192- EXEC SQL CLOSE CPROPOS END-EXEC. */

            CPROPOS.Close();

        }

        [StopWatch]
        /*" R0100-00-GERA-MOVIMENTO-SECTION */
        private void R0100_00_GERA_MOVIMENTO_SECTION()
        {
            /*" -226- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", AREA_WORK.WNR_EXEC_SQL);

            /*" -228- MOVE ZEROS TO WS-EOF-COB. */
            _.Move(0, AREA_WORK.WS_EOF_COB);

            /*" -230- IF V0PROP-APOLICE EQUAL 109300000559 OR 3009300000559 OR 3009300001559 */

            if (AREA_WORK.V0PROP_APOLICE.In("109300000559", "3009300000559", "3009300001559"))
            {

                /*" -231- MOVE '2003-07-01' TO HOST-DTINIVIG-PARM */
                _.Move("2003-07-01", AREA_WORK.HOST_DTINIVIG_PARM);

                /*" -233- END-IF */
            }


            /*" -234- IF V0PROP-APOLICE EQUAL 109300000566 */

            if (AREA_WORK.V0PROP_APOLICE == 109300000566)
            {

                /*" -235- MOVE '2003-12-01' TO HOST-DTINIVIG-PARM */
                _.Move("2003-12-01", AREA_WORK.HOST_DTINIVIG_PARM);

                /*" -237- END-IF */
            }


            /*" -238- IF V0PROP-APOLICE EQUAL 109300000680 */

            if (AREA_WORK.V0PROP_APOLICE == 109300000680)
            {

                /*" -239- MOVE '2004-03-01' TO HOST-DTINIVIG-PARM */
                _.Move("2004-03-01", AREA_WORK.HOST_DTINIVIG_PARM);

                /*" -241- END-IF */
            }


            /*" -249- PERFORM R0100_00_GERA_MOVIMENTO_DB_DECLARE_1 */

            R0100_00_GERA_MOVIMENTO_DB_DECLARE_1();

            /*" -252- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -253- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -255- END-IF */
            }


            /*" -255- PERFORM R0100_00_GERA_MOVIMENTO_DB_OPEN_1 */

            R0100_00_GERA_MOVIMENTO_DB_OPEN_1();

            /*" -258- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -259- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -261- END-IF */
            }


            /*" -263- PERFORM R0101-00-FETCH. */

            R0101_00_FETCH_SECTION();

            /*" -266- PERFORM R0130-00-ATUALIZA-COBERTURA UNTIL WS-EOF-COB = 1. */

            while (!(AREA_WORK.WS_EOF_COB == 1))
            {

                R0130_00_ATUALIZA_COBERTURA_SECTION();
            }

            /*" -268- MOVE '199' TO WNR-EXEC-SQL. */
            _.Move("199", AREA_WORK.WNR_EXEC_SQL);

            /*" -268- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -271- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -272- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -273- END-IF */
            }


            /*" -273- . */

            /*" -0- FLUXCONTROL_PERFORM R0100_10_NEXT */

            R0100_10_NEXT();

        }

        [StopWatch]
        /*" R0100-00-GERA-MOVIMENTO-DB-OPEN-1 */
        public void R0100_00_GERA_MOVIMENTO_DB_OPEN_1()
        {
            /*" -255- EXEC SQL OPEN CCOB END-EXEC. */

            CCOB.Open();

        }

        [StopWatch]
        /*" R0100-10-NEXT */
        private void R0100_10_NEXT(bool isPerform = false)
        {
            /*" -276- PERFORM R0110-00-FETCH. */

            R0110_00_FETCH_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0101-00-FETCH-SECTION */
        private void R0101_00_FETCH_SECTION()
        {
            /*" -286- MOVE '10A' TO WNR-EXEC-SQL. */
            _.Move("10A", AREA_WORK.WNR_EXEC_SQL);

            /*" -295- PERFORM R0101_00_FETCH_DB_FETCH_1 */

            R0101_00_FETCH_DB_FETCH_1();

            /*" -298- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -299- MOVE 1 TO WS-EOF-COB */
                _.Move(1, AREA_WORK.WS_EOF_COB);

                /*" -299- PERFORM R0101_00_FETCH_DB_CLOSE_1 */

                R0101_00_FETCH_DB_CLOSE_1();

                /*" -301- GO TO R0101-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0101_99_SAIDA*/ //GOTO
                return;

                /*" -303- END-IF */
            }


            /*" -303- ADD 1 TO AC-LIDOS-COB. */
            AREA_WORK.AC_LIDOS_COB.Value = AREA_WORK.AC_LIDOS_COB + 1;

        }

        [StopWatch]
        /*" R0101-00-FETCH-DB-FETCH-1 */
        public void R0101_00_FETCH_DB_FETCH_1()
        {
            /*" -295- EXEC SQL FETCH CCOB INTO :HOST-IMPSEGCDC, :HOST-IMPMORNATU, :HOST-OCORHIST, :HOST-DTINIVIG, :HOST-DTTERVIG, :HOST-VLCUSTCDG, :HOST-DTINIVIG-1DAY END-EXEC. */

            if (CCOB.Fetch())
            {
                _.Move(CCOB.HOST_IMPSEGCDC, AREA_WORK.HOST_IMPSEGCDC);
                _.Move(CCOB.HOST_IMPMORNATU, AREA_WORK.HOST_IMPMORNATU);
                _.Move(CCOB.HOST_OCORHIST, AREA_WORK.HOST_OCORHIST);
                _.Move(CCOB.HOST_DTINIVIG, AREA_WORK.HOST_DTINIVIG);
                _.Move(CCOB.HOST_DTTERVIG, AREA_WORK.HOST_DTTERVIG);
                _.Move(CCOB.HOST_VLCUSTCDG, AREA_WORK.HOST_VLCUSTCDG);
                _.Move(CCOB.HOST_DTINIVIG_1DAY, AREA_WORK.HOST_DTINIVIG_1DAY);
            }

        }

        [StopWatch]
        /*" R0101-00-FETCH-DB-CLOSE-1 */
        public void R0101_00_FETCH_DB_CLOSE_1()
        {
            /*" -299- EXEC SQL CLOSE CCOB END-EXEC */

            CCOB.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0101_99_SAIDA*/

        [StopWatch]
        /*" R0110-00-FETCH-SECTION */
        private void R0110_00_FETCH_SECTION()
        {
            /*" -313- MOVE '110' TO WNR-EXEC-SQL. */
            _.Move("110", AREA_WORK.WNR_EXEC_SQL);

            /*" -319- PERFORM R0110_00_FETCH_DB_FETCH_1 */

            R0110_00_FETCH_DB_FETCH_1();

            /*" -322- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -323- MOVE 1 TO WS-EOF */
                _.Move(1, AREA_WORK.WS_EOF);

                /*" -324- GO TO R0110-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0110_99_SAIDA*/ //GOTO
                return;

                /*" -326- END-IF */
            }


            /*" -326- ADD 1 TO AC-LIDOS. */
            AREA_WORK.AC_LIDOS.Value = AREA_WORK.AC_LIDOS + 1;

        }

        [StopWatch]
        /*" R0110-00-FETCH-DB-FETCH-1 */
        public void R0110_00_FETCH_DB_FETCH_1()
        {
            /*" -319- EXEC SQL FETCH CPROPOS INTO :V0PROP-NRCERTIF, :V0PROP-OCORHIST, :V0PROP-CODCLIEN, :V0PROP-APOLICE END-EXEC. */

            if (CPROPOS.Fetch())
            {
                _.Move(CPROPOS.V0PROP_NRCERTIF, AREA_WORK.V0PROP_NRCERTIF);
                _.Move(CPROPOS.V0PROP_OCORHIST, AREA_WORK.V0PROP_OCORHIST);
                _.Move(CPROPOS.V0PROP_CODCLIEN, AREA_WORK.V0PROP_CODCLIEN);
                _.Move(CPROPOS.V0PROP_APOLICE, AREA_WORK.V0PROP_APOLICE);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0110_99_SAIDA*/

        [StopWatch]
        /*" R0130-00-ATUALIZA-COBERTURA-SECTION */
        private void R0130_00_ATUALIZA_COBERTURA_SECTION()
        {
            /*" -336- MOVE '130' TO WNR-EXEC-SQL. */
            _.Move("130", AREA_WORK.WNR_EXEC_SQL);

            /*" -337- IF HOST-IMPSEGCDC EQUAL ZEROS */

            if (AREA_WORK.HOST_IMPSEGCDC == 00)
            {

                /*" -338- GO TO R0130-10-NEXT */

                R0130_10_NEXT(); //GOTO
                return;

                /*" -340- END-IF */
            }


            /*" -342- COMPUTE HOST-IMPSEGCDC-NEW ROUNDED = HOST-IMPMORNATU * 0,30. */
            AREA_WORK.HOST_IMPSEGCDC_NEW.Value = AREA_WORK.HOST_IMPMORNATU * 0.30;

            /*" -343- IF HOST-IMPSEGCDC-NEW GREATER 60000,00 */

            if (AREA_WORK.HOST_IMPSEGCDC_NEW > 60000.00)
            {

                /*" -344- MOVE 60000,00 TO HOST-IMPSEGCDC-NEW */
                _.Move(60000.00, AREA_WORK.HOST_IMPSEGCDC_NEW);

                /*" -346- END-IF */
            }


            /*" -347- IF HOST-IMPSEGCDC-NEW LESS 20000,00 */

            if (AREA_WORK.HOST_IMPSEGCDC_NEW < 20000.00)
            {

                /*" -348- MOVE 20000,00 TO HOST-IMPSEGCDC-NEW */
                _.Move(20000.00, AREA_WORK.HOST_IMPSEGCDC_NEW);

                /*" -350- END-IF */
            }


            /*" -351- IF HOST-IMPSEGCDC EQUAL HOST-IMPSEGCDC-NEW */

            if (AREA_WORK.HOST_IMPSEGCDC == AREA_WORK.HOST_IMPSEGCDC_NEW)
            {

                /*" -352- GO TO R0130-10-NEXT */

                R0130_10_NEXT(); //GOTO
                return;

                /*" -354- END-IF */
            }


            /*" -356- MOVE '131' TO WNR-EXEC-SQL. */
            _.Move("131", AREA_WORK.WNR_EXEC_SQL);

            /*" -362- PERFORM R0130_00_ATUALIZA_COBERTURA_DB_UPDATE_1 */

            R0130_00_ATUALIZA_COBERTURA_DB_UPDATE_1();

            /*" -365- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -366- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -369- END-IF */
            }


            /*" -369- . */

            /*" -0- FLUXCONTROL_PERFORM R0130_10_NEXT */

            R0130_10_NEXT();

        }

        [StopWatch]
        /*" R0130-00-ATUALIZA-COBERTURA-DB-UPDATE-1 */
        public void R0130_00_ATUALIZA_COBERTURA_DB_UPDATE_1()
        {
            /*" -362- EXEC SQL UPDATE SEGUROS.V0COBERPROPVA SET IMPSEGCDC = :HOST-IMPSEGCDC-NEW WHERE NRCERTIF = :V0PROP-NRCERTIF AND OCORHIST = :HOST-OCORHIST END-EXEC. */

            var r0130_00_ATUALIZA_COBERTURA_DB_UPDATE_1_Update1 = new R0130_00_ATUALIZA_COBERTURA_DB_UPDATE_1_Update1()
            {
                HOST_IMPSEGCDC_NEW = AREA_WORK.HOST_IMPSEGCDC_NEW.ToString(),
                V0PROP_NRCERTIF = AREA_WORK.V0PROP_NRCERTIF.ToString(),
                HOST_OCORHIST = AREA_WORK.HOST_OCORHIST.ToString(),
            };

            R0130_00_ATUALIZA_COBERTURA_DB_UPDATE_1_Update1.Execute(r0130_00_ATUALIZA_COBERTURA_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R0130-10-NEXT */
        private void R0130_10_NEXT(bool isPerform = false)
        {
            /*" -371- PERFORM R0101-00-FETCH. */

            R0101_00_FETCH_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0130_99_SAIDA*/

        [StopWatch]
        /*" R0800-00-VERIFICA-CDG-SECTION */
        private void R0800_00_VERIFICA_CDG_SECTION()
        {
            /*" -381- MOVE '800' TO WNR-EXEC-SQL. */
            _.Move("800", AREA_WORK.WNR_EXEC_SQL);

            /*" -392- PERFORM R0800_00_VERIFICA_CDG_DB_SELECT_1 */

            R0800_00_VERIFICA_CDG_DB_SELECT_1();

            /*" -395- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -396- IF V0CDGC-DTINIVIG GREATER HOST-DTINIVIG */

                if (AREA_WORK.V0CDGC_DTINIVIG > AREA_WORK.HOST_DTINIVIG)
                {

                    /*" -397- GO TO R0800-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/ //GOTO
                    return;

                    /*" -398- ELSE */
                }
                else
                {


                    /*" -399- IF V0CDGC-DTINIVIG LESS HOST-DTINIVIG */

                    if (AREA_WORK.V0CDGC_DTINIVIG < AREA_WORK.HOST_DTINIVIG)
                    {

                        /*" -400- PERFORM R0810-00-UPDATE-CDG-VIG */

                        R0810_00_UPDATE_CDG_VIG_SECTION();

                        /*" -401- PERFORM R0820-00-INSERT-CDG */

                        R0820_00_INSERT_CDG_SECTION();

                        /*" -402- ELSE */
                    }
                    else
                    {


                        /*" -403- PERFORM R0830-00-UPDATE-IMPSEGCDG */

                        R0830_00_UPDATE_IMPSEGCDG_SECTION();

                        /*" -404- END-IF */
                    }


                    /*" -405- END-IF */
                }


                /*" -406- ELSE */
            }
            else
            {


                /*" -407- PERFORM R0820-00-INSERT-CDG */

                R0820_00_INSERT_CDG_SECTION();

                /*" -408- END-IF */
            }


            /*" -408- . */

        }

        [StopWatch]
        /*" R0800-00-VERIFICA-CDG-DB-SELECT-1 */
        public void R0800_00_VERIFICA_CDG_DB_SELECT_1()
        {
            /*" -392- EXEC SQL SELECT VLCUSTCDG, DTINIVIG, DTTERVIG INTO :V0CDGC-VLCUSTCDG, :V0CDGC-DTINIVIG, :V0CDGC-DTTERVIG FROM SEGUROS.V0CDGCOBER WHERE CODCLIEN = :V0PROP-CODCLIEN AND DTINIVIG <= :HOST-DTINIVIG AND DTTERVIG >= :HOST-DTINIVIG END-EXEC. */

            var r0800_00_VERIFICA_CDG_DB_SELECT_1_Query1 = new R0800_00_VERIFICA_CDG_DB_SELECT_1_Query1()
            {
                V0PROP_CODCLIEN = AREA_WORK.V0PROP_CODCLIEN.ToString(),
                HOST_DTINIVIG = AREA_WORK.HOST_DTINIVIG.ToString(),
            };

            var executed_1 = R0800_00_VERIFICA_CDG_DB_SELECT_1_Query1.Execute(r0800_00_VERIFICA_CDG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CDGC_VLCUSTCDG, AREA_WORK.V0CDGC_VLCUSTCDG);
                _.Move(executed_1.V0CDGC_DTINIVIG, AREA_WORK.V0CDGC_DTINIVIG);
                _.Move(executed_1.V0CDGC_DTTERVIG, AREA_WORK.V0CDGC_DTTERVIG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/

        [StopWatch]
        /*" R0810-00-UPDATE-CDG-VIG-SECTION */
        private void R0810_00_UPDATE_CDG_VIG_SECTION()
        {
            /*" -417- MOVE '810' TO WNR-EXEC-SQL. */
            _.Move("810", AREA_WORK.WNR_EXEC_SQL);

            /*" -426- PERFORM R0810_00_UPDATE_CDG_VIG_DB_UPDATE_1 */

            R0810_00_UPDATE_CDG_VIG_DB_UPDATE_1();

            /*" -429- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -430- DISPLAY ' ERRO UPDATE CDGCOBER ' */
                _.Display($" ERRO UPDATE CDGCOBER ");

                /*" -431- DISPLAY ' CODCLIEN ' V0PROP-CODCLIEN */
                _.Display($" CODCLIEN {AREA_WORK.V0PROP_CODCLIEN}");

                /*" -432- DISPLAY ' DTINIVIG ' HOST-DTINIVIG */
                _.Display($" DTINIVIG {AREA_WORK.HOST_DTINIVIG}");

                /*" -433- DISPLAY ' DTTERVIG ' HOST-DTINIVIG */
                _.Display($" DTTERVIG {AREA_WORK.HOST_DTINIVIG}");

                /*" -434- DISPLAY ' DTTER-UP ' HOST-DTINIVIG-1DAY */
                _.Display($" DTTER-UP {AREA_WORK.HOST_DTINIVIG_1DAY}");

                /*" -435- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -436- END-IF */
            }


            /*" -436- . */

        }

        [StopWatch]
        /*" R0810-00-UPDATE-CDG-VIG-DB-UPDATE-1 */
        public void R0810_00_UPDATE_CDG_VIG_DB_UPDATE_1()
        {
            /*" -426- EXEC SQL UPDATE SEGUROS.V0CDGCOBER SET DTTERVIG = :HOST-DTINIVIG-1DAY WHERE CODCLIEN = :V0PROP-CODCLIEN AND DTINIVIG <= :HOST-DTINIVIG AND DTTERVIG >= :HOST-DTINIVIG END-EXEC. */

            var r0810_00_UPDATE_CDG_VIG_DB_UPDATE_1_Update1 = new R0810_00_UPDATE_CDG_VIG_DB_UPDATE_1_Update1()
            {
                HOST_DTINIVIG_1DAY = AREA_WORK.HOST_DTINIVIG_1DAY.ToString(),
                V0PROP_CODCLIEN = AREA_WORK.V0PROP_CODCLIEN.ToString(),
                HOST_DTINIVIG = AREA_WORK.HOST_DTINIVIG.ToString(),
            };

            R0810_00_UPDATE_CDG_VIG_DB_UPDATE_1_Update1.Execute(r0810_00_UPDATE_CDG_VIG_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0810_99_SAIDA*/

        [StopWatch]
        /*" R0820-00-INSERT-CDG-SECTION */
        private void R0820_00_INSERT_CDG_SECTION()
        {
            /*" -445- MOVE '820' TO WNR-EXEC-SQL. */
            _.Move("820", AREA_WORK.WNR_EXEC_SQL);

            /*" -457- PERFORM R0820_00_INSERT_CDG_DB_INSERT_1 */

            R0820_00_INSERT_CDG_DB_INSERT_1();

            /*" -460- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -461- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -462- END-IF */
            }


            /*" -462- . */

        }

        [StopWatch]
        /*" R0820-00-INSERT-CDG-DB-INSERT-1 */
        public void R0820_00_INSERT_CDG_DB_INSERT_1()
        {
            /*" -457- EXEC SQL INSERT INTO SEGUROS.V0CDGCOBER VALUES (:V0PROP-CODCLIEN, :HOST-DTINIVIG, :HOST-DTTERVIG, :HOST-IMPSEGCDC-NEW, :HOST-VLCUSTCDG, :V0PROP-NRCERTIF, :HOST-OCORHIST, '0' , 'VP0118B' , CURRENT TIMESTAMP) END-EXEC. */

            var r0820_00_INSERT_CDG_DB_INSERT_1_Insert1 = new R0820_00_INSERT_CDG_DB_INSERT_1_Insert1()
            {
                V0PROP_CODCLIEN = AREA_WORK.V0PROP_CODCLIEN.ToString(),
                HOST_DTINIVIG = AREA_WORK.HOST_DTINIVIG.ToString(),
                HOST_DTTERVIG = AREA_WORK.HOST_DTTERVIG.ToString(),
                HOST_IMPSEGCDC_NEW = AREA_WORK.HOST_IMPSEGCDC_NEW.ToString(),
                HOST_VLCUSTCDG = AREA_WORK.HOST_VLCUSTCDG.ToString(),
                V0PROP_NRCERTIF = AREA_WORK.V0PROP_NRCERTIF.ToString(),
                HOST_OCORHIST = AREA_WORK.HOST_OCORHIST.ToString(),
            };

            R0820_00_INSERT_CDG_DB_INSERT_1_Insert1.Execute(r0820_00_INSERT_CDG_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0820_99_SAIDA*/

        [StopWatch]
        /*" R0830-00-UPDATE-IMPSEGCDG-SECTION */
        private void R0830_00_UPDATE_IMPSEGCDG_SECTION()
        {
            /*" -471- MOVE '830' TO WNR-EXEC-SQL. */
            _.Move("830", AREA_WORK.WNR_EXEC_SQL);

            /*" -481- PERFORM R0830_00_UPDATE_IMPSEGCDG_DB_UPDATE_1 */

            R0830_00_UPDATE_IMPSEGCDG_DB_UPDATE_1();

            /*" -484- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -485- DISPLAY ' ERRO UPDATE CDGCOBER ' */
                _.Display($" ERRO UPDATE CDGCOBER ");

                /*" -486- DISPLAY ' CODCLIEN ' V0PROP-CODCLIEN */
                _.Display($" CODCLIEN {AREA_WORK.V0PROP_CODCLIEN}");

                /*" -487- DISPLAY ' DTINIVIG ' HOST-DTINIVIG */
                _.Display($" DTINIVIG {AREA_WORK.HOST_DTINIVIG}");

                /*" -488- DISPLAY ' DTTERVIG ' HOST-DTINIVIG */
                _.Display($" DTTERVIG {AREA_WORK.HOST_DTINIVIG}");

                /*" -489- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -490- END-IF */
            }


            /*" -490- . */

        }

        [StopWatch]
        /*" R0830-00-UPDATE-IMPSEGCDG-DB-UPDATE-1 */
        public void R0830_00_UPDATE_IMPSEGCDG_DB_UPDATE_1()
        {
            /*" -481- EXEC SQL UPDATE SEGUROS.V0CDGCOBER SET IMPSEGCDG = :HOST-IMPSEGCDC-NEW, VLCUSTCDG = :HOST-VLCUSTCDG WHERE CODCLIEN = :V0PROP-CODCLIEN AND DTINIVIG <= :HOST-DTINIVIG AND DTTERVIG >= :HOST-DTINIVIG END-EXEC. */

            var r0830_00_UPDATE_IMPSEGCDG_DB_UPDATE_1_Update1 = new R0830_00_UPDATE_IMPSEGCDG_DB_UPDATE_1_Update1()
            {
                HOST_IMPSEGCDC_NEW = AREA_WORK.HOST_IMPSEGCDC_NEW.ToString(),
                HOST_VLCUSTCDG = AREA_WORK.HOST_VLCUSTCDG.ToString(),
                V0PROP_CODCLIEN = AREA_WORK.V0PROP_CODCLIEN.ToString(),
                HOST_DTINIVIG = AREA_WORK.HOST_DTINIVIG.ToString(),
            };

            R0830_00_UPDATE_IMPSEGCDG_DB_UPDATE_1_Update1.Execute(r0830_00_UPDATE_IMPSEGCDG_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0830_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -497- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_WORK.WSQLCODE);

            /*" -498- DISPLAY WABEND. */
            _.Display(AREA_WORK.WS_TIME_R.WABEND);

            /*" -499- DISPLAY 'SQLERRMC=<' SQLERRMC '>' */

            $"SQLERRMC=<{DB.SQLERRMC}>"
            .Display();

            /*" -500- DISPLAY ' ' . */
            _.Display($" ");

            /*" -502- DISPLAY 'CERTIFICADO ' V0PROP-NRCERTIF */
            _.Display($"CERTIFICADO {AREA_WORK.V0PROP_NRCERTIF}");

            /*" -503- MOVE '999' TO WNR-EXEC-SQL. */
            _.Move("999", AREA_WORK.WNR_EXEC_SQL);

            /*" -503- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -505- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -508- DISPLAY '*** VP0118B *** TERMINO ANORMAL' . */
            _.Display($"*** VP0118B *** TERMINO ANORMAL");

            /*" -509- MOVE 8 TO RETURN-CODE. */
            _.Move(8, RETURN_CODE);

            /*" -509- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}