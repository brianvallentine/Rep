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
using Sias.Sinistro.DB2.SI9104B;

namespace Code
{
    public class SI9104B
    {
        public bool IsCall { get; set; }

        public SI9104B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SINISTROS                          *      */
        /*"      *   PROGRAMA ...............  SI9104B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  PRODEXTER                          *      */
        /*"      *   PROGRAMADOR ............  PRODEXTER                          *      */
        /*"      *   DATA CODIFICACAO .......  MAIO/2003                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  PAGAMENTO DE INDENIZACAO DE OFICINA*      */
        /*"      *                             E HONORARIOS (AMBOS COM TRIBUTACAO)*      */
        /*"      *                             A PARTIR DE MOVIMENTO DE SINISTRO  *      */
        /*"      *                             CONVENIO AUTO VERA CRUZ            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ESTE PROGRAMA FOI ALTERADA POR SOLICITACAO SSI 12179 INCLUINDO*      */
        /*"      *  NOVAS COBERTURAS E TRATANDO A NOVA CAUSA 6 RAMO 31 VIDROS.    *      */
        /*"      *  ALTERADO - ALEXIS VEAS ITURRIAGA EM 22/11/2006                *      */
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
        /*"01       IND-COD-ERRO           PIC S9(004) VALUE +0 COMP.*/
        public IntBasis IND_COD_ERRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01       IND-COD-BANCO          PIC S9(004) VALUE +0 COMP.*/
        public IntBasis IND_COD_BANCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01       IND-COD-AGENCIA        PIC S9(004) VALUE +0 COMP.*/
        public IntBasis IND_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01       IND-NUM-CTA-CORRENTE   PIC S9(004) VALUE +0 COMP.*/
        public IntBasis IND_NUM_CTA_CORRENTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01       IND-DATA-EMISSAO       PIC S9(004) VALUE +0 COMP.*/
        public IntBasis IND_DATA_EMISSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01       WS-NUM-CTA-CORRENTE    PIC  9(013) VALUE ZEROS.*/
        public IntBasis WS_NUM_CTA_CORRENTE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
        /*"01       FILLER                 REDEFINES   WS-NUM-CTA-CORRENTE.*/
        private _REDEF_SI9104B_FILLER_0 _filler_0 { get; set; }
        public _REDEF_SI9104B_FILLER_0 FILLER_0
        {
            get { _filler_0 = new _REDEF_SI9104B_FILLER_0(); _.Move(WS_NUM_CTA_CORRENTE, _filler_0); VarBasis.RedefinePassValue(WS_NUM_CTA_CORRENTE, _filler_0, WS_NUM_CTA_CORRENTE); _filler_0.ValueChanged += () => { _.Move(_filler_0, WS_NUM_CTA_CORRENTE); }; return _filler_0; }
            set { VarBasis.RedefinePassValue(value, _filler_0, WS_NUM_CTA_CORRENTE); }
        }  //Redefines
        public class _REDEF_SI9104B_FILLER_0 : VarBasis
        {
            /*"  05     WS-OPERACAO-CONTA      PIC  9(001).*/
            public IntBasis WS_OPERACAO_CONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05     WS-COD-CONTA           PIC  9(009).*/
            public IntBasis WS_COD_CONTA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05     WS-DV-CONTA            PIC  9(001).*/
            public IntBasis WS_DV_CONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"01       WFIM-SIARDEVC          PIC  X(001) VALUE SPACES.*/

            public _REDEF_SI9104B_FILLER_0()
            {
                WS_OPERACAO_CONTA.ValueChanged += OnValueChanged;
                WS_COD_CONTA.ValueChanged += OnValueChanged;
                WS_DV_CONTA.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WFIM_SIARDEVC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01       WERRO-FORNECEDOR       PIC  X(001) VALUE SPACES.*/
        public StringBasis WERRO_FORNECEDOR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01       AC-L-SIARDEVC          PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_L_SIARDEVC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-U-SIARDEVC          PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_U_SIARDEVC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       WABEND.*/
        public SI9104B_WABEND WABEND { get; set; } = new SI9104B_WABEND();
        public class SI9104B_WABEND : VarBasis
        {
            /*"  05     FILLER                 PIC  X(010) VALUE        ' SI9104B'.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SI9104B");
            /*"  05     FILLER                 PIC  X(026) VALUE        ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"  05     WNR-EXEC-SQL           PIC  X(004) VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"  05     FILLER                 PIC  X(013) VALUE        ' *** SQLCODE '.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"  05     WSQLCODE               PIC  ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
        }


        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.PAROPESI PAROPESI { get; set; } = new Dclgens.PAROPESI();
        public Dclgens.FORNECED FORNECED { get; set; } = new Dclgens.FORNECED();
        public Dclgens.SIARDEVC SIARDEVC { get; set; } = new Dclgens.SIARDEVC();
        public Dclgens.NUMEROUT NUMEROUT { get; set; } = new Dclgens.NUMEROUT();
        public Dclgens.FIPADOFI FIPADOFI { get; set; } = new Dclgens.FIPADOFI();
        public Dclgens.SIPADOFI SIPADOFI { get; set; } = new Dclgens.SIPADOFI();
        public Dclgens.FIPADOLA FIPADOLA { get; set; } = new Dclgens.FIPADOLA();
        public Dclgens.GETPLADO GETPLADO { get; set; } = new Dclgens.GETPLADO();
        public Dclgens.FONTES FONTES { get; set; } = new Dclgens.FONTES();
        public SI9104B_C01_SIARDEVC C01_SIARDEVC { get; set; } = new SI9104B_C01_SIARDEVC();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -92- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -93- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -94- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -94- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -102- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", WABEND.WNR_EXEC_SQL);

            /*" -104- PERFORM R0100-00-LE-SISTEMAS */

            R0100_00_LE_SISTEMAS_SECTION();

            /*" -105- PERFORM R0900-00-DECLARA-SIARDEVC */

            R0900_00_DECLARA_SIARDEVC_SECTION();

            /*" -107- PERFORM R0910-00-LE-SIARDEVC */

            R0910_00_LE_SIARDEVC_SECTION();

            /*" -109- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WFIM-SIARDEVC NOT EQUAL SPACES. */

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
            /*" -114- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -115- DISPLAY '*    SI9104B - FIM NORMAL    *' */
            _.Display($"*    SI9104B - FIM NORMAL    *");

            /*" -116- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -117- DISPLAY 'LIDOS     SIARDEVC - ' AC-L-SIARDEVC */
            _.Display($"LIDOS     SIARDEVC - {AC_L_SIARDEVC}");

            /*" -119- DISPLAY 'ALTERADOS SIARDEVC - ' AC-U-SIARDEVC */
            _.Display($"ALTERADOS SIARDEVC - {AC_U_SIARDEVC}");

            /*" -121- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -121- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0100-00-LE-SISTEMAS-SECTION */
        private void R0100_00_LE_SISTEMAS_SECTION()
        {
            /*" -129- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", WABEND.WNR_EXEC_SQL);

            /*" -134- PERFORM R0100_00_LE_SISTEMAS_DB_SELECT_1 */

            R0100_00_LE_SISTEMAS_DB_SELECT_1();

            /*" -137- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -138- DISPLAY 'PROBLEMAS NO SELECT SISTEMAS' */
                _.Display($"PROBLEMAS NO SELECT SISTEMAS");

                /*" -140- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -141- DISPLAY 'DATA DO SISTEMA DE SINISTRO -' ' ' SISTEMAS-DATA-MOV-ABERTO. */

            $"DATA DO SISTEMA DE SINISTRO - {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}"
            .Display();

        }

        [StopWatch]
        /*" R0100-00-LE-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_LE_SISTEMAS_DB_SELECT_1()
        {
            /*" -134- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' END-EXEC. */

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
            /*" -151- MOVE '0900' TO WNR-EXEC-SQL. */
            _.Move("0900", WABEND.WNR_EXEC_SQL);

            /*" -208- PERFORM R0900_00_DECLARA_SIARDEVC_DB_DECLARE_1 */

            R0900_00_DECLARA_SIARDEVC_DB_DECLARE_1();

            /*" -210- PERFORM R0900_00_DECLARA_SIARDEVC_DB_OPEN_1 */

            R0900_00_DECLARA_SIARDEVC_DB_OPEN_1();

            /*" -213- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -214- DISPLAY 'PROBLEMAS NO OPEN SIARDEVC' */
                _.Display($"PROBLEMAS NO OPEN SIARDEVC");

                /*" -214- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARA-SIARDEVC-DB-DECLARE-1 */
        public void R0900_00_DECLARA_SIARDEVC_DB_DECLARE_1()
        {
            /*" -208- EXEC SQL DECLARE C01_SIARDEVC CURSOR FOR SELECT NOM_ARQUIVO, SEQ_GERACAO, TIPO_REGISTRO, SEQ_REGISTRO, NUM_APOL_SINISTRO, NUM_SINISTRO_VC, NUM_EXPEDIENTE_VC, IND_FAVORECIDO, CGCCPF, TIPO_PESSOA, NOM_FAVORECIDO, COD_BANCO, COD_AGENCIA, OPERACAO_CONTA, COD_CONTA, DV_CONTA, COD_OPERACAO, NUM_APOLICE, NUM_ENDOSSO, NUM_ITEM, COD_RAMO, COD_COBERTURA, DATA_OCORRENCIA, DATA_NEGOCIADA, COD_CAUSA, VAL_TOT_MOVIMENTO, VAL_MAO_OBRA, IND_FORMA_PAGTO, NOM_BAIRRO, NOM_CIDADE, COD_UF, NUM_CEP, NUM_DDD, NUM_TELEFONE, IND_DOC_FISCAL, NUM_DOC_FISCAL, SERIE_DOC_FISCAL, DATA_EMISSAO, VALUE(COD_FONTE, 0) FROM SEGUROS.SI_AR_DETALHE_VC WHERE NOM_ARQUIVO = 'VCMOVSIN' AND STA_PROCESSAMENTO = '0' AND ((COD_OPERACAO = 3001) OR (COD_OPERACAO = 1081 AND IND_FAVORECIDO = '2' ) OR (COD_OPERACAO = 1081 AND IND_FAVORECIDO = '5' AND COD_CAUSA = 6)) ORDER BY NUM_APOLICE, NUM_ITEM, DATA_OCORRENCIA END-EXEC. */
            C01_SIARDEVC = new SI9104B_C01_SIARDEVC(false);
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
							TIPO_PESSOA
							, 
							NOM_FAVORECIDO
							, 
							COD_BANCO
							, 
							COD_AGENCIA
							, 
							OPERACAO_CONTA
							, 
							COD_CONTA
							, 
							DV_CONTA
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
							VAL_TOT_MOVIMENTO
							, 
							VAL_MAO_OBRA
							, 
							IND_FORMA_PAGTO
							, 
							NOM_BAIRRO
							, 
							NOM_CIDADE
							, 
							COD_UF
							, 
							NUM_CEP
							, 
							NUM_DDD
							, 
							NUM_TELEFONE
							, 
							IND_DOC_FISCAL
							, 
							NUM_DOC_FISCAL
							, 
							SERIE_DOC_FISCAL
							, 
							DATA_EMISSAO
							, 
							VALUE(COD_FONTE
							, 0) 
							FROM SEGUROS.SI_AR_DETALHE_VC 
							WHERE NOM_ARQUIVO = 'VCMOVSIN' 
							AND STA_PROCESSAMENTO = '0' 
							AND ((COD_OPERACAO = 3001) 
							OR (COD_OPERACAO = 1081 
							AND IND_FAVORECIDO = '2' ) 
							OR (COD_OPERACAO = 1081 
							AND IND_FAVORECIDO = '5' 
							AND COD_CAUSA = 6)) 
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
            /*" -210- EXEC SQL OPEN C01_SIARDEVC END-EXEC. */

            C01_SIARDEVC.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-LE-SIARDEVC-SECTION */
        private void R0910_00_LE_SIARDEVC_SECTION()
        {
            /*" -224- MOVE '0910' TO WNR-EXEC-SQL. */
            _.Move("0910", WABEND.WNR_EXEC_SQL);

            /*" -264- PERFORM R0910_00_LE_SIARDEVC_DB_FETCH_1 */

            R0910_00_LE_SIARDEVC_DB_FETCH_1();

            /*" -267- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -268- ADD 1 TO AC-L-SIARDEVC */
                AC_L_SIARDEVC.Value = AC_L_SIARDEVC + 1;

                /*" -269- ELSE */
            }
            else
            {


                /*" -270- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -271- MOVE 'S' TO WFIM-SIARDEVC */
                    _.Move("S", WFIM_SIARDEVC);

                    /*" -271- PERFORM R0910_00_LE_SIARDEVC_DB_CLOSE_1 */

                    R0910_00_LE_SIARDEVC_DB_CLOSE_1();

                    /*" -273- ELSE */
                }
                else
                {


                    /*" -274- DISPLAY 'PROBLEMAS NO FETCH SIARDEVC' */
                    _.Display($"PROBLEMAS NO FETCH SIARDEVC");

                    /*" -274- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0910-00-LE-SIARDEVC-DB-FETCH-1 */
        public void R0910_00_LE_SIARDEVC_DB_FETCH_1()
        {
            /*" -264- EXEC SQL FETCH C01_SIARDEVC INTO :SIARDEVC-NOM-ARQUIVO, :SIARDEVC-SEQ-GERACAO, :SIARDEVC-TIPO-REGISTRO, :SIARDEVC-SEQ-REGISTRO, :SIARDEVC-NUM-APOL-SINISTRO, :SIARDEVC-NUM-SINISTRO-VC, :SIARDEVC-NUM-EXPEDIENTE-VC, :SIARDEVC-IND-FAVORECIDO, :SIARDEVC-CGCCPF, :SIARDEVC-TIPO-PESSOA, :SIARDEVC-NOM-FAVORECIDO, :SIARDEVC-COD-BANCO, :SIARDEVC-COD-AGENCIA, :SIARDEVC-OPERACAO-CONTA, :SIARDEVC-COD-CONTA, :SIARDEVC-DV-CONTA, :SIARDEVC-COD-OPERACAO, :SIARDEVC-NUM-APOLICE, :SIARDEVC-NUM-ENDOSSO, :SIARDEVC-NUM-ITEM, :SIARDEVC-COD-RAMO, :SIARDEVC-COD-COBERTURA, :SIARDEVC-DATA-OCORRENCIA, :SIARDEVC-DATA-NEGOCIADA, :SIARDEVC-COD-CAUSA, :SIARDEVC-VAL-TOT-MOVIMENTO, :SIARDEVC-VAL-MAO-OBRA, :SIARDEVC-IND-FORMA-PAGTO, :SIARDEVC-NOM-BAIRRO, :SIARDEVC-NOM-CIDADE, :SIARDEVC-COD-UF, :SIARDEVC-NUM-CEP, :SIARDEVC-NUM-DDD, :SIARDEVC-NUM-TELEFONE, :SIARDEVC-IND-DOC-FISCAL, :SIARDEVC-NUM-DOC-FISCAL, :SIARDEVC-SERIE-DOC-FISCAL, :SIARDEVC-DATA-EMISSAO:IND-DATA-EMISSAO, :SIARDEVC-COD-FONTE END-EXEC. */

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
                _.Move(C01_SIARDEVC.SIARDEVC_TIPO_PESSOA, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_PESSOA);
                _.Move(C01_SIARDEVC.SIARDEVC_NOM_FAVORECIDO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_FAVORECIDO);
                _.Move(C01_SIARDEVC.SIARDEVC_COD_BANCO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_BANCO);
                _.Move(C01_SIARDEVC.SIARDEVC_COD_AGENCIA, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_AGENCIA);
                _.Move(C01_SIARDEVC.SIARDEVC_OPERACAO_CONTA, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OPERACAO_CONTA);
                _.Move(C01_SIARDEVC.SIARDEVC_COD_CONTA, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_CONTA);
                _.Move(C01_SIARDEVC.SIARDEVC_DV_CONTA, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DV_CONTA);
                _.Move(C01_SIARDEVC.SIARDEVC_COD_OPERACAO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_OPERACAO);
                _.Move(C01_SIARDEVC.SIARDEVC_NUM_APOLICE, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE);
                _.Move(C01_SIARDEVC.SIARDEVC_NUM_ENDOSSO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_ENDOSSO);
                _.Move(C01_SIARDEVC.SIARDEVC_NUM_ITEM, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_ITEM);
                _.Move(C01_SIARDEVC.SIARDEVC_COD_RAMO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_RAMO);
                _.Move(C01_SIARDEVC.SIARDEVC_COD_COBERTURA, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_COBERTURA);
                _.Move(C01_SIARDEVC.SIARDEVC_DATA_OCORRENCIA, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_OCORRENCIA);
                _.Move(C01_SIARDEVC.SIARDEVC_DATA_NEGOCIADA, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_NEGOCIADA);
                _.Move(C01_SIARDEVC.SIARDEVC_COD_CAUSA, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_CAUSA);
                _.Move(C01_SIARDEVC.SIARDEVC_VAL_TOT_MOVIMENTO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_TOT_MOVIMENTO);
                _.Move(C01_SIARDEVC.SIARDEVC_VAL_MAO_OBRA, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_MAO_OBRA);
                _.Move(C01_SIARDEVC.SIARDEVC_IND_FORMA_PAGTO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_IND_FORMA_PAGTO);
                _.Move(C01_SIARDEVC.SIARDEVC_NOM_BAIRRO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_BAIRRO);
                _.Move(C01_SIARDEVC.SIARDEVC_NOM_CIDADE, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_CIDADE);
                _.Move(C01_SIARDEVC.SIARDEVC_COD_UF, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_UF);
                _.Move(C01_SIARDEVC.SIARDEVC_NUM_CEP, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CEP);
                _.Move(C01_SIARDEVC.SIARDEVC_NUM_DDD, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_DDD);
                _.Move(C01_SIARDEVC.SIARDEVC_NUM_TELEFONE, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_TELEFONE);
                _.Move(C01_SIARDEVC.SIARDEVC_IND_DOC_FISCAL, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_IND_DOC_FISCAL);
                _.Move(C01_SIARDEVC.SIARDEVC_NUM_DOC_FISCAL, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_DOC_FISCAL);
                _.Move(C01_SIARDEVC.SIARDEVC_SERIE_DOC_FISCAL, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SERIE_DOC_FISCAL);
                _.Move(C01_SIARDEVC.SIARDEVC_DATA_EMISSAO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_EMISSAO);
                _.Move(C01_SIARDEVC.IND_DATA_EMISSAO, IND_DATA_EMISSAO);
                _.Move(C01_SIARDEVC.SIARDEVC_COD_FONTE, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_FONTE);
            }

        }

        [StopWatch]
        /*" R0910-00-LE-SIARDEVC-DB-CLOSE-1 */
        public void R0910_00_LE_SIARDEVC_DB_CLOSE_1()
        {
            /*" -271- EXEC SQL CLOSE C01_SIARDEVC END-EXEC */

            C01_SIARDEVC.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -287- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", WABEND.WNR_EXEC_SQL);

            /*" -292- IF SIARDEVC-COD-OPERACAO EQUAL 3001 AND SIARDEVC-IND-FAVORECIDO NOT EQUAL '5' */

            if (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_OPERACAO == 3001 && SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_IND_FAVORECIDO != "5")
            {

                /*" -293- MOVE 46 TO SIARDEVC-COD-ERRO */
                _.Move(46, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO);

                /*" -294- MOVE 0 TO IND-COD-ERRO */
                _.Move(0, IND_COD_ERRO);

                /*" -295- MOVE '2' TO SIARDEVC-STA-PROCESSAMENTO */
                _.Move("2", SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO);

                /*" -300- GO TO R1000-10-LER. */

                R1000_10_LER(); //GOTO
                return;
            }


            /*" -302- PERFORM R1100-00-LE-SINISMES */

            R1100_00_LE_SINISMES_SECTION();

            /*" -306- MOVE ZEROS TO SIARDEVC-OCORR-HISTORICO SIARDEVC-ORDEM-PAGAMENTO SIARDEVC-COD-FAVORECIDO */
            _.Move(0, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_ORDEM_PAGAMENTO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_FAVORECIDO);

            /*" -308- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -309- MOVE 18 TO SIARDEVC-COD-ERRO */
                _.Move(18, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO);

                /*" -310- MOVE 0 TO IND-COD-ERRO */
                _.Move(0, IND_COD_ERRO);

                /*" -311- MOVE '2' TO SIARDEVC-STA-PROCESSAMENTO */
                _.Move("2", SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO);

                /*" -315- GO TO R1000-10-LER. */

                R1000_10_LER(); //GOTO
                return;
            }


            /*" -317- PERFORM R1500-00-LE-SIARDEVC-AVISO */

            R1500_00_LE_SIARDEVC_AVISO_SECTION();

            /*" -320- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -321- MOVE 21 TO SIARDEVC-COD-ERRO */
                _.Move(21, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO);

                /*" -322- MOVE 0 TO IND-COD-ERRO */
                _.Move(0, IND_COD_ERRO);

                /*" -323- MOVE '2' TO SIARDEVC-STA-PROCESSAMENTO */
                _.Move("2", SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO);

                /*" -324- GO TO R1000-10-LER */

                R1000_10_LER(); //GOTO
                return;

                /*" -325- ELSE */
            }
            else
            {


                /*" -333- IF SIARDEVC-NUM-SINISTRO-VC NOT EQUAL HOST-NUM-SINISTRO-VC OR SIARDEVC-NUM-EXPEDIENTE-VC NOT EQUAL HOST-NUM-EXPEDIENTE-VC OR SIARDEVC-COD-COBERTURA NOT EQUAL HOST-COD-COBERTURA */

                if (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_SINISTRO_VC != HOST_NUM_SINISTRO_VC || SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_EXPEDIENTE_VC != HOST_NUM_EXPEDIENTE_VC || SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_COBERTURA != HOST_COD_COBERTURA)
                {

                    /*" -334- MOVE 22 TO SIARDEVC-COD-ERRO */
                    _.Move(22, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO);

                    /*" -335- MOVE 0 TO IND-COD-ERRO */
                    _.Move(0, IND_COD_ERRO);

                    /*" -336- MOVE '2' TO SIARDEVC-STA-PROCESSAMENTO */
                    _.Move("2", SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO);

                    /*" -343- GO TO R1000-10-LER. */

                    R1000_10_LER(); //GOTO
                    return;
                }

            }


            /*" -344- IF SIARDEVC-COD-OPERACAO EQUAL 1081 */

            if (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_OPERACAO == 1081)
            {

                /*" -345- IF SINISMES-COD-CAUSA EQUAL 6 */

                if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA == 6)
                {

                    /*" -346- IF SIARDEVC-IND-FAVORECIDO NOT EQUAL '5' */

                    if (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_IND_FAVORECIDO != "5")
                    {

                        /*" -347- MOVE 46 TO SIARDEVC-COD-ERRO */
                        _.Move(46, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO);

                        /*" -348- MOVE ZEROS TO IND-COD-ERRO */
                        _.Move(0, IND_COD_ERRO);

                        /*" -349- MOVE '2' TO SIARDEVC-STA-PROCESSAMENTO */
                        _.Move("2", SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO);

                        /*" -350- GO TO R1000-10-LER */

                        R1000_10_LER(); //GOTO
                        return;

                        /*" -351- END-IF */
                    }


                    /*" -352- END-IF */
                }


                /*" -371- END-IF. */
            }


            /*" -373- IF SIARDEVC-COD-FONTE NOT EQUAL ZEROS */

            if (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_FONTE != 00)
            {

                /*" -374- PERFORM R1600-00-LE-FONTES */

                R1600_00_LE_FONTES_SECTION();

                /*" -376- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -377- MOVE 43 TO SIARDEVC-COD-ERRO */
                    _.Move(43, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO);

                    /*" -378- MOVE 0 TO IND-COD-ERRO */
                    _.Move(0, IND_COD_ERRO);

                    /*" -379- MOVE '2' TO SIARDEVC-STA-PROCESSAMENTO */
                    _.Move("2", SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO);

                    /*" -380- GO TO R1000-10-LER */

                    R1000_10_LER(); //GOTO
                    return;

                    /*" -381- ELSE */
                }
                else
                {


                    /*" -384- IF FONTES-SIT-REGISTRO NOT EQUAL '0' */

                    if (FONTES.DCLFONTES.FONTES_SIT_REGISTRO != "0")
                    {

                        /*" -385- MOVE 44 TO SIARDEVC-COD-ERRO */
                        _.Move(44, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO);

                        /*" -386- MOVE 0 TO IND-COD-ERRO */
                        _.Move(0, IND_COD_ERRO);

                        /*" -387- MOVE '2' TO SIARDEVC-STA-PROCESSAMENTO */
                        _.Move("2", SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO);

                        /*" -391- GO TO R1000-10-LER. */

                        R1000_10_LER(); //GOTO
                        return;
                    }

                }

            }


            /*" -393- IF SIARDEVC-IND-FORMA-PAGTO NOT EQUAL '1' AND '3' */

            if (!SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_IND_FORMA_PAGTO.In("1", "3"))
            {

                /*" -395- MOVE '1' TO SIARDEVC-IND-FORMA-PAGTO. */
                _.Move("1", SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_IND_FORMA_PAGTO);
            }


            /*" -397- IF SIARDEVC-IND-FORMA-PAGTO NOT EQUAL '1' AND '3' */

            if (!SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_IND_FORMA_PAGTO.In("1", "3"))
            {

                /*" -398- MOVE 23 TO SIARDEVC-COD-ERRO */
                _.Move(23, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO);

                /*" -407- MOVE 0 TO IND-COD-ERRO */
                _.Move(0, IND_COD_ERRO);

                /*" -408- ELSE */
            }
            else
            {


                /*" -409- MOVE 0 TO SIARDEVC-COD-ERRO */
                _.Move(0, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO);

                /*" -411- MOVE -1 TO IND-COD-ERRO. */
                _.Move(-1, IND_COD_ERRO);
            }


            /*" -411- MOVE '1' TO SIARDEVC-STA-PROCESSAMENTO. */
            _.Move("1", SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO);

            /*" -0- FLUXCONTROL_PERFORM R1000_10_LER */

            R1000_10_LER();

        }

        [StopWatch]
        /*" R1000-10-LER */
        private void R1000_10_LER(bool isPerform = false)
        {
            /*" -416- MOVE '1' TO SIARDEVC-STA-RETORNO */
            _.Move("1", SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_RETORNO);

            /*" -418- PERFORM R3100-00-ALTERA-SIARDEVC */

            R3100_00_ALTERA_SIARDEVC_SECTION();

            /*" -418- PERFORM R0910-00-LE-SIARDEVC. */

            R0910_00_LE_SIARDEVC_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-LE-SINISMES-SECTION */
        private void R1100_00_LE_SINISMES_SECTION()
        {
            /*" -428- MOVE '1100' TO WNR-EXEC-SQL */
            _.Move("1100", WABEND.WNR_EXEC_SQL);

            /*" -443- PERFORM R1100_00_LE_SINISMES_DB_SELECT_1 */

            R1100_00_LE_SINISMES_DB_SELECT_1();

            /*" -446- IF SQLCODE NOT EQUAL 0 AND 100 */

            if (!DB.SQLCODE.In("0", "100"))
            {

                /*" -452- DISPLAY 'PROBLEMAS NO SELECT SINISTRO_MESTRE' ' ' SIARDEVC-NUM-APOL-SINISTRO ' ' SIARDEVC-NOM-ARQUIVO ' ' SIARDEVC-SEQ-GERACAO ' ' SIARDEVC-TIPO-REGISTRO ' ' SIARDEVC-SEQ-REGISTRO */

                $"PROBLEMAS NO SELECT SINISTRO_MESTRE {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_ARQUIVO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_GERACAO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_REGISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_REGISTRO}"
                .Display();

                /*" -452- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1100-00-LE-SINISMES-DB-SELECT-1 */
        public void R1100_00_LE_SINISMES_DB_SELECT_1()
        {
            /*" -443- EXEC SQL SELECT SIT_REGISTRO, SALDO_PAGAR_IX, COD_FONTE, COD_PRODUTO, COD_CAUSA, OCORR_HISTORICO INTO :SINISMES-SIT-REGISTRO, :SINISMES-SALDO-PAGAR-IX, :SINISMES-COD-FONTE, :SINISMES-COD-PRODUTO, :SINISMES-COD-CAUSA, :SINISMES-OCORR-HISTORICO FROM SEGUROS.SINISTRO_MESTRE WHERE NUM_APOL_SINISTRO = :SIARDEVC-NUM-APOL-SINISTRO END-EXEC */

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
                _.Move(executed_1.SINISMES_COD_CAUSA, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA);
                _.Move(executed_1.SINISMES_OCORR_HISTORICO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_OCORR_HISTORICO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-LE-SIARDEVC-AVISO-SECTION */
        private void R1500_00_LE_SIARDEVC_AVISO_SECTION()
        {
            /*" -462- MOVE '1500' TO WNR-EXEC-SQL */
            _.Move("1500", WABEND.WNR_EXEC_SQL);

            /*" -473- PERFORM R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1 */

            R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1();

            /*" -476- IF SQLCODE NOT EQUAL 0 AND 100 */

            if (!DB.SQLCODE.In("0", "100"))
            {

                /*" -482- DISPLAY 'PROBLEMAS NO SELECT SI_AR_DETALHE_VC' ' ' SIARDEVC-NUM-APOL-SINISTRO ' ' SIARDEVC-NOM-ARQUIVO ' ' SIARDEVC-SEQ-GERACAO ' ' SIARDEVC-TIPO-REGISTRO ' ' SIARDEVC-SEQ-REGISTRO */

                $"PROBLEMAS NO SELECT SI_AR_DETALHE_VC {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_ARQUIVO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_GERACAO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_REGISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_REGISTRO}"
                .Display();

                /*" -482- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1500-00-LE-SIARDEVC-AVISO-DB-SELECT-1 */
        public void R1500_00_LE_SIARDEVC_AVISO_DB_SELECT_1()
        {
            /*" -473- EXEC SQL SELECT NUM_SINISTRO_VC, NUM_EXPEDIENTE_VC, COD_COBERTURA INTO :HOST-NUM-SINISTRO-VC, :HOST-NUM-EXPEDIENTE-VC, :HOST-COD-COBERTURA FROM SEGUROS.SI_AR_DETALHE_VC WHERE NUM_APOL_SINISTRO = :SIARDEVC-NUM-APOL-SINISTRO AND COD_OPERACAO = 101 AND STA_PROCESSAMENTO = '1' END-EXEC */

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
            /*" -492- MOVE '1600' TO WNR-EXEC-SQL */
            _.Move("1600", WABEND.WNR_EXEC_SQL);

            /*" -497- PERFORM R1600_00_LE_FONTES_DB_SELECT_1 */

            R1600_00_LE_FONTES_DB_SELECT_1();

            /*" -500- IF SQLCODE NOT EQUAL 0 AND 100 */

            if (!DB.SQLCODE.In("0", "100"))
            {

                /*" -507- DISPLAY 'PROBLEMAS NO SELECT FONTES' ' ' SIARDEVC-NUM-APOL-SINISTRO ' ' SIARDEVC-NOM-ARQUIVO ' ' SIARDEVC-SEQ-GERACAO ' ' SIARDEVC-TIPO-REGISTRO ' ' SIARDEVC-SEQ-REGISTRO ' ' SIARDEVC-COD-FONTE */

                $"PROBLEMAS NO SELECT FONTES {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_ARQUIVO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_GERACAO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_REGISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_REGISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_FONTE}"
                .Display();

                /*" -507- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1600-00-LE-FONTES-DB-SELECT-1 */
        public void R1600_00_LE_FONTES_DB_SELECT_1()
        {
            /*" -497- EXEC SQL SELECT SIT_REGISTRO INTO :FONTES-SIT-REGISTRO FROM SEGUROS.FONTES WHERE COD_FONTE = :SIARDEVC-COD-FONTE END-EXEC */

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
            /*" -517- MOVE '3100' TO WNR-EXEC-SQL */
            _.Move("3100", WABEND.WNR_EXEC_SQL);

            /*" -535- PERFORM R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1 */

            R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1();

            /*" -538- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -543- DISPLAY 'PROBLEMAS NO UPDATE SI_AR_DETALHE_VC' ' ' SIARDEVC-NOM-ARQUIVO ' ' SIARDEVC-SEQ-GERACAO ' ' SIARDEVC-TIPO-REGISTRO ' ' SIARDEVC-SEQ-REGISTRO */

                $"PROBLEMAS NO UPDATE SI_AR_DETALHE_VC {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_ARQUIVO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_GERACAO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_REGISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_REGISTRO}"
                .Display();

                /*" -545- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -545- ADD 1 TO AC-U-SIARDEVC. */
            AC_U_SIARDEVC.Value = AC_U_SIARDEVC + 1;

        }

        [StopWatch]
        /*" R3100-00-ALTERA-SIARDEVC-DB-UPDATE-1 */
        public void R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1()
        {
            /*" -535- EXEC SQL UPDATE SEGUROS.SI_AR_DETALHE_VC SET STA_PROCESSAMENTO = :SIARDEVC-STA-PROCESSAMENTO, STA_RETORNO = :SIARDEVC-STA-RETORNO, OCORR_HISTORICO = :SIARDEVC-OCORR-HISTORICO, ORDEM_PAGAMENTO = :SIARDEVC-ORDEM-PAGAMENTO, COD_FAVORECIDO = :SIARDEVC-COD-FAVORECIDO, COD_ERRO = :SIARDEVC-COD-ERRO:IND-COD-ERRO WHERE NOM_ARQUIVO = :SIARDEVC-NOM-ARQUIVO AND SEQ_GERACAO = :SIARDEVC-SEQ-GERACAO AND TIPO_REGISTRO = :SIARDEVC-TIPO-REGISTRO AND SEQ_REGISTRO = :SIARDEVC-SEQ-REGISTRO END-EXEC */

            var r3100_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1 = new R3100_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1()
            {
                SIARDEVC_COD_ERRO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO.ToString(),
                IND_COD_ERRO = IND_COD_ERRO.ToString(),
                SIARDEVC_STA_PROCESSAMENTO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO.ToString(),
                SIARDEVC_OCORR_HISTORICO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO.ToString(),
                SIARDEVC_ORDEM_PAGAMENTO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_ORDEM_PAGAMENTO.ToString(),
                SIARDEVC_COD_FAVORECIDO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_FAVORECIDO.ToString(),
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
            /*" -559- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -561- DISPLAY WABEND */
            _.Display(WABEND);

            /*" -562- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -563- DISPLAY '*    SI9104B - CANCELADO     *' */
            _.Display($"*    SI9104B - CANCELADO     *");

            /*" -565- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -565- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -569- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -569- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}