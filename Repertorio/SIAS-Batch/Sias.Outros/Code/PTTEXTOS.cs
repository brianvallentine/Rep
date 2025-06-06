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
using Sias.Outros.DB2.PTTEXTOS;

namespace Code
{
    public class PTTEXTOS
    {
        public bool IsCall { get; set; }

        public PTTEXTOS()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................ SINISTRO                            *      */
        /*"      *   SUBROTINA............... PTTEXTOS                            *      */
        /*"      *   ANALISTA ............... PRODEXTER                           *      */
        /*"      *   PROGRAMADOR ............ PRODEXTER                           *      */
        /*"      *   DATA CODIFICACAO ....... AGO / 2001                          *      */
        /*"      *   FUNCAO ................. INCLUI DADOS NA GE_CARTA_TEXTO      *      */
        /*"      *   AMBIENTE................ BATCH E ONLINE                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        /*"      *--------------------------------------                                 */
        #endregion


        #region VARIABLES

        /*"01             IND1                   PIC  9(004)   VALUE ZEROS.*/
        public IntBasis IND1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"01             WS-TEXTO-CARTA         PIC  X(3200)  VALUE SPACES*/
        public StringBasis WS_TEXTO_CARTA { get; set; } = new StringBasis(new PIC("X", "3200", "X(3200)"), @"");
        /*"01             FILLER                 REDEFINES   WS-TEXTO-CARTA*/
        private _REDEF_PTTEXTOS_FILLER_0 _filler_0 { get; set; }
        public _REDEF_PTTEXTOS_FILLER_0 FILLER_0
        {
            get { _filler_0 = new _REDEF_PTTEXTOS_FILLER_0(); _.Move(WS_TEXTO_CARTA, _filler_0); VarBasis.RedefinePassValue(WS_TEXTO_CARTA, _filler_0, WS_TEXTO_CARTA); _filler_0.ValueChanged += () => { _.Move(_filler_0, WS_TEXTO_CARTA); }; return _filler_0; }
            set { VarBasis.RedefinePassValue(value, _filler_0, WS_TEXTO_CARTA); }
        }  //Redefines
        public class _REDEF_PTTEXTOS_FILLER_0 : VarBasis
        {
            /*"  05           WS-LETRA-TEXTO         PIC  X(001)                                      OCCURS        3200 TIMES.*/
            public ListBasis<StringBasis, string> WS_LETRA_TEXTO { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(001)"), 3200);

            public _REDEF_PTTEXTOS_FILLER_0()
            {
                WS_LETRA_TEXTO.ValueChanged += OnValueChanged;
            }

        }


        public Copies.LBWCT001 LBWCT001 { get; set; } = new Copies.LBWCT001();
        public Copies.LBWCT002 LBWCT002 { get; set; } = new Copies.LBWCT002();
        public Dclgens.ABEND ABEND { get; set; } = new Dclgens.ABEND();
        public Dclgens.GECARTEX GECARTEX { get; set; } = new Dclgens.GECARTEX();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(LBWCT001_PROTOCOLO_RECEBIDO LBWCT001_PROTOCOLO_RECEBIDO_P, GECARTEX_DCLGE_CARTA_TEXTO GECARTEX_DCLGE_CARTA_TEXTO_P, LBWCT002_PROTOCOLO_ENVIO LBWCT002_PROTOCOLO_ENVIO_P) //PROCEDURE DIVISION USING 
        /*PROTOCOLO_RECEBIDO
        DCLGE_CARTA_TEXTO
        PROTOCOLO_ENVIO*/
        {
            try
            {
                this.LBWCT001.PROTOCOLO_RECEBIDO = LBWCT001_PROTOCOLO_RECEBIDO_P;
                this.GECARTEX.DCLGE_CARTA_TEXTO = GECARTEX_DCLGE_CARTA_TEXTO_P;
                this.LBWCT002.PROTOCOLO_ENVIO = LBWCT002_PROTOCOLO_ENVIO_P;

                /*" -72- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -73- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -74- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -74- FLUXCONTROL_PERFORM R0000-00-INICIO-SECTION */

                R0000_00_INICIO_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LBWCT001.PROTOCOLO_RECEBIDO, GECARTEX.DCLGE_CARTA_TEXTO, LBWCT002.PROTOCOLO_ENVIO };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-INICIO-SECTION */
        private void R0000_00_INICIO_SECTION()
        {
            /*" -83- INITIALIZE PROTOCOLO-ENVIO, DCLABEND */
            _.Initialize(
                LBWCT002.PROTOCOLO_ENVIO
                , ABEND.DCLABEND
            );

            /*" -85- PERFORM R0100-00-VERIFICA-PARAMETROS */

            R0100_00_VERIFICA_PARAMETROS_SECTION();

            /*" -86- IF OUT-COD-RETORNO EQUAL 01 */

            if (LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO == 01)
            {

                /*" -88- GO TO R0000-10-SAIDA. */

                R0000_10_SAIDA(); //GOTO
                return;
            }


            /*" -89- IF IN-OPERACAO EQUAL 1 */

            if (LBWCT001.PROTOCOLO_RECEBIDO.IN_OPERACAO == 1)
            {

                /*" -90- PERFORM R1000-00-PROCESSA-INCLUSAO */

                R1000_00_PROCESSA_INCLUSAO_SECTION();

                /*" -91- ELSE */
            }
            else
            {


                /*" -92- IF IN-OPERACAO EQUAL 2 */

                if (LBWCT001.PROTOCOLO_RECEBIDO.IN_OPERACAO == 2)
                {

                    /*" -93- PERFORM R2000-00-PROCESSA-ALTERACAO */

                    R2000_00_PROCESSA_ALTERACAO_SECTION();

                    /*" -94- ELSE */
                }
                else
                {


                    /*" -95- MOVE 01 TO OUT-COD-RETORNO */
                    _.Move(01, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                    /*" -96- MOVE 'PTTEXTOS - OPERACAO NAO PREVISTA' TO OUT-MENSAGEM. */
                    _.Move("PTTEXTOS - OPERACAO NAO PREVISTA", LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM);
                }

            }


            /*" -0- FLUXCONTROL_PERFORM R0000_10_SAIDA */

            R0000_10_SAIDA();

        }

        [StopWatch]
        /*" R0000-10-SAIDA */
        private void R0000_10_SAIDA(bool isPerform = false)
        {
            /*" -102- PERFORM R0200-00-FORMATA-SAIDA */

            R0200_00_FORMATA_SAIDA_SECTION();

            /*" -102- GOBACK. */

            throw new GoBack();

        }

        [StopWatch]
        /*" R0100-00-VERIFICA-PARAMETROS-SECTION */
        private void R0100_00_VERIFICA_PARAMETROS_SECTION()
        {
            /*" -109- IF GECARTEX-NUM-CARTA EQUAL ZEROS */

            if (GECARTEX.DCLGE_CARTA_TEXTO.GECARTEX_NUM_CARTA == 00)
            {

                /*" -110- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -112- MOVE 'PTTEXTOS - NUMERO DA CARTA NAO INFORMADO' TO OUT-MENSAGEM */
                _.Move("PTTEXTOS - NUMERO DA CARTA NAO INFORMADO", LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -114- GO TO R0100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -116- IF GECARTEX-TEXTO-CARTA-TEXT EQUAL SPACES */

            if (GECARTEX.DCLGE_CARTA_TEXTO.GECARTEX_TEXTO_CARTA.GECARTEX_TEXTO_CARTA_TEXT.IsEmpty())
            {

                /*" -117- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -119- MOVE 'PTTEXTOS - TEXTO DA CARTA NAO INFORMADO' TO OUT-MENSAGEM */
                _.Move("PTTEXTOS - TEXTO DA CARTA NAO INFORMADO", LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -119- GO TO R0100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-FORMATA-SAIDA-SECTION */
        private void R0200_00_FORMATA_SAIDA_SECTION()
        {
            /*" -130- MOVE SQLERRMC TO OUT-SQLERRMC */
            _.Move(DB.SQLERRMC, LBWCT002.PROTOCOLO_ENVIO.OUT_SQLERRMC);

            /*" -130- MOVE SQLSTATE TO OUT-SQLSTATE. */
            _.Move(DB.SQLSTATE, LBWCT002.PROTOCOLO_ENVIO.OUT_SQLSTATE);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-INCLUSAO-SECTION */
        private void R1000_00_PROCESSA_INCLUSAO_SECTION()
        {
            /*" -140- MOVE 'R1000' TO ABEND-COD-PROCESSO. */
            _.Move("R1000", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -142- PERFORM R1100-00-CONTA-TEXTO */

            R1100_00_CONTA_TEXTO_SECTION();

            /*" -144- MOVE IND1 TO GECARTEX-TEXTO-CARTA-LEN */
            _.Move(IND1, GECARTEX.DCLGE_CARTA_TEXTO.GECARTEX_TEXTO_CARTA.GECARTEX_TEXTO_CARTA_LEN);

            /*" -144- PERFORM R1200-00-INCLUI-CARTA-TEXTO. */

            R1200_00_INCLUI_CARTA_TEXTO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-CONTA-TEXTO-SECTION */
        private void R1100_00_CONTA_TEXTO_SECTION()
        {
            /*" -154- MOVE 'R1100' TO ABEND-COD-PROCESSO. */
            _.Move("R1100", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -156- MOVE GECARTEX-TEXTO-CARTA-TEXT TO WS-TEXTO-CARTA */
            _.Move(GECARTEX.DCLGE_CARTA_TEXTO.GECARTEX_TEXTO_CARTA.GECARTEX_TEXTO_CARTA_TEXT, WS_TEXTO_CARTA);

            /*" -156- MOVE 3200 TO IND1. */
            _.Move(3200, IND1);

            /*" -0- FLUXCONTROL_PERFORM R1100_10_CONTA */

            R1100_10_CONTA();

        }

        [StopWatch]
        /*" R1100-10-CONTA */
        private void R1100_10_CONTA(bool isPerform = false)
        {
            /*" -162- IF IND1 GREATER ZEROS AND WS-LETRA-TEXTO(IND1) EQUAL SPACES */

            if (IND1 > 00 && FILLER_0.WS_LETRA_TEXTO[IND1] == string.Empty)
            {

                /*" -163- SUBTRACT 1 FROM IND1 */
                IND1.Value = IND1 - 1;

                /*" -163- GO TO R1100-10-CONTA. */
                new Task(() => R1100_10_CONTA()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-INCLUI-CARTA-TEXTO-SECTION */
        private void R1200_00_INCLUI_CARTA_TEXTO_SECTION()
        {
            /*" -173- MOVE 'R1200' TO ABEND-COD-PROCESSO. */
            _.Move("R1200", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -181- PERFORM R1200_00_INCLUI_CARTA_TEXTO_DB_INSERT_1 */

            R1200_00_INCLUI_CARTA_TEXTO_DB_INSERT_1();

            /*" -184- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -185- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -186- MOVE SQLCODE TO OUT-COD-RETORNO-SQL */
                _.Move(DB.SQLCODE, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL);

                /*" -188- MOVE 'PTTEXTOS - PROBLEMAS NO INSERT GE_CARTA_TEXTO' TO OUT-MENSAGEM */
                _.Move("PTTEXTOS - PROBLEMAS NO INSERT GE_CARTA_TEXTO", LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -188- PERFORM R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION();
            }


        }

        [StopWatch]
        /*" R1200-00-INCLUI-CARTA-TEXTO-DB-INSERT-1 */
        public void R1200_00_INCLUI_CARTA_TEXTO_DB_INSERT_1()
        {
            /*" -181- EXEC SQL INSERT INTO SEGUROS.GE_CARTA_TEXTO (NUM_CARTA, TEXTO_CARTA, TIMESTAMP) VALUES (:GECARTEX-NUM-CARTA, :GECARTEX-TEXTO-CARTA, CURRENT TIMESTAMP) END-EXEC. */

            var r1200_00_INCLUI_CARTA_TEXTO_DB_INSERT_1_Insert1 = new R1200_00_INCLUI_CARTA_TEXTO_DB_INSERT_1_Insert1()
            {
                GECARTEX_NUM_CARTA = GECARTEX.DCLGE_CARTA_TEXTO.GECARTEX_NUM_CARTA.ToString(),
                GECARTEX_TEXTO_CARTA = GECARTEX.DCLGE_CARTA_TEXTO.GECARTEX_TEXTO_CARTA.ToString(),
            };

            R1200_00_INCLUI_CARTA_TEXTO_DB_INSERT_1_Insert1.Execute(r1200_00_INCLUI_CARTA_TEXTO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-PROCESSA-ALTERACAO-SECTION */
        private void R2000_00_PROCESSA_ALTERACAO_SECTION()
        {
            /*" -198- MOVE 'R2000' TO ABEND-COD-PROCESSO. */
            _.Move("R2000", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -200- PERFORM R1100-00-CONTA-TEXTO */

            R1100_00_CONTA_TEXTO_SECTION();

            /*" -202- MOVE IND1 TO GECARTEX-TEXTO-CARTA-LEN */
            _.Move(IND1, GECARTEX.DCLGE_CARTA_TEXTO.GECARTEX_TEXTO_CARTA.GECARTEX_TEXTO_CARTA_LEN);

            /*" -202- PERFORM R2100-00-ALTERA-CARTA-TEXTO. */

            R2100_00_ALTERA_CARTA_TEXTO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-ALTERA-CARTA-TEXTO-SECTION */
        private void R2100_00_ALTERA_CARTA_TEXTO_SECTION()
        {
            /*" -212- MOVE 'R2100' TO ABEND-COD-PROCESSO. */
            _.Move("R2100", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -217- PERFORM R2100_00_ALTERA_CARTA_TEXTO_DB_UPDATE_1 */

            R2100_00_ALTERA_CARTA_TEXTO_DB_UPDATE_1();

            /*" -220- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -221- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -222- MOVE SQLCODE TO OUT-COD-RETORNO-SQL */
                _.Move(DB.SQLCODE, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL);

                /*" -224- MOVE 'PTTEXTOS - PROBLEMAS NO UPDATE GE_CARTA_TEXTO' TO OUT-MENSAGEM */
                _.Move("PTTEXTOS - PROBLEMAS NO UPDATE GE_CARTA_TEXTO", LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -224- PERFORM R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION();
            }


        }

        [StopWatch]
        /*" R2100-00-ALTERA-CARTA-TEXTO-DB-UPDATE-1 */
        public void R2100_00_ALTERA_CARTA_TEXTO_DB_UPDATE_1()
        {
            /*" -217- EXEC SQL UPDATE SEGUROS.GE_CARTA_TEXTO SET TEXTO_CARTA = :GECARTEX-TEXTO-CARTA, TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_CARTA = :GECARTEX-NUM-CARTA END-EXEC. */

            var r2100_00_ALTERA_CARTA_TEXTO_DB_UPDATE_1_Update1 = new R2100_00_ALTERA_CARTA_TEXTO_DB_UPDATE_1_Update1()
            {
                GECARTEX_TEXTO_CARTA = GECARTEX.DCLGE_CARTA_TEXTO.GECARTEX_TEXTO_CARTA.ToString(),
                GECARTEX_NUM_CARTA = GECARTEX.DCLGE_CARTA_TEXTO.GECARTEX_NUM_CARTA.ToString(),
            };

            R2100_00_ALTERA_CARTA_TEXTO_DB_UPDATE_1_Update1.Execute(r2100_00_ALTERA_CARTA_TEXTO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -233- MOVE 'PTTEXTOS' TO ABEND-COD-APLICACAO */
            _.Move("PTTEXTOS", ABEND.DCLABEND.ABEND_COD_APLICACAO);

            /*" -233- MOVE IN-USUARIO TO ABEND-COD-USUARIO OF DCLABEND */
            _.Move(LBWCT001.PROTOCOLO_RECEBIDO.IN_USUARIO, ABEND.DCLABEND.ABEND_COD_USUARIO);

            /*" -233- MOVE SQLCODE TO ABEND-SQLCODE OF DCLABEND */
            _.Move(DB.SQLCODE, ABEND.DCLABEND.ABEND_SQLCODE);

            /*" -233- MOVE SQLERRMC TO ABEND-SQLERRMC OF DCLABEND */
            _.Move(DB.SQLERRMC, ABEND.DCLABEND.ABEND_SQLERRMC);

            /*" -233- MOVE SQLSTATE TO ABEND-SQLEXT OF DCLABEND. */
            _.Move(DB.SQLSTATE, ABEND.DCLABEND.ABEND_SQLEXT);

            /*" -233- CALL 'PTABEN1S' USING DCLABEND, PROTOCOLO-ENVIO. */
            _.Call("PTABEN1S", ABEND.DCLABEND, LBWCT002.PROTOCOLO_ENVIO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}