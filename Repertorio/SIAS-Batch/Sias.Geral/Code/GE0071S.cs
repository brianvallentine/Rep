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
using Sias.Geral.DB2.GE0071S;

namespace Code
{
    public class GE0071S
    {
        public bool IsCall { get; set; }

        public GE0071S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      * SISTEMA.........: SIAS                                         *      */
        /*"      * MODULO..........: VIDA                                         *      */
        /*"      * PROGRAMA........: GE0071                                      *       */
        /*"      * ANALISTA........: HUSNI ALI HUSNI                              *      */
        /*"      * DATA............: 17/04/2024                                   *      */
        /*"      * DEMANDA.........: 999999     TAREFA..........: 999999          *      */
        /*"      ******************************************************************      */
        /*"      * OBJETIVO........: TRATAR PARAMETRIZACAO DE COBERTURAS PARA     *      */
        /*"      *                   UM PRODUTO/VERSAO                            *      */
        /*"      *                   - SEGUROS.GE_PRODUTO_PREMIO                  *      */
        /*"      *            ACOES:                                             *       */
        /*"      *              (01) PESQUISAR COBERTURAS PARAMETRIZADAS PARA     *      */
        /*"      *                   O PRODUTO/VERSAO/OPCAOCOBERTURA/IDADE/       *      */
        /*"      *                   INDCONJUGE                                   *      */
        /*"      ******************************************************************      */
        /*"      * VERSAO     DATA     RESPONSAVEL      ALTERACAO                 *      */
        /*"      ******************************************************************      */
        /*"      * V001    17/04/2024  HUSNI ALI HUSNI  CRIACAO DO PROGGRAMA      *      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"01    WORK.*/
        public GE0071S_WORK WORK { get; set; } = new GE0071S_WORK();
        public class GE0071S_WORK : VarBasis
        {
            /*" 05   WS-PROGRAMA                    PIC  X(008) VALUE SPACES.*/
            public StringBasis WS_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*" 05   WS-CONTADORES.*/
            public GE0071S_WS_CONTADORES WS_CONTADORES { get; set; } = new GE0071S_WS_CONTADORES();
            public class GE0071S_WS_CONTADORES : VarBasis
            {
                /*"  10  WI                             PIC S9(004) COMP VALUE 0.*/
                public IntBasis WI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*" 05   WS-DATAS.*/
            }
            public GE0071S_WS_DATAS WS_DATAS { get; set; } = new GE0071S_WS_DATAS();
            public class GE0071S_WS_DATAS : VarBasis
            {
                /*"  10  WS-C-DATE-CURRENT              PIC  X(014) VALUE SPACES.*/
                public StringBasis WS_C_DATE_CURRENT { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
                /*"  10  WS-C-DATE-COMPILED             PIC  X(014) VALUE SPACES.*/
                public StringBasis WS_C_DATE_COMPILED { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
                /*"  05  WS-DATA-AMD.*/
                public GE0071S_WS_DATA_AMD WS_DATA_AMD { get; set; } = new GE0071S_WS_DATA_AMD();
                public class GE0071S_WS_DATA_AMD : VarBasis
                {
                    /*"   10 WS-DATA-AMD-AA                 PIC  X(004) VALUE SPACES.*/
                    public StringBasis WS_DATA_AMD_AA { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                    /*"   10 WS-DATA-AMD-T1                 PIC  X(001) VALUE SPACES.*/
                    public StringBasis WS_DATA_AMD_T1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"   10 WS-DATA-AMD-MM                 PIC  X(002) VALUE SPACES.*/
                    public StringBasis WS_DATA_AMD_MM { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                    /*"   10 WS-DATA-AMD-T2                 PIC  X(001) VALUE SPACES.*/
                    public StringBasis WS_DATA_AMD_T2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"   10 WS-DATA-AMD-DD                 PIC  X(002) VALUE SPACES.*/
                    public StringBasis WS_DATA_AMD_DD { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                    /*" 05   WS-EDIT.*/
                }
            }
            public GE0071S_WS_EDIT WS_EDIT { get; set; } = new GE0071S_WS_EDIT();
            public class GE0071S_WS_EDIT : VarBasis
            {
                /*"  10  WS-SMALLINT                    PIC ZZ.ZZ9- OCCURS 5 TIMES.*/
                public ListBasis<IntBasis, Int64> WS_SMALLINT { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "6", "ZZ.ZZ9-"), 5);
                /*"  10  WS-INTEGER                     PIC Z.ZZZ.ZZZ.ZZ9-                                                 OCCURS 5 TIMES.*/
                public ListBasis<IntBasis, Int64> WS_INTEGER { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "11", "Z.ZZZ.ZZZ.ZZ9-"), 5);
                /*"  10  WS-BIGINT                      PIC 99999999999999                                                 OCCURS 5 TIMES.*/
                public ListBasis<IntBasis, Int64> WS_BIGINT { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "14", "99999999999999"), 5);
                /*"  10  WS-DECIMAL                     PIC ZZZZZZZZZZZZZZ9,99                                                 OCCURS 5 TIMES.*/
                public ListBasis<DoubleBasis, double> WS_DECIMAL { get; set; } = new ListBasis<DoubleBasis, double>(new PIC("9", "15", "ZZZZZZZZZZZZZZ9V99"), 5);
                /*" 05   WS-ERRO.*/
            }
            public GE0071S_WS_ERRO WS_ERRO { get; set; } = new GE0071S_WS_ERRO();
            public class GE0071S_WS_ERRO : VarBasis
            {
                /*"  10  WS-SECTION                     PIC  X(005) VALUE SPACES.*/
                public StringBasis WS_SECTION { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"  10  WS-SQLCODE                     PIC  ZZZZ9-.*/
                public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("9", "6", "ZZZZ9-."));
                /*"  10  WS-SQLERRMC                    PIC  X(076) VALUE SPACES.*/
                public StringBasis WS_SQLERRMC { get; set; } = new StringBasis(new PIC("X", "76", "X(076)"), @"");
                /*"  10  WS-SQLSTATE                    PIC  X(005) VALUE SPACES.*/
                public StringBasis WS_SQLSTATE { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"  10  WS-MENSAGEM                    PIC  X(255) VALUE SPACES.*/
                public StringBasis WS_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "255", "X(255)"), @"");
                /*"  10  WS-TABELA                      PIC  X(050) VALUE SPACES.*/
                public StringBasis WS_TABELA { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
                /*"  10  WS-IND-ERRO                    PIC  9(001) VALUE 0.*/
                public IntBasis WS_IND_ERRO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            }
        }


        public Copies.RSGEWVDT RSGEWVDT { get; set; } = new Copies.RSGEWVDT();
        public Copies.GE0071W GE0071W { get; set; } = new Copies.GE0071W();
        public Dclgens.GE089 GE089 { get; set; } = new Dclgens.GE089();
        public Dclgens.GE090 GE090 { get; set; } = new Dclgens.GE090();
        public Dclgens.GE091 GE091 { get; set; } = new Dclgens.GE091();
        public Dclgens.GE118 GE118 { get; set; } = new Dclgens.GE118();
        public Dclgens.PRODUTO PRODUTO { get; set; } = new Dclgens.PRODUTO();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();

        public GE0071S_GE0071S_C01 GE0071S_C01 { get; set; } = new GE0071S_GE0071S_C01(true);
        string GetQuery_GE0071S_C01()
        {
            var query = @$"SELECT GE091.COD_COBERTURA
							,GE091.VLR_IS
							,GE091.VLR_PREMIO
							,GE091.PCT_PARTICIPACAO
							,GE118.IND_TIPO_COBERTURA
							,GE118.IND_SINISTRO_CANCELA
							,GE118.IND_INDENIZA_MAIS_VEZES
							,GE118.COD_RAMO_COBERTURA
							,VALUE(GE118.DES_APRESENTA_DOC
							,' ')
							FROM SEGUROS.GE_PROD_PREMIO_COBER GE091
							,SEGUROS.GE_PRODUTO_COBERTURA GE118 WHERE GE091.COD_PRODUTO = '{GE091.DCLGE_PROD_PREMIO_COBER.GE091_COD_PRODUTO}' AND GE091.SEQ_PRODUTO_VRS = '{GE091.DCLGE_PROD_PREMIO_COBER.GE091_SEQ_PRODUTO_VRS}' AND GE091.COD_OPC_COBERTURA = '{GE091.DCLGE_PROD_PREMIO_COBER.GE091_COD_OPC_COBERTURA}' AND GE091.IND_CONJUGE = '{GE091.DCLGE_PROD_PREMIO_COBER.GE091_IND_CONJUGE}' AND GE091.NUM_IDADE_INI = '{GE091.DCLGE_PROD_PREMIO_COBER.GE091_NUM_IDADE_INI}' AND GE118.COD_PRODUTO = GE091.COD_PRODUTO AND GE118.SEQ_PRODUTO_VRS = GE091.SEQ_PRODUTO_VRS AND GE118.COD_COBERTURA = GE091.COD_COBERTURA";

            return query;
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(GE0071W GE0071W_P, GE0071W_LK_0071_S_ARR LK_0071_S_ARR_P) //PROCEDURE DIVISION USING 
        /*PROCEDURE DIVISION
        LK_0071_E_TRACE
        LK_0071_E_COD_USUARIO
        LK_0071_E_NOM_PROGRAMA
        LK_0071_E_ACAO
        LK_0071_I_COD_PRODUTO
        LK_0071_I_SEQ_PRODUTO_VRS
        LK_0071_I_COD_OPC_COBERTURA
        LK_0071_I_COD_OPC_PLANO
        LK_0071_I_IND_CONJUGE
        LK_0071_I_NUM_IDADE
        LK_0071_S_NUM_IDADE_INI
        LK_0071_S_NUM_IDADE_FIM
        LK_0071_S_VLR_INI_PREMIO
        LK_0071_S_VLR_FIM_PREMIO
        LK_0071_S_PCT_IOF
        LK_0071_S_PCT_REENQUADRAMENTO
        LK_0071_S_IND_PERMIT_VENDA
        LK_0071_S_VLR_TOTAL_IS
        LK_0071_S_QTD_OCC
        LK_0071_S_ARR
        LK_0071_IND_ERRO
        LK_0071_MSG_ERRO
        LK_0071_NOM_TABELA
        LK_0071_SQLCODE
        LK_0071_SQLERRMC
        LK_0071_SQLSTATE*/
        {
            try
            {
                this.GE0071W = GE0071W_P;
                this.GE0071W.LK_0071_S_ARR = LK_0071_S_ARR_P;
                InitializeGetQuery();

                /*" -0- FLUXCONTROL_PERFORM P0000-INICIALIZAR-SECTION */

                P0000_INICIALIZAR_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { GE0071W, GE0071W.LK_0071_S_ARR };
            return Result;
        }

        public void InitializeGetQuery()
        {
            GE0071S_C01.GetQueryEvent += GetQuery_GE0071S_C01;
        }

        [StopWatch]
        /*" P0000-INICIALIZAR-SECTION */
        private void P0000_INICIALIZAR_SECTION()
        {
            /*" -189- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -190- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -191- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -194- MOVE FUNCTION CURRENT-DATE(1:14) TO WS-C-DATE-CURRENT. */
            _.Move(_.CurrentDate(0, 14), WORK.WS_DATAS.WS_C_DATE_CURRENT);

            /*" -196- MOVE FUNCTION WHEN-COMPILED TO WS-C-DATE-COMPILED. */
            _.Move(_.WhenCompiled(), WORK.WS_DATAS.WS_C_DATE_COMPILED);

            /*" -200- INITIALIZE LK-0071-IND-ERRO LK-0071-MSG-ERRO LK-0071-NOM-TABELA LK-0071-SQLCODE LK-0071-SQLERRMC LK-0071-SQLSTATE WS-ERRO */
            _.Initialize(
                GE0071W.LK_0071_S_ARR.LK_0071_IND_ERRO
                , GE0071W.LK_0071_S_ARR.LK_0071_MSG_ERRO
                , GE0071W.LK_0071_S_ARR.LK_0071_NOM_TABELA
                , GE0071W.LK_0071_S_ARR.LK_0071_SQLCODE
                , GE0071W.LK_0071_S_ARR.LK_0071_SQLERRMC
                , GE0071W.LK_0071_S_ARR.LK_0071_SQLSTATE
                , WORK.WS_ERRO
            );

            /*" -200- MOVE '0001' TO LK-RSGEWVDT-ANO */
            _.Move("0001", RSGEWVDT.LK_RSGEWVDT_ANO);

            /*" -200- MOVE '01' TO LK-RSGEWVDT-MES */
            _.Move("01", RSGEWVDT.LK_RSGEWVDT_MES);

            /*" -200- MOVE '01' TO LK-RSGEWVDT-DIA */
            _.Move("01", RSGEWVDT.LK_RSGEWVDT_DIA);

            /*" -200- MOVE ZEROS TO LK-RSGEWVDT-IND-RETORNO */
            _.Move(0, RSGEWVDT.LK_RSGEWVDT_IND_RETORNO);

            /*" -202- MOVE SPACES TO LK-RSGEWVDT-OUT-DATA */
            _.Move("", RSGEWVDT.LK_RSGEWVDT_OUT_DATA);

            /*" -203- IF NOT ( LK-0071-E-TRACE = 'S' OR = 'N' ) */

            if (!(GE0071W.LK_0071_E_TRACE.In("S", "N")))
            {

                /*" -204- MOVE 'N' TO LK-0071-E-TRACE */
                _.Move("N", GE0071W.LK_0071_E_TRACE);

                /*" -206- END-IF */
            }


            /*" -208- PERFORM P0050-VERIFICAR-SISTEMA */

            P0050_VERIFICAR_SISTEMA_SECTION();

            /*" -209- IF LK-0071-E-TRACE = 'S' */

            if (GE0071W.LK_0071_E_TRACE == "S")
            {

                /*" -210- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -211- DISPLAY '*              G E 0 0 7 1 S                 *' */
                _.Display($"*              G E 0 0 7 1 S                 *");

                /*" -212- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -219- DISPLAY '* DATA COMPILACAO....: ' WS-C-DATE-COMPILED(7:2) '/' WS-C-DATE-COMPILED(5:2) '/' WS-C-DATE-COMPILED(1:4) '-' WS-C-DATE-COMPILED(9:2) ':' WS-C-DATE-COMPILED(11:2) ':' WS-C-DATE-COMPILED(13:2) */

                $"* DATA COMPILACAO....: {WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(7, 2)}/{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(5, 2)}/{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(1, 4)}-{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(9, 2)}:{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(11, 2)}:{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(13, 2)}"
                .Display();

                /*" -226- DISPLAY '* DATA EXECUCAO......: ' WS-C-DATE-CURRENT(7:2) '/' WS-C-DATE-CURRENT(5:2) '/' WS-C-DATE-CURRENT(1:4) '-' WS-C-DATE-CURRENT(9:2) ':' WS-C-DATE-CURRENT(11:2) ':' WS-C-DATE-CURRENT(13:2) */

                $"* DATA EXECUCAO......: {WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(7, 2)}/{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(5, 2)}/{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(1, 4)}-{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(9, 2)}:{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(11, 2)}:{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(13, 2)}"
                .Display();

                /*" -230- DISPLAY '* DATA SISTEMA.......: ' SISTEMAS-DATA-MOV-ABERTO(9:2) '/' SISTEMAS-DATA-MOV-ABERTO(6:2) '/' SISTEMAS-DATA-MOV-ABERTO(1:4) */

                $"* DATA SISTEMA.......: {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2)}/{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2)}/{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4)}"
                .Display();

                /*" -231- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -232- DISPLAY '*             DADOS DE ENTRADA               *' */
                _.Display($"*             DADOS DE ENTRADA               *");

                /*" -233- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -234- DISPLAY '* TRACE..............: ' LK-0071-E-TRACE */
                _.Display($"* TRACE..............: {GE0071W.LK_0071_E_TRACE}");

                /*" -235- DISPLAY '* COD-USUARIO........: ' LK-0071-E-COD-USUARIO */
                _.Display($"* COD-USUARIO........: {GE0071W.LK_0071_E_COD_USUARIO}");

                /*" -236- DISPLAY '* NOM-PROGRAMA.......: ' LK-0071-E-NOM-PROGRAMA */
                _.Display($"* NOM-PROGRAMA.......: {GE0071W.LK_0071_E_NOM_PROGRAMA}");

                /*" -237- MOVE LK-0071-E-ACAO TO WS-SMALLINT(01) */
                _.Move(GE0071W.LK_0071_E_ACAO, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -238- DISPLAY '* ACAO...............: ' WS-SMALLINT(01) */
                _.Display($"* ACAO...............: {WORK.WS_EDIT.WS_SMALLINT[1]}");

                /*" -239- MOVE LK-0071-I-COD-PRODUTO TO WS-SMALLINT(01) */
                _.Move(GE0071W.LK_0071_I_COD_PRODUTO, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -240- DISPLAY '* COD-PRODUTO........: ' WS-SMALLINT(01) */
                _.Display($"* COD-PRODUTO........: {WORK.WS_EDIT.WS_SMALLINT[1]}");

                /*" -241- MOVE LK-0071-I-SEQ-PRODUTO-VRS TO WS-SMALLINT(01) */
                _.Move(GE0071W.LK_0071_I_SEQ_PRODUTO_VRS, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -242- DISPLAY '* SEQ-PRODUTO-VRS....: ' WS-SMALLINT(01) */
                _.Display($"* SEQ-PRODUTO-VRS....: {WORK.WS_EDIT.WS_SMALLINT[1]}");

                /*" -244- DISPLAY '* COD-OPC-COBERTURA..: ' LK-0071-I-COD-OPC-COBERTURA */
                _.Display($"* COD-OPC-COBERTURA..: {GE0071W.LK_0071_I_COD_OPC_COBERTURA}");

                /*" -245- MOVE LK-0071-I-COD-OPC-PLANO TO WS-SMALLINT(01) */
                _.Move(GE0071W.LK_0071_I_COD_OPC_PLANO, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -246- DISPLAY '* COD-OPC-PLANO......: ' WS-SMALLINT(01) */
                _.Display($"* COD-OPC-PLANO......: {WORK.WS_EDIT.WS_SMALLINT[1]}");

                /*" -247- DISPLAY '* IND-CONJUGE........: ' LK-0071-I-IND-CONJUGE */
                _.Display($"* IND-CONJUGE........: {GE0071W.LK_0071_I_IND_CONJUGE}");

                /*" -248- MOVE LK-0071-I-NUM-IDADE TO WS-SMALLINT(01) */
                _.Move(GE0071W.LK_0071_I_NUM_IDADE, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -249- DISPLAY '* NUM-IDADE..........: ' WS-SMALLINT(01) */
                _.Display($"* NUM-IDADE..........: {WORK.WS_EDIT.WS_SMALLINT[1]}");

                /*" -250- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -252- END-IF */
            }


            /*" -252- PERFORM P0005-PROCESSAR */

            P0005_PROCESSAR_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0000_99_EXIT*/

        [StopWatch]
        /*" P0005-PROCESSAR-SECTION */
        private void P0005_PROCESSAR_SECTION()
        {
            /*" -263- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0005_00_START */

            P0005_00_START();

        }

        [StopWatch]
        /*" P0005-00-START */
        private void P0005_00_START(bool isPerform = false)
        {
            /*" -266- MOVE 'P0005' TO WS-SECTION */
            _.Move("P0005", WORK.WS_ERRO.WS_SECTION);

            /*" -266- PERFORM P0005-05-INICIO */

            P0005_05_INICIO(true);

        }

        [StopWatch]
        /*" P0005-05-INICIO */
        private void P0005_05_INICIO(bool isPerform = false)
        {
            /*" -272- PERFORM P0100-VALIDAR-LINKAGE */

            P0100_VALIDAR_LINKAGE_SECTION();

            /*" -273-  EVALUATE TRUE  */

            /*" -274-  WHEN LK-0071-E-ACAO         = 01  */

            /*" -274- IF LK-0071-E-ACAO         = 01 */

            if (GE0071W.LK_0071_E_ACAO == 01)
            {

                /*" -275- PERFORM P0200-REALIZAR-ACAO-01 */

                P0200_REALIZAR_ACAO_01_SECTION();

                /*" -276-  WHEN OTHER  */

                /*" -276- ELSE */
            }
            else
            {


                /*" -277- MOVE 'P0005' TO WS-SECTION */
                _.Move("P0005", WORK.WS_ERRO.WS_SECTION);

                /*" -278- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -279- MOVE LK-0071-E-ACAO TO WS-SMALLINT(01) */
                _.Move(GE0071W.LK_0071_E_ACAO, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -283- STRING WS-SECTION ' - ACAO NAO PREVISTA. ' '<ACAO=' WS-SMALLINT(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl1 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl1 += " - ACAO NAO PREVISTA. ";
                spl1 += "<ACAO=";
                var spl2 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl2 += ">";
                var results3 = spl1 + spl2;
                _.Move(results3, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -285- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -286- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -287- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -289-  END-EVALUATE  */

                /*" -289- END-IF */
            }


            /*" -289- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0005_99_EXIT*/

        [StopWatch]
        /*" P0010-FINALIZAR-SECTION */
        private void P0010_FINALIZAR_SECTION()
        {
            /*" -300- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0010_00_START */

            P0010_00_START();

        }

        [StopWatch]
        /*" P0010-00-START */
        private void P0010_00_START(bool isPerform = false)
        {
            /*" -303- MOVE 'P0010' TO WS-SECTION */
            _.Move("P0010", WORK.WS_ERRO.WS_SECTION);

            /*" -303- . */

        }

        [StopWatch]
        /*" P0010-05-INICIO */
        private void P0010_05_INICIO(bool isPerform = false)
        {
            /*" -308- MOVE 0 TO WS-IND-ERRO */
            _.Move(0, WORK.WS_ERRO.WS_IND_ERRO);

            /*" -310- STRING 'OPERACAO SOLICITADA REALIZADA COM SUCESSO.' DELIMITED BY SIZE INTO WS-MENSAGEM */
            #region STRING
            var spl3 = "OPERACAO SOLICITADA REALIZADA COM SUCESSO.";
            _.Move(spl3, WORK.WS_ERRO.WS_MENSAGEM);
            #endregion

            /*" -311- MOVE WS-MENSAGEM TO LK-0071-MSG-ERRO */
            _.Move(WORK.WS_ERRO.WS_MENSAGEM, GE0071W.LK_0071_S_ARR.LK_0071_MSG_ERRO);

            /*" -313- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
            _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

            /*" -315- MOVE 0 TO WS-SQLCODE */
            _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

            /*" -315- . */

        }

        [StopWatch]
        /*" P0010-99-EXIT */
        private void P0010_99_EXIT(bool isPerform = false)
        {
            /*" -318- GOBACK. */

            throw new GoBack();

        }

        [StopWatch]
        /*" P0050-VERIFICAR-SISTEMA-SECTION */
        private void P0050_VERIFICAR_SISTEMA_SECTION()
        {
            /*" -326- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0050_00_START */

            P0050_00_START();

        }

        [StopWatch]
        /*" P0050-00-START */
        private void P0050_00_START(bool isPerform = false)
        {
            /*" -330- MOVE 'P0050' TO WS-SECTION */
            _.Move("P0050", WORK.WS_ERRO.WS_SECTION);

            /*" -330- PERFORM P0050-05-INICIO */

            P0050_05_INICIO(true);

        }

        [StopWatch]
        /*" P0050-05-INICIO */
        private void P0050_05_INICIO(bool isPerform = false)
        {
            /*" -340- PERFORM P0050_05_INICIO_DB_SELECT_1 */

            P0050_05_INICIO_DB_SELECT_1();

            /*" -343- IF NOT ( SQLCODE = 0 OR = 100 ) */

            if (!(DB.SQLCODE.In("0", "100")))
            {

                /*" -344- MOVE 'P0050' TO WS-SECTION */
                _.Move("P0050", WORK.WS_ERRO.WS_SECTION);

                /*" -345- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -349- STRING WS-SECTION ' - ERRO NO SELECT NA SEGUROS.SISTEMA.' '<SISTEMA=GE>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl4 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl4 += " - ERRO NO SELECT NA SEGUROS.SISTEMA.";
                spl4 += "<SISTEMA=GE>";
                _.Move(spl4, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -350- MOVE 'SEGUROS.SISTEMA' TO WS-TABELA */
                _.Move("SEGUROS.SISTEMA", WORK.WS_ERRO.WS_TABELA);

                /*" -351- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -352- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -353- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -354- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -356- END-IF */
            }


            /*" -357- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -358- MOVE 'P0050' TO WS-SECTION */
                _.Move("P0050", WORK.WS_ERRO.WS_SECTION);

                /*" -359- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -363- STRING WS-SECTION ' - REGISTRO DE CONTROLE SISTEMA NAO CADASTRADO. ' '<SISTEMA=GE>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl5 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl5 += " - REGISTRO DE CONTROLE SISTEMA NAO CADASTRADO. ";
                spl5 += "<SISTEMA=GE>";
                _.Move(spl5, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -364- MOVE 'SEGUROS.SISTEMA' TO WS-TABELA */
                _.Move("SEGUROS.SISTEMA", WORK.WS_ERRO.WS_TABELA);

                /*" -365- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -366- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -367- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -368- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -370- END-IF */
            }


            /*" -370- . */

        }

        [StopWatch]
        /*" P0050-05-INICIO-DB-SELECT-1 */
        public void P0050_05_INICIO_DB_SELECT_1()
        {
            /*" -340- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'GE' WITH UR END-EXEC. */

            var p0050_05_INICIO_DB_SELECT_1_Query1 = new P0050_05_INICIO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = P0050_05_INICIO_DB_SELECT_1_Query1.Execute(p0050_05_INICIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0050_99_EXIT*/

        [StopWatch]
        /*" P0100-VALIDAR-LINKAGE-SECTION */
        private void P0100_VALIDAR_LINKAGE_SECTION()
        {
            /*" -381- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0100_00_START */

            P0100_00_START();

        }

        [StopWatch]
        /*" P0100-00-START */
        private void P0100_00_START(bool isPerform = false)
        {
            /*" -384- MOVE 'P0100' TO WS-SECTION */
            _.Move("P0100", WORK.WS_ERRO.WS_SECTION);

            /*" -384- PERFORM P0100-05-INICIO */

            P0100_05_INICIO(true);

        }

        [StopWatch]
        /*" P0100-05-INICIO */
        private void P0100_05_INICIO(bool isPerform = false)
        {
            /*" -389- IF LK-0071-E-COD-USUARIO = SPACES */

            if (GE0071W.LK_0071_E_COD_USUARIO.IsEmpty())
            {

                /*" -390- MOVE 'P0100' TO WS-SECTION */
                _.Move("P0100", WORK.WS_ERRO.WS_SECTION);

                /*" -391- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -395- STRING WS-SECTION ' - CODIGO DO USUARIO NAO INFORMADO. ' '<COD_USUARIO=' LK-0071-E-COD-USUARIO '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl6 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl6 += " - CODIGO DO USUARIO NAO INFORMADO. ";
                spl6 += "<COD_USUARIO=";
                var spl7 = GE0071W.LK_0071_E_COD_USUARIO.GetMoveValues();
                spl7 += ">";
                var results8 = spl6 + spl7;
                _.Move(results8, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -397- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -398- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -399- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -401- END-IF */
            }


            /*" -402- IF LK-0071-E-NOM-PROGRAMA = SPACES */

            if (GE0071W.LK_0071_E_NOM_PROGRAMA.IsEmpty())
            {

                /*" -403- MOVE 'P0100' TO WS-SECTION */
                _.Move("P0100", WORK.WS_ERRO.WS_SECTION);

                /*" -404- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -408- STRING WS-SECTION ' - NOME DO PROGRAMA NAO INFORMADO. ' '<NOM_PROGRAMA=' LK-0071-E-NOM-PROGRAMA '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl8 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl8 += " - NOME DO PROGRAMA NAO INFORMADO. ";
                spl8 += "<NOM_PROGRAMA=";
                var spl9 = GE0071W.LK_0071_E_NOM_PROGRAMA.GetMoveValues();
                spl9 += ">";
                var results10 = spl8 + spl9;
                _.Move(results10, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -410- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -411- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -412- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -414- END-IF */
            }


            /*" -415- IF NOT ( LK-0071-E-ACAO = 01 ) */

            if (!(GE0071W.LK_0071_E_ACAO == 01))
            {

                /*" -416- MOVE 'P0100' TO WS-SECTION */
                _.Move("P0100", WORK.WS_ERRO.WS_SECTION);

                /*" -417- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -418- MOVE LK-0071-E-ACAO TO WS-SMALLINT(01) */
                _.Move(GE0071W.LK_0071_E_ACAO, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -422- STRING WS-SECTION ' - ACAO NAO PREVISTA. ' '<ACAO=' WS-SMALLINT(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl10 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl10 += " - ACAO NAO PREVISTA. ";
                spl10 += "<ACAO=";
                var spl11 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl11 += ">";
                var results12 = spl10 + spl11;
                _.Move(results12, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -424- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -425- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -426- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -428- END-IF */
            }


            /*" -430- PERFORM P0101-PESQUISAR-GE089 */

            P0101_PESQUISAR_GE089_SECTION();

            /*" -434- IF ( LK-0071-I-COD-OPC-COBERTURA = SPACES AND LK-0071-I-COD-OPC-PLANO = 0 ) OR ( LK-0071-I-COD-OPC-COBERTURA NOT = SPACES AND LK-0071-I-COD-OPC-PLANO > 0 ) */

            if ((GE0071W.LK_0071_I_COD_OPC_COBERTURA.IsEmpty() && GE0071W.LK_0071_I_COD_OPC_PLANO == 0) || (!GE0071W.LK_0071_I_COD_OPC_COBERTURA.IsEmpty() && GE0071W.LK_0071_I_COD_OPC_PLANO > 0))
            {

                /*" -435- MOVE 'P0100' TO WS-SECTION */
                _.Move("P0100", WORK.WS_ERRO.WS_SECTION);

                /*" -436- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -437- MOVE LK-0071-I-COD-OPC-PLANO TO WS-SMALLINT(01) */
                _.Move(GE0071W.LK_0071_I_COD_OPC_PLANO, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -443- STRING WS-SECTION ' - INFORME OPCAO DE COBERTURA OU OPCAO DE PLANO. ' '<OPC-COBERTURA=' LK-0071-I-COD-OPC-COBERTURA '>' '<OPC-PLANO=' WS-SMALLINT(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl12 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl12 += " - INFORME OPCAO DE COBERTURA OU OPCAO DE PLANO. ";
                spl12 += "<OPC-COBERTURA=";
                var spl13 = GE0071W.LK_0071_I_COD_OPC_COBERTURA.GetMoveValues();
                spl13 += ">";
                spl13 += "<OPC-PLANO=";
                var spl14 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl14 += ">";
                var results15 = spl12 + spl13 + spl14;
                _.Move(results15, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -445- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -446- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -447- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -455- END-IF */
            }


            /*" -455- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0100_99_EXIT*/

        [StopWatch]
        /*" P0101-PESQUISAR-GE089-SECTION */
        private void P0101_PESQUISAR_GE089_SECTION()
        {
            /*" -466- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0101_00_START */

            P0101_00_START();

        }

        [StopWatch]
        /*" P0101-00-START */
        private void P0101_00_START(bool isPerform = false)
        {
            /*" -470- MOVE 'P0101' TO WS-SECTION */
            _.Move("P0101", WORK.WS_ERRO.WS_SECTION);

            /*" -472- MOVE LK-0071-I-COD-PRODUTO TO GE089-COD-PRODUTO WS-SMALLINT(01) */
            _.Move(GE0071W.LK_0071_I_COD_PRODUTO, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_COD_PRODUTO, WORK.WS_EDIT.WS_SMALLINT[01]);

            /*" -475- MOVE LK-0071-I-SEQ-PRODUTO-VRS TO GE089-SEQ-PRODUTO-VRS WS-SMALLINT(02) */
            _.Move(GE0071W.LK_0071_I_SEQ_PRODUTO_VRS, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_SEQ_PRODUTO_VRS, WORK.WS_EDIT.WS_SMALLINT[02]);

            /*" -475- PERFORM P0101-05-INICIO */

            P0101_05_INICIO(true);

        }

        [StopWatch]
        /*" P0101-05-INICIO */
        private void P0101_05_INICIO(bool isPerform = false)
        {
            /*" -486- PERFORM P0101_05_INICIO_DB_SELECT_1 */

            P0101_05_INICIO_DB_SELECT_1();

            /*" -489- IF NOT ( SQLCODE = 0 OR = 100 ) */

            if (!(DB.SQLCODE.In("0", "100")))
            {

                /*" -490- MOVE 'P0101' TO WS-SECTION */
                _.Move("P0101", WORK.WS_ERRO.WS_SECTION);

                /*" -491- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -497- STRING WS-SECTION ' - ERRO NO SELECT NA SEGUROS.GE_PRODUTO_COMPLEMENTO' '. ' '<COD-PRODUTO=' WS-SMALLINT(01) '>' '<SEQ-PRODUTO-VRS=' WS-SMALLINT(02) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl15 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl15 += " - ERRO NO SELECT NA SEGUROS.GE_PRODUTO_COMPLEMENTO";
                spl15 += ". ";
                spl15 += "<COD-PRODUTO=";
                var spl16 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl16 += ">";
                spl16 += "<SEQ-PRODUTO-VRS=";
                var spl17 = WORK.WS_EDIT.WS_SMALLINT[02].GetMoveValues();
                spl17 += ">";
                var results18 = spl15 + spl16 + spl17;
                _.Move(results18, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -499- MOVE 'SEGUROS.GE_PRODUTO_COMPLEMENTO' TO WS-TABELA */
                _.Move("SEGUROS.GE_PRODUTO_COMPLEMENTO", WORK.WS_ERRO.WS_TABELA);

                /*" -500- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -501- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -502- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -503- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -505- END-IF */
            }


            /*" -506- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -507- MOVE 'P0101' TO WS-SECTION */
                _.Move("P0101", WORK.WS_ERRO.WS_SECTION);

                /*" -508- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -513- STRING WS-SECTION ' - CODIGO DE PRODUTO/VERSAO NAO CADASTRADO. ' '<COD-PRODUTO=' WS-SMALLINT(01) '>' '<SEQ-PRODUTO-VRS=' WS-SMALLINT(02) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl18 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl18 += " - CODIGO DE PRODUTO/VERSAO NAO CADASTRADO. ";
                spl18 += "<COD-PRODUTO=";
                var spl19 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl19 += ">";
                spl19 += "<SEQ-PRODUTO-VRS=";
                var spl20 = WORK.WS_EDIT.WS_SMALLINT[02].GetMoveValues();
                spl20 += ">";
                var results21 = spl18 + spl19 + spl20;
                _.Move(results21, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -515- MOVE 'SEGUROS.GE_PRODUTO_COMPLEMENTO' TO WS-TABELA */
                _.Move("SEGUROS.GE_PRODUTO_COMPLEMENTO", WORK.WS_ERRO.WS_TABELA);

                /*" -516- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -517- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -518- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -519- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -521- END-IF */
            }


            /*" -521- . */

        }

        [StopWatch]
        /*" P0101-05-INICIO-DB-SELECT-1 */
        public void P0101_05_INICIO_DB_SELECT_1()
        {
            /*" -486- EXEC SQL SELECT IND_FLUXO_PARAMTRIZADO INTO :GE089-IND-FLUXO-PARAMTRIZADO FROM SEGUROS.GE_PRODUTO_COMPLEMENTO WHERE COD_PRODUTO = :GE089-COD-PRODUTO AND SEQ_PRODUTO_VRS = :GE089-SEQ-PRODUTO-VRS WITH UR END-EXEC. */

            var p0101_05_INICIO_DB_SELECT_1_Query1 = new P0101_05_INICIO_DB_SELECT_1_Query1()
            {
                GE089_SEQ_PRODUTO_VRS = GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_SEQ_PRODUTO_VRS.ToString(),
                GE089_COD_PRODUTO = GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_COD_PRODUTO.ToString(),
            };

            var executed_1 = P0101_05_INICIO_DB_SELECT_1_Query1.Execute(p0101_05_INICIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE089_IND_FLUXO_PARAMTRIZADO, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_IND_FLUXO_PARAMTRIZADO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0101_99_EXIT*/

        [StopWatch]
        /*" P0200-REALIZAR-ACAO-01-SECTION */
        private void P0200_REALIZAR_ACAO_01_SECTION()
        {
            /*" -532- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0200_00_START */

            P0200_00_START();

        }

        [StopWatch]
        /*" P0200-00-START */
        private void P0200_00_START(bool isPerform = false)
        {
            /*" -536- MOVE 'P0200' TO WS-SECTION */
            _.Move("P0200", WORK.WS_ERRO.WS_SECTION);

            /*" -536- PERFORM P0200-05-INICIO */

            P0200_05_INICIO(true);

        }

        [StopWatch]
        /*" P0200-05-INICIO */
        private void P0200_05_INICIO(bool isPerform = false)
        {
            /*" -541-  EVALUATE TRUE  */

            /*" -542-  WHEN LK-0071-I-COD-OPC-COBERTURA NOT = SPACES  */

            /*" -542- IF LK-0071-I-COD-OPC-COBERTURA NOT = SPACES */

            if (!GE0071W.LK_0071_I_COD_OPC_COBERTURA.IsEmpty())
            {

                /*" -543- PERFORM P0201-PESQUISAR-PROD-PRM-OCB */

                P0201_PESQUISAR_PROD_PRM_OCB_SECTION();

                /*" -544-  WHEN LK-0071-I-COD-OPC-PLANO > 0  */

                /*" -544- ELSE IF LK-0071-I-COD-OPC-PLANO > 0 */
            }
            else

            if (GE0071W.LK_0071_I_COD_OPC_PLANO > 0)
            {

                /*" -545- PERFORM P0202-PESQUISAR-PROD-PRM-OPL */

                P0202_PESQUISAR_PROD_PRM_OPL_SECTION();

                /*" -546-  WHEN OTHER  */

                /*" -546- ELSE */
            }
            else
            {


                /*" -547- MOVE 'P0200' TO WS-SECTION */
                _.Move("P0200", WORK.WS_ERRO.WS_SECTION);

                /*" -548- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -550- MOVE LK-0071-I-COD-OPC-PLANO TO WS-SMALLINT(01) */
                _.Move(GE0071W.LK_0071_I_COD_OPC_PLANO, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -556- STRING WS-SECTION ' - INFORME OPCAO DE COBERTURA OU OPCAO DE PLANO. ' '<OPC-COBERTURA=' LK-0071-I-COD-OPC-COBERTURA '>' '<OPC-PLANO=' WS-SMALLINT(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl21 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl21 += " - INFORME OPCAO DE COBERTURA OU OPCAO DE PLANO. ";
                spl21 += "<OPC-COBERTURA=";
                var spl22 = GE0071W.LK_0071_I_COD_OPC_COBERTURA.GetMoveValues();
                spl22 += ">";
                spl22 += "<OPC-PLANO=";
                var spl23 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl23 += ">";
                var results24 = spl21 + spl22 + spl23;
                _.Move(results24, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -558- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -559- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -560- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -562-  END-EVALUATE  */

                /*" -562- END-IF */
            }


            /*" -563- PERFORM P0205-PESQUISAR-PREMIO-COBER */

            P0205_PESQUISAR_PREMIO_COBER_SECTION();

            /*" -564- IF LK-0071-S-QTD-OCC < 1 */

            if (GE0071W.LK_0071_S_QTD_OCC < 1)
            {

                /*" -565- MOVE 'P0200' TO WS-SECTION */
                _.Move("P0200", WORK.WS_ERRO.WS_SECTION);

                /*" -566- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -567- MOVE LK-0071-I-COD-PRODUTO TO WS-SMALLINT(01) */
                _.Move(GE0071W.LK_0071_I_COD_PRODUTO, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -568- MOVE LK-0071-I-SEQ-PRODUTO-VRS TO WS-SMALLINT(02) */
                _.Move(GE0071W.LK_0071_I_SEQ_PRODUTO_VRS, WORK.WS_EDIT.WS_SMALLINT[02]);

                /*" -570- MOVE LK-0071-I-COD-OPC-COBERTURA TO GE090-COD-OPC-COBERTURA */
                _.Move(GE0071W.LK_0071_I_COD_OPC_COBERTURA, GE090.DCLGE_PRODUTO_PREMIO.GE090_COD_OPC_COBERTURA);

                /*" -571- MOVE LK-0071-I-COD-OPC-PLANO TO WS-SMALLINT(03) */
                _.Move(GE0071W.LK_0071_I_COD_OPC_PLANO, WORK.WS_EDIT.WS_SMALLINT[03]);

                /*" -572- MOVE LK-0071-I-NUM-IDADE TO WS-SMALLINT(04) */
                _.Move(GE0071W.LK_0071_I_NUM_IDADE, WORK.WS_EDIT.WS_SMALLINT[04]);

                /*" -573- MOVE GE090-NUM-IDADE-INI TO WS-SMALLINT(05) */
                _.Move(GE090.DCLGE_PRODUTO_PREMIO.GE090_NUM_IDADE_INI, WORK.WS_EDIT.WS_SMALLINT[05]);

                /*" -583- STRING WS-SECTION ' - NAO ENCONTRADO CONFIGURACAO DE COBERTURAS. ' '<COD-PRODUTO=' WS-SMALLINT(01) '>' '<SEQ-PRODUTO-VRS=' WS-SMALLINT(02) '>' '<COD-OPC-COBERTURA=' LK-0071-I-COD-OPC-COBERTURA '>' '<COD-OPC-PLANO=' WS-SMALLINT(03) '>' '<IND-CONJUGE=' LK-0071-I-IND-CONJUGE '>' '<NUM-IDADE=' WS-SMALLINT(04) '>' '<NUM-IDADE-INI=' WS-SMALLINT(05) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl24 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl24 += " - NAO ENCONTRADO CONFIGURACAO DE COBERTURAS. ";
                spl24 += "<COD-PRODUTO=";
                var spl25 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl25 += ">";
                spl25 += "<SEQ-PRODUTO-VRS=";
                var spl26 = WORK.WS_EDIT.WS_SMALLINT[02].GetMoveValues();
                spl26 += ">";
                spl26 += "<COD-OPC-COBERTURA=";
                var spl27 = GE0071W.LK_0071_I_COD_OPC_COBERTURA.GetMoveValues();
                spl27 += ">";
                spl27 += "<COD-OPC-PLANO=";
                var spl28 = WORK.WS_EDIT.WS_SMALLINT[03].GetMoveValues();
                spl28 += ">";
                spl28 += "<IND-CONJUGE=";
                var spl29 = GE0071W.LK_0071_I_IND_CONJUGE.GetMoveValues();
                spl29 += ">";
                spl29 += "<NUM-IDADE=";
                var spl30 = WORK.WS_EDIT.WS_SMALLINT[04].GetMoveValues();
                spl30 += ">";
                spl30 += "<NUM-IDADE-INI=";
                var spl31 = WORK.WS_EDIT.WS_SMALLINT[05].GetMoveValues();
                spl31 += ">";
                var results32 = spl24 + spl25 + spl26 + spl27 + spl28 + spl29 + spl30 + spl31;
                _.Move(results32, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -585- MOVE 'SEGUROS.GE_PROD_PREMIO_COBER' TO WS-TABELA */
                _.Move("SEGUROS.GE_PROD_PREMIO_COBER", WORK.WS_ERRO.WS_TABELA);

                /*" -586- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -587- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -588- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -589- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -591- END-IF */
            }


            /*" -591- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0200_99_EXIT*/

        [StopWatch]
        /*" P0201-PESQUISAR-PROD-PRM-OCB-SECTION */
        private void P0201_PESQUISAR_PROD_PRM_OCB_SECTION()
        {
            /*" -603- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0201_00_START */

            P0201_00_START();

        }

        [StopWatch]
        /*" P0201-00-START */
        private void P0201_00_START(bool isPerform = false)
        {
            /*" -607- MOVE 'P0201' TO WS-SECTION */
            _.Move("P0201", WORK.WS_ERRO.WS_SECTION);

            /*" -609- MOVE LK-0071-I-COD-PRODUTO TO GE090-COD-PRODUTO WS-SMALLINT(01) */
            _.Move(GE0071W.LK_0071_I_COD_PRODUTO, GE090.DCLGE_PRODUTO_PREMIO.GE090_COD_PRODUTO, WORK.WS_EDIT.WS_SMALLINT[01]);

            /*" -611- MOVE LK-0071-I-SEQ-PRODUTO-VRS TO GE090-SEQ-PRODUTO-VRS WS-SMALLINT(02) */
            _.Move(GE0071W.LK_0071_I_SEQ_PRODUTO_VRS, GE090.DCLGE_PRODUTO_PREMIO.GE090_SEQ_PRODUTO_VRS, WORK.WS_EDIT.WS_SMALLINT[02]);

            /*" -613- MOVE LK-0071-I-COD-OPC-COBERTURA TO GE090-COD-OPC-COBERTURA */
            _.Move(GE0071W.LK_0071_I_COD_OPC_COBERTURA, GE090.DCLGE_PRODUTO_PREMIO.GE090_COD_OPC_COBERTURA);

            /*" -614- MOVE LK-0071-I-IND-CONJUGE TO GE090-IND-CONJUGE */
            _.Move(GE0071W.LK_0071_I_IND_CONJUGE, GE090.DCLGE_PRODUTO_PREMIO.GE090_IND_CONJUGE);

            /*" -617- MOVE LK-0071-I-NUM-IDADE TO GE090-NUM-IDADE-INI WS-SMALLINT(03) */
            _.Move(GE0071W.LK_0071_I_NUM_IDADE, GE090.DCLGE_PRODUTO_PREMIO.GE090_NUM_IDADE_INI, WORK.WS_EDIT.WS_SMALLINT[03]);

            /*" -617- PERFORM P0201-05-INICIO */

            P0201_05_INICIO(true);

        }

        [StopWatch]
        /*" P0201-05-INICIO */
        private void P0201_05_INICIO(bool isPerform = false)
        {
            /*" -648- PERFORM P0201_05_INICIO_DB_SELECT_1 */

            P0201_05_INICIO_DB_SELECT_1();

            /*" -651- IF NOT ( SQLCODE = 0 OR = 100 ) */

            if (!(DB.SQLCODE.In("0", "100")))
            {

                /*" -652- MOVE 'P0201' TO WS-SECTION */
                _.Move("P0201", WORK.WS_ERRO.WS_SECTION);

                /*" -653- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -661- STRING WS-SECTION ' - ERRO NO SELECT NA SEGUROS.GE_PRODUTO_PREMIO. ' '<COD-PRODUTO=' WS-SMALLINT(01) '>' '<SEQ-PRODUTO-VRS=' WS-SMALLINT(02) '>' '<COD-OPC-COBERTURA=' LK-0071-I-COD-OPC-COBERTURA '>' '<COD-IND-CONJUGE=' LK-0071-I-IND-CONJUGE '>' '<NUM-IDADE=' WS-SMALLINT(03) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl32 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl32 += " - ERRO NO SELECT NA SEGUROS.GE_PRODUTO_PREMIO. ";
                spl32 += "<COD-PRODUTO=";
                var spl33 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl33 += ">";
                spl33 += "<SEQ-PRODUTO-VRS=";
                var spl34 = WORK.WS_EDIT.WS_SMALLINT[02].GetMoveValues();
                spl34 += ">";
                spl34 += "<COD-OPC-COBERTURA=";
                var spl35 = GE0071W.LK_0071_I_COD_OPC_COBERTURA.GetMoveValues();
                spl35 += ">";
                spl35 += "<COD-IND-CONJUGE=";
                var spl36 = GE0071W.LK_0071_I_IND_CONJUGE.GetMoveValues();
                spl36 += ">";
                spl36 += "<NUM-IDADE=";
                var spl37 = WORK.WS_EDIT.WS_SMALLINT[03].GetMoveValues();
                spl37 += ">";
                var results38 = spl32 + spl33 + spl34 + spl35 + spl36 + spl37;
                _.Move(results38, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -663- MOVE 'SEGUROS.GE_PRODUTO_PREMIO' TO WS-TABELA */
                _.Move("SEGUROS.GE_PRODUTO_PREMIO", WORK.WS_ERRO.WS_TABELA);

                /*" -664- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -665- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -666- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -667- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -669- END-IF */
            }


            /*" -670- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -671- MOVE 'P0201' TO WS-SECTION */
                _.Move("P0201", WORK.WS_ERRO.WS_SECTION);

                /*" -672- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -681- STRING WS-SECTION ' - NAO ENCONTRADO PREMIO PARA OS PARAMETROS INFORMA' 'DOS. ' '<COD-PRODUTO=' WS-SMALLINT(01) '>' '<SEQ-PRODUTO-VRS=' WS-SMALLINT(02) '>' '<COD-OPC-COBERTURA=' LK-0071-I-COD-OPC-COBERTURA '>' '<COD-IND-CONJUGE=' LK-0071-I-IND-CONJUGE '>' '<NUM-IDADE=' WS-SMALLINT(03) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl38 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl38 += " - NAO ENCONTRADO PREMIO PARA OS PARAMETROS INFORMA";
                spl38 += "DOS. ";
                spl38 += "<COD-PRODUTO=";
                var spl39 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl39 += ">";
                spl39 += "<SEQ-PRODUTO-VRS=";
                var spl40 = WORK.WS_EDIT.WS_SMALLINT[02].GetMoveValues();
                spl40 += ">";
                spl40 += "<COD-OPC-COBERTURA=";
                var spl41 = GE0071W.LK_0071_I_COD_OPC_COBERTURA.GetMoveValues();
                spl41 += ">";
                spl41 += "<COD-IND-CONJUGE=";
                var spl42 = GE0071W.LK_0071_I_IND_CONJUGE.GetMoveValues();
                spl42 += ">";
                spl42 += "<NUM-IDADE=";
                var spl43 = WORK.WS_EDIT.WS_SMALLINT[03].GetMoveValues();
                spl43 += ">";
                var results44 = spl38 + spl39 + spl40 + spl41 + spl42 + spl43;
                _.Move(results44, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -683- MOVE 'SEGUROS.GE_PRODUTO_PREMIO' TO WS-TABELA */
                _.Move("SEGUROS.GE_PRODUTO_PREMIO", WORK.WS_ERRO.WS_TABELA);

                /*" -684- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -685- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -686- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -687- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -689- END-IF */
            }


            /*" -691- MOVE GE090-COD-OPC-COBERTURA TO LK-0071-I-COD-OPC-COBERTURA */
            _.Move(GE090.DCLGE_PRODUTO_PREMIO.GE090_COD_OPC_COBERTURA, GE0071W.LK_0071_I_COD_OPC_COBERTURA);

            /*" -693- MOVE GE090-COD-OPC-PLANO TO LK-0071-I-COD-OPC-PLANO */
            _.Move(GE090.DCLGE_PRODUTO_PREMIO.GE090_COD_OPC_PLANO, GE0071W.LK_0071_I_COD_OPC_PLANO);

            /*" -694- MOVE GE090-NUM-IDADE-INI TO LK-0071-S-NUM-IDADE-INI */
            _.Move(GE090.DCLGE_PRODUTO_PREMIO.GE090_NUM_IDADE_INI, GE0071W.LK_0071_S_NUM_IDADE_INI);

            /*" -695- MOVE GE090-NUM-IDADE-FIM TO LK-0071-S-NUM-IDADE-FIM */
            _.Move(GE090.DCLGE_PRODUTO_PREMIO.GE090_NUM_IDADE_FIM, GE0071W.LK_0071_S_NUM_IDADE_FIM);

            /*" -696- MOVE GE090-VLR-INI-PREMIO TO LK-0071-S-VLR-INI-PREMIO */
            _.Move(GE090.DCLGE_PRODUTO_PREMIO.GE090_VLR_INI_PREMIO, GE0071W.LK_0071_S_VLR_INI_PREMIO);

            /*" -697- MOVE GE090-VLR-FIM-PREMIO TO LK-0071-S-VLR-FIM-PREMIO */
            _.Move(GE090.DCLGE_PRODUTO_PREMIO.GE090_VLR_FIM_PREMIO, GE0071W.LK_0071_S_VLR_FIM_PREMIO);

            /*" -698- MOVE GE090-PCT-IOF TO LK-0071-S-PCT-IOF */
            _.Move(GE090.DCLGE_PRODUTO_PREMIO.GE090_PCT_IOF, GE0071W.LK_0071_S_PCT_IOF);

            /*" -700- MOVE GE090-PCT-REENQUADRAMENTO TO LK-0071-S-PCT-REENQUADRAMENTO */
            _.Move(GE090.DCLGE_PRODUTO_PREMIO.GE090_PCT_REENQUADRAMENTO, GE0071W.LK_0071_S_PCT_REENQUADRAMENTO);

            /*" -703- MOVE GE090-IND-PERMIT-VENDA TO LK-0071-S-IND-PERMIT-VENDA */
            _.Move(GE090.DCLGE_PRODUTO_PREMIO.GE090_IND_PERMIT_VENDA, GE0071W.LK_0071_S_IND_PERMIT_VENDA);

            /*" -703- . */

        }

        [StopWatch]
        /*" P0201-05-INICIO-DB-SELECT-1 */
        public void P0201_05_INICIO_DB_SELECT_1()
        {
            /*" -648- EXEC SQL SELECT COD_OPC_COBERTURA ,NUM_IDADE_INI ,NUM_IDADE_FIM ,COD_OPC_PLANO ,VLR_INI_PREMIO ,VLR_FIM_PREMIO ,PCT_IOF ,PCT_REENQUADRAMENTO ,IND_PERMIT_VENDA INTO :GE090-COD-OPC-COBERTURA ,:GE090-NUM-IDADE-INI ,:GE090-NUM-IDADE-FIM ,:GE090-COD-OPC-PLANO ,:GE090-VLR-INI-PREMIO ,:GE090-VLR-FIM-PREMIO ,:GE090-PCT-IOF ,:GE090-PCT-REENQUADRAMENTO ,:GE090-IND-PERMIT-VENDA FROM SEGUROS.GE_PRODUTO_PREMIO WHERE COD_PRODUTO = :GE090-COD-PRODUTO AND SEQ_PRODUTO_VRS = :GE090-SEQ-PRODUTO-VRS AND COD_OPC_COBERTURA = :GE090-COD-OPC-COBERTURA AND IND_CONJUGE = :GE090-IND-CONJUGE AND :GE090-NUM-IDADE-INI BETWEEN NUM_IDADE_INI AND NUM_IDADE_FIM WITH UR END-EXEC. */

            var p0201_05_INICIO_DB_SELECT_1_Query1 = new P0201_05_INICIO_DB_SELECT_1_Query1()
            {
                GE090_COD_OPC_COBERTURA = GE090.DCLGE_PRODUTO_PREMIO.GE090_COD_OPC_COBERTURA.ToString(),
                GE090_SEQ_PRODUTO_VRS = GE090.DCLGE_PRODUTO_PREMIO.GE090_SEQ_PRODUTO_VRS.ToString(),
                GE090_NUM_IDADE_INI = GE090.DCLGE_PRODUTO_PREMIO.GE090_NUM_IDADE_INI.ToString(),
                GE090_COD_PRODUTO = GE090.DCLGE_PRODUTO_PREMIO.GE090_COD_PRODUTO.ToString(),
                GE090_IND_CONJUGE = GE090.DCLGE_PRODUTO_PREMIO.GE090_IND_CONJUGE.ToString(),
            };

            var executed_1 = P0201_05_INICIO_DB_SELECT_1_Query1.Execute(p0201_05_INICIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE090_COD_OPC_COBERTURA, GE090.DCLGE_PRODUTO_PREMIO.GE090_COD_OPC_COBERTURA);
                _.Move(executed_1.GE090_NUM_IDADE_INI, GE090.DCLGE_PRODUTO_PREMIO.GE090_NUM_IDADE_INI);
                _.Move(executed_1.GE090_NUM_IDADE_FIM, GE090.DCLGE_PRODUTO_PREMIO.GE090_NUM_IDADE_FIM);
                _.Move(executed_1.GE090_COD_OPC_PLANO, GE090.DCLGE_PRODUTO_PREMIO.GE090_COD_OPC_PLANO);
                _.Move(executed_1.GE090_VLR_INI_PREMIO, GE090.DCLGE_PRODUTO_PREMIO.GE090_VLR_INI_PREMIO);
                _.Move(executed_1.GE090_VLR_FIM_PREMIO, GE090.DCLGE_PRODUTO_PREMIO.GE090_VLR_FIM_PREMIO);
                _.Move(executed_1.GE090_PCT_IOF, GE090.DCLGE_PRODUTO_PREMIO.GE090_PCT_IOF);
                _.Move(executed_1.GE090_PCT_REENQUADRAMENTO, GE090.DCLGE_PRODUTO_PREMIO.GE090_PCT_REENQUADRAMENTO);
                _.Move(executed_1.GE090_IND_PERMIT_VENDA, GE090.DCLGE_PRODUTO_PREMIO.GE090_IND_PERMIT_VENDA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0201_99_EXIT*/

        [StopWatch]
        /*" P0202-PESQUISAR-PROD-PRM-OPL-SECTION */
        private void P0202_PESQUISAR_PROD_PRM_OPL_SECTION()
        {
            /*" -715- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0202_00_START */

            P0202_00_START();

        }

        [StopWatch]
        /*" P0202-00-START */
        private void P0202_00_START(bool isPerform = false)
        {
            /*" -719- MOVE 'P0202' TO WS-SECTION */
            _.Move("P0202", WORK.WS_ERRO.WS_SECTION);

            /*" -721- MOVE LK-0071-I-COD-PRODUTO TO GE090-COD-PRODUTO WS-SMALLINT(01) */
            _.Move(GE0071W.LK_0071_I_COD_PRODUTO, GE090.DCLGE_PRODUTO_PREMIO.GE090_COD_PRODUTO, WORK.WS_EDIT.WS_SMALLINT[01]);

            /*" -723- MOVE LK-0071-I-SEQ-PRODUTO-VRS TO GE090-SEQ-PRODUTO-VRS WS-SMALLINT(02) */
            _.Move(GE0071W.LK_0071_I_SEQ_PRODUTO_VRS, GE090.DCLGE_PRODUTO_PREMIO.GE090_SEQ_PRODUTO_VRS, WORK.WS_EDIT.WS_SMALLINT[02]);

            /*" -725- MOVE LK-0071-I-COD-OPC-PLANO TO GE090-COD-OPC-PLANO WS-SMALLINT(03) */
            _.Move(GE0071W.LK_0071_I_COD_OPC_PLANO, GE090.DCLGE_PRODUTO_PREMIO.GE090_COD_OPC_PLANO, WORK.WS_EDIT.WS_SMALLINT[03]);

            /*" -726- MOVE LK-0071-I-IND-CONJUGE TO GE090-IND-CONJUGE */
            _.Move(GE0071W.LK_0071_I_IND_CONJUGE, GE090.DCLGE_PRODUTO_PREMIO.GE090_IND_CONJUGE);

            /*" -729- MOVE LK-0071-I-NUM-IDADE TO GE090-NUM-IDADE-INI WS-SMALLINT(04) */
            _.Move(GE0071W.LK_0071_I_NUM_IDADE, GE090.DCLGE_PRODUTO_PREMIO.GE090_NUM_IDADE_INI, WORK.WS_EDIT.WS_SMALLINT[04]);

            /*" -729- PERFORM P0202-05-INICIO */

            P0202_05_INICIO(true);

        }

        [StopWatch]
        /*" P0202-05-INICIO */
        private void P0202_05_INICIO(bool isPerform = false)
        {
            /*" -760- PERFORM P0202_05_INICIO_DB_SELECT_1 */

            P0202_05_INICIO_DB_SELECT_1();

            /*" -763- IF NOT ( SQLCODE = 0 OR = 100 ) */

            if (!(DB.SQLCODE.In("0", "100")))
            {

                /*" -764- MOVE 'P0202' TO WS-SECTION */
                _.Move("P0202", WORK.WS_ERRO.WS_SECTION);

                /*" -765- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -773- STRING WS-SECTION ' - ERRO NO SELECT NA SEGUROS.GE_PRODUTO_PREMIO. ' '<COD-PRODUTO=' WS-SMALLINT(01) '>' '<SEQ-PRODUTO-VRS=' WS-SMALLINT(02) '>' '<COD-OPC-PLANO=' WS-SMALLINT(03) '>' '<IND-CONJUGE=' LK-0071-I-IND-CONJUGE '>' '<NUM-IDADE=' WS-SMALLINT(04) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl44 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl44 += " - ERRO NO SELECT NA SEGUROS.GE_PRODUTO_PREMIO. ";
                spl44 += "<COD-PRODUTO=";
                var spl45 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl45 += ">";
                spl45 += "<SEQ-PRODUTO-VRS=";
                var spl46 = WORK.WS_EDIT.WS_SMALLINT[02].GetMoveValues();
                spl46 += ">";
                spl46 += "<COD-OPC-PLANO=";
                var spl47 = WORK.WS_EDIT.WS_SMALLINT[03].GetMoveValues();
                spl47 += ">";
                spl47 += "<IND-CONJUGE=";
                var spl48 = GE0071W.LK_0071_I_IND_CONJUGE.GetMoveValues();
                spl48 += ">";
                spl48 += "<NUM-IDADE=";
                var spl49 = WORK.WS_EDIT.WS_SMALLINT[04].GetMoveValues();
                spl49 += ">";
                var results50 = spl44 + spl45 + spl46 + spl47 + spl48 + spl49;
                _.Move(results50, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -775- MOVE 'SEGUROS.GE_PRODUTO_PREMIO' TO WS-TABELA */
                _.Move("SEGUROS.GE_PRODUTO_PREMIO", WORK.WS_ERRO.WS_TABELA);

                /*" -776- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -777- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -778- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -779- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -781- END-IF */
            }


            /*" -782- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -783- MOVE 'P0202' TO WS-SECTION */
                _.Move("P0202", WORK.WS_ERRO.WS_SECTION);

                /*" -784- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -793- STRING WS-SECTION ' - NAO ENCONTRADO PREMIO PARA OS PARAMETROS INFORMA' 'DOS. ' '<COD-PRODUTO=' WS-SMALLINT(01) '>' '<SEQ-PRODUTO-VRS=' WS-SMALLINT(02) '>' '<COD-OPC-PLANO=' WS-SMALLINT(03) '>' '<IND-CONJUGE=' LK-0071-I-IND-CONJUGE '>' '<NUM-IDADE=' WS-SMALLINT(04) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl50 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl50 += " - NAO ENCONTRADO PREMIO PARA OS PARAMETROS INFORMA";
                spl50 += "DOS. ";
                spl50 += "<COD-PRODUTO=";
                var spl51 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl51 += ">";
                spl51 += "<SEQ-PRODUTO-VRS=";
                var spl52 = WORK.WS_EDIT.WS_SMALLINT[02].GetMoveValues();
                spl52 += ">";
                spl52 += "<COD-OPC-PLANO=";
                var spl53 = WORK.WS_EDIT.WS_SMALLINT[03].GetMoveValues();
                spl53 += ">";
                spl53 += "<IND-CONJUGE=";
                var spl54 = GE0071W.LK_0071_I_IND_CONJUGE.GetMoveValues();
                spl54 += ">";
                spl54 += "<NUM-IDADE=";
                var spl55 = WORK.WS_EDIT.WS_SMALLINT[04].GetMoveValues();
                spl55 += ">";
                var results56 = spl50 + spl51 + spl52 + spl53 + spl54 + spl55;
                _.Move(results56, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -795- MOVE 'SEGUROS.GE_PRODUTO_PREMIO' TO WS-TABELA */
                _.Move("SEGUROS.GE_PRODUTO_PREMIO", WORK.WS_ERRO.WS_TABELA);

                /*" -796- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -797- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -798- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -799- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -801- END-IF */
            }


            /*" -803- MOVE GE090-COD-OPC-COBERTURA TO LK-0071-I-COD-OPC-COBERTURA */
            _.Move(GE090.DCLGE_PRODUTO_PREMIO.GE090_COD_OPC_COBERTURA, GE0071W.LK_0071_I_COD_OPC_COBERTURA);

            /*" -805- MOVE GE090-COD-OPC-PLANO TO LK-0071-I-COD-OPC-PLANO */
            _.Move(GE090.DCLGE_PRODUTO_PREMIO.GE090_COD_OPC_PLANO, GE0071W.LK_0071_I_COD_OPC_PLANO);

            /*" -806- MOVE GE090-NUM-IDADE-INI TO LK-0071-S-NUM-IDADE-INI */
            _.Move(GE090.DCLGE_PRODUTO_PREMIO.GE090_NUM_IDADE_INI, GE0071W.LK_0071_S_NUM_IDADE_INI);

            /*" -807- MOVE GE090-NUM-IDADE-FIM TO LK-0071-S-NUM-IDADE-FIM */
            _.Move(GE090.DCLGE_PRODUTO_PREMIO.GE090_NUM_IDADE_FIM, GE0071W.LK_0071_S_NUM_IDADE_FIM);

            /*" -808- MOVE GE090-VLR-INI-PREMIO TO LK-0071-S-VLR-INI-PREMIO */
            _.Move(GE090.DCLGE_PRODUTO_PREMIO.GE090_VLR_INI_PREMIO, GE0071W.LK_0071_S_VLR_INI_PREMIO);

            /*" -809- MOVE GE090-VLR-FIM-PREMIO TO LK-0071-S-VLR-FIM-PREMIO */
            _.Move(GE090.DCLGE_PRODUTO_PREMIO.GE090_VLR_FIM_PREMIO, GE0071W.LK_0071_S_VLR_FIM_PREMIO);

            /*" -810- MOVE GE090-PCT-IOF TO LK-0071-S-PCT-IOF */
            _.Move(GE090.DCLGE_PRODUTO_PREMIO.GE090_PCT_IOF, GE0071W.LK_0071_S_PCT_IOF);

            /*" -812- MOVE GE090-PCT-REENQUADRAMENTO TO LK-0071-S-PCT-REENQUADRAMENTO */
            _.Move(GE090.DCLGE_PRODUTO_PREMIO.GE090_PCT_REENQUADRAMENTO, GE0071W.LK_0071_S_PCT_REENQUADRAMENTO);

            /*" -815- MOVE GE090-IND-PERMIT-VENDA TO LK-0071-S-IND-PERMIT-VENDA */
            _.Move(GE090.DCLGE_PRODUTO_PREMIO.GE090_IND_PERMIT_VENDA, GE0071W.LK_0071_S_IND_PERMIT_VENDA);

            /*" -815- . */

        }

        [StopWatch]
        /*" P0202-05-INICIO-DB-SELECT-1 */
        public void P0202_05_INICIO_DB_SELECT_1()
        {
            /*" -760- EXEC SQL SELECT COD_OPC_COBERTURA ,NUM_IDADE_INI ,NUM_IDADE_FIM ,COD_OPC_PLANO ,VLR_INI_PREMIO ,VLR_FIM_PREMIO ,PCT_IOF ,PCT_REENQUADRAMENTO ,IND_PERMIT_VENDA INTO :GE090-COD-OPC-COBERTURA ,:GE090-NUM-IDADE-INI ,:GE090-NUM-IDADE-FIM ,:GE090-COD-OPC-PLANO ,:GE090-VLR-INI-PREMIO ,:GE090-VLR-FIM-PREMIO ,:GE090-PCT-IOF ,:GE090-PCT-REENQUADRAMENTO ,:GE090-IND-PERMIT-VENDA FROM SEGUROS.GE_PRODUTO_PREMIO WHERE COD_PRODUTO = :GE090-COD-PRODUTO AND SEQ_PRODUTO_VRS = :GE090-SEQ-PRODUTO-VRS AND COD_OPC_PLANO = :GE090-COD-OPC-PLANO AND IND_CONJUGE = :GE090-IND-CONJUGE AND :GE090-NUM-IDADE-INI BETWEEN NUM_IDADE_INI AND NUM_IDADE_FIM WITH UR END-EXEC. */

            var p0202_05_INICIO_DB_SELECT_1_Query1 = new P0202_05_INICIO_DB_SELECT_1_Query1()
            {
                GE090_SEQ_PRODUTO_VRS = GE090.DCLGE_PRODUTO_PREMIO.GE090_SEQ_PRODUTO_VRS.ToString(),
                GE090_COD_OPC_PLANO = GE090.DCLGE_PRODUTO_PREMIO.GE090_COD_OPC_PLANO.ToString(),
                GE090_NUM_IDADE_INI = GE090.DCLGE_PRODUTO_PREMIO.GE090_NUM_IDADE_INI.ToString(),
                GE090_COD_PRODUTO = GE090.DCLGE_PRODUTO_PREMIO.GE090_COD_PRODUTO.ToString(),
                GE090_IND_CONJUGE = GE090.DCLGE_PRODUTO_PREMIO.GE090_IND_CONJUGE.ToString(),
            };

            var executed_1 = P0202_05_INICIO_DB_SELECT_1_Query1.Execute(p0202_05_INICIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE090_COD_OPC_COBERTURA, GE090.DCLGE_PRODUTO_PREMIO.GE090_COD_OPC_COBERTURA);
                _.Move(executed_1.GE090_NUM_IDADE_INI, GE090.DCLGE_PRODUTO_PREMIO.GE090_NUM_IDADE_INI);
                _.Move(executed_1.GE090_NUM_IDADE_FIM, GE090.DCLGE_PRODUTO_PREMIO.GE090_NUM_IDADE_FIM);
                _.Move(executed_1.GE090_COD_OPC_PLANO, GE090.DCLGE_PRODUTO_PREMIO.GE090_COD_OPC_PLANO);
                _.Move(executed_1.GE090_VLR_INI_PREMIO, GE090.DCLGE_PRODUTO_PREMIO.GE090_VLR_INI_PREMIO);
                _.Move(executed_1.GE090_VLR_FIM_PREMIO, GE090.DCLGE_PRODUTO_PREMIO.GE090_VLR_FIM_PREMIO);
                _.Move(executed_1.GE090_PCT_IOF, GE090.DCLGE_PRODUTO_PREMIO.GE090_PCT_IOF);
                _.Move(executed_1.GE090_PCT_REENQUADRAMENTO, GE090.DCLGE_PRODUTO_PREMIO.GE090_PCT_REENQUADRAMENTO);
                _.Move(executed_1.GE090_IND_PERMIT_VENDA, GE090.DCLGE_PRODUTO_PREMIO.GE090_IND_PERMIT_VENDA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0202_99_EXIT*/

        [StopWatch]
        /*" P0205-PESQUISAR-PREMIO-COBER-SECTION */
        private void P0205_PESQUISAR_PREMIO_COBER_SECTION()
        {
            /*" -827- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0205_00_START */

            P0205_00_START();

        }

        [StopWatch]
        /*" P0205-00-START */
        private void P0205_00_START(bool isPerform = false)
        {
            /*" -831- MOVE 'P0205' TO WS-SECTION */
            _.Move("P0205", WORK.WS_ERRO.WS_SECTION);

            /*" -832- MOVE 0 TO WI */
            _.Move(0, WORK.WS_CONTADORES.WI);

            /*" -834- MOVE GE090-COD-PRODUTO TO GE091-COD-PRODUTO WS-SMALLINT(01) */
            _.Move(GE090.DCLGE_PRODUTO_PREMIO.GE090_COD_PRODUTO, GE091.DCLGE_PROD_PREMIO_COBER.GE091_COD_PRODUTO, WORK.WS_EDIT.WS_SMALLINT[01]);

            /*" -836- MOVE GE090-SEQ-PRODUTO-VRS TO GE091-SEQ-PRODUTO-VRS WS-SMALLINT(02) */
            _.Move(GE090.DCLGE_PRODUTO_PREMIO.GE090_SEQ_PRODUTO_VRS, GE091.DCLGE_PROD_PREMIO_COBER.GE091_SEQ_PRODUTO_VRS, WORK.WS_EDIT.WS_SMALLINT[02]);

            /*" -837- MOVE GE090-COD-OPC-COBERTURA TO GE091-COD-OPC-COBERTURA */
            _.Move(GE090.DCLGE_PRODUTO_PREMIO.GE090_COD_OPC_COBERTURA, GE091.DCLGE_PROD_PREMIO_COBER.GE091_COD_OPC_COBERTURA);

            /*" -838- MOVE GE090-IND-CONJUGE TO GE091-IND-CONJUGE */
            _.Move(GE090.DCLGE_PRODUTO_PREMIO.GE090_IND_CONJUGE, GE091.DCLGE_PROD_PREMIO_COBER.GE091_IND_CONJUGE);

            /*" -841- MOVE GE090-NUM-IDADE-INI TO GE091-NUM-IDADE-INI WS-SMALLINT(03) */
            _.Move(GE090.DCLGE_PRODUTO_PREMIO.GE090_NUM_IDADE_INI, GE091.DCLGE_PROD_PREMIO_COBER.GE091_NUM_IDADE_INI, WORK.WS_EDIT.WS_SMALLINT[03]);

            /*" -843- PERFORM P8001-OPEN-CURSOR-GE0071S-C01 */

            P8001_OPEN_CURSOR_GE0071S_C01_SECTION();

            /*" -843- . */

        }

        [StopWatch]
        /*" P0205-05-INICIO */
        private void P0205_05_INICIO(bool isPerform = false)
        {
            /*" -858- PERFORM P0205_05_INICIO_DB_FETCH_1 */

            P0205_05_INICIO_DB_FETCH_1();

            /*" -861- IF NOT ( SQLCODE = 0 OR = 100 ) */

            if (!(DB.SQLCODE.In("0", "100")))
            {

                /*" -862- MOVE 'P0205' TO WS-SECTION */
                _.Move("P0205", WORK.WS_ERRO.WS_SECTION);

                /*" -863- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -871- STRING WS-SECTION ' - ERRO NO FETCH CURSOR GE0071S_C01. ' '<COD-PRODUTO=' WS-SMALLINT(01) '>' '<SEQ-PRODUTO-VRS=' WS-SMALLINT(02) '>' '<COD-OPC-COBERTURA=' GE091-COD-OPC-COBERTURA '>' '<IND-CONJUGE=' GE091-IND-CONJUGE '>' '<NUM-IDADE-INI=' WS-SMALLINT(03) DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl56 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl56 += " - ERRO NO FETCH CURSOR GE0071S_C01. ";
                spl56 += "<COD-PRODUTO=";
                var spl57 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl57 += ">";
                spl57 += "<SEQ-PRODUTO-VRS=";
                var spl58 = WORK.WS_EDIT.WS_SMALLINT[02].GetMoveValues();
                spl58 += ">";
                spl58 += "<COD-OPC-COBERTURA=";
                var spl59 = GE091.DCLGE_PROD_PREMIO_COBER.GE091_COD_OPC_COBERTURA.GetMoveValues();
                spl59 += ">";
                spl59 += "<IND-CONJUGE=";
                var spl60 = GE091.DCLGE_PROD_PREMIO_COBER.GE091_IND_CONJUGE.GetMoveValues();
                spl60 += ">";
                spl60 += "<NUM-IDADE-INI=";
                var spl61 = WORK.WS_EDIT.WS_SMALLINT[03].GetMoveValues();
                var results62 = spl56 + spl57 + spl58 + spl59 + spl60 + spl61;
                _.Move(results62, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -873- MOVE 'SEGUROS.GE_PROD_PREMIO_COBER' TO WS-TABELA */
                _.Move("SEGUROS.GE_PROD_PREMIO_COBER", WORK.WS_ERRO.WS_TABELA);

                /*" -874- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -875- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -876- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -877- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -879- END-IF */
            }


            /*" -880- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -881- PERFORM P8002-CLOSE-CURSOR-GE0071S-C01 */

                P8002_CLOSE_CURSOR_GE0071S_C01_SECTION();

                /*" -882- GO TO P0205-99-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P0205_99_EXIT*/ //GOTO
                return;

                /*" -884- END-IF */
            }


            /*" -885- ADD 1 TO WI */
            WORK.WS_CONTADORES.WI.Value = WORK.WS_CONTADORES.WI + 1;

            /*" -886- IF WI > 30 */

            if (WORK.WS_CONTADORES.WI > 30)
            {

                /*" -887- MOVE 'P0205' TO WS-SECTION */
                _.Move("P0205", WORK.WS_ERRO.WS_SECTION);

                /*" -888- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -889- MOVE WI TO WS-SMALLINT(04) */
                _.Move(WORK.WS_CONTADORES.WI, WORK.WS_EDIT.WS_SMALLINT[04]);

                /*" -898- STRING WS-SECTION ' - ERRO NO FETCH CURSOR GE0071S_C01. ' '<COD-PRODUTO=' WS-SMALLINT(01) '>' '<SEQ-PRODUTO-VRS=' WS-SMALLINT(02) '>' '<COD-OPC-COBERTURA=' GE091-COD-OPC-COBERTURA '>' '<IND-CONJUGE=' GE091-IND-CONJUGE '>' '<NUM-IDADE-INI=' WS-SMALLINT(03) '>' '<QTD-OCORRENCIAS=' WS-SMALLINT(04) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl62 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl62 += " - ERRO NO FETCH CURSOR GE0071S_C01. ";
                spl62 += "<COD-PRODUTO=";
                var spl63 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl63 += ">";
                spl63 += "<SEQ-PRODUTO-VRS=";
                var spl64 = WORK.WS_EDIT.WS_SMALLINT[02].GetMoveValues();
                spl64 += ">";
                spl64 += "<COD-OPC-COBERTURA=";
                var spl65 = GE091.DCLGE_PROD_PREMIO_COBER.GE091_COD_OPC_COBERTURA.GetMoveValues();
                spl65 += ">";
                spl65 += "<IND-CONJUGE=";
                var spl66 = GE091.DCLGE_PROD_PREMIO_COBER.GE091_IND_CONJUGE.GetMoveValues();
                spl66 += ">";
                spl66 += "<NUM-IDADE-INI=";
                var spl67 = WORK.WS_EDIT.WS_SMALLINT[03].GetMoveValues();
                spl67 += ">";
                spl67 += "<QTD-OCORRENCIAS=";
                var spl68 = WORK.WS_EDIT.WS_SMALLINT[04].GetMoveValues();
                spl68 += ">";
                var results69 = spl62 + spl63 + spl64 + spl65 + spl66 + spl67 + spl68;
                _.Move(results69, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -900- MOVE 'SEGUROS.GE_PROD_PREMIO_COBER' TO WS-TABELA */
                _.Move("SEGUROS.GE_PROD_PREMIO_COBER", WORK.WS_ERRO.WS_TABELA);

                /*" -901- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -902- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -903- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -904- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -906- END-IF */
            }


            /*" -907- MOVE WI TO LK-0071-S-QTD-OCC */
            _.Move(WORK.WS_CONTADORES.WI, GE0071W.LK_0071_S_QTD_OCC);

            /*" -909- MOVE GE091-COD-COBERTURA TO LK-0071-S-A-COD-COBERTURA(WI) */
            _.Move(GE091.DCLGE_PROD_PREMIO_COBER.GE091_COD_COBERTURA, GE0071W.LK_0071_S_ARR.LK_0071_S_ARR_OCC[WORK.WS_CONTADORES.WI].LK_0071_S_A_COD_COBERTURA);

            /*" -911- MOVE GE091-VLR-IS TO LK-0071-S-A-VLR-IS(WI) LK-0071-S-VLR-TOTAL-IS */
            _.Move(GE091.DCLGE_PROD_PREMIO_COBER.GE091_VLR_IS, GE0071W.LK_0071_S_ARR.LK_0071_S_ARR_OCC[WORK.WS_CONTADORES.WI].LK_0071_S_A_VLR_IS, GE0071W.LK_0071_S_VLR_TOTAL_IS);

            /*" -913- MOVE GE091-VLR-PREMIO TO LK-0071-S-A-VLR-PREMIO(WI) */
            _.Move(GE091.DCLGE_PROD_PREMIO_COBER.GE091_VLR_PREMIO, GE0071W.LK_0071_S_ARR.LK_0071_S_ARR_OCC[WORK.WS_CONTADORES.WI].LK_0071_S_A_VLR_PREMIO);

            /*" -915- MOVE GE091-PCT-PARTICIPACAO TO LK-0071-S-A-PCT-PARTICIPACAO(WI) */
            _.Move(GE091.DCLGE_PROD_PREMIO_COBER.GE091_PCT_PARTICIPACAO, GE0071W.LK_0071_S_ARR.LK_0071_S_ARR_OCC[WORK.WS_CONTADORES.WI].LK_0071_S_A_PCT_PARTICIPACAO);

            /*" -917- MOVE GE118-IND-TIPO-COBERTURA TO LK-0071-S-A-IND-TP-COBER(WI) */
            _.Move(GE118.DCLGE_PRODUTO_COBERTURA.GE118_IND_TIPO_COBERTURA, GE0071W.LK_0071_S_ARR.LK_0071_S_ARR_OCC[WORK.WS_CONTADORES.WI].LK_0071_S_A_IND_TP_COBER);

            /*" -919- MOVE GE118-IND-SINISTRO-CANCELA TO LK-0071-S-A-IND-SINIS-CANC(WI) */
            _.Move(GE118.DCLGE_PRODUTO_COBERTURA.GE118_IND_SINISTRO_CANCELA, GE0071W.LK_0071_S_ARR.LK_0071_S_ARR_OCC[WORK.WS_CONTADORES.WI].LK_0071_S_A_IND_SINIS_CANC);

            /*" -921- MOVE GE118-IND-INDENIZA-MAIS-VEZES TO LK-0071-S-A-IND-INDNZ-MAISVEZ(WI) */
            _.Move(GE118.DCLGE_PRODUTO_COBERTURA.GE118_IND_INDENIZA_MAIS_VEZES, GE0071W.LK_0071_S_ARR.LK_0071_S_ARR_OCC[WORK.WS_CONTADORES.WI].LK_0071_S_A_IND_INDNZ_MAISVEZ);

            /*" -923- MOVE GE118-COD-RAMO-COBERTURA TO LK-0071-S-A-COD-RAMO-COBER(WI) */
            _.Move(GE118.DCLGE_PRODUTO_COBERTURA.GE118_COD_RAMO_COBERTURA, GE0071W.LK_0071_S_ARR.LK_0071_S_ARR_OCC[WORK.WS_CONTADORES.WI].LK_0071_S_A_COD_RAMO_COBER);

            /*" -926- MOVE GE118-DES-APRESENTA-DOC TO LK-0071-S-A-DES-APRES-DOC(WI) */
            _.Move(GE118.DCLGE_PRODUTO_COBERTURA.GE118_DES_APRESENTA_DOC, GE0071W.LK_0071_S_ARR.LK_0071_S_ARR_OCC[WORK.WS_CONTADORES.WI].LK_0071_S_A_DES_APRES_DOC);

            /*" -928- GO TO P0205-05-INICIO */
            new Task(() => P0205_05_INICIO()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

            /*" -928- . */

        }

        [StopWatch]
        /*" P0205-05-INICIO-DB-FETCH-1 */
        public void P0205_05_INICIO_DB_FETCH_1()
        {
            /*" -858- EXEC SQL FETCH GE0071S_C01 INTO :GE091-COD-COBERTURA ,:GE091-VLR-IS ,:GE091-VLR-PREMIO ,:GE091-PCT-PARTICIPACAO ,:GE118-IND-TIPO-COBERTURA ,:GE118-IND-SINISTRO-CANCELA ,:GE118-IND-INDENIZA-MAIS-VEZES ,:GE118-COD-RAMO-COBERTURA ,:GE118-DES-APRESENTA-DOC END-EXEC */

            if (GE0071S_C01.Fetch())
            {
                _.Move(GE0071S_C01.GE091_COD_COBERTURA, GE091.DCLGE_PROD_PREMIO_COBER.GE091_COD_COBERTURA);
                _.Move(GE0071S_C01.GE091_VLR_IS, GE091.DCLGE_PROD_PREMIO_COBER.GE091_VLR_IS);
                _.Move(GE0071S_C01.GE091_VLR_PREMIO, GE091.DCLGE_PROD_PREMIO_COBER.GE091_VLR_PREMIO);
                _.Move(GE0071S_C01.GE091_PCT_PARTICIPACAO, GE091.DCLGE_PROD_PREMIO_COBER.GE091_PCT_PARTICIPACAO);
                _.Move(GE0071S_C01.GE118_IND_TIPO_COBERTURA, GE118.DCLGE_PRODUTO_COBERTURA.GE118_IND_TIPO_COBERTURA);
                _.Move(GE0071S_C01.GE118_IND_SINISTRO_CANCELA, GE118.DCLGE_PRODUTO_COBERTURA.GE118_IND_SINISTRO_CANCELA);
                _.Move(GE0071S_C01.GE118_IND_INDENIZA_MAIS_VEZES, GE118.DCLGE_PRODUTO_COBERTURA.GE118_IND_INDENIZA_MAIS_VEZES);
                _.Move(GE0071S_C01.GE118_COD_RAMO_COBERTURA, GE118.DCLGE_PRODUTO_COBERTURA.GE118_COD_RAMO_COBERTURA);
                _.Move(GE0071S_C01.GE118_DES_APRESENTA_DOC, GE118.DCLGE_PRODUTO_COBERTURA.GE118_DES_APRESENTA_DOC);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0205_99_EXIT*/

        [StopWatch]
        /*" P8001-OPEN-CURSOR-GE0071S-C01-SECTION */
        private void P8001_OPEN_CURSOR_GE0071S_C01_SECTION()
        {
            /*" -939- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P8001_00_START */

            P8001_00_START();

        }

        [StopWatch]
        /*" P8001-00-START */
        private void P8001_00_START(bool isPerform = false)
        {
            /*" -943- MOVE 'P8001' TO WS-SECTION */
            _.Move("P8001", WORK.WS_ERRO.WS_SECTION);

            /*" -943- PERFORM P8001-05-INICIO */

            P8001_05_INICIO(true);

        }

        [StopWatch]
        /*" P8001-05-INICIO */
        private void P8001_05_INICIO(bool isPerform = false)
        {
            /*" -948- PERFORM P8001_05_INICIO_DB_OPEN_1 */

            P8001_05_INICIO_DB_OPEN_1();

            /*" -951- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -952- MOVE 'P8001' TO WS-SECTION */
                _.Move("P8001", WORK.WS_ERRO.WS_SECTION);

                /*" -953- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -956- STRING WS-SECTION ' - ERRO NO OPEN GE0071S_C01.' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl69 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl69 += " - ERRO NO OPEN GE0071S_C01.";
                _.Move(spl69, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -958- MOVE 'SEGUROS.GE_PROD_PREMIO_COBER' TO WS-TABELA */
                _.Move("SEGUROS.GE_PROD_PREMIO_COBER", WORK.WS_ERRO.WS_TABELA);

                /*" -959- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -960- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -961- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -962- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -964- END-IF */
            }


            /*" -964- . */

        }

        [StopWatch]
        /*" P8001-05-INICIO-DB-OPEN-1 */
        public void P8001_05_INICIO_DB_OPEN_1()
        {
            /*" -948- EXEC SQL OPEN GE0071S_C01 END-EXEC. */

            GE0071S_C01.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P8001_99_EXIT*/

        [StopWatch]
        /*" P8002-CLOSE-CURSOR-GE0071S-C01-SECTION */
        private void P8002_CLOSE_CURSOR_GE0071S_C01_SECTION()
        {
            /*" -976- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P8002_00_START */

            P8002_00_START();

        }

        [StopWatch]
        /*" P8002-00-START */
        private void P8002_00_START(bool isPerform = false)
        {
            /*" -980- MOVE 'P8002' TO WS-SECTION */
            _.Move("P8002", WORK.WS_ERRO.WS_SECTION);

            /*" -980- PERFORM P8002-05-INICIO */

            P8002_05_INICIO(true);

        }

        [StopWatch]
        /*" P8002-05-INICIO */
        private void P8002_05_INICIO(bool isPerform = false)
        {
            /*" -985- PERFORM P8002_05_INICIO_DB_CLOSE_1 */

            P8002_05_INICIO_DB_CLOSE_1();

            /*" -988- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -989- MOVE 'P8002' TO WS-SECTION */
                _.Move("P8002", WORK.WS_ERRO.WS_SECTION);

                /*" -990- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -993- STRING WS-SECTION ' - ERRO NO CLOSE GE0071S_C01.' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl70 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl70 += " - ERRO NO CLOSE GE0071S_C01.";
                _.Move(spl70, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -995- MOVE 'SEGUROS.GE_PROD_PREMIO_COBER' TO WS-TABELA */
                _.Move("SEGUROS.GE_PROD_PREMIO_COBER", WORK.WS_ERRO.WS_TABELA);

                /*" -996- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -997- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -998- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -999- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -1001- END-IF */
            }


            /*" -1001- . */

        }

        [StopWatch]
        /*" P8002-05-INICIO-DB-CLOSE-1 */
        public void P8002_05_INICIO_DB_CLOSE_1()
        {
            /*" -985- EXEC SQL CLOSE GE0071S_C01 END-EXEC. */

            GE0071S_C01.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P8002_99_EXIT*/

        [StopWatch]
        /*" P9999-ERRO-SECTION */
        private void P9999_ERRO_SECTION()
        {
            /*" -1014- DISPLAY '**********************************************' */
            _.Display($"**********************************************");

            /*" -1015- DISPLAY '*            E R R O   G E 0 0 7 1 S         *' */
            _.Display($"*            E R R O   G E 0 0 7 1 S         *");

            /*" -1016- DISPLAY '**********************************************' */
            _.Display($"**********************************************");

            /*" -1017- DISPLAY '* SECTION............: ' WS-SECTION */
            _.Display($"* SECTION............: {WORK.WS_ERRO.WS_SECTION}");

            /*" -1018- DISPLAY '* IND ERRO...........: ' WS-IND-ERRO */
            _.Display($"* IND ERRO...........: {WORK.WS_ERRO.WS_IND_ERRO}");

            /*" -1019- DISPLAY '* TABELA.............: ' WS-TABELA */
            _.Display($"* TABELA.............: {WORK.WS_ERRO.WS_TABELA}");

            /*" -1020- DISPLAY '* MENSAGEM...........: ' WS-MENSAGEM */
            _.Display($"* MENSAGEM...........: {WORK.WS_ERRO.WS_MENSAGEM}");

            /*" -1021- DISPLAY '* SQLCODE............: ' WS-SQLCODE */
            _.Display($"* SQLCODE............: {WORK.WS_ERRO.WS_SQLCODE}");

            /*" -1022- DISPLAY '* SQLERRMC...........: ' WS-SQLERRMC */
            _.Display($"* SQLERRMC...........: {WORK.WS_ERRO.WS_SQLERRMC}");

            /*" -1023- DISPLAY '* SQLSTATE...........: ' WS-SQLSTATE */
            _.Display($"* SQLSTATE...........: {WORK.WS_ERRO.WS_SQLSTATE}");

            /*" -1024- DISPLAY '**********************************************' */
            _.Display($"**********************************************");

            /*" -1025- DISPLAY '*             DADOS DE ENTRADA               *' */
            _.Display($"*             DADOS DE ENTRADA               *");

            /*" -1026- DISPLAY '**********************************************' */
            _.Display($"**********************************************");

            /*" -1027- DISPLAY '* TRACE..............: ' LK-0071-E-TRACE */
            _.Display($"* TRACE..............: {GE0071W.LK_0071_E_TRACE}");

            /*" -1028- DISPLAY '* COD-USUARIO........: ' LK-0071-E-COD-USUARIO */
            _.Display($"* COD-USUARIO........: {GE0071W.LK_0071_E_COD_USUARIO}");

            /*" -1029- DISPLAY '* NOM-PROGRAMA.......: ' LK-0071-E-NOM-PROGRAMA */
            _.Display($"* NOM-PROGRAMA.......: {GE0071W.LK_0071_E_NOM_PROGRAMA}");

            /*" -1030- MOVE LK-0071-E-ACAO TO WS-SMALLINT(01) */
            _.Move(GE0071W.LK_0071_E_ACAO, WORK.WS_EDIT.WS_SMALLINT[01]);

            /*" -1031- DISPLAY '* ACAO...............: ' WS-SMALLINT(01) */
            _.Display($"* ACAO...............: {WORK.WS_EDIT.WS_SMALLINT[1]}");

            /*" -1032- MOVE LK-0071-I-COD-PRODUTO TO WS-SMALLINT(01) */
            _.Move(GE0071W.LK_0071_I_COD_PRODUTO, WORK.WS_EDIT.WS_SMALLINT[01]);

            /*" -1033- DISPLAY '* COD-PRODUTO........: ' WS-SMALLINT(01) */
            _.Display($"* COD-PRODUTO........: {WORK.WS_EDIT.WS_SMALLINT[1]}");

            /*" -1034- MOVE LK-0071-I-SEQ-PRODUTO-VRS TO WS-SMALLINT(01) */
            _.Move(GE0071W.LK_0071_I_SEQ_PRODUTO_VRS, WORK.WS_EDIT.WS_SMALLINT[01]);

            /*" -1035- DISPLAY '* SEQ-PRODUTO-VRS....: ' WS-SMALLINT(01) */
            _.Display($"* SEQ-PRODUTO-VRS....: {WORK.WS_EDIT.WS_SMALLINT[1]}");

            /*" -1037- DISPLAY '* COD-OPC-COBERTURA..: ' LK-0071-I-COD-OPC-COBERTURA */
            _.Display($"* COD-OPC-COBERTURA..: {GE0071W.LK_0071_I_COD_OPC_COBERTURA}");

            /*" -1038- MOVE LK-0071-I-COD-OPC-PLANO TO WS-SMALLINT(01) */
            _.Move(GE0071W.LK_0071_I_COD_OPC_PLANO, WORK.WS_EDIT.WS_SMALLINT[01]);

            /*" -1039- DISPLAY '* COD-OPC-PLANO......: ' WS-SMALLINT(01) */
            _.Display($"* COD-OPC-PLANO......: {WORK.WS_EDIT.WS_SMALLINT[1]}");

            /*" -1040- DISPLAY '* IND-CONJUGE........: ' LK-0071-I-IND-CONJUGE */
            _.Display($"* IND-CONJUGE........: {GE0071W.LK_0071_I_IND_CONJUGE}");

            /*" -1041- MOVE LK-0071-I-NUM-IDADE TO WS-SMALLINT(01) */
            _.Move(GE0071W.LK_0071_I_NUM_IDADE, WORK.WS_EDIT.WS_SMALLINT[01]);

            /*" -1042- DISPLAY '* NUM-IDADE..........: ' WS-SMALLINT(01) */
            _.Display($"* NUM-IDADE..........: {WORK.WS_EDIT.WS_SMALLINT[1]}");

            /*" -1044- DISPLAY '**********************************************' */
            _.Display($"**********************************************");

            /*" -1045- MOVE WS-IND-ERRO TO LK-0071-IND-ERRO */
            _.Move(WORK.WS_ERRO.WS_IND_ERRO, GE0071W.LK_0071_S_ARR.LK_0071_IND_ERRO);

            /*" -1046- MOVE WS-MENSAGEM TO LK-0071-MSG-ERRO */
            _.Move(WORK.WS_ERRO.WS_MENSAGEM, GE0071W.LK_0071_S_ARR.LK_0071_MSG_ERRO);

            /*" -1047- MOVE WS-TABELA TO LK-0071-NOM-TABELA */
            _.Move(WORK.WS_ERRO.WS_TABELA, GE0071W.LK_0071_S_ARR.LK_0071_NOM_TABELA);

            /*" -1048- MOVE WS-SQLCODE TO LK-0071-SQLCODE */
            _.Move(WORK.WS_ERRO.WS_SQLCODE, GE0071W.LK_0071_S_ARR.LK_0071_SQLCODE);

            /*" -1049- MOVE WS-SQLERRMC TO LK-0071-SQLERRMC */
            _.Move(WORK.WS_ERRO.WS_SQLERRMC, GE0071W.LK_0071_S_ARR.LK_0071_SQLERRMC);

            /*" -1051- MOVE WS-SQLSTATE TO LK-0071-SQLSTATE */
            _.Move(WORK.WS_ERRO.WS_SQLSTATE, GE0071W.LK_0071_S_ARR.LK_0071_SQLSTATE);

            /*" -1051- . */

            /*" -0- FLUXCONTROL_PERFORM P9999_99_EXIT */

            P9999_99_EXIT();

        }

        [StopWatch]
        /*" P9999-99-EXIT */
        private void P9999_99_EXIT(bool isPerform = false)
        {
            /*" -1054- GOBACK. */

            throw new GoBack();

        }
    }
}