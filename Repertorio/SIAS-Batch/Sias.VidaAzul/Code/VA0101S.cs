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
using Sias.VidaAzul.DB2.VA0101S;

namespace Code
{
    public class VA0101S
    {
        public bool IsCall { get; set; }

        public VA0101S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *     SUBROTINA PARA CONTABILIZACAO DE VALORES DAS FATURAS DOS   *      */
        /*"      *                    NOVOS PRODUTOS VIDAZUL PF                   *      */
        /*"      *                                                                *      */
        /*"      *                 ALEXANDRE F FONSECA - 22/09/95                 *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      * CONVERSAO ANO 2000              CONSEDA4           01/06/1998  *      */
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"01  RAMO                        PIC S9(04)    COMP.*/
        public IntBasis RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  CODSUBES                    PIC S9(04)    COMP.*/
        public IntBasis CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  NUM-FATURA                  PIC S9(09)    COMP.*/
        public IntBasis NUM_FATURA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  DTREF                       PIC X(10).*/
        public StringBasis DTREF { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  DTREF2                      PIC X(10).*/
        public StringBasis DTREF2 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  CODPRODAZ                   PIC X(03).*/
        public StringBasis CODPRODAZ { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
        /*"01  QTD-VIDAS-VG                PIC S9(09)    COMP.*/
        public IntBasis QTD_VIDAS_VG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  QTD-VIDAS-AP                PIC S9(09)    COMP.*/
        public IntBasis QTD_VIDAS_AP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  PRM-VG                      PIC S9(13)V99 COMP-3.*/
        public DoubleBasis PRM_VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  PRM-AP                      PIC S9(13)V99 COMP-3.*/
        public DoubleBasis PRM_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  QTD-VIDAS-VG-W              PIC S9(09)    COMP.*/
        public IntBasis QTD_VIDAS_VG_W { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  QTD-VIDAS-AP-W              PIC S9(09)    COMP.*/
        public IntBasis QTD_VIDAS_AP_W { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  PRM-VG-W                    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis PRM_VG_W { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  PRM-AP-W                    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis PRM_AP_W { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  TIMESTAMP                   PIC X(26).*/
        public StringBasis TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"01  WORK-AREA.*/
        public VA0101S_WORK_AREA WORK_AREA { get; set; } = new VA0101S_WORK_AREA();
        public class VA0101S_WORK_AREA : VarBasis
        {
            /*"    05 WS-DATA-SQL.*/
            public VA0101S_WS_DATA_SQL WS_DATA_SQL { get; set; } = new VA0101S_WS_DATA_SQL();
            public class VA0101S_WS_DATA_SQL : VarBasis
            {
                /*"       10 WS-ANO-SQL            PIC 9(04).*/
                public IntBasis WS_ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       10 FILLER                PIC X(01).*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10 WS-MES-SQL            PIC 9(02).*/
                public IntBasis WS_MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       10 FILLER                PIC X(03).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
                /*"    05 WS-NUM-FATURA            PIC 9(06).*/
            }
            public IntBasis WS_NUM_FATURA { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
            /*"    05 WS-NUM-FATURA-R          REDEFINES       WS-NUM-FATURA.*/
            private _REDEF_VA0101S_WS_NUM_FATURA_R _ws_num_fatura_r { get; set; }
            public _REDEF_VA0101S_WS_NUM_FATURA_R WS_NUM_FATURA_R
            {
                get { _ws_num_fatura_r = new _REDEF_VA0101S_WS_NUM_FATURA_R(); _.Move(WS_NUM_FATURA, _ws_num_fatura_r); VarBasis.RedefinePassValue(WS_NUM_FATURA, _ws_num_fatura_r, WS_NUM_FATURA); _ws_num_fatura_r.ValueChanged += () => { _.Move(_ws_num_fatura_r, WS_NUM_FATURA); }; return _ws_num_fatura_r; }
                set { VarBasis.RedefinePassValue(value, _ws_num_fatura_r, WS_NUM_FATURA); }
            }  //Redefines
            public class _REDEF_VA0101S_WS_NUM_FATURA_R : VarBasis
            {
                /*"       10 WS-ANO-FAT            PIC 9(04).*/
                public IntBasis WS_ANO_FAT { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       10 WS-MES-FAT            PIC 9(02).*/
                public IntBasis WS_MES_FAT { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"01  PARAMETROS.*/

                public _REDEF_VA0101S_WS_NUM_FATURA_R()
                {
                    WS_ANO_FAT.ValueChanged += OnValueChanged;
                    WS_MES_FAT.ValueChanged += OnValueChanged;
                }

            }
        }
        public VA0101S_PARAMETROS PARAMETROS { get; set; } = new VA0101S_PARAMETROS();
        public class VA0101S_PARAMETROS : VarBasis
        {
            /*"    05 PARM-CODPRODAZ          PIC X(03).*/
            public StringBasis PARM_CODPRODAZ { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
            /*"    05 PARM-QTD-VIDAS          PIC S9(09)    COMP.*/
            public IntBasis PARM_QTD_VIDAS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"    05 PARM-PREMIO             PIC S9(13)V99 COMP-3.*/
            public DoubleBasis PARM_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 PARM-MENSAGEM           PIC X(50).*/
            public StringBasis PARM_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "50", "X(50)."), @"");
            /*"    05 PARM-RETCODE            PIC S9(04)    COMP.*/
            public IntBasis PARM_RETCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(VA0101S_PARAMETROS VA0101S_PARAMETROS_P) //PROCEDURE DIVISION USING 
        /*PARAMETROS*/
        {
            try
            {
                this.PARAMETROS = VA0101S_PARAMETROS_P;

                /*" -77- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -80- MOVE +9 TO PARM-RETCODE. */
                _.Move(+9, PARAMETROS.PARM_RETCODE);

                /*" -82- MOVE 'ERRO' TO PARM-MENSAGEM. */
                _.Move("ERRO", PARAMETROS.PARM_MENSAGEM);

                /*" -84- MOVE PARM-CODPRODAZ TO CODPRODAZ. */
                _.Move(PARAMETROS.PARM_CODPRODAZ, CODPRODAZ);

                /*" -92- PERFORM Execute_DB_SELECT_1 */

                Execute_DB_SELECT_1();

                /*" -95- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -96- MOVE SQLCODE TO PARM-RETCODE */
                    _.Move(DB.SQLCODE, PARAMETROS.PARM_RETCODE);

                    /*" -97- MOVE 'ERRO SELECT V0PRODUTOSVG' TO PARM-MENSAGEM */
                    _.Move("ERRO SELECT V0PRODUTOSVG", PARAMETROS.PARM_MENSAGEM);

                    /*" -99- GOBACK. */

                    throw new GoBack();
                }


                /*" -107- PERFORM Execute_DB_SELECT_2 */

                Execute_DB_SELECT_2();

                /*" -110- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -111- MOVE SQLCODE TO PARM-RETCODE */
                    _.Move(DB.SQLCODE, PARAMETROS.PARM_RETCODE);

                    /*" -112- MOVE 'ERRO SELECT V0FATURCONT' TO PARM-MENSAGEM */
                    _.Move("ERRO SELECT V0FATURCONT", PARAMETROS.PARM_MENSAGEM);

                    /*" -114- GOBACK. */

                    throw new GoBack();
                }


                /*" -115- MOVE DTREF TO WS-DATA-SQL. */
                _.Move(DTREF, WORK_AREA.WS_DATA_SQL);

                /*" -116- MOVE WS-ANO-SQL TO WS-ANO-FAT. */
                _.Move(WORK_AREA.WS_DATA_SQL.WS_ANO_SQL, WORK_AREA.WS_NUM_FATURA_R.WS_ANO_FAT);

                /*" -117- MOVE WS-MES-SQL TO WS-MES-FAT. */
                _.Move(WORK_AREA.WS_DATA_SQL.WS_MES_SQL, WORK_AREA.WS_NUM_FATURA_R.WS_MES_FAT);

                /*" -119- MOVE WS-NUM-FATURA TO NUM-FATURA. */
                _.Move(WORK_AREA.WS_NUM_FATURA, NUM_FATURA);

                /*" -121- MOVE WS-NUM-FATURA TO NUM-FATURA. */
                _.Move(WORK_AREA.WS_NUM_FATURA, NUM_FATURA);

                /*" -128- PERFORM Execute_DB_SELECT_3 */

                Execute_DB_SELECT_3();

                /*" -131- IF SQLCODE NOT EQUAL ZEROS AND 100 */

                if (!DB.SQLCODE.In("00", "100"))
                {

                    /*" -132- MOVE SQLCODE TO PARM-RETCODE */
                    _.Move(DB.SQLCODE, PARAMETROS.PARM_RETCODE);

                    /*" -133- MOVE 'ERRO SELECT V0FATURAS  ' TO PARM-MENSAGEM */
                    _.Move("ERRO SELECT V0FATURAS  ", PARAMETROS.PARM_MENSAGEM);

                    /*" -135- GOBACK. */

                    throw new GoBack();
                }


                /*" -136- IF SQLCODE EQUAL ZEROES */

                if (DB.SQLCODE == 00)
                {

                    /*" -138- MOVE DTREF2 TO DTREF. */
                    _.Move(DTREF2, DTREF);
                }


                /*" -139- IF RAMO = 93 */

                if (RAMO == 93)
                {

                    /*" -140- MOVE PARM-QTD-VIDAS TO QTD-VIDAS-VG */
                    _.Move(PARAMETROS.PARM_QTD_VIDAS, QTD_VIDAS_VG);

                    /*" -141- MOVE PARM-PREMIO TO PRM-VG */
                    _.Move(PARAMETROS.PARM_PREMIO, PRM_VG);

                    /*" -144- MOVE +0 TO QTD-VIDAS-AP PRM-AP. */
                    _.Move(+0, QTD_VIDAS_AP, PRM_AP);
                }


                /*" -145- IF RAMO = 81 */

                if (RAMO == 81)
                {

                    /*" -146- MOVE PARM-QTD-VIDAS TO QTD-VIDAS-AP */
                    _.Move(PARAMETROS.PARM_QTD_VIDAS, QTD_VIDAS_AP);

                    /*" -147- MOVE PARM-PREMIO TO PRM-AP */
                    _.Move(PARAMETROS.PARM_PREMIO, PRM_AP);

                    /*" -150- MOVE +0 TO QTD-VIDAS-VG PRM-VG. */
                    _.Move(+0, QTD_VIDAS_VG, PRM_VG);
                }


                /*" -151- IF RAMO = 97 */

                if (RAMO == 97)
                {

                    /*" -153- MOVE PARM-QTD-VIDAS TO QTD-VIDAS-VG QTD-VIDAS-AP */
                    _.Move(PARAMETROS.PARM_QTD_VIDAS, QTD_VIDAS_VG, QTD_VIDAS_AP);

                    /*" -154- COMPUTE PRM-VG = PARM-PREMIO / 2 */
                    PRM_VG.Value = PARAMETROS.PARM_PREMIO / 2f;

                    /*" -156- COMPUTE PRM-AP = PARM-PREMIO - PRM-VG. */
                    PRM_AP.Value = PARAMETROS.PARM_PREMIO - PRM_VG;
                }


                /*" -170- PERFORM Execute_DB_SELECT_4 */

                Execute_DB_SELECT_4();

                /*" -173- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -174- PERFORM M-0100-INCLUI-REFERENCIA THRU 0100-FIM */

                    M_0100_INCLUI_REFERENCIA(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0100_FIM*/


                    /*" -175- ELSE */
                }
                else
                {


                    /*" -176- IF SQLCODE EQUAL ZEROES */

                    if (DB.SQLCODE == 00)
                    {

                        /*" -177- PERFORM 0200-ALTERA-REFERENCIA THRU 0200-FIM */

                        M_0200_ALTERA_REFERENCIA(true);
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0200_FIM*/


                        /*" -178- ELSE */
                    }
                    else
                    {


                        /*" -179- MOVE SQLCODE TO PARM-RETCODE */
                        _.Move(DB.SQLCODE, PARAMETROS.PARM_RETCODE);

                        /*" -181- MOVE 'ERRO SELECT V0FATURCONTAZ' TO PARM-MENSAGEM. */
                        _.Move("ERRO SELECT V0FATURCONTAZ", PARAMETROS.PARM_MENSAGEM);
                    }

                }


                /*" -181- GOBACK. */

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
            /*" -92- EXEC SQL SELECT CODSUBES, RAMO INTO :CODSUBES, :RAMO FROM SEGUROS.V0PRODUTOSVG WHERE NUM_APOLICE = 97010000889 AND CODPRODAZ = :CODPRODAZ END-EXEC. */

            var execute_DB_SELECT_1_Query1 = new Execute_DB_SELECT_1_Query1()
            {
                CODPRODAZ = CODPRODAZ.ToString(),
            };

            var executed_1 = Execute_DB_SELECT_1_Query1.Execute(execute_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CODSUBES, CODSUBES);
                _.Move(executed_1.RAMO, RAMO);
            }


        }

        [StopWatch]
        /*" M-0100-INCLUI-REFERENCIA */
        private void M_0100_INCLUI_REFERENCIA(bool isPerform = false)
        {
            /*" -194- PERFORM M_0100_INCLUI_REFERENCIA_DB_INSERT_1 */

            M_0100_INCLUI_REFERENCIA_DB_INSERT_1();

            /*" -197- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -198- MOVE +0 TO PARM-RETCODE */
                _.Move(+0, PARAMETROS.PARM_RETCODE);

                /*" -199- MOVE SPACES TO PARM-MENSAGEM */
                _.Move("", PARAMETROS.PARM_MENSAGEM);

                /*" -200- ELSE */
            }
            else
            {


                /*" -201- MOVE SQLCODE TO PARM-RETCODE */
                _.Move(DB.SQLCODE, PARAMETROS.PARM_RETCODE);

                /*" -201- MOVE 'ERRO INSERT V0FATURCONTAZ' TO PARM-MENSAGEM. */
                _.Move("ERRO INSERT V0FATURCONTAZ", PARAMETROS.PARM_MENSAGEM);
            }


        }

        [StopWatch]
        /*" M-0100-INCLUI-REFERENCIA-DB-INSERT-1 */
        public void M_0100_INCLUI_REFERENCIA_DB_INSERT_1()
        {
            /*" -194- EXEC SQL INSERT INTO SEGUROS.V0FATURCONTAZ VALUES (:DTREF, :CODPRODAZ, :QTD-VIDAS-VG, :QTD-VIDAS-AP, :PRM-VG, :PRM-AP, CURRENT TIMESTAMP) END-EXEC. */

            var m_0100_INCLUI_REFERENCIA_DB_INSERT_1_Insert1 = new M_0100_INCLUI_REFERENCIA_DB_INSERT_1_Insert1()
            {
                DTREF = DTREF.ToString(),
                CODPRODAZ = CODPRODAZ.ToString(),
                QTD_VIDAS_VG = QTD_VIDAS_VG.ToString(),
                QTD_VIDAS_AP = QTD_VIDAS_AP.ToString(),
                PRM_VG = PRM_VG.ToString(),
                PRM_AP = PRM_AP.ToString(),
            };

            M_0100_INCLUI_REFERENCIA_DB_INSERT_1_Insert1.Execute(m_0100_INCLUI_REFERENCIA_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" Execute-DB-SELECT-2 */
        public void Execute_DB_SELECT_2()
        {
            /*" -107- EXEC SQL SELECT DATA_REFERENCIA, DATA_REFERENCIA + 1 MONTH INTO :DTREF, :DTREF2 FROM SEGUROS.V0FATURCONT WHERE NUM_APOLICE = 97010000889 AND COD_SUBGRUPO = :CODSUBES END-EXEC. */

            var execute_DB_SELECT_2_Query1 = new Execute_DB_SELECT_2_Query1()
            {
                CODSUBES = CODSUBES.ToString(),
            };

            var executed_1 = Execute_DB_SELECT_2_Query1.Execute(execute_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.DTREF, DTREF);
                _.Move(executed_1.DTREF2, DTREF2);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0100_FIM*/

        [StopWatch]
        /*" Execute-DB-SELECT-3 */
        public void Execute_DB_SELECT_3()
        {
            /*" -128- EXEC SQL SELECT NUM_FATURA INTO :NUM-FATURA FROM SEGUROS.V0FATURAS WHERE NUM_APOLICE = 97010000889 AND COD_SUBGRUPO = :CODSUBES AND NUM_FATURA = :NUM-FATURA END-EXEC. */

            var execute_DB_SELECT_3_Query1 = new Execute_DB_SELECT_3_Query1()
            {
                NUM_FATURA = NUM_FATURA.ToString(),
                CODSUBES = CODSUBES.ToString(),
            };

            var executed_1 = Execute_DB_SELECT_3_Query1.Execute(execute_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUM_FATURA, NUM_FATURA);
            }


        }

        [StopWatch]
        /*" M-0200-ALTERA-REFERENCIA */
        private void M_0200_ALTERA_REFERENCIA(bool isPerform = false)
        {
            /*" -208- COMPUTE QTD-VIDAS-VG-W = QTD-VIDAS-VG-W + QTD-VIDAS-VG. */
            QTD_VIDAS_VG_W.Value = QTD_VIDAS_VG_W + QTD_VIDAS_VG;

            /*" -209- COMPUTE QTD-VIDAS-AP-W = QTD-VIDAS-AP-W + QTD-VIDAS-AP. */
            QTD_VIDAS_AP_W.Value = QTD_VIDAS_AP_W + QTD_VIDAS_AP;

            /*" -210- COMPUTE PRM-VG-W = PRM-VG-W + PRM-VG. */
            PRM_VG_W.Value = PRM_VG_W + PRM_VG;

            /*" -212- COMPUTE PRM-AP-W = PRM-AP-W + PRM-AP. */
            PRM_AP_W.Value = PRM_AP_W + PRM_AP;

            /*" -221- PERFORM M_0200_ALTERA_REFERENCIA_DB_UPDATE_1 */

            M_0200_ALTERA_REFERENCIA_DB_UPDATE_1();

            /*" -224- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -225- MOVE +0 TO PARM-RETCODE */
                _.Move(+0, PARAMETROS.PARM_RETCODE);

                /*" -226- MOVE SPACES TO PARM-MENSAGEM */
                _.Move("", PARAMETROS.PARM_MENSAGEM);

                /*" -227- ELSE */
            }
            else
            {


                /*" -228- MOVE SQLCODE TO PARM-RETCODE */
                _.Move(DB.SQLCODE, PARAMETROS.PARM_RETCODE);

                /*" -228- MOVE 'ERRO UPDATE V0FATURCONTAZ' TO PARM-MENSAGEM. */
                _.Move("ERRO UPDATE V0FATURCONTAZ", PARAMETROS.PARM_MENSAGEM);
            }


        }

        [StopWatch]
        /*" M-0200-ALTERA-REFERENCIA-DB-UPDATE-1 */
        public void M_0200_ALTERA_REFERENCIA_DB_UPDATE_1()
        {
            /*" -221- EXEC SQL UPDATE SEGUROS.V0FATURCONTAZ SET QTD_VIDAS_VG = :QTD-VIDAS-VG-W, QTD_VIDAS_AP = :QTD-VIDAS-AP-W, PRM_VG = :PRM-VG-W, PRM_AP = :PRM-AP-W, TIMESTAMP = CURRENT TIMESTAMP WHERE DATA_REFERENCIA = :DTREF AND CODPRODAZ = :CODPRODAZ END-EXEC. */

            var m_0200_ALTERA_REFERENCIA_DB_UPDATE_1_Update1 = new M_0200_ALTERA_REFERENCIA_DB_UPDATE_1_Update1()
            {
                QTD_VIDAS_VG_W = QTD_VIDAS_VG_W.ToString(),
                QTD_VIDAS_AP_W = QTD_VIDAS_AP_W.ToString(),
                PRM_VG_W = PRM_VG_W.ToString(),
                PRM_AP_W = PRM_AP_W.ToString(),
                CODPRODAZ = CODPRODAZ.ToString(),
                DTREF = DTREF.ToString(),
            };

            M_0200_ALTERA_REFERENCIA_DB_UPDATE_1_Update1.Execute(m_0200_ALTERA_REFERENCIA_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" Execute-DB-SELECT-4 */
        public void Execute_DB_SELECT_4()
        {
            /*" -170- EXEC SQL SELECT QTD_VIDAS_VG, QTD_VIDAS_AP, PRM_VG, PRM_AP, TIMESTAMP INTO :QTD-VIDAS-VG-W, :QTD-VIDAS-AP-W, :PRM-VG-W, :PRM-AP-W, :TIMESTAMP FROM SEGUROS.V0FATURCONTAZ WHERE DATA_REFERENCIA = :DTREF AND CODPRODAZ = :CODPRODAZ END-EXEC. */

            var execute_DB_SELECT_4_Query1 = new Execute_DB_SELECT_4_Query1()
            {
                CODPRODAZ = CODPRODAZ.ToString(),
                DTREF = DTREF.ToString(),
            };

            var executed_1 = Execute_DB_SELECT_4_Query1.Execute(execute_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.QTD_VIDAS_VG_W, QTD_VIDAS_VG_W);
                _.Move(executed_1.QTD_VIDAS_AP_W, QTD_VIDAS_AP_W);
                _.Move(executed_1.PRM_VG_W, PRM_VG_W);
                _.Move(executed_1.PRM_AP_W, PRM_AP_W);
                _.Move(executed_1.TIMESTAMP, TIMESTAMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0200_FIM*/
    }
}