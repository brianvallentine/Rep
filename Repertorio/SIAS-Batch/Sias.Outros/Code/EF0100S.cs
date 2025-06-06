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
using Sias.Outros.DB2.EF0100S;

namespace Code
{
    public class EF0100S
    {
        public bool IsCall { get; set; }

        public EF0100S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      * ANALISTA: HEIDER COELHO                                        *      */
        /*"      *                                                                *      */
        /*"      * PROGRAMADOR: CARLOS ZEREDO                                     *      */
        /*"      *                                                                *      */
        /*"      * NOME DO PROGRAMA: EF0100S                                      *      */
        /*"      *                                                                *      */
        /*"      * MODULO:                                                        *      */
        /*"      *                                                                *      */
        /*"      * DESCRICAO:  CONSULTA V0ENDERECO_HABIT                          *      */
        /*"      *                                                                *      */
        /*"      * PROGRAMAS CHAMADORES: SI0077B                                  *      */
        /*"      *                                                                *      */
        /*"      * PROGRAMAS CHAMADOS:                                            *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * HISTORICO DE CORRECOES                                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * NO   VERSAO    DATA       PROGRAMADOR           ALTERACAO      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 1.    1.0    15/11/2003   CELSO FERRAZ          CODIFICACAO    *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *COPYBOOKS / DCLGENS USADOS                                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * NOME     DESCRICAO                                             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"77  LS-V0HABIT4-NUM-FIAP        PIC S9(09) COMP.*/
        public IntBasis LS_V0HABIT4_NUM_FIAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  LS-V0MEST-DATORR            PIC  X(10).*/
        public StringBasis LS_V0MEST_DATORR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77 LS-V0END-COD-CLIENTE         PIC S9(09) COMP.*/
        public IntBasis LS_V0END_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77 LS-V0END-ENDER-IMOVEL        PIC  X(30).*/
        public StringBasis LS_V0END_ENDER_IMOVEL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"77 LS-V0END-NUM-IMOVEL          PIC  X(05).*/
        public StringBasis LS_V0END_NUM_IMOVEL { get; set; } = new StringBasis(new PIC("X", "5", "X(05)."), @"");
        /*"77 LS-V0END-COMPL-IMOVEL        PIC  X(15).*/
        public StringBasis LS_V0END_COMPL_IMOVEL { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"77 LS-V0END-BAIRRO-IMOVEL       PIC  X(15).*/
        public StringBasis LS_V0END_BAIRRO_IMOVEL { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"77 LS-V0END-CIDADE-IMOVEL       PIC  X(22).*/
        public StringBasis LS_V0END_CIDADE_IMOVEL { get; set; } = new StringBasis(new PIC("X", "22", "X(22)."), @"");
        /*"77 LS-V0END-UF-IMOVEL           PIC  X(02).*/
        public StringBasis LS_V0END_UF_IMOVEL { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
        /*"77 LS-V0END-CEP-IMOVEL          PIC S9(09) COMP.*/
        public IntBasis LS_V0END_CEP_IMOVEL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77 LS-SQLCODE                   PIC S9(09) COMP-4.*/
        public IntBasis LS_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(IntBasis LS_V0HABIT4_NUM_FIAP_P, StringBasis LS_V0MEST_DATORR_P, IntBasis LS_V0END_COD_CLIENTE_P, StringBasis LS_V0END_ENDER_IMOVEL_P, StringBasis LS_V0END_NUM_IMOVEL_P, StringBasis LS_V0END_COMPL_IMOVEL_P, StringBasis LS_V0END_BAIRRO_IMOVEL_P, StringBasis LS_V0END_CIDADE_IMOVEL_P, StringBasis LS_V0END_UF_IMOVEL_P, IntBasis LS_V0END_CEP_IMOVEL_P, IntBasis LS_SQLCODE_P) //PROCEDURE DIVISION USING 
        /*LS_V0HABIT4_NUM_FIAP
        LS_V0MEST_DATORR
        LS_V0END_COD_CLIENTE
        LS_V0END_ENDER_IMOVEL
        LS_V0END_NUM_IMOVEL
        LS_V0END_COMPL_IMOVEL
        LS_V0END_BAIRRO_IMOVEL
        LS_V0END_CIDADE_IMOVEL
        LS_V0END_UF_IMOVEL
        LS_V0END_CEP_IMOVEL
        LS_SQLCODE*/
        {
            try
            {
                this.LS_V0HABIT4_NUM_FIAP.Value = LS_V0HABIT4_NUM_FIAP_P.Value;
                this.LS_V0MEST_DATORR.Value = LS_V0MEST_DATORR_P.Value;
                this.LS_V0END_COD_CLIENTE.Value = LS_V0END_COD_CLIENTE_P.Value;
                this.LS_V0END_ENDER_IMOVEL.Value = LS_V0END_ENDER_IMOVEL_P.Value;
                this.LS_V0END_NUM_IMOVEL.Value = LS_V0END_NUM_IMOVEL_P.Value;
                this.LS_V0END_COMPL_IMOVEL.Value = LS_V0END_COMPL_IMOVEL_P.Value;
                this.LS_V0END_BAIRRO_IMOVEL.Value = LS_V0END_BAIRRO_IMOVEL_P.Value;
                this.LS_V0END_CIDADE_IMOVEL.Value = LS_V0END_CIDADE_IMOVEL_P.Value;
                this.LS_V0END_UF_IMOVEL.Value = LS_V0END_UF_IMOVEL_P.Value;
                this.LS_V0END_CEP_IMOVEL.Value = LS_V0END_CEP_IMOVEL_P.Value;
                this.LS_SQLCODE.Value = LS_SQLCODE_P.Value;

                /*" -0- FLUXCONTROL_PERFORM B0000-PROCESSAMENTO */

                B0000_PROCESSAMENTO();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LS_V0HABIT4_NUM_FIAP, LS_V0MEST_DATORR, LS_V0END_COD_CLIENTE, LS_V0END_ENDER_IMOVEL, LS_V0END_NUM_IMOVEL, LS_V0END_COMPL_IMOVEL, LS_V0END_BAIRRO_IMOVEL, LS_V0END_CIDADE_IMOVEL, LS_V0END_UF_IMOVEL, LS_V0END_CEP_IMOVEL, LS_SQLCODE };
            return Result;
        }

        [StopWatch]
        /*" B0000-PROCESSAMENTO */
        private void B0000_PROCESSAMENTO(bool isPerform = false)
        {
            /*" -102- PERFORM A0000-INICIALIZACAO THRU A9999-EXIT. */

            A0000_INICIALIZACAO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: A9999_EXIT*/


            /*" -103- PERFORM D0000-PROCESSAMENTO-DB2 THRU D9999-EXIT. */

            D0000_PROCESSAMENTO_DB2(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: D9999_EXIT*/


            /*" -103- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B9999_EXIT*/

        [StopWatch]
        /*" A0000-INICIALIZACAO */
        private void A0000_INICIALIZACAO(bool isPerform = false)
        {
            /*" -116- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -117- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -118- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -128- INITIALIZE LS-V0END-COD-CLIENTE LS-V0END-ENDER-IMOVEL LS-V0END-NUM-IMOVEL LS-V0END-COMPL-IMOVEL LS-V0END-BAIRRO-IMOVEL LS-V0END-CIDADE-IMOVEL LS-V0END-UF-IMOVEL LS-V0END-CEP-IMOVEL LS-SQLCODE. */
            _.Initialize(
                LS_V0END_COD_CLIENTE
                , LS_V0END_ENDER_IMOVEL
                , LS_V0END_NUM_IMOVEL
                , LS_V0END_COMPL_IMOVEL
                , LS_V0END_BAIRRO_IMOVEL
                , LS_V0END_CIDADE_IMOVEL
                , LS_V0END_UF_IMOVEL
                , LS_V0END_CEP_IMOVEL
                , LS_SQLCODE
            );

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: A9999_EXIT*/

        [StopWatch]
        /*" D0000-PROCESSAMENTO-DB2 */
        private void D0000_PROCESSAMENTO_DB2(bool isPerform = false)
        {
            /*" -167- PERFORM D0000_PROCESSAMENTO_DB2_DB_SELECT_1 */

            D0000_PROCESSAMENTO_DB2_DB_SELECT_1();

            /*" -169- MOVE SQLCODE TO LS-SQLCODE. */
            _.Move(DB.SQLCODE, LS_SQLCODE);

        }

        [StopWatch]
        /*" D0000-PROCESSAMENTO-DB2-DB-SELECT-1 */
        public void D0000_PROCESSAMENTO_DB2_DB_SELECT_1()
        {
            /*" -167- EXEC SQL SELECT COD_CLIENTE, NOME_LOGRADOURO, VALUE(NUM_IMOVEL, '00000' ), VALUE(COMPL_ENDER, ' ' ), VALUE(BAIRRO, ' ' ), CIDADE, UF, CEP INTO :LS-V0END-COD-CLIENTE , :LS-V0END-ENDER-IMOVEL , :LS-V0END-NUM-IMOVEL , :LS-V0END-COMPL-IMOVEL , :LS-V0END-BAIRRO-IMOVEL, :LS-V0END-CIDADE-IMOVEL, :LS-V0END-UF-IMOVEL , :LS-V0END-CEP-IMOVEL FROM SEGUROS.V0ENDERECO_HABIT WHERE COD_PRODUTO = 6802 AND COD_CLIENTE = 528094 AND OPERACAO = 0 AND PONTO_VENDA = 0 AND NUM_CONTRATO = :LS-V0HABIT4-NUM-FIAP AND DATA_SIT_INI <= :LS-V0MEST-DATORR AND VALUE(DATA_SIT_FIM,DATE( '9999-12-31' )) >= :LS-V0MEST-DATORR END-EXEC. */

            var d0000_PROCESSAMENTO_DB2_DB_SELECT_1_Query1 = new D0000_PROCESSAMENTO_DB2_DB_SELECT_1_Query1()
            {
                LS_V0HABIT4_NUM_FIAP = LS_V0HABIT4_NUM_FIAP.ToString(),
                LS_V0MEST_DATORR = LS_V0MEST_DATORR.ToString(),
            };

            var executed_1 = D0000_PROCESSAMENTO_DB2_DB_SELECT_1_Query1.Execute(d0000_PROCESSAMENTO_DB2_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LS_V0END_COD_CLIENTE, LS_V0END_COD_CLIENTE);
                _.Move(executed_1.LS_V0END_ENDER_IMOVEL, LS_V0END_ENDER_IMOVEL);
                _.Move(executed_1.LS_V0END_NUM_IMOVEL, LS_V0END_NUM_IMOVEL);
                _.Move(executed_1.LS_V0END_COMPL_IMOVEL, LS_V0END_COMPL_IMOVEL);
                _.Move(executed_1.LS_V0END_BAIRRO_IMOVEL, LS_V0END_BAIRRO_IMOVEL);
                _.Move(executed_1.LS_V0END_CIDADE_IMOVEL, LS_V0END_CIDADE_IMOVEL);
                _.Move(executed_1.LS_V0END_UF_IMOVEL, LS_V0END_UF_IMOVEL);
                _.Move(executed_1.LS_V0END_CEP_IMOVEL, LS_V0END_CEP_IMOVEL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: D9999_EXIT*/
    }
}