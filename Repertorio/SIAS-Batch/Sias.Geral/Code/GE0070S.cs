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
using Sias.Geral.DB2.GE0070S;

namespace Code
{
    public class GE0070S
    {
        public bool IsCall { get; set; }

        public GE0070S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      * SISTEMA.........: SIAS                                         *      */
        /*"      * MODULO..........: VIDA                                         *      */
        /*"      * PROGRAMA........: GE0070S                                      *      */
        /*"      * ANALISTA........: HUSNI ALI HUSNI                              *      */
        /*"      * DATA............: 12/04/2024                                   *      */
        /*"      * DEMANDA.........: 999999     TAREFA..........: 999999          *      */
        /*"      ******************************************************************      */
        /*"      * OBJETIVO........: TRATAR PARAMETRIZACAO DO PRODUTO             *      */
        /*"      *                   - SEGUROS.GE_PRODUTO_COMPLEMENTO             *      */
        /*"      *            ACOES:                                             *       */
        /*"      *              (01) PESQUISAR PARAMETRIZACAO PARA PRODUTO        *      */
        /*"      ******************************************************************      */
        /*"      * VERSAO     DATA     RESPONSAVEL      ALTERACAO                 *      */
        /*"      ******************************************************************      */
        /*"      * V001    12/04/2024  HUSNI ALI HUSNI  CRIACAO DO PROGGRAMA      *      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"01    WORK.*/
        public GE0070S_WORK WORK { get; set; } = new GE0070S_WORK();
        public class GE0070S_WORK : VarBasis
        {
            /*" 05   WS-PROGRAMA                    PIC  X(008) VALUE SPACES.*/
            public StringBasis WS_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*" 05   WS-CONTADORES.*/
            public GE0070S_WS_CONTADORES WS_CONTADORES { get; set; } = new GE0070S_WS_CONTADORES();
            public class GE0070S_WS_CONTADORES : VarBasis
            {
                /*"  10  WS-I                           PIC S9(004) COMP VALUE 0.*/
                public IntBasis WS_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*" 05   WS-DATAS.*/
            }
            public GE0070S_WS_DATAS WS_DATAS { get; set; } = new GE0070S_WS_DATAS();
            public class GE0070S_WS_DATAS : VarBasis
            {
                /*"  10  WS-C-DATE-CURRENT              PIC  X(014) VALUE SPACES.*/
                public StringBasis WS_C_DATE_CURRENT { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
                /*"  10  WS-C-DATE-COMPILED             PIC  X(014) VALUE SPACES.*/
                public StringBasis WS_C_DATE_COMPILED { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
                /*"  05  WS-DATA-AMD.*/
                public GE0070S_WS_DATA_AMD WS_DATA_AMD { get; set; } = new GE0070S_WS_DATA_AMD();
                public class GE0070S_WS_DATA_AMD : VarBasis
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
            public GE0070S_WS_EDIT WS_EDIT { get; set; } = new GE0070S_WS_EDIT();
            public class GE0070S_WS_EDIT : VarBasis
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
            public GE0070S_WS_ERRO WS_ERRO { get; set; } = new GE0070S_WS_ERRO();
            public class GE0070S_WS_ERRO : VarBasis
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
        public Copies.GE0070W GE0070W { get; set; } = new Copies.GE0070W();
        public Dclgens.GE089 GE089 { get; set; } = new Dclgens.GE089();
        public Dclgens.PRODUTO PRODUTO { get; set; } = new Dclgens.PRODUTO();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(GE0070W GE0070W_P) //PROCEDURE DIVISION USING 
        /*PROCEDURE DIVISION
        LK_0070_E_TRACE
        LK_0070_E_COD_USUARIO
        LK_0070_E_NOM_PROGRAMA
        LK_0070_E_ACAO
        LK_0070_I_COD_PRODUTO
        LK_0070_I_SEQ_PRODUTO_VRS
        LK_0070_I_DTA_PROPOSTA
        LK_0070_S_DTA_INI_VIGENCIA
        LK_0070_S_DTA_FIM_VIGENCIA
        LK_0070_S_IND_FLUXO_PARAM
        LK_0070_S_COD_PERIOD_VIGENCIA
        LK_0070_S_QTD_PERIOD_VIGENCIA
        LK_0070_S_COD_MOEDA
        LK_0070_S_IND_RENOVA
        LK_0070_S_IND_RENOVA_AUTOMAT
        LK_0070_S_QTD_RENOVA_AUTOMAT
        LK_0070_S_IND_DPS
        LK_0070_S_IND_REENQUADRA_PREM
        LK_0070_S_IND_REAJUSTE_PREMIO
        LK_0070_S_COD_INDICE_REAJUSTE
        LK_0070_S_COD_PERIOD_REAJUSTE
        LK_0070_S_COD_INDC_DEVOLUCAO
        LK_0070_S_PCT_JUROS_DEVOLUCAO
        LK_0070_S_PCT_MULTA_DEVOLUCAO
        LK_0070_S_IND_FLUXO_COMISSAO
        LK_0070_S_IND_ACOPLADO
        LK_0070_S_IND_FLUXO_SINISTRO
        LK_0070_S_IND_CONJUGE
        LK_0070_S_COD_USUARIO
        LK_0070_S_NOM_PROGRAMA
        LK_0070_S_DTH_CADASTRAMENTO
        LK_0070_IND_ERRO
        LK_0070_MSG_ERRO
        LK_0070_NOM_TABELA
        LK_0070_SQLCODE
        LK_0070_SQLERRMC
        LK_0070_SQLSTATE*/
        {
            try
            {
                this.GE0070W = GE0070W_P;

                /*" -0- FLUXCONTROL_PERFORM P0000-INICIALIZAR-SECTION */

                P0000_INICIALIZAR_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { GE0070W };
            return Result;
        }

        [StopWatch]
        /*" P0000-INICIALIZAR-SECTION */
        private void P0000_INICIALIZAR_SECTION()
        {
            /*" -163- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -164- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -165- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -168- MOVE FUNCTION CURRENT-DATE(1:14) TO WS-C-DATE-CURRENT. */
            _.Move(_.CurrentDate(0, 14), WORK.WS_DATAS.WS_C_DATE_CURRENT);

            /*" -170- MOVE FUNCTION WHEN-COMPILED TO WS-C-DATE-COMPILED. */
            _.Move(_.WhenCompiled(), WORK.WS_DATAS.WS_C_DATE_COMPILED);

            /*" -174- INITIALIZE LK-0070-IND-ERRO LK-0070-MSG-ERRO LK-0070-NOM-TABELA LK-0070-SQLCODE LK-0070-SQLERRMC LK-0070-SQLSTATE WS-ERRO */
            _.Initialize(
                GE0070W.LK_0070_IND_ERRO
                , GE0070W.LK_0070_MSG_ERRO
                , GE0070W.LK_0070_NOM_TABELA
                , GE0070W.LK_0070_SQLCODE
                , GE0070W.LK_0070_SQLERRMC
                , GE0070W.LK_0070_SQLSTATE
                , WORK.WS_ERRO
            );

            /*" -174- MOVE '0001' TO LK-RSGEWVDT-ANO */
            _.Move("0001", RSGEWVDT.LK_RSGEWVDT_ANO);

            /*" -174- MOVE '01' TO LK-RSGEWVDT-MES */
            _.Move("01", RSGEWVDT.LK_RSGEWVDT_MES);

            /*" -174- MOVE '01' TO LK-RSGEWVDT-DIA */
            _.Move("01", RSGEWVDT.LK_RSGEWVDT_DIA);

            /*" -174- MOVE ZEROS TO LK-RSGEWVDT-IND-RETORNO */
            _.Move(0, RSGEWVDT.LK_RSGEWVDT_IND_RETORNO);

            /*" -176- MOVE SPACES TO LK-RSGEWVDT-OUT-DATA */
            _.Move("", RSGEWVDT.LK_RSGEWVDT_OUT_DATA);

            /*" -177- IF NOT ( LK-0070-E-TRACE = 'S' OR = 'N' ) */

            if (!(GE0070W.LK_0070_E_TRACE.In("S", "N")))
            {

                /*" -178- MOVE 'N' TO LK-0070-E-TRACE */
                _.Move("N", GE0070W.LK_0070_E_TRACE);

                /*" -180- END-IF */
            }


            /*" -182- PERFORM P0050-VERIFICAR-SISTEMA */

            P0050_VERIFICAR_SISTEMA_SECTION();

            /*" -183- IF LK-0070-E-TRACE = 'S' */

            if (GE0070W.LK_0070_E_TRACE == "S")
            {

                /*" -184- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -185- DISPLAY '*              G E 0 0 7 0 S                 *' */
                _.Display($"*              G E 0 0 7 0 S                 *");

                /*" -186- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -193- DISPLAY '* DATA COMPILACAO....: ' WS-C-DATE-COMPILED(7:2) '/' WS-C-DATE-COMPILED(5:2) '/' WS-C-DATE-COMPILED(1:4) '-' WS-C-DATE-COMPILED(9:2) ':' WS-C-DATE-COMPILED(11:2) ':' WS-C-DATE-COMPILED(13:2) */

                $"* DATA COMPILACAO....: {WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(7, 2)}/{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(5, 2)}/{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(1, 4)}-{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(9, 2)}:{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(11, 2)}:{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(13, 2)}"
                .Display();

                /*" -200- DISPLAY '* DATA EXECUCAO......: ' WS-C-DATE-CURRENT(7:2) '/' WS-C-DATE-CURRENT(5:2) '/' WS-C-DATE-CURRENT(1:4) '-' WS-C-DATE-CURRENT(9:2) ':' WS-C-DATE-CURRENT(11:2) ':' WS-C-DATE-CURRENT(13:2) */

                $"* DATA EXECUCAO......: {WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(7, 2)}/{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(5, 2)}/{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(1, 4)}-{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(9, 2)}:{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(11, 2)}:{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(13, 2)}"
                .Display();

                /*" -204- DISPLAY '* DATA SISTEMA.......: ' SISTEMAS-DATA-MOV-ABERTO(9:2) '/' SISTEMAS-DATA-MOV-ABERTO(6:2) '/' SISTEMAS-DATA-MOV-ABERTO(1:4) */

                $"* DATA SISTEMA.......: {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2)}/{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2)}/{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4)}"
                .Display();

                /*" -205- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -206- DISPLAY '*             DADOS DE ENTRADA               *' */
                _.Display($"*             DADOS DE ENTRADA               *");

                /*" -207- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -208- DISPLAY '* TRACE..............: ' LK-0070-E-TRACE */
                _.Display($"* TRACE..............: {GE0070W.LK_0070_E_TRACE}");

                /*" -209- DISPLAY '* COD-USUARIO........: ' LK-0070-E-COD-USUARIO */
                _.Display($"* COD-USUARIO........: {GE0070W.LK_0070_E_COD_USUARIO}");

                /*" -210- DISPLAY '* NOM-PROGRAMA.......: ' LK-0070-E-NOM-PROGRAMA */
                _.Display($"* NOM-PROGRAMA.......: {GE0070W.LK_0070_E_NOM_PROGRAMA}");

                /*" -211- MOVE LK-0070-E-ACAO TO WS-SMALLINT(01) */
                _.Move(GE0070W.LK_0070_E_ACAO, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -212- DISPLAY '* ACAO...............: ' WS-SMALLINT(01) */
                _.Display($"* ACAO...............: {WORK.WS_EDIT.WS_SMALLINT[1]}");

                /*" -213- MOVE LK-0070-I-COD-PRODUTO TO WS-SMALLINT(01) */
                _.Move(GE0070W.LK_0070_I_COD_PRODUTO, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -214- DISPLAY '* COD-PRODUTO........: ' WS-SMALLINT(01) */
                _.Display($"* COD-PRODUTO........: {WORK.WS_EDIT.WS_SMALLINT[1]}");

                /*" -215- MOVE LK-0070-I-SEQ-PRODUTO-VRS TO WS-SMALLINT(01) */
                _.Move(GE0070W.LK_0070_I_SEQ_PRODUTO_VRS, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -216- DISPLAY '* SEQ-PRODUTO-VRS....: ' WS-SMALLINT(01) */
                _.Display($"* SEQ-PRODUTO-VRS....: {WORK.WS_EDIT.WS_SMALLINT[1]}");

                /*" -217- DISPLAY '* DTA-PROPOSTA.......: ' LK-0070-I-DTA-PROPOSTA */
                _.Display($"* DTA-PROPOSTA.......: {GE0070W.LK_0070_I_DTA_PROPOSTA}");

                /*" -218- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -220- END-IF */
            }


            /*" -220- PERFORM P0005-PROCESSAR */

            P0005_PROCESSAR_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0000_99_EXIT*/

        [StopWatch]
        /*" P0005-PROCESSAR-SECTION */
        private void P0005_PROCESSAR_SECTION()
        {
            /*" -231- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0005_00_START */

            P0005_00_START();

        }

        [StopWatch]
        /*" P0005-00-START */
        private void P0005_00_START(bool isPerform = false)
        {
            /*" -234- MOVE 'P0005' TO WS-SECTION */
            _.Move("P0005", WORK.WS_ERRO.WS_SECTION);

            /*" -234- PERFORM P0005-05-INICIO */

            P0005_05_INICIO(true);

        }

        [StopWatch]
        /*" P0005-05-INICIO */
        private void P0005_05_INICIO(bool isPerform = false)
        {
            /*" -240- PERFORM P0100-VALIDAR-LINKAGE */

            P0100_VALIDAR_LINKAGE_SECTION();

            /*" -241-  EVALUATE TRUE  */

            /*" -242-  WHEN LK-0070-E-ACAO         = 01  */

            /*" -242- IF LK-0070-E-ACAO         = 01 */

            if (GE0070W.LK_0070_E_ACAO == 01)
            {

                /*" -243- PERFORM P0200-REALIZAR-ACAO-01 */

                P0200_REALIZAR_ACAO_01_SECTION();

                /*" -244-  WHEN OTHER  */

                /*" -244- ELSE */
            }
            else
            {


                /*" -245- MOVE 'P0005' TO WS-SECTION */
                _.Move("P0005", WORK.WS_ERRO.WS_SECTION);

                /*" -246- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -247- MOVE LK-0070-E-ACAO TO WS-SMALLINT(01) */
                _.Move(GE0070W.LK_0070_E_ACAO, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -251- STRING WS-SECTION ' - ACAO NAO PREVISTA. ' '<ACAO=' WS-SMALLINT(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl1 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl1 += " - ACAO NAO PREVISTA. ";
                spl1 += "<ACAO=";
                var spl2 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl2 += ">";
                var results3 = spl1 + spl2;
                _.Move(results3, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -253- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -254- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -255- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -257-  END-EVALUATE  */

                /*" -257- END-IF */
            }


            /*" -257- PERFORM P0010-FINALIZAR */

            P0010_FINALIZAR_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0005_99_EXIT*/

        [StopWatch]
        /*" P0010-FINALIZAR-SECTION */
        private void P0010_FINALIZAR_SECTION()
        {
            /*" -268- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0010_00_START */

            P0010_00_START();

        }

        [StopWatch]
        /*" P0010-00-START */
        private void P0010_00_START(bool isPerform = false)
        {
            /*" -271- MOVE 'P0010' TO WS-SECTION */
            _.Move("P0010", WORK.WS_ERRO.WS_SECTION);

            /*" -271- PERFORM P0010-05-INICIO */

            P0010_05_INICIO(true);

        }

        [StopWatch]
        /*" P0010-05-INICIO */
        private void P0010_05_INICIO(bool isPerform = false)
        {
            /*" -276- MOVE 0 TO WS-IND-ERRO */
            _.Move(0, WORK.WS_ERRO.WS_IND_ERRO);

            /*" -278- STRING 'OPERACAO SOLICITADA REALIZADA COM SUCESSO.' DELIMITED BY SIZE INTO WS-MENSAGEM */
            #region STRING
            var spl3 = "OPERACAO SOLICITADA REALIZADA COM SUCESSO.";
            _.Move(spl3, WORK.WS_ERRO.WS_MENSAGEM);
            #endregion

            /*" -279- MOVE WS-MENSAGEM TO LK-0070-MSG-ERRO */
            _.Move(WORK.WS_ERRO.WS_MENSAGEM, GE0070W.LK_0070_MSG_ERRO);

            /*" -281- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
            _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

            /*" -283- MOVE 0 TO WS-SQLCODE */
            _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

            /*" -283- . */

        }

        [StopWatch]
        /*" P0010-99-EXIT */
        private void P0010_99_EXIT(bool isPerform = false)
        {
            /*" -286- GOBACK. */

            throw new GoBack();

        }

        [StopWatch]
        /*" P0050-VERIFICAR-SISTEMA-SECTION */
        private void P0050_VERIFICAR_SISTEMA_SECTION()
        {
            /*" -294- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0050_00_START */

            P0050_00_START();

        }

        [StopWatch]
        /*" P0050-00-START */
        private void P0050_00_START(bool isPerform = false)
        {
            /*" -298- MOVE 'P0050' TO WS-SECTION */
            _.Move("P0050", WORK.WS_ERRO.WS_SECTION);

            /*" -298- PERFORM P0050-05-INICIO */

            P0050_05_INICIO(true);

        }

        [StopWatch]
        /*" P0050-05-INICIO */
        private void P0050_05_INICIO(bool isPerform = false)
        {
            /*" -308- PERFORM P0050_05_INICIO_DB_SELECT_1 */

            P0050_05_INICIO_DB_SELECT_1();

            /*" -311- IF NOT ( SQLCODE = 0 OR = 100 ) */

            if (!(DB.SQLCODE.In("0", "100")))
            {

                /*" -312- MOVE 'P0050' TO WS-SECTION */
                _.Move("P0050", WORK.WS_ERRO.WS_SECTION);

                /*" -313- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -317- STRING WS-SECTION ' - ERRO NO SELECT NA SEGUROS.SISTEMA.' '<SISTEMA=GE>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl4 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl4 += " - ERRO NO SELECT NA SEGUROS.SISTEMA.";
                spl4 += "<SISTEMA=GE>";
                _.Move(spl4, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -318- MOVE 'SEGUROS.SISTEMA' TO WS-TABELA */
                _.Move("SEGUROS.SISTEMA", WORK.WS_ERRO.WS_TABELA);

                /*" -319- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -320- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -321- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -322- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -324- END-IF */
            }


            /*" -325- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -326- MOVE 'P0050' TO WS-SECTION */
                _.Move("P0050", WORK.WS_ERRO.WS_SECTION);

                /*" -327- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -331- STRING WS-SECTION ' - REGISTRO DE CONTROLE SISTEMA NAO CADASTRADO. ' '<SISTEMA=GE>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl5 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl5 += " - REGISTRO DE CONTROLE SISTEMA NAO CADASTRADO. ";
                spl5 += "<SISTEMA=GE>";
                _.Move(spl5, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -332- MOVE 'SEGUROS.SISTEMA' TO WS-TABELA */
                _.Move("SEGUROS.SISTEMA", WORK.WS_ERRO.WS_TABELA);

                /*" -333- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -334- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -335- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -336- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -338- END-IF */
            }


            /*" -338- . */

        }

        [StopWatch]
        /*" P0050-05-INICIO-DB-SELECT-1 */
        public void P0050_05_INICIO_DB_SELECT_1()
        {
            /*" -308- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'GE' WITH UR END-EXEC. */

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
            /*" -349- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0100_00_START */

            P0100_00_START();

        }

        [StopWatch]
        /*" P0100-00-START */
        private void P0100_00_START(bool isPerform = false)
        {
            /*" -352- MOVE 'P0100' TO WS-SECTION */
            _.Move("P0100", WORK.WS_ERRO.WS_SECTION);

            /*" -352- PERFORM P0100-05-INICIO */

            P0100_05_INICIO(true);

        }

        [StopWatch]
        /*" P0100-05-INICIO */
        private void P0100_05_INICIO(bool isPerform = false)
        {
            /*" -357- IF LK-0070-E-COD-USUARIO = SPACES */

            if (GE0070W.LK_0070_E_COD_USUARIO.IsEmpty())
            {

                /*" -358- MOVE 'P0100' TO WS-SECTION */
                _.Move("P0100", WORK.WS_ERRO.WS_SECTION);

                /*" -359- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -363- STRING WS-SECTION ' - CODIGO DO USUARIO NAO INFORMADO. ' '<COD_USUARIO=' LK-0070-E-COD-USUARIO '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl6 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl6 += " - CODIGO DO USUARIO NAO INFORMADO. ";
                spl6 += "<COD_USUARIO=";
                var spl7 = GE0070W.LK_0070_E_COD_USUARIO.GetMoveValues();
                spl7 += ">";
                var results8 = spl6 + spl7;
                _.Move(results8, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -365- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -366- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -367- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -369- END-IF */
            }


            /*" -370- IF LK-0070-E-NOM-PROGRAMA = SPACES */

            if (GE0070W.LK_0070_E_NOM_PROGRAMA.IsEmpty())
            {

                /*" -371- MOVE 'P0100' TO WS-SECTION */
                _.Move("P0100", WORK.WS_ERRO.WS_SECTION);

                /*" -372- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -376- STRING WS-SECTION ' - NOME DO PROGRAMA NAO INFORMADO. ' '<NOM_PROGRAMA=' LK-0070-E-NOM-PROGRAMA '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl8 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl8 += " - NOME DO PROGRAMA NAO INFORMADO. ";
                spl8 += "<NOM_PROGRAMA=";
                var spl9 = GE0070W.LK_0070_E_NOM_PROGRAMA.GetMoveValues();
                spl9 += ">";
                var results10 = spl8 + spl9;
                _.Move(results10, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -378- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -379- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -380- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -382- END-IF */
            }


            /*" -383- IF NOT ( LK-0070-E-ACAO = 01 ) */

            if (!(GE0070W.LK_0070_E_ACAO == 01))
            {

                /*" -384- MOVE 'P0100' TO WS-SECTION */
                _.Move("P0100", WORK.WS_ERRO.WS_SECTION);

                /*" -385- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -386- MOVE LK-0070-E-ACAO TO WS-SMALLINT(01) */
                _.Move(GE0070W.LK_0070_E_ACAO, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -390- STRING WS-SECTION ' - ACAO NAO PREVISTA. ' '<ACAO=' WS-SMALLINT(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl10 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl10 += " - ACAO NAO PREVISTA. ";
                spl10 += "<ACAO=";
                var spl11 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl11 += ">";
                var results12 = spl10 + spl11;
                _.Move(results12, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -392- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -393- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -394- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -396- END-IF */
            }


            /*" -398- PERFORM P0101-PESQUISAR-PRODUTO */

            P0101_PESQUISAR_PRODUTO_SECTION();

            /*" -399- IF LK-0070-I-DTA-PROPOSTA = SPACES */

            if (GE0070W.LK_0070_I_DTA_PROPOSTA.IsEmpty())
            {

                /*" -400- MOVE '0001-01-01' TO LK-0070-I-DTA-PROPOSTA */
                _.Move("0001-01-01", GE0070W.LK_0070_I_DTA_PROPOSTA);

                /*" -402- END-IF */
            }


            /*" -403- MOVE LK-0070-I-DTA-PROPOSTA TO WS-DATA-AMD */
            _.Move(GE0070W.LK_0070_I_DTA_PROPOSTA, WORK.WS_DATAS.WS_DATA_AMD);

            /*" -404- MOVE WS-DATA-AMD-AA TO LK-RSGEWVDT-ANO */
            _.Move(WORK.WS_DATAS.WS_DATA_AMD.WS_DATA_AMD_AA, RSGEWVDT.LK_RSGEWVDT_ANO);

            /*" -405- MOVE WS-DATA-AMD-MM TO LK-RSGEWVDT-MES */
            _.Move(WORK.WS_DATAS.WS_DATA_AMD.WS_DATA_AMD_MM, RSGEWVDT.LK_RSGEWVDT_MES);

            /*" -406- MOVE WS-DATA-AMD-DD TO LK-RSGEWVDT-DIA */
            _.Move(WORK.WS_DATAS.WS_DATA_AMD.WS_DATA_AMD_DD, RSGEWVDT.LK_RSGEWVDT_DIA);

            /*" -407- MOVE ZEROS TO LK-RSGEWVDT-IND-RETORNO */
            _.Move(0, RSGEWVDT.LK_RSGEWVDT_IND_RETORNO);

            /*" -408- MOVE SPACES TO LK-RSGEWVDT-OUT-DATA */
            _.Move("", RSGEWVDT.LK_RSGEWVDT_OUT_DATA);

            /*" -409- MOVE 'RSGESVDT' TO WS-PROGRAMA */
            _.Move("RSGESVDT", WORK.WS_PROGRAMA);

            /*" -414- CALL WS-PROGRAMA USING LK-RSGEWVDT-ANO LK-RSGEWVDT-MES LK-RSGEWVDT-DIA LK-RSGEWVDT-IND-RETORNO LK-RSGEWVDT-OUT-DATA */
            _.Call(WORK.WS_PROGRAMA, RSGEWVDT);

            /*" -416- IF LK-RSGEWVDT-IND-RETORNO NOT = 0 AND LK-0070-I-DTA-PROPOSTA NOT = '0001-01-01' */

            if (RSGEWVDT.LK_RSGEWVDT_IND_RETORNO != 0 && GE0070W.LK_0070_I_DTA_PROPOSTA != "0001-01-01")
            {

                /*" -417- MOVE 'P0100' TO WS-SECTION */
                _.Move("P0100", WORK.WS_ERRO.WS_SECTION);

                /*" -418- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -422- STRING WS-SECTION ' - DATA INVALIDA. ' '<DTA-PROPOSTA=' LK-0070-I-DTA-PROPOSTA '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl12 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl12 += " - DATA INVALIDA. ";
                spl12 += "<DTA-PROPOSTA=";
                var spl13 = GE0070W.LK_0070_I_DTA_PROPOSTA.GetMoveValues();
                spl13 += ">";
                var results14 = spl12 + spl13;
                _.Move(results14, WORK.WS_ERRO.WS_MENSAGEM);
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


            /*" -430- IF LK-0070-I-DTA-PROPOSTA = '0001-01-01' AND LK-0070-I-SEQ-PRODUTO-VRS < 1 */

            if (GE0070W.LK_0070_I_DTA_PROPOSTA == "0001-01-01" && GE0070W.LK_0070_I_SEQ_PRODUTO_VRS < 1)
            {

                /*" -431- MOVE 'P0100' TO WS-SECTION */
                _.Move("P0100", WORK.WS_ERRO.WS_SECTION);

                /*" -432- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -434- MOVE LK-0070-I-SEQ-PRODUTO-VRS TO WS-SMALLINT(01) */
                _.Move(GE0070W.LK_0070_I_SEQ_PRODUTO_VRS, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -440- STRING WS-SECTION ' - INFORME A DATA DA PROPOSTA OU VERSAO DO ' 'PRODUTO. ' '<DTA-PROPOSTA=' LK-0070-I-DTA-PROPOSTA '>' '<SEQ-PRODUTO-VRS=' WS-SMALLINT(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl14 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl14 += " - INFORME A DATA DA PROPOSTA OU VERSAO DO ";
                spl14 += "PRODUTO. ";
                spl14 += "<DTA-PROPOSTA=";
                var spl15 = GE0070W.LK_0070_I_DTA_PROPOSTA.GetMoveValues();
                spl15 += ">";
                spl15 += "<SEQ-PRODUTO-VRS=";
                var spl16 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl16 += ">";
                var results17 = spl14 + spl15 + spl16;
                _.Move(results17, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -442- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -443- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -444- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -446- END-IF */
            }


            /*" -448- IF LK-0070-I-DTA-PROPOSTA NOT = '0001-01-01' AND LK-0070-I-SEQ-PRODUTO-VRS > 0 */

            if (GE0070W.LK_0070_I_DTA_PROPOSTA != "0001-01-01" && GE0070W.LK_0070_I_SEQ_PRODUTO_VRS > 0)
            {

                /*" -449- MOVE 'P0100' TO WS-SECTION */
                _.Move("P0100", WORK.WS_ERRO.WS_SECTION);

                /*" -450- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -452- MOVE LK-0070-I-SEQ-PRODUTO-VRS TO WS-SMALLINT(01) */
                _.Move(GE0070W.LK_0070_I_SEQ_PRODUTO_VRS, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -458- STRING WS-SECTION ' - INFORME A DATA DA PROPOSTA OU VERSAO DO ' 'PRODUTO. ' '<DTA-PROPOSTA=' LK-0070-I-DTA-PROPOSTA '>' '<SEQ-PRODUTO-VRS=' WS-SMALLINT(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl17 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl17 += " - INFORME A DATA DA PROPOSTA OU VERSAO DO ";
                spl17 += "PRODUTO. ";
                spl17 += "<DTA-PROPOSTA=";
                var spl18 = GE0070W.LK_0070_I_DTA_PROPOSTA.GetMoveValues();
                spl18 += ">";
                spl18 += "<SEQ-PRODUTO-VRS=";
                var spl19 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl19 += ">";
                var results20 = spl17 + spl18 + spl19;
                _.Move(results20, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -460- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -461- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -462- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -464- END-IF */
            }


            /*" -464- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0100_99_EXIT*/

        [StopWatch]
        /*" P0101-PESQUISAR-PRODUTO-SECTION */
        private void P0101_PESQUISAR_PRODUTO_SECTION()
        {
            /*" -475- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0101_00_START */

            P0101_00_START();

        }

        [StopWatch]
        /*" P0101-00-START */
        private void P0101_00_START(bool isPerform = false)
        {
            /*" -479- MOVE 'P0101' TO WS-SECTION */
            _.Move("P0101", WORK.WS_ERRO.WS_SECTION);

            /*" -482- MOVE LK-0070-I-COD-PRODUTO TO PRODUTO-COD-PRODUTO WS-SMALLINT(01) */
            _.Move(GE0070W.LK_0070_I_COD_PRODUTO, PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO, WORK.WS_EDIT.WS_SMALLINT[01]);

            /*" -482- PERFORM P0101-05-INICIO */

            P0101_05_INICIO(true);

        }

        [StopWatch]
        /*" P0101-05-INICIO */
        private void P0101_05_INICIO(bool isPerform = false)
        {
            /*" -492- PERFORM P0101_05_INICIO_DB_SELECT_1 */

            P0101_05_INICIO_DB_SELECT_1();

            /*" -495- IF NOT ( SQLCODE = 0 OR = 100 ) */

            if (!(DB.SQLCODE.In("0", "100")))
            {

                /*" -496- MOVE 'P0101' TO WS-SECTION */
                _.Move("P0101", WORK.WS_ERRO.WS_SECTION);

                /*" -497- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -501- STRING WS-SECTION ' - ERRO NO SELECT NA SEGUROS.PRODUTO. ' '<COD-PRODUTO=' WS-SMALLINT(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl20 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl20 += " - ERRO NO SELECT NA SEGUROS.PRODUTO. ";
                spl20 += "<COD-PRODUTO=";
                var spl21 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl21 += ">";
                var results22 = spl20 + spl21;
                _.Move(results22, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -502- MOVE 'SEGUROS.PRODUTO' TO WS-TABELA */
                _.Move("SEGUROS.PRODUTO", WORK.WS_ERRO.WS_TABELA);

                /*" -503- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -504- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -505- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -506- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -508- END-IF */
            }


            /*" -509- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -510- MOVE 'P0101' TO WS-SECTION */
                _.Move("P0101", WORK.WS_ERRO.WS_SECTION);

                /*" -511- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -515- STRING WS-SECTION ' - CODIGO DE PRODUTO NAO CADASTRADO. ' '<COD-PRODUTO=' WS-SMALLINT(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl22 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl22 += " - CODIGO DE PRODUTO NAO CADASTRADO. ";
                spl22 += "<COD-PRODUTO=";
                var spl23 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl23 += ">";
                var results24 = spl22 + spl23;
                _.Move(results24, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -516- MOVE 'SEGUROS.PRODUTO' TO WS-TABELA */
                _.Move("SEGUROS.PRODUTO", WORK.WS_ERRO.WS_TABELA);

                /*" -517- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -518- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -519- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -520- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -522- END-IF */
            }


            /*" -522- . */

        }

        [StopWatch]
        /*" P0101-05-INICIO-DB-SELECT-1 */
        public void P0101_05_INICIO_DB_SELECT_1()
        {
            /*" -492- EXEC SQL SELECT DESCR_PRODUTO INTO :PRODUTO-DESCR-PRODUTO FROM SEGUROS.PRODUTO WHERE COD_PRODUTO = :PRODUTO-COD-PRODUTO WITH UR END-EXEC. */

            var p0101_05_INICIO_DB_SELECT_1_Query1 = new P0101_05_INICIO_DB_SELECT_1_Query1()
            {
                PRODUTO_COD_PRODUTO = PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO.ToString(),
            };

            var executed_1 = P0101_05_INICIO_DB_SELECT_1_Query1.Execute(p0101_05_INICIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUTO_DESCR_PRODUTO, PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0101_99_EXIT*/

        [StopWatch]
        /*" P0200-REALIZAR-ACAO-01-SECTION */
        private void P0200_REALIZAR_ACAO_01_SECTION()
        {
            /*" -533- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0200_00_START */

            P0200_00_START();

        }

        [StopWatch]
        /*" P0200-00-START */
        private void P0200_00_START(bool isPerform = false)
        {
            /*" -537- MOVE 'P0200' TO WS-SECTION */
            _.Move("P0200", WORK.WS_ERRO.WS_SECTION);

            /*" -537- PERFORM P0200-05-INICIO */

            P0200_05_INICIO(true);

        }

        [StopWatch]
        /*" P0200-05-INICIO */
        private void P0200_05_INICIO(bool isPerform = false)
        {
            /*" -542-  EVALUATE TRUE  */

            /*" -543-  WHEN LK-0070-I-SEQ-PRODUTO-VRS > 0  */

            /*" -543- IF LK-0070-I-SEQ-PRODUTO-VRS > 0 */

            if (GE0070W.LK_0070_I_SEQ_PRODUTO_VRS > 0)
            {

                /*" -544- PERFORM P0201-PESQUISAR-PROD-VERSAO */

                P0201_PESQUISAR_PROD_VERSAO_SECTION();

                /*" -545-  WHEN OTHER  */

                /*" -545- ELSE */
            }
            else
            {


                /*" -546- PERFORM P0202-PESQUISAR-PROD-VRS-DT */

                P0202_PESQUISAR_PROD_VRS_DT_SECTION();

                /*" -548-  END-EVALUATE  */

                /*" -548- END-IF */
            }


            /*" -548- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0200_99_EXIT*/

        [StopWatch]
        /*" P0201-PESQUISAR-PROD-VERSAO-SECTION */
        private void P0201_PESQUISAR_PROD_VERSAO_SECTION()
        {
            /*" -560- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0201_00_START */

            P0201_00_START();

        }

        [StopWatch]
        /*" P0201-00-START */
        private void P0201_00_START(bool isPerform = false)
        {
            /*" -564- MOVE 'P0201' TO WS-SECTION */
            _.Move("P0201", WORK.WS_ERRO.WS_SECTION);

            /*" -566- MOVE LK-0070-I-COD-PRODUTO TO GE089-COD-PRODUTO WS-SMALLINT(01) */
            _.Move(GE0070W.LK_0070_I_COD_PRODUTO, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_COD_PRODUTO, WORK.WS_EDIT.WS_SMALLINT[01]);

            /*" -569- MOVE LK-0070-I-SEQ-PRODUTO-VRS TO GE089-SEQ-PRODUTO-VRS WS-SMALLINT(02) */
            _.Move(GE0070W.LK_0070_I_SEQ_PRODUTO_VRS, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_SEQ_PRODUTO_VRS, WORK.WS_EDIT.WS_SMALLINT[02]);

            /*" -569- PERFORM P0201-05-INICIO */

            P0201_05_INICIO(true);

        }

        [StopWatch]
        /*" P0201-05-INICIO */
        private void P0201_05_INICIO(bool isPerform = false)
        {
            /*" -630- PERFORM P0201_05_INICIO_DB_SELECT_1 */

            P0201_05_INICIO_DB_SELECT_1();

            /*" -633- IF NOT ( SQLCODE = 0 OR = 100 ) */

            if (!(DB.SQLCODE.In("0", "100")))
            {

                /*" -634- MOVE 'P0201' TO WS-SECTION */
                _.Move("P0201", WORK.WS_ERRO.WS_SECTION);

                /*" -635- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -641- STRING WS-SECTION ' - ERRO NO SELECT NA ' 'SEGUROS.GE_PRODUTO_COMPLEMENTO. ' '<COD-PRODUTO=' WS-SMALLINT(01) '>' '<SEQ-PRODUTO-VRS=' WS-SMALLINT(02) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl24 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl24 += " - ERRO NO SELECT NA ";
                spl24 += "SEGUROS.GE_PRODUTO_COMPLEMENTO. ";
                spl24 += "<COD-PRODUTO=";
                var spl25 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl25 += ">";
                spl25 += "<SEQ-PRODUTO-VRS=";
                var spl26 = WORK.WS_EDIT.WS_SMALLINT[02].GetMoveValues();
                spl26 += ">";
                var results27 = spl24 + spl25 + spl26;
                _.Move(results27, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -643- MOVE 'SEGUROS.GE_PRODUTO_COMPLEMENTO' TO WS-TABELA */
                _.Move("SEGUROS.GE_PRODUTO_COMPLEMENTO", WORK.WS_ERRO.WS_TABELA);

                /*" -644- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -645- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -646- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -647- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -649- END-IF */
            }


            /*" -650- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -651- MOVE 'P0201' TO WS-SECTION */
                _.Move("P0201", WORK.WS_ERRO.WS_SECTION);

                /*" -652- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -657- STRING WS-SECTION ' - CODIGO DE PRODUTO E VERSAO NAO CADASTRADO. ' '<COD-PRODUTO=' WS-SMALLINT(01) '>' '<SEQ-PRODUTO-VRS=' WS-SMALLINT(02) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl27 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl27 += " - CODIGO DE PRODUTO E VERSAO NAO CADASTRADO. ";
                spl27 += "<COD-PRODUTO=";
                var spl28 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl28 += ">";
                spl28 += "<SEQ-PRODUTO-VRS=";
                var spl29 = WORK.WS_EDIT.WS_SMALLINT[02].GetMoveValues();
                spl29 += ">";
                var results30 = spl27 + spl28 + spl29;
                _.Move(results30, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -659- MOVE 'SEGUROS.GE_PRODUTO_COMPLEMENTO' TO WS-TABELA */
                _.Move("SEGUROS.GE_PRODUTO_COMPLEMENTO", WORK.WS_ERRO.WS_TABELA);

                /*" -660- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -661- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -662- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -663- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -665- END-IF */
            }


            /*" -667- PERFORM P0205-MOVER-DADOS */

            P0205_MOVER_DADOS_SECTION();

            /*" -667- . */

        }

        [StopWatch]
        /*" P0201-05-INICIO-DB-SELECT-1 */
        public void P0201_05_INICIO_DB_SELECT_1()
        {
            /*" -630- EXEC SQL SELECT COD_PRODUTO ,SEQ_PRODUTO_VRS ,DTA_INI_VIGENCIA ,DTA_FIM_VIGENCIA ,IND_FLUXO_PARAMTRIZADO ,COD_PERIOD_VIGENCIA ,QTD_PERIOD_VIGENCIA ,COD_MOEDA ,IND_RENOVA ,IND_RENOVA_AUTOMATICA ,QTD_RENOVA_AUTOMATICA ,IND_DPS ,IND_REENQUADRA_PREMIO ,IND_REAJUSTE_PREMIO ,COD_INDICE_REAJUSTE ,COD_PERIOD_REAJUSTE ,COD_INDICE_DEVOLUCAO ,PCT_JUROS_DEVOLUCAO ,PCT_MULTA_DEVOLUCAO ,IND_FLUXO_COMISSAO ,IND_ACOPLADO ,IND_FLUXO_SINISTRO ,IND_CONJUGE ,COD_USUARIO ,NOM_PROGRAMA ,CHAR(DTH_CADASTRAMENTO) INTO :GE089-COD-PRODUTO ,:GE089-SEQ-PRODUTO-VRS ,:GE089-DTA-INI-VIGENCIA ,:GE089-DTA-FIM-VIGENCIA ,:GE089-IND-FLUXO-PARAMTRIZADO ,:GE089-COD-PERIOD-VIGENCIA ,:GE089-QTD-PERIOD-VIGENCIA ,:GE089-COD-MOEDA ,:GE089-IND-RENOVA ,:GE089-IND-RENOVA-AUTOMATICA ,:GE089-QTD-RENOVA-AUTOMATICA ,:GE089-IND-DPS ,:GE089-IND-REENQUADRA-PREMIO ,:GE089-IND-REAJUSTE-PREMIO ,:GE089-COD-INDICE-REAJUSTE ,:GE089-COD-PERIOD-REAJUSTE ,:GE089-COD-INDICE-DEVOLUCAO ,:GE089-PCT-JUROS-DEVOLUCAO ,:GE089-PCT-MULTA-DEVOLUCAO ,:GE089-IND-FLUXO-COMISSAO ,:GE089-IND-ACOPLADO ,:GE089-IND-FLUXO-SINISTRO ,:GE089-IND-CONJUGE ,:GE089-COD-USUARIO ,:GE089-NOM-PROGRAMA ,:GE089-DTH-CADASTRAMENTO FROM SEGUROS.GE_PRODUTO_COMPLEMENTO WHERE COD_PRODUTO = :GE089-COD-PRODUTO AND SEQ_PRODUTO_VRS = :GE089-SEQ-PRODUTO-VRS WITH UR END-EXEC. */

            var p0201_05_INICIO_DB_SELECT_1_Query1 = new P0201_05_INICIO_DB_SELECT_1_Query1()
            {
                GE089_SEQ_PRODUTO_VRS = GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_SEQ_PRODUTO_VRS.ToString(),
                GE089_COD_PRODUTO = GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_COD_PRODUTO.ToString(),
            };

            var executed_1 = P0201_05_INICIO_DB_SELECT_1_Query1.Execute(p0201_05_INICIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE089_COD_PRODUTO, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_COD_PRODUTO);
                _.Move(executed_1.GE089_SEQ_PRODUTO_VRS, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_SEQ_PRODUTO_VRS);
                _.Move(executed_1.GE089_DTA_INI_VIGENCIA, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_DTA_INI_VIGENCIA);
                _.Move(executed_1.GE089_DTA_FIM_VIGENCIA, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_DTA_FIM_VIGENCIA);
                _.Move(executed_1.GE089_IND_FLUXO_PARAMTRIZADO, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_IND_FLUXO_PARAMTRIZADO);
                _.Move(executed_1.GE089_COD_PERIOD_VIGENCIA, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_COD_PERIOD_VIGENCIA);
                _.Move(executed_1.GE089_QTD_PERIOD_VIGENCIA, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_QTD_PERIOD_VIGENCIA);
                _.Move(executed_1.GE089_COD_MOEDA, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_COD_MOEDA);
                _.Move(executed_1.GE089_IND_RENOVA, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_IND_RENOVA);
                _.Move(executed_1.GE089_IND_RENOVA_AUTOMATICA, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_IND_RENOVA_AUTOMATICA);
                _.Move(executed_1.GE089_QTD_RENOVA_AUTOMATICA, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_QTD_RENOVA_AUTOMATICA);
                _.Move(executed_1.GE089_IND_DPS, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_IND_DPS);
                _.Move(executed_1.GE089_IND_REENQUADRA_PREMIO, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_IND_REENQUADRA_PREMIO);
                _.Move(executed_1.GE089_IND_REAJUSTE_PREMIO, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_IND_REAJUSTE_PREMIO);
                _.Move(executed_1.GE089_COD_INDICE_REAJUSTE, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_COD_INDICE_REAJUSTE);
                _.Move(executed_1.GE089_COD_PERIOD_REAJUSTE, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_COD_PERIOD_REAJUSTE);
                _.Move(executed_1.GE089_COD_INDICE_DEVOLUCAO, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_COD_INDICE_DEVOLUCAO);
                _.Move(executed_1.GE089_PCT_JUROS_DEVOLUCAO, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_PCT_JUROS_DEVOLUCAO);
                _.Move(executed_1.GE089_PCT_MULTA_DEVOLUCAO, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_PCT_MULTA_DEVOLUCAO);
                _.Move(executed_1.GE089_IND_FLUXO_COMISSAO, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_IND_FLUXO_COMISSAO);
                _.Move(executed_1.GE089_IND_ACOPLADO, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_IND_ACOPLADO);
                _.Move(executed_1.GE089_IND_FLUXO_SINISTRO, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_IND_FLUXO_SINISTRO);
                _.Move(executed_1.GE089_IND_CONJUGE, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_IND_CONJUGE);
                _.Move(executed_1.GE089_COD_USUARIO, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_COD_USUARIO);
                _.Move(executed_1.GE089_NOM_PROGRAMA, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_NOM_PROGRAMA);
                _.Move(executed_1.GE089_DTH_CADASTRAMENTO, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_DTH_CADASTRAMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0201_99_EXIT*/

        [StopWatch]
        /*" P0202-PESQUISAR-PROD-VRS-DT-SECTION */
        private void P0202_PESQUISAR_PROD_VRS_DT_SECTION()
        {
            /*" -679- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0202_00_START */

            P0202_00_START();

        }

        [StopWatch]
        /*" P0202-00-START */
        private void P0202_00_START(bool isPerform = false)
        {
            /*" -683- MOVE 'P0202' TO WS-SECTION */
            _.Move("P0202", WORK.WS_ERRO.WS_SECTION);

            /*" -685- MOVE LK-0070-I-COD-PRODUTO TO GE089-COD-PRODUTO WS-SMALLINT(01) */
            _.Move(GE0070W.LK_0070_I_COD_PRODUTO, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_COD_PRODUTO, WORK.WS_EDIT.WS_SMALLINT[01]);

            /*" -687- MOVE LK-0070-I-DTA-PROPOSTA TO GE089-DTA-INI-VIGENCIA */
            _.Move(GE0070W.LK_0070_I_DTA_PROPOSTA, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_DTA_INI_VIGENCIA);

            /*" -687- PERFORM P0202-05-INICIO */

            P0202_05_INICIO(true);

        }

        [StopWatch]
        /*" P0202-05-INICIO */
        private void P0202_05_INICIO(bool isPerform = false)
        {
            /*" -749- PERFORM P0202_05_INICIO_DB_SELECT_1 */

            P0202_05_INICIO_DB_SELECT_1();

            /*" -752- IF NOT ( SQLCODE = 0 OR = 100 ) */

            if (!(DB.SQLCODE.In("0", "100")))
            {

                /*" -753- MOVE 'P0202' TO WS-SECTION */
                _.Move("P0202", WORK.WS_ERRO.WS_SECTION);

                /*" -754- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -760- STRING WS-SECTION ' - ERRO NO SELECT NA ' 'SEGUROS.GE_PRODUTO_COMPLEMENTO. ' '<COD-PRODUTO=' WS-SMALLINT(01) '>' '<SEQ-PRODUTO-VRS=' WS-SMALLINT(02) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl30 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl30 += " - ERRO NO SELECT NA ";
                spl30 += "SEGUROS.GE_PRODUTO_COMPLEMENTO. ";
                spl30 += "<COD-PRODUTO=";
                var spl31 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl31 += ">";
                spl31 += "<SEQ-PRODUTO-VRS=";
                var spl32 = WORK.WS_EDIT.WS_SMALLINT[02].GetMoveValues();
                spl32 += ">";
                var results33 = spl30 + spl31 + spl32;
                _.Move(results33, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -762- MOVE 'SEGUROS.GE_PRODUTO_COMPLEMENTO' TO WS-TABELA */
                _.Move("SEGUROS.GE_PRODUTO_COMPLEMENTO", WORK.WS_ERRO.WS_TABELA);

                /*" -763- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -764- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -765- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -766- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -768- END-IF */
            }


            /*" -769- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -770- MOVE LK-0070-I-COD-PRODUTO TO GE089-COD-PRODUTO */
                _.Move(GE0070W.LK_0070_I_COD_PRODUTO, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_COD_PRODUTO);

                /*" -771- MOVE 00 TO GE089-SEQ-PRODUTO-VRS */
                _.Move(00, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_SEQ_PRODUTO_VRS);

                /*" -772- MOVE '0001-01-01' TO GE089-DTA-INI-VIGENCIA */
                _.Move("0001-01-01", GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_DTA_INI_VIGENCIA);

                /*" -773- MOVE '9999-12-31' TO GE089-DTA-FIM-VIGENCIA */
                _.Move("9999-12-31", GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_DTA_FIM_VIGENCIA);

                /*" -775- MOVE 'N' TO GE089-IND-FLUXO-PARAMTRIZADO */
                _.Move("N", GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_IND_FLUXO_PARAMTRIZADO);

                /*" -776- MOVE 0 TO GE089-COD-PERIOD-VIGENCIA */
                _.Move(0, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_COD_PERIOD_VIGENCIA);

                /*" -777- MOVE 0 TO GE089-QTD-PERIOD-VIGENCIA */
                _.Move(0, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_QTD_PERIOD_VIGENCIA);

                /*" -778- MOVE 0 TO GE089-COD-MOEDA */
                _.Move(0, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_COD_MOEDA);

                /*" -779- MOVE 'N' TO GE089-IND-RENOVA */
                _.Move("N", GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_IND_RENOVA);

                /*" -781- MOVE 'N' TO GE089-IND-RENOVA-AUTOMATICA */
                _.Move("N", GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_IND_RENOVA_AUTOMATICA);

                /*" -783- MOVE 0 TO GE089-QTD-RENOVA-AUTOMATICA */
                _.Move(0, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_QTD_RENOVA_AUTOMATICA);

                /*" -784- MOVE 'N' TO GE089-IND-DPS */
                _.Move("N", GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_IND_DPS);

                /*" -786- MOVE 'N' TO GE089-IND-REENQUADRA-PREMIO */
                _.Move("N", GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_IND_REENQUADRA_PREMIO);

                /*" -787- MOVE 'N' TO GE089-IND-REAJUSTE-PREMIO */
                _.Move("N", GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_IND_REAJUSTE_PREMIO);

                /*" -788- MOVE 0 TO GE089-COD-INDICE-REAJUSTE */
                _.Move(0, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_COD_INDICE_REAJUSTE);

                /*" -789- MOVE 0 TO GE089-COD-PERIOD-REAJUSTE */
                _.Move(0, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_COD_PERIOD_REAJUSTE);

                /*" -791- MOVE 0 TO GE089-COD-INDICE-DEVOLUCAO */
                _.Move(0, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_COD_INDICE_DEVOLUCAO);

                /*" -792- MOVE 0 TO GE089-PCT-JUROS-DEVOLUCAO */
                _.Move(0, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_PCT_JUROS_DEVOLUCAO);

                /*" -793- MOVE 0 TO GE089-PCT-MULTA-DEVOLUCAO */
                _.Move(0, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_PCT_MULTA_DEVOLUCAO);

                /*" -794- MOVE 'N' TO GE089-IND-FLUXO-COMISSAO */
                _.Move("N", GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_IND_FLUXO_COMISSAO);

                /*" -795- MOVE 'N' TO GE089-IND-ACOPLADO */
                _.Move("N", GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_IND_ACOPLADO);

                /*" -796- MOVE 'N' TO GE089-IND-FLUXO-SINISTRO */
                _.Move("N", GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_IND_FLUXO_SINISTRO);

                /*" -797- MOVE 'N' TO GE089-IND-CONJUGE */
                _.Move("N", GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_IND_CONJUGE);

                /*" -798- MOVE SPACES TO GE089-COD-USUARIO */
                _.Move("", GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_COD_USUARIO);

                /*" -799- MOVE 'GE0070S' TO GE089-NOM-PROGRAMA */
                _.Move("GE0070S", GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_NOM_PROGRAMA);

                /*" -801- MOVE '1900-01-01-01.01.01.000001' TO GE089-DTH-CADASTRAMENTO */
                _.Move("1900-01-01-01.01.01.000001", GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_DTH_CADASTRAMENTO);

                /*" -803- END-IF */
            }


            /*" -805- PERFORM P0205-MOVER-DADOS */

            P0205_MOVER_DADOS_SECTION();

            /*" -805- . */

        }

        [StopWatch]
        /*" P0202-05-INICIO-DB-SELECT-1 */
        public void P0202_05_INICIO_DB_SELECT_1()
        {
            /*" -749- EXEC SQL SELECT COD_PRODUTO ,SEQ_PRODUTO_VRS ,DTA_INI_VIGENCIA ,DTA_FIM_VIGENCIA ,IND_FLUXO_PARAMTRIZADO ,COD_PERIOD_VIGENCIA ,QTD_PERIOD_VIGENCIA ,COD_MOEDA ,IND_RENOVA ,IND_RENOVA_AUTOMATICA ,QTD_RENOVA_AUTOMATICA ,IND_DPS ,IND_REENQUADRA_PREMIO ,IND_REAJUSTE_PREMIO ,COD_INDICE_REAJUSTE ,COD_PERIOD_REAJUSTE ,COD_INDICE_DEVOLUCAO ,PCT_JUROS_DEVOLUCAO ,PCT_MULTA_DEVOLUCAO ,IND_FLUXO_COMISSAO ,IND_ACOPLADO ,IND_FLUXO_SINISTRO ,IND_CONJUGE ,COD_USUARIO ,NOM_PROGRAMA ,CHAR(DTH_CADASTRAMENTO) INTO :GE089-COD-PRODUTO ,:GE089-SEQ-PRODUTO-VRS ,:GE089-DTA-INI-VIGENCIA ,:GE089-DTA-FIM-VIGENCIA ,:GE089-IND-FLUXO-PARAMTRIZADO ,:GE089-COD-PERIOD-VIGENCIA ,:GE089-QTD-PERIOD-VIGENCIA ,:GE089-COD-MOEDA ,:GE089-IND-RENOVA ,:GE089-IND-RENOVA-AUTOMATICA ,:GE089-QTD-RENOVA-AUTOMATICA ,:GE089-IND-DPS ,:GE089-IND-REENQUADRA-PREMIO ,:GE089-IND-REAJUSTE-PREMIO ,:GE089-COD-INDICE-REAJUSTE ,:GE089-COD-PERIOD-REAJUSTE ,:GE089-COD-INDICE-DEVOLUCAO ,:GE089-PCT-JUROS-DEVOLUCAO ,:GE089-PCT-MULTA-DEVOLUCAO ,:GE089-IND-FLUXO-COMISSAO ,:GE089-IND-ACOPLADO ,:GE089-IND-FLUXO-SINISTRO ,:GE089-IND-CONJUGE ,:GE089-COD-USUARIO ,:GE089-NOM-PROGRAMA ,:GE089-DTH-CADASTRAMENTO FROM SEGUROS.GE_PRODUTO_COMPLEMENTO WHERE COD_PRODUTO = :GE089-COD-PRODUTO AND :GE089-DTA-INI-VIGENCIA BETWEEN DTA_INI_VIGENCIA AND DTA_FIM_VIGENCIA WITH UR END-EXEC. */

            var p0202_05_INICIO_DB_SELECT_1_Query1 = new P0202_05_INICIO_DB_SELECT_1_Query1()
            {
                GE089_DTA_INI_VIGENCIA = GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_DTA_INI_VIGENCIA.ToString(),
                GE089_COD_PRODUTO = GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_COD_PRODUTO.ToString(),
            };

            var executed_1 = P0202_05_INICIO_DB_SELECT_1_Query1.Execute(p0202_05_INICIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE089_COD_PRODUTO, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_COD_PRODUTO);
                _.Move(executed_1.GE089_SEQ_PRODUTO_VRS, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_SEQ_PRODUTO_VRS);
                _.Move(executed_1.GE089_DTA_INI_VIGENCIA, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_DTA_INI_VIGENCIA);
                _.Move(executed_1.GE089_DTA_FIM_VIGENCIA, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_DTA_FIM_VIGENCIA);
                _.Move(executed_1.GE089_IND_FLUXO_PARAMTRIZADO, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_IND_FLUXO_PARAMTRIZADO);
                _.Move(executed_1.GE089_COD_PERIOD_VIGENCIA, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_COD_PERIOD_VIGENCIA);
                _.Move(executed_1.GE089_QTD_PERIOD_VIGENCIA, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_QTD_PERIOD_VIGENCIA);
                _.Move(executed_1.GE089_COD_MOEDA, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_COD_MOEDA);
                _.Move(executed_1.GE089_IND_RENOVA, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_IND_RENOVA);
                _.Move(executed_1.GE089_IND_RENOVA_AUTOMATICA, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_IND_RENOVA_AUTOMATICA);
                _.Move(executed_1.GE089_QTD_RENOVA_AUTOMATICA, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_QTD_RENOVA_AUTOMATICA);
                _.Move(executed_1.GE089_IND_DPS, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_IND_DPS);
                _.Move(executed_1.GE089_IND_REENQUADRA_PREMIO, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_IND_REENQUADRA_PREMIO);
                _.Move(executed_1.GE089_IND_REAJUSTE_PREMIO, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_IND_REAJUSTE_PREMIO);
                _.Move(executed_1.GE089_COD_INDICE_REAJUSTE, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_COD_INDICE_REAJUSTE);
                _.Move(executed_1.GE089_COD_PERIOD_REAJUSTE, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_COD_PERIOD_REAJUSTE);
                _.Move(executed_1.GE089_COD_INDICE_DEVOLUCAO, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_COD_INDICE_DEVOLUCAO);
                _.Move(executed_1.GE089_PCT_JUROS_DEVOLUCAO, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_PCT_JUROS_DEVOLUCAO);
                _.Move(executed_1.GE089_PCT_MULTA_DEVOLUCAO, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_PCT_MULTA_DEVOLUCAO);
                _.Move(executed_1.GE089_IND_FLUXO_COMISSAO, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_IND_FLUXO_COMISSAO);
                _.Move(executed_1.GE089_IND_ACOPLADO, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_IND_ACOPLADO);
                _.Move(executed_1.GE089_IND_FLUXO_SINISTRO, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_IND_FLUXO_SINISTRO);
                _.Move(executed_1.GE089_IND_CONJUGE, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_IND_CONJUGE);
                _.Move(executed_1.GE089_COD_USUARIO, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_COD_USUARIO);
                _.Move(executed_1.GE089_NOM_PROGRAMA, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_NOM_PROGRAMA);
                _.Move(executed_1.GE089_DTH_CADASTRAMENTO, GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_DTH_CADASTRAMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0202_99_EXIT*/

        [StopWatch]
        /*" P0205-MOVER-DADOS-SECTION */
        private void P0205_MOVER_DADOS_SECTION()
        {
            /*" -816- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0205_00_START */

            P0205_00_START();

        }

        [StopWatch]
        /*" P0205-00-START */
        private void P0205_00_START(bool isPerform = false)
        {
            /*" -820- MOVE 'P0205' TO WS-SECTION */
            _.Move("P0205", WORK.WS_ERRO.WS_SECTION);

            /*" -820- PERFORM P0205-05-INICIO */

            P0205_05_INICIO(true);

        }

        [StopWatch]
        /*" P0205-05-INICIO */
        private void P0205_05_INICIO(bool isPerform = false)
        {
            /*" -825- MOVE GE089-COD-PRODUTO TO LK-0070-I-COD-PRODUTO */
            _.Move(GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_COD_PRODUTO, GE0070W.LK_0070_I_COD_PRODUTO);

            /*" -827- MOVE GE089-SEQ-PRODUTO-VRS TO LK-0070-I-SEQ-PRODUTO-VRS */
            _.Move(GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_SEQ_PRODUTO_VRS, GE0070W.LK_0070_I_SEQ_PRODUTO_VRS);

            /*" -829- MOVE GE089-DTA-INI-VIGENCIA TO LK-0070-S-DTA-INI-VIGENCIA */
            _.Move(GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_DTA_INI_VIGENCIA, GE0070W.LK_0070_S_DTA_INI_VIGENCIA);

            /*" -831- MOVE GE089-DTA-FIM-VIGENCIA TO LK-0070-S-DTA-FIM-VIGENCIA */
            _.Move(GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_DTA_FIM_VIGENCIA, GE0070W.LK_0070_S_DTA_FIM_VIGENCIA);

            /*" -833- MOVE GE089-IND-FLUXO-PARAMTRIZADO TO LK-0070-S-IND-FLUXO-PARAM */
            _.Move(GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_IND_FLUXO_PARAMTRIZADO, GE0070W.LK_0070_S_IND_FLUXO_PARAM);

            /*" -835- MOVE GE089-COD-PERIOD-VIGENCIA TO LK-0070-S-COD-PERIOD-VIGENCIA */
            _.Move(GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_COD_PERIOD_VIGENCIA, GE0070W.LK_0070_S_COD_PERIOD_VIGENCIA);

            /*" -837- MOVE GE089-QTD-PERIOD-VIGENCIA TO LK-0070-S-QTD-PERIOD-VIGENCIA */
            _.Move(GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_QTD_PERIOD_VIGENCIA, GE0070W.LK_0070_S_QTD_PERIOD_VIGENCIA);

            /*" -838- MOVE GE089-COD-MOEDA TO LK-0070-S-COD-MOEDA */
            _.Move(GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_COD_MOEDA, GE0070W.LK_0070_S_COD_MOEDA);

            /*" -839- MOVE GE089-IND-RENOVA TO LK-0070-S-IND-RENOVA */
            _.Move(GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_IND_RENOVA, GE0070W.LK_0070_S_IND_RENOVA);

            /*" -841- MOVE GE089-IND-RENOVA-AUTOMATICA TO LK-0070-S-IND-RENOVA-AUTOMAT */
            _.Move(GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_IND_RENOVA_AUTOMATICA, GE0070W.LK_0070_S_IND_RENOVA_AUTOMAT);

            /*" -843- MOVE GE089-QTD-RENOVA-AUTOMATICA TO LK-0070-S-QTD-RENOVA-AUTOMAT */
            _.Move(GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_QTD_RENOVA_AUTOMATICA, GE0070W.LK_0070_S_QTD_RENOVA_AUTOMAT);

            /*" -844- MOVE GE089-IND-DPS TO LK-0070-S-IND-DPS */
            _.Move(GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_IND_DPS, GE0070W.LK_0070_S_IND_DPS);

            /*" -846- MOVE GE089-IND-REENQUADRA-PREMIO TO LK-0070-S-IND-REENQUADRA-PREM */
            _.Move(GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_IND_REENQUADRA_PREMIO, GE0070W.LK_0070_S_IND_REENQUADRA_PREM);

            /*" -848- MOVE GE089-IND-REAJUSTE-PREMIO TO LK-0070-S-IND-REAJUSTE-PREMIO */
            _.Move(GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_IND_REAJUSTE_PREMIO, GE0070W.LK_0070_S_IND_REAJUSTE_PREMIO);

            /*" -850- MOVE GE089-COD-INDICE-REAJUSTE TO LK-0070-S-COD-INDICE-REAJUSTE */
            _.Move(GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_COD_INDICE_REAJUSTE, GE0070W.LK_0070_S_COD_INDICE_REAJUSTE);

            /*" -852- MOVE GE089-COD-PERIOD-REAJUSTE TO LK-0070-S-COD-PERIOD-REAJUSTE */
            _.Move(GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_COD_PERIOD_REAJUSTE, GE0070W.LK_0070_S_COD_PERIOD_REAJUSTE);

            /*" -854- MOVE GE089-COD-INDICE-DEVOLUCAO TO LK-0070-S-COD-INDC-DEVOLUCAO */
            _.Move(GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_COD_INDICE_DEVOLUCAO, GE0070W.LK_0070_S_COD_INDC_DEVOLUCAO);

            /*" -856- MOVE GE089-PCT-JUROS-DEVOLUCAO TO LK-0070-S-PCT-JUROS-DEVOLUCAO */
            _.Move(GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_PCT_JUROS_DEVOLUCAO, GE0070W.LK_0070_S_PCT_JUROS_DEVOLUCAO);

            /*" -858- MOVE GE089-PCT-MULTA-DEVOLUCAO TO LK-0070-S-PCT-MULTA-DEVOLUCAO */
            _.Move(GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_PCT_MULTA_DEVOLUCAO, GE0070W.LK_0070_S_PCT_MULTA_DEVOLUCAO);

            /*" -860- MOVE GE089-IND-FLUXO-COMISSAO TO LK-0070-S-IND-FLUXO-COMISSAO */
            _.Move(GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_IND_FLUXO_COMISSAO, GE0070W.LK_0070_S_IND_FLUXO_COMISSAO);

            /*" -861- MOVE GE089-IND-ACOPLADO TO LK-0070-S-IND-ACOPLADO */
            _.Move(GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_IND_ACOPLADO, GE0070W.LK_0070_S_IND_ACOPLADO);

            /*" -863- MOVE GE089-IND-FLUXO-SINISTRO TO LK-0070-S-IND-FLUXO-SINISTRO */
            _.Move(GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_IND_FLUXO_SINISTRO, GE0070W.LK_0070_S_IND_FLUXO_SINISTRO);

            /*" -864- MOVE GE089-IND-CONJUGE TO LK-0070-S-IND-CONJUGE */
            _.Move(GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_IND_CONJUGE, GE0070W.LK_0070_S_IND_CONJUGE);

            /*" -865- MOVE GE089-COD-USUARIO TO LK-0070-S-COD-USUARIO */
            _.Move(GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_COD_USUARIO, GE0070W.LK_0070_S_COD_USUARIO);

            /*" -866- MOVE GE089-NOM-PROGRAMA TO LK-0070-S-NOM-PROGRAMA */
            _.Move(GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_NOM_PROGRAMA, GE0070W.LK_0070_S_NOM_PROGRAMA);

            /*" -869- MOVE GE089-DTH-CADASTRAMENTO TO LK-0070-S-DTH-CADASTRAMENTO */
            _.Move(GE089.DCLGE_PRODUTO_COMPLEMENTO.GE089_DTH_CADASTRAMENTO, GE0070W.LK_0070_S_DTH_CADASTRAMENTO);

            /*" -869- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0205_99_EXIT*/

        [StopWatch]
        /*" P9999-ERRO-SECTION */
        private void P9999_ERRO_SECTION()
        {
            /*" -881- DISPLAY '**********************************************' */
            _.Display($"**********************************************");

            /*" -882- DISPLAY '*            E R R O   G E 0 0 7 0 S         *' */
            _.Display($"*            E R R O   G E 0 0 7 0 S         *");

            /*" -883- DISPLAY '**********************************************' */
            _.Display($"**********************************************");

            /*" -884- DISPLAY '* SECTION............: ' WS-SECTION */
            _.Display($"* SECTION............: {WORK.WS_ERRO.WS_SECTION}");

            /*" -885- DISPLAY '* IND ERRO...........: ' WS-IND-ERRO */
            _.Display($"* IND ERRO...........: {WORK.WS_ERRO.WS_IND_ERRO}");

            /*" -886- DISPLAY '* TABELA.............: ' WS-TABELA */
            _.Display($"* TABELA.............: {WORK.WS_ERRO.WS_TABELA}");

            /*" -887- DISPLAY '* MENSAGEM...........: ' WS-MENSAGEM */
            _.Display($"* MENSAGEM...........: {WORK.WS_ERRO.WS_MENSAGEM}");

            /*" -888- DISPLAY '* SQLCODE............: ' WS-SQLCODE */
            _.Display($"* SQLCODE............: {WORK.WS_ERRO.WS_SQLCODE}");

            /*" -889- DISPLAY '* SQLERRMC...........: ' WS-SQLERRMC */
            _.Display($"* SQLERRMC...........: {WORK.WS_ERRO.WS_SQLERRMC}");

            /*" -890- DISPLAY '* SQLSTATE...........: ' WS-SQLSTATE */
            _.Display($"* SQLSTATE...........: {WORK.WS_ERRO.WS_SQLSTATE}");

            /*" -891- DISPLAY '**********************************************' */
            _.Display($"**********************************************");

            /*" -892- DISPLAY '*             DADOS DE ENTRADA               *' */
            _.Display($"*             DADOS DE ENTRADA               *");

            /*" -893- DISPLAY '**********************************************' */
            _.Display($"**********************************************");

            /*" -894- DISPLAY '* TRACE..............: ' LK-0070-E-TRACE */
            _.Display($"* TRACE..............: {GE0070W.LK_0070_E_TRACE}");

            /*" -895- DISPLAY '* COD-USUARIO........: ' LK-0070-E-COD-USUARIO */
            _.Display($"* COD-USUARIO........: {GE0070W.LK_0070_E_COD_USUARIO}");

            /*" -896- DISPLAY '* NOM-PROGRAMA.......: ' LK-0070-E-NOM-PROGRAMA */
            _.Display($"* NOM-PROGRAMA.......: {GE0070W.LK_0070_E_NOM_PROGRAMA}");

            /*" -897- MOVE LK-0070-E-ACAO TO WS-SMALLINT(01) */
            _.Move(GE0070W.LK_0070_E_ACAO, WORK.WS_EDIT.WS_SMALLINT[01]);

            /*" -898- DISPLAY '* ACAO...............: ' WS-SMALLINT(01) */
            _.Display($"* ACAO...............: {WORK.WS_EDIT.WS_SMALLINT[1]}");

            /*" -899- MOVE LK-0070-I-COD-PRODUTO TO WS-SMALLINT(01) */
            _.Move(GE0070W.LK_0070_I_COD_PRODUTO, WORK.WS_EDIT.WS_SMALLINT[01]);

            /*" -900- DISPLAY '* COD-PRODUTO........: ' WS-SMALLINT(01) */
            _.Display($"* COD-PRODUTO........: {WORK.WS_EDIT.WS_SMALLINT[1]}");

            /*" -901- MOVE LK-0070-I-SEQ-PRODUTO-VRS TO WS-SMALLINT(01) */
            _.Move(GE0070W.LK_0070_I_SEQ_PRODUTO_VRS, WORK.WS_EDIT.WS_SMALLINT[01]);

            /*" -902- DISPLAY '* SEQ-PRODUTO-VRS....: ' WS-SMALLINT(01) */
            _.Display($"* SEQ-PRODUTO-VRS....: {WORK.WS_EDIT.WS_SMALLINT[1]}");

            /*" -903- DISPLAY '* DTA-PROPOSTA.......: ' LK-0070-I-DTA-PROPOSTA */
            _.Display($"* DTA-PROPOSTA.......: {GE0070W.LK_0070_I_DTA_PROPOSTA}");

            /*" -905- DISPLAY '**********************************************' */
            _.Display($"**********************************************");

            /*" -906- MOVE WS-IND-ERRO TO LK-0070-IND-ERRO */
            _.Move(WORK.WS_ERRO.WS_IND_ERRO, GE0070W.LK_0070_IND_ERRO);

            /*" -907- MOVE WS-MENSAGEM TO LK-0070-MSG-ERRO */
            _.Move(WORK.WS_ERRO.WS_MENSAGEM, GE0070W.LK_0070_MSG_ERRO);

            /*" -908- MOVE WS-TABELA TO LK-0070-NOM-TABELA */
            _.Move(WORK.WS_ERRO.WS_TABELA, GE0070W.LK_0070_NOM_TABELA);

            /*" -909- MOVE WS-SQLCODE TO LK-0070-SQLCODE */
            _.Move(WORK.WS_ERRO.WS_SQLCODE, GE0070W.LK_0070_SQLCODE);

            /*" -910- MOVE WS-SQLERRMC TO LK-0070-SQLERRMC */
            _.Move(WORK.WS_ERRO.WS_SQLERRMC, GE0070W.LK_0070_SQLERRMC);

            /*" -912- MOVE WS-SQLSTATE TO LK-0070-SQLSTATE */
            _.Move(WORK.WS_ERRO.WS_SQLSTATE, GE0070W.LK_0070_SQLSTATE);

            /*" -912- . */

            /*" -0- FLUXCONTROL_PERFORM P9999_99_EXIT */

            P9999_99_EXIT();

        }

        [StopWatch]
        /*" P9999-99-EXIT */
        private void P9999_99_EXIT(bool isPerform = false)
        {
            /*" -915- GOBACK. */

            throw new GoBack();

        }
    }
}