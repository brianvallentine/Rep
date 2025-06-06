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
using Sias.Loterico.DB2.LT3250S;

namespace Code
{
    public class LT3250S
    {
        public bool IsCall { get; set; }

        public LT3250S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-----------------------------------------------------------------      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA .............. LOTERICO                              *      */
        /*"      *   PROGRAMA.............. LT3250S                               *      */
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
        /*"      *     NUM-APOLICE         = 107100070673                         *      */
        /*"      *     COD-LOT-FENAL       = 999  TAXAS                           *      */
        /*"      *     COD-LOT-FENAL       = 1000 COEFICIENTES DAS CLASSES        *      */
        /*"      *                                DE 1 A 60 (ATE 60 PARCELAS)     *      */
        /*"      *     COD-LOT-FENAL       = 2000 PERCENTUAIS DIARIOS DE PLURI-   *      */
        /*"      *                                ANUALIDADE  DE 1 A 1830 - 5 ANOS*      */
        /*"      *     RAMO-COBERTURA      = NUM-CLASSE    DE 1 A 5               *      */
        /*"      *     COD-COBERTURA       = COD-COBERTURA DE 1 A 20              *      */
        /*"      *     MODALIDA-COBERTURA  = COD-REGIAO    DE 1 A 4               *      */
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
        /*"      *             SPBLT033- PROPOSTA/ENDOSSO                         *      */
        /*"      *             PROG.LT3084B                                       *      */
        /*"      *             PROG.LT3020B                                       *      */
        /*"      *             PROG.LT3025B                                       *      */
        /*"      *             PROG.LT3081B                                       *      */
        /*"      *             PROG.LT3080B                                       *      */
        /*"      *             PROG.EM0010B                                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * V.02  - JAZZ 248622 - RENOVA��O LOTERICO/CCA 2021              *      */
        /*"      *         CALCULO ANUAL-TRIENAL-QUINQUENAL            OLIVEIRA   *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  WS-VERSAO                         PIC  X(40) VALUE                 'LT3250S-VERSAO V.01 25102020 2050HS'.*/
        public StringBasis WS_VERSAO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"LT3250S-VERSAO V.01 25102020 2050HS");
        /*"01  WS-PARAGRAFO                      PIC  X(05).*/
        public StringBasis WS_PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "5", "X(05)."), @"");
        /*"01  WS-SQLCODE                        PIC -ZZZZZZ9.*/
        public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("9", "7", "-ZZZZZZ9."));
        /*"01  WS-VALORS                         PIC -ZZZZ9,999.*/
        public DoubleBasis WS_VALORS { get; set; } = new DoubleBasis(new PIC("9", "5", "-ZZZZ9V999."), 3);
        /*"01  WS-TAXAS                          PIC -ZZ9,999999999.*/
        public DoubleBasis WS_TAXAS { get; set; } = new DoubleBasis(new PIC("9", "3", "-ZZ9V999999999."), 9);
        /*"01  WS-IND                            PIC  9(04).*/
        public IntBasis WS_IND { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
        /*"01  WS-QTD-DIAS-VIGENCIA              PIC  S9(04) COMP VALUE 0.*/
        public IntBasis WS_QTD_DIAS_VIGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  WS-VALOR                          PIC  S9(04) COMP VALUE 0.*/
        public IntBasis WS_VALOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  WS-QUOCIENTE                      PIC  S9(04) COMP VALUE 0.*/
        public IntBasis WS_QUOCIENTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  WS-RESTO                          PIC  S9(04) COMP VALUE 0.*/
        public IntBasis WS_RESTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  WS-DATA                           PIC  X(10).*/
        public StringBasis WS_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  WS-DISPLAY                        PIC  X(03) VALUE 'SIM'.*/
        public StringBasis WS_DISPLAY { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"SIM");
        /*"01  WS-AREA-WORK.*/
        public LT3250S_WS_AREA_WORK WS_AREA_WORK { get; set; } = new LT3250S_WS_AREA_WORK();
        public class LT3250S_WS_AREA_WORK : VarBasis
        {
            /*"  05 TAB-SAI-PLURI  OCCURS 10 TIMES.*/
            public ListBasis<LT3250S_TAB_SAI_PLURI> TAB_SAI_PLURI { get; set; } = new ListBasis<LT3250S_TAB_SAI_PLURI>(10);
            public class LT3250S_TAB_SAI_PLURI : VarBasis
            {
                /*"     10   TB-SAI-IND                 PIC ZZZ9-.*/
                public IntBasis TB_SAI_IND { get; set; } = new IntBasis(new PIC("9", "5", "ZZZ9-."));
                /*"     10   TB-SAI-DTINIVIG            PIC X(10).*/
                public StringBasis TB_SAI_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"     10   TB-SAI-DTTERVIG            PIC X(10).*/
                public StringBasis TB_SAI_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"     10   TB-SAI-QTD-DIAS            PIC 9(4).*/
                public IntBasis TB_SAI_QTD_DIAS { get; set; } = new IntBasis(new PIC("9", "4", "9(4)."));
                /*"     10   TB-SAI-PCT-PLURI           PIC ZZZZZZ9,999.*/
                public DoubleBasis TB_SAI_PCT_PLURI { get; set; } = new DoubleBasis(new PIC("9", "7", "ZZZZZZ9V999."), 3);
            }
        }


        public Copies.LBTB3201 LBTB3201 { get; set; } = new Copies.LBTB3201();
        public Copies.LBLT3250 LBLT3250 { get; set; } = new Copies.LBLT3250();
        public Dclgens.LOTTAX01 LOTTAX01 { get; set; } = new Dclgens.LOTTAX01();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(LBLT3250_LT3250_AREA_PARAMETROS LBLT3250_LT3250_AREA_PARAMETROS_P) //PROCEDURE DIVISION USING 
        /*LT3250_AREA_PARAMETROS*/
        {
            try
            {
                this.LBLT3250.LT3250_AREA_PARAMETROS = LBLT3250_LT3250_AREA_PARAMETROS_P;

                /*" -120- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -123- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -126- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -130- PERFORM R0001-00-INICIALIZAR-VARIAVEIS */

                R0001_00_INICIALIZAR_VARIAVEIS_SECTION();

                /*" -132- PERFORM R0110-00-CRITICAR-PARAMETROS */

                R0110_00_CRITICAR_PARAMETROS_SECTION();

                /*" -134- PERFORM R1000-00-PROCESSAR-TAXA */

                R1000_00_PROCESSAR_TAXA_SECTION();

                /*" -136- PERFORM R1100-00-PROCESSAR-COEF */

                R1100_00_PROCESSAR_COEF_SECTION();

                /*" -138- PERFORM R1200-00-PROCESSAR-PCT-PLURI */

                R1200_00_PROCESSAR_PCT_PLURI_SECTION();

                /*" -138- PERFORM R9090-00-ROT-RETORNO . */

                R9090_00_ROT_RETORNO_SECTION();

                /*" -138- FLUXCONTROL_PERFORM R0001-00-INICIALIZAR-VARIAVEIS-SECTION */

                R0001_00_INICIALIZAR_VARIAVEIS_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LBLT3250.LT3250_AREA_PARAMETROS, CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R0001-00-INICIALIZAR-VARIAVEIS-SECTION */
        private void R0001_00_INICIALIZAR_VARIAVEIS_SECTION()
        {
            /*" -147- INITIALIZE LT3250-COD-RETORNO LT3250-MENSAGEM . */
            _.Initialize(
                LBLT3250.LT3250_AREA_PARAMETROS.LT3250_COD_RETORNO
                , LBLT3250.LT3250_AREA_PARAMETROS.LT3250_MENSAGEM
            );

            /*" -148- PERFORM VARYING WS-IND FROM 1 BY 1 UNTIL WS-IND GREATER 60 */

            for (WS_IND.Value = 1; !(WS_IND > 60); WS_IND.Value += 1)
            {

                /*" -149- MOVE 0 TO LT3250-PCT-COEFICIENTE(WS-IND) */
                _.Move(0, LBLT3250.LT3250_AREA_PARAMETROS.LT3250_TAB_COEFICIENTES.LT3250_PERCENT_COEFICIENTES[WS_IND].LT3250_PCT_COEFICIENTE);

                /*" -150- IF WS-IND <= 20 */

                if (WS_IND <= 20)
                {

                    /*" -151- MOVE 0 TO LT3250-TAXA(WS-IND) */
                    _.Move(0, LBLT3250.LT3250_AREA_PARAMETROS.LT3250_TAB_TAXAS.LT3250_VALORES_TAXAS[WS_IND].LT3250_TAXA);

                    /*" -152- END-IF */
                }


                /*" -153- IF WS-IND <= 10 */

                if (WS_IND <= 10)
                {

                    /*" -154- MOVE 0 TO LT3250-PCT-PLURI(WS-IND) */
                    _.Move(0, LBLT3250.LT3250_AREA_PARAMETROS.LT3250_TAB_COEF_PLURI.LT3250_PERCENT_PLURI[WS_IND].LT3250_PCT_PLURI);

                    /*" -156- END-IF */
                }


                /*" -157- IF WS-IND <= 10 */

                if (WS_IND <= 10)
                {

                    /*" -158- MOVE 0 TO TB-SAI-IND(WS-IND) */
                    _.Move(0, WS_AREA_WORK.TAB_SAI_PLURI[WS_IND].TB_SAI_IND);

                    /*" -160- MOVE SPACES TO TB-SAI-DTINIVIG(WS-IND) TB-SAI-DTTERVIG(WS-IND) */
                    _.Move("", WS_AREA_WORK.TAB_SAI_PLURI[WS_IND].TB_SAI_DTINIVIG, WS_AREA_WORK.TAB_SAI_PLURI[WS_IND].TB_SAI_DTTERVIG);

                    /*" -162- MOVE 0 TO TB-SAI-QTD-DIAS(WS-IND) TB-SAI-PCT-PLURI(WS-IND) */
                    _.Move(0, WS_AREA_WORK.TAB_SAI_PLURI[WS_IND].TB_SAI_QTD_DIAS, WS_AREA_WORK.TAB_SAI_PLURI[WS_IND].TB_SAI_PCT_PLURI);

                    /*" -163- END-IF */
                }


                /*" -164- END-PERFORM */
            }

            /*" -164- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0001_99_SAIDA*/

        [StopWatch]
        /*" R0110-00-CRITICAR-PARAMETROS-SECTION */
        private void R0110_00_CRITICAR_PARAMETROS_SECTION()
        {
            /*" -173- MOVE '0110' TO WS-PARAGRAFO. */
            _.Move("0110", WS_PARAGRAFO);

            /*" -174- IF LT3250-DTINIVIG EQUAL SPACES */

            if (LBLT3250.LT3250_AREA_PARAMETROS.LT3250_DTINIVIG.IsEmpty())
            {

                /*" -175- MOVE 110 TO LT3250-COD-RETORNO */
                _.Move(110, LBLT3250.LT3250_AREA_PARAMETROS.LT3250_COD_RETORNO);

                /*" -176- MOVE 'DTINIVIG INVALIDO' TO LT3250-MENSAGEM */
                _.Move("DTINIVIG INVALIDO", LBLT3250.LT3250_AREA_PARAMETROS.LT3250_MENSAGEM);

                /*" -177- PERFORM R9090-00-ROT-RETORNO */

                R9090_00_ROT_RETORNO_SECTION();

                /*" -179- END-IF */
            }


            /*" -181- IF LT3250-NUM-CLASSE LESS THAN 1 OR LT3250-NUM-CLASSE GREATER THAN 5 */

            if (LBLT3250.LT3250_AREA_PARAMETROS.LT3250_NUM_CLASSE < 1 || LBLT3250.LT3250_AREA_PARAMETROS.LT3250_NUM_CLASSE > 5)
            {

                /*" -182- MOVE 110 TO LT3250-COD-RETORNO */
                _.Move(110, LBLT3250.LT3250_AREA_PARAMETROS.LT3250_COD_RETORNO);

                /*" -183- MOVE 'NUM CLASSE INVALIDO' TO LT3250-MENSAGEM */
                _.Move("NUM CLASSE INVALIDO", LBLT3250.LT3250_AREA_PARAMETROS.LT3250_MENSAGEM);

                /*" -184- PERFORM R9090-00-ROT-RETORNO */

                R9090_00_ROT_RETORNO_SECTION();

                /*" -186- END-IF */
            }


            /*" -188- IF LT3250-COD-REGIAO LESS THAN 1 OR LT3250-COD-REGIAO GREATER THAN 4 */

            if (LBLT3250.LT3250_AREA_PARAMETROS.LT3250_COD_REGIAO < 1 || LBLT3250.LT3250_AREA_PARAMETROS.LT3250_COD_REGIAO > 4)
            {

                /*" -189- MOVE 110 TO LT3250-COD-RETORNO */
                _.Move(110, LBLT3250.LT3250_AREA_PARAMETROS.LT3250_COD_RETORNO);

                /*" -190- MOVE 'COD REGIAO INVALIDO' TO LT3250-MENSAGEM */
                _.Move("COD REGIAO INVALIDO", LBLT3250.LT3250_AREA_PARAMETROS.LT3250_MENSAGEM);

                /*" -191- PERFORM R9090-00-ROT-RETORNO */

                R9090_00_ROT_RETORNO_SECTION();

                /*" -192- END-IF */
            }


            /*" -192- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0110_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSAR-TAXA-SECTION */
        private void R1000_00_PROCESSAR_TAXA_SECTION()
        {
            /*" -201- MOVE '1000' TO WS-PARAGRAFO. */
            _.Move("1000", WS_PARAGRAFO);

            /*" -202- MOVE 107100070673 TO LOTTAX01-NUM-APOLICE */
            _.Move(107100070673, LOTTAX01.DCLLOTTAXA01.LOTTAX01_NUM_APOLICE);

            /*" -203- MOVE 999 TO LOTTAX01-COD-LOT-FENAL */
            _.Move(999, LOTTAX01.DCLLOTTAXA01.LOTTAX01_COD_LOT_FENAL);

            /*" -204- MOVE LT3250-DTINIVIG TO LOTTAX01-DTINIVIG */
            _.Move(LBLT3250.LT3250_AREA_PARAMETROS.LT3250_DTINIVIG, LOTTAX01.DCLLOTTAXA01.LOTTAX01_DTINIVIG);

            /*" -205- MOVE LT3250-DTTERVIG TO LOTTAX01-DTTERVIG */
            _.Move(LBLT3250.LT3250_AREA_PARAMETROS.LT3250_DTTERVIG, LOTTAX01.DCLLOTTAXA01.LOTTAX01_DTTERVIG);

            /*" -206- MOVE LT3250-NUM-CLASSE TO LOTTAX01-RAMO-COBERTURA */
            _.Move(LBLT3250.LT3250_AREA_PARAMETROS.LT3250_NUM_CLASSE, LOTTAX01.DCLLOTTAXA01.LOTTAX01_RAMO_COBERTURA);

            /*" -208- MOVE LT3250-COD-REGIAO TO LOTTAX01-MODALIDA-COBERTURA */
            _.Move(LBLT3250.LT3250_AREA_PARAMETROS.LT3250_COD_REGIAO, LOTTAX01.DCLLOTTAXA01.LOTTAX01_MODALIDA_COBERTURA);

            /*" -209- PERFORM VARYING WS-IND FROM 1 BY 1 UNTIL WS-IND GREATER 19 */

            for (WS_IND.Value = 1; !(WS_IND > 19); WS_IND.Value += 1)
            {

                /*" -210- MOVE WS-IND TO LOTTAX01-COD-COBERTURA */
                _.Move(WS_IND, LOTTAX01.DCLLOTTAXA01.LOTTAX01_COD_COBERTURA);

                /*" -211- PERFORM R1010-00-LER-TAXA */

                R1010_00_LER_TAXA_SECTION();

                /*" -212- MOVE LOTTAX01-TAXA-IS-FENAL TO LT3250-TAXA(WS-IND) */
                _.Move(LOTTAX01.DCLLOTTAXA01.LOTTAX01_TAXA_IS_FENAL, LBLT3250.LT3250_AREA_PARAMETROS.LT3250_TAB_TAXAS.LT3250_VALORES_TAXAS[WS_IND].LT3250_TAXA);

                /*" -213- END-PERFORM */
            }

            /*" -213- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1010-00-LER-TAXA-SECTION */
        private void R1010_00_LER_TAXA_SECTION()
        {
            /*" -222- MOVE '1010' TO WS-PARAGRAFO. */
            _.Move("1010", WS_PARAGRAFO);

            /*" -224- MOVE ZEROS TO LOTTAX01-TAXA-IS-FENAL */
            _.Move(0, LOTTAX01.DCLLOTTAXA01.LOTTAX01_TAXA_IS_FENAL);

            /*" -236- PERFORM R1010_00_LER_TAXA_DB_SELECT_1 */

            R1010_00_LER_TAXA_DB_SELECT_1();

            /*" -239- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -240- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_SQLCODE);

                /*" -241- DISPLAY ' LT3250S-R1010-ERRO LOTTAXA01 ' */
                _.Display($" LT3250S-R1010-ERRO LOTTAXA01 ");

                /*" -242- DISPLAY 'NUM-APOLICE  ' LOTTAX01-NUM-APOLICE */
                _.Display($"NUM-APOLICE  {LOTTAX01.DCLLOTTAXA01.LOTTAX01_NUM_APOLICE}");

                /*" -243- DISPLAY 'COD-LOT-FENAL' LOTTAX01-COD-LOT-FENAL */
                _.Display($"COD-LOT-FENAL{LOTTAX01.DCLLOTTAXA01.LOTTAX01_COD_LOT_FENAL}");

                /*" -244- DISPLAY 'RAMO-COBERTUR' LOTTAX01-RAMO-COBERTURA */
                _.Display($"RAMO-COBERTUR{LOTTAX01.DCLLOTTAXA01.LOTTAX01_RAMO_COBERTURA}");

                /*" -245- DISPLAY 'COD-COBERTURA' LOTTAX01-COD-COBERTURA */
                _.Display($"COD-COBERTURA{LOTTAX01.DCLLOTTAXA01.LOTTAX01_COD_COBERTURA}");

                /*" -246- DISPLAY 'MODALIDA-COBE' LOTTAX01-MODALIDA-COBERTURA */
                _.Display($"MODALIDA-COBE{LOTTAX01.DCLLOTTAXA01.LOTTAX01_MODALIDA_COBERTURA}");

                /*" -247- DISPLAY 'DTINIVIG     ' LOTTAX01-DTINIVIG */
                _.Display($"DTINIVIG     {LOTTAX01.DCLLOTTAXA01.LOTTAX01_DTINIVIG}");

                /*" -248- DISPLAY 'SQLCODE      ' WS-SQLCODE */
                _.Display($"SQLCODE      {WS_SQLCODE}");

                /*" -249- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -250- END-IF */
            }


            /*" -250- . */

        }

        [StopWatch]
        /*" R1010-00-LER-TAXA-DB-SELECT-1 */
        public void R1010_00_LER_TAXA_DB_SELECT_1()
        {
            /*" -236- EXEC SQL SELECT TAXA_IS_FENAL INTO :LOTTAX01-TAXA-IS-FENAL FROM SEGUROS.V0LOTTAXA01 WHERE NUM_APOLICE = :LOTTAX01-NUM-APOLICE AND COD_COBERTURA = :LOTTAX01-COD-COBERTURA AND COD_LOT_FENAL = :LOTTAX01-COD-LOT-FENAL AND RAMO_COBERTURA = :LOTTAX01-RAMO-COBERTURA AND MODALIDA_COBERTURA = :LOTTAX01-MODALIDA-COBERTURA AND :LOTTAX01-DTINIVIG BETWEEN DTINIVIG AND DTTERVIG WITH UR END-EXEC. */

            var r1010_00_LER_TAXA_DB_SELECT_1_Query1 = new R1010_00_LER_TAXA_DB_SELECT_1_Query1()
            {
                LOTTAX01_MODALIDA_COBERTURA = LOTTAX01.DCLLOTTAXA01.LOTTAX01_MODALIDA_COBERTURA.ToString(),
                LOTTAX01_RAMO_COBERTURA = LOTTAX01.DCLLOTTAXA01.LOTTAX01_RAMO_COBERTURA.ToString(),
                LOTTAX01_COD_COBERTURA = LOTTAX01.DCLLOTTAXA01.LOTTAX01_COD_COBERTURA.ToString(),
                LOTTAX01_COD_LOT_FENAL = LOTTAX01.DCLLOTTAXA01.LOTTAX01_COD_LOT_FENAL.ToString(),
                LOTTAX01_NUM_APOLICE = LOTTAX01.DCLLOTTAXA01.LOTTAX01_NUM_APOLICE.ToString(),
                LOTTAX01_DTINIVIG = LOTTAX01.DCLLOTTAXA01.LOTTAX01_DTINIVIG.ToString(),
            };

            var executed_1 = R1010_00_LER_TAXA_DB_SELECT_1_Query1.Execute(r1010_00_LER_TAXA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LOTTAX01_TAXA_IS_FENAL, LOTTAX01.DCLLOTTAXA01.LOTTAX01_TAXA_IS_FENAL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-PROCESSAR-COEF-SECTION */
        private void R1100_00_PROCESSAR_COEF_SECTION()
        {
            /*" -259- MOVE '1100' TO WS-PARAGRAFO. */
            _.Move("1100", WS_PARAGRAFO);

            /*" -260- MOVE 107100070673 TO LOTTAX01-NUM-APOLICE */
            _.Move(107100070673, LOTTAX01.DCLLOTTAXA01.LOTTAX01_NUM_APOLICE);

            /*" -261- MOVE 1000 TO LOTTAX01-COD-LOT-FENAL */
            _.Move(1000, LOTTAX01.DCLLOTTAXA01.LOTTAX01_COD_LOT_FENAL);

            /*" -262- MOVE LT3250-DTINIVIG TO LOTTAX01-DTINIVIG */
            _.Move(LBLT3250.LT3250_AREA_PARAMETROS.LT3250_DTINIVIG, LOTTAX01.DCLLOTTAXA01.LOTTAX01_DTINIVIG);

            /*" -263- MOVE LT3250-DTTERVIG TO LOTTAX01-DTTERVIG */
            _.Move(LBLT3250.LT3250_AREA_PARAMETROS.LT3250_DTTERVIG, LOTTAX01.DCLLOTTAXA01.LOTTAX01_DTTERVIG);

            /*" -266- MOVE LT3250-NUM-CLASSE TO LOTTAX01-RAMO-COBERTURA */
            _.Move(LBLT3250.LT3250_AREA_PARAMETROS.LT3250_NUM_CLASSE, LOTTAX01.DCLLOTTAXA01.LOTTAX01_RAMO_COBERTURA);

            /*" -267- PERFORM VARYING WS-IND FROM 1 BY 1 UNTIL WS-IND GREATER 60 */

            for (WS_IND.Value = 1; !(WS_IND > 60); WS_IND.Value += 1)
            {

                /*" -268- MOVE WS-IND TO LOTTAX01-COD-COBERTURA */
                _.Move(WS_IND, LOTTAX01.DCLLOTTAXA01.LOTTAX01_COD_COBERTURA);

                /*" -269- PERFORM R1110-00-LER-COEF */

                R1110_00_LER_COEF_SECTION();

                /*" -271- MOVE LOTTAX01-TAXA-IS-FENAL TO LT3250-PCT-COEFICIENTE(WS-IND) */
                _.Move(LOTTAX01.DCLLOTTAXA01.LOTTAX01_TAXA_IS_FENAL, LBLT3250.LT3250_AREA_PARAMETROS.LT3250_TAB_COEFICIENTES.LT3250_PERCENT_COEFICIENTES[WS_IND].LT3250_PCT_COEFICIENTE);

                /*" -273- END-PERFORM */
            }

            /*" -273- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1110-00-LER-COEF-SECTION */
        private void R1110_00_LER_COEF_SECTION()
        {
            /*" -282- MOVE '1110' TO WS-PARAGRAFO. */
            _.Move("1110", WS_PARAGRAFO);

            /*" -284- MOVE ZEROS TO LOTTAX01-TAXA-IS-FENAL */
            _.Move(0, LOTTAX01.DCLLOTTAXA01.LOTTAX01_TAXA_IS_FENAL);

            /*" -295- PERFORM R1110_00_LER_COEF_DB_SELECT_1 */

            R1110_00_LER_COEF_DB_SELECT_1();

            /*" -298- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -299- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -300- MOVE 0 TO LOTTAX01-TAXA-IS-FENAL */
                    _.Move(0, LOTTAX01.DCLLOTTAXA01.LOTTAX01_TAXA_IS_FENAL);

                    /*" -301- ELSE */
                }
                else
                {


                    /*" -302- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, WS_SQLCODE);

                    /*" -303- DISPLAY ' LT3250S-R1110-ERRO LOTTAXA01 ' */
                    _.Display($" LT3250S-R1110-ERRO LOTTAXA01 ");

                    /*" -304- DISPLAY 'NUM-APOLICE  ' LOTTAX01-NUM-APOLICE */
                    _.Display($"NUM-APOLICE  {LOTTAX01.DCLLOTTAXA01.LOTTAX01_NUM_APOLICE}");

                    /*" -305- DISPLAY 'COD-LOT-FENAL' LOTTAX01-COD-LOT-FENAL */
                    _.Display($"COD-LOT-FENAL{LOTTAX01.DCLLOTTAXA01.LOTTAX01_COD_LOT_FENAL}");

                    /*" -306- DISPLAY 'RAMO-COBERTUR' LOTTAX01-RAMO-COBERTURA */
                    _.Display($"RAMO-COBERTUR{LOTTAX01.DCLLOTTAXA01.LOTTAX01_RAMO_COBERTURA}");

                    /*" -307- DISPLAY 'DTINIVIG     ' LOTTAX01-DTINIVIG */
                    _.Display($"DTINIVIG     {LOTTAX01.DCLLOTTAXA01.LOTTAX01_DTINIVIG}");

                    /*" -308- DISPLAY 'SQLCODE      ' WS-SQLCODE */
                    _.Display($"SQLCODE      {WS_SQLCODE}");

                    /*" -309- PERFORM R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION();

                    /*" -310- END-IF */
                }


                /*" -311- END-IF */
            }


            /*" -311- . */

        }

        [StopWatch]
        /*" R1110-00-LER-COEF-DB-SELECT-1 */
        public void R1110_00_LER_COEF_DB_SELECT_1()
        {
            /*" -295- EXEC SQL SELECT TAXA_IS_FENAL INTO :LOTTAX01-TAXA-IS-FENAL FROM SEGUROS.V0LOTTAXA01 WHERE NUM_APOLICE = :LOTTAX01-NUM-APOLICE AND COD_COBERTURA = :LOTTAX01-COD-COBERTURA AND COD_LOT_FENAL = :LOTTAX01-COD-LOT-FENAL AND RAMO_COBERTURA = :LOTTAX01-RAMO-COBERTURA AND :LOTTAX01-DTINIVIG BETWEEN DTINIVIG AND DTTERVIG WITH UR END-EXEC. */

            var r1110_00_LER_COEF_DB_SELECT_1_Query1 = new R1110_00_LER_COEF_DB_SELECT_1_Query1()
            {
                LOTTAX01_RAMO_COBERTURA = LOTTAX01.DCLLOTTAXA01.LOTTAX01_RAMO_COBERTURA.ToString(),
                LOTTAX01_COD_COBERTURA = LOTTAX01.DCLLOTTAXA01.LOTTAX01_COD_COBERTURA.ToString(),
                LOTTAX01_COD_LOT_FENAL = LOTTAX01.DCLLOTTAXA01.LOTTAX01_COD_LOT_FENAL.ToString(),
                LOTTAX01_NUM_APOLICE = LOTTAX01.DCLLOTTAXA01.LOTTAX01_NUM_APOLICE.ToString(),
                LOTTAX01_DTINIVIG = LOTTAX01.DCLLOTTAXA01.LOTTAX01_DTINIVIG.ToString(),
            };

            var executed_1 = R1110_00_LER_COEF_DB_SELECT_1_Query1.Execute(r1110_00_LER_COEF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LOTTAX01_TAXA_IS_FENAL, LOTTAX01.DCLLOTTAXA01.LOTTAX01_TAXA_IS_FENAL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-PROCESSAR-PCT-PLURI-SECTION */
        private void R1200_00_PROCESSAR_PCT_PLURI_SECTION()
        {
            /*" -324- MOVE '1200' TO WS-PARAGRAFO. */
            _.Move("1200", WS_PARAGRAFO);

            /*" -325- MOVE 107100070673 TO LOTTAX01-NUM-APOLICE */
            _.Move(107100070673, LOTTAX01.DCLLOTTAXA01.LOTTAX01_NUM_APOLICE);

            /*" -326- MOVE 2000 TO LOTTAX01-COD-LOT-FENAL */
            _.Move(2000, LOTTAX01.DCLLOTTAXA01.LOTTAX01_COD_LOT_FENAL);

            /*" -327- MOVE LT3250-DTINIVIG TO LOTTAX01-DTINIVIG */
            _.Move(LBLT3250.LT3250_AREA_PARAMETROS.LT3250_DTINIVIG, LOTTAX01.DCLLOTTAXA01.LOTTAX01_DTINIVIG);

            /*" -329- MOVE LT3250-DTTERVIG TO LOTTAX01-DTTERVIG */
            _.Move(LBLT3250.LT3250_AREA_PARAMETROS.LT3250_DTTERVIG, LOTTAX01.DCLLOTTAXA01.LOTTAX01_DTTERVIG);

            /*" -330- IF LT3250-DTINIVIG < '2021-01-01' */

            if (LBLT3250.LT3250_AREA_PARAMETROS.LT3250_DTINIVIG < "2021-01-01")
            {

                /*" -331- GO TO R1200-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/ //GOTO
                return;

                /*" -333- END-IF */
            }


            /*" -334- PERFORM VARYING WS-IND FROM 1 BY 1 UNTIL WS-IND > 5 */

            for (WS_IND.Value = 1; !(WS_IND > 5); WS_IND.Value += 1)
            {

                /*" -335- PERFORM R1260-00-CALC-QTD-DIAS-VIG */

                R1260_00_CALC_QTD_DIAS_VIG_SECTION();

                /*" -336- IF WS-QTD-DIAS-VIGENCIA > 0 */

                if (WS_QTD_DIAS_VIGENCIA > 0)
                {

                    /*" -337- PERFORM R1250-00-LER-PCT-PLURI */

                    R1250_00_LER_PCT_PLURI_SECTION();

                    /*" -341- MOVE LOTTAX01-TAXA-IS-FENAL TO LT3250-PCT-PLURI(WS-IND) WS-VALORS TB-SAI-PCT-PLURI(WS-IND) */
                    _.Move(LOTTAX01.DCLLOTTAXA01.LOTTAX01_TAXA_IS_FENAL, LBLT3250.LT3250_AREA_PARAMETROS.LT3250_TAB_COEF_PLURI.LT3250_PERCENT_PLURI[WS_IND].LT3250_PCT_PLURI, WS_VALORS, WS_AREA_WORK.TAB_SAI_PLURI[WS_IND].TB_SAI_PCT_PLURI);

                    /*" -343- MOVE WS-QTD-DIAS-VIGENCIA TO LT3250-QTD-DIAS-PLURI(WS-IND) */
                    _.Move(WS_QTD_DIAS_VIGENCIA, LBLT3250.LT3250_AREA_PARAMETROS.LT3250_TAB_COEF_PLURI.LT3250_PERCENT_PLURI[WS_IND].LT3250_QTD_DIAS_PLURI);

                    /*" -344- END-IF */
                }


                /*" -345- END-PERFORM */
            }

            /*" -345- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1250-00-LER-PCT-PLURI-SECTION */
        private void R1250_00_LER_PCT_PLURI_SECTION()
        {
            /*" -354- MOVE '1250' TO WS-PARAGRAFO. */
            _.Move("1250", WS_PARAGRAFO);

            /*" -355- MOVE ZEROS TO LOTTAX01-TAXA-IS-FENAL */
            _.Move(0, LOTTAX01.DCLLOTTAXA01.LOTTAX01_TAXA_IS_FENAL);

            /*" -357- MOVE WS-QTD-DIAS-VIGENCIA TO LOTTAX01-RAMO-COBERTURA */
            _.Move(WS_QTD_DIAS_VIGENCIA, LOTTAX01.DCLLOTTAXA01.LOTTAX01_RAMO_COBERTURA);

            /*" -367- PERFORM R1250_00_LER_PCT_PLURI_DB_SELECT_1 */

            R1250_00_LER_PCT_PLURI_DB_SELECT_1();

            /*" -370- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -371- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_SQLCODE);

                /*" -373- MOVE 'R1250-PCT PLURI NAO CADASTRADO NA LOTTAXA01' TO LT3250-MENSAGEM */
                _.Move("R1250-PCT PLURI NAO CADASTRADO NA LOTTAXA01", LBLT3250.LT3250_AREA_PARAMETROS.LT3250_MENSAGEM);

                /*" -374- DISPLAY LT3250-MENSAGEM */
                _.Display(LBLT3250.LT3250_AREA_PARAMETROS.LT3250_MENSAGEM);

                /*" -375- DISPLAY 'NUM-APOLICE  :' LOTTAX01-NUM-APOLICE */
                _.Display($"NUM-APOLICE  :{LOTTAX01.DCLLOTTAXA01.LOTTAX01_NUM_APOLICE}");

                /*" -376- DISPLAY 'COD-LOT-FENAL:' LOTTAX01-COD-LOT-FENAL */
                _.Display($"COD-LOT-FENAL:{LOTTAX01.DCLLOTTAXA01.LOTTAX01_COD_LOT_FENAL}");

                /*" -377- DISPLAY 'RAMO-COBERTUR:' LOTTAX01-RAMO-COBERTURA */
                _.Display($"RAMO-COBERTUR:{LOTTAX01.DCLLOTTAXA01.LOTTAX01_RAMO_COBERTURA}");

                /*" -378- DISPLAY 'DTINIVIG     :' LOTTAX01-DTINIVIG */
                _.Display($"DTINIVIG     :{LOTTAX01.DCLLOTTAXA01.LOTTAX01_DTINIVIG}");

                /*" -379- DISPLAY 'DTTERVIG     :' WS-DATA */
                _.Display($"DTTERVIG     :{WS_DATA}");

                /*" -380- DISPLAY 'SQLCODE      :' WS-SQLCODE */
                _.Display($"SQLCODE      :{WS_SQLCODE}");

                /*" -381- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -382- END-IF */
            }


            /*" -382- . */

        }

        [StopWatch]
        /*" R1250-00-LER-PCT-PLURI-DB-SELECT-1 */
        public void R1250_00_LER_PCT_PLURI_DB_SELECT_1()
        {
            /*" -367- EXEC SQL SELECT TAXA_IS_FENAL INTO :LOTTAX01-TAXA-IS-FENAL FROM SEGUROS.V0LOTTAXA01 WHERE NUM_APOLICE = :LOTTAX01-NUM-APOLICE AND COD_LOT_FENAL = :LOTTAX01-COD-LOT-FENAL AND RAMO_COBERTURA = :LOTTAX01-RAMO-COBERTURA AND :LOTTAX01-DTINIVIG BETWEEN DTINIVIG AND DTTERVIG WITH UR END-EXEC. */

            var r1250_00_LER_PCT_PLURI_DB_SELECT_1_Query1 = new R1250_00_LER_PCT_PLURI_DB_SELECT_1_Query1()
            {
                LOTTAX01_RAMO_COBERTURA = LOTTAX01.DCLLOTTAXA01.LOTTAX01_RAMO_COBERTURA.ToString(),
                LOTTAX01_COD_LOT_FENAL = LOTTAX01.DCLLOTTAXA01.LOTTAX01_COD_LOT_FENAL.ToString(),
                LOTTAX01_NUM_APOLICE = LOTTAX01.DCLLOTTAXA01.LOTTAX01_NUM_APOLICE.ToString(),
                LOTTAX01_DTINIVIG = LOTTAX01.DCLLOTTAXA01.LOTTAX01_DTINIVIG.ToString(),
            };

            var executed_1 = R1250_00_LER_PCT_PLURI_DB_SELECT_1_Query1.Execute(r1250_00_LER_PCT_PLURI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LOTTAX01_TAXA_IS_FENAL, LOTTAX01.DCLLOTTAXA01.LOTTAX01_TAXA_IS_FENAL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1250_99_SAIDA*/

        [StopWatch]
        /*" R1260-00-CALC-QTD-DIAS-VIG-SECTION */
        private void R1260_00_CALC_QTD_DIAS_VIG_SECTION()
        {
            /*" -390- IF WS-DISPLAY = 'SIM' */

            if (WS_DISPLAY == "SIM")
            {

                /*" -395- DISPLAY 'R1260-INICIO ......' ' DTINIVIG:' LT3250-DTINIVIG ' WS-IND:' WS-IND ' TB-DTTER-PLURI(WS-IND):' TB-DTTER-PLURI(WS-IND) */

                $"R1260-INICIO ...... DTINIVIG:{LBLT3250.LT3250_AREA_PARAMETROS.LT3250_DTINIVIG} WS-IND:{WS_IND} TB-DTTER-PLURI(WS-IND):{LBTB3201.TABELA_VIG_PLURI.TAB_VIG_PLURI_R.TB_VIG_PLURI[WS_IND]}"
                .Display();

                /*" -397- END-IF. */
            }


            /*" -398- MOVE '1260' TO WS-PARAGRAFO. */
            _.Move("1260", WS_PARAGRAFO);

            /*" -399- MOVE 0 TO WS-QTD-DIAS-VIGENCIA */
            _.Move(0, WS_QTD_DIAS_VIGENCIA);

            /*" -400- MOVE TB-DTTER-PLURI(WS-IND) TO WS-DATA */
            _.Move(LBTB3201.TABELA_VIG_PLURI.TAB_VIG_PLURI_R.TB_VIG_PLURI[WS_IND].TB_DTTER_PLURI, WS_DATA);

            /*" -407- PERFORM R1260_00_CALC_QTD_DIAS_VIG_DB_SELECT_1 */

            R1260_00_CALC_QTD_DIAS_VIG_DB_SELECT_1();

            /*" -410- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -411- DISPLAY 'R1260-ERRO CALC QTD DIAS VIGENCIA...' */
                _.Display($"R1260-ERRO CALC QTD DIAS VIGENCIA...");

                /*" -412- DISPLAY 'DTINIVIG     ' LT3250-DTINIVIG */
                _.Display($"DTINIVIG     {LBLT3250.LT3250_AREA_PARAMETROS.LT3250_DTINIVIG}");

                /*" -413- DISPLAY 'DTTERVIG     ' WS-DATA */
                _.Display($"DTTERVIG     {WS_DATA}");

                /*" -414- DISPLAY 'SQLCODE      ' SQLCODE */
                _.Display($"SQLCODE      {DB.SQLCODE}");

                /*" -415- DISPLAY 'WS-IND:      ' WS-IND */
                _.Display($"WS-IND:      {WS_IND}");

                /*" -416- DISPLAY ' TB-DTTER-PLURI(WS-IND):' TB-DTTER-PLURI(WS-IND) */
                _.Display($" TB-DTTER-PLURI(WS-IND):{LBTB3201.TABELA_VIG_PLURI.TAB_VIG_PLURI_R.TB_VIG_PLURI[WS_IND]}");

                /*" -417- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -419- END-IF */
            }


            /*" -420- IF WS-DISPLAY = 'SIM' */

            if (WS_DISPLAY == "SIM")
            {

                /*" -421- IF WS-QTD-DIAS-VIGENCIA > 1826 */

                if (WS_QTD_DIAS_VIGENCIA > 1826)
                {

                    /*" -427- DISPLAY 'R1260- QTDDIAS > 1826 AJUSTADO...' ' DTINIVIG:' LT3250-DTINIVIG ' DTTERVIG:' WS-DATA ' QTD-DIAS-VIG:' WS-QTD-DIAS-VIGENCIA ' WS-IND:      ' WS-IND ' TB-DTTER-PLURI(WS-IND):' TB-DTTER-PLURI(WS-IND) */

                    $"R1260- QTDDIAS > 1826 AJUSTADO... DTINIVIG:{LBLT3250.LT3250_AREA_PARAMETROS.LT3250_DTINIVIG} DTTERVIG:{WS_DATA} QTD-DIAS-VIG:{WS_QTD_DIAS_VIGENCIA} WS-IND:      {WS_IND} TB-DTTER-PLURI(WS-IND):{LBTB3201.TABELA_VIG_PLURI.TAB_VIG_PLURI_R.TB_VIG_PLURI[WS_IND]}"
                    .Display();

                    /*" -428- MOVE 1826 TO WS-QTD-DIAS-VIGENCIA */
                    _.Move(1826, WS_QTD_DIAS_VIGENCIA);

                    /*" -430- END-IF */
                }


                /*" -431- IF WS-QTD-DIAS-VIGENCIA < 1 */

                if (WS_QTD_DIAS_VIGENCIA < 1)
                {

                    /*" -437- DISPLAY 'R1260- QTDDIAS < 1 AJUSTADO...' ' DTINIVIG:' LT3250-DTINIVIG ' DTTERVIG:' WS-DATA ' QTD-DIAS-VIG:' WS-QTD-DIAS-VIGENCIA ' WS-IND:      ' WS-IND ' TB-DTTER-PLURI(WS-IND):' TB-DTTER-PLURI(WS-IND) */

                    $"R1260- QTDDIAS < 1 AJUSTADO... DTINIVIG:{LBLT3250.LT3250_AREA_PARAMETROS.LT3250_DTINIVIG} DTTERVIG:{WS_DATA} QTD-DIAS-VIG:{WS_QTD_DIAS_VIGENCIA} WS-IND:      {WS_IND} TB-DTTER-PLURI(WS-IND):{LBTB3201.TABELA_VIG_PLURI.TAB_VIG_PLURI_R.TB_VIG_PLURI[WS_IND]}"
                    .Display();

                    /*" -438- MOVE 1 TO WS-QTD-DIAS-VIGENCIA */
                    _.Move(1, WS_QTD_DIAS_VIGENCIA);

                    /*" -439- END-IF */
                }


                /*" -441- END-IF. */
            }


            /*" -443- MOVE WS-QTD-DIAS-VIGENCIA TO WS-VALORS */
            _.Move(WS_QTD_DIAS_VIGENCIA, WS_VALORS);

            /*" -444- MOVE WS-IND TO TB-SAI-IND(WS-IND) */
            _.Move(WS_IND, WS_AREA_WORK.TAB_SAI_PLURI[WS_IND].TB_SAI_IND);

            /*" -445- MOVE LT3250-DTINIVIG TO TB-SAI-DTINIVIG(WS-IND) */
            _.Move(LBLT3250.LT3250_AREA_PARAMETROS.LT3250_DTINIVIG, WS_AREA_WORK.TAB_SAI_PLURI[WS_IND].TB_SAI_DTINIVIG);

            /*" -446- MOVE WS-DATA TO TB-SAI-DTTERVIG(WS-IND) */
            _.Move(WS_DATA, WS_AREA_WORK.TAB_SAI_PLURI[WS_IND].TB_SAI_DTTERVIG);

            /*" -447- MOVE WS-QTD-DIAS-VIGENCIA TO TB-SAI-QTD-DIAS(WS-IND) */
            _.Move(WS_QTD_DIAS_VIGENCIA, WS_AREA_WORK.TAB_SAI_PLURI[WS_IND].TB_SAI_QTD_DIAS);

            /*" -449- MOVE 0 TO TB-SAI-PCT-PLURI(WS-IND) */
            _.Move(0, WS_AREA_WORK.TAB_SAI_PLURI[WS_IND].TB_SAI_PCT_PLURI);

            /*" -450- IF WS-DISPLAY = 'SIM' */

            if (WS_DISPLAY == "SIM")
            {

                /*" -456- DISPLAY 'R1260-CALCULO-QTD DIAS VIG...' ' DTINIVIG:' LT3250-DTINIVIG ' DTTERVIG:' WS-DATA ' QTD-DIAS-VIG:' WS-QTD-DIAS-VIGENCIA ' WS-IND:      ' WS-IND ' TB-DTTER-PLURI(WS-IND):' TB-DTTER-PLURI(WS-IND) */

                $"R1260-CALCULO-QTD DIAS VIG... DTINIVIG:{LBLT3250.LT3250_AREA_PARAMETROS.LT3250_DTINIVIG} DTTERVIG:{WS_DATA} QTD-DIAS-VIG:{WS_QTD_DIAS_VIGENCIA} WS-IND:      {WS_IND} TB-DTTER-PLURI(WS-IND):{LBTB3201.TABELA_VIG_PLURI.TAB_VIG_PLURI_R.TB_VIG_PLURI[WS_IND]}"
                .Display();

                /*" -457- END-IF */
            }


            /*" -457- . */

        }

        [StopWatch]
        /*" R1260-00-CALC-QTD-DIAS-VIG-DB-SELECT-1 */
        public void R1260_00_CALC_QTD_DIAS_VIG_DB_SELECT_1()
        {
            /*" -407- EXEC SQL SELECT (DAYS(:WS-DATA) - DAYS(:LT3250-DTINIVIG) + 1) INTO :WS-QTD-DIAS-VIGENCIA FROM SYSIBM.SYSDUMMY1 WITH UR END-EXEC. */

            var r1260_00_CALC_QTD_DIAS_VIG_DB_SELECT_1_Query1 = new R1260_00_CALC_QTD_DIAS_VIG_DB_SELECT_1_Query1()
            {
                LT3250_DTINIVIG = LBLT3250.LT3250_AREA_PARAMETROS.LT3250_DTINIVIG.ToString(),
                WS_DATA = WS_DATA.ToString(),
            };

            var executed_1 = R1260_00_CALC_QTD_DIAS_VIG_DB_SELECT_1_Query1.Execute(r1260_00_CALC_QTD_DIAS_VIG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_QTD_DIAS_VIGENCIA, WS_QTD_DIAS_VIGENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1260_99_SAIDA*/

        [StopWatch]
        /*" R9090-00-ROT-RETORNO-SECTION */
        private void R9090_00_ROT_RETORNO_SECTION()
        {
            /*" -465- IF LT3250-COD-RETORNO NOT EQUAL ZEROES */

            if (LBLT3250.LT3250_AREA_PARAMETROS.LT3250_COD_RETORNO != 00)
            {

                /*" -466- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_SQLCODE);

                /*" -470- DISPLAY 'LT3250S-R9090:' '/' WS-SQLCODE '/' LT3250-COD-RETORNO '/' LT3250-MENSAGEM */

                $"LT3250S-R9090:/{WS_SQLCODE}/{LBLT3250.LT3250_AREA_PARAMETROS.LT3250_COD_RETORNO}/{LBLT3250.LT3250_AREA_PARAMETROS.LT3250_MENSAGEM}"
                .Display();

                /*" -474- DISPLAY 'NCLA=' LT3250-NUM-CLASSE ' REG=' LT3250-COD-REGIAO ' DTI=' LT3250-DTINIVIG ' DTT=' LT3250-DTTERVIG */

                $"NCLA={LBLT3250.LT3250_AREA_PARAMETROS.LT3250_NUM_CLASSE} REG={LBLT3250.LT3250_AREA_PARAMETROS.LT3250_COD_REGIAO} DTI={LBLT3250.LT3250_AREA_PARAMETROS.LT3250_DTINIVIG} DTT={LBLT3250.LT3250_AREA_PARAMETROS.LT3250_DTTERVIG}"
                .Display();

                /*" -476- END-IF */
            }


            /*" -478- MOVE ' ' TO LT3250-DISPLAY */
            _.Move(" ", LBLT3250.LT3250_AREA_PARAMETROS.LT3250_DISPLAY);

            /*" -479- IF LT3250-DISPLAY EQUAL 'S' */

            if (LBLT3250.LT3250_AREA_PARAMETROS.LT3250_DISPLAY == "S")
            {

                /*" -480- DISPLAY '-------------------------------------------' */
                _.Display($"-------------------------------------------");

                /*" -481- DISPLAY 'LT3250-' */
                _.Display($"LT3250-");

                /*" -484- DISPLAY ' DTINIVIG=' LT3250-DTINIVIG ' CLASSE=' LT3250-NUM-CLASSE ' REGIAO=' LT3250-COD-REGIAO */

                $" DTINIVIG={LBLT3250.LT3250_AREA_PARAMETROS.LT3250_DTINIVIG} CLASSE={LBLT3250.LT3250_AREA_PARAMETROS.LT3250_NUM_CLASSE} REGIAO={LBLT3250.LT3250_AREA_PARAMETROS.LT3250_COD_REGIAO}"
                .Display();

                /*" -485- DISPLAY '-------------------------------------------' */
                _.Display($"-------------------------------------------");

                /*" -486- DISPLAY '--------- TAXAS ---------------------------' */
                _.Display($"--------- TAXAS ---------------------------");

                /*" -487- PERFORM VARYING WS-IND FROM 1 BY 1 UNTIL WS-IND > 20 */

                for (WS_IND.Value = 1; !(WS_IND > 20); WS_IND.Value += 1)
                {

                    /*" -488- MOVE LT3250-TAXA(WS-IND) TO WS-TAXAS */
                    _.Move(LBLT3250.LT3250_AREA_PARAMETROS.LT3250_TAB_TAXAS.LT3250_VALORES_TAXAS[WS_IND].LT3250_TAXA, WS_TAXAS);

                    /*" -490- DISPLAY ' COB=' WS-IND ' TAXA=' WS-TAXAS */

                    $" COB={WS_IND} TAXA={WS_TAXAS}"
                    .Display();

                    /*" -492- END-PERFORM */
                }

                /*" -493- DISPLAY '--------- COEFICIENTES --------------------' */
                _.Display($"--------- COEFICIENTES --------------------");

                /*" -494- PERFORM VARYING WS-IND FROM 1 BY 1 UNTIL WS-IND > 60 */

                for (WS_IND.Value = 1; !(WS_IND > 60); WS_IND.Value += 1)
                {

                    /*" -495- MOVE LT3250-PCT-COEFICIENTE(WS-IND) TO WS-TAXAS */
                    _.Move(LBLT3250.LT3250_AREA_PARAMETROS.LT3250_TAB_COEFICIENTES.LT3250_PERCENT_COEFICIENTES[WS_IND].LT3250_PCT_COEFICIENTE, WS_TAXAS);

                    /*" -497- DISPLAY ' NR.PARCELA=' WS-IND ' COEF=' WS-TAXAS */

                    $" NR.PARCELA={WS_IND} COEF={WS_TAXAS}"
                    .Display();

                    /*" -498- END-PERFORM */
                }

                /*" -500- END-IF */
            }


            /*" -502- MOVE ' ' TO LT3250-DISPLAY */
            _.Move(" ", LBLT3250.LT3250_AREA_PARAMETROS.LT3250_DISPLAY);

            /*" -503- IF LT3250-DISPLAY EQUAL 'S' */

            if (LBLT3250.LT3250_AREA_PARAMETROS.LT3250_DISPLAY == "S")
            {

                /*" -504- PERFORM VARYING WS-IND FROM 1 BY 1 UNTIL WS-IND > 5 */

                for (WS_IND.Value = 1; !(WS_IND > 5); WS_IND.Value += 1)
                {

                    /*" -505- IF TB-SAI-IND(WS-IND) > 0 */

                    if (WS_AREA_WORK.TAB_SAI_PLURI[WS_IND].TB_SAI_IND > 0)
                    {

                        /*" -511- DISPLAY 'LT3250-R9090-PERCENT PLURI' ' ANOVIG:' TB-SAI-IND(WS-IND) ' INI:' TB-SAI-DTINIVIG(WS-IND) ' TER:' TB-SAI-DTTERVIG(WS-IND) ' QTDIAS:' TB-SAI-QTD-DIAS(WS-IND) ' PCTPLURI:' TB-SAI-PCT-PLURI(WS-IND) */

                        $"LT3250-R9090-PERCENT PLURI ANOVIG:{WS_AREA_WORK.TAB_SAI_PLURI[WS_IND]} INI:{WS_AREA_WORK.TAB_SAI_PLURI[WS_IND]} TER:{WS_AREA_WORK.TAB_SAI_PLURI[WS_IND]} QTDIAS:{WS_AREA_WORK.TAB_SAI_PLURI[WS_IND]} PCTPLURI:{WS_AREA_WORK.TAB_SAI_PLURI[WS_IND]}"
                        .Display();

                        /*" -512- END-IF */
                    }


                    /*" -513- END-PERFORM */
                }

                /*" -514- DISPLAY '  ' */
                _.Display($"  ");

                /*" -516- END-IF */
            }


            /*" -517- GOBACK */

            throw new GoBack();

            /*" -517- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9090_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -526- MOVE SQLCODE TO WS-SQLCODE. */
            _.Move(DB.SQLCODE, WS_SQLCODE);

            /*" -531- DISPLAY 'LT3250S-R9999:' '/' WS-SQLCODE '/' LT3250-COD-RETORNO '/' LT3250-MENSAGEM. */

            $"LT3250S-R9999:/{WS_SQLCODE}/{LBLT3250.LT3250_AREA_PARAMETROS.LT3250_COD_RETORNO}/{LBLT3250.LT3250_AREA_PARAMETROS.LT3250_MENSAGEM}"
            .Display();

            /*" -531- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -533- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -537- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -537- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}