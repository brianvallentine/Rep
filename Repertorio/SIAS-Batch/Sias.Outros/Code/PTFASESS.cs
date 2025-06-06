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
using Sias.Outros.DB2.PTFASESS;

namespace Code
{
    public class PTFASESS
    {
        public bool IsCall { get; set; }

        public PTFASESS()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................ SINISTRO                            *      */
        /*"      *   SUBROTINA............... PTFASESS                            *      */
        /*"      *   ANALISTA ............... PRODEXTER                           *      */
        /*"      *   PROGRAMADOR ............ PRODEXTER                           *      */
        /*"      *   DATA CODIFICACAO ....... AGO / 2001                          *      */
        /*"      *   FUNCAO ................. INCLUI DADOS NA SI_SINISTRO_FASE    *      */
        /*"      *   AMBIENTE................ BATCH E ONLINE                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        /*"      *--------------------------------------                                 */
        #endregion


        #region VARIABLES

        /*"01 WS-SQLCODE      PIC ---9.*/
        public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("9", "4", "---9."));


        public Copies.LBWCT001 LBWCT001 { get; set; } = new Copies.LBWCT001();
        public Copies.LBWCT002 LBWCT002 { get; set; } = new Copies.LBWCT002();
        public Dclgens.ABEND ABEND { get; set; } = new Dclgens.ABEND();
        public Dclgens.SISINFAS SISINFAS { get; set; } = new Dclgens.SISINFAS();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(LBWCT001_PROTOCOLO_RECEBIDO LBWCT001_PROTOCOLO_RECEBIDO_P, SISINFAS_DCLSI_SINISTRO_FASE SISINFAS_DCLSI_SINISTRO_FASE_P, LBWCT002_PROTOCOLO_ENVIO LBWCT002_PROTOCOLO_ENVIO_P) //PROCEDURE DIVISION USING 
        /*PROTOCOLO_RECEBIDO
        DCLSI_SINISTRO_FASE
        PROTOCOLO_ENVIO*/
        {
            try
            {
                this.LBWCT001.PROTOCOLO_RECEBIDO = LBWCT001_PROTOCOLO_RECEBIDO_P;
                this.SISINFAS.DCLSI_SINISTRO_FASE = SISINFAS_DCLSI_SINISTRO_FASE_P;
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

            Result = new { LBWCT001.PROTOCOLO_RECEBIDO, SISINFAS.DCLSI_SINISTRO_FASE, LBWCT002.PROTOCOLO_ENVIO };
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

            /*" -83- DISPLAY 'PTFASESS VERSAO 2 - INICIO PROCESSAMENTO EM  ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"PTFASESS VERSAO 2 - INICIO PROCESSAMENTO EM  {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -84- DISPLAY ' ' */
            _.Display($" ");

            /*" -85- DISPLAY 'PTFASESS - DADOS RECEBIDOS ------------------' */
            _.Display($"PTFASESS - DADOS RECEBIDOS ------------------");

            /*" -86- DISPLAY 'IN-SISTEMA                  = ' IN-SISTEMA */
            _.Display($"IN-SISTEMA                  = {LBWCT001.PROTOCOLO_RECEBIDO.IN_SISTEMA}");

            /*" -87- DISPLAY 'IN-CANAL                    = ' IN-CANAL */
            _.Display($"IN-CANAL                    = {LBWCT001.PROTOCOLO_RECEBIDO.IN_CANAL}");

            /*" -88- DISPLAY 'IN-PV                       = ' IN-PV */
            _.Display($"IN-PV                       = {LBWCT001.PROTOCOLO_RECEBIDO.IN_PV}");

            /*" -89- DISPLAY 'IN-USUARIO                  = ' IN-USUARIO */
            _.Display($"IN-USUARIO                  = {LBWCT001.PROTOCOLO_RECEBIDO.IN_USUARIO}");

            /*" -90- DISPLAY 'IN-OPERACAO                 = ' IN-OPERACAO */
            _.Display($"IN-OPERACAO                 = {LBWCT001.PROTOCOLO_RECEBIDO.IN_OPERACAO}");

            /*" -91- DISPLAY 'SISINFAS-COD-FONTE          = ' SISINFAS-COD-FONTE */
            _.Display($"SISINFAS-COD-FONTE          = {SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_COD_FONTE}");

            /*" -93- DISPLAY 'SISINFAS-NUM-PROTOCOLO-SINI = ' SISINFAS-NUM-PROTOCOLO-SINI */
            _.Display($"SISINFAS-NUM-PROTOCOLO-SINI = {SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_NUM_PROTOCOLO_SINI}");

            /*" -95- DISPLAY 'SISINFAS-DAC-PROTOCOLO-SINI = ' SISINFAS-DAC-PROTOCOLO-SINI */
            _.Display($"SISINFAS-DAC-PROTOCOLO-SINI = {SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_DAC_PROTOCOLO_SINI}");

            /*" -96- DISPLAY 'SISINFAS-COD-FASE           = ' SISINFAS-COD-FASE */
            _.Display($"SISINFAS-COD-FASE           = {SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_COD_FASE}");

            /*" -97- DISPLAY 'SISINFAS-COD-EVENTO         = ' SISINFAS-COD-EVENTO */
            _.Display($"SISINFAS-COD-EVENTO         = {SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_COD_EVENTO}");

            /*" -99- DISPLAY 'SISINFAS-NUM-OCORR-SINIACO  = ' SISINFAS-NUM-OCORR-SINIACO */
            _.Display($"SISINFAS-NUM-OCORR-SINIACO  = {SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_NUM_OCORR_SINIACO}");

            /*" -101- DISPLAY 'SISINFAS-DATA-INIVIG-REFAEV = ' SISINFAS-DATA-INIVIG-REFAEV */
            _.Display($"SISINFAS-DATA-INIVIG-REFAEV = {SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_DATA_INIVIG_REFAEV}");

            /*" -103- DISPLAY 'SISINFAS-DATA-ABERTURA-SIFA = ' SISINFAS-DATA-ABERTURA-SIFA */
            _.Display($"SISINFAS-DATA-ABERTURA-SIFA = {SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_DATA_ABERTURA_SIFA}");

            /*" -105- DISPLAY 'SISINFAS-DATA-FECHA-SIFA    = ' SISINFAS-DATA-FECHA-SIFA */
            _.Display($"SISINFAS-DATA-FECHA-SIFA    = {SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_DATA_FECHA_SIFA}");

            /*" -106- DISPLAY 'SISINFAS-TIMESTAMP          = ' SISINFAS-TIMESTAMP */
            _.Display($"SISINFAS-TIMESTAMP          = {SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_TIMESTAMP}");

            /*" -107- DISPLAY 'OUT-COD-RETORNO             = ' OUT-COD-RETORNO */
            _.Display($"OUT-COD-RETORNO             = {LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO}");

            /*" -108- DISPLAY 'OUT-COD-RETORNO-SQL         = ' OUT-COD-RETORNO-SQL */
            _.Display($"OUT-COD-RETORNO-SQL         = {LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL}");

            /*" -109- DISPLAY 'OUT-MENSAGEM                = ' OUT-MENSAGEM */
            _.Display($"OUT-MENSAGEM                = {LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM}");

            /*" -110- DISPLAY '---------------------------------------------' */
            _.Display($"---------------------------------------------");

            /*" -111- DISPLAY ' ' */
            _.Display($" ");

            /*" -119- DISPLAY 'PTFASESS VERSAO 2 - FIM PROCESSAMENTO EM  ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"PTFASESS VERSAO 2 - FIM PROCESSAMENTO EM  {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -121- PERFORM R0100-00-VERIFICA-PARAMETROS */

            R0100_00_VERIFICA_PARAMETROS_SECTION();

            /*" -122- IF OUT-COD-RETORNO EQUAL 01 */

            if (LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO == 01)
            {

                /*" -124- GO TO R0000-10-SAIDA. */

                R0000_10_SAIDA(); //GOTO
                return;
            }


            /*" -125- IF IN-OPERACAO EQUAL 1 */

            if (LBWCT001.PROTOCOLO_RECEBIDO.IN_OPERACAO == 1)
            {

                /*" -126- PERFORM R1000-00-PROCESSA-INCLUSAO */

                R1000_00_PROCESSA_INCLUSAO_SECTION();

                /*" -127- ELSE */
            }
            else
            {


                /*" -128- IF IN-OPERACAO EQUAL 2 */

                if (LBWCT001.PROTOCOLO_RECEBIDO.IN_OPERACAO == 2)
                {

                    /*" -129- PERFORM R2000-00-PROCESSA-ALTERACAO */

                    R2000_00_PROCESSA_ALTERACAO_SECTION();

                    /*" -130- ELSE */
                }
                else
                {


                    /*" -131- IF IN-OPERACAO EQUAL 3 */

                    if (LBWCT001.PROTOCOLO_RECEBIDO.IN_OPERACAO == 3)
                    {

                        /*" -132- PERFORM R3000-00-PROCESSA-EXCLUSAO */

                        R3000_00_PROCESSA_EXCLUSAO_SECTION();

                        /*" -133- ELSE */
                    }
                    else
                    {


                        /*" -134- MOVE 01 TO OUT-COD-RETORNO */
                        _.Move(01, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                        /*" -135- MOVE 'PTFASESS - OPERACAO NAO PREVISTA' TO OUT-MENSAGEM. */
                        _.Move("PTFASESS - OPERACAO NAO PREVISTA", LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM);
                    }

                }

            }


            /*" -0- FLUXCONTROL_PERFORM R0000_10_SAIDA */

            R0000_10_SAIDA();

        }

        [StopWatch]
        /*" R0000-10-SAIDA */
        private void R0000_10_SAIDA(bool isPerform = false)
        {
            /*" -141- PERFORM R0200-00-FORMATA-SAIDA */

            R0200_00_FORMATA_SAIDA_SECTION();

            /*" -142- DISPLAY 'PTFASESS - DADOS RETORNADOS -----------------' */
            _.Display($"PTFASESS - DADOS RETORNADOS -----------------");

            /*" -143- DISPLAY 'IN-SISTEMA                  = ' IN-SISTEMA */
            _.Display($"IN-SISTEMA                  = {LBWCT001.PROTOCOLO_RECEBIDO.IN_SISTEMA}");

            /*" -144- DISPLAY 'IN-CANAL                    = ' IN-CANAL */
            _.Display($"IN-CANAL                    = {LBWCT001.PROTOCOLO_RECEBIDO.IN_CANAL}");

            /*" -145- DISPLAY 'IN-PV                       = ' IN-PV */
            _.Display($"IN-PV                       = {LBWCT001.PROTOCOLO_RECEBIDO.IN_PV}");

            /*" -146- DISPLAY 'IN-USUARIO                  = ' IN-USUARIO */
            _.Display($"IN-USUARIO                  = {LBWCT001.PROTOCOLO_RECEBIDO.IN_USUARIO}");

            /*" -147- DISPLAY 'IN-OPERACAO                 = ' IN-OPERACAO */
            _.Display($"IN-OPERACAO                 = {LBWCT001.PROTOCOLO_RECEBIDO.IN_OPERACAO}");

            /*" -148- DISPLAY 'SISINFAS-COD-FONTE          = ' SISINFAS-COD-FONTE */
            _.Display($"SISINFAS-COD-FONTE          = {SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_COD_FONTE}");

            /*" -150- DISPLAY 'SISINFAS-NUM-PROTOCOLO-SINI = ' SISINFAS-NUM-PROTOCOLO-SINI */
            _.Display($"SISINFAS-NUM-PROTOCOLO-SINI = {SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_NUM_PROTOCOLO_SINI}");

            /*" -152- DISPLAY 'SISINFAS-DAC-PROTOCOLO-SINI = ' SISINFAS-DAC-PROTOCOLO-SINI */
            _.Display($"SISINFAS-DAC-PROTOCOLO-SINI = {SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_DAC_PROTOCOLO_SINI}");

            /*" -153- DISPLAY 'SISINFAS-COD-FASE           = ' SISINFAS-COD-FASE */
            _.Display($"SISINFAS-COD-FASE           = {SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_COD_FASE}");

            /*" -154- DISPLAY 'SISINFAS-COD-EVENTO         = ' SISINFAS-COD-EVENTO */
            _.Display($"SISINFAS-COD-EVENTO         = {SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_COD_EVENTO}");

            /*" -156- DISPLAY 'SISINFAS-NUM-OCORR-SINIACO  = ' SISINFAS-NUM-OCORR-SINIACO */
            _.Display($"SISINFAS-NUM-OCORR-SINIACO  = {SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_NUM_OCORR_SINIACO}");

            /*" -158- DISPLAY 'SISINFAS-DATA-INIVIG-REFAEV = ' SISINFAS-DATA-INIVIG-REFAEV */
            _.Display($"SISINFAS-DATA-INIVIG-REFAEV = {SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_DATA_INIVIG_REFAEV}");

            /*" -160- DISPLAY 'SISINFAS-DATA-ABERTURA-SIFA = ' SISINFAS-DATA-ABERTURA-SIFA */
            _.Display($"SISINFAS-DATA-ABERTURA-SIFA = {SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_DATA_ABERTURA_SIFA}");

            /*" -162- DISPLAY 'SISINFAS-DATA-FECHA-SIFA    = ' SISINFAS-DATA-FECHA-SIFA */
            _.Display($"SISINFAS-DATA-FECHA-SIFA    = {SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_DATA_FECHA_SIFA}");

            /*" -163- DISPLAY 'SISINFAS-TIMESTAMP          = ' SISINFAS-TIMESTAMP */
            _.Display($"SISINFAS-TIMESTAMP          = {SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_TIMESTAMP}");

            /*" -164- DISPLAY 'OUT-COD-RETORNO             = ' OUT-COD-RETORNO */
            _.Display($"OUT-COD-RETORNO             = {LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO}");

            /*" -165- DISPLAY 'OUT-COD-RETORNO-SQL         = ' OUT-COD-RETORNO-SQL */
            _.Display($"OUT-COD-RETORNO-SQL         = {LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL}");

            /*" -166- DISPLAY 'OUT-MENSAGEM                = ' OUT-MENSAGEM */
            _.Display($"OUT-MENSAGEM                = {LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM}");

            /*" -168- DISPLAY '---------------------------------------------' */
            _.Display($"---------------------------------------------");

            /*" -168- GOBACK. */

            throw new GoBack();

        }

        [StopWatch]
        /*" R0100-00-VERIFICA-PARAMETROS-SECTION */
        private void R0100_00_VERIFICA_PARAMETROS_SECTION()
        {
            /*" -175- IF SISINFAS-COD-FONTE EQUAL ZEROS */

            if (SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_COD_FONTE == 00)
            {

                /*" -176- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -178- MOVE 'PTFASESS - CODIGO DA FONTE NAO INFORMADO' TO OUT-MENSAGEM */
                _.Move("PTFASESS - CODIGO DA FONTE NAO INFORMADO", LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -180- GO TO R0100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -182- IF SISINFAS-NUM-PROTOCOLO-SINI EQUAL ZEROS */

            if (SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_NUM_PROTOCOLO_SINI == 00)
            {

                /*" -183- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -185- MOVE 'PTFASESS - NUMERO DO PROTOCOLO NAO INFORMADO' TO OUT-MENSAGEM */
                _.Move("PTFASESS - NUMERO DO PROTOCOLO NAO INFORMADO", LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -187- GO TO R0100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -188- IF SISINFAS-COD-FASE EQUAL ZEROS */

            if (SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_COD_FASE == 00)
            {

                /*" -189- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -191- MOVE 'PTFASESS - CODIGO DA FASE NAO INFORMADO' TO OUT-MENSAGEM */
                _.Move("PTFASESS - CODIGO DA FASE NAO INFORMADO", LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -193- GO TO R0100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -194- IF SISINFAS-COD-EVENTO EQUAL ZEROS */

            if (SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_COD_EVENTO == 00)
            {

                /*" -195- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -197- MOVE 'PTFASESS - CODIGO DO EVENTO NAO INFORMADO' TO OUT-MENSAGEM */
                _.Move("PTFASESS - CODIGO DO EVENTO NAO INFORMADO", LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -199- GO TO R0100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -201- IF SISINFAS-NUM-OCORR-SINIACO EQUAL ZEROS */

            if (SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_NUM_OCORR_SINIACO == 00)
            {

                /*" -202- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -204- MOVE 'PTFASESS - NR OCORRENCIA DO SINISTRO NAO INFORMADO' TO OUT-MENSAGEM */
                _.Move("PTFASESS - NR OCORRENCIA DO SINISTRO NAO INFORMADO", LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -206- GO TO R0100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -208- IF SISINFAS-DATA-INIVIG-REFAEV EQUAL SPACES */

            if (SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_DATA_INIVIG_REFAEV.IsEmpty())
            {

                /*" -209- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -211- MOVE 'PTFASESS - DATA INICIO VIGENCIA NAO INFORMADA' TO OUT-MENSAGEM */
                _.Move("PTFASESS - DATA INICIO VIGENCIA NAO INFORMADA", LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -213- GO TO R0100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -216- IF (IN-OPERACAO EQUAL 1 OR 2) AND (SISINFAS-DATA-ABERTURA-SIFA EQUAL SPACES) */

            if ((LBWCT001.PROTOCOLO_RECEBIDO.IN_OPERACAO.In("1", "2")) && (SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_DATA_ABERTURA_SIFA.IsEmpty()))
            {

                /*" -217- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -219- MOVE 'PTFASESS - DATA DE ABERTURA NAO INFORMADA' TO OUT-MENSAGEM */
                _.Move("PTFASESS - DATA DE ABERTURA NAO INFORMADA", LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -221- GO TO R0100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -224- IF (IN-OPERACAO EQUAL 1 OR 2) AND (SISINFAS-DATA-FECHA-SIFA EQUAL SPACES) */

            if ((LBWCT001.PROTOCOLO_RECEBIDO.IN_OPERACAO.In("1", "2")) && (SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_DATA_FECHA_SIFA.IsEmpty()))
            {

                /*" -225- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -227- MOVE 'PTFASESS - DATA DE FECHAMENTO NAO INFORMADA' TO OUT-MENSAGEM */
                _.Move("PTFASESS - DATA DE FECHAMENTO NAO INFORMADA", LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -227- GO TO R0100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-FORMATA-SAIDA-SECTION */
        private void R0200_00_FORMATA_SAIDA_SECTION()
        {
            /*" -238- MOVE SQLERRMC TO OUT-SQLERRMC */
            _.Move(DB.SQLERRMC, LBWCT002.PROTOCOLO_ENVIO.OUT_SQLERRMC);

            /*" -238- MOVE SQLSTATE TO OUT-SQLSTATE. */
            _.Move(DB.SQLSTATE, LBWCT002.PROTOCOLO_ENVIO.OUT_SQLSTATE);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-INCLUSAO-SECTION */
        private void R1000_00_PROCESSA_INCLUSAO_SECTION()
        {
            /*" -248- MOVE 'R1000' TO ABEND-COD-PROCESSO. */
            _.Move("R1000", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -248- PERFORM R1100-00-INCLUI-SINISTRO-FASE. */

            R1100_00_INCLUI_SINISTRO_FASE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-INCLUI-SINISTRO-FASE-SECTION */
        private void R1100_00_INCLUI_SINISTRO_FASE_SECTION()
        {
            /*" -257- MOVE 'R1100' TO ABEND-COD-PROCESSO. */
            _.Move("R1100", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -258- DISPLAY 'ENTROU NO R1100-00-INCLUI-SINISTRO-FASE' */
            _.Display($"ENTROU NO R1100-00-INCLUI-SINISTRO-FASE");

            /*" -259- DISPLAY ' ' */
            _.Display($" ");

            /*" -260- DISPLAY 'DADOS A SEREM INCLUIDOS NA SI_SINISTRO_FASE' */
            _.Display($"DADOS A SEREM INCLUIDOS NA SI_SINISTRO_FASE");

            /*" -261- DISPLAY 'SISINFAS-COD-FONTE          = ' SISINFAS-COD-FONTE */
            _.Display($"SISINFAS-COD-FONTE          = {SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_COD_FONTE}");

            /*" -263- DISPLAY 'SISINFAS-NUM-PROTOCOLO-SINI = ' SISINFAS-NUM-PROTOCOLO-SINI */
            _.Display($"SISINFAS-NUM-PROTOCOLO-SINI = {SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_NUM_PROTOCOLO_SINI}");

            /*" -265- DISPLAY 'SISINFAS-DAC-PROTOCOLO-SINI = ' SISINFAS-DAC-PROTOCOLO-SINI */
            _.Display($"SISINFAS-DAC-PROTOCOLO-SINI = {SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_DAC_PROTOCOLO_SINI}");

            /*" -266- DISPLAY 'SISINFAS-COD-FASE           = ' SISINFAS-COD-FASE */
            _.Display($"SISINFAS-COD-FASE           = {SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_COD_FASE}");

            /*" -267- DISPLAY 'SISINFAS-COD-EVENTO         = ' SISINFAS-COD-EVENTO */
            _.Display($"SISINFAS-COD-EVENTO         = {SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_COD_EVENTO}");

            /*" -269- DISPLAY 'SISINFAS-NUM-OCORR-SINIACO  = ' SISINFAS-NUM-OCORR-SINIACO */
            _.Display($"SISINFAS-NUM-OCORR-SINIACO  = {SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_NUM_OCORR_SINIACO}");

            /*" -271- DISPLAY 'SISINFAS-DATA-INIVIG-REFAEV = ' SISINFAS-DATA-INIVIG-REFAEV */
            _.Display($"SISINFAS-DATA-INIVIG-REFAEV = {SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_DATA_INIVIG_REFAEV}");

            /*" -273- DISPLAY 'SISINFAS-DATA-ABERTURA-SIFA = ' SISINFAS-DATA-ABERTURA-SIFA */
            _.Display($"SISINFAS-DATA-ABERTURA-SIFA = {SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_DATA_ABERTURA_SIFA}");

            /*" -275- DISPLAY 'SISINFAS-DATA-FECHA-SIFA    = ' SISINFAS-DATA-FECHA-SIFA */
            _.Display($"SISINFAS-DATA-FECHA-SIFA    = {SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_DATA_FECHA_SIFA}");

            /*" -277- DISPLAY '-------------------------------------------' */
            _.Display($"-------------------------------------------");

            /*" -299- PERFORM R1100_00_INCLUI_SINISTRO_FASE_DB_INSERT_1 */

            R1100_00_INCLUI_SINISTRO_FASE_DB_INSERT_1();

            /*" -302- MOVE SQLCODE TO WS-SQLCODE */
            _.Move(DB.SQLCODE, WS_SQLCODE);

            /*" -303- DISPLAY ' ' */
            _.Display($" ");

            /*" -305- DISPLAY 'SQLCODE DO INSERT NA SI_SINISTRO_FASE = ' WS-SQLCODE */
            _.Display($"SQLCODE DO INSERT NA SI_SINISTRO_FASE = {WS_SQLCODE}");

            /*" -306- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -307- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -308- MOVE SQLCODE TO OUT-COD-RETORNO-SQL */
                _.Move(DB.SQLCODE, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL);

                /*" -309- DISPLAY 'PTFASESS - PROBLEMAS NO INSERT SI_SINISTRO_FASE' */
                _.Display($"PTFASESS - PROBLEMAS NO INSERT SI_SINISTRO_FASE");

                /*" -310- DISPLAY ' ' */
                _.Display($" ");

                /*" -312- MOVE 'PTFASESS - PROBLEMAS NO INSERT SI_SINISTRO_FASE' TO OUT-MENSAGEM */
                _.Move("PTFASESS - PROBLEMAS NO INSERT SI_SINISTRO_FASE", LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -312- PERFORM R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION();
            }


        }

        [StopWatch]
        /*" R1100-00-INCLUI-SINISTRO-FASE-DB-INSERT-1 */
        public void R1100_00_INCLUI_SINISTRO_FASE_DB_INSERT_1()
        {
            /*" -299- EXEC SQL INSERT INTO SEGUROS.SI_SINISTRO_FASE (COD_FONTE, NUM_PROTOCOLO_SINI, DAC_PROTOCOLO_SINI, COD_FASE, COD_EVENTO, NUM_OCORR_SINIACO, DATA_INIVIG_REFAEV, DATA_ABERTURA_SIFA, DATA_FECHA_SIFA, TIMESTAMP) VALUES (:SISINFAS-COD-FONTE, :SISINFAS-NUM-PROTOCOLO-SINI, :SISINFAS-DAC-PROTOCOLO-SINI, :SISINFAS-COD-FASE, :SISINFAS-COD-EVENTO, :SISINFAS-NUM-OCORR-SINIACO, :SISINFAS-DATA-INIVIG-REFAEV, :SISINFAS-DATA-ABERTURA-SIFA, :SISINFAS-DATA-FECHA-SIFA, CURRENT TIMESTAMP) END-EXEC. */

            var r1100_00_INCLUI_SINISTRO_FASE_DB_INSERT_1_Insert1 = new R1100_00_INCLUI_SINISTRO_FASE_DB_INSERT_1_Insert1()
            {
                SISINFAS_COD_FONTE = SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_COD_FONTE.ToString(),
                SISINFAS_NUM_PROTOCOLO_SINI = SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_NUM_PROTOCOLO_SINI.ToString(),
                SISINFAS_DAC_PROTOCOLO_SINI = SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_DAC_PROTOCOLO_SINI.ToString(),
                SISINFAS_COD_FASE = SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_COD_FASE.ToString(),
                SISINFAS_COD_EVENTO = SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_COD_EVENTO.ToString(),
                SISINFAS_NUM_OCORR_SINIACO = SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_NUM_OCORR_SINIACO.ToString(),
                SISINFAS_DATA_INIVIG_REFAEV = SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_DATA_INIVIG_REFAEV.ToString(),
                SISINFAS_DATA_ABERTURA_SIFA = SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_DATA_ABERTURA_SIFA.ToString(),
                SISINFAS_DATA_FECHA_SIFA = SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_DATA_FECHA_SIFA.ToString(),
            };

            R1100_00_INCLUI_SINISTRO_FASE_DB_INSERT_1_Insert1.Execute(r1100_00_INCLUI_SINISTRO_FASE_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-PROCESSA-ALTERACAO-SECTION */
        private void R2000_00_PROCESSA_ALTERACAO_SECTION()
        {
            /*" -322- MOVE 'R2000' TO ABEND-COD-PROCESSO. */
            _.Move("R2000", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -332- PERFORM R2000_00_PROCESSA_ALTERACAO_DB_UPDATE_1 */

            R2000_00_PROCESSA_ALTERACAO_DB_UPDATE_1();

            /*" -335- IF SQLCODE NOT EQUAL 0 AND 100 */

            if (!DB.SQLCODE.In("0", "100"))
            {

                /*" -336- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -337- MOVE SQLCODE TO OUT-COD-RETORNO-SQL */
                _.Move(DB.SQLCODE, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL);

                /*" -339- MOVE 'PTFASESS - PROBLEMAS NO UPDATE SI_SINISTRO_FASE' TO OUT-MENSAGEM */
                _.Move("PTFASESS - PROBLEMAS NO UPDATE SI_SINISTRO_FASE", LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -339- PERFORM R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION();
            }


        }

        [StopWatch]
        /*" R2000-00-PROCESSA-ALTERACAO-DB-UPDATE-1 */
        public void R2000_00_PROCESSA_ALTERACAO_DB_UPDATE_1()
        {
            /*" -332- EXEC SQL UPDATE SEGUROS.SI_SINISTRO_FASE SET DATA_FECHA_SIFA = :SISINFAS-DATA-FECHA-SIFA, TIMESTAMP = CURRENT TIMESTAMP WHERE COD_FONTE = :SISINFAS-COD-FONTE AND NUM_PROTOCOLO_SINI = :SISINFAS-NUM-PROTOCOLO-SINI AND DAC_PROTOCOLO_SINI = :SISINFAS-DAC-PROTOCOLO-SINI AND COD_FASE = :SISINFAS-COD-FASE AND DATA_FECHA_SIFA = '9999-12-31' END-EXEC. */

            var r2000_00_PROCESSA_ALTERACAO_DB_UPDATE_1_Update1 = new R2000_00_PROCESSA_ALTERACAO_DB_UPDATE_1_Update1()
            {
                SISINFAS_DATA_FECHA_SIFA = SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_DATA_FECHA_SIFA.ToString(),
                SISINFAS_NUM_PROTOCOLO_SINI = SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_NUM_PROTOCOLO_SINI.ToString(),
                SISINFAS_DAC_PROTOCOLO_SINI = SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_DAC_PROTOCOLO_SINI.ToString(),
                SISINFAS_COD_FONTE = SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_COD_FONTE.ToString(),
                SISINFAS_COD_FASE = SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_COD_FASE.ToString(),
            };

            R2000_00_PROCESSA_ALTERACAO_DB_UPDATE_1_Update1.Execute(r2000_00_PROCESSA_ALTERACAO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-PROCESSA-EXCLUSAO-SECTION */
        private void R3000_00_PROCESSA_EXCLUSAO_SECTION()
        {
            /*" -349- MOVE 'R3000' TO ABEND-COD-PROCESSO. */
            _.Move("R3000", ABEND.DCLABEND.ABEND_COD_PROCESSO);

            /*" -356- PERFORM R3000_00_PROCESSA_EXCLUSAO_DB_DELETE_1 */

            R3000_00_PROCESSA_EXCLUSAO_DB_DELETE_1();

            /*" -359- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -360- MOVE 01 TO OUT-COD-RETORNO */
                _.Move(01, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO);

                /*" -361- MOVE SQLCODE TO OUT-COD-RETORNO-SQL */
                _.Move(DB.SQLCODE, LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL);

                /*" -363- MOVE 'PTFASESS - PROBLEMAS NO DELETE SI_SINISTRO_FASE' TO OUT-MENSAGEM */
                _.Move("PTFASESS - PROBLEMAS NO DELETE SI_SINISTRO_FASE", LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM);

                /*" -363- PERFORM R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION();
            }


        }

        [StopWatch]
        /*" R3000-00-PROCESSA-EXCLUSAO-DB-DELETE-1 */
        public void R3000_00_PROCESSA_EXCLUSAO_DB_DELETE_1()
        {
            /*" -356- EXEC SQL DELETE FROM SEGUROS.SI_SINISTRO_FASE WHERE COD_FONTE = :SISINFAS-COD-FONTE AND NUM_PROTOCOLO_SINI = :SISINFAS-NUM-PROTOCOLO-SINI AND DAC_PROTOCOLO_SINI = :SISINFAS-DAC-PROTOCOLO-SINI AND COD_FASE = :SISINFAS-COD-FASE END-EXEC. */

            var r3000_00_PROCESSA_EXCLUSAO_DB_DELETE_1_Delete1 = new R3000_00_PROCESSA_EXCLUSAO_DB_DELETE_1_Delete1()
            {
                SISINFAS_COD_FONTE = SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_COD_FONTE.ToString(),
                SISINFAS_NUM_PROTOCOLO_SINI = SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_NUM_PROTOCOLO_SINI.ToString(),
                SISINFAS_DAC_PROTOCOLO_SINI = SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_DAC_PROTOCOLO_SINI.ToString(),
                SISINFAS_COD_FASE = SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_COD_FASE.ToString(),
            };

            R3000_00_PROCESSA_EXCLUSAO_DB_DELETE_1_Delete1.Execute(r3000_00_PROCESSA_EXCLUSAO_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -372- MOVE 'PTFASESS' TO ABEND-COD-APLICACAO */
            _.Move("PTFASESS", ABEND.DCLABEND.ABEND_COD_APLICACAO);

            /*" -372- MOVE IN-USUARIO TO ABEND-COD-USUARIO OF DCLABEND */
            _.Move(LBWCT001.PROTOCOLO_RECEBIDO.IN_USUARIO, ABEND.DCLABEND.ABEND_COD_USUARIO);

            /*" -372- MOVE SQLCODE TO ABEND-SQLCODE OF DCLABEND */
            _.Move(DB.SQLCODE, ABEND.DCLABEND.ABEND_SQLCODE);

            /*" -372- MOVE SQLERRMC TO ABEND-SQLERRMC OF DCLABEND */
            _.Move(DB.SQLERRMC, ABEND.DCLABEND.ABEND_SQLERRMC);

            /*" -372- MOVE SQLSTATE TO ABEND-SQLEXT OF DCLABEND. */
            _.Move(DB.SQLSTATE, ABEND.DCLABEND.ABEND_SQLEXT);

            /*" -373- CALL 'PTABEN1S' USING DCLABEND, PROTOCOLO-ENVIO. */
            _.Call("PTABEN1S", ABEND.DCLABEND, LBWCT002.PROTOCOLO_ENVIO);

            /*" -374- MOVE SQLERRMC TO OUT-SQLERRMC */
            _.Move(DB.SQLERRMC, LBWCT002.PROTOCOLO_ENVIO.OUT_SQLERRMC);

            /*" -375- MOVE SQLSTATE TO OUT-SQLSTATE */
            _.Move(DB.SQLSTATE, LBWCT002.PROTOCOLO_ENVIO.OUT_SQLSTATE);

            /*" -376- DISPLAY 'PTFASESS - DADOS RECEBIDOS ------------------' */
            _.Display($"PTFASESS - DADOS RECEBIDOS ------------------");

            /*" -377- DISPLAY 'IN-SISTEMA                  = ' IN-SISTEMA */
            _.Display($"IN-SISTEMA                  = {LBWCT001.PROTOCOLO_RECEBIDO.IN_SISTEMA}");

            /*" -378- DISPLAY 'IN-CANAL                    = ' IN-CANAL */
            _.Display($"IN-CANAL                    = {LBWCT001.PROTOCOLO_RECEBIDO.IN_CANAL}");

            /*" -379- DISPLAY 'IN-PV                       = ' IN-PV */
            _.Display($"IN-PV                       = {LBWCT001.PROTOCOLO_RECEBIDO.IN_PV}");

            /*" -380- DISPLAY 'IN-USUARIO                  = ' IN-USUARIO */
            _.Display($"IN-USUARIO                  = {LBWCT001.PROTOCOLO_RECEBIDO.IN_USUARIO}");

            /*" -381- DISPLAY 'IN-OPERACAO                 = ' IN-OPERACAO */
            _.Display($"IN-OPERACAO                 = {LBWCT001.PROTOCOLO_RECEBIDO.IN_OPERACAO}");

            /*" -382- DISPLAY 'SISINFAS-COD-FONTE          = ' SISINFAS-COD-FONTE */
            _.Display($"SISINFAS-COD-FONTE          = {SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_COD_FONTE}");

            /*" -384- DISPLAY 'SISINFAS-NUM-PROTOCOLO-SINI = ' SISINFAS-NUM-PROTOCOLO-SINI */
            _.Display($"SISINFAS-NUM-PROTOCOLO-SINI = {SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_NUM_PROTOCOLO_SINI}");

            /*" -386- DISPLAY 'SISINFAS-DAC-PROTOCOLO-SINI = ' SISINFAS-DAC-PROTOCOLO-SINI */
            _.Display($"SISINFAS-DAC-PROTOCOLO-SINI = {SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_DAC_PROTOCOLO_SINI}");

            /*" -387- DISPLAY 'SISINFAS-COD-FASE           = ' SISINFAS-COD-FASE */
            _.Display($"SISINFAS-COD-FASE           = {SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_COD_FASE}");

            /*" -388- DISPLAY 'SISINFAS-COD-EVENTO         = ' SISINFAS-COD-EVENTO */
            _.Display($"SISINFAS-COD-EVENTO         = {SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_COD_EVENTO}");

            /*" -390- DISPLAY 'SISINFAS-NUM-OCORR-SINIACO  = ' SISINFAS-NUM-OCORR-SINIACO */
            _.Display($"SISINFAS-NUM-OCORR-SINIACO  = {SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_NUM_OCORR_SINIACO}");

            /*" -392- DISPLAY 'SISINFAS-DATA-INIVIG-REFAEV = ' SISINFAS-DATA-INIVIG-REFAEV */
            _.Display($"SISINFAS-DATA-INIVIG-REFAEV = {SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_DATA_INIVIG_REFAEV}");

            /*" -394- DISPLAY 'SISINFAS-DATA-ABERTURA-SIFA = ' SISINFAS-DATA-ABERTURA-SIFA */
            _.Display($"SISINFAS-DATA-ABERTURA-SIFA = {SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_DATA_ABERTURA_SIFA}");

            /*" -396- DISPLAY 'SISINFAS-DATA-FECHA-SIFA    = ' SISINFAS-DATA-FECHA-SIFA */
            _.Display($"SISINFAS-DATA-FECHA-SIFA    = {SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_DATA_FECHA_SIFA}");

            /*" -397- DISPLAY 'SISINFAS-TIMESTAMP          = ' SISINFAS-TIMESTAMP */
            _.Display($"SISINFAS-TIMESTAMP          = {SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_TIMESTAMP}");

            /*" -398- DISPLAY 'OUT-COD-RETORNO             = ' OUT-COD-RETORNO */
            _.Display($"OUT-COD-RETORNO             = {LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO}");

            /*" -399- DISPLAY 'OUT-COD-RETORNO-SQL         = ' OUT-COD-RETORNO-SQL */
            _.Display($"OUT-COD-RETORNO-SQL         = {LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL}");

            /*" -400- DISPLAY 'OUT-MENSAGEM                = ' OUT-MENSAGEM */
            _.Display($"OUT-MENSAGEM                = {LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM}");

            /*" -401- DISPLAY 'OUT-SQLERRMC                = ' OUT-SQLERRMC */
            _.Display($"OUT-SQLERRMC                = {LBWCT002.PROTOCOLO_ENVIO.OUT_SQLERRMC}");

            /*" -402- DISPLAY 'OUT-SQLSTATE                = ' OUT-SQLSTATE */
            _.Display($"OUT-SQLSTATE                = {LBWCT002.PROTOCOLO_ENVIO.OUT_SQLSTATE}");

            /*" -403- DISPLAY '---------------------------------------------' */
            _.Display($"---------------------------------------------");

            /*" -403- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}