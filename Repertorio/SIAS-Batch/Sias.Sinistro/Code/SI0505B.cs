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
using Sias.Sinistro.DB2.SI0505B;

namespace Code
{
    public class SI0505B
    {
        public bool IsCall { get; set; }

        public SI0505B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *==============================================================*        */
        /*"      ****************************************************************        */
        /*"      *   SISTEMA ................  SINISTRO / RESSARCIMENTO         *        */
        /*"      *   PROGRAMA ...............  SI0505B                          *        */
        /*"      *   ANALISTA ...............  GEORGES DA MATA CLAESSEN         *        */
        /*"      *   PROGRAMADOR ............  GEORGES DA MATA CLAESSEN         *        */
        /*"      *   DATA CODIFICACAO .......  21/05/2009                       *        */
        /*"      *--------------------------------------------------------------*        */
        /*"      *   FUNCAO .................  SUBROTINA PARA VERIFICAR         *        */
        /*"      *          SE O NUMERO DA AGENCIA DO CONTRATO EH DIFERENTE     *        */
        /*"      *          DA UNIDADE OPERACIONAL (COD_UNO) COM BASE NO        *        */
        /*"      *          ARQUIVO INFORMADO PELA GEHAB.                       *        */
        /*"      *                             CASO SEJA DIFERENTE DEVERA       *        */
        /*"      *          RETORNAR A UNIDADE OPERACIONAL ONDE O CREDITO       *        */
        /*"      *          DO REPASSE OU INDENIZACAO SERA EFETUADO.            *        */
        /*"      *--------------------------------------------------------------*        */
        /*"      * ATENCAO |                                                    *        */
        /*"      * ATENCAO | ESTE PROGRAMA UTILIZA OS BOOKS LBSI505A E LBSI505B *        */
        /*"      * ATENCAO |                                                    *        */
        /*"      * ATENCAO | LBSI505A = LISTAGEM DE CONTRATOS E AG DESTINO      *        */
        /*"      * ATENCAO |            ATUALIZADO PELA CEF ATRAVES DE UM       *        */
        /*"      * ATENCAO |            ARQUIVO ENVIADO PELA GEHAB TODO FIM     *        */
        /*"      * ATENCAO |            DE MES A CAIXA SEGUROS. RECEBIDO POR    *        */
        /*"      * ATENCAO |            EMAIL PELA CAIXA SEGUROS.               *        */
        /*"      * ATENCAO |                                                    *        */
        /*"      * ATENCAO | LBSI505B = AREA DE TRANSFERENCIA PARA PROGRAMAS    *        */
        /*"      * ATENCAO |            QUE TENHAM INTERESSE EM COLHER O NUMERO *        */
        /*"      * ATENCAO |            DA AGENCIA CORRETA DE UM CONTRATO DE    *        */
        /*"      * ATENCAO |            MATCON                                  *        */
        /*"      ****************************************************************        */
        /*"      *--------------------------------------------------------------*        */
        /*"      *   M A N U T E N C A O - O R D E M  D E C R E S C E N T E     *        */
        /*"      *--------------------------------------------------------------*        */
        /*"V.02  * 01/02/2010 - GEFAB - CONTRASTE - GEORGES DA MATA CLAESSEN    *        */
        /*"      *            - CADMUS 36500 - PROCURAR V.02                    *        */
        /*"      *            - ATUALIZACAO BOOK LBSI505A                       *        */
        /*"      *--------------------------------------------------------------*        */
        /*"V.01  * 02/10/2009 - GEFAB - CONTRASTE - GEORGES DA MATA CLAESSEN    *        */
        /*"      *            - CADMUS 30640 - PROCURAR V.01                    *        */
        /*"      *            - ATUALIZACAO DA VERSAO QUE SE PERDEU             *        */
        /*"      *--------------------------------------------------------------*        */
        /*"      *==============================================================*        */
        #endregion


        #region VARIABLES

        /*"01  W-E-ENTRADA.*/
        public SI0505B_W_E_ENTRADA W_E_ENTRADA { get; set; } = new SI0505B_W_E_ENTRADA();
        public class SI0505B_W_E_ENTRADA : VarBasis
        {
            /*"    05  W-E-NUM-APOL-SINISTRO  PIC S9(13)V USAGE COMP-3.*/
            public DoubleBasis W_E_NUM_APOL_SINISTRO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
            /*"01  W-GERAL.*/
        }
        public SI0505B_W_GERAL W_GERAL { get; set; } = new SI0505B_W_GERAL();
        public class SI0505B_W_GERAL : VarBasis
        {
            /*"    03  W-IND                  PIC 9(7).*/
            public IntBasis W_IND { get; set; } = new IntBasis(new PIC("9", "7", "9(7)."));
            /*"    03  W-POS1                 PIC 9(7).*/
            public IntBasis W_POS1 { get; set; } = new IntBasis(new PIC("9", "7", "9(7)."));
            /*"    03  W-NUM-CNTRTO-A         PIC X(9).*/
            public StringBasis W_NUM_CNTRTO_A { get; set; } = new StringBasis(new PIC("X", "9", "X(9)."), @"");
            /*"    03  W-NUM-CNTRTO-N         PIC 9(9).*/
            public IntBasis W_NUM_CNTRTO_N { get; set; } = new IntBasis(new PIC("9", "9", "9(9)."));
            /*"01  W-CONTRATO.*/
        }
        public SI0505B_W_CONTRATO W_CONTRATO { get; set; } = new SI0505B_W_CONTRATO();
        public class SI0505B_W_CONTRATO : VarBasis
        {
            /*"    03  W-NUM-OPERACAO         PIC 9.*/
            public IntBasis W_NUM_OPERACAO { get; set; } = new IntBasis(new PIC("9", "1", "9."));
            /*"    03  W-NUM-PV               PIC 9999.*/
            public IntBasis W_NUM_PV { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
            /*"    03  W-NUM-CNTRTO           PIC 9999999.*/
            public IntBasis W_NUM_CNTRTO { get; set; } = new IntBasis(new PIC("9", "7", "9999999."));
        }


        public Copies.LBSI505A LBSI505A { get; set; } = new Copies.LBSI505A();
        public Copies.LBSI505B LBSI505B { get; set; } = new Copies.LBSI505B();
        public Dclgens.SINIHAB1 SINIHAB1 { get; set; } = new Dclgens.SINIHAB1();
        public Dclgens.EF072 EF072 { get; set; } = new Dclgens.EF072();
        public Dclgens.ENDHABIT ENDHABIT { get; set; } = new Dclgens.ENDHABIT();
        public Dclgens.EF083 EF083 { get; set; } = new Dclgens.EF083();
        public Dclgens.EF047 EF047 { get; set; } = new Dclgens.EF047();
        public Dclgens.EF075 EF075 { get; set; } = new Dclgens.EF075();
        public Dclgens.EF079 EF079 { get; set; } = new Dclgens.EF079();
        public Dclgens.GEPESEND GEPESEND { get; set; } = new Dclgens.GEPESEND();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(LBSI505B_SI0505B_PARAMETROS LBSI505B_SI0505B_PARAMETROS_P) //PROCEDURE DIVISION USING 
        /*SI0505B_PARAMETROS*/
        {
            try
            {
                this.LBSI505B.SI0505B_PARAMETROS = LBSI505B_SI0505B_PARAMETROS_P;

                /*" -121- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -122- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -123- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -126- PERFORM R0100-INI-VARIAVEL THRU R0100-EXIT. */

                R0100_INI_VARIAVEL(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_EXIT*/


                /*" -127- PERFORM R0200-REC-ENTRADA THRU R0200-EXIT. */

                R0200_REC_ENTRADA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_EXIT*/


                /*" -128- PERFORM R0300-VAL-ENTRADA THRU R0300-EXIT. */

                R0300_VAL_ENTRADA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_EXIT*/


                /*" -129- PERFORM R0400-SEL-HABIT01 THRU R0400-EXIT. */

                R0400_SEL_HABIT01(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_EXIT*/


                /*" -131- PERFORM R0500-OBT-UNO THRU R0500-EXIT. */

                R0500_OBT_UNO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_EXIT*/


                /*" -131- GOBACK. */

                throw new GoBack();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LBSI505B.SI0505B_PARAMETROS };
            return Result;
        }

        [StopWatch]
        /*" R0100-INI-VARIAVEL */
        private void R0100_INI_VARIAVEL(bool isPerform = false)
        {
            /*" -139- MOVE 1 TO W-IND. */
            _.Move(1, W_GERAL.W_IND);

            /*" -140- MOVE 0 TO W-NUM-OPERACAO. */
            _.Move(0, W_CONTRATO.W_NUM_OPERACAO);

            /*" -141- MOVE 0 TO W-NUM-PV. */
            _.Move(0, W_CONTRATO.W_NUM_PV);

            /*" -142- MOVE 0 TO W-NUM-CNTRTO. */
            _.Move(0, W_CONTRATO.W_NUM_CNTRTO);

            /*" -144- MOVE SPACE TO W-NUM-CNTRTO-A. */
            _.Move("", W_GERAL.W_NUM_CNTRTO_A);

            /*" -145- MOVE 0 TO SI0505B-RC. */
            _.Move(0, LBSI505B.SI0505B_PARAMETROS.SI0505B_SAIDA.SI0505B_RC);

            /*" -146- MOVE 0 TO SI0505B-NUM-SQL. */
            _.Move(0, LBSI505B.SI0505B_PARAMETROS.SI0505B_SAIDA.SI0505B_NUM_SQL);

            /*" -147- MOVE 0 TO SI0505B-SQLCODE. */
            _.Move(0, LBSI505B.SI0505B_PARAMETROS.SI0505B_SAIDA.SI0505B_SQLCODE);

            /*" -148- MOVE SPACE TO SI0505B-MENSAGEM. */
            _.Move("", LBSI505B.SI0505B_PARAMETROS.SI0505B_SAIDA.SI0505B_MENSAGEM);

            /*" -149- MOVE 0 TO SI0505B-AG-CONTRATO. */
            _.Move(0, LBSI505B.SI0505B_PARAMETROS.SI0505B_SAIDA.SI0505B_AG_CONTRATO);

            /*" -149- MOVE 0 TO SI0505B-UNO. */
            _.Move(0, LBSI505B.SI0505B_PARAMETROS.SI0505B_SAIDA.SI0505B_UNO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_EXIT*/

        [StopWatch]
        /*" R0200-REC-ENTRADA */
        private void R0200_REC_ENTRADA(bool isPerform = false)
        {
            /*" -162- INSPECT SI0505B-PARAMETROS REPLACING ALL LOW-VALUES BY SPACES. */

            /*" -162- MOVE SI0505B-NUM-APOL-SINISTRO TO W-E-NUM-APOL-SINISTRO. */
            _.Move(LBSI505B.SI0505B_PARAMETROS.SI0505B_ENTRADA.SI0505B_NUM_APOL_SINISTRO, W_E_ENTRADA.W_E_NUM_APOL_SINISTRO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_EXIT*/

        [StopWatch]
        /*" R0300-VAL-ENTRADA */
        private void R0300_VAL_ENTRADA(bool isPerform = false)
        {
            /*" -177- IF (SI0505B-NUM-APOL-SINISTRO IS NOT NUMERIC) */

            if ((!LBSI505B.SI0505B_PARAMETROS.SI0505B_ENTRADA.SI0505B_NUM_APOL_SINISTRO.IsNumeric()))
            {

                /*" -179- MOVE 'NUMERO DO SINISTRO DEVE SER NUMERICO' TO SI0505B-MENSAGEM */
                _.Move("NUMERO DO SINISTRO DEVE SER NUMERICO", LBSI505B.SI0505B_PARAMETROS.SI0505B_SAIDA.SI0505B_MENSAGEM);

                /*" -180- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO(); //GOTO
                return;

                /*" -182- END-IF. */
            }


            /*" -183- IF (SI0505B-NUM-APOL-SINISTRO = SPACE OR ZERO) */

            if ((LBSI505B.SI0505B_PARAMETROS.SI0505B_ENTRADA.SI0505B_NUM_APOL_SINISTRO.In(" ", "00")))
            {

                /*" -185- MOVE 'NUMERO DO SINISTRO DEVE SER PREENCHIDO' TO SI0505B-MENSAGEM */
                _.Move("NUMERO DO SINISTRO DEVE SER PREENCHIDO", LBSI505B.SI0505B_PARAMETROS.SI0505B_SAIDA.SI0505B_MENSAGEM);

                /*" -186- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO(); //GOTO
                return;

                /*" -186- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_EXIT*/

        [StopWatch]
        /*" R0400-SEL-HABIT01 */
        private void R0400_SEL_HABIT01(bool isPerform = false)
        {
            /*" -196- MOVE W-E-NUM-APOL-SINISTRO TO SINIHAB1-NUM-APOL-SINISTRO. */
            _.Move(W_E_ENTRADA.W_E_NUM_APOL_SINISTRO, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_NUM_APOL_SINISTRO);

            /*" -198- MOVE '001' TO SI0505B-NUM-SQL. */
            _.Move("001", LBSI505B.SI0505B_PARAMETROS.SI0505B_SAIDA.SI0505B_NUM_SQL);

            /*" -210- PERFORM R0400_SEL_HABIT01_DB_SELECT_1 */

            R0400_SEL_HABIT01_DB_SELECT_1();

            /*" -213- IF (SQLCODE NOT = 0) */

            if ((DB.SQLCODE != 0))
            {

                /*" -215- MOVE 'ERRO AO SELECIONAR SINISTRO_HABIT01' TO SI0505B-MENSAGEM */
                _.Move("ERRO AO SELECIONAR SINISTRO_HABIT01", LBSI505B.SI0505B_PARAMETROS.SI0505B_SAIDA.SI0505B_MENSAGEM);

                /*" -216- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO(); //GOTO
                return;

                /*" -218- END-IF. */
            }


            /*" -219- MOVE SINIHAB1-PONTO-VENDA TO SI0505B-AG-CONTRATO. */
            _.Move(SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_PONTO_VENDA, LBSI505B.SI0505B_PARAMETROS.SI0505B_SAIDA.SI0505B_AG_CONTRATO);

            /*" -221- MOVE SINIHAB1-PONTO-VENDA TO SI0505B-UNO. */
            _.Move(SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_PONTO_VENDA, LBSI505B.SI0505B_PARAMETROS.SI0505B_SAIDA.SI0505B_UNO);

            /*" -222- MOVE SINIHAB1-OPERACAO TO W-NUM-OPERACAO. */
            _.Move(SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_OPERACAO, W_CONTRATO.W_NUM_OPERACAO);

            /*" -223- MOVE SINIHAB1-PONTO-VENDA TO W-NUM-PV. */
            _.Move(SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_PONTO_VENDA, W_CONTRATO.W_NUM_PV);

            /*" -224- MOVE SINIHAB1-NUM-CONTRATO TO W-NUM-CNTRTO-N. */
            _.Move(SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_NUM_CONTRATO, W_GERAL.W_NUM_CNTRTO_N);

            /*" -225- MOVE W-NUM-CNTRTO-N TO W-NUM-CNTRTO-A. */
            _.Move(W_GERAL.W_NUM_CNTRTO_N, W_GERAL.W_NUM_CNTRTO_A);

            /*" -226- MOVE SPACE TO W-NUM-CNTRTO-A(9:1). */
            _.MoveAtPosition("", W_GERAL.W_NUM_CNTRTO_A, 9, 1);

            /*" -226- COMPUTE W-NUM-CNTRTO = FUNCTION NUMVAL(W-NUM-CNTRTO-A). */
            W_CONTRATO.W_NUM_CNTRTO.Value = _.NumVal(W_GERAL.W_NUM_CNTRTO_A);

        }

        [StopWatch]
        /*" R0400-SEL-HABIT01-DB-SELECT-1 */
        public void R0400_SEL_HABIT01_DB_SELECT_1()
        {
            /*" -210- EXEC SQL SELECT OPERACAO ,PONTO_VENDA ,NUM_CONTRATO INTO :SINIHAB1-OPERACAO ,:SINIHAB1-PONTO-VENDA ,:SINIHAB1-NUM-CONTRATO FROM SEGUROS.SINISTRO_HABIT01 WHERE NUM_APOL_SINISTRO = :SINIHAB1-NUM-APOL-SINISTRO WITH UR END-EXEC. */

            var r0400_SEL_HABIT01_DB_SELECT_1_Query1 = new R0400_SEL_HABIT01_DB_SELECT_1_Query1()
            {
                SINIHAB1_NUM_APOL_SINISTRO = SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R0400_SEL_HABIT01_DB_SELECT_1_Query1.Execute(r0400_SEL_HABIT01_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINIHAB1_OPERACAO, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_OPERACAO);
                _.Move(executed_1.SINIHAB1_PONTO_VENDA, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_PONTO_VENDA);
                _.Move(executed_1.SINIHAB1_NUM_CONTRATO, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_NUM_CONTRATO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_EXIT*/

        [StopWatch]
        /*" R0500-OBT-UNO */
        private void R0500_OBT_UNO(bool isPerform = false)
        {
            /*" -246- MOVE 0 TO W-IND. */
            _.Move(0, W_GERAL.W_IND);

            /*" -249- PERFORM VARYING W-IND FROM 1 BY 1 UNTIL (W-IND > W-NUM-OCORR-TAB1) */

            for (W_GERAL.W_IND.Value = 1; !((W_GERAL.W_IND > LBSI505A.W_NUM_OCORR_TAB1)); W_GERAL.W_IND.Value += 1)
            {

                /*" -250- IF (W-CONTRATO = W-TAB1-CONTRATO(W-IND)) */

                if ((W_CONTRATO == LBSI505A.FILLER_694.W_TABELA1[W_GERAL.W_IND].W_TAB1_CONTRATO))
                {

                    /*" -252- MOVE W-TAB1-NUM-UNO(W-IND) TO SI0505B-UNO */
                    _.Move(LBSI505A.FILLER_694.W_TABELA1[W_GERAL.W_IND].W_TAB1_NUM_UNO, LBSI505B.SI0505B_PARAMETROS.SI0505B_SAIDA.SI0505B_UNO);

                    /*" -253- GO TO R0500-EXIT */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_EXIT*/ //GOTO
                    return;

                    /*" -255- END-IF */
                }


                /*" -255- END-PERFORM. */
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_EXIT*/

        [StopWatch]
        /*" RXXXX-DEBUG */
        private void RXXXX_DEBUG(bool isPerform = false)
        {
            /*" -265- DISPLAY ' ' . */
            _.Display($" ");

            /*" -266- DISPLAY '==== W-GERAL =================================== ' . */
            _.Display($"==== W-GERAL =================================== ");

            /*" -267- DISPLAY 'W-TAB1-CONTRATO(W-IND). ' W-TAB1-CONTRATO(W-IND) . */
            _.Display($"W-TAB1-CONTRATO(W-IND). {LBSI505A.FILLER_694.W_TABELA1[W_GERAL.W_IND]}");

            /*" -268- DISPLAY 'W-TAB1-NUM-UNO (W-IND). ' W-TAB1-NUM-UNO(W-IND) . */
            _.Display($"W-TAB1-NUM-UNO (W-IND). {LBSI505A.FILLER_694.W_TABELA1[W_GERAL.W_IND]}");

            /*" -269- DISPLAY 'OPERACAO .............. ' SINIHAB1-OPERACAO . */
            _.Display($"OPERACAO .............. {SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_OPERACAO}");

            /*" -270- DISPLAY 'PONTO_VENDA............ ' SINIHAB1-PONTO-VENDA . */
            _.Display($"PONTO_VENDA............ {SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_PONTO_VENDA}");

            /*" -271- DISPLAY 'NR CONTRATO............ ' SINIHAB1-NUM-CONTRATO . */
            _.Display($"NR CONTRATO............ {SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_NUM_CONTRATO}");

            /*" -272- DISPLAY 'W-NUM-OPERACAO......... ' W-NUM-OPERACAO . */
            _.Display($"W-NUM-OPERACAO......... {W_CONTRATO.W_NUM_OPERACAO}");

            /*" -273- DISPLAY 'W-NUM-PV............... ' W-NUM-PV . */
            _.Display($"W-NUM-PV............... {W_CONTRATO.W_NUM_PV}");

            /*" -274- DISPLAY 'W-NUM-CNTRTO........... ' W-NUM-CNTRTO . */
            _.Display($"W-NUM-CNTRTO........... {W_CONTRATO.W_NUM_CNTRTO}");

            /*" -275- DISPLAY 'W-CONTRATO............. ' W-CONTRATO . */
            _.Display($"W-CONTRATO............. {W_CONTRATO}");

            /*" -276- DISPLAY 'W-E-NUM-APOL-SINISTRO.. ' W-E-NUM-APOL-SINISTRO . */
            _.Display($"W-E-NUM-APOL-SINISTRO.. {W_E_ENTRADA.W_E_NUM_APOL_SINISTRO}");

            /*" -277- DISPLAY '==== SI0505B =================================== ' . */
            _.Display($"==== SI0505B =================================== ");

            /*" -278- DISPLAY '  NUM-APOL-SINISTRO.... ' SI0505B-NUM-APOL-SINISTRO. */
            _.Display($"  NUM-APOL-SINISTRO.... {LBSI505B.SI0505B_PARAMETROS.SI0505B_ENTRADA.SI0505B_NUM_APOL_SINISTRO}");

            /*" -279- DISPLAY '  RC................... ' SI0505B-RC . */
            _.Display($"  RC................... {LBSI505B.SI0505B_PARAMETROS.SI0505B_SAIDA.SI0505B_RC}");

            /*" -280- DISPLAY '  NUM-SQL.............. ' SI0505B-NUM-SQL . */
            _.Display($"  NUM-SQL.............. {LBSI505B.SI0505B_PARAMETROS.SI0505B_SAIDA.SI0505B_NUM_SQL}");

            /*" -281- DISPLAY '  SQLCODE.............. ' SI0505B-SQLCODE . */
            _.Display($"  SQLCODE.............. {LBSI505B.SI0505B_PARAMETROS.SI0505B_SAIDA.SI0505B_SQLCODE}");

            /*" -282- DISPLAY '  MENSAGEM............. ' SI0505B-MENSAGEM . */
            _.Display($"  MENSAGEM............. {LBSI505B.SI0505B_PARAMETROS.SI0505B_SAIDA.SI0505B_MENSAGEM}");

            /*" -283- DISPLAY '  AG-CONTRATO.......... ' SI0505B-AG-CONTRATO . */
            _.Display($"  AG-CONTRATO.......... {LBSI505B.SI0505B_PARAMETROS.SI0505B_SAIDA.SI0505B_AG_CONTRATO}");

            /*" -284- DISPLAY '  UNO.................. ' SI0505B-UNO . */
            _.Display($"  UNO.................. {LBSI505B.SI0505B_PARAMETROS.SI0505B_SAIDA.SI0505B_UNO}");

            /*" -284- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: RXXXX_FIM*/

        [StopWatch]
        /*" R9999-ROT-ERRO */
        private void R9999_ROT_ERRO(bool isPerform = false)
        {
            /*" -293- MOVE SQLCODE TO SI0505B-SQLCODE. */
            _.Move(DB.SQLCODE, LBSI505B.SI0505B_PARAMETROS.SI0505B_SAIDA.SI0505B_SQLCODE);

            /*" -295- MOVE 99 TO SI0505B-RC. */
            _.Move(99, LBSI505B.SI0505B_PARAMETROS.SI0505B_SAIDA.SI0505B_RC);

            /*" -296- IF (SI0505B-MENSAGEM = SPACE) */

            if ((LBSI505B.SI0505B_PARAMETROS.SI0505B_SAIDA.SI0505B_MENSAGEM == " "))
            {

                /*" -298- MOVE 'ERRO AO ACESSAR O BANCO DE DADOS' TO SI0505B-MENSAGEM */
                _.Move("ERRO AO ACESSAR O BANCO DE DADOS", LBSI505B.SI0505B_PARAMETROS.SI0505B_SAIDA.SI0505B_MENSAGEM);

                /*" -302- END-IF. */
            }


            /*" -302- GOBACK. */

            throw new GoBack();

        }
    }
}