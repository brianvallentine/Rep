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
using Sias.Outros.DB2.FC0105S;

namespace Code
{
    public class FC0105S
    {
        public bool IsCall { get; set; }

        public FC0105S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      * FUNCAO : GERA TITULOS ACOPLADOS PARA EMPRESAS PARCEIRAS        *      */
        /*"      * FLUXOS : 01 - EMISSAO/RESERVA                                  *      */
        /*"      *          02 - ATIVACAO DE EMISSAO                              *      */
        /*"      *          03 - RENOVACAO                                        *      */
        /*"      *          04 - RESGATE                                          *      */
        /*"      *          05 - ATIVACAO AUTOMATICA                              *      */
        /*"      *          06 - EMISSAO/BOLETO                                   *      */
        /*"      *          07 - DISPONIVEL                                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *VERSAO: 035 - 26/03/20 - CA176258 CODIGO REVISADO E ALTERADO    *      */
        /*"      *      : 034 - 22/11/19 - CA176258 INICIO DA REVISAO DO CODIGO   *      */
        /*"      *      : 033 - 03/10/19 - CA177662 CORRECAO DE ABEND             *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  W77-MENSAGEM            PIC X(120) VALUE SPACES.*/
        public StringBasis W77_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "120", "X(120)"), @"");
        /*"77  W77-DATA-CORRENTE       PIC X(010) VALUE SPACES.*/
        public StringBasis W77_DATA_CORRENTE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77  W77-COD-RAMO            PIC 9(006) VALUE ZEROS.*/
        public IntBasis W77_COD_RAMO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"77  W77-RETURN              PIC 9(002) VALUE ZEROS.*/
        public IntBasis W77_RETURN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"77  W77-NUM-PLANO           PIC 9(004) VALUE ZEROS.*/
        public IntBasis W77_NUM_PLANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"77  W77-NUM-SERIE           PIC 9(005) VALUE ZEROS.*/
        public IntBasis W77_NUM_SERIE { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
        /*"77  W77-NUM-TITULO          PIC 9(009) VALUE ZEROS.*/
        public IntBasis W77_NUM_TITULO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"77  W77-EMP-PARCEIRA        PIC 9(009) VALUE ZEROS.*/
        public IntBasis W77_EMP_PARCEIRA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"77  W77-IDE-CLIENTE         PIC 9(009) VALUE ZEROS.*/
        public IntBasis W77_IDE_CLIENTE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"77  W77-NUM-NSA             PIC X(010) VALUE SPACES.*/
        public StringBasis W77_NUM_NSA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77  W77-VLR-TITULO          PIC ZZZZZ9.99.*/
        public IntBasis W77_VLR_TITULO { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZZ9.99."));
        /*"77  W77-VLR-MENSALIDADE     PIC ZZZZZ9.99.*/
        public IntBasis W77_VLR_MENSALIDADE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZZ9.99."));
        /*"77  W77-VLR-PROPOSTA        PIC ZZZZZ9.99.*/
        public IntBasis W77_VLR_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZZ9.99."));
        /*"77  W77-QTD-TITULO          PIC 9(009) VALUE ZEROS.*/
        public IntBasis W77_QTD_TITULO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"77  W77-NUM-PROPOSTA        PIC 9(015) VALUE ZEROS.*/
        public IntBasis W77_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
        /*"77  W77-SEQ-SOLICITACAO     PIC 9(010) VALUE ZEROS.*/
        public IntBasis W77_SEQ_SOLICITACAO { get; set; } = new IntBasis(new PIC("9", "10", "9(010)"));
        /*"77  W77-SQLCODE             PIC -999.*/
        public IntBasis W77_SQLCODE { get; set; } = new IntBasis(new PIC("9", "3", "-999."));
        /*"77  W77-SQLSTATE            PIC -99999.*/
        public IntBasis W77_SQLSTATE { get; set; } = new IntBasis(new PIC("9", "5", "-99999."));
        /*"77  W77-SQLERRMC            PIC X(070) VALUE SPACES.*/
        public StringBasis W77_SQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
        /*"77  W77-NULL1               PIC S9(004) COMP.*/
        public IntBasis W77_NULL1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  W77-NULL2               PIC S9(004) COMP.*/
        public IntBasis W77_NULL2 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  W77-IND-ERRO            PIC  9(004) VALUE ZEROS.*/
        public IntBasis W77_IND_ERRO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"01 LK-COD-USUARIO-N061           PIC X(008).*/
        public StringBasis LK_COD_USUARIO_N061 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"01 LK-COD-PROG-ORIGEM-N061       PIC X(010).*/
        public StringBasis LK_COD_PROG_ORIGEM_N061 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01 LK-SIGLA-UNID-NEG-N061        PIC X(020).*/
        public StringBasis LK_SIGLA_UNID_NEG_N061 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"01 LK-COD-MSG-LANG-N061          PIC X(010).*/
        public StringBasis LK_COD_MSG_LANG_N061 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01 LK-IND-TIPO-PROC-N061         PIC X(001).*/
        public StringBasis LK_IND_TIPO_PROC_N061 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01 LK-NUM-ORDEM-N061             PIC S9(09) COMP.*/
        public IntBasis LK_NUM_ORDEM_N061 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01 LK-COD-EMPRESA-N061           PIC S9(09) COMP.*/
        public IntBasis LK_COD_EMPRESA_N061 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01 LK-IND-ERRO-N061              PIC S9(04) COMP.*/
        public IntBasis LK_IND_ERRO_N061 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01 LK-MSG-RET-N061               PIC X(200).*/
        public StringBasis LK_MSG_RET_N061 { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");
        /*"01 LK-NM-TAB-N061                PIC X(030).*/
        public StringBasis LK_NM_TAB_N061 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
        /*"01 LK-SQLCODE-N061               PIC S9(09) COMP.*/
        public IntBasis LK_SQLCODE_N061 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01 LK-SQLERRMC-N061              PIC X(070).*/
        public StringBasis LK_SQLERRMC_N061 { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
        /*" 01 LK-NUM-PLANO         PIC S9(4)       USAGE COMP.*/
        public IntBasis LK_NUM_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*" 01 LK-NUM-SERIE         PIC S9(4)       USAGE COMP.*/
        public IntBasis LK_NUM_SERIE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*" 01 LK-NUM-TITULO        PIC S9(9)       USAGE COMP.*/
        public IntBasis LK_NUM_TITULO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*" 01 LK-NUM-PROPOSTA      PIC S9(15)V     USAGE COMP-3.*/
        public DoubleBasis LK_NUM_PROPOSTA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*" 01 LK-QTD-TITULOS       PIC S9(4)       USAGE COMP.*/
        public IntBasis LK_QTD_TITULOS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*" 01 LK-VLR-TITULO        PIC S9(08)V9(2) USAGE COMP-3.*/
        public DoubleBasis LK_VLR_TITULO { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V9(2)"), 2);
        /*" 01 LK-EMP-PARCEIRA      PIC S9(4)       USAGE COMP.*/
        public IntBasis LK_EMP_PARCEIRA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*" 01 LK-COD-RAMO          PIC S9(4)       USAGE COMP.*/
        public IntBasis LK_COD_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*" 01 LK-NUM-NSA           PIC S9(9)       USAGE COMP.*/
        public IntBasis LK_NUM_NSA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*" 01 LK-TRACE             PIC X(009).*/

        public SelectorBasis LK_TRACE { get; set; } = new SelectorBasis("009")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 LK-TRACE-ON          VALUE 'TRACE ON ' 'TRACEON  '. */
							new SelectorItemBasis("LK_TRACE_ON", "TRACE ON "),
							/*" 88 LK-TRACE-OFF         VALUE 'TRACE OFF' 'TRACEOFF '. */
							new SelectorItemBasis("LK_TRACE_OFF", "TRACE OFF")
                }
        };

        /*" 01 LK-OUT-COD-RETORNO     PIC S9(004) COMP.*/
        public IntBasis LK_OUT_COD_RETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*" 01 LK-OUT-SQLCODE         PIC S9(004) COMP.*/
        public IntBasis LK_OUT_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*" 01 LK-OUT-MENSAGEM        PIC X(070).*/
        public StringBasis LK_OUT_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
        /*" 01 LK-OUT-SQLERRMC        PIC X(070).*/
        public StringBasis LK_OUT_SQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
        /*" 01 LK-OUT-SQLSTATE        PIC X(005).*/
        public StringBasis LK_OUT_SQLSTATE { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(IntBasis LK_NUM_PLANO_P, IntBasis LK_NUM_SERIE_P, IntBasis LK_NUM_TITULO_P, DoubleBasis LK_NUM_PROPOSTA_P, IntBasis LK_QTD_TITULOS_P, DoubleBasis LK_VLR_TITULO_P, IntBasis LK_EMP_PARCEIRA_P, IntBasis LK_COD_RAMO_P, IntBasis LK_NUM_NSA_P, StringBasis LK_TRACE_P, IntBasis LK_OUT_COD_RETORNO_P, IntBasis LK_OUT_SQLCODE_P, StringBasis LK_OUT_MENSAGEM_P, StringBasis LK_OUT_SQLERRMC_P, StringBasis LK_OUT_SQLSTATE_P) //PROCEDURE DIVISION USING 
        /*LK_NUM_PLANO
        LK_NUM_SERIE
        LK_NUM_TITULO
        LK_NUM_PROPOSTA
        LK_QTD_TITULOS
        LK_VLR_TITULO
        LK_EMP_PARCEIRA
        LK_COD_RAMO
        LK_NUM_NSA
        LK_TRACE
        LK_OUT_COD_RETORNO
        LK_OUT_SQLCODE
        LK_OUT_MENSAGEM
        LK_OUT_SQLERRMC
        LK_OUT_SQLSTATE*/
        {
            try
            {
                this.LK_NUM_PLANO.Value = LK_NUM_PLANO_P.Value;
                this.LK_NUM_SERIE.Value = LK_NUM_SERIE_P.Value;
                this.LK_NUM_TITULO.Value = LK_NUM_TITULO_P.Value;
                this.LK_NUM_PROPOSTA.Value = LK_NUM_PROPOSTA_P.Value;
                this.LK_QTD_TITULOS.Value = LK_QTD_TITULOS_P.Value;
                this.LK_VLR_TITULO.Value = LK_VLR_TITULO_P.Value;
                this.LK_EMP_PARCEIRA.Value = LK_EMP_PARCEIRA_P.Value;
                this.LK_COD_RAMO.Value = LK_COD_RAMO_P.Value;
                this.LK_NUM_NSA.Value = LK_NUM_NSA_P.Value;
                this.LK_TRACE.Value = LK_TRACE_P.Value;
                this.LK_OUT_COD_RETORNO.Value = LK_OUT_COD_RETORNO_P.Value;
                this.LK_OUT_SQLCODE.Value = LK_OUT_SQLCODE_P.Value;
                this.LK_OUT_MENSAGEM.Value = LK_OUT_MENSAGEM_P.Value;
                this.LK_OUT_SQLERRMC.Value = LK_OUT_SQLERRMC_P.Value;
                this.LK_OUT_SQLSTATE.Value = LK_OUT_SQLSTATE_P.Value;

                /*" -0- FLUXCONTROL_PERFORM P000-PRINCIPAL-SECTION */

                P000_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LK_NUM_PLANO, LK_NUM_SERIE, LK_NUM_TITULO, LK_NUM_PROPOSTA, LK_QTD_TITULOS, LK_VLR_TITULO, LK_EMP_PARCEIRA, LK_COD_RAMO, LK_NUM_NSA, LK_TRACE, LK_OUT_COD_RETORNO, LK_OUT_SQLCODE, LK_OUT_MENSAGEM, LK_OUT_SQLERRMC, LK_OUT_SQLSTATE, CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" P000-PRINCIPAL-SECTION */
        private void P000_PRINCIPAL_SECTION()
        {
            /*" -112- MOVE LK-NUM-PLANO TO W77-NUM-PLANO */
            _.Move(LK_NUM_PLANO, W77_NUM_PLANO);

            /*" -113- MOVE LK-NUM-SERIE TO W77-NUM-SERIE */
            _.Move(LK_NUM_SERIE, W77_NUM_SERIE);

            /*" -114- MOVE LK-NUM-TITULO TO W77-NUM-TITULO */
            _.Move(LK_NUM_TITULO, W77_NUM_TITULO);

            /*" -115- MOVE LK-NUM-PROPOSTA TO W77-NUM-PROPOSTA */
            _.Move(LK_NUM_PROPOSTA, W77_NUM_PROPOSTA);

            /*" -116- MOVE LK-QTD-TITULOS TO W77-QTD-TITULO */
            _.Move(LK_QTD_TITULOS, W77_QTD_TITULO);

            /*" -117- MOVE LK-VLR-TITULO TO W77-VLR-TITULO */
            _.Move(LK_VLR_TITULO, W77_VLR_TITULO);

            /*" -118- MOVE LK-EMP-PARCEIRA TO W77-EMP-PARCEIRA */
            _.Move(LK_EMP_PARCEIRA, W77_EMP_PARCEIRA);

            /*" -119- MOVE LK-COD-RAMO TO W77-COD-RAMO */
            _.Move(LK_COD_RAMO, W77_COD_RAMO);

            /*" -120- MOVE ZEROS TO LK-NUM-NSA */
            _.Move(0, LK_NUM_NSA);

            /*" -122- MOVE '0001-01-01' TO W77-NUM-NSA */
            _.Move("0001-01-01", W77_NUM_NSA);

            /*" -123- IF LK-TRACE-ON */

            if (LK_TRACE["LK_TRACE_ON"])
            {

                /*" -124- DISPLAY '************************************************' */
                _.Display($"************************************************");

                /*" -125- DISPLAY '*                 FC0105S                      *' */
                _.Display($"*                 FC0105S                      *");

                /*" -126- DISPLAY '* GERA E RENOVA PROPOSTAS DE TITULOS ACOPLADOS *' */
                _.Display($"* GERA E RENOVA PROPOSTAS DE TITULOS ACOPLADOS *");

                /*" -127- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -134- DISPLAY '* VERSAO: 35 - ' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) ' AS ' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) '          *' */

                $"* VERSAO: 35 - FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)} AS FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}          *"
                .Display();

                /*" -135- DISPLAY '************************************************' */
                _.Display($"************************************************");

                /*" -136- DISPLAY ' ' */
                _.Display($" ");

                /*" -143- DISPLAY '--> INICIOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

                $"--> INICIOU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
                .Display();

                /*" -144- DISPLAY ' ' */
                _.Display($" ");

                /*" -145- DISPLAY '--------------------------------------------' */
                _.Display($"--------------------------------------------");

                /*" -146- DISPLAY '          PARAMETROS INFORMADOS' */
                _.Display($"          PARAMETROS INFORMADOS");

                /*" -148- DISPLAY '--------------------------------------------' */
                _.Display($"--------------------------------------------");

                /*" -149- DISPLAY 'NRO. DO PLANO         <' W77-NUM-PLANO '>' */

                $"NRO. DO PLANO         <{W77_NUM_PLANO}>"
                .Display();

                /*" -150- DISPLAY 'NRO. DA SERIE         <' W77-NUM-SERIE '>' */

                $"NRO. DA SERIE         <{W77_NUM_SERIE}>"
                .Display();

                /*" -151- DISPLAY 'NRO. DO TITULO        <' W77-NUM-TITULO '>' */

                $"NRO. DO TITULO        <{W77_NUM_TITULO}>"
                .Display();

                /*" -152- DISPLAY 'NRO. DA PROPOSTA      <' W77-NUM-PROPOSTA '>' */

                $"NRO. DA PROPOSTA      <{W77_NUM_PROPOSTA}>"
                .Display();

                /*" -153- DISPLAY 'QUANTIDADE DE TITULOS <' W77-QTD-TITULO '>' */

                $"QUANTIDADE DE TITULOS <{W77_QTD_TITULO}>"
                .Display();

                /*" -154- DISPLAY 'VALOR DO TITULO       <' W77-VLR-TITULO '>' */

                $"VALOR DO TITULO       <{W77_VLR_TITULO}>"
                .Display();

                /*" -155- DISPLAY 'EMPRESA PARCEIRA      <' W77-EMP-PARCEIRA '>' */

                $"EMPRESA PARCEIRA      <{W77_EMP_PARCEIRA}>"
                .Display();

                /*" -156- DISPLAY 'CODIGO RAMO           <' W77-COD-RAMO '>' */

                $"CODIGO RAMO           <{W77_COD_RAMO}>"
                .Display();

                /*" -157- DISPLAY 'LK-NUM-NSA            <' W77-NUM-NSA '>' */

                $"LK-NUM-NSA            <{W77_NUM_NSA}>"
                .Display();

                /*" -158- DISPLAY 'TRACE                 <' LK-TRACE '>' */

                $"TRACE                 <{LK_TRACE}>"
                .Display();

                /*" -159- DISPLAY '--------------------------------------------' */
                _.Display($"--------------------------------------------");

                /*" -160- DISPLAY ' ' */
                _.Display($" ");

                /*" -162- END-IF */
            }


            /*" -171- INITIALIZE LK-OUT-COD-RETORNO LK-OUT-SQLCODE LK-OUT-MENSAGEM LK-OUT-SQLERRMC LK-OUT-SQLSTATE W77-MENSAGEM REPLACING NUMERIC DATA BY ZEROS ALPHANUMERIC DATA BY SPACES */
            _.Initialize(
                LK_OUT_COD_RETORNO
                , LK_OUT_SQLCODE
                , LK_OUT_MENSAGEM
                , LK_OUT_SQLERRMC
                , LK_OUT_SQLSTATE
                , W77_MENSAGEM
            );

            /*" -175- MOVE 00 TO RETURN-CODE */
            _.Move(00, RETURN_CODE);

            /*" -176- IF LK-TRACE-ON OR LK-TRACE-OFF */

            if (LK_TRACE["LK_TRACE_ON"] || LK_TRACE["LK_TRACE_OFF"])
            {

                /*" -177- CONTINUE */

                /*" -178- ELSE */
            }
            else
            {


                /*" -183- STRING 'OPCAO DE TRACE INVALIDA. VALORES VALIDOS: ' '"TRACE ON " OU "TRACE OFF"' DELIMITED BY SIZE INTO W77-MENSAGEM END-STRING */
                #region STRING
                var spl1 = "OPCAO DE TRACE INVALIDA. VALORES VALIDOS: " + "\"TRACE ON \" OU \"TRACE OFF\"";
                _.Move(spl1, W77_MENSAGEM);
                #endregion

                /*" -184- MOVE 99 TO RETURN-CODE */
                _.Move(99, RETURN_CODE);

                /*" -185- GO TO P010-RETORNA */

                P010_RETORNA(); //GOTO
                return;

                /*" -187- END-IF */
            }


            /*" -188- MOVE 'SIATC' TO LK-COD-USUARIO-N061 */
            _.Move("SIATC", LK_COD_USUARIO_N061);

            /*" -189- MOVE 'FC0105S' TO LK-COD-PROG-ORIGEM-N061 */
            _.Move("FC0105S", LK_COD_PROG_ORIGEM_N061);

            /*" -190- MOVE 'CAP' TO LK-SIGLA-UNID-NEG-N061 */
            _.Move("CAP", LK_SIGLA_UNID_NEG_N061);

            /*" -191- MOVE 'PT-BR' TO LK-COD-MSG-LANG-N061 */
            _.Move("PT-BR", LK_COD_MSG_LANG_N061);

            /*" -192- MOVE 'B' TO LK-IND-TIPO-PROC-N061 */
            _.Move("B", LK_IND_TIPO_PROC_N061);

            /*" -193- MOVE ZEROS TO LK-NUM-ORDEM-N061 */
            _.Move(0, LK_NUM_ORDEM_N061);

            /*" -195- MOVE 20 TO LK-COD-EMPRESA-N061 */
            _.Move(20, LK_COD_EMPRESA_N061);

            /*" -201- INITIALIZE LK-IND-ERRO-N061 LK-MSG-RET-N061 LK-NM-TAB-N061 LK-SQLCODE-N061 LK-SQLERRMC-N061 */
            _.Initialize(
                LK_IND_ERRO_N061
                , LK_MSG_RET_N061
                , LK_NM_TAB_N061
                , LK_SQLCODE_N061
                , LK_SQLERRMC_N061
            );

            /*" -202- IF LK-TRACE-ON */

            if (LK_TRACE["LK_TRACE_ON"])
            {

                /*" -203- DISPLAY ' ' */
                _.Display($" ");

                /*" -212- DISPLAY 'CHAMA-FCATN061 COM <SIATC/FC0105S/CAP/PT-BR/' 'O/0/20> entrou as ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

                $"CHAMA-FCATN061 COM <SIATC/FC0105S/CAP/PT-BR/O/0/20> entrou as {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
                .Display();

                /*" -215- END-IF */
            }


            /*" -237- PERFORM P000_PRINCIPAL_DB_CALL_1 */

            P000_PRINCIPAL_DB_CALL_1();

            /*" -240- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -242- MOVE SQLCODE TO W77-SQLCODE LK-OUT-SQLCODE */
                _.Move(DB.SQLCODE, W77_SQLCODE, LK_OUT_SQLCODE);

                /*" -244- MOVE SQLERRMC TO W77-SQLERRMC LK-OUT-SQLERRMC */
                _.Move(DB.SQLERRMC, W77_SQLERRMC, LK_OUT_SQLERRMC);

                /*" -246- MOVE SQLSTATE TO W77-SQLSTATE LK-OUT-SQLSTATE */
                _.Move(DB.SQLSTATE, W77_SQLSTATE, LK_OUT_SQLSTATE);

                /*" -248- MOVE 2 TO W77-IND-ERRO LK-OUT-COD-RETORNO */
                _.Move(2, W77_IND_ERRO, LK_OUT_COD_RETORNO);

                /*" -251- STRING 'ERRO NO CALL DA FCATN061. SQLCODE <' W77-SQLCODE '>' DELIMITED BY SIZE INTO LK-OUT-MENSAGEM END-STRING */
                #region STRING
                var spl2 = "ERRO NO CALL DA FCATN061. SQLCODE <" + W77_SQLCODE.GetMoveValues();
                spl2 += ">";
                _.Move(spl2, LK_OUT_MENSAGEM);
                #endregion

                /*" -252- MOVE LK-OUT-MENSAGEM TO W77-MENSAGEM */
                _.Move(LK_OUT_MENSAGEM, W77_MENSAGEM);

                /*" -253- MOVE 99 TO RETURN-CODE */
                _.Move(99, RETURN_CODE);

                /*" -254- GO TO P010-RETORNA */

                P010_RETORNA(); //GOTO
                return;

                /*" -256- END-IF */
            }


            /*" -258- MOVE LK-SQLCODE-N061 TO LK-OUT-SQLCODE W77-SQLCODE */
            _.Move(LK_SQLCODE_N061, LK_OUT_SQLCODE, W77_SQLCODE);

            /*" -260- MOVE LK-SQLERRMC-N061 TO LK-OUT-SQLERRMC W77-SQLERRMC */
            _.Move(LK_SQLERRMC_N061, LK_OUT_SQLERRMC, W77_SQLERRMC);

            /*" -262- MOVE LK-MSG-RET-N061(1:120) TO LK-OUT-MENSAGEM W77-MENSAGEM */
            _.Move(LK_MSG_RET_N061.Substring(1, 120), LK_OUT_MENSAGEM, W77_MENSAGEM);

            /*" -264- MOVE LK-SQLERRMC-N061 TO LK-OUT-SQLERRMC W77-SQLERRMC */
            _.Move(LK_SQLERRMC_N061, LK_OUT_SQLERRMC, W77_SQLERRMC);

            /*" -267- MOVE LK-IND-ERRO-N061 TO LK-OUT-COD-RETORNO W77-IND-ERRO */
            _.Move(LK_IND_ERRO_N061, LK_OUT_COD_RETORNO, W77_IND_ERRO);

            /*" -268- IF LK-SQLCODE-N061 NOT EQUAL ZEROS AND +100 */

            if (!LK_SQLCODE_N061.In("00", "+100"))
            {

                /*" -270- DISPLAY 'ERRO DE SQLCODE <' W77-SQLCODE '>' ' NO RETORNO DA FCATN061.' */

                $"ERRO DE SQLCODE <{W77_SQLCODE}> NO RETORNO DA FCATN061."
                .Display();

                /*" -271- DISPLAY '-----------------------------------------------' */
                _.Display($"-----------------------------------------------");

                /*" -272- DISPLAY ' IND_ERRO DA FCATN061 <' W77-IND-ERRO '>' */

                $" IND_ERRO DA FCATN061 <{W77_IND_ERRO}>"
                .Display();

                /*" -273- DISPLAY ' MENSAGEM <' W77-MENSAGEM(01:60) '>' */

                $" MENSAGEM <{W77_MENSAGEM.Substring(1, 60)}>"
                .Display();

                /*" -274- DISPLAY '          <' W77-MENSAGEM(61:60) '>' */

                $"          <{W77_MENSAGEM.Substring(61, 60)}>"
                .Display();

                /*" -275- DISPLAY ' ERRMC    <' W77-SQLERRMC '>' */

                $" ERRMC    <{W77_SQLERRMC}>"
                .Display();

                /*" -276- DISPLAY '***********************************************' */
                _.Display($"***********************************************");

                /*" -277- MOVE 99 TO LK-OUT-COD-RETORNO */
                _.Move(99, LK_OUT_COD_RETORNO);

                /*" -279- END-IF */
            }


            /*" -280- IF LK-SQLCODE-N061 EQUAL +100 */

            if (LK_SQLCODE_N061 == +100)
            {

                /*" -284- MOVE 0 TO LK-OUT-COD-RETORNO */
                _.Move(0, LK_OUT_COD_RETORNO);

                /*" -285- DISPLAY '----------------------------------------------' */
                _.Display($"----------------------------------------------");

                /*" -286- DISPLAY '==> MSG RET. <' W77-MENSAGEM '>' */

                $"==> MSG RET. <{W77_MENSAGEM}>"
                .Display();

                /*" -287- DISPLAY '==> TITULO NAO INSERIDO. VERIFICAR SE JA EXISTE.' */
                _.Display($"==> TITULO NAO INSERIDO. VERIFICAR SE JA EXISTE.");

                /*" -288- DISPLAY '----------------------------------------------' */
                _.Display($"----------------------------------------------");

                /*" -289- ELSE */
            }
            else
            {


                /*" -290- IF LK-TRACE-ON */

                if (LK_TRACE["LK_TRACE_ON"])
                {

                    /*" -292- DISPLAY '-----------------------------------------------' */
                    _.Display($"-----------------------------------------------");

                    /*" -294- DISPLAY '==>  SQLCODE DO RETORNO <' W77-SQLCODE '>' */

                    $"==>  SQLCODE DO RETORNO <{W77_SQLCODE}>"
                    .Display();

                    /*" -296- DISPLAY '***********************************************' */
                    _.Display($"***********************************************");

                    /*" -297- END-IF */
                }


                /*" -298- MOVE 00 TO RETURN-CODE */
                _.Move(00, RETURN_CODE);

                /*" -300- END-IF */
            }


            /*" -300- GO TO P010-RETORNA. */

            P010_RETORNA(); //GOTO
            return;

        }

        [StopWatch]
        /*" P000-PRINCIPAL-DB-CALL-1 */
        public void P000_PRINCIPAL_DB_CALL_1()
        {
            /*" -237- EXEC SQL CALL FDRCAP.FCATN061 ( :LK-COD-USUARIO-N061 , :LK-COD-PROG-ORIGEM-N061 , :LK-SIGLA-UNID-NEG-N061 , :LK-COD-MSG-LANG-N061 , :LK-IND-TIPO-PROC-N061 , :LK-EMP-PARCEIRA , :LK-NUM-PLANO , :LK-NUM-SERIE , :LK-NUM-TITULO , :LK-COD-RAMO , :LK-NUM-PROPOSTA , :LK-QTD-TITULOS , :LK-VLR-TITULO , :LK-NUM-ORDEM-N061 , :W77-NUM-NSA , :LK-COD-EMPRESA-N061 , :LK-IND-ERRO-N061 , :LK-MSG-RET-N061 , :LK-NM-TAB-N061 , :LK-SQLCODE-N061 , :LK-SQLERRMC-N061) END-EXEC */

            var fDRCAP_FCATN061_Call1 = new FDRCAP_FCATN061_Call1()
            {
                LK_COD_USUARIO_N061 = LK_COD_USUARIO_N061.ToString(),
                LK_COD_PROG_ORIGEM_N061 = LK_COD_PROG_ORIGEM_N061.ToString(),
                LK_SIGLA_UNID_NEG_N061 = LK_SIGLA_UNID_NEG_N061.ToString(),
                LK_COD_MSG_LANG_N061 = LK_COD_MSG_LANG_N061.ToString(),
                LK_IND_TIPO_PROC_N061 = LK_IND_TIPO_PROC_N061.ToString(),
                LK_EMP_PARCEIRA = LK_EMP_PARCEIRA.ToString(),
                LK_NUM_PLANO = LK_NUM_PLANO.ToString(),
                LK_NUM_SERIE = LK_NUM_SERIE.ToString(),
                LK_NUM_TITULO = LK_NUM_TITULO.ToString(),
                LK_COD_RAMO = LK_COD_RAMO.ToString(),
                LK_NUM_PROPOSTA = LK_NUM_PROPOSTA.ToString(),
                LK_QTD_TITULOS = LK_QTD_TITULOS.ToString(),
                LK_VLR_TITULO = LK_VLR_TITULO.ToString(),
                LK_NUM_ORDEM_N061 = LK_NUM_ORDEM_N061.ToString(),
                W77_NUM_NSA = W77_NUM_NSA.ToString(),
                LK_COD_EMPRESA_N061 = LK_COD_EMPRESA_N061.ToString(),
                LK_IND_ERRO_N061 = LK_IND_ERRO_N061.ToString(),
                LK_MSG_RET_N061 = LK_MSG_RET_N061.ToString(),
                LK_NM_TAB_N061 = LK_NM_TAB_N061.ToString(),
                LK_SQLCODE_N061 = LK_SQLCODE_N061.ToString(),
                LK_SQLERRMC_N061 = LK_SQLERRMC_N061.ToString(),
            };

            var executed_1 = FDRCAP_FCATN061_Call1.Execute(fDRCAP_FCATN061_Call1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LK_COD_USUARIO_N061, LK_COD_USUARIO_N061);
                _.Move(executed_1.LK_COD_PROG_ORIGEM_N061, LK_COD_PROG_ORIGEM_N061);
                _.Move(executed_1.LK_SIGLA_UNID_NEG_N061, LK_SIGLA_UNID_NEG_N061);
                _.Move(executed_1.LK_COD_MSG_LANG_N061, LK_COD_MSG_LANG_N061);
                _.Move(executed_1.LK_IND_TIPO_PROC_N061, LK_IND_TIPO_PROC_N061);
                _.Move(executed_1.LK_EMP_PARCEIRA, LK_EMP_PARCEIRA);
                _.Move(executed_1.LK_NUM_PLANO, LK_NUM_PLANO);
                _.Move(executed_1.LK_NUM_SERIE, LK_NUM_SERIE);
                _.Move(executed_1.LK_NUM_TITULO, LK_NUM_TITULO);
                _.Move(executed_1.LK_COD_RAMO, LK_COD_RAMO);
                _.Move(executed_1.LK_NUM_PROPOSTA, LK_NUM_PROPOSTA);
                _.Move(executed_1.LK_QTD_TITULOS, LK_QTD_TITULOS);
                _.Move(executed_1.LK_VLR_TITULO, LK_VLR_TITULO);
                _.Move(executed_1.LK_NUM_ORDEM_N061, LK_NUM_ORDEM_N061);
                _.Move(executed_1.W77_NUM_NSA, W77_NUM_NSA);
                _.Move(executed_1.LK_COD_EMPRESA_N061, LK_COD_EMPRESA_N061);
                _.Move(executed_1.LK_IND_ERRO_N061, LK_IND_ERRO_N061);
                _.Move(executed_1.LK_MSG_RET_N061, LK_MSG_RET_N061);
                _.Move(executed_1.LK_NM_TAB_N061, LK_NM_TAB_N061);
                _.Move(executed_1.LK_SQLCODE_N061, LK_SQLCODE_N061);
                _.Move(executed_1.LK_SQLERRMC_N061, LK_SQLERRMC_N061);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P000_PRINCIPAL_SAIDA*/

        [StopWatch]
        /*" P010-RETORNA */
        private void P010_RETORNA(bool isPerform = false)
        {
            /*" -309- MOVE RETURN-CODE TO W77-RETURN */
            _.Move(RETURN_CODE, W77_RETURN);

            /*" -311- IF (W77-RETURN NOT EQUAL ZEROS) AND (W77-SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((W77_RETURN != 00) && (!W77_SQLCODE.In("00", "+100")))
            {

                /*" -312- DISPLAY '***********************************************' */
                _.Display($"***********************************************");

                /*" -313- DISPLAY ' RET-COD  <' W77-RETURN '>' */

                $" RET-COD  <{W77_RETURN}>"
                .Display();

                /*" -314- DISPLAY ' IND_ERRO <' W77-IND-ERRO '>' */

                $" IND_ERRO <{W77_IND_ERRO}>"
                .Display();

                /*" -315- DISPLAY ' SQLCODE  <' W77-SQLCODE '>' */

                $" SQLCODE  <{W77_SQLCODE}>"
                .Display();

                /*" -316- DISPLAY ' MENSAGEM <' W77-MENSAGEM(01:60) '>' */

                $" MENSAGEM <{W77_MENSAGEM.Substring(1, 60)}>"
                .Display();

                /*" -317- DISPLAY '          <' W77-MENSAGEM(61:60) '>' */

                $"          <{W77_MENSAGEM.Substring(61, 60)}>"
                .Display();

                /*" -318- DISPLAY ' ERRMC    <' W77-SQLERRMC '>' */

                $" ERRMC    <{W77_SQLERRMC}>"
                .Display();

                /*" -319- DISPLAY '***********************************************' */
                _.Display($"***********************************************");

                /*" -320- DISPLAY ' ' */
                _.Display($" ");

                /*" -322- END-IF */
            }


            /*" -324- IF LK-TRACE-ON */

            if (LK_TRACE["LK_TRACE_ON"])
            {

                /*" -325- IF W77-SQLCODE EQUAL ZEROS */

                if (W77_SQLCODE == 00)
                {

                    /*" -326- DISPLAY '==> MSG RET. <' W77-MENSAGEM '>' */

                    $"==> MSG RET. <{W77_MENSAGEM}>"
                    .Display();

                    /*" -328- END-IF */
                }


                /*" -335- DISPLAY '*** FC0105S TERMINOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) ' ***' */

                $"*** FC0105S TERMINOU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss} ***"
                .Display();

                /*" -336- DISPLAY ' ' */
                _.Display($" ");

                /*" -338- END-IF */
            }


            /*" -338- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P010_SAIDA*/
    }
}