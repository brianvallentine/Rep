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
using Sias.Sinistro.DB2.SI5040B;

namespace Code
{
    public class SI5040B
    {
        public bool IsCall { get; set; }

        public SI5040B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   SISTEMA ................  SINISTRO                           *      */
        /*"      *   PROGRAMA ...............  SI5040B                            *      */
        /*"      *   ANALISTA ...............  ALEXIS VEAS ITURRIAGA              *      */
        /*"      *   PROGRAMADOR ............  ALEXIS VEAS ITURRIAGA              *      */
        /*"      *   DATA CODIFICACAO .......  NOV/2005                           *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *                     OBJETIVOS                                  *      */
        /*"      * ESTE PROGRAMA GERA OS NUMEROS DOS SIVATS A SEREM ENVIADOS A    *      */
        /*"      * CAIXA, PARA ALGUNS PRODUTOS EH UM SINISTRO POR SIVAT E OUTROS  *      */
        /*"      * SAO CENTRALIZADOS GERANDO VARIOS SINISTROS PARA APENAS UM SIVAT*      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 28/09/2011 - PATRICIA SALES                                    *      */
        /*"      *              PAGAMENTOS NAO GERADOS - O PROGRAMA PASSARA A     *      */
        /*"      *              UTILIZAR A DATA DE 10 DIAS ATRAS ATE O MOVIMENTO  *      */
        /*"      *              PROCESSADO.                       PROCURE : V.02. *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO PELA FAST COMPUTER EM 09/2008                        *      */
        /*"      * DEMANDA DA GEFAB/CAIXA SEGUROS                                 *      */
        /*"      * MUDAR O LIMITE DE ESTOURO DA TABELA PARA 99999999              *      */
        /*"      * PASSA A UTILIZAR A DATA_MOV_ABERTO DA SISTEMAS                 *      */
        /*"      * 1 SINISTRO GERA 1 NUMERO DE SIVAT                              *      */
        /*"      * SSI/CADMUS = 13008                                             *      */
        /*"      * PROCURAR POR V.01                                              *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  HOST-DT-MOVABTO-MENOS-10DIAS   PIC X(10) VALUE SPACES.*/
        public StringBasis HOST_DT_MOVABTO_MENOS_10DIAS { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"01 FILLER.*/
        public SI5040B_FILLER_0 FILLER_0 { get; set; } = new SI5040B_FILLER_0();
        public class SI5040B_FILLER_0 : VarBasis
        {
            /*"    03 FILLER                   PIC X(33)     VALUE       '*** INICIO DA WORKING-STORAGE ***'.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "33", "X(33)"), @"*** INICIO DA WORKING-STORAGE ***");
            /*"    03 CA-NUMERO-PRODIG11       PIC 9(18)     VALUE ZEROS.*/
            public IntBasis CA_NUMERO_PRODIG11 { get; set; } = new IntBasis(new PIC("9", "18", "9(18)"));
            /*"    03 CA-DIGITO-PRODIG11       PIC 9(01)     VALUE ZEROS.*/
            public IntBasis CA_DIGITO_PRODIG11 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
            /*"    03 CA-IDENT-MOV             PIC X(23)     VALUE SPACES.*/
            public StringBasis CA_IDENT_MOV { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
            /*"    03 CT-UP-RALCHEDO           PIC 9(07)     VALUE ZEROS.*/
            public IntBasis CT_UP_RALCHEDO { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
            /*"    03 CT-CR-SIVAT              PIC 9(07)     VALUE ZEROS.*/
            public IntBasis CT_CR_SIVAT { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
            /*"    03 AT-CR-SIVAT                             VALUE LOW-VALUE.*/
            public SI5040B_AT_CR_SIVAT AT_CR_SIVAT { get; set; } = new SI5040B_AT_CR_SIVAT();
            public class SI5040B_AT_CR_SIVAT : VarBasis
            {
                /*"       06 AT-IDENT-MOV           PIC X(23).*/
                public StringBasis AT_IDENT_MOV { get; set; } = new StringBasis(new PIC("X", "23", "X(23)."), @"");
                /*"       06 AT-COD-PRODUTO         PIC 9(04).*/
                public IntBasis AT_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       06 AT-AGE-CENTRAL         PIC 9(04).*/
                public IntBasis AT_AGE_CENTRAL { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"    03 AN-CR-SIVAT                             VALUE LOW-VALUE.*/
            }
            public SI5040B_AN_CR_SIVAT AN_CR_SIVAT { get; set; } = new SI5040B_AN_CR_SIVAT();
            public class SI5040B_AN_CR_SIVAT : VarBasis
            {
                /*"       06 AN-IDENT-MOV           PIC X(23).*/
                public StringBasis AN_IDENT_MOV { get; set; } = new StringBasis(new PIC("X", "23", "X(23)."), @"");
                /*"       06 AN-COD-PRODUTO         PIC 9(04).*/
                public IntBasis AN_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       06 AN-AGE-CENTRAL         PIC 9(04).*/
                public IntBasis AN_AGE_CENTRAL { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"    03 QBAT-CR-SIVAT             PIC X(10)    VALUE LOW-VALUE.*/
            }
            public StringBasis QBAT_CR_SIVAT { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"01  FILLER.*/
        }
        public SI5040B_FILLER_2 FILLER_2 { get; set; } = new SI5040B_FILLER_2();
        public class SI5040B_FILLER_2 : VarBasis
        {
            /*"    05 WERRO                         PIC S9(09) VALUE ZEROS.*/
            public IntBasis WERRO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"    05 WABEND.*/
            public SI5040B_WABEND WABEND { get; set; } = new SI5040B_WABEND();
            public class SI5040B_WABEND : VarBasis
            {
                /*"       10 FILLER                     PIC  X(10) VALUE          ' SI5040B '.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @" SI5040B ");
                /*"       10 FILLER                     PIC  X(28) VALUE          ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "28", "X(28)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"       10 WNR-EXEC-SQL               PIC  X(04) VALUE '0000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"0000");
                /*"       10 FILLER                     PIC  X(14) VALUE          ' SQLCODE = '.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @" SQLCODE = ");
                /*"       10 WSQLCODE                   PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            }
        }


        public Dclgens.CHEQUEMI CHEQUEMI { get; set; } = new Dclgens.CHEQUEMI();
        public Dclgens.RALCHEDO RALCHEDO { get; set; } = new Dclgens.RALCHEDO();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.GEOPERAC GEOPERAC { get; set; } = new Dclgens.GEOPERAC();
        public Dclgens.NUMEROUT NUMEROUT { get; set; } = new Dclgens.NUMEROUT();

        public SI5040B_CR_SIVAT CR_SIVAT { get; set; } = new SI5040B_CR_SIVAT(true);
        string GetQuery_CR_SIVAT()
        {
            var query = @$"SELECT 'INDE - NAO CENTRALIZADA'
							, C.TIPO_MOVIMENTO
							, C.COD_FONTE
							, C.NUM_DOCUMENTO
							, C.NOME_FAVORECIDO
							, C.VAL_CHEQUE
							, C.NUM_CHEQUE_INTERNO
							, C.DIG_CHEQUE_INTERNO
							, C.PRACA_PAGAMENTO
							, C.DATA_LANCAMENTO
							, R.NUM_DOCUMENTO
							, R.AGENCIA_CONTRATO
							, R.AGE_CENTRAL_PROD01
							, R.OCORR_HISTORICO
							, H.COD_PRODUTO
							, H.NUM_APOL_SINISTRO
							FROM SEGUROS.CHEQUES_EMITIDOS C
							, SEGUROS.RALACAO_CHEQ_DOCTO R
							, SEGUROS.SINISTRO_HISTORICO H
							, SEGUROS.GE_OPERACAO O WHERE C.DATA_MOVIMENTO BETWEEN '{HOST_DT_MOVABTO_MENOS_10DIAS}' AND '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' AND C.COD_OPERACAO = 101 AND C.SIT_REGISTRO IN ('0'
							,'1') AND C.TIPO_PAGAMENTO = '7' AND R.NUMERO_SIVAT = 0 AND R.AGE_CENTRAL_PROD01 = 0 AND R.DV_SIVAT IN ('0'
							, ' ') AND R.NUM_CHEQUE_INTERNO = C.NUM_CHEQUE_INTERNO AND H.NUM_APOL_SINISTRO = R.NUMDOC_NUM01 AND H.OCORR_HISTORICO = R.OCORR_HISTORICO AND O.COD_OPERACAO = H.COD_OPERACAO AND O.IDE_SISTEMA = 'SI' AND O.FUNCAO_OPERACAO IN ('IND'
							, 'JBIND'
							, 'DPAG'
							, 'HPAG'
							, 'DSPAG'
							, 'HSPAG'
							, 'APAG' ) UNION ALL SELECT 'INDE - CENTRALIZADA....'
							, C.TIPO_MOVIMENTO
							, C.COD_FONTE
							, C.NUM_DOCUMENTO
							, C.NOME_FAVORECIDO
							, C.VAL_CHEQUE
							, C.NUM_CHEQUE_INTERNO
							, C.DIG_CHEQUE_INTERNO
							, C.PRACA_PAGAMENTO
							, C.DATA_LANCAMENTO
							, R.NUM_DOCUMENTO
							, R.AGENCIA_CONTRATO
							, R.AGE_CENTRAL_PROD01
							, R.OCORR_HISTORICO
							, H.COD_PRODUTO
							, H.NUM_APOL_SINISTRO
							FROM SEGUROS.CHEQUES_EMITIDOS C
							, SEGUROS.RALACAO_CHEQ_DOCTO R
							, SEGUROS.SINISTRO_HISTORICO H
							, SEGUROS.GE_OPERACAO O WHERE C.DATA_MOVIMENTO = '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' AND C.COD_OPERACAO = 101 AND C.SIT_REGISTRO IN ('0'
							,'1') AND C.TIPO_PAGAMENTO = '7' AND R.NUMERO_SIVAT = 0 AND R.AGE_CENTRAL_PROD01 <> 0 AND R.DV_SIVAT IN ('0'
							, ' ') AND R.NUM_CHEQUE_INTERNO = C.NUM_CHEQUE_INTERNO AND H.NUM_APOL_SINISTRO = R.NUMDOC_NUM01 AND H.OCORR_HISTORICO = R.OCORR_HISTORICO AND O.COD_OPERACAO = H.COD_OPERACAO AND O.IDE_SISTEMA = 'SI' AND O.FUNCAO_OPERACAO IN ('IND'
							, 'JBIND'
							, 'DPAG'
							, 'HPAG'
							, 'DSPAG'
							, 'HSPAG'
							, 'APAG' ) UNION ALL SELECT 'REPA - NAO CENTRALIZADO'
							, C.TIPO_MOVIMENTO
							, C.COD_FONTE
							, C.NUM_DOCUMENTO
							, C.NOME_FAVORECIDO
							, C.VAL_CHEQUE
							, C.NUM_CHEQUE_INTERNO
							, C.DIG_CHEQUE_INTERNO
							, C.PRACA_PAGAMENTO
							, C.DATA_LANCAMENTO
							, R.NUM_DOCUMENTO
							, R.AGENCIA_CONTRATO
							, R.AGE_CENTRAL_PROD01
							, R.OCORR_HISTORICO
							, H.COD_PRODUTO
							, H.NUM_APOL_SINISTRO
							FROM SEGUROS.CHEQUES_EMITIDOS C
							, SEGUROS.RALACAO_CHEQ_DOCTO R
							, SEGUROS.SINISTRO_HISTORICO H
							, SEGUROS.GE_OPERACAO O WHERE C.DATA_MOVIMENTO = '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' AND C.COD_OPERACAO = 101 AND C.SIT_REGISTRO IN ('0'
							,'1') AND C.TIPO_PAGAMENTO = '7' AND R.NUMERO_SIVAT = 0 AND R.AGE_CENTRAL_PROD01 = 0 AND R.DV_SIVAT IN ('0'
							, ' ') AND R.NUM_CHEQUE_INTERNO = C.NUM_CHEQUE_INTERNO AND H.NUM_APOL_SINISTRO = R.NUMDOC_NUM01 AND H.OCORR_HISTORICO = R.OCORR_HISTORICO AND O.COD_OPERACAO = H.COD_OPERACAO AND O.IDE_SISTEMA = 'SI' AND O.FUNCAO_OPERACAO = 'RSREP' UNION ALL SELECT 'REPA - CENTRALIZADO....'
							, C.TIPO_MOVIMENTO
							, C.COD_FONTE
							, C.NUM_DOCUMENTO
							, C.NOME_FAVORECIDO
							, C.VAL_CHEQUE
							, C.NUM_CHEQUE_INTERNO
							, C.DIG_CHEQUE_INTERNO
							, C.PRACA_PAGAMENTO
							, C.DATA_LANCAMENTO
							, R.NUM_DOCUMENTO
							, R.AGENCIA_CONTRATO
							, R.AGE_CENTRAL_PROD01
							, R.OCORR_HISTORICO
							, H.COD_PRODUTO
							, H.NUM_APOL_SINISTRO
							FROM SEGUROS.CHEQUES_EMITIDOS C
							, SEGUROS.RALACAO_CHEQ_DOCTO R
							, SEGUROS.SINISTRO_HISTORICO H
							, SEGUROS.GE_OPERACAO O WHERE C.DATA_MOVIMENTO = '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' AND C.COD_OPERACAO = 101 AND C.SIT_REGISTRO IN ('0'
							,'1') AND C.TIPO_PAGAMENTO = '7' AND R.NUMERO_SIVAT = 0 AND R.AGE_CENTRAL_PROD01 <> 0 AND R.DV_SIVAT IN ('0'
							, ' ') AND R.NUM_CHEQUE_INTERNO = C.NUM_CHEQUE_INTERNO AND H.NUM_APOL_SINISTRO = R.NUMDOC_NUM01 AND H.OCORR_HISTORICO = R.OCORR_HISTORICO AND O.COD_OPERACAO = H.COD_OPERACAO AND O.IDE_SISTEMA = 'SI' AND O.FUNCAO_OPERACAO = 'RSREP' ORDER BY 1
							, 7
							,15
							, 13
							, 12
							, 16";

            return query;
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                InitializeGetQuery();

                /*" -301- DISPLAY '*** SI5040B-V001 - INICIO DE PROCESSAMENTO ***' . */
                _.Display($"*** SI5040B-V001 - INICIO DE PROCESSAMENTO ***");

                /*" -301- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -302- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -303- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -307- PERFORM R10-BUSCA-DATA-SISTEMA THRU R10-FIM. */

                R10_BUSCA_DATA_SISTEMA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R10_FIM*/


                /*" -309- PERFORM R20-LE-NUMERO-OUTROS THRU R20-FIM. */

                R20_LE_NUMERO_OUTROS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R20_FIM*/


                /*" -314- PERFORM R30-PRINCIPAL THRU R30-FIM. */

                R30_PRINCIPAL(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R30_FIM*/


                /*" -316- EXEC SQL COMMIT WORK END-EXEC. */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -319- DISPLAY '*** SI5040B - TOTAL LIDOS CR_SIVAT = ' CT-CR-SIVAT. */
                _.Display($"*** SI5040B - TOTAL LIDOS CR_SIVAT = {FILLER_0.CT_CR_SIVAT}");

                /*" -321- DISPLAY '*** SI5040B - TOTAL ATUALIZADOS    = ' CT-UP-RALCHEDO. */
                _.Display($"*** SI5040B - TOTAL ATUALIZADOS    = {FILLER_0.CT_UP_RALCHEDO}");

                /*" -323- DISPLAY '*** SI5040B - FIM NORMAL ***' . */
                _.Display($"*** SI5040B - FIM NORMAL ***");

                /*" -323- STOP RUN. */

                throw new GoBack();   // => STOP RUN.

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            return Result;
        }

        public void InitializeGetQuery()
        {
            CR_SIVAT.GetQueryEvent += GetQuery_CR_SIVAT;
        }

        [StopWatch]
        /*" R10-BUSCA-DATA-SISTEMA */
        private void R10_BUSCA_DATA_SISTEMA(bool isPerform = false)
        {
            /*" -333- MOVE '001' TO WNR-EXEC-SQL. */
            _.Move("001", FILLER_2.WABEND.WNR_EXEC_SQL);

            /*" -345- PERFORM R10_BUSCA_DATA_SISTEMA_DB_SELECT_1 */

            R10_BUSCA_DATA_SISTEMA_DB_SELECT_1();

            /*" -351- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -352- DISPLAY '*** SI5040B - ERRO ACESSO SISTEMAS ***' */
                _.Display($"*** SI5040B - ERRO ACESSO SISTEMAS ***");

                /*" -353- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -355- END-IF. */
            }


            /*" -356- DISPLAY 'DATAS SELECIONADAS NA SISTEMAS - FI' . */
            _.Display($"DATAS SELECIONADAS NA SISTEMAS - FI");

            /*" -357- DISPLAY 'DTMOVABE.......' SISTEMAS-DATA-MOV-ABERTO. */
            _.Display($"DTMOVABE.......{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -357- DISPLAY 'DTULTPCS.......' SISTEMAS-DATULT-PROCESSAMEN. */
            _.Display($"DTULTPCS.......{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATULT_PROCESSAMEN}");

        }

        [StopWatch]
        /*" R10-BUSCA-DATA-SISTEMA-DB-SELECT-1 */
        public void R10_BUSCA_DATA_SISTEMA_DB_SELECT_1()
        {
            /*" -345- EXEC SQL SELECT DATA_MOV_ABERTO, DATA_MOV_ABERTO - 10 DAYS, DATULT_PROCESSAMEN INTO :SISTEMAS-DATA-MOV-ABERTO, :HOST-DT-MOVABTO-MENOS-10DIAS, :SISTEMAS-DATULT-PROCESSAMEN FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'FI' END-EXEC. */

            var r10_BUSCA_DATA_SISTEMA_DB_SELECT_1_Query1 = new R10_BUSCA_DATA_SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R10_BUSCA_DATA_SISTEMA_DB_SELECT_1_Query1.Execute(r10_BUSCA_DATA_SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.HOST_DT_MOVABTO_MENOS_10DIAS, HOST_DT_MOVABTO_MENOS_10DIAS);
                _.Move(executed_1.SISTEMAS_DATULT_PROCESSAMEN, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATULT_PROCESSAMEN);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R10_FIM*/

        [StopWatch]
        /*" R20-LE-NUMERO-OUTROS */
        private void R20_LE_NUMERO_OUTROS(bool isPerform = false)
        {
            /*" -370- MOVE '002' TO WNR-EXEC-SQL. */
            _.Move("002", FILLER_2.WABEND.WNR_EXEC_SQL);

            /*" -377- PERFORM R20_LE_NUMERO_OUTROS_DB_SELECT_1 */

            R20_LE_NUMERO_OUTROS_DB_SELECT_1();

            /*" -380- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -381- DISPLAY '*** SI5040B - ERRO SELECT NUMERO_OUTROS ***' */
                _.Display($"*** SI5040B - ERRO SELECT NUMERO_OUTROS ***");

                /*" -382- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -382- END-IF. */
            }


        }

        [StopWatch]
        /*" R20-LE-NUMERO-OUTROS-DB-SELECT-1 */
        public void R20_LE_NUMERO_OUTROS_DB_SELECT_1()
        {
            /*" -377- EXEC SQL SELECT VALUE(NUM_SIVAT,0) INTO :NUMEROUT-NUM-SIVAT FROM SEGUROS.NUMERO_OUTROS END-EXEC. */

            var r20_LE_NUMERO_OUTROS_DB_SELECT_1_Query1 = new R20_LE_NUMERO_OUTROS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R20_LE_NUMERO_OUTROS_DB_SELECT_1_Query1.Execute(r20_LE_NUMERO_OUTROS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUMEROUT_NUM_SIVAT, NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_SIVAT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R20_FIM*/

        [StopWatch]
        /*" R30-PRINCIPAL */
        private void R30_PRINCIPAL(bool isPerform = false)
        {
            /*" -395- PERFORM R300-OPEN-CR-SIVAT THRU R300-FIM. */

            R300_OPEN_CR_SIVAT(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R300_FIM*/


            /*" -398- PERFORM R310-LE-CR-SIVAT THRU R310-FIM UNTIL QBAT-CR-SIVAT EQUAL HIGH-VALUE. */

            while (!(FILLER_0.QBAT_CR_SIVAT.IsHighValues))
            {

                R310_LE_CR_SIVAT(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R310_FIM*/

            }

            /*" -400- PERFORM R320-CLOSE-CR-SIVAT THRU R320-FIM. */

            R320_CLOSE_CR_SIVAT(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R320_FIM*/


            /*" -401- IF CT-CR-SIVAT GREATER ZEROS */

            if (FILLER_0.CT_CR_SIVAT > 00)
            {

                /*" -402- PERFORM R330-ATUALIZA-NUM-SIVAT THRU R330-FIM */

                R330_ATUALIZA_NUM_SIVAT(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R330_FIM*/


                /*" -402- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R30_FIM*/

        [StopWatch]
        /*" R300-OPEN-CR-SIVAT */
        private void R300_OPEN_CR_SIVAT(bool isPerform = false)
        {
            /*" -415- MOVE '003' TO WNR-EXEC-SQL. */
            _.Move("003", FILLER_2.WABEND.WNR_EXEC_SQL);

            /*" -417- PERFORM R300_OPEN_CR_SIVAT_DB_OPEN_1 */

            R300_OPEN_CR_SIVAT_DB_OPEN_1();

            /*" -420- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -421- DISPLAY '** SI5040B - ERRO NO OPEN DO CURSOR CR_SIVAT **' */
                _.Display($"** SI5040B - ERRO NO OPEN DO CURSOR CR_SIVAT **");

                /*" -422- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -422- END-IF. */
            }


        }

        [StopWatch]
        /*" R300-OPEN-CR-SIVAT-DB-OPEN-1 */
        public void R300_OPEN_CR_SIVAT_DB_OPEN_1()
        {
            /*" -417- EXEC SQL OPEN CR_SIVAT END-EXEC. */

            CR_SIVAT.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R300_FIM*/

        [StopWatch]
        /*" R310-LE-CR-SIVAT */
        private void R310_LE_CR_SIVAT(bool isPerform = false)
        {
            /*" -434- MOVE '004' TO WNR-EXEC-SQL. */
            _.Move("004", FILLER_2.WABEND.WNR_EXEC_SQL);

            /*" -436- MOVE AT-CR-SIVAT TO AN-CR-SIVAT. */
            _.Move(FILLER_0.AT_CR_SIVAT, FILLER_0.AN_CR_SIVAT);

            /*" -455- PERFORM R310_LE_CR_SIVAT_DB_FETCH_1 */

            R310_LE_CR_SIVAT_DB_FETCH_1();

            /*" -458- IF SQLCODE EQUAL +100 */

            if (DB.SQLCODE == +100)
            {

                /*" -459- MOVE HIGH-VALUE TO QBAT-CR-SIVAT */

                FILLER_0.QBAT_CR_SIVAT.IsHighValues = true;

                /*" -460- GO TO R310-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R310_FIM*/ //GOTO
                return;

                /*" -462- END-IF. */
            }


            /*" -463- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -464- DISPLAY '*** SI5040B - ERRO NO FETCH CURSOR CR_SIVAT ***' */
                _.Display($"*** SI5040B - ERRO NO FETCH CURSOR CR_SIVAT ***");

                /*" -465- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -467- END-IF. */
            }


            /*" -469- ADD 1 TO CT-CR-SIVAT. */
            FILLER_0.CT_CR_SIVAT.Value = FILLER_0.CT_CR_SIVAT + 1;

            /*" -470- MOVE CA-IDENT-MOV TO AT-IDENT-MOV. */
            _.Move(FILLER_0.CA_IDENT_MOV, FILLER_0.AT_CR_SIVAT.AT_IDENT_MOV);

            /*" -471- MOVE SINISHIS-COD-PRODUTO TO AT-COD-PRODUTO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PRODUTO, FILLER_0.AT_CR_SIVAT.AT_COD_PRODUTO);

            /*" -477- MOVE RALCHEDO-AGE-CENTRAL-PROD01 TO AT-AGE-CENTRAL. */
            _.Move(RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_AGE_CENTRAL_PROD01, FILLER_0.AT_CR_SIVAT.AT_AGE_CENTRAL);

            /*" -477- PERFORM R3100-PROCESSA-SIVAT THRU R3100-FIM. */

            R3100_PROCESSA_SIVAT(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_FIM*/


        }

        [StopWatch]
        /*" R310-LE-CR-SIVAT-DB-FETCH-1 */
        public void R310_LE_CR_SIVAT_DB_FETCH_1()
        {
            /*" -455- EXEC SQL FETCH CR_SIVAT INTO :CA-IDENT-MOV, :CHEQUEMI-TIPO-MOVIMENTO, :CHEQUEMI-COD-FONTE, :CHEQUEMI-NUM-DOCUMENTO, :CHEQUEMI-NOME-FAVORECIDO, :CHEQUEMI-VAL-CHEQUE, :CHEQUEMI-NUM-CHEQUE-INTERNO, :CHEQUEMI-DIG-CHEQUE-INTERNO, :CHEQUEMI-PRACA-PAGAMENTO, :CHEQUEMI-DATA-LANCAMENTO, :RALCHEDO-NUM-DOCUMENTO, :RALCHEDO-AGENCIA-CONTRATO, :RALCHEDO-AGE-CENTRAL-PROD01, :RALCHEDO-OCORR-HISTORICO, :SINISHIS-COD-PRODUTO, :SINISHIS-NUM-APOL-SINISTRO END-EXEC. */

            if (CR_SIVAT.Fetch())
            {
                _.Move(CR_SIVAT.CA_IDENT_MOV, FILLER_0.CA_IDENT_MOV);
                _.Move(CR_SIVAT.CHEQUEMI_TIPO_MOVIMENTO, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_TIPO_MOVIMENTO);
                _.Move(CR_SIVAT.CHEQUEMI_COD_FONTE, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_COD_FONTE);
                _.Move(CR_SIVAT.CHEQUEMI_NUM_DOCUMENTO, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NUM_DOCUMENTO);
                _.Move(CR_SIVAT.CHEQUEMI_NOME_FAVORECIDO, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NOME_FAVORECIDO);
                _.Move(CR_SIVAT.CHEQUEMI_VAL_CHEQUE, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_VAL_CHEQUE);
                _.Move(CR_SIVAT.CHEQUEMI_NUM_CHEQUE_INTERNO, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NUM_CHEQUE_INTERNO);
                _.Move(CR_SIVAT.CHEQUEMI_DIG_CHEQUE_INTERNO, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_DIG_CHEQUE_INTERNO);
                _.Move(CR_SIVAT.CHEQUEMI_PRACA_PAGAMENTO, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_PRACA_PAGAMENTO);
                _.Move(CR_SIVAT.CHEQUEMI_DATA_LANCAMENTO, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_DATA_LANCAMENTO);
                _.Move(CR_SIVAT.RALCHEDO_NUM_DOCUMENTO, RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_NUM_DOCUMENTO);
                _.Move(CR_SIVAT.RALCHEDO_AGENCIA_CONTRATO, RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_AGENCIA_CONTRATO);
                _.Move(CR_SIVAT.RALCHEDO_AGE_CENTRAL_PROD01, RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_AGE_CENTRAL_PROD01);
                _.Move(CR_SIVAT.RALCHEDO_OCORR_HISTORICO, RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_OCORR_HISTORICO);
                _.Move(CR_SIVAT.SINISHIS_COD_PRODUTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PRODUTO);
                _.Move(CR_SIVAT.SINISHIS_NUM_APOL_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R310_FIM*/

        [StopWatch]
        /*" R3100-PROCESSA-SIVAT */
        private void R3100_PROCESSA_SIVAT(bool isPerform = false)
        {
            /*" -501- PERFORM R31000-BUSCA-NUM-SIVAT THRU R31000-FIM */

            R31000_BUSCA_NUM_SIVAT(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R31000_FIM*/


            /*" -502- IF SINISHIS-COD-PRODUTO EQUAL 4801 OR 4812 OR 7001 */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PRODUTO.In("4801", "4812", "7001"))
            {

                /*" -503- IF RALCHEDO-AGE-CENTRAL-PROD01 EQUAL ZEROS */

                if (RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_AGE_CENTRAL_PROD01 == 00)
                {

                    /*" -504- DISPLAY 'SI5040B - PGM CANCELADO TEM AGENCIA ' */
                    _.Display($"SI5040B - PGM CANCELADO TEM AGENCIA ");

                    /*" -505- DISPLAY 'CENTRALIZADORA ZERADA. ' */
                    _.Display($"CENTRALIZADORA ZERADA. ");

                    /*" -506- DISPLAY 'SINISTRO = ' SINISHIS-NUM-APOL-SINISTRO */
                    _.Display($"SINISTRO = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                    /*" -507- DISPLAY 'AGENCIA CONTRATO = ' RALCHEDO-AGENCIA-CONTRATO */
                    _.Display($"AGENCIA CONTRATO = {RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_AGENCIA_CONTRATO}");

                    /*" -508- DISPLAY 'AVISAR IMEDIATAMENTE OS ANALISTAS' */
                    _.Display($"AVISAR IMEDIATAMENTE OS ANALISTAS");

                    /*" -509- DISPLAY 'RESPONSAVEIS ' */
                    _.Display($"RESPONSAVEIS ");

                    /*" -510- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;

                    /*" -511- END-IF */
                }


                /*" -513- END-IF. */
            }


            /*" -513- PERFORM R31010-UPDATE-NUM-SIVAT THRU R31010-FIM. */

            R31010_UPDATE_NUM_SIVAT(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R31010_FIM*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_FIM*/

        [StopWatch]
        /*" R31000-BUSCA-NUM-SIVAT */
        private void R31000_BUSCA_NUM_SIVAT(bool isPerform = false)
        {
            /*" -527- ADD 1 TO NUMEROUT-NUM-SIVAT. */
            NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_SIVAT.Value = NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_SIVAT + 1;

            /*" -528- IF NUMEROUT-NUM-SIVAT GREATER 99999999 */

            if (NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_SIVAT > 99999999)
            {

                /*" -530- DISPLAY '*** SI5040B - ESTOURO DA NUMERACAO DO SIVAT ***' */
                _.Display($"*** SI5040B - ESTOURO DA NUMERACAO DO SIVAT ***");

                /*" -531- DISPLAY '*** SI5040B - NUMERACAO SUPERIOR A 99999999 ***' */
                _.Display($"*** SI5040B - NUMERACAO SUPERIOR A 99999999 ***");

                /*" -532- DISPLAY '*** SI5040B - SOLICITAR NOVA NUMERACAO COM  ***' */
                _.Display($"*** SI5040B - SOLICITAR NOVA NUMERACAO COM  ***");

                /*" -533- DISPLAY '*** SI5040B - GETEC.                        ***' */
                _.Display($"*** SI5040B - GETEC.                        ***");

                /*" -534- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -536- END-IF. */
            }


            /*" -538- MOVE NUMEROUT-NUM-SIVAT TO CA-NUMERO-PRODIG11. */
            _.Move(NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_SIVAT, FILLER_0.CA_NUMERO_PRODIG11);

            /*" -541- CALL 'PRODIG11' USING CA-NUMERO-PRODIG11 CA-DIGITO-PRODIG11. */
            _.Call("PRODIG11", FILLER_0);

            /*" -542- MOVE NUMEROUT-NUM-SIVAT TO RALCHEDO-NUMERO-SIVAT. */
            _.Move(NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_SIVAT, RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_NUMERO_SIVAT);

            /*" -542- MOVE CA-DIGITO-PRODIG11 TO RALCHEDO-DV-SIVAT. */
            _.Move(FILLER_0.CA_DIGITO_PRODIG11, RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_DV_SIVAT);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R31000_FIM*/

        [StopWatch]
        /*" R31010-UPDATE-NUM-SIVAT */
        private void R31010_UPDATE_NUM_SIVAT(bool isPerform = false)
        {
            /*" -555- MOVE '005' TO WNR-EXEC-SQL. */
            _.Move("005", FILLER_2.WABEND.WNR_EXEC_SQL);

            /*" -568- PERFORM R31010_UPDATE_NUM_SIVAT_DB_UPDATE_1 */

            R31010_UPDATE_NUM_SIVAT_DB_UPDATE_1();

            /*" -571- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -572- DISPLAY '*** SI5040B - ERRO NO UPDATE RALCHEDO ***' */
                _.Display($"*** SI5040B - ERRO NO UPDATE RALCHEDO ***");

                /*" -573- DISPLAY 'CHEQUE INTERNO = ' CHEQUEMI-NUM-CHEQUE-INTERNO */
                _.Display($"CHEQUE INTERNO = {CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NUM_CHEQUE_INTERNO}");

                /*" -574- DISPLAY 'SINISTRO       = ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO       = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -575- DISPLAY 'NUMERO_SIVAT   = ' RALCHEDO-NUMERO-SIVAT */
                _.Display($"NUMERO_SIVAT   = {RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_NUMERO_SIVAT}");

                /*" -576- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -581- END-IF. */
            }


            /*" -581- ADD 1 TO CT-UP-RALCHEDO. */
            FILLER_0.CT_UP_RALCHEDO.Value = FILLER_0.CT_UP_RALCHEDO + 1;

        }

        [StopWatch]
        /*" R31010-UPDATE-NUM-SIVAT-DB-UPDATE-1 */
        public void R31010_UPDATE_NUM_SIVAT_DB_UPDATE_1()
        {
            /*" -568- EXEC SQL UPDATE SEGUROS.RALACAO_CHEQ_DOCTO SET NUMERO_SIVAT = :RALCHEDO-NUMERO-SIVAT, DV_SIVAT = :RALCHEDO-DV-SIVAT, DATA_SIVAT = :SISTEMAS-DATA-MOV-ABERTO WHERE NUM_CHEQUE_INTERNO = :CHEQUEMI-NUM-CHEQUE-INTERNO AND DIG_CHEQUE_INTERNO = :CHEQUEMI-DIG-CHEQUE-INTERNO AND NUM_DOCUMENTO = :RALCHEDO-NUM-DOCUMENTO AND AGENCIA_CONTRATO = :RALCHEDO-AGENCIA-CONTRATO AND AGE_CENTRAL_PROD01 = :RALCHEDO-AGE-CENTRAL-PROD01 AND OCORR_HISTORICO = :RALCHEDO-OCORR-HISTORICO END-EXEC. */

            var r31010_UPDATE_NUM_SIVAT_DB_UPDATE_1_Update1 = new R31010_UPDATE_NUM_SIVAT_DB_UPDATE_1_Update1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                RALCHEDO_NUMERO_SIVAT = RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_NUMERO_SIVAT.ToString(),
                RALCHEDO_DV_SIVAT = RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_DV_SIVAT.ToString(),
                CHEQUEMI_NUM_CHEQUE_INTERNO = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NUM_CHEQUE_INTERNO.ToString(),
                CHEQUEMI_DIG_CHEQUE_INTERNO = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_DIG_CHEQUE_INTERNO.ToString(),
                RALCHEDO_AGE_CENTRAL_PROD01 = RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_AGE_CENTRAL_PROD01.ToString(),
                RALCHEDO_AGENCIA_CONTRATO = RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_AGENCIA_CONTRATO.ToString(),
                RALCHEDO_OCORR_HISTORICO = RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_OCORR_HISTORICO.ToString(),
                RALCHEDO_NUM_DOCUMENTO = RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_NUM_DOCUMENTO.ToString(),
            };

            R31010_UPDATE_NUM_SIVAT_DB_UPDATE_1_Update1.Execute(r31010_UPDATE_NUM_SIVAT_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R31010_FIM*/

        [StopWatch]
        /*" R320-CLOSE-CR-SIVAT */
        private void R320_CLOSE_CR_SIVAT(bool isPerform = false)
        {
            /*" -594- MOVE '006' TO WNR-EXEC-SQL. */
            _.Move("006", FILLER_2.WABEND.WNR_EXEC_SQL);

            /*" -596- PERFORM R320_CLOSE_CR_SIVAT_DB_CLOSE_1 */

            R320_CLOSE_CR_SIVAT_DB_CLOSE_1();

            /*" -599- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -600- DISPLAY '** SI5040B - ERRO NO CLOSE CURSOR CR_SIVAT **' */
                _.Display($"** SI5040B - ERRO NO CLOSE CURSOR CR_SIVAT **");

                /*" -601- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -601- END-IF. */
            }


        }

        [StopWatch]
        /*" R320-CLOSE-CR-SIVAT-DB-CLOSE-1 */
        public void R320_CLOSE_CR_SIVAT_DB_CLOSE_1()
        {
            /*" -596- EXEC SQL CLOSE CR_SIVAT END-EXEC. */

            CR_SIVAT.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R320_FIM*/

        [StopWatch]
        /*" R330-ATUALIZA-NUM-SIVAT */
        private void R330_ATUALIZA_NUM_SIVAT(bool isPerform = false)
        {
            /*" -614- MOVE '007' TO WNR-EXEC-SQL. */
            _.Move("007", FILLER_2.WABEND.WNR_EXEC_SQL);

            /*" -618- PERFORM R330_ATUALIZA_NUM_SIVAT_DB_UPDATE_1 */

            R330_ATUALIZA_NUM_SIVAT_DB_UPDATE_1();

            /*" -621- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -622- DISPLAY 'PROBLEMAS UPDATE V0NUMERO_OUTROS. ' */
                _.Display($"PROBLEMAS UPDATE V0NUMERO_OUTROS. ");

                /*" -623- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -623- END-IF. */
            }


        }

        [StopWatch]
        /*" R330-ATUALIZA-NUM-SIVAT-DB-UPDATE-1 */
        public void R330_ATUALIZA_NUM_SIVAT_DB_UPDATE_1()
        {
            /*" -618- EXEC SQL UPDATE SEGUROS.NUMERO_OUTROS SET NUM_SIVAT = :NUMEROUT-NUM-SIVAT WHERE 1 = 1 END-EXEC. */

            var r330_ATUALIZA_NUM_SIVAT_DB_UPDATE_1_Update1 = new R330_ATUALIZA_NUM_SIVAT_DB_UPDATE_1_Update1()
            {
                NUMEROUT_NUM_SIVAT = NUMEROUT.DCLNUMERO_OUTROS.NUMEROUT_NUM_SIVAT.ToString(),
            };

            R330_ATUALIZA_NUM_SIVAT_DB_UPDATE_1_Update1.Execute(r330_ATUALIZA_NUM_SIVAT_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R330_FIM*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO */
        private void R9999_00_ROT_ERRO(bool isPerform = false)
        {
            /*" -635- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -636- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, FILLER_2.WABEND.WSQLCODE);

                /*" -637- DISPLAY WABEND */
                _.Display(FILLER_2.WABEND);

                /*" -638- MOVE SQLERRD(1) TO WSQLCODE */
                _.Move(DB.SQLERRD[1], FILLER_2.WABEND.WSQLCODE);

                /*" -639- DISPLAY ' SQLERRD1 = ' WSQLCODE */
                _.Display($" SQLERRD1 = {FILLER_2.WABEND.WSQLCODE}");

                /*" -640- MOVE SQLERRD(2) TO WSQLCODE */
                _.Move(DB.SQLERRD[2], FILLER_2.WABEND.WSQLCODE);

                /*" -641- DISPLAY ' SQLERRD2 = ' WSQLCODE */
                _.Display($" SQLERRD2 = {FILLER_2.WABEND.WSQLCODE}");

                /*" -642- MOVE SQLCODE TO WERRO */
                _.Move(DB.SQLCODE, FILLER_2.WERRO);

                /*" -643- ELSE */
            }
            else
            {


                /*" -645- MOVE -999 TO WERRO. */
                _.Move(-999, FILLER_2.WERRO);
            }


            /*" -645- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -646- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -650- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -650- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_EXIT*/
    }
}