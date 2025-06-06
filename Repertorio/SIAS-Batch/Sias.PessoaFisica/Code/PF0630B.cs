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
using Sias.PessoaFisica.DB2.PF0630B;

namespace Code
{
    public class PF0630B
    {
        public bool IsCall { get; set; }

        public PF0630B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO ............  GERA REGISTRO TIPO 12 NO ARQUIVO DE     *      */
        /*"      *                        PARAMETROS - FAIXAS DE TITULOS POR      *      */
        /*"      *                        PRODUTO                                 *      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA ..........  CHICON - PRODEXTER                      *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ..........  PF0630B                                 *      */
        /*"      *                                                                *      */
        /*"      *   DATA ..............  18/07/2002.                             *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *                    A L T E R A C O E S                         *      */
        /*"      ******************************************************************      */
        /*"      * 22-01-2010 - EDILANA CERQUEIRA     PROCURAR V.03               *      */
        /*"      * AUMENTO DA OCORRENCIAS DA TABELA DE FAIXAS DE 2000 PARA 4000.  *      */
        /*"      * ATENDE CADMUS 36081.                                           *      */
        /*"      ******************************************************************      */
        /*"      * 15-06-2007 - MAURICIO LINKE                                    *      */
        /*"      * AUMENTO DA OCORRENCIAS DA TABELA DE FAIXAS DE 1000 PARA 2000.  *      */
        /*"      ******************************************************************      */
        /*"      * NORA  C SANZ  (PROCURAR NSANZ)  12-01-2006                     *      */
        /*"      *                                                                *      */
        /*"      * AUMENTAR O TAMANHO DA TABELA TAB-FAIXAS DE 300 PARA 400        *      */
        /*"      ******************************************************************      */
        /*"1     ******************************************************************      */
        #endregion


        #region VARIABLES

        public FileBasis _PARAMETROS_IN { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis PARAMETROS_IN
        {
            get
            {
                _.Move(REG_PARAMETROS_IN, _PARAMETROS_IN); VarBasis.RedefinePassValue(REG_PARAMETROS_IN, _PARAMETROS_IN, REG_PARAMETROS_IN); return _PARAMETROS_IN;
            }
        }
        public FileBasis _PARAMETROS_OUT { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis PARAMETROS_OUT
        {
            get
            {
                _.Move(REG_PARAMETROS_OUT, _PARAMETROS_OUT); VarBasis.RedefinePassValue(REG_PARAMETROS_OUT, _PARAMETROS_OUT, REG_PARAMETROS_OUT); return _PARAMETROS_OUT;
            }
        }
        /*"01   REG-PARAMETROS-IN.*/
        public PF0630B_REG_PARAMETROS_IN REG_PARAMETROS_IN { get; set; } = new PF0630B_REG_PARAMETROS_IN();
        public class PF0630B_REG_PARAMETROS_IN : VarBasis
        {
            /*"  05 FILLER                             PIC X(200).*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");
            /*"01   REG-PARAMETROS-OUT.*/
        }
        public PF0630B_REG_PARAMETROS_OUT REG_PARAMETROS_OUT { get; set; } = new PF0630B_REG_PARAMETROS_OUT();
        public class PF0630B_REG_PARAMETROS_OUT : VarBasis
        {
            /*"  05 FILLER                             PIC X(200).*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis IX1 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"01           WSQLERRO.*/
        public PF0630B_WSQLERRO WSQLERRO { get; set; } = new PF0630B_WSQLERRO();
        public class PF0630B_WSQLERRO : VarBasis
        {
            /*"    10       FILLER               PIC  X(014) VALUE            ' *** SQLERRMC '.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @" *** SQLERRMC ");
            /*"    10       WSQLERRMC            PIC  X(070) VALUE  SPACES.*/
            public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
            /*"77  WS-CONT                           PIC 9(004) VALUE ZEROS.*/
        }
        public IntBasis WS_CONT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"77  WS-FIM                            PIC X(001) VALUE 'N'.*/
        public StringBasis WS_FIM { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"77  WS-FIM-CURS01                     PIC X(001) VALUE 'N'.*/
        public StringBasis WS_FIM_CURS01 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"77  WS-FIM-CURS02                     PIC X(001) VALUE 'N'.*/
        public StringBasis WS_FIM_CURS02 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"77  WS-FIM-FAIXAS                     PIC X(001) VALUE 'N'.*/
        public StringBasis WS_FIM_FAIXAS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"77  WS-LIDOS                          PIC 9(009) VALUE ZEROS.*/
        public IntBasis WS_LIDOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"77  WS-LIDOS-CURS01                   PIC 9(009) VALUE ZEROS.*/
        public IntBasis WS_LIDOS_CURS01 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"77  WS-LIDOS-CURS02                   PIC 9(009) VALUE ZEROS.*/
        public IntBasis WS_LIDOS_CURS02 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"77  WS-GRAVA                          PIC 9(009) VALUE ZEROS.*/
        public IntBasis WS_GRAVA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"77  WS-GRAVA-TIPO12                   PIC 9(009) VALUE ZEROS.*/
        public IntBasis WS_GRAVA_TIPO12 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"77  WS-AREA                           PIC X(200) VALUE ZEROS.*/
        public StringBasis WS_AREA { get; set; } = new StringBasis(new PIC("X", "200", "X(200)"), @"");
        /*"77  WS-FLAG                           PIC X(001) VALUE SPACES.*/
        public StringBasis WS_FLAG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77  WS-COD-PRODUTO-INI                PIC S9(004) COMP VALUE +0.*/
        public IntBasis WS_COD_PRODUTO_INI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WS-COD-PRODUTO-FIM                PIC S9(004) COMP VALUE +0.*/
        public IntBasis WS_COD_PRODUTO_FIM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WS-COD-PRODUTO-SIVPF              PIC S9(004) COMP VALUE +0.*/
        public IntBasis WS_COD_PRODUTO_SIVPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WS-PARAMETROS.*/
        public PF0630B_WS_PARAMETROS WS_PARAMETROS { get; set; } = new PF0630B_WS_PARAMETROS();
        public class PF0630B_WS_PARAMETROS : VarBasis
        {
            /*"    05  WS-ID-REG.*/
            public PF0630B_WS_ID_REG WS_ID_REG { get; set; } = new PF0630B_WS_ID_REG();
            public class PF0630B_WS_ID_REG : VarBasis
            {
                /*"     10 WS-IDENTIFICA                 PIC X(002)  VALUE SPACES.*/
                public StringBasis WS_IDENTIFICA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"     10 FILLER                        PIC X(012)  VALUE SPACES.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"");
                /*"    05  FILLER                        PIC X(186)  VALUE SPACES.*/
            }
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "186", "X(186)"), @"");
            /*"01  WS-PARAM.*/
        }
        public PF0630B_WS_PARAM WS_PARAM { get; set; } = new PF0630B_WS_PARAM();
        public class PF0630B_WS_PARAM : VarBasis
        {
            /*"    05  WS-IDENTIFICA-REG             PIC X(002)  VALUE SPACES.*/
            public StringBasis WS_IDENTIFICA_REG { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"    05  WS-AGENCIA                    PIC 9(004)  VALUE ZEROS.*/
            public IntBasis WS_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05  WS-OPERACAO                   PIC X(001)  VALUE SPACES.*/
            public StringBasis WS_OPERACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05  WS-QTD-OCORR                  PIC 9(002)  VALUE ZEROS.*/
            public IntBasis WS_QTD_OCORR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"    05  WS-PRODUTO-1                  PIC 9(003)  VALUE ZEROS.*/
            public IntBasis WS_PRODUTO_1 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"    05  WS-FXA-INI-1                  PIC 9(014)  VALUE ZEROS.*/
            public IntBasis WS_FXA_INI_1 { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"    05  WS-FXA-FIM-1                  PIC 9(014)  VALUE ZEROS.*/
            public IntBasis WS_FXA_FIM_1 { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"    05  WS-PRODUTO-2                  PIC 9(003)  VALUE ZEROS.*/
            public IntBasis WS_PRODUTO_2 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"    05  WS-FXA-INI-2                  PIC 9(014)  VALUE ZEROS.*/
            public IntBasis WS_FXA_INI_2 { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"    05  WS-FXA-FIM-2                  PIC 9(014)  VALUE ZEROS.*/
            public IntBasis WS_FXA_FIM_2 { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"    05  WS-PRODUTO-3                  PIC 9(003)  VALUE ZEROS.*/
            public IntBasis WS_PRODUTO_3 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"    05  WS-FXA-INI-3                  PIC 9(014)  VALUE ZEROS.*/
            public IntBasis WS_FXA_INI_3 { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"    05  WS-FXA-FIM-3                  PIC 9(014)  VALUE ZEROS.*/
            public IntBasis WS_FXA_FIM_3 { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"    05  WS-PRODUTO-4                  PIC 9(003)  VALUE ZEROS.*/
            public IntBasis WS_PRODUTO_4 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"    05  WS-FXA-INI-4                  PIC 9(014)  VALUE ZEROS.*/
            public IntBasis WS_FXA_INI_4 { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"    05  WS-FXA-FIM-4                  PIC 9(014)  VALUE ZEROS.*/
            public IntBasis WS_FXA_FIM_4 { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"    05  WS-PRODUTO-5                  PIC 9(003)  VALUE ZEROS.*/
            public IntBasis WS_PRODUTO_5 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"    05  WS-FXA-INI-5                  PIC 9(014)  VALUE ZEROS.*/
            public IntBasis WS_FXA_INI_5 { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"    05  WS-FXA-FIM-5                  PIC 9(014)  VALUE ZEROS.*/
            public IntBasis WS_FXA_FIM_5 { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"    05  WS-PRODUTO-6                  PIC 9(003)  VALUE ZEROS.*/
            public IntBasis WS_PRODUTO_6 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"    05  WS-FXA-INI-6                  PIC 9(014)  VALUE ZEROS.*/
            public IntBasis WS_FXA_INI_6 { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"    05  WS-FXA-FIM-6                  PIC 9(014)  VALUE ZEROS.*/
            public IntBasis WS_FXA_FIM_6 { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"    05  FILLER                        PIC X(005)  VALUE SPACES.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
            /*"01          TAB-FAIXAS.*/
        }
        public PF0630B_TAB_FAIXAS TAB_FAIXAS { get; set; } = new PF0630B_TAB_FAIXAS();
        public class PF0630B_TAB_FAIXAS : VarBasis
        {
            /*"    05        TAB-FAIXAS-OCORR    OCCURS 4000 TIMES                                INDEXED BY  IX1.*/
            public ListBasis<PF0630B_TAB_FAIXAS_OCORR> TAB_FAIXAS_OCORR { get; set; } = new ListBasis<PF0630B_TAB_FAIXAS_OCORR>(4000);
            public class PF0630B_TAB_FAIXAS_OCORR : VarBasis
            {
                /*"     10      TAB-FAIXA.*/
                public PF0630B_TAB_FAIXA TAB_FAIXA { get; set; } = new PF0630B_TAB_FAIXA();
                public class PF0630B_TAB_FAIXA : VarBasis
                {
                    /*"       15     TAB-PRODUTO         PIC  9(003).*/
                    public IntBasis TAB_PRODUTO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                    /*"       15     TAB-FAIXA-INI       PIC  9(014).*/
                    public IntBasis TAB_FAIXA_INI { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                    /*"       15     TAB-FAIXA-FIM       PIC  9(014).*/
                    public IntBasis TAB_FAIXA_FIM { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                    /*"01        WS-MSGERRO.*/
                }
            }
        }
        public PF0630B_WS_MSGERRO WS_MSGERRO { get; set; } = new PF0630B_WS_MSGERRO();
        public class PF0630B_WS_MSGERRO : VarBasis
        {
            /*"    05      WS-PARAGRAFO         PIC  X(040)   VALUE SPACES.*/
            public StringBasis WS_PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"    05      WS-NOME-TABELA       PIC  X(020)   VALUE SPACES.*/
            public StringBasis WS_NOME_TABELA { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
            /*"    05      WS-INSTRUCAO         PIC  X(020)   VALUE SPACES.*/
            public StringBasis WS_INSTRUCAO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
            /*"    05      WS-SQLCODE           PIC    ---9   VALUE ZEROS.*/
            public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("9", "4", "---9"));
            /*"    05      WS-MENSAGEM          PIC  X(100)   VALUE SPACES.*/
            public StringBasis WS_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "100", "X(100)"), @"");
            /*"    05      WS-CHAVE             PIC  X(350)   VALUE SPACES.*/
            public StringBasis WS_CHAVE { get; set; } = new StringBasis(new PIC("X", "350", "X(350)"), @"");
            /*"01        WS-CHAVE-ACESSO.*/
        }
        public PF0630B_WS_CHAVE_ACESSO WS_CHAVE_ACESSO { get; set; } = new PF0630B_WS_CHAVE_ACESSO();
        public class PF0630B_WS_CHAVE_ACESSO : VarBasis
        {
            /*"    05      WS-CAMPO1            PIC  X(013)   VALUE SPACES.*/
            public StringBasis WS_CAMPO1 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"");
            /*"    05      FILLER               PIC  X(001)   VALUE SPACES.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05      WS-CAMPO2            PIC  X(013)   VALUE SPACES.*/
            public StringBasis WS_CAMPO2 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"");
            /*"    05      FILLER               PIC  X(001)   VALUE SPACES.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05      WS-CAMPO3            PIC  X(010)   VALUE SPACES.*/
            public StringBasis WS_CAMPO3 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    05      FILLER               PIC  X(001)   VALUE SPACES.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05      WS-CAMPO4            PIC  X(010)   VALUE SPACES.*/
            public StringBasis WS_CAMPO4 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    05      FILLER               PIC  X(001)   VALUE SPACES.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05      WS-CAMPO5            PIC  X(010)   VALUE SPACES.*/
            public StringBasis WS_CAMPO5 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        }


        public Copies.LBFCT018 LBFCT018 { get; set; } = new Copies.LBFCT018();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.PRDSIVPF PRDSIVPF { get; set; } = new Dclgens.PRDSIVPF();
        public Dclgens.SICFAIRC SICFAIRC { get; set; } = new Dclgens.SICFAIRC();

        public PF0630B_CURS01 CURS01 { get; set; } = new PF0630B_CURS01(false);
        string GetQuery_CURS01()
        {
            var query = @$"SELECT A.COD_PRODUTO_SIVPF
							, B.NUM_SICOB_INI
							, B.NUM_SICOB_FIM
							FROM SEGUROS.PRODUTOS_SIVPF A
							, SEGUROS.SICOB_FAIXA_RCAP B WHERE A.COD_PRODUTO = B.COD_PRODUTO ORDER BY A.COD_PRODUTO_SIVPF
							, B.NUM_SICOB_INI
							, B.NUM_SICOB_FIM";

            return query;
        }


        public PF0630B_CURS02 CURS02 { get; set; } = new PF0630B_CURS02(true);
        string GetQuery_CURS02()
        {
            var query = @$"SELECT A.NUM_SICOB_INI
							, A.NUM_SICOB_FIM
							FROM SEGUROS.SICOB_FAIXA_RCAP A WHERE A.COD_PRODUTO = '{SICFAIRC.DCLSICOB_FAIXA_RCAP.SICFAIRC_COD_PRODUTO}' ORDER BY A.NUM_SICOB_INI
							, A.NUM_SICOB_FIM";

            return query;
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string PARAMETROS_IN_FILE_NAME_P, string PARAMETROS_OUT_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                PARAMETROS_IN.SetFile(PARAMETROS_IN_FILE_NAME_P);
                PARAMETROS_OUT.SetFile(PARAMETROS_OUT_FILE_NAME_P);
                InitializeGetQuery();

                /*" -0- FLUXCONTROL_PERFORM M-0000-PRINCIPAL */

                M_0000_PRINCIPAL();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        public void InitializeGetQuery()
        {
            CURS01.GetQueryEvent += GetQuery_CURS01;
            CURS02.GetQueryEvent += GetQuery_CURS02;
        }

        [StopWatch]
        /*" M-0000-PRINCIPAL */
        private void M_0000_PRINCIPAL(bool isPerform = false)
        {
            /*" -219- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -221- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -223- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -227- PERFORM 0100-INICIALIZA. */

            M_0100_INICIALIZA_SECTION();

            /*" -230- PERFORM 0200-PROCESSA UNTIL WS-FIM EQUAL 'S' . */

            while (!(WS_FIM == "S"))
            {

                M_0200_PROCESSA_SECTION();
            }

            /*" -232- PERFORM 0300-FINALIZA. */

            M_0300_FINALIZA_SECTION();

            /*" -232- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_SAIDA*/

        [StopWatch]
        /*" M-0100-INICIALIZA-SECTION */
        private void M_0100_INICIALIZA_SECTION()
        {
            /*" -244- MOVE '0100-INICIALIZA   ' TO WS-PARAGRAFO */
            _.Move("0100-INICIALIZA   ", WS_MSGERRO.WS_PARAGRAFO);

            /*" -246- INITIALIZE TAB-FAIXAS. */
            _.Initialize(
                TAB_FAIXAS
            );

            /*" -247- OPEN INPUT PARAMETROS-IN. */
            PARAMETROS_IN.Open(REG_PARAMETROS_IN);

            /*" -249- OPEN OUTPUT PARAMETROS-OUT. */
            PARAMETROS_OUT.Open(REG_PARAMETROS_OUT);

            /*" -250- MOVE 'PF0630B' TO RELATORI-COD-RELATORIO. */
            _.Move("PF0630B", RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO);

            /*" -252- PERFORM 0105-LE-RELATORIOS. */

            M_0105_LE_RELATORIOS_SECTION();

            /*" -253- MOVE 'N' TO WS-FIM. */
            _.Move("N", WS_FIM);

            /*" -254- IF WS-FIM NOT EQUAL 'S' */

            if (WS_FIM != "S")
            {

                /*" -255- PERFORM 0106-LE-ARQ-PARAMETRO */

                M_0106_LE_ARQ_PARAMETRO_SECTION();

                /*" -256- SET IX1 TO 1 */
                IX1.Value = 1;

                /*" -256- MOVE 1 TO WS-CONT. */
                _.Move(1, WS_CONT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0100_SAIDA*/

        [StopWatch]
        /*" M-0105-LE-RELATORIOS-SECTION */
        private void M_0105_LE_RELATORIOS_SECTION()
        {
            /*" -267- MOVE '0105-LE-RELATORIOS' TO WS-PARAGRAFO */
            _.Move("0105-LE-RELATORIOS", WS_MSGERRO.WS_PARAGRAFO);

            /*" -274- PERFORM M_0105_LE_RELATORIOS_DB_SELECT_1 */

            M_0105_LE_RELATORIOS_DB_SELECT_1();

            /*" -278- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL +100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != +100)
            {

                /*" -279- MOVE '0105-LE-RELATORIOS' TO WS-PARAGRAFO */
                _.Move("0105-LE-RELATORIOS", WS_MSGERRO.WS_PARAGRAFO);

                /*" -280- MOVE 'RELATORIOS' TO WS-NOME-TABELA */
                _.Move("RELATORIOS", WS_MSGERRO.WS_NOME_TABELA);

                /*" -281- MOVE 'SELECT' TO WS-INSTRUCAO */
                _.Move("SELECT", WS_MSGERRO.WS_INSTRUCAO);

                /*" -282- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_MSGERRO.WS_SQLCODE);

                /*" -283- MOVE 'ERRO GRAVE' TO WS-MENSAGEM */
                _.Move("ERRO GRAVE", WS_MSGERRO.WS_MENSAGEM);

                /*" -284- MOVE SPACES TO WS-CHAVE-ACESSO */
                _.Move("", WS_CHAVE_ACESSO);

                /*" -285- MOVE 'PF' TO WS-CAMPO1 */
                _.Move("PF", WS_CHAVE_ACESSO.WS_CAMPO1);

                /*" -286- MOVE 'PF0630B' TO WS-CAMPO2 */
                _.Move("PF0630B", WS_CHAVE_ACESSO.WS_CAMPO2);

                /*" -287- MOVE WS-CHAVE-ACESSO TO WS-CHAVE */
                _.Move(WS_CHAVE_ACESSO, WS_MSGERRO.WS_CHAVE);

                /*" -289- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -290- IF SQLCODE EQUAL +100 */

            if (DB.SQLCODE == +100)
            {

                /*" -292- MOVE SPACES TO RELATORI-COD-RELATORIO */
                _.Move("", RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO);

                /*" -292- MOVE 'S' TO WS-FIM. */
                _.Move("S", WS_FIM);
            }


        }

        [StopWatch]
        /*" M-0105-LE-RELATORIOS-DB-SELECT-1 */
        public void M_0105_LE_RELATORIOS_DB_SELECT_1()
        {
            /*" -274- EXEC SQL SELECT COD_RELATORIO INTO :RELATORI-COD-RELATORIO FROM SEGUROS.RELATORIOS WHERE IDE_SISTEMA = 'PF' AND COD_RELATORIO = :RELATORI-COD-RELATORIO AND SIT_REGISTRO = '0' END-EXEC. */

            var m_0105_LE_RELATORIOS_DB_SELECT_1_Query1 = new M_0105_LE_RELATORIOS_DB_SELECT_1_Query1()
            {
                RELATORI_COD_RELATORIO = RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO.ToString(),
            };

            var executed_1 = M_0105_LE_RELATORIOS_DB_SELECT_1_Query1.Execute(m_0105_LE_RELATORIOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RELATORI_COD_RELATORIO, RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0105_SAIDA*/

        [StopWatch]
        /*" M-0106-LE-ARQ-PARAMETRO-SECTION */
        private void M_0106_LE_ARQ_PARAMETRO_SECTION()
        {
            /*" -303- MOVE '0106-LE-ARQ-PARAMETRO ' TO WS-PARAGRAFO */
            _.Move("0106-LE-ARQ-PARAMETRO ", WS_MSGERRO.WS_PARAGRAFO);

            /*" -304- READ PARAMETROS-IN INTO WS-PARAMETROS AT END */
            try
            {
                PARAMETROS_IN.Read(() =>
                {

                    /*" -306- MOVE 'S' TO WS-FIM. */
                    _.Move("S", WS_FIM);
                });

                _.Move(PARAMETROS_IN.Value, WS_PARAMETROS); _.Move(PARAMETROS_IN.Value, REG_PARAMETROS_IN);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -307- IF WS-FIM NOT EQUAL 'S' */

            if (WS_FIM != "S")
            {

                /*" -307- ADD 1 TO WS-LIDOS. */
                WS_LIDOS.Value = WS_LIDOS + 1;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0106_SAIDA*/

        [StopWatch]
        /*" M-0200-PROCESSA-SECTION */
        private void M_0200_PROCESSA_SECTION()
        {
            /*" -316- IF WS-ID-REG EQUAL 'H 9999ARQCOMUM' */
            if (WS_PARAMETROS.WS_ID_REG.GetMoveValues() == "H 9999ARQCOMUM")
            {

                /*" -318- MOVE '*' TO WS-FLAG. */
                _.Move("*", WS_FLAG);
            }


            /*" -321- IF WS-FLAG EQUAL '*' AND WS-IDENTIFICA EQUAL 'T ' */

            if (WS_FLAG == "*" && WS_PARAMETROS.WS_ID_REG.WS_IDENTIFICA == "T ")
            {

                /*" -323- MOVE WS-PARAMETROS TO WS-AREA */
                _.Move(WS_PARAMETROS, WS_AREA);

                /*" -325- PERFORM 0210-PROCESSA-FAIXAS */

                M_0210_PROCESSA_FAIXAS_SECTION();

                /*" -326- MOVE WS-AREA TO WS-PARAMETROS */
                _.Move(WS_AREA, WS_PARAMETROS);

                /*" -328- MOVE SPACES TO WS-AREA. */
                _.Move("", WS_AREA);
            }


            /*" -332- IF ((WS-FLAG EQUAL ' ' ) OR (WS-FLAG EQUAL '*' AND WS-IDENTIFICA NOT EQUAL '12' AND WS-IDENTIFICA NOT EQUAL '08' )) */

            if (((WS_FLAG == " ") || (WS_FLAG == "*" && WS_PARAMETROS.WS_ID_REG.WS_IDENTIFICA != "12" && WS_PARAMETROS.WS_ID_REG.WS_IDENTIFICA != "08")))
            {

                /*" -334- PERFORM 0214-GRAVA-PARAMETRO. */

                M_0214_GRAVA_PARAMETRO_SECTION();
            }


            /*" -334- PERFORM 0106-LE-ARQ-PARAMETRO. */

            M_0106_LE_ARQ_PARAMETRO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0200_SAIDA*/

        [StopWatch]
        /*" M-0210-PROCESSA-FAIXAS-SECTION */
        private void M_0210_PROCESSA_FAIXAS_SECTION()
        {
            /*" -345- MOVE '0210-PROCESSA-FAIXAS  ' TO WS-PARAGRAFO */
            _.Move("0210-PROCESSA-FAIXAS  ", WS_MSGERRO.WS_PARAGRAFO);

            /*" -347- PERFORM 0215-OPEN-CURS01. */

            M_0215_OPEN_CURS01_SECTION();

            /*" -349- PERFORM 0220-FETCH-CURS01. */

            M_0220_FETCH_CURS01_SECTION();

            /*" -352- PERFORM 0225-CARREGA-TABELA UNTIL WS-FIM-CURS01 EQUAL 'S' . */

            while (!(WS_FIM_CURS01 == "S"))
            {

                M_0225_CARREGA_TABELA_SECTION();
            }

            /*" -354- PERFORM 0230-TRATA-FAIXAS-FIXAS. */

            M_0230_TRATA_FAIXAS_FIXAS_SECTION();

            /*" -355- SET IX1 TO 1. */
            IX1.Value = 1;

            /*" -357- MOVE 1 TO WS-CONT. */
            _.Move(1, WS_CONT);

            /*" -361- PERFORM 0235-GRAVA-FAIXAS UNTIL TAB-PRODUTO(IX1) EQUAL ZEROS OR IX1 GREATER 4000. */

            while (!(TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_PRODUTO == 00 || IX1 > 4000))
            {

                M_0235_GRAVA_FAIXAS_SECTION();
            }

            /*" -364- IF WS-PRODUTO-1 NOT EQUAL ZEROS AND WS-FXA-INI-1 NOT EQUAL ZEROS AND WS-FXA-FIM-1 NOT EQUAL ZEROS */

            if (WS_PARAM.WS_PRODUTO_1 != 00 && WS_PARAM.WS_FXA_INI_1 != 00 && WS_PARAM.WS_FXA_FIM_1 != 00)
            {

                /*" -365- MOVE 12 TO WS-IDENTIFICA-REG */
                _.Move(12, WS_PARAM.WS_IDENTIFICA_REG);

                /*" -366- MOVE 9999 TO WS-AGENCIA */
                _.Move(9999, WS_PARAM.WS_AGENCIA);

                /*" -368- MOVE 'I' TO WS-OPERACAO */
                _.Move("I", WS_PARAM.WS_OPERACAO);

                /*" -369- MOVE WS-PARAM TO WS-PARAMETROS */
                _.Move(WS_PARAM, WS_PARAMETROS);

                /*" -370- PERFORM 0214-GRAVA-PARAMETRO */

                M_0214_GRAVA_PARAMETRO_SECTION();

                /*" -371- ADD 1 TO WS-GRAVA-TIPO12 */
                WS_GRAVA_TIPO12.Value = WS_GRAVA_TIPO12 + 1;

                /*" -372- MOVE ZEROS TO WS-QTD-OCORR */
                _.Move(0, WS_PARAM.WS_QTD_OCORR);

                /*" -374- MOVE SPACES TO WS-PARAM. */
                _.Move("", WS_PARAM);
            }


            /*" -374- MOVE ' ' TO WS-FLAG. */
            _.Move(" ", WS_FLAG);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0210_SAIDA*/

        [StopWatch]
        /*" M-0214-GRAVA-PARAMETRO-SECTION */
        private void M_0214_GRAVA_PARAMETRO_SECTION()
        {
            /*" -385- MOVE '0214-GRAVA-PARAMETRO  ' TO WS-PARAGRAFO */
            _.Move("0214-GRAVA-PARAMETRO  ", WS_MSGERRO.WS_PARAGRAFO);

            /*" -386- WRITE REG-PARAMETROS-OUT FROM WS-PARAMETROS. */
            _.Move(WS_PARAMETROS.GetMoveValues(), REG_PARAMETROS_OUT);

            PARAMETROS_OUT.Write(REG_PARAMETROS_OUT.GetMoveValues().ToString());

            /*" -386- ADD 1 TO WS-GRAVA. */
            WS_GRAVA.Value = WS_GRAVA + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0214_SAIDA*/

        [StopWatch]
        /*" M-0215-OPEN-CURS01-SECTION */
        private void M_0215_OPEN_CURS01_SECTION()
        {
            /*" -397- MOVE '0215-OPEN-CURSOR01    ' TO WS-PARAGRAFO */
            _.Move("0215-OPEN-CURSOR01    ", WS_MSGERRO.WS_PARAGRAFO);

            /*" -397- PERFORM M_0215_OPEN_CURS01_DB_OPEN_1 */

            M_0215_OPEN_CURS01_DB_OPEN_1();

            /*" -400- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -401- MOVE '0215-OPEN-CURS01' TO WS-PARAGRAFO */
                _.Move("0215-OPEN-CURS01", WS_MSGERRO.WS_PARAGRAFO);

                /*" -402- MOVE 'CURS01' TO WS-NOME-TABELA */
                _.Move("CURS01", WS_MSGERRO.WS_NOME_TABELA);

                /*" -403- MOVE 'OPEN' TO WS-INSTRUCAO */
                _.Move("OPEN", WS_MSGERRO.WS_INSTRUCAO);

                /*" -404- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_MSGERRO.WS_SQLCODE);

                /*" -405- MOVE 'ERRO GRAVE' TO WS-MENSAGEM */
                _.Move("ERRO GRAVE", WS_MSGERRO.WS_MENSAGEM);

                /*" -406- MOVE SPACES TO WS-CHAVE */
                _.Move("", WS_MSGERRO.WS_CHAVE);

                /*" -406- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0215-OPEN-CURS01-DB-OPEN-1 */
        public void M_0215_OPEN_CURS01_DB_OPEN_1()
        {
            /*" -397- EXEC SQL OPEN CURS01 END-EXEC. */

            CURS01.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0215_SAIDA*/

        [StopWatch]
        /*" M-0220-FETCH-CURS01-SECTION */
        private void M_0220_FETCH_CURS01_SECTION()
        {
            /*" -417- MOVE '0220-FETCH-CURS01     ' TO WS-PARAGRAFO */
            _.Move("0220-FETCH-CURS01     ", WS_MSGERRO.WS_PARAGRAFO);

            /*" -422- PERFORM M_0220_FETCH_CURS01_DB_FETCH_1 */

            M_0220_FETCH_CURS01_DB_FETCH_1();

            /*" -427- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -428- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -429- MOVE 'S' TO WS-FIM-CURS01 */
                    _.Move("S", WS_FIM_CURS01);

                    /*" -430- MOVE 99 TO WS-COD-PRODUTO-FIM */
                    _.Move(99, WS_COD_PRODUTO_FIM);

                    /*" -430- PERFORM M_0220_FETCH_CURS01_DB_CLOSE_1 */

                    M_0220_FETCH_CURS01_DB_CLOSE_1();

                    /*" -432- ELSE */
                }
                else
                {


                    /*" -433- MOVE '0220-FETCH-CURS01' TO WS-PARAGRAFO */
                    _.Move("0220-FETCH-CURS01", WS_MSGERRO.WS_PARAGRAFO);

                    /*" -434- MOVE 'CURS01' TO WS-NOME-TABELA */
                    _.Move("CURS01", WS_MSGERRO.WS_NOME_TABELA);

                    /*" -435- MOVE 'FETCH' TO WS-INSTRUCAO */
                    _.Move("FETCH", WS_MSGERRO.WS_INSTRUCAO);

                    /*" -436- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, WS_MSGERRO.WS_SQLCODE);

                    /*" -437- MOVE 'ERRO GRAVE' TO WS-MENSAGEM */
                    _.Move("ERRO GRAVE", WS_MSGERRO.WS_MENSAGEM);

                    /*" -438- MOVE SPACES TO WS-CHAVE */
                    _.Move("", WS_MSGERRO.WS_CHAVE);

                    /*" -439- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -440- ELSE */
                }

            }
            else
            {


                /*" -442- ADD 1 TO WS-LIDOS-CURS01. */
                WS_LIDOS_CURS01.Value = WS_LIDOS_CURS01 + 1;
            }


            /*" -443- IF WS-LIDOS-CURS01 EQUAL 1 */

            if (WS_LIDOS_CURS01 == 1)
            {

                /*" -444- MOVE PRDSIVPF-COD-PRODUTO-SIVPF TO WS-COD-PRODUTO-INI WS-COD-PRODUTO-FIM. */
                _.Move(PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF, WS_COD_PRODUTO_INI, WS_COD_PRODUTO_FIM);
            }


        }

        [StopWatch]
        /*" M-0220-FETCH-CURS01-DB-FETCH-1 */
        public void M_0220_FETCH_CURS01_DB_FETCH_1()
        {
            /*" -422- EXEC SQL FETCH CURS01 INTO :PRDSIVPF-COD-PRODUTO-SIVPF, :SICFAIRC-NUM-SICOB-INI, :SICFAIRC-NUM-SICOB-FIM END-EXEC. */

            if (CURS01.Fetch())
            {
                _.Move(CURS01.PRDSIVPF_COD_PRODUTO_SIVPF, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF);
                _.Move(CURS01.SICFAIRC_NUM_SICOB_INI, SICFAIRC.DCLSICOB_FAIXA_RCAP.SICFAIRC_NUM_SICOB_INI);
                _.Move(CURS01.SICFAIRC_NUM_SICOB_FIM, SICFAIRC.DCLSICOB_FAIXA_RCAP.SICFAIRC_NUM_SICOB_FIM);
            }

        }

        [StopWatch]
        /*" M-0220-FETCH-CURS01-DB-CLOSE-1 */
        public void M_0220_FETCH_CURS01_DB_CLOSE_1()
        {
            /*" -430- EXEC SQL CLOSE CURS01 END-EXEC */

            CURS01.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0220_SAIDA*/

        [StopWatch]
        /*" M-0225-CARREGA-TABELA-SECTION */
        private void M_0225_CARREGA_TABELA_SECTION()
        {
            /*" -455- MOVE '0225-CARREGA-TABELA   ' TO WS-PARAGRAFO */
            _.Move("0225-CARREGA-TABELA   ", WS_MSGERRO.WS_PARAGRAFO);

            /*" -456- IF PRDSIVPF-COD-PRODUTO-SIVPF NOT EQUAL WS-COD-PRODUTO-INI */

            if (PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF != WS_COD_PRODUTO_INI)
            {

                /*" -457- MOVE PRDSIVPF-COD-PRODUTO-SIVPF TO WS-COD-PRODUTO-FIM */
                _.Move(PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF, WS_COD_PRODUTO_FIM);

                /*" -458- PERFORM 0230-TRATA-FAIXAS-FIXAS */

                M_0230_TRATA_FAIXAS_FIXAS_SECTION();

                /*" -460- MOVE PRDSIVPF-COD-PRODUTO-SIVPF TO WS-COD-PRODUTO-INI. */
                _.Move(PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF, WS_COD_PRODUTO_INI);
            }


            /*" -461- MOVE PRDSIVPF-COD-PRODUTO-SIVPF TO TAB-PRODUTO(IX1). */
            _.Move(PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_PRODUTO);

            /*" -462- MOVE SICFAIRC-NUM-SICOB-INI TO TAB-FAIXA-INI(IX1). */
            _.Move(SICFAIRC.DCLSICOB_FAIXA_RCAP.SICFAIRC_NUM_SICOB_INI, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_INI);

            /*" -464- MOVE SICFAIRC-NUM-SICOB-FIM TO TAB-FAIXA-FIM(IX1). */
            _.Move(SICFAIRC.DCLSICOB_FAIXA_RCAP.SICFAIRC_NUM_SICOB_FIM, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_FIM);

            /*" -465- SET IX1 UP BY 1. */
            IX1.Value += 1;

            /*" -467- ADD 1 TO WS-CONT. */
            WS_CONT.Value = WS_CONT + 1;

            /*" -468- IF WS-CONT > 4000 */

            if (WS_CONT > 4000)
            {

                /*" -469- DISPLAY 'ESTOURO TAB INTERNA IX1 = ' WS-CONT */
                _.Display($"ESTOURO TAB INTERNA IX1 = {WS_CONT}");

                /*" -470- GO TO 9999-ERRO */

                M_9999_ERRO_SECTION(); //GOTO
                return;

                /*" -472- END-IF. */
            }


            /*" -472- PERFORM 0220-FETCH-CURS01. */

            M_0220_FETCH_CURS01_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0225_SAIDA*/

        [StopWatch]
        /*" M-0230-TRATA-FAIXAS-FIXAS-SECTION */
        private void M_0230_TRATA_FAIXAS_FIXAS_SECTION()
        {
            /*" -486- MOVE '0230-TRATA-FAIXAS-FIXAS ' TO WS-PARAGRAFO */
            _.Move("0230-TRATA-FAIXAS-FIXAS ", WS_MSGERRO.WS_PARAGRAFO);

            /*" -488- IF 01 NOT LESS WS-COD-PRODUTO-INI AND 01 LESS WS-COD-PRODUTO-FIM */

            if (01 >= WS_COD_PRODUTO_INI && 01 < WS_COD_PRODUTO_FIM)
            {

                /*" -489- MOVE 01 TO TAB-PRODUTO(IX1) */
                _.Move(01, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_PRODUTO);

                /*" -490- MOVE 84820000000 TO TAB-FAIXA-INI(IX1) */
                _.Move(84820000000, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_INI);

                /*" -491- MOVE 84829999999 TO TAB-FAIXA-FIM(IX1) */
                _.Move(84829999999, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_FIM);

                /*" -492- SET IX1 UP BY 1 */
                IX1.Value += 1;

                /*" -493- ADD 1 TO WS-CONT */
                WS_CONT.Value = WS_CONT + 1;

                /*" -494- IF WS-CONT > 4000 */

                if (WS_CONT > 4000)
                {

                    /*" -495- DISPLAY 'ESTOURO TAB INTERNA IX1 = ' WS-CONT */
                    _.Display($"ESTOURO TAB INTERNA IX1 = {WS_CONT}");

                    /*" -496- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -498- END-IF. */
                }

            }


            /*" -500- IF 03 NOT LESS WS-COD-PRODUTO-INI AND 03 LESS WS-COD-PRODUTO-FIM */

            if (03 >= WS_COD_PRODUTO_INI && 03 < WS_COD_PRODUTO_FIM)
            {

                /*" -501- MOVE 03 TO TAB-PRODUTO(IX1) */
                _.Move(03, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_PRODUTO);

                /*" -502- MOVE 84940000000 TO TAB-FAIXA-INI(IX1) */
                _.Move(84940000000, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_INI);

                /*" -503- MOVE 84949999999 TO TAB-FAIXA-FIM(IX1) */
                _.Move(84949999999, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_FIM);

                /*" -504- SET IX1 UP BY 1 */
                IX1.Value += 1;

                /*" -505- ADD 1 TO WS-CONT */
                WS_CONT.Value = WS_CONT + 1;

                /*" -506- IF WS-CONT > 4000 */

                if (WS_CONT > 4000)
                {

                    /*" -507- DISPLAY 'ESTOURO TAB INTERNA IX1 = ' WS-CONT */
                    _.Display($"ESTOURO TAB INTERNA IX1 = {WS_CONT}");

                    /*" -508- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -510- END-IF */
                }


                /*" -511- MOVE 03 TO TAB-PRODUTO(IX1) */
                _.Move(03, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_PRODUTO);

                /*" -512- MOVE 84950000000 TO TAB-FAIXA-INI(IX1) */
                _.Move(84950000000, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_INI);

                /*" -513- MOVE 84959999999 TO TAB-FAIXA-FIM(IX1) */
                _.Move(84959999999, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_FIM);

                /*" -514- SET IX1 UP BY 1 */
                IX1.Value += 1;

                /*" -515- ADD 1 TO WS-CONT */
                WS_CONT.Value = WS_CONT + 1;

                /*" -516- IF WS-CONT > 4000 */

                if (WS_CONT > 4000)
                {

                    /*" -517- DISPLAY 'ESTOURO TAB INTERNA IX1 = ' WS-CONT */
                    _.Display($"ESTOURO TAB INTERNA IX1 = {WS_CONT}");

                    /*" -518- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -520- END-IF. */
                }

            }


            /*" -522- IF 09 NOT LESS WS-COD-PRODUTO-INI AND 09 LESS WS-COD-PRODUTO-FIM */

            if (09 >= WS_COD_PRODUTO_INI && 09 < WS_COD_PRODUTO_FIM)
            {

                /*" -523- MOVE 09 TO TAB-PRODUTO(IX1) */
                _.Move(09, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_PRODUTO);

                /*" -524- MOVE 82300000000 TO TAB-FAIXA-INI(IX1) */
                _.Move(82300000000, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_INI);

                /*" -525- MOVE 82464999999 TO TAB-FAIXA-FIM(IX1) */
                _.Move(82464999999, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_FIM);

                /*" -526- SET IX1 UP BY 1 */
                IX1.Value += 1;

                /*" -527- ADD 1 TO WS-CONT */
                WS_CONT.Value = WS_CONT + 1;

                /*" -528- IF WS-CONT > 4000 */

                if (WS_CONT > 4000)
                {

                    /*" -529- DISPLAY 'ESTOURO TAB INTERNA IX1 = ' WS-CONT */
                    _.Display($"ESTOURO TAB INTERNA IX1 = {WS_CONT}");

                    /*" -530- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -532- END-IF */
                }


                /*" -533- MOVE 09 TO TAB-PRODUTO(IX1) */
                _.Move(09, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_PRODUTO);

                /*" -534- MOVE 82465000000 TO TAB-FAIXA-INI(IX1) */
                _.Move(82465000000, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_INI);

                /*" -535- MOVE 82491100099 TO TAB-FAIXA-FIM(IX1) */
                _.Move(82491100099, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_FIM);

                /*" -536- SET IX1 UP BY 1 */
                IX1.Value += 1;

                /*" -537- ADD 1 TO WS-CONT */
                WS_CONT.Value = WS_CONT + 1;

                /*" -538- IF WS-CONT > 4000 */

                if (WS_CONT > 4000)
                {

                    /*" -539- DISPLAY 'ESTOURO TAB INTERNA IX1 = ' WS-CONT */
                    _.Display($"ESTOURO TAB INTERNA IX1 = {WS_CONT}");

                    /*" -540- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -542- END-IF */
                }


                /*" -543- MOVE 09 TO TAB-PRODUTO(IX1) */
                _.Move(09, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_PRODUTO);

                /*" -544- MOVE 82491100100 TO TAB-FAIXA-INI(IX1) */
                _.Move(82491100100, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_INI);

                /*" -545- MOVE 82494999999 TO TAB-FAIXA-FIM(IX1) */
                _.Move(82494999999, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_FIM);

                /*" -546- SET IX1 UP BY 1 */
                IX1.Value += 1;

                /*" -547- ADD 1 TO WS-CONT */
                WS_CONT.Value = WS_CONT + 1;

                /*" -548- IF WS-CONT > 4000 */

                if (WS_CONT > 4000)
                {

                    /*" -549- DISPLAY 'ESTOURO TAB INTERNA IX1 = ' WS-CONT */
                    _.Display($"ESTOURO TAB INTERNA IX1 = {WS_CONT}");

                    /*" -550- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -552- END-IF */
                }


                /*" -553- MOVE 09 TO TAB-PRODUTO(IX1) */
                _.Move(09, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_PRODUTO);

                /*" -554- MOVE 82495000000 TO TAB-FAIXA-INI(IX1) */
                _.Move(82495000000, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_INI);

                /*" -555- MOVE 82498900099 TO TAB-FAIXA-FIM(IX1) */
                _.Move(82498900099, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_FIM);

                /*" -556- SET IX1 UP BY 1 */
                IX1.Value += 1;

                /*" -557- ADD 1 TO WS-CONT */
                WS_CONT.Value = WS_CONT + 1;

                /*" -558- IF WS-CONT > 4000 */

                if (WS_CONT > 4000)
                {

                    /*" -559- DISPLAY 'ESTOURO TAB INTERNA IX1 = ' WS-CONT */
                    _.Display($"ESTOURO TAB INTERNA IX1 = {WS_CONT}");

                    /*" -560- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -562- END-IF */
                }


                /*" -563- MOVE 09 TO TAB-PRODUTO(IX1) */
                _.Move(09, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_PRODUTO);

                /*" -564- MOVE 82498900100 TO TAB-FAIXA-INI(IX1) */
                _.Move(82498900100, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_INI);

                /*" -565- MOVE 82599999999 TO TAB-FAIXA-FIM(IX1) */
                _.Move(82599999999, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_FIM);

                /*" -566- SET IX1 UP BY 1 */
                IX1.Value += 1;

                /*" -567- ADD 1 TO WS-CONT */
                WS_CONT.Value = WS_CONT + 1;

                /*" -568- IF WS-CONT > 4000 */

                if (WS_CONT > 4000)
                {

                    /*" -569- DISPLAY 'ESTOURO TAB INTERNA IX1 = ' WS-CONT */
                    _.Display($"ESTOURO TAB INTERNA IX1 = {WS_CONT}");

                    /*" -570- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -572- END-IF */
                }


                /*" -573- MOVE 09 TO TAB-PRODUTO(IX1) */
                _.Move(09, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_PRODUTO);

                /*" -574- MOVE 82656050500 TO TAB-FAIXA-INI(IX1) */
                _.Move(82656050500, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_INI);

                /*" -575- MOVE 82656250599 TO TAB-FAIXA-FIM(IX1) */
                _.Move(82656250599, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_FIM);

                /*" -576- SET IX1 UP BY 1 */
                IX1.Value += 1;

                /*" -577- ADD 1 TO WS-CONT */
                WS_CONT.Value = WS_CONT + 1;

                /*" -578- IF WS-CONT > 4000 */

                if (WS_CONT > 4000)
                {

                    /*" -579- DISPLAY 'ESTOURO TAB INTERNA IX1 = ' WS-CONT */
                    _.Display($"ESTOURO TAB INTERNA IX1 = {WS_CONT}");

                    /*" -580- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -582- END-IF */
                }


                /*" -583- MOVE 09 TO TAB-PRODUTO(IX1) */
                _.Move(09, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_PRODUTO);

                /*" -584- MOVE 82950000000 TO TAB-FAIXA-INI(IX1) */
                _.Move(82950000000, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_INI);

                /*" -585- MOVE 82999999999 TO TAB-FAIXA-FIM(IX1) */
                _.Move(82999999999, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_FIM);

                /*" -586- SET IX1 UP BY 1 */
                IX1.Value += 1;

                /*" -587- ADD 1 TO WS-CONT */
                WS_CONT.Value = WS_CONT + 1;

                /*" -588- IF WS-CONT > 4000 */

                if (WS_CONT > 4000)
                {

                    /*" -589- DISPLAY 'ESTOURO TAB INTERNA IX1 = ' WS-CONT */
                    _.Display($"ESTOURO TAB INTERNA IX1 = {WS_CONT}");

                    /*" -590- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -592- END-IF */
                }


                /*" -593- MOVE 09 TO TAB-PRODUTO(IX1) */
                _.Move(09, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_PRODUTO);

                /*" -594- MOVE 83750000000 TO TAB-FAIXA-INI(IX1) */
                _.Move(83750000000, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_INI);

                /*" -595- MOVE 83799999999 TO TAB-FAIXA-FIM(IX1) */
                _.Move(83799999999, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_FIM);

                /*" -596- SET IX1 UP BY 1 */
                IX1.Value += 1;

                /*" -597- ADD 1 TO WS-CONT */
                WS_CONT.Value = WS_CONT + 1;

                /*" -598- IF WS-CONT > 4000 */

                if (WS_CONT > 4000)
                {

                    /*" -599- DISPLAY 'ESTOURO TAB INTERNA IX1 = ' WS-CONT */
                    _.Display($"ESTOURO TAB INTERNA IX1 = {WS_CONT}");

                    /*" -600- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -602- END-IF */
                }


                /*" -603- MOVE 8201 TO SICFAIRC-COD-PRODUTO */
                _.Move(8201, SICFAIRC.DCLSICOB_FAIXA_RCAP.SICFAIRC_COD_PRODUTO);

                /*" -604- MOVE 09 TO WS-COD-PRODUTO-SIVPF */
                _.Move(09, WS_COD_PRODUTO_SIVPF);

                /*" -606- MOVE 'N' TO WS-FIM-CURS02 */
                _.Move("N", WS_FIM_CURS02);

                /*" -608- PERFORM 0240-OPEN-CURS02 */

                M_0240_OPEN_CURS02_SECTION();

                /*" -610- PERFORM 0250-FETCH-CURS02 */

                M_0250_FETCH_CURS02_SECTION();

                /*" -613- PERFORM 0260-CARREGA-TABELA UNTIL WS-FIM-CURS02 EQUAL 'S' */

                while (!(WS_FIM_CURS02 == "S"))
                {

                    M_0260_CARREGA_TABELA_SECTION();
                }

                /*" -614- MOVE 8104 TO SICFAIRC-COD-PRODUTO */
                _.Move(8104, SICFAIRC.DCLSICOB_FAIXA_RCAP.SICFAIRC_COD_PRODUTO);

                /*" -615- MOVE 09 TO WS-COD-PRODUTO-SIVPF */
                _.Move(09, WS_COD_PRODUTO_SIVPF);

                /*" -617- MOVE 'N' TO WS-FIM-CURS02 */
                _.Move("N", WS_FIM_CURS02);

                /*" -619- PERFORM 0240-OPEN-CURS02 */

                M_0240_OPEN_CURS02_SECTION();

                /*" -621- PERFORM 0250-FETCH-CURS02 */

                M_0250_FETCH_CURS02_SECTION();

                /*" -623- PERFORM 0260-CARREGA-TABELA UNTIL WS-FIM-CURS02 EQUAL 'S' */

                while (!(WS_FIM_CURS02 == "S"))
                {

                    M_0260_CARREGA_TABELA_SECTION();
                }

                /*" -625- END-IF. */
            }


            /*" -627- IF 10 NOT LESS WS-COD-PRODUTO-INI AND 10 LESS WS-COD-PRODUTO-FIM */

            if (10 >= WS_COD_PRODUTO_INI && 10 < WS_COD_PRODUTO_FIM)
            {

                /*" -628- MOVE 10 TO TAB-PRODUTO(IX1) */
                _.Move(10, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_PRODUTO);

                /*" -629- MOVE 82600000000 TO TAB-FAIXA-INI(IX1) */
                _.Move(82600000000, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_INI);

                /*" -630- MOVE 82680099999 TO TAB-FAIXA-FIM(IX1) */
                _.Move(82680099999, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_FIM);

                /*" -631- SET IX1 UP BY 1 */
                IX1.Value += 1;

                /*" -632- ADD 1 TO WS-CONT */
                WS_CONT.Value = WS_CONT + 1;

                /*" -633- IF WS-CONT > 4000 */

                if (WS_CONT > 4000)
                {

                    /*" -634- DISPLAY 'ESTOURO TAB INTERNA IX1 = ' WS-CONT */
                    _.Display($"ESTOURO TAB INTERNA IX1 = {WS_CONT}");

                    /*" -635- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -637- END-IF */
                }


                /*" -638- MOVE 10 TO TAB-PRODUTO(IX1) */
                _.Move(10, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_PRODUTO);

                /*" -639- MOVE 82680100000 TO TAB-FAIXA-INI(IX1) */
                _.Move(82680100000, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_INI);

                /*" -640- MOVE 82699999999 TO TAB-FAIXA-FIM(IX1) */
                _.Move(82699999999, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_FIM);

                /*" -641- SET IX1 UP BY 1 */
                IX1.Value += 1;

                /*" -642- ADD 1 TO WS-CONT */
                WS_CONT.Value = WS_CONT + 1;

                /*" -643- IF WS-CONT > 4000 */

                if (WS_CONT > 4000)
                {

                    /*" -644- DISPLAY 'ESTOURO TAB INTERNA IX1 = ' WS-CONT */
                    _.Display($"ESTOURO TAB INTERNA IX1 = {WS_CONT}");

                    /*" -645- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -647- END-IF */
                }


                /*" -648- MOVE 10 TO TAB-PRODUTO(IX1) */
                _.Move(10, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_PRODUTO);

                /*" -649- MOVE 82700000000 TO TAB-FAIXA-INI(IX1) */
                _.Move(82700000000, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_INI);

                /*" -650- MOVE 82799999999 TO TAB-FAIXA-FIM(IX1) */
                _.Move(82799999999, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_FIM);

                /*" -651- SET IX1 UP BY 1 */
                IX1.Value += 1;

                /*" -652- ADD 1 TO WS-CONT */
                WS_CONT.Value = WS_CONT + 1;

                /*" -653- IF WS-CONT > 4000 */

                if (WS_CONT > 4000)
                {

                    /*" -654- DISPLAY 'ESTOURO TAB INTERNA IX1 = ' WS-CONT */
                    _.Display($"ESTOURO TAB INTERNA IX1 = {WS_CONT}");

                    /*" -655- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -657- END-IF */
                }


                /*" -658- MOVE 10 TO TAB-PRODUTO(IX1) */
                _.Move(10, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_PRODUTO);

                /*" -659- MOVE 84584654279 TO TAB-FAIXA-INI(IX1) */
                _.Move(84584654279, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_INI);

                /*" -660- MOVE 84584883600 TO TAB-FAIXA-FIM(IX1) */
                _.Move(84584883600, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_FIM);

                /*" -661- SET IX1 UP BY 1 */
                IX1.Value += 1;

                /*" -662- ADD 1 TO WS-CONT */
                WS_CONT.Value = WS_CONT + 1;

                /*" -663- IF WS-CONT > 4000 */

                if (WS_CONT > 4000)
                {

                    /*" -664- DISPLAY 'ESTOURO TAB INTERNA IX1 = ' WS-CONT */
                    _.Display($"ESTOURO TAB INTERNA IX1 = {WS_CONT}");

                    /*" -665- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -667- END-IF */
                }


                /*" -668- MOVE 10 TO TAB-PRODUTO(IX1) */
                _.Move(10, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_PRODUTO);

                /*" -669- MOVE 84689034548 TO TAB-FAIXA-INI(IX1) */
                _.Move(84689034548, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_INI);

                /*" -670- MOVE 84689834536 TO TAB-FAIXA-FIM(IX1) */
                _.Move(84689834536, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_FIM);

                /*" -671- SET IX1 UP BY 1 */
                IX1.Value += 1;

                /*" -672- ADD 1 TO WS-CONT */
                WS_CONT.Value = WS_CONT + 1;

                /*" -673- IF WS-CONT > 4000 */

                if (WS_CONT > 4000)
                {

                    /*" -674- DISPLAY 'ESTOURO TAB INTERNA IX1 = ' WS-CONT */
                    _.Display($"ESTOURO TAB INTERNA IX1 = {WS_CONT}");

                    /*" -675- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -677- END-IF */
                }


                /*" -678- MOVE 7106 TO SICFAIRC-COD-PRODUTO */
                _.Move(7106, SICFAIRC.DCLSICOB_FAIXA_RCAP.SICFAIRC_COD_PRODUTO);

                /*" -679- MOVE 10 TO WS-COD-PRODUTO-SIVPF */
                _.Move(10, WS_COD_PRODUTO_SIVPF);

                /*" -681- MOVE 'N' TO WS-FIM-CURS02 */
                _.Move("N", WS_FIM_CURS02);

                /*" -683- PERFORM 0240-OPEN-CURS02 */

                M_0240_OPEN_CURS02_SECTION();

                /*" -685- PERFORM 0250-FETCH-CURS02 */

                M_0250_FETCH_CURS02_SECTION();

                /*" -688- PERFORM 0260-CARREGA-TABELA UNTIL WS-FIM-CURS02 EQUAL 'S' */

                while (!(WS_FIM_CURS02 == "S"))
                {

                    M_0260_CARREGA_TABELA_SECTION();
                }

                /*" -689- MOVE 1405 TO SICFAIRC-COD-PRODUTO */
                _.Move(1405, SICFAIRC.DCLSICOB_FAIXA_RCAP.SICFAIRC_COD_PRODUTO);

                /*" -690- MOVE 10 TO WS-COD-PRODUTO-SIVPF */
                _.Move(10, WS_COD_PRODUTO_SIVPF);

                /*" -692- MOVE 'N' TO WS-FIM-CURS02 */
                _.Move("N", WS_FIM_CURS02);

                /*" -694- PERFORM 0240-OPEN-CURS02 */

                M_0240_OPEN_CURS02_SECTION();

                /*" -696- PERFORM 0250-FETCH-CURS02 */

                M_0250_FETCH_CURS02_SECTION();

                /*" -698- PERFORM 0260-CARREGA-TABELA UNTIL WS-FIM-CURS02 EQUAL 'S' */

                while (!(WS_FIM_CURS02 == "S"))
                {

                    M_0260_CARREGA_TABELA_SECTION();
                }

                /*" -700- END-IF. */
            }


            /*" -702- IF 12 NOT LESS WS-COD-PRODUTO-INI AND 12 LESS WS-COD-PRODUTO-FIM */

            if (12 >= WS_COD_PRODUTO_INI && 12 < WS_COD_PRODUTO_FIM)
            {

                /*" -703- MOVE 12 TO TAB-PRODUTO(IX1) */
                _.Move(12, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_PRODUTO);

                /*" -704- MOVE 84940000000 TO TAB-FAIXA-INI(IX1) */
                _.Move(84940000000, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_INI);

                /*" -705- MOVE 84949999999 TO TAB-FAIXA-FIM(IX1) */
                _.Move(84949999999, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_FIM);

                /*" -706- SET IX1 UP BY 1 */
                IX1.Value += 1;

                /*" -707- ADD 1 TO WS-CONT */
                WS_CONT.Value = WS_CONT + 1;

                /*" -708- IF WS-CONT > 4000 */

                if (WS_CONT > 4000)
                {

                    /*" -709- DISPLAY 'ESTOURO TAB INTERNA IX1 = ' WS-CONT */
                    _.Display($"ESTOURO TAB INTERNA IX1 = {WS_CONT}");

                    /*" -710- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -712- END-IF */
                }


                /*" -713- MOVE 12 TO TAB-PRODUTO(IX1) */
                _.Move(12, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_PRODUTO);

                /*" -714- MOVE 84950000000 TO TAB-FAIXA-INI(IX1) */
                _.Move(84950000000, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_INI);

                /*" -715- MOVE 84959999999 TO TAB-FAIXA-FIM(IX1) */
                _.Move(84959999999, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_FIM);

                /*" -716- SET IX1 UP BY 1 */
                IX1.Value += 1;

                /*" -717- ADD 1 TO WS-CONT */
                WS_CONT.Value = WS_CONT + 1;

                /*" -718- IF WS-CONT > 4000 */

                if (WS_CONT > 4000)
                {

                    /*" -719- DISPLAY 'ESTOURO TAB INTERNA IX1 = ' WS-CONT */
                    _.Display($"ESTOURO TAB INTERNA IX1 = {WS_CONT}");

                    /*" -720- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -721- END-IF */
                }


                /*" -723- END-IF. */
            }


            /*" -725- IF 14 NOT LESS WS-COD-PRODUTO-INI AND 14 LESS WS-COD-PRODUTO-FIM */

            if (14 >= WS_COD_PRODUTO_INI && 14 < WS_COD_PRODUTO_FIM)
            {

                /*" -726- MOVE 14 TO TAB-PRODUTO(IX1) */
                _.Move(14, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_PRODUTO);

                /*" -727- MOVE 84940000000 TO TAB-FAIXA-INI(IX1) */
                _.Move(84940000000, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_INI);

                /*" -728- MOVE 84949999999 TO TAB-FAIXA-FIM(IX1) */
                _.Move(84949999999, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_FIM);

                /*" -729- SET IX1 UP BY 1 */
                IX1.Value += 1;

                /*" -730- ADD 1 TO WS-CONT */
                WS_CONT.Value = WS_CONT + 1;

                /*" -731- IF WS-CONT > 4000 */

                if (WS_CONT > 4000)
                {

                    /*" -732- DISPLAY 'ESTOURO TAB INTERNA IX1 = ' WS-CONT */
                    _.Display($"ESTOURO TAB INTERNA IX1 = {WS_CONT}");

                    /*" -733- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -735- END-IF */
                }


                /*" -736- MOVE 14 TO TAB-PRODUTO(IX1) */
                _.Move(14, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_PRODUTO);

                /*" -737- MOVE 84950000000 TO TAB-FAIXA-INI(IX1) */
                _.Move(84950000000, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_INI);

                /*" -738- MOVE 84959999999 TO TAB-FAIXA-FIM(IX1) */
                _.Move(84959999999, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_FIM);

                /*" -739- SET IX1 UP BY 1 */
                IX1.Value += 1;

                /*" -740- ADD 1 TO WS-CONT */
                WS_CONT.Value = WS_CONT + 1;

                /*" -741- IF WS-CONT > 4000 */

                if (WS_CONT > 4000)
                {

                    /*" -742- DISPLAY 'ESTOURO TAB INTERNA IX1 = ' WS-CONT */
                    _.Display($"ESTOURO TAB INTERNA IX1 = {WS_CONT}");

                    /*" -743- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -744- END-IF */
                }


                /*" -746- END-IF. */
            }


            /*" -748- IF 17 NOT LESS WS-COD-PRODUTO-INI AND 17 LESS WS-COD-PRODUTO-FIM */

            if (17 >= WS_COD_PRODUTO_INI && 17 < WS_COD_PRODUTO_FIM)
            {

                /*" -749- MOVE 17 TO TAB-PRODUTO(IX1) */
                _.Move(17, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_PRODUTO);

                /*" -750- MOVE 84940000000 TO TAB-FAIXA-INI(IX1) */
                _.Move(84940000000, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_INI);

                /*" -751- MOVE 84949999999 TO TAB-FAIXA-FIM(IX1) */
                _.Move(84949999999, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_FIM);

                /*" -752- SET IX1 UP BY 1 */
                IX1.Value += 1;

                /*" -753- ADD 1 TO WS-CONT */
                WS_CONT.Value = WS_CONT + 1;

                /*" -754- IF WS-CONT > 4000 */

                if (WS_CONT > 4000)
                {

                    /*" -755- DISPLAY 'ESTOURO TAB INTERNA IX1 = ' WS-CONT */
                    _.Display($"ESTOURO TAB INTERNA IX1 = {WS_CONT}");

                    /*" -756- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -758- END-IF */
                }


                /*" -759- MOVE 17 TO TAB-PRODUTO(IX1) */
                _.Move(17, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_PRODUTO);

                /*" -760- MOVE 84950000000 TO TAB-FAIXA-INI(IX1) */
                _.Move(84950000000, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_INI);

                /*" -761- MOVE 84959999999 TO TAB-FAIXA-FIM(IX1) */
                _.Move(84959999999, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_FIM);

                /*" -762- SET IX1 UP BY 1 */
                IX1.Value += 1;

                /*" -763- ADD 1 TO WS-CONT */
                WS_CONT.Value = WS_CONT + 1;

                /*" -764- IF WS-CONT > 4000 */

                if (WS_CONT > 4000)
                {

                    /*" -765- DISPLAY 'ESTOURO TAB INTERNA IX1 = ' WS-CONT */
                    _.Display($"ESTOURO TAB INTERNA IX1 = {WS_CONT}");

                    /*" -766- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -767- END-IF */
                }


                /*" -769- END-IF. */
            }


            /*" -771- IF 18 NOT LESS WS-COD-PRODUTO-INI AND 18 LESS WS-COD-PRODUTO-FIM */

            if (18 >= WS_COD_PRODUTO_INI && 18 < WS_COD_PRODUTO_FIM)
            {

                /*" -772- MOVE 18 TO TAB-PRODUTO(IX1) */
                _.Move(18, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_PRODUTO);

                /*" -773- MOVE 84940000000 TO TAB-FAIXA-INI(IX1) */
                _.Move(84940000000, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_INI);

                /*" -774- MOVE 84949999999 TO TAB-FAIXA-FIM(IX1) */
                _.Move(84949999999, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_FIM);

                /*" -775- SET IX1 UP BY 1 */
                IX1.Value += 1;

                /*" -776- ADD 1 TO WS-CONT */
                WS_CONT.Value = WS_CONT + 1;

                /*" -777- IF WS-CONT > 4000 */

                if (WS_CONT > 4000)
                {

                    /*" -778- DISPLAY 'ESTOURO TAB INTERNA IX1 = ' WS-CONT */
                    _.Display($"ESTOURO TAB INTERNA IX1 = {WS_CONT}");

                    /*" -779- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -781- END-IF */
                }


                /*" -782- MOVE 18 TO TAB-PRODUTO(IX1) */
                _.Move(18, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_PRODUTO);

                /*" -783- MOVE 84950000000 TO TAB-FAIXA-INI(IX1) */
                _.Move(84950000000, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_INI);

                /*" -784- MOVE 84959999999 TO TAB-FAIXA-FIM(IX1) */
                _.Move(84959999999, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_FIM);

                /*" -785- SET IX1 UP BY 1 */
                IX1.Value += 1;

                /*" -786- ADD 1 TO WS-CONT */
                WS_CONT.Value = WS_CONT + 1;

                /*" -787- IF WS-CONT > 4000 */

                if (WS_CONT > 4000)
                {

                    /*" -788- DISPLAY 'ESTOURO TAB INTERNA IX1 = ' WS-CONT */
                    _.Display($"ESTOURO TAB INTERNA IX1 = {WS_CONT}");

                    /*" -789- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -791- END-IF */
                }


                /*" -792- MOVE 18 TO TAB-PRODUTO(IX1) */
                _.Move(18, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_PRODUTO);

                /*" -793- MOVE 84900000000 TO TAB-FAIXA-INI(IX1) */
                _.Move(84900000000, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_INI);

                /*" -794- MOVE 84999999999 TO TAB-FAIXA-FIM(IX1) */
                _.Move(84999999999, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_FIM);

                /*" -795- SET IX1 UP BY 1 */
                IX1.Value += 1;

                /*" -796- ADD 1 TO WS-CONT */
                WS_CONT.Value = WS_CONT + 1;

                /*" -797- IF WS-CONT > 4000 */

                if (WS_CONT > 4000)
                {

                    /*" -798- DISPLAY 'ESTOURO TAB INTERNA IX1 = ' WS-CONT */
                    _.Display($"ESTOURO TAB INTERNA IX1 = {WS_CONT}");

                    /*" -799- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -800- END-IF */
                }


                /*" -802- END-IF. */
            }


            /*" -804- IF 19 NOT LESS WS-COD-PRODUTO-INI AND 19 LESS WS-COD-PRODUTO-FIM */

            if (19 >= WS_COD_PRODUTO_INI && 19 < WS_COD_PRODUTO_FIM)
            {

                /*" -805- MOVE 19 TO TAB-PRODUTO(IX1) */
                _.Move(19, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_PRODUTO);

                /*" -806- MOVE 84900000000 TO TAB-FAIXA-INI(IX1) */
                _.Move(84900000000, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_INI);

                /*" -807- MOVE 84999999999 TO TAB-FAIXA-FIM(IX1) */
                _.Move(84999999999, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_FIM);

                /*" -808- SET IX1 UP BY 1 */
                IX1.Value += 1;

                /*" -809- ADD 1 TO WS-CONT */
                WS_CONT.Value = WS_CONT + 1;

                /*" -810- IF WS-CONT > 4000 */

                if (WS_CONT > 4000)
                {

                    /*" -811- DISPLAY 'ESTOURO TAB INTERNA IX1 = ' WS-CONT */
                    _.Display($"ESTOURO TAB INTERNA IX1 = {WS_CONT}");

                    /*" -812- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -813- END-IF */
                }


                /*" -815- END-IF. */
            }


            /*" -817- IF 30 NOT LESS WS-COD-PRODUTO-INI AND 30 LESS WS-COD-PRODUTO-FIM */

            if (30 >= WS_COD_PRODUTO_INI && 30 < WS_COD_PRODUTO_FIM)
            {

                /*" -818- MOVE 30 TO TAB-PRODUTO(IX1) */
                _.Move(30, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_PRODUTO);

                /*" -819- MOVE 82800000000 TO TAB-FAIXA-INI(IX1) */
                _.Move(82800000000, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_INI);

                /*" -820- MOVE 82899999999 TO TAB-FAIXA-FIM(IX1) */
                _.Move(82899999999, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_FIM);

                /*" -821- SET IX1 UP BY 1 */
                IX1.Value += 1;

                /*" -822- ADD 1 TO WS-CONT */
                WS_CONT.Value = WS_CONT + 1;

                /*" -823- IF WS-CONT > 4000 */

                if (WS_CONT > 4000)
                {

                    /*" -824- DISPLAY 'ESTOURO TAB INTERNA IX1 = ' WS-CONT */
                    _.Display($"ESTOURO TAB INTERNA IX1 = {WS_CONT}");

                    /*" -825- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -826- END-IF */
                }


                /*" -828- END-IF. */
            }


            /*" -830- IF 32 NOT LESS WS-COD-PRODUTO-INI AND 32 LESS WS-COD-PRODUTO-FIM */

            if (32 >= WS_COD_PRODUTO_INI && 32 < WS_COD_PRODUTO_FIM)
            {

                /*" -831- MOVE 32 TO TAB-PRODUTO(IX1) */
                _.Move(32, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_PRODUTO);

                /*" -832- MOVE 82800000000 TO TAB-FAIXA-INI(IX1) */
                _.Move(82800000000, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_INI);

                /*" -833- MOVE 82899999999 TO TAB-FAIXA-FIM(IX1) */
                _.Move(82899999999, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_FIM);

                /*" -834- SET IX1 UP BY 1 */
                IX1.Value += 1;

                /*" -835- ADD 1 TO WS-CONT */
                WS_CONT.Value = WS_CONT + 1;

                /*" -836- IF WS-CONT > 4000 */

                if (WS_CONT > 4000)
                {

                    /*" -837- DISPLAY 'ESTOURO TAB INTERNA IX1 = ' WS-CONT */
                    _.Display($"ESTOURO TAB INTERNA IX1 = {WS_CONT}");

                    /*" -838- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -841- END-IF */
                }


                /*" -842- MOVE 32 TO TAB-PRODUTO(IX1) */
                _.Move(32, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_PRODUTO);

                /*" -843- MOVE 83700000000 TO TAB-FAIXA-INI(IX1) */
                _.Move(83700000000, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_INI);

                /*" -844- MOVE 83799999999 TO TAB-FAIXA-FIM(IX1) */
                _.Move(83799999999, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_FIM);

                /*" -845- SET IX1 UP BY 1 */
                IX1.Value += 1;

                /*" -846- ADD 1 TO WS-CONT */
                WS_CONT.Value = WS_CONT + 1;

                /*" -847- IF WS-CONT > 4000 */

                if (WS_CONT > 4000)
                {

                    /*" -848- DISPLAY 'ESTOURO TAB INTERNA IX1 = ' WS-CONT */
                    _.Display($"ESTOURO TAB INTERNA IX1 = {WS_CONT}");

                    /*" -849- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -851- END-IF */
                }


                /*" -852- MOVE 32 TO TAB-PRODUTO(IX1) */
                _.Move(32, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_PRODUTO);

                /*" -853- MOVE 84500000000 TO TAB-FAIXA-INI(IX1) */
                _.Move(84500000000, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_INI);

                /*" -854- MOVE 84599999999 TO TAB-FAIXA-FIM(IX1) */
                _.Move(84599999999, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_FIM);

                /*" -855- SET IX1 UP BY 1 */
                IX1.Value += 1;

                /*" -856- ADD 1 TO WS-CONT */
                WS_CONT.Value = WS_CONT + 1;

                /*" -857- IF WS-CONT > 4000 */

                if (WS_CONT > 4000)
                {

                    /*" -858- DISPLAY 'ESTOURO TAB INTERNA IX1 = ' WS-CONT */
                    _.Display($"ESTOURO TAB INTERNA IX1 = {WS_CONT}");

                    /*" -859- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -861- END-IF */
                }


                /*" -862- MOVE 32 TO TAB-PRODUTO(IX1) */
                _.Move(32, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_PRODUTO);

                /*" -863- MOVE 84600000000 TO TAB-FAIXA-INI(IX1) */
                _.Move(84600000000, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_INI);

                /*" -864- MOVE 84699999999 TO TAB-FAIXA-FIM(IX1) */
                _.Move(84699999999, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_FIM);

                /*" -865- SET IX1 UP BY 1 */
                IX1.Value += 1;

                /*" -866- ADD 1 TO WS-CONT */
                WS_CONT.Value = WS_CONT + 1;

                /*" -867- IF WS-CONT > 4000 */

                if (WS_CONT > 4000)
                {

                    /*" -868- DISPLAY 'ESTOURO TAB INTERNA IX1 = ' WS-CONT */
                    _.Display($"ESTOURO TAB INTERNA IX1 = {WS_CONT}");

                    /*" -869- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -871- END-IF */
                }


                /*" -872- MOVE 32 TO TAB-PRODUTO(IX1) */
                _.Move(32, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_PRODUTO);

                /*" -873- MOVE 84700000000 TO TAB-FAIXA-INI(IX1) */
                _.Move(84700000000, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_INI);

                /*" -874- MOVE 84799999999 TO TAB-FAIXA-FIM(IX1) */
                _.Move(84799999999, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_FIM);

                /*" -875- SET IX1 UP BY 1 */
                IX1.Value += 1;

                /*" -876- ADD 1 TO WS-CONT */
                WS_CONT.Value = WS_CONT + 1;

                /*" -877- IF WS-CONT > 4000 */

                if (WS_CONT > 4000)
                {

                    /*" -878- DISPLAY 'ESTOURO TAB INTERNA IX1 = ' WS-CONT */
                    _.Display($"ESTOURO TAB INTERNA IX1 = {WS_CONT}");

                    /*" -879- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -880- END-IF */
                }


                /*" -882- END-IF. */
            }


            /*" -884- IF 35 NOT LESS WS-COD-PRODUTO-INI AND 35 LESS WS-COD-PRODUTO-FIM */

            if (35 >= WS_COD_PRODUTO_INI && 35 < WS_COD_PRODUTO_FIM)
            {

                /*" -885- MOVE 35 TO TAB-PRODUTO(IX1) */
                _.Move(35, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_PRODUTO);

                /*" -886- MOVE 83700000000 TO TAB-FAIXA-INI(IX1) */
                _.Move(83700000000, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_INI);

                /*" -887- MOVE 83749999999 TO TAB-FAIXA-FIM(IX1) */
                _.Move(83749999999, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_FIM);

                /*" -888- SET IX1 UP BY 1 */
                IX1.Value += 1;

                /*" -889- ADD 1 TO WS-CONT */
                WS_CONT.Value = WS_CONT + 1;

                /*" -890- IF WS-CONT > 4000 */

                if (WS_CONT > 4000)
                {

                    /*" -891- DISPLAY 'ESTOURO TAB INTERNA IX1 = ' WS-CONT */
                    _.Display($"ESTOURO TAB INTERNA IX1 = {WS_CONT}");

                    /*" -892- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -893- END-IF */
                }


                /*" -895- END-IF. */
            }


            /*" -897- IF 37 NOT LESS WS-COD-PRODUTO-INI AND 37 LESS WS-COD-PRODUTO-FIM */

            if (37 >= WS_COD_PRODUTO_INI && 37 < WS_COD_PRODUTO_FIM)
            {

                /*" -898- MOVE 37 TO TAB-PRODUTO(IX1) */
                _.Move(37, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_PRODUTO);

                /*" -899- MOVE 82800000000 TO TAB-FAIXA-INI(IX1) */
                _.Move(82800000000, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_INI);

                /*" -900- MOVE 82899999999 TO TAB-FAIXA-FIM(IX1) */
                _.Move(82899999999, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_FIM);

                /*" -901- SET IX1 UP BY 1 */
                IX1.Value += 1;

                /*" -902- ADD 1 TO WS-CONT */
                WS_CONT.Value = WS_CONT + 1;

                /*" -903- IF WS-CONT > 4000 */

                if (WS_CONT > 4000)
                {

                    /*" -904- DISPLAY 'ESTOURO TAB INTERNA IX1 = ' WS-CONT */
                    _.Display($"ESTOURO TAB INTERNA IX1 = {WS_CONT}");

                    /*" -905- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -907- END-IF */
                }


                /*" -908- MOVE 37 TO TAB-PRODUTO(IX1) */
                _.Move(37, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_PRODUTO);

                /*" -909- MOVE 83700000000 TO TAB-FAIXA-INI(IX1) */
                _.Move(83700000000, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_INI);

                /*" -910- MOVE 83799999999 TO TAB-FAIXA-FIM(IX1) */
                _.Move(83799999999, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_FIM);

                /*" -911- SET IX1 UP BY 1 */
                IX1.Value += 1;

                /*" -912- ADD 1 TO WS-CONT */
                WS_CONT.Value = WS_CONT + 1;

                /*" -913- IF WS-CONT > 4000 */

                if (WS_CONT > 4000)
                {

                    /*" -914- DISPLAY 'ESTOURO TAB INTERNA IX1 = ' WS-CONT */
                    _.Display($"ESTOURO TAB INTERNA IX1 = {WS_CONT}");

                    /*" -915- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -917- END-IF */
                }


                /*" -918- MOVE 37 TO TAB-PRODUTO(IX1) */
                _.Move(37, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_PRODUTO);

                /*" -919- MOVE 84500000000 TO TAB-FAIXA-INI(IX1) */
                _.Move(84500000000, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_INI);

                /*" -920- MOVE 84599999999 TO TAB-FAIXA-FIM(IX1) */
                _.Move(84599999999, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_FIM);

                /*" -921- SET IX1 UP BY 1 */
                IX1.Value += 1;

                /*" -922- ADD 1 TO WS-CONT */
                WS_CONT.Value = WS_CONT + 1;

                /*" -923- IF WS-CONT > 4000 */

                if (WS_CONT > 4000)
                {

                    /*" -924- DISPLAY 'ESTOURO TAB INTERNA IX1 = ' WS-CONT */
                    _.Display($"ESTOURO TAB INTERNA IX1 = {WS_CONT}");

                    /*" -925- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -927- END-IF */
                }


                /*" -928- MOVE 37 TO TAB-PRODUTO(IX1) */
                _.Move(37, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_PRODUTO);

                /*" -929- MOVE 84600000000 TO TAB-FAIXA-INI(IX1) */
                _.Move(84600000000, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_INI);

                /*" -930- MOVE 84699999999 TO TAB-FAIXA-FIM(IX1) */
                _.Move(84699999999, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_FIM);

                /*" -931- SET IX1 UP BY 1 */
                IX1.Value += 1;

                /*" -932- ADD 1 TO WS-CONT */
                WS_CONT.Value = WS_CONT + 1;

                /*" -933- IF WS-CONT > 4000 */

                if (WS_CONT > 4000)
                {

                    /*" -934- DISPLAY 'ESTOURO TAB INTERNA IX1 = ' WS-CONT */
                    _.Display($"ESTOURO TAB INTERNA IX1 = {WS_CONT}");

                    /*" -935- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -937- END-IF */
                }


                /*" -938- MOVE 37 TO TAB-PRODUTO(IX1) */
                _.Move(37, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_PRODUTO);

                /*" -939- MOVE 84700000000 TO TAB-FAIXA-INI(IX1) */
                _.Move(84700000000, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_INI);

                /*" -940- MOVE 84799999999 TO TAB-FAIXA-FIM(IX1) */
                _.Move(84799999999, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_FIM);

                /*" -941- SET IX1 UP BY 1 */
                IX1.Value += 1;

                /*" -942- ADD 1 TO WS-CONT */
                WS_CONT.Value = WS_CONT + 1;

                /*" -943- IF WS-CONT > 4000 */

                if (WS_CONT > 4000)
                {

                    /*" -944- DISPLAY 'ESTOURO TAB INTERNA IX1 = ' WS-CONT */
                    _.Display($"ESTOURO TAB INTERNA IX1 = {WS_CONT}");

                    /*" -945- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -946- END-IF */
                }


                /*" -948- END-IF. */
            }


            /*" -950- IF 39 NOT LESS WS-COD-PRODUTO-INI AND 39 LESS WS-COD-PRODUTO-FIM */

            if (39 >= WS_COD_PRODUTO_INI && 39 < WS_COD_PRODUTO_FIM)
            {

                /*" -951- MOVE 39 TO TAB-PRODUTO(IX1) */
                _.Move(39, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_PRODUTO);

                /*" -952- MOVE 82800000000 TO TAB-FAIXA-INI(IX1) */
                _.Move(82800000000, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_INI);

                /*" -953- MOVE 82899999999 TO TAB-FAIXA-FIM(IX1) */
                _.Move(82899999999, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_FIM);

                /*" -954- SET IX1 UP BY 1 */
                IX1.Value += 1;

                /*" -955- ADD 1 TO WS-CONT */
                WS_CONT.Value = WS_CONT + 1;

                /*" -956- IF WS-CONT > 4000 */

                if (WS_CONT > 4000)
                {

                    /*" -957- DISPLAY 'ESTOURO TAB INTERNA IX1 = ' WS-CONT */
                    _.Display($"ESTOURO TAB INTERNA IX1 = {WS_CONT}");

                    /*" -958- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -960- END-IF */
                }


                /*" -961- MOVE 39 TO TAB-PRODUTO(IX1) */
                _.Move(39, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_PRODUTO);

                /*" -962- MOVE 83700000000 TO TAB-FAIXA-INI(IX1) */
                _.Move(83700000000, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_INI);

                /*" -963- MOVE 83799999999 TO TAB-FAIXA-FIM(IX1) */
                _.Move(83799999999, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_FIM);

                /*" -964- SET IX1 UP BY 1 */
                IX1.Value += 1;

                /*" -965- ADD 1 TO WS-CONT */
                WS_CONT.Value = WS_CONT + 1;

                /*" -966- IF WS-CONT > 4000 */

                if (WS_CONT > 4000)
                {

                    /*" -967- DISPLAY 'ESTOURO TAB INTERNA IX1 = ' WS-CONT */
                    _.Display($"ESTOURO TAB INTERNA IX1 = {WS_CONT}");

                    /*" -968- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -970- END-IF */
                }


                /*" -971- MOVE 39 TO TAB-PRODUTO(IX1) */
                _.Move(39, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_PRODUTO);

                /*" -972- MOVE 84500000000 TO TAB-FAIXA-INI(IX1) */
                _.Move(84500000000, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_INI);

                /*" -973- MOVE 84599999999 TO TAB-FAIXA-FIM(IX1) */
                _.Move(84599999999, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_FIM);

                /*" -974- SET IX1 UP BY 1 */
                IX1.Value += 1;

                /*" -975- ADD 1 TO WS-CONT */
                WS_CONT.Value = WS_CONT + 1;

                /*" -976- IF WS-CONT > 4000 */

                if (WS_CONT > 4000)
                {

                    /*" -977- DISPLAY 'ESTOURO TAB INTERNA IX1 = ' WS-CONT */
                    _.Display($"ESTOURO TAB INTERNA IX1 = {WS_CONT}");

                    /*" -978- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -980- END-IF */
                }


                /*" -981- MOVE 39 TO TAB-PRODUTO(IX1) */
                _.Move(39, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_PRODUTO);

                /*" -982- MOVE 84600000000 TO TAB-FAIXA-INI(IX1) */
                _.Move(84600000000, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_INI);

                /*" -983- MOVE 84699999999 TO TAB-FAIXA-FIM(IX1) */
                _.Move(84699999999, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_FIM);

                /*" -984- SET IX1 UP BY 1 */
                IX1.Value += 1;

                /*" -985- ADD 1 TO WS-CONT */
                WS_CONT.Value = WS_CONT + 1;

                /*" -986- IF WS-CONT > 4000 */

                if (WS_CONT > 4000)
                {

                    /*" -987- DISPLAY 'ESTOURO TAB INTERNA IX1 = ' WS-CONT */
                    _.Display($"ESTOURO TAB INTERNA IX1 = {WS_CONT}");

                    /*" -988- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -990- END-IF */
                }


                /*" -991- MOVE 39 TO TAB-PRODUTO(IX1) */
                _.Move(39, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_PRODUTO);

                /*" -992- MOVE 84700000000 TO TAB-FAIXA-INI(IX1) */
                _.Move(84700000000, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_INI);

                /*" -993- MOVE 84799999999 TO TAB-FAIXA-FIM(IX1) */
                _.Move(84799999999, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_FIM);

                /*" -994- SET IX1 UP BY 1 */
                IX1.Value += 1;

                /*" -995- ADD 1 TO WS-CONT */
                WS_CONT.Value = WS_CONT + 1;

                /*" -996- IF WS-CONT > 4000 */

                if (WS_CONT > 4000)
                {

                    /*" -997- DISPLAY 'ESTOURO TAB INTERNA IX1 = ' WS-CONT */
                    _.Display($"ESTOURO TAB INTERNA IX1 = {WS_CONT}");

                    /*" -998- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -999- END-IF */
                }


                /*" -1001- END-IF. */
            }


            /*" -1003- IF 65 NOT LESS WS-COD-PRODUTO-INI AND 65 LESS WS-COD-PRODUTO-FIM */

            if (65 >= WS_COD_PRODUTO_INI && 65 < WS_COD_PRODUTO_FIM)
            {

                /*" -1004- MOVE 65 TO TAB-PRODUTO(IX1) */
                _.Move(65, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_PRODUTO);

                /*" -1005- MOVE 65000000000 TO TAB-FAIXA-INI(IX1) */
                _.Move(65000000000, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_INI);

                /*" -1006- MOVE 65999999999 TO TAB-FAIXA-FIM(IX1) */
                _.Move(65999999999, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_FIM);

                /*" -1007- SET IX1 UP BY 1 */
                IX1.Value += 1;

                /*" -1008- ADD 1 TO WS-CONT */
                WS_CONT.Value = WS_CONT + 1;

                /*" -1009- IF WS-CONT > 4000 */

                if (WS_CONT > 4000)
                {

                    /*" -1010- DISPLAY 'ESTOURO TAB INTERNA IX1 = ' WS-CONT */
                    _.Display($"ESTOURO TAB INTERNA IX1 = {WS_CONT}");

                    /*" -1011- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1013- END-IF */
                }


                /*" -1014- MOVE 65 TO TAB-PRODUTO(IX1) */
                _.Move(65, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_PRODUTO);

                /*" -1015- MOVE 84820000000 TO TAB-FAIXA-INI(IX1) */
                _.Move(84820000000, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_INI);

                /*" -1016- MOVE 84829999999 TO TAB-FAIXA-FIM(IX1) */
                _.Move(84829999999, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_FIM);

                /*" -1017- SET IX1 UP BY 1 */
                IX1.Value += 1;

                /*" -1018- ADD 1 TO WS-CONT */
                WS_CONT.Value = WS_CONT + 1;

                /*" -1019- IF WS-CONT > 4000 */

                if (WS_CONT > 4000)
                {

                    /*" -1020- DISPLAY 'ESTOURO TAB INTERNA IX1 = ' WS-CONT */
                    _.Display($"ESTOURO TAB INTERNA IX1 = {WS_CONT}");

                    /*" -1021- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1022- END-IF */
                }


                /*" -1022- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0230_SAIDA*/

        [StopWatch]
        /*" M-0235-GRAVA-FAIXAS-SECTION */
        private void M_0235_GRAVA_FAIXAS_SECTION()
        {
            /*" -1033- MOVE '0235-GRAVA-FAIXAS       ' TO WS-PARAGRAFO */
            _.Move("0235-GRAVA-FAIXAS       ", WS_MSGERRO.WS_PARAGRAFO);

            /*" -1035- IF WS-QTD-OCORR EQUAL 6 */

            if (WS_PARAM.WS_QTD_OCORR == 6)
            {

                /*" -1036- MOVE 12 TO WS-IDENTIFICA-REG */
                _.Move(12, WS_PARAM.WS_IDENTIFICA_REG);

                /*" -1037- MOVE 9999 TO WS-AGENCIA */
                _.Move(9999, WS_PARAM.WS_AGENCIA);

                /*" -1039- MOVE 'I' TO WS-OPERACAO */
                _.Move("I", WS_PARAM.WS_OPERACAO);

                /*" -1040- MOVE WS-PARAM TO WS-PARAMETROS */
                _.Move(WS_PARAM, WS_PARAMETROS);

                /*" -1041- PERFORM 0214-GRAVA-PARAMETRO */

                M_0214_GRAVA_PARAMETRO_SECTION();

                /*" -1042- ADD 1 TO WS-GRAVA-TIPO12 */
                WS_GRAVA_TIPO12.Value = WS_GRAVA_TIPO12 + 1;

                /*" -1043- MOVE ZEROS TO WS-QTD-OCORR */
                _.Move(0, WS_PARAM.WS_QTD_OCORR);

                /*" -1045- MOVE SPACES TO WS-PARAM. */
                _.Move("", WS_PARAM);
            }


            /*" -1047- ADD 1 TO WS-QTD-OCORR. */
            WS_PARAM.WS_QTD_OCORR.Value = WS_PARAM.WS_QTD_OCORR + 1;

            /*" -1048- IF WS-QTD-OCORR EQUAL 1 */

            if (WS_PARAM.WS_QTD_OCORR == 1)
            {

                /*" -1049- MOVE TAB-PRODUTO(IX1) TO WS-PRODUTO-1 */
                _.Move(TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_PRODUTO, WS_PARAM.WS_PRODUTO_1);

                /*" -1050- MOVE TAB-FAIXA-INI(IX1) TO WS-FXA-INI-1 */
                _.Move(TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_INI, WS_PARAM.WS_FXA_INI_1);

                /*" -1052- MOVE TAB-FAIXA-FIM(IX1) TO WS-FXA-FIM-1. */
                _.Move(TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_FIM, WS_PARAM.WS_FXA_FIM_1);
            }


            /*" -1053- IF WS-QTD-OCORR EQUAL 2 */

            if (WS_PARAM.WS_QTD_OCORR == 2)
            {

                /*" -1054- MOVE TAB-PRODUTO(IX1) TO WS-PRODUTO-2 */
                _.Move(TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_PRODUTO, WS_PARAM.WS_PRODUTO_2);

                /*" -1055- MOVE TAB-FAIXA-INI(IX1) TO WS-FXA-INI-2 */
                _.Move(TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_INI, WS_PARAM.WS_FXA_INI_2);

                /*" -1057- MOVE TAB-FAIXA-FIM(IX1) TO WS-FXA-FIM-2. */
                _.Move(TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_FIM, WS_PARAM.WS_FXA_FIM_2);
            }


            /*" -1058- IF WS-QTD-OCORR EQUAL 3 */

            if (WS_PARAM.WS_QTD_OCORR == 3)
            {

                /*" -1059- MOVE TAB-PRODUTO(IX1) TO WS-PRODUTO-3 */
                _.Move(TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_PRODUTO, WS_PARAM.WS_PRODUTO_3);

                /*" -1060- MOVE TAB-FAIXA-INI(IX1) TO WS-FXA-INI-3 */
                _.Move(TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_INI, WS_PARAM.WS_FXA_INI_3);

                /*" -1062- MOVE TAB-FAIXA-FIM(IX1) TO WS-FXA-FIM-3. */
                _.Move(TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_FIM, WS_PARAM.WS_FXA_FIM_3);
            }


            /*" -1063- IF WS-QTD-OCORR EQUAL 4 */

            if (WS_PARAM.WS_QTD_OCORR == 4)
            {

                /*" -1064- MOVE TAB-PRODUTO(IX1) TO WS-PRODUTO-4 */
                _.Move(TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_PRODUTO, WS_PARAM.WS_PRODUTO_4);

                /*" -1065- MOVE TAB-FAIXA-INI(IX1) TO WS-FXA-INI-4 */
                _.Move(TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_INI, WS_PARAM.WS_FXA_INI_4);

                /*" -1067- MOVE TAB-FAIXA-FIM(IX1) TO WS-FXA-FIM-4. */
                _.Move(TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_FIM, WS_PARAM.WS_FXA_FIM_4);
            }


            /*" -1068- IF WS-QTD-OCORR EQUAL 5 */

            if (WS_PARAM.WS_QTD_OCORR == 5)
            {

                /*" -1069- MOVE TAB-PRODUTO(IX1) TO WS-PRODUTO-5 */
                _.Move(TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_PRODUTO, WS_PARAM.WS_PRODUTO_5);

                /*" -1070- MOVE TAB-FAIXA-INI(IX1) TO WS-FXA-INI-5 */
                _.Move(TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_INI, WS_PARAM.WS_FXA_INI_5);

                /*" -1072- MOVE TAB-FAIXA-FIM(IX1) TO WS-FXA-FIM-5. */
                _.Move(TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_FIM, WS_PARAM.WS_FXA_FIM_5);
            }


            /*" -1073- IF WS-QTD-OCORR EQUAL 6 */

            if (WS_PARAM.WS_QTD_OCORR == 6)
            {

                /*" -1074- MOVE TAB-PRODUTO(IX1) TO WS-PRODUTO-6 */
                _.Move(TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_PRODUTO, WS_PARAM.WS_PRODUTO_6);

                /*" -1075- MOVE TAB-FAIXA-INI(IX1) TO WS-FXA-INI-6 */
                _.Move(TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_INI, WS_PARAM.WS_FXA_INI_6);

                /*" -1077- MOVE TAB-FAIXA-FIM(IX1) TO WS-FXA-FIM-6. */
                _.Move(TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_FIM, WS_PARAM.WS_FXA_FIM_6);
            }


            /*" -1078- SET IX1 UP BY 1 */
            IX1.Value += 1;

            /*" -1080- ADD 1 TO WS-CONT */
            WS_CONT.Value = WS_CONT + 1;

            /*" -1081- IF WS-CONT > 3999 */

            if (WS_CONT > 3999)
            {

                /*" -1082- DISPLAY 'IX1 = ' WS-CONT */
                _.Display($"IX1 = {WS_CONT}");

                /*" -1082- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0235_SAIDA*/

        [StopWatch]
        /*" M-0240-OPEN-CURS02-SECTION */
        private void M_0240_OPEN_CURS02_SECTION()
        {
            /*" -1094- MOVE '0240-OPEN-CURS02        ' TO WS-PARAGRAFO */
            _.Move("0240-OPEN-CURS02        ", WS_MSGERRO.WS_PARAGRAFO);

            /*" -1094- PERFORM M_0240_OPEN_CURS02_DB_OPEN_1 */

            M_0240_OPEN_CURS02_DB_OPEN_1();

            /*" -1097- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1098- MOVE '0240-OPEN-CURS02' TO WS-PARAGRAFO */
                _.Move("0240-OPEN-CURS02", WS_MSGERRO.WS_PARAGRAFO);

                /*" -1099- MOVE 'CURS01' TO WS-NOME-TABELA */
                _.Move("CURS01", WS_MSGERRO.WS_NOME_TABELA);

                /*" -1100- MOVE 'OPEN' TO WS-INSTRUCAO */
                _.Move("OPEN", WS_MSGERRO.WS_INSTRUCAO);

                /*" -1101- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_MSGERRO.WS_SQLCODE);

                /*" -1102- MOVE 'ERRO GRAVE' TO WS-MENSAGEM */
                _.Move("ERRO GRAVE", WS_MSGERRO.WS_MENSAGEM);

                /*" -1103- MOVE SPACES TO WS-CHAVE */
                _.Move("", WS_MSGERRO.WS_CHAVE);

                /*" -1103- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0240-OPEN-CURS02-DB-OPEN-1 */
        public void M_0240_OPEN_CURS02_DB_OPEN_1()
        {
            /*" -1094- EXEC SQL OPEN CURS02 END-EXEC. */

            CURS02.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0240_SAIDA*/

        [StopWatch]
        /*" M-0250-FETCH-CURS02-SECTION */
        private void M_0250_FETCH_CURS02_SECTION()
        {
            /*" -1114- MOVE '0250-FETCH-CURS02       ' TO WS-PARAGRAFO */
            _.Move("0250-FETCH-CURS02       ", WS_MSGERRO.WS_PARAGRAFO);

            /*" -1118- PERFORM M_0250_FETCH_CURS02_DB_FETCH_1 */

            M_0250_FETCH_CURS02_DB_FETCH_1();

            /*" -1121- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1122- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1123- MOVE 'S' TO WS-FIM-CURS02 */
                    _.Move("S", WS_FIM_CURS02);

                    /*" -1123- PERFORM M_0250_FETCH_CURS02_DB_CLOSE_1 */

                    M_0250_FETCH_CURS02_DB_CLOSE_1();

                    /*" -1125- ELSE */
                }
                else
                {


                    /*" -1126- MOVE '0250-FETCH-CURS02' TO WS-PARAGRAFO */
                    _.Move("0250-FETCH-CURS02", WS_MSGERRO.WS_PARAGRAFO);

                    /*" -1127- MOVE 'CURS02' TO WS-NOME-TABELA */
                    _.Move("CURS02", WS_MSGERRO.WS_NOME_TABELA);

                    /*" -1128- MOVE 'FETCH' TO WS-INSTRUCAO */
                    _.Move("FETCH", WS_MSGERRO.WS_INSTRUCAO);

                    /*" -1129- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, WS_MSGERRO.WS_SQLCODE);

                    /*" -1130- MOVE 'ERRO GRAVE' TO WS-MENSAGEM */
                    _.Move("ERRO GRAVE", WS_MSGERRO.WS_MENSAGEM);

                    /*" -1131- MOVE SPACES TO WS-CHAVE */
                    _.Move("", WS_MSGERRO.WS_CHAVE);

                    /*" -1132- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1133- ELSE */
                }

            }
            else
            {


                /*" -1133- ADD 1 TO WS-LIDOS-CURS02. */
                WS_LIDOS_CURS02.Value = WS_LIDOS_CURS02 + 1;
            }


        }

        [StopWatch]
        /*" M-0250-FETCH-CURS02-DB-FETCH-1 */
        public void M_0250_FETCH_CURS02_DB_FETCH_1()
        {
            /*" -1118- EXEC SQL FETCH CURS02 INTO :SICFAIRC-NUM-SICOB-INI, :SICFAIRC-NUM-SICOB-FIM END-EXEC. */

            if (CURS02.Fetch())
            {
                _.Move(CURS02.SICFAIRC_NUM_SICOB_INI, SICFAIRC.DCLSICOB_FAIXA_RCAP.SICFAIRC_NUM_SICOB_INI);
                _.Move(CURS02.SICFAIRC_NUM_SICOB_FIM, SICFAIRC.DCLSICOB_FAIXA_RCAP.SICFAIRC_NUM_SICOB_FIM);
            }

        }

        [StopWatch]
        /*" M-0250-FETCH-CURS02-DB-CLOSE-1 */
        public void M_0250_FETCH_CURS02_DB_CLOSE_1()
        {
            /*" -1123- EXEC SQL CLOSE CURS02 END-EXEC */

            CURS02.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0250_SAIDA*/

        [StopWatch]
        /*" M-0260-CARREGA-TABELA-SECTION */
        private void M_0260_CARREGA_TABELA_SECTION()
        {
            /*" -1144- MOVE '0260-CARREGA-TABELLA    ' TO WS-PARAGRAFO */
            _.Move("0260-CARREGA-TABELLA    ", WS_MSGERRO.WS_PARAGRAFO);

            /*" -1145- MOVE WS-COD-PRODUTO-SIVPF TO TAB-PRODUTO(IX1). */
            _.Move(WS_COD_PRODUTO_SIVPF, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_PRODUTO);

            /*" -1146- MOVE SICFAIRC-NUM-SICOB-INI TO TAB-FAIXA-INI(IX1). */
            _.Move(SICFAIRC.DCLSICOB_FAIXA_RCAP.SICFAIRC_NUM_SICOB_INI, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_INI);

            /*" -1148- MOVE SICFAIRC-NUM-SICOB-FIM TO TAB-FAIXA-FIM(IX1). */
            _.Move(SICFAIRC.DCLSICOB_FAIXA_RCAP.SICFAIRC_NUM_SICOB_FIM, TAB_FAIXAS.TAB_FAIXAS_OCORR[IX1].TAB_FAIXA.TAB_FAIXA_FIM);

            /*" -1149- SET IX1 UP BY 1. */
            IX1.Value += 1;

            /*" -1150- ADD 1 TO WS-CONT */
            WS_CONT.Value = WS_CONT + 1;

            /*" -1151- IF WS-CONT > 299 */

            if (WS_CONT > 299)
            {

                /*" -1152- DISPLAY 'IX1 = ' WS-CONT */
                _.Display($"IX1 = {WS_CONT}");

                /*" -1153- END-IF. */
            }


            /*" -1153- PERFORM 0250-FETCH-CURS02. */

            M_0250_FETCH_CURS02_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0260_SAIDA*/

        [StopWatch]
        /*" M-0300-FINALIZA-SECTION */
        private void M_0300_FINALIZA_SECTION()
        {
            /*" -1165- MOVE '0300-FINALIZA           ' TO WS-PARAGRAFO */
            _.Move("0300-FINALIZA           ", WS_MSGERRO.WS_PARAGRAFO);

            /*" -1167- PERFORM 0301-EXCLUI-RELATORIOS. */

            M_0301_EXCLUI_RELATORIOS_SECTION();

            /*" -1168- IF WS-GRAVA-TIPO12 GREATER ZEROS */

            if (WS_GRAVA_TIPO12 > 00)
            {

                /*" -1169- MOVE 'PF0613B' TO RELATORI-COD-RELATORIO */
                _.Move("PF0613B", RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO);

                /*" -1171- PERFORM 0105-LE-RELATORIOS */

                M_0105_LE_RELATORIOS_SECTION();

                /*" -1172- IF RELATORI-COD-RELATORIO EQUAL SPACES */

                if (RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO.IsEmpty())
                {

                    /*" -1175- PERFORM 0302-INCLUI-RELATORIOS. */

                    M_0302_INCLUI_RELATORIOS_SECTION();
                }

            }


            /*" -1178- CLOSE PARAMETROS-IN PARAMETROS-OUT. */
            PARAMETROS_IN.Close();
            PARAMETROS_OUT.Close();

            /*" -1179- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1180- DISPLAY '*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*' . */
            _.Display($"*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*");

            /*" -1181- DISPLAY '*  TERMINO NORMAL DO PROGRAMA PF0630B   *' . */
            _.Display($"*  TERMINO NORMAL DO PROGRAMA PF0630B   *");

            /*" -1182- DISPLAY '*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*' . */
            _.Display($"*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*");

            /*" -1183- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1184- DISPLAY 'REG. LIDOS    (ARQ PARAMETROS) = ' WS-LIDOS. */
            _.Display($"REG. LIDOS    (ARQ PARAMETROS) = {WS_LIDOS}");

            /*" -1185- DISPLAY 'REG. LIDOS    (FAIXA NUMER.)   = ' WS-LIDOS-CURS01. */
            _.Display($"REG. LIDOS    (FAIXA NUMER.)   = {WS_LIDOS_CURS01}");

            /*" -1186- DISPLAY 'REG. LIDOS    (PROD 7106/8201) = ' WS-LIDOS-CURS02. */
            _.Display($"REG. LIDOS    (PROD 7106/8201) = {WS_LIDOS_CURS02}");

            /*" -1187- DISPLAY 'REG. GRAVADOS (ARQ PARAMETROS) = ' WS-GRAVA. */
            _.Display($"REG. GRAVADOS (ARQ PARAMETROS) = {WS_GRAVA}");

            /*" -1187- DISPLAY 'REG. GRAVADOS (TIPO 12)        = ' WS-GRAVA-TIPO12. */
            _.Display($"REG. GRAVADOS (TIPO 12)        = {WS_GRAVA_TIPO12}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0300_99_EXIT*/

        [StopWatch]
        /*" M-0301-EXCLUI-RELATORIOS-SECTION */
        private void M_0301_EXCLUI_RELATORIOS_SECTION()
        {
            /*" -1198- MOVE '0301-EXCLUI-RELATORIOS  ' TO WS-PARAGRAFO */
            _.Move("0301-EXCLUI-RELATORIOS  ", WS_MSGERRO.WS_PARAGRAFO);

            /*" -1204- PERFORM M_0301_EXCLUI_RELATORIOS_DB_DELETE_1 */

            M_0301_EXCLUI_RELATORIOS_DB_DELETE_1();

            /*" -1208- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL +100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != +100)
            {

                /*" -1209- MOVE '0301-EXCLUI-RELATORIOS' TO WS-PARAGRAFO */
                _.Move("0301-EXCLUI-RELATORIOS", WS_MSGERRO.WS_PARAGRAFO);

                /*" -1210- MOVE 'RELATORIOS' TO WS-NOME-TABELA */
                _.Move("RELATORIOS", WS_MSGERRO.WS_NOME_TABELA);

                /*" -1211- MOVE 'DELETE' TO WS-INSTRUCAO */
                _.Move("DELETE", WS_MSGERRO.WS_INSTRUCAO);

                /*" -1212- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_MSGERRO.WS_SQLCODE);

                /*" -1213- MOVE 'ERRO GRAVE' TO WS-MENSAGEM */
                _.Move("ERRO GRAVE", WS_MSGERRO.WS_MENSAGEM);

                /*" -1214- MOVE SPACES TO WS-CHAVE-ACESSO */
                _.Move("", WS_CHAVE_ACESSO);

                /*" -1215- MOVE 'PF' TO WS-CAMPO1 */
                _.Move("PF", WS_CHAVE_ACESSO.WS_CAMPO1);

                /*" -1216- MOVE 'PF0630B' TO WS-CAMPO2 */
                _.Move("PF0630B", WS_CHAVE_ACESSO.WS_CAMPO2);

                /*" -1217- MOVE WS-CHAVE-ACESSO TO WS-CHAVE */
                _.Move(WS_CHAVE_ACESSO, WS_MSGERRO.WS_CHAVE);

                /*" -1217- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0301-EXCLUI-RELATORIOS-DB-DELETE-1 */
        public void M_0301_EXCLUI_RELATORIOS_DB_DELETE_1()
        {
            /*" -1204- EXEC SQL DELETE FROM SEGUROS.RELATORIOS WHERE IDE_SISTEMA = 'PF' AND COD_RELATORIO = 'PF0630B' AND SIT_REGISTRO = '0' END-EXEC. */

            var m_0301_EXCLUI_RELATORIOS_DB_DELETE_1_Delete1 = new M_0301_EXCLUI_RELATORIOS_DB_DELETE_1_Delete1()
            {
            };

            M_0301_EXCLUI_RELATORIOS_DB_DELETE_1_Delete1.Execute(m_0301_EXCLUI_RELATORIOS_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0301_SAIDA*/

        [StopWatch]
        /*" M-0302-INCLUI-RELATORIOS-SECTION */
        private void M_0302_INCLUI_RELATORIOS_SECTION()
        {
            /*" -1228- MOVE '0302-INCLUI-RELATORIOS  ' TO WS-PARAGRAFO */
            _.Move("0302-INCLUI-RELATORIOS  ", WS_MSGERRO.WS_PARAGRAFO);

            /*" -1271- PERFORM M_0302_INCLUI_RELATORIOS_DB_INSERT_1 */

            M_0302_INCLUI_RELATORIOS_DB_INSERT_1();

            /*" -1274- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1275- MOVE '0302-INCLUI-RELATORIOS' TO WS-PARAGRAFO */
                _.Move("0302-INCLUI-RELATORIOS", WS_MSGERRO.WS_PARAGRAFO);

                /*" -1276- MOVE 'RELATORIOS' TO WS-NOME-TABELA */
                _.Move("RELATORIOS", WS_MSGERRO.WS_NOME_TABELA);

                /*" -1277- MOVE 'DELETE' TO WS-INSTRUCAO */
                _.Move("DELETE", WS_MSGERRO.WS_INSTRUCAO);

                /*" -1278- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_MSGERRO.WS_SQLCODE);

                /*" -1279- MOVE 'ERRO GRAVE' TO WS-MENSAGEM */
                _.Move("ERRO GRAVE", WS_MSGERRO.WS_MENSAGEM);

                /*" -1280- MOVE SPACES TO WS-CHAVE-ACESSO */
                _.Move("", WS_CHAVE_ACESSO);

                /*" -1281- MOVE 'PF' TO WS-CAMPO1 */
                _.Move("PF", WS_CHAVE_ACESSO.WS_CAMPO1);

                /*" -1282- MOVE 'PF0613B' TO WS-CAMPO2 */
                _.Move("PF0613B", WS_CHAVE_ACESSO.WS_CAMPO2);

                /*" -1283- MOVE WS-CHAVE-ACESSO TO WS-CHAVE */
                _.Move(WS_CHAVE_ACESSO, WS_MSGERRO.WS_CHAVE);

                /*" -1283- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0302-INCLUI-RELATORIOS-DB-INSERT-1 */
        public void M_0302_INCLUI_RELATORIOS_DB_INSERT_1()
        {
            /*" -1271- EXEC SQL INSERT INTO SEGUROS.RELATORIOS VALUES ( 'PF0630B' , CURRENT DATE, 'PF' , 'PF0613B' , 0, 0, CURRENT DATE, CURRENT DATE, CURRENT DATE, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '0' , ' ' , ' ' , NULL, NULL, NULL, CURRENT TIMESTAMP) END-EXEC. */

            var m_0302_INCLUI_RELATORIOS_DB_INSERT_1_Insert1 = new M_0302_INCLUI_RELATORIOS_DB_INSERT_1_Insert1()
            {
            };

            M_0302_INCLUI_RELATORIOS_DB_INSERT_1_Insert1.Execute(m_0302_INCLUI_RELATORIOS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0302_SAIDA*/

        [StopWatch]
        /*" M-9999-ERRO-SECTION */
        private void M_9999_ERRO_SECTION()
        {
            /*" -1293- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1294- DISPLAY '*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*' . */
            _.Display($"*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*");

            /*" -1295- DISPLAY '*  TERMINO ANORMAL DO PROGRAMA PF0630B  *' . */
            _.Display($"*  TERMINO ANORMAL DO PROGRAMA PF0630B  *");

            /*" -1296- DISPLAY '*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*' . */
            _.Display($"*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*");

            /*" -1297- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1298- DISPLAY 'PARAGRAFO       = ' WS-PARAGRAFO. */
            _.Display($"PARAGRAFO       = {WS_MSGERRO.WS_PARAGRAFO}");

            /*" -1299- DISPLAY 'TABELA          = ' WS-NOME-TABELA. */
            _.Display($"TABELA          = {WS_MSGERRO.WS_NOME_TABELA}");

            /*" -1300- DISPLAY 'SQLCODE         = ' WS-SQLCODE. */
            _.Display($"SQLCODE         = {WS_MSGERRO.WS_SQLCODE}");

            /*" -1301- DISPLAY 'MENSAGEM        = ' WS-MENSAGEM. */
            _.Display($"MENSAGEM        = {WS_MSGERRO.WS_MENSAGEM}");

            /*" -1303- DISPLAY 'CHAVE DE ACESSO = ' WS-CHAVE. */
            _.Display($"CHAVE DE ACESSO = {WS_MSGERRO.WS_CHAVE}");

            /*" -1304- MOVE SQLERRMC TO WSQLERRMC */
            _.Move(DB.SQLERRMC, WSQLERRO.WSQLERRMC);

            /*" -1306- DISPLAY WSQLERRO */
            _.Display(WSQLERRO);

            /*" -1306- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1309- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1309- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9999_SAIDA*/
    }
}