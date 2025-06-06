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
using Sias.Sinistro.DB2.SISAP01B;

namespace Code
{
    public class SISAP01B
    {
        public bool IsCall { get; set; }

        public SISAP01B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SINISTRO/FINANCEIRO                *      */
        /*"      *   PROGRAMA ...............  SISAP01B                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  HEIDER COELHO                      *      */
        /*"      *   PROGRAMADOR ............  HEIDER COELHO                      *      */
        /*"      *   DATA CODIFICACAO .......  JUNHO / 2010                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO:                                                      *      */
        /*"      *   GERAR O ARQUIVO COM OS MOVIMENTOS DE PAGAMENTO E RECEBIMENTO *      */
        /*"      *   PARA ENVIO AO SAP                                            *      */
        /*"      *   TRATA MOVIMENTO DE CREDITO OU DEBITO EM CONTA CORRENTE       *      */
        /*"      *   TABELAS DE ORIGEM: MOVTO_DEBITOCC_CEF                        *      */
        /*"      *                                                                *      */
        /*"      * CADMUS - 44.213                                                *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * HISTORICO DE VERSOES                                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * NO   VERSAO    DATA       PROGRAMADOR           ALTERACAO      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.28  * VERSAO  : 028                                                  *      */
        /*"      * DEMANDA : 226662 / TAREFA 244983                               *      */
        /*"      * DATA    : 15/05/2020                                           *      */
        /*"      * NOME    : HUSNI ALI HUSNI                                      *      */
        /*"      * MARCADOR: V.28                                                 *      */
        /*"      * MOTIVO  : CVP - INCLUIR NA PESQUISA DA CEPFAIXAFILIAL O CODIGO *      */
        /*"      *           DA EMPRES BASEADO NA INFORMACAO DO PRODUTO           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.27  * VERSAO  : 027                                                  *      */
        /*"      * MOTIVO  : REINF 2                                              *      */
        /*"      * HISTORIA: 209501 / Tarefa 210430                               *      */
        /*"      * DATA    : 25/07/2019                                           *      */
        /*"      * NOME    : RILDO SICO                                           *      */
        /*"      * MARCADOR: V.27                                                 *      */
        /*"      * VERSAO  : 027                                                  *      */
        /*"      * MOTIVO  : GRAVAR NO ARQ-A O NOME DO FAVORECIDO INFORMADO PELO  *      */
        /*"      *           SCPJUD (SINISTRO_HISTORICO) PARA IDE_SISTEMA = 'SI'  *      */
        /*"      *           E IND_TIPO_FUNCAO = 'JUD-DEP'/'JUR-INDENI'/'JUR-DESP'*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * HISTORIA: 193956                                               *      */
        /*"      * DATA    : 23/05/2017                                           *      */
        /*"      * NOME    : HUSNI ALI HUSNI                                      *      */
        /*"      * MARCADOR: V.26                                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * PROJETO REINF - OUT/2017                                       *      */
        /*"      *  ALTERA��O DO CAMPO GE_ARQUIVO_SAP.TXT_REG_SAP DE 3.952 BYTES  *      */
        /*"      *  GE0300B - 3.952 BYTES                                         *      */
        /*"      *  GE0306B - 4.834 BYTES                                         *      */
        /*"      *  PROCURAR V.01 - DOUGLAS ARAUJO - ATOS                         *      */
        /*"      *  PROCURAR V.01 - DOUGLAS ARAUJO - ATOS                         *      */
        /*"      *  PROCURAR REINF                                                *      */
        /*"V.24D *  PROCURAR V.24D - DIEGO DIAS - GESIN/INDRA EM 12/04/2018       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * PROJETO REINF - OUT/2017                                       *      */
        /*"      *  ALTERA��O DO CAMPO GE_ARQUIVO_SAP.TXT_REG_SAP DE 3.952 BYTES  *      */
        /*"      *    PARA 4.834 BYTES                                            *      */
        /*"      *  PROCURAR V.25 - DOUGLAS ARAUJO - ATOS                         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 024                                                         */
        /*"      * MOTIVO  : INCLUIR NUMERO DO SINISTRO NOS EVENTOS 9515, 9504.          */
        /*"      *           PARA MELHORA NA CONCILIACAO CONTABIL                        */
        /*"      * CADMUS  : 146956                                                      */
        /*"      * DATA    : 15/02/2017                                                  */
        /*"      * NOME    : DIOGO MATHEUS                                               */
        /*"      * MARCADOR: V.24                                                        */
        /*"      *----------------------------------------------------------------*      */
        /*"V.23  *   VERSAO 23 - CADMUS 138499                                    *      */
        /*"      *                                                                *      */
        /*"      *               - ALTERACAO NA REGRA DA BAIXA DE INDENIZACAO DE  *      */
        /*"      *  SINISTRO 'OP 1001'. ANTES ERA GERADO A BAIXA NO MOMENTO DE    *      */
        /*"      *  ENVIO PARA O SAP, GERANDO DIFERENCA NO CONTABIL E FINANCEIRO  *      */
        /*"      *  PARA OS CASOS QUE VOLTAVAM COM INSUCESSO, VISTO QUE JA CONSTA-*      */
        /*"      *  VAM COMO PAGOS, ASSIM ERA NECESSARIO GERAR ESTORNO P/ SAS.    *      */
        /*"      *  AGORA PASSA A ENVIAR P/ PGTO COM A OPERACAO CORRETA 1081      *      */
        /*"      *  E GERA 1001 SOMENTE NO RETORNO COM SUCESSO DE PAGAMENTO DO    *      */
        /*"      *  BANCO, RETIRANDO A NECESSIDADE DE GERAR ESTORNO PARA CASOS    *      */
        /*"      *  COM INSUCESSO.   (EXCETO CHEQUE)                              *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/08/2016 - DIEGO DIAS                                   *      */
        /*"      *                                       PROCURE POR V.23         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 022                                                         */
        /*"      * MOTIVO  : O SAP NAO ESTA MAIS ACEITANDO VALOR TEXTO NO CAMPO          */
        /*"      *           BKREF                                                       */
        /*"      * CADMUS  : ERRO SAP NO ARQ-A                                           */
        /*"      * DATA    : 17/06/2016                                                  */
        /*"      * NOME    : DIOGO MATHEUS                                               */
        /*"      * MARCADOR: V.22                                                        */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO...: V.21        -   GUILHERME CORREIA                  *      */
        /*"      *  CADMUS...: 136539                                             *      */
        /*"      *  DATA ....: 18/05/2016                                         *      */
        /*"      *  AGORA O SAP QUER QUE MUDE O EVENTO PARA 09515 E NAO MAIS 09505*      */
        /*"      *  COMO FOI SOLICITADO INICIALMENTE.                             *      */
        /*"      *  TODOS OS RESSARCIMENTOS ESTAO REPRESADOS NO SAP DESDE A SUBIDA*      */
        /*"      *  DA DEMANDA 129207.                                            *      */
        /*"      *                                                                *      */
        /*"      *                             PROCURAR V.21                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO...: V.20        -   GUILHERME CORREIA                  *      */
        /*"      *  CADMUS...: 129207                                             *      */
        /*"      *  DATA ....: 03/02/2016                                         *      */
        /*"      *  SUSEP E CONTABILIDADE INVENTARAM QUE ESTORNO N PODE MAIS PARA *      */
        /*"      *  OS PRODUTOS CCA E LOTERICO E SOLICITARAM CRIACAO DAS OPERACOES*      */
        /*"      *  DE RESSARCIMENTO, TAMBEM FOI SOLICITADO GERAR O EVENTO        *      */
        /*"      *  SIAS_09505.                                                   *      */
        /*"      *  RESSARC SERA FEITO VIA DEBITO EM CONTA                        *      */
        /*"      *                                                                *      */
        /*"      *                             PROCURAR V.20                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 19 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 10/12/2014 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.19         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 18   V.18      29/04/2014 DIEGO DIAS     REGRA DE DIGITO DV BANC      */
        /*"      *      AJUSTAR A REGRA DO DV DO BANCO NA CHAMADA DA GE0080B             */
        /*"      *      QUANDO NAO ENCONTRA BANCO, POIS � MOVIDO '?' PARA O CAMPO *      */
        /*"      *      DV DO BANCO, O QUE ATUALMENTE CAUSA ERRO NO CADASTRO SAP E*      */
        /*"      *      NO ENVIO DE PAGAMENTO, ALEM DO RECOMANDO DO PAGAMENTO QUE        */
        /*"      *      � FEITO MANUAL APOS ERRO. ASIM SER� MOVIDO 0 POR PADRAO          */
        /*"      *                                                                       */
        /*"      *                                          CADMUS 97259 29/04/14 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 17   V.17      15/08/2013 PATRICIA SALES    RETIRA FILTRO      *      */
        /*"      *      INCLUIDO NA VERSAO 16 NO DIA 14/08.                              */
        /*"      *                           RESOLVER ABEND CADMUS 86256 15/08/13 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.16  * 16   V.16      14/08/2013 DIEGO DIAS        INSERIR FILTRO COM *      */
        /*"      *      CAMPO NUM-ENDOSSO PARA RESOLVER ABEND ONDE RETORNA MAIS DE*      */
        /*"      *      UMA OCORRENCIA DE HISTORICO NA TABELA SI_PESS_SINISTRO    *      */
        /*"      *                           RESOLVER ABEND CADMUS 86170 14/08/13 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 15   V.15      27/03/2012 PATRICIA SALES    RETIRANDO PRESTADOR*      */
        /*"      *                                             DE SERVICO CAIXA.  *      */
        /*"      *                           RESOLVER ABEND CADMUS 68080 26/03/12 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * HEIDER EM 20/01/2012 - APENAS RETIRANDO DISPLYAS EXTRAS, VISANDO      */
        /*"      *        PERFORMANCE DE EXECUCAO                                        */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   HISTORICO DE ALTERACAO                                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.13  * JEFFERSON - 26/10/2011                                         *      */
        /*"      *   INCLUIR O CODIGO J2 PARA PAGAMENTO DE VIGILANCIA             *      */
        /*"      *   PROCURAR POR: V13                                            *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.12  * HEIDER - 18/02/2011                                                   */
        /*"      *   INCLUIR O FI0096B = SI5071B E FI0095B = SI5070B                     */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.11  * HEIDER - 09/02/2011                                                   */
        /*"      *   FIRST E LAST NAME PARA O 43350                                      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.10  * HEIDER - 08/02/2011                                                   */
        /*"      *   TROCAR OS PARAMETROS DE ENVIO DOS PAGAMENTOS DO 43350 DAS    *      */
        /*"      *    INDENIZACOES DE SINISTRO HABIT E PENHOR                     *      */
        /*"      *    NATPERS = > PREENCHER COM X PARA PESSOA F�SICA                     */
        /*"      *    TAXNUM_CPF => PREENCHER COM O N� DO CPF (11 POSI��ES)              */
        /*"      *                                   FORMATO  99999999999.               */
        /*"      *    TITLE_MEDI:                                                        */
        /*"      *    PESSOA F�SICA: Z003 (INDEFINIDO)                                   */
        /*"      *    PESSOA JUR�DICA: 0003 (EMPRESA)                                    */
        /*"      *    BANKN => QUANDO O EVENTO DE PAGTO FOR OP ELETR�NICA(SIVAT)         */
        /*"      *             PREENCHER COM A LETRA -0-.                                */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   HISTORICO DE ALTERACAO                                       *      */
        /*"V.08  * PARA AS OPERACOES DIFERENTE DE SICOV, VAI PEGAR FORNECEDOR            */
        /*"      * 25/01/2011 - NO SISAP02B TB FOI FEITO HOJE                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.09  * 20/01/2011 - ATR_FPAG = 'I' QUANDO SICOV P/ 600128                    */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"V.08  * 19/01/2011 - AJUSTE DO CAMPO ZWELS PARA QDO PAGTO FOR PELO            */
        /*"      *    BANCO DO BRASIL                                                    */
        /*"      *    ORIGEM DA DEMANDA - REUNIAO DE URGENCIA DO SAP COM RODRIGO,        */
        /*"      *    POVOA, BARAN, ELERSON, FERNANDO, SIDNEY, DEARO EM 19/01/2011       */
        /*"      * OBSERVACAO: ESTE PROGRAMA JA ATENDIA A TODAS AS DEFINICOES            */
        /*"      * DOS CAMPOS ATR_FPAG, FPAG, ATTR29 (TIPO DE CONVENIO), BANKK           */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"V.07  * 18/01/2011 - PEGANDO NA CHEQUES APENAS TIPO_PAGTO = '1' - CHQ         */
        /*"V.07  *    TAMBEM INVESTIGAMOS O CASO DO AGRUPADOR QUE ESTAVA COM 30X.        */
        /*"V.07  *    SO ACONTECEU OS 30X PQ ESTAVA PEGANDO TIPO_PAGAMENTO '7' +         */
        /*"V.07  *    O MOVIMENTO SER DO FI0095B que deveria ser siacc                   */
        /*"V.07  *   => neste programa teve alteracao. no sisap01 nao teve               */
        /*"      *                                                                *      */
        /*"V.06  * 07/01/2011 - AGRUPADOR ESTAVA FIXO NO ATR10 E TEM Q SER 10 OU 13      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.05  * 06/01/2011 - AGRUPADOR PARA JUDICIAL E AUTOMOVEL                      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.03  * 05/01/2011 - CORRIGINDO ERRO DOS NOMES DOS FAVORECIDOS                */
        /*"      * LOTERICO - ESTAVA ENVIANDO O NOME DO LOTERICO EM QUANDO O PAGTO       */
        /*"      *            NAO ERA PARA O LOTERICO - CASO COSTA E SILVA               */
        /*"      *            107100023395 AND H.OCORR_HISTORICO = 166                   */
        /*"      * AUTO     - ESTAVA ENVIANDO O NOME DO SEGURADO QUANDO O PAGTO          */
        /*"      *            ERA P/ CAIXA SEGUROS. PAGTOS REFERENTES AS BAIXAS          */
        /*"      *            DE PARCELA. O PROBLEMA EH QUE A ESTRUTURA DO REDUCAO       */
        /*"      *            DE CHEQUE GRAVA A OCORRENCIA DO SEGURADO E DA CXSEGU       */
        /*"      *            ROS COM O MESMO NUMERO DE PESSOA.                          */
        /*"      *            1003100071495 AND H.OCORR_HISTORICO = 17                   */
        /*"      *                                                                *      */
        /*"V.02  * 23/12/2010 - FUNCAO "IND" PARA RAMO 66                                */
        /*"      *                                                                *      */
        /*"      * 22/11/2010 - INCLUSAO DO AGRUPADOR                             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77   HOST-TIMESTAMP            PIC  X(026) VALUE SPACES.*/
        public StringBasis HOST_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
        /*"77   HOST-TIMESTAMP            PIC  X(026) VALUE SPACES.*/
        public StringBasis HOST_TIMESTAMP_0 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
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
        /*"77   HOST-NUM-IMOVEL           PIC S9(005) VALUE +0 COMP.*/
        public IntBasis HOST_NUM_IMOVEL { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
        /*"77   HOST-NUM-CEP              PIC S9(008) VALUE +0 COMP.*/
        public IntBasis HOST_NUM_CEP { get; set; } = new IntBasis(new PIC("S9", "8", "S9(008)"));
        /*"77   HOST-COUNT                PIC S9(009) VALUE +0 COMP.*/
        public IntBasis HOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77   VIND-SEQ-TIPO-OBJ-SEG     PIC S9(004) VALUE +0 COMP.*/
        public IntBasis VIND_SEQ_TIPO_OBJ_SEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
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
        /*"77  FIPADOIM-COD-IMPOSTO-SAP-NN    PIC S9(04) COMP VALUE +0.*/
        public IntBasis FIPADOIM_COD_IMPOSTO_SAP_NN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01           WS-IND-NOME-HIST       PIC X(001) VALUE 'N'.*/
        public StringBasis WS_IND_NOME_HIST { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"01           AREA-DE-WORK.*/
        public SISAP01B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SISAP01B_AREA_DE_WORK();
        public class SISAP01B_AREA_DE_WORK : VarBasis
        {
            /*"  05         WS-SMALLINT       PIC ZZZZ9- OCCURS 5 TIMES.*/
            public ListBasis<IntBasis, Int64> WS_SMALLINT { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "6", "ZZZZ9-"), 5);
            /*"  05         WS-RETURN-CODE    PIC  9(009)    VALUE ZEROS.*/
            public IntBasis WS_RETURN_CODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WSL-SQLCODE       PIC  9(009)    VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WS-ENDERECO.*/
            public SISAP01B_WS_ENDERECO WS_ENDERECO { get; set; } = new SISAP01B_WS_ENDERECO();
            public class SISAP01B_WS_ENDERECO : VarBasis
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
            public SISAP01B_WS_TRATA_TAMANHO WS_TRATA_TAMANHO { get; set; } = new SISAP01B_WS_TRATA_TAMANHO();
            public class SISAP01B_WS_TRATA_TAMANHO : VarBasis
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
            public SISAP01B_WHORA WHORA { get; set; } = new SISAP01B_WHORA();
            public class SISAP01B_WHORA : VarBasis
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
                /*"  05 WCHEQUE-ANTERIOR          PIC  9(010)    VALUE ZEROS.*/
            }
            public IntBasis WCHEQUE_ANTERIOR { get; set; } = new IntBasis(new PIC("9", "10", "9(010)"));
            /*"  05 W-ATTR-DESTINO            PIC X(30) VALUE SPACES.*/
            public StringBasis W_ATTR_DESTINO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 W-AGRUPADOR-1.*/
            public SISAP01B_W_AGRUPADOR_1 W_AGRUPADOR_1 { get; set; } = new SISAP01B_W_AGRUPADOR_1();
            public class SISAP01B_W_AGRUPADOR_1 : VarBasis
            {
                /*"     10 W-AGRUPADOR-LEGENDA           PIC X(11) VALUE ' '.*/
                public StringBasis W_AGRUPADOR_LEGENDA { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @" ");
                /*"     10 W-AGRUPADOR-MINUTO-SSSSSS     PIC X(09) VALUE ' '.*/
                public StringBasis W_AGRUPADOR_MINUTO_SSSSSS { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @" ");
                /*"  05 W-IDLG-SIAS-SINISTRO.*/
            }
            public SISAP01B_W_IDLG_SIAS_SINISTRO W_IDLG_SIAS_SINISTRO { get; set; } = new SISAP01B_W_IDLG_SIAS_SINISTRO();
            public class SISAP01B_W_IDLG_SIAS_SINISTRO : VarBasis
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
                private _REDEF_SISAP01B_W_IDLG_COMPLEMENTO_1 _w_idlg_complemento_1 { get; set; }
                public _REDEF_SISAP01B_W_IDLG_COMPLEMENTO_1 W_IDLG_COMPLEMENTO_1
                {
                    get { _w_idlg_complemento_1 = new _REDEF_SISAP01B_W_IDLG_COMPLEMENTO_1(); _.Move(W_IDLG_COMPLEMENTO, _w_idlg_complemento_1); VarBasis.RedefinePassValue(W_IDLG_COMPLEMENTO, _w_idlg_complemento_1, W_IDLG_COMPLEMENTO); _w_idlg_complemento_1.ValueChanged += () => { _.Move(_w_idlg_complemento_1, W_IDLG_COMPLEMENTO); }; return _w_idlg_complemento_1; }
                    set { VarBasis.RedefinePassValue(value, _w_idlg_complemento_1, W_IDLG_COMPLEMENTO); }
                }  //Redefines
                public class _REDEF_SISAP01B_W_IDLG_COMPLEMENTO_1 : VarBasis
                {
                    /*"       15 W-IDLG-NUM-CHEQUE-INTERNO  PIC 9(10).*/
                    public IntBasis W_IDLG_NUM_CHEQUE_INTERNO { get; set; } = new IntBasis(new PIC("9", "10", "9(10)."));
                    /*"    10 W-IDLG-COMPLEMENTO-2   REDEFINES  W-IDLG-COMPLEMENTO.*/

                    public _REDEF_SISAP01B_W_IDLG_COMPLEMENTO_1()
                    {
                        W_IDLG_NUM_CHEQUE_INTERNO.ValueChanged += OnValueChanged;
                    }

                }
                private _REDEF_SISAP01B_W_IDLG_COMPLEMENTO_2 _w_idlg_complemento_2 { get; set; }
                public _REDEF_SISAP01B_W_IDLG_COMPLEMENTO_2 W_IDLG_COMPLEMENTO_2
                {
                    get { _w_idlg_complemento_2 = new _REDEF_SISAP01B_W_IDLG_COMPLEMENTO_2(); _.Move(W_IDLG_COMPLEMENTO, _w_idlg_complemento_2); VarBasis.RedefinePassValue(W_IDLG_COMPLEMENTO, _w_idlg_complemento_2, W_IDLG_COMPLEMENTO); _w_idlg_complemento_2.ValueChanged += () => { _.Move(_w_idlg_complemento_2, W_IDLG_COMPLEMENTO); }; return _w_idlg_complemento_2; }
                    set { VarBasis.RedefinePassValue(value, _w_idlg_complemento_2, W_IDLG_COMPLEMENTO); }
                }  //Redefines
                public class _REDEF_SISAP01B_W_IDLG_COMPLEMENTO_2 : VarBasis
                {
                    /*"       15 W-IDLG-NSAS                PIC 9(10).*/
                    public IntBasis W_IDLG_NSAS { get; set; } = new IntBasis(new PIC("9", "10", "9(10)."));
                    /*"    10 W-IDLG-COMPLEMENTO-3   REDEFINES  W-IDLG-COMPLEMENTO.*/

                    public _REDEF_SISAP01B_W_IDLG_COMPLEMENTO_2()
                    {
                        W_IDLG_NSAS.ValueChanged += OnValueChanged;
                    }

                }
                private _REDEF_SISAP01B_W_IDLG_COMPLEMENTO_3 _w_idlg_complemento_3 { get; set; }
                public _REDEF_SISAP01B_W_IDLG_COMPLEMENTO_3 W_IDLG_COMPLEMENTO_3
                {
                    get { _w_idlg_complemento_3 = new _REDEF_SISAP01B_W_IDLG_COMPLEMENTO_3(); _.Move(W_IDLG_COMPLEMENTO, _w_idlg_complemento_3); VarBasis.RedefinePassValue(W_IDLG_COMPLEMENTO, _w_idlg_complemento_3, W_IDLG_COMPLEMENTO); _w_idlg_complemento_3.ValueChanged += () => { _.Move(_w_idlg_complemento_3, W_IDLG_COMPLEMENTO); }; return _w_idlg_complemento_3; }
                    set { VarBasis.RedefinePassValue(value, _w_idlg_complemento_3, W_IDLG_COMPLEMENTO); }
                }  //Redefines
                public class _REDEF_SISAP01B_W_IDLG_COMPLEMENTO_3 : VarBasis
                {
                    /*"       15 W-IDLG-NUM-ACORDO          PIC 9(05).*/
                    public IntBasis W_IDLG_NUM_ACORDO { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
                    /*"       15 FILLER                     PIC X(01).*/
                    public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                    /*"       15 W-IDLG-NUM-PARCELA         PIC 9(04).*/
                    public IntBasis W_IDLG_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                    /*"  05 W-LOTE-NUM-SEQUENCIA            PIC 9(09) VALUE 0.*/

                    public _REDEF_SISAP01B_W_IDLG_COMPLEMENTO_3()
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
            public SISAP01B_W_LOTE W_LOTE { get; set; } = new SISAP01B_W_LOTE();
            public class SISAP01B_W_LOTE : VarBasis
            {
                /*"    10 W-LOTE-NOME-PROGRAMA.*/
                public SISAP01B_W_LOTE_NOME_PROGRAMA W_LOTE_NOME_PROGRAMA { get; set; } = new SISAP01B_W_LOTE_NOME_PROGRAMA();
                public class SISAP01B_W_LOTE_NOME_PROGRAMA : VarBasis
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
                /*"  05 W-BANKK.*/
            }
            public SISAP01B_W_BANKK W_BANKK { get; set; } = new SISAP01B_W_BANKK();
            public class SISAP01B_W_BANKK : VarBasis
            {
                /*"       10 W-COD-BANCO             PIC 9(03) VALUE 0.*/
                public IntBasis W_COD_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
                /*"       10 W-DV-BANCO              PIC 9(01) VALUE 0.*/
                public IntBasis W_DV_BANCO { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
                /*"       10 W-COD-AGENCIA           PIC 9(04) VALUE 0.*/
                public IntBasis W_COD_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"  05 WS-LOTE-ANT                PIC S9(09) VALUE ZEROS.*/
            }
            public IntBasis WS_LOTE_ANT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"  05 W-USO-EMPRESA-SIACC.*/
            public SISAP01B_W_USO_EMPRESA_SIACC W_USO_EMPRESA_SIACC { get; set; } = new SISAP01B_W_USO_EMPRESA_SIACC();
            public class SISAP01B_W_USO_EMPRESA_SIACC : VarBasis
            {
                /*"       10 W-ATTR-14               PIC X(30) VALUE SPACES.*/
                public StringBasis W_ATTR_14 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
                /*"       10 W-ATTR-15               PIC X(10) VALUE SPACES.*/
                public StringBasis W_ATTR_15 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"  05 W-CONTA-SAP.*/
            }
            public SISAP01B_W_CONTA_SAP W_CONTA_SAP { get; set; } = new SISAP01B_W_CONTA_SAP();
            public class SISAP01B_W_CONTA_SAP : VarBasis
            {
                /*"       10 W-NUM-CONTA-SAP         PIC 9(12) VALUE 0.*/
                public IntBasis W_NUM_CONTA_SAP { get; set; } = new IntBasis(new PIC("9", "12", "9(12)"));
                /*"       10 FILLER                  PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       10 W-DV-CONTA-SAP          PIC X(01) VALUE ' '.*/
                public StringBasis W_DV_CONTA_SAP { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"  05 W-ATTR17.*/
            }
            public SISAP01B_W_ATTR17 W_ATTR17 { get; set; } = new SISAP01B_W_ATTR17();
            public class SISAP01B_W_ATTR17 : VarBasis
            {
                /*"     10 W-ATTR17-SISTEMA             PIC X(02) VALUE 'SI'.*/
                public StringBasis W_ATTR17_SISTEMA { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"SI");
                /*"     10 W-ATTR17-USUARIO             PIC X(08) VALUE ' '.*/
                public StringBasis W_ATTR17_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @" ");
                /*"  05  W-PRODUTO-SAP.*/
            }
            public SISAP01B_W_PRODUTO_SAP W_PRODUTO_SAP { get; set; } = new SISAP01B_W_PRODUTO_SAP();
            public class SISAP01B_W_PRODUTO_SAP : VarBasis
            {
                /*"     10  W-PRODUTO-SAP-L000       PIC X(04) VALUE SPACES.*/
                public StringBasis W_PRODUTO_SAP_L000 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
                /*"     10  W-PRODUTO-SAP-PRODUTO    PIC 9(04) VALUE 0.*/
                public IntBasis W_PRODUTO_SAP_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"  05  WFIM-LE-MOVDEBCE-1          PIC  X(003)    VALUE SPACES.*/
            }
            public StringBasis WFIM_LE_MOVDEBCE_1 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05  WFIM-IMPOSTOS               PIC  X(003)    VALUE SPACES.*/
            public StringBasis WFIM_IMPOSTOS { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05  W-AC-LIDOS-MOVDEBCE         PIC  9(005)    VALUE ZEROS.*/
            public IntBasis W_AC_LIDOS_MOVDEBCE { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05  WS-USO-EMPRESA-SICOV.*/
            public SISAP01B_WS_USO_EMPRESA_SICOV WS_USO_EMPRESA_SICOV { get; set; } = new SISAP01B_WS_USO_EMPRESA_SICOV();
            public class SISAP01B_WS_USO_EMPRESA_SICOV : VarBasis
            {
                /*"      10 WS-USO-EMPRESA-SICOV-TXT1    PIC  X(40) VALUE SPACES.*/
                public StringBasis WS_USO_EMPRESA_SICOV_TXT1 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"      10 FILLER                       PIC  X(01) VALUE SPACES.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"      10 WS-USO-EMPRESA-SICOV-25      PIC  X(25) VALUE SPACES.*/
                public StringBasis WS_USO_EMPRESA_SICOV_25 { get; set; } = new StringBasis(new PIC("X", "25", "X(25)"), @"");
                /*"      10 FILLER                       PIC  X(01) VALUE SPACES.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"      10 WS-USO-EMPRESA-SICOV-TXT2    PIC  X(40) VALUE SPACES.*/
                public StringBasis WS_USO_EMPRESA_SICOV_TXT2 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"      10 FILLER                       PIC  X(01) VALUE SPACES.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
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
            /*"  05  W-CHAVE-TEM-INSS               PIC X(03) VALUE  'NAO'.*/
            public StringBasis W_CHAVE_TEM_INSS { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
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
            /*"  05  W-PRE                          PIC X(05) VALUE SPACES.*/
            public StringBasis W_PRE { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
            /*"  05  W-LIB                          PIC X(05) VALUE SPACES.*/
            public StringBasis W_LIB { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
            /*"  05 W-DATA-AAAAMMDD.*/
            public SISAP01B_W_DATA_AAAAMMDD W_DATA_AAAAMMDD { get; set; } = new SISAP01B_W_DATA_AAAAMMDD();
            public class SISAP01B_W_DATA_AAAAMMDD : VarBasis
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
            /*"   05 W-CNPJ-AA      PIC 9(14).*/
            public IntBasis W_CNPJ_AA { get; set; } = new IntBasis(new PIC("9", "14", "9(14)."));
            /*"   05 W-CNPJ-BB REDEFINES W-CNPJ-AA PIC X(14).*/
            private _REDEF_StringBasis _w_cnpj_bb { get; set; }
            public _REDEF_StringBasis W_CNPJ_BB
            {
                get { _w_cnpj_bb = new _REDEF_StringBasis(new PIC("X", "14", "X(14).")); ; _.Move(W_CNPJ_AA, _w_cnpj_bb); VarBasis.RedefinePassValue(W_CNPJ_AA, _w_cnpj_bb, W_CNPJ_AA); _w_cnpj_bb.ValueChanged += () => { _.Move(_w_cnpj_bb, W_CNPJ_AA); }; return _w_cnpj_bb; }
                set { VarBasis.RedefinePassValue(value, _w_cnpj_bb, W_CNPJ_AA); }
            }  //Redefines
            /*"   05 W-AC-TOT-INDENIZACOES        PIC 9(15)V99.*/
            public DoubleBasis W_AC_TOT_INDENIZACOES { get; set; } = new DoubleBasis(new PIC("9", "15", "9(15)V99."), 2);
            /*"   05 W-AC-TOT-HONORARIOS          PIC 9(15)V99.*/
            public DoubleBasis W_AC_TOT_HONORARIOS { get; set; } = new DoubleBasis(new PIC("9", "15", "9(15)V99."), 2);
            /*"  05  W-NUM-CPF-NUM                PIC 9(11).*/
        }
        public IntBasis W_NUM_CPF_NUM { get; set; } = new IntBasis(new PIC("9", "11", "9(11)."));
        /*"  05  W-NUM-CPF-ALFA  REDEFINES  W-NUM-CPF-NUM  PIC X(11).*/
        private _REDEF_StringBasis _w_num_cpf_alfa { get; set; }
        public _REDEF_StringBasis W_NUM_CPF_ALFA
        {
            get { _w_num_cpf_alfa = new _REDEF_StringBasis(new PIC("X", "11", "X(11).")); ; _.Move(W_NUM_CPF_NUM, _w_num_cpf_alfa); VarBasis.RedefinePassValue(W_NUM_CPF_NUM, _w_num_cpf_alfa, W_NUM_CPF_NUM); _w_num_cpf_alfa.ValueChanged += () => { _.Move(_w_num_cpf_alfa, W_NUM_CPF_NUM); }; return _w_num_cpf_alfa; }
            set { VarBasis.RedefinePassValue(value, _w_num_cpf_alfa, W_NUM_CPF_NUM); }
        }  //Redefines
        /*"  05  W-NUM-CNPJ-NUM                PIC 9(14).*/
        public IntBasis W_NUM_CNPJ_NUM { get; set; } = new IntBasis(new PIC("9", "14", "9(14)."));
        /*"  05  W-NUM-CNPJ-ALFA  REDEFINES  W-NUM-CNPJ-NUM  PIC X(14).*/
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
        /*"  05 W-TOTAL-TRAILLER                  PIC 9(15)V99 VALUE 0.*/
        public DoubleBasis W_TOTAL_TRAILLER { get; set; } = new DoubleBasis(new PIC("9", "15", "9(15)V99"), 2);
        /*"  05 W-CAMPO-EDITADO.*/
        public SISAP01B_W_CAMPO_EDITADO W_CAMPO_EDITADO { get; set; } = new SISAP01B_W_CAMPO_EDITADO();
        public class SISAP01B_W_CAMPO_EDITADO : VarBasis
        {
            /*"     10 FILLER                       PIC X(05).*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)."), @"");
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
        public SISAP01B_W_VALOR_GERAL_X W_VALOR_GERAL_X { get; set; } = new SISAP01B_W_VALOR_GERAL_X();
        public class SISAP01B_W_VALOR_GERAL_X : VarBasis
        {
            /*"     10 W-VALOR-GERAL-VALOR          PIC ------------9,99.*/
            public DoubleBasis W_VALOR_GERAL_VALOR { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
            /*"  05 W-CEP-NUM                       PIC 9(08) VALUE 0.*/
        }
        public IntBasis W_CEP_NUM { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
        /*"  05 W-CEP-NUMERICO  REDEFINES  W-CEP-NUM.*/
        private _REDEF_SISAP01B_W_CEP_NUMERICO _w_cep_numerico { get; set; }
        public _REDEF_SISAP01B_W_CEP_NUMERICO W_CEP_NUMERICO
        {
            get { _w_cep_numerico = new _REDEF_SISAP01B_W_CEP_NUMERICO(); _.Move(W_CEP_NUM, _w_cep_numerico); VarBasis.RedefinePassValue(W_CEP_NUM, _w_cep_numerico, W_CEP_NUM); _w_cep_numerico.ValueChanged += () => { _.Move(_w_cep_numerico, W_CEP_NUM); }; return _w_cep_numerico; }
            set { VarBasis.RedefinePassValue(value, _w_cep_numerico, W_CEP_NUM); }
        }  //Redefines
        public class _REDEF_SISAP01B_W_CEP_NUMERICO : VarBasis
        {
            /*"     10 W-CEP-NUMERICO-PARTE1        PIC 9(05).*/
            public IntBasis W_CEP_NUMERICO_PARTE1 { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
            /*"     10 W-CEP-NUMERICO-PARTE2        PIC 9(03).*/
            public IntBasis W_CEP_NUMERICO_PARTE2 { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
            /*"  05 W-CEP-ALFA.*/

            public _REDEF_SISAP01B_W_CEP_NUMERICO()
            {
                W_CEP_NUMERICO_PARTE1.ValueChanged += OnValueChanged;
                W_CEP_NUMERICO_PARTE2.ValueChanged += OnValueChanged;
            }

        }
        public SISAP01B_W_CEP_ALFA W_CEP_ALFA { get; set; } = new SISAP01B_W_CEP_ALFA();
        public class SISAP01B_W_CEP_ALFA : VarBasis
        {
            /*"     10 W-CEP-ALFA-PARTE1            PIC 9(05).*/
            public IntBasis W_CEP_ALFA_PARTE1 { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
            /*"     10 FILLER                       PIC X(01)  VALUE '-' .*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
            /*"     10 W-CEP-ALFA-PARTE2            PIC 9(03).*/
            public IntBasis W_CEP_ALFA_PARTE2 { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
            /*"  05 W-CONTA-CORRENTE-DEBITO.*/
        }
        public SISAP01B_W_CONTA_CORRENTE_DEBITO W_CONTA_CORRENTE_DEBITO { get; set; } = new SISAP01B_W_CONTA_CORRENTE_DEBITO();
        public class SISAP01B_W_CONTA_CORRENTE_DEBITO : VarBasis
        {
            /*"     10 W-OPERACAO-CONTA-DEBITO  PIC 9(04) VALUE ZEROS.*/
            public IntBasis W_OPERACAO_CONTA_DEBITO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
            /*"     10 W-CONTA-CONTA-DEBITO     PIC 9(12) VALUE ZEROS.*/
            public IntBasis W_CONTA_CONTA_DEBITO { get; set; } = new IntBasis(new PIC("9", "12", "9(12)"));
            /*"  05 W-DV-CORRENTE-DEBITO-NUM    PIC 9(05).*/
        }
        public IntBasis W_DV_CORRENTE_DEBITO_NUM { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
        /*"  05 W-DV-CORRENTE-DEBITO-ALFA                         REDEFINES  W-DV-CORRENTE-DEBITO-NUM.*/
        private _REDEF_SISAP01B_W_DV_CORRENTE_DEBITO_ALFA _w_dv_corrente_debito_alfa { get; set; }
        public _REDEF_SISAP01B_W_DV_CORRENTE_DEBITO_ALFA W_DV_CORRENTE_DEBITO_ALFA
        {
            get { _w_dv_corrente_debito_alfa = new _REDEF_SISAP01B_W_DV_CORRENTE_DEBITO_ALFA(); _.Move(W_DV_CORRENTE_DEBITO_NUM, _w_dv_corrente_debito_alfa); VarBasis.RedefinePassValue(W_DV_CORRENTE_DEBITO_NUM, _w_dv_corrente_debito_alfa, W_DV_CORRENTE_DEBITO_NUM); _w_dv_corrente_debito_alfa.ValueChanged += () => { _.Move(_w_dv_corrente_debito_alfa, W_DV_CORRENTE_DEBITO_NUM); }; return _w_dv_corrente_debito_alfa; }
            set { VarBasis.RedefinePassValue(value, _w_dv_corrente_debito_alfa, W_DV_CORRENTE_DEBITO_NUM); }
        }  //Redefines
        public class _REDEF_SISAP01B_W_DV_CORRENTE_DEBITO_ALFA : VarBasis
        {
            /*"     10 FILLER                   PIC X(04).*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)."), @"");
            /*"     10 W-DV-CONTA-CONTA-DEBITO  PIC X(01).*/
            public StringBasis W_DV_CONTA_CONTA_DEBITO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"  05 WS-COD-EVENTO               PIC  X(10).*/

            public _REDEF_SISAP01B_W_DV_CORRENTE_DEBITO_ALFA()
            {
                FILLER_17.ValueChanged += OnValueChanged;
                W_DV_CONTA_CONTA_DEBITO.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_COD_EVENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"  05  FILLER REDEFINES    WS-COD-EVENTO.*/
        private _REDEF_SISAP01B_FILLER_18 _filler_18 { get; set; }
        public _REDEF_SISAP01B_FILLER_18 FILLER_18
        {
            get { _filler_18 = new _REDEF_SISAP01B_FILLER_18(); _.Move(WS_COD_EVENTO, _filler_18); VarBasis.RedefinePassValue(WS_COD_EVENTO, _filler_18, WS_COD_EVENTO); _filler_18.ValueChanged += () => { _.Move(_filler_18, WS_COD_EVENTO); }; return _filler_18; }
            set { VarBasis.RedefinePassValue(value, _filler_18, WS_COD_EVENTO); }
        }  //Redefines
        public class _REDEF_SISAP01B_FILLER_18 : VarBasis
        {
            /*"     10 WS-COD-EVENTO-ALFA       PIC  X(05).*/
            public StringBasis WS_COD_EVENTO_ALFA { get; set; } = new StringBasis(new PIC("X", "5", "X(05)."), @"");
            /*"     10 WS-COD-EVENTO-NUM        PIC  X(05).*/
            public StringBasis WS_COD_EVENTO_NUM { get; set; } = new StringBasis(new PIC("X", "5", "X(05)."), @"");
            /*"  05         WHORA-CURR.*/

            public _REDEF_SISAP01B_FILLER_18()
            {
                WS_COD_EVENTO_ALFA.ValueChanged += OnValueChanged;
                WS_COD_EVENTO_NUM.ValueChanged += OnValueChanged;
            }

        }
        public SISAP01B_WHORA_CURR WHORA_CURR { get; set; } = new SISAP01B_WHORA_CURR();
        public class SISAP01B_WHORA_CURR : VarBasis
        {
            /*"    10       WHORA-HH-CURR     PIC  9(002)    VALUE ZEROS.*/
            public IntBasis WHORA_HH_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"    10       WHORA-MM-CURR     PIC  9(002)    VALUE ZEROS.*/
            public IntBasis WHORA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"    10       WHORA-SS-CURR     PIC  9(002)    VALUE ZEROS.*/
            public IntBasis WHORA_SS_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05         WHORAS.*/
        }
        public SISAP01B_WHORAS WHORAS { get; set; } = new SISAP01B_WHORAS();
        public class SISAP01B_WHORAS : VarBasis
        {
            /*"    10       WHORAS-HH         PIC  9(002)    VALUE ZEROS.*/
            public IntBasis WHORAS_HH { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"    10       WHORAS-MM         PIC  9(002)    VALUE ZEROS.*/
            public IntBasis WHORAS_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"    10       WHORAS-SS         PIC  9(002)    VALUE ZEROS.*/
            public IntBasis WHORAS_SS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"    10       WHORAS-CC         PIC  9(002)    VALUE ZEROS.*/
            public IntBasis WHORAS_CC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05         WMONTA-DATA       PIC  X(008)    VALUE SPACES.*/
        }
        public StringBasis WMONTA_DATA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"  05         FILLER            REDEFINES      WMONTA-DATA.*/
        private _REDEF_SISAP01B_FILLER_19 _filler_19 { get; set; }
        public _REDEF_SISAP01B_FILLER_19 FILLER_19
        {
            get { _filler_19 = new _REDEF_SISAP01B_FILLER_19(); _.Move(WMONTA_DATA, _filler_19); VarBasis.RedefinePassValue(WMONTA_DATA, _filler_19, WMONTA_DATA); _filler_19.ValueChanged += () => { _.Move(_filler_19, WMONTA_DATA); }; return _filler_19; }
            set { VarBasis.RedefinePassValue(value, _filler_19, WMONTA_DATA); }
        }  //Redefines
        public class _REDEF_SISAP01B_FILLER_19 : VarBasis
        {
            /*"    10       WDATA-DIA         PIC  9(002).*/
            public IntBasis WDATA_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    10       WDATA-MES         PIC  9(002).*/
            public IntBasis WDATA_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    10       WDATA-ANO         PIC  9(004).*/
            public IntBasis WDATA_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05  W-EDICAO-QTD             PIC Z.ZZZ.ZZ9.*/

            public _REDEF_SISAP01B_FILLER_19()
            {
                WDATA_DIA.ValueChanged += OnValueChanged;
                WDATA_MES.ValueChanged += OnValueChanged;
                WDATA_ANO.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis W_EDICAO_QTD { get; set; } = new IntBasis(new PIC("9", "7", "Z.ZZZ.ZZ9."));
        /*"  05  W-EDICAO-VALOR-1         PIC Z.ZZZ.ZZ9,99-.*/
        public DoubleBasis W_EDICAO_VALOR_1 { get; set; } = new DoubleBasis(new PIC("9", "7", "Z.ZZZ.ZZ9V99-."), 3);
        /*"  05         WCGCCPF           PIC S9(015) VALUE ZEROS.*/
        public IntBasis WCGCCPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"  05         WCGC              REDEFINES   WCGCCPF.*/
        private _REDEF_SISAP01B_WCGC _wcgc { get; set; }
        public _REDEF_SISAP01B_WCGC WCGC
        {
            get { _wcgc = new _REDEF_SISAP01B_WCGC(); _.Move(WCGCCPF, _wcgc); VarBasis.RedefinePassValue(WCGCCPF, _wcgc, WCGCCPF); _wcgc.ValueChanged += () => { _.Move(_wcgc, WCGCCPF); }; return _wcgc; }
            set { VarBasis.RedefinePassValue(value, _wcgc, WCGCCPF); }
        }  //Redefines
        public class _REDEF_SISAP01B_WCGC : VarBasis
        {
            /*"    10       WCGC-RES          PIC  9(001).*/
            public IntBasis WCGC_RES { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    10       WCGC-NUM          PIC  9(008).*/
            public IntBasis WCGC_NUM { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    10       WCGC-FIL          PIC  9(004).*/
            public IntBasis WCGC_FIL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    10       WCGC-DIG          PIC  9(002).*/
            public IntBasis WCGC_DIG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"01 W-TRAILLER-SIAS-GERAL.*/

            public _REDEF_SISAP01B_WCGC()
            {
                WCGC_RES.ValueChanged += OnValueChanged;
                WCGC_NUM.ValueChanged += OnValueChanged;
                WCGC_FIL.ValueChanged += OnValueChanged;
                WCGC_DIG.ValueChanged += OnValueChanged;
            }

        }
        public SISAP01B_W_TRAILLER_SIAS_GERAL W_TRAILLER_SIAS_GERAL { get; set; } = new SISAP01B_W_TRAILLER_SIAS_GERAL();
        public class SISAP01B_W_TRAILLER_SIAS_GERAL : VarBasis
        {
            /*"  05 TIPOREG-TRAILLER                 PIC 9(02) VALUE 00.*/
            public IntBasis TIPOREG_TRAILLER { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"), 00);
            /*"  05 QTDEREG-TRAILLER                 PIC 9(11) VALUE 0.*/
            public IntBasis QTDEREG_TRAILLER { get; set; } = new IntBasis(new PIC("9", "11", "9(11)"));
            /*"  05 FILLER                           PIC X(11) VALUE ' '.*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @" ");
            /*"  05 FILLER                           PIC X(05) VALUE ' '.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @" ");
            /*"  05 AMNTT-TRAILLER                   PIC ---------------,--.*/
            public StringBasis AMNTT_TRAILLER { get; set; } = new StringBasis(new PIC("X", "0", "---------------V--."), @"");
            /*"  05 FILLER                           PIC X(23) VALUE ' '.*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @" ");
            /*"  05 ORIG-TRAILLER                    PIC X(04) VALUE ' '                                        JUST RIGHT.*/
            public StringBasis ORIG_TRAILLER { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @" ");
            /*"  05 LOTE-TRAILLER                    PIC X(24) VALUE ' '                                        JUST RIGHT.*/
            public StringBasis LOTE_TRAILLER { get; set; } = new StringBasis(new PIC("X", "24", "X(24)"), @" ");
            /*"  05 FILLER                           PIC X(3406) VALUE ' '.*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "3406", "X(3406)"), @" ");
            /*"01 W-REGISTRO-SIAS-GERAL.*/
        }
        public SISAP01B_W_REGISTRO_SIAS_GERAL W_REGISTRO_SIAS_GERAL { get; set; } = new SISAP01B_W_REGISTRO_SIAS_GERAL();
        public class SISAP01B_W_REGISTRO_SIAS_GERAL : VarBasis
        {
            /*"  05 TIPOREG-GERAL                    PIC 9(02) VALUE 01.*/
            public IntBasis TIPOREG_GERAL { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"), 01);
            /*"  05 FILLER                           PIC X(68) VALUE SPACES.*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "68", "X(68)"), @"");
            /*"  05 ORIG-GERAL                       PIC X(04) VALUE SPACES.*/
            public StringBasis ORIG_GERAL { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
            /*"  05 LOTE-GERAL                       PIC X(24) VALUE SPACES.*/
            public StringBasis LOTE_GERAL { get; set; } = new StringBasis(new PIC("X", "24", "X(24)"), @"");
            /*"  05 LOTEIT-GERAL                     PIC 9(09) VALUE ZEROS.*/
            public IntBasis LOTEIT_GERAL { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"  05 IDLG-GERAL                       PIC X(40) VALUE SPACES.*/
            public StringBasis IDLG_GERAL { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
            /*"  05 JANELA-GERAL                     PIC X(02) VALUE SPACES.*/
            public StringBasis JANELA_GERAL { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
            /*"  05 ANPRO-GERAL                      PIC 9(04) VALUE ZEROS.*/
            public IntBasis ANPRO_GERAL { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
            /*"  05 CODOPE-GERAL                     PIC X(10) VALUE SPACES.*/
            public StringBasis CODOPE_GERAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"  05 PAGBLK-GERAL                     PIC X(01) VALUE SPACES.*/
            public StringBasis PAGBLK_GERAL { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"  05 CODSOC-GERAL                     PIC X(04) VALUE SPACES.*/
            public StringBasis CODSOC_GERAL { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
            /*"  05 MOEDA-GERAL                      PIC X(05) VALUE SPACES.*/
            public StringBasis MOEDA_GERAL { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
            /*"  05 DTDOC-GERAL                      PIC X(08) VALUE SPACES.*/
            public StringBasis DTDOC_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 DTLAN-GERAL                      PIC X(08) VALUE SPACES.*/
            public StringBasis DTLAN_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTR01-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR01_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL01-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL01_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR02-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR02_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL02-GERAL                  PIC X(30) VALUE  SPACES.*/
            public StringBasis ATTRVAL02_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR03-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR03_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL03-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL03_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR04-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR04_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL04-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL04_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR05-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR05_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL05-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL05_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR06-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR06_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL06-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL06_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR07-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR07_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL07-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL07_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR08-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR08_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL08-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL08_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR09-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR09_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL09-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL09_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR10-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR10_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL10-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL10_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR11-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR11_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL11-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL11_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR12-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR12_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL12-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL12_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR13-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR13_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL13-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL13_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR14-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR14_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL14-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL14_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR15-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR15_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL15-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL15_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR16-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR16_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL16-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL16_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR17-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR17_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL17-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL17_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR18-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR18_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL18-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL18_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR19-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR19_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL19-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL19_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR20-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR20_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL20-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL20_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR21-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR21_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL21-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL21_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR22-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR22_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL22-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL22_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR23-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR23_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL23-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL23_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR24-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR24_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL24-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL24_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR25-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR25_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL25-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL25_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR26-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR26_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL26-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL26_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR27-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR27_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL27-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL27_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR28-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR28_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL28-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL28_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR29-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR29_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL29-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL29_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR30-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR30_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL30-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL30_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR31-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR31_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL31-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL31_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR32-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR32_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL32-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL32_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR33-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR33_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL33-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL33_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR34-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR34_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL34-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL34_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR35-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR35_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL35-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL35_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR36-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR36_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL36-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL36_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR37-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR37_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL37-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL37_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR38-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR38_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL38-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL38_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR39-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR39_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL39-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL39_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR40-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR40_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL40-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL40_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR41-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR41_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL41-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL41_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR42-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR42_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL42-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL42_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR43-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR43_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL43-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL43_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR44-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR44_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL44-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL44_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR45-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR45_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL45-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL45_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR46-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR46_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL46-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL46_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR47-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR47_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL47-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL47_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR48-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR48_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL48-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL48_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR49-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR49_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL49-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL49_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR50-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR50_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL50-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL50_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR51-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR51_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL51-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL51_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR52-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR52_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL52-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL52_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR53-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR53_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL53-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL53_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR54-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR54_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL54-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL54_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR55-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR55_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL55-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL55_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR56-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR56_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL56-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL56_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR57-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR57_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL57-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL57_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR58-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR58_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL58-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL58_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR59-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR59_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL59-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL59_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR60-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR60_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL60-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL60_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR61-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR61_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL61-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL61_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR62-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR62_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL62-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL62_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR63-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR63_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL63-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL63_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR64-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR64_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL64-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL64_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR65-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR65_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL65-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL65_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR66-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR66_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL66-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL66_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR67-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR67_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL67-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL67_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR68-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR68_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL68-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL68_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR69-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR69_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL69-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL69_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 ATTR70-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR70_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 ATTRVAL70-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL70_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 COD01-GERAL                      PIC X(08) VALUE SPACES.*/
            public StringBasis COD01_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 VALO01-GERAL                     PIC X(23) VALUE SPACES                       JUST RIGHT.*/
            public StringBasis VALO01_GERAL { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
            /*"  05 COD02-GERAL                      PIC X(08) VALUE SPACES.*/
            public StringBasis COD02_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 VALO02-GERAL                     PIC X(23) VALUE SPACES                       JUST RIGHT.*/
            public StringBasis VALO02_GERAL { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
            /*"  05 COD03-GERAL                      PIC X(08) VALUE SPACES.*/
            public StringBasis COD03_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 VALO03-GERAL                     PIC X(23) VALUE SPACES                       JUST RIGHT.*/
            public StringBasis VALO03_GERAL { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
            /*"  05 COD04-GERAL                      PIC X(08) VALUE SPACES.*/
            public StringBasis COD04_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 VALO04-GERAL                     PIC X(23) VALUE SPACES                       JUST RIGHT.*/
            public StringBasis VALO04_GERAL { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
            /*"  05 COD05-GERAL                      PIC X(08) VALUE SPACES.*/
            public StringBasis COD05_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 VALO05-GERAL                     PIC X(23) VALUE SPACES                       JUST RIGHT.*/
            public StringBasis VALO05_GERAL { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
            /*"  05 COD06-GERAL                      PIC X(08) VALUE SPACES.*/
            public StringBasis COD06_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 VALO06-GERAL                     PIC X(23) VALUE SPACES                       JUST RIGHT.*/
            public StringBasis VALO06_GERAL { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
            /*"  05 COD07-GERAL                      PIC X(08) VALUE SPACES.*/
            public StringBasis COD07_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 VALO07-GERAL                     PIC X(23) VALUE SPACES                       JUST RIGHT.*/
            public StringBasis VALO07_GERAL { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
            /*"  05 COD08-GERAL                      PIC X(08) VALUE SPACES.*/
            public StringBasis COD08_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 VALO08-GERAL                     PIC X(23) VALUE SPACES                       JUST RIGHT.*/
            public StringBasis VALO08_GERAL { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
            /*"  05 COD09-GERAL                      PIC X(08) VALUE SPACES.*/
            public StringBasis COD09_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 VALO09-GERAL                     PIC X(23) VALUE SPACES                       JUST RIGHT.*/
            public StringBasis VALO09_GERAL { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
            /*"  05 COD010-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis COD010_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 VALO010-GERAL                    PIC X(23) VALUE SPACES                       JUST RIGHT.*/
            public StringBasis VALO010_GERAL { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
            /*"  05 COD011-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis COD011_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 VALO011-GERAL                    PIC X(23) VALUE SPACES                       JUST RIGHT.*/
            public StringBasis VALO011_GERAL { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
            /*"  05 COD012-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis COD012_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 VALO012-GERAL                    PIC X(23) VALUE SPACES                       JUST RIGHT.*/
            public StringBasis VALO012_GERAL { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
            /*"  05 COD013-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis COD013_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 VALO013-GERAL                    PIC X(23) VALUE SPACES                       JUST RIGHT.*/
            public StringBasis VALO013_GERAL { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
            /*"  05 COD014-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis COD014_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 VALO014-GERAL                    PIC X(23) VALUE SPACES                       JUST RIGHT.*/
            public StringBasis VALO014_GERAL { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
            /*"  05 COD015-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis COD015_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 VALO015-GERAL                    PIC X(23) VALUE SPACES                       JUST RIGHT.*/
            public StringBasis VALO015_GERAL { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
            /*"  05 COD016-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis COD016_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 VALO016-GERAL                    PIC X(23) VALUE SPACES                       JUST RIGHT.*/
            public StringBasis VALO016_GERAL { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
            /*"  05 COD017-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis COD017_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 VALO017-GERAL                    PIC X(23) VALUE SPACES                       JUST RIGHT.*/
            public StringBasis VALO017_GERAL { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
            /*"  05 COD018-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis COD018_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 VALO018-GERAL                    PIC X(23) VALUE SPACES                       JUST RIGHT.*/
            public StringBasis VALO018_GERAL { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
            /*"  05 COD019-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis COD019_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 VALO019-GERAL                    PIC X(23) VALUE SPACES                       JUST RIGHT.*/
            public StringBasis VALO019_GERAL { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
            /*"  05 COD020-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis COD020_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 VALO020-GERAL                    PIC X(23) VALUE SPACES                       JUST RIGHT.*/
            public StringBasis VALO020_GERAL { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
            /*"  05 COD021-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis COD021_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 VALO021-GERAL                    PIC X(23) VALUE SPACES                       JUST RIGHT.*/
            public StringBasis VALO021_GERAL { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
            /*"  05 COD022-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis COD022_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 VALO022-GERAL                    PIC X(23) VALUE SPACES                       JUST RIGHT.*/
            public StringBasis VALO022_GERAL { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
            /*"  05 COD023-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis COD023_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 VALO023-GERAL                    PIC X(23) VALUE SPACES                       JUST RIGHT.*/
            public StringBasis VALO023_GERAL { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
            /*"  05 COD024-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis COD024_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 VALO024-GERAL                    PIC X(23) VALUE SPACES                       JUST RIGHT.*/
            public StringBasis VALO024_GERAL { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
            /*"  05 COD025-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis COD025_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"  05 VALO025-GERAL                    PIC X(23) VALUE SPACES                       JUST RIGHT.*/
            public StringBasis VALO025_GERAL { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
            /*"  05 CODEMP-GERAL                     PIC X(04) VALUE SPACES.*/
            public StringBasis CODEMP_GERAL { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
            /*"  05 MOEDABP-GERAL                    PIC X(05) VALUE SPACES.*/
            public StringBasis MOEDABP_GERAL { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
            /*"  05 NATPERS-GERAL                    PIC X(01) VALUE SPACES.*/
            public StringBasis NATPERS_GERAL { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"  05 TITLE-MEDI-GERAL                 PIC X(30) VALUE SPACES.*/
            public StringBasis TITLE_MEDI_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 NAME-ORG1-GERAL                  PIC X(40) VALUE SPACES.*/
            public StringBasis NAME_ORG1_GERAL { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
            /*"  05 NAME-FIRST-GERAL                 PIC X(40) VALUE SPACES.*/
            public StringBasis NAME_FIRST_GERAL { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
            /*"  05 NAME-LAST-GERAL                  PIC X(40) VALUE SPACES.*/
            public StringBasis NAME_LAST_GERAL { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
            /*"  05 TAXTYPE-CPF-GERAL                PIC X(04) VALUE SPACES.*/
            public StringBasis TAXTYPE_CPF_GERAL { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
            /*"  05 TAXNUM-CPF-GERAL                 PIC X(20) VALUE SPACES.*/
            public StringBasis TAXNUM_CPF_GERAL { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"");
            /*"  05 TAXTYPE-CNPJ-GERAL               PIC X(04) VALUE SPACES.*/
            public StringBasis TAXTYPE_CNPJ_GERAL { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
            /*"  05 TAXNUM-CNPJ-GERAL                PIC X(20) VALUE SPACES.*/
            public StringBasis TAXNUM_CNPJ_GERAL { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"");
            /*"  05 TAXTYPE-INSCRM-GERAL             PIC X(04) VALUE SPACES.*/
            public StringBasis TAXTYPE_INSCRM_GERAL { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
            /*"  05 TAXNUM-INSCRM-GERAL              PIC X(20) VALUE SPACES.*/
            public StringBasis TAXNUM_INSCRM_GERAL { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"");
            /*"  05 TAXTYPE-INSCRE-GERAL             PIC X(04) VALUE SPACES.*/
            public StringBasis TAXTYPE_INSCRE_GERAL { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
            /*"  05 TAXNUM-INSCRE-GERAL              PIC X(20) VALUE SPACES.*/
            public StringBasis TAXNUM_INSCRE_GERAL { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"");
            /*"  05 STREET-FSCL-GERAL                PIC X(60) VALUE SPACES.*/
            public StringBasis STREET_FSCL_GERAL { get; set; } = new StringBasis(new PIC("X", "60", "X(60)"), @"");
            /*"  05 HOUSE-NUM1-FSCL-GERAL            PIC X(10) VALUE SPACES.*/
            public StringBasis HOUSE_NUM1_FSCL_GERAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"  05 HOUSE-NUM2-FSCL-GERAL            PIC X(10) VALUE SPACES.*/
            public StringBasis HOUSE_NUM2_FSCL_GERAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"  05 POST-CODE1-FSCL-GERAL            PIC X(10) VALUE SPACES.*/
            public StringBasis POST_CODE1_FSCL_GERAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"  05 REGION-FSCL-GERAL                PIC X(03) VALUE SPACES.*/
            public StringBasis REGION_FSCL_GERAL { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
            /*"  05 CITY1-FSCL-GERAL                 PIC X(40) VALUE SPACES.*/
            public StringBasis CITY1_FSCL_GERAL { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
            /*"  05 CITY2-FSCL-GERAL                 PIC X(40) VALUE SPACES.*/
            public StringBasis CITY2_FSCL_GERAL { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
            /*"  05 COUNTRY-FSCL-GERAL               PIC X(03) VALUE SPACES.*/
            public StringBasis COUNTRY_FSCL_GERAL { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
            /*"  05 STREET-COR-GERAL                 PIC X(60) VALUE SPACES.*/
            public StringBasis STREET_COR_GERAL { get; set; } = new StringBasis(new PIC("X", "60", "X(60)"), @"");
            /*"  05 HOUSE-NUM1-COR-GERAL             PIC X(10) VALUE SPACES.*/
            public StringBasis HOUSE_NUM1_COR_GERAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"  05 HOUSE-NUM2-COR-GERAL             PIC X(10) VALUE SPACES.*/
            public StringBasis HOUSE_NUM2_COR_GERAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"  05 POST-CODE1-COR-GERAL             PIC X(10) VALUE SPACES.*/
            public StringBasis POST_CODE1_COR_GERAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"  05 REGION-COR-GERAL                 PIC X(03) VALUE SPACES.*/
            public StringBasis REGION_COR_GERAL { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
            /*"  05 CITY1-COR-GERAL                  PIC X(40) VALUE SPACES.*/
            public StringBasis CITY1_COR_GERAL { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
            /*"  05 CITY2-COR-GERAL                  PIC X(40) VALUE SPACES.*/
            public StringBasis CITY2_COR_GERAL { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
            /*"  05 COUNTRY-COR-GERAL                PIC X(03) VALUE SPACES.*/
            public StringBasis COUNTRY_COR_GERAL { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
            /*"  05 LANGUCORR-GERAL                  PIC X(02) VALUE SPACES.*/
            public StringBasis LANGUCORR_GERAL { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
            /*"  05 LANGU-GERAL                      PIC X(01) VALUE SPACES.*/
            public StringBasis LANGU_GERAL { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"  05 SMTP-ADDR-GERAL                  PIC X(241) VALUE SPACES.*/
            public StringBasis SMTP_ADDR_GERAL { get; set; } = new StringBasis(new PIC("X", "241", "X(241)"), @"");
            /*"  05 TEL-NUMBER-GERAL                 PIC X(30) VALUE SPACES.*/
            public StringBasis TEL_NUMBER_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 FAX-NUMBER-GERAL                 PIC X(30) VALUE SPACES.*/
            public StringBasis FAX_NUMBER_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"  05 BANKS-GERAL                      PIC X(03) VALUE SPACES.*/
            public StringBasis BANKS_GERAL { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
            /*"  05 BANKK-GERAL                      PIC X(15) VALUE SPACES.*/
            public StringBasis BANKK_GERAL { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"");
            /*"  05 BKONT-GERAL                      PIC X(02) VALUE '00'.*/
            public StringBasis BKONT_GERAL { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"00");
            /*"  05 BANKN-GERAL                      PIC X(18) VALUE SPACES.*/
            public StringBasis BANKN_GERAL { get; set; } = new StringBasis(new PIC("X", "18", "X(18)"), @"");
            /*"  05 BKREF-GERAL                      PIC X(20) VALUE SPACES.*/
            public StringBasis BKREF_GERAL { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"");
            /*"  05 KOINH-GERAL                      PIC X(60) VALUE SPACES.*/
            public StringBasis KOINH_GERAL { get; set; } = new StringBasis(new PIC("X", "60", "X(60)"), @"");
            /*"  05 XEZER-GERAL                      PIC X(01) VALUE SPACES.*/
            public StringBasis XEZER_GERAL { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"  05 CCINS-GERAL                      PIC X(04) VALUE SPACES.*/
            public StringBasis CCINS_GERAL { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
            /*"  05 CCNUM-GERAL                      PIC X(25) VALUE SPACES.*/
            public StringBasis CCNUM_GERAL { get; set; } = new StringBasis(new PIC("X", "25", "X(25)"), @"");
            /*"  05 CCDEF-GERAL                      PIC X(01) VALUE SPACES.*/
            public StringBasis CCDEF_GERAL { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"  05 ZWELS-GERAL                      PIC X(10) VALUE SPACES.*/
            public StringBasis ZWELS_GERAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"  05 FPAG-GERAL                       PIC X(01) VALUE SPACES.*/
            public StringBasis FPAG_GERAL { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"  05 FREC-GERAL                       PIC X(01) VALUE SPACES.*/
            public StringBasis FREC_GERAL { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"  05 ZNIT-TYPE-GERAL                  PIC X(06) VALUE SPACES.*/
            public StringBasis ZNIT_TYPE_GERAL { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"");
            /*"  05 ZNIT-GERAL                       PIC X(60) VALUE SPACES.*/
            public StringBasis ZNIT_GERAL { get; set; } = new StringBasis(new PIC("X", "60", "X(60)"), @"");
            /*"  05 ZCBO-TYPE-GERAL                  PIC X(06) VALUE SPACES.*/
            public StringBasis ZCBO_TYPE_GERAL { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"");
            /*"  05 ZCBO-GERAL                       PIC X(60) VALUE SPACES.*/
            public StringBasis ZCBO_GERAL { get; set; } = new StringBasis(new PIC("X", "60", "X(60)"), @"");
            /*"  05 OP-SIMPL-FED-GERAL               PIC X(05) VALUE SPACES.*/
            public StringBasis OP_SIMPL_FED_GERAL { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
            /*"01          WABEND.*/
        }
        public SISAP01B_WABEND WABEND { get; set; } = new SISAP01B_WABEND();
        public class SISAP01B_WABEND : VarBasis
        {
            /*"  05        FILLER              PIC  X(010)     VALUE           ' SISAP01B'.*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SISAP01B");
            /*"  05        FILLER              PIC  X(026)     VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"  05        WNR-EXEC-SQL        PIC  X(004)     VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"  05        FILLER              PIC  X(013)     VALUE           ' *** SQLCODE '.*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"  05        WSQLCODE            PIC  ZZZZZ999-  VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            /*"01  REG-LK-BANCOS.*/
        }
        public SISAP01B_REG_LK_BANCOS REG_LK_BANCOS { get; set; } = new SISAP01B_REG_LK_BANCOS();
        public class SISAP01B_REG_LK_BANCOS : VarBasis
        {
            /*"  05 LK-BANCO-COD-BANCO            PIC  9(03).*/
            public IntBasis LK_BANCO_COD_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
            /*"  05 LK-BANCO-DV-BANCO             PIC  X(01).*/
            public StringBasis LK_BANCO_DV_BANCO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"  05 LK-BANCO-NOME                 PIC  X(60).*/
            public StringBasis LK_BANCO_NOME { get; set; } = new StringBasis(new PIC("X", "60", "X(60)."), @"");
            /*"  05 LK-BANCO-COD-RETORNO          PIC  X(01).*/
            public StringBasis LK_BANCO_COD_RETORNO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"  05 LK-BANCO-MENSAGEM-RETORNO     PIC  X(80).*/
            public StringBasis LK_BANCO_MENSAGEM_RETORNO { get; set; } = new StringBasis(new PIC("X", "80", "X(80)."), @"");
            /*"   05        CT0007SW099.*/
            public SISAP01B_CT0007SW099 CT0007SW099 { get; set; } = new SISAP01B_CT0007SW099();
            public class SISAP01B_CT0007SW099 : VarBasis
            {
                /*"     10      CT0007S-NOME       PIC  X(100).*/
                public StringBasis CT0007S_NOME { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
                /*"     10      CT0007S-SOBRENOME  PIC  X(040).*/
                public StringBasis CT0007S_SOBRENOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"     10      CT0007S-NOME1      PIC  X(040).*/
                public StringBasis CT0007S_NOME1 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"01          PARAMETROS-GE.*/
            }
        }
        public SISAP01B_PARAMETROS_GE PARAMETROS_GE { get; set; } = new SISAP01B_PARAMETROS_GE();
        public class SISAP01B_PARAMETROS_GE : VarBasis
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
            /*"01  REGISTRO-LINKAGE-GE0306B.*/
        }
        public SISAP01B_REGISTRO_LINKAGE_GE0306B REGISTRO_LINKAGE_GE0306B { get; set; } = new SISAP01B_REGISTRO_LINKAGE_GE0306B();
        public class SISAP01B_REGISTRO_LINKAGE_GE0306B : VarBasis
        {
            /*"  05 LK-GE0306B-FUNCAO                  PIC  9(02).*/
            public IntBasis LK_GE0306B_FUNCAO { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"  05 LK-GE0306B-IDLG                    PIC  X(40).*/
            public StringBasis LK_GE0306B_IDLG { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"  05 LK-GE0306B-DATA-MOV-ABERTO         PIC  X(10).*/
            public StringBasis LK_GE0306B_DATA_MOV_ABERTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"  05 LK-GE0306B-IDE-SISTEMA             PIC  X(02).*/
            public StringBasis LK_GE0306B_IDE_SISTEMA { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
            /*"  05 LK-GE0306B-NUM-ESTRUTURA           PIC S9(04) COMP.*/
            public IntBasis LK_GE0306B_NUM_ESTRUTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05 LK-GE0306B-NUM-APOLICE             piC S9(13) COMP-3.*/
            public IntBasis LK_GE0306B_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "0", "05"));
            /*"  05 LK-GE0306B-NUM-ENDOSSO             PIC S9(09) COMP.*/
            public IntBasis LK_GE0306B_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"  05 LK-GE0306B-NUM-PARCELA             PIC S9(04) COMP.*/
            public IntBasis LK_GE0306B_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05 LK-GE0306B-NUM-NOSSO-TITULO        PIC S9(16) COMP-3.*/
            public IntBasis LK_GE0306B_NUM_NOSSO_TITULO { get; set; } = new IntBasis(new PIC("S9", "16", "S9(16)"));
            /*"  05 LK-GE0306B-NUM-OCORR-HISTORICO     PIC S9(04) COMP.*/
            public IntBasis LK_GE0306B_NUM_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05 LK-GE0306B-NUM-APOL-SINISTRO       PIC S9(13) COMP-3.*/
            public IntBasis LK_GE0306B_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
            /*"  05 LK-GE0306B-COD-OPERACAO            PIC S9(04) COMP.*/
            public IntBasis LK_GE0306B_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05 LK-GE0306B-NUM-RESSARC             PIC S9(09) COMP.*/
            public IntBasis LK_GE0306B_NUM_RESSARC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"  05 LK-GE0306B-SEQ-RESSARC             PIC S9(04) COMP.*/
            public IntBasis LK_GE0306B_SEQ_RESSARC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05 LK-GE0306B-NSAS                    PIC S9(04) COMP.*/
            public IntBasis LK_GE0306B_NSAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05 LK-GE0306B-NUM-CHEQUE-INTERNO      PIC S9(09) COMP.*/
            public IntBasis LK_GE0306B_NUM_CHEQUE_INTERNO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"  05 LK-GE0306B-COD-CONVENIO            PIC S9(09) COMP.*/
            public IntBasis LK_GE0306B_COD_CONVENIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"  05 LK-GE0306B-NUM-CERTIFICADO         PIC S9(15) COMP-3.*/
            public IntBasis LK_GE0306B_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
            /*"  05 LK-GE0306B-CHR-USO-EMPRESA         PIC  X(200).*/
            public StringBasis LK_GE0306B_CHR_USO_EMPRESA { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");
            /*"    05 LK-GE0306B-REGISTRO                PIC  X(4834).*/
            public StringBasis LK_GE0306B_REGISTRO { get; set; } = new StringBasis(new PIC("X", "4834", "X(4834)."), @"");
            /*"  05 LK-GE0306B-COD-RETORNO             PIC  X(01).*/
        }
        public StringBasis LK_GE0306B_COD_RETORNO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"  05 LK-GE0306B-MENSAGEM.*/
        public SISAP01B_LK_GE0306B_MENSAGEM LK_GE0306B_MENSAGEM { get; set; } = new SISAP01B_LK_GE0306B_MENSAGEM();
        public class SISAP01B_LK_GE0306B_MENSAGEM : VarBasis
        {
            /*"       10 LK-GE0306B-SQLCODE              PIC   -ZZ9.*/
            public IntBasis LK_GE0306B_SQLCODE { get; set; } = new IntBasis(new PIC("9", "3", "-ZZ9."));
            /*"       10 FILLER                          PIC  X(01).*/
            public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"       10 LK-GE0306B-MENSAGEM-RETORNO     PIC  X(75).*/
            public StringBasis LK_GE0306B_MENSAGEM_RETORNO { get; set; } = new StringBasis(new PIC("X", "75", "X(75)."), @"");
            /*"01  W-TIPO-E-CPF-CNPJ.*/
        }
        public SISAP01B_W_TIPO_E_CPF_CNPJ W_TIPO_E_CPF_CNPJ { get; set; } = new SISAP01B_W_TIPO_E_CPF_CNPJ();
        public class SISAP01B_W_TIPO_E_CPF_CNPJ : VarBasis
        {
            /*"  05 W-SE-EH-PF-PJ                 PIC  X(02).*/
            public StringBasis W_SE_EH_PF_PJ { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
            /*"  05 W-CPF-CNPJ-MUTUARIO           PIC  9(14).*/
            public IntBasis W_CPF_CNPJ_MUTUARIO { get; set; } = new IntBasis(new PIC("9", "14", "9(14)."));
            /*"  05 FILLER                        PIC  X(64).*/
            public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "64", "X(64)."), @"");
            /*"01  REGISTRO-LINKAGE-SAP-P15B.*/
        }
        public SISAP01B_REGISTRO_LINKAGE_SAP_P15B REGISTRO_LINKAGE_SAP_P15B { get; set; } = new SISAP01B_REGISTRO_LINKAGE_SAP_P15B();
        public class SISAP01B_REGISTRO_LINKAGE_SAP_P15B : VarBasis
        {
            /*"  05 P15B-SAP-NUM-APOLICE          PIC S9(13) COMP-3.*/
            public IntBasis P15B_SAP_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
            /*"  05 P15B-SAP-NUM-ENDOSSO          PIC S9(09) COMP.*/
            public IntBasis P15B_SAP_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"  05 P15B-SAP-NUM-PARCELA          PIC S9(04) COMP.*/
            public IntBasis P15B_SAP_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05 P15B-SAP-COD-CONVENIO         PIC S9(09) COMP.*/
            public IntBasis P15B_SAP_COD_CONVENIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"  05 P15B-SAP-NSAS                 PIC S9(04) COMP.*/
            public IntBasis P15B_SAP_NSAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05 P15B-SAP-SITUACAO-COBRANCA    PIC  X(01).*/
            public StringBasis P15B_SAP_SITUACAO_COBRANCA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"  05 P15B-SAP-COD-BANCO            PIC S9(04) COMP.*/
            public IntBasis P15B_SAP_COD_BANCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05 P15B-SAP-COD-AGENCIA          PIC  9(05).*/
            public IntBasis P15B_SAP_COD_AGENCIA { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
            /*"  05 P15B-SAP-DV-AGENCIA           PIC  X(01).*/
            public StringBasis P15B_SAP_DV_AGENCIA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"  05 P15B-SAP-OPERACAO-CONTA       PIC  9(04).*/
            public IntBasis P15B_SAP_OPERACAO_CONTA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"  05 P15B-SAP-NUM-CONTA            PIC  9(12).*/
            public IntBasis P15B_SAP_NUM_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(12)."));
            /*"  05 P15B-SAP-DV-CONTA             PIC  X(01).*/
            public StringBasis P15B_SAP_DV_CONTA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"  05 P15B-SAP-COD-PROGRAMA         PIC  X(08).*/
            public StringBasis P15B_SAP_COD_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
            /*"  05 P15B-SAP-FAVORECIDO.*/
            public SISAP01B_P15B_SAP_FAVORECIDO P15B_SAP_FAVORECIDO { get; set; } = new SISAP01B_P15B_SAP_FAVORECIDO();
            public class SISAP01B_P15B_SAP_FAVORECIDO : VarBasis
            {
                /*"       10 P15B-SAP-NOME-FAVORECIDO   PIC  X(30).*/
                public StringBasis P15B_SAP_NOME_FAVORECIDO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
                /*"       10 P15B-SAP-NUM-DOC-EMPRESA   PIC  9(06).*/
                public IntBasis P15B_SAP_NUM_DOC_EMPRESA { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
                /*"       10 P15B-SAP-FILLER1           PIC  X(04).*/
                public StringBasis P15B_SAP_FILLER1 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)."), @"");
                /*"  05 P15B-SAP-DES-LOGRADOURO       PIC  X(30).*/
            }
            public StringBasis P15B_SAP_DES_LOGRADOURO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
            /*"  05 P15B-SAP-NUM-LOCAL            PIC  9(05).*/
            public IntBasis P15B_SAP_NUM_LOCAL { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
            /*"  05 P15B-SAP-DES-COMPLEMENTO      PIC  X(15).*/
            public StringBasis P15B_SAP_DES_COMPLEMENTO { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
            /*"  05 P15B-SAP-DES-BAIRRO           PIC  X(15).*/
            public StringBasis P15B_SAP_DES_BAIRRO { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
            /*"  05 P15B-SAP-DES-CIDADE           PIC  X(20).*/
            public StringBasis P15B_SAP_DES_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
            /*"  05 P15B-SAP-NUM-CEP              PIC  9(05).*/
            public IntBasis P15B_SAP_NUM_CEP { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
            /*"  05 P15B-SAP-DES-COMPL-CEP        PIC  X(03).*/
            public StringBasis P15B_SAP_DES_COMPL_CEP { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
            /*"  05 P15B-SAP-DES-SIGLA-UF         PIC  X(02).*/
            public StringBasis P15B_SAP_DES_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
            /*"  05 P15B-SAP-CHR-USO-EMPRESA.*/
            public SISAP01B_P15B_SAP_CHR_USO_EMPRESA P15B_SAP_CHR_USO_EMPRESA { get; set; } = new SISAP01B_P15B_SAP_CHR_USO_EMPRESA();
            public class SISAP01B_P15B_SAP_CHR_USO_EMPRESA : VarBasis
            {
                /*"       10 WS-USO-EMPRESA-SICOV-TXT1  PIC  X(40).*/
                public StringBasis WS_USO_EMPRESA_SICOV_TXT1_0 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"       10 FILLER                     PIC  X(01).*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10 WS-USO-EMPRESA-SICOV-25    PIC  X(25).*/
                public StringBasis WS_USO_EMPRESA_SICOV_25_0 { get; set; } = new StringBasis(new PIC("X", "25", "X(25)."), @"");
                /*"       10 FILLER                     PIC  X(01).*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10 WS-USO-EMPRESA-SICOV-TXT2  PIC  X(40).*/
                public StringBasis WS_USO_EMPRESA_SICOV_TXT2_0 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"       10 FILLER                     PIC  X(01).*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10 WS-USO-EMPRESA-SICOV-60    PIC  X(60).*/
                public StringBasis WS_USO_EMPRESA_SICOV_60_0 { get; set; } = new StringBasis(new PIC("X", "60", "X(60)."), @"");
                /*"       10 FILLER                     PIC  X(32).*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "32", "X(32)."), @"");
                /*"  05 P15B-SAP-COD-DOCUMENTO-SIACC  PIC  X(15).*/
            }
            public StringBasis P15B_SAP_COD_DOCUMENTO_SIACC { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
            /*"  05 P15B-SAP-USO-EMPRESA-SIACC    PIC  X(40).*/
            public StringBasis P15B_SAP_USO_EMPRESA_SIACC { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"  05 P15B-SAP-COD-RETORNO          PIC  X(01).*/
            public StringBasis P15B_SAP_COD_RETORNO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"  05 P15B-SAP-MENSAGEM-RETORNO     PIC  X(80).*/
            public StringBasis P15B_SAP_MENSAGEM_RETORNO { get; set; } = new StringBasis(new PIC("X", "80", "X(80)."), @"");
            /*"  05 P15B-SAP-REGISTRO             PIC  X(3503).*/
            public StringBasis P15B_SAP_REGISTRO { get; set; } = new StringBasis(new PIC("X", "3503", "X(3503)."), @"");
            /*"01  REGISTRO-LINKAGE-SAP.*/
        }
        public SISAP01B_REGISTRO_LINKAGE_SAP REGISTRO_LINKAGE_SAP { get; set; } = new SISAP01B_REGISTRO_LINKAGE_SAP();
        public class SISAP01B_REGISTRO_LINKAGE_SAP : VarBasis
        {
            /*"  05 LK-SAP-NUM-APOLICE            PIC S9(13) COMP-3.*/
            public IntBasis LK_SAP_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
            /*"  05 LK-SAP-NUM-ENDOSSO            PIC S9(09) COMP.*/
            public IntBasis LK_SAP_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"  05 LK-SAP-NUM-PARCELA            PIC S9(04) COMP.*/
            public IntBasis LK_SAP_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05 LK-SAP-COD-CONVENIO           PIC S9(09) COMP.*/
            public IntBasis LK_SAP_COD_CONVENIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"  05 LK-SAP-NSAS                   PIC S9(04) COMP.*/
            public IntBasis LK_SAP_NSAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05 LK-SAP-SITUACAO-COBRANCA      PIC  X(01).*/
            public StringBasis LK_SAP_SITUACAO_COBRANCA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"  05 LK-SAP-COD-BANCO              PIC S9(04) COMP.*/
            public IntBasis LK_SAP_COD_BANCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05 LK-SAP-COD-AGENCIA            PIC  9(05).*/
            public IntBasis LK_SAP_COD_AGENCIA { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
            /*"  05 LK-SAP-DV-AGENCIA             PIC  X(01).*/
            public StringBasis LK_SAP_DV_AGENCIA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 LK-SAP-OPERACAO-CONTA         PIC  9(04).*/
            public IntBasis LK_SAP_OPERACAO_CONTA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"  05 LK-SAP-NUM-CONTA              PIC  9(12).*/
        }
        public IntBasis LK_SAP_NUM_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(12)."));
        /*"  05 LK-SAP-DV-CONTA               PIC  X(01).*/
        public StringBasis LK_SAP_DV_CONTA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"  05 LK-SAP-COD-PROGRAMA           PIC  X(08).*/
        public StringBasis LK_SAP_COD_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
        /*"  05 LK-SAP-FAVORECIDO.*/
        public SISAP01B_LK_SAP_FAVORECIDO LK_SAP_FAVORECIDO { get; set; } = new SISAP01B_LK_SAP_FAVORECIDO();
        public class SISAP01B_LK_SAP_FAVORECIDO : VarBasis
        {
            /*"       10 LK-SAP-NOME-FAVORECIDO     PIC  X(30).*/
            public StringBasis LK_SAP_NOME_FAVORECIDO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
            /*"       10 LK-SAP-NUM-DOC-EMPRESA     PIC  9(06).*/
            public IntBasis LK_SAP_NUM_DOC_EMPRESA { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
            /*"       10 LK-SAP-FILLER1             PIC  X(04).*/
            public StringBasis LK_SAP_FILLER1 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)."), @"");
            /*"  05 LK-SAP-DES-LOGRADOURO         PIC  X(30).*/
        }
        public StringBasis LK_SAP_DES_LOGRADOURO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"  05 LK-SAP-NUM-LOCAL              PIC  9(05).*/
        public IntBasis LK_SAP_NUM_LOCAL { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
        /*"  05 LK-SAP-DES-COMPLEMENTO        PIC  X(15).*/
        public StringBasis LK_SAP_DES_COMPLEMENTO { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"  05 LK-SAP-DES-BAIRRO             PIC  X(15).*/
        public StringBasis LK_SAP_DES_BAIRRO { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"  05 LK-SAP-DES-CIDADE             PIC  X(20).*/
        public StringBasis LK_SAP_DES_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"  05 LK-SAP-NUM-CEP                PIC  9(05).*/
        public IntBasis LK_SAP_NUM_CEP { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
        /*"  05 LK-SAP-DES-COMPL-CEP          PIC  X(03).*/
        public StringBasis LK_SAP_DES_COMPL_CEP { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
        /*"  05 LK-SAP-DES-SIGLA-UF           PIC  X(02).*/
        public StringBasis LK_SAP_DES_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
        /*"  05 LK-SAP-CHR-USO-EMPRESA.*/
        public SISAP01B_LK_SAP_CHR_USO_EMPRESA LK_SAP_CHR_USO_EMPRESA { get; set; } = new SISAP01B_LK_SAP_CHR_USO_EMPRESA();
        public class SISAP01B_LK_SAP_CHR_USO_EMPRESA : VarBasis
        {
            /*"       10 WS-USO-EMPRESA-SICOV-TXT1  PIC  X(40).*/
            public StringBasis WS_USO_EMPRESA_SICOV_TXT1_1 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"       10 FILLER                     PIC  X(01).*/
            public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"       10 WS-USO-EMPRESA-SICOV-25    PIC  X(25).*/
            public StringBasis WS_USO_EMPRESA_SICOV_25_1 { get; set; } = new StringBasis(new PIC("X", "25", "X(25)."), @"");
            /*"       10 FILLER                     PIC  X(01).*/
            public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"       10 WS-USO-EMPRESA-SICOV-TXT2  PIC  X(40).*/
            public StringBasis WS_USO_EMPRESA_SICOV_TXT2_1 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"       10 FILLER                     PIC  X(01).*/
            public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"       10 WS-USO-EMPRESA-SICOV-60    PIC  X(60).*/
            public StringBasis WS_USO_EMPRESA_SICOV_60_1 { get; set; } = new StringBasis(new PIC("X", "60", "X(60)."), @"");
            /*"       10 FILLER                     PIC  X(32).*/
            public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "32", "X(32)."), @"");
            /*"  05 LK-SAP-COD-DOCUMENTO-SIACC    PIC  X(15).*/
        }
        public StringBasis LK_SAP_COD_DOCUMENTO_SIACC { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"  05 LK-SAP-USO-EMPRESA-SIACC      PIC  X(40).*/
        public StringBasis LK_SAP_USO_EMPRESA_SIACC { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"  05 LK-SAP-COD-RETORNO            PIC  X(01).*/
        public StringBasis LK_SAP_COD_RETORNO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"  05 LK-SAP-MENSAGEM-RETORNO       PIC  X(80).*/
        public StringBasis LK_SAP_MENSAGEM_RETORNO { get; set; } = new StringBasis(new PIC("X", "80", "X(80)."), @"");
        /*"    05 LK-SAP-REGISTRO               PIC  X(4834).*/
        public StringBasis LK_SAP_REGISTRO { get; set; } = new StringBasis(new PIC("X", "4834", "X(4834)."), @"");


        public Dclgens.SIPROJUD SIPROJUD { get; set; } = new Dclgens.SIPROJUD();
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
        public Dclgens.GEARDETA GEARDETA { get; set; } = new Dclgens.GEARDETA();
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
        public SISAP01B_LE_MOVDEBCE LE_MOVDEBCE { get; set; } = new SISAP01B_LE_MOVDEBCE();
        public SISAP01B_IMPOSTOS IMPOSTOS { get; set; } = new SISAP01B_IMPOSTOS();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(SISAP01B_REGISTRO_LINKAGE_SAP SISAP01B_REGISTRO_LINKAGE_SAP_P) //PROCEDURE DIVISION USING 
        /*REGISTRO_LINKAGE_SAP*/
        {
            try
            {
                this.REGISTRO_LINKAGE_SAP = SISAP01B_REGISTRO_LINKAGE_SAP_P;

                /*" -1997- INSPECT LK-SAP-SITUACAO-COBRANCA CONVERTING LOW-VALUES TO ' ' . */
                REGISTRO_LINKAGE_SAP.LK_SAP_SITUACAO_COBRANCA.Value = REGISTRO_LINKAGE_SAP.LK_SAP_SITUACAO_COBRANCA.Value.Replace("\0", " ");

                /*" -1999- INSPECT LK-SAP-DV-AGENCIA CONVERTING LOW-VALUES TO ' ' . */
                REGISTRO_LINKAGE_SAP.LK_SAP_DV_AGENCIA.Value = REGISTRO_LINKAGE_SAP.LK_SAP_DV_AGENCIA.Value.Replace("\0", " ");

                /*" -2001- INSPECT LK-SAP-DV-CONTA CONVERTING LOW-VALUES TO ' ' . */
                LK_SAP_DV_CONTA.Value = LK_SAP_DV_CONTA.Value.Replace("\0", " ");

                /*" -2003- INSPECT LK-SAP-COD-PROGRAMA CONVERTING LOW-VALUES TO ' ' . */
                LK_SAP_COD_PROGRAMA.Value = LK_SAP_COD_PROGRAMA.Value.Replace("\0", " ");

                /*" -2005- INSPECT LK-SAP-NOME-FAVORECIDO CONVERTING LOW-VALUES TO ' ' . */
                LK_SAP_FAVORECIDO.LK_SAP_NOME_FAVORECIDO.Value = LK_SAP_FAVORECIDO.LK_SAP_NOME_FAVORECIDO.Value.Replace("\0", " ");

                /*" -2007- INSPECT LK-SAP-FILLER1 CONVERTING LOW-VALUES TO ' ' . */
                LK_SAP_FAVORECIDO.LK_SAP_FILLER1.Value = LK_SAP_FAVORECIDO.LK_SAP_FILLER1.Value.Replace("\0", " ");

                /*" -2009- INSPECT LK-SAP-DES-LOGRADOURO CONVERTING LOW-VALUES TO ' ' . */
                LK_SAP_DES_LOGRADOURO.Value = LK_SAP_DES_LOGRADOURO.Value.Replace("\0", " ");

                /*" -2011- INSPECT LK-SAP-DES-COMPLEMENTO CONVERTING LOW-VALUES TO ' ' . */
                LK_SAP_DES_COMPLEMENTO.Value = LK_SAP_DES_COMPLEMENTO.Value.Replace("\0", " ");

                /*" -2013- INSPECT LK-SAP-DES-BAIRRO CONVERTING LOW-VALUES TO ' ' . */
                LK_SAP_DES_BAIRRO.Value = LK_SAP_DES_BAIRRO.Value.Replace("\0", " ");

                /*" -2015- INSPECT LK-SAP-DES-CIDADE CONVERTING LOW-VALUES TO ' ' . */
                LK_SAP_DES_CIDADE.Value = LK_SAP_DES_CIDADE.Value.Replace("\0", " ");

                /*" -2017- INSPECT LK-SAP-DES-COMPL-CEP CONVERTING LOW-VALUES TO ' ' . */
                LK_SAP_DES_COMPL_CEP.Value = LK_SAP_DES_COMPL_CEP.Value.Replace("\0", " ");

                /*" -2047- INSPECT LK-SAP-DES-SIGLA-UF CONVERTING LOW-VALUES TO ' ' . */
                LK_SAP_DES_SIGLA_UF.Value = LK_SAP_DES_SIGLA_UF.Value.Replace("\0", " ");

                /*" -2048- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -2050- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -2052- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -2057- DISPLAY '------------------------------------------------' */
                _.Display($"------------------------------------------------");

                /*" -2064- DISPLAY 'SISAP01B VERSAO 028 - INICIO  PROCESSAMENTO EM  ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

                $"SISAP01B VERSAO 028 - INICIO  PROCESSAMENTO EM  {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
                .Display();

                /*" -2066- DISPLAY '------------------------------------------------' */
                _.Display($"------------------------------------------------");

                /*" -2068- MOVE '0' TO LK-SAP-COD-RETORNO */
                _.Move("0", LK_SAP_COD_RETORNO);

                /*" -2070- IF (LK-SAP-COD-PROGRAMA NOT EQUAL 'FI0096B' ) AND (LK-SAP-COD-PROGRAMA NOT EQUAL 'SI5071B' ) */

                if ((LK_SAP_COD_PROGRAMA != "FI0096B") && (LK_SAP_COD_PROGRAMA != "SI5071B"))
                {

                    /*" -2073- MOVE SPACES TO LK-SAP-MENSAGEM-RETORNO. */
                    _.Move("", LK_SAP_MENSAGEM_RETORNO);
                }


                /*" -2082- PERFORM R0010-SELECT-SISTEMAS THRU R0010-EXIT. */

                R0010_SELECT_SISTEMAS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_EXIT*/


                /*" -2088- IF (LK-SAP-COD-PROGRAMA NOT EQUAL 'FI0096B' ) AND (LK-SAP-COD-PROGRAMA NOT EQUAL 'SI5071B' ) AND (LK-SAP-COD-PROGRAMA NOT EQUAL 'SI5067B' ) AND (LK-SAP-COD-PROGRAMA NOT EQUAL 'CB1061B' ) AND (LK-SAP-COD-PROGRAMA NOT EQUAL 'SI5001B' ) AND (LK-SAP-COD-PROGRAMA NOT EQUAL 'SI5002B' ) */

                if ((LK_SAP_COD_PROGRAMA != "FI0096B") && (LK_SAP_COD_PROGRAMA != "SI5071B") && (LK_SAP_COD_PROGRAMA != "SI5067B") && (LK_SAP_COD_PROGRAMA != "CB1061B") && (LK_SAP_COD_PROGRAMA != "SI5001B") && (LK_SAP_COD_PROGRAMA != "SI5002B"))
                {

                    /*" -2089- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -2090- DISPLAY '**********************************************' */
                    _.Display($"**********************************************");

                    /*" -2091- DISPLAY '*' */
                    _.Display($"*");

                    /*" -2092- DISPLAY '* ATENCAO: ROTINA DE SEGURANCAO DE GERACAO' */
                    _.Display($"* ATENCAO: ROTINA DE SEGURANCAO DE GERACAO");

                    /*" -2093- DISPLAY '* DO ARQUIVO A PARA O SAP' */
                    _.Display($"* DO ARQUIVO A PARA O SAP");

                    /*" -2094- DISPLAY '*' */
                    _.Display($"*");

                    /*" -2095- DISPLAY '* PROGRAMA CHAMADOR NAO PREVISTO NA SUB-ROTINA' */
                    _.Display($"* PROGRAMA CHAMADOR NAO PREVISTO NA SUB-ROTINA");

                    /*" -2096- DISPLAY '*' */
                    _.Display($"*");

                    /*" -2097- DISPLAY '* PROGRAMA: ' LK-SAP-COD-PROGRAMA */
                    _.Display($"* PROGRAMA: {LK_SAP_COD_PROGRAMA}");

                    /*" -2098- DISPLAY '*' */
                    _.Display($"*");

                    /*" -2099- DISPLAY '**********************************************' */
                    _.Display($"**********************************************");

                    /*" -2106- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO(); //GOTO
                    return Result;
                }


                /*" -2112- IF (LK-SAP-COD-CONVENIO NOT EQUAL 600128) AND (LK-SAP-COD-CONVENIO NOT EQUAL 600119) AND (LK-SAP-COD-CONVENIO NOT EQUAL 600120) AND (LK-SAP-COD-CONVENIO NOT EQUAL 600123) AND (LK-SAP-COD-CONVENIO NOT EQUAL 921286) AND (LK-SAP-COD-CONVENIO NOT EQUAL 43350) */

                if ((REGISTRO_LINKAGE_SAP.LK_SAP_COD_CONVENIO != 600128) && (REGISTRO_LINKAGE_SAP.LK_SAP_COD_CONVENIO != 600119) && (REGISTRO_LINKAGE_SAP.LK_SAP_COD_CONVENIO != 600120) && (REGISTRO_LINKAGE_SAP.LK_SAP_COD_CONVENIO != 600123) && (REGISTRO_LINKAGE_SAP.LK_SAP_COD_CONVENIO != 921286) && (REGISTRO_LINKAGE_SAP.LK_SAP_COD_CONVENIO != 43350))
                {

                    /*" -2113- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -2114- DISPLAY '**********************************************' */
                    _.Display($"**********************************************");

                    /*" -2115- DISPLAY '*' */
                    _.Display($"*");

                    /*" -2116- DISPLAY '* ATENCAO: ROTINA DE SEGURANCAO DE GERACAO' */
                    _.Display($"* ATENCAO: ROTINA DE SEGURANCAO DE GERACAO");

                    /*" -2117- DISPLAY '* DO ARQUIVO A PARA O SAP' */
                    _.Display($"* DO ARQUIVO A PARA O SAP");

                    /*" -2118- DISPLAY '*' */
                    _.Display($"*");

                    /*" -2119- DISPLAY '* CONVENIO NAO PREVISTO NA SUB-ROTINA' */
                    _.Display($"* CONVENIO NAO PREVISTO NA SUB-ROTINA");

                    /*" -2120- DISPLAY '*' */
                    _.Display($"*");

                    /*" -2121- DISPLAY '* CONVENIO: ' LK-SAP-COD-CONVENIO */
                    _.Display($"* CONVENIO: {REGISTRO_LINKAGE_SAP.LK_SAP_COD_CONVENIO}");

                    /*" -2122- DISPLAY '*' */
                    _.Display($"*");

                    /*" -2123- DISPLAY '**********************************************' */
                    _.Display($"**********************************************");

                    /*" -2125- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO(); //GOTO
                    return Result;
                }


                /*" -2127- PERFORM R0020-VALIDA-MOVDEBCE THRU R0020-EXIT. */

                R0020_VALIDA_MOVDEBCE(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_EXIT*/


                /*" -2129- MOVE 'NAO' TO WFIM-LE-MOVDEBCE-1. */
                _.Move("NAO", AREA_DE_WORK.WFIM_LE_MOVDEBCE_1);

                /*" -2130- PERFORM R0100-DECLARE-MOVDEBCE THRU R0100-EXIT. */

                R0100_DECLARE_MOVDEBCE(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_EXIT*/


                /*" -2132- PERFORM R0101-FETCH-MOVDEBCE THRU R0101-EXIT. */

                R0101_FETCH_MOVDEBCE(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0101_EXIT*/


                /*" -2133- PERFORM R0200-PROCESSA-PRINCIPAL THRU R0200-EXIT UNTIL WFIM-LE-MOVDEBCE-1 = 'SIM' . */

                while (!(AREA_DE_WORK.WFIM_LE_MOVDEBCE_1 == "SIM"))
                {

                    R0200_PROCESSA_PRINCIPAL(true);

                    R0200_MONTA_REGISTRO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_EXIT*/

                }

                /*" -2133- FLUXCONTROL_PERFORM R0000-90-FINALIZA */

                R0000_90_FINALIZA();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { REGISTRO_LINKAGE_SAP, CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -2138- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -2139- MOVE '0' TO LK-SAP-COD-RETORNO */
            _.Move("0", LK_SAP_COD_RETORNO);

            /*" -2141- MOVE 'EXECUCAO COM SUCESSO' TO LK-SAP-MENSAGEM-RETORNO. */
            _.Move("EXECUCAO COM SUCESSO", LK_SAP_MENSAGEM_RETORNO);

            /*" -2141- GO TO RXXXX-ROTINA-RETORNO. */

            RXXXX_ROTINA_RETORNO(); //GOTO
            return;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_SAIDA*/

        [StopWatch]
        /*" R0010-SELECT-SISTEMAS */
        private void R0010_SELECT_SISTEMAS(bool isPerform = false)
        {
            /*" -2158- PERFORM R0010_SELECT_SISTEMAS_DB_SELECT_1 */

            R0010_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -2161- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -2162- DISPLAY 'SISAP01B - ERRO NO ACESSO SISTEMAS - FI' */
                _.Display($"SISAP01B - ERRO NO ACESSO SISTEMAS - FI");

                /*" -2164- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -2172- PERFORM R0010_SELECT_SISTEMAS_DB_SELECT_2 */

            R0010_SELECT_SISTEMAS_DB_SELECT_2();

            /*" -2175- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -2176- DISPLAY 'SISAP01B - ERRO NO ACESSO SISTEMAS - SI' */
                _.Display($"SISAP01B - ERRO NO ACESSO SISTEMAS - SI");

                /*" -2207- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -2208- MOVE HOST-CURRENT-DATE(1:4) TO W-LOTE-DATE-AAAA. */
            _.Move(HOST_CURRENT_DATE.Substring(1, 4), AREA_DE_WORK.W_LOTE.W_LOTE_DATE_AAAA);

            /*" -2209- MOVE HOST-CURRENT-DATE(6:2) TO W-LOTE-DATE-MM. */
            _.Move(HOST_CURRENT_DATE.Substring(6, 2), AREA_DE_WORK.W_LOTE.W_LOTE_DATE_MM);

            /*" -2210- MOVE HOST-CURRENT-DATE(9:2) TO W-LOTE-DATE-DD. */
            _.Move(HOST_CURRENT_DATE.Substring(9, 2), AREA_DE_WORK.W_LOTE.W_LOTE_DATE_DD);

            /*" -2211- MOVE HOST-CURRENT-TIME(1:2) TO W-LOTE-TIME-HH. */
            _.Move(HOST_CURRENT_TIME.Substring(1, 2), AREA_DE_WORK.W_LOTE.W_LOTE_TIME_HH);

            /*" -2212- MOVE HOST-CURRENT-TIME(4:2) TO W-LOTE-TIME-MM. */
            _.Move(HOST_CURRENT_TIME.Substring(4, 2), AREA_DE_WORK.W_LOTE.W_LOTE_TIME_MM);

            /*" -2212- MOVE HOST-CURRENT-TIME(7:2) TO W-LOTE-TIME-SS. */
            _.Move(HOST_CURRENT_TIME.Substring(7, 2), AREA_DE_WORK.W_LOTE.W_LOTE_TIME_SS);

        }

        [StopWatch]
        /*" R0010-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0010_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -2158- EXEC SQL SELECT DATA_MOV_ABERTO, DATULT_PROCESSAMEN, CURRENT DATE, CURRENT TIME INTO :SISTEMAS-DATA-MOV-ABERTO, :SISTEMAS-DATULT-PROCESSAMEN, :HOST-CURRENT-DATE, :HOST-CURRENT-TIME FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'FI' WITH UR END-EXEC. */

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
            /*" -2172- EXEC SQL SELECT DATA_MOV_ABERTO, CURRENT DATE INTO :HOST-SI-DATA-MOV-ABERTO, :HOST-SI-CURRENT-DATE FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' WITH UR END-EXEC. */

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
            /*" -2222- IF LK-SAP-NUM-ENDOSSO EQUAL 1081 */

            if (REGISTRO_LINKAGE_SAP.LK_SAP_NUM_ENDOSSO == 1081)
            {

                /*" -2225- DISPLAY ' INDENIZA APOLICE =' LK-SAP-NUM-APOLICE ' ENDO = ' LK-SAP-NUM-ENDOSSO ' PARC = ' LK-SAP-NUM-PARCELA */

                $" INDENIZA APOLICE ={REGISTRO_LINKAGE_SAP.LK_SAP_NUM_APOLICE} ENDO = {REGISTRO_LINKAGE_SAP.LK_SAP_NUM_ENDOSSO} PARC = {REGISTRO_LINKAGE_SAP.LK_SAP_NUM_PARCELA}"
                .Display();

                /*" -2226- END-IF */
            }


            /*" -2228- MOVE 0 TO HOST-COUNT. */
            _.Move(0, HOST_COUNT);

            /*" -2238- PERFORM R0020_VALIDA_MOVDEBCE_DB_SELECT_1 */

            R0020_VALIDA_MOVDEBCE_DB_SELECT_1();

            /*" -2241- IF SQLCODE EQUAL 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -2242- IF HOST-COUNT EQUAL 0 */

                if (HOST_COUNT == 0)
                {

                    /*" -2243- DISPLAY 'SISAP01B - REGISTRO NAO ACHADO NA MOVDEBCE' */
                    _.Display($"SISAP01B - REGISTRO NAO ACHADO NA MOVDEBCE");

                    /*" -2245- DISPLAY 'LK-SAP-NUM-APOLICE ........ ' LK-SAP-NUM-APOLICE */
                    _.Display($"LK-SAP-NUM-APOLICE ........ {REGISTRO_LINKAGE_SAP.LK_SAP_NUM_APOLICE}");

                    /*" -2247- DISPLAY 'LK-SAP-NUM-ENDOSSO ........ ' LK-SAP-NUM-ENDOSSO */
                    _.Display($"LK-SAP-NUM-ENDOSSO ........ {REGISTRO_LINKAGE_SAP.LK_SAP_NUM_ENDOSSO}");

                    /*" -2249- DISPLAY 'LK-SAP-NUM-PARCELA ........ ' LK-SAP-NUM-PARCELA */
                    _.Display($"LK-SAP-NUM-PARCELA ........ {REGISTRO_LINKAGE_SAP.LK_SAP_NUM_PARCELA}");

                    /*" -2251- DISPLAY 'LK-SAP-NSAS ............... ' LK-SAP-NSAS */
                    _.Display($"LK-SAP-NSAS ............... {REGISTRO_LINKAGE_SAP.LK_SAP_NSAS}");

                    /*" -2253- DISPLAY 'LK-SAP-COD-CONVENIO ....... ' LK-SAP-COD-CONVENIO */
                    _.Display($"LK-SAP-COD-CONVENIO ....... {REGISTRO_LINKAGE_SAP.LK_SAP_COD_CONVENIO}");

                    /*" -2255- DISPLAY 'LK-SAP-SITUACAO-COBRANCA .. ' LK-SAP-SITUACAO-COBRANCA */
                    _.Display($"LK-SAP-SITUACAO-COBRANCA .. {REGISTRO_LINKAGE_SAP.LK_SAP_SITUACAO_COBRANCA}");

                    /*" -2256- MOVE '1' TO LK-SAP-COD-RETORNO */
                    _.Move("1", LK_SAP_COD_RETORNO);

                    /*" -2258- MOVE 'NAO FOI ENCONTRADO REG. NA MOVTO_DEBITOCC_CEF' TO LK-SAP-MENSAGEM-RETORNO */
                    _.Move("NAO FOI ENCONTRADO REG. NA MOVTO_DEBITOCC_CEF", LK_SAP_MENSAGEM_RETORNO);

                    /*" -2260- GO TO RXXXX-ROTINA-RETORNO. */

                    RXXXX_ROTINA_RETORNO(); //GOTO
                    return;
                }

            }


            /*" -2261- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -2262- DISPLAY 'SISAP01B - ERRO ACESSO MOVDEBCE - VALIDACAO' */
                _.Display($"SISAP01B - ERRO ACESSO MOVDEBCE - VALIDACAO");

                /*" -2262- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0020-VALIDA-MOVDEBCE-DB-SELECT-1 */
        public void R0020_VALIDA_MOVDEBCE_DB_SELECT_1()
        {
            /*" -2238- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :HOST-COUNT FROM SEGUROS.MOVTO_DEBITOCC_CEF MO WHERE MO.NUM_APOLICE = :LK-SAP-NUM-APOLICE AND MO.NUM_ENDOSSO = :LK-SAP-NUM-ENDOSSO AND MO.NUM_PARCELA = :LK-SAP-NUM-PARCELA AND MO.NSAS = :LK-SAP-NSAS AND MO.SITUACAO_COBRANCA = :LK-SAP-SITUACAO-COBRANCA AND MO.COD_CONVENIO = :LK-SAP-COD-CONVENIO END-EXEC. */

            var r0020_VALIDA_MOVDEBCE_DB_SELECT_1_Query1 = new R0020_VALIDA_MOVDEBCE_DB_SELECT_1_Query1()
            {
                LK_SAP_SITUACAO_COBRANCA = REGISTRO_LINKAGE_SAP.LK_SAP_SITUACAO_COBRANCA.ToString(),
                LK_SAP_COD_CONVENIO = REGISTRO_LINKAGE_SAP.LK_SAP_COD_CONVENIO.ToString(),
                LK_SAP_NUM_APOLICE = REGISTRO_LINKAGE_SAP.LK_SAP_NUM_APOLICE.ToString(),
                LK_SAP_NUM_ENDOSSO = REGISTRO_LINKAGE_SAP.LK_SAP_NUM_ENDOSSO.ToString(),
                LK_SAP_NUM_PARCELA = REGISTRO_LINKAGE_SAP.LK_SAP_NUM_PARCELA.ToString(),
                LK_SAP_NSAS = REGISTRO_LINKAGE_SAP.LK_SAP_NSAS.ToString(),
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
            /*" -2270- MOVE 0 TO W-AC-LIDOS-MOVDEBCE */
            _.Move(0, AREA_DE_WORK.W_AC_LIDOS_MOVDEBCE);

            /*" -2665- PERFORM R0100_DECLARE_MOVDEBCE_DB_DECLARE_1 */

            R0100_DECLARE_MOVDEBCE_DB_DECLARE_1();

            /*" -2667- PERFORM R0100_DECLARE_MOVDEBCE_DB_OPEN_1 */

            R0100_DECLARE_MOVDEBCE_DB_OPEN_1();

            /*" -2670- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -2671- DISPLAY 'SISAP01B - ERRO CURSOR LE_MOVDEBCE' */
                _.Display($"SISAP01B - ERRO CURSOR LE_MOVDEBCE");

                /*" -2671- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0100-DECLARE-MOVDEBCE-DB-DECLARE-1 */
        public void R0100_DECLARE_MOVDEBCE_DB_DECLARE_1()
        {
            /*" -2665- EXEC SQL DECLARE LE_MOVDEBCE CURSOR FOR SELECT 'CRED/DEB 1 - CONV 600128 - SIN, 43350 - RESS.,921286 - BB' , H.TIPO_REGISTRO AS 'TIPO SEGURO' , CASE H.TIPO_REGISTRO WHEN '0' THEN 'COSSEGURO ACEITO' WHEN '1' THEN 'NOSSA LIDERANCA ' END AS 'NOME TIPO SEGURO' , H.NUM_APOLICE AS 'NUM APOLICE' , H.NUM_APOL_SINISTRO AS 'NUM SINISTRO' , H.OCORR_HISTORICO AS 'OCORRHIST' , H.COD_OPERACAO AS 'OPERACAO' , H.NOME_FAVORECIDO AS 'NOME FAVORECIDO - HISTSINI' , YEAR(H.DATA_MOVIMENTO) AS 'ANO OPERACIONAL DO PAGAMENTO' , YEAR(SIS.DATA_MOV_ABERTO) AS 'ANO CONTABIL DO PAGAMENTO' , OPE.FUNCAO_OPERACAO AS 'FUNCAO OPERACAO' , SUBSTR(OPE.DES_OPERACAO,1,30) AS 'NOME OPERACAO' , ABS(H.VAL_OPERACAO) AS 'VALOR BRUTO' , MO.VLR_CREDITO AS 'MOV. VALOR CREDITO' , MO.VALOR_DEBITO AS 'MOV. VALOR DEBITO' , H.DATA_MOVIMENTO AS 'DATA BAIXA PELA TESOURARIA' , H.COD_PREST_SERVICO AS 'COD DA FORNECEDORES' , H.COD_SERVICO AS 'COD DO SERVICO' , H.SIT_CONTABIL AS 'FORMA PAGAMENTO' , CASE H.SIT_CONTABIL WHEN '1' THEN 'CHEQUE PAPEL     ' WHEN '2' THEN 'CREDITO EM CONTA ' WHEN '7' THEN 'SIACC            ' END AS 'NOME FORMA PAGAMENTO' , H.NOM_PROGRAMA AS 'PGM GERADOR' , H.COD_USUARIO AS 'USUARIO QUE BAIXO PAGTO' , M.RAMO AS 'RAMO CXS' , M.COD_FONTE AS 'FONTE' , H1.DATA_MOVIMENTO AS 'DATA AVISO NO SIAS' , M.DATA_COMUNICADO AS 'DATA COMUNICADO NA CXS' , M.COD_PRODUTO AS 'PRODUTO' , PRO.DESCR_PRODUTO AS 'NOME PRODUTO' , SC.NUM_CHEQUE_INTERNO AS 'CHQINT' , MO.NUM_APOLICE AS 'MOV. APOLICE' , MO.NUM_ENDOSSO AS 'MOV. ENDOSSO' , MO.NUM_PARCELA AS 'MOV. PARCELA' , MO.SITUACAO_COBRANCA AS 'MOV. SITUACAO COBRANCA' , CASE MO.SITUACAO_COBRANCA WHEN ' ' THEN 'PEND. ENVIO 1                     ' WHEN '0' THEN 'PEND. ENVIO 2                     ' WHEN '1' THEN 'PEND. RETORNO                     ' WHEN '2' THEN 'CRD/DEB EFETUADO C/ SUCESSO       ' WHEN '3' THEN 'CRD/DEB NAO EFETUADO              ' WHEN '4' THEN 'CANCELADO A PEDIDO DO GCX AO BANCO' WHEN '6' THEN 'CRD C/ NAO EFETUADO - GERADO CHQ. ' END AS 'MOV. NOME SITUACAO COBRANCA' , MO.DATA_VENCIMENTO AS 'MOV. DATA CREDITO' , MO.DATA_MOVIMENTO AS 'MOV. DT. GERACAO MOVDEBCC' , MO.COD_AGENCIA_DEB AS 'MOV. AGENCIA' , MO.OPER_CONTA_DEB AS 'MOV. OPER CONTA' , MO.NUM_CONTA_DEB AS 'MOV. NUM. CONTA' , MO.DIG_CONTA_DEB AS 'MOV. DV CONTA' , MO.COD_CONVENIO AS 'MOV.CONVENIO' , MO.DATA_ENVIO AS 'MOV. DT. ENVIO SIAS P/ SAP' , MO.NSAS AS 'MOV. NSAS' , MO.NUM_REQUISICAO AS 'MOV. NUM. CHQ. INTERNO' , CONTA.COD_AGENCIA AS 'CONTA COD AGENCIA' , CONTA.COD_BANCO AS 'CONTA BANCO' , CONTA.NUM_CONTA_CNB AS 'CONTA NUM. CONTA' , CONTA.NUM_DV_CONTA_CNB AS 'CONTA DV CONTA' , CONTA.IND_CONTA_BANCARIA AS 'CONTA ACHO QUE OPERACAO CONTA' , PRO.COD_EMPRESA AS 'CODG EMPRESA' FROM SEGUROS.SISTEMAS SIS, SEGUROS.SINISTRO_HISTORICO H, SEGUROS.SINISTRO_MESTRE M, SEGUROS.SINISTRO_HISTORICO H1, SEGUROS.SI_SINI_CHEQUE SC, SEGUROS.GE_OPERACAO OPE, SEGUROS.PRODUTO PRO, SEGUROS.MOVTO_DEBITOCC_CEF MO LEFT JOIN SEGUROS.GE_MOVTO_CONTA CONTA ON CONTA.NUM_APOLICE = MO.NUM_APOLICE AND CONTA.NUM_ENDOSSO = MO.NUM_ENDOSSO AND CONTA.NUM_PARCELA = MO.NUM_PARCELA AND CONTA.COD_CONVENIO = MO.COD_CONVENIO AND CONTA.NSAS = MO.NSAS WHERE ( ( MO.COD_CONVENIO = 600128 ) OR ( MO.COD_CONVENIO = 43350 AND MO.NUM_ENDOSSO = 7777 AND MO.NUM_PARCELA = 7777 ) OR ( MO.COD_CONVENIO = 921286 AND MO.NUM_CARTAO <> 0 AND EXISTS (SELECT 1 FROM SEGUROS.SI_SINI_CHEQUE XX WHERE XX.NUM_APOL_SINISTRO = MO.NUM_APOLICE AND XX.OCORR_HISTORICO = MO.NUM_PARCELA AND XX.COD_OPERACAO = MO.NUM_ENDOSSO) ) ) AND MO.NUM_APOLICE = :LK-SAP-NUM-APOLICE AND MO.NUM_ENDOSSO = :LK-SAP-NUM-ENDOSSO AND MO.NUM_PARCELA = :LK-SAP-NUM-PARCELA AND MO.NSAS = :LK-SAP-NSAS AND MO.SITUACAO_COBRANCA = :LK-SAP-SITUACAO-COBRANCA AND SC.NUM_CHEQUE_INTERNO = INTEGER(MO.NUM_CARTAO) AND H.NUM_APOL_SINISTRO = SC.NUM_APOL_SINISTRO AND H.OCORR_HISTORICO = SC.OCORR_HISTORICO AND H.COD_OPERACAO = SC.COD_OPERACAO AND H.SIT_REGISTRO = '1' AND H.SIT_CONTABIL IN ( '2' , '7' ) AND OPE.IDE_SISTEMA = 'SI' AND OPE.COD_OPERACAO = H.COD_OPERACAO AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND PRO.COD_PRODUTO = M.COD_PRODUTO AND H1.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND H1.COD_OPERACAO = 101 AND H1.TIMESTAMP = (SELECT MIN(A.TIMESTAMP) FROM SEGUROS.SINISTRO_HISTORICO A WHERE A.NUM_APOL_SINISTRO = H1.NUM_APOL_SINISTRO AND A.OCORR_HISTORICO = H1.OCORR_HISTORICO AND A.COD_OPERACAO = H1.COD_OPERACAO) AND SIS.IDE_SISTEMA = 'FI' UNION ALL SELECT 'CRED/DEB 2 - CONV 600128 - SIN, 43350 - SIACC,921286 - BB' , H.TIPO_REGISTRO AS 'TIPO SEGURO' , CASE H.TIPO_REGISTRO WHEN '0' THEN 'COSSEGURO ACEITO' WHEN '1' THEN 'NOSSA LIDERANCA ' END AS 'NOME TIPO SEGURO' , H.NUM_APOLICE AS 'NUM APOLICE' , H.NUM_APOL_SINISTRO AS 'NUM SINISTRO' , H.OCORR_HISTORICO AS 'OCORRHIST' , H.COD_OPERACAO AS 'OPERACAO' , H.NOME_FAVORECIDO AS 'NOME FAVORECIDO - HISTSINI' , YEAR(H.DATA_MOVIMENTO) AS 'ANO OPERACIONAL DO PAGAMENTO' , YEAR(SIS.DATA_MOV_ABERTO) AS 'ANO CONTABIL DO PAGAMENTO' , OPE.FUNCAO_OPERACAO AS 'FUNCAO OPERACAO' , SUBSTR(OPE.DES_OPERACAO,1,30) AS 'NOME OPERACAO' , ABS(H.VAL_OPERACAO) AS 'VALOR BRUTO' , MO.VLR_CREDITO AS 'MOV. VALOR CREDITO' , MO.VALOR_DEBITO AS 'MOV. VALOR DEBITO' , H.DATA_MOVIMENTO AS 'DATA BAIXA PELA TESOURARIA' , H.COD_PREST_SERVICO AS 'COD DA FORNECEDORES' , H.COD_SERVICO AS 'COD DO SERVICO' , H.SIT_CONTABIL AS 'FORMA PAGAMENTO' , CASE H.SIT_CONTABIL WHEN '1' THEN 'CHEQUE PAPEL     ' WHEN '2' THEN 'CREDITO EM CONTA ' WHEN '7' THEN 'SIACC            ' END AS 'NOME FORMA PAGAMENTO' , H.NOM_PROGRAMA AS 'PGM GERADOR' , H.COD_USUARIO AS 'USUARIO QUE BAIXO PAGTO' , M.RAMO AS 'RAMO CXS' , M.COD_FONTE AS 'FONTE' , H1.DATA_MOVIMENTO AS 'DATA AVISO NO SIAS' , M.DATA_COMUNICADO AS 'DATA COMUNICADO NA CXS' , M.COD_PRODUTO AS 'PRODUTO' , PRO.DESCR_PRODUTO AS 'NOME PRODUTO' , SC.NUM_CHEQUE_INTERNO AS 'CHQINT' , MO.NUM_APOLICE AS 'MOV. APOLICE' , MO.NUM_ENDOSSO AS 'MOV. ENDOSSO' , MO.NUM_PARCELA AS 'MOV. PARCELA' , MO.SITUACAO_COBRANCA AS 'MOV. SITUACAO COBRANCA' , CASE MO.SITUACAO_COBRANCA WHEN ' ' THEN 'PEND. ENVIO 1                     ' WHEN '0' THEN 'PEND. ENVIO 2                     ' WHEN '1' THEN 'PEND. RETORNO                     ' WHEN '2' THEN 'CRD/DEB EFETUADO C/ SUCESSO       ' WHEN '3' THEN 'CRD/DEB NAO EFETUADO              ' WHEN '4' THEN 'CANCELADO A PEDIDO DO GCX AO BANCO' WHEN '6' THEN 'CRD C/ NAO EFETUADO - GERADO CHQ. ' END AS 'MOV. NOME SITUACAO COBRANCA' , MO.DATA_VENCIMENTO AS 'MOV. DATA CREDITO' , MO.DATA_MOVIMENTO AS 'MOV. DT. GERACAO MOVDEBCC' , MO.COD_AGENCIA_DEB AS 'MOV. AGENCIA' , MO.OPER_CONTA_DEB AS 'MOV. OPER CONTA' , MO.NUM_CONTA_DEB AS 'MOV. NUM. CONTA' , MO.DIG_CONTA_DEB AS 'MOV. DV CONTA' , MO.COD_CONVENIO AS 'MOV.CONVENIO' , MO.DATA_ENVIO AS 'MOV. DT. ENVIO SIAS P/ SAP' , MO.NSAS AS 'MOV. NSAS' , MO.NUM_REQUISICAO AS 'MOV. NUM. CHQ. INTERNO' , CONTA.COD_AGENCIA AS 'CONTA COD AGENCIA' , CONTA.COD_BANCO AS 'CONTA BANCO' , CONTA.NUM_CONTA_CNB AS 'CONTA NUM. CONTA' , CONTA.NUM_DV_CONTA_CNB AS 'CONTA DV CONTA' , CONTA.IND_CONTA_BANCARIA AS 'CONTA ACHO QUE OPERACAO CONTA' , PRO.COD_EMPRESA AS 'CODG EMPRESA' FROM SEGUROS.SISTEMAS SIS, SEGUROS.SINISTRO_HISTORICO H, SEGUROS.SINISTRO_MESTRE M, SEGUROS.SINISTRO_HISTORICO H1, SEGUROS.SI_SINI_CHEQUE SC, SEGUROS.GE_OPERACAO OPE, SEGUROS.PRODUTO PRO, SEGUROS.MOVTO_DEBITOCC_CEF MO LEFT JOIN SEGUROS.GE_MOVTO_CONTA CONTA ON CONTA.NUM_APOLICE = MO.NUM_APOLICE AND CONTA.NUM_ENDOSSO = MO.NUM_ENDOSSO AND CONTA.NUM_PARCELA = MO.NUM_PARCELA AND CONTA.COD_CONVENIO = MO.COD_CONVENIO AND CONTA.NSAS = MO.NSAS WHERE ( MO.COD_CONVENIO = 43350 AND EXISTS (SELECT 1 FROM SEGUROS.SINISTRO_HISTORICO YY WHERE YY.NUM_APOL_SINISTRO = MO.NUM_APOLICE AND YY.OCORR_HISTORICO = MO.NUM_PARCELA AND YY.COD_OPERACAO = MO.NUM_ENDOSSO - YY.COD_PRODUTO * 10000) ) AND MO.NUM_APOLICE = :LK-SAP-NUM-APOLICE AND MO.NUM_ENDOSSO = :LK-SAP-NUM-ENDOSSO AND MO.NUM_PARCELA = :LK-SAP-NUM-PARCELA AND MO.NSAS = :LK-SAP-NSAS AND MO.SITUACAO_COBRANCA = :LK-SAP-SITUACAO-COBRANCA AND MO.NUM_PARCELA <> 7777 AND MO.NUM_ENDOSSO <> 7777 AND H.NUM_APOL_SINISTRO = MO.NUM_APOLICE AND H.OCORR_HISTORICO = MO.NUM_PARCELA AND H.COD_OPERACAO = MO.NUM_ENDOSSO - H.COD_PRODUTO * 10000 AND H.SIT_REGISTRO = '1' AND H.SIT_CONTABIL IN ( '2' , '7' ) AND SC.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND SC.OCORR_HISTORICO = H.OCORR_HISTORICO AND SC.COD_OPERACAO = H.COD_OPERACAO AND OPE.IDE_SISTEMA = 'SI' AND OPE.COD_OPERACAO = H.COD_OPERACAO AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND PRO.COD_PRODUTO = M.COD_PRODUTO AND H1.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND H1.COD_OPERACAO = 101 AND H1.TIMESTAMP = (SELECT MIN(A.TIMESTAMP) FROM SEGUROS.SINISTRO_HISTORICO A WHERE A.NUM_APOL_SINISTRO = H1.NUM_APOL_SINISTRO AND A.OCORR_HISTORICO = H1.OCORR_HISTORICO AND A.COD_OPERACAO = H1.COD_OPERACAO) AND SIS.IDE_SISTEMA = 'FI' UNION ALL SELECT 'CRED/DEB 3 - 600119, 600120, 600123 - LOTERICO' , H.TIPO_REGISTRO AS 'TIPO SEGURO' , CASE H.TIPO_REGISTRO WHEN '0' THEN 'COSSEGURO ACEITO' WHEN '1' THEN 'NOSSA LIDERANCA ' END AS 'NOME TIPO SEGURO' , H.NUM_APOLICE AS 'NUM APOLICE' , H.NUM_APOL_SINISTRO AS 'NUM SINISTRO' , H.OCORR_HISTORICO AS 'OCORRHIST' , H.COD_OPERACAO AS 'OPERACAO' , H.NOME_FAVORECIDO AS 'NOME FAVORECIDO - HISTSINI' , YEAR(H.DATA_MOVIMENTO) AS 'ANO OPERACIONAL DO PAGAMENTO' , YEAR(SIS.DATA_MOV_ABERTO) AS 'ANO CONTABIL DO PAGAMENTO' , OPE.FUNCAO_OPERACAO AS 'FUNCAO OPERACAO' , SUBSTR(OPE.DES_OPERACAO,1,30) AS 'NOME OPERACAO' , H.VAL_OPERACAO AS 'VALOR BRUTO' , MO.VLR_CREDITO AS 'MOV. VALOR CREDITO' , MO.VALOR_DEBITO AS 'MOV. VALOR DEBITO' , H.DATA_MOVIMENTO AS 'DATA BAIXA PELA TESOURARIA' , H.COD_PREST_SERVICO AS 'COD DA FORNECEDORES' , H.COD_SERVICO AS 'COD DO SERVICO' , H.SIT_CONTABIL AS 'FORMA PAGAMENTO' , CASE H.SIT_CONTABIL WHEN '1' THEN 'CHEQUE PAPEL     ' WHEN '2' THEN 'CREDITO EM CONTA ' WHEN '7' THEN 'SIACC            ' END AS 'NOME FORMA PAGAMENTO' , H.NOM_PROGRAMA AS 'PGM GERADOR' , H.COD_USUARIO AS 'USUARIO QUE BAIXO PAGTO' , M.RAMO AS 'RAMO CXS' , M.COD_FONTE AS 'FONTE' , H1.DATA_MOVIMENTO AS 'DATA AVISO NO SIAS' , M.DATA_COMUNICADO AS 'DATA COMUNICADO NA CXS' , M.COD_PRODUTO AS 'PRODUTO' , PRO.DESCR_PRODUTO AS 'NOME PRODUTO' , 0 AS 'CHQINT' , MO.NUM_APOLICE AS 'MOV. APOLICE' , MO.NUM_ENDOSSO AS 'MOV. ENDOSSO' , MO.NUM_PARCELA AS 'MOV. PARCELA' , MO.SITUACAO_COBRANCA AS 'MOV. SITUACAO COBRANCA' , CASE MO.SITUACAO_COBRANCA WHEN ' ' THEN 'PEND. ENVIO 1                     ' WHEN '0' THEN 'PEND. ENVIO 2                     ' WHEN '1' THEN 'PEND. RETORNO                     ' WHEN '2' THEN 'CRD/DEB EFETUADO C/ SUCESSO       ' WHEN '3' THEN 'CRD/DEB NAO EFETUADO              ' WHEN '4' THEN 'CANCELADO A PEDIDO DO GCX AO BANCO' WHEN '6' THEN 'CRD C/ NAO EFETUADO - GERADO CHQ. ' END AS 'MOV. NOME SITUACAO COBRANCA' , MO.DATA_VENCIMENTO AS 'MOV. DATA CREDITO' , MO.DATA_MOVIMENTO AS 'MOV. DT. GERACAO MOVDEBCC' , MO.COD_AGENCIA_DEB AS 'MOV. AGENCIA' , MO.OPER_CONTA_DEB AS 'MOV. OPER CONTA' , MO.NUM_CONTA_DEB AS 'MOV. NUM. CONTA' , MO.DIG_CONTA_DEB AS 'MOV. DV CONTA' , MO.COD_CONVENIO AS 'MOV.CONVENIO' , MO.DATA_ENVIO AS 'MOV. DT. ENVIO SIAS P/ SAP' , MO.NSAS AS 'MOV. NSAS' , MO.NUM_REQUISICAO AS 'MOV. NUM. CHQ. INTERNO' , CONTA.COD_AGENCIA AS 'CONTA COD AGENCIA' , CONTA.COD_BANCO AS 'CONTA BANCO' , CONTA.NUM_CONTA_CNB AS 'CONTA NUM. CONTA' , CONTA.NUM_DV_CONTA_CNB AS 'CONTA DV CONTA' , CONTA.IND_CONTA_BANCARIA AS 'CONTA ACHO QUE OPERACAO CONTA' , PRO.COD_EMPRESA AS 'CODG EMPRESA' FROM SEGUROS.SISTEMAS SIS, SEGUROS.SINISTRO_HISTORICO H, SEGUROS.SINISTRO_MESTRE M, SEGUROS.SINISTRO_HISTORICO H1, SEGUROS.GE_OPERACAO OPE, SEGUROS.PRODUTO PRO, SEGUROS.MOVTO_DEBITOCC_CEF MO LEFT JOIN SEGUROS.GE_MOVTO_CONTA CONTA ON CONTA.NUM_APOLICE = MO.NUM_APOLICE AND CONTA.NUM_ENDOSSO = MO.NUM_ENDOSSO AND CONTA.NUM_PARCELA = MO.NUM_PARCELA AND CONTA.COD_CONVENIO = MO.COD_CONVENIO AND CONTA.NSAS = MO.NSAS WHERE ( MO.COD_CONVENIO IN (600119 , 600120 , 600123) ) AND MO.NUM_APOLICE = :LK-SAP-NUM-APOLICE AND MO.NUM_ENDOSSO = :LK-SAP-NUM-ENDOSSO AND MO.NUM_PARCELA = :LK-SAP-NUM-PARCELA AND MO.NSAS = :LK-SAP-NSAS AND MO.SITUACAO_COBRANCA = :LK-SAP-SITUACAO-COBRANCA AND H.NUM_APOL_SINISTRO = MO.NUM_APOLICE AND H.OCORR_HISTORICO = MO.NUM_PARCELA AND H.COD_OPERACAO = MO.NUM_ENDOSSO - H.COD_PRODUTO * 10000 AND H.SIT_REGISTRO IN ( '1' , '8' ) AND H.SIT_CONTABIL IN ( '2' , '7' ) AND OPE.IDE_SISTEMA = 'SI' AND OPE.COD_OPERACAO = H.COD_OPERACAO AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND PRO.COD_PRODUTO = M.COD_PRODUTO AND H1.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND H1.COD_OPERACAO = 101 AND H1.TIMESTAMP = (SELECT MIN(A.TIMESTAMP) FROM SEGUROS.SINISTRO_HISTORICO A WHERE A.NUM_APOL_SINISTRO = H1.NUM_APOL_SINISTRO AND A.OCORR_HISTORICO = H1.OCORR_HISTORICO AND A.COD_OPERACAO = H1.COD_OPERACAO) AND SIS.IDE_SISTEMA = 'FI' ORDER BY 5,6,7 WITH UR END-EXEC. */
            LE_MOVDEBCE = new SISAP01B_LE_MOVDEBCE(true);
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
							AND MO.NUM_APOLICE = '{REGISTRO_LINKAGE_SAP.LK_SAP_NUM_APOLICE}' 
							AND MO.NUM_ENDOSSO = '{REGISTRO_LINKAGE_SAP.LK_SAP_NUM_ENDOSSO}' 
							AND MO.NUM_PARCELA = '{REGISTRO_LINKAGE_SAP.LK_SAP_NUM_PARCELA}' 
							AND MO.NSAS = '{REGISTRO_LINKAGE_SAP.LK_SAP_NSAS}' 
							AND MO.SITUACAO_COBRANCA = '{REGISTRO_LINKAGE_SAP.LK_SAP_SITUACAO_COBRANCA}' 
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
							AND MO.NUM_APOLICE = '{REGISTRO_LINKAGE_SAP.LK_SAP_NUM_APOLICE}' 
							AND MO.NUM_ENDOSSO = '{REGISTRO_LINKAGE_SAP.LK_SAP_NUM_ENDOSSO}' 
							AND MO.NUM_PARCELA = '{REGISTRO_LINKAGE_SAP.LK_SAP_NUM_PARCELA}' 
							AND MO.NSAS = '{REGISTRO_LINKAGE_SAP.LK_SAP_NSAS}' 
							AND MO.SITUACAO_COBRANCA = '{REGISTRO_LINKAGE_SAP.LK_SAP_SITUACAO_COBRANCA}' 
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
							AND MO.NUM_APOLICE = '{REGISTRO_LINKAGE_SAP.LK_SAP_NUM_APOLICE}' 
							AND MO.NUM_ENDOSSO = '{REGISTRO_LINKAGE_SAP.LK_SAP_NUM_ENDOSSO}' 
							AND MO.NUM_PARCELA = '{REGISTRO_LINKAGE_SAP.LK_SAP_NUM_PARCELA}' 
							AND MO.NSAS = '{REGISTRO_LINKAGE_SAP.LK_SAP_NSAS}' 
							AND MO.SITUACAO_COBRANCA = '{REGISTRO_LINKAGE_SAP.LK_SAP_SITUACAO_COBRANCA}' 
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
            /*" -2667- EXEC SQL OPEN LE_MOVDEBCE END-EXEC. */

            LE_MOVDEBCE.Open();

        }

        [StopWatch]
        /*" R4000-DECLARE-IMPOSTOS-DB-DECLARE-1 */
        public void R4000_DECLARE_IMPOSTOS_DB_DECLARE_1()
        {
            /*" -4897- EXEC SQL DECLARE IMPOSTOS CURSOR FOR SELECT H.NUM_APOL_SINISTRO, H.OCORR_HISTORICO, H.COD_OPERACAO, A.NUM_DOCF_INTERNO, C.COD_TP_LANCDOCF AS 'COD LANC DA NOTA FISCAL' , Y.ABREV_LANCDOCF AS 'NOME LANC DA NOTA FISCAL' , C.VALOR_LANCAMENTO AS 'VALOR LANC NOTA FISCAL' , NOM_IMP.COD_IMP_INTERNO AS 'COD IMPOSTO' , NOM_IMP.SIGLA_IMP AS 'NOME IMPOSTO' , IMP.ALIQ_TRIBUTACAO AS 'ALIQUOTA IMPOSTO' , IMP.VALOR_IMPOSTO AS 'VALOR IMPOSTO' , IMP.COD_IMPOSTO_SAP FROM SEGUROS.SINISTRO_HISTORICO H , SEGUROS.SI_PAGA_DOC_FISCAL A , SEGUROS.FI_PAGA_DOC_FISCAL F , SEGUROS.FI_PAGA_DOCF_LANC C , SEGUROS.GE_TP_LANC_DOCF Y , SEGUROS.FI_PAGA_DOCF_IMP IMP , SEGUROS.GE_TIPO_IMPOSTO NOM_IMP WHERE A.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND A.OCORR_HISTORICO = H.OCORR_HISTORICO AND A.COD_OPERACAO = H.COD_OPERACAO AND C.NUM_DOCF_INTERNO = A.NUM_DOCF_INTERNO AND C.VALOR_LANCAMENTO <> 0 AND Y.COD_TP_LANCDOCF = C.COD_TP_LANCDOCF AND Y.DT_INIVIG_LANCDOCF = C.DT_INIVIG_LANCDOCF AND IMP.NUM_DOCF_INTERNO = C.NUM_DOCF_INTERNO AND IMP.COD_TP_LANCDOCF = C.COD_TP_LANCDOCF AND IMP.DT_INIVIG_LANCDOCF = C.DT_INIVIG_LANCDOCF AND NOM_IMP.COD_IMP_INTERNO = IMP.COD_IMP_INTERNO AND NOM_IMP.DATA_INIVIG_IMP = IMP.DATA_INIVIG_IMP AND H.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND H.OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND F.NUM_DOCF_INTERNO = A.NUM_DOCF_INTERNO AND IMP.VALOR_IMPOSTO <> 0 END-EXEC. */
            IMPOSTOS = new SISAP01B_IMPOSTOS(true);
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
            /*" -2728- PERFORM R0101_FETCH_MOVDEBCE_DB_FETCH_1 */

            R0101_FETCH_MOVDEBCE_DB_FETCH_1();

            /*" -2731- IF W-AC-LIDOS-MOVDEBCE EQUAL 0 AND SQLCODE EQUAL 100 */

            if (AREA_DE_WORK.W_AC_LIDOS_MOVDEBCE == 0 && DB.SQLCODE == 100)
            {

                /*" -2732- DISPLAY ' ' */
                _.Display($" ");

                /*" -2733- DISPLAY ' ' */
                _.Display($" ");

                /*" -2734- DISPLAY '********************************************' */
                _.Display($"********************************************");

                /*" -2735- DISPLAY '*                                          *' */
                _.Display($"*                                          *");

                /*" -2736- DISPLAY '*          SUB-ROTINA - SISAP01B           *' */
                _.Display($"*          SUB-ROTINA - SISAP01B           *");

                /*" -2737- DISPLAY '*                                          *' */
                _.Display($"*                                          *");

                /*" -2738- DISPLAY '* ERRO NA DEFINICAO DO PROGRAMA            *' */
                _.Display($"* ERRO NA DEFINICAO DO PROGRAMA            *");

                /*" -2739- DISPLAY '*                                          *' */
                _.Display($"*                                          *");

                /*" -2740- DISPLAY '* PROGRAMA CANCELADO                       *' */
                _.Display($"* PROGRAMA CANCELADO                       *");

                /*" -2741- DISPLAY '*                                          *' */
                _.Display($"*                                          *");

                /*" -2742- DISPLAY '* NAO FOI ENCONTRADO REGISTRO NA NA TABELA *' */
                _.Display($"* NAO FOI ENCONTRADO REGISTRO NA NA TABELA *");

                /*" -2743- DISPLAY '* MOVTO_DEBITOCC_CEF                       *' */
                _.Display($"* MOVTO_DEBITOCC_CEF                       *");

                /*" -2744- DISPLAY '*                                          *' */
                _.Display($"*                                          *");

                /*" -2745- DISPLAY '* CHAVE DA MOVTO_DEBITOCC_CEF:             *' */
                _.Display($"* CHAVE DA MOVTO_DEBITOCC_CEF:             *");

                /*" -2746- DISPLAY '*                                          *' */
                _.Display($"*                                          *");

                /*" -2747- DISPLAY '* NUM_APOLICE: ' LK-SAP-NUM-APOLICE */
                _.Display($"* NUM_APOLICE: {REGISTRO_LINKAGE_SAP.LK_SAP_NUM_APOLICE}");

                /*" -2748- DISPLAY '* NUM_ENDOSSO: ' LK-SAP-NUM-ENDOSSO */
                _.Display($"* NUM_ENDOSSO: {REGISTRO_LINKAGE_SAP.LK_SAP_NUM_ENDOSSO}");

                /*" -2749- DISPLAY '* NUM_PARCELA: ' LK-SAP-NUM-PARCELA */
                _.Display($"* NUM_PARCELA: {REGISTRO_LINKAGE_SAP.LK_SAP_NUM_PARCELA}");

                /*" -2750- DISPLAY '* NSAS       : ' LK-SAP-NSAS */
                _.Display($"* NSAS       : {REGISTRO_LINKAGE_SAP.LK_SAP_NSAS}");

                /*" -2752- DISPLAY '* SITUACAO_COBRANCA: ' LK-SAP-SITUACAO-COBRANCA */
                _.Display($"* SITUACAO_COBRANCA: {REGISTRO_LINKAGE_SAP.LK_SAP_SITUACAO_COBRANCA}");

                /*" -2753- DISPLAY 'W-AC-LIDOS-MOVDEBCE - ' W-AC-LIDOS-MOVDEBCE */
                _.Display($"W-AC-LIDOS-MOVDEBCE - {AREA_DE_WORK.W_AC_LIDOS_MOVDEBCE}");

                /*" -2754- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -2755- DISPLAY '*                                          *' */
                _.Display($"*                                          *");

                /*" -2756- DISPLAY '********************************************' */
                _.Display($"********************************************");

                /*" -2757- DISPLAY ' ' */
                _.Display($" ");

                /*" -2758- MOVE '1' TO LK-SAP-COD-RETORNO */
                _.Move("1", LK_SAP_COD_RETORNO);

                /*" -2760- MOVE 'NAO FOI ENCONTRADO REG. NA MOVTO_DEBITOCC_CEF' TO LK-SAP-MENSAGEM-RETORNO */
                _.Move("NAO FOI ENCONTRADO REG. NA MOVTO_DEBITOCC_CEF", LK_SAP_MENSAGEM_RETORNO);

                /*" -2760- PERFORM R0101_FETCH_MOVDEBCE_DB_CLOSE_1 */

                R0101_FETCH_MOVDEBCE_DB_CLOSE_1();

                /*" -2770- GO TO RXXXX-ROTINA-RETORNO. */

                RXXXX_ROTINA_RETORNO(); //GOTO
                return;
            }


            /*" -2771- MOVE 'NAO' TO W-CHAVE-EH-PRESTADOR. */
            _.Move("NAO", AREA_DE_WORK.W_CHAVE_EH_PRESTADOR);

            /*" -2772- IF SQLCODE EQUAL 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -2774- IF (SINISHIS-COD-PREST-SERVICO NOT EQUAL 0) AND (SINISHIS-COD-SERVICO NOT EQUAL 95) */

                if ((SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO != 0) && (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_SERVICO != 95))
                {

                    /*" -2776- MOVE 'SIM' TO W-CHAVE-EH-PRESTADOR. */
                    _.Move("SIM", AREA_DE_WORK.W_CHAVE_EH_PRESTADOR);
                }

            }


            /*" -2778- IF SQLCODE EQUAL 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -2780- ADD 1 TO W-AC-LIDOS-MOVDEBCE . */
                AREA_DE_WORK.W_AC_LIDOS_MOVDEBCE.Value = AREA_DE_WORK.W_AC_LIDOS_MOVDEBCE + 1;
            }


            /*" -2781- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2781- PERFORM R0101_FETCH_MOVDEBCE_DB_CLOSE_2 */

                R0101_FETCH_MOVDEBCE_DB_CLOSE_2();

                /*" -2783- MOVE 'SIM' TO WFIM-LE-MOVDEBCE-1 */
                _.Move("SIM", AREA_DE_WORK.WFIM_LE_MOVDEBCE_1);

                /*" -2785- GO TO R0101-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0101_EXIT*/ //GOTO
                return;
            }


            /*" -2786- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -2787- DISPLAY 'SISAP01B - ERRO NO FETCH CURSOR LE_MOVDEBCE(1)' */
                _.Display($"SISAP01B - ERRO NO FETCH CURSOR LE_MOVDEBCE(1)");

                /*" -2787- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0101-FETCH-MOVDEBCE-DB-FETCH-1 */
        public void R0101_FETCH_MOVDEBCE_DB_FETCH_1()
        {
            /*" -2728- EXEC SQL FETCH LE_MOVDEBCE INTO :W-NOME-QUERY, :SINISHIS-TIPO-REGISTRO, :W-NOME-TIPO-SEGURO, :SINISHIS-NUM-APOLICE, :SINISHIS-NUM-APOL-SINISTRO, :SINISHIS-OCORR-HISTORICO, :SINISHIS-COD-OPERACAO, :SINISHIS-NOME-FAVORECIDO, :W-ANO-OPERACIONAL-MOVIMENTO, :W-ANO-CONTABIL-MOVIMENTO, :GEOPERAC-FUNCAO-OPERACAO, :GEOPERAC-DES-OPERACAO, :SINISHIS-VAL-OPERACAO, :MOVDEBCE-VLR-CREDITO, :MOVDEBCE-VALOR-DEBITO, :SINISHIS-DATA-MOVIMENTO, :SINISHIS-COD-PREST-SERVICO, :SINISHIS-COD-SERVICO, :SINISHIS-SIT-CONTABIL, :W-NOME-FORMA-PAGAMENTO, :SINISHIS-NOM-PROGRAMA:NULL-NOM-PROGRAMA, :SINISHIS-COD-USUARIO, :SINISMES-RAMO, :SINISMES-COD-FONTE, :W-DATA-AVISO-SIAS, :SINISMES-DATA-COMUNICADO, :SINISMES-COD-PRODUTO, :PRODUTO-DESCR-PRODUTO, :CHEQUEMI-NUM-CHEQUE-INTERNO, :MOVDEBCE-NUM-APOLICE, :MOVDEBCE-NUM-ENDOSSO, :MOVDEBCE-NUM-PARCELA, :MOVDEBCE-SITUACAO-COBRANCA, :W-NOME-SITUACAO-COBRANCA, :MOVDEBCE-DATA-VENCIMENTO, :MOVDEBCE-DATA-MOVIMENTO, :MOVDEBCE-COD-AGENCIA-DEB, :MOVDEBCE-OPER-CONTA-DEB, :MOVDEBCE-NUM-CONTA-DEB, :MOVDEBCE-DIG-CONTA-DEB, :MOVDEBCE-COD-CONVENIO, :MOVDEBCE-DATA-ENVIO, :MOVDEBCE-NSAS, :MOVDEBCE-NUM-REQUISICAO, :GE369-COD-AGENCIA:NULL-COD-AGENCIA, :GE369-COD-BANCO:NULL-COD-BANCO, :GE369-NUM-CONTA-CNB:NULL-NUM-CONTA-CNB, :GE369-NUM-DV-CONTA-CNB:NULL-NUM-DV-CONTA-CNB, :GE369-IND-CONTA-BANCARIA:NULL-IND-CONTA-BANCARIA ,:PRODUTO-COD-EMPRESA END-EXEC. */

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
            /*" -2760- EXEC SQL CLOSE LE_MOVDEBCE END-EXEC */

            LE_MOVDEBCE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0101_EXIT*/

        [StopWatch]
        /*" R0101-FETCH-MOVDEBCE-DB-CLOSE-2 */
        public void R0101_FETCH_MOVDEBCE_DB_CLOSE_2()
        {
            /*" -2781- EXEC SQL CLOSE LE_MOVDEBCE END-EXEC */

            LE_MOVDEBCE.Close();

        }

        [StopWatch]
        /*" R0200-PROCESSA-PRINCIPAL */
        private void R0200_PROCESSA_PRINCIPAL(bool isPerform = false)
        {
            /*" -2795- PERFORM R19200-SELECT-REINF THRU R19200-EXIT. */

            R19200_SELECT_REINF(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R19200_EXIT*/


            /*" -2799- MOVE ZEROS TO W-NUM-CPF-NUM W-NUM-CNPJ-NUM. */
            _.Move(0, W_NUM_CPF_NUM, W_NUM_CNPJ_NUM);

            /*" -2804- MOVE SPACES TO W-CHAVE-ORIGEM-CADASTRO. */
            _.Move("", AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO);

            /*" -2806- MOVE 'XX' TO W-CHAVE-TIPO-PESSOA-PF-PJ. */
            _.Move("XX", AREA_DE_WORK.W_CHAVE_TIPO_PESSOA_PF_PJ);

            /*" -2808- PERFORM R2000-CADASTRAIS-ODS THRU R2000-EXIT. */

            R2000_CADASTRAIS_ODS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_EXIT*/


            /*" -2809- IF W-CHAVE-ORIGEM-CADASTRO EQUAL 'ODS' */

            if (AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO == "ODS")
            {

                /*" -2811- GO TO R0200-MONTA-REGISTRO . */

                R0200_MONTA_REGISTRO(); //GOTO
                return;
            }


            /*" -2813- INITIALIZE DCLFORNECEDORES. */
            _.Initialize(
                FORNECED.DCLFORNECEDORES
            );

            /*" -2815- PERFORM R2010-CADASTRAIS-LOTERICO THRU R2010-EXIT. */

            R2010_CADASTRAIS_LOTERICO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R2010_EXIT*/


            /*" -2816- IF W-CHAVE-ORIGEM-CADASTRO EQUAL 'FORNECEDOR OU LOTERICO' */

            if (AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO == "FORNECEDOR OU LOTERICO")
            {

                /*" -2818- GO TO R0200-MONTA-REGISTRO . */

                R0200_MONTA_REGISTRO(); //GOTO
                return;
            }


            /*" -2820- PERFORM R2020-CADASTRAIS-FORNECED THRU R2020-EXIT. */

            R2020_CADASTRAIS_FORNECED(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R2020_EXIT*/


            /*" -2821- IF W-CHAVE-ORIGEM-CADASTRO EQUAL 'FORNECEDOR OU LOTERICO' */

            if (AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO == "FORNECEDOR OU LOTERICO")
            {

                /*" -2822- GO TO R0200-MONTA-REGISTRO */

                R0200_MONTA_REGISTRO(); //GOTO
                return;

                /*" -2823- ELSE */
            }
            else
            {


                /*" -2823- MOVE 'SEM CADASTRO' TO W-CHAVE-ORIGEM-CADASTRO. */
                _.Move("SEM CADASTRO", AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO);
            }


        }

        [StopWatch]
        /*" R0200-MONTA-REGISTRO */
        private void R0200_MONTA_REGISTRO(bool isPerform = false)
        {
            /*" -2829- PERFORM R3000-MONTA-REGISTRO THRU R3000-EXIT. */

            R3000_MONTA_REGISTRO(true);

            R3000_GRAVA_REGISTRO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_EXIT*/


            /*" -2831- PERFORM R19000-GE0306B-GRAVA-CONTROLES THRU R19000-EXIT. */

            R19000_GE0306B_GRAVA_CONTROLES(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R19000_EXIT*/


            /*" -2831- PERFORM R0101-FETCH-MOVDEBCE THRU R0101-EXIT. */

            R0101_FETCH_MOVDEBCE(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R0101_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_EXIT*/

        [StopWatch]
        /*" R3000-MONTA-REGISTRO */
        private void R3000_MONTA_REGISTRO(bool isPerform = false)
        {
            /*" -2839- INITIALIZE W-REGISTRO-SIAS-GERAL. */
            _.Initialize(
                W_REGISTRO_SIAS_GERAL
            );

            /*" -2843- MOVE 01 TO TIPOREG-GERAL */
            _.Move(01, W_REGISTRO_SIAS_GERAL.TIPOREG_GERAL);

            /*" -2850- IF (MOVDEBCE-COD-CONVENIO EQUAL 600119 OR 600120 OR 600123) AND (SINISHIS-COD-OPERACAO EQUAL 1070 OR 1071 OR 1072 OR 1073 OR 1074 OR 1030 OR 1040 OR 4000) */

            if ((MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.In("600119", "600120", "600123")) && (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.In("1070", "1071", "1072", "1073", "1074", "1030", "1040", "4000")))
            {

                /*" -2851- IF SINISHIS-VAL-OPERACAO > 0 */

                if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO > 0)
                {

                    /*" -2852- MOVE 'IND' TO GEOPERAC-FUNCAO-OPERACAO */
                    _.Move("IND", GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO);

                    /*" -2853- ELSE */
                }
                else
                {


                    /*" -2854- MOVE 'EIND' TO GEOPERAC-FUNCAO-OPERACAO */
                    _.Move("EIND", GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO);

                    /*" -2856- COMPUTE SINISHIS-VAL-OPERACAO = SINISHIS-VAL-OPERACAO * -1 */
                    SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO.Value = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO * -1;

                    /*" -2857- END-IF */
                }


                /*" -2858- IF SINISHIS-COD-OPERACAO EQUAL 4000 */

                if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO == 4000)
                {

                    /*" -2859- MOVE 'RSPPR' TO GEOPERAC-FUNCAO-OPERACAO */
                    _.Move("RSPPR", GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO);

                    /*" -2860- END-IF */
                }


                /*" -2864- END-IF */
            }


            /*" -2868- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'EIND' OR 'RSPPR' */

            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO.In("EIND", "RSPPR"))
            {

                /*" -2871- PERFORM C0010-CHAMA-SISAP15B THRU C0010-CHAMA-SISAP15B-EXIT */

                C0010_CHAMA_SISAP15B(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: C0010_CHAMA_SISAP15B_EXIT*/


                /*" -2873- END-IF */
            }


            /*" -2876- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'LIB' AND SINISHIS-COD-OPERACAO EQUAL 1081 OR 1082 OR 1083 OR 1084 */

            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "LIB" && SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.In("1081", "1082", "1083", "1084"))
            {

                /*" -2877- MOVE 'LIB@' TO GEOPERAC-FUNCAO-OPERACAO */
                _.Move("LIB@", GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO);

                /*" -2879- END-IF */
            }


            /*" -2881- MOVE 'AP' TO W-LOTE-SIGLA-MODULO */
            _.Move("AP", AREA_DE_WORK.W_LOTE.W_LOTE_SIGLA_MODULO);

            /*" -2882- EVALUATE GEOPERAC-FUNCAO-OPERACAO */
            switch (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO.Value.Trim())
            {

                /*" -2883- WHEN 'LIB@' */
                case "LIB@":

                    /*" -2884- MOVE 'LIB' TO GEOPERAC-FUNCAO-OPERACAO */
                    _.Move("LIB", GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO);

                    /*" -2885- MOVE 'S101' TO ORIG-GERAL */
                    _.Move("S101", W_REGISTRO_SIAS_GERAL.ORIG_GERAL);

                    /*" -2886- WHEN 'IND' */
                    break;
                case "IND":

                    /*" -2887- MOVE 'S101' TO ORIG-GERAL */
                    _.Move("S101", W_REGISTRO_SIAS_GERAL.ORIG_GERAL);

                    /*" -2888- WHEN 'DPAG' */
                    break;
                case "DPAG":

                /*" -2889- WHEN 'HPAG' */
                case "HPAG":

                    /*" -2890- MOVE 'S104' TO ORIG-GERAL */
                    _.Move("S104", W_REGISTRO_SIAS_GERAL.ORIG_GERAL);

                    /*" -2891- WHEN 'DSPAG' */
                    break;
                case "DSPAG":

                /*" -2892- WHEN 'HSPAG' */
                case "HSPAG":

                    /*" -2893- WHEN 'RSHOP' */
                    break;
                case "RSHOP":

                /*" -2894- WHEN 'RSDEP' */
                case "RSDEP":

                    /*" -2895- WHEN 'RSREP' */
                    break;
                case "RSREP":

                    /*" -2896- MOVE 'S109' TO ORIG-GERAL */
                    _.Move("S109", W_REGISTRO_SIAS_GERAL.ORIG_GERAL);

                    /*" -2897- WHEN 'JBIND' */
                    break;
                case "JBIND":

                /*" -2898- WHEN 'JBDES' */
                case "JBDES":

                    /*" -2899- WHEN 'JBHON' */
                    break;
                case "JBHON":

                    /*" -2900- MOVE 'S100' TO ORIG-GERAL */
                    _.Move("S100", W_REGISTRO_SIAS_GERAL.ORIG_GERAL);

                    /*" -2901- WHEN 'JBDP' */
                    break;
                case "JBDP":

                    /*" -2902- MOVE 'S110' TO ORIG-GERAL */
                    _.Move("S110", W_REGISTRO_SIAS_GERAL.ORIG_GERAL);

                    /*" -2903- WHEN OTHER */
                    break;
                default:

                    /*" -2904- MOVE 'S???' TO ORIG-GERAL */
                    _.Move("S???", W_REGISTRO_SIAS_GERAL.ORIG_GERAL);

                    /*" -2908- END-EVALUATE */
                    break;
            }


            /*" -2909- MOVE LK-SAP-COD-PROGRAMA TO W-LOTE-NOME-PROGRAMA */
            _.Move(LK_SAP_COD_PROGRAMA, AREA_DE_WORK.W_LOTE.W_LOTE_NOME_PROGRAMA);

            /*" -2910- IF W-LOTE-PROGRAMA-FILLER EQUAL ' ' */

            if (AREA_DE_WORK.W_LOTE.W_LOTE_NOME_PROGRAMA.W_LOTE_PROGRAMA_FILLER == " ")
            {

                /*" -2911- MOVE 'X' TO W-LOTE-PROGRAMA-FILLER. */
                _.Move("X", AREA_DE_WORK.W_LOTE.W_LOTE_NOME_PROGRAMA.W_LOTE_PROGRAMA_FILLER);
            }


            /*" -2919- MOVE W-LOTE TO LOTE-GERAL. */
            _.Move(AREA_DE_WORK.W_LOTE, W_REGISTRO_SIAS_GERAL.LOTE_GERAL);

            /*" -2923- MOVE 999999999 TO LOTEIT-GERAL. */
            _.Move(999999999, W_REGISTRO_SIAS_GERAL.LOTEIT_GERAL);

            /*" -2924- MOVE 'S' TO W-IDLG-SINISTRO */
            _.Move("S", AREA_DE_WORK.W_IDLG_SIAS_SINISTRO.W_IDLG_SINISTRO);

            /*" -2925- MOVE SINISHIS-NUM-APOL-SINISTRO TO W-IDLG-NUM-APOL-SINISTRO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, AREA_DE_WORK.W_IDLG_SIAS_SINISTRO.W_IDLG_NUM_APOL_SINISTRO);

            /*" -2926- MOVE SINISHIS-OCORR-HISTORICO TO W-IDLG-OCORR-HISTORICO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO, AREA_DE_WORK.W_IDLG_SIAS_SINISTRO.W_IDLG_OCORR_HISTORICO);

            /*" -2928- MOVE SINISHIS-COD-OPERACAO TO W-IDLG-COD-OPERACAO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO, AREA_DE_WORK.W_IDLG_SIAS_SINISTRO.W_IDLG_COD_OPERACAO);

            /*" -2929- IF MOVDEBCE-VLR-CREDITO NOT EQUAL 0 */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_CREDITO != 0)
            {

                /*" -2930- MOVE 'P' TO W-IDLG-TIPO-MOVIMENTO */
                _.Move("P", AREA_DE_WORK.W_IDLG_SIAS_SINISTRO.W_IDLG_TIPO_MOVIMENTO);

                /*" -2931- ELSE */
            }
            else
            {


                /*" -2932- IF MOVDEBCE-VALOR-DEBITO NOT EQUAL 0 */

                if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO != 0)
                {

                    /*" -2933- MOVE 'R' TO W-IDLG-TIPO-MOVIMENTO */
                    _.Move("R", AREA_DE_WORK.W_IDLG_SIAS_SINISTRO.W_IDLG_TIPO_MOVIMENTO);

                    /*" -2934- ELSE */
                }
                else
                {


                    /*" -2938- MOVE '?' TO W-IDLG-TIPO-MOVIMENTO. */
                    _.Move("?", AREA_DE_WORK.W_IDLG_SIAS_SINISTRO.W_IDLG_TIPO_MOVIMENTO);
                }

            }


            /*" -2940- MOVE '2' TO W-IDLG-FORMA-PAGAMENTO. */
            _.Move("2", AREA_DE_WORK.W_IDLG_SIAS_SINISTRO.W_IDLG_FORMA_PAGAMENTO);

            /*" -2942- MOVE MOVDEBCE-NSAS TO W-IDLG-NSAS */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS, AREA_DE_WORK.W_IDLG_SIAS_SINISTRO.W_IDLG_COMPLEMENTO_2.W_IDLG_NSAS);

            /*" -2946- MOVE W-IDLG-SIAS-SINISTRO TO IDLG-GERAL. */
            _.Move(AREA_DE_WORK.W_IDLG_SIAS_SINISTRO, W_REGISTRO_SIAS_GERAL.IDLG_GERAL);

            /*" -2950- MOVE SPACES TO JANELA-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.JANELA_GERAL);

            /*" -2954- MOVE W-ANO-CONTABIL-MOVIMENTO TO ANPRO-GERAL. */
            _.Move(W_ANO_CONTABIL_MOVIMENTO, W_REGISTRO_SIAS_GERAL.ANPRO_GERAL);

            /*" -2955- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'EIND' */

            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "EIND")
            {

                /*" -2956- MOVE 'SIAS_09504' TO CODOPE-GERAL */
                _.Move("SIAS_09504", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);

                /*" -2957- ELSE */
            }
            else
            {


                /*" -2958- IF SINISMES-RAMO NOT EQUAL 66 */

                if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO != 66)
                {

                    /*" -2959- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'IND' */

                    if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "IND")
                    {

                        /*" -2960- MOVE 'SIAS_09001' TO CODOPE-GERAL */
                        _.Move("SIAS_09001", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);

                        /*" -2961- ELSE */
                    }
                    else
                    {


                        /*" -2964- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'LIB' AND SINISHIS-COD-OPERACAO EQUAL 1081 OR 1082 OR 1083 OR 1084 */

                        if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "LIB" && SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.In("1081", "1082", "1083", "1084"))
                        {

                            /*" -2965- MOVE 'SIAS_09001' TO CODOPE-GERAL */
                            _.Move("SIAS_09001", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);

                            /*" -2966- ELSE */
                        }
                        else
                        {


                            /*" -2967- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'DPAG' */

                            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "DPAG")
                            {

                                /*" -2968- MOVE 'SIAS_09023' TO CODOPE-GERAL */
                                _.Move("SIAS_09023", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);

                                /*" -2969- ELSE */
                            }
                            else
                            {


                                /*" -2970- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'DSPAG' */

                                if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "DSPAG")
                                {

                                    /*" -2971- MOVE 'SIAS_09011' TO CODOPE-GERAL */
                                    _.Move("SIAS_09011", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);

                                    /*" -2972- ELSE */
                                }
                                else
                                {


                                    /*" -2973- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'HSPAG' */

                                    if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "HSPAG")
                                    {

                                        /*" -2974- MOVE 'SIAS_09012' TO CODOPE-GERAL */
                                        _.Move("SIAS_09012", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);

                                        /*" -2975- ELSE */
                                    }
                                    else
                                    {


                                        /*" -2976- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'RSHOP' */

                                        if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "RSHOP")
                                        {

                                            /*" -2977- MOVE 'SIAS_09013' TO CODOPE-GERAL */
                                            _.Move("SIAS_09013", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);

                                            /*" -2978- ELSE */
                                        }
                                        else
                                        {


                                            /*" -2979- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'RSDEP' */

                                            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "RSDEP")
                                            {

                                                /*" -2980- MOVE 'SIAS_09024' TO CODOPE-GERAL */
                                                _.Move("SIAS_09024", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);

                                                /*" -2981- ELSE */
                                            }
                                            else
                                            {


                                                /*" -2982- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'RSREP' */

                                                if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "RSREP")
                                                {

                                                    /*" -2983- MOVE 'SIAS_09005' TO CODOPE-GERAL */
                                                    _.Move("SIAS_09005", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);

                                                    /*" -2984- ELSE */
                                                }
                                                else
                                                {


                                                    /*" -2985- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'JBIND' */

                                                    if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "JBIND")
                                                    {

                                                        /*" -2986- IF SINISHIS-COD-OPERACAO EQUAL 8206 */

                                                        if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO == 8206)
                                                        {

                                                            /*" -2987- MOVE 'SIAS_09002' TO CODOPE-GERAL */
                                                            _.Move("SIAS_09002", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);

                                                            /*" -2988- ELSE */
                                                        }
                                                        else
                                                        {


                                                            /*" -2989- MOVE 'SIAS_09003' TO CODOPE-GERAL */
                                                            _.Move("SIAS_09003", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);

                                                            /*" -2990- END-IF */
                                                        }


                                                        /*" -2991- ELSE */
                                                    }
                                                    else
                                                    {


                                                        /*" -2992- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'JBDP' */

                                                        if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "JBDP")
                                                        {

                                                            /*" -2993- MOVE 'SIAS_09004' TO CODOPE-GERAL */
                                                            _.Move("SIAS_09004", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);

                                                            /*" -2994- ELSE */
                                                        }
                                                        else
                                                        {


                                                            /*" -2995- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'JBDES' */

                                                            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "JBDES")
                                                            {

                                                                /*" -2996- MOVE 'SIAS_09022' TO CODOPE-GERAL */
                                                                _.Move("SIAS_09022", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);

                                                                /*" -2997- ELSE */
                                                            }
                                                            else
                                                            {


                                                                /*" -2998- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'JBHON' */

                                                                if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "JBHON")
                                                                {

                                                                    /*" -2999- MOVE 'SIAS_09009' TO CODOPE-GERAL */
                                                                    _.Move("SIAS_09009", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);

                                                                    /*" -3000- ELSE */
                                                                }
                                                                else
                                                                {


                                                                    /*" -3002- MOVE 'SIAS_01???' TO CODOPE-GERAL. */
                                                                    _.Move("SIAS_01???", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);
                                                                }

                                                            }

                                                        }

                                                    }

                                                }

                                            }

                                        }

                                    }

                                }

                            }

                        }

                    }

                }

            }


            /*" -3004- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'RSPPR' */

            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "RSPPR")
            {

                /*" -3005- MOVE 'SIAS_09515' TO CODOPE-GERAL */
                _.Move("SIAS_09515", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);

                /*" -3009- END-IF */
            }


            /*" -3010- IF SINISMES-RAMO EQUAL 66 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO == 66)
            {

                /*" -3011- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'JBIND' */

                if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "JBIND")
                {

                    /*" -3012- IF SINISHIS-COD-OPERACAO EQUAL 8206 */

                    if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO == 8206)
                    {

                        /*" -3013- MOVE 'SIAS_09006' TO CODOPE-GERAL */
                        _.Move("SIAS_09006", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);

                        /*" -3014- ELSE */
                    }
                    else
                    {


                        /*" -3015- MOVE 'SIAS_09008' TO CODOPE-GERAL */
                        _.Move("SIAS_09008", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);

                        /*" -3016- END-IF */
                    }


                    /*" -3017- ELSE */
                }
                else
                {


                    /*" -3018- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'JBDP' */

                    if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "JBDP")
                    {

                        /*" -3019- MOVE 'SIAS_09007' TO CODOPE-GERAL */
                        _.Move("SIAS_09007", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);

                        /*" -3020- ELSE */
                    }
                    else
                    {


                        /*" -3021- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'JBDES' */

                        if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "JBDES")
                        {

                            /*" -3022- MOVE 'SIAS_09025' TO CODOPE-GERAL */
                            _.Move("SIAS_09025", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);

                            /*" -3023- ELSE */
                        }
                        else
                        {


                            /*" -3024- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'JBHON' */

                            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "JBHON")
                            {

                                /*" -3025- MOVE 'SIAS_09015' TO CODOPE-GERAL */
                                _.Move("SIAS_09015", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);

                                /*" -3026- ELSE */
                            }
                            else
                            {


                                /*" -3035- MOVE 'SIAS_02???' TO CODOPE-GERAL. */
                                _.Move("SIAS_02???", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);
                            }

                        }

                    }

                }

            }


            /*" -3036- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'HPAG' */

            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "HPAG")
            {

                /*" -3037- MOVE 0 TO HOST-COUNT */
                _.Move(0, HOST_COUNT);

                /*" -3039- PERFORM R3010-ACESSA-SCPJUD THRU R3010-EXIT */

                R3010_ACESSA_SCPJUD(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3010_EXIT*/


                /*" -3040- IF HOST-COUNT EQUAL 0 */

                if (HOST_COUNT == 0)
                {

                    /*" -3042- MOVE 'SIAS_09010' TO CODOPE-GERAL */
                    _.Move("SIAS_09010", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);

                    /*" -3043- ELSE */
                }
                else
                {


                    /*" -3044- IF SINISMES-RAMO EQUAL 66 */

                    if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO == 66)
                    {

                        /*" -3045- MOVE 'SIAS_09014' TO CODOPE-GERAL */
                        _.Move("SIAS_09014", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);

                        /*" -3046- ELSE */
                    }
                    else
                    {


                        /*" -3047- MOVE 'S100' TO ORIG-GERAL */
                        _.Move("S100", W_REGISTRO_SIAS_GERAL.ORIG_GERAL);

                        /*" -3051- MOVE 'SIAS_09009' TO CODOPE-GERAL. */
                        _.Move("SIAS_09009", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);
                    }

                }

            }


            /*" -3052- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'DPAG' */

            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "DPAG")
            {

                /*" -3053- MOVE 0 TO HOST-COUNT */
                _.Move(0, HOST_COUNT);

                /*" -3055- PERFORM R3010-ACESSA-SCPJUD THRU R3010-EXIT */

                R3010_ACESSA_SCPJUD(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3010_EXIT*/


                /*" -3056- IF HOST-COUNT EQUAL 0 */

                if (HOST_COUNT == 0)
                {

                    /*" -3058- MOVE 'SIAS_09023' TO CODOPE-GERAL */
                    _.Move("SIAS_09023", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);

                    /*" -3059- ELSE */
                }
                else
                {


                    /*" -3060- IF SINISMES-RAMO EQUAL 66 */

                    if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO == 66)
                    {

                        /*" -3061- MOVE 'SIAS_09014' TO CODOPE-GERAL */
                        _.Move("SIAS_09014", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);

                        /*" -3062- ELSE */
                    }
                    else
                    {


                        /*" -3063- MOVE 'S100' TO ORIG-GERAL */
                        _.Move("S100", W_REGISTRO_SIAS_GERAL.ORIG_GERAL);

                        /*" -3067- MOVE 'SIAS_09022' TO CODOPE-GERAL. */
                        _.Move("SIAS_09022", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);
                    }

                }

            }


            /*" -3069- IF SINISMES-RAMO EQUAL 66 AND GEOPERAC-FUNCAO-OPERACAO EQUAL 'IND' */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO == 66 && GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "IND")
            {

                /*" -3070- MOVE 0 TO HOST-COUNT */
                _.Move(0, HOST_COUNT);

                /*" -3072- PERFORM R3010-ACESSA-SCPJUD THRU R3010-EXIT */

                R3010_ACESSA_SCPJUD(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3010_EXIT*/


                /*" -3073- IF HOST-COUNT EQUAL 0 */

                if (HOST_COUNT == 0)
                {

                    /*" -3074- MOVE 'S101' TO ORIG-GERAL */
                    _.Move("S101", W_REGISTRO_SIAS_GERAL.ORIG_GERAL);

                    /*" -3076- MOVE 'SIAS_09001' TO CODOPE-GERAL */
                    _.Move("SIAS_09001", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);

                    /*" -3077- ELSE */
                }
                else
                {


                    /*" -3078- MOVE 'S100' TO ORIG-GERAL */
                    _.Move("S100", W_REGISTRO_SIAS_GERAL.ORIG_GERAL);

                    /*" -3084- MOVE 'SIAS_09008' TO CODOPE-GERAL. */
                    _.Move("SIAS_09008", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);
                }

            }


            /*" -3088- MOVE 'X' TO PAGBLK-GERAL. */
            _.Move("X", W_REGISTRO_SIAS_GERAL.PAGBLK_GERAL);

            /*" -3092- MOVE 'C000' TO CODSOC-GERAL. */
            _.Move("C000", W_REGISTRO_SIAS_GERAL.CODSOC_GERAL);

            /*" -3096- MOVE 'BRL' TO MOEDA-GERAL. */
            _.Move("BRL", W_REGISTRO_SIAS_GERAL.MOEDA_GERAL);

            /*" -3097- MOVE SISTEMAs-DATA-MOV-ABERTO(1:4) TO W-DATA-AAAAMMDD-AAAA. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4), AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_AAAA);

            /*" -3098- MOVE SISTEMAs-DATA-MOV-ABERTO(6:2) TO W-DATA-AAAAMMDD-MM. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2), AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_MM);

            /*" -3099- MOVE SISTEMAs-DATA-MOV-ABERTO(9:2) TO W-DATA-AAAAMMDD-DD. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2), AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_DD);

            /*" -3103- MOVE W-DATA-AAAAMMDD TO DTDOC-GERAL. */
            _.Move(AREA_DE_WORK.W_DATA_AAAAMMDD, W_REGISTRO_SIAS_GERAL.DTDOC_GERAL);

            /*" -3104- MOVE SISTEMAs-DATA-MOV-ABERTO(1:4) TO W-DATA-AAAAMMDD-AAAA. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4), AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_AAAA);

            /*" -3105- MOVE SISTEMAs-DATA-MOV-ABERTO(6:2) TO W-DATA-AAAAMMDD-MM. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2), AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_MM);

            /*" -3106- MOVE SISTEMAs-DATA-MOV-ABERTO(9:2) TO W-DATA-AAAAMMDD-DD. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2), AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_DD);

            /*" -3108- MOVE W-DATA-AAAAMMDD TO DTLAN-GERAL. */
            _.Move(AREA_DE_WORK.W_DATA_AAAAMMDD, W_REGISTRO_SIAS_GERAL.DTLAN_GERAL);

            /*" -3110- PERFORM R3100-DADOS-FINAL-ARQUIVO THRU R3100-EXIT. */

            R3100_DADOS_FINAL_ARQUIVO(true);

            R3100_CONTINUA_MONTAGEM(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_EXIT*/


            /*" -3118- MOVE CODOPE-GERAL TO WS-COD-EVENTO */
            _.Move(W_REGISTRO_SIAS_GERAL.CODOPE_GERAL, WS_COD_EVENTO);

            /*" -3119- IF CODOPE-GERAL EQUAL 'SIAS_09504' OR 'SIAS_09515' */

            if (W_REGISTRO_SIAS_GERAL.CODOPE_GERAL.In("SIAS_09504".ToString(), "SIAS_09515".ToString()))
            {

                /*" -3120- PERFORM R3700-MONTA-ATTR-RECEB-MOD-CA THRU R3700-EXIT */

                R3700_MONTA_ATTR_RECEB_MOD_CA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3700_EXIT*/


                /*" -3121- PERFORM R3750-MONTA-CODV-RECEB-MOD-CA THRU R3750-EXIT */

                R3750_MONTA_CODV_RECEB_MOD_CA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3750_EXIT*/


                /*" -3122- ELSE */
            }
            else
            {


                /*" -3123- PERFORM R3500-MONTA-ATTR-PAGTO-MOD-AP THRU R3500-EXIT */

                R3500_MONTA_ATTR_PAGTO_MOD_AP(true);

                R3500_PULA_CBEN(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3500_EXIT*/


                /*" -3123- PERFORM R3550-MONTA-CODV-PAGTO-MOD-AP THRU R3550-EXIT. */

                R3550_MONTA_CODV_PAGTO_MOD_AP(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3550_EXIT*/

            }


        }

        [StopWatch]
        /*" R3000-GRAVA-REGISTRO */
        private void R3000_GRAVA_REGISTRO(bool isPerform = false)
        {
            /*" -3130- IF W-CHAVE-MONTA-SIACC-ESPECIAL EQUAL 'NAO' */

            if (AREA_DE_WORK.W_CHAVE_MONTA_SIACC_ESPECIAL == "NAO")
            {

                /*" -3131- IF TITLE-MEDI-GERAL EQUAL 'Z004' */

                if (W_REGISTRO_SIAS_GERAL.TITLE_MEDI_GERAL == "Z004")
                {

                    /*" -3133- PERFORM R3020-ENDERECO-CAIXA-SEGUROS THRU R3020-EXIT. */

                    R3020_ENDERECO_CAIXA_SEGUROS(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R3020_EXIT*/

                }

            }


            /*" -3134- IF REGION-FSCL-GERAL EQUAL ' ' */

            if (W_REGISTRO_SIAS_GERAL.REGION_FSCL_GERAL == " ")
            {

                /*" -3135- MOVE 'XX' TO REGION-FSCL-GERAL. */
                _.Move("XX", W_REGISTRO_SIAS_GERAL.REGION_FSCL_GERAL);
            }


            /*" -3136- IF REGION-COR-GERAL EQUAL ' ' */

            if (W_REGISTRO_SIAS_GERAL.REGION_COR_GERAL == " ")
            {

                /*" -3136- MOVE 'XX' TO REGION-COR-GERAL . */
                _.Move("XX", W_REGISTRO_SIAS_GERAL.REGION_COR_GERAL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_EXIT*/

        [StopWatch]
        /*" R3005-LIMPA-OS-COD-E-VALOR */
        private void R3005_LIMPA_OS_COD_E_VALOR(bool isPerform = false)
        {
            /*" -3143- MOVE ZEROS TO W-VALOR-GERAL-VALOR. */
            _.Move(0, W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

            /*" -3153- MOVE '0,00' TO VALO04-GERAL VALO05-GERAL VALO06-GERAL VALO07-GERAL VALO08-GERAL VALO09-GERAL VALO010-GERAL VALO011-GERAL VALO012-GERAL VALO013-GERAL VALO014-GERAL VALO015-GERAL VALO016-GERAL VALO017-GERAL VALO018-GERAL VALO019-GERAL. */
            _.Move("0,00", W_REGISTRO_SIAS_GERAL.VALO04_GERAL, W_REGISTRO_SIAS_GERAL.VALO05_GERAL, W_REGISTRO_SIAS_GERAL.VALO06_GERAL, W_REGISTRO_SIAS_GERAL.VALO07_GERAL, W_REGISTRO_SIAS_GERAL.VALO08_GERAL, W_REGISTRO_SIAS_GERAL.VALO09_GERAL, W_REGISTRO_SIAS_GERAL.VALO010_GERAL, W_REGISTRO_SIAS_GERAL.VALO011_GERAL, W_REGISTRO_SIAS_GERAL.VALO012_GERAL, W_REGISTRO_SIAS_GERAL.VALO013_GERAL, W_REGISTRO_SIAS_GERAL.VALO014_GERAL, W_REGISTRO_SIAS_GERAL.VALO015_GERAL, W_REGISTRO_SIAS_GERAL.VALO016_GERAL, W_REGISTRO_SIAS_GERAL.VALO017_GERAL, W_REGISTRO_SIAS_GERAL.VALO018_GERAL, W_REGISTRO_SIAS_GERAL.VALO019_GERAL);

            /*" -3155- MOVE 'CV_IRFAB' TO COD04-GERAL */
            _.Move("CV_IRFAB", W_REGISTRO_SIAS_GERAL.COD04_GERAL);

            /*" -3157- MOVE 'CV_IRFAR' TO COD05-GERAL */
            _.Move("CV_IRFAR", W_REGISTRO_SIAS_GERAL.COD05_GERAL);

            /*" -3159- MOVE 'CV_IRFBS' TO COD06-GERAL */
            _.Move("CV_IRFBS", W_REGISTRO_SIAS_GERAL.COD06_GERAL);

            /*" -3161- MOVE 'CV_IRFRT' TO COD07-GERAL */
            _.Move("CV_IRFRT", W_REGISTRO_SIAS_GERAL.COD07_GERAL);

            /*" -3163- MOVE 'CV_ISSBS' TO COD08-GERAL */
            _.Move("CV_ISSBS", W_REGISTRO_SIAS_GERAL.COD08_GERAL);

            /*" -3165- MOVE 'CV_ISSRT' TO COD09-GERAL */
            _.Move("CV_ISSRT", W_REGISTRO_SIAS_GERAL.COD09_GERAL);

            /*" -3167- MOVE 'CV_INSBS' TO COD010-GERAL */
            _.Move("CV_INSBS", W_REGISTRO_SIAS_GERAL.COD010_GERAL);

            /*" -3169- MOVE 'CV_INSRT' TO COD011-GERAL */
            _.Move("CV_INSRT", W_REGISTRO_SIAS_GERAL.COD011_GERAL);

            /*" -3171- MOVE 'CV_PISBS' TO COD012-GERAL */
            _.Move("CV_PISBS", W_REGISTRO_SIAS_GERAL.COD012_GERAL);

            /*" -3173- MOVE 'CV_PISRT' TO COD013-GERAL */
            _.Move("CV_PISRT", W_REGISTRO_SIAS_GERAL.COD013_GERAL);

            /*" -3175- MOVE 'CV_COFBS' TO COD014-GERAL */
            _.Move("CV_COFBS", W_REGISTRO_SIAS_GERAL.COD014_GERAL);

            /*" -3177- MOVE 'CV_COFRT' TO COD015-GERAL */
            _.Move("CV_COFRT", W_REGISTRO_SIAS_GERAL.COD015_GERAL);

            /*" -3179- MOVE 'CV_CSLBS' TO COD016-GERAL */
            _.Move("CV_CSLBS", W_REGISTRO_SIAS_GERAL.COD016_GERAL);

            /*" -3181- MOVE 'CV_CSLRT' TO COD017-GERAL */
            _.Move("CV_CSLRT", W_REGISTRO_SIAS_GERAL.COD017_GERAL);

            /*" -3183- MOVE 'CV_IRJBS' TO COD018-GERAL */
            _.Move("CV_IRJBS", W_REGISTRO_SIAS_GERAL.COD018_GERAL);

            /*" -3187- MOVE 'CV_IRJRT' TO COD019-GERAL */
            _.Move("CV_IRJRT", W_REGISTRO_SIAS_GERAL.COD019_GERAL);

            /*" -3190- MOVE 'CV_INPBS' TO COD020-GERAL */
            _.Move("CV_INPBS", W_REGISTRO_SIAS_GERAL.COD020_GERAL);

            /*" -3192- MOVE 'CV_INPRT' TO COD021-GERAL */
            _.Move("CV_INPRT", W_REGISTRO_SIAS_GERAL.COD021_GERAL);

            /*" -3193- MOVE SPACES TO COD022-GERAL VALO022-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD022_GERAL, W_REGISTRO_SIAS_GERAL.VALO022_GERAL);

            /*" -3194- MOVE SPACES TO COD023-GERAL VALO023-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD023_GERAL, W_REGISTRO_SIAS_GERAL.VALO023_GERAL);

            /*" -3195- MOVE SPACES TO COD024-GERAL VALO024-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD024_GERAL, W_REGISTRO_SIAS_GERAL.VALO024_GERAL);

            /*" -3197- MOVE SPACES TO COD025-GERAL VALO025-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD025_GERAL, W_REGISTRO_SIAS_GERAL.VALO025_GERAL);

            /*" -3198- MOVE '0,00' TO VALO010-GERAL */
            _.Move("0,00", W_REGISTRO_SIAS_GERAL.VALO010_GERAL);

            /*" -3199- MOVE '0,00' TO VALO020-GERAL */
            _.Move("0,00", W_REGISTRO_SIAS_GERAL.VALO020_GERAL);

            /*" -3200- MOVE '0,00' TO VALO021-GERAL */
            _.Move("0,00", W_REGISTRO_SIAS_GERAL.VALO021_GERAL);

            /*" -3200- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3005_EXIT*/

        [StopWatch]
        /*" R3010-ACESSA-SCPJUD */
        private void R3010_ACESSA_SCPJUD(bool isPerform = false)
        {
            /*" -3212- PERFORM R3010_ACESSA_SCPJUD_DB_SELECT_1 */

            R3010_ACESSA_SCPJUD_DB_SELECT_1();

            /*" -3215- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -3216- DISPLAY 'SISAP01B - ERRO COUNT SI_PROCESSO_JURID (1)' */
                _.Display($"SISAP01B - ERRO COUNT SI_PROCESSO_JURID (1)");

                /*" -3218- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -3219- IF HOST-COUNT EQUAL 0 */

            if (HOST_COUNT == 0)
            {

                /*" -3221- GO TO R3010-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3010_EXIT*/ //GOTO
                return;
            }


            /*" -3232- PERFORM R3010_ACESSA_SCPJUD_DB_SELECT_2 */

            R3010_ACESSA_SCPJUD_DB_SELECT_2();

            /*" -3235- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -3236- DISPLAY 'SISAP01B - ERRO COUNT SI_PROCESSO_JURID (2)' */
                _.Display($"SISAP01B - ERRO COUNT SI_PROCESSO_JURID (2)");

                /*" -3236- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3010-ACESSA-SCPJUD-DB-SELECT-1 */
        public void R3010_ACESSA_SCPJUD_DB_SELECT_1()
        {
            /*" -3212- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :HOST-COUNT FROM SEGUROS.SI_PROCESSO_JURID WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO WITH UR END-EXEC. */

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
            /*" -3232- EXEC SQL SELECT COD_PROCESSO_JURID INTO :SIPROJUD-COD-PROCESSO-JURID FROM SEGUROS.SI_PROCESSO_JURID WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND DTH_TIMESTAMP = ( SELECT MIN(DTH_TIMESTAMP) FROM SEGUROS.SI_PROCESSO_JURID WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO ) WITH UR END-EXEC. */

            var r3010_ACESSA_SCPJUD_DB_SELECT_2_Query1 = new R3010_ACESSA_SCPJUD_DB_SELECT_2_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
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
            /*" -3243- MOVE 'Q SCN QUADRA 01' TO STREET-FSCL-GERAL */
            _.Move("Q SCN QUADRA 01", W_REGISTRO_SIAS_GERAL.STREET_FSCL_GERAL);

            /*" -3244- MOVE 'ED. # 1' TO HOUSE-NUM1-FSCL-GERAL */
            _.Move("ED. # 1", W_REGISTRO_SIAS_GERAL.HOUSE_NUM1_FSCL_GERAL);

            /*" -3245- MOVE ' 17 ANDAR' TO HOUSE-NUM2-FSCL-GERAL */
            _.Move(" 17 ANDAR", W_REGISTRO_SIAS_GERAL.HOUSE_NUM2_FSCL_GERAL);

            /*" -3246- MOVE '70711-900' TO POST-CODE1-FSCL-GERAL */
            _.Move("70711-900", W_REGISTRO_SIAS_GERAL.POST_CODE1_FSCL_GERAL);

            /*" -3247- MOVE 'DF' TO REGION-FSCL-GERAL */
            _.Move("DF", W_REGISTRO_SIAS_GERAL.REGION_FSCL_GERAL);

            /*" -3248- MOVE 'BRASILIA' TO CITY1-FSCL-GERAL */
            _.Move("BRASILIA", W_REGISTRO_SIAS_GERAL.CITY1_FSCL_GERAL);

            /*" -3249- MOVE 'SETOR COMERCIAL NORTE' TO CITY2-FSCL-GERAL */
            _.Move("SETOR COMERCIAL NORTE", W_REGISTRO_SIAS_GERAL.CITY2_FSCL_GERAL);

            /*" -3251- MOVE 'BR' TO COUNTRY-FSCL-GERAL */
            _.Move("BR", W_REGISTRO_SIAS_GERAL.COUNTRY_FSCL_GERAL);

            /*" -3252- MOVE 'Q SCN QUADRA 01' TO STREET-COR-GERAL */
            _.Move("Q SCN QUADRA 01", W_REGISTRO_SIAS_GERAL.STREET_COR_GERAL);

            /*" -3253- MOVE 'ED. # 1' TO HOUSE-NUM1-COR-GERAL */
            _.Move("ED. # 1", W_REGISTRO_SIAS_GERAL.HOUSE_NUM1_COR_GERAL);

            /*" -3254- MOVE ' 17 ANDAR' TO HOUSE-NUM2-COR-GERAL */
            _.Move(" 17 ANDAR", W_REGISTRO_SIAS_GERAL.HOUSE_NUM2_COR_GERAL);

            /*" -3255- MOVE '70711-900' TO POST-CODE1-COR-GERAL */
            _.Move("70711-900", W_REGISTRO_SIAS_GERAL.POST_CODE1_COR_GERAL);

            /*" -3256- MOVE 'DF' TO REGION-COR-GERAL */
            _.Move("DF", W_REGISTRO_SIAS_GERAL.REGION_COR_GERAL);

            /*" -3257- MOVE 'BRASILIA' TO CITY1-COR-GERAL */
            _.Move("BRASILIA", W_REGISTRO_SIAS_GERAL.CITY1_COR_GERAL);

            /*" -3258- MOVE 'SETOR COMERCIAL NORTE' TO CITY2-COR-GERAL */
            _.Move("SETOR COMERCIAL NORTE", W_REGISTRO_SIAS_GERAL.CITY2_COR_GERAL);

            /*" -3260- MOVE 'BR' TO COUNTRY-COR-GERAL. */
            _.Move("BR", W_REGISTRO_SIAS_GERAL.COUNTRY_COR_GERAL);

            /*" -3261- IF REGION-FSCL-GERAL EQUAL ' ' */

            if (W_REGISTRO_SIAS_GERAL.REGION_FSCL_GERAL == " ")
            {

                /*" -3262- MOVE 'XX' TO REGION-FSCL-GERAL. */
                _.Move("XX", W_REGISTRO_SIAS_GERAL.REGION_FSCL_GERAL);
            }


            /*" -3263- IF REGION-COR-GERAL EQUAL ' ' */

            if (W_REGISTRO_SIAS_GERAL.REGION_COR_GERAL == " ")
            {

                /*" -3263- MOVE 'XX' TO REGION-COR-GERAL . */
                _.Move("XX", W_REGISTRO_SIAS_GERAL.REGION_COR_GERAL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3020_EXIT*/

        [StopWatch]
        /*" R3100-DADOS-FINAL-ARQUIVO */
        private void R3100_DADOS_FINAL_ARQUIVO(bool isPerform = false)
        {
            /*" -3270- MOVE 'C000' TO CODEMP-GERAL. */
            _.Move("C000", W_REGISTRO_SIAS_GERAL.CODEMP_GERAL);

            /*" -3272- MOVE 'BRL' TO MOEDABP-GERAL. */
            _.Move("BRL", W_REGISTRO_SIAS_GERAL.MOEDABP_GERAL);

            /*" -3273- MOVE 'BR2' TO TAXTYPE-CPF-GERAL */
            _.Move("BR2", W_REGISTRO_SIAS_GERAL.TAXTYPE_CPF_GERAL);

            /*" -3279- MOVE 'BR1' TO TAXTYPE-CNPJ-GERAL */
            _.Move("BR1", W_REGISTRO_SIAS_GERAL.TAXTYPE_CNPJ_GERAL);

            /*" -3281- IF LK-SAP-COD-PROGRAMA EQUAL 'FI0096B' OR 'SI5067B' OR 'SI5071B' */

            if (LK_SAP_COD_PROGRAMA.In("FI0096B", "SI5067B", "SI5071B"))
            {

                /*" -3282- MOVE 'SIM' TO W-CHAVE-MONTA-SIACC-ESPECIAL */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_MONTA_SIACC_ESPECIAL);

                /*" -3283- PERFORM R3300-MONTA-SIACC-IND-REP THRU R3300-EXIT */

                R3300_MONTA_SIACC_IND_REP(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3300_EXIT*/


                /*" -3285- GO TO R3100-CONTINUA-MONTAGEM. */

                R3100_CONTINUA_MONTAGEM(); //GOTO
                return;
            }


            /*" -3289- IF ( GEOPERAC-IND-TIPO-FUNCAO = 'JUR-DEP' OR 'JUR-DESP' ) OR ( GEOPERAC-IND-TIPO-FUNCAO = 'JUR-INDENI' AND NOT ( SINISHIS-COD-OPERACAO = 8210 OR 8211 OR 8212 ) ) */

            if ((GEOPERAC.DCLGE_OPERACAO.GEOPERAC_IND_TIPO_FUNCAO.In("JUR-DEP", "JUR-DESP")) || (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_IND_TIPO_FUNCAO == "JUR-INDENI" && !(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.In("8210", "8211", "8212"))))
            {

                /*" -3290- MOVE 'S' TO WS-IND-NOME-HIST */
                _.Move("S", WS_IND_NOME_HIST);

                /*" -3291- ELSE */
            }
            else
            {


                /*" -3292- MOVE 'N' TO WS-IND-NOME-HIST */
                _.Move("N", WS_IND_NOME_HIST);

                /*" -3294- END-IF */
            }


            /*" -3295- IF W-CHAVE-ORIGEM-CADASTRO EQUAL 'ODS' */

            if (AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO == "ODS")
            {

                /*" -3296- IF OD001-IND-PESSOA EQUAL 'F' */

                if (OD001.DCLOD_PESSOA.OD001_IND_PESSOA == "F")
                {

                    /*" -3297- MOVE 'X' TO NATPERS-GERAL */
                    _.Move("X", W_REGISTRO_SIAS_GERAL.NATPERS_GERAL);

                    /*" -3298- MOVE 'Z003' TO TITLE-MEDI-GERAL */
                    _.Move("Z003", W_REGISTRO_SIAS_GERAL.TITLE_MEDI_GERAL);

                    /*" -3299- IF NULL-NOM-PESSOA >= 0 */

                    if (NULL_NOM_PESSOA >= 0)
                    {

                        /*" -3301- MOVE OD002-NOM-PESSOA-TEXT TO NAME-FIRST-GERAL */
                        _.Move(OD002.DCLOD_PESSOA_FISICA.OD002_NOM_PESSOA.OD002_NOM_PESSOA_TEXT, W_REGISTRO_SIAS_GERAL.NAME_FIRST_GERAL);

                        /*" -3302- ELSE */
                    }
                    else
                    {


                        /*" -3303- MOVE ALL '?1' TO NAME-FIRST-GERAL */
                        _.MoveAll("?1", W_REGISTRO_SIAS_GERAL.NAME_FIRST_GERAL);

                        /*" -3304- END-IF */
                    }


                    /*" -3305- IF WS-IND-NOME-HIST = 'S' */

                    if (WS_IND_NOME_HIST == "S")
                    {

                        /*" -3307- MOVE SINISHIS-NOME-FAVORECIDO TO NAME-FIRST-GERAL */
                        _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO, W_REGISTRO_SIAS_GERAL.NAME_FIRST_GERAL);

                        /*" -3308- END-IF */
                    }


                    /*" -3309- MOVE 'BR2' TO TAXTYPE-CPF-GERAL */
                    _.Move("BR2", W_REGISTRO_SIAS_GERAL.TAXTYPE_CPF_GERAL);

                    /*" -3310- IF NULL-NUM-CPF >= 0 */

                    if (NULL_NUM_CPF >= 0)
                    {

                        /*" -3311- MOVE W-NUM-CPF-ALFA TO TAXNUM-CPF-GERAL */
                        _.Move(W_NUM_CPF_ALFA, W_REGISTRO_SIAS_GERAL.TAXNUM_CPF_GERAL);

                        /*" -3312- ELSE */
                    }
                    else
                    {


                        /*" -3313- MOVE ALL '?9' TO TAXNUM-CPF-GERAL */
                        _.MoveAll("?9", W_REGISTRO_SIAS_GERAL.TAXNUM_CPF_GERAL);

                        /*" -3314- END-IF */
                    }


                    /*" -3315- ELSE */
                }
                else
                {


                    /*" -3316- IF OD001-IND-PESSOA EQUAL 'J' */

                    if (OD001.DCLOD_PESSOA.OD001_IND_PESSOA == "J")
                    {

                        /*" -3317- MOVE ' ' TO NATPERS-GERAL */
                        _.Move(" ", W_REGISTRO_SIAS_GERAL.NATPERS_GERAL);

                        /*" -3318- MOVE '0003' TO TITLE-MEDI-GERAL */
                        _.Move("0003", W_REGISTRO_SIAS_GERAL.TITLE_MEDI_GERAL);

                        /*" -3319- IF NULL-NOM-RAZAO-SOCIAL >= 0 */

                        if (NULL_NOM_RAZAO_SOCIAL >= 0)
                        {

                            /*" -3321- MOVE OD003-NOM-RAZAO-SOCIAL-TEXT TO NAME-ORG1-GERAL */
                            _.Move(OD003.DCLOD_PESSOA_JURIDICA.OD003_NOM_RAZAO_SOCIAL.OD003_NOM_RAZAO_SOCIAL_TEXT, W_REGISTRO_SIAS_GERAL.NAME_ORG1_GERAL);

                            /*" -3322- ELSE */
                        }
                        else
                        {


                            /*" -3323- MOVE ALL '?2' TO NAME-ORG1-GERAL */
                            _.MoveAll("?2", W_REGISTRO_SIAS_GERAL.NAME_ORG1_GERAL);

                            /*" -3324- END-IF */
                        }


                        /*" -3325- IF WS-IND-NOME-HIST = 'S' */

                        if (WS_IND_NOME_HIST == "S")
                        {

                            /*" -3327- MOVE SINISHIS-NOME-FAVORECIDO TO NAME-ORG1-GERAL */
                            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO, W_REGISTRO_SIAS_GERAL.NAME_ORG1_GERAL);

                            /*" -3328- END-IF */
                        }


                        /*" -3329- MOVE 'BR1' TO TAXTYPE-CNPJ-GERAL */
                        _.Move("BR1", W_REGISTRO_SIAS_GERAL.TAXTYPE_CNPJ_GERAL);

                        /*" -3330- IF NULL-NUM-CNPJ >= 0 */

                        if (NULL_NUM_CNPJ >= 0)
                        {

                            /*" -3331- MOVE W-NUM-CNPJ-ALFA TO TAXNUM-CNPJ-GERAL */
                            _.Move(W_NUM_CNPJ_ALFA, W_REGISTRO_SIAS_GERAL.TAXNUM_CNPJ_GERAL);

                            /*" -3332- ELSE */
                        }
                        else
                        {


                            /*" -3333- MOVE ALL '?10' TO TAXNUM-CNPJ-GERAL */
                            _.MoveAll("?10", W_REGISTRO_SIAS_GERAL.TAXNUM_CNPJ_GERAL);

                            /*" -3334- END-IF */
                        }


                        /*" -3335- ELSE */
                    }
                    else
                    {


                        /*" -3336- MOVE '?' TO NATPERS-GERAL */
                        _.Move("?", W_REGISTRO_SIAS_GERAL.NATPERS_GERAL);

                        /*" -3337- MOVE 'Z004' TO TITLE-MEDI-GERAL */
                        _.Move("Z004", W_REGISTRO_SIAS_GERAL.TITLE_MEDI_GERAL);

                        /*" -3338- MOVE ALL '?12' TO TAXNUM-CPF-GERAL */
                        _.MoveAll("?12", W_REGISTRO_SIAS_GERAL.TAXNUM_CPF_GERAL);

                        /*" -3340- MOVE ALL '?11' TO TAXNUM-CNPJ-GERAL. */
                        _.MoveAll("?11", W_REGISTRO_SIAS_GERAL.TAXNUM_CNPJ_GERAL);
                    }

                }

            }


            /*" -3341- IF W-CHAVE-ORIGEM-CADASTRO EQUAL 'FORNECEDOR OU LOTERICO' */

            if (AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO == "FORNECEDOR OU LOTERICO")
            {

                /*" -3342- IF FORNECED-TIPO-PESSOA EQUAL 'F' */

                if (FORNECED.DCLFORNECEDORES.FORNECED_TIPO_PESSOA == "F")
                {

                    /*" -3343- MOVE 'X' TO NATPERS-GERAL */
                    _.Move("X", W_REGISTRO_SIAS_GERAL.NATPERS_GERAL);

                    /*" -3344- MOVE 'Z003' TO TITLE-MEDI-GERAL */
                    _.Move("Z003", W_REGISTRO_SIAS_GERAL.TITLE_MEDI_GERAL);

                    /*" -3345- MOVE FORNECED-NOME-FORNECEDOR TO NAME-FIRST-GERAL */
                    _.Move(FORNECED.DCLFORNECEDORES.FORNECED_NOME_FORNECEDOR, W_REGISTRO_SIAS_GERAL.NAME_FIRST_GERAL);

                    /*" -3346- IF WS-IND-NOME-HIST = 'S' */

                    if (WS_IND_NOME_HIST == "S")
                    {

                        /*" -3348- MOVE SINISHIS-NOME-FAVORECIDO TO NAME-FIRST-GERAL */
                        _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO, W_REGISTRO_SIAS_GERAL.NAME_FIRST_GERAL);

                        /*" -3349- END-IF */
                    }


                    /*" -3350- MOVE 'BR2' TO TAXTYPE-CPF-GERAL */
                    _.Move("BR2", W_REGISTRO_SIAS_GERAL.TAXTYPE_CPF_GERAL);

                    /*" -3351- MOVE W-NUM-CPF-ALFA TO TAXNUM-CPF-GERAL */
                    _.Move(W_NUM_CPF_ALFA, W_REGISTRO_SIAS_GERAL.TAXNUM_CPF_GERAL);

                    /*" -3352- ELSE */
                }
                else
                {


                    /*" -3353- IF FORNECED-TIPO-PESSOA EQUAL 'J' */

                    if (FORNECED.DCLFORNECEDORES.FORNECED_TIPO_PESSOA == "J")
                    {

                        /*" -3354- MOVE ' ' TO NATPERS-GERAL */
                        _.Move(" ", W_REGISTRO_SIAS_GERAL.NATPERS_GERAL);

                        /*" -3355- MOVE '0003' TO TITLE-MEDI-GERAL */
                        _.Move("0003", W_REGISTRO_SIAS_GERAL.TITLE_MEDI_GERAL);

                        /*" -3356- MOVE FORNECED-NOME-FORNECEDOR TO NAME-ORG1-GERAL */
                        _.Move(FORNECED.DCLFORNECEDORES.FORNECED_NOME_FORNECEDOR, W_REGISTRO_SIAS_GERAL.NAME_ORG1_GERAL);

                        /*" -3357- IF WS-IND-NOME-HIST = 'S' */

                        if (WS_IND_NOME_HIST == "S")
                        {

                            /*" -3359- MOVE SINISHIS-NOME-FAVORECIDO TO NAME-ORG1-GERAL */
                            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO, W_REGISTRO_SIAS_GERAL.NAME_ORG1_GERAL);

                            /*" -3360- END-IF */
                        }


                        /*" -3361- MOVE 'BR1' TO TAXTYPE-CNPJ-GERAL */
                        _.Move("BR1", W_REGISTRO_SIAS_GERAL.TAXTYPE_CNPJ_GERAL);

                        /*" -3362- MOVE W-NUM-CNPJ-ALFA TO TAXNUM-CNPJ-GERAL */
                        _.Move(W_NUM_CNPJ_ALFA, W_REGISTRO_SIAS_GERAL.TAXNUM_CNPJ_GERAL);

                        /*" -3363- ELSE */
                    }
                    else
                    {


                        /*" -3364- MOVE '?' TO NATPERS-GERAL */
                        _.Move("?", W_REGISTRO_SIAS_GERAL.NATPERS_GERAL);

                        /*" -3365- MOVE ALL '?4' TO NAME-FIRST-GERAL */
                        _.MoveAll("?4", W_REGISTRO_SIAS_GERAL.NAME_FIRST_GERAL);

                        /*" -3367- MOVE ALL '?5' TO NAME-ORG1-GERAL. */
                        _.MoveAll("?5", W_REGISTRO_SIAS_GERAL.NAME_ORG1_GERAL);
                    }

                }

            }


            /*" -3368- IF W-CHAVE-ORIGEM-CADASTRO EQUAL 'SEM CADASTRO' */

            if (AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO == "SEM CADASTRO")
            {

                /*" -3369- MOVE SINISHIS-NOME-FAVORECIDO TO NAME-ORG1-GERAL */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO, W_REGISTRO_SIAS_GERAL.NAME_ORG1_GERAL);

                /*" -3370- IF WS-IND-NOME-HIST = 'S' */

                if (WS_IND_NOME_HIST == "S")
                {

                    /*" -3372- MOVE SINISHIS-NOME-FAVORECIDO TO NAME-ORG1-GERAL */
                    _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO, W_REGISTRO_SIAS_GERAL.NAME_ORG1_GERAL);

                    /*" -3373- END-IF */
                }


                /*" -3374- MOVE ' ' TO NATPERS-GERAL */
                _.Move(" ", W_REGISTRO_SIAS_GERAL.NATPERS_GERAL);

                /*" -3376- MOVE 'Z004' TO TITLE-MEDI-GERAL . */
                _.Move("Z004", W_REGISTRO_SIAS_GERAL.TITLE_MEDI_GERAL);
            }


            /*" -3377- IF NAME-FIRST-GERAL NOT EQUAL SPACES */

            if (!W_REGISTRO_SIAS_GERAL.NAME_FIRST_GERAL.IsEmpty())
            {

                /*" -3378- MOVE NAME-FIRST-GERAL TO CT0007S-NOME */
                _.Move(W_REGISTRO_SIAS_GERAL.NAME_FIRST_GERAL, REG_LK_BANCOS.CT0007SW099.CT0007S_NOME);

                /*" -3379- CALL 'CT0007S' USING CT0007SW099 */
                _.Call("CT0007S", REG_LK_BANCOS.CT0007SW099);

                /*" -3380- IF CT0007S-SOBRENOME EQUAL ' ' */

                if (REG_LK_BANCOS.CT0007SW099.CT0007S_SOBRENOME == " ")
                {

                    /*" -3381- MOVE ALL '?8' TO NAME-LAST-GERAL */
                    _.MoveAll("?8", W_REGISTRO_SIAS_GERAL.NAME_LAST_GERAL);

                    /*" -3382- ELSE */
                }
                else
                {


                    /*" -3383- MOVE CT0007S-NOME1 TO NAME-FIRST-GERAL */
                    _.Move(REG_LK_BANCOS.CT0007SW099.CT0007S_NOME1, W_REGISTRO_SIAS_GERAL.NAME_FIRST_GERAL);

                    /*" -3385- MOVE CT0007S-SOBRENOME TO NAME-LAST-GERAL. */
                    _.Move(REG_LK_BANCOS.CT0007SW099.CT0007S_SOBRENOME, W_REGISTRO_SIAS_GERAL.NAME_LAST_GERAL);
                }

            }


            /*" -3386- IF W-CHAVE-EH-PRESTADOR EQUAL 'SIM' */

            if (AREA_DE_WORK.W_CHAVE_EH_PRESTADOR == "SIM")
            {

                /*" -3388- PERFORM R3200-MONTA-PRESTADOR THRU R3200-EXIT. */

                R3200_MONTA_PRESTADOR(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_EXIT*/

            }


            /*" -3390- MOVE 'NAO' TO W-CHAVE-COLOCA-ENDERECO */
            _.Move("NAO", AREA_DE_WORK.W_CHAVE_COLOCA_ENDERECO);

            /*" -3391- IF W-CHAVE-ORIGEM-CADASTRO EQUAL 'ODS' */

            if (AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO == "ODS")
            {

                /*" -3392- IF NULL-NOM-LOGRADOURO >= 0 */

                if (NULL_NOM_LOGRADOURO >= 0)
                {

                    /*" -3393- MOVE OD007-NOM-LOGRADOURO TO STREET-FSCL-GERAL */
                    _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_LOGRADOURO, W_REGISTRO_SIAS_GERAL.STREET_FSCL_GERAL);

                    /*" -3394- MOVE OD007-NOM-LOGRADOURO TO STREET-COR-GERAL */
                    _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_LOGRADOURO, W_REGISTRO_SIAS_GERAL.STREET_COR_GERAL);

                    /*" -3395- ELSE */
                }
                else
                {


                    /*" -3396- MOVE 'SIM' TO W-CHAVE-COLOCA-ENDERECO */
                    _.Move("SIM", AREA_DE_WORK.W_CHAVE_COLOCA_ENDERECO);

                    /*" -3397- MOVE ALL '?30' TO STREET-FSCL-GERAL */
                    _.MoveAll("?30", W_REGISTRO_SIAS_GERAL.STREET_FSCL_GERAL);

                    /*" -3398- MOVE ALL '?30' TO STREET-COR-GERAL */
                    _.MoveAll("?30", W_REGISTRO_SIAS_GERAL.STREET_COR_GERAL);

                    /*" -3399- END-IF */
                }


                /*" -3400- IF NULL-DES-NUM-IMOVEL >= 0 */

                if (NULL_DES_NUM_IMOVEL >= 0)
                {

                    /*" -3401- MOVE OD007-DES-NUM-IMOVEL TO HOUSE-NUM1-FSCL-GERAL */
                    _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_DES_NUM_IMOVEL, W_REGISTRO_SIAS_GERAL.HOUSE_NUM1_FSCL_GERAL);

                    /*" -3402- MOVE OD007-DES-NUM-IMOVEL TO HOUSE-NUM1-COR-GERAL */
                    _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_DES_NUM_IMOVEL, W_REGISTRO_SIAS_GERAL.HOUSE_NUM1_COR_GERAL);

                    /*" -3403- ELSE */
                }
                else
                {


                    /*" -3404- MOVE 'SIM' TO W-CHAVE-COLOCA-ENDERECO */
                    _.Move("SIM", AREA_DE_WORK.W_CHAVE_COLOCA_ENDERECO);

                    /*" -3405- MOVE ALL '?31' TO HOUSE-NUM1-FSCL-GERAL */
                    _.MoveAll("?31", W_REGISTRO_SIAS_GERAL.HOUSE_NUM1_FSCL_GERAL);

                    /*" -3406- MOVE ALL '?31' TO HOUSE-NUM1-COR-GERAL */
                    _.MoveAll("?31", W_REGISTRO_SIAS_GERAL.HOUSE_NUM1_COR_GERAL);

                    /*" -3407- END-IF */
                }


                /*" -3408- IF NULL-DES-COMPL-ENDERECO >= 0 */

                if (NULL_DES_COMPL_ENDERECO >= 0)
                {

                    /*" -3409- MOVE OD007-DES-COMPL-ENDERECO TO HOUSE-NUM2-FSCL-GERAL */
                    _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_DES_COMPL_ENDERECO, W_REGISTRO_SIAS_GERAL.HOUSE_NUM2_FSCL_GERAL);

                    /*" -3410- MOVE OD007-DES-COMPL-ENDERECO TO HOUSE-NUM2-COR-GERAL */
                    _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_DES_COMPL_ENDERECO, W_REGISTRO_SIAS_GERAL.HOUSE_NUM2_COR_GERAL);

                    /*" -3411- ELSE */
                }
                else
                {


                    /*" -3412- MOVE 'SIM' TO W-CHAVE-COLOCA-ENDERECO */
                    _.Move("SIM", AREA_DE_WORK.W_CHAVE_COLOCA_ENDERECO);

                    /*" -3413- MOVE ALL '?32' TO HOUSE-NUM2-FSCL-GERAL */
                    _.MoveAll("?32", W_REGISTRO_SIAS_GERAL.HOUSE_NUM2_FSCL_GERAL);

                    /*" -3414- MOVE ALL '?32' TO HOUSE-NUM2-COR-GERAL */
                    _.MoveAll("?32", W_REGISTRO_SIAS_GERAL.HOUSE_NUM2_COR_GERAL);

                    /*" -3415- END-IF */
                }


                /*" -3416- IF NULL-COD-CEP >= 0 */

                if (NULL_COD_CEP >= 0)
                {

                    /*" -3417- MOVE W-CEP-ALFA TO POST-CODE1-FSCL-GERAL */
                    _.Move(W_CEP_ALFA, W_REGISTRO_SIAS_GERAL.POST_CODE1_FSCL_GERAL);

                    /*" -3418- MOVE W-CEP-ALFA TO POST-CODE1-COR-GERAL */
                    _.Move(W_CEP_ALFA, W_REGISTRO_SIAS_GERAL.POST_CODE1_COR_GERAL);

                    /*" -3419- ELSE */
                }
                else
                {


                    /*" -3420- MOVE '99999-999' TO POST-CODE1-FSCL-GERAL */
                    _.Move("99999-999", W_REGISTRO_SIAS_GERAL.POST_CODE1_FSCL_GERAL);

                    /*" -3421- MOVE '99999-999' TO POST-CODE1-COR-GERAL */
                    _.Move("99999-999", W_REGISTRO_SIAS_GERAL.POST_CODE1_COR_GERAL);

                    /*" -3422- END-IF */
                }


                /*" -3423- IF NULL-COD-UF >= 0 */

                if (NULL_COD_UF >= 0)
                {

                    /*" -3424- MOVE OD007-COD-UF TO REGION-FSCL-GERAL */
                    _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_UF, W_REGISTRO_SIAS_GERAL.REGION_FSCL_GERAL);

                    /*" -3425- MOVE OD007-COD-UF TO REGION-COR-GERAL */
                    _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_UF, W_REGISTRO_SIAS_GERAL.REGION_COR_GERAL);

                    /*" -3426- ELSE */
                }
                else
                {


                    /*" -3427- MOVE 'XX' TO REGION-FSCL-GERAL */
                    _.Move("XX", W_REGISTRO_SIAS_GERAL.REGION_FSCL_GERAL);

                    /*" -3428- MOVE 'XX' TO REGION-COR-GERAL */
                    _.Move("XX", W_REGISTRO_SIAS_GERAL.REGION_COR_GERAL);

                    /*" -3429- END-IF */
                }


                /*" -3430- IF NULL-NOM-CIDADE >= 0 */

                if (NULL_NOM_CIDADE >= 0)
                {

                    /*" -3431- MOVE OD007-NOM-CIDADE TO CITY1-FSCL-GERAL */
                    _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_CIDADE, W_REGISTRO_SIAS_GERAL.CITY1_FSCL_GERAL);

                    /*" -3432- MOVE OD007-NOM-CIDADE TO CITY1-COR-GERAL */
                    _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_CIDADE, W_REGISTRO_SIAS_GERAL.CITY1_COR_GERAL);

                    /*" -3433- ELSE */
                }
                else
                {


                    /*" -3434- MOVE 'SIM' TO W-CHAVE-COLOCA-ENDERECO */
                    _.Move("SIM", AREA_DE_WORK.W_CHAVE_COLOCA_ENDERECO);

                    /*" -3435- MOVE ALL '?35' TO CITY1-FSCL-GERAL */
                    _.MoveAll("?35", W_REGISTRO_SIAS_GERAL.CITY1_FSCL_GERAL);

                    /*" -3436- MOVE ALL '?35' TO CITY1-COR-GERAL */
                    _.MoveAll("?35", W_REGISTRO_SIAS_GERAL.CITY1_COR_GERAL);

                    /*" -3437- END-IF */
                }


                /*" -3438- IF NULL-NOM-BAIRRO >= 0 */

                if (NULL_NOM_BAIRRO >= 0)
                {

                    /*" -3439- MOVE OD007-NOM-BAIRRO TO CITY2-FSCL-GERAL */
                    _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_BAIRRO, W_REGISTRO_SIAS_GERAL.CITY2_FSCL_GERAL);

                    /*" -3440- MOVE OD007-NOM-BAIRRO TO CITY2-COR-GERAL */
                    _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_BAIRRO, W_REGISTRO_SIAS_GERAL.CITY2_COR_GERAL);

                    /*" -3441- ELSE */
                }
                else
                {


                    /*" -3442- MOVE 'SIM' TO W-CHAVE-COLOCA-ENDERECO */
                    _.Move("SIM", AREA_DE_WORK.W_CHAVE_COLOCA_ENDERECO);

                    /*" -3443- MOVE ALL '?36' TO CITY1-FSCL-GERAL */
                    _.MoveAll("?36", W_REGISTRO_SIAS_GERAL.CITY1_FSCL_GERAL);

                    /*" -3444- MOVE ALL '?36' TO CITY1-COR-GERAL */
                    _.MoveAll("?36", W_REGISTRO_SIAS_GERAL.CITY1_COR_GERAL);

                    /*" -3446- END-IF . */
                }

            }


            /*" -3448- IF W-CHAVE-COLOCA-ENDERECO EQUAL 'SIM' OR W-CHAVE-ORIGEM-CADASTRO EQUAL 'SEM CADASTRO' */

            if (AREA_DE_WORK.W_CHAVE_COLOCA_ENDERECO == "SIM" || AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO == "SEM CADASTRO")
            {

                /*" -3450- PERFORM R3020-ENDERECO-CAIXA-SEGUROS THRU R3020-EXIT. */

                R3020_ENDERECO_CAIXA_SEGUROS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3020_EXIT*/

            }


            /*" -3451- IF W-CHAVE-ORIGEM-CADASTRO EQUAL 'FORNECEDOR OU LOTERICO' */

            if (AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO == "FORNECEDOR OU LOTERICO")
            {

                /*" -3452- MOVE FORNECED-ENDERECO TO STREET-FSCL-GERAL */
                _.Move(FORNECED.DCLFORNECEDORES.FORNECED_ENDERECO, W_REGISTRO_SIAS_GERAL.STREET_FSCL_GERAL);

                /*" -3453- MOVE FORNECED-ENDERECO TO STREET-COR-GERAL */
                _.Move(FORNECED.DCLFORNECEDORES.FORNECED_ENDERECO, W_REGISTRO_SIAS_GERAL.STREET_COR_GERAL);

                /*" -3454- MOVE W-CEP-ALFA TO POST-CODE1-FSCL-GERAL */
                _.Move(W_CEP_ALFA, W_REGISTRO_SIAS_GERAL.POST_CODE1_FSCL_GERAL);

                /*" -3455- MOVE W-CEP-ALFA TO POST-CODE1-COR-GERAL */
                _.Move(W_CEP_ALFA, W_REGISTRO_SIAS_GERAL.POST_CODE1_COR_GERAL);

                /*" -3456- MOVE FORNECED-SIGLA-UF TO REGION-FSCL-GERAL */
                _.Move(FORNECED.DCLFORNECEDORES.FORNECED_SIGLA_UF, W_REGISTRO_SIAS_GERAL.REGION_FSCL_GERAL);

                /*" -3457- MOVE FORNECED-SIGLA-UF TO REGION-COR-GERAL */
                _.Move(FORNECED.DCLFORNECEDORES.FORNECED_SIGLA_UF, W_REGISTRO_SIAS_GERAL.REGION_COR_GERAL);

                /*" -3458- MOVE FORNECED-CIDADE TO CITY1-FSCL-GERAL */
                _.Move(FORNECED.DCLFORNECEDORES.FORNECED_CIDADE, W_REGISTRO_SIAS_GERAL.CITY1_FSCL_GERAL);

                /*" -3459- MOVE FORNECED-CIDADE TO CITY1-COR-GERAL */
                _.Move(FORNECED.DCLFORNECEDORES.FORNECED_CIDADE, W_REGISTRO_SIAS_GERAL.CITY1_COR_GERAL);

                /*" -3460- MOVE FORNECED-BAIRRO TO CITY2-FSCL-GERAL */
                _.Move(FORNECED.DCLFORNECEDORES.FORNECED_BAIRRO, W_REGISTRO_SIAS_GERAL.CITY2_FSCL_GERAL);

                /*" -3460- MOVE FORNECED-BAIRRO TO CITY2-COR-GERAL. */
                _.Move(FORNECED.DCLFORNECEDORES.FORNECED_BAIRRO, W_REGISTRO_SIAS_GERAL.CITY2_COR_GERAL);
            }


        }

        [StopWatch]
        /*" R3100-CONTINUA-MONTAGEM */
        private void R3100_CONTINUA_MONTAGEM(bool isPerform = false)
        {
            /*" -3470- MOVE 'BR4' TO TAXTYPE-INSCRM-GERAL. */
            _.Move("BR4", W_REGISTRO_SIAS_GERAL.TAXTYPE_INSCRM_GERAL);

            /*" -3472- MOVE 'BR3' TO TAXTYPE-INSCRE-GERAL. */
            _.Move("BR3", W_REGISTRO_SIAS_GERAL.TAXTYPE_INSCRE_GERAL);

            /*" -3474- MOVE 'BR' TO COUNTRY-FSCL-GERAL COUNTRY-COR-GERAL. */
            _.Move("BR", W_REGISTRO_SIAS_GERAL.COUNTRY_FSCL_GERAL, W_REGISTRO_SIAS_GERAL.COUNTRY_COR_GERAL);

            /*" -3475- IF NATPERS-GERAL EQUAL 'X' */

            if (W_REGISTRO_SIAS_GERAL.NATPERS_GERAL == "X")
            {

                /*" -3477- MOVE 'PT' TO LANGUCORR-GERAL . */
                _.Move("PT", W_REGISTRO_SIAS_GERAL.LANGUCORR_GERAL);
            }


            /*" -3479- IF TITLE-MEDI-GERAL EQUAL '0003' AND NATPERS-GERAL EQUAL ' ' */

            if (W_REGISTRO_SIAS_GERAL.TITLE_MEDI_GERAL == "0003" && W_REGISTRO_SIAS_GERAL.NATPERS_GERAL == " ")
            {

                /*" -3483- MOVE 'P' TO LANGU-GERAL . */
                _.Move("P", W_REGISTRO_SIAS_GERAL.LANGU_GERAL);
            }


            /*" -3485- MOVE 'BR' TO BANKS-GERAL */
            _.Move("BR", W_REGISTRO_SIAS_GERAL.BANKS_GERAL);

            /*" -3487- INITIALIZE REG-LK-BANCOS. */
            _.Initialize(
                REG_LK_BANCOS
            );

            /*" -3489- MOVE LK-SAP-COD-BANCO TO LK-BANCO-COD-BANCO . */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_COD_BANCO, REG_LK_BANCOS.LK_BANCO_COD_BANCO);

            /*" -3494- CALL 'GE0080B' USING REG-LK-BANCOS. */
            _.Call("GE0080B", REG_LK_BANCOS);

            /*" -3496- IF LK-BANCO-COD-RETORNO NOT EQUAL ' ' */

            if (REG_LK_BANCOS.LK_BANCO_COD_RETORNO != " ")
            {

                /*" -3498- MOVE 0 TO LK-BANCO-DV-BANCO. */
                _.Move(0, REG_LK_BANCOS.LK_BANCO_DV_BANCO);
            }


            /*" -3499- MOVE LK-SAP-COD-BANCO TO W-COD-BANCO */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_COD_BANCO, AREA_DE_WORK.W_BANKK.W_COD_BANCO);

            /*" -3500- MOVE LK-BANCO-DV-BANCO TO W-DV-BANCO. */
            _.Move(REG_LK_BANCOS.LK_BANCO_DV_BANCO, AREA_DE_WORK.W_BANKK.W_DV_BANCO);

            /*" -3502- MOVE LK-SAP-COD-AGENCIA TO W-COD-AGENCIA. */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_COD_AGENCIA, AREA_DE_WORK.W_BANKK.W_COD_AGENCIA);

            /*" -3506- MOVE W-BANKK TO BANKK-GERAL. */
            _.Move(AREA_DE_WORK.W_BANKK, W_REGISTRO_SIAS_GERAL.BANKK_GERAL);

            /*" -3507- IF LK-SAP-COD-BANCO EQUAL 341 */

            if (REGISTRO_LINKAGE_SAP.LK_SAP_COD_BANCO == 341)
            {

                /*" -3508- MOVE SPACES TO BKONT-GERAL */
                _.Move("", W_REGISTRO_SIAS_GERAL.BKONT_GERAL);

                /*" -3509- ELSE */
            }
            else
            {


                /*" -3519- MOVE LK-SAP-DV-AGENCIA TO BKONT-GERAL. */
                _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_DV_AGENCIA, W_REGISTRO_SIAS_GERAL.BKONT_GERAL);
            }


            /*" -3520- MOVE LK-SAP-NUM-CONTA TO W-NUM-CONTA-SAP. */
            _.Move(LK_SAP_NUM_CONTA, AREA_DE_WORK.W_CONTA_SAP.W_NUM_CONTA_SAP);

            /*" -3521- MOVE LK-SAP-DV-CONTA TO W-DV-CONTA-SAP. */
            _.Move(LK_SAP_DV_CONTA, AREA_DE_WORK.W_CONTA_SAP.W_DV_CONTA_SAP);

            /*" -3523- MOVE W-CONTA-SAP TO BANKN-GERAL. */
            _.Move(AREA_DE_WORK.W_CONTA_SAP, W_REGISTRO_SIAS_GERAL.BANKN_GERAL);

            /*" -3525- IF LK-SAP-COD-CONVENIO EQUAL 921286 AND LK-SAP-COD-BANCO EQUAL 104 */

            if (REGISTRO_LINKAGE_SAP.LK_SAP_COD_CONVENIO == 921286 && REGISTRO_LINKAGE_SAP.LK_SAP_COD_BANCO == 104)
            {

                /*" -3526- MOVE BANKN-GERAL(2:3) TO LK-SAP-OPERACAO-CONTA */
                _.Move(W_REGISTRO_SIAS_GERAL.BANKN_GERAL.Substring(2, 3), REGISTRO_LINKAGE_SAP.LK_SAP_OPERACAO_CONTA);

                /*" -3527- MOVE '0' TO BANKN-GERAL(1:1) */
                _.MoveAtPosition("0", W_REGISTRO_SIAS_GERAL.BANKN_GERAL, 1, 1);

                /*" -3528- MOVE '0' TO BANKN-GERAL(2:1) */
                _.MoveAtPosition("0", W_REGISTRO_SIAS_GERAL.BANKN_GERAL, 2, 1);

                /*" -3529- MOVE '0' TO BANKN-GERAL(3:1) */
                _.MoveAtPosition("0", W_REGISTRO_SIAS_GERAL.BANKN_GERAL, 3, 1);

                /*" -3533- MOVE '0' TO BANKN-GERAL(4:1). */
                _.MoveAtPosition("0", W_REGISTRO_SIAS_GERAL.BANKN_GERAL, 4, 1);
            }


            /*" -3534- IF LK-SAP-COD-BANCO NOT EQUAL 104 */

            if (REGISTRO_LINKAGE_SAP.LK_SAP_COD_BANCO != 104)
            {

                /*" -3535- MOVE '01' TO BKREF-GERAL */
                _.Move("01", W_REGISTRO_SIAS_GERAL.BKREF_GERAL);

                /*" -3536- ELSE */
            }
            else
            {


                /*" -3537- IF LK-SAP-COD-BANCO EQUAL 104 */

                if (REGISTRO_LINKAGE_SAP.LK_SAP_COD_BANCO == 104)
                {

                    /*" -3538- IF LK-SAP-OPERACAO-CONTA EQUAL 1 */

                    if (REGISTRO_LINKAGE_SAP.LK_SAP_OPERACAO_CONTA == 1)
                    {

                        /*" -3539- MOVE '001' TO BKREF-GERAL */
                        _.Move("001", W_REGISTRO_SIAS_GERAL.BKREF_GERAL);

                        /*" -3540- ELSE */
                    }
                    else
                    {


                        /*" -3541- IF LK-SAP-OPERACAO-CONTA EQUAL 2 */

                        if (REGISTRO_LINKAGE_SAP.LK_SAP_OPERACAO_CONTA == 2)
                        {

                            /*" -3542- MOVE '002' TO BKREF-GERAL */
                            _.Move("002", W_REGISTRO_SIAS_GERAL.BKREF_GERAL);

                            /*" -3543- ELSE */
                        }
                        else
                        {


                            /*" -3544- IF LK-SAP-OPERACAO-CONTA EQUAL 3 */

                            if (REGISTRO_LINKAGE_SAP.LK_SAP_OPERACAO_CONTA == 3)
                            {

                                /*" -3545- MOVE '003' TO BKREF-GERAL */
                                _.Move("003", W_REGISTRO_SIAS_GERAL.BKREF_GERAL);

                                /*" -3546- ELSE */
                            }
                            else
                            {


                                /*" -3547- IF LK-SAP-OPERACAO-CONTA EQUAL 6 */

                                if (REGISTRO_LINKAGE_SAP.LK_SAP_OPERACAO_CONTA == 6)
                                {

                                    /*" -3548- MOVE '006' TO BKREF-GERAL */
                                    _.Move("006", W_REGISTRO_SIAS_GERAL.BKREF_GERAL);

                                    /*" -3549- ELSE */
                                }
                                else
                                {


                                    /*" -3550- IF LK-SAP-OPERACAO-CONTA EQUAL 7 */

                                    if (REGISTRO_LINKAGE_SAP.LK_SAP_OPERACAO_CONTA == 7)
                                    {

                                        /*" -3551- MOVE '007' TO BKREF-GERAL */
                                        _.Move("007", W_REGISTRO_SIAS_GERAL.BKREF_GERAL);

                                        /*" -3552- ELSE */
                                    }
                                    else
                                    {


                                        /*" -3553- IF LK-SAP-OPERACAO-CONTA EQUAL 13 */

                                        if (REGISTRO_LINKAGE_SAP.LK_SAP_OPERACAO_CONTA == 13)
                                        {

                                            /*" -3554- MOVE '013' TO BKREF-GERAL */
                                            _.Move("013", W_REGISTRO_SIAS_GERAL.BKREF_GERAL);

                                            /*" -3555- ELSE */
                                        }
                                        else
                                        {


                                            /*" -3556- IF LK-SAP-OPERACAO-CONTA EQUAL 22 */

                                            if (REGISTRO_LINKAGE_SAP.LK_SAP_OPERACAO_CONTA == 22)
                                            {

                                                /*" -3557- MOVE '022' TO BKREF-GERAL */
                                                _.Move("022", W_REGISTRO_SIAS_GERAL.BKREF_GERAL);

                                                /*" -3558- ELSE */
                                            }
                                            else
                                            {


                                                /*" -3559- IF LK-SAP-OPERACAO-CONTA EQUAL 23 */

                                                if (REGISTRO_LINKAGE_SAP.LK_SAP_OPERACAO_CONTA == 23)
                                                {

                                                    /*" -3560- MOVE '023' TO BKREF-GERAL */
                                                    _.Move("023", W_REGISTRO_SIAS_GERAL.BKREF_GERAL);

                                                    /*" -3562- ELSE */
                                                }
                                                else
                                                {


                                                    /*" -3564- MOVE '000' TO BKREF-GERAL. */
                                                    _.Move("000", W_REGISTRO_SIAS_GERAL.BKREF_GERAL);
                                                }

                                            }

                                        }

                                    }

                                }

                            }

                        }

                    }

                }

            }


            /*" -3566- IF LK-SAP-COD-BANCO EQUAL 104 AND W-CHAVE-MONTA-SIACC-ESPECIAL EQUAL 'SIM' */

            if (REGISTRO_LINKAGE_SAP.LK_SAP_COD_BANCO == 104 && AREA_DE_WORK.W_CHAVE_MONTA_SIACC_ESPECIAL == "SIM")
            {

                /*" -3567- MOVE '003' TO BKREF-GERAL */
                _.Move("003", W_REGISTRO_SIAS_GERAL.BKREF_GERAL);

                /*" -3571- MOVE 'O' TO BANKN-GERAL. */
                _.Move("O", W_REGISTRO_SIAS_GERAL.BANKN_GERAL);
            }


            /*" -3575- MOVE ' ' TO KOINH-GERAL */
            _.Move(" ", W_REGISTRO_SIAS_GERAL.KOINH_GERAL);

            /*" -3577- MOVE 'X' TO XEZER-GERAL. */
            _.Move("X", W_REGISTRO_SIAS_GERAL.XEZER_GERAL);

            /*" -3578- MOVE 'ZCBO' TO ZCBO-TYPE-GERAL. */
            _.Move("ZCBO", W_REGISTRO_SIAS_GERAL.ZCBO_TYPE_GERAL);

            /*" -3592- MOVE SPACES TO ZCBO-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.ZCBO_GERAL);

            /*" -3593- IF W-LOTE-SIGLA-MODULO EQUAL 'CA' */

            if (AREA_DE_WORK.W_LOTE.W_LOTE_SIGLA_MODULO == "CA")
            {

                /*" -3594- MOVE ' ' TO ZWELS-GERAL */
                _.Move(" ", W_REGISTRO_SIAS_GERAL.ZWELS_GERAL);

                /*" -3596- ELSE */
            }
            else
            {


                /*" -3597- IF MOVDEBCE-COD-CONVENIO EQUAL 921286 */

                if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO == 921286)
                {

                    /*" -3598- MOVE 'UWXBZT' TO ZWELS-GERAL */
                    _.Move("UWXBZT", W_REGISTRO_SIAS_GERAL.ZWELS_GERAL);

                    /*" -3599- ELSE */
                }
                else
                {


                    /*" -3623- MOVE 'ISFECOTJG' TO ZWELS-GERAL. */
                    _.Move("ISFECOTJG", W_REGISTRO_SIAS_GERAL.ZWELS_GERAL);
                }

            }


            /*" -3624- IF (MOVDEBCE-COD-CONVENIO EQUAL 43350) */

            if ((MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO == 43350))
            {

                /*" -3625- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'IND' */

                if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "IND")
                {

                    /*" -3626- MOVE 'G' TO FPAG-GERAL */
                    _.Move("G", W_REGISTRO_SIAS_GERAL.FPAG_GERAL);

                    /*" -3627- ELSE */
                }
                else
                {


                    /*" -3628- MOVE 'O' TO FPAG-GERAL */
                    _.Move("O", W_REGISTRO_SIAS_GERAL.FPAG_GERAL);

                    /*" -3629- END-IF */
                }


                /*" -3630- ELSE */
            }
            else
            {


                /*" -3631- IF (MOVDEBCE-COD-CONVENIO EQUAL 921286) */

                if ((MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO == 921286))
                {

                    /*" -3632- MOVE '0' TO FPAG-GERAL */
                    _.Move("0", W_REGISTRO_SIAS_GERAL.FPAG_GERAL);

                    /*" -3633- ELSE */
                }
                else
                {


                    /*" -3636- IF (MOVDEBCE-COD-CONVENIO EQUAL 600119) OR (MOVDEBCE-COD-CONVENIO EQUAL 600120) OR (MOVDEBCE-COD-CONVENIO EQUAL 600123) */

                    if ((MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO == 600119) || (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO == 600120) || (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO == 600123))
                    {

                        /*" -3637- MOVE 'I' TO FPAG-GERAL */
                        _.Move("I", W_REGISTRO_SIAS_GERAL.FPAG_GERAL);

                        /*" -3638- ELSE */
                    }
                    else
                    {


                        /*" -3639- IF (MOVDEBCE-COD-CONVENIO EQUAL 600128) */

                        if ((MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO == 600128))
                        {

                            /*" -3640- MOVE 'S' TO FPAG-GERAL */
                            _.Move("S", W_REGISTRO_SIAS_GERAL.FPAG_GERAL);

                            /*" -3641- ELSE */
                        }
                        else
                        {


                            /*" -3644- MOVE '?' TO FPAG-GERAL. */
                            _.Move("?", W_REGISTRO_SIAS_GERAL.FPAG_GERAL);
                        }

                    }

                }

            }


            /*" -3645- IF CODOPE-GERAL EQUAL 'SIAS_09504' OR 'SIAS_09515' */

            if (W_REGISTRO_SIAS_GERAL.CODOPE_GERAL.In("SIAS_09504".ToString(), "SIAS_09515".ToString()))
            {

                /*" -3646- MOVE 'D' TO FREC-GERAL */
                _.Move("D", W_REGISTRO_SIAS_GERAL.FREC_GERAL);

                /*" -3647- ELSE */
            }
            else
            {


                /*" -3653- MOVE ' ' TO FREC-GERAL. */
                _.Move(" ", W_REGISTRO_SIAS_GERAL.FREC_GERAL);
            }


            /*" -3654- IF FORNECED-OPT-SIMPLES-FED EQUAL 'S' */

            if (FORNECED.DCLFORNECEDORES.FORNECED_OPT_SIMPLES_FED == "S")
            {

                /*" -3659- MOVE 'X' TO OP-SIMPL-FED-GERAL. */
                _.Move("X", W_REGISTRO_SIAS_GERAL.OP_SIMPL_FED_GERAL);
            }


            /*" -3660- MOVE '0000000000' TO TEL-NUMBER-GERAL. */
            _.Move("0000000000", W_REGISTRO_SIAS_GERAL.TEL_NUMBER_GERAL);

            /*" -3661- MOVE '0000000000' TO FAX-NUMBER-GERAL. */
            _.Move("0000000000", W_REGISTRO_SIAS_GERAL.FAX_NUMBER_GERAL);

            /*" -3661- MOVE 'IBS001' TO ZNIT-TYPE-GERAL. */
            _.Move("IBS001", W_REGISTRO_SIAS_GERAL.ZNIT_TYPE_GERAL);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_EXIT*/

        [StopWatch]
        /*" R3200-MONTA-PRESTADOR */
        private void R3200_MONTA_PRESTADOR(bool isPerform = false)
        {
            /*" -3668- IF W-CHAVE-ORIGEM-CADASTRO EQUAL 'ODS' */

            if (AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO == "ODS")
            {

                /*" -3669- IF OD001-IND-PESSOA EQUAL 'F' */

                if (OD001.DCLOD_PESSOA.OD001_IND_PESSOA == "F")
                {

                    /*" -3670- IF NULL-PF-INSC-PREFEITURA >= 0 */

                    if (NULL_PF_INSC_PREFEITURA >= 0)
                    {

                        /*" -3671- MOVE W-PF-INSC-PREFEITURA TO TAXNUM-INSCRM-GERAL */
                        _.Move(W_PF_INSC_PREFEITURA, W_REGISTRO_SIAS_GERAL.TAXNUM_INSCRM_GERAL);

                        /*" -3672- END-IF */
                    }


                    /*" -3673- IF NULL-PF-INSC-ESTADUAL >= 0 */

                    if (NULL_PF_INSC_ESTADUAL >= 0)
                    {

                        /*" -3674- MOVE W-PF-INSC-ESTADUAL TO TAXNUM-INSCRE-GERAL */
                        _.Move(W_PF_INSC_ESTADUAL, W_REGISTRO_SIAS_GERAL.TAXNUM_INSCRE_GERAL);

                        /*" -3675- END-IF */
                    }


                    /*" -3676- ELSE */
                }
                else
                {


                    /*" -3677- IF OD001-IND-PESSOA EQUAL 'J' */

                    if (OD001.DCLOD_PESSOA.OD001_IND_PESSOA == "J")
                    {

                        /*" -3678- IF NULL-PJ-INSC-PREFEITURA >= 0 */

                        if (NULL_PJ_INSC_PREFEITURA >= 0)
                        {

                            /*" -3679- MOVE W-PJ-INSC-PREFEITURA TO TAXNUM-INSCRM-GERAL */
                            _.Move(W_PJ_INSC_PREFEITURA, W_REGISTRO_SIAS_GERAL.TAXNUM_INSCRM_GERAL);

                            /*" -3680- END-IF */
                        }


                        /*" -3681- IF NULL-PJ-INSC-ESTADUAL >= 0 */

                        if (NULL_PJ_INSC_ESTADUAL >= 0)
                        {

                            /*" -3682- MOVE W-PJ-INSC-ESTADUAL TO TAXNUM-INSCRE-GERAL */
                            _.Move(W_PJ_INSC_ESTADUAL, W_REGISTRO_SIAS_GERAL.TAXNUM_INSCRE_GERAL);

                            /*" -3683- END-IF */
                        }


                        /*" -3684- ELSE */
                    }
                    else
                    {


                        /*" -3685- MOVE ALL '?21' TO TAXNUM-INSCRM-GERAL */
                        _.MoveAll("?21", W_REGISTRO_SIAS_GERAL.TAXNUM_INSCRM_GERAL);

                        /*" -3687- MOVE ALL '?22' TO TAXNUM-INSCRE-GERAL. */
                        _.MoveAll("?22", W_REGISTRO_SIAS_GERAL.TAXNUM_INSCRE_GERAL);
                    }

                }

            }


            /*" -3688- IF W-CHAVE-ORIGEM-CADASTRO EQUAL 'ODS' */

            if (AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO == "ODS")
            {

                /*" -3690- IF TAXNUM-INSCRM-GERAL EQUAL ' ' OR TAXNUM-INSCRE-GERAL EQUAL ' ' */

                if (W_REGISTRO_SIAS_GERAL.TAXNUM_INSCRM_GERAL == " " || W_REGISTRO_SIAS_GERAL.TAXNUM_INSCRE_GERAL == " ")
                {

                    /*" -3691- PERFORM R3210-LE-FORNECEDOR THRU R3210-EXIT */

                    R3210_LE_FORNECEDOR(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R3210_EXIT*/


                    /*" -3693- MOVE FORNECED-INSC-PREFEITURA TO TAXNUM-INSCRM-GERAL */
                    _.Move(FORNECED.DCLFORNECEDORES.FORNECED_INSC_PREFEITURA, W_REGISTRO_SIAS_GERAL.TAXNUM_INSCRM_GERAL);

                    /*" -3695- MOVE FORNECED-INSC-ESTADUAL TO TAXNUM-INSCRE-GERAL */
                    _.Move(FORNECED.DCLFORNECEDORES.FORNECED_INSC_ESTADUAL, W_REGISTRO_SIAS_GERAL.TAXNUM_INSCRE_GERAL);

                    /*" -3696- IF TAXNUM-INSCRM-GERAL EQUAL 0 */

                    if (W_REGISTRO_SIAS_GERAL.TAXNUM_INSCRM_GERAL == 0)
                    {

                        /*" -3697- MOVE ALL '?34' TO TAXNUM-INSCRM-GERAL */
                        _.MoveAll("?34", W_REGISTRO_SIAS_GERAL.TAXNUM_INSCRM_GERAL);

                        /*" -3698- END-IF */
                    }


                    /*" -3699- IF TAXNUM-INSCRE-GERAL EQUAL 0 */

                    if (W_REGISTRO_SIAS_GERAL.TAXNUM_INSCRE_GERAL == 0)
                    {

                        /*" -3700- MOVE ALL '?35' TO TAXNUM-INSCRE-GERAL */
                        _.MoveAll("?35", W_REGISTRO_SIAS_GERAL.TAXNUM_INSCRE_GERAL);

                        /*" -3702- END-IF. */
                    }

                }

            }


            /*" -3703- IF W-CHAVE-ORIGEM-CADASTRO EQUAL 'FORNECEDOR OU LOTERICO' */

            if (AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO == "FORNECEDOR OU LOTERICO")
            {

                /*" -3704- MOVE FORNECED-INSC-PREFEITURA TO TAXNUM-INSCRM-GERAL */
                _.Move(FORNECED.DCLFORNECEDORES.FORNECED_INSC_PREFEITURA, W_REGISTRO_SIAS_GERAL.TAXNUM_INSCRM_GERAL);

                /*" -3706- MOVE FORNECED-INSC-ESTADUAL TO TAXNUM-INSCRE-GERAL. */
                _.Move(FORNECED.DCLFORNECEDORES.FORNECED_INSC_ESTADUAL, W_REGISTRO_SIAS_GERAL.TAXNUM_INSCRE_GERAL);
            }


            /*" -3707- IF W-CHAVE-ORIGEM-CADASTRO EQUAL 'SEM CADASTRO' */

            if (AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO == "SEM CADASTRO")
            {

                /*" -3708- MOVE SPACES TO TAXNUM-INSCRM-GERAL */
                _.Move("", W_REGISTRO_SIAS_GERAL.TAXNUM_INSCRM_GERAL);

                /*" -3708- MOVE SPACES TO TAXNUM-INSCRE-GERAL. */
                _.Move("", W_REGISTRO_SIAS_GERAL.TAXNUM_INSCRE_GERAL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_EXIT*/

        [StopWatch]
        /*" R3210-LE-FORNECEDOR */
        private void R3210_LE_FORNECEDOR(bool isPerform = false)
        {
            /*" -3726- PERFORM R3210_LE_FORNECEDOR_DB_SELECT_1 */

            R3210_LE_FORNECEDOR_DB_SELECT_1();

            /*" -3729- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -3730- DISPLAY 'SISAP01B - ERRO ACESSO FORNECEDORES (2)' */
                _.Display($"SISAP01B - ERRO ACESSO FORNECEDORES (2)");

                /*" -3730- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3210-LE-FORNECEDOR-DB-SELECT-1 */
        public void R3210_LE_FORNECEDOR_DB_SELECT_1()
        {
            /*" -3726- EXEC SQL SELECT F.INSC_PREFEITURA AS 'INSCRICAO MUNICIPAL' , F.INSC_ESTADUAL AS 'INSCRICAO ESTADUAL' , F.OPT_SIMPLES_FED AS 'OPTANTE SIMPLES FERERAL' , F.OPT_SIMPLES_MUN AS 'OPTANTE SIMPLES MUNICIPAL' INTO :FORNECED-INSC-PREFEITURA, :FORNECED-INSC-ESTADUAL, :FORNECED-OPT-SIMPLES-FED, :FORNECED-OPT-SIMPLES-MUN FROM SEGUROS.FORNECEDORES F WHERE COD_FORNECEDOR = :SINISHIS-COD-PREST-SERVICO END-EXEC. */

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
            /*" -3737- MOVE LK-SAP-DES-BAIRRO TO CITY2-FSCL-GERAL */
            _.Move(LK_SAP_DES_BAIRRO, W_REGISTRO_SIAS_GERAL.CITY2_FSCL_GERAL);

            /*" -3738- MOVE LK-SAP-DES-BAIRRO TO CITY2-COR-GERAL */
            _.Move(LK_SAP_DES_BAIRRO, W_REGISTRO_SIAS_GERAL.CITY2_COR_GERAL);

            /*" -3739- MOVE LK-SAP-DES-CIDADE TO CITY1-FSCL-GERAL */
            _.Move(LK_SAP_DES_CIDADE, W_REGISTRO_SIAS_GERAL.CITY1_FSCL_GERAL);

            /*" -3740- MOVE LK-SAP-DES-CIDADE TO CITY1-COR-GERAL */
            _.Move(LK_SAP_DES_CIDADE, W_REGISTRO_SIAS_GERAL.CITY1_COR_GERAL);

            /*" -3741- MOVE LK-SAP-DES-SIGLA-UF TO REGION-FSCL-GERAL */
            _.Move(LK_SAP_DES_SIGLA_UF, W_REGISTRO_SIAS_GERAL.REGION_FSCL_GERAL);

            /*" -3743- MOVE LK-SAP-DES-SIGLA-UF TO REGION-COR-GERAL */
            _.Move(LK_SAP_DES_SIGLA_UF, W_REGISTRO_SIAS_GERAL.REGION_COR_GERAL);

            /*" -3744- IF LK-SAP-NUM-CEP EQUAL ZEROS */

            if (LK_SAP_NUM_CEP == 00)
            {

                /*" -3746- MOVE 99999 TO LK-SAP-NUM-CEP. */
                _.Move(99999, LK_SAP_NUM_CEP);
            }


            /*" -3749- IF LK-SAP-DES-COMPL-CEP(1:1) EQUAL ' ' OR LK-SAP-DES-COMPL-CEP(2:1) EQUAL ' ' OR LK-SAP-DES-COMPL-CEP(3:1) EQUAL ' ' */

            if (LK_SAP_DES_COMPL_CEP.Substring(1, 1) == " " || LK_SAP_DES_COMPL_CEP.Substring(2, 1) == " " || LK_SAP_DES_COMPL_CEP.Substring(3, 1) == " ")
            {

                /*" -3751- MOVE 000 TO LK-SAP-DES-COMPL-CEP. */
                _.Move(000, LK_SAP_DES_COMPL_CEP);
            }


            /*" -3752- MOVE LK-SAP-NUM-CEP TO W-CEP-ALFA-PARTE1 */
            _.Move(LK_SAP_NUM_CEP, W_CEP_ALFA.W_CEP_ALFA_PARTE1);

            /*" -3753- MOVE LK-SAP-DES-COMPL-CEP TO W-CEP-ALFA-PARTE2. */
            _.Move(LK_SAP_DES_COMPL_CEP, W_CEP_ALFA.W_CEP_ALFA_PARTE2);

            /*" -3754- MOVE W-CEP-ALFA TO POST-CODE1-FSCL-GERAL. */
            _.Move(W_CEP_ALFA, W_REGISTRO_SIAS_GERAL.POST_CODE1_FSCL_GERAL);

            /*" -3756- MOVE W-CEP-ALFA TO POST-CODE1-COR-GERAL . */
            _.Move(W_CEP_ALFA, W_REGISTRO_SIAS_GERAL.POST_CODE1_COR_GERAL);

            /*" -3757- MOVE LK-SAP-NUM-LOCAL TO HOUSE-NUM1-FSCL-GERAL */
            _.Move(LK_SAP_NUM_LOCAL, W_REGISTRO_SIAS_GERAL.HOUSE_NUM1_FSCL_GERAL);

            /*" -3759- MOVE LK-SAP-NUM-LOCAL TO HOUSE-NUM1-COR-GERAL */
            _.Move(LK_SAP_NUM_LOCAL, W_REGISTRO_SIAS_GERAL.HOUSE_NUM1_COR_GERAL);

            /*" -3760- MOVE LK-SAP-DES-COMPLEMENTO TO HOUSE-NUM2-FSCL-GERAL */
            _.Move(LK_SAP_DES_COMPLEMENTO, W_REGISTRO_SIAS_GERAL.HOUSE_NUM2_FSCL_GERAL);

            /*" -3761- MOVE LK-SAP-DES-COMPLEMENTO TO HOUSE-NUM2-COR-GERAL */
            _.Move(LK_SAP_DES_COMPLEMENTO, W_REGISTRO_SIAS_GERAL.HOUSE_NUM2_COR_GERAL);

            /*" -3762- MOVE LK-SAP-DES-LOGRADOURO TO STREET-FSCL-GERAL */
            _.Move(LK_SAP_DES_LOGRADOURO, W_REGISTRO_SIAS_GERAL.STREET_FSCL_GERAL);

            /*" -3764- MOVE LK-SAP-DES-LOGRADOURO TO STREET-COR-GERAL */
            _.Move(LK_SAP_DES_LOGRADOURO, W_REGISTRO_SIAS_GERAL.STREET_COR_GERAL);

            /*" -3766- MOVE LK-SAP-FAVORECIDO TO NAME-ORG1-GERAL . */
            _.Move(LK_SAP_FAVORECIDO, W_REGISTRO_SIAS_GERAL.NAME_ORG1_GERAL);

            /*" -3767- IF LK-SAP-COD-PROGRAMA EQUAL 'SI5067B' */

            if (LK_SAP_COD_PROGRAMA == "SI5067B")
            {

                /*" -3768- MOVE ' ' TO NATPERS-GERAL */
                _.Move(" ", W_REGISTRO_SIAS_GERAL.NATPERS_GERAL);

                /*" -3769- MOVE 'Z001' TO TITLE-MEDI-GERAL */
                _.Move("Z001", W_REGISTRO_SIAS_GERAL.TITLE_MEDI_GERAL);

                /*" -3771- GO TO R3300-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3300_EXIT*/ //GOTO
                return;
            }


            /*" -3772- IF LK-SAP-COD-PROGRAMA EQUAL 'FI0096B' OR 'SI5071B' */

            if (LK_SAP_COD_PROGRAMA.In("FI0096B", "SI5071B"))
            {

                /*" -3775- MOVE LK-SAP-MENSAGEM-RETORNO TO W-TIPO-E-CPF-CNPJ */
                _.Move(LK_SAP_MENSAGEM_RETORNO, W_TIPO_E_CPF_CNPJ);

                /*" -3776- IF W-SE-EH-PF-PJ EQUAL 'PF' */

                if (W_TIPO_E_CPF_CNPJ.W_SE_EH_PF_PJ == "PF")
                {

                    /*" -3777- MOVE 'X' TO NATPERS-GERAL */
                    _.Move("X", W_REGISTRO_SIAS_GERAL.NATPERS_GERAL);

                    /*" -3778- MOVE W-CPF-CNPJ-MUTUARIO TO W-NUM-CPF-NUM */
                    _.Move(W_TIPO_E_CPF_CNPJ.W_CPF_CNPJ_MUTUARIO, W_NUM_CPF_NUM);

                    /*" -3779- MOVE W-NUM-CPF-ALFA TO TAXNUM-CPF-GERAL */
                    _.Move(W_NUM_CPF_ALFA, W_REGISTRO_SIAS_GERAL.TAXNUM_CPF_GERAL);

                    /*" -3780- MOVE 'Z003' TO TITLE-MEDI-GERAL */
                    _.Move("Z003", W_REGISTRO_SIAS_GERAL.TITLE_MEDI_GERAL);

                    /*" -3781- ELSE */
                }
                else
                {


                    /*" -3782- MOVE ' ' TO NATPERS-GERAL */
                    _.Move(" ", W_REGISTRO_SIAS_GERAL.NATPERS_GERAL);

                    /*" -3783- MOVE W-CPF-CNPJ-MUTUARIO TO W-NUM-CNPJ-NUM */
                    _.Move(W_TIPO_E_CPF_CNPJ.W_CPF_CNPJ_MUTUARIO, W_NUM_CNPJ_NUM);

                    /*" -3784- MOVE W-NUM-CNPJ-ALFA TO TAXNUM-CNPJ-GERAL */
                    _.Move(W_NUM_CNPJ_ALFA, W_REGISTRO_SIAS_GERAL.TAXNUM_CNPJ_GERAL);

                    /*" -3785- MOVE '0003' TO TITLE-MEDI-GERAL */
                    _.Move("0003", W_REGISTRO_SIAS_GERAL.TITLE_MEDI_GERAL);

                    /*" -3786- END-IF */
                }


                /*" -3787- MOVE LK-SAP-FAVORECIDO TO NAME-ORG1-GERAL */
                _.Move(LK_SAP_FAVORECIDO, W_REGISTRO_SIAS_GERAL.NAME_ORG1_GERAL);

                /*" -3788- MOVE LK-SAP-FAVORECIDO TO CT0007S-NOME */
                _.Move(LK_SAP_FAVORECIDO, REG_LK_BANCOS.CT0007SW099.CT0007S_NOME);

                /*" -3789- CALL 'CT0007S' USING CT0007SW099 */
                _.Call("CT0007S", REG_LK_BANCOS.CT0007SW099);

                /*" -3790- IF CT0007S-SOBRENOME EQUAL ' ' */

                if (REG_LK_BANCOS.CT0007SW099.CT0007S_SOBRENOME == " ")
                {

                    /*" -3791- MOVE ALL '?A' TO NAME-LAST-GERAL */
                    _.MoveAll("?A", W_REGISTRO_SIAS_GERAL.NAME_LAST_GERAL);

                    /*" -3792- ELSE */
                }
                else
                {


                    /*" -3793- MOVE CT0007S-NOME1 TO NAME-FIRST-GERAL */
                    _.Move(REG_LK_BANCOS.CT0007SW099.CT0007S_NOME1, W_REGISTRO_SIAS_GERAL.NAME_FIRST_GERAL);

                    /*" -3794- MOVE CT0007S-SOBRENOME TO NAME-LAST-GERAL */
                    _.Move(REG_LK_BANCOS.CT0007SW099.CT0007S_SOBRENOME, W_REGISTRO_SIAS_GERAL.NAME_LAST_GERAL);

                    /*" -3795- END-IF */
                }


                /*" -3795- GO TO R3300-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3300_EXIT*/ //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3300_EXIT*/

        [StopWatch]
        /*" R3500-MONTA-ATTR-PAGTO-MOD-AP */
        private void R3500_MONTA_ATTR_PAGTO_MOD_AP(bool isPerform = false)
        {
            /*" -3807- MOVE CODOPE-GERAL TO WS-COD-EVENTO */
            _.Move(W_REGISTRO_SIAS_GERAL.CODOPE_GERAL, WS_COD_EVENTO);

            /*" -3808- MOVE 'ATR_FTEP' TO ATTR01-GERAL. */
            _.Move("ATR_FTEP", W_REGISTRO_SIAS_GERAL.ATTR01_GERAL);

            /*" -3813- MOVE SINISMES-COD-FONTE TO ATTRVAL01-GERAL. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE, W_REGISTRO_SIAS_GERAL.ATTRVAL01_GERAL);

            /*" -3820- MOVE ZEROS TO LKGE-RAMO-EMISSOR LKGE-MODALIDADE LKGE-PRODUTO LKGE-GRUPO-SUSEP LKGE-RAMO-SUSEP LKGE-SQLCODE. */
            _.Move(0, PARAMETROS_GE.LKGE_RAMO_EMISSOR, PARAMETROS_GE.LKGE_MODALIDADE, PARAMETROS_GE.LKGE_PRODUTO, PARAMETROS_GE.LKGE_GRUPO_SUSEP, PARAMETROS_GE.LKGE_RAMO_SUSEP, PARAMETROS_GE.LKGE_SQLCODE);

            /*" -3823- MOVE SPACES TO LKGE-INIVIGENCIA LKGE-MENSAGEM. */
            _.Move("", PARAMETROS_GE.LKGE_INIVIGENCIA, PARAMETROS_GE.LKGE_MENSAGEM);

            /*" -3825- MOVE SINISMES-RAMO TO LKGE-RAMO-EMISSOR. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO, PARAMETROS_GE.LKGE_RAMO_EMISSOR);

            /*" -3826- IF SINISMES-RAMO EQUAL 48 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO == 48)
            {

                /*" -3828- MOVE SINISMES-COD-PRODUTO TO LKGE-PRODUTO. */
                _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO, PARAMETROS_GE.LKGE_PRODUTO);
            }


            /*" -3840- MOVE HOST-SI-DATA-MOV-ABERTO TO LKGE-INIVIGENCIA. */
            _.Move(HOST_SI_DATA_MOV_ABERTO, PARAMETROS_GE.LKGE_INIVIGENCIA);

            /*" -3842- CALL 'GE0005S' USING PARAMETROS-GE. */
            _.Call("GE0005S", PARAMETROS_GE);

            /*" -3843- IF LKGE-MENSAGEM NOT EQUAL SPACES */

            if (!PARAMETROS_GE.LKGE_MENSAGEM.IsEmpty())
            {

                /*" -3844- DISPLAY 'R1250 - ERRO NO CALL DA SUB-ROTINA GE0005S' */
                _.Display($"R1250 - ERRO NO CALL DA SUB-ROTINA GE0005S");

                /*" -3845- DISPLAY 'ERRO ...... ' LKGE-MENSAGEM */
                _.Display($"ERRO ...... {PARAMETROS_GE.LKGE_MENSAGEM}");

                /*" -3846- DISPLAY 'SQLCODE ... ' LKGE-SQLCODE */
                _.Display($"SQLCODE ... {PARAMETROS_GE.LKGE_SQLCODE}");

                /*" -3847- DISPLAY 'RAMO ...... ' LKGE-RAMO-EMISSOR */
                _.Display($"RAMO ...... {PARAMETROS_GE.LKGE_RAMO_EMISSOR}");

                /*" -3848- DISPLAY 'PRODUTO ... ' LKGE-PRODUTO */
                _.Display($"PRODUTO ... {PARAMETROS_GE.LKGE_PRODUTO}");

                /*" -3849- DISPLAY 'VIGENCIA .. ' LKGE-INIVIGENCIA */
                _.Display($"VIGENCIA .. {PARAMETROS_GE.LKGE_INIVIGENCIA}");

                /*" -3850- MOVE LKGE-SQLCODE TO SQLCODE */
                _.Move(PARAMETROS_GE.LKGE_SQLCODE, DB.SQLCODE);

                /*" -3852- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -3853- MOVE 'ATR_RAMO' TO ATTR02-GERAL. */
            _.Move("ATR_RAMO", W_REGISTRO_SIAS_GERAL.ATTR02_GERAL);

            /*" -3855- MOVE LKGE-RAMO-SUSEP TO ATTRVAL02-GERAL. */
            _.Move(PARAMETROS_GE.LKGE_RAMO_SUSEP, W_REGISTRO_SIAS_GERAL.ATTRVAL02_GERAL);

            /*" -3856- MOVE 'ATR_PROD' TO ATTR03-GERAL. */
            _.Move("ATR_PROD", W_REGISTRO_SIAS_GERAL.ATTR03_GERAL);

            /*" -3857- MOVE 'L000' TO W-PRODUTO-SAP-L000. */
            _.Move("L000", AREA_DE_WORK.W_PRODUTO_SAP.W_PRODUTO_SAP_L000);

            /*" -3858- MOVE SINISMES-COD-PRODUTO TO W-PRODUTO-SAP-PRODUTO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO, AREA_DE_WORK.W_PRODUTO_SAP.W_PRODUTO_SAP_PRODUTO);

            /*" -3860- MOVE W-PRODUTO-SAP TO ATTRVAL03-GERAL. */
            _.Move(AREA_DE_WORK.W_PRODUTO_SAP, W_REGISTRO_SIAS_GERAL.ATTRVAL03_GERAL);

            /*" -3861- MOVE 'ATR_APOL' TO ATTR04-GERAL. */
            _.Move("ATR_APOL", W_REGISTRO_SIAS_GERAL.ATTR04_GERAL);

            /*" -3863- MOVE SINISHIS-NUM-APOLICE TO ATTRVAL04-GERAL. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOLICE, W_REGISTRO_SIAS_GERAL.ATTRVAL04_GERAL);

            /*" -3864- MOVE 'ATR_SNTR' TO ATTR05-GERAL. */
            _.Move("ATR_SNTR", W_REGISTRO_SIAS_GERAL.ATTR05_GERAL);

            /*" -3868- MOVE SINISHIS-NUM-APOL-SINISTRO TO ATTRVAL05-GERAL. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, W_REGISTRO_SIAS_GERAL.ATTRVAL05_GERAL);

            /*" -3872- IF CODOPE-GERAL EQUAL 'SIAS_09005' OR 'SIAS_09011' OR 'SIAS_09012' OR 'SIAS_09013' OR 'SIAS_09024' */

            if (W_REGISTRO_SIAS_GERAL.CODOPE_GERAL.In("SIAS_09005".ToString(), "SIAS_09011".ToString(), "SIAS_09012".ToString(), "SIAS_09013".ToString(), "SIAS_09024".ToString()))
            {

                /*" -3873- GO TO R3500-PULA-CBEN */

                R3500_PULA_CBEN(); //GOTO
                return;

                /*" -3874- ELSE */
            }
            else
            {


                /*" -3885- MOVE 'ATR_CBEN' TO ATTR06-GERAL. */
                _.Move("ATR_CBEN", W_REGISTRO_SIAS_GERAL.ATTR06_GERAL);
            }


            /*" -3886- IF W-CHAVE-ORIGEM-CADASTRO EQUAL 'ODS' */

            if (AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO == "ODS")
            {

                /*" -3887- IF NULL-NUM-CNPJ >= 0 */

                if (NULL_NUM_CNPJ >= 0)
                {

                    /*" -3888- MOVE W-NUM-CNPJ-ALFA TO ATTRVAL06-GERAL */
                    _.Move(W_NUM_CNPJ_ALFA, W_REGISTRO_SIAS_GERAL.ATTRVAL06_GERAL);

                    /*" -3889- ELSE */
                }
                else
                {


                    /*" -3890- IF NULL-NUM-CPF >= 0 */

                    if (NULL_NUM_CPF >= 0)
                    {

                        /*" -3891- MOVE W-NUM-CPF-ALFA TO ATTRVAL06-GERAL */
                        _.Move(W_NUM_CPF_ALFA, W_REGISTRO_SIAS_GERAL.ATTRVAL06_GERAL);

                        /*" -3892- ELSE */
                    }
                    else
                    {


                        /*" -3894- MOVE ALL '7' TO ATTRVAL06-GERAL. */
                        _.MoveAll("7", W_REGISTRO_SIAS_GERAL.ATTRVAL06_GERAL);
                    }

                }

            }


            /*" -3895- IF W-CHAVE-ORIGEM-CADASTRO EQUAL 'FORNECEDOR OU LOTERICO' */

            if (AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO == "FORNECEDOR OU LOTERICO")
            {

                /*" -3896- IF FORNECED-TIPO-PESSOA EQUAL 'F' */

                if (FORNECED.DCLFORNECEDORES.FORNECED_TIPO_PESSOA == "F")
                {

                    /*" -3897- MOVE W-NUM-CPF-ALFA TO ATTRVAL06-GERAL */
                    _.Move(W_NUM_CPF_ALFA, W_REGISTRO_SIAS_GERAL.ATTRVAL06_GERAL);

                    /*" -3898- ELSE */
                }
                else
                {


                    /*" -3900- MOVE W-NUM-CNPJ-ALFA TO ATTRVAL06-GERAL. */
                    _.Move(W_NUM_CNPJ_ALFA, W_REGISTRO_SIAS_GERAL.ATTRVAL06_GERAL);
                }

            }


            /*" -3901- IF W-CHAVE-ORIGEM-CADASTRO EQUAL 'SEM CADASTRO' */

            if (AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO == "SEM CADASTRO")
            {

                /*" -3901- MOVE ALL 'X' TO ATTRVAL06-GERAL. */
                _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL06_GERAL);
            }


        }

        [StopWatch]
        /*" R3500-PULA-CBEN */
        private void R3500_PULA_CBEN(bool isPerform = false)
        {
            /*" -3908- MOVE SPACES TO ATTR07-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTR07_GERAL);

            /*" -3912- MOVE SPACES TO ATTRVAL07-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTRVAL07_GERAL);

            /*" -3918- IF CODOPE-GERAL EQUAL 'SIAS_09002' OR 'SIAS_09003' OR 'SIAS_09004' OR 'SIAS_09006' OR 'SIAS_09007' OR 'SIAS_09008' OR 'SIAS_09009' OR 'SIAS_09015' OR 'SIAS_09022' OR 'SIAS_09025' */

            if (W_REGISTRO_SIAS_GERAL.CODOPE_GERAL.In("SIAS_09002".ToString(), "SIAS_09003".ToString(), "SIAS_09004".ToString(), "SIAS_09006".ToString(), "SIAS_09007".ToString(), "SIAS_09008".ToString(), "SIAS_09009".ToString(), "SIAS_09015".ToString(), "SIAS_09022".ToString(), "SIAS_09025".ToString()))
            {

                /*" -3919- MOVE 'ATR_PJUD' TO ATTR07-GERAL */
                _.Move("ATR_PJUD", W_REGISTRO_SIAS_GERAL.ATTR07_GERAL);

                /*" -3920- MOVE 0 TO HOST-COUNT */
                _.Move(0, HOST_COUNT);

                /*" -3921- PERFORM R3010-ACESSA-SCPJUD THRU R3010-EXIT */

                R3010_ACESSA_SCPJUD(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3010_EXIT*/


                /*" -3923- IF HOST-COUNT EQUAL 0 */

                if (HOST_COUNT == 0)
                {

                    /*" -3924- MOVE ALL 'X' TO ATTRVAL07-GERAL */
                    _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL07_GERAL);

                    /*" -3925- ELSE */
                }
                else
                {


                    /*" -3930- MOVE SIPROJUD-COD-PROCESSO-JURID TO ATTRVAL07-GERAL . */
                    _.Move(SIPROJUD.DCLSI_PROCESSO_JURID.SIPROJUD_COD_PROCESSO_JURID, W_REGISTRO_SIAS_GERAL.ATTRVAL07_GERAL);
                }

            }


            /*" -3931- MOVE SPACES TO ATTR08-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTR08_GERAL);

            /*" -3933- MOVE SPACES TO ATTRVAL08-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTRVAL08_GERAL);

            /*" -3939- IF CODOPE-GERAL EQUAL 'SIAS_09002' OR 'SIAS_09003' OR 'SIAS_09004' OR 'SIAS_09006' OR 'SIAS_09007' OR 'SIAS_09008' OR 'SIAS_09009' OR 'SIAS_09015' OR 'SIAS_09022' OR 'SIAS_09025' */

            if (W_REGISTRO_SIAS_GERAL.CODOPE_GERAL.In("SIAS_09002".ToString(), "SIAS_09003".ToString(), "SIAS_09004".ToString(), "SIAS_09006".ToString(), "SIAS_09007".ToString(), "SIAS_09008".ToString(), "SIAS_09009".ToString(), "SIAS_09015".ToString(), "SIAS_09022".ToString(), "SIAS_09025".ToString()))
            {

                /*" -3940- MOVE 'ATR_RJUD' TO ATTR08-GERAL */
                _.Move("ATR_RJUD", W_REGISTRO_SIAS_GERAL.ATTR08_GERAL);

                /*" -3944- MOVE ALL 'X' TO ATTRVAL08-GERAL. */
                _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL08_GERAL);
            }


            /*" -3946- IF CODOPE-GERAL EQUAL 'SIAS_09001' OR 'SIAS_09010' OR 'SIAS_09014' OR 'SIAS_09023' */

            if (W_REGISTRO_SIAS_GERAL.CODOPE_GERAL.In("SIAS_09001".ToString(), "SIAS_09010".ToString(), "SIAS_09014".ToString(), "SIAS_09023".ToString()))
            {

                /*" -3947- MOVE 'ATR_DTAV' TO ATTR09-GERAL */
                _.Move("ATR_DTAV", W_REGISTRO_SIAS_GERAL.ATTR09_GERAL);

                /*" -3948- MOVE W-DATA-AVISO-SIAS(1:4) TO W-DATA-AAAAMMDD-AAAA */
                _.Move(W_DATA_AVISO_SIAS.Substring(1, 4), AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_AAAA);

                /*" -3949- MOVE W-DATA-AVISO-SIAS(6:2) TO W-DATA-AAAAMMDD-MM */
                _.Move(W_DATA_AVISO_SIAS.Substring(6, 2), AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_MM);

                /*" -3950- MOVE W-DATA-AVISO-SIAS(9:2) TO W-DATA-AAAAMMDD-DD */
                _.Move(W_DATA_AVISO_SIAS.Substring(9, 2), AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_DD);

                /*" -3951- MOVE W-DATA-AAAAMMDD TO ATTRVAL09-GERAL */
                _.Move(AREA_DE_WORK.W_DATA_AAAAMMDD, W_REGISTRO_SIAS_GERAL.ATTRVAL09_GERAL);

                /*" -3952- ELSE */
            }
            else
            {


                /*" -3954- MOVE SPACES TO ATTR09-GERAL ATTRVAL09-GERAL. */
                _.Move("", W_REGISTRO_SIAS_GERAL.ATTR09_GERAL, W_REGISTRO_SIAS_GERAL.ATTRVAL09_GERAL);
            }


            /*" -3959- IF CODOPE-GERAL EQUAL 'SIAS_09003' OR 'SIAS_09004' OR 'SIAS_09008' OR 'SIAS_09015' OR 'SIAS_09025' */

            if (W_REGISTRO_SIAS_GERAL.CODOPE_GERAL.In("SIAS_09003".ToString(), "SIAS_09004".ToString(), "SIAS_09008".ToString(), "SIAS_09015".ToString(), "SIAS_09025".ToString()))
            {

                /*" -3960- MOVE 'ATR_PCEF' TO ATTR09-GERAL */
                _.Move("ATR_PCEF", W_REGISTRO_SIAS_GERAL.ATTR09_GERAL);

                /*" -3964- MOVE ALL 'X' TO ATTRVAL09-GERAL . */
                _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL09_GERAL);
            }


            /*" -3966- IF CODOPE-GERAL EQUAL 'SIAS_09001' OR 'SIAS_09010' OR 'SIAS_09014' OR 'SIAS_09023' */

            if (W_REGISTRO_SIAS_GERAL.CODOPE_GERAL.In("SIAS_09001".ToString(), "SIAS_09010".ToString(), "SIAS_09014".ToString(), "SIAS_09023".ToString()))
            {

                /*" -3967- MOVE 'ATR_DTCM' TO ATTR10-GERAL */
                _.Move("ATR_DTCM", W_REGISTRO_SIAS_GERAL.ATTR10_GERAL);

                /*" -3968- MOVE SINISMES-DATA-COMUNICADO(1:4) TO W-DATA-AAAAMMDD-AAAA */
                _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_COMUNICADO.Substring(1, 4), AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_AAAA);

                /*" -3969- MOVE SINISMES-DATA-COMUNICADO(6:2) TO W-DATA-AAAAMMDD-MM */
                _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_COMUNICADO.Substring(6, 2), AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_MM);

                /*" -3970- MOVE SINISMES-DATA-COMUNICADO(9:2) TO W-DATA-AAAAMMDD-DD */
                _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_COMUNICADO.Substring(9, 2), AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_DD);

                /*" -3971- MOVE W-DATA-AAAAMMDD TO ATTRVAL10-GERAL */
                _.Move(AREA_DE_WORK.W_DATA_AAAAMMDD, W_REGISTRO_SIAS_GERAL.ATTRVAL10_GERAL);

                /*" -3972- ELSE */
            }
            else
            {


                /*" -3974- MOVE SPACES TO ATTR10-GERAL ATTRVAL10-GERAL. */
                _.Move("", W_REGISTRO_SIAS_GERAL.ATTR10_GERAL, W_REGISTRO_SIAS_GERAL.ATTRVAL10_GERAL);
            }


            /*" -3979- IF CODOPE-GERAL EQUAL 'SIAS_09003' OR 'SIAS_09004' OR 'SIAS_09008' OR 'SIAS_09015' OR 'SIAS_09025' */

            if (W_REGISTRO_SIAS_GERAL.CODOPE_GERAL.In("SIAS_09003".ToString(), "SIAS_09004".ToString(), "SIAS_09008".ToString(), "SIAS_09015".ToString(), "SIAS_09025".ToString()))
            {

                /*" -3980- MOVE 'ATR_AGRU' TO ATTR10-GERAL */
                _.Move("ATR_AGRU", W_REGISTRO_SIAS_GERAL.ATTR10_GERAL);

                /*" -3981- MOVE ALL 'X' TO ATTRVAL10-GERAL */
                _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL10_GERAL);

                /*" -3982- MOVE 'ATTRVAL10-GERAL' TO W-ATTR-DESTINO */
                _.Move("ATTRVAL10-GERAL", AREA_DE_WORK.W_ATTR_DESTINO);

                /*" -3986- PERFORM R2060-MONTA-AGRUPA-PAGTO-SAP THRU R2060-EXIT. */

                R2060_MONTA_AGRUPA_PAGTO_SAP(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2060_EXIT*/

            }


            /*" -3987- MOVE SPACES TO ATTR11-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTR11_GERAL);

            /*" -3989- MOVE SPACES TO ATTRVAL11-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTRVAL11_GERAL);

            /*" -3994- IF CODOPE-GERAL EQUAL 'SIAS_09003' OR 'SIAS_09004' OR 'SIAS_09008' OR 'SIAS_09015' OR 'SIAS_09025' */

            if (W_REGISTRO_SIAS_GERAL.CODOPE_GERAL.In("SIAS_09003".ToString(), "SIAS_09004".ToString(), "SIAS_09008".ToString(), "SIAS_09015".ToString(), "SIAS_09025".ToString()))
            {

                /*" -3995- MOVE 'ATR_DTCA' TO ATTR11-GERAL */
                _.Move("ATR_DTCA", W_REGISTRO_SIAS_GERAL.ATTR11_GERAL);

                /*" -3999- MOVE ALL 'X' TO ATTRVAL11-GERAL. */
                _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL11_GERAL);
            }


            /*" -4000- MOVE SPACES TO ATTR12-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTR12_GERAL);

            /*" -4002- MOVE SPACES TO ATTRVAL12-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTRVAL12_GERAL);

            /*" -4007- IF CODOPE-GERAL EQUAL 'SIAS_09003' OR 'SIAS_09004' OR 'SIAS_09008' OR 'SIAS_09015' OR 'SIAS_09025' */

            if (W_REGISTRO_SIAS_GERAL.CODOPE_GERAL.In("SIAS_09003".ToString(), "SIAS_09004".ToString(), "SIAS_09008".ToString(), "SIAS_09015".ToString(), "SIAS_09025".ToString()))
            {

                /*" -4008- MOVE 'ATR_DTST' TO ATTR12-GERAL */
                _.Move("ATR_DTST", W_REGISTRO_SIAS_GERAL.ATTR12_GERAL);

                /*" -4010- MOVE ALL 'X' TO ATTRVAL12-GERAL . */
                _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL12_GERAL);
            }


            /*" -4017- IF CODOPE-GERAL EQUAL 'SIAS_09001' OR 'SIAS_09011' OR 'SIAS_09002' OR 'SIAS_09012' OR 'SIAS_09005' OR 'SIAS_09013' OR 'SIAS_09006' OR 'SIAS_09014' OR 'SIAS_09007' OR 'SIAS_09022' OR 'SIAS_09009' OR 'SIAS_09023' OR 'SIAS_09010' OR 'SIAS_09024' */

            if (W_REGISTRO_SIAS_GERAL.CODOPE_GERAL.In("SIAS_09001".ToString(), "SIAS_09011".ToString(), "SIAS_09002".ToString(), "SIAS_09012".ToString(), "SIAS_09005".ToString(), "SIAS_09013".ToString(), "SIAS_09006".ToString(), "SIAS_09014".ToString(), "SIAS_09007".ToString(), "SIAS_09022".ToString(), "SIAS_09009".ToString(), "SIAS_09023".ToString(), "SIAS_09010".ToString(), "SIAS_09024".ToString()))
            {

                /*" -4018- IF MOVDEBCE-COD-CONVENIO EQUAL 43350 */

                if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO == 43350)
                {

                    /*" -4019- MOVE 'ATR_PCEF' TO ATTR12-GERAL */
                    _.Move("ATR_PCEF", W_REGISTRO_SIAS_GERAL.ATTR12_GERAL);

                    /*" -4020- MOVE LK-SAP-COD-DOCUMENTO-SIACC TO ATTRVAL12-GERAL */
                    _.Move(LK_SAP_COD_DOCUMENTO_SIACC, W_REGISTRO_SIAS_GERAL.ATTRVAL12_GERAL);

                    /*" -4021- ELSE */
                }
                else
                {


                    /*" -4022- MOVE 'ATR_PCEF' TO ATTR12-GERAL */
                    _.Move("ATR_PCEF", W_REGISTRO_SIAS_GERAL.ATTR12_GERAL);

                    /*" -4026- MOVE ALL 'X' TO ATTRVAL12-GERAL. */
                    _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL12_GERAL);
                }

            }


            /*" -4027- MOVE SPACES TO ATTR13-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTR13_GERAL);

            /*" -4029- MOVE SPACES TO ATTRVAL13-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTRVAL13_GERAL);

            /*" -4034- IF CODOPE-GERAL EQUAL 'SIAS_09003' OR 'SIAS_09004' OR 'SIAS_09008' OR 'SIAS_09015' OR 'SIAS_09025' */

            if (W_REGISTRO_SIAS_GERAL.CODOPE_GERAL.In("SIAS_09003".ToString(), "SIAS_09004".ToString(), "SIAS_09008".ToString(), "SIAS_09015".ToString(), "SIAS_09025".ToString()))
            {

                /*" -4035- MOVE 'ATR_DTCS' TO ATTR13-GERAL */
                _.Move("ATR_DTCS", W_REGISTRO_SIAS_GERAL.ATTR13_GERAL);

                /*" -4036- MOVE ALL 'X' TO ATTRVAL13-GERAL */
                _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL13_GERAL);

                /*" -4037- ELSE */
            }
            else
            {


                /*" -4038- MOVE 'ATR_AGRU' TO ATTR13-GERAL */
                _.Move("ATR_AGRU", W_REGISTRO_SIAS_GERAL.ATTR13_GERAL);

                /*" -4039- MOVE ALL 'X' TO ATTRVAL13-GERAL */
                _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL13_GERAL);

                /*" -4040- MOVE 'ATTRVAL13-GERAL' TO W-ATTR-DESTINO */
                _.Move("ATTRVAL13-GERAL", AREA_DE_WORK.W_ATTR_DESTINO);

                /*" -4042- PERFORM R2060-MONTA-AGRUPA-PAGTO-SAP THRU R2060-EXIT. */

                R2060_MONTA_AGRUPA_PAGTO_SAP(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2060_EXIT*/

            }


            /*" -4043- IF MOVDEBCE-COD-CONVENIO NOT EQUAL 43350 */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO != 43350)
            {

                /*" -4044- MOVE 'ATR_INF1' TO ATTR14-GERAL */
                _.Move("ATR_INF1", W_REGISTRO_SIAS_GERAL.ATTR14_GERAL);

                /*" -4045- MOVE ALL 'X' TO ATTRVAL14-GERAL */
                _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL14_GERAL);

                /*" -4046- MOVE 'ATR_INF2' TO ATTR15-GERAL */
                _.Move("ATR_INF2", W_REGISTRO_SIAS_GERAL.ATTR15_GERAL);

                /*" -4048- MOVE ALL 'X' TO ATTRVAL15-GERAL . */
                _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL15_GERAL);
            }


            /*" -4049- IF MOVDEBCE-COD-CONVENIO EQUAL 43350 */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO == 43350)
            {

                /*" -4050- MOVE SPACES TO W-USO-EMPRESA-SIACC */
                _.Move("", AREA_DE_WORK.W_USO_EMPRESA_SIACC);

                /*" -4051- MOVE LK-SAP-USO-EMPRESA-SIACC TO W-USO-EMPRESA-SIACC */
                _.Move(LK_SAP_USO_EMPRESA_SIACC, AREA_DE_WORK.W_USO_EMPRESA_SIACC);

                /*" -4052- MOVE 'ATR_INF1' TO ATTR14-GERAL */
                _.Move("ATR_INF1", W_REGISTRO_SIAS_GERAL.ATTR14_GERAL);

                /*" -4053- MOVE W-ATTR-14 TO ATTRVAL14-GERAL */
                _.Move(AREA_DE_WORK.W_USO_EMPRESA_SIACC.W_ATTR_14, W_REGISTRO_SIAS_GERAL.ATTRVAL14_GERAL);

                /*" -4054- MOVE 'ATR_INF2' TO ATTR15-GERAL */
                _.Move("ATR_INF2", W_REGISTRO_SIAS_GERAL.ATTR15_GERAL);

                /*" -4067- MOVE W-ATTR-15 TO ATTRVAL15-GERAL . */
                _.Move(AREA_DE_WORK.W_USO_EMPRESA_SIACC.W_ATTR_15, W_REGISTRO_SIAS_GERAL.ATTRVAL15_GERAL);
            }


            /*" -4070- MOVE 'ATR_FPAG' TO ATTR16-GERAL . */
            _.Move("ATR_FPAG", W_REGISTRO_SIAS_GERAL.ATTR16_GERAL);

            /*" -4081- IF MOVDEBCE-COD-CONVENIO EQUAL 43350 */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO == 43350)
            {

                /*" -4082- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'IND' */

                if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "IND")
                {

                    /*" -4083- MOVE 'G' TO ATTRVAL16-GERAL */
                    _.Move("G", W_REGISTRO_SIAS_GERAL.ATTRVAL16_GERAL);

                    /*" -4084- ELSE */
                }
                else
                {


                    /*" -4085- MOVE 'O' TO ATTRVAL16-GERAL */
                    _.Move("O", W_REGISTRO_SIAS_GERAL.ATTRVAL16_GERAL);

                    /*" -4086- END-IF */
                }


                /*" -4088- ELSE */
            }
            else
            {


                /*" -4089- IF MOVDEBCE-COD-CONVENIO EQUAL 921286 */

                if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO == 921286)
                {

                    /*" -4090- MOVE '0' TO ATTRVAL16-GERAL */
                    _.Move("0", W_REGISTRO_SIAS_GERAL.ATTRVAL16_GERAL);

                    /*" -4092- ELSE */
                }
                else
                {


                    /*" -4093- IF MOVDEBCE-COD-CONVENIO EQUAL 600119 OR 600120 OR 600123 */

                    if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.In("600119", "600120", "600123"))
                    {

                        /*" -4094- MOVE 'I' TO ATTRVAL16-GERAL */
                        _.Move("I", W_REGISTRO_SIAS_GERAL.ATTRVAL16_GERAL);

                        /*" -4096- ELSE */
                    }
                    else
                    {


                        /*" -4099- IF MOVDEBCE-COD-CONVENIO EQUAL 600128 */

                        if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO == 600128)
                        {

                            /*" -4101- MOVE 'I' TO ATTRVAL16-GERAL */
                            _.Move("I", W_REGISTRO_SIAS_GERAL.ATTRVAL16_GERAL);

                            /*" -4102- ELSE */
                        }
                        else
                        {


                            /*" -4107- MOVE '?' TO ATTRVAL16-GERAL. */
                            _.Move("?", W_REGISTRO_SIAS_GERAL.ATTRVAL16_GERAL);
                        }

                    }

                }

            }


            /*" -4108- MOVE 'ATR_ATRB' TO ATTR17-GERAL. */
            _.Move("ATR_ATRB", W_REGISTRO_SIAS_GERAL.ATTR17_GERAL);

            /*" -4109- MOVE 'SI' TO W-ATTR17-SISTEMA. */
            _.Move("SI", AREA_DE_WORK.W_ATTR17.W_ATTR17_SISTEMA);

            /*" -4110- MOVE SINISHIS-COD-USUARIO TO W-ATTR17-USUARIO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_USUARIO, AREA_DE_WORK.W_ATTR17.W_ATTR17_USUARIO);

            /*" -4112- MOVE W-ATTR17 TO ATTRVAL17-GERAL. */
            _.Move(AREA_DE_WORK.W_ATTR17, W_REGISTRO_SIAS_GERAL.ATTRVAL17_GERAL);

            /*" -4113- MOVE SPACES TO ATTR18-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTR18_GERAL);

            /*" -4117- MOVE SPACES TO ATTRVAL18-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTRVAL18_GERAL);

            /*" -4118- MOVE 'NAO' TO W-CHAVE-ACHOU-NOTA-FISCAL */
            _.Move("NAO", AREA_DE_WORK.W_CHAVE_ACHOU_NOTA_FISCAL);

            /*" -4119- PERFORM R2030-PEGA-NOTA-FISCAL THRU R2030-EXIT */

            R2030_PEGA_NOTA_FISCAL(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R2030_EXIT*/


            /*" -4121- INITIALIZE W-ATTRVAL */
            _.Initialize(
                AREA_DE_WORK.W_ATTRVAL
            );

            /*" -4122- IF W-CHAVE-ACHOU-NOTA-FISCAL EQUAL 'SIM' */

            if (AREA_DE_WORK.W_CHAVE_ACHOU_NOTA_FISCAL == "SIM")
            {

                /*" -4123- MOVE 'ATR_NFIS' TO ATTR18-GERAL */
                _.Move("ATR_NFIS", W_REGISTRO_SIAS_GERAL.ATTR18_GERAL);

                /*" -4124- MOVE FIPADOFI-NUM-DOC-FISCAL TO ATTRVAL18-GERAL */
                _.Move(FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_NUM_DOC_FISCAL, W_REGISTRO_SIAS_GERAL.ATTRVAL18_GERAL);

                /*" -4125- ELSE */
            }
            else
            {


                /*" -4126- MOVE 'ATR_NFIS' TO ATTR18-GERAL */
                _.Move("ATR_NFIS", W_REGISTRO_SIAS_GERAL.ATTR18_GERAL);

                /*" -4127- MOVE ALL 'X' TO ATTRVAL18-GERAL */
                _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL18_GERAL);

                /*" -4128- MOVE ALL 'X' TO W-ATTRVAL */
                _.MoveAll("X", AREA_DE_WORK.W_ATTRVAL);

                /*" -4132- END-IF */
            }


            /*" -4133- IF W-CHAVE-ACHOU-NOTA-FISCAL EQUAL 'SIM' */

            if (AREA_DE_WORK.W_CHAVE_ACHOU_NOTA_FISCAL == "SIM")
            {

                /*" -4136- IF FIPADOFI-DATA-EMISSAO-DOC EQUAL SPACES OR '1212-12-12' OR LOW-VALUES */

                if (FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_DATA_EMISSAO_DOC.IsLowValues())
                {

                    /*" -4137- MOVE ALL 'X' TO W-ATTRVAL */
                    _.MoveAll("X", AREA_DE_WORK.W_ATTRVAL);

                    /*" -4138- ELSE */
                }
                else
                {


                    /*" -4142- STRING FIPADOFI-DATA-EMISSAO-DOC(1:4) FIPADOFI-DATA-EMISSAO-DOC(6:2) FIPADOFI-DATA-EMISSAO-DOC(9:2) DELIMITED BY SIZE INTO W-ATTRVAL */
                    #region STRING
                    var spl1 = FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_DATA_EMISSAO_DOC.Substring(1, 4).GetMoveValues();
                    var spl2 = FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_DATA_EMISSAO_DOC.Substring(6, 2).GetMoveValues();
                    var spl3 = FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_DATA_EMISSAO_DOC.Substring(9, 2).GetMoveValues();
                    var results4 = spl1 + spl2 + spl3;
                    _.Move(results4, AREA_DE_WORK.W_ATTRVAL);
                    #endregion

                    /*" -4143- END-IF */
                }


                /*" -4144- ELSE */
            }
            else
            {


                /*" -4145- MOVE ALL 'X' TO W-ATTRVAL */
                _.MoveAll("X", AREA_DE_WORK.W_ATTRVAL);

                /*" -4147- END-IF */
            }


            /*" -4148- EVALUATE WS-COD-EVENTO-NUM */
            switch (FILLER_18.WS_COD_EVENTO_NUM.Value.Trim())
            {

                /*" -4149- WHEN '09002' */
                case "09002":

                    /*" -4150- WHEN '09006' */
                    break;
                case "09006":

                /*" -4151- WHEN '09009' */
                case "09009":

                    /*" -4152- WHEN '09022' */
                    break;
                case "09022":

                /*" -4153- WHEN '09001' */
                case "09001":

                    /*" -4154- WHEN '09010' */
                    break;
                case "09010":

                /*" -4155- WHEN '09014' */
                case "09014":

                    /*" -4156- WHEN '09023' */
                    break;
                case "09023":

                /*" -4157- WHEN '09007' */
                case "09007":

                    /*" -4158- MOVE 'ATR_DTNF' TO ATTR37-GERAL */
                    _.Move("ATR_DTNF", W_REGISTRO_SIAS_GERAL.ATTR37_GERAL);

                    /*" -4159- MOVE W-ATTRVAL TO ATTRVAL37-GERAL */
                    _.Move(AREA_DE_WORK.W_ATTRVAL, W_REGISTRO_SIAS_GERAL.ATTRVAL37_GERAL);

                    /*" -4160- WHEN '09003' */
                    break;
                case "09003":

                /*" -4161- WHEN '09004' */
                case "09004":

                    /*" -4162- WHEN '09008' */
                    break;
                case "09008":

                /*" -4163- WHEN '09015' */
                case "09015":

                    /*" -4164- WHEN '09025' */
                    break;
                case "09025":

                    /*" -4165- MOVE 'ATR_DTNF' TO ATTR40-GERAL */
                    _.Move("ATR_DTNF", W_REGISTRO_SIAS_GERAL.ATTR40_GERAL);

                    /*" -4166- MOVE W-ATTRVAL TO ATTRVAL40-GERAL */
                    _.Move(AREA_DE_WORK.W_ATTRVAL, W_REGISTRO_SIAS_GERAL.ATTRVAL40_GERAL);

                    /*" -4167- WHEN '09017' */
                    break;
                case "09017":

                /*" -4168- WHEN '09021' */
                case "09021":

                    /*" -4169- WHEN '09026' */
                    break;
                case "09026":

                    /*" -4170- MOVE 'ATR_DTNF' TO ATTR11-GERAL */
                    _.Move("ATR_DTNF", W_REGISTRO_SIAS_GERAL.ATTR11_GERAL);

                    /*" -4171- MOVE W-ATTRVAL TO ATTRVAL11-GERAL */
                    _.Move(AREA_DE_WORK.W_ATTRVAL, W_REGISTRO_SIAS_GERAL.ATTRVAL11_GERAL);

                    /*" -4172- WHEN '09018' */
                    break;
                case "09018":

                /*" -4173- WHEN '09020' */
                case "09020":

                    /*" -4174- WHEN '09019' */
                    break;
                case "09019":

                /*" -4175- WHEN '09005' */
                case "09005":

                    /*" -4176- WHEN '09011' */
                    break;
                case "09011":

                /*" -4177- WHEN '09012' */
                case "09012":

                    /*" -4178- WHEN '09013' */
                    break;
                case "09013":

                /*" -4179- WHEN '09024' */
                case "09024":

                    /*" -4180- MOVE 'ATR_DTNF' TO ATTR10-GERAL */
                    _.Move("ATR_DTNF", W_REGISTRO_SIAS_GERAL.ATTR10_GERAL);

                    /*" -4181- MOVE W-ATTRVAL TO ATTRVAL10-GERAL */
                    _.Move(AREA_DE_WORK.W_ATTRVAL, W_REGISTRO_SIAS_GERAL.ATTRVAL10_GERAL);

                    /*" -4182- WHEN '09016' */
                    break;
                case "09016":

                    /*" -4183- MOVE 'ATR_DTNF' TO ATTR09-GERAL */
                    _.Move("ATR_DTNF", W_REGISTRO_SIAS_GERAL.ATTR09_GERAL);

                    /*" -4184- MOVE W-ATTRVAL TO ATTRVAL09-GERAL */
                    _.Move(AREA_DE_WORK.W_ATTRVAL, W_REGISTRO_SIAS_GERAL.ATTRVAL09_GERAL);

                    /*" -4188- END-EVALUATE */
                    break;
            }


            /*" -4189- MOVE 'ATR_TSER' TO W-ATTR */
            _.Move("ATR_TSER", AREA_DE_WORK.W_ATTR);

            /*" -4191- MOVE ALL 'X' TO W-ATTRVAL */
            _.MoveAll("X", AREA_DE_WORK.W_ATTRVAL);

            /*" -4192- EVALUATE WS-COD-EVENTO-NUM */
            switch (FILLER_18.WS_COD_EVENTO_NUM.Value.Trim())
            {

                /*" -4193- WHEN '09001' */
                case "09001":

                    /*" -4194- WHEN '09010' */
                    break;
                case "09010":

                /*" -4195- WHEN '09014' */
                case "09014":

                    /*" -4196- WHEN '09023' */
                    break;
                case "09023":

                    /*" -4197- MOVE W-ATTR TO ATTR40-GERAL */
                    _.Move(AREA_DE_WORK.W_ATTR, W_REGISTRO_SIAS_GERAL.ATTR40_GERAL);

                    /*" -4198- MOVE W-ATTRVAL TO ATTRVAL40-GERAL */
                    _.Move(AREA_DE_WORK.W_ATTRVAL, W_REGISTRO_SIAS_GERAL.ATTRVAL40_GERAL);

                    /*" -4199- WHEN '09002' */
                    break;
                case "09002":

                /*" -4200- WHEN '09006' */
                case "09006":

                    /*" -4201- WHEN '09007' */
                    break;
                case "09007":

                /*" -4202- WHEN '09009' */
                case "09009":

                    /*" -4203- WHEN '09022' */
                    break;
                case "09022":

                    /*" -4204- MOVE W-ATTR TO ATTR40-GERAL */
                    _.Move(AREA_DE_WORK.W_ATTR, W_REGISTRO_SIAS_GERAL.ATTR40_GERAL);

                    /*" -4205- MOVE W-ATTRVAL TO ATTRVAL40-GERAL */
                    _.Move(AREA_DE_WORK.W_ATTRVAL, W_REGISTRO_SIAS_GERAL.ATTRVAL40_GERAL);

                    /*" -4206- WHEN '09005' */
                    break;
                case "09005":

                /*" -4207- WHEN '09011' */
                case "09011":

                    /*" -4208- WHEN '09012' */
                    break;
                case "09012":

                /*" -4209- WHEN '09013' */
                case "09013":

                    /*" -4210- WHEN '09024' */
                    break;
                case "09024":

                    /*" -4211- MOVE W-ATTR TO ATTR37-GERAL */
                    _.Move(AREA_DE_WORK.W_ATTR, W_REGISTRO_SIAS_GERAL.ATTR37_GERAL);

                    /*" -4212- MOVE W-ATTRVAL TO ATTRVAL37-GERAL */
                    _.Move(AREA_DE_WORK.W_ATTRVAL, W_REGISTRO_SIAS_GERAL.ATTRVAL37_GERAL);

                    /*" -4213- WHEN '09003' */
                    break;
                case "09003":

                /*" -4214- WHEN '09004' */
                case "09004":

                    /*" -4215- WHEN '09008' */
                    break;
                case "09008":

                /*" -4216- WHEN '09015' */
                case "09015":

                    /*" -4217- WHEN '09025' */
                    break;
                case "09025":

                    /*" -4218- MOVE W-ATTR TO ATTR43-GERAL */
                    _.Move(AREA_DE_WORK.W_ATTR, W_REGISTRO_SIAS_GERAL.ATTR43_GERAL);

                    /*" -4219- MOVE W-ATTRVAL TO ATTRVAL43-GERAL */
                    _.Move(AREA_DE_WORK.W_ATTRVAL, W_REGISTRO_SIAS_GERAL.ATTRVAL43_GERAL);

                    /*" -4222- END-EVALUATE */
                    break;
            }


            /*" -4223- MOVE 'ATR_IRIQ' TO W-ATTR */
            _.Move("ATR_IRIQ", AREA_DE_WORK.W_ATTR);

            /*" -4225- MOVE ALL 'X' TO W-ATTRVAL */
            _.MoveAll("X", AREA_DE_WORK.W_ATTRVAL);

            /*" -4226- EVALUATE WS-COD-EVENTO-NUM */
            switch (FILLER_18.WS_COD_EVENTO_NUM.Value.Trim())
            {

                /*" -4227- WHEN '09001' */
                case "09001":

                    /*" -4228- WHEN '09010' */
                    break;
                case "09010":

                /*" -4229- WHEN '09014' */
                case "09014":

                    /*" -4230- WHEN '09023' */
                    break;
                case "09023":

                    /*" -4231- MOVE W-ATTR TO ATTR07-GERAL */
                    _.Move(AREA_DE_WORK.W_ATTR, W_REGISTRO_SIAS_GERAL.ATTR07_GERAL);

                    /*" -4232- MOVE W-ATTRVAL TO ATTRVAL07-GERAL */
                    _.Move(AREA_DE_WORK.W_ATTRVAL, W_REGISTRO_SIAS_GERAL.ATTRVAL07_GERAL);

                    /*" -4233- WHEN '09002' */
                    break;
                case "09002":

                /*" -4234- WHEN '09006' */
                case "09006":

                    /*" -4235- WHEN '09007' */
                    break;
                case "09007":

                /*" -4236- WHEN '09009' */
                case "09009":

                    /*" -4237- WHEN '09022' */
                    break;
                case "09022":

                    /*" -4238- MOVE W-ATTR TO ATTR09-GERAL */
                    _.Move(AREA_DE_WORK.W_ATTR, W_REGISTRO_SIAS_GERAL.ATTR09_GERAL);

                    /*" -4239- MOVE W-ATTRVAL TO ATTRVAL09-GERAL */
                    _.Move(AREA_DE_WORK.W_ATTRVAL, W_REGISTRO_SIAS_GERAL.ATTRVAL09_GERAL);

                    /*" -4240- WHEN '09005' */
                    break;
                case "09005":

                /*" -4241- WHEN '09011' */
                case "09011":

                    /*" -4242- WHEN '09012' */
                    break;
                case "09012":

                /*" -4243- WHEN '09013' */
                case "09013":

                    /*" -4244- WHEN '09024' */
                    break;
                case "09024":

                    /*" -4245- MOVE W-ATTR TO ATTR06-GERAL */
                    _.Move(AREA_DE_WORK.W_ATTR, W_REGISTRO_SIAS_GERAL.ATTR06_GERAL);

                    /*" -4246- MOVE W-ATTRVAL TO ATTRVAL06-GERAL */
                    _.Move(AREA_DE_WORK.W_ATTRVAL, W_REGISTRO_SIAS_GERAL.ATTRVAL06_GERAL);

                    /*" -4247- WHEN '09003' */
                    break;
                case "09003":

                /*" -4248- WHEN '09004' */
                case "09004":

                    /*" -4249- WHEN '09008' */
                    break;
                case "09008":

                /*" -4250- WHEN '09015' */
                case "09015":

                    /*" -4251- WHEN '09025' */
                    break;
                case "09025":

                    /*" -4252- MOVE W-ATTR TO ATTR36-GERAL */
                    _.Move(AREA_DE_WORK.W_ATTR, W_REGISTRO_SIAS_GERAL.ATTR36_GERAL);

                    /*" -4253- MOVE W-ATTRVAL TO ATTRVAL36-GERAL */
                    _.Move(AREA_DE_WORK.W_ATTRVAL, W_REGISTRO_SIAS_GERAL.ATTRVAL36_GERAL);

                    /*" -4258- END-EVALUATE. */
                    break;
            }


            /*" -4261- MOVE 'ATR_DVEN' TO ATTR19-GERAL. */
            _.Move("ATR_DVEN", W_REGISTRO_SIAS_GERAL.ATTR19_GERAL);

            /*" -4263- MOVE MOVDEBCE-DATA-VENCIMENTO(1:4) TO W-DATA-AAAAMMDD-AAAA. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO.Substring(1, 4), AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_AAAA);

            /*" -4265- MOVE MOVDEBCE-DATA-VENCIMENTO(6:2) TO W-DATA-AAAAMMDD-MM. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO.Substring(6, 2), AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_MM);

            /*" -4267- MOVE MOVDEBCE-DATA-VENCIMENTO(9:2) TO W-DATA-AAAAMMDD-DD. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO.Substring(9, 2), AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_DD);

            /*" -4280- MOVE W-DATA-AAAAMMDD TO ATTRVAL19-GERAL. */
            _.Move(AREA_DE_WORK.W_DATA_AAAAMMDD, W_REGISTRO_SIAS_GERAL.ATTRVAL19_GERAL);

            /*" -4281- MOVE 'ATR_CDIJ' TO ATTR20-GERAL */
            _.Move("ATR_CDIJ", W_REGISTRO_SIAS_GERAL.ATTR20_GERAL);

            /*" -4283- MOVE ALL 'X' TO ATTRVAL20-GERAL. */
            _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL20_GERAL);

            /*" -4284- MOVE 'ATR_CDIR' TO ATTR21-GERAL */
            _.Move("ATR_CDIR", W_REGISTRO_SIAS_GERAL.ATTR21_GERAL);

            /*" -4288- MOVE ALL 'X' TO ATTRVAL21-GERAL. */
            _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL21_GERAL);

            /*" -4289- MOVE 'ATR_CDIS' TO ATTR22-GERAL. */
            _.Move("ATR_CDIS", W_REGISTRO_SIAS_GERAL.ATTR22_GERAL);

            /*" -4293- MOVE ALL 'X' TO ATTRVAL22-GERAL. */
            _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL22_GERAL);

            /*" -4294- MOVE 'ATR_CDIN' TO ATTR23-GERAL. */
            _.Move("ATR_CDIN", W_REGISTRO_SIAS_GERAL.ATTR23_GERAL);

            /*" -4298- MOVE ALL 'X' TO ATTRVAL23-GERAL. */
            _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL23_GERAL);

            /*" -4299- MOVE 'ATR_CDPS' TO ATTR24-GERAL. */
            _.Move("ATR_CDPS", W_REGISTRO_SIAS_GERAL.ATTR24_GERAL);

            /*" -4303- MOVE ALL 'X' TO ATTRVAL24-GERAL. */
            _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL24_GERAL);

            /*" -4304- MOVE 'ATR_CDCF' TO ATTR25-GERAL. */
            _.Move("ATR_CDCF", W_REGISTRO_SIAS_GERAL.ATTR25_GERAL);

            /*" -4308- MOVE ALL 'X' TO ATTRVAL25-GERAL. */
            _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL25_GERAL);

            /*" -4309- MOVE 'ATR_CDCS' TO ATTR26-GERAL. */
            _.Move("ATR_CDCS", W_REGISTRO_SIAS_GERAL.ATTR26_GERAL);

            /*" -4314- MOVE ALL 'X' TO ATTRVAL26-GERAL. */
            _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL26_GERAL);

            /*" -4315- MOVE 'ATR_CDIP' TO ATTR27-GERAL. */
            _.Move("ATR_CDIP", W_REGISTRO_SIAS_GERAL.ATTR27_GERAL);

            /*" -4319- MOVE ALL 'X' TO ATTRVAL27-GERAL. */
            _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL27_GERAL);

            /*" -4320- MOVE 'ATR_CDCC' TO ATTR28-GERAL. */
            _.Move("ATR_CDCC", W_REGISTRO_SIAS_GERAL.ATTR28_GERAL);

            /*" -4324- MOVE MOVDEBCE-COD-CONVENIO TO ATTRVAL28-GERAL. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO, W_REGISTRO_SIAS_GERAL.ATTRVAL28_GERAL);

            /*" -4325- MOVE 'ATR_TPCV' TO ATTR29-GERAL. */
            _.Move("ATR_TPCV", W_REGISTRO_SIAS_GERAL.ATTR29_GERAL);

            /*" -4326- IF (MOVDEBCE-COD-CONVENIO EQUAL 43350) */

            if ((MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO == 43350))
            {

                /*" -4327- MOVE 'A' TO ATTRVAL29-GERAL */
                _.Move("A", W_REGISTRO_SIAS_GERAL.ATTRVAL29_GERAL);

                /*" -4328- ELSE */
            }
            else
            {


                /*" -4329- IF (MOVDEBCE-COD-CONVENIO EQUAL 921286) */

                if ((MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO == 921286))
                {

                    /*" -4330- MOVE ALL 'X' TO ATTRVAL29-GERAL */
                    _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL29_GERAL);

                    /*" -4331- ELSE */
                }
                else
                {


                    /*" -4335- MOVE 'B' TO ATTRVAL29-GERAL . */
                    _.Move("B", W_REGISTRO_SIAS_GERAL.ATTRVAL29_GERAL);
                }

            }


            /*" -4339- MOVE 'ATR_COMP' TO ATTR30-GERAL. */
            _.Move("ATR_COMP", W_REGISTRO_SIAS_GERAL.ATTR30_GERAL);

            /*" -4342- MOVE ALL 'X' TO ATTRVAL30-GERAL . */
            _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL30_GERAL);

            /*" -4343- MOVE 'ATR_SERV' TO ATTR31-GERAL. */
            _.Move("ATR_SERV", W_REGISTRO_SIAS_GERAL.ATTR31_GERAL);

            /*" -4345- MOVE ALL 'X' TO ATTRVAL31-GERAL. */
            _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL31_GERAL);

            /*" -4346- MOVE 'NAO' TO W-CHAVE-ACHOU-FORNECEDOR */
            _.Move("NAO", AREA_DE_WORK.W_CHAVE_ACHOU_FORNECEDOR);

            /*" -4347- PERFORM R2040-PEGA-SERVICO THRU R2040-EXIT */

            R2040_PEGA_SERVICO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R2040_EXIT*/


            /*" -4348- IF W-CHAVE-ACHOU-FORNECEDOR EQUAL 'SIM' */

            if (AREA_DE_WORK.W_CHAVE_ACHOU_FORNECEDOR == "SIM")
            {

                /*" -4350- IF SINISCAP-COD-NAT-RENDIMENTO = 0 OR W-CHAVE-TEM-CAPA-LOTE = 'NAO' */

                if (SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_NAT_RENDIMENTO == 0 || AREA_DE_WORK.W_CHAVE_TEM_CAPA_LOTE == "NAO")
                {

                    /*" -4351- EVALUATE FORNECED-COD-SERVICO-ISS */
                    switch (FORNECED.DCLFORNECEDORES.FORNECED_COD_SERVICO_ISS.Value)
                    {

                        /*" -4352- WHEN 20 */
                        case 20:

                            /*" -4353- MOVE '1709' TO ATTRVAL31-GERAL */
                            _.Move("1709", W_REGISTRO_SIAS_GERAL.ATTRVAL31_GERAL);

                            /*" -4354- WHEN 92 */
                            break;
                        case 92:

                            /*" -4355- MOVE '0705' TO ATTRVAL31-GERAL */
                            _.Move("0705", W_REGISTRO_SIAS_GERAL.ATTRVAL31_GERAL);

                            /*" -4356- WHEN 93 */
                            break;
                        case 93:

                            /*" -4357- MOVE '1405' TO ATTRVAL31-GERAL */
                            _.Move("1405", W_REGISTRO_SIAS_GERAL.ATTRVAL31_GERAL);

                            /*" -4359- WHEN OTHER */
                            break;
                        default:

                            /*" -4360- MOVE '????' TO ATTRVAL31-GERAL */
                            _.Move("????", W_REGISTRO_SIAS_GERAL.ATTRVAL31_GERAL);

                            /*" -4361- END-EVALUATE */
                            break;
                    }


                    /*" -4362- ELSE */
                }
                else
                {


                    /*" -4363- IF SINISCAP-COD-SERVICO-CONTABIL(01:4) NOT EQUAL SPACES */

                    if (SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_SERVICO_CONTABIL.Substring(01, 4) != string.Empty)
                    {

                        /*" -4365- MOVE SINISCAP-COD-SERVICO-CONTABIL(01:4) TO ATTRVAL31-GERAL */
                        _.Move(SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_SERVICO_CONTABIL.Substring(1, 4), W_REGISTRO_SIAS_GERAL.ATTRVAL31_GERAL);

                        /*" -4366- END-IF */
                    }


                    /*" -4367- END-IF */
                }


                /*" -4369- END-IF */
            }


            /*" -4370- MOVE SPACES TO ATTR32-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTR32_GERAL);

            /*" -4372- MOVE SPACES TO ATTRVAL32-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTRVAL32_GERAL);

            /*" -4373- IF W-CHAVE-ACHOU-NOTA-FISCAL EQUAL 'SIM' */

            if (AREA_DE_WORK.W_CHAVE_ACHOU_NOTA_FISCAL == "SIM")
            {

                /*" -4374- MOVE 'ATR_SENF' TO ATTR32-GERAL */
                _.Move("ATR_SENF", W_REGISTRO_SIAS_GERAL.ATTR32_GERAL);

                /*" -4375- IF FIPADOFI-SERIE-DOC-FISCAL NOT EQUAL SPACES */

                if (!FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_SERIE_DOC_FISCAL.IsEmpty())
                {

                    /*" -4377- MOVE FIPADOFI-SERIE-DOC-FISCAL(1:5) TO ATTRVAL32-GERAL */
                    _.Move(FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_SERIE_DOC_FISCAL.Substring(1, 5), W_REGISTRO_SIAS_GERAL.ATTRVAL32_GERAL);

                    /*" -4378- ELSE */
                }
                else
                {


                    /*" -4379- MOVE ALL 'X' TO ATTRVAL32-GERAL */
                    _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL32_GERAL);

                    /*" -4380- END-IF */
                }


                /*" -4381- ELSE */
            }
            else
            {


                /*" -4382- MOVE 'ATR_SENF' TO ATTR32-GERAL */
                _.Move("ATR_SENF", W_REGISTRO_SIAS_GERAL.ATTR32_GERAL);

                /*" -4384- MOVE ALL 'X' TO ATTRVAL32-GERAL. */
                _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL32_GERAL);
            }


            /*" -4385- MOVE SPACES TO ATTR33-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTR33_GERAL);

            /*" -4387- MOVE SPACES TO ATTRVAL33-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTRVAL33_GERAL);

            /*" -4388- MOVE 'NAO' TO W-CHAVE-ACHOU-FONTE-IMPOSTO. */
            _.Move("NAO", AREA_DE_WORK.W_CHAVE_ACHOU_FONTE_IMPOSTO);

            /*" -4389- PERFORM R2050-FONTE-RECOLHE-IMPOSTO THRU R2050-EXIT */

            R2050_FONTE_RECOLHE_IMPOSTO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R2050_EXIT*/


            /*" -4390- IF W-CHAVE-ACHOU-FONTE-IMPOSTO EQUAL 'SIM' */

            if (AREA_DE_WORK.W_CHAVE_ACHOU_FONTE_IMPOSTO == "SIM")
            {

                /*" -4391- MOVE 'ATR_FISS' TO ATTR33-GERAL */
                _.Move("ATR_FISS", W_REGISTRO_SIAS_GERAL.ATTR33_GERAL);

                /*" -4392- MOVE CEPFXFIL-FONTE TO ATTRVAL33-GERAL */
                _.Move(CEPFXFIL.DCLCEPFAIXAFILIAL.CEPFXFIL_FONTE, W_REGISTRO_SIAS_GERAL.ATTRVAL33_GERAL);

                /*" -4393- ELSE */
            }
            else
            {


                /*" -4394- MOVE 'ATR_FISS' TO ATTR33-GERAL */
                _.Move("ATR_FISS", W_REGISTRO_SIAS_GERAL.ATTR33_GERAL);

                /*" -4395- MOVE ALL 'X' TO ATTRVAL33-GERAL */
                _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL33_GERAL);

                /*" -4399- END-IF */
            }


            /*" -4400- MOVE 'ATR_BPAR' TO ATTR34-GERAL. */
            _.Move("ATR_BPAR", W_REGISTRO_SIAS_GERAL.ATTR34_GERAL);

            /*" -4404- MOVE SPACES TO ATTRVAL34-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTRVAL34_GERAL);

            /*" -4405- MOVE 'ATR_FORN' TO ATTR35-GERAL. */
            _.Move("ATR_FORN", W_REGISTRO_SIAS_GERAL.ATTR35_GERAL);

            /*" -4410- MOVE SPACES TO ATTRVAL35-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTRVAL35_GERAL);

            /*" -4412- INITIALIZE W-ATTRVAL */
            _.Initialize(
                AREA_DE_WORK.W_ATTRVAL
            );

            /*" -4413- IF SINISCAP-NUM-CPF-CNPJ-TOMADOR EQUAL ZEROS */

            if (SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_NUM_CPF_CNPJ_TOMADOR == 00)
            {

                /*" -4414- MOVE ALL 'X' TO W-ATTRVAL */
                _.MoveAll("X", AREA_DE_WORK.W_ATTRVAL);

                /*" -4415- ELSE */
            }
            else
            {


                /*" -4417- MOVE SINISCAP-NUM-CPF-CNPJ-TOMADOR TO WS-TRATA-TAMANHO-14 */
                _.Move(SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_NUM_CPF_CNPJ_TOMADOR, AREA_DE_WORK.WS_TRATA_TAMANHO.WS_TRATA_TAMANHO_14);

                /*" -4418- MOVE WS-TRATA-TAMANHO-14 TO W-ATTRVAL */
                _.Move(AREA_DE_WORK.WS_TRATA_TAMANHO.WS_TRATA_TAMANHO_14, AREA_DE_WORK.W_ATTRVAL);

                /*" -4420- END-IF */
            }


            /*" -4421- EVALUATE WS-COD-EVENTO-NUM */
            switch (FILLER_18.WS_COD_EVENTO_NUM.Value.Trim())
            {

                /*" -4422- WHEN '09002' */
                case "09002":

                    /*" -4423- WHEN '09006' */
                    break;
                case "09006":

                /*" -4424- WHEN '09007' */
                case "09007":

                    /*" -4425- WHEN '09009' */
                    break;
                case "09009":

                /*" -4426- WHEN '09022' */
                case "09022":

                    /*" -4427- MOVE 'ATR_CNPJ' TO ATTR10-GERAL */
                    _.Move("ATR_CNPJ", W_REGISTRO_SIAS_GERAL.ATTR10_GERAL);

                    /*" -4428- MOVE W-ATTRVAL TO ATTRVAL10-GERAL */
                    _.Move(AREA_DE_WORK.W_ATTRVAL, W_REGISTRO_SIAS_GERAL.ATTRVAL10_GERAL);

                    /*" -4429- WHEN '09001' */
                    break;
                case "09001":

                /*" -4430- WHEN '09010' */
                case "09010":

                    /*" -4431- WHEN '09014' */
                    break;
                case "09014":

                /*" -4432- WHEN '09023' */
                case "09023":

                    /*" -4433- MOVE 'ATR_CNPJ' TO ATTR08-GERAL */
                    _.Move("ATR_CNPJ", W_REGISTRO_SIAS_GERAL.ATTR08_GERAL);

                    /*" -4434- MOVE W-ATTRVAL TO ATTRVAL08-GERAL */
                    _.Move(AREA_DE_WORK.W_ATTRVAL, W_REGISTRO_SIAS_GERAL.ATTRVAL08_GERAL);

                    /*" -4435- WHEN '09003' */
                    break;
                case "09003":

                /*" -4436- WHEN '09004' */
                case "09004":

                    /*" -4437- WHEN '09008' */
                    break;
                case "09008":

                /*" -4438- WHEN '09015' */
                case "09015":

                    /*" -4439- WHEN '09025' */
                    break;
                case "09025":

                    /*" -4440- MOVE 'ATR_CNPJ' TO ATTR37-GERAL */
                    _.Move("ATR_CNPJ", W_REGISTRO_SIAS_GERAL.ATTR37_GERAL);

                    /*" -4441- MOVE W-ATTRVAL TO ATTRVAL37-GERAL */
                    _.Move(AREA_DE_WORK.W_ATTRVAL, W_REGISTRO_SIAS_GERAL.ATTRVAL37_GERAL);

                    /*" -4442- WHEN '09005' */
                    break;
                case "09005":

                /*" -4443- WHEN '09011' */
                case "09011":

                    /*" -4444- WHEN '09012' */
                    break;
                case "09012":

                /*" -4445- WHEN '09013' */
                case "09013":

                    /*" -4446- WHEN '09024' */
                    break;
                case "09024":

                    /*" -4447- MOVE 'ATR_CNPJ' TO ATTR07-GERAL */
                    _.Move("ATR_CNPJ", W_REGISTRO_SIAS_GERAL.ATTR07_GERAL);

                    /*" -4448- MOVE W-ATTRVAL TO ATTRVAL07-GERAL */
                    _.Move(AREA_DE_WORK.W_ATTRVAL, W_REGISTRO_SIAS_GERAL.ATTRVAL07_GERAL);

                    /*" -4450- END-EVALUATE */
                    break;
            }


            /*" -4450- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3500_EXIT*/

        [StopWatch]
        /*" R3550-MONTA-CODV-PAGTO-MOD-AP */
        private void R3550_MONTA_CODV_PAGTO_MOD_AP(bool isPerform = false)
        {
            /*" -4461- MOVE SPACES TO COD01-GERAL VALO01-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD01_GERAL, W_REGISTRO_SIAS_GERAL.VALO01_GERAL);

            /*" -4463- MOVE SPACES TO COD02-GERAL VALO02-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD02_GERAL, W_REGISTRO_SIAS_GERAL.VALO02_GERAL);

            /*" -4467- IF CODOPE-GERAL EQUAL 'SIAS_09001' OR 'SIAS_09002' OR 'SIAS_09003' OR 'SIAS_09004' OR 'SIAS_09005' OR 'SIAS_09006' OR 'SIAS_09007' OR 'SIAS_09008' */

            if (W_REGISTRO_SIAS_GERAL.CODOPE_GERAL.In("SIAS_09001".ToString(), "SIAS_09002".ToString(), "SIAS_09003".ToString(), "SIAS_09004".ToString(), "SIAS_09005".ToString(), "SIAS_09006".ToString(), "SIAS_09007".ToString(), "SIAS_09008".ToString()))
            {

                /*" -4468- MOVE 'CV_PGSIN' TO COD01-GERAL */
                _.Move("CV_PGSIN", W_REGISTRO_SIAS_GERAL.COD01_GERAL);

                /*" -4469- MOVE SINISHIS-VAL-OPERACAO TO W-VALOR-GERAL-VALOR */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

                /*" -4470- ADD SINISHIS-VAL-OPERACAO TO W-TOTAL-VALORES */
                AREA_DE_WORK.W_TOTAL_VALORES.Value = AREA_DE_WORK.W_TOTAL_VALORES + SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO;

                /*" -4471- MOVE W-VALOR-GERAL-X TO VALO01-GERAL */
                _.Move(W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO01_GERAL);

                /*" -4472- ADD SINISHIS-VAL-OPERACAO TO W-AC-TOT-INDENIZACOES */
                AREA_DE_WORK.W_AC_TOT_INDENIZACOES.Value = AREA_DE_WORK.W_AC_TOT_INDENIZACOES + SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO;

                /*" -4474- MOVE SPACES TO COD02-GERAL VALO02-GERAL. */
                _.Move("", W_REGISTRO_SIAS_GERAL.COD02_GERAL, W_REGISTRO_SIAS_GERAL.VALO02_GERAL);
            }


            /*" -4476- IF CODOPE-GERAL EQUAL 'SIAS_09009' OR 'SIAS_09010' OR 'SIAS_09013' OR 'SIAS_09015' */

            if (W_REGISTRO_SIAS_GERAL.CODOPE_GERAL.In("SIAS_09009".ToString(), "SIAS_09010".ToString(), "SIAS_09013".ToString(), "SIAS_09015".ToString()))
            {

                /*" -4478- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'HPAG' OR 'HSPAG' OR 'RSHOP' OR 'JBHON' */

                if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO.In("HPAG", "HSPAG", "RSHOP", "JBHON"))
                {

                    /*" -4479- MOVE 'CV_PGHON' TO COD01-GERAL */
                    _.Move("CV_PGHON", W_REGISTRO_SIAS_GERAL.COD01_GERAL);

                    /*" -4480- MOVE SINISHIS-VAL-OPERACAO TO W-VALOR-GERAL-VALOR */
                    _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

                    /*" -4481- MOVE W-VALOR-GERAL-X TO VALO01-GERAL */
                    _.Move(W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO01_GERAL);

                    /*" -4482- ADD SINISHIS-VAL-OPERACAO TO W-AC-TOT-HONORARIOS */
                    AREA_DE_WORK.W_AC_TOT_HONORARIOS.Value = AREA_DE_WORK.W_AC_TOT_HONORARIOS + SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO;

                    /*" -4483- ADD SINISHIS-VAL-OPERACAO TO W-TOTAL-VALORES */
                    AREA_DE_WORK.W_TOTAL_VALORES.Value = AREA_DE_WORK.W_TOTAL_VALORES + SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO;

                    /*" -4485- MOVE SPACES TO COD02-GERAL VALO02-GERAL. */
                    _.Move("", W_REGISTRO_SIAS_GERAL.COD02_GERAL, W_REGISTRO_SIAS_GERAL.VALO02_GERAL);
                }

            }


            /*" -4487- IF CODOPE-GERAL EQUAL 'SIAS_09022' OR 'SIAS_09023' OR 'SIAS_09024' OR 'SIAS_09025' */

            if (W_REGISTRO_SIAS_GERAL.CODOPE_GERAL.In("SIAS_09022".ToString(), "SIAS_09023".ToString(), "SIAS_09024".ToString(), "SIAS_09025".ToString()))
            {

                /*" -4489- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'DPAG' OR 'DSPAG' OR 'RSDEP' OR 'JBDES' */

                if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO.In("DPAG", "DSPAG", "RSDEP", "JBDES"))
                {

                    /*" -4490- MOVE 'CV_PGDES' TO COD01-GERAL */
                    _.Move("CV_PGDES", W_REGISTRO_SIAS_GERAL.COD01_GERAL);

                    /*" -4491- MOVE SINISHIS-VAL-OPERACAO TO W-VALOR-GERAL-VALOR */
                    _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

                    /*" -4492- MOVE W-VALOR-GERAL-X TO VALO01-GERAL */
                    _.Move(W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO01_GERAL);

                    /*" -4493- ADD SINISHIS-VAL-OPERACAO TO W-AC-TOT-HONORARIOS */
                    AREA_DE_WORK.W_AC_TOT_HONORARIOS.Value = AREA_DE_WORK.W_AC_TOT_HONORARIOS + SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO;

                    /*" -4494- ADD SINISHIS-VAL-OPERACAO TO W-TOTAL-VALORES */
                    AREA_DE_WORK.W_TOTAL_VALORES.Value = AREA_DE_WORK.W_TOTAL_VALORES + SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO;

                    /*" -4496- MOVE SPACES TO COD02-GERAL VALO02-GERAL. */
                    _.Move("", W_REGISTRO_SIAS_GERAL.COD02_GERAL, W_REGISTRO_SIAS_GERAL.VALO02_GERAL);
                }

            }


            /*" -4497- IF CODOPE-GERAL EQUAL 'SIAS_09014' */

            if (W_REGISTRO_SIAS_GERAL.CODOPE_GERAL == "SIAS_09014")
            {

                /*" -4498- MOVE 'CV_PGHON' TO COD01-GERAL */
                _.Move("CV_PGHON", W_REGISTRO_SIAS_GERAL.COD01_GERAL);

                /*" -4499- MOVE 'CV_PGDES' TO COD02-GERAL */
                _.Move("CV_PGDES", W_REGISTRO_SIAS_GERAL.COD02_GERAL);

                /*" -4500- MOVE 0 TO W-VALOR-GERAL-VALOR */
                _.Move(0, W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

                /*" -4501- MOVE W-VALOR-GERAL-X TO VALO01-GERAL VALO02-GERAL */
                _.Move(W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO01_GERAL, W_REGISTRO_SIAS_GERAL.VALO02_GERAL);

                /*" -4503- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'HPAG' OR 'HSPAG' OR 'RSHOP' OR 'JBHON' */

                if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO.In("HPAG", "HSPAG", "RSHOP", "JBHON"))
                {

                    /*" -4504- MOVE SINISHIS-VAL-OPERACAO TO W-VALOR-GERAL-VALOR */
                    _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

                    /*" -4505- MOVE W-VALOR-GERAL-X TO VALO01-GERAL */
                    _.Move(W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO01_GERAL);

                    /*" -4506- ELSE */
                }
                else
                {


                    /*" -4508- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'DPAG' OR 'DSPAG' OR 'RSDEP' OR 'JBDES' */

                    if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO.In("DPAG", "DSPAG", "RSDEP", "JBDES"))
                    {

                        /*" -4509- MOVE SINISHIS-VAL-OPERACAO TO W-VALOR-GERAL-VALOR */
                        _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

                        /*" -4511- MOVE W-VALOR-GERAL-X TO VALO02-GERAL. */
                        _.Move(W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO02_GERAL);
                    }

                }

            }


            /*" -4512- IF CODOPE-GERAL EQUAL 'SIAS_09011' */

            if (W_REGISTRO_SIAS_GERAL.CODOPE_GERAL == "SIAS_09011")
            {

                /*" -4513- MOVE SPACES TO COD01-GERAL */
                _.Move("", W_REGISTRO_SIAS_GERAL.COD01_GERAL);

                /*" -4514- MOVE SPACES TO VALO01-GERAL */
                _.Move("", W_REGISTRO_SIAS_GERAL.VALO01_GERAL);

                /*" -4515- MOVE 'CV_PGDES' TO COD02-GERAL */
                _.Move("CV_PGDES", W_REGISTRO_SIAS_GERAL.COD02_GERAL);

                /*" -4516- MOVE 0 TO W-VALOR-GERAL-VALOR */
                _.Move(0, W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

                /*" -4517- MOVE W-VALOR-GERAL-X TO VALO02-GERAL */
                _.Move(W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO02_GERAL);

                /*" -4519- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'HPAG' OR 'HSPAG' OR 'RSHOP' OR 'JBHON' */

                if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO.In("HPAG", "HSPAG", "RSHOP", "JBHON"))
                {

                    /*" -4520- MOVE SINISHIS-VAL-OPERACAO TO W-VALOR-GERAL-VALOR */
                    _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

                    /*" -4521- MOVE W-VALOR-GERAL-X TO VALO01-GERAL */
                    _.Move(W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO01_GERAL);

                    /*" -4522- ELSE */
                }
                else
                {


                    /*" -4524- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'DPAG' OR 'DSPAG' OR 'RSDEP' OR 'JBDES' */

                    if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO.In("DPAG", "DSPAG", "RSDEP", "JBDES"))
                    {

                        /*" -4525- MOVE SINISHIS-VAL-OPERACAO TO W-VALOR-GERAL-VALOR */
                        _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

                        /*" -4527- MOVE W-VALOR-GERAL-X TO VALO02-GERAL. */
                        _.Move(W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO02_GERAL);
                    }

                }

            }


            /*" -4528- IF CODOPE-GERAL EQUAL 'SIAS_09012' */

            if (W_REGISTRO_SIAS_GERAL.CODOPE_GERAL == "SIAS_09012")
            {

                /*" -4529- MOVE 'CV_PGHON' TO COD01-GERAL */
                _.Move("CV_PGHON", W_REGISTRO_SIAS_GERAL.COD01_GERAL);

                /*" -4530- MOVE 0 TO W-VALOR-GERAL-VALOR */
                _.Move(0, W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

                /*" -4531- MOVE W-VALOR-GERAL-X TO VALO01-GERAL */
                _.Move(W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO01_GERAL);

                /*" -4532- MOVE SPACES TO COD02-GERAL */
                _.Move("", W_REGISTRO_SIAS_GERAL.COD02_GERAL);

                /*" -4533- MOVE SPACES TO VALO02-GERAL */
                _.Move("", W_REGISTRO_SIAS_GERAL.VALO02_GERAL);

                /*" -4535- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'HPAG' OR 'HSPAG' OR 'RSHOP' OR 'JBHON' */

                if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO.In("HPAG", "HSPAG", "RSHOP", "JBHON"))
                {

                    /*" -4536- MOVE SINISHIS-VAL-OPERACAO TO W-VALOR-GERAL-VALOR */
                    _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

                    /*" -4537- MOVE W-VALOR-GERAL-X TO VALO01-GERAL */
                    _.Move(W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO01_GERAL);

                    /*" -4538- ELSE */
                }
                else
                {


                    /*" -4540- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'DPAG' OR 'DSPAG' OR 'RSDEP' OR 'JBDES' */

                    if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO.In("DPAG", "DSPAG", "RSDEP", "JBDES"))
                    {

                        /*" -4541- MOVE SINISHIS-VAL-OPERACAO TO W-VALOR-GERAL-VALOR */
                        _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

                        /*" -4545- MOVE W-VALOR-GERAL-X TO VALO02-GERAL. */
                        _.Move(W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO02_GERAL);
                    }

                }

            }


            /*" -4546- MOVE SPACES TO COD03-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD03_GERAL);

            /*" -4548- MOVE SPACES TO VALO03-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.VALO03_GERAL);

            /*" -4549- MOVE SPACES TO COD04-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD04_GERAL);

            /*" -4551- MOVE SPACES TO VALO04-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.VALO04_GERAL);

            /*" -4552- MOVE SPACES TO COD05-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD05_GERAL);

            /*" -4558- MOVE SPACES TO VALO05-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.VALO05_GERAL);

            /*" -4569- PERFORM R3005-LIMPA-OS-COD-E-VALOR THRU R3005-EXIT. */

            R3005_LIMPA_OS_COD_E_VALOR(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R3005_EXIT*/


            /*" -4572- IF SINISHIS-COD-OPERACAO EQUAL 4291 OR W-CHAVE-EH-PRESTADOR EQUAL 'NAO' */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO == 4291 || AREA_DE_WORK.W_CHAVE_EH_PRESTADOR == "NAO")
            {

                /*" -4578- GO TO R3550-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3550_EXIT*/ //GOTO
                return;
            }


            /*" -4579- MOVE 'NAO' TO W-CHAVE-TEM-IMPOSTOS. */
            _.Move("NAO", AREA_DE_WORK.W_CHAVE_TEM_IMPOSTOS);

            /*" -4581- MOVE 'NAO' TO WFIM-IMPOSTOS . */
            _.Move("NAO", AREA_DE_WORK.WFIM_IMPOSTOS);

            /*" -4582- PERFORM R4000-DECLARE-IMPOSTOS THRU R4000-EXIT. */

            R4000_DECLARE_IMPOSTOS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_EXIT*/


            /*" -4599- PERFORM R4001-FETCH-IMPOSTOS THRU R4001-EXIT. */

            R4001_FETCH_IMPOSTOS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R4001_EXIT*/


            /*" -4600- PERFORM R4010-PROCESSA-IMPOSTOS THRU R4010-EXIT UNTIL WFIM-IMPOSTOS EQUAL 'SIM' . */

            while (!(AREA_DE_WORK.WFIM_IMPOSTOS == "SIM"))
            {

                R4010_PROCESSA_IMPOSTOS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R4010_EXIT*/

            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3550_EXIT*/

        [StopWatch]
        /*" R3700-MONTA-ATTR-RECEB-MOD-CA */
        private void R3700_MONTA_ATTR_RECEB_MOD_CA(bool isPerform = false)
        {
            /*" -4611- MOVE 'ATR_CRED' TO ATTR01-GERAL. */
            _.Move("ATR_CRED", W_REGISTRO_SIAS_GERAL.ATTR01_GERAL);

            /*" -4616- MOVE ALL 'X' TO ATTRVAL01-GERAL. */
            _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL01_GERAL);

            /*" -4623- MOVE ZEROS TO LKGE-RAMO-EMISSOR LKGE-MODALIDADE LKGE-PRODUTO LKGE-GRUPO-SUSEP LKGE-RAMO-SUSEP LKGE-SQLCODE. */
            _.Move(0, PARAMETROS_GE.LKGE_RAMO_EMISSOR, PARAMETROS_GE.LKGE_MODALIDADE, PARAMETROS_GE.LKGE_PRODUTO, PARAMETROS_GE.LKGE_GRUPO_SUSEP, PARAMETROS_GE.LKGE_RAMO_SUSEP, PARAMETROS_GE.LKGE_SQLCODE);

            /*" -4626- MOVE SPACES TO LKGE-INIVIGENCIA LKGE-MENSAGEM. */
            _.Move("", PARAMETROS_GE.LKGE_INIVIGENCIA, PARAMETROS_GE.LKGE_MENSAGEM);

            /*" -4628- MOVE SINISMES-RAMO TO LKGE-RAMO-EMISSOR. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO, PARAMETROS_GE.LKGE_RAMO_EMISSOR);

            /*" -4629- IF SINISMES-RAMO EQUAL 48 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO == 48)
            {

                /*" -4631- MOVE SINISMES-COD-PRODUTO TO LKGE-PRODUTO. */
                _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO, PARAMETROS_GE.LKGE_PRODUTO);
            }


            /*" -4634- MOVE HOST-SI-DATA-MOV-ABERTO TO LKGE-INIVIGENCIA. */
            _.Move(HOST_SI_DATA_MOV_ABERTO, PARAMETROS_GE.LKGE_INIVIGENCIA);

            /*" -4637- CALL 'GE0005S' USING PARAMETROS-GE. */
            _.Call("GE0005S", PARAMETROS_GE);

            /*" -4638- IF LKGE-MENSAGEM NOT EQUAL SPACES */

            if (!PARAMETROS_GE.LKGE_MENSAGEM.IsEmpty())
            {

                /*" -4639- DISPLAY 'R1250 - ERRO NO CALL DA SUB-ROTINA GE0005S' */
                _.Display($"R1250 - ERRO NO CALL DA SUB-ROTINA GE0005S");

                /*" -4640- DISPLAY 'ERRO ...... ' LKGE-MENSAGEM */
                _.Display($"ERRO ...... {PARAMETROS_GE.LKGE_MENSAGEM}");

                /*" -4641- DISPLAY 'SQLCODE ... ' LKGE-SQLCODE */
                _.Display($"SQLCODE ... {PARAMETROS_GE.LKGE_SQLCODE}");

                /*" -4642- DISPLAY 'RAMO ...... ' LKGE-RAMO-EMISSOR */
                _.Display($"RAMO ...... {PARAMETROS_GE.LKGE_RAMO_EMISSOR}");

                /*" -4643- DISPLAY 'PRODUTO ... ' LKGE-PRODUTO */
                _.Display($"PRODUTO ... {PARAMETROS_GE.LKGE_PRODUTO}");

                /*" -4644- DISPLAY 'VIGENCIA .. ' LKGE-INIVIGENCIA */
                _.Display($"VIGENCIA .. {PARAMETROS_GE.LKGE_INIVIGENCIA}");

                /*" -4645- MOVE LKGE-SQLCODE TO SQLCODE */
                _.Move(PARAMETROS_GE.LKGE_SQLCODE, DB.SQLCODE);

                /*" -4647- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -4648- MOVE 'ATR_PROP' TO ATTR02-GERAL. */
            _.Move("ATR_PROP", W_REGISTRO_SIAS_GERAL.ATTR02_GERAL);

            /*" -4650- MOVE ALL 'X' TO ATTRVAL02-GERAL. */
            _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL02_GERAL);

            /*" -4651- MOVE 'ATR_CANA' TO ATTR03-GERAL. */
            _.Move("ATR_CANA", W_REGISTRO_SIAS_GERAL.ATTR03_GERAL);

            /*" -4653- MOVE ALL 'X' TO ATTRVAL03-GERAL. */
            _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL03_GERAL);

            /*" -4654- MOVE 'ATR_NNUM' TO ATTR04-GERAL. */
            _.Move("ATR_NNUM", W_REGISTRO_SIAS_GERAL.ATTR04_GERAL);

            /*" -4656- MOVE ALL 'X' TO ATTRVAL04-GERAL. */
            _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL04_GERAL);

            /*" -4657- MOVE 'ATR_DTCR' TO ATTR05-GERAL. */
            _.Move("ATR_DTCR", W_REGISTRO_SIAS_GERAL.ATTR05_GERAL);

            /*" -4659- MOVE ALL 'X' TO ATTRVAL05-GERAL. */
            _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL05_GERAL);

            /*" -4660- MOVE 'ATR_CDCC' TO ATTR06-GERAL. */
            _.Move("ATR_CDCC", W_REGISTRO_SIAS_GERAL.ATTR06_GERAL);

            /*" -4662- MOVE MOVDEBCE-COD-CONVENIO TO ATTRVAL06-GERAL. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO, W_REGISTRO_SIAS_GERAL.ATTRVAL06_GERAL);

            /*" -4663- MOVE 'ATR_CODU' TO ATTR07-GERAL. */
            _.Move("ATR_CODU", W_REGISTRO_SIAS_GERAL.ATTR07_GERAL);

            /*" -4665- MOVE 'AUTO' TO ATTRVAL07-GERAL. */
            _.Move("AUTO", W_REGISTRO_SIAS_GERAL.ATTRVAL07_GERAL);

            /*" -4666- MOVE 'ATR_APOL' TO ATTR08-GERAL. */
            _.Move("ATR_APOL", W_REGISTRO_SIAS_GERAL.ATTR08_GERAL);

            /*" -4668- MOVE SINISHIS-NUM-APOLICE TO ATTRVAL08-GERAL. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOLICE, W_REGISTRO_SIAS_GERAL.ATTRVAL08_GERAL);

            /*" -4669- MOVE 'ATR_NEND' TO ATTR09-GERAL. */
            _.Move("ATR_NEND", W_REGISTRO_SIAS_GERAL.ATTR09_GERAL);

            /*" -4671- MOVE ALL 'X' TO ATTRVAL09-GERAL. */
            _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL09_GERAL);

            /*" -4672- MOVE 'ATR_PARC' TO ATTR10-GERAL. */
            _.Move("ATR_PARC", W_REGISTRO_SIAS_GERAL.ATTR10_GERAL);

            /*" -4674- MOVE ALL 'X' TO ATTRVAL10-GERAL. */
            _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL10_GERAL);

            /*" -4675- MOVE 'ATR_TPCV' TO ATTR11-GERAL. */
            _.Move("ATR_TPCV", W_REGISTRO_SIAS_GERAL.ATTR11_GERAL);

            /*" -4676- IF MOVDEBCE-COD-CONVENIO EQUAL 43350 */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO == 43350)
            {

                /*" -4677- MOVE 'A' TO ATTRVAL11-GERAL */
                _.Move("A", W_REGISTRO_SIAS_GERAL.ATTRVAL11_GERAL);

                /*" -4678- ELSE */
            }
            else
            {


                /*" -4679- IF MOVDEBCE-COD-CONVENIO EQUAL 600119 OR 600123 */

                if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.In("600119", "600123"))
                {

                    /*" -4680- MOVE 'B' TO ATTRVAL11-GERAL */
                    _.Move("B", W_REGISTRO_SIAS_GERAL.ATTRVAL11_GERAL);

                    /*" -4681- ELSE */
                }
                else
                {


                    /*" -4683- MOVE ALL 'X' TO ATTRVAL11-GERAL . */
                    _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL11_GERAL);
                }

            }


            /*" -4684- MOVE 'ATR_COMP' TO ATTR12-GERAL. */
            _.Move("ATR_COMP", W_REGISTRO_SIAS_GERAL.ATTR12_GERAL);

            /*" -4685- IF ATTRVAL11-GERAL EQUAL 'A' */

            if (W_REGISTRO_SIAS_GERAL.ATTRVAL11_GERAL == "A")
            {

                /*" -4686- MOVE '0' TO ATTRVAL12-GERAL */
                _.Move("0", W_REGISTRO_SIAS_GERAL.ATTRVAL12_GERAL);

                /*" -4687- ELSE */
            }
            else
            {


                /*" -4689- MOVE ALL 'X' TO ATTRVAL12-GERAL . */
                _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL12_GERAL);
            }


            /*" -4690- MOVE 'ATR_FTEP' TO ATTR13-GERAL. */
            _.Move("ATR_FTEP", W_REGISTRO_SIAS_GERAL.ATTR13_GERAL);

            /*" -4692- MOVE SINISMES-COD-FONTE TO ATTRVAL13-GERAL. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE, W_REGISTRO_SIAS_GERAL.ATTRVAL13_GERAL);

            /*" -4693- MOVE 'ATR_PROD' TO ATTR14-GERAL. */
            _.Move("ATR_PROD", W_REGISTRO_SIAS_GERAL.ATTR14_GERAL);

            /*" -4694- MOVE 'L000' TO W-PRODUTO-SAP-L000. */
            _.Move("L000", AREA_DE_WORK.W_PRODUTO_SAP.W_PRODUTO_SAP_L000);

            /*" -4695- MOVE SINISMES-COD-PRODUTO TO W-PRODUTO-SAP-PRODUTO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO, AREA_DE_WORK.W_PRODUTO_SAP.W_PRODUTO_SAP_PRODUTO);

            /*" -4697- MOVE W-PRODUTO-SAP TO ATTRVAL14-GERAL. */
            _.Move(AREA_DE_WORK.W_PRODUTO_SAP, W_REGISTRO_SIAS_GERAL.ATTRVAL14_GERAL);

            /*" -4698- MOVE 'ATR_RAMO' TO ATTR15-GERAL. */
            _.Move("ATR_RAMO", W_REGISTRO_SIAS_GERAL.ATTR15_GERAL);

            /*" -4702- MOVE LKGE-RAMO-SUSEP TO ATTRVAL15-GERAL. */
            _.Move(PARAMETROS_GE.LKGE_RAMO_SUSEP, W_REGISTRO_SIAS_GERAL.ATTRVAL15_GERAL);

            /*" -4703- MOVE 'ATR_FREC' TO ATTR16-GERAL. */
            _.Move("ATR_FREC", W_REGISTRO_SIAS_GERAL.ATTR16_GERAL);

            /*" -4705- MOVE 'D' TO ATTRVAL16-GERAL. */
            _.Move("D", W_REGISTRO_SIAS_GERAL.ATTRVAL16_GERAL);

            /*" -4706- MOVE 'ATR_DVEN' TO ATTR17-GERAL. */
            _.Move("ATR_DVEN", W_REGISTRO_SIAS_GERAL.ATTR17_GERAL);

            /*" -4708- MOVE MOVDEBCE-DATA-VENCIMENTO(1:4) TO W-DATA-AAAAMMDD-AAAA. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO.Substring(1, 4), AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_AAAA);

            /*" -4710- MOVE MOVDEBCE-DATA-VENCIMENTO(6:2) TO W-DATA-AAAAMMDD-MM. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO.Substring(6, 2), AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_MM);

            /*" -4712- MOVE MOVDEBCE-DATA-VENCIMENTO(9:2) TO W-DATA-AAAAMMDD-DD. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO.Substring(9, 2), AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_DD);

            /*" -4714- MOVE W-DATA-AAAAMMDD TO ATTRVAL17-GERAL. */
            _.Move(AREA_DE_WORK.W_DATA_AAAAMMDD, W_REGISTRO_SIAS_GERAL.ATTRVAL17_GERAL);

            /*" -4715- MOVE SPACES TO ATTR18-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTR18_GERAL);

            /*" -4717- MOVE SPACES TO ATTRVAL18-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTRVAL18_GERAL);

            /*" -4718- MOVE 'ATR_ACCT' TO ATTR19-GERAL. */
            _.Move("ATR_ACCT", W_REGISTRO_SIAS_GERAL.ATTR19_GERAL);

            /*" -4722- MOVE SINISHIS-NUM-APOL-SINISTRO TO ATTRVAL19-GERAL. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, W_REGISTRO_SIAS_GERAL.ATTRVAL19_GERAL);

            /*" -4723- MOVE 'ATR_SNTR' TO ATTR20-GERAL. */
            _.Move("ATR_SNTR", W_REGISTRO_SIAS_GERAL.ATTR20_GERAL);

            /*" -4725- MOVE SINISHIS-NUM-APOL-SINISTRO TO ATTRVAL20-GERAL. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, W_REGISTRO_SIAS_GERAL.ATTRVAL20_GERAL);

            /*" -4726- MOVE SPACES TO ATTR21-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTR21_GERAL);

            /*" -4728- MOVE SPACES TO ATTRVAL21-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTRVAL21_GERAL);

            /*" -4729- MOVE SPACES TO ATTR22-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTR22_GERAL);

            /*" -4731- MOVE SPACES TO ATTRVAL22-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTRVAL22_GERAL);

            /*" -4732- MOVE SPACES TO ATTR23-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTR23_GERAL);

            /*" -4734- MOVE SPACES TO ATTRVAL23-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTRVAL23_GERAL);

            /*" -4735- MOVE SPACES TO ATTR24-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTR24_GERAL);

            /*" -4737- MOVE SPACES TO ATTRVAL24-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTRVAL24_GERAL);

            /*" -4738- MOVE SPACES TO ATTR25-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTR25_GERAL);

            /*" -4740- MOVE SPACES TO ATTRVAL25-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTRVAL25_GERAL);

            /*" -4741- MOVE SPACES TO ATTR26-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTR26_GERAL);

            /*" -4743- MOVE SPACES TO ATTRVAL26-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTRVAL26_GERAL);

            /*" -4744- MOVE SPACES TO ATTR27-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTR27_GERAL);

            /*" -4746- MOVE SPACES TO ATTRVAL27-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTRVAL27_GERAL);

            /*" -4747- MOVE SPACES TO ATTR28-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTR28_GERAL);

            /*" -4749- MOVE SPACES TO ATTRVAL28-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTRVAL28_GERAL);

            /*" -4750- MOVE SPACES TO ATTR29-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTR29_GERAL);

            /*" -4752- MOVE SPACES TO ATTRVAL29-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTRVAL29_GERAL);

            /*" -4753- MOVE SPACES TO ATTR30-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTR30_GERAL);

            /*" -4755- MOVE SPACES TO ATTRVAL30-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTRVAL30_GERAL);

            /*" -4756- MOVE SPACES TO ATTR31-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTR31_GERAL);

            /*" -4758- MOVE SPACES TO ATTRVAL31-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTRVAL31_GERAL);

            /*" -4759- MOVE 'ATR_TPAR' TO ATTR32-GERAL. */
            _.Move("ATR_TPAR", W_REGISTRO_SIAS_GERAL.ATTR32_GERAL);

            /*" -4761- MOVE ALL 'X' TO ATTRVAL32-GERAL. */
            _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL32_GERAL);

            /*" -4762- MOVE 'ATR_IDCC' TO ATTR33-GERAL. */
            _.Move("ATR_IDCC", W_REGISTRO_SIAS_GERAL.ATTR33_GERAL);

            /*" -4764- MOVE ALL " " TO ATTRVAL33-GERAL. */
            _.MoveAll("\"", W_REGISTRO_SIAS_GERAL.ATTRVAL33_GERAL);

            /*" -4765- MOVE 'ATR_IDBC' TO ATTR34-GERAL. */
            _.Move("ATR_IDBC", W_REGISTRO_SIAS_GERAL.ATTR34_GERAL);

            /*" -4767- MOVE ALL " " TO ATTRVAL34-GERAL. */
            _.MoveAll("\"", W_REGISTRO_SIAS_GERAL.ATTRVAL34_GERAL);

            /*" -4768- MOVE 'ATR_PNEG' TO ATTR35-GERAL. */
            _.Move("ATR_PNEG", W_REGISTRO_SIAS_GERAL.ATTR35_GERAL);

            /*" -4768- MOVE ALL " " TO ATTRVAL35-GERAL. */
            _.MoveAll("\"", W_REGISTRO_SIAS_GERAL.ATTRVAL35_GERAL);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3700_EXIT*/

        [StopWatch]
        /*" R3750-MONTA-CODV-RECEB-MOD-CA */
        private void R3750_MONTA_CODV_RECEB_MOD_CA(bool isPerform = false)
        {
            /*" -4778- MOVE SPACES TO COD01-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD01_GERAL);

            /*" -4780- MOVE SPACES TO VALO01-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.VALO01_GERAL);

            /*" -4781- MOVE 'CV_AVISO' TO COD01-GERAL */
            _.Move("CV_AVISO", W_REGISTRO_SIAS_GERAL.COD01_GERAL);

            /*" -4782- MOVE SINISHIS-VAL-OPERACAO TO W-VALOR-GERAL-VALOR */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

            /*" -4783- ADD SINISHIS-VAL-OPERACAO TO W-TOTAL-VALORES */
            AREA_DE_WORK.W_TOTAL_VALORES.Value = AREA_DE_WORK.W_TOTAL_VALORES + SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO;

            /*" -4785- MOVE W-VALOR-GERAL-X TO VALO01-GERAL */
            _.Move(W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO01_GERAL);

            /*" -4786- MOVE SPACES TO COD02-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD02_GERAL);

            /*" -4787- MOVE SPACES TO VALO02-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.VALO02_GERAL);

            /*" -4788- MOVE SPACES TO COD03-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD03_GERAL);

            /*" -4789- MOVE SPACES TO VALO03-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.VALO03_GERAL);

            /*" -4790- MOVE SPACES TO COD04-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD04_GERAL);

            /*" -4791- MOVE SPACES TO VALO04-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.VALO04_GERAL);

            /*" -4792- MOVE SPACES TO COD05-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD05_GERAL);

            /*" -4793- MOVE SPACES TO VALO05-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.VALO05_GERAL);

            /*" -4794- MOVE SPACES TO COD06-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD06_GERAL);

            /*" -4795- MOVE SPACES TO VALO06-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.VALO06_GERAL);

            /*" -4796- MOVE SPACES TO COD07-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD07_GERAL);

            /*" -4797- MOVE SPACES TO VALO07-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.VALO07_GERAL);

            /*" -4798- MOVE SPACES TO COD08-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD08_GERAL);

            /*" -4799- MOVE SPACES TO VALO08-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.VALO08_GERAL);

            /*" -4800- MOVE SPACES TO COD09-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD09_GERAL);

            /*" -4801- MOVE SPACES TO VALO09-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.VALO09_GERAL);

            /*" -4802- MOVE SPACES TO COD010-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD010_GERAL);

            /*" -4803- MOVE SPACES TO VALO010-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.VALO010_GERAL);

            /*" -4804- MOVE SPACES TO COD011-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD011_GERAL);

            /*" -4805- MOVE SPACES TO VALO011-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.VALO011_GERAL);

            /*" -4806- MOVE SPACES TO COD012-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD012_GERAL);

            /*" -4807- MOVE SPACES TO VALO012-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.VALO012_GERAL);

            /*" -4808- MOVE SPACES TO COD013-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD013_GERAL);

            /*" -4809- MOVE SPACES TO VALO013-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.VALO013_GERAL);

            /*" -4810- MOVE SPACES TO COD014-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD014_GERAL);

            /*" -4811- MOVE SPACES TO VALO014-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.VALO014_GERAL);

            /*" -4812- MOVE SPACES TO COD015-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD015_GERAL);

            /*" -4813- MOVE SPACES TO VALO015-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.VALO015_GERAL);

            /*" -4814- MOVE SPACES TO COD016-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD016_GERAL);

            /*" -4815- MOVE SPACES TO VALO016-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.VALO016_GERAL);

            /*" -4816- MOVE SPACES TO COD017-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD017_GERAL);

            /*" -4817- MOVE SPACES TO VALO017-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.VALO017_GERAL);

            /*" -4818- MOVE SPACES TO COD018-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD018_GERAL);

            /*" -4819- MOVE SPACES TO VALO018-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.VALO018_GERAL);

            /*" -4820- MOVE SPACES TO COD019-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD019_GERAL);

            /*" -4821- MOVE SPACES TO VALO019-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.VALO019_GERAL);

            /*" -4822- MOVE SPACES TO COD021-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD021_GERAL);

            /*" -4823- MOVE SPACES TO VALO021-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.VALO021_GERAL);

            /*" -4824- MOVE SPACES TO COD022-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD022_GERAL);

            /*" -4825- MOVE SPACES TO VALO022-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.VALO022_GERAL);

            /*" -4826- MOVE SPACES TO COD023-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD023_GERAL);

            /*" -4827- MOVE SPACES TO VALO023-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.VALO023_GERAL);

            /*" -4828- MOVE SPACES TO COD024-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD024_GERAL);

            /*" -4829- MOVE SPACES TO VALO024-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.VALO024_GERAL);

            /*" -4830- MOVE SPACES TO COD025-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD025_GERAL);

            /*" -4830- MOVE SPACES TO VALO025-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.VALO025_GERAL);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3750_EXIT*/

        [StopWatch]
        /*" R4000-DECLARE-IMPOSTOS */
        private void R4000_DECLARE_IMPOSTOS(bool isPerform = false)
        {
            /*" -4837- INITIALIZE DCLSI-PAGA-DOC-FISCAL */
            _.Initialize(
                SIPADOFI.DCLSI_PAGA_DOC_FISCAL
            );

            /*" -4838- INITIALIZE DCLGE-TP-LANC-DOCF */
            _.Initialize(
                GETPLADO.DCLGE_TP_LANC_DOCF
            );

            /*" -4839- INITIALIZE DCLFI-PAGA-DOCF-LANC */
            _.Initialize(
                FIPADOLA.DCLFI_PAGA_DOCF_LANC
            );

            /*" -4840- INITIALIZE DCLGE-TIPO-IMPOSTO */
            _.Initialize(
                GETIPIMP.DCLGE_TIPO_IMPOSTO
            );

            /*" -4845- INITIALIZE DCLFI-PAGA-DOCF-IMP */
            _.Initialize(
                FIPADOIM.DCLFI_PAGA_DOCF_IMP
            );

            /*" -4897- PERFORM R4000_DECLARE_IMPOSTOS_DB_DECLARE_1 */

            R4000_DECLARE_IMPOSTOS_DB_DECLARE_1();

            /*" -4899- PERFORM R4000_DECLARE_IMPOSTOS_DB_OPEN_1 */

            R4000_DECLARE_IMPOSTOS_DB_OPEN_1();

            /*" -4902- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -4903- DISPLAY 'SISAP01B - ERRO CURSOR IMPOSTOS' */
                _.Display($"SISAP01B - ERRO CURSOR IMPOSTOS");

                /*" -4903- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4000-DECLARE-IMPOSTOS-DB-OPEN-1 */
        public void R4000_DECLARE_IMPOSTOS_DB_OPEN_1()
        {
            /*" -4899- EXEC SQL OPEN IMPOSTOS END-EXEC. */

            IMPOSTOS.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_EXIT*/

        [StopWatch]
        /*" R4001-FETCH-IMPOSTOS */
        private void R4001_FETCH_IMPOSTOS(bool isPerform = false)
        {
            /*" -4922- PERFORM R4001_FETCH_IMPOSTOS_DB_FETCH_1 */

            R4001_FETCH_IMPOSTOS_DB_FETCH_1();

            /*" -4925- IF SQLCODE EQUAL 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -4930- MOVE 'SIM' TO W-CHAVE-TEM-IMPOSTOS. */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_TEM_IMPOSTOS);
            }


            /*" -4931- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -4931- PERFORM R4001_FETCH_IMPOSTOS_DB_CLOSE_1 */

                R4001_FETCH_IMPOSTOS_DB_CLOSE_1();

                /*" -4933- MOVE 'SIM' TO WFIM-IMPOSTOS */
                _.Move("SIM", AREA_DE_WORK.WFIM_IMPOSTOS);

                /*" -4935- GO TO R4001-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R4001_EXIT*/ //GOTO
                return;
            }


            /*" -4936- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -4937- DISPLAY 'SISAP01B - ERRO NO FETCH CURSOR IMPOSTOS' */
                _.Display($"SISAP01B - ERRO NO FETCH CURSOR IMPOSTOS");

                /*" -4937- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4001-FETCH-IMPOSTOS-DB-FETCH-1 */
        public void R4001_FETCH_IMPOSTOS_DB_FETCH_1()
        {
            /*" -4922- EXEC SQL FETCH IMPOSTOS INTO :SINISHIS-NUM-APOL-SINISTRO ,:SINISHIS-OCORR-HISTORICO ,:SINISHIS-COD-OPERACAO ,:SIPADOFI-NUM-DOCF-INTERNO ,:FIPADOLA-COD-TP-LANCDOCF ,:GETPLADO-ABREV-LANCDOCF ,:FIPADOLA-VALOR-LANCAMENTO ,:GETIPIMP-COD-IMP-INTERNO ,:GETIPIMP-SIGLA-IMP ,:FIPADOIM-ALIQ-TRIBUTACAO ,:FIPADOIM-VALOR-IMPOSTO ,:FIPADOIM-COD-IMPOSTO-SAP:FIPADOIM-COD-IMPOSTO-SAP-NN END-EXEC. */

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
            /*" -4931- EXEC SQL CLOSE IMPOSTOS END-EXEC */

            IMPOSTOS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4001_EXIT*/

        [StopWatch]
        /*" R4010-PROCESSA-IMPOSTOS */
        private void R4010_PROCESSA_IMPOSTOS(bool isPerform = false)
        {
            /*" -4959- MOVE 'NAO' TO W-CHAVE-TEM-INSS */
            _.Move("NAO", AREA_DE_WORK.W_CHAVE_TEM_INSS);

            /*" -4961- INITIALIZE W-ATTRVAL */
            _.Initialize(
                AREA_DE_WORK.W_ATTRVAL
            );

            /*" -4962- IF GETIPIMP-COD-IMP-INTERNO EQUAL 1 */

            if (GETIPIMP.DCLGE_TIPO_IMPOSTO.GETIPIMP_COD_IMP_INTERNO == 1)
            {

                /*" -4963- EVALUATE W-CHAVE-TIPO-PESSOA-PF-PJ */
                switch (AREA_DE_WORK.W_CHAVE_TIPO_PESSOA_PF_PJ.Value.Trim())
                {

                    /*" -4965- WHEN 'PF' */
                    case "PF":

                        /*" -4966- MOVE 'S1' TO W-ATTRVAL */
                        _.Move("S1", AREA_DE_WORK.W_ATTRVAL);

                        /*" -4968- WHEN 'PJ' */
                        break;
                    case "PJ":

                        /*" -4969- IF FIPADOIM-ALIQ-TRIBUTACAO EQUAL 1,00000 */

                        if (FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_ALIQ_TRIBUTACAO == 1.00000)
                        {

                            /*" -4970- MOVE 'J2' TO ATTRVAL20-GERAL */
                            _.Move("J2", W_REGISTRO_SIAS_GERAL.ATTRVAL20_GERAL);

                            /*" -4971- ELSE */
                        }
                        else
                        {


                            /*" -4972- MOVE 'J1' TO ATTRVAL20-GERAL */
                            _.Move("J1", W_REGISTRO_SIAS_GERAL.ATTRVAL20_GERAL);

                            /*" -4974- END-IF */
                        }


                        /*" -4975- MOVE ALL 'X' TO W-ATTRVAL */
                        _.MoveAll("X", AREA_DE_WORK.W_ATTRVAL);

                        /*" -4976- WHEN OTHER */
                        break;
                    default:

                        /*" -4977- MOVE ALL '?34?' TO ATTRVAL20-GERAL */
                        _.MoveAll("?34?", W_REGISTRO_SIAS_GERAL.ATTRVAL20_GERAL);

                        /*" -4980- END-EVALUATE */
                        break;
                }


                /*" -4981- EVALUATE WS-COD-EVENTO-NUM */
                switch (FILLER_18.WS_COD_EVENTO_NUM.Value.Trim())
                {

                    /*" -4982- WHEN '09001' */
                    case "09001":

                        /*" -4983- WHEN '09010' */
                        break;
                    case "09010":

                    /*" -4984- WHEN '09014' */
                    case "09014":

                        /*" -4985- WHEN '09023' */
                        break;
                    case "09023":

                        /*" -4986- MOVE 'ATR_IRIQ' TO ATTR07-GERAL */
                        _.Move("ATR_IRIQ", W_REGISTRO_SIAS_GERAL.ATTR07_GERAL);

                        /*" -4987- MOVE W-ATTRVAL TO ATTRVAL07-GERAL */
                        _.Move(AREA_DE_WORK.W_ATTRVAL, W_REGISTRO_SIAS_GERAL.ATTRVAL07_GERAL);

                        /*" -4988- WHEN '09002' */
                        break;
                    case "09002":

                    /*" -4989- WHEN '09006' */
                    case "09006":

                        /*" -4990- WHEN '09007' */
                        break;
                    case "09007":

                    /*" -4991- WHEN '09009' */
                    case "09009":

                        /*" -4992- WHEN '09022' */
                        break;
                    case "09022":

                        /*" -4993- MOVE 'ATR_IRIQ' TO ATTR09-GERAL */
                        _.Move("ATR_IRIQ", W_REGISTRO_SIAS_GERAL.ATTR09_GERAL);

                        /*" -4994- MOVE W-ATTRVAL TO ATTRVAL09-GERAL */
                        _.Move(AREA_DE_WORK.W_ATTRVAL, W_REGISTRO_SIAS_GERAL.ATTRVAL09_GERAL);

                        /*" -4995- WHEN '09005' */
                        break;
                    case "09005":

                    /*" -4996- WHEN '09011' */
                    case "09011":

                        /*" -4997- WHEN '09012' */
                        break;
                    case "09012":

                    /*" -4998- WHEN '09013' */
                    case "09013":

                        /*" -4999- WHEN '09024' */
                        break;
                    case "09024":

                        /*" -5000- MOVE 'ATR_IRIQ' TO ATTR06-GERAL */
                        _.Move("ATR_IRIQ", W_REGISTRO_SIAS_GERAL.ATTR06_GERAL);

                        /*" -5001- MOVE W-ATTRVAL TO ATTRVAL06-GERAL */
                        _.Move(AREA_DE_WORK.W_ATTRVAL, W_REGISTRO_SIAS_GERAL.ATTRVAL06_GERAL);

                        /*" -5002- WHEN '09003' */
                        break;
                    case "09003":

                    /*" -5003- WHEN '09004' */
                    case "09004":

                        /*" -5004- WHEN '09008' */
                        break;
                    case "09008":

                    /*" -5005- WHEN '09015' */
                    case "09015":

                        /*" -5006- WHEN '09025' */
                        break;
                    case "09025":

                        /*" -5007- MOVE 'ATR_IRIQ' TO ATTR36-GERAL */
                        _.Move("ATR_IRIQ", W_REGISTRO_SIAS_GERAL.ATTR36_GERAL);

                        /*" -5008- MOVE W-ATTRVAL TO ATTRVAL36-GERAL */
                        _.Move(AREA_DE_WORK.W_ATTRVAL, W_REGISTRO_SIAS_GERAL.ATTRVAL36_GERAL);

                        /*" -5010- END-EVALUATE */
                        break;
                }


                /*" -5011- MOVE FIPADOLA-VALOR-LANCAMENTO TO W-VALOR-GERAL-VALOR */
                _.Move(FIPADOLA.DCLFI_PAGA_DOCF_LANC.FIPADOLA_VALOR_LANCAMENTO, W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

                /*" -5012- ADD FIPADOLA-VALOR-LANCAMENTO TO W-TOTAL-VALORES */
                AREA_DE_WORK.W_TOTAL_VALORES.Value = AREA_DE_WORK.W_TOTAL_VALORES + FIPADOLA.DCLFI_PAGA_DOCF_LANC.FIPADOLA_VALOR_LANCAMENTO;

                /*" -5013- EVALUATE W-CHAVE-TIPO-PESSOA-PF-PJ */
                switch (AREA_DE_WORK.W_CHAVE_TIPO_PESSOA_PF_PJ.Value.Trim())
                {

                    /*" -5014- WHEN 'PF' */
                    case "PF":

                        /*" -5015- MOVE 'CV_IRFAB' TO COD04-GERAL */
                        _.Move("CV_IRFAB", W_REGISTRO_SIAS_GERAL.COD04_GERAL);

                        /*" -5016- MOVE W-VALOR-GERAL-X TO VALO04-GERAL */
                        _.Move(W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO04_GERAL);

                        /*" -5017- MOVE '0,00' TO VALO018-GERAL */
                        _.Move("0,00", W_REGISTRO_SIAS_GERAL.VALO018_GERAL);

                        /*" -5018- WHEN 'PJ' */
                        break;
                    case "PJ":

                        /*" -5019- MOVE 'CV_IRJBS' TO COD018-GERAL */
                        _.Move("CV_IRJBS", W_REGISTRO_SIAS_GERAL.COD018_GERAL);

                        /*" -5020- MOVE W-VALOR-GERAL-X TO VALO018-GERAL */
                        _.Move(W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO018_GERAL);

                        /*" -5021- MOVE '0,00' TO VALO04-GERAL */
                        _.Move("0,00", W_REGISTRO_SIAS_GERAL.VALO04_GERAL);

                        /*" -5022- WHEN OTHER */
                        break;
                    default:

                        /*" -5023- MOVE ALL '?35?' TO COD06-GERAL VALO06-GERAL */
                        _.MoveAll("?35?", W_REGISTRO_SIAS_GERAL.COD06_GERAL, W_REGISTRO_SIAS_GERAL.VALO06_GERAL);

                        /*" -5024- MOVE ALL '?36?' TO COD018-GERAL VALO018-GERAL */
                        _.MoveAll("?36?", W_REGISTRO_SIAS_GERAL.COD018_GERAL, W_REGISTRO_SIAS_GERAL.VALO018_GERAL);

                        /*" -5025- END-EVALUATE */
                        break;
                }


                /*" -5041- END-IF */
            }


            /*" -5042- MOVE 'ATR_CDIN' TO ATTR23-GERAL. */
            _.Move("ATR_CDIN", W_REGISTRO_SIAS_GERAL.ATTR23_GERAL);

            /*" -5043- MOVE 'CV_INSBS' TO COD010-GERAL. */
            _.Move("CV_INSBS", W_REGISTRO_SIAS_GERAL.COD010_GERAL);

            /*" -5044- MOVE 'ATR_CDIP' TO ATTR27-GERAL. */
            _.Move("ATR_CDIP", W_REGISTRO_SIAS_GERAL.ATTR27_GERAL);

            /*" -5046- MOVE 'CV_INPBS' TO COD020-GERAL. */
            _.Move("CV_INPBS", W_REGISTRO_SIAS_GERAL.COD020_GERAL);

            /*" -5047- IF GETIPIMP-COD-IMP-INTERNO EQUAL 2 */

            if (GETIPIMP.DCLGE_TIPO_IMPOSTO.GETIPIMP_COD_IMP_INTERNO == 2)
            {

                /*" -5050- MOVE ALL 'X' TO ATTRVAL23-GERAL ATTRVAL27-GERAL */
                _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL23_GERAL, W_REGISTRO_SIAS_GERAL.ATTRVAL27_GERAL);

                /*" -5053- MOVE '0,00' TO VALO010-GERAL VALO020-GERAL */
                _.Move("0,00", W_REGISTRO_SIAS_GERAL.VALO010_GERAL, W_REGISTRO_SIAS_GERAL.VALO020_GERAL);

                /*" -5055- IF FIPADOLA-VALOR-LANCAMENTO GREATER ZEROS AND W-CHAVE-TEM-CAPA-LOTE = 'SIM' */

                if (FIPADOLA.DCLFI_PAGA_DOCF_LANC.FIPADOLA_VALOR_LANCAMENTO > 00 && AREA_DE_WORK.W_CHAVE_TEM_CAPA_LOTE == "SIM")
                {

                    /*" -5056- MOVE GE612-COD-TP-SERVICO-INSS TO W-ATTRVAL */
                    _.Move(GE612.DCLGE_TP_SERVICO_INSS.GE612_COD_TP_SERVICO_INSS, AREA_DE_WORK.W_ATTRVAL);

                    /*" -5057- ELSE */
                }
                else
                {


                    /*" -5058- MOVE ALL 'X' TO W-ATTRVAL */
                    _.MoveAll("X", AREA_DE_WORK.W_ATTRVAL);

                    /*" -5060- END-IF */
                }


                /*" -5064- MOVE 'ATR_TSER' TO W-ATTR */
                _.Move("ATR_TSER", AREA_DE_WORK.W_ATTR);

                /*" -5065- EVALUATE WS-COD-EVENTO-NUM */
                switch (FILLER_18.WS_COD_EVENTO_NUM.Value.Trim())
                {

                    /*" -5066- WHEN '09001' */
                    case "09001":

                        /*" -5067- WHEN '09010' */
                        break;
                    case "09010":

                    /*" -5068- WHEN '09014' */
                    case "09014":

                        /*" -5069- WHEN '09023' */
                        break;
                    case "09023":

                        /*" -5070- MOVE W-ATTR TO ATTR40-GERAL */
                        _.Move(AREA_DE_WORK.W_ATTR, W_REGISTRO_SIAS_GERAL.ATTR40_GERAL);

                        /*" -5071- MOVE W-ATTRVAL TO ATTRVAL40-GERAL */
                        _.Move(AREA_DE_WORK.W_ATTRVAL, W_REGISTRO_SIAS_GERAL.ATTRVAL40_GERAL);

                        /*" -5072- WHEN '09002' */
                        break;
                    case "09002":

                    /*" -5073- WHEN '09006' */
                    case "09006":

                        /*" -5074- WHEN '09007' */
                        break;
                    case "09007":

                    /*" -5075- WHEN '09009' */
                    case "09009":

                        /*" -5076- WHEN '09022' */
                        break;
                    case "09022":

                        /*" -5077- MOVE W-ATTR TO ATTR40-GERAL */
                        _.Move(AREA_DE_WORK.W_ATTR, W_REGISTRO_SIAS_GERAL.ATTR40_GERAL);

                        /*" -5078- MOVE W-ATTRVAL TO ATTRVAL40-GERAL */
                        _.Move(AREA_DE_WORK.W_ATTRVAL, W_REGISTRO_SIAS_GERAL.ATTRVAL40_GERAL);

                        /*" -5079- WHEN '09005' */
                        break;
                    case "09005":

                    /*" -5080- WHEN '09011' */
                    case "09011":

                        /*" -5081- WHEN '09012' */
                        break;
                    case "09012":

                    /*" -5082- WHEN '09013' */
                    case "09013":

                        /*" -5083- WHEN '09024' */
                        break;
                    case "09024":

                        /*" -5084- MOVE W-ATTR TO ATTR37-GERAL */
                        _.Move(AREA_DE_WORK.W_ATTR, W_REGISTRO_SIAS_GERAL.ATTR37_GERAL);

                        /*" -5085- MOVE W-ATTRVAL TO ATTRVAL37-GERAL */
                        _.Move(AREA_DE_WORK.W_ATTRVAL, W_REGISTRO_SIAS_GERAL.ATTRVAL37_GERAL);

                        /*" -5086- WHEN '09003' */
                        break;
                    case "09003":

                    /*" -5087- WHEN '09004' */
                    case "09004":

                        /*" -5088- WHEN '09008' */
                        break;
                    case "09008":

                    /*" -5089- WHEN '09015' */
                    case "09015":

                        /*" -5090- WHEN '09025' */
                        break;
                    case "09025":

                        /*" -5091- MOVE W-ATTR TO ATTR43-GERAL */
                        _.Move(AREA_DE_WORK.W_ATTR, W_REGISTRO_SIAS_GERAL.ATTR43_GERAL);

                        /*" -5092- MOVE W-ATTRVAL TO ATTRVAL43-GERAL */
                        _.Move(AREA_DE_WORK.W_ATTRVAL, W_REGISTRO_SIAS_GERAL.ATTRVAL43_GERAL);

                        /*" -5094- END-EVALUATE */
                        break;
                }


                /*" -5095- EVALUATE W-CHAVE-TIPO-PESSOA-PF-PJ */
                switch (AREA_DE_WORK.W_CHAVE_TIPO_PESSOA_PF_PJ.Value.Trim())
                {

                    /*" -5101- WHEN 'PF' */
                    case "PF":

                        /*" -5102- IF FIPADOLA-VALOR-LANCAMENTO GREATER ZEROS */

                        if (FIPADOLA.DCLFI_PAGA_DOCF_LANC.FIPADOLA_VALOR_LANCAMENTO > 00)
                        {

                            /*" -5103- MOVE 'N2' TO ATTRVAL23-GERAL */
                            _.Move("N2", W_REGISTRO_SIAS_GERAL.ATTRVAL23_GERAL);

                            /*" -5105- MOVE FIPADOLA-VALOR-LANCAMENTO TO W-VALOR-GERAL-VALOR */
                            _.Move(FIPADOLA.DCLFI_PAGA_DOCF_LANC.FIPADOLA_VALOR_LANCAMENTO, W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

                            /*" -5106- MOVE W-VALOR-GERAL-X TO VALO010-GERAL */
                            _.Move(W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO010_GERAL);

                            /*" -5110- MOVE 'SIM' TO W-CHAVE-TEM-INSS */
                            _.Move("SIM", AREA_DE_WORK.W_CHAVE_TEM_INSS);

                            /*" -5111- MOVE 'M1' TO ATTRVAL27-GERAL */
                            _.Move("M1", W_REGISTRO_SIAS_GERAL.ATTRVAL27_GERAL);

                            /*" -5113- MOVE FIPADOLA-VALOR-LANCAMENTO TO W-VALOR-GERAL-VALOR */
                            _.Move(FIPADOLA.DCLFI_PAGA_DOCF_LANC.FIPADOLA_VALOR_LANCAMENTO, W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

                            /*" -5114- MOVE W-VALOR-GERAL-X TO VALO020-GERAL */
                            _.Move(W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO020_GERAL);

                            /*" -5116- END-IF */
                        }


                        /*" -5117- WHEN 'PJ' */
                        break;
                    case "PJ":

                        /*" -5118- IF FIPADOIM-ALIQ-TRIBUTACAO EQUAL 3,5 */

                        if (FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_ALIQ_TRIBUTACAO == 3.5)
                        {

                            /*" -5119- MOVE 'N3' TO ATTRVAL23-GERAL */
                            _.Move("N3", W_REGISTRO_SIAS_GERAL.ATTRVAL23_GERAL);

                            /*" -5121- MOVE FIPADOLA-VALOR-LANCAMENTO TO W-VALOR-GERAL-VALOR */
                            _.Move(FIPADOLA.DCLFI_PAGA_DOCF_LANC.FIPADOLA_VALOR_LANCAMENTO, W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

                            /*" -5122- MOVE W-VALOR-GERAL-X TO VALO010-GERAL */
                            _.Move(W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO010_GERAL);

                            /*" -5123- MOVE 'SIM' TO W-CHAVE-TEM-INSS */
                            _.Move("SIM", AREA_DE_WORK.W_CHAVE_TEM_INSS);

                            /*" -5125- END-IF */
                        }


                        /*" -5126- IF FIPADOIM-ALIQ-TRIBUTACAO EQUAL 11 */

                        if (FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_ALIQ_TRIBUTACAO == 11)
                        {

                            /*" -5127- MOVE 'N1' TO ATTRVAL23-GERAL */
                            _.Move("N1", W_REGISTRO_SIAS_GERAL.ATTRVAL23_GERAL);

                            /*" -5129- MOVE FIPADOLA-VALOR-LANCAMENTO TO W-VALOR-GERAL-VALOR */
                            _.Move(FIPADOLA.DCLFI_PAGA_DOCF_LANC.FIPADOLA_VALOR_LANCAMENTO, W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

                            /*" -5130- MOVE W-VALOR-GERAL-X TO VALO010-GERAL */
                            _.Move(W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO010_GERAL);

                            /*" -5131- MOVE 'SIM' TO W-CHAVE-TEM-INSS */
                            _.Move("SIM", AREA_DE_WORK.W_CHAVE_TEM_INSS);

                            /*" -5133- END-IF */
                        }


                        /*" -5134- MOVE ALL 'X' TO ATTRVAL27-GERAL */
                        _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL27_GERAL);

                        /*" -5136- MOVE '0,00' TO VALO020-GERAL */
                        _.Move("0,00", W_REGISTRO_SIAS_GERAL.VALO020_GERAL);

                        /*" -5137- WHEN OTHER */
                        break;
                    default:

                        /*" -5138- MOVE ALL '?30?' TO ATTRVAL23-GERAL */
                        _.MoveAll("?30?", W_REGISTRO_SIAS_GERAL.ATTRVAL23_GERAL);

                        /*" -5139- END-EVALUATE */
                        break;
                }


                /*" -5146- END-IF */
            }


            /*" -5147- IF GETIPIMP-COD-IMP-INTERNO EQUAL 3 */

            if (GETIPIMP.DCLGE_TIPO_IMPOSTO.GETIPIMP_COD_IMP_INTERNO == 3)
            {

                /*" -5149- MOVE 'ATR_CDIS' TO ATTR22-GERAL */
                _.Move("ATR_CDIS", W_REGISTRO_SIAS_GERAL.ATTR22_GERAL);

                /*" -5150- IF FIPADOIM-COD-IMPOSTO-SAP-NN >= 0 */

                if (FIPADOIM_COD_IMPOSTO_SAP_NN >= 0)
                {

                    /*" -5151- MOVE FIPADOIM-COD-IMPOSTO-SAP TO ATTRVAL22-GERAL */
                    _.Move(FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_COD_IMPOSTO_SAP, W_REGISTRO_SIAS_GERAL.ATTRVAL22_GERAL);

                    /*" -5152- ELSE */
                }
                else
                {


                    /*" -5153- MOVE ALL 'X' TO ATTRVAL22-GERAL */
                    _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL22_GERAL);

                    /*" -5171- END-IF */
                }


                /*" -5172- IF FIPADOIM-ALIQ-TRIBUTACAO NOT EQUAL ZEROS */

                if (FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_ALIQ_TRIBUTACAO != 00)
                {

                    /*" -5173- MOVE 'CV_ISSBS' TO COD08-GERAL */
                    _.Move("CV_ISSBS", W_REGISTRO_SIAS_GERAL.COD08_GERAL);

                    /*" -5174- MOVE FIPADOLA-VALOR-LANCAMENTO TO W-VALOR-GERAL-VALOR */
                    _.Move(FIPADOLA.DCLFI_PAGA_DOCF_LANC.FIPADOLA_VALOR_LANCAMENTO, W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

                    /*" -5175- ADD FIPADOLA-VALOR-LANCAMENTO TO W-TOTAL-VALORES */
                    AREA_DE_WORK.W_TOTAL_VALORES.Value = AREA_DE_WORK.W_TOTAL_VALORES + FIPADOLA.DCLFI_PAGA_DOCF_LANC.FIPADOLA_VALOR_LANCAMENTO;

                    /*" -5176- MOVE W-VALOR-GERAL-X TO VALO08-GERAL */
                    _.Move(W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO08_GERAL);

                    /*" -5177- END-IF */
                }


                /*" -5183- END-IF */
            }


            /*" -5184- IF GETIPIMP-COD-IMP-INTERNO EQUAL 7 */

            if (GETIPIMP.DCLGE_TIPO_IMPOSTO.GETIPIMP_COD_IMP_INTERNO == 7)
            {

                /*" -5185- MOVE 'ATR_CDCS' TO ATTR26-GERAL */
                _.Move("ATR_CDCS", W_REGISTRO_SIAS_GERAL.ATTR26_GERAL);

                /*" -5186- IF FIPADOIM-VALOR-IMPOSTO EQUAL 0 */

                if (FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_VALOR_IMPOSTO == 0)
                {

                    /*" -5187- MOVE 'I1' TO ATTRVAL26-GERAL */
                    _.Move("I1", W_REGISTRO_SIAS_GERAL.ATTRVAL26_GERAL);

                    /*" -5188- ELSE */
                }
                else
                {


                    /*" -5190- MOVE 'I2' TO ATTRVAL26-GERAL. */
                    _.Move("I2", W_REGISTRO_SIAS_GERAL.ATTRVAL26_GERAL);
                }

            }


            /*" -5191- IF GETIPIMP-COD-IMP-INTERNO EQUAL 7 */

            if (GETIPIMP.DCLGE_TIPO_IMPOSTO.GETIPIMP_COD_IMP_INTERNO == 7)
            {

                /*" -5192- MOVE 'CV_CSLBS' TO COD016-GERAL */
                _.Move("CV_CSLBS", W_REGISTRO_SIAS_GERAL.COD016_GERAL);

                /*" -5193- MOVE FIPADOLA-VALOR-LANCAMENTO TO W-VALOR-GERAL-VALOR */
                _.Move(FIPADOLA.DCLFI_PAGA_DOCF_LANC.FIPADOLA_VALOR_LANCAMENTO, W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

                /*" -5194- ADD FIPADOLA-VALOR-LANCAMENTO TO W-TOTAL-VALORES */
                AREA_DE_WORK.W_TOTAL_VALORES.Value = AREA_DE_WORK.W_TOTAL_VALORES + FIPADOLA.DCLFI_PAGA_DOCF_LANC.FIPADOLA_VALOR_LANCAMENTO;

                /*" -5199- MOVE W-VALOR-GERAL-X TO VALO016-GERAL . */
                _.Move(W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO016_GERAL);
            }


            /*" -5200- IF GETIPIMP-COD-IMP-INTERNO EQUAL 8 */

            if (GETIPIMP.DCLGE_TIPO_IMPOSTO.GETIPIMP_COD_IMP_INTERNO == 8)
            {

                /*" -5201- MOVE 'ATR_CDCF' TO ATTR25-GERAL */
                _.Move("ATR_CDCF", W_REGISTRO_SIAS_GERAL.ATTR25_GERAL);

                /*" -5202- IF FIPADOIM-VALOR-IMPOSTO EQUAL 0 */

                if (FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_VALOR_IMPOSTO == 0)
                {

                    /*" -5203- MOVE 'I6' TO ATTRVAL25-GERAL */
                    _.Move("I6", W_REGISTRO_SIAS_GERAL.ATTRVAL25_GERAL);

                    /*" -5204- ELSE */
                }
                else
                {


                    /*" -5206- MOVE 'I5' TO ATTRVAL25-GERAL. */
                    _.Move("I5", W_REGISTRO_SIAS_GERAL.ATTRVAL25_GERAL);
                }

            }


            /*" -5207- IF GETIPIMP-COD-IMP-INTERNO EQUAL 8 */

            if (GETIPIMP.DCLGE_TIPO_IMPOSTO.GETIPIMP_COD_IMP_INTERNO == 8)
            {

                /*" -5208- MOVE 'CV_COFBS' TO COD014-GERAL */
                _.Move("CV_COFBS", W_REGISTRO_SIAS_GERAL.COD014_GERAL);

                /*" -5209- MOVE FIPADOLA-VALOR-LANCAMENTO TO W-VALOR-GERAL-VALOR */
                _.Move(FIPADOLA.DCLFI_PAGA_DOCF_LANC.FIPADOLA_VALOR_LANCAMENTO, W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

                /*" -5210- ADD FIPADOLA-VALOR-LANCAMENTO TO W-TOTAL-VALORES */
                AREA_DE_WORK.W_TOTAL_VALORES.Value = AREA_DE_WORK.W_TOTAL_VALORES + FIPADOLA.DCLFI_PAGA_DOCF_LANC.FIPADOLA_VALOR_LANCAMENTO;

                /*" -5215- MOVE W-VALOR-GERAL-X TO VALO014-GERAL . */
                _.Move(W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO014_GERAL);
            }


            /*" -5216- IF GETIPIMP-COD-IMP-INTERNO EQUAL 9 */

            if (GETIPIMP.DCLGE_TIPO_IMPOSTO.GETIPIMP_COD_IMP_INTERNO == 9)
            {

                /*" -5217- MOVE 'ATR_CDPS' TO ATTR24-GERAL */
                _.Move("ATR_CDPS", W_REGISTRO_SIAS_GERAL.ATTR24_GERAL);

                /*" -5218- IF FIPADOIM-VALOR-IMPOSTO EQUAL 0 */

                if (FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_VALOR_IMPOSTO == 0)
                {

                    /*" -5219- MOVE 'I4' TO ATTRVAL24-GERAL */
                    _.Move("I4", W_REGISTRO_SIAS_GERAL.ATTRVAL24_GERAL);

                    /*" -5220- ELSE */
                }
                else
                {


                    /*" -5222- MOVE 'I3' TO ATTRVAL24-GERAL. */
                    _.Move("I3", W_REGISTRO_SIAS_GERAL.ATTRVAL24_GERAL);
                }

            }


            /*" -5223- IF GETIPIMP-COD-IMP-INTERNO EQUAL 9 */

            if (GETIPIMP.DCLGE_TIPO_IMPOSTO.GETIPIMP_COD_IMP_INTERNO == 9)
            {

                /*" -5224- MOVE 'CV_PISBS' TO COD012-GERAL */
                _.Move("CV_PISBS", W_REGISTRO_SIAS_GERAL.COD012_GERAL);

                /*" -5225- MOVE FIPADOLA-VALOR-LANCAMENTO TO W-VALOR-GERAL-VALOR */
                _.Move(FIPADOLA.DCLFI_PAGA_DOCF_LANC.FIPADOLA_VALOR_LANCAMENTO, W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

                /*" -5226- ADD FIPADOLA-VALOR-LANCAMENTO TO W-TOTAL-VALORES */
                AREA_DE_WORK.W_TOTAL_VALORES.Value = AREA_DE_WORK.W_TOTAL_VALORES + FIPADOLA.DCLFI_PAGA_DOCF_LANC.FIPADOLA_VALOR_LANCAMENTO;

                /*" -5232- MOVE W-VALOR-GERAL-X TO VALO012-GERAL . */
                _.Move(W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO012_GERAL);
            }


            /*" -5232- PERFORM R4001-FETCH-IMPOSTOS THRU R4001-EXIT. */

            R4001_FETCH_IMPOSTOS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R4001_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4010_EXIT*/

        [StopWatch]
        /*" R4020-MANDA-IMP-CALCULADO */
        private void R4020_MANDA_IMP_CALCULADO(bool isPerform = false)
        {
            /*" -5249- IF GETIPIMP-COD-IMP-INTERNO EQUAL 1 */

            if (GETIPIMP.DCLGE_TIPO_IMPOSTO.GETIPIMP_COD_IMP_INTERNO == 1)
            {

                /*" -5250- MOVE FIPADOIM-VALOR-IMPOSTO TO W-VALOR-GERAL-VALOR */
                _.Move(FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_VALOR_IMPOSTO, W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

                /*" -5251- ADD FIPADOIM-VALOR-IMPOSTO TO W-TOTAL-VALORES */
                AREA_DE_WORK.W_TOTAL_VALORES.Value = AREA_DE_WORK.W_TOTAL_VALORES + FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_VALOR_IMPOSTO;

                /*" -5252- IF W-CHAVE-TIPO-PESSOA-PF-PJ EQUAL 'PF' */

                if (AREA_DE_WORK.W_CHAVE_TIPO_PESSOA_PF_PJ == "PF")
                {

                    /*" -5253- MOVE 'CV_IRFRT' TO COD07-GERAL */
                    _.Move("CV_IRFRT", W_REGISTRO_SIAS_GERAL.COD07_GERAL);

                    /*" -5254- MOVE W-VALOR-GERAL-X TO VALO07-GERAL */
                    _.Move(W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO07_GERAL);

                    /*" -5255- ELSE */
                }
                else
                {


                    /*" -5256- IF W-CHAVE-TIPO-PESSOA-PF-PJ EQUAL 'PJ' */

                    if (AREA_DE_WORK.W_CHAVE_TIPO_PESSOA_PF_PJ == "PJ")
                    {

                        /*" -5257- MOVE 'CV_IRJRT' TO COD019-GERAL */
                        _.Move("CV_IRJRT", W_REGISTRO_SIAS_GERAL.COD019_GERAL);

                        /*" -5258- MOVE W-VALOR-GERAL-X TO VALO019-GERAL */
                        _.Move(W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO019_GERAL);

                        /*" -5259- ELSE */
                    }
                    else
                    {


                        /*" -5260- MOVE ALL '?37?' TO COD07-GERAL VALO07-GERAL */
                        _.MoveAll("?37?", W_REGISTRO_SIAS_GERAL.COD07_GERAL, W_REGISTRO_SIAS_GERAL.VALO07_GERAL);

                        /*" -5264- MOVE ALL '?38?' TO COD019-GERAL VALO019-GERAL. */
                        _.MoveAll("?38?", W_REGISTRO_SIAS_GERAL.COD019_GERAL, W_REGISTRO_SIAS_GERAL.VALO019_GERAL);
                    }

                }

            }


            /*" -5265- IF GETIPIMP-COD-IMP-INTERNO EQUAL 2 */

            if (GETIPIMP.DCLGE_TIPO_IMPOSTO.GETIPIMP_COD_IMP_INTERNO == 2)
            {

                /*" -5266- MOVE 'CV_INSRT' TO COD011-GERAL */
                _.Move("CV_INSRT", W_REGISTRO_SIAS_GERAL.COD011_GERAL);

                /*" -5267- MOVE FIPADOIM-VALOR-IMPOSTO TO W-VALOR-GERAL-VALOR */
                _.Move(FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_VALOR_IMPOSTO, W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

                /*" -5268- ADD FIPADOIM-VALOR-IMPOSTO TO W-TOTAL-VALORES */
                AREA_DE_WORK.W_TOTAL_VALORES.Value = AREA_DE_WORK.W_TOTAL_VALORES + FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_VALOR_IMPOSTO;

                /*" -5272- MOVE W-VALOR-GERAL-X TO VALO011-GERAL . */
                _.Move(W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO011_GERAL);
            }


            /*" -5273- IF GETIPIMP-COD-IMP-INTERNO EQUAL 3 */

            if (GETIPIMP.DCLGE_TIPO_IMPOSTO.GETIPIMP_COD_IMP_INTERNO == 3)
            {

                /*" -5274- MOVE 'CV_ISSRT' TO COD09-GERAL */
                _.Move("CV_ISSRT", W_REGISTRO_SIAS_GERAL.COD09_GERAL);

                /*" -5275- MOVE FIPADOIM-VALOR-IMPOSTO TO W-VALOR-GERAL-VALOR */
                _.Move(FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_VALOR_IMPOSTO, W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

                /*" -5276- ADD FIPADOIM-VALOR-IMPOSTO TO W-TOTAL-VALORES */
                AREA_DE_WORK.W_TOTAL_VALORES.Value = AREA_DE_WORK.W_TOTAL_VALORES + FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_VALOR_IMPOSTO;

                /*" -5280- MOVE W-VALOR-GERAL-X TO VALO09-GERAL . */
                _.Move(W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO09_GERAL);
            }


            /*" -5281- IF GETIPIMP-COD-IMP-INTERNO EQUAL 7 */

            if (GETIPIMP.DCLGE_TIPO_IMPOSTO.GETIPIMP_COD_IMP_INTERNO == 7)
            {

                /*" -5282- MOVE 'CV_CSLRT' TO COD017-GERAL */
                _.Move("CV_CSLRT", W_REGISTRO_SIAS_GERAL.COD017_GERAL);

                /*" -5283- MOVE FIPADOIM-VALOR-IMPOSTO TO W-VALOR-GERAL-VALOR */
                _.Move(FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_VALOR_IMPOSTO, W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

                /*" -5284- ADD FIPADOIM-VALOR-IMPOSTO TO W-TOTAL-VALORES */
                AREA_DE_WORK.W_TOTAL_VALORES.Value = AREA_DE_WORK.W_TOTAL_VALORES + FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_VALOR_IMPOSTO;

                /*" -5288- MOVE W-VALOR-GERAL-X TO VALO017-GERAL . */
                _.Move(W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO017_GERAL);
            }


            /*" -5289- IF GETIPIMP-COD-IMP-INTERNO EQUAL 8 */

            if (GETIPIMP.DCLGE_TIPO_IMPOSTO.GETIPIMP_COD_IMP_INTERNO == 8)
            {

                /*" -5290- MOVE 'CV_COFRT' TO COD015-GERAL */
                _.Move("CV_COFRT", W_REGISTRO_SIAS_GERAL.COD015_GERAL);

                /*" -5291- MOVE FIPADOIM-VALOR-IMPOSTO TO W-VALOR-GERAL-VALOR */
                _.Move(FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_VALOR_IMPOSTO, W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

                /*" -5292- ADD FIPADOIM-VALOR-IMPOSTO TO W-TOTAL-VALORES */
                AREA_DE_WORK.W_TOTAL_VALORES.Value = AREA_DE_WORK.W_TOTAL_VALORES + FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_VALOR_IMPOSTO;

                /*" -5296- MOVE W-VALOR-GERAL-X TO VALO015-GERAL . */
                _.Move(W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO015_GERAL);
            }


            /*" -5297- IF GETIPIMP-COD-IMP-INTERNO EQUAL 9 */

            if (GETIPIMP.DCLGE_TIPO_IMPOSTO.GETIPIMP_COD_IMP_INTERNO == 9)
            {

                /*" -5298- MOVE 'CV_PISRT' TO COD013-GERAL */
                _.Move("CV_PISRT", W_REGISTRO_SIAS_GERAL.COD013_GERAL);

                /*" -5299- MOVE FIPADOIM-VALOR-IMPOSTO TO W-VALOR-GERAL-VALOR */
                _.Move(FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_VALOR_IMPOSTO, W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

                /*" -5300- ADD FIPADOIM-VALOR-IMPOSTO TO W-TOTAL-VALORES */
                AREA_DE_WORK.W_TOTAL_VALORES.Value = AREA_DE_WORK.W_TOTAL_VALORES + FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_VALOR_IMPOSTO;

                /*" -5300- MOVE W-VALOR-GERAL-X TO VALO013-GERAL . */
                _.Move(W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO013_GERAL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4020_EXIT*/

        [StopWatch]
        /*" R5000-SELECT-DOC-FISCAL */
        private void R5000_SELECT_DOC_FISCAL(bool isPerform = false)
        {
            /*" -5308- INITIALIZE DCLFI-PAGA-DOC-FISCAL */
            _.Initialize(
                FIPADOFI.DCLFI_PAGA_DOC_FISCAL
            );

            /*" -5310- MOVE 'NAO' TO W-CHAVE-TEM-NOTA-FISCAL */
            _.Move("NAO", AREA_DE_WORK.W_CHAVE_TEM_NOTA_FISCAL);

            /*" -5325- PERFORM R5000_SELECT_DOC_FISCAL_DB_SELECT_1 */

            R5000_SELECT_DOC_FISCAL_DB_SELECT_1();

            /*" -5328- EVALUATE SQLCODE */
            switch (DB.SQLCODE.Value)
            {

                /*" -5329- WHEN 0 */
                case 0:

                    /*" -5330- MOVE 'SIM' TO W-CHAVE-TEM-NOTA-FISCAL */
                    _.Move("SIM", AREA_DE_WORK.W_CHAVE_TEM_NOTA_FISCAL);

                    /*" -5331- WHEN +100 */
                    break;
                case +100:

                    /*" -5332- MOVE 'NAO' TO W-CHAVE-TEM-NOTA-FISCAL */
                    _.Move("NAO", AREA_DE_WORK.W_CHAVE_TEM_NOTA_FISCAL);

                    /*" -5333- WHEN OTHER */
                    break;
                default:

                    /*" -5334- DISPLAY 'SISAP01B - ERRO CONSULTA NOTA FISCAL' */
                    _.Display($"SISAP01B - ERRO CONSULTA NOTA FISCAL");

                    /*" -5336- DISPLAY 'NUM_APOL_SINISTRO= ' SINISHIS-NUM-APOL-SINISTRO */
                    _.Display($"NUM_APOL_SINISTRO= {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                    /*" -5339- DISPLAY 'OCORR_HISTORICO  = ' SINISHIS-OCORR-HISTORICO */
                    _.Display($"OCORR_HISTORICO  = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}");

                    /*" -5340- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;

                    /*" -5341- END-EVALUATE */
                    break;
            }


            /*" -5341- . */

        }

        [StopWatch]
        /*" R5000-SELECT-DOC-FISCAL-DB-SELECT-1 */
        public void R5000_SELECT_DOC_FISCAL_DB_SELECT_1()
        {
            /*" -5325- EXEC SQL SELECT F.NUM_DOC_FISCAL , F.SERIE_DOC_FISCAL , F.DATA_EMISSAO_DOC INTO :FIPADOFI-NUM-DOC-FISCAL:NULL-NUM-DOC-FISCAL ,:FIPADOFI-SERIE-DOC-FISCAL:NULL-SERIE-DOC-FISCAL ,:FIPADOFI-DATA-EMISSAO-DOC:NULL-DATA-EMISSAO-DOC FROM SEGUROS.SI_PAGA_DOC_FISCAL A JOIN SEGUROS.FI_PAGA_DOC_FISCAL F ON F.NUM_DOCF_INTERNO = A.NUM_DOCF_INTERNO WHERE F.NUM_DOC_FISCAL > 0 AND A.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND A.OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO END-EXEC. */

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
            /*" -5449- PERFORM R2000_CADASTRAIS_ODS_DB_SELECT_1 */

            R2000_CADASTRAIS_ODS_DB_SELECT_1();

            /*" -5453- IF SQLCODE EQUAL 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -5455- MOVE 'ODS' TO W-CHAVE-ORIGEM-CADASTRO. */
                _.Move("ODS", AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO);
            }


            /*" -5456- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -5457- DISPLAY 'SISAP01B - ERRO ACESSO BASE ODS' */
                _.Display($"SISAP01B - ERRO ACESSO BASE ODS");

                /*" -5458- DISPLAY 'SINISTRO ........ ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO ........ {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -5459- DISPLAY 'OCORRHIST ....... ' SINISHIS-OCORR-HISTORICO */
                _.Display($"OCORRHIST ....... {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}");

                /*" -5461- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -5462- IF OD001-IND-PESSOA EQUAL 'F' */

            if (OD001.DCLOD_PESSOA.OD001_IND_PESSOA == "F")
            {

                /*" -5463- MOVE 'PF' TO W-CHAVE-TIPO-PESSOA-PF-PJ */
                _.Move("PF", AREA_DE_WORK.W_CHAVE_TIPO_PESSOA_PF_PJ);

                /*" -5464- ELSE */
            }
            else
            {


                /*" -5465- IF OD001-IND-PESSOA EQUAL 'J' */

                if (OD001.DCLOD_PESSOA.OD001_IND_PESSOA == "J")
                {

                    /*" -5466- MOVE 'PJ' TO W-CHAVE-TIPO-PESSOA-PF-PJ */
                    _.Move("PJ", AREA_DE_WORK.W_CHAVE_TIPO_PESSOA_PF_PJ);

                    /*" -5467- ELSE */
                }
                else
                {


                    /*" -5469- MOVE '??' TO W-CHAVE-TIPO-PESSOA-PF-PJ. */
                    _.Move("??", AREA_DE_WORK.W_CHAVE_TIPO_PESSOA_PF_PJ);
                }

            }


            /*" -5470- MOVE W-NUMERO-CPF-BASE TO W-NUM-CPF-ALFA. */
            _.Move(W_NUMERO_CPF_BASE, W_NUM_CPF_ALFA);

            /*" -5472- MOVE W-NUMERO-CNPJ-BASE TO W-NUM-CNPJ-ALFA. */
            _.Move(W_NUMERO_CNPJ_BASE, W_NUM_CNPJ_ALFA);

            /*" -5480- IF OD007-COD-CEP(1:1) NOT NUMERIC OR OD007-COD-CEP(2:1) NOT NUMERIC OR OD007-COD-CEP(3:1) NOT NUMERIC OR OD007-COD-CEP(4:1) NOT NUMERIC OR OD007-COD-CEP(5:1) NOT NUMERIC OR OD007-COD-CEP(6:1) NOT NUMERIC OR OD007-COD-CEP(7:1) NOT NUMERIC OR OD007-COD-CEP(8:1) NOT NUMERIC */

            if (!OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_CEP.Substring(1, 1).IsNumeric() || !OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_CEP.Substring(2, 1).IsNumeric() || !OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_CEP.Substring(3, 1).IsNumeric() || !OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_CEP.Substring(4, 1).IsNumeric() || !OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_CEP.Substring(5, 1).IsNumeric() || !OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_CEP.Substring(6, 1).IsNumeric() || !OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_CEP.Substring(7, 1).IsNumeric() || !OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_CEP.Substring(8, 1).IsNumeric())
            {

                /*" -5481- MOVE 99999999 TO OD007-COD-CEP */
                _.Move(99999999, OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_CEP);

                /*" -5482- ELSE */
            }
            else
            {


                /*" -5483- MOVE OD007-COD-CEP TO W-CEP-NUM */
                _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_CEP, W_CEP_NUM);

                /*" -5484- MOVE W-CEP-NUMERICO-PARTE1 TO W-CEP-ALFA-PARTE1 */
                _.Move(W_CEP_NUMERICO.W_CEP_NUMERICO_PARTE1, W_CEP_ALFA.W_CEP_ALFA_PARTE1);

                /*" -5484- MOVE W-CEP-NUMERICO-PARTE2 TO W-CEP-ALFA-PARTE2. */
                _.Move(W_CEP_NUMERICO.W_CEP_NUMERICO_PARTE2, W_CEP_ALFA.W_CEP_ALFA_PARTE2);
            }


        }

        [StopWatch]
        /*" R2000-CADASTRAIS-ODS-DB-SELECT-1 */
        public void R2000_CADASTRAIS_ODS_DB_SELECT_1()
        {
            /*" -5449- EXEC SQL SELECT H.NUM_APOL_SINISTRO AS 'NUM SINISTRO' , H.OCORR_HISTORICO AS 'OCORRHIST' , H.COD_OPERACAO AS 'OPERACAO' , OPE.FUNCAO_OPERACAO AS 'FUNCAO OPERACAO' , SUBSTR(OPE.DES_OPERACAO,1,30) AS 'NOME OPERACAO' , LEGPES.NUM_OCORR_MOVTO AS 'NUM_OCORR_MOVTO' , LEGPES.NUM_PESSOA AS 'NUM. PESSOA' , PE.IND_PESSOA AS 'TIPO PESSOA' , DIGITS(DECIMAL(PF.NUM_CPF,9,0)) ||DIGITS(DECIMAL(PF.NUM_DV_CPF,2,0)) AS 'CPF DO FAVORECIDO' , SUBSTR(PF.NOM_PESSOA,1,100) AS 'NOME_FAVORECIDO' , 0 AS 'INSCRICAO MUNICIPAL' , 0 AS 'INSCRICAO ESTADUAL' , PF.NUM_INSC_SOCIAL AS 'INSCRICAO SOCIAL' , PF.NUM_DV_INSC_SOCIAL AS 'DV INSCRICAO SOCIAL' , DIGITS(DECIMAL(PJ.NUM_CNPJ,8,0)) ||DIGITS(DECIMAL(PJ.NUM_FILIAL,4,0)) ||DIGITS(DECIMAL(PJ.NUM_DV_CNPJ,2,0)) AS 'CNPJ DO FAVORECIDO' , SUBSTR(PJ.NOM_RAZAO_SOCIAL,1,100) AS 'RAZAO SOCIAL' , PJ.NUM_INSC_MUNICIPAL AS 'INSCRICAO MUNICIPAL' , PJ.NUM_INSC_ESTADUAL AS 'INSCRICAO ESTADUAL' , 0 AS 'INSCRICAO SOCIAL' , 0 AS 'DV INSCRICAO SOCIAL' , PESEND.NOM_LOGRADOURO AS 'LOGRADOURO' , PESEND.DES_NUM_IMOVEL AS 'NUM IMOVEL' , PESEND.DES_COMPL_ENDERECO AS 'COMPLEMENTO' , PESEND.NOM_BAIRRO AS 'BAIRRO' , PESEND.NOM_CIDADE AS 'CIDADE' , PESEND.COD_CEP AS 'CEP' , PESEND.COD_UF AS 'UF' , H.NOME_FAVORECIDO AS 'NOME_FAVORECIDO_HIST' , OPE.IND_TIPO_FUNCAO AS 'TIPO FUNCAO OPERACAO' INTO :SINISHIS-NUM-APOL-SINISTRO, :SINISHIS-OCORR-HISTORICO, :SINISHIS-COD-OPERACAO, :GEOPERAC-FUNCAO-OPERACAO, :GEOPERAC-DES-OPERACAO, :GE368-NUM-OCORR-MOVTO, :GE368-NUM-PESSOA, :OD001-IND-PESSOA, :W-NUMERO-CPF-BASE:NULL-NUM-CPF, :OD002-NOM-PESSOA:NULL-NOM-PESSOA, :W-PF-INSC-PREFEITURA:NULL-PF-INSC-PREFEITURA, :W-PF-INSC-ESTADUAL:NULL-PF-INSC-ESTADUAL, :W-PF-NUM-INSC-SOCIAL:NULL-PF-NUM-INSC-SOCIAL, :W-PF-NUM-DV-INSC-SOCIAL:NULL-PF-NUM-DV-INSC-SOCIAL, :W-NUMERO-CNPJ-BASE:NULL-NUM-CNPJ, :OD003-NOM-RAZAO-SOCIAL:NULL-NOM-RAZAO-SOCIAL, :W-PJ-INSC-PREFEITURA:NULL-PJ-INSC-PREFEITURA, :W-PJ-INSC-ESTADUAL:NULL-PJ-INSC-ESTADUAL, :W-PJ-NUM-INSC-SOCIAL:NULL-PJ-NUM-INSC-SOCIAL, :W-PJ-NUM-DV-INSC-SOCIAL:NULL-PJ-NUM-DV-INSC-SOCIAL, :OD007-NOM-LOGRADOURO:NULL-NOM-LOGRADOURO, :OD007-DES-NUM-IMOVEL:NULL-DES-NUM-IMOVEL, :OD007-DES-COMPL-ENDERECO:NULL-DES-COMPL-ENDERECO, :OD007-NOM-BAIRRO:NULL-NOM-BAIRRO, :OD007-NOM-CIDADE:NULL-NOM-CIDADE, :OD007-COD-CEP:NULL-COD-CEP, :OD007-COD-UF:NULL-COD-UF, :SINISHIS-NOME-FAVORECIDO, :GEOPERAC-IND-TIPO-FUNCAO FROM SEGUROS.SINISTRO_HISTORICO H, SEGUROS.GE_OPERACAO OPE, SEGUROS.SI_PESS_SINISTRO SIPES, SEGUROS.GE_LEG_PESS_EVENTO LEGPES LEFT JOIN ODS.OD_PESSOA PE ON PE.NUM_PESSOA = LEGPES.NUM_PESSOA LEFT JOIN ODS.OD_PESSOA_FISICA PF ON PF.NUM_PESSOA = LEGPES.NUM_PESSOA LEFT JOIN ODS.OD_PESSOA_JURIDICA PJ ON PJ.NUM_PESSOA = LEGPES.NUM_PESSOA LEFT JOIN ODS.OD_PESSOA_ENDERECO PESEND ON PESEND.NUM_PESSOA = LEGPES.NUM_PESSOA AND PESEND.SEQ_ENDERECO = LEGPES.SEQ_ENTIDADE WHERE SIPES.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND SIPES.OCORR_HISTORICO = H.OCORR_HISTORICO AND SIPES.COD_OPERACAO = H.COD_OPERACAO AND LEGPES.NUM_OCORR_MOVTO = SIPES.NUM_OCORR_MOVTO AND LEGPES.IND_ENTIDADE = 1 AND OPE.IDE_SISTEMA = 'SI' AND OPE.COD_OPERACAO = H.COD_OPERACAO AND H.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND H.OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND H.COD_PREST_SERVICO <> 891733 AND H.NOME_FAVORECIDO <> 'CAIXA SEGURADORA S A' END-EXEC. */

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
            /*" -5496- IF SINISHIS-COD-OPERACAO NOT EQUAL 1070 AND 1071 AND 1072 AND 1073 AND 1074 AND 1170 AND 1171 AND 1172 AND 1173 AND 1174 AND 1030 AND 1040 AND 4000 */

            if (!SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.In("1070", "1071", "1072", "1073", "1074", "1170", "1171", "1172", "1173", "1174", "1030", "1040", "4000"))
            {

                /*" -5500- GO TO R2010-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2010_EXIT*/ //GOTO
                return;
            }


            /*" -5510- PERFORM R2010_CADASTRAIS_LOTERICO_DB_SELECT_1 */

            R2010_CADASTRAIS_LOTERICO_DB_SELECT_1();

            /*" -5513- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -5515- GO TO R2010-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2010_EXIT*/ //GOTO
                return;
            }


            /*" -5516- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -5517- DISPLAY 'SISAP01B - ERRO ACESSO SINI_LOTERICO01 - 1' */
                _.Display($"SISAP01B - ERRO ACESSO SINI_LOTERICO01 - 1");

                /*" -5521- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -5558- PERFORM R2010_CADASTRAIS_LOTERICO_DB_SELECT_2 */

            R2010_CADASTRAIS_LOTERICO_DB_SELECT_2();

            /*" -5561- IF SQLCODE EQUAL 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -5562- MOVE FORNECED-CGCCPF TO W-NUM-CPF-NUM */
                _.Move(FORNECED.DCLFORNECEDORES.FORNECED_CGCCPF, W_NUM_CPF_NUM);

                /*" -5563- MOVE FORNECED-CGCCPF TO W-NUM-CNPJ-NUM */
                _.Move(FORNECED.DCLFORNECEDORES.FORNECED_CGCCPF, W_NUM_CNPJ_NUM);

                /*" -5565- MOVE 'FORNECEDOR OU LOTERICO' TO W-CHAVE-ORIGEM-CADASTRO. */
                _.Move("FORNECEDOR OU LOTERICO", AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO);
            }


            /*" -5566- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -5567- DISPLAY 'SISAP01B - ERRO ACESSO SINI_LOTERICO01 - 2' */
                _.Display($"SISAP01B - ERRO ACESSO SINI_LOTERICO01 - 2");

                /*" -5569- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -5570- IF FORNECED-TIPO-PESSOA EQUAL 'F' */

            if (FORNECED.DCLFORNECEDORES.FORNECED_TIPO_PESSOA == "F")
            {

                /*" -5571- MOVE 'PF' TO W-CHAVE-TIPO-PESSOA-PF-PJ */
                _.Move("PF", AREA_DE_WORK.W_CHAVE_TIPO_PESSOA_PF_PJ);

                /*" -5572- ELSE */
            }
            else
            {


                /*" -5573- IF FORNECED-TIPO-PESSOA EQUAL 'J' */

                if (FORNECED.DCLFORNECEDORES.FORNECED_TIPO_PESSOA == "J")
                {

                    /*" -5574- MOVE 'PJ' TO W-CHAVE-TIPO-PESSOA-PF-PJ */
                    _.Move("PJ", AREA_DE_WORK.W_CHAVE_TIPO_PESSOA_PF_PJ);

                    /*" -5575- ELSE */
                }
                else
                {


                    /*" -5577- MOVE '??' TO W-CHAVE-TIPO-PESSOA-PF-PJ. */
                    _.Move("??", AREA_DE_WORK.W_CHAVE_TIPO_PESSOA_PF_PJ);
                }

            }


            /*" -5578- MOVE FORNECED-CEP TO W-CEP-NUM . */
            _.Move(FORNECED.DCLFORNECEDORES.FORNECED_CEP, W_CEP_NUM);

            /*" -5579- MOVE W-CEP-NUMERICO-PARTE1 TO W-CEP-ALFA-PARTE1 . */
            _.Move(W_CEP_NUMERICO.W_CEP_NUMERICO_PARTE1, W_CEP_ALFA.W_CEP_ALFA_PARTE1);

            /*" -5579- MOVE W-CEP-NUMERICO-PARTE2 TO W-CEP-ALFA-PARTE2 . */
            _.Move(W_CEP_NUMERICO.W_CEP_NUMERICO_PARTE2, W_CEP_ALFA.W_CEP_ALFA_PARTE2);

        }

        [StopWatch]
        /*" R2010-CADASTRAIS-LOTERICO-DB-SELECT-1 */
        public void R2010_CADASTRAIS_LOTERICO_DB_SELECT_1()
        {
            /*" -5510- EXEC SQL SELECT X.NUM_APOL_SINISTRO INTO :SINILT01-NUM-APOL-SINISTRO FROM SEGUROS.SINI_LOTERICO01 X, SEGUROS.SINISTRO_HISTORICO H WHERE H.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND H.OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND H.COD_OPERACAO = :SINISHIS-COD-OPERACAO AND H.COD_PREST_SERVICO = 0 AND X.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO END-EXEC. */

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
            /*" -5558- EXEC SQL SELECT CLI.NOME_RAZAO , CLI.TIPO_PESSOA , CASE CLI.TIPO_PESSOA WHEN 'F' THEN 'PESSOA FISICA  ' WHEN 'J' THEN 'PESSOA JURIDICA' END AS 'TIPO DE PESSOA' , CLI.CGCCPF AS 'CPF / CNPJ DO FAVORECIDO' , LOT.ENDERECO , LOT.BAIRRO , LOT.CIDADE , LOT.CEP , LOT.SIGLA_UF INTO :FORNECED-NOME-FORNECEDOR, :FORNECED-TIPO-PESSOA, :W-NOME-TIPO-PESSOA, :FORNECED-CGCCPF, :FORNECED-ENDERECO, :FORNECED-BAIRRO, :FORNECED-CIDADE, :FORNECED-CEP, :FORNECED-SIGLA-UF FROM SEGUROS.SINI_LOTERICO01 X, SEGUROS.LOTERICO01 LOT, SEGUROS.CLIENTES CLI WHERE X.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND LOT.COD_CLIENTE = X.COD_CLIENTE AND CLI.COD_CLIENTE = X.COD_CLIENTE AND LOT.TIMESTAMP = (SELECT MAX(ZZ.TIMESTAMP) FROM SEGUROS.SINI_LOTERICO01 XX, SEGUROS.LOTERICO01 ZZ WHERE XX.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND ZZ.COD_CLIENTE = XX.COD_CLIENTE ) END-EXEC. */

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
            /*" -5660- PERFORM R2020_CADASTRAIS_FORNECED_DB_SELECT_1 */

            R2020_CADASTRAIS_FORNECED_DB_SELECT_1();

            /*" -5663- IF SQLCODE EQUAL 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -5664- MOVE FORNECED-CGCCPF TO W-NUM-CPF-NUM */
                _.Move(FORNECED.DCLFORNECEDORES.FORNECED_CGCCPF, W_NUM_CPF_NUM);

                /*" -5665- MOVE FORNECED-CGCCPF TO W-NUM-CNPJ-NUM */
                _.Move(FORNECED.DCLFORNECEDORES.FORNECED_CGCCPF, W_NUM_CNPJ_NUM);

                /*" -5667- MOVE 'FORNECEDOR OU LOTERICO' TO W-CHAVE-ORIGEM-CADASTRO. */
                _.Move("FORNECEDOR OU LOTERICO", AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO);
            }


            /*" -5668- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -5669- DISPLAY 'SISAP01B - ERRO ACESSO FORNECEDORES' */
                _.Display($"SISAP01B - ERRO ACESSO FORNECEDORES");

                /*" -5671- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -5672- IF FORNECED-TIPO-PESSOA EQUAL 'F' */

            if (FORNECED.DCLFORNECEDORES.FORNECED_TIPO_PESSOA == "F")
            {

                /*" -5673- MOVE 'PF' TO W-CHAVE-TIPO-PESSOA-PF-PJ */
                _.Move("PF", AREA_DE_WORK.W_CHAVE_TIPO_PESSOA_PF_PJ);

                /*" -5674- ELSE */
            }
            else
            {


                /*" -5675- IF FORNECED-TIPO-PESSOA EQUAL 'J' */

                if (FORNECED.DCLFORNECEDORES.FORNECED_TIPO_PESSOA == "J")
                {

                    /*" -5676- MOVE 'PJ' TO W-CHAVE-TIPO-PESSOA-PF-PJ */
                    _.Move("PJ", AREA_DE_WORK.W_CHAVE_TIPO_PESSOA_PF_PJ);

                    /*" -5677- ELSE */
                }
                else
                {


                    /*" -5679- MOVE '??' TO W-CHAVE-TIPO-PESSOA-PF-PJ. */
                    _.Move("??", AREA_DE_WORK.W_CHAVE_TIPO_PESSOA_PF_PJ);
                }

            }


            /*" -5680- MOVE FORNECED-CEP TO W-CEP-NUM . */
            _.Move(FORNECED.DCLFORNECEDORES.FORNECED_CEP, W_CEP_NUM);

            /*" -5681- MOVE W-CEP-NUMERICO-PARTE1 TO W-CEP-ALFA-PARTE1 . */
            _.Move(W_CEP_NUMERICO.W_CEP_NUMERICO_PARTE1, W_CEP_ALFA.W_CEP_ALFA_PARTE1);

            /*" -5681- MOVE W-CEP-NUMERICO-PARTE2 TO W-CEP-ALFA-PARTE2 . */
            _.Move(W_CEP_NUMERICO.W_CEP_NUMERICO_PARTE2, W_CEP_ALFA.W_CEP_ALFA_PARTE2);

        }

        [StopWatch]
        /*" R2020-CADASTRAIS-FORNECED-DB-SELECT-1 */
        public void R2020_CADASTRAIS_FORNECED_DB_SELECT_1()
        {
            /*" -5660- EXEC SQL SELECT H.NUM_APOL_SINISTRO AS 'NUM SINISTRO' , H.OCORR_HISTORICO AS 'OCORRHIST' , H.COD_OPERACAO AS 'OPERACAO' , OPE.FUNCAO_OPERACAO AS 'FUNCAO OPERACAO' , SUBSTR(OPE.DES_OPERACAO,1,30) AS 'NOME OPERACAO' , F.TIPO_PESSOA AS 'TIPO PESSOA' , CASE F.TIPO_PESSOA WHEN 'F' THEN 'PESSOA FISICA  ' WHEN 'J' THEN 'PESSOA JURIDICA' END AS 'TIPO DE PESSOA' , F.CGCCPF AS 'CPF / CNPJ DO FAVORECIDO' , F.NOME_FORNECEDOR AS 'NOME FORNECEDOR' , F.INSC_PREFEITURA AS 'INSCRICAO MUNICIPAL' , F.INSC_ESTADUAL AS 'INSCRICAO ESTADUAL' , F.OPT_SIMPLES_FED AS 'OPTANTE SIMPLES FERERAL' , F.OPT_SIMPLES_MUN AS 'OPTANTE SIMPLES MUNICIPAL' , F.ENDERECO AS 'LOGRAD. + NUM IMOVEL + COMPL' , F.BAIRRO AS 'BAIRRO' , F.CIDADE AS 'CIDADE' , F.CEP AS 'CEP' , F.SIGLA_UF AS 'UF' , H.NOME_FAVORECIDO AS 'NOME_FAVORECIDO_HIST' , OPE.IND_TIPO_FUNCAO AS 'TIPO FUNCAO OPERACAO' INTO :SINISHIS-NUM-APOL-SINISTRO, :SINISHIS-OCORR-HISTORICO, :SINISHIS-COD-OPERACAO, :GEOPERAC-FUNCAO-OPERACAO, :GEOPERAC-DES-OPERACAO, :FORNECED-TIPO-PESSOA, :W-NOME-TIPO-PESSOA, :FORNECED-CGCCPF, :FORNECED-NOME-FORNECEDOR, :FORNECED-INSC-PREFEITURA, :FORNECED-INSC-ESTADUAL, :FORNECED-OPT-SIMPLES-FED, :FORNECED-OPT-SIMPLES-MUN, :FORNECED-ENDERECO, :FORNECED-BAIRRO, :FORNECED-CIDADE, :FORNECED-CEP, :FORNECED-SIGLA-UF, :SINISHIS-NOME-FAVORECIDO, :GEOPERAC-IND-TIPO-FUNCAO FROM SEGUROS.SINISTRO_HISTORICO H, SEGUROS.GE_OPERACAO OPE, SEGUROS.FORNECEDORES F WHERE NOT EXISTS (SELECT 1 FROM SEGUROS.SI_PESS_SINISTRO SIPES WHERE SIPES.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND SIPES.OCORR_HISTORICO = H.OCORR_HISTORICO AND SIPES.COD_OPERACAO = H.COD_OPERACAO) AND OPE.IDE_SISTEMA = 'SI' AND OPE.COD_OPERACAO = H.COD_OPERACAO AND H.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND H.OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND H.COD_OPERACAO = :SINISHIS-COD-OPERACAO AND H.COD_PREST_SERVICO <> 0 AND F.COD_FORNECEDOR = H.COD_PREST_SERVICO AND F.CGCCPF <> 80000000000 END-EXEC. */

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
            /*" -5689- INITIALIZE DCLFI-PAGA-DOC-FISCAL */
            _.Initialize(
                FIPADOFI.DCLFI_PAGA_DOC_FISCAL
            );

            /*" -5693- MOVE 0 TO NULL-NUM-DOC-FISCAL NULL-SERIE-DOC-FISCAL NULL-DATA-EMISSAO-DOC */
            _.Move(0, NULL_NUM_DOC_FISCAL, NULL_SERIE_DOC_FISCAL, NULL_DATA_EMISSAO_DOC);

            /*" -5709- PERFORM R2030_PEGA_NOTA_FISCAL_DB_SELECT_1 */

            R2030_PEGA_NOTA_FISCAL_DB_SELECT_1();

            /*" -5712- IF SQLCODE EQUAL 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -5713- IF W-CHAVE-EH-PRESTADOR EQUAL 'SIM' */

                if (AREA_DE_WORK.W_CHAVE_EH_PRESTADOR == "SIM")
                {

                    /*" -5714- MOVE 'SIM' TO W-CHAVE-ACHOU-NOTA-FISCAL */
                    _.Move("SIM", AREA_DE_WORK.W_CHAVE_ACHOU_NOTA_FISCAL);

                    /*" -5715- ELSE */
                }
                else
                {


                    /*" -5716- MOVE 'NAO' TO W-CHAVE-ACHOU-NOTA-FISCAL */
                    _.Move("NAO", AREA_DE_WORK.W_CHAVE_ACHOU_NOTA_FISCAL);

                    /*" -5717- END-IF */
                }


                /*" -5719- END-IF */
            }


            /*" -5720- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -5721- DISPLAY 'SISAP01B - ERRO ACESSO FI_PAGA_DOC_FISCAL' */
                _.Display($"SISAP01B - ERRO ACESSO FI_PAGA_DOC_FISCAL");

                /*" -5722- DISPLAY 'NUM_APOL_SINISTRO= ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"NUM_APOL_SINISTRO= {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -5723- DISPLAY 'OCORR_HISTORICO  = ' SINISHIS-OCORR-HISTORICO */
                _.Display($"OCORR_HISTORICO  = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}");

                /*" -5724- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -5725- END-IF */
            }


            /*" -5725- . */

        }

        [StopWatch]
        /*" R2030-PEGA-NOTA-FISCAL-DB-SELECT-1 */
        public void R2030_PEGA_NOTA_FISCAL_DB_SELECT_1()
        {
            /*" -5709- EXEC SQL SELECT NUM_DOC_FISCAL ,SERIE_DOC_FISCAL ,DATA_EMISSAO_DOC INTO :FIPADOFI-NUM-DOC-FISCAL:NULL-NUM-DOC-FISCAL ,:FIPADOFI-SERIE-DOC-FISCAL:NULL-SERIE-DOC-FISCAL ,:FIPADOFI-DATA-EMISSAO-DOC:NULL-DATA-EMISSAO-DOC FROM SEGUROS.SI_PAGA_DOC_FISCAL X ,SEGUROS.FI_PAGA_DOC_FISCAL Y WHERE X.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND X.OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND X.COD_OPERACAO = :SINISHIS-COD-OPERACAO AND Y.NUM_DOCF_INTERNO = X.NUM_DOCF_INTERNO END-EXEC. */

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
            /*" -5743- PERFORM R2040_PEGA_SERVICO_DB_SELECT_1 */

            R2040_PEGA_SERVICO_DB_SELECT_1();

            /*" -5746- IF SQLCODE EQUAL 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -5747- IF W-CHAVE-EH-PRESTADOR EQUAL 'SIM' */

                if (AREA_DE_WORK.W_CHAVE_EH_PRESTADOR == "SIM")
                {

                    /*" -5748- MOVE 'SIM' TO W-CHAVE-ACHOU-FORNECEDOR */
                    _.Move("SIM", AREA_DE_WORK.W_CHAVE_ACHOU_FORNECEDOR);

                    /*" -5749- ELSE */
                }
                else
                {


                    /*" -5751- MOVE 'NAO' TO W-CHAVE-ACHOU-FORNECEDOR. */
                    _.Move("NAO", AREA_DE_WORK.W_CHAVE_ACHOU_FORNECEDOR);
                }

            }


            /*" -5752- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -5753- DISPLAY 'SISAP01B - ERRO ACESSO FORNECEDORES (12)' */
                _.Display($"SISAP01B - ERRO ACESSO FORNECEDORES (12)");

                /*" -5753- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2040-PEGA-SERVICO-DB-SELECT-1 */
        public void R2040_PEGA_SERVICO_DB_SELECT_1()
        {
            /*" -5743- EXEC SQL SELECT CEP, COD_SERVICO_ISS INTO :FORNECED-CEP, :FORNECED-COD-SERVICO-ISS FROM SEGUROS.SINISTRO_HISTORICO H, SEGUROS.FORNECEDORES F WHERE H.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND H.OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND H.COD_OPERACAO = :SINISHIS-COD-OPERACAO AND F.COD_FORNECEDOR = H.COD_PREST_SERVICO END-EXEC. */

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
            /*" -5761- MOVE 0 TO CEPFXFIL-FONTE . */
            _.Move(0, CEPFXFIL.DCLCEPFAIXAFILIAL.CEPFXFIL_FONTE);

            /*" -5770- PERFORM R2050_FONTE_RECOLHE_IMPOSTO_DB_SELECT_1 */

            R2050_FONTE_RECOLHE_IMPOSTO_DB_SELECT_1();

            /*" -5774- MOVE 'NAO' TO W-CHAVE-ACHOU-FONTE-IMPOSTO . */
            _.Move("NAO", AREA_DE_WORK.W_CHAVE_ACHOU_FONTE_IMPOSTO);

            /*" -5775- IF SQLCODE EQUAL 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -5776- IF CEPFXFIL-FONTE NOT EQUAL 0 */

                if (CEPFXFIL.DCLCEPFAIXAFILIAL.CEPFXFIL_FONTE != 0)
                {

                    /*" -5777- IF W-CHAVE-EH-PRESTADOR EQUAL 'SIM' */

                    if (AREA_DE_WORK.W_CHAVE_EH_PRESTADOR == "SIM")
                    {

                        /*" -5779- MOVE 'SIM' TO W-CHAVE-ACHOU-FONTE-IMPOSTO. */
                        _.Move("SIM", AREA_DE_WORK.W_CHAVE_ACHOU_FONTE_IMPOSTO);
                    }

                }

            }


            /*" -5780- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -5781- DISPLAY 'SISAP01B - ERRO ACESSO CEPFAIXAFILIAL' */
                _.Display($"SISAP01B - ERRO ACESSO CEPFAIXAFILIAL");

                /*" -5782- DISPLAY 'CEP PESQUISADO = ' FORNECED-CEP */
                _.Display($"CEP PESQUISADO = {FORNECED.DCLFORNECEDORES.FORNECED_CEP}");

                /*" -5783- MOVE PRODUTO-COD-EMPRESA TO WS-SMALLINT(01) */
                _.Move(PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA, AREA_DE_WORK.WS_SMALLINT[01]);

                /*" -5784- DISPLAY 'COD EMPRESA    = ' WS-SMALLINT(01) */
                _.Display($"COD EMPRESA    = {AREA_DE_WORK.WS_SMALLINT[1]}");

                /*" -5784- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2050-FONTE-RECOLHE-IMPOSTO-DB-SELECT-1 */
        public void R2050_FONTE_RECOLHE_IMPOSTO_DB_SELECT_1()
        {
            /*" -5770- EXEC SQL SELECT VALUE(MIN(FONTE),0) INTO :CEPFXFIL-FONTE FROM SEGUROS.CEPFAIXAFILIAL A WHERE A.DATA_INI_VIGENCIA <= :SISTEMAS-DATA-MOV-ABERTO AND A.DATA_TER_VIGENCIA = '9999-12-31' AND A.CEP_INICIAL <= :FORNECED-CEP AND A.CEP_FINAL >= :FORNECED-CEP AND A.COD_EMPRESA = :PRODUTO-COD-EMPRESA END-EXEC. */

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
            /*" -5800- IF NULL-NOM-PROGRAMA < 0 */

            if (NULL_NOM_PROGRAMA < 0)
            {

                /*" -5810- GO TO R2060-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2060_EXIT*/ //GOTO
                return;
            }


            /*" -5811- IF SINISHIS-NOM-PROGRAMA EQUAL 'FI0095B' OR 'SI5070B' */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOM_PROGRAMA.In("FI0095B", "SI5070B"))
            {

                /*" -5822- GO TO R2060-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2060_EXIT*/ //GOTO
                return;
            }


            /*" -5823- IF SINISHIS-NOM-PROGRAMA EQUAL 'SI5066B' */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOM_PROGRAMA == "SI5066B")
            {

                /*" -5825- IF W-ATTR-DESTINO EQUAL 'ATTRVAL10-GERAL' */

                if (AREA_DE_WORK.W_ATTR_DESTINO == "ATTRVAL10-GERAL")
                {

                    /*" -5827- MOVE 'SI5066B REPASSE MATC' TO ATTRVAL10-GERAL */
                    _.Move("SI5066B REPASSE MATC", W_REGISTRO_SIAS_GERAL.ATTRVAL10_GERAL);

                    /*" -5828- END-IF */
                }


                /*" -5830- IF W-ATTR-DESTINO EQUAL 'ATTRVAL13-GERAL' */

                if (AREA_DE_WORK.W_ATTR_DESTINO == "ATTRVAL13-GERAL")
                {

                    /*" -5832- MOVE 'SI5066B REPASSE MATC' TO ATTRVAL13-GERAL */
                    _.Move("SI5066B REPASSE MATC", W_REGISTRO_SIAS_GERAL.ATTRVAL13_GERAL);

                    /*" -5833- END-IF */
                }


                /*" -5848- GO TO R2060-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2060_EXIT*/ //GOTO
                return;
            }


            /*" -5849- IF SINISHIS-NOM-PROGRAMA EQUAL 'FI0005B' */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOM_PROGRAMA == "FI0005B")
            {

                /*" -5851- IF W-ATTR-DESTINO EQUAL 'ATTRVAL10-GERAL' */

                if (AREA_DE_WORK.W_ATTR_DESTINO == "ATTRVAL10-GERAL")
                {

                    /*" -5853- MOVE 'FI0005B IND HAB CRED' TO ATTRVAL10-GERAL */
                    _.Move("FI0005B IND HAB CRED", W_REGISTRO_SIAS_GERAL.ATTRVAL10_GERAL);

                    /*" -5854- END-IF */
                }


                /*" -5856- IF W-ATTR-DESTINO EQUAL 'ATTRVAL13-GERAL' */

                if (AREA_DE_WORK.W_ATTR_DESTINO == "ATTRVAL13-GERAL")
                {

                    /*" -5858- MOVE 'FI0005B IND HAB CRED' TO ATTRVAL13-GERAL */
                    _.Move("FI0005B IND HAB CRED", W_REGISTRO_SIAS_GERAL.ATTRVAL13_GERAL);

                    /*" -5859- END-IF */
                }


                /*" -5869- GO TO R2060-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2060_EXIT*/ //GOTO
                return;
            }


            /*" -5870- IF SINISHIS-NOM-PROGRAMA EQUAL 'SI5022B' */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOM_PROGRAMA == "SI5022B")
            {

                /*" -5872- IF W-ATTR-DESTINO EQUAL 'ATTRVAL10-GERAL' */

                if (AREA_DE_WORK.W_ATTR_DESTINO == "ATTRVAL10-GERAL")
                {

                    /*" -5874- MOVE 'SI5022B IND HAB CC L' TO ATTRVAL10-GERAL */
                    _.Move("SI5022B IND HAB CC L", W_REGISTRO_SIAS_GERAL.ATTRVAL10_GERAL);

                    /*" -5875- END-IF */
                }


                /*" -5877- IF W-ATTR-DESTINO EQUAL 'ATTRVAL13-GERAL' */

                if (AREA_DE_WORK.W_ATTR_DESTINO == "ATTRVAL13-GERAL")
                {

                    /*" -5879- MOVE 'SI5022B IND HAB CC L' TO ATTRVAL13-GERAL */
                    _.Move("SI5022B IND HAB CC L", W_REGISTRO_SIAS_GERAL.ATTRVAL13_GERAL);

                    /*" -5880- END-IF */
                }


                /*" -5889- GO TO R2060-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2060_EXIT*/ //GOTO
                return;
            }


            /*" -5890- IF SINISHIS-NOM-PROGRAMA EQUAL 'SI5033B' */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOM_PROGRAMA == "SI5033B")
            {

                /*" -5892- IF W-ATTR-DESTINO EQUAL 'ATTRVAL10-GERAL' */

                if (AREA_DE_WORK.W_ATTR_DESTINO == "ATTRVAL10-GERAL")
                {

                    /*" -5894- MOVE 'SI5033B REPASSE CRED' TO ATTRVAL10-GERAL */
                    _.Move("SI5033B REPASSE CRED", W_REGISTRO_SIAS_GERAL.ATTRVAL10_GERAL);

                    /*" -5895- END-IF */
                }


                /*" -5897- IF W-ATTR-DESTINO EQUAL 'ATTRVAL13-GERAL' */

                if (AREA_DE_WORK.W_ATTR_DESTINO == "ATTRVAL13-GERAL")
                {

                    /*" -5899- MOVE 'SI5033B REPASSE CRED' TO ATTRVAL13-GERAL */
                    _.Move("SI5033B REPASSE CRED", W_REGISTRO_SIAS_GERAL.ATTRVAL13_GERAL);

                    /*" -5900- END-IF */
                }


                /*" -5909- GO TO R2060-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2060_EXIT*/ //GOTO
                return;
            }


            /*" -5910- IF SINISHIS-NOM-PROGRAMA EQUAL 'SI5038B' */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOM_PROGRAMA == "SI5038B")
            {

                /*" -5912- IF W-ATTR-DESTINO EQUAL 'ATTRVAL10-GERAL' */

                if (AREA_DE_WORK.W_ATTR_DESTINO == "ATTRVAL10-GERAL")
                {

                    /*" -5914- MOVE 'SI5038B INDHAB CXCON' TO ATTRVAL10-GERAL */
                    _.Move("SI5038B INDHAB CXCON", W_REGISTRO_SIAS_GERAL.ATTRVAL10_GERAL);

                    /*" -5915- END-IF */
                }


                /*" -5917- IF W-ATTR-DESTINO EQUAL 'ATTRVAL13-GERAL' */

                if (AREA_DE_WORK.W_ATTR_DESTINO == "ATTRVAL13-GERAL")
                {

                    /*" -5919- MOVE 'SI5038B INDHAB CXCON' TO ATTRVAL13-GERAL */
                    _.Move("SI5038B INDHAB CXCON", W_REGISTRO_SIAS_GERAL.ATTRVAL13_GERAL);

                    /*" -5920- END-IF */
                }


                /*" -5929- GO TO R2060-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2060_EXIT*/ //GOTO
                return;
            }


            /*" -5930- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'JBIND' */

            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "JBIND")
            {

                /*" -5931- PERFORM R7777-ACESSA-TIMESTAMP THRU R7777-EXIT */

                R7777_ACESSA_TIMESTAMP(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R7777_EXIT*/


                /*" -5932- MOVE 'JURID IND  ' TO W-AGRUPADOR-LEGENDA */
                _.Move("JURID IND  ", AREA_DE_WORK.W_AGRUPADOR_1.W_AGRUPADOR_LEGENDA);

                /*" -5933- IF W-ATTR-DESTINO EQUAL 'ATTRVAL10-GERAL' */

                if (AREA_DE_WORK.W_ATTR_DESTINO == "ATTRVAL10-GERAL")
                {

                    /*" -5934- MOVE W-AGRUPADOR-1 TO ATTRVAL10-GERAL */
                    _.Move(AREA_DE_WORK.W_AGRUPADOR_1, W_REGISTRO_SIAS_GERAL.ATTRVAL10_GERAL);

                    /*" -5935- END-IF */
                }


                /*" -5936- IF W-ATTR-DESTINO EQUAL 'ATTRVAL13-GERAL' */

                if (AREA_DE_WORK.W_ATTR_DESTINO == "ATTRVAL13-GERAL")
                {

                    /*" -5937- MOVE W-AGRUPADOR-1 TO ATTRVAL13-GERAL */
                    _.Move(AREA_DE_WORK.W_AGRUPADOR_1, W_REGISTRO_SIAS_GERAL.ATTRVAL13_GERAL);

                    /*" -5938- END-IF */
                }


                /*" -5942- GO TO R2060-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2060_EXIT*/ //GOTO
                return;
            }


            /*" -5943- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'JBDP' */

            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "JBDP")
            {

                /*" -5944- IF SINISHIS-COD-OPERACAO EQUAL 8111 */

                if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO == 8111)
                {

                    /*" -5945- PERFORM R7777-ACESSA-TIMESTAMP THRU R7777-EXIT */

                    R7777_ACESSA_TIMESTAMP(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R7777_EXIT*/


                    /*" -5946- MOVE 'JUR TUTELA ' TO W-AGRUPADOR-LEGENDA */
                    _.Move("JUR TUTELA ", AREA_DE_WORK.W_AGRUPADOR_1.W_AGRUPADOR_LEGENDA);

                    /*" -5947- IF W-ATTR-DESTINO EQUAL 'ATTRVAL10-GERAL' */

                    if (AREA_DE_WORK.W_ATTR_DESTINO == "ATTRVAL10-GERAL")
                    {

                        /*" -5948- MOVE W-AGRUPADOR-1 TO ATTRVAL10-GERAL */
                        _.Move(AREA_DE_WORK.W_AGRUPADOR_1, W_REGISTRO_SIAS_GERAL.ATTRVAL10_GERAL);

                        /*" -5949- END-IF */
                    }


                    /*" -5950- IF W-ATTR-DESTINO EQUAL 'ATTRVAL13-GERAL' */

                    if (AREA_DE_WORK.W_ATTR_DESTINO == "ATTRVAL13-GERAL")
                    {

                        /*" -5951- MOVE W-AGRUPADOR-1 TO ATTRVAL13-GERAL */
                        _.Move(AREA_DE_WORK.W_AGRUPADOR_1, W_REGISTRO_SIAS_GERAL.ATTRVAL13_GERAL);

                        /*" -5952- END-IF */
                    }


                    /*" -5953- GO TO R2060-EXIT */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2060_EXIT*/ //GOTO
                    return;

                    /*" -5954- ELSE */
                }
                else
                {


                    /*" -5955- PERFORM R7777-ACESSA-TIMESTAMP THRU R7777-EXIT */

                    R7777_ACESSA_TIMESTAMP(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R7777_EXIT*/


                    /*" -5956- MOVE 'JUR DEPOSI ' TO W-AGRUPADOR-LEGENDA */
                    _.Move("JUR DEPOSI ", AREA_DE_WORK.W_AGRUPADOR_1.W_AGRUPADOR_LEGENDA);

                    /*" -5957- IF W-ATTR-DESTINO EQUAL 'ATTRVAL10-GERAL' */

                    if (AREA_DE_WORK.W_ATTR_DESTINO == "ATTRVAL10-GERAL")
                    {

                        /*" -5958- MOVE W-AGRUPADOR-1 TO ATTRVAL10-GERAL */
                        _.Move(AREA_DE_WORK.W_AGRUPADOR_1, W_REGISTRO_SIAS_GERAL.ATTRVAL10_GERAL);

                        /*" -5959- END-IF */
                    }


                    /*" -5960- IF W-ATTR-DESTINO EQUAL 'ATTRVAL13-GERAL' */

                    if (AREA_DE_WORK.W_ATTR_DESTINO == "ATTRVAL13-GERAL")
                    {

                        /*" -5961- MOVE W-AGRUPADOR-1 TO ATTRVAL13-GERAL */
                        _.Move(AREA_DE_WORK.W_AGRUPADOR_1, W_REGISTRO_SIAS_GERAL.ATTRVAL13_GERAL);

                        /*" -5962- END-IF */
                    }


                    /*" -5967- GO TO R2060-EXIT. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2060_EXIT*/ //GOTO
                    return;
                }

            }


            /*" -5969- IF GEOPERAC-FUNCAO-OPERACAO EQUAL ( 'IND' OR 'LIB' )AND (SINISMES-RAMO EQUAL 31 OR 53 OR 20) */

            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO.In("IND", "LIB") && (SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO.In("31", "53", "20")))
            {

                /*" -5970- PERFORM R7777-ACESSA-TIMESTAMP THRU R7777-EXIT */

                R7777_ACESSA_TIMESTAMP(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R7777_EXIT*/


                /*" -5971- MOVE 'AUTOMOVEL  ' TO W-AGRUPADOR-LEGENDA */
                _.Move("AUTOMOVEL  ", AREA_DE_WORK.W_AGRUPADOR_1.W_AGRUPADOR_LEGENDA);

                /*" -5972- IF W-ATTR-DESTINO EQUAL 'ATTRVAL10-GERAL' */

                if (AREA_DE_WORK.W_ATTR_DESTINO == "ATTRVAL10-GERAL")
                {

                    /*" -5973- MOVE W-AGRUPADOR-1 TO ATTRVAL10-GERAL */
                    _.Move(AREA_DE_WORK.W_AGRUPADOR_1, W_REGISTRO_SIAS_GERAL.ATTRVAL10_GERAL);

                    /*" -5974- END-IF */
                }


                /*" -5975- IF W-ATTR-DESTINO EQUAL 'ATTRVAL13-GERAL' */

                if (AREA_DE_WORK.W_ATTR_DESTINO == "ATTRVAL13-GERAL")
                {

                    /*" -5976- MOVE W-AGRUPADOR-1 TO ATTRVAL13-GERAL */
                    _.Move(AREA_DE_WORK.W_AGRUPADOR_1, W_REGISTRO_SIAS_GERAL.ATTRVAL13_GERAL);

                    /*" -5977- END-IF */
                }


                /*" -5977- GO TO R2060-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2060_EXIT*/ //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2060_EXIT*/

        [StopWatch]
        /*" R7777-ACESSA-TIMESTAMP */
        private void R7777_ACESSA_TIMESTAMP(bool isPerform = false)
        {
            /*" -5988- PERFORM R7777_ACESSA_TIMESTAMP_DB_SELECT_1 */

            R7777_ACESSA_TIMESTAMP_DB_SELECT_1();

            /*" -5991- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -5992- DISPLAY 'SISAP02B - ERRO NO ACESSO TIMESTAMP - R7777' */
                _.Display($"SISAP02B - ERRO NO ACESSO TIMESTAMP - R7777");

                /*" -5994- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -5995- MOVE HOST-CURRENT-TIMESTAMP(18:9) TO W-AGRUPADOR-MINUTO-SSSSSS. */
            _.Move(HOST_CURRENT_TIMESTAMP.Substring(18, 9), AREA_DE_WORK.W_AGRUPADOR_1.W_AGRUPADOR_MINUTO_SSSSSS);

        }

        [StopWatch]
        /*" R7777-ACESSA-TIMESTAMP-DB-SELECT-1 */
        public void R7777_ACESSA_TIMESTAMP_DB_SELECT_1()
        {
            /*" -5988- EXEC SQL SELECT CURRENT TIMESTAMP INTO :HOST-CURRENT-TIMESTAMP FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'FI' WITH UR END-EXEC. */

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
        /*" R19000-GE0306B-GRAVA-CONTROLES */
        private void R19000_GE0306B_GRAVA_CONTROLES(bool isPerform = false)
        {
            /*" -6005- INITIALIZE REGISTRO-LINKAGE-GE0306B. */
            _.Initialize(
                REGISTRO_LINKAGE_GE0306B
            );

            /*" -6007- MOVE MOVDEBCE-NUM-APOLICE TO LK-GE0306B-NUM-APOLICE . */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE, REGISTRO_LINKAGE_GE0306B.LK_GE0306B_NUM_APOLICE);

            /*" -6009- MOVE MOVDEBCE-NUM-ENDOSSO TO LK-GE0306B-NUM-ENDOSSO . */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO, REGISTRO_LINKAGE_GE0306B.LK_GE0306B_NUM_ENDOSSO);

            /*" -6011- MOVE MOVDEBCE-NUM-PARCELA TO LK-GE0306B-NUM-PARCELA . */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA, REGISTRO_LINKAGE_GE0306B.LK_GE0306B_NUM_PARCELA);

            /*" -6013- MOVE MOVDEBCE-COD-CONVENIO TO LK-GE0306B-COD-CONVENIO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO, REGISTRO_LINKAGE_GE0306B.LK_GE0306B_COD_CONVENIO);

            /*" -6015- MOVE MOVDEBCE-NSAS TO LK-GE0306B-NSAS. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS, REGISTRO_LINKAGE_GE0306B.LK_GE0306B_NSAS);

            /*" -6016- MOVE 1 TO LK-GE0306B-FUNCAO */
            _.Move(1, REGISTRO_LINKAGE_GE0306B.LK_GE0306B_FUNCAO);

            /*" -6017- MOVE W-IDLG-SIAS-SINISTRO TO LK-GE0306B-IDLG */
            _.Move(AREA_DE_WORK.W_IDLG_SIAS_SINISTRO, REGISTRO_LINKAGE_GE0306B.LK_GE0306B_IDLG);

            /*" -6018- MOVE HOST-SI-DATA-MOV-ABERTO TO LK-GE0306B-DATA-MOV-ABERTO */
            _.Move(HOST_SI_DATA_MOV_ABERTO, REGISTRO_LINKAGE_GE0306B.LK_GE0306B_DATA_MOV_ABERTO);

            /*" -6028- MOVE 'SI' TO LK-GE0306B-IDE-SISTEMA */
            _.Move("SI", REGISTRO_LINKAGE_GE0306B.LK_GE0306B_IDE_SISTEMA);

            /*" -6030- MOVE 4 TO LK-GE0306B-NUM-ESTRUTURA */
            _.Move(4, REGISTRO_LINKAGE_GE0306B.LK_GE0306B_NUM_ESTRUTURA);

            /*" -6031- MOVE MOVDEBCE-NUM-APOLICE TO LK-GE0306B-NUM-APOLICE . */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE, REGISTRO_LINKAGE_GE0306B.LK_GE0306B_NUM_APOLICE);

            /*" -6032- MOVE MOVDEBCE-NUM-ENDOSSO TO LK-GE0306B-NUM-ENDOSSO . */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO, REGISTRO_LINKAGE_GE0306B.LK_GE0306B_NUM_ENDOSSO);

            /*" -6033- MOVE MOVDEBCE-NUM-PARCELA TO LK-GE0306B-NUM-PARCELA . */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA, REGISTRO_LINKAGE_GE0306B.LK_GE0306B_NUM_PARCELA);

            /*" -6034- MOVE MOVDEBCE-COD-CONVENIO TO LK-GE0306B-COD-CONVENIO . */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO, REGISTRO_LINKAGE_GE0306B.LK_GE0306B_COD_CONVENIO);

            /*" -6038- MOVE MOVDEBCE-NSAS TO LK-GE0306B-NSAS . */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS, REGISTRO_LINKAGE_GE0306B.LK_GE0306B_NSAS);

            /*" -6044- MOVE LK-SAP-CHR-USO-EMPRESA TO LK-GE0306B-CHR-USO-EMPRESA. */
            _.Move(LK_SAP_CHR_USO_EMPRESA, REGISTRO_LINKAGE_GE0306B.LK_GE0306B_CHR_USO_EMPRESA);

            /*" -6047- PERFORM R19400-VERIFICA-OPERACAO THRU R19400-EXIT. */

            R19400_VERIFICA_OPERACAO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R19400_EXIT*/


            /*" -6049- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'DPAG' OR 'RSDEP' OR 'DSPAG' OR 'JBDES' */

            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO.In("DPAG", "RSDEP", "DSPAG", "JBDES"))
            {

                /*" -6050- PERFORM R19500-MONTA-DESPESAS THRU R19500-EXIT */

                R19500_MONTA_DESPESAS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R19500_EXIT*/


                /*" -6051- ELSE */
            }
            else
            {


                /*" -6052- PERFORM R19100-MONTA-REINF THRU R19100-EXIT */

                R19100_MONTA_REINF(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R19100_EXIT*/


                /*" -6054- END-IF. */
            }


            /*" -6058- MOVE W-REGISTRO-SIAS-GERAL TO LK-GE0306B-REGISTRO . */
            _.Move(W_REGISTRO_SIAS_GERAL, REGISTRO_LINKAGE_GE0306B.LK_GE0306B_REGISTRO);

            /*" -6068- CALL 'GE0306B' USING REGISTRO-LINKAGE-GE0306B. */
            _.Call("GE0306B", REGISTRO_LINKAGE_GE0306B);

            /*" -6069- IF LK-GE0306B-COD-RETORNO NOT EQUAL '0' */

            if (LK_GE0306B_COD_RETORNO != "0")
            {

                /*" -6070- DISPLAY ' ' */
                _.Display($" ");

                /*" -6071- DISPLAY ' ' */
                _.Display($" ");

                /*" -6072- DISPLAY '************************************************' */
                _.Display($"************************************************");

                /*" -6073- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -6074- DISPLAY '*            PROGRAMA - SISAP01B               *' */
                _.Display($"*            PROGRAMA - SISAP01B               *");

                /*" -6075- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -6076- DISPLAY '*   ERRO NA EXECUCAO DO CALL DA GE0306B        *' */
                _.Display($"*   ERRO NA EXECUCAO DO CALL DA GE0306B        *");

                /*" -6077- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -6078- DISPLAY '************************************************' */
                _.Display($"************************************************");

                /*" -6079- DISPLAY ' ' */
                _.Display($" ");

                /*" -6080- DISPLAY '=> LK-GE0306B-MENSAGEM .. ' LK-GE0306B-MENSAGEM */
                _.Display($"=> LK-GE0306B-MENSAGEM .. {LK_GE0306B_MENSAGEM}");

                /*" -6081- DISPLAY ' ' */
                _.Display($" ");

                /*" -6082- MOVE '1' TO LK-SAP-COD-RETORNO */
                _.Move("1", LK_SAP_COD_RETORNO);

                /*" -6083- MOVE LK-GE0306B-MENSAGEM TO LK-SAP-MENSAGEM-RETORNO */
                _.Move(LK_GE0306B_MENSAGEM, LK_SAP_MENSAGEM_RETORNO);

                /*" -6084- GO TO RXXXX-ROTINA-RETORNO */

                RXXXX_ROTINA_RETORNO(); //GOTO
                return;

                /*" -6084- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R19000_EXIT*/

        [StopWatch]
        /*" R19100-MONTA-REINF */
        private void R19100_MONTA_REINF(bool isPerform = false)
        {
            /*" -6093- MOVE CODOPE-GERAL TO WS-COD-EVENTO. */
            _.Move(W_REGISTRO_SIAS_GERAL.CODOPE_GERAL, WS_COD_EVENTO);

            /*" -6094- EVALUATE WS-COD-EVENTO-NUM */
            switch (FILLER_18.WS_COD_EVENTO_NUM.Value.Trim())
            {

                /*" -6095- WHEN '09002' */
                case "09002":

                    /*" -6096- WHEN '09003' */
                    break;
                case "09003":

                /*" -6097- WHEN '09004' */
                case "09004":

                    /*" -6098- WHEN '09006' */
                    break;
                case "09006":

                /*" -6099- WHEN '09007' */
                case "09007":

                    /*" -6100- WHEN '09008' */
                    break;
                case "09008":

                /*" -6101- WHEN '09009' */
                case "09009":

                    /*" -6102- WHEN '09015' */
                    break;
                case "09015":

                /*" -6103- WHEN '09022' */
                case "09022":

                    /*" -6104- WHEN '09025' */
                    break;
                case "09025":

                    /*" -6105- MOVE 'ATR_RJUD' TO ATTR08-GERAL */
                    _.Move("ATR_RJUD", W_REGISTRO_SIAS_GERAL.ATTR08_GERAL);

                    /*" -6106- MOVE ALL 'X' TO ATTRVAL08-GERAL */
                    _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL08_GERAL);

                    /*" -6107- WHEN '09001' */
                    break;
                case "09001":

                /*" -6108- WHEN '09010' */
                case "09010":

                    /*" -6109- WHEN '09014' */
                    break;
                case "09014":

                /*" -6110- WHEN '09017' */
                case "09017":

                    /*" -6111- WHEN '09021' */
                    break;
                case "09021":

                /*" -6112- WHEN '09023' */
                case "09023":

                    /*" -6113- WHEN '09026' */
                    break;
                case "09026":

                /*" -6114- CONTINUE */

                /*" -6115- WHEN '09005' */
                case "09005":

                    /*" -6116- WHEN '09011' */
                    break;
                case "09011":

                /*" -6117- WHEN '09012' */
                case "09012":

                    /*" -6118- WHEN '09013' */
                    break;
                case "09013":

                /*" -6119- WHEN '09024' */
                case "09024":

                    /*" -6120- MOVE 'ATR_CNOI' TO ATTR08-GERAL */
                    _.Move("ATR_CNOI", W_REGISTRO_SIAS_GERAL.ATTR08_GERAL);

                    /*" -6122- IF (SINISLAN-SEQ-INDICATIVO-OBRA EQUAL 9999 OR 0) OR (W-CHAVE-TIPO-PESSOA-PF-PJ EQUAL 'PF' ) */

                    if ((SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_SEQ_INDICATIVO_OBRA.In("9999", "0")) || (AREA_DE_WORK.W_CHAVE_TIPO_PESSOA_PF_PJ == "PF"))
                    {

                        /*" -6123- MOVE ALL 'X' TO ATTRVAL08-GERAL */
                        _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL08_GERAL);

                        /*" -6124- ELSE */
                    }
                    else
                    {


                        /*" -6126- MOVE SINISLAN-SEQ-INDICATIVO-OBRA TO WS-TRATA-TAMANHO-1 */
                        _.Move(SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_SEQ_INDICATIVO_OBRA, AREA_DE_WORK.WS_TRATA_TAMANHO.WS_TRATA_TAMANHO_1);

                        /*" -6127- MOVE WS-TRATA-TAMANHO-1 TO ATTRVAL08-GERAL */
                        _.Move(AREA_DE_WORK.WS_TRATA_TAMANHO.WS_TRATA_TAMANHO_1, W_REGISTRO_SIAS_GERAL.ATTRVAL08_GERAL);

                        /*" -6128- END-IF */
                    }


                    /*" -6130- END-EVALUATE. */
                    break;
            }


            /*" -6131- EVALUATE WS-COD-EVENTO-NUM */
            switch (FILLER_18.WS_COD_EVENTO_NUM.Value.Trim())
            {

                /*" -6132- WHEN '09002' */
                case "09002":

                    /*" -6133- WHEN '09006' */
                    break;
                case "09006":

                /*" -6134- WHEN '09007' */
                case "09007":

                    /*" -6135- WHEN '09009' */
                    break;
                case "09009":

                /*" -6136- WHEN '09022' */
                case "09022":

                    /*" -6137- CONTINUE */

                    /*" -6138- WHEN '09005' */
                    break;
                case "09005":

                /*" -6139- WHEN '09011' */
                case "09011":

                    /*" -6140- WHEN '09012' */
                    break;
                case "09012":

                /*" -6141- WHEN '09013' */
                case "09013":

                    /*" -6142- WHEN '09024' */
                    break;
                case "09024":

                    /*" -6143- MOVE 'ATR_CNOC' TO ATTR09-GERAL */
                    _.Move("ATR_CNOC", W_REGISTRO_SIAS_GERAL.ATTR09_GERAL);

                    /*" -6144- IF SINISLAN-SEQ-INDICATIVO-OBRA EQUAL ZEROS */

                    if (SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_SEQ_INDICATIVO_OBRA == 00)
                    {

                        /*" -6145- MOVE ALL 'X' TO ATTRVAL09-GERAL */
                        _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL09_GERAL);

                        /*" -6146- ELSE */
                    }
                    else
                    {


                        /*" -6148- MOVE SINISLAN-COD-NACIONAL-OBRA TO WS-TRATA-TAMANHO-17 */
                        _.Move(SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_COD_NACIONAL_OBRA, AREA_DE_WORK.WS_TRATA_TAMANHO.WS_TRATA_TAMANHO_17);

                        /*" -6149- MOVE WS-TRATA-TAMANHO-17 TO ATTRVAL09-GERAL */
                        _.Move(AREA_DE_WORK.WS_TRATA_TAMANHO.WS_TRATA_TAMANHO_17, W_REGISTRO_SIAS_GERAL.ATTRVAL09_GERAL);

                        /*" -6150- END-IF */
                    }


                    /*" -6151- WHEN '09003' */
                    break;
                case "09003":

                /*" -6152- WHEN '09004' */
                case "09004":

                    /*" -6153- WHEN '09008' */
                    break;
                case "09008":

                /*" -6154- WHEN '09015' */
                case "09015":

                    /*" -6155- WHEN '09025' */
                    break;
                case "09025":

                /*" -6156- CONTINUE */

                /*" -6157- WHEN '09001' */
                case "09001":

                    /*" -6158- WHEN '09010' */
                    break;
                case "09010":

                /*" -6159- WHEN '09014' */
                case "09014":

                    /*" -6160- WHEN '09023' */
                    break;
                case "09023":

                    /*" -6161- CONTINUE */

                    /*" -6164- END-EVALUATE. */
                    break;
            }


            /*" -6165- EVALUATE WS-COD-EVENTO-NUM */
            switch (FILLER_18.WS_COD_EVENTO_NUM.Value.Trim())
            {

                /*" -6166- WHEN '09001' */
                case "09001":

                    /*" -6167- WHEN '09002' */
                    break;
                case "09002":

                /*" -6168- WHEN '09006' */
                case "09006":

                    /*" -6169- WHEN '09007' */
                    break;
                case "09007":

                /*" -6170- WHEN '09009' */
                case "09009":

                    /*" -6171- WHEN '09010' */
                    break;
                case "09010":

                /*" -6172- WHEN '09014' */
                case "09014":

                    /*" -6173- WHEN '09022' */
                    break;
                case "09022":

                /*" -6174- WHEN '09023' */
                case "09023":

                    /*" -6175- MOVE 'ATR_CNOI' TO ATTR11-GERAL */
                    _.Move("ATR_CNOI", W_REGISTRO_SIAS_GERAL.ATTR11_GERAL);

                    /*" -6177- IF (SINISLAN-SEQ-INDICATIVO-OBRA EQUAL 9999 OR 0) OR (W-CHAVE-TIPO-PESSOA-PF-PJ EQUAL 'PF' ) */

                    if ((SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_SEQ_INDICATIVO_OBRA.In("9999", "0")) || (AREA_DE_WORK.W_CHAVE_TIPO_PESSOA_PF_PJ == "PF"))
                    {

                        /*" -6178- MOVE ALL 'X' TO ATTRVAL11-GERAL */
                        _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL11_GERAL);

                        /*" -6179- ELSE */
                    }
                    else
                    {


                        /*" -6181- MOVE SINISLAN-SEQ-INDICATIVO-OBRA TO WS-TRATA-TAMANHO-1 */
                        _.Move(SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_SEQ_INDICATIVO_OBRA, AREA_DE_WORK.WS_TRATA_TAMANHO.WS_TRATA_TAMANHO_1);

                        /*" -6182- MOVE WS-TRATA-TAMANHO-1 TO ATTRVAL11-GERAL */
                        _.Move(AREA_DE_WORK.WS_TRATA_TAMANHO.WS_TRATA_TAMANHO_1, W_REGISTRO_SIAS_GERAL.ATTRVAL11_GERAL);

                        /*" -6183- END-IF */
                    }


                    /*" -6184- WHEN '09005' */
                    break;
                case "09005":

                /*" -6185- WHEN '09011' */
                case "09011":

                    /*" -6186- WHEN '09012' */
                    break;
                case "09012":

                /*" -6187- WHEN '09013' */
                case "09013":

                    /*" -6188- WHEN '09024' */
                    break;
                case "09024":

                    /*" -6189- MOVE 'ATR_NATR' TO ATTR11-GERAL */
                    _.Move("ATR_NATR", W_REGISTRO_SIAS_GERAL.ATTR11_GERAL);

                    /*" -6190- IF SINISCAP-COD-NAT-RENDIMENTO NOT EQUAL ZEROS */

                    if (SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_NAT_RENDIMENTO != 00)
                    {

                        /*" -6192- MOVE SINISCAP-COD-NAT-RENDIMENTO TO ATTRVAL11-GERAL */
                        _.Move(SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_NAT_RENDIMENTO, W_REGISTRO_SIAS_GERAL.ATTRVAL11_GERAL);

                        /*" -6193- ELSE */
                    }
                    else
                    {


                        /*" -6194- MOVE ALL 'X' TO ATTRVAL11-GERAL */
                        _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL11_GERAL);

                        /*" -6195- END-IF */
                    }


                    /*" -6196- WHEN '09003' */
                    break;
                case "09003":

                /*" -6197- WHEN '09004' */
                case "09004":

                    /*" -6198- WHEN '09008' */
                    break;
                case "09008":

                /*" -6199- WHEN '09015' */
                case "09015":

                    /*" -6200- WHEN '09025' */
                    break;
                case "09025":

                    /*" -6201- CONTINUE */

                    /*" -6204- END-EVALUATE. */
                    break;
            }


            /*" -6205- EVALUATE WS-COD-EVENTO-NUM */
            switch (FILLER_18.WS_COD_EVENTO_NUM.Value.Trim())
            {

                /*" -6206- WHEN '09001' */
                case "09001":

                    /*" -6207- WHEN '09002' */
                    break;
                case "09002":

                /*" -6208- WHEN '09006' */
                case "09006":

                    /*" -6209- WHEN '09007' */
                    break;
                case "09007":

                /*" -6210- WHEN '09009' */
                case "09009":

                    /*" -6211- WHEN '09010' */
                    break;
                case "09010":

                /*" -6212- WHEN '09014' */
                case "09014":

                    /*" -6213- WHEN '09022' */
                    break;
                case "09022":

                /*" -6214- WHEN '09023' */
                case "09023":

                    /*" -6215- MOVE 'ATR_CNOC' TO ATTR36-GERAL */
                    _.Move("ATR_CNOC", W_REGISTRO_SIAS_GERAL.ATTR36_GERAL);

                    /*" -6216- IF SINISLAN-SEQ-INDICATIVO-OBRA EQUAL ZEROS */

                    if (SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_SEQ_INDICATIVO_OBRA == 00)
                    {

                        /*" -6217- MOVE ALL 'X' TO ATTRVAL36-GERAL */
                        _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL36_GERAL);

                        /*" -6218- ELSE */
                    }
                    else
                    {


                        /*" -6220- MOVE SINISLAN-COD-NACIONAL-OBRA TO WS-TRATA-TAMANHO-17 */
                        _.Move(SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_COD_NACIONAL_OBRA, AREA_DE_WORK.WS_TRATA_TAMANHO.WS_TRATA_TAMANHO_17);

                        /*" -6222- MOVE WS-TRATA-TAMANHO-17 TO ATTRVAL36-GERAL */
                        _.Move(AREA_DE_WORK.WS_TRATA_TAMANHO.WS_TRATA_TAMANHO_17, W_REGISTRO_SIAS_GERAL.ATTRVAL36_GERAL);

                        /*" -6223- END-IF */
                    }


                    /*" -6224- WHEN '09003' */
                    break;
                case "09003":

                /*" -6225- WHEN '09004' */
                case "09004":

                    /*" -6226- WHEN '09008' */
                    break;
                case "09008":

                /*" -6227- WHEN '09015' */
                case "09015":

                    /*" -6228- WHEN '09025' */
                    break;
                case "09025":

                /*" -6229- CONTINUE */

                /*" -6230- WHEN '09005' */
                case "09005":

                    /*" -6231- WHEN '09011' */
                    break;
                case "09011":

                /*" -6232- WHEN '09012' */
                case "09012":

                    /*" -6233- WHEN '09013' */
                    break;
                case "09013":

                /*" -6234- WHEN '09024' */
                case "09024":

                    /*" -6235- MOVE 'ATR_PJDT' TO ATTR36-GERAL */
                    _.Move("ATR_PJDT", W_REGISTRO_SIAS_GERAL.ATTR36_GERAL);

                    /*" -6237- IF SINISCAP-COD-PROCESSO-ISENCAO EQUAL SPACES */

                    if (SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_PROCESSO_ISENCAO.IsEmpty())
                    {

                        /*" -6238- MOVE ALL 'X' TO ATTRVAL36-GERAL */
                        _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL36_GERAL);

                        /*" -6239- ELSE */
                    }
                    else
                    {


                        /*" -6241- MOVE SINISCAP-COD-PROCESSO-ISENCAO TO ATTRVAL36-GERAL */
                        _.Move(SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_PROCESSO_ISENCAO, W_REGISTRO_SIAS_GERAL.ATTRVAL36_GERAL);

                        /*" -6242- END-IF */
                    }


                    /*" -6245- END-EVALUATE. */
                    break;
            }


            /*" -6246- EVALUATE WS-COD-EVENTO-NUM */
            switch (FILLER_18.WS_COD_EVENTO_NUM.Value.Trim())
            {

                /*" -6247- WHEN '09001' */
                case "09001":

                    /*" -6248- WHEN '09002' */
                    break;
                case "09002":

                /*" -6249- WHEN '09006' */
                case "09006":

                    /*" -6250- WHEN '09007' */
                    break;
                case "09007":

                /*" -6251- WHEN '09009' */
                case "09009":

                    /*" -6252- WHEN '09010' */
                    break;
                case "09010":

                /*" -6253- WHEN '09014' */
                case "09014":

                    /*" -6254- WHEN '09022' */
                    break;
                case "09022":

                /*" -6255- WHEN '09023' */
                case "09023":

                    /*" -6256- MOVE 'ATR_NATR' TO ATTR38-GERAL */
                    _.Move("ATR_NATR", W_REGISTRO_SIAS_GERAL.ATTR38_GERAL);

                    /*" -6257- IF SINISCAP-COD-NAT-RENDIMENTO NOT EQUAL ZEROS */

                    if (SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_NAT_RENDIMENTO != 00)
                    {

                        /*" -6259- MOVE SINISCAP-COD-NAT-RENDIMENTO TO ATTRVAL38-GERAL */
                        _.Move(SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_NAT_RENDIMENTO, W_REGISTRO_SIAS_GERAL.ATTRVAL38_GERAL);

                        /*" -6260- ELSE */
                    }
                    else
                    {


                        /*" -6261- MOVE ALL 'X' TO ATTRVAL38-GERAL */
                        _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL38_GERAL);

                        /*" -6262- END-IF */
                    }


                    /*" -6263- WHEN '09003' */
                    break;
                case "09003":

                /*" -6264- WHEN '09004' */
                case "09004":

                    /*" -6265- WHEN '09008' */
                    break;
                case "09008":

                /*" -6266- WHEN '09015' */
                case "09015":

                    /*" -6267- WHEN '09025' */
                    break;
                case "09025":

                    /*" -6268- MOVE 'ATR_CNOI' TO ATTR38-GERAL */
                    _.Move("ATR_CNOI", W_REGISTRO_SIAS_GERAL.ATTR38_GERAL);

                    /*" -6270- IF (SINISLAN-SEQ-INDICATIVO-OBRA EQUAL 9999 OR 0) OR (W-CHAVE-TIPO-PESSOA-PF-PJ EQUAL 'PF' ) */

                    if ((SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_SEQ_INDICATIVO_OBRA.In("9999", "0")) || (AREA_DE_WORK.W_CHAVE_TIPO_PESSOA_PF_PJ == "PF"))
                    {

                        /*" -6271- MOVE ALL 'X' TO ATTRVAL38-GERAL */
                        _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL38_GERAL);

                        /*" -6272- ELSE */
                    }
                    else
                    {


                        /*" -6274- MOVE SINISLAN-SEQ-INDICATIVO-OBRA TO WS-TRATA-TAMANHO-1 */
                        _.Move(SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_SEQ_INDICATIVO_OBRA, AREA_DE_WORK.WS_TRATA_TAMANHO.WS_TRATA_TAMANHO_1);

                        /*" -6275- MOVE WS-TRATA-TAMANHO-1 TO ATTRVAL38-GERAL */
                        _.Move(AREA_DE_WORK.WS_TRATA_TAMANHO.WS_TRATA_TAMANHO_1, W_REGISTRO_SIAS_GERAL.ATTRVAL38_GERAL);

                        /*" -6276- END-IF */
                    }


                    /*" -6277- WHEN '09005' */
                    break;
                case "09005":

                /*" -6278- WHEN '09011' */
                case "09011":

                    /*" -6279- WHEN '09012' */
                    break;
                case "09012":

                /*" -6280- WHEN '09013' */
                case "09013":

                    /*" -6281- WHEN '09024' */
                    break;
                case "09024":

                    /*" -6282- MOVE 'ATR_MEAT' TO ATTR38-GERAL */
                    _.Move("ATR_MEAT", W_REGISTRO_SIAS_GERAL.ATTR38_GERAL);

                    /*" -6284- IF SINISLAN-VLR-CUSTO-N-BASE-INSS EQUAL ZEROS */

                    if (SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_VLR_CUSTO_N_BASE_INSS == 00)
                    {

                        /*" -6285- MOVE ALL 'X' TO ATTRVAL38-GERAL */
                        _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL38_GERAL);

                        /*" -6286- ELSE */
                    }
                    else
                    {


                        /*" -6288- MOVE SINISLAN-VLR-CUSTO-N-BASE-INSS TO WS-VLR-AUX-14 */
                        _.Move(SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_VLR_CUSTO_N_BASE_INSS, AREA_DE_WORK.WS_VLR_AUX_14);

                        /*" -6289- MOVE WS-VLR-AUX-14 TO ATTRVAL38-GERAL */
                        _.Move(AREA_DE_WORK.WS_VLR_AUX_14, W_REGISTRO_SIAS_GERAL.ATTRVAL38_GERAL);

                        /*" -6291- END-IF */
                    }


                    /*" -6294- END-EVALUATE. */
                    break;
            }


            /*" -6295- EVALUATE WS-COD-EVENTO-NUM */
            switch (FILLER_18.WS_COD_EVENTO_NUM.Value.Trim())
            {

                /*" -6296- WHEN '09001' */
                case "09001":

                    /*" -6297- WHEN '09002' */
                    break;
                case "09002":

                /*" -6298- WHEN '09006' */
                case "09006":

                    /*" -6299- WHEN '09007' */
                    break;
                case "09007":

                /*" -6300- WHEN '09009' */
                case "09009":

                    /*" -6301- WHEN '09010' */
                    break;
                case "09010":

                /*" -6302- WHEN '09014' */
                case "09014":

                    /*" -6303- WHEN '09022' */
                    break;
                case "09022":

                /*" -6304- WHEN '09023' */
                case "09023":

                    /*" -6305- MOVE 'ATR_PJDT' TO ATTR39-GERAL */
                    _.Move("ATR_PJDT", W_REGISTRO_SIAS_GERAL.ATTR39_GERAL);

                    /*" -6307- IF SINISCAP-COD-PROCESSO-ISENCAO EQUAL SPACES */

                    if (SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_PROCESSO_ISENCAO.IsEmpty())
                    {

                        /*" -6308- MOVE ALL 'X' TO ATTRVAL39-GERAL */
                        _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL39_GERAL);

                        /*" -6309- ELSE */
                    }
                    else
                    {


                        /*" -6311- MOVE SINISCAP-COD-PROCESSO-ISENCAO TO ATTRVAL39-GERAL */
                        _.Move(SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_PROCESSO_ISENCAO, W_REGISTRO_SIAS_GERAL.ATTRVAL39_GERAL);

                        /*" -6312- END-IF */
                    }


                    /*" -6313- WHEN '09003' */
                    break;
                case "09003":

                /*" -6314- WHEN '09004' */
                case "09004":

                    /*" -6315- WHEN '09008' */
                    break;
                case "09008":

                /*" -6316- WHEN '09015' */
                case "09015":

                    /*" -6317- WHEN '09025' */
                    break;
                case "09025":

                    /*" -6318- MOVE 'ATR_CNOC' TO ATTR39-GERAL */
                    _.Move("ATR_CNOC", W_REGISTRO_SIAS_GERAL.ATTR39_GERAL);

                    /*" -6319- IF SINISLAN-SEQ-INDICATIVO-OBRA EQUAL ZEROS */

                    if (SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_SEQ_INDICATIVO_OBRA == 00)
                    {

                        /*" -6320- MOVE ALL 'X' TO ATTRVAL39-GERAL */
                        _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL39_GERAL);

                        /*" -6321- ELSE */
                    }
                    else
                    {


                        /*" -6323- MOVE SINISLAN-COD-NACIONAL-OBRA TO WS-TRATA-TAMANHO-17 */
                        _.Move(SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_COD_NACIONAL_OBRA, AREA_DE_WORK.WS_TRATA_TAMANHO.WS_TRATA_TAMANHO_17);

                        /*" -6324- MOVE WS-TRATA-TAMANHO-17 TO ATTRVAL39-GERAL */
                        _.Move(AREA_DE_WORK.WS_TRATA_TAMANHO.WS_TRATA_TAMANHO_17, W_REGISTRO_SIAS_GERAL.ATTRVAL39_GERAL);

                        /*" -6325- END-IF */
                    }


                    /*" -6326- WHEN '09005' */
                    break;
                case "09005":

                /*" -6327- WHEN '09011' */
                case "09011":

                    /*" -6328- WHEN '09012' */
                    break;
                case "09012":

                /*" -6329- WHEN '09013' */
                case "09013":

                    /*" -6330- WHEN '09024' */
                    break;
                case "09024":

                    /*" -6331- MOVE 'ATR_VRNF' TO ATTR39-GERAL */
                    _.Move("ATR_VRNF", W_REGISTRO_SIAS_GERAL.ATTR39_GERAL);

                    /*" -6333- IF SINISLAN-VLR-INSS-SUBCONTRATO EQUAL ZEROS */

                    if (SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_VLR_INSS_SUBCONTRATO == 00)
                    {

                        /*" -6334- MOVE ALL 'X' TO ATTRVAL39-GERAL */
                        _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL39_GERAL);

                        /*" -6335- ELSE */
                    }
                    else
                    {


                        /*" -6337- MOVE SINISLAN-VLR-INSS-SUBCONTRATO TO WS-VLR-AUX-14 */
                        _.Move(SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_VLR_INSS_SUBCONTRATO, AREA_DE_WORK.WS_VLR_AUX_14);

                        /*" -6338- MOVE WS-VLR-AUX-14 TO ATTRVAL39-GERAL */
                        _.Move(AREA_DE_WORK.WS_VLR_AUX_14, W_REGISTRO_SIAS_GERAL.ATTRVAL39_GERAL);

                        /*" -6339- END-IF */
                    }


                    /*" -6342- END-EVALUATE. */
                    break;
            }


            /*" -6343- EVALUATE WS-COD-EVENTO-NUM */
            switch (FILLER_18.WS_COD_EVENTO_NUM.Value.Trim())
            {

                /*" -6344- WHEN '09001' */
                case "09001":

                    /*" -6345- WHEN '09002' */
                    break;
                case "09002":

                /*" -6346- WHEN '09006' */
                case "09006":

                    /*" -6347- WHEN '09007' */
                    break;
                case "09007":

                /*" -6348- WHEN '09009' */
                case "09009":

                    /*" -6349- WHEN '09010' */
                    break;
                case "09010":

                /*" -6350- WHEN '09014' */
                case "09014":

                    /*" -6351- WHEN '09022' */
                    break;
                case "09022":

                /*" -6352- WHEN '09023' */
                case "09023":

                    /*" -6353- CONTINUE */

                    /*" -6354- WHEN '09003' */
                    break;
                case "09003":

                /*" -6355- WHEN '09004' */
                case "09004":

                    /*" -6356- WHEN '09008' */
                    break;
                case "09008":

                /*" -6357- WHEN '09015' */
                case "09015":

                    /*" -6358- WHEN '09025' */
                    break;
                case "09025":

                /*" -6359- CONTINUE */

                /*" -6360- WHEN '09005' */
                case "09005":

                    /*" -6361- WHEN '09011' */
                    break;
                case "09011":

                /*" -6362- WHEN '09012' */
                case "09012":

                    /*" -6363- WHEN '09013' */
                    break;
                case "09013":

                /*" -6364- WHEN '09024' */
                case "09024":

                    /*" -6365- MOVE 'ATR_VREP' TO ATTR40-GERAL */
                    _.Move("ATR_VREP", W_REGISTRO_SIAS_GERAL.ATTR40_GERAL);

                    /*" -6366- IF SINISLAN-NUM-LOTE NOT EQUAL WS-LOTE-ANT */

                    if (SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_NUM_LOTE != AREA_DE_WORK.WS_LOTE_ANT)
                    {

                        /*" -6367- MOVE SINISLAN-NUM-LOTE TO WS-LOTE-ANT */
                        _.Move(SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_NUM_LOTE, AREA_DE_WORK.WS_LOTE_ANT);

                        /*" -6369- IF SINISCAP-VLR-RET-N-EFETUADO EQUAL ZEROS */

                        if (SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_VLR_RET_N_EFETUADO == 00)
                        {

                            /*" -6370- MOVE ALL 'X' TO ATTRVAL40-GERAL */
                            _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL40_GERAL);

                            /*" -6371- ELSE */
                        }
                        else
                        {


                            /*" -6372- MOVE SINISCAP-VLR-RET-N-EFETUADO TO WS-VLR-AUX-14 */
                            _.Move(SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_VLR_RET_N_EFETUADO, AREA_DE_WORK.WS_VLR_AUX_14);

                            /*" -6373- MOVE WS-VLR-AUX-14 TO ATTRVAL40-GERAL */
                            _.Move(AREA_DE_WORK.WS_VLR_AUX_14, W_REGISTRO_SIAS_GERAL.ATTRVAL40_GERAL);

                            /*" -6374- END-IF */
                        }


                        /*" -6375- ELSE */
                    }
                    else
                    {


                        /*" -6376- MOVE ALL 'X' TO ATTRVAL40-GERAL */
                        _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL40_GERAL);

                        /*" -6378- END-IF */
                    }


                    /*" -6381- END-EVALUATE. */
                    break;
            }


            /*" -6382- EVALUATE WS-COD-EVENTO-NUM */
            switch (FILLER_18.WS_COD_EVENTO_NUM.Value.Trim())
            {

                /*" -6383- WHEN '09001' */
                case "09001":

                    /*" -6384- WHEN '09002' */
                    break;
                case "09002":

                /*" -6385- WHEN '09006' */
                case "09006":

                    /*" -6386- WHEN '09007' */
                    break;
                case "09007":

                /*" -6387- WHEN '09009' */
                case "09009":

                    /*" -6388- WHEN '09010' */
                    break;
                case "09010":

                /*" -6389- WHEN '09014' */
                case "09014":

                    /*" -6390- WHEN '09022' */
                    break;
                case "09022":

                /*" -6391- WHEN '09023' */
                case "09023":

                    /*" -6392- MOVE 'ATR_MEAT' TO ATTR41-GERAL */
                    _.Move("ATR_MEAT", W_REGISTRO_SIAS_GERAL.ATTR41_GERAL);

                    /*" -6394- IF SINISLAN-VLR-CUSTO-N-BASE-INSS EQUAL ZEROS */

                    if (SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_VLR_CUSTO_N_BASE_INSS == 00)
                    {

                        /*" -6395- MOVE ALL 'X' TO ATTRVAL41-GERAL */
                        _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL41_GERAL);

                        /*" -6396- ELSE */
                    }
                    else
                    {


                        /*" -6398- MOVE SINISLAN-VLR-CUSTO-N-BASE-INSS TO WS-VLR-AUX-14 */
                        _.Move(SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_VLR_CUSTO_N_BASE_INSS, AREA_DE_WORK.WS_VLR_AUX_14);

                        /*" -6399- MOVE WS-VLR-AUX-14 TO ATTRVAL41-GERAL */
                        _.Move(AREA_DE_WORK.WS_VLR_AUX_14, W_REGISTRO_SIAS_GERAL.ATTRVAL41_GERAL);

                        /*" -6400- END-IF */
                    }


                    /*" -6401- WHEN '09003' */
                    break;
                case "09003":

                /*" -6402- WHEN '09004' */
                case "09004":

                    /*" -6403- WHEN '09008' */
                    break;
                case "09008":

                /*" -6404- WHEN '09015' */
                case "09015":

                    /*" -6405- WHEN '09025' */
                    break;
                case "09025":

                    /*" -6406- MOVE 'ATR_NATR' TO ATTR41-GERAL */
                    _.Move("ATR_NATR", W_REGISTRO_SIAS_GERAL.ATTR41_GERAL);

                    /*" -6407- IF SINISCAP-COD-NAT-RENDIMENTO NOT EQUAL ZEROS */

                    if (SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_NAT_RENDIMENTO != 00)
                    {

                        /*" -6409- MOVE SINISCAP-COD-NAT-RENDIMENTO TO ATTRVAL41-GERAL */
                        _.Move(SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_NAT_RENDIMENTO, W_REGISTRO_SIAS_GERAL.ATTRVAL41_GERAL);

                        /*" -6410- ELSE */
                    }
                    else
                    {


                        /*" -6411- MOVE ALL 'X' TO ATTRVAL41-GERAL */
                        _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL41_GERAL);

                        /*" -6412- END-IF */
                    }


                    /*" -6413- WHEN '09005' */
                    break;
                case "09005":

                /*" -6414- WHEN '09011' */
                case "09011":

                    /*" -6415- WHEN '09012' */
                    break;
                case "09012":

                /*" -6416- WHEN '09013' */
                case "09013":

                    /*" -6417- WHEN '09024' */
                    break;
                case "09024":

                    /*" -6418- MOVE 'ATR_QIPL' TO ATTR41-GERAL */
                    _.Move("ATR_QIPL", W_REGISTRO_SIAS_GERAL.ATTR41_GERAL);

                    /*" -6420- IF SINISCAP-COD-IMPOSTO-LIMINAR EQUAL ZEROS */

                    if (SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_IMPOSTO_LIMINAR == 00)
                    {

                        /*" -6421- MOVE ALL 'X' TO ATTRVAL41-GERAL */
                        _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL41_GERAL);

                        /*" -6422- ELSE */
                    }
                    else
                    {


                        /*" -6424- MOVE SINISCAP-COD-IMPOSTO-LIMINAR TO WS-TRATA-TAMANHO-2 */
                        _.Move(SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_IMPOSTO_LIMINAR, AREA_DE_WORK.WS_TRATA_TAMANHO.WS_TRATA_TAMANHO_2);

                        /*" -6425- MOVE WS-TRATA-TAMANHO-2 TO ATTRVAL41-GERAL */
                        _.Move(AREA_DE_WORK.WS_TRATA_TAMANHO.WS_TRATA_TAMANHO_2, W_REGISTRO_SIAS_GERAL.ATTRVAL41_GERAL);

                        /*" -6427- END-IF */
                    }


                    /*" -6430- END-EVALUATE. */
                    break;
            }


            /*" -6431- EVALUATE WS-COD-EVENTO-NUM */
            switch (FILLER_18.WS_COD_EVENTO_NUM.Value.Trim())
            {

                /*" -6432- WHEN '09001' */
                case "09001":

                    /*" -6433- WHEN '09002' */
                    break;
                case "09002":

                /*" -6434- WHEN '09006' */
                case "09006":

                    /*" -6435- WHEN '09007' */
                    break;
                case "09007":

                /*" -6436- WHEN '09009' */
                case "09009":

                    /*" -6437- WHEN '09010' */
                    break;
                case "09010":

                /*" -6438- WHEN '09014' */
                case "09014":

                    /*" -6439- WHEN '09022' */
                    break;
                case "09022":

                /*" -6440- WHEN '09023' */
                case "09023":

                    /*" -6441- MOVE 'ATR_VRNF' TO ATTR42-GERAL */
                    _.Move("ATR_VRNF", W_REGISTRO_SIAS_GERAL.ATTR42_GERAL);

                    /*" -6443- IF SINISLAN-VLR-INSS-SUBCONTRATO EQUAL ZEROS */

                    if (SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_VLR_INSS_SUBCONTRATO == 00)
                    {

                        /*" -6444- MOVE ALL 'X' TO ATTRVAL42-GERAL */
                        _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL42_GERAL);

                        /*" -6445- ELSE */
                    }
                    else
                    {


                        /*" -6447- MOVE SINISLAN-VLR-INSS-SUBCONTRATO TO WS-VLR-AUX-14 */
                        _.Move(SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_VLR_INSS_SUBCONTRATO, AREA_DE_WORK.WS_VLR_AUX_14);

                        /*" -6448- MOVE WS-VLR-AUX-14 TO ATTRVAL42-GERAL */
                        _.Move(AREA_DE_WORK.WS_VLR_AUX_14, W_REGISTRO_SIAS_GERAL.ATTRVAL42_GERAL);

                        /*" -6449- END-IF */
                    }


                    /*" -6450- WHEN '09003' */
                    break;
                case "09003":

                /*" -6451- WHEN '09004' */
                case "09004":

                    /*" -6452- WHEN '09008' */
                    break;
                case "09008":

                /*" -6453- WHEN '09015' */
                case "09015":

                    /*" -6454- WHEN '09025' */
                    break;
                case "09025":

                    /*" -6455- MOVE 'ATR_PJDT' TO ATTR42-GERAL */
                    _.Move("ATR_PJDT", W_REGISTRO_SIAS_GERAL.ATTR42_GERAL);

                    /*" -6457- IF SINISCAP-COD-PROCESSO-ISENCAO EQUAL SPACES */

                    if (SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_PROCESSO_ISENCAO.IsEmpty())
                    {

                        /*" -6458- MOVE ALL 'X' TO ATTRVAL42-GERAL */
                        _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL42_GERAL);

                        /*" -6459- ELSE */
                    }
                    else
                    {


                        /*" -6461- MOVE SINISCAP-COD-PROCESSO-ISENCAO TO ATTRVAL42-GERAL */
                        _.Move(SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_PROCESSO_ISENCAO, W_REGISTRO_SIAS_GERAL.ATTRVAL42_GERAL);

                        /*" -6462- END-IF */
                    }


                    /*" -6463- WHEN '09005' */
                    break;
                case "09005":

                /*" -6464- WHEN '09011' */
                case "09011":

                    /*" -6465- WHEN '09012' */
                    break;
                case "09012":

                /*" -6466- WHEN '09013' */
                case "09013":

                    /*" -6467- WHEN '09024' */
                    break;
                case "09024":

                    /*" -6469- MOVE SPACES TO ATTR42-GERAL ATTRVAL42-GERAL */
                    _.Move("", W_REGISTRO_SIAS_GERAL.ATTR42_GERAL, W_REGISTRO_SIAS_GERAL.ATTRVAL42_GERAL);

                    /*" -6472- END-EVALUATE. */
                    break;
            }


            /*" -6473- EVALUATE WS-COD-EVENTO-NUM */
            switch (FILLER_18.WS_COD_EVENTO_NUM.Value.Trim())
            {

                /*" -6474- WHEN '09001' */
                case "09001":

                    /*" -6475- WHEN '09002' */
                    break;
                case "09002":

                /*" -6476- WHEN '09006' */
                case "09006":

                    /*" -6477- WHEN '09007' */
                    break;
                case "09007":

                /*" -6478- WHEN '09009' */
                case "09009":

                    /*" -6479- WHEN '09010' */
                    break;
                case "09010":

                /*" -6480- WHEN '09014' */
                case "09014":

                    /*" -6481- WHEN '09022' */
                    break;
                case "09022":

                /*" -6482- WHEN '09023' */
                case "09023":

                    /*" -6483- MOVE 'ATR_VREP' TO ATTR43-GERAL */
                    _.Move("ATR_VREP", W_REGISTRO_SIAS_GERAL.ATTR43_GERAL);

                    /*" -6484- IF SINISLAN-NUM-LOTE NOT EQUAL WS-LOTE-ANT */

                    if (SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_NUM_LOTE != AREA_DE_WORK.WS_LOTE_ANT)
                    {

                        /*" -6485- MOVE SINISLAN-NUM-LOTE TO WS-LOTE-ANT */
                        _.Move(SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_NUM_LOTE, AREA_DE_WORK.WS_LOTE_ANT);

                        /*" -6487- IF SINISCAP-VLR-RET-N-EFETUADO EQUAL ZEROS */

                        if (SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_VLR_RET_N_EFETUADO == 00)
                        {

                            /*" -6488- MOVE ALL 'X' TO ATTRVAL43-GERAL */
                            _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL43_GERAL);

                            /*" -6489- ELSE */
                        }
                        else
                        {


                            /*" -6490- MOVE SINISCAP-VLR-RET-N-EFETUADO TO WS-VLR-AUX-14 */
                            _.Move(SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_VLR_RET_N_EFETUADO, AREA_DE_WORK.WS_VLR_AUX_14);

                            /*" -6491- MOVE WS-VLR-AUX-14 TO ATTRVAL43-GERAL */
                            _.Move(AREA_DE_WORK.WS_VLR_AUX_14, W_REGISTRO_SIAS_GERAL.ATTRVAL43_GERAL);

                            /*" -6492- END-IF */
                        }


                        /*" -6493- ELSE */
                    }
                    else
                    {


                        /*" -6494- MOVE ALL 'X' TO ATTRVAL43-GERAL */
                        _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL43_GERAL);

                        /*" -6495- END-IF */
                    }


                    /*" -6496- WHEN '09003' */
                    break;
                case "09003":

                /*" -6497- WHEN '09004' */
                case "09004":

                    /*" -6498- WHEN '09008' */
                    break;
                case "09008":

                /*" -6499- WHEN '09015' */
                case "09015":

                    /*" -6500- WHEN '09025' */
                    break;
                case "09025":

                /*" -6501- CONTINUE */

                /*" -6502- WHEN '09005' */
                case "09005":

                    /*" -6503- WHEN '09011' */
                    break;
                case "09011":

                /*" -6504- WHEN '09012' */
                case "09012":

                    /*" -6505- WHEN '09013' */
                    break;
                case "09013":

                /*" -6506- WHEN '09024' */
                case "09024":

                    /*" -6508- MOVE SPACES TO ATTR43-GERAL ATTRVAL43-GERAL */
                    _.Move("", W_REGISTRO_SIAS_GERAL.ATTR43_GERAL, W_REGISTRO_SIAS_GERAL.ATTRVAL43_GERAL);

                    /*" -6511- END-EVALUATE. */
                    break;
            }


            /*" -6512- EVALUATE WS-COD-EVENTO-NUM */
            switch (FILLER_18.WS_COD_EVENTO_NUM.Value.Trim())
            {

                /*" -6513- WHEN '09001' */
                case "09001":

                    /*" -6514- WHEN '09002' */
                    break;
                case "09002":

                /*" -6515- WHEN '09006' */
                case "09006":

                    /*" -6516- WHEN '09007' */
                    break;
                case "09007":

                /*" -6517- WHEN '09009' */
                case "09009":

                    /*" -6518- WHEN '09010' */
                    break;
                case "09010":

                /*" -6519- WHEN '09014' */
                case "09014":

                    /*" -6520- WHEN '09022' */
                    break;
                case "09022":

                /*" -6521- WHEN '09023' */
                case "09023":

                    /*" -6522- MOVE 'ATR_QIPL' TO ATTR44-GERAL */
                    _.Move("ATR_QIPL", W_REGISTRO_SIAS_GERAL.ATTR44_GERAL);

                    /*" -6524- IF SINISCAP-COD-IMPOSTO-LIMINAR EQUAL ZEROS */

                    if (SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_IMPOSTO_LIMINAR == 00)
                    {

                        /*" -6525- MOVE ALL 'X' TO ATTRVAL44-GERAL */
                        _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL44_GERAL);

                        /*" -6526- ELSE */
                    }
                    else
                    {


                        /*" -6528- MOVE SINISCAP-COD-IMPOSTO-LIMINAR TO WS-TRATA-TAMANHO-2 */
                        _.Move(SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_IMPOSTO_LIMINAR, AREA_DE_WORK.WS_TRATA_TAMANHO.WS_TRATA_TAMANHO_2);

                        /*" -6529- MOVE WS-TRATA-TAMANHO-2 TO ATTRVAL44-GERAL */
                        _.Move(AREA_DE_WORK.WS_TRATA_TAMANHO.WS_TRATA_TAMANHO_2, W_REGISTRO_SIAS_GERAL.ATTRVAL44_GERAL);

                        /*" -6530- END-IF */
                    }


                    /*" -6531- WHEN '09003' */
                    break;
                case "09003":

                /*" -6532- WHEN '09004' */
                case "09004":

                    /*" -6533- WHEN '09008' */
                    break;
                case "09008":

                /*" -6534- WHEN '09015' */
                case "09015":

                    /*" -6535- WHEN '09025' */
                    break;
                case "09025":

                    /*" -6536- MOVE 'ATR_MEAT' TO ATTR44-GERAL */
                    _.Move("ATR_MEAT", W_REGISTRO_SIAS_GERAL.ATTR44_GERAL);

                    /*" -6538- IF SINISLAN-VLR-CUSTO-N-BASE-INSS EQUAL ZEROS */

                    if (SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_VLR_CUSTO_N_BASE_INSS == 00)
                    {

                        /*" -6539- MOVE ALL 'X' TO ATTRVAL44-GERAL */
                        _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL44_GERAL);

                        /*" -6540- ELSE */
                    }
                    else
                    {


                        /*" -6542- MOVE SINISLAN-VLR-CUSTO-N-BASE-INSS TO WS-VLR-AUX-14 */
                        _.Move(SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_VLR_CUSTO_N_BASE_INSS, AREA_DE_WORK.WS_VLR_AUX_14);

                        /*" -6543- MOVE WS-VLR-AUX-14 TO ATTRVAL44-GERAL */
                        _.Move(AREA_DE_WORK.WS_VLR_AUX_14, W_REGISTRO_SIAS_GERAL.ATTRVAL44_GERAL);

                        /*" -6544- END-IF */
                    }


                    /*" -6545- WHEN '09005' */
                    break;
                case "09005":

                /*" -6546- WHEN '09011' */
                case "09011":

                    /*" -6547- WHEN '09012' */
                    break;
                case "09012":

                /*" -6548- WHEN '09013' */
                case "09013":

                    /*" -6549- WHEN '09024' */
                    break;
                case "09024":

                    /*" -6550- MOVE SPACES TO ATTR44-GERAL ATTRVAL44-GERAL */
                    _.Move("", W_REGISTRO_SIAS_GERAL.ATTR44_GERAL, W_REGISTRO_SIAS_GERAL.ATTRVAL44_GERAL);

                    /*" -6553- END-EVALUATE. */
                    break;
            }


            /*" -6554- EVALUATE WS-COD-EVENTO-NUM */
            switch (FILLER_18.WS_COD_EVENTO_NUM.Value.Trim())
            {

                /*" -6555- WHEN '09003' */
                case "09003":

                    /*" -6556- WHEN '09004' */
                    break;
                case "09004":

                /*" -6557- WHEN '09008' */
                case "09008":

                    /*" -6558- WHEN '09015' */
                    break;
                case "09015":

                /*" -6559- WHEN '09025' */
                case "09025":

                    /*" -6560- MOVE 'ATR_VRNF' TO ATTR45-GERAL */
                    _.Move("ATR_VRNF", W_REGISTRO_SIAS_GERAL.ATTR45_GERAL);

                    /*" -6562- IF SINISLAN-VLR-INSS-SUBCONTRATO EQUAL ZEROS */

                    if (SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_VLR_INSS_SUBCONTRATO == 00)
                    {

                        /*" -6563- MOVE ALL 'X' TO ATTRVAL45-GERAL */
                        _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL45_GERAL);

                        /*" -6564- ELSE */
                    }
                    else
                    {


                        /*" -6566- MOVE SINISLAN-VLR-INSS-SUBCONTRATO TO WS-VLR-AUX-14 */
                        _.Move(SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_VLR_INSS_SUBCONTRATO, AREA_DE_WORK.WS_VLR_AUX_14);

                        /*" -6567- MOVE WS-VLR-AUX-14 TO ATTRVAL45-GERAL */
                        _.Move(AREA_DE_WORK.WS_VLR_AUX_14, W_REGISTRO_SIAS_GERAL.ATTRVAL45_GERAL);

                        /*" -6568- END-IF */
                    }


                    /*" -6569- WHEN '09005' */
                    break;
                case "09005":

                /*" -6570- WHEN '09011' */
                case "09011":

                    /*" -6571- WHEN '09012' */
                    break;
                case "09012":

                /*" -6572- WHEN '09013' */
                case "09013":

                    /*" -6573- WHEN '09024' */
                    break;
                case "09024":

                /*" -6574- WHEN '09022' */
                case "09022":

                    /*" -6575- WHEN '09001' */
                    break;
                case "09001":

                /*" -6576- WHEN '09002' */
                case "09002":

                    /*" -6577- WHEN '09006' */
                    break;
                case "09006":

                /*" -6578- WHEN '09007' */
                case "09007":

                    /*" -6579- WHEN '09009' */
                    break;
                case "09009":

                /*" -6580- WHEN '09010' */
                case "09010":

                    /*" -6581- WHEN '09014' */
                    break;
                case "09014":

                /*" -6582- WHEN '09023' */
                case "09023":

                    /*" -6583- MOVE SPACES TO ATTR45-GERAL ATTRVAL45-GERAL */
                    _.Move("", W_REGISTRO_SIAS_GERAL.ATTR45_GERAL, W_REGISTRO_SIAS_GERAL.ATTRVAL45_GERAL);

                    /*" -6586- END-EVALUATE. */
                    break;
            }


            /*" -6587- EVALUATE WS-COD-EVENTO-NUM */
            switch (FILLER_18.WS_COD_EVENTO_NUM.Value.Trim())
            {

                /*" -6588- WHEN '09003' */
                case "09003":

                    /*" -6589- WHEN '09004' */
                    break;
                case "09004":

                /*" -6590- WHEN '09008' */
                case "09008":

                    /*" -6591- WHEN '09015' */
                    break;
                case "09015":

                /*" -6592- WHEN '09025' */
                case "09025":

                    /*" -6593- MOVE 'ATR_VREP' TO ATTR46-GERAL */
                    _.Move("ATR_VREP", W_REGISTRO_SIAS_GERAL.ATTR46_GERAL);

                    /*" -6594- IF SINISLAN-NUM-LOTE NOT EQUAL WS-LOTE-ANT */

                    if (SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_NUM_LOTE != AREA_DE_WORK.WS_LOTE_ANT)
                    {

                        /*" -6595- MOVE SINISLAN-NUM-LOTE TO WS-LOTE-ANT */
                        _.Move(SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_NUM_LOTE, AREA_DE_WORK.WS_LOTE_ANT);

                        /*" -6597- IF SINISCAP-VLR-RET-N-EFETUADO EQUAL ZEROS */

                        if (SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_VLR_RET_N_EFETUADO == 00)
                        {

                            /*" -6598- MOVE ALL 'X' TO ATTRVAL46-GERAL */
                            _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL46_GERAL);

                            /*" -6599- ELSE */
                        }
                        else
                        {


                            /*" -6600- MOVE SINISCAP-VLR-RET-N-EFETUADO TO WS-VLR-AUX-14 */
                            _.Move(SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_VLR_RET_N_EFETUADO, AREA_DE_WORK.WS_VLR_AUX_14);

                            /*" -6601- MOVE WS-VLR-AUX-14 TO ATTRVAL46-GERAL */
                            _.Move(AREA_DE_WORK.WS_VLR_AUX_14, W_REGISTRO_SIAS_GERAL.ATTRVAL46_GERAL);

                            /*" -6602- END-IF */
                        }


                        /*" -6603- ELSE */
                    }
                    else
                    {


                        /*" -6604- MOVE ALL 'X' TO ATTRVAL46-GERAL */
                        _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL46_GERAL);

                        /*" -6605- END-IF */
                    }


                    /*" -6606- WHEN '09005' */
                    break;
                case "09005":

                /*" -6607- WHEN '09011' */
                case "09011":

                    /*" -6608- WHEN '09012' */
                    break;
                case "09012":

                /*" -6609- WHEN '09013' */
                case "09013":

                    /*" -6610- WHEN '09024' */
                    break;
                case "09024":

                /*" -6611- WHEN '09022' */
                case "09022":

                    /*" -6612- WHEN '09001' */
                    break;
                case "09001":

                /*" -6613- WHEN '09002' */
                case "09002":

                    /*" -6614- WHEN '09006' */
                    break;
                case "09006":

                /*" -6615- WHEN '09007' */
                case "09007":

                    /*" -6616- WHEN '09009' */
                    break;
                case "09009":

                /*" -6617- WHEN '09010' */
                case "09010":

                    /*" -6618- WHEN '09014' */
                    break;
                case "09014":

                /*" -6619- WHEN '09023' */
                case "09023":

                    /*" -6620- MOVE SPACES TO ATTR46-GERAL ATTRVAL46-GERAL */
                    _.Move("", W_REGISTRO_SIAS_GERAL.ATTR46_GERAL, W_REGISTRO_SIAS_GERAL.ATTRVAL46_GERAL);

                    /*" -6623- END-EVALUATE. */
                    break;
            }


            /*" -6624- EVALUATE WS-COD-EVENTO-NUM */
            switch (FILLER_18.WS_COD_EVENTO_NUM.Value.Trim())
            {

                /*" -6625- WHEN '09003' */
                case "09003":

                    /*" -6626- WHEN '09004' */
                    break;
                case "09004":

                /*" -6627- WHEN '09008' */
                case "09008":

                    /*" -6628- WHEN '09015' */
                    break;
                case "09015":

                /*" -6629- WHEN '09025' */
                case "09025":

                    /*" -6630- MOVE 'ATR_QIPL' TO ATTR47-GERAL */
                    _.Move("ATR_QIPL", W_REGISTRO_SIAS_GERAL.ATTR47_GERAL);

                    /*" -6632- IF SINISCAP-COD-IMPOSTO-LIMINAR EQUAL ZEROS */

                    if (SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_IMPOSTO_LIMINAR == 00)
                    {

                        /*" -6633- MOVE ALL 'X' TO ATTRVAL47-GERAL */
                        _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL47_GERAL);

                        /*" -6634- ELSE */
                    }
                    else
                    {


                        /*" -6636- MOVE SINISCAP-COD-IMPOSTO-LIMINAR TO WS-TRATA-TAMANHO-2 */
                        _.Move(SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_IMPOSTO_LIMINAR, AREA_DE_WORK.WS_TRATA_TAMANHO.WS_TRATA_TAMANHO_2);

                        /*" -6637- MOVE WS-TRATA-TAMANHO-2 TO ATTRVAL47-GERAL */
                        _.Move(AREA_DE_WORK.WS_TRATA_TAMANHO.WS_TRATA_TAMANHO_2, W_REGISTRO_SIAS_GERAL.ATTRVAL47_GERAL);

                        /*" -6638- END-IF */
                    }


                    /*" -6639- WHEN '09005' */
                    break;
                case "09005":

                /*" -6640- WHEN '09011' */
                case "09011":

                    /*" -6641- WHEN '09012' */
                    break;
                case "09012":

                /*" -6642- WHEN '09013' */
                case "09013":

                    /*" -6644- WHEN '09024' */
                    break;
                case "09024":

                /*" -6646- WHEN '09022' */
                case "09022":

                    /*" -6647- WHEN '09001' */
                    break;
                case "09001":

                /*" -6648- WHEN '09002' */
                case "09002":

                    /*" -6649- WHEN '09006' */
                    break;
                case "09006":

                /*" -6650- WHEN '09007' */
                case "09007":

                    /*" -6651- WHEN '09009' */
                    break;
                case "09009":

                /*" -6652- WHEN '09010' */
                case "09010":

                    /*" -6653- WHEN '09014' */
                    break;
                case "09014":

                /*" -6654- WHEN '09023' */
                case "09023":

                    /*" -6655- MOVE SPACES TO ATTR47-GERAL ATTRVAL47-GERAL */
                    _.Move("", W_REGISTRO_SIAS_GERAL.ATTR47_GERAL, W_REGISTRO_SIAS_GERAL.ATTRVAL47_GERAL);

                    /*" -6655- END-EVALUATE. */
                    break;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R19100_EXIT*/

        [StopWatch]
        /*" R19200-SELECT-REINF */
        private void R19200_SELECT_REINF(bool isPerform = false)
        {
            /*" -6691- MOVE 'NAO' TO W-CHAVE-TEM-CAPA-LOTE */
            _.Move("NAO", AREA_DE_WORK.W_CHAVE_TEM_CAPA_LOTE);

            /*" -6692- EVALUATE GEOPERAC-FUNCAO-OPERACAO */
            switch (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO.Value.Trim())
            {

                /*" -6693- WHEN 'IND' */
                case "IND":

                    /*" -6694- WHEN 'LIB' */
                    break;
                case "LIB":

                    /*" -6695- MOVE 'PRE' TO W-PRE */
                    _.Move("PRE", AREA_DE_WORK.W_PRE);

                    /*" -6696- MOVE 'LIB' TO W-LIB */
                    _.Move("LIB", AREA_DE_WORK.W_LIB);

                    /*" -6697- WHEN 'DMOV' */
                    break;
                case "DMOV":

                /*" -6698- WHEN 'DPAG' */
                case "DPAG":

                    /*" -6699- MOVE 'DMOV' TO W-PRE */
                    _.Move("DMOV", AREA_DE_WORK.W_PRE);

                    /*" -6700- MOVE 'DPAG' TO W-LIB */
                    _.Move("DPAG", AREA_DE_WORK.W_LIB);

                    /*" -6701- WHEN 'HMOV' */
                    break;
                case "HMOV":

                /*" -6702- WHEN 'HPAG' */
                case "HPAG":

                    /*" -6703- MOVE 'HMOV' TO W-PRE */
                    _.Move("HMOV", AREA_DE_WORK.W_PRE);

                    /*" -6704- MOVE 'HPAG' TO W-LIB */
                    _.Move("HPAG", AREA_DE_WORK.W_LIB);

                    /*" -6705- WHEN 'RSHOL' */
                    break;
                case "RSHOL":

                /*" -6706- WHEN 'RSHOP' */
                case "RSHOP":

                    /*" -6707- MOVE 'RSHOL' TO W-PRE */
                    _.Move("RSHOL", AREA_DE_WORK.W_PRE);

                    /*" -6708- MOVE 'RSHOP' TO W-LIB */
                    _.Move("RSHOP", AREA_DE_WORK.W_LIB);

                    /*" -6709- WHEN 'RSREL' */
                    break;
                case "RSREL":

                /*" -6710- WHEN 'RSREP' */
                case "RSREP":

                    /*" -6711- MOVE 'RSREL' TO W-PRE */
                    _.Move("RSREL", AREA_DE_WORK.W_PRE);

                    /*" -6712- MOVE 'RSREP' TO W-LIB */
                    _.Move("RSREP", AREA_DE_WORK.W_LIB);

                    /*" -6713- WHEN 'DSMOV' */
                    break;
                case "DSMOV":

                /*" -6714- WHEN 'DSPAG' */
                case "DSPAG":

                    /*" -6715- MOVE 'DSMOV' TO W-PRE */
                    _.Move("DSMOV", AREA_DE_WORK.W_PRE);

                    /*" -6716- MOVE 'DSPAG' TO W-LIB */
                    _.Move("DSPAG", AREA_DE_WORK.W_LIB);

                    /*" -6717- WHEN 'HSMOV' */
                    break;
                case "HSMOV":

                /*" -6718- WHEN 'HSPAG' */
                case "HSPAG":

                    /*" -6719- MOVE 'HSMOV' TO W-PRE */
                    _.Move("HSMOV", AREA_DE_WORK.W_PRE);

                    /*" -6720- MOVE 'HSPAG' TO W-LIB */
                    _.Move("HSPAG", AREA_DE_WORK.W_LIB);

                    /*" -6721- WHEN 'JPDES' */
                    break;
                case "JPDES":

                /*" -6722- WHEN 'JBDES' */
                case "JBDES":

                    /*" -6723- MOVE 'JPDES' TO W-PRE */
                    _.Move("JPDES", AREA_DE_WORK.W_PRE);

                    /*" -6724- MOVE 'JBDES' TO W-LIB */
                    _.Move("JBDES", AREA_DE_WORK.W_LIB);

                    /*" -6725- WHEN 'JPHON' */
                    break;
                case "JPHON":

                /*" -6726- WHEN 'JBHON' */
                case "JBHON":

                    /*" -6727- MOVE 'JPHON' TO W-PRE */
                    _.Move("JPHON", AREA_DE_WORK.W_PRE);

                    /*" -6728- MOVE 'JBHON' TO W-LIB */
                    _.Move("JBHON", AREA_DE_WORK.W_LIB);

                    /*" -6729- WHEN 'JPIND' */
                    break;
                case "JPIND":

                /*" -6730- WHEN 'JBIND' */
                case "JBIND":

                    /*" -6731- MOVE 'JPIND' TO W-PRE */
                    _.Move("JPIND", AREA_DE_WORK.W_PRE);

                    /*" -6732- MOVE 'JLIND' TO W-LIB */
                    _.Move("JLIND", AREA_DE_WORK.W_LIB);

                    /*" -6733- WHEN 'JPDP' */
                    break;
                case "JPDP":

                /*" -6734- WHEN 'JBDP' */
                case "JBDP":

                    /*" -6735- MOVE 'JPDP' TO W-PRE */
                    _.Move("JPDP", AREA_DE_WORK.W_PRE);

                    /*" -6736- MOVE 'JBDP' TO W-LIB */
                    _.Move("JBDP", AREA_DE_WORK.W_LIB);

                    /*" -6737- WHEN 'RSDEL' */
                    break;
                case "RSDEL":

                /*" -6738- WHEN 'RSDEP' */
                case "RSDEP":

                    /*" -6739- MOVE 'RSDEL' TO W-PRE */
                    _.Move("RSDEL", AREA_DE_WORK.W_PRE);

                    /*" -6740- MOVE 'RSDEP' TO W-LIB */
                    _.Move("RSDEP", AREA_DE_WORK.W_LIB);

                    /*" -6742- END-EVALUATE */
                    break;
            }


            /*" -6743- INITIALIZE DCLSINISTRO-CAPALOTE1. */
            _.Initialize(
                SINISCAP.DCLSINISTRO_CAPALOTE1
            );

            /*" -6745- INITIALIZE DCLSINISTRO-LANCLOTE1. */
            _.Initialize(
                SINISLAN.DCLSINISTRO_LANCLOTE1
            );

            /*" -6746- MOVE ZEROS TO SINISLAN-COD-FONTE. */
            _.Move(0, SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_COD_FONTE);

            /*" -6747- MOVE ZEROS TO SINISLAN-NUM-LOTE. */
            _.Move(0, SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_NUM_LOTE);

            /*" -6748- MOVE ZEROS TO SINISLAN-NUM-APOL-SINISTRO. */
            _.Move(0, SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_NUM_APOL_SINISTRO);

            /*" -6749- MOVE ZEROS TO SINISLAN-OCORR-HISTORICO. */
            _.Move(0, SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_OCORR_HISTORICO);

            /*" -6750- MOVE ZEROS TO SINISLAN-COD-OPERACAO. */
            _.Move(0, SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_COD_OPERACAO);

            /*" -6751- MOVE ZEROS TO SINISLAN-VAL-OPERACAO. */
            _.Move(0, SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_VAL_OPERACAO);

            /*" -6752- MOVE SPACES TO SINISLAN-COD-PROCESSO-JURID. */
            _.Move("", SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_COD_PROCESSO_JURID);

            /*" -6753- MOVE ZEROS TO SINISLAN-VLR-INSS-SUBCONTRATO. */
            _.Move(0, SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_VLR_INSS_SUBCONTRATO);

            /*" -6754- MOVE ZEROS TO SINISLAN-SEQ-TP-SERVICO-INSS. */
            _.Move(0, SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_SEQ_TP_SERVICO_INSS);

            /*" -6755- MOVE ZEROS TO SINISLAN-SEQ-INDICATIVO-OBRA. */
            _.Move(0, SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_SEQ_INDICATIVO_OBRA);

            /*" -6756- MOVE ZEROS TO SINISLAN-VLR-CUSTO-N-BASE-INSS. */
            _.Move(0, SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_VLR_CUSTO_N_BASE_INSS);

            /*" -6757- MOVE ZEROS TO SINISLAN-COD-NACIONAL-OBRA. */
            _.Move(0, SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_COD_NACIONAL_OBRA);

            /*" -6758- MOVE ZEROS TO SINISLAN-VLR-BASE-CALCULO-INSS. */
            _.Move(0, SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_VLR_BASE_CALCULO_INSS);

            /*" -6759- MOVE ZEROS TO SINISCAP-NUM-DOCF-INTERNO. */
            _.Move(0, SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_NUM_DOCF_INTERNO);

            /*" -6760- MOVE ZEROS TO SINISCAP-NUM-CPF-CNPJ-FAVOREC. */
            _.Move(0, SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_NUM_CPF_CNPJ_FAVOREC);

            /*" -6761- MOVE ZEROS TO SINISCAP-NUM-CPF-CNPJ-TOMADOR. */
            _.Move(0, SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_NUM_CPF_CNPJ_TOMADOR);

            /*" -6762- MOVE ZEROS TO SINISCAP-SEQ-CNAE-CPRB. */
            _.Move(0, SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_SEQ_CNAE_CPRB);

            /*" -6763- MOVE ZEROS TO SINISCAP-VLR-TOTAL-DOCUMENTO. */
            _.Move(0, SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_VLR_TOTAL_DOCUMENTO);

            /*" -6764- MOVE SPACES TO SINISCAP-IND-GRUPO-LANCAMENTO. */
            _.Move("", SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_IND_GRUPO_LANCAMENTO);

            /*" -6765- MOVE SPACES TO SINISCAP-IND-ISENCAO-TRIBUTO. */
            _.Move("", SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_IND_ISENCAO_TRIBUTO);

            /*" -6766- MOVE ZEROS TO SINISCAP-COD-IMPOSTO-LIMINAR. */
            _.Move(0, SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_IMPOSTO_LIMINAR);

            /*" -6767- MOVE SPACES TO SINISCAP-COD-PROCESSO-ISENCAO. */
            _.Move("", SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_PROCESSO_ISENCAO);

            /*" -6768- MOVE ZEROS TO SINISCAP-VLR-RET-N-EFETUADO. */
            _.Move(0, SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_VLR_RET_N_EFETUADO);

            /*" -6769- MOVE ZEROS TO SINISCAP-PCT-CPRB. */
            _.Move(0, SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_PCT_CPRB);

            /*" -6770- MOVE SPACES TO SINISCAP-IND-DESC-INSS. */
            _.Move("", SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_IND_DESC_INSS);

            /*" -6771- MOVE ZEROS TO SINISCAP-COD-SERVICO-CONTABIL. */
            _.Move(0, SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_SERVICO_CONTABIL);

            /*" -6772- MOVE ZEROS TO SINISCAP-COD-NAT-RENDIMENTO. */
            _.Move(0, SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_NAT_RENDIMENTO);

            /*" -6773- MOVE ZEROS TO SINISCAP-COD-IMPOSTO-ISS. */
            _.Move(0, SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_IMPOSTO_ISS);

            /*" -6775- MOVE ZEROS TO SINISCAP-PCT-ALIQ-ISS. */
            _.Move(0, SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_PCT_ALIQ_ISS);

            /*" -6847- PERFORM R19200_SELECT_REINF_DB_SELECT_1 */

            R19200_SELECT_REINF_DB_SELECT_1();

            /*" -6850-  EVALUATE SQLCODE  */

            /*" -6851-  WHEN ZEROS  */

            /*" -6851- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -6852- MOVE 'SIM' TO W-CHAVE-TEM-CAPA-LOTE */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_TEM_CAPA_LOTE);

                /*" -6853-  WHEN +100  */

                /*" -6853- ELSE IF   SQLCODE EQUALS  +100 */
            }
            else

            if (DB.SQLCODE == +100)
            {

                /*" -6854- CONTINUE */

                /*" -6855-  WHEN OTHER  */

                /*" -6855- ELSE */
            }
            else
            {


                /*" -6857- DISPLAY 'SISAP01B - ERRO ACESSO INFO REINF - ' 'CAPA DE LOTE' */
                _.Display($"SISAP01B - ERRO ACESSO INFO REINF - CAPA DE LOTE");

                /*" -6859- DISPLAY 'SINISTRO ' SINISHIS-NUM-APOL-SINISTRO ' OCOR ' SINISHIS-OCORR-HISTORICO */

                $"SINISTRO {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO} OCOR {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}"
                .Display();

                /*" -6860- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -6862-  END-EVALUATE  */

                /*" -6862- END-IF */
            }


            /*" -6863- IF SINISLAN-SEQ-TP-SERVICO-INSS GREATER ZEROS */

            if (SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_SEQ_TP_SERVICO_INSS > 00)
            {

                /*" -6864- PERFORM R19300-SELECT-INSS THRU R19300-EXIT */

                R19300_SELECT_INSS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R19300_EXIT*/


                /*" -6864- END-IF. */
            }


        }

        [StopWatch]
        /*" R19200-SELECT-REINF-DB-SELECT-1 */
        public void R19200_SELECT_REINF_DB_SELECT_1()
        {
            /*" -6847- EXEC SQL SELECT SINISLAN.COD_FONTE ,SINISLAN.NUM_LOTE ,SINISLAN.NUM_APOL_SINISTRO ,SINISLAN.OCORR_HISTORICO ,SINISLAN.COD_OPERACAO ,SINISLAN.VAL_OPERACAO ,VALUE(SINISLAN.COD_PROCESSO_JURID, ' ' ) ,VALUE(SINISLAN.SEQ_TP_SERVICO_INSS,0) ,VALUE(SINISLAN.SEQ_INDICATIVO_OBRA,0) ,VALUE(SINISLAN.COD_NACIONAL_OBRA, 0) ,VALUE(SINISLAN.VLR_CUSTO_N_BASE_INSS, 0) ,VALUE(SINISLAN.VLR_BASE_CALCULO_INSS, 0) ,VALUE(SINISLAN.VLR_INSS_SUBCONTRATO, 0) ,VALUE(SINISCAP.NUM_DOCF_INTERNO, 0) ,VALUE(SINISCAP.NUM_CPF_CNPJ_FAVOREC, 0) ,VALUE(SINISCAP.NUM_CPF_CNPJ_TOMADOR, 0) ,VALUE(SINISCAP.SEQ_CNAE_CPRB, 0) ,VALUE(SINISCAP.VLR_TOTAL_DOCUMENTO, 0) ,VALUE(SINISCAP.IND_GRUPO_LANCAMENTO, ' ' ) ,VALUE(SINISCAP.IND_ISENCAO_TRIBUTO, ' ' ) ,VALUE(SINISCAP.COD_IMPOSTO_LIMINAR, 0) ,LTRIM(VALUE(SINISCAP.COD_PROCESSO_ISENCAO, ' ' )) ,VALUE(SINISCAP.VLR_RET_N_EFETUADO, 0) ,VALUE(SINISCAP.PCT_CPRB, 0) ,VALUE(SINISCAP.IND_DESC_INSS, 'S' ) ,VALUE(SINISCAP.COD_SERVICO_CONTABIL, '' ) ,VALUE(SINISCAP.COD_NAT_RENDIMENTO,0) ,VALUE(SINISCAP.COD_IMPOSTO_ISS, '' ) ,VALUE(SINISCAP.PCT_ALIQ_ISS,0) INTO :SINISLAN-COD-FONTE ,:SINISLAN-NUM-LOTE ,:SINISLAN-NUM-APOL-SINISTRO ,:SINISLAN-OCORR-HISTORICO ,:SINISLAN-COD-OPERACAO ,:SINISLAN-VAL-OPERACAO ,:SINISLAN-COD-PROCESSO-JURID ,:SINISLAN-SEQ-TP-SERVICO-INSS ,:SINISLAN-SEQ-INDICATIVO-OBRA ,:SINISLAN-COD-NACIONAL-OBRA ,:SINISLAN-VLR-CUSTO-N-BASE-INSS ,:SINISLAN-VLR-BASE-CALCULO-INSS ,:SINISLAN-VLR-INSS-SUBCONTRATO ,:SINISCAP-NUM-DOCF-INTERNO ,:SINISCAP-NUM-CPF-CNPJ-FAVOREC ,:SINISCAP-NUM-CPF-CNPJ-TOMADOR ,:SINISCAP-SEQ-CNAE-CPRB ,:SINISCAP-VLR-TOTAL-DOCUMENTO ,:SINISCAP-IND-GRUPO-LANCAMENTO ,:SINISCAP-IND-ISENCAO-TRIBUTO ,:SINISCAP-COD-IMPOSTO-LIMINAR ,:SINISCAP-COD-PROCESSO-ISENCAO ,:SINISCAP-VLR-RET-N-EFETUADO ,:SINISCAP-PCT-CPRB ,:SINISCAP-IND-DESC-INSS ,:SINISCAP-COD-SERVICO-CONTABIL ,:SINISCAP-COD-NAT-RENDIMENTO ,:SINISCAP-COD-IMPOSTO-ISS ,:SINISCAP-PCT-ALIQ-ISS FROM SEGUROS.SINISTRO_CAPALOTE1 SINISCAP ,SEGUROS.SINISTRO_LANCLOTE1 SINISLAN ,SEGUROS.GE_OPERACAO O WHERE SINISLAN.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND SINISLAN.OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND O.COD_OPERACAO = SINISLAN.COD_OPERACAO AND O.IDE_SISTEMA = 'SI' AND O.FUNCAO_OPERACAO IN (:W-PRE,:W-LIB) AND SINISCAP.COD_FONTE = SINISLAN.COD_FONTE AND SINISCAP.NUM_LOTE = SINISLAN.NUM_LOTE END-EXEC. */

            var r19200_SELECT_REINF_DB_SELECT_1_Query1 = new R19200_SELECT_REINF_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
                W_PRE = AREA_DE_WORK.W_PRE.ToString(),
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
            /*" -6877- MOVE SINISLAN-SEQ-TP-SERVICO-INSS TO GE612-SEQ-TP-SERVICO-INSS. */
            _.Move(SINISLAN.DCLSINISTRO_LANCLOTE1.SINISLAN_SEQ_TP_SERVICO_INSS, GE612.DCLGE_TP_SERVICO_INSS.GE612_SEQ_TP_SERVICO_INSS);

            /*" -6883- PERFORM R19300_SELECT_INSS_DB_SELECT_1 */

            R19300_SELECT_INSS_DB_SELECT_1();

            /*" -6886- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -6887- CONTINUE */

                /*" -6888- ELSE */
            }
            else
            {


                /*" -6889- IF SQLCODE EQUAL +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -6890- GO TO R19300-EXIT */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R19300_EXIT*/ //GOTO
                    return;

                    /*" -6891- ELSE */
                }
                else
                {


                    /*" -6892- DISPLAY 'SISAP01B - ERRO ACESSO INFO TIPO SERVICO' */
                    _.Display($"SISAP01B - ERRO ACESSO INFO TIPO SERVICO");

                    /*" -6893- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;

                    /*" -6894- END-IF */
                }


                /*" -6894- END-IF. */
            }


        }

        [StopWatch]
        /*" R19300-SELECT-INSS-DB-SELECT-1 */
        public void R19300_SELECT_INSS_DB_SELECT_1()
        {
            /*" -6883- EXEC SQL SELECT COD_TP_SERVICO_INSS INTO :GE612-COD-TP-SERVICO-INSS FROM SIUS.GE_TP_SERVICO_INSS WHERE SEQ_TP_SERVICO_INSS = :GE612-SEQ-TP-SERVICO-INSS END-EXEC. */

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
            /*" -6907- MOVE SINISHIS-COD-OPERACAO TO GEOPERAC-COD-OPERACAO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO, GEOPERAC.DCLGE_OPERACAO.GEOPERAC_COD_OPERACAO);

            /*" -6917- PERFORM R19400_VERIFICA_OPERACAO_DB_SELECT_1 */

            R19400_VERIFICA_OPERACAO_DB_SELECT_1();

            /*" -6920- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -6921- CONTINUE */

                /*" -6922- ELSE */
            }
            else
            {


                /*" -6923- IF SQLCODE EQUAL +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -6924- GO TO R19400-EXIT */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R19400_EXIT*/ //GOTO
                    return;

                    /*" -6925- ELSE */
                }
                else
                {


                    /*" -6926- DISPLAY 'SISAP01B - ERRO ACESSO BUSCA OPERACAO' */
                    _.Display($"SISAP01B - ERRO ACESSO BUSCA OPERACAO");

                    /*" -6927- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;

                    /*" -6928- END-IF */
                }


                /*" -6928- END-IF. */
            }


        }

        [StopWatch]
        /*" R19400-VERIFICA-OPERACAO-DB-SELECT-1 */
        public void R19400_VERIFICA_OPERACAO_DB_SELECT_1()
        {
            /*" -6917- EXEC SQL SELECT COD_OPERACAO ,DES_OPERACAO ,FUNCAO_OPERACAO INTO :GEOPERAC-COD-OPERACAO ,:GEOPERAC-DES-OPERACAO ,:GEOPERAC-FUNCAO-OPERACAO FROM SEGUROS.GE_OPERACAO WHERE IDE_SISTEMA = 'SI' AND COD_OPERACAO = :GEOPERAC-COD-OPERACAO END-EXEC. */

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
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R19400_EXIT*/

        [StopWatch]
        /*" R19500-MONTA-DESPESAS */
        private void R19500_MONTA_DESPESAS(bool isPerform = false)
        {
            /*" -6941- MOVE CODOPE-GERAL TO WS-COD-EVENTO. */
            _.Move(W_REGISTRO_SIAS_GERAL.CODOPE_GERAL, WS_COD_EVENTO);

            /*" -6942- EVALUATE WS-COD-EVENTO-NUM */
            switch (FILLER_18.WS_COD_EVENTO_NUM.Value.Trim())
            {

                /*" -6943- WHEN '09002' */
                case "09002":

                    /*" -6944- WHEN '09001' */
                    break;
                case "09001":

                /*" -6945- WHEN '09003' */
                case "09003":

                    /*" -6946- WHEN '09004' */
                    break;
                case "09004":

                /*" -6947- WHEN '09006' */
                case "09006":

                    /*" -6948- WHEN '09007' */
                    break;
                case "09007":

                /*" -6949- WHEN '09008' */
                case "09008":

                    /*" -6950- WHEN '09009' */
                    break;
                case "09009":

                /*" -6951- WHEN '09010' */
                case "09010":

                    /*" -6952- WHEN '09014' */
                    break;
                case "09014":

                /*" -6953- WHEN '09015' */
                case "09015":

                    /*" -6954- WHEN '09022' */
                    break;
                case "09022":

                /*" -6955- WHEN '09023' */
                case "09023":

                    /*" -6956- WHEN '09025' */
                    break;
                case "09025":

                /*" -6957- CONTINUE */

                /*" -6958- WHEN '09005' */
                case "09005":

                    /*" -6959- WHEN '09011' */
                    break;
                case "09011":

                /*" -6960- WHEN '09012' */
                case "09012":

                    /*" -6961- WHEN '09013' */
                    break;
                case "09013":

                /*" -6962- WHEN '09024' */
                case "09024":

                    /*" -6963- MOVE 'ATR_IRIQ' TO ATTR06-GERAL */
                    _.Move("ATR_IRIQ", W_REGISTRO_SIAS_GERAL.ATTR06_GERAL);

                    /*" -6964- MOVE ALL 'X' TO ATTRVAL06-GERAL */
                    _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL06_GERAL);

                    /*" -6967- END-EVALUATE. */
                    break;
            }


            /*" -6968- EVALUATE WS-COD-EVENTO-NUM */
            switch (FILLER_18.WS_COD_EVENTO_NUM.Value.Trim())
            {

                /*" -6969- WHEN '09002' */
                case "09002":

                    /*" -6970- WHEN '09003' */
                    break;
                case "09003":

                /*" -6971- WHEN '09004' */
                case "09004":

                    /*" -6972- WHEN '09006' */
                    break;
                case "09006":

                /*" -6973- WHEN '09007' */
                case "09007":

                    /*" -6974- WHEN '09008' */
                    break;
                case "09008":

                /*" -6975- WHEN '09009' */
                case "09009":

                    /*" -6976- WHEN '09015' */
                    break;
                case "09015":

                /*" -6977- WHEN '09022' */
                case "09022":

                    /*" -6978- WHEN '09025' */
                    break;
                case "09025":

                /*" -6979- CONTINUE */

                /*" -6980- WHEN '09001' */
                case "09001":

                    /*" -6981- WHEN '09010' */
                    break;
                case "09010":

                /*" -6982- WHEN '09014' */
                case "09014":

                    /*" -6983- WHEN '09023' */
                    break;
                case "09023":

                    /*" -6984- MOVE 'ATR_IRIQ' TO ATTR07-GERAL */
                    _.Move("ATR_IRIQ", W_REGISTRO_SIAS_GERAL.ATTR07_GERAL);

                    /*" -6985- MOVE ALL 'X' TO ATTRVAL07-GERAL */
                    _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL07_GERAL);

                    /*" -6986- WHEN '09005' */
                    break;
                case "09005":

                /*" -6987- WHEN '09011' */
                case "09011":

                    /*" -6988- WHEN '09012' */
                    break;
                case "09012":

                /*" -6989- WHEN '09013' */
                case "09013":

                    /*" -6990- WHEN '09024' */
                    break;
                case "09024":

                    /*" -6991- MOVE 'ATR_CNPJ' TO ATTR07-GERAL */
                    _.Move("ATR_CNPJ", W_REGISTRO_SIAS_GERAL.ATTR07_GERAL);

                    /*" -6992- MOVE ALL 'X' TO ATTRVAL07-GERAL */
                    _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL07_GERAL);

                    /*" -6995- END-EVALUATE. */
                    break;
            }


            /*" -6996- EVALUATE WS-COD-EVENTO-NUM */
            switch (FILLER_18.WS_COD_EVENTO_NUM.Value.Trim())
            {

                /*" -6997- WHEN '09002' */
                case "09002":

                    /*" -6998- WHEN '09003' */
                    break;
                case "09003":

                /*" -6999- WHEN '09004' */
                case "09004":

                    /*" -7000- WHEN '09006' */
                    break;
                case "09006":

                /*" -7001- WHEN '09007' */
                case "09007":

                    /*" -7002- WHEN '09008' */
                    break;
                case "09008":

                /*" -7003- WHEN '09009' */
                case "09009":

                    /*" -7004- WHEN '09015' */
                    break;
                case "09015":

                /*" -7005- WHEN '09022' */
                case "09022":

                    /*" -7006- WHEN '09025' */
                    break;
                case "09025":

                    /*" -7007- MOVE 'ATR_RJUD' TO ATTR08-GERAL */
                    _.Move("ATR_RJUD", W_REGISTRO_SIAS_GERAL.ATTR08_GERAL);

                    /*" -7008- MOVE ALL 'X' TO ATTRVAL08-GERAL */
                    _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL08_GERAL);

                    /*" -7009- WHEN '09001' */
                    break;
                case "09001":

                /*" -7010- WHEN '09010' */
                case "09010":

                    /*" -7011- WHEN '09014' */
                    break;
                case "09014":

                /*" -7012- WHEN '09023' */
                case "09023":

                    /*" -7013- MOVE 'ATR_CNPJ' TO ATTR08-GERAL */
                    _.Move("ATR_CNPJ", W_REGISTRO_SIAS_GERAL.ATTR08_GERAL);

                    /*" -7014- MOVE ALL 'X' TO ATTRVAL08-GERAL */
                    _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL08_GERAL);

                    /*" -7015- WHEN '09005' */
                    break;
                case "09005":

                /*" -7016- WHEN '09011' */
                case "09011":

                    /*" -7017- WHEN '09012' */
                    break;
                case "09012":

                /*" -7018- WHEN '09013' */
                case "09013":

                    /*" -7019- WHEN '09024' */
                    break;
                case "09024":

                    /*" -7020- MOVE 'ATR_CNOI' TO ATTR08-GERAL */
                    _.Move("ATR_CNOI", W_REGISTRO_SIAS_GERAL.ATTR08_GERAL);

                    /*" -7021- MOVE ALL 'X' TO ATTRVAL08-GERAL */
                    _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL08_GERAL);

                    /*" -7023- END-EVALUATE. */
                    break;
            }


            /*" -7024- EVALUATE WS-COD-EVENTO-NUM */
            switch (FILLER_18.WS_COD_EVENTO_NUM.Value.Trim())
            {

                /*" -7025- WHEN '09002' */
                case "09002":

                    /*" -7026- WHEN '09006' */
                    break;
                case "09006":

                /*" -7027- WHEN '09007' */
                case "09007":

                    /*" -7028- WHEN '09009' */
                    break;
                case "09009":

                /*" -7029- WHEN '09022' */
                case "09022":

                    /*" -7030- MOVE 'ATR_IRIQ' TO ATTR09-GERAL */
                    _.Move("ATR_IRIQ", W_REGISTRO_SIAS_GERAL.ATTR09_GERAL);

                    /*" -7031- MOVE ALL 'X' TO ATTRVAL09-GERAL */
                    _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL09_GERAL);

                    /*" -7032- WHEN '09005' */
                    break;
                case "09005":

                /*" -7033- WHEN '09011' */
                case "09011":

                    /*" -7034- WHEN '09012' */
                    break;
                case "09012":

                /*" -7035- WHEN '09013' */
                case "09013":

                    /*" -7036- WHEN '09024' */
                    break;
                case "09024":

                    /*" -7037- MOVE 'ATR_CNOC' TO ATTR09-GERAL */
                    _.Move("ATR_CNOC", W_REGISTRO_SIAS_GERAL.ATTR09_GERAL);

                    /*" -7038- MOVE ALL 'X' TO ATTRVAL09-GERAL */
                    _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL09_GERAL);

                    /*" -7039- WHEN '09003' */
                    break;
                case "09003":

                /*" -7040- WHEN '09004' */
                case "09004":

                    /*" -7041- WHEN '09008' */
                    break;
                case "09008":

                /*" -7042- WHEN '09015' */
                case "09015":

                    /*" -7043- WHEN '09025' */
                    break;
                case "09025":

                /*" -7044- CONTINUE */

                /*" -7045- WHEN '09001' */
                case "09001":

                    /*" -7046- WHEN '09010' */
                    break;
                case "09010":

                /*" -7047- WHEN '09014' */
                case "09014":

                    /*" -7048- WHEN '09023' */
                    break;
                case "09023":

                    /*" -7049- CONTINUE */

                    /*" -7052- END-EVALUATE. */
                    break;
            }


            /*" -7053- EVALUATE WS-COD-EVENTO-NUM */
            switch (FILLER_18.WS_COD_EVENTO_NUM.Value.Trim())
            {

                /*" -7054- WHEN '09001' */
                case "09001":

                    /*" -7055- WHEN '09010' */
                    break;
                case "09010":

                /*" -7056- WHEN '09014' */
                case "09014":

                    /*" -7057- WHEN '09023' */
                    break;
                case "09023":

                /*" -7058- CONTINUE */

                /*" -7059- WHEN '09002' */
                case "09002":

                    /*" -7060- WHEN '09006' */
                    break;
                case "09006":

                /*" -7061- WHEN '09007' */
                case "09007":

                    /*" -7062- WHEN '09009' */
                    break;
                case "09009":

                /*" -7063- WHEN '09022' */
                case "09022":

                    /*" -7064- MOVE 'ATR_CNPJ' TO ATTR10-GERAL */
                    _.Move("ATR_CNPJ", W_REGISTRO_SIAS_GERAL.ATTR10_GERAL);

                    /*" -7065- MOVE ALL 'X' TO ATTRVAL10-GERAL */
                    _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL10_GERAL);

                    /*" -7066- WHEN '09005' */
                    break;
                case "09005":

                /*" -7067- WHEN '09011' */
                case "09011":

                    /*" -7068- WHEN '09012' */
                    break;
                case "09012":

                /*" -7069- WHEN '09013' */
                case "09013":

                    /*" -7070- WHEN '09024' */
                    break;
                case "09024":

                    /*" -7071- MOVE 'ATR_DTNF' TO ATTR10-GERAL */
                    _.Move("ATR_DTNF", W_REGISTRO_SIAS_GERAL.ATTR10_GERAL);

                    /*" -7072- MOVE ALL 'X' TO ATTRVAL10-GERAL */
                    _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL10_GERAL);

                    /*" -7073- WHEN '09003' */
                    break;
                case "09003":

                /*" -7074- WHEN '09004' */
                case "09004":

                    /*" -7075- WHEN '09008' */
                    break;
                case "09008":

                /*" -7076- WHEN '09015' */
                case "09015":

                    /*" -7077- WHEN '09025' */
                    break;
                case "09025":

                    /*" -7078- CONTINUE */

                    /*" -7081- END-EVALUATE. */
                    break;
            }


            /*" -7082- EVALUATE WS-COD-EVENTO-NUM */
            switch (FILLER_18.WS_COD_EVENTO_NUM.Value.Trim())
            {

                /*" -7083- WHEN '09001' */
                case "09001":

                    /*" -7084- WHEN '09002' */
                    break;
                case "09002":

                /*" -7085- WHEN '09006' */
                case "09006":

                    /*" -7086- WHEN '09007' */
                    break;
                case "09007":

                /*" -7087- WHEN '09009' */
                case "09009":

                    /*" -7088- WHEN '09010' */
                    break;
                case "09010":

                /*" -7089- WHEN '09014' */
                case "09014":

                    /*" -7090- WHEN '09022' */
                    break;
                case "09022":

                /*" -7091- WHEN '09023' */
                case "09023":

                    /*" -7092- MOVE 'ATR_CNOI' TO ATTR11-GERAL */
                    _.Move("ATR_CNOI", W_REGISTRO_SIAS_GERAL.ATTR11_GERAL);

                    /*" -7093- MOVE ALL 'X' TO ATTRVAL11-GERAL */
                    _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL11_GERAL);

                    /*" -7094- WHEN '09005' */
                    break;
                case "09005":

                /*" -7095- WHEN '09011' */
                case "09011":

                    /*" -7096- WHEN '09012' */
                    break;
                case "09012":

                /*" -7097- WHEN '09013' */
                case "09013":

                    /*" -7098- WHEN '09024' */
                    break;
                case "09024":

                    /*" -7099- MOVE 'ATR_NATR' TO ATTR11-GERAL */
                    _.Move("ATR_NATR", W_REGISTRO_SIAS_GERAL.ATTR11_GERAL);

                    /*" -7100- IF SINISCAP-COD-NAT-RENDIMENTO NOT EQUAL ZEROS */

                    if (SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_NAT_RENDIMENTO != 00)
                    {

                        /*" -7102- MOVE SINISCAP-COD-NAT-RENDIMENTO TO ATTRVAL11-GERAL */
                        _.Move(SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_NAT_RENDIMENTO, W_REGISTRO_SIAS_GERAL.ATTRVAL11_GERAL);

                        /*" -7103- ELSE */
                    }
                    else
                    {


                        /*" -7104- MOVE ALL 'X' TO ATTRVAL11-GERAL */
                        _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL11_GERAL);

                        /*" -7105- END-IF */
                    }


                    /*" -7106- WHEN '09003' */
                    break;
                case "09003":

                /*" -7107- WHEN '09004' */
                case "09004":

                    /*" -7108- WHEN '09008' */
                    break;
                case "09008":

                /*" -7109- WHEN '09015' */
                case "09015":

                    /*" -7110- WHEN '09025' */
                    break;
                case "09025":

                    /*" -7111- CONTINUE */

                    /*" -7114- END-EVALUATE. */
                    break;
            }


            /*" -7115- EVALUATE WS-COD-EVENTO-NUM */
            switch (FILLER_18.WS_COD_EVENTO_NUM.Value.Trim())
            {

                /*" -7116- WHEN '09001' */
                case "09001":

                    /*" -7117- WHEN '09002' */
                    break;
                case "09002":

                /*" -7118- WHEN '09006' */
                case "09006":

                    /*" -7119- WHEN '09007' */
                    break;
                case "09007":

                /*" -7120- WHEN '09009' */
                case "09009":

                    /*" -7121- WHEN '09010' */
                    break;
                case "09010":

                /*" -7122- WHEN '09014' */
                case "09014":

                    /*" -7123- WHEN '09022' */
                    break;
                case "09022":

                /*" -7124- WHEN '09023' */
                case "09023":

                    /*" -7125- MOVE 'ATR_CNOC' TO ATTR36-GERAL */
                    _.Move("ATR_CNOC", W_REGISTRO_SIAS_GERAL.ATTR36_GERAL);

                    /*" -7126- MOVE ALL 'X' TO ATTRVAL36-GERAL */
                    _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL36_GERAL);

                    /*" -7127- WHEN '09003' */
                    break;
                case "09003":

                /*" -7128- WHEN '09004' */
                case "09004":

                    /*" -7129- WHEN '09008' */
                    break;
                case "09008":

                /*" -7130- WHEN '09015' */
                case "09015":

                    /*" -7131- WHEN '09025' */
                    break;
                case "09025":

                    /*" -7132- MOVE 'ATR_IRIQ' TO ATTR36-GERAL */
                    _.Move("ATR_IRIQ", W_REGISTRO_SIAS_GERAL.ATTR36_GERAL);

                    /*" -7133- MOVE ALL 'X' TO ATTRVAL36-GERAL */
                    _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL36_GERAL);

                    /*" -7134- WHEN '09005' */
                    break;
                case "09005":

                /*" -7135- WHEN '09011' */
                case "09011":

                    /*" -7136- WHEN '09012' */
                    break;
                case "09012":

                /*" -7137- WHEN '09013' */
                case "09013":

                    /*" -7138- WHEN '09024' */
                    break;
                case "09024":

                    /*" -7139- MOVE 'ATR_PJDT' TO ATTR36-GERAL */
                    _.Move("ATR_PJDT", W_REGISTRO_SIAS_GERAL.ATTR36_GERAL);

                    /*" -7140- MOVE ALL 'X' TO ATTRVAL36-GERAL */
                    _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL36_GERAL);

                    /*" -7144- END-EVALUATE. */
                    break;
            }


            /*" -7145- EVALUATE WS-COD-EVENTO-NUM */
            switch (FILLER_18.WS_COD_EVENTO_NUM.Value.Trim())
            {

                /*" -7146- WHEN '09001' */
                case "09001":

                    /*" -7147- WHEN '09002' */
                    break;
                case "09002":

                /*" -7148- WHEN '09006' */
                case "09006":

                    /*" -7149- WHEN '09007' */
                    break;
                case "09007":

                /*" -7150- WHEN '09009' */
                case "09009":

                    /*" -7151- WHEN '09010' */
                    break;
                case "09010":

                /*" -7152- WHEN '09014' */
                case "09014":

                    /*" -7153- WHEN '09022' */
                    break;
                case "09022":

                /*" -7154- WHEN '09023' */
                case "09023":

                    /*" -7155- MOVE 'ATR_DTNF' TO ATTR37-GERAL */
                    _.Move("ATR_DTNF", W_REGISTRO_SIAS_GERAL.ATTR37_GERAL);

                    /*" -7156- MOVE ALL 'X' TO ATTRVAL37-GERAL */
                    _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL37_GERAL);

                    /*" -7157- WHEN '09003' */
                    break;
                case "09003":

                /*" -7158- WHEN '09004' */
                case "09004":

                    /*" -7159- WHEN '09008' */
                    break;
                case "09008":

                /*" -7160- WHEN '09015' */
                case "09015":

                    /*" -7161- WHEN '09025' */
                    break;
                case "09025":

                    /*" -7162- MOVE 'ATR_CNPJ' TO ATTR37-GERAL */
                    _.Move("ATR_CNPJ", W_REGISTRO_SIAS_GERAL.ATTR37_GERAL);

                    /*" -7163- MOVE ALL 'X' TO ATTRVAL37-GERAL */
                    _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL37_GERAL);

                    /*" -7164- WHEN '09005' */
                    break;
                case "09005":

                /*" -7165- WHEN '09011' */
                case "09011":

                    /*" -7166- WHEN '09012' */
                    break;
                case "09012":

                /*" -7167- WHEN '09013' */
                case "09013":

                    /*" -7168- WHEN '09024' */
                    break;
                case "09024":

                    /*" -7169- MOVE 'ATR_TSER' TO ATTR37-GERAL */
                    _.Move("ATR_TSER", W_REGISTRO_SIAS_GERAL.ATTR37_GERAL);

                    /*" -7170- MOVE ALL 'X' TO ATTRVAL37-GERAL */
                    _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL37_GERAL);

                    /*" -7173- END-EVALUATE. */
                    break;
            }


            /*" -7174- EVALUATE WS-COD-EVENTO-NUM */
            switch (FILLER_18.WS_COD_EVENTO_NUM.Value.Trim())
            {

                /*" -7175- WHEN '09001' */
                case "09001":

                    /*" -7176- WHEN '09002' */
                    break;
                case "09002":

                /*" -7177- WHEN '09006' */
                case "09006":

                    /*" -7178- WHEN '09007' */
                    break;
                case "09007":

                /*" -7179- WHEN '09009' */
                case "09009":

                    /*" -7180- WHEN '09010' */
                    break;
                case "09010":

                /*" -7181- WHEN '09014' */
                case "09014":

                    /*" -7182- WHEN '09022' */
                    break;
                case "09022":

                /*" -7183- WHEN '09023' */
                case "09023":

                    /*" -7184- MOVE 'ATR_NATR' TO ATTR38-GERAL */
                    _.Move("ATR_NATR", W_REGISTRO_SIAS_GERAL.ATTR38_GERAL);

                    /*" -7185- IF SINISCAP-COD-NAT-RENDIMENTO NOT EQUAL ZEROS */

                    if (SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_NAT_RENDIMENTO != 00)
                    {

                        /*" -7187- MOVE SINISCAP-COD-NAT-RENDIMENTO TO ATTRVAL38-GERAL */
                        _.Move(SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_NAT_RENDIMENTO, W_REGISTRO_SIAS_GERAL.ATTRVAL38_GERAL);

                        /*" -7188- ELSE */
                    }
                    else
                    {


                        /*" -7189- MOVE ALL 'X' TO ATTRVAL38-GERAL */
                        _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL38_GERAL);

                        /*" -7190- END-IF */
                    }


                    /*" -7191- WHEN '09003' */
                    break;
                case "09003":

                /*" -7192- WHEN '09004' */
                case "09004":

                    /*" -7193- WHEN '09008' */
                    break;
                case "09008":

                /*" -7194- WHEN '09015' */
                case "09015":

                    /*" -7195- WHEN '09025' */
                    break;
                case "09025":

                    /*" -7196- MOVE 'ATR_CNOI' TO ATTR38-GERAL */
                    _.Move("ATR_CNOI", W_REGISTRO_SIAS_GERAL.ATTR38_GERAL);

                    /*" -7197- MOVE ALL 'X' TO ATTRVAL38-GERAL */
                    _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL38_GERAL);

                    /*" -7198- WHEN '09005' */
                    break;
                case "09005":

                /*" -7199- WHEN '09011' */
                case "09011":

                    /*" -7200- WHEN '09012' */
                    break;
                case "09012":

                /*" -7201- WHEN '09013' */
                case "09013":

                    /*" -7202- WHEN '09024' */
                    break;
                case "09024":

                    /*" -7203- MOVE 'ATR_MEAT' TO ATTR38-GERAL */
                    _.Move("ATR_MEAT", W_REGISTRO_SIAS_GERAL.ATTR38_GERAL);

                    /*" -7204- MOVE ALL 'X' TO ATTRVAL38-GERAL */
                    _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL38_GERAL);

                    /*" -7207- END-EVALUATE. */
                    break;
            }


            /*" -7208- EVALUATE WS-COD-EVENTO-NUM */
            switch (FILLER_18.WS_COD_EVENTO_NUM.Value.Trim())
            {

                /*" -7209- WHEN '09001' */
                case "09001":

                    /*" -7210- WHEN '09002' */
                    break;
                case "09002":

                /*" -7211- WHEN '09006' */
                case "09006":

                    /*" -7212- WHEN '09007' */
                    break;
                case "09007":

                /*" -7213- WHEN '09009' */
                case "09009":

                    /*" -7214- WHEN '09010' */
                    break;
                case "09010":

                /*" -7215- WHEN '09014' */
                case "09014":

                    /*" -7216- WHEN '09022' */
                    break;
                case "09022":

                /*" -7217- WHEN '09023' */
                case "09023":

                    /*" -7218- MOVE 'ATR_PJDT' TO ATTR39-GERAL */
                    _.Move("ATR_PJDT", W_REGISTRO_SIAS_GERAL.ATTR39_GERAL);

                    /*" -7219- MOVE ALL 'X' TO ATTRVAL39-GERAL */
                    _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL39_GERAL);

                    /*" -7220- WHEN '09003' */
                    break;
                case "09003":

                /*" -7221- WHEN '09004' */
                case "09004":

                    /*" -7222- WHEN '09008' */
                    break;
                case "09008":

                /*" -7223- WHEN '09015' */
                case "09015":

                    /*" -7224- WHEN '09025' */
                    break;
                case "09025":

                    /*" -7225- MOVE 'ATR_CNOC' TO ATTR39-GERAL */
                    _.Move("ATR_CNOC", W_REGISTRO_SIAS_GERAL.ATTR39_GERAL);

                    /*" -7226- MOVE ALL 'X' TO ATTRVAL39-GERAL */
                    _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL39_GERAL);

                    /*" -7227- WHEN '09005' */
                    break;
                case "09005":

                /*" -7228- WHEN '09011' */
                case "09011":

                    /*" -7229- WHEN '09012' */
                    break;
                case "09012":

                /*" -7230- WHEN '09013' */
                case "09013":

                    /*" -7231- WHEN '09024' */
                    break;
                case "09024":

                    /*" -7232- MOVE 'ATR_VRNF' TO ATTR39-GERAL */
                    _.Move("ATR_VRNF", W_REGISTRO_SIAS_GERAL.ATTR39_GERAL);

                    /*" -7233- MOVE ALL 'X' TO ATTRVAL39-GERAL */
                    _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL39_GERAL);

                    /*" -7236- END-EVALUATE. */
                    break;
            }


            /*" -7237- EVALUATE WS-COD-EVENTO-NUM */
            switch (FILLER_18.WS_COD_EVENTO_NUM.Value.Trim())
            {

                /*" -7238- WHEN '09001' */
                case "09001":

                    /*" -7239- WHEN '09002' */
                    break;
                case "09002":

                /*" -7240- WHEN '09006' */
                case "09006":

                    /*" -7241- WHEN '09007' */
                    break;
                case "09007":

                /*" -7242- WHEN '09009' */
                case "09009":

                    /*" -7243- WHEN '09010' */
                    break;
                case "09010":

                /*" -7244- WHEN '09014' */
                case "09014":

                    /*" -7245- WHEN '09022' */
                    break;
                case "09022":

                /*" -7246- WHEN '09023' */
                case "09023":

                    /*" -7247- MOVE 'ATR_TSER' TO ATTR40-GERAL */
                    _.Move("ATR_TSER", W_REGISTRO_SIAS_GERAL.ATTR40_GERAL);

                    /*" -7248- MOVE ALL 'X' TO ATTRVAL40-GERAL */
                    _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL40_GERAL);

                    /*" -7249- WHEN '09003' */
                    break;
                case "09003":

                /*" -7250- WHEN '09004' */
                case "09004":

                    /*" -7251- WHEN '09008' */
                    break;
                case "09008":

                /*" -7252- WHEN '09015' */
                case "09015":

                    /*" -7253- WHEN '09025' */
                    break;
                case "09025":

                    /*" -7254- MOVE 'ATR_DTNF' TO ATTR40-GERAL */
                    _.Move("ATR_DTNF", W_REGISTRO_SIAS_GERAL.ATTR40_GERAL);

                    /*" -7255- MOVE ALL 'X' TO ATTRVAL40-GERAL */
                    _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL40_GERAL);

                    /*" -7256- WHEN '09005' */
                    break;
                case "09005":

                /*" -7257- WHEN '09011' */
                case "09011":

                    /*" -7258- WHEN '09012' */
                    break;
                case "09012":

                /*" -7259- WHEN '09013' */
                case "09013":

                    /*" -7260- WHEN '09024' */
                    break;
                case "09024":

                    /*" -7261- MOVE 'ATR_VREP' TO ATTR40-GERAL */
                    _.Move("ATR_VREP", W_REGISTRO_SIAS_GERAL.ATTR40_GERAL);

                    /*" -7262- MOVE ALL 'X' TO ATTRVAL40-GERAL */
                    _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL40_GERAL);

                    /*" -7265- END-EVALUATE. */
                    break;
            }


            /*" -7266- EVALUATE WS-COD-EVENTO-NUM */
            switch (FILLER_18.WS_COD_EVENTO_NUM.Value.Trim())
            {

                /*" -7267- WHEN '09001' */
                case "09001":

                    /*" -7268- WHEN '09002' */
                    break;
                case "09002":

                /*" -7269- WHEN '09006' */
                case "09006":

                    /*" -7270- WHEN '09007' */
                    break;
                case "09007":

                /*" -7271- WHEN '09009' */
                case "09009":

                    /*" -7272- WHEN '09010' */
                    break;
                case "09010":

                /*" -7273- WHEN '09014' */
                case "09014":

                    /*" -7274- WHEN '09022' */
                    break;
                case "09022":

                /*" -7275- WHEN '09023' */
                case "09023":

                    /*" -7276- MOVE 'ATR_MEAT' TO ATTR41-GERAL */
                    _.Move("ATR_MEAT", W_REGISTRO_SIAS_GERAL.ATTR41_GERAL);

                    /*" -7277- MOVE ALL 'X' TO ATTRVAL41-GERAL */
                    _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL41_GERAL);

                    /*" -7278- WHEN '09003' */
                    break;
                case "09003":

                /*" -7279- WHEN '09004' */
                case "09004":

                    /*" -7280- WHEN '09008' */
                    break;
                case "09008":

                /*" -7281- WHEN '09015' */
                case "09015":

                    /*" -7282- WHEN '09025' */
                    break;
                case "09025":

                    /*" -7283- MOVE 'ATR_NATR' TO ATTR41-GERAL */
                    _.Move("ATR_NATR", W_REGISTRO_SIAS_GERAL.ATTR41_GERAL);

                    /*" -7284- IF SINISCAP-COD-NAT-RENDIMENTO NOT EQUAL ZEROS */

                    if (SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_NAT_RENDIMENTO != 00)
                    {

                        /*" -7286- MOVE SINISCAP-COD-NAT-RENDIMENTO TO ATTRVAL41-GERAL */
                        _.Move(SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_NAT_RENDIMENTO, W_REGISTRO_SIAS_GERAL.ATTRVAL41_GERAL);

                        /*" -7287- ELSE */
                    }
                    else
                    {


                        /*" -7288- MOVE ALL 'X' TO ATTRVAL41-GERAL */
                        _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL41_GERAL);

                        /*" -7289- END-IF */
                    }


                    /*" -7290- WHEN '09005' */
                    break;
                case "09005":

                /*" -7291- WHEN '09011' */
                case "09011":

                    /*" -7292- WHEN '09012' */
                    break;
                case "09012":

                /*" -7293- WHEN '09013' */
                case "09013":

                    /*" -7294- WHEN '09024' */
                    break;
                case "09024":

                    /*" -7295- MOVE 'ATR_QIPL' TO ATTR41-GERAL */
                    _.Move("ATR_QIPL", W_REGISTRO_SIAS_GERAL.ATTR41_GERAL);

                    /*" -7296- MOVE ALL 'X' TO ATTRVAL41-GERAL */
                    _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL41_GERAL);

                    /*" -7299- END-EVALUATE. */
                    break;
            }


            /*" -7300- EVALUATE WS-COD-EVENTO-NUM */
            switch (FILLER_18.WS_COD_EVENTO_NUM.Value.Trim())
            {

                /*" -7301- WHEN '09001' */
                case "09001":

                    /*" -7302- WHEN '09002' */
                    break;
                case "09002":

                /*" -7303- WHEN '09006' */
                case "09006":

                    /*" -7304- WHEN '09007' */
                    break;
                case "09007":

                /*" -7305- WHEN '09009' */
                case "09009":

                    /*" -7306- WHEN '09010' */
                    break;
                case "09010":

                /*" -7307- WHEN '09014' */
                case "09014":

                    /*" -7308- WHEN '09022' */
                    break;
                case "09022":

                /*" -7309- WHEN '09023' */
                case "09023":

                    /*" -7310- MOVE 'ATR_VRNF' TO ATTR42-GERAL */
                    _.Move("ATR_VRNF", W_REGISTRO_SIAS_GERAL.ATTR42_GERAL);

                    /*" -7311- MOVE ALL 'X' TO ATTRVAL42-GERAL */
                    _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL42_GERAL);

                    /*" -7312- WHEN '09003' */
                    break;
                case "09003":

                /*" -7313- WHEN '09004' */
                case "09004":

                    /*" -7314- WHEN '09008' */
                    break;
                case "09008":

                /*" -7315- WHEN '09015' */
                case "09015":

                    /*" -7316- WHEN '09025' */
                    break;
                case "09025":

                    /*" -7317- MOVE 'ATR_PJDT' TO ATTR42-GERAL */
                    _.Move("ATR_PJDT", W_REGISTRO_SIAS_GERAL.ATTR42_GERAL);

                    /*" -7318- MOVE ALL 'X' TO ATTRVAL42-GERAL */
                    _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL42_GERAL);

                    /*" -7319- WHEN '09005' */
                    break;
                case "09005":

                /*" -7320- WHEN '09011' */
                case "09011":

                    /*" -7321- WHEN '09012' */
                    break;
                case "09012":

                /*" -7322- WHEN '09013' */
                case "09013":

                    /*" -7323- WHEN '09024' */
                    break;
                case "09024":

                    /*" -7324- MOVE SPACES TO ATTR42-GERAL ATTRVAL42-GERAL */
                    _.Move("", W_REGISTRO_SIAS_GERAL.ATTR42_GERAL, W_REGISTRO_SIAS_GERAL.ATTRVAL42_GERAL);

                    /*" -7327- END-EVALUATE. */
                    break;
            }


            /*" -7328- EVALUATE WS-COD-EVENTO-NUM */
            switch (FILLER_18.WS_COD_EVENTO_NUM.Value.Trim())
            {

                /*" -7329- WHEN '09001' */
                case "09001":

                    /*" -7330- WHEN '09002' */
                    break;
                case "09002":

                /*" -7331- WHEN '09006' */
                case "09006":

                    /*" -7332- WHEN '09007' */
                    break;
                case "09007":

                /*" -7333- WHEN '09009' */
                case "09009":

                    /*" -7334- WHEN '09010' */
                    break;
                case "09010":

                /*" -7335- WHEN '09014' */
                case "09014":

                    /*" -7336- WHEN '09022' */
                    break;
                case "09022":

                /*" -7337- WHEN '09023' */
                case "09023":

                    /*" -7338- MOVE 'ATR_VREP' TO ATTR43-GERAL */
                    _.Move("ATR_VREP", W_REGISTRO_SIAS_GERAL.ATTR43_GERAL);

                    /*" -7339- MOVE ALL 'X' TO ATTRVAL43-GERAL */
                    _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL43_GERAL);

                    /*" -7340- WHEN '09003' */
                    break;
                case "09003":

                /*" -7341- WHEN '09004' */
                case "09004":

                    /*" -7342- WHEN '09008' */
                    break;
                case "09008":

                /*" -7343- WHEN '09015' */
                case "09015":

                    /*" -7344- WHEN '09025' */
                    break;
                case "09025":

                    /*" -7345- MOVE 'ATR_TSER' TO ATTR43-GERAL */
                    _.Move("ATR_TSER", W_REGISTRO_SIAS_GERAL.ATTR43_GERAL);

                    /*" -7346- MOVE ALL 'X' TO ATTRVAL43-GERAL */
                    _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL43_GERAL);

                    /*" -7347- WHEN '09005' */
                    break;
                case "09005":

                /*" -7348- WHEN '09011' */
                case "09011":

                    /*" -7349- WHEN '09012' */
                    break;
                case "09012":

                /*" -7350- WHEN '09013' */
                case "09013":

                    /*" -7351- WHEN '09024' */
                    break;
                case "09024":

                    /*" -7352- MOVE SPACES TO ATTR43-GERAL ATTRVAL43-GERAL */
                    _.Move("", W_REGISTRO_SIAS_GERAL.ATTR43_GERAL, W_REGISTRO_SIAS_GERAL.ATTRVAL43_GERAL);

                    /*" -7355- END-EVALUATE. */
                    break;
            }


            /*" -7356- EVALUATE WS-COD-EVENTO-NUM */
            switch (FILLER_18.WS_COD_EVENTO_NUM.Value.Trim())
            {

                /*" -7357- WHEN '09001' */
                case "09001":

                    /*" -7358- WHEN '09002' */
                    break;
                case "09002":

                /*" -7359- WHEN '09006' */
                case "09006":

                    /*" -7360- WHEN '09007' */
                    break;
                case "09007":

                /*" -7361- WHEN '09009' */
                case "09009":

                    /*" -7362- WHEN '09010' */
                    break;
                case "09010":

                /*" -7363- WHEN '09014' */
                case "09014":

                    /*" -7364- WHEN '09022' */
                    break;
                case "09022":

                /*" -7365- WHEN '09023' */
                case "09023":

                    /*" -7366- MOVE 'ATR_QIPL' TO ATTR44-GERAL */
                    _.Move("ATR_QIPL", W_REGISTRO_SIAS_GERAL.ATTR44_GERAL);

                    /*" -7367- MOVE ALL 'X' TO ATTRVAL44-GERAL */
                    _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL44_GERAL);

                    /*" -7368- WHEN '09003' */
                    break;
                case "09003":

                /*" -7369- WHEN '09004' */
                case "09004":

                    /*" -7370- WHEN '09008' */
                    break;
                case "09008":

                /*" -7371- WHEN '09015' */
                case "09015":

                    /*" -7372- WHEN '09025' */
                    break;
                case "09025":

                    /*" -7373- MOVE 'ATR_MEAT' TO ATTR44-GERAL */
                    _.Move("ATR_MEAT", W_REGISTRO_SIAS_GERAL.ATTR44_GERAL);

                    /*" -7374- MOVE ALL 'X' TO ATTRVAL44-GERAL */
                    _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL44_GERAL);

                    /*" -7375- WHEN '09005' */
                    break;
                case "09005":

                /*" -7376- WHEN '09011' */
                case "09011":

                    /*" -7377- WHEN '09012' */
                    break;
                case "09012":

                /*" -7378- WHEN '09013' */
                case "09013":

                    /*" -7379- WHEN '09024' */
                    break;
                case "09024":

                    /*" -7380- MOVE SPACES TO ATTR44-GERAL ATTRVAL44-GERAL */
                    _.Move("", W_REGISTRO_SIAS_GERAL.ATTR44_GERAL, W_REGISTRO_SIAS_GERAL.ATTRVAL44_GERAL);

                    /*" -7383- END-EVALUATE. */
                    break;
            }


            /*" -7384- EVALUATE WS-COD-EVENTO-NUM */
            switch (FILLER_18.WS_COD_EVENTO_NUM.Value.Trim())
            {

                /*" -7385- WHEN '09003' */
                case "09003":

                    /*" -7386- WHEN '09004' */
                    break;
                case "09004":

                /*" -7387- WHEN '09008' */
                case "09008":

                    /*" -7388- WHEN '09015' */
                    break;
                case "09015":

                /*" -7389- WHEN '09025' */
                case "09025":

                    /*" -7390- MOVE 'ATR_VRNF' TO ATTR45-GERAL */
                    _.Move("ATR_VRNF", W_REGISTRO_SIAS_GERAL.ATTR45_GERAL);

                    /*" -7391- MOVE ALL 'X' TO ATTRVAL45-GERAL */
                    _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL45_GERAL);

                    /*" -7392- WHEN '09005' */
                    break;
                case "09005":

                /*" -7393- WHEN '09011' */
                case "09011":

                    /*" -7394- WHEN '09012' */
                    break;
                case "09012":

                /*" -7395- WHEN '09013' */
                case "09013":

                    /*" -7396- WHEN '09024' */
                    break;
                case "09024":

                /*" -7397- WHEN '09022' */
                case "09022":

                    /*" -7398- WHEN '09001' */
                    break;
                case "09001":

                /*" -7399- WHEN '09002' */
                case "09002":

                    /*" -7400- WHEN '09006' */
                    break;
                case "09006":

                /*" -7401- WHEN '09007' */
                case "09007":

                    /*" -7402- WHEN '09009' */
                    break;
                case "09009":

                /*" -7403- WHEN '09010' */
                case "09010":

                    /*" -7404- WHEN '09014' */
                    break;
                case "09014":

                /*" -7405- WHEN '09023' */
                case "09023":

                    /*" -7406- MOVE SPACES TO ATTR45-GERAL ATTRVAL45-GERAL */
                    _.Move("", W_REGISTRO_SIAS_GERAL.ATTR45_GERAL, W_REGISTRO_SIAS_GERAL.ATTRVAL45_GERAL);

                    /*" -7409- END-EVALUATE. */
                    break;
            }


            /*" -7410- EVALUATE WS-COD-EVENTO-NUM */
            switch (FILLER_18.WS_COD_EVENTO_NUM.Value.Trim())
            {

                /*" -7411- WHEN '09003' */
                case "09003":

                    /*" -7412- WHEN '09004' */
                    break;
                case "09004":

                /*" -7413- WHEN '09008' */
                case "09008":

                    /*" -7414- WHEN '09015' */
                    break;
                case "09015":

                /*" -7415- WHEN '09025' */
                case "09025":

                    /*" -7416- MOVE 'ATR_VREP' TO ATTR46-GERAL */
                    _.Move("ATR_VREP", W_REGISTRO_SIAS_GERAL.ATTR46_GERAL);

                    /*" -7417- MOVE ALL 'X' TO ATTRVAL46-GERAL */
                    _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL46_GERAL);

                    /*" -7418- WHEN '09005' */
                    break;
                case "09005":

                /*" -7419- WHEN '09011' */
                case "09011":

                    /*" -7420- WHEN '09012' */
                    break;
                case "09012":

                /*" -7421- WHEN '09013' */
                case "09013":

                    /*" -7422- WHEN '09024' */
                    break;
                case "09024":

                /*" -7423- WHEN '09022' */
                case "09022":

                    /*" -7424- WHEN '09001' */
                    break;
                case "09001":

                /*" -7425- WHEN '09002' */
                case "09002":

                    /*" -7426- WHEN '09006' */
                    break;
                case "09006":

                /*" -7427- WHEN '09007' */
                case "09007":

                    /*" -7428- WHEN '09009' */
                    break;
                case "09009":

                /*" -7429- WHEN '09010' */
                case "09010":

                    /*" -7430- WHEN '09014' */
                    break;
                case "09014":

                /*" -7431- WHEN '09023' */
                case "09023":

                    /*" -7432- MOVE SPACES TO ATTR46-GERAL ATTRVAL46-GERAL */
                    _.Move("", W_REGISTRO_SIAS_GERAL.ATTR46_GERAL, W_REGISTRO_SIAS_GERAL.ATTRVAL46_GERAL);

                    /*" -7435- END-EVALUATE. */
                    break;
            }


            /*" -7436- EVALUATE WS-COD-EVENTO-NUM */
            switch (FILLER_18.WS_COD_EVENTO_NUM.Value.Trim())
            {

                /*" -7437- WHEN '09003' */
                case "09003":

                    /*" -7438- WHEN '09004' */
                    break;
                case "09004":

                /*" -7439- WHEN '09008' */
                case "09008":

                    /*" -7440- WHEN '09015' */
                    break;
                case "09015":

                /*" -7441- WHEN '09025' */
                case "09025":

                    /*" -7442- MOVE 'ATR_QIPL' TO ATTR47-GERAL */
                    _.Move("ATR_QIPL", W_REGISTRO_SIAS_GERAL.ATTR47_GERAL);

                    /*" -7443- MOVE ALL 'X' TO ATTRVAL47-GERAL */
                    _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL47_GERAL);

                    /*" -7444- WHEN '09005' */
                    break;
                case "09005":

                /*" -7445- WHEN '09011' */
                case "09011":

                    /*" -7446- WHEN '09012' */
                    break;
                case "09012":

                /*" -7447- WHEN '09013' */
                case "09013":

                    /*" -7448- WHEN '09024' */
                    break;
                case "09024":

                /*" -7449- WHEN '09022' */
                case "09022":

                    /*" -7450- WHEN '09001' */
                    break;
                case "09001":

                /*" -7451- WHEN '09002' */
                case "09002":

                    /*" -7452- WHEN '09006' */
                    break;
                case "09006":

                /*" -7453- WHEN '09007' */
                case "09007":

                    /*" -7454- WHEN '09009' */
                    break;
                case "09009":

                /*" -7455- WHEN '09010' */
                case "09010":

                    /*" -7456- WHEN '09014' */
                    break;
                case "09014":

                /*" -7457- WHEN '09023' */
                case "09023":

                    /*" -7458- MOVE SPACES TO ATTR47-GERAL ATTRVAL47-GERAL */
                    _.Move("", W_REGISTRO_SIAS_GERAL.ATTR47_GERAL, W_REGISTRO_SIAS_GERAL.ATTRVAL47_GERAL);

                    /*" -7461- END-EVALUATE. */
                    break;
            }


            /*" -7462- MOVE 'CV_IRFAB' TO COD04-GERAL. */
            _.Move("CV_IRFAB", W_REGISTRO_SIAS_GERAL.COD04_GERAL);

            /*" -7465- MOVE '0,00' TO VALO04-GERAL. */
            _.Move("0,00", W_REGISTRO_SIAS_GERAL.VALO04_GERAL);

            /*" -7467- MOVE 'CV_IRFAR' TO COD05-GERAL. */
            _.Move("CV_IRFAR", W_REGISTRO_SIAS_GERAL.COD05_GERAL);

            /*" -7469- MOVE '0,00' TO VALO05-GERAL. */
            _.Move("0,00", W_REGISTRO_SIAS_GERAL.VALO05_GERAL);

            /*" -7470- MOVE 'CV_INPBS' TO COD020-GERAL. */
            _.Move("CV_INPBS", W_REGISTRO_SIAS_GERAL.COD020_GERAL);

            /*" -7470- MOVE '0,00' TO VALO020-GERAL. */
            _.Move("0,00", W_REGISTRO_SIAS_GERAL.VALO020_GERAL);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R19500_EXIT*/

        [StopWatch]
        /*" C0010-CHAMA-SISAP15B */
        private void C0010_CHAMA_SISAP15B(bool isPerform = false)
        {
            /*" -7478- MOVE 'S201' TO ORIG-GERAL */
            _.Move("S201", W_REGISTRO_SIAS_GERAL.ORIG_GERAL);

            /*" -7479- MOVE 'CA' TO W-LOTE-SIGLA-MODULO */
            _.Move("CA", AREA_DE_WORK.W_LOTE.W_LOTE_SIGLA_MODULO);

            /*" -7480- MOVE LK-SAP-NUM-APOLICE TO P15B-SAP-NUM-APOLICE */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_NUM_APOLICE, REGISTRO_LINKAGE_SAP_P15B.P15B_SAP_NUM_APOLICE);

            /*" -7481- MOVE LK-SAP-NUM-ENDOSSO TO P15B-SAP-NUM-ENDOSSO */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_NUM_ENDOSSO, REGISTRO_LINKAGE_SAP_P15B.P15B_SAP_NUM_ENDOSSO);

            /*" -7482- MOVE LK-SAP-NUM-PARCELA TO P15B-SAP-NUM-PARCELA */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_NUM_PARCELA, REGISTRO_LINKAGE_SAP_P15B.P15B_SAP_NUM_PARCELA);

            /*" -7483- MOVE LK-SAP-COD-CONVENIO TO P15B-SAP-COD-CONVENIO */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_COD_CONVENIO, REGISTRO_LINKAGE_SAP_P15B.P15B_SAP_COD_CONVENIO);

            /*" -7484- MOVE LK-SAP-NSAS TO P15B-SAP-NSAS */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_NSAS, REGISTRO_LINKAGE_SAP_P15B.P15B_SAP_NSAS);

            /*" -7485- MOVE LK-SAP-SITUACAO-COBRANCA TO P15B-SAP-SITUACAO-COBRANCA */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_SITUACAO_COBRANCA, REGISTRO_LINKAGE_SAP_P15B.P15B_SAP_SITUACAO_COBRANCA);

            /*" -7486- MOVE LK-SAP-COD-BANCO TO P15B-SAP-COD-BANCO */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_COD_BANCO, REGISTRO_LINKAGE_SAP_P15B.P15B_SAP_COD_BANCO);

            /*" -7487- MOVE LK-SAP-COD-AGENCIA TO P15B-SAP-COD-AGENCIA */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_COD_AGENCIA, REGISTRO_LINKAGE_SAP_P15B.P15B_SAP_COD_AGENCIA);

            /*" -7488- MOVE LK-SAP-DV-AGENCIA TO P15B-SAP-DV-AGENCIA */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_DV_AGENCIA, REGISTRO_LINKAGE_SAP_P15B.P15B_SAP_DV_AGENCIA);

            /*" -7489- MOVE LK-SAP-OPERACAO-CONTA TO P15B-SAP-OPERACAO-CONTA */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_OPERACAO_CONTA, REGISTRO_LINKAGE_SAP_P15B.P15B_SAP_OPERACAO_CONTA);

            /*" -7490- MOVE LK-SAP-NUM-CONTA TO P15B-SAP-NUM-CONTA */
            _.Move(LK_SAP_NUM_CONTA, REGISTRO_LINKAGE_SAP_P15B.P15B_SAP_NUM_CONTA);

            /*" -7491- MOVE LK-SAP-DV-CONTA TO P15B-SAP-DV-CONTA */
            _.Move(LK_SAP_DV_CONTA, REGISTRO_LINKAGE_SAP_P15B.P15B_SAP_DV_CONTA);

            /*" -7492- MOVE LK-SAP-COD-PROGRAMA TO P15B-SAP-COD-PROGRAMA */
            _.Move(LK_SAP_COD_PROGRAMA, REGISTRO_LINKAGE_SAP_P15B.P15B_SAP_COD_PROGRAMA);

            /*" -7493- MOVE LK-SAP-FAVORECIDO TO P15B-SAP-FAVORECIDO */
            _.Move(LK_SAP_FAVORECIDO, REGISTRO_LINKAGE_SAP_P15B.P15B_SAP_FAVORECIDO);

            /*" -7494- MOVE LK-SAP-DES-LOGRADOURO TO P15B-SAP-DES-LOGRADOURO */
            _.Move(LK_SAP_DES_LOGRADOURO, REGISTRO_LINKAGE_SAP_P15B.P15B_SAP_DES_LOGRADOURO);

            /*" -7495- MOVE LK-SAP-NUM-LOCAL TO P15B-SAP-NUM-LOCAL */
            _.Move(LK_SAP_NUM_LOCAL, REGISTRO_LINKAGE_SAP_P15B.P15B_SAP_NUM_LOCAL);

            /*" -7496- MOVE LK-SAP-DES-COMPLEMENTO TO P15B-SAP-DES-COMPLEMENTO */
            _.Move(LK_SAP_DES_COMPLEMENTO, REGISTRO_LINKAGE_SAP_P15B.P15B_SAP_DES_COMPLEMENTO);

            /*" -7497- MOVE LK-SAP-DES-BAIRRO TO P15B-SAP-DES-BAIRRO */
            _.Move(LK_SAP_DES_BAIRRO, REGISTRO_LINKAGE_SAP_P15B.P15B_SAP_DES_BAIRRO);

            /*" -7498- MOVE LK-SAP-DES-CIDADE TO P15B-SAP-DES-CIDADE */
            _.Move(LK_SAP_DES_CIDADE, REGISTRO_LINKAGE_SAP_P15B.P15B_SAP_DES_CIDADE);

            /*" -7499- MOVE LK-SAP-NUM-CEP TO P15B-SAP-NUM-CEP */
            _.Move(LK_SAP_NUM_CEP, REGISTRO_LINKAGE_SAP_P15B.P15B_SAP_NUM_CEP);

            /*" -7500- MOVE LK-SAP-DES-COMPL-CEP TO P15B-SAP-DES-COMPL-CEP */
            _.Move(LK_SAP_DES_COMPL_CEP, REGISTRO_LINKAGE_SAP_P15B.P15B_SAP_DES_COMPL_CEP);

            /*" -7501- MOVE LK-SAP-DES-SIGLA-UF TO P15B-SAP-DES-SIGLA-UF */
            _.Move(LK_SAP_DES_SIGLA_UF, REGISTRO_LINKAGE_SAP_P15B.P15B_SAP_DES_SIGLA_UF);

            /*" -7502- MOVE LK-SAP-CHR-USO-EMPRESA TO P15B-SAP-CHR-USO-EMPRESA */
            _.Move(LK_SAP_CHR_USO_EMPRESA, REGISTRO_LINKAGE_SAP_P15B.P15B_SAP_CHR_USO_EMPRESA);

            /*" -7504- MOVE LK-SAP-COD-DOCUMENTO-SIACC TO P15B-SAP-COD-DOCUMENTO-SIACC */
            _.Move(LK_SAP_COD_DOCUMENTO_SIACC, REGISTRO_LINKAGE_SAP_P15B.P15B_SAP_COD_DOCUMENTO_SIACC);

            /*" -7505- MOVE LK-SAP-USO-EMPRESA-SIACC TO P15B-SAP-USO-EMPRESA-SIACC */
            _.Move(LK_SAP_USO_EMPRESA_SIACC, REGISTRO_LINKAGE_SAP_P15B.P15B_SAP_USO_EMPRESA_SIACC);

            /*" -7506- MOVE LK-SAP-COD-RETORNO TO P15B-SAP-COD-RETORNO */
            _.Move(LK_SAP_COD_RETORNO, REGISTRO_LINKAGE_SAP_P15B.P15B_SAP_COD_RETORNO);

            /*" -7507- MOVE LK-SAP-MENSAGEM-RETORNO TO P15B-SAP-MENSAGEM-RETORNO */
            _.Move(LK_SAP_MENSAGEM_RETORNO, REGISTRO_LINKAGE_SAP_P15B.P15B_SAP_MENSAGEM_RETORNO);

            /*" -7509- MOVE LK-SAP-REGISTRO TO P15B-SAP-REGISTRO */
            _.Move(LK_SAP_REGISTRO, REGISTRO_LINKAGE_SAP_P15B.P15B_SAP_REGISTRO);

            /*" -7511- CALL 'SISAP15B' USING REGISTRO-LINKAGE-SAP-P15B */
            _.Call("SISAP15B", REGISTRO_LINKAGE_SAP_P15B);

            /*" -7513- MOVE RETURN-CODE TO WS-RETURN-CODE */
            _.Move(RETURN_CODE, AREA_DE_WORK.WS_RETURN_CODE);

            /*" -7514- IF WS-RETURN-CODE NOT = ZEROS */

            if (AREA_DE_WORK.WS_RETURN_CODE != 00)
            {

                /*" -7515- DISPLAY ' ' */
                _.Display($" ");

                /*" -7516- DISPLAY ' ' */
                _.Display($" ");

                /*" -7517- DISPLAY '************************************************' */
                _.Display($"************************************************");

                /*" -7518- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -7519- DISPLAY '*            PROGRAMA - SISAP01B               *' */
                _.Display($"*            PROGRAMA - SISAP01B               *");

                /*" -7520- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -7521- DISPLAY '* ERRO NO CALL DA SUBROTINA SISAP15B           *' */
                _.Display($"* ERRO NO CALL DA SUBROTINA SISAP15B           *");

                /*" -7522- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -7524- DISPLAY '* RETURN-CODE = ' WS-RETURN-CODE '                     *' */

                $"* RETURN-CODE = {AREA_DE_WORK.WS_RETURN_CODE}                     *"
                .Display();

                /*" -7525- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -7526- DISPLAY '************************************************' */
                _.Display($"************************************************");

                /*" -7527- DISPLAY ' ' */
                _.Display($" ");

                /*" -7529- END-IF */
            }


            /*" -7530- IF P15B-SAP-COD-RETORNO NOT = '0' */

            if (REGISTRO_LINKAGE_SAP_P15B.P15B_SAP_COD_RETORNO != "0")
            {

                /*" -7531- DISPLAY ' ' */
                _.Display($" ");

                /*" -7532- DISPLAY ' ' */
                _.Display($" ");

                /*" -7533- DISPLAY '************************************************' */
                _.Display($"************************************************");

                /*" -7534- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -7535- DISPLAY '*            PROGRAMA - SISAP01B               *' */
                _.Display($"*            PROGRAMA - SISAP01B               *");

                /*" -7536- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -7537- DISPLAY '* SUBROTINA SISAP15B RETORNOU COM ERRO         *' */
                _.Display($"* SUBROTINA SISAP15B RETORNOU COM ERRO         *");

                /*" -7538- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -7539- DISPLAY '************************************************' */
                _.Display($"************************************************");

                /*" -7540- DISPLAY ' ' */
                _.Display($" ");

                /*" -7542- DISPLAY '=> P15B-SAP-COD-RETORNO      = ' P15B-SAP-COD-RETORNO */
                _.Display($"=> P15B-SAP-COD-RETORNO      = {REGISTRO_LINKAGE_SAP_P15B.P15B_SAP_COD_RETORNO}");

                /*" -7544- DISPLAY '=> P15B-SAP-MENSAGEM-RETORNO = ' P15B-SAP-MENSAGEM-RETORNO */
                _.Display($"=> P15B-SAP-MENSAGEM-RETORNO = {REGISTRO_LINKAGE_SAP_P15B.P15B_SAP_MENSAGEM_RETORNO}");

                /*" -7545- DISPLAY ' ' */
                _.Display($" ");

                /*" -7547- END-IF */
            }


            /*" -7548- MOVE P15B-SAP-COD-RETORNO TO LK-SAP-COD-RETORNO */
            _.Move(REGISTRO_LINKAGE_SAP_P15B.P15B_SAP_COD_RETORNO, LK_SAP_COD_RETORNO);

            /*" -7549- MOVE P15B-SAP-MENSAGEM-RETORNO TO LK-SAP-MENSAGEM-RETORNO */
            _.Move(REGISTRO_LINKAGE_SAP_P15B.P15B_SAP_MENSAGEM_RETORNO, LK_SAP_MENSAGEM_RETORNO);

            /*" -7551- MOVE P15B-SAP-REGISTRO TO LK-SAP-REGISTRO */
            _.Move(REGISTRO_LINKAGE_SAP_P15B.P15B_SAP_REGISTRO, LK_SAP_REGISTRO);

            /*" -7551- PERFORM C0010_CHAMA_SISAP15B_DB_CLOSE_1 */

            C0010_CHAMA_SISAP15B_DB_CLOSE_1();

            /*" -7553- GO TO RXXXX-ROTINA-RETORNO. */

            RXXXX_ROTINA_RETORNO(); //GOTO
            return;

        }

        [StopWatch]
        /*" C0010-CHAMA-SISAP15B-DB-CLOSE-1 */
        public void C0010_CHAMA_SISAP15B_DB_CLOSE_1()
        {
            /*" -7551- EXEC SQL CLOSE LE_MOVDEBCE END-EXEC */

            LE_MOVDEBCE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: C0010_CHAMA_SISAP15B_EXIT*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO */
        private void R9999_00_ROT_ERRO(bool isPerform = false)
        {
            /*" -7566- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -7568- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -7571- DISPLAY 'SISAP01B - RETORNO PELA ROTINA DE ERRO ' */
            _.Display($"SISAP01B - RETORNO PELA ROTINA DE ERRO ");

            /*" -7571- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -7575- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -7576- MOVE '1' TO LK-SAP-COD-RETORNO. */
            _.Move("1", LK_SAP_COD_RETORNO);

            /*" -7579- MOVE 'PROBLEMA NA SISAP01B - VEJA DISPLAYS' TO LK-SAP-MENSAGEM-RETORNO. */
            _.Move("PROBLEMA NA SISAP01B - VEJA DISPLAYS", LK_SAP_MENSAGEM_RETORNO);

            /*" -7579- GO TO RXXXX-ROTINA-RETORNO. */

            RXXXX_ROTINA_RETORNO(); //GOTO
            return;

        }

        [StopWatch]
        /*" R8888-DISPLAY-FETCH */
        private void R8888_DISPLAY_FETCH(bool isPerform = false)
        {
            /*" -7585- DISPLAY ' => DISPLAY DO FETCH DO DECLARE PRINCIPAL' */
            _.Display($" => DO FETCH DO DECLARE PRINCIPAL");

            /*" -7587- DISPLAY 'W-NOME-QUERY ..................... ' W-NOME-QUERY */
            _.Display($"W-NOME-QUERY ..................... {W_NOME_QUERY}");

            /*" -7589- DISPLAY 'SINISHIS-TIPO-REGISTRO ........... ' SINISHIS-TIPO-REGISTRO */
            _.Display($"SINISHIS-TIPO-REGISTRO ........... {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_TIPO_REGISTRO}");

            /*" -7591- DISPLAY 'W-NOME-TIPO-SEGURO ............... ' W-NOME-TIPO-SEGURO */
            _.Display($"W-NOME-TIPO-SEGURO ............... {W_NOME_TIPO_SEGURO}");

            /*" -7593- DISPLAY 'SINISHIS-NUM-APOL-SINISTRO ....... ' SINISHIS-NUM-APOL-SINISTRO */
            _.Display($"SINISHIS-NUM-APOL-SINISTRO ....... {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

            /*" -7595- DISPLAY 'SINISHIS-OCORR-HISTORICO ......... ' SINISHIS-OCORR-HISTORICO */
            _.Display($"SINISHIS-OCORR-HISTORICO ......... {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}");

            /*" -7597- DISPLAY 'SINISHIS-COD-OPERACAO  ........... ' SINISHIS-COD-OPERACAO */
            _.Display($"SINISHIS-COD-OPERACAO  ........... {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO}");

            /*" -7599- DISPLAY 'SINISHIS-NOME-FAVORECIDO ......... ' SINISHIS-NOME-FAVORECIDO */
            _.Display($"SINISHIS-NOME-FAVORECIDO ......... {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO}");

            /*" -7601- DISPLAY 'GEOPERAC-FUNCAO-OPERACAO ......... ' GEOPERAC-FUNCAO-OPERACAO */
            _.Display($"GEOPERAC-FUNCAO-OPERACAO ......... {GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO}");

            /*" -7603- DISPLAY 'GEOPERAC-DES-OPERACAO  ............ ' GEOPERAC-DES-OPERACAO */
            _.Display($"GEOPERAC-DES-OPERACAO  ............ {GEOPERAC.DCLGE_OPERACAO.GEOPERAC_DES_OPERACAO}");

            /*" -7605- DISPLAY 'W-ANO-OPERACIONAL-MOVIMENTO ....... ' W-ANO-OPERACIONAL-MOVIMENTO */
            _.Display($"W-ANO-OPERACIONAL-MOVIMENTO ....... {W_ANO_OPERACIONAL_MOVIMENTO}");

            /*" -7607- DISPLAY 'W-ANO-CONTABIL-MOVIMENTO  ......... ' W-ANO-CONTABIL-MOVIMENTO */
            _.Display($"W-ANO-CONTABIL-MOVIMENTO  ......... {W_ANO_CONTABIL_MOVIMENTO}");

            /*" -7609- DISPLAY 'SINISHIS-VAL-OPERACAO  ............ ' SINISHIS-VAL-OPERACAO */
            _.Display($"SINISHIS-VAL-OPERACAO  ............ {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO}");

            /*" -7611- DISPLAY 'MOVDEBCE-VLR-CREDITO  ............. ' MOVDEBCE-VLR-CREDITO */
            _.Display($"MOVDEBCE-VLR-CREDITO  ............. {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_CREDITO}");

            /*" -7613- DISPLAY 'MOVDEBCE-VALOR-DEBITO  ............ ' MOVDEBCE-VALOR-DEBITO */
            _.Display($"MOVDEBCE-VALOR-DEBITO  ............ {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO}");

            /*" -7615- DISPLAY 'SINISHIS-DATA-MOVIMENTO  .......... ' SINISHIS-DATA-MOVIMENTO */
            _.Display($"SINISHIS-DATA-MOVIMENTO  .......... {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO}");

            /*" -7617- DISPLAY 'SINISHIS-COD-PREST-SERVICO ........ ' SINISHIS-COD-PREST-SERVICO */
            _.Display($"SINISHIS-COD-PREST-SERVICO ........ {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO}");

            /*" -7619- DISPLAY 'SINISHIS-SIT-CONTABIL  ............ ' SINISHIS-SIT-CONTABIL */
            _.Display($"SINISHIS-SIT-CONTABIL  ............ {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL}");

            /*" -7621- DISPLAY 'W-NOME-FORMA-PAGAMENTO  ............ ' W-NOME-FORMA-PAGAMENTO */
            _.Display($"W-NOME-FORMA-PAGAMENTO  ............ {W_NOME_FORMA_PAGAMENTO}");

            /*" -7623- DISPLAY 'SINISHIS-NOM-PROGRAMA  ............. ' SINISHIS-NOM-PROGRAMA */
            _.Display($"SINISHIS-NOM-PROGRAMA  ............. {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOM_PROGRAMA}");

            /*" -7625- DISPLAY 'SINISMES-RAMO  ..................... ' SINISMES-RAMO */
            _.Display($"SINISMES-RAMO  ..................... {SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO}");

            /*" -7627- DISPLAY 'SINISMES-COD-FONTE ................. ' SINISMES-COD-FONTE */
            _.Display($"SINISMES-COD-FONTE ................. {SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE}");

            /*" -7629- DISPLAY 'W-DATA-AVISO-SIAS  ................. ' W-DATA-AVISO-SIAS */
            _.Display($"W-DATA-AVISO-SIAS  ................. {W_DATA_AVISO_SIAS}");

            /*" -7631- DISPLAY 'SINISMES-DATA-COMUNICADO  .......... ' SINISMES-DATA-COMUNICADO */
            _.Display($"SINISMES-DATA-COMUNICADO  .......... {SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_COMUNICADO}");

            /*" -7633- DISPLAY 'SINISMES-COD-PRODUTO  .............. ' SINISMES-COD-PRODUTO */
            _.Display($"SINISMES-COD-PRODUTO  .............. {SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO}");

            /*" -7635- DISPLAY 'PRODUTO-DESCR-PRODUTO  ............. ' PRODUTO-DESCR-PRODUTO */
            _.Display($"PRODUTO-DESCR-PRODUTO  ............. {PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO}");

            /*" -7637- DISPLAY 'CHEQUEMI-NUM-CHEQUE-INTERNO ........ ' CHEQUEMI-NUM-CHEQUE-INTERNO */
            _.Display($"CHEQUEMI-NUM-CHEQUE-INTERNO ........ {CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NUM_CHEQUE_INTERNO}");

            /*" -7639- DISPLAY 'MOVDEBCE-NUM-APOLICE  .............. ' MOVDEBCE-NUM-APOLICE */
            _.Display($"MOVDEBCE-NUM-APOLICE  .............. {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE}");

            /*" -7641- DISPLAY 'MOVDEBCE-NUM-ENDOSSO  .............. ' MOVDEBCE-NUM-ENDOSSO */
            _.Display($"MOVDEBCE-NUM-ENDOSSO  .............. {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO}");

            /*" -7643- DISPLAY 'MOVDEBCE-NUM-PARCELA  .............. ' MOVDEBCE-NUM-PARCELA */
            _.Display($"MOVDEBCE-NUM-PARCELA  .............. {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA}");

            /*" -7645- DISPLAY 'MOVDEBCE-SITUACAO-COBRANCA  ........ ' MOVDEBCE-SITUACAO-COBRANCA */
            _.Display($"MOVDEBCE-SITUACAO-COBRANCA  ........ {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA}");

            /*" -7647- DISPLAY 'W-NOME-SITUACAO-COBRANCA  .......... ' W-NOME-SITUACAO-COBRANCA */
            _.Display($"W-NOME-SITUACAO-COBRANCA  .......... {W_NOME_SITUACAO_COBRANCA}");

            /*" -7649- DISPLAY 'MOVDEBCE-DATA-VENCIMENTO  .......... ' MOVDEBCE-DATA-VENCIMENTO */
            _.Display($"MOVDEBCE-DATA-VENCIMENTO  .......... {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO}");

            /*" -7651- DISPLAY 'MOVDEBCE-DATA-MOVIMENTO ............ ' MOVDEBCE-DATA-MOVIMENTO */
            _.Display($"MOVDEBCE-DATA-MOVIMENTO ............ {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO}");

            /*" -7653- DISPLAY 'MOVDEBCE-COD-AGENCIA-DEB ........... ' MOVDEBCE-COD-AGENCIA-DEB */
            _.Display($"MOVDEBCE-COD-AGENCIA-DEB ........... {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB}");

            /*" -7655- DISPLAY 'MOVDEBCE-OPER-CONTA-DEB  ........... ' MOVDEBCE-OPER-CONTA-DEB */
            _.Display($"MOVDEBCE-OPER-CONTA-DEB  ........... {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB}");

            /*" -7657- DISPLAY 'MOVDEBCE-NUM-CONTA-DEB  ............ ' MOVDEBCE-NUM-CONTA-DEB */
            _.Display($"MOVDEBCE-NUM-CONTA-DEB  ............ {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB}");

            /*" -7659- DISPLAY 'MOVDEBCE-DIG-CONTA-DEB  ............ ' MOVDEBCE-DIG-CONTA-DEB */
            _.Display($"MOVDEBCE-DIG-CONTA-DEB  ............ {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB}");

            /*" -7661- DISPLAY 'MOVDEBCE-COD-CONVENIO  ............. ' MOVDEBCE-COD-CONVENIO */
            _.Display($"MOVDEBCE-COD-CONVENIO  ............. {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO}");

            /*" -7663- DISPLAY 'MOVDEBCE-DATA-ENVIO  ............... ' MOVDEBCE-DATA-ENVIO */
            _.Display($"MOVDEBCE-DATA-ENVIO  ............... {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_ENVIO}");

            /*" -7665- DISPLAY 'MOVDEBCE-NSAS  ..................... ' MOVDEBCE-NSAS */
            _.Display($"MOVDEBCE-NSAS  ..................... {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS}");

            /*" -7667- DISPLAY 'MOVDEBCE-NUM-REQUISICAO  ........... ' MOVDEBCE-NUM-REQUISICAO */
            _.Display($"MOVDEBCE-NUM-REQUISICAO  ........... {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO}");

            /*" -7669- DISPLAY 'GE369-COD-AGENCIA .................. ' GE369-COD-AGENCIA */
            _.Display($"GE369-COD-AGENCIA .................. {GE369.DCLGE_MOVTO_CONTA.GE369_COD_AGENCIA}");

            /*" -7671- DISPLAY 'NULL-COD-AGENCIA  .................. ' NULL-COD-AGENCIA */
            _.Display($"NULL-COD-AGENCIA  .................. {NULL_COD_AGENCIA}");

            /*" -7673- DISPLAY 'GE369-COD-BANCO  ................... ' GE369-COD-BANCO */
            _.Display($"GE369-COD-BANCO  ................... {GE369.DCLGE_MOVTO_CONTA.GE369_COD_BANCO}");

            /*" -7675- DISPLAY 'NULL-COD-BANCO  .................... ' NULL-COD-BANCO */
            _.Display($"NULL-COD-BANCO  .................... {NULL_COD_BANCO}");

            /*" -7677- DISPLAY 'GE369-NUM-CONTA-CNB ................ ' GE369-NUM-CONTA-CNB */
            _.Display($"GE369-NUM-CONTA-CNB ................ {GE369.DCLGE_MOVTO_CONTA.GE369_NUM_CONTA_CNB}");

            /*" -7679- DISPLAY 'NULL-NUM-CONTA-CNB ................. ' NULL-NUM-CONTA-CNB */
            _.Display($"NULL-NUM-CONTA-CNB ................. {NULL_NUM_CONTA_CNB}");

            /*" -7681- DISPLAY 'GE369-NUM-DV-CONTA-CNB ............. ' GE369-NUM-DV-CONTA-CNB */
            _.Display($"GE369-NUM-DV-CONTA-CNB ............. {GE369.DCLGE_MOVTO_CONTA.GE369_NUM_DV_CONTA_CNB}");

            /*" -7683- DISPLAY 'NULL-NUM-DV-CONTA-CNB .............. ' NULL-NUM-DV-CONTA-CNB */
            _.Display($"NULL-NUM-DV-CONTA-CNB .............. {NULL_NUM_DV_CONTA_CNB}");

            /*" -7685- DISPLAY 'GE369-IND-CONTA-BANCARIA ........... ' GE369-IND-CONTA-BANCARIA */
            _.Display($"GE369-IND-CONTA-BANCARIA ........... {GE369.DCLGE_MOVTO_CONTA.GE369_IND_CONTA_BANCARIA}");

            /*" -7686- DISPLAY 'NULL-IND-CONTA-BANCARIA ............ ' NULL-IND-CONTA-BANCARIA . */
            _.Display($"NULL-IND-CONTA-BANCARIA ............ {NULL_IND_CONTA_BANCARIA}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8888_EXIT*/

        [StopWatch]
        /*" R8889-DISPLAY-IMPOSTOS */
        private void R8889_DISPLAY_IMPOSTOS(bool isPerform = false)
        {
            /*" -7694- DISPLAY 'SINISHIS-NUM-APOL-SINISTRO .......... ' SINISHIS-NUM-APOL-SINISTRO */
            _.Display($"SINISHIS-NUM-APOL-SINISTRO .......... {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

            /*" -7696- DISPLAY 'SINISHIS-OCORR-HISTORICO   .......... ' SINISHIS-OCORR-HISTORICO */
            _.Display($"SINISHIS-OCORR-HISTORICO   .......... {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}");

            /*" -7698- DISPLAY 'SINISHIS-COD-OPERACAO  .......... ' SINISHIS-COD-OPERACAO */
            _.Display($"SINISHIS-COD-OPERACAO  .......... {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO}");

            /*" -7700- DISPLAY 'SIPADOFI-NUM-DOCF-INTERNO .......... ' SIPADOFI-NUM-DOCF-INTERNO */
            _.Display($"SIPADOFI-NUM-DOCF-INTERNO .......... {SIPADOFI.DCLSI_PAGA_DOC_FISCAL.SIPADOFI_NUM_DOCF_INTERNO}");

            /*" -7702- DISPLAY 'FIPADOLA-COD-TP-LANCDOCF .......... ' FIPADOLA-COD-TP-LANCDOCF */
            _.Display($"FIPADOLA-COD-TP-LANCDOCF .......... {FIPADOLA.DCLFI_PAGA_DOCF_LANC.FIPADOLA_COD_TP_LANCDOCF}");

            /*" -7704- DISPLAY 'GETPLADO-ABREV-LANCDOCF .......... ' GETPLADO-ABREV-LANCDOCF */
            _.Display($"GETPLADO-ABREV-LANCDOCF .......... {GETPLADO.DCLGE_TP_LANC_DOCF.GETPLADO_ABREV_LANCDOCF}");

            /*" -7706- DISPLAY 'FIPADOLA-VALOR-LANCAMENTO .......... ' FIPADOLA-VALOR-LANCAMENTO */
            _.Display($"FIPADOLA-VALOR-LANCAMENTO .......... {FIPADOLA.DCLFI_PAGA_DOCF_LANC.FIPADOLA_VALOR_LANCAMENTO}");

            /*" -7708- DISPLAY 'GETIPIMP-COD-IMP-INTERNO .......... ' GETIPIMP-COD-IMP-INTERNO */
            _.Display($"GETIPIMP-COD-IMP-INTERNO .......... {GETIPIMP.DCLGE_TIPO_IMPOSTO.GETIPIMP_COD_IMP_INTERNO}");

            /*" -7710- DISPLAY 'GETIPIMP-SIGLA-IMP .......... ' GETIPIMP-SIGLA-IMP */
            _.Display($"GETIPIMP-SIGLA-IMP .......... {GETIPIMP.DCLGE_TIPO_IMPOSTO.GETIPIMP_SIGLA_IMP}");

            /*" -7712- DISPLAY 'FIPADOIM-ALIQ-TRIBUTACAO .......... ' FIPADOIM-ALIQ-TRIBUTACAO */
            _.Display($"FIPADOIM-ALIQ-TRIBUTACAO .......... {FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_ALIQ_TRIBUTACAO}");

            /*" -7713- DISPLAY 'FIPADOIM-VALOR-IMPOSTO  .......... ' FIPADOIM-VALOR-IMPOSTO . */
            _.Display($"FIPADOIM-VALOR-IMPOSTO  .......... {FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_VALOR_IMPOSTO}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8889_EXIT*/

        [StopWatch]
        /*" RXXXX-ROTINA-RETORNO */
        private void RXXXX_ROTINA_RETORNO(bool isPerform = false)
        {
            /*" -7720- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: RXXXX_EXIT*/
    }
}