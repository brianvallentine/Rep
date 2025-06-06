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
using Sias.Sinistro.DB2.SI0006S;

namespace Code
{
    public class SI0006S
    {
        public bool IsCall { get; set; }

        public SI0006S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SINISTRO / LOTERICO                *      */
        /*"      *   SUBROTINA ..............  SI0006S                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  MAURICIO LINKE - CONTRASTE         *      */
        /*"      *   PROGRAMADOR ............  MAURICIO LINKE - CONTRASTE         *      */
        /*"      *   DATA CODIFICACAO .......  DEZEMBRO / 2004.                   *      */
        /*"      *   VERSAO .................  08012009 17:00HS                   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO ....... SUBROTINA PARA CALCULO DE SALDO DA IS (IMPOR- *      */
        /*"      *                  TANCIA SEGURADA), A PARTIR DE PARAMETROS RECE-*      */
        /*"      *                  BIDOS. BATCH.                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.07  *   MICHAEL NOGUEIRA  - 27/08/2019 - CADMUS 176076 E 176034      *      */
        /*"      *                     - CORRIGINDO O DISPLAY PARA O RC EM VEZ DE *      */
        /*"      *                     - SQLCODE                                  *      */
        /*"      *                                 PROCURAR   V.07                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.06  *   LISIANE B SOARES  - 09/11/2017         - CADMUS 155460       *      */
        /*"      *                     - ALTERADO PARA CONSIDERAR A OPERACAO 4000 *      */
        /*"      *                                 PROCURAR   V.06                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.05  *   GUILHERME CORREIA - 25/02/2016         - CADMUS 129207       *      */
        /*"      *                     - NOVAS REGRAS DE RESSARCIMENTO PARA O     *      */
        /*"      *                       LOTERICO E CCA, NAO HAVERA MAIS ESTORNO  *      */
        /*"      *                                 PROCURAR   V.05                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.04  *   DAIRO LOPES       - 16/02/2016         - CADMUS 130683       *      */
        /*"      *                     - INCLUIR VALIDACAO SINISTRO - SOMAR       *      */
        /*"      *                       APENAS FRANQUIA QUE NAO ESTEJA CANCELADA *      */
        /*"      *                                 PROCURAR   V.04                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.03  * ALTERACAO:  16/12/15   GUILHERME CORREIA                       *      */
        /*"      *             CADMUS 127108 - AJUSTE CALCULO IS     PROCURAR V.3 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.02  * ALTERACAO:  10/06/14   DAIRO LOPES                             *      */
        /*"      *             CADMUS 99028 - CALCULAR IS PARA CCA   PROCURAR V.2 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO:  13/06/08   GILSON PINTO DA SILVA                   *      */
        /*"      *   PROJETO  FGV                                                 *      */
        /*"      *                INIBIR COMANDO DISPLAY  -  PROCURAR GP0608      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  W-HOST-VALOR-AVISADO-OPER-101  PIC S9(13)V99 COMP-3 VALUE +0*/
        public DoubleBasis W_HOST_VALOR_AVISADO_OPER_101 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  W-HOST-VALOR-CALCULADO-99      PIC S9(13)V99 COMP-3 VALUE +0*/
        public DoubleBasis W_HOST_VALOR_CALCULADO_99 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  W-HOST-INDENIZ-SINISTRO        PIC S9(13)V99 COMP-3 VALUE +0*/
        public DoubleBasis W_HOST_INDENIZ_SINISTRO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  W-HOST-VALOR-FRANQUIA          PIC S9(13)V99 COMP-3 VALUE +0*/
        public DoubleBasis W_HOST_VALOR_FRANQUIA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  W-VALOR-BASE-ADIANTA           PIC S9(13)V99 COMP-3 VALUE +0*/
        public DoubleBasis W_VALOR_BASE_ADIANTA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  W-HOST-VALOR-ADIANTA2          PIC S9(13)V99 COMP-3 VALUE +0*/
        public DoubleBasis W_HOST_VALOR_ADIANTA2 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  W-HOST-VALOR-CALCULADO-1       PIC S9(13)V99 COMP-3 VALUE +0*/
        public DoubleBasis W_HOST_VALOR_CALCULADO_1 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  W-HOST-AVISOS                  PIC S9(13)V99 COMP-3 VALUE +0*/
        public DoubleBasis W_HOST_AVISOS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  HOST-ANO-MOV-ABERTO            PIC  X(04)    VALUE  SPACES.*/
        public StringBasis HOST_ANO_MOV_ABERTO { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
        /*"77  WS-VALOR-IS                    PIC S9(13)V99 COMP-3 VALUE +0*/
        public DoubleBasis WS_VALOR_IS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01          AREAS-DE-WORK.*/
        public SI0006S_AREAS_DE_WORK AREAS_DE_WORK { get; set; } = new SI0006S_AREAS_DE_WORK();
        public class SI0006S_AREAS_DE_WORK : VarBasis
        {
            /*"  05 WFIM-SINISTROS-APOLICE      PIC X(03)    VALUE 'NAO'.*/
            public StringBasis WFIM_SINISTROS_APOLICE { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"  05 WABEND.*/
            public SI0006S_WABEND WABEND { get; set; } = new SI0006S_WABEND();
            public class SI0006S_WABEND : VarBasis
            {
                /*"     07 WABEND1.*/
                public SI0006S_WABEND1 WABEND1 { get; set; } = new SI0006S_WABEND1();
                public class SI0006S_WABEND1 : VarBasis
                {
                    /*"        10 FILLER                PIC  X(008) VALUE  'SI0006S'.*/
                    public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"SI0006S");
                    /*"     07 WABEND2.*/
                }
                public SI0006S_WABEND2 WABEND2 { get; set; } = new SI0006S_WABEND2();
                public class SI0006S_WABEND2 : VarBasis
                {
                    /*"        10 FILLER                PIC  X(025) VALUE        '*** ERRO EXEC SQL NUMERO '.*/
                    public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"*** ERRO EXEC SQL NUMERO ");
                    /*"        10 WNR-EXEC-SQL          PIC  X(004) VALUE  '0000'.*/
                    public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                    /*"     07 WABEND3.*/
                }
                public SI0006S_WABEND3 WABEND3 { get; set; } = new SI0006S_WABEND3();
                public class SI0006S_WABEND3 : VarBasis
                {
                    /*"        10 FILLER                PIC  X(013) VALUE        ' *** SQLCODE '.*/
                    public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                    /*"        10 WSQLCODE              PIC  ZZZZZ999-  VALUE  ZEROS.*/
                    public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                    /*"01       WS-DATA-DB2.*/
                }
            }
        }
        public SI0006S_WS_DATA_DB2 WS_DATA_DB2 { get; set; } = new SI0006S_WS_DATA_DB2();
        public class SI0006S_WS_DATA_DB2 : VarBasis
        {
            /*"  05     WS-ANO-DB2       PIC  9(004)          VALUE ZEROS.*/
            public IntBasis WS_ANO_DB2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05     FILLER           PIC  X(001)          VALUE '-'.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"  05     WS-MES-DB2       PIC  9(002)          VALUE ZEROS.*/
            public IntBasis WS_MES_DB2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05     FILLER           PIC  X(001)          VALUE '-'.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"  05     WS-DIA-DB2       PIC  9(002)          VALUE ZEROS.*/
            public IntBasis WS_DIA_DB2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"01          LK2-LINK.*/
        }
        public SI0006S_LK2_LINK LK2_LINK { get; set; } = new SI0006S_LK2_LINK();
        public class SI0006S_LK2_LINK : VarBasis
        {
            /*"  05 LK2-RTCODE                  PIC S9(04) COMP VALUE +0.*/
            public IntBasis LK2_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05 LK2-LOTERI01-NUM-APOLICE    PIC  9(13).*/
            public IntBasis LK2_LOTERI01_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
            /*"  05 LK2-AV-COD-NATUREZA         PIC  X(02).*/
            public StringBasis LK2_AV_COD_NATUREZA { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
            /*"  05 LK2-LOTERI01-COD-LOT-CEF    PIC  9(13).*/
            public IntBasis LK2_LOTERI01_COD_LOT_CEF { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
            /*"  05 LK2-LOTERI01-COD-LOT-FENAL  PIC  9(13).*/
            public IntBasis LK2_LOTERI01_COD_LOT_FENAL { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
            /*"  05 LK2-IMP-SEGURADA-IX         PIC S9(13)V99 COMP-3 VALUE +0.*/
            public DoubleBasis LK2_IMP_SEGURADA_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05 LK2-DATA-INIVIGENCIA        PIC  X(10).*/
            public StringBasis LK2_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"  05 LK2-DATA-TERVIGENCIA        PIC  X(10).*/
            public StringBasis LK2_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"  05 LK2-W-HOST-VALOR-SALDO-IS   PIC S9(13)V99 COMP-3 VALUE +0.*/
            public DoubleBasis LK2_W_HOST_VALOR_SALDO_IS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05 LK2-W-HOST-VAL-AVISOS       PIC S9(13)V99 COMP-3 VALUE +0.*/
            public DoubleBasis LK2_W_HOST_VAL_AVISOS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05 LK2-W-HOST-INDENIZ-EFETIV   PIC S9(13)V99 COMP-3 VALUE +0.*/
            public DoubleBasis LK2_W_HOST_INDENIZ_EFETIV { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        }


        public Dclgens.SIPARADI SIPARADI { get; set; } = new Dclgens.SIPARADI();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.OUTROCOB OUTROCOB { get; set; } = new Dclgens.OUTROCOB();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.SINILT01 SINILT01 { get; set; } = new Dclgens.SINILT01();
        public Dclgens.LOTERI01 LOTERI01 { get; set; } = new Dclgens.LOTERI01();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.LBLT3159 LBLT3159 { get; set; } = new Dclgens.LBLT3159();
        public SI0006S_SINISTRO_APOL SINISTRO_APOL { get; set; } = new SI0006S_SINISTRO_APOL();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(SI0006S_LK2_LINK SI0006S_LK2_LINK_P) //PROCEDURE DIVISION USING 
        /*LK2_LINK*/
        {
            try
            {
                this.LK2_LINK = SI0006S_LK2_LINK_P;

                /*" -0- FLUXCONTROL_PERFORM M-000-00-PRINCIPAL */

                M_000_00_PRINCIPAL();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LK2_LINK, CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" M-000-00-PRINCIPAL */
        private void M_000_00_PRINCIPAL(bool isPerform = false)
        {
            /*" -163- MOVE ZEROS TO W-HOST-AVISOS LK2-W-HOST-VAL-AVISOS LK2-W-HOST-INDENIZ-EFETIV LK2-W-HOST-VALOR-SALDO-IS LK2-RTCODE. */
            _.Move(0, W_HOST_AVISOS, LK2_LINK.LK2_W_HOST_VAL_AVISOS, LK2_LINK.LK2_W_HOST_INDENIZ_EFETIV, LK2_LINK.LK2_W_HOST_VALOR_SALDO_IS, LK2_LINK.LK2_RTCODE);

            /*" -167- PERFORM 100-00-LE-PERCETUAL-ADIANTA THRU 100-99-EXIT. */

            M_100_00_LE_PERCETUAL_ADIANTA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_99_EXIT*/


            /*" -169- PERFORM 200-00-DECLARE-SINISTROS-APOL THRU 200-99-EXIT. */

            M_200_00_DECLARE_SINISTROS_APOL(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_200_99_EXIT*/


            /*" -171- MOVE 'NAO' TO WFIM-SINISTROS-APOLICE. */
            _.Move("NAO", AREAS_DE_WORK.WFIM_SINISTROS_APOLICE);

            /*" -173- PERFORM 210-00-FETCH-SINISTROS-APOL THRU 210-99-EXIT. */

            M_210_00_FETCH_SINISTROS_APOL(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_210_99_EXIT*/


            /*" -182- PERFORM M-230-00-PROCESSA-SINISTROS-APOL THRU 230-99-EXIT UNTIL WFIM-SINISTROS-APOLICE EQUAL 'SIM' . */

            while (!(AREAS_DE_WORK.WFIM_SINISTROS_APOLICE == "SIM"))
            {

                M_230_00_PROCESSA_SINISTROS_APOL(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_230_99_EXIT*/

            }

            /*" -184- PERFORM 150-00-BUSCA-IS THRU 150-99-EXIT. */

            M_150_00_BUSCA_IS_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_150_99_EXIT*/


            /*" -194- COMPUTE LK2-W-HOST-VALOR-SALDO-IS = (OUTROCOB-IMP-SEGURADA-IX * WS-VALOR-IS) - (LK2-W-HOST-VAL-AVISOS + LK2-W-HOST-INDENIZ-EFETIV). */
            LK2_LINK.LK2_W_HOST_VALOR_SALDO_IS.Value = (OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_IMP_SEGURADA_IX * WS_VALOR_IS) - (LK2_LINK.LK2_W_HOST_VAL_AVISOS + LK2_LINK.LK2_W_HOST_INDENIZ_EFETIV);

            /*" -194- GOBACK. */

            throw new GoBack();

        }

        [StopWatch]
        /*" M-100-00-LE-PERCETUAL-ADIANTA */
        private void M_100_00_LE_PERCETUAL_ADIANTA(bool isPerform = false)
        {
            /*" -202- MOVE '001' TO WNR-EXEC-SQL. */
            _.Move("001", AREAS_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL);

            /*" -203- MOVE LK2-LOTERI01-NUM-APOLICE TO APOLICES-NUM-APOLICE. */
            _.Move(LK2_LINK.LK2_LOTERI01_NUM_APOLICE, APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE);

            /*" -205- MOVE LK2-AV-COD-NATUREZA TO SIPARADI-COD-COBERTURA. */
            _.Move(LK2_LINK.LK2_AV_COD_NATUREZA, SIPARADI.DCLSI_PARAM_ADIANT.SIPARADI_COD_COBERTURA);

            /*" -220- PERFORM M_100_00_LE_PERCETUAL_ADIANTA_DB_SELECT_1 */

            M_100_00_LE_PERCETUAL_ADIANTA_DB_SELECT_1();

            /*" -223- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -224- DISPLAY 'ERRO SELECT SI_PARAM_ADIANT ....................' */
                _.Display($"ERRO SELECT SI_PARAM_ADIANT ....................");

                /*" -225- DISPLAY 'LOTERICO ............. ' LK2-LOTERI01-COD-LOT-CEF */
                _.Display($"LOTERICO ............. {LK2_LINK.LK2_LOTERI01_COD_LOT_CEF}");

                /*" -226- DISPLAY 'COBERTURA ............ ' SIPARADI-COD-COBERTURA */
                _.Display($"COBERTURA ............ {SIPARADI.DCLSI_PARAM_ADIANT.SIPARADI_COD_COBERTURA}");

                /*" -226- GO TO 999-00-ROT-ERRO. */

                M_999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-100-00-LE-PERCETUAL-ADIANTA-DB-SELECT-1 */
        public void M_100_00_LE_PERCETUAL_ADIANTA_DB_SELECT_1()
        {
            /*" -220- EXEC SQL SELECT P.COD_PRODUTO, P.COD_COBERTURA, P.PERC_ADIANTAMENTO INTO :SIPARADI-COD-PRODUTO, :SIPARADI-COD-COBERTURA, :SIPARADI-PERC-ADIANTAMENTO FROM SEGUROS.SI_PARAM_ADIANT P, SEGUROS.APOLICES A WHERE A.NUM_APOLICE = :APOLICES-NUM-APOLICE AND P.COD_PRODUTO = A.COD_PRODUTO AND P.COD_COBERTURA = :SIPARADI-COD-COBERTURA AND P.DATA_INIVIGENCIA <= CURRENT DATE AND P.DATA_TERVIGENCIA >= CURRENT DATE WITH UR END-EXEC. */

            var m_100_00_LE_PERCETUAL_ADIANTA_DB_SELECT_1_Query1 = new M_100_00_LE_PERCETUAL_ADIANTA_DB_SELECT_1_Query1()
            {
                SIPARADI_COD_COBERTURA = SIPARADI.DCLSI_PARAM_ADIANT.SIPARADI_COD_COBERTURA.ToString(),
                APOLICES_NUM_APOLICE = APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE.ToString(),
            };

            var executed_1 = M_100_00_LE_PERCETUAL_ADIANTA_DB_SELECT_1_Query1.Execute(m_100_00_LE_PERCETUAL_ADIANTA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SIPARADI_COD_PRODUTO, SIPARADI.DCLSI_PARAM_ADIANT.SIPARADI_COD_PRODUTO);
                _.Move(executed_1.SIPARADI_COD_COBERTURA, SIPARADI.DCLSI_PARAM_ADIANT.SIPARADI_COD_COBERTURA);
                _.Move(executed_1.SIPARADI_PERC_ADIANTAMENTO, SIPARADI.DCLSI_PARAM_ADIANT.SIPARADI_PERC_ADIANTAMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_99_EXIT*/

        [StopWatch]
        /*" M-150-00-BUSCA-IS-SECTION */
        private void M_150_00_BUSCA_IS_SECTION()
        {
            /*" -262- MOVE '04' TO LT3159S-OPERACAO */
            _.Move("04", LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_OPERACAO);

            /*" -264- MOVE ZEROS TO LT3159S-PARAM */
            _.Move(0, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_PARAM);

            /*" -265- MOVE 0 TO LT3159S-VALOR */
            _.Move(0, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_VALOR);

            /*" -269- MOVE SPACES TO LT3159S-NOME */
            _.Move("", LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_NOME);

            /*" -270- IF SIPARADI-COD-PRODUTO EQUAL 1805 */

            if (SIPARADI.DCLSI_PARAM_ADIANT.SIPARADI_COD_PRODUTO == 1805)
            {

                /*" -271- MOVE 1805 TO LT3159S-COD-PRODUTO */
                _.Move(1805, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_COD_PRODUTO);

                /*" -272- ELSE */
            }
            else
            {


                /*" -273- MOVE 1803 TO LT3159S-COD-PRODUTO */
                _.Move(1803, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_COD_PRODUTO);

                /*" -275- END-IF */
            }


            /*" -277- MOVE LK2-DATA-INIVIGENCIA TO LT3159S-DATA-INIVIGENCIA */
            _.Move(LK2_LINK.LK2_DATA_INIVIGENCIA, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_DATA_INIVIGENCIA);

            /*" -279- CALL 'LT3159S' USING LT3159S-AREA-PARAMETROS. */
            _.Call("LT3159S", LBLT3159.LT3159S_AREA_PARAMETROS);

            /*" -280- IF LT3159S-COD-RETORNO > 0 */

            if (LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_COD_RETORNO > 0)
            {

                /*" -281- DISPLAY ' COD RETORNO   =' LT3159S-COD-RETORNO */
                _.Display($" COD RETORNO   ={LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_COD_RETORNO}");

                /*" -283- GO TO 999-00-ROT-ERRO. */

                M_999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -285- MOVE LT3159S-TB-VALOR(72) TO WS-VALOR-IS */
            _.Move(LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_TABELA_SAIDA.LT3159S_TAB_SAIDA[72].LT3159S_TB_VALOR, WS_VALOR_IS);

            /*" -285- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_150_99_EXIT*/

        [StopWatch]
        /*" M-200-00-DECLARE-SINISTROS-APOL */
        private void M_200_00_DECLARE_SINISTROS_APOL(bool isPerform = false)
        {
            /*" -295- MOVE '002' TO WNR-EXEC-SQL. */
            _.Move("002", AREAS_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL);

            /*" -296- MOVE LK2-LOTERI01-NUM-APOLICE TO LOTERI01-NUM-APOLICE. */
            _.Move(LK2_LINK.LK2_LOTERI01_NUM_APOLICE, LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE);

            /*" -297- MOVE LK2-LOTERI01-COD-LOT-CEF TO LOTERI01-COD-LOT-CEF. */
            _.Move(LK2_LINK.LK2_LOTERI01_COD_LOT_CEF, LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_CEF);

            /*" -298- MOVE LK2-LOTERI01-COD-LOT-FENAL TO LOTERI01-COD-LOT-FENAL. */
            _.Move(LK2_LINK.LK2_LOTERI01_COD_LOT_FENAL, LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_FENAL);

            /*" -299- MOVE LK2-AV-COD-NATUREZA TO OUTROCOB-COD-COBERTURA. */
            _.Move(LK2_LINK.LK2_AV_COD_NATUREZA, OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_COD_COBERTURA);

            /*" -300- MOVE LK2-IMP-SEGURADA-IX TO OUTROCOB-IMP-SEGURADA-IX. */
            _.Move(LK2_LINK.LK2_IMP_SEGURADA_IX, OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_IMP_SEGURADA_IX);

            /*" -301- MOVE LK2-DATA-INIVIGENCIA TO OUTROCOB-DATA-INIVIGENCIA. */
            _.Move(LK2_LINK.LK2_DATA_INIVIGENCIA, OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_DATA_INIVIGENCIA);

            /*" -303- MOVE LK2-DATA-TERVIGENCIA TO OUTROCOB-DATA-TERVIGENCIA. */
            _.Move(LK2_LINK.LK2_DATA_TERVIGENCIA, OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_DATA_TERVIGENCIA);

            /*" -320- PERFORM M_200_00_DECLARE_SINISTROS_APOL_DB_DECLARE_1 */

            M_200_00_DECLARE_SINISTROS_APOL_DB_DECLARE_1();

            /*" -322- PERFORM M_200_00_DECLARE_SINISTROS_APOL_DB_OPEN_1 */

            M_200_00_DECLARE_SINISTROS_APOL_DB_OPEN_1();

            /*" -325- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -327- DISPLAY 'LOTERICO ...................... ' LK2-LOTERI01-COD-LOT-CEF */
                _.Display($"LOTERICO ...................... {LK2_LINK.LK2_LOTERI01_COD_LOT_CEF}");

                /*" -329- DISPLAY 'LOTERI01-NUM-APOLICE .......... ' LOTERI01-NUM-APOLICE */
                _.Display($"LOTERI01-NUM-APOLICE .......... {LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE}");

                /*" -331- DISPLAY 'OUTROCOB-COD-COBERTURA ........ ' OUTROCOB-COD-COBERTURA */
                _.Display($"OUTROCOB-COD-COBERTURA ........ {OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_COD_COBERTURA}");

                /*" -333- DISPLAY 'OUTROCOB-DATA-INIVIGENCIA ..... ' OUTROCOB-DATA-INIVIGENCIA */
                _.Display($"OUTROCOB-DATA-INIVIGENCIA ..... {OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_DATA_INIVIGENCIA}");

                /*" -335- DISPLAY 'OUTROCOB-DATA-TERVIGENCIA ..... ' OUTROCOB-DATA-TERVIGENCIA */
                _.Display($"OUTROCOB-DATA-TERVIGENCIA ..... {OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_DATA_TERVIGENCIA}");

                /*" -335- GO TO 999-00-ROT-ERRO. */

                M_999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-200-00-DECLARE-SINISTROS-APOL-DB-DECLARE-1 */
        public void M_200_00_DECLARE_SINISTROS_APOL_DB_DECLARE_1()
        {
            /*" -320- EXEC SQL DECLARE SINISTRO_APOL CURSOR FOR SELECT H.NUM_APOL_SINISTRO, H.VAL_OPERACAO FROM SEGUROS.SINISTRO_HISTORICO H, SEGUROS.SINISTRO_MESTRE M, SEGUROS.SINI_LOTERICO01 SL WHERE SL.NUM_APOLICE = :LOTERI01-NUM-APOLICE AND SL.COD_COBERTURA = :OUTROCOB-COD-COBERTURA AND M.NUM_APOL_SINISTRO = SL.NUM_APOL_SINISTRO AND H.NUM_APOL_SINISTRO = SL.NUM_APOL_SINISTRO AND H.COD_OPERACAO = 101 AND M.SIT_REGISTRO <> '2' ORDER BY H.NUM_APOL_SINISTRO WITH UR END-EXEC. */
            SINISTRO_APOL = new SI0006S_SINISTRO_APOL(true);
            string GetQuery_SINISTRO_APOL()
            {
                var query = @$"SELECT H.NUM_APOL_SINISTRO
							, 
							H.VAL_OPERACAO 
							FROM SEGUROS.SINISTRO_HISTORICO H
							, 
							SEGUROS.SINISTRO_MESTRE M
							, 
							SEGUROS.SINI_LOTERICO01 SL 
							WHERE SL.NUM_APOLICE = '{LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE}' 
							AND SL.COD_COBERTURA = '{OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_COD_COBERTURA}' 
							AND M.NUM_APOL_SINISTRO = SL.NUM_APOL_SINISTRO 
							AND H.NUM_APOL_SINISTRO = SL.NUM_APOL_SINISTRO 
							AND H.COD_OPERACAO = 101 
							AND M.SIT_REGISTRO <> '2' 
							ORDER BY H.NUM_APOL_SINISTRO";

                return query;
            }
            SINISTRO_APOL.GetQueryEvent += GetQuery_SINISTRO_APOL;

        }

        [StopWatch]
        /*" M-200-00-DECLARE-SINISTROS-APOL-DB-OPEN-1 */
        public void M_200_00_DECLARE_SINISTROS_APOL_DB_OPEN_1()
        {
            /*" -322- EXEC SQL OPEN SINISTRO_APOL END-EXEC. */

            SINISTRO_APOL.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_200_99_EXIT*/

        [StopWatch]
        /*" M-210-00-FETCH-SINISTROS-APOL */
        private void M_210_00_FETCH_SINISTROS_APOL(bool isPerform = false)
        {
            /*" -346- MOVE '003' TO WNR-EXEC-SQL. */
            _.Move("003", AREAS_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL);

            /*" -349- PERFORM M_210_00_FETCH_SINISTROS_APOL_DB_FETCH_1 */

            M_210_00_FETCH_SINISTROS_APOL_DB_FETCH_1();

            /*" -357- IF (SQLCODE NOT EQUAL ZEROS) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -359- DISPLAY 'LOTERICO ...................... ' LK2-LOTERI01-COD-LOT-CEF */
                _.Display($"LOTERICO ...................... {LK2_LINK.LK2_LOTERI01_COD_LOT_CEF}");

                /*" -361- DISPLAY 'LOTERI01-NUM-APOLICE .......... ' LOTERI01-NUM-APOLICE */
                _.Display($"LOTERI01-NUM-APOLICE .......... {LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE}");

                /*" -363- DISPLAY 'OUTROCOB-COD-COBERTURA ........ ' OUTROCOB-COD-COBERTURA */
                _.Display($"OUTROCOB-COD-COBERTURA ........ {OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_COD_COBERTURA}");

                /*" -365- DISPLAY 'OUTROCOB-DATA-INIVIGENCIA ..... ' OUTROCOB-DATA-INIVIGENCIA */
                _.Display($"OUTROCOB-DATA-INIVIGENCIA ..... {OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_DATA_INIVIGENCIA}");

                /*" -367- DISPLAY 'OUTROCOB-DATA-TERVIGENCIA ..... ' OUTROCOB-DATA-TERVIGENCIA */
                _.Display($"OUTROCOB-DATA-TERVIGENCIA ..... {OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_DATA_TERVIGENCIA}");

                /*" -369- GO TO 999-00-ROT-ERRO. */

                M_999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -371- MOVE '004' TO WNR-EXEC-SQL. */
            _.Move("004", AREAS_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL);

            /*" -372- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -373- MOVE 'SIM' TO WFIM-SINISTROS-APOLICE */
                _.Move("SIM", AREAS_DE_WORK.WFIM_SINISTROS_APOLICE);

                /*" -373- PERFORM M_210_00_FETCH_SINISTROS_APOL_DB_CLOSE_1 */

                M_210_00_FETCH_SINISTROS_APOL_DB_CLOSE_1();

                /*" -375- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -377- DISPLAY 'LOTERICO ...................... ' LK2-LOTERI01-COD-LOT-CEF */
                    _.Display($"LOTERICO ...................... {LK2_LINK.LK2_LOTERI01_COD_LOT_CEF}");

                    /*" -379- DISPLAY 'LOTERI01-NUM-APOLICE .......... ' LOTERI01-NUM-APOLICE */
                    _.Display($"LOTERI01-NUM-APOLICE .......... {LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE}");

                    /*" -381- DISPLAY 'OUTROCOB-COD-COBERTURA ........ ' OUTROCOB-COD-COBERTURA */
                    _.Display($"OUTROCOB-COD-COBERTURA ........ {OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_COD_COBERTURA}");

                    /*" -383- DISPLAY 'OUTROCOB-DATA-INIVIGENCIA ..... ' OUTROCOB-DATA-INIVIGENCIA */
                    _.Display($"OUTROCOB-DATA-INIVIGENCIA ..... {OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_DATA_INIVIGENCIA}");

                    /*" -385- DISPLAY 'OUTROCOB-DATA-TERVIGENCIA ..... ' OUTROCOB-DATA-TERVIGENCIA */
                    _.Display($"OUTROCOB-DATA-TERVIGENCIA ..... {OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_DATA_TERVIGENCIA}");

                    /*" -385- GO TO 999-00-ROT-ERRO. */

                    M_999_00_ROT_ERRO(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-210-00-FETCH-SINISTROS-APOL-DB-FETCH-1 */
        public void M_210_00_FETCH_SINISTROS_APOL_DB_FETCH_1()
        {
            /*" -349- EXEC SQL FETCH SINISTRO_APOL INTO :SINISHIS-NUM-APOL-SINISTRO, :W-HOST-VALOR-AVISADO-OPER-101 END-EXEC. */

            if (SINISTRO_APOL.Fetch())
            {
                _.Move(SINISTRO_APOL.SINISHIS_NUM_APOL_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO);
                _.Move(SINISTRO_APOL.W_HOST_VALOR_AVISADO_OPER_101, W_HOST_VALOR_AVISADO_OPER_101);
            }

        }

        [StopWatch]
        /*" M-210-00-FETCH-SINISTROS-APOL-DB-CLOSE-1 */
        public void M_210_00_FETCH_SINISTROS_APOL_DB_CLOSE_1()
        {
            /*" -373- EXEC SQL CLOSE SINISTRO_APOL END-EXEC */

            SINISTRO_APOL.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_210_99_EXIT*/

        [StopWatch]
        /*" M-220-00-BUSCA-ADIANTAMENTOS */
        private void M_220_00_BUSCA_ADIANTAMENTOS(bool isPerform = false)
        {
            /*" -396- MOVE '005' TO WNR-EXEC-SQL. */
            _.Move("005", AREAS_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL);

            /*" -398- MOVE ZEROS TO W-HOST-VALOR-ADIANTA2. */
            _.Move(0, W_HOST_VALOR_ADIANTA2);

            /*" -405- PERFORM M_220_00_BUSCA_ADIANTAMENTOS_DB_SELECT_1 */

            M_220_00_BUSCA_ADIANTAMENTOS_DB_SELECT_1();

            /*" -408- IF (SQLCODE NOT EQUAL 100) AND (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 100) && (DB.SQLCODE != 00))
            {

                /*" -409- DISPLAY 'BUSCA-ADIANTAMENTOS' */
                _.Display($"BUSCA-ADIANTAMENTOS");

                /*" -410- DISPLAY 'LOTERICO ........... ' LK2-LOTERI01-COD-LOT-CEF */
                _.Display($"LOTERICO ........... {LK2_LINK.LK2_LOTERI01_COD_LOT_CEF}");

                /*" -411- DISPLAY 'LOTERI01-NUM-APOLICE ' LOTERI01-NUM-APOLICE */
                _.Display($"LOTERI01-NUM-APOLICE {LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE}");

                /*" -413- DISPLAY 'OUTROCOB-DATA-INIVIGENCIA ....... ' OUTROCOB-DATA-INIVIGENCIA */
                _.Display($"OUTROCOB-DATA-INIVIGENCIA ....... {OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_DATA_INIVIGENCIA}");

                /*" -415- DISPLAY 'OUTROCOB-DATA-TERVIGENCIA ....... ' OUTROCOB-DATA-TERVIGENCIA */
                _.Display($"OUTROCOB-DATA-TERVIGENCIA ....... {OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_DATA_TERVIGENCIA}");

                /*" -416- DISPLAY 'SINISTRO ........ ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO ........ {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -416- GO TO 999-00-ROT-ERRO. */

                M_999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-220-00-BUSCA-ADIANTAMENTOS-DB-SELECT-1 */
        public void M_220_00_BUSCA_ADIANTAMENTOS_DB_SELECT_1()
        {
            /*" -405- EXEC SQL SELECT VALUE(SUM(H.VAL_OPERACAO),0) INTO :W-HOST-VALOR-ADIANTA2 FROM SEGUROS.SINISTRO_HISTORICO H WHERE H.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND H.COD_OPERACAO = 1070 WITH UR END-EXEC. */

            var m_220_00_BUSCA_ADIANTAMENTOS_DB_SELECT_1_Query1 = new M_220_00_BUSCA_ADIANTAMENTOS_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = M_220_00_BUSCA_ADIANTAMENTOS_DB_SELECT_1_Query1.Execute(m_220_00_BUSCA_ADIANTAMENTOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.W_HOST_VALOR_ADIANTA2, W_HOST_VALOR_ADIANTA2);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_220_99_EXIT*/

        [StopWatch]
        /*" M-230-00-PROCESSA-SINISTROS-APOL */
        private void M_230_00_PROCESSA_SINISTROS_APOL(bool isPerform = false)
        {
            /*" -431- MOVE ZEROS TO W-HOST-VALOR-CALCULADO-1 W-HOST-VALOR-CALCULADO-99 W-HOST-VALOR-FRANQUIA. */
            _.Move(0, W_HOST_VALOR_CALCULADO_1, W_HOST_VALOR_CALCULADO_99, W_HOST_VALOR_FRANQUIA);

            /*" -433- PERFORM 231-00-INDENIZ-EFETIVADAS THRU 231-99-EXIT. */

            M_231_00_INDENIZ_EFETIVADAS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_231_99_EXIT*/


            /*" -434- IF W-HOST-VALOR-CALCULADO-1 > 0 */

            if (W_HOST_VALOR_CALCULADO_1 > 0)
            {

                /*" -438- PERFORM 232-00-BUSCA-FRANQUIA THRU 232-99-EXIT. */

                M_232_00_BUSCA_FRANQUIA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_232_99_EXIT*/

            }


            /*" -440- PERFORM 233-00-EST-INDENIZ-EFETIVADAS THRU 233-99-EXIT. */

            M_233_00_EST_INDENIZ_EFETIVADAS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_233_99_EXIT*/


            /*" -445- COMPUTE W-HOST-INDENIZ-SINISTRO = W-HOST-VALOR-CALCULADO-1 + W-HOST-VALOR-FRANQUIA - W-HOST-VALOR-CALCULADO-99. */
            W_HOST_INDENIZ_SINISTRO.Value = W_HOST_VALOR_CALCULADO_1 + W_HOST_VALOR_FRANQUIA - W_HOST_VALOR_CALCULADO_99;

            /*" -451- DISPLAY 'SI0006-W-HOST-VALOR-CALCULADO-1 ' W-HOST-VALOR-CALCULADO-1 ' W-HOST-VALOR-FRANQUIA ' W-HOST-VALOR-FRANQUIA ' W-HOST-VALOR-CALCULADO-99 ' W-HOST-VALOR-CALCULADO-99 */

            $"SI0006-W-HOST-VALOR-CALCULADO-1 {W_HOST_VALOR_CALCULADO_1} W-HOST-VALOR-FRANQUIA {W_HOST_VALOR_FRANQUIA} W-HOST-VALOR-CALCULADO-99 {W_HOST_VALOR_CALCULADO_99}"
            .Display();

            /*" -455- COMPUTE LK2-W-HOST-INDENIZ-EFETIV = LK2-W-HOST-INDENIZ-EFETIV + W-HOST-INDENIZ-SINISTRO. */
            LK2_LINK.LK2_W_HOST_INDENIZ_EFETIV.Value = LK2_LINK.LK2_W_HOST_INDENIZ_EFETIV + W_HOST_INDENIZ_SINISTRO;

            /*" -460- DISPLAY 'SI0006-LK2-W-HOST-INDENIZ-EFETIV ' LK2-W-HOST-INDENIZ-EFETIV */
            _.Display($"SI0006-LK2-W-HOST-INDENIZ-EFETIV {LK2_LINK.LK2_W_HOST_INDENIZ_EFETIV}");

            /*" -461- IF W-HOST-INDENIZ-SINISTRO > 0 */

            if (W_HOST_INDENIZ_SINISTRO > 0)
            {

                /*" -462- PERFORM 240-00-LE-NOVO-SINISTRO THRU 240-99-EXIT */

                M_240_00_LE_NOVO_SINISTRO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_240_99_EXIT*/


                /*" -466- GO TO 230-99-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_230_99_EXIT*/ //GOTO
                return;
            }


            /*" -472- PERFORM 220-00-BUSCA-ADIANTAMENTOS THRU 220-99-EXIT. */

            M_220_00_BUSCA_ADIANTAMENTOS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_220_99_EXIT*/


            /*" -473- IF SIPARADI-PERC-ADIANTAMENTO EQUAL ZEROS */

            if (SIPARADI.DCLSI_PARAM_ADIANT.SIPARADI_PERC_ADIANTAMENTO == 00)
            {

                /*" -474- MOVE 1 TO SIPARADI-PERC-ADIANTAMENTO */
                _.Move(1, SIPARADI.DCLSI_PARAM_ADIANT.SIPARADI_PERC_ADIANTAMENTO);

                /*" -476- END-IF */
            }


            /*" -480- COMPUTE W-VALOR-BASE-ADIANTA ROUNDED = W-HOST-VALOR-ADIANTA2 * 100 / SIPARADI-PERC-ADIANTAMENTO. */
            W_VALOR_BASE_ADIANTA.Value = W_HOST_VALOR_ADIANTA2 * 100 / SIPARADI.DCLSI_PARAM_ADIANT.SIPARADI_PERC_ADIANTAMENTO;

            /*" -486- MOVE W-HOST-VALOR-AVISADO-OPER-101 TO W-VALOR-BASE-ADIANTA. */
            _.Move(W_HOST_VALOR_AVISADO_OPER_101, W_VALOR_BASE_ADIANTA);

            /*" -489- COMPUTE LK2-W-HOST-VAL-AVISOS = LK2-W-HOST-VAL-AVISOS + W-VALOR-BASE-ADIANTA. */
            LK2_LINK.LK2_W_HOST_VAL_AVISOS.Value = LK2_LINK.LK2_W_HOST_VAL_AVISOS + W_VALOR_BASE_ADIANTA;

            /*" -492- DISPLAY 'SI0006-W-VALOR-BASE-ADIANTA ' W-VALOR-BASE-ADIANTA ' LK2-W-HOST-VAL-AVISOS ' LK2-W-HOST-VAL-AVISOS */

            $"SI0006-W-VALOR-BASE-ADIANTA {W_VALOR_BASE_ADIANTA} LK2-W-HOST-VAL-AVISOS {LK2_LINK.LK2_W_HOST_VAL_AVISOS}"
            .Display();

            /*" -492- PERFORM 240-00-LE-NOVO-SINISTRO THRU 240-99-EXIT. */

            M_240_00_LE_NOVO_SINISTRO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_240_99_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_230_99_EXIT*/

        [StopWatch]
        /*" M-240-00-LE-NOVO-SINISTRO */
        private void M_240_00_LE_NOVO_SINISTRO(bool isPerform = false)
        {
            /*" -501- PERFORM 210-00-FETCH-SINISTROS-APOL THRU 210-99-EXIT. */

            M_210_00_FETCH_SINISTROS_APOL(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_210_99_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_240_99_EXIT*/

        [StopWatch]
        /*" M-231-00-INDENIZ-EFETIVADAS */
        private void M_231_00_INDENIZ_EFETIVADAS(bool isPerform = false)
        {
            /*" -512- MOVE '006' TO WNR-EXEC-SQL. */
            _.Move("006", AREAS_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL);

            /*" -520- MOVE ZEROS TO W-HOST-VALOR-CALCULADO-1. */
            _.Move(0, W_HOST_VALOR_CALCULADO_1);

            /*" -527- PERFORM M_231_00_INDENIZ_EFETIVADAS_DB_SELECT_1 */

            M_231_00_INDENIZ_EFETIVADAS_DB_SELECT_1();

            /*" -530- IF (SQLCODE NOT EQUAL 100) AND (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 100) && (DB.SQLCODE != 00))
            {

                /*" -531- DISPLAY '231-00-INDENIZ-EFETIVADAS' */
                _.Display($"231-00-INDENIZ-EFETIVADAS");

                /*" -532- DISPLAY 'LOTERICO ........... ' LK2-LOTERI01-COD-LOT-CEF */
                _.Display($"LOTERICO ........... {LK2_LINK.LK2_LOTERI01_COD_LOT_CEF}");

                /*" -533- DISPLAY 'LOTERI01-NUM-APOLICE  ' LOTERI01-NUM-APOLICE */
                _.Display($"LOTERI01-NUM-APOLICE  {LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE}");

                /*" -535- DISPLAY 'OUTROCOB-DATA-INIVIGENCIA ........ ' OUTROCOB-DATA-INIVIGENCIA */
                _.Display($"OUTROCOB-DATA-INIVIGENCIA ........ {OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_DATA_INIVIGENCIA}");

                /*" -537- DISPLAY 'OUTROCOB-DATA-TERVIGENCIA ........ ' OUTROCOB-DATA-TERVIGENCIA */
                _.Display($"OUTROCOB-DATA-TERVIGENCIA ........ {OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_DATA_TERVIGENCIA}");

                /*" -538- DISPLAY 'SINISTRO ........ ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO ........ {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -538- GO TO 999-00-ROT-ERRO. */

                M_999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-231-00-INDENIZ-EFETIVADAS-DB-SELECT-1 */
        public void M_231_00_INDENIZ_EFETIVADAS_DB_SELECT_1()
        {
            /*" -527- EXEC SQL SELECT VALUE(SUM(H.VAL_OPERACAO),0) INTO :W-HOST-VALOR-CALCULADO-1 FROM SEGUROS.SINISTRO_HISTORICO H WHERE H.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND H.COD_OPERACAO IN (1003 , 1004, 1001) WITH UR END-EXEC. */

            var m_231_00_INDENIZ_EFETIVADAS_DB_SELECT_1_Query1 = new M_231_00_INDENIZ_EFETIVADAS_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = M_231_00_INDENIZ_EFETIVADAS_DB_SELECT_1_Query1.Execute(m_231_00_INDENIZ_EFETIVADAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.W_HOST_VALOR_CALCULADO_1, W_HOST_VALOR_CALCULADO_1);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_231_99_EXIT*/

        [StopWatch]
        /*" M-232-00-BUSCA-FRANQUIA */
        private void M_232_00_BUSCA_FRANQUIA(bool isPerform = false)
        {
            /*" -562- PERFORM M_232_00_BUSCA_FRANQUIA_DB_SELECT_1 */

            M_232_00_BUSCA_FRANQUIA_DB_SELECT_1();

            /*" -565- IF (SQLCODE NOT EQUAL 100) AND (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 100) && (DB.SQLCODE != 00))
            {

                /*" -566- DISPLAY '232-00-INDENIZ-EFETIVADAS' */
                _.Display($"232-00-INDENIZ-EFETIVADAS");

                /*" -567- DISPLAY 'LOTERICO ........... ' LK2-LOTERI01-COD-LOT-CEF */
                _.Display($"LOTERICO ........... {LK2_LINK.LK2_LOTERI01_COD_LOT_CEF}");

                /*" -568- DISPLAY 'LOTERI01-NUM-APOLICE  ' LOTERI01-NUM-APOLICE */
                _.Display($"LOTERI01-NUM-APOLICE  {LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE}");

                /*" -570- DISPLAY 'OUTROCOB-DATA-INIVIGENCIA ........ ' OUTROCOB-DATA-INIVIGENCIA */
                _.Display($"OUTROCOB-DATA-INIVIGENCIA ........ {OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_DATA_INIVIGENCIA}");

                /*" -572- DISPLAY 'OUTROCOB-DATA-TERVIGENCIA ........ ' OUTROCOB-DATA-TERVIGENCIA */
                _.Display($"OUTROCOB-DATA-TERVIGENCIA ........ {OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_DATA_TERVIGENCIA}");

                /*" -573- DISPLAY 'SINISTRO ........ ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO ........ {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -573- GO TO 999-00-ROT-ERRO. */

                M_999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-232-00-BUSCA-FRANQUIA-DB-SELECT-1 */
        public void M_232_00_BUSCA_FRANQUIA_DB_SELECT_1()
        {
            /*" -562- EXEC SQL SELECT VALUE(SUM(H.VAL_OPERACAO),0) INTO :W-HOST-VALOR-FRANQUIA FROM SEGUROS.SINISTRO_HISTORICO H WHERE H.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND H.COD_OPERACAO = 21 AND NOT EXISTS ( SELECT C.NUM_APOL_SINISTRO FROM SEGUROS.SINISTRO_HISTORICO C WHERE C.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND C.OCORR_HISTORICO = H.OCORR_HISTORICO AND C.COD_OPERACAO IN (1093,1193) ) WITH UR END-EXEC. */

            var m_232_00_BUSCA_FRANQUIA_DB_SELECT_1_Query1 = new M_232_00_BUSCA_FRANQUIA_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = M_232_00_BUSCA_FRANQUIA_DB_SELECT_1_Query1.Execute(m_232_00_BUSCA_FRANQUIA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.W_HOST_VALOR_FRANQUIA, W_HOST_VALOR_FRANQUIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_232_99_EXIT*/

        [StopWatch]
        /*" M-233-00-EST-INDENIZ-EFETIVADAS */
        private void M_233_00_EST_INDENIZ_EFETIVADAS(bool isPerform = false)
        {
            /*" -584- MOVE '007' TO WNR-EXEC-SQL. */
            _.Move("007", AREAS_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL);

            /*" -591- MOVE ZEROS TO W-HOST-VALOR-CALCULADO-99. */
            _.Move(0, W_HOST_VALOR_CALCULADO_99);

            /*" -606- PERFORM M_233_00_EST_INDENIZ_EFETIVADAS_DB_SELECT_1 */

            M_233_00_EST_INDENIZ_EFETIVADAS_DB_SELECT_1();

            /*" -609- IF (SQLCODE NOT EQUAL 100) AND (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 100) && (DB.SQLCODE != 00))
            {

                /*" -610- DISPLAY '233-00-EST-INDENIZ-EFETIVADAS' */
                _.Display($"233-00-EST-INDENIZ-EFETIVADAS");

                /*" -611- DISPLAY 'LOTERICO ........... ' LK2-LOTERI01-COD-LOT-CEF */
                _.Display($"LOTERICO ........... {LK2_LINK.LK2_LOTERI01_COD_LOT_CEF}");

                /*" -612- DISPLAY 'LOTERI01-NUM-APOLICE  ' LOTERI01-NUM-APOLICE */
                _.Display($"LOTERI01-NUM-APOLICE  {LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE}");

                /*" -614- DISPLAY 'OUTROCOB-DATA-INIVIGENCIA ........ ' OUTROCOB-DATA-INIVIGENCIA */
                _.Display($"OUTROCOB-DATA-INIVIGENCIA ........ {OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_DATA_INIVIGENCIA}");

                /*" -616- DISPLAY 'OUTROCOB-DATA-TERVIGENCIA ........ ' OUTROCOB-DATA-TERVIGENCIA */
                _.Display($"OUTROCOB-DATA-TERVIGENCIA ........ {OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_DATA_TERVIGENCIA}");

                /*" -617- DISPLAY 'SINISTRO ........ ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO ........ {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -617- GO TO 999-00-ROT-ERRO. */

                M_999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-233-00-EST-INDENIZ-EFETIVADAS-DB-SELECT-1 */
        public void M_233_00_EST_INDENIZ_EFETIVADAS_DB_SELECT_1()
        {
            /*" -606- EXEC SQL SELECT VALUE(SUM(H.VAL_OPERACAO),0) INTO :W-HOST-VALOR-CALCULADO-99 FROM SEGUROS.SINISTRO_HISTORICO H WHERE H.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND H.COD_OPERACAO IN (1050, 4001, 4000) AND H.OCORR_HISTORICO IN ( SELECT DISTINCT H1.OCORR_HISTORICO FROM SEGUROS.SINISTRO_HISTORICO H1 WHERE H1.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND H1.COD_OPERACAO IN (1003 , 1004, 1001) ) WITH UR END-EXEC. */

            var m_233_00_EST_INDENIZ_EFETIVADAS_DB_SELECT_1_Query1 = new M_233_00_EST_INDENIZ_EFETIVADAS_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = M_233_00_EST_INDENIZ_EFETIVADAS_DB_SELECT_1_Query1.Execute(m_233_00_EST_INDENIZ_EFETIVADAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.W_HOST_VALOR_CALCULADO_99, W_HOST_VALOR_CALCULADO_99);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_233_99_EXIT*/

        [StopWatch]
        /*" M-999-00-ROT-ERRO */
        private void M_999_00_ROT_ERRO(bool isPerform = false)
        {
            /*" -628- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREAS_DE_WORK.WABEND.WABEND3.WSQLCODE);

            /*" -629- DISPLAY ' ' */
            _.Display($" ");

            /*" -630- DISPLAY '=====  SUBROTINA ABENDADA  =====' */
            _.Display($"=====  SUBROTINA ABENDADA  =====");

            /*" -631- DISPLAY ' ' */
            _.Display($" ");

            /*" -632- DISPLAY WABEND1. */
            _.Display(AREAS_DE_WORK.WABEND.WABEND1);

            /*" -633- DISPLAY WABEND2. */
            _.Display(AREAS_DE_WORK.WABEND.WABEND2);

            /*" -635- DISPLAY WABEND3. */
            _.Display(AREAS_DE_WORK.WABEND.WABEND3);

            /*" -635- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -637- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -640- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -642- MOVE 99 TO LK2-RTCODE. */
            _.Move(99, LK2_LINK.LK2_RTCODE);

            /*" -642- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_999_99_EXIT*/
    }
}