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
using Sias.Sinistro.DB2.SI1000S;

namespace Code
{
    public class SI1000S
    {
        public bool IsCall { get; set; }

        public SI1000S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SISTEMA SINISTRO                   *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  SI1000S.                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  PRODEXTER                          *      */
        /*"      *   PROG/ANALISTA...........  PRODEXTER                          *      */
        /*"      *   DATA CODIFICACAO .......  ABRIL/2005                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  OBTEM VALOR A PARTIR DE UMA FUNCAO *      */
        /*"      *                             DE CALCULO PARAMETRIZADA           *      */
        /*"      *                                                                *      */
        /*"      *   OBS.:                                                        *      */
        /*"      *   (1) OS BOOK'S UTILIZADOS ESTAO NA DES.SIA.SRCLIB.DATA        *      */
        /*"      *                                                                *      */
        /*"      *   (2) AS FUNCOES ESTAO PARAMETRIZADAS NAS TABELAS              *      */
        /*"      *       GE_SISTEMA_FUNCAO E GE_SIS_FUNCAO_OPER                   *      */
        /*"      *                                                                *      */
        /*"      *   (3) OS VALORES SAO CALCULADOS A PARTIR DOS MOVIMENTOS        *      */
        /*"      *       EXISTENTES NA TABELA SINISTRO_HISTORICO                  *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"01        HOST-DATA-INICIO        PIC  X(010).*/
        public StringBasis HOST_DATA_INICIO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01        HOST-DATA-FIM           PIC  X(010).*/
        public StringBasis HOST_DATA_FIM { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");


        public Copies.LBSI1000 LBSI1000 { get; set; } = new Copies.LBSI1000();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.GESISFUO GESISFUO { get; set; } = new Dclgens.GESISFUO();
        public Dclgens.GESISFUN GESISFUN { get; set; } = new Dclgens.GESISFUN();
        public Dclgens.CALENDAR CALENDAR { get; set; } = new Dclgens.CALENDAR();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(LBSI1000_SI1000S_PARAMETROS LBSI1000_SI1000S_PARAMETROS_P) //PROCEDURE DIVISION USING 
        /*SI1000S_PARAMETROS*/
        {
            try
            {
                this.LBSI1000.SI1000S_PARAMETROS = LBSI1000_SI1000S_PARAMETROS_P;

                /*" -71- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -72- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -73- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -73- FLUXCONTROL_PERFORM R0000-00-INICIO-SECTION */

                R0000_00_INICIO_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LBSI1000.SI1000S_PARAMETROS };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-INICIO-SECTION */
        private void R0000_00_INICIO_SECTION()
        {
            /*" -80- MOVE '000' TO SI1000S-ERRO-PARAGRAFO */
            _.Move("000", LBSI1000.SI1000S_PARAMETROS.SI1000S_SAIDA.SI1000S_ERRO_PARAGRAFO);

            /*" -82- PERFORM R0100-00-CONSISTE-ENTRADA */

            R0100_00_CONSISTE_ENTRADA_SECTION();

            /*" -86- PERFORM R0200-00-CALCULA-VALOR */

            R0200_00_CALCULA_VALOR_SECTION();

            /*" -86- GOBACK. */

            throw new GoBack();

        }

        [StopWatch]
        /*" R0100-00-CONSISTE-ENTRADA-SECTION */
        private void R0100_00_CONSISTE_ENTRADA_SECTION()
        {
            /*" -95- MOVE '010' TO SI1000S-ERRO-PARAGRAFO */
            _.Move("010", LBSI1000.SI1000S_PARAMETROS.SI1000S_SAIDA.SI1000S_ERRO_PARAGRAFO);

            /*" -97- IF SI1000S-IDE-SISTEMA EQUAL SPACES */

            if (LBSI1000.SI1000S_PARAMETROS.SI1000S_ENTRADA.SI1000S_IDE_SISTEMA.IsEmpty())
            {

                /*" -99- MOVE 'SI1000S - CODIGO DO SISTEMA DA FUNCAO NAO INFORMADO' TO SI1000S-ERRO-MENSAGEM */
                _.Move("SI1000S - CODIGO DO SISTEMA DA FUNCAO NAO INFORMADO", LBSI1000.SI1000S_PARAMETROS.SI1000S_SAIDA.SI1000S_ERRO_MENSAGEM);

                /*" -101- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -103- IF SI1000S-IDE-SISTEMA-OPER EQUAL SPACES */

            if (LBSI1000.SI1000S_PARAMETROS.SI1000S_ENTRADA.SI1000S_IDE_SISTEMA_OPER.IsEmpty())
            {

                /*" -105- MOVE 'SI1000S - CODIGO DO SISTEMA DA OPERACAO NAO INFORMADO' TO SI1000S-ERRO-MENSAGEM */
                _.Move("SI1000S - CODIGO DO SISTEMA DA OPERACAO NAO INFORMADO", LBSI1000.SI1000S_PARAMETROS.SI1000S_SAIDA.SI1000S_ERRO_MENSAGEM);

                /*" -107- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -109- IF SI1000S-COD-FUNCAO EQUAL ZEROS */

            if (LBSI1000.SI1000S_PARAMETROS.SI1000S_ENTRADA.SI1000S_COD_FUNCAO == 00)
            {

                /*" -111- MOVE 'SI1000S - CODIGO DA FUNCAO NAO INFORMADO' TO SI1000S-ERRO-MENSAGEM */
                _.Move("SI1000S - CODIGO DA FUNCAO NAO INFORMADO", LBSI1000.SI1000S_PARAMETROS.SI1000S_SAIDA.SI1000S_ERRO_MENSAGEM);

                /*" -113- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -115- MOVE SI1000S-IDE-SISTEMA TO GESISFUN-IDE-SISTEMA */
            _.Move(LBSI1000.SI1000S_PARAMETROS.SI1000S_ENTRADA.SI1000S_IDE_SISTEMA, GESISFUN.DCLGE_SISTEMA_FUNCAO.GESISFUN_IDE_SISTEMA);

            /*" -117- MOVE SI1000S-COD-FUNCAO TO GESISFUN-COD-FUNCAO */
            _.Move(LBSI1000.SI1000S_PARAMETROS.SI1000S_ENTRADA.SI1000S_COD_FUNCAO, GESISFUN.DCLGE_SISTEMA_FUNCAO.GESISFUN_COD_FUNCAO);

            /*" -119- PERFORM R0110-00-LE-GE-SISTEMA-FUNCAO */

            R0110_00_LE_GE_SISTEMA_FUNCAO_SECTION();

            /*" -120- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -122- MOVE 'SI1000S - FUNCAO NAO CADASTRADA' TO SI1000S-ERRO-MENSAGEM */
                _.Move("SI1000S - FUNCAO NAO CADASTRADA", LBSI1000.SI1000S_PARAMETROS.SI1000S_SAIDA.SI1000S_ERRO_MENSAGEM);

                /*" -126- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -128- IF SI1000S-NUM-APOL-SINISTRO NOT NUMERIC */

            if (!LBSI1000.SI1000S_PARAMETROS.SI1000S_ENTRADA.SI1000S_NUM_APOL_SINISTRO.IsNumeric())
            {

                /*" -130- MOVE 'SI1000S - NUMERO DO SINISTRO INVALIDO' TO SI1000S-ERRO-MENSAGEM */
                _.Move("SI1000S - NUMERO DO SINISTRO INVALIDO", LBSI1000.SI1000S_PARAMETROS.SI1000S_SAIDA.SI1000S_ERRO_MENSAGEM);

                /*" -134- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -139- IF SI1000S-NUM-APOL-SINISTRO EQUAL ZEROS AND SI1000S-COD-PRODUTO EQUAL ZEROS AND SI1000S-RAMO EQUAL ZEROS */

            if (LBSI1000.SI1000S_PARAMETROS.SI1000S_ENTRADA.SI1000S_NUM_APOL_SINISTRO == 00 && LBSI1000.SI1000S_PARAMETROS.SI1000S_ENTRADA.SI1000S_COD_PRODUTO == 00 && LBSI1000.SI1000S_PARAMETROS.SI1000S_ENTRADA.SI1000S_RAMO == 00)
            {

                /*" -141- MOVE 'SI1000S - INFORME O SINISTRO, PRODUTO OU RAMO' TO SI1000S-ERRO-MENSAGEM */
                _.Move("SI1000S - INFORME O SINISTRO, PRODUTO OU RAMO", LBSI1000.SI1000S_PARAMETROS.SI1000S_SAIDA.SI1000S_ERRO_MENSAGEM);

                /*" -143- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -145- IF SI1000S-NUM-APOL-SINISTRO NOT EQUAL ZEROS */

            if (LBSI1000.SI1000S_PARAMETROS.SI1000S_ENTRADA.SI1000S_NUM_APOL_SINISTRO != 00)
            {

                /*" -147- MOVE SI1000S-NUM-APOL-SINISTRO TO SINISMES-NUM-APOL-SINISTRO */
                _.Move(LBSI1000.SI1000S_PARAMETROS.SI1000S_ENTRADA.SI1000S_NUM_APOL_SINISTRO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO);

                /*" -148- PERFORM R0120-00-LE-SINISTRO-MESTRE */

                R0120_00_LE_SINISTRO_MESTRE_SECTION();

                /*" -149- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -151- MOVE 'SI1000S - NUMERO DO SINISTRO NAO CADASTRADO' TO SI1000S-ERRO-MENSAGEM */
                    _.Move("SI1000S - NUMERO DO SINISTRO NAO CADASTRADO", LBSI1000.SI1000S_PARAMETROS.SI1000S_SAIDA.SI1000S_ERRO_MENSAGEM);

                    /*" -152- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -153- END-IF */
                }


                /*" -154- ELSE */
            }
            else
            {


                /*" -156- IF SI1000S-COD-PRODUTO NOT EQUAL ZEROS */

                if (LBSI1000.SI1000S_PARAMETROS.SI1000S_ENTRADA.SI1000S_COD_PRODUTO != 00)
                {

                    /*" -158- MOVE SI1000S-COD-PRODUTO TO SINISHIS-COD-PRODUTO */
                    _.Move(LBSI1000.SI1000S_PARAMETROS.SI1000S_ENTRADA.SI1000S_COD_PRODUTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PRODUTO);

                    /*" -159- ELSE */
                }
                else
                {


                    /*" -163- MOVE SI1000S-RAMO TO SINISMES-RAMO. */
                    _.Move(LBSI1000.SI1000S_PARAMETROS.SI1000S_ENTRADA.SI1000S_RAMO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO);
                }

            }


            /*" -165- IF SI1000S-DATA-INICIO NOT EQUAL SPACES */

            if (!LBSI1000.SI1000S_PARAMETROS.SI1000S_ENTRADA.SI1000S_DATA_INICIO.IsEmpty())
            {

                /*" -167- MOVE SI1000S-DATA-INICIO TO CALENDAR-DATA-CALENDARIO */
                _.Move(LBSI1000.SI1000S_PARAMETROS.SI1000S_ENTRADA.SI1000S_DATA_INICIO, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);

                /*" -168- PERFORM R0130-00-LE-CALENDARIO */

                R0130_00_LE_CALENDARIO_SECTION();

                /*" -169- IF SQLCODE EQUAL -180 OR -181 */

                if (DB.SQLCODE.In("-180", "-181"))
                {

                    /*" -171- MOVE 'SI1000S - PERIODO INICIAL INVALIDO' TO SI1000S-ERRO-MENSAGEM */
                    _.Move("SI1000S - PERIODO INICIAL INVALIDO", LBSI1000.SI1000S_PARAMETROS.SI1000S_SAIDA.SI1000S_ERRO_MENSAGEM);

                    /*" -175- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -177- IF SI1000S-DATA-FIM NOT EQUAL SPACES */

            if (!LBSI1000.SI1000S_PARAMETROS.SI1000S_ENTRADA.SI1000S_DATA_FIM.IsEmpty())
            {

                /*" -178- MOVE SI1000S-DATA-FIM TO CALENDAR-DATA-CALENDARIO */
                _.Move(LBSI1000.SI1000S_PARAMETROS.SI1000S_ENTRADA.SI1000S_DATA_FIM, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);

                /*" -179- PERFORM R0130-00-LE-CALENDARIO */

                R0130_00_LE_CALENDARIO_SECTION();

                /*" -180- IF SQLCODE EQUAL -180 OR -181 */

                if (DB.SQLCODE.In("-180", "-181"))
                {

                    /*" -182- MOVE 'SI1000S - PERIODO FINAL INVALIDO' TO SI1000S-ERRO-MENSAGEM */
                    _.Move("SI1000S - PERIODO FINAL INVALIDO", LBSI1000.SI1000S_PARAMETROS.SI1000S_SAIDA.SI1000S_ERRO_MENSAGEM);

                    /*" -186- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -192- IF SI1000S-DATA-INICIO NOT EQUAL SPACES AND SI1000S-DATA-FIM NOT EQUAL SPACES AND SI1000S-DATA-INICIO GREATER SI1000S-DATA-FIM */

            if (!LBSI1000.SI1000S_PARAMETROS.SI1000S_ENTRADA.SI1000S_DATA_INICIO.IsEmpty() && !LBSI1000.SI1000S_PARAMETROS.SI1000S_ENTRADA.SI1000S_DATA_FIM.IsEmpty() && LBSI1000.SI1000S_PARAMETROS.SI1000S_ENTRADA.SI1000S_DATA_INICIO > LBSI1000.SI1000S_PARAMETROS.SI1000S_ENTRADA.SI1000S_DATA_FIM)
            {

                /*" -194- MOVE 'SI1000S - PERIODO INICIAL SUPERIOR AO FINAL' TO SI1000S-ERRO-MENSAGEM */
                _.Move("SI1000S - PERIODO INICIAL SUPERIOR AO FINAL", LBSI1000.SI1000S_PARAMETROS.SI1000S_SAIDA.SI1000S_ERRO_MENSAGEM);

                /*" -194- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_EXIT*/

        [StopWatch]
        /*" R0110-00-LE-GE-SISTEMA-FUNCAO-SECTION */
        private void R0110_00_LE_GE_SISTEMA_FUNCAO_SECTION()
        {
            /*" -203- MOVE '011' TO SI1000S-ERRO-PARAGRAFO */
            _.Move("011", LBSI1000.SI1000S_PARAMETROS.SI1000S_SAIDA.SI1000S_ERRO_PARAGRAFO);

            /*" -209- PERFORM R0110_00_LE_GE_SISTEMA_FUNCAO_DB_SELECT_1 */

            R0110_00_LE_GE_SISTEMA_FUNCAO_DB_SELECT_1();

            /*" -212- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -214- MOVE 'SI1000S - ERRO NO SELECT GE_SISTEMA_FUNCAO' TO SI1000S-ERRO-MENSAGEM */
                _.Move("SI1000S - ERRO NO SELECT GE_SISTEMA_FUNCAO", LBSI1000.SI1000S_PARAMETROS.SI1000S_SAIDA.SI1000S_ERRO_MENSAGEM);

                /*" -214- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0110-00-LE-GE-SISTEMA-FUNCAO-DB-SELECT-1 */
        public void R0110_00_LE_GE_SISTEMA_FUNCAO_DB_SELECT_1()
        {
            /*" -209- EXEC SQL SELECT NOM_FUNCAO INTO :GESISFUN-NOM-FUNCAO FROM SEGUROS.GE_SISTEMA_FUNCAO WHERE IDE_SISTEMA = :GESISFUN-IDE-SISTEMA AND COD_FUNCAO = :GESISFUN-COD-FUNCAO END-EXEC. */

            var r0110_00_LE_GE_SISTEMA_FUNCAO_DB_SELECT_1_Query1 = new R0110_00_LE_GE_SISTEMA_FUNCAO_DB_SELECT_1_Query1()
            {
                GESISFUN_IDE_SISTEMA = GESISFUN.DCLGE_SISTEMA_FUNCAO.GESISFUN_IDE_SISTEMA.ToString(),
                GESISFUN_COD_FUNCAO = GESISFUN.DCLGE_SISTEMA_FUNCAO.GESISFUN_COD_FUNCAO.ToString(),
            };

            var executed_1 = R0110_00_LE_GE_SISTEMA_FUNCAO_DB_SELECT_1_Query1.Execute(r0110_00_LE_GE_SISTEMA_FUNCAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GESISFUN_NOM_FUNCAO, GESISFUN.DCLGE_SISTEMA_FUNCAO.GESISFUN_NOM_FUNCAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0110_99_EXIT*/

        [StopWatch]
        /*" R0120-00-LE-SINISTRO-MESTRE-SECTION */
        private void R0120_00_LE_SINISTRO_MESTRE_SECTION()
        {
            /*" -223- MOVE '012' TO SI1000S-ERRO-PARAGRAFO */
            _.Move("012", LBSI1000.SI1000S_PARAMETROS.SI1000S_SAIDA.SI1000S_ERRO_PARAGRAFO);

            /*" -228- PERFORM R0120_00_LE_SINISTRO_MESTRE_DB_SELECT_1 */

            R0120_00_LE_SINISTRO_MESTRE_DB_SELECT_1();

            /*" -231- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -233- MOVE 'SI1000S - ERRO NO SELECT SINISTRO_MESTRE' TO SI1000S-ERRO-MENSAGEM */
                _.Move("SI1000S - ERRO NO SELECT SINISTRO_MESTRE", LBSI1000.SI1000S_PARAMETROS.SI1000S_SAIDA.SI1000S_ERRO_MENSAGEM);

                /*" -233- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0120-00-LE-SINISTRO-MESTRE-DB-SELECT-1 */
        public void R0120_00_LE_SINISTRO_MESTRE_DB_SELECT_1()
        {
            /*" -228- EXEC SQL SELECT NUM_APOL_SINISTRO INTO :SINISMES-NUM-APOL-SINISTRO FROM SEGUROS.SINISTRO_MESTRE WHERE NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO END-EXEC. */

            var r0120_00_LE_SINISTRO_MESTRE_DB_SELECT_1_Query1 = new R0120_00_LE_SINISTRO_MESTRE_DB_SELECT_1_Query1()
            {
                SINISMES_NUM_APOL_SINISTRO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R0120_00_LE_SINISTRO_MESTRE_DB_SELECT_1_Query1.Execute(r0120_00_LE_SINISTRO_MESTRE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISMES_NUM_APOL_SINISTRO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0120_99_EXIT*/

        [StopWatch]
        /*" R0130-00-LE-CALENDARIO-SECTION */
        private void R0130_00_LE_CALENDARIO_SECTION()
        {
            /*" -242- MOVE '013' TO SI1000S-ERRO-PARAGRAFO */
            _.Move("013", LBSI1000.SI1000S_PARAMETROS.SI1000S_SAIDA.SI1000S_ERRO_PARAGRAFO);

            /*" -247- PERFORM R0130_00_LE_CALENDARIO_DB_SELECT_1 */

            R0130_00_LE_CALENDARIO_DB_SELECT_1();

            /*" -251- IF SQLCODE NOT EQUAL ZEROS AND 100 AND -180 AND -181 */

            if (!DB.SQLCODE.In("00", "100", "-180", "-181"))
            {

                /*" -253- MOVE 'SI1000S - ERRO NO SELECT CALENDARIO' TO SI1000S-ERRO-MENSAGEM */
                _.Move("SI1000S - ERRO NO SELECT CALENDARIO", LBSI1000.SI1000S_PARAMETROS.SI1000S_SAIDA.SI1000S_ERRO_MENSAGEM);

                /*" -253- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0130-00-LE-CALENDARIO-DB-SELECT-1 */
        public void R0130_00_LE_CALENDARIO_DB_SELECT_1()
        {
            /*" -247- EXEC SQL SELECT DATA_CALENDARIO INTO :CALENDAR-DATA-CALENDARIO FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO = :CALENDAR-DATA-CALENDARIO END-EXEC. */

            var r0130_00_LE_CALENDARIO_DB_SELECT_1_Query1 = new R0130_00_LE_CALENDARIO_DB_SELECT_1_Query1()
            {
                CALENDAR_DATA_CALENDARIO = CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO.ToString(),
            };

            var executed_1 = R0130_00_LE_CALENDARIO_DB_SELECT_1_Query1.Execute(r0130_00_LE_CALENDARIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CALENDAR_DATA_CALENDARIO, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0130_99_EXIT*/

        [StopWatch]
        /*" R0200-00-CALCULA-VALOR-SECTION */
        private void R0200_00_CALCULA_VALOR_SECTION()
        {
            /*" -262- MOVE '020' TO SI1000S-ERRO-PARAGRAFO */
            _.Move("020", LBSI1000.SI1000S_PARAMETROS.SI1000S_SAIDA.SI1000S_ERRO_PARAGRAFO);

            /*" -265- MOVE SI1000S-IDE-SISTEMA-OPER TO GESISFUO-IDE-SISTEMA-OPER */
            _.Move(LBSI1000.SI1000S_PARAMETROS.SI1000S_ENTRADA.SI1000S_IDE_SISTEMA_OPER, GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_IDE_SISTEMA_OPER);

            /*" -267- IF SI1000S-DATA-INICIO EQUAL SPACES */

            if (LBSI1000.SI1000S_PARAMETROS.SI1000S_ENTRADA.SI1000S_DATA_INICIO.IsEmpty())
            {

                /*" -268- MOVE '0001-01-01' TO HOST-DATA-INICIO */
                _.Move("0001-01-01", HOST_DATA_INICIO);

                /*" -269- ELSE */
            }
            else
            {


                /*" -272- MOVE SI1000S-DATA-INICIO TO HOST-DATA-INICIO. */
                _.Move(LBSI1000.SI1000S_PARAMETROS.SI1000S_ENTRADA.SI1000S_DATA_INICIO, HOST_DATA_INICIO);
            }


            /*" -273- IF SI1000S-DATA-FIM EQUAL SPACES */

            if (LBSI1000.SI1000S_PARAMETROS.SI1000S_ENTRADA.SI1000S_DATA_FIM.IsEmpty())
            {

                /*" -274- MOVE '9999-12-31' TO HOST-DATA-FIM */
                _.Move("9999-12-31", HOST_DATA_FIM);

                /*" -275- ELSE */
            }
            else
            {


                /*" -279- MOVE SI1000S-DATA-FIM TO HOST-DATA-FIM. */
                _.Move(LBSI1000.SI1000S_PARAMETROS.SI1000S_ENTRADA.SI1000S_DATA_FIM, HOST_DATA_FIM);
            }


            /*" -281- IF SI1000S-NUM-APOL-SINISTRO NOT EQUAL ZEROS */

            if (LBSI1000.SI1000S_PARAMETROS.SI1000S_ENTRADA.SI1000S_NUM_APOL_SINISTRO != 00)
            {

                /*" -282- PERFORM R0300-00-SUM-FUNCAO-SINISTRO */

                R0300_00_SUM_FUNCAO_SINISTRO_SECTION();

                /*" -283- ELSE */
            }
            else
            {


                /*" -285- IF SI1000S-COD-PRODUTO NOT EQUAL ZEROS */

                if (LBSI1000.SI1000S_PARAMETROS.SI1000S_ENTRADA.SI1000S_COD_PRODUTO != 00)
                {

                    /*" -286- PERFORM R0400-00-SUM-FUNCAO-PRODUTO */

                    R0400_00_SUM_FUNCAO_PRODUTO_SECTION();

                    /*" -287- ELSE */
                }
                else
                {


                    /*" -289- PERFORM R0500-00-SUM-FUNCAO-RAMO. */

                    R0500_00_SUM_FUNCAO_RAMO_SECTION();
                }

            }


            /*" -290- MOVE SINISHIS-VAL-OPERACAO TO SI1000S-VALOR-CALCULADO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, LBSI1000.SI1000S_PARAMETROS.SI1000S_SAIDA.SI1000S_VALOR_CALCULADO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_EXIT*/

        [StopWatch]
        /*" R0300-00-SUM-FUNCAO-SINISTRO-SECTION */
        private void R0300_00_SUM_FUNCAO_SINISTRO_SECTION()
        {
            /*" -299- MOVE '030' TO SI1000S-ERRO-PARAGRAFO */
            _.Move("030", LBSI1000.SI1000S_PARAMETROS.SI1000S_SAIDA.SI1000S_ERRO_PARAGRAFO);

            /*" -313- PERFORM R0300_00_SUM_FUNCAO_SINISTRO_DB_SELECT_1 */

            R0300_00_SUM_FUNCAO_SINISTRO_DB_SELECT_1();

            /*" -316- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -318- MOVE 'SI1000S - ERRO NO SELECT SINISTRO_HISTORICO/GE_SIS_FUNCAO_OPER' TO SI1000S-ERRO-MENSAGEM */
                _.Move("SI1000S - ERRO NO SELECT SINISTRO_HISTORICO/GE_SIS_FUNCAO_OPER", LBSI1000.SI1000S_PARAMETROS.SI1000S_SAIDA.SI1000S_ERRO_MENSAGEM);

                /*" -318- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0300-00-SUM-FUNCAO-SINISTRO-DB-SELECT-1 */
        public void R0300_00_SUM_FUNCAO_SINISTRO_DB_SELECT_1()
        {
            /*" -313- EXEC SQL SELECT VALUE(SUM(A.VAL_OPERACAO * B.NUM_FATOR), 0) INTO :SINISHIS-VAL-OPERACAO FROM SEGUROS.SINISTRO_HISTORICO A, SEGUROS.GE_SIS_FUNCAO_OPER B WHERE A.NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO AND B.IDE_SISTEMA = :GESISFUN-IDE-SISTEMA AND B.COD_FUNCAO = :GESISFUN-COD-FUNCAO AND B.IDE_SISTEMA_OPER = :GESISFUO-IDE-SISTEMA-OPER AND B.TIPO_ENDOSSO = '9' AND A.DATA_MOVIMENTO >= :HOST-DATA-INICIO AND A.DATA_MOVIMENTO <= :HOST-DATA-FIM AND A.COD_OPERACAO = B.COD_OPERACAO END-EXEC. */

            var r0300_00_SUM_FUNCAO_SINISTRO_DB_SELECT_1_Query1 = new R0300_00_SUM_FUNCAO_SINISTRO_DB_SELECT_1_Query1()
            {
                SINISMES_NUM_APOL_SINISTRO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.ToString(),
                GESISFUO_IDE_SISTEMA_OPER = GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_IDE_SISTEMA_OPER.ToString(),
                GESISFUN_IDE_SISTEMA = GESISFUN.DCLGE_SISTEMA_FUNCAO.GESISFUN_IDE_SISTEMA.ToString(),
                GESISFUN_COD_FUNCAO = GESISFUN.DCLGE_SISTEMA_FUNCAO.GESISFUN_COD_FUNCAO.ToString(),
                HOST_DATA_INICIO = HOST_DATA_INICIO.ToString(),
                HOST_DATA_FIM = HOST_DATA_FIM.ToString(),
            };

            var executed_1 = R0300_00_SUM_FUNCAO_SINISTRO_DB_SELECT_1_Query1.Execute(r0300_00_SUM_FUNCAO_SINISTRO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISHIS_VAL_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_EXIT*/

        [StopWatch]
        /*" R0400-00-SUM-FUNCAO-PRODUTO-SECTION */
        private void R0400_00_SUM_FUNCAO_PRODUTO_SECTION()
        {
            /*" -327- MOVE '040' TO SI1000S-ERRO-PARAGRAFO */
            _.Move("040", LBSI1000.SI1000S_PARAMETROS.SI1000S_SAIDA.SI1000S_ERRO_PARAGRAFO);

            /*" -340- PERFORM R0400_00_SUM_FUNCAO_PRODUTO_DB_SELECT_1 */

            R0400_00_SUM_FUNCAO_PRODUTO_DB_SELECT_1();

            /*" -343- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -345- MOVE 'SI1000S - ERRO NO SELECT SINISTRO_HISTORICO/GE_SIS_FUNCAO_OPER' TO SI1000S-ERRO-MENSAGEM */
                _.Move("SI1000S - ERRO NO SELECT SINISTRO_HISTORICO/GE_SIS_FUNCAO_OPER", LBSI1000.SI1000S_PARAMETROS.SI1000S_SAIDA.SI1000S_ERRO_MENSAGEM);

                /*" -345- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0400-00-SUM-FUNCAO-PRODUTO-DB-SELECT-1 */
        public void R0400_00_SUM_FUNCAO_PRODUTO_DB_SELECT_1()
        {
            /*" -340- EXEC SQL SELECT VALUE(SUM(A.VAL_OPERACAO * B.NUM_FATOR), 0) INTO :SINISHIS-VAL-OPERACAO FROM SEGUROS.SINISTRO_HISTORICO A, SEGUROS.GE_SIS_FUNCAO_OPER B WHERE A.COD_PRODUTO = :SINISHIS-COD-PRODUTO AND B.IDE_SISTEMA = :GESISFUN-IDE-SISTEMA AND B.COD_FUNCAO = :GESISFUN-COD-FUNCAO AND B.IDE_SISTEMA_OPER = :GESISFUO-IDE-SISTEMA-OPER AND B.TIPO_ENDOSSO = '9' AND A.DATA_MOVIMENTO >= :HOST-DATA-INICIO AND A.DATA_MOVIMENTO <= :HOST-DATA-FIM AND A.COD_OPERACAO = B.COD_OPERACAO END-EXEC. */

            var r0400_00_SUM_FUNCAO_PRODUTO_DB_SELECT_1_Query1 = new R0400_00_SUM_FUNCAO_PRODUTO_DB_SELECT_1_Query1()
            {
                GESISFUO_IDE_SISTEMA_OPER = GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_IDE_SISTEMA_OPER.ToString(),
                SINISHIS_COD_PRODUTO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PRODUTO.ToString(),
                GESISFUN_IDE_SISTEMA = GESISFUN.DCLGE_SISTEMA_FUNCAO.GESISFUN_IDE_SISTEMA.ToString(),
                GESISFUN_COD_FUNCAO = GESISFUN.DCLGE_SISTEMA_FUNCAO.GESISFUN_COD_FUNCAO.ToString(),
                HOST_DATA_INICIO = HOST_DATA_INICIO.ToString(),
                HOST_DATA_FIM = HOST_DATA_FIM.ToString(),
            };

            var executed_1 = R0400_00_SUM_FUNCAO_PRODUTO_DB_SELECT_1_Query1.Execute(r0400_00_SUM_FUNCAO_PRODUTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISHIS_VAL_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_EXIT*/

        [StopWatch]
        /*" R0500-00-SUM-FUNCAO-RAMO-SECTION */
        private void R0500_00_SUM_FUNCAO_RAMO_SECTION()
        {
            /*" -354- MOVE '050' TO SI1000S-ERRO-PARAGRAFO */
            _.Move("050", LBSI1000.SI1000S_PARAMETROS.SI1000S_SAIDA.SI1000S_ERRO_PARAGRAFO);

            /*" -370- PERFORM R0500_00_SUM_FUNCAO_RAMO_DB_SELECT_1 */

            R0500_00_SUM_FUNCAO_RAMO_DB_SELECT_1();

            /*" -373- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -375- MOVE 'SI1000S - ERRO NO SELECT SINISTRO_HISTORICO/GE_SIS_FUNCAO_OPER' TO SI1000S-ERRO-MENSAGEM */
                _.Move("SI1000S - ERRO NO SELECT SINISTRO_HISTORICO/GE_SIS_FUNCAO_OPER", LBSI1000.SI1000S_PARAMETROS.SI1000S_SAIDA.SI1000S_ERRO_MENSAGEM);

                /*" -375- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0500-00-SUM-FUNCAO-RAMO-DB-SELECT-1 */
        public void R0500_00_SUM_FUNCAO_RAMO_DB_SELECT_1()
        {
            /*" -370- EXEC SQL SELECT VALUE(SUM(A.VAL_OPERACAO * B.NUM_FATOR), 0) INTO :SINISHIS-VAL-OPERACAO FROM SEGUROS.SINISTRO_HISTORICO A, SEGUROS.GE_SIS_FUNCAO_OPER B, SEGUROS.SINISTRO_MESTRE C WHERE C.RAMO = :SINISMES-RAMO AND B.IDE_SISTEMA = :GESISFUN-IDE-SISTEMA AND B.COD_FUNCAO = :GESISFUN-COD-FUNCAO AND B.IDE_SISTEMA_OPER = :GESISFUO-IDE-SISTEMA-OPER AND B.TIPO_ENDOSSO = '9' AND A.DATA_MOVIMENTO >= :HOST-DATA-INICIO AND A.DATA_MOVIMENTO <= :HOST-DATA-FIM AND A.COD_OPERACAO = B.COD_OPERACAO AND A.NUM_APOL_SINISTRO = C.NUM_APOL_SINISTRO END-EXEC. */

            var r0500_00_SUM_FUNCAO_RAMO_DB_SELECT_1_Query1 = new R0500_00_SUM_FUNCAO_RAMO_DB_SELECT_1_Query1()
            {
                GESISFUO_IDE_SISTEMA_OPER = GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_IDE_SISTEMA_OPER.ToString(),
                GESISFUN_IDE_SISTEMA = GESISFUN.DCLGE_SISTEMA_FUNCAO.GESISFUN_IDE_SISTEMA.ToString(),
                GESISFUN_COD_FUNCAO = GESISFUN.DCLGE_SISTEMA_FUNCAO.GESISFUN_COD_FUNCAO.ToString(),
                HOST_DATA_INICIO = HOST_DATA_INICIO.ToString(),
                SINISMES_RAMO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO.ToString(),
                HOST_DATA_FIM = HOST_DATA_FIM.ToString(),
            };

            var executed_1 = R0500_00_SUM_FUNCAO_RAMO_DB_SELECT_1_Query1.Execute(r0500_00_SUM_FUNCAO_RAMO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISHIS_VAL_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_EXIT*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -386- MOVE SQLCODE TO SI1000S-ERRO-SQLCODE */
            _.Move(DB.SQLCODE, LBSI1000.SI1000S_PARAMETROS.SI1000S_SAIDA.SI1000S_ERRO_SQLCODE);

            /*" -386- GOBACK. */

            throw new GoBack();

        }
    }
}