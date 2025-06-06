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
using Sias.Outros.DB2.SPBVG009;

namespace Code
{
    public class SPBVG009
    {
        public bool IsCall { get; set; }

        public SPBVG009()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      * SISTEMA.........: SIAS                                         *      */
        /*"      * MODULO..........: VIDA                                         *      */
        /*"      * PROGRAMA........: SPBVG009                                     *      */
        /*"      * ANALISTA........: HUSNI ALI HUSNI                              *      */
        /*"      * DATA............: 25/03/2022                                   *      */
        /*"      * DEMANDA.........: 294878     TAREFA..........: 340464          *      */
        /*"      ******************************************************************      */
        /*"      * OBJETIVO........: CONSULTAR INFORMACOES DE RISCO DA PROPOSTA   *      */
        /*"      *                   (SEGUROS.VG_C612_INFO_RISCO)                 *      */
        /*"      *                   OBSERVA��O:                                  *      */
        /*"      *                   - DOCUMENTACAO DOS CAMPOS NO BOOK DE LINKAGE *      */
        /*"      *                   LK-VG009-E-TIPO-ACAO                         *      */
        /*"      *                   (01) CONSULTAR INFORMACOES DE RISCO          *      */
        /*"      *                        ATRAVES DO NUM_PROPOSTA                 *      */
        /*"      ******************************************************************      */
        /*"      * VERSAO     DATA     RESPONSAVEL       ALTERACAO                *      */
        /*"      ******************************************************************      */
        /*"      * V.001   25/03/2022  ELIERMES OLIVEIRA CRIACAO DO PROGRAMA      *      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"01    WORK.*/
        public SPBVG009_WORK WORK { get; set; } = new SPBVG009_WORK();
        public class SPBVG009_WORK : VarBasis
        {
            /*"  05  WS-PROGRAMA                    PIC  X(008) VALUE SPACES.*/
            public StringBasis WS_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"  05  WS-CONTADORES.*/
            public SPBVG009_WS_CONTADORES WS_CONTADORES { get; set; } = new SPBVG009_WS_CONTADORES();
            public class SPBVG009_WS_CONTADORES : VarBasis
            {
                /*"   10 WS-I                           PIC S9(004) COMP VALUE 0.*/
                public IntBasis WS_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"  05  WS-DATAS.*/
            }
            public SPBVG009_WS_DATAS WS_DATAS { get; set; } = new SPBVG009_WS_DATAS();
            public class SPBVG009_WS_DATAS : VarBasis
            {
                /*"   10 WS-C-DATE-CURRENT              PIC  X(014) VALUE SPACES.*/
                public StringBasis WS_C_DATE_CURRENT { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
                /*"   10 WS-C-DATE-COMPILED             PIC  X(014) VALUE SPACES.*/
                public StringBasis WS_C_DATE_COMPILED { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
                /*"  05  WS-EDIT.*/
            }
            public SPBVG009_WS_EDIT WS_EDIT { get; set; } = new SPBVG009_WS_EDIT();
            public class SPBVG009_WS_EDIT : VarBasis
            {
                /*"   10 WS-SMALLINT                    PIC ZZ.ZZ9- OCCURS 5 TIMES.*/
                public ListBasis<IntBasis, Int64> WS_SMALLINT { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "6", "ZZ.ZZ9-"), 5);
                /*"   10 WS-INTEGER                     PIC Z.ZZZ.ZZZ.ZZ9-                                                 OCCURS 5 TIMES.*/
                public ListBasis<IntBasis, Int64> WS_INTEGER { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "11", "Z.ZZZ.ZZZ.ZZ9-"), 5);
                /*"   10 WS-BIGINT                      PIC 99999999999999                                                 OCCURS 5 TIMES.*/
                public ListBasis<IntBasis, Int64> WS_BIGINT { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "14", "99999999999999"), 5);
                /*"   10 WS-DECIMAL                     PIC ZZZZZZZZZZ9,999999                                                 OCCURS 5 TIMES.*/
                public ListBasis<DoubleBasis, double> WS_DECIMAL { get; set; } = new ListBasis<DoubleBasis, double>(new PIC("9", "11", "ZZZZZZZZZZ9V999999"), 5);
                /*"  05  WS-ERRO.*/
            }
            public SPBVG009_WS_ERRO WS_ERRO { get; set; } = new SPBVG009_WS_ERRO();
            public class SPBVG009_WS_ERRO : VarBasis
            {
                /*"   10 WS-SECTION                     PIC  X(005) VALUE SPACES.*/
                public StringBasis WS_SECTION { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"   10 WS-SQLCODE                     PIC  ZZZZ9-.*/
                public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("9", "6", "ZZZZ9-."));
                /*"   10 WS-SQLERRMC                    PIC  X(076) VALUE SPACES.*/
                public StringBasis WS_SQLERRMC { get; set; } = new StringBasis(new PIC("X", "76", "X(076)"), @"");
                /*"   10 WS-MENSAGEM                    PIC  X(255) VALUE SPACES.*/
                public StringBasis WS_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "255", "X(255)"), @"");
                /*"   10 WS-TABELA                      PIC  X(050) VALUE SPACES.*/
                public StringBasis WS_TABELA { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
                /*"   10 WS-IND-ERRO                    PIC  9(001) VALUE 0.*/
                public IntBasis WS_IND_ERRO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            }
        }


        public Copies.SPVG009W SPVG009W { get; set; } = new Copies.SPVG009W();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.VG110 VG110 { get; set; } = new Dclgens.VG110();
        public Dclgens.VG113 VG113 { get; set; } = new Dclgens.VG113();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(SPVG009W SPVG009W_P) //PROCEDURE DIVISION USING 
        /*PROCEDURE DIVISION
        LK_VG009_E_TRACE
        LK_VG009_E_COD_USUARIO
        LK_VG009_E_NOM_PROGRAMA
        LK_VG009_E_TIPO_ACAO
        LK_VG009_E_NUM_PROPOSTA
        LK_VG009_S_COD_PESSOA
        LK_VG009_S_SEQ_PESSOA_HIST
        LK_VG009_S_COD_CLASSIF_RISCO
        LK_VG009_S_NUM_SCORE_RISCO
        LK_VG009_S_DTA_CLASSIF_RISCO
        LK_VG009_S_IND_PEND_APROVACAO
        LK_VG009_S_IND_DECL_AUTOMATICO
        LK_VG009_S_IND_ATLZ_FXA_RISCO
        LK_VG009_IND_ERRO
        LK_VG009_MSG_ERRO
        LK_VG009_NOM_TABELA
        LK_VG009_SQLCODE
        LK_VG009_SQLERRMC*/
        {
            try
            {
                this.SPVG009W = SPVG009W_P;

                /*" -0- FLUXCONTROL_PERFORM P0000-INICIALIZAR-SECTION */

                P0000_INICIALIZAR_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { SPVG009W };
            return Result;
        }

        [StopWatch]
        /*" P0000-INICIALIZAR-SECTION */
        private void P0000_INICIALIZAR_SECTION()
        {
            /*" -129- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -130- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -131- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -134- MOVE FUNCTION CURRENT-DATE(1:14) TO WS-C-DATE-CURRENT. */
            _.Move(_.CurrentDate(0, 14), WORK.WS_DATAS.WS_C_DATE_CURRENT);

            /*" -136- MOVE FUNCTION WHEN-COMPILED TO WS-C-DATE-COMPILED. */
            _.Move(_.WhenCompiled(), WORK.WS_DATAS.WS_C_DATE_COMPILED);

            /*" -140- INITIALIZE LK-VG009-IND-ERRO LK-VG009-MSG-ERRO LK-VG009-NOM-TABELA LK-VG009-SQLCODE LK-VG009-SQLERRMC WS-ERRO */
            _.Initialize(
                SPVG009W.LK_VG009_IND_ERRO
                , SPVG009W.LK_VG009_MSG_ERRO
                , SPVG009W.LK_VG009_NOM_TABELA
                , SPVG009W.LK_VG009_SQLCODE
                , SPVG009W.LK_VG009_SQLERRMC
                , WORK.WS_ERRO
            );

            /*" -141- IF NOT ( LK-VG009-E-TRACE = 'S' OR = 'N' ) */

            if (!(SPVG009W.LK_VG009_E_TRACE.In("S", "N")))
            {

                /*" -142- MOVE 'N' TO LK-VG009-E-TRACE */
                _.Move("N", SPVG009W.LK_VG009_E_TRACE);

                /*" -144- END-IF */
            }


            /*" -146- PERFORM P0050-VERIFICAR-SISTEMA */

            P0050_VERIFICAR_SISTEMA_SECTION();

            /*" -147- IF LK-VG009-E-TRACE = 'S' */

            if (SPVG009W.LK_VG009_E_TRACE == "S")
            {

                /*" -148- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -149- DISPLAY '*            S P B V G 0 0 9                 *' */
                _.Display($"*            S P B V G 0 0 9                 *");

                /*" -150- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -157- DISPLAY '* DATA COMPILACAO..: ' WS-C-DATE-COMPILED(7:2) '/' WS-C-DATE-COMPILED(5:2) '/' WS-C-DATE-COMPILED(1:4) '-' WS-C-DATE-COMPILED(9:2) ':' WS-C-DATE-COMPILED(11:2) ':' WS-C-DATE-COMPILED(13:2) */

                $"* DATA COMPILACAO..: {WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(7, 2)}/{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(5, 2)}/{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(1, 4)}-{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(9, 2)}:{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(11, 2)}:{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(13, 2)}"
                .Display();

                /*" -164- DISPLAY '* DATA EXECUCAO....: ' WS-C-DATE-CURRENT(7:2) '/' WS-C-DATE-CURRENT(5:2) '/' WS-C-DATE-CURRENT(1:4) '-' WS-C-DATE-CURRENT(9:2) ':' WS-C-DATE-CURRENT(11:2) ':' WS-C-DATE-CURRENT(13:2) */

                $"* DATA EXECUCAO....: {WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(7, 2)}/{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(5, 2)}/{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(1, 4)}-{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(9, 2)}:{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(11, 2)}:{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(13, 2)}"
                .Display();

                /*" -168- DISPLAY '* DATA SISTEMA.....: ' SISTEMAS-DATA-MOV-ABERTO(9:2) '/' SISTEMAS-DATA-MOV-ABERTO(6:2) '/' SISTEMAS-DATA-MOV-ABERTO(1:4) */

                $"* DATA SISTEMA.....: {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2)}/{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2)}/{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4)}"
                .Display();

                /*" -169- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -170- DISPLAY '*             DADOS DE ENTRADA               *' */
                _.Display($"*             DADOS DE ENTRADA               *");

                /*" -171- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -172- DISPLAY '* TRACE............: ' LK-VG009-E-TRACE */
                _.Display($"* TRACE............: {SPVG009W.LK_VG009_E_TRACE}");

                /*" -173- DISPLAY '* COD-USUARIO......: ' LK-VG009-E-COD-USUARIO */
                _.Display($"* COD-USUARIO......: {SPVG009W.LK_VG009_E_COD_USUARIO}");

                /*" -174- DISPLAY '* NOM-PROGRAMA.....: ' LK-VG009-E-NOM-PROGRAMA */
                _.Display($"* NOM-PROGRAMA.....: {SPVG009W.LK_VG009_E_NOM_PROGRAMA}");

                /*" -175- MOVE LK-VG009-E-TIPO-ACAO TO WS-SMALLINT(01) */
                _.Move(SPVG009W.LK_VG009_E_TIPO_ACAO, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -176- DISPLAY '* TIPO-ACAO........: ' WS-SMALLINT(01) */
                _.Display($"* TIPO-ACAO........: {WORK.WS_EDIT.WS_SMALLINT[1]}");

                /*" -177- MOVE LK-VG009-E-NUM-PROPOSTA TO WS-BIGINT(01) */
                _.Move(SPVG009W.LK_VG009_E_NUM_PROPOSTA, WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -178- DISPLAY '* NUM-PROPOSTA.....: ' WS-BIGINT(01) */
                _.Display($"* NUM-PROPOSTA.....: {WORK.WS_EDIT.WS_BIGINT[1]}");

                /*" -179- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -181- END-IF */
            }


            /*" -181- PERFORM P0005-PROCESSAR. */

            P0005_PROCESSAR_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0000_99_EXIT*/

        [StopWatch]
        /*" P0005-PROCESSAR-SECTION */
        private void P0005_PROCESSAR_SECTION()
        {
            /*" -193- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0005_00_START */

            P0005_00_START();

        }

        [StopWatch]
        /*" P0005-00-START */
        private void P0005_00_START(bool isPerform = false)
        {
            /*" -196- MOVE 'P0005' TO WS-SECTION. */
            _.Move("P0005", WORK.WS_ERRO.WS_SECTION);

            /*" -196- PERFORM P0005-05-INICIO. */

            P0005_05_INICIO(true);

        }

        [StopWatch]
        /*" P0005-05-INICIO */
        private void P0005_05_INICIO(bool isPerform = false)
        {
            /*" -203- PERFORM P0100-VALIDAR-LINKAGE. */

            P0100_VALIDAR_LINKAGE_SECTION();

            /*" -204-  EVALUATE TRUE  */

            /*" -206-  WHEN LK-VG009-E-TIPO-ACAO     = 01  */

            /*" -206- IF LK-VG009-E-TIPO-ACAO     = 01 */

            if (SPVG009W.LK_VG009_E_TIPO_ACAO == 01)
            {

                /*" -207- PERFORM P0301-TRATAR-TIPO-ACAO-01 */

                P0301_TRATAR_TIPO_ACAO_01_SECTION();

                /*" -208-  WHEN OTHER  */

                /*" -208- ELSE */
            }
            else
            {


                /*" -209- MOVE 'P0005' TO WS-SECTION */
                _.Move("P0005", WORK.WS_ERRO.WS_SECTION);

                /*" -210- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -211- MOVE LK-VG009-E-TIPO-ACAO TO WS-SMALLINT(01) */
                _.Move(SPVG009W.LK_VG009_E_TIPO_ACAO, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -215- STRING WS-SECTION ' - TIPO DE ACAO INFORMADA INVALIDA.' '<TIPO_ACAO=' WS-SMALLINT(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl1 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl1 += " - TIPO DE ACAO INFORMADA INVALIDA.";
                spl1 += "<TIPO_ACAO=";
                var spl2 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl2 += ">";
                var results3 = spl1 + spl2;
                _.Move(results3, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -216- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -217- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -218- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -220-  END-EVALUATE  */

                /*" -220- END-IF */
            }


            /*" -220- PERFORM P0010-FINALIZAR. */

            P0010_FINALIZAR_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0005_99_EXIT*/

        [StopWatch]
        /*" P0010-FINALIZAR-SECTION */
        private void P0010_FINALIZAR_SECTION()
        {
            /*" -232- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0010_00_START */

            P0010_00_START();

        }

        [StopWatch]
        /*" P0010-00-START */
        private void P0010_00_START(bool isPerform = false)
        {
            /*" -235- MOVE 'P0010' TO WS-SECTION. */
            _.Move("P0010", WORK.WS_ERRO.WS_SECTION);

            /*" -235- PERFORM P0010-05-INICIO. */

            P0010_05_INICIO(true);

        }

        [StopWatch]
        /*" P0010-05-INICIO */
        private void P0010_05_INICIO(bool isPerform = false)
        {
            /*" -241- MOVE 0 TO WS-IND-ERRO */
            _.Move(0, WORK.WS_ERRO.WS_IND_ERRO);

            /*" -243- STRING 'OPERACAO SOLICITADA REALIZADA COM SUCESSO.' DELIMITED BY SIZE INTO WS-MENSAGEM */
            #region STRING
            var spl3 = "OPERACAO SOLICITADA REALIZADA COM SUCESSO.";
            _.Move(spl3, WORK.WS_ERRO.WS_MENSAGEM);
            #endregion

            /*" -244- MOVE WS-MENSAGEM TO LK-VG009-MSG-ERRO */
            _.Move(WORK.WS_ERRO.WS_MENSAGEM, SPVG009W.LK_VG009_MSG_ERRO);

            /*" -245- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
            _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

            /*" -247- MOVE 0 TO WS-SQLCODE */
            _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

            /*" -247- PERFORM P0010-99-EXIT. */

            P0010_99_EXIT(true);

        }

        [StopWatch]
        /*" P0010-99-EXIT */
        private void P0010_99_EXIT(bool isPerform = false)
        {
            /*" -251- GOBACK. */

            throw new GoBack();

        }

        [StopWatch]
        /*" P0050-VERIFICAR-SISTEMA-SECTION */
        private void P0050_VERIFICAR_SISTEMA_SECTION()
        {
            /*" -259- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0050_00_START */

            P0050_00_START();

        }

        [StopWatch]
        /*" P0050-00-START */
        private void P0050_00_START(bool isPerform = false)
        {
            /*" -262- MOVE 'P0050' TO WS-SECTION. */
            _.Move("P0050", WORK.WS_ERRO.WS_SECTION);

            /*" -262- PERFORM P0050-05-INICIO. */

            P0050_05_INICIO(true);

        }

        [StopWatch]
        /*" P0050-05-INICIO */
        private void P0050_05_INICIO(bool isPerform = false)
        {
            /*" -272- PERFORM P0050_05_INICIO_DB_SELECT_1 */

            P0050_05_INICIO_DB_SELECT_1();

            /*" -275- IF NOT ( SQLCODE = 0 OR = 100 ) */

            if (!(DB.SQLCODE.In("0", "100")))
            {

                /*" -276- MOVE 'P0050' TO WS-SECTION */
                _.Move("P0050", WORK.WS_ERRO.WS_SECTION);

                /*" -277- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -281- STRING WS-SECTION ' - ERRO NO SELECT NA SEGUROS.SISTEMA.' '<SISTEMA=VG>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl4 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl4 += " - ERRO NO SELECT NA SEGUROS.SISTEMA.";
                spl4 += "<SISTEMA=VG>";
                _.Move(spl4, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -282- MOVE 'SEGUROS.SISTEMA' TO WS-TABELA */
                _.Move("SEGUROS.SISTEMA", WORK.WS_ERRO.WS_TABELA);

                /*" -283- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -284- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -285- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -287- END-IF */
            }


            /*" -288- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -289- MOVE 'P0050' TO WS-SECTION */
                _.Move("P0050", WORK.WS_ERRO.WS_SECTION);

                /*" -290- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -294- STRING WS-SECTION ' - REGISTRO DE CONTROLE SISTEMA NAO CADASTRADO.' '<SISTEMA=VG>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl5 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl5 += " - REGISTRO DE CONTROLE SISTEMA NAO CADASTRADO.";
                spl5 += "<SISTEMA=VG>";
                _.Move(spl5, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -295- MOVE 'SEGUROS.SISTEMA' TO WS-TABELA */
                _.Move("SEGUROS.SISTEMA", WORK.WS_ERRO.WS_TABELA);

                /*" -296- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -297- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -298- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -298- END-IF. */
            }


        }

        [StopWatch]
        /*" P0050-05-INICIO-DB-SELECT-1 */
        public void P0050_05_INICIO_DB_SELECT_1()
        {
            /*" -272- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VG' WITH UR END-EXEC. */

            var p0050_05_INICIO_DB_SELECT_1_Query1 = new P0050_05_INICIO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = P0050_05_INICIO_DB_SELECT_1_Query1.Execute(p0050_05_INICIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0050_EXIT*/

        [StopWatch]
        /*" P0100-VALIDAR-LINKAGE-SECTION */
        private void P0100_VALIDAR_LINKAGE_SECTION()
        {
            /*" -309- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0100_00_START */

            P0100_00_START();

        }

        [StopWatch]
        /*" P0100-00-START */
        private void P0100_00_START(bool isPerform = false)
        {
            /*" -313- MOVE 'P0100' TO WS-SECTION. */
            _.Move("P0100", WORK.WS_ERRO.WS_SECTION);

            /*" -316- INITIALIZE DCLVG-C612-RELAC-PROPOSTA DCLVG-C612-INFO-RISCO */
            _.Initialize(
                VG110.DCLVG_C612_RELAC_PROPOSTA
                , VG113.DCLVG_C612_INFO_RISCO
            );

            /*" -316- PERFORM P0100-05-INICIO. */

            P0100_05_INICIO(true);

        }

        [StopWatch]
        /*" P0100-05-INICIO */
        private void P0100_05_INICIO(bool isPerform = false)
        {
            /*" -322- IF LK-VG009-E-COD-USUARIO = SPACES */

            if (SPVG009W.LK_VG009_E_COD_USUARIO.IsEmpty())
            {

                /*" -323- MOVE 'P0100' TO WS-SECTION */
                _.Move("P0100", WORK.WS_ERRO.WS_SECTION);

                /*" -324- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -328- STRING WS-SECTION ' - CODIGO DO USUARIO NAO INFORMADO.' '<COD_USUARIO=' LK-VG009-E-COD-USUARIO '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl6 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl6 += " - CODIGO DO USUARIO NAO INFORMADO.";
                spl6 += "<COD_USUARIO=";
                var spl7 = SPVG009W.LK_VG009_E_COD_USUARIO.GetMoveValues();
                spl7 += ">";
                var results8 = spl6 + spl7;
                _.Move(results8, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -329- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -330- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -331- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -333- END-IF */
            }


            /*" -334- IF LK-VG009-E-NOM-PROGRAMA = SPACES */

            if (SPVG009W.LK_VG009_E_NOM_PROGRAMA.IsEmpty())
            {

                /*" -335- MOVE 'P0100' TO WS-SECTION */
                _.Move("P0100", WORK.WS_ERRO.WS_SECTION);

                /*" -336- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -340- STRING WS-SECTION ' - NOME DO PROGRAMA NAO INFORMADO.' '<NOM_PROGRAMA=' LK-VG009-E-NOM-PROGRAMA '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl8 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl8 += " - NOME DO PROGRAMA NAO INFORMADO.";
                spl8 += "<NOM_PROGRAMA=";
                var spl9 = SPVG009W.LK_VG009_E_NOM_PROGRAMA.GetMoveValues();
                spl9 += ">";
                var results10 = spl8 + spl9;
                _.Move(results10, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -341- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -342- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -343- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -346- END-IF */
            }


            /*" -347-  EVALUATE TRUE  */

            /*" -348-  WHEN LK-VG009-E-TIPO-ACAO    = 01  */

            /*" -348- IF LK-VG009-E-TIPO-ACAO    = 01 */

            if (SPVG009W.LK_VG009_E_TIPO_ACAO == 01)
            {

                /*" -349- PERFORM P0102-VALIDAR-CONSULTA-VG110 */

                P0102_VALIDAR_CONSULTA_VG110_SECTION();

                /*" -350-  WHEN OTHER  */

                /*" -350- ELSE */
            }
            else
            {


                /*" -351- MOVE 'P0100' TO WS-SECTION */
                _.Move("P0100", WORK.WS_ERRO.WS_SECTION);

                /*" -352- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -353- MOVE LK-VG009-E-TIPO-ACAO TO WS-SMALLINT(01) */
                _.Move(SPVG009W.LK_VG009_E_TIPO_ACAO, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -357- STRING WS-SECTION ' - TIPO DE ACAO INFORMADA INVALIDA.' '<TIPO_ACAO=' WS-SMALLINT(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl10 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl10 += " - TIPO DE ACAO INFORMADA INVALIDA.";
                spl10 += "<TIPO_ACAO=";
                var spl11 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl11 += ">";
                var results12 = spl10 + spl11;
                _.Move(results12, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -358- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -359- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -360- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -362-  END-EVALUATE  */

                /*" -362- END-IF */
            }


            /*" -362- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0100_99_EXIT*/

        [StopWatch]
        /*" P0102-VALIDAR-CONSULTA-VG110-SECTION */
        private void P0102_VALIDAR_CONSULTA_VG110_SECTION()
        {
            /*" -373- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0102_00_START */

            P0102_00_START();

        }

        [StopWatch]
        /*" P0102-00-START */
        private void P0102_00_START(bool isPerform = false)
        {
            /*" -378- MOVE 'P0102' TO WS-SECTION */
            _.Move("P0102", WORK.WS_ERRO.WS_SECTION);

            /*" -378- PERFORM P0102-10-INICIO. */

            P0102_10_INICIO(true);

        }

        [StopWatch]
        /*" P0102-10-INICIO */
        private void P0102_10_INICIO(bool isPerform = false)
        {
            /*" -385- IF LK-VG009-E-NUM-PROPOSTA EQUAL ZEROS */

            if (SPVG009W.LK_VG009_E_NUM_PROPOSTA == 00)
            {

                /*" -386- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -387- MOVE LK-VG009-E-NUM-PROPOSTA TO WS-BIGINT(01) */
                _.Move(SPVG009W.LK_VG009_E_NUM_PROPOSTA, WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -391- STRING WS-SECTION ' - NUMERO DA PROPOSTA NAO INFORMADO.' ' NUM_PROPOSTA = ' WS-BIGINT(01) DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl12 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl12 += " - NUMERO DA PROPOSTA NAO INFORMADO.";
                spl12 += " NUM_PROPOSTA = ";
                var spl13 = WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                var results14 = spl12 + spl13;
                _.Move(results14, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -392- MOVE SPACES TO WS-TABELA WS-SQLERRMC */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -393- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -394- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -398- END-IF */
            }


            /*" -398- PERFORM P3021-CONS-RELAC-PROPOSTA. */

            P3021_CONS_RELAC_PROPOSTA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0102_99_EXIT*/

        [StopWatch]
        /*" P0301-TRATAR-TIPO-ACAO-01-SECTION */
        private void P0301_TRATAR_TIPO_ACAO_01_SECTION()
        {
            /*" -409- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P0301_00_START */

            P0301_00_START();

        }

        [StopWatch]
        /*" P0301-00-START */
        private void P0301_00_START(bool isPerform = false)
        {
            /*" -414- MOVE 'P0301' TO WS-SECTION */
            _.Move("P0301", WORK.WS_ERRO.WS_SECTION);

            /*" -414- PERFORM P0301-05-INICIO. */

            P0301_05_INICIO(true);

        }

        [StopWatch]
        /*" P0301-05-INICIO */
        private void P0301_05_INICIO(bool isPerform = false)
        {
            /*" -440- PERFORM P0301_05_INICIO_DB_SELECT_1 */

            P0301_05_INICIO_DB_SELECT_1();

            /*" -443- IF NOT ( SQLCODE = 0 OR = 100 ) */

            if (!(DB.SQLCODE.In("0", "100")))
            {

                /*" -444- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -445- MOVE VG110-NUM-PROPOSTA TO WS-BIGINT(01) */
                _.Move(VG110.DCLVG_C612_RELAC_PROPOSTA.VG110_NUM_PROPOSTA, WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -446- MOVE VG110-COD-PESSOA TO WS-INTEGER(01) */
                _.Move(VG110.DCLVG_C612_RELAC_PROPOSTA.VG110_COD_PESSOA, WORK.WS_EDIT.WS_INTEGER[01]);

                /*" -447- MOVE VG110-SEQ-PESSOA-HIST TO WS-INTEGER(02) */
                _.Move(VG110.DCLVG_C612_RELAC_PROPOSTA.VG110_SEQ_PESSOA_HIST, WORK.WS_EDIT.WS_INTEGER[02]);

                /*" -453- STRING WS-SECTION ' - ERRO NO SELECT SEGUROS.VG_C612_INFO_RISCO.' ' COD_PESSOA = ' WS-INTEGER(01) ' SEQ_PESSOA-HIST = ' WS-INTEGER(02) ' NUM_PROPOSTA = ' WS-BIGINT(01) DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl14 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl14 += " - ERRO NO SELECT SEGUROS.VG_C612_INFO_RISCO.";
                spl14 += " COD_PESSOA = ";
                var spl15 = WORK.WS_EDIT.WS_INTEGER[01].GetMoveValues();
                spl15 += " SEQ_PESSOA-HIST = ";
                var spl16 = WORK.WS_EDIT.WS_INTEGER[02].GetMoveValues();
                spl16 += " NUM_PROPOSTA = ";
                var spl17 = WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                var results18 = spl14 + spl15 + spl16 + spl17;
                _.Move(results18, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -455- MOVE 'SEGUROS.VG_C612_INFO_RISCO' TO WS-TABELA */
                _.Move("SEGUROS.VG_C612_INFO_RISCO", WORK.WS_ERRO.WS_TABELA);

                /*" -456- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -457- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -458- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -460- END-IF. */
            }


            /*" -461- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -462- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -463- MOVE VG110-NUM-PROPOSTA TO WS-BIGINT(01) */
                _.Move(VG110.DCLVG_C612_RELAC_PROPOSTA.VG110_NUM_PROPOSTA, WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -464- MOVE VG110-COD-PESSOA TO WS-INTEGER(01) */
                _.Move(VG110.DCLVG_C612_RELAC_PROPOSTA.VG110_COD_PESSOA, WORK.WS_EDIT.WS_INTEGER[01]);

                /*" -465- MOVE VG110-SEQ-PESSOA-HIST TO WS-INTEGER(02) */
                _.Move(VG110.DCLVG_C612_RELAC_PROPOSTA.VG110_SEQ_PESSOA_HIST, WORK.WS_EDIT.WS_INTEGER[02]);

                /*" -471- STRING WS-SECTION ' - NUM-PROPOSTA/COD-PESSOA NAO CADASTRADO.' ' COD_PESSOA = ' WS-INTEGER(01) ' SEQ_PESSOA-HIST = ' WS-INTEGER(02) ' NUM_PROPOSTA = ' WS-BIGINT(01) DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl18 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl18 += " - NUM-PROPOSTA/COD-PESSOA NAO CADASTRADO.";
                spl18 += " COD_PESSOA = ";
                var spl19 = WORK.WS_EDIT.WS_INTEGER[01].GetMoveValues();
                spl19 += " SEQ_PESSOA-HIST = ";
                var spl20 = WORK.WS_EDIT.WS_INTEGER[02].GetMoveValues();
                spl20 += " NUM_PROPOSTA = ";
                var spl21 = WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                var results22 = spl18 + spl19 + spl20 + spl21;
                _.Move(results22, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -473- MOVE 'SEGUROS.VG_C612_INFO_RISCO' TO WS-TABELA */
                _.Move("SEGUROS.VG_C612_INFO_RISCO", WORK.WS_ERRO.WS_TABELA);

                /*" -474- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -475- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -476- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -478- END-IF */
            }


            /*" -480- MOVE VG113-COD-PESSOA TO LK-VG009-S-COD-PESSOA */
            _.Move(VG113.DCLVG_C612_INFO_RISCO.VG113_COD_PESSOA, SPVG009W.LK_VG009_S_COD_PESSOA);

            /*" -482- MOVE VG113-SEQ-PESSOA-HIST TO LK-VG009-S-SEQ-PESSOA-HIST */
            _.Move(VG113.DCLVG_C612_INFO_RISCO.VG113_SEQ_PESSOA_HIST, SPVG009W.LK_VG009_S_SEQ_PESSOA_HIST);

            /*" -484- MOVE VG113-COD-CLASSIF-RISCO TO LK-VG009-S-COD-CLASSIF-RISCO */
            _.Move(VG113.DCLVG_C612_INFO_RISCO.VG113_COD_CLASSIF_RISCO, SPVG009W.LK_VG009_S_COD_CLASSIF_RISCO);

            /*" -486- MOVE VG113-NUM-SCORE-RISCO TO LK-VG009-S-NUM-SCORE-RISCO */
            _.Move(VG113.DCLVG_C612_INFO_RISCO.VG113_NUM_SCORE_RISCO, SPVG009W.LK_VG009_S_NUM_SCORE_RISCO);

            /*" -488- MOVE VG113-DTA-CLASSIF-RISCO TO LK-VG009-S-DTA-CLASSIF-RISCO */
            _.Move(VG113.DCLVG_C612_INFO_RISCO.VG113_DTA_CLASSIF_RISCO, SPVG009W.LK_VG009_S_DTA_CLASSIF_RISCO);

            /*" -490- MOVE VG113-IND-PEND-APROVACAO TO LK-VG009-S-IND-PEND-APROVACAO */
            _.Move(VG113.DCLVG_C612_INFO_RISCO.VG113_IND_PEND_APROVACAO, SPVG009W.LK_VG009_S_IND_PEND_APROVACAO);

            /*" -492- MOVE VG113-IND-DECL-AUTOMATICO TO LK-VG009-S-IND-DECL-AUTOMATICO */
            _.Move(VG113.DCLVG_C612_INFO_RISCO.VG113_IND_DECL_AUTOMATICO, SPVG009W.LK_VG009_S_IND_DECL_AUTOMATICO);

            /*" -495- MOVE VG113-IND-ATLZ-FAIXA-RISCO TO LK-VG009-S-IND-ATLZ-FXA-RISCO */
            _.Move(VG113.DCLVG_C612_INFO_RISCO.VG113_IND_ATLZ_FAIXA_RISCO, SPVG009W.LK_VG009_S_IND_ATLZ_FXA_RISCO);

            /*" -495- . */

        }

        [StopWatch]
        /*" P0301-05-INICIO-DB-SELECT-1 */
        public void P0301_05_INICIO_DB_SELECT_1()
        {
            /*" -440- EXEC SQL SELECT COD_PESSOA , SEQ_PESSOA_HIST , COD_CLASSIF_RISCO , NUM_SCORE_RISCO , DTA_CLASSIF_RISCO , IND_PEND_APROVACAO , IND_DECL_AUTOMATICO , IND_ATLZ_FAIXA_RISCO INTO :VG113-COD-PESSOA , :VG113-SEQ-PESSOA-HIST , :VG113-COD-CLASSIF-RISCO , :VG113-NUM-SCORE-RISCO , :VG113-DTA-CLASSIF-RISCO , :VG113-IND-PEND-APROVACAO , :VG113-IND-DECL-AUTOMATICO , :VG113-IND-ATLZ-FAIXA-RISCO FROM SEGUROS.VG_C612_INFO_RISCO WHERE COD_PESSOA = :VG110-COD-PESSOA AND SEQ_PESSOA_HIST = :VG110-SEQ-PESSOA-HIST WITH UR END-EXEC */

            var p0301_05_INICIO_DB_SELECT_1_Query1 = new P0301_05_INICIO_DB_SELECT_1_Query1()
            {
                VG110_SEQ_PESSOA_HIST = VG110.DCLVG_C612_RELAC_PROPOSTA.VG110_SEQ_PESSOA_HIST.ToString(),
                VG110_COD_PESSOA = VG110.DCLVG_C612_RELAC_PROPOSTA.VG110_COD_PESSOA.ToString(),
            };

            var executed_1 = P0301_05_INICIO_DB_SELECT_1_Query1.Execute(p0301_05_INICIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VG113_COD_PESSOA, VG113.DCLVG_C612_INFO_RISCO.VG113_COD_PESSOA);
                _.Move(executed_1.VG113_SEQ_PESSOA_HIST, VG113.DCLVG_C612_INFO_RISCO.VG113_SEQ_PESSOA_HIST);
                _.Move(executed_1.VG113_COD_CLASSIF_RISCO, VG113.DCLVG_C612_INFO_RISCO.VG113_COD_CLASSIF_RISCO);
                _.Move(executed_1.VG113_NUM_SCORE_RISCO, VG113.DCLVG_C612_INFO_RISCO.VG113_NUM_SCORE_RISCO);
                _.Move(executed_1.VG113_DTA_CLASSIF_RISCO, VG113.DCLVG_C612_INFO_RISCO.VG113_DTA_CLASSIF_RISCO);
                _.Move(executed_1.VG113_IND_PEND_APROVACAO, VG113.DCLVG_C612_INFO_RISCO.VG113_IND_PEND_APROVACAO);
                _.Move(executed_1.VG113_IND_DECL_AUTOMATICO, VG113.DCLVG_C612_INFO_RISCO.VG113_IND_DECL_AUTOMATICO);
                _.Move(executed_1.VG113_IND_ATLZ_FAIXA_RISCO, VG113.DCLVG_C612_INFO_RISCO.VG113_IND_ATLZ_FAIXA_RISCO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P0301_99_EXIT*/

        [StopWatch]
        /*" P3021-CONS-RELAC-PROPOSTA-SECTION */
        private void P3021_CONS_RELAC_PROPOSTA_SECTION()
        {
            /*" -506- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM P3021_00_START */

            P3021_00_START();

        }

        [StopWatch]
        /*" P3021-00-START */
        private void P3021_00_START(bool isPerform = false)
        {
            /*" -510- MOVE 'P3021' TO WS-SECTION */
            _.Move("P3021", WORK.WS_ERRO.WS_SECTION);

            /*" -512- MOVE LK-VG009-E-NUM-PROPOSTA TO VG110-NUM-PROPOSTA */
            _.Move(SPVG009W.LK_VG009_E_NUM_PROPOSTA, VG110.DCLVG_C612_RELAC_PROPOSTA.VG110_NUM_PROPOSTA);

            /*" -512- PERFORM P3021-05-INICIO. */

            P3021_05_INICIO(true);

        }

        [StopWatch]
        /*" P3021-05-INICIO */
        private void P3021_05_INICIO(bool isPerform = false)
        {
            /*" -528- PERFORM P3021_05_INICIO_DB_SELECT_1 */

            P3021_05_INICIO_DB_SELECT_1();

            /*" -531- IF NOT ( SQLCODE = 0 OR = 100 ) */

            if (!(DB.SQLCODE.In("0", "100")))
            {

                /*" -532- MOVE 'P3021' TO WS-SECTION */
                _.Move("P3021", WORK.WS_ERRO.WS_SECTION);

                /*" -533- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -534- MOVE VG110-NUM-PROPOSTA TO WS-BIGINT(01) */
                _.Move(VG110.DCLVG_C612_RELAC_PROPOSTA.VG110_NUM_PROPOSTA, WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -538- STRING WS-SECTION ' - ERRO NO SELECT SEGUROS.VG_C612_PESSOA_HIST.' '<NUM-PROPOSTA=' WS-BIGINT(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl22 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl22 += " - ERRO NO SELECT SEGUROS.VG_C612_PESSOA_HIST.";
                spl22 += "<NUM-PROPOSTA=";
                var spl23 = WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                spl23 += ">";
                var results24 = spl22 + spl23;
                _.Move(results24, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -540- MOVE 'SEGUROS.VG_C612_RELAC_PROPOSTA' TO WS-TABELA */
                _.Move("SEGUROS.VG_C612_RELAC_PROPOSTA", WORK.WS_ERRO.WS_TABELA);

                /*" -541- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -542- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -543- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -545- END-IF */
            }


            /*" -546- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -547- MOVE 'P3021' TO WS-SECTION */
                _.Move("P3021", WORK.WS_ERRO.WS_SECTION);

                /*" -548- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -549- MOVE VG110-NUM-PROPOSTA TO WS-BIGINT(01) */
                _.Move(VG110.DCLVG_C612_RELAC_PROPOSTA.VG110_NUM_PROPOSTA, WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -553- STRING WS-SECTION ' - NUMERO PROPOSTA NAO CADASTRADO.' '<NUM-PROPOSTA=' WS-BIGINT(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl24 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl24 += " - NUMERO PROPOSTA NAO CADASTRADO.";
                spl24 += "<NUM-PROPOSTA=";
                var spl25 = WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                spl25 += ">";
                var results26 = spl24 + spl25;
                _.Move(results26, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -555- MOVE 'SEGUROS.VG_C612_RELAC_PROPOSTA' TO WS-TABELA */
                _.Move("SEGUROS.VG_C612_RELAC_PROPOSTA", WORK.WS_ERRO.WS_TABELA);

                /*" -556- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -557- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -558- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -559- END-IF */
            }


            /*" -559- . */

        }

        [StopWatch]
        /*" P3021-05-INICIO-DB-SELECT-1 */
        public void P3021_05_INICIO_DB_SELECT_1()
        {
            /*" -528- EXEC SQL SELECT COD_PESSOA , SEQ_PESSOA_HIST INTO :VG110-COD-PESSOA , :VG110-SEQ-PESSOA-HIST FROM SEGUROS.VG_C612_RELAC_PROPOSTA A WHERE A.NUM_PROPOSTA = :VG110-NUM-PROPOSTA AND A.SEQ_PESSOA_HIST = ( SELECT MAX(VW1.SEQ_PESSOA_HIST) FROM SEGUROS.VG_C612_RELAC_PROPOSTA VW1 WHERE VW1.NUM_PROPOSTA = A.NUM_PROPOSTA ) WITH UR END-EXEC */

            var p3021_05_INICIO_DB_SELECT_1_Query1 = new P3021_05_INICIO_DB_SELECT_1_Query1()
            {
                VG110_NUM_PROPOSTA = VG110.DCLVG_C612_RELAC_PROPOSTA.VG110_NUM_PROPOSTA.ToString(),
            };

            var executed_1 = P3021_05_INICIO_DB_SELECT_1_Query1.Execute(p3021_05_INICIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VG110_COD_PESSOA, VG110.DCLVG_C612_RELAC_PROPOSTA.VG110_COD_PESSOA);
                _.Move(executed_1.VG110_SEQ_PESSOA_HIST, VG110.DCLVG_C612_RELAC_PROPOSTA.VG110_SEQ_PESSOA_HIST);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P3021_99_EXIT*/

        [StopWatch]
        /*" P9999-ERRO-SECTION */
        private void P9999_ERRO_SECTION()
        {
            /*" -572- IF LK-VG009-E-TRACE = 'S' */

            if (SPVG009W.LK_VG009_E_TRACE == "S")
            {

                /*" -573- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -574- DISPLAY '*         E R R O    S P B V G 0 0 9         *' */
                _.Display($"*         E R R O    S P B V G 0 0 9         *");

                /*" -575- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -576- DISPLAY '* SECTION..........: ' WS-SECTION */
                _.Display($"* SECTION..........: {WORK.WS_ERRO.WS_SECTION}");

                /*" -577- DISPLAY '* IND ERRO.........: ' WS-IND-ERRO */
                _.Display($"* IND ERRO.........: {WORK.WS_ERRO.WS_IND_ERRO}");

                /*" -578- DISPLAY '* TABELA...........: ' WS-TABELA */
                _.Display($"* TABELA...........: {WORK.WS_ERRO.WS_TABELA}");

                /*" -579- DISPLAY '* MENSAGEM.........: ' WS-MENSAGEM */
                _.Display($"* MENSAGEM.........: {WORK.WS_ERRO.WS_MENSAGEM}");

                /*" -580- DISPLAY '* SQLCODE..........: ' WS-SQLCODE */
                _.Display($"* SQLCODE..........: {WORK.WS_ERRO.WS_SQLCODE}");

                /*" -581- DISPLAY '* SQLERRMC.........: ' WS-SQLERRMC */
                _.Display($"* SQLERRMC.........: {WORK.WS_ERRO.WS_SQLERRMC}");

                /*" -582- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -584- END-IF */
            }


            /*" -585- MOVE ZEROS TO LK-VG009-S-COD-PESSOA */
            _.Move(0, SPVG009W.LK_VG009_S_COD_PESSOA);

            /*" -586- MOVE ZEROS TO LK-VG009-S-SEQ-PESSOA-HIST */
            _.Move(0, SPVG009W.LK_VG009_S_SEQ_PESSOA_HIST);

            /*" -587- MOVE ZEROS TO LK-VG009-S-COD-CLASSIF-RISCO */
            _.Move(0, SPVG009W.LK_VG009_S_COD_CLASSIF_RISCO);

            /*" -588- MOVE ZEROS TO LK-VG009-S-NUM-SCORE-RISCO */
            _.Move(0, SPVG009W.LK_VG009_S_NUM_SCORE_RISCO);

            /*" -589- MOVE '1212-12-12' TO LK-VG009-S-DTA-CLASSIF-RISCO */
            _.Move("1212-12-12", SPVG009W.LK_VG009_S_DTA_CLASSIF_RISCO);

            /*" -590- MOVE SPACES TO LK-VG009-S-IND-PEND-APROVACAO */
            _.Move("", SPVG009W.LK_VG009_S_IND_PEND_APROVACAO);

            /*" -591- MOVE SPACES TO LK-VG009-S-IND-DECL-AUTOMATICO */
            _.Move("", SPVG009W.LK_VG009_S_IND_DECL_AUTOMATICO);

            /*" -593- MOVE SPACES TO LK-VG009-S-IND-ATLZ-FXA-RISCO */
            _.Move("", SPVG009W.LK_VG009_S_IND_ATLZ_FXA_RISCO);

            /*" -594- MOVE WS-IND-ERRO TO LK-VG009-IND-ERRO */
            _.Move(WORK.WS_ERRO.WS_IND_ERRO, SPVG009W.LK_VG009_IND_ERRO);

            /*" -595- MOVE WS-MENSAGEM TO LK-VG009-MSG-ERRO */
            _.Move(WORK.WS_ERRO.WS_MENSAGEM, SPVG009W.LK_VG009_MSG_ERRO);

            /*" -596- MOVE WS-TABELA TO LK-VG009-NOM-TABELA */
            _.Move(WORK.WS_ERRO.WS_TABELA, SPVG009W.LK_VG009_NOM_TABELA);

            /*" -597- MOVE WS-SQLCODE TO LK-VG009-SQLCODE */
            _.Move(WORK.WS_ERRO.WS_SQLCODE, SPVG009W.LK_VG009_SQLCODE);

            /*" -599- MOVE WS-SQLERRMC TO LK-VG009-SQLERRMC */
            _.Move(WORK.WS_ERRO.WS_SQLERRMC, SPVG009W.LK_VG009_SQLERRMC);

            /*" -599- . */

            /*" -0- FLUXCONTROL_PERFORM P9999_99_EXIT */

            P9999_99_EXIT();

        }

        [StopWatch]
        /*" P9999-99-EXIT */
        private void P9999_99_EXIT(bool isPerform = false)
        {
            /*" -602- GOBACK. */

            throw new GoBack();

        }
    }
}