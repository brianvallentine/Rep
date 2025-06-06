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
using Sias.Geral.DB2.GE0006S;

namespace Code
{
    public class GE0006S
    {
        public bool IsCall { get; set; }

        public GE0006S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"01  SISTEMAS-DATA-MOV-ABERTO-1       PIC X(10).*/
        public StringBasis SISTEMAS_DATA_MOV_ABERTO_1 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  WRETORNO                         PIC  X(001) VALUE  SPACES.*/
        public StringBasis WRETORNO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01  WS-DATA-VENCIMENTO               PIC X(10).*/
        public StringBasis WS_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  WS-RESTO                         PIC 9(04).*/
        public IntBasis WS_RESTO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
        /*"01  WS-CONTA-DIA                     PIC 9(04).*/
        public IntBasis WS_CONTA_DIA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
        /*"01  ANO-TRAB                         PIC 9(04).*/
        public IntBasis ANO_TRAB { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
        /*"01  WHOST-DTTRAB                     PIC X(10).*/
        public StringBasis WHOST_DTTRAB { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  WORK-AREA.*/
        public GE0006S_WORK_AREA WORK_AREA { get; set; } = new GE0006S_WORK_AREA();
        public class GE0006S_WORK_AREA : VarBasis
        {
            /*"    05      WLINK-LINKAGE.*/
            public GE0006S_WLINK_LINKAGE WLINK_LINKAGE { get; set; } = new GE0006S_WLINK_LINKAGE();
            public class GE0006S_WLINK_LINKAGE : VarBasis
            {
                /*"      10    WLINK-INPUT.*/
                public GE0006S_WLINK_INPUT WLINK_INPUT { get; set; } = new GE0006S_WLINK_INPUT();
                public class GE0006S_WLINK_INPUT : VarBasis
                {
                    /*"        15  WLINK-DATA-DESTINO  PIC  X(010)  VALUE  SPACES.*/
                    public StringBasis WLINK_DATA_DESTINO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                    /*"        15  WLINK-QTDIAS        PIC  9(004)  VALUE  ZEROS.*/
                    public IntBasis WLINK_QTDIAS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"      10    WLINK-MENSAGEM      PIC  X(070)  VALUE  SPACES.*/
                }
                public StringBasis WLINK_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                /*"    05      DATA-SQL.*/
            }
            public GE0006S_DATA_SQL DATA_SQL { get; set; } = new GE0006S_DATA_SQL();
            public class GE0006S_DATA_SQL : VarBasis
            {
                /*"      10    ANO-SQL                  PIC  9(004).*/
                public IntBasis ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10    T1                       PIC  X(001).*/
                public StringBasis T1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10    MES-SQL                  PIC  9(002).*/
                public IntBasis MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    T2                       PIC  X(001).*/
                public StringBasis T2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10    DIA-SQL                  PIC  9(002).*/
                public IntBasis DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05      DATA-INVERTIDA           PIC  9(008).*/
            }
            public IntBasis DATA_INVERTIDA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05      DATA-AAMMDD REDEFINES DATA-INVERTIDA.*/
            private _REDEF_GE0006S_DATA_AAMMDD _data_aammdd { get; set; }
            public _REDEF_GE0006S_DATA_AAMMDD DATA_AAMMDD
            {
                get { _data_aammdd = new _REDEF_GE0006S_DATA_AAMMDD(); _.Move(DATA_INVERTIDA, _data_aammdd); VarBasis.RedefinePassValue(DATA_INVERTIDA, _data_aammdd, DATA_INVERTIDA); _data_aammdd.ValueChanged += () => { _.Move(_data_aammdd, DATA_INVERTIDA); }; return _data_aammdd; }
                set { VarBasis.RedefinePassValue(value, _data_aammdd, DATA_INVERTIDA); }
            }  //Redefines
            public class _REDEF_GE0006S_DATA_AAMMDD : VarBasis
            {
                /*"      10    ANO                      PIC  9(004).*/
                public IntBasis ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10    MES                      PIC  9(002).*/
                public IntBasis MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    DIA                      PIC  9(002).*/
                public IntBasis DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05      WABEND.*/

                public _REDEF_GE0006S_DATA_AAMMDD()
                {
                    ANO.ValueChanged += OnValueChanged;
                    MES.ValueChanged += OnValueChanged;
                    DIA.ValueChanged += OnValueChanged;
                }

            }
            public GE0006S_WABEND WABEND { get; set; } = new GE0006S_WABEND();
            public class GE0006S_WABEND : VarBasis
            {
                /*"      10    FILLER                   PIC  X(010) VALUE            'GE0006S  '.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"GE0006S  ");
                /*"      10    FILLER                   PIC  X(028) VALUE            ' *** ERRO  EXEC SQL ***'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL ***");
                /*"      10    FILLER                   PIC  X(014) VALUE            '    SQLCODE = '.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"      10    WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD1 = '.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"      10    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"      10    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    05      LOCALIZA-ABEND-1.*/
            }
            public GE0006S_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new GE0006S_LOCALIZA_ABEND_1();
            public class GE0006S_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05      LOCALIZA-ABEND-2.*/
            }
            public GE0006S_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new GE0006S_LOCALIZA_ABEND_2();
            public class GE0006S_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'COMANDO   = '.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"      10    COMANDO                  PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"01      GE0006S-LINKAGE.*/
            }
        }
        public GE0006S_GE0006S_LINKAGE GE0006S_LINKAGE { get; set; } = new GE0006S_GE0006S_LINKAGE();
        public class GE0006S_GE0006S_LINKAGE : VarBasis
        {
            /*"  05    GE0006S-DATA-DESTINO   PIC  X(010).*/
            public StringBasis GE0006S_DATA_DESTINO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05    GE0006S-QTDIAS         PIC  9(004).*/
            public IntBasis GE0006S_QTDIAS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05    GE0006S-MENSAGEM       PIC  X(070).*/
            public StringBasis GE0006S_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
        }


        public Dclgens.CALENDAR CALENDAR { get; set; } = new Dclgens.CALENDAR();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.FERIADOS FERIADOS { get; set; } = new Dclgens.FERIADOS();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(GE0006S_GE0006S_LINKAGE GE0006S_GE0006S_LINKAGE_P) //PROCEDURE DIVISION USING 
        /*GE0006S_LINKAGE*/
        {
            try
            {
                this.GE0006S_LINKAGE = GE0006S_GE0006S_LINKAGE_P;

                /*" -0- FLUXCONTROL_PERFORM R0000-PRINCIPAL */

                R0000_PRINCIPAL();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { GE0006S_LINKAGE };
            return Result;
        }

        [StopWatch]
        /*" R0000-PRINCIPAL */
        private void R0000_PRINCIPAL(bool isPerform = false)
        {
            /*" -120- MOVE 'R0001-INICIO               ' TO PARAGRAFO. */
            _.Move("R0001-INICIO               ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -120- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -121- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -122- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -126- PERFORM R0200-00-CONSISTE-PARAMETRO */

            R0200_00_CONSISTE_PARAMETRO_SECTION();

            /*" -127- IF WRETORNO EQUAL SPACES */

            if (WRETORNO.IsEmpty())
            {

                /*" -128- PERFORM R1000-00-PROCESSA-DATA */

                R1000_00_PROCESSA_DATA_SECTION();

                /*" -130- END-IF. */
            }


            /*" -134- MOVE DATA-SQL TO GE0006S-DATA-DESTINO. */
            _.Move(WORK_AREA.DATA_SQL, GE0006S_LINKAGE.GE0006S_DATA_DESTINO);

            /*" -135- IF WLINK-MENSAGEM NOT EQUAL SPACES */

            if (!WORK_AREA.WLINK_LINKAGE.WLINK_MENSAGEM.IsEmpty())
            {

                /*" -136- MOVE WLINK-MENSAGEM TO GE0006S-MENSAGEM */
                _.Move(WORK_AREA.WLINK_LINKAGE.WLINK_MENSAGEM, GE0006S_LINKAGE.GE0006S_MENSAGEM);

                /*" -138- END-IF. */
            }


            /*" -138- GOBACK. */

            throw new GoBack();

        }

        [StopWatch]
        /*" R0200-00-CONSISTE-PARAMETRO-SECTION */
        private void R0200_00_CONSISTE_PARAMETRO_SECTION()
        {
            /*" -146- MOVE 'R0200-CONSISTE-PARAMETRO' TO PARAGRAFO. */
            _.Move("R0200-CONSISTE-PARAMETRO", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -148- MOVE GE0006S-LINKAGE TO WLINK-LINKAGE. */
            _.Move(GE0006S_LINKAGE, WORK_AREA.WLINK_LINKAGE);

            /*" -149- IF WLINK-DATA-DESTINO IS NUMERIC */

            if (WORK_AREA.WLINK_LINKAGE.WLINK_INPUT.WLINK_DATA_DESTINO.IsNumeric())
            {

                /*" -150- MOVE '*' TO WRETORNO */
                _.Move("*", WRETORNO);

                /*" -151- MOVE 'DATA INVALIDA' TO WLINK-MENSAGEM */
                _.Move("DATA INVALIDA", WORK_AREA.WLINK_LINKAGE.WLINK_MENSAGEM);

                /*" -152- GO TO R0200-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/ //GOTO
                return;

                /*" -153- END-IF. */
            }


            /*" -154- IF WLINK-QTDIAS EQUAL ZEROS */

            if (WORK_AREA.WLINK_LINKAGE.WLINK_INPUT.WLINK_QTDIAS == 00)
            {

                /*" -155- MOVE '*' TO WRETORNO */
                _.Move("*", WRETORNO);

                /*" -157- MOVE 'QUANTIDADE DE DIAS ZERADO' TO WLINK-MENSAGEM */
                _.Move("QUANTIDADE DE DIAS ZERADO", WORK_AREA.WLINK_LINKAGE.WLINK_MENSAGEM);

                /*" -158- GO TO R0200-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/ //GOTO
                return;

                /*" -158- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-SOMA-DIAS-SECTION */
        private void R0300_00_SOMA_DIAS_SECTION()
        {
            /*" -170- MOVE 'R0300-00-SOMA-DIAS     ' TO PARAGRAFO */
            _.Move("R0300-00-SOMA-DIAS     ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -173- PERFORM R0400-SOMA-1-DIA */

            R0400_SOMA_1_DIA_SECTION();

            /*" -173- MOVE ZEROS TO WS-CONTA-DIA. */
            _.Move(0, WS_CONTA_DIA);

            /*" -0- FLUXCONTROL_PERFORM LOOP_CALEND */

            LOOP_CALEND();

        }

        [StopWatch]
        /*" LOOP-CALEND */
        private void LOOP_CALEND(bool isPerform = false)
        {
            /*" -180- MOVE 'LOOP-CALEND   ' TO PARAGRAFO */
            _.Move("LOOP-CALEND   ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -184- MOVE 'SELECT CALENDARIO' TO COMANDO. */
            _.Move("SELECT CALENDARIO", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -190- PERFORM LOOP_CALEND_DB_SELECT_1 */

            LOOP_CALEND_DB_SELECT_1();

            /*" -192- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -193- PERFORM R0400-SOMA-1-DIA */

                R0400_SOMA_1_DIA_SECTION();

                /*" -195- GO TO LOOP-CALEND. */
                new Task(() => LOOP_CALEND()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -199- MOVE 'SELECT FERIADOS  ' TO COMANDO. */
            _.Move("SELECT FERIADOS  ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -204- PERFORM LOOP_CALEND_DB_SELECT_2 */

            LOOP_CALEND_DB_SELECT_2();

            /*" -206- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -207- PERFORM R0400-SOMA-1-DIA */

                R0400_SOMA_1_DIA_SECTION();

                /*" -209- GO TO LOOP-CALEND. */
                new Task(() => LOOP_CALEND()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -211- ADD 1 TO WS-CONTA-DIA. */
            WS_CONTA_DIA.Value = WS_CONTA_DIA + 1;

            /*" -212- IF WS-CONTA-DIA = WLINK-QTDIAS */

            if (WS_CONTA_DIA == WORK_AREA.WLINK_LINKAGE.WLINK_INPUT.WLINK_QTDIAS)
            {

                /*" -213- GO TO R0300-99-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_FIM*/ //GOTO
                return;

                /*" -214- ELSE */
            }
            else
            {


                /*" -215- PERFORM R0400-SOMA-1-DIA */

                R0400_SOMA_1_DIA_SECTION();

                /*" -215- GO TO LOOP-CALEND. */
                new Task(() => LOOP_CALEND()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }

        [StopWatch]
        /*" LOOP-CALEND-DB-SELECT-1 */
        public void LOOP_CALEND_DB_SELECT_1()
        {
            /*" -190- EXEC SQL SELECT DATA_CALENDARIO INTO :CALENDAR-DATA-CALENDARIO FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO = :WHOST-DTTRAB AND DIA_SEMANA IN ( 'S' , 'D' ) END-EXEC. */

            var lOOP_CALEND_DB_SELECT_1_Query1 = new LOOP_CALEND_DB_SELECT_1_Query1()
            {
                WHOST_DTTRAB = WHOST_DTTRAB.ToString(),
            };

            var executed_1 = LOOP_CALEND_DB_SELECT_1_Query1.Execute(lOOP_CALEND_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CALENDAR_DATA_CALENDARIO, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_FIM*/

        [StopWatch]
        /*" LOOP-CALEND-DB-SELECT-2 */
        public void LOOP_CALEND_DB_SELECT_2()
        {
            /*" -204- EXEC SQL SELECT DATA_FERIADO INTO :FERIADOS-DATA-FERIADO FROM SEGUROS.FERIADOS WHERE DATA_FERIADO = :WHOST-DTTRAB END-EXEC. */

            var lOOP_CALEND_DB_SELECT_2_Query1 = new LOOP_CALEND_DB_SELECT_2_Query1()
            {
                WHOST_DTTRAB = WHOST_DTTRAB.ToString(),
            };

            var executed_1 = LOOP_CALEND_DB_SELECT_2_Query1.Execute(lOOP_CALEND_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FERIADOS_DATA_FERIADO, FERIADOS.DCLFERIADOS.FERIADOS_DATA_FERIADO);
            }


        }

        [StopWatch]
        /*" R0400-SOMA-1-DIA-SECTION */
        private void R0400_SOMA_1_DIA_SECTION()
        {
            /*" -227- MOVE 'R0400-SOMA-1-DIA    ' TO PARAGRAFO */
            _.Move("R0400-SOMA-1-DIA    ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -228- MOVE WHOST-DTTRAB TO DATA-SQL */
            _.Move(WHOST_DTTRAB, WORK_AREA.DATA_SQL);

            /*" -230- ADD 1 TO DIA-SQL */
            WORK_AREA.DATA_SQL.DIA_SQL.Value = WORK_AREA.DATA_SQL.DIA_SQL + 1;

            /*" -237- IF MES-SQL = 01 OR 03 OR 05 OR 07 OR 08 OR 10 OR 12 */

            if (WORK_AREA.DATA_SQL.MES_SQL.In("01", "03", "05", "07", "08", "10", "12"))
            {

                /*" -238- IF DIA-SQL > 31 */

                if (WORK_AREA.DATA_SQL.DIA_SQL > 31)
                {

                    /*" -239- MOVE 1 TO DIA-SQL */
                    _.Move(1, WORK_AREA.DATA_SQL.DIA_SQL);

                    /*" -240- ADD 1 TO MES-SQL */
                    WORK_AREA.DATA_SQL.MES_SQL.Value = WORK_AREA.DATA_SQL.MES_SQL + 1;

                    /*" -241- IF MES-SQL > 12 */

                    if (WORK_AREA.DATA_SQL.MES_SQL > 12)
                    {

                        /*" -242- MOVE 1 TO MES-SQL */
                        _.Move(1, WORK_AREA.DATA_SQL.MES_SQL);

                        /*" -244- ADD 1 TO ANO-SQL. */
                        WORK_AREA.DATA_SQL.ANO_SQL.Value = WORK_AREA.DATA_SQL.ANO_SQL + 1;
                    }

                }

            }


            /*" -248- IF MES-SQL = 04 OR 06 OR 09 OR 11 */

            if (WORK_AREA.DATA_SQL.MES_SQL.In("04", "06", "09", "11"))
            {

                /*" -249- IF DIA-SQL > 30 */

                if (WORK_AREA.DATA_SQL.DIA_SQL > 30)
                {

                    /*" -250- MOVE 1 TO DIA-SQL */
                    _.Move(1, WORK_AREA.DATA_SQL.DIA_SQL);

                    /*" -251- ADD 1 TO MES-SQL */
                    WORK_AREA.DATA_SQL.MES_SQL.Value = WORK_AREA.DATA_SQL.MES_SQL + 1;

                    /*" -252- IF MES-SQL > 12 */

                    if (WORK_AREA.DATA_SQL.MES_SQL > 12)
                    {

                        /*" -253- MOVE 1 TO MES-SQL */
                        _.Move(1, WORK_AREA.DATA_SQL.MES_SQL);

                        /*" -255- ADD 1 TO ANO-SQL. */
                        WORK_AREA.DATA_SQL.ANO_SQL.Value = WORK_AREA.DATA_SQL.ANO_SQL + 1;
                    }

                }

            }


            /*" -256- IF MES-SQL = 02 */

            if (WORK_AREA.DATA_SQL.MES_SQL == 02)
            {

                /*" -258- DIVIDE ANO-SQL BY 4 GIVING ANO-TRAB REMAINDER WS-RESTO */
                _.Divide(WORK_AREA.DATA_SQL.ANO_SQL, 4, ANO_TRAB, WS_RESTO);

                /*" -259- IF WS-RESTO = 0 */

                if (WS_RESTO == 0)
                {

                    /*" -260- IF DIA-SQL > 29 */

                    if (WORK_AREA.DATA_SQL.DIA_SQL > 29)
                    {

                        /*" -261- MOVE 1 TO DIA-SQL */
                        _.Move(1, WORK_AREA.DATA_SQL.DIA_SQL);

                        /*" -262- ADD 1 TO MES-SQL */
                        WORK_AREA.DATA_SQL.MES_SQL.Value = WORK_AREA.DATA_SQL.MES_SQL + 1;

                        /*" -263- END-IF */
                    }


                    /*" -264- ELSE */
                }
                else
                {


                    /*" -265- IF DIA-SQL > 28 */

                    if (WORK_AREA.DATA_SQL.DIA_SQL > 28)
                    {

                        /*" -266- MOVE 1 TO DIA-SQL */
                        _.Move(1, WORK_AREA.DATA_SQL.DIA_SQL);

                        /*" -267- ADD 1 TO MES-SQL */
                        WORK_AREA.DATA_SQL.MES_SQL.Value = WORK_AREA.DATA_SQL.MES_SQL + 1;

                        /*" -268- END-IF */
                    }


                    /*" -269- END-IF */
                }


                /*" -271- END-IF. */
            }


            /*" -271- MOVE DATA-SQL TO WHOST-DTTRAB. */
            _.Move(WORK_AREA.DATA_SQL, WHOST_DTTRAB);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_FIM*/

        [StopWatch]
        /*" R1000-00-PROCESSA-DATA-SECTION */
        private void R1000_00_PROCESSA_DATA_SECTION()
        {
            /*" -288- MOVE 'R1000-00-PROCESSA-DATA' TO PARAGRAFO. */
            _.Move("R1000-00-PROCESSA-DATA", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -290- MOVE WLINK-DATA-DESTINO TO WHOST-DTTRAB */
            _.Move(WORK_AREA.WLINK_LINKAGE.WLINK_INPUT.WLINK_DATA_DESTINO, WHOST_DTTRAB);

            /*" -292- PERFORM R0300-00-SOMA-DIAS. */

            R0300_00_SOMA_DIAS_SECTION();

            /*" -293- MOVE WHOST-DTTRAB TO DATA-SQL. */
            _.Move(WHOST_DTTRAB, WORK_AREA.DATA_SQL);

            /*" -294- MOVE CORR DATA-SQL TO DATA-AAMMDD. */
            _.MoveCorr(WORK_AREA.DATA_SQL, WORK_AREA.DATA_AAMMDD);

            /*" -294- MOVE DATA-INVERTIDA TO WS-DATA-VENCIMENTO. */
            _.Move(WORK_AREA.DATA_INVERTIDA, WS_DATA_VENCIMENTO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/
    }
}