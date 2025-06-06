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
using Sias.Sinistro.DB2.SICP001S;

namespace Code
{
    public class SICP001S
    {
        public bool IsCall { get; set; }

        public SICP001S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SINISTRO/FINANCEIRO                *      */
        /*"      *   PROGRAMA ...............  SICP001S                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  HERVAL SOUZA                       *      */
        /*"      *   PROGRAMADOR ............  HERVAL SOUZA                       *      */
        /*"      *   DATA CODIFICACAO .......  NOVEMBRO/ 2021                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO:                                                      *      */
        /*"      *   CARREGAR OS DADOS NA ESTRUTURA DE COMUNICACAO COM O MCP PARA *      */
        /*"      *   AS OPERACOES DE SINISTRO.                                    *      */
        /*"      *   CRITERIOS RETIRADOS DO SISAP01B.                             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * HISTORICO DE VERSOES                                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO: V.12  DATA:18-09-2024  JAZZ: 596266   HERVAL SOUZA     *      */
        /*"      * ALTERACAO: .IDENTIFICAR FINANCEIRO DE REPASSE CAIXA, DEVIDO    *      */
        /*"      *            AO SIAS GRAVAR 2 OPERA��ES DE PAGAMENTO NESSE CASO. *      */
        /*"      *            .CORRE��O DE DIAPLAY COM SICP002B                   *      */
        /*"      *            .INCLUIR TRATAMENTO PARA SIC5002B                   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO: V.11  DATA:01-07-2024  JAZZ: 593169   HERVAL JOSE      *      */
        /*"      * ALTERACAO: CORRECAO NA BUSCA DO PROCESSO JURIDICO REFERENTE    *      */
        /*"      *            AO PAGAMENTO.                                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO: V.10  DATA:19-08-2023  JAZZ: 524.617 - ROGER PIRES     *      */
        /*"      * ALTERACAO: SEGREGACAO SINISTRO MCP CNP - MCP CVP               *      */
        /*"      *            IDENTIFICACAO DO CODIGO DA EMPRESA                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO: V.09  DATA:30-06-2023  JAZZ: 508892     HERVAL SOUZA   *      */
        /*"      * ALTERACAO: 1- Ajustar  erro em Data Nula.                      *      */
        /*"      *            2- Carregar novos campos nas tabelas                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO: V.08  DATA:22-12-2022  JAZZ: 454897     HERVAL SOUZA   *      */
        /*"      * ALTERACAO: 1- Ajustar  a identificação de erro MCP.            *      */
        /*"      *            2- Ajustar dados INSS não enviado ao MCP            *      */
        /*"      *            3- Ajustar envio CNAE-CPRB envio errado             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO: V.07  DATA:11-07-2022  JAZZ: 401113     HERVAL SOUZA   *      */
        /*"      * ALTERACAO: 1- Ajustar campo COD_IMPOSTO_LIMINAR, eh CHAR       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO: V.06  DATA:08-07-2022  JAZZ: 401113     HERVAL SOUZA   *      */
        /*"      * ALTERACAO: 1- Ajustar campo COD_IMPOSTO_LIMINAR                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO: V.05  DATA:20-05-2022  JAZZ: ABEND     HERVAL SOUZA    *      */
        /*"      * ALTERACAO: 1- CAUSA DO ABEND FOI SICP101S                      *      */
        /*"      *             RETIRAR A CLAUSULA "WITH UR" NAO EH NECESSARIA     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO: V.04  DATA:19-05-2022  JAZZ: ABEND     HERVAL SOUZA    *      */
        /*"      * ALTERACAO: 1- CORRIGIR ABEND VINDO DA CB1061B. NAO ACHOU       *      */
        /*"      *             REGISTRO NA MOVTO_DEBITOCC_CEF.                    *      */
        /*"      *             INCLUIR A CLAUSULA "WITH UR"                       *      */
        /*"      *            2- IMPEDIR GERAR NOVO PAGAMENTO PARA O MESMO        *      */
        /*"      *            SINISTRO, OCORR-HISTORICO, COD-OPERACAO, SE O       *      */
        /*"      *            REGISTRO NAO ESTIVER EM ERRO.                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *      V.03      16-05-2022 HERVAL SOUZA   NAO RECUSAR PAGAMENTO *      */
        /*"      *              DE COSSEGURO ACEITO.                              *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *      V.02      10-05-2022 HERVAL SOUZA   NAO ABENDAR PAGAMENTO *      */
        /*"      *              DE COSSEGURO ACEITO. S� LISTAR E NAO GRAVAR.            */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77   HOST-SI-DATA-MOV-ABERTO   PIC  X(010) VALUE SPACES.*/
        public StringBasis HOST_SI_DATA_MOV_ABERTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77   HOST-CURRENT-TIMESTAMP    PIC  X(026) VALUE SPACES.*/
        public StringBasis HOST_CURRENT_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
        /*"77   HOST-SI-CURRENT-DATE      PIC  X(010) VALUE SPACES.*/
        public StringBasis HOST_SI_CURRENT_DATE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77   HOST-CURRENT-DATE         PIC  X(010) VALUE SPACES.*/
        public StringBasis HOST_CURRENT_DATE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77   HOST-CURRENT-TIME         PIC  X(008) VALUE SPACES.*/
        public StringBasis HOST_CURRENT_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"77   HOST-COUNT                PIC S9(009) VALUE +0 COMP.*/
        public IntBasis HOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77   W-NOME-TIPO-SEGURO            PIC X(40)       VALUE ' '.*/
        public StringBasis W_NOME_TIPO_SEGURO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @" ");
        /*"77   W-ANO-OPERACIONAL-MOVIMENTO   PIC S9(04) COMP VALUE 0.*/
        public IntBasis W_ANO_OPERACIONAL_MOVIMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77   W-ANO-CONTABIL-MOVIMENTO      PIC S9(04) COMP VALUE 0.*/
        public IntBasis W_ANO_CONTABIL_MOVIMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77   W-NOME-FORMA-PAGAMENTO        PIC X(80)       VALUE ' '.*/
        public StringBasis W_NOME_FORMA_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @" ");
        /*"77   W-NOME-SITUACAO-COBRANCA      PIC X(80)       VALUE ' '.*/
        public StringBasis W_NOME_SITUACAO_COBRANCA { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @" ");
        /*"77   W-NOME-TIPO-PESSOA            PIC X(40)       VALUE ' '.*/
        public StringBasis W_NOME_TIPO_PESSOA { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @" ");
        /*"77   W-DATA-AVISO-SIAS             PIC X(10)       VALUE ' '.*/
        public StringBasis W_DATA_AVISO_SIAS { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @" ");
        /*"77   W-NOME-QUERY                  PIC X(80)       VALUE SPACES.*/
        public StringBasis W_NOME_QUERY { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"");
        /*"77   NULL-NOM-PROGRAMA             PIC S9(04) COMP VALUE +0.*/
        public IntBasis NULL_NOM_PROGRAMA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77   NULL-COD-AGENCIA              PIC S9(04) COMP VALUE +0.*/
        public IntBasis NULL_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77   NULL-COD-BANCO                PIC S9(04) COMP VALUE +0.*/
        public IntBasis NULL_COD_BANCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77   NULL-NUM-CONTA-CNB            PIC S9(04) COMP VALUE +0.*/
        public IntBasis NULL_NUM_CONTA_CNB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77   NULL-NUM-DV-CONTA-CNB         PIC S9(04) COMP VALUE +0.*/
        public IntBasis NULL_NUM_DV_CONTA_CNB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77   NULL-IND-CONTA-BANCARIA       PIC S9(04) COMP VALUE +0.*/
        public IntBasis NULL_IND_CONTA_BANCARIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77   NULL-NOM-PESSOA               PIC S9(04) COMP VALUE +0.*/
        public IntBasis NULL_NOM_PESSOA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77   NULL-NOM-RAZAO-SOCIAL         PIC S9(04) COMP VALUE +0.*/
        public IntBasis NULL_NOM_RAZAO_SOCIAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77   NULL-PF-INSC-PREFEITURA       PIC S9(04) COMP VALUE +0.*/
        public IntBasis NULL_PF_INSC_PREFEITURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77   NULL-PF-INSC-ESTADUAL         PIC S9(04) COMP VALUE +0.*/
        public IntBasis NULL_PF_INSC_ESTADUAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77   NULL-PF-NUM-INSC-SOCIAL       PIC S9(04) COMP VALUE +0.*/
        public IntBasis NULL_PF_NUM_INSC_SOCIAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77   NULL-PF-NUM-DV-INSC-SOCIAL    PIC S9(04) COMP VALUE +0.*/
        public IntBasis NULL_PF_NUM_DV_INSC_SOCIAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77   NULL-PJ-INSC-PREFEITURA       PIC S9(04) COMP VALUE +0.*/
        public IntBasis NULL_PJ_INSC_PREFEITURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77   NULL-PJ-INSC-ESTADUAL         PIC S9(04) COMP VALUE +0.*/
        public IntBasis NULL_PJ_INSC_ESTADUAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77   NULL-PJ-NUM-INSC-SOCIAL       PIC S9(04) COMP VALUE +0.*/
        public IntBasis NULL_PJ_NUM_INSC_SOCIAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77   NULL-PJ-NUM-DV-INSC-SOCIAL    PIC S9(04) COMP VALUE +0.*/
        public IntBasis NULL_PJ_NUM_DV_INSC_SOCIAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77   NULL-NOM-LOGRADOURO           PIC S9(04) COMP VALUE +0.*/
        public IntBasis NULL_NOM_LOGRADOURO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77   NULL-DES-NUM-IMOVEL           PIC S9(04) COMP VALUE +0.*/
        public IntBasis NULL_DES_NUM_IMOVEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77   NULL-DES-COMPL-ENDERECO       PIC S9(04) COMP VALUE +0.*/
        public IntBasis NULL_DES_COMPL_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77   NULL-NOM-BAIRRO               PIC S9(04) COMP VALUE +0.*/
        public IntBasis NULL_NOM_BAIRRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77   NULL-NOM-CIDADE               PIC S9(04) COMP VALUE +0.*/
        public IntBasis NULL_NOM_CIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77   NULL-COD-CEP                  PIC S9(04) COMP VALUE +0.*/
        public IntBasis NULL_COD_CEP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77   NULL-COD-UF                   PIC S9(04) COMP VALUE +0.*/
        public IntBasis NULL_COD_UF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77   NULL-NUM-CPF                  PIC S9(04) COMP VALUE +0.*/
        public IntBasis NULL_NUM_CPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77   NULL-NUM-CNPJ                 PIC S9(04) COMP VALUE +0.*/
        public IntBasis NULL_NUM_CNPJ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77   W-NUM-CPF-NUM11               PIC  9(11)        VALUE 0.*/
        public IntBasis W_NUM_CPF_NUM11 { get; set; } = new IntBasis(new PIC("9", "11", "9(11)"));
        /*"77   W-NUM-CNPJ-NUM14              PIC  9(14)        VALUE 0.*/
        public IntBasis W_NUM_CNPJ_NUM14 { get; set; } = new IntBasis(new PIC("9", "14", "9(14)"));
        /*"77   W-NUMERO-CPF-BASE             PIC  X(11)        VALUE ' '.*/
        public StringBasis W_NUMERO_CPF_BASE { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @" ");
        /*"77   W-NUMERO-CNPJ-BASE            PIC  X(14)        VALUE ' '.*/
        public StringBasis W_NUMERO_CNPJ_BASE { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @" ");
        /*"77   W-PF-INSC-PREFEITURA          PIC S9(15) COMP-3 VALUE +0.*/
        public IntBasis W_PF_INSC_PREFEITURA { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77   W-PF-INSC-ESTADUAL            PIC S9(15) COMP-3 VALUE +0.*/
        public IntBasis W_PF_INSC_ESTADUAL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77   W-PF-NUM-INSC-SOCIAL          PIC S9(15) COMP-3 VALUE +0.*/
        public IntBasis W_PF_NUM_INSC_SOCIAL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77   W-PF-NUM-DV-INSC-SOCIAL       PIC S9(15) COMP-3 VALUE +0.*/
        public IntBasis W_PF_NUM_DV_INSC_SOCIAL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77   W-PJ-INSC-PREFEITURA          PIC S9(15) COMP-3 VALUE +0.*/
        public IntBasis W_PJ_INSC_PREFEITURA { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77   W-PJ-INSC-ESTADUAL            PIC S9(15) COMP-3 VALUE +0.*/
        public IntBasis W_PJ_INSC_ESTADUAL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77   W-PJ-NUM-INSC-SOCIAL          PIC S9(15) COMP-3 VALUE +0.*/
        public IntBasis W_PJ_NUM_INSC_SOCIAL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77   W-PJ-NUM-DV-INSC-SOCIAL       PIC S9(15) COMP-3 VALUE +0.*/
        public IntBasis W_PJ_NUM_DV_INSC_SOCIAL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77   NULL-NUM-DOC-FISCAL           PIC S9(04) COMP VALUE +0.*/
        public IntBasis NULL_NUM_DOC_FISCAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77   NULL-SERIE-DOC-FISCAL         PIC S9(04) COMP VALUE +0.*/
        public IntBasis NULL_SERIE_DOC_FISCAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77   NULL-DATA-EMISSAO-DOC         PIC S9(04) COMP VALUE +0.*/
        public IntBasis NULL_DATA_EMISSAO_DOC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77   WH-PROGRAMA-NULL              PIC S9(04) COMP VALUE +0.*/
        public IntBasis WH_PROGRAMA_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  FIPADOIM-COD-IMPOSTO-SAP-NN    PIC S9(04) COMP VALUE +0.*/
        public IntBasis FIPADOIM_COD_IMPOSTO_SAP_NN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  WH-SEXO-NULL                PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_SEXO_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-CPF-CNPJ-BENEF-NULL      PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_CPF_CNPJ_BENEF_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-LOGRADOURO-NULL          PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_LOGRADOURO_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-NUM-RESIDENCIA-NULL      PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_NUM_RESIDENCIA_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-COMPL-ENDERECO-NULL      PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_COMPL_ENDERECO_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-BAIRRO-NULL              PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_BAIRRO_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-CIDADE-NULL              PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_CIDADE_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-UF-NULL                  PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_UF_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-CEP-NULL                 PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_CEP_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-EMAIL-NULL               PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_EMAIL_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-TELEFONE-NULL            PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_TELEFONE_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-FAX-NULL                 PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_FAX_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-INSC-MUNICIPAL-NULL      PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_INSC_MUNICIPAL_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-INSC-ESTADUAL-NULL       PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_INSC_ESTADUAL_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-OPT-SIMPLES-FEDERAL-NULL PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_OPT_SIMPLES_FEDERAL_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-CONVENIO-NULL            PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_CONVENIO_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-TP-CONVENIO-NULL         PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_TP_CONVENIO_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-FORMA-PAG-COB-NULL       PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_FORMA_PAG_COB_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-DOC-SIACC-NULL           PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_DOC_SIACC_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-BANCO-NULL               PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_BANCO_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-AGENCIA-NULL             PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_AGENCIA_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-DV-AGENCIA-NULL          PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_DV_AGENCIA_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-OPERACAO-CONTA-NULL      PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_OPERACAO_CONTA_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-CC-NULL                  PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_CC_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-DV-CONTA-NULL            PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_DV_CONTA_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-CONGENERE-NULL           PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_CONGENERE_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-FONTE-SIAS-NULL          PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_FONTE_SIAS_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-RAMO-SUSEP-NULL          PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_RAMO_SUSEP_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-PRODUTO-NULL             PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_PRODUTO_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-APOLICE-NULL             PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_APOLICE_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-OPERACAO-NULL            PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_OPERACAO_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-OCORR-HISTORICO-NULL     PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_OCORR_HISTORICO_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-AVISO-NULL               PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_AVISO_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-COMUNICACAO-NULL         PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_COMUNICACAO_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-SENTENCA-JUDICIAL-NULL   PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_SENTENCA_JUDICIAL_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-COMUNIC-SENTEN-NULL      PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_COMUNIC_SENTEN_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-PROCES-JURID-NULL        PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_PROCES_JURID_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-SERVICO-SAP-NULL         PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_SERVICO_SAP_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-FONTE-ISS-NULL           PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_FONTE_ISS_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-DOC-FISCAL-NULL          PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_DOC_FISCAL_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-SERIE-DOC-FISCAL-NULL    PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_SERIE_DOC_FISCAL_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-AGRUPADOR-NULL           PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_AGRUPADOR_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-CPF-CNPJ-TOMADOR-NULL    PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_CPF_CNPJ_TOMADOR_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-INDICATIVO-OBRA-NULL     PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_INDICATIVO_OBRA_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-NACIONAL-OBRA-NULL       PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_NACIONAL_OBRA_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-NOTA-FISCAL-NULL         PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_NOTA_FISCAL_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-CNAE-CPRB-NULL           PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_CNAE_CPRB_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-PROCESSO-JUD-NULL        PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_PROCESSO_JUD_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-TP-SERVICO-INSS-NULL     PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_TP_SERVICO_INSS_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-IMPOSTO-LIMINAR-NULL     PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_IMPOSTO_LIMINAR_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-PROPOSTA-NULL            PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_PROPOSTA_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-CERTIFICADO-NULL         PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_CERTIFICADO_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-ENDOSSO-NULL             PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_ENDOSSO_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-PARCELA-NULL             PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_PARCELA_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-NIT-INSS-NULL            PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_NIT_INSS_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-CANAL-VENDA-NULL         PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_CANAL_VENDA_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-TITULO-NULL              PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_TITULO_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-CEDENTE-NULL             PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_CEDENTE_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-COMPROMISSO-NULL         PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_COMPROMISSO_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-INFO-CART-CRED-NULL      PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_INFO_CART_CRED_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-QTD-PARCELA-NULL         PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_QTD_PARCELA_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-IDLG-MCP-NULL            PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_IDLG_MCP_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-IDLG-SAP-NULL            PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_IDLG_SAP_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-ENVIO-MCP-NULL           PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_ENVIO_MCP_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-RETORNO-SAP-ARQG-NULL    PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_RETORNO_SAP_ARQG_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-RETORNO-SAP-ARQH-NULL    PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_RETORNO_SAP_ARQH_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-EFETIVO-PGTO-COB-NULL    PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_EFETIVO_PGTO_COB_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-ID-ENVIO-NULL            PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_ID_ENVIO_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-ID-ENVIO-HIST-NULL       PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_ID_ENVIO_HIST_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-SI-ENVIO-NULL            PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_SI_ENVIO_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-SI-RETORNO-H-NULL        PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_SI_RETORNO_H_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-EFETIVO-PGTO-NULL        PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_EFETIVO_PGTO_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-MOVTO-ARQH-NULL          PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_MOVTO_ARQH_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-MOVTO-HISTORICO-NULL     PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_MOVTO_HISTORICO_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-ALICOTA-NULL             PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_ALICOTA_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WH-TRIBUTO-NULL             PIC S9(004)  COMP-5    VALUE +0.*/
        public IntBasis WH_TRIBUTO_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01           WS-IND-NOME-HIST       PIC X(001) VALUE 'N'.*/
        public StringBasis WS_IND_NOME_HIST { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"01           AREA-DE-WORK.*/
        public SICP001S_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SICP001S_AREA_DE_WORK();
        public class SICP001S_AREA_DE_WORK : VarBasis
        {
            /*"  05         WS-SI239-SQL100   PIC  X(003)         VALUE 'NAO'.*/
            public StringBasis WS_SI239_SQL100 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"  05         WS-SI237-SQL100   PIC  X(003)         VALUE 'NAO'.*/
            public StringBasis WS_SI237_SQL100 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"  05         WS-SINIS-SQL100   PIC  X(003)         VALUE 'NAO'.*/
            public StringBasis WS_SINIS_SQL100 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"  05         WS-OPE-1020-EXISTE                               PIC  X(003)         VALUE 'NAO'.*/
            public StringBasis WS_OPE_1020_EXISTE { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"  05         WS-SMALLINT       PIC  ZZZZ9-  OCCURS 5 TIMES.*/
            public ListBasis<IntBasis, Int64> WS_SMALLINT { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "6", "ZZZZ9-"), 5);
            /*"  05         WS-PRIMEIRA-VEZ   PIC  X(003)         VALUE 'SIM'.*/
            public StringBasis WS_PRIMEIRA_VEZ { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"SIM");
            /*"  05         WS-DTA-NULL       PIC  X(010)  VALUE '1212-12-12'.*/
            public StringBasis WS_DTA_NULL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"1212-12-12");
            /*"  05         WS-APOLICE-ED     PIC  9(013).*/
            public IntBasis WS_APOLICE_ED { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"  05         WS-OPERACAO-ED    PIC  9(004).*/
            public IntBasis WS_OPERACAO_ED { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         WS-BIGINT1-ED     PIC  9(019).*/
            public IntBasis WS_BIGINT1_ED { get; set; } = new IntBasis(new PIC("9", "19", "9(019)."));
            /*"  05         WS-BIGINT2-ED     PIC  9(019).*/
            public IntBasis WS_BIGINT2_ED { get; set; } = new IntBasis(new PIC("9", "19", "9(019)."));
            /*"  05         WS-PROGRAMA       PIC  X(008).*/
            public StringBasis WS_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  05         CODOPE-GERAL      PIC  X(010)  VALUE SPACES.*/
            public StringBasis CODOPE_GERAL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         TITLE-MEDI-GERAL  PIC  X(030)  VALUE SPACES.*/
            public StringBasis TITLE_MEDI_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
            /*"  05         WS-DT-NULL        PIC  X(010)  VALUE '1212-12-12'.*/
            public StringBasis WS_DT_NULL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"1212-12-12");
            /*"  05         WS-IMPOSTO-LIMINAR-NUM                               PIC  99        VALUE ZEROS.*/
            public IntBasis WS_IMPOSTO_LIMINAR_NUM { get; set; } = new IntBasis(new PIC("9", "2", "99"));
            /*"  05         WS-IMPOSTO-LIMINAR-CHR             REDEFINES   WS-IMPOSTO-LIMINAR-NUM                               PIC  X(002).*/
            private _REDEF_StringBasis _ws_imposto_liminar_chr { get; set; }
            public _REDEF_StringBasis WS_IMPOSTO_LIMINAR_CHR
            {
                get { _ws_imposto_liminar_chr = new _REDEF_StringBasis(new PIC("X", "002", "X(002).")); ; _.Move(WS_IMPOSTO_LIMINAR_NUM, _ws_imposto_liminar_chr); VarBasis.RedefinePassValue(WS_IMPOSTO_LIMINAR_NUM, _ws_imposto_liminar_chr, WS_IMPOSTO_LIMINAR_NUM); _ws_imposto_liminar_chr.ValueChanged += () => { _.Move(_ws_imposto_liminar_chr, WS_IMPOSTO_LIMINAR_NUM); }; return _ws_imposto_liminar_chr; }
                set { VarBasis.RedefinePassValue(value, _ws_imposto_liminar_chr, WS_IMPOSTO_LIMINAR_NUM); }
            }  //Redefines
            /*"  05         WS-NAT-RENDIMENTOS-CHR                               PIC  X(005)    VALUE SPACES.*/
            public StringBasis WS_NAT_RENDIMENTOS_CHR { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
            /*"  05         WS-NAT-RENDIMENTOS-NUM             REDEFINES   WS-NAT-RENDIMENTOS-CHR                               PIC  9(005).*/
            private _REDEF_IntBasis _ws_nat_rendimentos_num { get; set; }
            public _REDEF_IntBasis WS_NAT_RENDIMENTOS_NUM
            {
                get { _ws_nat_rendimentos_num = new _REDEF_IntBasis(new PIC("9", "005", "9(005).")); ; _.Move(WS_NAT_RENDIMENTOS_CHR, _ws_nat_rendimentos_num); VarBasis.RedefinePassValue(WS_NAT_RENDIMENTOS_CHR, _ws_nat_rendimentos_num, WS_NAT_RENDIMENTOS_CHR); _ws_nat_rendimentos_num.ValueChanged += () => { _.Move(_ws_nat_rendimentos_num, WS_NAT_RENDIMENTOS_CHR); }; return _ws_nat_rendimentos_num; }
                set { VarBasis.RedefinePassValue(value, _ws_nat_rendimentos_num, WS_NAT_RENDIMENTOS_CHR); }
            }  //Redefines
            /*"  05         WS-RETURN-CODE    PIC  9(009)    VALUE ZEROS.*/
            public IntBasis WS_RETURN_CODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WSL-SQLCODE       PIC  9(009)    VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WS-ENDERECO.*/
            public SICP001S_WS_ENDERECO WS_ENDERECO { get; set; } = new SICP001S_WS_ENDERECO();
            public class SICP001S_WS_ENDERECO : VarBasis
            {
                /*"    10       WS-TIPO-LOG       PIC  X(003)    VALUE SPACES.*/
                public StringBasis WS_TIPO_LOG { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    10       FILLER            PIC  X(001)    VALUE SPACES.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WS-LOGRADOURO     PIC  X(020)    VALUE SPACES.*/
                public StringBasis WS_LOGRADOURO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                /*"    10       FILLER            PIC  X(001)    VALUE SPACES.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WS-NUM-IMOVEL     PIC  X(005)    VALUE SPACES.*/
                public StringBasis WS_NUM_IMOVEL { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"  05         WS-TRATA-TAMANHO.*/
            }
            public SICP001S_WS_TRATA_TAMANHO WS_TRATA_TAMANHO { get; set; } = new SICP001S_WS_TRATA_TAMANHO();
            public class SICP001S_WS_TRATA_TAMANHO : VarBasis
            {
                /*"     10      WS-TRATA-TAMANHO-1    PIC  9(01) VALUE ZEROS.*/
                public IntBasis WS_TRATA_TAMANHO_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
                /*"     10      WS-TRATA-TAMANHO-2    PIC  9(02) VALUE ZEROS.*/
                public IntBasis WS_TRATA_TAMANHO_2 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"     10      WS-TRATA-TAMANHO-4    PIC  9(04) VALUE ZEROS.*/
                public IntBasis WS_TRATA_TAMANHO_4 { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"     10      WS-TRATA-TAMANHO-13   PIC  9(13) VALUE ZEROS.*/
                public IntBasis WS_TRATA_TAMANHO_13 { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
                /*"     10      WS-TRATA-TAMANHO-14   PIC  9(14) VALUE ZEROS.*/
                public IntBasis WS_TRATA_TAMANHO_14 { get; set; } = new IntBasis(new PIC("9", "14", "9(14)"));
                /*"     10      WS-TRATA-TAMANHO-15   PIC  9(15) VALUE ZEROS.*/
                public IntBasis WS_TRATA_TAMANHO_15 { get; set; } = new IntBasis(new PIC("9", "15", "9(15)"));
                /*"     10      WS-TRATA-TAMANHO-16   PIC  9(16) VALUE ZEROS.*/
                public IntBasis WS_TRATA_TAMANHO_16 { get; set; } = new IntBasis(new PIC("9", "16", "9(16)"));
                /*"     10      WS-TRATA-TAMANHO-17   PIC  9(17) VALUE ZEROS.*/
                public IntBasis WS_TRATA_TAMANHO_17 { get; set; } = new IntBasis(new PIC("9", "17", "9(17)"));
                /*"  05   W-NUM4                  PIC 9(04)  VALUE 0.*/
            }
            public IntBasis W_NUM4 { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
            /*"  05   W-NUM5                  PIC 9(06)  VALUE 0.*/
            public IntBasis W_NUM5 { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
            /*"  05   WS-VLR-AUX-14           PIC  ----------9,99.*/
            public DoubleBasis WS_VLR_AUX_14 { get; set; } = new DoubleBasis(new PIC("9", "11", "----------9V99."), 2);
            /*"  05         WHORA.*/
            public SICP001S_WHORA WHORA { get; set; } = new SICP001S_WHORA();
            public class SICP001S_WHORA : VarBasis
            {
                /*"    10       WHORA-HH          PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_HH { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE ':'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"    10       WHORA-MM          PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE ':'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"    10       WHORA-SS          PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_SS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05 W-ATTR-DESTINO            PIC X(30) VALUE SPACES.*/
            }
            public StringBasis W_ATTR_DESTINO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 W-AGRUPADOR-1.*/
            public SICP001S_W_AGRUPADOR_1 W_AGRUPADOR_1 { get; set; } = new SICP001S_W_AGRUPADOR_1();
            public class SICP001S_W_AGRUPADOR_1 : VarBasis
            {
                /*"     10 W-AGRUPADOR-LEGENDA           PIC X(11) VALUE ' '.*/
                public StringBasis W_AGRUPADOR_LEGENDA { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @" ");
                /*"     10 W-AGRUPADOR-MINUTO-SSSSSS     PIC X(09) VALUE ' '.*/
                public StringBasis W_AGRUPADOR_MINUTO_SSSSSS { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @" ");
                /*"  05 W-IDLG-SIAS-SINISTRO.*/
            }
            public SICP001S_W_IDLG_SIAS_SINISTRO W_IDLG_SIAS_SINISTRO { get; set; } = new SICP001S_W_IDLG_SIAS_SINISTRO();
            public class SICP001S_W_IDLG_SIAS_SINISTRO : VarBasis
            {
                /*"    10 W-IDLG-SINISTRO               PIC X(01) VALUE ' '.*/
                public StringBasis W_IDLG_SINISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"    10 W-IDLG-NUM-APOL-SINISTRO      PIC 9(13) VALUE 0.*/
                public IntBasis W_IDLG_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
                /*"    10 FILLER                        PIC X(01) VALUE '|'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"|");
                /*"    10 W-IDLG-OCORR-HISTORICO        PIC 9(05) VALUE 0.*/
                public IntBasis W_IDLG_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("9", "5", "9(05)"));
                /*"    10 FILLER                        PIC X(01) VALUE '|'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"|");
                /*"    10 W-IDLG-COD-OPERACAO           PIC 9(04) VALUE 0.*/
                public IntBasis W_IDLG_COD_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"    10 FILLER                        PIC X(01) VALUE '|'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"|");
                /*"    10 W-IDLG-TIPO-MOVIMENTO         PIC X(01) VALUE ' '.*/
                public StringBasis W_IDLG_TIPO_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"    10 FILLER                        PIC X(01) VALUE '|'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"|");
                /*"    10 W-IDLG-FORMA-PAGAMENTO        PIC X(01) VALUE ' '.*/
                public StringBasis W_IDLG_FORMA_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"    10 FILLER                        PIC X(01) VALUE '|'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"|");
                /*"    10 W-IDLG-COMPLEMENTO            PIC X(10).*/
                public StringBasis W_IDLG_COMPLEMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"    10 W-IDLG-COMPLEMENTO-1   REDEFINES  W-IDLG-COMPLEMENTO.*/
                private _REDEF_SICP001S_W_IDLG_COMPLEMENTO_1 _w_idlg_complemento_1 { get; set; }
                public _REDEF_SICP001S_W_IDLG_COMPLEMENTO_1 W_IDLG_COMPLEMENTO_1
                {
                    get { _w_idlg_complemento_1 = new _REDEF_SICP001S_W_IDLG_COMPLEMENTO_1(); _.Move(W_IDLG_COMPLEMENTO, _w_idlg_complemento_1); VarBasis.RedefinePassValue(W_IDLG_COMPLEMENTO, _w_idlg_complemento_1, W_IDLG_COMPLEMENTO); _w_idlg_complemento_1.ValueChanged += () => { _.Move(_w_idlg_complemento_1, W_IDLG_COMPLEMENTO); }; return _w_idlg_complemento_1; }
                    set { VarBasis.RedefinePassValue(value, _w_idlg_complemento_1, W_IDLG_COMPLEMENTO); }
                }  //Redefines
                public class _REDEF_SICP001S_W_IDLG_COMPLEMENTO_1 : VarBasis
                {
                    /*"       15 W-IDLG-NUM-CHEQUE-INTERNO  PIC 9(10).*/
                    public IntBasis W_IDLG_NUM_CHEQUE_INTERNO { get; set; } = new IntBasis(new PIC("9", "10", "9(10)."));
                    /*"    10 W-IDLG-COMPLEMENTO-2   REDEFINES  W-IDLG-COMPLEMENTO.*/

                    public _REDEF_SICP001S_W_IDLG_COMPLEMENTO_1()
                    {
                        W_IDLG_NUM_CHEQUE_INTERNO.ValueChanged += OnValueChanged;
                    }

                }
                private _REDEF_SICP001S_W_IDLG_COMPLEMENTO_2 _w_idlg_complemento_2 { get; set; }
                public _REDEF_SICP001S_W_IDLG_COMPLEMENTO_2 W_IDLG_COMPLEMENTO_2
                {
                    get { _w_idlg_complemento_2 = new _REDEF_SICP001S_W_IDLG_COMPLEMENTO_2(); _.Move(W_IDLG_COMPLEMENTO, _w_idlg_complemento_2); VarBasis.RedefinePassValue(W_IDLG_COMPLEMENTO, _w_idlg_complemento_2, W_IDLG_COMPLEMENTO); _w_idlg_complemento_2.ValueChanged += () => { _.Move(_w_idlg_complemento_2, W_IDLG_COMPLEMENTO); }; return _w_idlg_complemento_2; }
                    set { VarBasis.RedefinePassValue(value, _w_idlg_complemento_2, W_IDLG_COMPLEMENTO); }
                }  //Redefines
                public class _REDEF_SICP001S_W_IDLG_COMPLEMENTO_2 : VarBasis
                {
                    /*"       15 W-IDLG-NSAS                PIC 9(10).*/
                    public IntBasis W_IDLG_NSAS { get; set; } = new IntBasis(new PIC("9", "10", "9(10)."));
                    /*"    10 W-IDLG-COMPLEMENTO-3   REDEFINES  W-IDLG-COMPLEMENTO.*/

                    public _REDEF_SICP001S_W_IDLG_COMPLEMENTO_2()
                    {
                        W_IDLG_NSAS.ValueChanged += OnValueChanged;
                    }

                }
                private _REDEF_SICP001S_W_IDLG_COMPLEMENTO_3 _w_idlg_complemento_3 { get; set; }
                public _REDEF_SICP001S_W_IDLG_COMPLEMENTO_3 W_IDLG_COMPLEMENTO_3
                {
                    get { _w_idlg_complemento_3 = new _REDEF_SICP001S_W_IDLG_COMPLEMENTO_3(); _.Move(W_IDLG_COMPLEMENTO, _w_idlg_complemento_3); VarBasis.RedefinePassValue(W_IDLG_COMPLEMENTO, _w_idlg_complemento_3, W_IDLG_COMPLEMENTO); _w_idlg_complemento_3.ValueChanged += () => { _.Move(_w_idlg_complemento_3, W_IDLG_COMPLEMENTO); }; return _w_idlg_complemento_3; }
                    set { VarBasis.RedefinePassValue(value, _w_idlg_complemento_3, W_IDLG_COMPLEMENTO); }
                }  //Redefines
                public class _REDEF_SICP001S_W_IDLG_COMPLEMENTO_3 : VarBasis
                {
                    /*"       15 W-IDLG-NUM-ACORDO          PIC 9(05).*/
                    public IntBasis W_IDLG_NUM_ACORDO { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
                    /*"       15 FILLER                     PIC X(01).*/
                    public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                    /*"       15 W-IDLG-NUM-PARCELA         PIC 9(04).*/
                    public IntBasis W_IDLG_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                    /*"  05 W-LOTE-NUM-SEQUENCIA            PIC 9(09) VALUE 0.*/

                    public _REDEF_SICP001S_W_IDLG_COMPLEMENTO_3()
                    {
                        W_IDLG_NUM_ACORDO.ValueChanged += OnValueChanged;
                        FILLER_9.ValueChanged += OnValueChanged;
                        W_IDLG_NUM_PARCELA.ValueChanged += OnValueChanged;
                    }

                }
            }
            public IntBasis W_LOTE_NUM_SEQUENCIA { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"  05       WSTATUS               PIC  9(002)     VALUE ZEROS.*/
            public IntBasis WSTATUS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05 W-LOTE.*/
            public SICP001S_W_LOTE W_LOTE { get; set; } = new SICP001S_W_LOTE();
            public class SICP001S_W_LOTE : VarBasis
            {
                /*"    10 W-LOTE-NOME-PROGRAMA.*/
                public SICP001S_W_LOTE_NOME_PROGRAMA W_LOTE_NOME_PROGRAMA { get; set; } = new SICP001S_W_LOTE_NOME_PROGRAMA();
                public class SICP001S_W_LOTE_NOME_PROGRAMA : VarBasis
                {
                    /*"       15 FILLER                     PIC X(07) VALUE ' '.*/
                    public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @" ");
                    /*"       15 W-LOTE-PROGRAMA-FILLER     PIC X(01) VALUE ' '.*/
                    public StringBasis W_LOTE_PROGRAMA_FILLER { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                    /*"    10 W-LOTE-SIGLA-MODULO           PIC X(02) VALUE '??'.*/
                }
                public StringBasis W_LOTE_SIGLA_MODULO { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"??");
                /*"    10 W-LOTE-DATE-AAAA              PIC 9(04) VALUE 9999.*/
                public IntBasis W_LOTE_DATE_AAAA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"), 9999);
                /*"    10 W-LOTE-DATE-MM                PIC 9(02) VALUE 12.*/
                public IntBasis W_LOTE_DATE_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"), 12);
                /*"    10 W-LOTE-DATE-DD                PIC 9(02) VALUE 31.*/
                public IntBasis W_LOTE_DATE_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"), 31);
                /*"    10 W-LOTE-TIME-HH                PIC 9(02) VALUE 01.*/
                public IntBasis W_LOTE_TIME_HH { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"), 01);
                /*"    10 W-LOTE-TIME-MM                PIC 9(02) VALUE 01.*/
                public IntBasis W_LOTE_TIME_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"), 01);
                /*"    10 W-LOTE-TIME-SS                PIC 9(02) VALUE 01.*/
                public IntBasis W_LOTE_TIME_SS { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"), 01);
                /*"    05 W-BANKK.*/
                public SICP001S_W_BANKK W_BANKK { get; set; } = new SICP001S_W_BANKK();
                public class SICP001S_W_BANKK : VarBasis
                {
                    /*"       10 W-COD-BANCO             PIC 9(03) VALUE 0.*/
                    public IntBasis W_COD_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
                    /*"       10 W-DV-BANCO              PIC 9(01) VALUE 0.*/
                    public IntBasis W_DV_BANCO { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
                    /*"       10 W-COD-AGENCIA           PIC 9(04) VALUE 0.*/
                    public IntBasis W_COD_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                    /*"    05 WS-LOTE-ANT                PIC S9(09) VALUE ZEROS.*/
                }
                public IntBasis WS_LOTE_ANT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
                /*"    05 W-CONTA-SAP.*/
                public SICP001S_W_CONTA_SAP W_CONTA_SAP { get; set; } = new SICP001S_W_CONTA_SAP();
                public class SICP001S_W_CONTA_SAP : VarBasis
                {
                    /*"       10 W-NUM-CONTA-SAP         PIC 9(12) VALUE 0.*/
                    public IntBasis W_NUM_CONTA_SAP { get; set; } = new IntBasis(new PIC("9", "12", "9(12)"));
                    /*"       10 FILLER                  REDEFINES W-NUM-CONTA-SAP.*/
                    private _REDEF_SICP001S_FILLER_11 _filler_11 { get; set; }
                    public _REDEF_SICP001S_FILLER_11 FILLER_11
                    {
                        get { _filler_11 = new _REDEF_SICP001S_FILLER_11(); _.Move(W_NUM_CONTA_SAP, _filler_11); VarBasis.RedefinePassValue(W_NUM_CONTA_SAP, _filler_11, W_NUM_CONTA_SAP); _filler_11.ValueChanged += () => { _.Move(_filler_11, W_NUM_CONTA_SAP); }; return _filler_11; }
                        set { VarBasis.RedefinePassValue(value, _filler_11, W_NUM_CONTA_SAP); }
                    }  //Redefines
                    public class _REDEF_SICP001S_FILLER_11 : VarBasis
                    {
                        /*"          15 W-TIPO-OPER-BB       PIC 9(003).*/
                        public IntBasis W_TIPO_OPER_BB { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                        /*"          15 FILLER               PIC 9(009).*/
                        public IntBasis FILLER_12 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                        /*"  05 W-ATTR17.*/

                        public _REDEF_SICP001S_FILLER_11()
                        {
                            W_TIPO_OPER_BB.ValueChanged += OnValueChanged;
                            FILLER_12.ValueChanged += OnValueChanged;
                        }

                    }
                }
            }
            public SICP001S_W_ATTR17 W_ATTR17 { get; set; } = new SICP001S_W_ATTR17();
            public class SICP001S_W_ATTR17 : VarBasis
            {
                /*"     10 W-ATTR17-SISTEMA             PIC X(02) VALUE 'SI'.*/
                public StringBasis W_ATTR17_SISTEMA { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"SI");
                /*"     10 W-ATTR17-USUARIO             PIC X(08) VALUE ' '.*/
                public StringBasis W_ATTR17_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @" ");
                /*"  05  WFIM-LE-MOVDEBCE-1          PIC  X(003)    VALUE SPACES.*/
            }
            public StringBasis WFIM_LE_MOVDEBCE_1 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05  WFIM-IMPOSTOS               PIC  X(003)    VALUE SPACES.*/
            public StringBasis WFIM_IMPOSTOS { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05  W-AC-LIDOS-MOVDEBCE         PIC  9(005)    VALUE ZEROS.*/
            public IntBasis W_AC_LIDOS_MOVDEBCE { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05  WS-USO-EMPRESA-SICOV.*/
            public SICP001S_WS_USO_EMPRESA_SICOV WS_USO_EMPRESA_SICOV { get; set; } = new SICP001S_WS_USO_EMPRESA_SICOV();
            public class SICP001S_WS_USO_EMPRESA_SICOV : VarBasis
            {
                /*"      10 WS-USO-EMPRESA-SICOV-TXT1    PIC  X(40) VALUE SPACES.*/
                public StringBasis WS_USO_EMPRESA_SICOV_TXT1 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"      10 FILLER                       PIC  X(01) VALUE SPACES.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"      10 WS-USO-EMPRESA-SICOV-25      PIC  X(25) VALUE SPACES.*/
                public StringBasis WS_USO_EMPRESA_SICOV_25 { get; set; } = new StringBasis(new PIC("X", "25", "X(25)"), @"");
                /*"      10 FILLER                       PIC  X(01) VALUE SPACES.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"      10 WS-USO-EMPRESA-SICOV-TXT2    PIC  X(40) VALUE SPACES.*/
                public StringBasis WS_USO_EMPRESA_SICOV_TXT2 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"      10 FILLER                       PIC  X(01) VALUE SPACES.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"      10 WS-USO-EMPRESA-SICOV-60      PIC  X(60) VALUE SPACES.*/
                public StringBasis WS_USO_EMPRESA_SICOV_60 { get; set; } = new StringBasis(new PIC("X", "60", "X(60)"), @"");
                /*"  05  W-CHAVE-ORIGEM-CADASTRO  PIC  X(080)    VALUE SPACES.*/
            }
            public StringBasis W_CHAVE_ORIGEM_CADASTRO { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"");
            /*"  05  W-CHAVE-TEM-IMPOSTOS     PIC  X(003)    VALUE SPACES.*/
            public StringBasis W_CHAVE_TEM_IMPOSTOS { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05  W-CHAVE-EH-PRESTADOR     PIC  X(003)    VALUE SPACES.*/
            public StringBasis W_CHAVE_EH_PRESTADOR { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05  W-CHAVE-TEM-NOTA-FISCAL        PIC X(03) VALUE  'NAO'.*/
            public StringBasis W_CHAVE_TEM_NOTA_FISCAL { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"  05  W-CHAVE-TEM-CAPA-LOTE          PIC X(03) VALUE  'NAO'.*/
            public StringBasis W_CHAVE_TEM_CAPA_LOTE { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"  05  W-CHAVE-ACHOU-NOTA-FISCAL      PIC X(03) VALUE  'NAO'.*/
            public StringBasis W_CHAVE_ACHOU_NOTA_FISCAL { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"  05  W-CHAVE-MONTA-SIACC-ESPECIAL   PIC X(03) VALUE  'NAO'.*/
            public StringBasis W_CHAVE_MONTA_SIACC_ESPECIAL { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"  05  W-CHAVE-TIPO-PESSOA-PF-PJ      PIC X(05) VALUE SPACES.*/
            public StringBasis W_CHAVE_TIPO_PESSOA_PF_PJ { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
            /*"  05  W-CHAVE-COLOCA-ENDERECO        PIC X(03) VALUE  'NAO'.*/
            public StringBasis W_CHAVE_COLOCA_ENDERECO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"  05  W-CHAVE-ACHOU-FORNECEDOR       PIC X(03) VALUE  'NAO'.*/
            public StringBasis W_CHAVE_ACHOU_FORNECEDOR { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"  05  W-CHAVE-ACHOU-FONTE-IMPOSTO    PIC X(03) VALUE  'NAO'.*/
            public StringBasis W_CHAVE_ACHOU_FONTE_IMPOSTO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"  05  W-ATTR                         PIC X(08) VALUE SPACES.*/
            public StringBasis W_ATTR { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05  W-ATTRVAL                      PIC X(30) VALUE SPACES.*/
            public StringBasis W_ATTRVAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05  W-VALO                         PIC X(23) VALUE SPACES.*/
            public StringBasis W_VALO { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
            /*"  05  W-LIB                          PIC X(40) VALUE SPACES.*/
            public StringBasis W_LIB { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
            /*"  05 W-DATA-AAAAMMDD.*/
            public SICP001S_W_DATA_AAAAMMDD W_DATA_AAAAMMDD { get; set; } = new SICP001S_W_DATA_AAAAMMDD();
            public class SICP001S_W_DATA_AAAAMMDD : VarBasis
            {
                /*"     10 W-DATA-AAAAMMDD-AAAA         PIC 9(04) VALUE ZEROS.*/
                public IntBasis W_DATA_AAAAMMDD_AAAA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"     10 W-DATA-AAAAMMDD-MM           PIC 9(02) VALUE ZEROS.*/
                public IntBasis W_DATA_AAAAMMDD_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"     10 W-DATA-AAAAMMDD-DD           PIC 9(02) VALUE ZEROS.*/
                public IntBasis W_DATA_AAAAMMDD_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"  05 W-TOTAL-VALORES                  PIC  9(16)V99 VALUE 0.*/
            }
            public DoubleBasis W_TOTAL_VALORES { get; set; } = new DoubleBasis(new PIC("9", "16", "9(16)V99"), 2);
            /*"  05 W-CNPJ-AA      PIC 9(14).*/
            public IntBasis W_CNPJ_AA { get; set; } = new IntBasis(new PIC("9", "14", "9(14)."));
            /*"  05 W-CNPJ-BB REDEFINES W-CNPJ-AA PIC X(14).*/
            private _REDEF_StringBasis _w_cnpj_bb { get; set; }
            public _REDEF_StringBasis W_CNPJ_BB
            {
                get { _w_cnpj_bb = new _REDEF_StringBasis(new PIC("X", "14", "X(14).")); ; _.Move(W_CNPJ_AA, _w_cnpj_bb); VarBasis.RedefinePassValue(W_CNPJ_AA, _w_cnpj_bb, W_CNPJ_AA); _w_cnpj_bb.ValueChanged += () => { _.Move(_w_cnpj_bb, W_CNPJ_AA); }; return _w_cnpj_bb; }
                set { VarBasis.RedefinePassValue(value, _w_cnpj_bb, W_CNPJ_AA); }
            }  //Redefines
            /*"  05 W-NUM-CPF-NUM                PIC 9(11).*/
            public IntBasis W_NUM_CPF_NUM { get; set; } = new IntBasis(new PIC("9", "11", "9(11)."));
            /*"  05 W-NUM-CPF-ALFA  REDEFINES  W-NUM-CPF-NUM  PIC X(11).*/
            private _REDEF_StringBasis _w_num_cpf_alfa { get; set; }
            public _REDEF_StringBasis W_NUM_CPF_ALFA
            {
                get { _w_num_cpf_alfa = new _REDEF_StringBasis(new PIC("X", "11", "X(11).")); ; _.Move(W_NUM_CPF_NUM, _w_num_cpf_alfa); VarBasis.RedefinePassValue(W_NUM_CPF_NUM, _w_num_cpf_alfa, W_NUM_CPF_NUM); _w_num_cpf_alfa.ValueChanged += () => { _.Move(_w_num_cpf_alfa, W_NUM_CPF_NUM); }; return _w_num_cpf_alfa; }
                set { VarBasis.RedefinePassValue(value, _w_num_cpf_alfa, W_NUM_CPF_NUM); }
            }  //Redefines
            /*"  05 W-NUM-CNPJ-NUM                PIC 9(14).*/
            public IntBasis W_NUM_CNPJ_NUM { get; set; } = new IntBasis(new PIC("9", "14", "9(14)."));
            /*"  05 W-NUM-CNPJ-ALFA  REDEFINES  W-NUM-CNPJ-NUM  PIC X(14).*/
            private _REDEF_StringBasis _w_num_cnpj_alfa { get; set; }
            public _REDEF_StringBasis W_NUM_CNPJ_ALFA
            {
                get { _w_num_cnpj_alfa = new _REDEF_StringBasis(new PIC("X", "14", "X(14).")); ; _.Move(W_NUM_CNPJ_NUM, _w_num_cnpj_alfa); VarBasis.RedefinePassValue(W_NUM_CNPJ_NUM, _w_num_cnpj_alfa, W_NUM_CNPJ_NUM); _w_num_cnpj_alfa.ValueChanged += () => { _.Move(_w_num_cnpj_alfa, W_NUM_CNPJ_NUM); }; return _w_num_cnpj_alfa; }
                set { VarBasis.RedefinePassValue(value, _w_num_cnpj_alfa, W_NUM_CNPJ_NUM); }
            }  //Redefines
            /*"  05 W-COD-SERVICO-NUM              PIC 9(04).*/
            public IntBasis W_COD_SERVICO_NUM { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"  05 W-COD-SERVICO-ALFA REDEFINES W-COD-SERVICO-NUM PIC X(04).*/
            private _REDEF_StringBasis _w_cod_servico_alfa { get; set; }
            public _REDEF_StringBasis W_COD_SERVICO_ALFA
            {
                get { _w_cod_servico_alfa = new _REDEF_StringBasis(new PIC("X", "04", "X(04).")); ; _.Move(W_COD_SERVICO_NUM, _w_cod_servico_alfa); VarBasis.RedefinePassValue(W_COD_SERVICO_NUM, _w_cod_servico_alfa, W_COD_SERVICO_NUM); _w_cod_servico_alfa.ValueChanged += () => { _.Move(_w_cod_servico_alfa, W_COD_SERVICO_NUM); }; return _w_cod_servico_alfa; }
                set { VarBasis.RedefinePassValue(value, _w_cod_servico_alfa, W_COD_SERVICO_NUM); }
            }  //Redefines
            /*"  05 W-EDICAO-33        PIC 99999,99.*/
            public DoubleBasis W_EDICAO_33 { get; set; } = new DoubleBasis(new PIC("9", "5", "99999V99."), 2);
            /*"  05 W-EDICAO-11        PIC 99999999999.*/
            public IntBasis W_EDICAO_11 { get; set; } = new IntBasis(new PIC("9", "11", "99999999999."));
            /*"  05 W-EDICAO-14        PIC 99999999999999.*/
            public IntBasis W_EDICAO_14 { get; set; } = new IntBasis(new PIC("9", "14", "99999999999999."));
            /*"  05 W-EDICAO-15        PIC 999999999999999.*/
            public IntBasis W_EDICAO_15 { get; set; } = new IntBasis(new PIC("9", "15", "999999999999999."));
            /*"  05 W-CAMPO-EDITADO.*/
            public SICP001S_W_CAMPO_EDITADO W_CAMPO_EDITADO { get; set; } = new SICP001S_W_CAMPO_EDITADO();
            public class SICP001S_W_CAMPO_EDITADO : VarBasis
            {
                /*"     10 FILLER                       PIC X(05).*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)."), @"");
                /*"     10 W-CAMPO-EDITADO-ALFA         PIC X(18).*/
                public StringBasis W_CAMPO_EDITADO_ALFA { get; set; } = new StringBasis(new PIC("X", "18", "X(18)."), @"");
                /*"     10 W-CAMPO-EDITADO-NUM    REDEFINES W-CAMPO-EDITADO-ALFA                                     PIC 9(15),99.*/
                private _REDEF_DoubleBasis _w_campo_editado_num { get; set; }
                public _REDEF_DoubleBasis W_CAMPO_EDITADO_NUM
                {
                    get { _w_campo_editado_num = new _REDEF_DoubleBasis(new PIC("9", "15", "9(15)V99."), 2); ; _.Move(W_CAMPO_EDITADO_ALFA, _w_campo_editado_num); VarBasis.RedefinePassValue(W_CAMPO_EDITADO_ALFA, _w_campo_editado_num, W_CAMPO_EDITADO_ALFA); _w_campo_editado_num.ValueChanged += () => { _.Move(_w_campo_editado_num, W_CAMPO_EDITADO_ALFA); }; return _w_campo_editado_num; }
                    set { VarBasis.RedefinePassValue(value, _w_campo_editado_num, W_CAMPO_EDITADO_ALFA); }
                }  //Redefines
                /*"  05 W-CAMPO-NUMERO                  PIC 9(15)V99 VALUE 0.*/
            }
            public DoubleBasis W_CAMPO_NUMERO { get; set; } = new DoubleBasis(new PIC("9", "15", "9(15)V99"), 2);
            /*"  05 W-VALOR-GERAL-X.*/
            public SICP001S_W_VALOR_GERAL_X W_VALOR_GERAL_X { get; set; } = new SICP001S_W_VALOR_GERAL_X();
            public class SICP001S_W_VALOR_GERAL_X : VarBasis
            {
                /*"     10 W-VALOR-GERAL-VALOR          PIC ------------9,99.*/
                public DoubleBasis W_VALOR_GERAL_VALOR { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
                /*"  05 W-CEP-NUM                       PIC 9(08) VALUE 0.*/
            }
            public IntBasis W_CEP_NUM { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"  05 W-CEP-NUMERICO  REDEFINES  W-CEP-NUM.*/
            private _REDEF_SICP001S_W_CEP_NUMERICO _w_cep_numerico { get; set; }
            public _REDEF_SICP001S_W_CEP_NUMERICO W_CEP_NUMERICO
            {
                get { _w_cep_numerico = new _REDEF_SICP001S_W_CEP_NUMERICO(); _.Move(W_CEP_NUM, _w_cep_numerico); VarBasis.RedefinePassValue(W_CEP_NUM, _w_cep_numerico, W_CEP_NUM); _w_cep_numerico.ValueChanged += () => { _.Move(_w_cep_numerico, W_CEP_NUM); }; return _w_cep_numerico; }
                set { VarBasis.RedefinePassValue(value, _w_cep_numerico, W_CEP_NUM); }
            }  //Redefines
            public class _REDEF_SICP001S_W_CEP_NUMERICO : VarBasis
            {
                /*"     10 W-CEP-NUMERICO-PARTE1        PIC 9(05).*/
                public IntBasis W_CEP_NUMERICO_PARTE1 { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
                /*"     10 W-CEP-NUMERICO-PARTE2        PIC 9(03).*/
                public IntBasis W_CEP_NUMERICO_PARTE2 { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
                /*"  05 W-CEP-ALFA.*/

                public _REDEF_SICP001S_W_CEP_NUMERICO()
                {
                    W_CEP_NUMERICO_PARTE1.ValueChanged += OnValueChanged;
                    W_CEP_NUMERICO_PARTE2.ValueChanged += OnValueChanged;
                }

            }
            public SICP001S_W_CEP_ALFA W_CEP_ALFA { get; set; } = new SICP001S_W_CEP_ALFA();
            public class SICP001S_W_CEP_ALFA : VarBasis
            {
                /*"     10 W-CEP-ALFA-PARTE1            PIC 9(05).*/
                public IntBasis W_CEP_ALFA_PARTE1 { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
                /*"     10 FILLER                       PIC X(01)  VALUE '-' .*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"     10 W-CEP-ALFA-PARTE2            PIC 9(03).*/
                public IntBasis W_CEP_ALFA_PARTE2 { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
                /*"  05 W-CONTA-CORRENTE-DEBITO.*/
            }
            public SICP001S_W_CONTA_CORRENTE_DEBITO W_CONTA_CORRENTE_DEBITO { get; set; } = new SICP001S_W_CONTA_CORRENTE_DEBITO();
            public class SICP001S_W_CONTA_CORRENTE_DEBITO : VarBasis
            {
                /*"     10 W-OPERACAO-CONTA-DEBITO  PIC 9(04) VALUE ZEROS.*/
                public IntBasis W_OPERACAO_CONTA_DEBITO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"     10 W-CONTA-CONTA-DEBITO     PIC 9(12) VALUE ZEROS.*/
                public IntBasis W_CONTA_CONTA_DEBITO { get; set; } = new IntBasis(new PIC("9", "12", "9(12)"));
                /*"  05 W-DV-CORRENTE-DEBITO-NUM    PIC 9(05).*/
            }
            public IntBasis W_DV_CORRENTE_DEBITO_NUM { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
            /*"  05 W-DV-CORRENTE-DEBITO-ALFA                         REDEFINES  W-DV-CORRENTE-DEBITO-NUM.*/
            private _REDEF_SICP001S_W_DV_CORRENTE_DEBITO_ALFA _w_dv_corrente_debito_alfa { get; set; }
            public _REDEF_SICP001S_W_DV_CORRENTE_DEBITO_ALFA W_DV_CORRENTE_DEBITO_ALFA
            {
                get { _w_dv_corrente_debito_alfa = new _REDEF_SICP001S_W_DV_CORRENTE_DEBITO_ALFA(); _.Move(W_DV_CORRENTE_DEBITO_NUM, _w_dv_corrente_debito_alfa); VarBasis.RedefinePassValue(W_DV_CORRENTE_DEBITO_NUM, _w_dv_corrente_debito_alfa, W_DV_CORRENTE_DEBITO_NUM); _w_dv_corrente_debito_alfa.ValueChanged += () => { _.Move(_w_dv_corrente_debito_alfa, W_DV_CORRENTE_DEBITO_NUM); }; return _w_dv_corrente_debito_alfa; }
                set { VarBasis.RedefinePassValue(value, _w_dv_corrente_debito_alfa, W_DV_CORRENTE_DEBITO_NUM); }
            }  //Redefines
            public class _REDEF_SICP001S_W_DV_CORRENTE_DEBITO_ALFA : VarBasis
            {
                /*"     10 FILLER                   PIC X(04).*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)."), @"");
                /*"     10 W-DV-CONTA-CONTA-DEBITO  PIC X(01).*/
                public StringBasis W_DV_CONTA_CONTA_DEBITO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"01          WABEND.*/

                public _REDEF_SICP001S_W_DV_CORRENTE_DEBITO_ALFA()
                {
                    FILLER_18.ValueChanged += OnValueChanged;
                    W_DV_CONTA_CONTA_DEBITO.ValueChanged += OnValueChanged;
                }

            }
        }
        public SICP001S_WABEND WABEND { get; set; } = new SICP001S_WABEND();
        public class SICP001S_WABEND : VarBasis
        {
            /*"  05        FILLER              PIC  X(010)     VALUE           ' SICP001S'.*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SICP001S");
            /*"  05        FILLER              PIC  X(026)     VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"  05        WNR-EXEC-SQL        PIC  X(004)     VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"  05        FILLER              PIC  X(013)     VALUE           ' *** SQLCODE '.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"  05        WSQLCODE            PIC  ZZZZZ999-  VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            /*"01  REG-LK-BANCOS.*/
        }
        public SICP001S_REG_LK_BANCOS REG_LK_BANCOS { get; set; } = new SICP001S_REG_LK_BANCOS();
        public class SICP001S_REG_LK_BANCOS : VarBasis
        {
            /*"    05 LK-BANCO-COD-BANCO            PIC  9(03).*/
            public IntBasis LK_BANCO_COD_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
            /*"    05 LK-BANCO-DV-BANCO             PIC  X(01).*/
            public StringBasis LK_BANCO_DV_BANCO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 LK-BANCO-NOME                 PIC  X(60).*/
            public StringBasis LK_BANCO_NOME { get; set; } = new StringBasis(new PIC("X", "60", "X(60)."), @"");
            /*"    05 LK-BANCO-COD-RETORNO          PIC  X(01).*/
            public StringBasis LK_BANCO_COD_RETORNO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 LK-BANCO-MENSAGEM-RETORNO     PIC  X(80).*/
            public StringBasis LK_BANCO_MENSAGEM_RETORNO { get; set; } = new StringBasis(new PIC("X", "80", "X(80)."), @"");
            /*"01          PARAMETROS-GE.*/
        }
        public SICP001S_PARAMETROS_GE PARAMETROS_GE { get; set; } = new SICP001S_PARAMETROS_GE();
        public class SICP001S_PARAMETROS_GE : VarBasis
        {
            /*"  05        LKGE-RAMO-EMISSOR   PIC  9(004)      VALUE ZEROS.*/
            public IntBasis LKGE_RAMO_EMISSOR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05        LKGE-MODALIDADE     PIC  9(004)      VALUE ZEROS.*/
            public IntBasis LKGE_MODALIDADE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05        LKGE-PRODUTO        PIC  9(004)      VALUE ZEROS.*/
            public IntBasis LKGE_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05        LKGE-INIVIGENCIA    PIC  X(010)      VALUE ZEROS.*/
            public StringBasis LKGE_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05        LKGE-GRUPO-SUSEP    PIC  9(004)      VALUE ZEROS.*/
            public IntBasis LKGE_GRUPO_SUSEP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05        LKGE-RAMO-SUSEP     PIC  9(004)      VALUE ZEROS.*/
            public IntBasis LKGE_RAMO_SUSEP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05        LKGE-SQLCODE        PIC  ---9.*/
            public IntBasis LKGE_SQLCODE { get; set; } = new IntBasis(new PIC("9", "4", "---9."));
            /*"  05        LKGE-MENSAGEM       PIC  X(070)      VALUE SPACES.*/
            public StringBasis LKGE_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
            /*"01  W-TIPO-E-CPF-CNPJ.*/
        }
        public SICP001S_W_TIPO_E_CPF_CNPJ W_TIPO_E_CPF_CNPJ { get; set; } = new SICP001S_W_TIPO_E_CPF_CNPJ();
        public class SICP001S_W_TIPO_E_CPF_CNPJ : VarBasis
        {
            /*"    05 W-SE-EH-PF-PJ                 PIC  X(02).*/
            public StringBasis W_SE_EH_PF_PJ { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
            /*"    05 W-CPF-CNPJ-MUTUARIO           PIC  9(14).*/
            public IntBasis W_CPF_CNPJ_MUTUARIO { get; set; } = new IntBasis(new PIC("9", "14", "9(14)."));
            /*"    05 FILLER                        PIC  X(64).*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "64", "X(64)."), @"");
            /*"01  SICPW001.*/
        }
        public SICP001S_SICPW001 SICPW001 { get; set; } = new SICP001S_SICPW001();
        public class SICP001S_SICPW001 : VarBasis
        {
            /*"    05 LK-SICPW001-NUM-APOLICE            PIC S9(13) COMP-3.*/
            public IntBasis LK_SICPW001_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
            /*"    05 LK-SICPW001-NUM-ENDOSSO            PIC S9(09) COMP-5.*/
            public IntBasis LK_SICPW001_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"    05 LK-SICPW001-NUM-PARCELA            PIC S9(04) COMP-5.*/
            public IntBasis LK_SICPW001_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 LK-SICPW001-COD-CONVENIO           PIC S9(09) COMP-5.*/
            public IntBasis LK_SICPW001_COD_CONVENIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"    05 LK-SICPW001-NSAS                   PIC S9(04) COMP-5.*/
            public IntBasis LK_SICPW001_NSAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 LK-SICPW001-SITUACAO-COBRANCA      PIC  X(01).*/
            public StringBasis LK_SICPW001_SITUACAO_COBRANCA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 LK-SICPW001-COD-BANCO              PIC S9(04) COMP-5.*/
            public IntBasis LK_SICPW001_COD_BANCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 LK-SICPW001-COD-AGENCIA            PIC  9(05).*/
            public IntBasis LK_SICPW001_COD_AGENCIA { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
            /*"    05 LK-SICPW001-DV-AGENCIA             PIC  X(01).*/
            public StringBasis LK_SICPW001_DV_AGENCIA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 LK-SICPW001-OPERACAO-CONTA         PIC  9(04).*/
            public IntBasis LK_SICPW001_OPERACAO_CONTA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"    05 LK-SICPW001-NUM-CONTA              PIC  9(12).*/
            public IntBasis LK_SICPW001_NUM_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(12)."));
            /*"    05 LK-SICPW001-DV-CONTA               PIC  X(01).*/
            public StringBasis LK_SICPW001_DV_CONTA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 LK-SICPW001-COD-PROGRAMA           PIC  X(08).*/
            public StringBasis LK_SICPW001_COD_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
            /*"    05 LK-SICPW001-FAVORECIDO.*/
            public SICP001S_LK_SICPW001_FAVORECIDO LK_SICPW001_FAVORECIDO { get; set; } = new SICP001S_LK_SICPW001_FAVORECIDO();
            public class SICP001S_LK_SICPW001_FAVORECIDO : VarBasis
            {
                /*"       10 LK-SICPW001-NOME-FAVORECIDO     PIC  X(30).*/
                public StringBasis LK_SICPW001_NOME_FAVORECIDO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
                /*"       10 LK-SICPW001-NUM-DOC-EMPRESA     PIC  9(06).*/
                public IntBasis LK_SICPW001_NUM_DOC_EMPRESA { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
                /*"       10 LK-SICPW001-FILLER1             PIC  X(04).*/
                public StringBasis LK_SICPW001_FILLER1 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)."), @"");
                /*"    05 LK-SICPW001-DES-LOGRADOURO         PIC  X(30).*/
            }
            public StringBasis LK_SICPW001_DES_LOGRADOURO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
            /*"    05 LK-SICPW001-NUM-LOCAL              PIC  9(05).*/
            public IntBasis LK_SICPW001_NUM_LOCAL { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
            /*"    05 LK-SICPW001-DES-COMPLEMENTO        PIC  X(15).*/
            public StringBasis LK_SICPW001_DES_COMPLEMENTO { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
            /*"    05 LK-SICPW001-DES-BAIRRO             PIC  X(15).*/
            public StringBasis LK_SICPW001_DES_BAIRRO { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
            /*"    05 LK-SICPW001-DES-CIDADE             PIC  X(20).*/
            public StringBasis LK_SICPW001_DES_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
            /*"    05 LK-SICPW001-NUM-CEP                PIC  9(05).*/
            public IntBasis LK_SICPW001_NUM_CEP { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
            /*"    05 LK-SICPW001-DES-COMPL-CEP          PIC  X(03).*/
            public StringBasis LK_SICPW001_DES_COMPL_CEP { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
            /*"    05 LK-SICPW001-DES-SIGLA-UF           PIC  X(02).*/
            public StringBasis LK_SICPW001_DES_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
            /*"    05 LK-SICPW001-CHR-USO-EMPRESA.*/
            public SICP001S_LK_SICPW001_CHR_USO_EMPRESA LK_SICPW001_CHR_USO_EMPRESA { get; set; } = new SICP001S_LK_SICPW001_CHR_USO_EMPRESA();
            public class SICP001S_LK_SICPW001_CHR_USO_EMPRESA : VarBasis
            {
                /*"       10 LKCPW001-EMP-SICOV-TXT1         PIC  X(40).*/
                public StringBasis LKCPW001_EMP_SICOV_TXT1 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"       10 FILLER                          PIC  X(01).*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10 LKCPW001-EMP-SICOV-25           PIC  X(25).*/
                public StringBasis LKCPW001_EMP_SICOV_25 { get; set; } = new StringBasis(new PIC("X", "25", "X(25)."), @"");
                /*"       10 FILLER                          PIC  X(01).*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10 LKCPW001-EMP-SICOV-TXT2         PIC  X(40).*/
                public StringBasis LKCPW001_EMP_SICOV_TXT2 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"       10 FILLER                          PIC  X(01).*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10 LKCPW001-EMP-SICOV-60           PIC  X(60).*/
                public StringBasis LKCPW001_EMP_SICOV_60 { get; set; } = new StringBasis(new PIC("X", "60", "X(60)."), @"");
                /*"       10 FILLER                          PIC  X(32).*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "32", "X(32)."), @"");
                /*"    05 LK-SICPW001-COD-DOC-SIACC          PIC  X(15).*/
            }
            public StringBasis LK_SICPW001_COD_DOC_SIACC { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
            /*"    05 LK-SICPW001-USO-SIACC              PIC  X(40).*/
            public StringBasis LK_SICPW001_USO_SIACC { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"    05 LK-SICPW001-COD-RETORNO            PIC  X(01).*/
            public StringBasis LK_SICPW001_COD_RETORNO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 LK-SICPW001-MENSAGEM-RETORNO       PIC  X(80).*/
            public StringBasis LK_SICPW001_MENSAGEM_RETORNO { get; set; } = new StringBasis(new PIC("X", "80", "X(80)."), @"");
        }


        public Copies.RSGEWDTA RSGEWDTA { get; set; } = new Copies.RSGEWDTA();
        public Copies.RSGEWERR RSGEWERR { get; set; } = new Copies.RSGEWERR();
        public Copies.SICPW002 SICPW002 { get; set; } = new Copies.SICPW002();
        public Copies.RSGEWCNT RSGEWCNT { get; set; } = new Copies.RSGEWCNT();
        public Dclgens.SIPROJUD SIPROJUD { get; set; } = new Dclgens.SIPROJUD();
        public Dclgens.SI042 SI042 { get; set; } = new Dclgens.SI042();
        public Dclgens.LOTERI01 LOTERI01 { get; set; } = new Dclgens.LOTERI01();
        public Dclgens.CEPFXFIL CEPFXFIL { get; set; } = new Dclgens.CEPFXFIL();
        public Dclgens.SIPADOFI SIPADOFI { get; set; } = new Dclgens.SIPADOFI();
        public Dclgens.FIPADOFI FIPADOFI { get; set; } = new Dclgens.FIPADOFI();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.SINILT01 SINILT01 { get; set; } = new Dclgens.SINILT01();
        public Dclgens.SISINCHE SISINCHE { get; set; } = new Dclgens.SISINCHE();
        public Dclgens.PRODUTO PRODUTO { get; set; } = new Dclgens.PRODUTO();
        public Dclgens.CHEQUEMI CHEQUEMI { get; set; } = new Dclgens.CHEQUEMI();
        public Dclgens.FORNECED FORNECED { get; set; } = new Dclgens.FORNECED();
        public Dclgens.FIPADOLA FIPADOLA { get; set; } = new Dclgens.FIPADOLA();
        public Dclgens.FIPADOIM FIPADOIM { get; set; } = new Dclgens.FIPADOIM();
        public Dclgens.GETPLADO GETPLADO { get; set; } = new Dclgens.GETPLADO();
        public Dclgens.GETIPIMP GETIPIMP { get; set; } = new Dclgens.GETIPIMP();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.GEOPERAC GEOPERAC { get; set; } = new Dclgens.GEOPERAC();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.MOVDEBCE MOVDEBCE { get; set; } = new Dclgens.MOVDEBCE();
        public Dclgens.GE369 GE369 { get; set; } = new Dclgens.GE369();
        public Dclgens.CALENDAR CALENDAR { get; set; } = new Dclgens.CALENDAR();
        public Dclgens.OD001 OD001 { get; set; } = new Dclgens.OD001();
        public Dclgens.OD002 OD002 { get; set; } = new Dclgens.OD002();
        public Dclgens.OD003 OD003 { get; set; } = new Dclgens.OD003();
        public Dclgens.OD004 OD004 { get; set; } = new Dclgens.OD004();
        public Dclgens.OD005 OD005 { get; set; } = new Dclgens.OD005();
        public Dclgens.OD007 OD007 { get; set; } = new Dclgens.OD007();
        public Dclgens.GE366 GE366 { get; set; } = new Dclgens.GE366();
        public Dclgens.SI175 SI175 { get; set; } = new Dclgens.SI175();
        public Dclgens.GE368 GE368 { get; set; } = new Dclgens.GE368();
        public Dclgens.SINISCAP SINISCAP { get; set; } = new Dclgens.SINISCAP();
        public Dclgens.SINISLAN SINISLAN { get; set; } = new Dclgens.SINISLAN();
        public Dclgens.GE612 GE612 { get; set; } = new Dclgens.GE612();
        public Dclgens.SI237 SI237 { get; set; } = new Dclgens.SI237();
        public Dclgens.GE420 GE420 { get; set; } = new Dclgens.GE420();
        public Dclgens.GE419 GE419 { get; set; } = new Dclgens.GE419();
        public Dclgens.SI239 SI239 { get; set; } = new Dclgens.SI239();
        public SICP001S_LE_MOVDEBCE LE_MOVDEBCE { get; set; } = new SICP001S_LE_MOVDEBCE();
        public SICP001S_IMPOSTOS IMPOSTOS { get; set; } = new SICP001S_IMPOSTOS();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(SICP001S_SICPW001 SICP001S_SICPW001_P) //PROCEDURE DIVISION USING 
        /*SICPW001*/
        {
            try
            {
                this.SICPW001 = SICP001S_SICPW001_P;

                /*" -743- DISPLAY 'PROCEDURE DIVISION' */
                _.Display($"PROCEDURE DIVISION");

                /*" -744- DISPLAY ' => SICP001S- INICIO SUB-ROTINA - GRAVA MOVTO MCP' */
                _.Display($" => SICP001S- INICIO SUB-ROTINA - GRAVA MOVTO MCP");

                /*" -745- DISPLAY 'DADOS RECEBIDOS' */
                _.Display($"DADOS RECEBIDOS");

                /*" -746- DISPLAY ' APO ' LK-SICPW001-NUM-APOLICE */
                _.Display($" APO {SICPW001.LK_SICPW001_NUM_APOLICE}");

                /*" -747- DISPLAY ' END ' LK-SICPW001-NUM-ENDOSSO */
                _.Display($" END {SICPW001.LK_SICPW001_NUM_ENDOSSO}");

                /*" -748- DISPLAY ' PAR ' LK-SICPW001-NUM-PARCELA */
                _.Display($" PAR {SICPW001.LK_SICPW001_NUM_PARCELA}");

                /*" -749- DISPLAY ' CONV ' LK-SICPW001-COD-CONVENIO */
                _.Display($" CONV {SICPW001.LK_SICPW001_COD_CONVENIO}");

                /*" -750- DISPLAY ' NSAS ' LK-SICPW001-NSAS */
                _.Display($" NSAS {SICPW001.LK_SICPW001_NSAS}");

                /*" -751- DISPLAY ' SIT COB ' LK-SICPW001-SITUACAO-COBRANCA */
                _.Display($" SIT COB {SICPW001.LK_SICPW001_SITUACAO_COBRANCA}");

                /*" -752- DISPLAY ' BCO ' LK-SICPW001-COD-BANCO */
                _.Display($" BCO {SICPW001.LK_SICPW001_COD_BANCO}");

                /*" -753- DISPLAY ' AGE ' LK-SICPW001-COD-AGENCIA */
                _.Display($" AGE {SICPW001.LK_SICPW001_COD_AGENCIA}");

                /*" -754- DISPLAY ' DVA ' LK-SICPW001-DV-AGENCIA */
                _.Display($" DVA {SICPW001.LK_SICPW001_DV_AGENCIA}");

                /*" -755- DISPLAY ' OP CNT ' LK-SICPW001-OPERACAO-CONTA */
                _.Display($" OP CNT {SICPW001.LK_SICPW001_OPERACAO_CONTA}");

                /*" -756- DISPLAY ' NUM CNT ' LK-SICPW001-NUM-CONTA. */
                _.Display($" NUM CNT {SICPW001.LK_SICPW001_NUM_CONTA}");

                /*" -757- DISPLAY ' DVC ' LK-SICPW001-DV-CONTA */
                _.Display($" DVC {SICPW001.LK_SICPW001_DV_CONTA}");

                /*" -758- DISPLAY ' PGM ' LK-SICPW001-COD-PROGRAMA */
                _.Display($" PGM {SICPW001.LK_SICPW001_COD_PROGRAMA}");

                /*" -759- DISPLAY ' FAV1 ' LK-SICPW001-FAVORECIDO */
                _.Display($" FAV1 {SICPW001.LK_SICPW001_FAVORECIDO}");

                /*" -760- DISPLAY ' FAV2 ' LK-SICPW001-NOME-FAVORECIDO */
                _.Display($" FAV2 {SICPW001.LK_SICPW001_FAVORECIDO.LK_SICPW001_NOME_FAVORECIDO}");

                /*" -761- DISPLAY ' FAV3 ' LK-SICPW001-NUM-DOC-EMPRESA */
                _.Display($" FAV3 {SICPW001.LK_SICPW001_FAVORECIDO.LK_SICPW001_NUM_DOC_EMPRESA}");

                /*" -762- DISPLAY ' LOG ' LK-SICPW001-DES-LOGRADOURO */
                _.Display($" LOG {SICPW001.LK_SICPW001_DES_LOGRADOURO}");

                /*" -763- DISPLAY ' NUM ' LK-SICPW001-NUM-LOCAL */
                _.Display($" NUM {SICPW001.LK_SICPW001_NUM_LOCAL}");

                /*" -764- DISPLAY ' COPL ' LK-SICPW001-DES-COMPLEMENTO */
                _.Display($" COPL {SICPW001.LK_SICPW001_DES_COMPLEMENTO}");

                /*" -765- DISPLAY ' BRO ' LK-SICPW001-DES-BAIRRO */
                _.Display($" BRO {SICPW001.LK_SICPW001_DES_BAIRRO}");

                /*" -766- DISPLAY ' CID ' LK-SICPW001-DES-CIDADE */
                _.Display($" CID {SICPW001.LK_SICPW001_DES_CIDADE}");

                /*" -767- DISPLAY ' CEP1 ' LK-SICPW001-NUM-CEP */
                _.Display($" CEP1 {SICPW001.LK_SICPW001_NUM_CEP}");

                /*" -768- DISPLAY ' CEP2 ' LK-SICPW001-DES-COMPL-CEP */
                _.Display($" CEP2 {SICPW001.LK_SICPW001_DES_COMPL_CEP}");

                /*" -769- DISPLAY ' UF ' LK-SICPW001-DES-SIGLA-UF. */
                _.Display($" UF {SICPW001.LK_SICPW001_DES_SIGLA_UF}");

                /*" -771- DISPLAY ' USO-EMPRESA :' LK-SICPW001-CHR-USO-EMPRESA. */
                _.Display($" USO-EMPRESA :{SICPW001.LK_SICPW001_CHR_USO_EMPRESA}");

                /*" -773- INSPECT LK-SICPW001-SITUACAO-COBRANCA CONVERTING LOW-VALUES TO ' ' . */
                SICPW001.LK_SICPW001_SITUACAO_COBRANCA.Value = SICPW001.LK_SICPW001_SITUACAO_COBRANCA.Value.Replace("\0", " ");

                /*" -775- INSPECT LK-SICPW001-DV-AGENCIA CONVERTING LOW-VALUES TO ' ' . */
                SICPW001.LK_SICPW001_DV_AGENCIA.Value = SICPW001.LK_SICPW001_DV_AGENCIA.Value.Replace("\0", " ");

                /*" -777- INSPECT LK-SICPW001-DV-CONTA CONVERTING LOW-VALUES TO ' ' . */
                SICPW001.LK_SICPW001_DV_CONTA.Value = SICPW001.LK_SICPW001_DV_CONTA.Value.Replace("\0", " ");

                /*" -779- INSPECT LK-SICPW001-COD-PROGRAMA CONVERTING LOW-VALUES TO ' ' . */
                SICPW001.LK_SICPW001_COD_PROGRAMA.Value = SICPW001.LK_SICPW001_COD_PROGRAMA.Value.Replace("\0", " ");

                /*" -781- INSPECT LK-SICPW001-NOME-FAVORECIDO CONVERTING LOW-VALUES TO ' ' . */
                SICPW001.LK_SICPW001_FAVORECIDO.LK_SICPW001_NOME_FAVORECIDO.Value = SICPW001.LK_SICPW001_FAVORECIDO.LK_SICPW001_NOME_FAVORECIDO.Value.Replace("\0", " ");

                /*" -783- INSPECT LK-SICPW001-FILLER1 CONVERTING LOW-VALUES TO ' ' . */
                SICPW001.LK_SICPW001_FAVORECIDO.LK_SICPW001_FILLER1.Value = SICPW001.LK_SICPW001_FAVORECIDO.LK_SICPW001_FILLER1.Value.Replace("\0", " ");

                /*" -785- INSPECT LK-SICPW001-DES-LOGRADOURO CONVERTING LOW-VALUES TO ' ' . */
                SICPW001.LK_SICPW001_DES_LOGRADOURO.Value = SICPW001.LK_SICPW001_DES_LOGRADOURO.Value.Replace("\0", " ");

                /*" -787- INSPECT LK-SICPW001-DES-COMPLEMENTO CONVERTING LOW-VALUES TO ' ' . */
                SICPW001.LK_SICPW001_DES_COMPLEMENTO.Value = SICPW001.LK_SICPW001_DES_COMPLEMENTO.Value.Replace("\0", " ");

                /*" -789- INSPECT LK-SICPW001-DES-BAIRRO CONVERTING LOW-VALUES TO ' ' . */
                SICPW001.LK_SICPW001_DES_BAIRRO.Value = SICPW001.LK_SICPW001_DES_BAIRRO.Value.Replace("\0", " ");

                /*" -791- INSPECT LK-SICPW001-DES-CIDADE CONVERTING LOW-VALUES TO ' ' . */
                SICPW001.LK_SICPW001_DES_CIDADE.Value = SICPW001.LK_SICPW001_DES_CIDADE.Value.Replace("\0", " ");

                /*" -793- INSPECT LK-SICPW001-DES-COMPL-CEP CONVERTING LOW-VALUES TO ' ' . */
                SICPW001.LK_SICPW001_DES_COMPL_CEP.Value = SICPW001.LK_SICPW001_DES_COMPL_CEP.Value.Replace("\0", " ");

                /*" -796- INSPECT LK-SICPW001-DES-SIGLA-UF CONVERTING LOW-VALUES TO ' ' . */
                SICPW001.LK_SICPW001_DES_SIGLA_UF.Value = SICPW001.LK_SICPW001_DES_SIGLA_UF.Value.Replace("\0", " ");

                /*" -797- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -799- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -801- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -805- MOVE SPACES TO LK-ERRO-DB2 */
                _.Move("", RSGEWERR.LK_ERRO_DB2);

                /*" -807- INITIALIZE LK-RSGEWCNT-IND-ERRO LK-RSGEWCNT-MENSAGEM-RETORNO LK-RSGEWCNT-NOME-TABELA LK-RSGEWCNT-SQLCODE LK-RSGEWCNT-SQLERRMC. */
                _.Initialize(
                    RSGEWCNT.LK_RSGEWCNT_IND_ERRO
                    , RSGEWCNT.LK_RSGEWCNT_MENSAGEM_RETORNO
                    , RSGEWCNT.LK_RSGEWCNT_NOME_TABELA
                    , RSGEWCNT.LK_RSGEWCNT_SQLCODE
                    , RSGEWCNT.LK_RSGEWCNT_SQLERRMC
                );

                /*" -807- MOVE FUNCTION CURRENT-DATE TO WS-CURRENT-DATE */
                _.Move(_.CurrentDate(), RSGEWDTA.RSS_WORK_DATAS.WS_CURRENT_DATE);

                /*" -807- MOVE FUNCTION WHEN-COMPILED TO WS-WHEN-COMPILED */
                _.Move(_.WhenCompiled(), RSGEWDTA.RSS_WORK_DATAS.WS_WHEN_COMPILED);

                /*" -807- STRING WS-WHEN-ANO '-' WS-WHEN-MES '-' WS-WHEN-DIA ' ' WS-WHEN-HORA ':' WS-WHEN-MIN ':' WS-WHEN-SEG ',' WS-WHEN-DECSEG DELIMITED BY SIZE INTO WS-COMPILED-EDIT */
                #region STRING
                var spl1 = RSGEWDTA.RSS_WORK_DATAS.FILLER.WS_WHEN_ANO.GetMoveValues();
                spl1 += "-";
                var spl2 = RSGEWDTA.RSS_WORK_DATAS.FILLER.WS_WHEN_MES.GetMoveValues();
                spl2 += "-";
                var spl3 = RSGEWDTA.RSS_WORK_DATAS.FILLER.WS_WHEN_DIA.GetMoveValues();
                spl3 += " ";
                var spl4 = RSGEWDTA.RSS_WORK_DATAS.FILLER.WS_WHEN_HORA.GetMoveValues();
                spl4 += ":";
                var spl5 = RSGEWDTA.RSS_WORK_DATAS.FILLER.WS_WHEN_MIN.GetMoveValues();
                spl5 += ":";
                var spl6 = RSGEWDTA.RSS_WORK_DATAS.FILLER.WS_WHEN_SEG.GetMoveValues();
                spl6 += ",";
                var spl7 = RSGEWDTA.RSS_WORK_DATAS.FILLER.WS_WHEN_DECSEG.GetMoveValues();
                var results8 = spl1 + spl2 + spl3 + spl4 + spl5 + spl6 + spl7;
                _.Move(results8, RSGEWDTA.RSS_WORK_DATAS.WS_COMPILED_EDIT);
                #endregion

                /*" -809- STRING WS-CDTE-ANO '-' WS-CDTE-MES '-' WS-CDTE-DIA ' ' WS-CDTE-HORA ':' WS-CDTE-MIN ':' WS-CDTE-SEG ',' WS-CDTE-DECSEG DELIMITED BY SIZE INTO WS-CURRENT-EDIT */
                #region STRING
                var spl8 = RSGEWDTA.RSS_WORK_DATAS.FILLER_0.WS_CDTE_ANO.GetMoveValues();
                spl8 += "-";
                var spl9 = RSGEWDTA.RSS_WORK_DATAS.FILLER_0.WS_CDTE_MES.GetMoveValues();
                spl9 += "-";
                var spl10 = RSGEWDTA.RSS_WORK_DATAS.FILLER_0.WS_CDTE_DIA.GetMoveValues();
                spl10 += " ";
                var spl11 = RSGEWDTA.RSS_WORK_DATAS.FILLER_0.WS_CDTE_HORA.GetMoveValues();
                spl11 += ":";
                var spl12 = RSGEWDTA.RSS_WORK_DATAS.FILLER_0.WS_CDTE_MIN.GetMoveValues();
                spl12 += ":";
                var spl13 = RSGEWDTA.RSS_WORK_DATAS.FILLER_0.WS_CDTE_SEG.GetMoveValues();
                spl13 += ",";
                var spl14 = RSGEWDTA.RSS_WORK_DATAS.FILLER_0.WS_CDTE_DECSEG.GetMoveValues();
                var results15 = spl8 + spl9 + spl10 + spl11 + spl12 + spl13 + spl14;
                _.Move(results15, RSGEWDTA.RSS_WORK_DATAS.WS_CURRENT_EDIT);
                #endregion

                /*" -810- IF WS-PRIMEIRA-VEZ = 'SIM' */

                if (AREA_DE_WORK.WS_PRIMEIRA_VEZ == "SIM")
                {

                    /*" -811- MOVE 'NAO' TO WS-PRIMEIRA-VEZ */
                    _.Move("NAO", AREA_DE_WORK.WS_PRIMEIRA_VEZ);

                    /*" -812- DISPLAY '---------------------------------------------' */
                    _.Display($"---------------------------------------------");

                    /*" -814- DISPLAY 'SICP001S -  V.12 COMPILADO EM: ' WS-COMPILED-EDIT(1:19) */
                    _.Display($"SICP001S -  V.12 COMPILADO EM: {RSGEWDTA.RSS_WORK_DATAS.WS_COMPILED_EDIT.Substring(1, 19)}");

                    /*" -821- DISPLAY '   INICIO DO PROCESSAMENTO EM: ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

                    $"   INICIO DO PROCESSAMENTO EM: {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
                    .Display();

                    /*" -822- DISPLAY '---------------------------------------------' */
                    _.Display($"---------------------------------------------");

                    /*" -824- END-IF. */
                }


                /*" -826- MOVE '0' TO LK-SICPW001-COD-RETORNO */
                _.Move("0", SICPW001.LK_SICPW001_COD_RETORNO);

                /*" -828- IF (LK-SICPW001-COD-PROGRAMA NOT EQUAL 'FI0096B' ) AND (LK-SICPW001-COD-PROGRAMA NOT EQUAL 'SI5071B' ) */

                if ((SICPW001.LK_SICPW001_COD_PROGRAMA != "FI0096B") && (SICPW001.LK_SICPW001_COD_PROGRAMA != "SI5071B"))
                {

                    /*" -829- MOVE SPACES TO LK-SICPW001-MENSAGEM-RETORNO */
                    _.Move("", SICPW001.LK_SICPW001_MENSAGEM_RETORNO);

                    /*" -831- END-IF. */
                }


                /*" -833- PERFORM R0010-SELECT-SISTEMAS THRU R0010-EXIT. */

                R0010_SELECT_SISTEMAS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_EXIT*/


                /*" -839- IF (LK-SICPW001-COD-PROGRAMA NOT EQUAL 'SI5071B' ) AND (LK-SICPW001-COD-PROGRAMA NOT EQUAL 'SI5067B' ) AND (LK-SICPW001-COD-PROGRAMA NOT EQUAL 'CB1061B' ) AND (LK-SICPW001-COD-PROGRAMA NOT EQUAL 'SI5001B' ) AND (LK-SICPW001-COD-PROGRAMA NOT EQUAL 'SI5002B' ) AND (LK-SICPW001-COD-PROGRAMA NOT EQUAL 'SIC5002B' ) */

                if ((SICPW001.LK_SICPW001_COD_PROGRAMA != "SI5071B") && (SICPW001.LK_SICPW001_COD_PROGRAMA != "SI5067B") && (SICPW001.LK_SICPW001_COD_PROGRAMA != "CB1061B") && (SICPW001.LK_SICPW001_COD_PROGRAMA != "SI5001B") && (SICPW001.LK_SICPW001_COD_PROGRAMA != "SI5002B") && (SICPW001.LK_SICPW001_COD_PROGRAMA != "SIC5002B"))
                {

                    /*" -840- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -841- DISPLAY '**********************************************' */
                    _.Display($"**********************************************");

                    /*" -842- DISPLAY '*' */
                    _.Display($"*");

                    /*" -843- DISPLAY '* ATENCAO: ROTINA DE SEGURANCA DE GERACAO' */
                    _.Display($"* ATENCAO: ROTINA DE SEGURANCA DE GERACAO");

                    /*" -844- DISPLAY '* DO ARQUIVO A PARA O MCP' */
                    _.Display($"* DO ARQUIVO A PARA O MCP");

                    /*" -845- DISPLAY '*' */
                    _.Display($"*");

                    /*" -846- DISPLAY '* PROGRAMA CHAMADOR NAO PREVISTO NA SUB-ROTINA' */
                    _.Display($"* PROGRAMA CHAMADOR NAO PREVISTO NA SUB-ROTINA");

                    /*" -847- DISPLAY '*' */
                    _.Display($"*");

                    /*" -848- DISPLAY '* PROGRAMA: ' LK-SICPW001-COD-PROGRAMA */
                    _.Display($"* PROGRAMA: {SICPW001.LK_SICPW001_COD_PROGRAMA}");

                    /*" -849- DISPLAY '*' */
                    _.Display($"*");

                    /*" -850- DISPLAY '**********************************************' */
                    _.Display($"**********************************************");

                    /*" -851- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO(); //GOTO
                    return Result;

                    /*" -853- END-IF. */
                }


                /*" -854- DISPLAY '-----------------------------------' */
                _.Display($"-----------------------------------");

                /*" -855- DISPLAY '--- CALL PELO PROGRAMA ' LK-SICPW001-COD-PROGRAMA */
                _.Display($"--- CALL PELO PROGRAMA {SICPW001.LK_SICPW001_COD_PROGRAMA}");

                /*" -857- DISPLAY '-----------------------------------' */
                _.Display($"-----------------------------------");

                /*" -863- IF (LK-SICPW001-COD-CONVENIO NOT EQUAL 600128) AND (LK-SICPW001-COD-CONVENIO NOT EQUAL 600119) AND (LK-SICPW001-COD-CONVENIO NOT EQUAL 600120) AND (LK-SICPW001-COD-CONVENIO NOT EQUAL 600123) AND (LK-SICPW001-COD-CONVENIO NOT EQUAL 921286) AND (LK-SICPW001-COD-CONVENIO NOT EQUAL 43350) */

                if ((SICPW001.LK_SICPW001_COD_CONVENIO != 600128) && (SICPW001.LK_SICPW001_COD_CONVENIO != 600119) && (SICPW001.LK_SICPW001_COD_CONVENIO != 600120) && (SICPW001.LK_SICPW001_COD_CONVENIO != 600123) && (SICPW001.LK_SICPW001_COD_CONVENIO != 921286) && (SICPW001.LK_SICPW001_COD_CONVENIO != 43350))
                {

                    /*" -864- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -865- DISPLAY '**********************************************' */
                    _.Display($"**********************************************");

                    /*" -866- DISPLAY '*' */
                    _.Display($"*");

                    /*" -867- DISPLAY '* ATENCAO: ROTINA DE SEGURANCAO DE GERACAO' */
                    _.Display($"* ATENCAO: ROTINA DE SEGURANCAO DE GERACAO");

                    /*" -868- DISPLAY '* DO ARQUIVO A PARA O MCP' */
                    _.Display($"* DO ARQUIVO A PARA O MCP");

                    /*" -869- DISPLAY '*' */
                    _.Display($"*");

                    /*" -870- DISPLAY '* CONVENIO NAO PREVISTO NA SUB-ROTINA' */
                    _.Display($"* CONVENIO NAO PREVISTO NA SUB-ROTINA");

                    /*" -871- DISPLAY '*' */
                    _.Display($"*");

                    /*" -872- DISPLAY '* CONVENIO: ' LK-SICPW001-COD-CONVENIO */
                    _.Display($"* CONVENIO: {SICPW001.LK_SICPW001_COD_CONVENIO}");

                    /*" -873- DISPLAY '*' */
                    _.Display($"*");

                    /*" -874- DISPLAY '**********************************************' */
                    _.Display($"**********************************************");

                    /*" -875- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO(); //GOTO
                    return Result;

                    /*" -877- END-IF. */
                }


                /*" -879- PERFORM R0020-VALIDA-MOVDEBCE THRU R0020-EXIT. */

                R0020_VALIDA_MOVDEBCE(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_EXIT*/


                /*" -881- MOVE 'NAO' TO WFIM-LE-MOVDEBCE-1. */
                _.Move("NAO", AREA_DE_WORK.WFIM_LE_MOVDEBCE_1);

                /*" -882- PERFORM R0100-DECLARE-MOVDEBCE THRU R0100-EXIT. */

                R0100_DECLARE_MOVDEBCE(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_EXIT*/


                /*" -884- PERFORM R0101-FETCH-MOVDEBCE THRU R0101-EXIT. */

                R0101_FETCH_MOVDEBCE(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0101_EXIT*/


                /*" -885- PERFORM R0200-PROCESSA-PRINCIPAL THRU R0200-EXIT UNTIL WFIM-LE-MOVDEBCE-1 = 'SIM' . */

                while (!(AREA_DE_WORK.WFIM_LE_MOVDEBCE_1 == "SIM"))
                {

                    R0200_PROCESSA_PRINCIPAL(true);

                    R0200_MONTA_REGISTRO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_EXIT*/

                }

                /*" -885- FLUXCONTROL_PERFORM R0000-90-FINALIZA */

                R0000_90_FINALIZA();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { SICPW001, CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -890- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -891- MOVE '0' TO LK-SICPW001-COD-RETORNO */
            _.Move("0", SICPW001.LK_SICPW001_COD_RETORNO);

            /*" -893- MOVE 'EXECUCAO COM SUCESSO' TO LK-SICPW001-MENSAGEM-RETORNO */
            _.Move("EXECUCAO COM SUCESSO", SICPW001.LK_SICPW001_MENSAGEM_RETORNO);

            /*" -893- GO TO RXXXX-ROTINA-RETORNO. */

            RXXXX_ROTINA_RETORNO(); //GOTO
            return;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_SAIDA*/

        [StopWatch]
        /*" R0010-SELECT-SISTEMAS */
        private void R0010_SELECT_SISTEMAS(bool isPerform = false)
        {
            /*" -903- DISPLAY 'R0010-SELECT-SISTEMAS' */
            _.Display($"R0010-SELECT-SISTEMAS");

            /*" -915- PERFORM R0010_SELECT_SISTEMAS_DB_SELECT_1 */

            R0010_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -918- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -919- DISPLAY 'SICP001S- ERRO NO ACESSO SISTEMAS - FI' */
                _.Display($"SICP001S- ERRO NO ACESSO SISTEMAS - FI");

                /*" -921- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -929- PERFORM R0010_SELECT_SISTEMAS_DB_SELECT_2 */

            R0010_SELECT_SISTEMAS_DB_SELECT_2();

            /*" -932- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -933- DISPLAY 'SICP001S- ERRO NO ACESSO SISTEMAS - SI' */
                _.Display($"SICP001S- ERRO NO ACESSO SISTEMAS - SI");

                /*" -935- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -936- MOVE HOST-CURRENT-DATE(1:4) TO W-LOTE-DATE-AAAA. */
            _.Move(HOST_CURRENT_DATE.Substring(1, 4), AREA_DE_WORK.W_LOTE.W_LOTE_DATE_AAAA);

            /*" -937- MOVE HOST-CURRENT-DATE(6:2) TO W-LOTE-DATE-MM. */
            _.Move(HOST_CURRENT_DATE.Substring(6, 2), AREA_DE_WORK.W_LOTE.W_LOTE_DATE_MM);

            /*" -938- MOVE HOST-CURRENT-DATE(9:2) TO W-LOTE-DATE-DD. */
            _.Move(HOST_CURRENT_DATE.Substring(9, 2), AREA_DE_WORK.W_LOTE.W_LOTE_DATE_DD);

            /*" -939- MOVE HOST-CURRENT-TIME(1:2) TO W-LOTE-TIME-HH. */
            _.Move(HOST_CURRENT_TIME.Substring(1, 2), AREA_DE_WORK.W_LOTE.W_LOTE_TIME_HH);

            /*" -940- MOVE HOST-CURRENT-TIME(4:2) TO W-LOTE-TIME-MM. */
            _.Move(HOST_CURRENT_TIME.Substring(4, 2), AREA_DE_WORK.W_LOTE.W_LOTE_TIME_MM);

            /*" -940- MOVE HOST-CURRENT-TIME(7:2) TO W-LOTE-TIME-SS. */
            _.Move(HOST_CURRENT_TIME.Substring(7, 2), AREA_DE_WORK.W_LOTE.W_LOTE_TIME_SS);

        }

        [StopWatch]
        /*" R0010-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0010_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -915- EXEC SQL SELECT DATA_MOV_ABERTO, DATULT_PROCESSAMEN, CURRENT DATE, CURRENT TIME INTO :SISTEMAS-DATA-MOV-ABERTO, :SISTEMAS-DATULT-PROCESSAMEN, :HOST-CURRENT-DATE, :HOST-CURRENT-TIME FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'FI' WITH UR END-EXEC. */

            var r0010_SELECT_SISTEMAS_DB_SELECT_1_Query1 = new R0010_SELECT_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0010_SELECT_SISTEMAS_DB_SELECT_1_Query1.Execute(r0010_SELECT_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.SISTEMAS_DATULT_PROCESSAMEN, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATULT_PROCESSAMEN);
                _.Move(executed_1.HOST_CURRENT_DATE, HOST_CURRENT_DATE);
                _.Move(executed_1.HOST_CURRENT_TIME, HOST_CURRENT_TIME);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_EXIT*/

        [StopWatch]
        /*" R0010-SELECT-SISTEMAS-DB-SELECT-2 */
        public void R0010_SELECT_SISTEMAS_DB_SELECT_2()
        {
            /*" -929- EXEC SQL SELECT DATA_MOV_ABERTO, CURRENT DATE INTO :HOST-SI-DATA-MOV-ABERTO, :HOST-SI-CURRENT-DATE FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' WITH UR END-EXEC. */

            var r0010_SELECT_SISTEMAS_DB_SELECT_2_Query1 = new R0010_SELECT_SISTEMAS_DB_SELECT_2_Query1()
            {
            };

            var executed_1 = R0010_SELECT_SISTEMAS_DB_SELECT_2_Query1.Execute(r0010_SELECT_SISTEMAS_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_SI_DATA_MOV_ABERTO, HOST_SI_DATA_MOV_ABERTO);
                _.Move(executed_1.HOST_SI_CURRENT_DATE, HOST_SI_CURRENT_DATE);
            }


        }

        [StopWatch]
        /*" R0020-VALIDA-MOVDEBCE */
        private void R0020_VALIDA_MOVDEBCE(bool isPerform = false)
        {
            /*" -955- DISPLAY 'R0020-VALIDA-MOVDEBCE' */
            _.Display($"R0020-VALIDA-MOVDEBCE");

            /*" -957- MOVE 0 TO HOST-COUNT. */
            _.Move(0, HOST_COUNT);

            /*" -968- PERFORM R0020_VALIDA_MOVDEBCE_DB_SELECT_1 */

            R0020_VALIDA_MOVDEBCE_DB_SELECT_1();

            /*" -971- IF SQLCODE EQUAL 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -972- IF HOST-COUNT EQUAL 0 */

                if (HOST_COUNT == 0)
                {

                    /*" -973- DISPLAY 'SICP001S- REGISTRO NAO ACHADO NA MOVDEBCE' */
                    _.Display($"SICP001S- REGISTRO NAO ACHADO NA MOVDEBCE");

                    /*" -975- DISPLAY 'LK-SICPW001-NUM-APOLICE ........ ' LK-SICPW001-NUM-APOLICE */
                    _.Display($"LK-SICPW001-NUM-APOLICE ........ {SICPW001.LK_SICPW001_NUM_APOLICE}");

                    /*" -977- DISPLAY 'LK-SICPW001-NUM-ENDOSSO ........ ' LK-SICPW001-NUM-ENDOSSO */
                    _.Display($"LK-SICPW001-NUM-ENDOSSO ........ {SICPW001.LK_SICPW001_NUM_ENDOSSO}");

                    /*" -979- DISPLAY 'LK-SICPW001-NUM-PARCELA ........ ' LK-SICPW001-NUM-PARCELA */
                    _.Display($"LK-SICPW001-NUM-PARCELA ........ {SICPW001.LK_SICPW001_NUM_PARCELA}");

                    /*" -981- DISPLAY 'LK-SICPW001-NSAS ............... ' LK-SICPW001-NSAS */
                    _.Display($"LK-SICPW001-NSAS ............... {SICPW001.LK_SICPW001_NSAS}");

                    /*" -983- DISPLAY 'LK-SICPW001-COD-CONVENIO ....... ' LK-SICPW001-COD-CONVENIO */
                    _.Display($"LK-SICPW001-COD-CONVENIO ....... {SICPW001.LK_SICPW001_COD_CONVENIO}");

                    /*" -985- DISPLAY 'LK-SICPW001-SITUACAO-COBRANCA .. ' LK-SICPW001-SITUACAO-COBRANCA */
                    _.Display($"LK-SICPW001-SITUACAO-COBRANCA .. {SICPW001.LK_SICPW001_SITUACAO_COBRANCA}");

                    /*" -986- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -987- MOVE '1' TO LK-SICPW001-COD-RETORNO */
                    _.Move("1", SICPW001.LK_SICPW001_COD_RETORNO);

                    /*" -989- MOVE 'NAO FOI ENCONTRADO REG. NA MOVTO_DEBITOCC_CEF' TO LK-SICPW001-MENSAGEM-RETORNO */
                    _.Move("NAO FOI ENCONTRADO REG. NA MOVTO_DEBITOCC_CEF", SICPW001.LK_SICPW001_MENSAGEM_RETORNO);

                    /*" -990- GO TO RXXXX-ROTINA-RETORNO */

                    RXXXX_ROTINA_RETORNO(); //GOTO
                    return;

                    /*" -991- END-IF */
                }


                /*" -993- END-IF. */
            }


            /*" -994- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -995- DISPLAY 'SICP001S- ERRO ACESSO MOVDEBCE - VALIDACAO' */
                _.Display($"SICP001S- ERRO ACESSO MOVDEBCE - VALIDACAO");

                /*" -996- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -996- END-IF. */
            }


        }

        [StopWatch]
        /*" R0020-VALIDA-MOVDEBCE-DB-SELECT-1 */
        public void R0020_VALIDA_MOVDEBCE_DB_SELECT_1()
        {
            /*" -968- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :HOST-COUNT FROM SEGUROS.MOVTO_DEBITOCC_CEF MO WHERE MO.NUM_APOLICE = :LK-SICPW001-NUM-APOLICE AND MO.NUM_ENDOSSO = :LK-SICPW001-NUM-ENDOSSO AND MO.NUM_PARCELA = :LK-SICPW001-NUM-PARCELA AND MO.NSAS = :LK-SICPW001-NSAS AND MO.SITUACAO_COBRANCA = :LK-SICPW001-SITUACAO-COBRANCA AND MO.COD_CONVENIO = :LK-SICPW001-COD-CONVENIO END-EXEC. */

            var r0020_VALIDA_MOVDEBCE_DB_SELECT_1_Query1 = new R0020_VALIDA_MOVDEBCE_DB_SELECT_1_Query1()
            {
                LK_SICPW001_SITUACAO_COBRANCA = SICPW001.LK_SICPW001_SITUACAO_COBRANCA.ToString(),
                LK_SICPW001_COD_CONVENIO = SICPW001.LK_SICPW001_COD_CONVENIO.ToString(),
                LK_SICPW001_NUM_APOLICE = SICPW001.LK_SICPW001_NUM_APOLICE.ToString(),
                LK_SICPW001_NUM_ENDOSSO = SICPW001.LK_SICPW001_NUM_ENDOSSO.ToString(),
                LK_SICPW001_NUM_PARCELA = SICPW001.LK_SICPW001_NUM_PARCELA.ToString(),
                LK_SICPW001_NSAS = SICPW001.LK_SICPW001_NSAS.ToString(),
            };

            var executed_1 = R0020_VALIDA_MOVDEBCE_DB_SELECT_1_Query1.Execute(r0020_VALIDA_MOVDEBCE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_COUNT, HOST_COUNT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_EXIT*/

        [StopWatch]
        /*" R0100-DECLARE-MOVDEBCE */
        private void R0100_DECLARE_MOVDEBCE(bool isPerform = false)
        {
            /*" -1004- DISPLAY 'R0100-DECLARE-MOVDEBCE' */
            _.Display($"R0100-DECLARE-MOVDEBCE");

            /*" -1006- MOVE 0 TO W-AC-LIDOS-MOVDEBCE */
            _.Move(0, AREA_DE_WORK.W_AC_LIDOS_MOVDEBCE);

            /*" -1400- PERFORM R0100_DECLARE_MOVDEBCE_DB_DECLARE_1 */

            R0100_DECLARE_MOVDEBCE_DB_DECLARE_1();

            /*" -1402- PERFORM R0100_DECLARE_MOVDEBCE_DB_OPEN_1 */

            R0100_DECLARE_MOVDEBCE_DB_OPEN_1();

            /*" -1405- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1406- DISPLAY 'SICP001S- ERRO CURSOR LE_MOVDEBCE' */
                _.Display($"SICP001S- ERRO CURSOR LE_MOVDEBCE");

                /*" -1406- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0100-DECLARE-MOVDEBCE-DB-DECLARE-1 */
        public void R0100_DECLARE_MOVDEBCE_DB_DECLARE_1()
        {
            /*" -1400- EXEC SQL DECLARE LE_MOVDEBCE CURSOR FOR SELECT 'CRED/DEB 1 - CONV 600128 - SIN, 43350 - RESS.,921286 - BB' , H.TIPO_REGISTRO AS "TIPO SEGURO", CASE H.TIPO_REGISTRO WHEN '0' THEN 'COSSEGURO ACEITO' WHEN '1' THEN 'NOSSA LIDERANCA ' END AS "NOME TIPO SEGURO", H.NUM_APOLICE AS "NUM APOLICE", H.NUM_APOL_SINISTRO AS "NUM SINISTRO", H.OCORR_HISTORICO AS "OCORRHIST", H.COD_OPERACAO AS "OPERACAO", H.NOME_FAVORECIDO AS "NOME FAVORECIDO - HISTSINI", YEAR(H.DATA_MOVIMENTO) AS "ANO OPERACIONAL DO PAGAMENTO", YEAR(SIS.DATA_MOV_ABERTO) AS "ANO CONTABIL DO PAGAMENTO", OPE.FUNCAO_OPERACAO AS "FUNCAO OPERACAO", OPE.IND_TIPO_FUNCAO AS "TIPO FUNCAO", SUBSTR(OPE.DES_OPERACAO,1,30) AS "NOME OPERACAO", ABS(H.VAL_OPERACAO) AS "VALOR BRUTO", MO.VLR_CREDITO AS "MOV. VALOR CREDITO", MO.VALOR_DEBITO AS "MOV. VALOR DEBITO", H.DATA_MOVIMENTO AS "DATA BAIXA PELA TESOURARIA", H.COD_PREST_SERVICO AS "COD DA FORNECEDORES", H.COD_SERVICO AS "COD DO SERVICO", H.SIT_CONTABIL AS "FORMA PAGAMENTO", CASE H.SIT_CONTABIL WHEN '1' THEN 'CHEQUE PAPEL     ' WHEN '2' THEN 'CREDITO EM CONTA ' WHEN '7' THEN 'SIACC            ' END AS "NOME FORMA PAGAMENTO", H.NOM_PROGRAMA AS "PGM GERADOR", H.COD_USUARIO AS "USUARIO QUE BAIXO PAGTO", M.RAMO AS "RAMO CXS", M.COD_FONTE AS "FONTE", H1.DATA_MOVIMENTO AS "DATA AVISO NO SIAS", M.DATA_COMUNICADO AS "DATA COMUNICADO NA CXS", M.COD_PRODUTO AS "PRODUTO", PRO.DESCR_PRODUTO AS "NOME PRODUTO", SC.NUM_CHEQUE_INTERNO AS "CHQINT", MO.NUM_APOLICE AS "MOV. APOLICE", MO.NUM_ENDOSSO AS "MOV. ENDOSSO", MO.NUM_PARCELA AS "MOV. PARCELA", MO.SITUACAO_COBRANCA AS "MOV. SITUACAO COBRANCA", CASE MO.SITUACAO_COBRANCA WHEN ' ' THEN 'PEND. ENVIO 1                     ' WHEN '0' THEN 'PEND. ENVIO 2                     ' WHEN '1' THEN 'PEND. RETORNO                     ' WHEN '2' THEN 'CRD/DEB EFETUADO C/ SUCESSO       ' WHEN '3' THEN 'CRD/DEB NAO EFETUADO              ' WHEN '4' THEN 'CANCELADO A PEDIDO DO GCX AO BANCO' WHEN '6' THEN 'CRD C/ NAO EFETUADO - GERADO CHQ. ' END AS "MOV. NOME SITUACAO COBRANCA", MO.DATA_VENCIMENTO AS "MOV. DATA CREDITO", MO.DATA_MOVIMENTO AS "MOV. DT. GERACAO MOVDEBCC", MO.COD_AGENCIA_DEB AS "MOV. AGENCIA", MO.OPER_CONTA_DEB AS "MOV. OPER CONTA", MO.NUM_CONTA_DEB AS "MOV. NUM. CONTA", MO.DIG_CONTA_DEB AS "MOV. DV CONTA", MO.COD_CONVENIO AS "MOV.CONVENIO", MO.DATA_ENVIO AS "MOV. DT. ENVIO SIAS P/ SAP", MO.NSAS AS "MOV. NSAS", MO.NUM_REQUISICAO AS "MOV. NUM. CHQ. INTERNO", CONTA.COD_AGENCIA AS "CONTA COD AGENCIA", CONTA.COD_BANCO AS "CONTA BANCO", CONTA.NUM_CONTA_CNB AS "CONTA NUM. CONTA", CONTA.NUM_DV_CONTA_CNB AS "CONTA DV CONTA", CONTA.IND_CONTA_BANCARIA AS "CONTA ACHO QUE OPERACAO CONTA", PRO.COD_EMPRESA AS "CODG EMPRESA" FROM SEGUROS.SISTEMAS SIS, SEGUROS.SINISTRO_HISTORICO H, SEGUROS.SINISTRO_MESTRE M, SEGUROS.SINISTRO_HISTORICO H1, SEGUROS.SI_SINI_CHEQUE SC, SEGUROS.GE_OPERACAO OPE, SEGUROS.PRODUTO PRO, SEGUROS.MOVTO_DEBITOCC_CEF MO LEFT JOIN SEGUROS.GE_MOVTO_CONTA CONTA ON CONTA.NUM_APOLICE = MO.NUM_APOLICE AND CONTA.NUM_ENDOSSO = MO.NUM_ENDOSSO AND CONTA.NUM_PARCELA = MO.NUM_PARCELA AND CONTA.COD_CONVENIO = MO.COD_CONVENIO AND CONTA.NSAS = MO.NSAS WHERE ( ( MO.COD_CONVENIO = 600128 ) OR ( MO.COD_CONVENIO = 43350 AND MO.NUM_ENDOSSO = 7777 AND MO.NUM_PARCELA = 7777 ) OR ( MO.COD_CONVENIO = 921286 AND MO.NUM_CARTAO <> 0 AND EXISTS (SELECT 1 FROM SEGUROS.SI_SINI_CHEQUE XX WHERE XX.NUM_APOL_SINISTRO = MO.NUM_APOLICE AND XX.OCORR_HISTORICO = MO.NUM_PARCELA AND XX.COD_OPERACAO = MO.NUM_ENDOSSO) ) ) AND MO.NUM_APOLICE = :LK-SICPW001-NUM-APOLICE AND MO.NUM_ENDOSSO = :LK-SICPW001-NUM-ENDOSSO AND MO.NUM_PARCELA = :LK-SICPW001-NUM-PARCELA AND MO.NSAS = :LK-SICPW001-NSAS AND MO.SITUACAO_COBRANCA = :LK-SICPW001-SITUACAO-COBRANCA AND SC.NUM_CHEQUE_INTERNO = INTEGER(MO.NUM_CARTAO) AND H.NUM_APOL_SINISTRO = SC.NUM_APOL_SINISTRO AND H.OCORR_HISTORICO = SC.OCORR_HISTORICO AND H.COD_OPERACAO = SC.COD_OPERACAO AND H.SIT_REGISTRO = '1' AND H.SIT_CONTABIL IN ( '2' , '7' ) AND OPE.IDE_SISTEMA = 'SI' AND OPE.COD_OPERACAO = H.COD_OPERACAO AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND PRO.COD_PRODUTO = M.COD_PRODUTO AND H1.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND H1.COD_OPERACAO = 101 AND H1.TIMESTAMP = (SELECT MIN(A.TIMESTAMP) FROM SEGUROS.SINISTRO_HISTORICO A WHERE A.NUM_APOL_SINISTRO = H1.NUM_APOL_SINISTRO AND A.OCORR_HISTORICO = H1.OCORR_HISTORICO AND A.COD_OPERACAO = H1.COD_OPERACAO) AND SIS.IDE_SISTEMA = 'FI' UNION ALL SELECT 'CRED/DEB 2 - CONV 600128 - SIN, 43350 - SIACC,921286 - BB' , H.TIPO_REGISTRO AS "TIPO SEGURO", CASE H.TIPO_REGISTRO WHEN '0' THEN 'COSSEGURO ACEITO' WHEN '1' THEN 'NOSSA LIDERANCA ' END AS "NOME TIPO SEGURO", H.NUM_APOLICE AS "NUM APOLICE", H.NUM_APOL_SINISTRO AS "NUM SINISTRO", H.OCORR_HISTORICO AS "OCORRHIST", H.COD_OPERACAO AS "OPERACAO", H.NOME_FAVORECIDO AS "NOME FAVORECIDO - HISTSINI", YEAR(H.DATA_MOVIMENTO) AS "ANO OPERACIONAL DO PAGAMENTO", YEAR(SIS.DATA_MOV_ABERTO) AS "ANO CONTABIL DO PAGAMENTO", OPE.FUNCAO_OPERACAO AS "FUNCAO OPERACAO", OPE.IND_TIPO_FUNCAO AS "TIPO FUNCAO", SUBSTR(OPE.DES_OPERACAO,1,30) AS "NOME OPERACAO", ABS(H.VAL_OPERACAO) AS "VALOR BRUTO", MO.VLR_CREDITO AS "MOV. VALOR CREDITO", MO.VALOR_DEBITO AS "MOV. VALOR DEBITO", H.DATA_MOVIMENTO AS "DATA BAIXA PELA TESOURARIA", H.COD_PREST_SERVICO AS "COD DA FORNECEDORES", H.COD_SERVICO AS "COD DO SERVICO", H.SIT_CONTABIL AS "FORMA PAGAMENTO", CASE H.SIT_CONTABIL WHEN '1' THEN 'CHEQUE PAPEL     ' WHEN '2' THEN 'CREDITO EM CONTA ' WHEN '7' THEN 'SIACC            ' END AS "NOME FORMA PAGAMENTO", H.NOM_PROGRAMA AS "PGM GERADOR", H.COD_USUARIO AS "USUARIO QUE BAIXO PAGTO", M.RAMO AS "RAMO CXS", M.COD_FONTE AS "FONTE", H1.DATA_MOVIMENTO AS "DATA AVISO NO SIAS", M.DATA_COMUNICADO AS "DATA COMUNICADO NA CXS", M.COD_PRODUTO AS "PRODUTO", PRO.DESCR_PRODUTO AS "NOME PRODUTO", SC.NUM_CHEQUE_INTERNO AS "CHQINT", MO.NUM_APOLICE AS "MOV. APOLICE", MO.NUM_ENDOSSO AS "MOV. ENDOSSO", MO.NUM_PARCELA AS "MOV. PARCELA", MO.SITUACAO_COBRANCA AS "MOV. SITUACAO COBRANCA", CASE MO.SITUACAO_COBRANCA WHEN ' ' THEN 'PEND. ENVIO 1                     ' WHEN '0' THEN 'PEND. ENVIO 2                     ' WHEN '1' THEN 'PEND. RETORNO                     ' WHEN '2' THEN 'CRD/DEB EFETUADO C/ SUCESSO       ' WHEN '3' THEN 'CRD/DEB NAO EFETUADO              ' WHEN '4' THEN 'CANCELADO A PEDIDO DO GCX AO BANCO' WHEN '6' THEN 'CRD C/ NAO EFETUADO - GERADO CHQ. ' END AS "MOV. NOME SITUACAO COBRANCA", MO.DATA_VENCIMENTO AS "MOV. DATA CREDITO", MO.DATA_MOVIMENTO AS "MOV. DT. GERACAO MOVDEBCC", MO.COD_AGENCIA_DEB AS "MOV. AGENCIA", MO.OPER_CONTA_DEB AS "MOV. OPER CONTA", MO.NUM_CONTA_DEB AS "MOV. NUM. CONTA", MO.DIG_CONTA_DEB AS "MOV. DV CONTA", MO.COD_CONVENIO AS "MOV.CONVENIO", MO.DATA_ENVIO AS "MOV. DT. ENVIO SIAS P/ SAP", MO.NSAS AS "MOV. NSAS", MO.NUM_REQUISICAO AS "MOV. NUM. CHQ. INTERNO", CONTA.COD_AGENCIA AS "CONTA COD AGENCIA", CONTA.COD_BANCO AS "CONTA BANCO", CONTA.NUM_CONTA_CNB AS "CONTA NUM. CONTA", CONTA.NUM_DV_CONTA_CNB AS "CONTA DV CONTA", CONTA.IND_CONTA_BANCARIA AS "CONTA ACHO QUE OPERACAO CONTA", PRO.COD_EMPRESA AS "CODG EMPRESA" FROM SEGUROS.SISTEMAS SIS, SEGUROS.SINISTRO_HISTORICO H, SEGUROS.SINISTRO_MESTRE M, SEGUROS.SINISTRO_HISTORICO H1, SEGUROS.SI_SINI_CHEQUE SC, SEGUROS.GE_OPERACAO OPE, SEGUROS.PRODUTO PRO, SEGUROS.MOVTO_DEBITOCC_CEF MO LEFT JOIN SEGUROS.GE_MOVTO_CONTA CONTA ON CONTA.NUM_APOLICE = MO.NUM_APOLICE AND CONTA.NUM_ENDOSSO = MO.NUM_ENDOSSO AND CONTA.NUM_PARCELA = MO.NUM_PARCELA AND CONTA.COD_CONVENIO = MO.COD_CONVENIO AND CONTA.NSAS = MO.NSAS WHERE ( MO.COD_CONVENIO = 43350 AND EXISTS (SELECT 1 FROM SEGUROS.SINISTRO_HISTORICO YY WHERE YY.NUM_APOL_SINISTRO = MO.NUM_APOLICE AND YY.OCORR_HISTORICO = MO.NUM_PARCELA AND YY.COD_OPERACAO = MO.NUM_ENDOSSO - YY.COD_PRODUTO * 10000) ) AND MO.NUM_APOLICE = :LK-SICPW001-NUM-APOLICE AND MO.NUM_ENDOSSO = :LK-SICPW001-NUM-ENDOSSO AND MO.NUM_PARCELA = :LK-SICPW001-NUM-PARCELA AND MO.NSAS = :LK-SICPW001-NSAS AND MO.SITUACAO_COBRANCA = :LK-SICPW001-SITUACAO-COBRANCA AND MO.NUM_PARCELA <> 7777 AND MO.NUM_ENDOSSO <> 7777 AND H.NUM_APOL_SINISTRO = MO.NUM_APOLICE AND H.OCORR_HISTORICO = MO.NUM_PARCELA AND H.COD_OPERACAO = MO.NUM_ENDOSSO - H.COD_PRODUTO * 10000 AND H.SIT_REGISTRO = '1' AND H.SIT_CONTABIL IN ( '2' , '7' ) AND SC.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND SC.OCORR_HISTORICO = H.OCORR_HISTORICO AND SC.COD_OPERACAO = H.COD_OPERACAO AND OPE.IDE_SISTEMA = 'SI' AND OPE.COD_OPERACAO = H.COD_OPERACAO AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND PRO.COD_PRODUTO = M.COD_PRODUTO AND H1.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND H1.COD_OPERACAO = 101 AND H1.TIMESTAMP = (SELECT MIN(A.TIMESTAMP) FROM SEGUROS.SINISTRO_HISTORICO A WHERE A.NUM_APOL_SINISTRO = H1.NUM_APOL_SINISTRO AND A.OCORR_HISTORICO = H1.OCORR_HISTORICO AND A.COD_OPERACAO = H1.COD_OPERACAO) AND SIS.IDE_SISTEMA = 'FI' UNION ALL SELECT 'CRED/DEB 3 - 600119, 600120, 600123 - LOTERICO' , H.TIPO_REGISTRO AS "TIPO SEGURO", CASE H.TIPO_REGISTRO WHEN '0' THEN 'COSSEGURO ACEITO' WHEN '1' THEN 'NOSSA LIDERANCA ' END AS "NOME TIPO SEGURO", H.NUM_APOLICE AS "NUM APOLICE", H.NUM_APOL_SINISTRO AS "NUM SINISTRO", H.OCORR_HISTORICO AS "OCORRHIST", H.COD_OPERACAO AS "OPERACAO", H.NOME_FAVORECIDO AS "NOME FAVORECIDO - HISTSINI", YEAR(H.DATA_MOVIMENTO) AS "ANO OPERACIONAL DO PAGAMENTO", YEAR(SIS.DATA_MOV_ABERTO) AS "ANO CONTABIL DO PAGAMENTO", OPE.FUNCAO_OPERACAO AS "FUNCAO OPERACAO", OPE.IND_TIPO_FUNCAO AS "TIPO FUNCAO", SUBSTR(OPE.DES_OPERACAO,1,30) AS "NOME OPERACAO", H.VAL_OPERACAO AS "VALOR BRUTO", MO.VLR_CREDITO AS "MOV. VALOR CREDITO", MO.VALOR_DEBITO AS "MOV. VALOR DEBITO", H.DATA_MOVIMENTO AS "DATA BAIXA PELA TESOURARIA", H.COD_PREST_SERVICO AS "COD DA FORNECEDORES", H.COD_SERVICO AS "COD DO SERVICO", H.SIT_CONTABIL AS "FORMA PAGAMENTO", CASE H.SIT_CONTABIL WHEN '1' THEN 'CHEQUE PAPEL     ' WHEN '2' THEN 'CREDITO EM CONTA ' WHEN '7' THEN 'SIACC            ' END AS "NOME FORMA PAGAMENTO", H.NOM_PROGRAMA AS "PGM GERADOR", H.COD_USUARIO AS "USUARIO QUE BAIXO PAGTO", M.RAMO AS "RAMO CXS", M.COD_FONTE AS "FONTE", H1.DATA_MOVIMENTO AS "DATA AVISO NO SIAS", M.DATA_COMUNICADO AS "DATA COMUNICADO NA CXS", M.COD_PRODUTO AS "PRODUTO", PRO.DESCR_PRODUTO AS "NOME PRODUTO", 0 AS "CHQINT", MO.NUM_APOLICE AS "MOV. APOLICE", MO.NUM_ENDOSSO AS "MOV. ENDOSSO", MO.NUM_PARCELA AS "MOV. PARCELA", MO.SITUACAO_COBRANCA AS "MOV. SITUACAO COBRANCA", CASE MO.SITUACAO_COBRANCA WHEN ' ' THEN 'PEND. ENVIO 1                     ' WHEN '0' THEN 'PEND. ENVIO 2                     ' WHEN '1' THEN 'PEND. RETORNO                     ' WHEN '2' THEN 'CRD/DEB EFETUADO C/ SUCESSO       ' WHEN '3' THEN 'CRD/DEB NAO EFETUADO              ' WHEN '4' THEN 'CANCELADO A PEDIDO DO GCX AO BANCO' WHEN '6' THEN 'CRD C/ NAO EFETUADO - GERADO CHQ. ' END AS "MOV. NOME SITUACAO COBRANCA", MO.DATA_VENCIMENTO AS "MOV. DATA CREDITO", MO.DATA_MOVIMENTO AS "MOV. DT. GERACAO MOVDEBCC", MO.COD_AGENCIA_DEB AS "MOV. AGENCIA", MO.OPER_CONTA_DEB AS "MOV. OPER CONTA", MO.NUM_CONTA_DEB AS "MOV. NUM. CONTA", MO.DIG_CONTA_DEB AS "MOV. DV CONTA", MO.COD_CONVENIO AS "MOV.CONVENIO", MO.DATA_ENVIO AS "MOV. DT. ENVIO SIAS P/ SAP", MO.NSAS AS "MOV. NSAS", MO.NUM_REQUISICAO AS "MOV. NUM. CHQ. INTERNO", CONTA.COD_AGENCIA AS "CONTA COD AGENCIA", CONTA.COD_BANCO AS "CONTA BANCO", CONTA.NUM_CONTA_CNB AS "CONTA NUM. CONTA", CONTA.NUM_DV_CONTA_CNB AS "CONTA DV CONTA", CONTA.IND_CONTA_BANCARIA AS "CONTA ACHO QUE OPERACAO CONTA" , PRO.COD_EMPRESA AS "CODG EMPRESA" FROM SEGUROS.SISTEMAS SIS, SEGUROS.SINISTRO_HISTORICO H, SEGUROS.SINISTRO_MESTRE M, SEGUROS.SINISTRO_HISTORICO H1, SEGUROS.GE_OPERACAO OPE, SEGUROS.PRODUTO PRO, SEGUROS.MOVTO_DEBITOCC_CEF MO LEFT JOIN SEGUROS.GE_MOVTO_CONTA CONTA ON CONTA.NUM_APOLICE = MO.NUM_APOLICE AND CONTA.NUM_ENDOSSO = MO.NUM_ENDOSSO AND CONTA.NUM_PARCELA = MO.NUM_PARCELA AND CONTA.COD_CONVENIO = MO.COD_CONVENIO AND CONTA.NSAS = MO.NSAS WHERE ( MO.COD_CONVENIO IN (600119 , 600120 , 600123) ) AND MO.NUM_APOLICE = :LK-SICPW001-NUM-APOLICE AND MO.NUM_ENDOSSO = :LK-SICPW001-NUM-ENDOSSO AND MO.NUM_PARCELA = :LK-SICPW001-NUM-PARCELA AND MO.NSAS = :LK-SICPW001-NSAS AND MO.SITUACAO_COBRANCA = :LK-SICPW001-SITUACAO-COBRANCA AND H.NUM_APOL_SINISTRO = MO.NUM_APOLICE AND H.OCORR_HISTORICO = MO.NUM_PARCELA AND H.COD_OPERACAO = MO.NUM_ENDOSSO - H.COD_PRODUTO * 10000 AND H.SIT_REGISTRO IN ( '1' , '8' ) AND H.SIT_CONTABIL IN ( '2' , '7' ) AND OPE.IDE_SISTEMA = 'SI' AND OPE.COD_OPERACAO = H.COD_OPERACAO AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND PRO.COD_PRODUTO = M.COD_PRODUTO AND H1.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND H1.COD_OPERACAO = 101 AND H1.TIMESTAMP = (SELECT MIN(A.TIMESTAMP) FROM SEGUROS.SINISTRO_HISTORICO A WHERE A.NUM_APOL_SINISTRO = H1.NUM_APOL_SINISTRO AND A.OCORR_HISTORICO = H1.OCORR_HISTORICO AND A.COD_OPERACAO = H1.COD_OPERACAO) AND SIS.IDE_SISTEMA = 'FI' ORDER BY 5,6,7 WITH UR END-EXEC. */
            LE_MOVDEBCE = new SICP001S_LE_MOVDEBCE(true);
            string GetQuery_LE_MOVDEBCE()
            {
                var query = @$"SELECT 
							'CRED/DEB 1 - CONV 600128 - SIN
							, 43350 - RESS.
							,921286 - BB'
							, 
							H.TIPO_REGISTRO AS TIPOSEGURO
							, 
							CASE H.TIPO_REGISTRO 
							WHEN '0' THEN 'COSSEGURO ACEITO' 
							WHEN '1' THEN 'NOSSA LIDERANCA ' 
							END AS NOMETIPOSEGURO
							, 
							H.NUM_APOLICE AS NUMAPOLICE
							, 
							H.NUM_APOL_SINISTRO AS NUMSINISTRO
							, 
							H.OCORR_HISTORICO AS OCORRHIST
							, 
							H.COD_OPERACAO AS OPERACAO
							, 
							H.NOME_FAVORECIDO AS NOMEFAVORECIDOHISTSINI
							, 
							YEAR(H.DATA_MOVIMENTO) AS ANOOPERACIONALDOPAGAMENTO
							, 
							YEAR(SIS.DATA_MOV_ABERTO) 
							AS ANOCONTABILDOPAGAMENTO
							, 
							OPE.FUNCAO_OPERACAO AS FUNCAOOPERACAO
							, 
							OPE.IND_TIPO_FUNCAO AS TIPOFUNCAO
							, 
							SUBSTR(OPE.DES_OPERACAO
							,1
							,30) 
							AS NOMEOPERACAO
							, 
							ABS(H.VAL_OPERACAO) AS VALORBRUTO
							, 
							MO.VLR_CREDITO AS MOVVALORCREDITO
							, 
							MO.VALOR_DEBITO AS MOVVALORDEBITO
							, 
							H.DATA_MOVIMENTO AS DATABAIXAPELATESOURARIA
							, 
							H.COD_PREST_SERVICO AS CODDAFORNECEDORES
							, 
							H.COD_SERVICO AS CODDOSERVICO
							, 
							H.SIT_CONTABIL AS FORMAPAGAMENTO
							, 
							CASE H.SIT_CONTABIL 
							WHEN '1' THEN 'CHEQUE PAPEL ' 
							WHEN '2' THEN 'CREDITO EM CONTA ' 
							WHEN '7' THEN 'SIACC ' 
							END AS NOMEFORMAPAGAMENTO
							, 
							H.NOM_PROGRAMA AS PGMGERADOR
							, 
							H.COD_USUARIO AS USUARIOQUEBAIXOPAGTO
							, 
							M.RAMO AS RAMOCXS
							, 
							M.COD_FONTE AS FONTE
							, 
							H1.DATA_MOVIMENTO AS DATAAVISONOSIAS
							, 
							M.DATA_COMUNICADO AS DATACOMUNICADONACXS
							, 
							M.COD_PRODUTO AS PRODUTO
							, 
							PRO.DESCR_PRODUTO AS NOMEPRODUTO
							, 
							SC.NUM_CHEQUE_INTERNO AS CHQINT
							, 
							MO.NUM_APOLICE AS MOVAPOLICE
							, 
							MO.NUM_ENDOSSO AS MOVENDOSSO
							, 
							MO.NUM_PARCELA AS MOVPARCELA
							, 
							MO.SITUACAO_COBRANCA AS MOVSITUACAOCOBRANCA
							, 
							CASE MO.SITUACAO_COBRANCA 
							WHEN ' ' THEN 'PEND. ENVIO 1 ' 
							WHEN '0' THEN 'PEND. ENVIO 2 ' 
							WHEN '1' THEN 'PEND. RETORNO ' 
							WHEN '2' THEN 'CRD/DEB EFETUADO C/ SUCESSO ' 
							WHEN '3' THEN 'CRD/DEB NAO EFETUADO ' 
							WHEN '4' THEN 'CANCELADO A PEDIDO DO GCX AO BANCO' 
							WHEN '6' THEN 'CRD C/ NAO EFETUADO - GERADO CHQ. ' 
							END AS MOVNOMESITUACAOCOBRANCA
							, 
							MO.DATA_VENCIMENTO AS MOVDATACREDITO
							, 
							MO.DATA_MOVIMENTO AS MOVDTGERACAOMOVDEBCC
							, 
							MO.COD_AGENCIA_DEB AS MOVAGENCIA
							, 
							MO.OPER_CONTA_DEB AS MOVOPERCONTA
							, 
							MO.NUM_CONTA_DEB AS MOVNUMCONTA
							, 
							MO.DIG_CONTA_DEB AS MOVDVCONTA
							, 
							MO.COD_CONVENIO AS MOVCONVENIO
							, 
							MO.DATA_ENVIO AS MOVDTENVIOSIASPSAP
							, 
							MO.NSAS AS MOVNSAS
							, 
							MO.NUM_REQUISICAO 
							AS MOVNUMCHQINTERNO
							, 
							CONTA.COD_AGENCIA AS CONTACODAGENCIA
							, 
							CONTA.COD_BANCO AS CONTABANCO
							, 
							CONTA.NUM_CONTA_CNB AS CONTANUMCONTA
							, 
							CONTA.NUM_DV_CONTA_CNB AS CONTADVCONTA
							, 
							CONTA.IND_CONTA_BANCARIA 
							AS CONTAACHOQUEOPERACAOCONTA
							, 
							PRO.COD_EMPRESA AS CODGEMPRESA 
							FROM 
							SEGUROS.SISTEMAS SIS
							, 
							SEGUROS.SINISTRO_HISTORICO H
							, 
							SEGUROS.SINISTRO_MESTRE M
							, 
							SEGUROS.SINISTRO_HISTORICO H1
							, 
							SEGUROS.SI_SINI_CHEQUE SC
							, 
							SEGUROS.GE_OPERACAO OPE
							, 
							SEGUROS.PRODUTO PRO
							, 
							SEGUROS.MOVTO_DEBITOCC_CEF MO 
							LEFT
							JOIN SEGUROS.GE_MOVTO_CONTA CONTA 
							ON CONTA.NUM_APOLICE = MO.NUM_APOLICE 
							AND CONTA.NUM_ENDOSSO = MO.NUM_ENDOSSO 
							AND CONTA.NUM_PARCELA = MO.NUM_PARCELA 
							AND CONTA.COD_CONVENIO = MO.COD_CONVENIO 
							AND CONTA.NSAS = MO.NSAS 
							WHERE 
							( ( MO.COD_CONVENIO = 600128 
							) 
							OR 
							( MO.COD_CONVENIO = 43350 
							AND MO.NUM_ENDOSSO = 7777 
							AND MO.NUM_PARCELA = 7777 
							) 
							OR 
							( MO.COD_CONVENIO = 921286 
							AND MO.NUM_CARTAO <> 0 
							AND EXISTS 
							(SELECT 1
							FROM SEGUROS.SI_SINI_CHEQUE XX 
							WHERE XX.NUM_APOL_SINISTRO = MO.NUM_APOLICE 
							AND XX.OCORR_HISTORICO = MO.NUM_PARCELA 
							AND XX.COD_OPERACAO = MO.NUM_ENDOSSO) 
							) 
							) 
							AND MO.NUM_APOLICE = '{SICPW001.LK_SICPW001_NUM_APOLICE}' 
							AND MO.NUM_ENDOSSO = '{SICPW001.LK_SICPW001_NUM_ENDOSSO}' 
							AND MO.NUM_PARCELA = '{SICPW001.LK_SICPW001_NUM_PARCELA}' 
							AND MO.NSAS = '{SICPW001.LK_SICPW001_NSAS}' 
							AND MO.SITUACAO_COBRANCA = '{SICPW001.LK_SICPW001_SITUACAO_COBRANCA}' 
							AND SC.NUM_CHEQUE_INTERNO = INTEGER(MO.NUM_CARTAO) 
							AND H.NUM_APOL_SINISTRO = SC.NUM_APOL_SINISTRO 
							AND H.OCORR_HISTORICO = SC.OCORR_HISTORICO 
							AND H.COD_OPERACAO = SC.COD_OPERACAO 
							AND H.SIT_REGISTRO = '1' 
							AND H.SIT_CONTABIL IN ( '2'
							, '7' ) 
							AND OPE.IDE_SISTEMA = 'SI' 
							AND OPE.COD_OPERACAO = H.COD_OPERACAO 
							AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND PRO.COD_PRODUTO = M.COD_PRODUTO 
							AND H1.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND H1.COD_OPERACAO = 101 
							AND H1.TIMESTAMP = 
							(SELECT MIN(A.TIMESTAMP) 
							FROM SEGUROS.SINISTRO_HISTORICO A 
							WHERE A.NUM_APOL_SINISTRO = H1.NUM_APOL_SINISTRO 
							AND A.OCORR_HISTORICO = H1.OCORR_HISTORICO 
							AND A.COD_OPERACAO = H1.COD_OPERACAO) 
							AND SIS.IDE_SISTEMA = 'FI' 
							UNION ALL 
							SELECT 
							'CRED/DEB 2 - CONV 600128 - SIN
							, 43350 - SIACC
							,921286 - BB'
							, 
							H.TIPO_REGISTRO AS TIPOSEGURO
							, 
							CASE H.TIPO_REGISTRO 
							WHEN '0' THEN 'COSSEGURO ACEITO' 
							WHEN '1' THEN 'NOSSA LIDERANCA ' 
							END AS NOMETIPOSEGURO
							, 
							H.NUM_APOLICE AS NUMAPOLICE
							, 
							H.NUM_APOL_SINISTRO AS NUMSINISTRO
							, 
							H.OCORR_HISTORICO AS OCORRHIST
							, 
							H.COD_OPERACAO AS OPERACAO
							, 
							H.NOME_FAVORECIDO AS NOMEFAVORECIDOHISTSINI
							, 
							YEAR(H.DATA_MOVIMENTO) AS ANOOPERACIONALDOPAGAMENTO
							, 
							YEAR(SIS.DATA_MOV_ABERTO) 
							AS ANOCONTABILDOPAGAMENTO
							, 
							OPE.FUNCAO_OPERACAO AS FUNCAOOPERACAO
							, 
							OPE.IND_TIPO_FUNCAO AS TIPOFUNCAO
							, 
							SUBSTR(OPE.DES_OPERACAO
							,1
							,30) 
							AS NOMEOPERACAO
							, 
							ABS(H.VAL_OPERACAO) AS VALORBRUTO
							, 
							MO.VLR_CREDITO AS MOVVALORCREDITO
							, 
							MO.VALOR_DEBITO AS MOVVALORDEBITO
							, 
							H.DATA_MOVIMENTO AS DATABAIXAPELATESOURARIA
							, 
							H.COD_PREST_SERVICO AS CODDAFORNECEDORES
							, 
							H.COD_SERVICO AS CODDOSERVICO
							, 
							H.SIT_CONTABIL AS FORMAPAGAMENTO
							, 
							CASE H.SIT_CONTABIL 
							WHEN '1' THEN 'CHEQUE PAPEL ' 
							WHEN '2' THEN 'CREDITO EM CONTA ' 
							WHEN '7' THEN 'SIACC ' 
							END AS NOMEFORMAPAGAMENTO
							, 
							H.NOM_PROGRAMA AS PGMGERADOR
							, 
							H.COD_USUARIO AS USUARIOQUEBAIXOPAGTO
							, 
							M.RAMO AS RAMOCXS
							, 
							M.COD_FONTE AS FONTE
							, 
							H1.DATA_MOVIMENTO AS DATAAVISONOSIAS
							, 
							M.DATA_COMUNICADO AS DATACOMUNICADONACXS
							, 
							M.COD_PRODUTO AS PRODUTO
							, 
							PRO.DESCR_PRODUTO AS NOMEPRODUTO
							, 
							SC.NUM_CHEQUE_INTERNO AS CHQINT
							, 
							MO.NUM_APOLICE AS MOVAPOLICE
							, 
							MO.NUM_ENDOSSO AS MOVENDOSSO
							, 
							MO.NUM_PARCELA AS MOVPARCELA
							, 
							MO.SITUACAO_COBRANCA AS MOVSITUACAOCOBRANCA
							, 
							CASE MO.SITUACAO_COBRANCA 
							WHEN ' ' THEN 'PEND. ENVIO 1 ' 
							WHEN '0' THEN 'PEND. ENVIO 2 ' 
							WHEN '1' THEN 'PEND. RETORNO ' 
							WHEN '2' THEN 'CRD/DEB EFETUADO C/ SUCESSO ' 
							WHEN '3' THEN 'CRD/DEB NAO EFETUADO ' 
							WHEN '4' THEN 'CANCELADO A PEDIDO DO GCX AO BANCO' 
							WHEN '6' THEN 'CRD C/ NAO EFETUADO - GERADO CHQ. ' 
							END AS MOVNOMESITUACAOCOBRANCA
							, 
							MO.DATA_VENCIMENTO AS MOVDATACREDITO
							, 
							MO.DATA_MOVIMENTO AS MOVDTGERACAOMOVDEBCC
							, 
							MO.COD_AGENCIA_DEB AS MOVAGENCIA
							, 
							MO.OPER_CONTA_DEB AS MOVOPERCONTA
							, 
							MO.NUM_CONTA_DEB AS MOVNUMCONTA
							, 
							MO.DIG_CONTA_DEB AS MOVDVCONTA
							, 
							MO.COD_CONVENIO AS MOVCONVENIO
							, 
							MO.DATA_ENVIO AS MOVDTENVIOSIASPSAP
							, 
							MO.NSAS AS MOVNSAS
							, 
							MO.NUM_REQUISICAO 
							AS MOVNUMCHQINTERNO
							, 
							CONTA.COD_AGENCIA AS CONTACODAGENCIA
							, 
							CONTA.COD_BANCO AS CONTABANCO
							, 
							CONTA.NUM_CONTA_CNB AS CONTANUMCONTA
							, 
							CONTA.NUM_DV_CONTA_CNB AS CONTADVCONTA
							, 
							CONTA.IND_CONTA_BANCARIA 
							AS CONTAACHOQUEOPERACAOCONTA
							, 
							PRO.COD_EMPRESA AS CODGEMPRESA 
							FROM 
							SEGUROS.SISTEMAS SIS
							, 
							SEGUROS.SINISTRO_HISTORICO H
							, 
							SEGUROS.SINISTRO_MESTRE M
							, 
							SEGUROS.SINISTRO_HISTORICO H1
							, 
							SEGUROS.SI_SINI_CHEQUE SC
							, 
							SEGUROS.GE_OPERACAO OPE
							, 
							SEGUROS.PRODUTO PRO
							, 
							SEGUROS.MOVTO_DEBITOCC_CEF MO 
							LEFT
							JOIN SEGUROS.GE_MOVTO_CONTA CONTA 
							ON CONTA.NUM_APOLICE = MO.NUM_APOLICE 
							AND CONTA.NUM_ENDOSSO = MO.NUM_ENDOSSO 
							AND CONTA.NUM_PARCELA = MO.NUM_PARCELA 
							AND CONTA.COD_CONVENIO = MO.COD_CONVENIO 
							AND CONTA.NSAS = MO.NSAS 
							WHERE 
							( MO.COD_CONVENIO = 43350 
							AND EXISTS 
							(SELECT 1
							FROM SEGUROS.SINISTRO_HISTORICO YY 
							WHERE YY.NUM_APOL_SINISTRO = MO.NUM_APOLICE 
							AND YY.OCORR_HISTORICO = MO.NUM_PARCELA 
							AND YY.COD_OPERACAO = 
							MO.NUM_ENDOSSO - YY.COD_PRODUTO * 10000) 
							) 
							AND MO.NUM_APOLICE = '{SICPW001.LK_SICPW001_NUM_APOLICE}' 
							AND MO.NUM_ENDOSSO = '{SICPW001.LK_SICPW001_NUM_ENDOSSO}' 
							AND MO.NUM_PARCELA = '{SICPW001.LK_SICPW001_NUM_PARCELA}' 
							AND MO.NSAS = '{SICPW001.LK_SICPW001_NSAS}' 
							AND MO.SITUACAO_COBRANCA = '{SICPW001.LK_SICPW001_SITUACAO_COBRANCA}' 
							AND MO.NUM_PARCELA <> 7777 
							AND MO.NUM_ENDOSSO <> 7777 
							AND H.NUM_APOL_SINISTRO = MO.NUM_APOLICE 
							AND H.OCORR_HISTORICO = MO.NUM_PARCELA 
							AND H.COD_OPERACAO = 
							MO.NUM_ENDOSSO - H.COD_PRODUTO * 10000 
							AND H.SIT_REGISTRO = '1' 
							AND H.SIT_CONTABIL IN ( '2'
							, '7' ) 
							AND SC.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND SC.OCORR_HISTORICO = H.OCORR_HISTORICO 
							AND SC.COD_OPERACAO = H.COD_OPERACAO 
							AND OPE.IDE_SISTEMA = 'SI' 
							AND OPE.COD_OPERACAO = H.COD_OPERACAO 
							AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND PRO.COD_PRODUTO = M.COD_PRODUTO 
							AND H1.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND H1.COD_OPERACAO = 101 
							AND H1.TIMESTAMP = 
							(SELECT MIN(A.TIMESTAMP) 
							FROM SEGUROS.SINISTRO_HISTORICO A 
							WHERE A.NUM_APOL_SINISTRO = H1.NUM_APOL_SINISTRO 
							AND A.OCORR_HISTORICO = H1.OCORR_HISTORICO 
							AND A.COD_OPERACAO = H1.COD_OPERACAO) 
							AND SIS.IDE_SISTEMA = 'FI' 
							UNION ALL 
							SELECT 
							'CRED/DEB 3 - 600119
							, 600120
							, 600123 - LOTERICO'
							, 
							H.TIPO_REGISTRO AS TIPOSEGURO
							, 
							CASE H.TIPO_REGISTRO 
							WHEN '0' THEN 'COSSEGURO ACEITO' 
							WHEN '1' THEN 'NOSSA LIDERANCA ' 
							END AS NOMETIPOSEGURO
							, 
							H.NUM_APOLICE AS NUMAPOLICE
							, 
							H.NUM_APOL_SINISTRO AS NUMSINISTRO
							, 
							H.OCORR_HISTORICO AS OCORRHIST
							, 
							H.COD_OPERACAO AS OPERACAO
							, 
							H.NOME_FAVORECIDO AS NOMEFAVORECIDOHISTSINI
							, 
							YEAR(H.DATA_MOVIMENTO) AS ANOOPERACIONALDOPAGAMENTO
							, 
							YEAR(SIS.DATA_MOV_ABERTO) 
							AS ANOCONTABILDOPAGAMENTO
							, 
							OPE.FUNCAO_OPERACAO AS FUNCAOOPERACAO
							, 
							OPE.IND_TIPO_FUNCAO AS TIPOFUNCAO
							, 
							SUBSTR(OPE.DES_OPERACAO
							,1
							,30) 
							AS NOMEOPERACAO
							, 
							H.VAL_OPERACAO AS VALORBRUTO
							, 
							MO.VLR_CREDITO AS MOVVALORCREDITO
							, 
							MO.VALOR_DEBITO AS MOVVALORDEBITO
							, 
							H.DATA_MOVIMENTO AS DATABAIXAPELATESOURARIA
							, 
							H.COD_PREST_SERVICO AS CODDAFORNECEDORES
							, 
							H.COD_SERVICO AS CODDOSERVICO
							, 
							H.SIT_CONTABIL AS FORMAPAGAMENTO
							, 
							CASE H.SIT_CONTABIL 
							WHEN '1' THEN 'CHEQUE PAPEL ' 
							WHEN '2' THEN 'CREDITO EM CONTA ' 
							WHEN '7' THEN 'SIACC ' 
							END AS NOMEFORMAPAGAMENTO
							, 
							H.NOM_PROGRAMA AS PGMGERADOR
							, 
							H.COD_USUARIO AS USUARIOQUEBAIXOPAGTO
							, 
							M.RAMO AS RAMOCXS
							, 
							M.COD_FONTE AS FONTE
							, 
							H1.DATA_MOVIMENTO AS DATAAVISONOSIAS
							, 
							M.DATA_COMUNICADO AS DATACOMUNICADONACXS
							, 
							M.COD_PRODUTO AS PRODUTO
							, 
							PRO.DESCR_PRODUTO AS NOMEPRODUTO
							, 
							0 AS CHQINT
							, 
							MO.NUM_APOLICE AS MOVAPOLICE
							, 
							MO.NUM_ENDOSSO AS MOVENDOSSO
							, 
							MO.NUM_PARCELA AS MOVPARCELA
							, 
							MO.SITUACAO_COBRANCA AS MOVSITUACAOCOBRANCA
							, 
							CASE MO.SITUACAO_COBRANCA 
							WHEN ' ' THEN 'PEND. ENVIO 1 ' 
							WHEN '0' THEN 'PEND. ENVIO 2 ' 
							WHEN '1' THEN 'PEND. RETORNO ' 
							WHEN '2' THEN 'CRD/DEB EFETUADO C/ SUCESSO ' 
							WHEN '3' THEN 'CRD/DEB NAO EFETUADO ' 
							WHEN '4' THEN 'CANCELADO A PEDIDO DO GCX AO BANCO' 
							WHEN '6' THEN 'CRD C/ NAO EFETUADO - GERADO CHQ. ' 
							END AS MOVNOMESITUACAOCOBRANCA
							, 
							MO.DATA_VENCIMENTO AS MOVDATACREDITO
							, 
							MO.DATA_MOVIMENTO AS MOVDTGERACAOMOVDEBCC
							, 
							MO.COD_AGENCIA_DEB AS MOVAGENCIA
							, 
							MO.OPER_CONTA_DEB AS MOVOPERCONTA
							, 
							MO.NUM_CONTA_DEB AS MOVNUMCONTA
							, 
							MO.DIG_CONTA_DEB AS MOVDVCONTA
							, 
							MO.COD_CONVENIO AS MOVCONVENIO
							, 
							MO.DATA_ENVIO AS MOVDTENVIOSIASPSAP
							, 
							MO.NSAS AS MOVNSAS
							, 
							MO.NUM_REQUISICAO 
							AS MOVNUMCHQINTERNO
							, 
							CONTA.COD_AGENCIA AS CONTACODAGENCIA
							, 
							CONTA.COD_BANCO AS CONTABANCO
							, 
							CONTA.NUM_CONTA_CNB AS CONTANUMCONTA
							, 
							CONTA.NUM_DV_CONTA_CNB AS CONTADVCONTA
							, 
							CONTA.IND_CONTA_BANCARIA 
							AS CONTAACHOQUEOPERACAOCONTA
							, 
							PRO.COD_EMPRESA AS CODGEMPRESA 
							FROM 
							SEGUROS.SISTEMAS SIS
							, 
							SEGUROS.SINISTRO_HISTORICO H
							, 
							SEGUROS.SINISTRO_MESTRE M
							, 
							SEGUROS.SINISTRO_HISTORICO H1
							, 
							SEGUROS.GE_OPERACAO OPE
							, 
							SEGUROS.PRODUTO PRO
							, 
							SEGUROS.MOVTO_DEBITOCC_CEF MO 
							LEFT
							JOIN SEGUROS.GE_MOVTO_CONTA CONTA 
							ON CONTA.NUM_APOLICE = MO.NUM_APOLICE 
							AND CONTA.NUM_ENDOSSO = MO.NUM_ENDOSSO 
							AND CONTA.NUM_PARCELA = MO.NUM_PARCELA 
							AND CONTA.COD_CONVENIO = MO.COD_CONVENIO 
							AND CONTA.NSAS = MO.NSAS 
							WHERE 
							( 
							MO.COD_CONVENIO IN (600119
							, 600120
							, 600123) 
							) 
							AND MO.NUM_APOLICE = '{SICPW001.LK_SICPW001_NUM_APOLICE}' 
							AND MO.NUM_ENDOSSO = '{SICPW001.LK_SICPW001_NUM_ENDOSSO}' 
							AND MO.NUM_PARCELA = '{SICPW001.LK_SICPW001_NUM_PARCELA}' 
							AND MO.NSAS = '{SICPW001.LK_SICPW001_NSAS}' 
							AND MO.SITUACAO_COBRANCA = '{SICPW001.LK_SICPW001_SITUACAO_COBRANCA}' 
							AND H.NUM_APOL_SINISTRO = MO.NUM_APOLICE 
							AND H.OCORR_HISTORICO = MO.NUM_PARCELA 
							AND H.COD_OPERACAO = 
							MO.NUM_ENDOSSO - H.COD_PRODUTO * 10000 
							AND H.SIT_REGISTRO IN ( '1'
							, '8' ) 
							AND H.SIT_CONTABIL IN ( '2'
							, '7' ) 
							AND OPE.IDE_SISTEMA = 'SI' 
							AND OPE.COD_OPERACAO = H.COD_OPERACAO 
							AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND PRO.COD_PRODUTO = M.COD_PRODUTO 
							AND H1.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND H1.COD_OPERACAO = 101 
							AND H1.TIMESTAMP = 
							(SELECT MIN(A.TIMESTAMP) 
							FROM SEGUROS.SINISTRO_HISTORICO A 
							WHERE A.NUM_APOL_SINISTRO = H1.NUM_APOL_SINISTRO 
							AND A.OCORR_HISTORICO = H1.OCORR_HISTORICO 
							AND A.COD_OPERACAO = H1.COD_OPERACAO) 
							AND SIS.IDE_SISTEMA = 'FI' 
							ORDER BY 5
							,6
							,7";

                return query;
            }
            LE_MOVDEBCE.GetQueryEvent += GetQuery_LE_MOVDEBCE;

        }

        [StopWatch]
        /*" R0100-DECLARE-MOVDEBCE-DB-OPEN-1 */
        public void R0100_DECLARE_MOVDEBCE_DB_OPEN_1()
        {
            /*" -1402- EXEC SQL OPEN LE_MOVDEBCE END-EXEC. */

            LE_MOVDEBCE.Open();

        }

        [StopWatch]
        /*" R4000-DECLARE-IMPOSTOS-DB-DECLARE-1 */
        public void R4000_DECLARE_IMPOSTOS_DB_DECLARE_1()
        {
            /*" -2783- EXEC SQL DECLARE IMPOSTOS CURSOR FOR SELECT H.NUM_APOL_SINISTRO, H.OCORR_HISTORICO, H.COD_OPERACAO, A.NUM_DOCF_INTERNO, C.COD_TP_LANCDOCF AS "COD LANC DA NOTA FISCAL", Y.ABREV_LANCDOCF AS "NOME LANC DA NOTA FISCAL", C.VALOR_LANCAMENTO AS "VALOR LANC NOTA FISCAL", NOM_IMP.COD_IMP_INTERNO AS "COD IMPOSTO", NOM_IMP.SIGLA_IMP AS "NOME IMPOSTO", IMP.ALIQ_TRIBUTACAO AS "ALIQUOTA IMPOSTO", IMP.VALOR_IMPOSTO AS "VALOR IMPOSTO", IMP.COD_IMPOSTO_SAP FROM SEGUROS.SINISTRO_HISTORICO H , SEGUROS.SI_PAGA_DOC_FISCAL A , SEGUROS.FI_PAGA_DOC_FISCAL F , SEGUROS.FI_PAGA_DOCF_LANC C , SEGUROS.GE_TP_LANC_DOCF Y , SEGUROS.FI_PAGA_DOCF_IMP IMP , SEGUROS.GE_TIPO_IMPOSTO NOM_IMP WHERE A.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND A.OCORR_HISTORICO = H.OCORR_HISTORICO AND A.COD_OPERACAO = H.COD_OPERACAO AND C.NUM_DOCF_INTERNO = A.NUM_DOCF_INTERNO AND C.VALOR_LANCAMENTO <> 0 AND Y.COD_TP_LANCDOCF = C.COD_TP_LANCDOCF AND Y.DT_INIVIG_LANCDOCF = C.DT_INIVIG_LANCDOCF AND IMP.NUM_DOCF_INTERNO = C.NUM_DOCF_INTERNO AND IMP.COD_TP_LANCDOCF = C.COD_TP_LANCDOCF AND IMP.DT_INIVIG_LANCDOCF = C.DT_INIVIG_LANCDOCF AND NOM_IMP.COD_IMP_INTERNO = IMP.COD_IMP_INTERNO AND NOM_IMP.DATA_INIVIG_IMP = IMP.DATA_INIVIG_IMP AND H.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND H.OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND F.NUM_DOCF_INTERNO = A.NUM_DOCF_INTERNO AND IMP.VALOR_IMPOSTO <> 0 END-EXEC. */
            IMPOSTOS = new SICP001S_IMPOSTOS(true);
            string GetQuery_IMPOSTOS()
            {
                var query = @$"SELECT 
							H.NUM_APOL_SINISTRO
							, 
							H.OCORR_HISTORICO
							, 
							H.COD_OPERACAO
							, 
							A.NUM_DOCF_INTERNO
							, 
							C.COD_TP_LANCDOCF AS CODLANCDANOTAFISCAL
							, 
							Y.ABREV_LANCDOCF AS NOMELANCDANOTAFISCAL
							, 
							C.VALOR_LANCAMENTO AS VALORLANCNOTAFISCAL
							, 
							NOM_IMP.COD_IMP_INTERNO AS CODIMPOSTO
							, 
							NOM_IMP.SIGLA_IMP AS NOMEIMPOSTO
							, 
							IMP.ALIQ_TRIBUTACAO AS ALIQUOTAIMPOSTO
							, 
							IMP.VALOR_IMPOSTO AS VALORIMPOSTO
							, 
							IMP.COD_IMPOSTO_SAP 
							FROM SEGUROS.SINISTRO_HISTORICO H
							, 
							SEGUROS.SI_PAGA_DOC_FISCAL A
							, 
							SEGUROS.FI_PAGA_DOC_FISCAL F
							, 
							SEGUROS.FI_PAGA_DOCF_LANC C
							, 
							SEGUROS.GE_TP_LANC_DOCF Y
							, 
							SEGUROS.FI_PAGA_DOCF_IMP IMP
							, 
							SEGUROS.GE_TIPO_IMPOSTO NOM_IMP 
							WHERE A.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND A.OCORR_HISTORICO = H.OCORR_HISTORICO 
							AND A.COD_OPERACAO = H.COD_OPERACAO 
							AND C.NUM_DOCF_INTERNO = A.NUM_DOCF_INTERNO 
							AND C.VALOR_LANCAMENTO <> 0 
							AND Y.COD_TP_LANCDOCF = C.COD_TP_LANCDOCF 
							AND Y.DT_INIVIG_LANCDOCF = C.DT_INIVIG_LANCDOCF 
							AND IMP.NUM_DOCF_INTERNO = C.NUM_DOCF_INTERNO 
							AND IMP.COD_TP_LANCDOCF = C.COD_TP_LANCDOCF 
							AND IMP.DT_INIVIG_LANCDOCF = C.DT_INIVIG_LANCDOCF 
							AND NOM_IMP.COD_IMP_INTERNO = IMP.COD_IMP_INTERNO 
							AND NOM_IMP.DATA_INIVIG_IMP = IMP.DATA_INIVIG_IMP 
							AND H.NUM_APOL_SINISTRO = '{SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}' 
							AND H.OCORR_HISTORICO = '{SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}' 
							AND F.NUM_DOCF_INTERNO = A.NUM_DOCF_INTERNO 
							AND IMP.VALOR_IMPOSTO <> 0";

                return query;
            }
            IMPOSTOS.GetQueryEvent += GetQuery_IMPOSTOS;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_EXIT*/

        [StopWatch]
        /*" R0101-FETCH-MOVDEBCE */
        private void R0101_FETCH_MOVDEBCE(bool isPerform = false)
        {
            /*" -1414- DISPLAY 'R0101-FETCH-MOVDEBCE' */
            _.Display($"R0101-FETCH-MOVDEBCE");

            /*" -1466- PERFORM R0101_FETCH_MOVDEBCE_DB_FETCH_1 */

            R0101_FETCH_MOVDEBCE_DB_FETCH_1();

            /*" -1469- IF W-AC-LIDOS-MOVDEBCE EQUAL 0 AND SQLCODE EQUAL 100 */

            if (AREA_DE_WORK.W_AC_LIDOS_MOVDEBCE == 0 && DB.SQLCODE == 100)
            {

                /*" -1470- DISPLAY ' ' */
                _.Display($" ");

                /*" -1471- DISPLAY ' ' */
                _.Display($" ");

                /*" -1472- DISPLAY '********************************************' */
                _.Display($"********************************************");

                /*" -1473- DISPLAY '*                                          *' */
                _.Display($"*                                          *");

                /*" -1474- DISPLAY '*          SUB-ROTINA - SICP001S           *' */
                _.Display($"*          SUB-ROTINA - SICP001S           *");

                /*" -1475- DISPLAY '*                                          *' */
                _.Display($"*                                          *");

                /*" -1476- DISPLAY '* ERRO NA DEFINICAO DO PROGRAMA            *' */
                _.Display($"* ERRO NA DEFINICAO DO PROGRAMA            *");

                /*" -1477- DISPLAY '*                                          *' */
                _.Display($"*                                          *");

                /*" -1478- DISPLAY '* PROGRAMA CANCELADO                       *' */
                _.Display($"* PROGRAMA CANCELADO                       *");

                /*" -1479- DISPLAY '*                                          *' */
                _.Display($"*                                          *");

                /*" -1480- DISPLAY '* NAO FOI ENCONTRADO REGISTRO NO JOIN DA   *' */
                _.Display($"* NAO FOI ENCONTRADO REGISTRO NO JOIN DA   *");

                /*" -1481- DISPLAY '* MOVTO_DEBITOCC_CEF  COM OUTRAS TABELAS   *' */
                _.Display($"* MOVTO_DEBITOCC_CEF  COM OUTRAS TABELAS   *");

                /*" -1482- DISPLAY '*                                          *' */
                _.Display($"*                                          *");

                /*" -1483- DISPLAY '* CHAVE DA MOVTO_DEBITOCC_CEF:             *' */
                _.Display($"* CHAVE DA MOVTO_DEBITOCC_CEF:             *");

                /*" -1484- DISPLAY '*                                          *' */
                _.Display($"*                                          *");

                /*" -1485- DISPLAY '* NUM_APOLICE: ' LK-SICPW001-NUM-APOLICE */
                _.Display($"* NUM_APOLICE: {SICPW001.LK_SICPW001_NUM_APOLICE}");

                /*" -1486- DISPLAY '* NUM_ENDOSSO: ' LK-SICPW001-NUM-ENDOSSO */
                _.Display($"* NUM_ENDOSSO: {SICPW001.LK_SICPW001_NUM_ENDOSSO}");

                /*" -1487- DISPLAY '* NUM_PARCELA: ' LK-SICPW001-NUM-PARCELA */
                _.Display($"* NUM_PARCELA: {SICPW001.LK_SICPW001_NUM_PARCELA}");

                /*" -1488- DISPLAY '* NSAS       : ' LK-SICPW001-NSAS */
                _.Display($"* NSAS       : {SICPW001.LK_SICPW001_NSAS}");

                /*" -1489- DISPLAY '* CONVENIO   : ' LK-SICPW001-COD-CONVENIO */
                _.Display($"* CONVENIO   : {SICPW001.LK_SICPW001_COD_CONVENIO}");

                /*" -1491- DISPLAY '* SITUACAO_COBRANCA: ' LK-SICPW001-SITUACAO-COBRANCA */
                _.Display($"* SITUACAO_COBRANCA: {SICPW001.LK_SICPW001_SITUACAO_COBRANCA}");

                /*" -1492- DISPLAY '* W-AC-LIDOS-MOVDEBCE - ' W-AC-LIDOS-MOVDEBCE */
                _.Display($"* W-AC-LIDOS-MOVDEBCE - {AREA_DE_WORK.W_AC_LIDOS_MOVDEBCE}");

                /*" -1493- DISPLAY '* SQLCODE - ' SQLCODE */
                _.Display($"* SQLCODE - {DB.SQLCODE}");

                /*" -1494- DISPLAY '*                                          *' */
                _.Display($"*                                          *");

                /*" -1495- DISPLAY '********************************************' */
                _.Display($"********************************************");

                /*" -1496- DISPLAY ' ' */
                _.Display($" ");

                /*" -1497- MOVE '1' TO LK-SICPW001-COD-RETORNO */
                _.Move("1", SICPW001.LK_SICPW001_COD_RETORNO);

                /*" -1499- MOVE 'NAO FOI ENCONTRADO REG. NA MOVTO_DEBITOCC_CEF' TO LK-SICPW001-MENSAGEM-RETORNO */
                _.Move("NAO FOI ENCONTRADO REG. NA MOVTO_DEBITOCC_CEF", SICPW001.LK_SICPW001_MENSAGEM_RETORNO);

                /*" -1499- PERFORM R0101_FETCH_MOVDEBCE_DB_CLOSE_1 */

                R0101_FETCH_MOVDEBCE_DB_CLOSE_1();

                /*" -1501- GO TO RXXXX-ROTINA-RETORNO */

                RXXXX_ROTINA_RETORNO(); //GOTO
                return;

                /*" -1503- END-IF. */
            }


            /*" -1504- DISPLAY 'QUERY:  ' W-NOME-QUERY */
            _.Display($"QUERY:  {W_NOME_QUERY}");

            /*" -1505- DISPLAY 'NUM_APOL_SINISTRO = ' SINISHIS-NUM-APOL-SINISTRO */
            _.Display($"NUM_APOL_SINISTRO = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

            /*" -1506- DISPLAY 'OCORR_HISTORICO   = ' SINISHIS-OCORR-HISTORICO */
            _.Display($"OCORR_HISTORICO   = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}");

            /*" -1507- DISPLAY 'COD_OPERACAO      = ' SINISHIS-COD-OPERACAO */
            _.Display($"COD_OPERACAO      = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO}");

            /*" -1560- DISPLAY 'COD_CONVENIO      = ' MOVDEBCE-COD-CONVENIO */
            _.Display($"COD_CONVENIO      = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO}");

            /*" -1561- MOVE 'NAO' TO W-CHAVE-EH-PRESTADOR. */
            _.Move("NAO", AREA_DE_WORK.W_CHAVE_EH_PRESTADOR);

            /*" -1562- IF SQLCODE EQUAL 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -1564- IF (SINISHIS-COD-PREST-SERVICO NOT EQUAL 0) AND (SINISHIS-COD-SERVICO NOT EQUAL 95) */

                if ((SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO != 0) && (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_SERVICO != 95))
                {

                    /*" -1565- MOVE 'SIM' TO W-CHAVE-EH-PRESTADOR */
                    _.Move("SIM", AREA_DE_WORK.W_CHAVE_EH_PRESTADOR);

                    /*" -1566- END-IF */
                }


                /*" -1568- END-IF. */
            }


            /*" -1569- IF SQLCODE EQUAL 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -1570- ADD 1 TO W-AC-LIDOS-MOVDEBCE */
                AREA_DE_WORK.W_AC_LIDOS_MOVDEBCE.Value = AREA_DE_WORK.W_AC_LIDOS_MOVDEBCE + 1;

                /*" -1572- END-IF. */
            }


            /*" -1573- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1573- PERFORM R0101_FETCH_MOVDEBCE_DB_CLOSE_2 */

                R0101_FETCH_MOVDEBCE_DB_CLOSE_2();

                /*" -1575- MOVE 'SIM' TO WFIM-LE-MOVDEBCE-1 */
                _.Move("SIM", AREA_DE_WORK.WFIM_LE_MOVDEBCE_1);

                /*" -1576- GO TO R0101-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0101_EXIT*/ //GOTO
                return;

                /*" -1578- END-IF. */
            }


            /*" -1579- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1580- DISPLAY 'SICP001S- ERRO NO FETCH CURSOR LE_MOVDEBCE(1)' */
                _.Display($"SICP001S- ERRO NO FETCH CURSOR LE_MOVDEBCE(1)");

                /*" -1581- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -1581- END-IF. */
            }


        }

        [StopWatch]
        /*" R0101-FETCH-MOVDEBCE-DB-FETCH-1 */
        public void R0101_FETCH_MOVDEBCE_DB_FETCH_1()
        {
            /*" -1466- EXEC SQL FETCH LE_MOVDEBCE INTO :W-NOME-QUERY, :SINISHIS-TIPO-REGISTRO, :W-NOME-TIPO-SEGURO, :SINISHIS-NUM-APOLICE, :SINISHIS-NUM-APOL-SINISTRO, :SINISHIS-OCORR-HISTORICO, :SINISHIS-COD-OPERACAO, :SINISHIS-NOME-FAVORECIDO, :W-ANO-OPERACIONAL-MOVIMENTO, :W-ANO-CONTABIL-MOVIMENTO, :GEOPERAC-FUNCAO-OPERACAO, :GEOPERAC-IND-TIPO-FUNCAO, :GEOPERAC-DES-OPERACAO, :SINISHIS-VAL-OPERACAO, :MOVDEBCE-VLR-CREDITO, :MOVDEBCE-VALOR-DEBITO, :SINISHIS-DATA-MOVIMENTO, :SINISHIS-COD-PREST-SERVICO, :SINISHIS-COD-SERVICO, :SINISHIS-SIT-CONTABIL, :W-NOME-FORMA-PAGAMENTO, :SINISHIS-NOM-PROGRAMA:NULL-NOM-PROGRAMA, :SINISHIS-COD-USUARIO, :SINISMES-RAMO, :SINISMES-COD-FONTE, :W-DATA-AVISO-SIAS, :SINISMES-DATA-COMUNICADO, :SINISMES-COD-PRODUTO, :PRODUTO-DESCR-PRODUTO, :CHEQUEMI-NUM-CHEQUE-INTERNO, :MOVDEBCE-NUM-APOLICE, :MOVDEBCE-NUM-ENDOSSO, :MOVDEBCE-NUM-PARCELA, :MOVDEBCE-SITUACAO-COBRANCA, :W-NOME-SITUACAO-COBRANCA, :MOVDEBCE-DATA-VENCIMENTO, :MOVDEBCE-DATA-MOVIMENTO, :MOVDEBCE-COD-AGENCIA-DEB, :MOVDEBCE-OPER-CONTA-DEB, :MOVDEBCE-NUM-CONTA-DEB, :MOVDEBCE-DIG-CONTA-DEB, :MOVDEBCE-COD-CONVENIO, :MOVDEBCE-DATA-ENVIO, :MOVDEBCE-NSAS, :MOVDEBCE-NUM-REQUISICAO, :GE369-COD-AGENCIA:NULL-COD-AGENCIA, :GE369-COD-BANCO:NULL-COD-BANCO, :GE369-NUM-CONTA-CNB:NULL-NUM-CONTA-CNB, :GE369-NUM-DV-CONTA-CNB:NULL-NUM-DV-CONTA-CNB, :GE369-IND-CONTA-BANCARIA:NULL-IND-CONTA-BANCARIA ,:PRODUTO-COD-EMPRESA END-EXEC. */

            if (LE_MOVDEBCE.Fetch())
            {
                _.Move(LE_MOVDEBCE.W_NOME_QUERY, W_NOME_QUERY);
                _.Move(LE_MOVDEBCE.SINISHIS_TIPO_REGISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_TIPO_REGISTRO);
                _.Move(LE_MOVDEBCE.W_NOME_TIPO_SEGURO, W_NOME_TIPO_SEGURO);
                _.Move(LE_MOVDEBCE.SINISHIS_NUM_APOLICE, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOLICE);
                _.Move(LE_MOVDEBCE.SINISHIS_NUM_APOL_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO);
                _.Move(LE_MOVDEBCE.SINISHIS_OCORR_HISTORICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO);
                _.Move(LE_MOVDEBCE.SINISHIS_COD_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);
                _.Move(LE_MOVDEBCE.SINISHIS_NOME_FAVORECIDO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO);
                _.Move(LE_MOVDEBCE.W_ANO_OPERACIONAL_MOVIMENTO, W_ANO_OPERACIONAL_MOVIMENTO);
                _.Move(LE_MOVDEBCE.W_ANO_CONTABIL_MOVIMENTO, W_ANO_CONTABIL_MOVIMENTO);
                _.Move(LE_MOVDEBCE.GEOPERAC_FUNCAO_OPERACAO, GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO);
                _.Move(LE_MOVDEBCE.GEOPERAC_IND_TIPO_FUNCAO, GEOPERAC.DCLGE_OPERACAO.GEOPERAC_IND_TIPO_FUNCAO);
                _.Move(LE_MOVDEBCE.GEOPERAC_DES_OPERACAO, GEOPERAC.DCLGE_OPERACAO.GEOPERAC_DES_OPERACAO);
                _.Move(LE_MOVDEBCE.SINISHIS_VAL_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);
                _.Move(LE_MOVDEBCE.MOVDEBCE_VLR_CREDITO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_CREDITO);
                _.Move(LE_MOVDEBCE.MOVDEBCE_VALOR_DEBITO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO);
                _.Move(LE_MOVDEBCE.SINISHIS_DATA_MOVIMENTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO);
                _.Move(LE_MOVDEBCE.SINISHIS_COD_PREST_SERVICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO);
                _.Move(LE_MOVDEBCE.SINISHIS_COD_SERVICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_SERVICO);
                _.Move(LE_MOVDEBCE.SINISHIS_SIT_CONTABIL, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL);
                _.Move(LE_MOVDEBCE.W_NOME_FORMA_PAGAMENTO, W_NOME_FORMA_PAGAMENTO);
                _.Move(LE_MOVDEBCE.SINISHIS_NOM_PROGRAMA, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOM_PROGRAMA);
                _.Move(LE_MOVDEBCE.NULL_NOM_PROGRAMA, NULL_NOM_PROGRAMA);
                _.Move(LE_MOVDEBCE.SINISHIS_COD_USUARIO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_USUARIO);
                _.Move(LE_MOVDEBCE.SINISMES_RAMO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO);
                _.Move(LE_MOVDEBCE.SINISMES_COD_FONTE, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE);
                _.Move(LE_MOVDEBCE.W_DATA_AVISO_SIAS, W_DATA_AVISO_SIAS);
                _.Move(LE_MOVDEBCE.SINISMES_DATA_COMUNICADO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_COMUNICADO);
                _.Move(LE_MOVDEBCE.SINISMES_COD_PRODUTO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO);
                _.Move(LE_MOVDEBCE.PRODUTO_DESCR_PRODUTO, PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO);
                _.Move(LE_MOVDEBCE.CHEQUEMI_NUM_CHEQUE_INTERNO, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NUM_CHEQUE_INTERNO);
                _.Move(LE_MOVDEBCE.MOVDEBCE_NUM_APOLICE, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);
                _.Move(LE_MOVDEBCE.MOVDEBCE_NUM_ENDOSSO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);
                _.Move(LE_MOVDEBCE.MOVDEBCE_NUM_PARCELA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA);
                _.Move(LE_MOVDEBCE.MOVDEBCE_SITUACAO_COBRANCA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);
                _.Move(LE_MOVDEBCE.W_NOME_SITUACAO_COBRANCA, W_NOME_SITUACAO_COBRANCA);
                _.Move(LE_MOVDEBCE.MOVDEBCE_DATA_VENCIMENTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO);
                _.Move(LE_MOVDEBCE.MOVDEBCE_DATA_MOVIMENTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO);
                _.Move(LE_MOVDEBCE.MOVDEBCE_COD_AGENCIA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB);
                _.Move(LE_MOVDEBCE.MOVDEBCE_OPER_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB);
                _.Move(LE_MOVDEBCE.MOVDEBCE_NUM_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB);
                _.Move(LE_MOVDEBCE.MOVDEBCE_DIG_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB);
                _.Move(LE_MOVDEBCE.MOVDEBCE_COD_CONVENIO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);
                _.Move(LE_MOVDEBCE.MOVDEBCE_DATA_ENVIO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_ENVIO);
                _.Move(LE_MOVDEBCE.MOVDEBCE_NSAS, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS);
                _.Move(LE_MOVDEBCE.MOVDEBCE_NUM_REQUISICAO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO);
                _.Move(LE_MOVDEBCE.GE369_COD_AGENCIA, GE369.DCLGE_MOVTO_CONTA.GE369_COD_AGENCIA);
                _.Move(LE_MOVDEBCE.NULL_COD_AGENCIA, NULL_COD_AGENCIA);
                _.Move(LE_MOVDEBCE.GE369_COD_BANCO, GE369.DCLGE_MOVTO_CONTA.GE369_COD_BANCO);
                _.Move(LE_MOVDEBCE.NULL_COD_BANCO, NULL_COD_BANCO);
                _.Move(LE_MOVDEBCE.GE369_NUM_CONTA_CNB, GE369.DCLGE_MOVTO_CONTA.GE369_NUM_CONTA_CNB);
                _.Move(LE_MOVDEBCE.NULL_NUM_CONTA_CNB, NULL_NUM_CONTA_CNB);
                _.Move(LE_MOVDEBCE.GE369_NUM_DV_CONTA_CNB, GE369.DCLGE_MOVTO_CONTA.GE369_NUM_DV_CONTA_CNB);
                _.Move(LE_MOVDEBCE.NULL_NUM_DV_CONTA_CNB, NULL_NUM_DV_CONTA_CNB);
                _.Move(LE_MOVDEBCE.GE369_IND_CONTA_BANCARIA, GE369.DCLGE_MOVTO_CONTA.GE369_IND_CONTA_BANCARIA);
                _.Move(LE_MOVDEBCE.NULL_IND_CONTA_BANCARIA, NULL_IND_CONTA_BANCARIA);
                _.Move(LE_MOVDEBCE.PRODUTO_COD_EMPRESA, PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA);
            }

        }

        [StopWatch]
        /*" R0101-FETCH-MOVDEBCE-DB-CLOSE-1 */
        public void R0101_FETCH_MOVDEBCE_DB_CLOSE_1()
        {
            /*" -1499- EXEC SQL CLOSE LE_MOVDEBCE END-EXEC */

            LE_MOVDEBCE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0101_EXIT*/

        [StopWatch]
        /*" R0101-FETCH-MOVDEBCE-DB-CLOSE-2 */
        public void R0101_FETCH_MOVDEBCE_DB_CLOSE_2()
        {
            /*" -1573- EXEC SQL CLOSE LE_MOVDEBCE END-EXEC */

            LE_MOVDEBCE.Close();

        }

        [StopWatch]
        /*" R0200-PROCESSA-PRINCIPAL */
        private void R0200_PROCESSA_PRINCIPAL(bool isPerform = false)
        {
            /*" -1593- DISPLAY 'R0200-PROCESSA-PRINCIPAL' */
            _.Display($"R0200-PROCESSA-PRINCIPAL");

            /*" -1594- MOVE SINISHIS-COD-OPERACAO TO SI239-COD-OPERACAO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO, SI239.DCLSI_OPERACAO_EVENTO.SI239_COD_OPERACAO);

            /*" -1595- MOVE SISTEMAS-DATA-MOV-ABERTO TO SI239-DTA-INI-VIGENCIA */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, SI239.DCLSI_OPERACAO_EVENTO.SI239_DTA_INI_VIGENCIA);

            /*" -1597- PERFORM P7239-SI2-SELECT THRU P7239-SI2-EXIT. */

            P7239_SI2_SELECT(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: P7239_SI2_EXIT*/


            /*" -1598- IF WS-SI239-SQL100 = 'SIM' */

            if (AREA_DE_WORK.WS_SI239_SQL100 == "SIM")
            {

                /*" -1600- DISPLAY 'SICP001S- NAO ACHEI OPERACAO ' 'NA SI_OPERACAO_EVENTO' */
                _.Display($"SICP001S- NAO ACHEI OPERACAO NA SI_OPERACAO_EVENTO");

                /*" -1602- DISPLAY 'LK-SICPW001-NUM-APOLICE ........ ' LK-SICPW001-NUM-APOLICE */
                _.Display($"LK-SICPW001-NUM-APOLICE ........ {SICPW001.LK_SICPW001_NUM_APOLICE}");

                /*" -1604- DISPLAY 'LK-SICPW001-NUM-ENDOSSO ........ ' LK-SICPW001-NUM-ENDOSSO */
                _.Display($"LK-SICPW001-NUM-ENDOSSO ........ {SICPW001.LK_SICPW001_NUM_ENDOSSO}");

                /*" -1606- DISPLAY 'LK-SICPW001-NUM-PARCELA ........ ' LK-SICPW001-NUM-PARCELA */
                _.Display($"LK-SICPW001-NUM-PARCELA ........ {SICPW001.LK_SICPW001_NUM_PARCELA}");

                /*" -1608- DISPLAY 'SI239-COD-OPERACAO ............. ' SI239-COD-OPERACAO */
                _.Display($"SI239-COD-OPERACAO ............. {SI239.DCLSI_OPERACAO_EVENTO.SI239_COD_OPERACAO}");

                /*" -1609- MOVE '1' TO LK-SICPW001-COD-RETORNO */
                _.Move("1", SICPW001.LK_SICPW001_COD_RETORNO);

                /*" -1611- MOVE 'NAO FOI ENCONTRADO REG. NA SI_OPERACAO_EVENTO' TO LK-SICPW001-MENSAGEM-RETORNO */
                _.Move("NAO FOI ENCONTRADO REG. NA SI_OPERACAO_EVENTO", SICPW001.LK_SICPW001_MENSAGEM_RETORNO);

                /*" -1612- GO TO RXXXX-ROTINA-RETORNO */

                RXXXX_ROTINA_RETORNO(); //GOTO
                return;

                /*" -1614- END-IF. */
            }


            /*" -1616- PERFORM R19200-SELECT-REINF THRU R19200-EXIT. */

            R19200_SELECT_REINF(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R19200_EXIT*/


            /*" -1620- MOVE ZEROS TO W-NUM-CPF-NUM W-NUM-CNPJ-NUM. */
            _.Move(0, AREA_DE_WORK.W_NUM_CPF_NUM, AREA_DE_WORK.W_NUM_CNPJ_NUM);

            /*" -1625- MOVE SPACES TO W-CHAVE-ORIGEM-CADASTRO. */
            _.Move("", AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO);

            /*" -1627- MOVE 'XX' TO W-CHAVE-TIPO-PESSOA-PF-PJ. */
            _.Move("XX", AREA_DE_WORK.W_CHAVE_TIPO_PESSOA_PF_PJ);

            /*" -1629- PERFORM R2000-CADASTRAIS-ODS THRU R2000-EXIT. */

            R2000_CADASTRAIS_ODS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_EXIT*/


            /*" -1630- IF W-CHAVE-ORIGEM-CADASTRO EQUAL 'ODS' */

            if (AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO == "ODS")
            {

                /*" -1632- GO TO R0200-MONTA-REGISTRO . */

                R0200_MONTA_REGISTRO(); //GOTO
                return;
            }


            /*" -1634- INITIALIZE DCLFORNECEDORES. */
            _.Initialize(
                FORNECED.DCLFORNECEDORES
            );

            /*" -1636- PERFORM R2010-CADASTRAIS-LOTERICO THRU R2010-EXIT. */

            R2010_CADASTRAIS_LOTERICO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R2010_EXIT*/


            /*" -1637- IF W-CHAVE-ORIGEM-CADASTRO EQUAL 'FORNECEDOR OU LOTERICO' */

            if (AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO == "FORNECEDOR OU LOTERICO")
            {

                /*" -1639- GO TO R0200-MONTA-REGISTRO . */

                R0200_MONTA_REGISTRO(); //GOTO
                return;
            }


            /*" -1641- PERFORM R2020-CADASTRAIS-FORNECED THRU R2020-EXIT. */

            R2020_CADASTRAIS_FORNECED(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R2020_EXIT*/


            /*" -1642- IF W-CHAVE-ORIGEM-CADASTRO EQUAL 'FORNECEDOR OU LOTERICO' */

            if (AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO == "FORNECEDOR OU LOTERICO")
            {

                /*" -1643- GO TO R0200-MONTA-REGISTRO */

                R0200_MONTA_REGISTRO(); //GOTO
                return;

                /*" -1644- ELSE */
            }
            else
            {


                /*" -1644- MOVE 'SEM CADASTRO' TO W-CHAVE-ORIGEM-CADASTRO. */
                _.Move("SEM CADASTRO", AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO);
            }


        }

        [StopWatch]
        /*" R0200-MONTA-REGISTRO */
        private void R0200_MONTA_REGISTRO(bool isPerform = false)
        {
            /*" -1652- PERFORM R3000-MONTA-REGISTRO THRU R3000-EXIT. */

            R3000_MONTA_REGISTRO(true);

            R3000_GRAVA_REGISTRO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_EXIT*/


            /*" -1654- PERFORM R19400-VERIFICA-OPERACAO THRU R19400-EXIT. */

            R19400_VERIFICA_OPERACAO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R19400_EXIT*/


            /*" -1656- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'DLIB' OR 'RSDLB' OR 'DSLIB' OR 'JLDES' */

            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO.In("DLIB", "RSDLB", "DSLIB", "JLDES"))
            {

                /*" -1657- PERFORM R19500-MONTA-DESPESAS THRU R19500-EXIT */

                R19500_MONTA_DESPESAS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R19500_EXIT*/


                /*" -1658- ELSE */
            }
            else
            {


                /*" -1659- PERFORM R19100-MONTA-REINF THRU R19100-EXIT */

                R19100_MONTA_REINF(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R19100_EXIT*/


                /*" -1661- END-IF. */
            }


            /*" -1663- PERFORM P7000-00-GRAVA-PARA-MCP THRU P7000-99-EXIT. */

            P7000_00_GRAVA_PARA_MCP(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: P7000_99_EXIT*/


            /*" -1665- PERFORM R3550-MONTA-CODV-PAGTO-MOD-AP THRU R3550-EXIT. */

            R3550_MONTA_CODV_PAGTO_MOD_AP(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R3550_EXIT*/


            /*" -1667- PERFORM P7200-00-GERA-OPER-FINANCEIRA THRU P7200-99-EXIT. */

            P7200_00_GERA_OPER_FINANCEIRA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: P7200_99_EXIT*/


            /*" -1667- PERFORM R0101-FETCH-MOVDEBCE THRU R0101-EXIT. */

            R0101_FETCH_MOVDEBCE(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R0101_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_EXIT*/

        [StopWatch]
        /*" R3000-MONTA-REGISTRO */
        private void R3000_MONTA_REGISTRO(bool isPerform = false)
        {
            /*" -1676- DISPLAY 'R3000-MONTA-REGISTRO' */
            _.Display($"R3000-MONTA-REGISTRO");

            /*" -1680- PERFORM R3001-INITIALIZE-TABLES THRU R3001-99-EXIT. */

            R3001_INITIALIZE_TABLES(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R3001_99_EXIT*/


            /*" -1681- MOVE SI239-COD-EMPRESA-SAP TO GE420-COD-EMPRESA-SAP */
            _.Move(SI239.DCLSI_OPERACAO_EVENTO.SI239_COD_EMPRESA_SAP, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_EMPRESA_SAP);

            /*" -1682- MOVE SI239-COD-SISTEMA-SAP TO GE420-COD-SISTEMA-SAP */
            _.Move(SI239.DCLSI_OPERACAO_EVENTO.SI239_COD_SISTEMA_SAP, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_SISTEMA_SAP);

            /*" -1684- MOVE LK-SICPW001-COD-PROGRAMA TO GE420-NOM-PROG-GRAVOU */
            _.Move(SICPW001.LK_SICPW001_COD_PROGRAMA, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NOM_PROG_GRAVOU);

            /*" -1685- MOVE 'AP' TO GE420-COD-MODULO-SAP */
            _.Move("AP", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_MODULO_SAP);

            /*" -1686- MOVE SINISHIS-COD-OPERACAO TO GE420-COD-OPERACAO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_OPERACAO);

            /*" -1691- MOVE SINISHIS-OCORR-HISTORICO TO GE420-NUM-OCORR-HISTORICO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_OCORR_HISTORICO);

            /*" -1692- MOVE 'S' TO W-IDLG-SINISTRO */
            _.Move("S", AREA_DE_WORK.W_IDLG_SIAS_SINISTRO.W_IDLG_SINISTRO);

            /*" -1694- MOVE SINISHIS-NUM-APOL-SINISTRO TO W-IDLG-NUM-APOL-SINISTRO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, AREA_DE_WORK.W_IDLG_SIAS_SINISTRO.W_IDLG_NUM_APOL_SINISTRO);

            /*" -1695- MOVE SINISHIS-OCORR-HISTORICO TO W-IDLG-OCORR-HISTORICO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO, AREA_DE_WORK.W_IDLG_SIAS_SINISTRO.W_IDLG_OCORR_HISTORICO);

            /*" -1697- MOVE SINISHIS-COD-OPERACAO TO W-IDLG-COD-OPERACAO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO, AREA_DE_WORK.W_IDLG_SIAS_SINISTRO.W_IDLG_COD_OPERACAO);

            /*" -1698- IF MOVDEBCE-VLR-CREDITO NOT EQUAL 0 */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_CREDITO != 0)
            {

                /*" -1699- MOVE 'P' TO W-IDLG-TIPO-MOVIMENTO */
                _.Move("P", AREA_DE_WORK.W_IDLG_SIAS_SINISTRO.W_IDLG_TIPO_MOVIMENTO);

                /*" -1700- ELSE */
            }
            else
            {


                /*" -1701- MOVE '?' TO W-IDLG-TIPO-MOVIMENTO */
                _.Move("?", AREA_DE_WORK.W_IDLG_SIAS_SINISTRO.W_IDLG_TIPO_MOVIMENTO);

                /*" -1705- END-IF. */
            }


            /*" -1707- MOVE '2' TO W-IDLG-FORMA-PAGAMENTO. */
            _.Move("2", AREA_DE_WORK.W_IDLG_SIAS_SINISTRO.W_IDLG_FORMA_PAGAMENTO);

            /*" -1709- MOVE MOVDEBCE-NSAS TO W-IDLG-NSAS */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS, AREA_DE_WORK.W_IDLG_SIAS_SINISTRO.W_IDLG_COMPLEMENTO_2.W_IDLG_NSAS);

            /*" -1713- MOVE W-IDLG-SIAS-SINISTRO TO GE420-COD-CHAVE-NEGOCIO */
            _.Move(AREA_DE_WORK.W_IDLG_SIAS_SINISTRO, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_CHAVE_NEGOCIO);

            /*" -1715- MOVE SI239-COD-EVENTO-SAP TO GE420-COD-EVENTO-SAP */
            _.Move(SI239.DCLSI_OPERACAO_EVENTO.SI239_COD_EVENTO_SAP, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_EVENTO_SAP);

            /*" -1719- PERFORM R3010-ACESSA-SCPJUD THRU R3010-EXIT */

            R3010_ACESSA_SCPJUD(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R3010_EXIT*/


            /*" -1720- IF HOST-COUNT NOT EQUAL 0 */

            if (HOST_COUNT != 0)
            {

                /*" -1721- IF SINISMES-RAMO EQUAL 66 */

                if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO == 66)
                {

                    /*" -1722- MOVE SI239-COD-EVENTO-SAP-SFH TO GE420-COD-EVENTO-SAP */
                    _.Move(SI239.DCLSI_OPERACAO_EVENTO.SI239_COD_EVENTO_SAP_SFH, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_EVENTO_SAP);

                    /*" -1723- ELSE */
                }
                else
                {


                    /*" -1724- MOVE SI239-COD-EVENTO-SAP-JUD TO GE420-COD-EVENTO-SAP */
                    _.Move(SI239.DCLSI_OPERACAO_EVENTO.SI239_COD_EVENTO_SAP_JUD, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_EVENTO_SAP);

                    /*" -1726- END-IF. */
                }

            }


            /*" -1728- MOVE GE420-COD-EVENTO-SAP TO CODOPE-GERAL. */
            _.Move(GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_EVENTO_SAP, AREA_DE_WORK.CODOPE_GERAL);

            /*" -1730- PERFORM R3100-DADOS-FINAL-ARQUIVO THRU R3100-EXIT. */

            R3100_DADOS_FINAL_ARQUIVO(true);

            R3100_CONTINUA_MONTAGEM(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_EXIT*/


            /*" -1730- PERFORM R3500-MONTA-ATTR-PAGTO-MOD-AP THRU R3500-EXIT. */

            R3500_MONTA_ATTR_PAGTO_MOD_AP(true);

            R3500_PULA_CBEN(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R3500_EXIT*/


        }

        [StopWatch]
        /*" R3000-GRAVA-REGISTRO */
        private void R3000_GRAVA_REGISTRO(bool isPerform = false)
        {
            /*" -1737- IF W-CHAVE-MONTA-SIACC-ESPECIAL EQUAL 'NAO' */

            if (AREA_DE_WORK.W_CHAVE_MONTA_SIACC_ESPECIAL == "NAO")
            {

                /*" -1738- IF TITLE-MEDI-GERAL EQUAL 'Z004' */

                if (AREA_DE_WORK.TITLE_MEDI_GERAL == "Z004")
                {

                    /*" -1739- PERFORM R3020-ENDERECO-CAIXA-SEGUROS THRU R3020-EXIT */

                    R3020_ENDERECO_CAIXA_SEGUROS(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R3020_EXIT*/


                    /*" -1740- END-IF */
                }


                /*" -1740- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_EXIT*/

        [StopWatch]
        /*" R3001-INITIALIZE-TABLES */
        private void R3001_INITIALIZE_TABLES(bool isPerform = false)
        {
            /*" -1750- DISPLAY 'R3001-INITIALIZE-TABLES' */
            _.Display($"R3001-INITIALIZE-TABLES");

            /*" -1754- INITIALIZE DCLSI-MOVTO-PGTO-COB DCLGE-MOVTO-TRIBUTO DCLGE-MOVTO-ENVIO-MCP. */
            _.Initialize(
                SI237.DCLSI_MOVTO_PGTO_COB
                , GE419.DCLGE_MOVTO_TRIBUTO
                , GE420.DCLGE_MOVTO_ENVIO_MCP
            );

            /*" -1761- MOVE '1212-12-12' TO GE420-DTA-SOL-PAGTO GE420-DTA-AVISO GE420-DTA-COMUNICACAO GE420-DTA-SENTENCA-JUDICIAL GE420-DTA-COMUNIC-SENTEN GE420-DTA-NOTA-FISCAL. */
            _.Move("1212-12-12", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DTA_SOL_PAGTO, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DTA_AVISO, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DTA_COMUNICACAO, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DTA_SENTENCA_JUDICIAL, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DTA_COMUNIC_SENTEN, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DTA_NOTA_FISCAL);

            /*" -1821- INITIALIZE WH-CPF-CNPJ-BENEF-NULL WH-LOGRADOURO-NULL WH-NUM-RESIDENCIA-NULL WH-COMPL-ENDERECO-NULL WH-BAIRRO-NULL WH-CIDADE-NULL WH-UF-NULL WH-CEP-NULL WH-TELEFONE-NULL WH-FAX-NULL WH-INSC-MUNICIPAL-NULL WH-INSC-ESTADUAL-NULL WH-OPT-SIMPLES-FEDERAL-NULL WH-CONVENIO-NULL WH-TP-CONVENIO-NULL WH-FORMA-PAG-COB-NULL WH-DOC-SIACC-NULL WH-BANCO-NULL WH-AGENCIA-NULL WH-DV-AGENCIA-NULL WH-OPERACAO-CONTA-NULL WH-CC-NULL WH-DV-CONTA-NULL WH-CONGENERE-NULL WH-FONTE-SIAS-NULL WH-RAMO-SUSEP-NULL WH-PRODUTO-NULL WH-APOLICE-NULL WH-OPERACAO-NULL WH-OCORR-HISTORICO-NULL WH-AVISO-NULL WH-COMUNICACAO-NULL WH-SENTENCA-JUDICIAL-NULL WH-COMUNIC-SENTEN-NULL WH-PROCES-JURID-NULL WH-SERVICO-SAP-NULL WH-FONTE-ISS-NULL WH-DOC-FISCAL-NULL WH-SERIE-DOC-FISCAL-NULL WH-AGRUPADOR-NULL WH-CPF-CNPJ-TOMADOR-NULL WH-INDICATIVO-OBRA-NULL WH-NACIONAL-OBRA-NULL WH-NOTA-FISCAL-NULL WH-CNAE-CPRB-NULL WH-PROCESSO-JUD-NULL WH-TP-SERVICO-INSS-NULL WH-IMPOSTO-LIMINAR-NULL WH-PROPOSTA-NULL WH-CERTIFICADO-NULL WH-ENDOSSO-NULL WH-PARCELA-NULL WH-NIT-INSS-NULL WH-CANAL-VENDA-NULL WH-TITULO-NULL WH-CEDENTE-NULL WH-COMPROMISSO-NULL WH-INFO-CART-CRED-NULL WH-QTD-PARCELA-NULL. */
            _.Initialize(
                WH_CPF_CNPJ_BENEF_NULL
                , WH_LOGRADOURO_NULL
                , WH_NUM_RESIDENCIA_NULL
                , WH_COMPL_ENDERECO_NULL
                , WH_BAIRRO_NULL
                , WH_CIDADE_NULL
                , WH_UF_NULL
                , WH_CEP_NULL
                , WH_TELEFONE_NULL
                , WH_FAX_NULL
                , WH_INSC_MUNICIPAL_NULL
                , WH_INSC_ESTADUAL_NULL
                , WH_OPT_SIMPLES_FEDERAL_NULL
                , WH_CONVENIO_NULL
                , WH_TP_CONVENIO_NULL
                , WH_FORMA_PAG_COB_NULL
                , WH_DOC_SIACC_NULL
                , WH_BANCO_NULL
                , WH_AGENCIA_NULL
                , WH_DV_AGENCIA_NULL
                , WH_OPERACAO_CONTA_NULL
                , WH_CC_NULL
                , WH_DV_CONTA_NULL
                , WH_CONGENERE_NULL
                , WH_FONTE_SIAS_NULL
                , WH_RAMO_SUSEP_NULL
                , WH_PRODUTO_NULL
                , WH_APOLICE_NULL
                , WH_OPERACAO_NULL
                , WH_OCORR_HISTORICO_NULL
                , WH_AVISO_NULL
                , WH_COMUNICACAO_NULL
                , WH_SENTENCA_JUDICIAL_NULL
                , WH_COMUNIC_SENTEN_NULL
                , WH_PROCES_JURID_NULL
                , WH_SERVICO_SAP_NULL
                , WH_FONTE_ISS_NULL
                , WH_DOC_FISCAL_NULL
                , WH_SERIE_DOC_FISCAL_NULL
                , WH_AGRUPADOR_NULL
                , WH_CPF_CNPJ_TOMADOR_NULL
                , WH_INDICATIVO_OBRA_NULL
                , WH_NACIONAL_OBRA_NULL
                , WH_NOTA_FISCAL_NULL
                , WH_CNAE_CPRB_NULL
                , WH_PROCESSO_JUD_NULL
                , WH_TP_SERVICO_INSS_NULL
                , WH_IMPOSTO_LIMINAR_NULL
                , WH_PROPOSTA_NULL
                , WH_CERTIFICADO_NULL
                , WH_ENDOSSO_NULL
                , WH_PARCELA_NULL
                , WH_NIT_INSS_NULL
                , WH_CANAL_VENDA_NULL
                , WH_TITULO_NULL
                , WH_CEDENTE_NULL
                , WH_COMPROMISSO_NULL
                , WH_INFO_CART_CRED_NULL
                , WH_QTD_PARCELA_NULL
            );

            /*" -1828- MOVE -1 TO WH-IDLG-MCP-NULL WH-IDLG-SAP-NULL WH-EMAIL-NULL WH-SEXO-NULL WH-ENVIO-MCP-NULL WH-RETORNO-SAP-ARQG-NULL WH-RETORNO-SAP-ARQH-NULL WH-EFETIVO-PGTO-COB-NULL. */
            _.Move(-1, WH_IDLG_MCP_NULL, WH_IDLG_SAP_NULL, WH_EMAIL_NULL, WH_SEXO_NULL, WH_ENVIO_MCP_NULL, WH_RETORNO_SAP_ARQG_NULL, WH_RETORNO_SAP_ARQH_NULL, WH_EFETIVO_PGTO_COB_NULL);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3001_99_EXIT*/

        [StopWatch]
        /*" R3010-ACESSA-SCPJUD */
        private void R3010_ACESSA_SCPJUD(bool isPerform = false)
        {
            /*" -1837- DISPLAY 'R3010-ACESSA-SCPJUD' */
            _.Display($"R3010-ACESSA-SCPJUD");

            /*" -1843- PERFORM R3010_ACESSA_SCPJUD_DB_SELECT_1 */

            R3010_ACESSA_SCPJUD_DB_SELECT_1();

            /*" -1846- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1847- DISPLAY 'SICP001S- ERRO COUNT SI_PROCESSO_JURID (1)' */
                _.Display($"SICP001S- ERRO COUNT SI_PROCESSO_JURID (1)");

                /*" -1849- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1850- IF HOST-COUNT EQUAL 0 */

            if (HOST_COUNT == 0)
            {

                /*" -1852- GO TO R3010-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3010_EXIT*/ //GOTO
                return;
            }


            /*" -1860- PERFORM R3010_ACESSA_SCPJUD_DB_SELECT_2 */

            R3010_ACESSA_SCPJUD_DB_SELECT_2();

            /*" -1863- IF SQLCODE = 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -1864- GO TO R3010-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3010_EXIT*/ //GOTO
                return;

                /*" -1866- END-IF. */
            }


            /*" -1868- IF SQLCODE NOT = 100 */

            if (DB.SQLCODE != 100)
            {

                /*" -1871- DISPLAY 'SICP001S - ERRO ACESSO SI_DETALHE_PROC_JURID' '\ NUM_APOL_SINISTRO  = ' SINISHIS-NUM-APOL-SINISTRO '\ OCORR_HISTORICO = ' SINISHIS-OCORR-HISTORICO */

                $"SICP001S - ERRO ACESSO SI_DETALHE_PROC_JURID\\ NUM_APOL_SINISTRO  = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}\\ OCORR_HISTORICO = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}"
                .Display();

                /*" -1872- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -1874- END-IF. */
            }


            /*" -1885- PERFORM R3010_ACESSA_SCPJUD_DB_SELECT_3 */

            R3010_ACESSA_SCPJUD_DB_SELECT_3();

            /*" -1888- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1889- DISPLAY 'SICP001S- ERRO COUNT SI_PROCESSO_JURID (2)' */
                _.Display($"SICP001S- ERRO COUNT SI_PROCESSO_JURID (2)");

                /*" -1889- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3010-ACESSA-SCPJUD-DB-SELECT-1 */
        public void R3010_ACESSA_SCPJUD_DB_SELECT_1()
        {
            /*" -1843- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :HOST-COUNT FROM SEGUROS.SI_PROCESSO_JURID WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO WITH UR END-EXEC. */

            var r3010_ACESSA_SCPJUD_DB_SELECT_1_Query1 = new R3010_ACESSA_SCPJUD_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R3010_ACESSA_SCPJUD_DB_SELECT_1_Query1.Execute(r3010_ACESSA_SCPJUD_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_COUNT, HOST_COUNT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3010_EXIT*/

        [StopWatch]
        /*" R3010-ACESSA-SCPJUD-DB-SELECT-2 */
        public void R3010_ACESSA_SCPJUD_DB_SELECT_2()
        {
            /*" -1860- EXEC SQL SELECT COD_PROCESSO_JURID INTO :SIPROJUD-COD-PROCESSO-JURID FROM SEGUROS.SI_DETALHE_PROC_JURID SDPJ WHERE SDPJ.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND SDPJ.OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO END-EXEC. */

            var r3010_ACESSA_SCPJUD_DB_SELECT_2_Query1 = new R3010_ACESSA_SCPJUD_DB_SELECT_2_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
            };

            var executed_1 = R3010_ACESSA_SCPJUD_DB_SELECT_2_Query1.Execute(r3010_ACESSA_SCPJUD_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SIPROJUD_COD_PROCESSO_JURID, SIPROJUD.DCLSI_PROCESSO_JURID.SIPROJUD_COD_PROCESSO_JURID);
            }


        }

        [StopWatch]
        /*" R3020-ENDERECO-CAIXA-SEGUROS */
        private void R3020_ENDERECO_CAIXA_SEGUROS(bool isPerform = false)
        {
            /*" -1897- DISPLAY 'R3020-ENDERECO-CAIXA-SEGUROS' */
            _.Display($"R3020-ENDERECO-CAIXA-SEGUROS");

            /*" -1898- MOVE 'Q SCN QUADRA 01' TO GE420-NOM-LOGRADOURO */
            _.Move("Q SCN QUADRA 01", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NOM_LOGRADOURO);

            /*" -1899- MOVE 'ED. # 1' TO GE420-DES-NUM-RESIDENCIA */
            _.Move("ED. # 1", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DES_NUM_RESIDENCIA);

            /*" -1900- MOVE ' 17 ANDAR' TO GE420-DES-COMPL-ENDERECO */
            _.Move(" 17 ANDAR", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DES_COMPL_ENDERECO);

            /*" -1901- MOVE '70711-900' TO GE420-COD-CEP */
            _.Move("70711-900", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_CEP);

            /*" -1902- MOVE 'DF' TO GE420-COD-UF */
            _.Move("DF", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_UF);

            /*" -1903- MOVE 'BRASILIA' TO GE420-NOM-CIDADE */
            _.Move("BRASILIA", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NOM_CIDADE);

            /*" -1903- MOVE 'SETOR COMERCIAL NORTE' TO GE420-NOM-BAIRRO. */
            _.Move("SETOR COMERCIAL NORTE", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NOM_BAIRRO);

        }

        [StopWatch]
        /*" R3010-ACESSA-SCPJUD-DB-SELECT-3 */
        public void R3010_ACESSA_SCPJUD_DB_SELECT_3()
        {
            /*" -1885- EXEC SQL SELECT COD_PROCESSO_JURID INTO :SIPROJUD-COD-PROCESSO-JURID FROM SEGUROS.SI_PROCESSO_JURID WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND DTH_TIMESTAMP = ( SELECT MIN(DTH_TIMESTAMP) FROM SEGUROS.SI_PROCESSO_JURID WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO ) WITH UR END-EXEC. */

            var r3010_ACESSA_SCPJUD_DB_SELECT_3_Query1 = new R3010_ACESSA_SCPJUD_DB_SELECT_3_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R3010_ACESSA_SCPJUD_DB_SELECT_3_Query1.Execute(r3010_ACESSA_SCPJUD_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SIPROJUD_COD_PROCESSO_JURID, SIPROJUD.DCLSI_PROCESSO_JURID.SIPROJUD_COD_PROCESSO_JURID);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3020_EXIT*/

        [StopWatch]
        /*" R3100-DADOS-FINAL-ARQUIVO */
        private void R3100_DADOS_FINAL_ARQUIVO(bool isPerform = false)
        {
            /*" -1915- DISPLAY 'R3100-DADOS-FINAL-ARQUIVO' */
            _.Display($"R3100-DADOS-FINAL-ARQUIVO");

            /*" -1917- IF LK-SICPW001-COD-PROGRAMA EQUAL 'FI0096B' OR 'SI5067B' OR 'SI5071B' */

            if (SICPW001.LK_SICPW001_COD_PROGRAMA.In("FI0096B", "SI5067B", "SI5071B"))
            {

                /*" -1918- MOVE 'SIM' TO W-CHAVE-MONTA-SIACC-ESPECIAL */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_MONTA_SIACC_ESPECIAL);

                /*" -1919- PERFORM R3300-MONTA-SIACC-IND-REP THRU R3300-EXIT */

                R3300_MONTA_SIACC_IND_REP(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3300_EXIT*/


                /*" -1920- GO TO R3100-CONTINUA-MONTAGEM */

                R3100_CONTINUA_MONTAGEM(); //GOTO
                return;

                /*" -1922- END-IF. */
            }


            /*" -1926- IF ( GEOPERAC-IND-TIPO-FUNCAO = 'JUR-DEP' OR 'JUR-DESP' ) OR ( GEOPERAC-IND-TIPO-FUNCAO = 'JUR-INDENI' AND NOT ( SINISHIS-COD-OPERACAO = 8210 OR 8211 OR 8212 ) ) */

            if ((GEOPERAC.DCLGE_OPERACAO.GEOPERAC_IND_TIPO_FUNCAO.In("JUR-DEP", "JUR-DESP")) || (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_IND_TIPO_FUNCAO == "JUR-INDENI" && !(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.In("8210", "8211", "8212"))))
            {

                /*" -1927- MOVE 'S' TO WS-IND-NOME-HIST */
                _.Move("S", WS_IND_NOME_HIST);

                /*" -1928- ELSE */
            }
            else
            {


                /*" -1929- MOVE 'N' TO WS-IND-NOME-HIST */
                _.Move("N", WS_IND_NOME_HIST);

                /*" -1931- END-IF */
            }


            /*" -1932- IF W-CHAVE-ORIGEM-CADASTRO EQUAL 'ODS' */

            if (AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO == "ODS")
            {

                /*" -1933- MOVE OD001-IND-PESSOA TO GE420-IND-TIPO-PESSOA */
                _.Move(OD001.DCLOD_PESSOA.OD001_IND_PESSOA, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_IND_TIPO_PESSOA);

                /*" -1934- IF OD001-IND-PESSOA EQUAL 'F' */

                if (OD001.DCLOD_PESSOA.OD001_IND_PESSOA == "F")
                {

                    /*" -1935- MOVE 'Z003' TO TITLE-MEDI-GERAL */
                    _.Move("Z003", AREA_DE_WORK.TITLE_MEDI_GERAL);

                    /*" -1936- IF NULL-NOM-PESSOA >= 0 */

                    if (NULL_NOM_PESSOA >= 0)
                    {

                        /*" -1938- MOVE OD002-NOM-PESSOA-TEXT TO GE420-NOM-RAZ-SOCIAL */
                        _.Move(OD002.DCLOD_PESSOA_FISICA.OD002_NOM_PESSOA.OD002_NOM_PESSOA_TEXT, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NOM_RAZ_SOCIAL);

                        /*" -1939- ELSE */
                    }
                    else
                    {


                        /*" -1940- MOVE ALL '1?' TO GE420-NOM-RAZ-SOCIAL */
                        _.MoveAll("1?", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NOM_RAZ_SOCIAL);

                        /*" -1941- END-IF */
                    }


                    /*" -1942- IF WS-IND-NOME-HIST = 'S' */

                    if (WS_IND_NOME_HIST == "S")
                    {

                        /*" -1944- MOVE SINISHIS-NOME-FAVORECIDO TO GE420-NOM-RAZ-SOCIAL */
                        _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NOM_RAZ_SOCIAL);

                        /*" -1945- END-IF */
                    }


                    /*" -1946- IF NULL-NUM-CPF >= 0 */

                    if (NULL_NUM_CPF >= 0)
                    {

                        /*" -1947- MOVE W-NUM-CPF-NUM TO GE420-NUM-CPF-CNPJ */
                        _.Move(AREA_DE_WORK.W_NUM_CPF_NUM, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_CPF_CNPJ);

                        /*" -1948- ELSE */
                    }
                    else
                    {


                        /*" -1949- MOVE ZEROS TO GE420-NUM-CPF-CNPJ */
                        _.Move(0, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_CPF_CNPJ);

                        /*" -1950- END-IF */
                    }


                    /*" -1951- ELSE */
                }
                else
                {


                    /*" -1952- IF OD001-IND-PESSOA EQUAL 'J' */

                    if (OD001.DCLOD_PESSOA.OD001_IND_PESSOA == "J")
                    {

                        /*" -1953- MOVE '0003' TO TITLE-MEDI-GERAL */
                        _.Move("0003", AREA_DE_WORK.TITLE_MEDI_GERAL);

                        /*" -1954- IF NULL-NOM-RAZAO-SOCIAL >= 0 */

                        if (NULL_NOM_RAZAO_SOCIAL >= 0)
                        {

                            /*" -1956- MOVE OD003-NOM-RAZAO-SOCIAL-TEXT TO GE420-NOM-RAZ-SOCIAL */
                            _.Move(OD003.DCLOD_PESSOA_JURIDICA.OD003_NOM_RAZAO_SOCIAL.OD003_NOM_RAZAO_SOCIAL_TEXT, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NOM_RAZ_SOCIAL);

                            /*" -1957- ELSE */
                        }
                        else
                        {


                            /*" -1958- MOVE ALL '?2' TO GE420-NOM-RAZ-SOCIAL */
                            _.MoveAll("?2", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NOM_RAZ_SOCIAL);

                            /*" -1959- END-IF */
                        }


                        /*" -1960- IF WS-IND-NOME-HIST = 'S' */

                        if (WS_IND_NOME_HIST == "S")
                        {

                            /*" -1962- MOVE SINISHIS-NOME-FAVORECIDO TO GE420-NOM-RAZ-SOCIAL */
                            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NOM_RAZ_SOCIAL);

                            /*" -1963- END-IF */
                        }


                        /*" -1964- IF NULL-NUM-CNPJ >= 0 */

                        if (NULL_NUM_CNPJ >= 0)
                        {

                            /*" -1965- MOVE W-NUM-CNPJ-NUM TO GE420-NUM-CPF-CNPJ */
                            _.Move(AREA_DE_WORK.W_NUM_CNPJ_NUM, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_CPF_CNPJ);

                            /*" -1966- ELSE */
                        }
                        else
                        {


                            /*" -1967- MOVE ZEROS TO GE420-NUM-CPF-CNPJ */
                            _.Move(0, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_CPF_CNPJ);

                            /*" -1968- END-IF */
                        }


                        /*" -1969- ELSE */
                    }
                    else
                    {


                        /*" -1970- MOVE ' ' TO GE420-IND-TIPO-PESSOA */
                        _.Move(" ", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_IND_TIPO_PESSOA);

                        /*" -1971- MOVE 'Z004' TO TITLE-MEDI-GERAL */
                        _.Move("Z004", AREA_DE_WORK.TITLE_MEDI_GERAL);

                        /*" -1972- MOVE ZEROS TO GE420-NUM-CPF-CNPJ */
                        _.Move(0, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_CPF_CNPJ);

                        /*" -1973- END-IF */
                    }


                    /*" -1975- END-IF. */
                }

            }


            /*" -1976- IF W-CHAVE-ORIGEM-CADASTRO EQUAL 'FORNECEDOR OU LOTERICO' */

            if (AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO == "FORNECEDOR OU LOTERICO")
            {

                /*" -1977- MOVE FORNECED-TIPO-PESSOA TO GE420-IND-TIPO-PESSOA */
                _.Move(FORNECED.DCLFORNECEDORES.FORNECED_TIPO_PESSOA, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_IND_TIPO_PESSOA);

                /*" -1978- IF FORNECED-TIPO-PESSOA EQUAL 'F' */

                if (FORNECED.DCLFORNECEDORES.FORNECED_TIPO_PESSOA == "F")
                {

                    /*" -1979- MOVE 'Z003' TO TITLE-MEDI-GERAL */
                    _.Move("Z003", AREA_DE_WORK.TITLE_MEDI_GERAL);

                    /*" -1980- MOVE FORNECED-NOME-FORNECEDOR TO GE420-NOM-RAZ-SOCIAL */
                    _.Move(FORNECED.DCLFORNECEDORES.FORNECED_NOME_FORNECEDOR, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NOM_RAZ_SOCIAL);

                    /*" -1981- IF WS-IND-NOME-HIST = 'S' */

                    if (WS_IND_NOME_HIST == "S")
                    {

                        /*" -1983- MOVE SINISHIS-NOME-FAVORECIDO TO GE420-NOM-RAZ-SOCIAL */
                        _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NOM_RAZ_SOCIAL);

                        /*" -1984- END-IF */
                    }


                    /*" -1985- MOVE W-NUM-CPF-NUM TO GE420-NUM-CPF-CNPJ */
                    _.Move(AREA_DE_WORK.W_NUM_CPF_NUM, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_CPF_CNPJ);

                    /*" -1986- ELSE */
                }
                else
                {


                    /*" -1987- IF FORNECED-TIPO-PESSOA EQUAL 'J' */

                    if (FORNECED.DCLFORNECEDORES.FORNECED_TIPO_PESSOA == "J")
                    {

                        /*" -1988- MOVE '0003' TO TITLE-MEDI-GERAL */
                        _.Move("0003", AREA_DE_WORK.TITLE_MEDI_GERAL);

                        /*" -1989- MOVE FORNECED-NOME-FORNECEDOR TO GE420-NOM-RAZ-SOCIAL */
                        _.Move(FORNECED.DCLFORNECEDORES.FORNECED_NOME_FORNECEDOR, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NOM_RAZ_SOCIAL);

                        /*" -1990- IF WS-IND-NOME-HIST = 'S' */

                        if (WS_IND_NOME_HIST == "S")
                        {

                            /*" -1992- MOVE SINISHIS-NOME-FAVORECIDO TO GE420-NOM-RAZ-SOCIAL */
                            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NOM_RAZ_SOCIAL);

                            /*" -1993- END-IF */
                        }


                        /*" -1994- MOVE W-NUM-CNPJ-NUM TO GE420-NUM-CPF-CNPJ */
                        _.Move(AREA_DE_WORK.W_NUM_CNPJ_NUM, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_CPF_CNPJ);

                        /*" -1995- ELSE */
                    }
                    else
                    {


                        /*" -1996- MOVE ' ' TO GE420-IND-TIPO-PESSOA */
                        _.Move(" ", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_IND_TIPO_PESSOA);

                        /*" -1997- MOVE 'Z004' TO TITLE-MEDI-GERAL */
                        _.Move("Z004", AREA_DE_WORK.TITLE_MEDI_GERAL);

                        /*" -1998- MOVE ZEROS TO GE420-NUM-CPF-CNPJ */
                        _.Move(0, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_CPF_CNPJ);

                        /*" -1999- END-IF */
                    }


                    /*" -2000- END-IF */
                }


                /*" -2002- END-IF. */
            }


            /*" -2003- IF W-CHAVE-ORIGEM-CADASTRO EQUAL 'SEM CADASTRO' */

            if (AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO == "SEM CADASTRO")
            {

                /*" -2004- MOVE SINISHIS-NOME-FAVORECIDO TO GE420-NOM-RAZ-SOCIAL */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NOM_RAZ_SOCIAL);

                /*" -2005- MOVE ' ' TO GE420-IND-TIPO-PESSOA */
                _.Move(" ", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_IND_TIPO_PESSOA);

                /*" -2006- MOVE 'Z004' TO TITLE-MEDI-GERAL */
                _.Move("Z004", AREA_DE_WORK.TITLE_MEDI_GERAL);

                /*" -2007- MOVE ZEROS TO GE420-NUM-CPF-CNPJ */
                _.Move(0, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_CPF_CNPJ);

                /*" -2009- END-IF. */
            }


            /*" -2010- IF W-CHAVE-EH-PRESTADOR EQUAL 'SIM' */

            if (AREA_DE_WORK.W_CHAVE_EH_PRESTADOR == "SIM")
            {

                /*" -2011- PERFORM R3200-MONTA-PRESTADOR THRU R3200-EXIT */

                R3200_MONTA_PRESTADOR(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_EXIT*/


                /*" -2013- END-IF. */
            }


            /*" -2015- MOVE 'NAO' TO W-CHAVE-COLOCA-ENDERECO */
            _.Move("NAO", AREA_DE_WORK.W_CHAVE_COLOCA_ENDERECO);

            /*" -2016- IF W-CHAVE-ORIGEM-CADASTRO EQUAL 'ODS' */

            if (AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO == "ODS")
            {

                /*" -2017- IF NULL-NOM-LOGRADOURO >= 0 */

                if (NULL_NOM_LOGRADOURO >= 0)
                {

                    /*" -2018- MOVE OD007-NOM-LOGRADOURO TO GE420-NOM-LOGRADOURO */
                    _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_LOGRADOURO, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NOM_LOGRADOURO);

                    /*" -2019- ELSE */
                }
                else
                {


                    /*" -2020- MOVE 'SIM' TO W-CHAVE-COLOCA-ENDERECO */
                    _.Move("SIM", AREA_DE_WORK.W_CHAVE_COLOCA_ENDERECO);

                    /*" -2021- MOVE ALL '?30' TO GE420-NOM-LOGRADOURO */
                    _.MoveAll("?30", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NOM_LOGRADOURO);

                    /*" -2022- END-IF */
                }


                /*" -2023- IF NULL-DES-NUM-IMOVEL >= 0 */

                if (NULL_DES_NUM_IMOVEL >= 0)
                {

                    /*" -2024- MOVE OD007-DES-NUM-IMOVEL TO GE420-DES-NUM-RESIDENCIA */
                    _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_DES_NUM_IMOVEL, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DES_NUM_RESIDENCIA);

                    /*" -2025- ELSE */
                }
                else
                {


                    /*" -2026- MOVE 'SIM' TO W-CHAVE-COLOCA-ENDERECO */
                    _.Move("SIM", AREA_DE_WORK.W_CHAVE_COLOCA_ENDERECO);

                    /*" -2027- MOVE ALL '?31' TO GE420-DES-NUM-RESIDENCIA */
                    _.MoveAll("?31", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DES_NUM_RESIDENCIA);

                    /*" -2028- END-IF */
                }


                /*" -2029- IF NULL-DES-COMPL-ENDERECO >= 0 */

                if (NULL_DES_COMPL_ENDERECO >= 0)
                {

                    /*" -2031- MOVE OD007-DES-COMPL-ENDERECO TO GE420-DES-COMPL-ENDERECO */
                    _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_DES_COMPL_ENDERECO, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DES_COMPL_ENDERECO);

                    /*" -2032- ELSE */
                }
                else
                {


                    /*" -2033- MOVE 'SIM' TO W-CHAVE-COLOCA-ENDERECO */
                    _.Move("SIM", AREA_DE_WORK.W_CHAVE_COLOCA_ENDERECO);

                    /*" -2034- MOVE ALL '?32' TO GE420-DES-COMPL-ENDERECO */
                    _.MoveAll("?32", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DES_COMPL_ENDERECO);

                    /*" -2035- END-IF */
                }


                /*" -2036- IF NULL-COD-CEP >= 0 */

                if (NULL_COD_CEP >= 0)
                {

                    /*" -2037- MOVE W-CEP-ALFA TO GE420-COD-CEP */
                    _.Move(AREA_DE_WORK.W_CEP_ALFA, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_CEP);

                    /*" -2038- ELSE */
                }
                else
                {


                    /*" -2039- MOVE '99999-999' TO GE420-COD-CEP */
                    _.Move("99999-999", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_CEP);

                    /*" -2040- END-IF */
                }


                /*" -2041- IF NULL-COD-UF >= 0 */

                if (NULL_COD_UF >= 0)
                {

                    /*" -2042- MOVE OD007-COD-UF TO GE420-COD-UF */
                    _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_UF, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_UF);

                    /*" -2043- ELSE */
                }
                else
                {


                    /*" -2044- MOVE 'XX' TO GE420-COD-UF */
                    _.Move("XX", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_UF);

                    /*" -2045- END-IF */
                }


                /*" -2046- IF NULL-NOM-CIDADE >= 0 */

                if (NULL_NOM_CIDADE >= 0)
                {

                    /*" -2047- MOVE OD007-NOM-CIDADE TO GE420-NOM-CIDADE */
                    _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_CIDADE, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NOM_CIDADE);

                    /*" -2048- ELSE */
                }
                else
                {


                    /*" -2049- MOVE 'SIM' TO W-CHAVE-COLOCA-ENDERECO */
                    _.Move("SIM", AREA_DE_WORK.W_CHAVE_COLOCA_ENDERECO);

                    /*" -2050- MOVE ALL '?35' TO GE420-NOM-CIDADE */
                    _.MoveAll("?35", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NOM_CIDADE);

                    /*" -2051- END-IF */
                }


                /*" -2052- IF NULL-NOM-BAIRRO >= 0 */

                if (NULL_NOM_BAIRRO >= 0)
                {

                    /*" -2053- MOVE OD007-NOM-BAIRRO TO GE420-NOM-BAIRRO */
                    _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_BAIRRO, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NOM_BAIRRO);

                    /*" -2054- ELSE */
                }
                else
                {


                    /*" -2055- MOVE 'SIM' TO W-CHAVE-COLOCA-ENDERECO */
                    _.Move("SIM", AREA_DE_WORK.W_CHAVE_COLOCA_ENDERECO);

                    /*" -2056- MOVE ALL '?36' TO GE420-NOM-BAIRRO */
                    _.MoveAll("?36", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NOM_BAIRRO);

                    /*" -2057- END-IF */
                }


                /*" -2059- END-IF. */
            }


            /*" -2061- IF W-CHAVE-COLOCA-ENDERECO EQUAL 'SIM' OR W-CHAVE-ORIGEM-CADASTRO EQUAL 'SEM CADASTRO' */

            if (AREA_DE_WORK.W_CHAVE_COLOCA_ENDERECO == "SIM" || AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO == "SEM CADASTRO")
            {

                /*" -2062- PERFORM R3020-ENDERECO-CAIXA-SEGUROS THRU R3020-EXIT */

                R3020_ENDERECO_CAIXA_SEGUROS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3020_EXIT*/


                /*" -2064- END-IF. */
            }


            /*" -2065- IF W-CHAVE-ORIGEM-CADASTRO EQUAL 'FORNECEDOR OU LOTERICO' */

            if (AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO == "FORNECEDOR OU LOTERICO")
            {

                /*" -2066- MOVE FORNECED-ENDERECO TO GE420-NOM-LOGRADOURO */
                _.Move(FORNECED.DCLFORNECEDORES.FORNECED_ENDERECO, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NOM_LOGRADOURO);

                /*" -2067- MOVE W-CEP-ALFA TO GE420-COD-CEP */
                _.Move(AREA_DE_WORK.W_CEP_ALFA, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_CEP);

                /*" -2068- MOVE FORNECED-SIGLA-UF TO GE420-COD-UF */
                _.Move(FORNECED.DCLFORNECEDORES.FORNECED_SIGLA_UF, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_UF);

                /*" -2069- MOVE FORNECED-CIDADE TO GE420-NOM-CIDADE */
                _.Move(FORNECED.DCLFORNECEDORES.FORNECED_CIDADE, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NOM_CIDADE);

                /*" -2070- MOVE FORNECED-BAIRRO TO GE420-NOM-BAIRRO */
                _.Move(FORNECED.DCLFORNECEDORES.FORNECED_BAIRRO, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NOM_BAIRRO);

                /*" -2070- END-IF. */
            }


        }

        [StopWatch]
        /*" R3100-CONTINUA-MONTAGEM */
        private void R3100_CONTINUA_MONTAGEM(bool isPerform = false)
        {
            /*" -2081- INITIALIZE REG-LK-BANCOS. */
            _.Initialize(
                REG_LK_BANCOS
            );

            /*" -2083- MOVE LK-SICPW001-COD-BANCO TO LK-BANCO-COD-BANCO. */
            _.Move(SICPW001.LK_SICPW001_COD_BANCO, REG_LK_BANCOS.LK_BANCO_COD_BANCO);

            /*" -2085- CALL 'GE0080B' USING REG-LK-BANCOS. */
            _.Call("GE0080B", REG_LK_BANCOS);

            /*" -2087- IF LK-BANCO-COD-RETORNO EQUAL '2' */

            if (REG_LK_BANCOS.LK_BANCO_COD_RETORNO == "2")
            {

                /*" -2088- DISPLAY LK-BANCO-MENSAGEM-RETORNO */
                _.Display(REG_LK_BANCOS.LK_BANCO_MENSAGEM_RETORNO);

                /*" -2089- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -2091- END-IF. */
            }


            /*" -2092- IF LK-BANCO-COD-RETORNO NOT EQUAL ' ' */

            if (REG_LK_BANCOS.LK_BANCO_COD_RETORNO != " ")
            {

                /*" -2093- MOVE '00' TO LK-BANCO-DV-BANCO */
                _.Move("00", REG_LK_BANCOS.LK_BANCO_DV_BANCO);

                /*" -2095- END-IF. */
            }


            /*" -2096- MOVE LK-SICPW001-COD-BANCO TO GE420-COD-BANCO */
            _.Move(SICPW001.LK_SICPW001_COD_BANCO, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_BANCO);

            /*" -2097- MOVE LK-BANCO-DV-BANCO TO W-DV-BANCO. */
            _.Move(REG_LK_BANCOS.LK_BANCO_DV_BANCO, AREA_DE_WORK.W_LOTE.W_BANKK.W_DV_BANCO);

            /*" -2101- MOVE LK-SICPW001-COD-AGENCIA TO GE420-COD-AGENCIA. */
            _.Move(SICPW001.LK_SICPW001_COD_AGENCIA, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_AGENCIA);

            /*" -2102- IF LK-SICPW001-COD-BANCO EQUAL 341 */

            if (SICPW001.LK_SICPW001_COD_BANCO == 341)
            {

                /*" -2103- MOVE SPACES TO GE420-NUM-DV-AGENCIA */
                _.Move("", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_DV_AGENCIA);

                /*" -2104- ELSE */
            }
            else
            {


                /*" -2105- MOVE LK-SICPW001-DV-AGENCIA TO GE420-NUM-DV-AGENCIA */
                _.Move(SICPW001.LK_SICPW001_DV_AGENCIA, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_DV_AGENCIA);

                /*" -2114- END-IF. */
            }


            /*" -2116- MOVE LK-SICPW001-NUM-CONTA TO W-NUM-CONTA-SAP. */
            _.Move(SICPW001.LK_SICPW001_NUM_CONTA, AREA_DE_WORK.W_LOTE.W_CONTA_SAP.W_NUM_CONTA_SAP);

            /*" -2118- IF LK-SICPW001-COD-CONVENIO EQUAL 921286 AND LK-SICPW001-COD-BANCO EQUAL 104 */

            if (SICPW001.LK_SICPW001_COD_CONVENIO == 921286 && SICPW001.LK_SICPW001_COD_BANCO == 104)
            {

                /*" -2119- MOVE W-TIPO-OPER-BB TO LK-SICPW001-OPERACAO-CONTA */
                _.Move(AREA_DE_WORK.W_LOTE.W_CONTA_SAP.FILLER_11.W_TIPO_OPER_BB, SICPW001.LK_SICPW001_OPERACAO_CONTA);

                /*" -2120- MOVE ZEROS TO W-TIPO-OPER-BB */
                _.Move(0, AREA_DE_WORK.W_LOTE.W_CONTA_SAP.FILLER_11.W_TIPO_OPER_BB);

                /*" -2122- END-IF. */
            }


            /*" -2123- MOVE W-NUM-CONTA-SAP TO GE420-NUM-CC. */
            _.Move(AREA_DE_WORK.W_LOTE.W_CONTA_SAP.W_NUM_CONTA_SAP, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_CC);

            /*" -2127- MOVE LK-SICPW001-DV-CONTA TO GE420-NUM-DV-CONTA. */
            _.Move(SICPW001.LK_SICPW001_DV_CONTA, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_DV_CONTA);

            /*" -2128- IF LK-SICPW001-COD-BANCO NOT EQUAL 104 */

            if (SICPW001.LK_SICPW001_COD_BANCO != 104)
            {

                /*" -2129- MOVE 1 TO GE420-NUM-OPERACAO-CONTA */
                _.Move(1, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_OPERACAO_CONTA);

                /*" -2130- ELSE */
            }
            else
            {


                /*" -2131- IF LK-SICPW001-COD-BANCO EQUAL 104 */

                if (SICPW001.LK_SICPW001_COD_BANCO == 104)
                {

                    /*" -2134- IF LK-SICPW001-OPERACAO-CONTA EQUAL 01 OR 02 OR 03 OR 06 OR 07 OR 13 OR 22 OR 23 */

                    if (SICPW001.LK_SICPW001_OPERACAO_CONTA.In("01", "02", "03", "06", "07", "13", "22", "23"))
                    {

                        /*" -2136- MOVE LK-SICPW001-OPERACAO-CONTA TO GE420-NUM-OPERACAO-CONTA */
                        _.Move(SICPW001.LK_SICPW001_OPERACAO_CONTA, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_OPERACAO_CONTA);

                        /*" -2137- ELSE */
                    }
                    else
                    {


                        /*" -2138- MOVE ZEROS TO GE420-NUM-OPERACAO-CONTA */
                        _.Move(0, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_OPERACAO_CONTA);

                        /*" -2139- END-IF */
                    }


                    /*" -2140- END-IF */
                }


                /*" -2142- END-IF. */
            }


            /*" -2144- IF LK-SICPW001-COD-BANCO EQUAL 104 AND W-CHAVE-MONTA-SIACC-ESPECIAL EQUAL 'SIM' */

            if (SICPW001.LK_SICPW001_COD_BANCO == 104 && AREA_DE_WORK.W_CHAVE_MONTA_SIACC_ESPECIAL == "SIM")
            {

                /*" -2145- MOVE 003 TO GE420-NUM-OPERACAO-CONTA */
                _.Move(003, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_OPERACAO_CONTA);

                /*" -2146- MOVE ZEROS TO GE420-NUM-CC */
                _.Move(0, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_CC);

                /*" -2169- END-IF. */
            }


            /*" -2170- IF (MOVDEBCE-COD-CONVENIO EQUAL 43350) */

            if ((MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO == 43350))
            {

                /*" -2172- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'LIB' AND SINISMES-RAMO = 31 OR 42 OR 53 */

                if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "LIB" && SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO.In("31", "42", "53"))
                {

                    /*" -2173- MOVE 'G' TO GE420-IND-FORMA-PAG-COB */
                    _.Move("G", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_IND_FORMA_PAG_COB);

                    /*" -2174- ELSE */
                }
                else
                {


                    /*" -2175- MOVE 'O' TO GE420-IND-FORMA-PAG-COB */
                    _.Move("O", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_IND_FORMA_PAG_COB);

                    /*" -2176- END-IF */
                }


                /*" -2177- ELSE */
            }
            else
            {


                /*" -2178- IF (MOVDEBCE-COD-CONVENIO EQUAL 921286) */

                if ((MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO == 921286))
                {

                    /*" -2179- MOVE '0' TO GE420-IND-FORMA-PAG-COB */
                    _.Move("0", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_IND_FORMA_PAG_COB);

                    /*" -2180- ELSE */
                }
                else
                {


                    /*" -2183- IF (MOVDEBCE-COD-CONVENIO EQUAL 600119) OR (MOVDEBCE-COD-CONVENIO EQUAL 600120) OR (MOVDEBCE-COD-CONVENIO EQUAL 600123) */

                    if ((MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO == 600119) || (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO == 600120) || (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO == 600123))
                    {

                        /*" -2184- MOVE 'I' TO GE420-IND-FORMA-PAG-COB */
                        _.Move("I", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_IND_FORMA_PAG_COB);

                        /*" -2185- ELSE */
                    }
                    else
                    {


                        /*" -2186- IF (MOVDEBCE-COD-CONVENIO EQUAL 600128) */

                        if ((MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO == 600128))
                        {

                            /*" -2187- MOVE 'S' TO GE420-IND-FORMA-PAG-COB */
                            _.Move("S", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_IND_FORMA_PAG_COB);

                            /*" -2188- ELSE */
                        }
                        else
                        {


                            /*" -2189- MOVE '?' TO GE420-IND-FORMA-PAG-COB */
                            _.Move("?", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_IND_FORMA_PAG_COB);

                            /*" -2190- END-IF */
                        }


                        /*" -2191- END-IF */
                    }


                    /*" -2192- END-IF */
                }


                /*" -2198- END-IF. */
            }


            /*" -2199- IF FORNECED-OPT-SIMPLES-FED EQUAL 'S' */

            if (FORNECED.DCLFORNECEDORES.FORNECED_OPT_SIMPLES_FED == "S")
            {

                /*" -2200- MOVE 'SIM' TO GE420-IND-OPT-SIMPLES-FEDERAL */
                _.Move("SIM", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_IND_OPT_SIMPLES_FEDERAL);

                /*" -2201- ELSE */
            }
            else
            {


                /*" -2202- MOVE SPACES TO GE420-IND-OPT-SIMPLES-FEDERAL */
                _.Move("", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_IND_OPT_SIMPLES_FEDERAL);

                /*" -2203- MOVE -1 TO WH-OPT-SIMPLES-FEDERAL-NULL */
                _.Move(-1, WH_OPT_SIMPLES_FEDERAL_NULL);

                /*" -2205- END-IF. */
            }


            /*" -2206- MOVE '0000000000' TO GE420-NUM-TELEFONE. */
            _.Move("0000000000", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_TELEFONE);

            /*" -2207- MOVE -1 TO WH-TELEFONE-NULL. */
            _.Move(-1, WH_TELEFONE_NULL);

            /*" -2208- MOVE '0000000000' TO GE420-DES-FAX. */
            _.Move("0000000000", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DES_FAX);

            /*" -2208- MOVE -1 TO WH-FAX-NULL. */
            _.Move(-1, WH_FAX_NULL);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_EXIT*/

        [StopWatch]
        /*" R3200-MONTA-PRESTADOR */
        private void R3200_MONTA_PRESTADOR(bool isPerform = false)
        {
            /*" -2216- DISPLAY 'R3200-MONTA-PRESTADOR' */
            _.Display($"R3200-MONTA-PRESTADOR");

            /*" -2217- IF W-CHAVE-ORIGEM-CADASTRO EQUAL 'ODS' */

            if (AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO == "ODS")
            {

                /*" -2218- IF OD001-IND-PESSOA EQUAL 'F' */

                if (OD001.DCLOD_PESSOA.OD001_IND_PESSOA == "F")
                {

                    /*" -2219- IF NULL-PF-INSC-PREFEITURA >= 0 */

                    if (NULL_PF_INSC_PREFEITURA >= 0)
                    {

                        /*" -2221- MOVE W-PF-INSC-PREFEITURA TO GE420-NUM-INSC-MUNICIPAL */
                        _.Move(W_PF_INSC_PREFEITURA, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_INSC_MUNICIPAL);

                        /*" -2222- END-IF */
                    }


                    /*" -2223- IF NULL-PF-INSC-ESTADUAL >= 0 */

                    if (NULL_PF_INSC_ESTADUAL >= 0)
                    {

                        /*" -2225- MOVE W-PF-INSC-ESTADUAL TO GE420-NUM-INSC-ESTADUAL */
                        _.Move(W_PF_INSC_ESTADUAL, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_INSC_ESTADUAL);

                        /*" -2226- END-IF */
                    }


                    /*" -2227- ELSE */
                }
                else
                {


                    /*" -2228- IF OD001-IND-PESSOA EQUAL 'J' */

                    if (OD001.DCLOD_PESSOA.OD001_IND_PESSOA == "J")
                    {

                        /*" -2229- IF NULL-PJ-INSC-PREFEITURA >= 0 */

                        if (NULL_PJ_INSC_PREFEITURA >= 0)
                        {

                            /*" -2231- MOVE W-PJ-INSC-PREFEITURA TO GE420-NUM-INSC-MUNICIPAL */
                            _.Move(W_PJ_INSC_PREFEITURA, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_INSC_MUNICIPAL);

                            /*" -2232- END-IF */
                        }


                        /*" -2233- IF NULL-PJ-INSC-ESTADUAL >= 0 */

                        if (NULL_PJ_INSC_ESTADUAL >= 0)
                        {

                            /*" -2235- MOVE W-PJ-INSC-ESTADUAL TO GE420-NUM-INSC-ESTADUAL */
                            _.Move(W_PJ_INSC_ESTADUAL, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_INSC_ESTADUAL);

                            /*" -2236- END-IF */
                        }


                        /*" -2237- ELSE */
                    }
                    else
                    {


                        /*" -2238- MOVE SPACES TO GE420-NUM-INSC-MUNICIPAL */
                        _.Move("", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_INSC_MUNICIPAL);

                        /*" -2239- MOVE SPACES TO GE420-NUM-INSC-ESTADUAL */
                        _.Move("", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_INSC_ESTADUAL);

                        /*" -2240- END-IF */
                    }


                    /*" -2242- END-IF. */
                }

            }


            /*" -2243- IF W-CHAVE-ORIGEM-CADASTRO EQUAL 'ODS' */

            if (AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO == "ODS")
            {

                /*" -2245- IF GE420-NUM-INSC-MUNICIPAL EQUAL ' ' OR GE420-NUM-INSC-ESTADUAL EQUAL ' ' */

                if (GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_INSC_MUNICIPAL == " " || GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_INSC_ESTADUAL == " ")
                {

                    /*" -2246- PERFORM R3210-LE-FORNECEDOR THRU R3210-EXIT */

                    R3210_LE_FORNECEDOR(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R3210_EXIT*/


                    /*" -2248- MOVE FORNECED-INSC-PREFEITURA TO GE420-NUM-INSC-MUNICIPAL */
                    _.Move(FORNECED.DCLFORNECEDORES.FORNECED_INSC_PREFEITURA, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_INSC_MUNICIPAL);

                    /*" -2250- MOVE FORNECED-INSC-ESTADUAL TO GE420-NUM-INSC-ESTADUAL */
                    _.Move(FORNECED.DCLFORNECEDORES.FORNECED_INSC_ESTADUAL, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_INSC_ESTADUAL);

                    /*" -2251- END-IF */
                }


                /*" -2253- END-IF. */
            }


            /*" -2254- IF W-CHAVE-ORIGEM-CADASTRO EQUAL 'FORNECEDOR OU LOTERICO' */

            if (AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO == "FORNECEDOR OU LOTERICO")
            {

                /*" -2256- MOVE FORNECED-INSC-PREFEITURA TO GE420-NUM-INSC-MUNICIPAL */
                _.Move(FORNECED.DCLFORNECEDORES.FORNECED_INSC_PREFEITURA, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_INSC_MUNICIPAL);

                /*" -2258- MOVE FORNECED-INSC-ESTADUAL TO GE420-NUM-INSC-ESTADUAL */
                _.Move(FORNECED.DCLFORNECEDORES.FORNECED_INSC_ESTADUAL, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_INSC_ESTADUAL);

                /*" -2260- END-IF. */
            }


            /*" -2261- IF W-CHAVE-ORIGEM-CADASTRO EQUAL 'SEM CADASTRO' */

            if (AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO == "SEM CADASTRO")
            {

                /*" -2262- MOVE SPACES TO GE420-NUM-INSC-MUNICIPAL */
                _.Move("", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_INSC_MUNICIPAL);

                /*" -2263- MOVE SPACES TO GE420-NUM-INSC-ESTADUAL */
                _.Move("", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_INSC_ESTADUAL);

                /*" -2263- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_EXIT*/

        [StopWatch]
        /*" R3210-LE-FORNECEDOR */
        private void R3210_LE_FORNECEDOR(bool isPerform = false)
        {
            /*" -2271- DISPLAY 'R3210-LE-FORNECEDOR' */
            _.Display($"R3210-LE-FORNECEDOR");

            /*" -2283- PERFORM R3210_LE_FORNECEDOR_DB_SELECT_1 */

            R3210_LE_FORNECEDOR_DB_SELECT_1();

            /*" -2286- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -2287- DISPLAY 'SICP001S- ERRO ACESSO FORNECEDORES (2)' */
                _.Display($"SICP001S- ERRO ACESSO FORNECEDORES (2)");

                /*" -2287- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3210-LE-FORNECEDOR-DB-SELECT-1 */
        public void R3210_LE_FORNECEDOR_DB_SELECT_1()
        {
            /*" -2283- EXEC SQL SELECT F.INSC_PREFEITURA AS "INSCRICAO MUNICIPAL", F.INSC_ESTADUAL AS "INSCRICAO ESTADUAL", F.OPT_SIMPLES_FED AS "OPTANTE SIMPLES FERERAL", F.OPT_SIMPLES_MUN AS "OPTANTE SIMPLES MUNICIPAL" INTO :FORNECED-INSC-PREFEITURA, :FORNECED-INSC-ESTADUAL, :FORNECED-OPT-SIMPLES-FED, :FORNECED-OPT-SIMPLES-MUN FROM SEGUROS.FORNECEDORES F WHERE COD_FORNECEDOR = :SINISHIS-COD-PREST-SERVICO END-EXEC. */

            var r3210_LE_FORNECEDOR_DB_SELECT_1_Query1 = new R3210_LE_FORNECEDOR_DB_SELECT_1_Query1()
            {
                SINISHIS_COD_PREST_SERVICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO.ToString(),
            };

            var executed_1 = R3210_LE_FORNECEDOR_DB_SELECT_1_Query1.Execute(r3210_LE_FORNECEDOR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FORNECED_INSC_PREFEITURA, FORNECED.DCLFORNECEDORES.FORNECED_INSC_PREFEITURA);
                _.Move(executed_1.FORNECED_INSC_ESTADUAL, FORNECED.DCLFORNECEDORES.FORNECED_INSC_ESTADUAL);
                _.Move(executed_1.FORNECED_OPT_SIMPLES_FED, FORNECED.DCLFORNECEDORES.FORNECED_OPT_SIMPLES_FED);
                _.Move(executed_1.FORNECED_OPT_SIMPLES_MUN, FORNECED.DCLFORNECEDORES.FORNECED_OPT_SIMPLES_MUN);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3210_EXIT*/

        [StopWatch]
        /*" R3300-MONTA-SIACC-IND-REP */
        private void R3300_MONTA_SIACC_IND_REP(bool isPerform = false)
        {
            /*" -2295- DISPLAY 'R3300-MONTA-SIACC-IND-REP' */
            _.Display($"R3300-MONTA-SIACC-IND-REP");

            /*" -2296- MOVE LK-SICPW001-DES-BAIRRO TO GE420-NOM-BAIRRO */
            _.Move(SICPW001.LK_SICPW001_DES_BAIRRO, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NOM_BAIRRO);

            /*" -2297- MOVE LK-SICPW001-DES-CIDADE TO GE420-NOM-CIDADE */
            _.Move(SICPW001.LK_SICPW001_DES_CIDADE, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NOM_CIDADE);

            /*" -2299- MOVE LK-SICPW001-DES-SIGLA-UF TO GE420-COD-UF */
            _.Move(SICPW001.LK_SICPW001_DES_SIGLA_UF, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_UF);

            /*" -2300- IF LK-SICPW001-NUM-CEP EQUAL ZEROS */

            if (SICPW001.LK_SICPW001_NUM_CEP == 00)
            {

                /*" -2301- MOVE 99999 TO LK-SICPW001-NUM-CEP */
                _.Move(99999, SICPW001.LK_SICPW001_NUM_CEP);

                /*" -2303- END-IF. */
            }


            /*" -2306- IF LK-SICPW001-DES-COMPL-CEP(1:1) EQUAL ' ' OR LK-SICPW001-DES-COMPL-CEP(2:1) EQUAL ' ' OR LK-SICPW001-DES-COMPL-CEP(3:1) EQUAL ' ' */

            if (SICPW001.LK_SICPW001_DES_COMPL_CEP.Substring(1, 1) == " " || SICPW001.LK_SICPW001_DES_COMPL_CEP.Substring(2, 1) == " " || SICPW001.LK_SICPW001_DES_COMPL_CEP.Substring(3, 1) == " ")
            {

                /*" -2307- MOVE 000 TO LK-SICPW001-DES-COMPL-CEP */
                _.Move(000, SICPW001.LK_SICPW001_DES_COMPL_CEP);

                /*" -2309- END-IF. */
            }


            /*" -2310- MOVE LK-SICPW001-NUM-CEP TO W-CEP-ALFA-PARTE1 */
            _.Move(SICPW001.LK_SICPW001_NUM_CEP, AREA_DE_WORK.W_CEP_ALFA.W_CEP_ALFA_PARTE1);

            /*" -2311- MOVE LK-SICPW001-DES-COMPL-CEP TO W-CEP-ALFA-PARTE2. */
            _.Move(SICPW001.LK_SICPW001_DES_COMPL_CEP, AREA_DE_WORK.W_CEP_ALFA.W_CEP_ALFA_PARTE2);

            /*" -2313- MOVE W-CEP-ALFA TO GE420-COD-CEP. */
            _.Move(AREA_DE_WORK.W_CEP_ALFA, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_CEP);

            /*" -2315- MOVE LK-SICPW001-NUM-LOCAL TO GE420-DES-NUM-RESIDENCIA */
            _.Move(SICPW001.LK_SICPW001_NUM_LOCAL, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DES_NUM_RESIDENCIA);

            /*" -2316- MOVE LK-SICPW001-DES-COMPLEMENTO TO GE420-DES-COMPL-ENDERECO */
            _.Move(SICPW001.LK_SICPW001_DES_COMPLEMENTO, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DES_COMPL_ENDERECO);

            /*" -2318- MOVE LK-SICPW001-DES-LOGRADOURO TO GE420-NOM-LOGRADOURO */
            _.Move(SICPW001.LK_SICPW001_DES_LOGRADOURO, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NOM_LOGRADOURO);

            /*" -2320- MOVE LK-SICPW001-FAVORECIDO TO GE420-NOM-RAZ-SOCIAL. */
            _.Move(SICPW001.LK_SICPW001_FAVORECIDO, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NOM_RAZ_SOCIAL);

            /*" -2321- IF LK-SICPW001-COD-PROGRAMA EQUAL 'SI5067B' */

            if (SICPW001.LK_SICPW001_COD_PROGRAMA == "SI5067B")
            {

                /*" -2322- MOVE 'J' TO GE420-IND-TIPO-PESSOA */
                _.Move("J", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_IND_TIPO_PESSOA);

                /*" -2323- MOVE 'Z001' TO TITLE-MEDI-GERAL */
                _.Move("Z001", AREA_DE_WORK.TITLE_MEDI_GERAL);

                /*" -2324- GO TO R3300-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3300_EXIT*/ //GOTO
                return;

                /*" -2326- END-IF. */
            }


            /*" -2327- IF LK-SICPW001-COD-PROGRAMA EQUAL 'SI5071B' */

            if (SICPW001.LK_SICPW001_COD_PROGRAMA == "SI5071B")
            {

                /*" -2328- MOVE LK-SICPW001-MENSAGEM-RETORNO TO W-TIPO-E-CPF-CNPJ */
                _.Move(SICPW001.LK_SICPW001_MENSAGEM_RETORNO, W_TIPO_E_CPF_CNPJ);

                /*" -2329- IF W-SE-EH-PF-PJ EQUAL 'PF' */

                if (W_TIPO_E_CPF_CNPJ.W_SE_EH_PF_PJ == "PF")
                {

                    /*" -2330- MOVE 'F' TO GE420-IND-TIPO-PESSOA */
                    _.Move("F", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_IND_TIPO_PESSOA);

                    /*" -2331- MOVE W-CPF-CNPJ-MUTUARIO TO GE420-NUM-CPF-CNPJ */
                    _.Move(W_TIPO_E_CPF_CNPJ.W_CPF_CNPJ_MUTUARIO, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_CPF_CNPJ);

                    /*" -2332- MOVE 'Z003' TO TITLE-MEDI-GERAL */
                    _.Move("Z003", AREA_DE_WORK.TITLE_MEDI_GERAL);

                    /*" -2333- ELSE */
                }
                else
                {


                    /*" -2334- MOVE 'J' TO GE420-IND-TIPO-PESSOA */
                    _.Move("J", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_IND_TIPO_PESSOA);

                    /*" -2335- MOVE W-CPF-CNPJ-MUTUARIO TO GE420-NUM-CPF-CNPJ */
                    _.Move(W_TIPO_E_CPF_CNPJ.W_CPF_CNPJ_MUTUARIO, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_CPF_CNPJ);

                    /*" -2336- MOVE '0003' TO TITLE-MEDI-GERAL */
                    _.Move("0003", AREA_DE_WORK.TITLE_MEDI_GERAL);

                    /*" -2337- END-IF */
                }


                /*" -2338- MOVE LK-SICPW001-FAVORECIDO TO GE420-NOM-RAZ-SOCIAL */
                _.Move(SICPW001.LK_SICPW001_FAVORECIDO, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NOM_RAZ_SOCIAL);

                /*" -2339- GO TO R3300-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3300_EXIT*/ //GOTO
                return;

                /*" -2339- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3300_EXIT*/

        [StopWatch]
        /*" R3500-MONTA-ATTR-PAGTO-MOD-AP */
        private void R3500_MONTA_ATTR_PAGTO_MOD_AP(bool isPerform = false)
        {
            /*" -2351- DISPLAY 'R3500-MONTA-ATTR-PAGTO-MOD-AP' */
            _.Display($"R3500-MONTA-ATTR-PAGTO-MOD-AP");

            /*" -2356- MOVE SINISMES-COD-FONTE TO GE420-COD-FONTE-SIAS. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_FONTE_SIAS);

            /*" -2363- MOVE ZEROS TO LKGE-RAMO-EMISSOR LKGE-MODALIDADE LKGE-PRODUTO LKGE-GRUPO-SUSEP LKGE-RAMO-SUSEP LKGE-SQLCODE. */
            _.Move(0, PARAMETROS_GE.LKGE_RAMO_EMISSOR, PARAMETROS_GE.LKGE_MODALIDADE, PARAMETROS_GE.LKGE_PRODUTO, PARAMETROS_GE.LKGE_GRUPO_SUSEP, PARAMETROS_GE.LKGE_RAMO_SUSEP, PARAMETROS_GE.LKGE_SQLCODE);

            /*" -2366- MOVE SPACES TO LKGE-INIVIGENCIA LKGE-MENSAGEM. */
            _.Move("", PARAMETROS_GE.LKGE_INIVIGENCIA, PARAMETROS_GE.LKGE_MENSAGEM);

            /*" -2368- MOVE SINISMES-RAMO TO LKGE-RAMO-EMISSOR. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO, PARAMETROS_GE.LKGE_RAMO_EMISSOR);

            /*" -2369- IF SINISMES-RAMO EQUAL 48 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO == 48)
            {

                /*" -2371- MOVE SINISMES-COD-PRODUTO TO LKGE-PRODUTO. */
                _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO, PARAMETROS_GE.LKGE_PRODUTO);
            }


            /*" -2383- MOVE HOST-SI-DATA-MOV-ABERTO TO LKGE-INIVIGENCIA. */
            _.Move(HOST_SI_DATA_MOV_ABERTO, PARAMETROS_GE.LKGE_INIVIGENCIA);

            /*" -2385- CALL 'GE0005S' USING PARAMETROS-GE. */
            _.Call("GE0005S", PARAMETROS_GE);

            /*" -2386- IF LKGE-MENSAGEM NOT EQUAL SPACES */

            if (!PARAMETROS_GE.LKGE_MENSAGEM.IsEmpty())
            {

                /*" -2387- DISPLAY 'R1250 - ERRO NO CALL DA SUB-ROTINA GE0005S' */
                _.Display($"R1250 - ERRO NO CALL DA SUB-ROTINA GE0005S");

                /*" -2388- DISPLAY 'ERRO ...... ' LKGE-MENSAGEM */
                _.Display($"ERRO ...... {PARAMETROS_GE.LKGE_MENSAGEM}");

                /*" -2389- DISPLAY 'SQLCODE ... ' LKGE-SQLCODE */
                _.Display($"SQLCODE ... {PARAMETROS_GE.LKGE_SQLCODE}");

                /*" -2390- DISPLAY 'RAMO ...... ' LKGE-RAMO-EMISSOR */
                _.Display($"RAMO ...... {PARAMETROS_GE.LKGE_RAMO_EMISSOR}");

                /*" -2391- DISPLAY 'PRODUTO ... ' LKGE-PRODUTO */
                _.Display($"PRODUTO ... {PARAMETROS_GE.LKGE_PRODUTO}");

                /*" -2392- DISPLAY 'VIGENCIA .. ' LKGE-INIVIGENCIA */
                _.Display($"VIGENCIA .. {PARAMETROS_GE.LKGE_INIVIGENCIA}");

                /*" -2393- MOVE LKGE-SQLCODE TO SQLCODE */
                _.Move(PARAMETROS_GE.LKGE_SQLCODE, DB.SQLCODE);

                /*" -2394- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -2396- END-IF. */
            }


            /*" -2398- MOVE LKGE-RAMO-SUSEP TO GE420-COD-RAMO-SUSEP. */
            _.Move(PARAMETROS_GE.LKGE_RAMO_SUSEP, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_RAMO_SUSEP);

            /*" -2400- MOVE SINISMES-COD-PRODUTO TO GE420-COD-PRODUTO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_PRODUTO);

            /*" -2402- MOVE SINISHIS-NUM-APOLICE TO GE420-NUM-APOLICE. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOLICE, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_APOLICE);

            /*" -2404- MOVE SINISHIS-NUM-APOL-SINISTRO TO GE420-NUM-SINISTRO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_SINISTRO);

            /*" -2409- MOVE LK-SICPW001-COD-PROGRAMA TO GE420-NOM-PROGRAMA. */
            _.Move(SICPW001.LK_SICPW001_COD_PROGRAMA, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NOM_PROGRAMA);

            /*" -2412- IF CODOPE-GERAL EQUAL 'SIAS_09005' OR 'SIAS_09011' OR 'SIAS_09012' OR 'SIAS_09013' OR 'SIAS_09024' */

            if (AREA_DE_WORK.CODOPE_GERAL.In("SIAS_09005".ToString(), "SIAS_09011".ToString(), "SIAS_09012".ToString(), "SIAS_09013".ToString(), "SIAS_09024".ToString()))
            {

                /*" -2413- GO TO R3500-PULA-CBEN */

                R3500_PULA_CBEN(); //GOTO
                return;

                /*" -2425- ELSE */
            }
            else
            {


                /*" -2426- IF W-CHAVE-ORIGEM-CADASTRO EQUAL 'ODS' */

                if (AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO == "ODS")
                {

                    /*" -2427- IF NULL-NUM-CNPJ >= 0 */

                    if (NULL_NUM_CNPJ >= 0)
                    {

                        /*" -2428- MOVE W-NUM-CNPJ-NUM TO GE420-NUM-CPF-CNPJ-BENEF */
                        _.Move(AREA_DE_WORK.W_NUM_CNPJ_NUM, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_CPF_CNPJ_BENEF);

                        /*" -2429- ELSE */
                    }
                    else
                    {


                        /*" -2430- IF NULL-NUM-CPF >= 0 */

                        if (NULL_NUM_CPF >= 0)
                        {

                            /*" -2431- MOVE W-NUM-CPF-NUM TO GE420-NUM-CPF-CNPJ-BENEF */
                            _.Move(AREA_DE_WORK.W_NUM_CPF_NUM, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_CPF_CNPJ_BENEF);

                            /*" -2432- ELSE */
                        }
                        else
                        {


                            /*" -2433- MOVE ALL '7' TO GE420-NUM-CPF-CNPJ-BENEF */
                            _.MoveAll("7", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_CPF_CNPJ_BENEF);

                            /*" -2434- MOVE -1 TO WH-CPF-CNPJ-BENEF-NULL */
                            _.Move(-1, WH_CPF_CNPJ_BENEF_NULL);

                            /*" -2435- END-IF */
                        }


                        /*" -2436- END-IF */
                    }


                    /*" -2438- END-IF. */
                }

            }


            /*" -2439- IF W-CHAVE-ORIGEM-CADASTRO EQUAL 'FORNECEDOR OU LOTERICO' */

            if (AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO == "FORNECEDOR OU LOTERICO")
            {

                /*" -2440- IF FORNECED-TIPO-PESSOA EQUAL 'F' */

                if (FORNECED.DCLFORNECEDORES.FORNECED_TIPO_PESSOA == "F")
                {

                    /*" -2441- MOVE W-NUM-CPF-NUM TO GE420-NUM-CPF-CNPJ-BENEF */
                    _.Move(AREA_DE_WORK.W_NUM_CPF_NUM, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_CPF_CNPJ_BENEF);

                    /*" -2442- ELSE */
                }
                else
                {


                    /*" -2443- MOVE W-NUM-CNPJ-NUM TO GE420-NUM-CPF-CNPJ-BENEF */
                    _.Move(AREA_DE_WORK.W_NUM_CNPJ_NUM, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_CPF_CNPJ_BENEF);

                    /*" -2444- END-IF */
                }


                /*" -2444- END-IF. */
            }


        }

        [StopWatch]
        /*" R3500-PULA-CBEN */
        private void R3500_PULA_CBEN(bool isPerform = false)
        {
            /*" -2457- IF CODOPE-GERAL EQUAL 'SIAS_09002' OR 'SIAS_09003' OR 'SIAS_09004' OR 'SIAS_09006' OR 'SIAS_09007' OR 'SIAS_09008' OR 'SIAS_09009' OR 'SIAS_09015' OR 'SIAS_09022' OR 'SIAS_09025' */

            if (AREA_DE_WORK.CODOPE_GERAL.In("SIAS_09002".ToString(), "SIAS_09003".ToString(), "SIAS_09004".ToString(), "SIAS_09006".ToString(), "SIAS_09007".ToString(), "SIAS_09008".ToString(), "SIAS_09009".ToString(), "SIAS_09015".ToString(), "SIAS_09022".ToString(), "SIAS_09025".ToString()))
            {

                /*" -2458- MOVE 0 TO HOST-COUNT */
                _.Move(0, HOST_COUNT);

                /*" -2459- PERFORM R3010-ACESSA-SCPJUD THRU R3010-EXIT */

                R3010_ACESSA_SCPJUD(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3010_EXIT*/


                /*" -2461- IF HOST-COUNT EQUAL 0 */

                if (HOST_COUNT == 0)
                {

                    /*" -2462- MOVE SPACES TO GE420-COD-PROCES-JURID */
                    _.Move("", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_PROCES_JURID);

                    /*" -2463- MOVE -1 TO WH-PROCES-JURID-NULL */
                    _.Move(-1, WH_PROCES_JURID_NULL);

                    /*" -2464- ELSE */
                }
                else
                {


                    /*" -2466- MOVE SIPROJUD-COD-PROCESSO-JURID TO GE420-COD-PROCES-JURID */
                    _.Move(SIPROJUD.DCLSI_PROCESSO_JURID.SIPROJUD_COD_PROCESSO_JURID, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_PROCES_JURID);

                    /*" -2474- END-IF. */
                }

            }


            /*" -2478- MOVE W-DATA-AVISO-SIAS TO GE420-DTA-AVISO. */
            _.Move(W_DATA_AVISO_SIAS, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DTA_AVISO);

            /*" -2480- IF CODOPE-GERAL EQUAL 'SIAS_09001' OR 'SIAS_09010' OR 'SIAS_09014' OR 'SIAS_09023' */

            if (AREA_DE_WORK.CODOPE_GERAL.In("SIAS_09001".ToString(), "SIAS_09010".ToString(), "SIAS_09014".ToString(), "SIAS_09023".ToString()))
            {

                /*" -2481- MOVE SINISMES-DATA-COMUNICADO TO GE420-DTA-COMUNICACAO */
                _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_COMUNICADO, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DTA_COMUNICACAO);

                /*" -2483- END-IF. */
            }


            /*" -2488- IF CODOPE-GERAL EQUAL 'SIAS_09003' OR 'SIAS_09004' OR 'SIAS_09008' OR 'SIAS_09015' OR 'SIAS_09025' */

            if (AREA_DE_WORK.CODOPE_GERAL.In("SIAS_09003".ToString(), "SIAS_09004".ToString(), "SIAS_09008".ToString(), "SIAS_09015".ToString(), "SIAS_09025".ToString()))
            {

                /*" -2489- PERFORM R2060-MONTA-AGRUPA-PAGTO-SAP THRU R2060-EXIT */

                R2060_MONTA_AGRUPA_PAGTO_SAP(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2060_EXIT*/


                /*" -2493- END-IF. */
            }


            /*" -2497- MOVE WS-DTA-NULL TO GE420-DTA-COMUNIC-SENTEN */
            _.Move(AREA_DE_WORK.WS_DTA_NULL, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DTA_COMUNIC_SENTEN);

            /*" -2499- MOVE WS-DTA-NULL TO GE420-DTA-SENTENCA-JUDICIAL */
            _.Move(AREA_DE_WORK.WS_DTA_NULL, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DTA_SENTENCA_JUDICIAL);

            /*" -2506- IF CODOPE-GERAL EQUAL 'SIAS_09001' OR 'SIAS_09011' OR 'SIAS_09002' OR 'SIAS_09012' OR 'SIAS_09005' OR 'SIAS_09013' OR 'SIAS_09006' OR 'SIAS_09014' OR 'SIAS_09007' OR 'SIAS_09022' OR 'SIAS_09009' OR 'SIAS_09023' OR 'SIAS_09010' OR 'SIAS_09024' */

            if (AREA_DE_WORK.CODOPE_GERAL.In("SIAS_09001".ToString(), "SIAS_09011".ToString(), "SIAS_09002".ToString(), "SIAS_09012".ToString(), "SIAS_09005".ToString(), "SIAS_09013".ToString(), "SIAS_09006".ToString(), "SIAS_09014".ToString(), "SIAS_09007".ToString(), "SIAS_09022".ToString(), "SIAS_09009".ToString(), "SIAS_09023".ToString(), "SIAS_09010".ToString(), "SIAS_09024".ToString()))
            {

                /*" -2507- IF MOVDEBCE-COD-CONVENIO EQUAL 43350 */

                if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO == 43350)
                {

                    /*" -2509- MOVE LK-SICPW001-COD-DOC-SIACC TO GE420-COD-DOC-SIACC */
                    _.Move(SICPW001.LK_SICPW001_COD_DOC_SIACC, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_DOC_SIACC);

                    /*" -2510- ELSE */
                }
                else
                {


                    /*" -2511- MOVE SPACES TO GE420-COD-DOC-SIACC */
                    _.Move("", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_DOC_SIACC);

                    /*" -2512- MOVE -1 TO WH-DOC-SIACC-NULL */
                    _.Move(-1, WH_DOC_SIACC_NULL);

                    /*" -2513- END-IF */
                }


                /*" -2517- END-IF. */
            }


            /*" -2522- IF CODOPE-GERAL EQUAL 'SIAS_09003' OR 'SIAS_09004' OR 'SIAS_09008' OR 'SIAS_09015' OR 'SIAS_09025' */

            if (AREA_DE_WORK.CODOPE_GERAL.In("SIAS_09003".ToString(), "SIAS_09004".ToString(), "SIAS_09008".ToString(), "SIAS_09015".ToString(), "SIAS_09025".ToString()))
            {

                /*" -2523- MOVE WS-DT-NULL TO GE420-DTA-COMUNIC-SENTEN */
                _.Move(AREA_DE_WORK.WS_DT_NULL, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DTA_COMUNIC_SENTEN);

                /*" -2524- ELSE */
            }
            else
            {


                /*" -2525- PERFORM R2060-MONTA-AGRUPA-PAGTO-SAP THRU R2060-EXIT */

                R2060_MONTA_AGRUPA_PAGTO_SAP(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2060_EXIT*/


                /*" -2527- END-IF. */
            }


            /*" -2528- IF MOVDEBCE-COD-CONVENIO EQUAL 43350 */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO == 43350)
            {

                /*" -2530- MOVE LK-SICPW001-USO-SIACC TO GE420-TXT-EMPRESA-TEXT */
                _.Move(SICPW001.LK_SICPW001_USO_SIACC, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_TXT_EMPRESA.GE420_TXT_EMPRESA_TEXT);

                /*" -2533- INSPECT FUNCTION REVERSE(GE420-TXT-EMPRESA-TEXT) TALLYING GE420-TXT-EMPRESA-LEN FOR LEADING SPACES */
                GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_TXT_EMPRESA.GE420_TXT_EMPRESA_LEN.Value = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_TXT_EMPRESA.GE420_TXT_EMPRESA_TEXT.ToString().Reverse().TakeWhile(x => x == ' ').Count();

                /*" -2536- SUBTRACT GE420-TXT-EMPRESA-LEN FROM LENGTH OF GE420-TXT-EMPRESA-TEXT GIVING GE420-TXT-EMPRESA-LEN */
                GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_TXT_EMPRESA.GE420_TXT_EMPRESA_LEN.Value = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_TXT_EMPRESA.GE420_TXT_EMPRESA_TEXT.Value.Length - GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_TXT_EMPRESA.GE420_TXT_EMPRESA_LEN;

                /*" -2550- END-IF. */
            }


            /*" -2561- IF MOVDEBCE-COD-CONVENIO EQUAL 43350 */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO == 43350)
            {

                /*" -2562- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'LIB' */

                if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "LIB")
                {

                    /*" -2563- MOVE 'G' TO GE420-IND-FORMA-PAG-COB */
                    _.Move("G", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_IND_FORMA_PAG_COB);

                    /*" -2564- ELSE */
                }
                else
                {


                    /*" -2565- MOVE 'O' TO GE420-IND-FORMA-PAG-COB */
                    _.Move("O", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_IND_FORMA_PAG_COB);

                    /*" -2566- END-IF */
                }


                /*" -2568- ELSE */
            }
            else
            {


                /*" -2569- IF MOVDEBCE-COD-CONVENIO EQUAL 921286 */

                if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO == 921286)
                {

                    /*" -2570- MOVE '0' TO GE420-IND-FORMA-PAG-COB */
                    _.Move("0", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_IND_FORMA_PAG_COB);

                    /*" -2572- ELSE */
                }
                else
                {


                    /*" -2573- IF MOVDEBCE-COD-CONVENIO EQUAL 600119 OR 600120 OR 600123 */

                    if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.In("600119", "600120", "600123"))
                    {

                        /*" -2574- MOVE 'I' TO GE420-IND-FORMA-PAG-COB */
                        _.Move("I", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_IND_FORMA_PAG_COB);

                        /*" -2576- ELSE */
                    }
                    else
                    {


                        /*" -2577- IF MOVDEBCE-COD-CONVENIO EQUAL 600128 */

                        if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO == 600128)
                        {

                            /*" -2578- MOVE 'I' TO GE420-IND-FORMA-PAG-COB */
                            _.Move("I", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_IND_FORMA_PAG_COB);

                            /*" -2579- ELSE */
                        }
                        else
                        {


                            /*" -2580- MOVE ' ' TO GE420-IND-FORMA-PAG-COB */
                            _.Move(" ", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_IND_FORMA_PAG_COB);

                            /*" -2584- END-IF. */
                        }

                    }

                }

            }


            /*" -2588- MOVE SINISHIS-COD-USUARIO TO GE420-COD-USUARIO-LIB. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_USUARIO, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_USUARIO_LIB);

            /*" -2589- MOVE 'NAO' TO W-CHAVE-ACHOU-NOTA-FISCAL */
            _.Move("NAO", AREA_DE_WORK.W_CHAVE_ACHOU_NOTA_FISCAL);

            /*" -2591- PERFORM R2030-PEGA-NOTA-FISCAL THRU R2030-EXIT */

            R2030_PEGA_NOTA_FISCAL(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R2030_EXIT*/


            /*" -2592- IF W-CHAVE-ACHOU-NOTA-FISCAL EQUAL 'SIM' */

            if (AREA_DE_WORK.W_CHAVE_ACHOU_NOTA_FISCAL == "SIM")
            {

                /*" -2593- MOVE FIPADOFI-NUM-DOC-FISCAL TO GE420-NUM-DOC-FISCAL */
                _.Move(FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_NUM_DOC_FISCAL, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_DOC_FISCAL);

                /*" -2597- END-IF */
            }


            /*" -2598- IF W-CHAVE-ACHOU-NOTA-FISCAL EQUAL 'SIM' */

            if (AREA_DE_WORK.W_CHAVE_ACHOU_NOTA_FISCAL == "SIM")
            {

                /*" -2600- IF FIPADOFI-DATA-EMISSAO-DOC EQUAL SPACES OR LOW-VALUES */

                if (FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_DATA_EMISSAO_DOC.IsLowValues())
                {

                    /*" -2601- MOVE '1212-12-12' TO GE420-DTA-NOTA-FISCAL */
                    _.Move("1212-12-12", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DTA_NOTA_FISCAL);

                    /*" -2602- ELSE */
                }
                else
                {


                    /*" -2604- MOVE FIPADOFI-DATA-EMISSAO-DOC TO GE420-DTA-NOTA-FISCAL */
                    _.Move(FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_DATA_EMISSAO_DOC, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DTA_NOTA_FISCAL);

                    /*" -2605- END-IF */
                }


                /*" -2606- ELSE */
            }
            else
            {


                /*" -2607- MOVE '1212-12-12' TO GE420-DTA-NOTA-FISCAL */
                _.Move("1212-12-12", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DTA_NOTA_FISCAL);

                /*" -2611- END-IF. */
            }


            /*" -2614- MOVE MOVDEBCE-DATA-VENCIMENTO TO GE420-DTA-SOL-PAGTO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DTA_SOL_PAGTO);

            /*" -2618- MOVE SINISHIS-VAL-OPERACAO TO GE420-VLR-PAGTO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_VLR_PAGTO);

            /*" -2622- MOVE MOVDEBCE-COD-CONVENIO TO GE420-COD-CONVENIO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_CONVENIO);

            /*" -2623- IF (MOVDEBCE-COD-CONVENIO EQUAL 43350) */

            if ((MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO == 43350))
            {

                /*" -2624- MOVE 'A' TO GE420-IND-TP-CONVENIO */
                _.Move("A", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_IND_TP_CONVENIO);

                /*" -2625- ELSE */
            }
            else
            {


                /*" -2626- IF (MOVDEBCE-COD-CONVENIO EQUAL 921286) */

                if ((MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO == 921286))
                {

                    /*" -2627- MOVE ' ' TO GE420-IND-TP-CONVENIO */
                    _.Move(" ", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_IND_TP_CONVENIO);

                    /*" -2628- MOVE -1 TO WH-TP-CONVENIO-NULL */
                    _.Move(-1, WH_TP_CONVENIO_NULL);

                    /*" -2629- ELSE */
                }
                else
                {


                    /*" -2630- MOVE 'B' TO GE420-IND-TP-CONVENIO */
                    _.Move("B", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_IND_TP_CONVENIO);

                    /*" -2631- END-IF */
                }


                /*" -2639- END-IF. */
            }


            /*" -2640- MOVE 'NAO' TO W-CHAVE-ACHOU-FORNECEDOR */
            _.Move("NAO", AREA_DE_WORK.W_CHAVE_ACHOU_FORNECEDOR);

            /*" -2641- PERFORM R2040-PEGA-SERVICO THRU R2040-EXIT */

            R2040_PEGA_SERVICO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R2040_EXIT*/


            /*" -2642- IF W-CHAVE-ACHOU-FORNECEDOR EQUAL 'SIM' */

            if (AREA_DE_WORK.W_CHAVE_ACHOU_FORNECEDOR == "SIM")
            {

                /*" -2644- IF SINISCAP-COD-NAT-RENDIMENTO = 0 OR W-CHAVE-TEM-CAPA-LOTE = 'NAO' */

                if (SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_NAT_RENDIMENTO == 0 || AREA_DE_WORK.W_CHAVE_TEM_CAPA_LOTE == "NAO")
                {

                    /*" -2645- EVALUATE FORNECED-COD-SERVICO-ISS */
                    switch (FORNECED.DCLFORNECEDORES.FORNECED_COD_SERVICO_ISS.Value)
                    {

                        /*" -2646- WHEN 20 */
                        case 20:

                            /*" -2647- MOVE 1709 TO GE420-COD-SERVICO-SAP */
                            _.Move(1709, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_SERVICO_SAP);

                            /*" -2648- WHEN 92 */
                            break;
                        case 92:

                            /*" -2649- MOVE 0705 TO GE420-COD-SERVICO-SAP */
                            _.Move(0705, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_SERVICO_SAP);

                            /*" -2650- WHEN 93 */
                            break;
                        case 93:

                            /*" -2651- MOVE 1405 TO GE420-COD-SERVICO-SAP */
                            _.Move(1405, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_SERVICO_SAP);

                            /*" -2652- WHEN OTHER */
                            break;
                        default:

                            /*" -2653- MOVE 9999 TO GE420-COD-SERVICO-SAP */
                            _.Move(9999, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_SERVICO_SAP);

                            /*" -2654- END-EVALUATE */
                            break;
                    }


                    /*" -2655- ELSE */
                }
                else
                {


                    /*" -2656- IF SINISCAP-COD-SERVICO-CONTABIL(01:4) NOT EQUAL SPACES */

                    if (SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_SERVICO_CONTABIL.Substring(01, 4) != string.Empty)
                    {

                        /*" -2658- MOVE SINISCAP-COD-SERVICO-CONTABIL(01:4) TO GE420-COD-SERVICO-SAP */
                        _.Move(SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_SERVICO_CONTABIL.Substring(1, 4), GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_SERVICO_SAP);

                        /*" -2659- ELSE */
                    }
                    else
                    {


                        /*" -2660- MOVE -1 TO WH-SERVICO-SAP-NULL */
                        _.Move(-1, WH_SERVICO_SAP_NULL);

                        /*" -2661- END-IF */
                    }


                    /*" -2662- END-IF */
                }


                /*" -2664- END-IF. */
            }


            /*" -2665- IF W-CHAVE-ACHOU-NOTA-FISCAL EQUAL 'SIM' */

            if (AREA_DE_WORK.W_CHAVE_ACHOU_NOTA_FISCAL == "SIM")
            {

                /*" -2666- IF FIPADOFI-SERIE-DOC-FISCAL NOT EQUAL SPACES */

                if (!FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_SERIE_DOC_FISCAL.IsEmpty())
                {

                    /*" -2668- MOVE FIPADOFI-SERIE-DOC-FISCAL(1:5) TO GE420-NUM-SERIE-DOC-FISCAL */
                    _.Move(FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_SERIE_DOC_FISCAL.Substring(1, 5), GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_SERIE_DOC_FISCAL);

                    /*" -2669- ELSE */
                }
                else
                {


                    /*" -2670- MOVE -1 TO WH-SERIE-DOC-FISCAL-NULL */
                    _.Move(-1, WH_SERIE_DOC_FISCAL_NULL);

                    /*" -2671- END-IF */
                }


                /*" -2673- END-IF. */
            }


            /*" -2674- MOVE 'NAO' TO W-CHAVE-ACHOU-FONTE-IMPOSTO. */
            _.Move("NAO", AREA_DE_WORK.W_CHAVE_ACHOU_FONTE_IMPOSTO);

            /*" -2675- PERFORM R2050-FONTE-RECOLHE-IMPOSTO THRU R2050-EXIT */

            R2050_FONTE_RECOLHE_IMPOSTO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R2050_EXIT*/


            /*" -2676- IF W-CHAVE-ACHOU-FONTE-IMPOSTO EQUAL 'SIM' */

            if (AREA_DE_WORK.W_CHAVE_ACHOU_FONTE_IMPOSTO == "SIM")
            {

                /*" -2677- MOVE CEPFXFIL-FONTE TO GE420-COD-FONTE-ISS */
                _.Move(CEPFXFIL.DCLCEPFAIXAFILIAL.CEPFXFIL_FONTE, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_FONTE_ISS);

                /*" -2678- ELSE */
            }
            else
            {


                /*" -2679- MOVE -1 TO WH-FONTE-ISS-NULL */
                _.Move(-1, WH_FONTE_ISS_NULL);

                /*" -2683- END-IF. */
            }


            /*" -2684- IF SINISCAP-NUM-CPF-CNPJ-TOMADOR NOT EQUAL ZEROS */

            if (SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_NUM_CPF_CNPJ_TOMADOR != 00)
            {

                /*" -2686- MOVE SINISCAP-NUM-CPF-CNPJ-TOMADOR TO GE420-NUM-CPF-CNPJ-TOMADOR */
                _.Move(SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_NUM_CPF_CNPJ_TOMADOR, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_CPF_CNPJ_TOMADOR);

                /*" -2687- ELSE */
            }
            else
            {


                /*" -2688- MOVE -1 TO WH-CPF-CNPJ-TOMADOR-NULL */
                _.Move(-1, WH_CPF_CNPJ_TOMADOR_NULL);

                /*" -2688- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3500_EXIT*/

        [StopWatch]
        /*" R3550-MONTA-CODV-PAGTO-MOD-AP */
        private void R3550_MONTA_CODV_PAGTO_MOD_AP(bool isPerform = false)
        {
            /*" -2708- DISPLAY 'R3550-MONTA-CODV-PAGTO-MOD-AP' */
            _.Display($"R3550-MONTA-CODV-PAGTO-MOD-AP");

            /*" -2711- IF SINISHIS-COD-OPERACAO EQUAL 4294 OR W-CHAVE-EH-PRESTADOR EQUAL 'NAO' */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO == 4294 || AREA_DE_WORK.W_CHAVE_EH_PRESTADOR == "NAO")
            {

                /*" -2712- GO TO R3550-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3550_EXIT*/ //GOTO
                return;

                /*" -2718- END-IF. */
            }


            /*" -2719- MOVE 'NAO' TO W-CHAVE-TEM-IMPOSTOS. */
            _.Move("NAO", AREA_DE_WORK.W_CHAVE_TEM_IMPOSTOS);

            /*" -2721- MOVE 'NAO' TO WFIM-IMPOSTOS. */
            _.Move("NAO", AREA_DE_WORK.WFIM_IMPOSTOS);

            /*" -2722- PERFORM R4000-DECLARE-IMPOSTOS THRU R4000-EXIT. */

            R4000_DECLARE_IMPOSTOS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_EXIT*/


            /*" -2724- PERFORM R4001-FETCH-IMPOSTOS THRU R4001-EXIT. */

            R4001_FETCH_IMPOSTOS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R4001_EXIT*/


            /*" -2725- PERFORM R4010-PROCESSA-IMPOSTOS THRU R4010-EXIT UNTIL WFIM-IMPOSTOS EQUAL 'SIM' . */

            while (!(AREA_DE_WORK.WFIM_IMPOSTOS == "SIM"))
            {

                R4010_PROCESSA_IMPOSTOS(true);

                R4010_10_GRAVA(true);

                R4010_20_IGNORA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R4010_EXIT*/

            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3550_EXIT*/

        [StopWatch]
        /*" R4000-DECLARE-IMPOSTOS */
        private void R4000_DECLARE_IMPOSTOS(bool isPerform = false)
        {
            /*" -2734- DISPLAY 'R4000-DECLARE-IMPOSTOS' */
            _.Display($"R4000-DECLARE-IMPOSTOS");

            /*" -2735- INITIALIZE DCLSI-PAGA-DOC-FISCAL */
            _.Initialize(
                SIPADOFI.DCLSI_PAGA_DOC_FISCAL
            );

            /*" -2736- INITIALIZE DCLGE-TP-LANC-DOCF */
            _.Initialize(
                GETPLADO.DCLGE_TP_LANC_DOCF
            );

            /*" -2737- INITIALIZE DCLFI-PAGA-DOCF-LANC */
            _.Initialize(
                FIPADOLA.DCLFI_PAGA_DOCF_LANC
            );

            /*" -2738- INITIALIZE DCLGE-TIPO-IMPOSTO */
            _.Initialize(
                GETIPIMP.DCLGE_TIPO_IMPOSTO
            );

            /*" -2743- INITIALIZE DCLFI-PAGA-DOCF-IMP */
            _.Initialize(
                FIPADOIM.DCLFI_PAGA_DOCF_IMP
            );

            /*" -2783- PERFORM R4000_DECLARE_IMPOSTOS_DB_DECLARE_1 */

            R4000_DECLARE_IMPOSTOS_DB_DECLARE_1();

            /*" -2785- PERFORM R4000_DECLARE_IMPOSTOS_DB_OPEN_1 */

            R4000_DECLARE_IMPOSTOS_DB_OPEN_1();

            /*" -2788- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -2789- DISPLAY 'SICP001S- ERRO CURSOR IMPOSTOS' */
                _.Display($"SICP001S- ERRO CURSOR IMPOSTOS");

                /*" -2789- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4000-DECLARE-IMPOSTOS-DB-OPEN-1 */
        public void R4000_DECLARE_IMPOSTOS_DB_OPEN_1()
        {
            /*" -2785- EXEC SQL OPEN IMPOSTOS END-EXEC. */

            IMPOSTOS.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_EXIT*/

        [StopWatch]
        /*" R4001-FETCH-IMPOSTOS */
        private void R4001_FETCH_IMPOSTOS(bool isPerform = false)
        {
            /*" -2797- DISPLAY 'R4100-FETCH-IMPOSTOS' */
            _.Display($"R4100-FETCH-IMPOSTOS");

            /*" -2810- PERFORM R4001_FETCH_IMPOSTOS_DB_FETCH_1 */

            R4001_FETCH_IMPOSTOS_DB_FETCH_1();

            /*" -2813- IF SQLCODE EQUAL 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -2815- MOVE 'SIM' TO W-CHAVE-TEM-IMPOSTOS. */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_TEM_IMPOSTOS);
            }


            /*" -2816- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2816- PERFORM R4001_FETCH_IMPOSTOS_DB_CLOSE_1 */

                R4001_FETCH_IMPOSTOS_DB_CLOSE_1();

                /*" -2818- MOVE 'SIM' TO WFIM-IMPOSTOS */
                _.Move("SIM", AREA_DE_WORK.WFIM_IMPOSTOS);

                /*" -2820- GO TO R4001-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R4001_EXIT*/ //GOTO
                return;
            }


            /*" -2821- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -2822- DISPLAY 'SICP001S- ERRO NO FETCH CURSOR IMPOSTOS' */
                _.Display($"SICP001S- ERRO NO FETCH CURSOR IMPOSTOS");

                /*" -2823- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -2825- END-IF. */
            }


            /*" -2825- PERFORM R8889-DISPLAY-IMPOSTOS. */

            R8889_DISPLAY_IMPOSTOS(true);

        }

        [StopWatch]
        /*" R4001-FETCH-IMPOSTOS-DB-FETCH-1 */
        public void R4001_FETCH_IMPOSTOS_DB_FETCH_1()
        {
            /*" -2810- EXEC SQL FETCH IMPOSTOS INTO :SINISHIS-NUM-APOL-SINISTRO ,:SINISHIS-OCORR-HISTORICO ,:SINISHIS-COD-OPERACAO ,:SIPADOFI-NUM-DOCF-INTERNO ,:FIPADOLA-COD-TP-LANCDOCF ,:GETPLADO-ABREV-LANCDOCF ,:FIPADOLA-VALOR-LANCAMENTO ,:GETIPIMP-COD-IMP-INTERNO ,:GETIPIMP-SIGLA-IMP ,:FIPADOIM-ALIQ-TRIBUTACAO ,:FIPADOIM-VALOR-IMPOSTO ,:FIPADOIM-COD-IMPOSTO-SAP:FIPADOIM-COD-IMPOSTO-SAP-NN END-EXEC. */

            if (IMPOSTOS.Fetch())
            {
                _.Move(IMPOSTOS.SINISHIS_NUM_APOL_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO);
                _.Move(IMPOSTOS.SINISHIS_OCORR_HISTORICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO);
                _.Move(IMPOSTOS.SINISHIS_COD_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);
                _.Move(IMPOSTOS.SIPADOFI_NUM_DOCF_INTERNO, SIPADOFI.DCLSI_PAGA_DOC_FISCAL.SIPADOFI_NUM_DOCF_INTERNO);
                _.Move(IMPOSTOS.FIPADOLA_COD_TP_LANCDOCF, FIPADOLA.DCLFI_PAGA_DOCF_LANC.FIPADOLA_COD_TP_LANCDOCF);
                _.Move(IMPOSTOS.GETPLADO_ABREV_LANCDOCF, GETPLADO.DCLGE_TP_LANC_DOCF.GETPLADO_ABREV_LANCDOCF);
                _.Move(IMPOSTOS.FIPADOLA_VALOR_LANCAMENTO, FIPADOLA.DCLFI_PAGA_DOCF_LANC.FIPADOLA_VALOR_LANCAMENTO);
                _.Move(IMPOSTOS.GETIPIMP_COD_IMP_INTERNO, GETIPIMP.DCLGE_TIPO_IMPOSTO.GETIPIMP_COD_IMP_INTERNO);
                _.Move(IMPOSTOS.GETIPIMP_SIGLA_IMP, GETIPIMP.DCLGE_TIPO_IMPOSTO.GETIPIMP_SIGLA_IMP);
                _.Move(IMPOSTOS.FIPADOIM_ALIQ_TRIBUTACAO, FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_ALIQ_TRIBUTACAO);
                _.Move(IMPOSTOS.FIPADOIM_VALOR_IMPOSTO, FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_VALOR_IMPOSTO);
                _.Move(IMPOSTOS.FIPADOIM_COD_IMPOSTO_SAP, FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_COD_IMPOSTO_SAP);
                _.Move(IMPOSTOS.FIPADOIM_COD_IMPOSTO_SAP_NN, FIPADOIM_COD_IMPOSTO_SAP_NN);
            }

        }

        [StopWatch]
        /*" R4001-FETCH-IMPOSTOS-DB-CLOSE-1 */
        public void R4001_FETCH_IMPOSTOS_DB_CLOSE_1()
        {
            /*" -2816- EXEC SQL CLOSE IMPOSTOS END-EXEC */

            IMPOSTOS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4001_EXIT*/

        [StopWatch]
        /*" R4010-PROCESSA-IMPOSTOS */
        private void R4010_PROCESSA_IMPOSTOS(bool isPerform = false)
        {
            /*" -2847- DISPLAY 'R4010-PROCESSA-IMPOSTOS' */
            _.Display($"R4010-PROCESSA-IMPOSTOS");

            /*" -2849- INITIALIZE DCLGE-MOVTO-TRIBUTO. */
            _.Initialize(
                GE419.DCLGE_MOVTO_TRIBUTO
            );

            /*" -2850- MOVE GE420-NUM-SINISTRO TO WS-APOLICE-ED. */
            _.Move(GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_SINISTRO, AREA_DE_WORK.WS_APOLICE_ED);

            /*" -2851- MOVE GE420-COD-OPERACAO TO WS-OPERACAO-ED. */
            _.Move(GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_OPERACAO, AREA_DE_WORK.WS_OPERACAO_ED);

            /*" -2853- MOVE GE420-NUM-OCORR-HISTORICO TO WS-SMALLINT(02). */
            _.Move(GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_OCORR_HISTORICO, AREA_DE_WORK.WS_SMALLINT[02]);

            /*" -2856- MOVE GETIPIMP-COD-IMP-INTERNO TO WS-SMALLINT(01). */
            _.Move(GETIPIMP.DCLGE_TIPO_IMPOSTO.GETIPIMP_COD_IMP_INTERNO, AREA_DE_WORK.WS_SMALLINT[01]);

            /*" -2860- MOVE GETIPIMP-COD-IMP-INTERNO TO GE419-COD-IMPOSTO-INTERNO */
            _.Move(GETIPIMP.DCLGE_TIPO_IMPOSTO.GETIPIMP_COD_IMP_INTERNO, GE419.DCLGE_MOVTO_TRIBUTO.GE419_COD_IMPOSTO_INTERNO);

            /*" -2861- IF GETIPIMP-COD-IMP-INTERNO EQUAL 1 */

            if (GETIPIMP.DCLGE_TIPO_IMPOSTO.GETIPIMP_COD_IMP_INTERNO == 1)
            {

                /*" -2862- EVALUATE W-CHAVE-TIPO-PESSOA-PF-PJ */
                switch (AREA_DE_WORK.W_CHAVE_TIPO_PESSOA_PF_PJ.Value.Trim())
                {

                    /*" -2864- WHEN 'PF' */
                    case "PF":

                        /*" -2865- MOVE 'S1' TO GE419-COD-TRIBUTO-SAP */
                        _.Move("S1", GE419.DCLGE_MOVTO_TRIBUTO.GE419_COD_TRIBUTO_SAP);

                        /*" -2867- WHEN 'PJ' */
                        break;
                    case "PJ":

                        /*" -2868- IF FIPADOIM-ALIQ-TRIBUTACAO EQUAL 1,00000 */

                        if (FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_ALIQ_TRIBUTACAO == 1.00000)
                        {

                            /*" -2869- MOVE 'J2' TO GE419-COD-TRIBUTO-SAP */
                            _.Move("J2", GE419.DCLGE_MOVTO_TRIBUTO.GE419_COD_TRIBUTO_SAP);

                            /*" -2870- ELSE */
                        }
                        else
                        {


                            /*" -2871- MOVE 'J1' TO GE419-COD-TRIBUTO-SAP */
                            _.Move("J1", GE419.DCLGE_MOVTO_TRIBUTO.GE419_COD_TRIBUTO_SAP);

                            /*" -2872- END-IF */
                        }


                        /*" -2873- WHEN OTHER */
                        break;
                    default:

                        /*" -2875- DISPLAY 'SICP001S- NAO FOI POSSIVEL ' 'GRAVAR TRIBUTO #1' */
                        _.Display($"SICP001S- NAO FOI POSSIVEL GRAVAR TRIBUTO #1");

                        /*" -2876- DISPLAY 'SINISTRO:   ' WS-APOLICE-ED */
                        _.Display($"SINISTRO:   {AREA_DE_WORK.WS_APOLICE_ED}");

                        /*" -2877- DISPLAY 'OPERACAO:   ' WS-OPERACAO-ED */
                        _.Display($"OPERACAO:   {AREA_DE_WORK.WS_OPERACAO_ED}");

                        /*" -2878- DISPLAY 'OCORR-HIST: ' WS-SMALLINT(02) */
                        _.Display($"OCORR-HIST: {AREA_DE_WORK.WS_SMALLINT[2]}");

                        /*" -2879- DISPLAY 'TRIBUTO:    ' WS-SMALLINT(01) */
                        _.Display($"TRIBUTO:    {AREA_DE_WORK.WS_SMALLINT[1]}");

                        /*" -2880- GO TO R4010-20-IGNORA */

                        R4010_20_IGNORA(); //GOTO
                        return;

                        /*" -2882- END-EVALUATE */
                        break;
                }


                /*" -2884- MOVE FIPADOLA-VALOR-LANCAMENTO TO GE419-VLR-BASE-TRIB */
                _.Move(FIPADOLA.DCLFI_PAGA_DOCF_LANC.FIPADOLA_VALOR_LANCAMENTO, GE419.DCLGE_MOVTO_TRIBUTO.GE419_VLR_BASE_TRIB);

                /*" -2885- GO TO R4010-10-GRAVA */

                R4010_10_GRAVA(); //GOTO
                return;

                /*" -2899- END-IF */
            }


            /*" -2900- IF GETIPIMP-COD-IMP-INTERNO EQUAL 2 */

            if (GETIPIMP.DCLGE_TIPO_IMPOSTO.GETIPIMP_COD_IMP_INTERNO == 2)
            {

                /*" -2902- IF FIPADOLA-VALOR-LANCAMENTO GREATER ZEROS AND W-CHAVE-TEM-CAPA-LOTE = 'SIM' */

                if (FIPADOLA.DCLFI_PAGA_DOCF_LANC.FIPADOLA_VALOR_LANCAMENTO > 00 && AREA_DE_WORK.W_CHAVE_TEM_CAPA_LOTE == "SIM")
                {

                    /*" -2905- MOVE GE612-COD-TP-SERVICO-INSS TO GE420-COD-TP-SERVICO-INSS */
                    _.Move(GE612.DCLGE_TP_SERVICO_INSS.GE612_COD_TP_SERVICO_INSS, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_TP_SERVICO_INSS);

                    /*" -2913- PERFORM P7420-GE3-UPDATE THRU P7420-GE3-EXIT */

                    P7420_GE3_UPDATE(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: P7420_GE3_EXIT*/


                    /*" -2915- END-IF */
                }


                /*" -2916- EVALUATE W-CHAVE-TIPO-PESSOA-PF-PJ */
                switch (AREA_DE_WORK.W_CHAVE_TIPO_PESSOA_PF_PJ.Value.Trim())
                {

                    /*" -2922- WHEN 'PF' */
                    case "PF":

                        /*" -2923- IF FIPADOLA-VALOR-LANCAMENTO GREATER ZEROS */

                        if (FIPADOLA.DCLFI_PAGA_DOCF_LANC.FIPADOLA_VALOR_LANCAMENTO > 00)
                        {

                            /*" -2924- MOVE 'N2' TO GE419-COD-TRIBUTO-SAP */
                            _.Move("N2", GE419.DCLGE_MOVTO_TRIBUTO.GE419_COD_TRIBUTO_SAP);

                            /*" -2927- MOVE FIPADOLA-VALOR-LANCAMENTO TO GE419-VLR-BASE-TRIB */
                            _.Move(FIPADOLA.DCLFI_PAGA_DOCF_LANC.FIPADOLA_VALOR_LANCAMENTO, GE419.DCLGE_MOVTO_TRIBUTO.GE419_VLR_BASE_TRIB);

                            /*" -2931- PERFORM P7419-GE1-INSERT THRU P7419-GE1-EXIT */

                            P7419_GE1_INSERT(true);
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: P7419_GE1_EXIT*/


                            /*" -2932- MOVE 10 TO GE419-COD-IMPOSTO-INTERNO */
                            _.Move(10, GE419.DCLGE_MOVTO_TRIBUTO.GE419_COD_IMPOSTO_INTERNO);

                            /*" -2933- MOVE 'M1' TO GE419-COD-TRIBUTO-SAP */
                            _.Move("M1", GE419.DCLGE_MOVTO_TRIBUTO.GE419_COD_TRIBUTO_SAP);

                            /*" -2935- END-IF */
                        }


                        /*" -2936- WHEN 'PJ' */
                        break;
                    case "PJ":

                        /*" -2937- IF FIPADOIM-ALIQ-TRIBUTACAO EQUAL 3,5 */

                        if (FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_ALIQ_TRIBUTACAO == 3.5)
                        {

                            /*" -2938- MOVE 'N3' TO GE419-COD-TRIBUTO-SAP */
                            _.Move("N3", GE419.DCLGE_MOVTO_TRIBUTO.GE419_COD_TRIBUTO_SAP);

                            /*" -2940- MOVE FIPADOLA-VALOR-LANCAMENTO TO GE419-VLR-BASE-TRIB */
                            _.Move(FIPADOLA.DCLFI_PAGA_DOCF_LANC.FIPADOLA_VALOR_LANCAMENTO, GE419.DCLGE_MOVTO_TRIBUTO.GE419_VLR_BASE_TRIB);

                            /*" -2941- ELSE */
                        }
                        else
                        {


                            /*" -2942- IF FIPADOIM-ALIQ-TRIBUTACAO EQUAL 11 */

                            if (FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_ALIQ_TRIBUTACAO == 11)
                            {

                                /*" -2943- MOVE 'N1' TO GE419-COD-TRIBUTO-SAP */
                                _.Move("N1", GE419.DCLGE_MOVTO_TRIBUTO.GE419_COD_TRIBUTO_SAP);

                                /*" -2945- MOVE FIPADOLA-VALOR-LANCAMENTO TO GE419-VLR-BASE-TRIB */
                                _.Move(FIPADOLA.DCLFI_PAGA_DOCF_LANC.FIPADOLA_VALOR_LANCAMENTO, GE419.DCLGE_MOVTO_TRIBUTO.GE419_VLR_BASE_TRIB);

                                /*" -2946- ELSE */
                            }
                            else
                            {


                                /*" -2948- DISPLAY 'SICP001S- NAO FOI POSSIVEL ' 'GRAVAR TRIBUTO#3' */
                                _.Display($"SICP001S- NAO FOI POSSIVEL GRAVAR TRIBUTO#3");

                                /*" -2949- DISPLAY 'SINISTRO:   ' WS-APOLICE-ED */
                                _.Display($"SINISTRO:   {AREA_DE_WORK.WS_APOLICE_ED}");

                                /*" -2950- DISPLAY 'OPERACAO:   ' WS-OPERACAO-ED */
                                _.Display($"OPERACAO:   {AREA_DE_WORK.WS_OPERACAO_ED}");

                                /*" -2951- DISPLAY 'OCORR-HIST: ' WS-SMALLINT(02) */
                                _.Display($"OCORR-HIST: {AREA_DE_WORK.WS_SMALLINT[2]}");

                                /*" -2952- DISPLAY 'TRIBUTO:    ' WS-SMALLINT(01) */
                                _.Display($"TRIBUTO:    {AREA_DE_WORK.WS_SMALLINT[1]}");

                                /*" -2953- GO TO R4010-20-IGNORA */

                                R4010_20_IGNORA(); //GOTO
                                return;

                                /*" -2954- END-IF */
                            }


                            /*" -2956- END-IF */
                        }


                        /*" -2957- WHEN OTHER */
                        break;
                    default:

                        /*" -2958- GO TO R4010-20-IGNORA */

                        R4010_20_IGNORA(); //GOTO
                        return;

                        /*" -2959- END-EVALUATE */
                        break;
                }


                /*" -2966- END-IF. */
            }


            /*" -2967- IF GETIPIMP-COD-IMP-INTERNO EQUAL 3 */

            if (GETIPIMP.DCLGE_TIPO_IMPOSTO.GETIPIMP_COD_IMP_INTERNO == 3)
            {

                /*" -2968- IF FIPADOIM-COD-IMPOSTO-SAP-NN >= 0 */

                if (FIPADOIM_COD_IMPOSTO_SAP_NN >= 0)
                {

                    /*" -2969- MOVE FIPADOIM-COD-IMPOSTO-SAP TO GE419-COD-TRIBUTO-SAP */
                    _.Move(FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_COD_IMPOSTO_SAP, GE419.DCLGE_MOVTO_TRIBUTO.GE419_COD_TRIBUTO_SAP);

                    /*" -2970- ELSE */
                }
                else
                {


                    /*" -2971- GO TO R4010-20-IGNORA */

                    R4010_20_IGNORA(); //GOTO
                    return;

                    /*" -2972- END-IF */
                }


                /*" -2973- IF FIPADOIM-ALIQ-TRIBUTACAO NOT EQUAL ZEROS */

                if (FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_ALIQ_TRIBUTACAO != 00)
                {

                    /*" -2974- MOVE FIPADOLA-VALOR-LANCAMENTO TO GE419-VLR-BASE-TRIB */
                    _.Move(FIPADOLA.DCLFI_PAGA_DOCF_LANC.FIPADOLA_VALOR_LANCAMENTO, GE419.DCLGE_MOVTO_TRIBUTO.GE419_VLR_BASE_TRIB);

                    /*" -2975- ELSE */
                }
                else
                {


                    /*" -2976- GO TO R4010-20-IGNORA */

                    R4010_20_IGNORA(); //GOTO
                    return;

                    /*" -2977- END-IF */
                }


                /*" -2983- END-IF. */
            }


            /*" -2984- IF GETIPIMP-COD-IMP-INTERNO EQUAL 7 */

            if (GETIPIMP.DCLGE_TIPO_IMPOSTO.GETIPIMP_COD_IMP_INTERNO == 7)
            {

                /*" -2985- IF FIPADOIM-VALOR-IMPOSTO EQUAL 0 */

                if (FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_VALOR_IMPOSTO == 0)
                {

                    /*" -2986- MOVE 'I1' TO GE419-COD-TRIBUTO-SAP */
                    _.Move("I1", GE419.DCLGE_MOVTO_TRIBUTO.GE419_COD_TRIBUTO_SAP);

                    /*" -2987- ELSE */
                }
                else
                {


                    /*" -2988- MOVE 'I2' TO GE419-COD-TRIBUTO-SAP */
                    _.Move("I2", GE419.DCLGE_MOVTO_TRIBUTO.GE419_COD_TRIBUTO_SAP);

                    /*" -2989- END-IF */
                }


                /*" -2990- MOVE FIPADOLA-VALOR-LANCAMENTO TO GE419-VLR-BASE-TRIB */
                _.Move(FIPADOLA.DCLFI_PAGA_DOCF_LANC.FIPADOLA_VALOR_LANCAMENTO, GE419.DCLGE_MOVTO_TRIBUTO.GE419_VLR_BASE_TRIB);

                /*" -2995- END-IF. */
            }


            /*" -2996- IF GETIPIMP-COD-IMP-INTERNO EQUAL 8 */

            if (GETIPIMP.DCLGE_TIPO_IMPOSTO.GETIPIMP_COD_IMP_INTERNO == 8)
            {

                /*" -2997- IF FIPADOIM-VALOR-IMPOSTO EQUAL 0 */

                if (FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_VALOR_IMPOSTO == 0)
                {

                    /*" -2998- MOVE 'I6' TO GE419-COD-TRIBUTO-SAP */
                    _.Move("I6", GE419.DCLGE_MOVTO_TRIBUTO.GE419_COD_TRIBUTO_SAP);

                    /*" -2999- ELSE */
                }
                else
                {


                    /*" -3000- MOVE 'I5' TO GE419-COD-TRIBUTO-SAP */
                    _.Move("I5", GE419.DCLGE_MOVTO_TRIBUTO.GE419_COD_TRIBUTO_SAP);

                    /*" -3001- END-IF */
                }


                /*" -3002- MOVE FIPADOLA-VALOR-LANCAMENTO TO GE419-VLR-BASE-TRIB */
                _.Move(FIPADOLA.DCLFI_PAGA_DOCF_LANC.FIPADOLA_VALOR_LANCAMENTO, GE419.DCLGE_MOVTO_TRIBUTO.GE419_VLR_BASE_TRIB);

                /*" -3007- END-IF. */
            }


            /*" -3008- IF GETIPIMP-COD-IMP-INTERNO EQUAL 9 */

            if (GETIPIMP.DCLGE_TIPO_IMPOSTO.GETIPIMP_COD_IMP_INTERNO == 9)
            {

                /*" -3009- IF FIPADOIM-VALOR-IMPOSTO EQUAL 0 */

                if (FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_VALOR_IMPOSTO == 0)
                {

                    /*" -3010- MOVE 'I4' TO GE419-COD-TRIBUTO-SAP */
                    _.Move("I4", GE419.DCLGE_MOVTO_TRIBUTO.GE419_COD_TRIBUTO_SAP);

                    /*" -3011- ELSE */
                }
                else
                {


                    /*" -3012- MOVE 'I3' TO GE419-COD-TRIBUTO-SAP */
                    _.Move("I3", GE419.DCLGE_MOVTO_TRIBUTO.GE419_COD_TRIBUTO_SAP);

                    /*" -3013- END-IF */
                }


                /*" -3014- MOVE FIPADOLA-VALOR-LANCAMENTO TO GE419-VLR-BASE-TRIB */
                _.Move(FIPADOLA.DCLFI_PAGA_DOCF_LANC.FIPADOLA_VALOR_LANCAMENTO, GE419.DCLGE_MOVTO_TRIBUTO.GE419_VLR_BASE_TRIB);

                /*" -3014- END-IF. */
            }


        }

        [StopWatch]
        /*" R4010-10-GRAVA */
        private void R4010_10_GRAVA(bool isPerform = false)
        {
            /*" -3019- PERFORM P7419-GE1-INSERT THRU P7419-GE1-EXIT. */

            P7419_GE1_INSERT(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: P7419_GE1_EXIT*/


        }

        [StopWatch]
        /*" R4010-20-IGNORA */
        private void R4010_20_IGNORA(bool isPerform = false)
        {
            /*" -3023- PERFORM R4001-FETCH-IMPOSTOS THRU R4001-EXIT. */

            R4001_FETCH_IMPOSTOS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R4001_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4010_EXIT*/

        [StopWatch]
        /*" R5000-SELECT-DOC-FISCAL */
        private void R5000_SELECT_DOC_FISCAL(bool isPerform = false)
        {
            /*" -3033- DISPLAY 'R5000-SELECT-DOC-FISCAL' */
            _.Display($"R5000-SELECT-DOC-FISCAL");

            /*" -3035- INITIALIZE DCLFI-PAGA-DOC-FISCAL */
            _.Initialize(
                FIPADOFI.DCLFI_PAGA_DOC_FISCAL
            );

            /*" -3037- MOVE 'NAO' TO W-CHAVE-TEM-NOTA-FISCAL */
            _.Move("NAO", AREA_DE_WORK.W_CHAVE_TEM_NOTA_FISCAL);

            /*" -3052- PERFORM R5000_SELECT_DOC_FISCAL_DB_SELECT_1 */

            R5000_SELECT_DOC_FISCAL_DB_SELECT_1();

            /*" -3055- EVALUATE SQLCODE */
            switch (DB.SQLCODE.Value)
            {

                /*" -3056- WHEN 0 */
                case 0:

                    /*" -3057- MOVE 'SIM' TO W-CHAVE-TEM-NOTA-FISCAL */
                    _.Move("SIM", AREA_DE_WORK.W_CHAVE_TEM_NOTA_FISCAL);

                    /*" -3058- WHEN +100 */
                    break;
                case +100:

                    /*" -3059- MOVE 'NAO' TO W-CHAVE-TEM-NOTA-FISCAL */
                    _.Move("NAO", AREA_DE_WORK.W_CHAVE_TEM_NOTA_FISCAL);

                    /*" -3060- WHEN OTHER */
                    break;
                default:

                    /*" -3061- DISPLAY 'SICP001S- ERRO CONSULTA NOTA FISCAL' */
                    _.Display($"SICP001S- ERRO CONSULTA NOTA FISCAL");

                    /*" -3063- DISPLAY 'NUM_APOL_SINISTRO= ' SINISHIS-NUM-APOL-SINISTRO */
                    _.Display($"NUM_APOL_SINISTRO= {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                    /*" -3066- DISPLAY 'OCORR_HISTORICO  = ' SINISHIS-OCORR-HISTORICO */
                    _.Display($"OCORR_HISTORICO  = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}");

                    /*" -3067- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;

                    /*" -3068- END-EVALUATE */
                    break;
            }


            /*" -3068- . */

        }

        [StopWatch]
        /*" R5000-SELECT-DOC-FISCAL-DB-SELECT-1 */
        public void R5000_SELECT_DOC_FISCAL_DB_SELECT_1()
        {
            /*" -3052- EXEC SQL SELECT F.NUM_DOC_FISCAL , F.SERIE_DOC_FISCAL , F.DATA_EMISSAO_DOC INTO :FIPADOFI-NUM-DOC-FISCAL:NULL-NUM-DOC-FISCAL ,:FIPADOFI-SERIE-DOC-FISCAL:NULL-SERIE-DOC-FISCAL ,:FIPADOFI-DATA-EMISSAO-DOC:NULL-DATA-EMISSAO-DOC FROM SEGUROS.SI_PAGA_DOC_FISCAL A JOIN SEGUROS.FI_PAGA_DOC_FISCAL F ON F.NUM_DOCF_INTERNO = A.NUM_DOCF_INTERNO WHERE F.NUM_DOC_FISCAL > 0 AND A.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND A.OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO END-EXEC. */

            var r5000_SELECT_DOC_FISCAL_DB_SELECT_1_Query1 = new R5000_SELECT_DOC_FISCAL_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
            };

            var executed_1 = R5000_SELECT_DOC_FISCAL_DB_SELECT_1_Query1.Execute(r5000_SELECT_DOC_FISCAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FIPADOFI_NUM_DOC_FISCAL, FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_NUM_DOC_FISCAL);
                _.Move(executed_1.NULL_NUM_DOC_FISCAL, NULL_NUM_DOC_FISCAL);
                _.Move(executed_1.FIPADOFI_SERIE_DOC_FISCAL, FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_SERIE_DOC_FISCAL);
                _.Move(executed_1.NULL_SERIE_DOC_FISCAL, NULL_SERIE_DOC_FISCAL);
                _.Move(executed_1.FIPADOFI_DATA_EMISSAO_DOC, FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_DATA_EMISSAO_DOC);
                _.Move(executed_1.NULL_DATA_EMISSAO_DOC, NULL_DATA_EMISSAO_DOC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5000_EXIT*/

        [StopWatch]
        /*" R2000-CADASTRAIS-ODS */
        private void R2000_CADASTRAIS_ODS(bool isPerform = false)
        {
            /*" -3078- DISPLAY 'R2000-CADASTRAIS-ODS' */
            _.Display($"R2000-CADASTRAIS-ODS");

            /*" -3177- PERFORM R2000_CADASTRAIS_ODS_DB_SELECT_1 */

            R2000_CADASTRAIS_ODS_DB_SELECT_1();

            /*" -3181- IF SQLCODE EQUAL 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -3183- MOVE 'ODS' TO W-CHAVE-ORIGEM-CADASTRO. */
                _.Move("ODS", AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO);
            }


            /*" -3184- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -3185- DISPLAY 'SICP001S- ERRO ACESSO BASE ODS' */
                _.Display($"SICP001S- ERRO ACESSO BASE ODS");

                /*" -3186- DISPLAY 'SINISTRO ........ ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO ........ {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -3187- DISPLAY 'OCORRHIST ....... ' SINISHIS-OCORR-HISTORICO */
                _.Display($"OCORRHIST ....... {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}");

                /*" -3189- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -3190- IF OD001-IND-PESSOA EQUAL 'F' */

            if (OD001.DCLOD_PESSOA.OD001_IND_PESSOA == "F")
            {

                /*" -3191- MOVE 'PF' TO W-CHAVE-TIPO-PESSOA-PF-PJ */
                _.Move("PF", AREA_DE_WORK.W_CHAVE_TIPO_PESSOA_PF_PJ);

                /*" -3192- ELSE */
            }
            else
            {


                /*" -3193- IF OD001-IND-PESSOA EQUAL 'J' */

                if (OD001.DCLOD_PESSOA.OD001_IND_PESSOA == "J")
                {

                    /*" -3194- MOVE 'PJ' TO W-CHAVE-TIPO-PESSOA-PF-PJ */
                    _.Move("PJ", AREA_DE_WORK.W_CHAVE_TIPO_PESSOA_PF_PJ);

                    /*" -3195- ELSE */
                }
                else
                {


                    /*" -3197- MOVE '??' TO W-CHAVE-TIPO-PESSOA-PF-PJ. */
                    _.Move("??", AREA_DE_WORK.W_CHAVE_TIPO_PESSOA_PF_PJ);
                }

            }


            /*" -3198- MOVE W-NUMERO-CPF-BASE TO W-NUM-CPF-ALFA. */
            _.Move(W_NUMERO_CPF_BASE, AREA_DE_WORK.W_NUM_CPF_ALFA);

            /*" -3200- MOVE W-NUMERO-CNPJ-BASE TO W-NUM-CNPJ-ALFA. */
            _.Move(W_NUMERO_CNPJ_BASE, AREA_DE_WORK.W_NUM_CNPJ_ALFA);

            /*" -3208- IF OD007-COD-CEP(1:1) NOT NUMERIC OR OD007-COD-CEP(2:1) NOT NUMERIC OR OD007-COD-CEP(3:1) NOT NUMERIC OR OD007-COD-CEP(4:1) NOT NUMERIC OR OD007-COD-CEP(5:1) NOT NUMERIC OR OD007-COD-CEP(6:1) NOT NUMERIC OR OD007-COD-CEP(7:1) NOT NUMERIC OR OD007-COD-CEP(8:1) NOT NUMERIC */

            if (!OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_CEP.Substring(1, 1).IsNumeric() || !OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_CEP.Substring(2, 1).IsNumeric() || !OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_CEP.Substring(3, 1).IsNumeric() || !OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_CEP.Substring(4, 1).IsNumeric() || !OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_CEP.Substring(5, 1).IsNumeric() || !OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_CEP.Substring(6, 1).IsNumeric() || !OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_CEP.Substring(7, 1).IsNumeric() || !OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_CEP.Substring(8, 1).IsNumeric())
            {

                /*" -3209- MOVE 99999999 TO OD007-COD-CEP */
                _.Move(99999999, OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_CEP);

                /*" -3210- ELSE */
            }
            else
            {


                /*" -3211- MOVE OD007-COD-CEP TO W-CEP-NUM */
                _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_CEP, AREA_DE_WORK.W_CEP_NUM);

                /*" -3212- MOVE W-CEP-NUMERICO-PARTE1 TO W-CEP-ALFA-PARTE1 */
                _.Move(AREA_DE_WORK.W_CEP_NUMERICO.W_CEP_NUMERICO_PARTE1, AREA_DE_WORK.W_CEP_ALFA.W_CEP_ALFA_PARTE1);

                /*" -3212- MOVE W-CEP-NUMERICO-PARTE2 TO W-CEP-ALFA-PARTE2. */
                _.Move(AREA_DE_WORK.W_CEP_NUMERICO.W_CEP_NUMERICO_PARTE2, AREA_DE_WORK.W_CEP_ALFA.W_CEP_ALFA_PARTE2);
            }


        }

        [StopWatch]
        /*" R2000-CADASTRAIS-ODS-DB-SELECT-1 */
        public void R2000_CADASTRAIS_ODS_DB_SELECT_1()
        {
            /*" -3177- EXEC SQL SELECT H.NUM_APOL_SINISTRO AS "NUM SINISTRO", H.OCORR_HISTORICO AS "OCORRHIST", H.COD_OPERACAO AS "OPERACAO", OPE.FUNCAO_OPERACAO AS "FUNCAO OPERACAO", SUBSTR(OPE.DES_OPERACAO,1,30) AS "NOME OPERACAO", LEGPES.NUM_OCORR_MOVTO AS "NUM_OCORR_MOVTO", LEGPES.NUM_PESSOA AS "NUM. PESSOA", PE.IND_PESSOA AS "TIPO PESSOA", DIGITS(DECIMAL(PF.NUM_CPF,9,0)) ||DIGITS(DECIMAL(PF.NUM_DV_CPF,2,0)) AS "CPF DO FAVORECIDO", SUBSTR(PF.NOM_PESSOA,1,100) AS "NOME_FAVORECIDO", 0 AS "INSCRICAO MUNICIPAL", 0 AS "INSCRICAO ESTADUAL", PF.NUM_INSC_SOCIAL AS "INSCRICAO SOCIAL", PF.NUM_DV_INSC_SOCIAL AS "DV INSCRICAO SOCIAL", DIGITS(DECIMAL(PJ.NUM_CNPJ,8,0)) ||DIGITS(DECIMAL(PJ.NUM_FILIAL,4,0)) ||DIGITS(DECIMAL(PJ.NUM_DV_CNPJ,2,0)) AS "CNPJ DO FAVORECIDO", SUBSTR(PJ.NOM_RAZAO_SOCIAL,1,100) AS "RAZAO SOCIAL", PJ.NUM_INSC_MUNICIPAL AS "INSCRICAO MUNICIPAL", PJ.NUM_INSC_ESTADUAL AS "INSCRICAO ESTADUAL", 0 AS "INSCRICAO SOCIAL", 0 AS "DV INSCRICAO SOCIAL", PESEND.NOM_LOGRADOURO AS "LOGRADOURO", PESEND.DES_NUM_IMOVEL AS "NUM IMOVEL", PESEND.DES_COMPL_ENDERECO AS "COMPLEMENTO", PESEND.NOM_BAIRRO AS "BAIRRO", PESEND.NOM_CIDADE AS "CIDADE", PESEND.COD_CEP AS "CEP", PESEND.COD_UF AS "UF", H.NOME_FAVORECIDO AS "NOME_FAVORECIDO_HIST", OPE.IND_TIPO_FUNCAO AS "TIPO FUNCAO OPERACAO" INTO :SINISHIS-NUM-APOL-SINISTRO, :SINISHIS-OCORR-HISTORICO, :SINISHIS-COD-OPERACAO, :GEOPERAC-FUNCAO-OPERACAO, :GEOPERAC-DES-OPERACAO, :GE368-NUM-OCORR-MOVTO, :GE368-NUM-PESSOA, :OD001-IND-PESSOA, :W-NUMERO-CPF-BASE:NULL-NUM-CPF, :OD002-NOM-PESSOA:NULL-NOM-PESSOA, :W-PF-INSC-PREFEITURA:NULL-PF-INSC-PREFEITURA, :W-PF-INSC-ESTADUAL:NULL-PF-INSC-ESTADUAL, :W-PF-NUM-INSC-SOCIAL:NULL-PF-NUM-INSC-SOCIAL, :W-PF-NUM-DV-INSC-SOCIAL:NULL-PF-NUM-DV-INSC-SOCIAL, :W-NUMERO-CNPJ-BASE:NULL-NUM-CNPJ, :OD003-NOM-RAZAO-SOCIAL:NULL-NOM-RAZAO-SOCIAL, :W-PJ-INSC-PREFEITURA:NULL-PJ-INSC-PREFEITURA, :W-PJ-INSC-ESTADUAL:NULL-PJ-INSC-ESTADUAL, :W-PJ-NUM-INSC-SOCIAL:NULL-PJ-NUM-INSC-SOCIAL, :W-PJ-NUM-DV-INSC-SOCIAL:NULL-PJ-NUM-DV-INSC-SOCIAL, :OD007-NOM-LOGRADOURO:NULL-NOM-LOGRADOURO, :OD007-DES-NUM-IMOVEL:NULL-DES-NUM-IMOVEL, :OD007-DES-COMPL-ENDERECO:NULL-DES-COMPL-ENDERECO, :OD007-NOM-BAIRRO:NULL-NOM-BAIRRO, :OD007-NOM-CIDADE:NULL-NOM-CIDADE, :OD007-COD-CEP:NULL-COD-CEP, :OD007-COD-UF:NULL-COD-UF, :SINISHIS-NOME-FAVORECIDO, :GEOPERAC-IND-TIPO-FUNCAO FROM SEGUROS.SINISTRO_HISTORICO H, SEGUROS.GE_OPERACAO OPE, SEGUROS.SI_PESS_SINISTRO SIPES, SEGUROS.GE_LEG_PESS_EVENTO LEGPES LEFT JOIN ODS.OD_PESSOA PE ON PE.NUM_PESSOA = LEGPES.NUM_PESSOA LEFT JOIN ODS.OD_PESSOA_FISICA PF ON PF.NUM_PESSOA = LEGPES.NUM_PESSOA LEFT JOIN ODS.OD_PESSOA_JURIDICA PJ ON PJ.NUM_PESSOA = LEGPES.NUM_PESSOA LEFT JOIN ODS.OD_PESSOA_ENDERECO PESEND ON PESEND.NUM_PESSOA = LEGPES.NUM_PESSOA AND PESEND.SEQ_ENDERECO = LEGPES.SEQ_ENTIDADE WHERE SIPES.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND SIPES.OCORR_HISTORICO = H.OCORR_HISTORICO AND SIPES.COD_OPERACAO = H.COD_OPERACAO AND LEGPES.NUM_OCORR_MOVTO = SIPES.NUM_OCORR_MOVTO AND LEGPES.IND_ENTIDADE = 1 AND OPE.IDE_SISTEMA = 'SI' AND OPE.COD_OPERACAO = H.COD_OPERACAO AND H.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND H.OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND H.COD_PREST_SERVICO <> 891733 AND H.NOME_FAVORECIDO <> 'CAIXA SEGURADORA S A' END-EXEC. */

            var r2000_CADASTRAIS_ODS_DB_SELECT_1_Query1 = new R2000_CADASTRAIS_ODS_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
            };

            var executed_1 = R2000_CADASTRAIS_ODS_DB_SELECT_1_Query1.Execute(r2000_CADASTRAIS_ODS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISHIS_NUM_APOL_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO);
                _.Move(executed_1.SINISHIS_OCORR_HISTORICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO);
                _.Move(executed_1.SINISHIS_COD_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);
                _.Move(executed_1.GEOPERAC_FUNCAO_OPERACAO, GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO);
                _.Move(executed_1.GEOPERAC_DES_OPERACAO, GEOPERAC.DCLGE_OPERACAO.GEOPERAC_DES_OPERACAO);
                _.Move(executed_1.GE368_NUM_OCORR_MOVTO, GE368.DCLGE_LEG_PESS_EVENTO.GE368_NUM_OCORR_MOVTO);
                _.Move(executed_1.GE368_NUM_PESSOA, GE368.DCLGE_LEG_PESS_EVENTO.GE368_NUM_PESSOA);
                _.Move(executed_1.OD001_IND_PESSOA, OD001.DCLOD_PESSOA.OD001_IND_PESSOA);
                _.Move(executed_1.W_NUMERO_CPF_BASE, W_NUMERO_CPF_BASE);
                _.Move(executed_1.NULL_NUM_CPF, NULL_NUM_CPF);
                _.Move(executed_1.OD002_NOM_PESSOA, OD002.DCLOD_PESSOA_FISICA.OD002_NOM_PESSOA);
                _.Move(executed_1.NULL_NOM_PESSOA, NULL_NOM_PESSOA);
                _.Move(executed_1.W_PF_INSC_PREFEITURA, W_PF_INSC_PREFEITURA);
                _.Move(executed_1.NULL_PF_INSC_PREFEITURA, NULL_PF_INSC_PREFEITURA);
                _.Move(executed_1.W_PF_INSC_ESTADUAL, W_PF_INSC_ESTADUAL);
                _.Move(executed_1.NULL_PF_INSC_ESTADUAL, NULL_PF_INSC_ESTADUAL);
                _.Move(executed_1.W_PF_NUM_INSC_SOCIAL, W_PF_NUM_INSC_SOCIAL);
                _.Move(executed_1.NULL_PF_NUM_INSC_SOCIAL, NULL_PF_NUM_INSC_SOCIAL);
                _.Move(executed_1.W_PF_NUM_DV_INSC_SOCIAL, W_PF_NUM_DV_INSC_SOCIAL);
                _.Move(executed_1.NULL_PF_NUM_DV_INSC_SOCIAL, NULL_PF_NUM_DV_INSC_SOCIAL);
                _.Move(executed_1.W_NUMERO_CNPJ_BASE, W_NUMERO_CNPJ_BASE);
                _.Move(executed_1.NULL_NUM_CNPJ, NULL_NUM_CNPJ);
                _.Move(executed_1.OD003_NOM_RAZAO_SOCIAL, OD003.DCLOD_PESSOA_JURIDICA.OD003_NOM_RAZAO_SOCIAL);
                _.Move(executed_1.NULL_NOM_RAZAO_SOCIAL, NULL_NOM_RAZAO_SOCIAL);
                _.Move(executed_1.W_PJ_INSC_PREFEITURA, W_PJ_INSC_PREFEITURA);
                _.Move(executed_1.NULL_PJ_INSC_PREFEITURA, NULL_PJ_INSC_PREFEITURA);
                _.Move(executed_1.W_PJ_INSC_ESTADUAL, W_PJ_INSC_ESTADUAL);
                _.Move(executed_1.NULL_PJ_INSC_ESTADUAL, NULL_PJ_INSC_ESTADUAL);
                _.Move(executed_1.W_PJ_NUM_INSC_SOCIAL, W_PJ_NUM_INSC_SOCIAL);
                _.Move(executed_1.NULL_PJ_NUM_INSC_SOCIAL, NULL_PJ_NUM_INSC_SOCIAL);
                _.Move(executed_1.W_PJ_NUM_DV_INSC_SOCIAL, W_PJ_NUM_DV_INSC_SOCIAL);
                _.Move(executed_1.NULL_PJ_NUM_DV_INSC_SOCIAL, NULL_PJ_NUM_DV_INSC_SOCIAL);
                _.Move(executed_1.OD007_NOM_LOGRADOURO, OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_LOGRADOURO);
                _.Move(executed_1.NULL_NOM_LOGRADOURO, NULL_NOM_LOGRADOURO);
                _.Move(executed_1.OD007_DES_NUM_IMOVEL, OD007.DCLOD_PESSOA_ENDERECO.OD007_DES_NUM_IMOVEL);
                _.Move(executed_1.NULL_DES_NUM_IMOVEL, NULL_DES_NUM_IMOVEL);
                _.Move(executed_1.OD007_DES_COMPL_ENDERECO, OD007.DCLOD_PESSOA_ENDERECO.OD007_DES_COMPL_ENDERECO);
                _.Move(executed_1.NULL_DES_COMPL_ENDERECO, NULL_DES_COMPL_ENDERECO);
                _.Move(executed_1.OD007_NOM_BAIRRO, OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_BAIRRO);
                _.Move(executed_1.NULL_NOM_BAIRRO, NULL_NOM_BAIRRO);
                _.Move(executed_1.OD007_NOM_CIDADE, OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_CIDADE);
                _.Move(executed_1.NULL_NOM_CIDADE, NULL_NOM_CIDADE);
                _.Move(executed_1.OD007_COD_CEP, OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_CEP);
                _.Move(executed_1.NULL_COD_CEP, NULL_COD_CEP);
                _.Move(executed_1.OD007_COD_UF, OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_UF);
                _.Move(executed_1.NULL_COD_UF, NULL_COD_UF);
                _.Move(executed_1.SINISHIS_NOME_FAVORECIDO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO);
                _.Move(executed_1.GEOPERAC_IND_TIPO_FUNCAO, GEOPERAC.DCLGE_OPERACAO.GEOPERAC_IND_TIPO_FUNCAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_EXIT*/

        [StopWatch]
        /*" R2010-CADASTRAIS-LOTERICO */
        private void R2010_CADASTRAIS_LOTERICO(bool isPerform = false)
        {
            /*" -3222- DISPLAY 'R2010-CADASTRAIS-LOTERICO' */
            _.Display($"R2010-CADASTRAIS-LOTERICO");

            /*" -3226- IF SINISHIS-COD-OPERACAO NOT EQUAL 1070 AND 1071 AND 1072 AND 1073 AND 1074 AND 1170 AND 1171 AND 1172 AND 1173 AND 1174 AND 1030 AND 1040 AND 4000 */

            if (!SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.In("1070", "1071", "1072", "1073", "1074", "1170", "1171", "1172", "1173", "1174", "1030", "1040", "4000"))
            {

                /*" -3230- GO TO R2010-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2010_EXIT*/ //GOTO
                return;
            }


            /*" -3240- PERFORM R2010_CADASTRAIS_LOTERICO_DB_SELECT_1 */

            R2010_CADASTRAIS_LOTERICO_DB_SELECT_1();

            /*" -3243- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3245- GO TO R2010-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2010_EXIT*/ //GOTO
                return;
            }


            /*" -3246- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -3247- DISPLAY 'SICP001S- ERRO ACESSO SINI_LOTERICO01 - 1' */
                _.Display($"SICP001S- ERRO ACESSO SINI_LOTERICO01 - 1");

                /*" -3251- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -3288- PERFORM R2010_CADASTRAIS_LOTERICO_DB_SELECT_2 */

            R2010_CADASTRAIS_LOTERICO_DB_SELECT_2();

            /*" -3291- IF SQLCODE EQUAL 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -3292- MOVE FORNECED-CGCCPF TO W-NUM-CPF-NUM */
                _.Move(FORNECED.DCLFORNECEDORES.FORNECED_CGCCPF, AREA_DE_WORK.W_NUM_CPF_NUM);

                /*" -3293- MOVE FORNECED-CGCCPF TO W-NUM-CNPJ-NUM */
                _.Move(FORNECED.DCLFORNECEDORES.FORNECED_CGCCPF, AREA_DE_WORK.W_NUM_CNPJ_NUM);

                /*" -3295- MOVE 'FORNECEDOR OU LOTERICO' TO W-CHAVE-ORIGEM-CADASTRO. */
                _.Move("FORNECEDOR OU LOTERICO", AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO);
            }


            /*" -3296- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -3297- DISPLAY 'SICP001S- ERRO ACESSO SINI_LOTERICO01 - 2' */
                _.Display($"SICP001S- ERRO ACESSO SINI_LOTERICO01 - 2");

                /*" -3299- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -3300- IF FORNECED-TIPO-PESSOA EQUAL 'F' */

            if (FORNECED.DCLFORNECEDORES.FORNECED_TIPO_PESSOA == "F")
            {

                /*" -3301- MOVE 'PF' TO W-CHAVE-TIPO-PESSOA-PF-PJ */
                _.Move("PF", AREA_DE_WORK.W_CHAVE_TIPO_PESSOA_PF_PJ);

                /*" -3302- ELSE */
            }
            else
            {


                /*" -3303- IF FORNECED-TIPO-PESSOA EQUAL 'J' */

                if (FORNECED.DCLFORNECEDORES.FORNECED_TIPO_PESSOA == "J")
                {

                    /*" -3304- MOVE 'PJ' TO W-CHAVE-TIPO-PESSOA-PF-PJ */
                    _.Move("PJ", AREA_DE_WORK.W_CHAVE_TIPO_PESSOA_PF_PJ);

                    /*" -3305- ELSE */
                }
                else
                {


                    /*" -3307- MOVE '??' TO W-CHAVE-TIPO-PESSOA-PF-PJ. */
                    _.Move("??", AREA_DE_WORK.W_CHAVE_TIPO_PESSOA_PF_PJ);
                }

            }


            /*" -3308- MOVE FORNECED-CEP TO W-CEP-NUM . */
            _.Move(FORNECED.DCLFORNECEDORES.FORNECED_CEP, AREA_DE_WORK.W_CEP_NUM);

            /*" -3309- MOVE W-CEP-NUMERICO-PARTE1 TO W-CEP-ALFA-PARTE1 . */
            _.Move(AREA_DE_WORK.W_CEP_NUMERICO.W_CEP_NUMERICO_PARTE1, AREA_DE_WORK.W_CEP_ALFA.W_CEP_ALFA_PARTE1);

            /*" -3309- MOVE W-CEP-NUMERICO-PARTE2 TO W-CEP-ALFA-PARTE2 . */
            _.Move(AREA_DE_WORK.W_CEP_NUMERICO.W_CEP_NUMERICO_PARTE2, AREA_DE_WORK.W_CEP_ALFA.W_CEP_ALFA_PARTE2);

        }

        [StopWatch]
        /*" R2010-CADASTRAIS-LOTERICO-DB-SELECT-1 */
        public void R2010_CADASTRAIS_LOTERICO_DB_SELECT_1()
        {
            /*" -3240- EXEC SQL SELECT X.NUM_APOL_SINISTRO INTO :SINILT01-NUM-APOL-SINISTRO FROM SEGUROS.SINI_LOTERICO01 X, SEGUROS.SINISTRO_HISTORICO H WHERE H.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND H.OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND H.COD_OPERACAO = :SINISHIS-COD-OPERACAO AND H.COD_PREST_SERVICO = 0 AND X.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO END-EXEC. */

            var r2010_CADASTRAIS_LOTERICO_DB_SELECT_1_Query1 = new R2010_CADASTRAIS_LOTERICO_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
                SINISHIS_COD_OPERACAO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.ToString(),
            };

            var executed_1 = R2010_CADASTRAIS_LOTERICO_DB_SELECT_1_Query1.Execute(r2010_CADASTRAIS_LOTERICO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINILT01_NUM_APOL_SINISTRO, SINILT01.DCLSINI_LOTERICO01.SINILT01_NUM_APOL_SINISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2010_EXIT*/

        [StopWatch]
        /*" R2010-CADASTRAIS-LOTERICO-DB-SELECT-2 */
        public void R2010_CADASTRAIS_LOTERICO_DB_SELECT_2()
        {
            /*" -3288- EXEC SQL SELECT CLI.NOME_RAZAO , CLI.TIPO_PESSOA , CASE CLI.TIPO_PESSOA WHEN 'F' THEN 'PESSOA FISICA  ' WHEN 'J' THEN 'PESSOA JURIDICA' END AS "TIPO DE PESSOA", CLI.CGCCPF AS "CPF / CNPJ DO FAVORECIDO", LOT.ENDERECO , LOT.BAIRRO , LOT.CIDADE , LOT.CEP , LOT.SIGLA_UF INTO :FORNECED-NOME-FORNECEDOR, :FORNECED-TIPO-PESSOA, :W-NOME-TIPO-PESSOA, :FORNECED-CGCCPF, :FORNECED-ENDERECO, :FORNECED-BAIRRO, :FORNECED-CIDADE, :FORNECED-CEP, :FORNECED-SIGLA-UF FROM SEGUROS.SINI_LOTERICO01 X, SEGUROS.LOTERICO01 LOT, SEGUROS.CLIENTES CLI WHERE X.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND LOT.COD_CLIENTE = X.COD_CLIENTE AND CLI.COD_CLIENTE = X.COD_CLIENTE AND LOT.TIMESTAMP = (SELECT MAX(ZZ.TIMESTAMP) FROM SEGUROS.SINI_LOTERICO01 XX, SEGUROS.LOTERICO01 ZZ WHERE XX.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND ZZ.COD_CLIENTE = XX.COD_CLIENTE ) END-EXEC. */

            var r2010_CADASTRAIS_LOTERICO_DB_SELECT_2_Query1 = new R2010_CADASTRAIS_LOTERICO_DB_SELECT_2_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R2010_CADASTRAIS_LOTERICO_DB_SELECT_2_Query1.Execute(r2010_CADASTRAIS_LOTERICO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FORNECED_NOME_FORNECEDOR, FORNECED.DCLFORNECEDORES.FORNECED_NOME_FORNECEDOR);
                _.Move(executed_1.FORNECED_TIPO_PESSOA, FORNECED.DCLFORNECEDORES.FORNECED_TIPO_PESSOA);
                _.Move(executed_1.W_NOME_TIPO_PESSOA, W_NOME_TIPO_PESSOA);
                _.Move(executed_1.FORNECED_CGCCPF, FORNECED.DCLFORNECEDORES.FORNECED_CGCCPF);
                _.Move(executed_1.FORNECED_ENDERECO, FORNECED.DCLFORNECEDORES.FORNECED_ENDERECO);
                _.Move(executed_1.FORNECED_BAIRRO, FORNECED.DCLFORNECEDORES.FORNECED_BAIRRO);
                _.Move(executed_1.FORNECED_CIDADE, FORNECED.DCLFORNECEDORES.FORNECED_CIDADE);
                _.Move(executed_1.FORNECED_CEP, FORNECED.DCLFORNECEDORES.FORNECED_CEP);
                _.Move(executed_1.FORNECED_SIGLA_UF, FORNECED.DCLFORNECEDORES.FORNECED_SIGLA_UF);
            }


        }

        [StopWatch]
        /*" R2020-CADASTRAIS-FORNECED */
        private void R2020_CADASTRAIS_FORNECED(bool isPerform = false)
        {
            /*" -3319- DISPLAY 'R2020-CADASTRAIS-FORNECED' */
            _.Display($"R2020-CADASTRAIS-FORNECED");

            /*" -3392- PERFORM R2020_CADASTRAIS_FORNECED_DB_SELECT_1 */

            R2020_CADASTRAIS_FORNECED_DB_SELECT_1();

            /*" -3395- IF SQLCODE EQUAL 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -3396- MOVE FORNECED-CGCCPF TO W-NUM-CPF-NUM */
                _.Move(FORNECED.DCLFORNECEDORES.FORNECED_CGCCPF, AREA_DE_WORK.W_NUM_CPF_NUM);

                /*" -3397- MOVE FORNECED-CGCCPF TO W-NUM-CNPJ-NUM */
                _.Move(FORNECED.DCLFORNECEDORES.FORNECED_CGCCPF, AREA_DE_WORK.W_NUM_CNPJ_NUM);

                /*" -3399- MOVE 'FORNECEDOR OU LOTERICO' TO W-CHAVE-ORIGEM-CADASTRO. */
                _.Move("FORNECEDOR OU LOTERICO", AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO);
            }


            /*" -3400- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -3401- DISPLAY 'SICP001S- ERRO ACESSO FORNECEDORES' */
                _.Display($"SICP001S- ERRO ACESSO FORNECEDORES");

                /*" -3403- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -3404- IF FORNECED-TIPO-PESSOA EQUAL 'F' */

            if (FORNECED.DCLFORNECEDORES.FORNECED_TIPO_PESSOA == "F")
            {

                /*" -3405- MOVE 'PF' TO W-CHAVE-TIPO-PESSOA-PF-PJ */
                _.Move("PF", AREA_DE_WORK.W_CHAVE_TIPO_PESSOA_PF_PJ);

                /*" -3406- ELSE */
            }
            else
            {


                /*" -3407- IF FORNECED-TIPO-PESSOA EQUAL 'J' */

                if (FORNECED.DCLFORNECEDORES.FORNECED_TIPO_PESSOA == "J")
                {

                    /*" -3408- MOVE 'PJ' TO W-CHAVE-TIPO-PESSOA-PF-PJ */
                    _.Move("PJ", AREA_DE_WORK.W_CHAVE_TIPO_PESSOA_PF_PJ);

                    /*" -3409- ELSE */
                }
                else
                {


                    /*" -3411- MOVE '??' TO W-CHAVE-TIPO-PESSOA-PF-PJ. */
                    _.Move("??", AREA_DE_WORK.W_CHAVE_TIPO_PESSOA_PF_PJ);
                }

            }


            /*" -3412- MOVE FORNECED-CEP TO W-CEP-NUM . */
            _.Move(FORNECED.DCLFORNECEDORES.FORNECED_CEP, AREA_DE_WORK.W_CEP_NUM);

            /*" -3413- MOVE W-CEP-NUMERICO-PARTE1 TO W-CEP-ALFA-PARTE1 . */
            _.Move(AREA_DE_WORK.W_CEP_NUMERICO.W_CEP_NUMERICO_PARTE1, AREA_DE_WORK.W_CEP_ALFA.W_CEP_ALFA_PARTE1);

            /*" -3413- MOVE W-CEP-NUMERICO-PARTE2 TO W-CEP-ALFA-PARTE2 . */
            _.Move(AREA_DE_WORK.W_CEP_NUMERICO.W_CEP_NUMERICO_PARTE2, AREA_DE_WORK.W_CEP_ALFA.W_CEP_ALFA_PARTE2);

        }

        [StopWatch]
        /*" R2020-CADASTRAIS-FORNECED-DB-SELECT-1 */
        public void R2020_CADASTRAIS_FORNECED_DB_SELECT_1()
        {
            /*" -3392- EXEC SQL SELECT H.NUM_APOL_SINISTRO AS "NUM SINISTRO", H.OCORR_HISTORICO AS "OCORRHIST", H.COD_OPERACAO AS "OPERACAO", OPE.FUNCAO_OPERACAO AS "FUNCAO OPERACAO", SUBSTR(OPE.DES_OPERACAO,1,30) AS "NOME OPERACAO", F.TIPO_PESSOA AS "TIPO PESSOA", CASE F.TIPO_PESSOA WHEN 'F' THEN 'PESSOA FISICA  ' WHEN 'J' THEN 'PESSOA JURIDICA' END AS "TIPO DE PESSOA", F.CGCCPF AS "CPF / CNPJ DO FAVORECIDO", F.NOME_FORNECEDOR AS "NOME FORNECEDOR", F.INSC_PREFEITURA AS "INSCRICAO MUNICIPAL", F.INSC_ESTADUAL AS "INSCRICAO ESTADUAL", F.OPT_SIMPLES_FED AS "OPTANTE SIMPLES FERERAL", F.OPT_SIMPLES_MUN AS "OPTANTE SIMPLES MUNICIPAL", F.ENDERECO AS "LOGRAD. + NUM IMOVEL + COMPL", F.BAIRRO AS "BAIRRO", F.CIDADE AS "CIDADE", F.CEP AS "CEP", F.SIGLA_UF AS "UF", H.NOME_FAVORECIDO AS "NOME_FAVORECIDO_HIST", OPE.IND_TIPO_FUNCAO AS "TIPO FUNCAO OPERACAO" INTO :SINISHIS-NUM-APOL-SINISTRO, :SINISHIS-OCORR-HISTORICO, :SINISHIS-COD-OPERACAO, :GEOPERAC-FUNCAO-OPERACAO, :GEOPERAC-DES-OPERACAO, :FORNECED-TIPO-PESSOA, :W-NOME-TIPO-PESSOA, :FORNECED-CGCCPF, :FORNECED-NOME-FORNECEDOR, :FORNECED-INSC-PREFEITURA, :FORNECED-INSC-ESTADUAL, :FORNECED-OPT-SIMPLES-FED, :FORNECED-OPT-SIMPLES-MUN, :FORNECED-ENDERECO, :FORNECED-BAIRRO, :FORNECED-CIDADE, :FORNECED-CEP, :FORNECED-SIGLA-UF, :SINISHIS-NOME-FAVORECIDO, :GEOPERAC-IND-TIPO-FUNCAO FROM SEGUROS.SINISTRO_HISTORICO H, SEGUROS.GE_OPERACAO OPE, SEGUROS.FORNECEDORES F WHERE NOT EXISTS (SELECT 1 FROM SEGUROS.SI_PESS_SINISTRO SIPES WHERE SIPES.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND SIPES.OCORR_HISTORICO = H.OCORR_HISTORICO AND SIPES.COD_OPERACAO = H.COD_OPERACAO) AND OPE.IDE_SISTEMA = 'SI' AND OPE.COD_OPERACAO = H.COD_OPERACAO AND H.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND H.OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND H.COD_OPERACAO = :SINISHIS-COD-OPERACAO AND H.COD_PREST_SERVICO <> 0 AND F.COD_FORNECEDOR = H.COD_PREST_SERVICO AND F.CGCCPF <> 80000000000 END-EXEC. */

            var r2020_CADASTRAIS_FORNECED_DB_SELECT_1_Query1 = new R2020_CADASTRAIS_FORNECED_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
                SINISHIS_COD_OPERACAO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.ToString(),
            };

            var executed_1 = R2020_CADASTRAIS_FORNECED_DB_SELECT_1_Query1.Execute(r2020_CADASTRAIS_FORNECED_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISHIS_NUM_APOL_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO);
                _.Move(executed_1.SINISHIS_OCORR_HISTORICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO);
                _.Move(executed_1.SINISHIS_COD_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);
                _.Move(executed_1.GEOPERAC_FUNCAO_OPERACAO, GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO);
                _.Move(executed_1.GEOPERAC_DES_OPERACAO, GEOPERAC.DCLGE_OPERACAO.GEOPERAC_DES_OPERACAO);
                _.Move(executed_1.FORNECED_TIPO_PESSOA, FORNECED.DCLFORNECEDORES.FORNECED_TIPO_PESSOA);
                _.Move(executed_1.W_NOME_TIPO_PESSOA, W_NOME_TIPO_PESSOA);
                _.Move(executed_1.FORNECED_CGCCPF, FORNECED.DCLFORNECEDORES.FORNECED_CGCCPF);
                _.Move(executed_1.FORNECED_NOME_FORNECEDOR, FORNECED.DCLFORNECEDORES.FORNECED_NOME_FORNECEDOR);
                _.Move(executed_1.FORNECED_INSC_PREFEITURA, FORNECED.DCLFORNECEDORES.FORNECED_INSC_PREFEITURA);
                _.Move(executed_1.FORNECED_INSC_ESTADUAL, FORNECED.DCLFORNECEDORES.FORNECED_INSC_ESTADUAL);
                _.Move(executed_1.FORNECED_OPT_SIMPLES_FED, FORNECED.DCLFORNECEDORES.FORNECED_OPT_SIMPLES_FED);
                _.Move(executed_1.FORNECED_OPT_SIMPLES_MUN, FORNECED.DCLFORNECEDORES.FORNECED_OPT_SIMPLES_MUN);
                _.Move(executed_1.FORNECED_ENDERECO, FORNECED.DCLFORNECEDORES.FORNECED_ENDERECO);
                _.Move(executed_1.FORNECED_BAIRRO, FORNECED.DCLFORNECEDORES.FORNECED_BAIRRO);
                _.Move(executed_1.FORNECED_CIDADE, FORNECED.DCLFORNECEDORES.FORNECED_CIDADE);
                _.Move(executed_1.FORNECED_CEP, FORNECED.DCLFORNECEDORES.FORNECED_CEP);
                _.Move(executed_1.FORNECED_SIGLA_UF, FORNECED.DCLFORNECEDORES.FORNECED_SIGLA_UF);
                _.Move(executed_1.SINISHIS_NOME_FAVORECIDO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO);
                _.Move(executed_1.GEOPERAC_IND_TIPO_FUNCAO, GEOPERAC.DCLGE_OPERACAO.GEOPERAC_IND_TIPO_FUNCAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2020_EXIT*/

        [StopWatch]
        /*" R2030-PEGA-NOTA-FISCAL */
        private void R2030_PEGA_NOTA_FISCAL(bool isPerform = false)
        {
            /*" -3421- DISPLAY 'R2030-PEGA-NOTA-FISCAL' */
            _.Display($"R2030-PEGA-NOTA-FISCAL");

            /*" -3423- INITIALIZE DCLFI-PAGA-DOC-FISCAL */
            _.Initialize(
                FIPADOFI.DCLFI_PAGA_DOC_FISCAL
            );

            /*" -3427- MOVE 0 TO NULL-NUM-DOC-FISCAL NULL-SERIE-DOC-FISCAL NULL-DATA-EMISSAO-DOC */
            _.Move(0, NULL_NUM_DOC_FISCAL, NULL_SERIE_DOC_FISCAL, NULL_DATA_EMISSAO_DOC);

            /*" -3443- PERFORM R2030_PEGA_NOTA_FISCAL_DB_SELECT_1 */

            R2030_PEGA_NOTA_FISCAL_DB_SELECT_1();

            /*" -3446- IF SQLCODE EQUAL 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -3447- IF W-CHAVE-EH-PRESTADOR EQUAL 'SIM' */

                if (AREA_DE_WORK.W_CHAVE_EH_PRESTADOR == "SIM")
                {

                    /*" -3448- MOVE 'SIM' TO W-CHAVE-ACHOU-NOTA-FISCAL */
                    _.Move("SIM", AREA_DE_WORK.W_CHAVE_ACHOU_NOTA_FISCAL);

                    /*" -3449- ELSE */
                }
                else
                {


                    /*" -3450- MOVE 'NAO' TO W-CHAVE-ACHOU-NOTA-FISCAL */
                    _.Move("NAO", AREA_DE_WORK.W_CHAVE_ACHOU_NOTA_FISCAL);

                    /*" -3451- END-IF */
                }


                /*" -3453- END-IF */
            }


            /*" -3454- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -3455- DISPLAY 'SICP001S- ERRO ACESSO FI_PAGA_DOC_FISCAL' */
                _.Display($"SICP001S- ERRO ACESSO FI_PAGA_DOC_FISCAL");

                /*" -3456- DISPLAY 'NUM_APOL_SINISTRO= ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"NUM_APOL_SINISTRO= {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -3457- DISPLAY 'OCORR_HISTORICO  = ' SINISHIS-OCORR-HISTORICO */
                _.Display($"OCORR_HISTORICO  = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}");

                /*" -3458- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -3459- END-IF */
            }


            /*" -3459- . */

        }

        [StopWatch]
        /*" R2030-PEGA-NOTA-FISCAL-DB-SELECT-1 */
        public void R2030_PEGA_NOTA_FISCAL_DB_SELECT_1()
        {
            /*" -3443- EXEC SQL SELECT NUM_DOC_FISCAL ,SERIE_DOC_FISCAL ,DATA_EMISSAO_DOC INTO :FIPADOFI-NUM-DOC-FISCAL:NULL-NUM-DOC-FISCAL ,:FIPADOFI-SERIE-DOC-FISCAL:NULL-SERIE-DOC-FISCAL ,:FIPADOFI-DATA-EMISSAO-DOC:NULL-DATA-EMISSAO-DOC FROM SEGUROS.SI_PAGA_DOC_FISCAL X ,SEGUROS.FI_PAGA_DOC_FISCAL Y WHERE X.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND X.OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND X.COD_OPERACAO = :SINISHIS-COD-OPERACAO AND Y.NUM_DOCF_INTERNO = X.NUM_DOCF_INTERNO END-EXEC. */

            var r2030_PEGA_NOTA_FISCAL_DB_SELECT_1_Query1 = new R2030_PEGA_NOTA_FISCAL_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
                SINISHIS_COD_OPERACAO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.ToString(),
            };

            var executed_1 = R2030_PEGA_NOTA_FISCAL_DB_SELECT_1_Query1.Execute(r2030_PEGA_NOTA_FISCAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FIPADOFI_NUM_DOC_FISCAL, FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_NUM_DOC_FISCAL);
                _.Move(executed_1.NULL_NUM_DOC_FISCAL, NULL_NUM_DOC_FISCAL);
                _.Move(executed_1.FIPADOFI_SERIE_DOC_FISCAL, FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_SERIE_DOC_FISCAL);
                _.Move(executed_1.NULL_SERIE_DOC_FISCAL, NULL_SERIE_DOC_FISCAL);
                _.Move(executed_1.FIPADOFI_DATA_EMISSAO_DOC, FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_DATA_EMISSAO_DOC);
                _.Move(executed_1.NULL_DATA_EMISSAO_DOC, NULL_DATA_EMISSAO_DOC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2030_EXIT*/

        [StopWatch]
        /*" R2040-PEGA-SERVICO */
        private void R2040_PEGA_SERVICO(bool isPerform = false)
        {
            /*" -3467- DISPLAY 'R2040-PEGA-SERVICO' */
            _.Display($"R2040-PEGA-SERVICO");

            /*" -3479- PERFORM R2040_PEGA_SERVICO_DB_SELECT_1 */

            R2040_PEGA_SERVICO_DB_SELECT_1();

            /*" -3482- IF SQLCODE EQUAL 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -3483- IF W-CHAVE-EH-PRESTADOR EQUAL 'SIM' */

                if (AREA_DE_WORK.W_CHAVE_EH_PRESTADOR == "SIM")
                {

                    /*" -3484- MOVE 'SIM' TO W-CHAVE-ACHOU-FORNECEDOR */
                    _.Move("SIM", AREA_DE_WORK.W_CHAVE_ACHOU_FORNECEDOR);

                    /*" -3485- ELSE */
                }
                else
                {


                    /*" -3487- MOVE 'NAO' TO W-CHAVE-ACHOU-FORNECEDOR. */
                    _.Move("NAO", AREA_DE_WORK.W_CHAVE_ACHOU_FORNECEDOR);
                }

            }


            /*" -3488- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -3489- DISPLAY 'SICP001S- ERRO ACESSO FORNECEDORES (12)' */
                _.Display($"SICP001S- ERRO ACESSO FORNECEDORES (12)");

                /*" -3489- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2040-PEGA-SERVICO-DB-SELECT-1 */
        public void R2040_PEGA_SERVICO_DB_SELECT_1()
        {
            /*" -3479- EXEC SQL SELECT CEP, COD_SERVICO_ISS INTO :FORNECED-CEP, :FORNECED-COD-SERVICO-ISS FROM SEGUROS.SINISTRO_HISTORICO H, SEGUROS.FORNECEDORES F WHERE H.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND H.OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND H.COD_OPERACAO = :SINISHIS-COD-OPERACAO AND F.COD_FORNECEDOR = H.COD_PREST_SERVICO END-EXEC. */

            var r2040_PEGA_SERVICO_DB_SELECT_1_Query1 = new R2040_PEGA_SERVICO_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
                SINISHIS_COD_OPERACAO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.ToString(),
            };

            var executed_1 = R2040_PEGA_SERVICO_DB_SELECT_1_Query1.Execute(r2040_PEGA_SERVICO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FORNECED_CEP, FORNECED.DCLFORNECEDORES.FORNECED_CEP);
                _.Move(executed_1.FORNECED_COD_SERVICO_ISS, FORNECED.DCLFORNECEDORES.FORNECED_COD_SERVICO_ISS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2040_EXIT*/

        [StopWatch]
        /*" R2050-FONTE-RECOLHE-IMPOSTO */
        private void R2050_FONTE_RECOLHE_IMPOSTO(bool isPerform = false)
        {
            /*" -3497- DISPLAY 'R2050-FONTE-RECOLHE-IMPOSTOS' */
            _.Display($"R2050-FONTE-RECOLHE-IMPOSTOS");

            /*" -3499- MOVE 0 TO CEPFXFIL-FONTE . */
            _.Move(0, CEPFXFIL.DCLCEPFAIXAFILIAL.CEPFXFIL_FONTE);

            /*" -3508- PERFORM R2050_FONTE_RECOLHE_IMPOSTO_DB_SELECT_1 */

            R2050_FONTE_RECOLHE_IMPOSTO_DB_SELECT_1();

            /*" -3512- MOVE 'NAO' TO W-CHAVE-ACHOU-FONTE-IMPOSTO . */
            _.Move("NAO", AREA_DE_WORK.W_CHAVE_ACHOU_FONTE_IMPOSTO);

            /*" -3513- IF SQLCODE EQUAL 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -3514- IF CEPFXFIL-FONTE NOT EQUAL 0 */

                if (CEPFXFIL.DCLCEPFAIXAFILIAL.CEPFXFIL_FONTE != 0)
                {

                    /*" -3515- IF W-CHAVE-EH-PRESTADOR EQUAL 'SIM' */

                    if (AREA_DE_WORK.W_CHAVE_EH_PRESTADOR == "SIM")
                    {

                        /*" -3517- MOVE 'SIM' TO W-CHAVE-ACHOU-FONTE-IMPOSTO. */
                        _.Move("SIM", AREA_DE_WORK.W_CHAVE_ACHOU_FONTE_IMPOSTO);
                    }

                }

            }


            /*" -3518- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -3519- DISPLAY 'SICP001S- ERRO ACESSO CEPFAIXAFILIAL' */
                _.Display($"SICP001S- ERRO ACESSO CEPFAIXAFILIAL");

                /*" -3520- DISPLAY 'CEP PESQUISADO = ' FORNECED-CEP */
                _.Display($"CEP PESQUISADO = {FORNECED.DCLFORNECEDORES.FORNECED_CEP}");

                /*" -3521- MOVE PRODUTO-COD-EMPRESA TO WS-SMALLINT(01) */
                _.Move(PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA, AREA_DE_WORK.WS_SMALLINT[01]);

                /*" -3522- DISPLAY 'COD EMPRESA    = ' WS-SMALLINT(01) */
                _.Display($"COD EMPRESA    = {AREA_DE_WORK.WS_SMALLINT[1]}");

                /*" -3522- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2050-FONTE-RECOLHE-IMPOSTO-DB-SELECT-1 */
        public void R2050_FONTE_RECOLHE_IMPOSTO_DB_SELECT_1()
        {
            /*" -3508- EXEC SQL SELECT VALUE(MIN(FONTE),0) INTO :CEPFXFIL-FONTE FROM SEGUROS.CEPFAIXAFILIAL A WHERE A.DATA_INI_VIGENCIA <= :SISTEMAS-DATA-MOV-ABERTO AND A.DATA_TER_VIGENCIA = '9999-12-31' AND A.CEP_INICIAL <= :FORNECED-CEP AND A.CEP_FINAL >= :FORNECED-CEP AND A.COD_EMPRESA = :PRODUTO-COD-EMPRESA END-EXEC. */

            var r2050_FONTE_RECOLHE_IMPOSTO_DB_SELECT_1_Query1 = new R2050_FONTE_RECOLHE_IMPOSTO_DB_SELECT_1_Query1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                PRODUTO_COD_EMPRESA = PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA.ToString(),
                FORNECED_CEP = FORNECED.DCLFORNECEDORES.FORNECED_CEP.ToString(),
            };

            var executed_1 = R2050_FONTE_RECOLHE_IMPOSTO_DB_SELECT_1_Query1.Execute(r2050_FONTE_RECOLHE_IMPOSTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CEPFXFIL_FONTE, CEPFXFIL.DCLCEPFAIXAFILIAL.CEPFXFIL_FONTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2050_EXIT*/

        [StopWatch]
        /*" R2060-MONTA-AGRUPA-PAGTO-SAP */
        private void R2060_MONTA_AGRUPA_PAGTO_SAP(bool isPerform = false)
        {
            /*" -3537- DISPLAY 'R2060-MONTA-AGRUPA-PAGTO-SAP' */
            _.Display($"R2060-MONTA-AGRUPA-PAGTO-SAP");

            /*" -3538- IF NULL-NOM-PROGRAMA < 0 */

            if (NULL_NOM_PROGRAMA < 0)
            {

                /*" -3548- GO TO R2060-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2060_EXIT*/ //GOTO
                return;
            }


            /*" -3549- IF SINISHIS-NOM-PROGRAMA EQUAL 'FI0095B' OR 'SI5070B' */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOM_PROGRAMA.In("FI0095B", "SI5070B"))
            {

                /*" -3560- GO TO R2060-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2060_EXIT*/ //GOTO
                return;
            }


            /*" -3561- IF SINISHIS-NOM-PROGRAMA EQUAL 'SI5066B' */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOM_PROGRAMA == "SI5066B")
            {

                /*" -3562- MOVE 'SI5066B REPASSE MATC' TO GE420-COD-AGRUPADOR */
                _.Move("SI5066B REPASSE MATC", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_AGRUPADOR);

                /*" -3563- GO TO R2060-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2060_EXIT*/ //GOTO
                return;

                /*" -3578- END-IF. */
            }


            /*" -3579- IF SINISHIS-NOM-PROGRAMA EQUAL 'FI0005B' */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOM_PROGRAMA == "FI0005B")
            {

                /*" -3580- MOVE 'FI0005B IND HAB CRED' TO GE420-COD-AGRUPADOR */
                _.Move("FI0005B IND HAB CRED", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_AGRUPADOR);

                /*" -3581- GO TO R2060-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2060_EXIT*/ //GOTO
                return;

                /*" -3591- END-IF. */
            }


            /*" -3592- IF SINISHIS-NOM-PROGRAMA EQUAL 'SI5022B' */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOM_PROGRAMA == "SI5022B")
            {

                /*" -3593- MOVE 'SI5022B IND HAB CC L' TO GE420-COD-AGRUPADOR */
                _.Move("SI5022B IND HAB CC L", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_AGRUPADOR);

                /*" -3594- GO TO R2060-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2060_EXIT*/ //GOTO
                return;

                /*" -3603- END-IF. */
            }


            /*" -3604- IF SINISHIS-NOM-PROGRAMA EQUAL 'SI5033B' */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOM_PROGRAMA == "SI5033B")
            {

                /*" -3605- MOVE 'SI5033B REPASSE CRED' TO GE420-COD-AGRUPADOR */
                _.Move("SI5033B REPASSE CRED", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_AGRUPADOR);

                /*" -3606- GO TO R2060-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2060_EXIT*/ //GOTO
                return;

                /*" -3615- END-IF. */
            }


            /*" -3616- IF SINISHIS-NOM-PROGRAMA EQUAL 'SI5038B' */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOM_PROGRAMA == "SI5038B")
            {

                /*" -3617- MOVE 'SI5038B INDHAB CXCON' TO GE420-COD-AGRUPADOR */
                _.Move("SI5038B INDHAB CXCON", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_AGRUPADOR);

                /*" -3618- GO TO R2060-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2060_EXIT*/ //GOTO
                return;

                /*" -3627- END-IF. */
            }


            /*" -3628- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'JLIND' */

            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "JLIND")
            {

                /*" -3629- PERFORM R7777-ACESSA-TIMESTAMP THRU R7777-EXIT */

                R7777_ACESSA_TIMESTAMP(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R7777_EXIT*/


                /*" -3630- MOVE 'JURID IND  ' TO W-AGRUPADOR-LEGENDA */
                _.Move("JURID IND  ", AREA_DE_WORK.W_AGRUPADOR_1.W_AGRUPADOR_LEGENDA);

                /*" -3631- MOVE W-AGRUPADOR-1 TO GE420-COD-AGRUPADOR */
                _.Move(AREA_DE_WORK.W_AGRUPADOR_1, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_AGRUPADOR);

                /*" -3632- GO TO R2060-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2060_EXIT*/ //GOTO
                return;

                /*" -3636- END-IF. */
            }


            /*" -3637- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'JLDP' */

            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "JLDP")
            {

                /*" -3638- IF SINISHIS-COD-OPERACAO EQUAL 8110 */

                if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO == 8110)
                {

                    /*" -3639- PERFORM R7777-ACESSA-TIMESTAMP THRU R7777-EXIT */

                    R7777_ACESSA_TIMESTAMP(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R7777_EXIT*/


                    /*" -3640- MOVE 'JUR TUTELA ' TO W-AGRUPADOR-LEGENDA */
                    _.Move("JUR TUTELA ", AREA_DE_WORK.W_AGRUPADOR_1.W_AGRUPADOR_LEGENDA);

                    /*" -3641- MOVE W-AGRUPADOR-1 TO GE420-COD-AGRUPADOR */
                    _.Move(AREA_DE_WORK.W_AGRUPADOR_1, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_AGRUPADOR);

                    /*" -3642- GO TO R2060-EXIT */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2060_EXIT*/ //GOTO
                    return;

                    /*" -3643- ELSE */
                }
                else
                {


                    /*" -3644- PERFORM R7777-ACESSA-TIMESTAMP THRU R7777-EXIT */

                    R7777_ACESSA_TIMESTAMP(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R7777_EXIT*/


                    /*" -3645- MOVE 'JUR DEPOSI ' TO W-AGRUPADOR-LEGENDA */
                    _.Move("JUR DEPOSI ", AREA_DE_WORK.W_AGRUPADOR_1.W_AGRUPADOR_LEGENDA);

                    /*" -3646- MOVE W-AGRUPADOR-1 TO GE420-COD-AGRUPADOR */
                    _.Move(AREA_DE_WORK.W_AGRUPADOR_1, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_AGRUPADOR);

                    /*" -3647- END-IF */
                }


                /*" -3648- GO TO R2060-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2060_EXIT*/ //GOTO
                return;

                /*" -3653- END-IF. */
            }


            /*" -3655- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'LIB' AND (SINISMES-RAMO EQUAL 31 OR 53 OR 20) */

            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "LIB" && (SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO.In("31", "53", "20")))
            {

                /*" -3656- PERFORM R7777-ACESSA-TIMESTAMP THRU R7777-EXIT */

                R7777_ACESSA_TIMESTAMP(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R7777_EXIT*/


                /*" -3657- MOVE 'AUTOMOVEL  ' TO W-AGRUPADOR-LEGENDA */
                _.Move("AUTOMOVEL  ", AREA_DE_WORK.W_AGRUPADOR_1.W_AGRUPADOR_LEGENDA);

                /*" -3658- MOVE W-AGRUPADOR-1 TO GE420-COD-AGRUPADOR */
                _.Move(AREA_DE_WORK.W_AGRUPADOR_1, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_AGRUPADOR);

                /*" -3659- GO TO R2060-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2060_EXIT*/ //GOTO
                return;

                /*" -3659- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2060_EXIT*/

        [StopWatch]
        /*" P7000-00-GRAVA-PARA-MCP */
        private void P7000_00_GRAVA_PARA_MCP(bool isPerform = false)
        {
            /*" -3677- DISPLAY 'P7000-00-GRAVA-PARA-MCP' */
            _.Display($"P7000-00-GRAVA-PARA-MCP");

            /*" -3682- MOVE -1 TO WH-ID-ENVIO-NULL WH-ID-ENVIO-HIST-NULL WH-SI-ENVIO-NULL WH-SI-RETORNO-H-NULL WH-EFETIVO-PGTO-NULL. */
            _.Move(-1, WH_ID_ENVIO_NULL, WH_ID_ENVIO_HIST_NULL, WH_SI_ENVIO_NULL, WH_SI_RETORNO_H_NULL, WH_EFETIVO_PGTO_NULL);

            /*" -3684- MOVE SINISHIS-NUM-APOL-SINISTRO TO SI237-NUM-SINISTRO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, SI237.DCLSI_MOVTO_PGTO_COB.SI237_NUM_SINISTRO);

            /*" -3685- MOVE SINISHIS-COD-OPERACAO TO SI237-COD-OPERACAO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO, SI237.DCLSI_MOVTO_PGTO_COB.SI237_COD_OPERACAO);

            /*" -3686- MOVE SINISHIS-OCORR-HISTORICO TO SI237-OCORR-HISTORICO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO, SI237.DCLSI_MOVTO_PGTO_COB.SI237_OCORR_HISTORICO);

            /*" -3687- MOVE SINISHIS-COD-USUARIO TO SI237-COD-USUARIO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_USUARIO, SI237.DCLSI_MOVTO_PGTO_COB.SI237_COD_USUARIO);

            /*" -3688- MOVE 'SI' TO SI237-IDE-SISTEMA */
            _.Move("SI", SI237.DCLSI_MOVTO_PGTO_COB.SI237_IDE_SISTEMA);

            /*" -3689- MOVE GE420-NOM-PROGRAMA TO SI237-COD-PROGRAMA */
            _.Move(GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NOM_PROGRAMA, SI237.DCLSI_MOVTO_PGTO_COB.SI237_COD_PROGRAMA);

            /*" -3690- MOVE 'PE' TO SI237-STA-ENVIO-MOVIMENTO */
            _.Move("PE", SI237.DCLSI_MOVTO_PGTO_COB.SI237_STA_ENVIO_MOVIMENTO);

            /*" -3693- MOVE '1212-12-12' TO SI237-DTA-SI-ENVIO SI237-DTA-SI-RETORNO-H SI237-DTA-EFETIVO-PGTO. */
            _.Move("1212-12-12", SI237.DCLSI_MOVTO_PGTO_COB.SI237_DTA_SI_ENVIO, SI237.DCLSI_MOVTO_PGTO_COB.SI237_DTA_SI_RETORNO_H, SI237.DCLSI_MOVTO_PGTO_COB.SI237_DTA_EFETIVO_PGTO);

            /*" -3697- MOVE ZEROS TO SI237-NUM-ID-ENVIO SI237-SEQ-ID-ENVIO-HIST GE420-NUM-ID-ENVIO GE420-SEQ-ID-ENVIO-HIST. */
            _.Move(0, SI237.DCLSI_MOVTO_PGTO_COB.SI237_NUM_ID_ENVIO, SI237.DCLSI_MOVTO_PGTO_COB.SI237_SEQ_ID_ENVIO_HIST, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_ID_ENVIO, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_SEQ_ID_ENVIO_HIST);

            /*" -3699- MOVE PRODUTO-COD-EMPRESA TO SI237-COD-EMPRESA. */
            _.Move(PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA, SI237.DCLSI_MOVTO_PGTO_COB.SI237_COD_EMPRESA);

            /*" -3701- PERFORM P7237-SI2-SELECT THRU P7237-SI2-EXIT. */

            P7237_SI2_SELECT(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: P7237_SI2_EXIT*/


            /*" -3704- IF WS-SI237-SQL100 = 'SIM' */

            if (AREA_DE_WORK.WS_SI237_SQL100 == "SIM")
            {

                /*" -3705- PERFORM P7237-SI1-INSERT THRU P7237-SI1-EXIT */

                P7237_SI1_INSERT(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P7237_SI1_EXIT*/


                /*" -3717- ELSE */
            }
            else
            {


                /*" -3719- IF SI237-STA-ENVIO-MOVIMENTO NOT = 'ER' AND 'EG' AND 'EH' AND 'AE' AND 'PR' */

                if (!SI237.DCLSI_MOVTO_PGTO_COB.SI237_STA_ENVIO_MOVIMENTO.In("ER", "EG", "EH", "AE", "PR"))
                {

                    /*" -3721- DISPLAY 'SICP001S: PAGAMENTO EM DUPLICIDADE' */
                    _.Display($"SICP001S: PAGAMENTO EM DUPLICIDADE");

                    /*" -3722- MOVE SINISHIS-NUM-APOL-SINISTRO TO WS-APOLICE-ED */
                    _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, AREA_DE_WORK.WS_APOLICE_ED);

                    /*" -3723- MOVE SINISHIS-COD-OPERACAO TO WS-OPERACAO-ED */
                    _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO, AREA_DE_WORK.WS_OPERACAO_ED);

                    /*" -3724- MOVE SINISHIS-OCORR-HISTORICO TO WS-SMALLINT(01) */
                    _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO, AREA_DE_WORK.WS_SMALLINT[01]);

                    /*" -3729- STRING 'SINISTRO: ' WS-APOLICE-ED '; OPERACAO: ' WS-OPERACAO-ED '; OCORR-HIST: ' WS-SMALLINT(01) '; STA ENVIO: ' SI237-STA-ENVIO-MOVIMENTO DELIMITED BY SIZE INTO LKERR-ELEMENTOS */
                    #region STRING
                    var spl15 = "SINISTRO: " + AREA_DE_WORK.WS_APOLICE_ED.GetMoveValues();
                    spl15 += "; OPERACAO: ";
                    var spl16 = AREA_DE_WORK.WS_OPERACAO_ED.GetMoveValues();
                    spl16 += "; OCORR-HIST: ";
                    var spl17 = AREA_DE_WORK.WS_SMALLINT[01].GetMoveValues();
                    spl17 += "; STA ENVIO: ";
                    var spl18 = SI237.DCLSI_MOVTO_PGTO_COB.SI237_STA_ENVIO_MOVIMENTO.GetMoveValues();
                    var results19 = spl15 + spl16 + spl17 + spl18;
                    _.Move(results19, RSGEWERR.LKERR_REG.LKERR_ELEMENTOS);
                    #endregion

                    /*" -3730- DISPLAY LKERR-ELEMENTOS */
                    _.Display(RSGEWERR.LKERR_REG.LKERR_ELEMENTOS);

                    /*" -3731- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;

                    /*" -3735- END-IF */
                }


                /*" -3736- IF SI237-NUM-ID-ENVIO NOT = 0 */

                if (SI237.DCLSI_MOVTO_PGTO_COB.SI237_NUM_ID_ENVIO != 0)
                {

                    /*" -3738- PERFORM P7100-00-GERA-HISTORICO-SI237 THRU P7100-99-EXIT */

                    P7100_00_GERA_HISTORICO_SI237(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: P7100_99_EXIT*/


                    /*" -3739- MOVE SI237-NUM-ID-ENVIO TO GE420-NUM-ID-ENVIO */
                    _.Move(SI237.DCLSI_MOVTO_PGTO_COB.SI237_NUM_ID_ENVIO, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_ID_ENVIO);

                    /*" -3741- MOVE SI237-SEQ-ID-ENVIO-HIST TO GE420-SEQ-ID-ENVIO-HIST */
                    _.Move(SI237.DCLSI_MOVTO_PGTO_COB.SI237_SEQ_ID_ENVIO_HIST, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_SEQ_ID_ENVIO_HIST);

                    /*" -3742- END-IF */
                }


                /*" -3745- END-IF. */
            }


            /*" -3748- IF GE420-NUM-ID-ENVIO = 0 */

            if (GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_ID_ENVIO == 0)
            {

                /*" -3749- PERFORM P7420-GE2-SELECT THRU P7420-GE2-EXIT */

                P7420_GE2_SELECT(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P7420_GE2_EXIT*/


                /*" -3750- MOVE ZEROS TO GE420-SEQ-ID-ENVIO-HIST */
                _.Move(0, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_SEQ_ID_ENVIO_HIST);

                /*" -3754- END-IF. */
            }


            /*" -3755- ADD 1 TO GE420-SEQ-ID-ENVIO-HIST. */
            GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_SEQ_ID_ENVIO_HIST.Value = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_SEQ_ID_ENVIO_HIST + 1;

            /*" -3756- MOVE 'PE' TO GE420-STA-ENVIO-MOVIMENTO */
            _.Move("PE", GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_STA_ENVIO_MOVIMENTO);

            /*" -3758- PERFORM P7420-GE1-INSERT THRU P7420-GE1-EXIT. */

            P7420_GE1_INSERT(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: P7420_GE1_EXIT*/


            /*" -3759- MOVE GE420-STA-ENVIO-MOVIMENTO TO SI237-STA-ENVIO-MOVIMENTO */
            _.Move(GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_STA_ENVIO_MOVIMENTO, SI237.DCLSI_MOVTO_PGTO_COB.SI237_STA_ENVIO_MOVIMENTO);

            /*" -3760- MOVE GE420-NUM-ID-ENVIO TO SI237-NUM-ID-ENVIO */
            _.Move(GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_ID_ENVIO, SI237.DCLSI_MOVTO_PGTO_COB.SI237_NUM_ID_ENVIO);

            /*" -3761- MOVE GE420-SEQ-ID-ENVIO-HIST TO SI237-SEQ-ID-ENVIO-HIST. */
            _.Move(GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_SEQ_ID_ENVIO_HIST, SI237.DCLSI_MOVTO_PGTO_COB.SI237_SEQ_ID_ENVIO_HIST);

            /*" -3764- MOVE 1 TO WH-ID-ENVIO-NULL WH-ID-ENVIO-HIST-NULL. */
            _.Move(1, WH_ID_ENVIO_NULL, WH_ID_ENVIO_HIST_NULL);

            /*" -3764- PERFORM P7237-SI3-UPDATE THRU P7237-SI3-EXIT. */

            P7237_SI3_UPDATE(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: P7237_SI3_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P7000_99_EXIT*/

        [StopWatch]
        /*" P7100-00-GERA-HISTORICO-SI237 */
        private void P7100_00_GERA_HISTORICO_SI237(bool isPerform = false)
        {
            /*" -3783- DISPLAY 'P7100-00-GERA-HISTORICO-SI237' */
            _.Display($"P7100-00-GERA-HISTORICO-SI237");

            /*" -3791- INITIALIZE SSICPW002 LK-RSGEWCNT-IND-ERRO LK-RSGEWCNT-MENSAGEM-RETORNO LK-RSGEWCNT-NOME-TABELA LK-RSGEWCNT-SQLCODE LK-RSGEWCNT-SQLERRMC. */
            _.Initialize(
                SICPW002.SSICPW002
                , RSGEWCNT.LK_RSGEWCNT_IND_ERRO
                , RSGEWCNT.LK_RSGEWCNT_MENSAGEM_RETORNO
                , RSGEWCNT.LK_RSGEWCNT_NOME_TABELA
                , RSGEWCNT.LK_RSGEWCNT_SQLCODE
                , RSGEWCNT.LK_RSGEWCNT_SQLERRMC
            );

            /*" -3792- MOVE SI237-NUM-SINISTRO TO LK-SICPW002-NUM-SINISTRO */
            _.Move(SI237.DCLSI_MOVTO_PGTO_COB.SI237_NUM_SINISTRO, SICPW002.SSICPW002.LK_SICPW002_NUM_SINISTRO);

            /*" -3793- MOVE 'BATCH' TO LK-SICPW002-COD-USUARIO */
            _.Move("BATCH", SICPW002.SSICPW002.LK_SICPW002_COD_USUARIO);

            /*" -3794- MOVE 'SICP001S' TO LK-SICPW002-NOM-PROGRAMA */
            _.Move("SICP001S", SICPW002.SSICPW002.LK_SICPW002_NOM_PROGRAMA);

            /*" -3795- MOVE SI237-COD-OPERACAO TO LK-SICPW002-COD-OPERACAO */
            _.Move(SI237.DCLSI_MOVTO_PGTO_COB.SI237_COD_OPERACAO, SICPW002.SSICPW002.LK_SICPW002_COD_OPERACAO);

            /*" -3798- MOVE SI237-OCORR-HISTORICO TO LK-SICPW002-OCORR-HISTORICO. */
            _.Move(SI237.DCLSI_MOVTO_PGTO_COB.SI237_OCORR_HISTORICO, SICPW002.SSICPW002.LK_SICPW002_OCORR_HISTORICO);

            /*" -3800- MOVE 'SICP002S' TO WS-PROGRAMA. */
            _.Move("SICP002S", AREA_DE_WORK.WS_PROGRAMA);

            /*" -3807- CALL WS-PROGRAMA USING SICPW002 LK-RSGEWCNT-IND-ERRO LK-RSGEWCNT-MENSAGEM-RETORNO LK-RSGEWCNT-NOME-TABELA LK-RSGEWCNT-SQLCODE LK-RSGEWCNT-SQLERRMC. */
            _.Call(AREA_DE_WORK.WS_PROGRAMA, SICPW002, RSGEWCNT);

            /*" -3808- IF LK-RSGEWCNT-IND-ERRO NOT = ZEROS */

            if (RSGEWCNT.LK_RSGEWCNT_IND_ERRO != 00)
            {

                /*" -3809- DISPLAY 'ERRO NA CHAMADA DA SICP002S' */
                _.Display($"ERRO NA CHAMADA DA SICP002S");

                /*" -3810- DISPLAY LK-RSGEWCNT-MENSAGEM-RETORNO */
                _.Display(RSGEWCNT.LK_RSGEWCNT_MENSAGEM_RETORNO);

                /*" -3811- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -3811- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P7100_99_EXIT*/

        [StopWatch]
        /*" P7200-00-GERA-OPER-FINANCEIRA */
        private void P7200_00_GERA_OPER_FINANCEIRA(bool isPerform = false)
        {
            /*" -3828- DISPLAY 'P7200-00-GERA-OPER-FINANCEIRA' */
            _.Display($"P7200-00-GERA-OPER-FINANCEIRA");

            /*" -3829- MOVE SI237-NUM-SINISTRO TO SINISHIS-NUM-APOL-SINISTRO */
            _.Move(SI237.DCLSI_MOVTO_PGTO_COB.SI237_NUM_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO);

            /*" -3830- MOVE SI237-OCORR-HISTORICO TO SINISHIS-OCORR-HISTORICO */
            _.Move(SI237.DCLSI_MOVTO_PGTO_COB.SI237_OCORR_HISTORICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO);

            /*" -3832- MOVE SI237-COD-OPERACAO TO SINISHIS-COD-OPERACAO. */
            _.Move(SI237.DCLSI_MOVTO_PGTO_COB.SI237_COD_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);

            /*" -3838- PERFORM P7011-SI2-SELECT THRU P7011-SI2-EXIT. */

            P7011_SI2_SELECT(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: P7011_SI2_EXIT*/


            /*" -3842- MOVE HOST-SI-DATA-MOV-ABERTO TO SINISHIS-DATA-MOVIMENTO. */
            _.Move(HOST_SI_DATA_MOV_ABERTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO);

            /*" -3843- IF SINISHIS-COD-OPERACAO = 4294 */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO == 4294)
            {

                /*" -3844- MOVE 1025 TO SINISHIS-COD-OPERACAO */
                _.Move(1025, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);

                /*" -3845- ELSE */
            }
            else
            {


                /*" -3846- MOVE 1020 TO SINISHIS-COD-OPERACAO */
                _.Move(1020, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);

                /*" -3848- END-IF. */
            }


            /*" -3849- MOVE 'SICP001S' TO SINISHIS-NOM-PROGRAMA. */
            _.Move("SICP001S", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOM_PROGRAMA);

            /*" -3851- MOVE '1' TO SINISHIS-SIT-REGISTRO. */
            _.Move("1", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_REGISTRO);

            /*" -3856- PERFORM P7011-SI1-INSERT THRU P7011-SI1-EXIT. */

            P7011_SI1_INSERT(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: P7011_SI1_EXIT*/


            /*" -3857- IF WS-OPE-1020-EXISTE = 'SIM' */

            if (AREA_DE_WORK.WS_OPE_1020_EXISTE == "SIM")
            {

                /*" -3858- PERFORM P7011-SI3-UPDATE THRU P7011-SI3-EXIT */

                P7011_SI3_UPDATE(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P7011_SI3_EXIT*/


                /*" -3858- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P7200_99_EXIT*/

        [StopWatch]
        /*" P7011-SI1-INSERT */
        private void P7011_SI1_INSERT(bool isPerform = false)
        {
            /*" -3873- DISPLAY 'P7011-SI1-INSERT' */
            _.Display($"P7011-SI1-INSERT");

            /*" -3875- MOVE 'NAO' TO WS-OPE-1020-EXISTE. */
            _.Move("NAO", AREA_DE_WORK.WS_OPE_1020_EXISTE);

            /*" -3877- MOVE ZEROS TO WH-PROGRAMA-NULL. */
            _.Move(0, WH_PROGRAMA_NULL);

            /*" -3933- PERFORM P7011_SI1_INSERT_DB_INSERT_1 */

            P7011_SI1_INSERT_DB_INSERT_1();

            /*" -3938- IF SQLCODE = -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -3939- MOVE 'SIM' TO WS-OPE-1020-EXISTE */
                _.Move("SIM", AREA_DE_WORK.WS_OPE_1020_EXISTE);

                /*" -3940- GO TO P7011-SI1-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P7011_SI1_EXIT*/ //GOTO
                return;

                /*" -3942- END-IF. */
            }


            /*" -3943- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3945- MOVE 'P7011-SI1-INSERT' TO LKERR-ROTINA */
                _.Move("P7011-SI1-INSERT", RSGEWERR.LKERR_REG.LKERR_ROTINA);

                /*" -3946- MOVE 'INSERT' TO LKERR-FUNCAO */
                _.Move("INSERT", RSGEWERR.LKERR_REG.LKERR_FUNCAO);

                /*" -3949- MOVE 'SEGUROS.SINISTRO_HISTORICO' TO LKERR-OBJETOS */
                _.Move("SEGUROS.SINISTRO_HISTORICO", RSGEWERR.LKERR_REG.LKERR_OBJETOS);

                /*" -3950- MOVE SINISHIS-NUM-APOL-SINISTRO TO WS-APOLICE-ED */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, AREA_DE_WORK.WS_APOLICE_ED);

                /*" -3951- MOVE SINISHIS-COD-OPERACAO TO WS-OPERACAO-ED */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO, AREA_DE_WORK.WS_OPERACAO_ED);

                /*" -3952- MOVE SINISHIS-OCORR-HISTORICO TO WS-SMALLINT(01) */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO, AREA_DE_WORK.WS_SMALLINT[01]);

                /*" -3956- STRING 'SINISTRO: ' WS-APOLICE-ED '; OPERACAO: ' WS-OPERACAO-ED '; OCORR-HIST: ' WS-SMALLINT(01) DELIMITED BY SIZE INTO LKERR-ELEMENTOS */
                #region STRING
                var spl19 = "SINISTRO: " + AREA_DE_WORK.WS_APOLICE_ED.GetMoveValues();
                spl19 += "; OPERACAO: ";
                var spl20 = AREA_DE_WORK.WS_OPERACAO_ED.GetMoveValues();
                spl20 += "; OCORR-HIST: ";
                var spl21 = AREA_DE_WORK.WS_SMALLINT[01].GetMoveValues();
                var results22 = spl19 + spl20 + spl21;
                _.Move(results22, RSGEWERR.LKERR_REG.LKERR_ELEMENTOS);
                #endregion

                /*" -3957- GO TO P9999-CHAMA-RSGESERR */

                P9999_CHAMA_RSGESERR(); //GOTO
                return;

                /*" -3957- END-IF. */
            }


        }

        [StopWatch]
        /*" P7011-SI1-INSERT-DB-INSERT-1 */
        public void P7011_SI1_INSERT_DB_INSERT_1()
        {
            /*" -3933- EXEC SQL INSERT INTO SEGUROS.SINISTRO_HISTORICO ( COD_EMPRESA ,TIPO_REGISTRO ,NUM_APOL_SINISTRO ,OCORR_HISTORICO ,COD_OPERACAO ,DATA_MOVIMENTO ,HORA_OPERACAO ,NOME_FAVORECIDO ,VAL_OPERACAO ,DATA_LIM_CORRECAO ,TIPO_FAVORECIDO ,DATA_NEGOCIADA ,FONTE_PAGAMENTO ,COD_PREST_SERVICO ,COD_SERVICO ,ORDEM_PAGAMENTO ,NUM_RECIBO ,NUM_MOV_SINISTRO ,COD_USUARIO ,SIT_CONTABIL ,SIT_REGISTRO ,TIMESTAMP ,NUM_APOLICE ,COD_PRODUTO ,NOM_PROGRAMA ) VALUES ( :SINISHIS-COD-EMPRESA ,:SINISHIS-TIPO-REGISTRO ,:SINISHIS-NUM-APOL-SINISTRO ,:SINISHIS-OCORR-HISTORICO ,:SINISHIS-COD-OPERACAO ,:SINISHIS-DATA-MOVIMENTO , CURRENT TIME ,:SINISHIS-NOME-FAVORECIDO ,:SINISHIS-VAL-OPERACAO ,:SINISHIS-DATA-LIM-CORRECAO ,:SINISHIS-TIPO-FAVORECIDO ,:SINISHIS-DATA-NEGOCIADA ,:SINISHIS-FONTE-PAGAMENTO ,:SINISHIS-COD-PREST-SERVICO ,:SINISHIS-COD-SERVICO ,:SINISHIS-ORDEM-PAGAMENTO ,:SINISHIS-NUM-RECIBO ,:SINISHIS-NUM-MOV-SINISTRO ,:SINISHIS-COD-USUARIO ,:SINISHIS-SIT-CONTABIL ,:SINISHIS-SIT-REGISTRO , CURRENT TIMESTAMP ,:SINISHIS-NUM-APOLICE ,:SINISHIS-COD-PRODUTO ,:SINISHIS-NOM-PROGRAMA :WH-PROGRAMA-NULL ) END-EXEC. */

            var p7011_SI1_INSERT_DB_INSERT_1_Insert1 = new P7011_SI1_INSERT_DB_INSERT_1_Insert1()
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
                SINISHIS_COD_USUARIO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_USUARIO.ToString(),
                SINISHIS_SIT_CONTABIL = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL.ToString(),
                SINISHIS_SIT_REGISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_REGISTRO.ToString(),
                SINISHIS_NUM_APOLICE = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOLICE.ToString(),
                SINISHIS_COD_PRODUTO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PRODUTO.ToString(),
                SINISHIS_NOM_PROGRAMA = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOM_PROGRAMA.ToString(),
                WH_PROGRAMA_NULL = WH_PROGRAMA_NULL.ToString(),
            };

            P7011_SI1_INSERT_DB_INSERT_1_Insert1.Execute(p7011_SI1_INSERT_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P7011_SI1_EXIT*/

        [StopWatch]
        /*" P7011-SI2-SELECT */
        private void P7011_SI2_SELECT(bool isPerform = false)
        {
            /*" -3972- DISPLAY 'P7011-SI2-SELECT' */
            _.Display($"P7011-SI2-SELECT");

            /*" -4031- PERFORM P7011_SI2_SELECT_DB_SELECT_1 */

            P7011_SI2_SELECT_DB_SELECT_1();

            /*" -4034- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4036- MOVE 'P7011-SI2-SELECT' TO LKERR-ROTINA */
                _.Move("P7011-SI2-SELECT", RSGEWERR.LKERR_REG.LKERR_ROTINA);

                /*" -4037- MOVE 'SELECT' TO LKERR-FUNCAO */
                _.Move("SELECT", RSGEWERR.LKERR_REG.LKERR_FUNCAO);

                /*" -4040- MOVE 'SEGUROS.SINISTRO_HISTORICO' TO LKERR-OBJETOS */
                _.Move("SEGUROS.SINISTRO_HISTORICO", RSGEWERR.LKERR_REG.LKERR_OBJETOS);

                /*" -4041- MOVE SINISHIS-NUM-APOL-SINISTRO TO WS-APOLICE-ED */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, AREA_DE_WORK.WS_APOLICE_ED);

                /*" -4042- MOVE SINISHIS-COD-OPERACAO TO WS-OPERACAO-ED */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO, AREA_DE_WORK.WS_OPERACAO_ED);

                /*" -4043- MOVE SINISHIS-OCORR-HISTORICO TO WS-SMALLINT(01) */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO, AREA_DE_WORK.WS_SMALLINT[01]);

                /*" -4047- STRING 'SINISTRO: ' WS-APOLICE-ED '; OPERACAO: ' WS-OPERACAO-ED '; OCORR-HIST: ' WS-SMALLINT(01) DELIMITED BY SIZE INTO LKERR-ELEMENTOS */
                #region STRING
                var spl22 = "SINISTRO: " + AREA_DE_WORK.WS_APOLICE_ED.GetMoveValues();
                spl22 += "; OPERACAO: ";
                var spl23 = AREA_DE_WORK.WS_OPERACAO_ED.GetMoveValues();
                spl23 += "; OCORR-HIST: ";
                var spl24 = AREA_DE_WORK.WS_SMALLINT[01].GetMoveValues();
                var results25 = spl22 + spl23 + spl24;
                _.Move(results25, RSGEWERR.LKERR_REG.LKERR_ELEMENTOS);
                #endregion

                /*" -4048- GO TO P9999-CHAMA-RSGESERR */

                P9999_CHAMA_RSGESERR(); //GOTO
                return;

                /*" -4048- END-IF. */
            }


        }

        [StopWatch]
        /*" P7011-SI2-SELECT-DB-SELECT-1 */
        public void P7011_SI2_SELECT_DB_SELECT_1()
        {
            /*" -4031- EXEC SQL SELECT COD_EMPRESA ,TIPO_REGISTRO ,NUM_APOL_SINISTRO ,OCORR_HISTORICO ,COD_OPERACAO ,DATA_MOVIMENTO ,HORA_OPERACAO ,NOME_FAVORECIDO ,VAL_OPERACAO ,DATA_LIM_CORRECAO ,TIPO_FAVORECIDO ,DATA_NEGOCIADA ,FONTE_PAGAMENTO ,COD_PREST_SERVICO ,COD_SERVICO ,ORDEM_PAGAMENTO ,NUM_RECIBO ,NUM_MOV_SINISTRO ,COD_USUARIO ,SIT_CONTABIL ,SIT_REGISTRO ,VALUE(TIMESTAMP, '0001-01-01:00:00:00.000000' ) ,NUM_APOLICE ,COD_PRODUTO ,VALUE(NOM_PROGRAMA, ' ' ) INTO :SINISHIS-COD-EMPRESA ,:SINISHIS-TIPO-REGISTRO ,:SINISHIS-NUM-APOL-SINISTRO ,:SINISHIS-OCORR-HISTORICO ,:SINISHIS-COD-OPERACAO ,:SINISHIS-DATA-MOVIMENTO ,:SINISHIS-HORA-OPERACAO ,:SINISHIS-NOME-FAVORECIDO ,:SINISHIS-VAL-OPERACAO ,:SINISHIS-DATA-LIM-CORRECAO ,:SINISHIS-TIPO-FAVORECIDO ,:SINISHIS-DATA-NEGOCIADA ,:SINISHIS-FONTE-PAGAMENTO ,:SINISHIS-COD-PREST-SERVICO ,:SINISHIS-COD-SERVICO ,:SINISHIS-ORDEM-PAGAMENTO ,:SINISHIS-NUM-RECIBO ,:SINISHIS-NUM-MOV-SINISTRO ,:SINISHIS-COD-USUARIO ,:SINISHIS-SIT-CONTABIL ,:SINISHIS-SIT-REGISTRO ,:SINISHIS-TIMESTAMP ,:SINISHIS-NUM-APOLICE ,:SINISHIS-COD-PRODUTO ,:SINISHIS-NOM-PROGRAMA FROM SEGUROS.SINISTRO_HISTORICO WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND COD_OPERACAO = :SINISHIS-COD-OPERACAO WITH UR END-EXEC. */

            var p7011_SI2_SELECT_DB_SELECT_1_Query1 = new P7011_SI2_SELECT_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
                SINISHIS_COD_OPERACAO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.ToString(),
            };

            var executed_1 = P7011_SI2_SELECT_DB_SELECT_1_Query1.Execute(p7011_SI2_SELECT_DB_SELECT_1_Query1);
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
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P7011_SI2_EXIT*/

        [StopWatch]
        /*" P7011-SI3-UPDATE */
        private void P7011_SI3_UPDATE(bool isPerform = false)
        {
            /*" -4063- DISPLAY 'P011-SI3-UPDATE' */
            _.Display($"P011-SI3-UPDATE");

            /*" -4065- MOVE 'NAO' TO WS-SINIS-SQL100. */
            _.Move("NAO", AREA_DE_WORK.WS_SINIS_SQL100);

            /*" -4067- MOVE ZEROS TO WH-PROGRAMA-NULL. */
            _.Move(0, WH_PROGRAMA_NULL);

            /*" -4083- PERFORM P7011_SI3_UPDATE_DB_UPDATE_1 */

            P7011_SI3_UPDATE_DB_UPDATE_1();

            /*" -4086- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4088- MOVE 'P7011-SI3-UPDATE' TO LKERR-ROTINA */
                _.Move("P7011-SI3-UPDATE", RSGEWERR.LKERR_REG.LKERR_ROTINA);

                /*" -4089- MOVE 'UPDATE' TO LKERR-FUNCAO */
                _.Move("UPDATE", RSGEWERR.LKERR_REG.LKERR_FUNCAO);

                /*" -4092- MOVE 'SEGUROS.SINISTRO_HISTORICO' TO LKERR-OBJETOS */
                _.Move("SEGUROS.SINISTRO_HISTORICO", RSGEWERR.LKERR_REG.LKERR_OBJETOS);

                /*" -4093- MOVE SINISHIS-NUM-APOL-SINISTRO TO WS-APOLICE-ED */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, AREA_DE_WORK.WS_APOLICE_ED);

                /*" -4094- MOVE SINISHIS-COD-OPERACAO TO WS-OPERACAO-ED */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO, AREA_DE_WORK.WS_OPERACAO_ED);

                /*" -4095- MOVE SINISHIS-OCORR-HISTORICO TO WS-SMALLINT(01) */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO, AREA_DE_WORK.WS_SMALLINT[01]);

                /*" -4099- STRING 'SINISTRO: ' WS-APOLICE-ED '; OPERACAO: ' WS-OPERACAO-ED '; OCORR-HIST: ' WS-SMALLINT(01) DELIMITED BY SIZE INTO LKERR-ELEMENTOS */
                #region STRING
                var spl25 = "SINISTRO: " + AREA_DE_WORK.WS_APOLICE_ED.GetMoveValues();
                spl25 += "; OPERACAO: ";
                var spl26 = AREA_DE_WORK.WS_OPERACAO_ED.GetMoveValues();
                spl26 += "; OCORR-HIST: ";
                var spl27 = AREA_DE_WORK.WS_SMALLINT[01].GetMoveValues();
                var results28 = spl25 + spl26 + spl27;
                _.Move(results28, RSGEWERR.LKERR_REG.LKERR_ELEMENTOS);
                #endregion

                /*" -4100- GO TO P9999-CHAMA-RSGESERR */

                P9999_CHAMA_RSGESERR(); //GOTO
                return;

                /*" -4100- END-IF. */
            }


        }

        [StopWatch]
        /*" P7011-SI3-UPDATE-DB-UPDATE-1 */
        public void P7011_SI3_UPDATE_DB_UPDATE_1()
        {
            /*" -4083- EXEC SQL UPDATE SEGUROS.SINISTRO_HISTORICO SET DATA_MOVIMENTO = :SINISHIS-DATA-MOVIMENTO ,HORA_OPERACAO = CURRENT TIME ,SIT_REGISTRO = '1' ,TIMESTAMP = CURRENT TIMESTAMP ,NOM_PROGRAMA = :SINISHIS-NOM-PROGRAMA :WH-PROGRAMA-NULL WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND COD_OPERACAO = :SINISHIS-COD-OPERACAO END-EXEC. */

            var p7011_SI3_UPDATE_DB_UPDATE_1_Update1 = new P7011_SI3_UPDATE_DB_UPDATE_1_Update1()
            {
                SINISHIS_NOM_PROGRAMA = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOM_PROGRAMA.ToString(),
                WH_PROGRAMA_NULL = WH_PROGRAMA_NULL.ToString(),
                SINISHIS_DATA_MOVIMENTO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO.ToString(),
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
                SINISHIS_COD_OPERACAO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.ToString(),
            };

            P7011_SI3_UPDATE_DB_UPDATE_1_Update1.Execute(p7011_SI3_UPDATE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P7011_SI3_EXIT*/

        [StopWatch]
        /*" P7237-SI1-INSERT */
        private void P7237_SI1_INSERT(bool isPerform = false)
        {
            /*" -4115- DISPLAY 'P7237-SI1-INSERT' */
            _.Display($"P7237-SI1-INSERT");

            /*" -4117- MOVE ZEROS TO SI237-QTD-RETORNO-ARQH SI237-SEQ-MOVTO-ARQH. */
            _.Move(0, SI237.DCLSI_MOVTO_PGTO_COB.SI237_QTD_RETORNO_ARQH, SI237.DCLSI_MOVTO_PGTO_COB.SI237_SEQ_MOVTO_ARQH);

            /*" -4119- MOVE SPACES TO SI237-STA-MOVTO-HISTORICO. */
            _.Move("", SI237.DCLSI_MOVTO_PGTO_COB.SI237_STA_MOVTO_HISTORICO);

            /*" -4122- MOVE -1 TO WH-MOVTO-ARQH-NULL WH-MOVTO-HISTORICO-NULL. */
            _.Move(-1, WH_MOVTO_ARQH_NULL, WH_MOVTO_HISTORICO_NULL);

            /*" -4168- PERFORM P7237_SI1_INSERT_DB_INSERT_1 */

            P7237_SI1_INSERT_DB_INSERT_1();

            /*" -4171- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4172- MOVE 'P7237-SI1-INSERT' TO LKERR-ROTINA */
                _.Move("P7237-SI1-INSERT", RSGEWERR.LKERR_REG.LKERR_ROTINA);

                /*" -4173- MOVE 'INSERT' TO LKERR-FUNCAO */
                _.Move("INSERT", RSGEWERR.LKERR_REG.LKERR_FUNCAO);

                /*" -4176- MOVE 'SEGUROS.SI_MOVTO_PGTO_COB' TO LKERR-OBJETOS */
                _.Move("SEGUROS.SI_MOVTO_PGTO_COB", RSGEWERR.LKERR_REG.LKERR_OBJETOS);

                /*" -4177- MOVE SI237-NUM-SINISTRO TO WS-APOLICE-ED */
                _.Move(SI237.DCLSI_MOVTO_PGTO_COB.SI237_NUM_SINISTRO, AREA_DE_WORK.WS_APOLICE_ED);

                /*" -4178- MOVE SI237-COD-OPERACAO TO WS-OPERACAO-ED */
                _.Move(SI237.DCLSI_MOVTO_PGTO_COB.SI237_COD_OPERACAO, AREA_DE_WORK.WS_OPERACAO_ED);

                /*" -4180- MOVE SI237-OCORR-HISTORICO TO WS-SMALLINT(01) */
                _.Move(SI237.DCLSI_MOVTO_PGTO_COB.SI237_OCORR_HISTORICO, AREA_DE_WORK.WS_SMALLINT[01]);

                /*" -4185- STRING 'SINISTRO: ' WS-APOLICE-ED '; OPERACAO: ' WS-OPERACAO-ED '; OCORR-HIST: ' WS-SMALLINT(01) '; STATUS ENVIO: ' SI237-STA-ENVIO-MOVIMENTO DELIMITED BY SIZE INTO LKERR-ELEMENTOS */
                #region STRING
                var spl28 = "SINISTRO: " + AREA_DE_WORK.WS_APOLICE_ED.GetMoveValues();
                spl28 += "; OPERACAO: ";
                var spl29 = AREA_DE_WORK.WS_OPERACAO_ED.GetMoveValues();
                spl29 += "; OCORR-HIST: ";
                var spl30 = AREA_DE_WORK.WS_SMALLINT[01].GetMoveValues();
                spl30 += "; STATUS ENVIO: ";
                var spl31 = SI237.DCLSI_MOVTO_PGTO_COB.SI237_STA_ENVIO_MOVIMENTO.GetMoveValues();
                var results32 = spl28 + spl29 + spl30 + spl31;
                _.Move(results32, RSGEWERR.LKERR_REG.LKERR_ELEMENTOS);
                #endregion

                /*" -4186- GO TO P9999-CHAMA-RSGESERR */

                P9999_CHAMA_RSGESERR(); //GOTO
                return;

                /*" -4186- END-IF. */
            }


        }

        [StopWatch]
        /*" P7237-SI1-INSERT-DB-INSERT-1 */
        public void P7237_SI1_INSERT_DB_INSERT_1()
        {
            /*" -4168- EXEC SQL INSERT INTO SEGUROS.SI_MOVTO_PGTO_COB ( NUM_SINISTRO ,OCORR_HISTORICO ,IDE_SISTEMA ,COD_OPERACAO ,NUM_ID_ENVIO ,SEQ_ID_ENVIO_HIST ,STA_ENVIO_MOVIMENTO ,DTA_SI_ENVIO ,DTA_SI_RETORNO_H ,DTA_EFETIVO_PGTO ,COD_USUARIO ,COD_PROGRAMA ,DTH_CADASTRAMENTO ,SEQ_MOVTO_ARQH ,STA_MOVTO_HISTORICO ,QTD_RETORNO_ARQH ,COD_EMPRESA ) VALUES ( :SI237-NUM-SINISTRO ,:SI237-OCORR-HISTORICO ,:SI237-IDE-SISTEMA ,:SI237-COD-OPERACAO ,:SI237-NUM-ID-ENVIO :WH-ID-ENVIO-NULL ,:SI237-SEQ-ID-ENVIO-HIST :WH-ID-ENVIO-HIST-NULL ,:SI237-STA-ENVIO-MOVIMENTO ,:SI237-DTA-SI-ENVIO :WH-SI-ENVIO-NULL ,:SI237-DTA-SI-RETORNO-H :WH-SI-RETORNO-H-NULL ,:SI237-DTA-EFETIVO-PGTO :WH-EFETIVO-PGTO-NULL ,:SI237-COD-USUARIO ,:SI237-COD-PROGRAMA ,CURRENT TIMESTAMP ,:SI237-SEQ-MOVTO-ARQH :WH-MOVTO-ARQH-NULL ,:SI237-STA-MOVTO-HISTORICO :WH-MOVTO-HISTORICO-NULL ,:SI237-QTD-RETORNO-ARQH ,:SI237-COD-EMPRESA ) END-EXEC. */

            var p7237_SI1_INSERT_DB_INSERT_1_Insert1 = new P7237_SI1_INSERT_DB_INSERT_1_Insert1()
            {
                SI237_NUM_SINISTRO = SI237.DCLSI_MOVTO_PGTO_COB.SI237_NUM_SINISTRO.ToString(),
                SI237_OCORR_HISTORICO = SI237.DCLSI_MOVTO_PGTO_COB.SI237_OCORR_HISTORICO.ToString(),
                SI237_IDE_SISTEMA = SI237.DCLSI_MOVTO_PGTO_COB.SI237_IDE_SISTEMA.ToString(),
                SI237_COD_OPERACAO = SI237.DCLSI_MOVTO_PGTO_COB.SI237_COD_OPERACAO.ToString(),
                SI237_NUM_ID_ENVIO = SI237.DCLSI_MOVTO_PGTO_COB.SI237_NUM_ID_ENVIO.ToString(),
                WH_ID_ENVIO_NULL = WH_ID_ENVIO_NULL.ToString(),
                SI237_SEQ_ID_ENVIO_HIST = SI237.DCLSI_MOVTO_PGTO_COB.SI237_SEQ_ID_ENVIO_HIST.ToString(),
                WH_ID_ENVIO_HIST_NULL = WH_ID_ENVIO_HIST_NULL.ToString(),
                SI237_STA_ENVIO_MOVIMENTO = SI237.DCLSI_MOVTO_PGTO_COB.SI237_STA_ENVIO_MOVIMENTO.ToString(),
                SI237_DTA_SI_ENVIO = SI237.DCLSI_MOVTO_PGTO_COB.SI237_DTA_SI_ENVIO.ToString(),
                WH_SI_ENVIO_NULL = WH_SI_ENVIO_NULL.ToString(),
                SI237_DTA_SI_RETORNO_H = SI237.DCLSI_MOVTO_PGTO_COB.SI237_DTA_SI_RETORNO_H.ToString(),
                WH_SI_RETORNO_H_NULL = WH_SI_RETORNO_H_NULL.ToString(),
                SI237_DTA_EFETIVO_PGTO = SI237.DCLSI_MOVTO_PGTO_COB.SI237_DTA_EFETIVO_PGTO.ToString(),
                WH_EFETIVO_PGTO_NULL = WH_EFETIVO_PGTO_NULL.ToString(),
                SI237_COD_USUARIO = SI237.DCLSI_MOVTO_PGTO_COB.SI237_COD_USUARIO.ToString(),
                SI237_COD_PROGRAMA = SI237.DCLSI_MOVTO_PGTO_COB.SI237_COD_PROGRAMA.ToString(),
                SI237_SEQ_MOVTO_ARQH = SI237.DCLSI_MOVTO_PGTO_COB.SI237_SEQ_MOVTO_ARQH.ToString(),
                WH_MOVTO_ARQH_NULL = WH_MOVTO_ARQH_NULL.ToString(),
                SI237_STA_MOVTO_HISTORICO = SI237.DCLSI_MOVTO_PGTO_COB.SI237_STA_MOVTO_HISTORICO.ToString(),
                WH_MOVTO_HISTORICO_NULL = WH_MOVTO_HISTORICO_NULL.ToString(),
                SI237_QTD_RETORNO_ARQH = SI237.DCLSI_MOVTO_PGTO_COB.SI237_QTD_RETORNO_ARQH.ToString(),
                SI237_COD_EMPRESA = SI237.DCLSI_MOVTO_PGTO_COB.SI237_COD_EMPRESA.ToString(),
            };

            P7237_SI1_INSERT_DB_INSERT_1_Insert1.Execute(p7237_SI1_INSERT_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P7237_SI1_EXIT*/

        [StopWatch]
        /*" P7237-SI2-SELECT */
        private void P7237_SI2_SELECT(bool isPerform = false)
        {
            /*" -4201- DISPLAY 'P7237-SI2-SELECT' */
            _.Display($"P7237-SI2-SELECT");

            /*" -4203- MOVE 'NAO' TO WS-SI237-SQL100. */
            _.Move("NAO", AREA_DE_WORK.WS_SI237_SQL100);

            /*" -4221- PERFORM P7237_SI2_SELECT_DB_SELECT_1 */

            P7237_SI2_SELECT_DB_SELECT_1();

            /*" -4224- IF SQLCODE NOT = ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -4225- MOVE 'ERRO NO SELECT' TO LK-RSGEWCNT-MENSAGEM-RETORNO */
                _.Move("ERRO NO SELECT", RSGEWCNT.LK_RSGEWCNT_MENSAGEM_RETORNO);

                /*" -4227- MOVE 'SEGUROS.SI_MOVTO_PGTO_COB' TO LK-RSGEWCNT-NOME-TABELA */
                _.Move("SEGUROS.SI_MOVTO_PGTO_COB", RSGEWCNT.LK_RSGEWCNT_NOME_TABELA);

                /*" -4228- MOVE 2 TO LK-RSGEWCNT-IND-ERRO */
                _.Move(2, RSGEWCNT.LK_RSGEWCNT_IND_ERRO);

                /*" -4229- MOVE SQLCODE TO LK-RSGEWCNT-SQLCODE */
                _.Move(DB.SQLCODE, RSGEWCNT.LK_RSGEWCNT_SQLCODE);

                /*" -4230- MOVE SQLERRMC TO LK-RSGEWCNT-SQLERRMC */
                _.Move(DB.SQLERRMC, RSGEWCNT.LK_RSGEWCNT_SQLERRMC);

                /*" -4232- MOVE 'P7237-SI2-SELECT' TO LKERR-ROTINA */
                _.Move("P7237-SI2-SELECT", RSGEWERR.LKERR_REG.LKERR_ROTINA);

                /*" -4233- MOVE 'SELECT' TO LKERR-FUNCAO */
                _.Move("SELECT", RSGEWERR.LKERR_REG.LKERR_FUNCAO);

                /*" -4236- MOVE 'SEGUROS.SI_MOVTO_PGTO_COB' TO LKERR-OBJETOS */
                _.Move("SEGUROS.SI_MOVTO_PGTO_COB", RSGEWERR.LKERR_REG.LKERR_OBJETOS);

                /*" -4237- MOVE SI237-NUM-SINISTRO TO WS-APOLICE-ED */
                _.Move(SI237.DCLSI_MOVTO_PGTO_COB.SI237_NUM_SINISTRO, AREA_DE_WORK.WS_APOLICE_ED);

                /*" -4238- MOVE SI237-COD-OPERACAO TO WS-OPERACAO-ED */
                _.Move(SI237.DCLSI_MOVTO_PGTO_COB.SI237_COD_OPERACAO, AREA_DE_WORK.WS_OPERACAO_ED);

                /*" -4240- MOVE SI237-OCORR-HISTORICO TO WS-SMALLINT(01) */
                _.Move(SI237.DCLSI_MOVTO_PGTO_COB.SI237_OCORR_HISTORICO, AREA_DE_WORK.WS_SMALLINT[01]);

                /*" -4244- STRING 'SINISTRO: ' WS-APOLICE-ED '; OPERACAO: ' WS-OPERACAO-ED '; OCORR-HIST: ' WS-SMALLINT(01) DELIMITED BY SIZE INTO LKERR-ELEMENTOS */
                #region STRING
                var spl32 = "SINISTRO: " + AREA_DE_WORK.WS_APOLICE_ED.GetMoveValues();
                spl32 += "; OPERACAO: ";
                var spl33 = AREA_DE_WORK.WS_OPERACAO_ED.GetMoveValues();
                spl33 += "; OCORR-HIST: ";
                var spl34 = AREA_DE_WORK.WS_SMALLINT[01].GetMoveValues();
                var results35 = spl32 + spl33 + spl34;
                _.Move(results35, RSGEWERR.LKERR_REG.LKERR_ELEMENTOS);
                #endregion

                /*" -4245- GO TO P9999-CHAMA-RSGESERR */

                P9999_CHAMA_RSGESERR(); //GOTO
                return;

                /*" -4247- END-IF. */
            }


            /*" -4248- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -4249- MOVE 'SIM' TO WS-SI237-SQL100 */
                _.Move("SIM", AREA_DE_WORK.WS_SI237_SQL100);

                /*" -4249- END-IF. */
            }


        }

        [StopWatch]
        /*" P7237-SI2-SELECT-DB-SELECT-1 */
        public void P7237_SI2_SELECT_DB_SELECT_1()
        {
            /*" -4221- EXEC SQL SELECT VALUE(NUM_ID_ENVIO, 0) ,VALUE(SEQ_ID_ENVIO_HIST, 0) ,STA_ENVIO_MOVIMENTO INTO :SI237-NUM-ID-ENVIO ,:SI237-SEQ-ID-ENVIO-HIST ,:SI237-STA-ENVIO-MOVIMENTO FROM SEGUROS.SI_MOVTO_PGTO_COB WHERE NUM_SINISTRO = :SI237-NUM-SINISTRO AND COD_OPERACAO = :SI237-COD-OPERACAO AND OCORR_HISTORICO = :SI237-OCORR-HISTORICO AND IDE_SISTEMA = 'SI' WITH UR END-EXEC. */

            var p7237_SI2_SELECT_DB_SELECT_1_Query1 = new P7237_SI2_SELECT_DB_SELECT_1_Query1()
            {
                SI237_OCORR_HISTORICO = SI237.DCLSI_MOVTO_PGTO_COB.SI237_OCORR_HISTORICO.ToString(),
                SI237_NUM_SINISTRO = SI237.DCLSI_MOVTO_PGTO_COB.SI237_NUM_SINISTRO.ToString(),
                SI237_COD_OPERACAO = SI237.DCLSI_MOVTO_PGTO_COB.SI237_COD_OPERACAO.ToString(),
            };

            var executed_1 = P7237_SI2_SELECT_DB_SELECT_1_Query1.Execute(p7237_SI2_SELECT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SI237_NUM_ID_ENVIO, SI237.DCLSI_MOVTO_PGTO_COB.SI237_NUM_ID_ENVIO);
                _.Move(executed_1.SI237_SEQ_ID_ENVIO_HIST, SI237.DCLSI_MOVTO_PGTO_COB.SI237_SEQ_ID_ENVIO_HIST);
                _.Move(executed_1.SI237_STA_ENVIO_MOVIMENTO, SI237.DCLSI_MOVTO_PGTO_COB.SI237_STA_ENVIO_MOVIMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P7237_SI2_EXIT*/

        [StopWatch]
        /*" P7237-SI3-UPDATE */
        private void P7237_SI3_UPDATE(bool isPerform = false)
        {
            /*" -4264- DISPLAY 'P7237-SI3-UPDATE' */
            _.Display($"P7237-SI3-UPDATE");

            /*" -4265- MOVE 'NAO' TO WS-SI237-SQL100. */
            _.Move("NAO", AREA_DE_WORK.WS_SI237_SQL100);

            /*" -4268- MOVE 1 TO WH-ID-ENVIO-NULL WH-ID-ENVIO-HIST-NULL. */
            _.Move(1, WH_ID_ENVIO_NULL, WH_ID_ENVIO_HIST_NULL);

            /*" -4271- MOVE SPACES TO SI237-DTA-SI-RETORNO-H SI237-DTA-SI-ENVIO SI237-DTA-EFETIVO-PGTO. */
            _.Move("", SI237.DCLSI_MOVTO_PGTO_COB.SI237_DTA_SI_RETORNO_H, SI237.DCLSI_MOVTO_PGTO_COB.SI237_DTA_SI_ENVIO, SI237.DCLSI_MOVTO_PGTO_COB.SI237_DTA_EFETIVO_PGTO);

            /*" -4275- MOVE -1 TO WH-EFETIVO-PGTO-NULL WH-SI-ENVIO-NULL WH-SI-RETORNO-H-NULL. */
            _.Move(-1, WH_EFETIVO_PGTO_NULL, WH_SI_ENVIO_NULL, WH_SI_RETORNO_H_NULL);

            /*" -4301- PERFORM P7237_SI3_UPDATE_DB_UPDATE_1 */

            P7237_SI3_UPDATE_DB_UPDATE_1();

            /*" -4305- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4306- MOVE 'ERRO NO UPDATE' TO LK-RSGEWCNT-MENSAGEM-RETORNO */
                _.Move("ERRO NO UPDATE", RSGEWCNT.LK_RSGEWCNT_MENSAGEM_RETORNO);

                /*" -4308- MOVE 'SEGUROS.SI_MOVTO_PGTO_COB' TO LK-RSGEWCNT-NOME-TABELA */
                _.Move("SEGUROS.SI_MOVTO_PGTO_COB", RSGEWCNT.LK_RSGEWCNT_NOME_TABELA);

                /*" -4309- MOVE 2 TO LK-RSGEWCNT-IND-ERRO */
                _.Move(2, RSGEWCNT.LK_RSGEWCNT_IND_ERRO);

                /*" -4310- MOVE SQLCODE TO LK-RSGEWCNT-SQLCODE */
                _.Move(DB.SQLCODE, RSGEWCNT.LK_RSGEWCNT_SQLCODE);

                /*" -4311- MOVE SQLERRMC TO LK-RSGEWCNT-SQLERRMC */
                _.Move(DB.SQLERRMC, RSGEWCNT.LK_RSGEWCNT_SQLERRMC);

                /*" -4313- MOVE 'P7237-SI3-UPDATE' TO LKERR-ROTINA */
                _.Move("P7237-SI3-UPDATE", RSGEWERR.LKERR_REG.LKERR_ROTINA);

                /*" -4314- MOVE 'UPDATE' TO LKERR-FUNCAO */
                _.Move("UPDATE", RSGEWERR.LKERR_REG.LKERR_FUNCAO);

                /*" -4317- MOVE 'SEGUROS.SI_MOVTO_PGTO_COB' TO LKERR-OBJETOS */
                _.Move("SEGUROS.SI_MOVTO_PGTO_COB", RSGEWERR.LKERR_REG.LKERR_OBJETOS);

                /*" -4318- MOVE SI237-NUM-SINISTRO TO WS-APOLICE-ED */
                _.Move(SI237.DCLSI_MOVTO_PGTO_COB.SI237_NUM_SINISTRO, AREA_DE_WORK.WS_APOLICE_ED);

                /*" -4319- MOVE SI237-COD-OPERACAO TO WS-OPERACAO-ED */
                _.Move(SI237.DCLSI_MOVTO_PGTO_COB.SI237_COD_OPERACAO, AREA_DE_WORK.WS_OPERACAO_ED);

                /*" -4321- MOVE SI237-OCORR-HISTORICO TO WS-SMALLINT(01) */
                _.Move(SI237.DCLSI_MOVTO_PGTO_COB.SI237_OCORR_HISTORICO, AREA_DE_WORK.WS_SMALLINT[01]);

                /*" -4325- STRING 'SINISTRO: ' WS-APOLICE-ED '; OPERACAO: ' WS-OPERACAO-ED '; OCORR-HIST: ' WS-SMALLINT(01) DELIMITED BY SIZE INTO LKERR-ELEMENTOS */
                #region STRING
                var spl35 = "SINISTRO: " + AREA_DE_WORK.WS_APOLICE_ED.GetMoveValues();
                spl35 += "; OPERACAO: ";
                var spl36 = AREA_DE_WORK.WS_OPERACAO_ED.GetMoveValues();
                spl36 += "; OCORR-HIST: ";
                var spl37 = AREA_DE_WORK.WS_SMALLINT[01].GetMoveValues();
                var results38 = spl35 + spl36 + spl37;
                _.Move(results38, RSGEWERR.LKERR_REG.LKERR_ELEMENTOS);
                #endregion

                /*" -4326- GO TO P9999-CHAMA-RSGESERR */

                P9999_CHAMA_RSGESERR(); //GOTO
                return;

                /*" -4326- END-IF. */
            }


        }

        [StopWatch]
        /*" P7237-SI3-UPDATE-DB-UPDATE-1 */
        public void P7237_SI3_UPDATE_DB_UPDATE_1()
        {
            /*" -4301- EXEC SQL UPDATE SEGUROS.SI_MOVTO_PGTO_COB SET NUM_ID_ENVIO = :SI237-NUM-ID-ENVIO :WH-ID-ENVIO-NULL ,SEQ_ID_ENVIO_HIST = :SI237-SEQ-ID-ENVIO-HIST :WH-ID-ENVIO-HIST-NULL ,STA_ENVIO_MOVIMENTO = :SI237-STA-ENVIO-MOVIMENTO ,DTA_SI_RETORNO_H = :SI237-DTA-SI-RETORNO-H :WH-SI-RETORNO-H-NULL ,DTA_SI_ENVIO = :SI237-DTA-SI-ENVIO :WH-SI-ENVIO-NULL ,DTA_EFETIVO_PGTO = :SI237-DTA-EFETIVO-PGTO :WH-EFETIVO-PGTO-NULL ,COD_USUARIO = :SINISHIS-COD-USUARIO ,COD_PROGRAMA = :GE420-NOM-PROGRAMA ,DTH_CADASTRAMENTO = CURRENT TIMESTAMP WHERE NUM_SINISTRO = :SI237-NUM-SINISTRO AND COD_OPERACAO = :SI237-COD-OPERACAO AND OCORR_HISTORICO = :SI237-OCORR-HISTORICO END-EXEC. */

            var p7237_SI3_UPDATE_DB_UPDATE_1_Update1 = new P7237_SI3_UPDATE_DB_UPDATE_1_Update1()
            {
                SI237_SEQ_ID_ENVIO_HIST = SI237.DCLSI_MOVTO_PGTO_COB.SI237_SEQ_ID_ENVIO_HIST.ToString(),
                WH_ID_ENVIO_HIST_NULL = WH_ID_ENVIO_HIST_NULL.ToString(),
                SI237_DTA_SI_RETORNO_H = SI237.DCLSI_MOVTO_PGTO_COB.SI237_DTA_SI_RETORNO_H.ToString(),
                WH_SI_RETORNO_H_NULL = WH_SI_RETORNO_H_NULL.ToString(),
                SI237_DTA_EFETIVO_PGTO = SI237.DCLSI_MOVTO_PGTO_COB.SI237_DTA_EFETIVO_PGTO.ToString(),
                WH_EFETIVO_PGTO_NULL = WH_EFETIVO_PGTO_NULL.ToString(),
                SI237_NUM_ID_ENVIO = SI237.DCLSI_MOVTO_PGTO_COB.SI237_NUM_ID_ENVIO.ToString(),
                WH_ID_ENVIO_NULL = WH_ID_ENVIO_NULL.ToString(),
                SI237_DTA_SI_ENVIO = SI237.DCLSI_MOVTO_PGTO_COB.SI237_DTA_SI_ENVIO.ToString(),
                WH_SI_ENVIO_NULL = WH_SI_ENVIO_NULL.ToString(),
                SI237_STA_ENVIO_MOVIMENTO = SI237.DCLSI_MOVTO_PGTO_COB.SI237_STA_ENVIO_MOVIMENTO.ToString(),
                SINISHIS_COD_USUARIO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_USUARIO.ToString(),
                GE420_NOM_PROGRAMA = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NOM_PROGRAMA.ToString(),
                SI237_OCORR_HISTORICO = SI237.DCLSI_MOVTO_PGTO_COB.SI237_OCORR_HISTORICO.ToString(),
                SI237_NUM_SINISTRO = SI237.DCLSI_MOVTO_PGTO_COB.SI237_NUM_SINISTRO.ToString(),
                SI237_COD_OPERACAO = SI237.DCLSI_MOVTO_PGTO_COB.SI237_COD_OPERACAO.ToString(),
            };

            P7237_SI3_UPDATE_DB_UPDATE_1_Update1.Execute(p7237_SI3_UPDATE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P7237_SI3_EXIT*/

        [StopWatch]
        /*" P7239-SI2-SELECT */
        private void P7239_SI2_SELECT(bool isPerform = false)
        {
            /*" -4345- DISPLAY 'P7239-SI2-SELECT' */
            _.Display($"P7239-SI2-SELECT");

            /*" -4347- MOVE 'NAO' TO WS-SI239-SQL100. */
            _.Move("NAO", AREA_DE_WORK.WS_SI239_SQL100);

            /*" -4372- PERFORM P7239_SI2_SELECT_DB_SELECT_1 */

            P7239_SI2_SELECT_DB_SELECT_1();

            /*" -4375- IF SQLCODE NOT = ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -4376- MOVE 'ERRO NO SELECT' TO LK-RSGEWCNT-MENSAGEM-RETORNO */
                _.Move("ERRO NO SELECT", RSGEWCNT.LK_RSGEWCNT_MENSAGEM_RETORNO);

                /*" -4378- MOVE 'SEGUROS.SI_OPERACAO_EVENTO' TO LK-RSGEWCNT-NOME-TABELA */
                _.Move("SEGUROS.SI_OPERACAO_EVENTO", RSGEWCNT.LK_RSGEWCNT_NOME_TABELA);

                /*" -4379- MOVE 2 TO LK-RSGEWCNT-IND-ERRO */
                _.Move(2, RSGEWCNT.LK_RSGEWCNT_IND_ERRO);

                /*" -4380- MOVE SQLCODE TO LK-RSGEWCNT-SQLCODE */
                _.Move(DB.SQLCODE, RSGEWCNT.LK_RSGEWCNT_SQLCODE);

                /*" -4381- MOVE SQLERRMC TO LK-RSGEWCNT-SQLERRMC */
                _.Move(DB.SQLERRMC, RSGEWCNT.LK_RSGEWCNT_SQLERRMC);

                /*" -4383- MOVE 'P7239-SI2-SELECT' TO LKERR-ROTINA */
                _.Move("P7239-SI2-SELECT", RSGEWERR.LKERR_REG.LKERR_ROTINA);

                /*" -4384- MOVE 'SELECT' TO LKERR-FUNCAO */
                _.Move("SELECT", RSGEWERR.LKERR_REG.LKERR_FUNCAO);

                /*" -4387- MOVE 'SEGUROS.SI_OPERACAO_EVENTO' TO LKERR-OBJETOS */
                _.Move("SEGUROS.SI_OPERACAO_EVENTO", RSGEWERR.LKERR_REG.LKERR_OBJETOS);

                /*" -4388- MOVE SI239-COD-OPERACAO TO WS-SMALLINT(01) */
                _.Move(SI239.DCLSI_OPERACAO_EVENTO.SI239_COD_OPERACAO, AREA_DE_WORK.WS_SMALLINT[01]);

                /*" -4390- STRING 'OPERACAO: ' WS-SMALLINT(01) DELIMITED BY SIZE INTO LKERR-ELEMENTOS */
                #region STRING
                var spl38 = "OPERACAO: " + AREA_DE_WORK.WS_SMALLINT[01].GetMoveValues();
                _.Move(spl38, RSGEWERR.LKERR_REG.LKERR_ELEMENTOS);
                #endregion

                /*" -4391- GO TO P9999-CHAMA-RSGESERR */

                P9999_CHAMA_RSGESERR(); //GOTO
                return;

                /*" -4393- END-IF. */
            }


            /*" -4394- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -4395- MOVE 'SIM' TO WS-SI239-SQL100 */
                _.Move("SIM", AREA_DE_WORK.WS_SI239_SQL100);

                /*" -4396- ELSE */
            }
            else
            {


                /*" -4397- EVALUATE PRODUTO-COD-EMPRESA */
                switch (PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA.Value)
                {

                    /*" -4398- WHEN 10 */
                    case 10:

                        /*" -4399- MOVE 'C010' TO SI239-COD-EMPRESA-SAP */
                        _.Move("C010", SI239.DCLSI_OPERACAO_EVENTO.SI239_COD_EMPRESA_SAP);

                        /*" -4400- WHEN 11 */
                        break;
                    case 11:

                        /*" -4401- MOVE 'D011' TO SI239-COD-EMPRESA-SAP */
                        _.Move("D011", SI239.DCLSI_OPERACAO_EVENTO.SI239_COD_EMPRESA_SAP);

                        /*" -4402- WHEN OTHER */
                        break;
                    default:

                        /*" -4403- MOVE 'C000' TO SI239-COD-EMPRESA-SAP */
                        _.Move("C000", SI239.DCLSI_OPERACAO_EVENTO.SI239_COD_EMPRESA_SAP);

                        /*" -4404- END-EVALUATE */
                        break;
                }


                /*" -4404- END-IF. */
            }


        }

        [StopWatch]
        /*" P7239-SI2-SELECT-DB-SELECT-1 */
        public void P7239_SI2_SELECT_DB_SELECT_1()
        {
            /*" -4372- EXEC SQL SELECT IDE_SISTEMA ,COD_OPERACAO ,COD_EVENTO_SAP ,COD_EVENTO_SAP_SFH ,VALUE(COD_EVENTO_SAP_JUD, COD_EVENTO_SAP) ,COD_EMPRESA_SAP ,COD_SISTEMA_SAP ,COD_ORIGEM_SAP INTO :SI239-IDE-SISTEMA ,:SI239-COD-OPERACAO ,:SI239-COD-EVENTO-SAP ,:SI239-COD-EVENTO-SAP-SFH ,:SI239-COD-EVENTO-SAP-JUD ,:SI239-COD-EMPRESA-SAP ,:SI239-COD-SISTEMA-SAP ,:SI239-COD-ORIGEM-SAP FROM SEGUROS.SI_OPERACAO_EVENTO WHERE IDE_SISTEMA = 'SI' AND COD_OPERACAO = :SI239-COD-OPERACAO AND (DTA_FIM_VIGENCIA = '9999-12-31' OR DTA_FIM_VIGENCIA IS NULL) WITH UR END-EXEC. */

            var p7239_SI2_SELECT_DB_SELECT_1_Query1 = new P7239_SI2_SELECT_DB_SELECT_1_Query1()
            {
                SI239_COD_OPERACAO = SI239.DCLSI_OPERACAO_EVENTO.SI239_COD_OPERACAO.ToString(),
            };

            var executed_1 = P7239_SI2_SELECT_DB_SELECT_1_Query1.Execute(p7239_SI2_SELECT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SI239_IDE_SISTEMA, SI239.DCLSI_OPERACAO_EVENTO.SI239_IDE_SISTEMA);
                _.Move(executed_1.SI239_COD_OPERACAO, SI239.DCLSI_OPERACAO_EVENTO.SI239_COD_OPERACAO);
                _.Move(executed_1.SI239_COD_EVENTO_SAP, SI239.DCLSI_OPERACAO_EVENTO.SI239_COD_EVENTO_SAP);
                _.Move(executed_1.SI239_COD_EVENTO_SAP_SFH, SI239.DCLSI_OPERACAO_EVENTO.SI239_COD_EVENTO_SAP_SFH);
                _.Move(executed_1.SI239_COD_EVENTO_SAP_JUD, SI239.DCLSI_OPERACAO_EVENTO.SI239_COD_EVENTO_SAP_JUD);
                _.Move(executed_1.SI239_COD_EMPRESA_SAP, SI239.DCLSI_OPERACAO_EVENTO.SI239_COD_EMPRESA_SAP);
                _.Move(executed_1.SI239_COD_SISTEMA_SAP, SI239.DCLSI_OPERACAO_EVENTO.SI239_COD_SISTEMA_SAP);
                _.Move(executed_1.SI239_COD_ORIGEM_SAP, SI239.DCLSI_OPERACAO_EVENTO.SI239_COD_ORIGEM_SAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P7239_SI2_EXIT*/

        [StopWatch]
        /*" P7419-GE1-INSERT */
        private void P7419_GE1_INSERT(bool isPerform = false)
        {
            /*" -4419- DISPLAY 'P7419-GE1-INSERT' */
            _.Display($"P7419-GE1-INSERT");

            /*" -4420- MOVE GE420-NUM-ID-ENVIO TO GE419-NUM-ID-ENVIO */
            _.Move(GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_ID_ENVIO, GE419.DCLGE_MOVTO_TRIBUTO.GE419_NUM_ID_ENVIO);

            /*" -4422- MOVE GE420-SEQ-ID-ENVIO-HIST TO GE419-SEQ-ID-ENVIO-HIST */
            _.Move(GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_SEQ_ID_ENVIO_HIST, GE419.DCLGE_MOVTO_TRIBUTO.GE419_SEQ_ID_ENVIO_HIST);

            /*" -4423- MOVE 1 TO GE419-IND-TP-TRIBUTO. */
            _.Move(1, GE419.DCLGE_MOVTO_TRIBUTO.GE419_IND_TP_TRIBUTO);

            /*" -4425- MOVE -1 TO WH-ALICOTA-NULL WH-TRIBUTO-NULL. */
            _.Move(-1, WH_ALICOTA_NULL, WH_TRIBUTO_NULL);

            /*" -4452- PERFORM P7419_GE1_INSERT_DB_INSERT_1 */

            P7419_GE1_INSERT_DB_INSERT_1();

            /*" -4455- IF SQLCODE NOT = ZEROS AND -803 */

            if (!DB.SQLCODE.In("00", "-803"))
            {

                /*" -4456- MOVE 'ERRO NO INSERT' TO LK-RSGEWCNT-MENSAGEM-RETORNO */
                _.Move("ERRO NO INSERT", RSGEWCNT.LK_RSGEWCNT_MENSAGEM_RETORNO);

                /*" -4458- MOVE 'SEGUROS.GE_MOVTO_TRIBUTO' TO LK-RSGEWCNT-NOME-TABELA */
                _.Move("SEGUROS.GE_MOVTO_TRIBUTO", RSGEWCNT.LK_RSGEWCNT_NOME_TABELA);

                /*" -4459- MOVE 2 TO LK-RSGEWCNT-IND-ERRO */
                _.Move(2, RSGEWCNT.LK_RSGEWCNT_IND_ERRO);

                /*" -4460- MOVE SQLCODE TO LK-RSGEWCNT-SQLCODE */
                _.Move(DB.SQLCODE, RSGEWCNT.LK_RSGEWCNT_SQLCODE);

                /*" -4461- MOVE SQLERRMC TO LK-RSGEWCNT-SQLERRMC */
                _.Move(DB.SQLERRMC, RSGEWCNT.LK_RSGEWCNT_SQLERRMC);

                /*" -4463- MOVE 'P7419-GE1-INSERT' TO LKERR-ROTINA */
                _.Move("P7419-GE1-INSERT", RSGEWERR.LKERR_REG.LKERR_ROTINA);

                /*" -4464- MOVE 'INSERT' TO LKERR-FUNCAO */
                _.Move("INSERT", RSGEWERR.LKERR_REG.LKERR_FUNCAO);

                /*" -4467- MOVE 'SEGUROS.GE_MOVTO_TRIBUTO' TO LKERR-OBJETOS */
                _.Move("SEGUROS.GE_MOVTO_TRIBUTO", RSGEWERR.LKERR_REG.LKERR_OBJETOS);

                /*" -4468- MOVE GE419-NUM-ID-ENVIO TO WS-BIGINT1-ED */
                _.Move(GE419.DCLGE_MOVTO_TRIBUTO.GE419_NUM_ID_ENVIO, AREA_DE_WORK.WS_BIGINT1_ED);

                /*" -4470- MOVE GE419-SEQ-ID-ENVIO-HIST TO WS-SMALLINT(03) */
                _.Move(GE419.DCLGE_MOVTO_TRIBUTO.GE419_SEQ_ID_ENVIO_HIST, AREA_DE_WORK.WS_SMALLINT[03]);

                /*" -4472- MOVE GE420-NUM-OCORR-HISTORICO TO WS-SMALLINT(02) */
                _.Move(GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_OCORR_HISTORICO, AREA_DE_WORK.WS_SMALLINT[02]);

                /*" -4474- MOVE GETIPIMP-COD-IMP-INTERNO TO WS-SMALLINT(01) */
                _.Move(GETIPIMP.DCLGE_TIPO_IMPOSTO.GETIPIMP_COD_IMP_INTERNO, AREA_DE_WORK.WS_SMALLINT[01]);

                /*" -4481- STRING 'ID_ENVIO: ' WS-BIGINT1-ED ' ;ID_ENVIO_HIST: ' WS-SMALLINT(03) ' ;NUM_SINISTRO: ' WS-APOLICE-ED ' ;OCORR_HISTORICO: ' WS-SMALLINT(02) ' ;COD_OPERACAO: ' WS-OPERACAO-ED ' ;COD_IMP_INTERNO: ' WS-SMALLINT(01) DELIMITED BY SIZE INTO LKERR-ELEMENTOS */
                #region STRING
                var spl39 = "ID_ENVIO: " + AREA_DE_WORK.WS_BIGINT1_ED.GetMoveValues();
                spl39 += " ;ID_ENVIO_HIST: ";
                var spl40 = AREA_DE_WORK.WS_SMALLINT[03].GetMoveValues();
                spl40 += " ;NUM_SINISTRO: ";
                var spl41 = AREA_DE_WORK.WS_APOLICE_ED.GetMoveValues();
                spl41 += " ;OCORR_HISTORICO: ";
                var spl42 = AREA_DE_WORK.WS_SMALLINT[02].GetMoveValues();
                spl42 += " ;COD_OPERACAO: ";
                var spl43 = AREA_DE_WORK.WS_OPERACAO_ED.GetMoveValues();
                spl43 += " ;COD_IMP_INTERNO: ";
                var spl44 = AREA_DE_WORK.WS_SMALLINT[01].GetMoveValues();
                var results45 = spl39 + spl40 + spl41 + spl42 + spl43 + spl44;
                _.Move(results45, RSGEWERR.LKERR_REG.LKERR_ELEMENTOS);
                #endregion

                /*" -4482- GO TO P9999-CHAMA-RSGESERR */

                P9999_CHAMA_RSGESERR(); //GOTO
                return;

                /*" -4484- END-IF. */
            }


            /*" -4485- IF SQLCODE = -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -4486- MOVE GE419-NUM-ID-ENVIO TO WS-BIGINT1-ED */
                _.Move(GE419.DCLGE_MOVTO_TRIBUTO.GE419_NUM_ID_ENVIO, AREA_DE_WORK.WS_BIGINT1_ED);

                /*" -4488- MOVE GE419-SEQ-ID-ENVIO-HIST TO WS-SMALLINT(03) */
                _.Move(GE419.DCLGE_MOVTO_TRIBUTO.GE419_SEQ_ID_ENVIO_HIST, AREA_DE_WORK.WS_SMALLINT[03]);

                /*" -4490- MOVE GE420-NUM-OCORR-HISTORICO TO WS-SMALLINT(02) */
                _.Move(GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_OCORR_HISTORICO, AREA_DE_WORK.WS_SMALLINT[02]);

                /*" -4492- MOVE GETIPIMP-COD-IMP-INTERNO TO WS-SMALLINT(01) */
                _.Move(GETIPIMP.DCLGE_TIPO_IMPOSTO.GETIPIMP_COD_IMP_INTERNO, AREA_DE_WORK.WS_SMALLINT[01]);

                /*" -4493- DISPLAY ' ' */
                _.Display($" ");

                /*" -4494- DISPLAY '***********************************************' */
                _.Display($"***********************************************");

                /*" -4496- DISPLAY '* SICP001S: ERRRO -803 NA ' 'SEGUROS.GE_MOVTO_TRIBUTO' */
                _.Display($"* SICP001S: ERRRO -803 NA SEGUROS.GE_MOVTO_TRIBUTO");

                /*" -4497- DISPLAY '* ID_ENVIO: ' WS-BIGINT1-ED */
                _.Display($"* ID_ENVIO: {AREA_DE_WORK.WS_BIGINT1_ED}");

                /*" -4498- DISPLAY '* ID_ENVIO_HIST: ' WS-SMALLINT(03) */
                _.Display($"* ID_ENVIO_HIST: {AREA_DE_WORK.WS_SMALLINT[3]}");

                /*" -4499- DISPLAY '* NUM_SINISTRO: ' WS-APOLICE-ED */
                _.Display($"* NUM_SINISTRO: {AREA_DE_WORK.WS_APOLICE_ED}");

                /*" -4500- DISPLAY '* OCORR_HISTORICO: ' WS-SMALLINT(02) */
                _.Display($"* OCORR_HISTORICO: {AREA_DE_WORK.WS_SMALLINT[2]}");

                /*" -4501- DISPLAY '* COD_OPERACAO: ' WS-OPERACAO-ED */
                _.Display($"* COD_OPERACAO: {AREA_DE_WORK.WS_OPERACAO_ED}");

                /*" -4502- DISPLAY '* COD_IMP_INTERNO: ' WS-SMALLINT(01) */
                _.Display($"* COD_IMP_INTERNO: {AREA_DE_WORK.WS_SMALLINT[1]}");

                /*" -4503- DISPLAY '* REGISTRO IGNORADO.  AVALIAR' */
                _.Display($"* REGISTRO IGNORADO.  AVALIAR");

                /*" -4504- DISPLAY '***********************************************' */
                _.Display($"***********************************************");

                /*" -4504- END-IF. */
            }


        }

        [StopWatch]
        /*" P7419-GE1-INSERT-DB-INSERT-1 */
        public void P7419_GE1_INSERT_DB_INSERT_1()
        {
            /*" -4452- EXEC SQL INSERT INTO SEGUROS.GE_MOVTO_TRIBUTO ( NUM_ID_ENVIO ,SEQ_ID_ENVIO_HIST ,COD_IMPOSTO_INTERNO ,COD_TRIBUTO_SAP ,IND_TP_TRIBUTO ,PCT_ALIQUOTA ,VLR_BASE_TRIB ,VLR_TRIBUTO ,NOM_PROGRAMA ,DTH_CADASTRAMENTO ) VALUES ( :GE419-NUM-ID-ENVIO ,:GE419-SEQ-ID-ENVIO-HIST ,:GE419-COD-IMPOSTO-INTERNO ,:GE419-COD-TRIBUTO-SAP ,:GE419-IND-TP-TRIBUTO ,:GE419-PCT-ALIQUOTA :WH-ALICOTA-NULL ,:GE419-VLR-BASE-TRIB ,:GE419-VLR-TRIBUTO :WH-TRIBUTO-NULL , 'SICP001S' , CURRENT TIMESTAMP ) END-EXEC. */

            var p7419_GE1_INSERT_DB_INSERT_1_Insert1 = new P7419_GE1_INSERT_DB_INSERT_1_Insert1()
            {
                GE419_NUM_ID_ENVIO = GE419.DCLGE_MOVTO_TRIBUTO.GE419_NUM_ID_ENVIO.ToString(),
                GE419_SEQ_ID_ENVIO_HIST = GE419.DCLGE_MOVTO_TRIBUTO.GE419_SEQ_ID_ENVIO_HIST.ToString(),
                GE419_COD_IMPOSTO_INTERNO = GE419.DCLGE_MOVTO_TRIBUTO.GE419_COD_IMPOSTO_INTERNO.ToString(),
                GE419_COD_TRIBUTO_SAP = GE419.DCLGE_MOVTO_TRIBUTO.GE419_COD_TRIBUTO_SAP.ToString(),
                GE419_IND_TP_TRIBUTO = GE419.DCLGE_MOVTO_TRIBUTO.GE419_IND_TP_TRIBUTO.ToString(),
                GE419_PCT_ALIQUOTA = GE419.DCLGE_MOVTO_TRIBUTO.GE419_PCT_ALIQUOTA.ToString(),
                WH_ALICOTA_NULL = WH_ALICOTA_NULL.ToString(),
                GE419_VLR_BASE_TRIB = GE419.DCLGE_MOVTO_TRIBUTO.GE419_VLR_BASE_TRIB.ToString(),
                GE419_VLR_TRIBUTO = GE419.DCLGE_MOVTO_TRIBUTO.GE419_VLR_TRIBUTO.ToString(),
                WH_TRIBUTO_NULL = WH_TRIBUTO_NULL.ToString(),
            };

            P7419_GE1_INSERT_DB_INSERT_1_Insert1.Execute(p7419_GE1_INSERT_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P7419_GE1_EXIT*/

        [StopWatch]
        /*" P7420-GE1-INSERT */
        private void P7420_GE1_INSERT(bool isPerform = false)
        {
            /*" -4519- DISPLAY 'P7420-GE1-INSERT' */
            _.Display($"P7420-GE1-INSERT");

            /*" -4520- IF GE420-DTA-AVISO = '1212-12-12' */

            if (GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DTA_AVISO == "1212-12-12")
            {

                /*" -4521- MOVE -1 TO WH-AVISO-NULL */
                _.Move(-1, WH_AVISO_NULL);

                /*" -4523- END-IF. */
            }


            /*" -4524- IF GE420-DTA-COMUNICACAO = '1212-12-12' */

            if (GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DTA_COMUNICACAO == "1212-12-12")
            {

                /*" -4525- MOVE -1 TO WH-COMUNICACAO-NULL */
                _.Move(-1, WH_COMUNICACAO_NULL);

                /*" -4527- END-IF. */
            }


            /*" -4528- IF GE420-DTA-SENTENCA-JUDICIAL = '1212-12-12' */

            if (GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DTA_SENTENCA_JUDICIAL == "1212-12-12")
            {

                /*" -4529- MOVE -1 TO WH-SENTENCA-JUDICIAL-NULL */
                _.Move(-1, WH_SENTENCA_JUDICIAL_NULL);

                /*" -4531- END-IF. */
            }


            /*" -4532- IF GE420-DTA-COMUNIC-SENTEN = '1212-12-12' */

            if (GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DTA_COMUNIC_SENTEN == "1212-12-12")
            {

                /*" -4533- MOVE -1 TO WH-COMUNIC-SENTEN-NULL */
                _.Move(-1, WH_COMUNIC_SENTEN_NULL);

                /*" -4535- END-IF. */
            }


            /*" -4536- IF GE420-DTA-NOTA-FISCAL = '1212-12-12' */

            if (GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DTA_NOTA_FISCAL == "1212-12-12")
            {

                /*" -4537- MOVE -1 TO WH-NOTA-FISCAL-NULL */
                _.Move(-1, WH_NOTA_FISCAL_NULL);

                /*" -4539- END-IF. */
            }


            /*" -4793- PERFORM P7420_GE1_INSERT_DB_INSERT_1 */

            P7420_GE1_INSERT_DB_INSERT_1();

            /*" -4796- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4797- PERFORM R8887-DISPLAY-GE420 THRU R8887-EXIT */

                R8887_DISPLAY_GE420(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8887_EXIT*/


                /*" -4798- MOVE 'ERRO NO INSERT' TO LK-RSGEWCNT-MENSAGEM-RETORNO */
                _.Move("ERRO NO INSERT", RSGEWCNT.LK_RSGEWCNT_MENSAGEM_RETORNO);

                /*" -4800- MOVE 'SEGUROS.GE_MOVTO_ENVIO_MCP' TO LK-RSGEWCNT-NOME-TABELA */
                _.Move("SEGUROS.GE_MOVTO_ENVIO_MCP", RSGEWCNT.LK_RSGEWCNT_NOME_TABELA);

                /*" -4801- MOVE 2 TO LK-RSGEWCNT-IND-ERRO */
                _.Move(2, RSGEWCNT.LK_RSGEWCNT_IND_ERRO);

                /*" -4802- MOVE SQLCODE TO LK-RSGEWCNT-SQLCODE */
                _.Move(DB.SQLCODE, RSGEWCNT.LK_RSGEWCNT_SQLCODE);

                /*" -4803- MOVE SQLERRMC TO LK-RSGEWCNT-SQLERRMC */
                _.Move(DB.SQLERRMC, RSGEWCNT.LK_RSGEWCNT_SQLERRMC);

                /*" -4805- MOVE 'P7420-GE1-INSERT' TO LKERR-ROTINA */
                _.Move("P7420-GE1-INSERT", RSGEWERR.LKERR_REG.LKERR_ROTINA);

                /*" -4806- MOVE 'INSERT' TO LKERR-FUNCAO */
                _.Move("INSERT", RSGEWERR.LKERR_REG.LKERR_FUNCAO);

                /*" -4809- MOVE 'SEGUROS.GE_MOVTO_ENVIO_MCP' TO LKERR-OBJETOS */
                _.Move("SEGUROS.GE_MOVTO_ENVIO_MCP", RSGEWERR.LKERR_REG.LKERR_OBJETOS);

                /*" -4810- MOVE SINISHIS-NUM-APOL-SINISTRO TO WS-APOLICE-ED */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, AREA_DE_WORK.WS_APOLICE_ED);

                /*" -4811- MOVE SINISHIS-COD-OPERACAO TO WS-OPERACAO-ED */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO, AREA_DE_WORK.WS_OPERACAO_ED);

                /*" -4812- MOVE SINISHIS-OCORR-HISTORICO TO WS-SMALLINT(01) */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO, AREA_DE_WORK.WS_SMALLINT[01]);

                /*" -4816- STRING 'SINISTRO: ' WS-APOLICE-ED '; OPERACAO: ' WS-OPERACAO-ED '; OCORR-HIST: ' WS-SMALLINT(01) DELIMITED BY SIZE INTO LKERR-ELEMENTOS */
                #region STRING
                var spl45 = "SINISTRO: " + AREA_DE_WORK.WS_APOLICE_ED.GetMoveValues();
                spl45 += "; OPERACAO: ";
                var spl46 = AREA_DE_WORK.WS_OPERACAO_ED.GetMoveValues();
                spl46 += "; OCORR-HIST: ";
                var spl47 = AREA_DE_WORK.WS_SMALLINT[01].GetMoveValues();
                var results48 = spl45 + spl46 + spl47;
                _.Move(results48, RSGEWERR.LKERR_REG.LKERR_ELEMENTOS);
                #endregion

                /*" -4817- GO TO P9999-CHAMA-RSGESERR */

                P9999_CHAMA_RSGESERR(); //GOTO
                return;

                /*" -4817- END-IF. */
            }


        }

        [StopWatch]
        /*" P7420-GE1-INSERT-DB-INSERT-1 */
        public void P7420_GE1_INSERT_DB_INSERT_1()
        {
            /*" -4793- EXEC SQL INSERT INTO SEGUROS.GE_MOVTO_ENVIO_MCP ( NUM_ID_ENVIO ,SEQ_ID_ENVIO_HIST ,STA_ENVIO_MOVIMENTO ,COD_EMPRESA_SAP ,COD_SISTEMA_SAP ,COD_EVENTO_SAP ,COD_CHAVE_NEGOCIO ,COD_USUARIO_LIB ,NOM_PROGRAMA ,NOM_RAZ_SOCIAL ,IND_TIPO_PESSOA ,IND_SEXO ,NUM_CPF_CNPJ ,NUM_CPF_CNPJ_BENEF ,NOM_LOGRADOURO ,DES_NUM_RESIDENCIA ,DES_COMPL_ENDERECO ,NOM_BAIRRO ,NOM_CIDADE ,COD_UF ,COD_CEP ,DES_EMAIL ,NUM_TELEFONE ,DES_FAX ,NUM_INSC_MUNICIPAL ,NUM_INSC_ESTADUAL ,IND_OPT_SIMPLES_FEDERAL ,COD_CONVENIO ,IND_TP_CONVENIO ,IND_FORMA_PAG_COB ,TXT_EMPRESA ,COD_DOC_SIACC ,DTA_SOL_PAGTO ,COD_BANCO ,COD_AGENCIA ,NUM_DV_AGENCIA ,NUM_OPERACAO_CONTA ,NUM_CC ,NUM_DV_CONTA ,VLR_PAGTO ,VLR_ATU_MONETARIA ,VLR_ATU_JUROS ,COD_CONGENERE ,COD_FONTE_SIAS ,COD_RAMO_SUSEP ,COD_PRODUTO ,NUM_APOLICE ,NUM_SINISTRO ,COD_OPERACAO ,NUM_OCORR_HISTORICO ,DTA_AVISO ,DTA_COMUNICACAO ,DTA_SENTENCA_JUDICIAL ,DTA_COMUNIC_SENTEN ,COD_PROCES_JURID ,COD_SERVICO_SAP ,COD_FONTE_ISS ,NUM_DOC_FISCAL ,NUM_SERIE_DOC_FISCAL ,COD_AGRUPADOR ,NUM_CPF_CNPJ_TOMADOR ,COD_INDICATIVO_OBRA ,COD_NACIONAL_OBRA ,DTA_NOTA_FISCAL ,COD_CNAE_CPRB ,COD_PROCESSO_JUD ,COD_TP_SERVICO_INSS ,VLR_DEDUCAO_MEAT ,VLR_RET_NOTA_FISC ,VLR_RET_PRINCIPAL ,COD_IMPOSTO_LIMINAR ,NUM_PROPOSTA ,NUM_CERTIFICADO ,NUM_ENDOSSO ,NUM_PARCELA ,NUM_NIT_INSS ,COD_CANAL_VENDA ,NUM_TITULO ,COD_CEDENTE ,COD_COMPROMISSO ,TXT_INFO_CART_CRED ,QTD_PARCELA ,NUM_IDLG_MCP ,NUM_IDLG_SAP ,DTA_ENVIO_MCP ,DTA_RETORNO_SAP_ARQG ,DTA_RETORNO_SAP_ARQH ,DTA_EFETIVO_PGTO_COB ,COD_MODULO_SAP ,NOM_PROG_GRAVOU ,DTH_CADASTRAMENTO ) VALUES ( :GE420-NUM-ID-ENVIO ,:GE420-SEQ-ID-ENVIO-HIST ,:GE420-STA-ENVIO-MOVIMENTO ,:GE420-COD-EMPRESA-SAP ,:GE420-COD-SISTEMA-SAP ,:GE420-COD-EVENTO-SAP ,:GE420-COD-CHAVE-NEGOCIO ,:GE420-COD-USUARIO-LIB ,:GE420-NOM-PROGRAMA ,:GE420-NOM-RAZ-SOCIAL ,:GE420-IND-TIPO-PESSOA ,:GE420-IND-SEXO :WH-SEXO-NULL ,:GE420-NUM-CPF-CNPJ ,:GE420-NUM-CPF-CNPJ-BENEF :WH-CPF-CNPJ-BENEF-NULL ,:GE420-NOM-LOGRADOURO :WH-LOGRADOURO-NULL ,:GE420-DES-NUM-RESIDENCIA :WH-NUM-RESIDENCIA-NULL ,:GE420-DES-COMPL-ENDERECO :WH-COMPL-ENDERECO-NULL ,:GE420-NOM-BAIRRO :WH-BAIRRO-NULL ,:GE420-NOM-CIDADE :WH-CIDADE-NULL ,:GE420-COD-UF :WH-UF-NULL ,:GE420-COD-CEP :WH-CEP-NULL ,:GE420-DES-EMAIL :WH-EMAIL-NULL ,:GE420-NUM-TELEFONE :WH-TELEFONE-NULL ,:GE420-DES-FAX :WH-FAX-NULL ,:GE420-NUM-INSC-MUNICIPAL :WH-INSC-MUNICIPAL-NULL ,:GE420-NUM-INSC-ESTADUAL :WH-INSC-ESTADUAL-NULL ,:GE420-IND-OPT-SIMPLES-FEDERAL :WH-OPT-SIMPLES-FEDERAL-NULL ,:GE420-COD-CONVENIO :WH-CONVENIO-NULL ,:GE420-IND-TP-CONVENIO :WH-TP-CONVENIO-NULL ,:GE420-IND-FORMA-PAG-COB :WH-FORMA-PAG-COB-NULL ,:GE420-TXT-EMPRESA ,:GE420-COD-DOC-SIACC :WH-DOC-SIACC-NULL ,:GE420-DTA-SOL-PAGTO ,:GE420-COD-BANCO :WH-BANCO-NULL ,:GE420-COD-AGENCIA :WH-AGENCIA-NULL ,:GE420-NUM-DV-AGENCIA :WH-DV-AGENCIA-NULL ,:GE420-NUM-OPERACAO-CONTA :WH-OPERACAO-CONTA-NULL ,:GE420-NUM-CC :WH-CC-NULL ,:GE420-NUM-DV-CONTA :WH-DV-CONTA-NULL ,:GE420-VLR-PAGTO ,:GE420-VLR-ATU-MONETARIA ,:GE420-VLR-ATU-JUROS ,:GE420-COD-CONGENERE :WH-CONGENERE-NULL ,:GE420-COD-FONTE-SIAS :WH-FONTE-SIAS-NULL ,:GE420-COD-RAMO-SUSEP :WH-RAMO-SUSEP-NULL ,:GE420-COD-PRODUTO :WH-PRODUTO-NULL ,:GE420-NUM-APOLICE :WH-APOLICE-NULL ,:GE420-NUM-SINISTRO ,:GE420-COD-OPERACAO :WH-OPERACAO-NULL ,:GE420-NUM-OCORR-HISTORICO :WH-OCORR-HISTORICO-NULL ,:GE420-DTA-AVISO :WH-AVISO-NULL ,:GE420-DTA-COMUNICACAO :WH-COMUNICACAO-NULL ,:GE420-DTA-SENTENCA-JUDICIAL :WH-SENTENCA-JUDICIAL-NULL ,:GE420-DTA-COMUNIC-SENTEN :WH-COMUNIC-SENTEN-NULL ,:GE420-COD-PROCES-JURID :WH-PROCES-JURID-NULL ,:GE420-COD-SERVICO-SAP :WH-SERVICO-SAP-NULL ,:GE420-COD-FONTE-ISS :WH-FONTE-ISS-NULL ,:GE420-NUM-DOC-FISCAL :WH-DOC-FISCAL-NULL ,:GE420-NUM-SERIE-DOC-FISCAL :WH-SERIE-DOC-FISCAL-NULL ,:GE420-COD-AGRUPADOR :WH-AGRUPADOR-NULL ,:GE420-NUM-CPF-CNPJ-TOMADOR :WH-CPF-CNPJ-TOMADOR-NULL ,:GE420-COD-INDICATIVO-OBRA :WH-INDICATIVO-OBRA-NULL ,:GE420-COD-NACIONAL-OBRA :WH-NACIONAL-OBRA-NULL ,:GE420-DTA-NOTA-FISCAL :WH-NOTA-FISCAL-NULL ,:GE420-COD-CNAE-CPRB :WH-CNAE-CPRB-NULL ,:GE420-COD-PROCESSO-JUD :WH-PROCESSO-JUD-NULL ,:GE420-COD-TP-SERVICO-INSS :WH-TP-SERVICO-INSS-NULL ,:GE420-VLR-DEDUCAO-MEAT ,:GE420-VLR-RET-NOTA-FISC ,:GE420-VLR-RET-PRINCIPAL ,:GE420-COD-IMPOSTO-LIMINAR :WH-IMPOSTO-LIMINAR-NULL ,:GE420-NUM-PROPOSTA :WH-PROPOSTA-NULL ,:GE420-NUM-CERTIFICADO :WH-CERTIFICADO-NULL ,:GE420-NUM-ENDOSSO :WH-ENDOSSO-NULL ,:GE420-NUM-PARCELA :WH-PARCELA-NULL ,:GE420-NUM-NIT-INSS :WH-NIT-INSS-NULL ,:GE420-COD-CANAL-VENDA :WH-CANAL-VENDA-NULL ,:GE420-NUM-TITULO :WH-TITULO-NULL ,:GE420-COD-CEDENTE :WH-CEDENTE-NULL ,:GE420-COD-COMPROMISSO :WH-COMPROMISSO-NULL ,:GE420-TXT-INFO-CART-CRED :WH-INFO-CART-CRED-NULL ,:GE420-QTD-PARCELA :WH-QTD-PARCELA-NULL ,:GE420-NUM-IDLG-MCP :WH-IDLG-MCP-NULL ,:GE420-NUM-IDLG-SAP :WH-IDLG-SAP-NULL ,:GE420-DTA-ENVIO-MCP :WH-ENVIO-MCP-NULL ,:GE420-DTA-RETORNO-SAP-ARQG :WH-RETORNO-SAP-ARQG-NULL ,:GE420-DTA-RETORNO-SAP-ARQH :WH-RETORNO-SAP-ARQH-NULL ,:GE420-DTA-EFETIVO-PGTO-COB :WH-EFETIVO-PGTO-COB-NULL ,:GE420-COD-MODULO-SAP , 'SICP001S' , CURRENT TIMESTAMP ) END-EXEC. */

            var p7420_GE1_INSERT_DB_INSERT_1_Insert1 = new P7420_GE1_INSERT_DB_INSERT_1_Insert1()
            {
                GE420_NUM_ID_ENVIO = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_ID_ENVIO.ToString(),
                GE420_SEQ_ID_ENVIO_HIST = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_SEQ_ID_ENVIO_HIST.ToString(),
                GE420_STA_ENVIO_MOVIMENTO = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_STA_ENVIO_MOVIMENTO.ToString(),
                GE420_COD_EMPRESA_SAP = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_EMPRESA_SAP.ToString(),
                GE420_COD_SISTEMA_SAP = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_SISTEMA_SAP.ToString(),
                GE420_COD_EVENTO_SAP = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_EVENTO_SAP.ToString(),
                GE420_COD_CHAVE_NEGOCIO = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_CHAVE_NEGOCIO.ToString(),
                GE420_COD_USUARIO_LIB = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_USUARIO_LIB.ToString(),
                GE420_NOM_PROGRAMA = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NOM_PROGRAMA.ToString(),
                GE420_NOM_RAZ_SOCIAL = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NOM_RAZ_SOCIAL.ToString(),
                GE420_IND_TIPO_PESSOA = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_IND_TIPO_PESSOA.ToString(),
                GE420_IND_SEXO = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_IND_SEXO.ToString(),
                WH_SEXO_NULL = WH_SEXO_NULL.ToString(),
                GE420_NUM_CPF_CNPJ = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_CPF_CNPJ.ToString(),
                GE420_NUM_CPF_CNPJ_BENEF = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_CPF_CNPJ_BENEF.ToString(),
                WH_CPF_CNPJ_BENEF_NULL = WH_CPF_CNPJ_BENEF_NULL.ToString(),
                GE420_NOM_LOGRADOURO = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NOM_LOGRADOURO.ToString(),
                WH_LOGRADOURO_NULL = WH_LOGRADOURO_NULL.ToString(),
                GE420_DES_NUM_RESIDENCIA = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DES_NUM_RESIDENCIA.ToString(),
                WH_NUM_RESIDENCIA_NULL = WH_NUM_RESIDENCIA_NULL.ToString(),
                GE420_DES_COMPL_ENDERECO = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DES_COMPL_ENDERECO.ToString(),
                WH_COMPL_ENDERECO_NULL = WH_COMPL_ENDERECO_NULL.ToString(),
                GE420_NOM_BAIRRO = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NOM_BAIRRO.ToString(),
                WH_BAIRRO_NULL = WH_BAIRRO_NULL.ToString(),
                GE420_NOM_CIDADE = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NOM_CIDADE.ToString(),
                WH_CIDADE_NULL = WH_CIDADE_NULL.ToString(),
                GE420_COD_UF = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_UF.ToString(),
                WH_UF_NULL = WH_UF_NULL.ToString(),
                GE420_COD_CEP = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_CEP.ToString(),
                WH_CEP_NULL = WH_CEP_NULL.ToString(),
                GE420_DES_EMAIL = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DES_EMAIL.ToString(),
                WH_EMAIL_NULL = WH_EMAIL_NULL.ToString(),
                GE420_NUM_TELEFONE = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_TELEFONE.ToString(),
                WH_TELEFONE_NULL = WH_TELEFONE_NULL.ToString(),
                GE420_DES_FAX = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DES_FAX.ToString(),
                WH_FAX_NULL = WH_FAX_NULL.ToString(),
                GE420_NUM_INSC_MUNICIPAL = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_INSC_MUNICIPAL.ToString(),
                WH_INSC_MUNICIPAL_NULL = WH_INSC_MUNICIPAL_NULL.ToString(),
                GE420_NUM_INSC_ESTADUAL = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_INSC_ESTADUAL.ToString(),
                WH_INSC_ESTADUAL_NULL = WH_INSC_ESTADUAL_NULL.ToString(),
                GE420_IND_OPT_SIMPLES_FEDERAL = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_IND_OPT_SIMPLES_FEDERAL.ToString(),
                WH_OPT_SIMPLES_FEDERAL_NULL = WH_OPT_SIMPLES_FEDERAL_NULL.ToString(),
                GE420_COD_CONVENIO = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_CONVENIO.ToString(),
                WH_CONVENIO_NULL = WH_CONVENIO_NULL.ToString(),
                GE420_IND_TP_CONVENIO = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_IND_TP_CONVENIO.ToString(),
                WH_TP_CONVENIO_NULL = WH_TP_CONVENIO_NULL.ToString(),
                GE420_IND_FORMA_PAG_COB = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_IND_FORMA_PAG_COB.ToString(),
                WH_FORMA_PAG_COB_NULL = WH_FORMA_PAG_COB_NULL.ToString(),
                GE420_TXT_EMPRESA = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_TXT_EMPRESA.ToString(),
                GE420_COD_DOC_SIACC = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_DOC_SIACC.ToString(),
                WH_DOC_SIACC_NULL = WH_DOC_SIACC_NULL.ToString(),
                GE420_DTA_SOL_PAGTO = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DTA_SOL_PAGTO.ToString(),
                GE420_COD_BANCO = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_BANCO.ToString(),
                WH_BANCO_NULL = WH_BANCO_NULL.ToString(),
                GE420_COD_AGENCIA = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_AGENCIA.ToString(),
                WH_AGENCIA_NULL = WH_AGENCIA_NULL.ToString(),
                GE420_NUM_DV_AGENCIA = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_DV_AGENCIA.ToString(),
                WH_DV_AGENCIA_NULL = WH_DV_AGENCIA_NULL.ToString(),
                GE420_NUM_OPERACAO_CONTA = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_OPERACAO_CONTA.ToString(),
                WH_OPERACAO_CONTA_NULL = WH_OPERACAO_CONTA_NULL.ToString(),
                GE420_NUM_CC = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_CC.ToString(),
                WH_CC_NULL = WH_CC_NULL.ToString(),
                GE420_NUM_DV_CONTA = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_DV_CONTA.ToString(),
                WH_DV_CONTA_NULL = WH_DV_CONTA_NULL.ToString(),
                GE420_VLR_PAGTO = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_VLR_PAGTO.ToString(),
                GE420_VLR_ATU_MONETARIA = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_VLR_ATU_MONETARIA.ToString(),
                GE420_VLR_ATU_JUROS = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_VLR_ATU_JUROS.ToString(),
                GE420_COD_CONGENERE = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_CONGENERE.ToString(),
                WH_CONGENERE_NULL = WH_CONGENERE_NULL.ToString(),
                GE420_COD_FONTE_SIAS = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_FONTE_SIAS.ToString(),
                WH_FONTE_SIAS_NULL = WH_FONTE_SIAS_NULL.ToString(),
                GE420_COD_RAMO_SUSEP = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_RAMO_SUSEP.ToString(),
                WH_RAMO_SUSEP_NULL = WH_RAMO_SUSEP_NULL.ToString(),
                GE420_COD_PRODUTO = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_PRODUTO.ToString(),
                WH_PRODUTO_NULL = WH_PRODUTO_NULL.ToString(),
                GE420_NUM_APOLICE = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_APOLICE.ToString(),
                WH_APOLICE_NULL = WH_APOLICE_NULL.ToString(),
                GE420_NUM_SINISTRO = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_SINISTRO.ToString(),
                GE420_COD_OPERACAO = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_OPERACAO.ToString(),
                WH_OPERACAO_NULL = WH_OPERACAO_NULL.ToString(),
                GE420_NUM_OCORR_HISTORICO = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_OCORR_HISTORICO.ToString(),
                WH_OCORR_HISTORICO_NULL = WH_OCORR_HISTORICO_NULL.ToString(),
                GE420_DTA_AVISO = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DTA_AVISO.ToString(),
                WH_AVISO_NULL = WH_AVISO_NULL.ToString(),
                GE420_DTA_COMUNICACAO = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DTA_COMUNICACAO.ToString(),
                WH_COMUNICACAO_NULL = WH_COMUNICACAO_NULL.ToString(),
                GE420_DTA_SENTENCA_JUDICIAL = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DTA_SENTENCA_JUDICIAL.ToString(),
                WH_SENTENCA_JUDICIAL_NULL = WH_SENTENCA_JUDICIAL_NULL.ToString(),
                GE420_DTA_COMUNIC_SENTEN = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DTA_COMUNIC_SENTEN.ToString(),
                WH_COMUNIC_SENTEN_NULL = WH_COMUNIC_SENTEN_NULL.ToString(),
                GE420_COD_PROCES_JURID = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_PROCES_JURID.ToString(),
                WH_PROCES_JURID_NULL = WH_PROCES_JURID_NULL.ToString(),
                GE420_COD_SERVICO_SAP = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_SERVICO_SAP.ToString(),
                WH_SERVICO_SAP_NULL = WH_SERVICO_SAP_NULL.ToString(),
                GE420_COD_FONTE_ISS = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_FONTE_ISS.ToString(),
                WH_FONTE_ISS_NULL = WH_FONTE_ISS_NULL.ToString(),
                GE420_NUM_DOC_FISCAL = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_DOC_FISCAL.ToString(),
                WH_DOC_FISCAL_NULL = WH_DOC_FISCAL_NULL.ToString(),
                GE420_NUM_SERIE_DOC_FISCAL = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_SERIE_DOC_FISCAL.ToString(),
                WH_SERIE_DOC_FISCAL_NULL = WH_SERIE_DOC_FISCAL_NULL.ToString(),
                GE420_COD_AGRUPADOR = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_AGRUPADOR.ToString(),
                WH_AGRUPADOR_NULL = WH_AGRUPADOR_NULL.ToString(),
                GE420_NUM_CPF_CNPJ_TOMADOR = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_CPF_CNPJ_TOMADOR.ToString(),
                WH_CPF_CNPJ_TOMADOR_NULL = WH_CPF_CNPJ_TOMADOR_NULL.ToString(),
                GE420_COD_INDICATIVO_OBRA = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_INDICATIVO_OBRA.ToString(),
                WH_INDICATIVO_OBRA_NULL = WH_INDICATIVO_OBRA_NULL.ToString(),
                GE420_COD_NACIONAL_OBRA = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_NACIONAL_OBRA.ToString(),
                WH_NACIONAL_OBRA_NULL = WH_NACIONAL_OBRA_NULL.ToString(),
                GE420_DTA_NOTA_FISCAL = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DTA_NOTA_FISCAL.ToString(),
                WH_NOTA_FISCAL_NULL = WH_NOTA_FISCAL_NULL.ToString(),
                GE420_COD_CNAE_CPRB = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_CNAE_CPRB.ToString(),
                WH_CNAE_CPRB_NULL = WH_CNAE_CPRB_NULL.ToString(),
                GE420_COD_PROCESSO_JUD = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_PROCESSO_JUD.ToString(),
                WH_PROCESSO_JUD_NULL = WH_PROCESSO_JUD_NULL.ToString(),
                GE420_COD_TP_SERVICO_INSS = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_TP_SERVICO_INSS.ToString(),
                WH_TP_SERVICO_INSS_NULL = WH_TP_SERVICO_INSS_NULL.ToString(),
                GE420_VLR_DEDUCAO_MEAT = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_VLR_DEDUCAO_MEAT.ToString(),
                GE420_VLR_RET_NOTA_FISC = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_VLR_RET_NOTA_FISC.ToString(),
                GE420_VLR_RET_PRINCIPAL = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_VLR_RET_PRINCIPAL.ToString(),
                GE420_COD_IMPOSTO_LIMINAR = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_IMPOSTO_LIMINAR.ToString(),
                WH_IMPOSTO_LIMINAR_NULL = WH_IMPOSTO_LIMINAR_NULL.ToString(),
                GE420_NUM_PROPOSTA = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_PROPOSTA.ToString(),
                WH_PROPOSTA_NULL = WH_PROPOSTA_NULL.ToString(),
                GE420_NUM_CERTIFICADO = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_CERTIFICADO.ToString(),
                WH_CERTIFICADO_NULL = WH_CERTIFICADO_NULL.ToString(),
                GE420_NUM_ENDOSSO = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_ENDOSSO.ToString(),
                WH_ENDOSSO_NULL = WH_ENDOSSO_NULL.ToString(),
                GE420_NUM_PARCELA = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_PARCELA.ToString(),
                WH_PARCELA_NULL = WH_PARCELA_NULL.ToString(),
                GE420_NUM_NIT_INSS = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_NIT_INSS.ToString(),
                WH_NIT_INSS_NULL = WH_NIT_INSS_NULL.ToString(),
                GE420_COD_CANAL_VENDA = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_CANAL_VENDA.ToString(),
                WH_CANAL_VENDA_NULL = WH_CANAL_VENDA_NULL.ToString(),
                GE420_NUM_TITULO = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_TITULO.ToString(),
                WH_TITULO_NULL = WH_TITULO_NULL.ToString(),
                GE420_COD_CEDENTE = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_CEDENTE.ToString(),
                WH_CEDENTE_NULL = WH_CEDENTE_NULL.ToString(),
                GE420_COD_COMPROMISSO = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_COMPROMISSO.ToString(),
                WH_COMPROMISSO_NULL = WH_COMPROMISSO_NULL.ToString(),
                GE420_TXT_INFO_CART_CRED = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_TXT_INFO_CART_CRED.ToString(),
                WH_INFO_CART_CRED_NULL = WH_INFO_CART_CRED_NULL.ToString(),
                GE420_QTD_PARCELA = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_QTD_PARCELA.ToString(),
                WH_QTD_PARCELA_NULL = WH_QTD_PARCELA_NULL.ToString(),
                GE420_NUM_IDLG_MCP = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_IDLG_MCP.ToString(),
                WH_IDLG_MCP_NULL = WH_IDLG_MCP_NULL.ToString(),
                GE420_NUM_IDLG_SAP = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_IDLG_SAP.ToString(),
                WH_IDLG_SAP_NULL = WH_IDLG_SAP_NULL.ToString(),
                GE420_DTA_ENVIO_MCP = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DTA_ENVIO_MCP.ToString(),
                WH_ENVIO_MCP_NULL = WH_ENVIO_MCP_NULL.ToString(),
                GE420_DTA_RETORNO_SAP_ARQG = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DTA_RETORNO_SAP_ARQG.ToString(),
                WH_RETORNO_SAP_ARQG_NULL = WH_RETORNO_SAP_ARQG_NULL.ToString(),
                GE420_DTA_RETORNO_SAP_ARQH = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DTA_RETORNO_SAP_ARQH.ToString(),
                WH_RETORNO_SAP_ARQH_NULL = WH_RETORNO_SAP_ARQH_NULL.ToString(),
                GE420_DTA_EFETIVO_PGTO_COB = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DTA_EFETIVO_PGTO_COB.ToString(),
                WH_EFETIVO_PGTO_COB_NULL = WH_EFETIVO_PGTO_COB_NULL.ToString(),
                GE420_COD_MODULO_SAP = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_MODULO_SAP.ToString(),
            };

            P7420_GE1_INSERT_DB_INSERT_1_Insert1.Execute(p7420_GE1_INSERT_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P7420_GE1_EXIT*/

        [StopWatch]
        /*" P7420-GE2-SELECT */
        private void P7420_GE2_SELECT(bool isPerform = false)
        {
            /*" -4832- DISPLAY 'P7420-GE2-SELECT' */
            _.Display($"P7420-GE2-SELECT");

            /*" -4834- MOVE ZEROS TO GE420-SEQ-ID-ENVIO-HIST. */
            _.Move(0, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_SEQ_ID_ENVIO_HIST);

            /*" -4840- PERFORM P7420_GE2_SELECT_DB_SELECT_1 */

            P7420_GE2_SELECT_DB_SELECT_1();

            /*" -4843- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4845- MOVE 'P7420-GE2-SELECT' TO LKERR-ROTINA */
                _.Move("P7420-GE2-SELECT", RSGEWERR.LKERR_REG.LKERR_ROTINA);

                /*" -4846- MOVE 'SELECT MAX' TO LKERR-FUNCAO */
                _.Move("SELECT MAX", RSGEWERR.LKERR_REG.LKERR_FUNCAO);

                /*" -4849- MOVE 'SEGUROS.GE_MOVTO_ENVIO_MCP' TO LKERR-OBJETOS */
                _.Move("SEGUROS.GE_MOVTO_ENVIO_MCP", RSGEWERR.LKERR_REG.LKERR_OBJETOS);

                /*" -4850- MOVE SPACES TO LKERR-ELEMENTOS */
                _.Move("", RSGEWERR.LKERR_REG.LKERR_ELEMENTOS);

                /*" -4851- GO TO P9999-CHAMA-RSGESERR */

                P9999_CHAMA_RSGESERR(); //GOTO
                return;

                /*" -4851- END-IF. */
            }


        }

        [StopWatch]
        /*" P7420-GE2-SELECT-DB-SELECT-1 */
        public void P7420_GE2_SELECT_DB_SELECT_1()
        {
            /*" -4840- EXEC SQL SELECT VALUE(MAX(NUM_ID_ENVIO),0) + 1 INTO :GE420-NUM-ID-ENVIO FROM SEGUROS.GE_MOVTO_ENVIO_MCP WITH UR END-EXEC. */

            var p7420_GE2_SELECT_DB_SELECT_1_Query1 = new P7420_GE2_SELECT_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = P7420_GE2_SELECT_DB_SELECT_1_Query1.Execute(p7420_GE2_SELECT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE420_NUM_ID_ENVIO, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_ID_ENVIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P7420_GE2_EXIT*/

        [StopWatch]
        /*" P7420-GE3-UPDATE */
        private void P7420_GE3_UPDATE(bool isPerform = false)
        {
            /*" -4866- DISPLAY 'P7420-GE3-UPDATE' */
            _.Display($"P7420-GE3-UPDATE");

            /*" -4870- PERFORM P7420_GE3_UPDATE_DB_UPDATE_1 */

            P7420_GE3_UPDATE_DB_UPDATE_1();

            /*" -4873- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4875- MOVE 'P7420-GE3-UPDATE' TO LKERR-ROTINA */
                _.Move("P7420-GE3-UPDATE", RSGEWERR.LKERR_REG.LKERR_ROTINA);

                /*" -4876- MOVE 'UPDATE' TO LKERR-FUNCAO */
                _.Move("UPDATE", RSGEWERR.LKERR_REG.LKERR_FUNCAO);

                /*" -4879- MOVE 'SEGUROS.GE_MOVTO_ENVIO_MCP' TO LKERR-OBJETOS */
                _.Move("SEGUROS.GE_MOVTO_ENVIO_MCP", RSGEWERR.LKERR_REG.LKERR_OBJETOS);

                /*" -4880- MOVE GE420-NUM-ID-ENVIO TO WS-BIGINT1-ED */
                _.Move(GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_ID_ENVIO, AREA_DE_WORK.WS_BIGINT1_ED);

                /*" -4882- MOVE GE420-SEQ-ID-ENVIO-HIST TO WS-SMALLINT(01) */
                _.Move(GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_SEQ_ID_ENVIO_HIST, AREA_DE_WORK.WS_SMALLINT[01]);

                /*" -4885- STRING 'NUM_ID_ENVIO = ' WS-BIGINT1-ED '; SEQ_ID_ENVIO = ' WS-SMALLINT(01) DELIMITED BY SIZE INTO LKERR-ELEMENTOS */
                #region STRING
                var spl48 = "NUM_ID_ENVIO = " + AREA_DE_WORK.WS_BIGINT1_ED.GetMoveValues();
                spl48 += "; SEQ_ID_ENVIO = ";
                var spl49 = AREA_DE_WORK.WS_SMALLINT[01].GetMoveValues();
                var results50 = spl48 + spl49;
                _.Move(results50, RSGEWERR.LKERR_REG.LKERR_ELEMENTOS);
                #endregion

                /*" -4886- GO TO P9999-CHAMA-RSGESERR */

                P9999_CHAMA_RSGESERR(); //GOTO
                return;

                /*" -4886- END-IF. */
            }


        }

        [StopWatch]
        /*" P7420-GE3-UPDATE-DB-UPDATE-1 */
        public void P7420_GE3_UPDATE_DB_UPDATE_1()
        {
            /*" -4870- EXEC SQL UPDATE SEGUROS.GE_MOVTO_ENVIO_MCP SET COD_TP_SERVICO_INSS = :GE420-COD-TP-SERVICO-INSS WHERE NUM_ID_ENVIO = :GE420-NUM-ID-ENVIO AND SEQ_ID_ENVIO_HIST = :GE420-SEQ-ID-ENVIO-HIST END-EXEC. */

            var p7420_GE3_UPDATE_DB_UPDATE_1_Update1 = new P7420_GE3_UPDATE_DB_UPDATE_1_Update1()
            {
                GE420_COD_TP_SERVICO_INSS = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_TP_SERVICO_INSS.ToString(),
                GE420_SEQ_ID_ENVIO_HIST = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_SEQ_ID_ENVIO_HIST.ToString(),
                GE420_NUM_ID_ENVIO = GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_ID_ENVIO.ToString(),
            };

            P7420_GE3_UPDATE_DB_UPDATE_1_Update1.Execute(p7420_GE3_UPDATE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P7420_GE3_EXIT*/

        [StopWatch]
        /*" R7777-ACESSA-TIMESTAMP */
        private void R7777_ACESSA_TIMESTAMP(bool isPerform = false)
        {
            /*" -4896- DISPLAY 'R7777-ACESSA-TIMESTAMP' */
            _.Display($"R7777-ACESSA-TIMESTAMP");

            /*" -4902- PERFORM R7777_ACESSA_TIMESTAMP_DB_SELECT_1 */

            R7777_ACESSA_TIMESTAMP_DB_SELECT_1();

            /*" -4905- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -4906- DISPLAY 'SISAP02B - ERRO NO ACESSO TIMESTAMP - R7777' */
                _.Display($"SISAP02B - ERRO NO ACESSO TIMESTAMP - R7777");

                /*" -4908- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -4909- MOVE HOST-CURRENT-TIMESTAMP(18:9) TO W-AGRUPADOR-MINUTO-SSSSSS. */
            _.Move(HOST_CURRENT_TIMESTAMP.Substring(18, 9), AREA_DE_WORK.W_AGRUPADOR_1.W_AGRUPADOR_MINUTO_SSSSSS);

        }

        [StopWatch]
        /*" R7777-ACESSA-TIMESTAMP-DB-SELECT-1 */
        public void R7777_ACESSA_TIMESTAMP_DB_SELECT_1()
        {
            /*" -4902- EXEC SQL SELECT CURRENT TIMESTAMP INTO :HOST-CURRENT-TIMESTAMP FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'FI' WITH UR END-EXEC. */

            var r7777_ACESSA_TIMESTAMP_DB_SELECT_1_Query1 = new R7777_ACESSA_TIMESTAMP_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R7777_ACESSA_TIMESTAMP_DB_SELECT_1_Query1.Execute(r7777_ACESSA_TIMESTAMP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_CURRENT_TIMESTAMP, HOST_CURRENT_TIMESTAMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7777_EXIT*/

        [StopWatch]
        /*" R19100-MONTA-REINF */
        private void R19100_MONTA_REINF(bool isPerform = false)
        {
            /*" -4920- DISPLAY 'R1900-MONTA-REINF' */
            _.Display($"R1900-MONTA-REINF");

            /*" -4922- IF (SINISLAN-SEQ-INDICATIVO-OBRA EQUAL 9999 OR 0) OR (W-CHAVE-TIPO-PESSOA-PF-PJ EQUAL 'PF' ) */

            if ((SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_SEQ_INDICATIVO_OBRA.In("9999", "0")) || (AREA_DE_WORK.W_CHAVE_TIPO_PESSOA_PF_PJ == "PF"))
            {

                /*" -4923- CONTINUE */

                /*" -4924- ELSE */
            }
            else
            {


                /*" -4926- MOVE SINISLAN-SEQ-INDICATIVO-OBRA TO GE420-COD-INDICATIVO-OBRA */
                _.Move(SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_SEQ_INDICATIVO_OBRA, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_INDICATIVO_OBRA);

                /*" -4930- END-IF. */
            }


            /*" -4931- IF SINISLAN-SEQ-INDICATIVO-OBRA NOT EQUAL ZEROS */

            if (SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_SEQ_INDICATIVO_OBRA != 00)
            {

                /*" -4933- MOVE SINISLAN-COD-NACIONAL-OBRA TO GE420-COD-NACIONAL-OBRA */
                _.Move(SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_COD_NACIONAL_OBRA, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_NACIONAL_OBRA);

                /*" -4937- END-IF. */
            }


            /*" -4938- IF SINISCAP-COD-NAT-RENDIMENTO NOT EQUAL ZEROS */

            if (SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_NAT_RENDIMENTO != 00)
            {

                /*" -4940- MOVE SINISCAP-COD-NAT-RENDIMENTO TO WS-NAT-RENDIMENTOS-NUM */
                _.Move(SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_NAT_RENDIMENTO, AREA_DE_WORK.WS_NAT_RENDIMENTOS_NUM);

                /*" -4942- MOVE WS-NAT-RENDIMENTOS-CHR TO GE420-COD-CNAE-CPRB */
                _.Move(AREA_DE_WORK.WS_NAT_RENDIMENTOS_CHR, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_CNAE_CPRB);

                /*" -4946- END-IF. */
            }


            /*" -4948- IF SINISCAP-COD-PROCESSO-ISENCAO NOT EQUAL SPACES */

            if (!SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_PROCESSO_ISENCAO.IsEmpty())
            {

                /*" -4950- MOVE SINISCAP-COD-PROCESSO-ISENCAO TO GE420-COD-PROCESSO-JUD */
                _.Move(SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_PROCESSO_ISENCAO, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_PROCESSO_JUD);

                /*" -4954- END-IF. */
            }


            /*" -4956- IF SINISLAN-VLR-CUSTO-N-BASE-INSS NOT EQUAL ZEROS */

            if (SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_VLR_CUSTO_N_BASE_INSS != 00)
            {

                /*" -4958- MOVE SINISLAN-VLR-CUSTO-N-BASE-INSS TO GE420-VLR-DEDUCAO-MEAT */
                _.Move(SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_VLR_CUSTO_N_BASE_INSS, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_VLR_DEDUCAO_MEAT);

                /*" -4962- END-IF. */
            }


            /*" -4964- IF SINISLAN-VLR-INSS-SUBCONTRATO NOT EQUAL ZEROS */

            if (SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_VLR_INSS_SUBCONTRATO != 00)
            {

                /*" -4966- MOVE SINISLAN-VLR-INSS-SUBCONTRATO TO GE420-VLR-RET-NOTA-FISC */
                _.Move(SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_VLR_INSS_SUBCONTRATO, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_VLR_RET_NOTA_FISC);

                /*" -4970- END-IF. */
            }


            /*" -4971- IF SINISLAN-NUM-LOTE NOT EQUAL WS-LOTE-ANT */

            if (SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_NUM_LOTE != AREA_DE_WORK.W_LOTE.WS_LOTE_ANT)
            {

                /*" -4972- MOVE SINISLAN-NUM-LOTE TO WS-LOTE-ANT */
                _.Move(SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_NUM_LOTE, AREA_DE_WORK.W_LOTE.WS_LOTE_ANT);

                /*" -4974- IF SINISCAP-VLR-RET-N-EFETUADO NOT EQUAL ZEROS */

                if (SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_VLR_RET_N_EFETUADO != 00)
                {

                    /*" -4976- MOVE SINISCAP-VLR-RET-N-EFETUADO TO GE420-VLR-RET-PRINCIPAL */
                    _.Move(SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_VLR_RET_N_EFETUADO, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_VLR_RET_PRINCIPAL);

                    /*" -4977- END-IF */
                }


                /*" -4981- END-IF. */
            }


            /*" -4983- IF SINISCAP-COD-IMPOSTO-LIMINAR NOT EQUAL ZEROS */

            if (SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_IMPOSTO_LIMINAR != 00)
            {

                /*" -4985- MOVE SINISCAP-COD-IMPOSTO-LIMINAR TO WS-IMPOSTO-LIMINAR-NUM */
                _.Move(SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_IMPOSTO_LIMINAR, AREA_DE_WORK.WS_IMPOSTO_LIMINAR_NUM);

                /*" -4987- MOVE WS-IMPOSTO-LIMINAR-CHR TO GE420-COD-IMPOSTO-LIMINAR */
                _.Move(AREA_DE_WORK.WS_IMPOSTO_LIMINAR_CHR, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_IMPOSTO_LIMINAR);

                /*" -4987- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R19100_EXIT*/

        [StopWatch]
        /*" R19200-SELECT-REINF */
        private void R19200_SELECT_REINF(bool isPerform = false)
        {
            /*" -4998- DISPLAY 'R19200-SELECT-REINF' */
            _.Display($"R19200-SELECT-REINF");

            /*" -5000- MOVE 'NAO' TO W-CHAVE-TEM-CAPA-LOTE */
            _.Move("NAO", AREA_DE_WORK.W_CHAVE_TEM_CAPA_LOTE);

            /*" -5002- MOVE GEOPERAC-IND-TIPO-FUNCAO TO W-LIB */
            _.Move(GEOPERAC.DCLGE_OPERACAO.GEOPERAC_IND_TIPO_FUNCAO, AREA_DE_WORK.W_LIB);

            /*" -5003- INITIALIZE DCLSINISTRO-CAPALOTE1. */
            _.Initialize(
                SINISCAP.DCLSINISTRO_CAPALOTE1
            );

            /*" -5005- INITIALIZE DCLSINISTRO-LANCLOTE1. */
            _.Initialize(
                SINISLAN.DCLSINISTRO_LANCLOTE1
            );

            /*" -5006- MOVE ZEROS TO SINISLAN-COD-FONTE. */
            _.Move(0, SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_COD_FONTE);

            /*" -5007- MOVE ZEROS TO SINISLAN-NUM-LOTE. */
            _.Move(0, SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_NUM_LOTE);

            /*" -5008- MOVE ZEROS TO SINISLAN-NUM-APOL-SINISTRO. */
            _.Move(0, SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_NUM_APOL_SINISTRO);

            /*" -5009- MOVE ZEROS TO SINISLAN-OCORR-HISTORICO. */
            _.Move(0, SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_OCORR_HISTORICO);

            /*" -5010- MOVE ZEROS TO SINISLAN-COD-OPERACAO. */
            _.Move(0, SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_COD_OPERACAO);

            /*" -5011- MOVE ZEROS TO SINISLAN-VAL-OPERACAO. */
            _.Move(0, SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_VAL_OPERACAO);

            /*" -5012- MOVE SPACES TO SINISLAN-COD-PROCESSO-JURID. */
            _.Move("", SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_COD_PROCESSO_JURID);

            /*" -5013- MOVE ZEROS TO SINISLAN-VLR-INSS-SUBCONTRATO. */
            _.Move(0, SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_VLR_INSS_SUBCONTRATO);

            /*" -5014- MOVE ZEROS TO SINISLAN-SEQ-TP-SERVICO-INSS. */
            _.Move(0, SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_SEQ_TP_SERVICO_INSS);

            /*" -5015- MOVE ZEROS TO SINISLAN-SEQ-INDICATIVO-OBRA. */
            _.Move(0, SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_SEQ_INDICATIVO_OBRA);

            /*" -5016- MOVE ZEROS TO SINISLAN-VLR-CUSTO-N-BASE-INSS. */
            _.Move(0, SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_VLR_CUSTO_N_BASE_INSS);

            /*" -5017- MOVE ZEROS TO SINISLAN-COD-NACIONAL-OBRA. */
            _.Move(0, SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_COD_NACIONAL_OBRA);

            /*" -5018- MOVE ZEROS TO SINISLAN-VLR-BASE-CALCULO-INSS. */
            _.Move(0, SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_VLR_BASE_CALCULO_INSS);

            /*" -5019- MOVE ZEROS TO SINISCAP-NUM-DOCF-INTERNO. */
            _.Move(0, SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_NUM_DOCF_INTERNO);

            /*" -5020- MOVE ZEROS TO SINISCAP-NUM-CPF-CNPJ-FAVOREC. */
            _.Move(0, SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_NUM_CPF_CNPJ_FAVOREC);

            /*" -5021- MOVE ZEROS TO SINISCAP-NUM-CPF-CNPJ-TOMADOR. */
            _.Move(0, SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_NUM_CPF_CNPJ_TOMADOR);

            /*" -5022- MOVE ZEROS TO SINISCAP-SEQ-CNAE-CPRB. */
            _.Move(0, SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_SEQ_CNAE_CPRB);

            /*" -5023- MOVE ZEROS TO SINISCAP-VLR-TOTAL-DOCUMENTO. */
            _.Move(0, SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_VLR_TOTAL_DOCUMENTO);

            /*" -5024- MOVE SPACES TO SINISCAP-IND-GRUPO-LANCAMENTO. */
            _.Move("", SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_IND_GRUPO_LANCAMENTO);

            /*" -5025- MOVE SPACES TO SINISCAP-IND-ISENCAO-TRIBUTO. */
            _.Move("", SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_IND_ISENCAO_TRIBUTO);

            /*" -5026- MOVE ZEROS TO SINISCAP-COD-IMPOSTO-LIMINAR. */
            _.Move(0, SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_IMPOSTO_LIMINAR);

            /*" -5027- MOVE SPACES TO SINISCAP-COD-PROCESSO-ISENCAO. */
            _.Move("", SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_PROCESSO_ISENCAO);

            /*" -5028- MOVE ZEROS TO SINISCAP-VLR-RET-N-EFETUADO. */
            _.Move(0, SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_VLR_RET_N_EFETUADO);

            /*" -5029- MOVE ZEROS TO SINISCAP-PCT-CPRB. */
            _.Move(0, SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_PCT_CPRB);

            /*" -5030- MOVE SPACES TO SINISCAP-IND-DESC-INSS. */
            _.Move("", SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_IND_DESC_INSS);

            /*" -5031- MOVE ZEROS TO SINISCAP-COD-SERVICO-CONTABIL. */
            _.Move(0, SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_SERVICO_CONTABIL);

            /*" -5032- MOVE ZEROS TO SINISCAP-COD-NAT-RENDIMENTO. */
            _.Move(0, SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_NAT_RENDIMENTO);

            /*" -5033- MOVE ZEROS TO SINISCAP-COD-IMPOSTO-ISS. */
            _.Move(0, SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_IMPOSTO_ISS);

            /*" -5034- MOVE ZEROS TO SINISCAP-PCT-ALIQ-ISS. */
            _.Move(0, SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_PCT_ALIQ_ISS);

            /*" -5036- MOVE SPACES TO GE612-COD-TP-SERVICO-INSS. */
            _.Move("", GE612.DCLGE_TP_SERVICO_INSS.GE612_COD_TP_SERVICO_INSS);

            /*" -5108- PERFORM R19200_SELECT_REINF_DB_SELECT_1 */

            R19200_SELECT_REINF_DB_SELECT_1();

            /*" -5111-  EVALUATE SQLCODE  */

            /*" -5112-  WHEN ZEROS  */

            /*" -5112- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -5113- MOVE 'SIM' TO W-CHAVE-TEM-CAPA-LOTE */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_TEM_CAPA_LOTE);

                /*" -5114-  WHEN +100  */

                /*" -5114- ELSE IF   SQLCODE EQUALS  +100 */
            }
            else

            if (DB.SQLCODE == +100)
            {

                /*" -5115- CONTINUE */

                /*" -5116-  WHEN OTHER  */

                /*" -5116- ELSE */
            }
            else
            {


                /*" -5118- DISPLAY 'SICP001S- ERRO ACESSO INFO REINF - ' 'CAPA DE LOTE' */
                _.Display($"SICP001S- ERRO ACESSO INFO REINF - CAPA DE LOTE");

                /*" -5120- DISPLAY 'SINISTRO ' SINISHIS-NUM-APOL-SINISTRO ' OCOR ' SINISHIS-OCORR-HISTORICO */

                $"SINISTRO {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO} OCOR {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}"
                .Display();

                /*" -5121- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -5123-  END-EVALUATE  */

                /*" -5123- END-IF */
            }


            /*" -5124- IF SINISLAN-SEQ-TP-SERVICO-INSS GREATER ZEROS */

            if (SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_SEQ_TP_SERVICO_INSS > 00)
            {

                /*" -5125- PERFORM R19300-SELECT-INSS THRU R19300-EXIT */

                R19300_SELECT_INSS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R19300_EXIT*/


                /*" -5125- END-IF. */
            }


        }

        [StopWatch]
        /*" R19200-SELECT-REINF-DB-SELECT-1 */
        public void R19200_SELECT_REINF_DB_SELECT_1()
        {
            /*" -5108- EXEC SQL SELECT SINISLAN.COD_FONTE ,SINISLAN.NUM_LOTE ,SINISLAN.NUM_APOL_SINISTRO ,SINISLAN.OCORR_HISTORICO ,SINISLAN.COD_OPERACAO ,SINISLAN.VAL_OPERACAO ,VALUE(SINISLAN.COD_PROCESSO_JURID, ' ' ) ,VALUE(SINISLAN.SEQ_TP_SERVICO_INSS,0) ,VALUE(SINISLAN.SEQ_INDICATIVO_OBRA,0) ,VALUE(SINISLAN.COD_NACIONAL_OBRA, 0) ,VALUE(SINISLAN.VLR_CUSTO_N_BASE_INSS, 0) ,VALUE(SINISLAN.VLR_BASE_CALCULO_INSS, 0) ,VALUE(SINISLAN.VLR_INSS_SUBCONTRATO, 0) ,VALUE(SINISCAP.NUM_DOCF_INTERNO, 0) ,VALUE(SINISCAP.NUM_CPF_CNPJ_FAVOREC, 0) ,VALUE(SINISCAP.NUM_CPF_CNPJ_TOMADOR, 0) ,VALUE(SINISCAP.SEQ_CNAE_CPRB, 0) ,VALUE(SINISCAP.VLR_TOTAL_DOCUMENTO, 0) ,VALUE(SINISCAP.IND_GRUPO_LANCAMENTO, ' ' ) ,VALUE(SINISCAP.IND_ISENCAO_TRIBUTO, ' ' ) ,VALUE(SINISCAP.COD_IMPOSTO_LIMINAR, 0) ,LTRIM(VALUE(SINISCAP.COD_PROCESSO_ISENCAO, ' ' )) ,VALUE(SINISCAP.VLR_RET_N_EFETUADO, 0) ,VALUE(SINISCAP.PCT_CPRB, 0) ,VALUE(SINISCAP.IND_DESC_INSS, 'S' ) ,VALUE(SINISCAP.COD_SERVICO_CONTABIL, '' ) ,VALUE(SINISCAP.COD_NAT_RENDIMENTO,0) ,VALUE(SINISCAP.COD_IMPOSTO_ISS, '' ) ,VALUE(SINISCAP.PCT_ALIQ_ISS,0) INTO :SINISLAN-COD-FONTE ,:SINISLAN-NUM-LOTE ,:SINISLAN-NUM-APOL-SINISTRO ,:SINISLAN-OCORR-HISTORICO ,:SINISLAN-COD-OPERACAO ,:SINISLAN-VAL-OPERACAO ,:SINISLAN-COD-PROCESSO-JURID ,:SINISLAN-SEQ-TP-SERVICO-INSS ,:SINISLAN-SEQ-INDICATIVO-OBRA ,:SINISLAN-COD-NACIONAL-OBRA ,:SINISLAN-VLR-CUSTO-N-BASE-INSS ,:SINISLAN-VLR-BASE-CALCULO-INSS ,:SINISLAN-VLR-INSS-SUBCONTRATO ,:SINISCAP-NUM-DOCF-INTERNO ,:SINISCAP-NUM-CPF-CNPJ-FAVOREC ,:SINISCAP-NUM-CPF-CNPJ-TOMADOR ,:SINISCAP-SEQ-CNAE-CPRB ,:SINISCAP-VLR-TOTAL-DOCUMENTO ,:SINISCAP-IND-GRUPO-LANCAMENTO ,:SINISCAP-IND-ISENCAO-TRIBUTO ,:SINISCAP-COD-IMPOSTO-LIMINAR ,:SINISCAP-COD-PROCESSO-ISENCAO ,:SINISCAP-VLR-RET-N-EFETUADO ,:SINISCAP-PCT-CPRB ,:SINISCAP-IND-DESC-INSS ,:SINISCAP-COD-SERVICO-CONTABIL ,:SINISCAP-COD-NAT-RENDIMENTO ,:SINISCAP-COD-IMPOSTO-ISS ,:SINISCAP-PCT-ALIQ-ISS FROM SEGUROS.SINISTRO_CAPALOTE1 SINISCAP ,SEGUROS.SINISTRO_LANCLOTE1 SINISLAN ,SEGUROS.GE_OPERACAO O WHERE SINISLAN.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND SINISLAN.OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND O.COD_OPERACAO = SINISLAN.COD_OPERACAO AND O.IDE_SISTEMA = 'SI' AND O.IND_TIPO_FUNCAO = :W-LIB AND SINISCAP.COD_FONTE = SINISLAN.COD_FONTE AND SINISCAP.NUM_LOTE = SINISLAN.NUM_LOTE END-EXEC. */

            var r19200_SELECT_REINF_DB_SELECT_1_Query1 = new R19200_SELECT_REINF_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
                W_LIB = AREA_DE_WORK.W_LIB.ToString(),
            };

            var executed_1 = R19200_SELECT_REINF_DB_SELECT_1_Query1.Execute(r19200_SELECT_REINF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISLAN_COD_FONTE, SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_COD_FONTE);
                _.Move(executed_1.SINISLAN_NUM_LOTE, SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_NUM_LOTE);
                _.Move(executed_1.SINISLAN_NUM_APOL_SINISTRO, SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_NUM_APOL_SINISTRO);
                _.Move(executed_1.SINISLAN_OCORR_HISTORICO, SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_OCORR_HISTORICO);
                _.Move(executed_1.SINISLAN_COD_OPERACAO, SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_COD_OPERACAO);
                _.Move(executed_1.SINISLAN_VAL_OPERACAO, SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_VAL_OPERACAO);
                _.Move(executed_1.SINISLAN_COD_PROCESSO_JURID, SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_COD_PROCESSO_JURID);
                _.Move(executed_1.SINISLAN_SEQ_TP_SERVICO_INSS, SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_SEQ_TP_SERVICO_INSS);
                _.Move(executed_1.SINISLAN_SEQ_INDICATIVO_OBRA, SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_SEQ_INDICATIVO_OBRA);
                _.Move(executed_1.SINISLAN_COD_NACIONAL_OBRA, SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_COD_NACIONAL_OBRA);
                _.Move(executed_1.SINISLAN_VLR_CUSTO_N_BASE_INSS, SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_VLR_CUSTO_N_BASE_INSS);
                _.Move(executed_1.SINISLAN_VLR_BASE_CALCULO_INSS, SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_VLR_BASE_CALCULO_INSS);
                _.Move(executed_1.SINISLAN_VLR_INSS_SUBCONTRATO, SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_VLR_INSS_SUBCONTRATO);
                _.Move(executed_1.SINISCAP_NUM_DOCF_INTERNO, SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_NUM_DOCF_INTERNO);
                _.Move(executed_1.SINISCAP_NUM_CPF_CNPJ_FAVOREC, SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_NUM_CPF_CNPJ_FAVOREC);
                _.Move(executed_1.SINISCAP_NUM_CPF_CNPJ_TOMADOR, SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_NUM_CPF_CNPJ_TOMADOR);
                _.Move(executed_1.SINISCAP_SEQ_CNAE_CPRB, SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_SEQ_CNAE_CPRB);
                _.Move(executed_1.SINISCAP_VLR_TOTAL_DOCUMENTO, SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_VLR_TOTAL_DOCUMENTO);
                _.Move(executed_1.SINISCAP_IND_GRUPO_LANCAMENTO, SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_IND_GRUPO_LANCAMENTO);
                _.Move(executed_1.SINISCAP_IND_ISENCAO_TRIBUTO, SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_IND_ISENCAO_TRIBUTO);
                _.Move(executed_1.SINISCAP_COD_IMPOSTO_LIMINAR, SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_IMPOSTO_LIMINAR);
                _.Move(executed_1.SINISCAP_COD_PROCESSO_ISENCAO, SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_PROCESSO_ISENCAO);
                _.Move(executed_1.SINISCAP_VLR_RET_N_EFETUADO, SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_VLR_RET_N_EFETUADO);
                _.Move(executed_1.SINISCAP_PCT_CPRB, SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_PCT_CPRB);
                _.Move(executed_1.SINISCAP_IND_DESC_INSS, SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_IND_DESC_INSS);
                _.Move(executed_1.SINISCAP_COD_SERVICO_CONTABIL, SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_SERVICO_CONTABIL);
                _.Move(executed_1.SINISCAP_COD_NAT_RENDIMENTO, SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_NAT_RENDIMENTO);
                _.Move(executed_1.SINISCAP_COD_IMPOSTO_ISS, SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_IMPOSTO_ISS);
                _.Move(executed_1.SINISCAP_PCT_ALIQ_ISS, SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_PCT_ALIQ_ISS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R19200_EXIT*/

        [StopWatch]
        /*" R19300-SELECT-INSS */
        private void R19300_SELECT_INSS(bool isPerform = false)
        {
            /*" -5137- DISPLAY 'R19300-SELECT-INSS' */
            _.Display($"R19300-SELECT-INSS");

            /*" -5140- MOVE SINISLAN-SEQ-TP-SERVICO-INSS TO GE612-SEQ-TP-SERVICO-INSS. */
            _.Move(SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_SEQ_TP_SERVICO_INSS, GE612.DCLGE_TP_SERVICO_INSS.GE612_SEQ_TP_SERVICO_INSS);

            /*" -5146- PERFORM R19300_SELECT_INSS_DB_SELECT_1 */

            R19300_SELECT_INSS_DB_SELECT_1();

            /*" -5149- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -5150- CONTINUE */

                /*" -5151- ELSE */
            }
            else
            {


                /*" -5152- IF SQLCODE EQUAL +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -5153- GO TO R19300-EXIT */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R19300_EXIT*/ //GOTO
                    return;

                    /*" -5154- ELSE */
                }
                else
                {


                    /*" -5155- DISPLAY 'SICP001S- ERRO ACESSO INFO TIPO SERVICO' */
                    _.Display($"SICP001S- ERRO ACESSO INFO TIPO SERVICO");

                    /*" -5156- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;

                    /*" -5157- END-IF */
                }


                /*" -5157- END-IF. */
            }


        }

        [StopWatch]
        /*" R19300-SELECT-INSS-DB-SELECT-1 */
        public void R19300_SELECT_INSS_DB_SELECT_1()
        {
            /*" -5146- EXEC SQL SELECT COD_TP_SERVICO_INSS INTO :GE612-COD-TP-SERVICO-INSS FROM SIUS.GE_TP_SERVICO_INSS WHERE SEQ_TP_SERVICO_INSS = :GE612-SEQ-TP-SERVICO-INSS END-EXEC. */

            var r19300_SELECT_INSS_DB_SELECT_1_Query1 = new R19300_SELECT_INSS_DB_SELECT_1_Query1()
            {
                GE612_SEQ_TP_SERVICO_INSS = GE612.DCLGE_TP_SERVICO_INSS.GE612_SEQ_TP_SERVICO_INSS.ToString(),
            };

            var executed_1 = R19300_SELECT_INSS_DB_SELECT_1_Query1.Execute(r19300_SELECT_INSS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE612_COD_TP_SERVICO_INSS, GE612.DCLGE_TP_SERVICO_INSS.GE612_COD_TP_SERVICO_INSS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R19300_EXIT*/

        [StopWatch]
        /*" R19400-VERIFICA-OPERACAO */
        private void R19400_VERIFICA_OPERACAO(bool isPerform = false)
        {
            /*" -5169- DISPLAY 'R19400-VERIFICA-OPERACAO' */
            _.Display($"R19400-VERIFICA-OPERACAO");

            /*" -5172- MOVE SINISHIS-COD-OPERACAO TO GEOPERAC-COD-OPERACAO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO, GEOPERAC.DCLGE_OPERACAO.GEOPERAC_COD_OPERACAO);

            /*" -5184- PERFORM R19400_VERIFICA_OPERACAO_DB_SELECT_1 */

            R19400_VERIFICA_OPERACAO_DB_SELECT_1();

            /*" -5187- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -5188- CONTINUE */

                /*" -5189- ELSE */
            }
            else
            {


                /*" -5190- IF SQLCODE EQUAL +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -5191- GO TO R19400-EXIT */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R19400_EXIT*/ //GOTO
                    return;

                    /*" -5192- ELSE */
                }
                else
                {


                    /*" -5193- DISPLAY 'SICP001S- ERRO ACESSO BUSCA OPERACAO' */
                    _.Display($"SICP001S- ERRO ACESSO BUSCA OPERACAO");

                    /*" -5194- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;

                    /*" -5195- END-IF */
                }


                /*" -5195- END-IF. */
            }


        }

        [StopWatch]
        /*" R19400-VERIFICA-OPERACAO-DB-SELECT-1 */
        public void R19400_VERIFICA_OPERACAO_DB_SELECT_1()
        {
            /*" -5184- EXEC SQL SELECT COD_OPERACAO ,DES_OPERACAO ,FUNCAO_OPERACAO ,IND_TIPO_FUNCAO INTO :GEOPERAC-COD-OPERACAO ,:GEOPERAC-DES-OPERACAO ,:GEOPERAC-FUNCAO-OPERACAO ,:GEOPERAC-IND-TIPO-FUNCAO FROM SEGUROS.GE_OPERACAO WHERE IDE_SISTEMA = 'SI' AND COD_OPERACAO = :GEOPERAC-COD-OPERACAO END-EXEC. */

            var r19400_VERIFICA_OPERACAO_DB_SELECT_1_Query1 = new R19400_VERIFICA_OPERACAO_DB_SELECT_1_Query1()
            {
                GEOPERAC_COD_OPERACAO = GEOPERAC.DCLGE_OPERACAO.GEOPERAC_COD_OPERACAO.ToString(),
            };

            var executed_1 = R19400_VERIFICA_OPERACAO_DB_SELECT_1_Query1.Execute(r19400_VERIFICA_OPERACAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GEOPERAC_COD_OPERACAO, GEOPERAC.DCLGE_OPERACAO.GEOPERAC_COD_OPERACAO);
                _.Move(executed_1.GEOPERAC_DES_OPERACAO, GEOPERAC.DCLGE_OPERACAO.GEOPERAC_DES_OPERACAO);
                _.Move(executed_1.GEOPERAC_FUNCAO_OPERACAO, GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO);
                _.Move(executed_1.GEOPERAC_IND_TIPO_FUNCAO, GEOPERAC.DCLGE_OPERACAO.GEOPERAC_IND_TIPO_FUNCAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R19400_EXIT*/

        [StopWatch]
        /*" R19500-MONTA-DESPESAS */
        private void R19500_MONTA_DESPESAS(bool isPerform = false)
        {
            /*" -5207- DISPLAY 'R19500-MONTA-DESPESAS' */
            _.Display($"R19500-MONTA-DESPESAS");

            /*" -5208- IF SINISCAP-COD-NAT-RENDIMENTO NOT EQUAL ZEROS */

            if (SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_NAT_RENDIMENTO != 00)
            {

                /*" -5210- MOVE SINISCAP-COD-NAT-RENDIMENTO TO GE420-COD-CNAE-CPRB */
                _.Move(SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_NAT_RENDIMENTO, GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_CNAE_CPRB);

                /*" -5210- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R19500_EXIT*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO */
        private void R9999_00_ROT_ERRO(bool isPerform = false)
        {
            /*" -5224- DISPLAY 'R9999-00-ROT-ERRO' */
            _.Display($"R9999-00-ROT-ERRO");

            /*" -5226- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -5228- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -5230- DISPLAY 'SICP001S- RETORNO PELA ROTINA DE ERRO ' */
            _.Display($"SICP001S- RETORNO PELA ROTINA DE ERRO ");

            /*" -5230- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -5234- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -5235- MOVE '1' TO LK-SICPW001-COD-RETORNO. */
            _.Move("1", SICPW001.LK_SICPW001_COD_RETORNO);

            /*" -5238- MOVE 'PROBLEMA NA SICP001S- VEJA DISPLAYS' TO LK-SICPW001-MENSAGEM-RETORNO. */
            _.Move("PROBLEMA NA SICP001S- VEJA DISPLAYS", SICPW001.LK_SICPW001_MENSAGEM_RETORNO);

            /*" -5238- GO TO RXXXX-ROTINA-RETORNO. */

            RXXXX_ROTINA_RETORNO(); //GOTO
            return;

        }

        [StopWatch]
        /*" P9999-CHAMA-RSGESERR */
        private void P9999_CHAMA_RSGESERR(bool isPerform = false)
        {
            /*" -5247- DISPLAY 'P9999-CHAMA-RSGESERR' */
            _.Display($"P9999-CHAMA-RSGESERR");

            /*" -5249- MOVE LK-SICPW001-COD-PROGRAMA TO LKERR-ORIGEM. */
            _.Move(SICPW001.LK_SICPW001_COD_PROGRAMA, RSGEWERR.LKERR_REG.LKERR_ORIGEM);

            /*" -5250- MOVE 'SICP001S' TO LKERR-PROGRAMA. */
            _.Move("SICP001S", RSGEWERR.LKERR_REG.LKERR_PROGRAMA);

            /*" -5251- MOVE 'BATCH' TO LKERR-USUARIO. */
            _.Move("BATCH", RSGEWERR.LKERR_REG.LKERR_USUARIO);

            /*" -5252- MOVE WS-COMPILED-EDIT TO LKERR-DTHCATAL. */
            _.Move(RSGEWDTA.RSS_WORK_DATAS.WS_COMPILED_EDIT, RSGEWERR.LKERR_REG.LKERR_DTHCATAL);

            /*" -5253- MOVE SPACES TO LKERR-MENSAGEM. */
            _.Move("", RSGEWERR.LKERR_REG.LKERR_MENSAGEM);

            /*" -5254- MOVE 2 TO LKERR-IND-ERRO. */
            _.Move(2, RSGEWERR.LKERR_REG.LKERR_IND_ERRO);

            /*" -5256- MOVE SPACES TO LKERR-LINKAGE. */
            _.Move("", RSGEWERR.LKERR_REG.LKERR_LINKAGE);

            /*" -5258- MOVE 'RSGESERR' TO WS-PROGRAMA. */
            _.Move("RSGESERR", AREA_DE_WORK.WS_PROGRAMA);

            /*" -5261- CALL WS-PROGRAMA USING SQLCA LK-ERRO-DB2. */
            _.Call(AREA_DE_WORK.WS_PROGRAMA, RSGEWERR);

            /*" -5262- DISPLAY '*  ' LKERR-MENSAGEM-RETORNO. */
            _.Display($"*  {RSGEWERR.LKERR_REG.LKERR_MENSAGEM_RETORNO}");

            /*" -5264- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -5264- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -5267- MOVE '1' TO LK-SICPW001-COD-RETORNO. */
            _.Move("1", SICPW001.LK_SICPW001_COD_RETORNO);

            /*" -5270- MOVE 'PROBLEMA NA SICP001S- VEJA DISPLAYS' TO LK-SICPW001-MENSAGEM-RETORNO. */
            _.Move("PROBLEMA NA SICP001S- VEJA DISPLAYS", SICPW001.LK_SICPW001_MENSAGEM_RETORNO);

            /*" -5270- GO TO RXXXX-ROTINA-RETORNO. */

            RXXXX_ROTINA_RETORNO(); //GOTO
            return;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P9999_99_EXIT*/

        [StopWatch]
        /*" R8887-DISPLAY-GE420 */
        private void R8887_DISPLAY_GE420(bool isPerform = false)
        {
            /*" -5279- DISPLAY 'R8887-DISPLAY-GE420' */
            _.Display($"R8887-DISPLAY-GE420");

            /*" -5281- DISPLAY 'GE420-NUM-ID-ENVIO.............' GE420-NUM-ID-ENVIO */
            _.Display($"GE420-NUM-ID-ENVIO.............{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_ID_ENVIO}");

            /*" -5283- DISPLAY 'GE420-SEQ-ID-ENVIO-HIST........' GE420-SEQ-ID-ENVIO-HIST */
            _.Display($"GE420-SEQ-ID-ENVIO-HIST........{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_SEQ_ID_ENVIO_HIST}");

            /*" -5285- DISPLAY 'GE420-STA-ENVIO-MOVIMENTO......' GE420-STA-ENVIO-MOVIMENTO */
            _.Display($"GE420-STA-ENVIO-MOVIMENTO......{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_STA_ENVIO_MOVIMENTO}");

            /*" -5287- DISPLAY 'GE420-COD-EMPRESA-SAP..........' GE420-COD-EMPRESA-SAP */
            _.Display($"GE420-COD-EMPRESA-SAP..........{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_EMPRESA_SAP}");

            /*" -5289- DISPLAY 'GE420-COD-SISTEMA-SAP..........' GE420-COD-SISTEMA-SAP */
            _.Display($"GE420-COD-SISTEMA-SAP..........{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_SISTEMA_SAP}");

            /*" -5291- DISPLAY 'GE420-COD-EVENTO-SAP...........' GE420-COD-EVENTO-SAP */
            _.Display($"GE420-COD-EVENTO-SAP...........{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_EVENTO_SAP}");

            /*" -5293- DISPLAY 'GE420-COD-CHAVE-NEGOCIO........' GE420-COD-CHAVE-NEGOCIO */
            _.Display($"GE420-COD-CHAVE-NEGOCIO........{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_CHAVE_NEGOCIO}");

            /*" -5295- DISPLAY 'GE420-COD-USUARIO-LIB..........' GE420-COD-USUARIO-LIB */
            _.Display($"GE420-COD-USUARIO-LIB..........{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_USUARIO_LIB}");

            /*" -5297- DISPLAY 'GE420-NOM-PROGRAMA.............' GE420-NOM-PROGRAMA */
            _.Display($"GE420-NOM-PROGRAMA.............{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NOM_PROGRAMA}");

            /*" -5299- DISPLAY 'GE420-NOM-RAZ-SOCIAL...........' GE420-NOM-RAZ-SOCIAL */
            _.Display($"GE420-NOM-RAZ-SOCIAL...........{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NOM_RAZ_SOCIAL}");

            /*" -5301- DISPLAY 'GE420-IND-TIPO-PESSOA..........' GE420-IND-TIPO-PESSOA */
            _.Display($"GE420-IND-TIPO-PESSOA..........{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_IND_TIPO_PESSOA}");

            /*" -5302- DISPLAY 'GE420-IND-SEXO.................' GE420-IND-SEXO */
            _.Display($"GE420-IND-SEXO.................{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_IND_SEXO}");

            /*" -5303- DISPLAY 'WH-SEXO-NULL...................' WH-SEXO-NULL */
            _.Display($"WH-SEXO-NULL...................{WH_SEXO_NULL}");

            /*" -5305- DISPLAY 'GE420-NUM-CPF-CNPJ.............' GE420-NUM-CPF-CNPJ */
            _.Display($"GE420-NUM-CPF-CNPJ.............{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_CPF_CNPJ}");

            /*" -5307- DISPLAY 'GE420-NUM-CPF-CNPJ-BENEF.......' GE420-NUM-CPF-CNPJ-BENEF */
            _.Display($"GE420-NUM-CPF-CNPJ-BENEF.......{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_CPF_CNPJ_BENEF}");

            /*" -5309- DISPLAY 'WH-CPF-CNPJ-BENEF-NULL.........' WH-CPF-CNPJ-BENEF-NULL */
            _.Display($"WH-CPF-CNPJ-BENEF-NULL.........{WH_CPF_CNPJ_BENEF_NULL}");

            /*" -5311- DISPLAY 'GE420-NOM-LOGRADOURO...........' GE420-NOM-LOGRADOURO */
            _.Display($"GE420-NOM-LOGRADOURO...........{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NOM_LOGRADOURO}");

            /*" -5313- DISPLAY 'WH-LOGRADOURO-NULL.............' WH-LOGRADOURO-NULL */
            _.Display($"WH-LOGRADOURO-NULL.............{WH_LOGRADOURO_NULL}");

            /*" -5315- DISPLAY 'GE420-DES-NUM-RESIDENCIA.......' GE420-DES-NUM-RESIDENCIA */
            _.Display($"GE420-DES-NUM-RESIDENCIA.......{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DES_NUM_RESIDENCIA}");

            /*" -5317- DISPLAY 'WH-NUM-RESIDENCIA-NULL.........' WH-NUM-RESIDENCIA-NULL */
            _.Display($"WH-NUM-RESIDENCIA-NULL.........{WH_NUM_RESIDENCIA_NULL}");

            /*" -5319- DISPLAY 'GE420-DES-COMPL-ENDERECO.......' GE420-DES-COMPL-ENDERECO */
            _.Display($"GE420-DES-COMPL-ENDERECO.......{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DES_COMPL_ENDERECO}");

            /*" -5321- DISPLAY 'WH-COMPL-ENDERECO-NULL.........' WH-COMPL-ENDERECO-NULL */
            _.Display($"WH-COMPL-ENDERECO-NULL.........{WH_COMPL_ENDERECO_NULL}");

            /*" -5322- DISPLAY 'GE420-NOM-BAIRRO...............' GE420-NOM-BAIRRO */
            _.Display($"GE420-NOM-BAIRRO...............{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NOM_BAIRRO}");

            /*" -5323- DISPLAY 'WH-BAIRRO-NULL.................' WH-BAIRRO-NULL */
            _.Display($"WH-BAIRRO-NULL.................{WH_BAIRRO_NULL}");

            /*" -5324- DISPLAY 'GE420-NOM-CIDADE...............' GE420-NOM-CIDADE */
            _.Display($"GE420-NOM-CIDADE...............{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NOM_CIDADE}");

            /*" -5325- DISPLAY 'WH-CIDADE-NULL.................' WH-CIDADE-NULL */
            _.Display($"WH-CIDADE-NULL.................{WH_CIDADE_NULL}");

            /*" -5326- DISPLAY 'GE420-COD-UF...................' GE420-COD-UF */
            _.Display($"GE420-COD-UF...................{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_UF}");

            /*" -5327- DISPLAY 'WH-UF-NULL.....................' WH-UF-NULL */
            _.Display($"WH-UF-NULL.....................{WH_UF_NULL}");

            /*" -5328- DISPLAY 'GE420-COD-CEP..................' GE420-COD-CEP */
            _.Display($"GE420-COD-CEP..................{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_CEP}");

            /*" -5329- DISPLAY 'WH-CEP-NULL....................' WH-CEP-NULL */
            _.Display($"WH-CEP-NULL....................{WH_CEP_NULL}");

            /*" -5330- DISPLAY 'GE420-DES-EMAIL................' GE420-DES-EMAIL */
            _.Display($"GE420-DES-EMAIL................{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DES_EMAIL}");

            /*" -5331- DISPLAY 'WH-EMAIL-NULL..................' WH-EMAIL-NULL */
            _.Display($"WH-EMAIL-NULL..................{WH_EMAIL_NULL}");

            /*" -5333- DISPLAY 'GE420-NUM-TELEFONE.............' GE420-NUM-TELEFONE */
            _.Display($"GE420-NUM-TELEFONE.............{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_TELEFONE}");

            /*" -5334- DISPLAY 'WH-TELEFONE-NULL...............' WH-TELEFONE-NULL */
            _.Display($"WH-TELEFONE-NULL...............{WH_TELEFONE_NULL}");

            /*" -5335- DISPLAY 'GE420-DES-FAX..................' GE420-DES-FAX */
            _.Display($"GE420-DES-FAX..................{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DES_FAX}");

            /*" -5336- DISPLAY 'WH-FAX-NULL....................' WH-FAX-NULL */
            _.Display($"WH-FAX-NULL....................{WH_FAX_NULL}");

            /*" -5338- DISPLAY 'GE420-NUM-INSC-MUNICIPAL.......' GE420-NUM-INSC-MUNICIPAL */
            _.Display($"GE420-NUM-INSC-MUNICIPAL.......{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_INSC_MUNICIPAL}");

            /*" -5340- DISPLAY 'WH-INSC-MUNICIPAL-NULL.........' WH-INSC-MUNICIPAL-NULL */
            _.Display($"WH-INSC-MUNICIPAL-NULL.........{WH_INSC_MUNICIPAL_NULL}");

            /*" -5342- DISPLAY 'GE420-NUM-INSC-ESTADUAL........' GE420-NUM-INSC-ESTADUAL */
            _.Display($"GE420-NUM-INSC-ESTADUAL........{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_INSC_ESTADUAL}");

            /*" -5344- DISPLAY 'WH-INSC-ESTADUAL-NULL..........' WH-INSC-ESTADUAL-NULL */
            _.Display($"WH-INSC-ESTADUAL-NULL..........{WH_INSC_ESTADUAL_NULL}");

            /*" -5346- DISPLAY 'GE420-IND-OPT-SIMPLES-FEDERAL..' GE420-IND-OPT-SIMPLES-FEDERAL */
            _.Display($"GE420-IND-OPT-SIMPLES-FEDERAL..{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_IND_OPT_SIMPLES_FEDERAL}");

            /*" -5348- DISPLAY 'WH-OPT-SIMPLES-FEDERAL-NULL....' WH-OPT-SIMPLES-FEDERAL-NULL */
            _.Display($"WH-OPT-SIMPLES-FEDERAL-NULL....{WH_OPT_SIMPLES_FEDERAL_NULL}");

            /*" -5350- DISPLAY 'GE420-COD-CONVENIO.............' GE420-COD-CONVENIO */
            _.Display($"GE420-COD-CONVENIO.............{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_CONVENIO}");

            /*" -5351- DISPLAY 'WH-CONVENIO-NULL...............' WH-CONVENIO-NULL */
            _.Display($"WH-CONVENIO-NULL...............{WH_CONVENIO_NULL}");

            /*" -5353- DISPLAY 'GE420-IND-TP-CONVENIO..........' GE420-IND-TP-CONVENIO */
            _.Display($"GE420-IND-TP-CONVENIO..........{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_IND_TP_CONVENIO}");

            /*" -5355- DISPLAY 'WH-TP-CONVENIO-NULL............' WH-TP-CONVENIO-NULL */
            _.Display($"WH-TP-CONVENIO-NULL............{WH_TP_CONVENIO_NULL}");

            /*" -5357- DISPLAY 'GE420-IND-FORMA-PAG-COB........' GE420-IND-FORMA-PAG-COB */
            _.Display($"GE420-IND-FORMA-PAG-COB........{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_IND_FORMA_PAG_COB}");

            /*" -5359- DISPLAY 'WH-FORMA-PAG-COB-NULL..........' WH-FORMA-PAG-COB-NULL */
            _.Display($"WH-FORMA-PAG-COB-NULL..........{WH_FORMA_PAG_COB_NULL}");

            /*" -5360- DISPLAY 'GE420-TXT-EMPRESA..............' GE420-TXT-EMPRESA */
            _.Display($"GE420-TXT-EMPRESA..............{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_TXT_EMPRESA}");

            /*" -5362- DISPLAY 'GE420-TXT-EMPRESA-LEN..........' GE420-TXT-EMPRESA-LEN */
            _.Display($"GE420-TXT-EMPRESA-LEN..........{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_TXT_EMPRESA.GE420_TXT_EMPRESA_LEN}");

            /*" -5364- DISPLAY 'GE420-TXT-EMPRESA-TEXT.........' GE420-TXT-EMPRESA-TEXT */
            _.Display($"GE420-TXT-EMPRESA-TEXT.........{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_TXT_EMPRESA.GE420_TXT_EMPRESA_TEXT}");

            /*" -5366- DISPLAY 'GE420-COD-DOC-SIACC............' GE420-COD-DOC-SIACC */
            _.Display($"GE420-COD-DOC-SIACC............{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_DOC_SIACC}");

            /*" -5367- DISPLAY 'WH-DOC-SIACC-NULL..............' WH-DOC-SIACC-NULL */
            _.Display($"WH-DOC-SIACC-NULL..............{WH_DOC_SIACC_NULL}");

            /*" -5369- DISPLAY 'GE420-DTA-SOL-PAGTO............' GE420-DTA-SOL-PAGTO */
            _.Display($"GE420-DTA-SOL-PAGTO............{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DTA_SOL_PAGTO}");

            /*" -5370- DISPLAY 'GE420-COD-BANCO................' GE420-COD-BANCO */
            _.Display($"GE420-COD-BANCO................{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_BANCO}");

            /*" -5371- DISPLAY 'WH-BANCO-NULL..................' WH-BANCO-NULL */
            _.Display($"WH-BANCO-NULL..................{WH_BANCO_NULL}");

            /*" -5372- DISPLAY 'GE420-COD-AGENCIA..............' GE420-COD-AGENCIA */
            _.Display($"GE420-COD-AGENCIA..............{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_AGENCIA}");

            /*" -5373- DISPLAY 'WH-AGENCIA-NULL................' WH-AGENCIA-NULL */
            _.Display($"WH-AGENCIA-NULL................{WH_AGENCIA_NULL}");

            /*" -5375- DISPLAY 'GE420-NUM-DV-AGENCIA...........' GE420-NUM-DV-AGENCIA */
            _.Display($"GE420-NUM-DV-AGENCIA...........{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_DV_AGENCIA}");

            /*" -5377- DISPLAY 'WH-DV-AGENCIA-NULL.............' WH-DV-AGENCIA-NULL */
            _.Display($"WH-DV-AGENCIA-NULL.............{WH_DV_AGENCIA_NULL}");

            /*" -5379- DISPLAY 'GE420-NUM-OPERACAO-CONTA.......' GE420-NUM-OPERACAO-CONTA */
            _.Display($"GE420-NUM-OPERACAO-CONTA.......{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_OPERACAO_CONTA}");

            /*" -5381- DISPLAY 'WH-OPERACAO-CONTA-NULL.........' WH-OPERACAO-CONTA-NULL */
            _.Display($"WH-OPERACAO-CONTA-NULL.........{WH_OPERACAO_CONTA_NULL}");

            /*" -5382- DISPLAY 'GE420-NUM-CC...................' GE420-NUM-CC */
            _.Display($"GE420-NUM-CC...................{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_CC}");

            /*" -5383- DISPLAY 'WH-CC-NULL.....................' WH-CC-NULL */
            _.Display($"WH-CC-NULL.....................{WH_CC_NULL}");

            /*" -5385- DISPLAY 'GE420-NUM-DV-CONTA.............' GE420-NUM-DV-CONTA */
            _.Display($"GE420-NUM-DV-CONTA.............{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_DV_CONTA}");

            /*" -5386- DISPLAY 'WH-DV-CONTA-NULL...............' WH-DV-CONTA-NULL */
            _.Display($"WH-DV-CONTA-NULL...............{WH_DV_CONTA_NULL}");

            /*" -5387- DISPLAY 'GE420-VLR-PAGTO................' GE420-VLR-PAGTO */
            _.Display($"GE420-VLR-PAGTO................{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_VLR_PAGTO}");

            /*" -5389- DISPLAY 'GE420-VLR-ATU-MONETARIA........' GE420-VLR-ATU-MONETARIA */
            _.Display($"GE420-VLR-ATU-MONETARIA........{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_VLR_ATU_MONETARIA}");

            /*" -5391- DISPLAY 'GE420-VLR-ATU-JUROS............' GE420-VLR-ATU-JUROS */
            _.Display($"GE420-VLR-ATU-JUROS............{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_VLR_ATU_JUROS}");

            /*" -5393- DISPLAY 'GE420-COD-CONGENERE............' GE420-COD-CONGENERE */
            _.Display($"GE420-COD-CONGENERE............{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_CONGENERE}");

            /*" -5394- DISPLAY 'WH-CONGENERE-NULL..............' WH-CONGENERE-NULL */
            _.Display($"WH-CONGENERE-NULL..............{WH_CONGENERE_NULL}");

            /*" -5396- DISPLAY 'GE420-COD-FONTE-SIAS...........' GE420-COD-FONTE-SIAS */
            _.Display($"GE420-COD-FONTE-SIAS...........{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_FONTE_SIAS}");

            /*" -5398- DISPLAY 'WH-FONTE-SIAS-NULL.............' WH-FONTE-SIAS-NULL */
            _.Display($"WH-FONTE-SIAS-NULL.............{WH_FONTE_SIAS_NULL}");

            /*" -5400- DISPLAY 'GE420-COD-RAMO-SUSEP...........' GE420-COD-RAMO-SUSEP */
            _.Display($"GE420-COD-RAMO-SUSEP...........{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_RAMO_SUSEP}");

            /*" -5402- DISPLAY 'WH-RAMO-SUSEP-NULL.............' WH-RAMO-SUSEP-NULL */
            _.Display($"WH-RAMO-SUSEP-NULL.............{WH_RAMO_SUSEP_NULL}");

            /*" -5404- DISPLAY 'GE420-COD-PRODUTO..............' GE420-COD-PRODUTO */
            _.Display($"GE420-COD-PRODUTO..............{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_PRODUTO}");

            /*" -5405- DISPLAY 'WH-PRODUTO-NULL................' WH-PRODUTO-NULL */
            _.Display($"WH-PRODUTO-NULL................{WH_PRODUTO_NULL}");

            /*" -5406- DISPLAY 'GE420-NUM-APOLICE..............' GE420-NUM-APOLICE */
            _.Display($"GE420-NUM-APOLICE..............{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_APOLICE}");

            /*" -5407- DISPLAY 'WH-APOLICE-NULL................' WH-APOLICE-NULL */
            _.Display($"WH-APOLICE-NULL................{WH_APOLICE_NULL}");

            /*" -5409- DISPLAY 'GE420-NUM-SINISTRO.............' GE420-NUM-SINISTRO */
            _.Display($"GE420-NUM-SINISTRO.............{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_SINISTRO}");

            /*" -5411- DISPLAY 'GE420-COD-OPERACAO.............' GE420-COD-OPERACAO */
            _.Display($"GE420-COD-OPERACAO.............{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_OPERACAO}");

            /*" -5412- DISPLAY 'WH-OPERACAO-NULL...............' WH-OPERACAO-NULL */
            _.Display($"WH-OPERACAO-NULL...............{WH_OPERACAO_NULL}");

            /*" -5414- DISPLAY 'GE420-NUM-OCORR-HISTORICO......' GE420-NUM-OCORR-HISTORICO */
            _.Display($"GE420-NUM-OCORR-HISTORICO......{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_OCORR_HISTORICO}");

            /*" -5416- DISPLAY 'WH-OCORR-HISTORICO-NULL........' WH-OCORR-HISTORICO-NULL */
            _.Display($"WH-OCORR-HISTORICO-NULL........{WH_OCORR_HISTORICO_NULL}");

            /*" -5417- DISPLAY 'GE420-DTA-AVISO................' GE420-DTA-AVISO */
            _.Display($"GE420-DTA-AVISO................{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DTA_AVISO}");

            /*" -5418- DISPLAY 'WH-AVISO-NULL..................' WH-AVISO-NULL */
            _.Display($"WH-AVISO-NULL..................{WH_AVISO_NULL}");

            /*" -5420- DISPLAY 'GE420-DTA-COMUNICACAO..........' GE420-DTA-COMUNICACAO */
            _.Display($"GE420-DTA-COMUNICACAO..........{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DTA_COMUNICACAO}");

            /*" -5422- DISPLAY 'WH-COMUNICACAO-NULL............' WH-COMUNICACAO-NULL */
            _.Display($"WH-COMUNICACAO-NULL............{WH_COMUNICACAO_NULL}");

            /*" -5424- DISPLAY 'GE420-DTA-SENTENCA-JUDICIAL....' GE420-DTA-SENTENCA-JUDICIAL */
            _.Display($"GE420-DTA-SENTENCA-JUDICIAL....{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DTA_SENTENCA_JUDICIAL}");

            /*" -5426- DISPLAY 'WH-SENTENCA-JUDICIAL-NULL......' WH-SENTENCA-JUDICIAL-NULL */
            _.Display($"WH-SENTENCA-JUDICIAL-NULL......{WH_SENTENCA_JUDICIAL_NULL}");

            /*" -5428- DISPLAY 'GE420-DTA-COMUNIC-SENTEN.......' GE420-DTA-COMUNIC-SENTEN */
            _.Display($"GE420-DTA-COMUNIC-SENTEN.......{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DTA_COMUNIC_SENTEN}");

            /*" -5430- DISPLAY 'WH-COMUNIC-SENTEN-NULL.........' WH-COMUNIC-SENTEN-NULL */
            _.Display($"WH-COMUNIC-SENTEN-NULL.........{WH_COMUNIC_SENTEN_NULL}");

            /*" -5432- DISPLAY 'GE420-COD-PROCES-JURID.........' GE420-COD-PROCES-JURID */
            _.Display($"GE420-COD-PROCES-JURID.........{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_PROCES_JURID}");

            /*" -5434- DISPLAY 'WH-PROCES-JURID-NULL...........' WH-PROCES-JURID-NULL */
            _.Display($"WH-PROCES-JURID-NULL...........{WH_PROCES_JURID_NULL}");

            /*" -5436- DISPLAY 'GE420-COD-SERVICO-SAP..........' GE420-COD-SERVICO-SAP */
            _.Display($"GE420-COD-SERVICO-SAP..........{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_SERVICO_SAP}");

            /*" -5438- DISPLAY 'WH-SERVICO-SAP-NULL............' WH-SERVICO-SAP-NULL */
            _.Display($"WH-SERVICO-SAP-NULL............{WH_SERVICO_SAP_NULL}");

            /*" -5440- DISPLAY 'GE420-COD-FONTE-ISS............' GE420-COD-FONTE-ISS */
            _.Display($"GE420-COD-FONTE-ISS............{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_FONTE_ISS}");

            /*" -5441- DISPLAY 'WH-FONTE-ISS-NULL..............' WH-FONTE-ISS-NULL */
            _.Display($"WH-FONTE-ISS-NULL..............{WH_FONTE_ISS_NULL}");

            /*" -5443- DISPLAY 'GE420-NUM-DOC-FISCAL...........' GE420-NUM-DOC-FISCAL */
            _.Display($"GE420-NUM-DOC-FISCAL...........{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_DOC_FISCAL}");

            /*" -5445- DISPLAY 'WH-DOC-FISCAL-NULL.............' WH-DOC-FISCAL-NULL */
            _.Display($"WH-DOC-FISCAL-NULL.............{WH_DOC_FISCAL_NULL}");

            /*" -5447- DISPLAY 'GE420-NUM-SERIE-DOC-FISCAL.....' GE420-NUM-SERIE-DOC-FISCAL */
            _.Display($"GE420-NUM-SERIE-DOC-FISCAL.....{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_SERIE_DOC_FISCAL}");

            /*" -5449- DISPLAY 'WH-SERIE-DOC-FISCAL-NULL.......' WH-SERIE-DOC-FISCAL-NULL */
            _.Display($"WH-SERIE-DOC-FISCAL-NULL.......{WH_SERIE_DOC_FISCAL_NULL}");

            /*" -5451- DISPLAY 'GE420-COD-AGRUPADOR............' GE420-COD-AGRUPADOR */
            _.Display($"GE420-COD-AGRUPADOR............{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_AGRUPADOR}");

            /*" -5452- DISPLAY 'WH-AGRUPADOR-NULL..............' WH-AGRUPADOR-NULL */
            _.Display($"WH-AGRUPADOR-NULL..............{WH_AGRUPADOR_NULL}");

            /*" -5454- DISPLAY 'GE420-NUM-CPF-CNPJ-TOMADOR.....' GE420-NUM-CPF-CNPJ-TOMADOR */
            _.Display($"GE420-NUM-CPF-CNPJ-TOMADOR.....{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_CPF_CNPJ_TOMADOR}");

            /*" -5456- DISPLAY 'WH-CPF-CNPJ-TOMADOR-NULL.......' WH-CPF-CNPJ-TOMADOR-NULL */
            _.Display($"WH-CPF-CNPJ-TOMADOR-NULL.......{WH_CPF_CNPJ_TOMADOR_NULL}");

            /*" -5458- DISPLAY 'GE420-COD-INDICATIVO-OBRA......' GE420-COD-INDICATIVO-OBRA */
            _.Display($"GE420-COD-INDICATIVO-OBRA......{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_INDICATIVO_OBRA}");

            /*" -5460- DISPLAY 'WH-INDICATIVO-OBRA-NULL........' WH-INDICATIVO-OBRA-NULL */
            _.Display($"WH-INDICATIVO-OBRA-NULL........{WH_INDICATIVO_OBRA_NULL}");

            /*" -5462- DISPLAY 'GE420-COD-NACIONAL-OBRA........' GE420-COD-NACIONAL-OBRA */
            _.Display($"GE420-COD-NACIONAL-OBRA........{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_NACIONAL_OBRA}");

            /*" -5464- DISPLAY 'WH-NACIONAL-OBRA-NULL..........' WH-NACIONAL-OBRA-NULL */
            _.Display($"WH-NACIONAL-OBRA-NULL..........{WH_NACIONAL_OBRA_NULL}");

            /*" -5466- DISPLAY 'GE420-DTA-NOTA-FISCAL..........' GE420-DTA-NOTA-FISCAL */
            _.Display($"GE420-DTA-NOTA-FISCAL..........{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DTA_NOTA_FISCAL}");

            /*" -5468- DISPLAY 'WH-NOTA-FISCAL-NULL............' WH-NOTA-FISCAL-NULL */
            _.Display($"WH-NOTA-FISCAL-NULL............{WH_NOTA_FISCAL_NULL}");

            /*" -5470- DISPLAY 'GE420-COD-CNAE-CPRB............' GE420-COD-CNAE-CPRB */
            _.Display($"GE420-COD-CNAE-CPRB............{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_CNAE_CPRB}");

            /*" -5471- DISPLAY 'WH-CNAE-CPRB-NULL..............' WH-CNAE-CPRB-NULL */
            _.Display($"WH-CNAE-CPRB-NULL..............{WH_CNAE_CPRB_NULL}");

            /*" -5473- DISPLAY 'GE420-COD-PROCESSO-JUD.........' GE420-COD-PROCESSO-JUD */
            _.Display($"GE420-COD-PROCESSO-JUD.........{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_PROCESSO_JUD}");

            /*" -5475- DISPLAY 'WH-PROCESSO-JUD-NULL...........' WH-PROCESSO-JUD-NULL */
            _.Display($"WH-PROCESSO-JUD-NULL...........{WH_PROCESSO_JUD_NULL}");

            /*" -5477- DISPLAY 'GE420-COD-TP-SERVICO-INSS......' GE420-COD-TP-SERVICO-INSS */
            _.Display($"GE420-COD-TP-SERVICO-INSS......{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_TP_SERVICO_INSS}");

            /*" -5479- DISPLAY 'WH-TP-SERVICO-INSS-NULL........' WH-TP-SERVICO-INSS-NULL */
            _.Display($"WH-TP-SERVICO-INSS-NULL........{WH_TP_SERVICO_INSS_NULL}");

            /*" -5481- DISPLAY 'GE420-VLR-DEDUCAO-MEAT.........' GE420-VLR-DEDUCAO-MEAT */
            _.Display($"GE420-VLR-DEDUCAO-MEAT.........{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_VLR_DEDUCAO_MEAT}");

            /*" -5483- DISPLAY 'GE420-VLR-RET-NOTA-FISC........' GE420-VLR-RET-NOTA-FISC */
            _.Display($"GE420-VLR-RET-NOTA-FISC........{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_VLR_RET_NOTA_FISC}");

            /*" -5485- DISPLAY 'GE420-VLR-RET-PRINCIPAL........' GE420-VLR-RET-PRINCIPAL */
            _.Display($"GE420-VLR-RET-PRINCIPAL........{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_VLR_RET_PRINCIPAL}");

            /*" -5487- DISPLAY 'GE420-COD-IMPOSTO-LIMINAR......' GE420-COD-IMPOSTO-LIMINAR */
            _.Display($"GE420-COD-IMPOSTO-LIMINAR......{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_IMPOSTO_LIMINAR}");

            /*" -5489- DISPLAY 'WH-IMPOSTO-LIMINAR-NULL........' WH-IMPOSTO-LIMINAR-NULL */
            _.Display($"WH-IMPOSTO-LIMINAR-NULL........{WH_IMPOSTO_LIMINAR_NULL}");

            /*" -5491- DISPLAY 'GE420-NUM-PROPOSTA.............' GE420-NUM-PROPOSTA */
            _.Display($"GE420-NUM-PROPOSTA.............{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_PROPOSTA}");

            /*" -5492- DISPLAY 'WH-PROPOSTA-NULL...............' WH-PROPOSTA-NULL */
            _.Display($"WH-PROPOSTA-NULL...............{WH_PROPOSTA_NULL}");

            /*" -5494- DISPLAY 'GE420-NUM-CERTIFICADO..........' GE420-NUM-CERTIFICADO */
            _.Display($"GE420-NUM-CERTIFICADO..........{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_CERTIFICADO}");

            /*" -5496- DISPLAY 'WH-CERTIFICADO-NULL............' WH-CERTIFICADO-NULL */
            _.Display($"WH-CERTIFICADO-NULL............{WH_CERTIFICADO_NULL}");

            /*" -5497- DISPLAY 'GE420-NUM-ENDOSSO..............' GE420-NUM-ENDOSSO */
            _.Display($"GE420-NUM-ENDOSSO..............{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_ENDOSSO}");

            /*" -5498- DISPLAY 'WH-ENDOSSO-NULL................' WH-ENDOSSO-NULL */
            _.Display($"WH-ENDOSSO-NULL................{WH_ENDOSSO_NULL}");

            /*" -5499- DISPLAY 'GE420-NUM-PARCELA..............' GE420-NUM-PARCELA */
            _.Display($"GE420-NUM-PARCELA..............{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_PARCELA}");

            /*" -5500- DISPLAY 'WH-PARCELA-NULL................' WH-PARCELA-NULL */
            _.Display($"WH-PARCELA-NULL................{WH_PARCELA_NULL}");

            /*" -5502- DISPLAY 'GE420-NUM-NIT-INSS.............' GE420-NUM-NIT-INSS */
            _.Display($"GE420-NUM-NIT-INSS.............{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_NIT_INSS}");

            /*" -5503- DISPLAY 'WH-NIT-INSS-NULL...............' WH-NIT-INSS-NULL */
            _.Display($"WH-NIT-INSS-NULL...............{WH_NIT_INSS_NULL}");

            /*" -5505- DISPLAY 'GE420-COD-CANAL-VENDA..........' GE420-COD-CANAL-VENDA */
            _.Display($"GE420-COD-CANAL-VENDA..........{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_CANAL_VENDA}");

            /*" -5507- DISPLAY 'WH-CANAL-VENDA-NULL............' WH-CANAL-VENDA-NULL */
            _.Display($"WH-CANAL-VENDA-NULL............{WH_CANAL_VENDA_NULL}");

            /*" -5508- DISPLAY 'GE420-NUM-TITULO...............' GE420-NUM-TITULO */
            _.Display($"GE420-NUM-TITULO...............{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_TITULO}");

            /*" -5509- DISPLAY 'WH-TITULO-NULL.................' WH-TITULO-NULL */
            _.Display($"WH-TITULO-NULL.................{WH_TITULO_NULL}");

            /*" -5510- DISPLAY 'GE420-COD-CEDENTE..............' GE420-COD-CEDENTE */
            _.Display($"GE420-COD-CEDENTE..............{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_CEDENTE}");

            /*" -5511- DISPLAY 'WH-CEDENTE-NULL................' WH-CEDENTE-NULL */
            _.Display($"WH-CEDENTE-NULL................{WH_CEDENTE_NULL}");

            /*" -5513- DISPLAY 'GE420-COD-COMPROMISSO..........' GE420-COD-COMPROMISSO */
            _.Display($"GE420-COD-COMPROMISSO..........{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_COMPROMISSO}");

            /*" -5515- DISPLAY 'WH-COMPROMISSO-NULL............' WH-COMPROMISSO-NULL */
            _.Display($"WH-COMPROMISSO-NULL............{WH_COMPROMISSO_NULL}");

            /*" -5517- DISPLAY 'GE420-TXT-INFO-CART-CRED.......' GE420-TXT-INFO-CART-CRED */
            _.Display($"GE420-TXT-INFO-CART-CRED.......{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_TXT_INFO_CART_CRED}");

            /*" -5519- DISPLAY 'WH-INFO-CART-CRED-NULL.........' WH-INFO-CART-CRED-NULL */
            _.Display($"WH-INFO-CART-CRED-NULL.........{WH_INFO_CART_CRED_NULL}");

            /*" -5520- DISPLAY 'GE420-QTD-PARCELA..............' GE420-QTD-PARCELA */
            _.Display($"GE420-QTD-PARCELA..............{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_QTD_PARCELA}");

            /*" -5522- DISPLAY 'WH-QTD-PARCELA-NULL............' WH-QTD-PARCELA-NULL */
            _.Display($"WH-QTD-PARCELA-NULL............{WH_QTD_PARCELA_NULL}");

            /*" -5524- DISPLAY 'GE420-NUM-IDLG-MCP.............' GE420-NUM-IDLG-MCP */
            _.Display($"GE420-NUM-IDLG-MCP.............{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_IDLG_MCP}");

            /*" -5526- DISPLAY 'WH-IDLG-MCP-NULL...............' WH-IDLG-MCP-NULL */
            _.Display($"WH-IDLG-MCP-NULL...............{WH_IDLG_MCP_NULL}");

            /*" -5528- DISPLAY 'GE420-NUM-IDLG-SAP.............' GE420-NUM-IDLG-SAP */
            _.Display($"GE420-NUM-IDLG-SAP.............{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NUM_IDLG_SAP}");

            /*" -5530- DISPLAY 'WH-IDLG-SAP-NULL...............' WH-IDLG-SAP-NULL */
            _.Display($"WH-IDLG-SAP-NULL...............{WH_IDLG_SAP_NULL}");

            /*" -5532- DISPLAY 'GE420-DTA-ENVIO-MCP............' GE420-DTA-ENVIO-MCP */
            _.Display($"GE420-DTA-ENVIO-MCP............{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DTA_ENVIO_MCP}");

            /*" -5534- DISPLAY 'WH-ENVIO-MCP-NULL..............' WH-ENVIO-MCP-NULL */
            _.Display($"WH-ENVIO-MCP-NULL..............{WH_ENVIO_MCP_NULL}");

            /*" -5536- DISPLAY 'GE420-DTA-RETORNO-SAP-ARQG.....' GE420-DTA-RETORNO-SAP-ARQG */
            _.Display($"GE420-DTA-RETORNO-SAP-ARQG.....{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DTA_RETORNO_SAP_ARQG}");

            /*" -5538- DISPLAY 'WH-RETORNO-SAP-ARQG-NULL.......' WH-RETORNO-SAP-ARQG-NULL */
            _.Display($"WH-RETORNO-SAP-ARQG-NULL.......{WH_RETORNO_SAP_ARQG_NULL}");

            /*" -5540- DISPLAY 'GE420-DTA-RETORNO-SAP-ARQH.....' GE420-DTA-RETORNO-SAP-ARQH */
            _.Display($"GE420-DTA-RETORNO-SAP-ARQH.....{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DTA_RETORNO_SAP_ARQH}");

            /*" -5542- DISPLAY 'WH-RETORNO-SAP-ARQH-NULL.......' WH-RETORNO-SAP-ARQH-NULL */
            _.Display($"WH-RETORNO-SAP-ARQH-NULL.......{WH_RETORNO_SAP_ARQH_NULL}");

            /*" -5544- DISPLAY 'GE420-DTA-EFETIVO-PGTO-COB.....' GE420-DTA-EFETIVO-PGTO-COB */
            _.Display($"GE420-DTA-EFETIVO-PGTO-COB.....{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_DTA_EFETIVO_PGTO_COB}");

            /*" -5546- DISPLAY 'WH-EFETIVO-PGTO-COB-NULL.......' WH-EFETIVO-PGTO-COB-NULL */
            _.Display($"WH-EFETIVO-PGTO-COB-NULL.......{WH_EFETIVO_PGTO_COB_NULL}");

            /*" -5548- DISPLAY 'GE420-COD-MODULO-SAP...........' GE420-COD-MODULO-SAP */
            _.Display($"GE420-COD-MODULO-SAP...........{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_COD_MODULO_SAP}");

            /*" -5549- DISPLAY 'GE420-NOM-PROG-GRAVOU..........' GE420-NOM-PROG-GRAVOU. */
            _.Display($"GE420-NOM-PROG-GRAVOU..........{GE420.DCLGE_MOVTO_ENVIO_MCP.GE420_NOM_PROG_GRAVOU}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8887_EXIT*/

        [StopWatch]
        /*" R8888-DISPLAY-FETCH */
        private void R8888_DISPLAY_FETCH(bool isPerform = false)
        {
            /*" -5557- DISPLAY 'R8888-DISPLAY-FETCH' */
            _.Display($"R8888-DISPLAY-FETCH");

            /*" -5558- DISPLAY ' => DISPLAY DO FETCH DO DECLARE PRINCIPAL' */
            _.Display($" => DO FETCH DO DECLARE PRINCIPAL");

            /*" -5560- DISPLAY 'W-NOME-QUERY ..................... ' W-NOME-QUERY */
            _.Display($"W-NOME-QUERY ..................... {W_NOME_QUERY}");

            /*" -5562- DISPLAY 'SINISHIS-TIPO-REGISTRO ........... ' SINISHIS-TIPO-REGISTRO */
            _.Display($"SINISHIS-TIPO-REGISTRO ........... {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_TIPO_REGISTRO}");

            /*" -5564- DISPLAY 'W-NOME-TIPO-SEGURO ............... ' W-NOME-TIPO-SEGURO */
            _.Display($"W-NOME-TIPO-SEGURO ............... {W_NOME_TIPO_SEGURO}");

            /*" -5566- DISPLAY 'SINISHIS-NUM-APOL-SINISTRO ....... ' SINISHIS-NUM-APOL-SINISTRO */
            _.Display($"SINISHIS-NUM-APOL-SINISTRO ....... {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

            /*" -5568- DISPLAY 'SINISHIS-OCORR-HISTORICO ......... ' SINISHIS-OCORR-HISTORICO */
            _.Display($"SINISHIS-OCORR-HISTORICO ......... {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}");

            /*" -5570- DISPLAY 'SINISHIS-COD-OPERACAO  ........... ' SINISHIS-COD-OPERACAO */
            _.Display($"SINISHIS-COD-OPERACAO  ........... {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO}");

            /*" -5572- DISPLAY 'SINISHIS-NOME-FAVORECIDO ......... ' SINISHIS-NOME-FAVORECIDO */
            _.Display($"SINISHIS-NOME-FAVORECIDO ......... {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO}");

            /*" -5574- DISPLAY 'GEOPERAC-FUNCAO-OPERACAO ......... ' GEOPERAC-FUNCAO-OPERACAO */
            _.Display($"GEOPERAC-FUNCAO-OPERACAO ......... {GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO}");

            /*" -5576- DISPLAY 'GEOPERAC-IND-TIPO-FUNCAO ......... ' GEOPERAC-IND-TIPO-FUNCAO */
            _.Display($"GEOPERAC-IND-TIPO-FUNCAO ......... {GEOPERAC.DCLGE_OPERACAO.GEOPERAC_IND_TIPO_FUNCAO}");

            /*" -5578- DISPLAY 'GEOPERAC-DES-OPERACAO  ............ ' GEOPERAC-DES-OPERACAO */
            _.Display($"GEOPERAC-DES-OPERACAO  ............ {GEOPERAC.DCLGE_OPERACAO.GEOPERAC_DES_OPERACAO}");

            /*" -5580- DISPLAY 'W-ANO-OPERACIONAL-MOVIMENTO ....... ' W-ANO-OPERACIONAL-MOVIMENTO */
            _.Display($"W-ANO-OPERACIONAL-MOVIMENTO ....... {W_ANO_OPERACIONAL_MOVIMENTO}");

            /*" -5582- DISPLAY 'W-ANO-CONTABIL-MOVIMENTO  ......... ' W-ANO-CONTABIL-MOVIMENTO */
            _.Display($"W-ANO-CONTABIL-MOVIMENTO  ......... {W_ANO_CONTABIL_MOVIMENTO}");

            /*" -5584- DISPLAY 'SINISHIS-VAL-OPERACAO  ............ ' SINISHIS-VAL-OPERACAO */
            _.Display($"SINISHIS-VAL-OPERACAO  ............ {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO}");

            /*" -5586- DISPLAY 'MOVDEBCE-VLR-CREDITO  ............. ' MOVDEBCE-VLR-CREDITO */
            _.Display($"MOVDEBCE-VLR-CREDITO  ............. {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_CREDITO}");

            /*" -5588- DISPLAY 'MOVDEBCE-VALOR-DEBITO  ............ ' MOVDEBCE-VALOR-DEBITO */
            _.Display($"MOVDEBCE-VALOR-DEBITO  ............ {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO}");

            /*" -5590- DISPLAY 'SINISHIS-DATA-MOVIMENTO  .......... ' SINISHIS-DATA-MOVIMENTO */
            _.Display($"SINISHIS-DATA-MOVIMENTO  .......... {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO}");

            /*" -5592- DISPLAY 'SINISHIS-COD-PREST-SERVICO ........ ' SINISHIS-COD-PREST-SERVICO */
            _.Display($"SINISHIS-COD-PREST-SERVICO ........ {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO}");

            /*" -5594- DISPLAY 'SINISHIS-SIT-CONTABIL  ............ ' SINISHIS-SIT-CONTABIL */
            _.Display($"SINISHIS-SIT-CONTABIL  ............ {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL}");

            /*" -5596- DISPLAY 'W-NOME-FORMA-PAGAMENTO  ............ ' W-NOME-FORMA-PAGAMENTO */
            _.Display($"W-NOME-FORMA-PAGAMENTO  ............ {W_NOME_FORMA_PAGAMENTO}");

            /*" -5598- DISPLAY 'SINISHIS-NOM-PROGRAMA  ............. ' SINISHIS-NOM-PROGRAMA */
            _.Display($"SINISHIS-NOM-PROGRAMA  ............. {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOM_PROGRAMA}");

            /*" -5600- DISPLAY 'SINISMES-RAMO  ..................... ' SINISMES-RAMO */
            _.Display($"SINISMES-RAMO  ..................... {SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO}");

            /*" -5602- DISPLAY 'SINISMES-COD-FONTE ................. ' SINISMES-COD-FONTE */
            _.Display($"SINISMES-COD-FONTE ................. {SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE}");

            /*" -5604- DISPLAY 'W-DATA-AVISO-SIAS  ................. ' W-DATA-AVISO-SIAS */
            _.Display($"W-DATA-AVISO-SIAS  ................. {W_DATA_AVISO_SIAS}");

            /*" -5606- DISPLAY 'SINISMES-DATA-COMUNICADO  .......... ' SINISMES-DATA-COMUNICADO */
            _.Display($"SINISMES-DATA-COMUNICADO  .......... {SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_COMUNICADO}");

            /*" -5608- DISPLAY 'SINISMES-COD-PRODUTO  .............. ' SINISMES-COD-PRODUTO */
            _.Display($"SINISMES-COD-PRODUTO  .............. {SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO}");

            /*" -5610- DISPLAY 'PRODUTO-DESCR-PRODUTO  ............. ' PRODUTO-DESCR-PRODUTO */
            _.Display($"PRODUTO-DESCR-PRODUTO  ............. {PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO}");

            /*" -5612- DISPLAY 'CHEQUEMI-NUM-CHEQUE-INTERNO ........ ' CHEQUEMI-NUM-CHEQUE-INTERNO */
            _.Display($"CHEQUEMI-NUM-CHEQUE-INTERNO ........ {CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NUM_CHEQUE_INTERNO}");

            /*" -5614- DISPLAY 'MOVDEBCE-NUM-APOLICE  .............. ' MOVDEBCE-NUM-APOLICE */
            _.Display($"MOVDEBCE-NUM-APOLICE  .............. {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE}");

            /*" -5616- DISPLAY 'MOVDEBCE-NUM-ENDOSSO  .............. ' MOVDEBCE-NUM-ENDOSSO */
            _.Display($"MOVDEBCE-NUM-ENDOSSO  .............. {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO}");

            /*" -5618- DISPLAY 'MOVDEBCE-NUM-PARCELA  .............. ' MOVDEBCE-NUM-PARCELA */
            _.Display($"MOVDEBCE-NUM-PARCELA  .............. {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA}");

            /*" -5620- DISPLAY 'MOVDEBCE-SITUACAO-COBRANCA  ........ ' MOVDEBCE-SITUACAO-COBRANCA */
            _.Display($"MOVDEBCE-SITUACAO-COBRANCA  ........ {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA}");

            /*" -5622- DISPLAY 'W-NOME-SITUACAO-COBRANCA  .......... ' W-NOME-SITUACAO-COBRANCA */
            _.Display($"W-NOME-SITUACAO-COBRANCA  .......... {W_NOME_SITUACAO_COBRANCA}");

            /*" -5624- DISPLAY 'MOVDEBCE-DATA-VENCIMENTO  .......... ' MOVDEBCE-DATA-VENCIMENTO */
            _.Display($"MOVDEBCE-DATA-VENCIMENTO  .......... {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO}");

            /*" -5626- DISPLAY 'MOVDEBCE-DATA-MOVIMENTO ............ ' MOVDEBCE-DATA-MOVIMENTO */
            _.Display($"MOVDEBCE-DATA-MOVIMENTO ............ {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO}");

            /*" -5628- DISPLAY 'MOVDEBCE-COD-AGENCIA-DEB ........... ' MOVDEBCE-COD-AGENCIA-DEB */
            _.Display($"MOVDEBCE-COD-AGENCIA-DEB ........... {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB}");

            /*" -5630- DISPLAY 'MOVDEBCE-OPER-CONTA-DEB  ........... ' MOVDEBCE-OPER-CONTA-DEB */
            _.Display($"MOVDEBCE-OPER-CONTA-DEB  ........... {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB}");

            /*" -5632- DISPLAY 'MOVDEBCE-NUM-CONTA-DEB  ............ ' MOVDEBCE-NUM-CONTA-DEB */
            _.Display($"MOVDEBCE-NUM-CONTA-DEB  ............ {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB}");

            /*" -5634- DISPLAY 'MOVDEBCE-DIG-CONTA-DEB  ............ ' MOVDEBCE-DIG-CONTA-DEB */
            _.Display($"MOVDEBCE-DIG-CONTA-DEB  ............ {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB}");

            /*" -5636- DISPLAY 'MOVDEBCE-COD-CONVENIO  ............. ' MOVDEBCE-COD-CONVENIO */
            _.Display($"MOVDEBCE-COD-CONVENIO  ............. {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO}");

            /*" -5638- DISPLAY 'MOVDEBCE-DATA-ENVIO  ............... ' MOVDEBCE-DATA-ENVIO */
            _.Display($"MOVDEBCE-DATA-ENVIO  ............... {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_ENVIO}");

            /*" -5640- DISPLAY 'MOVDEBCE-NSAS  ..................... ' MOVDEBCE-NSAS */
            _.Display($"MOVDEBCE-NSAS  ..................... {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS}");

            /*" -5642- DISPLAY 'MOVDEBCE-NUM-REQUISICAO  ........... ' MOVDEBCE-NUM-REQUISICAO */
            _.Display($"MOVDEBCE-NUM-REQUISICAO  ........... {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO}");

            /*" -5644- DISPLAY 'GE369-COD-AGENCIA .................. ' GE369-COD-AGENCIA */
            _.Display($"GE369-COD-AGENCIA .................. {GE369.DCLGE_MOVTO_CONTA.GE369_COD_AGENCIA}");

            /*" -5646- DISPLAY 'NULL-COD-AGENCIA  .................. ' NULL-COD-AGENCIA */
            _.Display($"NULL-COD-AGENCIA  .................. {NULL_COD_AGENCIA}");

            /*" -5648- DISPLAY 'GE369-COD-BANCO  ................... ' GE369-COD-BANCO */
            _.Display($"GE369-COD-BANCO  ................... {GE369.DCLGE_MOVTO_CONTA.GE369_COD_BANCO}");

            /*" -5650- DISPLAY 'NULL-COD-BANCO  .................... ' NULL-COD-BANCO */
            _.Display($"NULL-COD-BANCO  .................... {NULL_COD_BANCO}");

            /*" -5652- DISPLAY 'GE369-NUM-CONTA-CNB ................ ' GE369-NUM-CONTA-CNB */
            _.Display($"GE369-NUM-CONTA-CNB ................ {GE369.DCLGE_MOVTO_CONTA.GE369_NUM_CONTA_CNB}");

            /*" -5654- DISPLAY 'NULL-NUM-CONTA-CNB ................. ' NULL-NUM-CONTA-CNB */
            _.Display($"NULL-NUM-CONTA-CNB ................. {NULL_NUM_CONTA_CNB}");

            /*" -5656- DISPLAY 'GE369-NUM-DV-CONTA-CNB ............. ' GE369-NUM-DV-CONTA-CNB */
            _.Display($"GE369-NUM-DV-CONTA-CNB ............. {GE369.DCLGE_MOVTO_CONTA.GE369_NUM_DV_CONTA_CNB}");

            /*" -5658- DISPLAY 'NULL-NUM-DV-CONTA-CNB .............. ' NULL-NUM-DV-CONTA-CNB */
            _.Display($"NULL-NUM-DV-CONTA-CNB .............. {NULL_NUM_DV_CONTA_CNB}");

            /*" -5660- DISPLAY 'GE369-IND-CONTA-BANCARIA ........... ' GE369-IND-CONTA-BANCARIA */
            _.Display($"GE369-IND-CONTA-BANCARIA ........... {GE369.DCLGE_MOVTO_CONTA.GE369_IND_CONTA_BANCARIA}");

            /*" -5662- DISPLAY 'NULL-IND-CONTA-BANCARIA ............ ' NULL-IND-CONTA-BANCARIA . */
            _.Display($"NULL-IND-CONTA-BANCARIA ............ {NULL_IND_CONTA_BANCARIA}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8888_EXIT*/

        [StopWatch]
        /*" R8889-DISPLAY-IMPOSTOS */
        private void R8889_DISPLAY_IMPOSTOS(bool isPerform = false)
        {
            /*" -5669- DISPLAY 'R8889-DISPLAY-IMPOSTOS' */
            _.Display($"R8889-DISPLAY-IMPOSTOS");

            /*" -5670- DISPLAY ' => DISPLAY DO FETCH DO DECLARE IMPOSTOS' */
            _.Display($" => DO FETCH DO DECLARE IMPOSTOS");

            /*" -5672- DISPLAY 'SINISHIS-NUM-APOL-SINISTRO .......... ' SINISHIS-NUM-APOL-SINISTRO */
            _.Display($"SINISHIS-NUM-APOL-SINISTRO .......... {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

            /*" -5674- DISPLAY 'SINISHIS-OCORR-HISTORICO   .......... ' SINISHIS-OCORR-HISTORICO */
            _.Display($"SINISHIS-OCORR-HISTORICO   .......... {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}");

            /*" -5676- DISPLAY 'SINISHIS-COD-OPERACAO  .......... ' SINISHIS-COD-OPERACAO */
            _.Display($"SINISHIS-COD-OPERACAO  .......... {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO}");

            /*" -5678- DISPLAY 'SIPADOFI-NUM-DOCF-INTERNO .......... ' SIPADOFI-NUM-DOCF-INTERNO */
            _.Display($"SIPADOFI-NUM-DOCF-INTERNO .......... {SIPADOFI.DCLSI_PAGA_DOC_FISCAL.SIPADOFI_NUM_DOCF_INTERNO}");

            /*" -5680- DISPLAY 'FIPADOLA-COD-TP-LANCDOCF .......... ' FIPADOLA-COD-TP-LANCDOCF */
            _.Display($"FIPADOLA-COD-TP-LANCDOCF .......... {FIPADOLA.DCLFI_PAGA_DOCF_LANC.FIPADOLA_COD_TP_LANCDOCF}");

            /*" -5682- DISPLAY 'GETPLADO-ABREV-LANCDOCF .......... ' GETPLADO-ABREV-LANCDOCF */
            _.Display($"GETPLADO-ABREV-LANCDOCF .......... {GETPLADO.DCLGE_TP_LANC_DOCF.GETPLADO_ABREV_LANCDOCF}");

            /*" -5684- DISPLAY 'FIPADOLA-VALOR-LANCAMENTO .......... ' FIPADOLA-VALOR-LANCAMENTO */
            _.Display($"FIPADOLA-VALOR-LANCAMENTO .......... {FIPADOLA.DCLFI_PAGA_DOCF_LANC.FIPADOLA_VALOR_LANCAMENTO}");

            /*" -5686- DISPLAY 'GETIPIMP-COD-IMP-INTERNO .......... ' GETIPIMP-COD-IMP-INTERNO */
            _.Display($"GETIPIMP-COD-IMP-INTERNO .......... {GETIPIMP.DCLGE_TIPO_IMPOSTO.GETIPIMP_COD_IMP_INTERNO}");

            /*" -5688- DISPLAY 'GETIPIMP-SIGLA-IMP .......... ' GETIPIMP-SIGLA-IMP */
            _.Display($"GETIPIMP-SIGLA-IMP .......... {GETIPIMP.DCLGE_TIPO_IMPOSTO.GETIPIMP_SIGLA_IMP}");

            /*" -5690- DISPLAY 'FIPADOIM-ALIQ-TRIBUTACAO .......... ' FIPADOIM-ALIQ-TRIBUTACAO */
            _.Display($"FIPADOIM-ALIQ-TRIBUTACAO .......... {FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_ALIQ_TRIBUTACAO}");

            /*" -5692- DISPLAY 'FIPADOIM-VALOR-IMPOSTO  .......... ' FIPADOIM-VALOR-IMPOSTO . */
            _.Display($"FIPADOIM-VALOR-IMPOSTO  .......... {FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_VALOR_IMPOSTO}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8889_EXIT*/

        [StopWatch]
        /*" RXXXX-ROTINA-RETORNO */
        private void RXXXX_ROTINA_RETORNO(bool isPerform = false)
        {
            /*" -5700- DISPLAY 'RXXXX-ROTINA-RETORNO' */
            _.Display($"RXXXX-ROTINA-RETORNO");

            /*" -5700- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: RXXXX_EXIT*/
    }
}