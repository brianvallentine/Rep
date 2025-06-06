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
using Sias.Geral.DB2.GE0502B;

namespace Code
{
    public class GE0502B
    {
        public bool IsCall { get; set; }

        public GE0502B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  PESSOA                             *      */
        /*"      *   PROGRAMA ...............  GE0502B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  FAST COMPUTER                      *      */
        /*"      *   PROGRAMADOR ............  MARCO ANTONIO                      *      */
        /*"      *   DATA CODIFICACAO .......  DEZEMBRO/2007                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO.. EFETUAR O CADASTRAMENTO E CONSULTA DO ENDERECO             */
        /*"      *            NA BASE DE PESSOA                                   *      */
        /*"      *   GE0502B - COBOL / DB2 / CICS                                 *      */
        /*"      *   GE0502B - COBOL / DB2                                               */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   DATA = 13/01/2017   ANALISTA : DIEGO DIAS                           */
        /*"V.01  *   FUNCAO.. RETIRAR DISPLAY                                            */
        /*"      *                                      VERSAO: V.01                     */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77    VIND-NULL01               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL01 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL02               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL02 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL03               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL03 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL04               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL04 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL05               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL05 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL06               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL06 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL07               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL07 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01     AREA-DE-WORK.*/
        public GE0502B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new GE0502B_AREA_DE_WORK();
        public class GE0502B_AREA_DE_WORK : VarBasis
        {
            /*"  05 WFIM-MOVIMENTO                  PIC X(001) VALUE 'N'.*/
            public StringBasis WFIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  05 WTEM-ENDERECO                   PIC X(001) VALUE  SPACES.*/
            public StringBasis WTEM_ENDERECO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05 W-TABELA-LIKE-NOME.*/
            public GE0502B_W_TABELA_LIKE_NOME W_TABELA_LIKE_NOME { get; set; } = new GE0502B_W_TABELA_LIKE_NOME();
            public class GE0502B_W_TABELA_LIKE_NOME : VarBasis
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
            public GE0502B_WABEND WABEND { get; set; } = new GE0502B_WABEND();
            public class GE0502B_WABEND : VarBasis
            {
                /*"    10 WABEND1                       PIC  X(009)  VALUE                                                      'GE0502B '*/
                public StringBasis WABEND1 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"GE0502B ");
                /*"    10 WABEND2.*/
                public GE0502B_WABEND2 WABEND2 { get; set; } = new GE0502B_WABEND2();
                public class GE0502B_WABEND2 : VarBasis
                {
                    /*"      15 FILLER                      PIC  X(025)  VALUE                                     '*** ERRO EXEC SQL NUMERO '*/
                    public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"*** ERRO EXEC SQL NUMERO ");
                    /*"      15 WNR-EXEC-SQL                PIC  X(005)  VALUE SPACES.*/
                    public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                    /*"    10 WABEND3.*/
                }
                public GE0502B_WABEND3 WABEND3 { get; set; } = new GE0502B_WABEND3();
                public class GE0502B_WABEND3 : VarBasis
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
        public GE0502B_W_LINK_MSG_ERRO W_LINK_MSG_ERRO { get; set; } = new GE0502B_W_LINK_MSG_ERRO();
        public class GE0502B_W_LINK_MSG_ERRO : VarBasis
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
        public GE0502B_LINK_PARAMETRO LINK_PARAMETRO { get; set; } = new GE0502B_LINK_PARAMETRO();
        public class GE0502B_LINK_PARAMETRO : VarBasis
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
            /*"  05   LINK-SEQ-ENDERECO             PIC S9(4) USAGE COMP.*/
            public IntBasis LINK_SEQ_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"  05   LINK-DTH-CADASTRAMENTO-END    PIC X(26).*/
            public StringBasis LINK_DTH_CADASTRAMENTO_END { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
            /*"  05   LINK-IND-ENDERECO             PIC X(1).*/
            public StringBasis LINK_IND_ENDERECO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
            /*"  05   LINK-STA-ENDERECO             PIC X(1).*/
            public StringBasis LINK_STA_ENDERECO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
            /*"  05   LINK-NOM-LOGRADOURO           PIC X(72).*/
            public StringBasis LINK_NOM_LOGRADOURO { get; set; } = new StringBasis(new PIC("X", "72", "X(72)."), @"");
            /*"  05   LINK-DES-NUM-IMOVEL           PIC X(10).*/
            public StringBasis LINK_DES_NUM_IMOVEL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"  05   LINK-DES-COMPL-ENDERECO       PIC X(72).*/
            public StringBasis LINK_DES_COMPL_ENDERECO { get; set; } = new StringBasis(new PIC("X", "72", "X(72)."), @"");
            /*"  05   LINK-NOM-BAIRRO               PIC X(72).*/
            public StringBasis LINK_NOM_BAIRRO { get; set; } = new StringBasis(new PIC("X", "72", "X(72)."), @"");
            /*"  05   LINK-NOM-CIDADE               PIC X(72).*/
            public StringBasis LINK_NOM_CIDADE { get; set; } = new StringBasis(new PIC("X", "72", "X(72)."), @"");
            /*"  05   LINK-COD-CEP                  PIC X(8).*/
            public StringBasis LINK_COD_CEP { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
            /*"  05   LINK-COD-UF                   PIC X(2).*/
            public StringBasis LINK_COD_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
            /*"  05   LINK-STA-CORRESPONDER         PIC X(1).*/
            public StringBasis LINK_STA_CORRESPONDER { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
            /*"  05   LINK-STA-PROPAGANDA           PIC X(1).*/
            public StringBasis LINK_STA_PROPAGANDA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
            /*"  05   LINK-PARAMETROS-SAIDA.*/
            public GE0502B_LINK_PARAMETROS_SAIDA LINK_PARAMETROS_SAIDA { get; set; } = new GE0502B_LINK_PARAMETROS_SAIDA();
            public class GE0502B_LINK_PARAMETROS_SAIDA : VarBasis
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


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.OD001 OD001 { get; set; } = new Dclgens.OD001();
        public Dclgens.OD003 OD003 { get; set; } = new Dclgens.OD003();
        public Dclgens.OD007 OD007 { get; set; } = new Dclgens.OD007();
        public Dclgens.UNIDAFED UNIDAFED { get; set; } = new Dclgens.UNIDAFED();
        public GE0502B_V0ENDERECO V0ENDERECO { get; set; } = new GE0502B_V0ENDERECO();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(GE0502B_LINK_PARAMETRO GE0502B_LINK_PARAMETRO_P) //PROCEDURE DIVISION USING 
        /*LINK_PARAMETRO*/
        {
            try
            {
                this.LINK_PARAMETRO = GE0502B_LINK_PARAMETRO_P;

                /*" -152- MOVE '0001' TO WNR-EXEC-SQL */
                _.Move("0001", AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL);

                /*" -152- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -153- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -154- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -160- INITIALIZE LINK-PARAMETROS-SAIDA. */
                _.Initialize(
                    LINK_PARAMETRO.LINK_PARAMETROS_SAIDA
                );

                /*" -162- MOVE '0002' TO WNR-EXEC-SQL */
                _.Move("0002", AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL);

                /*" -169- PERFORM Execute_DB_SELECT_1 */

                Execute_DB_SELECT_1();

                /*" -172- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -174- MOVE 'GE0502B - ERRO NA LEITURA DA SISTEMAS' TO W-LINK-MENSAGEM */
                    _.Move("GE0502B - ERRO NA LEITURA DA SISTEMAS", W_LINK_MSG_ERRO.W_LINK_MENSAGEM);

                    /*" -175- MOVE SQLCODE TO W-LINK-SQLCODE */
                    _.Move(DB.SQLCODE, W_LINK_MSG_ERRO.W_LINK_SQLCODE);

                    /*" -176- MOVE WNR-EXEC-SQL TO W-WNR-EXEC-SQL */
                    _.Move(AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL, W_LINK_MSG_ERRO.W_WNR_EXEC_SQL);

                    /*" -177- MOVE W-LINK-MSG-ERRO TO LINK-MSG-ERRO */
                    _.Move(W_LINK_MSG_ERRO, LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                    /*" -178- MOVE 'SISTEMAS   ' TO LINK-NOME-TABELA */
                    _.Move("SISTEMAS   ", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_NOME_TABELA);

                    /*" -179- DISPLAY 'GE0502B - ERRO ACESSO SISTEMAS ' WNR-EXEC-SQL */
                    _.Display($"GE0502B - ERRO ACESSO SISTEMAS {AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL}");

                    /*" -184- GO TO R9999-00-CANCELA-PROGRAMA. */

                    R9999_00_CANCELA_PROGRAMA(); //GOTO
                    return Result;
                }


                /*" -186- IF (LINK-TIPO-UTILIZACAO NOT EQUAL 1) AND (LINK-TIPO-UTILIZACAO NOT EQUAL 2) */

                if ((LINK_PARAMETRO.LINK_TIPO_UTILIZACAO != 1) && (LINK_PARAMETRO.LINK_TIPO_UTILIZACAO != 2))
                {

                    /*" -189- MOVE 'GE0502B - TIPO DE CHAMADA INVALIDO. 1 - INCLUSAO 2 -CONSULTA' TO LINK-MSG-ERRO */
                    _.Move("GE0502B - TIPO DE CHAMADA INVALIDO. 1 - INCLUSAO 2 -CONSULTA", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                    /*" -191- GO TO R9999-00-CANCELA-PROGRAMA. */

                    R9999_00_CANCELA_PROGRAMA(); //GOTO
                    return Result;
                }


                /*" -192- IF LINK-PROGRAMA-CHAMADOR EQUAL SPACES */

                if (LINK_PARAMETRO.LINK_PROGRAMA_CHAMADOR.IsEmpty())
                {

                    /*" -194- MOVE 'GE0502B - NOME DO PGM CHAMADOR NAO INFORMADO' TO LINK-MSG-ERRO */
                    _.Move("GE0502B - NOME DO PGM CHAMADOR NAO INFORMADO", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                    /*" -196- GO TO R9999-00-CANCELA-PROGRAMA. */

                    R9999_00_CANCELA_PROGRAMA(); //GOTO
                    return Result;
                }


                /*" -197- IF LINK-NOME-USUARIO EQUAL SPACES */

                if (LINK_PARAMETRO.LINK_NOME_USUARIO.IsEmpty())
                {

                    /*" -199- MOVE 'GE0502B - NOME DO USUARIO CHAMADOR NAO INFORMADO' TO LINK-MSG-ERRO */
                    _.Move("GE0502B - NOME DO USUARIO CHAMADOR NAO INFORMADO", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                    /*" -201- GO TO R9999-00-CANCELA-PROGRAMA. */

                    R9999_00_CANCELA_PROGRAMA(); //GOTO
                    return Result;
                }


                /*" -202- IF LINK-NUM-PESSOA EQUAL ZEROS */

                if (LINK_PARAMETRO.LINK_NUM_PESSOA == 00)
                {

                    /*" -204- MOVE 'GE0502B - NUMERO DA PESSOA NAO INFORMADO' TO LINK-MSG-ERRO */
                    _.Move("GE0502B - NUMERO DA PESSOA NAO INFORMADO", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                    /*" -206- GO TO R9999-00-CANCELA-PROGRAMA. */

                    R9999_00_CANCELA_PROGRAMA(); //GOTO
                    return Result;
                }


                /*" -207- IF LINK-TIPO-UTILIZACAO EQUAL 2 */

                if (LINK_PARAMETRO.LINK_TIPO_UTILIZACAO == 2)
                {

                    /*" -208- IF LINK-SEQ-ENDERECO EQUAL ZEROS */

                    if (LINK_PARAMETRO.LINK_SEQ_ENDERECO == 00)
                    {

                        /*" -210- MOVE 'GE0502B - NUM. SEQUENCIA DO ENDERECO NAO INFORMADO' TO LINK-MSG-ERRO */
                        _.Move("GE0502B - NUM. SEQUENCIA DO ENDERECO NAO INFORMADO", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                        /*" -212- GO TO R9999-00-CANCELA-PROGRAMA. */

                        R9999_00_CANCELA_PROGRAMA(); //GOTO
                        return Result;
                    }

                }


                /*" -214- INITIALIZE DCLOD-PESSOA DCLOD-PESSOA-ENDERECO. */
                _.Initialize(
                    OD001.DCLOD_PESSOA
                    , OD007.DCLOD_PESSOA_ENDERECO
                );

                /*" -215- MOVE LINK-NUM-PESSOA TO OD001-NUM-PESSOA OD007-NUM-PESSOA. */
                _.Move(LINK_PARAMETRO.LINK_NUM_PESSOA, OD001.DCLOD_PESSOA.OD001_NUM_PESSOA, OD007.DCLOD_PESSOA_ENDERECO.OD007_NUM_PESSOA);

                /*" -217- MOVE LINK-SEQ-ENDERECO TO OD007-SEQ-ENDERECO . */
                _.Move(LINK_PARAMETRO.LINK_SEQ_ENDERECO, OD007.DCLOD_PESSOA_ENDERECO.OD007_SEQ_ENDERECO);

                /*" -218- IF (LINK-TIPO-UTILIZACAO EQUAL 1) */

                if ((LINK_PARAMETRO.LINK_TIPO_UTILIZACAO == 1))
                {

                    /*" -219- PERFORM R010-CRITICA-INCLUSAO THRU R010-EXIT */

                    R010_CRITICA_INCLUSAO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_EXIT*/


                    /*" -220- PERFORM R300-CONSULTA-ENDERECO THRU R300-EXIT */

                    R300_CONSULTA_ENDERECO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R300_EXIT*/


                    /*" -221- IF WTEM-ENDERECO NOT EQUAL 'S' */

                    if (AREA_DE_WORK.WTEM_ENDERECO != "S")
                    {

                        /*" -223- PERFORM R100-INSERT-ENDERECO THRU R100-EXIT. */

                        R100_INSERT_ENDERECO(true);
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/

                    }

                }


                /*" -224- IF (LINK-TIPO-UTILIZACAO EQUAL 2) */

                if ((LINK_PARAMETRO.LINK_TIPO_UTILIZACAO == 2))
                {

                    /*" -225- PERFORM R020-CRITICA-CONSUTA THRU R020-EXIT */

                    R020_CRITICA_CONSUTA(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R020_EXIT*/


                    /*" -227- PERFORM R200-CONSULTA-ENDERECO THRU R200-EXIT. */

                    R200_CONSULTA_ENDERECO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R200_EXIT*/

                }


                /*" -230- MOVE ZEROS TO RETURN-CODE. */
                _.Move(0, RETURN_CODE);

                /*" -230- GOBACK. */

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
            /*" -169- EXEC SQL SELECT CURRENT DATE, CURRENT TIMESTAMP INTO :HOST-CURRENT-DATE, :HOST-CURRENT-TIMESTAMP FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'EM' END-EXEC. */

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
            /*" -238- IF (LINK-IND-ENDERECO NOT EQUAL 'C' ) AND (LINK-IND-ENDERECO NOT EQUAL 'T' ) AND (LINK-IND-ENDERECO NOT EQUAL 'R' ) */

            if ((LINK_PARAMETRO.LINK_IND_ENDERECO != "C") && (LINK_PARAMETRO.LINK_IND_ENDERECO != "T") && (LINK_PARAMETRO.LINK_IND_ENDERECO != "R"))
            {

                /*" -240- MOVE 'GE0502B - INDICADOR DE ENDERECO INVALIDO' TO LINK-MSG-ERRO */
                _.Move("GE0502B - INDICADOR DE ENDERECO INVALIDO", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                /*" -242- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA(); //GOTO
                return;
            }


            /*" -244- IF (LINK-STA-ENDERECO NOT EQUAL 'A' ) AND (LINK-STA-ENDERECO NOT EQUAL 'I' ) */

            if ((LINK_PARAMETRO.LINK_STA_ENDERECO != "A") && (LINK_PARAMETRO.LINK_STA_ENDERECO != "I"))
            {

                /*" -246- MOVE 'GE0502B - INDICADOR STATUS DO ENDERECO INVALIDO' TO LINK-MSG-ERRO */
                _.Move("GE0502B - INDICADOR STATUS DO ENDERECO INVALIDO", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                /*" -248- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA(); //GOTO
                return;
            }


            /*" -250- IF (LINK-STA-CORRESPONDER NOT EQUAL 'S' ) AND (LINK-STA-CORRESPONDER NOT EQUAL 'N' ) */

            if ((LINK_PARAMETRO.LINK_STA_CORRESPONDER != "S") && (LINK_PARAMETRO.LINK_STA_CORRESPONDER != "N"))
            {

                /*" -252- MOVE 'GE0502B - INDICADOR CORRESPONDENCIA INVALIDO' TO LINK-MSG-ERRO */
                _.Move("GE0502B - INDICADOR CORRESPONDENCIA INVALIDO", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                /*" -254- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA(); //GOTO
                return;
            }


            /*" -256- IF (LINK-STA-PROPAGANDA NOT EQUAL 'S' ) AND (LINK-STA-PROPAGANDA NOT EQUAL 'N' ) */

            if ((LINK_PARAMETRO.LINK_STA_PROPAGANDA != "S") && (LINK_PARAMETRO.LINK_STA_PROPAGANDA != "N"))
            {

                /*" -258- MOVE 'GE0502B - INDICADOR PROPAGANDA INVALIDO' TO LINK-MSG-ERRO */
                _.Move("GE0502B - INDICADOR PROPAGANDA INVALIDO", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                /*" -258- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA(); //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_EXIT*/

        [StopWatch]
        /*" R020-CRITICA-CONSUTA */
        private void R020_CRITICA_CONSUTA(bool isPerform = false)
        {
            /*" -265- IF LINK-NUM-PESSOA EQUAL 0 */

            if (LINK_PARAMETRO.LINK_NUM_PESSOA == 0)
            {

                /*" -267- MOVE 'GE0502B - INFORME O NUMERO DA PESSOA PARA CONSULTA' TO LINK-MSG-ERRO */
                _.Move("GE0502B - INFORME O NUMERO DA PESSOA PARA CONSULTA", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                /*" -267- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA(); //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R020_EXIT*/

        [StopWatch]
        /*" R200-CONSULTA-ENDERECO */
        private void R200_CONSULTA_ENDERECO(bool isPerform = false)
        {
            /*" -275- MOVE '0003' TO WNR-EXEC-SQL */
            _.Move("0003", AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL);

            /*" -318- PERFORM R200_CONSULTA_ENDERECO_DB_SELECT_1 */

            R200_CONSULTA_ENDERECO_DB_SELECT_1();

            /*" -321- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -324- MOVE 'GE0502B - PESSOA ENDERECO NAO ENCONTRADA P/ ID INFORMADO' TO LINK-MSG-ERRO */
                _.Move("GE0502B - PESSOA ENDERECO NAO ENCONTRADA P/ ID INFORMADO", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                /*" -326- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA(); //GOTO
                return;
            }


            /*" -327- IF (SQLCODE NOT EQUAL ZEROS) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -329- MOVE 'GE0502B - ERRO NA LEITURA DA PJ P/ ID INFORMADO' TO W-LINK-MENSAGEM */
                _.Move("GE0502B - ERRO NA LEITURA DA PJ P/ ID INFORMADO", W_LINK_MSG_ERRO.W_LINK_MENSAGEM);

                /*" -330- MOVE SQLCODE TO W-LINK-SQLCODE */
                _.Move(DB.SQLCODE, W_LINK_MSG_ERRO.W_LINK_SQLCODE);

                /*" -331- MOVE WNR-EXEC-SQL TO W-WNR-EXEC-SQL */
                _.Move(AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL, W_LINK_MSG_ERRO.W_WNR_EXEC_SQL);

                /*" -332- MOVE W-LINK-MSG-ERRO TO LINK-MSG-ERRO */
                _.Move(W_LINK_MSG_ERRO, LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                /*" -333- MOVE 'PESSOA/ENDER' TO LINK-NOME-TABELA */
                _.Move("PESSOA/ENDER", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_NOME_TABELA);

                /*" -335- DISPLAY 'GE0502B - ERRO ACESSO JOIN ODS_PESSOA X ODS_PESSO 'A_ENDERECO SQLCODE ' W-LINK-SQLCODE */

                $"GE0502B - ERRO ACESSO JOIN ODS_PESSOA X ODS_PESSO A_ENDERECO{DB.SQLCODE}{W_LINK_MSG_ERRO.W_LINK_SQLCODE}"
                .Display();

                /*" -337- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA(); //GOTO
                return;
            }


            /*" -338- IF VIND-NULL01 LESS ZEROS */

            if (VIND_NULL01 < 00)
            {

                /*" -340- MOVE SPACES TO OD007-NOM-LOGRADOURO. */
                _.Move("", OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_LOGRADOURO);
            }


            /*" -341- IF VIND-NULL02 LESS ZEROS */

            if (VIND_NULL02 < 00)
            {

                /*" -343- MOVE SPACES TO OD007-DES-NUM-IMOVEL. */
                _.Move("", OD007.DCLOD_PESSOA_ENDERECO.OD007_DES_NUM_IMOVEL);
            }


            /*" -344- IF VIND-NULL03 LESS ZEROS */

            if (VIND_NULL03 < 00)
            {

                /*" -346- MOVE SPACES TO OD007-DES-COMPL-ENDERECO. */
                _.Move("", OD007.DCLOD_PESSOA_ENDERECO.OD007_DES_COMPL_ENDERECO);
            }


            /*" -347- IF VIND-NULL04 LESS ZEROS */

            if (VIND_NULL04 < 00)
            {

                /*" -349- MOVE SPACES TO OD007-NOM-BAIRRO. */
                _.Move("", OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_BAIRRO);
            }


            /*" -350- IF VIND-NULL05 LESS ZEROS */

            if (VIND_NULL05 < 00)
            {

                /*" -352- MOVE SPACES TO OD007-NOM-CIDADE. */
                _.Move("", OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_CIDADE);
            }


            /*" -353- IF VIND-NULL06 LESS ZEROS */

            if (VIND_NULL06 < 00)
            {

                /*" -355- MOVE SPACES TO OD007-COD-CEP. */
                _.Move("", OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_CEP);
            }


            /*" -356- IF VIND-NULL07 LESS ZEROS */

            if (VIND_NULL07 < 00)
            {

                /*" -359- MOVE SPACES TO OD007-COD-UF. */
                _.Move("", OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_UF);
            }


            /*" -360- MOVE OD001-NUM-PESSOA TO LINK-NUM-PESSOA */
            _.Move(OD001.DCLOD_PESSOA.OD001_NUM_PESSOA, LINK_PARAMETRO.LINK_NUM_PESSOA);

            /*" -361- MOVE OD001-DTH-CADASTRAMENTO TO LINK-DTH-CADASTRAMENTO */
            _.Move(OD001.DCLOD_PESSOA.OD001_DTH_CADASTRAMENTO, LINK_PARAMETRO.LINK_DTH_CADASTRAMENTO);

            /*" -362- MOVE OD001-NUM-DV-PESSOA TO LINK-NUM-DV-PESSOA */
            _.Move(OD001.DCLOD_PESSOA.OD001_NUM_DV_PESSOA, LINK_PARAMETRO.LINK_NUM_DV_PESSOA);

            /*" -363- MOVE OD001-IND-PESSOA TO LINK-IND-PESSOA */
            _.Move(OD001.DCLOD_PESSOA.OD001_IND_PESSOA, LINK_PARAMETRO.LINK_IND_PESSOA);

            /*" -364- MOVE OD001-STA-INF-INTEGRA TO LINK-STA-INF-INTEGRA */
            _.Move(OD001.DCLOD_PESSOA.OD001_STA_INF_INTEGRA, LINK_PARAMETRO.LINK_STA_INF_INTEGRA);

            /*" -365- MOVE OD007-SEQ-ENDERECO TO LINK-SEQ-ENDERECO */
            _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_SEQ_ENDERECO, LINK_PARAMETRO.LINK_SEQ_ENDERECO);

            /*" -366- MOVE OD007-DTH-CADASTRAMENTO TO LINK-DTH-CADASTRAMENTO-END */
            _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_DTH_CADASTRAMENTO, LINK_PARAMETRO.LINK_DTH_CADASTRAMENTO_END);

            /*" -367- MOVE OD007-IND-ENDERECO TO LINK-IND-ENDERECO */
            _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_IND_ENDERECO, LINK_PARAMETRO.LINK_IND_ENDERECO);

            /*" -368- MOVE OD007-STA-ENDERECO TO LINK-STA-ENDERECO */
            _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_STA_ENDERECO, LINK_PARAMETRO.LINK_STA_ENDERECO);

            /*" -369- MOVE OD007-NOM-LOGRADOURO TO LINK-NOM-LOGRADOURO */
            _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_LOGRADOURO, LINK_PARAMETRO.LINK_NOM_LOGRADOURO);

            /*" -370- MOVE OD007-DES-NUM-IMOVEL TO LINK-DES-NUM-IMOVEL */
            _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_DES_NUM_IMOVEL, LINK_PARAMETRO.LINK_DES_NUM_IMOVEL);

            /*" -371- MOVE OD007-DES-COMPL-ENDERECO TO LINK-DES-COMPL-ENDERECO */
            _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_DES_COMPL_ENDERECO, LINK_PARAMETRO.LINK_DES_COMPL_ENDERECO);

            /*" -372- MOVE OD007-NOM-BAIRRO TO LINK-NOM-BAIRRO */
            _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_BAIRRO, LINK_PARAMETRO.LINK_NOM_BAIRRO);

            /*" -373- MOVE OD007-NOM-CIDADE TO LINK-NOM-CIDADE */
            _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_CIDADE, LINK_PARAMETRO.LINK_NOM_CIDADE);

            /*" -374- MOVE OD007-COD-CEP TO LINK-COD-CEP */
            _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_CEP, LINK_PARAMETRO.LINK_COD_CEP);

            /*" -375- MOVE OD007-COD-UF TO LINK-COD-UF */
            _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_UF, LINK_PARAMETRO.LINK_COD_UF);

            /*" -376- MOVE OD007-STA-CORRESPONDER TO LINK-STA-CORRESPONDER */
            _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_STA_CORRESPONDER, LINK_PARAMETRO.LINK_STA_CORRESPONDER);

            /*" -376- MOVE OD007-STA-PROPAGANDA TO LINK-STA-PROPAGANDA. */
            _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_STA_PROPAGANDA, LINK_PARAMETRO.LINK_STA_PROPAGANDA);

        }

        [StopWatch]
        /*" R200-CONSULTA-ENDERECO-DB-SELECT-1 */
        public void R200_CONSULTA_ENDERECO_DB_SELECT_1()
        {
            /*" -318- EXEC SQL SELECT A.NUM_PESSOA , A.DTH_CADASTRAMENTO , A.NUM_DV_PESSOA , A.IND_PESSOA , A.STA_INF_INTEGRA , B.SEQ_ENDERECO , B.DTH_CADASTRAMENTO , B.IND_ENDERECO , B.STA_ENDERECO , B.NOM_LOGRADOURO , B.DES_NUM_IMOVEL , B.DES_COMPL_ENDERECO , B.NOM_BAIRRO , B.NOM_CIDADE , B.COD_CEP , B.COD_UF , B.STA_CORRESPONDER , B.STA_PROPAGANDA INTO :OD001-NUM-PESSOA , :OD001-DTH-CADASTRAMENTO , :OD001-NUM-DV-PESSOA , :OD001-IND-PESSOA , :OD001-STA-INF-INTEGRA , :OD007-SEQ-ENDERECO , :OD007-DTH-CADASTRAMENTO , :OD007-IND-ENDERECO , :OD007-STA-ENDERECO , :OD007-NOM-LOGRADOURO:VIND-NULL01 , :OD007-DES-NUM-IMOVEL:VIND-NULL02 , :OD007-DES-COMPL-ENDERECO:VIND-NULL03 , :OD007-NOM-BAIRRO:VIND-NULL04 , :OD007-NOM-CIDADE:VIND-NULL05 , :OD007-COD-CEP:VIND-NULL06 , :OD007-COD-UF:VIND-NULL07 , :OD007-STA-CORRESPONDER , :OD007-STA-PROPAGANDA FROM ODS.OD_PESSOA A , ODS.OD_PESSOA_ENDERECO B WHERE A.NUM_PESSOA = :OD001-NUM-PESSOA AND B.NUM_PESSOA = A.NUM_PESSOA AND B.SEQ_ENDERECO = :OD007-SEQ-ENDERECO WITH UR END-EXEC. */

            var r200_CONSULTA_ENDERECO_DB_SELECT_1_Query1 = new R200_CONSULTA_ENDERECO_DB_SELECT_1_Query1()
            {
                OD007_SEQ_ENDERECO = OD007.DCLOD_PESSOA_ENDERECO.OD007_SEQ_ENDERECO.ToString(),
                OD001_NUM_PESSOA = OD001.DCLOD_PESSOA.OD001_NUM_PESSOA.ToString(),
            };

            var executed_1 = R200_CONSULTA_ENDERECO_DB_SELECT_1_Query1.Execute(r200_CONSULTA_ENDERECO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OD001_NUM_PESSOA, OD001.DCLOD_PESSOA.OD001_NUM_PESSOA);
                _.Move(executed_1.OD001_DTH_CADASTRAMENTO, OD001.DCLOD_PESSOA.OD001_DTH_CADASTRAMENTO);
                _.Move(executed_1.OD001_NUM_DV_PESSOA, OD001.DCLOD_PESSOA.OD001_NUM_DV_PESSOA);
                _.Move(executed_1.OD001_IND_PESSOA, OD001.DCLOD_PESSOA.OD001_IND_PESSOA);
                _.Move(executed_1.OD001_STA_INF_INTEGRA, OD001.DCLOD_PESSOA.OD001_STA_INF_INTEGRA);
                _.Move(executed_1.OD007_SEQ_ENDERECO, OD007.DCLOD_PESSOA_ENDERECO.OD007_SEQ_ENDERECO);
                _.Move(executed_1.OD007_DTH_CADASTRAMENTO, OD007.DCLOD_PESSOA_ENDERECO.OD007_DTH_CADASTRAMENTO);
                _.Move(executed_1.OD007_IND_ENDERECO, OD007.DCLOD_PESSOA_ENDERECO.OD007_IND_ENDERECO);
                _.Move(executed_1.OD007_STA_ENDERECO, OD007.DCLOD_PESSOA_ENDERECO.OD007_STA_ENDERECO);
                _.Move(executed_1.OD007_NOM_LOGRADOURO, OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_LOGRADOURO);
                _.Move(executed_1.VIND_NULL01, VIND_NULL01);
                _.Move(executed_1.OD007_DES_NUM_IMOVEL, OD007.DCLOD_PESSOA_ENDERECO.OD007_DES_NUM_IMOVEL);
                _.Move(executed_1.VIND_NULL02, VIND_NULL02);
                _.Move(executed_1.OD007_DES_COMPL_ENDERECO, OD007.DCLOD_PESSOA_ENDERECO.OD007_DES_COMPL_ENDERECO);
                _.Move(executed_1.VIND_NULL03, VIND_NULL03);
                _.Move(executed_1.OD007_NOM_BAIRRO, OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_BAIRRO);
                _.Move(executed_1.VIND_NULL04, VIND_NULL04);
                _.Move(executed_1.OD007_NOM_CIDADE, OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_CIDADE);
                _.Move(executed_1.VIND_NULL05, VIND_NULL05);
                _.Move(executed_1.OD007_COD_CEP, OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_CEP);
                _.Move(executed_1.VIND_NULL06, VIND_NULL06);
                _.Move(executed_1.OD007_COD_UF, OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_UF);
                _.Move(executed_1.VIND_NULL07, VIND_NULL07);
                _.Move(executed_1.OD007_STA_CORRESPONDER, OD007.DCLOD_PESSOA_ENDERECO.OD007_STA_CORRESPONDER);
                _.Move(executed_1.OD007_STA_PROPAGANDA, OD007.DCLOD_PESSOA_ENDERECO.OD007_STA_PROPAGANDA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R200_EXIT*/

        [StopWatch]
        /*" R100-INSERT-ENDERECO */
        private void R100_INSERT_ENDERECO(bool isPerform = false)
        {
            /*" -386- MOVE '0004' TO WNR-EXEC-SQL */
            _.Move("0004", AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL);

            /*" -391- PERFORM R100_INSERT_ENDERECO_DB_SELECT_1 */

            R100_INSERT_ENDERECO_DB_SELECT_1();

            /*" -394- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -396- MOVE 'GE0502B - MAX PARA PEGAR NUMERO SEQUENCIA ENDERECO' TO W-LINK-MENSAGEM */
                _.Move("GE0502B - MAX PARA PEGAR NUMERO SEQUENCIA ENDERECO", W_LINK_MSG_ERRO.W_LINK_MENSAGEM);

                /*" -397- MOVE SQLCODE TO W-LINK-SQLCODE */
                _.Move(DB.SQLCODE, W_LINK_MSG_ERRO.W_LINK_SQLCODE);

                /*" -398- MOVE WNR-EXEC-SQL TO W-WNR-EXEC-SQL */
                _.Move(AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL, W_LINK_MSG_ERRO.W_WNR_EXEC_SQL);

                /*" -399- MOVE W-LINK-MSG-ERRO TO LINK-MSG-ERRO */
                _.Move(W_LINK_MSG_ERRO, LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                /*" -400- MOVE 'OD_PESSOA  ' TO LINK-NOME-TABELA */
                _.Move("OD_PESSOA  ", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_NOME_TABELA);

                /*" -401- DISPLAY 'GE0502B - ERRO MAX DA OD_PESSOA' */
                _.Display($"GE0502B - ERRO MAX DA OD_PESSOA");

                /*" -403- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA(); //GOTO
                return;
            }


            /*" -408- DISPLAY ' INSERT ENDERECO >' ' IND-END = =' LINK-IND-ENDERECO ' SEQ-END = =' OD007-SEQ-ENDERECO */

            $" INSERT ENDERECO > IND-END = ={LINK_PARAMETRO.LINK_IND_ENDERECO} SEQ-END = ={OD007.DCLOD_PESSOA_ENDERECO.OD007_SEQ_ENDERECO}"
            .Display();

            /*" -410- MOVE OD007-SEQ-ENDERECO TO LINK-SEQ-ENDERECO */
            _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_SEQ_ENDERECO, LINK_PARAMETRO.LINK_SEQ_ENDERECO);

            /*" -411- MOVE HOST-CURRENT-TIMESTAMP TO OD007-DTH-CADASTRAMENTO */
            _.Move(AREA_DE_WORK.HOST_CURRENT_TIMESTAMP, OD007.DCLOD_PESSOA_ENDERECO.OD007_DTH_CADASTRAMENTO);

            /*" -412- MOVE LINK-IND-ENDERECO TO OD007-IND-ENDERECO */
            _.Move(LINK_PARAMETRO.LINK_IND_ENDERECO, OD007.DCLOD_PESSOA_ENDERECO.OD007_IND_ENDERECO);

            /*" -413- MOVE LINK-STA-ENDERECO TO OD007-STA-ENDERECO */
            _.Move(LINK_PARAMETRO.LINK_STA_ENDERECO, OD007.DCLOD_PESSOA_ENDERECO.OD007_STA_ENDERECO);

            /*" -414- MOVE LINK-NOM-LOGRADOURO TO OD007-NOM-LOGRADOURO */
            _.Move(LINK_PARAMETRO.LINK_NOM_LOGRADOURO, OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_LOGRADOURO);

            /*" -415- MOVE LINK-DES-NUM-IMOVEL TO OD007-DES-NUM-IMOVEL */
            _.Move(LINK_PARAMETRO.LINK_DES_NUM_IMOVEL, OD007.DCLOD_PESSOA_ENDERECO.OD007_DES_NUM_IMOVEL);

            /*" -416- MOVE LINK-DES-COMPL-ENDERECO TO OD007-DES-COMPL-ENDERECO */
            _.Move(LINK_PARAMETRO.LINK_DES_COMPL_ENDERECO, OD007.DCLOD_PESSOA_ENDERECO.OD007_DES_COMPL_ENDERECO);

            /*" -417- MOVE LINK-NOM-BAIRRO TO OD007-NOM-BAIRRO */
            _.Move(LINK_PARAMETRO.LINK_NOM_BAIRRO, OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_BAIRRO);

            /*" -418- MOVE LINK-NOM-CIDADE TO OD007-NOM-CIDADE */
            _.Move(LINK_PARAMETRO.LINK_NOM_CIDADE, OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_CIDADE);

            /*" -419- MOVE LINK-COD-CEP TO OD007-COD-CEP */
            _.Move(LINK_PARAMETRO.LINK_COD_CEP, OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_CEP);

            /*" -420- MOVE LINK-COD-UF TO OD007-COD-UF */
            _.Move(LINK_PARAMETRO.LINK_COD_UF, OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_UF);

            /*" -421- MOVE LINK-STA-CORRESPONDER TO OD007-STA-CORRESPONDER */
            _.Move(LINK_PARAMETRO.LINK_STA_CORRESPONDER, OD007.DCLOD_PESSOA_ENDERECO.OD007_STA_CORRESPONDER);

            /*" -427- MOVE LINK-STA-PROPAGANDA TO OD007-STA-PROPAGANDA. */
            _.Move(LINK_PARAMETRO.LINK_STA_PROPAGANDA, OD007.DCLOD_PESSOA_ENDERECO.OD007_STA_PROPAGANDA);

            /*" -428- MOVE ZEROS TO VIND-NULL01. */
            _.Move(0, VIND_NULL01);

            /*" -429- MOVE ZEROS TO VIND-NULL02. */
            _.Move(0, VIND_NULL02);

            /*" -430- MOVE ZEROS TO VIND-NULL03. */
            _.Move(0, VIND_NULL03);

            /*" -431- MOVE ZEROS TO VIND-NULL04. */
            _.Move(0, VIND_NULL04);

            /*" -432- MOVE ZEROS TO VIND-NULL05. */
            _.Move(0, VIND_NULL05);

            /*" -433- MOVE ZEROS TO VIND-NULL06. */
            _.Move(0, VIND_NULL06);

            /*" -436- MOVE ZEROS TO VIND-NULL07. */
            _.Move(0, VIND_NULL07);

            /*" -438- MOVE '0005' TO WNR-EXEC-SQL */
            _.Move("0005", AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL);

            /*" -467- PERFORM R100_INSERT_ENDERECO_DB_INSERT_1 */

            R100_INSERT_ENDERECO_DB_INSERT_1();

            /*" -470- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -472- MOVE 'GE0502B - ERRO INSERT OD_PESSOA_ENDERECO' TO W-LINK-MENSAGEM */
                _.Move("GE0502B - ERRO INSERT OD_PESSOA_ENDERECO", W_LINK_MSG_ERRO.W_LINK_MENSAGEM);

                /*" -473- MOVE SQLCODE TO W-LINK-SQLCODE */
                _.Move(DB.SQLCODE, W_LINK_MSG_ERRO.W_LINK_SQLCODE);

                /*" -474- MOVE WNR-EXEC-SQL TO W-WNR-EXEC-SQL */
                _.Move(AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL, W_LINK_MSG_ERRO.W_WNR_EXEC_SQL);

                /*" -475- MOVE W-LINK-MSG-ERRO TO LINK-MSG-ERRO */
                _.Move(W_LINK_MSG_ERRO, LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                /*" -476- MOVE 'OD_PESSOA_FISICA' TO LINK-NOME-TABELA */
                _.Move("OD_PESSOA_FISICA", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_NOME_TABELA);

                /*" -478- DISPLAY 'GE0502B - ERRO INSERT OD_PESSOA_JURIDIC SQLCODE ' W-LINK-SQLCODE */
                _.Display($"GE0502B - ERRO INSERT OD_PESSOA_JURIDIC SQLCODE {W_LINK_MSG_ERRO.W_LINK_SQLCODE}");

                /*" -478- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R100-INSERT-ENDERECO-DB-SELECT-1 */
        public void R100_INSERT_ENDERECO_DB_SELECT_1()
        {
            /*" -391- EXEC SQL SELECT VALUE(MAX(SEQ_ENDERECO),0) + 1 INTO :OD007-SEQ-ENDERECO FROM ODS.OD_PESSOA_ENDERECO WHERE NUM_PESSOA = :OD007-NUM-PESSOA END-EXEC. */

            var r100_INSERT_ENDERECO_DB_SELECT_1_Query1 = new R100_INSERT_ENDERECO_DB_SELECT_1_Query1()
            {
                OD007_NUM_PESSOA = OD007.DCLOD_PESSOA_ENDERECO.OD007_NUM_PESSOA.ToString(),
            };

            var executed_1 = R100_INSERT_ENDERECO_DB_SELECT_1_Query1.Execute(r100_INSERT_ENDERECO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OD007_SEQ_ENDERECO, OD007.DCLOD_PESSOA_ENDERECO.OD007_SEQ_ENDERECO);
            }


        }

        [StopWatch]
        /*" R100-INSERT-ENDERECO-DB-INSERT-1 */
        public void R100_INSERT_ENDERECO_DB_INSERT_1()
        {
            /*" -467- EXEC SQL INSERT INTO ODS.OD_PESSOA_ENDERECO ( NUM_PESSOA , SEQ_ENDERECO , DTH_CADASTRAMENTO , IND_ENDERECO , STA_ENDERECO , NOM_LOGRADOURO , DES_NUM_IMOVEL , DES_COMPL_ENDERECO, NOM_BAIRRO , NOM_CIDADE , COD_CEP , COD_UF , STA_CORRESPONDER , STA_PROPAGANDA ) VALUES (:OD007-NUM-PESSOA , :OD007-SEQ-ENDERECO , :OD007-DTH-CADASTRAMENTO, :OD007-IND-ENDERECO , :OD007-STA-ENDERECO , :OD007-NOM-LOGRADOURO:VIND-NULL01 , :OD007-DES-NUM-IMOVEL:VIND-NULL02 , :OD007-DES-COMPL-ENDERECO:VIND-NULL03 , :OD007-NOM-BAIRRO:VIND-NULL04 , :OD007-NOM-CIDADE:VIND-NULL05 , :OD007-COD-CEP:VIND-NULL06 , :OD007-COD-UF:VIND-NULL07 , :OD007-STA-CORRESPONDER , :OD007-STA-PROPAGANDA) END-EXEC. */

            var r100_INSERT_ENDERECO_DB_INSERT_1_Insert1 = new R100_INSERT_ENDERECO_DB_INSERT_1_Insert1()
            {
                OD007_NUM_PESSOA = OD007.DCLOD_PESSOA_ENDERECO.OD007_NUM_PESSOA.ToString(),
                OD007_SEQ_ENDERECO = OD007.DCLOD_PESSOA_ENDERECO.OD007_SEQ_ENDERECO.ToString(),
                OD007_DTH_CADASTRAMENTO = OD007.DCLOD_PESSOA_ENDERECO.OD007_DTH_CADASTRAMENTO.ToString(),
                OD007_IND_ENDERECO = OD007.DCLOD_PESSOA_ENDERECO.OD007_IND_ENDERECO.ToString(),
                OD007_STA_ENDERECO = OD007.DCLOD_PESSOA_ENDERECO.OD007_STA_ENDERECO.ToString(),
                OD007_NOM_LOGRADOURO = OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_LOGRADOURO.ToString(),
                VIND_NULL01 = VIND_NULL01.ToString(),
                OD007_DES_NUM_IMOVEL = OD007.DCLOD_PESSOA_ENDERECO.OD007_DES_NUM_IMOVEL.ToString(),
                VIND_NULL02 = VIND_NULL02.ToString(),
                OD007_DES_COMPL_ENDERECO = OD007.DCLOD_PESSOA_ENDERECO.OD007_DES_COMPL_ENDERECO.ToString(),
                VIND_NULL03 = VIND_NULL03.ToString(),
                OD007_NOM_BAIRRO = OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_BAIRRO.ToString(),
                VIND_NULL04 = VIND_NULL04.ToString(),
                OD007_NOM_CIDADE = OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_CIDADE.ToString(),
                VIND_NULL05 = VIND_NULL05.ToString(),
                OD007_COD_CEP = OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_CEP.ToString(),
                VIND_NULL06 = VIND_NULL06.ToString(),
                OD007_COD_UF = OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_UF.ToString(),
                VIND_NULL07 = VIND_NULL07.ToString(),
                OD007_STA_CORRESPONDER = OD007.DCLOD_PESSOA_ENDERECO.OD007_STA_CORRESPONDER.ToString(),
                OD007_STA_PROPAGANDA = OD007.DCLOD_PESSOA_ENDERECO.OD007_STA_PROPAGANDA.ToString(),
            };

            R100_INSERT_ENDERECO_DB_INSERT_1_Insert1.Execute(r100_INSERT_ENDERECO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/

        [StopWatch]
        /*" R300-CONSULTA-ENDERECO */
        private void R300_CONSULTA_ENDERECO(bool isPerform = false)
        {
            /*" -486- MOVE '0006' TO WNR-EXEC-SQL. */
            _.Move("0006", AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL);

            /*" -488- MOVE SPACES TO WFIM-MOVIMENTO. */
            _.Move("", AREA_DE_WORK.WFIM_MOVIMENTO);

            /*" -490- PERFORM R310-00-DECLARE-ENDERECO THRU R310-EXIT. */

            R310_00_DECLARE_ENDERECO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R310_EXIT*/


            /*" -491- PERFORM R320-00-FETCH-ENDERECO THRU R320-EXIT UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_MOVIMENTO.IsEmpty()))
            {

                R320_00_FETCH_ENDERECO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R320_EXIT*/

            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R300_EXIT*/

        [StopWatch]
        /*" R310-00-DECLARE-ENDERECO */
        private void R310_00_DECLARE_ENDERECO(bool isPerform = false)
        {
            /*" -527- PERFORM R310_00_DECLARE_ENDERECO_DB_DECLARE_1 */

            R310_00_DECLARE_ENDERECO_DB_DECLARE_1();

            /*" -529- PERFORM R310_00_DECLARE_ENDERECO_DB_OPEN_1 */

            R310_00_DECLARE_ENDERECO_DB_OPEN_1();

            /*" -532- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -533- MOVE 'N' TO WTEM-ENDERECO */
                _.Move("N", AREA_DE_WORK.WTEM_ENDERECO);

                /*" -533- MOVE 'S' TO WFIM-MOVIMENTO. */
                _.Move("S", AREA_DE_WORK.WFIM_MOVIMENTO);
            }


        }

        [StopWatch]
        /*" R310-00-DECLARE-ENDERECO-DB-DECLARE-1 */
        public void R310_00_DECLARE_ENDERECO_DB_DECLARE_1()
        {
            /*" -527- EXEC SQL DECLARE V0ENDERECO CURSOR WITH HOLD FOR SELECT A.NUM_PESSOA , A.DTH_CADASTRAMENTO , A.NUM_DV_PESSOA , A.IND_PESSOA , A.STA_INF_INTEGRA , B.SEQ_ENDERECO , B.DTH_CADASTRAMENTO , B.IND_ENDERECO , B.STA_ENDERECO , B.NOM_LOGRADOURO , B.DES_NUM_IMOVEL , B.DES_COMPL_ENDERECO , B.NOM_BAIRRO , B.NOM_CIDADE , B.COD_CEP , B.COD_UF , B.STA_CORRESPONDER , B.STA_PROPAGANDA FROM ODS.OD_PESSOA A , ODS.OD_PESSOA_ENDERECO B WHERE A.NUM_PESSOA = :OD001-NUM-PESSOA AND A.NUM_PESSOA = B.NUM_PESSOA END-EXEC. */
            V0ENDERECO = new GE0502B_V0ENDERECO(true);
            string GetQuery_V0ENDERECO()
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
							B.SEQ_ENDERECO
							, 
							B.DTH_CADASTRAMENTO
							, 
							B.IND_ENDERECO
							, 
							B.STA_ENDERECO
							, 
							B.NOM_LOGRADOURO
							, 
							B.DES_NUM_IMOVEL
							, 
							B.DES_COMPL_ENDERECO
							, 
							B.NOM_BAIRRO
							, 
							B.NOM_CIDADE
							, 
							B.COD_CEP
							, 
							B.COD_UF
							, 
							B.STA_CORRESPONDER
							, 
							B.STA_PROPAGANDA 
							FROM ODS.OD_PESSOA A
							, 
							ODS.OD_PESSOA_ENDERECO B 
							WHERE A.NUM_PESSOA = '{OD001.DCLOD_PESSOA.OD001_NUM_PESSOA}' 
							AND A.NUM_PESSOA = B.NUM_PESSOA";

                return query;
            }
            V0ENDERECO.GetQueryEvent += GetQuery_V0ENDERECO;

        }

        [StopWatch]
        /*" R310-00-DECLARE-ENDERECO-DB-OPEN-1 */
        public void R310_00_DECLARE_ENDERECO_DB_OPEN_1()
        {
            /*" -529- EXEC SQL OPEN V0ENDERECO END-EXEC. */

            V0ENDERECO.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R310_EXIT*/

        [StopWatch]
        /*" R320-00-FETCH-ENDERECO */
        private void R320_00_FETCH_ENDERECO(bool isPerform = false)
        {
            /*" -559- PERFORM R320_00_FETCH_ENDERECO_DB_FETCH_1 */

            R320_00_FETCH_ENDERECO_DB_FETCH_1();

            /*" -562- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -562- PERFORM R320_00_FETCH_ENDERECO_DB_CLOSE_1 */

                R320_00_FETCH_ENDERECO_DB_CLOSE_1();

                /*" -564- MOVE 'S' TO WFIM-MOVIMENTO */
                _.Move("S", AREA_DE_WORK.WFIM_MOVIMENTO);

                /*" -565- MOVE 'N' TO WTEM-ENDERECO */
                _.Move("N", AREA_DE_WORK.WTEM_ENDERECO);

                /*" -567- GO TO R320-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R320_EXIT*/ //GOTO
                return;
            }


            /*" -568- IF VIND-NULL01 LESS ZEROS */

            if (VIND_NULL01 < 00)
            {

                /*" -570- MOVE SPACES TO OD007-NOM-LOGRADOURO. */
                _.Move("", OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_LOGRADOURO);
            }


            /*" -571- IF VIND-NULL02 LESS ZEROS */

            if (VIND_NULL02 < 00)
            {

                /*" -573- MOVE SPACES TO OD007-DES-NUM-IMOVEL. */
                _.Move("", OD007.DCLOD_PESSOA_ENDERECO.OD007_DES_NUM_IMOVEL);
            }


            /*" -574- IF VIND-NULL03 LESS ZEROS */

            if (VIND_NULL03 < 00)
            {

                /*" -576- MOVE SPACES TO OD007-DES-COMPL-ENDERECO. */
                _.Move("", OD007.DCLOD_PESSOA_ENDERECO.OD007_DES_COMPL_ENDERECO);
            }


            /*" -577- IF VIND-NULL04 LESS ZEROS */

            if (VIND_NULL04 < 00)
            {

                /*" -579- MOVE SPACES TO OD007-NOM-BAIRRO. */
                _.Move("", OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_BAIRRO);
            }


            /*" -580- IF VIND-NULL05 LESS ZEROS */

            if (VIND_NULL05 < 00)
            {

                /*" -582- MOVE SPACES TO OD007-NOM-CIDADE. */
                _.Move("", OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_CIDADE);
            }


            /*" -583- IF VIND-NULL06 LESS ZEROS */

            if (VIND_NULL06 < 00)
            {

                /*" -585- MOVE SPACES TO OD007-COD-CEP. */
                _.Move("", OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_CEP);
            }


            /*" -586- IF VIND-NULL07 LESS ZEROS */

            if (VIND_NULL07 < 00)
            {

                /*" -589- MOVE SPACES TO OD007-COD-UF. */
                _.Move("", OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_UF);
            }


            /*" -591- IF OD007-NOM-LOGRADOURO NOT EQUAL LINK-NOM-LOGRADOURO */

            if (OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_LOGRADOURO != LINK_PARAMETRO.LINK_NOM_LOGRADOURO)
            {

                /*" -592- MOVE 'N' TO WTEM-ENDERECO */
                _.Move("N", AREA_DE_WORK.WTEM_ENDERECO);

                /*" -594- GO TO R320-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R320_EXIT*/ //GOTO
                return;
            }


            /*" -596- IF OD007-DES-COMPL-ENDERECO NOT EQUAL LINK-DES-COMPL-ENDERECO */

            if (OD007.DCLOD_PESSOA_ENDERECO.OD007_DES_COMPL_ENDERECO != LINK_PARAMETRO.LINK_DES_COMPL_ENDERECO)
            {

                /*" -597- MOVE 'N' TO WTEM-ENDERECO */
                _.Move("N", AREA_DE_WORK.WTEM_ENDERECO);

                /*" -599- GO TO R320-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R320_EXIT*/ //GOTO
                return;
            }


            /*" -601- IF OD007-NOM-BAIRRO NOT EQUAL LINK-NOM-BAIRRO */

            if (OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_BAIRRO != LINK_PARAMETRO.LINK_NOM_BAIRRO)
            {

                /*" -602- MOVE 'N' TO WTEM-ENDERECO */
                _.Move("N", AREA_DE_WORK.WTEM_ENDERECO);

                /*" -604- GO TO R320-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R320_EXIT*/ //GOTO
                return;
            }


            /*" -606- IF OD007-NOM-CIDADE NOT EQUAL LINK-NOM-CIDADE */

            if (OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_CIDADE != LINK_PARAMETRO.LINK_NOM_CIDADE)
            {

                /*" -607- MOVE 'N' TO WTEM-ENDERECO */
                _.Move("N", AREA_DE_WORK.WTEM_ENDERECO);

                /*" -609- GO TO R320-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R320_EXIT*/ //GOTO
                return;
            }


            /*" -611- IF OD007-COD-CEP NOT EQUAL LINK-COD-CEP */

            if (OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_CEP != LINK_PARAMETRO.LINK_COD_CEP)
            {

                /*" -612- MOVE 'N' TO WTEM-ENDERECO */
                _.Move("N", AREA_DE_WORK.WTEM_ENDERECO);

                /*" -614- GO TO R320-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R320_EXIT*/ //GOTO
                return;
            }


            /*" -616- IF OD007-COD-UF NOT EQUAL LINK-COD-UF */

            if (OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_UF != LINK_PARAMETRO.LINK_COD_UF)
            {

                /*" -617- MOVE 'N' TO WTEM-ENDERECO */
                _.Move("N", AREA_DE_WORK.WTEM_ENDERECO);

                /*" -620- GO TO R320-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R320_EXIT*/ //GOTO
                return;
            }


            /*" -620- PERFORM R320_00_FETCH_ENDERECO_DB_CLOSE_2 */

            R320_00_FETCH_ENDERECO_DB_CLOSE_2();

            /*" -622- MOVE 'S' TO WFIM-MOVIMENTO. */
            _.Move("S", AREA_DE_WORK.WFIM_MOVIMENTO);

            /*" -624- MOVE 'S' TO WTEM-ENDERECO. */
            _.Move("S", AREA_DE_WORK.WTEM_ENDERECO);

            /*" -625- MOVE OD001-NUM-PESSOA TO LINK-NUM-PESSOA */
            _.Move(OD001.DCLOD_PESSOA.OD001_NUM_PESSOA, LINK_PARAMETRO.LINK_NUM_PESSOA);

            /*" -626- MOVE OD001-DTH-CADASTRAMENTO TO LINK-DTH-CADASTRAMENTO */
            _.Move(OD001.DCLOD_PESSOA.OD001_DTH_CADASTRAMENTO, LINK_PARAMETRO.LINK_DTH_CADASTRAMENTO);

            /*" -627- MOVE OD001-NUM-DV-PESSOA TO LINK-NUM-DV-PESSOA */
            _.Move(OD001.DCLOD_PESSOA.OD001_NUM_DV_PESSOA, LINK_PARAMETRO.LINK_NUM_DV_PESSOA);

            /*" -628- MOVE OD001-IND-PESSOA TO LINK-IND-PESSOA */
            _.Move(OD001.DCLOD_PESSOA.OD001_IND_PESSOA, LINK_PARAMETRO.LINK_IND_PESSOA);

            /*" -629- MOVE OD001-STA-INF-INTEGRA TO LINK-STA-INF-INTEGRA */
            _.Move(OD001.DCLOD_PESSOA.OD001_STA_INF_INTEGRA, LINK_PARAMETRO.LINK_STA_INF_INTEGRA);

            /*" -630- MOVE OD007-SEQ-ENDERECO TO LINK-SEQ-ENDERECO */
            _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_SEQ_ENDERECO, LINK_PARAMETRO.LINK_SEQ_ENDERECO);

            /*" -631- MOVE OD007-DTH-CADASTRAMENTO TO LINK-DTH-CADASTRAMENTO-END */
            _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_DTH_CADASTRAMENTO, LINK_PARAMETRO.LINK_DTH_CADASTRAMENTO_END);

            /*" -632- MOVE OD007-IND-ENDERECO TO LINK-IND-ENDERECO */
            _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_IND_ENDERECO, LINK_PARAMETRO.LINK_IND_ENDERECO);

            /*" -633- MOVE OD007-STA-ENDERECO TO LINK-STA-ENDERECO */
            _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_STA_ENDERECO, LINK_PARAMETRO.LINK_STA_ENDERECO);

            /*" -634- MOVE OD007-NOM-LOGRADOURO TO LINK-NOM-LOGRADOURO */
            _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_LOGRADOURO, LINK_PARAMETRO.LINK_NOM_LOGRADOURO);

            /*" -635- MOVE OD007-DES-NUM-IMOVEL TO LINK-DES-NUM-IMOVEL */
            _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_DES_NUM_IMOVEL, LINK_PARAMETRO.LINK_DES_NUM_IMOVEL);

            /*" -636- MOVE OD007-DES-COMPL-ENDERECO TO LINK-DES-COMPL-ENDERECO */
            _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_DES_COMPL_ENDERECO, LINK_PARAMETRO.LINK_DES_COMPL_ENDERECO);

            /*" -637- MOVE OD007-NOM-BAIRRO TO LINK-NOM-BAIRRO */
            _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_BAIRRO, LINK_PARAMETRO.LINK_NOM_BAIRRO);

            /*" -638- MOVE OD007-NOM-CIDADE TO LINK-NOM-CIDADE */
            _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_CIDADE, LINK_PARAMETRO.LINK_NOM_CIDADE);

            /*" -639- MOVE OD007-COD-CEP TO LINK-COD-CEP */
            _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_CEP, LINK_PARAMETRO.LINK_COD_CEP);

            /*" -640- MOVE OD007-COD-UF TO LINK-COD-UF */
            _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_UF, LINK_PARAMETRO.LINK_COD_UF);

            /*" -641- MOVE OD007-STA-CORRESPONDER TO LINK-STA-CORRESPONDER */
            _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_STA_CORRESPONDER, LINK_PARAMETRO.LINK_STA_CORRESPONDER);

            /*" -641- MOVE OD007-STA-PROPAGANDA TO LINK-STA-PROPAGANDA. */
            _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_STA_PROPAGANDA, LINK_PARAMETRO.LINK_STA_PROPAGANDA);

        }

        [StopWatch]
        /*" R320-00-FETCH-ENDERECO-DB-FETCH-1 */
        public void R320_00_FETCH_ENDERECO_DB_FETCH_1()
        {
            /*" -559- EXEC SQL FETCH V0ENDERECO INTO :OD001-NUM-PESSOA , :OD001-DTH-CADASTRAMENTO , :OD001-NUM-DV-PESSOA , :OD001-IND-PESSOA , :OD001-STA-INF-INTEGRA , :OD007-SEQ-ENDERECO , :OD007-DTH-CADASTRAMENTO , :OD007-IND-ENDERECO , :OD007-STA-ENDERECO , :OD007-NOM-LOGRADOURO:VIND-NULL01 , :OD007-DES-NUM-IMOVEL:VIND-NULL02 , :OD007-DES-COMPL-ENDERECO:VIND-NULL03 , :OD007-NOM-BAIRRO:VIND-NULL04 , :OD007-NOM-CIDADE:VIND-NULL05 , :OD007-COD-CEP:VIND-NULL06 , :OD007-COD-UF:VIND-NULL07 , :OD007-STA-CORRESPONDER , :OD007-STA-PROPAGANDA END-EXEC. */

            if (V0ENDERECO.Fetch())
            {
                _.Move(V0ENDERECO.OD001_NUM_PESSOA, OD001.DCLOD_PESSOA.OD001_NUM_PESSOA);
                _.Move(V0ENDERECO.OD001_DTH_CADASTRAMENTO, OD001.DCLOD_PESSOA.OD001_DTH_CADASTRAMENTO);
                _.Move(V0ENDERECO.OD001_NUM_DV_PESSOA, OD001.DCLOD_PESSOA.OD001_NUM_DV_PESSOA);
                _.Move(V0ENDERECO.OD001_IND_PESSOA, OD001.DCLOD_PESSOA.OD001_IND_PESSOA);
                _.Move(V0ENDERECO.OD001_STA_INF_INTEGRA, OD001.DCLOD_PESSOA.OD001_STA_INF_INTEGRA);
                _.Move(V0ENDERECO.OD007_SEQ_ENDERECO, OD007.DCLOD_PESSOA_ENDERECO.OD007_SEQ_ENDERECO);
                _.Move(V0ENDERECO.OD007_DTH_CADASTRAMENTO, OD007.DCLOD_PESSOA_ENDERECO.OD007_DTH_CADASTRAMENTO);
                _.Move(V0ENDERECO.OD007_IND_ENDERECO, OD007.DCLOD_PESSOA_ENDERECO.OD007_IND_ENDERECO);
                _.Move(V0ENDERECO.OD007_STA_ENDERECO, OD007.DCLOD_PESSOA_ENDERECO.OD007_STA_ENDERECO);
                _.Move(V0ENDERECO.OD007_NOM_LOGRADOURO, OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_LOGRADOURO);
                _.Move(V0ENDERECO.VIND_NULL01, VIND_NULL01);
                _.Move(V0ENDERECO.OD007_DES_NUM_IMOVEL, OD007.DCLOD_PESSOA_ENDERECO.OD007_DES_NUM_IMOVEL);
                _.Move(V0ENDERECO.VIND_NULL02, VIND_NULL02);
                _.Move(V0ENDERECO.OD007_DES_COMPL_ENDERECO, OD007.DCLOD_PESSOA_ENDERECO.OD007_DES_COMPL_ENDERECO);
                _.Move(V0ENDERECO.VIND_NULL03, VIND_NULL03);
                _.Move(V0ENDERECO.OD007_NOM_BAIRRO, OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_BAIRRO);
                _.Move(V0ENDERECO.VIND_NULL04, VIND_NULL04);
                _.Move(V0ENDERECO.OD007_NOM_CIDADE, OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_CIDADE);
                _.Move(V0ENDERECO.VIND_NULL05, VIND_NULL05);
                _.Move(V0ENDERECO.OD007_COD_CEP, OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_CEP);
                _.Move(V0ENDERECO.VIND_NULL06, VIND_NULL06);
                _.Move(V0ENDERECO.OD007_COD_UF, OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_UF);
                _.Move(V0ENDERECO.VIND_NULL07, VIND_NULL07);
                _.Move(V0ENDERECO.OD007_STA_CORRESPONDER, OD007.DCLOD_PESSOA_ENDERECO.OD007_STA_CORRESPONDER);
                _.Move(V0ENDERECO.OD007_STA_PROPAGANDA, OD007.DCLOD_PESSOA_ENDERECO.OD007_STA_PROPAGANDA);
            }

        }

        [StopWatch]
        /*" R320-00-FETCH-ENDERECO-DB-CLOSE-1 */
        public void R320_00_FETCH_ENDERECO_DB_CLOSE_1()
        {
            /*" -562- EXEC SQL CLOSE V0ENDERECO END-EXEC */

            V0ENDERECO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R320_EXIT*/

        [StopWatch]
        /*" R320-00-FETCH-ENDERECO-DB-CLOSE-2 */
        public void R320_00_FETCH_ENDERECO_DB_CLOSE_2()
        {
            /*" -620- EXEC SQL CLOSE V0ENDERECO END-EXEC. */

            V0ENDERECO.Close();

        }

        [StopWatch]
        /*" R1000-DISPLAY-INSERT */
        private void R1000_DISPLAY_INSERT(bool isPerform = false)
        {
            /*" -647- DISPLAY 'OD001-NUM-PESSOA.........' OD001-NUM-PESSOA */
            _.Display($"OD001-NUM-PESSOA.........{OD001.DCLOD_PESSOA.OD001_NUM_PESSOA}");

            /*" -648- DISPLAY 'OD001-DTH-CADASTRAMENTO..' OD001-DTH-CADASTRAMENTO */
            _.Display($"OD001-DTH-CADASTRAMENTO..{OD001.DCLOD_PESSOA.OD001_DTH_CADASTRAMENTO}");

            /*" -649- DISPLAY 'OD001-NUM-DV-PESSOA......' OD001-NUM-DV-PESSOA */
            _.Display($"OD001-NUM-DV-PESSOA......{OD001.DCLOD_PESSOA.OD001_NUM_DV_PESSOA}");

            /*" -650- DISPLAY 'OD001-IND-PESSOA.........' OD001-IND-PESSOA */
            _.Display($"OD001-IND-PESSOA.........{OD001.DCLOD_PESSOA.OD001_IND_PESSOA}");

            /*" -651- DISPLAY 'OD001-STA-INF-INTEGRA....' OD001-STA-INF-INTEGRA */
            _.Display($"OD001-STA-INF-INTEGRA....{OD001.DCLOD_PESSOA.OD001_STA_INF_INTEGRA}");

            /*" -652- DISPLAY ' ' */
            _.Display($" ");

            /*" -653- DISPLAY 'NUM-PESSOA.........' OD007-NUM-PESSOA */
            _.Display($"NUM-PESSOA.........{OD007.DCLOD_PESSOA_ENDERECO.OD007_NUM_PESSOA}");

            /*" -654- DISPLAY 'SEQ-ENDERECO.......' OD007-SEQ-ENDERECO */
            _.Display($"SEQ-ENDERECO.......{OD007.DCLOD_PESSOA_ENDERECO.OD007_SEQ_ENDERECO}");

            /*" -655- DISPLAY 'DTH-CADASTRAMENTO..' OD007-DTH-CADASTRAMENTO */
            _.Display($"DTH-CADASTRAMENTO..{OD007.DCLOD_PESSOA_ENDERECO.OD007_DTH_CADASTRAMENTO}");

            /*" -656- DISPLAY 'IND-ENDERECO.......' OD007-IND-ENDERECO */
            _.Display($"IND-ENDERECO.......{OD007.DCLOD_PESSOA_ENDERECO.OD007_IND_ENDERECO}");

            /*" -657- DISPLAY 'STA-ENDERECO.......' OD007-STA-ENDERECO */
            _.Display($"STA-ENDERECO.......{OD007.DCLOD_PESSOA_ENDERECO.OD007_STA_ENDERECO}");

            /*" -658- DISPLAY 'NOM-LOGRADOURO.....' OD007-NOM-LOGRADOURO */
            _.Display($"NOM-LOGRADOURO.....{OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_LOGRADOURO}");

            /*" -659- DISPLAY 'DES-NUM-IMOVEL.....' OD007-DES-NUM-IMOVEL */
            _.Display($"DES-NUM-IMOVEL.....{OD007.DCLOD_PESSOA_ENDERECO.OD007_DES_NUM_IMOVEL}");

            /*" -660- DISPLAY 'DES-COMPL-ENDERECO.' OD007-DES-COMPL-ENDERECO */
            _.Display($"DES-COMPL-ENDERECO.{OD007.DCLOD_PESSOA_ENDERECO.OD007_DES_COMPL_ENDERECO}");

            /*" -661- DISPLAY 'NOM-BAIRRO.........' OD007-NOM-BAIRRO */
            _.Display($"NOM-BAIRRO.........{OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_BAIRRO}");

            /*" -662- DISPLAY 'NOM-CIDADE.........' OD007-NOM-CIDADE */
            _.Display($"NOM-CIDADE.........{OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_CIDADE}");

            /*" -663- DISPLAY 'COD-CEP............' OD007-COD-CEP */
            _.Display($"COD-CEP............{OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_CEP}");

            /*" -664- DISPLAY 'COD-UF.............' OD007-COD-UF */
            _.Display($"COD-UF.............{OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_UF}");

            /*" -665- DISPLAY 'STA-CORRESPONDER...' OD007-STA-CORRESPONDER */
            _.Display($"STA-CORRESPONDER...{OD007.DCLOD_PESSOA_ENDERECO.OD007_STA_CORRESPONDER}");

            /*" -665- DISPLAY 'STA-PROPAGANDA.....' OD007-STA-PROPAGANDA . */
            _.Display($"STA-PROPAGANDA.....{OD007.DCLOD_PESSOA_ENDERECO.OD007_STA_PROPAGANDA}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_EXIT*/

        [StopWatch]
        /*" R9999-00-CANCELA-PROGRAMA */
        private void R9999_00_CANCELA_PROGRAMA(bool isPerform = false)
        {
            /*" -672- MOVE 'SIM' TO LINK-IND-ERRO */
            _.Move("SIM", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_IND_ERRO);

            /*" -675- MOVE SQLCODE TO LINK-SQLCODE WSQLCODE */
            _.Move(DB.SQLCODE, LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_SQLCODE, AREA_DE_WORK.WABEND.WABEND3.WSQLCODE);

            /*" -676- DISPLAY ' ' */
            _.Display($" ");

            /*" -677- DISPLAY '=====  PROGRAMA ABENDADO  =====' */
            _.Display($"=====  PROGRAMA ABENDADO  =====");

            /*" -678- DISPLAY ' ' */
            _.Display($" ");

            /*" -679- DISPLAY 'ERRO NA ROTINA GE0502B ' W-WNR-EXEC-SQL */
            _.Display($"ERRO NA ROTINA GE0502B {W_LINK_MSG_ERRO.W_WNR_EXEC_SQL}");

            /*" -680- DISPLAY 'LINK-MSG-ADICIONAL.' LINK-MSG-ADICIONAL */
            _.Display($"LINK-MSG-ADICIONAL.{LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ADICIONAL}");

            /*" -681- DISPLAY 'LINK-IND-ERRO......' LINK-IND-ERRO */
            _.Display($"LINK-IND-ERRO......{LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_IND_ERRO}");

            /*" -682- DISPLAY 'LINK-MSG-ERRO......' LINK-MSG-ERRO */
            _.Display($"LINK-MSG-ERRO......{LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO}");

            /*" -683- DISPLAY 'LINK-SQLCODE.......' LINK-SQLCODE */
            _.Display($"LINK-SQLCODE.......{LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_SQLCODE}");

            /*" -685- DISPLAY 'LINK-NOME-TABELA...' LINK-NOME-TABELA */
            _.Display($"LINK-NOME-TABELA...{LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_NOME_TABELA}");

            /*" -686- DISPLAY WABEND1. */
            _.Display(AREA_DE_WORK.WABEND.WABEND1);

            /*" -687- DISPLAY WABEND2. */
            _.Display(AREA_DE_WORK.WABEND.WABEND2);

            /*" -689- DISPLAY WABEND3. */
            _.Display(AREA_DE_WORK.WABEND.WABEND3);

            /*" -689- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -693- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -697- GOBACK. */

            throw new GoBack();

        }
    }
}