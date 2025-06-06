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
using Sias.Outros.DB2.EF0101S;

namespace Code
{
    public class EF0101S
    {
        public bool IsCall { get; set; }

        public EF0101S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      * ANALISTA: HEIDER COELHO                                        *      */
        /*"      *                                                                *      */
        /*"      * PROGRAMADOR: CELSO FERRAZ                                      *      */
        /*"      *                                                                *      */
        /*"      * NOME DO PROGRAMA: EF0101S                                      *      */
        /*"      *                                                                *      */
        /*"      * MODULO:                                                        *      */
        /*"      *                                                                *      */
        /*"      * DESCRICAO:  ACESSAR V0CONTRATO_HABIT                           *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      * PROGRAMAS CHAMADORES: SI0078B                                  *      */
        /*"      *                                                                *      */
        /*"      * PROGRAMAS CHAMADOS:                                            *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * HISTORICO DE CORRECOES                                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * NO   VERSAO    DATA       PROGRAMADOR           ALTERACAO      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 1.    1.0    27/11/2003  CELSO FERRAZ           CODIFICACAO    *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *COPYBOOKS / DCLGENS USADOS                                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * NOME     DESCRICAO                                             *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"77 LS-V0HAB01-NUM-CONTRATO      PIC S9(09)  COMP.*/
        public IntBasis LS_V0HAB01_NUM_CONTRATO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77 LS-SINI-DATORR               PIC  X(10).*/
        public StringBasis LS_SINI_DATORR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77 LS-V0CONT-DATA-CONTRATO      PIC  X(10).*/
        public StringBasis LS_V0CONT_DATA_CONTRATO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77 LS-V0CONT-PRZ-VIGENCIA       PIC S9(04)  COMP.*/
        public IntBasis LS_V0CONT_PRZ_VIGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77 LS-SQLCODE                   PIC S9(09)  COMP-4.*/
        public IntBasis LS_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(IntBasis LS_V0HAB01_NUM_CONTRATO_P, StringBasis LS_SINI_DATORR_P, StringBasis LS_V0CONT_DATA_CONTRATO_P, IntBasis LS_V0CONT_PRZ_VIGENCIA_P, IntBasis LS_SQLCODE_P) //PROCEDURE DIVISION USING 
        /*LS_V0HAB01_NUM_CONTRATO
        LS_SINI_DATORR
        LS_V0CONT_DATA_CONTRATO
        LS_V0CONT_PRZ_VIGENCIA
        LS_SQLCODE*/
        {
            try
            {
                this.LS_V0HAB01_NUM_CONTRATO.Value = LS_V0HAB01_NUM_CONTRATO_P.Value;
                this.LS_SINI_DATORR.Value = LS_SINI_DATORR_P.Value;
                this.LS_V0CONT_DATA_CONTRATO.Value = LS_V0CONT_DATA_CONTRATO_P.Value;
                this.LS_V0CONT_PRZ_VIGENCIA.Value = LS_V0CONT_PRZ_VIGENCIA_P.Value;
                this.LS_SQLCODE.Value = LS_SQLCODE_P.Value;

                /*" -0- FLUXCONTROL_PERFORM B0000-PROCESSAMENTO */

                B0000_PROCESSAMENTO();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LS_V0HAB01_NUM_CONTRATO, LS_SINI_DATORR, LS_V0CONT_DATA_CONTRATO, LS_V0CONT_PRZ_VIGENCIA, LS_SQLCODE };
            return Result;
        }

        [StopWatch]
        /*" B0000-PROCESSAMENTO */
        private void B0000_PROCESSAMENTO(bool isPerform = false)
        {
            /*" -89- PERFORM A0000-INICIALIZACAO THRU A9999-EXIT. */

            A0000_INICIALIZACAO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: A9999_EXIT*/


            /*" -90- PERFORM D0000-PROCESSAMENTO-DB2 THRU D9999-EXIT. */

            D0000_PROCESSAMENTO_DB2(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: D9999_EXIT*/


            /*" -90- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B9999_EXIT*/

        [StopWatch]
        /*" A0000-INICIALIZACAO */
        private void A0000_INICIALIZACAO(bool isPerform = false)
        {
            /*" -103- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -104- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -105- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -109- INITIALIZE LS-V0CONT-DATA-CONTRATO, LS-V0CONT-PRZ-VIGENCIA, LS-SQLCODE. */
            _.Initialize(
                LS_V0CONT_DATA_CONTRATO
                , LS_V0CONT_PRZ_VIGENCIA
                , LS_SQLCODE
            );

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: A9999_EXIT*/

        [StopWatch]
        /*" D0000-PROCESSAMENTO-DB2 */
        private void D0000_PROCESSAMENTO_DB2(bool isPerform = false)
        {
            /*" -136- PERFORM D0000_PROCESSAMENTO_DB2_DB_SELECT_1 */

            D0000_PROCESSAMENTO_DB2_DB_SELECT_1();

            /*" -138- MOVE SQLCODE TO LS-SQLCODE. */
            _.Move(DB.SQLCODE, LS_SQLCODE);

        }

        [StopWatch]
        /*" D0000-PROCESSAMENTO-DB2-DB-SELECT-1 */
        public void D0000_PROCESSAMENTO_DB2_DB_SELECT_1()
        {
            /*" -136- EXEC SQL SELECT DATA_CONTRATO, PRZ_VIGENCIA INTO :LS-V0CONT-DATA-CONTRATO, :LS-V0CONT-PRZ-VIGENCIA FROM SEGUROS.V0CONTRATO_HABIT WHERE COD_PRODUTO = 6802 AND COD_CLIENTE = 528094 AND OPERACAO = 0 AND PONTO_VENDA = 0 AND NUM_CONTRATO = :LS-V0HAB01-NUM-CONTRATO AND DATA_SIT_INI <= :LS-SINI-DATORR AND VALUE(DATA_SIT_FIM,DATE( '9999-12-31' )) >= :LS-SINI-DATORR END-EXEC. */

            var d0000_PROCESSAMENTO_DB2_DB_SELECT_1_Query1 = new D0000_PROCESSAMENTO_DB2_DB_SELECT_1_Query1()
            {
                LS_V0HAB01_NUM_CONTRATO = LS_V0HAB01_NUM_CONTRATO.ToString(),
                LS_SINI_DATORR = LS_SINI_DATORR.ToString(),
            };

            var executed_1 = D0000_PROCESSAMENTO_DB2_DB_SELECT_1_Query1.Execute(d0000_PROCESSAMENTO_DB2_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LS_V0CONT_DATA_CONTRATO, LS_V0CONT_DATA_CONTRATO);
                _.Move(executed_1.LS_V0CONT_PRZ_VIGENCIA, LS_V0CONT_PRZ_VIGENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: D9999_EXIT*/
    }
}