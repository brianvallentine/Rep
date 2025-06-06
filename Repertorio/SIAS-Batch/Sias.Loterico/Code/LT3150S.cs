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
using Sias.Loterico.DB2.LT3150S;

namespace Code
{
    public class LT3150S
    {
        public bool IsCall { get; set; }

        public LT3150S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-----------------------------------------------------------------      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA .............. LOTERICO                              *      */
        /*"      *   PROGRAMA.............. LT3150S                               *      */
        /*"      *   ANALISTA ............. ALCIONE ARAUJO                        *      */
        /*"      *   PROGRAMADOR .......... ALCIONE ARAUJO                        *      */
        /*"      *   DATA CODIFICACAO ..... SET / 2008                            *      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO ............... PESQUISAR AS TAXAS NA TABELA DE       *      */
        /*"      *                          LOTTAXA01 A PARTIR DE 2009            *      */
        /*"      *                                                                *      */
        /*"      *                          INFORMAR: NUM-CLASSE                  *      */
        /*"      *                                    REGIAO                      *      */
        /*"      *                                    DTINIVIG                    *      */
        /*"      *                                    DISPLAY ( ' '/'S' )         *      */
        /*"      *                                                                *      */
        /*"      *     LOTTAX01-NUM-APOLICE         = 107100070673                *      */
        /*"      *     LOTTAX01-COD-LOT-FENAL       = 999 (TAXAS) 1000 (COEFICIEN)*      */
        /*"      *     LOTTAX01-RAMO-COBERTURA      = NUM-CLASSE    ( 1 A 5   )   *      */
        /*"      *     LOTTAX01-COD-COBERTURA       = COD-COBERTURA ( 1 A 16  )   *      */
        /*"      *     LOTTAX01-MODALIDA-COBERTURA  = COD-REGIAO    ( 1 A 4   )   *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *   CHAMADOR: SPBLT021                                           *      */
        /*"      *             LT3117S - GERA PROPOSTA                            *      */
        /*"      *             LT3123S - ATUALIZA DTINIVIG/QTD PCL                *      */
        /*"      *             LT3111S - GERA PROPOSTA                            *      */
        /*"      *             LT3146S - GERA PROPOSTA                            *      */
        /*"      *             LT3132S - PROPOSTA RENOVACAO                       *      */
        /*"      *             LT3133S - ENDOSSO                                  *      */
        /*"      *             SPBLT021- PROPOSTA/ENDOSSO                         *      */
        /*"      *             PROG.LT3084B                                       *      */
        /*"      *             PROG.LT3020B                                       *      */
        /*"      *             PROG.LT3025B                                       *      */
        /*"      *             PROG.LT3081B                                       *      */
        /*"      *             PROG.LT3080B                                       *      */
        /*"      *             PROG.EM0010B                                       *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  WS-PARAGRAFO                         PIC  X(05).*/
        public StringBasis WS_PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "5", "X(05)."), @"");
        /*"01  WS-SQLCODE                           PIC  ZZZZZZ9-.*/
        public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZZZ9-."));
        /*"01  WS-IND                               PIC  9(04).*/
        public IntBasis WS_IND { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
        /*"01  WS-VERSAO                            PIC  X(50) VALUE                 'LT3150S-VERSAO:19112008 21:00HS'.*/
        public StringBasis WS_VERSAO { get; set; } = new StringBasis(new PIC("X", "50", "X(50)"), @"LT3150S-VERSAO:19112008 21:00HS");


        public Copies.LBLT3150 LBLT3150 { get; set; } = new Copies.LBLT3150();
        public Dclgens.LOTTAX01 LOTTAX01 { get; set; } = new Dclgens.LOTTAX01();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(LBLT3150_LT3150_AREA_PARAMETROS LBLT3150_LT3150_AREA_PARAMETROS_P) //PROCEDURE DIVISION USING 
        /*LT3150_AREA_PARAMETROS*/
        {
            try
            {
                this.LBLT3150.LT3150_AREA_PARAMETROS = LBLT3150_LT3150_AREA_PARAMETROS_P;

                /*" -100- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -103- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -106- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -110- PERFORM R0001-00-INICIALIZAR-VARIAVEIS */

                R0001_00_INICIALIZAR_VARIAVEIS_SECTION();

                /*" -112- PERFORM R0110-00-CRITICAR-PARAMETROS */

                R0110_00_CRITICAR_PARAMETROS_SECTION();

                /*" -114- PERFORM R1000-00-PROCESSAR-TAXA */

                R1000_00_PROCESSAR_TAXA_SECTION();

                /*" -116- PERFORM R1100-00-PROCESSAR-COEF */

                R1100_00_PROCESSAR_COEF_SECTION();

                /*" -116- PERFORM R9090-00-ROT-RETORNO . */

                R9090_00_ROT_RETORNO_SECTION();

                /*" -116- FLUXCONTROL_PERFORM R0001-00-INICIALIZAR-VARIAVEIS-SECTION */

                R0001_00_INICIALIZAR_VARIAVEIS_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LBLT3150.LT3150_AREA_PARAMETROS, CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R0001-00-INICIALIZAR-VARIAVEIS-SECTION */
        private void R0001_00_INICIALIZAR_VARIAVEIS_SECTION()
        {
            /*" -123- INITIALIZE LT3150-COD-RETORNO LT3150-MENSAGEM . */
            _.Initialize(
                LBLT3150.LT3150_AREA_PARAMETROS.LT3150_COD_RETORNO
                , LBLT3150.LT3150_AREA_PARAMETROS.LT3150_MENSAGEM
            );

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0001_99_SAIDA*/

        [StopWatch]
        /*" R0110-00-CRITICAR-PARAMETROS-SECTION */
        private void R0110_00_CRITICAR_PARAMETROS_SECTION()
        {
            /*" -133- MOVE '0110' TO WS-PARAGRAFO. */
            _.Move("0110", WS_PARAGRAFO);

            /*" -134- IF LT3150-DTINIVIG EQUAL SPACES */

            if (LBLT3150.LT3150_AREA_PARAMETROS.LT3150_DTINIVIG.IsEmpty())
            {

                /*" -135- MOVE 110 TO LT3150-COD-RETORNO */
                _.Move(110, LBLT3150.LT3150_AREA_PARAMETROS.LT3150_COD_RETORNO);

                /*" -136- MOVE 'DTINIVIG INVALIDO' TO LT3150-MENSAGEM */
                _.Move("DTINIVIG INVALIDO", LBLT3150.LT3150_AREA_PARAMETROS.LT3150_MENSAGEM);

                /*" -138- PERFORM R9090-00-ROT-RETORNO . */

                R9090_00_ROT_RETORNO_SECTION();
            }


            /*" -140- IF LT3150-NUM-CLASSE LESS THAN 1 OR LT3150-NUM-CLASSE GREATER THAN 5 */

            if (LBLT3150.LT3150_AREA_PARAMETROS.LT3150_NUM_CLASSE < 1 || LBLT3150.LT3150_AREA_PARAMETROS.LT3150_NUM_CLASSE > 5)
            {

                /*" -141- MOVE 110 TO LT3150-COD-RETORNO */
                _.Move(110, LBLT3150.LT3150_AREA_PARAMETROS.LT3150_COD_RETORNO);

                /*" -142- MOVE 'NUM CLASSE INVALIDO' TO LT3150-MENSAGEM */
                _.Move("NUM CLASSE INVALIDO", LBLT3150.LT3150_AREA_PARAMETROS.LT3150_MENSAGEM);

                /*" -144- PERFORM R9090-00-ROT-RETORNO . */

                R9090_00_ROT_RETORNO_SECTION();
            }


            /*" -146- IF LT3150-COD-REGIAO LESS THAN 1 OR LT3150-COD-REGIAO GREATER THAN 4 */

            if (LBLT3150.LT3150_AREA_PARAMETROS.LT3150_COD_REGIAO < 1 || LBLT3150.LT3150_AREA_PARAMETROS.LT3150_COD_REGIAO > 4)
            {

                /*" -147- MOVE 110 TO LT3150-COD-RETORNO */
                _.Move(110, LBLT3150.LT3150_AREA_PARAMETROS.LT3150_COD_RETORNO);

                /*" -148- MOVE 'COD REGIAO INVALIDO' TO LT3150-MENSAGEM */
                _.Move("COD REGIAO INVALIDO", LBLT3150.LT3150_AREA_PARAMETROS.LT3150_MENSAGEM);

                /*" -148- PERFORM R9090-00-ROT-RETORNO . */

                R9090_00_ROT_RETORNO_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0110_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSAR-TAXA-SECTION */
        private void R1000_00_PROCESSAR_TAXA_SECTION()
        {
            /*" -158- MOVE '1000' TO WS-PARAGRAFO. */
            _.Move("1000", WS_PARAGRAFO);

            /*" -159- MOVE 107100070673 TO LOTTAX01-NUM-APOLICE */
            _.Move(107100070673, LOTTAX01.DCLLOTTAXA01.LOTTAX01_NUM_APOLICE);

            /*" -160- MOVE 999 TO LOTTAX01-COD-LOT-FENAL */
            _.Move(999, LOTTAX01.DCLLOTTAXA01.LOTTAX01_COD_LOT_FENAL);

            /*" -161- MOVE LT3150-DTINIVIG TO LOTTAX01-DTINIVIG */
            _.Move(LBLT3150.LT3150_AREA_PARAMETROS.LT3150_DTINIVIG, LOTTAX01.DCLLOTTAXA01.LOTTAX01_DTINIVIG);

            /*" -162- MOVE LT3150-DTTERVIG TO LOTTAX01-DTTERVIG */
            _.Move(LBLT3150.LT3150_AREA_PARAMETROS.LT3150_DTTERVIG, LOTTAX01.DCLLOTTAXA01.LOTTAX01_DTTERVIG);

            /*" -163- MOVE LT3150-NUM-CLASSE TO LOTTAX01-RAMO-COBERTURA */
            _.Move(LBLT3150.LT3150_AREA_PARAMETROS.LT3150_NUM_CLASSE, LOTTAX01.DCLLOTTAXA01.LOTTAX01_RAMO_COBERTURA);

            /*" -165- MOVE LT3150-COD-REGIAO TO LOTTAX01-MODALIDA-COBERTURA */
            _.Move(LBLT3150.LT3150_AREA_PARAMETROS.LT3150_COD_REGIAO, LOTTAX01.DCLLOTTAXA01.LOTTAX01_MODALIDA_COBERTURA);

            /*" -166- PERFORM VARYING WS-IND FROM 1 BY 1 UNTIL WS-IND GREATER 20 */

            for (WS_IND.Value = 1; !(WS_IND > 20); WS_IND.Value += 1)
            {

                /*" -167- MOVE WS-IND TO LOTTAX01-COD-COBERTURA */
                _.Move(WS_IND, LOTTAX01.DCLLOTTAXA01.LOTTAX01_COD_COBERTURA);

                /*" -168- PERFORM R0300-00-LER-TAXA */

                R0300_00_LER_TAXA_SECTION();

                /*" -169- MOVE LOTTAX01-TAXA-IS-FENAL TO LT3150-TAXA(WS-IND) */
                _.Move(LOTTAX01.DCLLOTTAXA01.LOTTAX01_TAXA_IS_FENAL, LBLT3150.LT3150_AREA_PARAMETROS.LT3150_TAB_TAXAS.LT3150_VALORES_TAXAS[WS_IND].LT3150_TAXA);

                /*" -170- END-PERFORM */
            }

            /*" -170- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-LER-TAXA-SECTION */
        private void R0300_00_LER_TAXA_SECTION()
        {
            /*" -179- MOVE '0300' TO WS-PARAGRAFO. */
            _.Move("0300", WS_PARAGRAFO);

            /*" -181- MOVE ZEROS TO LOTTAX01-TAXA-IS-FENAL */
            _.Move(0, LOTTAX01.DCLLOTTAXA01.LOTTAX01_TAXA_IS_FENAL);

            /*" -193- PERFORM R0300_00_LER_TAXA_DB_SELECT_1 */

            R0300_00_LER_TAXA_DB_SELECT_1();

            /*" -196- IF SQLCODE NOT EQUAL ZEROES AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -197- DISPLAY ' LT3150S-R0300-ERRO LOTTAXA01 ' */
                _.Display($" LT3150S-R0300-ERRO LOTTAXA01 ");

                /*" -198- DISPLAY 'NUM-APOLICE  ' LOTTAX01-NUM-APOLICE */
                _.Display($"NUM-APOLICE  {LOTTAX01.DCLLOTTAXA01.LOTTAX01_NUM_APOLICE}");

                /*" -199- DISPLAY 'COD-LOT-FENAL' LOTTAX01-COD-LOT-FENAL */
                _.Display($"COD-LOT-FENAL{LOTTAX01.DCLLOTTAXA01.LOTTAX01_COD_LOT_FENAL}");

                /*" -200- DISPLAY 'RAMO-COBERTUR' LOTTAX01-RAMO-COBERTURA */
                _.Display($"RAMO-COBERTUR{LOTTAX01.DCLLOTTAXA01.LOTTAX01_RAMO_COBERTURA}");

                /*" -201- DISPLAY 'COD-COBERTURA' LOTTAX01-COD-COBERTURA */
                _.Display($"COD-COBERTURA{LOTTAX01.DCLLOTTAXA01.LOTTAX01_COD_COBERTURA}");

                /*" -202- DISPLAY 'MODALIDA-COBE' LOTTAX01-MODALIDA-COBERTURA */
                _.Display($"MODALIDA-COBE{LOTTAX01.DCLLOTTAXA01.LOTTAX01_MODALIDA_COBERTURA}");

                /*" -203- DISPLAY 'DTINIVIG     ' LOTTAX01-DTINIVIG */
                _.Display($"DTINIVIG     {LOTTAX01.DCLLOTTAXA01.LOTTAX01_DTINIVIG}");

                /*" -204- DISPLAY 'SQLCODE      ' SQLCODE */
                _.Display($"SQLCODE      {DB.SQLCODE}");

                /*" -206- PERFORM R9999-00-ROT-ERRO . */

                R9999_00_ROT_ERRO_SECTION();
            }


            /*" -207- IF WS-IND EQUAL 1 AND SQLCODE EQUAL +100 */

            if (WS_IND == 1 && DB.SQLCODE == +100)
            {

                /*" -208- MOVE 1100 TO LT3150-COD-RETORNO */
                _.Move(1100, LBLT3150.LT3150_AREA_PARAMETROS.LT3150_COD_RETORNO);

                /*" -209- MOVE 'TAXAS NAO ENCONTRADAS ' TO LT3150-MENSAGEM */
                _.Move("TAXAS NAO ENCONTRADAS ", LBLT3150.LT3150_AREA_PARAMETROS.LT3150_MENSAGEM);

                /*" -209- PERFORM R9090-00-ROT-RETORNO . */

                R9090_00_ROT_RETORNO_SECTION();
            }


        }

        [StopWatch]
        /*" R0300-00-LER-TAXA-DB-SELECT-1 */
        public void R0300_00_LER_TAXA_DB_SELECT_1()
        {
            /*" -193- EXEC SQL SELECT TAXA_IS_FENAL INTO :LOTTAX01-TAXA-IS-FENAL FROM SEGUROS.V0LOTTAXA01 WHERE NUM_APOLICE = :LOTTAX01-NUM-APOLICE AND COD_COBERTURA = :LOTTAX01-COD-COBERTURA AND COD_LOT_FENAL = :LOTTAX01-COD-LOT-FENAL AND RAMO_COBERTURA = :LOTTAX01-RAMO-COBERTURA AND MODALIDA_COBERTURA = :LOTTAX01-MODALIDA-COBERTURA AND :LOTTAX01-DTINIVIG BETWEEN DTINIVIG AND DTTERVIG WITH UR END-EXEC. */

            var r0300_00_LER_TAXA_DB_SELECT_1_Query1 = new R0300_00_LER_TAXA_DB_SELECT_1_Query1()
            {
                LOTTAX01_MODALIDA_COBERTURA = LOTTAX01.DCLLOTTAXA01.LOTTAX01_MODALIDA_COBERTURA.ToString(),
                LOTTAX01_RAMO_COBERTURA = LOTTAX01.DCLLOTTAXA01.LOTTAX01_RAMO_COBERTURA.ToString(),
                LOTTAX01_COD_COBERTURA = LOTTAX01.DCLLOTTAXA01.LOTTAX01_COD_COBERTURA.ToString(),
                LOTTAX01_COD_LOT_FENAL = LOTTAX01.DCLLOTTAXA01.LOTTAX01_COD_LOT_FENAL.ToString(),
                LOTTAX01_NUM_APOLICE = LOTTAX01.DCLLOTTAXA01.LOTTAX01_NUM_APOLICE.ToString(),
                LOTTAX01_DTINIVIG = LOTTAX01.DCLLOTTAXA01.LOTTAX01_DTINIVIG.ToString(),
            };

            var executed_1 = R0300_00_LER_TAXA_DB_SELECT_1_Query1.Execute(r0300_00_LER_TAXA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LOTTAX01_TAXA_IS_FENAL, LOTTAX01.DCLLOTTAXA01.LOTTAX01_TAXA_IS_FENAL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-PROCESSAR-COEF-SECTION */
        private void R1100_00_PROCESSAR_COEF_SECTION()
        {
            /*" -219- MOVE '1100' TO WS-PARAGRAFO. */
            _.Move("1100", WS_PARAGRAFO);

            /*" -220- MOVE 107100070673 TO LOTTAX01-NUM-APOLICE */
            _.Move(107100070673, LOTTAX01.DCLLOTTAXA01.LOTTAX01_NUM_APOLICE);

            /*" -221- MOVE 1000 TO LOTTAX01-COD-LOT-FENAL */
            _.Move(1000, LOTTAX01.DCLLOTTAXA01.LOTTAX01_COD_LOT_FENAL);

            /*" -222- MOVE LT3150-DTINIVIG TO LOTTAX01-DTINIVIG */
            _.Move(LBLT3150.LT3150_AREA_PARAMETROS.LT3150_DTINIVIG, LOTTAX01.DCLLOTTAXA01.LOTTAX01_DTINIVIG);

            /*" -223- MOVE LT3150-DTTERVIG TO LOTTAX01-DTTERVIG */
            _.Move(LBLT3150.LT3150_AREA_PARAMETROS.LT3150_DTTERVIG, LOTTAX01.DCLLOTTAXA01.LOTTAX01_DTTERVIG);

            /*" -225- MOVE LT3150-NUM-CLASSE TO LOTTAX01-RAMO-COBERTURA */
            _.Move(LBLT3150.LT3150_AREA_PARAMETROS.LT3150_NUM_CLASSE, LOTTAX01.DCLLOTTAXA01.LOTTAX01_RAMO_COBERTURA);

            /*" -226- PERFORM VARYING WS-IND FROM 1 BY 1 UNTIL WS-IND GREATER 12 */

            for (WS_IND.Value = 1; !(WS_IND > 12); WS_IND.Value += 1)
            {

                /*" -227- MOVE WS-IND TO LOTTAX01-COD-COBERTURA */
                _.Move(WS_IND, LOTTAX01.DCLLOTTAXA01.LOTTAX01_COD_COBERTURA);

                /*" -228- PERFORM R0400-00-LER-COEF */

                R0400_00_LER_COEF_SECTION();

                /*" -230- MOVE LOTTAX01-TAXA-IS-FENAL TO LT3150-PCT-COEFICIENTE(WS-IND) */
                _.Move(LOTTAX01.DCLLOTTAXA01.LOTTAX01_TAXA_IS_FENAL, LBLT3150.LT3150_AREA_PARAMETROS.LT3150_TAB_COEFICIENTES.LT3150_PERCENT_COEFICIENTES[WS_IND].LT3150_PCT_COEFICIENTE);

                /*" -232- END-PERFORM */
            }

            /*" -232- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-LER-COEF-SECTION */
        private void R0400_00_LER_COEF_SECTION()
        {
            /*" -241- MOVE '0400' TO WS-PARAGRAFO. */
            _.Move("0400", WS_PARAGRAFO);

            /*" -243- MOVE ZEROS TO LOTTAX01-TAXA-IS-FENAL */
            _.Move(0, LOTTAX01.DCLLOTTAXA01.LOTTAX01_TAXA_IS_FENAL);

            /*" -254- PERFORM R0400_00_LER_COEF_DB_SELECT_1 */

            R0400_00_LER_COEF_DB_SELECT_1();

            /*" -257- IF SQLCODE NOT EQUAL ZEROES AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -258- DISPLAY ' LT3150S-R0400-ERRO LOTTAXA01 ' */
                _.Display($" LT3150S-R0400-ERRO LOTTAXA01 ");

                /*" -259- DISPLAY 'NUM-APOLICE  ' LOTTAX01-NUM-APOLICE */
                _.Display($"NUM-APOLICE  {LOTTAX01.DCLLOTTAXA01.LOTTAX01_NUM_APOLICE}");

                /*" -260- DISPLAY 'COD-LOT-FENAL' LOTTAX01-COD-LOT-FENAL */
                _.Display($"COD-LOT-FENAL{LOTTAX01.DCLLOTTAXA01.LOTTAX01_COD_LOT_FENAL}");

                /*" -261- DISPLAY 'RAMO-COBERTUR' LOTTAX01-RAMO-COBERTURA */
                _.Display($"RAMO-COBERTUR{LOTTAX01.DCLLOTTAXA01.LOTTAX01_RAMO_COBERTURA}");

                /*" -262- DISPLAY 'DTINIVIG     ' LOTTAX01-DTINIVIG */
                _.Display($"DTINIVIG     {LOTTAX01.DCLLOTTAXA01.LOTTAX01_DTINIVIG}");

                /*" -263- DISPLAY 'SQLCODE      ' SQLCODE */
                _.Display($"SQLCODE      {DB.SQLCODE}");

                /*" -265- PERFORM R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION();
            }


            /*" -266- IF WS-IND EQUAL 1 AND SQLCODE EQUAL +100 */

            if (WS_IND == 1 && DB.SQLCODE == +100)
            {

                /*" -267- MOVE 1100 TO LT3150-COD-RETORNO */
                _.Move(1100, LBLT3150.LT3150_AREA_PARAMETROS.LT3150_COD_RETORNO);

                /*" -268- MOVE 'COEFICIENTES NAO ENCONTRADOS ' TO LT3150-MENSAGEM */
                _.Move("COEFICIENTES NAO ENCONTRADOS ", LBLT3150.LT3150_AREA_PARAMETROS.LT3150_MENSAGEM);

                /*" -269- PERFORM R9090-00-ROT-RETORNO */

                R9090_00_ROT_RETORNO_SECTION();

                /*" -270- END-IF */
            }


            /*" -270- . */

        }

        [StopWatch]
        /*" R0400-00-LER-COEF-DB-SELECT-1 */
        public void R0400_00_LER_COEF_DB_SELECT_1()
        {
            /*" -254- EXEC SQL SELECT TAXA_IS_FENAL INTO :LOTTAX01-TAXA-IS-FENAL FROM SEGUROS.V0LOTTAXA01 WHERE NUM_APOLICE = :LOTTAX01-NUM-APOLICE AND COD_COBERTURA = :LOTTAX01-COD-COBERTURA AND COD_LOT_FENAL = :LOTTAX01-COD-LOT-FENAL AND RAMO_COBERTURA = :LOTTAX01-RAMO-COBERTURA AND :LOTTAX01-DTINIVIG BETWEEN DTINIVIG AND DTTERVIG WITH UR END-EXEC. */

            var r0400_00_LER_COEF_DB_SELECT_1_Query1 = new R0400_00_LER_COEF_DB_SELECT_1_Query1()
            {
                LOTTAX01_RAMO_COBERTURA = LOTTAX01.DCLLOTTAXA01.LOTTAX01_RAMO_COBERTURA.ToString(),
                LOTTAX01_COD_COBERTURA = LOTTAX01.DCLLOTTAXA01.LOTTAX01_COD_COBERTURA.ToString(),
                LOTTAX01_COD_LOT_FENAL = LOTTAX01.DCLLOTTAXA01.LOTTAX01_COD_LOT_FENAL.ToString(),
                LOTTAX01_NUM_APOLICE = LOTTAX01.DCLLOTTAXA01.LOTTAX01_NUM_APOLICE.ToString(),
                LOTTAX01_DTINIVIG = LOTTAX01.DCLLOTTAXA01.LOTTAX01_DTINIVIG.ToString(),
            };

            var executed_1 = R0400_00_LER_COEF_DB_SELECT_1_Query1.Execute(r0400_00_LER_COEF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LOTTAX01_TAXA_IS_FENAL, LOTTAX01.DCLLOTTAXA01.LOTTAX01_TAXA_IS_FENAL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R9090-00-ROT-RETORNO-SECTION */
        private void R9090_00_ROT_RETORNO_SECTION()
        {
            /*" -278- IF LT3150-COD-RETORNO NOT EQUAL ZEROES */

            if (LBLT3150.LT3150_AREA_PARAMETROS.LT3150_COD_RETORNO != 00)
            {

                /*" -279- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_SQLCODE);

                /*" -283- DISPLAY 'LT3150S-R9090:' '/' WS-SQLCODE '/' LT3150-COD-RETORNO '/' LT3150-MENSAGEM */

                $"LT3150S-R9090:/{WS_SQLCODE}/{LBLT3150.LT3150_AREA_PARAMETROS.LT3150_COD_RETORNO}/{LBLT3150.LT3150_AREA_PARAMETROS.LT3150_MENSAGEM}"
                .Display();

                /*" -287- DISPLAY 'NCLA=' LT3150-NUM-CLASSE ' REG=' LT3150-COD-REGIAO ' DTI=' LT3150-DTINIVIG ' DTT=' LT3150-DTTERVIG */

                $"NCLA={LBLT3150.LT3150_AREA_PARAMETROS.LT3150_NUM_CLASSE} REG={LBLT3150.LT3150_AREA_PARAMETROS.LT3150_COD_REGIAO} DTI={LBLT3150.LT3150_AREA_PARAMETROS.LT3150_DTINIVIG} DTT={LBLT3150.LT3150_AREA_PARAMETROS.LT3150_DTTERVIG}"
                .Display();

                /*" -289- END-IF */
            }


            /*" -290- IF LT3150-DISPLAY EQUAL 'S' */

            if (LBLT3150.LT3150_AREA_PARAMETROS.LT3150_DISPLAY == "S")
            {

                /*" -291- DISPLAY '-------------------------------------------' */
                _.Display($"-------------------------------------------");

                /*" -295- DISPLAY 'NCLA=' LT3150-NUM-CLASSE ' REG=' LT3150-COD-REGIAO ' DTI=' LT3150-DTINIVIG */

                $"NCLA={LBLT3150.LT3150_AREA_PARAMETROS.LT3150_NUM_CLASSE} REG={LBLT3150.LT3150_AREA_PARAMETROS.LT3150_COD_REGIAO} DTI={LBLT3150.LT3150_AREA_PARAMETROS.LT3150_DTINIVIG}"
                .Display();

                /*" -296- DISPLAY '--------- TAXAS ---------------------------' */
                _.Display($"--------- TAXAS ---------------------------");

                /*" -301- DISPLAY '  TX01=' LT3150-TAXA(01) '  TX02=' LT3150-TAXA(02) '  TX03=' LT3150-TAXA(03) '  TX04=' LT3150-TAXA(04) '  TX05=' LT3150-TAXA(05) */

                $"  TX01={LBLT3150.LT3150_AREA_PARAMETROS.LT3150_TAB_TAXAS.LT3150_VALORES_TAXAS[1]}  TX02={LBLT3150.LT3150_AREA_PARAMETROS.LT3150_TAB_TAXAS.LT3150_VALORES_TAXAS[2]}  TX03={LBLT3150.LT3150_AREA_PARAMETROS.LT3150_TAB_TAXAS.LT3150_VALORES_TAXAS[3]}  TX04={LBLT3150.LT3150_AREA_PARAMETROS.LT3150_TAB_TAXAS.LT3150_VALORES_TAXAS[4]}  TX05={LBLT3150.LT3150_AREA_PARAMETROS.LT3150_TAB_TAXAS.LT3150_VALORES_TAXAS[5]}"
                .Display();

                /*" -306- DISPLAY '  TX06=' LT3150-TAXA(06) '  TX07=' LT3150-TAXA(07) '  TX08=' LT3150-TAXA(08) '  TX09=' LT3150-TAXA(09) '  TX10=' LT3150-TAXA(10) */

                $"  TX06={LBLT3150.LT3150_AREA_PARAMETROS.LT3150_TAB_TAXAS.LT3150_VALORES_TAXAS[6]}  TX07={LBLT3150.LT3150_AREA_PARAMETROS.LT3150_TAB_TAXAS.LT3150_VALORES_TAXAS[7]}  TX08={LBLT3150.LT3150_AREA_PARAMETROS.LT3150_TAB_TAXAS.LT3150_VALORES_TAXAS[8]}  TX09={LBLT3150.LT3150_AREA_PARAMETROS.LT3150_TAB_TAXAS.LT3150_VALORES_TAXAS[9]}  TX10={LBLT3150.LT3150_AREA_PARAMETROS.LT3150_TAB_TAXAS.LT3150_VALORES_TAXAS[10]}"
                .Display();

                /*" -311- DISPLAY '  TX11=' LT3150-TAXA(11) '  TX12=' LT3150-TAXA(12) '  TX12=' LT3150-TAXA(13) '  TX12=' LT3150-TAXA(14) '  TX12=' LT3150-TAXA(15) */

                $"  TX11={LBLT3150.LT3150_AREA_PARAMETROS.LT3150_TAB_TAXAS.LT3150_VALORES_TAXAS[11]}  TX12={LBLT3150.LT3150_AREA_PARAMETROS.LT3150_TAB_TAXAS.LT3150_VALORES_TAXAS[12]}  TX12={LBLT3150.LT3150_AREA_PARAMETROS.LT3150_TAB_TAXAS.LT3150_VALORES_TAXAS[13]}  TX12={LBLT3150.LT3150_AREA_PARAMETROS.LT3150_TAB_TAXAS.LT3150_VALORES_TAXAS[14]}  TX12={LBLT3150.LT3150_AREA_PARAMETROS.LT3150_TAB_TAXAS.LT3150_VALORES_TAXAS[15]}"
                .Display();

                /*" -317- DISPLAY '  TX12=' LT3150-TAXA(16) '  TX12=' LT3150-TAXA(17) '  TX12=' LT3150-TAXA(18) '  TX12=' LT3150-TAXA(19) '  TX12=' LT3150-TAXA(20) */

                $"  TX12={LBLT3150.LT3150_AREA_PARAMETROS.LT3150_TAB_TAXAS.LT3150_VALORES_TAXAS[16]}  TX12={LBLT3150.LT3150_AREA_PARAMETROS.LT3150_TAB_TAXAS.LT3150_VALORES_TAXAS[17]}  TX12={LBLT3150.LT3150_AREA_PARAMETROS.LT3150_TAB_TAXAS.LT3150_VALORES_TAXAS[18]}  TX12={LBLT3150.LT3150_AREA_PARAMETROS.LT3150_TAB_TAXAS.LT3150_VALORES_TAXAS[19]}  TX12={LBLT3150.LT3150_AREA_PARAMETROS.LT3150_TAB_TAXAS.LT3150_VALORES_TAXAS[20]}"
                .Display();

                /*" -318- DISPLAY '--------- COEFICIENTES --------------------' */
                _.Display($"--------- COEFICIENTES --------------------");

                /*" -324- DISPLAY '  CF01=' LT3150-PCT-COEFICIENTE(1) '  CF02=' LT3150-PCT-COEFICIENTE(2) '  CF03=' LT3150-PCT-COEFICIENTE(3) '  CF04=' LT3150-PCT-COEFICIENTE(4) '  CF05=' LT3150-PCT-COEFICIENTE(5) '  CF06=' LT3150-PCT-COEFICIENTE(6) */

                $"  CF01={LBLT3150.LT3150_AREA_PARAMETROS.LT3150_TAB_COEFICIENTES.LT3150_PERCENT_COEFICIENTES[1]}  CF02={LBLT3150.LT3150_AREA_PARAMETROS.LT3150_TAB_COEFICIENTES.LT3150_PERCENT_COEFICIENTES[2]}  CF03={LBLT3150.LT3150_AREA_PARAMETROS.LT3150_TAB_COEFICIENTES.LT3150_PERCENT_COEFICIENTES[3]}  CF04={LBLT3150.LT3150_AREA_PARAMETROS.LT3150_TAB_COEFICIENTES.LT3150_PERCENT_COEFICIENTES[4]}  CF05={LBLT3150.LT3150_AREA_PARAMETROS.LT3150_TAB_COEFICIENTES.LT3150_PERCENT_COEFICIENTES[5]}  CF06={LBLT3150.LT3150_AREA_PARAMETROS.LT3150_TAB_COEFICIENTES.LT3150_PERCENT_COEFICIENTES[6]}"
                .Display();

                /*" -330- DISPLAY '  CF07=' LT3150-PCT-COEFICIENTE(7) '  CF08=' LT3150-PCT-COEFICIENTE(8) '  CF09=' LT3150-PCT-COEFICIENTE(9) '  CF10=' LT3150-PCT-COEFICIENTE(10) '  CF11=' LT3150-PCT-COEFICIENTE(11) '  CF12=' LT3150-PCT-COEFICIENTE(12) */

                $"  CF07={LBLT3150.LT3150_AREA_PARAMETROS.LT3150_TAB_COEFICIENTES.LT3150_PERCENT_COEFICIENTES[7]}  CF08={LBLT3150.LT3150_AREA_PARAMETROS.LT3150_TAB_COEFICIENTES.LT3150_PERCENT_COEFICIENTES[8]}  CF09={LBLT3150.LT3150_AREA_PARAMETROS.LT3150_TAB_COEFICIENTES.LT3150_PERCENT_COEFICIENTES[9]}  CF10={LBLT3150.LT3150_AREA_PARAMETROS.LT3150_TAB_COEFICIENTES.LT3150_PERCENT_COEFICIENTES[10]}  CF11={LBLT3150.LT3150_AREA_PARAMETROS.LT3150_TAB_COEFICIENTES.LT3150_PERCENT_COEFICIENTES[11]}  CF12={LBLT3150.LT3150_AREA_PARAMETROS.LT3150_TAB_COEFICIENTES.LT3150_PERCENT_COEFICIENTES[12]}"
                .Display();

                /*" -331- DISPLAY 'COD=' LT3150-COD-RETORNO */
                _.Display($"COD={LBLT3150.LT3150_AREA_PARAMETROS.LT3150_COD_RETORNO}");

                /*" -332- DISPLAY '/' LT3150-MENSAGEM */
                _.Display($"/{LBLT3150.LT3150_AREA_PARAMETROS.LT3150_MENSAGEM}");

                /*" -334- END-IF */
            }


            /*" -335- GOBACK */

            throw new GoBack();

            /*" -335- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9090_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -344- MOVE SQLCODE TO WS-SQLCODE. */
            _.Move(DB.SQLCODE, WS_SQLCODE);

            /*" -349- DISPLAY 'LT3150S-R9999:' '/' WS-SQLCODE '/' LT3150-COD-RETORNO '/' LT3150-MENSAGEM. */

            $"LT3150S-R9999:/{WS_SQLCODE}/{LBLT3150.LT3150_AREA_PARAMETROS.LT3150_COD_RETORNO}/{LBLT3150.LT3150_AREA_PARAMETROS.LT3150_MENSAGEM}"
            .Display();

            /*" -349- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -351- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -355- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -355- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}