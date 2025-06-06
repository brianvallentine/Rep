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
using Sias.Sinistro.DB2.SI0211B;

namespace Code
{
    public class SI0211B
    {
        public bool IsCall { get; set; }

        public SI0211B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *================================================================*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SINISTRO / RESSARCIMENTO           *      */
        /*"      *   PROGRAMA ...............  SI0211B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  HEIDER / EDUARDO (PRODEXTER)       *      */
        /*"      *   PROGRAMADOR ............  HEIDER / EDUARDO (PRODEXTER)       *      */
        /*"      *   DATA CODIFICACAO .......  MARCO  / 2004                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO ....... PROGRAMA RESPONSAVEL PELA BAIXA DA PARCELAS   *      */
        /*"      *          DE RESSARCIMENTO RECEBIDAS PELA COBRANCA PF0002B      *      */
        /*"      *                                                                *      */
        /*"      *   SI0211B - BAIXA DE RECEBIMENTO DA COBRANCA                   *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 017                                                  *      */
        /*"      * MOTIVO  : CORRIGIR TRATAMENTO V.012. ESTA IGNORANDO PAGAMENTOS *      */
        /*"      *           RESWEB IDENTIFICADOS, BEM COMO A PRE-LIBERA��O DE    *      */
        /*"      *           HONORARIOS CORRESPONDENTES.                          *      */
        /*"      * TAREFA  : 568800                                               *      */
        /*"      * DATA    : 19/01/2024                                           *      */
        /*"      * NOME    : HERVAL SOUZA                                         *      */
        /*"      * MARCADOR: V.17                                                 *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 016                                                  *      */
        /*"      * MOTIVO  : REATIVER ATUALIZACAO DO AVISOS_SALDO                 *      */
        /*"      *           CORRIGIDO O PF2002B, QUE ESTAVA GRAVANDO ERRADO      *      */
        /*"      * TAREFA  : 255615                                               *      */
        /*"      * DATA    : 27/08/2020                                           *      */
        /*"      * NOME    : HERVAL SOUZA                                         *      */
        /*"      * MARCADOR: V.16                                                 *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 015                                                  *      */
        /*"      * MOTIVO  : INIBIR A ATUALIZACAO DO AVISOS_SALDO                        */
        /*"      *           ALGUM PROGRAMA DEIXOU DE CRIAR OS AVISOS_SALDO E            */
        /*"      *           AVISOS_SALDO. PORVAVEIS PF0002B OU PF2002B                  */
        /*"      * CADMUS  : 183269                                                      */
        /*"      * DATA    : 07/08/2020                                           *      */
        /*"      * NOME    : HEIDER COELHO                                        *      */
        /*"      * MARCADOR: V.15                                                 *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 014                                                  *      */
        /*"      * MOTIVO  : ABEND DA ROTINA JPSID13                                     */
        /*"      *           O RESSARCIMENTO DA CAIXA CONSORCIO COMECOU A SER FEITO      */
        /*"      *           POR EMISSAO, PAGAMENTO E BAIXA DE BOLETO                    */
        /*"      *         # PRODUTO: 4813 QUEBRA DE GARANTIA - IMOBILI�RIO              */
        /*"      *         # NAO TEM PAGAMENTO DE HONORARIO MAS SERA CRIADA A            */
        /*"      *           PRE-LIBERACAO CANCELADA.                                    */
        /*"      *         # O PRESTADOR DE SERVICO SERA A CAIXA CONSORCIO,              */
        /*"      *           INDEPENDENTE DO CODIGO QUE ESTIVER NO CAMPO                 */
        /*"      *           SI_RESSARC_PARCELA.COD_FORNECEDOR                           */
        /*"      *         # NAO TEM REPASSE E NAO SERA CRIADA A OCORRENCIA              */
        /*"      * CADMUS  : 179362                                                      */
        /*"      * DATA    : 20/12/2019                                           *      */
        /*"      * NOME    : HEIDER COELHO                                        *      */
        /*"      * MARCADOR: V.14                                                 *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 013                                                  *      */
        /*"      * MOTIVO  : ERRO IMPREVISTO NA IDENTIFICACAO DA OPERACAO         *      */
        /*"      * CADMUS  : 173329                                               *      */
        /*"      * DATA    : 01/03/2019                                           *      */
        /*"      * NOME    : DIOGO MATHEUS                                        *      */
        /*"      * MARCADOR: V.13                                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 012 - HEIDER COELHO - 08/01/2019                     *      */
        /*"      *                                                                *      */
        /*"      *     OS PRODUTOS 4813_4814_4815_4816_4817_6008_6009             *      */
        /*"      *     PARA ESTES PRODUTOS NAO SERA GERADO A PRE-LIBERACAO REPASSE*      */
        /*"      *     APENAS O ESTORNO.                                          *      */
        /*"      *                                                                *      */
        /*"      *     ESTES PRODUTOS NAO TEM REPASSE PARA A CAIXA.               *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 011                                                  *      */
        /*"      * MOTIVO  : ERRO SQLCODE 100                                     *      */
        /*"      * CADMUS  : 169109                                              *       */
        /*"      * DATA    : 21/09/2018                                           *      */
        /*"      * NOME    : DIOGO MATHEUS                                        *      */
        /*"      * MARCADOR: V.11                                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 010                                                  *      */
        /*"      * MOTIVO  : ERRO SQLCODE -305                                    *      */
        /*"      * CADMUS  : 144858                                               *      */
        /*"      * DATA    : 05/12/2016                                           *      */
        /*"      * NOME    : DIOGO MATHEUS                                        *      */
        /*"      * MARCADOR: V.10                                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *    CADMUS  80080 - GUILHERME CORREIA - 19/03/2013              *      */
        /*"      *                                                                *      */
        /*"      *            RESSARCIMENTO ENVIADO PELA SULAMERICA DO PRODUTO    *      */
        /*"      *            AUTO NAO ESTAVA SENDO TRATADO PELO PROGRAMA         *      */
        /*"      *                                                                *      */
        /*"      *            RESSARCIMENTO RETORNA DO SAP PELA ROTINA JPGETH06   *      */
        /*"      *            E O SISTEMA NAO ESTAVA PREVENDO ESTA OPERACAO, POIS *      */
        /*"      *            NAO ERA UTILIZADA ANTERIORMENTE PARA O PRODUTO AUTO *      */
        /*"      *                                                                *      */
        /*"      *            NOVO CEDENTE FOI INCLUIDO NO PROGRAMA EM8007B E A   *      */
        /*"      *            GRAVACAO NAS BASES DO SINISTRO FEITAS POR ESTE      *      */
        /*"      *            PROGRAMA PARA O RESSARCIMENTO ENVIADO PELA SAS      *      */
        /*"      *            FORAM REVISTAS.                                     *      */
        /*"      *                                                                *      */
        /*"      *                                          PROCURAR V.09         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 27/11/2008 INCLUIR WITH UR (SEGUROS.SINISTRO_HABIT01) - WV1108 *      */
        /*"      * 27/11/2008 RETIRAR WITH UR (C_SINISHIS)               - WV1108 *      */
        /*"      * 27/11/2008 RETIRAR WITH UR (C.OCORR_HISTORICO)        - WV1108 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.08  * 06/05/2011  - CADMUS 56087                                     *      */
        /*"      *             - BARDUCCO - PROCURAR V.08                         *      */
        /*"      *             - INCLUI COD_OPERACAO = 160 PARA DEFINIR O PERCEN- *      */
        /*"      *               TUAL DE REP�ASSE EM 15%                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.07  * 22/11/2010  - CADMUS 50541                                     *      */
        /*"      *             - SERGIO LORETO - PROCURAR C50541                  *      */
        /*"      *             NAO GERAR PRE-LIBERACAO DE REPASSE A CAIXA, PARA O *      */
        /*"      *             PRODUTO 6009 � QUEBRA DE GARANTIA - IMOBILIARIO    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.06  * V.06 - WILSON BARDUCCO - 04/11/2010 - CADMUS 49974                    */
        /*"      *        BYPASSA COBRAN�A COM COD_OPERACAO 161 (SEM PERCENTUAL DE       */
        /*"      *        REPASSE).                                                      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.05  * V.05 - EDSON MARQUES - CADMUS 34523 - 11/01/2010                      */
        /*"      *  ALTERAR A FORMA DE CALCULO DO HONORARIO DO ACORDO QUE FOI DO         */
        /*"      *  TIPO JUDICIAL                                                        */
        /*"      *----------------------------------------------------------------*      */
        /*"V.04  * V.04 - HEIDER COELHO - CADMUS 31217 - 16/10/2009                      */
        /*"      *  ABEND EM 16/10/2009. O PROGRAMA NAO PERMITE CRIAR O HONORARIO        */
        /*"      *  DE PARA ESCRIT�RIO, NO MOMENTO DA BAIXA, SE EXISTIR ALGUM            */
        /*"      *  MOVIMENTO DE HONORARIO PAGO SEM A RESPECTIVA BAIXA DE PARCELA        */
        /*"      *  (OPERACAO 4100) NO OCORR_HISTORICO.                                  */
        /*"      *  ESTA SITUACAO ERA PREVENTIVA POR CAUSA DA CARGA DO DTVWEB +          */
        /*"      *  A CONDICAO DE QUE NAO PODE TER HONORARIO SEM BAIXA DE PARCELA.       */
        /*"      *  ATENCAO: ESTA PREMISSA NAO E MAIS VERDADEIRA. JA EXISTE HONO-        */
        /*"      *  RARIO PARA ESCRITORIO POR CAUSA DOS ACORDOS JUDICIAIS.               */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.02  * 05/03/2009  - CONTRASTE - GEORGES - PROCURAR POR V.02          *      */
        /*"      *                                                                *      */
        /*"      *     - CASO SEJA RUNOFF, PRIMEIRA INDENIZACAO < '01-01-2005',   *      */
        /*"      *       ATRIBUIR A SITUACAO CONTABIL = 1 (PAGTO A CEF POR CHEQUE)*      */
        /*"      *                                                                *      */
        /*"      *     - NO CASO DE RUNON, PRIMEIRA INDENIZACAO >= '01-01-2005'   *      */
        /*"      *       A SITUACAO CONTABIL PERMANECE 7 (SIACC)                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 04/09/2009 - HEIDER - CADMUS 29300 - PROCURAR - V.03           *      */
        /*"      *              NAO GERAR HONORARIO PARA ACAO JUDICIAL            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 22/04/2005 - PRODEXTER -                                       *      */
        /*"      *              SUBSTITUICAO DA TABELA PARAMETR_OPER_SINI         *      */
        /*"      *              GE_OPERACAO.                                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 15/02/2006 - PRODEXTER -                                       *      */
        /*"      *              GERA PRE-LIBERACAO DE HONORARIO CANCELADA PARA    *      */
        /*"      *              ESCRITORIO DE COBRANCA IGUAL A CAIXA SEGURADORA   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"ME01  * 17/12/2007 - CONTRASTE - EDSON MARQUES                         *      */
        /*"      *            - PROCURAR POR - ME01                               *      */
        /*"      *            - INCLUSAO DE PARAGRAFO QUE TRABALHA COM PERCENTUAL *      */
        /*"      *            - HONORARIO, O MESMO ESTA INCLUSO NO R6200 E        *      */
        /*"      *            - FOI COPIADO DO PROGRAMA SI0210B.                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"ME02  * 03/04/2008 - CONTRASTE - EDSON MARQUES                         *      */
        /*"      *            - PROCURAR POR - ME02                               *      */
        /*"      *            - INCLUSAO DO SINCREIN-COD-OPERACAO 705             *      */
        /*"      *            - A PEDIDO DO HEIDER QUE ESTA DE FERIAS INCLUIR 705 *      */
        /*"      *            - COM O MESMO VALOR DO REPASSE DO 702."RESOLVE ABEND*      */
        /*"      *----------------------------------------------------------------*      */
        /*"ME03  * 07/04/2008 - CONTRASTE - EDSON MARQUES                         *      */
        /*"      *            - PROCURAR POR ME03                                 *      */
        /*"      *            - AJUSTE PAGAMENTO DE HONORARIO TROCANDO NO CALCULO *      */
        /*"      *            - A VARIAVEL W-PERC-COMISSAO-HON-PADRAO-01 = 20%    *      */
        /*"      *            - PELA       W-PERC-COMISSAO-HON-PADRAO-02 = 10%    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"ME04  * 08/04/2008 - EDSON CONTRASTE                                   *      */
        /*"      *            - SINISTROS AJUIZADOS TERAO OS PAGAMENTOS DE HONORA-*      */
        /*"      *            - RIOS PAGOS MANUALMENTE PELA GEREA EM FORMA DE     *      */
        /*"      *            - DESPESA .                                         *      */
        /*"      *            - MEDIADA PALIATIVA ATE A INTEGRACAO SIAS X SISWEB  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"GE01  * 08/04/2008  - POLITEC - GEORGES DA MATA CLAESSEN               *      */
        /*"      *             - VERIFICAR SE A PARCELA BAIXADA �                 *      */
        /*"      *               REFERENTE AO ULTIMO ACORDO DE RESSARCIMENTO.     *      */
        /*"      *               SE NAO FOR, SERA ENVIADO PARA FOLLOW UP          *      */
        /*"      *               PARA DECISAO DO USUARIO DO SISTEMA DE            *      */
        /*"      *               RESSARCIMENTO                                    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO PELA FAST COMPUTER EM 09/2008                        *      */
        /*"      * DEMANDA DA GEFAB/CAIXA SEGUROS                                 *      */
        /*"      * MUDAR A SIT_CONTABIL = '5' PARA SIT_CONTABIL = '7' DA TABELA   *      */
        /*"      * SINISTRO_HISTORICO                                             *      */
        /*"      * SSI/CADMUS = 13008                                             *      */
        /*"      * PROCURAR POR V.01                                              *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *    PROJETO FGV  (POLITEC)  WELLINGTON VERAS  -  TE39902        *      */
        /*"      *                                                                *      */
        /*"      * 13/06/2008 INIBIR DISPLAY                             - WV0608 *      */
        /*"      * 03/11/2008 INCLUIR WITH UR NO COMANDO SELECT          - WV1108 *      */
        /*"      * 27/11/2008 INCLUIR WITH UR (SEGUROS.SINISTRO_HABIT01) - WV1108 *      */
        /*"      * 27/11/2008 RETIRAR WITH UR (C_SINISHIS)               - WV1108 *      */
        /*"      * 27/11/2008 RETIRAR WITH UR (C.OCORR_HISTORICO)        - WV1108 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *==============================================================*        */
        #endregion


        #region VARIABLES

        public FileBasis _ARQRET { get; set; } = new FileBasis(new PIC("X", "300", "X(300)"));

        public FileBasis ARQRET
        {
            get
            {
                _.Move(REGISTRO_RETORNO, _ARQRET); VarBasis.RedefinePassValue(REGISTRO_RETORNO, _ARQRET, REGISTRO_RETORNO); return _ARQRET;
            }
        }
        /*"01  REGISTRO-RETORNO  PIC X(300).*/
        public StringBasis REGISTRO_RETORNO { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  W-NU-RESSARC-MAX               PIC S9(9) COMP    VALUE 0.*/
        public IntBasis W_NU_RESSARC_MAX { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"77  W-VALOR-LIMITE-TESTE           PIC  9(13)V99 VALUE 0.*/
        public DoubleBasis W_VALOR_LIMITE_TESTE { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
        /*"77  VIND-TIT-SIGCB                 PIC S9(04)    COMP   VALUE +0*/
        public IntBasis VIND_TIT_SIGCB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  VIND-DTH-PAGAMENTO             PIC S9(04)    COMP   VALUE +0*/
        public IntBasis VIND_DTH_PAGAMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  VIND-FOLLOUP-DATA-LIBERACAO    PIC S9(04)    COMP   VALUE +0*/
        public IntBasis VIND_FOLLOUP_DATA_LIBERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HOST-COUNT                     PIC S9(04)    COMP   VALUE +0*/
        public IntBasis HOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HOST-DATA-MOVIMENTO-ABERTO-SI  PIC  X(10) VALUE SPACES.*/
        public StringBasis HOST_DATA_MOVIMENTO_ABERTO_SI { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77  HOST-DATA-CORRENTE             PIC  X(10) VALUE SPACES.*/
        public StringBasis HOST_DATA_CORRENTE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77  HOST-SIT-REGISTRO              PIC  X(01) VALUE SPACES.*/
        public StringBasis HOST_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
        /*"77  HOST-MIN-DATA-MOVIMENTO        PIC  X(10) VALUE SPACES.*/
        public StringBasis HOST_MIN_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77  HOST-PCT-OPERACAO              PIC S9(3)V9(5) COMP-3 VALUE 0*/
        public DoubleBasis HOST_PCT_OPERACAO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(5)"), 5);
        /*"77   H-SINISHIS-COD-EMPRESA        PIC S9(09) VALUE +0 COMP.*/
        public IntBasis H_SINISHIS_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77   H-SINISHIS-TIPO-REGISTRO      PIC  X(01) VALUE SPACES.*/
        public StringBasis H_SINISHIS_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
        /*"77   H-SINISHIS-COD-OPERACAO       PIC S9(04) VALUE +0 COMP.*/
        public IntBasis H_SINISHIS_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77   H-SINISHIS-DATA-MOVIMENTO     PIC  X(10) VALUE SPACES.*/
        public StringBasis H_SINISHIS_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77   H-SINISHIS-HORA-OPERACAO      PIC  X(08) VALUE SPACES.*/
        public StringBasis H_SINISHIS_HORA_OPERACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
        /*"77   H-SINISHIS-NOME-FAVORECIDO    PIC  X(40) VALUE SPACES.*/
        public StringBasis H_SINISHIS_NOME_FAVORECIDO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
        /*"77   H-SINISHIS-VAL-OPERACAO       PIC S9(13)V99 VALUE +0 COMP-3*/
        public DoubleBasis H_SINISHIS_VAL_OPERACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77   H-SINISHIS-DATA-LIM-CORRECAO  PIC  X(10) VALUE SPACES.*/
        public StringBasis H_SINISHIS_DATA_LIM_CORRECAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77   H-SINISHIS-TIPO-FAVORECIDO    PIC  X(01) VALUE SPACES.*/
        public StringBasis H_SINISHIS_TIPO_FAVORECIDO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
        /*"77   H-SINISHIS-DATA-NEGOCIADA     PIC  X(10) VALUE SPACES.*/
        public StringBasis H_SINISHIS_DATA_NEGOCIADA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77   H-SINISHIS-FONTE-PAGAMENTO    PIC S9(04) VALUE +0 COMP.*/
        public IntBasis H_SINISHIS_FONTE_PAGAMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77   H-SINISHIS-COD-PREST-SERVICO  PIC S9(09) VALUE +0 COMP.*/
        public IntBasis H_SINISHIS_COD_PREST_SERVICO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77   H-SINISHIS-COD-SERVICO        PIC S9(04) VALUE +0 COMP.*/
        public IntBasis H_SINISHIS_COD_SERVICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77   H-SINISHIS-ORDEM-PAGAMENTO    PIC S9(09) VALUE +0 COMP.*/
        public IntBasis H_SINISHIS_ORDEM_PAGAMENTO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77   H-SINISHIS-NUM-RECIBO         PIC S9(09) VALUE +0 COMP.*/
        public IntBasis H_SINISHIS_NUM_RECIBO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77   H-SINISHIS-NUM-MOV-SINISTRO   PIC S9(09) VALUE +0 COMP.*/
        public IntBasis H_SINISHIS_NUM_MOV_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77   H-SINISHIS-COD-USUARIO        PIC  X(08) VALUE SPACES.*/
        public StringBasis H_SINISHIS_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
        /*"77   H-SINISHIS-SIT-CONTABIL       PIC  X(01) VALUE SPACES.*/
        public StringBasis H_SINISHIS_SIT_CONTABIL { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
        /*"77   H-SINISHIS-SIT-REGISTRO       PIC  X(01) VALUE SPACES.*/
        public StringBasis H_SINISHIS_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
        /*"77   H-SINISHIS-NUM-APOLICE        PIC S9(13) VALUE +0 COMP-3.*/
        public IntBasis H_SINISHIS_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77   H-SINISHIS-COD-PRODUTO        PIC S9(04) VALUE +0 COMP.*/
        public IntBasis H_SINISHIS_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77   H-SINISHIS-TIMESTAMP          PIC  X(26) VALUE SPACES.*/
        public StringBasis H_SINISHIS_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)"), @"");
        /*"77   HOST-MIN-OCORR-HISTORICO      PIC S9(04) VALUE +0 COMP.*/
        public IntBasis HOST_MIN_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77   W77-REG-NOK                   PIC 9(009) VALUE ZEROS.*/
        public IntBasis W77_REG_NOK { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01  AREA-DE-WORK.*/
        public SI0211B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SI0211B_AREA_DE_WORK();
        public class SI0211B_AREA_DE_WORK : VarBasis
        {
            /*"  05         AUX-NOME.*/
            public SI0211B_AUX_NOME AUX_NOME { get; set; } = new SI0211B_AUX_NOME();
            public class SI0211B_AUX_NOME : VarBasis
            {
                /*"    10       AUX-DESCR01        PIC  X(015).*/
                public StringBasis AUX_DESCR01 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                /*"    10       AUX-DESCR02        PIC  X(015).*/
                public StringBasis AUX_DESCR02 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                /*"    10       AUX-DTVEN-DD       PIC  9(002).*/
                public IntBasis AUX_DTVEN_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       AUX-DTVEN-01       PIC  X(001).*/
                public StringBasis AUX_DTVEN_01 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       AUX-DTVEN-MM       PIC  9(002).*/
                public IntBasis AUX_DTVEN_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       AUX-DTVEN-02       PIC  X(001).*/
                public StringBasis AUX_DTVEN_02 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       AUX-DTVEN-A1       PIC  9(002).*/
                public IntBasis AUX_DTVEN_A1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       AUX-DTVEN-A2       PIC  9(002).*/
                public IntBasis AUX_DTVEN_A2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WTIME-DAY          PIC  99.99.99.99.*/
            }
            public IntBasis WTIME_DAY { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
            /*"  05         FILLER             REDEFINES      WTIME-DAY.*/
            private _REDEF_SI0211B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_SI0211B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_SI0211B_FILLER_0(); _.Move(WTIME_DAY, _filler_0); VarBasis.RedefinePassValue(WTIME_DAY, _filler_0, WTIME_DAY); _filler_0.ValueChanged += () => { _.Move(_filler_0, WTIME_DAY); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WTIME_DAY); }
            }  //Redefines
            public class _REDEF_SI0211B_FILLER_0 : VarBasis
            {
                /*"    10       WTIME-DAYR.*/
                public SI0211B_WTIME_DAYR WTIME_DAYR { get; set; } = new SI0211B_WTIME_DAYR();
                public class SI0211B_WTIME_DAYR : VarBasis
                {
                    /*"      15     WTIME-HORA         PIC  9(002).*/
                    public IntBasis WTIME_HORA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      15     WTIME-2PT1         PIC  X(001).*/
                    public StringBasis WTIME_2PT1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15     WTIME-MINU         PIC  9(002).*/
                    public IntBasis WTIME_MINU { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      15     WTIME-2PT2         PIC  X(001).*/
                    public StringBasis WTIME_2PT2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15     WTIME-SEGU         PIC  9(002).*/
                    public IntBasis WTIME_SEGU { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    10       WTIME-2PT3         PIC  X(001).*/

                    public SI0211B_WTIME_DAYR()
                    {
                        WTIME_HORA.ValueChanged += OnValueChanged;
                        WTIME_2PT1.ValueChanged += OnValueChanged;
                        WTIME_MINU.ValueChanged += OnValueChanged;
                        WTIME_2PT2.ValueChanged += OnValueChanged;
                        WTIME_SEGU.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis WTIME_2PT3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WTIME-CCSE         PIC  X(002).*/
                public StringBasis WTIME_CCSE { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"  05         WS-TIME.*/

                public _REDEF_SI0211B_FILLER_0()
                {
                    WTIME_DAYR.ValueChanged += OnValueChanged;
                    WTIME_2PT3.ValueChanged += OnValueChanged;
                    WTIME_CCSE.ValueChanged += OnValueChanged;
                }

            }
            public SI0211B_WS_TIME WS_TIME { get; set; } = new SI0211B_WS_TIME();
            public class SI0211B_WS_TIME : VarBasis
            {
                /*"      10     WS-HH-TIME         PIC  9(002).*/
                public IntBasis WS_HH_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-MM-TIME         PIC  9(002).*/
                public IntBasis WS_MM_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-SS-TIME         PIC  9(002).*/
                public IntBasis WS_SS_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-CC-TIME         PIC  9(002).*/
                public IntBasis WS_CC_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05   AC-DUPLICA               PIC  9(007)    VALUE ZEROS.*/
            }
            public IntBasis AC_DUPLICA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05   WS-TEM-HONORARIO         PIC X(001) VALUE SPACES.*/
            public StringBasis WS_TEM_HONORARIO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05 W-EDICAO                      PIC ZZZ.ZZZ.ZZ9.*/
            public IntBasis W_EDICAO { get; set; } = new IntBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9."));
            /*"    05 WFIM-COBRANCA                 PIC X(03) VALUE 'NAO'.*/
            public StringBasis WFIM_COBRANCA { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    05 WFIM-SINISHIS                 PIC X(03) VALUE 'NAO'.*/
            public StringBasis WFIM_SINISHIS { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    05 W-CHAVE-CRITICA               PIC X(03)    VALUE 'NAO'.*/
            public StringBasis W_CHAVE_CRITICA { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    05 W-CHAVE-PARCELA-JA-BAIXADA    PIC X(03)    VALUE 'NAO'.*/
            public StringBasis W_CHAVE_PARCELA_JA_BAIXADA { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    05 W-CHAVE-ACHOU-PARCELA         PIC X(03)    VALUE 'NAO'.*/
            public StringBasis W_CHAVE_ACHOU_PARCELA { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    05 W-CHAVE-GRAVA-FOLLOWUP        PIC X(03)    VALUE 'NAO'.*/
            public StringBasis W_CHAVE_GRAVA_FOLLOWUP { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    05 W-CHAVE-ACORDO-CANCELADO      PIC X(03)    VALUE 'NAO'.*/
            public StringBasis W_CHAVE_ACORDO_CANCELADO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    05 W-CHAVE-CREDITO-INTERNO       PIC X(03)    VALUE 'NAO'.*/
            public StringBasis W_CHAVE_CREDITO_INTERNO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    05 WTEM-PAGTO-MAO-GRANDE         PIC X(03)    VALUE 'NAO'.*/
            public StringBasis WTEM_PAGTO_MAO_GRANDE { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    05 W-DATA-ANTERIOR               PIC X(10)    VALUE ' '.*/
            public StringBasis W_DATA_ANTERIOR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @" ");
            /*"    05 W-ULTIMO-COMMIT               PIC 9(09)    VALUE ZEROS.*/
            public IntBasis W_ULTIMO_COMMIT { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"    05 W-TOTAL-COMMIT                PIC 9(09)    VALUE ZEROS.*/
            public IntBasis W_TOTAL_COMMIT { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"    05 W-SALVA-SINISTRO             PIC S9(13) COMP-3 VALUE 0.*/
            public IntBasis W_SALVA_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
            /*"    05 W-TOTAL-PARCELA              PIC S9(13)V99 COMP-3 VALUE 0*/
            public DoubleBasis W_TOTAL_PARCELA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 W-VAL-COMISSAO-HONORARIO     PIC S9(13)V99 COMP-3 VALUE 0*/
            public DoubleBasis W_VAL_COMISSAO_HONORARIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 HOST-VALOR-PAGTO-HON-REPASSE PIC S9(13)V99 COMP-3 VALUE 0*/
            public DoubleBasis HOST_VALOR_PAGTO_HON_REPASSE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 W-VAL-REPASSE                PIC S9(13)V99 COMP-3 VALUE 0*/
            public DoubleBasis W_VAL_REPASSE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 W-VALOR-MINIMO-BAIXA         PIC S9(13)V99 COMP-3 VALUE 0*/
            public DoubleBasis W_VALOR_MINIMO_BAIXA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 W-VALOR-ACRESCIMO            PIC S9(13)V99 COMP-3 VALUE 0*/
            public DoubleBasis W_VALOR_ACRESCIMO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 W-VALOR-DESCONTO             PIC S9(13)V99 COMP-3 VALUE 0*/
            public DoubleBasis W_VALOR_DESCONTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 W-VALOR-PROVISAO             PIC S9(13)V99 COMP-3 VALUE 0*/
            public DoubleBasis W_VALOR_PROVISAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 W-NUM-APOL-SINISTRO          PIC 9(013)  VALUE ZEROS.*/
            public IntBasis W_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"    05 W-NUM-ACORDO                 PIC 9(013)  VALUE ZEROS.*/
            public IntBasis W_NUM_ACORDO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"    05 W-NUMERO-SINISTRO-NUM.*/
            public SI0211B_W_NUMERO_SINISTRO_NUM W_NUMERO_SINISTRO_NUM { get; set; } = new SI0211B_W_NUMERO_SINISTRO_NUM();
            public class SI0211B_W_NUMERO_SINISTRO_NUM : VarBasis
            {
                /*"       10 W-ORGAO-SINISTRO          PIC  9(03)     VALUE 0.*/
                public IntBasis W_ORGAO_SINISTRO { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
                /*"       10 W-RAMO-SINISTRO           PIC  9(02)     VALUE 0.*/
                public IntBasis W_RAMO_SINISTRO { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       10 W-NUM-SINISTRO            PIC  9(08)     VALUE 0.*/
                public IntBasis W_NUM_SINISTRO { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
                /*"    05 W-LIDOS-TIPO-01               PIC 9(09)    VALUE ZEROS.*/
            }
            public IntBasis W_LIDOS_TIPO_01 { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"    05 W-LIDOS-TIPO-02               PIC 9(09)    VALUE ZEROS.*/
            public IntBasis W_LIDOS_TIPO_02 { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"    05 W-REG-GRAV-RETORNO            PIC 9(06)    VALUE ZEROS.*/
            public IntBasis W_REG_GRAV_RETORNO { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
            /*"    05 W-REJEITADOS                  PIC 9(09)    VALUE ZEROS.*/
            public IntBasis W_REJEITADOS { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"    05 W-AVISADOS-SEM-ALTERACAO      PIC 9(09)    VALUE ZEROS.*/
            public IntBasis W_AVISADOS_SEM_ALTERACAO { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"    05 W-AVISADOS-COM-ALTERACAO      PIC 9(13)V99 VALUE ZEROS.*/
            public DoubleBasis W_AVISADOS_COM_ALTERACAO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
            /*"    05 W-CONTA-SINISTRO              PIC 9(08)    VALUE ZEROS.*/
            public IntBasis W_CONTA_SINISTRO { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05 W-QTD-MOVIMENTO-COBRANCA      PIC 9(08)    VALUE ZEROS.*/
            public IntBasis W_QTD_MOVIMENTO_COBRANCA { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05 W-QTD-PARCELAS-BAIXADAS       PIC 9(08)    VALUE ZEROS.*/
            public IntBasis W_QTD_PARCELAS_BAIXADAS { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05 W-QTD-FOLLOWUP                PIC 9(08)    VALUE ZEROS.*/
            public IntBasis W_QTD_FOLLOWUP { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05 W-SINISTRO-ANT                PIC 9(13)    VALUE ZEROS.*/
            public IntBasis W_SINISTRO_ANT { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
            /*"    05 W-ACORDO-ANT                  PIC 9(13)    VALUE ZEROS.*/
            public IntBasis W_ACORDO_ANT { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
            /*"    05 W-SUREG-ANT                   PIC 9(05)    VALUE ZEROS.*/
            public IntBasis W_SUREG_ANT { get; set; } = new IntBasis(new PIC("9", "5", "9(05)"));
            /*"    05 W-AGENCIA-ANT                 PIC 9(04)    VALUE ZEROS.*/
            public IntBasis W_AGENCIA_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
            /*"    05 W-OPERACAO-ANT                PIC 9(04)    VALUE ZEROS.*/
            public IntBasis W_OPERACAO_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
            /*"    05 W-CONTRATO-ANT                PIC 9(13)    VALUE ZEROS.*/
            public IntBasis W_CONTRATO_ANT { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
            /*"    05 W-DIGITO-ANT                  PIC 9(02)    VALUE ZEROS.*/
            public IntBasis W_DIGITO_ANT { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
            /*"    05 W-TEXTO-NOMFAV.*/
            public SI0211B_W_TEXTO_NOMFAV W_TEXTO_NOMFAV { get; set; } = new SI0211B_W_TEXTO_NOMFAV();
            public class SI0211B_W_TEXTO_NOMFAV : VarBasis
            {
                /*"       10 W-TEXTO-NOMFAV-TEXTO       PIC X(37) VALUE SPACES.*/
                public StringBasis W_TEXTO_NOMFAV_TEXTO { get; set; } = new StringBasis(new PIC("X", "37", "X(37)"), @"");
                /*"       10 W-TEXTO-NOMFAV-PARCELA     PIC 9(03) VALUE ZEROS.*/
                public IntBasis W_TEXTO_NOMFAV_PARCELA { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
                /*"    05 W-TEXTO-NOMFAV-CAIXA.*/
            }
            public SI0211B_W_TEXTO_NOMFAV_CAIXA W_TEXTO_NOMFAV_CAIXA { get; set; } = new SI0211B_W_TEXTO_NOMFAV_CAIXA();
            public class SI0211B_W_TEXTO_NOMFAV_CAIXA : VarBasis
            {
                /*"       10 W-TEXTO-NOMFAV-TEXTO-CAIXA PIC X(24) VALUE SPACES.*/
                public StringBasis W_TEXTO_NOMFAV_TEXTO_CAIXA { get; set; } = new StringBasis(new PIC("X", "24", "X(24)"), @"");
                /*"       10 FILLER                     PIC X(40) VALUE          '/ REPASSE CAIXA '.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"/ REPASSE CAIXA ");
                /*"    05 W-CONTA-PAGINA                PIC 9(07)    VALUE ZEROS.*/
            }
            public IntBasis W_CONTA_PAGINA { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
            /*"    05 W-CONTA-LINHA                 PIC 9(02)    VALUE 90.*/
            public IntBasis W_CONTA_LINHA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"), 90);
            /*"    05 W-CONTA-PAGINA-AVISOOK        PIC 9(07)    VALUE ZEROS.*/
            public IntBasis W_CONTA_PAGINA_AVISOOK { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
            /*"    05 W-CONTA-LINHA-AVISOOK         PIC 9(02)    VALUE 90.*/
            public IntBasis W_CONTA_LINHA_AVISOOK { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"), 90);
            /*"    05 W-DATA-CORRENTE.*/
            public SI0211B_W_DATA_CORRENTE W_DATA_CORRENTE { get; set; } = new SI0211B_W_DATA_CORRENTE();
            public class SI0211B_W_DATA_CORRENTE : VarBasis
            {
                /*"       15 W-DATA-CORRENTE-ANO        PIC 9(04)       VALUE ZEROS*/
                public IntBasis W_DATA_CORRENTE_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"       15 W-DATA-CORRENTE-FILLER-1   PIC X(01)       VALUE ZEROS*/
                public StringBasis W_DATA_CORRENTE_FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"       15 W-DATA-CORRENTE-MES        PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_DATA_CORRENTE_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       15 W-DATA-CORRENTE-FILLER-2   PIC X(01)       VALUE ZEROS*/
                public StringBasis W_DATA_CORRENTE_FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"       15 W-DATA-CORRENTE-DIA        PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_DATA_CORRENTE_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    05 W-HORA-CORRENTE.*/
            }
            public SI0211B_W_HORA_CORRENTE W_HORA_CORRENTE { get; set; } = new SI0211B_W_HORA_CORRENTE();
            public class SI0211B_W_HORA_CORRENTE : VarBasis
            {
                /*"       15 W-HORA-CORRENTE-ANO        PIC 9(04)       VALUE ZEROS*/
                public IntBasis W_HORA_CORRENTE_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"       15 W-HORA-CORRENTE-FILLER-1   PIC X(01)       VALUE ZEROS*/
                public StringBasis W_HORA_CORRENTE_FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"       15 W-HORA-CORRENTE-MES        PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_HORA_CORRENTE_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       15 W-HORA-CORRENTE-FILLER-2   PIC X(01)       VALUE ZEROS*/
                public StringBasis W_HORA_CORRENTE_FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"       15 W-HORA-CORRENTE-DIA        PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_HORA_CORRENTE_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    05 W-HORA-HH-MM-SS.*/
            }
            public SI0211B_W_HORA_HH_MM_SS W_HORA_HH_MM_SS { get; set; } = new SI0211B_W_HORA_HH_MM_SS();
            public class SI0211B_W_HORA_HH_MM_SS : VarBasis
            {
                /*"       15 W-HORA-HH-MM-SS-HH         PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_HORA_HH_MM_SS_HH { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       15 FILLER                     PIC X(01)       VALUE '.'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @".");
                /*"       15 W-HORA-HH-MM-SS-MM         PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_HORA_HH_MM_SS_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       15 FILLER                     PIC X(01)       VALUE '.'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @".");
                /*"       15 W-HORA-HH-MM-SS-SS         PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_HORA_HH_MM_SS_SS { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    05 W-HORA-HHMM.*/
            }
            public SI0211B_W_HORA_HHMM W_HORA_HHMM { get; set; } = new SI0211B_W_HORA_HHMM();
            public class SI0211B_W_HORA_HHMM : VarBasis
            {
                /*"       15 W-HORA-HHMM-HH             PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_HORA_HHMM_HH { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       15 W-HORA-HHMM-MM             PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_HORA_HHMM_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    05 W-DATA-AAAAMMDD.*/
            }
            public SI0211B_W_DATA_AAAAMMDD W_DATA_AAAAMMDD { get; set; } = new SI0211B_W_DATA_AAAAMMDD();
            public class SI0211B_W_DATA_AAAAMMDD : VarBasis
            {
                /*"       10 W-DATA-AAAAMMDD-AAAA       PIC 9(04)       VALUE ZEROS*/
                public IntBasis W_DATA_AAAAMMDD_AAAA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"       10 W-DATA-AAAAMMDD-MM         PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_DATA_AAAAMMDD_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       10 W-DATA-AAAAMMDD-DD         PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_DATA_AAAAMMDD_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    05 W-DATA-DD-MM-AAAA.*/
            }
            public SI0211B_W_DATA_DD_MM_AAAA W_DATA_DD_MM_AAAA { get; set; } = new SI0211B_W_DATA_DD_MM_AAAA();
            public class SI0211B_W_DATA_DD_MM_AAAA : VarBasis
            {
                /*"       10 W-DATA-DD-MM-AAAA-DD       PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_DATA_DD_MM_AAAA_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       10 FILLER                     PIC X(01)       VALUE '/'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"       10 W-DATA-DD-MM-AAAA-MM       PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_DATA_DD_MM_AAAA_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       10 FILLER                     PIC X(01)       VALUE '/'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"       10 W-DATA-DD-MM-AAAA-AAAA     PIC 9(04)       VALUE ZEROS*/
                public IntBasis W_DATA_DD_MM_AAAA_AAAA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"    05 W-DATA-AAAA-MM-DD.*/
            }
            public SI0211B_W_DATA_AAAA_MM_DD W_DATA_AAAA_MM_DD { get; set; } = new SI0211B_W_DATA_AAAA_MM_DD();
            public class SI0211B_W_DATA_AAAA_MM_DD : VarBasis
            {
                /*"       10 W-DATA-AAAA-MM-DD-AAAA     PIC 9(04)       VALUE ZEROS*/
                public IntBasis W_DATA_AAAA_MM_DD_AAAA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"       10 FILLER                     PIC X(01)       VALUE '-'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       10 W-DATA-AAAA-MM-DD-MM       PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_DATA_AAAA_MM_DD_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       10 FILLER                     PIC X(01)       VALUE '-'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       10 W-DATA-AAAA-MM-DD-DD       PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_DATA_AAAA_MM_DD_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    05 W-VALOR-LIMITE-01             PIC  9(13)V99 VALUE 0.*/
            }
            public DoubleBasis W_VALOR_LIMITE_01 { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
            /*"    05 W-PERC-COMISSAO-HON-PADRAO-01 PIC  9(03)V99 VALUE 0.*/
            public DoubleBasis W_PERC_COMISSAO_HON_PADRAO_01 { get; set; } = new DoubleBasis(new PIC("9", "3", "9(03)V99"), 2);
            /*"    05 W-PERC-COMISSAO-HON-PADRAO-02 PIC  9(03)V99 VALUE 0.*/
            public DoubleBasis W_PERC_COMISSAO_HON_PADRAO_02 { get; set; } = new DoubleBasis(new PIC("9", "3", "9(03)V99"), 2);
            /*"    05 W-PERC-COMISSAO-DES-PADRAO-01 PIC  9(03)V99 VALUE 0.*/
            public DoubleBasis W_PERC_COMISSAO_DES_PADRAO_01 { get; set; } = new DoubleBasis(new PIC("9", "3", "9(03)V99"), 2);
            /*"    05 W-PERCENTUAL-REPASSE          PIC  9(03)V99 VALUE 0.*/
            public DoubleBasis W_PERCENTUAL_REPASSE { get; set; } = new DoubleBasis(new PIC("9", "3", "9(03)V99"), 2);
            /*"    05 W-OPERACAO-CONTRATO           PIC S9(04)   COMP   VALUE 0*/
            public IntBasis W_OPERACAO_CONTRATO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 W-PERC-REPASSE                PIC  9(03)V9(04)   VALUE 0.*/
            public DoubleBasis W_PERC_REPASSE { get; set; } = new DoubleBasis(new PIC("9", "3", "9(03)V9(04)"), 4);
            /*"    05 W-PERC-HONORARIO              PIC  9(03)V99 VALUE 0.*/
            public DoubleBasis W_PERC_HONORARIO { get; set; } = new DoubleBasis(new PIC("9", "3", "9(03)V99"), 2);
            /*"    05 W-PERC-HONORARIO-FINAL        PIC  9(03)V99 VALUE 0.*/
            public DoubleBasis W_PERC_HONORARIO_FINAL { get; set; } = new DoubleBasis(new PIC("9", "3", "9(03)V99"), 2);
            /*"    05 W-VAL-PERC-VAL-LIMITE-01      PIC S9(13)V99 VALUE 0.*/
            public DoubleBasis W_VAL_PERC_VAL_LIMITE_01 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 W-VAL-EXCEDENTE-LIMITE        PIC S9(13)V99 VALUE 0.*/
            public DoubleBasis W_VAL_EXCEDENTE_LIMITE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 W-VAL-PERC-VAL-LIMITE-02      PIC S9(13)V99 VALUE 0.*/
            public DoubleBasis W_VAL_PERC_VAL_LIMITE_02 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 W-VAL-TOTAL-DEVIDO-COMISSAO   PIC S9(13)V99 VALUE 0.*/
            public DoubleBasis W_VAL_TOTAL_DEVIDO_COMISSAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 LC01.*/
            public SI0211B_LC01 LC01 { get; set; } = new SI0211B_LC01();
            public class SI0211B_LC01 : VarBasis
            {
                /*"       10 LC01-TIPO-ARQUIVO          PIC X(02) VALUE '02'.*/
                public StringBasis LC01_TIPO_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"02");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LC01-TIPO-REGISTRO         PIC X(01) VALUE 'C'.*/
                public StringBasis LC01_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"C");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LC01-RELATORIO             PIC X(10) VALUE          'SI0211B - '.*/
                public StringBasis LC01_RELATORIO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"SI0211B - ");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LC01-EMPRESA               PIC X(40) VALUE  SPACES.*/
                public StringBasis LC01_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    05 LC02.*/
            }
            public SI0211B_LC02 LC02 { get; set; } = new SI0211B_LC02();
            public class SI0211B_LC02 : VarBasis
            {
                /*"       10 LC02-TIPO-ARQUIVO          PIC X(02) VALUE '02'.*/
                public StringBasis LC02_TIPO_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"02");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LC02-TIPO-REGISTRO         PIC X(01) VALUE 'C'.*/
                public StringBasis LC02_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"C");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(19)  VALUE          'DATA SISTEMA (SI): '.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "19", "X(19)"), @"DATA SISTEMA (SI): ");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LC02-DATA-SISTEMA          PIC X(10)   VALUE SPACES.*/
                public StringBasis LC02_DATA_SISTEMA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    05 LC03.*/
            }
            public SI0211B_LC03 LC03 { get; set; } = new SI0211B_LC03();
            public class SI0211B_LC03 : VarBasis
            {
                /*"       10 LC03-TIPO-ARQUIVO          PIC X(02) VALUE '02'.*/
                public StringBasis LC03_TIPO_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"02");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LC03-TIPO-REGISTRO         PIC X(01) VALUE 'C'.*/
                public StringBasis LC03_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"C");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(15)  VALUE          'DATA CORRENTE: '.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"DATA CORRENTE: ");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LC03-DATA-CORRENTE         PIC X(10)   VALUE SPACES.*/
                public StringBasis LC03_DATA_CORRENTE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"    05 LC04.*/
            }
            public SI0211B_LC04 LC04 { get; set; } = new SI0211B_LC04();
            public class SI0211B_LC04 : VarBasis
            {
                /*"       10 LC04-TIPO-ARQUIVO          PIC X(02) VALUE '02'.*/
                public StringBasis LC04_TIPO_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"02");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LC04-TIPO-REGISTRO         PIC X(01) VALUE 'C'.*/
                public StringBasis LC04_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"C");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(51) VALUE         'RELATORIO DE PROCESSAMENTO - BAIXA DE PARCELAS'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)"), @"RELATORIO DE PROCESSAMENTO - BAIXA DE PARCELAS");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    05 LC05.*/
            }
            public SI0211B_LC05 LC05 { get; set; } = new SI0211B_LC05();
            public class SI0211B_LC05 : VarBasis
            {
                /*"       10 LC05-TIPO-ARQUIVO          PIC X(02) VALUE '02'.*/
                public StringBasis LC05_TIPO_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"02");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LC05-TIPO-REGISTRO         PIC X(01) VALUE 'C'.*/
                public StringBasis LC05_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"C");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(08) VALUE          'SINISTRO'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"SINISTRO");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(06) VALUE          'ACORDO'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"ACORDO");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(07) VALUE          'PARCELA'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"PARCELA");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(06) VALUE          'TITULO'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"TITULO");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(14) VALUE          'DT. VENCIMENTO'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"DT. VENCIMENTO");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(14) VALUE          'VALOR RECEBIDO'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"VALOR RECEBIDO");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(14) VALUE          'DATA PAGAMENTO'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"DATA PAGAMENTO");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(18) VALUE          'DATA PROCESSAMENTO'.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "18", "X(18)"), @"DATA PROCESSAMENTO");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(16) VALUE          'INDICADOR ORIGEM'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"INDICADOR ORIGEM");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(12) VALUE          'TEXTO ORIGEM'.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"TEXTO ORIGEM");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(18) VALUE          'IND. TIPO DE BAIXA'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "18", "X(18)"), @"IND. TIPO DE BAIXA");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(20) VALUE          'TEXTO TIPO DE BAIXA'.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"TEXTO TIPO DE BAIXA");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(15) VALUE          'INDICADOR BAIXA'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"INDICADOR BAIXA");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(20) VALUE          'MENSAGEM DE BAIXA'.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"MENSAGEM DE BAIXA");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    05 LD01.*/
            }
            public SI0211B_LD01 LD01 { get; set; } = new SI0211B_LD01();
            public class SI0211B_LD01 : VarBasis
            {
                /*"       10 LD01-TIPO-ARQUIVO          PIC X(02) VALUE '02'.*/
                public StringBasis LD01_TIPO_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"02");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LD01-TIPO-REGISTRO         PIC X(01) VALUE 'D'.*/
                public StringBasis LD01_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"D");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LD01-NUM-APOL-SINISTRO     PIC 9(13) VALUE ZEROS.*/
                public IntBasis LD01_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LD01-NUM-ACORDO            PIC 9(13) VALUE ZEROS.*/
                public IntBasis LD01_NUM_ACORDO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LD01-NUM-PARCELA           PIC 9(05) VALUE ZEROS.*/
                public IntBasis LD01_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "5", "9(05)"));
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LD01-NUM-TITULO            PIC 9(16) VALUE ZEROS.*/
                public IntBasis LD01_NUM_TITULO { get; set; } = new IntBasis(new PIC("9", "16", "9(16)"));
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LD01-DATA-VENCIMENTO       PIC X(10) VALUE SPACES.*/
                public StringBasis LD01_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LD01-VALOR-RECEBIDO        PIC ---.---.--9,99.*/
                public DoubleBasis LD01_VALOR_RECEBIDO { get; set; } = new DoubleBasis(new PIC("9", "9", "---.---.--9V99."), 2);
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LD01-DATA-PAGAMENTO        PIC X(10) VALUE SPACES.*/
                public StringBasis LD01_DATA_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LD01-DATA-PROCESSAMENTO    PIC X(10) VALUE SPACES.*/
                public StringBasis LD01_DATA_PROCESSAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LD01-IND-ORIGEM            PIC X(01) VALUE SPACES.*/
                public StringBasis LD01_IND_ORIGEM { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LD01-MSG-ORIGEM            PIC X(30) VALUE SPACES.*/
                public StringBasis LD01_MSG_ORIGEM { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LD01-IND-TIPO-BAIXA        PIC X(01) VALUE SPACES.*/
                public StringBasis LD01_IND_TIPO_BAIXA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LD01-TIPO-BAIXA            PIC X(20) VALUE SPACES.*/
                public StringBasis LD01_TIPO_BAIXA { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LD01-IND-PROCESSAMENTO     PIC X(01) VALUE SPACES.*/
                public StringBasis LD01_IND_PROCESSAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LD01-MENSAGEM              PIC X(100) VALUE SPACES.*/
                public StringBasis LD01_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "100", "X(100)"), @"");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    05 LC99-NAO-TEVE-MOVIMENTO.*/
            }
            public SI0211B_LC99_NAO_TEVE_MOVIMENTO LC99_NAO_TEVE_MOVIMENTO { get; set; } = new SI0211B_LC99_NAO_TEVE_MOVIMENTO();
            public class SI0211B_LC99_NAO_TEVE_MOVIMENTO : VarBasis
            {
                /*"       10 LC99-TIPO-ARQUIVO          PIC X(02) VALUE '02'.*/
                public StringBasis LC99_TIPO_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"02");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LC99-TIPO-REGISTRO         PIC X(01) VALUE 'C'.*/
                public StringBasis LC99_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"C");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(80) VALUE         'NENHUMA BAIXA FOI SELECIONADA PARA PROCESSAMENTO'.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"NENHUMA BAIXA FOI SELECIONADA PARA PROCESSAMENTO");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    05 LC-FIM.*/
            }
            public SI0211B_LC_FIM LC_FIM { get; set; } = new SI0211B_LC_FIM();
            public class SI0211B_LC_FIM : VarBasis
            {
                /*"       10 LCFIM-TIPO-ARQUIVO         PIC X(02) VALUE '02'.*/
                public StringBasis LCFIM_TIPO_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"02");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 LC04-TIPO-REGISTRO         PIC X(01) VALUE 'F'.*/
                public StringBasis LC04_TIPO_REGISTRO_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"F");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       10 FILLER                     PIC X(14) VALUE         'FIM DE ARQUIVO'.*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"FIM DE ARQUIVO");
                /*"       10 FILLER                     PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    05 WABEND.*/
            }
            public SI0211B_WABEND WABEND { get; set; } = new SI0211B_WABEND();
            public class SI0211B_WABEND : VarBasis
            {
                /*"       07 WABEND1.*/
                public SI0211B_WABEND1 WABEND1 { get; set; } = new SI0211B_WABEND1();
                public class SI0211B_WABEND1 : VarBasis
                {
                    /*"       10 FILLER         PIC  X(008)      VALUE          'SI0211B '.*/
                    public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"SI0211B ");
                    /*"       07 WABEND2.*/
                    public SI0211B_WABEND2 WABEND2 { get; set; } = new SI0211B_WABEND2();
                    public class SI0211B_WABEND2 : VarBasis
                    {
                        /*"       10 FILLER         PIC  X(025)      VALUE          '*** ERRO EXEC SQL NUMERO '.*/
                        public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"*** ERRO EXEC SQL NUMERO ");
                        /*"       10 WNR-EXEC-SQL   PIC  X(004)      VALUE   '0000'.*/
                        public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                        /*"       07 WABEND3.*/
                        public SI0211B_WABEND3 WABEND3 { get; set; } = new SI0211B_WABEND3();
                        public class SI0211B_WABEND3 : VarBasis
                        {
                            /*"       10 FILLER         PIC  X(013)      VALUE          ' *** SQLCODE '.*/
                            public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                            /*"       10 WSQLCODE       PIC  ZZZZZ999-   VALUE    ZEROS.*/
                            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                            /*"       10 WSQLERRMC      PIC  X(40)      VALUE    SPACES.*/
                            public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                            /*"       10 WSQLCAID     PIC X(8).*/
                            public StringBasis WSQLCAID { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
                            /*"       10 WSQLCABC     PIC S9(9) COMP-4.*/
                            public IntBasis WSQLCABC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
                            /*"       10 WSQLERRP     PIC X(8).*/
                            public StringBasis WSQLERRP { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
                            /*"       10 WSQLWARN.*/
                            public SI0211B_WSQLWARN WSQLWARN { get; set; } = new SI0211B_WSQLWARN();
                            public class SI0211B_WSQLWARN : VarBasis
                            {
                                /*"          15 WSQLWARN0 PIC X.*/
                                public StringBasis WSQLWARN0 { get; set; } = new StringBasis(new PIC("X", "1", "X."), @"");
                                /*"          15 WSQLWARN1 PIC X.*/
                                public StringBasis WSQLWARN1 { get; set; } = new StringBasis(new PIC("X", "1", "X."), @"");
                                /*"          15 WSQLWARN2 PIC X.*/
                                public StringBasis WSQLWARN2 { get; set; } = new StringBasis(new PIC("X", "1", "X."), @"");
                                /*"          15 WSQLWARN3 PIC X.*/
                                public StringBasis WSQLWARN3 { get; set; } = new StringBasis(new PIC("X", "1", "X."), @"");
                                /*"          15 WSQLWARN4 PIC X.*/
                                public StringBasis WSQLWARN4 { get; set; } = new StringBasis(new PIC("X", "1", "X."), @"");
                                /*"          15 WSQLWARN5 PIC X.*/
                                public StringBasis WSQLWARN5 { get; set; } = new StringBasis(new PIC("X", "1", "X."), @"");
                                /*"01          LK-LINK.*/
                            }
                        }
                    }
                }
                public SI0211B_LK_LINK LK_LINK { get; set; } = new SI0211B_LK_LINK();
                public class SI0211B_LK_LINK : VarBasis
                {
                    /*"  03        LK-RTCODE           PIC  S9(004)   VALUE +0   COMP.*/
                    public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                    /*"  03        LK-TAMANHO          PIC  S9(004)   VALUE +40  COMP.*/
                    public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +40);
                    /*"  03        LK-TITULO           PIC   X(132)   VALUE  SPACES.*/
                    public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
                }
            }
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.AVISOSAL AVISOSAL { get; set; } = new Dclgens.AVISOSAL();
        public Dclgens.FOLLOUP FOLLOUP { get; set; } = new Dclgens.FOLLOUP();
        public Dclgens.EMPRESAS EMPRESAS { get; set; } = new Dclgens.EMPRESAS();
        public Dclgens.MOVIMCOB MOVIMCOB { get; set; } = new Dclgens.MOVIMCOB();
        public Dclgens.FORNECED FORNECED { get; set; } = new Dclgens.FORNECED();
        public Dclgens.GE284 GE284 { get; set; } = new Dclgens.GE284();
        public Dclgens.SINIHAB1 SINIHAB1 { get; set; } = new Dclgens.SINIHAB1();
        public Dclgens.SI111 SI111 { get; set; } = new Dclgens.SI111();
        public Dclgens.SI112 SI112 { get; set; } = new Dclgens.SI112();
        public Dclgens.SINCREIN SINCREIN { get; set; } = new Dclgens.SINCREIN();
        public Dclgens.CALENDAR CALENDAR { get; set; } = new Dclgens.CALENDAR();
        public Dclgens.GEOPERAC GEOPERAC { get; set; } = new Dclgens.GEOPERAC();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.SISINCHE SISINCHE { get; set; } = new Dclgens.SISINCHE();
        public Dclgens.SIPADOFI SIPADOFI { get; set; } = new Dclgens.SIPADOFI();
        public Dclgens.RALCHEDO RALCHEDO { get; set; } = new Dclgens.RALCHEDO();
        public SI0211B_COBRANCA COBRANCA { get; set; } = new SI0211B_COBRANCA();
        public SI0211B_C_SINISHIS C_SINISHIS { get; set; } = new SI0211B_C_SINISHIS();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string ARQRET_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                ARQRET.SetFile(ARQRET_FILE_NAME_P);

                /*" -718- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -719- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -720- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -730- DISPLAY 'SI0211B - VERSAO 17 Alterado em: ' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) ' AS ' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) ' ***' */

                $"SI0211B - VERSAO 17 Alterado em: FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)} AS FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)} ***"
                .Display();

                /*" -731- DISPLAY 'SI0211B - BAIXA DE PARCELAS DE RESSARCIMENTO' */
                _.Display($"SI0211B - BAIXA DE PARCELAS DE RESSARCIMENTO");

                /*" -732- DISPLAY ' ' */
                _.Display($" ");

                /*" -733- DISPLAY 'ROTINA  : JPSID13' */
                _.Display($"ROTINA  : JPSID13");

                /*" -735- OPEN OUTPUT ARQRET. */
                ARQRET.Open(REGISTRO_RETORNO);

                /*" -767- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

                /*" -769- PERFORM R010-LE-SISTEMAS THRU R010-EXIT. */

                R010_LE_SISTEMAS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_EXIT*/


                /*" -771- PERFORM R015-LE-MONTA-NOME-EMPRESA THRU R015-EXIT. */

                R015_LE_MONTA_NOME_EMPRESA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R015_EXIT*/


                /*" -772- WRITE REGISTRO-RETORNO FROM LC01. */
                _.Move(AREA_DE_WORK.LC01.GetMoveValues(), REGISTRO_RETORNO);

                ARQRET.Write(REGISTRO_RETORNO.GetMoveValues().ToString());

                /*" -773- WRITE REGISTRO-RETORNO FROM LC02. */
                _.Move(AREA_DE_WORK.LC02.GetMoveValues(), REGISTRO_RETORNO);

                ARQRET.Write(REGISTRO_RETORNO.GetMoveValues().ToString());

                /*" -774- WRITE REGISTRO-RETORNO FROM LC03. */
                _.Move(AREA_DE_WORK.LC03.GetMoveValues(), REGISTRO_RETORNO);

                ARQRET.Write(REGISTRO_RETORNO.GetMoveValues().ToString());

                /*" -775- WRITE REGISTRO-RETORNO FROM LC04. */
                _.Move(AREA_DE_WORK.LC04.GetMoveValues(), REGISTRO_RETORNO);

                ARQRET.Write(REGISTRO_RETORNO.GetMoveValues().ToString());

                /*" -777- WRITE REGISTRO-RETORNO FROM LC05. */
                _.Move(AREA_DE_WORK.LC05.GetMoveValues(), REGISTRO_RETORNO);

                ARQRET.Write(REGISTRO_RETORNO.GetMoveValues().ToString());

                /*" -778- MOVE 'NAO' TO WFIM-COBRANCA. */
                _.Move("NAO", AREA_DE_WORK.WFIM_COBRANCA);

                /*" -779- PERFORM R020-LE-COBRANCA THRU R020-EXIT. */

                R020_LE_COBRANCA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R020_EXIT*/


                /*" -791- PERFORM R021-FETCH-COBRANCA THRU R021-EXIT. */

                R021_FETCH_COBRANCA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R021_EXIT*/


                /*" -792- IF WFIM-COBRANCA EQUAL 'SIM' */

                if (AREA_DE_WORK.WFIM_COBRANCA == "SIM")
                {

                    /*" -794- WRITE REGISTRO-RETORNO FROM LC99-NAO-TEVE-MOVIMENTO. */
                    _.Move(AREA_DE_WORK.LC99_NAO_TEVE_MOVIMENTO.GetMoveValues(), REGISTRO_RETORNO);

                    ARQRET.Write(REGISTRO_RETORNO.GetMoveValues().ToString());
                }


                /*" -797- PERFORM R100-PROCESSA-COBRANCA THRU R100-EXIT UNTIL WFIM-COBRANCA EQUAL 'SIM' . */

                while (!(AREA_DE_WORK.WFIM_COBRANCA == "SIM"))
                {

                    R100_PROCESSA_COBRANCA(true);

                    R100_CONTINUA1(true);

                    R100_LE_NOVO_TITULO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/

                }

                /*" -799- WRITE REGISTRO-RETORNO FROM LC-FIM. */
                _.Move(AREA_DE_WORK.LC_FIM.GetMoveValues(), REGISTRO_RETORNO);

                ARQRET.Write(REGISTRO_RETORNO.GetMoveValues().ToString());

                /*" -800- MOVE W-QTD-MOVIMENTO-COBRANCA TO W-EDICAO */
                _.Move(AREA_DE_WORK.W_QTD_MOVIMENTO_COBRANCA, AREA_DE_WORK.W_EDICAO);

                /*" -802- DISPLAY 'QTD. MOVIMENTO_COBRANCA SELECIONADAS.......' W-EDICAO. */
                _.Display($"QTD. MOVIMENTO_COBRANCA SELECIONADAS.......{AREA_DE_WORK.W_EDICAO}");

                /*" -803- MOVE W-QTD-PARCELAS-BAIXADAS TO W-EDICAO */
                _.Move(AREA_DE_WORK.W_QTD_PARCELAS_BAIXADAS, AREA_DE_WORK.W_EDICAO);

                /*" -805- DISPLAY 'QTD. DE PARCELAS BAIXADAS .................' W-EDICAO. */
                _.Display($"QTD. DE PARCELAS BAIXADAS .................{AREA_DE_WORK.W_EDICAO}");

                /*" -806- MOVE W-QTD-FOLLOWUP TO W-EDICAO */
                _.Move(AREA_DE_WORK.W_QTD_FOLLOWUP, AREA_DE_WORK.W_EDICAO);

                /*" -809- DISPLAY 'QTD. DE PARCELAS EM FOLLOW-UP .............' W-EDICAO. */
                _.Display($"QTD. DE PARCELAS EM FOLLOW-UP .............{AREA_DE_WORK.W_EDICAO}");

                /*" -810- MOVE W77-REG-NOK TO W-EDICAO */
                _.Move(W77_REG_NOK, AREA_DE_WORK.W_EDICAO);

                /*" -813- DISPLAY 'COBRANCAS IGNORADAS P/ COD_COBRANCA = 161 .' W-EDICAO */
                _.Display($"COBRANCAS IGNORADAS P/ COD_COBRANCA = 161 .{AREA_DE_WORK.W_EDICAO}");

                /*" -818- MOVE W-VALOR-LIMITE-TESTE TO W-EDICAO. */
                _.Move(W_VALOR_LIMITE_TESTE, AREA_DE_WORK.W_EDICAO);

                /*" -820- CLOSE ARQRET. */
                ARQRET.Close();

                /*" -821- DISPLAY ' ' . */
                _.Display($" ");

                /*" -822- DISPLAY '*************************************' . */
                _.Display($"*************************************");

                /*" -823- DISPLAY '*                                   *' . */
                _.Display($"*                                   *");

                /*" -824- DISPLAY '*           SI0211B                 *' . */
                _.Display($"*           SI0211B                 *");

                /*" -825- DISPLAY '*                                   *' . */
                _.Display($"*                                   *");

                /*" -826- DISPLAY '*  TERMINO NORMAL DE PROCESSAMENTO  *' . */
                _.Display($"*  TERMINO NORMAL DE PROCESSAMENTO  *");

                /*" -827- DISPLAY '*                                   *' . */
                _.Display($"*                                   *");

                /*" -829- DISPLAY '*************************************' . */
                _.Display($"*************************************");

                /*" -829- EXEC SQL COMMIT WORK END-EXEC. */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -832- MOVE ZEROS TO RETURN-CODE. */
                _.Move(0, RETURN_CODE);

                /*" -832- STOP RUN. */

                throw new GoBack();   // => STOP RUN.

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R010-LE-SISTEMAS */
        private void R010_LE_SISTEMAS(bool isPerform = false)
        {
            /*" -838- MOVE '002' TO WNR-EXEC-SQL. */
            _.Move("002", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -846- PERFORM R010_LE_SISTEMAS_DB_SELECT_1 */

            R010_LE_SISTEMAS_DB_SELECT_1();

            /*" -849- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -850- DISPLAY 'SI0211B - SISTEMA SI NAO CADASTRADO' */
                _.Display($"SI0211B - SISTEMA SI NAO CADASTRADO");

                /*" -852- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -854- MOVE '003' TO WNR-EXEC-SQL. */
            _.Move("003", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -860- PERFORM R010_LE_SISTEMAS_DB_SELECT_2 */

            R010_LE_SISTEMAS_DB_SELECT_2();

            /*" -865- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -866- DISPLAY 'SI0211B - SISTEMA COBRANCA NAO CADASTRADO' */
                _.Display($"SI0211B - SISTEMA COBRANCA NAO CADASTRADO");

                /*" -868- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -870- IF HOST-DATA-MOVIMENTO-ABERTO-SI NOT EQUAL SISTEMAS-DATA-MOV-ABERTO */

            if (HOST_DATA_MOVIMENTO_ABERTO_SI != SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO)
            {

                /*" -871- DISPLAY '*************************************************' */
                _.Display($"*************************************************");

                /*" -872- DISPLAY '*                                                ' */
                _.Display($"*                                                ");

                /*" -873- DISPLAY '* PROGRAMA SI0211B - ABENDADO PELO ANALISTA      ' */
                _.Display($"* PROGRAMA SI0211B - ABENDADO PELO ANALISTA      ");

                /*" -874- DISPLAY '*                                                ' */
                _.Display($"*                                                ");

                /*" -875- DISPLAY '* AS DATAS DOS SISTEMAS SINISTRO E COBRANCA ESTAO' */
                _.Display($"* AS DATAS DOS SISTEMAS SINISTRO E COBRANCA ESTAO");

                /*" -876- DISPLAY '* DIFERENTES. FAVOR AVISAR AO ANALISTA HEIDER    ' */
                _.Display($"* DIFERENTES. FAVOR AVISAR AO ANALISTA HEIDER    ");

                /*" -877- DISPLAY '*                                                ' */
                _.Display($"*                                                ");

                /*" -879- DISPLAY '* DATA SISTEMA SINISTRO = ' HOST-DATA-MOVIMENTO-ABERTO-SI */
                _.Display($"* DATA SISTEMA SINISTRO = {HOST_DATA_MOVIMENTO_ABERTO_SI}");

                /*" -881- DISPLAY '* DATA SISTEMA COBRANCA = ' SISTEMAS-DATA-MOV-ABERTO */
                _.Display($"* DATA SISTEMA COBRANCA = {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

                /*" -883- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -884- DISPLAY ' ' . */
            _.Display($" ");

            /*" -885- DISPLAY 'DATA DO SISTEMA DE SINISTRO (SI)' . */
            _.Display($"DATA DO SISTEMA DE SINISTRO (SI)");

            /*" -890- DISPLAY HOST-DATA-MOVIMENTO-ABERTO-SI(9:2) ' ' HOST-DATA-MOVIMENTO-ABERTO-SI(8:1) ' ' HOST-DATA-MOVIMENTO-ABERTO-SI(6:2) ' ' HOST-DATA-MOVIMENTO-ABERTO-SI(5:1) ' ' HOST-DATA-MOVIMENTO-ABERTO-SI(1:4). */

            $"{HOST_DATA_MOVIMENTO_ABERTO_SI.Substring(9, 2)} {HOST_DATA_MOVIMENTO_ABERTO_SI.Substring(8, 1)} {HOST_DATA_MOVIMENTO_ABERTO_SI.Substring(6, 2)} {HOST_DATA_MOVIMENTO_ABERTO_SI.Substring(5, 1)} {HOST_DATA_MOVIMENTO_ABERTO_SI.Substring(1, 4)}"
            .Display();

            /*" -892- DISPLAY ' ' . */
            _.Display($" ");

            /*" -893- DISPLAY ' ' . */
            _.Display($" ");

            /*" -894- DISPLAY 'DATA DO SISTEMA DE COBRANCA (CO)' . */
            _.Display($"DATA DO SISTEMA DE COBRANCA (CO)");

            /*" -899- DISPLAY SISTEMAS-DATA-MOV-ABERTO(9:2) ' ' SISTEMAS-DATA-MOV-ABERTO(8:1) ' ' SISTEMAS-DATA-MOV-ABERTO(6:2) ' ' SISTEMAS-DATA-MOV-ABERTO(5:1) ' ' SISTEMAS-DATA-MOV-ABERTO(1:4). */

            $"{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2)} {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(8, 1)} {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2)} {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(5, 1)} {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4)}"
            .Display();

            /*" -901- DISPLAY ' ' . */
            _.Display($" ");

            /*" -902- MOVE SISTEMAS-DATA-MOV-ABERTO(9:2) TO W-DATA-DD-MM-AAAA-DD */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2), AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_DD);

            /*" -903- MOVE SISTEMAS-DATA-MOV-ABERTO(6:2) TO W-DATA-DD-MM-AAAA-MM */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2), AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_MM);

            /*" -905- MOVE SISTEMAS-DATA-MOV-ABERTO(1:4) TO W-DATA-DD-MM-AAAA-AAAA */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4), AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_AAAA);

            /*" -907- MOVE W-DATA-DD-MM-AAAA TO LC02-DATA-SISTEMA. */
            _.Move(AREA_DE_WORK.W_DATA_DD_MM_AAAA, AREA_DE_WORK.LC02.LC02_DATA_SISTEMA);

            /*" -908- MOVE HOST-DATA-CORRENTE(9:2) TO W-DATA-DD-MM-AAAA-DD */
            _.Move(HOST_DATA_CORRENTE.Substring(9, 2), AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_DD);

            /*" -909- MOVE HOST-DATA-CORRENTE(6:2) TO W-DATA-DD-MM-AAAA-MM */
            _.Move(HOST_DATA_CORRENTE.Substring(6, 2), AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_MM);

            /*" -911- MOVE HOST-DATA-CORRENTE(1:4) TO W-DATA-DD-MM-AAAA-AAAA. */
            _.Move(HOST_DATA_CORRENTE.Substring(1, 4), AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_AAAA);

            /*" -911- MOVE W-DATA-DD-MM-AAAA TO LC03-DATA-CORRENTE. */
            _.Move(AREA_DE_WORK.W_DATA_DD_MM_AAAA, AREA_DE_WORK.LC03.LC03_DATA_CORRENTE);

        }

        [StopWatch]
        /*" R010-LE-SISTEMAS-DB-SELECT-1 */
        public void R010_LE_SISTEMAS_DB_SELECT_1()
        {
            /*" -846- EXEC SQL SELECT DATA_MOV_ABERTO, CURRENT DATE INTO :HOST-DATA-MOVIMENTO-ABERTO-SI, :HOST-DATA-CORRENTE FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' WITH UR END-EXEC. */

            var r010_LE_SISTEMAS_DB_SELECT_1_Query1 = new R010_LE_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R010_LE_SISTEMAS_DB_SELECT_1_Query1.Execute(r010_LE_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_DATA_MOVIMENTO_ABERTO_SI, HOST_DATA_MOVIMENTO_ABERTO_SI);
                _.Move(executed_1.HOST_DATA_CORRENTE, HOST_DATA_CORRENTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_EXIT*/

        [StopWatch]
        /*" R010-LE-SISTEMAS-DB-SELECT-2 */
        public void R010_LE_SISTEMAS_DB_SELECT_2()
        {
            /*" -860- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'CO' WITH UR END-EXEC. */

            var r010_LE_SISTEMAS_DB_SELECT_2_Query1 = new R010_LE_SISTEMAS_DB_SELECT_2_Query1()
            {
            };

            var executed_1 = R010_LE_SISTEMAS_DB_SELECT_2_Query1.Execute(r010_LE_SISTEMAS_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }

        [StopWatch]
        /*" R015-LE-MONTA-NOME-EMPRESA */
        private void R015_LE_MONTA_NOME_EMPRESA(bool isPerform = false)
        {
            /*" -919- MOVE '004' TO WNR-EXEC-SQL. */
            _.Move("004", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -925- PERFORM R015_LE_MONTA_NOME_EMPRESA_DB_SELECT_1 */

            R015_LE_MONTA_NOME_EMPRESA_DB_SELECT_1();

            /*" -928- MOVE EMPRESAS-NOME-EMPRESA TO LK-TITULO */
            _.Move(EMPRESAS.DCLEMPRESAS.EMPRESAS_NOME_EMPRESA, AREA_DE_WORK.WABEND.LK_LINK.LK_TITULO);

            /*" -930- CALL 'PROALN01' USING LK-LINK */
            _.Call("PROALN01", AREA_DE_WORK.WABEND.LK_LINK);

            /*" -931- IF LK-RTCODE EQUAL ZEROS */

            if (AREA_DE_WORK.WABEND.LK_LINK.LK_RTCODE == 00)
            {

                /*" -932- MOVE LK-TITULO TO LC01-EMPRESA LC01-EMPRESA */
                _.Move(AREA_DE_WORK.WABEND.LK_LINK.LK_TITULO, AREA_DE_WORK.LC01.LC01_EMPRESA, AREA_DE_WORK.LC01.LC01_EMPRESA);

                /*" -933- ELSE */
            }
            else
            {


                /*" -934- DISPLAY 'PROBLEMA CALL V0EMPRESA' */
                _.Display($"PROBLEMA CALL V0EMPRESA");

                /*" -934- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


        }

        [StopWatch]
        /*" R015-LE-MONTA-NOME-EMPRESA-DB-SELECT-1 */
        public void R015_LE_MONTA_NOME_EMPRESA_DB_SELECT_1()
        {
            /*" -925- EXEC SQL SELECT NOME_EMPRESA INTO :EMPRESAS-NOME-EMPRESA FROM SEGUROS.EMPRESAS WHERE COD_EMPRESA = 0 WITH UR END-EXEC. */

            var r015_LE_MONTA_NOME_EMPRESA_DB_SELECT_1_Query1 = new R015_LE_MONTA_NOME_EMPRESA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R015_LE_MONTA_NOME_EMPRESA_DB_SELECT_1_Query1.Execute(r015_LE_MONTA_NOME_EMPRESA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.EMPRESAS_NOME_EMPRESA, EMPRESAS.DCLEMPRESAS.EMPRESAS_NOME_EMPRESA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R015_EXIT*/

        [StopWatch]
        /*" R020-LE-COBRANCA */
        private void R020_LE_COBRANCA(bool isPerform = false)
        {
            /*" -942- MOVE '005' TO WNR-EXEC-SQL. */
            _.Move("005", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -975- PERFORM R020_LE_COBRANCA_DB_DECLARE_1 */

            R020_LE_COBRANCA_DB_DECLARE_1();

            /*" -977- PERFORM R020_LE_COBRANCA_DB_OPEN_1 */

            R020_LE_COBRANCA_DB_OPEN_1();

            /*" -980- IF (SQLCODE < 0) */

            if ((DB.SQLCODE < 0))
            {

                /*" -980- GO TO R10010199-MENSAGEM-LOCK. */

                R10010199_MENSAGEM_LOCK(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R020-LE-COBRANCA-DB-DECLARE-1 */
        public void R020_LE_COBRANCA_DB_DECLARE_1()
        {
            /*" -975- EXEC SQL DECLARE COBRANCA CURSOR FOR SELECT COD_EMPRESA, COD_MOVIMENTO, COD_BANCO, COD_AGENCIA, NUM_AVISO, NUM_FITA, DATA_MOVIMENTO, DATA_QUITACAO, NUM_TITULO, NUM_APOLICE, NUM_ENDOSSO, NUM_PARCELA, VAL_TITULO, VAL_IOCC, VAL_CREDITO, SIT_REGISTRO, TIMESTAMP, NOME_SEGURADO, TIPO_MOVIMENTO, NUM_NOSSO_TITULO FROM SEGUROS.MOVIMENTO_COBRANCA WHERE TIPO_MOVIMENTO = '7' AND SIT_REGISTRO = ' ' ORDER BY NUM_APOLICE, NUM_NOSSO_TITULO END-EXEC. */
            COBRANCA = new SI0211B_COBRANCA(false);
            string GetQuery_COBRANCA()
            {
                var query = @$"SELECT COD_EMPRESA
							, 
							COD_MOVIMENTO
							, 
							COD_BANCO
							, 
							COD_AGENCIA
							, 
							NUM_AVISO
							, 
							NUM_FITA
							, 
							DATA_MOVIMENTO
							, 
							DATA_QUITACAO
							, 
							NUM_TITULO
							, 
							NUM_APOLICE
							, 
							NUM_ENDOSSO
							, 
							NUM_PARCELA
							, 
							VAL_TITULO
							, 
							VAL_IOCC
							, 
							VAL_CREDITO
							, 
							SIT_REGISTRO
							, 
							TIMESTAMP
							, 
							NOME_SEGURADO
							, 
							TIPO_MOVIMENTO
							, 
							NUM_NOSSO_TITULO 
							FROM SEGUROS.MOVIMENTO_COBRANCA 
							WHERE TIPO_MOVIMENTO = '7' 
							AND SIT_REGISTRO = ' ' 
							ORDER BY NUM_APOLICE
							, NUM_NOSSO_TITULO";

                return query;
            }
            COBRANCA.GetQueryEvent += GetQuery_COBRANCA;

        }

        [StopWatch]
        /*" R020-LE-COBRANCA-DB-OPEN-1 */
        public void R020_LE_COBRANCA_DB_OPEN_1()
        {
            /*" -977- EXEC SQL OPEN COBRANCA END-EXEC. */

            COBRANCA.Open();

        }

        [StopWatch]
        /*" R1510-DECLARE-SINISHIS-DB-DECLARE-1 */
        public void R1510_DECLARE_SINISHIS_DB_DECLARE_1()
        {
            /*" -2646- EXEC SQL DECLARE C_SINISHIS CURSOR FOR SELECT A.COD_EMPRESA, A.TIPO_REGISTRO, A.COD_OPERACAO, A.DATA_MOVIMENTO, A.HORA_OPERACAO, A.NOME_FAVORECIDO, A.VAL_OPERACAO, A.DATA_LIM_CORRECAO, A.TIPO_FAVORECIDO, A.DATA_NEGOCIADA, A.FONTE_PAGAMENTO, A.COD_PREST_SERVICO, A.COD_SERVICO, A.ORDEM_PAGAMENTO, A.NUM_RECIBO, A.NUM_MOV_SINISTRO, A.COD_USUARIO, A.SIT_CONTABIL, A.SIT_REGISTRO, A.NUM_APOLICE, A.COD_PRODUTO, A.TIMESTAMP FROM SEGUROS.SINISTRO_HISTORICO A, SEGUROS.GE_OPERACAO B WHERE A.COD_OPERACAO = B.COD_OPERACAO AND B.IDE_SISTEMA = 'SI' AND A.NUM_APOL_SINISTRO = :SI111-NUM-APOL-SINISTRO AND A.OCORR_HISTORICO = :HOST-MIN-OCORR-HISTORICO AND B.IND_TIPO_FUNCAO = (SELECT C.IND_TIPO_FUNCAO FROM SEGUROS.GE_OPERACAO C WHERE C.COD_OPERACAO = :SINISHIS-COD-OPERACAO AND C.IDE_SISTEMA = B.IDE_SISTEMA) ORDER BY A.COD_OPERACAO END-EXEC. */
            C_SINISHIS = new SI0211B_C_SINISHIS(true);
            string GetQuery_C_SINISHIS()
            {
                var query = @$"SELECT A.COD_EMPRESA
							, 
							A.TIPO_REGISTRO
							, 
							A.COD_OPERACAO
							, 
							A.DATA_MOVIMENTO
							, 
							A.HORA_OPERACAO
							, 
							A.NOME_FAVORECIDO
							, 
							A.VAL_OPERACAO
							, 
							A.DATA_LIM_CORRECAO
							, 
							A.TIPO_FAVORECIDO
							, 
							A.DATA_NEGOCIADA
							, 
							A.FONTE_PAGAMENTO
							, 
							A.COD_PREST_SERVICO
							, 
							A.COD_SERVICO
							, 
							A.ORDEM_PAGAMENTO
							, 
							A.NUM_RECIBO
							, 
							A.NUM_MOV_SINISTRO
							, 
							A.COD_USUARIO
							, 
							A.SIT_CONTABIL
							, 
							A.SIT_REGISTRO
							, 
							A.NUM_APOLICE
							, 
							A.COD_PRODUTO
							, 
							A.TIMESTAMP 
							FROM SEGUROS.SINISTRO_HISTORICO A
							, 
							SEGUROS.GE_OPERACAO B 
							WHERE A.COD_OPERACAO = B.COD_OPERACAO 
							AND B.IDE_SISTEMA = 'SI' 
							AND A.NUM_APOL_SINISTRO = '{SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO}' 
							AND A.OCORR_HISTORICO = '{HOST_MIN_OCORR_HISTORICO}' 
							AND B.IND_TIPO_FUNCAO = 
							(SELECT C.IND_TIPO_FUNCAO 
							FROM SEGUROS.GE_OPERACAO C 
							WHERE C.COD_OPERACAO = '{SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO}' 
							AND C.IDE_SISTEMA = B.IDE_SISTEMA) 
							ORDER BY A.COD_OPERACAO";

                return query;
            }
            C_SINISHIS.GetQueryEvent += GetQuery_C_SINISHIS;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R020_EXIT*/

        [StopWatch]
        /*" R021-FETCH-COBRANCA */
        private void R021_FETCH_COBRANCA(bool isPerform = false)
        {
            /*" -988- MOVE '006' TO WNR-EXEC-SQL. */
            _.Move("006", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -1009- PERFORM R021_FETCH_COBRANCA_DB_FETCH_1 */

            R021_FETCH_COBRANCA_DB_FETCH_1();

            /*" -1013- IF (SQLCODE = ZEROS) */

            if ((DB.SQLCODE == 00))
            {

                /*" -1014- ADD 1 TO W-QTD-MOVIMENTO-COBRANCA */
                AREA_DE_WORK.W_QTD_MOVIMENTO_COBRANCA.Value = AREA_DE_WORK.W_QTD_MOVIMENTO_COBRANCA + 1;

                /*" -1016- END-IF. */
            }


            /*" -1017- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1018- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1018- PERFORM R021_FETCH_COBRANCA_DB_CLOSE_1 */

                    R021_FETCH_COBRANCA_DB_CLOSE_1();

                    /*" -1020- MOVE 'SIM' TO WFIM-COBRANCA */
                    _.Move("SIM", AREA_DE_WORK.WFIM_COBRANCA);

                    /*" -1021- ELSE */
                }
                else
                {


                    /*" -1022- DISPLAY 'ERRO NO FETCH DA COBANCA' */
                    _.Display($"ERRO NO FETCH DA COBANCA");

                    /*" -1022- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R021-FETCH-COBRANCA-DB-FETCH-1 */
        public void R021_FETCH_COBRANCA_DB_FETCH_1()
        {
            /*" -1009- EXEC SQL FETCH COBRANCA INTO :MOVIMCOB-COD-EMPRESA, :MOVIMCOB-COD-MOVIMENTO, :MOVIMCOB-COD-BANCO, :MOVIMCOB-COD-AGENCIA, :MOVIMCOB-NUM-AVISO, :MOVIMCOB-NUM-FITA, :MOVIMCOB-DATA-MOVIMENTO, :MOVIMCOB-DATA-QUITACAO, :MOVIMCOB-NUM-TITULO, :MOVIMCOB-NUM-APOLICE, :MOVIMCOB-NUM-ENDOSSO, :MOVIMCOB-NUM-PARCELA, :MOVIMCOB-VAL-TITULO, :MOVIMCOB-VAL-IOCC, :MOVIMCOB-VAL-CREDITO, :MOVIMCOB-SIT-REGISTRO, :MOVIMCOB-TIMESTAMP, :MOVIMCOB-NOME-SEGURADO, :MOVIMCOB-TIPO-MOVIMENTO, :MOVIMCOB-NUM-NOSSO-TITULO END-EXEC. */

            if (COBRANCA.Fetch())
            {
                _.Move(COBRANCA.MOVIMCOB_COD_EMPRESA, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_EMPRESA);
                _.Move(COBRANCA.MOVIMCOB_COD_MOVIMENTO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO);
                _.Move(COBRANCA.MOVIMCOB_COD_BANCO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO);
                _.Move(COBRANCA.MOVIMCOB_COD_AGENCIA, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA);
                _.Move(COBRANCA.MOVIMCOB_NUM_AVISO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO);
                _.Move(COBRANCA.MOVIMCOB_NUM_FITA, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_FITA);
                _.Move(COBRANCA.MOVIMCOB_DATA_MOVIMENTO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_MOVIMENTO);
                _.Move(COBRANCA.MOVIMCOB_DATA_QUITACAO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_QUITACAO);
                _.Move(COBRANCA.MOVIMCOB_NUM_TITULO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_TITULO);
                _.Move(COBRANCA.MOVIMCOB_NUM_APOLICE, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE);
                _.Move(COBRANCA.MOVIMCOB_NUM_ENDOSSO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO);
                _.Move(COBRANCA.MOVIMCOB_NUM_PARCELA, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA);
                _.Move(COBRANCA.MOVIMCOB_VAL_TITULO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO);
                _.Move(COBRANCA.MOVIMCOB_VAL_IOCC, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_IOCC);
                _.Move(COBRANCA.MOVIMCOB_VAL_CREDITO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_CREDITO);
                _.Move(COBRANCA.MOVIMCOB_SIT_REGISTRO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO);
                _.Move(COBRANCA.MOVIMCOB_TIMESTAMP, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_TIMESTAMP);
                _.Move(COBRANCA.MOVIMCOB_NOME_SEGURADO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO);
                _.Move(COBRANCA.MOVIMCOB_TIPO_MOVIMENTO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_TIPO_MOVIMENTO);
                _.Move(COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO);
            }

        }

        [StopWatch]
        /*" R021-FETCH-COBRANCA-DB-CLOSE-1 */
        public void R021_FETCH_COBRANCA_DB_CLOSE_1()
        {
            /*" -1018- EXEC SQL CLOSE COBRANCA END-EXEC */

            COBRANCA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R021_EXIT*/

        [StopWatch]
        /*" R100-PROCESSA-COBRANCA */
        private void R100_PROCESSA_COBRANCA(bool isPerform = false)
        {
            /*" -1031- MOVE 'NAO' TO W-CHAVE-CRITICA W-CHAVE-GRAVA-FOLLOWUP. */
            _.Move("NAO", AREA_DE_WORK.W_CHAVE_CRITICA, AREA_DE_WORK.W_CHAVE_GRAVA_FOLLOWUP);

            /*" -1033- PERFORM R110-ROTINA-CRITICA THRU R110-EXIT */

            R110_ROTINA_CRITICA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R110_EXIT*/


            /*" -1034- IF (W-CHAVE-CRITICA = 'NAO' ) */

            if ((AREA_DE_WORK.W_CHAVE_CRITICA == "NAO"))
            {

                /*" -1035- MOVE '007' TO WNR-EXEC-SQL */
                _.Move("007", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

                /*" -1041- PERFORM R100_PROCESSA_COBRANCA_DB_SELECT_1 */

                R100_PROCESSA_COBRANCA_DB_SELECT_1();

                /*" -1068- END-IF. */
            }


        }

        [StopWatch]
        /*" R100-PROCESSA-COBRANCA-DB-SELECT-1 */
        public void R100_PROCESSA_COBRANCA_DB_SELECT_1()
        {
            /*" -1041- EXEC SQL SELECT COD_OPERACAO INTO :SINCREIN-COD-OPERACAO FROM SEGUROS.SINISTRO_CRED_INT WHERE NUM_APOL_SINISTRO = :SI111-NUM-APOL-SINISTRO WITH UR END-EXEC */

            var r100_PROCESSA_COBRANCA_DB_SELECT_1_Query1 = new R100_PROCESSA_COBRANCA_DB_SELECT_1_Query1()
            {
                SI111_NUM_APOL_SINISTRO = SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R100_PROCESSA_COBRANCA_DB_SELECT_1_Query1.Execute(r100_PROCESSA_COBRANCA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINCREIN_COD_OPERACAO, SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_OPERACAO);
            }


        }

        [StopWatch]
        /*" R100-CONTINUA1 */
        private void R100_CONTINUA1(bool isPerform = false)
        {
            /*" -1074- IF W-CHAVE-CRITICA EQUAL 'SIM' OR W-CHAVE-GRAVA-FOLLOWUP EQUAL 'SIM' */

            if (AREA_DE_WORK.W_CHAVE_CRITICA == "SIM" || AREA_DE_WORK.W_CHAVE_GRAVA_FOLLOWUP == "SIM")
            {

                /*" -1075- MOVE '2' TO HOST-SIT-REGISTRO */
                _.Move("2", HOST_SIT_REGISTRO);

                /*" -1076- MOVE '008' TO WNR-EXEC-SQL */
                _.Move("008", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

                /*" -1078- PERFORM R1300-UPDATE-COBRANCA THRU R1300-EXIT. */

                R1300_UPDATE_COBRANCA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_EXIT*/

            }


            /*" -1079- IF W-CHAVE-GRAVA-FOLLOWUP EQUAL 'SIM' */

            if (AREA_DE_WORK.W_CHAVE_GRAVA_FOLLOWUP == "SIM")
            {

                /*" -1080- MOVE ZEROS TO AC-DUPLICA */
                _.Move(0, AREA_DE_WORK.AC_DUPLICA);

                /*" -1081- PERFORM R10000-GRAVA-FOLLOWUP THRU R10000-EXIT */

                R10000_GRAVA_FOLLOWUP(true);

                R10000_INSERT(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R10000_EXIT*/


                /*" -1083- GO TO R100-LE-NOVO-TITULO. */

                R100_LE_NOVO_TITULO(); //GOTO
                return;
            }


            /*" -1084- IF W-CHAVE-CRITICA EQUAL 'SIM' */

            if (AREA_DE_WORK.W_CHAVE_CRITICA == "SIM")
            {

                /*" -1086- GO TO R100-LE-NOVO-TITULO. */

                R100_LE_NOVO_TITULO(); //GOTO
                return;
            }


            /*" -1088- PERFORM R1000-GRAVA-RECEBIMENTO THRU R1000-EXIT */

            R1000_GRAVA_RECEBIMENTO(true);

            R6200_HONORARIO_JUDICIAL(true);

            R1000_REPASSE(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_PULA_REPASSE*/

            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_EXIT*/


            /*" -1089- MOVE '1' TO HOST-SIT-REGISTRO */
            _.Move("1", HOST_SIT_REGISTRO);

            /*" -1090- MOVE '009' TO WNR-EXEC-SQL. */
            _.Move("009", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -1096- PERFORM R1300-UPDATE-COBRANCA THRU R1300-EXIT. */

            R1300_UPDATE_COBRANCA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_EXIT*/


            /*" -1098- IF (MOVIMCOB-VAL-TITULO >= W-VALOR-MINIMO-BAIXA) AND (MOVIMCOB-VAL-TITULO < W-VALOR-PROVISAO) */

            if ((MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO >= AREA_DE_WORK.W_VALOR_MINIMO_BAIXA) && (MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO < AREA_DE_WORK.W_VALOR_PROVISAO))
            {

                /*" -1100- MOVE 'BAIXA EFETUADA. COM DIFERENCA A MENOR DE ATE 5,00' TO LD01-MENSAGEM */
                _.Move("BAIXA EFETUADA. COM DIFERENCA A MENOR DE ATE 5,00", AREA_DE_WORK.LD01.LD01_MENSAGEM);

                /*" -1101- ELSE */
            }
            else
            {


                /*" -1103- MOVE 'BAIXA EFETUADA. COM SUCESSO' TO LD01-MENSAGEM */
                _.Move("BAIXA EFETUADA. COM SUCESSO", AREA_DE_WORK.LD01.LD01_MENSAGEM);

                /*" -1105- END-IF. */
            }


            /*" -1106- MOVE '0' TO LD01-IND-PROCESSAMENTO */
            _.Move("0", AREA_DE_WORK.LD01.LD01_IND_PROCESSAMENTO);

            /*" -1106- PERFORM R120-GRAVA-ARQ-SAIDA THRU R120-EXIT. */

            R120_GRAVA_ARQ_SAIDA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


        }

        [StopWatch]
        /*" R100-LE-NOVO-TITULO */
        private void R100_LE_NOVO_TITULO(bool isPerform = false)
        {
            /*" -1110- PERFORM R021-FETCH-COBRANCA THRU R021-EXIT. */

            R021_FETCH_COBRANCA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R021_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/

        [StopWatch]
        /*" R110-ROTINA-CRITICA */
        private void R110_ROTINA_CRITICA(bool isPerform = false)
        {
            /*" -1117- MOVE 'NAO' TO W-CHAVE-ACHOU-PARCELA. */
            _.Move("NAO", AREA_DE_WORK.W_CHAVE_ACHOU_PARCELA);

            /*" -1118- MOVE 'NAO' TO W-CHAVE-PARCELA-JA-BAIXADA. */
            _.Move("NAO", AREA_DE_WORK.W_CHAVE_PARCELA_JA_BAIXADA);

            /*" -1132- MOVE 'NAO' TO W-CHAVE-ACORDO-CANCELADO. */
            _.Move("NAO", AREA_DE_WORK.W_CHAVE_ACORDO_CANCELADO);

            /*" -1133- MOVE ' ' TO FOLLOUP-COD-ERRO01 */
            _.Move(" ", FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_ERRO01);

            /*" -1134- MOVE ' ' TO FOLLOUP-COD-ERRO02 */
            _.Move(" ", FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_ERRO02);

            /*" -1135- MOVE ' ' TO FOLLOUP-COD-ERRO03 */
            _.Move(" ", FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_ERRO03);

            /*" -1136- MOVE ' ' TO FOLLOUP-COD-ERRO04 */
            _.Move(" ", FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_ERRO04);

            /*" -1137- MOVE ' ' TO FOLLOUP-COD-ERRO05 */
            _.Move(" ", FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_ERRO05);

            /*" -1139- MOVE ' ' TO FOLLOUP-COD-ERRO06 */
            _.Move(" ", FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_ERRO06);

            /*" -1141- PERFORM R130-LER-PARCELA THRU R130-EXIT */

            R130_LER_PARCELA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R130_EXIT*/


            /*" -1142- IF (W-CHAVE-ACHOU-PARCELA = 'NAO' ) */

            if ((AREA_DE_WORK.W_CHAVE_ACHOU_PARCELA == "NAO"))
            {

                /*" -1143- MOVE '1' TO LD01-IND-PROCESSAMENTO */
                _.Move("1", AREA_DE_WORK.LD01.LD01_IND_PROCESSAMENTO);

                /*" -1145- MOVE 'PARCELA NAO ENCONTRADA - FOI PARA FOLLOWUP' TO LD01-MENSAGEM */
                _.Move("PARCELA NAO ENCONTRADA - FOI PARA FOLLOWUP", AREA_DE_WORK.LD01.LD01_MENSAGEM);

                /*" -1146- PERFORM R120-GRAVA-ARQ-SAIDA THRU R120-EXIT */

                R120_GRAVA_ARQ_SAIDA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -1147- MOVE 'SIM' TO W-CHAVE-CRITICA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                /*" -1148- MOVE 'SIM' TO W-CHAVE-GRAVA-FOLLOWUP */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_GRAVA_FOLLOWUP);

                /*" -1149- MOVE '1' TO FOLLOUP-COD-ERRO01 */
                _.Move("1", FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_ERRO01);

                /*" -1150- GO TO R110-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R110_EXIT*/ //GOTO
                return;

                /*" -1152- END-IF. */
            }


            /*" -1153- IF (W-CHAVE-PARCELA-JA-BAIXADA = 'SIM' ) */

            if ((AREA_DE_WORK.W_CHAVE_PARCELA_JA_BAIXADA == "SIM"))
            {

                /*" -1154- MOVE '1' TO LD01-IND-PROCESSAMENTO */
                _.Move("1", AREA_DE_WORK.LD01.LD01_IND_PROCESSAMENTO);

                /*" -1156- MOVE 'PARCELA JA ENCONTRA-SE BAIXADA' TO LD01-MENSAGEM */
                _.Move("PARCELA JA ENCONTRA-SE BAIXADA", AREA_DE_WORK.LD01.LD01_MENSAGEM);

                /*" -1157- PERFORM R120-GRAVA-ARQ-SAIDA THRU R120-EXIT */

                R120_GRAVA_ARQ_SAIDA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -1158- MOVE 'SIM' TO W-CHAVE-CRITICA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                /*" -1159- MOVE 'SIM' TO W-CHAVE-GRAVA-FOLLOWUP */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_GRAVA_FOLLOWUP);

                /*" -1160- MOVE '1' TO FOLLOUP-COD-ERRO03 */
                _.Move("1", FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_ERRO03);

                /*" -1161- GO TO R110-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R110_EXIT*/ //GOTO
                return;

                /*" -1163- END-IF. */
            }


            /*" -1164- IF (W-CHAVE-ACORDO-CANCELADO = 'SIM' ) */

            if ((AREA_DE_WORK.W_CHAVE_ACORDO_CANCELADO == "SIM"))
            {

                /*" -1165- MOVE '1' TO LD01-IND-PROCESSAMENTO */
                _.Move("1", AREA_DE_WORK.LD01.LD01_IND_PROCESSAMENTO);

                /*" -1167- MOVE 'O ACORDO ESTA CANCELADO. BOLETO EM FOLLOW-UP' TO LD01-MENSAGEM */
                _.Move("O ACORDO ESTA CANCELADO. BOLETO EM FOLLOW-UP", AREA_DE_WORK.LD01.LD01_MENSAGEM);

                /*" -1168- PERFORM R120-GRAVA-ARQ-SAIDA THRU R120-EXIT */

                R120_GRAVA_ARQ_SAIDA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -1169- MOVE 'SIM' TO W-CHAVE-CRITICA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                /*" -1170- MOVE 'SIM' TO W-CHAVE-GRAVA-FOLLOWUP */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_GRAVA_FOLLOWUP);

                /*" -1171- MOVE '1' TO FOLLOUP-COD-ERRO04 */
                _.Move("1", FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_ERRO04);

                /*" -1172- GO TO R110-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R110_EXIT*/ //GOTO
                return;

                /*" -1201- END-IF. */
            }


            /*" -1202- PERFORM R140-LE-HISTSINI-PROVISAO THRU R140-EXIT. */

            R140_LE_HISTSINI_PROVISAO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R140_EXIT*/


            /*" -1204- MOVE SINISHIS-VAL-OPERACAO TO W-VALOR-PROVISAO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, AREA_DE_WORK.W_VALOR_PROVISAO);

            /*" -1206- COMPUTE W-VALOR-MINIMO-BAIXA = W-VALOR-PROVISAO - 5. */
            AREA_DE_WORK.W_VALOR_MINIMO_BAIXA.Value = AREA_DE_WORK.W_VALOR_PROVISAO - 5;

            /*" -1208- MOVE 0 TO W-VALOR-ACRESCIMO W-VALOR-DESCONTO. */
            _.Move(0, AREA_DE_WORK.W_VALOR_ACRESCIMO, AREA_DE_WORK.W_VALOR_DESCONTO);

            /*" -1209- IF MOVIMCOB-VAL-TITULO LESS W-VALOR-PROVISAO */

            if (MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO < AREA_DE_WORK.W_VALOR_PROVISAO)
            {

                /*" -1211- COMPUTE W-VALOR-DESCONTO = W-VALOR-PROVISAO - MOVIMCOB-VAL-TITULO */
                AREA_DE_WORK.W_VALOR_DESCONTO.Value = AREA_DE_WORK.W_VALOR_PROVISAO - MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO;

                /*" -1213- END-IF. */
            }


            /*" -1214- IF MOVIMCOB-VAL-TITULO GREATER W-VALOR-PROVISAO */

            if (MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO > AREA_DE_WORK.W_VALOR_PROVISAO)
            {

                /*" -1216- COMPUTE W-VALOR-ACRESCIMO = MOVIMCOB-VAL-TITULO - W-VALOR-PROVISAO */
                AREA_DE_WORK.W_VALOR_ACRESCIMO.Value = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO - AREA_DE_WORK.W_VALOR_PROVISAO;

                /*" -1218- END-IF. */
            }


            /*" -1219- IF MOVIMCOB-VAL-TITULO LESS W-VALOR-MINIMO-BAIXA */

            if (MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO < AREA_DE_WORK.W_VALOR_MINIMO_BAIXA)
            {

                /*" -1220- MOVE '1' TO LD01-IND-PROCESSAMENTO */
                _.Move("1", AREA_DE_WORK.LD01.LD01_IND_PROCESSAMENTO);

                /*" -1223- MOVE 'BAIXA NAO EFETUADA. $ RECEBIDO < 5,00 - FOI PARA FOLLOWUP' TO LD01-MENSAGEM */
                _.Move("BAIXA NAO EFETUADA. $ RECEBIDO < 5,00 - FOI PARA FOLLOWUP", AREA_DE_WORK.LD01.LD01_MENSAGEM);

                /*" -1224- PERFORM R120-GRAVA-ARQ-SAIDA THRU R120-EXIT */

                R120_GRAVA_ARQ_SAIDA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -1225- MOVE 'SIM' TO W-CHAVE-CRITICA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_CRITICA);

                /*" -1226- MOVE 'SIM' TO W-CHAVE-GRAVA-FOLLOWUP */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_GRAVA_FOLLOWUP);

                /*" -1227- MOVE '1' TO FOLLOUP-COD-ERRO06 */
                _.Move("1", FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_ERRO06);

                /*" -1227- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R110_EXIT*/

        [StopWatch]
        /*" R130-LER-PARCELA */
        private void R130_LER_PARCELA(bool isPerform = false)
        {
            /*" -1243- INITIALIZE DCLSI-RESSARC-PARCELA. */
            _.Initialize(
                SI111.DCLSI_RESSARC_PARCELA
            );

            /*" -1245- MOVE 0 TO HOST-COUNT. */
            _.Move(0, HOST_COUNT);

            /*" -1247- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -1309- PERFORM R130_LER_PARCELA_DB_SELECT_1 */

            R130_LER_PARCELA_DB_SELECT_1();

            /*" -1312- EVALUATE SQLCODE */
            switch (DB.SQLCODE.Value)
            {

                /*" -1313- WHEN 000 */
                case 000:

                    /*" -1314- MOVE 'SIM' TO W-CHAVE-ACHOU-PARCELA */
                    _.Move("SIM", AREA_DE_WORK.W_CHAVE_ACHOU_PARCELA);

                    /*" -1315- WHEN 100 */
                    break;
                case 100:

                /*" -1316- WHEN -811 */
                case -811:

                    /*" -1317- MOVE 'NAO' TO W-CHAVE-ACHOU-PARCELA */
                    _.Move("NAO", AREA_DE_WORK.W_CHAVE_ACHOU_PARCELA);

                    /*" -1319- GO TO R130-EXIT */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R130_EXIT*/ //GOTO
                    return;

                    /*" -1320- WHEN OTHER */
                    break;
                default:

                    /*" -1321- DISPLAY 'ERRO SELECT SI_RESSARC_PARCELA (1)..............' */
                    _.Display($"ERRO SELECT SI_RESSARC_PARCELA (1)..............");

                    /*" -1322- DISPLAY 'NUM-NOSSO-TITULO.. ' MOVIMCOB-NUM-NOSSO-TITULO */
                    _.Display($"NUM-NOSSO-TITULO.. {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}");

                    /*" -1323- DISPLAY 'APOLICE / SINISTRO ' MOVIMCOB-NUM-APOLICE */
                    _.Display($"APOLICE / SINISTRO {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE}");

                    /*" -1324- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;

                    /*" -1328- END-EVALUATE. */
                    break;
            }


            /*" -1330- MOVE '043' TO WNR-EXEC-SQL. */
            _.Move("043", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -1345- PERFORM R130_LER_PARCELA_DB_SELECT_2 */

            R130_LER_PARCELA_DB_SELECT_2();

            /*" -1348- IF (SQLCODE = 0) */

            if ((DB.SQLCODE == 0))
            {

                /*" -1351- IF (SI111-NUM-RESSARC < W-NU-RESSARC-MAX) */

                if ((SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_RESSARC < W_NU_RESSARC_MAX))
                {

                    /*" -1352- MOVE 'SIM' TO W-CHAVE-ACORDO-CANCELADO */
                    _.Move("SIM", AREA_DE_WORK.W_CHAVE_ACORDO_CANCELADO);

                    /*" -1353- GO TO R130-EXIT */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R130_EXIT*/ //GOTO
                    return;

                    /*" -1354- END-IF */
                }


                /*" -1355- ELSE */
            }
            else
            {


                /*" -1356- DISPLAY 'ERRO SELECT SI_RESSARC_PARCELA (2)..............' */
                _.Display($"ERRO SELECT SI_RESSARC_PARCELA (2)..............");

                /*" -1357- DISPLAY 'NUM-NOSSO-TITULO.. ' MOVIMCOB-NUM-NOSSO-TITULO */
                _.Display($"NUM-NOSSO-TITULO.. {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}");

                /*" -1358- DISPLAY 'APOLICE / SINISTRO ' MOVIMCOB-NUM-APOLICE */
                _.Display($"APOLICE / SINISTRO {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE}");

                /*" -1359- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -1367- END-IF. */
            }


            /*" -1369- MOVE '011' TO WNR-EXEC-SQL. */
            _.Move("011", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -1416- PERFORM R130_LER_PARCELA_DB_SELECT_3 */

            R130_LER_PARCELA_DB_SELECT_3();

            /*" -1419- IF (SQLCODE NOT EQUAL ZEROS) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -1420- DISPLAY 'ERRO SELECT SI_RESSARC_PARCELA..................' */
                _.Display($"ERRO SELECT SI_RESSARC_PARCELA..................");

                /*" -1421- DISPLAY 'NUM-NOSSO-TITULO.. ' MOVIMCOB-NUM-NOSSO-TITULO */
                _.Display($"NUM-NOSSO-TITULO.. {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}");

                /*" -1422- DISPLAY 'APOLICE / SINISTRO ' MOVIMCOB-NUM-APOLICE */
                _.Display($"APOLICE / SINISTRO {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE}");

                /*" -1424- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1425- IF (SQLCODE EQUAL 0) */

            if ((DB.SQLCODE == 0))
            {

                /*" -1426- MOVE 'NAO' TO W-CHAVE-PARCELA-JA-BAIXADA */
                _.Move("NAO", AREA_DE_WORK.W_CHAVE_PARCELA_JA_BAIXADA);

                /*" -1427- ELSE */
            }
            else
            {


                /*" -1429- MOVE 'SIM' TO W-CHAVE-PARCELA-JA-BAIXADA */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_PARCELA_JA_BAIXADA);

                /*" -1429- END-IF. */
            }


        }

        [StopWatch]
        /*" R130-LER-PARCELA-DB-SELECT-1 */
        public void R130_LER_PARCELA_DB_SELECT_1()
        {
            /*" -1309- EXEC SQL SELECT P.NUM_APOL_SINISTRO, P.OCORR_HISTORICO, P.COD_OPERACAO, P.NUM_RESSARC, P.SEQ_RESSARC, P.NUM_PARCELA, P.COD_AGENCIA_CEDENT, P.COD_SISTEMA_ORIGEM, P.NUM_CEDENTE, P.NUM_CEDENTE_DV, P.DTH_VENCIMENTO, P.NUM_NOSSO_TITULO, P.DTH_CADASTRAMENTO, P.PCT_OPERACAO, P.IND_FORMA_BAIXA, P.NOM_PROGRAMA, VALUE(P.DTH_PAGAMENTO, '0001-01-01' ), P.IND_INTEGRACAO, VALUE(P.NUM_TITULO_SIGCB, 0), A.VLR_TOTAL_ACORDO, A.COD_FORNECEDOR, A.STA_ACORDO , M.RAMO , M.COD_PRODUTO INTO :SI111-NUM-APOL-SINISTRO, :SI111-OCORR-HISTORICO, :SI111-COD-OPERACAO, :SI111-NUM-RESSARC, :SI111-SEQ-RESSARC, :SI111-NUM-PARCELA, :SI111-COD-AGENCIA-CEDENT, :SI111-COD-SISTEMA-ORIGEM, :SI111-NUM-CEDENTE, :SI111-NUM-CEDENTE-DV, :SI111-DTH-VENCIMENTO, :SI111-NUM-NOSSO-TITULO, :SI111-DTH-CADASTRAMENTO, :SI111-PCT-OPERACAO, :SI111-IND-FORMA-BAIXA, :SI111-NOM-PROGRAMA, :SI111-DTH-PAGAMENTO, :SI111-IND-INTEGRACAO, :SI111-NUM-TITULO-SIGCB, :SI112-VLR-TOTAL-ACORDO, :SI112-COD-FORNECEDOR, :SI112-STA-ACORDO , :SINISMES-RAMO , :SINISMES-COD-PRODUTO FROM SEGUROS.SI_RESSARC_PARCELA P, SEGUROS.SI_RESSARC_ACORDO A, SEGUROS.SINISTRO_MESTRE M, SEGUROS.GE_OPERACAO O WHERE P.NUM_NOSSO_TITULO = :MOVIMCOB-NUM-NOSSO-TITULO AND O.COD_OPERACAO = P.COD_OPERACAO AND O.IDE_SISTEMA = 'SI' AND ( O.FUNCAO_OPERACAO = 'RSPPR' AND O.COD_OPERACAO = 4000) AND A.NUM_APOL_SINISTRO = P.NUM_APOL_SINISTRO AND A.NUM_RESSARC = P.NUM_RESSARC AND A.SEQ_RESSARC = P.SEQ_RESSARC AND M.NUM_APOL_SINISTRO = A.NUM_APOL_SINISTRO END-EXEC. */

            var r130_LER_PARCELA_DB_SELECT_1_Query1 = new R130_LER_PARCELA_DB_SELECT_1_Query1()
            {
                MOVIMCOB_NUM_NOSSO_TITULO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO.ToString(),
            };

            var executed_1 = R130_LER_PARCELA_DB_SELECT_1_Query1.Execute(r130_LER_PARCELA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SI111_NUM_APOL_SINISTRO, SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO);
                _.Move(executed_1.SI111_OCORR_HISTORICO, SI111.DCLSI_RESSARC_PARCELA.SI111_OCORR_HISTORICO);
                _.Move(executed_1.SI111_COD_OPERACAO, SI111.DCLSI_RESSARC_PARCELA.SI111_COD_OPERACAO);
                _.Move(executed_1.SI111_NUM_RESSARC, SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_RESSARC);
                _.Move(executed_1.SI111_SEQ_RESSARC, SI111.DCLSI_RESSARC_PARCELA.SI111_SEQ_RESSARC);
                _.Move(executed_1.SI111_NUM_PARCELA, SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_PARCELA);
                _.Move(executed_1.SI111_COD_AGENCIA_CEDENT, SI111.DCLSI_RESSARC_PARCELA.SI111_COD_AGENCIA_CEDENT);
                _.Move(executed_1.SI111_COD_SISTEMA_ORIGEM, SI111.DCLSI_RESSARC_PARCELA.SI111_COD_SISTEMA_ORIGEM);
                _.Move(executed_1.SI111_NUM_CEDENTE, SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_CEDENTE);
                _.Move(executed_1.SI111_NUM_CEDENTE_DV, SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_CEDENTE_DV);
                _.Move(executed_1.SI111_DTH_VENCIMENTO, SI111.DCLSI_RESSARC_PARCELA.SI111_DTH_VENCIMENTO);
                _.Move(executed_1.SI111_NUM_NOSSO_TITULO, SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_NOSSO_TITULO);
                _.Move(executed_1.SI111_DTH_CADASTRAMENTO, SI111.DCLSI_RESSARC_PARCELA.SI111_DTH_CADASTRAMENTO);
                _.Move(executed_1.SI111_PCT_OPERACAO, SI111.DCLSI_RESSARC_PARCELA.SI111_PCT_OPERACAO);
                _.Move(executed_1.SI111_IND_FORMA_BAIXA, SI111.DCLSI_RESSARC_PARCELA.SI111_IND_FORMA_BAIXA);
                _.Move(executed_1.SI111_NOM_PROGRAMA, SI111.DCLSI_RESSARC_PARCELA.SI111_NOM_PROGRAMA);
                _.Move(executed_1.SI111_DTH_PAGAMENTO, SI111.DCLSI_RESSARC_PARCELA.SI111_DTH_PAGAMENTO);
                _.Move(executed_1.SI111_IND_INTEGRACAO, SI111.DCLSI_RESSARC_PARCELA.SI111_IND_INTEGRACAO);
                _.Move(executed_1.SI111_NUM_TITULO_SIGCB, SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_TITULO_SIGCB);
                _.Move(executed_1.SI112_VLR_TOTAL_ACORDO, SI112.DCLSI_RESSARC_ACORDO.SI112_VLR_TOTAL_ACORDO);
                _.Move(executed_1.SI112_COD_FORNECEDOR, SI112.DCLSI_RESSARC_ACORDO.SI112_COD_FORNECEDOR);
                _.Move(executed_1.SI112_STA_ACORDO, SI112.DCLSI_RESSARC_ACORDO.SI112_STA_ACORDO);
                _.Move(executed_1.SINISMES_RAMO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO);
                _.Move(executed_1.SINISMES_COD_PRODUTO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R130_EXIT*/

        [StopWatch]
        /*" R130-LER-PARCELA-DB-SELECT-2 */
        public void R130_LER_PARCELA_DB_SELECT_2()
        {
            /*" -1345- EXEC SQL SELECT VALUE(MAX(P.NUM_RESSARC),0) INTO :W-NU-RESSARC-MAX FROM SEGUROS.SI_RESSARC_PARCELA P, SEGUROS.SI_RESSARC_ACORDO A WHERE A.NUM_APOL_SINISTRO = :SI111-NUM-APOL-SINISTRO AND A.NUM_APOL_SINISTRO = P.NUM_APOL_SINISTRO AND A.NUM_RESSARC = P.NUM_RESSARC AND A.SEQ_RESSARC = P.SEQ_RESSARC END-EXEC. */

            var r130_LER_PARCELA_DB_SELECT_2_Query1 = new R130_LER_PARCELA_DB_SELECT_2_Query1()
            {
                SI111_NUM_APOL_SINISTRO = SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R130_LER_PARCELA_DB_SELECT_2_Query1.Execute(r130_LER_PARCELA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.W_NU_RESSARC_MAX, W_NU_RESSARC_MAX);
            }


        }

        [StopWatch]
        /*" R140-LE-HISTSINI-PROVISAO */
        private void R140_LE_HISTSINI_PROVISAO(bool isPerform = false)
        {
            /*" -1437- INITIALIZE DCLSINISTRO-HISTORICO. */
            _.Initialize(
                SINISHIS.DCLSINISTRO_HISTORICO
            );

            /*" -1439- MOVE '012' TO WNR-EXEC-SQL. */
            _.Move("012", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -1507- PERFORM R140_LE_HISTSINI_PROVISAO_DB_SELECT_1 */

            R140_LE_HISTSINI_PROVISAO_DB_SELECT_1();

            /*" -1510- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1511- DISPLAY 'ERRO NO FETCH DA SINISTRO_HISTORICO' */
                _.Display($"ERRO NO FETCH DA SINISTRO_HISTORICO");

                /*" -1512- DISPLAY 'ACESSO AO AVISO DE PROVISAO - PRINCIPAL' */
                _.Display($"ACESSO AO AVISO DE PROVISAO - PRINCIPAL");

                /*" -1513- DISPLAY 'NUM_APOL_SINISTRO  = ' SI111-NUM-APOL-SINISTRO */
                _.Display($"NUM_APOL_SINISTRO  = {SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO}");

                /*" -1514- DISPLAY 'OCORR_HISTORICO    = ' SI111-OCORR-HISTORICO */
                _.Display($"OCORR_HISTORICO    = {SI111.DCLSI_RESSARC_PARCELA.SI111_OCORR_HISTORICO}");

                /*" -1515- DISPLAY 'COD_OPERACAO       = ' SI111-COD-OPERACAO */
                _.Display($"COD_OPERACAO       = {SI111.DCLSI_RESSARC_PARCELA.SI111_COD_OPERACAO}");

                /*" -1516- DISPLAY 'NUM_NOSSO_TITULO   = ' MOVIMCOB-NUM-NOSSO-TITULO */
                _.Display($"NUM_NOSSO_TITULO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}");

                /*" -1516- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R140-LE-HISTSINI-PROVISAO-DB-SELECT-1 */
        public void R140_LE_HISTSINI_PROVISAO_DB_SELECT_1()
        {
            /*" -1507- EXEC SQL SELECT H.COD_EMPRESA , H.TIPO_REGISTRO , H.NUM_APOL_SINISTRO , H.OCORR_HISTORICO , H.COD_OPERACAO , H.DATA_MOVIMENTO , H.HORA_OPERACAO , H.NOME_FAVORECIDO , H.VAL_OPERACAO , H.DATA_LIM_CORRECAO , H.TIPO_FAVORECIDO , H.DATA_NEGOCIADA , H.FONTE_PAGAMENTO , H.COD_PREST_SERVICO , H.COD_SERVICO , H.ORDEM_PAGAMENTO , H.NUM_RECIBO , H.NUM_MOV_SINISTRO , H.COD_USUARIO , H.SIT_CONTABIL , H.SIT_REGISTRO , H.TIMESTAMP , H.NUM_APOLICE , H.COD_PRODUTO , H.NOM_PROGRAMA , O.DES_OPERACAO , O.IND_TIPO_FUNCAO , O.FUNCAO_OPERACAO , O.DES_ABREVIADA INTO :SINISHIS-COD-EMPRESA , :SINISHIS-TIPO-REGISTRO , :SINISHIS-NUM-APOL-SINISTRO, :SINISHIS-OCORR-HISTORICO, :SINISHIS-COD-OPERACAO, :SINISHIS-DATA-MOVIMENTO, :SINISHIS-HORA-OPERACAO, :SINISHIS-NOME-FAVORECIDO, :SINISHIS-VAL-OPERACAO, :SINISHIS-DATA-LIM-CORRECAO, :SINISHIS-TIPO-FAVORECIDO, :SINISHIS-DATA-NEGOCIADA, :SINISHIS-FONTE-PAGAMENTO, :SINISHIS-COD-PREST-SERVICO, :SINISHIS-COD-SERVICO, :SINISHIS-ORDEM-PAGAMENTO, :SINISHIS-NUM-RECIBO, :SINISHIS-NUM-MOV-SINISTRO, :SINISHIS-COD-USUARIO, :SINISHIS-SIT-CONTABIL, :SINISHIS-SIT-REGISTRO, :SINISHIS-TIMESTAMP, :SINISHIS-NUM-APOLICE, :SINISHIS-COD-PRODUTO, :SINISHIS-NOM-PROGRAMA, :GEOPERAC-DES-OPERACAO, :GEOPERAC-IND-TIPO-FUNCAO, :GEOPERAC-FUNCAO-OPERACAO, :GEOPERAC-DES-ABREVIADA FROM SEGUROS.SINISTRO_HISTORICO H, SEGUROS.GE_OPERACAO O WHERE H.NUM_APOL_SINISTRO = :SI111-NUM-APOL-SINISTRO AND H.OCORR_HISTORICO = :SI111-OCORR-HISTORICO AND H.COD_OPERACAO = :SI111-COD-OPERACAO AND O.COD_OPERACAO = H.COD_OPERACAO AND O.IDE_SISTEMA = 'SI' AND O.IND_TIPO_FUNCAO = 'RESSA-PRO' AND O.FUNCAO_OPERACAO = 'RSPPR' END-EXEC. */

            var r140_LE_HISTSINI_PROVISAO_DB_SELECT_1_Query1 = new R140_LE_HISTSINI_PROVISAO_DB_SELECT_1_Query1()
            {
                SI111_NUM_APOL_SINISTRO = SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO.ToString(),
                SI111_OCORR_HISTORICO = SI111.DCLSI_RESSARC_PARCELA.SI111_OCORR_HISTORICO.ToString(),
                SI111_COD_OPERACAO = SI111.DCLSI_RESSARC_PARCELA.SI111_COD_OPERACAO.ToString(),
            };

            var executed_1 = R140_LE_HISTSINI_PROVISAO_DB_SELECT_1_Query1.Execute(r140_LE_HISTSINI_PROVISAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISHIS_COD_EMPRESA, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_EMPRESA);
                _.Move(executed_1.SINISHIS_TIPO_REGISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_TIPO_REGISTRO);
                _.Move(executed_1.SINISHIS_NUM_APOL_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO);
                _.Move(executed_1.SINISHIS_OCORR_HISTORICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO);
                _.Move(executed_1.SINISHIS_COD_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);
                _.Move(executed_1.SINISHIS_DATA_MOVIMENTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO);
                _.Move(executed_1.SINISHIS_HORA_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_HORA_OPERACAO);
                _.Move(executed_1.SINISHIS_NOME_FAVORECIDO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO);
                _.Move(executed_1.SINISHIS_VAL_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);
                _.Move(executed_1.SINISHIS_DATA_LIM_CORRECAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_LIM_CORRECAO);
                _.Move(executed_1.SINISHIS_TIPO_FAVORECIDO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_TIPO_FAVORECIDO);
                _.Move(executed_1.SINISHIS_DATA_NEGOCIADA, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_NEGOCIADA);
                _.Move(executed_1.SINISHIS_FONTE_PAGAMENTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_FONTE_PAGAMENTO);
                _.Move(executed_1.SINISHIS_COD_PREST_SERVICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO);
                _.Move(executed_1.SINISHIS_COD_SERVICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_SERVICO);
                _.Move(executed_1.SINISHIS_ORDEM_PAGAMENTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_ORDEM_PAGAMENTO);
                _.Move(executed_1.SINISHIS_NUM_RECIBO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_RECIBO);
                _.Move(executed_1.SINISHIS_NUM_MOV_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_MOV_SINISTRO);
                _.Move(executed_1.SINISHIS_COD_USUARIO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_USUARIO);
                _.Move(executed_1.SINISHIS_SIT_CONTABIL, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL);
                _.Move(executed_1.SINISHIS_SIT_REGISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_REGISTRO);
                _.Move(executed_1.SINISHIS_TIMESTAMP, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_TIMESTAMP);
                _.Move(executed_1.SINISHIS_NUM_APOLICE, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOLICE);
                _.Move(executed_1.SINISHIS_COD_PRODUTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PRODUTO);
                _.Move(executed_1.SINISHIS_NOM_PROGRAMA, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOM_PROGRAMA);
                _.Move(executed_1.GEOPERAC_DES_OPERACAO, GEOPERAC.DCLGE_OPERACAO.GEOPERAC_DES_OPERACAO);
                _.Move(executed_1.GEOPERAC_IND_TIPO_FUNCAO, GEOPERAC.DCLGE_OPERACAO.GEOPERAC_IND_TIPO_FUNCAO);
                _.Move(executed_1.GEOPERAC_FUNCAO_OPERACAO, GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO);
                _.Move(executed_1.GEOPERAC_DES_ABREVIADA, GEOPERAC.DCLGE_OPERACAO.GEOPERAC_DES_ABREVIADA);
            }


        }

        [StopWatch]
        /*" R130-LER-PARCELA-DB-SELECT-3 */
        public void R130_LER_PARCELA_DB_SELECT_3()
        {
            /*" -1416- EXEC SQL SELECT P.NUM_APOL_SINISTRO, P.OCORR_HISTORICO, P.COD_OPERACAO, P.NUM_RESSARC, P.SEQ_RESSARC, P.NUM_PARCELA, P.COD_AGENCIA_CEDENT, P.COD_SISTEMA_ORIGEM, P.NUM_CEDENTE, P.NUM_CEDENTE_DV, P.DTH_VENCIMENTO, P.NUM_NOSSO_TITULO, P.DTH_CADASTRAMENTO, P.PCT_OPERACAO, P.IND_FORMA_BAIXA, P.NOM_PROGRAMA, VALUE(P.DTH_PAGAMENTO, '0001-01-01' ), P.IND_INTEGRACAO, VALUE(P.NUM_TITULO_SIGCB, 0) INTO :SI111-NUM-APOL-SINISTRO, :SI111-OCORR-HISTORICO, :SI111-COD-OPERACAO, :SI111-NUM-RESSARC, :SI111-SEQ-RESSARC, :SI111-NUM-PARCELA, :SI111-COD-AGENCIA-CEDENT, :SI111-COD-SISTEMA-ORIGEM, :SI111-NUM-CEDENTE, :SI111-NUM-CEDENTE-DV, :SI111-DTH-VENCIMENTO, :SI111-NUM-NOSSO-TITULO, :SI111-DTH-CADASTRAMENTO, :SI111-PCT-OPERACAO, :SI111-IND-FORMA-BAIXA, :SI111-NOM-PROGRAMA, :SI111-DTH-PAGAMENTO, :SI111-IND-INTEGRACAO, :SI111-NUM-TITULO-SIGCB FROM SEGUROS.SI_RESSARC_PARCELA P, SEGUROS.GE_OPERACAO O WHERE NUM_NOSSO_TITULO = :MOVIMCOB-NUM-NOSSO-TITULO AND O.COD_OPERACAO = P.COD_OPERACAO AND O.IDE_SISTEMA = 'SI' AND ( O.FUNCAO_OPERACAO = 'RSPPR' AND O.COD_OPERACAO = 4000) AND P.DTH_PAGAMENTO IS NULL END-EXEC. */

            var r130_LER_PARCELA_DB_SELECT_3_Query1 = new R130_LER_PARCELA_DB_SELECT_3_Query1()
            {
                MOVIMCOB_NUM_NOSSO_TITULO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO.ToString(),
            };

            var executed_1 = R130_LER_PARCELA_DB_SELECT_3_Query1.Execute(r130_LER_PARCELA_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SI111_NUM_APOL_SINISTRO, SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO);
                _.Move(executed_1.SI111_OCORR_HISTORICO, SI111.DCLSI_RESSARC_PARCELA.SI111_OCORR_HISTORICO);
                _.Move(executed_1.SI111_COD_OPERACAO, SI111.DCLSI_RESSARC_PARCELA.SI111_COD_OPERACAO);
                _.Move(executed_1.SI111_NUM_RESSARC, SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_RESSARC);
                _.Move(executed_1.SI111_SEQ_RESSARC, SI111.DCLSI_RESSARC_PARCELA.SI111_SEQ_RESSARC);
                _.Move(executed_1.SI111_NUM_PARCELA, SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_PARCELA);
                _.Move(executed_1.SI111_COD_AGENCIA_CEDENT, SI111.DCLSI_RESSARC_PARCELA.SI111_COD_AGENCIA_CEDENT);
                _.Move(executed_1.SI111_COD_SISTEMA_ORIGEM, SI111.DCLSI_RESSARC_PARCELA.SI111_COD_SISTEMA_ORIGEM);
                _.Move(executed_1.SI111_NUM_CEDENTE, SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_CEDENTE);
                _.Move(executed_1.SI111_NUM_CEDENTE_DV, SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_CEDENTE_DV);
                _.Move(executed_1.SI111_DTH_VENCIMENTO, SI111.DCLSI_RESSARC_PARCELA.SI111_DTH_VENCIMENTO);
                _.Move(executed_1.SI111_NUM_NOSSO_TITULO, SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_NOSSO_TITULO);
                _.Move(executed_1.SI111_DTH_CADASTRAMENTO, SI111.DCLSI_RESSARC_PARCELA.SI111_DTH_CADASTRAMENTO);
                _.Move(executed_1.SI111_PCT_OPERACAO, SI111.DCLSI_RESSARC_PARCELA.SI111_PCT_OPERACAO);
                _.Move(executed_1.SI111_IND_FORMA_BAIXA, SI111.DCLSI_RESSARC_PARCELA.SI111_IND_FORMA_BAIXA);
                _.Move(executed_1.SI111_NOM_PROGRAMA, SI111.DCLSI_RESSARC_PARCELA.SI111_NOM_PROGRAMA);
                _.Move(executed_1.SI111_DTH_PAGAMENTO, SI111.DCLSI_RESSARC_PARCELA.SI111_DTH_PAGAMENTO);
                _.Move(executed_1.SI111_IND_INTEGRACAO, SI111.DCLSI_RESSARC_PARCELA.SI111_IND_INTEGRACAO);
                _.Move(executed_1.SI111_NUM_TITULO_SIGCB, SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_TITULO_SIGCB);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R140_EXIT*/

        [StopWatch]
        /*" R1000-GRAVA-RECEBIMENTO */
        private void R1000_GRAVA_RECEBIMENTO(bool isPerform = false)
        {
            /*" -1527- MOVE '013' TO WNR-EXEC-SQL. */
            _.Move("013", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -1531- PERFORM R1000_GRAVA_RECEBIMENTO_DB_UPDATE_1 */

            R1000_GRAVA_RECEBIMENTO_DB_UPDATE_1();

            /*" -1534- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1535- DISPLAY 'ERRO NO UPDATE SINISTRO_HISTORICO' */
                _.Display($"ERRO NO UPDATE SINISTRO_HISTORICO");

                /*" -1536- DISPLAY 'ATUALIZACAO PQ TEM PAGAMENTO' */
                _.Display($"ATUALIZACAO PQ TEM PAGAMENTO");

                /*" -1537- DISPLAY 'NUM_APOL_SINISTRO  = ' SI111-NUM-APOL-SINISTRO */
                _.Display($"NUM_APOL_SINISTRO  = {SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO}");

                /*" -1538- DISPLAY 'OCORR_HISTORICO    = ' SI111-OCORR-HISTORICO */
                _.Display($"OCORR_HISTORICO    = {SI111.DCLSI_RESSARC_PARCELA.SI111_OCORR_HISTORICO}");

                /*" -1539- DISPLAY 'COD_OPERACAO       = ' SI111-COD-OPERACAO */
                _.Display($"COD_OPERACAO       = {SI111.DCLSI_RESSARC_PARCELA.SI111_COD_OPERACAO}");

                /*" -1540- DISPLAY 'NUM_PARCELA        = ' SI111-NUM-PARCELA */
                _.Display($"NUM_PARCELA        = {SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_PARCELA}");

                /*" -1541- DISPLAY 'NUM_NOSSO_TITULO   = ' MOVIMCOB-NUM-NOSSO-TITULO */
                _.Display($"NUM_NOSSO_TITULO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}");

                /*" -1546- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1548- MOVE '014' TO WNR-EXEC-SQL. */
            _.Move("014", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -1553- PERFORM R1000_GRAVA_RECEBIMENTO_DB_UPDATE_2 */

            R1000_GRAVA_RECEBIMENTO_DB_UPDATE_2();

            /*" -1556- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1557- DISPLAY 'ERRO NO UPDATE SI_RESSARC_PARCELA' */
                _.Display($"ERRO NO UPDATE SI_RESSARC_PARCELA");

                /*" -1558- DISPLAY 'ATUALIZACAO DA DATA DE PAGAMENTO' */
                _.Display($"ATUALIZACAO DA DATA DE PAGAMENTO");

                /*" -1559- DISPLAY 'NUM_APOL_SINISTRO  = ' SI111-NUM-APOL-SINISTRO */
                _.Display($"NUM_APOL_SINISTRO  = {SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO}");

                /*" -1560- DISPLAY 'OCORR_HISTORICO    = ' SI111-OCORR-HISTORICO */
                _.Display($"OCORR_HISTORICO    = {SI111.DCLSI_RESSARC_PARCELA.SI111_OCORR_HISTORICO}");

                /*" -1561- DISPLAY 'COD_OPERACAO       = ' SI111-COD-OPERACAO */
                _.Display($"COD_OPERACAO       = {SI111.DCLSI_RESSARC_PARCELA.SI111_COD_OPERACAO}");

                /*" -1562- DISPLAY 'NUM_PARCELA        = ' SI111-NUM-PARCELA */
                _.Display($"NUM_PARCELA        = {SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_PARCELA}");

                /*" -1563- DISPLAY 'NUM_NOSSO_TITULO   = ' MOVIMCOB-NUM-NOSSO-TITULO */
                _.Display($"NUM_NOSSO_TITULO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}");

                /*" -1565- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1566- MOVE '1' TO SINISHIS-SIT-REGISTRO. */
            _.Move("1", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_REGISTRO);

            /*" -1567- MOVE 'SI0211B' TO SINISHIS-NOM-PROGRAMA. */
            _.Move("SI0211B", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOM_PROGRAMA);

            /*" -1569- MOVE SISTEMAS-DATA-MOV-ABERTO TO SINISHIS-DATA-MOVIMENTO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO);

            /*" -1573- MOVE SI111-NUM-PARCELA TO W-TEXTO-NOMFAV-PARCELA */
            _.Move(SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_PARCELA, AREA_DE_WORK.W_TEXTO_NOMFAV.W_TEXTO_NOMFAV_PARCELA);

            /*" -1574- MOVE 4101 TO SINISHIS-COD-OPERACAO. */
            _.Move(4101, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);

            /*" -1576- MOVE 'RESSA. - RECEBE PRINCIPAL      PARC. ' TO W-TEXTO-NOMFAV-TEXTO. */
            _.Move("RESSA. - RECEBE PRINCIPAL      PARC. ", AREA_DE_WORK.W_TEXTO_NOMFAV.W_TEXTO_NOMFAV_TEXTO);

            /*" -1577- MOVE W-TEXTO-NOMFAV TO SINISHIS-NOME-FAVORECIDO. */
            _.Move(AREA_DE_WORK.W_TEXTO_NOMFAV, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO);

            /*" -1578- MOVE W-VALOR-PROVISAO TO SINISHIS-VAL-OPERACAO. */
            _.Move(AREA_DE_WORK.W_VALOR_PROVISAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);

            /*" -1581- PERFORM R1100-INSERT-HISTSINI THRU R1100-EXIT. */

            R1100_INSERT_HISTSINI(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_EXIT*/


            /*" -1582- MOVE SINISHIS-COD-OPERACAO TO SI111-COD-OPERACAO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO, SI111.DCLSI_RESSARC_PARCELA.SI111_COD_OPERACAO);

            /*" -1583- MOVE 'SI0211B' TO SI111-NOM-PROGRAMA. */
            _.Move("SI0211B", SI111.DCLSI_RESSARC_PARCELA.SI111_NOM_PROGRAMA);

            /*" -1584- MOVE '1' TO SI111-IND-FORMA-BAIXA. */
            _.Move("1", SI111.DCLSI_RESSARC_PARCELA.SI111_IND_FORMA_BAIXA);

            /*" -1585- MOVE '1' TO SI111-COD-SISTEMA-ORIGEM. */
            _.Move("1", SI111.DCLSI_RESSARC_PARCELA.SI111_COD_SISTEMA_ORIGEM);

            /*" -1586- ADD 1 TO W-QTD-PARCELAS-BAIXADAS */
            AREA_DE_WORK.W_QTD_PARCELAS_BAIXADAS.Value = AREA_DE_WORK.W_QTD_PARCELAS_BAIXADAS + 1;

            /*" -1588- MOVE MOVIMCOB-DATA-QUITACAO TO SI111-DTH-PAGAMENTO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_QUITACAO, SI111.DCLSI_RESSARC_PARCELA.SI111_DTH_PAGAMENTO);

            /*" -1589- MOVE '015' TO WNR-EXEC-SQL. */
            _.Move("015", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -1593- PERFORM R1200-INSERT-PARCELA THRU R1200-EXIT. */

            R1200_INSERT_PARCELA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_EXIT*/


            /*" -1594- MOVE 4100 TO SINISHIS-COD-OPERACAO. */
            _.Move(4100, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);

            /*" -1596- MOVE 'RESSA. - RECEBE TOTAL          PARC. ' TO W-TEXTO-NOMFAV-TEXTO. */
            _.Move("RESSA. - RECEBE TOTAL          PARC. ", AREA_DE_WORK.W_TEXTO_NOMFAV.W_TEXTO_NOMFAV_TEXTO);

            /*" -1597- MOVE W-TEXTO-NOMFAV TO SINISHIS-NOME-FAVORECIDO. */
            _.Move(AREA_DE_WORK.W_TEXTO_NOMFAV, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO);

            /*" -1598- MOVE MOVIMCOB-VAL-TITULO TO SINISHIS-VAL-OPERACAO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);

            /*" -1600- PERFORM R1100-INSERT-HISTSINI THRU R1100-EXIT. */

            R1100_INSERT_HISTSINI(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_EXIT*/


            /*" -1601- MOVE SINISHIS-COD-OPERACAO TO SI111-COD-OPERACAO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO, SI111.DCLSI_RESSARC_PARCELA.SI111_COD_OPERACAO);

            /*" -1602- MOVE 'SI0211B' TO SI111-NOM-PROGRAMA. */
            _.Move("SI0211B", SI111.DCLSI_RESSARC_PARCELA.SI111_NOM_PROGRAMA);

            /*" -1603- MOVE '1' TO SI111-IND-FORMA-BAIXA. */
            _.Move("1", SI111.DCLSI_RESSARC_PARCELA.SI111_IND_FORMA_BAIXA);

            /*" -1605- MOVE MOVIMCOB-DATA-QUITACAO TO SI111-DTH-PAGAMENTO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_QUITACAO, SI111.DCLSI_RESSARC_PARCELA.SI111_DTH_PAGAMENTO);

            /*" -1606- MOVE '016' TO WNR-EXEC-SQL. */
            _.Move("016", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -1613- PERFORM R1200-INSERT-PARCELA THRU R1200-EXIT. */

            R1200_INSERT_PARCELA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_EXIT*/


            /*" -1614- MOVE 4102 TO SINISHIS-COD-OPERACAO. */
            _.Move(4102, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);

            /*" -1616- MOVE 'RESSA. - RECEBE ACRESCIMO      PARC. ' TO W-TEXTO-NOMFAV-TEXTO. */
            _.Move("RESSA. - RECEBE ACRESCIMO      PARC. ", AREA_DE_WORK.W_TEXTO_NOMFAV.W_TEXTO_NOMFAV_TEXTO);

            /*" -1617- MOVE W-TEXTO-NOMFAV TO SINISHIS-NOME-FAVORECIDO. */
            _.Move(AREA_DE_WORK.W_TEXTO_NOMFAV, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO);

            /*" -1618- MOVE W-VALOR-ACRESCIMO TO SINISHIS-VAL-OPERACAO. */
            _.Move(AREA_DE_WORK.W_VALOR_ACRESCIMO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);

            /*" -1620- PERFORM R1100-INSERT-HISTSINI THRU R1100-EXIT. */

            R1100_INSERT_HISTSINI(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_EXIT*/


            /*" -1621- MOVE SINISHIS-COD-OPERACAO TO SI111-COD-OPERACAO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO, SI111.DCLSI_RESSARC_PARCELA.SI111_COD_OPERACAO);

            /*" -1622- MOVE 'SI0211B' TO SI111-NOM-PROGRAMA. */
            _.Move("SI0211B", SI111.DCLSI_RESSARC_PARCELA.SI111_NOM_PROGRAMA);

            /*" -1623- MOVE '1' TO SI111-IND-FORMA-BAIXA. */
            _.Move("1", SI111.DCLSI_RESSARC_PARCELA.SI111_IND_FORMA_BAIXA);

            /*" -1625- MOVE MOVIMCOB-DATA-QUITACAO TO SI111-DTH-PAGAMENTO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_QUITACAO, SI111.DCLSI_RESSARC_PARCELA.SI111_DTH_PAGAMENTO);

            /*" -1626- MOVE '017' TO WNR-EXEC-SQL. */
            _.Move("017", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -1630- PERFORM R1200-INSERT-PARCELA THRU R1200-EXIT. */

            R1200_INSERT_PARCELA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_EXIT*/


            /*" -1631- MOVE 4103 TO SINISHIS-COD-OPERACAO. */
            _.Move(4103, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);

            /*" -1633- MOVE 'RESSA. - RECEBE DESCONTO       PARC. ' TO W-TEXTO-NOMFAV-TEXTO. */
            _.Move("RESSA. - RECEBE DESCONTO       PARC. ", AREA_DE_WORK.W_TEXTO_NOMFAV.W_TEXTO_NOMFAV_TEXTO);

            /*" -1634- MOVE W-TEXTO-NOMFAV TO SINISHIS-NOME-FAVORECIDO. */
            _.Move(AREA_DE_WORK.W_TEXTO_NOMFAV, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO);

            /*" -1635- MOVE W-VALOR-DESCONTO TO SINISHIS-VAL-OPERACAO. */
            _.Move(AREA_DE_WORK.W_VALOR_DESCONTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);

            /*" -1637- PERFORM R1100-INSERT-HISTSINI THRU R1100-EXIT. */

            R1100_INSERT_HISTSINI(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_EXIT*/


            /*" -1638- MOVE SINISHIS-COD-OPERACAO TO SI111-COD-OPERACAO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO, SI111.DCLSI_RESSARC_PARCELA.SI111_COD_OPERACAO);

            /*" -1639- MOVE 'SI0211B' TO SI111-NOM-PROGRAMA. */
            _.Move("SI0211B", SI111.DCLSI_RESSARC_PARCELA.SI111_NOM_PROGRAMA);

            /*" -1640- MOVE '1' TO SI111-IND-FORMA-BAIXA. */
            _.Move("1", SI111.DCLSI_RESSARC_PARCELA.SI111_IND_FORMA_BAIXA);

            /*" -1642- MOVE MOVIMCOB-DATA-QUITACAO TO SI111-DTH-PAGAMENTO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_QUITACAO, SI111.DCLSI_RESSARC_PARCELA.SI111_DTH_PAGAMENTO);

            /*" -1643- MOVE '018' TO WNR-EXEC-SQL. */
            _.Move("018", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -1658- PERFORM R1200-INSERT-PARCELA THRU R1200-EXIT. */

            R1200_INSERT_PARCELA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_EXIT*/


            /*" -1660- MOVE 4260 TO SINISHIS-COD-OPERACAO. */
            _.Move(4260, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);

            /*" -1670- PERFORM R6100-LE-VALOR-BASE-HONORARIO THRU R6100-EXIT. */

            R6100_LE_VALOR_BASE_HONORARIO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R6100_EXIT*/


            /*" -1672- PERFORM R6150-LE-PERCENTUAL-HONORARIO THRU R6150-EXIT */

            R6150_LE_PERCENTUAL_HONORARIO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R6150_EXIT*/


            /*" -1673- IF WS-TEM-HONORARIO EQUAL 'N' */

            if (AREA_DE_WORK.WS_TEM_HONORARIO == "N")
            {

                /*" -1675- GO TO R1000-REPASSE. */

                R1000_REPASSE(); //GOTO
                return;
            }


            /*" -1676- IF SI112-STA-ACORDO = 'J' */

            if (SI112.DCLSI_RESSARC_ACORDO.SI112_STA_ACORDO == "J")
            {

                /*" -1678- COMPUTE SINISHIS-VAL-OPERACAO = (HOST-VALOR-PAGTO-HON-REPASSE / 100) * HOST-PCT-OPERACAO */
                SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO.Value = (AREA_DE_WORK.HOST_VALOR_PAGTO_HON_REPASSE / 100f) * HOST_PCT_OPERACAO;

                /*" -1682- GO TO R6200-HONORARIO-JUDICIAL. */

                R6200_HONORARIO_JUDICIAL(); //GOTO
                return;
            }


            /*" -1691- PERFORM R6200-CALC-HONORARIO THRU R6200-EXIT. */

            R6200_CALC_HONORARIO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R6200_EXIT*/


            /*" -1692- MOVE 'NAO' TO WTEM-PAGTO-MAO-GRANDE */
            _.Move("NAO", AREA_DE_WORK.WTEM_PAGTO_MAO_GRANDE);

            /*" -1699- PERFORM R1500-LE-SINISHIS THRU R1500-EXIT. */

            R1500_LE_SINISHIS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_EXIT*/


            /*" -1700- IF WTEM-PAGTO-MAO-GRANDE EQUAL 'SIM' */

            if (AREA_DE_WORK.WTEM_PAGTO_MAO_GRANDE == "SIM")
            {

                /*" -1707- DISPLAY 'EXISTE HONORARIO PAGO NA MAO GRANDE...' ' ' SI111-NUM-APOL-SINISTRO ' ' SI111-NUM-RESSARC ' ' SI111-NUM-PARCELA ' ' SI111-OCORR-HISTORICO ' ' MOVIMCOB-NUM-NOSSO-TITULO ' ' HOST-MIN-OCORR-HISTORICO */

                $"EXISTE HONORARIO PAGO NA MAO GRANDE... {SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO} {SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_RESSARC} {SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_PARCELA} {SI111.DCLSI_RESSARC_PARCELA.SI111_OCORR_HISTORICO} {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO} {HOST_MIN_OCORR_HISTORICO}"
                .Display();

                /*" -1708- MOVE 'NAO' TO WFIM-SINISHIS */
                _.Move("NAO", AREA_DE_WORK.WFIM_SINISHIS);

                /*" -1709- PERFORM R1510-DECLARE-SINISHIS THRU R1510-EXIT */

                R1510_DECLARE_SINISHIS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1510_EXIT*/


                /*" -1710- PERFORM R1520-FETCH-SINISHIS THRU R1520-EXIT */

                R1520_FETCH_SINISHIS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1520_EXIT*/


                /*" -1712- PERFORM R1600-ASSOCIA-PAGTO THRU R1600-EXIT UNTIL WFIM-SINISHIS EQUAL 'SIM' */

                while (!(AREA_DE_WORK.WFIM_SINISHIS == "SIM"))
                {

                    R1600_ASSOCIA_PAGTO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_EXIT*/

                }

                /*" -1714- GO TO R1000-REPASSE. */

                R1000_REPASSE(); //GOTO
                return;
            }


            /*" -1716- COMPUTE SINISHIS-VAL-OPERACAO = (HOST-VALOR-PAGTO-HON-REPASSE / 100) * W-PERC-HONORARIO-FINAL. */
            SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO.Value = (AREA_DE_WORK.HOST_VALOR_PAGTO_HON_REPASSE / 100f) * AREA_DE_WORK.W_PERC_HONORARIO_FINAL;

        }

        [StopWatch]
        /*" R1000-GRAVA-RECEBIMENTO-DB-UPDATE-1 */
        public void R1000_GRAVA_RECEBIMENTO_DB_UPDATE_1()
        {
            /*" -1531- EXEC SQL UPDATE SEGUROS.SINISTRO_HISTORICO SET SIT_REGISTRO = '1' WHERE NUM_APOL_SINISTRO = :SI111-NUM-APOL-SINISTRO AND OCORR_HISTORICO = :SI111-OCORR-HISTORICO END-EXEC. */

            var r1000_GRAVA_RECEBIMENTO_DB_UPDATE_1_Update1 = new R1000_GRAVA_RECEBIMENTO_DB_UPDATE_1_Update1()
            {
                SI111_NUM_APOL_SINISTRO = SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO.ToString(),
                SI111_OCORR_HISTORICO = SI111.DCLSI_RESSARC_PARCELA.SI111_OCORR_HISTORICO.ToString(),
            };

            R1000_GRAVA_RECEBIMENTO_DB_UPDATE_1_Update1.Execute(r1000_GRAVA_RECEBIMENTO_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R6200-HONORARIO-JUDICIAL */
        private void R6200_HONORARIO_JUDICIAL(bool isPerform = false)
        {
            /*" -1725- IF SINISMES-COD-PRODUTO EQUAL 4813 OR 4814 OR 4815 OR 4816 OR 4817 OR 6008 OR 6009 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO.In("4813", "4814", "4815", "4816", "4817", "6008", "6009"))
            {

                /*" -1726- MOVE 4374726 TO FORNECED-COD-FORNECEDOR */
                _.Move(4374726, FORNECED.DCLFORNECEDORES.FORNECED_COD_FORNECEDOR);

                /*" -1727- ELSE */
            }
            else
            {


                /*" -1729- MOVE SI112-COD-FORNECEDOR TO FORNECED-COD-FORNECEDOR. */
                _.Move(SI112.DCLSI_RESSARC_ACORDO.SI112_COD_FORNECEDOR, FORNECED.DCLFORNECEDORES.FORNECED_COD_FORNECEDOR);
            }


            /*" -1730- DISPLAY '--------------------------------------------------' */
            _.Display($"--------------------------------------------------");

            /*" -1731- DISPLAY '01 SI112-COD-FORNECEDOR    = ' SI112-COD-FORNECEDOR */
            _.Display($"01 SI112-COD-FORNECEDOR    = {SI112.DCLSI_RESSARC_ACORDO.SI112_COD_FORNECEDOR}");

            /*" -1733- DISPLAY '01 FORNECED-COD-FORNECEDOR = ' FORNECED-COD-FORNECEDOR */
            _.Display($"01 FORNECED-COD-FORNECEDOR = {FORNECED.DCLFORNECEDORES.FORNECED_COD_FORNECEDOR}");

            /*" -1734- DISPLAY '--------------------------------------------------' */
            _.Display($"--------------------------------------------------");

            /*" -1736- MOVE 20 TO FORNECED-COD-SERVICO-ISS. */
            _.Move(20, FORNECED.DCLFORNECEDORES.FORNECED_COD_SERVICO_ISS);

            /*" -1737- PERFORM R1010-LE-FORNECEDOR THRU R1010-EXIT. */

            R1010_LE_FORNECEDOR(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_EXIT*/


            /*" -1738- MOVE 'A' TO SINISHIS-TIPO-FAVORECIDO. */
            _.Move("A", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_TIPO_FAVORECIDO);

            /*" -1739- MOVE FORNECED-NOME-FORNECEDOR TO SINISHIS-NOME-FAVORECIDO */
            _.Move(FORNECED.DCLFORNECEDORES.FORNECED_NOME_FORNECEDOR, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO);

            /*" -1744- MOVE FORNECED-COD-FORNECEDOR TO SINISHIS-COD-PREST-SERVICO */
            _.Move(FORNECED.DCLFORNECEDORES.FORNECED_COD_FORNECEDOR, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO);

            /*" -1745- MOVE FORNECED-COD-SERVICO-ISS TO SINISHIS-COD-SERVICO */
            _.Move(FORNECED.DCLFORNECEDORES.FORNECED_COD_SERVICO_ISS, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_SERVICO);

            /*" -1746- IF FORNECED-COD-BANCO EQUAL 104 */

            if (FORNECED.DCLFORNECEDORES.FORNECED_COD_BANCO == 104)
            {

                /*" -1751- MOVE '2' TO SINISHIS-SIT-CONTABIL. */
                _.Move("2", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL);
            }


            /*" -1753- IF SINISMES-COD-PRODUTO EQUAL 4813 OR 4814 OR 4815 OR 4816 OR 4817 OR 6008 OR 6009 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO.In("4813", "4814", "4815", "4816", "4817", "6008", "6009"))
            {

                /*" -1754- MOVE '2' TO SINISHIS-SIT-REGISTRO */
                _.Move("2", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_REGISTRO);

                /*" -1755- ELSE */
            }
            else
            {


                /*" -1760- MOVE '0' TO SINISHIS-SIT-REGISTRO. */
                _.Move("0", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_REGISTRO);
            }


            /*" -1761- IF SI112-COD-FORNECEDOR EQUAL 2288714 */

            if (SI112.DCLSI_RESSARC_ACORDO.SI112_COD_FORNECEDOR == 2288714)
            {

                /*" -1762- MOVE '2' TO SINISHIS-SIT-REGISTRO */
                _.Move("2", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_REGISTRO);

                /*" -1763- ELSE */
            }
            else
            {


                /*" -1765- MOVE '0' TO SINISHIS-SIT-REGISTRO. */
                _.Move("0", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_REGISTRO);
            }


            /*" -1767- PERFORM R1100-INSERT-HISTSINI THRU R1100-EXIT. */

            R1100_INSERT_HISTSINI(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_EXIT*/


            /*" -1768- MOVE SINISHIS-COD-OPERACAO TO SI111-COD-OPERACAO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO, SI111.DCLSI_RESSARC_PARCELA.SI111_COD_OPERACAO);

            /*" -1769- MOVE 'SI0211B' TO SI111-NOM-PROGRAMA. */
            _.Move("SI0211B", SI111.DCLSI_RESSARC_PARCELA.SI111_NOM_PROGRAMA);

            /*" -1770- MOVE '1' TO SI111-IND-FORMA-BAIXA. */
            _.Move("1", SI111.DCLSI_RESSARC_PARCELA.SI111_IND_FORMA_BAIXA);

            /*" -1771- MOVE MOVIMCOB-DATA-QUITACAO TO SI111-DTH-PAGAMENTO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_QUITACAO, SI111.DCLSI_RESSARC_PARCELA.SI111_DTH_PAGAMENTO);

            /*" -1773- MOVE HOST-PCT-OPERACAO TO SI111-PCT-OPERACAO. */
            _.Move(HOST_PCT_OPERACAO, SI111.DCLSI_RESSARC_PARCELA.SI111_PCT_OPERACAO);

            /*" -1774- MOVE '019' TO WNR-EXEC-SQL. */
            _.Move("019", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -1774- PERFORM R1200-INSERT-PARCELA THRU R1200-EXIT. */

            R1200_INSERT_PARCELA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_EXIT*/


        }

        [StopWatch]
        /*" R1000-GRAVA-RECEBIMENTO-DB-UPDATE-2 */
        public void R1000_GRAVA_RECEBIMENTO_DB_UPDATE_2()
        {
            /*" -1553- EXEC SQL UPDATE SEGUROS.SI_RESSARC_PARCELA SET DTH_PAGAMENTO = :MOVIMCOB-DATA-QUITACAO, IND_FORMA_BAIXA = '1' WHERE NUM_APOL_SINISTRO = :SI111-NUM-APOL-SINISTRO AND OCORR_HISTORICO = :SI111-OCORR-HISTORICO END-EXEC. */

            var r1000_GRAVA_RECEBIMENTO_DB_UPDATE_2_Update1 = new R1000_GRAVA_RECEBIMENTO_DB_UPDATE_2_Update1()
            {
                MOVIMCOB_DATA_QUITACAO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_QUITACAO.ToString(),
                SI111_NUM_APOL_SINISTRO = SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO.ToString(),
                SI111_OCORR_HISTORICO = SI111.DCLSI_RESSARC_PARCELA.SI111_OCORR_HISTORICO.ToString(),
            };

            R1000_GRAVA_RECEBIMENTO_DB_UPDATE_2_Update1.Execute(r1000_GRAVA_RECEBIMENTO_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R1000-REPASSE */
        private void R1000_REPASSE(bool isPerform = false)
        {
            /*" -1780- IF SINCREIN-COD-OPERACAO = 999 */

            if (SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_OPERACAO == 999)
            {

                /*" -1788- IF SINISMES-COD-PRODUTO EQUAL 4813 OR SINISMES-COD-PRODUTO EQUAL 4814 OR SINISMES-COD-PRODUTO EQUAL 4815 OR SINISMES-COD-PRODUTO EQUAL 4816 OR SINISMES-COD-PRODUTO EQUAL 4817 OR SINISMES-COD-PRODUTO EQUAL 6008 OR SINISMES-COD-PRODUTO EQUAL 6009 NEXT SENTENCE */

                if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO == 4813 || SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO == 4814 || SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO == 4815 || SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO == 4816 || SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO == 4817 || SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO == 6008 || SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO == 6009)
                {

                    /*" -1789- ELSE */
                }
                else
                {


                    /*" -1790- CONTINUE */

                    /*" -1791- END-IF */
                }


                /*" -1793- END-IF */
            }


            /*" -1794- IF SINCREIN-COD-OPERACAO = 161 */

            if (SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_OPERACAO == 161)
            {

                /*" -1795- CONTINUE */

                /*" -1800- END-IF. */
            }


            /*" -1803- IF (SINISMES-RAMO NOT EQUAL 48) AND (SINISMES-RAMO NOT EQUAL 60) AND (SINISMES-RAMO NOT EQUAL 70) */

            if ((SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO != 48) && (SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO != 60) && (SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO != 70))
            {

                /*" -1804- CONTINUE */

                /*" -1813- END-IF. */
            }


            /*" -1814- IF SI111-NUM-APOL-SINISTRO EQUAL 104800089982 */

            if (SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO == 104800089982)
            {

                /*" -1815- CONTINUE */

                /*" -1823- END-IF. */
            }


            /*" -1831- IF SINISMES-COD-PRODUTO EQUAL 4813 OR SINISMES-COD-PRODUTO EQUAL 4814 OR SINISMES-COD-PRODUTO EQUAL 4815 OR SINISMES-COD-PRODUTO EQUAL 4816 OR SINISMES-COD-PRODUTO EQUAL 4817 OR SINISMES-COD-PRODUTO EQUAL 6008 OR SINISMES-COD-PRODUTO EQUAL 6009 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO == 4813 || SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO == 4814 || SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO == 4815 || SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO == 4816 || SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO == 4817 || SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO == 6008 || SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO == 6009)
            {

                /*" -1832- CONTINUE */

                /*" -1837- END-IF. */
            }


            /*" -1839- MOVE 'NAO' TO W-CHAVE-CREDITO-INTERNO */
            _.Move("NAO", AREA_DE_WORK.W_CHAVE_CREDITO_INTERNO);

            /*" -1840- MOVE 4290 TO SINISHIS-COD-OPERACAO. */
            _.Move(4290, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);

            /*" -1846- PERFORM R6300-CALC-REPASSE THRU R6300-EXIT. */

            R6300_CALC_REPASSE(true);

            R6300_PESQUISA_CREDITO_INTERNO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R6300_EXIT*/


            /*" -1847- MOVE 'NAO' TO WTEM-PAGTO-MAO-GRANDE */
            _.Move("NAO", AREA_DE_WORK.WTEM_PAGTO_MAO_GRANDE);

            /*" -1854- PERFORM R1500-LE-SINISHIS THRU R1500-EXIT. */

            R1500_LE_SINISHIS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_EXIT*/


            /*" -1855- IF WTEM-PAGTO-MAO-GRANDE EQUAL 'SIM' */

            if (AREA_DE_WORK.WTEM_PAGTO_MAO_GRANDE == "SIM")
            {

                /*" -1862- DISPLAY 'EXISTE REPASSE PAGO NA MAO GRANDE...' ' ' SI111-NUM-APOL-SINISTRO ' ' SI111-NUM-RESSARC ' ' SI111-NUM-PARCELA ' ' SI111-OCORR-HISTORICO ' ' MOVIMCOB-NUM-NOSSO-TITULO ' ' HOST-MIN-OCORR-HISTORICO */

                $"EXISTE REPASSE PAGO NA MAO GRANDE... {SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO} {SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_RESSARC} {SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_PARCELA} {SI111.DCLSI_RESSARC_PARCELA.SI111_OCORR_HISTORICO} {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO} {HOST_MIN_OCORR_HISTORICO}"
                .Display();

                /*" -1863- MOVE 'NAO' TO WFIM-SINISHIS */
                _.Move("NAO", AREA_DE_WORK.WFIM_SINISHIS);

                /*" -1864- PERFORM R1510-DECLARE-SINISHIS THRU R1510-EXIT */

                R1510_DECLARE_SINISHIS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1510_EXIT*/


                /*" -1865- PERFORM R1520-FETCH-SINISHIS THRU R1520-EXIT */

                R1520_FETCH_SINISHIS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1520_EXIT*/


                /*" -1867- PERFORM R1600-ASSOCIA-PAGTO THRU R1600-EXIT UNTIL WFIM-SINISHIS EQUAL 'SIM' */

                while (!(AREA_DE_WORK.WFIM_SINISHIS == "SIM"))
                {

                    R1600_ASSOCIA_PAGTO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_EXIT*/

                }

                /*" -1869- GO TO R1000-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_EXIT*/ //GOTO
                return;
            }


            /*" -1872- COMPUTE SINISHIS-VAL-OPERACAO = (HOST-VALOR-PAGTO-HON-REPASSE / 100) * W-PERCENTUAL-REPASSE. */
            SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO.Value = (AREA_DE_WORK.HOST_VALOR_PAGTO_HON_REPASSE / 100f) * AREA_DE_WORK.W_PERCENTUAL_REPASSE;

            /*" -1873- MOVE 891733 TO FORNECED-COD-FORNECEDOR. */
            _.Move(891733, FORNECED.DCLFORNECEDORES.FORNECED_COD_FORNECEDOR);

            /*" -1874- MOVE 95 TO FORNECED-COD-SERVICO-ISS */
            _.Move(95, FORNECED.DCLFORNECEDORES.FORNECED_COD_SERVICO_ISS);

            /*" -1875- DISPLAY '--------------------------------------------------' */
            _.Display($"--------------------------------------------------");

            /*" -1877- DISPLAY '03 FORNECED-COD-FORNECEDOR = ' FORNECED-COD-FORNECEDOR */
            _.Display($"03 FORNECED-COD-FORNECEDOR = {FORNECED.DCLFORNECEDORES.FORNECED_COD_FORNECEDOR}");

            /*" -1879- DISPLAY '--------------------------------------------------' */
            _.Display($"--------------------------------------------------");

            /*" -1885- PERFORM R1010-LE-FORNECEDOR THRU R1010-EXIT. */

            R1010_LE_FORNECEDOR(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_EXIT*/


            /*" -1891- MOVE 'A' TO SINISHIS-TIPO-FAVORECIDO. */
            _.Move("A", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_TIPO_FAVORECIDO);

            /*" -1892- IF (W-CHAVE-CREDITO-INTERNO = 'SIM' ) */

            if ((AREA_DE_WORK.W_CHAVE_CREDITO_INTERNO == "SIM"))
            {

                /*" -1893- PERFORM R1020-MIN-INDENIZACAO-CREDINT THRU R1020-EXIT */

                R1020_MIN_INDENIZACAO_CREDINT(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1020_EXIT*/


                /*" -1895- END-IF. */
            }


            /*" -1896- MOVE FORNECED-NOME-FORNECEDOR TO W-TEXTO-NOMFAV-TEXTO-CAIXA */
            _.Move(FORNECED.DCLFORNECEDORES.FORNECED_NOME_FORNECEDOR, AREA_DE_WORK.W_TEXTO_NOMFAV_CAIXA.W_TEXTO_NOMFAV_TEXTO_CAIXA);

            /*" -1899- MOVE W-TEXTO-NOMFAV-CAIXA TO SINISHIS-NOME-FAVORECIDO */
            _.Move(AREA_DE_WORK.W_TEXTO_NOMFAV_CAIXA, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO);

            /*" -1900- MOVE FORNECED-COD-FORNECEDOR TO SINISHIS-COD-PREST-SERVICO */
            _.Move(FORNECED.DCLFORNECEDORES.FORNECED_COD_FORNECEDOR, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO);

            /*" -1901- DISPLAY '--------------------------------------------------' */
            _.Display($"--------------------------------------------------");

            /*" -1903- DISPLAY '04 FORNECED-COD-FORNECEDOR = ' FORNECED-COD-FORNECEDOR */
            _.Display($"04 FORNECED-COD-FORNECEDOR = {FORNECED.DCLFORNECEDORES.FORNECED_COD_FORNECEDOR}");

            /*" -1905- DISPLAY '--------------------------------------------------' */
            _.Display($"--------------------------------------------------");

            /*" -1908- MOVE FORNECED-COD-SERVICO-ISS TO SINISHIS-COD-SERVICO */
            _.Move(FORNECED.DCLFORNECEDORES.FORNECED_COD_SERVICO_ISS, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_SERVICO);

            /*" -1919- MOVE '7' TO SINISHIS-SIT-CONTABIL. */
            _.Move("7", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL);

            /*" -1922- IF (W-CHAVE-CREDITO-INTERNO EQUAL 'SIM' ) AND (HOST-MIN-DATA-MOVIMENTO LESS '2005-01-01' ) AND (SINISHIS-COD-PREST-SERVICO = 891733) */

            if ((AREA_DE_WORK.W_CHAVE_CREDITO_INTERNO == "SIM") && (HOST_MIN_DATA_MOVIMENTO < "2005-01-01") && (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO == 891733))
            {

                /*" -1923- MOVE '1' TO SINISHIS-SIT-CONTABIL */
                _.Move("1", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL);

                /*" -1925- END-IF. */
            }


            /*" -1926- MOVE '0' TO SINISHIS-SIT-REGISTRO. */
            _.Move("0", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_REGISTRO);

            /*" -1928- PERFORM R1100-INSERT-HISTSINI THRU R1100-EXIT. */

            R1100_INSERT_HISTSINI(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_EXIT*/


            /*" -1929- MOVE SINISHIS-COD-OPERACAO TO SI111-COD-OPERACAO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO, SI111.DCLSI_RESSARC_PARCELA.SI111_COD_OPERACAO);

            /*" -1930- MOVE 'SI0211B' TO SI111-NOM-PROGRAMA. */
            _.Move("SI0211B", SI111.DCLSI_RESSARC_PARCELA.SI111_NOM_PROGRAMA);

            /*" -1931- MOVE '1' TO SI111-IND-FORMA-BAIXA. */
            _.Move("1", SI111.DCLSI_RESSARC_PARCELA.SI111_IND_FORMA_BAIXA);

            /*" -1932- MOVE 0 TO SI111-PCT-OPERACAO. */
            _.Move(0, SI111.DCLSI_RESSARC_PARCELA.SI111_PCT_OPERACAO);

            /*" -1934- MOVE MOVIMCOB-DATA-QUITACAO TO SI111-DTH-PAGAMENTO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_QUITACAO, SI111.DCLSI_RESSARC_PARCELA.SI111_DTH_PAGAMENTO);

            /*" -1935- MOVE '020' TO WNR-EXEC-SQL. */
            _.Move("020", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -1945- PERFORM R1200-INSERT-PARCELA THRU R1200-EXIT. */

            R1200_INSERT_PARCELA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_EXIT*/


            /*" -1948- IF (SINISHIS-COD-PRODUTO EQUAL 4801) OR (W-CHAVE-CREDITO-INTERNO EQUAL 'SIM' AND HOST-MIN-DATA-MOVIMENTO NOT LESS '2005-01-01' ) */

            if ((SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PRODUTO == 4801) || (AREA_DE_WORK.W_CHAVE_CREDITO_INTERNO == "SIM" && HOST_MIN_DATA_MOVIMENTO >= "2005-01-01"))
            {

                /*" -1949- MOVE '2' TO SINISHIS-SIT-REGISTRO */
                _.Move("2", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_REGISTRO);

                /*" -1950- PERFORM R1150-CANCELA-OPERACAO THRU R1150-EXIT */

                R1150_CANCELA_OPERACAO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1150_EXIT*/


                /*" -1951- MOVE 4291 TO SINISHIS-COD-OPERACAO */
                _.Move(4291, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);

                /*" -1952- MOVE '2' TO SINISHIS-SIT-REGISTRO */
                _.Move("2", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_REGISTRO);

                /*" -1953- PERFORM R1100-INSERT-HISTSINI THRU R1100-EXIT */

                R1100_INSERT_HISTSINI(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_EXIT*/


                /*" -1954- MOVE SINISHIS-COD-OPERACAO TO SI111-COD-OPERACAO */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO, SI111.DCLSI_RESSARC_PARCELA.SI111_COD_OPERACAO);

                /*" -1955- PERFORM R1200-INSERT-PARCELA THRU R1200-EXIT */

                R1200_INSERT_PARCELA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_EXIT*/


                /*" -1956- MOVE 4292 TO SINISHIS-COD-OPERACAO */
                _.Move(4292, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);

                /*" -1957- MOVE '0' TO SINISHIS-SIT-REGISTRO */
                _.Move("0", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_REGISTRO);

                /*" -1958- PERFORM R1100-INSERT-HISTSINI THRU R1100-EXIT */

                R1100_INSERT_HISTSINI(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_EXIT*/


                /*" -1959- MOVE SINISHIS-COD-OPERACAO TO SI111-COD-OPERACAO */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO, SI111.DCLSI_RESSARC_PARCELA.SI111_COD_OPERACAO);

                /*" -1959- PERFORM R1200-INSERT-PARCELA THRU R1200-EXIT. */

                R1200_INSERT_PARCELA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_EXIT*/

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_PULA_REPASSE*/
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_EXIT*/

        [StopWatch]
        /*" R1010-LE-FORNECEDOR */
        private void R1010_LE_FORNECEDOR(bool isPerform = false)
        {
            /*" -1973- MOVE '021' TO WNR-EXEC-SQL. */
            _.Move("021", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -1987- PERFORM R1010_LE_FORNECEDOR_DB_SELECT_1 */

            R1010_LE_FORNECEDOR_DB_SELECT_1();

            /*" -1990- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -1991- DISPLAY 'ERRO SELECT FORNECEDOR --------------------' */
                _.Display($"ERRO SELECT FORNECEDOR --------------------");

                /*" -1992- DISPLAY 'SINISTRO        = ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO        = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -1993- DISPLAY 'OCORHIST        = ' SINISHIS-OCORR-HISTORICO */
                _.Display($"OCORHIST        = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}");

                /*" -1994- DISPLAY 'OPERACAO        = ' SINISHIS-COD-OPERACAO */
                _.Display($"OPERACAO        = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO}");

                /*" -1995- DISPLAY 'FORNECEDOR      = ' FORNECED-COD-FORNECEDOR */
                _.Display($"FORNECEDOR      = {FORNECED.DCLFORNECEDORES.FORNECED_COD_FORNECEDOR}");

                /*" -1996- DISPLAY 'COD_SERVICO_ISS = ' FORNECED-COD-SERVICO-ISS */
                _.Display($"COD_SERVICO_ISS = {FORNECED.DCLFORNECEDORES.FORNECED_COD_SERVICO_ISS}");

                /*" -1997- DISPLAY '-------------------------------------------' */
                _.Display($"-------------------------------------------");

                /*" -1997- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1010-LE-FORNECEDOR-DB-SELECT-1 */
        public void R1010_LE_FORNECEDOR_DB_SELECT_1()
        {
            /*" -1987- EXEC SQL SELECT COD_FORNECEDOR, NOME_FORNECEDOR, COD_SERVICO_ISS, COD_BANCO INTO :FORNECED-COD-FORNECEDOR, :FORNECED-NOME-FORNECEDOR, :FORNECED-COD-SERVICO-ISS, :FORNECED-COD-BANCO FROM SEGUROS.FORNECEDORES WHERE COD_FORNECEDOR = :FORNECED-COD-FORNECEDOR AND TIPO_REGISTRO = '4' AND COD_SERVICO_ISS = :FORNECED-COD-SERVICO-ISS WITH UR END-EXEC. */

            var r1010_LE_FORNECEDOR_DB_SELECT_1_Query1 = new R1010_LE_FORNECEDOR_DB_SELECT_1_Query1()
            {
                FORNECED_COD_SERVICO_ISS = FORNECED.DCLFORNECEDORES.FORNECED_COD_SERVICO_ISS.ToString(),
                FORNECED_COD_FORNECEDOR = FORNECED.DCLFORNECEDORES.FORNECED_COD_FORNECEDOR.ToString(),
            };

            var executed_1 = R1010_LE_FORNECEDOR_DB_SELECT_1_Query1.Execute(r1010_LE_FORNECEDOR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FORNECED_COD_FORNECEDOR, FORNECED.DCLFORNECEDORES.FORNECED_COD_FORNECEDOR);
                _.Move(executed_1.FORNECED_NOME_FORNECEDOR, FORNECED.DCLFORNECEDORES.FORNECED_NOME_FORNECEDOR);
                _.Move(executed_1.FORNECED_COD_SERVICO_ISS, FORNECED.DCLFORNECEDORES.FORNECED_COD_SERVICO_ISS);
                _.Move(executed_1.FORNECED_COD_BANCO, FORNECED.DCLFORNECEDORES.FORNECED_COD_BANCO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_EXIT*/

        [StopWatch]
        /*" R1020-MIN-INDENIZACAO-CREDINT */
        private void R1020_MIN_INDENIZACAO_CREDINT(bool isPerform = false)
        {
            /*" -2005- MOVE '022' TO WNR-EXEC-SQL. */
            _.Move("022", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -2014- PERFORM R1020_MIN_INDENIZACAO_CREDINT_DB_SELECT_1 */

            R1020_MIN_INDENIZACAO_CREDINT_DB_SELECT_1();

            /*" -2017- IF (SQLCODE NOT = 0) */

            if ((DB.SQLCODE != 0))
            {

                /*" -2018- DISPLAY 'ERRO NO SELECT MIN DA SINISTRO_HISTORICO' */
                _.Display($"ERRO NO SELECT MIN DA SINISTRO_HISTORICO");

                /*" -2019- DISPLAY 'SINISTRO     : ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO     : {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -2020- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -2020- END-IF. */
            }


        }

        [StopWatch]
        /*" R1020-MIN-INDENIZACAO-CREDINT-DB-SELECT-1 */
        public void R1020_MIN_INDENIZACAO_CREDINT_DB_SELECT_1()
        {
            /*" -2014- EXEC SQL SELECT VALUE(MIN(A.DATA_MOVIMENTO), '9999-12-31' ) INTO :HOST-MIN-DATA-MOVIMENTO FROM SEGUROS.SINISTRO_HISTORICO A, SEGUROS.GE_OPERACAO B WHERE A.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND B.FUNCAO_OPERACAO = 'IND' AND A.COD_OPERACAO = B.COD_OPERACAO AND B.IDE_SISTEMA = 'SI' END-EXEC. */

            var r1020_MIN_INDENIZACAO_CREDINT_DB_SELECT_1_Query1 = new R1020_MIN_INDENIZACAO_CREDINT_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R1020_MIN_INDENIZACAO_CREDINT_DB_SELECT_1_Query1.Execute(r1020_MIN_INDENIZACAO_CREDINT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_MIN_DATA_MOVIMENTO, HOST_MIN_DATA_MOVIMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1020_EXIT*/

        [StopWatch]
        /*" R1100-INSERT-HISTSINI */
        private void R1100_INSERT_HISTSINI(bool isPerform = false)
        {
            /*" -2053- MOVE '023' TO WNR-EXEC-SQL. */
            _.Move("023", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -2104- PERFORM R1100_INSERT_HISTSINI_DB_INSERT_1 */

            R1100_INSERT_HISTSINI_DB_INSERT_1();

            /*" -2107- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -2108- DISPLAY 'INSERT SINISTRO_HISTORICO ' */
                _.Display($"INSERT SINISTRO_HISTORICO ");

                /*" -2109- DISPLAY 'NUMERO SINISTRO = ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"NUMERO SINISTRO = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -2110- DISPLAY 'OPERACAO = ' SINISHIS-COD-OPERACAO */
                _.Display($"OPERACAO = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO}");

                /*" -2111- DISPLAY 'OCOHIST  = ' SINISHIS-OCORR-HISTORICO */
                _.Display($"OCOHIST  = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}");

                /*" -2112- DISPLAY 'TITULO   = ' MOVIMCOB-NUM-NOSSO-TITULO */
                _.Display($"TITULO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}");

                /*" -2112- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1100-INSERT-HISTSINI-DB-INSERT-1 */
        public void R1100_INSERT_HISTSINI_DB_INSERT_1()
        {
            /*" -2104- EXEC SQL INSERT INTO SEGUROS.SINISTRO_HISTORICO (COD_EMPRESA, TIPO_REGISTRO, NUM_APOL_SINISTRO, OCORR_HISTORICO, COD_OPERACAO, DATA_MOVIMENTO, HORA_OPERACAO, NOME_FAVORECIDO, VAL_OPERACAO, DATA_LIM_CORRECAO, TIPO_FAVORECIDO, DATA_NEGOCIADA, FONTE_PAGAMENTO, COD_PREST_SERVICO, COD_SERVICO, ORDEM_PAGAMENTO, NUM_RECIBO, NUM_MOV_SINISTRO, COD_USUARIO, SIT_CONTABIL, SIT_REGISTRO, TIMESTAMP, NUM_APOLICE, COD_PRODUTO, NOM_PROGRAMA) VALUES (:SINISHIS-COD-EMPRESA, :SINISHIS-TIPO-REGISTRO, :SINISHIS-NUM-APOL-SINISTRO, :SINISHIS-OCORR-HISTORICO, :SINISHIS-COD-OPERACAO, :SINISHIS-DATA-MOVIMENTO, CURRENT TIME , :SINISHIS-NOME-FAVORECIDO, :SINISHIS-VAL-OPERACAO, :SINISHIS-DATA-LIM-CORRECAO, :SINISHIS-TIPO-FAVORECIDO, :SINISHIS-DATA-NEGOCIADA, :SINISHIS-FONTE-PAGAMENTO, :SINISHIS-COD-PREST-SERVICO, :SINISHIS-COD-SERVICO, :SINISHIS-ORDEM-PAGAMENTO, :SINISHIS-NUM-RECIBO, :SINISHIS-NUM-MOV-SINISTRO, 'RESSARC' , :SINISHIS-SIT-CONTABIL, :SINISHIS-SIT-REGISTRO, CURRENT TIMESTAMP, :SINISHIS-NUM-APOLICE, :SINISHIS-COD-PRODUTO, 'SI0211B' ) END-EXEC. */

            var r1100_INSERT_HISTSINI_DB_INSERT_1_Insert1 = new R1100_INSERT_HISTSINI_DB_INSERT_1_Insert1()
            {
                SINISHIS_COD_EMPRESA = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_EMPRESA.ToString(),
                SINISHIS_TIPO_REGISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_TIPO_REGISTRO.ToString(),
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
                SINISHIS_COD_OPERACAO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.ToString(),
                SINISHIS_DATA_MOVIMENTO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO.ToString(),
                SINISHIS_NOME_FAVORECIDO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO.ToString(),
                SINISHIS_VAL_OPERACAO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO.ToString(),
                SINISHIS_DATA_LIM_CORRECAO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_LIM_CORRECAO.ToString(),
                SINISHIS_TIPO_FAVORECIDO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_TIPO_FAVORECIDO.ToString(),
                SINISHIS_DATA_NEGOCIADA = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_NEGOCIADA.ToString(),
                SINISHIS_FONTE_PAGAMENTO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_FONTE_PAGAMENTO.ToString(),
                SINISHIS_COD_PREST_SERVICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO.ToString(),
                SINISHIS_COD_SERVICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_SERVICO.ToString(),
                SINISHIS_ORDEM_PAGAMENTO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_ORDEM_PAGAMENTO.ToString(),
                SINISHIS_NUM_RECIBO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_RECIBO.ToString(),
                SINISHIS_NUM_MOV_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_MOV_SINISTRO.ToString(),
                SINISHIS_SIT_CONTABIL = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL.ToString(),
                SINISHIS_SIT_REGISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_REGISTRO.ToString(),
                SINISHIS_NUM_APOLICE = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOLICE.ToString(),
                SINISHIS_COD_PRODUTO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PRODUTO.ToString(),
            };

            R1100_INSERT_HISTSINI_DB_INSERT_1_Insert1.Execute(r1100_INSERT_HISTSINI_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_EXIT*/

        [StopWatch]
        /*" R1150-CANCELA-OPERACAO */
        private void R1150_CANCELA_OPERACAO(bool isPerform = false)
        {
            /*" -2120- MOVE '024' TO WNR-EXEC-SQL. */
            _.Move("024", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -2126- PERFORM R1150_CANCELA_OPERACAO_DB_UPDATE_1 */

            R1150_CANCELA_OPERACAO_DB_UPDATE_1();

            /*" -2129- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -2130- DISPLAY 'ERRO NO UPDATE SINISTRO_HISTORICO' */
                _.Display($"ERRO NO UPDATE SINISTRO_HISTORICO");

                /*" -2131- DISPLAY 'SINISTRO     : ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO     : {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -2132- DISPLAY 'OCORHIST     : ' SINISHIS-OCORR-HISTORICO */
                _.Display($"OCORHIST     : {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}");

                /*" -2133- DISPLAY 'OPERACAO     : ' SINISHIS-COD-OPERACAO */
                _.Display($"OPERACAO     : {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO}");

                /*" -2133- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1150-CANCELA-OPERACAO-DB-UPDATE-1 */
        public void R1150_CANCELA_OPERACAO_DB_UPDATE_1()
        {
            /*" -2126- EXEC SQL UPDATE SEGUROS.SINISTRO_HISTORICO SET SIT_REGISTRO = :SINISHIS-SIT-REGISTRO WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND COD_OPERACAO = :SINISHIS-COD-OPERACAO END-EXEC. */

            var r1150_CANCELA_OPERACAO_DB_UPDATE_1_Update1 = new R1150_CANCELA_OPERACAO_DB_UPDATE_1_Update1()
            {
                SINISHIS_SIT_REGISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_REGISTRO.ToString(),
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
                SINISHIS_COD_OPERACAO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.ToString(),
            };

            R1150_CANCELA_OPERACAO_DB_UPDATE_1_Update1.Execute(r1150_CANCELA_OPERACAO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1150_EXIT*/

        [StopWatch]
        /*" R6100-LE-VALOR-BASE-HONORARIO */
        private void R6100_LE_VALOR_BASE_HONORARIO(bool isPerform = false)
        {
            /*" -2141- MOVE '025' TO WNR-EXEC-SQL. */
            _.Move("025", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -2152- PERFORM R6100_LE_VALOR_BASE_HONORARIO_DB_SELECT_1 */

            R6100_LE_VALOR_BASE_HONORARIO_DB_SELECT_1();

            /*" -2155- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2156- DISPLAY 'ERRO NO SUM PRINC + ACRESC SINISTRO_HISTORICO' */
                _.Display($"ERRO NO SUM PRINC + ACRESC SINISTRO_HISTORICO");

                /*" -2157- DISPLAY 'ACESSO AO AVISO DE PROVISAO - PRINCIPAL' */
                _.Display($"ACESSO AO AVISO DE PROVISAO - PRINCIPAL");

                /*" -2158- DISPLAY 'NUM_APOL_SINISTRO  = ' SI111-NUM-APOL-SINISTRO */
                _.Display($"NUM_APOL_SINISTRO  = {SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO}");

                /*" -2159- DISPLAY 'OCORR_HISTORICO    = ' SI111-OCORR-HISTORICO */
                _.Display($"OCORR_HISTORICO    = {SI111.DCLSI_RESSARC_PARCELA.SI111_OCORR_HISTORICO}");

                /*" -2159- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R6100-LE-VALOR-BASE-HONORARIO-DB-SELECT-1 */
        public void R6100_LE_VALOR_BASE_HONORARIO_DB_SELECT_1()
        {
            /*" -2152- EXEC SQL SELECT VALUE(SUM(H.VAL_OPERACAO),0) INTO :HOST-VALOR-PAGTO-HON-REPASSE FROM SEGUROS.SINISTRO_HISTORICO H, SEGUROS.GE_OPERACAO O WHERE H.NUM_APOL_SINISTRO = :SI111-NUM-APOL-SINISTRO AND H.OCORR_HISTORICO = :SI111-OCORR-HISTORICO AND O.COD_OPERACAO = H.COD_OPERACAO AND O.IND_TIPO_FUNCAO = 'RESSA-RECE' AND O.COD_OPERACAO IN ( 4101 , 4102 ) AND O.IDE_SISTEMA = 'SI' END-EXEC. */

            var r6100_LE_VALOR_BASE_HONORARIO_DB_SELECT_1_Query1 = new R6100_LE_VALOR_BASE_HONORARIO_DB_SELECT_1_Query1()
            {
                SI111_NUM_APOL_SINISTRO = SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO.ToString(),
                SI111_OCORR_HISTORICO = SI111.DCLSI_RESSARC_PARCELA.SI111_OCORR_HISTORICO.ToString(),
            };

            var executed_1 = R6100_LE_VALOR_BASE_HONORARIO_DB_SELECT_1_Query1.Execute(r6100_LE_VALOR_BASE_HONORARIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_VALOR_PAGTO_HON_REPASSE, AREA_DE_WORK.HOST_VALOR_PAGTO_HON_REPASSE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6100_EXIT*/

        [StopWatch]
        /*" R6150-LE-PERCENTUAL-HONORARIO */
        private void R6150_LE_PERCENTUAL_HONORARIO(bool isPerform = false)
        {
            /*" -2166- MOVE '025' TO WNR-EXEC-SQL. */
            _.Move("025", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -2168- INITIALIZE WS-TEM-HONORARIO */
            _.Initialize(
                AREA_DE_WORK.WS_TEM_HONORARIO
            );

            /*" -2175- PERFORM R6150_LE_PERCENTUAL_HONORARIO_DB_SELECT_1 */

            R6150_LE_PERCENTUAL_HONORARIO_DB_SELECT_1();

            /*" -2179- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL +100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != +100)
            {

                /*" -2180- DISPLAY 'ERRO ACESSO PCT_OPERACAO P/ % HON. - OPE. 4003' */
                _.Display($"ERRO ACESSO PCT_OPERACAO P/ % HON. - OPE. 4003");

                /*" -2181- DISPLAY 'ACESSO AO AVISO DE PROVISAO - PRINCIPAL' */
                _.Display($"ACESSO AO AVISO DE PROVISAO - PRINCIPAL");

                /*" -2182- DISPLAY 'NUM_APOL_SINISTRO  = ' SI111-NUM-APOL-SINISTRO */
                _.Display($"NUM_APOL_SINISTRO  = {SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO}");

                /*" -2183- DISPLAY 'OCORR_HISTORICO    = ' SI111-OCORR-HISTORICO */
                _.Display($"OCORR_HISTORICO    = {SI111.DCLSI_RESSARC_PARCELA.SI111_OCORR_HISTORICO}");

                /*" -2184- DISPLAY 'COD_OPERACAO       = 4003' */
                _.Display($"COD_OPERACAO       = 4003");

                /*" -2185- DISPLAY 'SQLCODE            = ' SQLCODE */
                _.Display($"SQLCODE            = {DB.SQLCODE}");

                /*" -2186- DISPLAY 'PCT-OPERACAO       = ' HOST-PCT-OPERACAO */
                _.Display($"PCT-OPERACAO       = {HOST_PCT_OPERACAO}");

                /*" -2188- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -2189- IF SQLCODE EQUAL +100 */

            if (DB.SQLCODE == +100)
            {

                /*" -2190- MOVE ZEROS TO HOST-PCT-OPERACAO */
                _.Move(0, HOST_PCT_OPERACAO);

                /*" -2190- MOVE 'N' TO WS-TEM-HONORARIO. */
                _.Move("N", AREA_DE_WORK.WS_TEM_HONORARIO);
            }


        }

        [StopWatch]
        /*" R6150-LE-PERCENTUAL-HONORARIO-DB-SELECT-1 */
        public void R6150_LE_PERCENTUAL_HONORARIO_DB_SELECT_1()
        {
            /*" -2175- EXEC SQL SELECT VALUE(PCT_OPERACAO,0) INTO :HOST-PCT-OPERACAO FROM SEGUROS.SI_RESSARC_PARCELA P WHERE P.NUM_APOL_SINISTRO = :SI111-NUM-APOL-SINISTRO AND P.OCORR_HISTORICO = :SI111-OCORR-HISTORICO AND P.COD_OPERACAO = 4003 END-EXEC. */

            var r6150_LE_PERCENTUAL_HONORARIO_DB_SELECT_1_Query1 = new R6150_LE_PERCENTUAL_HONORARIO_DB_SELECT_1_Query1()
            {
                SI111_NUM_APOL_SINISTRO = SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO.ToString(),
                SI111_OCORR_HISTORICO = SI111.DCLSI_RESSARC_PARCELA.SI111_OCORR_HISTORICO.ToString(),
            };

            var executed_1 = R6150_LE_PERCENTUAL_HONORARIO_DB_SELECT_1_Query1.Execute(r6150_LE_PERCENTUAL_HONORARIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_PCT_OPERACAO, HOST_PCT_OPERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6150_EXIT*/

        [StopWatch]
        /*" R6200-CALC-HONORARIO */
        private void R6200_CALC_HONORARIO(bool isPerform = false)
        {
            /*" -2211- MOVE W-VAL-COMISSAO-HONORARIO TO SINISHIS-VAL-OPERACAO. */
            _.Move(AREA_DE_WORK.W_VAL_COMISSAO_HONORARIO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);

            /*" -2212- MOVE 8000 TO W-VALOR-LIMITE-01. */
            _.Move(8000, AREA_DE_WORK.W_VALOR_LIMITE_01);

            /*" -2213- MOVE 20 TO W-PERC-COMISSAO-HON-PADRAO-01. */
            _.Move(20, AREA_DE_WORK.W_PERC_COMISSAO_HON_PADRAO_01);

            /*" -2214- MOVE 10 TO W-PERC-COMISSAO-HON-PADRAO-02. */
            _.Move(10, AREA_DE_WORK.W_PERC_COMISSAO_HON_PADRAO_02);

            /*" -2216- MOVE 3 TO W-PERC-COMISSAO-DES-PADRAO-01. */
            _.Move(3, AREA_DE_WORK.W_PERC_COMISSAO_DES_PADRAO_01);

            /*" -2220- MOVE SI112-VLR-TOTAL-ACORDO TO W-VALOR-LIMITE-TESTE. */
            _.Move(SI112.DCLSI_RESSARC_ACORDO.SI112_VLR_TOTAL_ACORDO, W_VALOR_LIMITE_TESTE);

            /*" -2221- IF SI112-VLR-TOTAL-ACORDO <= W-VALOR-LIMITE-01 */

            if (SI112.DCLSI_RESSARC_ACORDO.SI112_VLR_TOTAL_ACORDO <= AREA_DE_WORK.W_VALOR_LIMITE_01)
            {

                /*" -2224- COMPUTE W-PERC-HONORARIO-FINAL = W-PERC-COMISSAO-HON-PADRAO-01 + W-PERC-COMISSAO-DES-PADRAO-01 */
                AREA_DE_WORK.W_PERC_HONORARIO_FINAL.Value = AREA_DE_WORK.W_PERC_COMISSAO_HON_PADRAO_01 + AREA_DE_WORK.W_PERC_COMISSAO_DES_PADRAO_01;

                /*" -2227- GO TO R6200-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R6200_EXIT*/ //GOTO
                return;
            }


            /*" -2231- COMPUTE W-VAL-PERC-VAL-LIMITE-01 = (W-VALOR-LIMITE-01 / 100) * W-PERC-COMISSAO-HON-PADRAO-01. */
            AREA_DE_WORK.W_VAL_PERC_VAL_LIMITE_01.Value = (AREA_DE_WORK.W_VALOR_LIMITE_01 / 100f) * AREA_DE_WORK.W_PERC_COMISSAO_HON_PADRAO_01;

            /*" -2246- COMPUTE W-VAL-EXCEDENTE-LIMITE = SI112-VLR-TOTAL-ACORDO - W-VALOR-LIMITE-01. */
            AREA_DE_WORK.W_VAL_EXCEDENTE_LIMITE.Value = SI112.DCLSI_RESSARC_ACORDO.SI112_VLR_TOTAL_ACORDO - AREA_DE_WORK.W_VALOR_LIMITE_01;

            /*" -2251- COMPUTE W-VAL-PERC-VAL-LIMITE-02 = (W-VAL-EXCEDENTE-LIMITE / 100) * W-PERC-COMISSAO-HON-PADRAO-02. */
            AREA_DE_WORK.W_VAL_PERC_VAL_LIMITE_02.Value = (AREA_DE_WORK.W_VAL_EXCEDENTE_LIMITE / 100f) * AREA_DE_WORK.W_PERC_COMISSAO_HON_PADRAO_02;

            /*" -2258- COMPUTE W-VAL-TOTAL-DEVIDO-COMISSAO = W-VAL-PERC-VAL-LIMITE-01 + W-VAL-PERC-VAL-LIMITE-02. */
            AREA_DE_WORK.W_VAL_TOTAL_DEVIDO_COMISSAO.Value = AREA_DE_WORK.W_VAL_PERC_VAL_LIMITE_01 + AREA_DE_WORK.W_VAL_PERC_VAL_LIMITE_02;

            /*" -2263- COMPUTE W-PERC-HONORARIO = (W-VAL-TOTAL-DEVIDO-COMISSAO * 100) / SI112-VLR-TOTAL-ACORDO. */
            AREA_DE_WORK.W_PERC_HONORARIO.Value = (AREA_DE_WORK.W_VAL_TOTAL_DEVIDO_COMISSAO * 100) / SI112.DCLSI_RESSARC_ACORDO.SI112_VLR_TOTAL_ACORDO;

            /*" -2265- COMPUTE W-PERC-HONORARIO-FINAL = W-PERC-HONORARIO + W-PERC-COMISSAO-DES-PADRAO-01. */
            AREA_DE_WORK.W_PERC_HONORARIO_FINAL.Value = AREA_DE_WORK.W_PERC_HONORARIO + AREA_DE_WORK.W_PERC_COMISSAO_DES_PADRAO_01;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6200_EXIT*/

        [StopWatch]
        /*" R6300-CALC-REPASSE */
        private void R6300_CALC_REPASSE(bool isPerform = false)
        {
            /*" -2292- MOVE '026' TO WNR-EXEC-SQL. */
            _.Move("026", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -2298- PERFORM R6300_CALC_REPASSE_DB_SELECT_1 */

            R6300_CALC_REPASSE_DB_SELECT_1();

            /*" -2301- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -2302- DISPLAY 'ERRO NO COUNT(*) DA SINISTRO_HABIT01' */
                _.Display($"ERRO NO COUNT(*) DA SINISTRO_HABIT01");

                /*" -2303- DISPLAY 'SINISTRO     : ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO     : {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -2305- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -2306- IF HOST-COUNT NOT EQUAL 0 */

            if (HOST_COUNT != 0)
            {

                /*" -2307- MOVE 20 TO W-PERCENTUAL-REPASSE */
                _.Move(20, AREA_DE_WORK.W_PERCENTUAL_REPASSE);

                /*" -2308- GO TO R6300-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R6300_EXIT*/ //GOTO
                return;

                /*" -2309- ELSE */
            }
            else
            {


                /*" -2309- GO TO R6300-PESQUISA-CREDITO-INTERNO. */

                R6300_PESQUISA_CREDITO_INTERNO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R6300-CALC-REPASSE-DB-SELECT-1 */
        public void R6300_CALC_REPASSE_DB_SELECT_1()
        {
            /*" -2298- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :HOST-COUNT FROM SEGUROS.SINISTRO_HABIT01 WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO WITH UR END-EXEC. */

            var r6300_CALC_REPASSE_DB_SELECT_1_Query1 = new R6300_CALC_REPASSE_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R6300_CALC_REPASSE_DB_SELECT_1_Query1.Execute(r6300_CALC_REPASSE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_COUNT, HOST_COUNT);
            }


        }

        [StopWatch]
        /*" R6300-PESQUISA-CREDITO-INTERNO */
        private void R6300_PESQUISA_CREDITO_INTERNO(bool isPerform = false)
        {
            /*" -2315- MOVE '027' TO WNR-EXEC-SQL. */
            _.Move("027", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -2321- PERFORM R6300_PESQUISA_CREDITO_INTERNO_DB_SELECT_1 */

            R6300_PESQUISA_CREDITO_INTERNO_DB_SELECT_1();

            /*" -2324- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -2325- DISPLAY 'ERRO NO SELECT OPERACAO DA SINISTRO_CRED_INT' */
                _.Display($"ERRO NO SELECT OPERACAO DA SINISTRO_CRED_INT");

                /*" -2326- DISPLAY 'SINISTRO     : ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO     : {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -2330- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -2332- MOVE 'SIM' TO W-CHAVE-CREDITO-INTERNO */
            _.Move("SIM", AREA_DE_WORK.W_CHAVE_CREDITO_INTERNO);

            /*" -2336- IF SINCREIN-COD-OPERACAO = 105 OR 106 OR 107 OR 110 OR 111 OR 148 OR 149 OR 150 OR 151 OR 152 OR 190 OR 191 OR 15 */

            if (SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_OPERACAO.In("105", "106", "107", "110", "111", "148", "149", "150", "151", "152", "190", "191", "15"))
            {

                /*" -2337- MOVE 10 TO W-PERCENTUAL-REPASSE */
                _.Move(10, AREA_DE_WORK.W_PERCENTUAL_REPASSE);

                /*" -2338- ELSE */
            }
            else
            {


                /*" -2345- IF SINCREIN-COD-OPERACAO = 171 OR 173 OR 174 OR 181 OR 182 OR 649 OR 650 OR 652 OR 653 OR 690 OR 691 OR 692 OR 701 OR 702 OR 703 OR 704 OR 731 OR 705 OR 160 */

                if (SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_OPERACAO.In("171", "173", "174", "181", "182", "649", "650", "652", "653", "690", "691", "692", "701", "702", "703", "704", "731", "705", "160"))
                {

                    /*" -2346- MOVE 15 TO W-PERCENTUAL-REPASSE */
                    _.Move(15, AREA_DE_WORK.W_PERCENTUAL_REPASSE);

                    /*" -2347- ELSE */
                }
                else
                {


                    /*" -2348- DISPLAY 'ERRO IMPREVISTO NA IDENTIFICACAO DA OPERACAO DO' */
                    _.Display($"ERRO IMPREVISTO NA IDENTIFICACAO DA OPERACAO DO");

                    /*" -2349- DISPLAY 'CONTRATO DE CREDITO INTERNO PARA CALCULO REPASSE' */
                    _.Display($"CONTRATO DE CREDITO INTERNO PARA CALCULO REPASSE");

                    /*" -2350- DISPLAY 'PROGRAMA ABENDADO NA MAO GRANDE' */
                    _.Display($"PROGRAMA ABENDADO NA MAO GRANDE");

                    /*" -2351- DISPLAY 'NUM_APOL_SINISTRO    = ' SINISHIS-NUM-APOL-SINISTRO */
                    _.Display($"NUM_APOL_SINISTRO    = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                    /*" -2352- DISPLAY 'SINCREIN-COD-OPERACAO = ' SINCREIN-COD-OPERACAO */
                    _.Display($"SINCREIN-COD-OPERACAO = {SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_OPERACAO}");

                    /*" -2352- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R6300-PESQUISA-CREDITO-INTERNO-DB-SELECT-1 */
        public void R6300_PESQUISA_CREDITO_INTERNO_DB_SELECT_1()
        {
            /*" -2321- EXEC SQL SELECT COD_OPERACAO INTO :SINCREIN-COD-OPERACAO FROM SEGUROS.SINISTRO_CRED_INT WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO WITH UR END-EXEC. */

            var r6300_PESQUISA_CREDITO_INTERNO_DB_SELECT_1_Query1 = new R6300_PESQUISA_CREDITO_INTERNO_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R6300_PESQUISA_CREDITO_INTERNO_DB_SELECT_1_Query1.Execute(r6300_PESQUISA_CREDITO_INTERNO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINCREIN_COD_OPERACAO, SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_OPERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6300_EXIT*/

        [StopWatch]
        /*" R120-GRAVA-ARQ-SAIDA */
        private void R120_GRAVA_ARQ_SAIDA(bool isPerform = false)
        {
            /*" -2360- MOVE SI111-NUM-APOL-SINISTRO TO LD01-NUM-APOL-SINISTRO. */
            _.Move(SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO, AREA_DE_WORK.LD01.LD01_NUM_APOL_SINISTRO);

            /*" -2361- MOVE SI111-NUM-RESSARC TO LD01-NUM-ACORDO. */
            _.Move(SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_RESSARC, AREA_DE_WORK.LD01.LD01_NUM_ACORDO);

            /*" -2362- MOVE MOVIMCOB-NUM-NOSSO-TITULO TO LD01-NUM-TITULO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO, AREA_DE_WORK.LD01.LD01_NUM_TITULO);

            /*" -2363- MOVE SI111-DTH-VENCIMENTO TO LD01-DATA-VENCIMENTO. */
            _.Move(SI111.DCLSI_RESSARC_PARCELA.SI111_DTH_VENCIMENTO, AREA_DE_WORK.LD01.LD01_DATA_VENCIMENTO);

            /*" -2364- MOVE SI111-NUM-PARCELA TO LD01-NUM-PARCELA. */
            _.Move(SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_PARCELA, AREA_DE_WORK.LD01.LD01_NUM_PARCELA);

            /*" -2365- MOVE MOVIMCOB-VAL-TITULO TO LD01-VALOR-RECEBIDO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO, AREA_DE_WORK.LD01.LD01_VALOR_RECEBIDO);

            /*" -2366- MOVE SI111-DTH-PAGAMENTO TO LD01-DATA-PAGAMENTO. */
            _.Move(SI111.DCLSI_RESSARC_PARCELA.SI111_DTH_PAGAMENTO, AREA_DE_WORK.LD01.LD01_DATA_PAGAMENTO);

            /*" -2369- MOVE SISTEMAS-DATA-MOV-ABERTO TO LD01-DATA-PROCESSAMENTO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREA_DE_WORK.LD01.LD01_DATA_PROCESSAMENTO);

            /*" -2370- MOVE '1' TO LD01-IND-ORIGEM. */
            _.Move("1", AREA_DE_WORK.LD01.LD01_IND_ORIGEM);

            /*" -2373- MOVE 'SISTEMA COBRANCA' TO LD01-MSG-ORIGEM. */
            _.Move("SISTEMA COBRANCA", AREA_DE_WORK.LD01.LD01_MSG_ORIGEM);

            /*" -2374- MOVE '1' TO LD01-IND-TIPO-BAIXA. */
            _.Move("1", AREA_DE_WORK.LD01.LD01_IND_TIPO_BAIXA);

            /*" -2377- MOVE 'AUTOMATICA' TO LD01-TIPO-BAIXA. */
            _.Move("AUTOMATICA", AREA_DE_WORK.LD01.LD01_TIPO_BAIXA);

            /*" -2377- WRITE REGISTRO-RETORNO FROM LD01. */
            _.Move(AREA_DE_WORK.LD01.GetMoveValues(), REGISTRO_RETORNO);

            ARQRET.Write(REGISTRO_RETORNO.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/

        [StopWatch]
        /*" R1200-INSERT-PARCELA */
        private void R1200_INSERT_PARCELA(bool isPerform = false)
        {
            /*" -2385- MOVE '035' TO WNR-EXEC-SQL. */
            _.Move("035", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -2424- PERFORM R1200_INSERT_PARCELA_DB_INSERT_1 */

            R1200_INSERT_PARCELA_DB_INSERT_1();

            /*" -2435- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -2436- DISPLAY 'ERRO NO INSERT DA SI_RESSARC_PARCELA' */
                _.Display($"ERRO NO INSERT DA SI_RESSARC_PARCELA");

                /*" -2437- DISPLAY 'NUMERO SINISTRO = ' SI111-NUM-APOL-SINISTRO */
                _.Display($"NUMERO SINISTRO = {SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO}");

                /*" -2438- DISPLAY 'OPERACAO        = ' SI111-COD-OPERACAO */
                _.Display($"OPERACAO        = {SI111.DCLSI_RESSARC_PARCELA.SI111_COD_OPERACAO}");

                /*" -2439- DISPLAY 'OCOHIST         = ' SI111-OCORR-HISTORICO */
                _.Display($"OCOHIST         = {SI111.DCLSI_RESSARC_PARCELA.SI111_OCORR_HISTORICO}");

                /*" -2440- DISPLAY 'PARCELA         = ' SI111-NUM-PARCELA */
                _.Display($"PARCELA         = {SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_PARCELA}");

                /*" -2441- DISPLAY 'TITULO          = ' MOVIMCOB-NUM-NOSSO-TITULO */
                _.Display($"TITULO          = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}");

                /*" -2441- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1200-INSERT-PARCELA-DB-INSERT-1 */
        public void R1200_INSERT_PARCELA_DB_INSERT_1()
        {
            /*" -2424- EXEC SQL INSERT INTO SEGUROS.SI_RESSARC_PARCELA (NUM_APOL_SINISTRO , OCORR_HISTORICO , COD_OPERACAO , NUM_RESSARC , SEQ_RESSARC , NUM_PARCELA , COD_AGENCIA_CEDENT , COD_SISTEMA_ORIGEM , NUM_CEDENTE , NUM_CEDENTE_DV , DTH_VENCIMENTO , NUM_NOSSO_TITULO , DTH_CADASTRAMENTO , PCT_OPERACAO , IND_FORMA_BAIXA , NOM_PROGRAMA , DTH_PAGAMENTO , IND_INTEGRACAO , NUM_TITULO_SIGCB ) VALUES (:SI111-NUM-APOL-SINISTRO, :SI111-OCORR-HISTORICO, :SI111-COD-OPERACAO, :SI111-NUM-RESSARC, :SI111-SEQ-RESSARC, :SI111-NUM-PARCELA, :SI111-COD-AGENCIA-CEDENT, :SI111-COD-SISTEMA-ORIGEM, :SI111-NUM-CEDENTE, :SI111-NUM-CEDENTE-DV, :SI111-DTH-VENCIMENTO, :SI111-NUM-NOSSO-TITULO, CURRENT TIMESTAMP, :SI111-PCT-OPERACAO, :SI111-IND-FORMA-BAIXA, :SI111-NOM-PROGRAMA, :SI111-DTH-PAGAMENTO, :SI111-IND-INTEGRACAO, :SI111-NUM-TITULO-SIGCB:VIND-TIT-SIGCB ) END-EXEC. */

            var r1200_INSERT_PARCELA_DB_INSERT_1_Insert1 = new R1200_INSERT_PARCELA_DB_INSERT_1_Insert1()
            {
                SI111_NUM_APOL_SINISTRO = SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO.ToString(),
                SI111_OCORR_HISTORICO = SI111.DCLSI_RESSARC_PARCELA.SI111_OCORR_HISTORICO.ToString(),
                SI111_COD_OPERACAO = SI111.DCLSI_RESSARC_PARCELA.SI111_COD_OPERACAO.ToString(),
                SI111_NUM_RESSARC = SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_RESSARC.ToString(),
                SI111_SEQ_RESSARC = SI111.DCLSI_RESSARC_PARCELA.SI111_SEQ_RESSARC.ToString(),
                SI111_NUM_PARCELA = SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_PARCELA.ToString(),
                SI111_COD_AGENCIA_CEDENT = SI111.DCLSI_RESSARC_PARCELA.SI111_COD_AGENCIA_CEDENT.ToString(),
                SI111_COD_SISTEMA_ORIGEM = SI111.DCLSI_RESSARC_PARCELA.SI111_COD_SISTEMA_ORIGEM.ToString(),
                SI111_NUM_CEDENTE = SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_CEDENTE.ToString(),
                SI111_NUM_CEDENTE_DV = SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_CEDENTE_DV.ToString(),
                SI111_DTH_VENCIMENTO = SI111.DCLSI_RESSARC_PARCELA.SI111_DTH_VENCIMENTO.ToString(),
                SI111_NUM_NOSSO_TITULO = SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_NOSSO_TITULO.ToString(),
                SI111_PCT_OPERACAO = SI111.DCLSI_RESSARC_PARCELA.SI111_PCT_OPERACAO.ToString(),
                SI111_IND_FORMA_BAIXA = SI111.DCLSI_RESSARC_PARCELA.SI111_IND_FORMA_BAIXA.ToString(),
                SI111_NOM_PROGRAMA = SI111.DCLSI_RESSARC_PARCELA.SI111_NOM_PROGRAMA.ToString(),
                SI111_DTH_PAGAMENTO = SI111.DCLSI_RESSARC_PARCELA.SI111_DTH_PAGAMENTO.ToString(),
                SI111_IND_INTEGRACAO = SI111.DCLSI_RESSARC_PARCELA.SI111_IND_INTEGRACAO.ToString(),
                SI111_NUM_TITULO_SIGCB = SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_TITULO_SIGCB.ToString(),
                VIND_TIT_SIGCB = VIND_TIT_SIGCB.ToString(),
            };

            R1200_INSERT_PARCELA_DB_INSERT_1_Insert1.Execute(r1200_INSERT_PARCELA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_EXIT*/

        [StopWatch]
        /*" R1300-UPDATE-COBRANCA */
        private void R1300_UPDATE_COBRANCA(bool isPerform = false)
        {
            /*" -2466- PERFORM R1300_UPDATE_COBRANCA_DB_UPDATE_1 */

            R1300_UPDATE_COBRANCA_DB_UPDATE_1();

            /*" -2469- IF (SQLCODE NOT = ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -2470- DISPLAY 'ERRO NO UPDATE MOVIMENTO_COBRANCA' */
                _.Display($"ERRO NO UPDATE MOVIMENTO_COBRANCA");

                /*" -2471- DISPLAY 'ACESSO AO AVISO DE PROVISAO - PRINCIPAL' */
                _.Display($"ACESSO AO AVISO DE PROVISAO - PRINCIPAL");

                /*" -2472- DISPLAY 'NUM_APOL_SINISTRO  = ' SI111-NUM-APOL-SINISTRO */
                _.Display($"NUM_APOL_SINISTRO  = {SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO}");

                /*" -2473- DISPLAY 'OCORR_HISTORICO    = ' SI111-OCORR-HISTORICO */
                _.Display($"OCORR_HISTORICO    = {SI111.DCLSI_RESSARC_PARCELA.SI111_OCORR_HISTORICO}");

                /*" -2474- DISPLAY 'COD_OPERACAO       = ' SI111-COD-OPERACAO */
                _.Display($"COD_OPERACAO       = {SI111.DCLSI_RESSARC_PARCELA.SI111_COD_OPERACAO}");

                /*" -2475- DISPLAY 'NUM_NOSSO_TITULO  = ' MOVIMCOB-NUM-NOSSO-TITULO */
                _.Display($"NUM_NOSSO_TITULO  = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}");

                /*" -2476- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -2480- END-IF. */
            }


            /*" -2481- IF (HOST-SIT-REGISTRO = '1' ) */

            if ((HOST_SIT_REGISTRO == "1"))
            {

                /*" -2482- PERFORM R1400-UPDATE-AVISOS-SALDOS THRU R1400-EXIT */

                R1400_UPDATE_AVISOS_SALDOS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_EXIT*/


                /*" -2482- END-IF. */
            }


        }

        [StopWatch]
        /*" R1300-UPDATE-COBRANCA-DB-UPDATE-1 */
        public void R1300_UPDATE_COBRANCA_DB_UPDATE_1()
        {
            /*" -2466- EXEC SQL UPDATE SEGUROS.MOVIMENTO_COBRANCA SET SIT_REGISTRO = :HOST-SIT-REGISTRO WHERE COD_EMPRESA = :MOVIMCOB-COD-EMPRESA AND COD_MOVIMENTO = :MOVIMCOB-COD-MOVIMENTO AND COD_BANCO = :MOVIMCOB-COD-BANCO AND COD_AGENCIA = :MOVIMCOB-COD-AGENCIA AND NUM_AVISO = :MOVIMCOB-NUM-AVISO AND NUM_FITA = :MOVIMCOB-NUM-FITA AND DATA_MOVIMENTO = :MOVIMCOB-DATA-MOVIMENTO AND DATA_QUITACAO = :MOVIMCOB-DATA-QUITACAO AND NUM_TITULO = :MOVIMCOB-NUM-TITULO AND NUM_APOLICE = :MOVIMCOB-NUM-APOLICE AND NUM_ENDOSSO = :MOVIMCOB-NUM-ENDOSSO AND NUM_PARCELA = :MOVIMCOB-NUM-PARCELA AND TIPO_MOVIMENTO = :MOVIMCOB-TIPO-MOVIMENTO AND NUM_NOSSO_TITULO = :MOVIMCOB-NUM-NOSSO-TITULO END-EXEC. */

            var r1300_UPDATE_COBRANCA_DB_UPDATE_1_Update1 = new R1300_UPDATE_COBRANCA_DB_UPDATE_1_Update1()
            {
                HOST_SIT_REGISTRO = HOST_SIT_REGISTRO.ToString(),
                MOVIMCOB_NUM_NOSSO_TITULO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO.ToString(),
                MOVIMCOB_DATA_MOVIMENTO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_MOVIMENTO.ToString(),
                MOVIMCOB_TIPO_MOVIMENTO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_TIPO_MOVIMENTO.ToString(),
                MOVIMCOB_COD_MOVIMENTO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO.ToString(),
                MOVIMCOB_DATA_QUITACAO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_QUITACAO.ToString(),
                MOVIMCOB_COD_EMPRESA = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_EMPRESA.ToString(),
                MOVIMCOB_COD_AGENCIA = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA.ToString(),
                MOVIMCOB_NUM_APOLICE = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE.ToString(),
                MOVIMCOB_NUM_ENDOSSO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO.ToString(),
                MOVIMCOB_NUM_PARCELA = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA.ToString(),
                MOVIMCOB_NUM_TITULO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_TITULO.ToString(),
                MOVIMCOB_COD_BANCO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO.ToString(),
                MOVIMCOB_NUM_AVISO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO.ToString(),
                MOVIMCOB_NUM_FITA = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_FITA.ToString(),
            };

            R1300_UPDATE_COBRANCA_DB_UPDATE_1_Update1.Execute(r1300_UPDATE_COBRANCA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_EXIT*/

        [StopWatch]
        /*" R1400-UPDATE-AVISOS-SALDOS */
        private void R1400_UPDATE_AVISOS_SALDOS(bool isPerform = false)
        {
            /*" -2490- MOVE '028' TO WNR-EXEC-SQL. */
            _.Move("028", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -2496- PERFORM R1400_UPDATE_AVISOS_SALDOS_DB_UPDATE_1 */

            R1400_UPDATE_AVISOS_SALDOS_DB_UPDATE_1();

            /*" -2499- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2500- DISPLAY 'ERRO NO UPDATE AVISOS_SALDOS' */
                _.Display($"ERRO NO UPDATE AVISOS_SALDOS");

                /*" -2501- DISPLAY 'NUM_APOL_SINISTRO  = ' SI111-NUM-APOL-SINISTRO */
                _.Display($"NUM_APOL_SINISTRO  = {SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO}");

                /*" -2502- DISPLAY 'OCORR_HISTORICO    = ' SI111-OCORR-HISTORICO */
                _.Display($"OCORR_HISTORICO    = {SI111.DCLSI_RESSARC_PARCELA.SI111_OCORR_HISTORICO}");

                /*" -2503- DISPLAY 'COD_OPERACAO       = ' SI111-COD-OPERACAO */
                _.Display($"COD_OPERACAO       = {SI111.DCLSI_RESSARC_PARCELA.SI111_COD_OPERACAO}");

                /*" -2504- DISPLAY 'NUM_NOSSO_TITULO   = ' MOVIMCOB-NUM-NOSSO-TITULO */
                _.Display($"NUM_NOSSO_TITULO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}");

                /*" -2505- DISPLAY 'BCO_AVISO          = ' MOVIMCOB-COD-BANCO */
                _.Display($"BCO_AVISO          = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO}");

                /*" -2506- DISPLAY 'AGE_AVISO          = ' MOVIMCOB-COD-AGENCIA */
                _.Display($"AGE_AVISO          = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA}");

                /*" -2507- DISPLAY 'NUM_AVISO_CREDITO  = ' MOVIMCOB-NUM-AVISO */
                _.Display($"NUM_AVISO_CREDITO  = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO}");

                /*" -2507- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1400-UPDATE-AVISOS-SALDOS-DB-UPDATE-1 */
        public void R1400_UPDATE_AVISOS_SALDOS_DB_UPDATE_1()
        {
            /*" -2496- EXEC SQL UPDATE SEGUROS.AVISOS_SALDOS SET SALDO_ATUAL = SALDO_ATUAL - :MOVIMCOB-VAL-TITULO, TIMESTAMP = CURRENT TIMESTAMP WHERE BCO_AVISO = :MOVIMCOB-COD-BANCO AND AGE_AVISO = :MOVIMCOB-COD-AGENCIA AND NUM_AVISO_CREDITO = :MOVIMCOB-NUM-AVISO END-EXEC. */

            var r1400_UPDATE_AVISOS_SALDOS_DB_UPDATE_1_Update1 = new R1400_UPDATE_AVISOS_SALDOS_DB_UPDATE_1_Update1()
            {
                MOVIMCOB_VAL_TITULO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO.ToString(),
                MOVIMCOB_COD_AGENCIA = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA.ToString(),
                MOVIMCOB_COD_BANCO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO.ToString(),
                MOVIMCOB_NUM_AVISO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO.ToString(),
            };

            R1400_UPDATE_AVISOS_SALDOS_DB_UPDATE_1_Update1.Execute(r1400_UPDATE_AVISOS_SALDOS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_EXIT*/

        [StopWatch]
        /*" R1410-ATUALIZA-AVISOS-SALDOS */
        private void R1410_ATUALIZA_AVISOS_SALDOS(bool isPerform = false)
        {
            /*" -2515- MOVE '029' TO WNR-EXEC-SQL. */
            _.Move("029", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -2522- PERFORM R1410_ATUALIZA_AVISOS_SALDOS_DB_SELECT_1 */

            R1410_ATUALIZA_AVISOS_SALDOS_DB_SELECT_1();

            /*" -2525- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2526- DISPLAY 'ERRO NO SELECT AVISOS_SALDOS' */
                _.Display($"ERRO NO SELECT AVISOS_SALDOS");

                /*" -2527- DISPLAY 'BCO_AVISO          = ' MOVIMCOB-COD-BANCO */
                _.Display($"BCO_AVISO          = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO}");

                /*" -2528- DISPLAY 'AGE_AVISO          = ' MOVIMCOB-COD-AGENCIA */
                _.Display($"AGE_AVISO          = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA}");

                /*" -2529- DISPLAY 'NUM_AVISO_CREDITO  = ' MOVIMCOB-NUM-AVISO */
                _.Display($"NUM_AVISO_CREDITO  = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO}");

                /*" -2531- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -2532- IF AVISOSAL-SALDO-ATUAL NOT EQUAL ZERO */

            if (AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_SALDO_ATUAL != 00)
            {

                /*" -2534- GO TO R1410-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1410_EXIT*/ //GOTO
                return;
            }


            /*" -2536- MOVE '030' TO WNR-EXEC-SQL. */
            _.Move("030", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -2545- PERFORM R1410_ATUALIZA_AVISOS_SALDOS_DB_SELECT_2 */

            R1410_ATUALIZA_AVISOS_SALDOS_DB_SELECT_2();

            /*" -2548- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2549- DISPLAY 'ERRO NO SUM MOVIMENTO_COBRANCA' */
                _.Display($"ERRO NO SUM MOVIMENTO_COBRANCA");

                /*" -2550- DISPLAY 'BCO_AVISO          = ' MOVIMCOB-COD-BANCO */
                _.Display($"BCO_AVISO          = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO}");

                /*" -2551- DISPLAY 'AGE_AVISO          = ' MOVIMCOB-COD-AGENCIA */
                _.Display($"AGE_AVISO          = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA}");

                /*" -2552- DISPLAY 'NUM_AVISO_CREDITO  = ' MOVIMCOB-NUM-AVISO */
                _.Display($"NUM_AVISO_CREDITO  = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO}");

                /*" -2554- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -2556- MOVE '031' TO WNR-EXEC-SQL. */
            _.Move("031", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -2562- PERFORM R1410_ATUALIZA_AVISOS_SALDOS_DB_UPDATE_1 */

            R1410_ATUALIZA_AVISOS_SALDOS_DB_UPDATE_1();

        }

        [StopWatch]
        /*" R1410-ATUALIZA-AVISOS-SALDOS-DB-SELECT-1 */
        public void R1410_ATUALIZA_AVISOS_SALDOS_DB_SELECT_1()
        {
            /*" -2522- EXEC SQL SELECT SALDO_ATUAL INTO :AVISOSAL-SALDO-ATUAL FROM SEGUROS.AVISOS_SALDOS WHERE BCO_AVISO = :MOVIMCOB-COD-BANCO AND AGE_AVISO = :MOVIMCOB-COD-AGENCIA AND NUM_AVISO_CREDITO = :MOVIMCOB-NUM-AVISO END-EXEC. */

            var r1410_ATUALIZA_AVISOS_SALDOS_DB_SELECT_1_Query1 = new R1410_ATUALIZA_AVISOS_SALDOS_DB_SELECT_1_Query1()
            {
                MOVIMCOB_COD_AGENCIA = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA.ToString(),
                MOVIMCOB_COD_BANCO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO.ToString(),
                MOVIMCOB_NUM_AVISO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO.ToString(),
            };

            var executed_1 = R1410_ATUALIZA_AVISOS_SALDOS_DB_SELECT_1_Query1.Execute(r1410_ATUALIZA_AVISOS_SALDOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.AVISOSAL_SALDO_ATUAL, AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_SALDO_ATUAL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1410_EXIT*/

        [StopWatch]
        /*" R1410-ATUALIZA-AVISOS-SALDOS-DB-UPDATE-1 */
        public void R1410_ATUALIZA_AVISOS_SALDOS_DB_UPDATE_1()
        {
            /*" -2562- EXEC SQL UPDATE SEGUROS.AVISOS_SALDOS SET SALDO_ATUAL = :MOVIMCOB-VAL-TITULO, TIMESTAMP = CURRENT TIMESTAMP WHERE BCO_AVISO = :MOVIMCOB-COD-BANCO AND AGE_AVISO = :MOVIMCOB-COD-AGENCIA AND NUM_AVISO_CREDITO = :MOVIMCOB-NUM-AVISO END-EXEC. */

            var r1410_ATUALIZA_AVISOS_SALDOS_DB_UPDATE_1_Update1 = new R1410_ATUALIZA_AVISOS_SALDOS_DB_UPDATE_1_Update1()
            {
                MOVIMCOB_VAL_TITULO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO.ToString(),
                MOVIMCOB_COD_AGENCIA = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA.ToString(),
                MOVIMCOB_COD_BANCO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO.ToString(),
                MOVIMCOB_NUM_AVISO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO.ToString(),
            };

            R1410_ATUALIZA_AVISOS_SALDOS_DB_UPDATE_1_Update1.Execute(r1410_ATUALIZA_AVISOS_SALDOS_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1410-ATUALIZA-AVISOS-SALDOS-DB-SELECT-2 */
        public void R1410_ATUALIZA_AVISOS_SALDOS_DB_SELECT_2()
        {
            /*" -2545- EXEC SQL SELECT VALUE(SUM(VAL_TITULO),0) INTO :MOVIMCOB-VAL-TITULO FROM SEGUROS.MOVIMENTO_COBRANCA WHERE TIPO_MOVIMENTO = '7' AND SIT_REGISTRO = ' ' AND COD_BANCO = :MOVIMCOB-COD-BANCO AND COD_AGENCIA = :MOVIMCOB-COD-AGENCIA AND NUM_AVISO = :MOVIMCOB-NUM-AVISO END-EXEC. */

            var r1410_ATUALIZA_AVISOS_SALDOS_DB_SELECT_2_Query1 = new R1410_ATUALIZA_AVISOS_SALDOS_DB_SELECT_2_Query1()
            {
                MOVIMCOB_COD_AGENCIA = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA.ToString(),
                MOVIMCOB_COD_BANCO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO.ToString(),
                MOVIMCOB_NUM_AVISO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO.ToString(),
            };

            var executed_1 = R1410_ATUALIZA_AVISOS_SALDOS_DB_SELECT_2_Query1.Execute(r1410_ATUALIZA_AVISOS_SALDOS_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVIMCOB_VAL_TITULO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO);
            }


        }

        [StopWatch]
        /*" R1500-LE-SINISHIS */
        private void R1500_LE_SINISHIS(bool isPerform = false)
        {
            /*" -2570- MOVE '032' TO WNR-EXEC-SQL. */
            _.Move("032", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -2590- PERFORM R1500_LE_SINISHIS_DB_SELECT_1 */

            R1500_LE_SINISHIS_DB_SELECT_1();

            /*" -2593- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2599- DISPLAY 'ERRO NO SELECT MIN SINISTRO_HISTORICO' ' ' SI111-NUM-APOL-SINISTRO ' ' SI111-NUM-RESSARC ' ' SI111-NUM-PARCELA ' ' SI111-OCORR-HISTORICO ' ' MOVIMCOB-NUM-NOSSO-TITULO */

                $"ERRO NO SELECT MIN SINISTRO_HISTORICO {SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO} {SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_RESSARC} {SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_PARCELA} {SI111.DCLSI_RESSARC_PARCELA.SI111_OCORR_HISTORICO} {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}"
                .Display();

                /*" -2601- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -2602- IF HOST-MIN-OCORR-HISTORICO NOT EQUAL ZEROS */

            if (HOST_MIN_OCORR_HISTORICO != 00)
            {

                /*" -2602- MOVE 'SIM' TO WTEM-PAGTO-MAO-GRANDE. */
                _.Move("SIM", AREA_DE_WORK.WTEM_PAGTO_MAO_GRANDE);
            }


        }

        [StopWatch]
        /*" R1500-LE-SINISHIS-DB-SELECT-1 */
        public void R1500_LE_SINISHIS_DB_SELECT_1()
        {
            /*" -2590- EXEC SQL SELECT VALUE(MIN(A.OCORR_HISTORICO), 0) INTO :HOST-MIN-OCORR-HISTORICO FROM SEGUROS.SINISTRO_HISTORICO A WHERE A.COD_OPERACAO = :SINISHIS-COD-OPERACAO AND A.NUM_APOL_SINISTRO = :SI111-NUM-APOL-SINISTRO AND A.DATA_MOVIMENTO <= '2008-11-01' AND NOT EXISTS (SELECT B.OCORR_HISTORICO FROM SEGUROS.SI_RESSARC_PARCELA B WHERE A.NUM_APOL_SINISTRO = B.NUM_APOL_SINISTRO AND A.OCORR_HISTORICO = B.OCORR_HISTORICO AND A.COD_OPERACAO = B.COD_OPERACAO) AND NOT EXISTS (SELECT C.OCORR_HISTORICO FROM SEGUROS.SINISTRO_HISTORICO C WHERE A.NUM_APOL_SINISTRO = C.NUM_APOL_SINISTRO AND A.OCORR_HISTORICO = C.OCORR_HISTORICO AND C.COD_OPERACAO = 4100) END-EXEC. */

            var r1500_LE_SINISHIS_DB_SELECT_1_Query1 = new R1500_LE_SINISHIS_DB_SELECT_1_Query1()
            {
                SI111_NUM_APOL_SINISTRO = SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_COD_OPERACAO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.ToString(),
            };

            var executed_1 = R1500_LE_SINISHIS_DB_SELECT_1_Query1.Execute(r1500_LE_SINISHIS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_MIN_OCORR_HISTORICO, HOST_MIN_OCORR_HISTORICO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_EXIT*/

        [StopWatch]
        /*" R1510-DECLARE-SINISHIS */
        private void R1510_DECLARE_SINISHIS(bool isPerform = false)
        {
            /*" -2610- MOVE '033' TO WNR-EXEC-SQL. */
            _.Move("033", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -2646- PERFORM R1510_DECLARE_SINISHIS_DB_DECLARE_1 */

            R1510_DECLARE_SINISHIS_DB_DECLARE_1();

            /*" -2648- PERFORM R1510_DECLARE_SINISHIS_DB_OPEN_1 */

            R1510_DECLARE_SINISHIS_DB_OPEN_1();

            /*" -2651- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2658- DISPLAY 'ERRO NO OPEN SINISTRO_HISTORICO' ' ' SI111-NUM-APOL-SINISTRO ' ' SI111-NUM-RESSARC ' ' SI111-NUM-PARCELA ' ' SI111-OCORR-HISTORICO ' ' MOVIMCOB-NUM-NOSSO-TITULO ' ' HOST-MIN-OCORR-HISTORICO */

                $"ERRO NO OPEN SINISTRO_HISTORICO {SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO} {SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_RESSARC} {SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_PARCELA} {SI111.DCLSI_RESSARC_PARCELA.SI111_OCORR_HISTORICO} {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO} {HOST_MIN_OCORR_HISTORICO}"
                .Display();

                /*" -2658- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1510-DECLARE-SINISHIS-DB-OPEN-1 */
        public void R1510_DECLARE_SINISHIS_DB_OPEN_1()
        {
            /*" -2648- EXEC SQL OPEN C_SINISHIS END-EXEC. */

            C_SINISHIS.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1510_EXIT*/

        [StopWatch]
        /*" R1520-FETCH-SINISHIS */
        private void R1520_FETCH_SINISHIS(bool isPerform = false)
        {
            /*" -2666- MOVE '034' TO WNR-EXEC-SQL. */
            _.Move("034", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -2689- PERFORM R1520_FETCH_SINISHIS_DB_FETCH_1 */

            R1520_FETCH_SINISHIS_DB_FETCH_1();

            /*" -2692- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2693- MOVE 'SIM' TO WFIM-SINISHIS */
                _.Move("SIM", AREA_DE_WORK.WFIM_SINISHIS);

                /*" -2693- PERFORM R1520_FETCH_SINISHIS_DB_CLOSE_1 */

                R1520_FETCH_SINISHIS_DB_CLOSE_1();

                /*" -2695- ELSE */
            }
            else
            {


                /*" -2696- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2703- DISPLAY 'ERRO NO FETCH SINISTRO_HISTORICO' ' ' SI111-NUM-APOL-SINISTRO ' ' SI111-NUM-RESSARC ' ' SI111-NUM-PARCELA ' ' SI111-OCORR-HISTORICO ' ' MOVIMCOB-NUM-NOSSO-TITULO ' ' HOST-MIN-OCORR-HISTORICO */

                    $"ERRO NO FETCH SINISTRO_HISTORICO {SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO} {SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_RESSARC} {SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_PARCELA} {SI111.DCLSI_RESSARC_PARCELA.SI111_OCORR_HISTORICO} {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO} {HOST_MIN_OCORR_HISTORICO}"
                    .Display();

                    /*" -2703- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1520-FETCH-SINISHIS-DB-FETCH-1 */
        public void R1520_FETCH_SINISHIS_DB_FETCH_1()
        {
            /*" -2689- EXEC SQL FETCH C_SINISHIS INTO :H-SINISHIS-COD-EMPRESA, :H-SINISHIS-TIPO-REGISTRO, :H-SINISHIS-COD-OPERACAO, :H-SINISHIS-DATA-MOVIMENTO, :H-SINISHIS-HORA-OPERACAO, :H-SINISHIS-NOME-FAVORECIDO, :H-SINISHIS-VAL-OPERACAO, :H-SINISHIS-DATA-LIM-CORRECAO, :H-SINISHIS-TIPO-FAVORECIDO, :H-SINISHIS-DATA-NEGOCIADA, :H-SINISHIS-FONTE-PAGAMENTO, :H-SINISHIS-COD-PREST-SERVICO, :H-SINISHIS-COD-SERVICO, :H-SINISHIS-ORDEM-PAGAMENTO, :H-SINISHIS-NUM-RECIBO, :H-SINISHIS-NUM-MOV-SINISTRO, :H-SINISHIS-COD-USUARIO, :H-SINISHIS-SIT-CONTABIL, :H-SINISHIS-SIT-REGISTRO, :H-SINISHIS-NUM-APOLICE, :H-SINISHIS-COD-PRODUTO, :H-SINISHIS-TIMESTAMP END-EXEC. */

            if (C_SINISHIS.Fetch())
            {
                _.Move(C_SINISHIS.H_SINISHIS_COD_EMPRESA, H_SINISHIS_COD_EMPRESA);
                _.Move(C_SINISHIS.H_SINISHIS_TIPO_REGISTRO, H_SINISHIS_TIPO_REGISTRO);
                _.Move(C_SINISHIS.H_SINISHIS_COD_OPERACAO, H_SINISHIS_COD_OPERACAO);
                _.Move(C_SINISHIS.H_SINISHIS_DATA_MOVIMENTO, H_SINISHIS_DATA_MOVIMENTO);
                _.Move(C_SINISHIS.H_SINISHIS_HORA_OPERACAO, H_SINISHIS_HORA_OPERACAO);
                _.Move(C_SINISHIS.H_SINISHIS_NOME_FAVORECIDO, H_SINISHIS_NOME_FAVORECIDO);
                _.Move(C_SINISHIS.H_SINISHIS_VAL_OPERACAO, H_SINISHIS_VAL_OPERACAO);
                _.Move(C_SINISHIS.H_SINISHIS_DATA_LIM_CORRECAO, H_SINISHIS_DATA_LIM_CORRECAO);
                _.Move(C_SINISHIS.H_SINISHIS_TIPO_FAVORECIDO, H_SINISHIS_TIPO_FAVORECIDO);
                _.Move(C_SINISHIS.H_SINISHIS_DATA_NEGOCIADA, H_SINISHIS_DATA_NEGOCIADA);
                _.Move(C_SINISHIS.H_SINISHIS_FONTE_PAGAMENTO, H_SINISHIS_FONTE_PAGAMENTO);
                _.Move(C_SINISHIS.H_SINISHIS_COD_PREST_SERVICO, H_SINISHIS_COD_PREST_SERVICO);
                _.Move(C_SINISHIS.H_SINISHIS_COD_SERVICO, H_SINISHIS_COD_SERVICO);
                _.Move(C_SINISHIS.H_SINISHIS_ORDEM_PAGAMENTO, H_SINISHIS_ORDEM_PAGAMENTO);
                _.Move(C_SINISHIS.H_SINISHIS_NUM_RECIBO, H_SINISHIS_NUM_RECIBO);
                _.Move(C_SINISHIS.H_SINISHIS_NUM_MOV_SINISTRO, H_SINISHIS_NUM_MOV_SINISTRO);
                _.Move(C_SINISHIS.H_SINISHIS_COD_USUARIO, H_SINISHIS_COD_USUARIO);
                _.Move(C_SINISHIS.H_SINISHIS_SIT_CONTABIL, H_SINISHIS_SIT_CONTABIL);
                _.Move(C_SINISHIS.H_SINISHIS_SIT_REGISTRO, H_SINISHIS_SIT_REGISTRO);
                _.Move(C_SINISHIS.H_SINISHIS_NUM_APOLICE, H_SINISHIS_NUM_APOLICE);
                _.Move(C_SINISHIS.H_SINISHIS_COD_PRODUTO, H_SINISHIS_COD_PRODUTO);
                _.Move(C_SINISHIS.H_SINISHIS_TIMESTAMP, H_SINISHIS_TIMESTAMP);
            }

        }

        [StopWatch]
        /*" R1520-FETCH-SINISHIS-DB-CLOSE-1 */
        public void R1520_FETCH_SINISHIS_DB_CLOSE_1()
        {
            /*" -2693- EXEC SQL CLOSE C_SINISHIS END-EXEC */

            C_SINISHIS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1520_EXIT*/

        [StopWatch]
        /*" R1600-ASSOCIA-PAGTO */
        private void R1600_ASSOCIA_PAGTO(bool isPerform = false)
        {
            /*" -2719- PERFORM R1610-INCLUI-SINISHIS THRU R1610-EXIT. */

            R1610_INCLUI_SINISHIS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1610_EXIT*/


            /*" -2720- MOVE H-SINISHIS-COD-OPERACAO TO SI111-COD-OPERACAO */
            _.Move(H_SINISHIS_COD_OPERACAO, SI111.DCLSI_RESSARC_PARCELA.SI111_COD_OPERACAO);

            /*" -2725- PERFORM R1200-INSERT-PARCELA THRU R1200-EXIT. */

            R1200_INSERT_PARCELA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_EXIT*/


            /*" -2726- PERFORM R1620-ALTERA-SISINCHE THRU R1620-EXIT. */

            R1620_ALTERA_SISINCHE(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1620_EXIT*/


            /*" -2727- PERFORM R1630-ALTERA-SIPADOFI THRU R1630-EXIT. */

            R1630_ALTERA_SIPADOFI(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1630_EXIT*/


            /*" -2732- PERFORM R1640-ALTERA-RALCHEDO THRU R1640-EXIT. */

            R1640_ALTERA_RALCHEDO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1640_EXIT*/


            /*" -2732- PERFORM R1650-EXCLUI-SINISHIS THRU R1650-EXIT. */

            R1650_EXCLUI_SINISHIS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1650_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_EXIT*/

        [StopWatch]
        /*" R1610-INCLUI-SINISHIS */
        private void R1610_INCLUI_SINISHIS(bool isPerform = false)
        {
            /*" -2740- MOVE '036' TO WNR-EXEC-SQL. */
            _.Move("036", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -2791- PERFORM R1610_INCLUI_SINISHIS_DB_INSERT_1 */

            R1610_INCLUI_SINISHIS_DB_INSERT_1();

            /*" -2794- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -2800- DISPLAY 'ERRO NO INSERT SINISTRO_HISTORICO' ' ' SI111-NUM-APOL-SINISTRO ' ' H-SINISHIS-COD-OPERACAO ' ' SI111-OCORR-HISTORICO ' ' MOVIMCOB-NUM-NOSSO-TITULO ' ' HOST-MIN-OCORR-HISTORICO */

                $"ERRO NO INSERT SINISTRO_HISTORICO {SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO} {H_SINISHIS_COD_OPERACAO} {SI111.DCLSI_RESSARC_PARCELA.SI111_OCORR_HISTORICO} {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO} {HOST_MIN_OCORR_HISTORICO}"
                .Display();

                /*" -2800- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1610-INCLUI-SINISHIS-DB-INSERT-1 */
        public void R1610_INCLUI_SINISHIS_DB_INSERT_1()
        {
            /*" -2791- EXEC SQL INSERT INTO SEGUROS.SINISTRO_HISTORICO (COD_EMPRESA, TIPO_REGISTRO, NUM_APOL_SINISTRO, OCORR_HISTORICO, COD_OPERACAO, DATA_MOVIMENTO, HORA_OPERACAO, NOME_FAVORECIDO, VAL_OPERACAO, DATA_LIM_CORRECAO, TIPO_FAVORECIDO, DATA_NEGOCIADA, FONTE_PAGAMENTO, COD_PREST_SERVICO, COD_SERVICO, ORDEM_PAGAMENTO, NUM_RECIBO, NUM_MOV_SINISTRO, COD_USUARIO, SIT_CONTABIL, SIT_REGISTRO, TIMESTAMP, NUM_APOLICE, COD_PRODUTO, NOM_PROGRAMA) VALUES (:H-SINISHIS-COD-EMPRESA, :H-SINISHIS-TIPO-REGISTRO, :SI111-NUM-APOL-SINISTRO, :SI111-OCORR-HISTORICO, :H-SINISHIS-COD-OPERACAO, :H-SINISHIS-DATA-MOVIMENTO, :H-SINISHIS-HORA-OPERACAO, :H-SINISHIS-NOME-FAVORECIDO, :H-SINISHIS-VAL-OPERACAO, :H-SINISHIS-DATA-LIM-CORRECAO, :H-SINISHIS-TIPO-FAVORECIDO, :H-SINISHIS-DATA-NEGOCIADA, :H-SINISHIS-FONTE-PAGAMENTO, :H-SINISHIS-COD-PREST-SERVICO, :H-SINISHIS-COD-SERVICO, :H-SINISHIS-ORDEM-PAGAMENTO, :H-SINISHIS-NUM-RECIBO, :H-SINISHIS-NUM-MOV-SINISTRO, :H-SINISHIS-COD-USUARIO, :H-SINISHIS-SIT-CONTABIL, :H-SINISHIS-SIT-REGISTRO, :H-SINISHIS-TIMESTAMP, :H-SINISHIS-NUM-APOLICE, :H-SINISHIS-COD-PRODUTO, 'SI0211B' ) END-EXEC. */

            var r1610_INCLUI_SINISHIS_DB_INSERT_1_Insert1 = new R1610_INCLUI_SINISHIS_DB_INSERT_1_Insert1()
            {
                H_SINISHIS_COD_EMPRESA = H_SINISHIS_COD_EMPRESA.ToString(),
                H_SINISHIS_TIPO_REGISTRO = H_SINISHIS_TIPO_REGISTRO.ToString(),
                SI111_NUM_APOL_SINISTRO = SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO.ToString(),
                SI111_OCORR_HISTORICO = SI111.DCLSI_RESSARC_PARCELA.SI111_OCORR_HISTORICO.ToString(),
                H_SINISHIS_COD_OPERACAO = H_SINISHIS_COD_OPERACAO.ToString(),
                H_SINISHIS_DATA_MOVIMENTO = H_SINISHIS_DATA_MOVIMENTO.ToString(),
                H_SINISHIS_HORA_OPERACAO = H_SINISHIS_HORA_OPERACAO.ToString(),
                H_SINISHIS_NOME_FAVORECIDO = H_SINISHIS_NOME_FAVORECIDO.ToString(),
                H_SINISHIS_VAL_OPERACAO = H_SINISHIS_VAL_OPERACAO.ToString(),
                H_SINISHIS_DATA_LIM_CORRECAO = H_SINISHIS_DATA_LIM_CORRECAO.ToString(),
                H_SINISHIS_TIPO_FAVORECIDO = H_SINISHIS_TIPO_FAVORECIDO.ToString(),
                H_SINISHIS_DATA_NEGOCIADA = H_SINISHIS_DATA_NEGOCIADA.ToString(),
                H_SINISHIS_FONTE_PAGAMENTO = H_SINISHIS_FONTE_PAGAMENTO.ToString(),
                H_SINISHIS_COD_PREST_SERVICO = H_SINISHIS_COD_PREST_SERVICO.ToString(),
                H_SINISHIS_COD_SERVICO = H_SINISHIS_COD_SERVICO.ToString(),
                H_SINISHIS_ORDEM_PAGAMENTO = H_SINISHIS_ORDEM_PAGAMENTO.ToString(),
                H_SINISHIS_NUM_RECIBO = H_SINISHIS_NUM_RECIBO.ToString(),
                H_SINISHIS_NUM_MOV_SINISTRO = H_SINISHIS_NUM_MOV_SINISTRO.ToString(),
                H_SINISHIS_COD_USUARIO = H_SINISHIS_COD_USUARIO.ToString(),
                H_SINISHIS_SIT_CONTABIL = H_SINISHIS_SIT_CONTABIL.ToString(),
                H_SINISHIS_SIT_REGISTRO = H_SINISHIS_SIT_REGISTRO.ToString(),
                H_SINISHIS_TIMESTAMP = H_SINISHIS_TIMESTAMP.ToString(),
                H_SINISHIS_NUM_APOLICE = H_SINISHIS_NUM_APOLICE.ToString(),
                H_SINISHIS_COD_PRODUTO = H_SINISHIS_COD_PRODUTO.ToString(),
            };

            R1610_INCLUI_SINISHIS_DB_INSERT_1_Insert1.Execute(r1610_INCLUI_SINISHIS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1610_EXIT*/

        [StopWatch]
        /*" R1620-ALTERA-SISINCHE */
        private void R1620_ALTERA_SISINCHE(bool isPerform = false)
        {
            /*" -2808- MOVE '037' TO WNR-EXEC-SQL. */
            _.Move("037", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -2814- PERFORM R1620_ALTERA_SISINCHE_DB_UPDATE_1 */

            R1620_ALTERA_SISINCHE_DB_UPDATE_1();

            /*" -2817- IF SQLCODE NOT EQUAL ZERO AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -2823- DISPLAY 'ERRO NO UPDATE SI_SINI_CHEQUE' ' ' SI111-NUM-APOL-SINISTRO ' ' H-SINISHIS-COD-OPERACAO ' ' SI111-OCORR-HISTORICO ' ' MOVIMCOB-NUM-NOSSO-TITULO ' ' HOST-MIN-OCORR-HISTORICO */

                $"ERRO NO UPDATE SI_SINI_CHEQUE {SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO} {H_SINISHIS_COD_OPERACAO} {SI111.DCLSI_RESSARC_PARCELA.SI111_OCORR_HISTORICO} {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO} {HOST_MIN_OCORR_HISTORICO}"
                .Display();

                /*" -2823- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1620-ALTERA-SISINCHE-DB-UPDATE-1 */
        public void R1620_ALTERA_SISINCHE_DB_UPDATE_1()
        {
            /*" -2814- EXEC SQL UPDATE SEGUROS.SI_SINI_CHEQUE SET OCORR_HISTORICO = :SI111-OCORR-HISTORICO WHERE COD_OPERACAO = :H-SINISHIS-COD-OPERACAO AND NUM_APOL_SINISTRO = :SI111-NUM-APOL-SINISTRO AND OCORR_HISTORICO = :HOST-MIN-OCORR-HISTORICO END-EXEC. */

            var r1620_ALTERA_SISINCHE_DB_UPDATE_1_Update1 = new R1620_ALTERA_SISINCHE_DB_UPDATE_1_Update1()
            {
                SI111_OCORR_HISTORICO = SI111.DCLSI_RESSARC_PARCELA.SI111_OCORR_HISTORICO.ToString(),
                HOST_MIN_OCORR_HISTORICO = HOST_MIN_OCORR_HISTORICO.ToString(),
                H_SINISHIS_COD_OPERACAO = H_SINISHIS_COD_OPERACAO.ToString(),
                SI111_NUM_APOL_SINISTRO = SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO.ToString(),
            };

            R1620_ALTERA_SISINCHE_DB_UPDATE_1_Update1.Execute(r1620_ALTERA_SISINCHE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1620_EXIT*/

        [StopWatch]
        /*" R1630-ALTERA-SIPADOFI */
        private void R1630_ALTERA_SIPADOFI(bool isPerform = false)
        {
            /*" -2831- MOVE '038' TO WNR-EXEC-SQL. */
            _.Move("038", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -2837- PERFORM R1630_ALTERA_SIPADOFI_DB_UPDATE_1 */

            R1630_ALTERA_SIPADOFI_DB_UPDATE_1();

            /*" -2840- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -2846- DISPLAY 'ERRO NO UPDATE SI_PAGA_DOC_FISCAL' ' ' SI111-NUM-APOL-SINISTRO ' ' H-SINISHIS-COD-OPERACAO ' ' SI111-OCORR-HISTORICO ' ' MOVIMCOB-NUM-NOSSO-TITULO ' ' HOST-MIN-OCORR-HISTORICO */

                $"ERRO NO UPDATE SI_PAGA_DOC_FISCAL {SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO} {H_SINISHIS_COD_OPERACAO} {SI111.DCLSI_RESSARC_PARCELA.SI111_OCORR_HISTORICO} {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO} {HOST_MIN_OCORR_HISTORICO}"
                .Display();

                /*" -2846- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1630-ALTERA-SIPADOFI-DB-UPDATE-1 */
        public void R1630_ALTERA_SIPADOFI_DB_UPDATE_1()
        {
            /*" -2837- EXEC SQL UPDATE SEGUROS.SI_PAGA_DOC_FISCAL SET OCORR_HISTORICO = :SI111-OCORR-HISTORICO WHERE COD_OPERACAO = :H-SINISHIS-COD-OPERACAO AND NUM_APOL_SINISTRO = :SI111-NUM-APOL-SINISTRO AND OCORR_HISTORICO = :HOST-MIN-OCORR-HISTORICO END-EXEC. */

            var r1630_ALTERA_SIPADOFI_DB_UPDATE_1_Update1 = new R1630_ALTERA_SIPADOFI_DB_UPDATE_1_Update1()
            {
                SI111_OCORR_HISTORICO = SI111.DCLSI_RESSARC_PARCELA.SI111_OCORR_HISTORICO.ToString(),
                HOST_MIN_OCORR_HISTORICO = HOST_MIN_OCORR_HISTORICO.ToString(),
                H_SINISHIS_COD_OPERACAO = H_SINISHIS_COD_OPERACAO.ToString(),
                SI111_NUM_APOL_SINISTRO = SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO.ToString(),
            };

            R1630_ALTERA_SIPADOFI_DB_UPDATE_1_Update1.Execute(r1630_ALTERA_SIPADOFI_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1630_EXIT*/

        [StopWatch]
        /*" R1640-ALTERA-RALCHEDO */
        private void R1640_ALTERA_RALCHEDO(bool isPerform = false)
        {
            /*" -2854- MOVE '039' TO WNR-EXEC-SQL. */
            _.Move("039", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -2859- PERFORM R1640_ALTERA_RALCHEDO_DB_UPDATE_1 */

            R1640_ALTERA_RALCHEDO_DB_UPDATE_1();

            /*" -2862- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -2868- DISPLAY 'ERRO NO UPDATE RALACAO_CHEQ_DOCTO' ' ' SI111-NUM-APOL-SINISTRO ' ' H-SINISHIS-COD-OPERACAO ' ' SI111-OCORR-HISTORICO ' ' MOVIMCOB-NUM-NOSSO-TITULO ' ' HOST-MIN-OCORR-HISTORICO */

                $"ERRO NO UPDATE RALACAO_CHEQ_DOCTO {SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO} {H_SINISHIS_COD_OPERACAO} {SI111.DCLSI_RESSARC_PARCELA.SI111_OCORR_HISTORICO} {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO} {HOST_MIN_OCORR_HISTORICO}"
                .Display();

                /*" -2868- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1640-ALTERA-RALCHEDO-DB-UPDATE-1 */
        public void R1640_ALTERA_RALCHEDO_DB_UPDATE_1()
        {
            /*" -2859- EXEC SQL UPDATE SEGUROS.RALACAO_CHEQ_DOCTO SET OCORR_HISTORICO = :SI111-OCORR-HISTORICO WHERE NUMDOC_NUM01 = :SI111-NUM-APOL-SINISTRO AND OCORR_HISTORICO = :HOST-MIN-OCORR-HISTORICO END-EXEC. */

            var r1640_ALTERA_RALCHEDO_DB_UPDATE_1_Update1 = new R1640_ALTERA_RALCHEDO_DB_UPDATE_1_Update1()
            {
                SI111_OCORR_HISTORICO = SI111.DCLSI_RESSARC_PARCELA.SI111_OCORR_HISTORICO.ToString(),
                HOST_MIN_OCORR_HISTORICO = HOST_MIN_OCORR_HISTORICO.ToString(),
                SI111_NUM_APOL_SINISTRO = SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO.ToString(),
            };

            R1640_ALTERA_RALCHEDO_DB_UPDATE_1_Update1.Execute(r1640_ALTERA_RALCHEDO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1640_EXIT*/

        [StopWatch]
        /*" R1650-EXCLUI-SINISHIS */
        private void R1650_EXCLUI_SINISHIS(bool isPerform = false)
        {
            /*" -2876- MOVE '040' TO WNR-EXEC-SQL. */
            _.Move("040", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -2881- PERFORM R1650_EXCLUI_SINISHIS_DB_DELETE_1 */

            R1650_EXCLUI_SINISHIS_DB_DELETE_1();

            /*" -2884- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -2890- DISPLAY 'ERRO NO DELETE SINISTRO_HISTORICO' ' ' SI111-NUM-APOL-SINISTRO ' ' H-SINISHIS-COD-OPERACAO ' ' SI111-OCORR-HISTORICO ' ' MOVIMCOB-NUM-NOSSO-TITULO ' ' HOST-MIN-OCORR-HISTORICO */

                $"ERRO NO DELETE SINISTRO_HISTORICO {SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO} {H_SINISHIS_COD_OPERACAO} {SI111.DCLSI_RESSARC_PARCELA.SI111_OCORR_HISTORICO} {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO} {HOST_MIN_OCORR_HISTORICO}"
                .Display();

                /*" -2890- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1650-EXCLUI-SINISHIS-DB-DELETE-1 */
        public void R1650_EXCLUI_SINISHIS_DB_DELETE_1()
        {
            /*" -2881- EXEC SQL DELETE FROM SEGUROS.SINISTRO_HISTORICO WHERE COD_OPERACAO = :H-SINISHIS-COD-OPERACAO AND NUM_APOL_SINISTRO = :SI111-NUM-APOL-SINISTRO AND OCORR_HISTORICO = :HOST-MIN-OCORR-HISTORICO END-EXEC. */

            var r1650_EXCLUI_SINISHIS_DB_DELETE_1_Delete1 = new R1650_EXCLUI_SINISHIS_DB_DELETE_1_Delete1()
            {
                H_SINISHIS_COD_OPERACAO = H_SINISHIS_COD_OPERACAO.ToString(),
                SI111_NUM_APOL_SINISTRO = SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO.ToString(),
                HOST_MIN_OCORR_HISTORICO = HOST_MIN_OCORR_HISTORICO.ToString(),
            };

            R1650_EXCLUI_SINISHIS_DB_DELETE_1_Delete1.Execute(r1650_EXCLUI_SINISHIS_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1650_EXIT*/

        [StopWatch]
        /*" R10000-GRAVA-FOLLOWUP */
        private void R10000_GRAVA_FOLLOWUP(bool isPerform = false)
        {
            /*" -2902- MOVE MOVIMCOB-NOME-SEGURADO TO AUX-NOME. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO, AREA_DE_WORK.AUX_NOME);

            /*" -2904- IF AUX-DESCR01 EQUAL SPACES NEXT SENTENCE */

            if (AREA_DE_WORK.AUX_NOME.AUX_DESCR01.IsEmpty())
            {

                /*" -2905- ELSE */
            }
            else
            {


                /*" -2906- IF AUX-DESCR01 EQUAL 'TITULO DUPLICAD' */

                if (AREA_DE_WORK.AUX_NOME.AUX_DESCR01 == "TITULO DUPLICAD")
                {

                    /*" -2907- MOVE '1' TO FOLLOUP-COD-ERRO02 */
                    _.Move("1", FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_ERRO02);

                    /*" -2908- ELSE */
                }
                else
                {


                    /*" -2909- IF AUX-DESCR01 EQUAL 'TITULO NAO CADA' */

                    if (AREA_DE_WORK.AUX_NOME.AUX_DESCR01 == "TITULO NAO CADA")
                    {

                        /*" -2910- MOVE '1' TO FOLLOUP-COD-ERRO01 */
                        _.Move("1", FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_ERRO01);

                        /*" -2911- ELSE */
                    }
                    else
                    {


                        /*" -2912- IF AUX-DESCR01 EQUAL 'TITULO NAO INFO' */

                        if (AREA_DE_WORK.AUX_NOME.AUX_DESCR01 == "TITULO NAO INFO")
                        {

                            /*" -2913- MOVE '1' TO FOLLOUP-COD-ERRO02 */
                            _.Move("1", FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_ERRO02);

                            /*" -2914- ELSE */
                        }
                        else
                        {


                            /*" -2915- IF AUX-DESCR01 EQUAL 'VALOR DIVERGENT' */

                            if (AREA_DE_WORK.AUX_NOME.AUX_DESCR01 == "VALOR DIVERGENT")
                            {

                                /*" -2917- MOVE '1' TO FOLLOUP-COD-ERRO06. */
                                _.Move("1", FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_ERRO06);
                            }

                        }

                    }

                }

            }


            /*" -2920- MOVE MOVIMCOB-NUM-NOSSO-TITULO TO FOLLOUP-NUM-NOSSO-TITULO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_NOSSO_TITULO);

            /*" -2921- ACCEPT WS-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_TIME);

            /*" -2922- MOVE WS-HH-TIME TO WTIME-HORA. */
            _.Move(AREA_DE_WORK.WS_TIME.WS_HH_TIME, AREA_DE_WORK.FILLER_0.WTIME_DAYR.WTIME_HORA);

            /*" -2923- MOVE '.' TO WTIME-2PT1. */
            _.Move(".", AREA_DE_WORK.FILLER_0.WTIME_DAYR.WTIME_2PT1);

            /*" -2924- MOVE WS-MM-TIME TO WTIME-MINU. */
            _.Move(AREA_DE_WORK.WS_TIME.WS_MM_TIME, AREA_DE_WORK.FILLER_0.WTIME_DAYR.WTIME_MINU);

            /*" -2925- MOVE '.' TO WTIME-2PT2. */
            _.Move(".", AREA_DE_WORK.FILLER_0.WTIME_DAYR.WTIME_2PT2);

            /*" -2927- MOVE WS-SS-TIME TO WTIME-SEGU. */
            _.Move(AREA_DE_WORK.WS_TIME.WS_SS_TIME, AREA_DE_WORK.FILLER_0.WTIME_DAYR.WTIME_SEGU);

            /*" -2934- MOVE WTIME-DAYR TO FOLLOUP-HORA-OPERACAO. */
            _.Move(AREA_DE_WORK.FILLER_0.WTIME_DAYR, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_HORA_OPERACAO);

            /*" -2935- IF MOVIMCOB-NUM-APOLICE EQUAL ZEROS */

            if (MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE == 00)
            {

                /*" -2936- MOVE MOVIMCOB-NUM-TITULO TO FOLLOUP-NUM-APOLICE */
                _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_TITULO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_APOLICE);

                /*" -2937- ELSE */
            }
            else
            {


                /*" -2940- MOVE MOVIMCOB-NUM-APOLICE TO FOLLOUP-NUM-APOLICE. */
                _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_APOLICE);
            }


            /*" -2942- MOVE MOVIMCOB-NUM-ENDOSSO TO FOLLOUP-NUM-ENDOSSO */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_ENDOSSO);

            /*" -2943- MOVE MOVIMCOB-NUM-PARCELA TO FOLLOUP-NUM-PARCELA */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_PARCELA);

            /*" -2945- MOVE SPACES TO FOLLOUP-DAC-PARCELA */
            _.Move("", FOLLOUP.DCLFOLLOW_UP.FOLLOUP_DAC_PARCELA);

            /*" -2947- MOVE SISTEMAS-DATA-MOV-ABERTO TO FOLLOUP-DATA-MOVIMENTO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_DATA_MOVIMENTO);

            /*" -2948- MOVE MOVIMCOB-VAL-TITULO TO FOLLOUP-VAL-OPERACAO */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_VAL_OPERACAO);

            /*" -2949- MOVE MOVIMCOB-COD-BANCO TO FOLLOUP-BCO-AVISO */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_BCO_AVISO);

            /*" -2950- MOVE MOVIMCOB-COD-AGENCIA TO FOLLOUP-AGE-AVISO */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_AGE_AVISO);

            /*" -2951- MOVE MOVIMCOB-NUM-AVISO TO FOLLOUP-NUM-AVISO-CREDITO */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_AVISO_CREDITO);

            /*" -2955- MOVE 30 TO FOLLOUP-COD-BAIXA-PARCELA */
            _.Move(30, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_BAIXA_PARCELA);

            /*" -2957- MOVE '0' TO FOLLOUP-SIT-REGISTRO FOLLOUP-SIT-CONTABIL */
            _.Move("0", FOLLOUP.DCLFOLLOW_UP.FOLLOUP_SIT_REGISTRO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_SIT_CONTABIL);

            /*" -2958- MOVE 103 TO FOLLOUP-COD-OPERACAO */
            _.Move(103, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_OPERACAO);

            /*" -2959- MOVE SPACES TO FOLLOUP-DATA-LIBERACAO */
            _.Move("", FOLLOUP.DCLFOLLOW_UP.FOLLOUP_DATA_LIBERACAO);

            /*" -2960- MOVE -1 TO VIND-FOLLOUP-DATA-LIBERACAO */
            _.Move(-1, VIND_FOLLOUP_DATA_LIBERACAO);

            /*" -2961- MOVE MOVIMCOB-DATA-QUITACAO TO FOLLOUP-DATA-QUITACAO */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_QUITACAO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_DATA_QUITACAO);

            /*" -2962- MOVE ZEROS TO FOLLOUP-COD-EMPRESA */
            _.Move(0, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_EMPRESA);

            /*" -2963- MOVE '1' TO FOLLOUP-TIPO-SEGURO */
            _.Move("1", FOLLOUP.DCLFOLLOW_UP.FOLLOUP_TIPO_SEGURO);

            /*" -2968- MOVE ZEROS TO FOLLOUP-ORDEM-LIDER FOLLOUP-COD-LIDER FOLLOUP-COD-FONTE. */
            _.Move(0, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_ORDEM_LIDER, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_LIDER, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_FONTE);

            /*" -3002- MOVE SPACES TO FOLLOUP-NUM-APOL-LIDER FOLLOUP-ENDOS-LIDER. */
            _.Move("", FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_APOL_LIDER, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_ENDOS_LIDER);

            /*" -3002- MOVE '041' TO WNR-EXEC-SQL. */
            _.Move("041", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

        }

        [StopWatch]
        /*" R10000-INSERT */
        private void R10000_INSERT(bool isPerform = false)
        {
            /*" -3076- PERFORM R10000_INSERT_DB_INSERT_1 */

            R10000_INSERT_DB_INSERT_1();

            /*" -3083- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -3084- ADD 1 TO AC-DUPLICA */
                AREA_DE_WORK.AC_DUPLICA.Value = AREA_DE_WORK.AC_DUPLICA + 1;

                /*" -3085- IF AC-DUPLICA LESS 10 */

                if (AREA_DE_WORK.AC_DUPLICA < 10)
                {

                    /*" -3086- PERFORM R1220-00-ADICIONA-TIME THRU R1220-99-SAIDA */

                    R1220_00_ADICIONA_TIME(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1220_99_SAIDA*/


                    /*" -3087- GO TO R10000-INSERT */
                    new Task(() => R10000_INSERT()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -3088- ELSE */
                }
                else
                {


                    /*" -3089- DISPLAY 'ERRO NO INSERT NA FOLLOW_UP' */
                    _.Display($"ERRO NO INSERT NA FOLLOW_UP");

                    /*" -3090- DISPLAY 'NUMERO SINISTRO = ' SI111-NUM-APOL-SINISTRO */
                    _.Display($"NUMERO SINISTRO = {SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO}");

                    /*" -3091- DISPLAY 'OPERACAO        = ' SI111-COD-OPERACAO */
                    _.Display($"OPERACAO        = {SI111.DCLSI_RESSARC_PARCELA.SI111_COD_OPERACAO}");

                    /*" -3092- DISPLAY 'OCOHIST         = ' SI111-OCORR-HISTORICO */
                    _.Display($"OCOHIST         = {SI111.DCLSI_RESSARC_PARCELA.SI111_OCORR_HISTORICO}");

                    /*" -3093- DISPLAY 'TITULO          = ' MOVIMCOB-NUM-NOSSO-TITULO */
                    _.Display($"TITULO          = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}");

                    /*" -3094- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;

                    /*" -3095- ELSE */
                }

            }
            else
            {


                /*" -3096- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -3097- DISPLAY 'ERRO NO INSERT NA FOLLOW_UP' */
                    _.Display($"ERRO NO INSERT NA FOLLOW_UP");

                    /*" -3098- DISPLAY 'NUMERO SINISTRO = ' SI111-NUM-APOL-SINISTRO */
                    _.Display($"NUMERO SINISTRO = {SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_APOL_SINISTRO}");

                    /*" -3099- DISPLAY 'OPERACAO        = ' SI111-COD-OPERACAO */
                    _.Display($"OPERACAO        = {SI111.DCLSI_RESSARC_PARCELA.SI111_COD_OPERACAO}");

                    /*" -3100- DISPLAY 'OCOHIST         = ' SI111-OCORR-HISTORICO */
                    _.Display($"OCOHIST         = {SI111.DCLSI_RESSARC_PARCELA.SI111_OCORR_HISTORICO}");

                    /*" -3101- DISPLAY 'TITULO          = ' MOVIMCOB-NUM-NOSSO-TITULO */
                    _.Display($"TITULO          = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}");

                    /*" -3102- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;

                    /*" -3103- ELSE */
                }
                else
                {


                    /*" -3103- ADD 1 TO W-QTD-FOLLOWUP. */
                    AREA_DE_WORK.W_QTD_FOLLOWUP.Value = AREA_DE_WORK.W_QTD_FOLLOWUP + 1;
                }

            }


        }

        [StopWatch]
        /*" R10000-INSERT-DB-INSERT-1 */
        public void R10000_INSERT_DB_INSERT_1()
        {
            /*" -3076- EXEC SQL INSERT INTO SEGUROS.FOLLOW_UP ( NUM_APOLICE, NUM_ENDOSSO, NUM_PARCELA, DAC_PARCELA, DATA_MOVIMENTO, HORA_OPERACAO, VAL_OPERACAO, BCO_AVISO, AGE_AVISO, NUM_AVISO_CREDITO, COD_BAIXA_PARCELA, COD_ERRO01, COD_ERRO02, COD_ERRO03, COD_ERRO04, COD_ERRO05, COD_ERRO06, SIT_REGISTRO, SIT_CONTABIL, COD_OPERACAO, DATA_LIBERACAO, DATA_QUITACAO, COD_EMPRESA, TIMESTAMP, ORDEM_LIDER, TIPO_SEGURO, NUM_APOL_LIDER, ENDOS_LIDER, COD_LIDER, COD_FONTE, NUM_RCAP, NUM_NOSSO_TITULO) VALUES (:FOLLOUP-NUM-APOLICE, :FOLLOUP-NUM-ENDOSSO, :FOLLOUP-NUM-PARCELA, :FOLLOUP-DAC-PARCELA, :FOLLOUP-DATA-MOVIMENTO, :FOLLOUP-HORA-OPERACAO, :FOLLOUP-VAL-OPERACAO, :FOLLOUP-BCO-AVISO, :FOLLOUP-AGE-AVISO, :FOLLOUP-NUM-AVISO-CREDITO, :FOLLOUP-COD-BAIXA-PARCELA, :FOLLOUP-COD-ERRO01, :FOLLOUP-COD-ERRO02, :FOLLOUP-COD-ERRO03, :FOLLOUP-COD-ERRO04, :FOLLOUP-COD-ERRO05, :FOLLOUP-COD-ERRO06, :FOLLOUP-SIT-REGISTRO, :FOLLOUP-SIT-CONTABIL, :FOLLOUP-COD-OPERACAO, :FOLLOUP-DATA-LIBERACAO:VIND-FOLLOUP-DATA-LIBERACAO, :FOLLOUP-DATA-QUITACAO, :FOLLOUP-COD-EMPRESA, CURRENT TIMESTAMP, :FOLLOUP-ORDEM-LIDER, :FOLLOUP-TIPO-SEGURO, :FOLLOUP-NUM-APOL-LIDER, :FOLLOUP-ENDOS-LIDER, :FOLLOUP-COD-LIDER, :FOLLOUP-COD-FONTE, :FOLLOUP-NUM-RCAP, :FOLLOUP-NUM-NOSSO-TITULO) END-EXEC. */

            var r10000_INSERT_DB_INSERT_1_Insert1 = new R10000_INSERT_DB_INSERT_1_Insert1()
            {
                FOLLOUP_NUM_APOLICE = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_APOLICE.ToString(),
                FOLLOUP_NUM_ENDOSSO = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_ENDOSSO.ToString(),
                FOLLOUP_NUM_PARCELA = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_PARCELA.ToString(),
                FOLLOUP_DAC_PARCELA = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_DAC_PARCELA.ToString(),
                FOLLOUP_DATA_MOVIMENTO = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_DATA_MOVIMENTO.ToString(),
                FOLLOUP_HORA_OPERACAO = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_HORA_OPERACAO.ToString(),
                FOLLOUP_VAL_OPERACAO = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_VAL_OPERACAO.ToString(),
                FOLLOUP_BCO_AVISO = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_BCO_AVISO.ToString(),
                FOLLOUP_AGE_AVISO = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_AGE_AVISO.ToString(),
                FOLLOUP_NUM_AVISO_CREDITO = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_AVISO_CREDITO.ToString(),
                FOLLOUP_COD_BAIXA_PARCELA = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_BAIXA_PARCELA.ToString(),
                FOLLOUP_COD_ERRO01 = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_ERRO01.ToString(),
                FOLLOUP_COD_ERRO02 = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_ERRO02.ToString(),
                FOLLOUP_COD_ERRO03 = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_ERRO03.ToString(),
                FOLLOUP_COD_ERRO04 = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_ERRO04.ToString(),
                FOLLOUP_COD_ERRO05 = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_ERRO05.ToString(),
                FOLLOUP_COD_ERRO06 = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_ERRO06.ToString(),
                FOLLOUP_SIT_REGISTRO = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_SIT_REGISTRO.ToString(),
                FOLLOUP_SIT_CONTABIL = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_SIT_CONTABIL.ToString(),
                FOLLOUP_COD_OPERACAO = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_OPERACAO.ToString(),
                FOLLOUP_DATA_LIBERACAO = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_DATA_LIBERACAO.ToString(),
                VIND_FOLLOUP_DATA_LIBERACAO = VIND_FOLLOUP_DATA_LIBERACAO.ToString(),
                FOLLOUP_DATA_QUITACAO = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_DATA_QUITACAO.ToString(),
                FOLLOUP_COD_EMPRESA = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_EMPRESA.ToString(),
                FOLLOUP_ORDEM_LIDER = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_ORDEM_LIDER.ToString(),
                FOLLOUP_TIPO_SEGURO = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_TIPO_SEGURO.ToString(),
                FOLLOUP_NUM_APOL_LIDER = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_APOL_LIDER.ToString(),
                FOLLOUP_ENDOS_LIDER = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_ENDOS_LIDER.ToString(),
                FOLLOUP_COD_LIDER = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_LIDER.ToString(),
                FOLLOUP_COD_FONTE = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_FONTE.ToString(),
                FOLLOUP_NUM_RCAP = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_RCAP.ToString(),
                FOLLOUP_NUM_NOSSO_TITULO = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_NOSSO_TITULO.ToString(),
            };

            R10000_INSERT_DB_INSERT_1_Insert1.Execute(r10000_INSERT_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R10000_EXIT*/

        [StopWatch]
        /*" R1220-00-ADICIONA-TIME */
        private void R1220_00_ADICIONA_TIME(bool isPerform = false)
        {
            /*" -3151- MOVE '042' TO WNR-EXEC-SQL. */
            _.Move("042", AREA_DE_WORK.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -3153- IF WTIME-SEGU GREATER ZEROS AND WTIME-SEGU LESS 59 */

            if (AREA_DE_WORK.FILLER_0.WTIME_DAYR.WTIME_SEGU > 00 && AREA_DE_WORK.FILLER_0.WTIME_DAYR.WTIME_SEGU < 59)
            {

                /*" -3154- ADD 1 TO WTIME-SEGU */
                AREA_DE_WORK.FILLER_0.WTIME_DAYR.WTIME_SEGU.Value = AREA_DE_WORK.FILLER_0.WTIME_DAYR.WTIME_SEGU + 1;

                /*" -3155- ELSE */
            }
            else
            {


                /*" -3157- IF WTIME-MINU GREATER ZEROS AND WTIME-MINU LESS 59 */

                if (AREA_DE_WORK.FILLER_0.WTIME_DAYR.WTIME_MINU > 00 && AREA_DE_WORK.FILLER_0.WTIME_DAYR.WTIME_MINU < 59)
                {

                    /*" -3158- ADD 1 TO WTIME-MINU */
                    AREA_DE_WORK.FILLER_0.WTIME_DAYR.WTIME_MINU.Value = AREA_DE_WORK.FILLER_0.WTIME_DAYR.WTIME_MINU + 1;

                    /*" -3159- MOVE 1 TO WTIME-SEGU */
                    _.Move(1, AREA_DE_WORK.FILLER_0.WTIME_DAYR.WTIME_SEGU);

                    /*" -3160- ELSE */
                }
                else
                {


                    /*" -3162- IF WTIME-HORA GREATER ZEROS AND WTIME-HORA LESS 23 */

                    if (AREA_DE_WORK.FILLER_0.WTIME_DAYR.WTIME_HORA > 00 && AREA_DE_WORK.FILLER_0.WTIME_DAYR.WTIME_HORA < 23)
                    {

                        /*" -3163- ADD 1 TO WTIME-HORA */
                        AREA_DE_WORK.FILLER_0.WTIME_DAYR.WTIME_HORA.Value = AREA_DE_WORK.FILLER_0.WTIME_DAYR.WTIME_HORA + 1;

                        /*" -3165- MOVE 1 TO WTIME-MINU WTIME-SEGU */
                        _.Move(1, AREA_DE_WORK.FILLER_0.WTIME_DAYR.WTIME_MINU);
                        _.Move(1, AREA_DE_WORK.FILLER_0.WTIME_DAYR.WTIME_SEGU);


                        /*" -3166- ELSE */
                    }
                    else
                    {


                        /*" -3171- MOVE 01 TO WTIME-HORA WTIME-MINU WTIME-SEGU. */
                        _.Move(01, AREA_DE_WORK.FILLER_0.WTIME_DAYR.WTIME_HORA);
                        _.Move(01, AREA_DE_WORK.FILLER_0.WTIME_DAYR.WTIME_MINU);
                        _.Move(01, AREA_DE_WORK.FILLER_0.WTIME_DAYR.WTIME_SEGU);

                    }

                }

            }


            /*" -3172- MOVE WTIME-DAYR TO FOLLOUP-HORA-OPERACAO. */
            _.Move(AREA_DE_WORK.FILLER_0.WTIME_DAYR, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_HORA_OPERACAO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1220_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO */
        private void R9999_00_ROT_ERRO(bool isPerform = false)
        {
            /*" -3183- CLOSE ARQRET. */
            ARQRET.Close();

            /*" -3184- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3.WSQLCODE);

            /*" -3185- MOVE SQLERRMC TO WSQLERRMC. */
            _.Move(DB.SQLERRMC, AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3.WSQLERRMC);

            /*" -3186- MOVE SQLERRMC TO WSQLERRMC. */
            _.Move(DB.SQLERRMC, AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3.WSQLERRMC);

            /*" -3187- MOVE SQLCAID TO WSQLCAID . */
            _.Move(DB.SQLCAID, AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3.WSQLCAID);

            /*" -3188- MOVE SQLCABC TO WSQLCABC . */
            _.Move(DB.SQLCABC, AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3.WSQLCABC);

            /*" -3189- MOVE SQLCODE TO WSQLCODE . */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3.WSQLCODE);

            /*" -3191- MOVE SQLERRP TO WSQLERRP . */
            _.Move(DB.SQLERRP, AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3.WSQLERRP);

            /*" -3192- MOVE SQLWARN TO WSQLWARN. */
            _.Move(DB.SQLWARN, AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3.WSQLWARN);

            /*" -3193- DISPLAY ' ' */
            _.Display($" ");

            /*" -3194- DISPLAY '=====  PROGRAMA ABENDADO  =====' */
            _.Display($"=====  PROGRAMA ABENDADO  =====");

            /*" -3195- DISPLAY ' ' */
            _.Display($" ");

            /*" -3196- DISPLAY WABEND1. */
            _.Display(AREA_DE_WORK.WABEND.WABEND1);

            /*" -3197- DISPLAY WABEND2. */
            _.Display(AREA_DE_WORK.WABEND.WABEND1.WABEND2);

            /*" -3198- DISPLAY WABEND3. */
            _.Display(AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3);

            /*" -3198- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -3199- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -3201- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -3201- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_EXIT*/

        [StopWatch]
        /*" R10010199-MENSAGEM-LOCK */
        private void R10010199_MENSAGEM_LOCK(bool isPerform = false)
        {
            /*" -3209- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3.WSQLCODE);

            /*" -3212- DISPLAY '***********************************************************' UPON CONSOLE. */
            _.Display($"***********************************************************");

            /*" -3215- DISPLAY '*      -------------       ----------------------         *' UPON CONSOLE. */
            _.Display($"*      -------------       ----------------------         *");

            /*" -3218- DISPLAY '*      A T E N C A O       S R.   O P E R A D O R         *' UPON CONSOLE. */
            _.Display($"*      A T E N C A O       S R.   O P E R A D O R         *");

            /*" -3221- DISPLAY '*      -------------       ----------------------         *' UPON CONSOLE. */
            _.Display($"*      -------------       ----------------------         *");

            /*" -3224- DISPLAY '*                                                         *' UPON CONSOLE. */
            _.Display($"*                                                         *");

            /*" -3227- DISPLAY '*                   PROGRAMA ABENDADO                     *' UPON CONSOLE. */
            _.Display($"*                   PROGRAMA ABENDADO                     *");

            /*" -3230- DISPLAY '*                 PROVAVELMENTE POR LOCK                  *' UPON CONSOLE. */
            _.Display($"*                 PROVAVELMENTE POR LOCK                  *");

            /*" -3233- DISPLAY '*        VERIFIQUE O LOG ANTES DE LIGAR PARA O ANALISTA   *' UPON CONSOLE. */
            _.Display($"*        VERIFIQUE O LOG ANTES DE LIGAR PARA O ANALISTA   *");

            /*" -3236- DISPLAY '*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *' UPON CONSOLE. */
            _.Display($"*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *");

            /*" -3239- DISPLAY '*                                                         *' UPON CONSOLE. */
            _.Display($"*                                                         *");

            /*" -3242- DISPLAY '*  PERMANECENDO O ERRO, CONTACTAR O ANALISTA RESPONSAVEL  *' UPON CONSOLE. */
            _.Display($"*  PERMANECENDO O ERRO, CONTACTAR O ANALISTA RESPONSAVEL  *");

            /*" -3245- DISPLAY '*                                                         *' UPON CONSOLE. */
            _.Display($"*                                                         *");

            /*" -3248- DISPLAY '*                                                         *' UPON CONSOLE. */
            _.Display($"*                                                         *");

            /*" -3251- DISPLAY '*     SQLCODE DO ABEND ....... ' WSQLCODE UPON CONSOLE. */
            _.Display($"*     SQLCODE DO ABEND ....... {AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3.WSQLCODE}");

            /*" -3254- DISPLAY '*                                                         *' UPON CONSOLE. */
            _.Display($"*                                                         *");

            /*" -3260- DISPLAY '***********************************************************' UPON CONSOLE. */
            _.Display($"***********************************************************");

            /*" -3262- DISPLAY '***********************************************************' */
            _.Display($"***********************************************************");

            /*" -3264- DISPLAY '*      -------------       ----------------------         *' */
            _.Display($"*      -------------       ----------------------         *");

            /*" -3266- DISPLAY '*      A T E N C A O       S R.   O P E R A D O R         *' */
            _.Display($"*      A T E N C A O       S R.   O P E R A D O R         *");

            /*" -3268- DISPLAY '*      -------------       ----------------------         *' */
            _.Display($"*      -------------       ----------------------         *");

            /*" -3270- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -3272- DISPLAY '*                   PROGRAMA ABENDADO                     *' */
            _.Display($"*                   PROGRAMA ABENDADO                     *");

            /*" -3274- DISPLAY '*                 PROVAVELMENTE POR LOCK                  *' */
            _.Display($"*                 PROVAVELMENTE POR LOCK                  *");

            /*" -3276- DISPLAY '*        VERIFIQUE O LOG ANTES DE LIGAR PARA O ANALISTA   *' */
            _.Display($"*        VERIFIQUE O LOG ANTES DE LIGAR PARA O ANALISTA   *");

            /*" -3278- DISPLAY '*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *' */
            _.Display($"*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *");

            /*" -3280- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -3282- DISPLAY '*  PERMANECENDO O ERRO, CONTACTAR O ANALISTA RESPONSAVEL  *' */
            _.Display($"*  PERMANECENDO O ERRO, CONTACTAR O ANALISTA RESPONSAVEL  *");

            /*" -3284- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -3286- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -3288- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -3290- DISPLAY '*     SQLCODE DO ABEND ....... ' WSQLCODE */
            _.Display($"*     SQLCODE DO ABEND ....... {AREA_DE_WORK.WABEND.WABEND1.WABEND2.WABEND3.WSQLCODE}");

            /*" -3292- DISPLAY '***********************************************************' */
            _.Display($"***********************************************************");

            /*" -3292- GO TO R9999-00-ROT-ERRO. */

            R9999_00_ROT_ERRO(); //GOTO
            return;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R10010199_EXIT*/
    }
}