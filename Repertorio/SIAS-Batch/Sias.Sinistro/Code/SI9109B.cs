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
using Sias.Sinistro.DB2.SI9109B;

namespace Code
{
    public class SI9109B
    {
        public bool IsCall { get; set; }

        public SI9109B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SINISTROS                          *      */
        /*"      *   PROGRAMA ...............  SI9109B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  PRODEXTER                          *      */
        /*"      *   PROGRAMADOR ............  PRODEXTER                          *      */
        /*"      *   DATA CODIFICACAO .......  MAIO/2003                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  REATIVACAOO DE SINISTRO A PARTIR   *      */
        /*"      *                             DE MOVIMENTO DE SINISTRO DO        *      */
        /*"      *                             CONVENIO AUTO VERA CRUZ            *      */
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
        /*"01       IND-COD-ERRO           PIC S9(004) VALUE +0 COMP.*/
        public IntBasis IND_COD_ERRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01       WFIM-SIARDEVC          PIC  X(001) VALUE SPACES.*/
        public StringBasis WFIM_SIARDEVC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01       AC-L-SIARDEVC          PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_L_SIARDEVC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-U-SIARDEVC          PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_U_SIARDEVC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-U-SINISMES          PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_U_SINISMES { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-I-SINISHIS          PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_I_SINISHIS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       WABEND.*/
        public SI9109B_WABEND WABEND { get; set; } = new SI9109B_WABEND();
        public class SI9109B_WABEND : VarBasis
        {
            /*"  05     FILLER                 PIC  X(010) VALUE        ' SI9109B'.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SI9109B");
            /*"  05     FILLER                 PIC  X(026) VALUE        ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"  05     WNR-EXEC-SQL           PIC  X(004) VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"  05     FILLER                 PIC  X(013) VALUE        ' *** SQLCODE '.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"  05     WSQLCODE               PIC  ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
        }


        public Dclgens.CALENDAR CALENDAR { get; set; } = new Dclgens.CALENDAR();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.SIARDEVC SIARDEVC { get; set; } = new Dclgens.SIARDEVC();
        public SI9109B_C01_SIARDEVC C01_SIARDEVC { get; set; } = new SI9109B_C01_SIARDEVC();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -70- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -71- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -72- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -72- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -80- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", WABEND.WNR_EXEC_SQL);

            /*" -81- PERFORM R0100-00-LE-SISTEMAS */

            R0100_00_LE_SISTEMAS_SECTION();

            /*" -83- PERFORM R0200-00-LE-CALENDAR */

            R0200_00_LE_CALENDAR_SECTION();

            /*" -84- PERFORM R0900-00-DECLARA-SIARDEVC */

            R0900_00_DECLARA_SIARDEVC_SECTION();

            /*" -86- PERFORM R0910-00-LE-SIARDEVC */

            R0910_00_LE_SIARDEVC_SECTION();

            /*" -88- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WFIM-SIARDEVC NOT EQUAL SPACES. */

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
            /*" -93- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -94- DISPLAY '*    SI9109B - FIM NORMAL    *' */
            _.Display($"*    SI9109B - FIM NORMAL    *");

            /*" -95- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -96- DISPLAY 'LIDOS     SIARDEVC - ' AC-L-SIARDEVC */
            _.Display($"LIDOS     SIARDEVC - {AC_L_SIARDEVC}");

            /*" -97- DISPLAY 'INSERIDOS SINISHIS - ' AC-I-SINISHIS */
            _.Display($"INSERIDOS SINISHIS - {AC_I_SINISHIS}");

            /*" -98- DISPLAY 'ALTERADOS SINISMES - ' AC-U-SINISMES */
            _.Display($"ALTERADOS SINISMES - {AC_U_SINISMES}");

            /*" -100- DISPLAY '          SIARDEVC - ' AC-U-SIARDEVC */
            _.Display($"          SIARDEVC - {AC_U_SIARDEVC}");

            /*" -102- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -102- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0100-00-LE-SISTEMAS-SECTION */
        private void R0100_00_LE_SISTEMAS_SECTION()
        {
            /*" -110- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", WABEND.WNR_EXEC_SQL);

            /*" -115- PERFORM R0100_00_LE_SISTEMAS_DB_SELECT_1 */

            R0100_00_LE_SISTEMAS_DB_SELECT_1();

            /*" -118- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -119- DISPLAY 'PROBLEMAS NO SELECT SISTEMAS' */
                _.Display($"PROBLEMAS NO SELECT SISTEMAS");

                /*" -121- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -122- DISPLAY 'DATA DO SISTEMA DE SINISTRO -' ' ' SISTEMAS-DATA-MOV-ABERTO. */

            $"DATA DO SISTEMA DE SINISTRO - {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}"
            .Display();

        }

        [StopWatch]
        /*" R0100-00-LE-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_LE_SISTEMAS_DB_SELECT_1()
        {
            /*" -115- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' END-EXEC. */

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
            /*" -132- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", WABEND.WNR_EXEC_SQL);

            /*" -139- PERFORM R0200_00_LE_CALENDAR_DB_SELECT_1 */

            R0200_00_LE_CALENDAR_DB_SELECT_1();

            /*" -142- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -143- DISPLAY 'PROBLEMAS NO SELECT CALENDARIO' */
                _.Display($"PROBLEMAS NO SELECT CALENDARIO");

                /*" -145- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -147- IF CALENDAR-DATA-CALENDARIO EQUAL '0001-01-01' */

            if (CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO == "0001-01-01")
            {

                /*" -148- DISPLAY 'DATA DO PROXIMO DIA UTIL NAO CADASTRADA' */
                _.Display($"DATA DO PROXIMO DIA UTIL NAO CADASTRADA");

                /*" -150- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -151- DISPLAY 'DATA DO PROXIMO DIA UTIL    -' ' ' CALENDAR-DATA-CALENDARIO. */

            $"DATA DO PROXIMO DIA UTIL    - {CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO}"
            .Display();

        }

        [StopWatch]
        /*" R0200-00-LE-CALENDAR-DB-SELECT-1 */
        public void R0200_00_LE_CALENDAR_DB_SELECT_1()
        {
            /*" -139- EXEC SQL SELECT VALUE(MIN(DATA_CALENDARIO), DATE( '0001-01-01' )) INTO :CALENDAR-DATA-CALENDARIO FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO > :SISTEMAS-DATA-MOV-ABERTO AND DIA_SEMANA NOT IN ( 'S' , 'D' ) AND FERIADO = ' ' END-EXEC. */

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
            /*" -161- MOVE '0900' TO WNR-EXEC-SQL. */
            _.Move("0900", WABEND.WNR_EXEC_SQL);

            /*" -184- PERFORM R0900_00_DECLARA_SIARDEVC_DB_DECLARE_1 */

            R0900_00_DECLARA_SIARDEVC_DB_DECLARE_1();

            /*" -186- PERFORM R0900_00_DECLARA_SIARDEVC_DB_OPEN_1 */

            R0900_00_DECLARA_SIARDEVC_DB_OPEN_1();

            /*" -189- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -190- DISPLAY 'PROBLEMAS NO OPEN SIARDEVC' */
                _.Display($"PROBLEMAS NO OPEN SIARDEVC");

                /*" -190- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARA-SIARDEVC-DB-DECLARE-1 */
        public void R0900_00_DECLARA_SIARDEVC_DB_DECLARE_1()
        {
            /*" -184- EXEC SQL DECLARE C01_SIARDEVC CURSOR FOR SELECT NOM_ARQUIVO, SEQ_GERACAO, TIPO_REGISTRO, SEQ_REGISTRO, NUM_APOL_SINISTRO, NUM_SINISTRO_VC, NUM_EXPEDIENTE_VC, COD_OPERACAO, NUM_APOLICE, NUM_ENDOSSO, NUM_ITEM, COD_COBERTURA, DATA_OCORRENCIA, VAL_TOT_MOVIMENTO FROM SEGUROS.SI_AR_DETALHE_VC WHERE NOM_ARQUIVO = 'VCMOVSIN' AND STA_PROCESSAMENTO = '0' AND COD_OPERACAO = 114 ORDER BY NUM_APOLICE, NUM_ITEM, DATA_OCORRENCIA END-EXEC. */
            C01_SIARDEVC = new SI9109B_C01_SIARDEVC(false);
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
							COD_COBERTURA
							, 
							DATA_OCORRENCIA
							, 
							VAL_TOT_MOVIMENTO 
							FROM SEGUROS.SI_AR_DETALHE_VC 
							WHERE NOM_ARQUIVO = 'VCMOVSIN' 
							AND STA_PROCESSAMENTO = '0' 
							AND COD_OPERACAO = 114 
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
            /*" -186- EXEC SQL OPEN C01_SIARDEVC END-EXEC. */

            C01_SIARDEVC.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-LE-SIARDEVC-SECTION */
        private void R0910_00_LE_SIARDEVC_SECTION()
        {
            /*" -200- MOVE '0910' TO WNR-EXEC-SQL. */
            _.Move("0910", WABEND.WNR_EXEC_SQL);

            /*" -215- PERFORM R0910_00_LE_SIARDEVC_DB_FETCH_1 */

            R0910_00_LE_SIARDEVC_DB_FETCH_1();

            /*" -218- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -219- ADD 1 TO AC-L-SIARDEVC */
                AC_L_SIARDEVC.Value = AC_L_SIARDEVC + 1;

                /*" -220- ELSE */
            }
            else
            {


                /*" -221- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -222- MOVE 'S' TO WFIM-SIARDEVC */
                    _.Move("S", WFIM_SIARDEVC);

                    /*" -222- PERFORM R0910_00_LE_SIARDEVC_DB_CLOSE_1 */

                    R0910_00_LE_SIARDEVC_DB_CLOSE_1();

                    /*" -224- ELSE */
                }
                else
                {


                    /*" -225- DISPLAY 'PROBLEMAS NO FETCH SIARDEVC' */
                    _.Display($"PROBLEMAS NO FETCH SIARDEVC");

                    /*" -225- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0910-00-LE-SIARDEVC-DB-FETCH-1 */
        public void R0910_00_LE_SIARDEVC_DB_FETCH_1()
        {
            /*" -215- EXEC SQL FETCH C01_SIARDEVC INTO :SIARDEVC-NOM-ARQUIVO, :SIARDEVC-SEQ-GERACAO, :SIARDEVC-TIPO-REGISTRO, :SIARDEVC-SEQ-REGISTRO, :SIARDEVC-NUM-APOL-SINISTRO, :SIARDEVC-NUM-SINISTRO-VC, :SIARDEVC-NUM-EXPEDIENTE-VC, :SIARDEVC-COD-OPERACAO, :SIARDEVC-NUM-APOLICE, :SIARDEVC-NUM-ENDOSSO, :SIARDEVC-NUM-ITEM, :SIARDEVC-COD-COBERTURA, :SIARDEVC-DATA-OCORRENCIA, :SIARDEVC-VAL-TOT-MOVIMENTO END-EXEC. */

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
                _.Move(C01_SIARDEVC.SIARDEVC_COD_COBERTURA, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_COBERTURA);
                _.Move(C01_SIARDEVC.SIARDEVC_DATA_OCORRENCIA, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_OCORRENCIA);
                _.Move(C01_SIARDEVC.SIARDEVC_VAL_TOT_MOVIMENTO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_TOT_MOVIMENTO);
            }

        }

        [StopWatch]
        /*" R0910-00-LE-SIARDEVC-DB-CLOSE-1 */
        public void R0910_00_LE_SIARDEVC_DB_CLOSE_1()
        {
            /*" -222- EXEC SQL CLOSE C01_SIARDEVC END-EXEC */

            C01_SIARDEVC.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -237- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", WABEND.WNR_EXEC_SQL);

            /*" -239- PERFORM R1100-00-LE-SINISMES */

            R1100_00_LE_SINISMES_SECTION();

            /*" -241- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -242- MOVE 18 TO SIARDEVC-COD-ERRO */
                _.Move(18, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO);

                /*" -243- MOVE 0 TO IND-COD-ERRO */
                _.Move(0, IND_COD_ERRO);

                /*" -244- MOVE '2' TO SIARDEVC-STA-PROCESSAMENTO */
                _.Move("2", SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO);

                /*" -245- MOVE ZEROS TO SIARDEVC-OCORR-HISTORICO */
                _.Move(0, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO);

                /*" -247- GO TO R1000-10-LER. */

                R1000_10_LER(); //GOTO
                return;
            }


            /*" -250- IF SINISMES-SIT-REGISTRO NOT EQUAL '2' */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_SIT_REGISTRO != "2")
            {

                /*" -251- MOVE 35 TO SIARDEVC-COD-ERRO */
                _.Move(35, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO);

                /*" -252- MOVE 0 TO IND-COD-ERRO */
                _.Move(0, IND_COD_ERRO);

                /*" -253- MOVE '2' TO SIARDEVC-STA-PROCESSAMENTO */
                _.Move("2", SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO);

                /*" -254- MOVE ZEROS TO SIARDEVC-OCORR-HISTORICO */
                _.Move(0, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO);

                /*" -258- GO TO R1000-10-LER. */

                R1000_10_LER(); //GOTO
                return;
            }


            /*" -260- PERFORM R1500-00-LE-SIARDEVC-AVISO */

            R1500_00_LE_SIARDEVC_AVISO_SECTION();

            /*" -263- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -264- MOVE 21 TO SIARDEVC-COD-ERRO */
                _.Move(21, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO);

                /*" -265- MOVE 0 TO IND-COD-ERRO */
                _.Move(0, IND_COD_ERRO);

                /*" -266- MOVE '2' TO SIARDEVC-STA-PROCESSAMENTO */
                _.Move("2", SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO);

                /*" -267- MOVE ZEROS TO SIARDEVC-OCORR-HISTORICO */
                _.Move(0, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO);

                /*" -268- GO TO R1000-10-LER */

                R1000_10_LER(); //GOTO
                return;

                /*" -269- ELSE */
            }
            else
            {


                /*" -277- IF SIARDEVC-NUM-SINISTRO-VC NOT EQUAL HOST-NUM-SINISTRO-VC OR SIARDEVC-NUM-EXPEDIENTE-VC NOT EQUAL HOST-NUM-EXPEDIENTE-VC OR SIARDEVC-COD-COBERTURA NOT EQUAL HOST-COD-COBERTURA */

                if (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_SINISTRO_VC != HOST_NUM_SINISTRO_VC || SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_EXPEDIENTE_VC != HOST_NUM_EXPEDIENTE_VC || SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_COBERTURA != HOST_COD_COBERTURA)
                {

                    /*" -278- MOVE 26 TO SIARDEVC-COD-ERRO */
                    _.Move(26, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO);

                    /*" -279- MOVE 0 TO IND-COD-ERRO */
                    _.Move(0, IND_COD_ERRO);

                    /*" -280- MOVE '2' TO SIARDEVC-STA-PROCESSAMENTO */
                    _.Move("2", SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO);

                    /*" -281- MOVE ZEROS TO SIARDEVC-OCORR-HISTORICO */
                    _.Move(0, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO);

                    /*" -283- GO TO R1000-10-LER. */

                    R1000_10_LER(); //GOTO
                    return;
                }

            }


            /*" -284- MOVE 0 TO SIARDEVC-COD-ERRO */
            _.Move(0, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO);

            /*" -286- MOVE -1 TO IND-COD-ERRO */
            _.Move(-1, IND_COD_ERRO);

            /*" -288- PERFORM R2000-00-GERA-REATIVACAO */

            R2000_00_GERA_REATIVACAO_SECTION();

            /*" -288- MOVE '1' TO SIARDEVC-STA-PROCESSAMENTO. */
            _.Move("1", SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO);

            /*" -0- FLUXCONTROL_PERFORM R1000_10_LER */

            R1000_10_LER();

        }

        [StopWatch]
        /*" R1000-10-LER */
        private void R1000_10_LER(bool isPerform = false)
        {
            /*" -294- PERFORM R3100-00-ALTERA-SIARDEVC */

            R3100_00_ALTERA_SIARDEVC_SECTION();

            /*" -294- PERFORM R0910-00-LE-SIARDEVC. */

            R0910_00_LE_SIARDEVC_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-LE-SINISMES-SECTION */
        private void R1100_00_LE_SINISMES_SECTION()
        {
            /*" -304- MOVE '1100' TO WNR-EXEC-SQL */
            _.Move("1100", WABEND.WNR_EXEC_SQL);

            /*" -317- PERFORM R1100_00_LE_SINISMES_DB_SELECT_1 */

            R1100_00_LE_SINISMES_DB_SELECT_1();

            /*" -320- IF SQLCODE NOT EQUAL 0 AND 100 */

            if (!DB.SQLCODE.In("0", "100"))
            {

                /*" -326- DISPLAY 'PROBLEMAS NO SELECT SINISTRO_MESTRE' ' ' SIARDEVC-NUM-APOL-SINISTRO ' ' SIARDEVC-NOM-ARQUIVO ' ' SIARDEVC-SEQ-GERACAO ' ' SIARDEVC-TIPO-REGISTRO ' ' SIARDEVC-SEQ-REGISTRO */

                $"PROBLEMAS NO SELECT SINISTRO_MESTRE {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_ARQUIVO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_GERACAO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_REGISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_REGISTRO}"
                .Display();

                /*" -326- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1100-00-LE-SINISMES-DB-SELECT-1 */
        public void R1100_00_LE_SINISMES_DB_SELECT_1()
        {
            /*" -317- EXEC SQL SELECT SIT_REGISTRO, SALDO_PAGAR_IX, COD_FONTE, COD_PRODUTO, OCORR_HISTORICO INTO :SINISMES-SIT-REGISTRO, :SINISMES-SALDO-PAGAR-IX, :SINISMES-COD-FONTE, :SINISMES-COD-PRODUTO, :SINISMES-OCORR-HISTORICO FROM SEGUROS.SINISTRO_MESTRE WHERE NUM_APOL_SINISTRO = :SIARDEVC-NUM-APOL-SINISTRO END-EXEC */

            var r1100_00_LE_SINISMES_DB_SELECT_1_Query1 = new R1100_00_LE_SINISMES_DB_SELECT_1_Query1()
            {
                SIARDEVC_NUM_APOL_SINISTRO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R1100_00_LE_SINISMES_DB_SELECT_1_Query1.Execute(r1100_00_LE_SINISMES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISMES_SIT_REGISTRO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_SIT_REGISTRO);
                _.Move(executed_1.SINISMES_SALDO_PAGAR_IX, SINISMES.DCLSINISTRO_MESTRE.SINISMES_SALDO_PAGAR_IX);
                _.Move(executed_1.SINISMES_COD_FONTE, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE);
                _.Move(executed_1.SINISMES_COD_PRODUTO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO);
                _.Move(executed_1.SINISMES_OCORR_HISTORICO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_OCORR_HISTORICO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-LE-SIARDEVC-AVISO-SECTION */
        private void R1500_00_LE_SIARDEVC_AVISO_SECTION()
        {
            /*" -336- MOVE '1500' TO WNR-EXEC-SQL */
            _.Move("1500", WABEND.WNR_EXEC_SQL);

            /*" -347- PERFORM R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1 */

            R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1();

            /*" -350- IF SQLCODE NOT EQUAL 0 AND 100 */

            if (!DB.SQLCODE.In("0", "100"))
            {

                /*" -356- DISPLAY 'PROBLEMAS NO SELECT SI_AR_DETALHE_VC' ' ' SIARDEVC-NUM-APOL-SINISTRO ' ' SIARDEVC-NOM-ARQUIVO ' ' SIARDEVC-SEQ-GERACAO ' ' SIARDEVC-TIPO-REGISTRO ' ' SIARDEVC-SEQ-REGISTRO */

                $"PROBLEMAS NO SELECT SI_AR_DETALHE_VC {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_ARQUIVO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_GERACAO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_REGISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_REGISTRO}"
                .Display();

                /*" -356- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1500-00-LE-SIARDEVC-AVISO-DB-SELECT-1 */
        public void R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1()
        {
            /*" -347- EXEC SQL SELECT NUM_SINISTRO_VC, NUM_EXPEDIENTE_VC, COD_COBERTURA INTO :HOST-NUM-SINISTRO-VC, :HOST-NUM-EXPEDIENTE-VC, :HOST-COD-COBERTURA FROM SEGUROS.SI_AR_DETALHE_VC WHERE NUM_APOL_SINISTRO = :SIARDEVC-NUM-APOL-SINISTRO AND COD_OPERACAO = 101 AND STA_PROCESSAMENTO = '1' END-EXEC */

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
        /*" R2000-00-GERA-REATIVACAO-SECTION */
        private void R2000_00_GERA_REATIVACAO_SECTION()
        {
            /*" -368- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", WABEND.WNR_EXEC_SQL);

            /*" -370- MOVE SIARDEVC-COD-OPERACAO TO SINISHIS-COD-OPERACAO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);

            /*" -372- MOVE '1' TO SINISHIS-SIT-REGISTRO */
            _.Move("1", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_REGISTRO);

            /*" -376- MOVE SPACES TO SINISHIS-NOME-FAVORECIDO SINISHIS-TIPO-FAVORECIDO SINISHIS-SIT-CONTABIL */
            _.Move("", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_TIPO_FAVORECIDO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL);

            /*" -381- ADD 1 TO SINISMES-OCORR-HISTORICO */
            SINISMES.DCLSINISTRO_MESTRE.SINISMES_OCORR_HISTORICO.Value = SINISMES.DCLSINISTRO_MESTRE.SINISMES_OCORR_HISTORICO + 1;

            /*" -384- MOVE SINISMES-OCORR-HISTORICO TO SIARDEVC-OCORR-HISTORICO */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_OCORR_HISTORICO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO);

            /*" -386- MOVE ZEROS TO SINISHIS-VAL-OPERACAO */
            _.Move(0, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);

            /*" -391- PERFORM R2100-00-INCLUI-SINISHIS */

            R2100_00_INCLUI_SINISHIS_SECTION();

            /*" -393- IF SIARDEVC-VAL-TOT-MOVIMENTO GREATER ZEROS */

            if (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_TOT_MOVIMENTO > 00)
            {

                /*" -394- MOVE 112 TO SINISHIS-COD-OPERACAO */
                _.Move(112, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);

                /*" -396- MOVE SIARDEVC-VAL-TOT-MOVIMENTO TO SINISHIS-VAL-OPERACAO */
                _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_TOT_MOVIMENTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);

                /*" -397- ADD 1 TO SINISMES-OCORR-HISTORICO */
                SINISMES.DCLSINISTRO_MESTRE.SINISMES_OCORR_HISTORICO.Value = SINISMES.DCLSINISTRO_MESTRE.SINISMES_OCORR_HISTORICO + 1;

                /*" -398- PERFORM R2100-00-INCLUI-SINISHIS */

                R2100_00_INCLUI_SINISHIS_SECTION();

                /*" -402- COMPUTE SINISMES-SALDO-PAGAR-IX = SINISMES-SALDO-PAGAR-IX + SINISHIS-VAL-OPERACAO. */
                SINISMES.DCLSINISTRO_MESTRE.SINISMES_SALDO_PAGAR_IX.Value = SINISMES.DCLSINISTRO_MESTRE.SINISMES_SALDO_PAGAR_IX + SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO;
            }


            /*" -403- MOVE '0' TO SINISMES-SIT-REGISTRO */
            _.Move("0", SINISMES.DCLSINISTRO_MESTRE.SINISMES_SIT_REGISTRO);

            /*" -403- PERFORM R2300-00-ALTERA-SINISMES. */

            R2300_00_ALTERA_SINISMES_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-INCLUI-SINISHIS-SECTION */
        private void R2100_00_INCLUI_SINISHIS_SECTION()
        {
            /*" -413- MOVE '2100' TO WNR-EXEC-SQL. */
            _.Move("2100", WABEND.WNR_EXEC_SQL);

            /*" -465- PERFORM R2100_00_INCLUI_SINISHIS_DB_INSERT_1 */

            R2100_00_INCLUI_SINISHIS_DB_INSERT_1();

            /*" -468- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -469- DISPLAY ' ' SQLCA */
                _.Display($" {DB.SQLCA}");

                /*" -478- DISPLAY 'PROBLEMAS NO INSERT SINISTRO_HISTORICO' ' ' SIARDEVC-NUM-APOL-SINISTRO ' ' SINISMES-OCORR-HISTORICO ' ' SINISHIS-COD-OPERACAO ' ' SIARDEVC-COD-OPERACAO ' ' SIARDEVC-NOM-ARQUIVO ' ' SIARDEVC-SEQ-GERACAO ' ' SIARDEVC-TIPO-REGISTRO ' ' SIARDEVC-SEQ-REGISTRO */

                $"PROBLEMAS NO INSERT SINISTRO_HISTORICO {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO} {SINISMES.DCLSINISTRO_MESTRE.SINISMES_OCORR_HISTORICO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_OPERACAO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_ARQUIVO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_GERACAO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_REGISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_REGISTRO}"
                .Display();

                /*" -480- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -480- ADD 1 TO AC-I-SINISHIS. */
            AC_I_SINISHIS.Value = AC_I_SINISHIS + 1;

        }

        [StopWatch]
        /*" R2100-00-INCLUI-SINISHIS-DB-INSERT-1 */
        public void R2100_00_INCLUI_SINISHIS_DB_INSERT_1()
        {
            /*" -465- EXEC SQL INSERT INTO SEGUROS.SINISTRO_HISTORICO (COD_EMPRESA, TIPO_REGISTRO, NUM_APOL_SINISTRO, OCORR_HISTORICO, COD_OPERACAO, DATA_MOVIMENTO, HORA_OPERACAO, NOME_FAVORECIDO, VAL_OPERACAO, DATA_LIM_CORRECAO, TIPO_FAVORECIDO, DATA_NEGOCIADA, FONTE_PAGAMENTO, COD_PREST_SERVICO, COD_SERVICO, ORDEM_PAGAMENTO, NUM_RECIBO, NUM_MOV_SINISTRO, COD_USUARIO, SIT_CONTABIL, SIT_REGISTRO, TIMESTAMP, NUM_APOLICE, COD_PRODUTO, NOM_PROGRAMA) VALUES (0, '1' , :SIARDEVC-NUM-APOL-SINISTRO, :SINISMES-OCORR-HISTORICO, :SINISHIS-COD-OPERACAO, :SISTEMAS-DATA-MOV-ABERTO, CURRENT TIME, :SINISHIS-NOME-FAVORECIDO, :SINISHIS-VAL-OPERACAO, '9999-12-31' , :SINISHIS-TIPO-FAVORECIDO, '9999-12-31' , :SINISMES-COD-FONTE, 0, 0, 0, 0, 0, 'VERACRUZ' , :SINISHIS-SIT-CONTABIL, :SINISHIS-SIT-REGISTRO, CURRENT TIMESTAMP , :SIARDEVC-NUM-APOLICE, :SINISMES-COD-PRODUTO, 'SI9109B' ) END-EXEC. */

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
        /*" R2300-00-ALTERA-SINISMES-SECTION */
        private void R2300_00_ALTERA_SINISMES_SECTION()
        {
            /*" -490- MOVE '2300' TO WNR-EXEC-SQL */
            _.Move("2300", WABEND.WNR_EXEC_SQL);

            /*" -496- PERFORM R2300_00_ALTERA_SINISMES_DB_UPDATE_1 */

            R2300_00_ALTERA_SINISMES_DB_UPDATE_1();

            /*" -499- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -505- DISPLAY 'PROBLEMAS NO UPDATE SINISTRO_MESTRE' ' ' SIARDEVC-NUM-APOL-SINISTRO ' ' SIARDEVC-NOM-ARQUIVO ' ' SIARDEVC-SEQ-GERACAO ' ' SIARDEVC-TIPO-REGISTRO ' ' SIARDEVC-SEQ-REGISTRO */

                $"PROBLEMAS NO UPDATE SINISTRO_MESTRE {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_ARQUIVO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_GERACAO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_REGISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_REGISTRO}"
                .Display();

                /*" -507- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -507- ADD 1 TO AC-U-SINISMES. */
            AC_U_SINISMES.Value = AC_U_SINISMES + 1;

        }

        [StopWatch]
        /*" R2300-00-ALTERA-SINISMES-DB-UPDATE-1 */
        public void R2300_00_ALTERA_SINISMES_DB_UPDATE_1()
        {
            /*" -496- EXEC SQL UPDATE SEGUROS.SINISTRO_MESTRE SET SIT_REGISTRO = :SINISMES-SIT-REGISTRO, OCORR_HISTORICO = :SINISMES-OCORR-HISTORICO, SALDO_PAGAR_IX = :SINISMES-SALDO-PAGAR-IX WHERE NUM_APOL_SINISTRO = :SIARDEVC-NUM-APOL-SINISTRO END-EXEC. */

            var r2300_00_ALTERA_SINISMES_DB_UPDATE_1_Update1 = new R2300_00_ALTERA_SINISMES_DB_UPDATE_1_Update1()
            {
                SINISMES_OCORR_HISTORICO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_OCORR_HISTORICO.ToString(),
                SINISMES_SALDO_PAGAR_IX = SINISMES.DCLSINISTRO_MESTRE.SINISMES_SALDO_PAGAR_IX.ToString(),
                SINISMES_SIT_REGISTRO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_SIT_REGISTRO.ToString(),
                SIARDEVC_NUM_APOL_SINISTRO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO.ToString(),
            };

            R2300_00_ALTERA_SINISMES_DB_UPDATE_1_Update1.Execute(r2300_00_ALTERA_SINISMES_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_EXIT*/

        [StopWatch]
        /*" R3100-00-ALTERA-SIARDEVC-SECTION */
        private void R3100_00_ALTERA_SIARDEVC_SECTION()
        {
            /*" -517- MOVE '3100' TO WNR-EXEC-SQL */
            _.Move("3100", WABEND.WNR_EXEC_SQL);

            /*" -530- PERFORM R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1 */

            R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1();

            /*" -533- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -538- DISPLAY 'PROBLEMAS NO UPDATE SI_AR_DETALHE_VC' ' ' SIARDEVC-NOM-ARQUIVO ' ' SIARDEVC-SEQ-GERACAO ' ' SIARDEVC-TIPO-REGISTRO ' ' SIARDEVC-SEQ-REGISTRO */

                $"PROBLEMAS NO UPDATE SI_AR_DETALHE_VC {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_ARQUIVO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_GERACAO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_REGISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_REGISTRO}"
                .Display();

                /*" -540- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -540- ADD 1 TO AC-U-SIARDEVC. */
            AC_U_SIARDEVC.Value = AC_U_SIARDEVC + 1;

        }

        [StopWatch]
        /*" R3100-00-ALTERA-SIARDEVC-DB-UPDATE-1 */
        public void R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1()
        {
            /*" -530- EXEC SQL UPDATE SEGUROS.SI_AR_DETALHE_VC SET STA_PROCESSAMENTO = :SIARDEVC-STA-PROCESSAMENTO, STA_RETORNO = '1' , OCORR_HISTORICO = :SIARDEVC-OCORR-HISTORICO, COD_ERRO = :SIARDEVC-COD-ERRO:IND-COD-ERRO WHERE NOM_ARQUIVO = :SIARDEVC-NOM-ARQUIVO AND SEQ_GERACAO = :SIARDEVC-SEQ-GERACAO AND TIPO_REGISTRO = :SIARDEVC-TIPO-REGISTRO AND SEQ_REGISTRO = :SIARDEVC-SEQ-REGISTRO END-EXEC */

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
            /*" -554- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -556- DISPLAY WABEND */
            _.Display(WABEND);

            /*" -557- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -558- DISPLAY '*    SI9109B - CANCELADO     *' */
            _.Display($"*    SI9109B - CANCELADO     *");

            /*" -560- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -560- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -564- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -564- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}