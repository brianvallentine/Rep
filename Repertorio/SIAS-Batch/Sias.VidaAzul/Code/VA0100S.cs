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
using Sias.VidaAzul.DB2.VA0100S;

namespace Code
{
    public class VA0100S
    {
        public bool IsCall { get; set; }

        public VA0100S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *     SUBROTINA PARA CONTABILIZACAO DE LANCAMENTOS NA            *      */
        /*"      *    CONTA-CORRENTE SASSE DOS NOVOS PRODUTOS VIDAZUL PF          *      */
        /*"      *                                                                *      */
        /*"      *                 ALEXANDRE F FONSECA - 08/08/95                 *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      * CONVERSAO ANO 2000              CONSEDA4           01/06/1998  *      */
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"01  NUM-APOLICE                  PIC S9(013)          COMP-3.*/
        public IntBasis NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01  RAMO                         PIC S9(004)          COMP.*/
        public IntBasis RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  FONTE                        PIC S9(004)          COMP.*/
        public IntBasis FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  COD-SUBGRUPO                 PIC S9(004)          COMP.*/
        public IntBasis COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  DTMOVTO                      PIC  X(010).*/
        public StringBasis DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  DTINIVIG                     PIC  X(010).*/
        public StringBasis DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  PCIOF                        PIC S9(003)V99       COMP-3.*/
        public DoubleBasis PCIOF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"01  CODPRODAZ                    PIC  X(003).*/
        public StringBasis CODPRODAZ { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"01  CODOPER                      PIC S9(004)          COMP.*/
        public IntBasis CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VLOPER                       PIC S9(013)V99       COMP-3.*/
        public DoubleBasis VLOPER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  VLOPER-W                     PIC S9(013)V99       COMP-3.*/
        public DoubleBasis VLOPER_W { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  VLIOCC-W                     PIC S9(013)V99       COMP-3.*/
        public DoubleBasis VLIOCC_W { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  VLOPER-FIL                   PIC S9(013)V99       COMP-3.*/
        public DoubleBasis VLOPER_FIL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  VLIOCC-FIL                   PIC S9(013)V99       COMP-3.*/
        public DoubleBasis VLIOCC_FIL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  NUMFAT                       PIC S9(009)          COMP.*/
        public IntBasis NUMFAT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  INDNUMFAT                    PIC S9(004) COMP VALUE -1.*/
        public IntBasis INDNUMFAT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), -1);
        /*"01  VLIOCC                       PIC S9(013)V99       COMP-3.*/
        public DoubleBasis VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01              WS-WORK.*/
        public VA0100S_WS_WORK WS_WORK { get; set; } = new VA0100S_WS_WORK();
        public class VA0100S_WS_WORK : VarBasis
        {
            /*" 05             WS-DTRENOVA           PIC X(010).*/
            public StringBasis WS_DTRENOVA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*" 05             WS-DTINIVIG           PIC X(010).*/
            public StringBasis WS_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*" 05             WS-DTBASE.*/
            public VA0100S_WS_DTBASE WS_DTBASE { get; set; } = new VA0100S_WS_DTBASE();
            public class VA0100S_WS_DTBASE : VarBasis
            {
                /*"   10           WS-AABASE             PIC 9(004).*/
                public IntBasis WS_AABASE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"   10           FILLER                PIC X(001).*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"   10           WS-MMBASE             PIC 9(002).*/
                public IntBasis WS_MMBASE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"   10           FILLER                PIC X(001).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"   10           WS-DDBASE             PIC 9(002).*/
                public IntBasis WS_DDBASE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*" 05             WS-INTEIRO            PIC 9(004).*/
            }
            public IntBasis WS_INTEIRO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"01  PARAMETROS.*/
        }
        public VA0100S_PARAMETROS PARAMETROS { get; set; } = new VA0100S_PARAMETROS();
        public class VA0100S_PARAMETROS : VarBasis
        {
            /*"    05 PARM-APOLICE              PIC S9(013)          COMP-3.*/
            public IntBasis PARM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"    05 PARM-FONTE                PIC S9(004)          COMP.*/
            public IntBasis PARM_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05 PARM-DTMOVTO              PIC  X(010).*/
            public StringBasis PARM_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05 PARM-DTINIVIG             PIC  X(010).*/
            public StringBasis PARM_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05 PARM-DTRENOVA             PIC  X(010).*/
            public StringBasis PARM_DTRENOVA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05 PARM-CODPRODAZ            PIC  X(003).*/
            public StringBasis PARM_CODPRODAZ { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"    05 PARM-CODOPER              PIC S9(004)          COMP.*/
            public IntBasis PARM_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05 PARM-VLOPER               PIC S9(013)V99       COMP-3.*/
            public DoubleBasis PARM_VLOPER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 PARM-RETCODE              PIC S9(04)           COMP.*/
            public IntBasis PARM_RETCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 PARM-MENSAGEM             PIC  X(50).*/
            public StringBasis PARM_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "50", "X(50)."), @"");
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(VA0100S_PARAMETROS VA0100S_PARAMETROS_P) //PROCEDURE DIVISION USING 
        /*PARAMETROS*/
        {
            try
            {
                this.PARAMETROS = VA0100S_PARAMETROS_P;

                /*" -86- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -91- MOVE +9 TO PARM-RETCODE. */
                _.Move(+9, PARAMETROS.PARM_RETCODE);

                /*" -93- MOVE 'ERRO' TO PARM-MENSAGEM. */
                _.Move("ERRO", PARAMETROS.PARM_MENSAGEM);

                /*" -94- MOVE PARM-FONTE TO FONTE. */
                _.Move(PARAMETROS.PARM_FONTE, FONTE);

                /*" -95- MOVE PARM-DTMOVTO TO DTMOVTO. */
                _.Move(PARAMETROS.PARM_DTMOVTO, DTMOVTO);

                /*" -96- MOVE PARM-CODPRODAZ TO CODPRODAZ. */
                _.Move(PARAMETROS.PARM_CODPRODAZ, CODPRODAZ);

                /*" -97- MOVE PARM-CODOPER TO CODOPER. */
                _.Move(PARAMETROS.PARM_CODOPER, CODOPER);

                /*" -99- MOVE PARM-VLOPER TO VLOPER. */
                _.Move(PARAMETROS.PARM_VLOPER, VLOPER);

                /*" -106- PERFORM Execute_DB_SELECT_1 */

                Execute_DB_SELECT_1();

                /*" -109- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -110- MOVE +0 TO PARM-RETCODE */
                    _.Move(+0, PARAMETROS.PARM_RETCODE);

                    /*" -111- MOVE NUM-APOLICE TO PARM-APOLICE */
                    _.Move(NUM_APOLICE, PARAMETROS.PARM_APOLICE);

                    /*" -112- ELSE */
                }
                else
                {


                    /*" -113- MOVE SQLCODE TO PARM-RETCODE */
                    _.Move(DB.SQLCODE, PARAMETROS.PARM_RETCODE);

                    /*" -114- MOVE 'ERRO SELECT VOPRODUTOSVG ' TO PARM-MENSAGEM */
                    _.Move("ERRO SELECT VOPRODUTOSVG ", PARAMETROS.PARM_MENSAGEM);

                    /*" -118- GOBACK. */

                    throw new GoBack();
                }


                /*" -123- PERFORM Execute_DB_SELECT_2 */

                Execute_DB_SELECT_2();

                /*" -126- IF SQLCODE NOT EQUAL 00 */

                if (DB.SQLCODE != 00)
                {

                    /*" -127- MOVE SQLCODE TO PARM-RETCODE */
                    _.Move(DB.SQLCODE, PARAMETROS.PARM_RETCODE);

                    /*" -128- MOVE 'ERRO SELECT V1APOLICE' TO PARM-MENSAGEM */
                    _.Move("ERRO SELECT V1APOLICE", PARAMETROS.PARM_MENSAGEM);

                    /*" -133- GOBACK. */

                    throw new GoBack();
                }


                /*" -134- IF PARM-DTRENOVA EQUAL SPACES */

                if (PARAMETROS.PARM_DTRENOVA.IsEmpty())
                {

                    /*" -135- MOVE PARM-DTINIVIG TO WS-DTBASE */
                    _.Move(PARAMETROS.PARM_DTINIVIG, WS_WORK.WS_DTBASE);

                    /*" -136- ELSE */
                }
                else
                {


                    /*" -137- MOVE PARM-DTRENOVA TO WS-DTRENOVA */
                    _.Move(PARAMETROS.PARM_DTRENOVA, WS_WORK.WS_DTRENOVA);

                    /*" -139- PERFORM 0099-CALCULA-DTINIVIG THRU 0099-FIM. */
                }


                /*" -141- MOVE WS-DTBASE TO DTINIVIG. */
                _.Move(WS_WORK.WS_DTBASE, DTINIVIG);

                /*" -148- PERFORM Execute_DB_SELECT_3 */

                Execute_DB_SELECT_3();

                /*" -151- IF SQLCODE NOT EQUAL 00 */

                if (DB.SQLCODE != 00)
                {

                    /*" -152- MOVE SQLCODE TO PARM-RETCODE */
                    _.Move(DB.SQLCODE, PARAMETROS.PARM_RETCODE);

                    /*" -153- MOVE 'ERRO SELECT V1RAMOIND' TO PARM-MENSAGEM */
                    _.Move("ERRO SELECT V1RAMOIND", PARAMETROS.PARM_MENSAGEM);

                    /*" -155- GOBACK. */

                    throw new GoBack();
                }


                /*" -160- COMPUTE VLIOCC ROUNDED = PARM-VLOPER - (PARM-VLOPER / (1 + (PCIOF / 100))) */
                VLIOCC.Value = PARAMETROS.PARM_VLOPER - (PARAMETROS.PARM_VLOPER / (1 + (PCIOF / 100f)));

                /*" -168- PERFORM Execute_DB_SELECT_4 */

                Execute_DB_SELECT_4();

                /*" -171- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -172- PERFORM M-0100-INCLUI-LANCAMENTO THRU 0100-FIM */

                    M_0100_INCLUI_LANCAMENTO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0100_FIM*/


                    /*" -173- ELSE */
                }
                else
                {


                    /*" -174- IF SQLCODE EQUAL ZEROES */

                    if (DB.SQLCODE == 00)
                    {

                        /*" -175- PERFORM 0200-ALTERA-LANCAMENTO THRU 0200-FIM */

                        M_0200_ALTERA_LANCAMENTO(true);
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0200_FIM*/


                        /*" -176- ELSE */
                    }
                    else
                    {


                        /*" -177- MOVE SQLCODE TO PARM-RETCODE */
                        _.Move(DB.SQLCODE, PARAMETROS.PARM_RETCODE);

                        /*" -178- MOVE 'ERRO SELECT V0SALCONTABAZ' TO PARM-MENSAGEM */
                        _.Move("ERRO SELECT V0SALCONTABAZ", PARAMETROS.PARM_MENSAGEM);

                        /*" -180- GOBACK. */

                        throw new GoBack();
                    }

                }


                /*" -181- IF CODOPER EQUAL 101 OR 102 OR 201 OR 501 */

                if (CODOPER.In("101", "102", "201", "501"))
                {

                    /*" -182- MOVE +9 TO PARM-RETCODE */
                    _.Move(+9, PARAMETROS.PARM_RETCODE);

                    /*" -183- MOVE 'ERRO' TO PARM-MENSAGEM */
                    _.Move("ERRO", PARAMETROS.PARM_MENSAGEM);

                    /*" -185- PERFORM 0300-CONTABIL-NOVA THRU 0300-FIM. */

                    M_0300_CONTABIL_NOVA(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0300_FIM*/

                }


                /*" -191- GOBACK. 0099-CALCULA-DTINIVIG. */

                throw new GoBack();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { PARAMETROS };
            return Result;
        }

        [StopWatch]
        /*" Execute-DB-SELECT-1 */
        public void Execute_DB_SELECT_1()
        {
            /*" -106- EXEC SQL SELECT NUM_APOLICE, CODSUBES INTO :NUM-APOLICE, :COD-SUBGRUPO FROM SEGUROS.V0PRODUTOSVG WHERE CODPRODAZ = :CODPRODAZ END-EXEC. */

            var execute_DB_SELECT_1_Query1 = new Execute_DB_SELECT_1_Query1()
            {
                CODPRODAZ = CODPRODAZ.ToString(),
            };

            var executed_1 = Execute_DB_SELECT_1_Query1.Execute(execute_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUM_APOLICE, NUM_APOLICE);
                _.Move(executed_1.COD_SUBGRUPO, COD_SUBGRUPO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0099_FIM*/

        [StopWatch]
        /*" Execute-DB-SELECT-2 */
        public void Execute_DB_SELECT_2()
        {
            /*" -123- EXEC SQL SELECT RAMO INTO :RAMO FROM SEGUROS.V1APOLICE WHERE NUM_APOLICE = :NUM-APOLICE END-EXEC. */

            var execute_DB_SELECT_2_Query1 = new Execute_DB_SELECT_2_Query1()
            {
                NUM_APOLICE = NUM_APOLICE.ToString(),
            };

            var executed_1 = Execute_DB_SELECT_2_Query1.Execute(execute_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RAMO, RAMO);
            }


        }

        [StopWatch]
        /*" M-0100-INCLUI-LANCAMENTO */
        private void M_0100_INCLUI_LANCAMENTO(bool isPerform = false)
        {
            /*" -241- PERFORM M_0100_INCLUI_LANCAMENTO_DB_INSERT_1 */

            M_0100_INCLUI_LANCAMENTO_DB_INSERT_1();

            /*" -244- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -245- MOVE +0 TO PARM-RETCODE */
                _.Move(+0, PARAMETROS.PARM_RETCODE);

                /*" -246- MOVE SPACES TO PARM-MENSAGEM */
                _.Move("", PARAMETROS.PARM_MENSAGEM);

                /*" -247- ELSE */
            }
            else
            {


                /*" -248- MOVE SQLCODE TO PARM-RETCODE */
                _.Move(DB.SQLCODE, PARAMETROS.PARM_RETCODE);

                /*" -248- MOVE 'ERRO INSERT V0SALCONTAB' TO PARM-MENSAGEM. */
                _.Move("ERRO INSERT V0SALCONTAB", PARAMETROS.PARM_MENSAGEM);
            }


        }

        [StopWatch]
        /*" M-0100-INCLUI-LANCAMENTO-DB-INSERT-1 */
        public void M_0100_INCLUI_LANCAMENTO_DB_INSERT_1()
        {
            /*" -241- EXEC SQL INSERT INTO SEGUROS.V0SALCONTABAZ VALUES (:DTMOVTO, :CODPRODAZ, :CODOPER, :VLOPER, CURRENT TIMESTAMP, :NUMFAT:INDNUMFAT, :VLIOCC) END-EXEC. */

            var m_0100_INCLUI_LANCAMENTO_DB_INSERT_1_Insert1 = new M_0100_INCLUI_LANCAMENTO_DB_INSERT_1_Insert1()
            {
                DTMOVTO = DTMOVTO.ToString(),
                CODPRODAZ = CODPRODAZ.ToString(),
                CODOPER = CODOPER.ToString(),
                VLOPER = VLOPER.ToString(),
                NUMFAT = NUMFAT.ToString(),
                INDNUMFAT = INDNUMFAT.ToString(),
                VLIOCC = VLIOCC.ToString(),
            };

            M_0100_INCLUI_LANCAMENTO_DB_INSERT_1_Insert1.Execute(m_0100_INCLUI_LANCAMENTO_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" Execute-DB-SELECT-3 */
        public void Execute_DB_SELECT_3()
        {
            /*" -148- EXEC SQL SELECT PCIOF INTO :PCIOF FROM SEGUROS.V1RAMOIND WHERE RAMO = :RAMO AND DTINIVIG <= :DTINIVIG AND DTTERVIG >= :DTINIVIG END-EXEC. */

            var execute_DB_SELECT_3_Query1 = new Execute_DB_SELECT_3_Query1()
            {
                DTINIVIG = DTINIVIG.ToString(),
                RAMO = RAMO.ToString(),
            };

            var executed_1 = Execute_DB_SELECT_3_Query1.Execute(execute_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PCIOF, PCIOF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0100_FIM*/

        [StopWatch]
        /*" Execute-DB-SELECT-4 */
        public void Execute_DB_SELECT_4()
        {
            /*" -168- EXEC SQL SELECT VLOPER, VLIOCC INTO :VLOPER-W, :VLIOCC-W FROM SEGUROS.V0SALCONTABAZ WHERE DTMOVTO = :DTMOVTO AND CODPRODAZ = :CODPRODAZ AND CODOPER = :CODOPER AND NUM_FATURA IS NULL END-EXEC. */

            var execute_DB_SELECT_4_Query1 = new Execute_DB_SELECT_4_Query1()
            {
                CODPRODAZ = CODPRODAZ.ToString(),
                DTMOVTO = DTMOVTO.ToString(),
                CODOPER = CODOPER.ToString(),
            };

            var executed_1 = Execute_DB_SELECT_4_Query1.Execute(execute_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VLOPER_W, VLOPER_W);
                _.Move(executed_1.VLIOCC_W, VLIOCC_W);
            }


        }

        [StopWatch]
        /*" M-0200-ALTERA-LANCAMENTO */
        private void M_0200_ALTERA_LANCAMENTO(bool isPerform = false)
        {
            /*" -255- COMPUTE VLOPER-W = VLOPER-W + VLOPER. */
            VLOPER_W.Value = VLOPER_W + VLOPER;

            /*" -257- COMPUTE VLIOCC-W = VLIOCC-W + VLIOCC. */
            VLIOCC_W.Value = VLIOCC_W + VLIOCC;

            /*" -266- PERFORM M_0200_ALTERA_LANCAMENTO_DB_UPDATE_1 */

            M_0200_ALTERA_LANCAMENTO_DB_UPDATE_1();

            /*" -269- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -270- MOVE +0 TO PARM-RETCODE */
                _.Move(+0, PARAMETROS.PARM_RETCODE);

                /*" -271- MOVE SPACES TO PARM-MENSAGEM */
                _.Move("", PARAMETROS.PARM_MENSAGEM);

                /*" -272- ELSE */
            }
            else
            {


                /*" -273- MOVE SQLCODE TO PARM-RETCODE */
                _.Move(DB.SQLCODE, PARAMETROS.PARM_RETCODE);

                /*" -273- MOVE 'ERRO UPDATE V0SALCONTAB' TO PARM-MENSAGEM. */
                _.Move("ERRO UPDATE V0SALCONTAB", PARAMETROS.PARM_MENSAGEM);
            }


        }

        [StopWatch]
        /*" M-0200-ALTERA-LANCAMENTO-DB-UPDATE-1 */
        public void M_0200_ALTERA_LANCAMENTO_DB_UPDATE_1()
        {
            /*" -266- EXEC SQL UPDATE SEGUROS.V0SALCONTABAZ SET VLOPER = :VLOPER-W, VLIOCC = :VLIOCC-W, TIMESTAMP = CURRENT TIMESTAMP WHERE DTMOVTO = :DTMOVTO AND CODPRODAZ = :CODPRODAZ AND CODOPER = :CODOPER AND NUM_FATURA IS NULL END-EXEC. */

            var m_0200_ALTERA_LANCAMENTO_DB_UPDATE_1_Update1 = new M_0200_ALTERA_LANCAMENTO_DB_UPDATE_1_Update1()
            {
                VLOPER_W = VLOPER_W.ToString(),
                VLIOCC_W = VLIOCC_W.ToString(),
                CODPRODAZ = CODPRODAZ.ToString(),
                DTMOVTO = DTMOVTO.ToString(),
                CODOPER = CODOPER.ToString(),
            };

            M_0200_ALTERA_LANCAMENTO_DB_UPDATE_1_Update1.Execute(m_0200_ALTERA_LANCAMENTO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0200_FIM*/

        [StopWatch]
        /*" M-0300-CONTABIL-NOVA */
        private void M_0300_CONTABIL_NOVA(bool isPerform = false)
        {
            /*" -288- PERFORM M_0300_CONTABIL_NOVA_DB_SELECT_1 */

            M_0300_CONTABIL_NOVA_DB_SELECT_1();

            /*" -291- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -292- PERFORM 0400-INCLUI-LANCAMENTO THRU 0400-FIM */

                M_0400_INCLUI_LANCAMENTO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0400_FIM*/


                /*" -293- ELSE */
            }
            else
            {


                /*" -294- IF SQLCODE EQUAL ZEROES */

                if (DB.SQLCODE == 00)
                {

                    /*" -295- PERFORM 0500-ALTERA-LANCAMENTO THRU 0500-FIM */

                    M_0500_ALTERA_LANCAMENTO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0500_FIM*/


                    /*" -296- ELSE */
                }
                else
                {


                    /*" -297- MOVE SQLCODE TO PARM-RETCODE */
                    _.Move(DB.SQLCODE, PARAMETROS.PARM_RETCODE);

                    /*" -297- MOVE 'ERRO SELECT V0SALCONTABAZFIL' TO PARM-MENSAGEM. */
                    _.Move("ERRO SELECT V0SALCONTABAZFIL", PARAMETROS.PARM_MENSAGEM);
                }

            }


        }

        [StopWatch]
        /*" M-0300-CONTABIL-NOVA-DB-SELECT-1 */
        public void M_0300_CONTABIL_NOVA_DB_SELECT_1()
        {
            /*" -288- EXEC SQL SELECT VAL_OPERACAO, VLIOCC INTO :VLOPER-FIL, :VLIOCC-FIL FROM SEGUROS.V0SALCONTABAZFIL WHERE NUM_APOLICE = :NUM-APOLICE AND COD_FONTE = :FONTE AND DTMOVTO = :DTMOVTO AND COD_SUBGRUPO = :COD-SUBGRUPO AND COD_OPERACAO = :CODOPER AND NUM_FATURA IS NULL END-EXEC. */

            var m_0300_CONTABIL_NOVA_DB_SELECT_1_Query1 = new M_0300_CONTABIL_NOVA_DB_SELECT_1_Query1()
            {
                COD_SUBGRUPO = COD_SUBGRUPO.ToString(),
                NUM_APOLICE = NUM_APOLICE.ToString(),
                DTMOVTO = DTMOVTO.ToString(),
                CODOPER = CODOPER.ToString(),
                FONTE = FONTE.ToString(),
            };

            var executed_1 = M_0300_CONTABIL_NOVA_DB_SELECT_1_Query1.Execute(m_0300_CONTABIL_NOVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VLOPER_FIL, VLOPER_FIL);
                _.Move(executed_1.VLIOCC_FIL, VLIOCC_FIL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0300_FIM*/

        [StopWatch]
        /*" M-0400-INCLUI-LANCAMENTO */
        private void M_0400_INCLUI_LANCAMENTO(bool isPerform = false)
        {
            /*" -305- MOVE ZEROS TO NUMFAT */
            _.Move(0, NUMFAT);

            /*" -316- PERFORM M_0400_INCLUI_LANCAMENTO_DB_INSERT_1 */

            M_0400_INCLUI_LANCAMENTO_DB_INSERT_1();

            /*" -319- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -320- MOVE +0 TO PARM-RETCODE */
                _.Move(+0, PARAMETROS.PARM_RETCODE);

                /*" -321- MOVE SPACES TO PARM-MENSAGEM */
                _.Move("", PARAMETROS.PARM_MENSAGEM);

                /*" -322- ELSE */
            }
            else
            {


                /*" -323- MOVE SQLCODE TO PARM-RETCODE */
                _.Move(DB.SQLCODE, PARAMETROS.PARM_RETCODE);

                /*" -323- MOVE 'ERRO INSERT V0SALCONTABAZFIL' TO PARM-MENSAGEM. */
                _.Move("ERRO INSERT V0SALCONTABAZFIL", PARAMETROS.PARM_MENSAGEM);
            }


        }

        [StopWatch]
        /*" M-0400-INCLUI-LANCAMENTO-DB-INSERT-1 */
        public void M_0400_INCLUI_LANCAMENTO_DB_INSERT_1()
        {
            /*" -316- EXEC SQL INSERT INTO SEGUROS.V0SALCONTABAZFIL VALUES (:NUM-APOLICE, :FONTE, :COD-SUBGRUPO, :CODOPER, :VLOPER, :DTMOVTO, :NUMFAT:INDNUMFAT, CURRENT TIMESTAMP, :VLIOCC) END-EXEC. */

            var m_0400_INCLUI_LANCAMENTO_DB_INSERT_1_Insert1 = new M_0400_INCLUI_LANCAMENTO_DB_INSERT_1_Insert1()
            {
                NUM_APOLICE = NUM_APOLICE.ToString(),
                FONTE = FONTE.ToString(),
                COD_SUBGRUPO = COD_SUBGRUPO.ToString(),
                CODOPER = CODOPER.ToString(),
                VLOPER = VLOPER.ToString(),
                DTMOVTO = DTMOVTO.ToString(),
                NUMFAT = NUMFAT.ToString(),
                INDNUMFAT = INDNUMFAT.ToString(),
                VLIOCC = VLIOCC.ToString(),
            };

            M_0400_INCLUI_LANCAMENTO_DB_INSERT_1_Insert1.Execute(m_0400_INCLUI_LANCAMENTO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0400_FIM*/

        [StopWatch]
        /*" M-0500-ALTERA-LANCAMENTO */
        private void M_0500_ALTERA_LANCAMENTO(bool isPerform = false)
        {
            /*" -330- COMPUTE VLOPER-FIL = VLOPER-FIL + VLOPER. */
            VLOPER_FIL.Value = VLOPER_FIL + VLOPER;

            /*" -332- COMPUTE VLIOCC-FIL = VLIOCC-FIL + VLIOCC. */
            VLIOCC_FIL.Value = VLIOCC_FIL + VLIOCC;

            /*" -343- PERFORM M_0500_ALTERA_LANCAMENTO_DB_UPDATE_1 */

            M_0500_ALTERA_LANCAMENTO_DB_UPDATE_1();

            /*" -346- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -347- MOVE +0 TO PARM-RETCODE */
                _.Move(+0, PARAMETROS.PARM_RETCODE);

                /*" -348- MOVE SPACES TO PARM-MENSAGEM */
                _.Move("", PARAMETROS.PARM_MENSAGEM);

                /*" -349- ELSE */
            }
            else
            {


                /*" -350- MOVE SQLCODE TO PARM-RETCODE */
                _.Move(DB.SQLCODE, PARAMETROS.PARM_RETCODE);

                /*" -350- MOVE 'ERRO UPDATE V0SALCONTABAZFIL' TO PARM-MENSAGEM. */
                _.Move("ERRO UPDATE V0SALCONTABAZFIL", PARAMETROS.PARM_MENSAGEM);
            }


        }

        [StopWatch]
        /*" M-0500-ALTERA-LANCAMENTO-DB-UPDATE-1 */
        public void M_0500_ALTERA_LANCAMENTO_DB_UPDATE_1()
        {
            /*" -343- EXEC SQL UPDATE SEGUROS.V0SALCONTABAZFIL SET VAL_OPERACAO = :VLOPER-FIL, VLIOCC = :VLIOCC-FIL, TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_APOLICE = :NUM-APOLICE AND COD_FONTE = :FONTE AND DTMOVTO = :DTMOVTO AND COD_SUBGRUPO = :COD-SUBGRUPO AND COD_OPERACAO = :CODOPER AND NUM_FATURA IS NULL END-EXEC. */

            var m_0500_ALTERA_LANCAMENTO_DB_UPDATE_1_Update1 = new M_0500_ALTERA_LANCAMENTO_DB_UPDATE_1_Update1()
            {
                VLOPER_FIL = VLOPER_FIL.ToString(),
                VLIOCC_FIL = VLIOCC_FIL.ToString(),
                COD_SUBGRUPO = COD_SUBGRUPO.ToString(),
                NUM_APOLICE = NUM_APOLICE.ToString(),
                DTMOVTO = DTMOVTO.ToString(),
                CODOPER = CODOPER.ToString(),
                FONTE = FONTE.ToString(),
            };

            M_0500_ALTERA_LANCAMENTO_DB_UPDATE_1_Update1.Execute(m_0500_ALTERA_LANCAMENTO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0500_FIM*/
    }
}