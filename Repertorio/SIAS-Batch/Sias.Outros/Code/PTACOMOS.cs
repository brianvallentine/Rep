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
using Sias.Outros.DB2.PTACOMOS;

namespace Code
{
    public class PTACOMOS
    {
        public bool IsCall { get; set; }

        public PTACOMOS()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................ SINISTRO                            *      */
        /*"      *   SUBROTINA............... PTACOMOS                            *      */
        /*"      *   ANALISTA ............... PRODEXTER                           *      */
        /*"      *   PROGRAMADOR ............ PRODEXTER                           *      */
        /*"      *   DATA CODIFICACAO ....... AGO / 2001                          *      */
        /*"      *   FUNCAO ................. MANTEM DADOS DA SI_SINISTRO_ACOMP   *      */
        /*"      *   AMBIENTE................ BATCH E ONLINE                      *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        /*"01 AX-SQLCODE                 PIC -9999.*/
        public IntBasis AX_SQLCODE { get; set; } = new IntBasis(new PIC("9", "4", "-9999."));
        /*"01 WS-SQLCODE                 PIC ---9.*/
        public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("9", "4", "---9."));
        /*"01             IND-NUM-CARTA         PIC S9(004) COMP.*/
        public IntBasis IND_NUM_CARTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01             WTEM-SIMOVSIN         PIC  X(001) VALUE SPACES.*/
        public StringBasis WTEM_SIMOVSIN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");


        public Copies.LBWCT001 LBWCT001 { get; set; } = new Copies.LBWCT001();
        public Copies.LBWCT002 LBWCT002 { get; set; } = new Copies.LBWCT002();
        public Dclgens.ABEND ABEND { get; set; } = new Dclgens.ABEND();
        public Dclgens.SICHEPAR SICHEPAR { get; set; } = new Dclgens.SICHEPAR();
        public Dclgens.SIPROACO SIPROACO { get; set; } = new Dclgens.SIPROACO();
        public Dclgens.SIPARTIC SIPARTIC { get; set; } = new Dclgens.SIPARTIC();
        public Dclgens.SIMOVSIN SIMOVSIN { get; set; } = new Dclgens.SIMOVSIN();
        public Dclgens.SINISCAU SINISCAU { get; set; } = new Dclgens.SINISCAU();
        public Dclgens.SISINACO SISINACO { get; set; } = new Dclgens.SISINACO();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(LBWCT001_PROTOCOLO_RECEBIDO LBWCT001_PROTOCOLO_RECEBIDO_P, SISINACO_DCLSI_SINISTRO_ACOMP SISINACO_DCLSI_SINISTRO_ACOMP_P, LBWCT002_PROTOCOLO_ENVIO LBWCT002_PROTOCOLO_ENVIO_P) //PROCEDURE DIVISION USING 
        /*PROTOCOLO_RECEBIDO
        DCLSI_SINISTRO_ACOMP
        PROTOCOLO_ENVIO*/
        {
            try
            {
                this.LBWCT001.PROTOCOLO_RECEBIDO = LBWCT001_PROTOCOLO_RECEBIDO_P;
                this.SISINACO.DCLSI_SINISTRO_ACOMP = SISINACO_DCLSI_SINISTRO_ACOMP_P;
                this.LBWCT002.PROTOCOLO_ENVIO = LBWCT002_PROTOCOLO_ENVIO_P;

                /*" -74- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -75- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -76- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -76- FLUXCONTROL_PERFORM R0000-00-INICIO-SECTION */

                R0000_00_INICIO_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LBWCT001.PROTOCOLO_RECEBIDO, SISINACO.DCLSI_SINISTRO_ACOMP, LBWCT002.PROTOCOLO_ENVIO };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-INICIO-SECTION */
        private void R0000_00_INICIO_SECTION()
        {
            /*" -85- INITIALIZE PROTOCOLO-ENVIO, DCLABEND */
            _.Initialize(
                LBWCT002.PROTOCOLO_ENVIO
                , ABEND.DCLABEND
            );

            /*" -92- DISPLAY 'PTACOMOS VERSAO 2 - INICIO PROCESSAMENTO EM  ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"PTACOMOS VERSAO 2 - INICIO PROCESSAMENTO EM  {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -94- DISPLAY ' ' */
            _.Display($" ");

            /*" -95- DISPLAY 'PTACOMOS - DADOS RECEBIDOS -----------------------' */
            _.Display($"PTACOMOS - DADOS RECEBIDOS -----------------------");

            /*" -97- PERFORM R9000-00-DISPLAY-PARM */

            R9000_00_DISPLAY_PARM_SECTION();

            /*" -99- PERFORM R0100-00-VERIFICA-PARAMETROS */

            R0100_00_VERIFICA_PARAMETROS_SECTION();

            /*" -100- IF OUT-COD-RETORNO EQUAL 01 */

            if (LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO == 01)
            {

                /*" -102- GO TO R0000-10-SAIDA. */

                R0000_10_SAIDA(); //GOTO
                return;
            }


            /*" -103- IF IN-OPERACAO EQUAL 1 */

            if (LBWCT001.PROTOCOLO_RECEBIDO.IN_OPERACAO == 1)
            {

                /*" -104- PERFORM R1000-00-PROCESSA-INCLUSAO */

                R1000_00_PROCESSA_INCLUSAO_SECTION();

                /*" -105- ELSE */
            }
            else
            {


                /*" -106- IF IN-OPERACAO EQUAL 3 */

                if (LBWCT001.PROTOCOLO_RECEBIDO.IN_OPERACAO == 3)
                {

                    /*" -107- PERFORM R2000-00-PROCESSA-EXCLUSAO */

                    R2000_00_PROCESSA_EXCLUSAO_SECTION();

                    /*" -108- ELSE */
                }
                else
                {


                    /*" -109- MOVE 01 TO OUT-COD-RETORNO */
                    _.Move(01, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                    /*" -110- MOVE 'PTACOMOS - OPERACAO NAO PREVISTA' TO OUT-MENSAGEM. */
                    _.Move("PTACOMOS - OPERACAO NAO PREVISTA", LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM);
                }

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
            /*" -123- IF SISINACO-COD-FONTE EQUAL ZEROS */

            if (SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_FONTE == 00)
            {

                /*" -124- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -126- MOVE 'PTACOMOS - CODIGO DA FONTE NAO INFORMADO' TO OUT-MENSAGEM */
                _.Move("PTACOMOS - CODIGO DA FONTE NAO INFORMADO", LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -128- GO TO R0100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -130- IF SISINACO-NUM-PROTOCOLO-SINI EQUAL ZEROS */

            if (SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_PROTOCOLO_SINI == 00)
            {

                /*" -131- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -133- MOVE 'PTACOMOS - NUMERO DO PROTOCOLO NAO INFORMADO' TO OUT-MENSAGEM */
                _.Move("PTACOMOS - NUMERO DO PROTOCOLO NAO INFORMADO", LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -135- GO TO R0100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -137- IF IN-OPERACAO EQUAL 1 AND SISINACO-COD-EVENTO EQUAL ZEROS */

            if (LBWCT001.PROTOCOLO_RECEBIDO.IN_OPERACAO == 1 && SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_EVENTO == 00)
            {

                /*" -138- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -140- MOVE 'PTACOMOS - CODIGO DO EVENTO NAO INFORMADO' TO OUT-MENSAGEM */
                _.Move("PTACOMOS - CODIGO DO EVENTO NAO INFORMADO", LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -142- GO TO R0100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -145- IF IN-OPERACAO EQUAL 1 AND SISINACO-DATA-MOVTO-SINIACO EQUAL SPACES */

            if (LBWCT001.PROTOCOLO_RECEBIDO.IN_OPERACAO == 1 && SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DATA_MOVTO_SINIACO.IsEmpty())
            {

                /*" -146- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -148- MOVE 'PTACOMOS - DATA DE MOVIMENTO NAO INFORMADA' TO OUT-MENSAGEM */
                _.Move("PTACOMOS - DATA DE MOVIMENTO NAO INFORMADA", LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -150- GO TO R0100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -153- IF IN-OPERACAO EQUAL 3 AND SISINACO-NUM-OCORR-SINIACO EQUAL ZEROS */

            if (LBWCT001.PROTOCOLO_RECEBIDO.IN_OPERACAO == 3 && SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_OCORR_SINIACO == 00)
            {

                /*" -154- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -156- MOVE 'PTACOMOS - OCORRENCIA DO HISTORICO NAO INFORMADA' TO OUT-MENSAGEM */
                _.Move("PTACOMOS - OCORRENCIA DO HISTORICO NAO INFORMADA", LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -156- GO TO R0100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-FORMATA-SAIDA-SECTION */
        private void R0200_00_FORMATA_SAIDA_SECTION()
        {
            /*" -167- MOVE SQLERRMC TO OUT-SQLERRMC */
            _.Move(DB.SQLERRMC, LBWCT002.PROTOCOLO_ENVIO.OUT_SQLERRMC);

            /*" -168- MOVE SQLSTATE TO OUT-SQLSTATE. */
            _.Move(DB.SQLSTATE, LBWCT002.PROTOCOLO_ENVIO.OUT_SQLSTATE);

            /*" -169- DISPLAY 'PTACOMOS - DADOS RETORNADOS ----------------------' */
            _.Display($"PTACOMOS - DADOS RETORNADOS ----------------------");

            /*" -169- PERFORM R9000-00-DISPLAY-PARM. */

            R9000_00_DISPLAY_PARM_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-INCLUSAO-SECTION */
        private void R1000_00_PROCESSA_INCLUSAO_SECTION()
        {
            /*" -178- DISPLAY 'ENTROU NO R1000-00-PROCESSA-INCLUSAO' */
            _.Display($"ENTROU NO R1000-00-PROCESSA-INCLUSAO");

            /*" -180- MOVE 'R1000' TO ABEND-COD-PROCESSO. */
            _.Move("R1000", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -181- IF SISINACO-NUM-CARTA EQUAL ZEROS */

            if (SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_CARTA == 00)
            {

                /*" -182- MOVE -1 TO IND-NUM-CARTA */
                _.Move(-1, IND_NUM_CARTA);

                /*" -183- ELSE */
            }
            else
            {


                /*" -185- MOVE ZEROS TO IND-NUM-CARTA. */
                _.Move(0, IND_NUM_CARTA);
            }


            /*" -187- PERFORM R1100-00-MAX-NUM-OCORRENCIA */

            R1100_00_MAX_NUM_OCORRENCIA_SECTION();

            /*" -188- IF OUT-COD-RETORNO EQUAL 00 */

            if (LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO == 00)
            {

                /*" -189- ADD 1 TO SISINACO-NUM-OCORR-SINIACO */
                SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_OCORR_SINIACO.Value = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_OCORR_SINIACO + 1;

                /*" -193- PERFORM R1200-00-INCLUI-SINI-ACOMP. */

                R1200_00_INCLUI_SINI_ACOMP_SECTION();
            }


            /*" -195- MOVE SPACES TO WTEM-SIMOVSIN */
            _.Move("", WTEM_SIMOVSIN);

            /*" -196- IF OUT-COD-RETORNO EQUAL 00 */

            if (LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO == 00)
            {

                /*" -198- PERFORM R1300-00-LE-SI-MOVIMENTO-SINI. */

                R1300_00_LE_SI_MOVIMENTO_SINI_SECTION();
            }


            /*" -200- IF WTEM-SIMOVSIN EQUAL 'N' OR SIMOVSIN-RAMO-EMISSOR EQUAL 66 */

            if (WTEM_SIMOVSIN == "N" || SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_RAMO_EMISSOR == 66)
            {

                /*" -202- GO TO R1000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -205- IF OUT-COD-RETORNO EQUAL 00 AND SISINACO-NUM-OCORR-SINIACO EQUAL 1 */

            if (LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO == 00 && SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_OCORR_SINIACO == 1)
            {

                /*" -207- PERFORM R1400-00-INCLUI-SIPARTIC. */

                R1400_00_INCLUI_SIPARTIC_SECTION();
            }


            /*" -208- IF OUT-COD-RETORNO EQUAL 00 */

            if (LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO == 00)
            {

                /*" -210- PERFORM R1500-00-MAX-SIPROACO. */

                R1500_00_MAX_SIPROACO_SECTION();
            }


            /*" -211- IF OUT-COD-RETORNO EQUAL 00 */

            if (LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO == 00)
            {

                /*" -213- PERFORM R1600-00-LE-SINISCAU. */

                R1600_00_LE_SINISCAU_SECTION();
            }


            /*" -214- IF OUT-COD-RETORNO EQUAL 00 */

            if (LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO == 00)
            {

                /*" -216- PERFORM R1700-00-MAX-SICHEPAR. */

                R1700_00_MAX_SICHEPAR_SECTION();
            }


            /*" -217- IF OUT-COD-RETORNO EQUAL 00 */

            if (LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO == 00)
            {

                /*" -218- ADD 1 TO SIPROACO-OCORR-HISTORICO */
                SIPROACO.DCLSI_PROTOCOLO_ACOMP.SIPROACO_OCORR_HISTORICO.Value = SIPROACO.DCLSI_PROTOCOLO_ACOMP.SIPROACO_OCORR_HISTORICO + 1;

                /*" -219- PERFORM R1800-00-INCLUI-SIPROACO. */

                R1800_00_INCLUI_SIPROACO_SECTION();
            }


            /*" -219- DISPLAY 'SAIU DO R1000-00-PROCESSA-INCLUSAO' . */
            _.Display($"SAIU DO R1000-00-PROCESSA-INCLUSAO");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-MAX-NUM-OCORRENCIA-SECTION */
        private void R1100_00_MAX_NUM_OCORRENCIA_SECTION()
        {
            /*" -228- MOVE 'R1100' TO ABEND-COD-PROCESSO. */
            _.Move("R1100", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -229- DISPLAY 'ENTROU NO R1100-00-MAX-NUM-OCORRENCIA' */
            _.Display($"ENTROU NO R1100-00-MAX-NUM-OCORRENCIA");

            /*" -230- DISPLAY '-- CHAVE DE ACESSO A TABELA SI_SINISTRO_ACOMP-----' */
            _.Display($"-- CHAVE DE ACESSO A TABELA SI_SINISTRO_ACOMP-----");

            /*" -231- DISPLAY 'COD_FONTE           = ' SISINACO-COD-FONTE */
            _.Display($"COD_FONTE           = {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_FONTE}");

            /*" -232- DISPLAY 'NUM_PROTOCOLO_SINI  = ' SISINACO-NUM-PROTOCOLO-SINI */
            _.Display($"NUM_PROTOCOLO_SINI  = {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_PROTOCOLO_SINI}");

            /*" -233- DISPLAY 'DAC_PROTOCOLO_SINI  = ' SISINACO-DAC-PROTOCOLO-SINI */
            _.Display($"DAC_PROTOCOLO_SINI  = {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DAC_PROTOCOLO_SINI}");

            /*" -235- DISPLAY '--------------------------------------------------' */
            _.Display($"--------------------------------------------------");

            /*" -242- PERFORM R1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1 */

            R1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1();

            /*" -245- MOVE SQLCODE TO WS-SQLCODE */
            _.Move(DB.SQLCODE, WS_SQLCODE);

            /*" -246- DISPLAY 'SQLCODE DO MAX(NUM_OCORR_SINIACO) = ' WS-SQLCODE */
            _.Display($"SQLCODE DO MAX(NUM_OCORR_SINIACO) = {WS_SQLCODE}");

            /*" -249- DISPLAY 'SISINACO-NUM-OCORR-SINIACO = ' SISINACO-NUM-OCORR-SINIACO */
            _.Display($"SISINACO-NUM-OCORR-SINIACO = {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_OCORR_SINIACO}");

            /*" -250- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -251- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -252- MOVE SQLCODE TO OUT-COD-RETORNO-SQL */
                _.Move(DB.SQLCODE, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL);

                /*" -254- MOVE 'PTACOMOS - PROBLEMAS NO MAX SI_SINISTRO_ACOMP' TO OUT-MENSAGEM */
                _.Move("PTACOMOS - PROBLEMAS NO MAX SI_SINISTRO_ACOMP", LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -255- DISPLAY 'PTACOMOS - PROBLEMAS NO MAX SI_SINISTRO_ACOMP' */
                _.Display($"PTACOMOS - PROBLEMAS NO MAX SI_SINISTRO_ACOMP");

                /*" -256- DISPLAY 'SQLCODE             = ' WS-SQLCODE */
                _.Display($"SQLCODE             = {WS_SQLCODE}");

                /*" -257- DISPLAY 'COD_FONTE           = ' SISINACO-COD-FONTE */
                _.Display($"COD_FONTE           = {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_FONTE}");

                /*" -259- DISPLAY 'NUM_PROTOCOLO_SINI  = ' SISINACO-NUM-PROTOCOLO-SINI */
                _.Display($"NUM_PROTOCOLO_SINI  = {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_PROTOCOLO_SINI}");

                /*" -261- DISPLAY 'DAC_PROTOCOLO_SINI  = ' SISINACO-DAC-PROTOCOLO-SINI */
                _.Display($"DAC_PROTOCOLO_SINI  = {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DAC_PROTOCOLO_SINI}");

                /*" -262- DISPLAY '---------------------------------------------' */
                _.Display($"---------------------------------------------");

                /*" -263- PERFORM R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION();
            }


            /*" -263- DISPLAY 'SAIU DO R1100-00-MAX-NUM-OCORRENCIA' . */
            _.Display($"SAIU DO R1100-00-MAX-NUM-OCORRENCIA");

        }

        [StopWatch]
        /*" R1100-00-MAX-NUM-OCORRENCIA-DB-SELECT-1 */
        public void R1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1()
        {
            /*" -242- EXEC SQL SELECT VALUE(MAX(NUM_OCORR_SINIACO), 0) INTO :SISINACO-NUM-OCORR-SINIACO FROM SEGUROS.SI_SINISTRO_ACOMP WHERE COD_FONTE = :SISINACO-COD-FONTE AND NUM_PROTOCOLO_SINI = :SISINACO-NUM-PROTOCOLO-SINI AND DAC_PROTOCOLO_SINI = :SISINACO-DAC-PROTOCOLO-SINI END-EXEC. */

            var r1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1_Query1 = new R1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1_Query1()
            {
                SISINACO_NUM_PROTOCOLO_SINI = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_PROTOCOLO_SINI.ToString(),
                SISINACO_DAC_PROTOCOLO_SINI = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DAC_PROTOCOLO_SINI.ToString(),
                SISINACO_COD_FONTE = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_FONTE.ToString(),
            };

            var executed_1 = R1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1_Query1.Execute(r1100_00_MAX_NUM_OCORRENCIA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISINACO_NUM_OCORR_SINIACO, SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_OCORR_SINIACO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-INCLUI-SINI-ACOMP-SECTION */
        private void R1200_00_INCLUI_SINI_ACOMP_SECTION()
        {
            /*" -272- MOVE 'R1200' TO ABEND-COD-PROCESSO. */
            _.Move("R1200", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -274- DISPLAY 'ENTROU NO R1200-00-INCLUI-SINI-ACOMP ' */
            _.Display($"ENTROU NO R1200-00-INCLUI-SINI-ACOMP ");

            /*" -275- DISPLAY 'DADOS A SEREM INCLUIDOS NA SI_SINISTRO_ACOMP' */
            _.Display($"DADOS A SEREM INCLUIDOS NA SI_SINISTRO_ACOMP");

            /*" -277- PERFORM R9100-00-DISPLAY-DADOS */

            R9100_00_DISPLAY_DADOS_SECTION();

            /*" -299- PERFORM R1200_00_INCLUI_SINI_ACOMP_DB_INSERT_1 */

            R1200_00_INCLUI_SINI_ACOMP_DB_INSERT_1();

            /*" -302- MOVE SQLCODE TO WS-SQLCODE */
            _.Move(DB.SQLCODE, WS_SQLCODE);

            /*" -305- DISPLAY 'SQLCODE DO INSERT NA SI_SINISTRO_ACOMP = ' WS-SQLCODE */
            _.Display($"SQLCODE DO INSERT NA SI_SINISTRO_ACOMP = {WS_SQLCODE}");

            /*" -306- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -307- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -308- MOVE SQLCODE TO OUT-COD-RETORNO-SQL */
                _.Move(DB.SQLCODE, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL);

                /*" -310- MOVE 'PTACOMOS - PROBLEMAS NO INSERT SI_SINISTRO_ACOMP' TO OUT-MENSAGEM */
                _.Move("PTACOMOS - PROBLEMAS NO INSERT SI_SINISTRO_ACOMP", LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -311- DISPLAY 'PTACOMOS - PROBLEMAS NO INSERT SI_SINISTRO_ACOMP' */
                _.Display($"PTACOMOS - PROBLEMAS NO INSERT SI_SINISTRO_ACOMP");

                /*" -312- DISPLAY 'SQLCODE          = ' WS-SQLCODE */
                _.Display($"SQLCODE          = {WS_SQLCODE}");

                /*" -312- PERFORM R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION();
            }


        }

        [StopWatch]
        /*" R1200-00-INCLUI-SINI-ACOMP-DB-INSERT-1 */
        public void R1200_00_INCLUI_SINI_ACOMP_DB_INSERT_1()
        {
            /*" -299- EXEC SQL INSERT INTO SEGUROS.SI_SINISTRO_ACOMP (COD_FONTE, NUM_PROTOCOLO_SINI, DAC_PROTOCOLO_SINI, NUM_OCORR_SINIACO, COD_EVENTO, DATA_MOVTO_SINIACO, DESCR_COMPLEMENTAR, COD_USUARIO, TIMESTAMP, NUM_CARTA) VALUES (:SISINACO-COD-FONTE, :SISINACO-NUM-PROTOCOLO-SINI, :SISINACO-DAC-PROTOCOLO-SINI, :SISINACO-NUM-OCORR-SINIACO, :SISINACO-COD-EVENTO, :SISINACO-DATA-MOVTO-SINIACO, :SISINACO-DESCR-COMPLEMENTAR, :SISINACO-COD-USUARIO, CURRENT TIMESTAMP, :SISINACO-NUM-CARTA:IND-NUM-CARTA) END-EXEC. */

            var r1200_00_INCLUI_SINI_ACOMP_DB_INSERT_1_Insert1 = new R1200_00_INCLUI_SINI_ACOMP_DB_INSERT_1_Insert1()
            {
                SISINACO_COD_FONTE = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_FONTE.ToString(),
                SISINACO_NUM_PROTOCOLO_SINI = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_PROTOCOLO_SINI.ToString(),
                SISINACO_DAC_PROTOCOLO_SINI = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DAC_PROTOCOLO_SINI.ToString(),
                SISINACO_NUM_OCORR_SINIACO = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_OCORR_SINIACO.ToString(),
                SISINACO_COD_EVENTO = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_EVENTO.ToString(),
                SISINACO_DATA_MOVTO_SINIACO = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DATA_MOVTO_SINIACO.ToString(),
                SISINACO_DESCR_COMPLEMENTAR = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DESCR_COMPLEMENTAR.ToString(),
                SISINACO_COD_USUARIO = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_USUARIO.ToString(),
                SISINACO_NUM_CARTA = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_CARTA.ToString(),
                IND_NUM_CARTA = IND_NUM_CARTA.ToString(),
            };

            R1200_00_INCLUI_SINI_ACOMP_DB_INSERT_1_Insert1.Execute(r1200_00_INCLUI_SINI_ACOMP_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-LE-SI-MOVIMENTO-SINI-SECTION */
        private void R1300_00_LE_SI_MOVIMENTO_SINI_SECTION()
        {
            /*" -321- MOVE 'R1300' TO ABEND-COD-PROCESSO. */
            _.Move("R1300", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -322- DISPLAY 'ENTROU NO R1300-00-LE-SI-MOVIMENTO-SINI' */
            _.Display($"ENTROU NO R1300-00-LE-SI-MOVIMENTO-SINI");

            /*" -323- DISPLAY '-- CHAVE DE ACESSO A TABELA SI_MOVIMENTO_SINI-----' */
            _.Display($"-- CHAVE DE ACESSO A TABELA SI_MOVIMENTO_SINI-----");

            /*" -324- DISPLAY 'COD_FONTE           = ' SISINACO-COD-FONTE */
            _.Display($"COD_FONTE           = {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_FONTE}");

            /*" -325- DISPLAY 'NUM_PROTOCOLO_SINI  = ' SISINACO-NUM-PROTOCOLO-SINI */
            _.Display($"NUM_PROTOCOLO_SINI  = {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_PROTOCOLO_SINI}");

            /*" -326- DISPLAY 'DAC_PROTOCOLO_SINI  = ' SISINACO-DAC-PROTOCOLO-SINI */
            _.Display($"DAC_PROTOCOLO_SINI  = {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DAC_PROTOCOLO_SINI}");

            /*" -328- DISPLAY '--------------------------------------------------' */
            _.Display($"--------------------------------------------------");

            /*" -341- PERFORM R1300_00_LE_SI_MOVIMENTO_SINI_DB_SELECT_1 */

            R1300_00_LE_SI_MOVIMENTO_SINI_DB_SELECT_1();

            /*" -344- MOVE SQLCODE TO WS-SQLCODE */
            _.Move(DB.SQLCODE, WS_SQLCODE);

            /*" -347- DISPLAY 'SQLCODE DO SELECT NA SI_MOVIMENTO_SINI = ' WS-SQLCODE */
            _.Display($"SQLCODE DO SELECT NA SI_MOVIMENTO_SINI = {WS_SQLCODE}");

            /*" -348- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -349- MOVE 'N' TO WTEM-SIMOVSIN */
                _.Move("N", WTEM_SIMOVSIN);

                /*" -350- ELSE */
            }
            else
            {


                /*" -351- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -352- MOVE 01 TO OUT-COD-RETORNO */
                    _.Move(01, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                    /*" -353- MOVE SQLCODE TO OUT-COD-RETORNO-SQL */
                    _.Move(DB.SQLCODE, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL);

                    /*" -355- MOVE 'PTACOMOS - PROBLEMAS NO SELECT SI_MOVIMENTO_SINI' TO OUT-MENSAGEM */
                    _.Move("PTACOMOS - PROBLEMAS NO SELECT SI_MOVIMENTO_SINI", LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM);

                    /*" -356- DISPLAY 'PTACOMOS - PROBLEMAS SELECT SI_MOVIMENTO_SINI' */
                    _.Display($"PTACOMOS - PROBLEMAS SELECT SI_MOVIMENTO_SINI");

                    /*" -357- DISPLAY 'SQLCODE = ' WS-SQLCODE */
                    _.Display($"SQLCODE = {WS_SQLCODE}");

                    /*" -358- PERFORM R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION();
                }

            }


            /*" -358- DISPLAY 'SAIU DO R1300-00-LE-SI-MOVIMENTO-SINI' . */
            _.Display($"SAIU DO R1300-00-LE-SI-MOVIMENTO-SINI");

        }

        [StopWatch]
        /*" R1300-00-LE-SI-MOVIMENTO-SINI-DB-SELECT-1 */
        public void R1300_00_LE_SI_MOVIMENTO_SINI_DB_SELECT_1()
        {
            /*" -341- EXEC SQL SELECT COD_ESTIPULANTE, COD_PRODUTO, RAMO_EMISSOR, COD_CAUSA INTO :SIMOVSIN-COD-ESTIPULANTE, :SIMOVSIN-COD-PRODUTO, :SIMOVSIN-RAMO-EMISSOR, :SIMOVSIN-COD-CAUSA FROM SEGUROS.SI_MOVIMENTO_SINI WHERE COD_FONTE = :SISINACO-COD-FONTE AND NUM_PROTOCOLO_SINI = :SISINACO-NUM-PROTOCOLO-SINI AND DAC_PROTOCOLO_SINI = :SISINACO-DAC-PROTOCOLO-SINI END-EXEC. */

            var r1300_00_LE_SI_MOVIMENTO_SINI_DB_SELECT_1_Query1 = new R1300_00_LE_SI_MOVIMENTO_SINI_DB_SELECT_1_Query1()
            {
                SISINACO_NUM_PROTOCOLO_SINI = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_PROTOCOLO_SINI.ToString(),
                SISINACO_DAC_PROTOCOLO_SINI = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DAC_PROTOCOLO_SINI.ToString(),
                SISINACO_COD_FONTE = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_FONTE.ToString(),
            };

            var executed_1 = R1300_00_LE_SI_MOVIMENTO_SINI_DB_SELECT_1_Query1.Execute(r1300_00_LE_SI_MOVIMENTO_SINI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SIMOVSIN_COD_ESTIPULANTE, SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_COD_ESTIPULANTE);
                _.Move(executed_1.SIMOVSIN_COD_PRODUTO, SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_COD_PRODUTO);
                _.Move(executed_1.SIMOVSIN_RAMO_EMISSOR, SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_RAMO_EMISSOR);
                _.Move(executed_1.SIMOVSIN_COD_CAUSA, SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_COD_CAUSA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-INCLUI-SIPARTIC-SECTION */
        private void R1400_00_INCLUI_SIPARTIC_SECTION()
        {
            /*" -367- DISPLAY 'ENTROU NO R1400-00-INCLUI-SIPARTIC ' */
            _.Display($"ENTROU NO R1400-00-INCLUI-SIPARTIC ");

            /*" -369- MOVE 'R1400' TO ABEND-COD-PROCESSO. */
            _.Move("R1400", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -371- DISPLAY 'PTACOMOS INSERT SEGUROS.SI_PARTICIPANTE' */
            _.Display($"PTACOMOS INSERT SEGUROS.SI_PARTICIPANTE");

            /*" -372- DISPLAY 'DADOS DOS INSERT NA SI_PARTICIPANTE-------------' */
            _.Display($"DADOS DOS INSERT NA SI_PARTICIPANTE-------------");

            /*" -373- DISPLAY 'SISINACO-COD-FONTE          = ' SISINACO-COD-FONTE */
            _.Display($"SISINACO-COD-FONTE          = {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_FONTE}");

            /*" -375- DISPLAY 'SISINACO-NUM-PROTOCOLO-SINI = ' SISINACO-NUM-PROTOCOLO-SINI */
            _.Display($"SISINACO-NUM-PROTOCOLO-SINI = {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_PROTOCOLO_SINI}");

            /*" -377- DISPLAY 'SISINACO-DAC-PROTOCOLO-SINI = ' SISINACO-DAC-PROTOCOLO-SINI */
            _.Display($"SISINACO-DAC-PROTOCOLO-SINI = {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DAC_PROTOCOLO_SINI}");

            /*" -378- DISPLAY 'SISINACO-NUM-PARTICIPANTE   = 3' */
            _.Display($"SISINACO-NUM-PARTICIPANTE   = 3");

            /*" -380- DISPLAY 'SIMOVSIN-COD-ESTIPULANTE    = ' SIMOVSIN-COD-ESTIPULANTE */
            _.Display($"SIMOVSIN-COD-ESTIPULANTE    = {SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_COD_ESTIPULANTE}");

            /*" -381- DISPLAY 'SISINACO-SIT_PARTICIPANTE   = A' */
            _.Display($"SISINACO-SIT_PARTICIPANTE   = A");

            /*" -382- DISPLAY 'SISINACO-COD-USUARIO        = ' SISINACO-COD-USUARIO */
            _.Display($"SISINACO-COD-USUARIO        = {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_USUARIO}");

            /*" -384- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -403- PERFORM R1400_00_INCLUI_SIPARTIC_DB_INSERT_1 */

            R1400_00_INCLUI_SIPARTIC_DB_INSERT_1();

            /*" -406- MOVE SQLCODE TO WS-SQLCODE */
            _.Move(DB.SQLCODE, WS_SQLCODE);

            /*" -408- DISPLAY 'SQLCODE DO INSERT NA SI_PARTICIPANTE = ' WS-SQLCODE */
            _.Display($"SQLCODE DO INSERT NA SI_PARTICIPANTE = {WS_SQLCODE}");

            /*" -409- IF SQLCODE NOT EQUAL ZEROS AND -803 */

            if (!DB.SQLCODE.In("00", "-803"))
            {

                /*" -410- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -411- MOVE SQLCODE TO OUT-COD-RETORNO-SQL */
                _.Move(DB.SQLCODE, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL);

                /*" -413- MOVE 'PTACOMOS - PROBLEMAS NO INSERT SI_PARTICIPANTE' TO OUT-MENSAGEM */
                _.Move("PTACOMOS - PROBLEMAS NO INSERT SI_PARTICIPANTE", LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -414- DISPLAY 'PTACOMOS - PROBLEMAS NO INSERT SI_PARTICIPANTE' */
                _.Display($"PTACOMOS - PROBLEMAS NO INSERT SI_PARTICIPANTE");

                /*" -415- DISPLAY 'SQLCODE = ' WS-SQLCODE */
                _.Display($"SQLCODE = {WS_SQLCODE}");

                /*" -416- PERFORM R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION();
            }


            /*" -416- DISPLAY 'SAIU DO R1400-00-INCLUI-SIPARTIC ' . */
            _.Display($"SAIU DO R1400-00-INCLUI-SIPARTIC ");

        }

        [StopWatch]
        /*" R1400-00-INCLUI-SIPARTIC-DB-INSERT-1 */
        public void R1400_00_INCLUI_SIPARTIC_DB_INSERT_1()
        {
            /*" -403- EXEC SQL INSERT INTO SEGUROS.SI_PARTICIPANTE (COD_FONTE, NUM_PROTOCOLO_SINI, DAC_PROTOCOLO_SINI, NUM_PARTICIPANTE, COD_CLIENTE, SIT_PARTICIPANTE, COD_USUARIO, TIMESTAMP) VALUES (:SISINACO-COD-FONTE, :SISINACO-NUM-PROTOCOLO-SINI, :SISINACO-DAC-PROTOCOLO-SINI, 3, :SIMOVSIN-COD-ESTIPULANTE, 'A' , :SISINACO-COD-USUARIO, CURRENT TIMESTAMP) END-EXEC. */

            var r1400_00_INCLUI_SIPARTIC_DB_INSERT_1_Insert1 = new R1400_00_INCLUI_SIPARTIC_DB_INSERT_1_Insert1()
            {
                SISINACO_COD_FONTE = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_FONTE.ToString(),
                SISINACO_NUM_PROTOCOLO_SINI = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_PROTOCOLO_SINI.ToString(),
                SISINACO_DAC_PROTOCOLO_SINI = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DAC_PROTOCOLO_SINI.ToString(),
                SIMOVSIN_COD_ESTIPULANTE = SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_COD_ESTIPULANTE.ToString(),
                SISINACO_COD_USUARIO = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_USUARIO.ToString(),
            };

            R1400_00_INCLUI_SIPARTIC_DB_INSERT_1_Insert1.Execute(r1400_00_INCLUI_SIPARTIC_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-MAX-SIPROACO-SECTION */
        private void R1500_00_MAX_SIPROACO_SECTION()
        {
            /*" -425- MOVE 'R1500' TO ABEND-COD-PROCESSO. */
            _.Move("R1500", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -426- DISPLAY 'ENTROU NO R1500-00-MAX-SIPROACO ' */
            _.Display($"ENTROU NO R1500-00-MAX-SIPROACO ");

            /*" -427- DISPLAY '-- CHAVE DE ACESSO A TABELA SI_PROTOCOLO_ACOMP----' */
            _.Display($"-- CHAVE DE ACESSO A TABELA SI_PROTOCOLO_ACOMP----");

            /*" -428- DISPLAY 'COD_FONTE           = ' SISINACO-COD-FONTE */
            _.Display($"COD_FONTE           = {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_FONTE}");

            /*" -429- DISPLAY 'NUM_PROTOCOLO_SINI  = ' SISINACO-NUM-PROTOCOLO-SINI */
            _.Display($"NUM_PROTOCOLO_SINI  = {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_PROTOCOLO_SINI}");

            /*" -430- DISPLAY 'DAC_PROTOCOLO_SINI  = ' SISINACO-DAC-PROTOCOLO-SINI */
            _.Display($"DAC_PROTOCOLO_SINI  = {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DAC_PROTOCOLO_SINI}");

            /*" -432- DISPLAY '--------------------------------------------------' */
            _.Display($"--------------------------------------------------");

            /*" -439- PERFORM R1500_00_MAX_SIPROACO_DB_SELECT_1 */

            R1500_00_MAX_SIPROACO_DB_SELECT_1();

            /*" -442- MOVE SQLCODE TO WS-SQLCODE */
            _.Move(DB.SQLCODE, WS_SQLCODE);

            /*" -443- DISPLAY 'SQLCODE DO SELECT SI_PROTOCOLO_ACOMP = ' WS-SQLCODE */
            _.Display($"SQLCODE DO SELECT SI_PROTOCOLO_ACOMP = {WS_SQLCODE}");

            /*" -446- DISPLAY 'SIPROACO-OCORR-HISTORICO = ' SIPROACO-OCORR-HISTORICO */
            _.Display($"SIPROACO-OCORR-HISTORICO = {SIPROACO.DCLSI_PROTOCOLO_ACOMP.SIPROACO_OCORR_HISTORICO}");

            /*" -447- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -448- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -449- MOVE SQLCODE TO OUT-COD-RETORNO-SQL */
                _.Move(DB.SQLCODE, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL);

                /*" -451- MOVE 'PTACOMOS - PROBLEMAS NO MAX SI_PROTOCOLO_ACOMP' TO OUT-MENSAGEM */
                _.Move("PTACOMOS - PROBLEMAS NO MAX SI_PROTOCOLO_ACOMP", LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -452- DISPLAY 'PTACOMOS - PROBLEMAS NO MAX SI_PROTOCOLO_ACOMP' */
                _.Display($"PTACOMOS - PROBLEMAS NO MAX SI_PROTOCOLO_ACOMP");

                /*" -453- DISPLAY 'SQLCODE = ' WS-SQLCODE */
                _.Display($"SQLCODE = {WS_SQLCODE}");

                /*" -454- PERFORM R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION();
            }


            /*" -454- DISPLAY 'SAIU DO R1500-00-MAX-SIPROACO ' . */
            _.Display($"SAIU DO R1500-00-MAX-SIPROACO ");

        }

        [StopWatch]
        /*" R1500-00-MAX-SIPROACO-DB-SELECT-1 */
        public void R1500_00_MAX_SIPROACO_DB_SELECT_1()
        {
            /*" -439- EXEC SQL SELECT VALUE(MAX(OCORR_HISTORICO), 0) INTO :SIPROACO-OCORR-HISTORICO FROM SEGUROS.SI_PROTOCOLO_ACOMP WHERE COD_FONTE = :SISINACO-COD-FONTE AND NUM_PROTOCOLO_SINI = :SISINACO-NUM-PROTOCOLO-SINI AND DAC_PROTOCOLO_SINI = :SISINACO-DAC-PROTOCOLO-SINI END-EXEC. */

            var r1500_00_MAX_SIPROACO_DB_SELECT_1_Query1 = new R1500_00_MAX_SIPROACO_DB_SELECT_1_Query1()
            {
                SISINACO_NUM_PROTOCOLO_SINI = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_PROTOCOLO_SINI.ToString(),
                SISINACO_DAC_PROTOCOLO_SINI = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DAC_PROTOCOLO_SINI.ToString(),
                SISINACO_COD_FONTE = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_FONTE.ToString(),
            };

            var executed_1 = R1500_00_MAX_SIPROACO_DB_SELECT_1_Query1.Execute(r1500_00_MAX_SIPROACO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SIPROACO_OCORR_HISTORICO, SIPROACO.DCLSI_PROTOCOLO_ACOMP.SIPROACO_OCORR_HISTORICO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-LE-SINISCAU-SECTION */
        private void R1600_00_LE_SINISCAU_SECTION()
        {
            /*" -463- DISPLAY 'ENTROU NO R1600-00-LE-SINISCAU' . */
            _.Display($"ENTROU NO R1600-00-LE-SINISCAU");

            /*" -464- MOVE 'R1600' TO ABEND-COD-PROCESSO. */
            _.Move("R1600", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -465- DISPLAY '-- CHAVE DE ACESSO A TABELA SINISTRO_CAUSA--------' */
            _.Display($"-- CHAVE DE ACESSO A TABELA SINISTRO_CAUSA--------");

            /*" -466- DISPLAY 'RAMO_EMISSOR       = ' SIMOVSIN-RAMO-EMISSOR */
            _.Display($"RAMO_EMISSOR       = {SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_RAMO_EMISSOR}");

            /*" -467- DISPLAY 'COD_CAUSA          = ' SIMOVSIN-COD-CAUSA */
            _.Display($"COD_CAUSA          = {SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_COD_CAUSA}");

            /*" -469- DISPLAY '--------------------------------------------------' */
            _.Display($"--------------------------------------------------");

            /*" -477- PERFORM R1600_00_LE_SINISCAU_DB_SELECT_1 */

            R1600_00_LE_SINISCAU_DB_SELECT_1();

            /*" -480- MOVE SQLCODE TO WS-SQLCODE */
            _.Move(DB.SQLCODE, WS_SQLCODE);

            /*" -482- DISPLAY 'SQLCODE DO SELECT NA SINISTRO_CAUSA = ' WS-SQLCODE */
            _.Display($"SQLCODE DO SELECT NA SINISTRO_CAUSA = {WS_SQLCODE}");

            /*" -483- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -484- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -485- MOVE SQLCODE TO OUT-COD-RETORNO-SQL */
                _.Move(DB.SQLCODE, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL);

                /*" -487- MOVE 'PTACOMOS - PROBLEMAS NO SELECT SINISTRO_CAUSA' TO OUT-MENSAGEM */
                _.Move("PTACOMOS - PROBLEMAS NO SELECT SINISTRO_CAUSA", LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -488- DISPLAY 'PTACOMOS - PROBLEMAS NO SELECT SINISTRO_CAUSA' */
                _.Display($"PTACOMOS - PROBLEMAS NO SELECT SINISTRO_CAUSA");

                /*" -489- DISPLAY 'SQLCODE = ' WS-SQLCODE */
                _.Display($"SQLCODE = {WS_SQLCODE}");

                /*" -490- PERFORM R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION();
            }


            /*" -490- DISPLAY 'SAIU DO R1600-00-LE-SINISCAU' . */
            _.Display($"SAIU DO R1600-00-LE-SINISCAU");

        }

        [StopWatch]
        /*" R1600-00-LE-SINISCAU-DB-SELECT-1 */
        public void R1600_00_LE_SINISCAU_DB_SELECT_1()
        {
            /*" -477- EXEC SQL SELECT COD_GRUPO_CAUSA, COD_SUBGRUPO_CAUSA INTO :SINISCAU-COD-GRUPO-CAUSA, :SINISCAU-COD-SUBGRUPO-CAUSA FROM SEGUROS.SINISTRO_CAUSA WHERE RAMO_EMISSOR = :SIMOVSIN-RAMO-EMISSOR AND COD_CAUSA = :SIMOVSIN-COD-CAUSA END-EXEC. */

            var r1600_00_LE_SINISCAU_DB_SELECT_1_Query1 = new R1600_00_LE_SINISCAU_DB_SELECT_1_Query1()
            {
                SIMOVSIN_RAMO_EMISSOR = SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_RAMO_EMISSOR.ToString(),
                SIMOVSIN_COD_CAUSA = SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_COD_CAUSA.ToString(),
            };

            var executed_1 = R1600_00_LE_SINISCAU_DB_SELECT_1_Query1.Execute(r1600_00_LE_SINISCAU_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISCAU_COD_GRUPO_CAUSA, SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_COD_GRUPO_CAUSA);
                _.Move(executed_1.SINISCAU_COD_SUBGRUPO_CAUSA, SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_COD_SUBGRUPO_CAUSA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1700-00-MAX-SICHEPAR-SECTION */
        private void R1700_00_MAX_SICHEPAR_SECTION()
        {
            /*" -499- MOVE 'R1700' TO ABEND-COD-PROCESSO. */
            _.Move("R1700", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -500- DISPLAY 'ENTROU NO R1700-00-MAX-SICHEPAR' */
            _.Display($"ENTROU NO R1700-00-MAX-SICHEPAR");

            /*" -501- DISPLAY '-- CHAVE DE ACESSO A TABELA SI_CHECKLIST_PARAM----' */
            _.Display($"-- CHAVE DE ACESSO A TABELA SI_CHECKLIST_PARAM----");

            /*" -502- DISPLAY 'COD_PRODUTO        = ' SIMOVSIN-COD-PRODUTO */
            _.Display($"COD_PRODUTO        = {SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_COD_PRODUTO}");

            /*" -503- DISPLAY 'COD_GRUPO_CAUSA    = ' SINISCAU-COD-GRUPO-CAUSA */
            _.Display($"COD_GRUPO_CAUSA    = {SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_COD_GRUPO_CAUSA}");

            /*" -504- DISPLAY 'COD_SUBGRUPO_CAUSA = ' SINISCAU-COD-SUBGRUPO-CAUSA */
            _.Display($"COD_SUBGRUPO_CAUSA = {SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_COD_SUBGRUPO_CAUSA}");

            /*" -506- DISPLAY '--------------------------------------------------' */
            _.Display($"--------------------------------------------------");

            /*" -516- PERFORM R1700_00_MAX_SICHEPAR_DB_SELECT_1 */

            R1700_00_MAX_SICHEPAR_DB_SELECT_1();

            /*" -519- MOVE SQLCODE TO WS-SQLCODE */
            _.Move(DB.SQLCODE, WS_SQLCODE);

            /*" -521- DISPLAY 'SQLCODE DO SELECT NA SI_CHECKLIST_PARAM = ' WS-SQLCODE */
            _.Display($"SQLCODE DO SELECT NA SI_CHECKLIST_PARAM = {WS_SQLCODE}");

            /*" -524- DISPLAY 'SICHEPAR-DATA-INIVIGENCIA = ' SICHEPAR-DATA-INIVIGENCIA */
            _.Display($"SICHEPAR-DATA-INIVIGENCIA = {SICHEPAR.DCLSI_CHECKLIST_PARAM.SICHEPAR_DATA_INIVIGENCIA}");

            /*" -525- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -526- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -527- MOVE SQLCODE TO OUT-COD-RETORNO-SQL */
                _.Move(DB.SQLCODE, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL);

                /*" -529- MOVE 'PTACOMOS - PROBLEMAS NO MAX SI_CHECKLIST_PARAM' TO OUT-MENSAGEM */
                _.Move("PTACOMOS - PROBLEMAS NO MAX SI_CHECKLIST_PARAM", LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -530- DISPLAY 'PTACOMOS - PROBLEMAS NO MAX SI_CHECKLIST_PARAM' */
                _.Display($"PTACOMOS - PROBLEMAS NO MAX SI_CHECKLIST_PARAM");

                /*" -531- DISPLAY 'SQLCODE = ' WS-SQLCODE */
                _.Display($"SQLCODE = {WS_SQLCODE}");

                /*" -532- PERFORM R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION();
            }


            /*" -532- DISPLAY 'SAIU DO R1700-00-MAX-SICHEPAR' . */
            _.Display($"SAIU DO R1700-00-MAX-SICHEPAR");

        }

        [StopWatch]
        /*" R1700-00-MAX-SICHEPAR-DB-SELECT-1 */
        public void R1700_00_MAX_SICHEPAR_DB_SELECT_1()
        {
            /*" -516- EXEC SQL SELECT MAX(DATA_INIVIGENCIA) INTO :SICHEPAR-DATA-INIVIGENCIA FROM SEGUROS.SI_CHECKLIST_PARAM WHERE COD_PRODUTO = :SIMOVSIN-COD-PRODUTO AND COD_GRUPO_CAUSA = :SINISCAU-COD-GRUPO-CAUSA AND COD_SUBGRUPO_CAUSA = :SINISCAU-COD-SUBGRUPO-CAUSA AND COD_DOCUMENTO = 0 AND NUM_PARTICIPANTE = 3 AND COD_FASE = 2 END-EXEC. */

            var r1700_00_MAX_SICHEPAR_DB_SELECT_1_Query1 = new R1700_00_MAX_SICHEPAR_DB_SELECT_1_Query1()
            {
                SINISCAU_COD_SUBGRUPO_CAUSA = SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_COD_SUBGRUPO_CAUSA.ToString(),
                SINISCAU_COD_GRUPO_CAUSA = SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_COD_GRUPO_CAUSA.ToString(),
                SIMOVSIN_COD_PRODUTO = SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_COD_PRODUTO.ToString(),
            };

            var executed_1 = R1700_00_MAX_SICHEPAR_DB_SELECT_1_Query1.Execute(r1700_00_MAX_SICHEPAR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SICHEPAR_DATA_INIVIGENCIA, SICHEPAR.DCLSI_CHECKLIST_PARAM.SICHEPAR_DATA_INIVIGENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/

        [StopWatch]
        /*" R1800-00-INCLUI-SIPROACO-SECTION */
        private void R1800_00_INCLUI_SIPROACO_SECTION()
        {
            /*" -541- DISPLAY 'ENTROU NO R1800-00-INCLUI-SIPROACO' */
            _.Display($"ENTROU NO R1800-00-INCLUI-SIPROACO");

            /*" -543- MOVE 'R1800' TO ABEND-COD-PROCESSO. */
            _.Move("R1800", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -544- DISPLAY 'DADOS DE INSERT DA SI_PROTOCOLO_ACOMP----' */
            _.Display($"DADOS DE INSERT DA SI_PROTOCOLO_ACOMP----");

            /*" -546- PERFORM R9200-00-DISPLAY-DADOS */

            R9200_00_DISPLAY_DADOS_SECTION();

            /*" -591- PERFORM R1800_00_INCLUI_SIPROACO_DB_INSERT_1 */

            R1800_00_INCLUI_SIPROACO_DB_INSERT_1();

            /*" -594- MOVE SQLCODE TO WS-SQLCODE */
            _.Move(DB.SQLCODE, WS_SQLCODE);

            /*" -597- DISPLAY 'SQLCODE DO INSERT NA SI_PROTOCOLO_ACOMP = ' WS-SQLCODE */
            _.Display($"SQLCODE DO INSERT NA SI_PROTOCOLO_ACOMP = {WS_SQLCODE}");

            /*" -598- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -599- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -600- MOVE SQLCODE TO OUT-COD-RETORNO-SQL */
                _.Move(DB.SQLCODE, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL);

                /*" -602- MOVE 'PTACOMOS - PROBLEMAS NO INSERT SI_PROTOCOLO_ACOMP' TO OUT-MENSAGEM */
                _.Move("PTACOMOS - PROBLEMAS NO INSERT SI_PROTOCOLO_ACOMP", LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -603- DISPLAY 'PTACOMOS - PROBLEMAS INSERT SI_PROTOCOLO_ACOMP' */
                _.Display($"PTACOMOS - PROBLEMAS INSERT SI_PROTOCOLO_ACOMP");

                /*" -604- DISPLAY 'SQLCODE = ' WS-SQLCODE */
                _.Display($"SQLCODE = {WS_SQLCODE}");

                /*" -605- PERFORM R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION();
            }


            /*" -605- DISPLAY 'SAIU DO R1800-00-INCLUI-SIPROACO' . */
            _.Display($"SAIU DO R1800-00-INCLUI-SIPROACO");

        }

        [StopWatch]
        /*" R1800-00-INCLUI-SIPROACO-DB-INSERT-1 */
        public void R1800_00_INCLUI_SIPROACO_DB_INSERT_1()
        {
            /*" -591- EXEC SQL INSERT INTO SEGUROS.SI_PROTOCOLO_ACOMP (COD_FONTE, NUM_PROTOCOLO_SINI, DAC_PROTOCOLO_SINI, OCORR_HISTORICO, DATA_INIVIGENCIA, DATA_MOVIMENTO, COD_PRODUTO, COD_GRUPO_CAUSA, COD_SUBGRUPO_CAUSA, NUM_PARTICIPANTE, COD_CLIENTE, COD_DOCUMENTO, COD_FASE, COD_EVENTO, NUM_CARTA, OCORR_HIST_PAI, COD_USUARIO, TIMESTAMP, NOM_SISTEMA_ORIGEM, NOM_PROGRAMA, STA_INTEGRA_AMSS) VALUES (:SISINACO-COD-FONTE, :SISINACO-NUM-PROTOCOLO-SINI, :SISINACO-DAC-PROTOCOLO-SINI, :SIPROACO-OCORR-HISTORICO, :SICHEPAR-DATA-INIVIGENCIA, :SISINACO-DATA-MOVTO-SINIACO, :SIMOVSIN-COD-PRODUTO, :SINISCAU-COD-GRUPO-CAUSA, :SINISCAU-COD-SUBGRUPO-CAUSA, 3, :SIMOVSIN-COD-ESTIPULANTE, 0, 2, :SISINACO-COD-EVENTO, :SISINACO-NUM-CARTA:IND-NUM-CARTA, :SIPROACO-OCORR-HISTORICO, :SISINACO-COD-USUARIO, CURRENT TIMESTAMP, 'SISWEB' , 'PTACOMOS' , 'N' ) END-EXEC. */

            var r1800_00_INCLUI_SIPROACO_DB_INSERT_1_Insert1 = new R1800_00_INCLUI_SIPROACO_DB_INSERT_1_Insert1()
            {
                SISINACO_COD_FONTE = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_FONTE.ToString(),
                SISINACO_NUM_PROTOCOLO_SINI = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_PROTOCOLO_SINI.ToString(),
                SISINACO_DAC_PROTOCOLO_SINI = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DAC_PROTOCOLO_SINI.ToString(),
                SIPROACO_OCORR_HISTORICO = SIPROACO.DCLSI_PROTOCOLO_ACOMP.SIPROACO_OCORR_HISTORICO.ToString(),
                SICHEPAR_DATA_INIVIGENCIA = SICHEPAR.DCLSI_CHECKLIST_PARAM.SICHEPAR_DATA_INIVIGENCIA.ToString(),
                SISINACO_DATA_MOVTO_SINIACO = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DATA_MOVTO_SINIACO.ToString(),
                SIMOVSIN_COD_PRODUTO = SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_COD_PRODUTO.ToString(),
                SINISCAU_COD_GRUPO_CAUSA = SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_COD_GRUPO_CAUSA.ToString(),
                SINISCAU_COD_SUBGRUPO_CAUSA = SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_COD_SUBGRUPO_CAUSA.ToString(),
                SIMOVSIN_COD_ESTIPULANTE = SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_COD_ESTIPULANTE.ToString(),
                SISINACO_COD_EVENTO = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_EVENTO.ToString(),
                SISINACO_NUM_CARTA = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_CARTA.ToString(),
                IND_NUM_CARTA = IND_NUM_CARTA.ToString(),
                SISINACO_COD_USUARIO = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_USUARIO.ToString(),
            };

            R1800_00_INCLUI_SIPROACO_DB_INSERT_1_Insert1.Execute(r1800_00_INCLUI_SIPROACO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1800_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-PROCESSA-EXCLUSAO-SECTION */
        private void R2000_00_PROCESSA_EXCLUSAO_SECTION()
        {
            /*" -615- MOVE 'R2000' TO ABEND-COD-PROCESSO. */
            _.Move("R2000", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -615- PERFORM R2100-00-EXCLUI-SISINACO. */

            R2100_00_EXCLUI_SISINACO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-EXCLUI-SISINACO-SECTION */
        private void R2100_00_EXCLUI_SISINACO_SECTION()
        {
            /*" -624- DISPLAY 'ENTROU NO R2100-00-EXCLUI-SISINACO ' */
            _.Display($"ENTROU NO R2100-00-EXCLUI-SISINACO ");

            /*" -625- MOVE 'R2100' TO ABEND-COD-PROCESSO. */
            _.Move("R2100", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -626- DISPLAY '-- CHAVE DO DELETE SI_SINISTRO_ACOMP -------------' */
            _.Display($"-- CHAVE DO DELETE SI_SINISTRO_ACOMP -------------");

            /*" -627- DISPLAY 'COD_FONTE          = ' SISINACO-COD-FONTE */
            _.Display($"COD_FONTE          = {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_FONTE}");

            /*" -628- DISPLAY 'NUM_PROTOCOLO_SINI = ' SISINACO-NUM-PROTOCOLO-SINI */
            _.Display($"NUM_PROTOCOLO_SINI = {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_PROTOCOLO_SINI}");

            /*" -629- DISPLAY 'DAC_PROTOCOLO_SINI = ' SISINACO-DAC-PROTOCOLO-SINI */
            _.Display($"DAC_PROTOCOLO_SINI = {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DAC_PROTOCOLO_SINI}");

            /*" -630- DISPLAY 'NUM_OCORR_SINIACO  = ' SISINACO-NUM-OCORR-SINIACO */
            _.Display($"NUM_OCORR_SINIACO  = {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_OCORR_SINIACO}");

            /*" -632- DISPLAY '--------------------------------------------------' */
            _.Display($"--------------------------------------------------");

            /*" -638- PERFORM R2100_00_EXCLUI_SISINACO_DB_DELETE_1 */

            R2100_00_EXCLUI_SISINACO_DB_DELETE_1();

            /*" -641- MOVE SQLCODE TO WS-SQLCODE */
            _.Move(DB.SQLCODE, WS_SQLCODE);

            /*" -644- DISPLAY 'SQLCODE DO DELETE DA SI_SINISTRO_ACOMP = ' WS-SQLCODE */
            _.Display($"SQLCODE DO DELETE DA SI_SINISTRO_ACOMP = {WS_SQLCODE}");

            /*" -645- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -646- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -647- MOVE SQLCODE TO OUT-COD-RETORNO-SQL */
                _.Move(DB.SQLCODE, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL);

                /*" -649- MOVE 'PTACOMOS - PROBLEMAS NO DELETE SI_SINISTRO_ACOMP' TO OUT-MENSAGEM */
                _.Move("PTACOMOS - PROBLEMAS NO DELETE SI_SINISTRO_ACOMP", LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -650- DISPLAY 'PTACOMOS - PROBLEMAS NO DELETE SI_SINISTRO_ACOMP' */
                _.Display($"PTACOMOS - PROBLEMAS NO DELETE SI_SINISTRO_ACOMP");

                /*" -651- DISPLAY 'SQLCODE = ' WS-SQLCODE */
                _.Display($"SQLCODE = {WS_SQLCODE}");

                /*" -652- PERFORM R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION();
            }


            /*" -652- DISPLAY 'SAIU DO R2100-00-EXCLUI-SISINACO ' . */
            _.Display($"SAIU DO R2100-00-EXCLUI-SISINACO ");

        }

        [StopWatch]
        /*" R2100-00-EXCLUI-SISINACO-DB-DELETE-1 */
        public void R2100_00_EXCLUI_SISINACO_DB_DELETE_1()
        {
            /*" -638- EXEC SQL DELETE FROM SEGUROS.SI_SINISTRO_ACOMP WHERE COD_FONTE = :SISINACO-COD-FONTE AND NUM_PROTOCOLO_SINI = :SISINACO-NUM-PROTOCOLO-SINI AND DAC_PROTOCOLO_SINI = :SISINACO-DAC-PROTOCOLO-SINI AND NUM_OCORR_SINIACO = :SISINACO-NUM-OCORR-SINIACO END-EXEC. */

            var r2100_00_EXCLUI_SISINACO_DB_DELETE_1_Delete1 = new R2100_00_EXCLUI_SISINACO_DB_DELETE_1_Delete1()
            {
                SISINACO_COD_FONTE = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_FONTE.ToString(),
                SISINACO_NUM_PROTOCOLO_SINI = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_PROTOCOLO_SINI.ToString(),
                SISINACO_DAC_PROTOCOLO_SINI = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DAC_PROTOCOLO_SINI.ToString(),
                SISINACO_NUM_OCORR_SINIACO = SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_OCORR_SINIACO.ToString(),
            };

            R2100_00_EXCLUI_SISINACO_DB_DELETE_1_Delete1.Execute(r2100_00_EXCLUI_SISINACO_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-DISPLAY-PARM-SECTION */
        private void R9000_00_DISPLAY_PARM_SECTION()
        {
            /*" -658- DISPLAY 'IN-SISTEMA                  = ' IN-SISTEMA */
            _.Display($"IN-SISTEMA                  = {LBWCT001.PROTOCOLO_RECEBIDO.IN_SISTEMA}");

            /*" -659- DISPLAY 'IN-CANAL                    = ' IN-CANAL */
            _.Display($"IN-CANAL                    = {LBWCT001.PROTOCOLO_RECEBIDO.IN_CANAL}");

            /*" -660- DISPLAY 'IN-PV                       = ' IN-PV */
            _.Display($"IN-PV                       = {LBWCT001.PROTOCOLO_RECEBIDO.IN_PV}");

            /*" -661- DISPLAY 'IN-USUARIO                  = ' IN-USUARIO */
            _.Display($"IN-USUARIO                  = {LBWCT001.PROTOCOLO_RECEBIDO.IN_USUARIO}");

            /*" -662- DISPLAY 'IN-OPERACAO                 = ' IN-OPERACAO */
            _.Display($"IN-OPERACAO                 = {LBWCT001.PROTOCOLO_RECEBIDO.IN_OPERACAO}");

            /*" -663- DISPLAY 'SISINACO-COD-FONTE          = ' SISINACO-COD-FONTE */
            _.Display($"SISINACO-COD-FONTE          = {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_FONTE}");

            /*" -665- DISPLAY 'SISINACO-NUM-PROTOCOLO-SINI = ' SISINACO-NUM-PROTOCOLO-SINI */
            _.Display($"SISINACO-NUM-PROTOCOLO-SINI = {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_PROTOCOLO_SINI}");

            /*" -667- DISPLAY 'SISINACO-DAC-PROTOCOLO-SINI = ' SISINACO-DAC-PROTOCOLO-SINI */
            _.Display($"SISINACO-DAC-PROTOCOLO-SINI = {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DAC_PROTOCOLO_SINI}");

            /*" -669- DISPLAY 'SISINACO-NUM-OCORR-SINIACO  = ' SISINACO-NUM-OCORR-SINIACO */
            _.Display($"SISINACO-NUM-OCORR-SINIACO  = {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_OCORR_SINIACO}");

            /*" -670- DISPLAY 'SISINACO-COD-EVENTO         = ' SISINACO-COD-EVENTO */
            _.Display($"SISINACO-COD-EVENTO         = {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_EVENTO}");

            /*" -672- DISPLAY 'SISINACO-DATA-MOVTO-SINIACO = ' SISINACO-DATA-MOVTO-SINIACO */
            _.Display($"SISINACO-DATA-MOVTO-SINIACO = {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DATA_MOVTO_SINIACO}");

            /*" -674- DISPLAY 'SISINACO-DESCR-COMPLEMENTAR = ' SISINACO-DESCR-COMPLEMENTAR */
            _.Display($"SISINACO-DESCR-COMPLEMENTAR = {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DESCR_COMPLEMENTAR}");

            /*" -675- DISPLAY 'SISINACO-COD-USUARIO        = ' SISINACO-COD-USUARIO */
            _.Display($"SISINACO-COD-USUARIO        = {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_USUARIO}");

            /*" -676- DISPLAY 'SISINACO-TIMESTAMP          = ' SISINACO-TIMESTAMP */
            _.Display($"SISINACO-TIMESTAMP          = {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_TIMESTAMP}");

            /*" -677- DISPLAY 'SISINACO-NUM-CARTA          = ' SISINACO-NUM-CARTA */
            _.Display($"SISINACO-NUM-CARTA          = {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_CARTA}");

            /*" -678- DISPLAY 'OUT-COD-RETORNO             = ' OUT-COD-RETORNO */
            _.Display($"OUT-COD-RETORNO             = {LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO}");

            /*" -679- DISPLAY 'OUT-COD-RETORNO-SQL         = ' OUT-COD-RETORNO-SQL */
            _.Display($"OUT-COD-RETORNO-SQL         = {LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL}");

            /*" -680- DISPLAY 'OUT-MENSAGEM                = ' OUT-MENSAGEM */
            _.Display($"OUT-MENSAGEM                = {LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM}");

            /*" -681- DISPLAY 'OUT-SQLERRMC                = ' OUT-SQLERRMC */
            _.Display($"OUT-SQLERRMC                = {LBWCT002.PROTOCOLO_ENVIO.OUT_SQLERRMC}");

            /*" -682- DISPLAY 'OUT-SQLSTATE                = ' OUT-SQLSTATE */
            _.Display($"OUT-SQLSTATE                = {LBWCT002.PROTOCOLO_ENVIO.OUT_SQLSTATE}");

            /*" -683- DISPLAY '--------------------------------------------------' */
            _.Display($"--------------------------------------------------");

            /*" -683- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9100-00-DISPLAY-DADOS-SECTION */
        private void R9100_00_DISPLAY_DADOS_SECTION()
        {
            /*" -688- DISPLAY 'SISINACO-COD-FONTE          = ' SISINACO-COD-FONTE */
            _.Display($"SISINACO-COD-FONTE          = {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_FONTE}");

            /*" -690- DISPLAY 'SISINACO-NUM-PROTOCOLO-SINI = ' SISINACO-NUM-PROTOCOLO-SINI */
            _.Display($"SISINACO-NUM-PROTOCOLO-SINI = {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_PROTOCOLO_SINI}");

            /*" -692- DISPLAY 'SISINACO-DAC-PROTOCOLO-SINI = ' SISINACO-DAC-PROTOCOLO-SINI */
            _.Display($"SISINACO-DAC-PROTOCOLO-SINI = {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DAC_PROTOCOLO_SINI}");

            /*" -694- DISPLAY 'SISINACO-NUM-OCORR-SINIACO  = ' SISINACO-NUM-OCORR-SINIACO */
            _.Display($"SISINACO-NUM-OCORR-SINIACO  = {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_OCORR_SINIACO}");

            /*" -695- DISPLAY 'SISINACO-COD-EVENTO         = ' SISINACO-COD-EVENTO */
            _.Display($"SISINACO-COD-EVENTO         = {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_EVENTO}");

            /*" -697- DISPLAY 'SISINACO-DATA-MOVTO-SINIACO = ' SISINACO-DATA-MOVTO-SINIACO */
            _.Display($"SISINACO-DATA-MOVTO-SINIACO = {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DATA_MOVTO_SINIACO}");

            /*" -699- DISPLAY 'SISINACO-DESCR-COMPLEMENTAR = ' SISINACO-DESCR-COMPLEMENTAR */
            _.Display($"SISINACO-DESCR-COMPLEMENTAR = {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DESCR_COMPLEMENTAR}");

            /*" -700- DISPLAY 'SISINACO-COD-USUARIO        = ' SISINACO-COD-USUARIO */
            _.Display($"SISINACO-COD-USUARIO        = {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_USUARIO}");

            /*" -701- DISPLAY 'SISINACO-NUM-CARTA          = ' SISINACO-NUM-CARTA */
            _.Display($"SISINACO-NUM-CARTA          = {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_CARTA}");

            /*" -702- DISPLAY '--------------------------------------------' */
            _.Display($"--------------------------------------------");

            /*" -702- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9100_99_SAIDA*/

        [StopWatch]
        /*" R9200-00-DISPLAY-DADOS-SECTION */
        private void R9200_00_DISPLAY_DADOS_SECTION()
        {
            /*" -707- DISPLAY 'SISINACO-COD-FONTE          = ' SISINACO-COD-FONTE */
            _.Display($"SISINACO-COD-FONTE          = {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_FONTE}");

            /*" -709- DISPLAY 'SISINACO-NUM-PROTOCOLO-SINI = ' SISINACO-NUM-PROTOCOLO-SINI */
            _.Display($"SISINACO-NUM-PROTOCOLO-SINI = {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_PROTOCOLO_SINI}");

            /*" -711- DISPLAY 'SISINACO-DAC-PROTOCOLO-SINI = ' SISINACO-DAC-PROTOCOLO-SINI */
            _.Display($"SISINACO-DAC-PROTOCOLO-SINI = {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DAC_PROTOCOLO_SINI}");

            /*" -713- DISPLAY 'SIPROACO-OCORR-HISTORICO    = ' SIPROACO-OCORR-HISTORICO */
            _.Display($"SIPROACO-OCORR-HISTORICO    = {SIPROACO.DCLSI_PROTOCOLO_ACOMP.SIPROACO_OCORR_HISTORICO}");

            /*" -715- DISPLAY 'SICHEPAR-DATA-INIVIGENCIA   = ' SICHEPAR-DATA-INIVIGENCIA */
            _.Display($"SICHEPAR-DATA-INIVIGENCIA   = {SICHEPAR.DCLSI_CHECKLIST_PARAM.SICHEPAR_DATA_INIVIGENCIA}");

            /*" -717- DISPLAY 'SISINACO-DATA-MOVTO-SINIACO = ' SISINACO-DATA-MOVTO-SINIACO */
            _.Display($"SISINACO-DATA-MOVTO-SINIACO = {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DATA_MOVTO_SINIACO}");

            /*" -718- DISPLAY 'SIMOVSIN-COD-PRODUTO        = ' SIMOVSIN-COD-PRODUTO */
            _.Display($"SIMOVSIN-COD-PRODUTO        = {SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_COD_PRODUTO}");

            /*" -720- DISPLAY 'SINISCAU-COD-GRUPO-CAUSA    = ' SINISCAU-COD-GRUPO-CAUSA */
            _.Display($"SINISCAU-COD-GRUPO-CAUSA    = {SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_COD_GRUPO_CAUSA}");

            /*" -722- DISPLAY 'SINISCAU-COD-SUBGRUPO-CAUSA = ' SINISCAU-COD-SUBGRUPO-CAUSA */
            _.Display($"SINISCAU-COD-SUBGRUPO-CAUSA = {SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_COD_SUBGRUPO_CAUSA}");

            /*" -723- DISPLAY 'SIPROACO-NUM-PARTICIPANTE   = 3' */
            _.Display($"SIPROACO-NUM-PARTICIPANTE   = 3");

            /*" -725- DISPLAY 'SIMOVSIN-COD-ESTIPULANTE    = ' SIMOVSIN-COD-ESTIPULANTE */
            _.Display($"SIMOVSIN-COD-ESTIPULANTE    = {SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_COD_ESTIPULANTE}");

            /*" -726- DISPLAY 'SIPROACO-COD-CLIENTE        = 0' */
            _.Display($"SIPROACO-COD-CLIENTE        = 0");

            /*" -727- DISPLAY 'SIPROACO-COD-DOCUMENTO      = 2' */
            _.Display($"SIPROACO-COD-DOCUMENTO      = 2");

            /*" -728- DISPLAY 'SISINACO-COD-EVENTO         = ' SISINACO-COD-EVENTO */
            _.Display($"SISINACO-COD-EVENTO         = {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_EVENTO}");

            /*" -729- DISPLAY 'SISINACO-NUM-CARTA          = ' SISINACO-NUM-CARTA */
            _.Display($"SISINACO-NUM-CARTA          = {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_CARTA}");

            /*" -731- DISPLAY 'SIPROACO-OCORR-HISTORICO    = ' SIPROACO-OCORR-HISTORICO */
            _.Display($"SIPROACO-OCORR-HISTORICO    = {SIPROACO.DCLSI_PROTOCOLO_ACOMP.SIPROACO_OCORR_HISTORICO}");

            /*" -732- DISPLAY 'SISINACO-COD-USUARIO        = ' SISINACO-COD-USUARIO */
            _.Display($"SISINACO-COD-USUARIO        = {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_USUARIO}");

            /*" -733- DISPLAY 'SIPROACO-NOM-SISTEMA-ORIGEM = SISWEB' */
            _.Display($"SIPROACO-NOM-SISTEMA-ORIGEM = SISWEB");

            /*" -734- DISPLAY 'SIPROACO-NOM-PROGRAMA       = PTACOMOS' */
            _.Display($"SIPROACO-NOM-PROGRAMA       = PTACOMOS");

            /*" -735- DISPLAY 'SIPROACO-STA-INTEGRA-AMSS   = N' */
            _.Display($"SIPROACO-STA-INTEGRA-AMSS   = N");

            /*" -736- DISPLAY '--------------------------------------------------' */
            _.Display($"--------------------------------------------------");

            /*" -736- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9200_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -744- MOVE SQLERRMC TO OUT-SQLERRMC */
            _.Move(DB.SQLERRMC, LBWCT002.PROTOCOLO_ENVIO.OUT_SQLERRMC);

            /*" -745- MOVE SQLSTATE TO OUT-SQLSTATE */
            _.Move(DB.SQLSTATE, LBWCT002.PROTOCOLO_ENVIO.OUT_SQLSTATE);

            /*" -746- DISPLAY 'PTACOMOS - DADOS RETORNADOS ----------------------' */
            _.Display($"PTACOMOS - DADOS RETORNADOS ----------------------");

            /*" -748- PERFORM R9000-00-DISPLAY-PARM */

            R9000_00_DISPLAY_PARM_SECTION();

            /*" -748- GOBACK. */

            throw new GoBack();

        }
    }
}