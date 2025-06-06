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
using Sias.Sinistro.DB2.SI4922B;

namespace Code
{
    public class SI4922B
    {
        public bool IsCall { get; set; }

        public SI4922B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  PROJETO REDUCAO DE CHEQUE          *      */
        /*"      *   PROGRAMA ...............  SI4922B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  FAST COMPUTER                      *      */
        /*"      *   PROGRAMADOR ............  MARCO ANTONIO                      *      */
        /*"      *   DATA CODIFICACAO .......  ABRIL / 2009                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO.. VERIFICAR SE A QUANTIDADE DE DIAS ENTRE A DATA             */
        /*"      *            DE PAGAMENTO NEGOCIADA COM O CLIENTE ESTA DE ACORDO        */
        /*"      *            COM O PRAZO NECESSARIO PARA EMISSAO DO CHEQUE OU           */
        /*"      *            GERACAO E ENVIO DO ARQUIVO AOS BANCOS (BB OU CAIXA)        */
        /*"      *            OU SIACC                                                   */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 01 - OPTI-397                                         *      */
        /*"      *             - DIMINUIR QTD DE DISPLAY                          *      */
        /*"      *   EM 27/09/2024 - HERVAL SOUZA                                 *      */
        /*"      *                                       PROCURE POR V.01         *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01     AREA-DE-WORK.*/
        public SI4922B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SI4922B_AREA_DE_WORK();
        public class SI4922B_AREA_DE_WORK : VarBasis
        {
            /*"  05 IND-NULL-01                     PIC  S9(04) COMP VALUE +0.*/
            public IntBasis IND_NULL_01 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05 IND-NULL-02                     PIC  S9(04) COMP VALUE +0.*/
            public IntBasis IND_NULL_02 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05   W-EDICAO                      PIC  Z.ZZZ.ZZ9,99-.*/
            public DoubleBasis W_EDICAO { get; set; } = new DoubleBasis(new PIC("9", "7", "Z.ZZZ.ZZ9V99-."), 3);
            /*"  05 W-DATA-CONVENIO-BB-CAIXA        PIC  X(10) VALUE SPACES.*/
            public StringBasis W_DATA_CONVENIO_BB_CAIXA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"  05 W-DATA-CONVENIO-SIACC-CAIXA     PIC  X(10) VALUE SPACES.*/
            public StringBasis W_DATA_CONVENIO_SIACC_CAIXA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"  05 W-DATA-CHEQUE                   PIC  X(10) VALUE SPACES.*/
            public StringBasis W_DATA_CHEQUE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"  05 W-DATA-CORRENTE                 PIC  X(10) VALUE SPACES.*/
            public StringBasis W_DATA_CORRENTE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"  05 W-DATA-LIMITE-MAXIMO            PIC  X(10) VALUE SPACES.*/
            public StringBasis W_DATA_LIMITE_MAXIMO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"  05 W-DATA-PROXIMO-DIA-UTIL         PIC  X(10) VALUE SPACES.*/
            public StringBasis W_DATA_PROXIMO_DIA_UTIL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"  05 HOST-DATA-SISTEMA               PIC  X(10) VALUE SPACES.*/
            public StringBasis HOST_DATA_SISTEMA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"  05 HOST-DATA-NEGOCIADA             PIC  X(10) VALUE SPACES.*/
            public StringBasis HOST_DATA_NEGOCIADA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"  05 HOST-CURRENT-DATE               PIC  X(10) VALUE SPACES.*/
            public StringBasis HOST_CURRENT_DATE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"  05 HOST-CURRENT-TIMESTAMP          PIC  X(26) VALUE SPACES.*/
            public StringBasis HOST_CURRENT_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)"), @"");
            /*"  05 WS-PRIMEIRA-VEZ                 PIC  X(03) VALUE 'SIM'.*/
            public StringBasis WS_PRIMEIRA_VEZ { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"SIM");
            /*"  05 W-DATA-PARA-CHEQUE              PIC  X(10) VALUE SPACES.*/
            public StringBasis W_DATA_PARA_CHEQUE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"  05 W-DATA-PARA-CREDITO-EM-CONTA    PIC  X(10) VALUE SPACES.*/
            public StringBasis W_DATA_PARA_CREDITO_EM_CONTA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"  05 W-CONTA-DATAS                   PIC  9(03) VALUE 0.*/
            public IntBasis W_CONTA_DATAS { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
            /*"  05 W-CONTA-DIAS                    PIC  9(03) VALUE 0.*/
            public IntBasis W_CONTA_DIAS { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
            /*"  05   WABEND.*/
            public SI4922B_WABEND WABEND { get; set; } = new SI4922B_WABEND();
            public class SI4922B_WABEND : VarBasis
            {
                /*"    10 WABEND1                       PIC  X(009)  VALUE                                                      'SI4922B '*/
                public StringBasis WABEND1 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"SI4922B ");
                /*"    10 WABEND2.*/
                public SI4922B_WABEND2 WABEND2 { get; set; } = new SI4922B_WABEND2();
                public class SI4922B_WABEND2 : VarBasis
                {
                    /*"      15 FILLER                      PIC  X(025)  VALUE                                     '*** ERRO EXEC SQL NUMERO '*/
                    public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"*** ERRO EXEC SQL NUMERO ");
                    /*"      15 WNR-EXEC-SQL                PIC  X(005)  VALUE SPACES.*/
                    public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                    /*"    10 WABEND3.*/
                }
                public SI4922B_WABEND3 WABEND3 { get; set; } = new SI4922B_WABEND3();
                public class SI4922B_WABEND3 : VarBasis
                {
                    /*"      15 FILLER                      PIC  X(013)  VALUE                                                 ' *** SQLCODE '*/
                    public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                    /*"      15 WSQLCODE                    PIC  -999.*/
                    public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "3", "-999."));
                    /*"01     LK-PARAMETRO.*/
                }
            }
        }
        public SI4922B_LK_PARAMETRO LK_PARAMETRO { get; set; } = new SI4922B_LK_PARAMETRO();
        public class SI4922B_LK_PARAMETRO : VarBasis
        {
            /*"  05   LK-FORMA-PAGAMENTO            PIC 9(01).*/
            public IntBasis LK_FORMA_PAGAMENTO { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
            /*"  05   LK-DATA-SISTEMA.*/
            public SI4922B_LK_DATA_SISTEMA LK_DATA_SISTEMA { get; set; } = new SI4922B_LK_DATA_SISTEMA();
            public class SI4922B_LK_DATA_SISTEMA : VarBasis
            {
                /*"       10 LK-DATA-SISTEMA-AAAA      PIC X(04).*/
                public StringBasis LK_DATA_SISTEMA_AAAA { get; set; } = new StringBasis(new PIC("X", "4", "X(04)."), @"");
                /*"       10 LK-DATA-SISTEMA-FILLER1   PIC X(01).*/
                public StringBasis LK_DATA_SISTEMA_FILLER1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10 LK-DATA-SISTEMA-MM        PIC X(02).*/
                public StringBasis LK_DATA_SISTEMA_MM { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
                /*"       10 LK-DATA-SISTEMA-FILLER2   PIC X(01).*/
                public StringBasis LK_DATA_SISTEMA_FILLER2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10 LK-DATA-SISTEMA-DD        PIC X(02).*/
                public StringBasis LK_DATA_SISTEMA_DD { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
                /*"  05   LK-DATA-NEGOCIADA.*/
            }
            public SI4922B_LK_DATA_NEGOCIADA LK_DATA_NEGOCIADA { get; set; } = new SI4922B_LK_DATA_NEGOCIADA();
            public class SI4922B_LK_DATA_NEGOCIADA : VarBasis
            {
                /*"       10 LK-DATA-NEGOCIADA-AAAA    PIC X(04).*/
                public StringBasis LK_DATA_NEGOCIADA_AAAA { get; set; } = new StringBasis(new PIC("X", "4", "X(04)."), @"");
                /*"       10 LK-DATA-NEGOCIADA-FILLER1 PIC X(01).*/
                public StringBasis LK_DATA_NEGOCIADA_FILLER1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10 LK-DATA-NEGOCIADA-MM      PIC X(02).*/
                public StringBasis LK_DATA_NEGOCIADA_MM { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
                /*"       10 LK-DATA-NEGOCIADA-FILLER2 PIC X(01).*/
                public StringBasis LK_DATA_NEGOCIADA_FILLER2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10 LK-DATA-NEGOCIADA-DD      PIC X(02).*/
                public StringBasis LK_DATA_NEGOCIADA_DD { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
                /*"  05   LK-PARAMETROS-SAIDA.*/
            }
            public SI4922B_LK_PARAMETROS_SAIDA LK_PARAMETROS_SAIDA { get; set; } = new SI4922B_LK_PARAMETROS_SAIDA();
            public class SI4922B_LK_PARAMETROS_SAIDA : VarBasis
            {
                /*"       10 LK-DATA-CREDITO-EM-CONTA  PIC X(10).*/
                public StringBasis LK_DATA_CREDITO_EM_CONTA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"       10 LK-CHAVE-GERA-BAIXA       PIC X(03).*/
                public StringBasis LK_CHAVE_GERA_BAIXA { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
                /*"       10 LK-IND-ERRO               PIC X(03).*/
                public StringBasis LK_IND_ERRO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
                /*"       10 LK-MSG-ERRO               PIC X(80).*/
                public StringBasis LK_MSG_ERRO { get; set; } = new StringBasis(new PIC("X", "80", "X(80)."), @"");
                /*"       10 LK-SQLCODE                PIC S9(004) COMP.*/
                public IntBasis LK_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"       10 LK-NOME-TABELA            PIC X(30).*/
                public StringBasis LK_NOME_TABELA { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
            }
        }


        public Dclgens.CALENDAR CALENDAR { get; set; } = new Dclgens.CALENDAR();
        public SI4922B_CURSOR_DATA CURSOR_DATA { get; set; } = new SI4922B_CURSOR_DATA();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(SI4922B_LK_PARAMETRO SI4922B_LK_PARAMETRO_P) //PROCEDURE DIVISION USING 
        /*LK_PARAMETRO*/
        {
            try
            {
                this.LK_PARAMETRO = SI4922B_LK_PARAMETRO_P;

                /*" -0- FLUXCONTROL_PERFORM R000-INICIO */

                R000_INICIO();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LK_PARAMETRO, CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R000-INICIO */
        private void R000_INICIO(bool isPerform = false)
        {
            /*" -143- MOVE '0001' TO WNR-EXEC-SQL */
            _.Move("0001", AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL);

            /*" -143- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -144- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -145- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -148- IF WS-PRIMEIRA-VEZ = 'SIM' */

            if (AREA_DE_WORK.WS_PRIMEIRA_VEZ == "SIM")
            {

                /*" -149- DISPLAY ' ' */
                _.Display($" ");

                /*" -156- DISPLAY 'SI4922B  VERSAO 01: ' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) ' AS ' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) '     ***' */

                $"SI4922B  VERSAO 01: FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)} AS FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}     ***"
                .Display();

                /*" -158- END-IF. */
            }


            /*" -159- INITIALIZE LK-PARAMETROS-SAIDA. */
            _.Initialize(
                LK_PARAMETRO.LK_PARAMETROS_SAIDA
            );

            /*" -163- MOVE 'NAO' TO LK-CHAVE-GERA-BAIXA . */
            _.Move("NAO", LK_PARAMETRO.LK_PARAMETROS_SAIDA.LK_CHAVE_GERA_BAIXA);

            /*" -165- IF (LK-DATA-SISTEMA-FILLER1 NOT EQUAL '-' ) OR (LK-DATA-SISTEMA-FILLER2 NOT EQUAL '-' ) */

            if ((LK_PARAMETRO.LK_DATA_SISTEMA.LK_DATA_SISTEMA_FILLER1 != "-") || (LK_PARAMETRO.LK_DATA_SISTEMA.LK_DATA_SISTEMA_FILLER2 != "-"))
            {

                /*" -167- MOVE 'SI4922B - DATA SISTEMA COM FORMADO INVALIDO HIFEN' TO LK-MSG-ERRO */
                _.Move("SI4922B - DATA SISTEMA COM FORMADO INVALIDO HIFEN", LK_PARAMETRO.LK_PARAMETROS_SAIDA.LK_MSG_ERRO);

                /*" -169- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA(); //GOTO
                return;
            }


            /*" -171- IF (LK-DATA-NEGOCIADA-FILLER1 NOT EQUAL '-' ) OR (LK-DATA-NEGOCIADA-FILLER2 NOT EQUAL '-' ) */

            if ((LK_PARAMETRO.LK_DATA_NEGOCIADA.LK_DATA_NEGOCIADA_FILLER1 != "-") || (LK_PARAMETRO.LK_DATA_NEGOCIADA.LK_DATA_NEGOCIADA_FILLER2 != "-"))
            {

                /*" -173- MOVE 'SI4922B - DATA NEGOCIADA COM FORMADO INVALIDO HIFEN' TO LK-MSG-ERRO */
                _.Move("SI4922B - DATA NEGOCIADA COM FORMADO INVALIDO HIFEN", LK_PARAMETRO.LK_PARAMETROS_SAIDA.LK_MSG_ERRO);

                /*" -175- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA(); //GOTO
                return;
            }


            /*" -178- IF (LK-FORMA-PAGAMENTO NOT EQUAL 1) AND (LK-FORMA-PAGAMENTO NOT EQUAL 2) AND (LK-FORMA-PAGAMENTO NOT EQUAL 7) */

            if ((LK_PARAMETRO.LK_FORMA_PAGAMENTO != 1) && (LK_PARAMETRO.LK_FORMA_PAGAMENTO != 2) && (LK_PARAMETRO.LK_FORMA_PAGAMENTO != 7))
            {

                /*" -180- MOVE 'SI4922B - FORMA DE PAGAMENTO INVALIDA' TO LK-MSG-ERRO */
                _.Move("SI4922B - FORMA DE PAGAMENTO INVALIDA", LK_PARAMETRO.LK_PARAMETROS_SAIDA.LK_MSG_ERRO);

                /*" -182- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA(); //GOTO
                return;
            }


            /*" -183- IF LK-DATA-SISTEMA EQUAL SPACES */

            if (LK_PARAMETRO.LK_DATA_SISTEMA.IsEmpty())
            {

                /*" -185- MOVE 'SI4922B - DATA DO SISTEMA NAO INFORMADA' TO LK-MSG-ERRO */
                _.Move("SI4922B - DATA DO SISTEMA NAO INFORMADA", LK_PARAMETRO.LK_PARAMETROS_SAIDA.LK_MSG_ERRO);

                /*" -187- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA(); //GOTO
                return;
            }


            /*" -188- IF LK-DATA-NEGOCIADA EQUAL SPACES */

            if (LK_PARAMETRO.LK_DATA_NEGOCIADA.IsEmpty())
            {

                /*" -190- MOVE 'SI4922B - DATA NEGOCIADA DE PAGAMENTO NAO INFORMADA' TO LK-MSG-ERRO */
                _.Move("SI4922B - DATA NEGOCIADA DE PAGAMENTO NAO INFORMADA", LK_PARAMETRO.LK_PARAMETROS_SAIDA.LK_MSG_ERRO);

                /*" -194- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA(); //GOTO
                return;
            }


            /*" -196- MOVE LK-DATA-SISTEMA TO HOST-DATA-SISTEMA */
            _.Move(LK_PARAMETRO.LK_DATA_SISTEMA, AREA_DE_WORK.HOST_DATA_SISTEMA);

            /*" -201- PERFORM R000_INICIO_DB_SELECT_1 */

            R000_INICIO_DB_SELECT_1();

            /*" -204- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -206- MOVE 'SI4922B - DATA SISTEMA NAO TEM NA TAB. CALENDARIO' TO LK-MSG-ERRO */
                _.Move("SI4922B - DATA SISTEMA NAO TEM NA TAB. CALENDARIO", LK_PARAMETRO.LK_PARAMETROS_SAIDA.LK_MSG_ERRO);

                /*" -208- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA(); //GOTO
                return;
            }


            /*" -209- IF SQLCODE EQUAL -180 */

            if (DB.SQLCODE == -180)
            {

                /*" -211- MOVE 'SI4922B - DATA SISTEMA COM FORMATO INVALIDO' TO LK-MSG-ERRO */
                _.Move("SI4922B - DATA SISTEMA COM FORMATO INVALIDO", LK_PARAMETRO.LK_PARAMETROS_SAIDA.LK_MSG_ERRO);

                /*" -213- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA(); //GOTO
                return;
            }


            /*" -215- MOVE LK-DATA-NEGOCIADA TO HOST-DATA-NEGOCIADA */
            _.Move(LK_PARAMETRO.LK_DATA_NEGOCIADA, AREA_DE_WORK.HOST_DATA_NEGOCIADA);

            /*" -220- PERFORM R000_INICIO_DB_SELECT_2 */

            R000_INICIO_DB_SELECT_2();

            /*" -223- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -225- MOVE 'SI4922B - DATA NEGOCIADA NAO TEM NA TAB. CALENDARIO' TO LK-MSG-ERRO */
                _.Move("SI4922B - DATA NEGOCIADA NAO TEM NA TAB. CALENDARIO", LK_PARAMETRO.LK_PARAMETROS_SAIDA.LK_MSG_ERRO);

                /*" -227- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA(); //GOTO
                return;
            }


            /*" -228- IF SQLCODE EQUAL -180 */

            if (DB.SQLCODE == -180)
            {

                /*" -230- MOVE 'SI4922B - DATA NEGOCIADA COM FORMATO INVALIDO' TO LK-MSG-ERRO */
                _.Move("SI4922B - DATA NEGOCIADA COM FORMATO INVALIDO", LK_PARAMETRO.LK_PARAMETROS_SAIDA.LK_MSG_ERRO);

                /*" -232- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA(); //GOTO
                return;
            }


            /*" -234- PERFORM R100-LIMITE-MAXIMO THRU R100-EXIT . */

            R100_LIMITE_MAXIMO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/


            /*" -242- PERFORM R110-PROXIMO-DIA-UTIL THRU R110-EXIT . */

            R110_PROXIMO_DIA_UTIL(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R110_EXIT*/


            /*" -243- MOVE W-DATA-PROXIMO-DIA-UTIL TO W-DATA-CHEQUE . */
            _.Move(AREA_DE_WORK.W_DATA_PROXIMO_DIA_UTIL, AREA_DE_WORK.W_DATA_CHEQUE);

            /*" -244- IF WS-PRIMEIRA-VEZ = 'SIM' */

            if (AREA_DE_WORK.WS_PRIMEIRA_VEZ == "SIM")
            {

                /*" -245- DISPLAY 'P/ CHEQUE (PRX DU).. ' W-DATA-CHEQUE */
                _.Display($"P/ CHEQUE (PRX DU).. {AREA_DE_WORK.W_DATA_CHEQUE}");

                /*" -253- END-IF. */
            }


            /*" -255- MOVE 2 TO W-CONTA-DATAS. */
            _.Move(2, AREA_DE_WORK.W_CONTA_DATAS);

            /*" -256- PERFORM R120-DATA-PARA-CONVENIO THRU R120-EXIT . */

            R120_DATA_PARA_CONVENIO(true);

            R120_NOVO_FETCH(true);

            R120_CLOSE(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


            /*" -258- MOVE CALENDAR-DATA-CALENDARIO TO W-DATA-CONVENIO-BB-CAIXA */
            _.Move(CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO, AREA_DE_WORK.W_DATA_CONVENIO_BB_CAIXA);

            /*" -259- IF WS-PRIMEIRA-VEZ = 'SIM' */

            if (AREA_DE_WORK.WS_PRIMEIRA_VEZ == "SIM")
            {

                /*" -260- DISPLAY 'P/ BB E CAIXA ...... ' W-DATA-CONVENIO-BB-CAIXA */
                _.Display($"P/ BB E CAIXA ...... {AREA_DE_WORK.W_DATA_CONVENIO_BB_CAIXA}");

                /*" -265- END-IF. */
            }


            /*" -267- MOVE 3 TO W-CONTA-DATAS */
            _.Move(3, AREA_DE_WORK.W_CONTA_DATAS);

            /*" -268- PERFORM R120-DATA-PARA-CONVENIO THRU R120-EXIT . */

            R120_DATA_PARA_CONVENIO(true);

            R120_NOVO_FETCH(true);

            R120_CLOSE(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


            /*" -270- MOVE CALENDAR-DATA-CALENDARIO TO W-DATA-CONVENIO-SIACC-CAIXA */
            _.Move(CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO, AREA_DE_WORK.W_DATA_CONVENIO_SIACC_CAIXA);

            /*" -271- IF WS-PRIMEIRA-VEZ = 'SIM' */

            if (AREA_DE_WORK.WS_PRIMEIRA_VEZ == "SIM")
            {

                /*" -273- DISPLAY 'P/ SIACC ........... ' W-DATA-CONVENIO-SIACC-CAIXA */
                _.Display($"P/ SIACC ........... {AREA_DE_WORK.W_DATA_CONVENIO_SIACC_CAIXA}");

                /*" -275- END-IF. */
            }


            /*" -276- IF LK-DATA-NEGOCIADA NOT GREATER LK-DATA-SISTEMA */

            if (LK_PARAMETRO.LK_DATA_NEGOCIADA <= LK_PARAMETRO.LK_DATA_SISTEMA)
            {

                /*" -277- IF LK-FORMA-PAGAMENTO EQUAL 1 */

                if (LK_PARAMETRO.LK_FORMA_PAGAMENTO == 1)
                {

                    /*" -278- MOVE W-DATA-CHEQUE TO LK-DATA-CREDITO-EM-CONTA */
                    _.Move(AREA_DE_WORK.W_DATA_CHEQUE, LK_PARAMETRO.LK_PARAMETROS_SAIDA.LK_DATA_CREDITO_EM_CONTA);

                    /*" -279- END-IF */
                }


                /*" -280- IF LK-FORMA-PAGAMENTO EQUAL 2 */

                if (LK_PARAMETRO.LK_FORMA_PAGAMENTO == 2)
                {

                    /*" -282- MOVE W-DATA-CONVENIO-BB-CAIXA TO LK-DATA-CREDITO-EM-CONTA */
                    _.Move(AREA_DE_WORK.W_DATA_CONVENIO_BB_CAIXA, LK_PARAMETRO.LK_PARAMETROS_SAIDA.LK_DATA_CREDITO_EM_CONTA);

                    /*" -283- END-IF */
                }


                /*" -284- IF LK-FORMA-PAGAMENTO EQUAL 7 */

                if (LK_PARAMETRO.LK_FORMA_PAGAMENTO == 7)
                {

                    /*" -286- MOVE W-DATA-CONVENIO-SIACC-CAIXA TO LK-DATA-CREDITO-EM-CONTA */
                    _.Move(AREA_DE_WORK.W_DATA_CONVENIO_SIACC_CAIXA, LK_PARAMETRO.LK_PARAMETROS_SAIDA.LK_DATA_CREDITO_EM_CONTA);

                    /*" -287- END-IF */
                }


                /*" -288- MOVE 'SIM' TO LK-CHAVE-GERA-BAIXA */
                _.Move("SIM", LK_PARAMETRO.LK_PARAMETROS_SAIDA.LK_CHAVE_GERA_BAIXA);

                /*" -290- GO TO R000-FIM-NORMAL. */

                R000_FIM_NORMAL(); //GOTO
                return;
            }


            /*" -292- IF LK-FORMA-PAGAMENTO EQUAL 1 AND LK-DATA-NEGOCIADA EQUAL W-DATA-CHEQUE */

            if (LK_PARAMETRO.LK_FORMA_PAGAMENTO == 1 && LK_PARAMETRO.LK_DATA_NEGOCIADA == AREA_DE_WORK.W_DATA_CHEQUE)
            {

                /*" -293- MOVE W-DATA-CHEQUE TO LK-DATA-CREDITO-EM-CONTA */
                _.Move(AREA_DE_WORK.W_DATA_CHEQUE, LK_PARAMETRO.LK_PARAMETROS_SAIDA.LK_DATA_CREDITO_EM_CONTA);

                /*" -294- MOVE 'SIM' TO LK-CHAVE-GERA-BAIXA */
                _.Move("SIM", LK_PARAMETRO.LK_PARAMETROS_SAIDA.LK_CHAVE_GERA_BAIXA);

                /*" -299- GO TO R000-FIM-NORMAL. */

                R000_FIM_NORMAL(); //GOTO
                return;
            }


            /*" -301- IF LK-FORMA-PAGAMENTO EQUAL 2 AND LK-DATA-NEGOCIADA NOT GREATER W-DATA-CONVENIO-BB-CAIXA */

            if (LK_PARAMETRO.LK_FORMA_PAGAMENTO == 2 && LK_PARAMETRO.LK_DATA_NEGOCIADA <= AREA_DE_WORK.W_DATA_CONVENIO_BB_CAIXA)
            {

                /*" -302- MOVE W-DATA-CONVENIO-BB-CAIXA TO LK-DATA-CREDITO-EM-CONTA */
                _.Move(AREA_DE_WORK.W_DATA_CONVENIO_BB_CAIXA, LK_PARAMETRO.LK_PARAMETROS_SAIDA.LK_DATA_CREDITO_EM_CONTA);

                /*" -303- MOVE 'SIM' TO LK-CHAVE-GERA-BAIXA */
                _.Move("SIM", LK_PARAMETRO.LK_PARAMETROS_SAIDA.LK_CHAVE_GERA_BAIXA);

                /*" -305- GO TO R000-FIM-NORMAL. */

                R000_FIM_NORMAL(); //GOTO
                return;
            }


            /*" -308- IF LK-FORMA-PAGAMENTO EQUAL 7 AND LK-DATA-NEGOCIADA NOT GREATER W-DATA-CONVENIO-SIACC-CAIXA */

            if (LK_PARAMETRO.LK_FORMA_PAGAMENTO == 7 && LK_PARAMETRO.LK_DATA_NEGOCIADA <= AREA_DE_WORK.W_DATA_CONVENIO_SIACC_CAIXA)
            {

                /*" -310- MOVE W-DATA-CONVENIO-SIACC-CAIXA TO LK-DATA-CREDITO-EM-CONTA */
                _.Move(AREA_DE_WORK.W_DATA_CONVENIO_SIACC_CAIXA, LK_PARAMETRO.LK_PARAMETROS_SAIDA.LK_DATA_CREDITO_EM_CONTA);

                /*" -311- MOVE 'SIM' TO LK-CHAVE-GERA-BAIXA */
                _.Move("SIM", LK_PARAMETRO.LK_PARAMETROS_SAIDA.LK_CHAVE_GERA_BAIXA);

                /*" -313- GO TO R000-FIM-NORMAL. */

                R000_FIM_NORMAL(); //GOTO
                return;
            }


            /*" -313- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

        }

        [StopWatch]
        /*" R000-INICIO-DB-SELECT-1 */
        public void R000_INICIO_DB_SELECT_1()
        {
            /*" -201- EXEC SQL SELECT DATA_CALENDARIO INTO :CALENDAR-DATA-CALENDARIO FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO = :HOST-DATA-SISTEMA END-EXEC. */

            var r000_INICIO_DB_SELECT_1_Query1 = new R000_INICIO_DB_SELECT_1_Query1()
            {
                HOST_DATA_SISTEMA = AREA_DE_WORK.HOST_DATA_SISTEMA.ToString(),
            };

            var executed_1 = R000_INICIO_DB_SELECT_1_Query1.Execute(r000_INICIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CALENDAR_DATA_CALENDARIO, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);
            }


        }

        [StopWatch]
        /*" R000-FIM-NORMAL */
        private void R000_FIM_NORMAL(bool isPerform = false)
        {
            /*" -322- DISPLAY '....FIM NORMAL...' */
            _.Display($"....FIM NORMAL...");

            /*" -323- DISPLAY 'LK-FORMA-PAGAMENTO...... ' LK-FORMA-PAGAMENTO */
            _.Display($"LK-FORMA-PAGAMENTO...... {LK_PARAMETRO.LK_FORMA_PAGAMENTO}");

            /*" -324- DISPLAY 'LK-DATA-SISTEMA......... ' LK-DATA-SISTEMA */
            _.Display($"LK-DATA-SISTEMA......... {LK_PARAMETRO.LK_DATA_SISTEMA}");

            /*" -325- DISPLAY 'LK-DATA-NEGOCIADA....... ' LK-DATA-NEGOCIADA */
            _.Display($"LK-DATA-NEGOCIADA....... {LK_PARAMETRO.LK_DATA_NEGOCIADA}");

            /*" -326- DISPLAY 'LK-DATA-CREDITO-EM-CONTA ' LK-DATA-CREDITO-EM-CONTA */
            _.Display($"LK-DATA-CREDITO-EM-CONTA {LK_PARAMETRO.LK_PARAMETROS_SAIDA.LK_DATA_CREDITO_EM_CONTA}");

            /*" -327- DISPLAY 'LK-CHAVE-GERA-BAIXA..... ' LK-CHAVE-GERA-BAIXA */
            _.Display($"LK-CHAVE-GERA-BAIXA..... {LK_PARAMETRO.LK_PARAMETROS_SAIDA.LK_CHAVE_GERA_BAIXA}");

            /*" -328- DISPLAY 'LK-IND-ERRO............. ' LK-IND-ERRO */
            _.Display($"LK-IND-ERRO............. {LK_PARAMETRO.LK_PARAMETROS_SAIDA.LK_IND_ERRO}");

            /*" -330- DISPLAY 'LK-MSG-ERRO............. ' LK-MSG-ERRO . */
            _.Display($"LK-MSG-ERRO............. {LK_PARAMETRO.LK_PARAMETROS_SAIDA.LK_MSG_ERRO}");

            /*" -334- MOVE 'NAO' TO WS-PRIMEIRA-VEZ. */
            _.Move("NAO", AREA_DE_WORK.WS_PRIMEIRA_VEZ);

            /*" -334- GOBACK. */

            throw new GoBack();

        }

        [StopWatch]
        /*" R000-INICIO-DB-SELECT-2 */
        public void R000_INICIO_DB_SELECT_2()
        {
            /*" -220- EXEC SQL SELECT DATA_CALENDARIO INTO :CALENDAR-DATA-CALENDARIO FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO = :HOST-DATA-NEGOCIADA END-EXEC. */

            var r000_INICIO_DB_SELECT_2_Query1 = new R000_INICIO_DB_SELECT_2_Query1()
            {
                HOST_DATA_NEGOCIADA = AREA_DE_WORK.HOST_DATA_NEGOCIADA.ToString(),
            };

            var executed_1 = R000_INICIO_DB_SELECT_2_Query1.Execute(r000_INICIO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CALENDAR_DATA_CALENDARIO, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);
            }


        }

        [StopWatch]
        /*" R100-LIMITE-MAXIMO */
        private void R100_LIMITE_MAXIMO(bool isPerform = false)
        {
            /*" -347- PERFORM R100_LIMITE_MAXIMO_DB_SELECT_1 */

            R100_LIMITE_MAXIMO_DB_SELECT_1();

            /*" -350- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -352- MOVE 'SI4922B - DATA NEGOCIADA NAO TEM NA TAB. CALENDARIO' TO LK-MSG-ERRO */
                _.Move("SI4922B - DATA NEGOCIADA NAO TEM NA TAB. CALENDARIO", LK_PARAMETRO.LK_PARAMETROS_SAIDA.LK_MSG_ERRO);

                /*" -352- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R100-LIMITE-MAXIMO-DB-SELECT-1 */
        public void R100_LIMITE_MAXIMO_DB_SELECT_1()
        {
            /*" -347- EXEC SQL SELECT CURRENT DATE, CURRENT DATE + 20 DAYS INTO :W-DATA-CORRENTE, :W-DATA-LIMITE-MAXIMO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' END-EXEC. */

            var r100_LIMITE_MAXIMO_DB_SELECT_1_Query1 = new R100_LIMITE_MAXIMO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R100_LIMITE_MAXIMO_DB_SELECT_1_Query1.Execute(r100_LIMITE_MAXIMO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.W_DATA_CORRENTE, AREA_DE_WORK.W_DATA_CORRENTE);
                _.Move(executed_1.W_DATA_LIMITE_MAXIMO, AREA_DE_WORK.W_DATA_LIMITE_MAXIMO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/

        [StopWatch]
        /*" R110-PROXIMO-DIA-UTIL */
        private void R110_PROXIMO_DIA_UTIL(bool isPerform = false)
        {
            /*" -366- PERFORM R110_PROXIMO_DIA_UTIL_DB_SELECT_1 */

            R110_PROXIMO_DIA_UTIL_DB_SELECT_1();

            /*" -369- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -371- MOVE 'SI4922B - ERRO ACESSO DT. PROXIMO DIA UTIL' TO LK-MSG-ERRO */
                _.Move("SI4922B - ERRO ACESSO DT. PROXIMO DIA UTIL", LK_PARAMETRO.LK_PARAMETROS_SAIDA.LK_MSG_ERRO);

                /*" -371- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R110-PROXIMO-DIA-UTIL-DB-SELECT-1 */
        public void R110_PROXIMO_DIA_UTIL_DB_SELECT_1()
        {
            /*" -366- EXEC SQL SELECT MIN(DATA_CALENDARIO) INTO :W-DATA-PROXIMO-DIA-UTIL FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO > :HOST-DATA-SISTEMA AND DATA_CALENDARIO <= :W-DATA-LIMITE-MAXIMO AND DIA_SEMANA IN ( '2' , '3' , '4' , '5' , '6' ) AND FERIADO = ' ' END-EXEC. */

            var r110_PROXIMO_DIA_UTIL_DB_SELECT_1_Query1 = new R110_PROXIMO_DIA_UTIL_DB_SELECT_1_Query1()
            {
                W_DATA_LIMITE_MAXIMO = AREA_DE_WORK.W_DATA_LIMITE_MAXIMO.ToString(),
                HOST_DATA_SISTEMA = AREA_DE_WORK.HOST_DATA_SISTEMA.ToString(),
            };

            var executed_1 = R110_PROXIMO_DIA_UTIL_DB_SELECT_1_Query1.Execute(r110_PROXIMO_DIA_UTIL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.W_DATA_PROXIMO_DIA_UTIL, AREA_DE_WORK.W_DATA_PROXIMO_DIA_UTIL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R110_EXIT*/

        [StopWatch]
        /*" R120-DATA-PARA-CONVENIO */
        private void R120_DATA_PARA_CONVENIO(bool isPerform = false)
        {
            /*" -384- MOVE 1 TO W-CONTA-DIAS */
            _.Move(1, AREA_DE_WORK.W_CONTA_DIAS);

            /*" -392- PERFORM R120_DATA_PARA_CONVENIO_DB_DECLARE_1 */

            R120_DATA_PARA_CONVENIO_DB_DECLARE_1();

            /*" -394- PERFORM R120_DATA_PARA_CONVENIO_DB_OPEN_1 */

            R120_DATA_PARA_CONVENIO_DB_OPEN_1();

            /*" -396- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -398- MOVE 'SI4922B - ERRO DECLARE CURSOR_DATA (1)' TO LK-MSG-ERRO */
                _.Move("SI4922B - ERRO DECLARE CURSOR_DATA (1)", LK_PARAMETRO.LK_PARAMETROS_SAIDA.LK_MSG_ERRO);

                /*" -398- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R120-DATA-PARA-CONVENIO-DB-DECLARE-1 */
        public void R120_DATA_PARA_CONVENIO_DB_DECLARE_1()
        {
            /*" -392- EXEC SQL DECLARE CURSOR_DATA CURSOR FOR SELECT DATA_CALENDARIO FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO > :HOST-DATA-SISTEMA AND DATA_CALENDARIO <= :W-DATA-LIMITE-MAXIMO AND DIA_SEMANA IN ( '2' , '3' , '4' , '5' , '6' ) AND FERIADO = ' ' ORDER BY DATA_CALENDARIO END-EXEC. */
            CURSOR_DATA = new SI4922B_CURSOR_DATA(true);
            string GetQuery_CURSOR_DATA()
            {
                var query = @$"SELECT DATA_CALENDARIO 
							FROM SEGUROS.CALENDARIO 
							WHERE DATA_CALENDARIO > '{AREA_DE_WORK.HOST_DATA_SISTEMA}' 
							AND DATA_CALENDARIO <= '{AREA_DE_WORK.W_DATA_LIMITE_MAXIMO}' 
							AND DIA_SEMANA IN ( '2'
							, '3'
							, '4'
							, '5'
							, '6' ) 
							AND FERIADO = ' ' 
							ORDER BY DATA_CALENDARIO";

                return query;
            }
            CURSOR_DATA.GetQueryEvent += GetQuery_CURSOR_DATA;

        }

        [StopWatch]
        /*" R120-DATA-PARA-CONVENIO-DB-OPEN-1 */
        public void R120_DATA_PARA_CONVENIO_DB_OPEN_1()
        {
            /*" -394- EXEC SQL OPEN CURSOR_DATA END-EXEC. */

            CURSOR_DATA.Open();

        }

        [StopWatch]
        /*" R120-NOVO-FETCH */
        private void R120_NOVO_FETCH(bool isPerform = false)
        {
            /*" -404- PERFORM R120_NOVO_FETCH_DB_FETCH_1 */

            R120_NOVO_FETCH_DB_FETCH_1();

            /*" -407- IF SQLCODE EQUAL 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -408- IF W-CONTA-DIAS < W-CONTA-DATAS */

                if (AREA_DE_WORK.W_CONTA_DIAS < AREA_DE_WORK.W_CONTA_DATAS)
                {

                    /*" -409- ADD 1 TO W-CONTA-DIAS */
                    AREA_DE_WORK.W_CONTA_DIAS.Value = AREA_DE_WORK.W_CONTA_DIAS + 1;

                    /*" -411- GO TO R120-NOVO-FETCH. */
                    new Task(() => R120_NOVO_FETCH()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...
                }

            }


            /*" -412- IF SQLCODE EQUAL 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -415- IF W-CONTA-DIAS = W-CONTA-DATAS */

                if (AREA_DE_WORK.W_CONTA_DIAS == AREA_DE_WORK.W_CONTA_DATAS)
                {

                    /*" -417- GO TO R120-CLOSE. */

                    R120_CLOSE(); //GOTO
                    return;
                }

            }


            /*" -418- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -418- GO TO R120-CLOSE. */

                R120_CLOSE(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R120-NOVO-FETCH-DB-FETCH-1 */
        public void R120_NOVO_FETCH_DB_FETCH_1()
        {
            /*" -404- EXEC SQL FETCH CURSOR_DATA INTO :CALENDAR-DATA-CALENDARIO END-EXEC. */

            if (CURSOR_DATA.Fetch())
            {
                _.Move(CURSOR_DATA.CALENDAR_DATA_CALENDARIO, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);
            }

        }

        [StopWatch]
        /*" R120-CLOSE */
        private void R120_CLOSE(bool isPerform = false)
        {
            /*" -422- PERFORM R120_CLOSE_DB_CLOSE_1 */

            R120_CLOSE_DB_CLOSE_1();

            /*" -424- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -426- MOVE 'SI4922B - ERRO CLOSE CURSOR_DATA (1)' TO LK-MSG-ERRO */
                _.Move("SI4922B - ERRO CLOSE CURSOR_DATA (1)", LK_PARAMETRO.LK_PARAMETROS_SAIDA.LK_MSG_ERRO);

                /*" -426- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R120-CLOSE-DB-CLOSE-1 */
        public void R120_CLOSE_DB_CLOSE_1()
        {
            /*" -422- EXEC SQL CLOSE CURSOR_DATA END-EXEC */

            CURSOR_DATA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/

        [StopWatch]
        /*" R9999-00-CANCELA-PROGRAMA */
        private void R9999_00_CANCELA_PROGRAMA(bool isPerform = false)
        {
            /*" -434- MOVE 'SIM' TO LK-IND-ERRO */
            _.Move("SIM", LK_PARAMETRO.LK_PARAMETROS_SAIDA.LK_IND_ERRO);

            /*" -437- MOVE SQLCODE TO LK-SQLCODE WSQLCODE */
            _.Move(DB.SQLCODE, LK_PARAMETRO.LK_PARAMETROS_SAIDA.LK_SQLCODE, AREA_DE_WORK.WABEND.WABEND3.WSQLCODE);

            /*" -438- DISPLAY ' ' */
            _.Display($" ");

            /*" -439- DISPLAY '=====  PROGRAMA ABENDADO  =====' */
            _.Display($"=====  PROGRAMA ABENDADO  =====");

            /*" -440- DISPLAY ' ' */
            _.Display($" ");

            /*" -442- DISPLAY 'ERRO NA ROTINA SI4922B ' */
            _.Display($"ERRO NA ROTINA SI4922B ");

            /*" -443- DISPLAY WABEND1. */
            _.Display(AREA_DE_WORK.WABEND.WABEND1);

            /*" -444- DISPLAY WABEND2. */
            _.Display(AREA_DE_WORK.WABEND.WABEND2);

            /*" -446- DISPLAY WABEND3. */
            _.Display(AREA_DE_WORK.WABEND.WABEND3);

            /*" -449- DISPLAY 'LK-MSG-ERRO... ' LK-MSG-ERRO */
            _.Display($"LK-MSG-ERRO... {LK_PARAMETRO.LK_PARAMETROS_SAIDA.LK_MSG_ERRO}");

            /*" -455- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -455- GOBACK. */

            throw new GoBack();

        }
    }
}