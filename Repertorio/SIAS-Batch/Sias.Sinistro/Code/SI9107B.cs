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
using Sias.Sinistro.DB2.SI9107B;

namespace Code
{
    public class SI9107B
    {
        public bool IsCall { get; set; }

        public SI9107B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SINISTROS                          *      */
        /*"      *   PROGRAMA ...............  SI9107B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  PRODEXTER                          *      */
        /*"      *   PROGRAMADOR ............  PRODEXTER                          *      */
        /*"      *   DATA CODIFICACAO .......  MAIO/2003                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  ALTERACAO DE CAUSA A PARTIR        *      */
        /*"      *                             DE MOVIMENTO DE SINISTRO DO        *      */
        /*"      *                             CONVENIO AUTO VERA CRUZ            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 13/05/2005 - PRODEXTER                                         *      */
        /*"      *   NAO PERMITE ALTERACAO DE CAUSA DE PT (PERDA TOTAL) PARA      *      */
        /*"      *   PP (PERDA PARCIAL), CASO HAJA SALVADO ATIVO (RESERVA <> 0)   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ESTE PROGRAMA FOI ALTERADA POR SOLICITACAO SSI 12179 INCLUINDO*      */
        /*"      *  NOVAS COBERTURAS E TRATANDO A NOVA CAUSA 6 RAMO 31 VIDROS.    *      */
        /*"      *  ALTERADO - ALEXIS VEAS ITURRIAGA EM 27/12/2006                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        /*"      *--------------------------------------                                 */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01       HOST-NUM-SINISTRO-VC   PIC S9(015) VALUE +0 COMP-3.*/
        public IntBasis HOST_NUM_SINISTRO_VC { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01       HOST-NUM-EXPEDIENTE-VC PIC S9(004) VALUE +0 COMP.*/
        public IntBasis HOST_NUM_EXPEDIENTE_VC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01       HOST-COD-COBERTURA     PIC S9(004) VALUE +0 COMP.*/
        public IntBasis HOST_COD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01       HOST-VAL-RESERVA       PIC S9(013)V99 VALUE +0 COMP-3.*/
        public DoubleBasis HOST_VAL_RESERVA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01       HOST-COUNT             PIC S9(004) VALUE +0 COMP.*/
        public IntBasis HOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01       IND-COD-ERRO           PIC S9(004) VALUE +0 COMP.*/
        public IntBasis IND_COD_ERRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01       WFIM-SIARDEVC          PIC  X(001) VALUE SPACES.*/
        public StringBasis WFIM_SIARDEVC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01       WS-GRUPO-CAUSAS-ATU    PIC  X(020) VALUE SPACES.*/
        public StringBasis WS_GRUPO_CAUSAS_ATU { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
        /*"01       AC-L-SIARDEVC          PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_L_SIARDEVC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-U-SIARDEVC          PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_U_SIARDEVC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-U-SINISMES          PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_U_SINISMES { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-I-SINISHIS          PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_I_SINISHIS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       WABEND.*/
        public SI9107B_WABEND WABEND { get; set; } = new SI9107B_WABEND();
        public class SI9107B_WABEND : VarBasis
        {
            /*"  05     FILLER                 PIC  X(010) VALUE        ' SI9107B'.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SI9107B");
            /*"  05     FILLER                 PIC  X(026) VALUE        ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"  05     WNR-EXEC-SQL           PIC  X(004) VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"  05     FILLER                 PIC  X(013) VALUE        ' *** SQLCODE '.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"  05     WSQLCODE               PIC  ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
        }


        public Copies.LBSI1001 LBSI1001 { get; set; } = new Copies.LBSI1001();
        public Dclgens.CALENDAR CALENDAR { get; set; } = new Dclgens.CALENDAR();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.SINISCAU SINISCAU { get; set; } = new Dclgens.SINISCAU();
        public Dclgens.SINIMPSE SINIMPSE { get; set; } = new Dclgens.SINIMPSE();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.SIARDEVC SIARDEVC { get; set; } = new Dclgens.SIARDEVC();
        public SI9107B_C01_SIARDEVC C01_SIARDEVC { get; set; } = new SI9107B_C01_SIARDEVC();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -89- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -90- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -91- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -91- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -99- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", WABEND.WNR_EXEC_SQL);

            /*" -100- PERFORM R0100-00-LE-SISTEMAS */

            R0100_00_LE_SISTEMAS_SECTION();

            /*" -102- PERFORM R0200-00-LE-CALENDAR */

            R0200_00_LE_CALENDAR_SECTION();

            /*" -103- PERFORM R0900-00-DECLARA-SIARDEVC */

            R0900_00_DECLARA_SIARDEVC_SECTION();

            /*" -105- PERFORM R0910-00-LE-SIARDEVC */

            R0910_00_LE_SIARDEVC_SECTION();

            /*" -106- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WFIM-SIARDEVC NOT EQUAL SPACES. */

            while (!(!WFIM_SIARDEVC.IsEmpty()))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -111- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -112- DISPLAY '*    SI9107B - FIM NORMAL    *' */
            _.Display($"*    SI9107B - FIM NORMAL    *");

            /*" -113- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -114- DISPLAY 'LIDOS     SIARDEVC - ' AC-L-SIARDEVC */
            _.Display($"LIDOS     SIARDEVC - {AC_L_SIARDEVC}");

            /*" -115- DISPLAY 'INSERIDOS SINISHIS - ' AC-I-SINISHIS */
            _.Display($"INSERIDOS SINISHIS - {AC_I_SINISHIS}");

            /*" -116- DISPLAY 'ALTERADOS SINISMES - ' AC-U-SINISMES */
            _.Display($"ALTERADOS SINISMES - {AC_U_SINISMES}");

            /*" -118- DISPLAY '          SIARDEVC - ' AC-U-SIARDEVC */
            _.Display($"          SIARDEVC - {AC_U_SIARDEVC}");

            /*" -120- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -120- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0100-00-LE-SISTEMAS-SECTION */
        private void R0100_00_LE_SISTEMAS_SECTION()
        {
            /*" -128- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", WABEND.WNR_EXEC_SQL);

            /*" -133- PERFORM R0100_00_LE_SISTEMAS_DB_SELECT_1 */

            R0100_00_LE_SISTEMAS_DB_SELECT_1();

            /*" -136- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -137- DISPLAY 'PROBLEMAS NO SELECT SISTEMAS' */
                _.Display($"PROBLEMAS NO SELECT SISTEMAS");

                /*" -139- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -140- DISPLAY 'DATA DO SISTEMA DE SINISTRO -' ' ' SISTEMAS-DATA-MOV-ABERTO. */

            $"DATA DO SISTEMA DE SINISTRO - {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}"
            .Display();

        }

        [StopWatch]
        /*" R0100-00-LE-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_LE_SISTEMAS_DB_SELECT_1()
        {
            /*" -133- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' END-EXEC. */

            var r0100_00_LE_SISTEMAS_DB_SELECT_1_Query1 = new R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1.Execute(r0100_00_LE_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-LE-CALENDAR-SECTION */
        private void R0200_00_LE_CALENDAR_SECTION()
        {
            /*" -150- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", WABEND.WNR_EXEC_SQL);

            /*" -157- PERFORM R0200_00_LE_CALENDAR_DB_SELECT_1 */

            R0200_00_LE_CALENDAR_DB_SELECT_1();

            /*" -160- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -161- DISPLAY 'PROBLEMAS NO SELECT CALENDARIO' */
                _.Display($"PROBLEMAS NO SELECT CALENDARIO");

                /*" -163- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -165- IF CALENDAR-DATA-CALENDARIO EQUAL '0001-01-01' */

            if (CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO == "0001-01-01")
            {

                /*" -166- DISPLAY 'DATA DO PROXIMO DIA UTIL NAO CADASTRADA' */
                _.Display($"DATA DO PROXIMO DIA UTIL NAO CADASTRADA");

                /*" -168- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -169- DISPLAY 'DATA DO PROXIMO DIA UTIL    -' ' ' CALENDAR-DATA-CALENDARIO. */

            $"DATA DO PROXIMO DIA UTIL    - {CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO}"
            .Display();

        }

        [StopWatch]
        /*" R0200-00-LE-CALENDAR-DB-SELECT-1 */
        public void R0200_00_LE_CALENDAR_DB_SELECT_1()
        {
            /*" -157- EXEC SQL SELECT VALUE(MIN(DATA_CALENDARIO), DATE( '0001-01-01' )) INTO :CALENDAR-DATA-CALENDARIO FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO > :SISTEMAS-DATA-MOV-ABERTO AND DIA_SEMANA NOT IN ( 'S' , 'D' ) AND FERIADO = ' ' END-EXEC. */

            var r0200_00_LE_CALENDAR_DB_SELECT_1_Query1 = new R0200_00_LE_CALENDAR_DB_SELECT_1_Query1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
            };

            var executed_1 = R0200_00_LE_CALENDAR_DB_SELECT_1_Query1.Execute(r0200_00_LE_CALENDAR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CALENDAR_DATA_CALENDARIO, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARA-SIARDEVC-SECTION */
        private void R0900_00_DECLARA_SIARDEVC_SECTION()
        {
            /*" -179- MOVE '0900' TO WNR-EXEC-SQL. */
            _.Move("0900", WABEND.WNR_EXEC_SQL);

            /*" -203- PERFORM R0900_00_DECLARA_SIARDEVC_DB_DECLARE_1 */

            R0900_00_DECLARA_SIARDEVC_DB_DECLARE_1();

            /*" -205- PERFORM R0900_00_DECLARA_SIARDEVC_DB_OPEN_1 */

            R0900_00_DECLARA_SIARDEVC_DB_OPEN_1();

            /*" -208- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -209- DISPLAY 'PROBLEMAS NO OPEN SIARDEVC' */
                _.Display($"PROBLEMAS NO OPEN SIARDEVC");

                /*" -209- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARA-SIARDEVC-DB-DECLARE-1 */
        public void R0900_00_DECLARA_SIARDEVC_DB_DECLARE_1()
        {
            /*" -203- EXEC SQL DECLARE C01_SIARDEVC CURSOR FOR SELECT NOM_ARQUIVO, SEQ_GERACAO, TIPO_REGISTRO, SEQ_REGISTRO, NUM_APOL_SINISTRO, NUM_SINISTRO_VC, NUM_EXPEDIENTE_VC, COD_OPERACAO, NUM_APOLICE, NUM_ENDOSSO, NUM_ITEM, COD_RAMO, COD_COBERTURA, COD_CAUSA, DATA_OCORRENCIA FROM SEGUROS.SI_AR_DETALHE_VC WHERE NOM_ARQUIVO = 'VCMOVSIN' AND STA_PROCESSAMENTO = '0' AND COD_OPERACAO = 501 ORDER BY NUM_APOLICE, NUM_ITEM, DATA_OCORRENCIA END-EXEC. */
            C01_SIARDEVC = new SI9107B_C01_SIARDEVC(false);
            string GetQuery_C01_SIARDEVC()
            {
                var query = @$"SELECT NOM_ARQUIVO
							, 
							SEQ_GERACAO
							, 
							TIPO_REGISTRO
							, 
							SEQ_REGISTRO
							, 
							NUM_APOL_SINISTRO
							, 
							NUM_SINISTRO_VC
							, 
							NUM_EXPEDIENTE_VC
							, 
							COD_OPERACAO
							, 
							NUM_APOLICE
							, 
							NUM_ENDOSSO
							, 
							NUM_ITEM
							, 
							COD_RAMO
							, 
							COD_COBERTURA
							, 
							COD_CAUSA
							, 
							DATA_OCORRENCIA 
							FROM SEGUROS.SI_AR_DETALHE_VC 
							WHERE NOM_ARQUIVO = 'VCMOVSIN' 
							AND STA_PROCESSAMENTO = '0' 
							AND COD_OPERACAO = 501 
							ORDER BY NUM_APOLICE
							, 
							NUM_ITEM
							, 
							DATA_OCORRENCIA";

                return query;
            }
            C01_SIARDEVC.GetQueryEvent += GetQuery_C01_SIARDEVC;

        }

        [StopWatch]
        /*" R0900-00-DECLARA-SIARDEVC-DB-OPEN-1 */
        public void R0900_00_DECLARA_SIARDEVC_DB_OPEN_1()
        {
            /*" -205- EXEC SQL OPEN C01_SIARDEVC END-EXEC. */

            C01_SIARDEVC.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-LE-SIARDEVC-SECTION */
        private void R0910_00_LE_SIARDEVC_SECTION()
        {
            /*" -219- MOVE '0910' TO WNR-EXEC-SQL. */
            _.Move("0910", WABEND.WNR_EXEC_SQL);

            /*" -235- PERFORM R0910_00_LE_SIARDEVC_DB_FETCH_1 */

            R0910_00_LE_SIARDEVC_DB_FETCH_1();

            /*" -238- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -239- ADD 1 TO AC-L-SIARDEVC */
                AC_L_SIARDEVC.Value = AC_L_SIARDEVC + 1;

                /*" -240- ELSE */
            }
            else
            {


                /*" -241- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -242- MOVE 'S' TO WFIM-SIARDEVC */
                    _.Move("S", WFIM_SIARDEVC);

                    /*" -242- PERFORM R0910_00_LE_SIARDEVC_DB_CLOSE_1 */

                    R0910_00_LE_SIARDEVC_DB_CLOSE_1();

                    /*" -244- ELSE */
                }
                else
                {


                    /*" -245- DISPLAY 'PROBLEMAS NO FETCH SIARDEVC' */
                    _.Display($"PROBLEMAS NO FETCH SIARDEVC");

                    /*" -245- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0910-00-LE-SIARDEVC-DB-FETCH-1 */
        public void R0910_00_LE_SIARDEVC_DB_FETCH_1()
        {
            /*" -235- EXEC SQL FETCH C01_SIARDEVC INTO :SIARDEVC-NOM-ARQUIVO, :SIARDEVC-SEQ-GERACAO, :SIARDEVC-TIPO-REGISTRO, :SIARDEVC-SEQ-REGISTRO, :SIARDEVC-NUM-APOL-SINISTRO, :SIARDEVC-NUM-SINISTRO-VC, :SIARDEVC-NUM-EXPEDIENTE-VC, :SIARDEVC-COD-OPERACAO, :SIARDEVC-NUM-APOLICE, :SIARDEVC-NUM-ENDOSSO, :SIARDEVC-NUM-ITEM, :SIARDEVC-COD-RAMO, :SIARDEVC-COD-COBERTURA, :SIARDEVC-COD-CAUSA, :SIARDEVC-DATA-OCORRENCIA END-EXEC. */

            if (C01_SIARDEVC.Fetch())
            {
                _.Move(C01_SIARDEVC.SIARDEVC_NOM_ARQUIVO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_ARQUIVO);
                _.Move(C01_SIARDEVC.SIARDEVC_SEQ_GERACAO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_GERACAO);
                _.Move(C01_SIARDEVC.SIARDEVC_TIPO_REGISTRO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_REGISTRO);
                _.Move(C01_SIARDEVC.SIARDEVC_SEQ_REGISTRO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_REGISTRO);
                _.Move(C01_SIARDEVC.SIARDEVC_NUM_APOL_SINISTRO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO);
                _.Move(C01_SIARDEVC.SIARDEVC_NUM_SINISTRO_VC, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_SINISTRO_VC);
                _.Move(C01_SIARDEVC.SIARDEVC_NUM_EXPEDIENTE_VC, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_EXPEDIENTE_VC);
                _.Move(C01_SIARDEVC.SIARDEVC_COD_OPERACAO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_OPERACAO);
                _.Move(C01_SIARDEVC.SIARDEVC_NUM_APOLICE, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE);
                _.Move(C01_SIARDEVC.SIARDEVC_NUM_ENDOSSO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_ENDOSSO);
                _.Move(C01_SIARDEVC.SIARDEVC_NUM_ITEM, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_ITEM);
                _.Move(C01_SIARDEVC.SIARDEVC_COD_RAMO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_RAMO);
                _.Move(C01_SIARDEVC.SIARDEVC_COD_COBERTURA, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_COBERTURA);
                _.Move(C01_SIARDEVC.SIARDEVC_COD_CAUSA, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_CAUSA);
                _.Move(C01_SIARDEVC.SIARDEVC_DATA_OCORRENCIA, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_OCORRENCIA);
            }

        }

        [StopWatch]
        /*" R0910-00-LE-SIARDEVC-DB-CLOSE-1 */
        public void R0910_00_LE_SIARDEVC_DB_CLOSE_1()
        {
            /*" -242- EXEC SQL CLOSE C01_SIARDEVC END-EXEC */

            C01_SIARDEVC.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -257- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", WABEND.WNR_EXEC_SQL);

            /*" -259- PERFORM R1100-00-LE-SINISMES */

            R1100_00_LE_SINISMES_SECTION();

            /*" -261- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -262- MOVE 18 TO SIARDEVC-COD-ERRO */
                _.Move(18, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO);

                /*" -263- MOVE 0 TO IND-COD-ERRO */
                _.Move(0, IND_COD_ERRO);

                /*" -264- MOVE '2' TO SIARDEVC-STA-PROCESSAMENTO */
                _.Move("2", SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO);

                /*" -265- MOVE ZEROS TO SIARDEVC-OCORR-HISTORICO */
                _.Move(0, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO);

                /*" -278- GO TO R1000-10-LER. */

                R1000_10_LER(); //GOTO
                return;
            }


            /*" -280- PERFORM R1500-00-LE-SIARDEVC-AVISO */

            R1500_00_LE_SIARDEVC_AVISO_SECTION();

            /*" -283- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -284- MOVE 21 TO SIARDEVC-COD-ERRO */
                _.Move(21, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO);

                /*" -285- MOVE 0 TO IND-COD-ERRO */
                _.Move(0, IND_COD_ERRO);

                /*" -286- MOVE '2' TO SIARDEVC-STA-PROCESSAMENTO */
                _.Move("2", SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO);

                /*" -287- MOVE ZEROS TO SIARDEVC-OCORR-HISTORICO */
                _.Move(0, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO);

                /*" -288- GO TO R1000-10-LER */

                R1000_10_LER(); //GOTO
                return;

                /*" -289- ELSE */
            }
            else
            {


                /*" -297- IF SIARDEVC-NUM-SINISTRO-VC NOT EQUAL HOST-NUM-SINISTRO-VC OR SIARDEVC-NUM-EXPEDIENTE-VC NOT EQUAL HOST-NUM-EXPEDIENTE-VC OR SIARDEVC-COD-COBERTURA NOT EQUAL HOST-COD-COBERTURA */

                if (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_SINISTRO_VC != HOST_NUM_SINISTRO_VC || SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_EXPEDIENTE_VC != HOST_NUM_EXPEDIENTE_VC || SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_COBERTURA != HOST_COD_COBERTURA)
                {

                    /*" -298- MOVE 26 TO SIARDEVC-COD-ERRO */
                    _.Move(26, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO);

                    /*" -299- MOVE 0 TO IND-COD-ERRO */
                    _.Move(0, IND_COD_ERRO);

                    /*" -300- MOVE '2' TO SIARDEVC-STA-PROCESSAMENTO */
                    _.Move("2", SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO);

                    /*" -301- MOVE ZEROS TO SIARDEVC-OCORR-HISTORICO */
                    _.Move(0, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO);

                    /*" -306- GO TO R1000-10-LER. */

                    R1000_10_LER(); //GOTO
                    return;
                }

            }


            /*" -322- PERFORM R1200-00-CONTA-INDENIZACAO */

            R1200_00_CONTA_INDENIZACAO_SECTION();

            /*" -334- PERFORM R1300-00-CONTA-LIBERACAO */

            R1300_00_CONTA_LIBERACAO_SECTION();

            /*" -336- MOVE SINISMES-RAMO TO SINISCAU-RAMO-EMISSOR */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO, SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_RAMO_EMISSOR);

            /*" -338- MOVE SINISMES-COD-CAUSA TO SINISCAU-COD-CAUSA */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA, SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_COD_CAUSA);

            /*" -340- PERFORM R1400-00-LE-SINISCAU */

            R1400_00_LE_SINISCAU_SECTION();

            /*" -341- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -349- DISPLAY 'CAUSA ATUAL DO SINISTRO NAO CADASTRADA' ' ' SIARDEVC-NUM-APOL-SINISTRO ' ' SIARDEVC-NOM-ARQUIVO ' ' SIARDEVC-SEQ-GERACAO ' ' SIARDEVC-TIPO-REGISTRO ' ' SIARDEVC-SEQ-REGISTRO ' ' SINISCAU-RAMO-EMISSOR ' ' SINISCAU-COD-CAUSA */

                $"CAUSA ATUAL DO SINISTRO NAO CADASTRADA {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_ARQUIVO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_GERACAO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_REGISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_REGISTRO} {SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_RAMO_EMISSOR} {SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_COD_CAUSA}"
                .Display();

                /*" -351- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -356- MOVE SINISCAU-GRUPO-CAUSAS TO WS-GRUPO-CAUSAS-ATU */
            _.Move(SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_GRUPO_CAUSAS, WS_GRUPO_CAUSAS_ATU);

            /*" -358- MOVE SIARDEVC-COD-RAMO TO SINISCAU-RAMO-EMISSOR */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_RAMO, SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_RAMO_EMISSOR);

            /*" -360- MOVE SIARDEVC-COD-CAUSA TO SINISCAU-COD-CAUSA */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_CAUSA, SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_COD_CAUSA);

            /*" -362- PERFORM R1400-00-LE-SINISCAU */

            R1400_00_LE_SINISCAU_SECTION();

            /*" -364- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -365- MOVE 33 TO SIARDEVC-COD-ERRO */
                _.Move(33, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO);

                /*" -366- MOVE 0 TO IND-COD-ERRO */
                _.Move(0, IND_COD_ERRO);

                /*" -367- MOVE '2' TO SIARDEVC-STA-PROCESSAMENTO */
                _.Move("2", SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO);

                /*" -368- MOVE ZEROS TO SIARDEVC-OCORR-HISTORICO */
                _.Move(0, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO);

                /*" -374- GO TO R1000-10-LER. */

                R1000_10_LER(); //GOTO
                return;
            }


            /*" -376- PERFORM R1600-00-RESERVA-SALVADO */

            R1600_00_RESERVA_SALVADO_SECTION();

            /*" -384- IF SI1001S-VALOR-CALCULADO NOT EQUAL ZEROS AND WS-GRUPO-CAUSAS-ATU EQUAL 'PT' AND SINISCAU-GRUPO-CAUSAS EQUAL 'PP' */

            if (LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_VALOR_CALCULADO != 00 && WS_GRUPO_CAUSAS_ATU == "PT" && SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_GRUPO_CAUSAS == "PP")
            {

                /*" -385- MOVE 52 TO SIARDEVC-COD-ERRO */
                _.Move(52, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO);

                /*" -386- MOVE 0 TO IND-COD-ERRO */
                _.Move(0, IND_COD_ERRO);

                /*" -387- MOVE '2' TO SIARDEVC-STA-PROCESSAMENTO */
                _.Move("2", SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO);

                /*" -388- MOVE ZEROS TO SIARDEVC-OCORR-HISTORICO */
                _.Move(0, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO);

                /*" -392- GO TO R1000-10-LER. */

                R1000_10_LER(); //GOTO
                return;
            }


            /*" -393- IF SINISMES-RAMO EQUAL 31 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO == 31)
            {

                /*" -394- IF SINISMES-COD-CAUSA EQUAL 6 */

                if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA == 6)
                {

                    /*" -395- MOVE 67 TO SIARDEVC-COD-ERRO */
                    _.Move(67, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO);

                    /*" -396- MOVE ZEROS TO IND-COD-ERRO */
                    _.Move(0, IND_COD_ERRO);

                    /*" -397- MOVE '2' TO SIARDEVC-STA-PROCESSAMENTO */
                    _.Move("2", SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO);

                    /*" -398- MOVE ZEROS TO SIARDEVC-OCORR-HISTORICO */
                    _.Move(0, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO);

                    /*" -399- GO TO R1000-10-LER */

                    R1000_10_LER(); //GOTO
                    return;

                    /*" -400- END-IF */
                }


                /*" -402- END-IF. */
            }


            /*" -403- MOVE 0 TO SIARDEVC-COD-ERRO */
            _.Move(0, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO);

            /*" -405- MOVE -1 TO IND-COD-ERRO */
            _.Move(-1, IND_COD_ERRO);

            /*" -407- PERFORM R2000-00-GERA-ALTERA-CAUSA */

            R2000_00_GERA_ALTERA_CAUSA_SECTION();

            /*" -407- MOVE '1' TO SIARDEVC-STA-PROCESSAMENTO. */
            _.Move("1", SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO);

            /*" -0- FLUXCONTROL_PERFORM R1000_10_LER */

            R1000_10_LER();

        }

        [StopWatch]
        /*" R1000-10-LER */
        private void R1000_10_LER(bool isPerform = false)
        {
            /*" -413- PERFORM R3100-00-ALTERA-SIARDEVC */

            R3100_00_ALTERA_SIARDEVC_SECTION();

            /*" -413- PERFORM R0910-00-LE-SIARDEVC. */

            R0910_00_LE_SIARDEVC_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-LE-SINISMES-SECTION */
        private void R1100_00_LE_SINISMES_SECTION()
        {
            /*" -423- MOVE '1100' TO WNR-EXEC-SQL */
            _.Move("1100", WABEND.WNR_EXEC_SQL);

            /*" -438- PERFORM R1100_00_LE_SINISMES_DB_SELECT_1 */

            R1100_00_LE_SINISMES_DB_SELECT_1();

            /*" -441- IF SQLCODE NOT EQUAL 0 AND 100 */

            if (!DB.SQLCODE.In("0", "100"))
            {

                /*" -447- DISPLAY 'PROBLEMAS NO SELECT SINISTRO_MESTRE' ' ' SIARDEVC-NUM-APOL-SINISTRO ' ' SIARDEVC-NOM-ARQUIVO ' ' SIARDEVC-SEQ-GERACAO ' ' SIARDEVC-TIPO-REGISTRO ' ' SIARDEVC-SEQ-REGISTRO */

                $"PROBLEMAS NO SELECT SINISTRO_MESTRE {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_ARQUIVO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_GERACAO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_REGISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_REGISTRO}"
                .Display();

                /*" -447- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1100-00-LE-SINISMES-DB-SELECT-1 */
        public void R1100_00_LE_SINISMES_DB_SELECT_1()
        {
            /*" -438- EXEC SQL SELECT SIT_REGISTRO, VALUE(RAMO, 0), COD_CAUSA, COD_FONTE, COD_PRODUTO, OCORR_HISTORICO INTO :SINISMES-SIT-REGISTRO, :SINISMES-RAMO, :SINISMES-COD-CAUSA, :SINISMES-COD-FONTE, :SINISMES-COD-PRODUTO, :SINISMES-OCORR-HISTORICO FROM SEGUROS.SINISTRO_MESTRE WHERE NUM_APOL_SINISTRO = :SIARDEVC-NUM-APOL-SINISTRO END-EXEC */

            var r1100_00_LE_SINISMES_DB_SELECT_1_Query1 = new R1100_00_LE_SINISMES_DB_SELECT_1_Query1()
            {
                SIARDEVC_NUM_APOL_SINISTRO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R1100_00_LE_SINISMES_DB_SELECT_1_Query1.Execute(r1100_00_LE_SINISMES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISMES_SIT_REGISTRO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_SIT_REGISTRO);
                _.Move(executed_1.SINISMES_RAMO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO);
                _.Move(executed_1.SINISMES_COD_CAUSA, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA);
                _.Move(executed_1.SINISMES_COD_FONTE, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE);
                _.Move(executed_1.SINISMES_COD_PRODUTO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO);
                _.Move(executed_1.SINISMES_OCORR_HISTORICO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_OCORR_HISTORICO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-CONTA-INDENIZACAO-SECTION */
        private void R1200_00_CONTA_INDENIZACAO_SECTION()
        {
            /*" -457- MOVE '1200' TO WNR-EXEC-SQL */
            _.Move("1200", WABEND.WNR_EXEC_SQL);

            /*" -464- PERFORM R1200_00_CONTA_INDENIZACAO_DB_SELECT_1 */

            R1200_00_CONTA_INDENIZACAO_DB_SELECT_1();

            /*" -467- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -473- DISPLAY 'PROBLEMAS NO COUNT1 SINISTRO_HISTORICO' ' ' SIARDEVC-NUM-APOL-SINISTRO ' ' SIARDEVC-NOM-ARQUIVO ' ' SIARDEVC-SEQ-GERACAO ' ' SIARDEVC-TIPO-REGISTRO ' ' SIARDEVC-SEQ-REGISTRO */

                $"PROBLEMAS NO COUNT1 SINISTRO_HISTORICO {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_ARQUIVO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_GERACAO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_REGISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_REGISTRO}"
                .Display();

                /*" -473- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1200-00-CONTA-INDENIZACAO-DB-SELECT-1 */
        public void R1200_00_CONTA_INDENIZACAO_DB_SELECT_1()
        {
            /*" -464- EXEC SQL SELECT VALUE(COUNT(*), 0) INTO :HOST-COUNT FROM SEGUROS.SINISTRO_HISTORICO WHERE NUM_APOL_SINISTRO = :SIARDEVC-NUM-APOL-SINISTRO AND COD_OPERACAO IN (1001, 1002, 1003, 1004) AND SIT_REGISTRO <> '2' END-EXEC. */

            var r1200_00_CONTA_INDENIZACAO_DB_SELECT_1_Query1 = new R1200_00_CONTA_INDENIZACAO_DB_SELECT_1_Query1()
            {
                SIARDEVC_NUM_APOL_SINISTRO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R1200_00_CONTA_INDENIZACAO_DB_SELECT_1_Query1.Execute(r1200_00_CONTA_INDENIZACAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_COUNT, HOST_COUNT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_EXIT*/

        [StopWatch]
        /*" R1300-00-CONTA-LIBERACAO-SECTION */
        private void R1300_00_CONTA_LIBERACAO_SECTION()
        {
            /*" -483- MOVE '1300' TO WNR-EXEC-SQL */
            _.Move("1300", WABEND.WNR_EXEC_SQL);

            /*" -491- PERFORM R1300_00_CONTA_LIBERACAO_DB_SELECT_1 */

            R1300_00_CONTA_LIBERACAO_DB_SELECT_1();

            /*" -494- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -500- DISPLAY 'PROBLEMAS NO COUNT2 SINISTRO_HISTORICO' ' ' SIARDEVC-NUM-APOL-SINISTRO ' ' SIARDEVC-NOM-ARQUIVO ' ' SIARDEVC-SEQ-GERACAO ' ' SIARDEVC-TIPO-REGISTRO ' ' SIARDEVC-SEQ-REGISTRO */

                $"PROBLEMAS NO COUNT2 SINISTRO_HISTORICO {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_ARQUIVO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_GERACAO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_REGISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_REGISTRO}"
                .Display();

                /*" -500- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1300-00-CONTA-LIBERACAO-DB-SELECT-1 */
        public void R1300_00_CONTA_LIBERACAO_DB_SELECT_1()
        {
            /*" -491- EXEC SQL SELECT VALUE(COUNT(*), 0) INTO :HOST-COUNT FROM SEGUROS.SINISTRO_HISTORICO WHERE NUM_APOL_SINISTRO = :SIARDEVC-NUM-APOL-SINISTRO AND COD_OPERACAO IN (1081, 1082, 1083, 1084, 1181, 1182, 1183, 1184) AND SIT_REGISTRO <> '2' END-EXEC. */

            var r1300_00_CONTA_LIBERACAO_DB_SELECT_1_Query1 = new R1300_00_CONTA_LIBERACAO_DB_SELECT_1_Query1()
            {
                SIARDEVC_NUM_APOL_SINISTRO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R1300_00_CONTA_LIBERACAO_DB_SELECT_1_Query1.Execute(r1300_00_CONTA_LIBERACAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_COUNT, HOST_COUNT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_EXIT*/

        [StopWatch]
        /*" R1400-00-LE-SINISCAU-SECTION */
        private void R1400_00_LE_SINISCAU_SECTION()
        {
            /*" -510- MOVE '1400' TO WNR-EXEC-SQL */
            _.Move("1400", WABEND.WNR_EXEC_SQL);

            /*" -516- PERFORM R1400_00_LE_SINISCAU_DB_SELECT_1 */

            R1400_00_LE_SINISCAU_DB_SELECT_1();

            /*" -519- IF SQLCODE NOT EQUAL 0 AND 100 */

            if (!DB.SQLCODE.In("0", "100"))
            {

                /*" -527- DISPLAY 'PROBLEMAS NO SELECT SINISTRO_CAUSA' ' ' SIARDEVC-NUM-APOL-SINISTRO ' ' SIARDEVC-NOM-ARQUIVO ' ' SIARDEVC-SEQ-GERACAO ' ' SIARDEVC-TIPO-REGISTRO ' ' SIARDEVC-SEQ-REGISTRO ' ' SINISCAU-RAMO-EMISSOR ' ' SINISCAU-COD-CAUSA */

                $"PROBLEMAS NO SELECT SINISTRO_CAUSA {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_ARQUIVO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_GERACAO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_REGISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_REGISTRO} {SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_RAMO_EMISSOR} {SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_COD_CAUSA}"
                .Display();

                /*" -527- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1400-00-LE-SINISCAU-DB-SELECT-1 */
        public void R1400_00_LE_SINISCAU_DB_SELECT_1()
        {
            /*" -516- EXEC SQL SELECT GRUPO_CAUSAS INTO :SINISCAU-GRUPO-CAUSAS FROM SEGUROS.SINISTRO_CAUSA WHERE RAMO_EMISSOR = :SINISCAU-RAMO-EMISSOR AND COD_CAUSA = :SINISCAU-COD-CAUSA END-EXEC */

            var r1400_00_LE_SINISCAU_DB_SELECT_1_Query1 = new R1400_00_LE_SINISCAU_DB_SELECT_1_Query1()
            {
                SINISCAU_RAMO_EMISSOR = SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_RAMO_EMISSOR.ToString(),
                SINISCAU_COD_CAUSA = SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_COD_CAUSA.ToString(),
            };

            var executed_1 = R1400_00_LE_SINISCAU_DB_SELECT_1_Query1.Execute(r1400_00_LE_SINISCAU_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISCAU_GRUPO_CAUSAS, SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_GRUPO_CAUSAS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-LE-SIARDEVC-AVISO-SECTION */
        private void R1500_00_LE_SIARDEVC_AVISO_SECTION()
        {
            /*" -537- MOVE '1500' TO WNR-EXEC-SQL */
            _.Move("1500", WABEND.WNR_EXEC_SQL);

            /*" -548- PERFORM R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1 */

            R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1();

            /*" -551- IF SQLCODE NOT EQUAL 0 AND 100 */

            if (!DB.SQLCODE.In("0", "100"))
            {

                /*" -557- DISPLAY 'PROBLEMAS NO SELECT SI_AR_DETALHE_VC' ' ' SIARDEVC-NUM-APOL-SINISTRO ' ' SIARDEVC-NOM-ARQUIVO ' ' SIARDEVC-SEQ-GERACAO ' ' SIARDEVC-TIPO-REGISTRO ' ' SIARDEVC-SEQ-REGISTRO */

                $"PROBLEMAS NO SELECT SI_AR_DETALHE_VC {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_ARQUIVO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_GERACAO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_REGISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_REGISTRO}"
                .Display();

                /*" -557- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1500-00-LE-SIARDEVC-AVISO-DB-SELECT-1 */
        public void R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1()
        {
            /*" -548- EXEC SQL SELECT NUM_SINISTRO_VC, NUM_EXPEDIENTE_VC, COD_COBERTURA INTO :HOST-NUM-SINISTRO-VC, :HOST-NUM-EXPEDIENTE-VC, :HOST-COD-COBERTURA FROM SEGUROS.SI_AR_DETALHE_VC WHERE NUM_APOL_SINISTRO = :SIARDEVC-NUM-APOL-SINISTRO AND COD_OPERACAO = 101 AND STA_PROCESSAMENTO = '1' END-EXEC */

            var r1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1_Query1 = new R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1_Query1()
            {
                SIARDEVC_NUM_APOL_SINISTRO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1_Query1.Execute(r1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_NUM_SINISTRO_VC, HOST_NUM_SINISTRO_VC);
                _.Move(executed_1.HOST_NUM_EXPEDIENTE_VC, HOST_NUM_EXPEDIENTE_VC);
                _.Move(executed_1.HOST_COD_COBERTURA, HOST_COD_COBERTURA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-RESERVA-SALVADO-SECTION */
        private void R1600_00_RESERVA_SALVADO_SECTION()
        {
            /*" -569- MOVE '1600' TO WNR-EXEC-SQL */
            _.Move("1600", WABEND.WNR_EXEC_SQL);

            /*" -571- INITIALIZE SI1001S-PARAMETROS */
            _.Initialize(
                LBSI1001.SI1001S_PARAMETROS
            );

            /*" -574- MOVE SIARDEVC-NUM-APOL-SINISTRO TO SI1001S-NUM-APOL-SINISTRO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO);

            /*" -576- CALL 'SI1032S' USING SI1001S-PARAMETROS */
            _.Call("SI1032S", LBSI1001.SI1001S_PARAMETROS);

            /*" -578- IF SI1001S-ERRO-MENSAGEM NOT EQUAL SPACES */

            if (!LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM.IsEmpty())
            {

                /*" -584- DISPLAY 'PROBLEMAS NO CALL DA SI1032S ' ' ' SIARDEVC-NUM-APOL-SINISTRO ' ' SIARDEVC-NOM-ARQUIVO ' ' SIARDEVC-SEQ-GERACAO ' ' SIARDEVC-TIPO-REGISTRO ' ' SIARDEVC-SEQ-REGISTRO */

                $"PROBLEMAS NO CALL DA SI1032S  {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_ARQUIVO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_GERACAO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_REGISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_REGISTRO}"
                .Display();

                /*" -585- DISPLAY 'SQLCODE.... ' SI1001S-ERRO-SQLCODE */
                _.Display($"SQLCODE.... {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_SQLCODE}");

                /*" -586- DISPLAY 'MENSAGEM... ' SI1001S-ERRO-MENSAGEM */
                _.Display($"MENSAGEM... {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM}");

                /*" -586- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-GERA-ALTERA-CAUSA-SECTION */
        private void R2000_00_GERA_ALTERA_CAUSA_SECTION()
        {
            /*" -598- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", WABEND.WNR_EXEC_SQL);

            /*" -600- MOVE SIARDEVC-COD-OPERACAO TO SINISHIS-COD-OPERACAO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);

            /*" -602- MOVE '1' TO SINISHIS-SIT-REGISTRO */
            _.Move("1", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_REGISTRO);

            /*" -605- MOVE SPACES TO SINISHIS-NOME-FAVORECIDO SINISHIS-TIPO-FAVORECIDO SINISHIS-SIT-CONTABIL */
            _.Move("", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_TIPO_FAVORECIDO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL);

            /*" -607- MOVE ZEROS TO SINISHIS-VAL-OPERACAO */
            _.Move(0, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);

            /*" -609- MOVE SIARDEVC-COD-CAUSA TO SINISMES-COD-CAUSA */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_CAUSA, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA);

            /*" -614- ADD 1 TO SINISMES-OCORR-HISTORICO */
            SINISMES.DCLSINISTRO_MESTRE.SINISMES_OCORR_HISTORICO.Value = SINISMES.DCLSINISTRO_MESTRE.SINISMES_OCORR_HISTORICO + 1;

            /*" -617- MOVE SINISMES-OCORR-HISTORICO TO SIARDEVC-OCORR-HISTORICO */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_OCORR_HISTORICO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO);

            /*" -619- PERFORM R2100-00-INCLUI-SINISHIS */

            R2100_00_INCLUI_SINISHIS_SECTION();

            /*" -621- PERFORM R2200-00-LE-SINIMPSE */

            R2200_00_LE_SINIMPSE_SECTION();

            /*" -623- PERFORM R2300-00-ALTERA-SINIMPSE */

            R2300_00_ALTERA_SINIMPSE_SECTION();

            /*" -624- ADD 1 TO SINIMPSE-OCORR-HISTORICO */
            SINIMPSE.DCLSINISTRO_IMP_SEG.SINIMPSE_OCORR_HISTORICO.Value = SINIMPSE.DCLSINISTRO_IMP_SEG.SINIMPSE_OCORR_HISTORICO + 1;

            /*" -626- PERFORM R2400-00-INCLUI-SINIMPSE */

            R2400_00_INCLUI_SINIMPSE_SECTION();

            /*" -626- PERFORM R2500-00-ALTERA-SINISMES. */

            R2500_00_ALTERA_SINISMES_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-INCLUI-SINISHIS-SECTION */
        private void R2100_00_INCLUI_SINISHIS_SECTION()
        {
            /*" -636- MOVE '2100' TO WNR-EXEC-SQL. */
            _.Move("2100", WABEND.WNR_EXEC_SQL);

            /*" -688- PERFORM R2100_00_INCLUI_SINISHIS_DB_INSERT_1 */

            R2100_00_INCLUI_SINISHIS_DB_INSERT_1();

            /*" -691- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -692- DISPLAY ' ' SQLCA */
                _.Display($" {DB.SQLCA}");

                /*" -701- DISPLAY 'PROBLEMAS NO INSERT SINISTRO_HISTORICO' ' ' SIARDEVC-NUM-APOL-SINISTRO ' ' SINISMES-OCORR-HISTORICO ' ' SINISHIS-COD-OPERACAO ' ' SIARDEVC-COD-OPERACAO ' ' SIARDEVC-NOM-ARQUIVO ' ' SIARDEVC-SEQ-GERACAO ' ' SIARDEVC-TIPO-REGISTRO ' ' SIARDEVC-SEQ-REGISTRO */

                $"PROBLEMAS NO INSERT SINISTRO_HISTORICO {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO} {SINISMES.DCLSINISTRO_MESTRE.SINISMES_OCORR_HISTORICO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_OPERACAO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_ARQUIVO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_GERACAO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_REGISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_REGISTRO}"
                .Display();

                /*" -703- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -703- ADD 1 TO AC-I-SINISHIS. */
            AC_I_SINISHIS.Value = AC_I_SINISHIS + 1;

        }

        [StopWatch]
        /*" R2100-00-INCLUI-SINISHIS-DB-INSERT-1 */
        public void R2100_00_INCLUI_SINISHIS_DB_INSERT_1()
        {
            /*" -688- EXEC SQL INSERT INTO SEGUROS.SINISTRO_HISTORICO (COD_EMPRESA, TIPO_REGISTRO, NUM_APOL_SINISTRO, OCORR_HISTORICO, COD_OPERACAO, DATA_MOVIMENTO, HORA_OPERACAO, NOME_FAVORECIDO, VAL_OPERACAO, DATA_LIM_CORRECAO, TIPO_FAVORECIDO, DATA_NEGOCIADA, FONTE_PAGAMENTO, COD_PREST_SERVICO, COD_SERVICO, ORDEM_PAGAMENTO, NUM_RECIBO, NUM_MOV_SINISTRO, COD_USUARIO, SIT_CONTABIL, SIT_REGISTRO, TIMESTAMP, NUM_APOLICE, COD_PRODUTO, NOM_PROGRAMA) VALUES (0, '1' , :SIARDEVC-NUM-APOL-SINISTRO, :SINISMES-OCORR-HISTORICO, :SINISHIS-COD-OPERACAO, :SISTEMAS-DATA-MOV-ABERTO, CURRENT TIME, :SINISHIS-NOME-FAVORECIDO, :SINISHIS-VAL-OPERACAO, '9999-12-31' , :SINISHIS-TIPO-FAVORECIDO, '9999-12-31' , :SINISMES-COD-FONTE, 0, 0, 0, 0, 0, 'VERACRUZ' , :SINISHIS-SIT-CONTABIL, :SINISHIS-SIT-REGISTRO, CURRENT TIMESTAMP , :SIARDEVC-NUM-APOLICE, :SINISMES-COD-PRODUTO, 'SI9107B' ) END-EXEC. */

            var r2100_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1 = new R2100_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1()
            {
                SIARDEVC_NUM_APOL_SINISTRO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO.ToString(),
                SINISMES_OCORR_HISTORICO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_OCORR_HISTORICO.ToString(),
                SINISHIS_COD_OPERACAO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                SINISHIS_NOME_FAVORECIDO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO.ToString(),
                SINISHIS_VAL_OPERACAO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO.ToString(),
                SINISHIS_TIPO_FAVORECIDO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_TIPO_FAVORECIDO.ToString(),
                SINISMES_COD_FONTE = SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE.ToString(),
                SINISHIS_SIT_CONTABIL = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL.ToString(),
                SINISHIS_SIT_REGISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_REGISTRO.ToString(),
                SIARDEVC_NUM_APOLICE = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE.ToString(),
                SINISMES_COD_PRODUTO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO.ToString(),
            };

            R2100_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1.Execute(r2100_00_INCLUI_SINISHIS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-LE-SINIMPSE-SECTION */
        private void R2200_00_LE_SINIMPSE_SECTION()
        {
            /*" -713- MOVE '2200' TO WNR-EXEC-SQL */
            _.Move("2200", WABEND.WNR_EXEC_SQL);

            /*" -728- PERFORM R2200_00_LE_SINIMPSE_DB_SELECT_1 */

            R2200_00_LE_SINIMPSE_DB_SELECT_1();

            /*" -731- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -737- DISPLAY 'PROBLEMAS NO SELECT SINISTRO_IMP_SEG' ' ' SIARDEVC-NUM-APOL-SINISTRO ' ' SIARDEVC-NOM-ARQUIVO ' ' SIARDEVC-SEQ-GERACAO ' ' SIARDEVC-TIPO-REGISTRO ' ' SIARDEVC-SEQ-REGISTRO */

                $"PROBLEMAS NO SELECT SINISTRO_IMP_SEG {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_ARQUIVO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_GERACAO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_REGISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_REGISTRO}"
                .Display();

                /*" -737- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2200-00-LE-SINIMPSE-DB-SELECT-1 */
        public void R2200_00_LE_SINIMPSE_DB_SELECT_1()
        {
            /*" -728- EXEC SQL SELECT A.OCORR_HISTORICO, A.VAL_IS_DATA_OCORR, A.DATA_OCORRENCIA INTO :SINIMPSE-OCORR-HISTORICO, :SINIMPSE-VAL-IS-DATA-OCORR, :SINIMPSE-DATA-OCORRENCIA FROM SEGUROS.SINISTRO_IMP_SEG A WHERE A.NUM_APOL_SINISTRO = :SIARDEVC-NUM-APOL-SINISTRO AND A.OCORR_HISTORICO = (SELECT MAX(B.OCORR_HISTORICO) FROM SEGUROS.SINISTRO_IMP_SEG B WHERE B.NUM_APOL_SINISTRO = A.NUM_APOL_SINISTRO) END-EXEC. */

            var r2200_00_LE_SINIMPSE_DB_SELECT_1_Query1 = new R2200_00_LE_SINIMPSE_DB_SELECT_1_Query1()
            {
                SIARDEVC_NUM_APOL_SINISTRO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R2200_00_LE_SINIMPSE_DB_SELECT_1_Query1.Execute(r2200_00_LE_SINIMPSE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINIMPSE_OCORR_HISTORICO, SINIMPSE.DCLSINISTRO_IMP_SEG.SINIMPSE_OCORR_HISTORICO);
                _.Move(executed_1.SINIMPSE_VAL_IS_DATA_OCORR, SINIMPSE.DCLSINISTRO_IMP_SEG.SINIMPSE_VAL_IS_DATA_OCORR);
                _.Move(executed_1.SINIMPSE_DATA_OCORRENCIA, SINIMPSE.DCLSINISTRO_IMP_SEG.SINIMPSE_DATA_OCORRENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_EXIT*/

        [StopWatch]
        /*" R2300-00-ALTERA-SINIMPSE-SECTION */
        private void R2300_00_ALTERA_SINIMPSE_SECTION()
        {
            /*" -747- MOVE '2300' TO WNR-EXEC-SQL */
            _.Move("2300", WABEND.WNR_EXEC_SQL);

            /*" -753- PERFORM R2300_00_ALTERA_SINIMPSE_DB_UPDATE_1 */

            R2300_00_ALTERA_SINIMPSE_DB_UPDATE_1();

            /*" -756- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -763- DISPLAY 'PROBLEMAS NO UPDATE SINISTRO_IMP_SEG' ' ' SIARDEVC-NUM-APOL-SINISTRO ' ' SINIMPSE-OCORR-HISTORICO ' ' SIARDEVC-NOM-ARQUIVO ' ' SIARDEVC-SEQ-GERACAO ' ' SIARDEVC-TIPO-REGISTRO ' ' SIARDEVC-SEQ-REGISTRO */

                $"PROBLEMAS NO UPDATE SINISTRO_IMP_SEG {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO} {SINIMPSE.DCLSINISTRO_IMP_SEG.SINIMPSE_OCORR_HISTORICO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_ARQUIVO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_GERACAO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_REGISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_REGISTRO}"
                .Display();

                /*" -763- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2300-00-ALTERA-SINIMPSE-DB-UPDATE-1 */
        public void R2300_00_ALTERA_SINIMPSE_DB_UPDATE_1()
        {
            /*" -753- EXEC SQL UPDATE SEGUROS.SINISTRO_IMP_SEG SET SIT_REGISTRO = '2' , TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_APOL_SINISTRO = :SIARDEVC-NUM-APOL-SINISTRO AND OCORR_HISTORICO = :SINIMPSE-OCORR-HISTORICO END-EXEC. */

            var r2300_00_ALTERA_SINIMPSE_DB_UPDATE_1_Update1 = new R2300_00_ALTERA_SINIMPSE_DB_UPDATE_1_Update1()
            {
                SIARDEVC_NUM_APOL_SINISTRO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO.ToString(),
                SINIMPSE_OCORR_HISTORICO = SINIMPSE.DCLSINISTRO_IMP_SEG.SINIMPSE_OCORR_HISTORICO.ToString(),
            };

            R2300_00_ALTERA_SINIMPSE_DB_UPDATE_1_Update1.Execute(r2300_00_ALTERA_SINIMPSE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_EXIT*/

        [StopWatch]
        /*" R2400-00-INCLUI-SINIMPSE-SECTION */
        private void R2400_00_INCLUI_SINIMPSE_SECTION()
        {
            /*" -773- MOVE '2400' TO WNR-EXEC-SQL */
            _.Move("2400", WABEND.WNR_EXEC_SQL);

            /*" -791- PERFORM R2400_00_INCLUI_SINIMPSE_DB_INSERT_1 */

            R2400_00_INCLUI_SINIMPSE_DB_INSERT_1();

            /*" -794- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -801- DISPLAY 'PROBLEMAS NO INSERT SINISTRO_IMP_SEG' ' ' SIARDEVC-NUM-APOL-SINISTRO ' ' SINIMPSE-OCORR-HISTORICO ' ' SIARDEVC-NOM-ARQUIVO ' ' SIARDEVC-SEQ-GERACAO ' ' SIARDEVC-TIPO-REGISTRO ' ' SIARDEVC-SEQ-REGISTRO */

                $"PROBLEMAS NO INSERT SINISTRO_IMP_SEG {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO} {SINIMPSE.DCLSINISTRO_IMP_SEG.SINIMPSE_OCORR_HISTORICO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_ARQUIVO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_GERACAO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_REGISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_REGISTRO}"
                .Display();

                /*" -801- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2400-00-INCLUI-SINIMPSE-DB-INSERT-1 */
        public void R2400_00_INCLUI_SINIMPSE_DB_INSERT_1()
        {
            /*" -791- EXEC SQL INSERT INTO SEGUROS.SINISTRO_IMP_SEG (NUM_APOL_SINISTRO, OCORR_HISTORICO, SIT_REGISTRO, COD_CAUSA, VAL_IS_DATA_OCORR, DATA_MOVIMENTO, DATA_OCORRENCIA, TIMESTAMP) VALUES (:SIARDEVC-NUM-APOL-SINISTRO, :SINIMPSE-OCORR-HISTORICO, ' ' , :SIARDEVC-COD-CAUSA, :SINIMPSE-VAL-IS-DATA-OCORR, :SISTEMAS-DATA-MOV-ABERTO, :SINIMPSE-DATA-OCORRENCIA, CURRENT TIMESTAMP) END-EXEC. */

            var r2400_00_INCLUI_SINIMPSE_DB_INSERT_1_Insert1 = new R2400_00_INCLUI_SINIMPSE_DB_INSERT_1_Insert1()
            {
                SIARDEVC_NUM_APOL_SINISTRO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO.ToString(),
                SINIMPSE_OCORR_HISTORICO = SINIMPSE.DCLSINISTRO_IMP_SEG.SINIMPSE_OCORR_HISTORICO.ToString(),
                SIARDEVC_COD_CAUSA = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_CAUSA.ToString(),
                SINIMPSE_VAL_IS_DATA_OCORR = SINIMPSE.DCLSINISTRO_IMP_SEG.SINIMPSE_VAL_IS_DATA_OCORR.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                SINIMPSE_DATA_OCORRENCIA = SINIMPSE.DCLSINISTRO_IMP_SEG.SINIMPSE_DATA_OCORRENCIA.ToString(),
            };

            R2400_00_INCLUI_SINIMPSE_DB_INSERT_1_Insert1.Execute(r2400_00_INCLUI_SINIMPSE_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_EXIT*/

        [StopWatch]
        /*" R2500-00-ALTERA-SINISMES-SECTION */
        private void R2500_00_ALTERA_SINISMES_SECTION()
        {
            /*" -811- MOVE '2500' TO WNR-EXEC-SQL */
            _.Move("2500", WABEND.WNR_EXEC_SQL);

            /*" -816- PERFORM R2500_00_ALTERA_SINISMES_DB_UPDATE_1 */

            R2500_00_ALTERA_SINISMES_DB_UPDATE_1();

            /*" -819- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -825- DISPLAY 'PROBLEMAS NO UPDATE SINISTRO_MESTRE' ' ' SIARDEVC-NUM-APOL-SINISTRO ' ' SIARDEVC-NOM-ARQUIVO ' ' SIARDEVC-SEQ-GERACAO ' ' SIARDEVC-TIPO-REGISTRO ' ' SIARDEVC-SEQ-REGISTRO */

                $"PROBLEMAS NO UPDATE SINISTRO_MESTRE {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_ARQUIVO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_GERACAO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_REGISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_REGISTRO}"
                .Display();

                /*" -827- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -827- ADD 1 TO AC-U-SINISMES. */
            AC_U_SINISMES.Value = AC_U_SINISMES + 1;

        }

        [StopWatch]
        /*" R2500-00-ALTERA-SINISMES-DB-UPDATE-1 */
        public void R2500_00_ALTERA_SINISMES_DB_UPDATE_1()
        {
            /*" -816- EXEC SQL UPDATE SEGUROS.SINISTRO_MESTRE SET COD_CAUSA = :SINISMES-COD-CAUSA, OCORR_HISTORICO = :SINISMES-OCORR-HISTORICO WHERE NUM_APOL_SINISTRO = :SIARDEVC-NUM-APOL-SINISTRO END-EXEC. */

            var r2500_00_ALTERA_SINISMES_DB_UPDATE_1_Update1 = new R2500_00_ALTERA_SINISMES_DB_UPDATE_1_Update1()
            {
                SINISMES_OCORR_HISTORICO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_OCORR_HISTORICO.ToString(),
                SINISMES_COD_CAUSA = SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA.ToString(),
                SIARDEVC_NUM_APOL_SINISTRO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO.ToString(),
            };

            R2500_00_ALTERA_SINISMES_DB_UPDATE_1_Update1.Execute(r2500_00_ALTERA_SINISMES_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_EXIT*/

        [StopWatch]
        /*" R3100-00-ALTERA-SIARDEVC-SECTION */
        private void R3100_00_ALTERA_SIARDEVC_SECTION()
        {
            /*" -837- MOVE '3100' TO WNR-EXEC-SQL */
            _.Move("3100", WABEND.WNR_EXEC_SQL);

            /*" -850- PERFORM R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1 */

            R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1();

            /*" -853- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -854- DISPLAY ' ' SQLCA */
                _.Display($" {DB.SQLCA}");

                /*" -859- DISPLAY 'PROBLEMAS NO UPDATE SI_AR_DETALHE_VC' ' ' SIARDEVC-NOM-ARQUIVO ' ' SIARDEVC-SEQ-GERACAO ' ' SIARDEVC-TIPO-REGISTRO ' ' SIARDEVC-SEQ-REGISTRO */

                $"PROBLEMAS NO UPDATE SI_AR_DETALHE_VC {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_ARQUIVO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_GERACAO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_REGISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_REGISTRO}"
                .Display();

                /*" -861- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -861- ADD 1 TO AC-U-SIARDEVC. */
            AC_U_SIARDEVC.Value = AC_U_SIARDEVC + 1;

        }

        [StopWatch]
        /*" R3100-00-ALTERA-SIARDEVC-DB-UPDATE-1 */
        public void R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1()
        {
            /*" -850- EXEC SQL UPDATE SEGUROS.SI_AR_DETALHE_VC SET STA_PROCESSAMENTO = :SIARDEVC-STA-PROCESSAMENTO, STA_RETORNO = '1' , OCORR_HISTORICO = :SIARDEVC-OCORR-HISTORICO, COD_ERRO = :SIARDEVC-COD-ERRO:IND-COD-ERRO WHERE NOM_ARQUIVO = :SIARDEVC-NOM-ARQUIVO AND SEQ_GERACAO = :SIARDEVC-SEQ-GERACAO AND TIPO_REGISTRO = :SIARDEVC-TIPO-REGISTRO AND SEQ_REGISTRO = :SIARDEVC-SEQ-REGISTRO END-EXEC */

            var r3100_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1 = new R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1()
            {
                SIARDEVC_COD_ERRO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO.ToString(),
                IND_COD_ERRO = IND_COD_ERRO.ToString(),
                SIARDEVC_STA_PROCESSAMENTO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO.ToString(),
                SIARDEVC_OCORR_HISTORICO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO.ToString(),
                SIARDEVC_TIPO_REGISTRO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_REGISTRO.ToString(),
                SIARDEVC_SEQ_REGISTRO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_REGISTRO.ToString(),
                SIARDEVC_NOM_ARQUIVO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_ARQUIVO.ToString(),
                SIARDEVC_SEQ_GERACAO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_GERACAO.ToString(),
            };

            R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1.Execute(r3100_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -875- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -877- DISPLAY WABEND */
            _.Display(WABEND);

            /*" -878- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -879- DISPLAY '*    SI9107B - CANCELADO     *' */
            _.Display($"*    SI9107B - CANCELADO     *");

            /*" -881- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -881- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -885- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -885- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}