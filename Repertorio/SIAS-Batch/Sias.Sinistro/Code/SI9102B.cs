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
using Sias.Sinistro.DB2.SI9102B;

namespace Code
{
    public class SI9102B
    {
        public bool IsCall { get; set; }

        public SI9102B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SINISTROS                          *      */
        /*"      *   PROGRAMA ...............  SI9102B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  PRODEXTER                          *      */
        /*"      *   PROGRAMADOR ............  PRODEXTER                          *      */
        /*"      *   DATA CODIFICACAO .......  MAIO/2003                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  PAGAMENTO DE INDENIZACAO (EXCETO   *      */
        /*"      *                             OFICINA) A PARTIR DE MOVIMENTO     *      */
        /*"      *                             DE SINISTRO DO CONVENIO AUTO       *      */
        /*"      *                             VERA CRUZ                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ESTE PROGRAMA FOI ALTERADA POR SOLICITACAO SSI 12179 INCLUINDO*      */
        /*"      *  NOVAS COBERTURAS E TRATANDO A NOVA CAUSA 6 RAMO 31 VIDROS.    *      */
        /*"      *  ALTERADO - ALEXIS VEAS ITURRIAGA EM 22/11/2006                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO:  25/08/08   WELLINGTON VERAS (POLITEC)              *      */
        /*"      *    PROJETO FGV                                                 *      */
        /*"      *    INCLUSAO DA CLAUSULA WITH UR NO COMANDO SELECT   - WV0808   *      */
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
        /*"01       HOST-QTD-PARCELA-PEND  PIC S9(004) VALUE +0 COMP.*/
        public IntBasis HOST_QTD_PARCELA_PEND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01       HOST-COUNT             PIC S9(004) VALUE +0 COMP.*/
        public IntBasis HOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01       IND-COD-ERRO           PIC S9(004) VALUE +0 COMP.*/
        public IntBasis IND_COD_ERRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01       WFIM-SIARDEVC          PIC  X(001) VALUE SPACES.*/
        public StringBasis WFIM_SIARDEVC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01       AC-L-SIARDEVC          PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_L_SIARDEVC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-U-SIARDEVC          PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_U_SIARDEVC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       WABEND.*/
        public SI9102B_WABEND WABEND { get; set; } = new SI9102B_WABEND();
        public class SI9102B_WABEND : VarBasis
        {
            /*"  05     FILLER                 PIC  X(010) VALUE        ' SI9102B'.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SI9102B");
            /*"  05     FILLER                 PIC  X(026) VALUE        ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"  05     WNR-EXEC-SQL           PIC  X(004) VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"  05     FILLER                 PIC  X(013) VALUE        ' *** SQLCODE '.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"  05     WSQLCODE               PIC  ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
        }


        public Dclgens.SINISCAU SINISCAU { get; set; } = new Dclgens.SINISCAU();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.PARCELAS PARCELAS { get; set; } = new Dclgens.PARCELAS();
        public Dclgens.SIARDEVC SIARDEVC { get; set; } = new Dclgens.SIARDEVC();
        public Dclgens.FONTES FONTES { get; set; } = new Dclgens.FONTES();
        public SI9102B_C01_SIARDEVC C01_SIARDEVC { get; set; } = new SI9102B_C01_SIARDEVC();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -81- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -82- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -83- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -83- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -91- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", WABEND.WNR_EXEC_SQL);

            /*" -93- PERFORM R0100-00-LE-SISTEMAS */

            R0100_00_LE_SISTEMAS_SECTION();

            /*" -94- PERFORM R0900-00-DECLARA-SIARDEVC */

            R0900_00_DECLARA_SIARDEVC_SECTION();

            /*" -96- PERFORM R0910-00-LE-SIARDEVC */

            R0910_00_LE_SIARDEVC_SECTION();

            /*" -97- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WFIM-SIARDEVC NOT EQUAL SPACES. */

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
            /*" -102- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -103- DISPLAY '*    SI9102B - FIM NORMAL    *' */
            _.Display($"*    SI9102B - FIM NORMAL    *");

            /*" -104- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -105- DISPLAY 'LIDOS     SIARDEVC - ' AC-L-SIARDEVC */
            _.Display($"LIDOS     SIARDEVC - {AC_L_SIARDEVC}");

            /*" -107- DISPLAY 'ALTERADOS SIARDEVC - ' AC-U-SIARDEVC */
            _.Display($"ALTERADOS SIARDEVC - {AC_U_SIARDEVC}");

            /*" -109- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -109- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0100-00-LE-SISTEMAS-SECTION */
        private void R0100_00_LE_SISTEMAS_SECTION()
        {
            /*" -117- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", WABEND.WNR_EXEC_SQL);

            /*" -123- PERFORM R0100_00_LE_SISTEMAS_DB_SELECT_1 */

            R0100_00_LE_SISTEMAS_DB_SELECT_1();

            /*" -126- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -127- DISPLAY 'PROBLEMAS NO SELECT SISTEMAS' */
                _.Display($"PROBLEMAS NO SELECT SISTEMAS");

                /*" -129- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -130- DISPLAY 'DATA DO SISTEMA DE SINISTRO -' ' ' SISTEMAS-DATA-MOV-ABERTO. */

            $"DATA DO SISTEMA DE SINISTRO - {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}"
            .Display();

        }

        [StopWatch]
        /*" R0100-00-LE-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_LE_SISTEMAS_DB_SELECT_1()
        {
            /*" -123- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' WITH UR END-EXEC. */

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
        /*" R0900-00-DECLARA-SIARDEVC-SECTION */
        private void R0900_00_DECLARA_SIARDEVC_SECTION()
        {
            /*" -140- MOVE '0900' TO WNR-EXEC-SQL. */
            _.Move("0900", WABEND.WNR_EXEC_SQL);

            /*" -181- PERFORM R0900_00_DECLARA_SIARDEVC_DB_DECLARE_1 */

            R0900_00_DECLARA_SIARDEVC_DB_DECLARE_1();

            /*" -183- PERFORM R0900_00_DECLARA_SIARDEVC_DB_OPEN_1 */

            R0900_00_DECLARA_SIARDEVC_DB_OPEN_1();

            /*" -186- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -187- DISPLAY 'PROBLEMAS NO OPEN SIARDEVC' */
                _.Display($"PROBLEMAS NO OPEN SIARDEVC");

                /*" -187- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARA-SIARDEVC-DB-DECLARE-1 */
        public void R0900_00_DECLARA_SIARDEVC_DB_DECLARE_1()
        {
            /*" -181- EXEC SQL DECLARE C01_SIARDEVC CURSOR FOR SELECT NOM_ARQUIVO, SEQ_GERACAO, TIPO_REGISTRO, SEQ_REGISTRO, NUM_APOL_SINISTRO, NUM_SINISTRO_VC, NUM_EXPEDIENTE_VC, IND_FAVORECIDO, CGCCPF, NOM_FAVORECIDO, COD_OPERACAO, NUM_APOLICE, NUM_ENDOSSO, NUM_ITEM, COD_RAMO, COD_COBERTURA, DATA_OCORRENCIA, DATA_NEGOCIADA, COD_CAUSA, IND_FORMA_PAGTO, VAL_TOT_MOVIMENTO, STA_RETORNO, VALUE(COD_FONTE, 0) FROM SEGUROS.SI_AR_DETALHE_VC WHERE NOM_ARQUIVO = 'VCMOVSIN' AND STA_PROCESSAMENTO = '0' AND COD_OPERACAO = 1081 AND IND_FAVORECIDO <> '2' AND (IND_FAVORECIDO IN ( '1' , '3' , '4' , '6' ) OR (COD_CAUSA <> 6 AND IND_FAVORECIDO = '5' )) ORDER BY NUM_APOLICE, NUM_ITEM, DATA_OCORRENCIA END-EXEC. */
            C01_SIARDEVC = new SI9102B_C01_SIARDEVC(false);
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
							IND_FAVORECIDO
							, 
							CGCCPF
							, 
							NOM_FAVORECIDO
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
							DATA_OCORRENCIA
							, 
							DATA_NEGOCIADA
							, 
							COD_CAUSA
							, 
							IND_FORMA_PAGTO
							, 
							VAL_TOT_MOVIMENTO
							, 
							STA_RETORNO
							, 
							VALUE(COD_FONTE
							, 0) 
							FROM SEGUROS.SI_AR_DETALHE_VC 
							WHERE NOM_ARQUIVO = 'VCMOVSIN' 
							AND STA_PROCESSAMENTO = '0' 
							AND COD_OPERACAO = 1081 
							AND IND_FAVORECIDO <> '2' 
							AND (IND_FAVORECIDO IN ( '1'
							, '3'
							, '4'
							, '6' ) 
							OR (COD_CAUSA <> 6 
							AND IND_FAVORECIDO = '5' )) 
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
            /*" -183- EXEC SQL OPEN C01_SIARDEVC END-EXEC. */

            C01_SIARDEVC.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-LE-SIARDEVC-SECTION */
        private void R0910_00_LE_SIARDEVC_SECTION()
        {
            /*" -197- MOVE '0910' TO WNR-EXEC-SQL. */
            _.Move("0910", WABEND.WNR_EXEC_SQL);

            /*" -221- PERFORM R0910_00_LE_SIARDEVC_DB_FETCH_1 */

            R0910_00_LE_SIARDEVC_DB_FETCH_1();

            /*" -224- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -225- ADD 1 TO AC-L-SIARDEVC */
                AC_L_SIARDEVC.Value = AC_L_SIARDEVC + 1;

                /*" -226- ELSE */
            }
            else
            {


                /*" -227- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -228- MOVE 'S' TO WFIM-SIARDEVC */
                    _.Move("S", WFIM_SIARDEVC);

                    /*" -228- PERFORM R0910_00_LE_SIARDEVC_DB_CLOSE_1 */

                    R0910_00_LE_SIARDEVC_DB_CLOSE_1();

                    /*" -230- ELSE */
                }
                else
                {


                    /*" -231- DISPLAY 'PROBLEMAS NO FETCH SIARDEVC' */
                    _.Display($"PROBLEMAS NO FETCH SIARDEVC");

                    /*" -231- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0910-00-LE-SIARDEVC-DB-FETCH-1 */
        public void R0910_00_LE_SIARDEVC_DB_FETCH_1()
        {
            /*" -221- EXEC SQL FETCH C01_SIARDEVC INTO :SIARDEVC-NOM-ARQUIVO, :SIARDEVC-SEQ-GERACAO, :SIARDEVC-TIPO-REGISTRO, :SIARDEVC-SEQ-REGISTRO, :SIARDEVC-NUM-APOL-SINISTRO, :SIARDEVC-NUM-SINISTRO-VC, :SIARDEVC-NUM-EXPEDIENTE-VC, :SIARDEVC-IND-FAVORECIDO, :SIARDEVC-CGCCPF, :SIARDEVC-NOM-FAVORECIDO, :SIARDEVC-COD-OPERACAO, :SIARDEVC-NUM-APOLICE, :SIARDEVC-NUM-ENDOSSO, :SIARDEVC-NUM-ITEM, :SIARDEVC-COD-RAMO, :SIARDEVC-COD-COBERTURA, :SIARDEVC-DATA-OCORRENCIA, :SIARDEVC-DATA-NEGOCIADA, :SIARDEVC-COD-CAUSA, :SIARDEVC-IND-FORMA-PAGTO, :SIARDEVC-VAL-TOT-MOVIMENTO, :SIARDEVC-STA-RETORNO, :SIARDEVC-COD-FONTE END-EXEC. */

            if (C01_SIARDEVC.Fetch())
            {
                _.Move(C01_SIARDEVC.SIARDEVC_NOM_ARQUIVO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_ARQUIVO);
                _.Move(C01_SIARDEVC.SIARDEVC_SEQ_GERACAO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_GERACAO);
                _.Move(C01_SIARDEVC.SIARDEVC_TIPO_REGISTRO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_REGISTRO);
                _.Move(C01_SIARDEVC.SIARDEVC_SEQ_REGISTRO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_REGISTRO);
                _.Move(C01_SIARDEVC.SIARDEVC_NUM_APOL_SINISTRO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO);
                _.Move(C01_SIARDEVC.SIARDEVC_NUM_SINISTRO_VC, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_SINISTRO_VC);
                _.Move(C01_SIARDEVC.SIARDEVC_NUM_EXPEDIENTE_VC, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_EXPEDIENTE_VC);
                _.Move(C01_SIARDEVC.SIARDEVC_IND_FAVORECIDO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_IND_FAVORECIDO);
                _.Move(C01_SIARDEVC.SIARDEVC_CGCCPF, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_CGCCPF);
                _.Move(C01_SIARDEVC.SIARDEVC_NOM_FAVORECIDO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_FAVORECIDO);
                _.Move(C01_SIARDEVC.SIARDEVC_COD_OPERACAO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_OPERACAO);
                _.Move(C01_SIARDEVC.SIARDEVC_NUM_APOLICE, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE);
                _.Move(C01_SIARDEVC.SIARDEVC_NUM_ENDOSSO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_ENDOSSO);
                _.Move(C01_SIARDEVC.SIARDEVC_NUM_ITEM, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_ITEM);
                _.Move(C01_SIARDEVC.SIARDEVC_COD_RAMO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_RAMO);
                _.Move(C01_SIARDEVC.SIARDEVC_COD_COBERTURA, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_COBERTURA);
                _.Move(C01_SIARDEVC.SIARDEVC_DATA_OCORRENCIA, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_OCORRENCIA);
                _.Move(C01_SIARDEVC.SIARDEVC_DATA_NEGOCIADA, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_NEGOCIADA);
                _.Move(C01_SIARDEVC.SIARDEVC_COD_CAUSA, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_CAUSA);
                _.Move(C01_SIARDEVC.SIARDEVC_IND_FORMA_PAGTO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_IND_FORMA_PAGTO);
                _.Move(C01_SIARDEVC.SIARDEVC_VAL_TOT_MOVIMENTO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_TOT_MOVIMENTO);
                _.Move(C01_SIARDEVC.SIARDEVC_STA_RETORNO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_RETORNO);
                _.Move(C01_SIARDEVC.SIARDEVC_COD_FONTE, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_FONTE);
            }

        }

        [StopWatch]
        /*" R0910-00-LE-SIARDEVC-DB-CLOSE-1 */
        public void R0910_00_LE_SIARDEVC_DB_CLOSE_1()
        {
            /*" -228- EXEC SQL CLOSE C01_SIARDEVC END-EXEC */

            C01_SIARDEVC.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -241- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", WABEND.WNR_EXEC_SQL);

            /*" -245- MOVE ZEROS TO PARCELAS-PRM-TOTAL-IX */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_PRM_TOTAL_IX);

            /*" -247- PERFORM R1100-00-LE-SINISMES */

            R1100_00_LE_SINISMES_SECTION();

            /*" -249- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -250- MOVE 18 TO SIARDEVC-COD-ERRO */
                _.Move(18, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO);

                /*" -251- MOVE 0 TO IND-COD-ERRO */
                _.Move(0, IND_COD_ERRO);

                /*" -252- MOVE '2' TO SIARDEVC-STA-PROCESSAMENTO */
                _.Move("2", SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO);

                /*" -254- GO TO R1000-10-LER. */

                R1000_10_LER(); //GOTO
                return;
            }


            /*" -257- IF SINISMES-SIT-REGISTRO EQUAL '2' */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_SIT_REGISTRO == "2")
            {

                /*" -258- MOVE 19 TO SIARDEVC-COD-ERRO */
                _.Move(19, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO);

                /*" -259- MOVE 0 TO IND-COD-ERRO */
                _.Move(0, IND_COD_ERRO);

                /*" -260- MOVE '2' TO SIARDEVC-STA-PROCESSAMENTO */
                _.Move("2", SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO);

                /*" -262- GO TO R1000-10-LER. */

                R1000_10_LER(); //GOTO
                return;
            }


            /*" -268- PERFORM R1200-00-LE-SINISCAU */

            R1200_00_LE_SINISCAU_SECTION();

            /*" -280- IF (SIARDEVC-IND-FAVORECIDO EQUAL '1' OR '4' ) AND SIARDEVC-COD-RAMO EQUAL 31 AND SINISMES-COD-PRODUTO NOT EQUAL 3120 AND SINISCAU-GRUPO-CAUSAS EQUAL 'PT' AND (SIARDEVC-COD-COBERTURA EQUAL 201 OR 202 OR 203 OR 218) */

            if ((SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_IND_FAVORECIDO.In("1", "4")) && SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_RAMO == 31 && SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO != 3120 && SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_GRUPO_CAUSAS == "PT" && (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_COBERTURA.In("201", "202", "203", "218")))
            {

                /*" -282- IF SIARDEVC-NUM-APOL-SINISTRO NOT EQUAL 1003100009155 */

                if (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO != 1003100009155)
                {

                    /*" -283- PERFORM R1300-00-CONTA-INDENIZACAO */

                    R1300_00_CONTA_INDENIZACAO_SECTION();

                    /*" -284- IF HOST-COUNT EQUAL ZEROS */

                    if (HOST_COUNT == 00)
                    {

                        /*" -286- PERFORM R1400-00-SUM-PARCELA-PEND. */

                        R1400_00_SUM_PARCELA_PEND_SECTION();
                    }

                }

            }


            /*" -291- IF PARCELAS-PRM-TOTAL-IX GREATER SIARDEVC-VAL-TOT-MOVIMENTO */

            if (PARCELAS.DCLPARCELAS.PARCELAS_PRM_TOTAL_IX > SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_TOT_MOVIMENTO)
            {

                /*" -292- MOVE 20 TO SIARDEVC-COD-ERRO */
                _.Move(20, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO);

                /*" -293- MOVE 0 TO IND-COD-ERRO */
                _.Move(0, IND_COD_ERRO);

                /*" -294- MOVE '2' TO SIARDEVC-STA-PROCESSAMENTO */
                _.Move("2", SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO);

                /*" -298- GO TO R1000-10-LER. */

                R1000_10_LER(); //GOTO
                return;
            }


            /*" -300- PERFORM R1500-00-LE-SIARDEVC-AVISO */

            R1500_00_LE_SIARDEVC_AVISO_SECTION();

            /*" -303- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -304- MOVE 21 TO SIARDEVC-COD-ERRO */
                _.Move(21, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO);

                /*" -305- MOVE 0 TO IND-COD-ERRO */
                _.Move(0, IND_COD_ERRO);

                /*" -306- MOVE '2' TO SIARDEVC-STA-PROCESSAMENTO */
                _.Move("2", SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO);

                /*" -307- GO TO R1000-10-LER */

                R1000_10_LER(); //GOTO
                return;

                /*" -308- ELSE */
            }
            else
            {


                /*" -316- IF SIARDEVC-NUM-SINISTRO-VC NOT EQUAL HOST-NUM-SINISTRO-VC OR SIARDEVC-NUM-EXPEDIENTE-VC NOT EQUAL HOST-NUM-EXPEDIENTE-VC OR SIARDEVC-COD-COBERTURA NOT EQUAL HOST-COD-COBERTURA */

                if (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_SINISTRO_VC != HOST_NUM_SINISTRO_VC || SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_EXPEDIENTE_VC != HOST_NUM_EXPEDIENTE_VC || SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_COBERTURA != HOST_COD_COBERTURA)
                {

                    /*" -317- MOVE 22 TO SIARDEVC-COD-ERRO */
                    _.Move(22, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO);

                    /*" -318- MOVE 0 TO IND-COD-ERRO */
                    _.Move(0, IND_COD_ERRO);

                    /*" -319- MOVE '2' TO SIARDEVC-STA-PROCESSAMENTO */
                    _.Move("2", SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO);

                    /*" -323- GO TO R1000-10-LER. */

                    R1000_10_LER(); //GOTO
                    return;
                }

            }


            /*" -325- IF SIARDEVC-COD-FONTE NOT EQUAL ZEROS */

            if (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_FONTE != 00)
            {

                /*" -326- PERFORM R1600-00-LE-FONTES */

                R1600_00_LE_FONTES_SECTION();

                /*" -328- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -329- MOVE 43 TO SIARDEVC-COD-ERRO */
                    _.Move(43, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO);

                    /*" -330- MOVE 0 TO IND-COD-ERRO */
                    _.Move(0, IND_COD_ERRO);

                    /*" -331- MOVE '2' TO SIARDEVC-STA-PROCESSAMENTO */
                    _.Move("2", SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO);

                    /*" -332- GO TO R1000-10-LER */

                    R1000_10_LER(); //GOTO
                    return;

                    /*" -333- ELSE */
                }
                else
                {


                    /*" -336- IF FONTES-SIT-REGISTRO NOT EQUAL '0' */

                    if (FONTES.DCLFONTES.FONTES_SIT_REGISTRO != "0")
                    {

                        /*" -337- MOVE 44 TO SIARDEVC-COD-ERRO */
                        _.Move(44, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO);

                        /*" -338- MOVE 0 TO IND-COD-ERRO */
                        _.Move(0, IND_COD_ERRO);

                        /*" -339- MOVE '2' TO SIARDEVC-STA-PROCESSAMENTO */
                        _.Move("2", SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO);

                        /*" -346- GO TO R1000-10-LER. */

                        R1000_10_LER(); //GOTO
                        return;
                    }

                }

            }


            /*" -347- IF SINISMES-COD-CAUSA EQUAL 6 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA == 6)
            {

                /*" -348- IF SIARDEVC-IND-FAVORECIDO NOT EQUAL '5' */

                if (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_IND_FAVORECIDO != "5")
                {

                    /*" -349- MOVE 46 TO SIARDEVC-COD-ERRO */
                    _.Move(46, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO);

                    /*" -350- MOVE ZEROS TO IND-COD-ERRO */
                    _.Move(0, IND_COD_ERRO);

                    /*" -351- MOVE '2' TO SIARDEVC-STA-PROCESSAMENTO */
                    _.Move("2", SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO);

                    /*" -352- GO TO R1000-10-LER */

                    R1000_10_LER(); //GOTO
                    return;

                    /*" -353- END-IF */
                }


                /*" -357- END-IF. */
            }


            /*" -358- IF SIARDEVC-IND-FORMA-PAGTO NOT EQUAL '1' AND '3' */

            if (!SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_IND_FORMA_PAGTO.In("1", "3"))
            {

                /*" -360- MOVE '1' TO SIARDEVC-IND-FORMA-PAGTO. */
                _.Move("1", SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_IND_FORMA_PAGTO);
            }


            /*" -364- IF SIARDEVC-IND-FORMA-PAGTO NOT EQUAL '1' AND '3' */

            if (!SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_IND_FORMA_PAGTO.In("1", "3"))
            {

                /*" -365- MOVE 23 TO SIARDEVC-COD-ERRO */
                _.Move(23, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO);

                /*" -366- MOVE 0 TO IND-COD-ERRO */
                _.Move(0, IND_COD_ERRO);

                /*" -367- ELSE */
            }
            else
            {


                /*" -368- MOVE 0 TO SIARDEVC-COD-ERRO */
                _.Move(0, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO);

                /*" -370- MOVE -1 TO IND-COD-ERRO. */
                _.Move(-1, IND_COD_ERRO);
            }


            /*" -370- MOVE '1' TO SIARDEVC-STA-PROCESSAMENTO. */
            _.Move("1", SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO);

            /*" -0- FLUXCONTROL_PERFORM R1000_10_LER */

            R1000_10_LER();

        }

        [StopWatch]
        /*" R1000-10-LER */
        private void R1000_10_LER(bool isPerform = false)
        {
            /*" -376- MOVE '1' TO SIARDEVC-STA-RETORNO */
            _.Move("1", SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_RETORNO);

            /*" -377- IF SINISMES-COD-CAUSA EQUAL 6 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA == 6)
            {

                /*" -378- IF SIARDEVC-IND-FAVORECIDO EQUAL '5' */

                if (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_IND_FAVORECIDO == "5")
                {

                    /*" -379- MOVE '0' TO SIARDEVC-STA-PROCESSAMENTO */
                    _.Move("0", SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO);

                    /*" -380- MOVE '0' TO SIARDEVC-STA-RETORNO */
                    _.Move("0", SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_RETORNO);

                    /*" -381- END-IF */
                }


                /*" -383- END-IF. */
            }


            /*" -385- PERFORM R3100-00-ALTERA-SIARDEVC */

            R3100_00_ALTERA_SIARDEVC_SECTION();

            /*" -385- PERFORM R0910-00-LE-SIARDEVC. */

            R0910_00_LE_SIARDEVC_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-LE-SINISMES-SECTION */
        private void R1100_00_LE_SINISMES_SECTION()
        {
            /*" -395- MOVE '1100' TO WNR-EXEC-SQL */
            _.Move("1100", WABEND.WNR_EXEC_SQL);

            /*" -405- PERFORM R1100_00_LE_SINISMES_DB_SELECT_1 */

            R1100_00_LE_SINISMES_DB_SELECT_1();

            /*" -408- IF SQLCODE NOT EQUAL 0 AND 100 */

            if (!DB.SQLCODE.In("0", "100"))
            {

                /*" -414- DISPLAY 'PROBLEMAS NO SELECT SINISTRO_MESTRE' ' ' SIARDEVC-NUM-APOL-SINISTRO ' ' SIARDEVC-NOM-ARQUIVO ' ' SIARDEVC-SEQ-GERACAO ' ' SIARDEVC-TIPO-REGISTRO ' ' SIARDEVC-SEQ-REGISTRO */

                $"PROBLEMAS NO SELECT SINISTRO_MESTRE {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_ARQUIVO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_GERACAO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_REGISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_REGISTRO}"
                .Display();

                /*" -414- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1100-00-LE-SINISMES-DB-SELECT-1 */
        public void R1100_00_LE_SINISMES_DB_SELECT_1()
        {
            /*" -405- EXEC SQL SELECT SIT_REGISTRO, COD_CAUSA, COD_PRODUTO INTO :SINISMES-SIT-REGISTRO, :SINISMES-COD-CAUSA, :SINISMES-COD-PRODUTO FROM SEGUROS.SINISTRO_MESTRE WHERE NUM_APOL_SINISTRO = :SIARDEVC-NUM-APOL-SINISTRO WITH UR END-EXEC */

            var r1100_00_LE_SINISMES_DB_SELECT_1_Query1 = new R1100_00_LE_SINISMES_DB_SELECT_1_Query1()
            {
                SIARDEVC_NUM_APOL_SINISTRO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R1100_00_LE_SINISMES_DB_SELECT_1_Query1.Execute(r1100_00_LE_SINISMES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISMES_SIT_REGISTRO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_SIT_REGISTRO);
                _.Move(executed_1.SINISMES_COD_CAUSA, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA);
                _.Move(executed_1.SINISMES_COD_PRODUTO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-LE-SINISCAU-SECTION */
        private void R1200_00_LE_SINISCAU_SECTION()
        {
            /*" -424- MOVE '1200' TO WNR-EXEC-SQL */
            _.Move("1200", WABEND.WNR_EXEC_SQL);

            /*" -431- PERFORM R1200_00_LE_SINISCAU_DB_SELECT_1 */

            R1200_00_LE_SINISCAU_DB_SELECT_1();

            /*" -434- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -442- DISPLAY 'PROBLEMAS NO SELECT SINISTRO_CAUSA' ' ' SIARDEVC-NUM-APOL-SINISTRO ' ' SIARDEVC-COD-RAMO ' ' SIARDEVC-COD-CAUSA ' ' SIARDEVC-NOM-ARQUIVO ' ' SIARDEVC-SEQ-GERACAO ' ' SIARDEVC-TIPO-REGISTRO ' ' SIARDEVC-SEQ-REGISTRO */

                $"PROBLEMAS NO SELECT SINISTRO_CAUSA {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_RAMO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_CAUSA} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_ARQUIVO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_GERACAO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_REGISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_REGISTRO}"
                .Display();

                /*" -442- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1200-00-LE-SINISCAU-DB-SELECT-1 */
        public void R1200_00_LE_SINISCAU_DB_SELECT_1()
        {
            /*" -431- EXEC SQL SELECT GRUPO_CAUSAS INTO :SINISCAU-GRUPO-CAUSAS FROM SEGUROS.SINISTRO_CAUSA WHERE RAMO_EMISSOR = :SIARDEVC-COD-RAMO AND COD_CAUSA = :SIARDEVC-COD-CAUSA WITH UR END-EXEC. */

            var r1200_00_LE_SINISCAU_DB_SELECT_1_Query1 = new R1200_00_LE_SINISCAU_DB_SELECT_1_Query1()
            {
                SIARDEVC_COD_CAUSA = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_CAUSA.ToString(),
                SIARDEVC_COD_RAMO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_RAMO.ToString(),
            };

            var executed_1 = R1200_00_LE_SINISCAU_DB_SELECT_1_Query1.Execute(r1200_00_LE_SINISCAU_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISCAU_GRUPO_CAUSAS, SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_GRUPO_CAUSAS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_EXIT*/

        [StopWatch]
        /*" R1300-00-CONTA-INDENIZACAO-SECTION */
        private void R1300_00_CONTA_INDENIZACAO_SECTION()
        {
            /*" -452- MOVE '1300' TO WNR-EXEC-SQL */
            _.Move("1300", WABEND.WNR_EXEC_SQL);

            /*" -461- PERFORM R1300_00_CONTA_INDENIZACAO_DB_SELECT_1 */

            R1300_00_CONTA_INDENIZACAO_DB_SELECT_1();

            /*" -464- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -470- DISPLAY 'PROBLEMAS NO COUNT SINISTRO_HISTORICO' ' ' SIARDEVC-NUM-APOL-SINISTRO ' ' SIARDEVC-NOM-ARQUIVO ' ' SIARDEVC-SEQ-GERACAO ' ' SIARDEVC-TIPO-REGISTRO ' ' SIARDEVC-SEQ-REGISTRO */

                $"PROBLEMAS NO COUNT SINISTRO_HISTORICO {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_ARQUIVO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_GERACAO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_REGISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_REGISTRO}"
                .Display();

                /*" -470- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1300-00-CONTA-INDENIZACAO-DB-SELECT-1 */
        public void R1300_00_CONTA_INDENIZACAO_DB_SELECT_1()
        {
            /*" -461- EXEC SQL SELECT VALUE(COUNT(*), 0) INTO :HOST-COUNT FROM SEGUROS.SINISTRO_HISTORICO WHERE NUM_APOL_SINISTRO = :SIARDEVC-NUM-APOL-SINISTRO AND COD_OPERACAO IN (1081, 1082, 1083, 1084) AND SIT_REGISTRO <> '2' AND TIPO_FAVORECIDO IN ( '1' , '4' ) WITH UR END-EXEC. */

            var r1300_00_CONTA_INDENIZACAO_DB_SELECT_1_Query1 = new R1300_00_CONTA_INDENIZACAO_DB_SELECT_1_Query1()
            {
                SIARDEVC_NUM_APOL_SINISTRO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R1300_00_CONTA_INDENIZACAO_DB_SELECT_1_Query1.Execute(r1300_00_CONTA_INDENIZACAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_COUNT, HOST_COUNT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_EXIT*/

        [StopWatch]
        /*" R1400-00-SUM-PARCELA-PEND-SECTION */
        private void R1400_00_SUM_PARCELA_PEND_SECTION()
        {
            /*" -480- MOVE '1400' TO WNR-EXEC-SQL */
            _.Move("1400", WABEND.WNR_EXEC_SQL);

            /*" -489- PERFORM R1400_00_SUM_PARCELA_PEND_DB_SELECT_1 */

            R1400_00_SUM_PARCELA_PEND_DB_SELECT_1();

            /*" -492- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -499- DISPLAY 'PROBLEMAS NO SUM PARCELAS' ' ' SIARDEVC-NUM-APOL-SINISTRO ' ' SIARDEVC-NUM-APOLICE ' ' SIARDEVC-NOM-ARQUIVO ' ' SIARDEVC-SEQ-GERACAO ' ' SIARDEVC-TIPO-REGISTRO ' ' SIARDEVC-SEQ-REGISTRO */

                $"PROBLEMAS NO SUM PARCELAS {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_ARQUIVO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_GERACAO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_REGISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_REGISTRO}"
                .Display();

                /*" -499- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1400-00-SUM-PARCELA-PEND-DB-SELECT-1 */
        public void R1400_00_SUM_PARCELA_PEND_DB_SELECT_1()
        {
            /*" -489- EXEC SQL SELECT VALUE(COUNT(*), 0), VALUE(SUM(PRM_TOTAL_IX), 0) INTO :HOST-QTD-PARCELA-PEND, :PARCELAS-PRM-TOTAL-IX FROM SEGUROS.PARCELAS WHERE NUM_APOLICE = :SIARDEVC-NUM-APOLICE AND SIT_REGISTRO = '0' WITH UR END-EXEC. */

            var r1400_00_SUM_PARCELA_PEND_DB_SELECT_1_Query1 = new R1400_00_SUM_PARCELA_PEND_DB_SELECT_1_Query1()
            {
                SIARDEVC_NUM_APOLICE = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1400_00_SUM_PARCELA_PEND_DB_SELECT_1_Query1.Execute(r1400_00_SUM_PARCELA_PEND_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_QTD_PARCELA_PEND, HOST_QTD_PARCELA_PEND);
                _.Move(executed_1.PARCELAS_PRM_TOTAL_IX, PARCELAS.DCLPARCELAS.PARCELAS_PRM_TOTAL_IX);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_EXIT*/

        [StopWatch]
        /*" R1500-00-LE-SIARDEVC-AVISO-SECTION */
        private void R1500_00_LE_SIARDEVC_AVISO_SECTION()
        {
            /*" -509- MOVE '1500' TO WNR-EXEC-SQL */
            _.Move("1500", WABEND.WNR_EXEC_SQL);

            /*" -520- PERFORM R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1 */

            R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1();

            /*" -523- IF SQLCODE NOT EQUAL 0 AND 100 */

            if (!DB.SQLCODE.In("0", "100"))
            {

                /*" -529- DISPLAY 'PROBLEMAS NO SELECT SI_AR_DETALHE_VC' ' ' SIARDEVC-NUM-APOL-SINISTRO ' ' SIARDEVC-NOM-ARQUIVO ' ' SIARDEVC-SEQ-GERACAO ' ' SIARDEVC-TIPO-REGISTRO ' ' SIARDEVC-SEQ-REGISTRO */

                $"PROBLEMAS NO SELECT SI_AR_DETALHE_VC {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_ARQUIVO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_GERACAO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_REGISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_REGISTRO}"
                .Display();

                /*" -529- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1500-00-LE-SIARDEVC-AVISO-DB-SELECT-1 */
        public void R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1()
        {
            /*" -520- EXEC SQL SELECT NUM_SINISTRO_VC, NUM_EXPEDIENTE_VC, COD_COBERTURA INTO :HOST-NUM-SINISTRO-VC, :HOST-NUM-EXPEDIENTE-VC, :HOST-COD-COBERTURA FROM SEGUROS.SI_AR_DETALHE_VC WHERE NUM_APOL_SINISTRO = :SIARDEVC-NUM-APOL-SINISTRO AND COD_OPERACAO = 101 AND STA_PROCESSAMENTO = '1' END-EXEC */

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
        /*" R1600-00-LE-FONTES-SECTION */
        private void R1600_00_LE_FONTES_SECTION()
        {
            /*" -539- MOVE '1600' TO WNR-EXEC-SQL */
            _.Move("1600", WABEND.WNR_EXEC_SQL);

            /*" -545- PERFORM R1600_00_LE_FONTES_DB_SELECT_1 */

            R1600_00_LE_FONTES_DB_SELECT_1();

            /*" -548- IF SQLCODE NOT EQUAL 0 AND 100 */

            if (!DB.SQLCODE.In("0", "100"))
            {

                /*" -555- DISPLAY 'PROBLEMAS NO SELECT FONTES' ' ' SIARDEVC-NUM-APOL-SINISTRO ' ' SIARDEVC-NOM-ARQUIVO ' ' SIARDEVC-SEQ-GERACAO ' ' SIARDEVC-TIPO-REGISTRO ' ' SIARDEVC-SEQ-REGISTRO ' ' SIARDEVC-COD-FONTE */

                $"PROBLEMAS NO SELECT FONTES {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_ARQUIVO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_GERACAO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_REGISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_REGISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_FONTE}"
                .Display();

                /*" -555- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1600-00-LE-FONTES-DB-SELECT-1 */
        public void R1600_00_LE_FONTES_DB_SELECT_1()
        {
            /*" -545- EXEC SQL SELECT SIT_REGISTRO INTO :FONTES-SIT-REGISTRO FROM SEGUROS.FONTES WHERE COD_FONTE = :SIARDEVC-COD-FONTE WITH UR END-EXEC */

            var r1600_00_LE_FONTES_DB_SELECT_1_Query1 = new R1600_00_LE_FONTES_DB_SELECT_1_Query1()
            {
                SIARDEVC_COD_FONTE = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_FONTE.ToString(),
            };

            var executed_1 = R1600_00_LE_FONTES_DB_SELECT_1_Query1.Execute(r1600_00_LE_FONTES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FONTES_SIT_REGISTRO, FONTES.DCLFONTES.FONTES_SIT_REGISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-ALTERA-SIARDEVC-SECTION */
        private void R3100_00_ALTERA_SIARDEVC_SECTION()
        {
            /*" -565- MOVE '3100' TO WNR-EXEC-SQL */
            _.Move("3100", WABEND.WNR_EXEC_SQL);

            /*" -577- PERFORM R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1 */

            R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1();

            /*" -580- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -589- DISPLAY 'PROBLEMAS NO UPDATE SI_AR_DETALHE_VC' ' ' SIARDEVC-NOM-ARQUIVO ' ' SIARDEVC-SEQ-GERACAO ' ' SIARDEVC-TIPO-REGISTRO ' ' SIARDEVC-SEQ-REGISTRO ' ' SIARDEVC-STA-PROCESSAMENTO ' ' SIARDEVC-STA-RETORNO ' ' SIARDEVC-COD-ERRO ' ' IND-COD-ERRO */

                $"PROBLEMAS NO UPDATE SI_AR_DETALHE_VC {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_ARQUIVO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_GERACAO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_REGISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_REGISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_RETORNO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO} {IND_COD_ERRO}"
                .Display();

                /*" -591- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -591- ADD 1 TO AC-U-SIARDEVC. */
            AC_U_SIARDEVC.Value = AC_U_SIARDEVC + 1;

        }

        [StopWatch]
        /*" R3100-00-ALTERA-SIARDEVC-DB-UPDATE-1 */
        public void R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1()
        {
            /*" -577- EXEC SQL UPDATE SEGUROS.SI_AR_DETALHE_VC SET STA_PROCESSAMENTO = :SIARDEVC-STA-PROCESSAMENTO, STA_RETORNO = :SIARDEVC-STA-RETORNO, COD_ERRO = :SIARDEVC-COD-ERRO:IND-COD-ERRO WHERE NOM_ARQUIVO = :SIARDEVC-NOM-ARQUIVO AND SEQ_GERACAO = :SIARDEVC-SEQ-GERACAO AND TIPO_REGISTRO = :SIARDEVC-TIPO-REGISTRO AND SEQ_REGISTRO = :SIARDEVC-SEQ-REGISTRO END-EXEC */

            var r3100_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1 = new R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1()
            {
                SIARDEVC_COD_ERRO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO.ToString(),
                IND_COD_ERRO = IND_COD_ERRO.ToString(),
                SIARDEVC_STA_PROCESSAMENTO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO.ToString(),
                SIARDEVC_STA_RETORNO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_RETORNO.ToString(),
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
            /*" -605- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -607- DISPLAY WABEND */
            _.Display(WABEND);

            /*" -608- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -609- DISPLAY '*    SI9102B - CANCELADO     *' */
            _.Display($"*    SI9102B - CANCELADO     *");

            /*" -611- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -611- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -615- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -615- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}