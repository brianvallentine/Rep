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
using Sias.Geral.DB2.GE0531S;

namespace Code
{
    public class GE0531S
    {
        public bool IsCall { get; set; }

        public GE0531S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-----------------------------------------------------------------      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................:  CORPORATIVO                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   PROGRAMA ...............:  GE0531S                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............:  FLAVIO DE LIMA SILVA              *      */
        /*"      *   PROGRAMADOR ............:  FLAVIO DE LIMA SILVA              *      */
        /*"      *   DATA CODIFICACAO .......:  JUNHO/2019.                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................:  Gravar na tabela                  *      */
        /*"      *                              SIUS.GE_VALIDA_PESSOA_LOG as      *      */
        /*"      *                              consultas realizadas nas bases de *      */
        /*"      *                              dados que buscam validar situa��o *      */
        /*"      *                              cadastral das pessoas quanto a    *      */
        /*"      *                              restri��o ou pend�ncia de qualquer*      */
        /*"      *                              natureza, seja pessoal ou jur�dica*      */
        /*"      *                            - Exemplo de bases de dados internas*      */
        /*"      *                              ou de �rg�os externos consultadas:*      */
        /*"      *                           1) PEP "SIUS.GE_PEPS_PESSOA_EXPOSTAS"*      */
        /*"      *                           2) NLIST                             *      */
        /*"      *                           3) BLACKLIST                         *      */
        /*"      *                                                                *      */
        /*"      *                       O campo STA_REGISTRO: 1 - Sem Restri��o, *      */
        /*"      *                                             2 - Restri��o.     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   N    VERSAO   RESPONSAVEL          DATA        ALTERACAO     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   1      01     FLAVIO DE LIMA    28/06/2019    JAZZ 197.432   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *            E N V I R O N M E N T   D I V I S I O N             *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        /*"77  WS-QT-ENDOSSO                    PIC S9(006) VALUE +0 COMP.*/
        public IntBasis WS_QT_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "6", "S9(006)"));
        /*"77  WS-QT-PROPOSTA                   PIC S9(006) VALUE +0 COMP.*/
        public IntBasis WS_QT_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "6", "S9(006)"));

        /*"01  WS-ERRO                          PIC S9(009) COMP   VALUE +0*/
        public IntBasis WS_ERRO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  WS-IND                           PIC S9(009) COMP   VALUE +0*/
        public IntBasis WS_IND { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  WS-IND1                          PIC S9(009) COMP   VALUE +0*/
        public IntBasis WS_IND1 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  WS-DISPLAY                       PIC  X(003) VALUE 'S'.*/
        public StringBasis WS_DISPLAY { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"S");
        /*"01  WS-MENSAGEM                      PIC  X(100) VALUE SPACES.*/
        public StringBasis WS_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "100", "X(100)"), @"");
        /*"01  WS-PARAGRAFO                     PIC  X(008) VALUE SPACES.*/
        public StringBasis WS_PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"01  WS-SQLCODE                       PIC  -ZZZ999.*/
        public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("9", "6", "-ZZZ999."));
        /*"01  WNR-EXE                          PIC  X(004) VALUE '0000'.*/
        public StringBasis WNR_EXE { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
        /*"01  WS-SEQ-PESSOA-LOG                PIC S9(009) COMP VALUE 0.*/
        public IntBasis WS_SEQ_PESSOA_LOG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  WABEND.*/
        public GE0531S_WABEND WABEND { get; set; } = new GE0531S_WABEND();
        public class GE0531S_WABEND : VarBasis
        {
            /*"    05  WABEND1                      PIC  X(009)  VALUE                                                      'GE0531S '*/
            public StringBasis WABEND1 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"GE0531S ");
            /*"    05  WABEND2.*/
            public GE0531S_WABEND2 WABEND2 { get; set; } = new GE0531S_WABEND2();
            public class GE0531S_WABEND2 : VarBasis
            {
                /*"        10  FILLER                   PIC  X(025)  VALUE                                     '*** ERRO EXEC SQL NUMERO '*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"*** ERRO EXEC SQL NUMERO ");
                /*"        10  WNR-EXEC-SQL             PIC  X(005)  VALUE SPACES.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"    05  WABEND3.*/
            }
            public GE0531S_WABEND3 WABEND3 { get; set; } = new GE0531S_WABEND3();
            public class GE0531S_WABEND3 : VarBasis
            {
                /*"        10  FILLER                   PIC  X(013)  VALUE                                                 ' *** SQLCODE '*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"        10  WSQLCODE                 PIC  -999.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "3", "-999."));
                /*"01  GE615-NUM-CPF-CNPJ-NULO          PIC S9(004) COMP VALUE 0.*/
            }
        }
        public IntBasis GE615_NUM_CPF_CNPJ_NULO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  GE615-SEQ-REGISTRO-NULO          PIC S9(004) COMP VALUE 0.*/
        public IntBasis GE615_SEQ_REGISTRO_NULO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  GE615-NUM-RAMO-EMISSOR-NULO      PIC S9(004) COMP VALUE 0.*/
        public IntBasis GE615_NUM_RAMO_EMISSOR_NULO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  GE615-COD-PRODUTO-NULO           PIC S9(004) COMP VALUE 0.*/
        public IntBasis GE615_COD_PRODUTO_NULO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  GE615-COD-FONTE-NULO             PIC S9(004) COMP VALUE 0.*/
        public IntBasis GE615_COD_FONTE_NULO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  GE615-NUM-PROPOSTA-NULO          PIC S9(004) COMP VALUE 0.*/
        public IntBasis GE615_NUM_PROPOSTA_NULO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  GE615-NOM-SEGURADO-NULO          PIC S9(004) COMP VALUE 0.*/
        public IntBasis GE615_NOM_SEGURADO_NULO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  GE615-IND-TP-RELAC-INT-NULO      PIC S9(004) COMP VALUE 0.*/
        public IntBasis GE615_IND_TP_RELAC_INT_NULO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  GE615-IND-TIPO-PESSOA-NULO       PIC S9(004) COMP VALUE 0.*/
        public IntBasis GE615_IND_TIPO_PESSOA_NULO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  GE615-IND-MOVIMENTO-NULO         PIC S9(004) COMP VALUE 0.*/
        public IntBasis GE615_IND_MOVIMENTO_NULO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  GE615-IND-EVENTO-NULO            PIC S9(004) COMP VALUE 0.*/
        public IntBasis GE615_IND_EVENTO_NULO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  GE615-STA-REGISTRO-NULO          PIC S9(004) COMP VALUE 0.*/
        public IntBasis GE615_STA_REGISTRO_NULO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  GE615-COD-ORIGEM-NULO            PIC S9(004) COMP VALUE 0.*/
        public IntBasis GE615_COD_ORIGEM_NULO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  GE615-NOM-PROGRAMA-NULO          PIC S9(004) COMP VALUE 0.*/
        public IntBasis GE615_NOM_PROGRAMA_NULO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  GE615-DTH-CADASTRAMENTO-NULO     PIC S9(004) COMP VALUE 0.*/
        public IntBasis GE615_DTH_CADASTRAMENTO_NULO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  GDA-DTA-INCL-PEP                 PIC  X(010) VALUE SPACES.*/
        public StringBasis GDA_DTA_INCL_PEP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");


        public Copies.LBGE0531 LBGE0531 { get; set; } = new Copies.LBGE0531();
        public Dclgens.GE615 GE615 { get; set; } = new Dclgens.GE615();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(LBGE0531_LK_GE0531 LBGE0531_LK_GE0531_P) //PROCEDURE DIVISION USING 
        /*LK_GE0531*/
        {
            try
            {
                this.LBGE0531.LK_GE0531 = LBGE0531_LK_GE0531_P;

                /*" -124- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -125- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -126- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -130- PERFORM R000-00-INFORMES. */

                R000_00_INFORMES_SECTION();

                /*" -132- PERFORM R0000-00-INICIO. */

                R0000_00_INICIO_SECTION();

                /*" -134- PERFORM R1000-00-PROCESSAR. */

                R1000_00_PROCESSAR_SECTION();

                /*" -134- PERFORM R2000-00-FINALIZAR. */

                R2000_00_FINALIZAR_SECTION();

                /*" -134- FLUXCONTROL_PERFORM R000-00-INFORMES-SECTION */

                R000_00_INFORMES_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LBGE0531.LK_GE0531 };
            return Result;
        }

        [StopWatch]
        /*" R000-00-INFORMES-SECTION */
        private void R000_00_INFORMES_SECTION()
        {
            /*" -142- MOVE 'R000-INF' TO WS-PARAGRAFO */
            _.Move("R000-INF", WS_PARAGRAFO);

            /*" -143- DISPLAY ' ' */
            _.Display($" ");

            /*" -144- DISPLAY '***************************************************' */
            _.Display($"***************************************************");

            /*" -145- DISPLAY 'PROGRAMA GE0531S EM EXECUCAO' */
            _.Display($"PROGRAMA GE0531S EM EXECUCAO");

            /*" -152- DISPLAY 'COMPILADO EM ' FUNCTION WHEN-COMPILED(7:2) '/' FUNCTION WHEN-COMPILED(5:2) '/' FUNCTION WHEN-COMPILED(1:4) ' AS ' FUNCTION WHEN-COMPILED(9:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) ' *' */

            $"COMPILADO EM FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)} AS FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)} *"
            .Display();

            /*" -153- DISPLAY '***************************************************' */
            _.Display($"***************************************************");

            /*" -154- DISPLAY ' ' */
            _.Display($" ");

            /*" -161- DISPLAY '-->INICIOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) '<--' */

            $"-->INICIOU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}<--"
            .Display();

            /*" -161- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R000_99_EXIT*/

        [StopWatch]
        /*" R0000-00-INICIO-SECTION */
        private void R0000_00_INICIO_SECTION()
        {
            /*" -171- MOVE 'R0000-00' TO WS-PARAGRAFO */
            _.Move("R0000-00", WS_PARAGRAFO);

            /*" -173- INITIALIZE DCLGE-PESSOA-VALIDA-LOG */
            _.Initialize(
                GE615.DCLGE_PESSOA_VALIDA_LOG
            );

            /*" -174- DISPLAY '!!!!!GE0531S-INICIO !!!!!!!!!!!!!!!!!!' */
            _.Display($"!!!!!GE0531S-INICIO !!!!!!!!!!!!!!!!!!");

            /*" -175- DISPLAY 'CPF-CNPJ          :' LK-GE0531-CPF-CNPJ */
            _.Display($"CPF-CNPJ          :{LBGE0531.LK_GE0531.LK_GE0531_CPF_CNPJ}");

            /*" -176- DISPLAY 'SEQ-REGISTRO      :' LK-GE0531-SEQ-REGISTRO */
            _.Display($"SEQ-REGISTRO      :{LBGE0531.LK_GE0531.LK_GE0531_SEQ_REGISTRO}");

            /*" -177- DISPLAY 'NOM-SEGURADO      :' LK-GE0531-NOM-SEGURADO */
            _.Display($"NOM-SEGURADO      :{LBGE0531.LK_GE0531.LK_GE0531_NOM_SEGURADO}");

            /*" -178- DISPLAY 'NUM-RAMO-EMISSOR  :' LK-GE0531-NUM-RAMO-EMISSOR */
            _.Display($"NUM-RAMO-EMISSOR  :{LBGE0531.LK_GE0531.LK_GE0531_NUM_RAMO_EMISSOR}");

            /*" -199- DISPLAY 'COD-PRODUTO       :' LK-GE0531-COD-PRODUTO */
            _.Display($"COD-PRODUTO       :{LBGE0531.LK_GE0531.LK_GE0531_COD_PRODUTO}");

            /*" -200- DISPLAY 'NOM-PROGRAMA      :' LK-GE0531-NOM-PROGRAMA */
            _.Display($"NOM-PROGRAMA      :{LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_NOM_PROGRAMA}");

            /*" -205- DISPLAY 'DTH-CAD           :' LK-GE0531-DTH-CAD */
            _.Display($"DTH-CAD           :{LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_DTH_CAD}");

            /*" -206- IF LK-GE0531-NUM-RAMO-EMISSOR IS NOT NUMERIC */

            if (!LBGE0531.LK_GE0531.LK_GE0531_NUM_RAMO_EMISSOR.IsNumeric())
            {

                /*" -207- MOVE 01 TO LK-GE0531-COD-RETORNO */
                _.Move(01, LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_COD_RETORNO);

                /*" -209- MOVE 'GE0531S - Ramo Emissor invalido.' TO LK-GE0531-MSG-RETORNO */
                _.Move("GE0531S - Ramo Emissor invalido.", LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_MSG_RETORNO);

                /*" -210- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -212- END-IF */
            }


            /*" -213- IF LK-GE0531-NUM-RAMO-EMISSOR EQUAL ZEROS */

            if (LBGE0531.LK_GE0531.LK_GE0531_NUM_RAMO_EMISSOR == 00)
            {

                /*" -214- MOVE 02 TO LK-GE0531-COD-RETORNO */
                _.Move(02, LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_COD_RETORNO);

                /*" -216- MOVE 'GE0531S - Ramo Emissor zerado.' TO LK-GE0531-MSG-RETORNO */
                _.Move("GE0531S - Ramo Emissor zerado.", LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_MSG_RETORNO);

                /*" -217- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -219- END-IF */
            }


            /*" -220- IF LK-GE0531-NUM-RAMO-EMISSOR EQUAL 61 OR 65 OR 66 OR 68 */

            if (LBGE0531.LK_GE0531.LK_GE0531_NUM_RAMO_EMISSOR.In("61", "65", "66", "68"))
            {

                /*" -221- PERFORM R0005-00-RAMOS-HAB */

                R0005_00_RAMOS_HAB_SECTION();

                /*" -223- END-IF */
            }


            /*" -224- IF LK-GE0531-NUM-RAMO-EMISSOR EQUAL 18 */

            if (LBGE0531.LK_GE0531.LK_GE0531_NUM_RAMO_EMISSOR == 18)
            {

                /*" -225- PERFORM R0010-00-RAMO-LOT */

                R0010_00_RAMO_LOT_SECTION();

                /*" -226- END-IF */
            }


            /*" -226- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0005-00-RAMOS-HAB-SECTION */
        private void R0005_00_RAMOS_HAB_SECTION()
        {
            /*" -234- IF LK-GE0531-NUM-SINISTRO IS NOT NUMERIC */

            if (!LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_NUM_SINISTRO.IsNumeric())
            {

                /*" -235- MOVE 03 TO LK-GE0531-COD-RETORNO */
                _.Move(03, LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_COD_RETORNO);

                /*" -237- MOVE 'GE0531S - Apolice de Sinistro - invalido.' TO LK-GE0531-MSG-RETORNO */
                _.Move("GE0531S - Apolice de Sinistro - invalido.", LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_MSG_RETORNO);

                /*" -238- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -240- END-IF */
            }


            /*" -241- IF LK-GE0531-NUM-SINISTRO EQUAL ZEROS */

            if (LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_NUM_SINISTRO == 00)
            {

                /*" -242- MOVE 04 TO LK-GE0531-COD-RETORNO */
                _.Move(04, LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_COD_RETORNO);

                /*" -244- MOVE 'GE0531S - Apolice de Sinistro zerado.' TO LK-GE0531-MSG-RETORNO */
                _.Move("GE0531S - Apolice de Sinistro zerado.", LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_MSG_RETORNO);

                /*" -245- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -247- END-IF */
            }


            /*" -248- IF LK-GE0531-COD-PRODUTO IS NOT NUMERIC */

            if (!LBGE0531.LK_GE0531.LK_GE0531_COD_PRODUTO.IsNumeric())
            {

                /*" -249- MOVE 05 TO LK-GE0531-COD-RETORNO */
                _.Move(05, LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_COD_RETORNO);

                /*" -251- MOVE 'GE0531S - Codigo produto invalido.' TO LK-GE0531-MSG-RETORNO */
                _.Move("GE0531S - Codigo produto invalido.", LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_MSG_RETORNO);

                /*" -252- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -254- END-IF */
            }


            /*" -255- IF LK-GE0531-COD-PRODUTO EQUAL ZEROS */

            if (LBGE0531.LK_GE0531.LK_GE0531_COD_PRODUTO == 00)
            {

                /*" -256- MOVE 06 TO LK-GE0531-COD-RETORNO */
                _.Move(06, LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_COD_RETORNO);

                /*" -258- MOVE 'GE0531S - Codigo produto zerado.' TO LK-GE0531-MSG-RETORNO */
                _.Move("GE0531S - Codigo produto zerado.", LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_MSG_RETORNO);

                /*" -259- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -261- END-IF */
            }


            /*" -262- IF LK-GE0531-STA-REGISTRO EQUAL ZEROS */

            if (LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_STA_REGISTRO == 00)
            {

                /*" -263- MOVE 07 TO LK-GE0531-COD-RETORNO */
                _.Move(07, LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_COD_RETORNO);

                /*" -265- MOVE 'GE0531S - Codigo de restricao nao informado.' TO LK-GE0531-MSG-RETORNO */
                _.Move("GE0531S - Codigo de restricao nao informado.", LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_MSG_RETORNO);

                /*" -266- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -270- END-IF */
            }


            /*" -271- IF LK-GE0531-STA-REGISTRO NOT EQUAL 1 AND 2 */

            if (!LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_STA_REGISTRO.In("1", "2"))
            {

                /*" -272- MOVE 08 TO LK-GE0531-COD-RETORNO */
                _.Move(08, LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_COD_RETORNO);

                /*" -274- MOVE 'GE0531S - Codigo de restricao diferente de 1 e 2.' TO LK-GE0531-MSG-RETORNO */
                _.Move("GE0531S - Codigo de restricao diferente de 1 e 2.", LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_MSG_RETORNO);

                /*" -275- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -277- END-IF */
            }


            /*" -278- IF LK-GE0531-IND-EVENTO IS NOT NUMERIC */

            if (!LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_IND_EVENTO.IsNumeric())
            {

                /*" -279- MOVE 09 TO LK-GE0531-COD-RETORNO */
                _.Move(09, LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_COD_RETORNO);

                /*" -281- MOVE 'GE0531S - Indicador do Evento - invalido.' TO LK-GE0531-MSG-RETORNO */
                _.Move("GE0531S - Indicador do Evento - invalido.", LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_MSG_RETORNO);

                /*" -282- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -284- END-IF */
            }


            /*" -285- IF LK-GE0531-IND-EVENTO EQUAL ZEROS */

            if (LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_IND_EVENTO == 00)
            {

                /*" -286- MOVE 10 TO LK-GE0531-COD-RETORNO */
                _.Move(10, LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_COD_RETORNO);

                /*" -288- MOVE 'GE0531S - Indicador do Evento - zerado.' TO LK-GE0531-MSG-RETORNO */
                _.Move("GE0531S - Indicador do Evento - zerado.", LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_MSG_RETORNO);

                /*" -289- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -291- END-IF */
            }


            /*" -292- IF LK-GE0531-IND-MOVIMENTO IS NOT NUMERIC */

            if (!LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_IND_MOVIMENTO.IsNumeric())
            {

                /*" -293- MOVE 11 TO LK-GE0531-COD-RETORNO */
                _.Move(11, LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_COD_RETORNO);

                /*" -295- MOVE 'GE0531S - Indicador do movimento - invalido.' TO LK-GE0531-MSG-RETORNO */
                _.Move("GE0531S - Indicador do movimento - invalido.", LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_MSG_RETORNO);

                /*" -296- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -298- END-IF */
            }


            /*" -299- IF LK-GE0531-IND-MOVIMENTO EQUAL ZEROS */

            if (LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_IND_MOVIMENTO == 00)
            {

                /*" -300- MOVE 12 TO LK-GE0531-COD-RETORNO */
                _.Move(12, LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_COD_RETORNO);

                /*" -302- MOVE 'GE0531S - Indicador do movimento - zerado.' TO LK-GE0531-MSG-RETORNO */
                _.Move("GE0531S - Indicador do movimento - zerado.", LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_MSG_RETORNO);

                /*" -303- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -304- END-IF */
            }


            /*" -304- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0005_99_SAIDA*/

        [StopWatch]
        /*" R0010-00-RAMO-LOT-SECTION */
        private void R0010_00_RAMO_LOT_SECTION()
        {
            /*" -312- IF LK-GE0531-CPF-CNPJ EQUAL ZEROS */

            if (LBGE0531.LK_GE0531.LK_GE0531_CPF_CNPJ == 00)
            {

                /*" -313- MOVE 13 TO LK-GE0531-COD-RETORNO */
                _.Move(13, LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_COD_RETORNO);

                /*" -315- MOVE 'GE0531S - CPF/CNPJ - invalido.' TO LK-GE0531-MSG-RETORNO */
                _.Move("GE0531S - CPF/CNPJ - invalido.", LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_MSG_RETORNO);

                /*" -316- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -318- END-IF */
            }


            /*" -319- IF LK-GE0531-COD-PRODUTO IS NOT NUMERIC */

            if (!LBGE0531.LK_GE0531.LK_GE0531_COD_PRODUTO.IsNumeric())
            {

                /*" -320- MOVE 14 TO LK-GE0531-COD-RETORNO */
                _.Move(14, LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_COD_RETORNO);

                /*" -322- MOVE 'GE0531S - Codigo produto invalido.' TO LK-GE0531-MSG-RETORNO */
                _.Move("GE0531S - Codigo produto invalido.", LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_MSG_RETORNO);

                /*" -323- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -325- END-IF */
            }


            /*" -326- IF LK-GE0531-COD-PRODUTO EQUAL ZEROS */

            if (LBGE0531.LK_GE0531.LK_GE0531_COD_PRODUTO == 00)
            {

                /*" -327- MOVE 15 TO LK-GE0531-COD-RETORNO */
                _.Move(15, LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_COD_RETORNO);

                /*" -329- MOVE 'GE0531S - Codigo produto zerado.' TO LK-GE0531-MSG-RETORNO */
                _.Move("GE0531S - Codigo produto zerado.", LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_MSG_RETORNO);

                /*" -330- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -332- END-IF */
            }


            /*" -333- IF LK-GE0531-COD-FONTE EQUAL ZEROS */

            if (LBGE0531.LK_GE0531.LK_GE0531_COD_FONTE == 00)
            {

                /*" -334- MOVE 16 TO LK-GE0531-COD-RETORNO */
                _.Move(16, LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_COD_RETORNO);

                /*" -336- MOVE 'GE0531S - Codigo fonte invalido.' TO LK-GE0531-MSG-RETORNO */
                _.Move("GE0531S - Codigo fonte invalido.", LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_MSG_RETORNO);

                /*" -337- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -339- END-IF */
            }


            /*" -340- IF LK-GE0531-NUM-PROPOSTA EQUAL ZEROS */

            if (LBGE0531.LK_GE0531.LK_GE0531_NUM_PROPOSTA == 00)
            {

                /*" -341- MOVE 17 TO LK-GE0531-COD-RETORNO */
                _.Move(17, LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_COD_RETORNO);

                /*" -343- MOVE 'GE0531S - Proposta invalida.' TO LK-GE0531-MSG-RETORNO */
                _.Move("GE0531S - Proposta invalida.", LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_MSG_RETORNO);

                /*" -344- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -346- END-IF */
            }


            /*" -347- IF LK-GE0531-NUM-CERTIFIC-EXT IS NOT NUMERIC */

            if (!LBGE0531.LK_GE0531.LK_GE0531_NUM_CERTIFIC_EXT.IsNumeric())
            {

                /*" -348- MOVE 18 TO LK-GE0531-COD-RETORNO */
                _.Move(18, LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_COD_RETORNO);

                /*" -350- MOVE 'GE0531S - Codigo cliente invalido.' TO LK-GE0531-MSG-RETORNO */
                _.Move("GE0531S - Codigo cliente invalido.", LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_MSG_RETORNO);

                /*" -351- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -353- END-IF */
            }


            /*" -354- IF LK-GE0531-NUM-CERTIFIC-EXT EQUAL ZEROS */

            if (LBGE0531.LK_GE0531.LK_GE0531_NUM_CERTIFIC_EXT == 00)
            {

                /*" -355- MOVE 19 TO LK-GE0531-COD-RETORNO */
                _.Move(19, LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_COD_RETORNO);

                /*" -357- MOVE 'GE0531S - Codigo cliente zerado.' TO LK-GE0531-MSG-RETORNO */
                _.Move("GE0531S - Codigo cliente zerado.", LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_MSG_RETORNO);

                /*" -358- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -360- END-IF */
            }


            /*" -361- IF LK-GE0531-NOM-SEGURADO EQUAL SPACES */

            if (LBGE0531.LK_GE0531.LK_GE0531_NOM_SEGURADO.IsEmpty())
            {

                /*" -362- MOVE 20 TO LK-GE0531-COD-RETORNO */
                _.Move(20, LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_COD_RETORNO);

                /*" -364- MOVE 'GE0531S - Nome do segurado invalido.' TO LK-GE0531-MSG-RETORNO */
                _.Move("GE0531S - Nome do segurado invalido.", LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_MSG_RETORNO);

                /*" -365- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -367- END-IF */
            }


            /*" -368- IF LK-GE0531-STA-REGISTRO EQUAL ZEROS */

            if (LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_STA_REGISTRO == 00)
            {

                /*" -369- MOVE 21 TO LK-GE0531-COD-RETORNO */
                _.Move(21, LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_COD_RETORNO);

                /*" -371- MOVE 'GE0531S - Codigo de restricao nao informado.' TO LK-GE0531-MSG-RETORNO */
                _.Move("GE0531S - Codigo de restricao nao informado.", LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_MSG_RETORNO);

                /*" -372- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -376- END-IF */
            }


            /*" -377- IF LK-GE0531-STA-REGISTRO NOT EQUAL 1 AND 2 */

            if (!LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_STA_REGISTRO.In("1", "2"))
            {

                /*" -378- MOVE 22 TO LK-GE0531-COD-RETORNO */
                _.Move(22, LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_COD_RETORNO);

                /*" -380- MOVE 'GE0531S - Codigo de restricao diferente de 1 e 2.' TO LK-GE0531-MSG-RETORNO */
                _.Move("GE0531S - Codigo de restricao diferente de 1 e 2.", LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_MSG_RETORNO);

                /*" -381- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -383- END-IF */
            }


            /*" -384- IF LK-GE0531-IND-EVENTO IS NOT NUMERIC */

            if (!LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_IND_EVENTO.IsNumeric())
            {

                /*" -385- MOVE 23 TO LK-GE0531-COD-RETORNO */
                _.Move(23, LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_COD_RETORNO);

                /*" -387- MOVE 'GE0531S - Indicador do Evento - invalido.' TO LK-GE0531-MSG-RETORNO */
                _.Move("GE0531S - Indicador do Evento - invalido.", LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_MSG_RETORNO);

                /*" -388- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -390- END-IF */
            }


            /*" -391- IF LK-GE0531-IND-EVENTO EQUAL ZEROS */

            if (LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_IND_EVENTO == 00)
            {

                /*" -392- MOVE 24 TO LK-GE0531-COD-RETORNO */
                _.Move(24, LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_COD_RETORNO);

                /*" -394- MOVE 'GE0531S - Indicador do Evento - zerado.' TO LK-GE0531-MSG-RETORNO */
                _.Move("GE0531S - Indicador do Evento - zerado.", LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_MSG_RETORNO);

                /*" -395- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -397- END-IF */
            }


            /*" -398- IF LK-GE0531-COD-RELACAO-INT IS NOT NUMERIC */

            if (!LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_COD_RELACAO_INT.IsNumeric())
            {

                /*" -399- MOVE 25 TO LK-GE0531-COD-RETORNO */
                _.Move(25, LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_COD_RETORNO);

                /*" -401- MOVE 'GE0531S - Tipo de relacao com CS - invalido.' TO LK-GE0531-MSG-RETORNO */
                _.Move("GE0531S - Tipo de relacao com CS - invalido.", LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_MSG_RETORNO);

                /*" -402- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -404- END-IF */
            }


            /*" -405- IF LK-GE0531-COD-RELACAO-INT EQUAL ZEROS */

            if (LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_COD_RELACAO_INT == 00)
            {

                /*" -406- MOVE 26 TO LK-GE0531-COD-RETORNO */
                _.Move(26, LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_COD_RETORNO);

                /*" -408- MOVE 'GE0531S - Tipo de relacao com CS - zerado.' TO LK-GE0531-MSG-RETORNO */
                _.Move("GE0531S - Tipo de relacao com CS - zerado.", LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_MSG_RETORNO);

                /*" -409- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -411- END-IF */
            }


            /*" -412- IF LK-GE0531-IND-MOVIMENTO IS NOT NUMERIC */

            if (!LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_IND_MOVIMENTO.IsNumeric())
            {

                /*" -413- MOVE 27 TO LK-GE0531-COD-RETORNO */
                _.Move(27, LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_COD_RETORNO);

                /*" -415- MOVE 'GE0531S - Indicador do movimento - invalido.' TO LK-GE0531-MSG-RETORNO */
                _.Move("GE0531S - Indicador do movimento - invalido.", LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_MSG_RETORNO);

                /*" -416- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -418- END-IF */
            }


            /*" -419- IF LK-GE0531-IND-MOVIMENTO EQUAL ZEROS */

            if (LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_IND_MOVIMENTO == 00)
            {

                /*" -420- MOVE 28 TO LK-GE0531-COD-RETORNO */
                _.Move(28, LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_COD_RETORNO);

                /*" -422- MOVE 'GE0531S - Indicador do movimento - zerado.' TO LK-GE0531-MSG-RETORNO */
                _.Move("GE0531S - Indicador do movimento - zerado.", LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_MSG_RETORNO);

                /*" -423- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -424- END-IF */
            }


            /*" -424- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSAR-SECTION */
        private void R1000_00_PROCESSAR_SECTION()
        {
            /*" -436- MOVE 'R1000-00' TO WS-PARAGRAFO */
            _.Move("R1000-00", WS_PARAGRAFO);

            /*" -439- PERFORM R1050-00-BUSCAR-DTH-RESTR */

            R1050_00_BUSCAR_DTH_RESTR_SECTION();

            /*" -442- PERFORM R1100-00-BUSCAR-ULT-SEQ */

            R1100_00_BUSCAR_ULT_SEQ_SECTION();

            /*" -444- PERFORM R1200-00-INSERIR-DADOS-LOG */

            R1200_00_INSERIR_DADOS_LOG_SECTION();

            /*" -444- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1050-00-BUSCAR-DTH-RESTR-SECTION */
        private void R1050_00_BUSCAR_DTH_RESTR_SECTION()
        {
            /*" -456- MOVE 'R1050-00' TO WS-PARAGRAFO. */
            _.Move("R1050-00", WS_PARAGRAFO);

            /*" -457- MOVE ZEROS TO GE615-NUM-CPF-CNPJ */
            _.Move(0, GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_NUM_CPF_CNPJ);

            /*" -459- MOVE LK-GE0531-CPF-CNPJ TO GE615-NUM-CPF-CNPJ */
            _.Move(LBGE0531.LK_GE0531.LK_GE0531_CPF_CNPJ, GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_NUM_CPF_CNPJ);

            /*" -462- DISPLAY 'R1050-00-BUSCAR-DTH-RESTR  - INICIO.........' ' CPF:' GE615-NUM-CPF-CNPJ */

            $"R1050-00-BUSCAR-DTH-RESTR  - INICIO......... CPF:{GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_NUM_CPF_CNPJ}"
            .Display();

            /*" -479- PERFORM R1050_00_BUSCAR_DTH_RESTR_DB_SELECT_1 */

            R1050_00_BUSCAR_DTH_RESTR_DB_SELECT_1();

            /*" -482- EVALUATE SQLCODE */
            switch (DB.SQLCODE.Value)
            {

                /*" -483- WHEN +0 */
                case +0:

                    /*" -484- MOVE GE615-DTA-INCLUSAO TO GDA-DTA-INCL-PEP */
                    _.Move(GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_DTA_INCLUSAO, GDA_DTA_INCL_PEP);

                    /*" -485- WHEN +100 */
                    break;
                case +100:

                /*" -486- CONTINUE */

                /*" -487- WHEN OTHER */
                default:

                    /*" -488- MOVE 29 TO LK-GE0531-COD-RETORNO */
                    _.Move(29, LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_COD_RETORNO);

                    /*" -490- MOVE 'GE0531S - Erro select R1050-BUSCAR-DTH.' TO LK-GE0531-MSG-RETORNO */
                    _.Move("GE0531S - Erro select R1050-BUSCAR-DTH.", LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_MSG_RETORNO);

                    /*" -491- PERFORM R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION();

                    /*" -493- END-EVALUATE */
                    break;
            }


            /*" -493- . */

        }

        [StopWatch]
        /*" R1050-00-BUSCAR-DTH-RESTR-DB-SELECT-1 */
        public void R1050_00_BUSCAR_DTH_RESTR_DB_SELECT_1()
        {
            /*" -479- EXEC SQL SELECT NUM_CPF_CNPJ ,SEQ_REGISTRO ,NUM_CERTIFICADO_EXT ,DTA_INCLUSAO ,DTH_CADASTRAMENTO INTO :GE615-NUM-CPF-CNPJ ,:GE615-SEQ-REGISTRO ,:GE615-NUM-CERTIFICADO-EXT ,:GE615-DTA-INCLUSAO ,:GE615-DTH-CADASTRAMENTO FROM SIUS.GE_PESSOA_VALIDA_LOG WHERE NUM_CPF_CNPJ = :GE615-NUM-CPF-CNPJ AND STA_REGISTRO = 2 ORDER BY DTH_CADASTRAMENTO FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC */

            var r1050_00_BUSCAR_DTH_RESTR_DB_SELECT_1_Query1 = new R1050_00_BUSCAR_DTH_RESTR_DB_SELECT_1_Query1()
            {
                GE615_NUM_CPF_CNPJ = GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_NUM_CPF_CNPJ.ToString(),
            };

            var executed_1 = R1050_00_BUSCAR_DTH_RESTR_DB_SELECT_1_Query1.Execute(r1050_00_BUSCAR_DTH_RESTR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE615_NUM_CPF_CNPJ, GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_NUM_CPF_CNPJ);
                _.Move(executed_1.GE615_SEQ_REGISTRO, GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_SEQ_REGISTRO);
                _.Move(executed_1.GE615_NUM_CERTIFICADO_EXT, GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_NUM_CERTIFICADO_EXT);
                _.Move(executed_1.GE615_DTA_INCLUSAO, GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_DTA_INCLUSAO);
                _.Move(executed_1.GE615_DTH_CADASTRAMENTO, GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_DTH_CADASTRAMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1050_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-BUSCAR-ULT-SEQ-SECTION */
        private void R1100_00_BUSCAR_ULT_SEQ_SECTION()
        {
            /*" -507- MOVE 'R1100-00' TO WS-PARAGRAFO */
            _.Move("R1100-00", WS_PARAGRAFO);

            /*" -511- PERFORM R1100_00_BUSCAR_ULT_SEQ_DB_SELECT_1 */

            R1100_00_BUSCAR_ULT_SEQ_DB_SELECT_1();

            /*" -515- DISPLAY 'R1000-WS-SEQ-PESSOA-LOG : ' WS-SEQ-PESSOA-LOG */
            _.Display($"R1000-WS-SEQ-PESSOA-LOG : {WS_SEQ_PESSOA_LOG}");

            /*" -516- EVALUATE SQLCODE */
            switch (DB.SQLCODE.Value)
            {

                /*" -517- WHEN +0 */
                case +0:

                    /*" -518- WHEN +100 */
                    break;
                case +100:

                    /*" -519- ADD 1 TO WS-SEQ-PESSOA-LOG */
                    WS_SEQ_PESSOA_LOG.Value = WS_SEQ_PESSOA_LOG + 1;

                    /*" -520- DISPLAY 'GE0531S: ' SQLCODE */
                    _.Display($"GE0531S: {DB.SQLCODE}");

                    /*" -521- CONTINUE */

                    /*" -522- WHEN OTHER */
                    break;
                default:

                    /*" -523- MOVE 30 TO LK-GE0531-COD-RETORNO */
                    _.Move(30, LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_COD_RETORNO);

                    /*" -525- MOVE 'Erro select max SIUS.GE_PESSOA_VALIDA_LOG.' TO LK-GE0531-MSG-RETORNO */
                    _.Move("Erro select max SIUS.GE_PESSOA_VALIDA_LOG.", LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_MSG_RETORNO);

                    /*" -526- PERFORM R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION();

                    /*" -528- END-EVALUATE */
                    break;
            }


            /*" -528- . */

        }

        [StopWatch]
        /*" R1100-00-BUSCAR-ULT-SEQ-DB-SELECT-1 */
        public void R1100_00_BUSCAR_ULT_SEQ_DB_SELECT_1()
        {
            /*" -511- EXEC SQL SELECT MAX(SEQ_REGISTRO) INTO :WS-SEQ-PESSOA-LOG FROM SIUS.GE_PESSOA_VALIDA_LOG END-EXEC. */

            var r1100_00_BUSCAR_ULT_SEQ_DB_SELECT_1_Query1 = new R1100_00_BUSCAR_ULT_SEQ_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R1100_00_BUSCAR_ULT_SEQ_DB_SELECT_1_Query1.Execute(r1100_00_BUSCAR_ULT_SEQ_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_SEQ_PESSOA_LOG, WS_SEQ_PESSOA_LOG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-INSERIR-DADOS-LOG-SECTION */
        private void R1200_00_INSERIR_DADOS_LOG_SECTION()
        {
            /*" -538- MOVE 'R1200-00' TO WS-PARAGRAFO */
            _.Move("R1200-00", WS_PARAGRAFO);

            /*" -540- INITIALIZE DCLGE-PESSOA-VALIDA-LOG */
            _.Initialize(
                GE615.DCLGE_PESSOA_VALIDA_LOG
            );

            /*" -541- MOVE LK-GE0531-CPF-CNPJ TO GE615-NUM-CPF-CNPJ */
            _.Move(LBGE0531.LK_GE0531.LK_GE0531_CPF_CNPJ, GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_NUM_CPF_CNPJ);

            /*" -543- MOVE WS-SEQ-PESSOA-LOG TO GE615-SEQ-REGISTRO LK-GE0531-SEQ-REGISTRO */
            _.Move(WS_SEQ_PESSOA_LOG, GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_SEQ_REGISTRO, LBGE0531.LK_GE0531.LK_GE0531_SEQ_REGISTRO);

            /*" -544- MOVE LK-GE0531-NUM-RAMO-EMISSOR TO GE615-NUM-RAMO-EMISSOR */
            _.Move(LBGE0531.LK_GE0531.LK_GE0531_NUM_RAMO_EMISSOR, GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_NUM_RAMO_EMISSOR);

            /*" -545- MOVE LK-GE0531-COD-PRODUTO TO GE615-COD-PRODUTO */
            _.Move(LBGE0531.LK_GE0531.LK_GE0531_COD_PRODUTO, GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_COD_PRODUTO);

            /*" -546- MOVE LK-GE0531-COD-FONTE TO GE615-COD-FONTE */
            _.Move(LBGE0531.LK_GE0531.LK_GE0531_COD_FONTE, GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_COD_FONTE);

            /*" -548- MOVE LK-GE0531-NUM-PROPOSTA TO GE615-NUM-PROPOSTA */
            _.Move(LBGE0531.LK_GE0531.LK_GE0531_NUM_PROPOSTA, GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_NUM_PROPOSTA);

            /*" -551- MOVE LK-GE0531-NUM-CERTIFIC-EXT TO GE615-NUM-CERTIFICADO-EXT */
            _.Move(LBGE0531.LK_GE0531.LK_GE0531_NUM_CERTIFIC_EXT, GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_NUM_CERTIFICADO_EXT);

            /*" -552- MOVE LK-GE0531-NUM-APOLICE TO GE615-NUM-APOLICE */
            _.Move(LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_NUM_APOLICE, GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_NUM_APOLICE);

            /*" -553- MOVE LK-GE0531-NUM-ENDOSSO TO GE615-NUM-ENDOSSO */
            _.Move(LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_NUM_ENDOSSO, GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_NUM_ENDOSSO);

            /*" -554- MOVE LK-GE0531-NUM-SINISTRO TO GE615-NUM-SINISTRO */
            _.Move(LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_NUM_SINISTRO, GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_NUM_SINISTRO);

            /*" -555- MOVE LK-GE0531-OCORR-HISTORICO TO GE615-OCORR-HISTORICO */
            _.Move(LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_OCORR_HISTORICO, GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_OCORR_HISTORICO);

            /*" -556- MOVE LK-GE0531-COD-OPER-SINISTRO TO GE615-COD-OPER-SINISTRO */
            _.Move(LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_COD_OPER_SINISTRO, GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_COD_OPER_SINISTRO);

            /*" -557- MOVE LK-GE0531-NOM-SEGURADO TO GE615-NOM-SEGURADO */
            _.Move(LBGE0531.LK_GE0531.LK_GE0531_NOM_SEGURADO, GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_NOM_SEGURADO);

            /*" -558- MOVE LK-GE0531-COD-CARGO TO GE615-COD-CARGO */
            _.Move(LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_COD_CARGO, GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_COD_CARGO);

            /*" -559- MOVE LK-GE0531-DES-CARGO TO GE615-DES-CARGO */
            _.Move(LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_DES_CARGO, GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_DES_CARGO);

            /*" -561- MOVE LK-GE0531-NOM-ORGAO TO GE615-NOM-ORGAO */
            _.Move(LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_NOM_ORGAO, GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_NOM_ORGAO);

            /*" -564- MOVE LK-GE0531-COD-RELACAO-EXT TO GE615-COD-RELACAO-EXTERNO */
            _.Move(LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_COD_RELACAO_EXT, GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_COD_RELACAO_EXTERNO);

            /*" -567- MOVE LK-GE0531-COD-RELACAO-INT TO GE615-IND-TP-RELAC-INTERNO */
            _.Move(LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_COD_RELACAO_INT, GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_IND_TP_RELAC_INTERNO);

            /*" -568- MOVE LK-GE0531-IND-TIPO-PESSOA TO GE615-IND-TIPO-PESSOA */
            _.Move(LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_IND_TIPO_PESSOA, GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_IND_TIPO_PESSOA);

            /*" -569- MOVE LK-GE0531-IND-MOVIMENTO TO GE615-IND-MOVIMENTO */
            _.Move(LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_IND_MOVIMENTO, GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_IND_MOVIMENTO);

            /*" -571- MOVE LK-GE0531-IND-EVENTO TO GE615-IND-EVENTO */
            _.Move(LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_IND_EVENTO, GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_IND_EVENTO);

            /*" -572- IF GDA-DTA-INCL-PEP NOT EQUAL SPACES */

            if (!GDA_DTA_INCL_PEP.IsEmpty())
            {

                /*" -573- MOVE GDA-DTA-INCL-PEP TO GE615-DTA-INCLUSAO */
                _.Move(GDA_DTA_INCL_PEP, GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_DTA_INCLUSAO);

                /*" -574- ELSE */
            }
            else
            {


                /*" -575- IF LK-GE0531-DTA-INCLUSAO NOT EQUAL SPACES */

                if (!LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_DTA_INCLUSAO.IsEmpty())
                {

                    /*" -576- MOVE LK-GE0531-DTA-INCLUSAO TO GE615-DTA-INCLUSAO */
                    _.Move(LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_DTA_INCLUSAO, GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_DTA_INCLUSAO);

                    /*" -577- ELSE */
                }
                else
                {


                    /*" -578- MOVE '9999-12-31' TO GE615-DTA-INCLUSAO */
                    _.Move("9999-12-31", GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_DTA_INCLUSAO);

                    /*" -579- END-IF */
                }


                /*" -581- END-IF */
            }


            /*" -582- MOVE LK-GE0531-STA-REGISTRO TO GE615-STA-REGISTRO */
            _.Move(LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_STA_REGISTRO, GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_STA_REGISTRO);

            /*" -583- MOVE LK-GE0531-COD-ORIGEM TO GE615-COD-ORIGEM */
            _.Move(LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_COD_ORIGEM, GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_COD_ORIGEM);

            /*" -584- MOVE LK-GE0531-COD-USUARIO TO GE615-COD-USUARIO */
            _.Move(LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_COD_USUARIO, GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_COD_USUARIO);

            /*" -586- MOVE LK-GE0531-NOM-PROGRAMA TO GE615-NOM-PROGRAMA */
            _.Move(LBGE0531.LK_GE0531.LK_GE0531_DADOS_LOG.LK_GE0531_NOM_PROGRAMA, GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_NOM_PROGRAMA);

            /*" -648- PERFORM R1200_00_INSERIR_DADOS_LOG_DB_INSERT_1 */

            R1200_00_INSERIR_DADOS_LOG_DB_INSERT_1();

            /*" -651- EVALUATE SQLCODE */
            switch (DB.SQLCODE.Value)
            {

                /*" -652- WHEN +0 */
                case +0:

                    /*" -653- CONTINUE */

                    /*" -654- WHEN OTHER */
                    break;
                default:

                    /*" -655- MOVE 31 TO LK-GE0531-COD-RETORNO */
                    _.Move(31, LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_COD_RETORNO);

                    /*" -657- MOVE 'GE031S-Erro Insert SIUS.GE_PESSOA_VALIDA_LOG' TO LK-GE0531-MSG-RETORNO */
                    _.Move("GE031S-Erro Insert SIUS.GE_PESSOA_VALIDA_LOG", LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_MSG_RETORNO);

                    /*" -658- PERFORM R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION();

                    /*" -660- END-EVALUATE */
                    break;
            }


            /*" -662- DISPLAY 'GE0531S-R1200-00 - GRAVEI LOG COM SUCESSO.....' */
            _.Display($"GE0531S-R1200-00 - GRAVEI LOG COM SUCESSO.....");

            /*" -662- . */

        }

        [StopWatch]
        /*" R1200-00-INSERIR-DADOS-LOG-DB-INSERT-1 */
        public void R1200_00_INSERIR_DADOS_LOG_DB_INSERT_1()
        {
            /*" -648- EXEC SQL INSERT INTO SIUS.GE_PESSOA_VALIDA_LOG (NUM_CPF_CNPJ ,SEQ_REGISTRO ,NUM_RAMO_EMISSOR ,COD_PRODUTO ,COD_FONTE ,NUM_PROPOSTA ,NUM_CERTIFICADO_EXT ,NUM_APOLICE ,NUM_ENDOSSO ,NUM_SINISTRO ,OCORR_HISTORICO ,COD_OPER_SINISTRO ,NOM_SEGURADO ,COD_CARGO ,DES_CARGO ,NOM_ORGAO ,COD_RELACAO_EXTERNO ,IND_TP_RELAC_INTERNO ,IND_TIPO_PESSOA ,IND_MOVIMENTO ,IND_EVENTO ,DTA_INCLUSAO ,STA_REGISTRO ,COD_ORIGEM ,COD_USUARIO ,NOM_PROGRAMA ,DTH_CADASTRAMENTO ) VALUES (:GE615-NUM-CPF-CNPJ ,:GE615-SEQ-REGISTRO ,:GE615-NUM-RAMO-EMISSOR :GE615-NUM-RAMO-EMISSOR-NULO ,:GE615-COD-PRODUTO :GE615-COD-PRODUTO-NULO ,:GE615-COD-FONTE :GE615-COD-FONTE-NULO ,:GE615-NUM-PROPOSTA :GE615-NUM-PROPOSTA-NULO ,:GE615-NUM-CERTIFICADO-EXT ,:GE615-NUM-APOLICE ,:GE615-NUM-ENDOSSO ,:GE615-NUM-SINISTRO ,:GE615-OCORR-HISTORICO ,:GE615-COD-OPER-SINISTRO ,:GE615-NOM-SEGURADO :GE615-NOM-SEGURADO-NULO ,:GE615-COD-CARGO ,:GE615-DES-CARGO ,:GE615-NOM-ORGAO ,:GE615-COD-RELACAO-EXTERNO ,:GE615-IND-TP-RELAC-INTERNO :GE615-IND-TP-RELAC-INT-NULO ,:GE615-IND-TIPO-PESSOA :GE615-IND-TIPO-PESSOA-NULO ,:GE615-IND-MOVIMENTO :GE615-IND-MOVIMENTO-NULO ,:GE615-IND-EVENTO :GE615-IND-EVENTO-NULO ,:GE615-DTA-INCLUSAO ,:GE615-STA-REGISTRO :GE615-STA-REGISTRO-NULO ,:GE615-COD-ORIGEM :GE615-COD-ORIGEM-NULO ,:GE615-COD-USUARIO ,:GE615-NOM-PROGRAMA :GE615-NOM-PROGRAMA-NULO , CURRENT TIMESTAMP ) END-EXEC */

            var r1200_00_INSERIR_DADOS_LOG_DB_INSERT_1_Insert1 = new R1200_00_INSERIR_DADOS_LOG_DB_INSERT_1_Insert1()
            {
                GE615_NUM_CPF_CNPJ = GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_NUM_CPF_CNPJ.ToString(),
                GE615_SEQ_REGISTRO = GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_SEQ_REGISTRO.ToString(),
                GE615_NUM_RAMO_EMISSOR = GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_NUM_RAMO_EMISSOR.ToString(),
                GE615_NUM_RAMO_EMISSOR_NULO = GE615_NUM_RAMO_EMISSOR_NULO.ToString(),
                GE615_COD_PRODUTO = GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_COD_PRODUTO.ToString(),
                GE615_COD_PRODUTO_NULO = GE615_COD_PRODUTO_NULO.ToString(),
                GE615_COD_FONTE = GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_COD_FONTE.ToString(),
                GE615_COD_FONTE_NULO = GE615_COD_FONTE_NULO.ToString(),
                GE615_NUM_PROPOSTA = GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_NUM_PROPOSTA.ToString(),
                GE615_NUM_PROPOSTA_NULO = GE615_NUM_PROPOSTA_NULO.ToString(),
                GE615_NUM_CERTIFICADO_EXT = GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_NUM_CERTIFICADO_EXT.ToString(),
                GE615_NUM_APOLICE = GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_NUM_APOLICE.ToString(),
                GE615_NUM_ENDOSSO = GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_NUM_ENDOSSO.ToString(),
                GE615_NUM_SINISTRO = GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_NUM_SINISTRO.ToString(),
                GE615_OCORR_HISTORICO = GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_OCORR_HISTORICO.ToString(),
                GE615_COD_OPER_SINISTRO = GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_COD_OPER_SINISTRO.ToString(),
                GE615_NOM_SEGURADO = GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_NOM_SEGURADO.ToString(),
                GE615_NOM_SEGURADO_NULO = GE615_NOM_SEGURADO_NULO.ToString(),
                GE615_COD_CARGO = GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_COD_CARGO.ToString(),
                GE615_DES_CARGO = GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_DES_CARGO.ToString(),
                GE615_NOM_ORGAO = GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_NOM_ORGAO.ToString(),
                GE615_COD_RELACAO_EXTERNO = GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_COD_RELACAO_EXTERNO.ToString(),
                GE615_IND_TP_RELAC_INTERNO = GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_IND_TP_RELAC_INTERNO.ToString(),
                GE615_IND_TP_RELAC_INT_NULO = GE615_IND_TP_RELAC_INT_NULO.ToString(),
                GE615_IND_TIPO_PESSOA = GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_IND_TIPO_PESSOA.ToString(),
                GE615_IND_TIPO_PESSOA_NULO = GE615_IND_TIPO_PESSOA_NULO.ToString(),
                GE615_IND_MOVIMENTO = GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_IND_MOVIMENTO.ToString(),
                GE615_IND_MOVIMENTO_NULO = GE615_IND_MOVIMENTO_NULO.ToString(),
                GE615_IND_EVENTO = GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_IND_EVENTO.ToString(),
                GE615_IND_EVENTO_NULO = GE615_IND_EVENTO_NULO.ToString(),
                GE615_DTA_INCLUSAO = GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_DTA_INCLUSAO.ToString(),
                GE615_STA_REGISTRO = GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_STA_REGISTRO.ToString(),
                GE615_STA_REGISTRO_NULO = GE615_STA_REGISTRO_NULO.ToString(),
                GE615_COD_ORIGEM = GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_COD_ORIGEM.ToString(),
                GE615_COD_ORIGEM_NULO = GE615_COD_ORIGEM_NULO.ToString(),
                GE615_COD_USUARIO = GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_COD_USUARIO.ToString(),
                GE615_NOM_PROGRAMA = GE615.DCLGE_PESSOA_VALIDA_LOG.GE615_NOM_PROGRAMA.ToString(),
                GE615_NOM_PROGRAMA_NULO = GE615_NOM_PROGRAMA_NULO.ToString(),
            };

            R1200_00_INSERIR_DADOS_LOG_DB_INSERT_1_Insert1.Execute(r1200_00_INSERIR_DADOS_LOG_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-FINALIZAR-SECTION */
        private void R2000_00_FINALIZAR_SECTION()
        {
            /*" -672- MOVE 'R2000-00' TO WS-PARAGRAFO */
            _.Move("R2000-00", WS_PARAGRAFO);

            /*" -673- MOVE ZEROS TO LK-GE0531-COD-RETORNO */
            _.Move(0, LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_COD_RETORNO);

            /*" -675- MOVE SPACES TO LK-GE0531-MSG-RETORNO */
            _.Move("", LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_MSG_RETORNO);

            /*" -676- DISPLAY '*-*-*-*-*-*-*-*-*-*-*--*-*-*-*-*-*-*-*-*-*-*' */
            _.Display($"*-*-*-*-*-*-*-*-*-*-*--*-*-*-*-*-*-*-*-*-*-*");

            /*" -677- DISPLAY '* *          GE0531S - FIM NORMAL        * *' */
            _.Display($"* *          GE0531S - FIM NORMAL        * *");

            /*" -678- DISPLAY '*-*-*-*-*-*-*-*-*-*-*--*-*-*-*-*-*-*-*-*-*-*' */
            _.Display($"*-*-*-*-*-*-*-*-*-*-*--*-*-*-*-*-*-*-*-*-*-*");

            /*" -679- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -680- DISPLAY '* QTDE DE REGISTROS  INSERIDOS             *' */
            _.Display($"* QTDE DE REGISTROS  INSERIDOS             *");

            /*" -681- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -682- DISPLAY 'CPF-CNPJ          :' LK-GE0531-CPF-CNPJ */
            _.Display($"CPF-CNPJ          :{LBGE0531.LK_GE0531.LK_GE0531_CPF_CNPJ}");

            /*" -683- DISPLAY 'SEQ-REGISTRO      :' LK-GE0531-SEQ-REGISTRO */
            _.Display($"SEQ-REGISTRO      :{LBGE0531.LK_GE0531.LK_GE0531_SEQ_REGISTRO}");

            /*" -708- DISPLAY 'NOM-SEGURADO      :' LK-GE0531-NOM-SEGURADO */
            _.Display($"NOM-SEGURADO      :{LBGE0531.LK_GE0531.LK_GE0531_NOM_SEGURADO}");

            /*" -709- DISPLAY 'COD-RETORNO       :' LK-GE0531-COD-RETORNO */
            _.Display($"COD-RETORNO       :{LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_COD_RETORNO}");

            /*" -710- DISPLAY 'MSG-RETORNO       :' LK-GE0531-MSG-RETORNO */
            _.Display($"MSG-RETORNO       :{LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_MSG_RETORNO}");

            /*" -715- DISPLAY '*-*-*-*-*-*-*-*-*-*-*--*-*-*-*-*-*-*-*-*-*-*' */
            _.Display($"*-*-*-*-*-*-*-*-*-*-*--*-*-*-*-*-*-*-*-*-*-*");

            /*" -715- GOBACK. */

            throw new GoBack();

        }

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -727- MOVE SQLCODE TO WS-SQLCODE */
            _.Move(DB.SQLCODE, WS_SQLCODE);

            /*" -728- DISPLAY ' ' */
            _.Display($" ");

            /*" -729- DISPLAY '*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*' */
            _.Display($"*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*");

            /*" -730- DISPLAY '*  TERMINO ANORMAL DO PROGRAMA GE0531S  *' */
            _.Display($"*  TERMINO ANORMAL DO PROGRAMA GE0531S  *");

            /*" -731- DISPLAY '*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*' */
            _.Display($"*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*");

            /*" -732- DISPLAY ' ' . */
            _.Display($" ");

            /*" -733- DISPLAY 'PARAGRAFO       = ' WS-PARAGRAFO */
            _.Display($"PARAGRAFO       = {WS_PARAGRAFO}");

            /*" -734- DISPLAY 'SQLCODE         = ' WS-SQLCODE */
            _.Display($"SQLCODE         = {WS_SQLCODE}");

            /*" -735- DISPLAY 'SQLCA           = ' SQLCA */
            _.Display($"SQLCA           = {DB.SQLCA}");

            /*" -736- DISPLAY 'COD-RET         = ' LK-GE0531-COD-RETORNO */
            _.Display($"COD-RET         = {LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_COD_RETORNO}");

            /*" -737- DISPLAY 'MSG-RET         = ' LK-GE0531-MSG-RETORNO */
            _.Display($"MSG-RET         = {LBGE0531.LK_GE0531.LK_GE0531_GERAL.LK_GE0531_MSG_RETORNO}");

            /*" -738- DISPLAY 'R1050-LOT       = ' LK-GE0531-NUM-CERTIFIC-EXT */
            _.Display($"R1050-LOT       = {LBGE0531.LK_GE0531.LK_GE0531_NUM_CERTIFIC_EXT}");

            /*" -739- DISPLAY 'CPF             = ' LK-GE0531-CPF-CNPJ */
            _.Display($"CPF             = {LBGE0531.LK_GE0531.LK_GE0531_CPF_CNPJ}");

            /*" -740- DISPLAY 'NOME SEGURADO   = ' LK-GE0531-NOM-SEGURADO */
            _.Display($"NOME SEGURADO   = {LBGE0531.LK_GE0531.LK_GE0531_NOM_SEGURADO}");

            /*" -741- DISPLAY WABEND1. */
            _.Display(WABEND.WABEND1);

            /*" -742- DISPLAY WABEND2. */
            _.Display(WABEND.WABEND2);

            /*" -746- DISPLAY WABEND3. */
            _.Display(WABEND.WABEND3);

            /*" -746- GOBACK. */

            throw new GoBack();

        }
    }
}