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
using Sias.Sinistro.DB2.SI1040S;

namespace Code
{
    public class SI1040S
    {
        public bool IsCall { get; set; }

        public SI1040S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      * SISTEMA .........: SISTEMA SINISTRO                            *      */
        /*"      * PROGRAMA ........: SI1040S.                                    *      */
        /*"      * ANALISTA ........: ALEXIS VEAS ITURRIAGA                       *      */
        /*"      * PROGRAMADOR .....: ALEXIS VEAS ITURRIAGA                       *      */
        /*"      * DATA CODIFICACAO : OUT/2005                                    *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      * OBJETIVO.: ESTA SUBROTINA EH PARA ACHAR O CODIGO DA DESPESA    *      */
        /*"      * RELACIONADO AO CODIGO DE OPERACAO DO SINISTRO.                 *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *  VERSAO    DATA        PROGRAMADOR              ALTERACAO      *      */
        /*"      *    3       23/11/2010  DIOGO MATHEUS            CIRCULAR 395   *      */
        /*"      *                                                 PROCURE V.3    *      */
        /*"      ******************************************************************      */
        /*"      * ALTERADO EM 27/04/2006 EM VIRTUDE DA SSI 8482 ONDE FORAM       *      */
        /*"      * ALTERADOS OS CODIGOS DE DESPESAS PARA O RAMO 66.    ALEXIS     *      */
        /*"      ******************************************************************      */
        /*"      * ALTERADO EM 13/03/2008 - PROCURAR POR EDSON                    *      */
        /*"      * INCLUSAO DA FUNCAO_OPERACAO = 'RSDEP' PARA ATENDER PAGAMENTOS  *      */
        /*"      * DE DESPESAS RESSARCIMENTO                                      *      */
        /*"      ******************************************************************      */
        /*"V.03  * ALTERADO EM 24/02/2022 - PROCURAR POR V.03    HERVAL SOUZA     *      */
        /*"      *   AJUSTES DEVIDO AO  PROJETO DESCONFORMIDADE SIAS.             *      */
        /*"      *   AS OPERACOES DE PAGAMENTO DE SINISTRO SO SERAO BAIXADAS APOS *      */
        /*"      *   RETORNO DO SAP.  ASSIM PREVE CONSULTA COM AS OPERACOES DE    *      */
        /*"      *   LIBERACAO.                              JAZZ: 366844         *      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES


        public Copies.LBSI1040 LBSI1040 { get; set; } = new Copies.LBSI1040();
        public Dclgens.GEOPERAC GEOPERAC { get; set; } = new Dclgens.GEOPERAC();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(LBSI1040_SI1040S_PARAMETROS LBSI1040_SI1040S_PARAMETROS_P) //PROCEDURE DIVISION USING 
        /*SI1040S_PARAMETROS*/
        {
            try
            {
                this.LBSI1040.SI1040S_PARAMETROS = LBSI1040_SI1040S_PARAMETROS_P;

                /*" -74- PERFORM R10-CONSISTE-ENTRADA THRU R10-FIM. */

                R10_CONSISTE_ENTRADA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R10_FIM*/


                /*" -75- IF SI1040S-RC EQUAL ZEROS */

                if (LBSI1040.SI1040S_PARAMETROS.SI1040S_RC == 00)
                {

                    /*" -76- PERFORM R20-PROCESSA-DESPESA THRU R20-FIM */

                    R20_PROCESSA_DESPESA(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R20_FIM*/


                    /*" -77- ELSE */
                }
                else
                {


                    /*" -78- MOVE 9999 TO SI1040S-COD-DESPESA */
                    _.Move(9999, LBSI1040.SI1040S_PARAMETROS.SI1040S_COD_DESPESA);

                    /*" -80- END-IF. */
                }


                /*" -80- GOBACK. */

                throw new GoBack();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LBSI1040.SI1040S_PARAMETROS };
            return Result;
        }

        [StopWatch]
        /*" R10-CONSISTE-ENTRADA */
        private void R10_CONSISTE_ENTRADA(bool isPerform = false)
        {
            /*" -89- IF SI1040S-RAMO-EMISSOR NOT NUMERIC */

            if (!LBSI1040.SI1040S_PARAMETROS.SI1040S_RAMO_EMISSOR.IsNumeric())
            {

                /*" -90- MOVE 01 TO SI1040S-RC */
                _.Move(01, LBSI1040.SI1040S_PARAMETROS.SI1040S_RC);

                /*" -92- MOVE 'RAMO INFORMADO NAO EH NUMERICO' TO SI1040S-ERRO-MENSAGEM */
                _.Move("RAMO INFORMADO NAO EH NUMERICO", LBSI1040.SI1040S_PARAMETROS.SI1040S_ERRO_MENSAGEM);

                /*" -93- GO TO R10-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R10_FIM*/ //GOTO
                return;

                /*" -95- END-IF. */
            }


            /*" -96- IF SI1040S-RAMO-EMISSOR EQUAL ZEROS */

            if (LBSI1040.SI1040S_PARAMETROS.SI1040S_RAMO_EMISSOR == 00)
            {

                /*" -97- MOVE 01 TO SI1040S-RC */
                _.Move(01, LBSI1040.SI1040S_PARAMETROS.SI1040S_RC);

                /*" -98- MOVE 'RAMO INFORMADO ZERADO' TO SI1040S-ERRO-MENSAGEM */
                _.Move("RAMO INFORMADO ZERADO", LBSI1040.SI1040S_PARAMETROS.SI1040S_ERRO_MENSAGEM);

                /*" -99- GO TO R10-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R10_FIM*/ //GOTO
                return;

                /*" -101- END-IF. */
            }


            /*" -102- IF SI1040S-COD-OPERACAO NOT NUMERIC */

            if (!LBSI1040.SI1040S_PARAMETROS.SI1040S_COD_OPERACAO.IsNumeric())
            {

                /*" -103- MOVE 01 TO SI1040S-RC */
                _.Move(01, LBSI1040.SI1040S_PARAMETROS.SI1040S_RC);

                /*" -105- MOVE 'CODIGO DE OPERACAO INFORMADO NAO EH NUMERICO' TO SI1040S-ERRO-MENSAGEM */
                _.Move("CODIGO DE OPERACAO INFORMADO NAO EH NUMERICO", LBSI1040.SI1040S_PARAMETROS.SI1040S_ERRO_MENSAGEM);

                /*" -106- GO TO R10-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R10_FIM*/ //GOTO
                return;

                /*" -108- END-IF. */
            }


            /*" -109- IF SI1040S-COD-OPERACAO EQUAL ZEROS */

            if (LBSI1040.SI1040S_PARAMETROS.SI1040S_COD_OPERACAO == 00)
            {

                /*" -110- MOVE 01 TO SI1040S-RC */
                _.Move(01, LBSI1040.SI1040S_PARAMETROS.SI1040S_RC);

                /*" -112- MOVE 'CODIGO DE OPERACAO INFORMADO ZERADO' TO SI1040S-ERRO-MENSAGEM */
                _.Move("CODIGO DE OPERACAO INFORMADO ZERADO", LBSI1040.SI1040S_PARAMETROS.SI1040S_ERRO_MENSAGEM);

                /*" -113- GO TO R10-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R10_FIM*/ //GOTO
                return;

                /*" -115- END-IF. */
            }


            /*" -117- IF SI1040S-TIP-REGISTRO NOT EQUAL '0' AND SI1040S-TIP-REGISTRO NOT EQUAL '1' */

            if (LBSI1040.SI1040S_PARAMETROS.SI1040S_TIP_REGISTRO != "0" && LBSI1040.SI1040S_PARAMETROS.SI1040S_TIP_REGISTRO != "1")
            {

                /*" -118- MOVE 01 TO SI1040S-RC */
                _.Move(01, LBSI1040.SI1040S_PARAMETROS.SI1040S_RC);

                /*" -120- MOVE 'TIPO DE REGISTRO DIFERENTE DE 0 E 1' TO SI1040S-ERRO-MENSAGEM */
                _.Move("TIPO DE REGISTRO DIFERENTE DE 0 E 1", LBSI1040.SI1040S_PARAMETROS.SI1040S_ERRO_MENSAGEM);

                /*" -121- GO TO R10-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R10_FIM*/ //GOTO
                return;

                /*" -123- END-IF. */
            }


            /*" -123- PERFORM R100-PROCESSA-OPER THRU R100-FIM. */

            R100_PROCESSA_OPER(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_FIM*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R10_FIM*/

        [StopWatch]
        /*" R100-PROCESSA-OPER */
        private void R100_PROCESSA_OPER(bool isPerform = false)
        {
            /*" -136- MOVE SI1040S-COD-OPERACAO TO GEOPERAC-COD-OPERACAO. */
            _.Move(LBSI1040.SI1040S_PARAMETROS.SI1040S_COD_OPERACAO, GEOPERAC.DCLGE_OPERACAO.GEOPERAC_COD_OPERACAO);

            /*" -148- PERFORM R100_PROCESSA_OPER_DB_SELECT_1 */

            R100_PROCESSA_OPER_DB_SELECT_1();

            /*" -151- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -152- IF SQLCODE EQUAL +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -154- MOVE 'CODIGO DE OPERACAO NAO ENCONTRADO NA GE_OPERACAO' TO SI1040S-ERRO-MENSAGEM */
                    _.Move("CODIGO DE OPERACAO NAO ENCONTRADO NA GE_OPERACAO", LBSI1040.SI1040S_PARAMETROS.SI1040S_ERRO_MENSAGEM);

                    /*" -155- ELSE */
                }
                else
                {


                    /*" -157- MOVE 'ERRO DE ACESSO NA TABELA GE_OPERACAO' TO SI1040S-ERRO-MENSAGEM */
                    _.Move("ERRO DE ACESSO NA TABELA GE_OPERACAO", LBSI1040.SI1040S_PARAMETROS.SI1040S_ERRO_MENSAGEM);

                    /*" -158- END-IF */
                }


                /*" -159- MOVE 01 TO SI1040S-RC */
                _.Move(01, LBSI1040.SI1040S_PARAMETROS.SI1040S_RC);

                /*" -160- MOVE SQLCODE TO SI1040S-ERRO-SQLCODE */
                _.Move(DB.SQLCODE, LBSI1040.SI1040S_PARAMETROS.SI1040S_ERRO_SQLCODE);

                /*" -161- GO TO R100-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_FIM*/ //GOTO
                return;

                /*" -161- END-IF. */
            }


        }

        [StopWatch]
        /*" R100-PROCESSA-OPER-DB-SELECT-1 */
        public void R100_PROCESSA_OPER_DB_SELECT_1()
        {
            /*" -148- EXEC SQL SELECT FUNCAO_OPERACAO, IND_TIPO_FUNCAO INTO :GEOPERAC-FUNCAO-OPERACAO, :GEOPERAC-IND-TIPO-FUNCAO FROM SEGUROS.GE_OPERACAO WHERE IDE_SISTEMA = 'SI' AND COD_OPERACAO = :GEOPERAC-COD-OPERACAO END-EXEC. */

            var r100_PROCESSA_OPER_DB_SELECT_1_Query1 = new R100_PROCESSA_OPER_DB_SELECT_1_Query1()
            {
                GEOPERAC_COD_OPERACAO = GEOPERAC.DCLGE_OPERACAO.GEOPERAC_COD_OPERACAO.ToString(),
            };

            var executed_1 = R100_PROCESSA_OPER_DB_SELECT_1_Query1.Execute(r100_PROCESSA_OPER_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GEOPERAC_FUNCAO_OPERACAO, GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO);
                _.Move(executed_1.GEOPERAC_IND_TIPO_FUNCAO, GEOPERAC.DCLGE_OPERACAO.GEOPERAC_IND_TIPO_FUNCAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_FIM*/

        [StopWatch]
        /*" R20-PROCESSA-DESPESA */
        private void R20_PROCESSA_DESPESA(bool isPerform = false)
        {
            /*" -173- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'IND' OR 'LIB' */

            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO.In("IND", "LIB"))
            {

                /*" -176- IF SI1040S-RAMO-EMISSOR EQUAL 66 */

                if (LBSI1040.SI1040S_PARAMETROS.SI1040S_RAMO_EMISSOR == 66)
                {

                    /*" -177- MOVE 3309 TO SI1040S-COD-DESPESA */
                    _.Move(3309, LBSI1040.SI1040S_PARAMETROS.SI1040S_COD_DESPESA);

                    /*" -178- ELSE */
                }
                else
                {


                    /*" -179- MOVE 3092 TO SI1040S-COD-DESPESA */
                    _.Move(3092, LBSI1040.SI1040S_PARAMETROS.SI1040S_COD_DESPESA);

                    /*" -180- END-IF */
                }


                /*" -181- GO TO R20-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R20_FIM*/ //GOTO
                return;

                /*" -183- END-IF. */
            }


            /*" -184- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'JBIND' OR 'JLIND' */

            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO.In("JBIND", "JLIND"))
            {

                /*" -185- IF SI1040S-COD-OPERACAO EQUAL 8206 OR 8205 */

                if (LBSI1040.SI1040S_PARAMETROS.SI1040S_COD_OPERACAO.In("8206", "8205"))
                {

                    /*" -188- IF SI1040S-RAMO-EMISSOR EQUAL 66 */

                    if (LBSI1040.SI1040S_PARAMETROS.SI1040S_RAMO_EMISSOR == 66)
                    {

                        /*" -189- MOVE 3307 TO SI1040S-COD-DESPESA */
                        _.Move(3307, LBSI1040.SI1040S_PARAMETROS.SI1040S_COD_DESPESA);

                        /*" -190- ELSE */
                    }
                    else
                    {


                        /*" -191- MOVE 3116 TO SI1040S-COD-DESPESA */
                        _.Move(3116, LBSI1040.SI1040S_PARAMETROS.SI1040S_COD_DESPESA);

                        /*" -192- END-IF */
                    }


                    /*" -193- ELSE */
                }
                else
                {


                    /*" -196- IF SI1040S-RAMO-EMISSOR EQUAL 66 */

                    if (LBSI1040.SI1040S_PARAMETROS.SI1040S_RAMO_EMISSOR == 66)
                    {

                        /*" -197- MOVE 3311 TO SI1040S-COD-DESPESA */
                        _.Move(3311, LBSI1040.SI1040S_PARAMETROS.SI1040S_COD_DESPESA);

                        /*" -198- ELSE */
                    }
                    else
                    {


                        /*" -199- MOVE 3117 TO SI1040S-COD-DESPESA */
                        _.Move(3117, LBSI1040.SI1040S_PARAMETROS.SI1040S_COD_DESPESA);

                        /*" -200- END-IF */
                    }


                    /*" -201- END-IF */
                }


                /*" -202- GO TO R20-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R20_FIM*/ //GOTO
                return;

                /*" -204- END-IF. */
            }


            /*" -205- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'RSHOP' OR 'RSHLB' */

            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO.In("RSHOP", "RSHLB"))
            {

                /*" -206- IF SI1040S-RAMO-EMISSOR EQUAL 66 */

                if (LBSI1040.SI1040S_PARAMETROS.SI1040S_RAMO_EMISSOR == 66)
                {

                    /*" -207- MOVE 3097 TO SI1040S-COD-DESPESA */
                    _.Move(3097, LBSI1040.SI1040S_PARAMETROS.SI1040S_COD_DESPESA);

                    /*" -208- ELSE */
                }
                else
                {


                    /*" -209- MOVE 3305 TO SI1040S-COD-DESPESA */
                    _.Move(3305, LBSI1040.SI1040S_PARAMETROS.SI1040S_COD_DESPESA);

                    /*" -210- END-IF */
                }


                /*" -211- GO TO R20-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R20_FIM*/ //GOTO
                return;

                /*" -215- END-IF. */
            }


            /*" -216- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'RSDEP' OR 'RSDLB' */

            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO.In("RSDEP", "RSDLB"))
            {

                /*" -217- IF SI1040S-RAMO-EMISSOR EQUAL 66 */

                if (LBSI1040.SI1040S_PARAMETROS.SI1040S_RAMO_EMISSOR == 66)
                {

                    /*" -218- MOVE 3097 TO SI1040S-COD-DESPESA */
                    _.Move(3097, LBSI1040.SI1040S_PARAMETROS.SI1040S_COD_DESPESA);

                    /*" -219- ELSE */
                }
                else
                {


                    /*" -220- MOVE 3305 TO SI1040S-COD-DESPESA */
                    _.Move(3305, LBSI1040.SI1040S_PARAMETROS.SI1040S_COD_DESPESA);

                    /*" -221- END-IF */
                }


                /*" -222- GO TO R20-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R20_FIM*/ //GOTO
                return;

                /*" -225- END-IF. */
            }


            /*" -226- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'HPAG' OR 'HLIB' */

            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO.In("HPAG", "HLIB"))
            {

                /*" -229- IF SI1040S-RAMO-EMISSOR EQUAL 66 */

                if (LBSI1040.SI1040S_PARAMETROS.SI1040S_RAMO_EMISSOR == 66)
                {

                    /*" -230- MOVE 3310 TO SI1040S-COD-DESPESA */
                    _.Move(3310, LBSI1040.SI1040S_PARAMETROS.SI1040S_COD_DESPESA);

                    /*" -232- ELSE */
                }
                else
                {


                    /*" -233- IF SI1040S-RAMO-EMISSOR EQUAL 68 OR 65 OR 61 */

                    if (LBSI1040.SI1040S_PARAMETROS.SI1040S_RAMO_EMISSOR.In("68", "65", "61"))
                    {

                        /*" -234- MOVE 3122 TO SI1040S-COD-DESPESA */
                        _.Move(3122, LBSI1040.SI1040S_PARAMETROS.SI1040S_COD_DESPESA);

                        /*" -235- ELSE */
                    }
                    else
                    {


                        /*" -236- IF SI1040S-TIP-REGISTRO EQUAL '1' */

                        if (LBSI1040.SI1040S_PARAMETROS.SI1040S_TIP_REGISTRO == "1")
                        {

                            /*" -237- MOVE 3105 TO SI1040S-COD-DESPESA */
                            _.Move(3105, LBSI1040.SI1040S_PARAMETROS.SI1040S_COD_DESPESA);

                            /*" -238- ELSE */
                        }
                        else
                        {


                            /*" -239- MOVE 3122 TO SI1040S-COD-DESPESA */
                            _.Move(3122, LBSI1040.SI1040S_PARAMETROS.SI1040S_COD_DESPESA);

                            /*" -240- END-IF */
                        }


                        /*" -241- END-IF */
                    }


                    /*" -242- END-IF */
                }


                /*" -243- GO TO R20-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R20_FIM*/ //GOTO
                return;

                /*" -245- END-IF. */
            }


            /*" -246- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'DPAG' OR 'DLIB' */

            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO.In("DPAG", "DLIB"))
            {

                /*" -249- IF SI1040S-RAMO-EMISSOR EQUAL 66 */

                if (LBSI1040.SI1040S_PARAMETROS.SI1040S_RAMO_EMISSOR == 66)
                {

                    /*" -250- MOVE 3310 TO SI1040S-COD-DESPESA */
                    _.Move(3310, LBSI1040.SI1040S_PARAMETROS.SI1040S_COD_DESPESA);

                    /*" -252- ELSE */
                }
                else
                {


                    /*" -253- IF SI1040S-RAMO-EMISSOR EQUAL 68 OR 65 OR 61 */

                    if (LBSI1040.SI1040S_PARAMETROS.SI1040S_RAMO_EMISSOR.In("68", "65", "61"))
                    {

                        /*" -254- MOVE 3122 TO SI1040S-COD-DESPESA */
                        _.Move(3122, LBSI1040.SI1040S_PARAMETROS.SI1040S_COD_DESPESA);

                        /*" -255- ELSE */
                    }
                    else
                    {


                        /*" -256- IF SI1040S-TIP-REGISTRO EQUAL '1' */

                        if (LBSI1040.SI1040S_PARAMETROS.SI1040S_TIP_REGISTRO == "1")
                        {

                            /*" -257- MOVE 3103 TO SI1040S-COD-DESPESA */
                            _.Move(3103, LBSI1040.SI1040S_PARAMETROS.SI1040S_COD_DESPESA);

                            /*" -258- ELSE */
                        }
                        else
                        {


                            /*" -259- MOVE 3122 TO SI1040S-COD-DESPESA */
                            _.Move(3122, LBSI1040.SI1040S_PARAMETROS.SI1040S_COD_DESPESA);

                            /*" -260- END-IF */
                        }


                        /*" -261- END-IF */
                    }


                    /*" -262- END-IF */
                }


                /*" -263- GO TO R20-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R20_FIM*/ //GOTO
                return;

                /*" -268- END-IF. */
            }


            /*" -269- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'RSREP' OR 'RSRLB' */

            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO.In("RSREP", "RSRLB"))
            {

                /*" -270- MOVE 3306 TO SI1040S-COD-DESPESA */
                _.Move(3306, LBSI1040.SI1040S_PARAMETROS.SI1040S_COD_DESPESA);

                /*" -271- GO TO R20-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R20_FIM*/ //GOTO
                return;

                /*" -273- END-IF. */
            }


            /*" -274- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'JBDP' OR 'JLDP' */

            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO.In("JBDP", "JLDP"))
            {

                /*" -277- IF SI1040S-RAMO-EMISSOR EQUAL 66 */

                if (LBSI1040.SI1040S_PARAMETROS.SI1040S_RAMO_EMISSOR == 66)
                {

                    /*" -278- MOVE 3308 TO SI1040S-COD-DESPESA */
                    _.Move(3308, LBSI1040.SI1040S_PARAMETROS.SI1040S_COD_DESPESA);

                    /*" -279- ELSE */
                }
                else
                {


                    /*" -280- MOVE 3118 TO SI1040S-COD-DESPESA */
                    _.Move(3118, LBSI1040.SI1040S_PARAMETROS.SI1040S_COD_DESPESA);

                    /*" -281- END-IF */
                }


                /*" -282- GO TO R20-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R20_FIM*/ //GOTO
                return;

                /*" -284- END-IF. */
            }


            /*" -285- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'JBHON' OR 'JLHON' */

            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO.In("JBHON", "JLHON"))
            {

                /*" -288- IF SI1040S-RAMO-EMISSOR EQUAL 66 */

                if (LBSI1040.SI1040S_PARAMETROS.SI1040S_RAMO_EMISSOR == 66)
                {

                    /*" -289- MOVE 3312 TO SI1040S-COD-DESPESA */
                    _.Move(3312, LBSI1040.SI1040S_PARAMETROS.SI1040S_COD_DESPESA);

                    /*" -290- ELSE */
                }
                else
                {


                    /*" -291- MOVE 3119 TO SI1040S-COD-DESPESA */
                    _.Move(3119, LBSI1040.SI1040S_PARAMETROS.SI1040S_COD_DESPESA);

                    /*" -292- END-IF */
                }


                /*" -293- GO TO R20-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R20_FIM*/ //GOTO
                return;

                /*" -295- END-IF. */
            }


            /*" -296- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'JBDES' OR 'JLDES' */

            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO.In("JBDES", "JLDES"))
            {

                /*" -299- IF SI1040S-RAMO-EMISSOR EQUAL 66 */

                if (LBSI1040.SI1040S_PARAMETROS.SI1040S_RAMO_EMISSOR == 66)
                {

                    /*" -300- MOVE 3312 TO SI1040S-COD-DESPESA */
                    _.Move(3312, LBSI1040.SI1040S_PARAMETROS.SI1040S_COD_DESPESA);

                    /*" -301- ELSE */
                }
                else
                {


                    /*" -302- MOVE 3119 TO SI1040S-COD-DESPESA */
                    _.Move(3119, LBSI1040.SI1040S_PARAMETROS.SI1040S_COD_DESPESA);

                    /*" -303- END-IF */
                }


                /*" -304- GO TO R20-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R20_FIM*/ //GOTO
                return;

                /*" -306- END-IF. */
            }


            /*" -307- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'DSPAG' OR 'DSLIB' */

            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO.In("DSPAG", "DSLIB"))
            {

                /*" -308- MOVE 3301 TO SI1040S-COD-DESPESA */
                _.Move(3301, LBSI1040.SI1040S_PARAMETROS.SI1040S_COD_DESPESA);

                /*" -309- GO TO R20-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R20_FIM*/ //GOTO
                return;

                /*" -311- END-IF. */
            }


            /*" -312- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'HSPAG' OR 'HSLIB' */

            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO.In("HSPAG", "HSLIB"))
            {

                /*" -313- MOVE 3304 TO SI1040S-COD-DESPESA */
                _.Move(3304, LBSI1040.SI1040S_PARAMETROS.SI1040S_COD_DESPESA);

                /*" -314- GO TO R20-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R20_FIM*/ //GOTO
                return;

                /*" -316- END-IF. */
            }


            /*" -317- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'APAG' OR 'ALIB' */

            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO.In("APAG", "ALIB"))
            {

                /*" -318- MOVE 3092 TO SI1040S-COD-DESPESA */
                _.Move(3092, LBSI1040.SI1040S_PARAMETROS.SI1040S_COD_DESPESA);

                /*" -319- GO TO R20-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R20_FIM*/ //GOTO
                return;

                /*" -321- END-IF. */
            }


            /*" -322- MOVE 01 TO SI1040S-RC. */
            _.Move(01, LBSI1040.SI1040S_PARAMETROS.SI1040S_RC);

            /*" -323- MOVE 9999 TO SI1040S-COD-DESPESA. */
            _.Move(9999, LBSI1040.SI1040S_PARAMETROS.SI1040S_COD_DESPESA);

            /*" -324- MOVE 'CODIGO DE OPERACAO NAO PREVISTO PARA DESPESAS' TO SI1040S-ERRO-MENSAGEM. */
            _.Move("CODIGO DE OPERACAO NAO PREVISTO PARA DESPESAS", LBSI1040.SI1040S_PARAMETROS.SI1040S_ERRO_MENSAGEM);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R20_FIM*/
    }
}