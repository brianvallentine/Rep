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

namespace Code
{
    public class SI1007S
    {
        public bool IsCall { get; set; }

        public SI1007S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SISTEMA SINISTRO                   *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  SI1007S.                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  PRODEXTER                          *      */
        /*"      *   PROG/ANALISTA...........  PRODEXTER                          *      */
        /*"      *   DATA CODIFICACAO .......  ABRIL/2005                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  CALCULO DO VALOR DA RESERVA        *      */
        /*"      *                             (PENDENTE) DO JUDICIAL             *      */
        /*"      *                                                                *      */
        /*"      *   OBS.:                                                        *      */
        /*"      *   (1) OS BOOK'S UTILIZADOS ESTAO NA DES.SIA.SRCLIB.DATA        *      */
        /*"      *                                                                *      */
        /*"      *   (2) PARA ESTE CALCULO NAO SAO CONSIDERADOS OS MOVIMENTOS     *      */
        /*"      *       DE SEGURO, SUCUMBENCIA, SALVADOS E RESSARCIMENTOS        *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES


        public Copies.LBSI1000 LBSI1000 { get; set; } = new Copies.LBSI1000();
        public Copies.LBSI1001 LBSI1001 { get; set; } = new Copies.LBSI1001();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(LBSI1001_SI1001S_PARAMETROS LBSI1001_SI1001S_PARAMETROS_P) //PROCEDURE DIVISION USING 
        /*SI1001S_PARAMETROS*/
        {
            try
            {
                this.LBSI1001.SI1001S_PARAMETROS = LBSI1001_SI1001S_PARAMETROS_P;

                /*" -0- FLUXCONTROL_PERFORM R0000-00-INICIO-SECTION */

                R0000_00_INICIO_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LBSI1001.SI1001S_PARAMETROS };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-INICIO-SECTION */
        private void R0000_00_INICIO_SECTION()
        {
            /*" -74- MOVE '000' TO SI1001S-ERRO-PARAGRAFO */
            _.Move("000", LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_PARAGRAFO);

            /*" -76- PERFORM R0100-00-CONSISTE-ENTRADA */

            R0100_00_CONSISTE_ENTRADA_SECTION();

            /*" -80- PERFORM R0200-00-OBTEM-VALOR */

            R0200_00_OBTEM_VALOR_SECTION();

            /*" -80- GOBACK. */

            throw new GoBack();

        }

        [StopWatch]
        /*" R0100-00-CONSISTE-ENTRADA-SECTION */
        private void R0100_00_CONSISTE_ENTRADA_SECTION()
        {
            /*" -89- MOVE '010' TO SI1001S-ERRO-PARAGRAFO */
            _.Move("010", LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_PARAGRAFO);

            /*" -91- IF SI1001S-NUM-APOL-SINISTRO NOT NUMERIC */

            if (!LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO.IsNumeric())
            {

                /*" -93- MOVE 'SI1007S - NUMERO DO SINISTRO INVALIDO' TO SI1001S-ERRO-MENSAGEM */
                _.Move("SI1007S - NUMERO DO SINISTRO INVALIDO", LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM);

                /*" -97- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -102- IF SI1001S-NUM-APOL-SINISTRO EQUAL ZEROS AND SI1001S-COD-PRODUTO EQUAL ZEROS AND SI1001S-RAMO EQUAL ZEROS */

            if (LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO == 00 && LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_COD_PRODUTO == 00 && LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_RAMO == 00)
            {

                /*" -104- MOVE 'SI1007S - INFORME O SINISTRO, PRODUTO OU RAMO' TO SI1001S-ERRO-MENSAGEM */
                _.Move("SI1007S - INFORME O SINISTRO, PRODUTO OU RAMO", LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM);

                /*" -104- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_EXIT*/

        [StopWatch]
        /*" R0200-00-OBTEM-VALOR-SECTION */
        private void R0200_00_OBTEM_VALOR_SECTION()
        {
            /*" -121- MOVE '020' TO SI1001S-ERRO-PARAGRAFO */
            _.Move("020", LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_PARAGRAFO);

            /*" -123- INITIALIZE SI1000S-PARAMETROS */
            _.Initialize(
                LBSI1000.SI1000S_PARAMETROS
            );

            /*" -124- MOVE 'SI' TO SI1000S-IDE-SISTEMA */
            _.Move("SI", LBSI1000.SI1000S_PARAMETROS.SI1000S_ENTRADA.SI1000S_IDE_SISTEMA);

            /*" -125- MOVE 'SI' TO SI1000S-IDE-SISTEMA-OPER */
            _.Move("SI", LBSI1000.SI1000S_PARAMETROS.SI1000S_ENTRADA.SI1000S_IDE_SISTEMA_OPER);

            /*" -127- MOVE SI1001S-NUM-APOL-SINISTRO TO SI1000S-NUM-APOL-SINISTRO */
            _.Move(LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO, LBSI1000.SI1000S_PARAMETROS.SI1000S_ENTRADA.SI1000S_NUM_APOL_SINISTRO);

            /*" -129- MOVE SI1001S-COD-PRODUTO TO SI1000S-COD-PRODUTO */
            _.Move(LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_COD_PRODUTO, LBSI1000.SI1000S_PARAMETROS.SI1000S_ENTRADA.SI1000S_COD_PRODUTO);

            /*" -130- MOVE SI1001S-RAMO TO SI1000S-RAMO */
            _.Move(LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_RAMO, LBSI1000.SI1000S_PARAMETROS.SI1000S_ENTRADA.SI1000S_RAMO);

            /*" -132- MOVE SI1001S-DATA-INICIO TO SI1000S-DATA-INICIO */
            _.Move(LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_DATA_INICIO, LBSI1000.SI1000S_PARAMETROS.SI1000S_ENTRADA.SI1000S_DATA_INICIO);

            /*" -136- MOVE SI1001S-DATA-FIM TO SI1000S-DATA-FIM */
            _.Move(LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_DATA_FIM, LBSI1000.SI1000S_PARAMETROS.SI1000S_ENTRADA.SI1000S_DATA_FIM);

            /*" -137- MOVE 7 TO SI1000S-COD-FUNCAO */
            _.Move(7, LBSI1000.SI1000S_PARAMETROS.SI1000S_ENTRADA.SI1000S_COD_FUNCAO);

            /*" -139- PERFORM R0300-00-CHAMA-SI1000S */

            R0300_00_CHAMA_SI1000S_SECTION();

            /*" -140- MOVE SI1000S-VALOR-CALCULADO TO SI1001S-VALOR-CALCULADO. */
            _.Move(LBSI1000.SI1000S_PARAMETROS.SI1000S_SAIDA.SI1000S_VALOR_CALCULADO, LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_VALOR_CALCULADO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_EXIT*/

        [StopWatch]
        /*" R0300-00-CHAMA-SI1000S-SECTION */
        private void R0300_00_CHAMA_SI1000S_SECTION()
        {
            /*" -154- MOVE '030' TO SI1001S-ERRO-PARAGRAFO */
            _.Move("030", LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_PARAGRAFO);

            /*" -156- CALL 'SI1000S' USING SI1000S-PARAMETROS */
            _.Call("SI1000S", LBSI1000.SI1000S_PARAMETROS);

            /*" -158- IF SI1000S-ERRO-MENSAGEM NOT EQUAL SPACES */

            if (!LBSI1000.SI1000S_PARAMETROS.SI1000S_SAIDA.SI1000S_ERRO_MENSAGEM.IsEmpty())
            {

                /*" -160- MOVE SI1000S-ERRO-MENSAGEM TO SI1001S-ERRO-MENSAGEM */
                _.Move(LBSI1000.SI1000S_PARAMETROS.SI1000S_SAIDA.SI1000S_ERRO_MENSAGEM, LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM);

                /*" -162- MOVE SI1000S-ERRO-PARAGRAFO TO SI1001S-ERRO-PARAGRAFO */
                _.Move(LBSI1000.SI1000S_PARAMETROS.SI1000S_SAIDA.SI1000S_ERRO_PARAGRAFO, LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_PARAGRAFO);

                /*" -164- MOVE SI1000S-ERRO-SQLCODE TO SI1001S-ERRO-SQLCODE */
                _.Move(LBSI1000.SI1000S_PARAMETROS.SI1000S_SAIDA.SI1000S_ERRO_SQLCODE, LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_SQLCODE);

                /*" -164- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_EXIT*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -173- GOBACK. */

            throw new GoBack();

        }
    }
}