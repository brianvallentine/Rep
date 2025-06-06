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
using Sias.Geral.DB2.GE0500B;

namespace Code
{
    public class GE0500B
    {
        public bool IsCall { get; set; }

        public GE0500B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  PESSOA                             *      */
        /*"      *   PROGRAMA ...............  GE0500B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  FAST COMPUTER                      *      */
        /*"      *   PROGRAMADOR ............  MARCO ANTONIO                      *      */
        /*"      *   DATA CODIFICACAO .......  DEZEMBRO/2007                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO.. EFETUAR O CADASTRAMENTO E CONSULTA DE PESSOA FISICA *      */
        /*"      *            NA BASE DE PESSOA                                   *      */
        /*"      *   GE0500B - COBOL / DB2 / CICS                                 *      */
        /*"      *   GE0500B - COBOL / DB2                                               */
        /*"      * LINK-TIPO-UTILIZACAO = 1 CONSULTA PELO CPF, CASO A PESSOA NAO  *      */
        /*"      * SEJA ENCONTRADA, SERA FEITA INCLUSAO.                          *      */
        /*"      * LINK-TIPO-UTILIZACAO = 2 CONSULTA PELO CODIGO DE PESSOA        *      */
        /*"      * LINK-TIPO-UTILIZACAO = 3 INCLUSAO DE PESSOA SEM CONSULTA.      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * HISTORICO DE CORRECOES                                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 2    V.2       04/01/2012  PATRICIA SALES  PROCURE POR V.02    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * NO   VERSAO    DATA       RESPONSAVEL           ALTERACAO      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 01                                                    *      */
        /*"      *             - CAD 14.198    PASSA A CLASSIFICAR NUM_PESSOA     *      */
        /*"      *               EM ORDEM DESCENDENTE PARA CNPJ/CPF JA ENCONTRADO *      */
        /*"      *               PARA ALINHAR COM O ON-LINE 99-34, APLICACAO      *      */
        /*"      *               GE01M020 - MANUTENCAO BASE ODS.                  *      */
        /*"      *                                                                *      */
        /*"      *   EM 10/02/2009 - FAST COMPUTER            PROCURE POR V.01    *      */
        /*"      *                                                                *      */
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
        /*"77    VIND-NULL08               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL08 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL09               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL09 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL10               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL10 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL11               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL11 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL12               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL12 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL13               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL13 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL14               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL14 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL15               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL15 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01     AREA-DE-WORK.*/
        public GE0500B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new GE0500B_AREA_DE_WORK();
        public class GE0500B_AREA_DE_WORK : VarBasis
        {
            /*"  05 W-TABELA-LIKE-NOME.*/
            public GE0500B_W_TABELA_LIKE_NOME W_TABELA_LIKE_NOME { get; set; } = new GE0500B_W_TABELA_LIKE_NOME();
            public class GE0500B_W_TABELA_LIKE_NOME : VarBasis
            {
                /*"     10 W-TAB-LIKE-NOME              PIC X(01) OCCURS 200 TIMES.*/
                public ListBasis<StringBasis, string> W_TAB_LIKE_NOME { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(01)"), 200);
                /*"  05 WFIM-MOVIMENTO                  PIC X(001) VALUE 'N'.*/
            }
            public StringBasis WFIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  05 WTEM-PESSOA                     PIC X(001) VALUE  SPACES.*/
            public StringBasis WTEM_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05 AUX-NOM-PESSOA                  PIC X(200).*/
            public StringBasis AUX_NOM_PESSOA { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");
            /*"  05 W-IND-NOME                      PIC 9(03) VALUE ZEROS.*/
            public IntBasis W_IND_NOME { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
            /*"  05   W-EDICAO                      PIC  Z.ZZZ.ZZ9,99-.*/
            public DoubleBasis W_EDICAO { get; set; } = new DoubleBasis(new PIC("9", "7", "Z.ZZZ.ZZ9V99-."), 3);
            /*"  05 HOST-CURRENT-DATE               PIC  X(10) VALUE SPACES.*/
            public StringBasis HOST_CURRENT_DATE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"  05 HOST-CURRENT-TIMESTAMP          PIC  X(26) VALUE SPACES.*/
            public StringBasis HOST_CURRENT_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)"), @"");
            /*"  05 IND-NULL-01                     PIC  S9(04) COMP VALUE +0.*/
            public IntBasis IND_NULL_01 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05 IND-NULL-02                     PIC  S9(04) COMP VALUE +0.*/
            public IntBasis IND_NULL_02 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05 IND-NULL-03                     PIC  S9(04) COMP VALUE +0.*/
            public IntBasis IND_NULL_03 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05 IND-NULL-04                     PIC  S9(04) COMP VALUE +0.*/
            public IntBasis IND_NULL_04 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05   WABEND.*/
            public GE0500B_WABEND WABEND { get; set; } = new GE0500B_WABEND();
            public class GE0500B_WABEND : VarBasis
            {
                /*"    10 WABEND1                       PIC  X(009)  VALUE                                                      'GE0500B '*/
                public StringBasis WABEND1 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"GE0500B ");
                /*"    10 WABEND2.*/
                public GE0500B_WABEND2 WABEND2 { get; set; } = new GE0500B_WABEND2();
                public class GE0500B_WABEND2 : VarBasis
                {
                    /*"      15 FILLER                      PIC  X(025)  VALUE                                     '*** ERRO EXEC SQL NUMERO '*/
                    public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"*** ERRO EXEC SQL NUMERO ");
                    /*"      15 WNR-EXEC-SQL                PIC  X(005)  VALUE SPACES.*/
                    public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                    /*"    10 WABEND3.*/
                }
                public GE0500B_WABEND3 WABEND3 { get; set; } = new GE0500B_WABEND3();
                public class GE0500B_WABEND3 : VarBasis
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
        public GE0500B_W_LINK_MSG_ERRO W_LINK_MSG_ERRO { get; set; } = new GE0500B_W_LINK_MSG_ERRO();
        public class GE0500B_W_LINK_MSG_ERRO : VarBasis
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
        public GE0500B_LINK_PARAMETRO LINK_PARAMETRO { get; set; } = new GE0500B_LINK_PARAMETRO();
        public class GE0500B_LINK_PARAMETRO : VarBasis
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
            /*"  05   LINK-NUM-CPF                  PIC S9(9) USAGE COMP.*/
            public IntBasis LINK_NUM_CPF { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
            /*"  05   LINK-NUM-DV-CPF               PIC S9(4) USAGE COMP.*/
            public IntBasis LINK_NUM_DV_CPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"  05   LINK-NOM-PESSOA               PIC X(200).*/
            public StringBasis LINK_NOM_PESSOA { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");
            /*"  05   LINK-DTH-NASCIMENTO           PIC X(10).*/
            public StringBasis LINK_DTH_NASCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"  05   LINK-STA-SEXO                 PIC X(1).*/
            public StringBasis LINK_STA_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
            /*"  05   LINK-IND-ESTADO-CIVIL         PIC X(1).*/
            public StringBasis LINK_IND_ESTADO_CIVIL { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
            /*"  05   LINK-STA-PESSOA               PIC X(1).*/
            public StringBasis LINK_STA_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
            /*"  05   LINK-NOM-TRATAMENTO           PIC X(15).*/
            public StringBasis LINK_NOM_TRATAMENTO { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
            /*"  05   LINK-COD-UF                   PIC X(2).*/
            public StringBasis LINK_COD_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
            /*"  05   LINK-NUM-MUNICIPIO            PIC S9(9) USAGE COMP.*/
            public IntBasis LINK_NUM_MUNICIPIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
            /*"  05   LINK-NUM-INSC-SOCIAL          PIC S9(10)V USAGE COMP-3.*/
            public DoubleBasis LINK_NUM_INSC_SOCIAL { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V"), 0);
            /*"  05   LINK-NUM-DV-INSC-SOCIAL       PIC S9(4) USAGE COMP.*/
            public IntBasis LINK_NUM_DV_INSC_SOCIAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"  05   LINK-NUM-GRAU-INSTRUCAO       PIC S9(4) USAGE COMP.*/
            public IntBasis LINK_NUM_GRAU_INSTRUCAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"  05   LINK-NOM-REDUZIDO             PIC X(25).*/
            public StringBasis LINK_NOM_REDUZIDO { get; set; } = new StringBasis(new PIC("X", "25", "X(25)."), @"");
            /*"  05   LINK-COD-CBO                  PIC X(10).*/
            public StringBasis LINK_COD_CBO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"  05   LINK-NOM-PRIMEIRO             PIC X(25).*/
            public StringBasis LINK_NOM_PRIMEIRO { get; set; } = new StringBasis(new PIC("X", "25", "X(25)."), @"");
            /*"  05   LINK-NOM-ULTIMO               PIC X(25).*/
            public StringBasis LINK_NOM_ULTIMO { get; set; } = new StringBasis(new PIC("X", "25", "X(25)."), @"");
            /*"  05   LINK-PARAMETROS-SAIDA.*/
            public GE0500B_LINK_PARAMETROS_SAIDA LINK_PARAMETROS_SAIDA { get; set; } = new GE0500B_LINK_PARAMETROS_SAIDA();
            public class GE0500B_LINK_PARAMETROS_SAIDA : VarBasis
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
        public Dclgens.OD002 OD002 { get; set; } = new Dclgens.OD002();
        public Dclgens.UNIDAFED UNIDAFED { get; set; } = new Dclgens.UNIDAFED();
        public GE0500B_V0PFISICA V0PFISICA { get; set; } = new GE0500B_V0PFISICA();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(GE0500B_LINK_PARAMETRO GE0500B_LINK_PARAMETRO_P) //PROCEDURE DIVISION USING 
        /*LINK_PARAMETRO*/
        {
            try
            {
                this.LINK_PARAMETRO = GE0500B_LINK_PARAMETRO_P;

                /*" -184- MOVE '0001' TO WNR-EXEC-SQL */
                _.Move("0001", AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL);

                /*" -184- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -185- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -186- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -206- INITIALIZE LINK-PARAMETROS-SAIDA. */
                _.Initialize(
                    LINK_PARAMETRO.LINK_PARAMETROS_SAIDA
                );

                /*" -209- IF (LINK-TIPO-UTILIZACAO NOT EQUAL 1) AND (LINK-TIPO-UTILIZACAO NOT EQUAL 2) AND (LINK-TIPO-UTILIZACAO NOT EQUAL 3) */

                if ((LINK_PARAMETRO.LINK_TIPO_UTILIZACAO != 1) && (LINK_PARAMETRO.LINK_TIPO_UTILIZACAO != 2) && (LINK_PARAMETRO.LINK_TIPO_UTILIZACAO != 3))
                {

                    /*" -212- MOVE 'GE0500B - TIPO DE CHAMADA INVALIDO. 1 - CONSULTA/INCLUSAO 2 - CONSULTA 3 - INCLUSAO' TO LINK-MSG-ERRO */
                    _.Move("GE0500B - TIPO DE CHAMADA INVALIDO. 1 - CONSULTA/INCLUSAO 2 - CONSULTA 3 - INCLUSAO", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                    /*" -214- GO TO R9999-00-CANCELA-PROGRAMA. */

                    R9999_00_CANCELA_PROGRAMA(); //GOTO
                    return Result;
                }


                /*" -215- IF LINK-PROGRAMA-CHAMADOR EQUAL SPACES */

                if (LINK_PARAMETRO.LINK_PROGRAMA_CHAMADOR.IsEmpty())
                {

                    /*" -217- MOVE 'GE0500B - NOME DO PGM CHAMADOR NAO INFORMADO' TO LINK-MSG-ERRO */
                    _.Move("GE0500B - NOME DO PGM CHAMADOR NAO INFORMADO", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                    /*" -219- GO TO R9999-00-CANCELA-PROGRAMA. */

                    R9999_00_CANCELA_PROGRAMA(); //GOTO
                    return Result;
                }


                /*" -220- IF LINK-NOME-USUARIO EQUAL SPACES */

                if (LINK_PARAMETRO.LINK_NOME_USUARIO.IsEmpty())
                {

                    /*" -222- MOVE 'GE0500B - NOME DO USUARIO CHAMADOR NAO INFORMADO' TO LINK-MSG-ERRO */
                    _.Move("GE0500B - NOME DO USUARIO CHAMADOR NAO INFORMADO", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                    /*" -224- GO TO R9999-00-CANCELA-PROGRAMA. */

                    R9999_00_CANCELA_PROGRAMA(); //GOTO
                    return Result;
                }


                /*" -226- MOVE '0002' TO WNR-EXEC-SQL */
                _.Move("0002", AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL);

                /*" -233- PERFORM Execute_DB_SELECT_1 */

                Execute_DB_SELECT_1();

                /*" -236- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -238- MOVE 'GE0500B - ERRO NA LEITURA DA SISTEMAS' TO W-LINK-MENSAGEM */
                    _.Move("GE0500B - ERRO NA LEITURA DA SISTEMAS", W_LINK_MSG_ERRO.W_LINK_MENSAGEM);

                    /*" -239- MOVE SQLCODE TO W-LINK-SQLCODE */
                    _.Move(DB.SQLCODE, W_LINK_MSG_ERRO.W_LINK_SQLCODE);

                    /*" -240- MOVE WNR-EXEC-SQL TO W-WNR-EXEC-SQL */
                    _.Move(AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL, W_LINK_MSG_ERRO.W_WNR_EXEC_SQL);

                    /*" -241- MOVE W-LINK-MSG-ERRO TO LINK-MSG-ERRO */
                    _.Move(W_LINK_MSG_ERRO, LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                    /*" -242- MOVE 'SISTEMAS   ' TO LINK-NOME-TABELA */
                    _.Move("SISTEMAS   ", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_NOME_TABELA);

                    /*" -243- DISPLAY 'GE0500B - ERRO ACESSO SISTEMAS' */
                    _.Display($"GE0500B - ERRO ACESSO SISTEMAS");

                    /*" -245- GO TO R9999-00-CANCELA-PROGRAMA. */

                    R9999_00_CANCELA_PROGRAMA(); //GOTO
                    return Result;
                }


                /*" -246- IF (LINK-TIPO-UTILIZACAO EQUAL 1) */

                if ((LINK_PARAMETRO.LINK_TIPO_UTILIZACAO == 1))
                {

                    /*" -247- PERFORM R010-CRITICA-INCLUSAO THRU R010-EXIT */

                    R010_CRITICA_INCLUSAO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_EXIT*/


                    /*" -248- PERFORM R300-CONSULTA-PF THRU R300-EXIT */

                    R300_CONSULTA_PF(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R300_EXIT*/


                    /*" -249- IF WTEM-PESSOA NOT EQUAL 'S' */

                    if (AREA_DE_WORK.WTEM_PESSOA != "S")
                    {

                        /*" -251- PERFORM R100-INSERT-PF THRU R100-EXIT. */

                        R100_INSERT_PF(true);

                        INICIO_LOOP_NOME(true);
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/

                    }

                }


                /*" -252- IF (LINK-TIPO-UTILIZACAO EQUAL 2) */

                if ((LINK_PARAMETRO.LINK_TIPO_UTILIZACAO == 2))
                {

                    /*" -253- PERFORM R020-CRITICA-CONSUTA THRU R020-EXIT */

                    R020_CRITICA_CONSUTA(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R020_EXIT*/


                    /*" -255- PERFORM R200-CONSULTA-PF THRU R200-EXIT. */

                    R200_CONSULTA_PF(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R200_EXIT*/

                }


                /*" -256- IF (LINK-TIPO-UTILIZACAO EQUAL 3) */

                if ((LINK_PARAMETRO.LINK_TIPO_UTILIZACAO == 3))
                {

                    /*" -257- PERFORM R010-CRITICA-INCLUSAO THRU R010-EXIT */

                    R010_CRITICA_INCLUSAO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_EXIT*/


                    /*" -259- PERFORM R100-INSERT-PF THRU R100-EXIT. */

                    R100_INSERT_PF(true);

                    INICIO_LOOP_NOME(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/

                }


                /*" -265- MOVE ZEROS TO RETURN-CODE. */
                _.Move(0, RETURN_CODE);

                /*" -265- GOBACK. */

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
            /*" -233- EXEC SQL SELECT CURRENT DATE, CURRENT TIMESTAMP INTO :HOST-CURRENT-DATE, :HOST-CURRENT-TIMESTAMP FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'EM' END-EXEC. */

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
            /*" -272- IF LINK-IND-PESSOA NOT EQUAL 'F' */

            if (LINK_PARAMETRO.LINK_IND_PESSOA != "F")
            {

                /*" -274- MOVE 'GE0500B - INDICADOR DE PESSOA DIFERE DE FISICA' TO LINK-MSG-ERRO */
                _.Move("GE0500B - INDICADOR DE PESSOA DIFERE DE FISICA", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                /*" -276- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA(); //GOTO
                return;
            }


            /*" -279- IF (LINK-PESSOA-ESPECIAL NOT EQUAL 'N' ) AND (LINK-PESSOA-ESPECIAL NOT EQUAL 'E' ) AND (LINK-PESSOA-ESPECIAL NOT EQUAL 'G' ) */

            if ((LINK_PARAMETRO.LINK_PESSOA_ESPECIAL != "N") && (LINK_PARAMETRO.LINK_PESSOA_ESPECIAL != "E") && (LINK_PARAMETRO.LINK_PESSOA_ESPECIAL != "G"))
            {

                /*" -281- MOVE 'GE0500B - INDICADOR DE PESSOA ESPECIAL INVALIDA' TO LINK-MSG-ERRO */
                _.Move("GE0500B - INDICADOR DE PESSOA ESPECIAL INVALIDA", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                /*" -283- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA(); //GOTO
                return;
            }


            /*" -284- IF LINK-PESSOA-ESPECIAL EQUAL 'N' */

            if (LINK_PARAMETRO.LINK_PESSOA_ESPECIAL == "N")
            {

                /*" -285- IF LINK-NUM-CPF EQUAL 0 */

                if (LINK_PARAMETRO.LINK_NUM_CPF == 0)
                {

                    /*" -287- MOVE 'GE0500B - CPF NAO INFORMADO' TO LINK-MSG-ERRO */
                    _.Move("GE0500B - CPF NAO INFORMADO", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                    /*" -295- GO TO R9999-00-CANCELA-PROGRAMA. */

                    R9999_00_CANCELA_PROGRAMA(); //GOTO
                    return;
                }

            }


            /*" -296- IF LINK-NOM-PESSOA EQUAL SPACES */

            if (LINK_PARAMETRO.LINK_NOM_PESSOA.IsEmpty())
            {

                /*" -298- MOVE 'GE0500B - NOME DA PESSOA NAO INFORMADO' TO LINK-MSG-ERRO */
                _.Move("GE0500B - NOME DA PESSOA NAO INFORMADO", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                /*" -300- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA(); //GOTO
                return;
            }


            /*" -301- IF LINK-DTH-NASCIMENTO EQUAL SPACES */

            if (LINK_PARAMETRO.LINK_DTH_NASCIMENTO.IsEmpty())
            {

                /*" -302- MOVE -1 TO IND-NULL-01 */
                _.Move(-1, AREA_DE_WORK.IND_NULL_01);

                /*" -303- ELSE */
            }
            else
            {


                /*" -304- IF LINK-DTH-NASCIMENTO NOT LESS HOST-CURRENT-DATE */

                if (LINK_PARAMETRO.LINK_DTH_NASCIMENTO >= AREA_DE_WORK.HOST_CURRENT_DATE)
                {

                    /*" -306- MOVE 'GE0500B - DATA DE NASCIMENTO MAIOR DATA DE HOJE' TO LINK-MSG-ERRO */
                    _.Move("GE0500B - DATA DE NASCIMENTO MAIOR DATA DE HOJE", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                    /*" -307- GO TO R9999-00-CANCELA-PROGRAMA */

                    R9999_00_CANCELA_PROGRAMA(); //GOTO
                    return;

                    /*" -308- END-IF */
                }


                /*" -309- IF LINK-DTH-NASCIMENTO LESS '1907-01-01' */

                if (LINK_PARAMETRO.LINK_DTH_NASCIMENTO < "1907-01-01")
                {

                    /*" -311- MOVE 'GE0500B - DATA DE NASCIMENTO ANTERIOR A 100 ANOS' TO LINK-MSG-ERRO */
                    _.Move("GE0500B - DATA DE NASCIMENTO ANTERIOR A 100 ANOS", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                    /*" -312- GO TO R9999-00-CANCELA-PROGRAMA */

                    R9999_00_CANCELA_PROGRAMA(); //GOTO
                    return;

                    /*" -314- END-IF. */
                }

            }


            /*" -315- IF (LINK-STA-SEXO EQUAL ' ' ) */

            if ((LINK_PARAMETRO.LINK_STA_SEXO == " "))
            {

                /*" -316- MOVE -1 TO IND-NULL-02 */
                _.Move(-1, AREA_DE_WORK.IND_NULL_02);

                /*" -317- ELSE */
            }
            else
            {


                /*" -319- IF (LINK-STA-SEXO NOT EQUAL 'M' ) AND (LINK-STA-SEXO NOT EQUAL 'F' ) */

                if ((LINK_PARAMETRO.LINK_STA_SEXO != "M") && (LINK_PARAMETRO.LINK_STA_SEXO != "F"))
                {

                    /*" -321- MOVE 'GE0500B - SEXO INVALIDO' TO LINK-MSG-ERRO */
                    _.Move("GE0500B - SEXO INVALIDO", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                    /*" -323- GO TO R9999-00-CANCELA-PROGRAMA. */

                    R9999_00_CANCELA_PROGRAMA(); //GOTO
                    return;
                }

            }


            /*" -324- IF LINK-NUM-GRAU-INSTRUCAO EQUAL 0 */

            if (LINK_PARAMETRO.LINK_NUM_GRAU_INSTRUCAO == 0)
            {

                /*" -326- MOVE -1 TO IND-NULL-04. */
                _.Move(-1, AREA_DE_WORK.IND_NULL_04);
            }


            /*" -327- IF (LINK-IND-ESTADO-CIVIL EQUAL ' ' ) */

            if ((LINK_PARAMETRO.LINK_IND_ESTADO_CIVIL == " "))
            {

                /*" -328- MOVE -1 TO IND-NULL-03 */
                _.Move(-1, AREA_DE_WORK.IND_NULL_03);

                /*" -329- ELSE */
            }
            else
            {


                /*" -335- IF (LINK-IND-ESTADO-CIVIL NOT EQUAL 'S' ) AND (LINK-IND-ESTADO-CIVIL NOT EQUAL 'C' ) AND (LINK-IND-ESTADO-CIVIL NOT EQUAL 'D' ) AND (LINK-IND-ESTADO-CIVIL NOT EQUAL 'V' ) AND (LINK-IND-ESTADO-CIVIL NOT EQUAL 'F' ) AND (LINK-IND-ESTADO-CIVIL NOT EQUAL 'O' ) */

                if ((LINK_PARAMETRO.LINK_IND_ESTADO_CIVIL != "S") && (LINK_PARAMETRO.LINK_IND_ESTADO_CIVIL != "C") && (LINK_PARAMETRO.LINK_IND_ESTADO_CIVIL != "D") && (LINK_PARAMETRO.LINK_IND_ESTADO_CIVIL != "V") && (LINK_PARAMETRO.LINK_IND_ESTADO_CIVIL != "F") && (LINK_PARAMETRO.LINK_IND_ESTADO_CIVIL != "O"))
                {

                    /*" -337- MOVE 'GE0500B - ESTADO CIVIL INVALIDO' TO LINK-MSG-ERRO */
                    _.Move("GE0500B - ESTADO CIVIL INVALIDO", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                    /*" -339- GO TO R9999-00-CANCELA-PROGRAMA. */

                    R9999_00_CANCELA_PROGRAMA(); //GOTO
                    return;
                }

            }


            /*" -340- IF LINK-COD-UF EQUAL SPACES */

            if (LINK_PARAMETRO.LINK_COD_UF.IsEmpty())
            {

                /*" -342- GO TO R010-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_EXIT*/ //GOTO
                return;
            }


            /*" -344- MOVE LINK-COD-UF TO UNIDAFED-SIGLA-UF */
            _.Move(LINK_PARAMETRO.LINK_COD_UF, UNIDAFED.DCLUNIDADE_FEDERACAO.UNIDAFED_SIGLA_UF);

            /*" -346- MOVE '0002' TO WNR-EXEC-SQL */
            _.Move("0002", AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL);

            /*" -351- PERFORM R010_CRITICA_INCLUSAO_DB_SELECT_1 */

            R010_CRITICA_INCLUSAO_DB_SELECT_1();

            /*" -354- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -356- MOVE 'GE0500B - UF DO MUNICIPIO INVALIDO' TO LINK-MSG-ERRO */
                _.Move("GE0500B - UF DO MUNICIPIO INVALIDO", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                /*" -358- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA(); //GOTO
                return;
            }


            /*" -359- IF (SQLCODE NOT EQUAL 100) AND (SQLCODE NOT EQUAL 0) */

            if ((DB.SQLCODE != 100) && (DB.SQLCODE != 0))
            {

                /*" -361- MOVE 'GE0500B - ERRO NA LEITURA DA UNIDADE_FEDERACAO' TO W-LINK-MENSAGEM */
                _.Move("GE0500B - ERRO NA LEITURA DA UNIDADE_FEDERACAO", W_LINK_MSG_ERRO.W_LINK_MENSAGEM);

                /*" -362- MOVE SQLCODE TO W-LINK-SQLCODE */
                _.Move(DB.SQLCODE, W_LINK_MSG_ERRO.W_LINK_SQLCODE);

                /*" -363- MOVE WNR-EXEC-SQL TO W-WNR-EXEC-SQL */
                _.Move(AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL, W_LINK_MSG_ERRO.W_WNR_EXEC_SQL);

                /*" -364- MOVE W-LINK-MSG-ERRO TO LINK-MSG-ERRO */
                _.Move(W_LINK_MSG_ERRO, LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                /*" -365- MOVE 'UNIDADE_FEDERACAO' TO LINK-NOME-TABELA */
                _.Move("UNIDADE_FEDERACAO", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_NOME_TABELA);

                /*" -366- DISPLAY 'GE0500B - ERRO ACESSO UNIDADE_FEDERACAO' */
                _.Display($"GE0500B - ERRO ACESSO UNIDADE_FEDERACAO");

                /*" -366- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R010-CRITICA-INCLUSAO-DB-SELECT-1 */
        public void R010_CRITICA_INCLUSAO_DB_SELECT_1()
        {
            /*" -351- EXEC SQL SELECT SIGLA_UF INTO :UNIDAFED-SIGLA-UF FROM SEGUROS.UNIDADE_FEDERACAO WHERE SIGLA_UF = :UNIDAFED-SIGLA-UF END-EXEC. */

            var r010_CRITICA_INCLUSAO_DB_SELECT_1_Query1 = new R010_CRITICA_INCLUSAO_DB_SELECT_1_Query1()
            {
                UNIDAFED_SIGLA_UF = UNIDAFED.DCLUNIDADE_FEDERACAO.UNIDAFED_SIGLA_UF.ToString(),
            };

            var executed_1 = R010_CRITICA_INCLUSAO_DB_SELECT_1_Query1.Execute(r010_CRITICA_INCLUSAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.UNIDAFED_SIGLA_UF, UNIDAFED.DCLUNIDADE_FEDERACAO.UNIDAFED_SIGLA_UF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_EXIT*/

        [StopWatch]
        /*" R020-CRITICA-CONSUTA */
        private void R020_CRITICA_CONSUTA(bool isPerform = false)
        {
            /*" -373- IF LINK-NUM-PESSOA EQUAL 0 */

            if (LINK_PARAMETRO.LINK_NUM_PESSOA == 0)
            {

                /*" -375- MOVE 'GE0500B - INFORME O NUMERO DA PESSOA PARA CONSULTA' TO LINK-MSG-ERRO */
                _.Move("GE0500B - INFORME O NUMERO DA PESSOA PARA CONSULTA", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                /*" -375- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA(); //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R020_EXIT*/

        [StopWatch]
        /*" R200-CONSULTA-PF */
        private void R200_CONSULTA_PF(bool isPerform = false)
        {
            /*" -383- MOVE '0006' TO WNR-EXEC-SQL */
            _.Move("0006", AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL);

            /*" -385- INITIALIZE DCLOD-PESSOA DCLOD-PESSOA-FISICA */
            _.Initialize(
                OD001.DCLOD_PESSOA
                , OD002.DCLOD_PESSOA_FISICA
            );

            /*" -387- MOVE LINK-NUM-PESSOA TO OD001-NUM-PESSOA. */
            _.Move(LINK_PARAMETRO.LINK_NUM_PESSOA, OD001.DCLOD_PESSOA.OD001_NUM_PESSOA);

            /*" -439- PERFORM R200_CONSULTA_PF_DB_SELECT_1 */

            R200_CONSULTA_PF_DB_SELECT_1();

            /*" -442- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -445- MOVE 'GE0500B - PESSOA FISICA NAO ENCONTRADA P/ ID INFORMADO' TO LINK-MSG-ERRO */
                _.Move("GE0500B - PESSOA FISICA NAO ENCONTRADA P/ ID INFORMADO", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                /*" -447- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA(); //GOTO
                return;
            }


            /*" -448- IF (SQLCODE NOT EQUAL ZEROS) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -450- MOVE 'GE0500B - ERRO NA LEITURA DA PF P/ ID INFORMADO' TO W-LINK-MENSAGEM */
                _.Move("GE0500B - ERRO NA LEITURA DA PF P/ ID INFORMADO", W_LINK_MSG_ERRO.W_LINK_MENSAGEM);

                /*" -451- MOVE SQLCODE TO W-LINK-SQLCODE */
                _.Move(DB.SQLCODE, W_LINK_MSG_ERRO.W_LINK_SQLCODE);

                /*" -452- MOVE WNR-EXEC-SQL TO W-WNR-EXEC-SQL */
                _.Move(AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL, W_LINK_MSG_ERRO.W_WNR_EXEC_SQL);

                /*" -453- MOVE W-LINK-MSG-ERRO TO LINK-MSG-ERRO */
                _.Move(W_LINK_MSG_ERRO, LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                /*" -454- MOVE 'PESSOA E PF' TO LINK-NOME-TABELA */
                _.Move("PESSOA E PF", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_NOME_TABELA);

                /*" -456- DISPLAY 'GE0500B - ERRO ACESSO JOIN ODS_PESSOA X ODS_PESSO 'A_FISICA SQLCODE ' W-LINK-SQLCODE */

                $"GE0500B - ERRO ACESSO JOIN ODS_PESSOA X ODS_PESSO A_FISICA{DB.SQLCODE}{W_LINK_MSG_ERRO.W_LINK_SQLCODE}"
                .Display();

                /*" -458- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA(); //GOTO
                return;
            }


            /*" -459- IF VIND-NULL01 LESS ZEROS */

            if (VIND_NULL01 < 00)
            {

                /*" -461- MOVE SPACES TO OD002-DTH-NASCIMENTO. */
                _.Move("", OD002.DCLOD_PESSOA_FISICA.OD002_DTH_NASCIMENTO);
            }


            /*" -462- IF VIND-NULL02 LESS ZEROS */

            if (VIND_NULL02 < 00)
            {

                /*" -464- MOVE SPACES TO OD002-STA-SEXO. */
                _.Move("", OD002.DCLOD_PESSOA_FISICA.OD002_STA_SEXO);
            }


            /*" -465- IF VIND-NULL03 LESS ZEROS */

            if (VIND_NULL03 < 00)
            {

                /*" -467- MOVE SPACES TO OD002-IND-ESTADO-CIVIL. */
                _.Move("", OD002.DCLOD_PESSOA_FISICA.OD002_IND_ESTADO_CIVIL);
            }


            /*" -468- IF VIND-NULL04 LESS ZEROS */

            if (VIND_NULL04 < 00)
            {

                /*" -470- MOVE SPACES TO OD002-NOM-TRATAMENTO. */
                _.Move("", OD002.DCLOD_PESSOA_FISICA.OD002_NOM_TRATAMENTO);
            }


            /*" -471- IF VIND-NULL05 LESS ZEROS */

            if (VIND_NULL05 < 00)
            {

                /*" -473- MOVE SPACES TO OD002-COD-UF. */
                _.Move("", OD002.DCLOD_PESSOA_FISICA.OD002_COD_UF);
            }


            /*" -474- IF VIND-NULL10 LESS ZEROS */

            if (VIND_NULL10 < 00)
            {

                /*" -476- MOVE SPACES TO OD002-NOM-REDUZIDO. */
                _.Move("", OD002.DCLOD_PESSOA_FISICA.OD002_NOM_REDUZIDO);
            }


            /*" -477- IF VIND-NULL11 LESS ZEROS */

            if (VIND_NULL11 < 00)
            {

                /*" -479- MOVE SPACES TO OD002-COD-CBO. */
                _.Move("", OD002.DCLOD_PESSOA_FISICA.OD002_COD_CBO);
            }


            /*" -480- IF VIND-NULL12 LESS ZEROS */

            if (VIND_NULL12 < 00)
            {

                /*" -482- MOVE SPACES TO OD002-NOM-PRIMEIRO. */
                _.Move("", OD002.DCLOD_PESSOA_FISICA.OD002_NOM_PRIMEIRO);
            }


            /*" -483- IF VIND-NULL13 LESS ZEROS */

            if (VIND_NULL13 < 00)
            {

                /*" -486- MOVE SPACES TO OD002-NOM-ULTIMO. */
                _.Move("", OD002.DCLOD_PESSOA_FISICA.OD002_NOM_ULTIMO);
            }


            /*" -487- IF VIND-NULL06 LESS ZEROS */

            if (VIND_NULL06 < 00)
            {

                /*" -489- MOVE ZEROS TO OD002-NUM-MUNICIPIO. */
                _.Move(0, OD002.DCLOD_PESSOA_FISICA.OD002_NUM_MUNICIPIO);
            }


            /*" -490- IF VIND-NULL07 LESS ZEROS */

            if (VIND_NULL07 < 00)
            {

                /*" -492- MOVE ZEROS TO OD002-NUM-INSC-SOCIAL. */
                _.Move(0, OD002.DCLOD_PESSOA_FISICA.OD002_NUM_INSC_SOCIAL);
            }


            /*" -493- IF VIND-NULL08 LESS ZEROS */

            if (VIND_NULL08 < 00)
            {

                /*" -495- MOVE ZEROS TO OD002-NUM-DV-INSC-SOCIAL. */
                _.Move(0, OD002.DCLOD_PESSOA_FISICA.OD002_NUM_DV_INSC_SOCIAL);
            }


            /*" -496- IF VIND-NULL09 LESS ZEROS */

            if (VIND_NULL09 < 00)
            {

                /*" -499- MOVE ZEROS TO OD002-NUM-GRAU-INSTRUCAO. */
                _.Move(0, OD002.DCLOD_PESSOA_FISICA.OD002_NUM_GRAU_INSTRUCAO);
            }


            /*" -500- MOVE OD001-NUM-PESSOA TO LINK-NUM-PESSOA */
            _.Move(OD001.DCLOD_PESSOA.OD001_NUM_PESSOA, LINK_PARAMETRO.LINK_NUM_PESSOA);

            /*" -501- MOVE OD001-DTH-CADASTRAMENTO TO LINK-DTH-CADASTRAMENTO */
            _.Move(OD001.DCLOD_PESSOA.OD001_DTH_CADASTRAMENTO, LINK_PARAMETRO.LINK_DTH_CADASTRAMENTO);

            /*" -502- MOVE OD001-NUM-DV-PESSOA TO LINK-NUM-DV-PESSOA */
            _.Move(OD001.DCLOD_PESSOA.OD001_NUM_DV_PESSOA, LINK_PARAMETRO.LINK_NUM_DV_PESSOA);

            /*" -503- MOVE OD001-IND-PESSOA TO LINK-IND-PESSOA */
            _.Move(OD001.DCLOD_PESSOA.OD001_IND_PESSOA, LINK_PARAMETRO.LINK_IND_PESSOA);

            /*" -504- MOVE OD001-STA-INF-INTEGRA TO LINK-STA-INF-INTEGRA */
            _.Move(OD001.DCLOD_PESSOA.OD001_STA_INF_INTEGRA, LINK_PARAMETRO.LINK_STA_INF_INTEGRA);

            /*" -505- MOVE OD002-NUM-CPF TO LINK-NUM-CPF */
            _.Move(OD002.DCLOD_PESSOA_FISICA.OD002_NUM_CPF, LINK_PARAMETRO.LINK_NUM_CPF);

            /*" -506- MOVE OD002-NUM-DV-CPF TO LINK-NUM-DV-CPF */
            _.Move(OD002.DCLOD_PESSOA_FISICA.OD002_NUM_DV_CPF, LINK_PARAMETRO.LINK_NUM_DV_CPF);

            /*" -507- MOVE OD002-NOM-PESSOA-TEXT TO LINK-NOM-PESSOA */
            _.Move(OD002.DCLOD_PESSOA_FISICA.OD002_NOM_PESSOA.OD002_NOM_PESSOA_TEXT, LINK_PARAMETRO.LINK_NOM_PESSOA);

            /*" -508- MOVE OD002-DTH-NASCIMENTO TO LINK-DTH-NASCIMENTO */
            _.Move(OD002.DCLOD_PESSOA_FISICA.OD002_DTH_NASCIMENTO, LINK_PARAMETRO.LINK_DTH_NASCIMENTO);

            /*" -509- MOVE OD002-STA-SEXO TO LINK-STA-SEXO */
            _.Move(OD002.DCLOD_PESSOA_FISICA.OD002_STA_SEXO, LINK_PARAMETRO.LINK_STA_SEXO);

            /*" -510- MOVE OD002-IND-ESTADO-CIVIL TO LINK-IND-ESTADO-CIVIL */
            _.Move(OD002.DCLOD_PESSOA_FISICA.OD002_IND_ESTADO_CIVIL, LINK_PARAMETRO.LINK_IND_ESTADO_CIVIL);

            /*" -511- MOVE OD002-STA-PESSOA TO LINK-STA-PESSOA */
            _.Move(OD002.DCLOD_PESSOA_FISICA.OD002_STA_PESSOA, LINK_PARAMETRO.LINK_STA_PESSOA);

            /*" -512- MOVE OD002-NOM-TRATAMENTO TO LINK-NOM-TRATAMENTO */
            _.Move(OD002.DCLOD_PESSOA_FISICA.OD002_NOM_TRATAMENTO, LINK_PARAMETRO.LINK_NOM_TRATAMENTO);

            /*" -513- MOVE OD002-COD-UF TO LINK-COD-UF */
            _.Move(OD002.DCLOD_PESSOA_FISICA.OD002_COD_UF, LINK_PARAMETRO.LINK_COD_UF);

            /*" -514- MOVE OD002-NUM-MUNICIPIO TO LINK-NUM-MUNICIPIO */
            _.Move(OD002.DCLOD_PESSOA_FISICA.OD002_NUM_MUNICIPIO, LINK_PARAMETRO.LINK_NUM_MUNICIPIO);

            /*" -515- MOVE OD002-NUM-INSC-SOCIAL TO LINK-NUM-INSC-SOCIAL */
            _.Move(OD002.DCLOD_PESSOA_FISICA.OD002_NUM_INSC_SOCIAL, LINK_PARAMETRO.LINK_NUM_INSC_SOCIAL);

            /*" -516- MOVE OD002-NUM-DV-INSC-SOCIAL TO LINK-NUM-DV-INSC-SOCIAL */
            _.Move(OD002.DCLOD_PESSOA_FISICA.OD002_NUM_DV_INSC_SOCIAL, LINK_PARAMETRO.LINK_NUM_DV_INSC_SOCIAL);

            /*" -517- MOVE OD002-NUM-GRAU-INSTRUCAO TO LINK-NUM-GRAU-INSTRUCAO */
            _.Move(OD002.DCLOD_PESSOA_FISICA.OD002_NUM_GRAU_INSTRUCAO, LINK_PARAMETRO.LINK_NUM_GRAU_INSTRUCAO);

            /*" -518- MOVE OD002-NOM-REDUZIDO TO LINK-NOM-REDUZIDO */
            _.Move(OD002.DCLOD_PESSOA_FISICA.OD002_NOM_REDUZIDO, LINK_PARAMETRO.LINK_NOM_REDUZIDO);

            /*" -519- MOVE OD002-COD-CBO TO LINK-COD-CBO */
            _.Move(OD002.DCLOD_PESSOA_FISICA.OD002_COD_CBO, LINK_PARAMETRO.LINK_COD_CBO);

            /*" -520- MOVE OD002-NOM-PRIMEIRO TO LINK-NOM-PRIMEIRO */
            _.Move(OD002.DCLOD_PESSOA_FISICA.OD002_NOM_PRIMEIRO, LINK_PARAMETRO.LINK_NOM_PRIMEIRO);

            /*" -520- MOVE OD002-NOM-ULTIMO TO LINK-NOM-ULTIMO . */
            _.Move(OD002.DCLOD_PESSOA_FISICA.OD002_NOM_ULTIMO, LINK_PARAMETRO.LINK_NOM_ULTIMO);

        }

        [StopWatch]
        /*" R200-CONSULTA-PF-DB-SELECT-1 */
        public void R200_CONSULTA_PF_DB_SELECT_1()
        {
            /*" -439- EXEC SQL SELECT A.NUM_PESSOA , A.DTH_CADASTRAMENTO , A.NUM_DV_PESSOA , A.IND_PESSOA , A.STA_INF_INTEGRA , B.NUM_PESSOA , B.NUM_CPF , B.NUM_DV_CPF , B.NOM_PESSOA , B.DTH_NASCIMENTO , B.STA_SEXO , B.IND_ESTADO_CIVIL , B.STA_PESSOA , B.NOM_TRATAMENTO , B.COD_UF , B.NUM_MUNICIPIO , B.NUM_INSC_SOCIAL , B.NUM_DV_INSC_SOCIAL , B.NUM_GRAU_INSTRUCAO , B.NOM_REDUZIDO , B.COD_CBO , B.NOM_PRIMEIRO , B.NOM_ULTIMO INTO :OD001-NUM-PESSOA , :OD001-DTH-CADASTRAMENTO , :OD001-NUM-DV-PESSOA , :OD001-IND-PESSOA , :OD001-STA-INF-INTEGRA , :OD002-NUM-PESSOA , :OD002-NUM-CPF , :OD002-NUM-DV-CPF , :OD002-NOM-PESSOA , :OD002-DTH-NASCIMENTO:VIND-NULL01 , :OD002-STA-SEXO:VIND-NULL02 , :OD002-IND-ESTADO-CIVIL:VIND-NULL03 , :OD002-STA-PESSOA , :OD002-NOM-TRATAMENTO:VIND-NULL04 , :OD002-COD-UF:VIND-NULL05 , :OD002-NUM-MUNICIPIO:VIND-NULL06 , :OD002-NUM-INSC-SOCIAL:VIND-NULL07 , :OD002-NUM-DV-INSC-SOCIAL:VIND-NULL08 , :OD002-NUM-GRAU-INSTRUCAO:VIND-NULL09 , :OD002-NOM-REDUZIDO:VIND-NULL10 , :OD002-COD-CBO:VIND-NULL11 , :OD002-NOM-PRIMEIRO:VIND-NULL12 , :OD002-NOM-ULTIMO:VIND-NULL13 FROM ODS.OD_PESSOA A, ODS.OD_PESSOA_FISICA B WHERE A.NUM_PESSOA = :OD001-NUM-PESSOA AND B.NUM_PESSOA = A.NUM_PESSOA WITH UR END-EXEC. */

            var r200_CONSULTA_PF_DB_SELECT_1_Query1 = new R200_CONSULTA_PF_DB_SELECT_1_Query1()
            {
                OD001_NUM_PESSOA = OD001.DCLOD_PESSOA.OD001_NUM_PESSOA.ToString(),
            };

            var executed_1 = R200_CONSULTA_PF_DB_SELECT_1_Query1.Execute(r200_CONSULTA_PF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OD001_NUM_PESSOA, OD001.DCLOD_PESSOA.OD001_NUM_PESSOA);
                _.Move(executed_1.OD001_DTH_CADASTRAMENTO, OD001.DCLOD_PESSOA.OD001_DTH_CADASTRAMENTO);
                _.Move(executed_1.OD001_NUM_DV_PESSOA, OD001.DCLOD_PESSOA.OD001_NUM_DV_PESSOA);
                _.Move(executed_1.OD001_IND_PESSOA, OD001.DCLOD_PESSOA.OD001_IND_PESSOA);
                _.Move(executed_1.OD001_STA_INF_INTEGRA, OD001.DCLOD_PESSOA.OD001_STA_INF_INTEGRA);
                _.Move(executed_1.OD002_NUM_PESSOA, OD002.DCLOD_PESSOA_FISICA.OD002_NUM_PESSOA);
                _.Move(executed_1.OD002_NUM_CPF, OD002.DCLOD_PESSOA_FISICA.OD002_NUM_CPF);
                _.Move(executed_1.OD002_NUM_DV_CPF, OD002.DCLOD_PESSOA_FISICA.OD002_NUM_DV_CPF);
                _.Move(executed_1.OD002_NOM_PESSOA, OD002.DCLOD_PESSOA_FISICA.OD002_NOM_PESSOA);
                _.Move(executed_1.OD002_DTH_NASCIMENTO, OD002.DCLOD_PESSOA_FISICA.OD002_DTH_NASCIMENTO);
                _.Move(executed_1.VIND_NULL01, VIND_NULL01);
                _.Move(executed_1.OD002_STA_SEXO, OD002.DCLOD_PESSOA_FISICA.OD002_STA_SEXO);
                _.Move(executed_1.VIND_NULL02, VIND_NULL02);
                _.Move(executed_1.OD002_IND_ESTADO_CIVIL, OD002.DCLOD_PESSOA_FISICA.OD002_IND_ESTADO_CIVIL);
                _.Move(executed_1.VIND_NULL03, VIND_NULL03);
                _.Move(executed_1.OD002_STA_PESSOA, OD002.DCLOD_PESSOA_FISICA.OD002_STA_PESSOA);
                _.Move(executed_1.OD002_NOM_TRATAMENTO, OD002.DCLOD_PESSOA_FISICA.OD002_NOM_TRATAMENTO);
                _.Move(executed_1.VIND_NULL04, VIND_NULL04);
                _.Move(executed_1.OD002_COD_UF, OD002.DCLOD_PESSOA_FISICA.OD002_COD_UF);
                _.Move(executed_1.VIND_NULL05, VIND_NULL05);
                _.Move(executed_1.OD002_NUM_MUNICIPIO, OD002.DCLOD_PESSOA_FISICA.OD002_NUM_MUNICIPIO);
                _.Move(executed_1.VIND_NULL06, VIND_NULL06);
                _.Move(executed_1.OD002_NUM_INSC_SOCIAL, OD002.DCLOD_PESSOA_FISICA.OD002_NUM_INSC_SOCIAL);
                _.Move(executed_1.VIND_NULL07, VIND_NULL07);
                _.Move(executed_1.OD002_NUM_DV_INSC_SOCIAL, OD002.DCLOD_PESSOA_FISICA.OD002_NUM_DV_INSC_SOCIAL);
                _.Move(executed_1.VIND_NULL08, VIND_NULL08);
                _.Move(executed_1.OD002_NUM_GRAU_INSTRUCAO, OD002.DCLOD_PESSOA_FISICA.OD002_NUM_GRAU_INSTRUCAO);
                _.Move(executed_1.VIND_NULL09, VIND_NULL09);
                _.Move(executed_1.OD002_NOM_REDUZIDO, OD002.DCLOD_PESSOA_FISICA.OD002_NOM_REDUZIDO);
                _.Move(executed_1.VIND_NULL10, VIND_NULL10);
                _.Move(executed_1.OD002_COD_CBO, OD002.DCLOD_PESSOA_FISICA.OD002_COD_CBO);
                _.Move(executed_1.VIND_NULL11, VIND_NULL11);
                _.Move(executed_1.OD002_NOM_PRIMEIRO, OD002.DCLOD_PESSOA_FISICA.OD002_NOM_PRIMEIRO);
                _.Move(executed_1.VIND_NULL12, VIND_NULL12);
                _.Move(executed_1.OD002_NOM_ULTIMO, OD002.DCLOD_PESSOA_FISICA.OD002_NOM_ULTIMO);
                _.Move(executed_1.VIND_NULL13, VIND_NULL13);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R200_EXIT*/

        [StopWatch]
        /*" R100-INSERT-PF */
        private void R100_INSERT_PF(bool isPerform = false)
        {
            /*" -531- INITIALIZE DCLOD-PESSOA DCLOD-PESSOA-FISICA */
            _.Initialize(
                OD001.DCLOD_PESSOA
                , OD002.DCLOD_PESSOA_FISICA
            );

            /*" -533- MOVE '0002' TO WNR-EXEC-SQL */
            _.Move("0002", AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL);

            /*" -537- PERFORM R100_INSERT_PF_DB_SELECT_1 */

            R100_INSERT_PF_DB_SELECT_1();

            /*" -540- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -542- MOVE 'GE0500B - MAX PARA PEGAR NUMERO DA PESSOA' TO W-LINK-MENSAGEM */
                _.Move("GE0500B - MAX PARA PEGAR NUMERO DA PESSOA", W_LINK_MSG_ERRO.W_LINK_MENSAGEM);

                /*" -543- MOVE SQLCODE TO W-LINK-SQLCODE */
                _.Move(DB.SQLCODE, W_LINK_MSG_ERRO.W_LINK_SQLCODE);

                /*" -544- MOVE WNR-EXEC-SQL TO W-WNR-EXEC-SQL */
                _.Move(AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL, W_LINK_MSG_ERRO.W_WNR_EXEC_SQL);

                /*" -545- MOVE W-LINK-MSG-ERRO TO LINK-MSG-ERRO */
                _.Move(W_LINK_MSG_ERRO, LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                /*" -546- MOVE 'OD_PESSOA  ' TO LINK-NOME-TABELA */
                _.Move("OD_PESSOA  ", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_NOME_TABELA);

                /*" -547- DISPLAY 'GE0500B - ERRO MAX DA OD_PESSOA' */
                _.Display($"GE0500B - ERRO MAX DA OD_PESSOA");

                /*" -549- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA(); //GOTO
                return;
            }


            /*" -551- MOVE OD001-NUM-PESSOA TO LINK-NUM-PESSOA. */
            _.Move(OD001.DCLOD_PESSOA.OD001_NUM_PESSOA, LINK_PARAMETRO.LINK_NUM_PESSOA);

            /*" -553- MOVE HOST-CURRENT-TIMESTAMP TO OD001-DTH-CADASTRAMENTO */
            _.Move(AREA_DE_WORK.HOST_CURRENT_TIMESTAMP, OD001.DCLOD_PESSOA.OD001_DTH_CADASTRAMENTO);

            /*" -554- MOVE 0 TO OD001-NUM-DV-PESSOA */
            _.Move(0, OD001.DCLOD_PESSOA.OD001_NUM_DV_PESSOA);

            /*" -555- MOVE LINK-IND-PESSOA TO OD001-IND-PESSOA */
            _.Move(LINK_PARAMETRO.LINK_IND_PESSOA, OD001.DCLOD_PESSOA.OD001_IND_PESSOA);

            /*" -556- MOVE 'S' TO OD001-STA-INF-INTEGRA */
            _.Move("S", OD001.DCLOD_PESSOA.OD001_STA_INF_INTEGRA);

            /*" -557- MOVE OD001-NUM-PESSOA TO OD002-NUM-PESSOA */
            _.Move(OD001.DCLOD_PESSOA.OD001_NUM_PESSOA, OD002.DCLOD_PESSOA_FISICA.OD002_NUM_PESSOA);

            /*" -558- MOVE LINK-NUM-CPF TO OD002-NUM-CPF */
            _.Move(LINK_PARAMETRO.LINK_NUM_CPF, OD002.DCLOD_PESSOA_FISICA.OD002_NUM_CPF);

            /*" -560- MOVE LINK-NUM-DV-CPF TO OD002-NUM-DV-CPF */
            _.Move(LINK_PARAMETRO.LINK_NUM_DV_CPF, OD002.DCLOD_PESSOA_FISICA.OD002_NUM_DV_CPF);

            /*" -561- MOVE LINK-NOM-PESSOA TO W-TABELA-LIKE-NOME */
            _.Move(LINK_PARAMETRO.LINK_NOM_PESSOA, AREA_DE_WORK.W_TABELA_LIKE_NOME);

            /*" -561- MOVE 200 TO W-IND-NOME OD002-NOM-PESSOA-LEN. */
            _.Move(200, AREA_DE_WORK.W_IND_NOME, OD002.DCLOD_PESSOA_FISICA.OD002_NOM_PESSOA.OD002_NOM_PESSOA_LEN);

        }

        [StopWatch]
        /*" R100-INSERT-PF-DB-SELECT-1 */
        public void R100_INSERT_PF_DB_SELECT_1()
        {
            /*" -537- EXEC SQL SELECT VALUE(MAX(NUM_PESSOA),0) + 1 INTO :OD001-NUM-PESSOA FROM ODS.OD_PESSOA END-EXEC. */

            var r100_INSERT_PF_DB_SELECT_1_Query1 = new R100_INSERT_PF_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R100_INSERT_PF_DB_SELECT_1_Query1.Execute(r100_INSERT_PF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OD001_NUM_PESSOA, OD001.DCLOD_PESSOA.OD001_NUM_PESSOA);
            }


        }

        [StopWatch]
        /*" INICIO-LOOP-NOME */
        private void INICIO_LOOP_NOME(bool isPerform = false)
        {
            /*" -566- IF W-TAB-LIKE-NOME(W-IND-NOME) EQUAL ' ' */

            if (AREA_DE_WORK.W_TABELA_LIKE_NOME.W_TAB_LIKE_NOME[AREA_DE_WORK.W_IND_NOME] == " ")
            {

                /*" -567- COMPUTE W-IND-NOME = W-IND-NOME - 1 */
                AREA_DE_WORK.W_IND_NOME.Value = AREA_DE_WORK.W_IND_NOME - 1;

                /*" -568- IF W-IND-NOME EQUAL 0 */

                if (AREA_DE_WORK.W_IND_NOME == 0)
                {

                    /*" -570- MOVE 'SIENG1S - ERRO LOOP DO TAMANHO DO NOME' TO LINK-MSG-ERRO */
                    _.Move("SIENG1S - ERRO LOOP DO TAMANHO DO NOME", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                    /*" -571- DISPLAY 'WNR - ' WNR-EXEC-SQL ' ' LINK-MSG-ERRO */

                    $"WNR - {AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL} {LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO}"
                    .Display();

                    /*" -572- GO TO R9999-00-CANCELA-PROGRAMA */

                    R9999_00_CANCELA_PROGRAMA(); //GOTO
                    return;

                    /*" -573- ELSE */
                }
                else
                {


                    /*" -574- GO TO INICIO-LOOP-NOME */
                    new Task(() => INICIO_LOOP_NOME()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -575- ELSE */
                }

            }
            else
            {


                /*" -577- COMPUTE W-IND-NOME = W-IND-NOME + 1. */
                AREA_DE_WORK.W_IND_NOME.Value = AREA_DE_WORK.W_IND_NOME + 1;
            }


            /*" -579- MOVE W-IND-NOME TO OD002-NOM-PESSOA-LEN. */
            _.Move(AREA_DE_WORK.W_IND_NOME, OD002.DCLOD_PESSOA_FISICA.OD002_NOM_PESSOA.OD002_NOM_PESSOA_LEN);

            /*" -580- MOVE LINK-NOM-PESSOA TO OD002-NOM-PESSOA-TEXT */
            _.Move(LINK_PARAMETRO.LINK_NOM_PESSOA, OD002.DCLOD_PESSOA_FISICA.OD002_NOM_PESSOA.OD002_NOM_PESSOA_TEXT);

            /*" -581- MOVE LINK-DTH-NASCIMENTO TO OD002-DTH-NASCIMENTO */
            _.Move(LINK_PARAMETRO.LINK_DTH_NASCIMENTO, OD002.DCLOD_PESSOA_FISICA.OD002_DTH_NASCIMENTO);

            /*" -582- MOVE LINK-STA-SEXO TO OD002-STA-SEXO */
            _.Move(LINK_PARAMETRO.LINK_STA_SEXO, OD002.DCLOD_PESSOA_FISICA.OD002_STA_SEXO);

            /*" -583- MOVE LINK-IND-ESTADO-CIVIL TO OD002-IND-ESTADO-CIVIL */
            _.Move(LINK_PARAMETRO.LINK_IND_ESTADO_CIVIL, OD002.DCLOD_PESSOA_FISICA.OD002_IND_ESTADO_CIVIL);

            /*" -584- MOVE LINK-STA-PESSOA TO OD002-STA-PESSOA */
            _.Move(LINK_PARAMETRO.LINK_STA_PESSOA, OD002.DCLOD_PESSOA_FISICA.OD002_STA_PESSOA);

            /*" -585- MOVE LINK-NOM-TRATAMENTO TO OD002-NOM-TRATAMENTO */
            _.Move(LINK_PARAMETRO.LINK_NOM_TRATAMENTO, OD002.DCLOD_PESSOA_FISICA.OD002_NOM_TRATAMENTO);

            /*" -586- MOVE LINK-COD-UF TO OD002-COD-UF */
            _.Move(LINK_PARAMETRO.LINK_COD_UF, OD002.DCLOD_PESSOA_FISICA.OD002_COD_UF);

            /*" -587- MOVE LINK-NUM-MUNICIPIO TO OD002-NUM-MUNICIPIO */
            _.Move(LINK_PARAMETRO.LINK_NUM_MUNICIPIO, OD002.DCLOD_PESSOA_FISICA.OD002_NUM_MUNICIPIO);

            /*" -588- MOVE LINK-NUM-INSC-SOCIAL TO OD002-NUM-INSC-SOCIAL */
            _.Move(LINK_PARAMETRO.LINK_NUM_INSC_SOCIAL, OD002.DCLOD_PESSOA_FISICA.OD002_NUM_INSC_SOCIAL);

            /*" -589- MOVE LINK-NUM-DV-INSC-SOCIAL TO OD002-NUM-DV-INSC-SOCIAL */
            _.Move(LINK_PARAMETRO.LINK_NUM_DV_INSC_SOCIAL, OD002.DCLOD_PESSOA_FISICA.OD002_NUM_DV_INSC_SOCIAL);

            /*" -590- MOVE LINK-NUM-GRAU-INSTRUCAO TO OD002-NUM-GRAU-INSTRUCAO */
            _.Move(LINK_PARAMETRO.LINK_NUM_GRAU_INSTRUCAO, OD002.DCLOD_PESSOA_FISICA.OD002_NUM_GRAU_INSTRUCAO);

            /*" -591- MOVE LINK-NOM-REDUZIDO TO OD002-NOM-REDUZIDO */
            _.Move(LINK_PARAMETRO.LINK_NOM_REDUZIDO, OD002.DCLOD_PESSOA_FISICA.OD002_NOM_REDUZIDO);

            /*" -592- MOVE LINK-COD-CBO TO OD002-COD-CBO */
            _.Move(LINK_PARAMETRO.LINK_COD_CBO, OD002.DCLOD_PESSOA_FISICA.OD002_COD_CBO);

            /*" -593- MOVE LINK-NOM-PRIMEIRO TO OD002-NOM-PRIMEIRO */
            _.Move(LINK_PARAMETRO.LINK_NOM_PRIMEIRO, OD002.DCLOD_PESSOA_FISICA.OD002_NOM_PRIMEIRO);

            /*" -599- MOVE LINK-NOM-ULTIMO TO OD002-NOM-ULTIMO */
            _.Move(LINK_PARAMETRO.LINK_NOM_ULTIMO, OD002.DCLOD_PESSOA_FISICA.OD002_NOM_ULTIMO);

            /*" -600- IF OD002-NUM-MUNICIPIO EQUAL ZEROS */

            if (OD002.DCLOD_PESSOA_FISICA.OD002_NUM_MUNICIPIO == 00)
            {

                /*" -601- MOVE -1 TO VIND-NULL06 */
                _.Move(-1, VIND_NULL06);

                /*" -602- ELSE */
            }
            else
            {


                /*" -604- MOVE ZEROS TO VIND-NULL06. */
                _.Move(0, VIND_NULL06);
            }


            /*" -605- IF OD002-NUM-INSC-SOCIAL EQUAL ZEROS */

            if (OD002.DCLOD_PESSOA_FISICA.OD002_NUM_INSC_SOCIAL == 00)
            {

                /*" -606- MOVE -1 TO VIND-NULL07 */
                _.Move(-1, VIND_NULL07);

                /*" -607- ELSE */
            }
            else
            {


                /*" -609- MOVE ZEROS TO VIND-NULL07. */
                _.Move(0, VIND_NULL07);
            }


            /*" -610- IF OD002-NUM-DV-INSC-SOCIAL EQUAL ZEROS */

            if (OD002.DCLOD_PESSOA_FISICA.OD002_NUM_DV_INSC_SOCIAL == 00)
            {

                /*" -611- MOVE -1 TO VIND-NULL08 */
                _.Move(-1, VIND_NULL08);

                /*" -612- ELSE */
            }
            else
            {


                /*" -614- MOVE ZEROS TO VIND-NULL08. */
                _.Move(0, VIND_NULL08);
            }


            /*" -615- IF OD002-NUM-GRAU-INSTRUCAO EQUAL ZEROS */

            if (OD002.DCLOD_PESSOA_FISICA.OD002_NUM_GRAU_INSTRUCAO == 00)
            {

                /*" -616- MOVE -1 TO VIND-NULL09 */
                _.Move(-1, VIND_NULL09);

                /*" -617- ELSE */
            }
            else
            {


                /*" -619- MOVE ZEROS TO VIND-NULL09. */
                _.Move(0, VIND_NULL09);
            }


            /*" -620- IF OD002-DTH-NASCIMENTO EQUAL SPACES */

            if (OD002.DCLOD_PESSOA_FISICA.OD002_DTH_NASCIMENTO.IsEmpty())
            {

                /*" -621- MOVE -1 TO VIND-NULL01 */
                _.Move(-1, VIND_NULL01);

                /*" -622- ELSE */
            }
            else
            {


                /*" -624- MOVE ZEROS TO VIND-NULL01. */
                _.Move(0, VIND_NULL01);
            }


            /*" -625- IF OD002-STA-SEXO EQUAL SPACES */

            if (OD002.DCLOD_PESSOA_FISICA.OD002_STA_SEXO.IsEmpty())
            {

                /*" -626- MOVE -1 TO VIND-NULL02 */
                _.Move(-1, VIND_NULL02);

                /*" -627- ELSE */
            }
            else
            {


                /*" -629- MOVE ZEROS TO VIND-NULL02. */
                _.Move(0, VIND_NULL02);
            }


            /*" -630- IF OD002-IND-ESTADO-CIVIL EQUAL SPACES */

            if (OD002.DCLOD_PESSOA_FISICA.OD002_IND_ESTADO_CIVIL.IsEmpty())
            {

                /*" -631- MOVE -1 TO VIND-NULL03 */
                _.Move(-1, VIND_NULL03);

                /*" -632- ELSE */
            }
            else
            {


                /*" -634- MOVE ZEROS TO VIND-NULL03. */
                _.Move(0, VIND_NULL03);
            }


            /*" -635- IF OD002-NOM-TRATAMENTO EQUAL SPACES */

            if (OD002.DCLOD_PESSOA_FISICA.OD002_NOM_TRATAMENTO.IsEmpty())
            {

                /*" -636- MOVE -1 TO VIND-NULL04 */
                _.Move(-1, VIND_NULL04);

                /*" -637- ELSE */
            }
            else
            {


                /*" -639- MOVE ZEROS TO VIND-NULL04. */
                _.Move(0, VIND_NULL04);
            }


            /*" -640- IF OD002-COD-UF EQUAL SPACES */

            if (OD002.DCLOD_PESSOA_FISICA.OD002_COD_UF.IsEmpty())
            {

                /*" -641- MOVE -1 TO VIND-NULL05 */
                _.Move(-1, VIND_NULL05);

                /*" -642- ELSE */
            }
            else
            {


                /*" -644- MOVE ZEROS TO VIND-NULL05. */
                _.Move(0, VIND_NULL05);
            }


            /*" -645- IF OD002-NOM-REDUZIDO EQUAL SPACES */

            if (OD002.DCLOD_PESSOA_FISICA.OD002_NOM_REDUZIDO.IsEmpty())
            {

                /*" -646- MOVE -1 TO VIND-NULL10 */
                _.Move(-1, VIND_NULL10);

                /*" -647- ELSE */
            }
            else
            {


                /*" -649- MOVE ZEROS TO VIND-NULL10. */
                _.Move(0, VIND_NULL10);
            }


            /*" -650- IF OD002-COD-CBO EQUAL SPACES */

            if (OD002.DCLOD_PESSOA_FISICA.OD002_COD_CBO.IsEmpty())
            {

                /*" -651- MOVE -1 TO VIND-NULL11 */
                _.Move(-1, VIND_NULL11);

                /*" -652- ELSE */
            }
            else
            {


                /*" -654- MOVE ZEROS TO VIND-NULL11. */
                _.Move(0, VIND_NULL11);
            }


            /*" -655- IF OD002-NOM-PRIMEIRO EQUAL SPACES */

            if (OD002.DCLOD_PESSOA_FISICA.OD002_NOM_PRIMEIRO.IsEmpty())
            {

                /*" -656- MOVE -1 TO VIND-NULL12 */
                _.Move(-1, VIND_NULL12);

                /*" -657- ELSE */
            }
            else
            {


                /*" -659- MOVE ZEROS TO VIND-NULL12. */
                _.Move(0, VIND_NULL12);
            }


            /*" -660- IF OD002-NOM-ULTIMO EQUAL SPACES */

            if (OD002.DCLOD_PESSOA_FISICA.OD002_NOM_ULTIMO.IsEmpty())
            {

                /*" -661- MOVE -1 TO VIND-NULL13 */
                _.Move(-1, VIND_NULL13);

                /*" -662- ELSE */
            }
            else
            {


                /*" -669- MOVE ZEROS TO VIND-NULL13. */
                _.Move(0, VIND_NULL13);
            }


            /*" -671- MOVE '0006' TO WNR-EXEC-SQL */
            _.Move("0006", AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL);

            /*" -682- PERFORM INICIO_LOOP_NOME_DB_INSERT_1 */

            INICIO_LOOP_NOME_DB_INSERT_1();

            /*" -685- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -687- MOVE 'GE0500B - ERRO INSERT OD_PESSOA' TO W-LINK-MENSAGEM */
                _.Move("GE0500B - ERRO INSERT OD_PESSOA", W_LINK_MSG_ERRO.W_LINK_MENSAGEM);

                /*" -688- MOVE SQLCODE TO W-LINK-SQLCODE */
                _.Move(DB.SQLCODE, W_LINK_MSG_ERRO.W_LINK_SQLCODE);

                /*" -689- MOVE WNR-EXEC-SQL TO W-WNR-EXEC-SQL */
                _.Move(AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL, W_LINK_MSG_ERRO.W_WNR_EXEC_SQL);

                /*" -690- MOVE W-LINK-MSG-ERRO TO LINK-MSG-ERRO */
                _.Move(W_LINK_MSG_ERRO, LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                /*" -691- MOVE 'OD_PESSOA  ' TO LINK-NOME-TABELA */
                _.Move("OD_PESSOA  ", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_NOME_TABELA);

                /*" -693- DISPLAY 'GE0500B - ERRO INSERT OD_PESSOA SQLCODE ' W-LINK-SQLCODE */
                _.Display($"GE0500B - ERRO INSERT OD_PESSOA SQLCODE {W_LINK_MSG_ERRO.W_LINK_SQLCODE}");

                /*" -695- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA(); //GOTO
                return;
            }


            /*" -697- MOVE '0006' TO WNR-EXEC-SQL */
            _.Move("0006", AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL);

            /*" -734- PERFORM INICIO_LOOP_NOME_DB_INSERT_2 */

            INICIO_LOOP_NOME_DB_INSERT_2();

            /*" -737- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -739- MOVE 'GE0500B - ERRO INSERT OD_PESSOA_FISICA' TO W-LINK-MENSAGEM */
                _.Move("GE0500B - ERRO INSERT OD_PESSOA_FISICA", W_LINK_MSG_ERRO.W_LINK_MENSAGEM);

                /*" -740- MOVE SQLCODE TO W-LINK-SQLCODE */
                _.Move(DB.SQLCODE, W_LINK_MSG_ERRO.W_LINK_SQLCODE);

                /*" -741- MOVE WNR-EXEC-SQL TO W-WNR-EXEC-SQL */
                _.Move(AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL, W_LINK_MSG_ERRO.W_WNR_EXEC_SQL);

                /*" -742- MOVE W-LINK-MSG-ERRO TO LINK-MSG-ERRO */
                _.Move(W_LINK_MSG_ERRO, LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO);

                /*" -743- MOVE 'OD_PESSOA_FISICA' TO LINK-NOME-TABELA */
                _.Move("OD_PESSOA_FISICA", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_NOME_TABELA);

                /*" -745- DISPLAY 'GE0500B - ERRO INSERT OD_PESSOA_FISICA SQLCODE ' W-LINK-SQLCODE */
                _.Display($"GE0500B - ERRO INSERT OD_PESSOA_FISICA SQLCODE {W_LINK_MSG_ERRO.W_LINK_SQLCODE}");

                /*" -745- GO TO R9999-00-CANCELA-PROGRAMA. */

                R9999_00_CANCELA_PROGRAMA(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" INICIO-LOOP-NOME-DB-INSERT-1 */
        public void INICIO_LOOP_NOME_DB_INSERT_1()
        {
            /*" -682- EXEC SQL INSERT INTO ODS.OD_PESSOA (NUM_PESSOA , DTH_CADASTRAMENTO , NUM_DV_PESSOA , IND_PESSOA , STA_INF_INTEGRA) VALUES (:OD001-NUM-PESSOA , :OD001-DTH-CADASTRAMENTO , :OD001-NUM-DV-PESSOA , :OD001-IND-PESSOA , :OD001-STA-INF-INTEGRA) END-EXEC. */

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
            /*" -734- EXEC SQL INSERT INTO ODS.OD_PESSOA_FISICA (NUM_PESSOA , NUM_CPF , NUM_DV_CPF , NOM_PESSOA , DTH_NASCIMENTO , STA_SEXO , IND_ESTADO_CIVIL , STA_PESSOA , NOM_TRATAMENTO , COD_UF , NUM_MUNICIPIO , NUM_INSC_SOCIAL , NUM_DV_INSC_SOCIAL , NUM_GRAU_INSTRUCAO , NOM_REDUZIDO , COD_CBO , NOM_PRIMEIRO , NOM_ULTIMO ) VALUES (:OD002-NUM-PESSOA , :OD002-NUM-CPF , :OD002-NUM-DV-CPF , :OD002-NOM-PESSOA , :OD002-DTH-NASCIMENTO:VIND-NULL01 , :OD002-STA-SEXO:VIND-NULL02 , :OD002-IND-ESTADO-CIVIL:VIND-NULL03 , :OD002-STA-PESSOA , :OD002-NOM-TRATAMENTO:VIND-NULL04 , :OD002-COD-UF:VIND-NULL05 , :OD002-NUM-MUNICIPIO:VIND-NULL06 , :OD002-NUM-INSC-SOCIAL:VIND-NULL07 , :OD002-NUM-DV-INSC-SOCIAL:VIND-NULL08 , :OD002-NUM-GRAU-INSTRUCAO:VIND-NULL09 , :OD002-NOM-REDUZIDO:VIND-NULL10 , :OD002-COD-CBO:VIND-NULL11 , :OD002-NOM-PRIMEIRO:VIND-NULL12 , :OD002-NOM-ULTIMO:VIND-NULL13) END-EXEC. */

            var iNICIO_LOOP_NOME_DB_INSERT_2_Insert1 = new INICIO_LOOP_NOME_DB_INSERT_2_Insert1()
            {
                OD002_NUM_PESSOA = OD002.DCLOD_PESSOA_FISICA.OD002_NUM_PESSOA.ToString(),
                OD002_NUM_CPF = OD002.DCLOD_PESSOA_FISICA.OD002_NUM_CPF.ToString(),
                OD002_NUM_DV_CPF = OD002.DCLOD_PESSOA_FISICA.OD002_NUM_DV_CPF.ToString(),
                OD002_NOM_PESSOA = OD002.DCLOD_PESSOA_FISICA.OD002_NOM_PESSOA.ToString(),
                OD002_DTH_NASCIMENTO = OD002.DCLOD_PESSOA_FISICA.OD002_DTH_NASCIMENTO.ToString(),
                VIND_NULL01 = VIND_NULL01.ToString(),
                OD002_STA_SEXO = OD002.DCLOD_PESSOA_FISICA.OD002_STA_SEXO.ToString(),
                VIND_NULL02 = VIND_NULL02.ToString(),
                OD002_IND_ESTADO_CIVIL = OD002.DCLOD_PESSOA_FISICA.OD002_IND_ESTADO_CIVIL.ToString(),
                VIND_NULL03 = VIND_NULL03.ToString(),
                OD002_STA_PESSOA = OD002.DCLOD_PESSOA_FISICA.OD002_STA_PESSOA.ToString(),
                OD002_NOM_TRATAMENTO = OD002.DCLOD_PESSOA_FISICA.OD002_NOM_TRATAMENTO.ToString(),
                VIND_NULL04 = VIND_NULL04.ToString(),
                OD002_COD_UF = OD002.DCLOD_PESSOA_FISICA.OD002_COD_UF.ToString(),
                VIND_NULL05 = VIND_NULL05.ToString(),
                OD002_NUM_MUNICIPIO = OD002.DCLOD_PESSOA_FISICA.OD002_NUM_MUNICIPIO.ToString(),
                VIND_NULL06 = VIND_NULL06.ToString(),
                OD002_NUM_INSC_SOCIAL = OD002.DCLOD_PESSOA_FISICA.OD002_NUM_INSC_SOCIAL.ToString(),
                VIND_NULL07 = VIND_NULL07.ToString(),
                OD002_NUM_DV_INSC_SOCIAL = OD002.DCLOD_PESSOA_FISICA.OD002_NUM_DV_INSC_SOCIAL.ToString(),
                VIND_NULL08 = VIND_NULL08.ToString(),
                OD002_NUM_GRAU_INSTRUCAO = OD002.DCLOD_PESSOA_FISICA.OD002_NUM_GRAU_INSTRUCAO.ToString(),
                VIND_NULL09 = VIND_NULL09.ToString(),
                OD002_NOM_REDUZIDO = OD002.DCLOD_PESSOA_FISICA.OD002_NOM_REDUZIDO.ToString(),
                VIND_NULL10 = VIND_NULL10.ToString(),
                OD002_COD_CBO = OD002.DCLOD_PESSOA_FISICA.OD002_COD_CBO.ToString(),
                VIND_NULL11 = VIND_NULL11.ToString(),
                OD002_NOM_PRIMEIRO = OD002.DCLOD_PESSOA_FISICA.OD002_NOM_PRIMEIRO.ToString(),
                VIND_NULL12 = VIND_NULL12.ToString(),
                OD002_NOM_ULTIMO = OD002.DCLOD_PESSOA_FISICA.OD002_NOM_ULTIMO.ToString(),
                VIND_NULL13 = VIND_NULL13.ToString(),
            };

            INICIO_LOOP_NOME_DB_INSERT_2_Insert1.Execute(iNICIO_LOOP_NOME_DB_INSERT_2_Insert1);

        }

        [StopWatch]
        /*" R300-CONSULTA-PF */
        private void R300_CONSULTA_PF(bool isPerform = false)
        {
            /*" -756- MOVE '0006' TO WNR-EXEC-SQL. */
            _.Move("0006", AREA_DE_WORK.WABEND.WABEND2.WNR_EXEC_SQL);

            /*" -758- MOVE SPACES TO WFIM-MOVIMENTO. */
            _.Move("", AREA_DE_WORK.WFIM_MOVIMENTO);

            /*" -760- PERFORM R310-00-DECLARE-PFISICA THRU R310-EXIT. */

            R310_00_DECLARE_PFISICA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R310_EXIT*/


            /*" -761- PERFORM R320-00-FETCH-PFISICA THRU R320-EXIT UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_MOVIMENTO.IsEmpty()))
            {

                R320_00_FETCH_PFISICA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R320_EXIT*/

            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R300_EXIT*/

        [StopWatch]
        /*" R310-00-DECLARE-PFISICA */
        private void R310_00_DECLARE_PFISICA(bool isPerform = false)
        {
            /*" -770- INITIALIZE DCLOD-PESSOA DCLOD-PESSOA-FISICA */
            _.Initialize(
                OD001.DCLOD_PESSOA
                , OD002.DCLOD_PESSOA_FISICA
            );

            /*" -771- MOVE 'N' TO WTEM-PESSOA. */
            _.Move("N", AREA_DE_WORK.WTEM_PESSOA);

            /*" -772- MOVE LINK-NUM-CPF TO OD002-NUM-CPF. */
            _.Move(LINK_PARAMETRO.LINK_NUM_CPF, OD002.DCLOD_PESSOA_FISICA.OD002_NUM_CPF);

            /*" -774- MOVE LINK-NUM-DV-CPF TO OD002-NUM-DV-CPF. */
            _.Move(LINK_PARAMETRO.LINK_NUM_DV_CPF, OD002.DCLOD_PESSOA_FISICA.OD002_NUM_DV_CPF);

            /*" -806- PERFORM R310_00_DECLARE_PFISICA_DB_DECLARE_1 */

            R310_00_DECLARE_PFISICA_DB_DECLARE_1();

            /*" -808- PERFORM R310_00_DECLARE_PFISICA_DB_OPEN_1 */

            R310_00_DECLARE_PFISICA_DB_OPEN_1();

            /*" -811- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -812- MOVE 'N' TO WTEM-PESSOA */
                _.Move("N", AREA_DE_WORK.WTEM_PESSOA);

                /*" -812- MOVE 'S' TO WFIM-MOVIMENTO. */
                _.Move("S", AREA_DE_WORK.WFIM_MOVIMENTO);
            }


        }

        [StopWatch]
        /*" R310-00-DECLARE-PFISICA-DB-DECLARE-1 */
        public void R310_00_DECLARE_PFISICA_DB_DECLARE_1()
        {
            /*" -806- EXEC SQL DECLARE V0PFISICA CURSOR WITH HOLD FOR SELECT A.NUM_PESSOA , A.DTH_CADASTRAMENTO , A.NUM_DV_PESSOA , A.IND_PESSOA , A.STA_INF_INTEGRA , B.NUM_PESSOA , B.NUM_CPF , B.NUM_DV_CPF , B.NOM_PESSOA , B.DTH_NASCIMENTO , B.STA_SEXO , B.IND_ESTADO_CIVIL , B.STA_PESSOA , B.NOM_TRATAMENTO , B.COD_UF , B.NUM_MUNICIPIO , B.NUM_INSC_SOCIAL , B.NUM_DV_INSC_SOCIAL , B.NUM_GRAU_INSTRUCAO , B.NOM_REDUZIDO , B.COD_CBO , B.NOM_PRIMEIRO , B.NOM_ULTIMO FROM ODS.OD_PESSOA A, ODS.OD_PESSOA_FISICA B WHERE B.NUM_CPF = :OD002-NUM-CPF AND B.NUM_DV_CPF = :OD002-NUM-DV-CPF AND B.NUM_PESSOA = A.NUM_PESSOA ORDER BY A.NUM_PESSOA DESC END-EXEC. */
            V0PFISICA = new GE0500B_V0PFISICA(true);
            string GetQuery_V0PFISICA()
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
							B.NUM_CPF
							, 
							B.NUM_DV_CPF
							, 
							B.NOM_PESSOA
							, 
							B.DTH_NASCIMENTO
							, 
							B.STA_SEXO
							, 
							B.IND_ESTADO_CIVIL
							, 
							B.STA_PESSOA
							, 
							B.NOM_TRATAMENTO
							, 
							B.COD_UF
							, 
							B.NUM_MUNICIPIO
							, 
							B.NUM_INSC_SOCIAL
							, 
							B.NUM_DV_INSC_SOCIAL
							, 
							B.NUM_GRAU_INSTRUCAO
							, 
							B.NOM_REDUZIDO
							, 
							B.COD_CBO
							, 
							B.NOM_PRIMEIRO
							, 
							B.NOM_ULTIMO 
							FROM ODS.OD_PESSOA A
							, 
							ODS.OD_PESSOA_FISICA B 
							WHERE B.NUM_CPF = '{OD002.DCLOD_PESSOA_FISICA.OD002_NUM_CPF}' 
							AND B.NUM_DV_CPF = '{OD002.DCLOD_PESSOA_FISICA.OD002_NUM_DV_CPF}' 
							AND B.NUM_PESSOA = A.NUM_PESSOA 
							ORDER BY A.NUM_PESSOA DESC";

                return query;
            }
            V0PFISICA.GetQueryEvent += GetQuery_V0PFISICA;

        }

        [StopWatch]
        /*" R310-00-DECLARE-PFISICA-DB-OPEN-1 */
        public void R310_00_DECLARE_PFISICA_DB_OPEN_1()
        {
            /*" -808- EXEC SQL OPEN V0PFISICA END-EXEC. */

            V0PFISICA.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R310_EXIT*/

        [StopWatch]
        /*" R320-00-FETCH-PFISICA */
        private void R320_00_FETCH_PFISICA(bool isPerform = false)
        {
            /*" -843- PERFORM R320_00_FETCH_PFISICA_DB_FETCH_1 */

            R320_00_FETCH_PFISICA_DB_FETCH_1();

            /*" -846- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -846- PERFORM R320_00_FETCH_PFISICA_DB_CLOSE_1 */

                R320_00_FETCH_PFISICA_DB_CLOSE_1();

                /*" -848- MOVE 'S' TO WFIM-MOVIMENTO */
                _.Move("S", AREA_DE_WORK.WFIM_MOVIMENTO);

                /*" -849- MOVE 'N' TO WTEM-PESSOA */
                _.Move("N", AREA_DE_WORK.WTEM_PESSOA);

                /*" -852- GO TO R320-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R320_EXIT*/ //GOTO
                return;
            }


            /*" -853- MOVE SPACES TO AUX-NOM-PESSOA. */
            _.Move("", AREA_DE_WORK.AUX_NOM_PESSOA);

            /*" -855- MOVE OD002-NOM-PESSOA-TEXT TO AUX-NOM-PESSOA. */
            _.Move(OD002.DCLOD_PESSOA_FISICA.OD002_NOM_PESSOA.OD002_NOM_PESSOA_TEXT, AREA_DE_WORK.AUX_NOM_PESSOA);

            /*" -856- IF AUX-NOM-PESSOA NOT EQUAL LINK-NOM-PESSOA */

            if (AREA_DE_WORK.AUX_NOM_PESSOA != LINK_PARAMETRO.LINK_NOM_PESSOA)
            {

                /*" -857- MOVE 'N' TO WTEM-PESSOA */
                _.Move("N", AREA_DE_WORK.WTEM_PESSOA);

                /*" -860- GO TO R320-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R320_EXIT*/ //GOTO
                return;
            }


            /*" -860- PERFORM R320_00_FETCH_PFISICA_DB_CLOSE_2 */

            R320_00_FETCH_PFISICA_DB_CLOSE_2();

            /*" -862- MOVE 'S' TO WFIM-MOVIMENTO. */
            _.Move("S", AREA_DE_WORK.WFIM_MOVIMENTO);

            /*" -864- MOVE 'S' TO WTEM-PESSOA. */
            _.Move("S", AREA_DE_WORK.WTEM_PESSOA);

            /*" -865- IF VIND-NULL01 LESS ZEROS */

            if (VIND_NULL01 < 00)
            {

                /*" -867- MOVE SPACES TO OD002-DTH-NASCIMENTO. */
                _.Move("", OD002.DCLOD_PESSOA_FISICA.OD002_DTH_NASCIMENTO);
            }


            /*" -868- IF VIND-NULL02 LESS ZEROS */

            if (VIND_NULL02 < 00)
            {

                /*" -870- MOVE SPACES TO OD002-STA-SEXO. */
                _.Move("", OD002.DCLOD_PESSOA_FISICA.OD002_STA_SEXO);
            }


            /*" -871- IF VIND-NULL03 LESS ZEROS */

            if (VIND_NULL03 < 00)
            {

                /*" -873- MOVE SPACES TO OD002-IND-ESTADO-CIVIL. */
                _.Move("", OD002.DCLOD_PESSOA_FISICA.OD002_IND_ESTADO_CIVIL);
            }


            /*" -874- IF VIND-NULL04 LESS ZEROS */

            if (VIND_NULL04 < 00)
            {

                /*" -876- MOVE SPACES TO OD002-NOM-TRATAMENTO. */
                _.Move("", OD002.DCLOD_PESSOA_FISICA.OD002_NOM_TRATAMENTO);
            }


            /*" -877- IF VIND-NULL05 LESS ZEROS */

            if (VIND_NULL05 < 00)
            {

                /*" -879- MOVE SPACES TO OD002-COD-UF. */
                _.Move("", OD002.DCLOD_PESSOA_FISICA.OD002_COD_UF);
            }


            /*" -880- IF VIND-NULL10 LESS ZEROS */

            if (VIND_NULL10 < 00)
            {

                /*" -882- MOVE SPACES TO OD002-NOM-REDUZIDO. */
                _.Move("", OD002.DCLOD_PESSOA_FISICA.OD002_NOM_REDUZIDO);
            }


            /*" -883- IF VIND-NULL11 LESS ZEROS */

            if (VIND_NULL11 < 00)
            {

                /*" -885- MOVE SPACES TO OD002-COD-CBO. */
                _.Move("", OD002.DCLOD_PESSOA_FISICA.OD002_COD_CBO);
            }


            /*" -886- IF VIND-NULL12 LESS ZEROS */

            if (VIND_NULL12 < 00)
            {

                /*" -888- MOVE SPACES TO OD002-NOM-PRIMEIRO. */
                _.Move("", OD002.DCLOD_PESSOA_FISICA.OD002_NOM_PRIMEIRO);
            }


            /*" -889- IF VIND-NULL13 LESS ZEROS */

            if (VIND_NULL13 < 00)
            {

                /*" -892- MOVE SPACES TO OD002-NOM-ULTIMO. */
                _.Move("", OD002.DCLOD_PESSOA_FISICA.OD002_NOM_ULTIMO);
            }


            /*" -893- IF VIND-NULL06 LESS ZEROS */

            if (VIND_NULL06 < 00)
            {

                /*" -895- MOVE ZEROS TO OD002-NUM-MUNICIPIO. */
                _.Move(0, OD002.DCLOD_PESSOA_FISICA.OD002_NUM_MUNICIPIO);
            }


            /*" -896- IF VIND-NULL07 LESS ZEROS */

            if (VIND_NULL07 < 00)
            {

                /*" -898- MOVE ZEROS TO OD002-NUM-INSC-SOCIAL. */
                _.Move(0, OD002.DCLOD_PESSOA_FISICA.OD002_NUM_INSC_SOCIAL);
            }


            /*" -899- IF VIND-NULL08 LESS ZEROS */

            if (VIND_NULL08 < 00)
            {

                /*" -901- MOVE ZEROS TO OD002-NUM-DV-INSC-SOCIAL. */
                _.Move(0, OD002.DCLOD_PESSOA_FISICA.OD002_NUM_DV_INSC_SOCIAL);
            }


            /*" -902- IF VIND-NULL09 LESS ZEROS */

            if (VIND_NULL09 < 00)
            {

                /*" -905- MOVE ZEROS TO OD002-NUM-GRAU-INSTRUCAO. */
                _.Move(0, OD002.DCLOD_PESSOA_FISICA.OD002_NUM_GRAU_INSTRUCAO);
            }


            /*" -906- MOVE OD001-NUM-PESSOA TO LINK-NUM-PESSOA */
            _.Move(OD001.DCLOD_PESSOA.OD001_NUM_PESSOA, LINK_PARAMETRO.LINK_NUM_PESSOA);

            /*" -907- MOVE OD001-DTH-CADASTRAMENTO TO LINK-DTH-CADASTRAMENTO */
            _.Move(OD001.DCLOD_PESSOA.OD001_DTH_CADASTRAMENTO, LINK_PARAMETRO.LINK_DTH_CADASTRAMENTO);

            /*" -908- MOVE OD001-NUM-DV-PESSOA TO LINK-NUM-DV-PESSOA */
            _.Move(OD001.DCLOD_PESSOA.OD001_NUM_DV_PESSOA, LINK_PARAMETRO.LINK_NUM_DV_PESSOA);

            /*" -909- MOVE OD001-IND-PESSOA TO LINK-IND-PESSOA */
            _.Move(OD001.DCLOD_PESSOA.OD001_IND_PESSOA, LINK_PARAMETRO.LINK_IND_PESSOA);

            /*" -910- MOVE OD001-STA-INF-INTEGRA TO LINK-STA-INF-INTEGRA */
            _.Move(OD001.DCLOD_PESSOA.OD001_STA_INF_INTEGRA, LINK_PARAMETRO.LINK_STA_INF_INTEGRA);

            /*" -911- MOVE OD002-NUM-CPF TO LINK-NUM-CPF */
            _.Move(OD002.DCLOD_PESSOA_FISICA.OD002_NUM_CPF, LINK_PARAMETRO.LINK_NUM_CPF);

            /*" -912- MOVE OD002-NUM-DV-CPF TO LINK-NUM-DV-CPF */
            _.Move(OD002.DCLOD_PESSOA_FISICA.OD002_NUM_DV_CPF, LINK_PARAMETRO.LINK_NUM_DV_CPF);

            /*" -913- MOVE OD002-DTH-NASCIMENTO TO LINK-DTH-NASCIMENTO */
            _.Move(OD002.DCLOD_PESSOA_FISICA.OD002_DTH_NASCIMENTO, LINK_PARAMETRO.LINK_DTH_NASCIMENTO);

            /*" -914- MOVE OD002-STA-SEXO TO LINK-STA-SEXO */
            _.Move(OD002.DCLOD_PESSOA_FISICA.OD002_STA_SEXO, LINK_PARAMETRO.LINK_STA_SEXO);

            /*" -915- MOVE OD002-IND-ESTADO-CIVIL TO LINK-IND-ESTADO-CIVIL */
            _.Move(OD002.DCLOD_PESSOA_FISICA.OD002_IND_ESTADO_CIVIL, LINK_PARAMETRO.LINK_IND_ESTADO_CIVIL);

            /*" -916- MOVE OD002-STA-PESSOA TO LINK-STA-PESSOA */
            _.Move(OD002.DCLOD_PESSOA_FISICA.OD002_STA_PESSOA, LINK_PARAMETRO.LINK_STA_PESSOA);

            /*" -917- MOVE OD002-NOM-TRATAMENTO TO LINK-NOM-TRATAMENTO */
            _.Move(OD002.DCLOD_PESSOA_FISICA.OD002_NOM_TRATAMENTO, LINK_PARAMETRO.LINK_NOM_TRATAMENTO);

            /*" -918- MOVE OD002-COD-UF TO LINK-COD-UF */
            _.Move(OD002.DCLOD_PESSOA_FISICA.OD002_COD_UF, LINK_PARAMETRO.LINK_COD_UF);

            /*" -919- MOVE OD002-NUM-MUNICIPIO TO LINK-NUM-MUNICIPIO */
            _.Move(OD002.DCLOD_PESSOA_FISICA.OD002_NUM_MUNICIPIO, LINK_PARAMETRO.LINK_NUM_MUNICIPIO);

            /*" -920- MOVE OD002-NUM-INSC-SOCIAL TO LINK-NUM-INSC-SOCIAL */
            _.Move(OD002.DCLOD_PESSOA_FISICA.OD002_NUM_INSC_SOCIAL, LINK_PARAMETRO.LINK_NUM_INSC_SOCIAL);

            /*" -921- MOVE OD002-NUM-DV-INSC-SOCIAL TO LINK-NUM-DV-INSC-SOCIAL */
            _.Move(OD002.DCLOD_PESSOA_FISICA.OD002_NUM_DV_INSC_SOCIAL, LINK_PARAMETRO.LINK_NUM_DV_INSC_SOCIAL);

            /*" -922- MOVE OD002-NUM-GRAU-INSTRUCAO TO LINK-NUM-GRAU-INSTRUCAO */
            _.Move(OD002.DCLOD_PESSOA_FISICA.OD002_NUM_GRAU_INSTRUCAO, LINK_PARAMETRO.LINK_NUM_GRAU_INSTRUCAO);

            /*" -923- MOVE OD002-NOM-REDUZIDO TO LINK-NOM-REDUZIDO */
            _.Move(OD002.DCLOD_PESSOA_FISICA.OD002_NOM_REDUZIDO, LINK_PARAMETRO.LINK_NOM_REDUZIDO);

            /*" -924- MOVE OD002-COD-CBO TO LINK-COD-CBO */
            _.Move(OD002.DCLOD_PESSOA_FISICA.OD002_COD_CBO, LINK_PARAMETRO.LINK_COD_CBO);

            /*" -925- MOVE OD002-NOM-PRIMEIRO TO LINK-NOM-PRIMEIRO */
            _.Move(OD002.DCLOD_PESSOA_FISICA.OD002_NOM_PRIMEIRO, LINK_PARAMETRO.LINK_NOM_PRIMEIRO);

            /*" -925- MOVE OD002-NOM-ULTIMO TO LINK-NOM-ULTIMO. */
            _.Move(OD002.DCLOD_PESSOA_FISICA.OD002_NOM_ULTIMO, LINK_PARAMETRO.LINK_NOM_ULTIMO);

        }

        [StopWatch]
        /*" R320-00-FETCH-PFISICA-DB-FETCH-1 */
        public void R320_00_FETCH_PFISICA_DB_FETCH_1()
        {
            /*" -843- EXEC SQL FETCH V0PFISICA INTO :OD001-NUM-PESSOA , :OD001-DTH-CADASTRAMENTO , :OD001-NUM-DV-PESSOA , :OD001-IND-PESSOA , :OD001-STA-INF-INTEGRA , :OD002-NUM-PESSOA , :OD002-NUM-CPF , :OD002-NUM-DV-CPF , :OD002-NOM-PESSOA , :OD002-DTH-NASCIMENTO:VIND-NULL01 , :OD002-STA-SEXO:VIND-NULL02 , :OD002-IND-ESTADO-CIVIL:VIND-NULL03 , :OD002-STA-PESSOA , :OD002-NOM-TRATAMENTO:VIND-NULL04 , :OD002-COD-UF:VIND-NULL05 , :OD002-NUM-MUNICIPIO:VIND-NULL06 , :OD002-NUM-INSC-SOCIAL:VIND-NULL07 , :OD002-NUM-DV-INSC-SOCIAL:VIND-NULL08 , :OD002-NUM-GRAU-INSTRUCAO:VIND-NULL09 , :OD002-NOM-REDUZIDO:VIND-NULL10 , :OD002-COD-CBO:VIND-NULL11 , :OD002-NOM-PRIMEIRO:VIND-NULL12 , :OD002-NOM-ULTIMO:VIND-NULL13 END-EXEC. */

            if (V0PFISICA.Fetch())
            {
                _.Move(V0PFISICA.OD001_NUM_PESSOA, OD001.DCLOD_PESSOA.OD001_NUM_PESSOA);
                _.Move(V0PFISICA.OD001_DTH_CADASTRAMENTO, OD001.DCLOD_PESSOA.OD001_DTH_CADASTRAMENTO);
                _.Move(V0PFISICA.OD001_NUM_DV_PESSOA, OD001.DCLOD_PESSOA.OD001_NUM_DV_PESSOA);
                _.Move(V0PFISICA.OD001_IND_PESSOA, OD001.DCLOD_PESSOA.OD001_IND_PESSOA);
                _.Move(V0PFISICA.OD001_STA_INF_INTEGRA, OD001.DCLOD_PESSOA.OD001_STA_INF_INTEGRA);
                _.Move(V0PFISICA.OD002_NUM_PESSOA, OD002.DCLOD_PESSOA_FISICA.OD002_NUM_PESSOA);
                _.Move(V0PFISICA.OD002_NUM_CPF, OD002.DCLOD_PESSOA_FISICA.OD002_NUM_CPF);
                _.Move(V0PFISICA.OD002_NUM_DV_CPF, OD002.DCLOD_PESSOA_FISICA.OD002_NUM_DV_CPF);
                _.Move(V0PFISICA.OD002_NOM_PESSOA, OD002.DCLOD_PESSOA_FISICA.OD002_NOM_PESSOA);
                _.Move(V0PFISICA.OD002_DTH_NASCIMENTO, OD002.DCLOD_PESSOA_FISICA.OD002_DTH_NASCIMENTO);
                _.Move(V0PFISICA.VIND_NULL01, VIND_NULL01);
                _.Move(V0PFISICA.OD002_STA_SEXO, OD002.DCLOD_PESSOA_FISICA.OD002_STA_SEXO);
                _.Move(V0PFISICA.VIND_NULL02, VIND_NULL02);
                _.Move(V0PFISICA.OD002_IND_ESTADO_CIVIL, OD002.DCLOD_PESSOA_FISICA.OD002_IND_ESTADO_CIVIL);
                _.Move(V0PFISICA.VIND_NULL03, VIND_NULL03);
                _.Move(V0PFISICA.OD002_STA_PESSOA, OD002.DCLOD_PESSOA_FISICA.OD002_STA_PESSOA);
                _.Move(V0PFISICA.OD002_NOM_TRATAMENTO, OD002.DCLOD_PESSOA_FISICA.OD002_NOM_TRATAMENTO);
                _.Move(V0PFISICA.VIND_NULL04, VIND_NULL04);
                _.Move(V0PFISICA.OD002_COD_UF, OD002.DCLOD_PESSOA_FISICA.OD002_COD_UF);
                _.Move(V0PFISICA.VIND_NULL05, VIND_NULL05);
                _.Move(V0PFISICA.OD002_NUM_MUNICIPIO, OD002.DCLOD_PESSOA_FISICA.OD002_NUM_MUNICIPIO);
                _.Move(V0PFISICA.VIND_NULL06, VIND_NULL06);
                _.Move(V0PFISICA.OD002_NUM_INSC_SOCIAL, OD002.DCLOD_PESSOA_FISICA.OD002_NUM_INSC_SOCIAL);
                _.Move(V0PFISICA.VIND_NULL07, VIND_NULL07);
                _.Move(V0PFISICA.OD002_NUM_DV_INSC_SOCIAL, OD002.DCLOD_PESSOA_FISICA.OD002_NUM_DV_INSC_SOCIAL);
                _.Move(V0PFISICA.VIND_NULL08, VIND_NULL08);
                _.Move(V0PFISICA.OD002_NUM_GRAU_INSTRUCAO, OD002.DCLOD_PESSOA_FISICA.OD002_NUM_GRAU_INSTRUCAO);
                _.Move(V0PFISICA.VIND_NULL09, VIND_NULL09);
                _.Move(V0PFISICA.OD002_NOM_REDUZIDO, OD002.DCLOD_PESSOA_FISICA.OD002_NOM_REDUZIDO);
                _.Move(V0PFISICA.VIND_NULL10, VIND_NULL10);
                _.Move(V0PFISICA.OD002_COD_CBO, OD002.DCLOD_PESSOA_FISICA.OD002_COD_CBO);
                _.Move(V0PFISICA.VIND_NULL11, VIND_NULL11);
                _.Move(V0PFISICA.OD002_NOM_PRIMEIRO, OD002.DCLOD_PESSOA_FISICA.OD002_NOM_PRIMEIRO);
                _.Move(V0PFISICA.VIND_NULL12, VIND_NULL12);
                _.Move(V0PFISICA.OD002_NOM_ULTIMO, OD002.DCLOD_PESSOA_FISICA.OD002_NOM_ULTIMO);
                _.Move(V0PFISICA.VIND_NULL13, VIND_NULL13);
            }

        }

        [StopWatch]
        /*" R320-00-FETCH-PFISICA-DB-CLOSE-1 */
        public void R320_00_FETCH_PFISICA_DB_CLOSE_1()
        {
            /*" -846- EXEC SQL CLOSE V0PFISICA END-EXEC */

            V0PFISICA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R320_EXIT*/

        [StopWatch]
        /*" R320-00-FETCH-PFISICA-DB-CLOSE-2 */
        public void R320_00_FETCH_PFISICA_DB_CLOSE_2()
        {
            /*" -860- EXEC SQL CLOSE V0PFISICA END-EXEC. */

            V0PFISICA.Close();

        }

        [StopWatch]
        /*" R1000-DISPLAY-INSERT */
        private void R1000_DISPLAY_INSERT(bool isPerform = false)
        {
            /*" -932- DISPLAY 'OD001-NUM-PESSOA.........' OD001-NUM-PESSOA */
            _.Display($"OD001-NUM-PESSOA.........{OD001.DCLOD_PESSOA.OD001_NUM_PESSOA}");

            /*" -933- DISPLAY 'OD001-DTH-CADASTRAMENTO..' OD001-DTH-CADASTRAMENTO */
            _.Display($"OD001-DTH-CADASTRAMENTO..{OD001.DCLOD_PESSOA.OD001_DTH_CADASTRAMENTO}");

            /*" -934- DISPLAY 'OD001-NUM-DV-PESSOA......' OD001-NUM-DV-PESSOA */
            _.Display($"OD001-NUM-DV-PESSOA......{OD001.DCLOD_PESSOA.OD001_NUM_DV_PESSOA}");

            /*" -935- DISPLAY 'OD001-IND-PESSOA.........' OD001-IND-PESSOA */
            _.Display($"OD001-IND-PESSOA.........{OD001.DCLOD_PESSOA.OD001_IND_PESSOA}");

            /*" -936- DISPLAY 'OD001-STA-INF-INTEGRA....' OD001-STA-INF-INTEGRA */
            _.Display($"OD001-STA-INF-INTEGRA....{OD001.DCLOD_PESSOA.OD001_STA_INF_INTEGRA}");

            /*" -937- DISPLAY ' ' */
            _.Display($" ");

            /*" -938- DISPLAY 'NUM-PESSOA.......' OD002-NUM-PESSOA */
            _.Display($"NUM-PESSOA.......{OD002.DCLOD_PESSOA_FISICA.OD002_NUM_PESSOA}");

            /*" -939- DISPLAY 'NUM-CPF..........' OD002-NUM-CPF */
            _.Display($"NUM-CPF..........{OD002.DCLOD_PESSOA_FISICA.OD002_NUM_CPF}");

            /*" -940- DISPLAY 'NUM-DV-CPF.......' OD002-NUM-DV-CPF */
            _.Display($"NUM-DV-CPF.......{OD002.DCLOD_PESSOA_FISICA.OD002_NUM_DV_CPF}");

            /*" -941- DISPLAY 'NOM-PESSOA-LEN...' OD002-NOM-PESSOA-LEN */
            _.Display($"NOM-PESSOA-LEN...{OD002.DCLOD_PESSOA_FISICA.OD002_NOM_PESSOA.OD002_NOM_PESSOA_LEN}");

            /*" -942- DISPLAY 'NOM-PESSOA-TEXT..' OD002-NOM-PESSOA-TEXT */
            _.Display($"NOM-PESSOA-TEXT..{OD002.DCLOD_PESSOA_FISICA.OD002_NOM_PESSOA.OD002_NOM_PESSOA_TEXT}");

            /*" -943- DISPLAY 'DTH-NASCIMENTO...' OD002-DTH-NASCIMENTO */
            _.Display($"DTH-NASCIMENTO...{OD002.DCLOD_PESSOA_FISICA.OD002_DTH_NASCIMENTO}");

            /*" -944- DISPLAY 'STA-SEXO.........' OD002-STA-SEXO */
            _.Display($"STA-SEXO.........{OD002.DCLOD_PESSOA_FISICA.OD002_STA_SEXO}");

            /*" -945- DISPLAY 'IND-ESTADO-CIVIL.' OD002-IND-ESTADO-CIVIL */
            _.Display($"IND-ESTADO-CIVIL.{OD002.DCLOD_PESSOA_FISICA.OD002_IND_ESTADO_CIVIL}");

            /*" -946- DISPLAY 'STA-PESSOA.......' OD002-STA-PESSOA */
            _.Display($"STA-PESSOA.......{OD002.DCLOD_PESSOA_FISICA.OD002_STA_PESSOA}");

            /*" -947- DISPLAY 'NOM-TRATAMENTO...' OD002-NOM-TRATAMENTO */
            _.Display($"NOM-TRATAMENTO...{OD002.DCLOD_PESSOA_FISICA.OD002_NOM_TRATAMENTO}");

            /*" -948- DISPLAY 'COD-UF...........' OD002-COD-UF */
            _.Display($"COD-UF...........{OD002.DCLOD_PESSOA_FISICA.OD002_COD_UF}");

            /*" -949- DISPLAY 'NUM-MUNICIPIO....' OD002-NUM-MUNICIPIO */
            _.Display($"NUM-MUNICIPIO....{OD002.DCLOD_PESSOA_FISICA.OD002_NUM_MUNICIPIO}");

            /*" -950- DISPLAY 'NUM-INSC-SOCIAL..' OD002-NUM-INSC-SOCIAL */
            _.Display($"NUM-INSC-SOCIAL..{OD002.DCLOD_PESSOA_FISICA.OD002_NUM_INSC_SOCIAL}");

            /*" -951- DISPLAY 'NUM-DV-INSC-SOCIAL.' OD002-NUM-DV-INSC-SOCIAL */
            _.Display($"NUM-DV-INSC-SOCIAL.{OD002.DCLOD_PESSOA_FISICA.OD002_NUM_DV_INSC_SOCIAL}");

            /*" -952- DISPLAY 'NUM-GRAU-INSTRUCAO.' OD002-NUM-GRAU-INSTRUCAO */
            _.Display($"NUM-GRAU-INSTRUCAO.{OD002.DCLOD_PESSOA_FISICA.OD002_NUM_GRAU_INSTRUCAO}");

            /*" -953- DISPLAY 'NOM-REDUZIDO.......' OD002-NOM-REDUZIDO */
            _.Display($"NOM-REDUZIDO.......{OD002.DCLOD_PESSOA_FISICA.OD002_NOM_REDUZIDO}");

            /*" -954- DISPLAY 'COD-CBO............' OD002-COD-CBO */
            _.Display($"COD-CBO............{OD002.DCLOD_PESSOA_FISICA.OD002_COD_CBO}");

            /*" -955- DISPLAY 'NOM-PRIMEIRO.......' OD002-NOM-PRIMEIRO */
            _.Display($"NOM-PRIMEIRO.......{OD002.DCLOD_PESSOA_FISICA.OD002_NOM_PRIMEIRO}");

            /*" -955- DISPLAY 'NOM-ULTIMO.........' OD002-NOM-ULTIMO. */
            _.Display($"NOM-ULTIMO.........{OD002.DCLOD_PESSOA_FISICA.OD002_NOM_ULTIMO}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_EXIT*/

        [StopWatch]
        /*" R9999-00-CANCELA-PROGRAMA */
        private void R9999_00_CANCELA_PROGRAMA(bool isPerform = false)
        {
            /*" -962- MOVE 'SIM' TO LINK-IND-ERRO */
            _.Move("SIM", LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_IND_ERRO);

            /*" -965- MOVE SQLCODE TO LINK-SQLCODE WSQLCODE */
            _.Move(DB.SQLCODE, LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_SQLCODE, AREA_DE_WORK.WABEND.WABEND3.WSQLCODE);

            /*" -966- DISPLAY ' ' */
            _.Display($" ");

            /*" -967- DISPLAY '=====  PROGRAMA ABENDADO  =====' */
            _.Display($"=====  PROGRAMA ABENDADO  =====");

            /*" -968- DISPLAY ' ' */
            _.Display($" ");

            /*" -970- DISPLAY 'ERRO NA ROTINA GE0500B ' */
            _.Display($"ERRO NA ROTINA GE0500B ");

            /*" -971- DISPLAY 'LINK-MSG-ADICIONAL... ' LINK-MSG-ADICIONAL */
            _.Display($"LINK-MSG-ADICIONAL... {LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ADICIONAL}");

            /*" -972- DISPLAY 'LINK-IND-ERRO........ ' LINK-IND-ERRO */
            _.Display($"LINK-IND-ERRO........ {LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_IND_ERRO}");

            /*" -973- DISPLAY 'LINK-MSG-ERRO........ ' LINK-MSG-ERRO */
            _.Display($"LINK-MSG-ERRO........ {LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_MSG_ERRO}");

            /*" -974- DISPLAY 'LINK-SQLCODE......... ' LINK-SQLCODE */
            _.Display($"LINK-SQLCODE......... {LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_SQLCODE}");

            /*" -975- DISPLAY 'LINK-NOME-TABELA..... ' LINK-NOME-TABELA. */
            _.Display($"LINK-NOME-TABELA..... {LINK_PARAMETRO.LINK_PARAMETROS_SAIDA.LINK_NOME_TABELA}");

            /*" -976- DISPLAY WABEND1. */
            _.Display(AREA_DE_WORK.WABEND.WABEND1);

            /*" -977- DISPLAY WABEND2. */
            _.Display(AREA_DE_WORK.WABEND.WABEND2);

            /*" -981- DISPLAY WABEND3. */
            _.Display(AREA_DE_WORK.WABEND.WABEND3);

            /*" -987- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -987- GOBACK. */

            throw new GoBack();

        }
    }
}