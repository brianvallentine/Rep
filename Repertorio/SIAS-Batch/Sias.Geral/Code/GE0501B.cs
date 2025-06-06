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
using Sias.Geral.DB2.GE0501B;

namespace Code
{
    public class GE0501B
    {
        public bool IsCall { get; set; }

        public GE0501B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  PESSOA                             *      */
        /*"      *   PROGRAMA ...............  GE0501B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  FAST COMPUTER                      *      */
        /*"      *   PROGRAMADOR ............  MARCO ANTONIO                      *      */
        /*"      *   DATA CODIFICACAO .......  DEZEMBRO/2007                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO.. EFETUAR O CADASTRAMENTO E CONSULTA DE PESSOA JURIDICA      */
        /*"      *            NA BASE DE PESSOA                                   *      */
        /*"      *   GE0501B - COBOL / DB2 / CICS                                 *      */
        /*"      *   GE0501B - COBOL / DB2                                               */
        /*"      *----------------------------------------------------------------*      */
        /*"      * HISTORICO DE CORRECOES                                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * NO   VERSAO    DATA       RESPONSAVEL           ALTERACAO      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 3    V.3       04/01/2012  PATRICIA SALES  PROCURE POR V.03    *      */
        /*"      * LINK-TIPO-UTILIZACAO = 1 CONSULTA PELO CNPJ, CASO A PESSOA NAO *      */
        /*"      * SEJA ENCONTRADA, SERA FEITA INCLUSAO.                          *      */
        /*"      * LINK-TIPO-UTILIZACAO = 2 CONSULTA PELO CODIGO DE PESSOA        *      */
        /*"      * LINK-TIPO-UTILIZACAO = 3 INCLUSAO DE PESSOA SEM CONSULTA.      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 02                                                    *      */
        /*"      *             - CAD 14.198    PASSA A CLASSIFICAR NUM_PESSOA     *      */
        /*"      *               EM ORDEM DESCENDENTE PARA CNPJ/CPF JA ENCONTRADO *      */
        /*"      *               PARA ALINHAR COM O ON-LINE 99-34, APLICACAO      *      */
        /*"      *               GE01M020 - MANUTENCAO BASE ODS.                  *      */
        /*"      *   EM 10/02/2009 - FAST COMPUTER            PROCURE POR V.02    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * V.01 - FAST COMPUTER                                                  */
        /*"      *        RETIRADA A CRITICA DE NUMERO DO CNPJ ZERADO. O BANCO DO        */
        /*"      *        BRASIL TEM O NUMERO DO CNPJ IGUAL A ZERO.                      */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01     AREA-DE-WORK.*/
        public GE0501B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new GE0501B_AREA_DE_WORK();
        public class GE0501B_AREA_DE_WORK : VarBasis
        {
            /*"  05 W-TABELA-LIKE-NOME.*/
            public GE0501B_W_TABELA_LIKE_NOME W_TABELA_LIKE_NOME { get; set; } = new GE0501B_W_TABELA_LIKE_NOME();
            public class GE0501B_W_TABELA_LIKE_NOME : VarBasis
            {
                /*"     10 W-TAB-LIKE-NOME              PIC X(01) OCCURS 200 TIMES.*/
                public ListBasis<StringBasis, string> W_TAB_LIKE_NOME { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(01)"), 200);
                /*"  05 IND-NULL-01                     PIC  S9(04) COMP VALUE +0.*/
            }
            public IntBasis IND_NULL_01 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05 IND-NULL-02                     PIC  S9(04) COMP VALUE +0.*/
            public IntBasis IND_NULL_02 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05 IND-NULL-03                     PIC  S9(04) COMP VALUE +0.*/
            public IntBasis IND_NULL_03 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05 IND-NULL-04                     PIC  S9(04) COMP VALUE +0.*/
            public IntBasis IND_NULL_04 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05 IND-NULL-05                     PIC  S9(04) COMP VALUE +0.*/
            public IntBasis IND_NULL_05 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05 IND-NULL-06                     PIC  S9(04) COMP VALUE +0.*/
            public IntBasis IND_NULL_06 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05 IND-NULL-07                     PIC  S9(04) COMP VALUE +0.*/
            public IntBasis IND_NULL_07 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05 IND-NULL-08                     PIC  S9(04) COMP VALUE +0.*/
            public IntBasis IND_NULL_08 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05 IND-NULL-09                     PIC  S9(04) COMP VALUE +0.*/
            public IntBasis IND_NULL_09 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05 IND-NULL-10                     PIC  S9(04) COMP VALUE +0.*/
            public IntBasis IND_NULL_10 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05 IND-NULL-11                     PIC  S9(04) COMP VALUE +0.*/
            public IntBasis IND_NULL_11 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05 IND-NULL-12                     PIC  S9(04) COMP VALUE +0.*/
            public IntBasis IND_NULL_12 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05 IND-NULL-13                     PIC  S9(04) COMP VALUE +0.*/
            public IntBasis IND_NULL_13 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05 W-IND-NOME                      PIC 9(03) VALUE ZEROS.*/
            public IntBasis W_IND_NOME { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
            /*"  05   W-EDICAO                      PIC  Z.ZZZ.ZZ9,99-.*/
            public DoubleBasis W_EDICAO { get; set; } = new DoubleBasis(new PIC("9", "7", "Z.ZZZ.ZZ9V99-."), 3);
            /*"  05 HOST-CURRENT-DATE               PIC  X(10) VALUE SPACES.*/
            public StringBasis HOST_CURRENT_DATE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"  05 HOST-CURRENT-TIMESTAMP          PIC  X(26) VALUE SPACES.*/
            public StringBasis HOST_CURRENT_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)"), @"");
            /*"  05 WFIM-MOVIMENTO                  PIC X(001) VALUE 'N'.*/
            public StringBasis WFIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  05 WTEM-PESSOA                     PIC X(001) VALUE  SPACES.*/
            public StringBasis WTEM_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05 AUX-NOM-RAZAO-SOCIAL            PIC X(200).*/
            public StringBasis AUX_NOM_RAZAO_SOCIAL { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");
            /*"  05   WABEND.*/
            public GE0501B_WABEND WABEND { get; set; } = new GE0501B_WABEND();
            public class GE0501B_WABEND : VarBasis
            {
                /*"    10 WABEND1                       PIC  X(009)  VALUE                                                      'GE0501B '*/
                public StringBasis WABEND1 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"GE0501B ");
                /*"    10 WABEND2.*/
                public GE0501B_WABEND2 WABEND2 { get; set; } = new GE0501B_WABEND2();
                public class GE0501B_WABEND2 : VarBasis
                {
                    /*"      15 FILLER                      PIC  X(025)  VALUE                                     '*** ERRO EXEC SQL NUMERO '*/
                    public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"*** ERRO EXEC SQL NUMERO ");
                    /*"      15 WNR-EXEC-SQL                PIC  X(005)  VALUE SPACES.*/
                    public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                    /*"    10 WABEND3.*/
                }
                public GE0501B_WABEND3 WABEND3 { get; set; } = new GE0501B_WABEND3();
                public class GE0501B_WABEND3 : VarBasis
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
        public GE0501B_W_LINK_MSG_ERRO W_LINK_MSG_ERRO { get; set; } = new GE0501B_W_LINK_MSG_ERRO();
        public class GE0501B_W_LINK_MSG_ERRO : VarBasis
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
        public GE0501B_LINK_PARAMETRO LINK_PARAMETRO { get; set; } = new GE0501B_LINK_PARAMETRO();
        public class GE0501B_LINK_PARAMETRO : VarBasis
        {
            /*"  05   LINK-TIPO-UTILIZACAO          PIC  9(001).*/
            public IntBasis LINK_TIPO_UTILIZACAO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05   LINK-PESSOA-ESPECIAL          PIC  X(1).*/
            public StringBasis LINK_PESSOA_ESPECIAL { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
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
            /*"  05   LINK-NUM-CNPJ                 PIC S9(9) USAGE COMP.*/
            public IntBasis LINK_NUM_CNPJ { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
            /*"  05   LINK-NUM-FILIAL               PIC S9(4) USAGE COMP.*/
            public IntBasis LINK_NUM_FILIAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"  05   LINK-NUM-DV-CNPJ              PIC S9(4) USAGE COMP.*/
            public IntBasis LINK_NUM_DV_CNPJ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"  05   LINK-NOM-RAZAO-SOCIAL         PIC X(200).*/
            public StringBasis LINK_NOM_RAZAO_SOCIAL { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");
            /*"  05   LINK-STA-PESSOA               PIC X(1).*/
            public StringBasis LINK_STA_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
            /*"  05   LINK-NUM-RAMO-ATIVIDADE       PIC S9(9) USAGE COMP.*/
            public IntBasis LINK_NUM_RAMO_ATIVIDADE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
            /*"  05   LINK-DTH-FUNDACAO             PIC X(10).*/
            public StringBasis LINK_DTH_FUNDACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"  05   LINK-NOM-FANTASIA             PIC X(100).*/
            public StringBasis LINK_NOM_FANTASIA { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
            /*"  05   LINK-NOM-SIGLA-PESSOA         PIC X(40).*/
            public StringBasis LINK_NOM_SIGLA_PESSOA { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"  05   LINK-NUM-INSC-ESTADUAL        PIC S9(14)V USAGE COMP-3.*/
            public DoubleBasis LINK_NUM_INSC_ESTADUAL { get; set; } = new DoubleBasis(new PIC("S9", "14", "S9(14)V"), 0);
            /*"  05   LINK-NUM-INSC-MUNICIPAL       PIC S9(14)V USAGE COMP-3.*/
            public DoubleBasis LINK_NUM_INSC_MUNICIPAL { get; set; } = new DoubleBasis(new PIC("S9", "14", "S9(14)V"), 0);
            /*"  05   LINK-COD-UF                   PIC X(2).*/
            public StringBasis LINK_COD_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
            /*"  05   LINK-NUM-MUNICIPIO            PIC S9(9) USAGE COMP.*/
            public IntBasis LINK_NUM_MUNICIPIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
            /*"  05   LINK-COD-CNAE                 PIC X(20).*/
            public StringBasis LINK_COD_CNAE { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
            /*"  05   LINK-NUM-SOCIOS               PIC S9(4) USAGE COMP.*/
            public IntBasis LINK_NUM_SOCIOS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"  05   LINK-STA-FRANQUIA             PIC X(1).*/
            public StringBasis LINK_STA_FRANQUIA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
            /*"  05   LINK-IND-FINALIDADE           PIC X(1).*/
            public StringBasis LINK_IND_FINALIDADE { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
            /*"  05   LINK-PARAMETROS-SAIDA.*/
            public GE0501B_LINK_PARAMETROS_SAIDA LINK_PARAMETROS_SAIDA { get; set; } = new GE0501B_LINK_PARAMETROS_SAIDA();
            public class GE0501B_LINK_PARAMETROS_SAIDA : VarBasis
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
        public Dclgens.UNIDAFED UNIDAFED { get; set; } = new Dclgens.UNIDAFED();
        public GE0501B_V0PJURIDICA V0PJURIDICA { get; set; } = new GE0501B_V0PJURIDICA();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(GE0501B_LINK_PARAMETRO GE0501B_LINK_PARAMETRO_P) //PROCEDURE DIVISION USING 
        /*LINK_PARAMETRO*/
        {
            try
            {
                this.LINK_PARAMETRO = GE0501B_LINK_PARAMETRO_P;

                /*" -178- MOVE '0001' TO WNR-EXEC-SQL */
                _.Move("0001", AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL);

                /*" -178- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -179- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -180- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -184- INITIALIZE LINK-PARAMETROS-SAIDA. */
                _.Initialize(
                    LINK_PARAMETRO.LINK_PARAMETROS_SAIDA
                );

                /*" -186- MOVE '0002' TO WNR-EXEC-SQL */
                _.Move("0002", AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL);

                /*" -193- PERFORM Execute_DB_SELECT_1 */

                Execute_DB_SELECT_1();

                /*" -196- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -198- MOVE 'GE0501B - ERRO NA LEITURA DA SISTEMAS' TO W-LINK-MENSAGEM */
                    _.Move("GE0501B - ERRO NA LEITURA DA SISTEMAS", W_LINK_MSG_ERRO.W_LINK_MENSAGEM);

                    /*" -199- MOVE SQLCODE TO W-LINK-SQLCODE */
                    _.Move(DB.SQLCODE, W_LINK_MSG_ERRO.W_LINK_SQLCODE);

                    /*" -200- MOVE WNR-EXEC-SQL TO W-WNR-EXEC-SQL */
                    _.Move(AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL, W_LINK_MSG_ERRO.W_WNR_EXEC_SQL);

                    /*" -201- MOVE W-LINK-MSG-ERRO TO LINK-MSG-ERRO */
                    _.Move(W_LINK_MSG_ERRO, LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                    /*" -202- MOVE 'SISTEMAS   ' TO LINK-NOME-TABELA */
                    _.Move("SISTEMAS   ", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_NOME_TABELA);

                    /*" -203- DISPLAY 'GE0501B - ERRO ACESSO SISTEMAS' */
                    _.Display($"GE0501B - ERRO ACESSO SISTEMAS");

                    /*" -209- GO TO R9999-00-CANCELA-PROGRAMA. */

                    R9999_00_CANCELA_PROGRAMA(); //GOTO
                    return Result;
                }


                /*" -212- IF (LINK-TIPO-UTILIZACAO NOT EQUAL 1) AND (LINK-TIPO-UTILIZACAO NOT EQUAL 2) AND (LINK-TIPO-UTILIZACAO NOT EQUAL 3) */

                if ((LINK_PARAMETRO.LINK_TIPO_UTILIZACAO != 1) && (LINK_PARAMETRO.LINK_TIPO_UTILIZACAO != 2) && (LINK_PARAMETRO.LINK_TIPO_UTILIZACAO != 3))
                {

                    /*" -215- MOVE 'GE0501B - - TIPO DE CHAMADA INVALIDO. 1 - CONSULTA/INUSAO 2 - CONSULTA 3 - INCLUSAO' TO LINK-MSG-ERRO */
                    _.Move("GE0501B - - TIPO DE CHAMADA INVALIDO. 1 - CONSULTA/INUSAO 2 - CONSULTA 3 - INCLUSAO", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                    /*" -217- GO TO R9999-00-CANCELA-PROGRAMA. */

                    R9999_00_CANCELA_PROGRAMA(); //GOTO
                    return Result;
                }


                /*" -218- IF LINK-PROGRAMA-CHAMADOR EQUAL SPACES */

                if (LINK_PARAMETRO.LINK_PROGRAMA_CHAMADOR.IsEmpty())
                {

                    /*" -220- MOVE 'GE0501B - NOME DO PGM CHAMADOR NAO INFORMADO' TO LINK-MSG-ERRO */
                    _.Move("GE0501B - NOME DO PGM CHAMADOR NAO INFORMADO", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                    /*" -222- GO TO R9999-00-CANCELA-PROGRAMA. */

                    R9999_00_CANCELA_PROGRAMA(); //GOTO
                    return Result;
                }


                /*" -223- IF LINK-NOME-USUARIO EQUAL SPACES */

                if (LINK_PARAMETRO.LINK_NOME_USUARIO.IsEmpty())
                {

                    /*" -225- MOVE 'GE0501B - NOME DO USUARIO CHAMADOR NAO INFORMADO' TO LINK-MSG-ERRO */
                    _.Move("GE0501B - NOME DO USUARIO CHAMADOR NAO INFORMADO", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                    /*" -227- GO TO R9999-00-CANCELA-PROGRAMA. */

                    R9999_00_CANCELA_PROGRAMA(); //GOTO
                    return Result;
                }


                /*" -228- IF (LINK-TIPO-UTILIZACAO EQUAL 1) */

                if ((LINK_PARAMETRO.LINK_TIPO_UTILIZACAO == 1))
                {

                    /*" -229- PERFORM R010-CRITICA-INCLUSAO THRU R010-EXIT */

                    R010_CRITICA_INCLUSAO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_EXIT*/


                    /*" -230- PERFORM R300-CONSULTA-PJ THRU R300-EXIT */

                    R300_CONSULTA_PJ(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R300_EXIT*/


                    /*" -231- IF WTEM-PESSOA NOT EQUAL 'S' */

                    if (AREA_DE_WORK.WTEM_PESSOA != "S")
                    {

                        /*" -233- PERFORM R100-INSERT-PJ THRU R100-EXIT. */

                        R100_INSERT_PJ(true);

                        INICIO_LOOP_NOME(true);
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/

                    }

                }


                /*" -234- IF (LINK-TIPO-UTILIZACAO EQUAL 2) */

                if ((LINK_PARAMETRO.LINK_TIPO_UTILIZACAO == 2))
                {

                    /*" -235- PERFORM R020-CRITICA-CONSUTA THRU R020-EXIT */

                    R020_CRITICA_CONSUTA(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R020_EXIT*/


                    /*" -237- PERFORM R200-CONSULTA-PJ THRU R200-EXIT. */

                    R200_CONSULTA_PJ(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R200_EXIT*/

                }


                /*" -238- IF (LINK-TIPO-UTILIZACAO EQUAL 3) */

                if ((LINK_PARAMETRO.LINK_TIPO_UTILIZACAO == 3))
                {

                    /*" -239- PERFORM R010-CRITICA-INCLUSAO THRU R010-EXIT */

                    R010_CRITICA_INCLUSAO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_EXIT*/


                    /*" -241- PERFORM R100-INSERT-PJ THRU R100-EXIT. */

                    R100_INSERT_PJ(true);

                    INICIO_LOOP_NOME(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/

                }


                /*" -246- MOVE ZEROS TO RETURN-CODE. */
                _.Move(0, RETURN_CODE);

                /*" -246- GOBACK. */

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
            /*" -193- EXEC SQL SELECT CURRENT DATE, CURRENT TIMESTAMP INTO :HOST-CURRENT-DATE, :HOST-CURRENT-TIMESTAMP FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'EM' END-EXEC. */

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
            /*" -253- IF LINK-IND-PESSOA NOT EQUAL 'J' */

            if (LINK_PARAMETRO.LINK_IND_PESSOA != "J")
            {

                /*" -254- DISPLAY 'GE0501 - CRITICA DE INCLUSAO' */
                _.Display($"GE0501 - CRITICA DE INCLUSAO");

                /*" -256- DISPLAY 'GE0501B - INDICADOR DE PESSOA DIFERE DE JURIDICA' */
                _.Display($"GE0501B - INDICADOR DE PESSOA DIFERE DE JURIDICA");

                /*" -258- MOVE 'GE0501B - INDICADOR DE PESSOA DIFERE DE JURIDICA' TO LINK-MSG-ERRO */
                _.Move("GE0501B - INDICADOR DE PESSOA DIFERE DE JURIDICA", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                /*" -263- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA(); //GOTO
                return;
            }


            /*" -266- IF (LINK-PESSOA-ESPECIAL NOT EQUAL 'N' ) AND (LINK-PESSOA-ESPECIAL NOT EQUAL 'E' ) AND (LINK-PESSOA-ESPECIAL NOT EQUAL 'G' ) */

            if ((LINK_PARAMETRO.LINK_PESSOA_ESPECIAL != "N") && (LINK_PARAMETRO.LINK_PESSOA_ESPECIAL != "E") && (LINK_PARAMETRO.LINK_PESSOA_ESPECIAL != "G"))
            {

                /*" -267- DISPLAY 'GE0501 - CRITICA DE INCLUSAO' */
                _.Display($"GE0501 - CRITICA DE INCLUSAO");

                /*" -269- DISPLAY 'GE0501B - INDICADOR DE PESSOA ESPECIAL INVALIDO' */
                _.Display($"GE0501B - INDICADOR DE PESSOA ESPECIAL INVALIDO");

                /*" -271- MOVE 'GE0501B - INDICADOR DE PESSOA ESPECIAL INVALIDO' TO LINK-MSG-ERRO */
                _.Move("GE0501B - INDICADOR DE PESSOA ESPECIAL INVALIDO", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                /*" -275- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA(); //GOTO
                return;
            }


            /*" -277- IF (LINK-PESSOA-ESPECIAL EQUAL 'E' ) OR (LINK-PESSOA-ESPECIAL EQUAL 'G' ) */

            if ((LINK_PARAMETRO.LINK_PESSOA_ESPECIAL == "E") || (LINK_PARAMETRO.LINK_PESSOA_ESPECIAL == "G"))
            {

                /*" -280- GO TO R010-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_EXIT*/ //GOTO
                return;
            }


            /*" -281- IF LINK-NUM-FILIAL EQUAL 0 */

            if (LINK_PARAMETRO.LINK_NUM_FILIAL == 0)
            {

                /*" -282- DISPLAY 'GE0501 - CRITICA DE INCLUSAO' */
                _.Display($"GE0501 - CRITICA DE INCLUSAO");

                /*" -284- DISPLAY 'GE0501B - NUMERO DA FILIAL DO CNPJ ZERADO' */
                _.Display($"GE0501B - NUMERO DA FILIAL DO CNPJ ZERADO");

                /*" -286- MOVE 'GE0501B - NUMERO DA FILIAL DO CNPJ ZERADO' TO LINK-MSG-ERRO */
                _.Move("GE0501B - NUMERO DA FILIAL DO CNPJ ZERADO", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                /*" -288- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA(); //GOTO
                return;
            }


            /*" -289- IF LINK-NOM-RAZAO-SOCIAL EQUAL SPACES */

            if (LINK_PARAMETRO.LINK_NOM_RAZAO_SOCIAL.IsEmpty())
            {

                /*" -290- DISPLAY 'GE0501 - CRITICA DE INCLUSAO' */
                _.Display($"GE0501 - CRITICA DE INCLUSAO");

                /*" -292- DISPLAY 'GE0501B - RAZAO SOCIAL DA PJ NAO INFORMADA' */
                _.Display($"GE0501B - RAZAO SOCIAL DA PJ NAO INFORMADA");

                /*" -294- MOVE 'GE0501B - RAZAO SOCIAL DA PJ NAO INFORMADA' TO LINK-MSG-ERRO */
                _.Move("GE0501B - RAZAO SOCIAL DA PJ NAO INFORMADA", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                /*" -296- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA(); //GOTO
                return;
            }


            /*" -297- IF LINK-NUM-RAMO-ATIVIDADE EQUAL 0 */

            if (LINK_PARAMETRO.LINK_NUM_RAMO_ATIVIDADE == 0)
            {

                /*" -302- MOVE -1 TO IND-NULL-01. */
                _.Move(-1, AREA_DE_WORK.IND_NULL_01);
            }


            /*" -303- IF LINK-DTH-FUNDACAO EQUAL SPACES */

            if (LINK_PARAMETRO.LINK_DTH_FUNDACAO.IsEmpty())
            {

                /*" -303- MOVE -1 TO IND-NULL-02. */
                _.Move(-1, AREA_DE_WORK.IND_NULL_02);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_EXIT*/

        [StopWatch]
        /*" R020-CRITICA-CONSUTA */
        private void R020_CRITICA_CONSUTA(bool isPerform = false)
        {
            /*" -345- IF LINK-NUM-PESSOA EQUAL 0 */

            if (LINK_PARAMETRO.LINK_NUM_PESSOA == 0)
            {

                /*" -347- MOVE 'GE0501B - INFORME O NUMERO DA PESSOA PARA CONSULTA' TO LINK-MSG-ERRO */
                _.Move("GE0501B - INFORME O NUMERO DA PESSOA PARA CONSULTA", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                /*" -347- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA(); //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R020_EXIT*/

        [StopWatch]
        /*" R200-CONSULTA-PJ */
        private void R200_CONSULTA_PJ(bool isPerform = false)
        {
            /*" -355- MOVE '0006' TO WNR-EXEC-SQL */
            _.Move("0006", AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL);

            /*" -357- INITIALIZE DCLOD-PESSOA DCLOD-PESSOA-JURIDICA. */
            _.Initialize(
                OD001.DCLOD_PESSOA
                , OD003.DCLOD_PESSOA_JURIDICA
            );

            /*" -359- MOVE LINK-NUM-PESSOA TO OD001-NUM-PESSOA. */
            _.Move(LINK_PARAMETRO.LINK_NUM_PESSOA, OD001.DCLOD_PESSOA.OD001_NUM_PESSOA);

            /*" -411- PERFORM R200_CONSULTA_PJ_DB_SELECT_1 */

            R200_CONSULTA_PJ_DB_SELECT_1();

            /*" -414- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -417- MOVE 'GE0501B - PESSOA JURIDICA NAO ENCONTRADA P/ ID INFORMADO' TO LINK-MSG-ERRO */
                _.Move("GE0501B - PESSOA JURIDICA NAO ENCONTRADA P/ ID INFORMADO", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                /*" -419- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA(); //GOTO
                return;
            }


            /*" -420- IF (SQLCODE NOT EQUAL ZEROS) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -422- MOVE 'GE0501B - ERRO NA LEITURA DA PJ P/ ID INFORMADO' TO W-LINK-MENSAGEM */
                _.Move("GE0501B - ERRO NA LEITURA DA PJ P/ ID INFORMADO", W_LINK_MSG_ERRO.W_LINK_MENSAGEM);

                /*" -423- MOVE SQLCODE TO W-LINK-SQLCODE */
                _.Move(DB.SQLCODE, W_LINK_MSG_ERRO.W_LINK_SQLCODE);

                /*" -424- MOVE WNR-EXEC-SQL TO W-WNR-EXEC-SQL */
                _.Move(AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL, W_LINK_MSG_ERRO.W_WNR_EXEC_SQL);

                /*" -425- MOVE W-LINK-MSG-ERRO TO LINK-MSG-ERRO */
                _.Move(W_LINK_MSG_ERRO, LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                /*" -426- MOVE 'PESSOA E PJ' TO LINK-NOME-TABELA */
                _.Move("PESSOA E PJ", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_NOME_TABELA);

                /*" -428- DISPLAY 'GE0501B - ERRO ACESSO JOIN ODS_PESSOA X ODS_PESSO 'A_JURIDICA SQLCODE ' W-LINK-SQLCODE */

                $"GE0501B - ERRO ACESSO JOIN ODS_PESSOA X ODS_PESSO A_JURIDICA{DB.SQLCODE}{W_LINK_MSG_ERRO.W_LINK_SQLCODE}"
                .Display();

                /*" -430- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA(); //GOTO
                return;
            }


            /*" -431- IF IND-NULL-01 LESS ZEROS */

            if (AREA_DE_WORK.IND_NULL_01 < 00)
            {

                /*" -433- MOVE ZEROS TO OD003-NUM-RAMO-ATIVIDADE. */
                _.Move(0, OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_RAMO_ATIVIDADE);
            }


            /*" -434- IF IND-NULL-05 LESS ZEROS */

            if (AREA_DE_WORK.IND_NULL_05 < 00)
            {

                /*" -436- MOVE ZEROS TO OD003-NUM-INSC-ESTADUAL. */
                _.Move(0, OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_INSC_ESTADUAL);
            }


            /*" -437- IF IND-NULL-06 LESS ZEROS */

            if (AREA_DE_WORK.IND_NULL_06 < 00)
            {

                /*" -439- MOVE ZEROS TO OD003-NUM-INSC-MUNICIPAL. */
                _.Move(0, OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_INSC_MUNICIPAL);
            }


            /*" -440- IF IND-NULL-08 LESS ZEROS */

            if (AREA_DE_WORK.IND_NULL_08 < 00)
            {

                /*" -442- MOVE ZEROS TO OD003-NUM-MUNICIPIO. */
                _.Move(0, OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_MUNICIPIO);
            }


            /*" -443- IF IND-NULL-10 LESS ZEROS */

            if (AREA_DE_WORK.IND_NULL_10 < 00)
            {

                /*" -446- MOVE ZEROS TO OD003-NUM-SOCIOS. */
                _.Move(0, OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_SOCIOS);
            }


            /*" -447- IF IND-NULL-02 LESS ZEROS */

            if (AREA_DE_WORK.IND_NULL_02 < 00)
            {

                /*" -449- MOVE SPACES TO OD003-DTH-FUNDACAO. */
                _.Move("", OD003.DCLOD_PESSOA_JURIDICA.OD003_DTH_FUNDACAO);
            }


            /*" -450- IF IND-NULL-03 LESS ZEROS */

            if (AREA_DE_WORK.IND_NULL_03 < 00)
            {

                /*" -452- MOVE SPACES TO OD003-NOM-FANTASIA. */
                _.Move("", OD003.DCLOD_PESSOA_JURIDICA.OD003_NOM_FANTASIA);
            }


            /*" -453- IF IND-NULL-04 LESS ZEROS */

            if (AREA_DE_WORK.IND_NULL_04 < 00)
            {

                /*" -455- MOVE SPACES TO OD003-NOM-SIGLA-PESSOA. */
                _.Move("", OD003.DCLOD_PESSOA_JURIDICA.OD003_NOM_SIGLA_PESSOA);
            }


            /*" -456- IF IND-NULL-07 LESS ZEROS */

            if (AREA_DE_WORK.IND_NULL_07 < 00)
            {

                /*" -458- MOVE SPACES TO OD003-COD-UF. */
                _.Move("", OD003.DCLOD_PESSOA_JURIDICA.OD003_COD_UF);
            }


            /*" -459- IF IND-NULL-09 LESS ZEROS */

            if (AREA_DE_WORK.IND_NULL_09 < 00)
            {

                /*" -461- MOVE SPACES TO OD003-COD-CNAE. */
                _.Move("", OD003.DCLOD_PESSOA_JURIDICA.OD003_COD_CNAE);
            }


            /*" -462- IF IND-NULL-11 LESS ZEROS */

            if (AREA_DE_WORK.IND_NULL_11 < 00)
            {

                /*" -464- MOVE SPACES TO OD003-STA-FRANQUIA. */
                _.Move("", OD003.DCLOD_PESSOA_JURIDICA.OD003_STA_FRANQUIA);
            }


            /*" -465- IF IND-NULL-12 LESS ZEROS */

            if (AREA_DE_WORK.IND_NULL_12 < 00)
            {

                /*" -468- MOVE SPACES TO OD003-IND-FINALIDADE. */
                _.Move("", OD003.DCLOD_PESSOA_JURIDICA.OD003_IND_FINALIDADE);
            }


            /*" -469- MOVE OD001-NUM-PESSOA TO LINK-NUM-PESSOA */
            _.Move(OD001.DCLOD_PESSOA.OD001_NUM_PESSOA, LINK_PARAMETRO.LINK_NUM_PESSOA);

            /*" -470- MOVE OD001-DTH-CADASTRAMENTO TO LINK-DTH-CADASTRAMENTO */
            _.Move(OD001.DCLOD_PESSOA.OD001_DTH_CADASTRAMENTO, LINK_PARAMETRO.LINK_DTH_CADASTRAMENTO);

            /*" -471- MOVE OD001-NUM-DV-PESSOA TO LINK-NUM-DV-PESSOA */
            _.Move(OD001.DCLOD_PESSOA.OD001_NUM_DV_PESSOA, LINK_PARAMETRO.LINK_NUM_DV_PESSOA);

            /*" -472- MOVE OD001-IND-PESSOA TO LINK-IND-PESSOA */
            _.Move(OD001.DCLOD_PESSOA.OD001_IND_PESSOA, LINK_PARAMETRO.LINK_IND_PESSOA);

            /*" -473- MOVE OD001-STA-INF-INTEGRA TO LINK-STA-INF-INTEGRA */
            _.Move(OD001.DCLOD_PESSOA.OD001_STA_INF_INTEGRA, LINK_PARAMETRO.LINK_STA_INF_INTEGRA);

            /*" -474- MOVE OD003-NUM-CNPJ TO LINK-NUM-CNPJ */
            _.Move(OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_CNPJ, LINK_PARAMETRO.LINK_NUM_CNPJ);

            /*" -475- MOVE OD003-NUM-FILIAL TO LINK-NUM-FILIAL */
            _.Move(OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_FILIAL, LINK_PARAMETRO.LINK_NUM_FILIAL);

            /*" -476- MOVE OD003-NUM-DV-CNPJ TO LINK-NUM-DV-CNPJ */
            _.Move(OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_DV_CNPJ, LINK_PARAMETRO.LINK_NUM_DV_CNPJ);

            /*" -477- MOVE OD003-NOM-RAZAO-SOCIAL-TEXT TO LINK-NOM-RAZAO-SOCIAL */
            _.Move(OD003.DCLOD_PESSOA_JURIDICA.OD003_NOM_RAZAO_SOCIAL.OD003_NOM_RAZAO_SOCIAL_TEXT, LINK_PARAMETRO.LINK_NOM_RAZAO_SOCIAL);

            /*" -478- MOVE OD003-STA-PESSOA TO LINK-STA-PESSOA */
            _.Move(OD003.DCLOD_PESSOA_JURIDICA.OD003_STA_PESSOA, LINK_PARAMETRO.LINK_STA_PESSOA);

            /*" -479- MOVE OD003-NUM-RAMO-ATIVIDADE TO LINK-NUM-RAMO-ATIVIDADE */
            _.Move(OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_RAMO_ATIVIDADE, LINK_PARAMETRO.LINK_NUM_RAMO_ATIVIDADE);

            /*" -480- MOVE OD003-DTH-FUNDACAO TO LINK-DTH-FUNDACAO */
            _.Move(OD003.DCLOD_PESSOA_JURIDICA.OD003_DTH_FUNDACAO, LINK_PARAMETRO.LINK_DTH_FUNDACAO);

            /*" -481- MOVE OD003-NOM-FANTASIA TO LINK-NOM-FANTASIA */
            _.Move(OD003.DCLOD_PESSOA_JURIDICA.OD003_NOM_FANTASIA, LINK_PARAMETRO.LINK_NOM_FANTASIA);

            /*" -482- MOVE OD003-NOM-SIGLA-PESSOA TO LINK-NOM-SIGLA-PESSOA */
            _.Move(OD003.DCLOD_PESSOA_JURIDICA.OD003_NOM_SIGLA_PESSOA, LINK_PARAMETRO.LINK_NOM_SIGLA_PESSOA);

            /*" -483- MOVE OD003-NUM-INSC-ESTADUAL TO LINK-NUM-INSC-ESTADUAL */
            _.Move(OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_INSC_ESTADUAL, LINK_PARAMETRO.LINK_NUM_INSC_ESTADUAL);

            /*" -484- MOVE OD003-NUM-INSC-MUNICIPAL TO LINK-NUM-INSC-MUNICIPAL */
            _.Move(OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_INSC_MUNICIPAL, LINK_PARAMETRO.LINK_NUM_INSC_MUNICIPAL);

            /*" -485- MOVE OD003-COD-UF TO LINK-COD-UF */
            _.Move(OD003.DCLOD_PESSOA_JURIDICA.OD003_COD_UF, LINK_PARAMETRO.LINK_COD_UF);

            /*" -486- MOVE OD003-NUM-MUNICIPIO TO LINK-NUM-MUNICIPIO */
            _.Move(OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_MUNICIPIO, LINK_PARAMETRO.LINK_NUM_MUNICIPIO);

            /*" -487- MOVE OD003-COD-CNAE TO LINK-COD-CNAE */
            _.Move(OD003.DCLOD_PESSOA_JURIDICA.OD003_COD_CNAE, LINK_PARAMETRO.LINK_COD_CNAE);

            /*" -488- MOVE OD003-NUM-SOCIOS TO LINK-NUM-SOCIOS */
            _.Move(OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_SOCIOS, LINK_PARAMETRO.LINK_NUM_SOCIOS);

            /*" -489- MOVE OD003-STA-FRANQUIA TO LINK-STA-FRANQUIA */
            _.Move(OD003.DCLOD_PESSOA_JURIDICA.OD003_STA_FRANQUIA, LINK_PARAMETRO.LINK_STA_FRANQUIA);

            /*" -489- MOVE OD003-IND-FINALIDADE TO LINK-IND-FINALIDADE . */
            _.Move(OD003.DCLOD_PESSOA_JURIDICA.OD003_IND_FINALIDADE, LINK_PARAMETRO.LINK_IND_FINALIDADE);

        }

        [StopWatch]
        /*" R200-CONSULTA-PJ-DB-SELECT-1 */
        public void R200_CONSULTA_PJ_DB_SELECT_1()
        {
            /*" -411- EXEC SQL SELECT A.NUM_PESSOA , A.DTH_CADASTRAMENTO , A.NUM_DV_PESSOA , A.IND_PESSOA , A.STA_INF_INTEGRA , B.NUM_PESSOA , B.NUM_CNPJ , B.NUM_FILIAL , B.NUM_DV_CNPJ , B.NOM_RAZAO_SOCIAL , B.STA_PESSOA , B.NUM_RAMO_ATIVIDADE, B.DTH_FUNDACAO , B.NOM_FANTASIA , B.NOM_SIGLA_PESSOA , B.NUM_INSC_ESTADUAL , B.NUM_INSC_MUNICIPAL, B.COD_UF , B.NUM_MUNICIPIO , B.COD_CNAE , B.NUM_SOCIOS , B.STA_FRANQUIA , B.IND_FINALIDADE INTO :OD001-NUM-PESSOA , :OD001-DTH-CADASTRAMENTO , :OD001-NUM-DV-PESSOA , :OD001-IND-PESSOA , :OD001-STA-INF-INTEGRA , :OD003-NUM-PESSOA , :OD003-NUM-CNPJ , :OD003-NUM-FILIAL , :OD003-NUM-DV-CNPJ , :OD003-NOM-RAZAO-SOCIAL, :OD003-STA-PESSOA , :OD003-NUM-RAMO-ATIVIDADE:IND-NULL-01, :OD003-DTH-FUNDACAO:IND-NULL-02, :OD003-NOM-FANTASIA:IND-NULL-03, :OD003-NOM-SIGLA-PESSOA:IND-NULL-04, :OD003-NUM-INSC-ESTADUAL:IND-NULL-05, :OD003-NUM-INSC-MUNICIPAL:IND-NULL-06, :OD003-COD-UF:IND-NULL-07, :OD003-NUM-MUNICIPIO:IND-NULL-08, :OD003-COD-CNAE:IND-NULL-09, :OD003-NUM-SOCIOS:IND-NULL-10, :OD003-STA-FRANQUIA:IND-NULL-11, :OD003-IND-FINALIDADE:IND-NULL-12 FROM ODS.OD_PESSOA A, ODS.OD_PESSOA_JURIDICA B WHERE A.NUM_PESSOA = :OD001-NUM-PESSOA AND B.NUM_PESSOA = A.NUM_PESSOA WITH UR END-EXEC. */

            var r200_CONSULTA_PJ_DB_SELECT_1_Query1 = new R200_CONSULTA_PJ_DB_SELECT_1_Query1()
            {
                OD001_NUM_PESSOA = OD001.DCLOD_PESSOA.OD001_NUM_PESSOA.ToString(),
            };

            var executed_1 = R200_CONSULTA_PJ_DB_SELECT_1_Query1.Execute(r200_CONSULTA_PJ_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OD001_NUM_PESSOA, OD001.DCLOD_PESSOA.OD001_NUM_PESSOA);
                _.Move(executed_1.OD001_DTH_CADASTRAMENTO, OD001.DCLOD_PESSOA.OD001_DTH_CADASTRAMENTO);
                _.Move(executed_1.OD001_NUM_DV_PESSOA, OD001.DCLOD_PESSOA.OD001_NUM_DV_PESSOA);
                _.Move(executed_1.OD001_IND_PESSOA, OD001.DCLOD_PESSOA.OD001_IND_PESSOA);
                _.Move(executed_1.OD001_STA_INF_INTEGRA, OD001.DCLOD_PESSOA.OD001_STA_INF_INTEGRA);
                _.Move(executed_1.OD003_NUM_PESSOA, OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_PESSOA);
                _.Move(executed_1.OD003_NUM_CNPJ, OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_CNPJ);
                _.Move(executed_1.OD003_NUM_FILIAL, OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_FILIAL);
                _.Move(executed_1.OD003_NUM_DV_CNPJ, OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_DV_CNPJ);
                _.Move(executed_1.OD003_NOM_RAZAO_SOCIAL, OD003.DCLOD_PESSOA_JURIDICA.OD003_NOM_RAZAO_SOCIAL);
                _.Move(executed_1.OD003_STA_PESSOA, OD003.DCLOD_PESSOA_JURIDICA.OD003_STA_PESSOA);
                _.Move(executed_1.OD003_NUM_RAMO_ATIVIDADE, OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_RAMO_ATIVIDADE);
                _.Move(executed_1.IND_NULL_01, AREA_DE_WORK.IND_NULL_01);
                _.Move(executed_1.OD003_DTH_FUNDACAO, OD003.DCLOD_PESSOA_JURIDICA.OD003_DTH_FUNDACAO);
                _.Move(executed_1.IND_NULL_02, AREA_DE_WORK.IND_NULL_02);
                _.Move(executed_1.OD003_NOM_FANTASIA, OD003.DCLOD_PESSOA_JURIDICA.OD003_NOM_FANTASIA);
                _.Move(executed_1.IND_NULL_03, AREA_DE_WORK.IND_NULL_03);
                _.Move(executed_1.OD003_NOM_SIGLA_PESSOA, OD003.DCLOD_PESSOA_JURIDICA.OD003_NOM_SIGLA_PESSOA);
                _.Move(executed_1.IND_NULL_04, AREA_DE_WORK.IND_NULL_04);
                _.Move(executed_1.OD003_NUM_INSC_ESTADUAL, OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_INSC_ESTADUAL);
                _.Move(executed_1.IND_NULL_05, AREA_DE_WORK.IND_NULL_05);
                _.Move(executed_1.OD003_NUM_INSC_MUNICIPAL, OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_INSC_MUNICIPAL);
                _.Move(executed_1.IND_NULL_06, AREA_DE_WORK.IND_NULL_06);
                _.Move(executed_1.OD003_COD_UF, OD003.DCLOD_PESSOA_JURIDICA.OD003_COD_UF);
                _.Move(executed_1.IND_NULL_07, AREA_DE_WORK.IND_NULL_07);
                _.Move(executed_1.OD003_NUM_MUNICIPIO, OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_MUNICIPIO);
                _.Move(executed_1.IND_NULL_08, AREA_DE_WORK.IND_NULL_08);
                _.Move(executed_1.OD003_COD_CNAE, OD003.DCLOD_PESSOA_JURIDICA.OD003_COD_CNAE);
                _.Move(executed_1.IND_NULL_09, AREA_DE_WORK.IND_NULL_09);
                _.Move(executed_1.OD003_NUM_SOCIOS, OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_SOCIOS);
                _.Move(executed_1.IND_NULL_10, AREA_DE_WORK.IND_NULL_10);
                _.Move(executed_1.OD003_STA_FRANQUIA, OD003.DCLOD_PESSOA_JURIDICA.OD003_STA_FRANQUIA);
                _.Move(executed_1.IND_NULL_11, AREA_DE_WORK.IND_NULL_11);
                _.Move(executed_1.OD003_IND_FINALIDADE, OD003.DCLOD_PESSOA_JURIDICA.OD003_IND_FINALIDADE);
                _.Move(executed_1.IND_NULL_12, AREA_DE_WORK.IND_NULL_12);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R200_EXIT*/

        [StopWatch]
        /*" R100-INSERT-PJ */
        private void R100_INSERT_PJ(bool isPerform = false)
        {
            /*" -499- INITIALIZE DCLOD-PESSOA DCLOD-PESSOA-JURIDICA. */
            _.Initialize(
                OD001.DCLOD_PESSOA
                , OD003.DCLOD_PESSOA_JURIDICA
            );

            /*" -501- MOVE '0002' TO WNR-EXEC-SQL */
            _.Move("0002", AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL);

            /*" -505- PERFORM R100_INSERT_PJ_DB_SELECT_1 */

            R100_INSERT_PJ_DB_SELECT_1();

            /*" -508- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -510- MOVE 'GE0501B - MAX PARA PEGAR NUMERO DA PESSOA' TO W-LINK-MENSAGEM */
                _.Move("GE0501B - MAX PARA PEGAR NUMERO DA PESSOA", W_LINK_MSG_ERRO.W_LINK_MENSAGEM);

                /*" -511- MOVE SQLCODE TO W-LINK-SQLCODE */
                _.Move(DB.SQLCODE, W_LINK_MSG_ERRO.W_LINK_SQLCODE);

                /*" -512- MOVE WNR-EXEC-SQL TO W-WNR-EXEC-SQL */
                _.Move(AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL, W_LINK_MSG_ERRO.W_WNR_EXEC_SQL);

                /*" -513- MOVE W-LINK-MSG-ERRO TO LINK-MSG-ERRO */
                _.Move(W_LINK_MSG_ERRO, LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                /*" -514- MOVE 'OD_PESSOA  ' TO LINK-NOME-TABELA */
                _.Move("OD_PESSOA  ", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_NOME_TABELA);

                /*" -515- DISPLAY 'GE0501B - ERRO MAX DA OD_PESSOA' */
                _.Display($"GE0501B - ERRO MAX DA OD_PESSOA");

                /*" -517- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA(); //GOTO
                return;
            }


            /*" -519- MOVE HOST-CURRENT-TIMESTAMP TO OD001-DTH-CADASTRAMENTO */
            _.Move(AREA_DE_WORK.HOST_CURRENT_TIMESTAMP, OD001.DCLOD_PESSOA.OD001_DTH_CADASTRAMENTO);

            /*" -520- MOVE 0 TO OD001-NUM-DV-PESSOA */
            _.Move(0, OD001.DCLOD_PESSOA.OD001_NUM_DV_PESSOA);

            /*" -521- MOVE LINK-IND-PESSOA TO OD001-IND-PESSOA */
            _.Move(LINK_PARAMETRO.LINK_IND_PESSOA, OD001.DCLOD_PESSOA.OD001_IND_PESSOA);

            /*" -522- MOVE 'S' TO OD001-STA-INF-INTEGRA */
            _.Move("S", OD001.DCLOD_PESSOA.OD001_STA_INF_INTEGRA);

            /*" -523- MOVE OD001-NUM-PESSOA TO OD003-NUM-PESSOA */
            _.Move(OD001.DCLOD_PESSOA.OD001_NUM_PESSOA, OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_PESSOA);

            /*" -524- MOVE LINK-NUM-CNPJ TO OD003-NUM-CNPJ */
            _.Move(LINK_PARAMETRO.LINK_NUM_CNPJ, OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_CNPJ);

            /*" -525- MOVE LINK-NUM-FILIAL TO OD003-NUM-FILIAL */
            _.Move(LINK_PARAMETRO.LINK_NUM_FILIAL, OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_FILIAL);

            /*" -527- MOVE LINK-NUM-DV-CNPJ TO OD003-NUM-DV-CNPJ */
            _.Move(LINK_PARAMETRO.LINK_NUM_DV_CNPJ, OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_DV_CNPJ);

            /*" -528- MOVE LINK-NUM-DV-PESSOA TO OD001-NUM-DV-PESSOA */
            _.Move(LINK_PARAMETRO.LINK_NUM_DV_PESSOA, OD001.DCLOD_PESSOA.OD001_NUM_DV_PESSOA);

            /*" -529- MOVE LINK-IND-PESSOA TO OD001-IND-PESSOA */
            _.Move(LINK_PARAMETRO.LINK_IND_PESSOA, OD001.DCLOD_PESSOA.OD001_IND_PESSOA);

            /*" -530- MOVE LINK-STA-INF-INTEGRA TO OD001-STA-INF-INTEGRA */
            _.Move(LINK_PARAMETRO.LINK_STA_INF_INTEGRA, OD001.DCLOD_PESSOA.OD001_STA_INF_INTEGRA);

            /*" -532- MOVE LINK-NOM-RAZAO-SOCIAL TO OD003-NOM-RAZAO-SOCIAL-TEXT */
            _.Move(LINK_PARAMETRO.LINK_NOM_RAZAO_SOCIAL, OD003.DCLOD_PESSOA_JURIDICA.OD003_NOM_RAZAO_SOCIAL.OD003_NOM_RAZAO_SOCIAL_TEXT);

            /*" -533- MOVE LINK-NOM-RAZAO-SOCIAL TO W-TABELA-LIKE-NOME */
            _.Move(LINK_PARAMETRO.LINK_NOM_RAZAO_SOCIAL, AREA_DE_WORK.W_TABELA_LIKE_NOME);

            /*" -533- MOVE 200 TO W-IND-NOME OD003-NOM-RAZAO-SOCIAL-LEN. */
            _.Move(200, AREA_DE_WORK.W_IND_NOME, OD003.DCLOD_PESSOA_JURIDICA.OD003_NOM_RAZAO_SOCIAL.OD003_NOM_RAZAO_SOCIAL_LEN);

        }

        [StopWatch]
        /*" R100-INSERT-PJ-DB-SELECT-1 */
        public void R100_INSERT_PJ_DB_SELECT_1()
        {
            /*" -505- EXEC SQL SELECT VALUE(MAX(NUM_PESSOA),0) + 1 INTO :OD001-NUM-PESSOA FROM ODS.OD_PESSOA END-EXEC. */

            var r100_INSERT_PJ_DB_SELECT_1_Query1 = new R100_INSERT_PJ_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R100_INSERT_PJ_DB_SELECT_1_Query1.Execute(r100_INSERT_PJ_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OD001_NUM_PESSOA, OD001.DCLOD_PESSOA.OD001_NUM_PESSOA);
            }


        }

        [StopWatch]
        /*" INICIO-LOOP-NOME */
        private void INICIO_LOOP_NOME(bool isPerform = false)
        {
            /*" -538- IF W-TAB-LIKE-NOME(W-IND-NOME) EQUAL ' ' */

            if (AREA_DE_WORK.W_TABELA_LIKE_NOME.W_TAB_LIKE_NOME[AREA_DE_WORK.W_IND_NOME] == " ")
            {

                /*" -539- COMPUTE W-IND-NOME = W-IND-NOME - 1 */
                AREA_DE_WORK.W_IND_NOME.Value = AREA_DE_WORK.W_IND_NOME - 1;

                /*" -540- IF W-IND-NOME EQUAL 0 */

                if (AREA_DE_WORK.W_IND_NOME == 0)
                {

                    /*" -542- MOVE 'SIENG1S - ERRO LOOP DO TAMANHO DO NOME' TO LINK-MSG-ERRO */
                    _.Move("SIENG1S - ERRO LOOP DO TAMANHO DO NOME", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                    /*" -543- DISPLAY 'WNR - ' WNR-EXEC-SQL ' ' LINK-MSG-ERRO */

                    $"WNR - {AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL} {LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO}"
                    .Display();

                    /*" -544- GO TO R9999-00-CANCELA-PROGRAMA */

                    R9999_00_CANCELA_PROGRAMA(); //GOTO
                    return;

                    /*" -545- ELSE */
                }
                else
                {


                    /*" -546- GO TO INICIO-LOOP-NOME */
                    new Task(() => INICIO_LOOP_NOME()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -547- ELSE */
                }

            }
            else
            {


                /*" -549- COMPUTE W-IND-NOME = W-IND-NOME + 1. */
                AREA_DE_WORK.W_IND_NOME.Value = AREA_DE_WORK.W_IND_NOME + 1;
            }


            /*" -551- MOVE W-IND-NOME TO OD003-NOM-RAZAO-SOCIAL-LEN */
            _.Move(AREA_DE_WORK.W_IND_NOME, OD003.DCLOD_PESSOA_JURIDICA.OD003_NOM_RAZAO_SOCIAL.OD003_NOM_RAZAO_SOCIAL_LEN);

            /*" -552- MOVE LINK-STA-PESSOA TO OD003-STA-PESSOA */
            _.Move(LINK_PARAMETRO.LINK_STA_PESSOA, OD003.DCLOD_PESSOA_JURIDICA.OD003_STA_PESSOA);

            /*" -553- MOVE LINK-NUM-RAMO-ATIVIDADE TO OD003-NUM-RAMO-ATIVIDADE */
            _.Move(LINK_PARAMETRO.LINK_NUM_RAMO_ATIVIDADE, OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_RAMO_ATIVIDADE);

            /*" -554- MOVE LINK-DTH-FUNDACAO TO OD003-DTH-FUNDACAO */
            _.Move(LINK_PARAMETRO.LINK_DTH_FUNDACAO, OD003.DCLOD_PESSOA_JURIDICA.OD003_DTH_FUNDACAO);

            /*" -555- MOVE LINK-NOM-FANTASIA TO OD003-NOM-FANTASIA */
            _.Move(LINK_PARAMETRO.LINK_NOM_FANTASIA, OD003.DCLOD_PESSOA_JURIDICA.OD003_NOM_FANTASIA);

            /*" -556- MOVE LINK-NOM-SIGLA-PESSOA TO OD003-NOM-SIGLA-PESSOA */
            _.Move(LINK_PARAMETRO.LINK_NOM_SIGLA_PESSOA, OD003.DCLOD_PESSOA_JURIDICA.OD003_NOM_SIGLA_PESSOA);

            /*" -557- MOVE LINK-NUM-INSC-ESTADUAL TO OD003-NUM-INSC-ESTADUAL */
            _.Move(LINK_PARAMETRO.LINK_NUM_INSC_ESTADUAL, OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_INSC_ESTADUAL);

            /*" -558- MOVE LINK-NUM-INSC-MUNICIPAL TO OD003-NUM-INSC-MUNICIPAL */
            _.Move(LINK_PARAMETRO.LINK_NUM_INSC_MUNICIPAL, OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_INSC_MUNICIPAL);

            /*" -559- MOVE LINK-COD-UF TO OD003-COD-UF */
            _.Move(LINK_PARAMETRO.LINK_COD_UF, OD003.DCLOD_PESSOA_JURIDICA.OD003_COD_UF);

            /*" -560- MOVE LINK-NUM-MUNICIPIO TO OD003-NUM-MUNICIPIO */
            _.Move(LINK_PARAMETRO.LINK_NUM_MUNICIPIO, OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_MUNICIPIO);

            /*" -561- MOVE LINK-COD-CNAE TO OD003-COD-CNAE */
            _.Move(LINK_PARAMETRO.LINK_COD_CNAE, OD003.DCLOD_PESSOA_JURIDICA.OD003_COD_CNAE);

            /*" -562- MOVE LINK-NUM-SOCIOS TO OD003-NUM-SOCIOS */
            _.Move(LINK_PARAMETRO.LINK_NUM_SOCIOS, OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_SOCIOS);

            /*" -563- MOVE LINK-STA-FRANQUIA TO OD003-STA-FRANQUIA */
            _.Move(LINK_PARAMETRO.LINK_STA_FRANQUIA, OD003.DCLOD_PESSOA_JURIDICA.OD003_STA_FRANQUIA);

            /*" -569- MOVE LINK-IND-FINALIDADE TO OD003-IND-FINALIDADE . */
            _.Move(LINK_PARAMETRO.LINK_IND_FINALIDADE, OD003.DCLOD_PESSOA_JURIDICA.OD003_IND_FINALIDADE);

            /*" -570- IF OD003-NUM-RAMO-ATIVIDADE EQUAL ZEROS */

            if (OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_RAMO_ATIVIDADE == 00)
            {

                /*" -571- MOVE -1 TO IND-NULL-01 */
                _.Move(-1, AREA_DE_WORK.IND_NULL_01);

                /*" -572- ELSE */
            }
            else
            {


                /*" -574- MOVE ZEROS TO IND-NULL-01. */
                _.Move(0, AREA_DE_WORK.IND_NULL_01);
            }


            /*" -575- IF OD003-NUM-INSC-ESTADUAL EQUAL ZEROS */

            if (OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_INSC_ESTADUAL == 00)
            {

                /*" -576- MOVE -1 TO IND-NULL-05 */
                _.Move(-1, AREA_DE_WORK.IND_NULL_05);

                /*" -577- ELSE */
            }
            else
            {


                /*" -579- MOVE ZEROS TO IND-NULL-05. */
                _.Move(0, AREA_DE_WORK.IND_NULL_05);
            }


            /*" -580- IF OD003-NUM-INSC-MUNICIPAL EQUAL ZEROS */

            if (OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_INSC_MUNICIPAL == 00)
            {

                /*" -581- MOVE -1 TO IND-NULL-06 */
                _.Move(-1, AREA_DE_WORK.IND_NULL_06);

                /*" -582- ELSE */
            }
            else
            {


                /*" -584- MOVE ZEROS TO IND-NULL-06. */
                _.Move(0, AREA_DE_WORK.IND_NULL_06);
            }


            /*" -585- IF OD003-NUM-MUNICIPIO EQUAL ZEROS */

            if (OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_MUNICIPIO == 00)
            {

                /*" -586- MOVE -1 TO IND-NULL-08 */
                _.Move(-1, AREA_DE_WORK.IND_NULL_08);

                /*" -587- ELSE */
            }
            else
            {


                /*" -589- MOVE ZEROS TO IND-NULL-08. */
                _.Move(0, AREA_DE_WORK.IND_NULL_08);
            }


            /*" -590- IF OD003-NUM-SOCIOS EQUAL ZEROS */

            if (OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_SOCIOS == 00)
            {

                /*" -591- MOVE -1 TO IND-NULL-10 */
                _.Move(-1, AREA_DE_WORK.IND_NULL_10);

                /*" -592- ELSE */
            }
            else
            {


                /*" -594- MOVE ZEROS TO IND-NULL-10. */
                _.Move(0, AREA_DE_WORK.IND_NULL_10);
            }


            /*" -595- IF OD003-DTH-FUNDACAO EQUAL SPACES */

            if (OD003.DCLOD_PESSOA_JURIDICA.OD003_DTH_FUNDACAO.IsEmpty())
            {

                /*" -596- MOVE -1 TO IND-NULL-02 */
                _.Move(-1, AREA_DE_WORK.IND_NULL_02);

                /*" -597- ELSE */
            }
            else
            {


                /*" -599- MOVE ZEROS TO IND-NULL-02. */
                _.Move(0, AREA_DE_WORK.IND_NULL_02);
            }


            /*" -600- IF OD003-NOM-FANTASIA EQUAL SPACES */

            if (OD003.DCLOD_PESSOA_JURIDICA.OD003_NOM_FANTASIA.IsEmpty())
            {

                /*" -601- MOVE -1 TO IND-NULL-03 */
                _.Move(-1, AREA_DE_WORK.IND_NULL_03);

                /*" -602- ELSE */
            }
            else
            {


                /*" -604- MOVE ZEROS TO IND-NULL-03. */
                _.Move(0, AREA_DE_WORK.IND_NULL_03);
            }


            /*" -605- IF OD003-NOM-SIGLA-PESSOA EQUAL SPACES */

            if (OD003.DCLOD_PESSOA_JURIDICA.OD003_NOM_SIGLA_PESSOA.IsEmpty())
            {

                /*" -606- MOVE -1 TO IND-NULL-04 */
                _.Move(-1, AREA_DE_WORK.IND_NULL_04);

                /*" -607- ELSE */
            }
            else
            {


                /*" -609- MOVE ZEROS TO IND-NULL-04. */
                _.Move(0, AREA_DE_WORK.IND_NULL_04);
            }


            /*" -610- IF OD003-COD-UF EQUAL SPACES */

            if (OD003.DCLOD_PESSOA_JURIDICA.OD003_COD_UF.IsEmpty())
            {

                /*" -611- MOVE -1 TO IND-NULL-07 */
                _.Move(-1, AREA_DE_WORK.IND_NULL_07);

                /*" -612- ELSE */
            }
            else
            {


                /*" -614- MOVE ZEROS TO IND-NULL-07. */
                _.Move(0, AREA_DE_WORK.IND_NULL_07);
            }


            /*" -615- IF OD003-COD-CNAE EQUAL SPACES */

            if (OD003.DCLOD_PESSOA_JURIDICA.OD003_COD_CNAE.IsEmpty())
            {

                /*" -616- MOVE -1 TO IND-NULL-09 */
                _.Move(-1, AREA_DE_WORK.IND_NULL_09);

                /*" -617- ELSE */
            }
            else
            {


                /*" -619- MOVE ZEROS TO IND-NULL-09. */
                _.Move(0, AREA_DE_WORK.IND_NULL_09);
            }


            /*" -620- IF OD003-STA-FRANQUIA EQUAL SPACES */

            if (OD003.DCLOD_PESSOA_JURIDICA.OD003_STA_FRANQUIA.IsEmpty())
            {

                /*" -621- MOVE -1 TO IND-NULL-11 */
                _.Move(-1, AREA_DE_WORK.IND_NULL_11);

                /*" -622- ELSE */
            }
            else
            {


                /*" -624- MOVE ZEROS TO IND-NULL-11. */
                _.Move(0, AREA_DE_WORK.IND_NULL_11);
            }


            /*" -625- IF OD003-IND-FINALIDADE EQUAL SPACES */

            if (OD003.DCLOD_PESSOA_JURIDICA.OD003_IND_FINALIDADE.IsEmpty())
            {

                /*" -626- MOVE -1 TO IND-NULL-12 */
                _.Move(-1, AREA_DE_WORK.IND_NULL_12);

                /*" -627- ELSE */
            }
            else
            {


                /*" -633- MOVE ZEROS TO IND-NULL-12. */
                _.Move(0, AREA_DE_WORK.IND_NULL_12);
            }


            /*" -635- MOVE '0006' TO WNR-EXEC-SQL */
            _.Move("0006", AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL);

            /*" -646- PERFORM INICIO_LOOP_NOME_DB_INSERT_1 */

            INICIO_LOOP_NOME_DB_INSERT_1();

            /*" -649- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -651- MOVE 'GE0501B - ERRO INSERT OD_PESSOA' TO W-LINK-MENSAGEM */
                _.Move("GE0501B - ERRO INSERT OD_PESSOA", W_LINK_MSG_ERRO.W_LINK_MENSAGEM);

                /*" -652- MOVE SQLCODE TO W-LINK-SQLCODE */
                _.Move(DB.SQLCODE, W_LINK_MSG_ERRO.W_LINK_SQLCODE);

                /*" -653- MOVE WNR-EXEC-SQL TO W-WNR-EXEC-SQL */
                _.Move(AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL, W_LINK_MSG_ERRO.W_WNR_EXEC_SQL);

                /*" -654- MOVE W-LINK-MSG-ERRO TO LINK-MSG-ERRO */
                _.Move(W_LINK_MSG_ERRO, LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                /*" -655- MOVE 'OD_PESSOA  ' TO LINK-NOME-TABELA */
                _.Move("OD_PESSOA  ", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_NOME_TABELA);

                /*" -657- DISPLAY 'GE0501B - ERRO INSERT OD_PESSOA SQLCODE ' W-LINK-SQLCODE */
                _.Display($"GE0501B - ERRO INSERT OD_PESSOA SQLCODE {W_LINK_MSG_ERRO.W_LINK_SQLCODE}");

                /*" -659- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA(); //GOTO
                return;
            }


            /*" -661- MOVE OD001-NUM-PESSOA TO LINK-NUM-PESSOA. */
            _.Move(OD001.DCLOD_PESSOA.OD001_NUM_PESSOA, LINK_PARAMETRO.LINK_NUM_PESSOA);

            /*" -663- MOVE '0006' TO WNR-EXEC-SQL */
            _.Move("0006", AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL);

            /*" -700- PERFORM INICIO_LOOP_NOME_DB_INSERT_2 */

            INICIO_LOOP_NOME_DB_INSERT_2();

            /*" -703- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -705- MOVE 'GE0501B - ERRO INSERT OD_PESSOA_JURIDICA' TO W-LINK-MENSAGEM */
                _.Move("GE0501B - ERRO INSERT OD_PESSOA_JURIDICA", W_LINK_MSG_ERRO.W_LINK_MENSAGEM);

                /*" -706- MOVE SQLCODE TO W-LINK-SQLCODE */
                _.Move(DB.SQLCODE, W_LINK_MSG_ERRO.W_LINK_SQLCODE);

                /*" -707- MOVE WNR-EXEC-SQL TO W-WNR-EXEC-SQL */
                _.Move(AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL, W_LINK_MSG_ERRO.W_WNR_EXEC_SQL);

                /*" -708- MOVE W-LINK-MSG-ERRO TO LINK-MSG-ERRO */
                _.Move(W_LINK_MSG_ERRO, LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                /*" -709- MOVE 'OD_PESSOA_JURIDICA' TO LINK-NOME-TABELA */
                _.Move("OD_PESSOA_JURIDICA", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_NOME_TABELA);

                /*" -711- DISPLAY 'GE0501B - ERRO INSERT OD_PESSOA_JURIDIC SQLCODE ' W-LINK-SQLCODE */
                _.Display($"GE0501B - ERRO INSERT OD_PESSOA_JURIDIC SQLCODE {W_LINK_MSG_ERRO.W_LINK_SQLCODE}");

                /*" -712- PERFORM R1000-DISPLAY-INSERT THRU R1000-EXIT */

                R1000_DISPLAY_INSERT(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_EXIT*/


                /*" -712- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" INICIO-LOOP-NOME-DB-INSERT-1 */
        public void INICIO_LOOP_NOME_DB_INSERT_1()
        {
            /*" -646- EXEC SQL INSERT INTO ODS.OD_PESSOA (NUM_PESSOA , DTH_CADASTRAMENTO , NUM_DV_PESSOA , IND_PESSOA , STA_INF_INTEGRA) VALUES (:OD001-NUM-PESSOA , :OD001-DTH-CADASTRAMENTO , :OD001-NUM-DV-PESSOA , :OD001-IND-PESSOA , :OD001-STA-INF-INTEGRA) END-EXEC. */

            var iNICIO_LOOP_NOME_DB_INSERT_1_Insert1 = new INICIO_LOOP_NOME_DB_INSERT_1_Insert1()
            {
                OD001_NUM_PESSOA = OD001.DCLOD_PESSOA.OD001_NUM_PESSOA.ToString(),
                OD001_DTH_CADASTRAMENTO = OD001.DCLOD_PESSOA.OD001_DTH_CADASTRAMENTO.ToString(),
                OD001_NUM_DV_PESSOA = OD001.DCLOD_PESSOA.OD001_NUM_DV_PESSOA.ToString(),
                OD001_IND_PESSOA = OD001.DCLOD_PESSOA.OD001_IND_PESSOA.ToString(),
                OD001_STA_INF_INTEGRA = OD001.DCLOD_PESSOA.OD001_STA_INF_INTEGRA.ToString(),
            };

            INICIO_LOOP_NOME_DB_INSERT_1_Insert1.Execute(iNICIO_LOOP_NOME_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/

        [StopWatch]
        /*" INICIO-LOOP-NOME-DB-INSERT-2 */
        public void INICIO_LOOP_NOME_DB_INSERT_2()
        {
            /*" -700- EXEC SQL INSERT INTO ODS.OD_PESSOA_JURIDICA (NUM_PESSOA , NUM_CNPJ , NUM_FILIAL , NUM_DV_CNPJ , NOM_RAZAO_SOCIAL , STA_PESSOA , NUM_RAMO_ATIVIDADE, DTH_FUNDACAO , NOM_FANTASIA , NOM_SIGLA_PESSOA , NUM_INSC_ESTADUAL , NUM_INSC_MUNICIPAL, COD_UF , NUM_MUNICIPIO , COD_CNAE , NUM_SOCIOS , STA_FRANQUIA , IND_FINALIDADE ) VALUES (:OD003-NUM-PESSOA , :OD003-NUM-CNPJ , :OD003-NUM-FILIAL , :OD003-NUM-DV-CNPJ , :OD003-NOM-RAZAO-SOCIAL, :OD003-STA-PESSOA , :OD003-NUM-RAMO-ATIVIDADE:IND-NULL-01, :OD003-DTH-FUNDACAO:IND-NULL-02, :OD003-NOM-FANTASIA:IND-NULL-03, :OD003-NOM-SIGLA-PESSOA:IND-NULL-04, :OD003-NUM-INSC-ESTADUAL:IND-NULL-05, :OD003-NUM-INSC-MUNICIPAL:IND-NULL-06, :OD003-COD-UF:IND-NULL-07, :OD003-NUM-MUNICIPIO:IND-NULL-08, :OD003-COD-CNAE:IND-NULL-09, :OD003-NUM-SOCIOS:IND-NULL-10, :OD003-STA-FRANQUIA:IND-NULL-11, :OD003-IND-FINALIDADE:IND-NULL-12) END-EXEC. */

            var iNICIO_LOOP_NOME_DB_INSERT_2_Insert1 = new INICIO_LOOP_NOME_DB_INSERT_2_Insert1()
            {
                OD003_NUM_PESSOA = OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_PESSOA.ToString(),
                OD003_NUM_CNPJ = OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_CNPJ.ToString(),
                OD003_NUM_FILIAL = OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_FILIAL.ToString(),
                OD003_NUM_DV_CNPJ = OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_DV_CNPJ.ToString(),
                OD003_NOM_RAZAO_SOCIAL = OD003.DCLOD_PESSOA_JURIDICA.OD003_NOM_RAZAO_SOCIAL.ToString(),
                OD003_STA_PESSOA = OD003.DCLOD_PESSOA_JURIDICA.OD003_STA_PESSOA.ToString(),
                OD003_NUM_RAMO_ATIVIDADE = OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_RAMO_ATIVIDADE.ToString(),
                IND_NULL_01 = AREA_DE_WORK.IND_NULL_01.ToString(),
                OD003_DTH_FUNDACAO = OD003.DCLOD_PESSOA_JURIDICA.OD003_DTH_FUNDACAO.ToString(),
                IND_NULL_02 = AREA_DE_WORK.IND_NULL_02.ToString(),
                OD003_NOM_FANTASIA = OD003.DCLOD_PESSOA_JURIDICA.OD003_NOM_FANTASIA.ToString(),
                IND_NULL_03 = AREA_DE_WORK.IND_NULL_03.ToString(),
                OD003_NOM_SIGLA_PESSOA = OD003.DCLOD_PESSOA_JURIDICA.OD003_NOM_SIGLA_PESSOA.ToString(),
                IND_NULL_04 = AREA_DE_WORK.IND_NULL_04.ToString(),
                OD003_NUM_INSC_ESTADUAL = OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_INSC_ESTADUAL.ToString(),
                IND_NULL_05 = AREA_DE_WORK.IND_NULL_05.ToString(),
                OD003_NUM_INSC_MUNICIPAL = OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_INSC_MUNICIPAL.ToString(),
                IND_NULL_06 = AREA_DE_WORK.IND_NULL_06.ToString(),
                OD003_COD_UF = OD003.DCLOD_PESSOA_JURIDICA.OD003_COD_UF.ToString(),
                IND_NULL_07 = AREA_DE_WORK.IND_NULL_07.ToString(),
                OD003_NUM_MUNICIPIO = OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_MUNICIPIO.ToString(),
                IND_NULL_08 = AREA_DE_WORK.IND_NULL_08.ToString(),
                OD003_COD_CNAE = OD003.DCLOD_PESSOA_JURIDICA.OD003_COD_CNAE.ToString(),
                IND_NULL_09 = AREA_DE_WORK.IND_NULL_09.ToString(),
                OD003_NUM_SOCIOS = OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_SOCIOS.ToString(),
                IND_NULL_10 = AREA_DE_WORK.IND_NULL_10.ToString(),
                OD003_STA_FRANQUIA = OD003.DCLOD_PESSOA_JURIDICA.OD003_STA_FRANQUIA.ToString(),
                IND_NULL_11 = AREA_DE_WORK.IND_NULL_11.ToString(),
                OD003_IND_FINALIDADE = OD003.DCLOD_PESSOA_JURIDICA.OD003_IND_FINALIDADE.ToString(),
                IND_NULL_12 = AREA_DE_WORK.IND_NULL_12.ToString(),
            };

            INICIO_LOOP_NOME_DB_INSERT_2_Insert1.Execute(iNICIO_LOOP_NOME_DB_INSERT_2_Insert1);

        }

        [StopWatch]
        /*" R300-CONSULTA-PJ */
        private void R300_CONSULTA_PJ(bool isPerform = false)
        {
            /*" -723- MOVE '0006' TO WNR-EXEC-SQL. */
            _.Move("0006", AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL);

            /*" -725- MOVE SPACES TO WFIM-MOVIMENTO. */
            _.Move("", AREA_DE_WORK.WFIM_MOVIMENTO);

            /*" -727- PERFORM R310-00-DECLARE-PJURIDICA THRU R310-EXIT. */

            R310_00_DECLARE_PJURIDICA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R310_EXIT*/


            /*" -728- PERFORM R320-00-FETCH-PJURIDICA THRU R320-EXIT UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_MOVIMENTO.IsEmpty()))
            {

                R320_00_FETCH_PJURIDICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R320_EXIT*/

            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R300_EXIT*/

        [StopWatch]
        /*" R310-00-DECLARE-PJURIDICA */
        private void R310_00_DECLARE_PJURIDICA(bool isPerform = false)
        {
            /*" -737- INITIALIZE DCLOD-PESSOA DCLOD-PESSOA-JURIDICA. */
            _.Initialize(
                OD001.DCLOD_PESSOA
                , OD003.DCLOD_PESSOA_JURIDICA
            );

            /*" -738- MOVE 'N' TO WTEM-PESSOA. */
            _.Move("N", AREA_DE_WORK.WTEM_PESSOA);

            /*" -739- MOVE LINK-NUM-CNPJ TO OD003-NUM-CNPJ. */
            _.Move(LINK_PARAMETRO.LINK_NUM_CNPJ, OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_CNPJ);

            /*" -740- MOVE LINK-NUM-FILIAL TO OD003-NUM-FILIAL. */
            _.Move(LINK_PARAMETRO.LINK_NUM_FILIAL, OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_FILIAL);

            /*" -742- MOVE LINK-NUM-DV-CNPJ TO OD003-NUM-DV-CNPJ. */
            _.Move(LINK_PARAMETRO.LINK_NUM_DV_CNPJ, OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_DV_CNPJ);

            /*" -774- PERFORM R310_00_DECLARE_PJURIDICA_DB_DECLARE_1 */

            R310_00_DECLARE_PJURIDICA_DB_DECLARE_1();

            /*" -776- PERFORM R310_00_DECLARE_PJURIDICA_DB_OPEN_1 */

            R310_00_DECLARE_PJURIDICA_DB_OPEN_1();

            /*" -779- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -780- MOVE 'N' TO WTEM-PESSOA */
                _.Move("N", AREA_DE_WORK.WTEM_PESSOA);

                /*" -780- MOVE 'S' TO WFIM-MOVIMENTO. */
                _.Move("S", AREA_DE_WORK.WFIM_MOVIMENTO);
            }


        }

        [StopWatch]
        /*" R310-00-DECLARE-PJURIDICA-DB-DECLARE-1 */
        public void R310_00_DECLARE_PJURIDICA_DB_DECLARE_1()
        {
            /*" -774- EXEC SQL DECLARE V0PJURIDICA CURSOR WITH HOLD FOR SELECT A.NUM_PESSOA , A.DTH_CADASTRAMENTO , A.NUM_DV_PESSOA , A.IND_PESSOA , A.STA_INF_INTEGRA , B.NUM_PESSOA , B.NUM_CNPJ , B.NUM_FILIAL , B.NUM_DV_CNPJ , B.NOM_RAZAO_SOCIAL , B.STA_PESSOA , B.NUM_RAMO_ATIVIDADE , B.DTH_FUNDACAO , B.NOM_FANTASIA , B.NOM_SIGLA_PESSOA , B.NUM_INSC_ESTADUAL , B.NUM_INSC_MUNICIPAL , B.COD_UF , B.NUM_MUNICIPIO , B.COD_CNAE , B.NUM_SOCIOS , B.STA_FRANQUIA , B.IND_FINALIDADE FROM ODS.OD_PESSOA A , ODS.OD_PESSOA_JURIDICA B WHERE B.NUM_CNPJ = :OD003-NUM-CNPJ AND B.NUM_FILIAL = :OD003-NUM-FILIAL AND B.NUM_DV_CNPJ = :OD003-NUM-DV-CNPJ AND B.NUM_PESSOA = A.NUM_PESSOA ORDER BY A.NUM_PESSOA DESC END-EXEC. */
            V0PJURIDICA = new GE0501B_V0PJURIDICA(true);
            string GetQuery_V0PJURIDICA()
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
							B.NUM_PESSOA
							, 
							B.NUM_CNPJ
							, 
							B.NUM_FILIAL
							, 
							B.NUM_DV_CNPJ
							, 
							B.NOM_RAZAO_SOCIAL
							, 
							B.STA_PESSOA
							, 
							B.NUM_RAMO_ATIVIDADE
							, 
							B.DTH_FUNDACAO
							, 
							B.NOM_FANTASIA
							, 
							B.NOM_SIGLA_PESSOA
							, 
							B.NUM_INSC_ESTADUAL
							, 
							B.NUM_INSC_MUNICIPAL
							, 
							B.COD_UF
							, 
							B.NUM_MUNICIPIO
							, 
							B.COD_CNAE
							, 
							B.NUM_SOCIOS
							, 
							B.STA_FRANQUIA
							, 
							B.IND_FINALIDADE 
							FROM ODS.OD_PESSOA A
							, 
							ODS.OD_PESSOA_JURIDICA B 
							WHERE B.NUM_CNPJ = '{OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_CNPJ}' 
							AND B.NUM_FILIAL = '{OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_FILIAL}' 
							AND B.NUM_DV_CNPJ = '{OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_DV_CNPJ}' 
							AND B.NUM_PESSOA = A.NUM_PESSOA 
							ORDER BY A.NUM_PESSOA DESC";

                return query;
            }
            V0PJURIDICA.GetQueryEvent += GetQuery_V0PJURIDICA;

        }

        [StopWatch]
        /*" R310-00-DECLARE-PJURIDICA-DB-OPEN-1 */
        public void R310_00_DECLARE_PJURIDICA_DB_OPEN_1()
        {
            /*" -776- EXEC SQL OPEN V0PJURIDICA END-EXEC. */

            V0PJURIDICA.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R310_EXIT*/

        [StopWatch]
        /*" R320-00-FETCH-PJURIDICA */
        private void R320_00_FETCH_PJURIDICA(bool isPerform = false)
        {
            /*" -811- PERFORM R320_00_FETCH_PJURIDICA_DB_FETCH_1 */

            R320_00_FETCH_PJURIDICA_DB_FETCH_1();

            /*" -814- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -814- PERFORM R320_00_FETCH_PJURIDICA_DB_CLOSE_1 */

                R320_00_FETCH_PJURIDICA_DB_CLOSE_1();

                /*" -816- MOVE 'S' TO WFIM-MOVIMENTO */
                _.Move("S", AREA_DE_WORK.WFIM_MOVIMENTO);

                /*" -817- MOVE 'N' TO WTEM-PESSOA */
                _.Move("N", AREA_DE_WORK.WTEM_PESSOA);

                /*" -819- GO TO R320-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R320_EXIT*/ //GOTO
                return;
            }


            /*" -820- MOVE SPACES TO AUX-NOM-RAZAO-SOCIAL. */
            _.Move("", AREA_DE_WORK.AUX_NOM_RAZAO_SOCIAL);

            /*" -823- MOVE OD003-NOM-RAZAO-SOCIAL-TEXT TO AUX-NOM-RAZAO-SOCIAL. */
            _.Move(OD003.DCLOD_PESSOA_JURIDICA.OD003_NOM_RAZAO_SOCIAL.OD003_NOM_RAZAO_SOCIAL_TEXT, AREA_DE_WORK.AUX_NOM_RAZAO_SOCIAL);

            /*" -824- IF AUX-NOM-RAZAO-SOCIAL NOT EQUAL LINK-NOM-RAZAO-SOCIAL */

            if (AREA_DE_WORK.AUX_NOM_RAZAO_SOCIAL != LINK_PARAMETRO.LINK_NOM_RAZAO_SOCIAL)
            {

                /*" -825- MOVE 'N' TO WTEM-PESSOA */
                _.Move("N", AREA_DE_WORK.WTEM_PESSOA);

                /*" -828- GO TO R320-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R320_EXIT*/ //GOTO
                return;
            }


            /*" -828- PERFORM R320_00_FETCH_PJURIDICA_DB_CLOSE_2 */

            R320_00_FETCH_PJURIDICA_DB_CLOSE_2();

            /*" -830- MOVE 'S' TO WFIM-MOVIMENTO. */
            _.Move("S", AREA_DE_WORK.WFIM_MOVIMENTO);

            /*" -832- MOVE 'S' TO WTEM-PESSOA. */
            _.Move("S", AREA_DE_WORK.WTEM_PESSOA);

            /*" -833- IF IND-NULL-01 LESS ZEROS */

            if (AREA_DE_WORK.IND_NULL_01 < 00)
            {

                /*" -835- MOVE ZEROS TO OD003-NUM-RAMO-ATIVIDADE. */
                _.Move(0, OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_RAMO_ATIVIDADE);
            }


            /*" -836- IF IND-NULL-05 LESS ZEROS */

            if (AREA_DE_WORK.IND_NULL_05 < 00)
            {

                /*" -838- MOVE ZEROS TO OD003-NUM-INSC-ESTADUAL. */
                _.Move(0, OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_INSC_ESTADUAL);
            }


            /*" -839- IF IND-NULL-06 LESS ZEROS */

            if (AREA_DE_WORK.IND_NULL_06 < 00)
            {

                /*" -841- MOVE ZEROS TO OD003-NUM-INSC-MUNICIPAL. */
                _.Move(0, OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_INSC_MUNICIPAL);
            }


            /*" -842- IF IND-NULL-08 LESS ZEROS */

            if (AREA_DE_WORK.IND_NULL_08 < 00)
            {

                /*" -844- MOVE ZEROS TO OD003-NUM-MUNICIPIO. */
                _.Move(0, OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_MUNICIPIO);
            }


            /*" -845- IF IND-NULL-10 LESS ZEROS */

            if (AREA_DE_WORK.IND_NULL_10 < 00)
            {

                /*" -848- MOVE ZEROS TO OD003-NUM-SOCIOS. */
                _.Move(0, OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_SOCIOS);
            }


            /*" -849- IF IND-NULL-02 LESS ZEROS */

            if (AREA_DE_WORK.IND_NULL_02 < 00)
            {

                /*" -851- MOVE SPACES TO OD003-DTH-FUNDACAO. */
                _.Move("", OD003.DCLOD_PESSOA_JURIDICA.OD003_DTH_FUNDACAO);
            }


            /*" -852- IF IND-NULL-03 LESS ZEROS */

            if (AREA_DE_WORK.IND_NULL_03 < 00)
            {

                /*" -854- MOVE SPACES TO OD003-NOM-FANTASIA. */
                _.Move("", OD003.DCLOD_PESSOA_JURIDICA.OD003_NOM_FANTASIA);
            }


            /*" -855- IF IND-NULL-04 LESS ZEROS */

            if (AREA_DE_WORK.IND_NULL_04 < 00)
            {

                /*" -857- MOVE SPACES TO OD003-NOM-SIGLA-PESSOA. */
                _.Move("", OD003.DCLOD_PESSOA_JURIDICA.OD003_NOM_SIGLA_PESSOA);
            }


            /*" -858- IF IND-NULL-07 LESS ZEROS */

            if (AREA_DE_WORK.IND_NULL_07 < 00)
            {

                /*" -860- MOVE SPACES TO OD003-COD-UF. */
                _.Move("", OD003.DCLOD_PESSOA_JURIDICA.OD003_COD_UF);
            }


            /*" -861- IF IND-NULL-09 LESS ZEROS */

            if (AREA_DE_WORK.IND_NULL_09 < 00)
            {

                /*" -863- MOVE SPACES TO OD003-COD-CNAE. */
                _.Move("", OD003.DCLOD_PESSOA_JURIDICA.OD003_COD_CNAE);
            }


            /*" -864- IF IND-NULL-11 LESS ZEROS */

            if (AREA_DE_WORK.IND_NULL_11 < 00)
            {

                /*" -866- MOVE SPACES TO OD003-STA-FRANQUIA. */
                _.Move("", OD003.DCLOD_PESSOA_JURIDICA.OD003_STA_FRANQUIA);
            }


            /*" -867- IF IND-NULL-12 LESS ZEROS */

            if (AREA_DE_WORK.IND_NULL_12 < 00)
            {

                /*" -870- MOVE SPACES TO OD003-IND-FINALIDADE. */
                _.Move("", OD003.DCLOD_PESSOA_JURIDICA.OD003_IND_FINALIDADE);
            }


            /*" -871- MOVE OD001-NUM-PESSOA TO LINK-NUM-PESSOA */
            _.Move(OD001.DCLOD_PESSOA.OD001_NUM_PESSOA, LINK_PARAMETRO.LINK_NUM_PESSOA);

            /*" -872- MOVE OD001-DTH-CADASTRAMENTO TO LINK-DTH-CADASTRAMENTO */
            _.Move(OD001.DCLOD_PESSOA.OD001_DTH_CADASTRAMENTO, LINK_PARAMETRO.LINK_DTH_CADASTRAMENTO);

            /*" -873- MOVE OD001-NUM-DV-PESSOA TO LINK-NUM-DV-PESSOA */
            _.Move(OD001.DCLOD_PESSOA.OD001_NUM_DV_PESSOA, LINK_PARAMETRO.LINK_NUM_DV_PESSOA);

            /*" -874- MOVE OD001-IND-PESSOA TO LINK-IND-PESSOA */
            _.Move(OD001.DCLOD_PESSOA.OD001_IND_PESSOA, LINK_PARAMETRO.LINK_IND_PESSOA);

            /*" -875- MOVE OD001-STA-INF-INTEGRA TO LINK-STA-INF-INTEGRA */
            _.Move(OD001.DCLOD_PESSOA.OD001_STA_INF_INTEGRA, LINK_PARAMETRO.LINK_STA_INF_INTEGRA);

            /*" -876- MOVE OD003-NUM-CNPJ TO LINK-NUM-CNPJ */
            _.Move(OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_CNPJ, LINK_PARAMETRO.LINK_NUM_CNPJ);

            /*" -877- MOVE OD003-NUM-FILIAL TO LINK-NUM-FILIAL */
            _.Move(OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_FILIAL, LINK_PARAMETRO.LINK_NUM_FILIAL);

            /*" -878- MOVE OD003-NUM-DV-CNPJ TO LINK-NUM-DV-CNPJ */
            _.Move(OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_DV_CNPJ, LINK_PARAMETRO.LINK_NUM_DV_CNPJ);

            /*" -879- MOVE OD003-STA-PESSOA TO LINK-STA-PESSOA */
            _.Move(OD003.DCLOD_PESSOA_JURIDICA.OD003_STA_PESSOA, LINK_PARAMETRO.LINK_STA_PESSOA);

            /*" -880- MOVE OD003-NUM-RAMO-ATIVIDADE TO LINK-NUM-RAMO-ATIVIDADE */
            _.Move(OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_RAMO_ATIVIDADE, LINK_PARAMETRO.LINK_NUM_RAMO_ATIVIDADE);

            /*" -881- MOVE OD003-DTH-FUNDACAO TO LINK-DTH-FUNDACAO */
            _.Move(OD003.DCLOD_PESSOA_JURIDICA.OD003_DTH_FUNDACAO, LINK_PARAMETRO.LINK_DTH_FUNDACAO);

            /*" -882- MOVE OD003-NOM-FANTASIA TO LINK-NOM-FANTASIA */
            _.Move(OD003.DCLOD_PESSOA_JURIDICA.OD003_NOM_FANTASIA, LINK_PARAMETRO.LINK_NOM_FANTASIA);

            /*" -883- MOVE OD003-NOM-SIGLA-PESSOA TO LINK-NOM-SIGLA-PESSOA */
            _.Move(OD003.DCLOD_PESSOA_JURIDICA.OD003_NOM_SIGLA_PESSOA, LINK_PARAMETRO.LINK_NOM_SIGLA_PESSOA);

            /*" -884- MOVE OD003-NUM-INSC-ESTADUAL TO LINK-NUM-INSC-ESTADUAL */
            _.Move(OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_INSC_ESTADUAL, LINK_PARAMETRO.LINK_NUM_INSC_ESTADUAL);

            /*" -885- MOVE OD003-NUM-INSC-MUNICIPAL TO LINK-NUM-INSC-MUNICIPAL */
            _.Move(OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_INSC_MUNICIPAL, LINK_PARAMETRO.LINK_NUM_INSC_MUNICIPAL);

            /*" -886- MOVE OD003-COD-UF TO LINK-COD-UF */
            _.Move(OD003.DCLOD_PESSOA_JURIDICA.OD003_COD_UF, LINK_PARAMETRO.LINK_COD_UF);

            /*" -887- MOVE OD003-NUM-MUNICIPIO TO LINK-NUM-MUNICIPIO */
            _.Move(OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_MUNICIPIO, LINK_PARAMETRO.LINK_NUM_MUNICIPIO);

            /*" -888- MOVE OD003-COD-CNAE TO LINK-COD-CNAE */
            _.Move(OD003.DCLOD_PESSOA_JURIDICA.OD003_COD_CNAE, LINK_PARAMETRO.LINK_COD_CNAE);

            /*" -889- MOVE OD003-NUM-SOCIOS TO LINK-NUM-SOCIOS */
            _.Move(OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_SOCIOS, LINK_PARAMETRO.LINK_NUM_SOCIOS);

            /*" -890- MOVE OD003-STA-FRANQUIA TO LINK-STA-FRANQUIA */
            _.Move(OD003.DCLOD_PESSOA_JURIDICA.OD003_STA_FRANQUIA, LINK_PARAMETRO.LINK_STA_FRANQUIA);

            /*" -890- MOVE OD003-IND-FINALIDADE TO LINK-IND-FINALIDADE. */
            _.Move(OD003.DCLOD_PESSOA_JURIDICA.OD003_IND_FINALIDADE, LINK_PARAMETRO.LINK_IND_FINALIDADE);

        }

        [StopWatch]
        /*" R320-00-FETCH-PJURIDICA-DB-FETCH-1 */
        public void R320_00_FETCH_PJURIDICA_DB_FETCH_1()
        {
            /*" -811- EXEC SQL FETCH V0PJURIDICA INTO :OD001-NUM-PESSOA , :OD001-DTH-CADASTRAMENTO , :OD001-NUM-DV-PESSOA , :OD001-IND-PESSOA , :OD001-STA-INF-INTEGRA , :OD003-NUM-PESSOA , :OD003-NUM-CNPJ , :OD003-NUM-FILIAL , :OD003-NUM-DV-CNPJ , :OD003-NOM-RAZAO-SOCIAL , :OD003-STA-PESSOA , :OD003-NUM-RAMO-ATIVIDADE:IND-NULL-01 , :OD003-DTH-FUNDACAO:IND-NULL-02 , :OD003-NOM-FANTASIA:IND-NULL-03 , :OD003-NOM-SIGLA-PESSOA:IND-NULL-04 , :OD003-NUM-INSC-ESTADUAL:IND-NULL-05 , :OD003-NUM-INSC-MUNICIPAL:IND-NULL-06 , :OD003-COD-UF:IND-NULL-07 , :OD003-NUM-MUNICIPIO:IND-NULL-08 , :OD003-COD-CNAE:IND-NULL-09 , :OD003-NUM-SOCIOS:IND-NULL-10 , :OD003-STA-FRANQUIA:IND-NULL-11 , :OD003-IND-FINALIDADE:IND-NULL-12 END-EXEC. */

            if (V0PJURIDICA.Fetch())
            {
                _.Move(V0PJURIDICA.OD001_NUM_PESSOA, OD001.DCLOD_PESSOA.OD001_NUM_PESSOA);
                _.Move(V0PJURIDICA.OD001_DTH_CADASTRAMENTO, OD001.DCLOD_PESSOA.OD001_DTH_CADASTRAMENTO);
                _.Move(V0PJURIDICA.OD001_NUM_DV_PESSOA, OD001.DCLOD_PESSOA.OD001_NUM_DV_PESSOA);
                _.Move(V0PJURIDICA.OD001_IND_PESSOA, OD001.DCLOD_PESSOA.OD001_IND_PESSOA);
                _.Move(V0PJURIDICA.OD001_STA_INF_INTEGRA, OD001.DCLOD_PESSOA.OD001_STA_INF_INTEGRA);
                _.Move(V0PJURIDICA.OD003_NUM_PESSOA, OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_PESSOA);
                _.Move(V0PJURIDICA.OD003_NUM_CNPJ, OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_CNPJ);
                _.Move(V0PJURIDICA.OD003_NUM_FILIAL, OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_FILIAL);
                _.Move(V0PJURIDICA.OD003_NUM_DV_CNPJ, OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_DV_CNPJ);
                _.Move(V0PJURIDICA.OD003_NOM_RAZAO_SOCIAL, OD003.DCLOD_PESSOA_JURIDICA.OD003_NOM_RAZAO_SOCIAL);
                _.Move(V0PJURIDICA.OD003_STA_PESSOA, OD003.DCLOD_PESSOA_JURIDICA.OD003_STA_PESSOA);
                _.Move(V0PJURIDICA.OD003_NUM_RAMO_ATIVIDADE, OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_RAMO_ATIVIDADE);
                _.Move(V0PJURIDICA.IND_NULL_01, AREA_DE_WORK.IND_NULL_01);
                _.Move(V0PJURIDICA.OD003_DTH_FUNDACAO, OD003.DCLOD_PESSOA_JURIDICA.OD003_DTH_FUNDACAO);
                _.Move(V0PJURIDICA.IND_NULL_02, AREA_DE_WORK.IND_NULL_02);
                _.Move(V0PJURIDICA.OD003_NOM_FANTASIA, OD003.DCLOD_PESSOA_JURIDICA.OD003_NOM_FANTASIA);
                _.Move(V0PJURIDICA.IND_NULL_03, AREA_DE_WORK.IND_NULL_03);
                _.Move(V0PJURIDICA.OD003_NOM_SIGLA_PESSOA, OD003.DCLOD_PESSOA_JURIDICA.OD003_NOM_SIGLA_PESSOA);
                _.Move(V0PJURIDICA.IND_NULL_04, AREA_DE_WORK.IND_NULL_04);
                _.Move(V0PJURIDICA.OD003_NUM_INSC_ESTADUAL, OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_INSC_ESTADUAL);
                _.Move(V0PJURIDICA.IND_NULL_05, AREA_DE_WORK.IND_NULL_05);
                _.Move(V0PJURIDICA.OD003_NUM_INSC_MUNICIPAL, OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_INSC_MUNICIPAL);
                _.Move(V0PJURIDICA.IND_NULL_06, AREA_DE_WORK.IND_NULL_06);
                _.Move(V0PJURIDICA.OD003_COD_UF, OD003.DCLOD_PESSOA_JURIDICA.OD003_COD_UF);
                _.Move(V0PJURIDICA.IND_NULL_07, AREA_DE_WORK.IND_NULL_07);
                _.Move(V0PJURIDICA.OD003_NUM_MUNICIPIO, OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_MUNICIPIO);
                _.Move(V0PJURIDICA.IND_NULL_08, AREA_DE_WORK.IND_NULL_08);
                _.Move(V0PJURIDICA.OD003_COD_CNAE, OD003.DCLOD_PESSOA_JURIDICA.OD003_COD_CNAE);
                _.Move(V0PJURIDICA.IND_NULL_09, AREA_DE_WORK.IND_NULL_09);
                _.Move(V0PJURIDICA.OD003_NUM_SOCIOS, OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_SOCIOS);
                _.Move(V0PJURIDICA.IND_NULL_10, AREA_DE_WORK.IND_NULL_10);
                _.Move(V0PJURIDICA.OD003_STA_FRANQUIA, OD003.DCLOD_PESSOA_JURIDICA.OD003_STA_FRANQUIA);
                _.Move(V0PJURIDICA.IND_NULL_11, AREA_DE_WORK.IND_NULL_11);
                _.Move(V0PJURIDICA.OD003_IND_FINALIDADE, OD003.DCLOD_PESSOA_JURIDICA.OD003_IND_FINALIDADE);
                _.Move(V0PJURIDICA.IND_NULL_12, AREA_DE_WORK.IND_NULL_12);
            }

        }

        [StopWatch]
        /*" R320-00-FETCH-PJURIDICA-DB-CLOSE-1 */
        public void R320_00_FETCH_PJURIDICA_DB_CLOSE_1()
        {
            /*" -814- EXEC SQL CLOSE V0PJURIDICA END-EXEC */

            V0PJURIDICA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R320_EXIT*/

        [StopWatch]
        /*" R320-00-FETCH-PJURIDICA-DB-CLOSE-2 */
        public void R320_00_FETCH_PJURIDICA_DB_CLOSE_2()
        {
            /*" -828- EXEC SQL CLOSE V0PJURIDICA END-EXEC. */

            V0PJURIDICA.Close();

        }

        [StopWatch]
        /*" R1000-DISPLAY-INSERT */
        private void R1000_DISPLAY_INSERT(bool isPerform = false)
        {
            /*" -898- DISPLAY 'OD001-NUM-PESSOA.........' OD001-NUM-PESSOA */
            _.Display($"OD001-NUM-PESSOA.........{OD001.DCLOD_PESSOA.OD001_NUM_PESSOA}");

            /*" -899- DISPLAY 'OD001-DTH-CADASTRAMENTO..' OD001-DTH-CADASTRAMENTO */
            _.Display($"OD001-DTH-CADASTRAMENTO..{OD001.DCLOD_PESSOA.OD001_DTH_CADASTRAMENTO}");

            /*" -900- DISPLAY 'OD001-NUM-DV-PESSOA......' OD001-NUM-DV-PESSOA */
            _.Display($"OD001-NUM-DV-PESSOA......{OD001.DCLOD_PESSOA.OD001_NUM_DV_PESSOA}");

            /*" -901- DISPLAY 'OD001-IND-PESSOA.........' OD001-IND-PESSOA */
            _.Display($"OD001-IND-PESSOA.........{OD001.DCLOD_PESSOA.OD001_IND_PESSOA}");

            /*" -902- DISPLAY 'OD001-STA-INF-INTEGRA....' OD001-STA-INF-INTEGRA */
            _.Display($"OD001-STA-INF-INTEGRA....{OD001.DCLOD_PESSOA.OD001_STA_INF_INTEGRA}");

            /*" -903- DISPLAY ' ' */
            _.Display($" ");

            /*" -904- DISPLAY 'NUM-PESSOA.......' OD003-NUM-PESSOA */
            _.Display($"NUM-PESSOA.......{OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_PESSOA}");

            /*" -905- DISPLAY 'NUM-CNPJ.........' OD003-NUM-CNPJ */
            _.Display($"NUM-CNPJ.........{OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_CNPJ}");

            /*" -906- DISPLAY 'NUM-FILIAL.......' OD003-NUM-FILIAL */
            _.Display($"NUM-FILIAL.......{OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_FILIAL}");

            /*" -907- DISPLAY 'NUM-DV-CNPJ...... ' OD003-NUM-DV-CNPJ */
            _.Display($"NUM-DV-CNPJ...... {OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_DV_CNPJ}");

            /*" -908- DISPLAY 'NOM-RAZAO-LEN.... ' OD003-NOM-RAZAO-SOCIAL-LEN */
            _.Display($"NOM-RAZAO-LEN.... {OD003.DCLOD_PESSOA_JURIDICA.OD003_NOM_RAZAO_SOCIAL.OD003_NOM_RAZAO_SOCIAL_LEN}");

            /*" -909- DISPLAY 'NOM-RAZAO-TEXT... ' OD003-NOM-RAZAO-SOCIAL-TEXT */
            _.Display($"NOM-RAZAO-TEXT... {OD003.DCLOD_PESSOA_JURIDICA.OD003_NOM_RAZAO_SOCIAL.OD003_NOM_RAZAO_SOCIAL_TEXT}");

            /*" -910- DISPLAY 'NOM-RAZAO-SOCIAL.... ' OD003-NOM-RAZAO-SOCIAL */
            _.Display($"NOM-RAZAO-SOCIAL.... {OD003.DCLOD_PESSOA_JURIDICA.OD003_NOM_RAZAO_SOCIAL}");

            /*" -911- DISPLAY 'STA-PESSOA.......... ' OD003-STA-PESSOA */
            _.Display($"STA-PESSOA.......... {OD003.DCLOD_PESSOA_JURIDICA.OD003_STA_PESSOA}");

            /*" -912- DISPLAY 'NUM-RAMO-ATIVIDADE.. ' OD003-NUM-RAMO-ATIVIDADE */
            _.Display($"NUM-RAMO-ATIVIDADE.. {OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_RAMO_ATIVIDADE}");

            /*" -913- DISPLAY 'DTH-FUNDACAO........ ' OD003-DTH-FUNDACAO */
            _.Display($"DTH-FUNDACAO........ {OD003.DCLOD_PESSOA_JURIDICA.OD003_DTH_FUNDACAO}");

            /*" -914- DISPLAY 'NOM-FANTASIA........ ' OD003-NOM-FANTASIA */
            _.Display($"NOM-FANTASIA........ {OD003.DCLOD_PESSOA_JURIDICA.OD003_NOM_FANTASIA}");

            /*" -915- DISPLAY 'NOM-SIGLA-PESSOA.... ' OD003-NOM-SIGLA-PESSOA */
            _.Display($"NOM-SIGLA-PESSOA.... {OD003.DCLOD_PESSOA_JURIDICA.OD003_NOM_SIGLA_PESSOA}");

            /*" -916- DISPLAY 'NUM-INSC-ESTADUAL... ' OD003-NUM-INSC-ESTADUAL */
            _.Display($"NUM-INSC-ESTADUAL... {OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_INSC_ESTADUAL}");

            /*" -917- DISPLAY 'NUM-INSC-MUNICIPAL.. ' OD003-NUM-INSC-MUNICIPAL */
            _.Display($"NUM-INSC-MUNICIPAL.. {OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_INSC_MUNICIPAL}");

            /*" -918- DISPLAY 'COD-UF.............. ' OD003-COD-UF */
            _.Display($"COD-UF.............. {OD003.DCLOD_PESSOA_JURIDICA.OD003_COD_UF}");

            /*" -919- DISPLAY 'NUM-MUNICIPIO....... ' OD003-NUM-MUNICIPIO */
            _.Display($"NUM-MUNICIPIO....... {OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_MUNICIPIO}");

            /*" -920- DISPLAY 'COD-CNAE............ ' OD003-COD-CNAE */
            _.Display($"COD-CNAE............ {OD003.DCLOD_PESSOA_JURIDICA.OD003_COD_CNAE}");

            /*" -921- DISPLAY 'NUM-SOCIOS.......... ' OD003-NUM-SOCIOS */
            _.Display($"NUM-SOCIOS.......... {OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_SOCIOS}");

            /*" -922- DISPLAY 'STA-FRANQUIA........ ' OD003-STA-FRANQUIA */
            _.Display($"STA-FRANQUIA........ {OD003.DCLOD_PESSOA_JURIDICA.OD003_STA_FRANQUIA}");

            /*" -922- DISPLAY 'IND-FINALIDADE...... ' OD003-IND-FINALIDADE . */
            _.Display($"IND-FINALIDADE...... {OD003.DCLOD_PESSOA_JURIDICA.OD003_IND_FINALIDADE}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_EXIT*/

        [StopWatch]
        /*" R9999-00-CANCELA-PROGRAMA */
        private void R9999_00_CANCELA_PROGRAMA(bool isPerform = false)
        {
            /*" -929- MOVE 'SIM' TO LINK-IND-ERRO */
            _.Move("SIM", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_IND_ERRO);

            /*" -932- MOVE SQLCODE TO LINK-SQLCODE WSQLCODE */
            _.Move(DB.SQLCODE, LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_SQLCODE, AREA_DE_WORK.WABEND.WABEND3.WSQLCODE);

            /*" -933- DISPLAY ' ' */
            _.Display($" ");

            /*" -934- DISPLAY '=====  PROGRAMA ABENDADO  =====' */
            _.Display($"=====  PROGRAMA ABENDADO  =====");

            /*" -935- DISPLAY ' ' */
            _.Display($" ");

            /*" -937- DISPLAY 'ERRO NA ROTINA GE0501B ' */
            _.Display($"ERRO NA ROTINA GE0501B ");

            /*" -938- DISPLAY WABEND1. */
            _.Display(AREA_DE_WORK.WABEND.WABEND1);

            /*" -939- DISPLAY WABEND2. */
            _.Display(AREA_DE_WORK.WABEND.WABEND2);

            /*" -943- DISPLAY WABEND3. */
            _.Display(AREA_DE_WORK.WABEND.WABEND3);

            /*" -949- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -949- GOBACK. */

            throw new GoBack();

        }
    }
}