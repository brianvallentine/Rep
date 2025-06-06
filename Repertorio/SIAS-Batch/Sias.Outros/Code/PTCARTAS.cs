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
using Sias.Outros.DB2.PTCARTAS;

namespace Code
{
    public class PTCARTAS
    {
        public bool IsCall { get; set; }

        public PTCARTAS()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................ SINISTRO                            *      */
        /*"      *   SUBROTINA............... PTCARTAS                            *      */
        /*"      *   ANALISTA ............... PRODEXTER                           *      */
        /*"      *   PROGRAMADOR ............ PRODEXTER                           *      */
        /*"      *   DATA CODIFICACAO ....... AGO / 2001                          *      */
        /*"      *   FUNCAO ................. INCLUI DADOS NA GE_CARTA            *      */
        /*"      *   AMBIENTE................ BATCH E ONLINE                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 09/07/2012 - CADMUS 71714 - BARDUCCO                           *      */
        /*"      *              PROMOVE VERSAO BATCH NO LUGAR DA VERSAO CICS, QUE *      */
        /*"      *              FOI PROMOVIDA POR ENGANO                          *      */
        /*"      *----------------------------------------------------------------       */
        /*"      *   ALTERADO JEFFERSON EM 18/02/2007                             *      */
        /*"      *   NO INSERT DA GE_CARTA INCLUIU O CAMPO SEQ_CARTA_REITERA      *      */
        /*"      *----------------------------------------------------------------       */
        /*"      *                                                                       */
        /*"      *--------------------------------------                                 */
        #endregion


        #region VARIABLES

        /*"01             VIND-NUM-CARTA-REITERA   PIC S9(004) COMP VALUE 0*/
        public IntBasis VIND_NUM_CARTA_REITERA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));


        public Copies.LBWCT001 LBWCT001 { get; set; } = new Copies.LBWCT001();
        public Copies.LBWCT002 LBWCT002 { get; set; } = new Copies.LBWCT002();
        public Dclgens.ABEND ABEND { get; set; } = new Dclgens.ABEND();
        public Dclgens.GECARTA GECARTA { get; set; } = new Dclgens.GECARTA();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(LBWCT001_PROTOCOLO_RECEBIDO LBWCT001_PROTOCOLO_RECEBIDO_P, GECARTA_DCLGE_CARTA GECARTA_DCLGE_CARTA_P, LBWCT002_PROTOCOLO_ENVIO LBWCT002_PROTOCOLO_ENVIO_P) //PROCEDURE DIVISION USING 
        /*PROTOCOLO_RECEBIDO
        DCLGE_CARTA
        PROTOCOLO_ENVIO*/
        {
            try
            {
                this.LBWCT001.PROTOCOLO_RECEBIDO = LBWCT001_PROTOCOLO_RECEBIDO_P;
                this.GECARTA.DCLGE_CARTA = GECARTA_DCLGE_CARTA_P;
                this.LBWCT002.PROTOCOLO_ENVIO = LBWCT002_PROTOCOLO_ENVIO_P;

                /*" -61- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -62- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -63- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -63- FLUXCONTROL_PERFORM R0000-00-INICIO-SECTION */

                R0000_00_INICIO_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LBWCT001.PROTOCOLO_RECEBIDO, GECARTA.DCLGE_CARTA, LBWCT002.PROTOCOLO_ENVIO };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-INICIO-SECTION */
        private void R0000_00_INICIO_SECTION()
        {
            /*" -74- INITIALIZE PROTOCOLO-ENVIO, DCLABEND */
            _.Initialize(
                LBWCT002.PROTOCOLO_ENVIO
                , ABEND.DCLABEND
            );

            /*" -75- IF OUT-COD-RETORNO EQUAL 01 */

            if (LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO == 01)
            {

                /*" -77- GO TO R0000-10-SAIDA. */

                R0000_10_SAIDA(); //GOTO
                return;
            }


            /*" -78- IF IN-OPERACAO EQUAL 1 */

            if (LBWCT001.PROTOCOLO_RECEBIDO.IN_OPERACAO == 1)
            {

                /*" -79- PERFORM R1000-00-PROCESSA-INCLUSAO */

                R1000_00_PROCESSA_INCLUSAO_SECTION();

                /*" -80- ELSE */
            }
            else
            {


                /*" -81- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -82- MOVE 'PTCARTAS - OPERACAO NAO PREVISTA' TO OUT-MENSAGEM. */
                _.Move("PTCARTAS - OPERACAO NAO PREVISTA", LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM);
            }


            /*" -0- FLUXCONTROL_PERFORM R0000_10_SAIDA */

            R0000_10_SAIDA();

        }

        [StopWatch]
        /*" R0000-10-SAIDA */
        private void R0000_10_SAIDA(bool isPerform = false)
        {
            /*" -88- PERFORM R0200-00-FORMATA-SAIDA */

            R0200_00_FORMATA_SAIDA_SECTION();

            /*" -88- GOBACK. */

            throw new GoBack();

        }

        [StopWatch]
        /*" R0100-00-VERIFICA-PARAMETROS-SECTION */
        private void R0100_00_VERIFICA_PARAMETROS_SECTION()
        {
            /*" -95- IF GECARTA-NUM-CARTA EQUAL ZEROS */

            if (GECARTA.DCLGE_CARTA.GECARTA_NUM_CARTA == 00)
            {

                /*" -96- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -98- MOVE 'PTCARTAS - NUMERO DA CARTA NAO INFORMADO' TO OUT-MENSAGEM */
                _.Move("PTCARTAS - NUMERO DA CARTA NAO INFORMADO", LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -98- GO TO R0100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-FORMATA-SAIDA-SECTION */
        private void R0200_00_FORMATA_SAIDA_SECTION()
        {
            /*" -109- MOVE SQLERRMC TO OUT-SQLERRMC */
            _.Move(DB.SQLERRMC, LBWCT002.PROTOCOLO_ENVIO.OUT_SQLERRMC);

            /*" -109- MOVE SQLSTATE TO OUT-SQLSTATE. */
            _.Move(DB.SQLSTATE, LBWCT002.PROTOCOLO_ENVIO.OUT_SQLSTATE);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-INCLUSAO-SECTION */
        private void R1000_00_PROCESSA_INCLUSAO_SECTION()
        {
            /*" -119- MOVE 'R1000' TO ABEND-COD-PROCESSO. */
            _.Move("R1000", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -121- PERFORM R1100-00-MAX-NUM-CARTA */

            R1100_00_MAX_NUM_CARTA_SECTION();

            /*" -122- IF OUT-COD-RETORNO EQUAL 00 */

            if (LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO == 00)
            {

                /*" -123- ADD 1 TO GECARTA-NUM-CARTA */
                GECARTA.DCLGE_CARTA.GECARTA_NUM_CARTA.Value = GECARTA.DCLGE_CARTA.GECARTA_NUM_CARTA + 1;

                /*" -125- IF GECARTA-NUM-CARTA-REITERA EQUAL ZEROS */

                if (GECARTA.DCLGE_CARTA.GECARTA_NUM_CARTA_REITERA == 00)
                {

                    /*" -126- MOVE -1 TO VIND-NUM-CARTA-REITERA */
                    _.Move(-1, VIND_NUM_CARTA_REITERA);

                    /*" -127- ELSE */
                }
                else
                {


                    /*" -128- MOVE 0 TO VIND-NUM-CARTA-REITERA */
                    _.Move(0, VIND_NUM_CARTA_REITERA);

                    /*" -129- END-IF */
                }


                /*" -129- PERFORM R1200-00-INCLUI-CARTA. */

                R1200_00_INCLUI_CARTA_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-MAX-NUM-CARTA-SECTION */
        private void R1100_00_MAX_NUM_CARTA_SECTION()
        {
            /*" -139- MOVE 'R1100' TO ABEND-COD-PROCESSO. */
            _.Move("R1100", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -143- PERFORM R1100_00_MAX_NUM_CARTA_DB_SELECT_1 */

            R1100_00_MAX_NUM_CARTA_DB_SELECT_1();

            /*" -146- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -147- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -148- MOVE SQLCODE TO OUT-COD-RETORNO-SQL */
                _.Move(DB.SQLCODE, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL);

                /*" -150- MOVE 'PTCARTAS - PROBLEMAS NO MAX GE_CARTA' TO OUT-MENSAGEM */
                _.Move("PTCARTAS - PROBLEMAS NO MAX GE_CARTA", LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -150- PERFORM R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION();
            }


        }

        [StopWatch]
        /*" R1100-00-MAX-NUM-CARTA-DB-SELECT-1 */
        public void R1100_00_MAX_NUM_CARTA_DB_SELECT_1()
        {
            /*" -143- EXEC SQL SELECT VALUE(MAX(NUM_CARTA), 0) INTO :GECARTA-NUM-CARTA FROM SEGUROS.GE_CARTA END-EXEC. */

            var r1100_00_MAX_NUM_CARTA_DB_SELECT_1_Query1 = new R1100_00_MAX_NUM_CARTA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R1100_00_MAX_NUM_CARTA_DB_SELECT_1_Query1.Execute(r1100_00_MAX_NUM_CARTA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GECARTA_NUM_CARTA, GECARTA.DCLGE_CARTA.GECARTA_NUM_CARTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-INCLUI-CARTA-SECTION */
        private void R1200_00_INCLUI_CARTA_SECTION()
        {
            /*" -160- MOVE 'R1200' TO ABEND-COD-PROCESSO. */
            _.Move("R1200", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -172- PERFORM R1200_00_INCLUI_CARTA_DB_INSERT_1 */

            R1200_00_INCLUI_CARTA_DB_INSERT_1();

            /*" -175- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -176- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -177- MOVE SQLCODE TO OUT-COD-RETORNO-SQL */
                _.Move(DB.SQLCODE, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL);

                /*" -179- MOVE 'PTCARTAS - PROBLEMAS NO INSERT GE_CARTA' TO OUT-MENSAGEM */
                _.Move("PTCARTAS - PROBLEMAS NO INSERT GE_CARTA", LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -179- PERFORM R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION();
            }


        }

        [StopWatch]
        /*" R1200-00-INCLUI-CARTA-DB-INSERT-1 */
        public void R1200_00_INCLUI_CARTA_DB_INSERT_1()
        {
            /*" -172- EXEC SQL INSERT INTO SEGUROS.GE_CARTA (NUM_CARTA, NUM_CARTA_REITERA, COD_USUARIO, TIMESTAMP, SEQ_CARTA_REITERA) VALUES (:GECARTA-NUM-CARTA, :GECARTA-NUM-CARTA-REITERA:VIND-NUM-CARTA-REITERA, :GECARTA-COD-USUARIO, CURRENT TIMESTAMP, :GECARTA-SEQ-CARTA-REITERA) END-EXEC. */

            var r1200_00_INCLUI_CARTA_DB_INSERT_1_Insert1 = new R1200_00_INCLUI_CARTA_DB_INSERT_1_Insert1()
            {
                GECARTA_NUM_CARTA = GECARTA.DCLGE_CARTA.GECARTA_NUM_CARTA.ToString(),
                GECARTA_NUM_CARTA_REITERA = GECARTA.DCLGE_CARTA.GECARTA_NUM_CARTA_REITERA.ToString(),
                VIND_NUM_CARTA_REITERA = VIND_NUM_CARTA_REITERA.ToString(),
                GECARTA_COD_USUARIO = GECARTA.DCLGE_CARTA.GECARTA_COD_USUARIO.ToString(),
                GECARTA_SEQ_CARTA_REITERA = GECARTA.DCLGE_CARTA.GECARTA_SEQ_CARTA_REITERA.ToString(),
            };

            R1200_00_INCLUI_CARTA_DB_INSERT_1_Insert1.Execute(r1200_00_INCLUI_CARTA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -188- MOVE 'PTCARTAS' TO ABEND-COD-APLICACAO */
            _.Move("PTCARTAS", ABEND.DCLABEND.ABEND_COD_APLICACAO);

            /*" -188- MOVE IN-USUARIO TO ABEND-COD-USUARIO OF DCLABEND */
            _.Move(LBWCT001.PROTOCOLO_RECEBIDO.IN_USUARIO, ABEND.DCLABEND.ABEND_COD_USUARIO);

            /*" -188- MOVE SQLCODE TO ABEND-SQLCODE OF DCLABEND */
            _.Move(DB.SQLCODE, ABEND.DCLABEND.ABEND_SQLCODE);

            /*" -188- MOVE SQLERRMC TO ABEND-SQLERRMC OF DCLABEND */
            _.Move(DB.SQLERRMC, ABEND.DCLABEND.ABEND_SQLERRMC);

            /*" -188- MOVE SQLSTATE TO ABEND-SQLEXT OF DCLABEND. */
            _.Move(DB.SQLSTATE, ABEND.DCLABEND.ABEND_SQLEXT);

            /*" -188- CALL 'PTABEN1S' USING DCLABEND, PROTOCOLO-ENVIO. */
            _.Call("PTABEN1S", ABEND.DCLABEND, LBWCT002.PROTOCOLO_ENVIO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}