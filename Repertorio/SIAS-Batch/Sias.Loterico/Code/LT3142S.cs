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
using Sias.Loterico.DB2.LT3142S;

namespace Code
{
    public class LT3142S
    {
        public bool IsCall { get; set; }

        public LT3142S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-----------------------------------------------------------------      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA .............. LOTERICO                              *      */
        /*"      *   PROGRAMA.............. LT3142S (LT3133S)                     *      */
        /*"      *   ANALISTA ............. JOSE G OLIVEIRA                       *      */
        /*"      *   PROGRAMADOR .......... JOSE G OLIVEIRA                       *      */
        /*"      *   DATA CODIFICACAO ..... SET / 2006                            *      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO ............... PESQUISAR AS TAXAS NA TABELA DE       *      */
        /*"      *                          LOTTAXA01 A PARTIR DE 2007            *      */
        /*"      *                                                                *      */
        /*"      *                          INFORMAR: NUM-CLASSE                  *      */
        /*"      *                                    QTD-PARCELAS                *      */
        /*"      *                                    DTINIVIG                    *      */
        /*"      *                                    DISPLAY ( ' '/'S' )         *      */
        /*"      *                                                                *      */
        /*"      *     LOTTAX01-NUM-APOLICE         = 107100070673                *      */
        /*"      *     LOTTAX01-COD-LOT-FENAL       = 999                         *      */
        /*"      *     LOTTAX01-RAMO-COBERTURA      = NUM-CLASSE    ( 1 A 106 )   *      */
        /*"      *     LOTTAX01-COD-COBERTURA       = COD-COBERTURA ( 1 A 6   )   *      */
        /*"      *     LOTTAX01-MODALIDA-COBERTURA  = QTD PARCELAS  ( 1 A 12  )   *      */
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


        public Copies.LBLT3142 LBLT3142 { get; set; } = new Copies.LBLT3142();
        public Dclgens.LOTTAX01 LOTTAX01 { get; set; } = new Dclgens.LOTTAX01();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(LBLT3142_LT3142_AREA_PARAMETROS LBLT3142_LT3142_AREA_PARAMETROS_P) //PROCEDURE DIVISION USING 
        /*LT3142_AREA_PARAMETROS*/
        {
            try
            {
                this.LBLT3142.LT3142_AREA_PARAMETROS = LBLT3142_LT3142_AREA_PARAMETROS_P;

                /*" -99- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -102- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -105- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -110- PERFORM R0001-00-INICIALIZAR-VARIAVEIS */

                R0001_00_INICIALIZAR_VARIAVEIS_SECTION();

                /*" -112- PERFORM R0110-00-CRITICAR-PARAMETROS */

                R0110_00_CRITICAR_PARAMETROS_SECTION();

                /*" -114- PERFORM R1000-00-PROCESSAR */

                R1000_00_PROCESSAR_SECTION();

                /*" -114- PERFORM R9090-00-ROT-RETORNO . */

                R9090_00_ROT_RETORNO_SECTION();

                /*" -114- FLUXCONTROL_PERFORM R0001-00-INICIALIZAR-VARIAVEIS-SECTION */

                R0001_00_INICIALIZAR_VARIAVEIS_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LBLT3142.LT3142_AREA_PARAMETROS, CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R0001-00-INICIALIZAR-VARIAVEIS-SECTION */
        private void R0001_00_INICIALIZAR_VARIAVEIS_SECTION()
        {
            /*" -124- INITIALIZE LT3142-TAB-TAXAS ,LT3142-TAB-TAXAS-1PCL ,LT3142-COD-RETORNO ,LT3142-MENSAGEM . */
            _.Initialize(
                LBLT3142.LT3142_AREA_PARAMETROS.LT3142_TAB_TAXAS
                , LBLT3142.LT3142_AREA_PARAMETROS.LT3142_TAB_TAXAS_1PCL
                , LBLT3142.LT3142_AREA_PARAMETROS.LT3142_COD_RETORNO
                , LBLT3142.LT3142_AREA_PARAMETROS.LT3142_MENSAGEM
            );

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0001_99_SAIDA*/

        [StopWatch]
        /*" R0110-00-CRITICAR-PARAMETROS-SECTION */
        private void R0110_00_CRITICAR_PARAMETROS_SECTION()
        {
            /*" -134- MOVE '0110' TO WS-PARAGRAFO. */
            _.Move("0110", WS_PARAGRAFO);

            /*" -135- IF LT3142-DTINIVIG EQUAL SPACES */

            if (LBLT3142.LT3142_AREA_PARAMETROS.LT3142_DTINIVIG.IsEmpty())
            {

                /*" -136- MOVE 110 TO LT3142-COD-RETORNO */
                _.Move(110, LBLT3142.LT3142_AREA_PARAMETROS.LT3142_COD_RETORNO);

                /*" -137- MOVE 'DTINIVIG INVALIDO' TO LT3142-MENSAGEM */
                _.Move("DTINIVIG INVALIDO", LBLT3142.LT3142_AREA_PARAMETROS.LT3142_MENSAGEM);

                /*" -139- PERFORM R9090-00-ROT-RETORNO . */

                R9090_00_ROT_RETORNO_SECTION();
            }


            /*" -141- IF LT3142-NUM-CLASSE LESS THAN 1 OR LT3142-NUM-CLASSE GREATER THAN 13 */

            if (LBLT3142.LT3142_AREA_PARAMETROS.LT3142_NUM_CLASSE < 1 || LBLT3142.LT3142_AREA_PARAMETROS.LT3142_NUM_CLASSE > 13)
            {

                /*" -142- MOVE 110 TO LT3142-COD-RETORNO */
                _.Move(110, LBLT3142.LT3142_AREA_PARAMETROS.LT3142_COD_RETORNO);

                /*" -143- MOVE 'NUM CLASSE INVALIDO' TO LT3142-MENSAGEM */
                _.Move("NUM CLASSE INVALIDO", LBLT3142.LT3142_AREA_PARAMETROS.LT3142_MENSAGEM);

                /*" -145- PERFORM R9090-00-ROT-RETORNO . */

                R9090_00_ROT_RETORNO_SECTION();
            }


            /*" -147- IF LT3142-QTD-PARCELAS LESS THAN 1 OR LT3142-QTD-PARCELAS GREATER THAN 12 */

            if (LBLT3142.LT3142_AREA_PARAMETROS.LT3142_QTD_PARCELAS < 1 || LBLT3142.LT3142_AREA_PARAMETROS.LT3142_QTD_PARCELAS > 12)
            {

                /*" -148- MOVE 110 TO LT3142-COD-RETORNO */
                _.Move(110, LBLT3142.LT3142_AREA_PARAMETROS.LT3142_COD_RETORNO);

                /*" -149- MOVE 'QTD PARCELAS INVALIDO' TO LT3142-MENSAGEM */
                _.Move("QTD PARCELAS INVALIDO", LBLT3142.LT3142_AREA_PARAMETROS.LT3142_MENSAGEM);

                /*" -149- PERFORM R9090-00-ROT-RETORNO . */

                R9090_00_ROT_RETORNO_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0110_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-LER-TAXA-SECTION */
        private void R0300_00_LER_TAXA_SECTION()
        {
            /*" -163- MOVE '0300' TO WS-PARAGRAFO. */
            _.Move("0300", WS_PARAGRAFO);

            /*" -174- PERFORM R0300_00_LER_TAXA_DB_SELECT_1 */

            R0300_00_LER_TAXA_DB_SELECT_1();

            /*" -177- IF SQLCODE NOT EQUAL ZEROES AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -178- DISPLAY ' LT3142S-R0300-ERRO LOTTAXA01 ' */
                _.Display($" LT3142S-R0300-ERRO LOTTAXA01 ");

                /*" -179- DISPLAY 'NUM-APOLICE  ' LOTTAX01-NUM-APOLICE */
                _.Display($"NUM-APOLICE  {LOTTAX01.DCLLOTTAXA01.LOTTAX01_NUM_APOLICE}");

                /*" -180- DISPLAY 'COD-LOT-FENAL' LOTTAX01-COD-LOT-FENAL */
                _.Display($"COD-LOT-FENAL{LOTTAX01.DCLLOTTAXA01.LOTTAX01_COD_LOT_FENAL}");

                /*" -181- DISPLAY 'RAMO-COBERTUR' LOTTAX01-RAMO-COBERTURA */
                _.Display($"RAMO-COBERTUR{LOTTAX01.DCLLOTTAXA01.LOTTAX01_RAMO_COBERTURA}");

                /*" -182- DISPLAY 'COD-COBERTURA' LOTTAX01-COD-COBERTURA */
                _.Display($"COD-COBERTURA{LOTTAX01.DCLLOTTAXA01.LOTTAX01_COD_COBERTURA}");

                /*" -183- DISPLAY 'MODALIDA-COBE' LOTTAX01-MODALIDA-COBERTURA */
                _.Display($"MODALIDA-COBE{LOTTAX01.DCLLOTTAXA01.LOTTAX01_MODALIDA_COBERTURA}");

                /*" -184- DISPLAY 'DTINIVIG     ' LOTTAX01-DTINIVIG */
                _.Display($"DTINIVIG     {LOTTAX01.DCLLOTTAXA01.LOTTAX01_DTINIVIG}");

                /*" -185- DISPLAY 'SQLCODE      ' SQLCODE */
                _.Display($"SQLCODE      {DB.SQLCODE}");

                /*" -185- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0300-00-LER-TAXA-DB-SELECT-1 */
        public void R0300_00_LER_TAXA_DB_SELECT_1()
        {
            /*" -174- EXEC SQL SELECT TAXA_IS_FENAL INTO :LOTTAX01-TAXA-IS-FENAL FROM SEGUROS.LOTTAXA01 WHERE NUM_APOLICE = :LOTTAX01-NUM-APOLICE AND COD_LOT_FENAL = :LOTTAX01-COD-LOT-FENAL AND RAMO_COBERTURA = :LOTTAX01-RAMO-COBERTURA AND COD_COBERTURA = :LOTTAX01-COD-COBERTURA AND MODALIDA_COBERTURA = :LOTTAX01-MODALIDA-COBERTURA AND :LOTTAX01-DTINIVIG BETWEEN DTINIVIG AND DTTERVIG END-EXEC. */

            var r0300_00_LER_TAXA_DB_SELECT_1_Query1 = new R0300_00_LER_TAXA_DB_SELECT_1_Query1()
            {
                LOTTAX01_MODALIDA_COBERTURA = LOTTAX01.DCLLOTTAXA01.LOTTAX01_MODALIDA_COBERTURA.ToString(),
                LOTTAX01_RAMO_COBERTURA = LOTTAX01.DCLLOTTAXA01.LOTTAX01_RAMO_COBERTURA.ToString(),
                LOTTAX01_COD_LOT_FENAL = LOTTAX01.DCLLOTTAXA01.LOTTAX01_COD_LOT_FENAL.ToString(),
                LOTTAX01_COD_COBERTURA = LOTTAX01.DCLLOTTAXA01.LOTTAX01_COD_COBERTURA.ToString(),
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
        /*" R1000-00-PROCESSAR-SECTION */
        private void R1000_00_PROCESSAR_SECTION()
        {
            /*" -198- MOVE '1000' TO WS-PARAGRAFO. */
            _.Move("1000", WS_PARAGRAFO);

            /*" -199- MOVE 107100070673 TO LOTTAX01-NUM-APOLICE */
            _.Move(107100070673, LOTTAX01.DCLLOTTAXA01.LOTTAX01_NUM_APOLICE);

            /*" -200- MOVE 999 TO LOTTAX01-COD-LOT-FENAL */
            _.Move(999, LOTTAX01.DCLLOTTAXA01.LOTTAX01_COD_LOT_FENAL);

            /*" -206- MOVE LT3142-DTINIVIG TO LOTTAX01-DTINIVIG */
            _.Move(LBLT3142.LT3142_AREA_PARAMETROS.LT3142_DTINIVIG, LOTTAX01.DCLLOTTAXA01.LOTTAX01_DTINIVIG);

            /*" -207- PERFORM VARYING WS-IND FROM 1 BY 1 UNTIL WS-IND > 10 */

            for (WS_IND.Value = 1; !(WS_IND > 10); WS_IND.Value += 1)
            {

                /*" -208- MOVE LT3142-QTD-PARCELAS TO LOTTAX01-MODALIDA-COBERTURA */
                _.Move(LBLT3142.LT3142_AREA_PARAMETROS.LT3142_QTD_PARCELAS, LOTTAX01.DCLLOTTAXA01.LOTTAX01_MODALIDA_COBERTURA);

                /*" -210- COMPUTE LOTTAX01-RAMO-COBERTURA = WS-IND + 100 */
                LOTTAX01.DCLLOTTAXA01.LOTTAX01_RAMO_COBERTURA.Value = WS_IND + 100;

                /*" -212- IF LT3142-DTINIVIG >= '2008-01-01' AND LT3142-DTINIVIG <= '2008-12-31' */

                if (LBLT3142.LT3142_AREA_PARAMETROS.LT3142_DTINIVIG >= "2008-01-01" && LBLT3142.LT3142_AREA_PARAMETROS.LT3142_DTINIVIG <= "2008-12-31")
                {

                    /*" -213- IF LT3142-NUM-CLASSE NOT EQUAL 1 AND 5 */

                    if (!LBLT3142.LT3142_AREA_PARAMETROS.LT3142_NUM_CLASSE.In("1", "5"))
                    {

                        /*" -214- COMPUTE LOTTAX01-RAMO-COBERTURA = WS-IND + 200 */
                        LOTTAX01.DCLLOTTAXA01.LOTTAX01_RAMO_COBERTURA.Value = WS_IND + 200;

                        /*" -215- END-IF */
                    }


                    /*" -216- END-IF */
                }


                /*" -217- MOVE WS-IND TO LOTTAX01-COD-COBERTURA */
                _.Move(WS_IND, LOTTAX01.DCLLOTTAXA01.LOTTAX01_COD_COBERTURA);

                /*" -218- PERFORM R0300-00-LER-TAXA */

                R0300_00_LER_TAXA_SECTION();

                /*" -219- IF SQLCODE EQUAL TO ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -220- MOVE LOTTAX01-TAXA-IS-FENAL TO LT3142-TAXA(WS-IND) */
                    _.Move(LOTTAX01.DCLLOTTAXA01.LOTTAX01_TAXA_IS_FENAL, LBLT3142.LT3142_AREA_PARAMETROS.LT3142_TAB_TAXAS.LT3142_VALORES_TAXAS[WS_IND].LT3142_TAXA);

                    /*" -221- END-IF */
                }


                /*" -227- END-PERFORM */
            }

            /*" -228- PERFORM VARYING WS-IND FROM 2 BY 1 UNTIL WS-IND > 2 */

            for (WS_IND.Value = 2; !(WS_IND > 2); WS_IND.Value += 1)
            {

                /*" -229- MOVE LT3142-QTD-PARCELAS TO LOTTAX01-MODALIDA-COBERTURA */
                _.Move(LBLT3142.LT3142_AREA_PARAMETROS.LT3142_QTD_PARCELAS, LOTTAX01.DCLLOTTAXA01.LOTTAX01_MODALIDA_COBERTURA);

                /*" -230- MOVE LT3142-NUM-CLASSE TO LOTTAX01-RAMO-COBERTURA */
                _.Move(LBLT3142.LT3142_AREA_PARAMETROS.LT3142_NUM_CLASSE, LOTTAX01.DCLLOTTAXA01.LOTTAX01_RAMO_COBERTURA);

                /*" -231- MOVE WS-IND TO LOTTAX01-COD-COBERTURA */
                _.Move(WS_IND, LOTTAX01.DCLLOTTAXA01.LOTTAX01_COD_COBERTURA);

                /*" -232- PERFORM R0300-00-LER-TAXA */

                R0300_00_LER_TAXA_SECTION();

                /*" -233- IF SQLCODE EQUAL TO ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -234- MOVE LOTTAX01-TAXA-IS-FENAL TO LT3142-TAXA(WS-IND) */
                    _.Move(LOTTAX01.DCLLOTTAXA01.LOTTAX01_TAXA_IS_FENAL, LBLT3142.LT3142_AREA_PARAMETROS.LT3142_TAB_TAXAS.LT3142_VALORES_TAXAS[WS_IND].LT3142_TAXA);

                    /*" -235- END-IF */
                }


                /*" -241- END-PERFORM */
            }

            /*" -242- PERFORM VARYING WS-IND FROM 1 BY 1 UNTIL WS-IND > 10 */

            for (WS_IND.Value = 1; !(WS_IND > 10); WS_IND.Value += 1)
            {

                /*" -243- MOVE 1 TO LOTTAX01-MODALIDA-COBERTURA */
                _.Move(1, LOTTAX01.DCLLOTTAXA01.LOTTAX01_MODALIDA_COBERTURA);

                /*" -245- COMPUTE LOTTAX01-RAMO-COBERTURA = WS-IND + 100 */
                LOTTAX01.DCLLOTTAXA01.LOTTAX01_RAMO_COBERTURA.Value = WS_IND + 100;

                /*" -247- IF LT3142-DTINIVIG >= '2008-01-01' AND LT3142-DTINIVIG <= '2008-12-31' */

                if (LBLT3142.LT3142_AREA_PARAMETROS.LT3142_DTINIVIG >= "2008-01-01" && LBLT3142.LT3142_AREA_PARAMETROS.LT3142_DTINIVIG <= "2008-12-31")
                {

                    /*" -248- IF LT3142-NUM-CLASSE NOT EQUAL 1 AND 5 */

                    if (!LBLT3142.LT3142_AREA_PARAMETROS.LT3142_NUM_CLASSE.In("1", "5"))
                    {

                        /*" -249- COMPUTE LOTTAX01-RAMO-COBERTURA = WS-IND + 200 */
                        LOTTAX01.DCLLOTTAXA01.LOTTAX01_RAMO_COBERTURA.Value = WS_IND + 200;

                        /*" -250- END-IF */
                    }


                    /*" -251- END-IF */
                }


                /*" -252- MOVE WS-IND TO LOTTAX01-COD-COBERTURA */
                _.Move(WS_IND, LOTTAX01.DCLLOTTAXA01.LOTTAX01_COD_COBERTURA);

                /*" -253- PERFORM R0300-00-LER-TAXA */

                R0300_00_LER_TAXA_SECTION();

                /*" -254- IF SQLCODE EQUAL TO ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -255- MOVE LOTTAX01-TAXA-IS-FENAL TO LT3142-TAXA-1PCL(WS-IND) */
                    _.Move(LOTTAX01.DCLLOTTAXA01.LOTTAX01_TAXA_IS_FENAL, LBLT3142.LT3142_AREA_PARAMETROS.LT3142_TAB_TAXAS_1PCL.LT3142_VALORES_TAXAS_1PCL[WS_IND].LT3142_TAXA_1PCL);

                    /*" -256- END-IF */
                }


                /*" -261- END-PERFORM */
            }

            /*" -262- PERFORM VARYING WS-IND FROM 2 BY 1 UNTIL WS-IND > 2 */

            for (WS_IND.Value = 2; !(WS_IND > 2); WS_IND.Value += 1)
            {

                /*" -263- MOVE 1 TO LOTTAX01-MODALIDA-COBERTURA */
                _.Move(1, LOTTAX01.DCLLOTTAXA01.LOTTAX01_MODALIDA_COBERTURA);

                /*" -264- MOVE LT3142-NUM-CLASSE TO LOTTAX01-RAMO-COBERTURA */
                _.Move(LBLT3142.LT3142_AREA_PARAMETROS.LT3142_NUM_CLASSE, LOTTAX01.DCLLOTTAXA01.LOTTAX01_RAMO_COBERTURA);

                /*" -265- MOVE WS-IND TO LOTTAX01-COD-COBERTURA */
                _.Move(WS_IND, LOTTAX01.DCLLOTTAXA01.LOTTAX01_COD_COBERTURA);

                /*" -266- PERFORM R0300-00-LER-TAXA */

                R0300_00_LER_TAXA_SECTION();

                /*" -267- IF SQLCODE EQUAL TO ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -268- MOVE LOTTAX01-TAXA-IS-FENAL TO LT3142-TAXA-1PCL(WS-IND) */
                    _.Move(LOTTAX01.DCLLOTTAXA01.LOTTAX01_TAXA_IS_FENAL, LBLT3142.LT3142_AREA_PARAMETROS.LT3142_TAB_TAXAS_1PCL.LT3142_VALORES_TAXAS_1PCL[WS_IND].LT3142_TAXA_1PCL);

                    /*" -269- END-IF */
                }


                /*" -271- END-PERFORM */
            }

            /*" -277- IF LT3142-TAXA(01) EQUAL ZEROS AND LT3142-TAXA(02) EQUAL ZEROS AND LT3142-TAXA(03) EQUAL ZEROS AND LT3142-TAXA(04) EQUAL ZEROS AND LT3142-TAXA(05) EQUAL ZEROS AND LT3142-TAXA(06) EQUAL ZEROS */

            if (LBLT3142.LT3142_AREA_PARAMETROS.LT3142_TAB_TAXAS.LT3142_VALORES_TAXAS[01].LT3142_TAXA == 00 && LBLT3142.LT3142_AREA_PARAMETROS.LT3142_TAB_TAXAS.LT3142_VALORES_TAXAS[02].LT3142_TAXA == 00 && LBLT3142.LT3142_AREA_PARAMETROS.LT3142_TAB_TAXAS.LT3142_VALORES_TAXAS[03].LT3142_TAXA == 00 && LBLT3142.LT3142_AREA_PARAMETROS.LT3142_TAB_TAXAS.LT3142_VALORES_TAXAS[04].LT3142_TAXA == 00 && LBLT3142.LT3142_AREA_PARAMETROS.LT3142_TAB_TAXAS.LT3142_VALORES_TAXAS[05].LT3142_TAXA == 00 && LBLT3142.LT3142_AREA_PARAMETROS.LT3142_TAB_TAXAS.LT3142_VALORES_TAXAS[06].LT3142_TAXA == 00)
            {

                /*" -278- MOVE 1000 TO LT3142-COD-RETORNO */
                _.Move(1000, LBLT3142.LT3142_AREA_PARAMETROS.LT3142_COD_RETORNO);

                /*" -279- MOVE 'TAXAS NAO ENCONTRADAS ' TO LT3142-MENSAGEM */
                _.Move("TAXAS NAO ENCONTRADAS ", LBLT3142.LT3142_AREA_PARAMETROS.LT3142_MENSAGEM);

                /*" -282- PERFORM R9090-00-ROT-RETORNO. */

                R9090_00_ROT_RETORNO_SECTION();
            }


            /*" -282- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R9090-00-ROT-RETORNO-SECTION */
        private void R9090_00_ROT_RETORNO_SECTION()
        {
            /*" -292- IF LT3142-COD-RETORNO NOT EQUAL ZEROES */

            if (LBLT3142.LT3142_AREA_PARAMETROS.LT3142_COD_RETORNO != 00)
            {

                /*" -293- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_SQLCODE);

                /*" -297- DISPLAY 'LT3142S-R9090:' '/' WS-SQLCODE '/' LT3142-COD-RETORNO '/' LT3142-MENSAGEM */

                $"LT3142S-R9090:/{WS_SQLCODE}/{LBLT3142.LT3142_AREA_PARAMETROS.LT3142_COD_RETORNO}/{LBLT3142.LT3142_AREA_PARAMETROS.LT3142_MENSAGEM}"
                .Display();

                /*" -303- DISPLAY 'NCLA=' LT3142-NUM-CLASSE ' QTD=' LT3142-QTD-PARCELAS ' DTI=' LT3142-DTINIVIG ' DTT=' LT3142-DTTERVIG . */

                $"NCLA={LBLT3142.LT3142_AREA_PARAMETROS.LT3142_NUM_CLASSE} QTD={LBLT3142.LT3142_AREA_PARAMETROS.LT3142_QTD_PARCELAS} DTI={LBLT3142.LT3142_AREA_PARAMETROS.LT3142_DTINIVIG} DTT={LBLT3142.LT3142_AREA_PARAMETROS.LT3142_DTTERVIG}"
                .Display();
            }


            /*" -304- IF LT3142-DISPLAY EQUAL 'S' */

            if (LBLT3142.LT3142_AREA_PARAMETROS.LT3142_DISPLAY == "S")
            {

                /*" -305- DISPLAY '-------------------------------------------' */
                _.Display($"-------------------------------------------");

                /*" -309- DISPLAY 'NCLA=' LT3142-NUM-CLASSE ' QTD=' LT3142-QTD-PARCELAS ' DTI=' LT3142-DTINIVIG */

                $"NCLA={LBLT3142.LT3142_AREA_PARAMETROS.LT3142_NUM_CLASSE} QTD={LBLT3142.LT3142_AREA_PARAMETROS.LT3142_QTD_PARCELAS} DTI={LBLT3142.LT3142_AREA_PARAMETROS.LT3142_DTINIVIG}"
                .Display();

                /*" -312- DISPLAY '  TX01=' LT3142-TAXA(01) '  TX02=' LT3142-TAXA(02) '  TX03=' LT3142-TAXA(03) */

                $"  TX01={LBLT3142.LT3142_AREA_PARAMETROS.LT3142_TAB_TAXAS.LT3142_VALORES_TAXAS[1]}  TX02={LBLT3142.LT3142_AREA_PARAMETROS.LT3142_TAB_TAXAS.LT3142_VALORES_TAXAS[2]}  TX03={LBLT3142.LT3142_AREA_PARAMETROS.LT3142_TAB_TAXAS.LT3142_VALORES_TAXAS[3]}"
                .Display();

                /*" -315- DISPLAY '  TX04=' LT3142-TAXA(04) '  TX05=' LT3142-TAXA(05) '  TX06=' LT3142-TAXA(06) */

                $"  TX04={LBLT3142.LT3142_AREA_PARAMETROS.LT3142_TAB_TAXAS.LT3142_VALORES_TAXAS[4]}  TX05={LBLT3142.LT3142_AREA_PARAMETROS.LT3142_TAB_TAXAS.LT3142_VALORES_TAXAS[5]}  TX06={LBLT3142.LT3142_AREA_PARAMETROS.LT3142_TAB_TAXAS.LT3142_VALORES_TAXAS[6]}"
                .Display();

                /*" -318- DISPLAY '  TX07=' LT3142-TAXA(07) '  TX08=' LT3142-TAXA(08) '  TX09=' LT3142-TAXA(09) */

                $"  TX07={LBLT3142.LT3142_AREA_PARAMETROS.LT3142_TAB_TAXAS.LT3142_VALORES_TAXAS[7]}  TX08={LBLT3142.LT3142_AREA_PARAMETROS.LT3142_TAB_TAXAS.LT3142_VALORES_TAXAS[8]}  TX09={LBLT3142.LT3142_AREA_PARAMETROS.LT3142_TAB_TAXAS.LT3142_VALORES_TAXAS[9]}"
                .Display();

                /*" -319- DISPLAY '  ------  TAXAS A VISTA ----------------' */
                _.Display($"  ------  TAXAS A VISTA ----------------");

                /*" -322- DISPLAY 'TX1-01=' LT3142-TAXA-1PCL(01) 'TX1-02=' LT3142-TAXA-1PCL(02) 'TX1-03=' LT3142-TAXA-1PCL(03) */

                $"TX1-01={LBLT3142.LT3142_AREA_PARAMETROS.LT3142_TAB_TAXAS_1PCL.LT3142_VALORES_TAXAS_1PCL[1]}TX1-02={LBLT3142.LT3142_AREA_PARAMETROS.LT3142_TAB_TAXAS_1PCL.LT3142_VALORES_TAXAS_1PCL[2]}TX1-03={LBLT3142.LT3142_AREA_PARAMETROS.LT3142_TAB_TAXAS_1PCL.LT3142_VALORES_TAXAS_1PCL[3]}"
                .Display();

                /*" -325- DISPLAY 'TX1-04=' LT3142-TAXA-1PCL(04) 'TX1-05=' LT3142-TAXA-1PCL(05) 'TX1-06=' LT3142-TAXA-1PCL(06) */

                $"TX1-04={LBLT3142.LT3142_AREA_PARAMETROS.LT3142_TAB_TAXAS_1PCL.LT3142_VALORES_TAXAS_1PCL[4]}TX1-05={LBLT3142.LT3142_AREA_PARAMETROS.LT3142_TAB_TAXAS_1PCL.LT3142_VALORES_TAXAS_1PCL[5]}TX1-06={LBLT3142.LT3142_AREA_PARAMETROS.LT3142_TAB_TAXAS_1PCL.LT3142_VALORES_TAXAS_1PCL[6]}"
                .Display();

                /*" -329- DISPLAY 'TX1-07=' LT3142-TAXA-1PCL(07) 'TX1-08=' LT3142-TAXA-1PCL(08) 'TX1-09=' LT3142-TAXA-1PCL(09) */

                $"TX1-07={LBLT3142.LT3142_AREA_PARAMETROS.LT3142_TAB_TAXAS_1PCL.LT3142_VALORES_TAXAS_1PCL[7]}TX1-08={LBLT3142.LT3142_AREA_PARAMETROS.LT3142_TAB_TAXAS_1PCL.LT3142_VALORES_TAXAS_1PCL[8]}TX1-09={LBLT3142.LT3142_AREA_PARAMETROS.LT3142_TAB_TAXAS_1PCL.LT3142_VALORES_TAXAS_1PCL[9]}"
                .Display();

                /*" -330- DISPLAY 'COD=' LT3142-COD-RETORNO */
                _.Display($"COD={LBLT3142.LT3142_AREA_PARAMETROS.LT3142_COD_RETORNO}");

                /*" -333- DISPLAY '/' LT3142-MENSAGEM. */
                _.Display($"/{LBLT3142.LT3142_AREA_PARAMETROS.LT3142_MENSAGEM}");
            }


            /*" -333- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9090_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -344- MOVE SQLCODE TO WS-SQLCODE. */
            _.Move(DB.SQLCODE, WS_SQLCODE);

            /*" -349- DISPLAY 'LT3142S-R9999:' '/' WS-SQLCODE '/' LT3142-COD-RETORNO '/' LT3142-MENSAGEM. */

            $"LT3142S-R9999:/{WS_SQLCODE}/{LBLT3142.LT3142_AREA_PARAMETROS.LT3142_COD_RETORNO}/{LBLT3142.LT3142_AREA_PARAMETROS.LT3142_MENSAGEM}"
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