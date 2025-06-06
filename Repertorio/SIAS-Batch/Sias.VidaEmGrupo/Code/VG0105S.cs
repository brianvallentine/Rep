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
using Sias.VidaEmGrupo.DB2.VG0105S;

namespace Code
{
    public class VG0105S
    {
        public bool IsCall { get; set; }

        public VG0105S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      * ESTE PROGRAMA � UMA C�PIA DO FC0105S, COM MODIFICA��ES PARA           */
        /*"      * PROMOVER UMA NOVA INTEGRA��O COM A CNP CAPITALIZA��O, QUE             */
        /*"      * DEIXAR� DE USAR O MAINFRAME. A NOVA ESTRUTURA USAR� SERVI�OS          */
        /*"      * QUE UTILIZAR�O NOSSAS NOVAS TABELAS CRIADAS PARA REALIZAR A           */
        /*"      * INTEGRA��O. ESSE PROGRAMA GRAVAR� A SOLICITA��O DE COMPRA OU          */
        /*"      * RENOVA��O NESSAS TABELAS.                                             */
        /*"      * UMA VEZ PREENCHIDAS, TEREMOS UMA ROTINA QUE VAI PEGAR ESSAS           */
        /*"      * SOLICITA��ES E LEVAR VIA (GI) PARA CAP EFETIVAR.                      */
        /*"      * NOS MESMOS MOLDES SER� FEITO MARCA��ES NESSAS TABELAS                 */
        /*"      * INDICANDO AS ETAPAS DO PROCESSO, PARA GRAVAR DE VOLTA O               */
        /*"      * N�MERO DA SORTE GERADO E ASSIM, PODEMOS CONSUMI-LO DO LADO            */
        /*"      * DE C�.                                                                */
        /*"      * TENTAREMOS MANTER O MAIS PARECIDO POSS�VEL A ESTRUTURA PARA           */
        /*"      * MINIMIZAR O IMPACTO NOS PROGRAMAS QUE CHAMAM ESSES 2 SERVI�OS         */
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
        /*"      *VERSAO: 004 - 13/03/2024 - AJUSTES NA QUERY QUE TRATA RENOVACAO        */
        /*"      *----------------------------------------------------------------*      */
        /*"      *VERSAO: 003 - 17/02/2024 - AJUSTES NA QUERY QUE TRATA RENOVACAO        */
        /*"      *----------------------------------------------------------------*      */
        /*"      *VERSAO: 002 - 15/02/2024 - AJUSTES NO WHERE DO R0100 e Displays        */
        /*"      *----------------------------------------------------------------*      */
        /*"      *VERSAO: 001 - 02/01/24 - DEMANDA 564320 - Criar nova integra��o *      */
        /*"      *                         com a CNP Capitaliza��o atrav�s do     *      */
        /*"      *                         consumo de servi�os                    *      */
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
        /*"77  W77-COD-USUARIO         PIC X(008) VALUE SPACES.*/
        public StringBasis W77_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
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
        /*"77 WS-DATA                          PIC X(010) VALUE SPACES.*/
        public StringBasis WS_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77 WS-SMALLINT-1                    PIC 9(005) VALUE ZEROS.*/
        public IntBasis WS_SMALLINT_1 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
        /*"77 WS-SMALLINT-2                    PIC 9(005) VALUE ZEROS.*/
        public IntBasis WS_SMALLINT_2 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
        /*"77 WS-SMALLINT-3                    PIC 9(005) VALUE ZEROS.*/
        public IntBasis WS_SMALLINT_3 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
        /*"77 WS-SMALLINT-4                    PIC 9(005) VALUE ZEROS.*/
        public IntBasis WS_SMALLINT_4 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
        /*"77 WS-INTEGER-1                     PIC 9(009) VALUE ZEROS.*/
        public IntBasis WS_INTEGER_1 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"77 WS-INTEGER-2                     PIC 9(009) VALUE ZEROS.*/
        public IntBasis WS_INTEGER_2 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"77 WS-INTEGER-3                     PIC 9(009) VALUE ZEROS.*/
        public IntBasis WS_INTEGER_3 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"77 WS-INTEGER-4                     PIC 9(009) VALUE ZEROS.*/
        public IntBasis WS_INTEGER_4 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"77 WS-BIGINT-1                      PIC 99999999999999 .*/
        public IntBasis WS_BIGINT_1 { get; set; } = new IntBasis(new PIC("9", "14", "99999999999999"));
        /*"77 WS-BIGINT-2                      PIC 99999999999999 .*/
        public IntBasis WS_BIGINT_2 { get; set; } = new IntBasis(new PIC("9", "14", "99999999999999"));
        /*"77 WS-BIGINT-3                      PIC 99999999999999 .*/
        public IntBasis WS_BIGINT_3 { get; set; } = new IntBasis(new PIC("9", "14", "99999999999999"));
        /*"77 WS-BIGINT-4                      PIC 99999999999999 .*/
        public IntBasis WS_BIGINT_4 { get; set; } = new IntBasis(new PIC("9", "14", "99999999999999"));
        /*"77 WS-DECIMAL-1                     PIC ZZZZZZZZZZ9,999999 .*/
        public DoubleBasis WS_DECIMAL_1 { get; set; } = new DoubleBasis(new PIC("9", "11", "ZZZZZZZZZZ9V999999"), 6);
        /*"77 WS-DECIMAL-2                     PIC ZZZZZZZZZZ9,999999 .*/
        public DoubleBasis WS_DECIMAL_2 { get; set; } = new DoubleBasis(new PIC("9", "11", "ZZZZZZZZZZ9V999999"), 6);
        /*"77 WS-DECIMAL-3                     PIC ZZZZZZZZZZ9,999999 .*/
        public DoubleBasis WS_DECIMAL_3 { get; set; } = new DoubleBasis(new PIC("9", "11", "ZZZZZZZZZZ9V999999"), 6);
        /*"77 WS-DECIMAL-4                     PIC ZZZZZZZZZZ9,999999 .*/
        public DoubleBasis WS_DECIMAL_4 { get; set; } = new DoubleBasis(new PIC("9", "11", "ZZZZZZZZZZ9V999999"), 6);
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
        /*" 01 LK-COD-USUARIO       PIC X(008).*/
        public StringBasis LK_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
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


        public Copies.SPVG013W SPVG013W { get; set; } = new Copies.SPVG013W();
        public Copies.LBHCT002 LBHCT002 { get; set; } = new Copies.LBHCT002();
        public Dclgens.VG135 VG135 { get; set; } = new Dclgens.VG135();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(IntBasis LK_NUM_PLANO_P, IntBasis LK_NUM_SERIE_P, IntBasis LK_NUM_TITULO_P, DoubleBasis LK_NUM_PROPOSTA_P, IntBasis LK_QTD_TITULOS_P, DoubleBasis LK_VLR_TITULO_P, IntBasis LK_EMP_PARCEIRA_P, IntBasis LK_COD_RAMO_P, StringBasis LK_COD_USUARIO_P, IntBasis LK_NUM_NSA_P, StringBasis LK_TRACE_P, IntBasis LK_OUT_COD_RETORNO_P, IntBasis LK_OUT_SQLCODE_P, StringBasis LK_OUT_MENSAGEM_P, StringBasis LK_OUT_SQLERRMC_P, StringBasis LK_OUT_SQLSTATE_P) //PROCEDURE DIVISION USING 
        /*LK_NUM_PLANO
        LK_NUM_SERIE
        LK_NUM_TITULO
        LK_NUM_PROPOSTA
        LK_QTD_TITULOS
        LK_VLR_TITULO
        LK_EMP_PARCEIRA
        LK_COD_RAMO
        LK_COD_USUARIO
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
                this.LK_COD_USUARIO.Value = LK_COD_USUARIO_P.Value;
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

            Result = new { LK_NUM_PLANO, LK_NUM_SERIE, LK_NUM_TITULO, LK_NUM_PROPOSTA, LK_QTD_TITULOS, LK_VLR_TITULO, LK_EMP_PARCEIRA, LK_COD_RAMO, LK_COD_USUARIO, LK_NUM_NSA, LK_TRACE, LK_OUT_COD_RETORNO, LK_OUT_SQLCODE, LK_OUT_MENSAGEM, LK_OUT_SQLERRMC, LK_OUT_SQLSTATE, CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" P000-PRINCIPAL-SECTION */
        private void P000_PRINCIPAL_SECTION()
        {
            /*" -186- MOVE LK-NUM-PLANO TO W77-NUM-PLANO */
            _.Move(LK_NUM_PLANO, W77_NUM_PLANO);

            /*" -187- MOVE LK-NUM-SERIE TO W77-NUM-SERIE */
            _.Move(LK_NUM_SERIE, W77_NUM_SERIE);

            /*" -188- MOVE LK-NUM-TITULO TO W77-NUM-TITULO */
            _.Move(LK_NUM_TITULO, W77_NUM_TITULO);

            /*" -189- MOVE LK-NUM-PROPOSTA TO W77-NUM-PROPOSTA */
            _.Move(LK_NUM_PROPOSTA, W77_NUM_PROPOSTA);

            /*" -190- MOVE LK-QTD-TITULOS TO W77-QTD-TITULO */
            _.Move(LK_QTD_TITULOS, W77_QTD_TITULO);

            /*" -191- MOVE LK-VLR-TITULO TO W77-VLR-TITULO */
            _.Move(LK_VLR_TITULO, W77_VLR_TITULO);

            /*" -192- MOVE LK-EMP-PARCEIRA TO W77-EMP-PARCEIRA */
            _.Move(LK_EMP_PARCEIRA, W77_EMP_PARCEIRA);

            /*" -193- MOVE LK-COD-RAMO TO W77-COD-RAMO */
            _.Move(LK_COD_RAMO, W77_COD_RAMO);

            /*" -194- MOVE LK-COD-USUARIO TO W77-COD-USUARIO */
            _.Move(LK_COD_USUARIO, W77_COD_USUARIO);

            /*" -195- MOVE ZEROS TO LK-NUM-NSA */
            _.Move(0, LK_NUM_NSA);

            /*" -198- MOVE '0001-01-01' TO W77-NUM-NSA */
            _.Move("0001-01-01", W77_NUM_NSA);

            /*" -199- IF LK-TRACE-ON */

            if (LK_TRACE["LK_TRACE_ON"])
            {

                /*" -200- DISPLAY '************************************************' */
                _.Display($"************************************************");

                /*" -201- DISPLAY '*                 VG0105S                      *' */
                _.Display($"*                 VG0105S                      *");

                /*" -202- DISPLAY '* CHAMA A SPBVG013 PARA FAZER OS PEDIDOS     *' */
                _.Display($"* CHAMA A SPBVG013 PARA FAZER OS PEDIDOS     *");

                /*" -203- DISPLAY '* DE RENOVA��O OU COMPRA                     *' */
                _.Display($"* DE RENOVA��O OU COMPRA                     *");

                /*" -204- DISPLAY '* DE TITULOS ACOPLADOS                       *' */
                _.Display($"* DE TITULOS ACOPLADOS                       *");

                /*" -205- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -212- DISPLAY '* VERSAO: 04 - ' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) ' AS ' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) '          *' */

                $"* VERSAO: 04 - FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)} AS FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}          *"
                .Display();

                /*" -213- DISPLAY '************************************************' */
                _.Display($"************************************************");

                /*" -214- DISPLAY ' ' */
                _.Display($" ");

                /*" -221- DISPLAY '--> INICIOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

                $"--> INICIOU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
                .Display();

                /*" -222- DISPLAY ' ' */
                _.Display($" ");

                /*" -223- DISPLAY '--------------------------------------------' */
                _.Display($"--------------------------------------------");

                /*" -224- DISPLAY '          PARAMETROS INFORMADOS' */
                _.Display($"          PARAMETROS INFORMADOS");

                /*" -226- DISPLAY '--------------------------------------------' */
                _.Display($"--------------------------------------------");

                /*" -227- DISPLAY 'NRO. DO PLANO         <' W77-NUM-PLANO '>' */

                $"NRO. DO PLANO         <{W77_NUM_PLANO}>"
                .Display();

                /*" -228- DISPLAY 'NRO. DA SERIE         <' W77-NUM-SERIE '>' */

                $"NRO. DA SERIE         <{W77_NUM_SERIE}>"
                .Display();

                /*" -229- DISPLAY 'NRO. DO TITULO        <' W77-NUM-TITULO '>' */

                $"NRO. DO TITULO        <{W77_NUM_TITULO}>"
                .Display();

                /*" -230- DISPLAY 'NRO. DA PROPOSTA      <' W77-NUM-PROPOSTA '>' */

                $"NRO. DA PROPOSTA      <{W77_NUM_PROPOSTA}>"
                .Display();

                /*" -231- DISPLAY 'QUANTIDADE DE TITULOS <' W77-QTD-TITULO '>' */

                $"QUANTIDADE DE TITULOS <{W77_QTD_TITULO}>"
                .Display();

                /*" -232- DISPLAY 'VALOR DO TITULO       <' W77-VLR-TITULO '>' */

                $"VALOR DO TITULO       <{W77_VLR_TITULO}>"
                .Display();

                /*" -233- DISPLAY 'EMPRESA PARCEIRA      <' W77-EMP-PARCEIRA '>' */

                $"EMPRESA PARCEIRA      <{W77_EMP_PARCEIRA}>"
                .Display();

                /*" -234- DISPLAY 'CODIGO RAMO           <' W77-COD-RAMO '>' */

                $"CODIGO RAMO           <{W77_COD_RAMO}>"
                .Display();

                /*" -235- DISPLAY 'CODIGO USUARIO        <' W77-COD-USUARIO '>' */

                $"CODIGO USUARIO        <{W77_COD_USUARIO}>"
                .Display();

                /*" -236- DISPLAY 'LK-NUM-NSA            <' W77-NUM-NSA '>' */

                $"LK-NUM-NSA            <{W77_NUM_NSA}>"
                .Display();

                /*" -237- DISPLAY 'TRACE                 <' LK-TRACE '>' */

                $"TRACE                 <{LK_TRACE}>"
                .Display();

                /*" -238- DISPLAY '--------------------------------------------' */
                _.Display($"--------------------------------------------");

                /*" -239- DISPLAY ' ' */
                _.Display($" ");

                /*" -241- END-IF */
            }


            /*" -241- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -271- INITIALIZE LK-OUT-COD-RETORNO LK-OUT-SQLCODE LK-OUT-MENSAGEM LK-OUT-SQLERRMC LK-OUT-SQLSTATE W77-MENSAGEM W77-IND-ERRO W77-SQLCODE LK-VG013-TRACE LK-VG013-SISTEMA-CHAMADOR LK-VG013-CANAL LK-VG013-ORIGEM LK-VG013-COD-USUARIO LK-VG013-TIPO-ACAO LK-VG013-IDE-SISTEMA LK-VG013-NUM-CERTIFICADO LK-VG013-COD-PRODUTO LK-VG013-COD-PLANO LK-VG013-QTD-TITULO LK-VG013-VLR-TITULO LK-VG013-COD-EMPRESA-CAP LK-VG013-COD-RETORNO-API LK-VG013-DES-ERRO LK-VG013-DES-ACAO REPLACING NUMERIC DATA BY ZEROS ALPHANUMERIC DATA BY SPACES */
            _.Initialize(
                LK_OUT_COD_RETORNO
                , LK_OUT_SQLCODE
                , LK_OUT_MENSAGEM
                , LK_OUT_SQLERRMC
                , LK_OUT_SQLSTATE
                , W77_MENSAGEM
                , W77_IND_ERRO
                , W77_SQLCODE
                , SPVG013W.LK_VG013_TRACE
                , SPVG013W.LK_VG013_SISTEMA_CHAMADOR
                , SPVG013W.LK_VG013_CANAL
                , SPVG013W.LK_VG013_ORIGEM
                , SPVG013W.LK_VG013_COD_USUARIO
                , SPVG013W.LK_VG013_TIPO_ACAO
                , SPVG013W.LK_VG013_IDE_SISTEMA
                , SPVG013W.LK_VG013_NUM_CERTIFICADO
                , SPVG013W.LK_VG013_COD_PRODUTO
                , SPVG013W.LK_VG013_COD_PLANO
                , SPVG013W.LK_VG013_QTD_TITULO
                , SPVG013W.LK_VG013_VLR_TITULO
                , SPVG013W.LK_VG013_COD_EMPRESA_CAP
                , SPVG013W.LK_VG013_COD_RETORNO_API
                , SPVG013W.LK_VG013_DES_ERRO
                , SPVG013W.LK_VG013_DES_ACAO
            );

            /*" -274- MOVE 00 TO RETURN-CODE */
            _.Move(00, RETURN_CODE);

            /*" -275- IF LK-TRACE-ON OR LK-TRACE-OFF */

            if (LK_TRACE["LK_TRACE_ON"] || LK_TRACE["LK_TRACE_OFF"])
            {

                /*" -276- CONTINUE */

                /*" -277- ELSE */
            }
            else
            {


                /*" -282- STRING 'OPCAO DE TRACE INVALIDA. VALORES VALIDOS: ' '"TRACE ON " OU "TRACE OFF"' DELIMITED BY SIZE INTO W77-MENSAGEM END-STRING */
                #region STRING
                var spl1 = "OPCAO DE TRACE INVALIDA. VALORES VALIDOS: " + "\"TRACE ON \" OU \"TRACE OFF\"";
                _.Move(spl1, W77_MENSAGEM);
                #endregion

                /*" -285- MOVE 2 TO W77-IND-ERRO LK-OUT-COD-RETORNO */
                _.Move(2, W77_IND_ERRO, LK_OUT_COD_RETORNO);

                /*" -286- MOVE 99 TO RETURN-CODE */
                _.Move(99, RETURN_CODE);

                /*" -287- GO TO P010-RETORNA */

                P010_RETORNA(); //GOTO
                return;

                /*" -298- END-IF */
            }


            /*" -300- MOVE 'N' TO LK-VG013-TRACE */
            _.Move("N", SPVG013W.LK_VG013_TRACE);

            /*" -301- MOVE 'SIAS - VG0105S' TO LK-VG013-SISTEMA-CHAMADOR */
            _.Move("SIAS - VG0105S", SPVG013W.LK_VG013_SISTEMA_CHAMADOR);

            /*" -302- MOVE 0 TO LK-VG013-CANAL */
            _.Move(0, SPVG013W.LK_VG013_CANAL);

            /*" -304- MOVE 0 TO LK-VG013-ORIGEM */
            _.Move(0, SPVG013W.LK_VG013_ORIGEM);

            /*" -306- MOVE LK-COD-USUARIO TO LK-VG013-COD-USUARIO */
            _.Move(LK_COD_USUARIO, SPVG013W.LK_VG013_COD_USUARIO);

            /*" -307- IF LK-COD-USUARIO(1:2) EQUAL 'SZ' */

            if (LK_COD_USUARIO.Substring(1, 2) == "SZ")
            {

                /*" -308- MOVE 'SZ' TO LK-VG013-IDE-SISTEMA */
                _.Move("SZ", SPVG013W.LK_VG013_IDE_SISTEMA);

                /*" -309- ELSE */
            }
            else
            {


                /*" -310- MOVE 'VG' TO LK-VG013-IDE-SISTEMA */
                _.Move("VG", SPVG013W.LK_VG013_IDE_SISTEMA);

                /*" -312- END-IF */
            }


            /*" -313- MOVE LK-NUM-PLANO TO LK-VG013-COD-PLANO */
            _.Move(LK_NUM_PLANO, SPVG013W.LK_VG013_COD_PLANO);

            /*" -314- MOVE LK-NUM-PROPOSTA TO LK-VG013-NUM-CERTIFICADO */
            _.Move(LK_NUM_PROPOSTA, SPVG013W.LK_VG013_NUM_CERTIFICADO);

            /*" -315- MOVE LK-QTD-TITULOS TO LK-VG013-QTD-TITULO */
            _.Move(LK_QTD_TITULOS, SPVG013W.LK_VG013_QTD_TITULO);

            /*" -316- MOVE LK-VLR-TITULO TO LK-VG013-VLR-TITULO */
            _.Move(LK_VLR_TITULO, SPVG013W.LK_VG013_VLR_TITULO);

            /*" -317- MOVE LK-EMP-PARCEIRA TO LK-VG013-COD-EMPRESA-CAP */
            _.Move(LK_EMP_PARCEIRA, SPVG013W.LK_VG013_COD_EMPRESA_CAP);

            /*" -319- MOVE LK-COD-RAMO TO LK-VG013-COD-PRODUTO */
            _.Move(LK_COD_RAMO, SPVG013W.LK_VG013_COD_PRODUTO);

            /*" -322- IF LK-NUM-TITULO EQUAL ZEROS AND LK-NUM-SERIE EQUAL ZEROS */

            if (LK_NUM_TITULO == 00 && LK_NUM_SERIE == 00)
            {

                /*" -323- MOVE 01 TO LK-VG013-TIPO-ACAO */
                _.Move(01, SPVG013W.LK_VG013_TIPO_ACAO);

                /*" -325- ELSE */
            }
            else
            {


                /*" -326- MOVE 02 TO LK-VG013-TIPO-ACAO */
                _.Move(02, SPVG013W.LK_VG013_TIPO_ACAO);

                /*" -327- PERFORM R0100-VALIDA-STA-RENOVACAO */

                R0100_VALIDA_STA_RENOVACAO_SECTION();

                /*" -327- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM P0000_00_START */

            P0000_00_START();

        }

        [StopWatch]
        /*" P0000-00-START */
        private void P0000_00_START(bool isPerform = false)
        {
            /*" -340- INITIALIZE H-OUT-COD-RETORNO H-OUT-COD-RETORNO-SQL H-OUT-MENSAGEM H-OUT-SQLERRMC H-OUT-SQLSTATE */
            _.Initialize(
                LBHCT002.H_OUT_COD_RETORNO
                , LBHCT002.H_OUT_COD_RETORNO_SQL
                , LBHCT002.H_OUT_MENSAGEM
                , LBHCT002.H_OUT_SQLERRMC
                , LBHCT002.H_OUT_SQLSTATE
            );

            /*" -341- IF LK-TRACE-ON */

            if (LK_TRACE["LK_TRACE_ON"])
            {

                /*" -342- DISPLAY ' ' */
                _.Display($" ");

                /*" -351- DISPLAY 'CHAMA-SPBVG013 ' '> entrou as ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

                $"CHAMA-SPBVG013 > entrou as {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
                .Display();

                /*" -353- DISPLAY 'LK-VG013-TRACE.:            ' LK-VG013-TRACE */
                _.Display($"LK-VG013-TRACE.:            {SPVG013W.LK_VG013_TRACE}");

                /*" -355- DISPLAY 'LK-VG013-SISTEMA-CHAMADOR.: ' LK-VG013-SISTEMA-CHAMADOR */
                _.Display($"LK-VG013-SISTEMA-CHAMADOR.: {SPVG013W.LK_VG013_SISTEMA_CHAMADOR}");

                /*" -357- DISPLAY 'LK-VG013-CANAL.:            ' LK-VG013-CANAL */
                _.Display($"LK-VG013-CANAL.:            {SPVG013W.LK_VG013_CANAL}");

                /*" -359- DISPLAY 'LK-VG013-ORIGEM.:           ' LK-VG013-ORIGEM */
                _.Display($"LK-VG013-ORIGEM.:           {SPVG013W.LK_VG013_ORIGEM}");

                /*" -361- DISPLAY 'LK-VG013-COD-USUARIO.:      ' LK-VG013-COD-USUARIO */
                _.Display($"LK-VG013-COD-USUARIO.:      {SPVG013W.LK_VG013_COD_USUARIO}");

                /*" -363- DISPLAY 'LK-VG013-TIPO-ACAO.:        ' LK-VG013-TIPO-ACAO */
                _.Display($"LK-VG013-TIPO-ACAO.:        {SPVG013W.LK_VG013_TIPO_ACAO}");

                /*" -365- DISPLAY 'LK-VG013-IDE-SISTEMA.:      ' LK-VG013-IDE-SISTEMA */
                _.Display($"LK-VG013-IDE-SISTEMA.:      {SPVG013W.LK_VG013_IDE_SISTEMA}");

                /*" -367- DISPLAY 'LK-VG013-NUM-CERTIFICADO.:  ' LK-VG013-NUM-CERTIFICADO */
                _.Display($"LK-VG013-NUM-CERTIFICADO.:  {SPVG013W.LK_VG013_NUM_CERTIFICADO}");

                /*" -369- DISPLAY 'LK-VG013-COD-PRODUTO.:      ' LK-VG013-COD-PRODUTO */
                _.Display($"LK-VG013-COD-PRODUTO.:      {SPVG013W.LK_VG013_COD_PRODUTO}");

                /*" -371- DISPLAY 'LK-VG013-COD-PLANO.:        ' LK-VG013-COD-PLANO */
                _.Display($"LK-VG013-COD-PLANO.:        {SPVG013W.LK_VG013_COD_PLANO}");

                /*" -373- DISPLAY 'LK-VG013-QTD-TITULO.:       ' LK-VG013-QTD-TITULO */
                _.Display($"LK-VG013-QTD-TITULO.:       {SPVG013W.LK_VG013_QTD_TITULO}");

                /*" -376- DISPLAY 'LK-VG013-VLR-TITULO.:       ' LK-VG013-VLR-TITULO */
                _.Display($"LK-VG013-VLR-TITULO.:       {SPVG013W.LK_VG013_VLR_TITULO}");

                /*" -378- END-IF */
            }


            /*" -432- CALL 'SPBVG013' USING LK-VG013-TRACE ,LK-VG013-SISTEMA-CHAMADOR ,LK-VG013-CANAL ,LK-VG013-ORIGEM ,LK-VG013-COD-USUARIO ,LK-VG013-TIPO-ACAO ,LK-VG013-IDE-SISTEMA ,LK-VG013-NUM-CERTIFICADO ,LK-VG013-COD-PRODUTO ,LK-VG013-COD-PLANO ,LK-VG013-QTD-TITULO ,LK-VG013-VLR-TITULO ,LK-VG013-COD-EMPRESA-CAP ,LK-VG013-COD-RETORNO-API ,LK-VG013-DES-ERRO ,LK-VG013-DES-ACAO ,H-OUT-COD-RETORNO ,H-OUT-COD-RETORNO-SQL ,H-OUT-MENSAGEM ,H-OUT-SQLERRMC ,H-OUT-SQLSTATE */
            _.Call("SPBVG013", SPVG013W, LBHCT002);

            /*" -433-  EVALUATE H-OUT-COD-RETORNO  */

            /*" -434-  WHEN ZEROS  */

            /*" -434- IF   H-OUT-COD-RETORNO EQUALS  ZEROS */

            if (LBHCT002.H_OUT_COD_RETORNO == 00)
            {

                /*" -435- MOVE 00 TO RETURN-CODE */
                _.Move(00, RETURN_CODE);

                /*" -436- MOVE 0 TO LK-OUT-COD-RETORNO */
                _.Move(0, LK_OUT_COD_RETORNO);

                /*" -437-  WHEN OTHER  */

                /*" -437- ELSE */
            }
            else
            {


                /*" -438- MOVE LK-VG013-NUM-CERTIFICADO TO WS-BIGINT-1 */
                _.Move(SPVG013W.LK_VG013_NUM_CERTIFICADO, WS_BIGINT_1);

                /*" -439- MOVE LK-VG013-COD-PRODUTO TO WS-SMALLINT-1 */
                _.Move(SPVG013W.LK_VG013_COD_PRODUTO, WS_SMALLINT_1);

                /*" -440- MOVE LK-VG013-COD-PLANO TO WS-SMALLINT-2 */
                _.Move(SPVG013W.LK_VG013_COD_PLANO, WS_SMALLINT_2);

                /*" -441- MOVE W77-NUM-TITULO TO WS-SMALLINT-3 */
                _.Move(W77_NUM_TITULO, WS_SMALLINT_3);

                /*" -443- MOVE W77-NUM-SERIE TO WS-SMALLINT-4 */
                _.Move(W77_NUM_SERIE, WS_SMALLINT_4);

                /*" -447- MOVE 2 TO W77-IND-ERRO LK-OUT-COD-RETORNO */
                _.Move(2, W77_IND_ERRO, LK_OUT_COD_RETORNO);

                /*" -449- MOVE H-OUT-COD-RETORNO-SQL TO LK-OUT-SQLCODE W77-SQLCODE */
                _.Move(LBHCT002.H_OUT_COD_RETORNO_SQL, LK_OUT_SQLCODE, W77_SQLCODE);

                /*" -451- MOVE H-OUT-SQLERRMC TO LK-OUT-SQLERRMC W77-SQLERRMC */
                _.Move(LBHCT002.H_OUT_SQLERRMC, LK_OUT_SQLERRMC, W77_SQLERRMC);

                /*" -453- MOVE H-OUT-SQLSTATE TO LK-OUT-SQLSTATE */
                _.Move(LBHCT002.H_OUT_SQLSTATE, LK_OUT_SQLSTATE);

                /*" -467- STRING ' - ERRO NA CHAMADA DA SPBVG013.' '< MENSAGEM.:   ' H-OUT-MENSAGEM ' > ' '< SQLCODE.:    ' W77-SQLCODE ' > ' '< SQLERRMC.:   ' W77-SQLERRMC ' > ' '< SQLSTATE.:   ' H-OUT-SQLSTATE ' > ' '<CERTIFICADO= ' WS-BIGINT-1 '>' '<PRODUTO= ' WS-SMALLINT-1 '>' '<PLANO= ' WS-SMALLINT-2 '>' '<TITULO= ' WS-SMALLINT-3 '>' '<SERIE= ' WS-SMALLINT-4 '>' DELIMITED BY SIZE INTO LK-OUT-MENSAGEM */
                #region STRING
                var spl2 = " - ERRO NA CHAMADA DA SPBVG013." + "< MENSAGEM.: " + LBHCT002.H_OUT_MENSAGEM.GetMoveValues();
                spl2 += " > ";
                spl2 += "< SQLCODE.: ";
                var spl3 = W77_SQLCODE.GetMoveValues();
                spl3 += " > ";
                spl3 += "< SQLERRMC.: ";
                var spl4 = W77_SQLERRMC.GetMoveValues();
                spl4 += " > ";
                spl4 += "< SQLSTATE.: ";
                var spl5 = LBHCT002.H_OUT_SQLSTATE.GetMoveValues();
                spl5 += " > ";
                spl5 += "<CERTIFICADO= ";
                var spl6 = WS_BIGINT_1.GetMoveValues();
                spl6 += ">";
                spl6 += "<PRODUTO= ";
                var spl7 = WS_SMALLINT_1.GetMoveValues();
                spl7 += ">";
                spl7 += "<PLANO= ";
                var spl8 = WS_SMALLINT_2.GetMoveValues();
                spl8 += ">";
                spl8 += "<TITULO= ";
                var spl9 = WS_SMALLINT_3.GetMoveValues();
                spl9 += ">";
                spl9 += "<SERIE= ";
                var spl10 = WS_SMALLINT_4.GetMoveValues();
                spl10 += ">";
                var results11 = spl2 + spl3 + spl4 + spl5 + spl6 + spl7 + spl8 + spl9 + spl10;
                _.Move(results11, LK_OUT_MENSAGEM);
                #endregion

                /*" -469- MOVE LK-OUT-MENSAGEM TO W77-MENSAGEM */
                _.Move(LK_OUT_MENSAGEM, W77_MENSAGEM);

                /*" -470- MOVE 99 TO RETURN-CODE */
                _.Move(99, RETURN_CODE);

                /*" -471- GO TO P010-RETORNA */

                P010_RETORNA(); //GOTO
                return;

                /*" -532-  END-EVALUATE  */

                /*" -532- END-IF */
            }


            /*" -532- GO TO P010-RETORNA. */

            P010_RETORNA(); //GOTO
            return;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P000_PRINCIPAL_SAIDA*/

        [StopWatch]
        /*" R0100-VALIDA-STA-RENOVACAO-SECTION */
        private void R0100_VALIDA_STA_RENOVACAO_SECTION()
        {
            /*" -542- INITIALIZE DCLVG-ACOPLADO */
            _.Initialize(
                VG135.DCLVG_ACOPLADO
            );

            /*" -544- MOVE LK-NUM-PLANO TO VG135-COD-PLANO */
            _.Move(LK_NUM_PLANO, VG135.DCLVG_ACOPLADO.VG135_COD_PLANO);

            /*" -574- PERFORM R0100_VALIDA_STA_RENOVACAO_DB_SELECT_1 */

            R0100_VALIDA_STA_RENOVACAO_DB_SELECT_1();

            /*" -580- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -582- DISPLAY 'R0100 - ERRO NO R0100-VALIDA-STA-RENOVACAO' */
                _.Display($"R0100 - ERRO NO R0100-VALIDA-STA-RENOVACAO");

                /*" -584- MOVE SQLCODE TO W77-SQLCODE LK-OUT-SQLCODE */
                _.Move(DB.SQLCODE, W77_SQLCODE, LK_OUT_SQLCODE);

                /*" -586- MOVE SQLERRMC TO W77-SQLERRMC LK-OUT-SQLERRMC */
                _.Move(DB.SQLERRMC, W77_SQLERRMC, LK_OUT_SQLERRMC);

                /*" -588- MOVE SQLSTATE TO W77-SQLSTATE LK-OUT-SQLSTATE */
                _.Move(DB.SQLSTATE, W77_SQLSTATE, LK_OUT_SQLSTATE);

                /*" -590- MOVE 2 TO W77-IND-ERRO LK-OUT-COD-RETORNO */
                _.Move(2, W77_IND_ERRO, LK_OUT_COD_RETORNO);

                /*" -595- STRING 'ERRO NO R0100-VALIDA-STA-RENOVACAO. SQLCODE <' W77-SQLCODE '>' DELIMITED BY SIZE INTO LK-OUT-MENSAGEM END-STRING */
                #region STRING
                var spl11 = "ERRO NO R0100-VALIDA-STA-RENOVACAO. SQLCODE <" + W77_SQLCODE.GetMoveValues();
                spl11 += ">";
                _.Move(spl11, LK_OUT_MENSAGEM);
                #endregion

                /*" -596- MOVE VG135-NUM-CERTIFICADO TO WS-BIGINT-1 */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_NUM_CERTIFICADO, WS_BIGINT_1);

                /*" -597- MOVE LK-COD-RAMO TO WS-SMALLINT-1 */
                _.Move(LK_COD_RAMO, WS_SMALLINT_1);

                /*" -598- MOVE LK-NUM-PLANO TO WS-SMALLINT-2 */
                _.Move(LK_NUM_PLANO, WS_SMALLINT_2);

                /*" -599- MOVE W77-NUM-TITULO TO WS-SMALLINT-3 */
                _.Move(W77_NUM_TITULO, WS_SMALLINT_3);

                /*" -601- MOVE W77-NUM-SERIE TO WS-SMALLINT-4 */
                _.Move(W77_NUM_SERIE, WS_SMALLINT_4);

                /*" -607- DISPLAY ' <CERTIFICADO= ' WS-BIGINT-1 '>' '<PRODUTO= ' WS-SMALLINT-1 '>' '<PLANO= ' WS-SMALLINT-2 '>' '<TITULO= ' WS-SMALLINT-3 '>' '<SERIE= ' WS-SMALLINT-4 '>' */

                $" <CERTIFICADO= {WS_BIGINT_1}><PRODUTO= {WS_SMALLINT_1}><PLANO= {WS_SMALLINT_2}><TITULO= {WS_SMALLINT_3}><SERIE= {WS_SMALLINT_4}>"
                .Display();

                /*" -608- MOVE LK-OUT-MENSAGEM TO W77-MENSAGEM */
                _.Move(LK_OUT_MENSAGEM, W77_MENSAGEM);

                /*" -609- MOVE 99 TO RETURN-CODE */
                _.Move(99, RETURN_CODE);

                /*" -611- GO TO P010-RETORNA */

                P010_RETORNA(); //GOTO
                return;

                /*" -613- END-IF */
            }


            /*" -615- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -616- MOVE VG135-NUM-CERTIFICADO TO WS-BIGINT-1 */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_NUM_CERTIFICADO, WS_BIGINT_1);

                /*" -617- MOVE LK-COD-RAMO TO WS-SMALLINT-1 */
                _.Move(LK_COD_RAMO, WS_SMALLINT_1);

                /*" -618- MOVE LK-NUM-PLANO TO WS-SMALLINT-2 */
                _.Move(LK_NUM_PLANO, WS_SMALLINT_2);

                /*" -619- MOVE W77-NUM-TITULO TO WS-SMALLINT-3 */
                _.Move(W77_NUM_TITULO, WS_SMALLINT_3);

                /*" -621- MOVE W77-NUM-SERIE TO WS-SMALLINT-4 */
                _.Move(W77_NUM_SERIE, WS_SMALLINT_4);

                /*" -623- MOVE SQLCODE TO W77-SQLCODE LK-OUT-SQLCODE */
                _.Move(DB.SQLCODE, W77_SQLCODE, LK_OUT_SQLCODE);

                /*" -625- MOVE SQLERRMC TO W77-SQLERRMC LK-OUT-SQLERRMC */
                _.Move(DB.SQLERRMC, W77_SQLERRMC, LK_OUT_SQLERRMC);

                /*" -627- MOVE SQLSTATE TO W77-SQLSTATE LK-OUT-SQLSTATE */
                _.Move(DB.SQLSTATE, W77_SQLSTATE, LK_OUT_SQLSTATE);

                /*" -629- MOVE 2 TO W77-IND-ERRO LK-OUT-COD-RETORNO */
                _.Move(2, W77_IND_ERRO, LK_OUT_COD_RETORNO);

                /*" -639- STRING 'SOLICITACAO DE RENOVACAO NAO PODE SER REALIZADA' ' PORQUE NAO EXISTE DADO CADASTRADO NA ' 'VG_ACOPLADO PARA ESSE CERTIFICADO < SQLCODE.: ' W77-SQLCODE '>' DELIMITED BY SIZE INTO W77-MENSAGEM END-STRING */
                #region STRING
                var spl12 = "SOLICITACAO DE RENOVACAO NAO PODE SER REALIZADA" + " PORQUE NAO EXISTE DADO CADASTRADO NA " + "VG_ACOPLADO PARA ESSE CERTIFICADO < SQLCODE.: " + W77_SQLCODE.GetMoveValues();
                spl12 += ">";
                _.Move(spl12, W77_MENSAGEM);
                #endregion

                /*" -641- DISPLAY W77-MENSAGEM */
                _.Display(W77_MENSAGEM);

                /*" -647- DISPLAY ' <CERTIFICADO= ' WS-BIGINT-1 '>' '<PRODUTO= ' WS-SMALLINT-1 '>' '<PLANO= ' WS-SMALLINT-2 '>' '<TITULO= ' WS-SMALLINT-3 '>' '<SERIE= ' WS-SMALLINT-4 '>' */

                $" <CERTIFICADO= {WS_BIGINT_1}><PRODUTO= {WS_SMALLINT_1}><PLANO= {WS_SMALLINT_2}><TITULO= {WS_SMALLINT_3}><SERIE= {WS_SMALLINT_4}>"
                .Display();

                /*" -648- MOVE W77-MENSAGEM TO LK-OUT-MENSAGEM */
                _.Move(W77_MENSAGEM, LK_OUT_MENSAGEM);

                /*" -649- MOVE 99 TO RETURN-CODE */
                _.Move(99, RETURN_CODE);

                /*" -650- GO TO P010-RETORNA */

                P010_RETORNA(); //GOTO
                return;

                /*" -653- END-IF */
            }


            /*" -655- IF VG135-STA-ACOPLADO NOT EQUAL 7 */

            if (VG135.DCLVG_ACOPLADO.VG135_STA_ACOPLADO != 7)
            {

                /*" -657- IF VG135-STA-ACOPLADO EQUAL 3 */

                if (VG135.DCLVG_ACOPLADO.VG135_STA_ACOPLADO == 3)
                {

                    /*" -658- MOVE VG135-STA-ACOPLADO TO WS-SMALLINT-1 */
                    _.Move(VG135.DCLVG_ACOPLADO.VG135_STA_ACOPLADO, WS_SMALLINT_1);

                    /*" -667- STRING 'J� EXISTE UMA RENOVACAO EM ANDAMENTO.' ' - ' ' < STA-ACOPLADO.: ' WS-SMALLINT-1 '>' DELIMITED BY SIZE INTO W77-MENSAGEM END-STRING */
                    #region STRING
                    var spl13 = "J� EXISTE UMA RENOVACAO EM ANDAMENTO." + " - " + " < STA-ACOPLADO.: " + WS_SMALLINT_1.GetMoveValues();
                    spl13 += ">";
                    _.Move(spl13, W77_MENSAGEM);
                    #endregion

                    /*" -670- MOVE 0 TO W77-IND-ERRO LK-OUT-COD-RETORNO */
                    _.Move(0, W77_IND_ERRO, LK_OUT_COD_RETORNO);

                    /*" -671- DISPLAY ' < STA-ACOPLADO.: ' WS-SMALLINT-1 */
                    _.Display($" < STA-ACOPLADO.: {WS_SMALLINT_1}");

                    /*" -673- DISPLAY ' < VG135-NUM-CERTIFICADO.: ' VG135-NUM-CERTIFICADO */
                    _.Display($" < VG135-NUM-CERTIFICADO.: {VG135.DCLVG_ACOPLADO.VG135_NUM_CERTIFICADO}");

                    /*" -675- DISPLAY ' < VG135-COD-PLANO      .: ' VG135-COD-PLANO */
                    _.Display($" < VG135-COD-PLANO      .: {VG135.DCLVG_ACOPLADO.VG135_COD_PLANO}");

                    /*" -678- DISPLAY ' < VG135-COD-PRODUTO    .: ' VG135-COD-PRODUTO */
                    _.Display($" < VG135-COD-PRODUTO    .: {VG135.DCLVG_ACOPLADO.VG135_COD_PRODUTO}");

                    /*" -679- MOVE W77-MENSAGEM TO LK-OUT-MENSAGEM */
                    _.Move(W77_MENSAGEM, LK_OUT_MENSAGEM);

                    /*" -681- DISPLAY W77-MENSAGEM */
                    _.Display(W77_MENSAGEM);

                    /*" -682- MOVE 00 TO RETURN-CODE */
                    _.Move(00, RETURN_CODE);

                    /*" -684- GO TO P010-RETORNA */

                    P010_RETORNA(); //GOTO
                    return;

                    /*" -685- ELSE */
                }
                else
                {


                    /*" -686- MOVE VG135-STA-ACOPLADO TO WS-SMALLINT-1 */
                    _.Move(VG135.DCLVG_ACOPLADO.VG135_STA_ACOPLADO, WS_SMALLINT_1);

                    /*" -696- STRING 'SOLICITACAO DE RENOVACAO NAO PODE SER REALIZADA' ' - CERTIFICADO PENDENTE DE ATUALIZACAO.' ' < STA-ACOPLADO.: ' WS-SMALLINT-1 '>' DELIMITED BY SIZE INTO W77-MENSAGEM END-STRING */
                    #region STRING
                    var spl14 = "SOLICITACAO DE RENOVACAO NAO PODE SER REALIZADA" + " - CERTIFICADO PENDENTE DE ATUALIZACAO." + " < STA-ACOPLADO.: " + WS_SMALLINT_1.GetMoveValues();
                    spl14 += ">";
                    _.Move(spl14, W77_MENSAGEM);
                    #endregion

                    /*" -699- MOVE 2 TO W77-IND-ERRO LK-OUT-COD-RETORNO */
                    _.Move(2, W77_IND_ERRO, LK_OUT_COD_RETORNO);

                    /*" -700- DISPLAY ' < STA-ACOPLADO.: ' WS-SMALLINT-1 */
                    _.Display($" < STA-ACOPLADO.: {WS_SMALLINT_1}");

                    /*" -702- DISPLAY ' < VG135-NUM-CERTIFICADO.: ' VG135-NUM-CERTIFICADO */
                    _.Display($" < VG135-NUM-CERTIFICADO.: {VG135.DCLVG_ACOPLADO.VG135_NUM_CERTIFICADO}");

                    /*" -704- DISPLAY ' < VG135-COD-PLANO      .: ' VG135-COD-PLANO */
                    _.Display($" < VG135-COD-PLANO      .: {VG135.DCLVG_ACOPLADO.VG135_COD_PLANO}");

                    /*" -707- DISPLAY ' < VG135-COD-PRODUTO    .: ' VG135-COD-PRODUTO */
                    _.Display($" < VG135-COD-PRODUTO    .: {VG135.DCLVG_ACOPLADO.VG135_COD_PRODUTO}");

                    /*" -709- MOVE W77-MENSAGEM TO LK-OUT-MENSAGEM */
                    _.Move(W77_MENSAGEM, LK_OUT_MENSAGEM);

                    /*" -710- MOVE 99 TO RETURN-CODE */
                    _.Move(99, RETURN_CODE);

                    /*" -711- GO TO P010-RETORNA */

                    P010_RETORNA(); //GOTO
                    return;

                    /*" -713- END-IF */
                }


                /*" -715- END-IF */
            }


            /*" -716- MOVE VG135-NUM-CERTIFICADO TO LK-VG013-NUM-CERTIFICADO */
            _.Move(VG135.DCLVG_ACOPLADO.VG135_NUM_CERTIFICADO, SPVG013W.LK_VG013_NUM_CERTIFICADO);

            /*" -717- MOVE VG135-COD-PLANO TO LK-VG013-COD-PLANO */
            _.Move(VG135.DCLVG_ACOPLADO.VG135_COD_PLANO, SPVG013W.LK_VG013_COD_PLANO);

            /*" -719- MOVE VG135-COD-PRODUTO TO LK-VG013-COD-PRODUTO */
            _.Move(VG135.DCLVG_ACOPLADO.VG135_COD_PRODUTO, SPVG013W.LK_VG013_COD_PRODUTO);

            /*" -720- GO TO P0000-00-START */

            P0000_00_START(); //GOTO
            return;

            /*" -720- . */

        }

        [StopWatch]
        /*" R0100-VALIDA-STA-RENOVACAO-DB-SELECT-1 */
        public void R0100_VALIDA_STA_RENOVACAO_DB_SELECT_1()
        {
            /*" -574- EXEC SQL SELECT A.NUM_CERTIFICADO, A.COD_PLANO, A.COD_PRODUTO, A.STA_ACOPLADO INTO :VG135-NUM-CERTIFICADO , :VG135-COD-PLANO , :VG135-COD-PRODUTO , :VG135-STA-ACOPLADO FROM SEGUROS.VG_ACOPLADO A , SEGUROS.VG_ACOPLADO_TITULO B WHERE B.NUM_SERIE = :LK-NUM-SERIE AND B.NUM_TITULO = :LK-NUM-TITULO AND B.COD_PLANO = :VG135-COD-PLANO AND B.NUM_CERTIFICADO = A.NUM_CERTIFICADO AND B.COD_PLANO = A.COD_PLANO AND B.COD_PRODUTO = A.COD_PRODUTO AND B.IDE_SISTEMA = A.IDE_SISTEMA FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC */

            var r0100_VALIDA_STA_RENOVACAO_DB_SELECT_1_Query1 = new R0100_VALIDA_STA_RENOVACAO_DB_SELECT_1_Query1()
            {
                VG135_COD_PLANO = VG135.DCLVG_ACOPLADO.VG135_COD_PLANO.ToString(),
                LK_NUM_TITULO = LK_NUM_TITULO.ToString(),
                LK_NUM_SERIE = LK_NUM_SERIE.ToString(),
            };

            var executed_1 = R0100_VALIDA_STA_RENOVACAO_DB_SELECT_1_Query1.Execute(r0100_VALIDA_STA_RENOVACAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VG135_NUM_CERTIFICADO, VG135.DCLVG_ACOPLADO.VG135_NUM_CERTIFICADO);
                _.Move(executed_1.VG135_COD_PLANO, VG135.DCLVG_ACOPLADO.VG135_COD_PLANO);
                _.Move(executed_1.VG135_COD_PRODUTO, VG135.DCLVG_ACOPLADO.VG135_COD_PRODUTO);
                _.Move(executed_1.VG135_STA_ACOPLADO, VG135.DCLVG_ACOPLADO.VG135_STA_ACOPLADO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" P010-RETORNA */
        private void P010_RETORNA(bool isPerform = false)
        {
            /*" -733- MOVE RETURN-CODE TO W77-RETURN */
            _.Move(RETURN_CODE, W77_RETURN);

            /*" -735- IF (W77-RETURN NOT EQUAL ZEROS) AND (W77-SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((W77_RETURN != 00) && (!W77_SQLCODE.In("00", "+100")))
            {

                /*" -736- DISPLAY '***********************************************' */
                _.Display($"***********************************************");

                /*" -737- DISPLAY ' <<< ERRO NO VG0105S >>> ' */
                _.Display($" <<< ERRO NO VG0105S >>> ");

                /*" -738- DISPLAY ' RET-COD  <' W77-RETURN '>' */

                $" RET-COD  <{W77_RETURN}>"
                .Display();

                /*" -739- DISPLAY ' IND_ERRO <' W77-IND-ERRO '>' */

                $" IND_ERRO <{W77_IND_ERRO}>"
                .Display();

                /*" -740- DISPLAY ' SQLCODE  <' W77-SQLCODE '>' */

                $" SQLCODE  <{W77_SQLCODE}>"
                .Display();

                /*" -741- DISPLAY ' MENSAGEM <' W77-MENSAGEM(01:60) '>' */

                $" MENSAGEM <{W77_MENSAGEM.Substring(1, 60)}>"
                .Display();

                /*" -742- DISPLAY '          <' W77-MENSAGEM(61:60) '>' */

                $"          <{W77_MENSAGEM.Substring(61, 60)}>"
                .Display();

                /*" -743- DISPLAY ' ERRMC    <' W77-SQLERRMC '>' */

                $" ERRMC    <{W77_SQLERRMC}>"
                .Display();

                /*" -744- DISPLAY '***********************************************' */
                _.Display($"***********************************************");

                /*" -745- DISPLAY ' ' */
                _.Display($" ");

                /*" -746- DISPLAY '--------------------------------------------' */
                _.Display($"--------------------------------------------");

                /*" -747- DISPLAY '          PARAMETROS INFORMADOS' */
                _.Display($"          PARAMETROS INFORMADOS");

                /*" -749- DISPLAY '--------------------------------------------' */
                _.Display($"--------------------------------------------");

                /*" -750- DISPLAY 'NRO. DO PLANO         <' W77-NUM-PLANO '>' */

                $"NRO. DO PLANO         <{W77_NUM_PLANO}>"
                .Display();

                /*" -751- DISPLAY 'NRO. DA SERIE         <' W77-NUM-SERIE '>' */

                $"NRO. DA SERIE         <{W77_NUM_SERIE}>"
                .Display();

                /*" -752- DISPLAY 'NRO. DO TITULO        <' W77-NUM-TITULO '>' */

                $"NRO. DO TITULO        <{W77_NUM_TITULO}>"
                .Display();

                /*" -753- DISPLAY 'NRO. DA PROPOSTA      <' W77-NUM-PROPOSTA '>' */

                $"NRO. DA PROPOSTA      <{W77_NUM_PROPOSTA}>"
                .Display();

                /*" -754- DISPLAY 'QUANTIDADE DE TITULOS <' W77-QTD-TITULO '>' */

                $"QUANTIDADE DE TITULOS <{W77_QTD_TITULO}>"
                .Display();

                /*" -755- DISPLAY 'VALOR DO TITULO       <' W77-VLR-TITULO '>' */

                $"VALOR DO TITULO       <{W77_VLR_TITULO}>"
                .Display();

                /*" -756- DISPLAY 'EMPRESA PARCEIRA      <' W77-EMP-PARCEIRA '>' */

                $"EMPRESA PARCEIRA      <{W77_EMP_PARCEIRA}>"
                .Display();

                /*" -757- DISPLAY 'CODIGO RAMO           <' W77-COD-RAMO '>' */

                $"CODIGO RAMO           <{W77_COD_RAMO}>"
                .Display();

                /*" -758- DISPLAY 'CODIGO USUARIO        <' W77-COD-USUARIO '>' */

                $"CODIGO USUARIO        <{W77_COD_USUARIO}>"
                .Display();

                /*" -759- DISPLAY 'LK-NUM-NSA            <' W77-NUM-NSA '>' */

                $"LK-NUM-NSA            <{W77_NUM_NSA}>"
                .Display();

                /*" -760- DISPLAY 'TRACE                 <' LK-TRACE '>' */

                $"TRACE                 <{LK_TRACE}>"
                .Display();

                /*" -761- DISPLAY '--------------------------------------------' */
                _.Display($"--------------------------------------------");

                /*" -763- END-IF */
            }


            /*" -765- IF LK-TRACE-ON */

            if (LK_TRACE["LK_TRACE_ON"])
            {

                /*" -766- IF W77-SQLCODE EQUAL ZEROS */

                if (W77_SQLCODE == 00)
                {

                    /*" -767- DISPLAY '==> MSG RET. <' W77-MENSAGEM '>' */

                    $"==> MSG RET. <{W77_MENSAGEM}>"
                    .Display();

                    /*" -769- END-IF */
                }


                /*" -776- DISPLAY '*** VG0105S TERMINOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) ' ***' */

                $"*** VG0105S TERMINOU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss} ***"
                .Display();

                /*" -777- DISPLAY ' ' */
                _.Display($" ");

                /*" -779- END-IF */
            }


            /*" -779- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P010_SAIDA*/
    }
}