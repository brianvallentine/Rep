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
using Sias.Outros.DB2.PTACOM2S;

namespace Code
{
    public class PTACOM2S
    {
        public bool IsCall { get; set; }

        public PTACOM2S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................ SINISTRO                            *      */
        /*"      *   SUBROTINA............... PTACOM2S                            *      */
        /*"      *   ANALISTA ............... PRODEXTER                           *      */
        /*"      *   PROGRAMADOR ............ PRODEXTER                           *      */
        /*"      *   DATA CODIFICACAO ....... MAR / 2014                          *      */
        /*"      *   FUNCAO ................. MANTEM DADOS DA SI_DOCUMENTO_ACOMP  *      */
        /*"      *   AMBIENTE................ BATCH E ONLINE                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 1                                                           */
        /*"      * MOTIVO  : PROBLEMAS NO MAX SI_CHECKLIST_PARAM                         */
        /*"      * CADMUS  : 95059                                                       */
        /*"      * DATA    : 10/03/2014                                                  */
        /*"      * NOME    : KATIA FERREIRA                                              */
        /*"      * MARCADOR: V.1                                                         */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        /*"      *--------------------------------------                                 */
        #endregion


        #region VARIABLES

        /*"01             WTEM-SIMOVSIN           PIC  X(001) VALUE SPACES.*/
        public StringBasis WTEM_SIMOVSIN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01             VIND-NUM-CARTA          PIC S9(004) COMP VALUE +0*/
        public IntBasis VIND_NUM_CARTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));


        public Copies.LBWCT001 LBWCT001 { get; set; } = new Copies.LBWCT001();
        public Copies.LBWCT002 LBWCT002 { get; set; } = new Copies.LBWCT002();
        public Dclgens.ABEND ABEND { get; set; } = new Dclgens.ABEND();
        public Dclgens.SIPARTIC SIPARTIC { get; set; } = new Dclgens.SIPARTIC();
        public Dclgens.SIPROACO SIPROACO { get; set; } = new Dclgens.SIPROACO();
        public Dclgens.SIMOVSIN SIMOVSIN { get; set; } = new Dclgens.SIMOVSIN();
        public Dclgens.SICHEPAR SICHEPAR { get; set; } = new Dclgens.SICHEPAR();
        public Dclgens.SIDOCACO SIDOCACO { get; set; } = new Dclgens.SIDOCACO();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(LBWCT001_PROTOCOLO_RECEBIDO LBWCT001_PROTOCOLO_RECEBIDO_P, SIDOCACO_DCLSI_DOCUMENTO_ACOMP SIDOCACO_DCLSI_DOCUMENTO_ACOMP_P, LBWCT002_PROTOCOLO_ENVIO LBWCT002_PROTOCOLO_ENVIO_P) //PROCEDURE DIVISION USING 
        /*PROTOCOLO_RECEBIDO
        DCLSI_DOCUMENTO_ACOMP
        PROTOCOLO_ENVIO*/
        {
            try
            {
                this.LBWCT001.PROTOCOLO_RECEBIDO = LBWCT001_PROTOCOLO_RECEBIDO_P;
                this.SIDOCACO.DCLSI_DOCUMENTO_ACOMP = SIDOCACO_DCLSI_DOCUMENTO_ACOMP_P;
                this.LBWCT002.PROTOCOLO_ENVIO = LBWCT002_PROTOCOLO_ENVIO_P;

                /*" -81- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -82- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -83- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -83- FLUXCONTROL_PERFORM R0000-00-INICIO-SECTION */

                R0000_00_INICIO_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LBWCT001.PROTOCOLO_RECEBIDO, SIDOCACO.DCLSI_DOCUMENTO_ACOMP, LBWCT002.PROTOCOLO_ENVIO };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-INICIO-SECTION */
        private void R0000_00_INICIO_SECTION()
        {
            /*" -92- INITIALIZE PROTOCOLO-ENVIO, DCLABEND */
            _.Initialize(
                LBWCT002.PROTOCOLO_ENVIO
                , ABEND.DCLABEND
            );

            /*" -100- DISPLAY 'PTACOM2S VERSAO 1 - INICIO PROCESSAMENTO EM  ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"PTACOM2S VERSAO 1 - INICIO PROCESSAMENTO EM  {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -102- PERFORM R0100-00-VERIFICA-PARAMETROS */

            R0100_00_VERIFICA_PARAMETROS_SECTION();

            /*" -103- IF OUT-COD-RETORNO EQUAL 01 */

            if (LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO == 01)
            {

                /*" -105- GO TO R0000-10-SAIDA. */

                R0000_10_SAIDA(); //GOTO
                return;
            }


            /*" -106- IF IN-OPERACAO EQUAL 1 */

            if (LBWCT001.PROTOCOLO_RECEBIDO.IN_OPERACAO == 1)
            {

                /*" -107- PERFORM R1000-00-PROCESSA-INCLUSAO */

                R1000_00_PROCESSA_INCLUSAO_SECTION();

                /*" -108- ELSE */
            }
            else
            {


                /*" -109- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -110- MOVE 'SPBSI002 - OPERACAO NAO PREVISTA' TO OUT-MENSAGEM. */
                _.Move("SPBSI002 - OPERACAO NAO PREVISTA", LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM);
            }


            /*" -0- FLUXCONTROL_PERFORM R0000_10_SAIDA */

            R0000_10_SAIDA();

        }

        [StopWatch]
        /*" R0000-10-SAIDA */
        private void R0000_10_SAIDA(bool isPerform = false)
        {
            /*" -116- PERFORM R0200-00-FORMATA-SAIDA */

            R0200_00_FORMATA_SAIDA_SECTION();

            /*" -116- GOBACK. */

            throw new GoBack();

        }

        [StopWatch]
        /*" R0100-00-VERIFICA-PARAMETROS-SECTION */
        private void R0100_00_VERIFICA_PARAMETROS_SECTION()
        {
            /*" -154- IF SIDOCACO-COD-FONTE EQUAL ZEROS */

            if (SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_FONTE == 00)
            {

                /*" -155- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -157- MOVE 'SPBSI002 - CODIGO DA FONTE NAO INFORMADO' TO OUT-MENSAGEM */
                _.Move("SPBSI002 - CODIGO DA FONTE NAO INFORMADO", LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -159- GO TO R0100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -161- IF SIDOCACO-NUM-PROTOCOLO-SINI EQUAL ZEROS */

            if (SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_PROTOCOLO_SINI == 00)
            {

                /*" -162- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -164- MOVE 'SPBSI002 - NUMERO DO PROTOCOLO NAO INFORMADO' TO OUT-MENSAGEM */
                _.Move("SPBSI002 - NUMERO DO PROTOCOLO NAO INFORMADO", LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -166- GO TO R0100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -167- IF SIDOCACO-COD-DOCUMENTO EQUAL ZEROS */

            if (SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_DOCUMENTO == 00)
            {

                /*" -168- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -170- MOVE 'SPBSI002 - CODIGO DO DOCUMENTO NAO INFORMADO' TO OUT-MENSAGEM */
                _.Move("SPBSI002 - CODIGO DO DOCUMENTO NAO INFORMADO", LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -172- GO TO R0100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -173- IF SIDOCACO-COD-EVENTO EQUAL ZEROS */

            if (SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_EVENTO == 00)
            {

                /*" -174- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -176- MOVE 'SPBSI002 - CODIGO DO EVENTO NAO INFORMADO' TO OUT-MENSAGEM */
                _.Move("SPBSI002 - CODIGO DO EVENTO NAO INFORMADO", LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -178- GO TO R0100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -180- IF SIDOCACO-DATA-MOVTO-DOCACO EQUAL SPACES */

            if (SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DATA_MOVTO_DOCACO.IsEmpty())
            {

                /*" -181- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -183- MOVE 'SPBSI002 - DATA DE MOVIMENTO NAO INFORMADA' TO OUT-MENSAGEM */
                _.Move("SPBSI002 - DATA DE MOVIMENTO NAO INFORMADA", LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -183- GO TO R0100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-FORMATA-SAIDA-SECTION */
        private void R0200_00_FORMATA_SAIDA_SECTION()
        {
            /*" -194- MOVE SQLERRMC TO OUT-SQLERRMC */
            _.Move(DB.SQLERRMC, LBWCT002.PROTOCOLO_ENVIO.OUT_SQLERRMC);

            /*" -194- MOVE SQLSTATE TO OUT-SQLSTATE. */
            _.Move(DB.SQLSTATE, LBWCT002.PROTOCOLO_ENVIO.OUT_SQLSTATE);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-INCLUSAO-SECTION */
        private void R1000_00_PROCESSA_INCLUSAO_SECTION()
        {
            /*" -204- MOVE 'R1000' TO ABEND-COD-PROCESSO. */
            _.Move("R1000", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -206- PERFORM R1100-00-MAX-NUM-OCORRENCIA */

            R1100_00_MAX_NUM_OCORRENCIA_SECTION();

            /*" -207- IF OUT-COD-RETORNO EQUAL 00 */

            if (LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO == 00)
            {

                /*" -209- ADD 1 TO SIDOCACO-NUM-OCORR-DOCACO */
                SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_OCORR_DOCACO.Value = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_OCORR_DOCACO + 1;

                /*" -210- IF SIDOCACO-NUM-CARTA EQUAL 0 */

                if (SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_CARTA == 0)
                {

                    /*" -211- MOVE -1 TO VIND-NUM-CARTA */
                    _.Move(-1, VIND_NUM_CARTA);

                    /*" -212- ELSE */
                }
                else
                {


                    /*" -213- MOVE ZEROS TO VIND-NUM-CARTA */
                    _.Move(0, VIND_NUM_CARTA);

                    /*" -214- END-IF */
                }


                /*" -218- PERFORM R1200-00-INCLUI-DOCTO-ACOMP. */

                R1200_00_INCLUI_DOCTO_ACOMP_SECTION();
            }


            /*" -220- MOVE SPACES TO WTEM-SIMOVSIN */
            _.Move("", WTEM_SIMOVSIN);

            /*" -221- IF OUT-COD-RETORNO EQUAL 00 */

            if (LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO == 00)
            {

                /*" -223- PERFORM R1300-00-LE-SI-MOVIMENTO-SINI. */

                R1300_00_LE_SI_MOVIMENTO_SINI_SECTION();
            }


            /*" -224- IF WTEM-SIMOVSIN EQUAL 'N' */

            if (WTEM_SIMOVSIN == "N")
            {

                /*" -226- GO TO R1000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -227- IF OUT-COD-RETORNO EQUAL 00 */

            if (LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO == 00)
            {

                /*" -229- PERFORM R1400-00-MAX-SIPROACO. */

                R1400_00_MAX_SIPROACO_SECTION();
            }


            /*" -230- IF OUT-COD-RETORNO EQUAL 00 */

            if (LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO == 00)
            {

                /*" -232- PERFORM R1500-00-MAX-SICHEPAR. */

                R1500_00_MAX_SICHEPAR_SECTION();
            }


            /*" -233- IF OUT-COD-RETORNO EQUAL 00 */

            if (LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO == 00)
            {

                /*" -234- ADD 1 TO SIPROACO-OCORR-HISTORICO */
                SIPROACO.DCLSI_PROTOCOLO_ACOMP.SIPROACO_OCORR_HISTORICO.Value = SIPROACO.DCLSI_PROTOCOLO_ACOMP.SIPROACO_OCORR_HISTORICO + 1;

                /*" -234- PERFORM R1600-00-INCLUI-SIPROACO. */

                R1600_00_INCLUI_SIPROACO_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-MAX-NUM-OCORRENCIA-SECTION */
        private void R1100_00_MAX_NUM_OCORRENCIA_SECTION()
        {
            /*" -244- MOVE 'R1100' TO ABEND-COD-PROCESSO. */
            _.Move("R1100", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -252- PERFORM R1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1 */

            R1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1();

            /*" -255- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -256- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -257- MOVE SQLCODE TO OUT-COD-RETORNO-SQL */
                _.Move(DB.SQLCODE, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL);

                /*" -259- MOVE 'PTACOM2S - PROBLEMAS NO MAX SI_DOCUMENTO_ACOMP' TO OUT-MENSAGEM */
                _.Move("PTACOM2S - PROBLEMAS NO MAX SI_DOCUMENTO_ACOMP", LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -259- PERFORM R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION();
            }


        }

        [StopWatch]
        /*" R1100-00-MAX-NUM-OCORRENCIA-DB-SELECT-1 */
        public void R1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1()
        {
            /*" -252- EXEC SQL SELECT VALUE(MAX(NUM_OCORR_DOCACO), 0) INTO :SIDOCACO-NUM-OCORR-DOCACO FROM SEGUROS.SI_DOCUMENTO_ACOMP WHERE COD_FONTE = :SIDOCACO-COD-FONTE AND NUM_PROTOCOLO_SINI = :SIDOCACO-NUM-PROTOCOLO-SINI AND DAC_PROTOCOLO_SINI = :SIDOCACO-DAC-PROTOCOLO-SINI AND COD_DOCUMENTO = :SIDOCACO-COD-DOCUMENTO END-EXEC. */

            var r1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1_Query1 = new R1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1_Query1()
            {
                SIDOCACO_NUM_PROTOCOLO_SINI = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_PROTOCOLO_SINI.ToString(),
                SIDOCACO_DAC_PROTOCOLO_SINI = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DAC_PROTOCOLO_SINI.ToString(),
                SIDOCACO_COD_DOCUMENTO = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_DOCUMENTO.ToString(),
                SIDOCACO_COD_FONTE = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_FONTE.ToString(),
            };

            var executed_1 = R1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1_Query1.Execute(r1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SIDOCACO_NUM_OCORR_DOCACO, SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_OCORR_DOCACO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-INCLUI-DOCTO-ACOMP-SECTION */
        private void R1200_00_INCLUI_DOCTO_ACOMP_SECTION()
        {
            /*" -269- MOVE 'R1200' TO ABEND-COD-PROCESSO. */
            _.Move("R1200", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -301- PERFORM R1200_00_INCLUI_DOCTO_ACOMP_DB_INSERT_1 */

            R1200_00_INCLUI_DOCTO_ACOMP_DB_INSERT_1();

            /*" -304- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -305- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -306- MOVE SQLCODE TO OUT-COD-RETORNO-SQL */
                _.Move(DB.SQLCODE, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL);

                /*" -308- MOVE 'PTACOM2S - PROBLEMAS NO INSERT SI_DOCUMENTO_ACOMP' TO OUT-MENSAGEM */
                _.Move("PTACOM2S - PROBLEMAS NO INSERT SI_DOCUMENTO_ACOMP", LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -308- PERFORM R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION();
            }


        }

        [StopWatch]
        /*" R1200-00-INCLUI-DOCTO-ACOMP-DB-INSERT-1 */
        public void R1200_00_INCLUI_DOCTO_ACOMP_DB_INSERT_1()
        {
            /*" -301- EXEC SQL INSERT INTO SEGUROS.SI_DOCUMENTO_ACOMP (COD_FONTE, NUM_PROTOCOLO_SINI, DAC_PROTOCOLO_SINI, COD_DOCUMENTO, NUM_OCORR_DOCACO, COD_PRODUTO, COD_GRUPO_CAUSA, COD_SUBGRUPO_CAUSA, DATA_INIVIG_DOCPAR, COD_EVENTO, DATA_MOVTO_DOCACO, DESCR_COMPLEMENTAR, NUM_CARTA, COD_USUARIO, TIMESTAMP) VALUES (:SIDOCACO-COD-FONTE, :SIDOCACO-NUM-PROTOCOLO-SINI, :SIDOCACO-DAC-PROTOCOLO-SINI, :SIDOCACO-COD-DOCUMENTO, :SIDOCACO-NUM-OCORR-DOCACO, :SIDOCACO-COD-PRODUTO, :SIDOCACO-COD-GRUPO-CAUSA, :SIDOCACO-COD-SUBGRUPO-CAUSA, :SIDOCACO-DATA-INIVIG-DOCPAR, :SIDOCACO-COD-EVENTO, :SIDOCACO-DATA-MOVTO-DOCACO, :SIDOCACO-DESCR-COMPLEMENTAR, :SIDOCACO-NUM-CARTA:VIND-NUM-CARTA, :SIDOCACO-COD-USUARIO, CURRENT TIMESTAMP) END-EXEC. */

            var r1200_00_INCLUI_DOCTO_ACOMP_DB_INSERT_1_Insert1 = new R1200_00_INCLUI_DOCTO_ACOMP_DB_INSERT_1_Insert1()
            {
                SIDOCACO_COD_FONTE = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_FONTE.ToString(),
                SIDOCACO_NUM_PROTOCOLO_SINI = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_PROTOCOLO_SINI.ToString(),
                SIDOCACO_DAC_PROTOCOLO_SINI = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DAC_PROTOCOLO_SINI.ToString(),
                SIDOCACO_COD_DOCUMENTO = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_DOCUMENTO.ToString(),
                SIDOCACO_NUM_OCORR_DOCACO = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_OCORR_DOCACO.ToString(),
                SIDOCACO_COD_PRODUTO = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_PRODUTO.ToString(),
                SIDOCACO_COD_GRUPO_CAUSA = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_GRUPO_CAUSA.ToString(),
                SIDOCACO_COD_SUBGRUPO_CAUSA = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_SUBGRUPO_CAUSA.ToString(),
                SIDOCACO_DATA_INIVIG_DOCPAR = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DATA_INIVIG_DOCPAR.ToString(),
                SIDOCACO_COD_EVENTO = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_EVENTO.ToString(),
                SIDOCACO_DATA_MOVTO_DOCACO = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DATA_MOVTO_DOCACO.ToString(),
                SIDOCACO_DESCR_COMPLEMENTAR = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DESCR_COMPLEMENTAR.ToString(),
                SIDOCACO_NUM_CARTA = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_CARTA.ToString(),
                VIND_NUM_CARTA = VIND_NUM_CARTA.ToString(),
                SIDOCACO_COD_USUARIO = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_USUARIO.ToString(),
            };

            R1200_00_INCLUI_DOCTO_ACOMP_DB_INSERT_1_Insert1.Execute(r1200_00_INCLUI_DOCTO_ACOMP_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-LE-SI-MOVIMENTO-SINI-SECTION */
        private void R1300_00_LE_SI_MOVIMENTO_SINI_SECTION()
        {
            /*" -318- MOVE 'R1300' TO ABEND-COD-PROCESSO. */
            _.Move("R1300", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -325- PERFORM R1300_00_LE_SI_MOVIMENTO_SINI_DB_SELECT_1 */

            R1300_00_LE_SI_MOVIMENTO_SINI_DB_SELECT_1();

            /*" -328- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -329- MOVE 'N' TO WTEM-SIMOVSIN */
                _.Move("N", WTEM_SIMOVSIN);

                /*" -330- ELSE */
            }
            else
            {


                /*" -331- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -332- MOVE 01 TO OUT-COD-RETORNO */
                    _.Move(01, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                    /*" -333- MOVE SQLCODE TO OUT-COD-RETORNO-SQL */
                    _.Move(DB.SQLCODE, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL);

                    /*" -335- MOVE 'PTACOM2S - PROBLEMAS NO SELECT SI_MOVIMENTO_SINI' TO OUT-MENSAGEM */
                    _.Move("PTACOM2S - PROBLEMAS NO SELECT SI_MOVIMENTO_SINI", LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM);

                    /*" -335- PERFORM R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R1300-00-LE-SI-MOVIMENTO-SINI-DB-SELECT-1 */
        public void R1300_00_LE_SI_MOVIMENTO_SINI_DB_SELECT_1()
        {
            /*" -325- EXEC SQL SELECT COD_ESTIPULANTE INTO :SIMOVSIN-COD-ESTIPULANTE FROM SEGUROS.SI_MOVIMENTO_SINI WHERE COD_FONTE = :SIDOCACO-COD-FONTE AND NUM_PROTOCOLO_SINI = :SIDOCACO-NUM-PROTOCOLO-SINI AND DAC_PROTOCOLO_SINI = :SIDOCACO-DAC-PROTOCOLO-SINI END-EXEC. */

            var r1300_00_LE_SI_MOVIMENTO_SINI_DB_SELECT_1_Query1 = new R1300_00_LE_SI_MOVIMENTO_SINI_DB_SELECT_1_Query1()
            {
                SIDOCACO_NUM_PROTOCOLO_SINI = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_PROTOCOLO_SINI.ToString(),
                SIDOCACO_DAC_PROTOCOLO_SINI = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DAC_PROTOCOLO_SINI.ToString(),
                SIDOCACO_COD_FONTE = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_FONTE.ToString(),
            };

            var executed_1 = R1300_00_LE_SI_MOVIMENTO_SINI_DB_SELECT_1_Query1.Execute(r1300_00_LE_SI_MOVIMENTO_SINI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SIMOVSIN_COD_ESTIPULANTE, SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_COD_ESTIPULANTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-MAX-SIPROACO-SECTION */
        private void R1400_00_MAX_SIPROACO_SECTION()
        {
            /*" -345- MOVE 'R1400' TO ABEND-COD-PROCESSO. */
            _.Move("R1400", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -352- PERFORM R1400_00_MAX_SIPROACO_DB_SELECT_1 */

            R1400_00_MAX_SIPROACO_DB_SELECT_1();

            /*" -355- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -356- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -357- MOVE SQLCODE TO OUT-COD-RETORNO-SQL */
                _.Move(DB.SQLCODE, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL);

                /*" -359- MOVE 'PTACOM2S - PROBLEMAS NO MAX SI_PROTOCOLO_ACOMP' TO OUT-MENSAGEM */
                _.Move("PTACOM2S - PROBLEMAS NO MAX SI_PROTOCOLO_ACOMP", LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -359- PERFORM R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION();
            }


        }

        [StopWatch]
        /*" R1400-00-MAX-SIPROACO-DB-SELECT-1 */
        public void R1400_00_MAX_SIPROACO_DB_SELECT_1()
        {
            /*" -352- EXEC SQL SELECT VALUE(MAX(OCORR_HISTORICO), 0) INTO :SIPROACO-OCORR-HISTORICO FROM SEGUROS.SI_PROTOCOLO_ACOMP WHERE COD_FONTE = :SIDOCACO-COD-FONTE AND NUM_PROTOCOLO_SINI = :SIDOCACO-NUM-PROTOCOLO-SINI AND DAC_PROTOCOLO_SINI = :SIDOCACO-DAC-PROTOCOLO-SINI END-EXEC. */

            var r1400_00_MAX_SIPROACO_DB_SELECT_1_Query1 = new R1400_00_MAX_SIPROACO_DB_SELECT_1_Query1()
            {
                SIDOCACO_NUM_PROTOCOLO_SINI = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_PROTOCOLO_SINI.ToString(),
                SIDOCACO_DAC_PROTOCOLO_SINI = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DAC_PROTOCOLO_SINI.ToString(),
                SIDOCACO_COD_FONTE = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_FONTE.ToString(),
            };

            var executed_1 = R1400_00_MAX_SIPROACO_DB_SELECT_1_Query1.Execute(r1400_00_MAX_SIPROACO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SIPROACO_OCORR_HISTORICO, SIPROACO.DCLSI_PROTOCOLO_ACOMP.SIPROACO_OCORR_HISTORICO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-MAX-SICHEPAR-SECTION */
        private void R1500_00_MAX_SICHEPAR_SECTION()
        {
            /*" -369- MOVE 'R1500' TO ABEND-COD-PROCESSO. */
            _.Move("R1500", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -382- PERFORM R1500_00_MAX_SICHEPAR_DB_SELECT_1 */

            R1500_00_MAX_SICHEPAR_DB_SELECT_1();

            /*" -385- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -386- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -387- MOVE SQLCODE TO OUT-COD-RETORNO-SQL */
                _.Move(DB.SQLCODE, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL);

                /*" -389- MOVE 'PTACOM2S - PROBLEMAS NO MAX SI_CHECKLIST_PARAM' TO OUT-MENSAGEM */
                _.Move("PTACOM2S - PROBLEMAS NO MAX SI_CHECKLIST_PARAM", LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -390- DISPLAY 'PTACOM2S - PROBLEMAS NO MAX SI_CHECKLIST_PARAM' */
                _.Display($"PTACOM2S - PROBLEMAS NO MAX SI_CHECKLIST_PARAM");

                /*" -391- DISPLAY 'COD_PRODUTO        = ' SIDOCACO-COD-PRODUTO */
                _.Display($"COD_PRODUTO        = {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_PRODUTO}");

                /*" -392- DISPLAY 'COD_GRUPO_CAUSA    = ' SIDOCACO-COD-GRUPO-CAUSA */
                _.Display($"COD_GRUPO_CAUSA    = {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_GRUPO_CAUSA}");

                /*" -393- DISPLAY 'COD_SUBGRUPO_CAUSA = ' SIDOCACO-COD-SUBGRUPO-CAUSA */
                _.Display($"COD_SUBGRUPO_CAUSA = {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_SUBGRUPO_CAUSA}");

                /*" -394- DISPLAY 'COD_DOCUMENTO      = ' SIDOCACO-COD-DOCUMENTO */
                _.Display($"COD_DOCUMENTO      = {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_DOCUMENTO}");

                /*" -395- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -395- END-IF. */
            }


        }

        [StopWatch]
        /*" R1500-00-MAX-SICHEPAR-DB-SELECT-1 */
        public void R1500_00_MAX_SICHEPAR_DB_SELECT_1()
        {
            /*" -382- EXEC SQL SELECT DATA_INIVIGENCIA, COD_FASE INTO :SICHEPAR-DATA-INIVIGENCIA ,:SICHEPAR-COD-FASE FROM SEGUROS.SI_CHECKLIST_PARAM WHERE COD_PRODUTO = :SIDOCACO-COD-PRODUTO AND COD_GRUPO_CAUSA = :SIDOCACO-COD-GRUPO-CAUSA AND COD_SUBGRUPO_CAUSA = :SIDOCACO-COD-SUBGRUPO-CAUSA AND COD_DOCUMENTO = :SIDOCACO-COD-DOCUMENTO AND NUM_PARTICIPANTE = 3 AND COD_FASE IN (2, 3) FETCH FIRST 01 ROWS ONLY END-EXEC. */

            var r1500_00_MAX_SICHEPAR_DB_SELECT_1_Query1 = new R1500_00_MAX_SICHEPAR_DB_SELECT_1_Query1()
            {
                SIDOCACO_COD_SUBGRUPO_CAUSA = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_SUBGRUPO_CAUSA.ToString(),
                SIDOCACO_COD_GRUPO_CAUSA = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_GRUPO_CAUSA.ToString(),
                SIDOCACO_COD_DOCUMENTO = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_DOCUMENTO.ToString(),
                SIDOCACO_COD_PRODUTO = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_PRODUTO.ToString(),
            };

            var executed_1 = R1500_00_MAX_SICHEPAR_DB_SELECT_1_Query1.Execute(r1500_00_MAX_SICHEPAR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SICHEPAR_DATA_INIVIGENCIA, SICHEPAR.DCLSI_CHECKLIST_PARAM.SICHEPAR_DATA_INIVIGENCIA);
                _.Move(executed_1.SICHEPAR_COD_FASE, SICHEPAR.DCLSI_CHECKLIST_PARAM.SICHEPAR_COD_FASE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-INCLUI-SIPROACO-SECTION */
        private void R1600_00_INCLUI_SIPROACO_SECTION()
        {
            /*" -404- MOVE 'R1600' TO ABEND-COD-PROCESSO. */
            _.Move("R1600", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -406- MOVE SICHEPAR-COD-FASE TO SIPROACO-COD-FASE */
            _.Move(SICHEPAR.DCLSI_CHECKLIST_PARAM.SICHEPAR_COD_FASE, SIPROACO.DCLSI_PROTOCOLO_ACOMP.SIPROACO_COD_FASE);

            /*" -452- PERFORM R1600_00_INCLUI_SIPROACO_DB_INSERT_1 */

            R1600_00_INCLUI_SIPROACO_DB_INSERT_1();

            /*" -455- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -456- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -457- MOVE SQLCODE TO OUT-COD-RETORNO-SQL */
                _.Move(DB.SQLCODE, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL);

                /*" -459- MOVE 'PTACOM2S - PROBLEMAS NO INSERT SI_PROTOCOLO_ACOMP' TO OUT-MENSAGEM */
                _.Move("PTACOM2S - PROBLEMAS NO INSERT SI_PROTOCOLO_ACOMP", LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -460- DISPLAY 'PTACOM2S - ERRO NO INSERT SI_PROTOCOLO_ACOMP' */
                _.Display($"PTACOM2S - ERRO NO INSERT SI_PROTOCOLO_ACOMP");

                /*" -461- DISPLAY 'COD-FONTE           = ' SIDOCACO-COD-FONTE */
                _.Display($"COD-FONTE           = {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_FONTE}");

                /*" -463- DISPLAY 'NUM-PROTOCOLO-SINI  = ' SIDOCACO-NUM-PROTOCOLO-SINI */
                _.Display($"NUM-PROTOCOLO-SINI  = {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_PROTOCOLO_SINI}");

                /*" -465- DISPLAY 'DAC-PROTOCOLO-SINI  = ' SIDOCACO-DAC-PROTOCOLO-SINI */
                _.Display($"DAC-PROTOCOLO-SINI  = {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DAC_PROTOCOLO_SINI}");

                /*" -466- DISPLAY 'OCORR-HISTORICO     = ' SIPROACO-OCORR-HISTORICO */
                _.Display($"OCORR-HISTORICO     = {SIPROACO.DCLSI_PROTOCOLO_ACOMP.SIPROACO_OCORR_HISTORICO}");

                /*" -467- DISPLAY 'DATA-INIVIGENCIA    = ' SICHEPAR-DATA-INIVIGENCIA */
                _.Display($"DATA-INIVIGENCIA    = {SICHEPAR.DCLSI_CHECKLIST_PARAM.SICHEPAR_DATA_INIVIGENCIA}");

                /*" -469- DISPLAY 'DATA-MOVTO-DOCACO   = ' SIDOCACO-DATA-MOVTO-DOCACO */
                _.Display($"DATA-MOVTO-DOCACO   = {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DATA_MOVTO_DOCACO}");

                /*" -470- DISPLAY 'COD-PRODUTO         = ' SIDOCACO-COD-PRODUTO */
                _.Display($"COD-PRODUTO         = {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_PRODUTO}");

                /*" -471- DISPLAY 'COD-GRUPO-CAUSA     = ' SIDOCACO-COD-GRUPO-CAUSA */
                _.Display($"COD-GRUPO-CAUSA     = {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_GRUPO_CAUSA}");

                /*" -473- DISPLAY 'COD-SUBGRUPO-CAUSA  = ' SIDOCACO-COD-SUBGRUPO-CAUSA */
                _.Display($"COD-SUBGRUPO-CAUSA  = {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_SUBGRUPO_CAUSA}");

                /*" -474- DISPLAY 'COD-ESTIPULANTE     = ' SIMOVSIN-COD-ESTIPULANTE */
                _.Display($"COD-ESTIPULANTE     = {SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_COD_ESTIPULANTE}");

                /*" -475- DISPLAY 'COD-DOCUMENTO       = ' SIDOCACO-COD-DOCUMENTO */
                _.Display($"COD-DOCUMENTO       = {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_DOCUMENTO}");

                /*" -476- DISPLAY 'COD-FASE            = ' SIPROACO-COD-FASE */
                _.Display($"COD-FASE            = {SIPROACO.DCLSI_PROTOCOLO_ACOMP.SIPROACO_COD_FASE}");

                /*" -477- DISPLAY 'COD-EVENTO          = ' SIDOCACO-COD-EVENTO */
                _.Display($"COD-EVENTO          = {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_EVENTO}");

                /*" -478- DISPLAY 'NUM-CARTA           = ' SIDOCACO-NUM-CARTA */
                _.Display($"NUM-CARTA           = {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_CARTA}");

                /*" -479- DISPLAY 'OCORR-HISTORICO     = ' SIPROACO-OCORR-HISTORICO */
                _.Display($"OCORR-HISTORICO     = {SIPROACO.DCLSI_PROTOCOLO_ACOMP.SIPROACO_OCORR_HISTORICO}");

                /*" -480- DISPLAY 'COD-USUARIO         = ' SIDOCACO-COD-USUARIO */
                _.Display($"COD-USUARIO         = {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_USUARIO}");

                /*" -481- DISPLAY '---------------------------------------------' */
                _.Display($"---------------------------------------------");

                /*" -481- PERFORM R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION();
            }


        }

        [StopWatch]
        /*" R1600-00-INCLUI-SIPROACO-DB-INSERT-1 */
        public void R1600_00_INCLUI_SIPROACO_DB_INSERT_1()
        {
            /*" -452- EXEC SQL INSERT INTO SEGUROS.SI_PROTOCOLO_ACOMP (COD_FONTE, NUM_PROTOCOLO_SINI, DAC_PROTOCOLO_SINI, OCORR_HISTORICO, DATA_INIVIGENCIA, DATA_MOVIMENTO, COD_PRODUTO, COD_GRUPO_CAUSA, COD_SUBGRUPO_CAUSA, NUM_PARTICIPANTE, COD_CLIENTE, COD_DOCUMENTO, COD_FASE, COD_EVENTO, NUM_CARTA, OCORR_HIST_PAI, COD_USUARIO, TIMESTAMP, NOM_SISTEMA_ORIGEM, NOM_PROGRAMA, STA_INTEGRA_AMSS) VALUES (:SIDOCACO-COD-FONTE, :SIDOCACO-NUM-PROTOCOLO-SINI, :SIDOCACO-DAC-PROTOCOLO-SINI, :SIPROACO-OCORR-HISTORICO, :SICHEPAR-DATA-INIVIGENCIA, :SIDOCACO-DATA-MOVTO-DOCACO, :SIDOCACO-COD-PRODUTO, :SIDOCACO-COD-GRUPO-CAUSA, :SIDOCACO-COD-SUBGRUPO-CAUSA, 3, :SIMOVSIN-COD-ESTIPULANTE, :SIDOCACO-COD-DOCUMENTO, :SIPROACO-COD-FASE, :SIDOCACO-COD-EVENTO, :SIDOCACO-NUM-CARTA:VIND-NUM-CARTA, :SIPROACO-OCORR-HISTORICO, :SIDOCACO-COD-USUARIO, CURRENT TIMESTAMP, 'SISWEB' , 'PTACOM2S' , 'N' ) END-EXEC. */

            var r1600_00_INCLUI_SIPROACO_DB_INSERT_1_Insert1 = new R1600_00_INCLUI_SIPROACO_DB_INSERT_1_Insert1()
            {
                SIDOCACO_COD_FONTE = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_FONTE.ToString(),
                SIDOCACO_NUM_PROTOCOLO_SINI = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_PROTOCOLO_SINI.ToString(),
                SIDOCACO_DAC_PROTOCOLO_SINI = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DAC_PROTOCOLO_SINI.ToString(),
                SIPROACO_OCORR_HISTORICO = SIPROACO.DCLSI_PROTOCOLO_ACOMP.SIPROACO_OCORR_HISTORICO.ToString(),
                SICHEPAR_DATA_INIVIGENCIA = SICHEPAR.DCLSI_CHECKLIST_PARAM.SICHEPAR_DATA_INIVIGENCIA.ToString(),
                SIDOCACO_DATA_MOVTO_DOCACO = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DATA_MOVTO_DOCACO.ToString(),
                SIDOCACO_COD_PRODUTO = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_PRODUTO.ToString(),
                SIDOCACO_COD_GRUPO_CAUSA = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_GRUPO_CAUSA.ToString(),
                SIDOCACO_COD_SUBGRUPO_CAUSA = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_SUBGRUPO_CAUSA.ToString(),
                SIMOVSIN_COD_ESTIPULANTE = SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_COD_ESTIPULANTE.ToString(),
                SIDOCACO_COD_DOCUMENTO = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_DOCUMENTO.ToString(),
                SIPROACO_COD_FASE = SIPROACO.DCLSI_PROTOCOLO_ACOMP.SIPROACO_COD_FASE.ToString(),
                SIDOCACO_COD_EVENTO = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_EVENTO.ToString(),
                SIDOCACO_NUM_CARTA = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_CARTA.ToString(),
                VIND_NUM_CARTA = VIND_NUM_CARTA.ToString(),
                SIDOCACO_COD_USUARIO = SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_USUARIO.ToString(),
            };

            R1600_00_INCLUI_SIPROACO_DB_INSERT_1_Insert1.Execute(r1600_00_INCLUI_SIPROACO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -490- MOVE 'PTACOM2S' TO ABEND-COD-APLICACAO */
            _.Move("PTACOM2S", ABEND.DCLABEND.ABEND_COD_APLICACAO);

            /*" -490- MOVE IN-USUARIO TO ABEND-COD-USUARIO OF DCLABEND */
            _.Move(LBWCT001.PROTOCOLO_RECEBIDO.IN_USUARIO, ABEND.DCLABEND.ABEND_COD_USUARIO);

            /*" -490- MOVE SQLCODE TO ABEND-SQLCODE OF DCLABEND */
            _.Move(DB.SQLCODE, ABEND.DCLABEND.ABEND_SQLCODE);

            /*" -490- MOVE SQLERRMC TO ABEND-SQLERRMC OF DCLABEND */
            _.Move(DB.SQLERRMC, ABEND.DCLABEND.ABEND_SQLERRMC);

            /*" -490- MOVE SQLSTATE TO ABEND-SQLEXT OF DCLABEND. */
            _.Move(DB.SQLSTATE, ABEND.DCLABEND.ABEND_SQLEXT);

            /*" -490- CALL 'PTABEN1S' USING DCLABEND, PROTOCOLO-ENVIO. */
            _.Call("PTABEN1S", ABEND.DCLABEND, LBWCT002.PROTOCOLO_ENVIO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}