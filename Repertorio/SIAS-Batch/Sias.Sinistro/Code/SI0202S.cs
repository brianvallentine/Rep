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
using Sias.Sinistro.DB2.SI0202S;

namespace Code
{
    public class SI0202S
    {
        public bool IsCall { get; set; }

        public SI0202S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *==============================================================*        */
        /*"      *--------------------------------------------------------------*        */
        /*"      *   SISTEMA ................  SINISTRO / RESSARCIMENTO         *        */
        /*"      *   PROGRAMA ...............  SI0202S                          *        */
        /*"      *   ANALISTA ...............  POLITEC                          *        */
        /*"      *   PROGRAMADOR ............  POLITEC                          *        */
        /*"      *   DATA CODIFICACAO .......  09/02/2009                       *        */
        /*"      *--------------------------------------------------------------*        */
        /*"      *   FUNCAO .................  OBTER ENDERECO DO DEVEDOR NAS    *        */
        /*"      *                             BASES DE DADOS DO EF             *        */
        /*"      *                             E DO HABITACIONAL                *        */
        /*"      *--------------------------------------------------------------*        */
        /*"      *   M A N U T E N C A O - O R D E M  D E C R E S C E N T E     *        */
        /*"      *--------------------------------------------------------------*        */
        /*"V.01  * DD/MM/AAAA - EMPRESA - PROCURAR POR V.01                     *        */
        /*"      *            - ATENDIMENTO A SSI ?????/????                    *        */
        /*"      *            - DESCRICAO                                       *        */
        /*"      *                                                              *        */
        /*"      *--------------------------------------------------------------*        */
        /*"      *==============================================================*        */
        #endregion


        #region VARIABLES

        /*"77  W-EF083-ENDERECO          PIC X(081) VALUE SPACE.*/
        public StringBasis W_EF083_ENDERECO { get; set; } = new StringBasis(new PIC("X", "81", "X(081)"), @"");
        /*"77  W-GEPESEND-ENDERECO       PIC X(092) VALUE SPACE.*/
        public StringBasis W_GEPESEND_ENDERECO { get; set; } = new StringBasis(new PIC("X", "92", "X(092)"), @"");
        /*"77  W-ENDHABIT-ENDERECO       PIC X(061) VALUE SPACE.*/
        public StringBasis W_ENDHABIT_ENDERECO { get; set; } = new StringBasis(new PIC("X", "61", "X(061)"), @"");
        /*"77  W-ENDERECO-ORIG-TEXT      PIC X(092) VALUE SPACE.*/
        public StringBasis W_ENDERECO_ORIG_TEXT { get; set; } = new StringBasis(new PIC("X", "92", "X(092)"), @"");
        /*"77  W-ENDERECO-ORIG-LEN       PIC 9(002) VALUE 1.*/
        public IntBasis W_ENDERECO_ORIG_LEN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 1);
        /*"77  W-ENDERECO-TRIM-TEXT      PIC X(092) VALUE SPACE.*/
        public StringBasis W_ENDERECO_TRIM_TEXT { get; set; } = new StringBasis(new PIC("X", "92", "X(092)"), @"");
        /*"77  W-ENDERECO-TRIM-LEN       PIC 9(002) VALUE 1.*/
        public IntBasis W_ENDERECO_TRIM_LEN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 1);
        /*"77  W-NU-POS-INI              PIC 9(002) VALUE 1.*/
        public IntBasis W_NU_POS_INI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 1);
        /*"77  W-DE-ENTRADA              PIC X(080) VALUE SPACE.*/
        public StringBasis W_DE_ENTRADA { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"");
        /*"77  W-NUM-CEP                 PIC X(010) VALUE SPACE.*/
        public StringBasis W_NUM_CEP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77  W-POS                     PIC 9(002) VALUE 1.*/
        public IntBasis W_POS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 1);
        /*"77  W-POS1                    PIC 9(002) VALUE 1.*/
        public IntBasis W_POS1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 1);
        /*"77  W-I-CEP1                  PIC 9(002) VALUE 1.*/
        public IntBasis W_I_CEP1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 1);
        /*"77  W-I-CEP2                  PIC 9(002) VALUE 1.*/
        public IntBasis W_I_CEP2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 1);
        /*"77  W-IND-SPACE               PIC X(003) VALUE 'NAO'.*/
        public StringBasis W_IND_SPACE { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
        /*"01  W-DISPLAY.*/
        public SI0202S_W_DISPLAY W_DISPLAY { get; set; } = new SI0202S_W_DISPLAY();
        public class SI0202S_W_DISPLAY : VarBasis
        {
            /*"    03 W-DI-NUM-APOL-SINISTRO PIC 9(013) VALUE ZERO.*/
            public IntBasis W_DI_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"01  W-CONTRATO.*/
        }
        public SI0202S_W_CONTRATO W_CONTRATO { get; set; } = new SI0202S_W_CONTRATO();
        public class SI0202S_W_CONTRATO : VarBasis
        {
            /*"    03 W-NUM-OPERACAO         PIC 9(3).*/
            public IntBasis W_NUM_OPERACAO { get; set; } = new IntBasis(new PIC("9", "3", "9(3)."));
            /*"    03 W-NUM-PV               PIC 9(4).*/
            public IntBasis W_NUM_PV { get; set; } = new IntBasis(new PIC("9", "4", "9(4)."));
            /*"    03 W-NUM-CNTRTO           PIC 9(8).*/
            public IntBasis W_NUM_CNTRTO { get; set; } = new IntBasis(new PIC("9", "8", "9(8)."));
            /*"    03 W-NUM-CNTRTO-FINAL     PIC X(15).*/
            public StringBasis W_NUM_CNTRTO_FINAL { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        }


        public Copies.LBSI0202 LBSI0202 { get; set; } = new Copies.LBSI0202();
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
        public dynamic Execute(LBSI0202_SI0202S_PARAMETROS LBSI0202_SI0202S_PARAMETROS_P) //PROCEDURE DIVISION USING 
        /*SI0202S_PARAMETROS*/
        {
            try
            {
                this.LBSI0202.SI0202S_PARAMETROS = LBSI0202_SI0202S_PARAMETROS_P;

                /*" -102- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -103- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -104- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -111- INSPECT SI0202S-PARAMETROS REPLACING ALL LOW-VALUES BY SPACES. */

                /*" -112- MOVE SPACE TO SI0202S-LOGRADOURO. */
                _.Move("", LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_LOGRADOURO);

                /*" -113- MOVE SPACE TO SI0202S-BAIRRO. */
                _.Move("", LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_BAIRRO);

                /*" -114- MOVE SPACE TO SI0202S-CIDADE. */
                _.Move("", LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_CIDADE);

                /*" -115- MOVE SPACE TO SI0202S-UF. */
                _.Move("", LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_UF);

                /*" -116- MOVE 0 TO SI0202S-CEP. */
                _.Move(0, LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_CEP);

                /*" -118- MOVE SPACE TO SI0202S-ORIGEM. */
                _.Move("", LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_ORIGEM);

                /*" -119- MOVE ZERO TO SI0202S-NUM-SQL. */
                _.Move(0, LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_NUM_SQL);

                /*" -120- MOVE 0 TO SI0202S-SQLCODE. */
                _.Move(0, LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_SQLCODE);

                /*" -121- MOVE 0 TO SI0202S-RC. */
                _.Move(0, LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_RC);

                /*" -123- MOVE SPACE TO SI0202S-MENSAGEM. */
                _.Move("", LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_MENSAGEM);

                /*" -127- MOVE 0 TO W-DI-NUM-APOL-SINISTRO. */
                _.Move(0, W_DISPLAY.W_DI_NUM_APOL_SINISTRO);

                /*" -131- MOVE SI0202S-NUM-APOL-SINISTRO TO W-DI-NUM-APOL-SINISTRO. */
                _.Move(LBSI0202.SI0202S_PARAMETROS.SI0202S_ENTRADA.SI0202S_NUM_APOL_SINISTRO, W_DISPLAY.W_DI_NUM_APOL_SINISTRO);

                /*" -132- PERFORM R0100-VALIDAR-ENTRADA THRU R0100-FIM. */

                R0100_VALIDAR_ENTRADA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_FIM*/


                /*" -133- PERFORM R0500-SEL-NUM-CONTRATO THRU R0500-FIM. */

                R0500_SEL_NUM_CONTRATO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_FIM*/


                /*" -134- PERFORM R0700-FORMAR-NUM-CONTRATO THRU R0700-FIM. */

                R0700_FORMAR_NUM_CONTRATO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_FIM*/


                /*" -136- PERFORM R1000-SEL-EF-CONTR-HABIT THRU R1000-FIM. */

                R1000_SEL_EF_CONTR_HABIT(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_FIM*/


                /*" -137- IF (SQLCODE = 100) */

                if ((DB.SQLCODE == 100))
                {

                    /*" -138- PERFORM R9000-SEL-ANTIGO-HABITACIONAL THRU R9000-FIM */

                    R9000_SEL_ANTIGO_HABITACIONAL(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_FIM*/


                    /*" -139- GO TO R0000-FIM */

                    R0000_FIM(); //GOTO
                    return Result;

                    /*" -141- END-IF. */
                }


                /*" -142- PERFORM R2000-SEL-IMVL-OBJ-CTRTO-SEG-A THRU R2000-FIM. */

                R2000_SEL_IMVL_OBJ_CTRTO_SEG_A(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_FIM*/


                /*" -143- IF (SQLCODE = 0) */

                if ((DB.SQLCODE == 0))
                {

                    /*" -144- GO TO R0000-FIM */

                    R0000_FIM(); //GOTO
                    return Result;

                    /*" -146- END-IF. */
                }


                /*" -147- PERFORM R3000-SEL-IMOVEL-OBJ-CTRTO-SEG THRU R3000-FIM. */

                R3000_SEL_IMOVEL_OBJ_CTRTO_SEG(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_FIM*/


                /*" -148- IF (SQLCODE = 0) */

                if ((DB.SQLCODE == 0))
                {

                    /*" -149- GO TO R0000-FIM */

                    R0000_FIM(); //GOTO
                    return Result;

                    /*" -151- END-IF. */
                }


                /*" -152- PERFORM R4000-SEL-MIN-SEQ-OBJ-SEG THRU R4000-FIM. */

                R4000_SEL_MIN_SEQ_OBJ_SEG(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_FIM*/


                /*" -154- PERFORM R5000-SEL-PESSOA-CONTRTE THRU R5000-FIM. */

                R5000_SEL_PESSOA_CONTRTE(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R5000_FIM*/


                /*" -155- IF (SQLCODE = 0) */

                if ((DB.SQLCODE == 0))
                {

                    /*" -156- PERFORM R6000-SEL-GE-PESSOA-ENDER THRU R6000-FIM */

                    R6000_SEL_GE_PESSOA_ENDER(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R6000_FIM*/


                    /*" -157- IF (SQLCODE = 100) */

                    if ((DB.SQLCODE == 100))
                    {

                        /*" -158- PERFORM R9000-SEL-ANTIGO-HABITACIONAL THRU R9000-FIM */

                        R9000_SEL_ANTIGO_HABITACIONAL(true);
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_FIM*/


                        /*" -159- END-IF */
                    }


                    /*" -160- GO TO R0000-FIM */

                    R0000_FIM(); //GOTO
                    return Result;

                    /*" -162- END-IF. */
                }


                /*" -164- PERFORM R7000-SEL-COD-PESSOA-CRT THRU R7000-FIM. */

                R7000_SEL_COD_PESSOA_CRT(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R7000_FIM*/


                /*" -165- IF (SQLCODE = 0) */

                if ((DB.SQLCODE == 0))
                {

                    /*" -166- PERFORM R6000-SEL-GE-PESSOA-ENDER THRU R6000-FIM */

                    R6000_SEL_GE_PESSOA_ENDER(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R6000_FIM*/


                    /*" -167- IF (SQLCODE = 100) */

                    if ((DB.SQLCODE == 100))
                    {

                        /*" -168- PERFORM R9000-SEL-ANTIGO-HABITACIONAL THRU R9000-FIM */

                        R9000_SEL_ANTIGO_HABITACIONAL(true);
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_FIM*/


                        /*" -169- END-IF */
                    }


                    /*" -170- GO TO R0000-FIM */

                    R0000_FIM(); //GOTO
                    return Result;

                    /*" -172- END-IF. */
                }


                /*" -174- PERFORM R8000-SEL-CONTRTE-CONTR THRU R8000-FIM. */

                R8000_SEL_CONTRTE_CONTR(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_FIM*/


                /*" -175- IF (SQLCODE = 0) */

                if ((DB.SQLCODE == 0))
                {

                    /*" -176- PERFORM R6000-SEL-GE-PESSOA-ENDER THRU R6000-FIM */

                    R6000_SEL_GE_PESSOA_ENDER(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R6000_FIM*/


                    /*" -177- IF (SQLCODE = 100) */

                    if ((DB.SQLCODE == 100))
                    {

                        /*" -178- PERFORM R9000-SEL-ANTIGO-HABITACIONAL THRU R9000-FIM */

                        R9000_SEL_ANTIGO_HABITACIONAL(true);
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_FIM*/


                        /*" -179- END-IF */
                    }


                    /*" -180- GO TO R0000-FIM */

                    R0000_FIM(); //GOTO
                    return Result;

                    /*" -182- END-IF. */
                }


                /*" -182- PERFORM R9000-SEL-ANTIGO-HABITACIONAL THRU R9000-FIM. */

                R9000_SEL_ANTIGO_HABITACIONAL(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_FIM*/


            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LBSI0202.SI0202S_PARAMETROS };
            return Result;
        }

        [StopWatch]
        /*" R0000-FIM */
        private void R0000_FIM(bool isPerform = false)
        {
            /*" -186- GOBACK. */

            throw new GoBack();

        }

        [StopWatch]
        /*" R0100-VALIDAR-ENTRADA */
        private void R0100_VALIDAR_ENTRADA(bool isPerform = false)
        {
            /*" -193- IF (SI0202S-NUM-APOL-SINISTRO = SPACE) */

            if ((LBSI0202.SI0202S_PARAMETROS.SI0202S_ENTRADA.SI0202S_NUM_APOL_SINISTRO == " "))
            {

                /*" -196- STRING 'NUMERO DO SINISTRO DEVE SER PREENCHIDO' DELIMITED BY SIZE INTO SI0202S-MENSAGEM END-STRING */
                #region STRING
                var spl1 = "NUMERO DO SINISTRO DEVE SER PREENCHIDO";
                _.Move(spl1, LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_MENSAGEM);
                #endregion

                /*" -197- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO(); //GOTO
                return;

                /*" -199- END-IF. */
            }


            /*" -200- IF (SI0202S-NUM-APOL-SINISTRO NOT NUMERIC) */

            if ((!LBSI0202.SI0202S_PARAMETROS.SI0202S_ENTRADA.SI0202S_NUM_APOL_SINISTRO.IsNumeric()))
            {

                /*" -204- STRING 'NUMERO DE SINISTRO INVALIDO ' W-DI-NUM-APOL-SINISTRO DELIMITED BY SIZE INTO SI0202S-MENSAGEM END-STRING */
                #region STRING
                var spl2 = "NUMERO DE SINISTRO INVALIDO " + W_DISPLAY.W_DI_NUM_APOL_SINISTRO.GetMoveValues();
                _.Move(spl2, LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_MENSAGEM);
                #endregion

                /*" -205- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO(); //GOTO
                return;

                /*" -205- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_FIM*/

        [StopWatch]
        /*" R0500-SEL-NUM-CONTRATO */
        private void R0500_SEL_NUM_CONTRATO(bool isPerform = false)
        {
            /*" -215- MOVE SI0202S-NUM-APOL-SINISTRO TO SINIHAB1-NUM-APOL-SINISTRO. */
            _.Move(LBSI0202.SI0202S_PARAMETROS.SI0202S_ENTRADA.SI0202S_NUM_APOL_SINISTRO, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_NUM_APOL_SINISTRO);

            /*" -219- INITIALIZE SINIHAB1-OPERACAO SINIHAB1-PONTO-VENDA SINIHAB1-NUM-CONTRATO. */
            _.Initialize(
                SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_OPERACAO
                , SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_PONTO_VENDA
                , SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_NUM_CONTRATO
            );

            /*" -220- MOVE '001' TO SI0202S-NUM-SQL. */
            _.Move("001", LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_NUM_SQL);

            /*" -230- PERFORM R0500_SEL_NUM_CONTRATO_DB_SELECT_1 */

            R0500_SEL_NUM_CONTRATO_DB_SELECT_1();

            /*" -233- IF (SQLCODE NOT = 0 AND 100) */

            if ((!DB.SQLCODE.In("0", "100")))
            {

                /*" -238- STRING 'ERRO AO OBTER NUMERO DO CONTRATO DO ' 'SINISTRO ' W-DI-NUM-APOL-SINISTRO DELIMITED BY SIZE INTO SI0202S-MENSAGEM END-STRING */
                #region STRING
                var spl3 = "ERRO AO OBTER NUMERO DO CONTRATO DO " + "SINISTRO " + W_DISPLAY.W_DI_NUM_APOL_SINISTRO.GetMoveValues();
                _.Move(spl3, LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_MENSAGEM);
                #endregion

                /*" -239- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO(); //GOTO
                return;

                /*" -241- END-IF. */
            }


            /*" -242- IF (SQLCODE = 100) */

            if ((DB.SQLCODE == 100))
            {

                /*" -246- STRING 'O CONTRATO DO SINISTRO ' W-DI-NUM-APOL-SINISTRO ' NAO FOI ENCONTRADO' DELIMITED BY SIZE INTO SI0202S-MENSAGEM END-STRING */
                #region STRING
                var spl4 = "O CONTRATO DO SINISTRO " + W_DISPLAY.W_DI_NUM_APOL_SINISTRO.GetMoveValues();
                spl4 += " NAO FOI ENCONTRADO";
                _.Move(spl4, LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_MENSAGEM);
                #endregion

                /*" -247- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO(); //GOTO
                return;

                /*" -247- END-IF. */
            }


        }

        [StopWatch]
        /*" R0500-SEL-NUM-CONTRATO-DB-SELECT-1 */
        public void R0500_SEL_NUM_CONTRATO_DB_SELECT_1()
        {
            /*" -230- EXEC SQL SELECT OPERACAO ,PONTO_VENDA ,NUM_CONTRATO INTO :SINIHAB1-OPERACAO ,:SINIHAB1-PONTO-VENDA ,:SINIHAB1-NUM-CONTRATO FROM SEGUROS.SINISTRO_HABIT01 WHERE NUM_APOL_SINISTRO = :SINIHAB1-NUM-APOL-SINISTRO WITH UR END-EXEC. */

            var r0500_SEL_NUM_CONTRATO_DB_SELECT_1_Query1 = new R0500_SEL_NUM_CONTRATO_DB_SELECT_1_Query1()
            {
                SINIHAB1_NUM_APOL_SINISTRO = SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R0500_SEL_NUM_CONTRATO_DB_SELECT_1_Query1.Execute(r0500_SEL_NUM_CONTRATO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINIHAB1_OPERACAO, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_OPERACAO);
                _.Move(executed_1.SINIHAB1_PONTO_VENDA, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_PONTO_VENDA);
                _.Move(executed_1.SINIHAB1_NUM_CONTRATO, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_NUM_CONTRATO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_FIM*/

        [StopWatch]
        /*" R0700-FORMAR-NUM-CONTRATO */
        private void R0700_FORMAR_NUM_CONTRATO(bool isPerform = false)
        {
            /*" -260- MOVE 0 TO EF072-NUM-CONTRATO. */
            _.Move(0, EF072.DCLEF_CONTR_SEG_HABIT.EF072_NUM_CONTRATO);

            /*" -262- MOVE 0 TO EF072-NUM-CONTRATO-TERC. */
            _.Move(0, EF072.DCLEF_CONTR_SEG_HABIT.EF072_NUM_CONTRATO_TERC);

            /*" -263- MOVE SINIHAB1-OPERACAO TO W-NUM-OPERACAO. */
            _.Move(SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_OPERACAO, W_CONTRATO.W_NUM_OPERACAO);

            /*" -264- MOVE SINIHAB1-PONTO-VENDA TO W-NUM-PV. */
            _.Move(SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_PONTO_VENDA, W_CONTRATO.W_NUM_PV);

            /*" -266- MOVE SINIHAB1-NUM-CONTRATO TO W-NUM-CNTRTO. */
            _.Move(SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_NUM_CONTRATO, W_CONTRATO.W_NUM_CNTRTO);

            /*" -270- STRING W-NUM-OPERACAO W-NUM-PV W-NUM-CNTRTO DELIMITED BY SIZE INTO W-NUM-CNTRTO-FINAL */
            #region STRING
            var spl5 = W_CONTRATO.W_NUM_OPERACAO.GetMoveValues();
            var spl6 = W_CONTRATO.W_NUM_PV.GetMoveValues();
            var spl7 = W_CONTRATO.W_NUM_CNTRTO.GetMoveValues();
            var results8 = spl5 + spl6 + spl7;
            _.Move(results8, W_CONTRATO.W_NUM_CNTRTO_FINAL);
            #endregion

            /*" -273- MOVE '  ' TO W-NUM-CNTRTO-FINAL(1:2). */
            _.MoveAtPosition("  ", W_CONTRATO.W_NUM_CNTRTO_FINAL, 1, 2);

            /*" -276- MOVE ' ' TO W-NUM-CNTRTO-FINAL(15:1). */
            _.MoveAtPosition(" ", W_CONTRATO.W_NUM_CNTRTO_FINAL, 15, 1);

            /*" -277- COMPUTE EF072-NUM-CONTRATO-TERC = FUNCTION NUMVAL(W-NUM-CNTRTO-FINAL). */
            EF072.DCLEF_CONTR_SEG_HABIT.EF072_NUM_CONTRATO_TERC.Value = _.NumVal(W_CONTRATO.W_NUM_CNTRTO_FINAL);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_FIM*/

        [StopWatch]
        /*" R1000-SEL-EF-CONTR-HABIT */
        private void R1000_SEL_EF_CONTR_HABIT(bool isPerform = false)
        {
            /*" -287- MOVE 0 TO EF072-NUM-CONTRATO. */
            _.Move(0, EF072.DCLEF_CONTR_SEG_HABIT.EF072_NUM_CONTRATO);

            /*" -289- INITIALIZE EF072-NUM-CONTRATO. */
            _.Initialize(
                EF072.DCLEF_CONTR_SEG_HABIT.EF072_NUM_CONTRATO
            );

            /*" -291- MOVE '002' TO SI0202S-NUM-SQL. */
            _.Move("002", LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_NUM_SQL);

            /*" -298- PERFORM R1000_SEL_EF_CONTR_HABIT_DB_SELECT_1 */

            R1000_SEL_EF_CONTR_HABIT_DB_SELECT_1();

            /*" -301- IF (SQLCODE NOT = 0 AND 100) */

            if ((!DB.SQLCODE.In("0", "100")))
            {

                /*" -302- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO(); //GOTO
                return;

                /*" -302- END-IF. */
            }


        }

        [StopWatch]
        /*" R1000-SEL-EF-CONTR-HABIT-DB-SELECT-1 */
        public void R1000_SEL_EF_CONTR_HABIT_DB_SELECT_1()
        {
            /*" -298- EXEC SQL SELECT NUM_CONTRATO INTO :EF072-NUM-CONTRATO FROM SEGUROS.EF_CONTR_SEG_HABIT WHERE NOM_ARQUIVO = 'EF001' AND NUM_CONTRATO_TERC = :EF072-NUM-CONTRATO-TERC WITH UR END-EXEC. */

            var r1000_SEL_EF_CONTR_HABIT_DB_SELECT_1_Query1 = new R1000_SEL_EF_CONTR_HABIT_DB_SELECT_1_Query1()
            {
                EF072_NUM_CONTRATO_TERC = EF072.DCLEF_CONTR_SEG_HABIT.EF072_NUM_CONTRATO_TERC.ToString(),
            };

            var executed_1 = R1000_SEL_EF_CONTR_HABIT_DB_SELECT_1_Query1.Execute(r1000_SEL_EF_CONTR_HABIT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.EF072_NUM_CONTRATO, EF072.DCLEF_CONTR_SEG_HABIT.EF072_NUM_CONTRATO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_FIM*/

        [StopWatch]
        /*" R2000-SEL-IMVL-OBJ-CTRTO-SEG-A */
        private void R2000_SEL_IMVL_OBJ_CTRTO_SEG_A(bool isPerform = false)
        {
            /*" -316- INITIALIZE W-EF083-ENDERECO EF083-NOM-BAIRRO EF083-NUM-CEP EF083-NOM-CIDADE EF083-COD-UF. */
            _.Initialize(
                W_EF083_ENDERECO
                , EF083.DCLEF_IMOVEL.EF083_NOM_BAIRRO
                , EF083.DCLEF_IMOVEL.EF083_NUM_CEP
                , EF083.DCLEF_IMOVEL.EF083_NOM_CIDADE
                , EF083.DCLEF_IMOVEL.EF083_COD_UF
            );

            /*" -317- MOVE '003' TO SI0202S-NUM-SQL. */
            _.Move("003", LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_NUM_SQL);

            /*" -349- PERFORM R2000_SEL_IMVL_OBJ_CTRTO_SEG_A_DB_SELECT_1 */

            R2000_SEL_IMVL_OBJ_CTRTO_SEG_A_DB_SELECT_1();

            /*" -352- IF (SQLCODE NOT = 0 AND 100) */

            if ((!DB.SQLCODE.In("0", "100")))
            {

                /*" -353- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO(); //GOTO
                return;

                /*" -356- END-IF. */
            }


            /*" -357- MOVE SPACE TO W-ENDERECO-ORIG-TEXT. */
            _.Move("", W_ENDERECO_ORIG_TEXT);

            /*" -358- MOVE SPACE TO W-NUM-CEP. */
            _.Move("", W_NUM_CEP);

            /*" -359- MOVE 0 TO W-ENDERECO-ORIG-LEN. */
            _.Move(0, W_ENDERECO_ORIG_LEN);

            /*" -360- MOVE W-EF083-ENDERECO TO W-ENDERECO-ORIG-TEXT. */
            _.Move(W_EF083_ENDERECO, W_ENDERECO_ORIG_TEXT);

            /*" -361- MOVE LENGTH OF W-EF083-ENDERECO TO W-ENDERECO-ORIG-LEN. */
            _.Move(W_EF083_ENDERECO.Value.Length, W_ENDERECO_ORIG_LEN);

            /*" -362- PERFORM R9500-TRIM-ENDERECO THRU R9500-FIM. */

            R9500_TRIM_ENDERECO(true);

            R9500_FIM(true);

            /*" -364- MOVE W-ENDERECO-TRIM-TEXT TO SI0202S-LOGRADOURO. */
            _.Move(W_ENDERECO_TRIM_TEXT, LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_LOGRADOURO);

            /*" -365- MOVE EF083-NOM-BAIRRO TO SI0202S-BAIRRO. */
            _.Move(EF083.DCLEF_IMOVEL.EF083_NOM_BAIRRO, LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_BAIRRO);

            /*" -366- MOVE EF083-NOM-CIDADE TO SI0202S-CIDADE. */
            _.Move(EF083.DCLEF_IMOVEL.EF083_NOM_CIDADE, LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_CIDADE);

            /*" -367- MOVE EF083-COD-UF TO SI0202S-UF. */
            _.Move(EF083.DCLEF_IMOVEL.EF083_COD_UF, LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_UF);

            /*" -368- MOVE EF083-NUM-CEP TO SI0202S-CEP. */
            _.Move(EF083.DCLEF_IMOVEL.EF083_NUM_CEP, LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_CEP);

            /*" -369- MOVE 'EF' TO SI0202S-ORIGEM. */
            _.Move("EF", LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_ORIGEM);

            /*" -369- PERFORM R9100-DEL-PONTO-VIRGULA THRU R9100-FIM. */

            R9100_DEL_PONTO_VIRGULA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R9100_FIM*/


        }

        [StopWatch]
        /*" R2000-SEL-IMVL-OBJ-CTRTO-SEG-A-DB-SELECT-1 */
        public void R2000_SEL_IMVL_OBJ_CTRTO_SEG_A_DB_SELECT_1()
        {
            /*" -349- EXEC SQL SELECT A.DES_ENDERECO || ' ' || VALUE(A.DES_COMPL_ENDERECO, ' ' ) ,VALUE(A.NOM_BAIRRO, ' ' ) ,A.NUM_CEP ,A.NOM_CIDADE ,VALUE(A.COD_UF, ' ' ) INTO :W-EF083-ENDERECO ,:EF083-NOM-BAIRRO ,:EF083-NUM-CEP ,:EF083-NOM-CIDADE ,:EF083-COD-UF FROM SEGUROS.EF_IMOVEL A, SEGUROS.EF_OBJ_CONTR_SEGUR B WHERE A.NUM_CONTRATO_SEGUR = :EF072-NUM-CONTRATO AND A.NUM_CONTRATO_SEGUR = B.NUM_CONTRATO_SEGUR AND A.SEQ_TIPO_OBJ_SEG = B.SEQ_TIPO_OBJ_SEG AND A.COD_TIPO_OBJ_SEG = B.COD_TIPO_OBJ_SEG AND B.STA_OBJ_CONTR_SEG = 'A' AND B.COD_TIPO_OBJ_SEG = 1 AND A.SEQ_TIPO_OBJ_SEG = (SELECT MAX(C.SEQ_TIPO_OBJ_SEG) FROM SEGUROS.EF_IMOVEL C, SEGUROS.EF_OBJ_CONTR_SEGUR D WHERE C.NUM_CONTRATO_SEGUR = :EF072-NUM-CONTRATO AND C.NUM_CONTRATO_SEGUR = D.NUM_CONTRATO_SEGUR AND C.SEQ_TIPO_OBJ_SEG = D.SEQ_TIPO_OBJ_SEG AND C.COD_TIPO_OBJ_SEG = D.COD_TIPO_OBJ_SEG AND D.STA_OBJ_CONTR_SEG = 'A' AND D.COD_TIPO_OBJ_SEG = 1) WITH UR END-EXEC. */

            var r2000_SEL_IMVL_OBJ_CTRTO_SEG_A_DB_SELECT_1_Query1 = new R2000_SEL_IMVL_OBJ_CTRTO_SEG_A_DB_SELECT_1_Query1()
            {
                EF072_NUM_CONTRATO = EF072.DCLEF_CONTR_SEG_HABIT.EF072_NUM_CONTRATO.ToString(),
            };

            var executed_1 = R2000_SEL_IMVL_OBJ_CTRTO_SEG_A_DB_SELECT_1_Query1.Execute(r2000_SEL_IMVL_OBJ_CTRTO_SEG_A_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.W_EF083_ENDERECO, W_EF083_ENDERECO);
                _.Move(executed_1.EF083_NOM_BAIRRO, EF083.DCLEF_IMOVEL.EF083_NOM_BAIRRO);
                _.Move(executed_1.EF083_NUM_CEP, EF083.DCLEF_IMOVEL.EF083_NUM_CEP);
                _.Move(executed_1.EF083_NOM_CIDADE, EF083.DCLEF_IMOVEL.EF083_NOM_CIDADE);
                _.Move(executed_1.EF083_COD_UF, EF083.DCLEF_IMOVEL.EF083_COD_UF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_FIM*/

        [StopWatch]
        /*" R3000-SEL-IMOVEL-OBJ-CTRTO-SEG */
        private void R3000_SEL_IMOVEL_OBJ_CTRTO_SEG(bool isPerform = false)
        {
            /*" -384- INITIALIZE EF083-DES-ENDERECO EF083-DES-COMPL-ENDERECO EF083-NOM-BAIRRO EF083-NUM-CEP EF083-NOM-CIDADE EF083-COD-UF. */
            _.Initialize(
                EF083.DCLEF_IMOVEL.EF083_DES_ENDERECO
                , EF083.DCLEF_IMOVEL.EF083_DES_COMPL_ENDERECO
                , EF083.DCLEF_IMOVEL.EF083_NOM_BAIRRO
                , EF083.DCLEF_IMOVEL.EF083_NUM_CEP
                , EF083.DCLEF_IMOVEL.EF083_NOM_CIDADE
                , EF083.DCLEF_IMOVEL.EF083_COD_UF
            );

            /*" -385- MOVE '004' TO SI0202S-NUM-SQL. */
            _.Move("004", LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_NUM_SQL);

            /*" -415- PERFORM R3000_SEL_IMOVEL_OBJ_CTRTO_SEG_DB_SELECT_1 */

            R3000_SEL_IMOVEL_OBJ_CTRTO_SEG_DB_SELECT_1();

            /*" -418- IF (SQLCODE NOT = 0 AND 100) */

            if ((!DB.SQLCODE.In("0", "100")))
            {

                /*" -419- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO(); //GOTO
                return;

                /*" -422- END-IF. */
            }


            /*" -423- MOVE SPACE TO W-ENDERECO-ORIG-TEXT. */
            _.Move("", W_ENDERECO_ORIG_TEXT);

            /*" -424- MOVE SPACE TO W-NUM-CEP. */
            _.Move("", W_NUM_CEP);

            /*" -425- MOVE 0 TO W-ENDERECO-ORIG-LEN. */
            _.Move(0, W_ENDERECO_ORIG_LEN);

            /*" -426- MOVE W-EF083-ENDERECO TO W-ENDERECO-ORIG-TEXT. */
            _.Move(W_EF083_ENDERECO, W_ENDERECO_ORIG_TEXT);

            /*" -427- MOVE LENGTH OF W-EF083-ENDERECO TO W-ENDERECO-ORIG-LEN. */
            _.Move(W_EF083_ENDERECO.Value.Length, W_ENDERECO_ORIG_LEN);

            /*" -428- PERFORM R9500-TRIM-ENDERECO THRU R9500-FIM. */

            R9500_TRIM_ENDERECO(true);

            R9500_FIM(true);

            /*" -430- MOVE W-ENDERECO-TRIM-TEXT TO SI0202S-LOGRADOURO. */
            _.Move(W_ENDERECO_TRIM_TEXT, LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_LOGRADOURO);

            /*" -431- MOVE EF083-NOM-BAIRRO TO SI0202S-BAIRRO. */
            _.Move(EF083.DCLEF_IMOVEL.EF083_NOM_BAIRRO, LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_BAIRRO);

            /*" -432- MOVE EF083-NOM-CIDADE TO SI0202S-CIDADE. */
            _.Move(EF083.DCLEF_IMOVEL.EF083_NOM_CIDADE, LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_CIDADE);

            /*" -433- MOVE EF083-COD-UF TO SI0202S-UF. */
            _.Move(EF083.DCLEF_IMOVEL.EF083_COD_UF, LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_UF);

            /*" -434- MOVE EF083-NUM-CEP TO SI0202S-CEP. */
            _.Move(EF083.DCLEF_IMOVEL.EF083_NUM_CEP, LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_CEP);

            /*" -435- MOVE 'EF' TO SI0202S-ORIGEM. */
            _.Move("EF", LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_ORIGEM);

            /*" -435- PERFORM R9100-DEL-PONTO-VIRGULA THRU R9100-FIM. */

            R9100_DEL_PONTO_VIRGULA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R9100_FIM*/


        }

        [StopWatch]
        /*" R3000-SEL-IMOVEL-OBJ-CTRTO-SEG-DB-SELECT-1 */
        public void R3000_SEL_IMOVEL_OBJ_CTRTO_SEG_DB_SELECT_1()
        {
            /*" -415- EXEC SQL SELECT A.DES_ENDERECO ,VALUE(A.DES_COMPL_ENDERECO, ' ' ) ,VALUE(A.NOM_BAIRRO, ' ' ) ,A.NUM_CEP ,A.NOM_CIDADE ,VALUE(A.COD_UF, ' ' ) INTO :EF083-DES-ENDERECO ,:EF083-DES-COMPL-ENDERECO ,:EF083-NOM-BAIRRO ,:EF083-NUM-CEP ,:EF083-NOM-CIDADE ,:EF083-COD-UF FROM SEGUROS.EF_IMOVEL A, SEGUROS.EF_OBJ_CONTR_SEGUR B WHERE A.NUM_CONTRATO_SEGUR = :EF072-NUM-CONTRATO AND A.NUM_CONTRATO_SEGUR = B.NUM_CONTRATO_SEGUR AND A.SEQ_TIPO_OBJ_SEG = B.SEQ_TIPO_OBJ_SEG AND A.COD_TIPO_OBJ_SEG = B.COD_TIPO_OBJ_SEG AND B.COD_TIPO_OBJ_SEG = 1 AND A.SEQ_TIPO_OBJ_SEG = (SELECT MAX(C.SEQ_TIPO_OBJ_SEG) FROM SEGUROS.EF_IMOVEL C, SEGUROS.EF_OBJ_CONTR_SEGUR D WHERE C.NUM_CONTRATO_SEGUR = :EF072-NUM-CONTRATO AND C.NUM_CONTRATO_SEGUR = D.NUM_CONTRATO_SEGUR AND C.SEQ_TIPO_OBJ_SEG = D.SEQ_TIPO_OBJ_SEG AND C.COD_TIPO_OBJ_SEG = D.COD_TIPO_OBJ_SEG AND D.COD_TIPO_OBJ_SEG = 1) WITH UR END-EXEC. */

            var r3000_SEL_IMOVEL_OBJ_CTRTO_SEG_DB_SELECT_1_Query1 = new R3000_SEL_IMOVEL_OBJ_CTRTO_SEG_DB_SELECT_1_Query1()
            {
                EF072_NUM_CONTRATO = EF072.DCLEF_CONTR_SEG_HABIT.EF072_NUM_CONTRATO.ToString(),
            };

            var executed_1 = R3000_SEL_IMOVEL_OBJ_CTRTO_SEG_DB_SELECT_1_Query1.Execute(r3000_SEL_IMOVEL_OBJ_CTRTO_SEG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.EF083_DES_ENDERECO, EF083.DCLEF_IMOVEL.EF083_DES_ENDERECO);
                _.Move(executed_1.EF083_DES_COMPL_ENDERECO, EF083.DCLEF_IMOVEL.EF083_DES_COMPL_ENDERECO);
                _.Move(executed_1.EF083_NOM_BAIRRO, EF083.DCLEF_IMOVEL.EF083_NOM_BAIRRO);
                _.Move(executed_1.EF083_NUM_CEP, EF083.DCLEF_IMOVEL.EF083_NUM_CEP);
                _.Move(executed_1.EF083_NOM_CIDADE, EF083.DCLEF_IMOVEL.EF083_NOM_CIDADE);
                _.Move(executed_1.EF083_COD_UF, EF083.DCLEF_IMOVEL.EF083_COD_UF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_FIM*/

        [StopWatch]
        /*" R4000-SEL-MIN-SEQ-OBJ-SEG */
        private void R4000_SEL_MIN_SEQ_OBJ_SEG(bool isPerform = false)
        {
            /*" -445- INITIALIZE EF079-SEQ-TIPO-OBJ-SEG. */
            _.Initialize(
                EF079.DCLEF_SEGURADO_OBJETO.EF079_SEQ_TIPO_OBJ_SEG
            );

            /*" -446- MOVE '005' TO SI0202S-NUM-SQL. */
            _.Move("005", LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_NUM_SQL);

            /*" -459- PERFORM R4000_SEL_MIN_SEQ_OBJ_SEG_DB_SELECT_1 */

            R4000_SEL_MIN_SEQ_OBJ_SEG_DB_SELECT_1();

            /*" -462- IF (SQLCODE NOT = 0 AND 100) */

            if ((!DB.SQLCODE.In("0", "100")))
            {

                /*" -463- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO(); //GOTO
                return;

                /*" -465- END-IF. */
            }


            /*" -466- IF (SQLCODE = 100) */

            if ((DB.SQLCODE == 100))
            {

                /*" -467- MOVE 'ENDERECO NAO ENCONTRADO' TO SI0202S-MENSAGEM */
                _.Move("ENDERECO NAO ENCONTRADO", LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_MENSAGEM);

                /*" -468- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO(); //GOTO
                return;

                /*" -468- END-IF. */
            }


        }

        [StopWatch]
        /*" R4000-SEL-MIN-SEQ-OBJ-SEG-DB-SELECT-1 */
        public void R4000_SEL_MIN_SEQ_OBJ_SEG_DB_SELECT_1()
        {
            /*" -459- EXEC SQL SELECT VALUE(MIN(A.SEQ_TIPO_OBJ_SEG),0) INTO :EF079-SEQ-TIPO-OBJ-SEG FROM SEGUROS.EF_SEGURADO_OBJETO A, SEGUROS.EF_OBJ_CONTR_SEGUR B WHERE A.NUM_CONTRATO_SEGUR = :EF072-NUM-CONTRATO AND A.NUM_CONTRATO_SEGUR = B.NUM_CONTRATO_SEGUR AND A.SEQ_TIPO_OBJ_SEG = B.SEQ_TIPO_OBJ_SEG AND A.COD_TIPO_OBJ_SEG = B.COD_TIPO_OBJ_SEG AND A.STA_TITULAR = 'S' AND B.STA_OBJ_CONTR_SEG = 'A' AND B.COD_TIPO_OBJ_SEG = 2 WITH UR END-EXEC. */

            var r4000_SEL_MIN_SEQ_OBJ_SEG_DB_SELECT_1_Query1 = new R4000_SEL_MIN_SEQ_OBJ_SEG_DB_SELECT_1_Query1()
            {
                EF072_NUM_CONTRATO = EF072.DCLEF_CONTR_SEG_HABIT.EF072_NUM_CONTRATO.ToString(),
            };

            var executed_1 = R4000_SEL_MIN_SEQ_OBJ_SEG_DB_SELECT_1_Query1.Execute(r4000_SEL_MIN_SEQ_OBJ_SEG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.EF079_SEQ_TIPO_OBJ_SEG, EF079.DCLEF_SEGURADO_OBJETO.EF079_SEQ_TIPO_OBJ_SEG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_FIM*/

        [StopWatch]
        /*" R5000-SEL-PESSOA-CONTRTE */
        private void R5000_SEL_PESSOA_CONTRTE(bool isPerform = false)
        {
            /*" -478- INITIALIZE EF079-COD-PESSOA-CONTRTE. */
            _.Initialize(
                EF079.DCLEF_SEGURADO_OBJETO.EF079_COD_PESSOA_CONTRTE
            );

            /*" -479- MOVE '006' TO SI0202S-NUM-SQL. */
            _.Move("006", LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_NUM_SQL);

            /*" -493- PERFORM R5000_SEL_PESSOA_CONTRTE_DB_SELECT_1 */

            R5000_SEL_PESSOA_CONTRTE_DB_SELECT_1();

            /*" -496- IF (SQLCODE = 0 AND 100) */

            if ((DB.SQLCODE.In("0", "100")))
            {

                /*" -497- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO(); //GOTO
                return;

                /*" -497- END-IF. */
            }


        }

        [StopWatch]
        /*" R5000-SEL-PESSOA-CONTRTE-DB-SELECT-1 */
        public void R5000_SEL_PESSOA_CONTRTE_DB_SELECT_1()
        {
            /*" -493- EXEC SQL SELECT A.COD_PESSOA_CONTRTE INTO :EF079-COD-PESSOA-CONTRTE FROM SEGUROS.EF_SEGURADO_OBJETO A, SEGUROS.EF_OBJ_CONTR_SEGUR B WHERE A.NUM_CONTRATO_SEGUR = :EF072-NUM-CONTRATO AND A.NUM_CONTRATO_SEGUR = B.NUM_CONTRATO_SEGUR AND A.SEQ_TIPO_OBJ_SEG = :EF079-SEQ-TIPO-OBJ-SEG AND A.SEQ_TIPO_OBJ_SEG = B.SEQ_TIPO_OBJ_SEG AND A.COD_TIPO_OBJ_SEG = B.COD_TIPO_OBJ_SEG AND A.STA_TITULAR = 'S' AND B.STA_OBJ_CONTR_SEG = 'A' AND B.COD_TIPO_OBJ_SEG = 2 WITH UR END-EXEC. */

            var r5000_SEL_PESSOA_CONTRTE_DB_SELECT_1_Query1 = new R5000_SEL_PESSOA_CONTRTE_DB_SELECT_1_Query1()
            {
                EF079_SEQ_TIPO_OBJ_SEG = EF079.DCLEF_SEGURADO_OBJETO.EF079_SEQ_TIPO_OBJ_SEG.ToString(),
                EF072_NUM_CONTRATO = EF072.DCLEF_CONTR_SEG_HABIT.EF072_NUM_CONTRATO.ToString(),
            };

            var executed_1 = R5000_SEL_PESSOA_CONTRTE_DB_SELECT_1_Query1.Execute(r5000_SEL_PESSOA_CONTRTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.EF079_COD_PESSOA_CONTRTE, EF079.DCLEF_SEGURADO_OBJETO.EF079_COD_PESSOA_CONTRTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5000_FIM*/

        [StopWatch]
        /*" R6000-SEL-GE-PESSOA-ENDER */
        private void R6000_SEL_GE_PESSOA_ENDER(bool isPerform = false)
        {
            /*" -507- MOVE EF079-COD-PESSOA-CONTRTE TO GEPESEND-COD-PESSOA. */
            _.Move(EF079.DCLEF_SEGURADO_OBJETO.EF079_COD_PESSOA_CONTRTE, GEPESEND.DCLGE_PESSOA_ENDERECO.GEPESEND_COD_PESSOA);

            /*" -513- INITIALIZE W-GEPESEND-ENDERECO GEPESEND-NOM-BAIRRO GEPESEND-NOM-CIDADE GEPESEND-COD-UF GEPESEND-NUM-CEP. */
            _.Initialize(
                W_GEPESEND_ENDERECO
                , GEPESEND.DCLGE_PESSOA_ENDERECO.GEPESEND_NOM_BAIRRO
                , GEPESEND.DCLGE_PESSOA_ENDERECO.GEPESEND_NOM_CIDADE
                , GEPESEND.DCLGE_PESSOA_ENDERECO.GEPESEND_COD_UF
                , GEPESEND.DCLGE_PESSOA_ENDERECO.GEPESEND_NUM_CEP
            );

            /*" -514- MOVE '007' TO SI0202S-NUM-SQL. */
            _.Move("007", LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_NUM_SQL);

            /*" -536- PERFORM R6000_SEL_GE_PESSOA_ENDER_DB_SELECT_1 */

            R6000_SEL_GE_PESSOA_ENDER_DB_SELECT_1();

            /*" -539- IF (SQLCODE NOT = 0 AND 100) */

            if ((!DB.SQLCODE.In("0", "100")))
            {

                /*" -540- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO(); //GOTO
                return;

                /*" -543- END-IF. */
            }


            /*" -544- MOVE SPACE TO W-ENDERECO-ORIG-TEXT. */
            _.Move("", W_ENDERECO_ORIG_TEXT);

            /*" -545- MOVE SPACE TO W-NUM-CEP. */
            _.Move("", W_NUM_CEP);

            /*" -546- MOVE 0 TO W-ENDERECO-ORIG-LEN. */
            _.Move(0, W_ENDERECO_ORIG_LEN);

            /*" -547- MOVE W-GEPESEND-ENDERECO TO W-ENDERECO-ORIG-TEXT. */
            _.Move(W_GEPESEND_ENDERECO, W_ENDERECO_ORIG_TEXT);

            /*" -548- MOVE LENGTH OF W-GEPESEND-ENDERECO TO W-ENDERECO-ORIG-LEN. */
            _.Move(W_GEPESEND_ENDERECO.Value.Length, W_ENDERECO_ORIG_LEN);

            /*" -549- PERFORM R9500-TRIM-ENDERECO THRU R9500-FIM. */

            R9500_TRIM_ENDERECO(true);

            R9500_FIM(true);

            /*" -551- MOVE W-ENDERECO-TRIM-TEXT TO SI0202S-LOGRADOURO. */
            _.Move(W_ENDERECO_TRIM_TEXT, LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_LOGRADOURO);

            /*" -552- MOVE GEPESEND-NOM-BAIRRO TO SI0202S-BAIRRO. */
            _.Move(GEPESEND.DCLGE_PESSOA_ENDERECO.GEPESEND_NOM_BAIRRO, LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_BAIRRO);

            /*" -553- MOVE GEPESEND-NOM-CIDADE TO SI0202S-CIDADE. */
            _.Move(GEPESEND.DCLGE_PESSOA_ENDERECO.GEPESEND_NOM_CIDADE, LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_CIDADE);

            /*" -554- MOVE GEPESEND-COD-UF TO SI0202S-UF. */
            _.Move(GEPESEND.DCLGE_PESSOA_ENDERECO.GEPESEND_COD_UF, LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_UF);

            /*" -555- MOVE 0 TO W-NUM-CEP(1:1). */
            _.MoveAtPosition(0, W_NUM_CEP, 1, 1);

            /*" -556- MOVE 1 TO W-I-CEP1. */
            _.Move(1, W_I_CEP1);

            /*" -558- MOVE 1 TO W-I-CEP2. */
            _.Move(1, W_I_CEP2);

            /*" -559- PERFORM 10 TIMES */

            for (int i = 0; i < 10; i++)
            {

                /*" -560- IF (GEPESEND-NUM-CEP (W-I-CEP1:1) IS NUMERIC) */

                if ((GEPESEND.DCLGE_PESSOA_ENDERECO.GEPESEND_NUM_CEP.Substring(W_I_CEP1, 1).IsNumeric()))
                {

                    /*" -562- MOVE GEPESEND-NUM-CEP (W-I-CEP1:1) TO W-NUM-CEP(W-I-CEP2:1) */
                    _.MoveAtPosition(GEPESEND.DCLGE_PESSOA_ENDERECO.GEPESEND_NUM_CEP.Substring(W_I_CEP1, 1), W_NUM_CEP, W_I_CEP2, 1);

                    /*" -563- ADD 1 TO W-I-CEP2 */
                    W_I_CEP2.Value = W_I_CEP2 + 1;

                    /*" -564- END-IF */
                }


                /*" -565- ADD 1 TO W-I-CEP1 */
                W_I_CEP1.Value = W_I_CEP1 + 1;

                /*" -567- END-PERFORM. */
            }

            /*" -568- COMPUTE SI0202S-CEP = FUNCTION NUMVAL(W-NUM-CEP). */
            LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_CEP.Value = _.NumVal(W_NUM_CEP);

            /*" -569- MOVE 'EF' TO SI0202S-ORIGEM. */
            _.Move("EF", LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_ORIGEM);

            /*" -569- PERFORM R9100-DEL-PONTO-VIRGULA THRU R9100-FIM. */

            R9100_DEL_PONTO_VIRGULA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R9100_FIM*/


        }

        [StopWatch]
        /*" R6000-SEL-GE-PESSOA-ENDER-DB-SELECT-1 */
        public void R6000_SEL_GE_PESSOA_ENDER_DB_SELECT_1()
        {
            /*" -536- EXEC SQL SELECT A.NOM_LOGRADOURO || ' ' || A.DES_COMPLEMENTO || ' ' || A.NUM_IMOVEL ,A.NOM_BAIRRO ,A.NOM_CIDADE ,A.COD_UF ,A.NUM_CEP INTO :W-GEPESEND-ENDERECO ,:GEPESEND-NOM-BAIRRO ,:GEPESEND-NOM-CIDADE ,:GEPESEND-COD-UF ,:GEPESEND-NUM-CEP FROM SEGUROS.GE_PESSOA_ENDERECO A WHERE A.COD_PESSOA = :GEPESEND-COD-PESSOA AND A.STA_ENDERECO = 'A' AND A.SEQ_ENDERECO = (SELECT MAX(B.SEQ_ENDERECO) FROM SEGUROS.GE_PESSOA_ENDERECO B WHERE B.COD_PESSOA = :GEPESEND-COD-PESSOA AND B.STA_ENDERECO = 'A' ) WITH UR END-EXEC. */

            var r6000_SEL_GE_PESSOA_ENDER_DB_SELECT_1_Query1 = new R6000_SEL_GE_PESSOA_ENDER_DB_SELECT_1_Query1()
            {
                GEPESEND_COD_PESSOA = GEPESEND.DCLGE_PESSOA_ENDERECO.GEPESEND_COD_PESSOA.ToString(),
            };

            var executed_1 = R6000_SEL_GE_PESSOA_ENDER_DB_SELECT_1_Query1.Execute(r6000_SEL_GE_PESSOA_ENDER_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.W_GEPESEND_ENDERECO, W_GEPESEND_ENDERECO);
                _.Move(executed_1.GEPESEND_NOM_BAIRRO, GEPESEND.DCLGE_PESSOA_ENDERECO.GEPESEND_NOM_BAIRRO);
                _.Move(executed_1.GEPESEND_NOM_CIDADE, GEPESEND.DCLGE_PESSOA_ENDERECO.GEPESEND_NOM_CIDADE);
                _.Move(executed_1.GEPESEND_COD_UF, GEPESEND.DCLGE_PESSOA_ENDERECO.GEPESEND_COD_UF);
                _.Move(executed_1.GEPESEND_NUM_CEP, GEPESEND.DCLGE_PESSOA_ENDERECO.GEPESEND_NUM_CEP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6000_FIM*/

        [StopWatch]
        /*" R7000-SEL-COD-PESSOA-CRT */
        private void R7000_SEL_COD_PESSOA_CRT(bool isPerform = false)
        {
            /*" -579- INITIALIZE EF079-COD-PESSOA-CONTRTE. */
            _.Initialize(
                EF079.DCLEF_SEGURADO_OBJETO.EF079_COD_PESSOA_CONTRTE
            );

            /*" -580- MOVE '008' TO SI0202S-NUM-SQL. */
            _.Move("008", LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_NUM_SQL);

            /*" -600- PERFORM R7000_SEL_COD_PESSOA_CRT_DB_SELECT_1 */

            R7000_SEL_COD_PESSOA_CRT_DB_SELECT_1();

            /*" -603- IF (SQLCODE NOT = 0 AND 100) */

            if ((!DB.SQLCODE.In("0", "100")))
            {

                /*" -604- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO(); //GOTO
                return;

                /*" -604- END-IF. */
            }


        }

        [StopWatch]
        /*" R7000-SEL-COD-PESSOA-CRT-DB-SELECT-1 */
        public void R7000_SEL_COD_PESSOA_CRT_DB_SELECT_1()
        {
            /*" -600- EXEC SQL SELECT A.COD_PESSOA_CONTRTE INTO :EF079-COD-PESSOA-CONTRTE FROM SEGUROS.EF_SEGURADO_OBJETO A, SEGUROS.EF_OBJ_CONTR_SEGUR B WHERE A.NUM_CONTRATO_SEGUR = :EF072-NUM-CONTRATO AND A.NUM_CONTRATO_SEGUR = B.NUM_CONTRATO_SEGUR AND A.SEQ_TIPO_OBJ_SEG = B.SEQ_TIPO_OBJ_SEG AND A.COD_TIPO_OBJ_SEG = B.COD_TIPO_OBJ_SEG AND B.COD_TIPO_OBJ_SEG = 2 AND A.SEQ_TIPO_OBJ_SEG = (SELECT MAX(C.SEQ_TIPO_OBJ_SEG) FROM SEGUROS.EF_SEGURADO_OBJETO C, SEGUROS.EF_OBJ_CONTR_SEGUR D WHERE C.NUM_CONTRATO_SEGUR = :EF072-NUM-CONTRATO AND C.NUM_CONTRATO_SEGUR = D.NUM_CONTRATO_SEGUR AND C.SEQ_TIPO_OBJ_SEG = D.SEQ_TIPO_OBJ_SEG AND C.COD_TIPO_OBJ_SEG = D.COD_TIPO_OBJ_SEG AND D.COD_TIPO_OBJ_SEG = 2) WITH UR END-EXEC. */

            var r7000_SEL_COD_PESSOA_CRT_DB_SELECT_1_Query1 = new R7000_SEL_COD_PESSOA_CRT_DB_SELECT_1_Query1()
            {
                EF072_NUM_CONTRATO = EF072.DCLEF_CONTR_SEG_HABIT.EF072_NUM_CONTRATO.ToString(),
            };

            var executed_1 = R7000_SEL_COD_PESSOA_CRT_DB_SELECT_1_Query1.Execute(r7000_SEL_COD_PESSOA_CRT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.EF079_COD_PESSOA_CONTRTE, EF079.DCLEF_SEGURADO_OBJETO.EF079_COD_PESSOA_CONTRTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7000_FIM*/

        [StopWatch]
        /*" R8000-SEL-CONTRTE-CONTR */
        private void R8000_SEL_CONTRTE_CONTR(bool isPerform = false)
        {
            /*" -614- INITIALIZE EF047-COD-PESSOA-CONTRTE. */
            _.Initialize(
                EF047.DCLEF_CONTRTE_CONTR.EF047_COD_PESSOA_CONTRTE
            );

            /*" -615- MOVE '009' TO SI0202S-NUM-SQL. */
            _.Move("009", LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_NUM_SQL);

            /*" -625- PERFORM R8000_SEL_CONTRTE_CONTR_DB_SELECT_1 */

            R8000_SEL_CONTRTE_CONTR_DB_SELECT_1();

            /*" -628- IF (SQLCODE NOT = 0 AND 100) */

            if ((!DB.SQLCODE.In("0", "100")))
            {

                /*" -629- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO(); //GOTO
                return;

                /*" -629- END-IF. */
            }


        }

        [StopWatch]
        /*" R8000-SEL-CONTRTE-CONTR-DB-SELECT-1 */
        public void R8000_SEL_CONTRTE_CONTR_DB_SELECT_1()
        {
            /*" -625- EXEC SQL SELECT COD_PESSOA_CONTRTE INTO :EF047-COD-PESSOA-CONTRTE FROM SEGUROS.EF_CONTRTE_CONTR WHERE NUM_CONTRATO = :EF072-NUM-CONTRATO AND COD_PESSOA_CONTRTE = (SELECT MAX(B.COD_PESSOA_CONTRTE) FROM SEGUROS.EF_CONTRTE_CONTR B WHERE B.NUM_CONTRATO = :EF072-NUM-CONTRATO) WITH UR END-EXEC. */

            var r8000_SEL_CONTRTE_CONTR_DB_SELECT_1_Query1 = new R8000_SEL_CONTRTE_CONTR_DB_SELECT_1_Query1()
            {
                EF072_NUM_CONTRATO = EF072.DCLEF_CONTR_SEG_HABIT.EF072_NUM_CONTRATO.ToString(),
            };

            var executed_1 = R8000_SEL_CONTRTE_CONTR_DB_SELECT_1_Query1.Execute(r8000_SEL_CONTRTE_CONTR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.EF047_COD_PESSOA_CONTRTE, EF047.DCLEF_CONTRTE_CONTR.EF047_COD_PESSOA_CONTRTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_FIM*/

        [StopWatch]
        /*" R9000-SEL-ANTIGO-HABITACIONAL */
        private void R9000_SEL_ANTIGO_HABITACIONAL(bool isPerform = false)
        {
            /*" -638- MOVE SINIHAB1-OPERACAO TO ENDHABIT-OPERACAO. */
            _.Move(SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_OPERACAO, ENDHABIT.DCLENDERECO_HABIT.ENDHABIT_OPERACAO);

            /*" -639- MOVE SINIHAB1-PONTO-VENDA TO ENDHABIT-PONTO-VENDA. */
            _.Move(SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_PONTO_VENDA, ENDHABIT.DCLENDERECO_HABIT.ENDHABIT_PONTO_VENDA);

            /*" -641- MOVE SINIHAB1-NUM-CONTRATO TO ENDHABIT-NUM-CONTRATO. */
            _.Move(SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_NUM_CONTRATO, ENDHABIT.DCLENDERECO_HABIT.ENDHABIT_NUM_CONTRATO);

            /*" -647- INITIALIZE W-ENDHABIT-ENDERECO ENDHABIT-BAIRRO ENDHABIT-CIDADE ENDHABIT-UF ENDHABIT-CEP. */
            _.Initialize(
                W_ENDHABIT_ENDERECO
                , ENDHABIT.DCLENDERECO_HABIT.ENDHABIT_BAIRRO
                , ENDHABIT.DCLENDERECO_HABIT.ENDHABIT_CIDADE
                , ENDHABIT.DCLENDERECO_HABIT.ENDHABIT_UF
                , ENDHABIT.DCLENDERECO_HABIT.ENDHABIT_CEP
            );

            /*" -648- MOVE '010' TO SI0202S-NUM-SQL. */
            _.Move("010", LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_NUM_SQL);

            /*" -669- PERFORM R9000_SEL_ANTIGO_HABITACIONAL_DB_SELECT_1 */

            R9000_SEL_ANTIGO_HABITACIONAL_DB_SELECT_1();

            /*" -672- IF (SQLCODE NOT = 0 AND 100) */

            if ((!DB.SQLCODE.In("0", "100")))
            {

                /*" -673- GO TO R9999-ROT-ERRO */

                R9999_ROT_ERRO(); //GOTO
                return;

                /*" -675- END-IF. */
            }


            /*" -676- IF (SQLCODE = 100) */

            if ((DB.SQLCODE == 100))
            {

                /*" -677- MOVE 'ENDERECO NAO ENCONTRADO' TO SI0202S-MENSAGEM */
                _.Move("ENDERECO NAO ENCONTRADO", LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_MENSAGEM);

                /*" -681- END-IF. */
            }


            /*" -682- MOVE SPACE TO W-ENDERECO-ORIG-TEXT. */
            _.Move("", W_ENDERECO_ORIG_TEXT);

            /*" -683- MOVE SPACE TO W-NUM-CEP. */
            _.Move("", W_NUM_CEP);

            /*" -684- MOVE 0 TO W-ENDERECO-ORIG-LEN. */
            _.Move(0, W_ENDERECO_ORIG_LEN);

            /*" -685- MOVE W-ENDHABIT-ENDERECO TO W-ENDERECO-ORIG-TEXT. */
            _.Move(W_ENDHABIT_ENDERECO, W_ENDERECO_ORIG_TEXT);

            /*" -686- MOVE LENGTH OF W-ENDHABIT-ENDERECO TO W-ENDERECO-ORIG-LEN. */
            _.Move(W_ENDHABIT_ENDERECO.Value.Length, W_ENDERECO_ORIG_LEN);

            /*" -687- PERFORM R9500-TRIM-ENDERECO THRU R9500-FIM. */

            R9500_TRIM_ENDERECO(true);

            R9500_FIM(true);

            /*" -689- MOVE W-ENDERECO-TRIM-TEXT TO SI0202S-LOGRADOURO. */
            _.Move(W_ENDERECO_TRIM_TEXT, LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_LOGRADOURO);

            /*" -690- MOVE ENDHABIT-BAIRRO TO SI0202S-BAIRRO. */
            _.Move(ENDHABIT.DCLENDERECO_HABIT.ENDHABIT_BAIRRO, LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_BAIRRO);

            /*" -691- MOVE ENDHABIT-CIDADE TO SI0202S-CIDADE. */
            _.Move(ENDHABIT.DCLENDERECO_HABIT.ENDHABIT_CIDADE, LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_CIDADE);

            /*" -692- MOVE ENDHABIT-UF TO SI0202S-UF. */
            _.Move(ENDHABIT.DCLENDERECO_HABIT.ENDHABIT_UF, LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_UF);

            /*" -693- MOVE ENDHABIT-CEP TO SI0202S-CEP. */
            _.Move(ENDHABIT.DCLENDERECO_HABIT.ENDHABIT_CEP, LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_CEP);

            /*" -694- MOVE 'HB' TO SI0202S-ORIGEM. */
            _.Move("HB", LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_ORIGEM);

            /*" -694- PERFORM R9100-DEL-PONTO-VIRGULA THRU R9100-FIM. */

            R9100_DEL_PONTO_VIRGULA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R9100_FIM*/


        }

        [StopWatch]
        /*" R9000-SEL-ANTIGO-HABITACIONAL-DB-SELECT-1 */
        public void R9000_SEL_ANTIGO_HABITACIONAL_DB_SELECT_1()
        {
            /*" -669- EXEC SQL SELECT VALUE(TIPO_LOGRADOURO, ' ' ) || ' ' || NOME_LOGRADOURO || ' ' || VALUE(NUM_IMOVEL, ' ' ) || ' ' || VALUE(COMPL_ENDER, ' ' ) ,VALUE(BAIRRO, ' ' ) ,CIDADE ,UF ,CEP INTO :W-ENDHABIT-ENDERECO ,:ENDHABIT-BAIRRO ,:ENDHABIT-CIDADE ,:ENDHABIT-UF ,:ENDHABIT-CEP FROM SEGUROS.ENDERECO_HABIT WHERE OPERACAO = :ENDHABIT-OPERACAO AND PONTO_VENDA = :ENDHABIT-PONTO-VENDA AND NUM_CONTRATO = :ENDHABIT-NUM-CONTRATO AND OCORR_ENDER = 1 FETCH FIRST 1 ROW ONLY WITH UR END-EXEC. */

            var r9000_SEL_ANTIGO_HABITACIONAL_DB_SELECT_1_Query1 = new R9000_SEL_ANTIGO_HABITACIONAL_DB_SELECT_1_Query1()
            {
                ENDHABIT_NUM_CONTRATO = ENDHABIT.DCLENDERECO_HABIT.ENDHABIT_NUM_CONTRATO.ToString(),
                ENDHABIT_PONTO_VENDA = ENDHABIT.DCLENDERECO_HABIT.ENDHABIT_PONTO_VENDA.ToString(),
                ENDHABIT_OPERACAO = ENDHABIT.DCLENDERECO_HABIT.ENDHABIT_OPERACAO.ToString(),
            };

            var executed_1 = R9000_SEL_ANTIGO_HABITACIONAL_DB_SELECT_1_Query1.Execute(r9000_SEL_ANTIGO_HABITACIONAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.W_ENDHABIT_ENDERECO, W_ENDHABIT_ENDERECO);
                _.Move(executed_1.ENDHABIT_BAIRRO, ENDHABIT.DCLENDERECO_HABIT.ENDHABIT_BAIRRO);
                _.Move(executed_1.ENDHABIT_CIDADE, ENDHABIT.DCLENDERECO_HABIT.ENDHABIT_CIDADE);
                _.Move(executed_1.ENDHABIT_UF, ENDHABIT.DCLENDERECO_HABIT.ENDHABIT_UF);
                _.Move(executed_1.ENDHABIT_CEP, ENDHABIT.DCLENDERECO_HABIT.ENDHABIT_CEP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_FIM*/

        [StopWatch]
        /*" R9100-DEL-PONTO-VIRGULA */
        private void R9100_DEL_PONTO_VIRGULA(bool isPerform = false)
        {
            /*" -703- INSPECT SI0202S-LOGRADOURO REPLACING ALL ';' BY ' ' . */
            LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_LOGRADOURO.Replace(";", " ");

            /*" -704- INSPECT SI0202S-BAIRRO REPLACING ALL ';' BY ' ' . */
            LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_BAIRRO.Replace(";", " ");

            /*" -705- INSPECT SI0202S-CIDADE REPLACING ALL ';' BY ' ' . */
            LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_CIDADE.Replace(";", " ");

            /*" -705- INSPECT SI0202S-UF REPLACING ALL ';' BY ' ' . */
            LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_UF.Replace(";", " ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9100_FIM*/

        [StopWatch]
        /*" R9500-TRIM-ENDERECO */
        private void R9500_TRIM_ENDERECO(bool isPerform = false)
        {
            /*" -717- MOVE SPACE TO W-ENDERECO-TRIM-TEXT. */
            _.Move("", W_ENDERECO_TRIM_TEXT);

            /*" -719- MOVE 1 TO W-ENDERECO-TRIM-LEN. */
            _.Move(1, W_ENDERECO_TRIM_LEN);

            /*" -720- MOVE 1 TO W-POS. */
            _.Move(1, W_POS);

            /*" -721- MOVE 1 TO W-POS1. */
            _.Move(1, W_POS1);

            /*" -723- MOVE 'NAO' TO W-IND-SPACE. */
            _.Move("NAO", W_IND_SPACE);

            /*" -725- PERFORM UNTIL (W-ENDERECO-ORIG-TEXT(W-POS:1) NOT = SPACE) OR (W-POS > W-ENDERECO-ORIG-LEN) */

            while (!((W_ENDERECO_ORIG_TEXT.Substring(W_POS, 1) != " ") || (W_POS > W_ENDERECO_ORIG_LEN)))
            {

                /*" -726- ADD 1 TO W-POS */
                W_POS.Value = W_POS + 1;

                /*" -728- END-PERFORM. */
            }

            /*" -730- PERFORM UNTIL (W-POS > W-ENDERECO-ORIG-LEN) */

            while (!((W_POS > W_ENDERECO_ORIG_LEN)))
            {

                /*" -731- IF (W-ENDERECO-ORIG-TEXT(W-POS:1) NOT = SPACE) */

                if ((W_ENDERECO_ORIG_TEXT.Substring(W_POS, 1) != " "))
                {

                    /*" -733- MOVE W-ENDERECO-ORIG-TEXT(W-POS:1) TO W-ENDERECO-TRIM-TEXT(W-POS1:1) */
                    _.MoveAtPosition(W_ENDERECO_ORIG_TEXT.Substring(W_POS, 1), W_ENDERECO_TRIM_TEXT, W_POS1, 1);

                    /*" -734- ADD 1 TO W-POS1 */
                    W_POS1.Value = W_POS1 + 1;

                    /*" -735- MOVE 'NAO' TO W-IND-SPACE */
                    _.Move("NAO", W_IND_SPACE);

                    /*" -736- ELSE */
                }
                else
                {


                    /*" -738- IF (W-ENDERECO-ORIG-TEXT(W-POS:1) = SPACE) AND (W-IND-SPACE = 'NAO' ) */

                    if ((W_ENDERECO_ORIG_TEXT.Substring(W_POS, 1) == " ") && (W_IND_SPACE == "NAO"))
                    {

                        /*" -739- MOVE 'SIM' TO W-IND-SPACE */
                        _.Move("SIM", W_IND_SPACE);

                        /*" -740- MOVE SPACE TO W-ENDERECO-TRIM-TEXT(W-POS1:1) */
                        _.MoveAtPosition("", W_ENDERECO_TRIM_TEXT, W_POS1, 1);

                        /*" -741- ADD 1 TO W-POS1 */
                        W_POS1.Value = W_POS1 + 1;

                        /*" -742- END-IF */
                    }


                    /*" -743- END-IF */
                }


                /*" -744- ADD 1 TO W-POS */
                W_POS.Value = W_POS + 1;

                /*" -744- END-PERFORM. */
            }

        }

        [StopWatch]
        /*" R9500-FIM */
        private void R9500_FIM(bool isPerform = false)
        {
            /*" -749- PERFORM RXXXX-DEBUG. */

            RXXXX_DEBUG(true);

        }

        [StopWatch]
        /*" RXXXX-DEBUG */
        private void RXXXX_DEBUG(bool isPerform = false)
        {
            /*" -754- DISPLAY '===  SI0202S  ===================================' . */
            _.Display($"===  SI0202S  ===================================");

            /*" -755- DISPLAY 'NUM-APOL-SINISTRO   ' SI0202S-NUM-APOL-SINISTRO . */
            _.Display($"NUM-APOL-SINISTRO   {LBSI0202.SI0202S_PARAMETROS.SI0202S_ENTRADA.SI0202S_NUM_APOL_SINISTRO}");

            /*" -756- DISPLAY 'LOGRADOURO          ' SI0202S-LOGRADOURO . */
            _.Display($"LOGRADOURO          {LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_LOGRADOURO}");

            /*" -757- DISPLAY 'BAIRRO              ' SI0202S-BAIRRO . */
            _.Display($"BAIRRO              {LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_BAIRRO}");

            /*" -758- DISPLAY 'CIDADE              ' SI0202S-CIDADE . */
            _.Display($"CIDADE              {LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_CIDADE}");

            /*" -759- DISPLAY 'UF                  ' SI0202S-UF . */
            _.Display($"UF                  {LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_UF}");

            /*" -760- DISPLAY 'CEP                 ' SI0202S-CEP . */
            _.Display($"CEP                 {LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_CEP}");

            /*" -761- DISPLAY 'RC                  ' SI0202S-RC . */
            _.Display($"RC                  {LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_RC}");

            /*" -762- DISPLAY 'NUM-SQL             ' SI0202S-NUM-SQL . */
            _.Display($"NUM-SQL             {LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_NUM_SQL}");

            /*" -763- DISPLAY 'SQLCODE             ' SI0202S-SQLCODE . */
            _.Display($"SQLCODE             {LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_SQLCODE}");

            /*" -764- DISPLAY 'MENSAGEM            ' SI0202S-MENSAGEM . */
            _.Display($"MENSAGEM            {LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_MENSAGEM}");

            /*" -764- DISPLAY 'ORIGEM              ' SI0202S-ORIGEM . */
            _.Display($"ORIGEM              {LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_ORIGEM}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: RXXXX_FIM*/

        [StopWatch]
        /*" R9999-ROT-ERRO */
        private void R9999_ROT_ERRO(bool isPerform = false)
        {
            /*" -773- MOVE SQLCODE TO SI0202S-SQLCODE. */
            _.Move(DB.SQLCODE, LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_SQLCODE);

            /*" -775- MOVE 99 TO SI0202S-RC. */
            _.Move(99, LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_RC);

            /*" -776- IF (SI0202S-MENSAGEM = SPACE) */

            if ((LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_MENSAGEM == " "))
            {

                /*" -778- MOVE 'ERRO AO ACESSAR O BANCO DE DADOS' TO SI0202S-MENSAGEM */
                _.Move("ERRO AO ACESSAR O BANCO DE DADOS", LBSI0202.SI0202S_PARAMETROS.SI0202S_SAIDA.SI0202S_MENSAGEM);

                /*" -782- END-IF. */
            }


            /*" -782- GOBACK. */

            throw new GoBack();

        }
    }
}