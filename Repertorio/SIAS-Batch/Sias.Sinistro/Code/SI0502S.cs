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
using Sias.Sinistro.DB2.SI0502S;

namespace Code
{
    public class SI0502S
    {
        public bool IsCall { get; set; }

        public SI0502S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SINISTRO                           *      */
        /*"      *   PROGRAMA ...............  SI0502S                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  PRODEXTER                          *      */
        /*"      *   PROGRAMADOR ............  PRODEXTER                          *      */
        /*"      *   DATA CODIFICACAO .......  JUNHO     / 2006                   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO..................  EFETUA AJUSTE DA RESERVA EM FUNCAO *      */
        /*"      *                             DA ALTERACAO DE RESERVA ON-LINE    *      */
        /*"      *                             (CIRCULAR 255)                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * NO   VERSAO    DATA       PROGRAMADOR           ALTERACAO      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 1.    1.0    01/06/2006   PRODEXTER                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 2.    2.0    08/09/2008   PATRICIA SALES       CADMUS 14169.   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 3.    3.0    09/06/2009   PATRIICA SALES       CADMUS 25387.   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 4.    4.0    21/10/2010   MARCELO NEVES         V.04           *      */
        /*"      *                                                                *      */
        /*"      *   CADIMUS 47494/2010 - CIRCULAR 395                            *      */
        /*"      *                                                                *      */
        /*"      *   SUPORTAR O NOVO RAMO DE COMERCIALIZA��O DO  HABITACIONAL,    *      */
        /*"      *   FORA DO SFH; SUPORTAR O NOVO RAMO DE COMERCIALIZA��O  DO     *      */
        /*"      *   SEGURO GARANTIA CONSTRUTOR - SETOR P�BLICO E  PRIVADO  E     *      */
        /*"      *   SUPORTAR NOVOS PRODUTOS QUE SER�O CRIADOS NO RAMO 48 DOS     *      */
        /*"      *   CONTRATOS DO CONS�RCIO.                                      *      */
        /*"      *                                                                *      */
        /*"      *   MARCELO NEVES (TE41729)   PROCURAR: V.04                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 5.    5.0    27/02/2012   RILDO SICO           CADMUS 67044.   *      */
        /*"      *       INCLUSAO DO PRODUTO 4808 PARA NAO LER A TABELA           *      */
        /*"      *       SINISTRO_CRED_INT.                                              */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 6.    6.0    09/04/2012   RILDO SICO           CADMUS 67044.   *      */
        /*"      *       INCLUSAO DO PRODUTO 4804 PARA NAO LER A TABELA           *      */
        /*"      *       SINISTRO_CRED_INT.                                              */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01     AREA-DE-WORK.*/
        public SI0502S_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SI0502S_AREA_DE_WORK();
        public class SI0502S_AREA_DE_WORK : VarBasis
        {
            /*"  05   WABEND.*/
            public SI0502S_WABEND WABEND { get; set; } = new SI0502S_WABEND();
            public class SI0502S_WABEND : VarBasis
            {
                /*"    10 WABEND1                       PIC  X(009)  VALUE                                                      'SI0502S '*/
                public StringBasis WABEND1 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"SI0502S ");
                /*"    10 WABEND2.*/
                public SI0502S_WABEND2 WABEND2 { get; set; } = new SI0502S_WABEND2();
                public class SI0502S_WABEND2 : VarBasis
                {
                    /*"      15 FILLER                      PIC  X(025)  VALUE                                     '*** ERRO EXEC SQL NUMERO '*/
                    public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"*** ERRO EXEC SQL NUMERO ");
                    /*"      15 WNR-EXEC-SQL                PIC  X(005)  VALUE SPACES.*/
                    public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                    /*"    10 WABEND3.*/
                }
                public SI0502S_WABEND3 WABEND3 { get; set; } = new SI0502S_WABEND3();
                public class SI0502S_WABEND3 : VarBasis
                {
                    /*"      15 FILLER                      PIC  X(013)  VALUE                                                 ' *** SQLCODE '*/
                    public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                    /*"      15 WSQLCODE                    PIC  -999.*/
                    public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "3", "-999."));
                    /*"01     HOST-VAL-PENDENTE             PIC S9(013)V99  COMP-3.*/
                }
            }
        }
        public DoubleBasis HOST_VAL_PENDENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01     LINK-PARAMETRO.*/
        public SI0502S_LINK_PARAMETRO LINK_PARAMETRO { get; set; } = new SI0502S_LINK_PARAMETRO();
        public class SI0502S_LINK_PARAMETRO : VarBasis
        {
            /*"  05   LINK-NUM-APOL-SINISTRO        PIC  9(013).*/
            public IntBasis LINK_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"  05   LINK-VAL-RESERVA-DESEJADA     PIC  9(013)V99.*/
            public DoubleBasis LINK_VAL_RESERVA_DESEJADA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"  05   LINK-MSG-ADICIONAL            PIC  X(080).*/
            public StringBasis LINK_MSG_ADICIONAL { get; set; } = new StringBasis(new PIC("X", "80", "X(080)."), @"");
            /*"  05   LINK-IND-ERRO                 PIC  X(003).*/
            public StringBasis LINK_IND_ERRO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"  05   LINK-MSG-ERRO                 PIC  X(080).*/
            public StringBasis LINK_MSG_ERRO { get; set; } = new StringBasis(new PIC("X", "80", "X(080)."), @"");
            /*"  05   LINK-SQLCODE                  PIC S9(004) COMP.*/
            public IntBasis LINK_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05   LINK-NOME-TABELA              PIC  X(030).*/
            public StringBasis LINK_NOME_TABELA { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.GESISFUO GESISFUO { get; set; } = new Dclgens.GESISFUO();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.SINIHAB1 SINIHAB1 { get; set; } = new Dclgens.SINIHAB1();
        public Dclgens.SINCREIN SINCREIN { get; set; } = new Dclgens.SINCREIN();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(SI0502S_LINK_PARAMETRO SI0502S_LINK_PARAMETRO_P) //PROCEDURE DIVISION USING 
        /*LINK_PARAMETRO*/
        {
            try
            {
                this.LINK_PARAMETRO = SI0502S_LINK_PARAMETRO_P;

                /*" -115- MOVE 'R0000' TO WNR-EXEC-SQL */
                _.Move("R0000", AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL);

                /*" -115- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -116- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -117- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -120- DISPLAY '----------------' */
                _.Display($"----------------");

                /*" -121- DISPLAY 'PROGRAMA COBOL2 ' */
                _.Display($"PROGRAMA COBOL2 ");

                /*" -123- DISPLAY '----------------' */
                _.Display($"----------------");

                /*" -125- PERFORM R0100-00-LE-SISTEMAS */

                R0100_00_LE_SISTEMAS_SECTION();

                /*" -127- PERFORM R0200-00-CONSISTE-PARAMETRO */

                R0200_00_CONSISTE_PARAMETRO_SECTION();

                /*" -129- PERFORM R1000-00-VERIFICA-AJUSTE */

                R1000_00_VERIFICA_AJUSTE_SECTION();

                /*" -132- MOVE ZEROS TO RETURN-CODE. */
                _.Move(0, RETURN_CODE);

                /*" -132- GOBACK. */

                throw new GoBack();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LINK_PARAMETRO, CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R0100-00-LE-SISTEMAS-SECTION */
        private void R0100_00_LE_SISTEMAS_SECTION()
        {
            /*" -140- MOVE 'R0100' TO WNR-EXEC-SQL */
            _.Move("R0100", AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL);

            /*" -147- PERFORM R0100_00_LE_SISTEMAS_DB_SELECT_1 */

            R0100_00_LE_SISTEMAS_DB_SELECT_1();

            /*" -150- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -151- DISPLAY 'ERRO NO SELECT SISTEMAS (SI)...' */
                _.Display($"ERRO NO SELECT SISTEMAS (SI)...");

                /*" -153- MOVE 'SI0502S - ERRO DE ACESSO SELECT' TO LINK-MSG-ERRO */
                _.Move("SI0502S - ERRO DE ACESSO SELECT", LINK_PARAMETRO.LINK_MSG_ERRO);

                /*" -154- MOVE 'SISTEMAS' TO LINK-NOME-TABELA */
                _.Move("SISTEMAS", LINK_PARAMETRO.LINK_NOME_TABELA);

                /*" -154- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0100-00-LE-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_LE_SISTEMAS_DB_SELECT_1()
        {
            /*" -147- EXEC SQL SELECT IDE_SISTEMA, DATA_MOV_ABERTO INTO :SISTEMAS-IDE-SISTEMA, :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' END-EXEC. */

            var r0100_00_LE_SISTEMAS_DB_SELECT_1_Query1 = new R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1.Execute(r0100_00_LE_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_IDE_SISTEMA, SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA);
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_EXIT*/

        [StopWatch]
        /*" R0200-00-CONSISTE-PARAMETRO-SECTION */
        private void R0200_00_CONSISTE_PARAMETRO_SECTION()
        {
            /*" -164- MOVE 'R0200' TO WNR-EXEC-SQL */
            _.Move("R0200", AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL);

            /*" -166- IF LINK-NUM-APOL-SINISTRO EQUAL 0 */

            if (LINK_PARAMETRO.LINK_NUM_APOL_SINISTRO == 0)
            {

                /*" -168- MOVE 'SI0502S - NUMERO DO SINISTRO NAO INFORMADO' TO LINK-MSG-ERRO */
                _.Move("SI0502S - NUMERO DO SINISTRO NAO INFORMADO", LINK_PARAMETRO.LINK_MSG_ERRO);

                /*" -168- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA_SECTION(); //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_EXIT*/

        [StopWatch]
        /*" R1000-00-VERIFICA-AJUSTE-SECTION */
        private void R1000_00_VERIFICA_AJUSTE_SECTION()
        {
            /*" -180- MOVE 'R1000' TO WNR-EXEC-SQL */
            _.Move("R1000", AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL);

            /*" -183- MOVE LINK-NUM-APOL-SINISTRO TO SINISHIS-NUM-APOL-SINISTRO */
            _.Move(LINK_PARAMETRO.LINK_NUM_APOL_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO);

            /*" -185- PERFORM R1100-00-LE-SINISTRO-MESTRE */

            R1100_00_LE_SINISTRO_MESTRE_SECTION();

            /*" -186- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -188- MOVE 'SI0502S - SINISTRO NAO AVISADO NA CAIXA SEGUROS' TO LINK-MSG-ERRO */
                _.Move("SI0502S - SINISTRO NAO AVISADO NA CAIXA SEGUROS", LINK_PARAMETRO.LINK_MSG_ERRO);

                /*" -215- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA_SECTION(); //GOTO
                return;
            }


            /*" -216- IF SINISMES-RAMO = 66 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO == 66)
            {

                /*" -219- MOVE 'SI0502S - NAO HA AJUSTE DE RESERVA PARA HABITACIONAL RAMO 66' TO LINK-MSG-ADICIONAL */
                _.Move("SI0502S - NAO HA AJUSTE DE RESERVA PARA HABITACIONAL RAMO 66", LINK_PARAMETRO.LINK_MSG_ADICIONAL);

                /*" -223- GO TO R1000-10-ENCERRA. */

                R1000_10_ENCERRA(); //GOTO
                return;
            }


            /*" -230- IF (SINISMES-RAMO = 48 OR 60 OR 70) AND (SINISMES-COD-PRODUTO NOT = 4801 AND 4812 AND 7001 AND 6008 AND 6009 AND 4814 AND 4813 AND 4808 AND 4804) */

            if ((SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO.In("48", "60", "70")) && (!SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO.In("4801", "4812", "7001", "6008", "6009", "4814", "4813", "4808", "4804")))
            {

                /*" -231- PERFORM R4000-00-TRAZ-OPERACAO-CRED */

                R4000_00_TRAZ_OPERACAO_CRED_SECTION();

                /*" -268- IF ( ( (SINISMES-COD-PRODUTO = 4800) AND (SINCREIN-COD-OPERACAO NOT = 105 AND 106 AND 149 AND 150 AND 650 AND 702 AND 704) ) OR ( (SINISMES-COD-PRODUTO = 4802) AND (SINCREIN-COD-OPERACAO NOT = 702 AND 704) ) OR ( (SINISMES-COD-PRODUTO = 4803) AND (SINCREIN-COD-OPERACAO NOT = 110) ) OR ( (SINISMES-COD-PRODUTO = 4807) AND (SINCREIN-COD-OPERACAO NOT = 107) ) OR ( (SINISMES-COD-PRODUTO = 4809) AND (SINCREIN-COD-OPERACAO NOT = 171 AND 173 AND 174) ) OR ( (SINISMES-COD-PRODUTO = 4810) AND (SINCREIN-COD-OPERACAO NOT = 731) ) OR ( (SINISMES-COD-PRODUTO = 6007) AND (SINCREIN-COD-OPERACAO NOT = 650 AND 690 AND 691 AND 702 AND 704 AND 731) ) OR ( (SINISMES-COD-PRODUTO = 7009) AND (SINCREIN-COD-OPERACAO NOT = 105 AND 106 AND 107 AND 110 AND 149 AND 150 AND 171 AND 173 AND 174 AND 190 AND 191 AND 690 AND 691) ) ) */

                if ((((SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO == 4800) && (!SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_OPERACAO.In("105", "106", "149", "150", "650", "702", "704"))) || ((SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO == 4802) && (!SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_OPERACAO.In("702", "704"))) || ((SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO == 4803) && (SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_OPERACAO != 110)) || ((SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO == 4807) && (SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_OPERACAO != 107)) || ((SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO == 4809) && (!SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_OPERACAO.In("171", "173", "174"))) || ((SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO == 4810) && (SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_OPERACAO != 731)) || ((SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO == 6007) && (!SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_OPERACAO.In("650", "690", "691", "702", "704", "731"))) || ((SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO == 7009) && (!SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_OPERACAO.In("105", "106", "107", "110", "149", "150", "171", "173", "174", "190", "191", "690", "691")))))
                {

                    /*" -271- MOVE 'SI0502S - NAO HA AJUSTE DE RESERVA PARA O PRODUTO E OPERACAO DO SINISTRO' TO LINK-MSG-ADICIONAL */
                    _.Move("SI0502S - NAO HA AJUSTE DE RESERVA PARA O PRODUTO E OPERACAO DO SINISTRO", LINK_PARAMETRO.LINK_MSG_ADICIONAL);

                    /*" -276- GO TO R1000-10-ENCERRA. */

                    R1000_10_ENCERRA(); //GOTO
                    return;
                }

            }


            /*" -278- IF SINISMES-RAMO EQUAL 31 OR 53 OR 20 OR 81 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO.In("31", "53", "20", "81"))
            {

                /*" -281- MOVE 'SI0502S - NAO HA AJUSTE DE RESERVA PARA RAMOS DEAUTOMOVEL' TO LINK-MSG-ADICIONAL */
                _.Move("SI0502S - NAO HA AJUSTE DE RESERVA PARA RAMOS DEAUTOMOVEL", LINK_PARAMETRO.LINK_MSG_ADICIONAL);

                /*" -285- GO TO R1000-10-ENCERRA. */

                R1000_10_ENCERRA(); //GOTO
                return;
            }


            /*" -286- IF SINISMES-COD-PRODUTO EQUAL 1803 OR 7105 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO.In("1803", "7105"))
            {

                /*" -288- MOVE 'SI0502S - NAO HA AJUSTE DE RESERVA PARA PRODUTO LOTERICO' TO LINK-MSG-ADICIONAL */
                _.Move("SI0502S - NAO HA AJUSTE DE RESERVA PARA PRODUTO LOTERICO", LINK_PARAMETRO.LINK_MSG_ADICIONAL);

                /*" -292- GO TO R1000-10-ENCERRA. */

                R1000_10_ENCERRA(); //GOTO
                return;
            }


            /*" -292- PERFORM R1200-00-EFETUA-AJUSTE. */

            R1200_00_EFETUA_AJUSTE_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R1000_10_ENCERRA */

            R1000_10_ENCERRA();

        }

        [StopWatch]
        /*" R1000-10-ENCERRA */
        private void R1000_10_ENCERRA(bool isPerform = false)
        {
            /*" -299- MOVE SPACES TO LINK-IND-ERRO LINK-MSG-ERRO. */
            _.Move("", LINK_PARAMETRO.LINK_IND_ERRO, LINK_PARAMETRO.LINK_MSG_ERRO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_EXIT*/

        [StopWatch]
        /*" R1100-00-LE-SINISTRO-MESTRE-SECTION */
        private void R1100_00_LE_SINISTRO_MESTRE_SECTION()
        {
            /*" -309- MOVE 'R1100' TO WNR-EXEC-SQL */
            _.Move("R1100", AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL);

            /*" -318- PERFORM R1100_00_LE_SINISTRO_MESTRE_DB_SELECT_1 */

            R1100_00_LE_SINISTRO_MESTRE_DB_SELECT_1();

            /*" -321- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -323- DISPLAY 'ERRO NO SELECT SINISTRO_MESTRE...' ' ' SINISHIS-NUM-APOL-SINISTRO */

                $"ERRO NO SELECT SINISTRO_MESTRE... {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}"
                .Display();

                /*" -325- MOVE 'SI0502S - ERRO DE ACESSO SELECT' TO LINK-MSG-ERRO */
                _.Move("SI0502S - ERRO DE ACESSO SELECT", LINK_PARAMETRO.LINK_MSG_ERRO);

                /*" -326- MOVE 'SINISMES' TO LINK-NOME-TABELA */
                _.Move("SINISMES", LINK_PARAMETRO.LINK_NOME_TABELA);

                /*" -326- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1100-00-LE-SINISTRO-MESTRE-DB-SELECT-1 */
        public void R1100_00_LE_SINISTRO_MESTRE_DB_SELECT_1()
        {
            /*" -318- EXEC SQL SELECT VALUE(RAMO, 0), VALUE(COD_PRODUTO, 0), OCORR_HISTORICO INTO :SINISMES-RAMO, :SINISMES-COD-PRODUTO, :SINISMES-OCORR-HISTORICO FROM SEGUROS.SINISTRO_MESTRE WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO END-EXEC. */

            var r1100_00_LE_SINISTRO_MESTRE_DB_SELECT_1_Query1 = new R1100_00_LE_SINISTRO_MESTRE_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R1100_00_LE_SINISTRO_MESTRE_DB_SELECT_1_Query1.Execute(r1100_00_LE_SINISTRO_MESTRE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISMES_RAMO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO);
                _.Move(executed_1.SINISMES_COD_PRODUTO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO);
                _.Move(executed_1.SINISMES_OCORR_HISTORICO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_OCORR_HISTORICO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_EXIT*/

        [StopWatch]
        /*" R1200-00-EFETUA-AJUSTE-SECTION */
        private void R1200_00_EFETUA_AJUSTE_SECTION()
        {
            /*" -336- MOVE 'R1200' TO WNR-EXEC-SQL */
            _.Move("R1200", AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL);

            /*" -338- MOVE 'AJUSTE RESERVA DE SINISTRO - USUARIO' TO SINISHIS-NOME-FAVORECIDO */
            _.Move("AJUSTE RESERVA DE SINISTRO - USUARIO", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO);

            /*" -339- MOVE 'SI0502S' TO SINISHIS-NOM-PROGRAMA */
            _.Move("SI0502S", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOM_PROGRAMA);

            /*" -340- MOVE '0' TO SINISHIS-SIT-REGISTRO */
            _.Move("0", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_REGISTRO);

            /*" -343- MOVE SISTEMAS-DATA-MOV-ABERTO TO SINISHIS-DATA-MOVIMENTO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO);

            /*" -344- ADD 1 TO SINISMES-OCORR-HISTORICO */
            SINISMES.DCLSINISTRO_MESTRE.SINISMES_OCORR_HISTORICO.Value = SINISMES.DCLSINISTRO_MESTRE.SINISMES_OCORR_HISTORICO + 1;

            /*" -347- MOVE SINISMES-OCORR-HISTORICO TO SINISHIS-OCORR-HISTORICO */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_OCORR_HISTORICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO);

            /*" -351- PERFORM R1210-00-ALTERA-SINISMES */

            R1210_00_ALTERA_SINISMES_SECTION();

            /*" -355- PERFORM R1220-00-LE-AVISO-SINISTRO */

            R1220_00_LE_AVISO_SINISTRO_SECTION();

            /*" -356- MOVE 27 TO GESISFUO-COD-FUNCAO */
            _.Move(27, GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_COD_FUNCAO);

            /*" -364- PERFORM R1230-00-LE-VALOR-PENDENTE */

            R1230_00_LE_VALOR_PENDENTE_SECTION();

            /*" -366- IF LINK-VAL-RESERVA-DESEJADA NOT GREATER HOST-VAL-PENDENTE */

            if (LINK_PARAMETRO.LINK_VAL_RESERVA_DESEJADA <= HOST_VAL_PENDENTE)
            {

                /*" -367- MOVE 131 TO SINISHIS-COD-OPERACAO */
                _.Move(131, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);

                /*" -369- COMPUTE SINISHIS-VAL-OPERACAO = HOST-VAL-PENDENTE - LINK-VAL-RESERVA-DESEJADA */
                SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO.Value = HOST_VAL_PENDENTE - LINK_PARAMETRO.LINK_VAL_RESERVA_DESEJADA;

                /*" -370- ELSE */
            }
            else
            {


                /*" -371- MOVE 130 TO SINISHIS-COD-OPERACAO */
                _.Move(130, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);

                /*" -374- COMPUTE SINISHIS-VAL-OPERACAO = LINK-VAL-RESERVA-DESEJADA - HOST-VAL-PENDENTE. */
                SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO.Value = LINK_PARAMETRO.LINK_VAL_RESERVA_DESEJADA - HOST_VAL_PENDENTE;
            }


            /*" -378- PERFORM R1240-00-INCLUI-SINISHIS */

            R1240_00_INCLUI_SINISHIS_SECTION();

            /*" -379- MOVE 28 TO GESISFUO-COD-FUNCAO */
            _.Move(28, GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_COD_FUNCAO);

            /*" -387- PERFORM R1230-00-LE-VALOR-PENDENTE */

            R1230_00_LE_VALOR_PENDENTE_SECTION();

            /*" -389- IF HOST-VAL-PENDENTE NOT LESS ZEROS */

            if (HOST_VAL_PENDENTE >= 00)
            {

                /*" -390- MOVE 133 TO SINISHIS-COD-OPERACAO */
                _.Move(133, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);

                /*" -391- MOVE HOST-VAL-PENDENTE TO SINISHIS-VAL-OPERACAO */
                _.Move(HOST_VAL_PENDENTE, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);

                /*" -392- ELSE */
            }
            else
            {


                /*" -393- MOVE 132 TO SINISHIS-COD-OPERACAO */
                _.Move(132, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);

                /*" -396- COMPUTE SINISHIS-VAL-OPERACAO = HOST-VAL-PENDENTE * -1. */
                SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO.Value = HOST_VAL_PENDENTE * -1;
            }


            /*" -400- PERFORM R1240-00-INCLUI-SINISHIS */

            R1240_00_INCLUI_SINISHIS_SECTION();

            /*" -401- MOVE 29 TO GESISFUO-COD-FUNCAO */
            _.Move(29, GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_COD_FUNCAO);

            /*" -409- PERFORM R1230-00-LE-VALOR-PENDENTE */

            R1230_00_LE_VALOR_PENDENTE_SECTION();

            /*" -411- IF HOST-VAL-PENDENTE NOT LESS ZEROS */

            if (HOST_VAL_PENDENTE >= 00)
            {

                /*" -412- MOVE 135 TO SINISHIS-COD-OPERACAO */
                _.Move(135, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);

                /*" -413- MOVE HOST-VAL-PENDENTE TO SINISHIS-VAL-OPERACAO */
                _.Move(HOST_VAL_PENDENTE, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);

                /*" -414- ELSE */
            }
            else
            {


                /*" -415- MOVE 134 TO SINISHIS-COD-OPERACAO */
                _.Move(134, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);

                /*" -418- COMPUTE SINISHIS-VAL-OPERACAO = HOST-VAL-PENDENTE * -1. */
                SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO.Value = HOST_VAL_PENDENTE * -1;
            }


            /*" -418- PERFORM R1240-00-INCLUI-SINISHIS. */

            R1240_00_INCLUI_SINISHIS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_EXIT*/

        [StopWatch]
        /*" R1210-00-ALTERA-SINISMES-SECTION */
        private void R1210_00_ALTERA_SINISMES_SECTION()
        {
            /*" -428- MOVE 'R1210' TO WNR-EXEC-SQL */
            _.Move("R1210", AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL);

            /*" -432- PERFORM R1210_00_ALTERA_SINISMES_DB_UPDATE_1 */

            R1210_00_ALTERA_SINISMES_DB_UPDATE_1();

            /*" -435- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -438- DISPLAY 'ERRO NO UPDATE SINISTRO_MESTRE...' ' ' SINISHIS-NUM-APOL-SINISTRO ' ' SINISMES-OCORR-HISTORICO */

                $"ERRO NO UPDATE SINISTRO_MESTRE... {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO} {SINISMES.DCLSINISTRO_MESTRE.SINISMES_OCORR_HISTORICO}"
                .Display();

                /*" -440- MOVE 'SI0502S - ERRO DE ACESSO UPDATE' TO LINK-MSG-ERRO */
                _.Move("SI0502S - ERRO DE ACESSO UPDATE", LINK_PARAMETRO.LINK_MSG_ERRO);

                /*" -441- MOVE 'SINISMES' TO LINK-NOME-TABELA */
                _.Move("SINISMES", LINK_PARAMETRO.LINK_NOME_TABELA);

                /*" -441- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1210-00-ALTERA-SINISMES-DB-UPDATE-1 */
        public void R1210_00_ALTERA_SINISMES_DB_UPDATE_1()
        {
            /*" -432- EXEC SQL UPDATE SEGUROS.SINISTRO_MESTRE SET OCORR_HISTORICO = :SINISMES-OCORR-HISTORICO WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO END-EXEC. */

            var r1210_00_ALTERA_SINISMES_DB_UPDATE_1_Update1 = new R1210_00_ALTERA_SINISMES_DB_UPDATE_1_Update1()
            {
                SINISMES_OCORR_HISTORICO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_OCORR_HISTORICO.ToString(),
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            R1210_00_ALTERA_SINISMES_DB_UPDATE_1_Update1.Execute(r1210_00_ALTERA_SINISMES_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1210_99_EXIT*/

        [StopWatch]
        /*" R1220-00-LE-AVISO-SINISTRO-SECTION */
        private void R1220_00_LE_AVISO_SINISTRO_SECTION()
        {
            /*" -451- MOVE 'R1220' TO WNR-EXEC-SQL */
            _.Move("R1220", AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL);

            /*" -486- PERFORM R1220_00_LE_AVISO_SINISTRO_DB_SELECT_1 */

            R1220_00_LE_AVISO_SINISTRO_DB_SELECT_1();

            /*" -489- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -491- DISPLAY 'ERRO NO SELECT SINISTRO_HISTORICO (AVISO)...' ' ' SINISHIS-NUM-APOL-SINISTRO */

                $"ERRO NO SELECT SINISTRO_HISTORICO (AVISO)... {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}"
                .Display();

                /*" -493- MOVE 'SI0502S - ERRO DE ACESSO SELECT' TO LINK-MSG-ERRO */
                _.Move("SI0502S - ERRO DE ACESSO SELECT", LINK_PARAMETRO.LINK_MSG_ERRO);

                /*" -494- MOVE 'SINISHIS' TO LINK-NOME-TABELA */
                _.Move("SINISHIS", LINK_PARAMETRO.LINK_NOME_TABELA);

                /*" -494- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1220-00-LE-AVISO-SINISTRO-DB-SELECT-1 */
        public void R1220_00_LE_AVISO_SINISTRO_DB_SELECT_1()
        {
            /*" -486- EXEC SQL SELECT COD_EMPRESA, TIPO_REGISTRO, DATA_LIM_CORRECAO, TIPO_FAVORECIDO, DATA_NEGOCIADA, FONTE_PAGAMENTO, COD_PREST_SERVICO, COD_SERVICO, ORDEM_PAGAMENTO, NUM_RECIBO, NUM_MOV_SINISTRO, COD_USUARIO, SIT_CONTABIL, NUM_APOLICE, COD_PRODUTO INTO :SINISHIS-COD-EMPRESA, :SINISHIS-TIPO-REGISTRO, :SINISHIS-DATA-LIM-CORRECAO, :SINISHIS-TIPO-FAVORECIDO, :SINISHIS-DATA-NEGOCIADA, :SINISHIS-FONTE-PAGAMENTO, :SINISHIS-COD-PREST-SERVICO, :SINISHIS-COD-SERVICO, :SINISHIS-ORDEM-PAGAMENTO, :SINISHIS-NUM-RECIBO, :SINISHIS-NUM-MOV-SINISTRO, :SINISHIS-COD-USUARIO, :SINISHIS-SIT-CONTABIL, :SINISHIS-NUM-APOLICE, :SINISHIS-COD-PRODUTO FROM SEGUROS.SINISTRO_HISTORICO WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND OCORR_HISTORICO = 1 AND COD_OPERACAO = 101 END-EXEC. */

            var r1220_00_LE_AVISO_SINISTRO_DB_SELECT_1_Query1 = new R1220_00_LE_AVISO_SINISTRO_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R1220_00_LE_AVISO_SINISTRO_DB_SELECT_1_Query1.Execute(r1220_00_LE_AVISO_SINISTRO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISHIS_COD_EMPRESA, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_EMPRESA);
                _.Move(executed_1.SINISHIS_TIPO_REGISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_TIPO_REGISTRO);
                _.Move(executed_1.SINISHIS_DATA_LIM_CORRECAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_LIM_CORRECAO);
                _.Move(executed_1.SINISHIS_TIPO_FAVORECIDO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_TIPO_FAVORECIDO);
                _.Move(executed_1.SINISHIS_DATA_NEGOCIADA, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_NEGOCIADA);
                _.Move(executed_1.SINISHIS_FONTE_PAGAMENTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_FONTE_PAGAMENTO);
                _.Move(executed_1.SINISHIS_COD_PREST_SERVICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO);
                _.Move(executed_1.SINISHIS_COD_SERVICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_SERVICO);
                _.Move(executed_1.SINISHIS_ORDEM_PAGAMENTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_ORDEM_PAGAMENTO);
                _.Move(executed_1.SINISHIS_NUM_RECIBO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_RECIBO);
                _.Move(executed_1.SINISHIS_NUM_MOV_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_MOV_SINISTRO);
                _.Move(executed_1.SINISHIS_COD_USUARIO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_USUARIO);
                _.Move(executed_1.SINISHIS_SIT_CONTABIL, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL);
                _.Move(executed_1.SINISHIS_NUM_APOLICE, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOLICE);
                _.Move(executed_1.SINISHIS_COD_PRODUTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1220_99_EXIT*/

        [StopWatch]
        /*" R1230-00-LE-VALOR-PENDENTE-SECTION */
        private void R1230_00_LE_VALOR_PENDENTE_SECTION()
        {
            /*" -504- MOVE 'R1230' TO WNR-EXEC-SQL */
            _.Move("R1230", AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL);

            /*" -515- PERFORM R1230_00_LE_VALOR_PENDENTE_DB_SELECT_1 */

            R1230_00_LE_VALOR_PENDENTE_DB_SELECT_1();

            /*" -518- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -523- DISPLAY 'ERRO NO SELECT SINIHIS/GESISFUO...' ' ' SINISHIS-NUM-APOL-SINISTRO ' ' SISTEMAS-DATA-MOV-ABERTO ' ' SISTEMAS-IDE-SISTEMA ' ' GESISFUO-COD-FUNCAO */

                $"ERRO NO SELECT SINIHIS/GESISFUO... {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO} {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO} {SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA} {GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_COD_FUNCAO}"
                .Display();

                /*" -525- MOVE 'SI0502S - ERRO DE ACESSO SELECT' TO LINK-MSG-ERRO */
                _.Move("SI0502S - ERRO DE ACESSO SELECT", LINK_PARAMETRO.LINK_MSG_ERRO);

                /*" -526- MOVE 'SINISHIS/GESISFUO' TO LINK-NOME-TABELA */
                _.Move("SINISHIS/GESISFUO", LINK_PARAMETRO.LINK_NOME_TABELA);

                /*" -526- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1230-00-LE-VALOR-PENDENTE-DB-SELECT-1 */
        public void R1230_00_LE_VALOR_PENDENTE_DB_SELECT_1()
        {
            /*" -515- EXEC SQL SELECT VALUE(SUM(H.VAL_OPERACAO * O.NUM_FATOR), 0) INTO :HOST-VAL-PENDENTE FROM SEGUROS.SINISTRO_HISTORICO H, SEGUROS.GE_SIS_FUNCAO_OPER O WHERE H.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND H.DATA_MOVIMENTO <= :SISTEMAS-DATA-MOV-ABERTO AND O.IDE_SISTEMA = :SISTEMAS-IDE-SISTEMA AND O.COD_FUNCAO = :GESISFUO-COD-FUNCAO AND O.IDE_SISTEMA = O.IDE_SISTEMA_OPER AND O.COD_OPERACAO = H.COD_OPERACAO END-EXEC. */

            var r1230_00_LE_VALOR_PENDENTE_DB_SELECT_1_Query1 = new R1230_00_LE_VALOR_PENDENTE_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                SISTEMAS_IDE_SISTEMA = SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA.ToString(),
                GESISFUO_COD_FUNCAO = GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_COD_FUNCAO.ToString(),
            };

            var executed_1 = R1230_00_LE_VALOR_PENDENTE_DB_SELECT_1_Query1.Execute(r1230_00_LE_VALOR_PENDENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_VAL_PENDENTE, HOST_VAL_PENDENTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1230_99_EXIT*/

        [StopWatch]
        /*" R1240-00-INCLUI-SINISHIS-SECTION */
        private void R1240_00_INCLUI_SINISHIS_SECTION()
        {
            /*" -536- MOVE 'R1240' TO WNR-EXEC-SQL */
            _.Move("R1240", AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL);

            /*" -588- PERFORM R1240_00_INCLUI_SINISHIS_DB_INSERT_1 */

            R1240_00_INCLUI_SINISHIS_DB_INSERT_1();

            /*" -591- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -595- DISPLAY 'ERRO NO INSERT SINISTRO_HISTORICO...' ' ' SINISHIS-NUM-APOL-SINISTRO ' ' SINISHIS-OCORR-HISTORICO ' ' SINISHIS-COD-OPERACAO */

                $"ERRO NO INSERT SINISTRO_HISTORICO... {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO}"
                .Display();

                /*" -597- MOVE 'SI0502S - ERRO DE ACESSO INSERT' TO LINK-MSG-ERRO */
                _.Move("SI0502S - ERRO DE ACESSO INSERT", LINK_PARAMETRO.LINK_MSG_ERRO);

                /*" -598- MOVE 'SINISHIS' TO LINK-NOME-TABELA */
                _.Move("SINISHIS", LINK_PARAMETRO.LINK_NOME_TABELA);

                /*" -598- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1240-00-INCLUI-SINISHIS-DB-INSERT-1 */
        public void R1240_00_INCLUI_SINISHIS_DB_INSERT_1()
        {
            /*" -588- EXEC SQL INSERT INTO SEGUROS.SINISTRO_HISTORICO (COD_EMPRESA, TIPO_REGISTRO, NUM_APOL_SINISTRO, OCORR_HISTORICO, COD_OPERACAO, DATA_MOVIMENTO, HORA_OPERACAO, NOME_FAVORECIDO, VAL_OPERACAO, DATA_LIM_CORRECAO, TIPO_FAVORECIDO, DATA_NEGOCIADA, FONTE_PAGAMENTO, COD_PREST_SERVICO, COD_SERVICO, ORDEM_PAGAMENTO, NUM_RECIBO, NUM_MOV_SINISTRO, COD_USUARIO, SIT_CONTABIL, SIT_REGISTRO, TIMESTAMP, NUM_APOLICE, COD_PRODUTO, NOM_PROGRAMA) VALUES (:SINISHIS-COD-EMPRESA, :SINISHIS-TIPO-REGISTRO, :SINISHIS-NUM-APOL-SINISTRO, :SINISHIS-OCORR-HISTORICO, :SINISHIS-COD-OPERACAO, :SINISHIS-DATA-MOVIMENTO, CURRENT TIME, :SINISHIS-NOME-FAVORECIDO, :SINISHIS-VAL-OPERACAO, :SINISHIS-DATA-LIM-CORRECAO, :SINISHIS-TIPO-FAVORECIDO, :SINISHIS-DATA-NEGOCIADA, :SINISHIS-FONTE-PAGAMENTO, :SINISHIS-COD-PREST-SERVICO, :SINISHIS-COD-SERVICO, :SINISHIS-ORDEM-PAGAMENTO, :SINISHIS-NUM-RECIBO, :SINISHIS-NUM-MOV-SINISTRO, :SINISHIS-COD-USUARIO, :SINISHIS-SIT-CONTABIL, :SINISHIS-SIT-REGISTRO, CURRENT TIMESTAMP, :SINISHIS-NUM-APOLICE, :SINISHIS-COD-PRODUTO, :SINISHIS-NOM-PROGRAMA) END-EXEC. */

            var r1240_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1 = new R1240_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1()
            {
                SINISHIS_COD_EMPRESA = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_EMPRESA.ToString(),
                SINISHIS_TIPO_REGISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_TIPO_REGISTRO.ToString(),
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
                SINISHIS_COD_OPERACAO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.ToString(),
                SINISHIS_DATA_MOVIMENTO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO.ToString(),
                SINISHIS_NOME_FAVORECIDO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO.ToString(),
                SINISHIS_VAL_OPERACAO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO.ToString(),
                SINISHIS_DATA_LIM_CORRECAO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_LIM_CORRECAO.ToString(),
                SINISHIS_TIPO_FAVORECIDO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_TIPO_FAVORECIDO.ToString(),
                SINISHIS_DATA_NEGOCIADA = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_NEGOCIADA.ToString(),
                SINISHIS_FONTE_PAGAMENTO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_FONTE_PAGAMENTO.ToString(),
                SINISHIS_COD_PREST_SERVICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO.ToString(),
                SINISHIS_COD_SERVICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_SERVICO.ToString(),
                SINISHIS_ORDEM_PAGAMENTO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_ORDEM_PAGAMENTO.ToString(),
                SINISHIS_NUM_RECIBO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_RECIBO.ToString(),
                SINISHIS_NUM_MOV_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_MOV_SINISTRO.ToString(),
                SINISHIS_COD_USUARIO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_USUARIO.ToString(),
                SINISHIS_SIT_CONTABIL = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL.ToString(),
                SINISHIS_SIT_REGISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_REGISTRO.ToString(),
                SINISHIS_NUM_APOLICE = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOLICE.ToString(),
                SINISHIS_COD_PRODUTO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PRODUTO.ToString(),
                SINISHIS_NOM_PROGRAMA = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOM_PROGRAMA.ToString(),
            };

            R1240_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1.Execute(r1240_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1240_99_EXIT*/

        [StopWatch]
        /*" R3000-00-TRAZ-COBER-RAMO68-SECTION */
        private void R3000_00_TRAZ_COBER_RAMO68_SECTION()
        {
            /*" -608- MOVE 'R3000' TO WNR-EXEC-SQL */
            _.Move("R3000", AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL);

            /*" -613- PERFORM R3000_00_TRAZ_COBER_RAMO68_DB_SELECT_1 */

            R3000_00_TRAZ_COBER_RAMO68_DB_SELECT_1();

            /*" -616- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -618- DISPLAY 'ERRO NO SELECT SINISTRO_HABIT01....' ' ' SINISHIS-NUM-APOL-SINISTRO */

                $"ERRO NO SELECT SINISTRO_HABIT01.... {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}"
                .Display();

                /*" -620- MOVE 'SI0502S - ERRO DE ACESSO NA SINIHAB1' TO LINK-MSG-ERRO */
                _.Move("SI0502S - ERRO DE ACESSO NA SINIHAB1", LINK_PARAMETRO.LINK_MSG_ERRO);

                /*" -621- MOVE 'SINISTRO-HABIT01' TO LINK-NOME-TABELA */
                _.Move("SINISTRO-HABIT01", LINK_PARAMETRO.LINK_NOME_TABELA);

                /*" -621- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3000-00-TRAZ-COBER-RAMO68-DB-SELECT-1 */
        public void R3000_00_TRAZ_COBER_RAMO68_DB_SELECT_1()
        {
            /*" -613- EXEC SQL SELECT COD_COBERTURA INTO :SINIHAB1-COD-COBERTURA FROM SEGUROS.SINISTRO_HABIT01 WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO END-EXEC. */

            var r3000_00_TRAZ_COBER_RAMO68_DB_SELECT_1_Query1 = new R3000_00_TRAZ_COBER_RAMO68_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R3000_00_TRAZ_COBER_RAMO68_DB_SELECT_1_Query1.Execute(r3000_00_TRAZ_COBER_RAMO68_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINIHAB1_COD_COBERTURA, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_COD_COBERTURA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_EXIT*/

        [StopWatch]
        /*" R4000-00-TRAZ-OPERACAO-CRED-SECTION */
        private void R4000_00_TRAZ_OPERACAO_CRED_SECTION()
        {
            /*" -631- MOVE 'R4000' TO WNR-EXEC-SQL */
            _.Move("R4000", AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL);

            /*" -636- PERFORM R4000_00_TRAZ_OPERACAO_CRED_DB_SELECT_1 */

            R4000_00_TRAZ_OPERACAO_CRED_DB_SELECT_1();

            /*" -639- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -641- DISPLAY 'ERRO NO SELECT SINISTRO_CRED_INT....' ' ' SINISHIS-NUM-APOL-SINISTRO */

                $"ERRO NO SELECT SINISTRO_CRED_INT.... {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}"
                .Display();

                /*" -643- MOVE 'SI0502S - ERRO DE ACESSO NA SINCREIN' TO LINK-MSG-ERRO */
                _.Move("SI0502S - ERRO DE ACESSO NA SINCREIN", LINK_PARAMETRO.LINK_MSG_ERRO);

                /*" -644- MOVE 'SINISTRO-CRED-INT' TO LINK-NOME-TABELA */
                _.Move("SINISTRO-CRED-INT", LINK_PARAMETRO.LINK_NOME_TABELA);

                /*" -644- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4000-00-TRAZ-OPERACAO-CRED-DB-SELECT-1 */
        public void R4000_00_TRAZ_OPERACAO_CRED_DB_SELECT_1()
        {
            /*" -636- EXEC SQL SELECT COD_OPERACAO INTO :SINCREIN-COD-OPERACAO FROM SEGUROS.SINISTRO_CRED_INT WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO END-EXEC. */

            var r4000_00_TRAZ_OPERACAO_CRED_DB_SELECT_1_Query1 = new R4000_00_TRAZ_OPERACAO_CRED_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R4000_00_TRAZ_OPERACAO_CRED_DB_SELECT_1_Query1.Execute(r4000_00_TRAZ_OPERACAO_CRED_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINCREIN_COD_OPERACAO, SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_OPERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_EXIT*/

        [StopWatch]
        /*" R9999-00-CANCELA-PROGRAMA-SECTION */
        private void R9999_00_CANCELA_PROGRAMA_SECTION()
        {
            /*" -653- MOVE 'SIM' TO LINK-IND-ERRO */
            _.Move("SIM", LINK_PARAMETRO.LINK_IND_ERRO);

            /*" -656- MOVE SQLCODE TO LINK-SQLCODE WSQLCODE */
            _.Move(DB.SQLCODE, LINK_PARAMETRO.LINK_SQLCODE, AREA_DE_WORK.WABEND.WABEND3.WSQLCODE);

            /*" -657- DISPLAY ' ' */
            _.Display($" ");

            /*" -658- DISPLAY '=====  PROGRAMA ABENDADO  =====' */
            _.Display($"=====  PROGRAMA ABENDADO  =====");

            /*" -659- DISPLAY ' ' */
            _.Display($" ");

            /*" -660- DISPLAY WABEND1. */
            _.Display(AREA_DE_WORK.WABEND.WABEND1);

            /*" -661- DISPLAY WABEND2. */
            _.Display(AREA_DE_WORK.WABEND.WABEND2);

            /*" -663- DISPLAY WABEND3. */
            _.Display(AREA_DE_WORK.WABEND.WABEND3);

            /*" -663- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -668- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -668- GOBACK. */

            throw new GoBack();

        }
    }
}