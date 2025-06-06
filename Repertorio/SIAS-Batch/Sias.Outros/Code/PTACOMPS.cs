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
using Sias.Outros.DB2.PTACOMPS;

namespace Code
{
    public class PTACOMPS
    {
        public bool IsCall { get; set; }

        public PTACOMPS()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................ SINISTRO                            *      */
        /*"      *   SUBROTINA............... PTACOMPS                            *      */
        /*"      *   ANALISTA ............... PRODEXTER                           *      */
        /*"      *   PROGRAMADOR ............ PRODEXTER                           *      */
        /*"      *   DATA CODIFICACAO ....... AGO / 2001                          *      */
        /*"      *   FUNCAO ................. INCLUI DADOS NA GE_CARTA_ACOMP      *      */
        /*"      *   AMBIENTE................ BATCH E ONLINE                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        /*"      *--------------------------------------                                 */
        #endregion


        #region VARIABLES


        public Copies.LBWCT001 LBWCT001 { get; set; } = new Copies.LBWCT001();
        public Copies.LBWCT002 LBWCT002 { get; set; } = new Copies.LBWCT002();
        public Dclgens.ABEND ABEND { get; set; } = new Dclgens.ABEND();
        public Dclgens.GECARACO GECARACO { get; set; } = new Dclgens.GECARACO();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(LBWCT001_PROTOCOLO_RECEBIDO LBWCT001_PROTOCOLO_RECEBIDO_P, GECARACO_DCLGE_CARTA_ACOMP GECARACO_DCLGE_CARTA_ACOMP_P, LBWCT002_PROTOCOLO_ENVIO LBWCT002_PROTOCOLO_ENVIO_P) //PROCEDURE DIVISION USING 
        /*PROTOCOLO_RECEBIDO
        DCLGE_CARTA_ACOMP
        PROTOCOLO_ENVIO*/
        {
            try
            {
                this.LBWCT001.PROTOCOLO_RECEBIDO = LBWCT001_PROTOCOLO_RECEBIDO_P;
                this.GECARACO.DCLGE_CARTA_ACOMP = GECARACO_DCLGE_CARTA_ACOMP_P;
                this.LBWCT002.PROTOCOLO_ENVIO = LBWCT002_PROTOCOLO_ENVIO_P;

                /*" -65- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -66- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -67- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -67- FLUXCONTROL_PERFORM R0000-00-INICIO-SECTION */

                R0000_00_INICIO_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LBWCT001.PROTOCOLO_RECEBIDO, GECARACO.DCLGE_CARTA_ACOMP, LBWCT002.PROTOCOLO_ENVIO };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-INICIO-SECTION */
        private void R0000_00_INICIO_SECTION()
        {
            /*" -76- INITIALIZE PROTOCOLO-ENVIO, DCLABEND */
            _.Initialize(
                LBWCT002.PROTOCOLO_ENVIO
                , ABEND.DCLABEND
            );

            /*" -78- PERFORM R0100-00-VERIFICA-PARAMETROS */

            R0100_00_VERIFICA_PARAMETROS_SECTION();

            /*" -79- IF OUT-COD-RETORNO EQUAL 01 */

            if (LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO == 01)
            {

                /*" -81- GO TO R0000-10-SAIDA. */

                R0000_10_SAIDA(); //GOTO
                return;
            }


            /*" -82- IF IN-OPERACAO EQUAL 1 */

            if (LBWCT001.PROTOCOLO_RECEBIDO.IN_OPERACAO == 1)
            {

                /*" -83- PERFORM R1000-00-PROCESSA-INCLUSAO */

                R1000_00_PROCESSA_INCLUSAO_SECTION();

                /*" -84- ELSE */
            }
            else
            {


                /*" -85- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -86- MOVE 'PTACOMPS - OPERACAO NAO PREVISTA' TO OUT-MENSAGEM. */
                _.Move("PTACOMPS - OPERACAO NAO PREVISTA", LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM);
            }


            /*" -0- FLUXCONTROL_PERFORM R0000_10_SAIDA */

            R0000_10_SAIDA();

        }

        [StopWatch]
        /*" R0000-10-SAIDA */
        private void R0000_10_SAIDA(bool isPerform = false)
        {
            /*" -92- PERFORM R0200-00-FORMATA-SAIDA */

            R0200_00_FORMATA_SAIDA_SECTION();

            /*" -92- GOBACK. */

            throw new GoBack();

        }

        [StopWatch]
        /*" R0100-00-VERIFICA-PARAMETROS-SECTION */
        private void R0100_00_VERIFICA_PARAMETROS_SECTION()
        {
            /*" -99- IF GECARACO-NUM-CARTA EQUAL ZEROS */

            if (GECARACO.DCLGE_CARTA_ACOMP.GECARACO_NUM_CARTA == 00)
            {

                /*" -100- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -102- MOVE 'PTACOMPS - NUMERO DA CARTA NAO INFORMADO' TO OUT-MENSAGEM */
                _.Move("PTACOMPS - NUMERO DA CARTA NAO INFORMADO", LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -104- GO TO R0100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -105- IF GECARACO-COD-EVENTO EQUAL ZEROS */

            if (GECARACO.DCLGE_CARTA_ACOMP.GECARACO_COD_EVENTO == 00)
            {

                /*" -106- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -108- MOVE 'PTACOMPS - CODIGO DO EVENTO NAO INFORMADO' TO OUT-MENSAGEM */
                _.Move("PTACOMPS - CODIGO DO EVENTO NAO INFORMADO", LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -110- GO TO R0100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -112- IF GECARACO-DATA-MOVTO-CARTACO EQUAL SPACES */

            if (GECARACO.DCLGE_CARTA_ACOMP.GECARACO_DATA_MOVTO_CARTACO.IsEmpty())
            {

                /*" -113- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -115- MOVE 'PTACOMPS - DATA DE MOVIMENTO NAO INFORMADA' TO OUT-MENSAGEM */
                _.Move("PTACOMPS - DATA DE MOVIMENTO NAO INFORMADA", LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -115- GO TO R0100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-FORMATA-SAIDA-SECTION */
        private void R0200_00_FORMATA_SAIDA_SECTION()
        {
            /*" -126- MOVE SQLERRMC TO OUT-SQLERRMC */
            _.Move(DB.SQLERRMC, LBWCT002.PROTOCOLO_ENVIO.OUT_SQLERRMC);

            /*" -126- MOVE SQLSTATE TO OUT-SQLSTATE. */
            _.Move(DB.SQLSTATE, LBWCT002.PROTOCOLO_ENVIO.OUT_SQLSTATE);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-INCLUSAO-SECTION */
        private void R1000_00_PROCESSA_INCLUSAO_SECTION()
        {
            /*" -136- MOVE 'R1000' TO ABEND-COD-PROCESSO. */
            _.Move("R1000", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -138- PERFORM R1100-00-MAX-NUM-OCORRENCIA */

            R1100_00_MAX_NUM_OCORRENCIA_SECTION();

            /*" -139- IF OUT-COD-RETORNO EQUAL 00 */

            if (LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO == 00)
            {

                /*" -141- ADD 1 TO GECARACO-NUM-OCORR-CARTACO */
                GECARACO.DCLGE_CARTA_ACOMP.GECARACO_NUM_OCORR_CARTACO.Value = GECARACO.DCLGE_CARTA_ACOMP.GECARACO_NUM_OCORR_CARTACO + 1;

                /*" -141- PERFORM R1200-00-INCLUI-CARTA-ACOMP. */

                R1200_00_INCLUI_CARTA_ACOMP_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-MAX-NUM-OCORRENCIA-SECTION */
        private void R1100_00_MAX_NUM_OCORRENCIA_SECTION()
        {
            /*" -151- MOVE 'R1100' TO ABEND-COD-PROCESSO. */
            _.Move("R1100", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -156- PERFORM R1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1 */

            R1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1();

            /*" -159- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -160- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -161- MOVE SQLCODE TO OUT-COD-RETORNO-SQL */
                _.Move(DB.SQLCODE, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL);

                /*" -163- MOVE 'PTACOMPS - PROBLEMAS NO MAX GE_CARTA_ACOMP' TO OUT-MENSAGEM */
                _.Move("PTACOMPS - PROBLEMAS NO MAX GE_CARTA_ACOMP", LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -163- PERFORM R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION();
            }


        }

        [StopWatch]
        /*" R1100-00-MAX-NUM-OCORRENCIA-DB-SELECT-1 */
        public void R1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1()
        {
            /*" -156- EXEC SQL SELECT VALUE(MAX(NUM_OCORR_CARTACO), 0) INTO :GECARACO-NUM-OCORR-CARTACO FROM SEGUROS.GE_CARTA_ACOMP WHERE NUM_CARTA = :GECARACO-NUM-CARTA END-EXEC. */

            var r1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1_Query1 = new R1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1_Query1()
            {
                GECARACO_NUM_CARTA = GECARACO.DCLGE_CARTA_ACOMP.GECARACO_NUM_CARTA.ToString(),
            };

            var executed_1 = R1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1_Query1.Execute(r1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GECARACO_NUM_OCORR_CARTACO, GECARACO.DCLGE_CARTA_ACOMP.GECARACO_NUM_OCORR_CARTACO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-INCLUI-CARTA-ACOMP-SECTION */
        private void R1200_00_INCLUI_CARTA_ACOMP_SECTION()
        {
            /*" -173- MOVE 'R1200' TO ABEND-COD-PROCESSO. */
            _.Move("R1200", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -179- DISPLAY ' ' GECARACO-NUM-CARTA ' ' GECARACO-NUM-OCORR-CARTACO ' ' GECARACO-COD-EVENTO ' ' GECARACO-DATA-MOVTO-CARTACO ' ' GECARACO-COD-USUARIO */

            $" {GECARACO.DCLGE_CARTA_ACOMP.GECARACO_NUM_CARTA} {GECARACO.DCLGE_CARTA_ACOMP.GECARACO_NUM_OCORR_CARTACO} {GECARACO.DCLGE_CARTA_ACOMP.GECARACO_COD_EVENTO} {GECARACO.DCLGE_CARTA_ACOMP.GECARACO_DATA_MOVTO_CARTACO} {GECARACO.DCLGE_CARTA_ACOMP.GECARACO_COD_USUARIO}"
            .Display();

            /*" -193- PERFORM R1200_00_INCLUI_CARTA_ACOMP_DB_INSERT_1 */

            R1200_00_INCLUI_CARTA_ACOMP_DB_INSERT_1();

            /*" -196- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -197- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -198- MOVE SQLCODE TO OUT-COD-RETORNO-SQL */
                _.Move(DB.SQLCODE, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL);

                /*" -200- MOVE 'PTACOMPS - PROBLEMAS NO INSERT GE_CARTA_ACOMP' TO OUT-MENSAGEM */
                _.Move("PTACOMPS - PROBLEMAS NO INSERT GE_CARTA_ACOMP", LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -200- PERFORM R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION();
            }


        }

        [StopWatch]
        /*" R1200-00-INCLUI-CARTA-ACOMP-DB-INSERT-1 */
        public void R1200_00_INCLUI_CARTA_ACOMP_DB_INSERT_1()
        {
            /*" -193- EXEC SQL INSERT INTO SEGUROS.GE_CARTA_ACOMP (NUM_CARTA, NUM_OCORR_CARTACO, COD_EVENTO, DATA_MOVTO_CARTACO, COD_USUARIO, TIMESTAMP) VALUES (:GECARACO-NUM-CARTA, :GECARACO-NUM-OCORR-CARTACO, :GECARACO-COD-EVENTO, :GECARACO-DATA-MOVTO-CARTACO, :GECARACO-COD-USUARIO, CURRENT TIMESTAMP) END-EXEC. */

            var r1200_00_INCLUI_CARTA_ACOMP_DB_INSERT_1_Insert1 = new R1200_00_INCLUI_CARTA_ACOMP_DB_INSERT_1_Insert1()
            {
                GECARACO_NUM_CARTA = GECARACO.DCLGE_CARTA_ACOMP.GECARACO_NUM_CARTA.ToString(),
                GECARACO_NUM_OCORR_CARTACO = GECARACO.DCLGE_CARTA_ACOMP.GECARACO_NUM_OCORR_CARTACO.ToString(),
                GECARACO_COD_EVENTO = GECARACO.DCLGE_CARTA_ACOMP.GECARACO_COD_EVENTO.ToString(),
                GECARACO_DATA_MOVTO_CARTACO = GECARACO.DCLGE_CARTA_ACOMP.GECARACO_DATA_MOVTO_CARTACO.ToString(),
                GECARACO_COD_USUARIO = GECARACO.DCLGE_CARTA_ACOMP.GECARACO_COD_USUARIO.ToString(),
            };

            R1200_00_INCLUI_CARTA_ACOMP_DB_INSERT_1_Insert1.Execute(r1200_00_INCLUI_CARTA_ACOMP_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -209- MOVE 'PTACOMPS' TO ABEND-COD-APLICACAO */
            _.Move("PTACOMPS", ABEND.DCLABEND.ABEND_COD_APLICACAO);

            /*" -209- MOVE IN-USUARIO TO ABEND-COD-USUARIO OF DCLABEND */
            _.Move(LBWCT001.PROTOCOLO_RECEBIDO.IN_USUARIO, ABEND.DCLABEND.ABEND_COD_USUARIO);

            /*" -209- MOVE SQLCODE TO ABEND-SQLCODE OF DCLABEND */
            _.Move(DB.SQLCODE, ABEND.DCLABEND.ABEND_SQLCODE);

            /*" -209- MOVE SQLERRMC TO ABEND-SQLERRMC OF DCLABEND */
            _.Move(DB.SQLERRMC, ABEND.DCLABEND.ABEND_SQLERRMC);

            /*" -209- MOVE SQLSTATE TO ABEND-SQLEXT OF DCLABEND. */
            _.Move(DB.SQLSTATE, ABEND.DCLABEND.ABEND_SQLEXT);

            /*" -209- CALL 'PTABEN1S' USING DCLABEND, PROTOCOLO-ENVIO. */
            _.Call("PTABEN1S", ABEND.DCLABEND, LBWCT002.PROTOCOLO_ENVIO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}