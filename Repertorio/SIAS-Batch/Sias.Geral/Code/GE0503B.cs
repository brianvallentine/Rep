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
using Sias.Geral.DB2.GE0503B;

namespace Code
{
    public class GE0503B
    {
        public bool IsCall { get; set; }

        public GE0503B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  PESSOA                             *      */
        /*"      *   PROGRAMA ...............  GE0503B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  FAST COMPUTER                      *      */
        /*"      *   PROGRAMADOR ............  MARCO ANTONIO                      *      */
        /*"      *   DATA CODIFICACAO .......  DEZEMBRO/2007                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO.. EFETUAR O CADASTRAMENTO E CONSULTA DOS DADOS BANCO         */
        /*"      *            NA BASE DE PESSOA + DOMICILIO BANCARIO              *      */
        /*"      *   GE0503B - COBOL / DB2 / CICS                                 *      */
        /*"      *   GE0503B - COBOL / DB2                                               */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                          ALTERACOES                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 02 -   NSGD - JAZZ   586063.                          *      */
        /*"      *               - NOVAS OPERACOES NSGD                           *      */
        /*"      *                                                                *      */
        /*"      *   EM 21/06/2024 - TERCIO CARVALHO                              *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.02         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01 -   NSGD - CADMUS 103659B.                         *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 11/10/2014 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.01         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77    VIND-NULL01               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL01 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL02               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL02 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01     AREA-DE-WORK.*/
        public GE0503B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new GE0503B_AREA_DE_WORK();
        public class GE0503B_AREA_DE_WORK : VarBasis
        {
            /*"  05 WFIM-MOVIMENTO                  PIC X(001) VALUE 'N'.*/
            public StringBasis WFIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  05 WTEM-CONTA                      PIC X(001) VALUE  SPACES.*/
            public StringBasis WTEM_CONTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05 W-TABELA-LIKE-NOME.*/
            public GE0503B_W_TABELA_LIKE_NOME W_TABELA_LIKE_NOME { get; set; } = new GE0503B_W_TABELA_LIKE_NOME();
            public class GE0503B_W_TABELA_LIKE_NOME : VarBasis
            {
                /*"     10 W-TAB-LIKE-NOME              PIC X(01) OCCURS 200 TIMES.*/
                public ListBasis<StringBasis, string> W_TAB_LIKE_NOME { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(01)"), 200);
                /*"  05 W-IND-NOME                      PIC 9(03) VALUE ZEROS.*/
            }
            public IntBasis W_IND_NOME { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
            /*"  05   W-EDICAO                      PIC  Z.ZZZ.ZZ9,99-.*/
            public DoubleBasis W_EDICAO { get; set; } = new DoubleBasis(new PIC("9", "7", "Z.ZZZ.ZZ9V99-."), 3);
            /*"  05 HOST-CURRENT-DATE               PIC  X(10) VALUE SPACES.*/
            public StringBasis HOST_CURRENT_DATE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"  05 HOST-CURRENT-TIMESTAMP          PIC  X(26) VALUE SPACES.*/
            public StringBasis HOST_CURRENT_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)"), @"");
            /*"  05   WABEND.*/
            public GE0503B_WABEND WABEND { get; set; } = new GE0503B_WABEND();
            public class GE0503B_WABEND : VarBasis
            {
                /*"    10 WABEND1                       PIC  X(009)  VALUE                                                      'GE0503B '*/
                public StringBasis WABEND1 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"GE0503B ");
                /*"    10 WABEND2.*/
                public GE0503B_WABEND2 WABEND2 { get; set; } = new GE0503B_WABEND2();
                public class GE0503B_WABEND2 : VarBasis
                {
                    /*"      15 FILLER                      PIC  X(025)  VALUE                                     '*** ERRO EXEC SQL NUMERO '*/
                    public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"*** ERRO EXEC SQL NUMERO ");
                    /*"      15 WNR-EXEC-SQL                PIC  X(005)  VALUE SPACES.*/
                    public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                    /*"    10 WABEND3.*/
                }
                public GE0503B_WABEND3 WABEND3 { get; set; } = new GE0503B_WABEND3();
                public class GE0503B_WABEND3 : VarBasis
                {
                    /*"      15 FILLER                      PIC  X(013)  VALUE                                                 ' *** SQLCODE '*/
                    public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                    /*"      15 WSQLCODE                    PIC  -999.*/
                    public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "3", "-999."));
                    /*"01     W-HOST-COUNT                  PIC S9(009)     COMP.*/
                }
            }
        }
        public IntBasis W_HOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01     W-LINK-MSG-ERRO.*/
        public GE0503B_W_LINK_MSG_ERRO W_LINK_MSG_ERRO { get; set; } = new GE0503B_W_LINK_MSG_ERRO();
        public class GE0503B_W_LINK_MSG_ERRO : VarBasis
        {
            /*"       05 W-LINK-MENSAGEM            PIC  X(60).*/
            public StringBasis W_LINK_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "60", "X(60)."), @"");
            /*"       05 FILLER1                    PIC  X(01).*/
            public StringBasis FILLER1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"       05 W-LINK-SQLCODE             PIC  9(04).*/
            public IntBasis W_LINK_SQLCODE { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"       05 FILLER2                    PIC  X(01).*/
            public StringBasis FILLER2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"       05 W-WNR-EXEC-SQL             PIC  X(05).*/
            public StringBasis W_WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "5", "X(05)."), @"");
            /*"       05 FILLER3                    PIC  X(01).*/
            public StringBasis FILLER3 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"       05 W-OCORHIST                 PIC  9(03).*/
            public IntBasis W_OCORHIST { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
            /*"01     LINK-PARAMETRO.*/
        }
        public GE0503B_LINK_PARAMETRO LINK_PARAMETRO { get; set; } = new GE0503B_LINK_PARAMETRO();
        public class GE0503B_LINK_PARAMETRO : VarBasis
        {
            /*"  05   LINK-TIPO-UTILIZACAO          PIC  9(001).*/
            public IntBasis LINK_TIPO_UTILIZACAO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05   LINK-PROGRAMA-CHAMADOR        PIC  X(8).*/
            public StringBasis LINK_PROGRAMA_CHAMADOR { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
            /*"  05   LINK-NOME-USUARIO             PIC  X(8).*/
            public StringBasis LINK_NOME_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
            /*"  05   LINK-NUM-PESSOA               PIC S9(9) USAGE COMP.*/
            public IntBasis LINK_NUM_PESSOA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
            /*"  05   LINK-DTH-CADASTRAMENTO        PIC X(26).*/
            public StringBasis LINK_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
            /*"  05   LINK-NUM-DV-PESSOA            PIC S9(4) USAGE COMP.*/
            public IntBasis LINK_NUM_DV_PESSOA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"  05   LINK-IND-PESSOA               PIC X(1).*/
            public StringBasis LINK_IND_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
            /*"  05   LINK-STA-INF-INTEGRA          PIC X(1).*/
            public StringBasis LINK_STA_INF_INTEGRA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
            /*"  05   LINK-SEQ-CONTA-BANCARIA       PIC S9(4) USAGE COMP.*/
            public IntBasis LINK_SEQ_CONTA_BANCARIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"  05   LINK-STA-CONTA                PIC X(1).*/
            public StringBasis LINK_STA_CONTA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
            /*"  05   LINK-COD-BANCO                PIC S9(4) USAGE COMP.*/
            public IntBasis LINK_COD_BANCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"  05   LINK-COD-AGENCIA              PIC S9(4) USAGE COMP.*/
            public IntBasis LINK_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"  05   LINK-IND-CONTA-BANCARIA       PIC S9(4) USAGE COMP.*/
            public IntBasis LINK_IND_CONTA_BANCARIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"  05   LINK-NUM-CONTA                PIC S9(13) USAGE COMP-3.*/
            public IntBasis LINK_NUM_CONTA { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
            /*"  05   LINK-NUM-DV-CONTA             PIC X(2).*/
            public StringBasis LINK_NUM_DV_CONTA { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
            /*"  05   LINK-NUM-OPERACAO-CONTA       PIC S9(4) USAGE COMP.*/
            public IntBasis LINK_NUM_OPERACAO_CONTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"  05   LINK-PARAMETROS-SAIDA.*/
            public GE0503B_LINK_PARAMETROS_SAIDA LINK_PARAMETROS_SAIDA { get; set; } = new GE0503B_LINK_PARAMETROS_SAIDA();
            public class GE0503B_LINK_PARAMETROS_SAIDA : VarBasis
            {
                /*"       10   LINK-MSG-ADICIONAL            PIC  X(080).*/
                public StringBasis LINK_MSG_ADICIONAL { get; set; } = new StringBasis(new PIC("X", "80", "X(080)."), @"");
                /*"       10   LINK-IND-ERRO                 PIC  X(003).*/
                public StringBasis LINK_IND_ERRO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"       10   LINK-MSG-ERRO                 PIC  X(080).*/
                public StringBasis LINK_MSG_ERRO { get; set; } = new StringBasis(new PIC("X", "80", "X(080)."), @"");
                /*"       10   LINK-SQLCODE                  PIC S9(004) COMP.*/
                public IntBasis LINK_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"       10   LINK-NOME-TABELA              PIC  X(030).*/
                public StringBasis LINK_NOME_TABELA { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
            }
        }


        public Dclgens.AGENCIAS AGENCIAS { get; set; } = new Dclgens.AGENCIAS();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.OD001 OD001 { get; set; } = new Dclgens.OD001();
        public Dclgens.OD009 OD009 { get; set; } = new Dclgens.OD009();
        public GE0503B_V0BANCO V0BANCO { get; set; } = new GE0503B_V0BANCO();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(GE0503B_LINK_PARAMETRO GE0503B_LINK_PARAMETRO_P) //PROCEDURE DIVISION USING 
        /*LINK_PARAMETRO*/
        {
            try
            {
                this.LINK_PARAMETRO = GE0503B_LINK_PARAMETRO_P;

                /*" -164- MOVE '0001' TO WNR-EXEC-SQL */
                _.Move("0001", AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL);

                /*" -164- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -165- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -166- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -172- INITIALIZE LINK-PARAMETROS-SAIDA. */
                _.Initialize(
                    LINK_PARAMETRO.LINK_PARAMETROS_SAIDA
                );

                /*" -174- INITIALIZE DCLOD-PESSOA DCLOD-PESS-CONTA-BANC. */
                _.Initialize(
                    OD001.DCLOD_PESSOA
                    , OD009.DCLOD_PESS_CONTA_BANC
                );

                /*" -176- MOVE '0002' TO WNR-EXEC-SQL */
                _.Move("0002", AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL);

                /*" -183- PERFORM Execute_DB_SELECT_1 */

                Execute_DB_SELECT_1();

                /*" -186- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -188- MOVE 'GE0503B - ERRO NA LEITURA DA SISTEMAS' TO W-LINK-MENSAGEM */
                    _.Move("GE0503B - ERRO NA LEITURA DA SISTEMAS", W_LINK_MSG_ERRO.W_LINK_MENSAGEM);

                    /*" -189- MOVE SQLCODE TO W-LINK-SQLCODE */
                    _.Move(DB.SQLCODE, W_LINK_MSG_ERRO.W_LINK_SQLCODE);

                    /*" -190- MOVE WNR-EXEC-SQL TO W-WNR-EXEC-SQL */
                    _.Move(AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL, W_LINK_MSG_ERRO.W_WNR_EXEC_SQL);

                    /*" -191- MOVE W-LINK-MSG-ERRO TO LINK-MSG-ERRO */
                    _.Move(W_LINK_MSG_ERRO, LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                    /*" -192- MOVE 'SISTEMAS   ' TO LINK-NOME-TABELA */
                    _.Move("SISTEMAS   ", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_NOME_TABELA);

                    /*" -193- DISPLAY 'GE0503B - ERRO ACESSO SISTEMAS' */
                    _.Display($"GE0503B - ERRO ACESSO SISTEMAS");

                    /*" -198- GO TO R9999-00-CANCELA-PROGRAMA. */

                    R9999_00_CANCELA_PROGRAMA(); //GOTO
                    return Result;
                }


                /*" -200- IF (LINK-TIPO-UTILIZACAO NOT EQUAL 1) AND (LINK-TIPO-UTILIZACAO NOT EQUAL 2) */

                if ((LINK_PARAMETRO.LINK_TIPO_UTILIZACAO != 1) && (LINK_PARAMETRO.LINK_TIPO_UTILIZACAO != 2))
                {

                    /*" -203- MOVE 'GE0503B - TIPO DE CHAMADA INVALIDO. 1 - INCLUSAO 2 -CONSULTA' TO LINK-MSG-ERRO */
                    _.Move("GE0503B - TIPO DE CHAMADA INVALIDO. 1 - INCLUSAO 2 -CONSULTA", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                    /*" -205- GO TO R9999-00-CANCELA-PROGRAMA. */

                    R9999_00_CANCELA_PROGRAMA(); //GOTO
                    return Result;
                }


                /*" -206- IF LINK-PROGRAMA-CHAMADOR EQUAL SPACES */

                if (LINK_PARAMETRO.LINK_PROGRAMA_CHAMADOR.IsEmpty())
                {

                    /*" -208- MOVE 'GE0503B - NOME DO PGM CHAMADOR NAO INFORMADO' TO LINK-MSG-ERRO */
                    _.Move("GE0503B - NOME DO PGM CHAMADOR NAO INFORMADO", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                    /*" -210- GO TO R9999-00-CANCELA-PROGRAMA. */

                    R9999_00_CANCELA_PROGRAMA(); //GOTO
                    return Result;
                }


                /*" -211- IF LINK-NOME-USUARIO EQUAL SPACES */

                if (LINK_PARAMETRO.LINK_NOME_USUARIO.IsEmpty())
                {

                    /*" -213- MOVE 'GE0503B - NOME DO USUARIO CHAMADOR NAO INFORMADO' TO LINK-MSG-ERRO */
                    _.Move("GE0503B - NOME DO USUARIO CHAMADOR NAO INFORMADO", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                    /*" -215- GO TO R9999-00-CANCELA-PROGRAMA. */

                    R9999_00_CANCELA_PROGRAMA(); //GOTO
                    return Result;
                }


                /*" -216- IF LINK-NUM-PESSOA EQUAL ZEROS */

                if (LINK_PARAMETRO.LINK_NUM_PESSOA == 00)
                {

                    /*" -218- MOVE 'GE0503B - NUMERO DA PESSOA NAO INFORMADO' TO LINK-MSG-ERRO */
                    _.Move("GE0503B - NUMERO DA PESSOA NAO INFORMADO", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                    /*" -220- GO TO R9999-00-CANCELA-PROGRAMA. */

                    R9999_00_CANCELA_PROGRAMA(); //GOTO
                    return Result;
                }


                /*" -221- IF LINK-TIPO-UTILIZACAO EQUAL 2 */

                if (LINK_PARAMETRO.LINK_TIPO_UTILIZACAO == 2)
                {

                    /*" -222- IF LINK-SEQ-CONTA-BANCARIA EQUAL ZEROS */

                    if (LINK_PARAMETRO.LINK_SEQ_CONTA_BANCARIA == 00)
                    {

                        /*" -224- MOVE 'GE0503B - NUM. SEQUENCIA DO ENDERECO NAO INFORMADO' TO LINK-MSG-ERRO */
                        _.Move("GE0503B - NUM. SEQUENCIA DO ENDERECO NAO INFORMADO", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                        /*" -226- GO TO R9999-00-CANCELA-PROGRAMA. */

                        R9999_00_CANCELA_PROGRAMA(); //GOTO
                        return Result;
                    }

                }


                /*" -228- MOVE LINK-NUM-PESSOA TO OD001-NUM-PESSOA OD009-NUM-PESSOA. */
                _.Move(LINK_PARAMETRO.LINK_NUM_PESSOA, OD001.DCLOD_PESSOA.OD001_NUM_PESSOA, OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_PESSOA);

                /*" -229- IF (LINK-TIPO-UTILIZACAO EQUAL 1) */

                if ((LINK_PARAMETRO.LINK_TIPO_UTILIZACAO == 1))
                {

                    /*" -230- PERFORM R010-CRITICA-INCLUSAO THRU R010-EXIT */

                    R010_CRITICA_INCLUSAO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_PULA_BANCO*/

                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_EXIT*/


                    /*" -231- PERFORM R300-CONSULTA-BANCO THRU R300-EXIT */

                    R300_CONSULTA_BANCO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R300_EXIT*/


                    /*" -232- IF WTEM-CONTA NOT EQUAL 'S' */

                    if (AREA_DE_WORK.WTEM_CONTA != "S")
                    {

                        /*" -234- PERFORM R100-INSERT-BANCO THRU R100-EXIT. */

                        R100_INSERT_BANCO(true);
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/

                    }

                }


                /*" -235- IF (LINK-TIPO-UTILIZACAO EQUAL 2) */

                if ((LINK_PARAMETRO.LINK_TIPO_UTILIZACAO == 2))
                {

                    /*" -236- PERFORM R020-CRITICA-CONSUTA THRU R020-EXIT */

                    R020_CRITICA_CONSUTA(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R020_EXIT*/


                    /*" -238- PERFORM R200-CONSULTA-BANCO THRU R200-EXIT. */

                    R200_CONSULTA_BANCO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R200_EXIT*/

                }


                /*" -244- MOVE ZEROS TO RETURN-CODE. */
                _.Move(0, RETURN_CODE);

                /*" -244- GOBACK. */

                throw new GoBack();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LINK_PARAMETRO, CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" Execute-DB-SELECT-1 */
        public void Execute_DB_SELECT_1()
        {
            /*" -183- EXEC SQL SELECT CURRENT DATE, CURRENT TIMESTAMP INTO :HOST-CURRENT-DATE, :HOST-CURRENT-TIMESTAMP FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'EM' END-EXEC. */

            var execute_DB_SELECT_1_Query1 = new Execute_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = Execute_DB_SELECT_1_Query1.Execute(execute_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_CURRENT_DATE, AREA_DE_WORK.HOST_CURRENT_DATE);
                _.Move(executed_1.HOST_CURRENT_TIMESTAMP, AREA_DE_WORK.HOST_CURRENT_TIMESTAMP);
            }


        }

        [StopWatch]
        /*" R010-CRITICA-INCLUSAO */
        private void R010_CRITICA_INCLUSAO(bool isPerform = false)
        {
            /*" -251- IF (LINK-STA-CONTA NOT EQUAL 'A' ) */

            if ((LINK_PARAMETRO.LINK_STA_CONTA != "A"))
            {

                /*" -253- MOVE 'GE0503B - STATUS DA CONTA INVALIDO' TO LINK-MSG-ERRO */
                _.Move("GE0503B - STATUS DA CONTA INVALIDO", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                /*" -263- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA(); //GOTO
                return;
            }


            /*" -265- IF (LINK-COD-BANCO NOT EQUAL 104) AND (LINK-NUM-OPERACAO-CONTA NOT EQUAL 0) */

            if ((LINK_PARAMETRO.LINK_COD_BANCO != 104) && (LINK_PARAMETRO.LINK_NUM_OPERACAO_CONTA != 0))
            {

                /*" -267- MOVE 'GE0503B - P/ BANCO DIFERENTE CAIXA TIPO CONTA E ZERO' TO LINK-MSG-ERRO */
                _.Move("GE0503B - P/ BANCO DIFERENTE CAIXA TIPO CONTA E ZERO", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                /*" -269- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA(); //GOTO
                return;
            }


            /*" -283- IF LINK-COD-BANCO EQUAL 104 AND (LINK-NUM-OPERACAO-CONTA NOT EQUAL 1) AND (LINK-NUM-OPERACAO-CONTA NOT EQUAL 2) AND (LINK-NUM-OPERACAO-CONTA NOT EQUAL 3) AND (LINK-NUM-OPERACAO-CONTA NOT EQUAL 6) AND (LINK-NUM-OPERACAO-CONTA NOT EQUAL 13) AND (LINK-NUM-OPERACAO-CONTA NOT EQUAL 22) AND (LINK-NUM-OPERACAO-CONTA NOT EQUAL 23) AND (LINK-NUM-OPERACAO-CONTA NOT EQUAL 1288) AND (LINK-NUM-OPERACAO-CONTA NOT EQUAL 3702) AND (LINK-NUM-OPERACAO-CONTA NOT EQUAL 3701) AND (LINK-NUM-OPERACAO-CONTA NOT EQUAL 3700) AND (LINK-NUM-OPERACAO-CONTA NOT EQUAL 1367) AND (LINK-NUM-OPERACAO-CONTA NOT EQUAL 1369) */

            if (LINK_PARAMETRO.LINK_COD_BANCO == 104 && (LINK_PARAMETRO.LINK_NUM_OPERACAO_CONTA != 1) && (LINK_PARAMETRO.LINK_NUM_OPERACAO_CONTA != 2) && (LINK_PARAMETRO.LINK_NUM_OPERACAO_CONTA != 3) && (LINK_PARAMETRO.LINK_NUM_OPERACAO_CONTA != 6) && (LINK_PARAMETRO.LINK_NUM_OPERACAO_CONTA != 13) && (LINK_PARAMETRO.LINK_NUM_OPERACAO_CONTA != 22) && (LINK_PARAMETRO.LINK_NUM_OPERACAO_CONTA != 23) && (LINK_PARAMETRO.LINK_NUM_OPERACAO_CONTA != 1288) && (LINK_PARAMETRO.LINK_NUM_OPERACAO_CONTA != 3702) && (LINK_PARAMETRO.LINK_NUM_OPERACAO_CONTA != 3701) && (LINK_PARAMETRO.LINK_NUM_OPERACAO_CONTA != 3700) && (LINK_PARAMETRO.LINK_NUM_OPERACAO_CONTA != 1367) && (LINK_PARAMETRO.LINK_NUM_OPERACAO_CONTA != 1369))
            {

                /*" -285- MOVE 'GE0503B - OPERACAO DA CONTA CAIXA INVALIDA' TO LINK-MSG-ERRO */
                _.Move("GE0503B - OPERACAO DA CONTA CAIXA INVALIDA", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                /*" -291- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA(); //GOTO
                return;
            }


            /*" -294- GO TO R010-PULA-BANCO. */
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_PULA_BANCO*/ //GOTO
            return;


        }

        [StopWatch]
        /*" R010-CRITICA-INCLUSAO-DB-SELECT-1 */
        public void R010_CRITICA_INCLUSAO_DB_SELECT_1()
        {
            /*" -306- EXEC SQL SELECT COD_BANCO, COD_AGENCIA INTO :AGENCIAS-COD-BANCO, :AGENCIAS-COD-AGENCIA FROM SEGUROS.AGENCIAS WHERE COD_BANCO = :AGENCIAS-COD-BANCO AND COD_AGENCIA = :AGENCIAS-COD-AGENCIA WITH UR END-EXEC. */

            var r010_CRITICA_INCLUSAO_DB_SELECT_1_Query1 = new R010_CRITICA_INCLUSAO_DB_SELECT_1_Query1()
            {
                AGENCIAS_COD_AGENCIA = AGENCIAS.DCLAGENCIAS.AGENCIAS_COD_AGENCIA.ToString(),
                AGENCIAS_COD_BANCO = AGENCIAS.DCLAGENCIAS.AGENCIAS_COD_BANCO.ToString(),
            };

            var executed_1 = R010_CRITICA_INCLUSAO_DB_SELECT_1_Query1.Execute(r010_CRITICA_INCLUSAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.AGENCIAS_COD_BANCO, AGENCIAS.DCLAGENCIAS.AGENCIAS_COD_BANCO);
                _.Move(executed_1.AGENCIAS_COD_AGENCIA, AGENCIAS.DCLAGENCIAS.AGENCIAS_COD_AGENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_PULA_BANCO*/
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_EXIT*/

        [StopWatch]
        /*" R020-CRITICA-CONSUTA */
        private void R020_CRITICA_CONSUTA(bool isPerform = false)
        {
            /*" -333- IF LINK-SEQ-CONTA-BANCARIA EQUAL 0 */

            if (LINK_PARAMETRO.LINK_SEQ_CONTA_BANCARIA == 0)
            {

                /*" -335- MOVE 'GE0503B - INFORME O NUMERO DA PESSOA PARA CONSULTA' TO LINK-MSG-ERRO */
                _.Move("GE0503B - INFORME O NUMERO DA PESSOA PARA CONSULTA", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                /*" -335- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA(); //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R020_EXIT*/

        [StopWatch]
        /*" R200-CONSULTA-BANCO */
        private void R200_CONSULTA_BANCO(bool isPerform = false)
        {
            /*" -343- MOVE '0006' TO WNR-EXEC-SQL */
            _.Move("0006", AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL);

            /*" -345- MOVE LINK-SEQ-CONTA-BANCARIA TO OD009-SEQ-CONTA-BANCARIA. */
            _.Move(LINK_PARAMETRO.LINK_SEQ_CONTA_BANCARIA, OD009.DCLOD_PESS_CONTA_BANC.OD009_SEQ_CONTA_BANCARIA);

            /*" -380- PERFORM R200_CONSULTA_BANCO_DB_SELECT_1 */

            R200_CONSULTA_BANCO_DB_SELECT_1();

            /*" -383- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -386- MOVE 'GE0503B - PESSOA BANCO NAO ENCONTRADA P/ ID INFORMADO' TO LINK-MSG-ERRO */
                _.Move("GE0503B - PESSOA BANCO NAO ENCONTRADA P/ ID INFORMADO", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                /*" -388- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA(); //GOTO
                return;
            }


            /*" -389- IF (SQLCODE NOT EQUAL ZEROS) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -391- MOVE 'GE0503B - ERRO NA LEITURA DA PESSOA X BANCO' TO W-LINK-MENSAGEM */
                _.Move("GE0503B - ERRO NA LEITURA DA PESSOA X BANCO", W_LINK_MSG_ERRO.W_LINK_MENSAGEM);

                /*" -392- MOVE SQLCODE TO W-LINK-SQLCODE */
                _.Move(DB.SQLCODE, W_LINK_MSG_ERRO.W_LINK_SQLCODE);

                /*" -393- MOVE WNR-EXEC-SQL TO W-WNR-EXEC-SQL */
                _.Move(AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL, W_LINK_MSG_ERRO.W_WNR_EXEC_SQL);

                /*" -394- MOVE W-LINK-MSG-ERRO TO LINK-MSG-ERRO */
                _.Move(W_LINK_MSG_ERRO, LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                /*" -395- MOVE 'PESSOA/BANCO' TO LINK-NOME-TABELA */
                _.Move("PESSOA/BANCO", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_NOME_TABELA);

                /*" -397- DISPLAY 'GE0503B - ERRO ACESSO JOIN ODS_PESSOA X ODS_PESSO 'A_ENDERECO SQLCODE ' W-LINK-SQLCODE */

                $"GE0503B - ERRO ACESSO JOIN ODS_PESSOA X ODS_PESSO A_ENDERECO{DB.SQLCODE}{W_LINK_MSG_ERRO.W_LINK_SQLCODE}"
                .Display();

                /*" -399- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA(); //GOTO
                return;
            }


            /*" -400- IF VIND-NULL01 LESS ZEROS */

            if (VIND_NULL01 < 00)
            {

                /*" -403- MOVE SPACES TO OD009-NUM-DV-CONTA. */
                _.Move("", OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_DV_CONTA);
            }


            /*" -404- IF VIND-NULL02 LESS ZEROS */

            if (VIND_NULL02 < 00)
            {

                /*" -407- MOVE ZEROS TO OD009-NUM-OPERACAO-CONTA. */
                _.Move(0, OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_OPERACAO_CONTA);
            }


            /*" -408- MOVE OD001-NUM-PESSOA TO LINK-NUM-PESSOA */
            _.Move(OD001.DCLOD_PESSOA.OD001_NUM_PESSOA, LINK_PARAMETRO.LINK_NUM_PESSOA);

            /*" -409- MOVE OD001-DTH-CADASTRAMENTO TO LINK-DTH-CADASTRAMENTO */
            _.Move(OD001.DCLOD_PESSOA.OD001_DTH_CADASTRAMENTO, LINK_PARAMETRO.LINK_DTH_CADASTRAMENTO);

            /*" -410- MOVE OD001-NUM-DV-PESSOA TO LINK-NUM-DV-PESSOA */
            _.Move(OD001.DCLOD_PESSOA.OD001_NUM_DV_PESSOA, LINK_PARAMETRO.LINK_NUM_DV_PESSOA);

            /*" -411- MOVE OD001-IND-PESSOA TO LINK-IND-PESSOA */
            _.Move(OD001.DCLOD_PESSOA.OD001_IND_PESSOA, LINK_PARAMETRO.LINK_IND_PESSOA);

            /*" -412- MOVE OD001-STA-INF-INTEGRA TO LINK-STA-INF-INTEGRA */
            _.Move(OD001.DCLOD_PESSOA.OD001_STA_INF_INTEGRA, LINK_PARAMETRO.LINK_STA_INF_INTEGRA);

            /*" -413- MOVE OD009-SEQ-CONTA-BANCARIA TO LINK-SEQ-CONTA-BANCARIA */
            _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_SEQ_CONTA_BANCARIA, LINK_PARAMETRO.LINK_SEQ_CONTA_BANCARIA);

            /*" -414- MOVE OD009-DTH-CADASTRAMENTO TO LINK-DTH-CADASTRAMENTO */
            _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_DTH_CADASTRAMENTO, LINK_PARAMETRO.LINK_DTH_CADASTRAMENTO);

            /*" -415- MOVE OD009-STA-CONTA TO LINK-STA-CONTA */
            _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_STA_CONTA, LINK_PARAMETRO.LINK_STA_CONTA);

            /*" -416- MOVE OD009-COD-BANCO TO LINK-COD-BANCO */
            _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_BANCO, LINK_PARAMETRO.LINK_COD_BANCO);

            /*" -417- MOVE OD009-COD-AGENCIA TO LINK-COD-AGENCIA */
            _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_AGENCIA, LINK_PARAMETRO.LINK_COD_AGENCIA);

            /*" -418- MOVE OD009-IND-CONTA-BANCARIA TO LINK-IND-CONTA-BANCARIA */
            _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_IND_CONTA_BANCARIA, LINK_PARAMETRO.LINK_IND_CONTA_BANCARIA);

            /*" -419- MOVE OD009-NUM-CONTA TO LINK-NUM-CONTA */
            _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_CONTA, LINK_PARAMETRO.LINK_NUM_CONTA);

            /*" -420- MOVE OD009-NUM-DV-CONTA TO LINK-NUM-DV-CONTA */
            _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_DV_CONTA, LINK_PARAMETRO.LINK_NUM_DV_CONTA);

            /*" -420- MOVE OD009-NUM-OPERACAO-CONTA TO LINK-NUM-OPERACAO-CONTA. */
            _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_OPERACAO_CONTA, LINK_PARAMETRO.LINK_NUM_OPERACAO_CONTA);

        }

        [StopWatch]
        /*" R200-CONSULTA-BANCO-DB-SELECT-1 */
        public void R200_CONSULTA_BANCO_DB_SELECT_1()
        {
            /*" -380- EXEC SQL SELECT A.NUM_PESSOA , A.DTH_CADASTRAMENTO , A.NUM_DV_PESSOA , A.IND_PESSOA , A.STA_INF_INTEGRA , B.SEQ_CONTA_BANCARIA , B.DTH_CADASTRAMENTO , B.STA_CONTA , B.COD_BANCO , B.COD_AGENCIA , B.IND_CONTA_BANCARIA , B.NUM_CONTA , B.NUM_DV_CONTA , B.NUM_OPERACAO_CONTA INTO :OD001-NUM-PESSOA , :OD001-DTH-CADASTRAMENTO , :OD001-NUM-DV-PESSOA , :OD001-IND-PESSOA , :OD001-STA-INF-INTEGRA , :OD009-SEQ-CONTA-BANCARIA , :OD009-DTH-CADASTRAMENTO , :OD009-STA-CONTA , :OD009-COD-BANCO , :OD009-COD-AGENCIA , :OD009-IND-CONTA-BANCARIA , :OD009-NUM-CONTA , :OD009-NUM-DV-CONTA:VIND-NULL01 , :OD009-NUM-OPERACAO-CONTA:VIND-NULL02 FROM ODS.OD_PESSOA A, ODS.OD_PESS_CONTA_BANC B WHERE A.NUM_PESSOA = :OD001-NUM-PESSOA AND B.NUM_PESSOA = A.NUM_PESSOA AND B.SEQ_CONTA_BANCARIA = :OD009-SEQ-CONTA-BANCARIA WITH UR END-EXEC. */

            var r200_CONSULTA_BANCO_DB_SELECT_1_Query1 = new R200_CONSULTA_BANCO_DB_SELECT_1_Query1()
            {
                OD009_SEQ_CONTA_BANCARIA = OD009.DCLOD_PESS_CONTA_BANC.OD009_SEQ_CONTA_BANCARIA.ToString(),
                OD001_NUM_PESSOA = OD001.DCLOD_PESSOA.OD001_NUM_PESSOA.ToString(),
            };

            var executed_1 = R200_CONSULTA_BANCO_DB_SELECT_1_Query1.Execute(r200_CONSULTA_BANCO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OD001_NUM_PESSOA, OD001.DCLOD_PESSOA.OD001_NUM_PESSOA);
                _.Move(executed_1.OD001_DTH_CADASTRAMENTO, OD001.DCLOD_PESSOA.OD001_DTH_CADASTRAMENTO);
                _.Move(executed_1.OD001_NUM_DV_PESSOA, OD001.DCLOD_PESSOA.OD001_NUM_DV_PESSOA);
                _.Move(executed_1.OD001_IND_PESSOA, OD001.DCLOD_PESSOA.OD001_IND_PESSOA);
                _.Move(executed_1.OD001_STA_INF_INTEGRA, OD001.DCLOD_PESSOA.OD001_STA_INF_INTEGRA);
                _.Move(executed_1.OD009_SEQ_CONTA_BANCARIA, OD009.DCLOD_PESS_CONTA_BANC.OD009_SEQ_CONTA_BANCARIA);
                _.Move(executed_1.OD009_DTH_CADASTRAMENTO, OD009.DCLOD_PESS_CONTA_BANC.OD009_DTH_CADASTRAMENTO);
                _.Move(executed_1.OD009_STA_CONTA, OD009.DCLOD_PESS_CONTA_BANC.OD009_STA_CONTA);
                _.Move(executed_1.OD009_COD_BANCO, OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_BANCO);
                _.Move(executed_1.OD009_COD_AGENCIA, OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_AGENCIA);
                _.Move(executed_1.OD009_IND_CONTA_BANCARIA, OD009.DCLOD_PESS_CONTA_BANC.OD009_IND_CONTA_BANCARIA);
                _.Move(executed_1.OD009_NUM_CONTA, OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_CONTA);
                _.Move(executed_1.OD009_NUM_DV_CONTA, OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_DV_CONTA);
                _.Move(executed_1.VIND_NULL01, VIND_NULL01);
                _.Move(executed_1.OD009_NUM_OPERACAO_CONTA, OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_OPERACAO_CONTA);
                _.Move(executed_1.VIND_NULL02, VIND_NULL02);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R200_EXIT*/

        [StopWatch]
        /*" R100-INSERT-BANCO */
        private void R100_INSERT_BANCO(bool isPerform = false)
        {
            /*" -432- MOVE '0002' TO WNR-EXEC-SQL */
            _.Move("0002", AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL);

            /*" -437- PERFORM R100_INSERT_BANCO_DB_SELECT_1 */

            R100_INSERT_BANCO_DB_SELECT_1();

            /*" -440- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -442- MOVE 'GE0503B - MAX PARA PEGAR NUMERO SEQUENCIA BANCO' TO W-LINK-MENSAGEM */
                _.Move("GE0503B - MAX PARA PEGAR NUMERO SEQUENCIA BANCO", W_LINK_MSG_ERRO.W_LINK_MENSAGEM);

                /*" -443- MOVE SQLCODE TO W-LINK-SQLCODE */
                _.Move(DB.SQLCODE, W_LINK_MSG_ERRO.W_LINK_SQLCODE);

                /*" -444- MOVE WNR-EXEC-SQL TO W-WNR-EXEC-SQL */
                _.Move(AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL, W_LINK_MSG_ERRO.W_WNR_EXEC_SQL);

                /*" -445- MOVE W-LINK-MSG-ERRO TO LINK-MSG-ERRO */
                _.Move(W_LINK_MSG_ERRO, LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                /*" -446- MOVE 'OD_PESSOA  ' TO LINK-NOME-TABELA */
                _.Move("OD_PESSOA  ", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_NOME_TABELA);

                /*" -447- DISPLAY 'GE0503B - ERRO MAX DA OD_PESSOA' */
                _.Display($"GE0503B - ERRO MAX DA OD_PESSOA");

                /*" -449- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA(); //GOTO
                return;
            }


            /*" -451- MOVE OD009-SEQ-CONTA-BANCARIA TO LINK-SEQ-CONTA-BANCARIA. */
            _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_SEQ_CONTA_BANCARIA, LINK_PARAMETRO.LINK_SEQ_CONTA_BANCARIA);

            /*" -452- MOVE HOST-CURRENT-TIMESTAMP TO OD009-DTH-CADASTRAMENTO . */
            _.Move(AREA_DE_WORK.HOST_CURRENT_TIMESTAMP, OD009.DCLOD_PESS_CONTA_BANC.OD009_DTH_CADASTRAMENTO);

            /*" -453- MOVE LINK-STA-CONTA TO OD009-STA-CONTA . */
            _.Move(LINK_PARAMETRO.LINK_STA_CONTA, OD009.DCLOD_PESS_CONTA_BANC.OD009_STA_CONTA);

            /*" -454- MOVE LINK-COD-BANCO TO OD009-COD-BANCO . */
            _.Move(LINK_PARAMETRO.LINK_COD_BANCO, OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_BANCO);

            /*" -455- MOVE LINK-COD-AGENCIA TO OD009-COD-AGENCIA . */
            _.Move(LINK_PARAMETRO.LINK_COD_AGENCIA, OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_AGENCIA);

            /*" -456- MOVE LINK-IND-CONTA-BANCARIA TO OD009-IND-CONTA-BANCARIA. */
            _.Move(LINK_PARAMETRO.LINK_IND_CONTA_BANCARIA, OD009.DCLOD_PESS_CONTA_BANC.OD009_IND_CONTA_BANCARIA);

            /*" -458- MOVE LINK-NUM-CONTA TO OD009-NUM-CONTA . */
            _.Move(LINK_PARAMETRO.LINK_NUM_CONTA, OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_CONTA);

            /*" -459- IF LINK-NUM-DV-CONTA(1:1) EQUAL ' ' */

            if (LINK_PARAMETRO.LINK_NUM_DV_CONTA.Substring(1, 1) == " ")
            {

                /*" -460- MOVE LINK-NUM-DV-CONTA(2:1) TO LINK-NUM-DV-CONTA(1:1) */
                _.MoveAtPosition(LINK_PARAMETRO.LINK_NUM_DV_CONTA.Substring(2, 1), LINK_PARAMETRO.LINK_NUM_DV_CONTA, 1, 1);

                /*" -462- MOVE ' ' TO LINK-NUM-DV-CONTA(2:1) . */
                _.MoveAtPosition(" ", LINK_PARAMETRO.LINK_NUM_DV_CONTA, 2, 1);
            }


            /*" -463- MOVE LINK-NUM-DV-CONTA TO OD009-NUM-DV-CONTA . */
            _.Move(LINK_PARAMETRO.LINK_NUM_DV_CONTA, OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_DV_CONTA);

            /*" -469- MOVE LINK-NUM-OPERACAO-CONTA TO OD009-NUM-OPERACAO-CONTA. */
            _.Move(LINK_PARAMETRO.LINK_NUM_OPERACAO_CONTA, OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_OPERACAO_CONTA);

            /*" -470- MOVE ZEROS TO VIND-NULL01. */
            _.Move(0, VIND_NULL01);

            /*" -473- MOVE ZEROS TO VIND-NULL02. */
            _.Move(0, VIND_NULL02);

            /*" -475- MOVE '0006' TO WNR-EXEC-SQL */
            _.Move("0006", AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL);

            /*" -496- PERFORM R100_INSERT_BANCO_DB_INSERT_1 */

            R100_INSERT_BANCO_DB_INSERT_1();

            /*" -499- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -501- MOVE 'GE0503B - ERRO INSERT OD_PESS_CONTA_BANC' TO W-LINK-MENSAGEM */
                _.Move("GE0503B - ERRO INSERT OD_PESS_CONTA_BANC", W_LINK_MSG_ERRO.W_LINK_MENSAGEM);

                /*" -502- MOVE SQLCODE TO W-LINK-SQLCODE */
                _.Move(DB.SQLCODE, W_LINK_MSG_ERRO.W_LINK_SQLCODE);

                /*" -503- MOVE WNR-EXEC-SQL TO W-WNR-EXEC-SQL */
                _.Move(AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL, W_LINK_MSG_ERRO.W_WNR_EXEC_SQL);

                /*" -504- MOVE W-LINK-MSG-ERRO TO LINK-MSG-ERRO */
                _.Move(W_LINK_MSG_ERRO, LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                /*" -505- MOVE 'OD_PESS_CONTA_BANC' TO LINK-NOME-TABELA */
                _.Move("OD_PESS_CONTA_BANC", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_NOME_TABELA);

                /*" -507- DISPLAY 'GE0503B - ERRO INSERT OD_PESS_CONTA_BAN SQLCODE ' W-LINK-SQLCODE */
                _.Display($"GE0503B - ERRO INSERT OD_PESS_CONTA_BAN SQLCODE {W_LINK_MSG_ERRO.W_LINK_SQLCODE}");

                /*" -509- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA(); //GOTO
                return;
            }


            /*" -512- DISPLAY 'GE0503B - GRAVOU OD009 ... ' OD009-NUM-PESSOA ' ' OD009-NUM-OPERACAO-CONTA ' ' OD009-NUM-CONTA ' ' OD009-NUM-DV-CONTA. */

            $"GE0503B - GRAVOU OD009 ... {OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_PESSOA} {OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_OPERACAO_CONTA} {OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_CONTA} {OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_DV_CONTA}"
            .Display();

        }

        [StopWatch]
        /*" R100-INSERT-BANCO-DB-SELECT-1 */
        public void R100_INSERT_BANCO_DB_SELECT_1()
        {
            /*" -437- EXEC SQL SELECT VALUE(MAX(SEQ_CONTA_BANCARIA),0) + 1 INTO :OD009-SEQ-CONTA-BANCARIA FROM ODS.OD_PESS_CONTA_BANC WHERE NUM_PESSOA = :OD009-NUM-PESSOA END-EXEC. */

            var r100_INSERT_BANCO_DB_SELECT_1_Query1 = new R100_INSERT_BANCO_DB_SELECT_1_Query1()
            {
                OD009_NUM_PESSOA = OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_PESSOA.ToString(),
            };

            var executed_1 = R100_INSERT_BANCO_DB_SELECT_1_Query1.Execute(r100_INSERT_BANCO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OD009_SEQ_CONTA_BANCARIA, OD009.DCLOD_PESS_CONTA_BANC.OD009_SEQ_CONTA_BANCARIA);
            }


        }

        [StopWatch]
        /*" R100-INSERT-BANCO-DB-INSERT-1 */
        public void R100_INSERT_BANCO_DB_INSERT_1()
        {
            /*" -496- EXEC SQL INSERT INTO ODS.OD_PESS_CONTA_BANC ( NUM_PESSOA , SEQ_CONTA_BANCARIA, DTH_CADASTRAMENTO , STA_CONTA , COD_BANCO , COD_AGENCIA , IND_CONTA_BANCARIA, NUM_CONTA , NUM_DV_CONTA , NUM_OPERACAO_CONTA) VALUES (:OD009-NUM-PESSOA , :OD009-SEQ-CONTA-BANCARIA, :OD009-DTH-CADASTRAMENTO , :OD009-STA-CONTA , :OD009-COD-BANCO , :OD009-COD-AGENCIA , :OD009-IND-CONTA-BANCARIA, :OD009-NUM-CONTA , :OD009-NUM-DV-CONTA:VIND-NULL01 , :OD009-NUM-OPERACAO-CONTA:VIND-NULL02) END-EXEC. */

            var r100_INSERT_BANCO_DB_INSERT_1_Insert1 = new R100_INSERT_BANCO_DB_INSERT_1_Insert1()
            {
                OD009_NUM_PESSOA = OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_PESSOA.ToString(),
                OD009_SEQ_CONTA_BANCARIA = OD009.DCLOD_PESS_CONTA_BANC.OD009_SEQ_CONTA_BANCARIA.ToString(),
                OD009_DTH_CADASTRAMENTO = OD009.DCLOD_PESS_CONTA_BANC.OD009_DTH_CADASTRAMENTO.ToString(),
                OD009_STA_CONTA = OD009.DCLOD_PESS_CONTA_BANC.OD009_STA_CONTA.ToString(),
                OD009_COD_BANCO = OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_BANCO.ToString(),
                OD009_COD_AGENCIA = OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_AGENCIA.ToString(),
                OD009_IND_CONTA_BANCARIA = OD009.DCLOD_PESS_CONTA_BANC.OD009_IND_CONTA_BANCARIA.ToString(),
                OD009_NUM_CONTA = OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_CONTA.ToString(),
                OD009_NUM_DV_CONTA = OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_DV_CONTA.ToString(),
                VIND_NULL01 = VIND_NULL01.ToString(),
                OD009_NUM_OPERACAO_CONTA = OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_OPERACAO_CONTA.ToString(),
                VIND_NULL02 = VIND_NULL02.ToString(),
            };

            R100_INSERT_BANCO_DB_INSERT_1_Insert1.Execute(r100_INSERT_BANCO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/

        [StopWatch]
        /*" R300-CONSULTA-BANCO */
        private void R300_CONSULTA_BANCO(bool isPerform = false)
        {
            /*" -523- MOVE '0006' TO WNR-EXEC-SQL. */
            _.Move("0006", AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL);

            /*" -525- MOVE SPACES TO WFIM-MOVIMENTO. */
            _.Move("", AREA_DE_WORK.WFIM_MOVIMENTO);

            /*" -527- PERFORM R310-00-DECLARE-BANCO THRU R310-EXIT. */

            R310_00_DECLARE_BANCO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R310_EXIT*/


            /*" -528- PERFORM R320-00-FETCH-BANCO THRU R320-EXIT UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_MOVIMENTO.IsEmpty()))
            {

                R320_00_FETCH_BANCO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R320_EXIT*/

            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R300_EXIT*/

        [StopWatch]
        /*" R310-00-DECLARE-BANCO */
        private void R310_00_DECLARE_BANCO(bool isPerform = false)
        {
            /*" -536- MOVE 'N' TO WTEM-CONTA. */
            _.Move("N", AREA_DE_WORK.WTEM_CONTA);

            /*" -537- MOVE LINK-COD-BANCO TO OD009-COD-BANCO. */
            _.Move(LINK_PARAMETRO.LINK_COD_BANCO, OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_BANCO);

            /*" -538- MOVE LINK-COD-AGENCIA TO OD009-COD-AGENCIA. */
            _.Move(LINK_PARAMETRO.LINK_COD_AGENCIA, OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_AGENCIA);

            /*" -540- MOVE LINK-NUM-CONTA TO OD009-NUM-CONTA. */
            _.Move(LINK_PARAMETRO.LINK_NUM_CONTA, OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_CONTA);

            /*" -564- PERFORM R310_00_DECLARE_BANCO_DB_DECLARE_1 */

            R310_00_DECLARE_BANCO_DB_DECLARE_1();

            /*" -566- PERFORM R310_00_DECLARE_BANCO_DB_OPEN_1 */

            R310_00_DECLARE_BANCO_DB_OPEN_1();

            /*" -569- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -570- MOVE 'N' TO WTEM-CONTA */
                _.Move("N", AREA_DE_WORK.WTEM_CONTA);

                /*" -570- MOVE 'S' TO WFIM-MOVIMENTO. */
                _.Move("S", AREA_DE_WORK.WFIM_MOVIMENTO);
            }


        }

        [StopWatch]
        /*" R310-00-DECLARE-BANCO-DB-DECLARE-1 */
        public void R310_00_DECLARE_BANCO_DB_DECLARE_1()
        {
            /*" -564- EXEC SQL DECLARE V0BANCO CURSOR WITH HOLD FOR SELECT A.NUM_PESSOA , A.DTH_CADASTRAMENTO , A.NUM_DV_PESSOA , A.IND_PESSOA , A.STA_INF_INTEGRA , B.SEQ_CONTA_BANCARIA , B.DTH_CADASTRAMENTO , B.STA_CONTA , B.COD_BANCO , B.COD_AGENCIA , B.IND_CONTA_BANCARIA , B.NUM_CONTA , B.NUM_DV_CONTA , B.NUM_OPERACAO_CONTA FROM ODS.OD_PESSOA A, ODS.OD_PESS_CONTA_BANC B WHERE A.NUM_PESSOA = :OD001-NUM-PESSOA AND B.NUM_PESSOA = A.NUM_PESSOA AND B.COD_BANCO = :OD009-COD-BANCO AND B.COD_AGENCIA = :OD009-COD-AGENCIA AND B.NUM_CONTA = :OD009-NUM-CONTA END-EXEC. */
            V0BANCO = new GE0503B_V0BANCO(true);
            string GetQuery_V0BANCO()
            {
                var query = @$"SELECT A.NUM_PESSOA
							, 
							A.DTH_CADASTRAMENTO
							, 
							A.NUM_DV_PESSOA
							, 
							A.IND_PESSOA
							, 
							A.STA_INF_INTEGRA
							, 
							B.SEQ_CONTA_BANCARIA
							, 
							B.DTH_CADASTRAMENTO
							, 
							B.STA_CONTA
							, 
							B.COD_BANCO
							, 
							B.COD_AGENCIA
							, 
							B.IND_CONTA_BANCARIA
							, 
							B.NUM_CONTA
							, 
							B.NUM_DV_CONTA
							, 
							B.NUM_OPERACAO_CONTA 
							FROM ODS.OD_PESSOA A
							, 
							ODS.OD_PESS_CONTA_BANC B 
							WHERE A.NUM_PESSOA = '{OD001.DCLOD_PESSOA.OD001_NUM_PESSOA}' 
							AND B.NUM_PESSOA = A.NUM_PESSOA 
							AND B.COD_BANCO = '{OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_BANCO}' 
							AND B.COD_AGENCIA = '{OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_AGENCIA}' 
							AND B.NUM_CONTA = '{OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_CONTA}'";

                return query;
            }
            V0BANCO.GetQueryEvent += GetQuery_V0BANCO;

        }

        [StopWatch]
        /*" R310-00-DECLARE-BANCO-DB-OPEN-1 */
        public void R310_00_DECLARE_BANCO_DB_OPEN_1()
        {
            /*" -566- EXEC SQL OPEN V0BANCO END-EXEC. */

            V0BANCO.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R310_EXIT*/

        [StopWatch]
        /*" R320-00-FETCH-BANCO */
        private void R320_00_FETCH_BANCO(bool isPerform = false)
        {
            /*" -593- PERFORM R320_00_FETCH_BANCO_DB_FETCH_1 */

            R320_00_FETCH_BANCO_DB_FETCH_1();

            /*" -596- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -596- PERFORM R320_00_FETCH_BANCO_DB_CLOSE_1 */

                R320_00_FETCH_BANCO_DB_CLOSE_1();

                /*" -598- MOVE 'S' TO WFIM-MOVIMENTO */
                _.Move("S", AREA_DE_WORK.WFIM_MOVIMENTO);

                /*" -599- MOVE 'N' TO WTEM-CONTA */
                _.Move("N", AREA_DE_WORK.WTEM_CONTA);

                /*" -601- GO TO R320-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R320_EXIT*/ //GOTO
                return;
            }


            /*" -602- IF VIND-NULL01 LESS ZEROS */

            if (VIND_NULL01 < 00)
            {

                /*" -605- MOVE SPACES TO OD009-NUM-DV-CONTA. */
                _.Move("", OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_DV_CONTA);
            }


            /*" -606- IF VIND-NULL02 LESS ZEROS */

            if (VIND_NULL02 < 00)
            {

                /*" -610- MOVE ZEROS TO OD009-NUM-OPERACAO-CONTA. */
                _.Move(0, OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_OPERACAO_CONTA);
            }


            /*" -612- IF OD009-NUM-DV-CONTA NOT EQUAL LINK-NUM-DV-CONTA */

            if (OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_DV_CONTA != LINK_PARAMETRO.LINK_NUM_DV_CONTA)
            {

                /*" -613- MOVE 'N' TO WTEM-CONTA */
                _.Move("N", AREA_DE_WORK.WTEM_CONTA);

                /*" -615- GO TO R320-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R320_EXIT*/ //GOTO
                return;
            }


            /*" -617- IF OD009-NUM-OPERACAO-CONTA NOT EQUAL LINK-NUM-OPERACAO-CONTA */

            if (OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_OPERACAO_CONTA != LINK_PARAMETRO.LINK_NUM_OPERACAO_CONTA)
            {

                /*" -618- MOVE 'N' TO WTEM-CONTA */
                _.Move("N", AREA_DE_WORK.WTEM_CONTA);

                /*" -621- GO TO R320-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R320_EXIT*/ //GOTO
                return;
            }


            /*" -621- PERFORM R320_00_FETCH_BANCO_DB_CLOSE_2 */

            R320_00_FETCH_BANCO_DB_CLOSE_2();

            /*" -623- MOVE 'S' TO WFIM-MOVIMENTO. */
            _.Move("S", AREA_DE_WORK.WFIM_MOVIMENTO);

            /*" -625- MOVE 'S' TO WTEM-CONTA. */
            _.Move("S", AREA_DE_WORK.WTEM_CONTA);

            /*" -626- MOVE OD001-NUM-PESSOA TO LINK-NUM-PESSOA */
            _.Move(OD001.DCLOD_PESSOA.OD001_NUM_PESSOA, LINK_PARAMETRO.LINK_NUM_PESSOA);

            /*" -627- MOVE OD001-DTH-CADASTRAMENTO TO LINK-DTH-CADASTRAMENTO */
            _.Move(OD001.DCLOD_PESSOA.OD001_DTH_CADASTRAMENTO, LINK_PARAMETRO.LINK_DTH_CADASTRAMENTO);

            /*" -628- MOVE OD001-NUM-DV-PESSOA TO LINK-NUM-DV-PESSOA */
            _.Move(OD001.DCLOD_PESSOA.OD001_NUM_DV_PESSOA, LINK_PARAMETRO.LINK_NUM_DV_PESSOA);

            /*" -629- MOVE OD001-IND-PESSOA TO LINK-IND-PESSOA */
            _.Move(OD001.DCLOD_PESSOA.OD001_IND_PESSOA, LINK_PARAMETRO.LINK_IND_PESSOA);

            /*" -630- MOVE OD001-STA-INF-INTEGRA TO LINK-STA-INF-INTEGRA */
            _.Move(OD001.DCLOD_PESSOA.OD001_STA_INF_INTEGRA, LINK_PARAMETRO.LINK_STA_INF_INTEGRA);

            /*" -631- MOVE OD009-SEQ-CONTA-BANCARIA TO LINK-SEQ-CONTA-BANCARIA */
            _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_SEQ_CONTA_BANCARIA, LINK_PARAMETRO.LINK_SEQ_CONTA_BANCARIA);

            /*" -632- MOVE OD009-DTH-CADASTRAMENTO TO LINK-DTH-CADASTRAMENTO */
            _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_DTH_CADASTRAMENTO, LINK_PARAMETRO.LINK_DTH_CADASTRAMENTO);

            /*" -633- MOVE OD009-STA-CONTA TO LINK-STA-CONTA */
            _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_STA_CONTA, LINK_PARAMETRO.LINK_STA_CONTA);

            /*" -634- MOVE OD009-COD-BANCO TO LINK-COD-BANCO */
            _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_BANCO, LINK_PARAMETRO.LINK_COD_BANCO);

            /*" -635- MOVE OD009-COD-AGENCIA TO LINK-COD-AGENCIA */
            _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_AGENCIA, LINK_PARAMETRO.LINK_COD_AGENCIA);

            /*" -636- MOVE OD009-IND-CONTA-BANCARIA TO LINK-IND-CONTA-BANCARIA */
            _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_IND_CONTA_BANCARIA, LINK_PARAMETRO.LINK_IND_CONTA_BANCARIA);

            /*" -637- MOVE OD009-NUM-CONTA TO LINK-NUM-CONTA */
            _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_CONTA, LINK_PARAMETRO.LINK_NUM_CONTA);

            /*" -638- MOVE OD009-NUM-DV-CONTA TO LINK-NUM-DV-CONTA */
            _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_DV_CONTA, LINK_PARAMETRO.LINK_NUM_DV_CONTA);

            /*" -638- MOVE OD009-NUM-OPERACAO-CONTA TO LINK-NUM-OPERACAO-CONTA. */
            _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_OPERACAO_CONTA, LINK_PARAMETRO.LINK_NUM_OPERACAO_CONTA);

        }

        [StopWatch]
        /*" R320-00-FETCH-BANCO-DB-FETCH-1 */
        public void R320_00_FETCH_BANCO_DB_FETCH_1()
        {
            /*" -593- EXEC SQL FETCH V0BANCO INTO :OD001-NUM-PESSOA , :OD001-DTH-CADASTRAMENTO , :OD001-NUM-DV-PESSOA , :OD001-IND-PESSOA , :OD001-STA-INF-INTEGRA , :OD009-SEQ-CONTA-BANCARIA , :OD009-DTH-CADASTRAMENTO , :OD009-STA-CONTA , :OD009-COD-BANCO , :OD009-COD-AGENCIA , :OD009-IND-CONTA-BANCARIA , :OD009-NUM-CONTA , :OD009-NUM-DV-CONTA:VIND-NULL01 , :OD009-NUM-OPERACAO-CONTA:VIND-NULL02 END-EXEC. */

            if (V0BANCO.Fetch())
            {
                _.Move(V0BANCO.OD001_NUM_PESSOA, OD001.DCLOD_PESSOA.OD001_NUM_PESSOA);
                _.Move(V0BANCO.OD001_DTH_CADASTRAMENTO, OD001.DCLOD_PESSOA.OD001_DTH_CADASTRAMENTO);
                _.Move(V0BANCO.OD001_NUM_DV_PESSOA, OD001.DCLOD_PESSOA.OD001_NUM_DV_PESSOA);
                _.Move(V0BANCO.OD001_IND_PESSOA, OD001.DCLOD_PESSOA.OD001_IND_PESSOA);
                _.Move(V0BANCO.OD001_STA_INF_INTEGRA, OD001.DCLOD_PESSOA.OD001_STA_INF_INTEGRA);
                _.Move(V0BANCO.OD009_SEQ_CONTA_BANCARIA, OD009.DCLOD_PESS_CONTA_BANC.OD009_SEQ_CONTA_BANCARIA);
                _.Move(V0BANCO.OD009_DTH_CADASTRAMENTO, OD009.DCLOD_PESS_CONTA_BANC.OD009_DTH_CADASTRAMENTO);
                _.Move(V0BANCO.OD009_STA_CONTA, OD009.DCLOD_PESS_CONTA_BANC.OD009_STA_CONTA);
                _.Move(V0BANCO.OD009_COD_BANCO, OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_BANCO);
                _.Move(V0BANCO.OD009_COD_AGENCIA, OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_AGENCIA);
                _.Move(V0BANCO.OD009_IND_CONTA_BANCARIA, OD009.DCLOD_PESS_CONTA_BANC.OD009_IND_CONTA_BANCARIA);
                _.Move(V0BANCO.OD009_NUM_CONTA, OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_CONTA);
                _.Move(V0BANCO.OD009_NUM_DV_CONTA, OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_DV_CONTA);
                _.Move(V0BANCO.VIND_NULL01, VIND_NULL01);
                _.Move(V0BANCO.OD009_NUM_OPERACAO_CONTA, OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_OPERACAO_CONTA);
                _.Move(V0BANCO.VIND_NULL02, VIND_NULL02);
            }

        }

        [StopWatch]
        /*" R320-00-FETCH-BANCO-DB-CLOSE-1 */
        public void R320_00_FETCH_BANCO_DB_CLOSE_1()
        {
            /*" -596- EXEC SQL CLOSE V0BANCO END-EXEC */

            V0BANCO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R320_EXIT*/

        [StopWatch]
        /*" R320-00-FETCH-BANCO-DB-CLOSE-2 */
        public void R320_00_FETCH_BANCO_DB_CLOSE_2()
        {
            /*" -621- EXEC SQL CLOSE V0BANCO END-EXEC. */

            V0BANCO.Close();

        }

        [StopWatch]
        /*" R1000-DISPLAY-INSERT */
        private void R1000_DISPLAY_INSERT(bool isPerform = false)
        {
            /*" -644- DISPLAY 'OD001-NUM-PESSOA.........' OD001-NUM-PESSOA */
            _.Display($"OD001-NUM-PESSOA.........{OD001.DCLOD_PESSOA.OD001_NUM_PESSOA}");

            /*" -645- DISPLAY 'OD001-DTH-CADASTRAMENTO..' OD001-DTH-CADASTRAMENTO */
            _.Display($"OD001-DTH-CADASTRAMENTO..{OD001.DCLOD_PESSOA.OD001_DTH_CADASTRAMENTO}");

            /*" -646- DISPLAY 'OD001-NUM-DV-PESSOA......' OD001-NUM-DV-PESSOA */
            _.Display($"OD001-NUM-DV-PESSOA......{OD001.DCLOD_PESSOA.OD001_NUM_DV_PESSOA}");

            /*" -647- DISPLAY 'OD001-IND-PESSOA.........' OD001-IND-PESSOA */
            _.Display($"OD001-IND-PESSOA.........{OD001.DCLOD_PESSOA.OD001_IND_PESSOA}");

            /*" -648- DISPLAY 'OD001-STA-INF-INTEGRA....' OD001-STA-INF-INTEGRA */
            _.Display($"OD001-STA-INF-INTEGRA....{OD001.DCLOD_PESSOA.OD001_STA_INF_INTEGRA}");

            /*" -649- DISPLAY ' ' */
            _.Display($" ");

            /*" -650- DISPLAY 'NUM-PESSOA......... ' OD009-NUM-PESSOA */
            _.Display($"NUM-PESSOA......... {OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_PESSOA}");

            /*" -651- DISPLAY 'SEQ-CONTA-BANCARIA. ' OD009-SEQ-CONTA-BANCARIA */
            _.Display($"SEQ-CONTA-BANCARIA. {OD009.DCLOD_PESS_CONTA_BANC.OD009_SEQ_CONTA_BANCARIA}");

            /*" -652- DISPLAY 'DTH-CADASTRAMENTO.. ' OD009-DTH-CADASTRAMENTO */
            _.Display($"DTH-CADASTRAMENTO.. {OD009.DCLOD_PESS_CONTA_BANC.OD009_DTH_CADASTRAMENTO}");

            /*" -653- DISPLAY 'STA-CONTA.......... ' OD009-STA-CONTA */
            _.Display($"STA-CONTA.......... {OD009.DCLOD_PESS_CONTA_BANC.OD009_STA_CONTA}");

            /*" -654- DISPLAY 'COD-BANCO.......... ' OD009-COD-BANCO */
            _.Display($"COD-BANCO.......... {OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_BANCO}");

            /*" -655- DISPLAY 'COD-AGENCIA........ ' OD009-COD-AGENCIA */
            _.Display($"COD-AGENCIA........ {OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_AGENCIA}");

            /*" -656- DISPLAY 'IND-CONTA-BANCARIA. ' OD009-IND-CONTA-BANCARIA */
            _.Display($"IND-CONTA-BANCARIA. {OD009.DCLOD_PESS_CONTA_BANC.OD009_IND_CONTA_BANCARIA}");

            /*" -657- DISPLAY 'NUM-CONTA.......... ' OD009-NUM-CONTA */
            _.Display($"NUM-CONTA.......... {OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_CONTA}");

            /*" -658- DISPLAY 'NUM-DV-CONTA....... ' OD009-NUM-DV-CONTA */
            _.Display($"NUM-DV-CONTA....... {OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_DV_CONTA}");

            /*" -658- DISPLAY 'NUM-OPERACAO-CONTA. ' OD009-NUM-OPERACAO-CONTA. */
            _.Display($"NUM-OPERACAO-CONTA. {OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_OPERACAO_CONTA}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_EXIT*/

        [StopWatch]
        /*" R9999-00-CANCELA-PROGRAMA */
        private void R9999_00_CANCELA_PROGRAMA(bool isPerform = false)
        {
            /*" -665- MOVE 'SIM' TO LINK-IND-ERRO */
            _.Move("SIM", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_IND_ERRO);

            /*" -668- MOVE SQLCODE TO LINK-SQLCODE WSQLCODE */
            _.Move(DB.SQLCODE, LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_SQLCODE, AREA_DE_WORK.WABEND.WABEND3.WSQLCODE);

            /*" -669- DISPLAY ' ' */
            _.Display($" ");

            /*" -670- DISPLAY '=====  PROGRAMA ABENDADO  =====' */
            _.Display($"=====  PROGRAMA ABENDADO  =====");

            /*" -671- DISPLAY ' ' */
            _.Display($" ");

            /*" -673- DISPLAY 'ERRO NA ROTINA GE0503B ' */
            _.Display($"ERRO NA ROTINA GE0503B ");

            /*" -674- DISPLAY ' ' */
            _.Display($" ");

            /*" -675- DISPLAY 'LINK-MSG-ADICIONAL.. ' LINK-MSG-ADICIONAL */
            _.Display($"LINK-MSG-ADICIONAL.. {LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ADICIONAL}");

            /*" -676- DISPLAY 'LINK-IND-ERRO....... ' LINK-IND-ERRO */
            _.Display($"LINK-IND-ERRO....... {LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_IND_ERRO}");

            /*" -677- DISPLAY 'LINK-MSG-ERRO....... ' LINK-MSG-ERRO */
            _.Display($"LINK-MSG-ERRO....... {LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO}");

            /*" -678- DISPLAY 'LINK-SQLCODE........ ' LINK-SQLCODE */
            _.Display($"LINK-SQLCODE........ {LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_SQLCODE}");

            /*" -679- DISPLAY 'LINK-NOME-TABELA.... ' LINK-NOME-TABELA */
            _.Display($"LINK-NOME-TABELA.... {LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_NOME_TABELA}");

            /*" -680- DISPLAY ' ' */
            _.Display($" ");

            /*" -681- DISPLAY WABEND1. */
            _.Display(AREA_DE_WORK.WABEND.WABEND1);

            /*" -682- DISPLAY WABEND2. */
            _.Display(AREA_DE_WORK.WABEND.WABEND2);

            /*" -686- DISPLAY WABEND3. */
            _.Display(AREA_DE_WORK.WABEND.WABEND3);

            /*" -692- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -692- GOBACK. */

            throw new GoBack();

        }
    }
}