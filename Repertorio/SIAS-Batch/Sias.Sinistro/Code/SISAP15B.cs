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
using Sias.Sinistro.DB2.SISAP15B;

namespace Code
{
    public class SISAP15B
    {
        public bool IsCall { get; set; }

        public SISAP15B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SINISTRO/FINANCEIRO                *      */
        /*"      *   PROGRAMA ...............  SISAP15B                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  HEIDER COELHO                      *      */
        /*"      *   PROGRAMADOR ............  HEIDER COELHO                      *      */
        /*"      *   DATA CODIFICACAO .......  JUNHO / 2010                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO:                                                      *      */
        /*"      *   Este programa � copia do SISAP01B que a partir do Projeto    *      */
        /*"      *   REINF s� processar� as cobran�as - movimentos CA             *      */
        /*"      *                                                                *      */
        /*"      *   SISAP01B - Pagamentos em conta corrente                      *      */
        /*"      *   SISAP01B - Pagamentos em cheque                              *      */
        /*"      *   SISAP15B - Cobran�a                                          *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *   Projeto REINF                                                *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * HISTORICO DE VERSOES                                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * NO   VERSAO    DATA       PROGRAMADOR           ALTERACAO      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.25  * VERSAO  : 025                                                  *      */
        /*"      * TAREFA  : 247980                                               *      */
        /*"      * DATA    : 16/06/2020                                           *      */
        /*"      * NOME    : HERVAL SOUZA                                         *      */
        /*"      * MARCADOR: V.25                                                 *      */
        /*"      * MOTIVO  : CVP - INCLUIR NA PESQUISA DA CEPFAIXAFILIAL O CODIGO *      */
        /*"      *           DA EMPRES BASEADO NA INFORMACAO DO PRODUTO           *      */
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
        /*"01  DCLOD-PESSOA-FISICA.*/
        public SISAP15B_DCLOD_PESSOA_FISICA DCLOD_PESSOA_FISICA { get; set; } = new SISAP15B_DCLOD_PESSOA_FISICA();
        public class SISAP15B_DCLOD_PESSOA_FISICA : VarBasis
        {
            /*"    10 OD002-NUM-PESSOA     PIC S9(9) USAGE COMP.*/
            public IntBasis OD002_NUM_PESSOA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
            /*"    10 OD002-NUM-CPF        PIC S9(9) USAGE COMP.*/
            public IntBasis OD002_NUM_CPF { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
            /*"    10 OD002-NUM-DV-CPF     PIC S9(4) USAGE COMP.*/
            public IntBasis OD002_NUM_DV_CPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    10 OD002-NOM-PESSOA.*/
            public SISAP15B_OD002_NOM_PESSOA OD002_NOM_PESSOA { get; set; } = new SISAP15B_OD002_NOM_PESSOA();
            public class SISAP15B_OD002_NOM_PESSOA : VarBasis
            {
                /*"       49 OD002-NOM-PESSOA-LEN          PIC S9(4) USAGE COMP.*/
                public IntBasis OD002_NOM_PESSOA_LEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
                /*"       49 OD002-NOM-PESSOA-TEXT          PIC X(200).*/
                public StringBasis OD002_NOM_PESSOA_TEXT { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");
                /*"    10 OD002-DTH-NASCIMENTO       PIC X(10).*/
            }
            public StringBasis OD002_DTH_NASCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    10 OD002-STA-SEXO       PIC X(1).*/
            public StringBasis OD002_STA_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
            /*"    10 OD002-IND-ESTADO-CIVIL       PIC X(1).*/
            public StringBasis OD002_IND_ESTADO_CIVIL { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
            /*"    10 OD002-STA-PESSOA     PIC X(1).*/
            public StringBasis OD002_STA_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
            /*"    10 OD002-NOM-TRATAMENTO       PIC X(15).*/
            public StringBasis OD002_NOM_TRATAMENTO { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
            /*"    10 OD002-COD-UF         PIC X(2).*/
            public StringBasis OD002_COD_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
            /*"    10 OD002-NUM-MUNICIPIO  PIC S9(9) USAGE COMP.*/
            public IntBasis OD002_NUM_MUNICIPIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
            /*"    10 OD002-NUM-INSC-SOCIAL       PIC S9(10)V USAGE COMP-3.*/
            public DoubleBasis OD002_NUM_INSC_SOCIAL { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V"), 0);
            /*"    10 OD002-NUM-DV-INSC-SOCIAL       PIC S9(4) USAGE COMP.*/
            public IntBasis OD002_NUM_DV_INSC_SOCIAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    10 OD002-NUM-GRAU-INSTRUCAO       PIC S9(4) USAGE COMP.*/
            public IntBasis OD002_NUM_GRAU_INSTRUCAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    10 OD002-NOM-REDUZIDO   PIC X(25).*/
            public StringBasis OD002_NOM_REDUZIDO { get; set; } = new StringBasis(new PIC("X", "25", "X(25)."), @"");
            /*"    10 OD002-COD-CBO        PIC X(10).*/
            public StringBasis OD002_COD_CBO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    10 OD002-NOM-PRIMEIRO   PIC X(25).*/
            public StringBasis OD002_NOM_PRIMEIRO { get; set; } = new StringBasis(new PIC("X", "25", "X(25)."), @"");
            /*"    10 OD002-NOM-ULTIMO     PIC X(25).*/
            public StringBasis OD002_NOM_ULTIMO { get; set; } = new StringBasis(new PIC("X", "25", "X(25)."), @"");
            /*"01           AREA-DE-WORK.*/
        }
        public SISAP15B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SISAP15B_AREA_DE_WORK();
        public class SISAP15B_AREA_DE_WORK : VarBasis
        {
            /*"  05         WSL-SQLCODE       PIC  9(009)    VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WS-ENDERECO.*/
            public SISAP15B_WS_ENDERECO WS_ENDERECO { get; set; } = new SISAP15B_WS_ENDERECO();
            public class SISAP15B_WS_ENDERECO : VarBasis
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
                /*"  05   W-NUM4                  PIC 9(04)  VALUE 0.*/
            }
            public IntBasis W_NUM4 { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
            /*"  05   W-NUM5                  PIC 9(06)  VALUE 0.*/
            public IntBasis W_NUM5 { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
            /*"  05         WHORA.*/
            public SISAP15B_WHORA WHORA { get; set; } = new SISAP15B_WHORA();
            public class SISAP15B_WHORA : VarBasis
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
            public SISAP15B_W_AGRUPADOR_1 W_AGRUPADOR_1 { get; set; } = new SISAP15B_W_AGRUPADOR_1();
            public class SISAP15B_W_AGRUPADOR_1 : VarBasis
            {
                /*"     10 W-AGRUPADOR-LEGENDA           PIC X(11) VALUE ' '.*/
                public StringBasis W_AGRUPADOR_LEGENDA { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @" ");
                /*"     10 W-AGRUPADOR-MINUTO-SSSSSS     PIC X(09) VALUE ' '.*/
                public StringBasis W_AGRUPADOR_MINUTO_SSSSSS { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @" ");
                /*"  05 W-IDLG-SIAS-SINISTRO.*/
            }
            public SISAP15B_W_IDLG_SIAS_SINISTRO W_IDLG_SIAS_SINISTRO { get; set; } = new SISAP15B_W_IDLG_SIAS_SINISTRO();
            public class SISAP15B_W_IDLG_SIAS_SINISTRO : VarBasis
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
                private _REDEF_SISAP15B_W_IDLG_COMPLEMENTO_1 _w_idlg_complemento_1 { get; set; }
                public _REDEF_SISAP15B_W_IDLG_COMPLEMENTO_1 W_IDLG_COMPLEMENTO_1
                {
                    get { _w_idlg_complemento_1 = new _REDEF_SISAP15B_W_IDLG_COMPLEMENTO_1(); _.Move(W_IDLG_COMPLEMENTO, _w_idlg_complemento_1); VarBasis.RedefinePassValue(W_IDLG_COMPLEMENTO, _w_idlg_complemento_1, W_IDLG_COMPLEMENTO); _w_idlg_complemento_1.ValueChanged += () => { _.Move(_w_idlg_complemento_1, W_IDLG_COMPLEMENTO); }; return _w_idlg_complemento_1; }
                    set { VarBasis.RedefinePassValue(value, _w_idlg_complemento_1, W_IDLG_COMPLEMENTO); }
                }  //Redefines
                public class _REDEF_SISAP15B_W_IDLG_COMPLEMENTO_1 : VarBasis
                {
                    /*"       15 W-IDLG-NUM-CHEQUE-INTERNO  PIC 9(10).*/
                    public IntBasis W_IDLG_NUM_CHEQUE_INTERNO { get; set; } = new IntBasis(new PIC("9", "10", "9(10)."));
                    /*"    10 W-IDLG-COMPLEMENTO-2   REDEFINES  W-IDLG-COMPLEMENTO.*/

                    public _REDEF_SISAP15B_W_IDLG_COMPLEMENTO_1()
                    {
                        W_IDLG_NUM_CHEQUE_INTERNO.ValueChanged += OnValueChanged;
                    }

                }
                private _REDEF_SISAP15B_W_IDLG_COMPLEMENTO_2 _w_idlg_complemento_2 { get; set; }
                public _REDEF_SISAP15B_W_IDLG_COMPLEMENTO_2 W_IDLG_COMPLEMENTO_2
                {
                    get { _w_idlg_complemento_2 = new _REDEF_SISAP15B_W_IDLG_COMPLEMENTO_2(); _.Move(W_IDLG_COMPLEMENTO, _w_idlg_complemento_2); VarBasis.RedefinePassValue(W_IDLG_COMPLEMENTO, _w_idlg_complemento_2, W_IDLG_COMPLEMENTO); _w_idlg_complemento_2.ValueChanged += () => { _.Move(_w_idlg_complemento_2, W_IDLG_COMPLEMENTO); }; return _w_idlg_complemento_2; }
                    set { VarBasis.RedefinePassValue(value, _w_idlg_complemento_2, W_IDLG_COMPLEMENTO); }
                }  //Redefines
                public class _REDEF_SISAP15B_W_IDLG_COMPLEMENTO_2 : VarBasis
                {
                    /*"       15 W-IDLG-NSAS                PIC 9(10).*/
                    public IntBasis W_IDLG_NSAS { get; set; } = new IntBasis(new PIC("9", "10", "9(10)."));
                    /*"    10 W-IDLG-COMPLEMENTO-3   REDEFINES  W-IDLG-COMPLEMENTO.*/

                    public _REDEF_SISAP15B_W_IDLG_COMPLEMENTO_2()
                    {
                        W_IDLG_NSAS.ValueChanged += OnValueChanged;
                    }

                }
                private _REDEF_SISAP15B_W_IDLG_COMPLEMENTO_3 _w_idlg_complemento_3 { get; set; }
                public _REDEF_SISAP15B_W_IDLG_COMPLEMENTO_3 W_IDLG_COMPLEMENTO_3
                {
                    get { _w_idlg_complemento_3 = new _REDEF_SISAP15B_W_IDLG_COMPLEMENTO_3(); _.Move(W_IDLG_COMPLEMENTO, _w_idlg_complemento_3); VarBasis.RedefinePassValue(W_IDLG_COMPLEMENTO, _w_idlg_complemento_3, W_IDLG_COMPLEMENTO); _w_idlg_complemento_3.ValueChanged += () => { _.Move(_w_idlg_complemento_3, W_IDLG_COMPLEMENTO); }; return _w_idlg_complemento_3; }
                    set { VarBasis.RedefinePassValue(value, _w_idlg_complemento_3, W_IDLG_COMPLEMENTO); }
                }  //Redefines
                public class _REDEF_SISAP15B_W_IDLG_COMPLEMENTO_3 : VarBasis
                {
                    /*"       15 W-IDLG-NUM-ACORDO          PIC 9(05).*/
                    public IntBasis W_IDLG_NUM_ACORDO { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
                    /*"       15 FILLER                     PIC X(01).*/
                    public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                    /*"       15 W-IDLG-NUM-PARCELA         PIC 9(04).*/
                    public IntBasis W_IDLG_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                    /*"  05 W-LOTE-NUM-SEQUENCIA            PIC 9(09) VALUE 0.*/

                    public _REDEF_SISAP15B_W_IDLG_COMPLEMENTO_3()
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
            public SISAP15B_W_LOTE W_LOTE { get; set; } = new SISAP15B_W_LOTE();
            public class SISAP15B_W_LOTE : VarBasis
            {
                /*"    10 W-LOTE-NOME-PROGRAMA.*/
                public SISAP15B_W_LOTE_NOME_PROGRAMA W_LOTE_NOME_PROGRAMA { get; set; } = new SISAP15B_W_LOTE_NOME_PROGRAMA();
                public class SISAP15B_W_LOTE_NOME_PROGRAMA : VarBasis
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
                public SISAP15B_W_BANKK W_BANKK { get; set; } = new SISAP15B_W_BANKK();
                public class SISAP15B_W_BANKK : VarBasis
                {
                    /*"       10 W-COD-BANCO             PIC 9(03) VALUE 0.*/
                    public IntBasis W_COD_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
                    /*"       10 W-DV-BANCO              PIC 9(01) VALUE 0.*/
                    public IntBasis W_DV_BANCO { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
                    /*"       10 W-COD-AGENCIA           PIC 9(04) VALUE 0.*/
                    public IntBasis W_COD_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                    /*"    05 W-USO-EMPRESA-SIACC.*/
                }
                public SISAP15B_W_USO_EMPRESA_SIACC W_USO_EMPRESA_SIACC { get; set; } = new SISAP15B_W_USO_EMPRESA_SIACC();
                public class SISAP15B_W_USO_EMPRESA_SIACC : VarBasis
                {
                    /*"       10 W-ATTR-14               PIC X(30) VALUE SPACES.*/
                    public StringBasis W_ATTR_14 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
                    /*"       10 W-ATTR-15               PIC X(10) VALUE SPACES.*/
                    public StringBasis W_ATTR_15 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                    /*"    05 W-CONTA-SAP.*/
                }
                public SISAP15B_W_CONTA_SAP W_CONTA_SAP { get; set; } = new SISAP15B_W_CONTA_SAP();
                public class SISAP15B_W_CONTA_SAP : VarBasis
                {
                    /*"       10 W-NUM-CONTA-SAP         PIC 9(12) VALUE 0.*/
                    public IntBasis W_NUM_CONTA_SAP { get; set; } = new IntBasis(new PIC("9", "12", "9(12)"));
                    /*"       10 FILLER                  PIC X(01) VALUE '-'.*/
                    public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                    /*"       10 W-DV-CONTA-SAP          PIC X(01) VALUE ' '.*/
                    public StringBasis W_DV_CONTA_SAP { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                    /*"  05 W-ATTR17.*/
                }
            }
            public SISAP15B_W_ATTR17 W_ATTR17 { get; set; } = new SISAP15B_W_ATTR17();
            public class SISAP15B_W_ATTR17 : VarBasis
            {
                /*"     10 W-ATTR17-SISTEMA             PIC X(02) VALUE 'SI'.*/
                public StringBasis W_ATTR17_SISTEMA { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"SI");
                /*"     10 W-ATTR17-USUARIO             PIC X(08) VALUE ' '.*/
                public StringBasis W_ATTR17_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @" ");
                /*"  05  W-PRODUTO-SAP.*/
            }
            public SISAP15B_W_PRODUTO_SAP W_PRODUTO_SAP { get; set; } = new SISAP15B_W_PRODUTO_SAP();
            public class SISAP15B_W_PRODUTO_SAP : VarBasis
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
            public SISAP15B_WS_USO_EMPRESA_SICOV WS_USO_EMPRESA_SICOV { get; set; } = new SISAP15B_WS_USO_EMPRESA_SICOV();
            public class SISAP15B_WS_USO_EMPRESA_SICOV : VarBasis
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
            /*"  05  W-CHAVE-ACHOU-NOTA-FISCAL       PIC X(03) VALUE  'NAO'.*/
            public StringBasis W_CHAVE_ACHOU_NOTA_FISCAL { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"  05  W-CHAVE-MONTA-SIACC-ESPECIAL    PIC X(03) VALUE  'NAO'.*/
            public StringBasis W_CHAVE_MONTA_SIACC_ESPECIAL { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"  05  W-CHAVE-TIPO-PESSOA-PF-PJ       PIC X(05) VALUE SPACES.*/
            public StringBasis W_CHAVE_TIPO_PESSOA_PF_PJ { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
            /*"  05  W-CHAVE-COLOCA-ENDERECO         PIC X(03) VALUE  'NAO'.*/
            public StringBasis W_CHAVE_COLOCA_ENDERECO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"  05  W-CHAVE-ACHOU-FORNECEDOR        PIC X(03) VALUE  'NAO'.*/
            public StringBasis W_CHAVE_ACHOU_FORNECEDOR { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"  05  W-CHAVE-ACHOU-FONTE-IMPOSTO     PIC X(03) VALUE  'NAO'.*/
            public StringBasis W_CHAVE_ACHOU_FONTE_IMPOSTO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"  05 W-DATA-AAAAMMDD.*/
            public SISAP15B_W_DATA_AAAAMMDD W_DATA_AAAAMMDD { get; set; } = new SISAP15B_W_DATA_AAAAMMDD();
            public class SISAP15B_W_DATA_AAAAMMDD : VarBasis
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
            /*"  05 W-AC-TOT-INDENIZACOES        PIC 9(15)V99.*/
            public DoubleBasis W_AC_TOT_INDENIZACOES { get; set; } = new DoubleBasis(new PIC("9", "15", "9(15)V99."), 2);
            /*"  05 W-AC-TOT-HONORARIOS          PIC 9(15)V99.*/
            public DoubleBasis W_AC_TOT_HONORARIOS { get; set; } = new DoubleBasis(new PIC("9", "15", "9(15)V99."), 2);
            /*"  05  W-NUM-CPF-NUM                PIC 9(11).*/
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
            public SISAP15B_W_CAMPO_EDITADO W_CAMPO_EDITADO { get; set; } = new SISAP15B_W_CAMPO_EDITADO();
            public class SISAP15B_W_CAMPO_EDITADO : VarBasis
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
            public SISAP15B_W_VALOR_GERAL_X W_VALOR_GERAL_X { get; set; } = new SISAP15B_W_VALOR_GERAL_X();
            public class SISAP15B_W_VALOR_GERAL_X : VarBasis
            {
                /*"     10 W-VALOR-GERAL-VALOR          PIC ------------9,99.*/
                public DoubleBasis W_VALOR_GERAL_VALOR { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
                /*"  05 W-CEP-NUM                       PIC 9(08) VALUE 0.*/
            }
            public IntBasis W_CEP_NUM { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"  05 W-CEP-NUMERICO  REDEFINES  W-CEP-NUM.*/
            private _REDEF_SISAP15B_W_CEP_NUMERICO _w_cep_numerico { get; set; }
            public _REDEF_SISAP15B_W_CEP_NUMERICO W_CEP_NUMERICO
            {
                get { _w_cep_numerico = new _REDEF_SISAP15B_W_CEP_NUMERICO(); _.Move(W_CEP_NUM, _w_cep_numerico); VarBasis.RedefinePassValue(W_CEP_NUM, _w_cep_numerico, W_CEP_NUM); _w_cep_numerico.ValueChanged += () => { _.Move(_w_cep_numerico, W_CEP_NUM); }; return _w_cep_numerico; }
                set { VarBasis.RedefinePassValue(value, _w_cep_numerico, W_CEP_NUM); }
            }  //Redefines
            public class _REDEF_SISAP15B_W_CEP_NUMERICO : VarBasis
            {
                /*"     10 W-CEP-NUMERICO-PARTE1        PIC 9(05).*/
                public IntBasis W_CEP_NUMERICO_PARTE1 { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
                /*"     10 W-CEP-NUMERICO-PARTE2        PIC 9(03).*/
                public IntBasis W_CEP_NUMERICO_PARTE2 { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
                /*"  05 W-CEP-ALFA.*/

                public _REDEF_SISAP15B_W_CEP_NUMERICO()
                {
                    W_CEP_NUMERICO_PARTE1.ValueChanged += OnValueChanged;
                    W_CEP_NUMERICO_PARTE2.ValueChanged += OnValueChanged;
                }

            }
            public SISAP15B_W_CEP_ALFA W_CEP_ALFA { get; set; } = new SISAP15B_W_CEP_ALFA();
            public class SISAP15B_W_CEP_ALFA : VarBasis
            {
                /*"     10 W-CEP-ALFA-PARTE1            PIC 9(05).*/
                public IntBasis W_CEP_ALFA_PARTE1 { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
                /*"     10 FILLER                       PIC X(01)  VALUE '-' .*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"     10 W-CEP-ALFA-PARTE2            PIC 9(03).*/
                public IntBasis W_CEP_ALFA_PARTE2 { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
                /*"  05 W-CONTA-CORRENTE-DEBITO.*/
            }
            public SISAP15B_W_CONTA_CORRENTE_DEBITO W_CONTA_CORRENTE_DEBITO { get; set; } = new SISAP15B_W_CONTA_CORRENTE_DEBITO();
            public class SISAP15B_W_CONTA_CORRENTE_DEBITO : VarBasis
            {
                /*"     10 W-OPERACAO-CONTA-DEBITO  PIC 9(04) VALUE ZEROS.*/
                public IntBasis W_OPERACAO_CONTA_DEBITO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"     10 W-CONTA-CONTA-DEBITO     PIC 9(12) VALUE ZEROS.*/
                public IntBasis W_CONTA_CONTA_DEBITO { get; set; } = new IntBasis(new PIC("9", "12", "9(12)"));
                /*"  05 W-DV-CORRENTE-DEBITO-NUM    PIC 9(05).*/
            }
            public IntBasis W_DV_CORRENTE_DEBITO_NUM { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
            /*"  05 W-DV-CORRENTE-DEBITO-ALFA                         REDEFINES  W-DV-CORRENTE-DEBITO-NUM.*/
            private _REDEF_SISAP15B_W_DV_CORRENTE_DEBITO_ALFA _w_dv_corrente_debito_alfa { get; set; }
            public _REDEF_SISAP15B_W_DV_CORRENTE_DEBITO_ALFA W_DV_CORRENTE_DEBITO_ALFA
            {
                get { _w_dv_corrente_debito_alfa = new _REDEF_SISAP15B_W_DV_CORRENTE_DEBITO_ALFA(); _.Move(W_DV_CORRENTE_DEBITO_NUM, _w_dv_corrente_debito_alfa); VarBasis.RedefinePassValue(W_DV_CORRENTE_DEBITO_NUM, _w_dv_corrente_debito_alfa, W_DV_CORRENTE_DEBITO_NUM); _w_dv_corrente_debito_alfa.ValueChanged += () => { _.Move(_w_dv_corrente_debito_alfa, W_DV_CORRENTE_DEBITO_NUM); }; return _w_dv_corrente_debito_alfa; }
                set { VarBasis.RedefinePassValue(value, _w_dv_corrente_debito_alfa, W_DV_CORRENTE_DEBITO_NUM); }
            }  //Redefines
            public class _REDEF_SISAP15B_W_DV_CORRENTE_DEBITO_ALFA : VarBasis
            {
                /*"     10 FILLER                   PIC X(04).*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)."), @"");
                /*"     10 W-DV-CONTA-CONTA-DEBITO  PIC X(01).*/
                public StringBasis W_DV_CONTA_CONTA_DEBITO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"  05         WHORA-CURR.*/

                public _REDEF_SISAP15B_W_DV_CORRENTE_DEBITO_ALFA()
                {
                    FILLER_17.ValueChanged += OnValueChanged;
                    W_DV_CONTA_CONTA_DEBITO.ValueChanged += OnValueChanged;
                }

            }
            public SISAP15B_WHORA_CURR WHORA_CURR { get; set; } = new SISAP15B_WHORA_CURR();
            public class SISAP15B_WHORA_CURR : VarBasis
            {
                /*"    10       WHORA-HH-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_HH_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORA-MM-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORA-SS-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_SS_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WHORAS.*/
            }
            public SISAP15B_WHORAS WHORAS { get; set; } = new SISAP15B_WHORAS();
            public class SISAP15B_WHORAS : VarBasis
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
            private _REDEF_SISAP15B_FILLER_18 _filler_18 { get; set; }
            public _REDEF_SISAP15B_FILLER_18 FILLER_18
            {
                get { _filler_18 = new _REDEF_SISAP15B_FILLER_18(); _.Move(WMONTA_DATA, _filler_18); VarBasis.RedefinePassValue(WMONTA_DATA, _filler_18, WMONTA_DATA); _filler_18.ValueChanged += () => { _.Move(_filler_18, WMONTA_DATA); }; return _filler_18; }
                set { VarBasis.RedefinePassValue(value, _filler_18, WMONTA_DATA); }
            }  //Redefines
            public class _REDEF_SISAP15B_FILLER_18 : VarBasis
            {
                /*"    10       WDATA-DIA         PIC  9(002).*/
                public IntBasis WDATA_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WDATA-MES         PIC  9(002).*/
                public IntBasis WDATA_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WDATA-ANO         PIC  9(004).*/
                public IntBasis WDATA_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05  W-EDICAO-QTD             PIC Z.ZZZ.ZZ9.*/

                public _REDEF_SISAP15B_FILLER_18()
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
            private _REDEF_SISAP15B_WCGC _wcgc { get; set; }
            public _REDEF_SISAP15B_WCGC WCGC
            {
                get { _wcgc = new _REDEF_SISAP15B_WCGC(); _.Move(WCGCCPF, _wcgc); VarBasis.RedefinePassValue(WCGCCPF, _wcgc, WCGCCPF); _wcgc.ValueChanged += () => { _.Move(_wcgc, WCGCCPF); }; return _wcgc; }
                set { VarBasis.RedefinePassValue(value, _wcgc, WCGCCPF); }
            }  //Redefines
            public class _REDEF_SISAP15B_WCGC : VarBasis
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

                public _REDEF_SISAP15B_WCGC()
                {
                    WCGC_RES.ValueChanged += OnValueChanged;
                    WCGC_NUM.ValueChanged += OnValueChanged;
                    WCGC_FIL.ValueChanged += OnValueChanged;
                    WCGC_DIG.ValueChanged += OnValueChanged;
                }

            }
        }
        public SISAP15B_W_TRAILLER_SIAS_GERAL W_TRAILLER_SIAS_GERAL { get; set; } = new SISAP15B_W_TRAILLER_SIAS_GERAL();
        public class SISAP15B_W_TRAILLER_SIAS_GERAL : VarBasis
        {
            /*"    05 TIPOREG-TRAILLER                 PIC 9(02) VALUE 00.*/
            public IntBasis TIPOREG_TRAILLER { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"), 00);
            /*"    05 QTDEREG-TRAILLER                 PIC 9(11) VALUE 0.*/
            public IntBasis QTDEREG_TRAILLER { get; set; } = new IntBasis(new PIC("9", "11", "9(11)"));
            /*"    05 FILLER                           PIC X(11) VALUE ' '.*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @" ");
            /*"    05 FILLER                           PIC X(05) VALUE ' '.*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @" ");
            /*"    05 AMNTT-TRAILLER                   PIC ---------------,--.*/
            public StringBasis AMNTT_TRAILLER { get; set; } = new StringBasis(new PIC("X", "0", "---------------V--."), @"");
            /*"    05 FILLER                           PIC X(23) VALUE ' '.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @" ");
            /*"    05 ORIG-TRAILLER                    PIC X(04) VALUE ' '.*/
            public StringBasis ORIG_TRAILLER { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @" ");
            /*"    05 LOTE-TRAILLER                    PIC X(24) VALUE ' '.*/
            public StringBasis LOTE_TRAILLER { get; set; } = new StringBasis(new PIC("X", "24", "X(24)"), @" ");
            /*"    05 FILLER                           PIC X(3406) VALUE ' '.*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "3406", "X(3406)"), @" ");
            /*"01 W-REGISTRO-SIAS-GERAL.*/
        }
        public SISAP15B_W_REGISTRO_SIAS_GERAL W_REGISTRO_SIAS_GERAL { get; set; } = new SISAP15B_W_REGISTRO_SIAS_GERAL();
        public class SISAP15B_W_REGISTRO_SIAS_GERAL : VarBasis
        {
            /*"    05 TIPOREG-GERAL                    PIC 9(02) VALUE 01.*/
            public IntBasis TIPOREG_GERAL { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"), 01);
            /*"    05 FILLER                           PIC X(68) VALUE SPACES.*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "68", "X(68)"), @"");
            /*"    05 ORIG-GERAL                       PIC X(04) VALUE SPACES.*/
            public StringBasis ORIG_GERAL { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
            /*"    05 LOTE-GERAL                       PIC X(24) VALUE SPACES.*/
            public StringBasis LOTE_GERAL { get; set; } = new StringBasis(new PIC("X", "24", "X(24)"), @"");
            /*"    05 LOTEIT-GERAL                     PIC 9(09) VALUE ZEROS.*/
            public IntBasis LOTEIT_GERAL { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"    05 IDLG-GERAL                       PIC X(40) VALUE SPACES.*/
            public StringBasis IDLG_GERAL { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
            /*"    05 JANELA-GERAL                     PIC X(02) VALUE SPACES.*/
            public StringBasis JANELA_GERAL { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
            /*"    05 ANPRO-GERAL                      PIC 9(04) VALUE ZEROS.*/
            public IntBasis ANPRO_GERAL { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
            /*"    05 CODOPE-GERAL                     PIC X(10) VALUE SPACES.*/
            public StringBasis CODOPE_GERAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"    05 PAGBLK-GERAL                     PIC X(01) VALUE SPACES.*/
            public StringBasis PAGBLK_GERAL { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"    05 CODSOC-GERAL                     PIC X(04) VALUE SPACES.*/
            public StringBasis CODSOC_GERAL { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
            /*"    05 MOEDA-GERAL                      PIC X(05) VALUE SPACES.*/
            public StringBasis MOEDA_GERAL { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
            /*"    05 DTDOC-GERAL                      PIC X(08) VALUE SPACES.*/
            public StringBasis DTDOC_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 DTLAN-GERAL                      PIC X(08) VALUE SPACES.*/
            public StringBasis DTLAN_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 ATTR01-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR01_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 ATTRVAL01-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL01_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"    05 ATTR02-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR02_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 ATTRVAL02-GERAL                  PIC X(30) VALUE  SPACES.*/
            public StringBasis ATTRVAL02_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"    05 ATTR03-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR03_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 ATTRVAL03-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL03_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"    05 ATTR04-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR04_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 ATTRVAL04-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL04_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"    05 ATTR05-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR05_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 ATTRVAL05-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL05_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"    05 ATTR06-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR06_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 ATTRVAL06-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL06_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"    05 ATTR07-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR07_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 ATTRVAL07-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL07_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"    05 ATTR08-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR08_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 ATTRVAL08-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL08_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"    05 ATTR09-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR09_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 ATTRVAL09-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL09_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"    05 ATTR10-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR10_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 ATTRVAL10-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL10_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"    05 ATTR11-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR11_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 ATTRVAL11-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL11_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"    05 ATTR12-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR12_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 ATTRVAL12-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL12_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"    05 ATTR13-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR13_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 ATTRVAL13-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL13_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"    05 ATTR14-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR14_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 ATTRVAL14-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL14_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"    05 ATTR15-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR15_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 ATTRVAL15-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL15_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"    05 ATTR16-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR16_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 ATTRVAL16-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL16_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"    05 ATTR17-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR17_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 ATTRVAL17-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL17_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"    05 ATTR18-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR18_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 ATTRVAL18-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL18_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"    05 ATTR19-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR19_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 ATTRVAL19-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL19_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"    05 ATTR20-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR20_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 ATTRVAL20-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL20_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"    05 ATTR21-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR21_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 ATTRVAL21-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL21_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"    05 ATTR22-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR22_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 ATTRVAL22-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL22_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"    05 ATTR23-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR23_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 ATTRVAL23-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL23_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"    05 ATTR24-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR24_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 ATTRVAL24-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL24_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"    05 ATTR25-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR25_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 ATTRVAL25-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL25_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"    05 ATTR26-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR26_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 ATTRVAL26-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL26_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"    05 ATTR27-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR27_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 ATTRVAL27-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL27_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"    05 ATTR28-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR28_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 ATTRVAL28-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL28_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"    05 ATTR29-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR29_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 ATTRVAL29-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL29_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"    05 ATTR30-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR30_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 ATTRVAL30-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL30_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"    05 ATTR31-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR31_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 ATTRVAL31-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL31_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"    05 ATTR32-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR32_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 ATTRVAL32-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL32_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"    05 ATTR33-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR33_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 ATTRVAL33-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL33_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"    05 ATTR34-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR34_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 ATTRVAL34-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL34_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"    05 ATTR35-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis ATTR35_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 ATTRVAL35-GERAL                  PIC X(30) VALUE SPACES.*/
            public StringBasis ATTRVAL35_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"    05 COD01-GERAL                      PIC X(08) VALUE SPACES.*/
            public StringBasis COD01_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 VALO01-GERAL                     PIC X(23) VALUE SPACES                       JUST RIGHT.*/
            public StringBasis VALO01_GERAL { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
            /*"    05 COD02-GERAL                      PIC X(08) VALUE SPACES.*/
            public StringBasis COD02_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 VALO02-GERAL                     PIC X(23) VALUE SPACES                       JUST RIGHT.*/
            public StringBasis VALO02_GERAL { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
            /*"    05 COD03-GERAL                      PIC X(08) VALUE SPACES.*/
            public StringBasis COD03_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 VALO03-GERAL                     PIC X(23) VALUE SPACES                       JUST RIGHT.*/
            public StringBasis VALO03_GERAL { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
            /*"    05 COD04-GERAL                      PIC X(08) VALUE SPACES.*/
            public StringBasis COD04_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 VALO04-GERAL                     PIC X(23) VALUE SPACES                       JUST RIGHT.*/
            public StringBasis VALO04_GERAL { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
            /*"    05 COD05-GERAL                      PIC X(08) VALUE SPACES.*/
            public StringBasis COD05_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 VALO05-GERAL                     PIC X(23) VALUE SPACES                       JUST RIGHT.*/
            public StringBasis VALO05_GERAL { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
            /*"    05 COD06-GERAL                      PIC X(08) VALUE SPACES.*/
            public StringBasis COD06_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 VALO06-GERAL                     PIC X(23) VALUE SPACES                       JUST RIGHT.*/
            public StringBasis VALO06_GERAL { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
            /*"    05 COD07-GERAL                      PIC X(08) VALUE SPACES.*/
            public StringBasis COD07_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 VALO07-GERAL                     PIC X(23) VALUE SPACES                       JUST RIGHT.*/
            public StringBasis VALO07_GERAL { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
            /*"    05 COD08-GERAL                      PIC X(08) VALUE SPACES.*/
            public StringBasis COD08_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 VALO08-GERAL                     PIC X(23) VALUE SPACES                       JUST RIGHT.*/
            public StringBasis VALO08_GERAL { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
            /*"    05 COD09-GERAL                      PIC X(08) VALUE SPACES.*/
            public StringBasis COD09_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 VALO09-GERAL                     PIC X(23) VALUE SPACES                       JUST RIGHT.*/
            public StringBasis VALO09_GERAL { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
            /*"    05 COD010-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis COD010_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 VALO010-GERAL                    PIC X(23) VALUE SPACES                       JUST RIGHT.*/
            public StringBasis VALO010_GERAL { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
            /*"    05 COD011-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis COD011_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 VALO011-GERAL                    PIC X(23) VALUE SPACES                       JUST RIGHT.*/
            public StringBasis VALO011_GERAL { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
            /*"    05 COD012-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis COD012_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 VALO012-GERAL                    PIC X(23) VALUE SPACES                       JUST RIGHT.*/
            public StringBasis VALO012_GERAL { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
            /*"    05 COD013-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis COD013_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 VALO013-GERAL                    PIC X(23) VALUE SPACES                       JUST RIGHT.*/
            public StringBasis VALO013_GERAL { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
            /*"    05 COD014-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis COD014_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 VALO014-GERAL                    PIC X(23) VALUE SPACES                       JUST RIGHT.*/
            public StringBasis VALO014_GERAL { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
            /*"    05 COD015-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis COD015_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 VALO015-GERAL                    PIC X(23) VALUE SPACES                       JUST RIGHT.*/
            public StringBasis VALO015_GERAL { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
            /*"    05 COD016-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis COD016_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 VALO016-GERAL                    PIC X(23) VALUE SPACES                       JUST RIGHT.*/
            public StringBasis VALO016_GERAL { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
            /*"    05 COD017-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis COD017_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 VALO017-GERAL                    PIC X(23) VALUE SPACES                       JUST RIGHT.*/
            public StringBasis VALO017_GERAL { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
            /*"    05 COD018-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis COD018_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 VALO018-GERAL                    PIC X(23) VALUE SPACES                       JUST RIGHT.*/
            public StringBasis VALO018_GERAL { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
            /*"    05 COD019-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis COD019_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 VALO019-GERAL                    PIC X(23) VALUE SPACES                       JUST RIGHT.*/
            public StringBasis VALO019_GERAL { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
            /*"    05 COD020-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis COD020_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 VALO020-GERAL                    PIC X(23) VALUE SPACES                       JUST RIGHT.*/
            public StringBasis VALO020_GERAL { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
            /*"    05 COD021-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis COD021_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 VALO021-GERAL                    PIC X(23) VALUE SPACES                       JUST RIGHT.*/
            public StringBasis VALO021_GERAL { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
            /*"    05 COD022-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis COD022_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 VALO022-GERAL                    PIC X(23) VALUE SPACES                       JUST RIGHT.*/
            public StringBasis VALO022_GERAL { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
            /*"    05 COD023-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis COD023_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 VALO023-GERAL                    PIC X(23) VALUE SPACES                       JUST RIGHT.*/
            public StringBasis VALO023_GERAL { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
            /*"    05 COD024-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis COD024_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 VALO024-GERAL                    PIC X(23) VALUE SPACES                       JUST RIGHT.*/
            public StringBasis VALO024_GERAL { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
            /*"    05 COD025-GERAL                     PIC X(08) VALUE SPACES.*/
            public StringBasis COD025_GERAL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05 VALO025-GERAL                    PIC X(23) VALUE SPACES                       JUST RIGHT.*/
            public StringBasis VALO025_GERAL { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
            /*"    05 CODEMP-GERAL                     PIC X(04) VALUE SPACES.*/
            public StringBasis CODEMP_GERAL { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
            /*"    05 MOEDABP-GERAL                    PIC X(05) VALUE SPACES.*/
            public StringBasis MOEDABP_GERAL { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
            /*"    05 NATPERS-GERAL                    PIC X(01) VALUE SPACES.*/
            public StringBasis NATPERS_GERAL { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"    05 TITLE-MEDI-GERAL                 PIC X(30) VALUE SPACES.*/
            public StringBasis TITLE_MEDI_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"    05 NAME-ORG1-GERAL                  PIC X(40) VALUE SPACES.*/
            public StringBasis NAME_ORG1_GERAL { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
            /*"    05 NAME-FIRST-GERAL                 PIC X(40) VALUE SPACES.*/
            public StringBasis NAME_FIRST_GERAL { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
            /*"    05 NAME-LAST-GERAL                  PIC X(40) VALUE SPACES.*/
            public StringBasis NAME_LAST_GERAL { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
            /*"    05 TAXTYPE-CPF-GERAL                PIC X(04) VALUE SPACES.*/
            public StringBasis TAXTYPE_CPF_GERAL { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
            /*"    05 TAXNUM-CPF-GERAL                 PIC X(20) VALUE SPACES.*/
            public StringBasis TAXNUM_CPF_GERAL { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"");
            /*"    05 TAXTYPE-CNPJ-GERAL               PIC X(04) VALUE SPACES.*/
            public StringBasis TAXTYPE_CNPJ_GERAL { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
            /*"    05 TAXNUM-CNPJ-GERAL                PIC X(20) VALUE SPACES.*/
            public StringBasis TAXNUM_CNPJ_GERAL { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"");
            /*"    05 TAXTYPE-INSCRM-GERAL             PIC X(04) VALUE SPACES.*/
            public StringBasis TAXTYPE_INSCRM_GERAL { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
            /*"    05 TAXNUM-INSCRM-GERAL              PIC X(20) VALUE SPACES.*/
            public StringBasis TAXNUM_INSCRM_GERAL { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"");
            /*"    05 TAXTYPE-INSCRE-GERAL             PIC X(04) VALUE SPACES.*/
            public StringBasis TAXTYPE_INSCRE_GERAL { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
            /*"    05 TAXNUM-INSCRE-GERAL              PIC X(20) VALUE SPACES.*/
            public StringBasis TAXNUM_INSCRE_GERAL { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"");
            /*"    05 STREET-FSCL-GERAL                PIC X(60) VALUE SPACES.*/
            public StringBasis STREET_FSCL_GERAL { get; set; } = new StringBasis(new PIC("X", "60", "X(60)"), @"");
            /*"    05 HOUSE-NUM1-FSCL-GERAL            PIC X(10) VALUE SPACES.*/
            public StringBasis HOUSE_NUM1_FSCL_GERAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"    05 HOUSE-NUM2-FSCL-GERAL            PIC X(10) VALUE SPACES.*/
            public StringBasis HOUSE_NUM2_FSCL_GERAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"    05 POST-CODE1-FSCL-GERAL            PIC X(10) VALUE SPACES.*/
            public StringBasis POST_CODE1_FSCL_GERAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"    05 REGION-FSCL-GERAL                PIC X(03) VALUE SPACES.*/
            public StringBasis REGION_FSCL_GERAL { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
            /*"    05 CITY1-FSCL-GERAL                 PIC X(40) VALUE SPACES.*/
            public StringBasis CITY1_FSCL_GERAL { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
            /*"    05 CITY2-FSCL-GERAL                 PIC X(40) VALUE SPACES.*/
            public StringBasis CITY2_FSCL_GERAL { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
            /*"    05 COUNTRY-FSCL-GERAL               PIC X(03) VALUE SPACES.*/
            public StringBasis COUNTRY_FSCL_GERAL { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
            /*"    05 STREET-COR-GERAL                 PIC X(60) VALUE SPACES.*/
            public StringBasis STREET_COR_GERAL { get; set; } = new StringBasis(new PIC("X", "60", "X(60)"), @"");
            /*"    05 HOUSE-NUM1-COR-GERAL             PIC X(10) VALUE SPACES.*/
            public StringBasis HOUSE_NUM1_COR_GERAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"    05 HOUSE-NUM2-COR-GERAL             PIC X(10) VALUE SPACES.*/
            public StringBasis HOUSE_NUM2_COR_GERAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"    05 POST-CODE1-COR-GERAL             PIC X(10) VALUE SPACES.*/
            public StringBasis POST_CODE1_COR_GERAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"    05 REGION-COR-GERAL                 PIC X(03) VALUE SPACES.*/
            public StringBasis REGION_COR_GERAL { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
            /*"    05 CITY1-COR-GERAL                  PIC X(40) VALUE SPACES.*/
            public StringBasis CITY1_COR_GERAL { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
            /*"    05 CITY2-COR-GERAL                  PIC X(40) VALUE SPACES.*/
            public StringBasis CITY2_COR_GERAL { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
            /*"    05 COUNTRY-COR-GERAL                PIC X(03) VALUE SPACES.*/
            public StringBasis COUNTRY_COR_GERAL { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
            /*"    05 LANGUCORR-GERAL                  PIC X(02) VALUE SPACES.*/
            public StringBasis LANGUCORR_GERAL { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
            /*"    05 LANGU-GERAL                      PIC X(01) VALUE SPACES.*/
            public StringBasis LANGU_GERAL { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"    05 SMTP-ADDR-GERAL                  PIC X(241) VALUE SPACES.*/
            public StringBasis SMTP_ADDR_GERAL { get; set; } = new StringBasis(new PIC("X", "241", "X(241)"), @"");
            /*"    05 TEL-NUMBER-GERAL                 PIC X(30) VALUE SPACES.*/
            public StringBasis TEL_NUMBER_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"    05 FAX-NUMBER-GERAL                 PIC X(30) VALUE SPACES.*/
            public StringBasis FAX_NUMBER_GERAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"    05 BANKS-GERAL                      PIC X(03) VALUE SPACES.*/
            public StringBasis BANKS_GERAL { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
            /*"    05 BANKK-GERAL                      PIC X(15) VALUE SPACES.*/
            public StringBasis BANKK_GERAL { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"");
            /*"    05 BKONT-GERAL                      PIC X(02) VALUE '00'.*/
            public StringBasis BKONT_GERAL { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"00");
            /*"    05 BANKN-GERAL                      PIC X(18) VALUE SPACES.*/
            public StringBasis BANKN_GERAL { get; set; } = new StringBasis(new PIC("X", "18", "X(18)"), @"");
            /*"    05 BKREF-GERAL                      PIC X(20) VALUE SPACES.*/
            public StringBasis BKREF_GERAL { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"");
            /*"    05 KOINH-GERAL                      PIC X(60) VALUE SPACES.*/
            public StringBasis KOINH_GERAL { get; set; } = new StringBasis(new PIC("X", "60", "X(60)"), @"");
            /*"    05 XEZER-GERAL                      PIC X(01) VALUE SPACES.*/
            public StringBasis XEZER_GERAL { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"    05 CCINS-GERAL                      PIC X(04) VALUE SPACES.*/
            public StringBasis CCINS_GERAL { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
            /*"    05 CCNUM-GERAL                      PIC X(25) VALUE SPACES.*/
            public StringBasis CCNUM_GERAL { get; set; } = new StringBasis(new PIC("X", "25", "X(25)"), @"");
            /*"    05 CCDEF-GERAL                      PIC X(01) VALUE SPACES.*/
            public StringBasis CCDEF_GERAL { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"    05 ZWELS-GERAL                      PIC X(10) VALUE SPACES.*/
            public StringBasis ZWELS_GERAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"    05 FPAG-GERAL                       PIC X(01) VALUE SPACES.*/
            public StringBasis FPAG_GERAL { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"    05 FREC-GERAL                       PIC X(01) VALUE SPACES.*/
            public StringBasis FREC_GERAL { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"    05 ZNIT-TYPE-GERAL                  PIC X(06) VALUE SPACES.*/
            public StringBasis ZNIT_TYPE_GERAL { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"");
            /*"    05 ZNIT-GERAL                       PIC X(60) VALUE SPACES.*/
            public StringBasis ZNIT_GERAL { get; set; } = new StringBasis(new PIC("X", "60", "X(60)"), @"");
            /*"    05 ZCBO-TYPE-GERAL                  PIC X(06) VALUE SPACES.*/
            public StringBasis ZCBO_TYPE_GERAL { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"");
            /*"    05 ZCBO-GERAL                       PIC X(60) VALUE SPACES.*/
            public StringBasis ZCBO_GERAL { get; set; } = new StringBasis(new PIC("X", "60", "X(60)"), @"");
            /*"    05 OP-SIMPL-FED-GERAL               PIC X(05) VALUE SPACES.*/
            public StringBasis OP_SIMPL_FED_GERAL { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
            /*"01          WABEND.*/
        }
        public SISAP15B_WABEND WABEND { get; set; } = new SISAP15B_WABEND();
        public class SISAP15B_WABEND : VarBasis
        {
            /*"  05        FILLER              PIC  X(010)     VALUE           ' SISAP15B'.*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SISAP15B");
            /*"  05        FILLER              PIC  X(026)     VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"  05        WNR-EXEC-SQL        PIC  X(004)     VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"  05        FILLER              PIC  X(013)     VALUE           ' *** SQLCODE '.*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"  05        WSQLCODE            PIC  ZZZZZ999-  VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            /*"01  REG-LK-BANCOS.*/
        }
        public SISAP15B_REG_LK_BANCOS REG_LK_BANCOS { get; set; } = new SISAP15B_REG_LK_BANCOS();
        public class SISAP15B_REG_LK_BANCOS : VarBasis
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
            /*"    05        CT0007SW099.*/
            public SISAP15B_CT0007SW099 CT0007SW099 { get; set; } = new SISAP15B_CT0007SW099();
            public class SISAP15B_CT0007SW099 : VarBasis
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
        public SISAP15B_PARAMETROS_GE PARAMETROS_GE { get; set; } = new SISAP15B_PARAMETROS_GE();
        public class SISAP15B_PARAMETROS_GE : VarBasis
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
            /*"01  REGISTRO-LINKAGE-GE0300B.*/
        }
        public SISAP15B_REGISTRO_LINKAGE_GE0300B REGISTRO_LINKAGE_GE0300B { get; set; } = new SISAP15B_REGISTRO_LINKAGE_GE0300B();
        public class SISAP15B_REGISTRO_LINKAGE_GE0300B : VarBasis
        {
            /*"    05 LK-GE0300B-FUNCAO                  PIC  9(02).*/
            public IntBasis LK_GE0300B_FUNCAO { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    05 LK-GE0300B-IDLG                    PIC  X(40).*/
            public StringBasis LK_GE0300B_IDLG { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"    05 LK-GE0300B-DATA-MOV-ABERTO         PIC  X(10).*/
            public StringBasis LK_GE0300B_DATA_MOV_ABERTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 LK-GE0300B-IDE-SISTEMA             PIC  X(02).*/
            public StringBasis LK_GE0300B_IDE_SISTEMA { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
            /*"    05 LK-GE0300B-NUM-ESTRUTURA           PIC S9(04) COMP.*/
            public IntBasis LK_GE0300B_NUM_ESTRUTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 LK-GE0300B-NUM-APOLICE             piC S9(13) COMP-3.*/
            public IntBasis LK_GE0300B_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "0", "05"));
            /*"    05 LK-GE0300B-NUM-ENDOSSO             PIC S9(09) COMP.*/
            public IntBasis LK_GE0300B_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"    05 LK-GE0300B-NUM-PARCELA             PIC S9(04) COMP.*/
            public IntBasis LK_GE0300B_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 LK-GE0300B-NUM-NOSSO-TITULO        PIC S9(16) COMP-3.*/
            public IntBasis LK_GE0300B_NUM_NOSSO_TITULO { get; set; } = new IntBasis(new PIC("S9", "16", "S9(16)"));
            /*"    05 LK-GE0300B-NUM-OCORR-HISTORICO     PIC S9(04) COMP.*/
            public IntBasis LK_GE0300B_NUM_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 LK-GE0300B-NUM-APOL-SINISTRO       PIC S9(13) COMP-3.*/
            public IntBasis LK_GE0300B_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
            /*"    05 LK-GE0300B-COD-OPERACAO            PIC S9(04) COMP.*/
            public IntBasis LK_GE0300B_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 LK-GE0300B-NUM-RESSARC             PIC S9(09) COMP.*/
            public IntBasis LK_GE0300B_NUM_RESSARC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"    05 LK-GE0300B-SEQ-RESSARC             PIC S9(04) COMP.*/
            public IntBasis LK_GE0300B_SEQ_RESSARC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 LK-GE0300B-NSAS                    PIC S9(04) COMP.*/
            public IntBasis LK_GE0300B_NSAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 LK-GE0300B-NUM-CHEQUE-INTERNO      PIC S9(09) COMP.*/
            public IntBasis LK_GE0300B_NUM_CHEQUE_INTERNO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"    05 LK-GE0300B-COD-CONVENIO            PIC S9(09) COMP.*/
            public IntBasis LK_GE0300B_COD_CONVENIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"    05 LK-GE0300B-NUM-CERTIFICADO         PIC S9(15) COMP-3.*/
            public IntBasis LK_GE0300B_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
            /*"    05 LK-GE0300B-CHR-USO-EMPRESA         PIC  X(200).*/
            public StringBasis LK_GE0300B_CHR_USO_EMPRESA { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");
            /*"    05 LK-GE0300B-REGISTRO                PIC  X(4834).*/
            public StringBasis LK_GE0300B_REGISTRO { get; set; } = new StringBasis(new PIC("X", "4834", "X(4834)."), @"");
            /*"    05 LK-GE0300B-COD-RETORNO             PIC  X(01).*/
            public StringBasis LK_GE0300B_COD_RETORNO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 LK-GE0300B-MENSAGEM.*/
            public SISAP15B_LK_GE0300B_MENSAGEM LK_GE0300B_MENSAGEM { get; set; } = new SISAP15B_LK_GE0300B_MENSAGEM();
            public class SISAP15B_LK_GE0300B_MENSAGEM : VarBasis
            {
                /*"       10 LK-GE0300B-SQLCODE              PIC   -ZZ9.*/
                public IntBasis LK_GE0300B_SQLCODE { get; set; } = new IntBasis(new PIC("9", "3", "-ZZ9."));
                /*"       10 FILLER                          PIC  X(01).*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10 LK-GE0300B-MENSAGEM-RETORNO     PIC  X(75).*/
                public StringBasis LK_GE0300B_MENSAGEM_RETORNO { get; set; } = new StringBasis(new PIC("X", "75", "X(75)."), @"");
                /*"01  W-TIPO-E-CPF-CNPJ.*/
            }
        }
        public SISAP15B_W_TIPO_E_CPF_CNPJ W_TIPO_E_CPF_CNPJ { get; set; } = new SISAP15B_W_TIPO_E_CPF_CNPJ();
        public class SISAP15B_W_TIPO_E_CPF_CNPJ : VarBasis
        {
            /*"    05 W-SE-EH-PF-PJ                 PIC  X(02).*/
            public StringBasis W_SE_EH_PF_PJ { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
            /*"    05 W-CPF-CNPJ-MUTUARIO           PIC  9(14).*/
            public IntBasis W_CPF_CNPJ_MUTUARIO { get; set; } = new IntBasis(new PIC("9", "14", "9(14)."));
            /*"    05 FILLER                        PIC  X(64).*/
            public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "64", "X(64)."), @"");
            /*"01  REGISTRO-LINKAGE-SAP.*/
        }
        public SISAP15B_REGISTRO_LINKAGE_SAP REGISTRO_LINKAGE_SAP { get; set; } = new SISAP15B_REGISTRO_LINKAGE_SAP();
        public class SISAP15B_REGISTRO_LINKAGE_SAP : VarBasis
        {
            /*"    05 LK-SAP-NUM-APOLICE            PIC S9(13) COMP-3.*/
            public IntBasis LK_SAP_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
            /*"    05 LK-SAP-NUM-ENDOSSO            PIC S9(09) COMP.*/
            public IntBasis LK_SAP_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"    05 LK-SAP-NUM-PARCELA            PIC S9(04) COMP.*/
            public IntBasis LK_SAP_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 LK-SAP-COD-CONVENIO           PIC S9(09) COMP.*/
            public IntBasis LK_SAP_COD_CONVENIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"    05 LK-SAP-NSAS                   PIC S9(04) COMP.*/
            public IntBasis LK_SAP_NSAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 LK-SAP-SITUACAO-COBRANCA      PIC  X(01).*/
            public StringBasis LK_SAP_SITUACAO_COBRANCA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 LK-SAP-COD-BANCO              PIC S9(04) COMP.*/
            public IntBasis LK_SAP_COD_BANCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 LK-SAP-COD-AGENCIA            PIC  9(05).*/
            public IntBasis LK_SAP_COD_AGENCIA { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
            /*"    05 LK-SAP-DV-AGENCIA             PIC  X(01).*/
            public StringBasis LK_SAP_DV_AGENCIA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 LK-SAP-OPERACAO-CONTA         PIC  9(04).*/
            public IntBasis LK_SAP_OPERACAO_CONTA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"    05 LK-SAP-NUM-CONTA              PIC  9(12).*/
            public IntBasis LK_SAP_NUM_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(12)."));
            /*"    05 LK-SAP-DV-CONTA               PIC  X(01).*/
            public StringBasis LK_SAP_DV_CONTA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 LK-SAP-COD-PROGRAMA           PIC  X(08).*/
            public StringBasis LK_SAP_COD_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
            /*"    05 LK-SAP-FAVORECIDO.*/
            public SISAP15B_LK_SAP_FAVORECIDO LK_SAP_FAVORECIDO { get; set; } = new SISAP15B_LK_SAP_FAVORECIDO();
            public class SISAP15B_LK_SAP_FAVORECIDO : VarBasis
            {
                /*"       10 LK-SAP-NOME-FAVORECIDO     PIC  X(30).*/
                public StringBasis LK_SAP_NOME_FAVORECIDO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
                /*"       10 LK-SAP-NUM-DOC-EMPRESA     PIC  9(06).*/
                public IntBasis LK_SAP_NUM_DOC_EMPRESA { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
                /*"       10 LK-SAP-FILLER1             PIC  X(04).*/
                public StringBasis LK_SAP_FILLER1 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)."), @"");
                /*"    05 LK-SAP-DES-LOGRADOURO         PIC  X(30).*/
            }
            public StringBasis LK_SAP_DES_LOGRADOURO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
            /*"    05 LK-SAP-NUM-LOCAL              PIC  9(05).*/
            public IntBasis LK_SAP_NUM_LOCAL { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
            /*"    05 LK-SAP-DES-COMPLEMENTO        PIC  X(15).*/
            public StringBasis LK_SAP_DES_COMPLEMENTO { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
            /*"    05 LK-SAP-DES-BAIRRO             PIC  X(15).*/
            public StringBasis LK_SAP_DES_BAIRRO { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
            /*"    05 LK-SAP-DES-CIDADE             PIC  X(20).*/
            public StringBasis LK_SAP_DES_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
            /*"    05 LK-SAP-NUM-CEP                PIC  9(05).*/
            public IntBasis LK_SAP_NUM_CEP { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
            /*"    05 LK-SAP-DES-COMPL-CEP          PIC  X(03).*/
            public StringBasis LK_SAP_DES_COMPL_CEP { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
            /*"    05 LK-SAP-DES-SIGLA-UF           PIC  X(02).*/
            public StringBasis LK_SAP_DES_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
            /*"    05 LK-SAP-CHR-USO-EMPRESA.*/
            public SISAP15B_LK_SAP_CHR_USO_EMPRESA LK_SAP_CHR_USO_EMPRESA { get; set; } = new SISAP15B_LK_SAP_CHR_USO_EMPRESA();
            public class SISAP15B_LK_SAP_CHR_USO_EMPRESA : VarBasis
            {
                /*"       10 WS-USO-EMPRESA-SICOV-TXT1  PIC  X(40).*/
                public StringBasis WS_USO_EMPRESA_SICOV_TXT1_0 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"       10 FILLER                     PIC  X(01).*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10 WS-USO-EMPRESA-SICOV-25    PIC  X(25).*/
                public StringBasis WS_USO_EMPRESA_SICOV_25_0 { get; set; } = new StringBasis(new PIC("X", "25", "X(25)."), @"");
                /*"       10 FILLER                     PIC  X(01).*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10 WS-USO-EMPRESA-SICOV-TXT2  PIC  X(40).*/
                public StringBasis WS_USO_EMPRESA_SICOV_TXT2_0 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"       10 FILLER                     PIC  X(01).*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10 WS-USO-EMPRESA-SICOV-60    PIC  X(60).*/
                public StringBasis WS_USO_EMPRESA_SICOV_60_0 { get; set; } = new StringBasis(new PIC("X", "60", "X(60)."), @"");
                /*"       10 FILLER                     PIC  X(32).*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "32", "X(32)."), @"");
                /*"    05 LK-SAP-COD-DOCUMENTO-SIACC    PIC  X(15).*/
            }
            public StringBasis LK_SAP_COD_DOCUMENTO_SIACC { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
            /*"    05 LK-SAP-USO-EMPRESA-SIACC      PIC  X(40).*/
            public StringBasis LK_SAP_USO_EMPRESA_SIACC { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"    05 LK-SAP-COD-RETORNO            PIC  X(01).*/
            public StringBasis LK_SAP_COD_RETORNO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 LK-SAP-MENSAGEM-RETORNO       PIC  X(80).*/
            public StringBasis LK_SAP_MENSAGEM_RETORNO { get; set; } = new StringBasis(new PIC("X", "80", "X(80)."), @"");
            /*"    05 LK-SAP-REGISTRO               PIC  X(3503).*/
            public StringBasis LK_SAP_REGISTRO { get; set; } = new StringBasis(new PIC("X", "3503", "X(3503)."), @"");
        }


        public Dclgens.SIPROJUD SIPROJUD { get; set; } = new Dclgens.SIPROJUD();
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
        public Dclgens.OD003 OD003 { get; set; } = new Dclgens.OD003();
        public Dclgens.OD004 OD004 { get; set; } = new Dclgens.OD004();
        public Dclgens.OD005 OD005 { get; set; } = new Dclgens.OD005();
        public Dclgens.OD007 OD007 { get; set; } = new Dclgens.OD007();
        public Dclgens.GE366 GE366 { get; set; } = new Dclgens.GE366();
        public Dclgens.SI175 SI175 { get; set; } = new Dclgens.SI175();
        public Dclgens.GE368 GE368 { get; set; } = new Dclgens.GE368();
        public SISAP15B_LE_MOVDEBCE LE_MOVDEBCE { get; set; } = new SISAP15B_LE_MOVDEBCE();
        public SISAP15B_IMPOSTOS IMPOSTOS { get; set; } = new SISAP15B_IMPOSTOS();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(SISAP15B_REGISTRO_LINKAGE_SAP SISAP15B_REGISTRO_LINKAGE_SAP_P) //PROCEDURE DIVISION USING 
        /*REGISTRO_LINKAGE_SAP*/
        {
            try
            {
                this.REGISTRO_LINKAGE_SAP = SISAP15B_REGISTRO_LINKAGE_SAP_P;

                /*" -1738- INSPECT LK-SAP-SITUACAO-COBRANCA CONVERTING LOW-VALUES TO ' ' . */
                REGISTRO_LINKAGE_SAP.LK_SAP_SITUACAO_COBRANCA.Value = REGISTRO_LINKAGE_SAP.LK_SAP_SITUACAO_COBRANCA.Value.Replace("\0", " ");

                /*" -1740- INSPECT LK-SAP-DV-AGENCIA CONVERTING LOW-VALUES TO ' ' . */
                REGISTRO_LINKAGE_SAP.LK_SAP_DV_AGENCIA.Value = REGISTRO_LINKAGE_SAP.LK_SAP_DV_AGENCIA.Value.Replace("\0", " ");

                /*" -1742- INSPECT LK-SAP-DV-CONTA CONVERTING LOW-VALUES TO ' ' . */
                REGISTRO_LINKAGE_SAP.LK_SAP_DV_CONTA.Value = REGISTRO_LINKAGE_SAP.LK_SAP_DV_CONTA.Value.Replace("\0", " ");

                /*" -1744- INSPECT LK-SAP-COD-PROGRAMA CONVERTING LOW-VALUES TO ' ' . */
                REGISTRO_LINKAGE_SAP.LK_SAP_COD_PROGRAMA.Value = REGISTRO_LINKAGE_SAP.LK_SAP_COD_PROGRAMA.Value.Replace("\0", " ");

                /*" -1746- INSPECT LK-SAP-NOME-FAVORECIDO CONVERTING LOW-VALUES TO ' ' . */
                REGISTRO_LINKAGE_SAP.LK_SAP_FAVORECIDO.LK_SAP_NOME_FAVORECIDO.Value = REGISTRO_LINKAGE_SAP.LK_SAP_FAVORECIDO.LK_SAP_NOME_FAVORECIDO.Value.Replace("\0", " ");

                /*" -1748- INSPECT LK-SAP-FILLER1 CONVERTING LOW-VALUES TO ' ' . */
                REGISTRO_LINKAGE_SAP.LK_SAP_FAVORECIDO.LK_SAP_FILLER1.Value = REGISTRO_LINKAGE_SAP.LK_SAP_FAVORECIDO.LK_SAP_FILLER1.Value.Replace("\0", " ");

                /*" -1750- INSPECT LK-SAP-DES-LOGRADOURO CONVERTING LOW-VALUES TO ' ' . */
                REGISTRO_LINKAGE_SAP.LK_SAP_DES_LOGRADOURO.Value = REGISTRO_LINKAGE_SAP.LK_SAP_DES_LOGRADOURO.Value.Replace("\0", " ");

                /*" -1752- INSPECT LK-SAP-DES-COMPLEMENTO CONVERTING LOW-VALUES TO ' ' . */
                REGISTRO_LINKAGE_SAP.LK_SAP_DES_COMPLEMENTO.Value = REGISTRO_LINKAGE_SAP.LK_SAP_DES_COMPLEMENTO.Value.Replace("\0", " ");

                /*" -1754- INSPECT LK-SAP-DES-BAIRRO CONVERTING LOW-VALUES TO ' ' . */
                REGISTRO_LINKAGE_SAP.LK_SAP_DES_BAIRRO.Value = REGISTRO_LINKAGE_SAP.LK_SAP_DES_BAIRRO.Value.Replace("\0", " ");

                /*" -1756- INSPECT LK-SAP-DES-CIDADE CONVERTING LOW-VALUES TO ' ' . */
                REGISTRO_LINKAGE_SAP.LK_SAP_DES_CIDADE.Value = REGISTRO_LINKAGE_SAP.LK_SAP_DES_CIDADE.Value.Replace("\0", " ");

                /*" -1758- INSPECT LK-SAP-DES-COMPL-CEP CONVERTING LOW-VALUES TO ' ' . */
                REGISTRO_LINKAGE_SAP.LK_SAP_DES_COMPL_CEP.Value = REGISTRO_LINKAGE_SAP.LK_SAP_DES_COMPL_CEP.Value.Replace("\0", " ");

                /*" -1788- INSPECT LK-SAP-DES-SIGLA-UF CONVERTING LOW-VALUES TO ' ' . */
                REGISTRO_LINKAGE_SAP.LK_SAP_DES_SIGLA_UF.Value = REGISTRO_LINKAGE_SAP.LK_SAP_DES_SIGLA_UF.Value.Replace("\0", " ");

                /*" -1789- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -1791- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -1793- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -1804- DISPLAY 'SISAP15B VERSAO 025 - INICIO  PROCESSAMENTO EM  ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

                $"SISAP15B VERSAO 025 - INICIO  PROCESSAMENTO EM  {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
                .Display();

                /*" -1806- MOVE '0' TO LK-SAP-COD-RETORNO */
                _.Move("0", REGISTRO_LINKAGE_SAP.LK_SAP_COD_RETORNO);

                /*" -1808- IF (LK-SAP-COD-PROGRAMA NOT EQUAL 'FI0096B' ) AND (LK-SAP-COD-PROGRAMA NOT EQUAL 'SI5071B' ) */

                if ((REGISTRO_LINKAGE_SAP.LK_SAP_COD_PROGRAMA != "FI0096B") && (REGISTRO_LINKAGE_SAP.LK_SAP_COD_PROGRAMA != "SI5071B"))
                {

                    /*" -1811- MOVE SPACES TO LK-SAP-MENSAGEM-RETORNO. */
                    _.Move("", REGISTRO_LINKAGE_SAP.LK_SAP_MENSAGEM_RETORNO);
                }


                /*" -1820- PERFORM R0010-SELECT-SISTEMAS THRU R0010-EXIT. */

                R0010_SELECT_SISTEMAS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_EXIT*/


                /*" -1826- IF (LK-SAP-COD-PROGRAMA NOT EQUAL 'FI0096B' ) AND (LK-SAP-COD-PROGRAMA NOT EQUAL 'SI5071B' ) AND (LK-SAP-COD-PROGRAMA NOT EQUAL 'SI5067B' ) AND (LK-SAP-COD-PROGRAMA NOT EQUAL 'CB1061B' ) AND (LK-SAP-COD-PROGRAMA NOT EQUAL 'SI5001B' ) AND (LK-SAP-COD-PROGRAMA NOT EQUAL 'SI5002B' ) */

                if ((REGISTRO_LINKAGE_SAP.LK_SAP_COD_PROGRAMA != "FI0096B") && (REGISTRO_LINKAGE_SAP.LK_SAP_COD_PROGRAMA != "SI5071B") && (REGISTRO_LINKAGE_SAP.LK_SAP_COD_PROGRAMA != "SI5067B") && (REGISTRO_LINKAGE_SAP.LK_SAP_COD_PROGRAMA != "CB1061B") && (REGISTRO_LINKAGE_SAP.LK_SAP_COD_PROGRAMA != "SI5001B") && (REGISTRO_LINKAGE_SAP.LK_SAP_COD_PROGRAMA != "SI5002B"))
                {

                    /*" -1827- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -1828- DISPLAY '**********************************************' */
                    _.Display($"**********************************************");

                    /*" -1829- DISPLAY '*' */
                    _.Display($"*");

                    /*" -1830- DISPLAY '* ATENCAO: ROTINA DE SEGURANCAO DE GERACAO' */
                    _.Display($"* ATENCAO: ROTINA DE SEGURANCAO DE GERACAO");

                    /*" -1831- DISPLAY '* DO ARQUIVO A PARA O SAP' */
                    _.Display($"* DO ARQUIVO A PARA O SAP");

                    /*" -1832- DISPLAY '*' */
                    _.Display($"*");

                    /*" -1833- DISPLAY '* PROGRAMA CHAMADOR NAO PREVISTO NA SUB-ROTINA' */
                    _.Display($"* PROGRAMA CHAMADOR NAO PREVISTO NA SUB-ROTINA");

                    /*" -1834- DISPLAY '*' */
                    _.Display($"*");

                    /*" -1835- DISPLAY '* PROGRAMA: ' LK-SAP-COD-PROGRAMA */
                    _.Display($"* PROGRAMA: {REGISTRO_LINKAGE_SAP.LK_SAP_COD_PROGRAMA}");

                    /*" -1836- DISPLAY '*' */
                    _.Display($"*");

                    /*" -1837- DISPLAY '**********************************************' */
                    _.Display($"**********************************************");

                    /*" -1844- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO(); //GOTO
                    return Result;
                }


                /*" -1850- IF (LK-SAP-COD-CONVENIO NOT EQUAL 600128) AND (LK-SAP-COD-CONVENIO NOT EQUAL 600119) AND (LK-SAP-COD-CONVENIO NOT EQUAL 600120) AND (LK-SAP-COD-CONVENIO NOT EQUAL 600123) AND (LK-SAP-COD-CONVENIO NOT EQUAL 921286) AND (LK-SAP-COD-CONVENIO NOT EQUAL 43350) */

                if ((REGISTRO_LINKAGE_SAP.LK_SAP_COD_CONVENIO != 600128) && (REGISTRO_LINKAGE_SAP.LK_SAP_COD_CONVENIO != 600119) && (REGISTRO_LINKAGE_SAP.LK_SAP_COD_CONVENIO != 600120) && (REGISTRO_LINKAGE_SAP.LK_SAP_COD_CONVENIO != 600123) && (REGISTRO_LINKAGE_SAP.LK_SAP_COD_CONVENIO != 921286) && (REGISTRO_LINKAGE_SAP.LK_SAP_COD_CONVENIO != 43350))
                {

                    /*" -1851- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -1852- DISPLAY '**********************************************' */
                    _.Display($"**********************************************");

                    /*" -1853- DISPLAY '*' */
                    _.Display($"*");

                    /*" -1854- DISPLAY '* ATENCAO: ROTINA DE SEGURANCAO DE GERACAO' */
                    _.Display($"* ATENCAO: ROTINA DE SEGURANCAO DE GERACAO");

                    /*" -1855- DISPLAY '* DO ARQUIVO A PARA O SAP' */
                    _.Display($"* DO ARQUIVO A PARA O SAP");

                    /*" -1856- DISPLAY '*' */
                    _.Display($"*");

                    /*" -1857- DISPLAY '* CONVENIO NAO PREVISTO NA SUB-ROTINA' */
                    _.Display($"* CONVENIO NAO PREVISTO NA SUB-ROTINA");

                    /*" -1858- DISPLAY '*' */
                    _.Display($"*");

                    /*" -1859- DISPLAY '* CONVENIO: ' LK-SAP-COD-CONVENIO */
                    _.Display($"* CONVENIO: {REGISTRO_LINKAGE_SAP.LK_SAP_COD_CONVENIO}");

                    /*" -1860- DISPLAY '*' */
                    _.Display($"*");

                    /*" -1861- DISPLAY '**********************************************' */
                    _.Display($"**********************************************");

                    /*" -1863- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO(); //GOTO
                    return Result;
                }


                /*" -1865- PERFORM R0020-VALIDA-MOVDEBCE THRU R0020-EXIT. */

                R0020_VALIDA_MOVDEBCE(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_EXIT*/


                /*" -1867- MOVE 'NAO' TO WFIM-LE-MOVDEBCE-1. */
                _.Move("NAO", AREA_DE_WORK.WFIM_LE_MOVDEBCE_1);

                /*" -1868- PERFORM R0100-DECLARE-MOVDEBCE THRU R0100-EXIT. */

                R0100_DECLARE_MOVDEBCE(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_EXIT*/


                /*" -1870- PERFORM R0101-FETCH-MOVDEBCE THRU R0101-EXIT. */

                R0101_FETCH_MOVDEBCE(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0101_EXIT*/


                /*" -1871- PERFORM R0200-PROCESSA-PRINCIPAL THRU R0200-EXIT UNTIL WFIM-LE-MOVDEBCE-1 = 'SIM' . */

                while (!(AREA_DE_WORK.WFIM_LE_MOVDEBCE_1 == "SIM"))
                {

                    R0200_PROCESSA_PRINCIPAL(true);

                    R0200_MONTA_REGISTRO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_EXIT*/

                }

                /*" -1871- FLUXCONTROL_PERFORM R0000-90-FINALIZA */

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
            /*" -1877- PERFORM R9000-CLOSE-ARQUIVOS THRU R9000-EXIT. */
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_CLOSE_ARQUIVOS*/

            /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_EXIT*/


            /*" -1878- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -1879- MOVE '0' TO LK-SAP-COD-RETORNO */
            _.Move("0", REGISTRO_LINKAGE_SAP.LK_SAP_COD_RETORNO);

            /*" -1886- MOVE 'EXECUCAO COM SUCESSO' TO LK-SAP-MENSAGEM-RETORNO. */
            _.Move("EXECUCAO COM SUCESSO", REGISTRO_LINKAGE_SAP.LK_SAP_MENSAGEM_RETORNO);

            /*" -1886- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_SAIDA*/

        [StopWatch]
        /*" R0010-SELECT-SISTEMAS */
        private void R0010_SELECT_SISTEMAS(bool isPerform = false)
        {
            /*" -1904- PERFORM R0010_SELECT_SISTEMAS_DB_SELECT_1 */

            R0010_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -1907- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1908- DISPLAY 'SISAP15B - ERRO NO ACESSO SISTEMAS - FI' */
                _.Display($"SISAP15B - ERRO NO ACESSO SISTEMAS - FI");

                /*" -1910- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1918- PERFORM R0010_SELECT_SISTEMAS_DB_SELECT_2 */

            R0010_SELECT_SISTEMAS_DB_SELECT_2();

            /*" -1921- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1922- DISPLAY 'SISAP15B - ERRO NO ACESSO SISTEMAS - SI' */
                _.Display($"SISAP15B - ERRO NO ACESSO SISTEMAS - SI");

                /*" -1953- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1954- MOVE HOST-CURRENT-DATE(1:4) TO W-LOTE-DATE-AAAA. */
            _.Move(HOST_CURRENT_DATE.Substring(1, 4), AREA_DE_WORK.W_LOTE.W_LOTE_DATE_AAAA);

            /*" -1955- MOVE HOST-CURRENT-DATE(6:2) TO W-LOTE-DATE-MM. */
            _.Move(HOST_CURRENT_DATE.Substring(6, 2), AREA_DE_WORK.W_LOTE.W_LOTE_DATE_MM);

            /*" -1956- MOVE HOST-CURRENT-DATE(9:2) TO W-LOTE-DATE-DD. */
            _.Move(HOST_CURRENT_DATE.Substring(9, 2), AREA_DE_WORK.W_LOTE.W_LOTE_DATE_DD);

            /*" -1957- MOVE HOST-CURRENT-TIME(1:2) TO W-LOTE-TIME-HH. */
            _.Move(HOST_CURRENT_TIME.Substring(1, 2), AREA_DE_WORK.W_LOTE.W_LOTE_TIME_HH);

            /*" -1958- MOVE HOST-CURRENT-TIME(4:2) TO W-LOTE-TIME-MM. */
            _.Move(HOST_CURRENT_TIME.Substring(4, 2), AREA_DE_WORK.W_LOTE.W_LOTE_TIME_MM);

            /*" -1958- MOVE HOST-CURRENT-TIME(7:2) TO W-LOTE-TIME-SS. */
            _.Move(HOST_CURRENT_TIME.Substring(7, 2), AREA_DE_WORK.W_LOTE.W_LOTE_TIME_SS);

        }

        [StopWatch]
        /*" R0010-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0010_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -1904- EXEC SQL SELECT DATA_MOV_ABERTO, DATULT_PROCESSAMEN, CURRENT DATE, CURRENT TIME INTO :SISTEMAS-DATA-MOV-ABERTO, :SISTEMAS-DATULT-PROCESSAMEN, :HOST-CURRENT-DATE, :HOST-CURRENT-TIME FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'FI' WITH UR END-EXEC. */

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
            /*" -1918- EXEC SQL SELECT DATA_MOV_ABERTO, CURRENT DATE INTO :HOST-SI-DATA-MOV-ABERTO, :HOST-SI-CURRENT-DATE FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' WITH UR END-EXEC. */

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
            /*" -1968- IF LK-SAP-NUM-ENDOSSO =1081 */

            if (REGISTRO_LINKAGE_SAP.LK_SAP_NUM_ENDOSSO == 1081)
            {

                /*" -1971- DISPLAY ' INDENIZA APOLICE =' LK-SAP-NUM-APOLICE ' ENDO = ' LK-SAP-NUM-ENDOSSO ' PARC = ' LK-SAP-NUM-PARCELA */

                $" INDENIZA APOLICE ={REGISTRO_LINKAGE_SAP.LK_SAP_NUM_APOLICE} ENDO = {REGISTRO_LINKAGE_SAP.LK_SAP_NUM_ENDOSSO} PARC = {REGISTRO_LINKAGE_SAP.LK_SAP_NUM_PARCELA}"
                .Display();

                /*" -1972- END-IF */
            }


            /*" -1974- MOVE 0 TO HOST-COUNT. */
            _.Move(0, HOST_COUNT);

            /*" -1984- PERFORM R0020_VALIDA_MOVDEBCE_DB_SELECT_1 */

            R0020_VALIDA_MOVDEBCE_DB_SELECT_1();

            /*" -1994- DISPLAY 'ACHEI NA MOVDEBCE (VALIDACAO)-15 ' HOST-COUNT ' COM' ' APO X ' LK-SAP-NUM-APOLICE ' END X ' LK-SAP-NUM-ENDOSSO ' PAR X ' LK-SAP-NUM-PARCELA ' NSA X ' LK-SAP-NSAS ' SIT X ' LK-SAP-SITUACAO-COBRANCA. */

            $"ACHEI NA MOVDEBCE (VALIDACAO)-15 {HOST_COUNT} COM APO X {REGISTRO_LINKAGE_SAP.LK_SAP_NUM_APOLICE} END X {REGISTRO_LINKAGE_SAP.LK_SAP_NUM_ENDOSSO} PAR X {REGISTRO_LINKAGE_SAP.LK_SAP_NUM_PARCELA} NSA X {REGISTRO_LINKAGE_SAP.LK_SAP_NSAS} SIT X {REGISTRO_LINKAGE_SAP.LK_SAP_SITUACAO_COBRANCA}"
            .Display();

            /*" -1995- IF SQLCODE EQUAL 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -1996- IF HOST-COUNT EQUAL 0 */

                if (HOST_COUNT == 0)
                {

                    /*" -1997- DISPLAY 'SISAP15B - REGISTRO NAO ACHADO NA MOVDEBCE' */
                    _.Display($"SISAP15B - REGISTRO NAO ACHADO NA MOVDEBCE");

                    /*" -1999- DISPLAY 'LK-SAP-NUM-APOLICE ........ ' LK-SAP-NUM-APOLICE */
                    _.Display($"LK-SAP-NUM-APOLICE ........ {REGISTRO_LINKAGE_SAP.LK_SAP_NUM_APOLICE}");

                    /*" -2001- DISPLAY 'LK-SAP-NUM-ENDOSSO ........ ' LK-SAP-NUM-ENDOSSO */
                    _.Display($"LK-SAP-NUM-ENDOSSO ........ {REGISTRO_LINKAGE_SAP.LK_SAP_NUM_ENDOSSO}");

                    /*" -2003- DISPLAY 'LK-SAP-NUM-PARCELA ........ ' LK-SAP-NUM-PARCELA */
                    _.Display($"LK-SAP-NUM-PARCELA ........ {REGISTRO_LINKAGE_SAP.LK_SAP_NUM_PARCELA}");

                    /*" -2005- DISPLAY 'LK-SAP-NSAS ............... ' LK-SAP-NSAS */
                    _.Display($"LK-SAP-NSAS ............... {REGISTRO_LINKAGE_SAP.LK_SAP_NSAS}");

                    /*" -2007- DISPLAY 'LK-SAP-COD-CONVENIO ....... ' LK-SAP-COD-CONVENIO */
                    _.Display($"LK-SAP-COD-CONVENIO ....... {REGISTRO_LINKAGE_SAP.LK_SAP_COD_CONVENIO}");

                    /*" -2009- DISPLAY 'LK-SAP-SITUACAO-COBRANCA .. ' LK-SAP-SITUACAO-COBRANCA */
                    _.Display($"LK-SAP-SITUACAO-COBRANCA .. {REGISTRO_LINKAGE_SAP.LK_SAP_SITUACAO_COBRANCA}");

                    /*" -2010- MOVE '1' TO LK-SAP-COD-RETORNO */
                    _.Move("1", REGISTRO_LINKAGE_SAP.LK_SAP_COD_RETORNO);

                    /*" -2012- MOVE 'NAO FOI ENCONTRADO REG. NA MOVTO_DEBITOCC_CEF' TO LK-SAP-MENSAGEM-RETORNO */
                    _.Move("NAO FOI ENCONTRADO REG. NA MOVTO_DEBITOCC_CEF", REGISTRO_LINKAGE_SAP.LK_SAP_MENSAGEM_RETORNO);

                    /*" -2014- GO TO RXXXX-ROTINA-RETORNO. */

                    RXXXX_ROTINA_RETORNO(); //GOTO
                    return;
                }

            }


            /*" -2015- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -2016- DISPLAY 'SISAP15B - ERRO ACESSO MOVDEBCE - VALIDACAO' */
                _.Display($"SISAP15B - ERRO ACESSO MOVDEBCE - VALIDACAO");

                /*" -2016- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0020-VALIDA-MOVDEBCE-DB-SELECT-1 */
        public void R0020_VALIDA_MOVDEBCE_DB_SELECT_1()
        {
            /*" -1984- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :HOST-COUNT FROM SEGUROS.MOVTO_DEBITOCC_CEF MO WHERE MO.NUM_APOLICE = :LK-SAP-NUM-APOLICE AND MO.NUM_ENDOSSO = :LK-SAP-NUM-ENDOSSO AND MO.NUM_PARCELA = :LK-SAP-NUM-PARCELA AND MO.NSAS = :LK-SAP-NSAS AND MO.SITUACAO_COBRANCA = :LK-SAP-SITUACAO-COBRANCA AND MO.COD_CONVENIO = :LK-SAP-COD-CONVENIO END-EXEC. */

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
            /*" -2024- MOVE 0 TO W-AC-LIDOS-MOVDEBCE */
            _.Move(0, AREA_DE_WORK.W_AC_LIDOS_MOVDEBCE);

            /*" -2416- PERFORM R0100_DECLARE_MOVDEBCE_DB_DECLARE_1 */

            R0100_DECLARE_MOVDEBCE_DB_DECLARE_1();

            /*" -2418- PERFORM R0100_DECLARE_MOVDEBCE_DB_OPEN_1 */

            R0100_DECLARE_MOVDEBCE_DB_OPEN_1();

            /*" -2421- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -2422- DISPLAY 'SISAP15B - ERRO CURSOR LE_MOVDEBCE' */
                _.Display($"SISAP15B - ERRO CURSOR LE_MOVDEBCE");

                /*" -2422- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0100-DECLARE-MOVDEBCE-DB-DECLARE-1 */
        public void R0100_DECLARE_MOVDEBCE_DB_DECLARE_1()
        {
            /*" -2416- EXEC SQL DECLARE LE_MOVDEBCE CURSOR FOR SELECT 'CRED/DEB 1 - CONV 600128 - SIN, 43350 - RESS.,921286 - BB' , H.TIPO_REGISTRO AS 'TIPO SEGURO' , CASE H.TIPO_REGISTRO WHEN '0' THEN 'COSSEGURO ACEITO' WHEN '1' THEN 'NOSSA LIDERANCA ' END AS 'NOME TIPO SEGURO' , H.NUM_APOLICE AS 'NUM APOLICE' , H.NUM_APOL_SINISTRO AS 'NUM SINISTRO' , H.OCORR_HISTORICO AS 'OCORRHIST' , H.COD_OPERACAO AS 'OPERACAO' , H.NOME_FAVORECIDO AS 'NOME FAVORECIDO - HISTSINI' , YEAR(H.DATA_MOVIMENTO) AS 'ANO OPERACIONAL DO PAGAMENTO' , YEAR(SIS.DATA_MOV_ABERTO) AS 'ANO CONTABIL DO PAGAMENTO' , OPE.FUNCAO_OPERACAO AS 'FUNCAO OPERACAO' , SUBSTR(OPE.DES_OPERACAO,1,30) AS 'NOME OPERACAO' , ABS(H.VAL_OPERACAO) AS 'VALOR BRUTO' , MO.VLR_CREDITO AS 'MOV. VALOR CREDITO' , MO.VALOR_DEBITO AS 'MOV. VALOR DEBITO' , H.DATA_MOVIMENTO AS 'DATA BAIXA PELA TESOURARIA' , H.COD_PREST_SERVICO AS 'COD DA FORNECEDORES' , H.COD_SERVICO AS 'COD DO SERVICO' , H.SIT_CONTABIL AS 'FORMA PAGAMENTO' , CASE H.SIT_CONTABIL WHEN '1' THEN 'CHEQUE PAPEL     ' WHEN '2' THEN 'CREDITO EM CONTA ' WHEN '7' THEN 'SIACC            ' END AS 'NOME FORMA PAGAMENTO' , H.NOM_PROGRAMA AS 'PGM GERADOR' , H.COD_USUARIO AS 'USUARIO QUE BAIXO PAGTO' , M.RAMO AS 'RAMO CXS' , M.COD_FONTE AS 'FONTE' , H1.DATA_MOVIMENTO AS 'DATA AVISO NO SIAS' , M.DATA_COMUNICADO AS 'DATA COMUNICADO NA CXS' , M.COD_PRODUTO AS 'PRODUTO' , PRO.DESCR_PRODUTO AS 'NOME PRODUTO' , SC.NUM_CHEQUE_INTERNO AS 'CHQINT' , MO.NUM_APOLICE AS 'MOV. APOLICE' , MO.NUM_ENDOSSO AS 'MOV. ENDOSSO' , MO.NUM_PARCELA AS 'MOV. PARCELA' , MO.SITUACAO_COBRANCA AS 'MOV. SITUACAO COBRANCA' , CASE MO.SITUACAO_COBRANCA WHEN ' ' THEN 'PEND. ENVIO 1                     ' WHEN '0' THEN 'PEND. ENVIO 2                     ' WHEN '1' THEN 'PEND. RETORNO                     ' WHEN '2' THEN 'CRD/DEB EFETUADO C/ SUCESSO       ' WHEN '3' THEN 'CRD/DEB NAO EFETUADO              ' WHEN '4' THEN 'CANCELADO A PEDIDO DO GCX AO BANCO' WHEN '6' THEN 'CRD C/ NAO EFETUADO - GERADO CHQ. ' END AS 'MOV. NOME SITUACAO COBRANCA' , MO.DATA_VENCIMENTO AS 'MOV. DATA CREDITO' , MO.DATA_MOVIMENTO AS 'MOV. DT. GERACAO MOVDEBCC' , MO.COD_AGENCIA_DEB AS 'MOV. AGENCIA' , MO.OPER_CONTA_DEB AS 'MOV. OPER CONTA' , MO.NUM_CONTA_DEB AS 'MOV. NUM. CONTA' , MO.DIG_CONTA_DEB AS 'MOV. DV CONTA' , MO.COD_CONVENIO AS 'MOV.CONVENIO' , MO.DATA_ENVIO AS 'MOV. DT. ENVIO SIAS P/ SAP' , MO.NSAS AS 'MOV. NSAS' , MO.NUM_REQUISICAO AS 'MOV. NUM. CHQ. INTERNO' , CONTA.COD_AGENCIA AS 'CONTA COD AGENCIA' , CONTA.COD_BANCO AS 'CONTA BANCO' , CONTA.NUM_CONTA_CNB AS 'CONTA NUM. CONTA' , CONTA.NUM_DV_CONTA_CNB AS 'CONTA DV CONTA' , CONTA.IND_CONTA_BANCARIA AS 'CONTA ACHO QUE OPERACAO CONTA' FROM SEGUROS.SISTEMAS SIS, SEGUROS.SINISTRO_HISTORICO H, SEGUROS.SINISTRO_MESTRE M, SEGUROS.SINISTRO_HISTORICO H1, SEGUROS.SI_SINI_CHEQUE SC, SEGUROS.GE_OPERACAO OPE, SEGUROS.PRODUTO PRO, SEGUROS.MOVTO_DEBITOCC_CEF MO LEFT JOIN SEGUROS.GE_MOVTO_CONTA CONTA ON CONTA.NUM_APOLICE = MO.NUM_APOLICE AND CONTA.NUM_ENDOSSO = MO.NUM_ENDOSSO AND CONTA.NUM_PARCELA = MO.NUM_PARCELA AND CONTA.COD_CONVENIO = MO.COD_CONVENIO AND CONTA.NSAS = MO.NSAS WHERE ( ( MO.COD_CONVENIO = 600128 ) OR ( MO.COD_CONVENIO = 43350 AND MO.NUM_ENDOSSO = 7777 AND MO.NUM_PARCELA = 7777 ) OR ( MO.COD_CONVENIO = 921286 AND MO.NUM_CARTAO <> 0 AND EXISTS (SELECT 1 FROM SEGUROS.SI_SINI_CHEQUE XX WHERE XX.NUM_APOL_SINISTRO = MO.NUM_APOLICE AND XX.OCORR_HISTORICO = MO.NUM_PARCELA AND XX.COD_OPERACAO = MO.NUM_ENDOSSO) ) ) AND MO.NUM_APOLICE = :LK-SAP-NUM-APOLICE AND MO.NUM_ENDOSSO = :LK-SAP-NUM-ENDOSSO AND MO.NUM_PARCELA = :LK-SAP-NUM-PARCELA AND MO.NSAS = :LK-SAP-NSAS AND MO.SITUACAO_COBRANCA = :LK-SAP-SITUACAO-COBRANCA AND SC.NUM_CHEQUE_INTERNO = INTEGER(MO.NUM_CARTAO) AND H.NUM_APOL_SINISTRO = SC.NUM_APOL_SINISTRO AND H.OCORR_HISTORICO = SC.OCORR_HISTORICO AND H.COD_OPERACAO = SC.COD_OPERACAO AND H.SIT_REGISTRO = '1' AND H.SIT_CONTABIL IN ( '2' , '7' ) AND OPE.IDE_SISTEMA = 'SI' AND OPE.COD_OPERACAO = H.COD_OPERACAO AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND PRO.COD_PRODUTO = M.COD_PRODUTO AND H1.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND H1.COD_OPERACAO = 101 AND H1.TIMESTAMP = (SELECT MIN(A.TIMESTAMP) FROM SEGUROS.SINISTRO_HISTORICO A WHERE A.NUM_APOL_SINISTRO = H1.NUM_APOL_SINISTRO AND A.OCORR_HISTORICO = H1.OCORR_HISTORICO AND A.COD_OPERACAO = H1.COD_OPERACAO) AND SIS.IDE_SISTEMA = 'FI' UNION ALL SELECT 'CRED/DEB 2 - CONV 600128 - SIN, 43350 - SIACC,921286 - BB' , H.TIPO_REGISTRO AS 'TIPO SEGURO' , CASE H.TIPO_REGISTRO WHEN '0' THEN 'COSSEGURO ACEITO' WHEN '1' THEN 'NOSSA LIDERANCA ' END AS 'NOME TIPO SEGURO' , H.NUM_APOLICE AS 'NUM APOLICE' , H.NUM_APOL_SINISTRO AS 'NUM SINISTRO' , H.OCORR_HISTORICO AS 'OCORRHIST' , H.COD_OPERACAO AS 'OPERACAO' , H.NOME_FAVORECIDO AS 'NOME FAVORECIDO - HISTSINI' , YEAR(H.DATA_MOVIMENTO) AS 'ANO OPERACIONAL DO PAGAMENTO' , YEAR(SIS.DATA_MOV_ABERTO) AS 'ANO CONTABIL DO PAGAMENTO' , OPE.FUNCAO_OPERACAO AS 'FUNCAO OPERACAO' , SUBSTR(OPE.DES_OPERACAO,1,30) AS 'NOME OPERACAO' , ABS(H.VAL_OPERACAO) AS 'VALOR BRUTO' , MO.VLR_CREDITO AS 'MOV. VALOR CREDITO' , MO.VALOR_DEBITO AS 'MOV. VALOR DEBITO' , H.DATA_MOVIMENTO AS 'DATA BAIXA PELA TESOURARIA' , H.COD_PREST_SERVICO AS 'COD DA FORNECEDORES' , H.COD_SERVICO AS 'COD DO SERVICO' , H.SIT_CONTABIL AS 'FORMA PAGAMENTO' , CASE H.SIT_CONTABIL WHEN '1' THEN 'CHEQUE PAPEL     ' WHEN '2' THEN 'CREDITO EM CONTA ' WHEN '7' THEN 'SIACC            ' END AS 'NOME FORMA PAGAMENTO' , H.NOM_PROGRAMA AS 'PGM GERADOR' , H.COD_USUARIO AS 'USUARIO QUE BAIXO PAGTO' , M.RAMO AS 'RAMO CXS' , M.COD_FONTE AS 'FONTE' , H1.DATA_MOVIMENTO AS 'DATA AVISO NO SIAS' , M.DATA_COMUNICADO AS 'DATA COMUNICADO NA CXS' , M.COD_PRODUTO AS 'PRODUTO' , PRO.DESCR_PRODUTO AS 'NOME PRODUTO' , SC.NUM_CHEQUE_INTERNO AS 'CHQINT' , MO.NUM_APOLICE AS 'MOV. APOLICE' , MO.NUM_ENDOSSO AS 'MOV. ENDOSSO' , MO.NUM_PARCELA AS 'MOV. PARCELA' , MO.SITUACAO_COBRANCA AS 'MOV. SITUACAO COBRANCA' , CASE MO.SITUACAO_COBRANCA WHEN ' ' THEN 'PEND. ENVIO 1                     ' WHEN '0' THEN 'PEND. ENVIO 2                     ' WHEN '1' THEN 'PEND. RETORNO                     ' WHEN '2' THEN 'CRD/DEB EFETUADO C/ SUCESSO       ' WHEN '3' THEN 'CRD/DEB NAO EFETUADO              ' WHEN '4' THEN 'CANCELADO A PEDIDO DO GCX AO BANCO' WHEN '6' THEN 'CRD C/ NAO EFETUADO - GERADO CHQ. ' END AS 'MOV. NOME SITUACAO COBRANCA' , MO.DATA_VENCIMENTO AS 'MOV. DATA CREDITO' , MO.DATA_MOVIMENTO AS 'MOV. DT. GERACAO MOVDEBCC' , MO.COD_AGENCIA_DEB AS 'MOV. AGENCIA' , MO.OPER_CONTA_DEB AS 'MOV. OPER CONTA' , MO.NUM_CONTA_DEB AS 'MOV. NUM. CONTA' , MO.DIG_CONTA_DEB AS 'MOV. DV CONTA' , MO.COD_CONVENIO AS 'MOV.CONVENIO' , MO.DATA_ENVIO AS 'MOV. DT. ENVIO SIAS P/ SAP' , MO.NSAS AS 'MOV. NSAS' , MO.NUM_REQUISICAO AS 'MOV. NUM. CHQ. INTERNO' , CONTA.COD_AGENCIA AS 'CONTA COD AGENCIA' , CONTA.COD_BANCO AS 'CONTA BANCO' , CONTA.NUM_CONTA_CNB AS 'CONTA NUM. CONTA' , CONTA.NUM_DV_CONTA_CNB AS 'CONTA DV CONTA' , CONTA.IND_CONTA_BANCARIA AS 'CONTA ACHO QUE OPERACAO CONTA' FROM SEGUROS.SISTEMAS SIS, SEGUROS.SINISTRO_HISTORICO H, SEGUROS.SINISTRO_MESTRE M, SEGUROS.SINISTRO_HISTORICO H1, SEGUROS.SI_SINI_CHEQUE SC, SEGUROS.GE_OPERACAO OPE, SEGUROS.PRODUTO PRO, SEGUROS.MOVTO_DEBITOCC_CEF MO LEFT JOIN SEGUROS.GE_MOVTO_CONTA CONTA ON CONTA.NUM_APOLICE = MO.NUM_APOLICE AND CONTA.NUM_ENDOSSO = MO.NUM_ENDOSSO AND CONTA.NUM_PARCELA = MO.NUM_PARCELA AND CONTA.COD_CONVENIO = MO.COD_CONVENIO AND CONTA.NSAS = MO.NSAS WHERE ( MO.COD_CONVENIO = 43350 AND EXISTS (SELECT 1 FROM SEGUROS.SINISTRO_HISTORICO YY WHERE YY.NUM_APOL_SINISTRO = MO.NUM_APOLICE AND YY.OCORR_HISTORICO = MO.NUM_PARCELA AND YY.COD_OPERACAO = MO.NUM_ENDOSSO - YY.COD_PRODUTO * 10000) ) AND MO.NUM_APOLICE = :LK-SAP-NUM-APOLICE AND MO.NUM_ENDOSSO = :LK-SAP-NUM-ENDOSSO AND MO.NUM_PARCELA = :LK-SAP-NUM-PARCELA AND MO.NSAS = :LK-SAP-NSAS AND MO.SITUACAO_COBRANCA = :LK-SAP-SITUACAO-COBRANCA AND MO.NUM_PARCELA <> 7777 AND MO.NUM_ENDOSSO <> 7777 AND H.NUM_APOL_SINISTRO = MO.NUM_APOLICE AND H.OCORR_HISTORICO = MO.NUM_PARCELA AND H.COD_OPERACAO = MO.NUM_ENDOSSO - H.COD_PRODUTO * 10000 AND H.SIT_REGISTRO = '1' AND H.SIT_CONTABIL IN ( '2' , '7' ) AND SC.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND SC.OCORR_HISTORICO = H.OCORR_HISTORICO AND SC.COD_OPERACAO = H.COD_OPERACAO AND OPE.IDE_SISTEMA = 'SI' AND OPE.COD_OPERACAO = H.COD_OPERACAO AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND PRO.COD_PRODUTO = M.COD_PRODUTO AND H1.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND H1.COD_OPERACAO = 101 AND H1.TIMESTAMP = (SELECT MIN(A.TIMESTAMP) FROM SEGUROS.SINISTRO_HISTORICO A WHERE A.NUM_APOL_SINISTRO = H1.NUM_APOL_SINISTRO AND A.OCORR_HISTORICO = H1.OCORR_HISTORICO AND A.COD_OPERACAO = H1.COD_OPERACAO) AND SIS.IDE_SISTEMA = 'FI' UNION ALL SELECT 'CRED/DEB 3 - 600119, 600120, 600123 - LOTERICO' , H.TIPO_REGISTRO AS 'TIPO SEGURO' , CASE H.TIPO_REGISTRO WHEN '0' THEN 'COSSEGURO ACEITO' WHEN '1' THEN 'NOSSA LIDERANCA ' END AS 'NOME TIPO SEGURO' , H.NUM_APOLICE AS 'NUM APOLICE' , H.NUM_APOL_SINISTRO AS 'NUM SINISTRO' , H.OCORR_HISTORICO AS 'OCORRHIST' , H.COD_OPERACAO AS 'OPERACAO' , H.NOME_FAVORECIDO AS 'NOME FAVORECIDO - HISTSINI' , YEAR(H.DATA_MOVIMENTO) AS 'ANO OPERACIONAL DO PAGAMENTO' , YEAR(SIS.DATA_MOV_ABERTO) AS 'ANO CONTABIL DO PAGAMENTO' , OPE.FUNCAO_OPERACAO AS 'FUNCAO OPERACAO' , SUBSTR(OPE.DES_OPERACAO,1,30) AS 'NOME OPERACAO' , H.VAL_OPERACAO AS 'VALOR BRUTO' , MO.VLR_CREDITO AS 'MOV. VALOR CREDITO' , MO.VALOR_DEBITO AS 'MOV. VALOR DEBITO' , H.DATA_MOVIMENTO AS 'DATA BAIXA PELA TESOURARIA' , H.COD_PREST_SERVICO AS 'COD DA FORNECEDORES' , H.COD_SERVICO AS 'COD DO SERVICO' , H.SIT_CONTABIL AS 'FORMA PAGAMENTO' , CASE H.SIT_CONTABIL WHEN '1' THEN 'CHEQUE PAPEL     ' WHEN '2' THEN 'CREDITO EM CONTA ' WHEN '7' THEN 'SIACC            ' END AS 'NOME FORMA PAGAMENTO' , H.NOM_PROGRAMA AS 'PGM GERADOR' , H.COD_USUARIO AS 'USUARIO QUE BAIXO PAGTO' , M.RAMO AS 'RAMO CXS' , M.COD_FONTE AS 'FONTE' , H1.DATA_MOVIMENTO AS 'DATA AVISO NO SIAS' , M.DATA_COMUNICADO AS 'DATA COMUNICADO NA CXS' , M.COD_PRODUTO AS 'PRODUTO' , PRO.DESCR_PRODUTO AS 'NOME PRODUTO' , 0 AS 'CHQINT' , MO.NUM_APOLICE AS 'MOV. APOLICE' , MO.NUM_ENDOSSO AS 'MOV. ENDOSSO' , MO.NUM_PARCELA AS 'MOV. PARCELA' , MO.SITUACAO_COBRANCA AS 'MOV. SITUACAO COBRANCA' , CASE MO.SITUACAO_COBRANCA WHEN ' ' THEN 'PEND. ENVIO 1                     ' WHEN '0' THEN 'PEND. ENVIO 2                     ' WHEN '1' THEN 'PEND. RETORNO                     ' WHEN '2' THEN 'CRD/DEB EFETUADO C/ SUCESSO       ' WHEN '3' THEN 'CRD/DEB NAO EFETUADO              ' WHEN '4' THEN 'CANCELADO A PEDIDO DO GCX AO BANCO' WHEN '6' THEN 'CRD C/ NAO EFETUADO - GERADO CHQ. ' END AS 'MOV. NOME SITUACAO COBRANCA' , MO.DATA_VENCIMENTO AS 'MOV. DATA CREDITO' , MO.DATA_MOVIMENTO AS 'MOV. DT. GERACAO MOVDEBCC' , MO.COD_AGENCIA_DEB AS 'MOV. AGENCIA' , MO.OPER_CONTA_DEB AS 'MOV. OPER CONTA' , MO.NUM_CONTA_DEB AS 'MOV. NUM. CONTA' , MO.DIG_CONTA_DEB AS 'MOV. DV CONTA' , MO.COD_CONVENIO AS 'MOV.CONVENIO' , MO.DATA_ENVIO AS 'MOV. DT. ENVIO SIAS P/ SAP' , MO.NSAS AS 'MOV. NSAS' , MO.NUM_REQUISICAO AS 'MOV. NUM. CHQ. INTERNO' , CONTA.COD_AGENCIA AS 'CONTA COD AGENCIA' , CONTA.COD_BANCO AS 'CONTA BANCO' , CONTA.NUM_CONTA_CNB AS 'CONTA NUM. CONTA' , CONTA.NUM_DV_CONTA_CNB AS 'CONTA DV CONTA' , CONTA.IND_CONTA_BANCARIA AS 'CONTA ACHO QUE OPERACAO CONTA' FROM SEGUROS.SISTEMAS SIS, SEGUROS.SINISTRO_HISTORICO H, SEGUROS.SINISTRO_MESTRE M, SEGUROS.SINISTRO_HISTORICO H1, SEGUROS.GE_OPERACAO OPE, SEGUROS.PRODUTO PRO, SEGUROS.MOVTO_DEBITOCC_CEF MO LEFT JOIN SEGUROS.GE_MOVTO_CONTA CONTA ON CONTA.NUM_APOLICE = MO.NUM_APOLICE AND CONTA.NUM_ENDOSSO = MO.NUM_ENDOSSO AND CONTA.NUM_PARCELA = MO.NUM_PARCELA AND CONTA.COD_CONVENIO = MO.COD_CONVENIO AND CONTA.NSAS = MO.NSAS WHERE ( MO.COD_CONVENIO IN (600119 , 600120 , 600123) ) AND MO.NUM_APOLICE = :LK-SAP-NUM-APOLICE AND MO.NUM_ENDOSSO = :LK-SAP-NUM-ENDOSSO AND MO.NUM_PARCELA = :LK-SAP-NUM-PARCELA AND MO.NSAS = :LK-SAP-NSAS AND MO.SITUACAO_COBRANCA = :LK-SAP-SITUACAO-COBRANCA AND H.NUM_APOL_SINISTRO = MO.NUM_APOLICE AND H.OCORR_HISTORICO = MO.NUM_PARCELA AND H.COD_OPERACAO = MO.NUM_ENDOSSO - H.COD_PRODUTO * 10000 AND H.SIT_REGISTRO IN ( '1' , '8' ) AND H.SIT_CONTABIL IN ( '2' , '7' ) AND OPE.IDE_SISTEMA = 'SI' AND OPE.COD_OPERACAO = H.COD_OPERACAO AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND PRO.COD_PRODUTO = M.COD_PRODUTO AND H1.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND H1.COD_OPERACAO = 101 AND H1.TIMESTAMP = (SELECT MIN(A.TIMESTAMP) FROM SEGUROS.SINISTRO_HISTORICO A WHERE A.NUM_APOL_SINISTRO = H1.NUM_APOL_SINISTRO AND A.OCORR_HISTORICO = H1.OCORR_HISTORICO AND A.COD_OPERACAO = H1.COD_OPERACAO) AND SIS.IDE_SISTEMA = 'FI' ORDER BY 5,6,7 WITH UR END-EXEC. */
            LE_MOVDEBCE = new SISAP15B_LE_MOVDEBCE(true);
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
            /*" -2418- EXEC SQL OPEN LE_MOVDEBCE END-EXEC. */

            LE_MOVDEBCE.Open();

        }

        [StopWatch]
        /*" R4000-DECLARE-IMPOSTOS-DB-DECLARE-1 */
        public void R4000_DECLARE_IMPOSTOS_DB_DECLARE_1()
        {
            /*" -4415- EXEC SQL DECLARE IMPOSTOS CURSOR FOR SELECT H.NUM_APOL_SINISTRO, H.OCORR_HISTORICO, H.COD_OPERACAO, A.NUM_DOCF_INTERNO, C.COD_TP_LANCDOCF AS 'COD LANCAMENTO DA NOTA FISCAL' , Y.ABREV_LANCDOCF AS 'NOME LANCAMENTO DA NOTA FISCAL' , C.VALOR_LANCAMENTO AS 'VALOR LANCAMENTO NOTA FISCAL' , NOM_IMP.COD_IMP_INTERNO AS 'COD IMPOSTO' , NOM_IMP.SIGLA_IMP AS 'NOME IMPOSTO' , IMP.ALIQ_TRIBUTACAO AS 'ALIQUOTA IMPOSTO' , IMP.VALOR_IMPOSTO AS 'VALOR IMPOSTO' , F.NUM_DOC_FISCAL AS 'NUM DA NOTA FISCAL' , F.SERIE_DOC_FISCAL AS 'SERIE DA NOTA FISCAL' , F.DATA_EMISSAO_DOC AS 'DATA EMISSAO NOTA FISCAL' FROM SEGUROS.SINISTRO_HISTORICO H , SEGUROS.SI_PAGA_DOC_FISCAL A , SEGUROS.FI_PAGA_DOC_FISCAL F , SEGUROS.FI_PAGA_DOCF_LANC C , SEGUROS.GE_TP_LANC_DOCF Y , SEGUROS.FI_PAGA_DOCF_IMP IMP , SEGUROS.GE_TIPO_IMPOSTO NOM_IMP WHERE A.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND A.OCORR_HISTORICO = H.OCORR_HISTORICO AND A.COD_OPERACAO = H.COD_OPERACAO AND C.NUM_DOCF_INTERNO = A.NUM_DOCF_INTERNO AND C.VALOR_LANCAMENTO <> 0 AND Y.COD_TP_LANCDOCF = C.COD_TP_LANCDOCF AND Y.DT_INIVIG_LANCDOCF = C.DT_INIVIG_LANCDOCF AND IMP.NUM_DOCF_INTERNO = C.NUM_DOCF_INTERNO AND IMP.COD_TP_LANCDOCF = C.COD_TP_LANCDOCF AND IMP.DT_INIVIG_LANCDOCF = C.DT_INIVIG_LANCDOCF AND NOM_IMP.COD_IMP_INTERNO = IMP.COD_IMP_INTERNO AND NOM_IMP.DATA_INIVIG_IMP = IMP.DATA_INIVIG_IMP AND H.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND H.OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND F.NUM_DOCF_INTERNO = A.NUM_DOCF_INTERNO AND IMP.VALOR_IMPOSTO <> 0 END-EXEC. */
            IMPOSTOS = new SISAP15B_IMPOSTOS(true);
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
							C.COD_TP_LANCDOCF AS CODLANCAMENTODANOTAFISCAL
							, 
							Y.ABREV_LANCDOCF AS NOMELANCAMENTODANOTAFISCAL
							, 
							C.VALOR_LANCAMENTO AS VALORLANCAMENTONOTAFISCAL
							, 
							NOM_IMP.COD_IMP_INTERNO AS CODIMPOSTO
							, 
							NOM_IMP.SIGLA_IMP AS NOMEIMPOSTO
							, 
							IMP.ALIQ_TRIBUTACAO AS ALIQUOTAIMPOSTO
							, 
							IMP.VALOR_IMPOSTO AS VALORIMPOSTO
							, 
							F.NUM_DOC_FISCAL AS NUMDANOTAFISCAL
							, 
							F.SERIE_DOC_FISCAL AS SERIEDANOTAFISCAL
							, 
							F.DATA_EMISSAO_DOC AS DATAEMISSAONOTAFISCAL 
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
            /*" -2478- PERFORM R0101_FETCH_MOVDEBCE_DB_FETCH_1 */

            R0101_FETCH_MOVDEBCE_DB_FETCH_1();

            /*" -2481- IF W-AC-LIDOS-MOVDEBCE EQUAL 0 AND SQLCODE EQUAL 100 */

            if (AREA_DE_WORK.W_AC_LIDOS_MOVDEBCE == 0 && DB.SQLCODE == 100)
            {

                /*" -2482- DISPLAY ' ' */
                _.Display($" ");

                /*" -2483- DISPLAY ' ' */
                _.Display($" ");

                /*" -2484- DISPLAY '********************************************' */
                _.Display($"********************************************");

                /*" -2485- DISPLAY '*                                          *' */
                _.Display($"*                                          *");

                /*" -2486- DISPLAY '*          SUB-ROTINA - SISAP15B           *' */
                _.Display($"*          SUB-ROTINA - SISAP15B           *");

                /*" -2487- DISPLAY '*                                          *' */
                _.Display($"*                                          *");

                /*" -2488- DISPLAY '* ERRO NA DEFINICAO DO PROGRAMA            *' */
                _.Display($"* ERRO NA DEFINICAO DO PROGRAMA            *");

                /*" -2489- DISPLAY '*                                          *' */
                _.Display($"*                                          *");

                /*" -2490- DISPLAY '* PROGRAMA CANCELADO                       *' */
                _.Display($"* PROGRAMA CANCELADO                       *");

                /*" -2491- DISPLAY '*                                          *' */
                _.Display($"*                                          *");

                /*" -2492- DISPLAY '* NAO FOI ENCONTRADO REGISTRO NA NA TABELA *' */
                _.Display($"* NAO FOI ENCONTRADO REGISTRO NA NA TABELA *");

                /*" -2493- DISPLAY '* MOVTO_DEBITOCC_CEF                       *' */
                _.Display($"* MOVTO_DEBITOCC_CEF                       *");

                /*" -2494- DISPLAY '*                                          *' */
                _.Display($"*                                          *");

                /*" -2495- DISPLAY '* CHAVE DA MOVTO_DEBITOCC_CEF:             *' */
                _.Display($"* CHAVE DA MOVTO_DEBITOCC_CEF:             *");

                /*" -2496- DISPLAY '*                                          *' */
                _.Display($"*                                          *");

                /*" -2497- DISPLAY '* NUM_APOLICE: ' LK-SAP-NUM-APOLICE */
                _.Display($"* NUM_APOLICE: {REGISTRO_LINKAGE_SAP.LK_SAP_NUM_APOLICE}");

                /*" -2498- DISPLAY '* NUM_ENDOSSO: ' LK-SAP-NUM-ENDOSSO */
                _.Display($"* NUM_ENDOSSO: {REGISTRO_LINKAGE_SAP.LK_SAP_NUM_ENDOSSO}");

                /*" -2499- DISPLAY '* NUM_PARCELA: ' LK-SAP-NUM-PARCELA */
                _.Display($"* NUM_PARCELA: {REGISTRO_LINKAGE_SAP.LK_SAP_NUM_PARCELA}");

                /*" -2500- DISPLAY '* NSAS       : ' LK-SAP-NSAS */
                _.Display($"* NSAS       : {REGISTRO_LINKAGE_SAP.LK_SAP_NSAS}");

                /*" -2502- DISPLAY '* SITUACAO_COBRANCA: ' LK-SAP-SITUACAO-COBRANCA */
                _.Display($"* SITUACAO_COBRANCA: {REGISTRO_LINKAGE_SAP.LK_SAP_SITUACAO_COBRANCA}");

                /*" -2503- DISPLAY 'W-AC-LIDOS-MOVDEBCE - ' W-AC-LIDOS-MOVDEBCE */
                _.Display($"W-AC-LIDOS-MOVDEBCE - {AREA_DE_WORK.W_AC_LIDOS_MOVDEBCE}");

                /*" -2504- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -2505- DISPLAY '*                                          *' */
                _.Display($"*                                          *");

                /*" -2506- DISPLAY '********************************************' */
                _.Display($"********************************************");

                /*" -2507- DISPLAY ' ' */
                _.Display($" ");

                /*" -2508- MOVE '1' TO LK-SAP-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE_SAP.LK_SAP_COD_RETORNO);

                /*" -2510- MOVE 'NAO FOI ENCONTRADO REG. NA MOVTO_DEBITOCC_CEF' TO LK-SAP-MENSAGEM-RETORNO */
                _.Move("NAO FOI ENCONTRADO REG. NA MOVTO_DEBITOCC_CEF", REGISTRO_LINKAGE_SAP.LK_SAP_MENSAGEM_RETORNO);

                /*" -2510- PERFORM R0101_FETCH_MOVDEBCE_DB_CLOSE_1 */

                R0101_FETCH_MOVDEBCE_DB_CLOSE_1();

                /*" -2520- GO TO RXXXX-ROTINA-RETORNO. */

                RXXXX_ROTINA_RETORNO(); //GOTO
                return;
            }


            /*" -2521- MOVE 'NAO' TO W-CHAVE-EH-PRESTADOR. */
            _.Move("NAO", AREA_DE_WORK.W_CHAVE_EH_PRESTADOR);

            /*" -2522- IF SQLCODE EQUAL 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -2524- IF (SINISHIS-COD-PREST-SERVICO NOT EQUAL 0) AND (SINISHIS-COD-SERVICO NOT EQUAL 95) */

                if ((SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO != 0) && (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_SERVICO != 95))
                {

                    /*" -2526- MOVE 'SIM' TO W-CHAVE-EH-PRESTADOR. */
                    _.Move("SIM", AREA_DE_WORK.W_CHAVE_EH_PRESTADOR);
                }

            }


            /*" -2528- IF SQLCODE EQUAL 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -2530- ADD 1 TO W-AC-LIDOS-MOVDEBCE . */
                AREA_DE_WORK.W_AC_LIDOS_MOVDEBCE.Value = AREA_DE_WORK.W_AC_LIDOS_MOVDEBCE + 1;
            }


            /*" -2531- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2531- PERFORM R0101_FETCH_MOVDEBCE_DB_CLOSE_2 */

                R0101_FETCH_MOVDEBCE_DB_CLOSE_2();

                /*" -2533- MOVE 'SIM' TO WFIM-LE-MOVDEBCE-1 */
                _.Move("SIM", AREA_DE_WORK.WFIM_LE_MOVDEBCE_1);

                /*" -2535- GO TO R0101-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0101_EXIT*/ //GOTO
                return;
            }


            /*" -2536- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -2537- DISPLAY 'SISAP15B - ERRO NO FETCH CURSOR LE_MOVDEBCE(1)' */
                _.Display($"SISAP15B - ERRO NO FETCH CURSOR LE_MOVDEBCE(1)");

                /*" -2537- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0101-FETCH-MOVDEBCE-DB-FETCH-1 */
        public void R0101_FETCH_MOVDEBCE_DB_FETCH_1()
        {
            /*" -2478- EXEC SQL FETCH LE_MOVDEBCE INTO :W-NOME-QUERY, :SINISHIS-TIPO-REGISTRO, :W-NOME-TIPO-SEGURO, :SINISHIS-NUM-APOLICE, :SINISHIS-NUM-APOL-SINISTRO, :SINISHIS-OCORR-HISTORICO, :SINISHIS-COD-OPERACAO, :SINISHIS-NOME-FAVORECIDO, :W-ANO-OPERACIONAL-MOVIMENTO, :W-ANO-CONTABIL-MOVIMENTO, :GEOPERAC-FUNCAO-OPERACAO, :GEOPERAC-DES-OPERACAO, :SINISHIS-VAL-OPERACAO, :MOVDEBCE-VLR-CREDITO, :MOVDEBCE-VALOR-DEBITO, :SINISHIS-DATA-MOVIMENTO, :SINISHIS-COD-PREST-SERVICO, :SINISHIS-COD-SERVICO, :SINISHIS-SIT-CONTABIL, :W-NOME-FORMA-PAGAMENTO, :SINISHIS-NOM-PROGRAMA:NULL-NOM-PROGRAMA, :SINISHIS-COD-USUARIO, :SINISMES-RAMO, :SINISMES-COD-FONTE, :W-DATA-AVISO-SIAS, :SINISMES-DATA-COMUNICADO, :SINISMES-COD-PRODUTO, :PRODUTO-DESCR-PRODUTO, :CHEQUEMI-NUM-CHEQUE-INTERNO, :MOVDEBCE-NUM-APOLICE, :MOVDEBCE-NUM-ENDOSSO, :MOVDEBCE-NUM-PARCELA, :MOVDEBCE-SITUACAO-COBRANCA, :W-NOME-SITUACAO-COBRANCA, :MOVDEBCE-DATA-VENCIMENTO, :MOVDEBCE-DATA-MOVIMENTO, :MOVDEBCE-COD-AGENCIA-DEB, :MOVDEBCE-OPER-CONTA-DEB, :MOVDEBCE-NUM-CONTA-DEB, :MOVDEBCE-DIG-CONTA-DEB, :MOVDEBCE-COD-CONVENIO, :MOVDEBCE-DATA-ENVIO, :MOVDEBCE-NSAS, :MOVDEBCE-NUM-REQUISICAO, :GE369-COD-AGENCIA:NULL-COD-AGENCIA, :GE369-COD-BANCO:NULL-COD-BANCO, :GE369-NUM-CONTA-CNB:NULL-NUM-CONTA-CNB, :GE369-NUM-DV-CONTA-CNB:NULL-NUM-DV-CONTA-CNB, :GE369-IND-CONTA-BANCARIA:NULL-IND-CONTA-BANCARIA END-EXEC. */

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
            }

        }

        [StopWatch]
        /*" R0101-FETCH-MOVDEBCE-DB-CLOSE-1 */
        public void R0101_FETCH_MOVDEBCE_DB_CLOSE_1()
        {
            /*" -2510- EXEC SQL CLOSE LE_MOVDEBCE END-EXEC */

            LE_MOVDEBCE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0101_EXIT*/

        [StopWatch]
        /*" R0101-FETCH-MOVDEBCE-DB-CLOSE-2 */
        public void R0101_FETCH_MOVDEBCE_DB_CLOSE_2()
        {
            /*" -2531- EXEC SQL CLOSE LE_MOVDEBCE END-EXEC */

            LE_MOVDEBCE.Close();

        }

        [StopWatch]
        /*" R0200-PROCESSA-PRINCIPAL */
        private void R0200_PROCESSA_PRINCIPAL(bool isPerform = false)
        {
            /*" -2547- MOVE ZEROS TO W-NUM-CPF-NUM W-NUM-CNPJ-NUM. */
            _.Move(0, AREA_DE_WORK.W_NUM_CPF_NUM, AREA_DE_WORK.W_NUM_CNPJ_NUM);

            /*" -2552- MOVE SPACES TO W-CHAVE-ORIGEM-CADASTRO. */
            _.Move("", AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO);

            /*" -2554- MOVE 'XX' TO W-CHAVE-TIPO-PESSOA-PF-PJ. */
            _.Move("XX", AREA_DE_WORK.W_CHAVE_TIPO_PESSOA_PF_PJ);

            /*" -2556- PERFORM R2000-CADASTRAIS-ODS THRU R2000-EXIT. */

            R2000_CADASTRAIS_ODS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_EXIT*/


            /*" -2557- IF W-CHAVE-ORIGEM-CADASTRO EQUAL 'ODS' */

            if (AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO == "ODS")
            {

                /*" -2559- GO TO R0200-MONTA-REGISTRO . */

                R0200_MONTA_REGISTRO(); //GOTO
                return;
            }


            /*" -2561- INITIALIZE DCLFORNECEDORES. */
            _.Initialize(
                FORNECED.DCLFORNECEDORES
            );

            /*" -2563- PERFORM R2010-CADASTRAIS-LOTERICO THRU R2010-EXIT. */

            R2010_CADASTRAIS_LOTERICO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R2010_EXIT*/


            /*" -2564- IF W-CHAVE-ORIGEM-CADASTRO EQUAL 'FORNECEDOR OU LOTERICO' */

            if (AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO == "FORNECEDOR OU LOTERICO")
            {

                /*" -2566- GO TO R0200-MONTA-REGISTRO . */

                R0200_MONTA_REGISTRO(); //GOTO
                return;
            }


            /*" -2568- PERFORM R2020-CADASTRAIS-FORNECED THRU R2020-EXIT. */

            R2020_CADASTRAIS_FORNECED(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R2020_EXIT*/


            /*" -2569- IF W-CHAVE-ORIGEM-CADASTRO EQUAL 'FORNECEDOR OU LOTERICO' */

            if (AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO == "FORNECEDOR OU LOTERICO")
            {

                /*" -2570- GO TO R0200-MONTA-REGISTRO */

                R0200_MONTA_REGISTRO(); //GOTO
                return;

                /*" -2571- ELSE */
            }
            else
            {


                /*" -2571- MOVE 'SEM CADASTRO' TO W-CHAVE-ORIGEM-CADASTRO. */
                _.Move("SEM CADASTRO", AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO);
            }


        }

        [StopWatch]
        /*" R0200-MONTA-REGISTRO */
        private void R0200_MONTA_REGISTRO(bool isPerform = false)
        {
            /*" -2577- PERFORM R3000-MONTA-REGISTRO THRU R3000-EXIT. */

            R3000_MONTA_REGISTRO(true);

            R3000_GRAVA_REGISTRO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_EXIT*/


            /*" -2579- PERFORM R19000-GE0300B-GRAVA-CONTROLES THRU R19000-EXIT. */

            R19000_GE0300B_GRAVA_CONTROLES(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R19000_EXIT*/


            /*" -2579- PERFORM R0101-FETCH-MOVDEBCE THRU R0101-EXIT. */

            R0101_FETCH_MOVDEBCE(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R0101_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_EXIT*/

        [StopWatch]
        /*" R3000-MONTA-REGISTRO */
        private void R3000_MONTA_REGISTRO(bool isPerform = false)
        {
            /*" -2587- INITIALIZE W-REGISTRO-SIAS-GERAL. */
            _.Initialize(
                W_REGISTRO_SIAS_GERAL
            );

            /*" -2591- MOVE 01 TO TIPOREG-GERAL */
            _.Move(01, W_REGISTRO_SIAS_GERAL.TIPOREG_GERAL);

            /*" -2598- IF (MOVDEBCE-COD-CONVENIO EQUAL 600119 OR 600120 OR 600123) AND (SINISHIS-COD-OPERACAO EQUAL 1070 OR 1071 OR 1072 OR 1073 OR 1074 OR 1030 OR 1040 OR 4000) */

            if ((MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.In("600119", "600120", "600123")) && (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.In("1070", "1071", "1072", "1073", "1074", "1030", "1040", "4000")))
            {

                /*" -2599- IF SINISHIS-VAL-OPERACAO > 0 */

                if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO > 0)
                {

                    /*" -2600- MOVE 'IND' TO GEOPERAC-FUNCAO-OPERACAO */
                    _.Move("IND", GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO);

                    /*" -2601- ELSE */
                }
                else
                {


                    /*" -2602- MOVE 'EIND' TO GEOPERAC-FUNCAO-OPERACAO */
                    _.Move("EIND", GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO);

                    /*" -2604- COMPUTE SINISHIS-VAL-OPERACAO = SINISHIS-VAL-OPERACAO * -1 */
                    SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO.Value = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO * -1;

                    /*" -2605- END-IF */
                }


                /*" -2606- IF SINISHIS-COD-OPERACAO EQUAL 4000 */

                if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO == 4000)
                {

                    /*" -2607- MOVE 'RSPPR' TO GEOPERAC-FUNCAO-OPERACAO */
                    _.Move("RSPPR", GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO);

                    /*" -2608- END-IF */
                }


                /*" -2612- END-IF */
            }


            /*" -2613- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'EIND' OR 'RSPPR' */

            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO.In("EIND", "RSPPR"))
            {

                /*" -2614- MOVE 'S201' TO ORIG-GERAL */
                _.Move("S201", W_REGISTRO_SIAS_GERAL.ORIG_GERAL);

                /*" -2615- MOVE 'CA' TO W-LOTE-SIGLA-MODULO */
                _.Move("CA", AREA_DE_WORK.W_LOTE.W_LOTE_SIGLA_MODULO);

                /*" -2616- ELSE */
            }
            else
            {


                /*" -2617- MOVE 'AP' TO W-LOTE-SIGLA-MODULO */
                _.Move("AP", AREA_DE_WORK.W_LOTE.W_LOTE_SIGLA_MODULO);

                /*" -2618- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'IND' */

                if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "IND")
                {

                    /*" -2619- MOVE 'S101' TO ORIG-GERAL */
                    _.Move("S101", W_REGISTRO_SIAS_GERAL.ORIG_GERAL);

                    /*" -2620- ELSE */
                }
                else
                {


                    /*" -2623- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'LIB' AND SINISHIS-COD-OPERACAO EQUAL 1081 OR 1082 OR 1083 OR 1084 */

                    if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "LIB" && SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.In("1081", "1082", "1083", "1084"))
                    {

                        /*" -2624- MOVE 'S101' TO ORIG-GERAL */
                        _.Move("S101", W_REGISTRO_SIAS_GERAL.ORIG_GERAL);

                        /*" -2625- ELSE */
                    }
                    else
                    {


                        /*" -2626- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'DPAG' */

                        if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "DPAG")
                        {

                            /*" -2627- MOVE 'S104' TO ORIG-GERAL */
                            _.Move("S104", W_REGISTRO_SIAS_GERAL.ORIG_GERAL);

                            /*" -2628- ELSE */
                        }
                        else
                        {


                            /*" -2630- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'HPAG' */

                            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "HPAG")
                            {

                                /*" -2631- MOVE 'S104' TO ORIG-GERAL */
                                _.Move("S104", W_REGISTRO_SIAS_GERAL.ORIG_GERAL);

                                /*" -2632- ELSE */
                            }
                            else
                            {


                                /*" -2633- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'DSPAG' */

                                if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "DSPAG")
                                {

                                    /*" -2634- MOVE 'S109' TO ORIG-GERAL */
                                    _.Move("S109", W_REGISTRO_SIAS_GERAL.ORIG_GERAL);

                                    /*" -2635- ELSE */
                                }
                                else
                                {


                                    /*" -2636- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'HSPAG' */

                                    if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "HSPAG")
                                    {

                                        /*" -2637- MOVE 'S109' TO ORIG-GERAL */
                                        _.Move("S109", W_REGISTRO_SIAS_GERAL.ORIG_GERAL);

                                        /*" -2638- ELSE */
                                    }
                                    else
                                    {


                                        /*" -2639- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'RSHOP' */

                                        if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "RSHOP")
                                        {

                                            /*" -2640- MOVE 'S109' TO ORIG-GERAL */
                                            _.Move("S109", W_REGISTRO_SIAS_GERAL.ORIG_GERAL);

                                            /*" -2641- ELSE */
                                        }
                                        else
                                        {


                                            /*" -2642- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'RSDEP' */

                                            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "RSDEP")
                                            {

                                                /*" -2643- MOVE 'S109' TO ORIG-GERAL */
                                                _.Move("S109", W_REGISTRO_SIAS_GERAL.ORIG_GERAL);

                                                /*" -2644- ELSE */
                                            }
                                            else
                                            {


                                                /*" -2645- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'RSREP' */

                                                if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "RSREP")
                                                {

                                                    /*" -2646- MOVE 'S109' TO ORIG-GERAL */
                                                    _.Move("S109", W_REGISTRO_SIAS_GERAL.ORIG_GERAL);

                                                    /*" -2647- ELSE */
                                                }
                                                else
                                                {


                                                    /*" -2648- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'JBIND' */

                                                    if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "JBIND")
                                                    {

                                                        /*" -2649- MOVE 'S100' TO ORIG-GERAL */
                                                        _.Move("S100", W_REGISTRO_SIAS_GERAL.ORIG_GERAL);

                                                        /*" -2650- ELSE */
                                                    }
                                                    else
                                                    {


                                                        /*" -2651- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'JBDP' */

                                                        if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "JBDP")
                                                        {

                                                            /*" -2652- MOVE 'S110' TO ORIG-GERAL */
                                                            _.Move("S110", W_REGISTRO_SIAS_GERAL.ORIG_GERAL);

                                                            /*" -2653- ELSE */
                                                        }
                                                        else
                                                        {


                                                            /*" -2654- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'JBDES' */

                                                            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "JBDES")
                                                            {

                                                                /*" -2655- MOVE 'S100' TO ORIG-GERAL */
                                                                _.Move("S100", W_REGISTRO_SIAS_GERAL.ORIG_GERAL);

                                                                /*" -2656- ELSE */
                                                            }
                                                            else
                                                            {


                                                                /*" -2657- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'JBHON' */

                                                                if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "JBHON")
                                                                {

                                                                    /*" -2658- MOVE 'S100' TO ORIG-GERAL */
                                                                    _.Move("S100", W_REGISTRO_SIAS_GERAL.ORIG_GERAL);

                                                                    /*" -2659- ELSE */
                                                                }
                                                                else
                                                                {


                                                                    /*" -2663- MOVE 'S???' TO ORIG-GERAL. */
                                                                    _.Move("S???", W_REGISTRO_SIAS_GERAL.ORIG_GERAL);
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


            /*" -2664- MOVE LK-SAP-COD-PROGRAMA TO W-LOTE-NOME-PROGRAMA */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_COD_PROGRAMA, AREA_DE_WORK.W_LOTE.W_LOTE_NOME_PROGRAMA);

            /*" -2665- IF W-LOTE-PROGRAMA-FILLER EQUAL ' ' */

            if (AREA_DE_WORK.W_LOTE.W_LOTE_NOME_PROGRAMA.W_LOTE_PROGRAMA_FILLER == " ")
            {

                /*" -2666- MOVE 'X' TO W-LOTE-PROGRAMA-FILLER. */
                _.Move("X", AREA_DE_WORK.W_LOTE.W_LOTE_NOME_PROGRAMA.W_LOTE_PROGRAMA_FILLER);
            }


            /*" -2674- MOVE W-LOTE TO LOTE-GERAL. */
            _.Move(AREA_DE_WORK.W_LOTE, W_REGISTRO_SIAS_GERAL.LOTE_GERAL);

            /*" -2678- MOVE 999999999 TO LOTEIT-GERAL. */
            _.Move(999999999, W_REGISTRO_SIAS_GERAL.LOTEIT_GERAL);

            /*" -2679- MOVE 'S' TO W-IDLG-SINISTRO */
            _.Move("S", AREA_DE_WORK.W_IDLG_SIAS_SINISTRO.W_IDLG_SINISTRO);

            /*" -2680- MOVE SINISHIS-NUM-APOL-SINISTRO TO W-IDLG-NUM-APOL-SINISTRO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, AREA_DE_WORK.W_IDLG_SIAS_SINISTRO.W_IDLG_NUM_APOL_SINISTRO);

            /*" -2681- MOVE SINISHIS-OCORR-HISTORICO TO W-IDLG-OCORR-HISTORICO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO, AREA_DE_WORK.W_IDLG_SIAS_SINISTRO.W_IDLG_OCORR_HISTORICO);

            /*" -2683- MOVE SINISHIS-COD-OPERACAO TO W-IDLG-COD-OPERACAO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO, AREA_DE_WORK.W_IDLG_SIAS_SINISTRO.W_IDLG_COD_OPERACAO);

            /*" -2684- IF MOVDEBCE-VLR-CREDITO NOT EQUAL 0 */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_CREDITO != 0)
            {

                /*" -2685- MOVE 'P' TO W-IDLG-TIPO-MOVIMENTO */
                _.Move("P", AREA_DE_WORK.W_IDLG_SIAS_SINISTRO.W_IDLG_TIPO_MOVIMENTO);

                /*" -2686- ELSE */
            }
            else
            {


                /*" -2687- IF MOVDEBCE-VALOR-DEBITO NOT EQUAL 0 */

                if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO != 0)
                {

                    /*" -2688- MOVE 'R' TO W-IDLG-TIPO-MOVIMENTO */
                    _.Move("R", AREA_DE_WORK.W_IDLG_SIAS_SINISTRO.W_IDLG_TIPO_MOVIMENTO);

                    /*" -2689- ELSE */
                }
                else
                {


                    /*" -2693- MOVE '?' TO W-IDLG-TIPO-MOVIMENTO. */
                    _.Move("?", AREA_DE_WORK.W_IDLG_SIAS_SINISTRO.W_IDLG_TIPO_MOVIMENTO);
                }

            }


            /*" -2695- MOVE '2' TO W-IDLG-FORMA-PAGAMENTO. */
            _.Move("2", AREA_DE_WORK.W_IDLG_SIAS_SINISTRO.W_IDLG_FORMA_PAGAMENTO);

            /*" -2697- MOVE MOVDEBCE-NSAS TO W-IDLG-NSAS */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS, AREA_DE_WORK.W_IDLG_SIAS_SINISTRO.W_IDLG_COMPLEMENTO_2.W_IDLG_NSAS);

            /*" -2701- MOVE W-IDLG-SIAS-SINISTRO TO IDLG-GERAL. */
            _.Move(AREA_DE_WORK.W_IDLG_SIAS_SINISTRO, W_REGISTRO_SIAS_GERAL.IDLG_GERAL);

            /*" -2705- MOVE SPACES TO JANELA-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.JANELA_GERAL);

            /*" -2709- MOVE W-ANO-CONTABIL-MOVIMENTO TO ANPRO-GERAL. */
            _.Move(W_ANO_CONTABIL_MOVIMENTO, W_REGISTRO_SIAS_GERAL.ANPRO_GERAL);

            /*" -2710- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'EIND' */

            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "EIND")
            {

                /*" -2711- MOVE 'SIAS_09504' TO CODOPE-GERAL */
                _.Move("SIAS_09504", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);

                /*" -2712- ELSE */
            }
            else
            {


                /*" -2713- IF SINISMES-RAMO NOT EQUAL 66 */

                if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO != 66)
                {

                    /*" -2714- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'IND' */

                    if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "IND")
                    {

                        /*" -2715- MOVE 'SIAS_09001' TO CODOPE-GERAL */
                        _.Move("SIAS_09001", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);

                        /*" -2716- ELSE */
                    }
                    else
                    {


                        /*" -2719- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'LIB' AND SINISHIS-COD-OPERACAO EQUAL 1081 OR 1082 OR 1083 OR 1084 */

                        if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "LIB" && SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.In("1081", "1082", "1083", "1084"))
                        {

                            /*" -2720- MOVE 'SIAS_09001' TO CODOPE-GERAL */
                            _.Move("SIAS_09001", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);

                            /*" -2721- ELSE */
                        }
                        else
                        {


                            /*" -2722- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'DPAG' */

                            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "DPAG")
                            {

                                /*" -2723- MOVE 'SIAS_09023' TO CODOPE-GERAL */
                                _.Move("SIAS_09023", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);

                                /*" -2724- ELSE */
                            }
                            else
                            {


                                /*" -2725- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'DSPAG' */

                                if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "DSPAG")
                                {

                                    /*" -2726- MOVE 'SIAS_09011' TO CODOPE-GERAL */
                                    _.Move("SIAS_09011", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);

                                    /*" -2727- ELSE */
                                }
                                else
                                {


                                    /*" -2728- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'HSPAG' */

                                    if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "HSPAG")
                                    {

                                        /*" -2729- MOVE 'SIAS_09012' TO CODOPE-GERAL */
                                        _.Move("SIAS_09012", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);

                                        /*" -2730- ELSE */
                                    }
                                    else
                                    {


                                        /*" -2731- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'RSHOP' */

                                        if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "RSHOP")
                                        {

                                            /*" -2732- MOVE 'SIAS_09013' TO CODOPE-GERAL */
                                            _.Move("SIAS_09013", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);

                                            /*" -2733- ELSE */
                                        }
                                        else
                                        {


                                            /*" -2734- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'RSDEP' */

                                            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "RSDEP")
                                            {

                                                /*" -2735- MOVE 'SIAS_09024' TO CODOPE-GERAL */
                                                _.Move("SIAS_09024", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);

                                                /*" -2736- ELSE */
                                            }
                                            else
                                            {


                                                /*" -2737- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'RSREP' */

                                                if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "RSREP")
                                                {

                                                    /*" -2738- MOVE 'SIAS_09005' TO CODOPE-GERAL */
                                                    _.Move("SIAS_09005", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);

                                                    /*" -2739- ELSE */
                                                }
                                                else
                                                {


                                                    /*" -2740- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'JBIND' */

                                                    if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "JBIND")
                                                    {

                                                        /*" -2741- IF SINISHIS-COD-OPERACAO EQUAL 8206 */

                                                        if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO == 8206)
                                                        {

                                                            /*" -2742- MOVE 'SIAS_09002' TO CODOPE-GERAL */
                                                            _.Move("SIAS_09002", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);

                                                            /*" -2743- ELSE */
                                                        }
                                                        else
                                                        {


                                                            /*" -2744- MOVE 'SIAS_09003' TO CODOPE-GERAL */
                                                            _.Move("SIAS_09003", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);

                                                            /*" -2745- END-IF */
                                                        }


                                                        /*" -2746- ELSE */
                                                    }
                                                    else
                                                    {


                                                        /*" -2747- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'JBDP' */

                                                        if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "JBDP")
                                                        {

                                                            /*" -2748- MOVE 'SIAS_09004' TO CODOPE-GERAL */
                                                            _.Move("SIAS_09004", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);

                                                            /*" -2749- ELSE */
                                                        }
                                                        else
                                                        {


                                                            /*" -2750- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'JBDES' */

                                                            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "JBDES")
                                                            {

                                                                /*" -2751- MOVE 'SIAS_09022' TO CODOPE-GERAL */
                                                                _.Move("SIAS_09022", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);

                                                                /*" -2752- ELSE */
                                                            }
                                                            else
                                                            {


                                                                /*" -2753- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'JBHON' */

                                                                if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "JBHON")
                                                                {

                                                                    /*" -2754- MOVE 'SIAS_09009' TO CODOPE-GERAL */
                                                                    _.Move("SIAS_09009", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);

                                                                    /*" -2755- ELSE */
                                                                }
                                                                else
                                                                {


                                                                    /*" -2757- MOVE 'SIAS_01???' TO CODOPE-GERAL. */
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


            /*" -2759- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'RSPPR' */

            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "RSPPR")
            {

                /*" -2760- MOVE 'SIAS_09515' TO CODOPE-GERAL */
                _.Move("SIAS_09515", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);

                /*" -2764- END-IF */
            }


            /*" -2765- IF SINISMES-RAMO EQUAL 66 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO == 66)
            {

                /*" -2766- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'JBIND' */

                if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "JBIND")
                {

                    /*" -2767- IF SINISHIS-COD-OPERACAO EQUAL 8206 */

                    if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO == 8206)
                    {

                        /*" -2768- MOVE 'SIAS_09006' TO CODOPE-GERAL */
                        _.Move("SIAS_09006", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);

                        /*" -2769- ELSE */
                    }
                    else
                    {


                        /*" -2770- MOVE 'SIAS_09008' TO CODOPE-GERAL */
                        _.Move("SIAS_09008", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);

                        /*" -2771- END-IF */
                    }


                    /*" -2772- ELSE */
                }
                else
                {


                    /*" -2773- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'JBDP' */

                    if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "JBDP")
                    {

                        /*" -2774- MOVE 'SIAS_09007' TO CODOPE-GERAL */
                        _.Move("SIAS_09007", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);

                        /*" -2775- ELSE */
                    }
                    else
                    {


                        /*" -2776- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'JBDES' */

                        if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "JBDES")
                        {

                            /*" -2777- MOVE 'SIAS_09025' TO CODOPE-GERAL */
                            _.Move("SIAS_09025", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);

                            /*" -2778- ELSE */
                        }
                        else
                        {


                            /*" -2779- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'JBHON' */

                            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "JBHON")
                            {

                                /*" -2780- MOVE 'SIAS_09015' TO CODOPE-GERAL */
                                _.Move("SIAS_09015", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);

                                /*" -2781- ELSE */
                            }
                            else
                            {


                                /*" -2790- MOVE 'SIAS_02???' TO CODOPE-GERAL. */
                                _.Move("SIAS_02???", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);
                            }

                        }

                    }

                }

            }


            /*" -2791- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'HPAG' */

            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "HPAG")
            {

                /*" -2792- MOVE 0 TO HOST-COUNT */
                _.Move(0, HOST_COUNT);

                /*" -2794- PERFORM R3010-ACESSA-SCPJUD THRU R3010-EXIT */

                R3010_ACESSA_SCPJUD(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3010_EXIT*/


                /*" -2795- IF HOST-COUNT EQUAL 0 */

                if (HOST_COUNT == 0)
                {

                    /*" -2797- MOVE 'SIAS_09010' TO CODOPE-GERAL */
                    _.Move("SIAS_09010", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);

                    /*" -2798- ELSE */
                }
                else
                {


                    /*" -2799- IF SINISMES-RAMO EQUAL 66 */

                    if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO == 66)
                    {

                        /*" -2800- MOVE 'SIAS_09014' TO CODOPE-GERAL */
                        _.Move("SIAS_09014", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);

                        /*" -2801- ELSE */
                    }
                    else
                    {


                        /*" -2802- MOVE 'S100' TO ORIG-GERAL */
                        _.Move("S100", W_REGISTRO_SIAS_GERAL.ORIG_GERAL);

                        /*" -2806- MOVE 'SIAS_09009' TO CODOPE-GERAL. */
                        _.Move("SIAS_09009", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);
                    }

                }

            }


            /*" -2807- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'DPAG' */

            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "DPAG")
            {

                /*" -2808- MOVE 0 TO HOST-COUNT */
                _.Move(0, HOST_COUNT);

                /*" -2810- PERFORM R3010-ACESSA-SCPJUD THRU R3010-EXIT */

                R3010_ACESSA_SCPJUD(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3010_EXIT*/


                /*" -2811- IF HOST-COUNT EQUAL 0 */

                if (HOST_COUNT == 0)
                {

                    /*" -2813- MOVE 'SIAS_09023' TO CODOPE-GERAL */
                    _.Move("SIAS_09023", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);

                    /*" -2814- ELSE */
                }
                else
                {


                    /*" -2815- IF SINISMES-RAMO EQUAL 66 */

                    if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO == 66)
                    {

                        /*" -2816- MOVE 'SIAS_09014' TO CODOPE-GERAL */
                        _.Move("SIAS_09014", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);

                        /*" -2817- ELSE */
                    }
                    else
                    {


                        /*" -2818- MOVE 'S100' TO ORIG-GERAL */
                        _.Move("S100", W_REGISTRO_SIAS_GERAL.ORIG_GERAL);

                        /*" -2822- MOVE 'SIAS_09022' TO CODOPE-GERAL. */
                        _.Move("SIAS_09022", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);
                    }

                }

            }


            /*" -2824- IF SINISMES-RAMO EQUAL 66 AND GEOPERAC-FUNCAO-OPERACAO EQUAL 'IND' */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO == 66 && GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "IND")
            {

                /*" -2825- MOVE 0 TO HOST-COUNT */
                _.Move(0, HOST_COUNT);

                /*" -2827- PERFORM R3010-ACESSA-SCPJUD THRU R3010-EXIT */

                R3010_ACESSA_SCPJUD(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3010_EXIT*/


                /*" -2828- IF HOST-COUNT EQUAL 0 */

                if (HOST_COUNT == 0)
                {

                    /*" -2829- MOVE 'S101' TO ORIG-GERAL */
                    _.Move("S101", W_REGISTRO_SIAS_GERAL.ORIG_GERAL);

                    /*" -2831- MOVE 'SIAS_09001' TO CODOPE-GERAL */
                    _.Move("SIAS_09001", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);

                    /*" -2832- ELSE */
                }
                else
                {


                    /*" -2833- MOVE 'S100' TO ORIG-GERAL */
                    _.Move("S100", W_REGISTRO_SIAS_GERAL.ORIG_GERAL);

                    /*" -2839- MOVE 'SIAS_09008' TO CODOPE-GERAL. */
                    _.Move("SIAS_09008", W_REGISTRO_SIAS_GERAL.CODOPE_GERAL);
                }

            }


            /*" -2843- MOVE 'X' TO PAGBLK-GERAL. */
            _.Move("X", W_REGISTRO_SIAS_GERAL.PAGBLK_GERAL);

            /*" -2847- MOVE 'C000' TO CODSOC-GERAL. */
            _.Move("C000", W_REGISTRO_SIAS_GERAL.CODSOC_GERAL);

            /*" -2851- MOVE 'BRL' TO MOEDA-GERAL. */
            _.Move("BRL", W_REGISTRO_SIAS_GERAL.MOEDA_GERAL);

            /*" -2852- MOVE SISTEMAs-DATA-MOV-ABERTO(1:4) TO W-DATA-AAAAMMDD-AAAA. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4), AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_AAAA);

            /*" -2853- MOVE SISTEMAs-DATA-MOV-ABERTO(6:2) TO W-DATA-AAAAMMDD-MM. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2), AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_MM);

            /*" -2854- MOVE SISTEMAs-DATA-MOV-ABERTO(9:2) TO W-DATA-AAAAMMDD-DD. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2), AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_DD);

            /*" -2858- MOVE W-DATA-AAAAMMDD TO DTDOC-GERAL. */
            _.Move(AREA_DE_WORK.W_DATA_AAAAMMDD, W_REGISTRO_SIAS_GERAL.DTDOC_GERAL);

            /*" -2859- MOVE SISTEMAs-DATA-MOV-ABERTO(1:4) TO W-DATA-AAAAMMDD-AAAA. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4), AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_AAAA);

            /*" -2860- MOVE SISTEMAs-DATA-MOV-ABERTO(6:2) TO W-DATA-AAAAMMDD-MM. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2), AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_MM);

            /*" -2861- MOVE SISTEMAs-DATA-MOV-ABERTO(9:2) TO W-DATA-AAAAMMDD-DD. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2), AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_DD);

            /*" -2863- MOVE W-DATA-AAAAMMDD TO DTLAN-GERAL. */
            _.Move(AREA_DE_WORK.W_DATA_AAAAMMDD, W_REGISTRO_SIAS_GERAL.DTLAN_GERAL);

            /*" -2871- PERFORM R3100-DADOS-FINAL-ARQUIVO THRU R3100-EXIT. */

            R3100_DADOS_FINAL_ARQUIVO(true);

            R3100_CONTINUA_MONTAGEM(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_EXIT*/


            /*" -2872- IF CODOPE-GERAL EQUAL 'SIAS_09504' OR 'SIAS_09515' */

            if (W_REGISTRO_SIAS_GERAL.CODOPE_GERAL.In("SIAS_09504".ToString(), "SIAS_09515".ToString()))
            {

                /*" -2873- PERFORM R3700-MONTA-ATTR-RECEB-MOD-CA THRU R3700-EXIT */

                R3700_MONTA_ATTR_RECEB_MOD_CA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3700_EXIT*/


                /*" -2874- PERFORM R3750-MONTA-CODV-RECEB-MOD-CA THRU R3750-EXIT */

                R3750_MONTA_CODV_RECEB_MOD_CA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3750_EXIT*/


                /*" -2875- ELSE */
            }
            else
            {


                /*" -2876- PERFORM R3500-MONTA-ATTR-PAGTO-MOD-AP THRU R3500-EXIT */

                R3500_MONTA_ATTR_PAGTO_MOD_AP(true);

                R3500_PULA_CBEN(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3500_EXIT*/


                /*" -2876- PERFORM R3550-MONTA-CODV-PAGTO-MOD-AP THRU R3550-EXIT. */

                R3550_MONTA_CODV_PAGTO_MOD_AP(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3550_EXIT*/

            }


        }

        [StopWatch]
        /*" R3000-GRAVA-REGISTRO */
        private void R3000_GRAVA_REGISTRO(bool isPerform = false)
        {
            /*" -2883- IF W-CHAVE-MONTA-SIACC-ESPECIAL EQUAL 'NAO' */

            if (AREA_DE_WORK.W_CHAVE_MONTA_SIACC_ESPECIAL == "NAO")
            {

                /*" -2884- IF TITLE-MEDI-GERAL EQUAL 'Z004' */

                if (W_REGISTRO_SIAS_GERAL.TITLE_MEDI_GERAL == "Z004")
                {

                    /*" -2886- PERFORM R3020-ENDERECO-CAIXA-SEGUROS THRU R3020-EXIT. */

                    R3020_ENDERECO_CAIXA_SEGUROS(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R3020_EXIT*/

                }

            }


            /*" -2887- IF REGION-FSCL-GERAL EQUAL ' ' */

            if (W_REGISTRO_SIAS_GERAL.REGION_FSCL_GERAL == " ")
            {

                /*" -2888- MOVE 'XX' TO REGION-FSCL-GERAL. */
                _.Move("XX", W_REGISTRO_SIAS_GERAL.REGION_FSCL_GERAL);
            }


            /*" -2889- IF REGION-COR-GERAL EQUAL ' ' */

            if (W_REGISTRO_SIAS_GERAL.REGION_COR_GERAL == " ")
            {

                /*" -2889- MOVE 'XX' TO REGION-COR-GERAL . */
                _.Move("XX", W_REGISTRO_SIAS_GERAL.REGION_COR_GERAL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_EXIT*/

        [StopWatch]
        /*" R3005-LIMPA-OS-COD-E-VALOR */
        private void R3005_LIMPA_OS_COD_E_VALOR(bool isPerform = false)
        {
            /*" -2896- MOVE ZEROS TO W-VALOR-GERAL-VALOR. */
            _.Move(0, AREA_DE_WORK.W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

            /*" -2905- MOVE W-VALOR-GERAL-X TO VALO06-GERAL VALO07-GERAL VALO08-GERAL VALO09-GERAL VALO010-GERAL VALO011-GERAL VALO012-GERAL VALO013-GERAL VALO014-GERAL VALO015-GERAL VALO016-GERAL VALO017-GERAL VALO018-GERAL VALO019-GERAL. */
            _.Move(AREA_DE_WORK.W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO06_GERAL, W_REGISTRO_SIAS_GERAL.VALO07_GERAL, W_REGISTRO_SIAS_GERAL.VALO08_GERAL, W_REGISTRO_SIAS_GERAL.VALO09_GERAL, W_REGISTRO_SIAS_GERAL.VALO010_GERAL, W_REGISTRO_SIAS_GERAL.VALO011_GERAL, W_REGISTRO_SIAS_GERAL.VALO012_GERAL, W_REGISTRO_SIAS_GERAL.VALO013_GERAL, W_REGISTRO_SIAS_GERAL.VALO014_GERAL, W_REGISTRO_SIAS_GERAL.VALO015_GERAL, W_REGISTRO_SIAS_GERAL.VALO016_GERAL, W_REGISTRO_SIAS_GERAL.VALO017_GERAL, W_REGISTRO_SIAS_GERAL.VALO018_GERAL, W_REGISTRO_SIAS_GERAL.VALO019_GERAL);

            /*" -2907- MOVE 'CV_IRFBS' TO COD06-GERAL */
            _.Move("CV_IRFBS", W_REGISTRO_SIAS_GERAL.COD06_GERAL);

            /*" -2909- MOVE 'CV_IRFRT' TO COD07-GERAL */
            _.Move("CV_IRFRT", W_REGISTRO_SIAS_GERAL.COD07_GERAL);

            /*" -2911- MOVE 'CV_ISSBS' TO COD08-GERAL */
            _.Move("CV_ISSBS", W_REGISTRO_SIAS_GERAL.COD08_GERAL);

            /*" -2913- MOVE 'CV_ISSRT' TO COD09-GERAL */
            _.Move("CV_ISSRT", W_REGISTRO_SIAS_GERAL.COD09_GERAL);

            /*" -2915- MOVE 'CV_INSBS' TO COD010-GERAL */
            _.Move("CV_INSBS", W_REGISTRO_SIAS_GERAL.COD010_GERAL);

            /*" -2917- MOVE 'CV_INSRT' TO COD011-GERAL */
            _.Move("CV_INSRT", W_REGISTRO_SIAS_GERAL.COD011_GERAL);

            /*" -2919- MOVE 'CV_PISBS' TO COD012-GERAL */
            _.Move("CV_PISBS", W_REGISTRO_SIAS_GERAL.COD012_GERAL);

            /*" -2921- MOVE 'CV_PISRT' TO COD013-GERAL */
            _.Move("CV_PISRT", W_REGISTRO_SIAS_GERAL.COD013_GERAL);

            /*" -2923- MOVE 'CV_COFBS' TO COD014-GERAL */
            _.Move("CV_COFBS", W_REGISTRO_SIAS_GERAL.COD014_GERAL);

            /*" -2925- MOVE 'CV_COFRT' TO COD015-GERAL */
            _.Move("CV_COFRT", W_REGISTRO_SIAS_GERAL.COD015_GERAL);

            /*" -2927- MOVE 'CV_CSLBS' TO COD016-GERAL */
            _.Move("CV_CSLBS", W_REGISTRO_SIAS_GERAL.COD016_GERAL);

            /*" -2929- MOVE 'CV_CSLRT' TO COD017-GERAL */
            _.Move("CV_CSLRT", W_REGISTRO_SIAS_GERAL.COD017_GERAL);

            /*" -2931- MOVE 'CV_IRJBS' TO COD018-GERAL */
            _.Move("CV_IRJBS", W_REGISTRO_SIAS_GERAL.COD018_GERAL);

            /*" -2935- MOVE 'CV_IRJRT' TO COD019-GERAL */
            _.Move("CV_IRJRT", W_REGISTRO_SIAS_GERAL.COD019_GERAL);

            /*" -2936- MOVE 'CV_INPBS' TO COD020-GERAL. */
            _.Move("CV_INPBS", W_REGISTRO_SIAS_GERAL.COD020_GERAL);

            /*" -2937- MOVE 0 TO W-VALOR-GERAL-VALOR */
            _.Move(0, AREA_DE_WORK.W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

            /*" -2940- MOVE W-VALOR-GERAL-X TO VALO020-GERAL. */
            _.Move(AREA_DE_WORK.W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO020_GERAL);

            /*" -2941- MOVE 'CV_INPRT' TO COD021-GERAL. */
            _.Move("CV_INPRT", W_REGISTRO_SIAS_GERAL.COD021_GERAL);

            /*" -2942- MOVE 0 TO W-VALOR-GERAL-VALOR */
            _.Move(0, AREA_DE_WORK.W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

            /*" -2944- MOVE W-VALOR-GERAL-X TO VALO021-GERAL. */
            _.Move(AREA_DE_WORK.W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO021_GERAL);

            /*" -2945- MOVE SPACES TO COD022-GERAL VALO022-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD022_GERAL, W_REGISTRO_SIAS_GERAL.VALO022_GERAL);

            /*" -2946- MOVE SPACES TO COD023-GERAL VALO023-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD023_GERAL, W_REGISTRO_SIAS_GERAL.VALO023_GERAL);

            /*" -2947- MOVE SPACES TO COD024-GERAL VALO024-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD024_GERAL, W_REGISTRO_SIAS_GERAL.VALO024_GERAL);

            /*" -2947- MOVE SPACES TO COD025-GERAL VALO025-GERAL . */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD025_GERAL, W_REGISTRO_SIAS_GERAL.VALO025_GERAL);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3005_EXIT*/

        [StopWatch]
        /*" R3010-ACESSA-SCPJUD */
        private void R3010_ACESSA_SCPJUD(bool isPerform = false)
        {
            /*" -2959- PERFORM R3010_ACESSA_SCPJUD_DB_SELECT_1 */

            R3010_ACESSA_SCPJUD_DB_SELECT_1();

            /*" -2962- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -2963- DISPLAY 'SISAP15B - ERRO COUNT SI_PROCESSO_JURID (1)' */
                _.Display($"SISAP15B - ERRO COUNT SI_PROCESSO_JURID (1)");

                /*" -2965- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -2966- IF HOST-COUNT EQUAL 0 */

            if (HOST_COUNT == 0)
            {

                /*" -2968- GO TO R3010-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3010_EXIT*/ //GOTO
                return;
            }


            /*" -2979- PERFORM R3010_ACESSA_SCPJUD_DB_SELECT_2 */

            R3010_ACESSA_SCPJUD_DB_SELECT_2();

            /*" -2982- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -2983- DISPLAY 'SISAP15B - ERRO COUNT SI_PROCESSO_JURID (2)' */
                _.Display($"SISAP15B - ERRO COUNT SI_PROCESSO_JURID (2)");

                /*" -2983- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3010-ACESSA-SCPJUD-DB-SELECT-1 */
        public void R3010_ACESSA_SCPJUD_DB_SELECT_1()
        {
            /*" -2959- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :HOST-COUNT FROM SEGUROS.SI_PROCESSO_JURID WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO WITH UR END-EXEC. */

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
            /*" -2979- EXEC SQL SELECT COD_PROCESSO_JURID INTO :SIPROJUD-COD-PROCESSO-JURID FROM SEGUROS.SI_PROCESSO_JURID WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND DTH_TIMESTAMP = ( SELECT MIN(DTH_TIMESTAMP) FROM SEGUROS.SI_PROCESSO_JURID WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO ) WITH UR END-EXEC. */

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
            /*" -2990- MOVE 'Q SCN QUADRA 01' TO STREET-FSCL-GERAL */
            _.Move("Q SCN QUADRA 01", W_REGISTRO_SIAS_GERAL.STREET_FSCL_GERAL);

            /*" -2991- MOVE 'ED. # 1' TO HOUSE-NUM1-FSCL-GERAL */
            _.Move("ED. # 1", W_REGISTRO_SIAS_GERAL.HOUSE_NUM1_FSCL_GERAL);

            /*" -2992- MOVE ' 17 ANDAR' TO HOUSE-NUM2-FSCL-GERAL */
            _.Move(" 17 ANDAR", W_REGISTRO_SIAS_GERAL.HOUSE_NUM2_FSCL_GERAL);

            /*" -2993- MOVE '70711-900' TO POST-CODE1-FSCL-GERAL */
            _.Move("70711-900", W_REGISTRO_SIAS_GERAL.POST_CODE1_FSCL_GERAL);

            /*" -2994- MOVE 'DF' TO REGION-FSCL-GERAL */
            _.Move("DF", W_REGISTRO_SIAS_GERAL.REGION_FSCL_GERAL);

            /*" -2995- MOVE 'BRASILIA' TO CITY1-FSCL-GERAL */
            _.Move("BRASILIA", W_REGISTRO_SIAS_GERAL.CITY1_FSCL_GERAL);

            /*" -2996- MOVE 'SETOR COMERCIAL NORTE' TO CITY2-FSCL-GERAL */
            _.Move("SETOR COMERCIAL NORTE", W_REGISTRO_SIAS_GERAL.CITY2_FSCL_GERAL);

            /*" -2998- MOVE 'BR' TO COUNTRY-FSCL-GERAL */
            _.Move("BR", W_REGISTRO_SIAS_GERAL.COUNTRY_FSCL_GERAL);

            /*" -2999- MOVE 'Q SCN QUADRA 01' TO STREET-COR-GERAL */
            _.Move("Q SCN QUADRA 01", W_REGISTRO_SIAS_GERAL.STREET_COR_GERAL);

            /*" -3000- MOVE 'ED. # 1' TO HOUSE-NUM1-COR-GERAL */
            _.Move("ED. # 1", W_REGISTRO_SIAS_GERAL.HOUSE_NUM1_COR_GERAL);

            /*" -3001- MOVE ' 17 ANDAR' TO HOUSE-NUM2-COR-GERAL */
            _.Move(" 17 ANDAR", W_REGISTRO_SIAS_GERAL.HOUSE_NUM2_COR_GERAL);

            /*" -3002- MOVE '70711-900' TO POST-CODE1-COR-GERAL */
            _.Move("70711-900", W_REGISTRO_SIAS_GERAL.POST_CODE1_COR_GERAL);

            /*" -3003- MOVE 'DF' TO REGION-COR-GERAL */
            _.Move("DF", W_REGISTRO_SIAS_GERAL.REGION_COR_GERAL);

            /*" -3004- MOVE 'BRASILIA' TO CITY1-COR-GERAL */
            _.Move("BRASILIA", W_REGISTRO_SIAS_GERAL.CITY1_COR_GERAL);

            /*" -3005- MOVE 'SETOR COMERCIAL NORTE' TO CITY2-COR-GERAL */
            _.Move("SETOR COMERCIAL NORTE", W_REGISTRO_SIAS_GERAL.CITY2_COR_GERAL);

            /*" -3007- MOVE 'BR' TO COUNTRY-COR-GERAL. */
            _.Move("BR", W_REGISTRO_SIAS_GERAL.COUNTRY_COR_GERAL);

            /*" -3008- IF REGION-FSCL-GERAL EQUAL ' ' */

            if (W_REGISTRO_SIAS_GERAL.REGION_FSCL_GERAL == " ")
            {

                /*" -3009- MOVE 'XX' TO REGION-FSCL-GERAL. */
                _.Move("XX", W_REGISTRO_SIAS_GERAL.REGION_FSCL_GERAL);
            }


            /*" -3010- IF REGION-COR-GERAL EQUAL ' ' */

            if (W_REGISTRO_SIAS_GERAL.REGION_COR_GERAL == " ")
            {

                /*" -3010- MOVE 'XX' TO REGION-COR-GERAL . */
                _.Move("XX", W_REGISTRO_SIAS_GERAL.REGION_COR_GERAL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3020_EXIT*/

        [StopWatch]
        /*" R3100-DADOS-FINAL-ARQUIVO */
        private void R3100_DADOS_FINAL_ARQUIVO(bool isPerform = false)
        {
            /*" -3017- MOVE 'C000' TO CODEMP-GERAL. */
            _.Move("C000", W_REGISTRO_SIAS_GERAL.CODEMP_GERAL);

            /*" -3019- MOVE 'BRL' TO MOEDABP-GERAL. */
            _.Move("BRL", W_REGISTRO_SIAS_GERAL.MOEDABP_GERAL);

            /*" -3020- MOVE 'BR2' TO TAXTYPE-CPF-GERAL */
            _.Move("BR2", W_REGISTRO_SIAS_GERAL.TAXTYPE_CPF_GERAL);

            /*" -3026- MOVE 'BR1' TO TAXTYPE-CNPJ-GERAL */
            _.Move("BR1", W_REGISTRO_SIAS_GERAL.TAXTYPE_CNPJ_GERAL);

            /*" -3028- IF LK-SAP-COD-PROGRAMA EQUAL 'FI0096B' OR 'SI5067B' OR 'SI5071B' */

            if (REGISTRO_LINKAGE_SAP.LK_SAP_COD_PROGRAMA.In("FI0096B", "SI5067B", "SI5071B"))
            {

                /*" -3029- MOVE 'SIM' TO W-CHAVE-MONTA-SIACC-ESPECIAL */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_MONTA_SIACC_ESPECIAL);

                /*" -3030- PERFORM R3300-MONTA-SIACC-IND-REP THRU R3300-EXIT */

                R3300_MONTA_SIACC_IND_REP(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3300_EXIT*/


                /*" -3032- GO TO R3100-CONTINUA-MONTAGEM. */

                R3100_CONTINUA_MONTAGEM(); //GOTO
                return;
            }


            /*" -3033- IF W-CHAVE-ORIGEM-CADASTRO EQUAL 'ODS' */

            if (AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO == "ODS")
            {

                /*" -3034- IF OD001-IND-PESSOA EQUAL 'F' */

                if (OD001.DCLOD_PESSOA.OD001_IND_PESSOA == "F")
                {

                    /*" -3035- MOVE 'X' TO NATPERS-GERAL */
                    _.Move("X", W_REGISTRO_SIAS_GERAL.NATPERS_GERAL);

                    /*" -3036- MOVE 'Z003' TO TITLE-MEDI-GERAL */
                    _.Move("Z003", W_REGISTRO_SIAS_GERAL.TITLE_MEDI_GERAL);

                    /*" -3037- IF NULL-NOM-PESSOA >= 0 */

                    if (NULL_NOM_PESSOA >= 0)
                    {

                        /*" -3039- MOVE OD002-NOM-PESSOA-TEXT TO NAME-FIRST-GERAL */
                        _.Move(DCLOD_PESSOA_FISICA.OD002_NOM_PESSOA.OD002_NOM_PESSOA_TEXT, W_REGISTRO_SIAS_GERAL.NAME_FIRST_GERAL);

                        /*" -3040- ELSE */
                    }
                    else
                    {


                        /*" -3041- MOVE ALL '?1' TO NAME-FIRST-GERAL */
                        _.MoveAll("?1", W_REGISTRO_SIAS_GERAL.NAME_FIRST_GERAL);

                        /*" -3042- END-IF */
                    }


                    /*" -3043- MOVE 'BR2' TO TAXTYPE-CPF-GERAL */
                    _.Move("BR2", W_REGISTRO_SIAS_GERAL.TAXTYPE_CPF_GERAL);

                    /*" -3044- IF NULL-NUM-CPF >= 0 */

                    if (NULL_NUM_CPF >= 0)
                    {

                        /*" -3045- MOVE W-NUM-CPF-ALFA TO TAXNUM-CPF-GERAL */
                        _.Move(AREA_DE_WORK.W_NUM_CPF_ALFA, W_REGISTRO_SIAS_GERAL.TAXNUM_CPF_GERAL);

                        /*" -3046- ELSE */
                    }
                    else
                    {


                        /*" -3047- MOVE ALL '?9' TO TAXNUM-CPF-GERAL */
                        _.MoveAll("?9", W_REGISTRO_SIAS_GERAL.TAXNUM_CPF_GERAL);

                        /*" -3048- END-IF */
                    }


                    /*" -3049- ELSE */
                }
                else
                {


                    /*" -3050- IF OD001-IND-PESSOA EQUAL 'J' */

                    if (OD001.DCLOD_PESSOA.OD001_IND_PESSOA == "J")
                    {

                        /*" -3051- MOVE ' ' TO NATPERS-GERAL */
                        _.Move(" ", W_REGISTRO_SIAS_GERAL.NATPERS_GERAL);

                        /*" -3052- MOVE '0003' TO TITLE-MEDI-GERAL */
                        _.Move("0003", W_REGISTRO_SIAS_GERAL.TITLE_MEDI_GERAL);

                        /*" -3053- IF NULL-NOM-RAZAO-SOCIAL >= 0 */

                        if (NULL_NOM_RAZAO_SOCIAL >= 0)
                        {

                            /*" -3055- MOVE OD003-NOM-RAZAO-SOCIAL-TEXT TO NAME-ORG1-GERAL */
                            _.Move(OD003.DCLOD_PESSOA_JURIDICA.OD003_NOM_RAZAO_SOCIAL.OD003_NOM_RAZAO_SOCIAL_TEXT, W_REGISTRO_SIAS_GERAL.NAME_ORG1_GERAL);

                            /*" -3056- ELSE */
                        }
                        else
                        {


                            /*" -3057- MOVE ALL '?2' TO NAME-ORG1-GERAL */
                            _.MoveAll("?2", W_REGISTRO_SIAS_GERAL.NAME_ORG1_GERAL);

                            /*" -3058- END-IF */
                        }


                        /*" -3059- MOVE 'BR1' TO TAXTYPE-CNPJ-GERAL */
                        _.Move("BR1", W_REGISTRO_SIAS_GERAL.TAXTYPE_CNPJ_GERAL);

                        /*" -3060- IF NULL-NUM-CNPJ >= 0 */

                        if (NULL_NUM_CNPJ >= 0)
                        {

                            /*" -3061- MOVE W-NUM-CNPJ-ALFA TO TAXNUM-CNPJ-GERAL */
                            _.Move(AREA_DE_WORK.W_NUM_CNPJ_ALFA, W_REGISTRO_SIAS_GERAL.TAXNUM_CNPJ_GERAL);

                            /*" -3062- ELSE */
                        }
                        else
                        {


                            /*" -3063- MOVE ALL '?10' TO TAXNUM-CNPJ-GERAL */
                            _.MoveAll("?10", W_REGISTRO_SIAS_GERAL.TAXNUM_CNPJ_GERAL);

                            /*" -3064- END-IF */
                        }


                        /*" -3065- ELSE */
                    }
                    else
                    {


                        /*" -3066- MOVE '?' TO NATPERS-GERAL */
                        _.Move("?", W_REGISTRO_SIAS_GERAL.NATPERS_GERAL);

                        /*" -3067- MOVE 'Z004' TO TITLE-MEDI-GERAL */
                        _.Move("Z004", W_REGISTRO_SIAS_GERAL.TITLE_MEDI_GERAL);

                        /*" -3068- MOVE ALL '?12' TO TAXNUM-CPF-GERAL */
                        _.MoveAll("?12", W_REGISTRO_SIAS_GERAL.TAXNUM_CPF_GERAL);

                        /*" -3070- MOVE ALL '?11' TO TAXNUM-CNPJ-GERAL. */
                        _.MoveAll("?11", W_REGISTRO_SIAS_GERAL.TAXNUM_CNPJ_GERAL);
                    }

                }

            }


            /*" -3071- IF W-CHAVE-ORIGEM-CADASTRO EQUAL 'FORNECEDOR OU LOTERICO' */

            if (AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO == "FORNECEDOR OU LOTERICO")
            {

                /*" -3072- IF FORNECED-TIPO-PESSOA EQUAL 'F' */

                if (FORNECED.DCLFORNECEDORES.FORNECED_TIPO_PESSOA == "F")
                {

                    /*" -3073- MOVE 'X' TO NATPERS-GERAL */
                    _.Move("X", W_REGISTRO_SIAS_GERAL.NATPERS_GERAL);

                    /*" -3074- MOVE 'Z003' TO TITLE-MEDI-GERAL */
                    _.Move("Z003", W_REGISTRO_SIAS_GERAL.TITLE_MEDI_GERAL);

                    /*" -3075- MOVE FORNECED-NOME-FORNECEDOR TO NAME-FIRST-GERAL */
                    _.Move(FORNECED.DCLFORNECEDORES.FORNECED_NOME_FORNECEDOR, W_REGISTRO_SIAS_GERAL.NAME_FIRST_GERAL);

                    /*" -3076- MOVE 'BR2' TO TAXTYPE-CPF-GERAL */
                    _.Move("BR2", W_REGISTRO_SIAS_GERAL.TAXTYPE_CPF_GERAL);

                    /*" -3077- MOVE W-NUM-CPF-ALFA TO TAXNUM-CPF-GERAL */
                    _.Move(AREA_DE_WORK.W_NUM_CPF_ALFA, W_REGISTRO_SIAS_GERAL.TAXNUM_CPF_GERAL);

                    /*" -3078- ELSE */
                }
                else
                {


                    /*" -3079- IF FORNECED-TIPO-PESSOA EQUAL 'J' */

                    if (FORNECED.DCLFORNECEDORES.FORNECED_TIPO_PESSOA == "J")
                    {

                        /*" -3080- MOVE ' ' TO NATPERS-GERAL */
                        _.Move(" ", W_REGISTRO_SIAS_GERAL.NATPERS_GERAL);

                        /*" -3081- MOVE '0003' TO TITLE-MEDI-GERAL */
                        _.Move("0003", W_REGISTRO_SIAS_GERAL.TITLE_MEDI_GERAL);

                        /*" -3082- MOVE FORNECED-NOME-FORNECEDOR TO NAME-ORG1-GERAL */
                        _.Move(FORNECED.DCLFORNECEDORES.FORNECED_NOME_FORNECEDOR, W_REGISTRO_SIAS_GERAL.NAME_ORG1_GERAL);

                        /*" -3083- MOVE 'BR1' TO TAXTYPE-CNPJ-GERAL */
                        _.Move("BR1", W_REGISTRO_SIAS_GERAL.TAXTYPE_CNPJ_GERAL);

                        /*" -3084- MOVE W-NUM-CNPJ-ALFA TO TAXNUM-CNPJ-GERAL */
                        _.Move(AREA_DE_WORK.W_NUM_CNPJ_ALFA, W_REGISTRO_SIAS_GERAL.TAXNUM_CNPJ_GERAL);

                        /*" -3085- ELSE */
                    }
                    else
                    {


                        /*" -3086- MOVE '?' TO NATPERS-GERAL */
                        _.Move("?", W_REGISTRO_SIAS_GERAL.NATPERS_GERAL);

                        /*" -3087- MOVE ALL '?4' TO NAME-FIRST-GERAL */
                        _.MoveAll("?4", W_REGISTRO_SIAS_GERAL.NAME_FIRST_GERAL);

                        /*" -3089- MOVE ALL '?5' TO NAME-ORG1-GERAL. */
                        _.MoveAll("?5", W_REGISTRO_SIAS_GERAL.NAME_ORG1_GERAL);
                    }

                }

            }


            /*" -3090- IF W-CHAVE-ORIGEM-CADASTRO EQUAL 'SEM CADASTRO' */

            if (AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO == "SEM CADASTRO")
            {

                /*" -3091- MOVE SINISHIS-NOME-FAVORECIDO TO NAME-ORG1-GERAL */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO, W_REGISTRO_SIAS_GERAL.NAME_ORG1_GERAL);

                /*" -3092- MOVE ' ' TO NATPERS-GERAL */
                _.Move(" ", W_REGISTRO_SIAS_GERAL.NATPERS_GERAL);

                /*" -3094- MOVE 'Z004' TO TITLE-MEDI-GERAL . */
                _.Move("Z004", W_REGISTRO_SIAS_GERAL.TITLE_MEDI_GERAL);
            }


            /*" -3095- IF NAME-FIRST-GERAL NOT EQUAL SPACES */

            if (!W_REGISTRO_SIAS_GERAL.NAME_FIRST_GERAL.IsEmpty())
            {

                /*" -3096- MOVE NAME-FIRST-GERAL TO CT0007S-NOME */
                _.Move(W_REGISTRO_SIAS_GERAL.NAME_FIRST_GERAL, REG_LK_BANCOS.CT0007SW099.CT0007S_NOME);

                /*" -3097- CALL 'CT0007S' USING CT0007SW099 */
                _.Call("CT0007S", REG_LK_BANCOS.CT0007SW099);

                /*" -3098- IF CT0007S-SOBRENOME EQUAL ' ' */

                if (REG_LK_BANCOS.CT0007SW099.CT0007S_SOBRENOME == " ")
                {

                    /*" -3099- MOVE ALL '?8' TO NAME-LAST-GERAL */
                    _.MoveAll("?8", W_REGISTRO_SIAS_GERAL.NAME_LAST_GERAL);

                    /*" -3100- ELSE */
                }
                else
                {


                    /*" -3101- MOVE CT0007S-NOME1 TO NAME-FIRST-GERAL */
                    _.Move(REG_LK_BANCOS.CT0007SW099.CT0007S_NOME1, W_REGISTRO_SIAS_GERAL.NAME_FIRST_GERAL);

                    /*" -3103- MOVE CT0007S-SOBRENOME TO NAME-LAST-GERAL. */
                    _.Move(REG_LK_BANCOS.CT0007SW099.CT0007S_SOBRENOME, W_REGISTRO_SIAS_GERAL.NAME_LAST_GERAL);
                }

            }


            /*" -3104- IF W-CHAVE-EH-PRESTADOR EQUAL 'SIM' */

            if (AREA_DE_WORK.W_CHAVE_EH_PRESTADOR == "SIM")
            {

                /*" -3106- PERFORM R3200-MONTA-PRESTADOR THRU R3200-EXIT. */

                R3200_MONTA_PRESTADOR(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_EXIT*/

            }


            /*" -3108- MOVE 'NAO' TO W-CHAVE-COLOCA-ENDERECO */
            _.Move("NAO", AREA_DE_WORK.W_CHAVE_COLOCA_ENDERECO);

            /*" -3109- IF W-CHAVE-ORIGEM-CADASTRO EQUAL 'ODS' */

            if (AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO == "ODS")
            {

                /*" -3110- IF NULL-NOM-LOGRADOURO >= 0 */

                if (NULL_NOM_LOGRADOURO >= 0)
                {

                    /*" -3111- MOVE OD007-NOM-LOGRADOURO TO STREET-FSCL-GERAL */
                    _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_LOGRADOURO, W_REGISTRO_SIAS_GERAL.STREET_FSCL_GERAL);

                    /*" -3112- MOVE OD007-NOM-LOGRADOURO TO STREET-COR-GERAL */
                    _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_LOGRADOURO, W_REGISTRO_SIAS_GERAL.STREET_COR_GERAL);

                    /*" -3113- ELSE */
                }
                else
                {


                    /*" -3114- MOVE 'SIM' TO W-CHAVE-COLOCA-ENDERECO */
                    _.Move("SIM", AREA_DE_WORK.W_CHAVE_COLOCA_ENDERECO);

                    /*" -3115- MOVE ALL '?30' TO STREET-FSCL-GERAL */
                    _.MoveAll("?30", W_REGISTRO_SIAS_GERAL.STREET_FSCL_GERAL);

                    /*" -3116- MOVE ALL '?30' TO STREET-COR-GERAL */
                    _.MoveAll("?30", W_REGISTRO_SIAS_GERAL.STREET_COR_GERAL);

                    /*" -3117- END-IF */
                }


                /*" -3118- IF NULL-DES-NUM-IMOVEL >= 0 */

                if (NULL_DES_NUM_IMOVEL >= 0)
                {

                    /*" -3119- MOVE OD007-DES-NUM-IMOVEL TO HOUSE-NUM1-FSCL-GERAL */
                    _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_DES_NUM_IMOVEL, W_REGISTRO_SIAS_GERAL.HOUSE_NUM1_FSCL_GERAL);

                    /*" -3120- MOVE OD007-DES-NUM-IMOVEL TO HOUSE-NUM1-COR-GERAL */
                    _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_DES_NUM_IMOVEL, W_REGISTRO_SIAS_GERAL.HOUSE_NUM1_COR_GERAL);

                    /*" -3121- ELSE */
                }
                else
                {


                    /*" -3122- MOVE 'SIM' TO W-CHAVE-COLOCA-ENDERECO */
                    _.Move("SIM", AREA_DE_WORK.W_CHAVE_COLOCA_ENDERECO);

                    /*" -3123- MOVE ALL '?31' TO HOUSE-NUM1-FSCL-GERAL */
                    _.MoveAll("?31", W_REGISTRO_SIAS_GERAL.HOUSE_NUM1_FSCL_GERAL);

                    /*" -3124- MOVE ALL '?31' TO HOUSE-NUM1-COR-GERAL */
                    _.MoveAll("?31", W_REGISTRO_SIAS_GERAL.HOUSE_NUM1_COR_GERAL);

                    /*" -3125- END-IF */
                }


                /*" -3126- IF NULL-DES-COMPL-ENDERECO >= 0 */

                if (NULL_DES_COMPL_ENDERECO >= 0)
                {

                    /*" -3127- MOVE OD007-DES-COMPL-ENDERECO TO HOUSE-NUM2-FSCL-GERAL */
                    _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_DES_COMPL_ENDERECO, W_REGISTRO_SIAS_GERAL.HOUSE_NUM2_FSCL_GERAL);

                    /*" -3128- MOVE OD007-DES-COMPL-ENDERECO TO HOUSE-NUM2-COR-GERAL */
                    _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_DES_COMPL_ENDERECO, W_REGISTRO_SIAS_GERAL.HOUSE_NUM2_COR_GERAL);

                    /*" -3129- ELSE */
                }
                else
                {


                    /*" -3130- MOVE 'SIM' TO W-CHAVE-COLOCA-ENDERECO */
                    _.Move("SIM", AREA_DE_WORK.W_CHAVE_COLOCA_ENDERECO);

                    /*" -3131- MOVE ALL '?32' TO HOUSE-NUM2-FSCL-GERAL */
                    _.MoveAll("?32", W_REGISTRO_SIAS_GERAL.HOUSE_NUM2_FSCL_GERAL);

                    /*" -3132- MOVE ALL '?32' TO HOUSE-NUM2-COR-GERAL */
                    _.MoveAll("?32", W_REGISTRO_SIAS_GERAL.HOUSE_NUM2_COR_GERAL);

                    /*" -3133- END-IF */
                }


                /*" -3134- IF NULL-COD-CEP >= 0 */

                if (NULL_COD_CEP >= 0)
                {

                    /*" -3135- MOVE W-CEP-ALFA TO POST-CODE1-FSCL-GERAL */
                    _.Move(AREA_DE_WORK.W_CEP_ALFA, W_REGISTRO_SIAS_GERAL.POST_CODE1_FSCL_GERAL);

                    /*" -3136- MOVE W-CEP-ALFA TO POST-CODE1-COR-GERAL */
                    _.Move(AREA_DE_WORK.W_CEP_ALFA, W_REGISTRO_SIAS_GERAL.POST_CODE1_COR_GERAL);

                    /*" -3137- ELSE */
                }
                else
                {


                    /*" -3138- MOVE '99999-999' TO POST-CODE1-FSCL-GERAL */
                    _.Move("99999-999", W_REGISTRO_SIAS_GERAL.POST_CODE1_FSCL_GERAL);

                    /*" -3139- MOVE '99999-999' TO POST-CODE1-COR-GERAL */
                    _.Move("99999-999", W_REGISTRO_SIAS_GERAL.POST_CODE1_COR_GERAL);

                    /*" -3140- END-IF */
                }


                /*" -3141- IF NULL-COD-UF >= 0 */

                if (NULL_COD_UF >= 0)
                {

                    /*" -3142- MOVE OD007-COD-UF TO REGION-FSCL-GERAL */
                    _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_UF, W_REGISTRO_SIAS_GERAL.REGION_FSCL_GERAL);

                    /*" -3143- MOVE OD007-COD-UF TO REGION-COR-GERAL */
                    _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_UF, W_REGISTRO_SIAS_GERAL.REGION_COR_GERAL);

                    /*" -3144- ELSE */
                }
                else
                {


                    /*" -3145- MOVE 'XX' TO REGION-FSCL-GERAL */
                    _.Move("XX", W_REGISTRO_SIAS_GERAL.REGION_FSCL_GERAL);

                    /*" -3146- MOVE 'XX' TO REGION-COR-GERAL */
                    _.Move("XX", W_REGISTRO_SIAS_GERAL.REGION_COR_GERAL);

                    /*" -3147- END-IF */
                }


                /*" -3148- IF NULL-NOM-CIDADE >= 0 */

                if (NULL_NOM_CIDADE >= 0)
                {

                    /*" -3149- MOVE OD007-NOM-CIDADE TO CITY1-FSCL-GERAL */
                    _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_CIDADE, W_REGISTRO_SIAS_GERAL.CITY1_FSCL_GERAL);

                    /*" -3150- MOVE OD007-NOM-CIDADE TO CITY1-COR-GERAL */
                    _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_CIDADE, W_REGISTRO_SIAS_GERAL.CITY1_COR_GERAL);

                    /*" -3151- ELSE */
                }
                else
                {


                    /*" -3152- MOVE 'SIM' TO W-CHAVE-COLOCA-ENDERECO */
                    _.Move("SIM", AREA_DE_WORK.W_CHAVE_COLOCA_ENDERECO);

                    /*" -3153- MOVE ALL '?35' TO CITY1-FSCL-GERAL */
                    _.MoveAll("?35", W_REGISTRO_SIAS_GERAL.CITY1_FSCL_GERAL);

                    /*" -3154- MOVE ALL '?35' TO CITY1-COR-GERAL */
                    _.MoveAll("?35", W_REGISTRO_SIAS_GERAL.CITY1_COR_GERAL);

                    /*" -3155- END-IF */
                }


                /*" -3156- IF NULL-NOM-BAIRRO >= 0 */

                if (NULL_NOM_BAIRRO >= 0)
                {

                    /*" -3157- MOVE OD007-NOM-BAIRRO TO CITY2-FSCL-GERAL */
                    _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_BAIRRO, W_REGISTRO_SIAS_GERAL.CITY2_FSCL_GERAL);

                    /*" -3158- MOVE OD007-NOM-BAIRRO TO CITY2-COR-GERAL */
                    _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_BAIRRO, W_REGISTRO_SIAS_GERAL.CITY2_COR_GERAL);

                    /*" -3159- ELSE */
                }
                else
                {


                    /*" -3160- MOVE 'SIM' TO W-CHAVE-COLOCA-ENDERECO */
                    _.Move("SIM", AREA_DE_WORK.W_CHAVE_COLOCA_ENDERECO);

                    /*" -3161- MOVE ALL '?36' TO CITY1-FSCL-GERAL */
                    _.MoveAll("?36", W_REGISTRO_SIAS_GERAL.CITY1_FSCL_GERAL);

                    /*" -3162- MOVE ALL '?36' TO CITY1-COR-GERAL */
                    _.MoveAll("?36", W_REGISTRO_SIAS_GERAL.CITY1_COR_GERAL);

                    /*" -3164- END-IF . */
                }

            }


            /*" -3166- IF W-CHAVE-COLOCA-ENDERECO EQUAL 'SIM' OR W-CHAVE-ORIGEM-CADASTRO EQUAL 'SEM CADASTRO' */

            if (AREA_DE_WORK.W_CHAVE_COLOCA_ENDERECO == "SIM" || AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO == "SEM CADASTRO")
            {

                /*" -3168- PERFORM R3020-ENDERECO-CAIXA-SEGUROS THRU R3020-EXIT. */

                R3020_ENDERECO_CAIXA_SEGUROS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3020_EXIT*/

            }


            /*" -3169- IF W-CHAVE-ORIGEM-CADASTRO EQUAL 'FORNECEDOR OU LOTERICO' */

            if (AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO == "FORNECEDOR OU LOTERICO")
            {

                /*" -3170- MOVE FORNECED-ENDERECO TO STREET-FSCL-GERAL */
                _.Move(FORNECED.DCLFORNECEDORES.FORNECED_ENDERECO, W_REGISTRO_SIAS_GERAL.STREET_FSCL_GERAL);

                /*" -3171- MOVE FORNECED-ENDERECO TO STREET-COR-GERAL */
                _.Move(FORNECED.DCLFORNECEDORES.FORNECED_ENDERECO, W_REGISTRO_SIAS_GERAL.STREET_COR_GERAL);

                /*" -3172- MOVE W-CEP-ALFA TO POST-CODE1-FSCL-GERAL */
                _.Move(AREA_DE_WORK.W_CEP_ALFA, W_REGISTRO_SIAS_GERAL.POST_CODE1_FSCL_GERAL);

                /*" -3173- MOVE W-CEP-ALFA TO POST-CODE1-COR-GERAL */
                _.Move(AREA_DE_WORK.W_CEP_ALFA, W_REGISTRO_SIAS_GERAL.POST_CODE1_COR_GERAL);

                /*" -3174- MOVE FORNECED-SIGLA-UF TO REGION-FSCL-GERAL */
                _.Move(FORNECED.DCLFORNECEDORES.FORNECED_SIGLA_UF, W_REGISTRO_SIAS_GERAL.REGION_FSCL_GERAL);

                /*" -3175- MOVE FORNECED-SIGLA-UF TO REGION-COR-GERAL */
                _.Move(FORNECED.DCLFORNECEDORES.FORNECED_SIGLA_UF, W_REGISTRO_SIAS_GERAL.REGION_COR_GERAL);

                /*" -3176- MOVE FORNECED-CIDADE TO CITY1-FSCL-GERAL */
                _.Move(FORNECED.DCLFORNECEDORES.FORNECED_CIDADE, W_REGISTRO_SIAS_GERAL.CITY1_FSCL_GERAL);

                /*" -3177- MOVE FORNECED-CIDADE TO CITY1-COR-GERAL */
                _.Move(FORNECED.DCLFORNECEDORES.FORNECED_CIDADE, W_REGISTRO_SIAS_GERAL.CITY1_COR_GERAL);

                /*" -3178- MOVE FORNECED-BAIRRO TO CITY2-FSCL-GERAL */
                _.Move(FORNECED.DCLFORNECEDORES.FORNECED_BAIRRO, W_REGISTRO_SIAS_GERAL.CITY2_FSCL_GERAL);

                /*" -3178- MOVE FORNECED-BAIRRO TO CITY2-COR-GERAL. */
                _.Move(FORNECED.DCLFORNECEDORES.FORNECED_BAIRRO, W_REGISTRO_SIAS_GERAL.CITY2_COR_GERAL);
            }


        }

        [StopWatch]
        /*" R3100-CONTINUA-MONTAGEM */
        private void R3100_CONTINUA_MONTAGEM(bool isPerform = false)
        {
            /*" -3188- MOVE 'BR4' TO TAXTYPE-INSCRM-GERAL. */
            _.Move("BR4", W_REGISTRO_SIAS_GERAL.TAXTYPE_INSCRM_GERAL);

            /*" -3190- MOVE 'BR3' TO TAXTYPE-INSCRE-GERAL. */
            _.Move("BR3", W_REGISTRO_SIAS_GERAL.TAXTYPE_INSCRE_GERAL);

            /*" -3192- MOVE 'BR' TO COUNTRY-FSCL-GERAL COUNTRY-COR-GERAL. */
            _.Move("BR", W_REGISTRO_SIAS_GERAL.COUNTRY_FSCL_GERAL, W_REGISTRO_SIAS_GERAL.COUNTRY_COR_GERAL);

            /*" -3193- IF NATPERS-GERAL EQUAL 'X' */

            if (W_REGISTRO_SIAS_GERAL.NATPERS_GERAL == "X")
            {

                /*" -3195- MOVE 'PT' TO LANGUCORR-GERAL . */
                _.Move("PT", W_REGISTRO_SIAS_GERAL.LANGUCORR_GERAL);
            }


            /*" -3197- IF TITLE-MEDI-GERAL EQUAL '0003' AND NATPERS-GERAL EQUAL ' ' */

            if (W_REGISTRO_SIAS_GERAL.TITLE_MEDI_GERAL == "0003" && W_REGISTRO_SIAS_GERAL.NATPERS_GERAL == " ")
            {

                /*" -3201- MOVE 'P' TO LANGU-GERAL . */
                _.Move("P", W_REGISTRO_SIAS_GERAL.LANGU_GERAL);
            }


            /*" -3203- MOVE 'BR' TO BANKS-GERAL */
            _.Move("BR", W_REGISTRO_SIAS_GERAL.BANKS_GERAL);

            /*" -3205- INITIALIZE REG-LK-BANCOS. */
            _.Initialize(
                REG_LK_BANCOS
            );

            /*" -3207- MOVE LK-SAP-COD-BANCO TO LK-BANCO-COD-BANCO . */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_COD_BANCO, REG_LK_BANCOS.LK_BANCO_COD_BANCO);

            /*" -3212- CALL 'GE0080B' USING REG-LK-BANCOS. */
            _.Call("GE0080B", REG_LK_BANCOS);

            /*" -3214- IF LK-BANCO-COD-RETORNO NOT EQUAL ' ' */

            if (REG_LK_BANCOS.LK_BANCO_COD_RETORNO != " ")
            {

                /*" -3216- MOVE 0 TO LK-BANCO-DV-BANCO. */
                _.Move(0, REG_LK_BANCOS.LK_BANCO_DV_BANCO);
            }


            /*" -3217- MOVE LK-SAP-COD-BANCO TO W-COD-BANCO */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_COD_BANCO, AREA_DE_WORK.W_LOTE.W_BANKK.W_COD_BANCO);

            /*" -3218- MOVE LK-BANCO-DV-BANCO TO W-DV-BANCO. */
            _.Move(REG_LK_BANCOS.LK_BANCO_DV_BANCO, AREA_DE_WORK.W_LOTE.W_BANKK.W_DV_BANCO);

            /*" -3220- MOVE LK-SAP-COD-AGENCIA TO W-COD-AGENCIA. */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_COD_AGENCIA, AREA_DE_WORK.W_LOTE.W_BANKK.W_COD_AGENCIA);

            /*" -3224- MOVE W-BANKK TO BANKK-GERAL. */
            _.Move(AREA_DE_WORK.W_LOTE.W_BANKK, W_REGISTRO_SIAS_GERAL.BANKK_GERAL);

            /*" -3225- IF LK-SAP-COD-BANCO EQUAL 341 */

            if (REGISTRO_LINKAGE_SAP.LK_SAP_COD_BANCO == 341)
            {

                /*" -3226- MOVE SPACES TO BKONT-GERAL */
                _.Move("", W_REGISTRO_SIAS_GERAL.BKONT_GERAL);

                /*" -3227- ELSE */
            }
            else
            {


                /*" -3237- MOVE LK-SAP-DV-AGENCIA TO BKONT-GERAL. */
                _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_DV_AGENCIA, W_REGISTRO_SIAS_GERAL.BKONT_GERAL);
            }


            /*" -3238- MOVE LK-SAP-NUM-CONTA TO W-NUM-CONTA-SAP. */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_NUM_CONTA, AREA_DE_WORK.W_LOTE.W_CONTA_SAP.W_NUM_CONTA_SAP);

            /*" -3239- MOVE LK-SAP-DV-CONTA TO W-DV-CONTA-SAP. */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_DV_CONTA, AREA_DE_WORK.W_LOTE.W_CONTA_SAP.W_DV_CONTA_SAP);

            /*" -3241- MOVE W-CONTA-SAP TO BANKN-GERAL. */
            _.Move(AREA_DE_WORK.W_LOTE.W_CONTA_SAP, W_REGISTRO_SIAS_GERAL.BANKN_GERAL);

            /*" -3243- IF LK-SAP-COD-CONVENIO EQUAL 921286 AND LK-SAP-COD-BANCO EQUAL 104 */

            if (REGISTRO_LINKAGE_SAP.LK_SAP_COD_CONVENIO == 921286 && REGISTRO_LINKAGE_SAP.LK_SAP_COD_BANCO == 104)
            {

                /*" -3244- MOVE BANKN-GERAL(2:3) TO LK-SAP-OPERACAO-CONTA */
                _.Move(W_REGISTRO_SIAS_GERAL.BANKN_GERAL.Substring(2, 3), REGISTRO_LINKAGE_SAP.LK_SAP_OPERACAO_CONTA);

                /*" -3245- MOVE '0' TO BANKN-GERAL(1:1) */
                _.MoveAtPosition("0", W_REGISTRO_SIAS_GERAL.BANKN_GERAL, 1, 1);

                /*" -3246- MOVE '0' TO BANKN-GERAL(2:1) */
                _.MoveAtPosition("0", W_REGISTRO_SIAS_GERAL.BANKN_GERAL, 2, 1);

                /*" -3247- MOVE '0' TO BANKN-GERAL(3:1) */
                _.MoveAtPosition("0", W_REGISTRO_SIAS_GERAL.BANKN_GERAL, 3, 1);

                /*" -3251- MOVE '0' TO BANKN-GERAL(4:1). */
                _.MoveAtPosition("0", W_REGISTRO_SIAS_GERAL.BANKN_GERAL, 4, 1);
            }


            /*" -3252- IF LK-SAP-COD-BANCO NOT EQUAL 104 */

            if (REGISTRO_LINKAGE_SAP.LK_SAP_COD_BANCO != 104)
            {

                /*" -3253- MOVE '01' TO BKREF-GERAL */
                _.Move("01", W_REGISTRO_SIAS_GERAL.BKREF_GERAL);

                /*" -3254- ELSE */
            }
            else
            {


                /*" -3255- IF LK-SAP-COD-BANCO EQUAL 104 */

                if (REGISTRO_LINKAGE_SAP.LK_SAP_COD_BANCO == 104)
                {

                    /*" -3256- IF LK-SAP-OPERACAO-CONTA EQUAL 1 */

                    if (REGISTRO_LINKAGE_SAP.LK_SAP_OPERACAO_CONTA == 1)
                    {

                        /*" -3257- MOVE '001' TO BKREF-GERAL */
                        _.Move("001", W_REGISTRO_SIAS_GERAL.BKREF_GERAL);

                        /*" -3258- ELSE */
                    }
                    else
                    {


                        /*" -3259- IF LK-SAP-OPERACAO-CONTA EQUAL 2 */

                        if (REGISTRO_LINKAGE_SAP.LK_SAP_OPERACAO_CONTA == 2)
                        {

                            /*" -3260- MOVE '002' TO BKREF-GERAL */
                            _.Move("002", W_REGISTRO_SIAS_GERAL.BKREF_GERAL);

                            /*" -3261- ELSE */
                        }
                        else
                        {


                            /*" -3262- IF LK-SAP-OPERACAO-CONTA EQUAL 3 */

                            if (REGISTRO_LINKAGE_SAP.LK_SAP_OPERACAO_CONTA == 3)
                            {

                                /*" -3263- MOVE '003' TO BKREF-GERAL */
                                _.Move("003", W_REGISTRO_SIAS_GERAL.BKREF_GERAL);

                                /*" -3264- ELSE */
                            }
                            else
                            {


                                /*" -3265- IF LK-SAP-OPERACAO-CONTA EQUAL 6 */

                                if (REGISTRO_LINKAGE_SAP.LK_SAP_OPERACAO_CONTA == 6)
                                {

                                    /*" -3266- MOVE '006' TO BKREF-GERAL */
                                    _.Move("006", W_REGISTRO_SIAS_GERAL.BKREF_GERAL);

                                    /*" -3267- ELSE */
                                }
                                else
                                {


                                    /*" -3268- IF LK-SAP-OPERACAO-CONTA EQUAL 7 */

                                    if (REGISTRO_LINKAGE_SAP.LK_SAP_OPERACAO_CONTA == 7)
                                    {

                                        /*" -3269- MOVE '007' TO BKREF-GERAL */
                                        _.Move("007", W_REGISTRO_SIAS_GERAL.BKREF_GERAL);

                                        /*" -3270- ELSE */
                                    }
                                    else
                                    {


                                        /*" -3271- IF LK-SAP-OPERACAO-CONTA EQUAL 13 */

                                        if (REGISTRO_LINKAGE_SAP.LK_SAP_OPERACAO_CONTA == 13)
                                        {

                                            /*" -3272- MOVE '013' TO BKREF-GERAL */
                                            _.Move("013", W_REGISTRO_SIAS_GERAL.BKREF_GERAL);

                                            /*" -3273- ELSE */
                                        }
                                        else
                                        {


                                            /*" -3274- IF LK-SAP-OPERACAO-CONTA EQUAL 22 */

                                            if (REGISTRO_LINKAGE_SAP.LK_SAP_OPERACAO_CONTA == 22)
                                            {

                                                /*" -3275- MOVE '022' TO BKREF-GERAL */
                                                _.Move("022", W_REGISTRO_SIAS_GERAL.BKREF_GERAL);

                                                /*" -3276- ELSE */
                                            }
                                            else
                                            {


                                                /*" -3277- IF LK-SAP-OPERACAO-CONTA EQUAL 23 */

                                                if (REGISTRO_LINKAGE_SAP.LK_SAP_OPERACAO_CONTA == 23)
                                                {

                                                    /*" -3278- MOVE '023' TO BKREF-GERAL */
                                                    _.Move("023", W_REGISTRO_SIAS_GERAL.BKREF_GERAL);

                                                    /*" -3280- ELSE */
                                                }
                                                else
                                                {


                                                    /*" -3282- MOVE '000' TO BKREF-GERAL. */
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


            /*" -3284- IF LK-SAP-COD-BANCO EQUAL 104 AND W-CHAVE-MONTA-SIACC-ESPECIAL EQUAL 'SIM' */

            if (REGISTRO_LINKAGE_SAP.LK_SAP_COD_BANCO == 104 && AREA_DE_WORK.W_CHAVE_MONTA_SIACC_ESPECIAL == "SIM")
            {

                /*" -3285- MOVE '003' TO BKREF-GERAL */
                _.Move("003", W_REGISTRO_SIAS_GERAL.BKREF_GERAL);

                /*" -3289- MOVE 'O' TO BANKN-GERAL. */
                _.Move("O", W_REGISTRO_SIAS_GERAL.BANKN_GERAL);
            }


            /*" -3293- MOVE ' ' TO KOINH-GERAL */
            _.Move(" ", W_REGISTRO_SIAS_GERAL.KOINH_GERAL);

            /*" -3295- MOVE 'X' TO XEZER-GERAL. */
            _.Move("X", W_REGISTRO_SIAS_GERAL.XEZER_GERAL);

            /*" -3296- MOVE 'ZCBO' TO ZCBO-TYPE-GERAL. */
            _.Move("ZCBO", W_REGISTRO_SIAS_GERAL.ZCBO_TYPE_GERAL);

            /*" -3310- MOVE SPACES TO ZCBO-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.ZCBO_GERAL);

            /*" -3311- IF W-LOTE-SIGLA-MODULO EQUAL 'CA' */

            if (AREA_DE_WORK.W_LOTE.W_LOTE_SIGLA_MODULO == "CA")
            {

                /*" -3312- MOVE ' ' TO ZWELS-GERAL */
                _.Move(" ", W_REGISTRO_SIAS_GERAL.ZWELS_GERAL);

                /*" -3314- ELSE */
            }
            else
            {


                /*" -3315- IF MOVDEBCE-COD-CONVENIO EQUAL 921286 */

                if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO == 921286)
                {

                    /*" -3316- MOVE 'UWXBZT' TO ZWELS-GERAL */
                    _.Move("UWXBZT", W_REGISTRO_SIAS_GERAL.ZWELS_GERAL);

                    /*" -3317- ELSE */
                }
                else
                {


                    /*" -3341- MOVE 'ISFECOTJG' TO ZWELS-GERAL. */
                    _.Move("ISFECOTJG", W_REGISTRO_SIAS_GERAL.ZWELS_GERAL);
                }

            }


            /*" -3342- IF (MOVDEBCE-COD-CONVENIO EQUAL 43350) */

            if ((MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO == 43350))
            {

                /*" -3343- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'IND' */

                if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "IND")
                {

                    /*" -3344- MOVE 'G' TO FPAG-GERAL */
                    _.Move("G", W_REGISTRO_SIAS_GERAL.FPAG_GERAL);

                    /*" -3345- ELSE */
                }
                else
                {


                    /*" -3346- MOVE 'O' TO FPAG-GERAL */
                    _.Move("O", W_REGISTRO_SIAS_GERAL.FPAG_GERAL);

                    /*" -3347- END-IF */
                }


                /*" -3348- ELSE */
            }
            else
            {


                /*" -3349- IF (MOVDEBCE-COD-CONVENIO EQUAL 921286) */

                if ((MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO == 921286))
                {

                    /*" -3350- MOVE '0' TO FPAG-GERAL */
                    _.Move("0", W_REGISTRO_SIAS_GERAL.FPAG_GERAL);

                    /*" -3351- ELSE */
                }
                else
                {


                    /*" -3354- IF (MOVDEBCE-COD-CONVENIO EQUAL 600119) OR (MOVDEBCE-COD-CONVENIO EQUAL 600120) OR (MOVDEBCE-COD-CONVENIO EQUAL 600123) */

                    if ((MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO == 600119) || (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO == 600120) || (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO == 600123))
                    {

                        /*" -3355- MOVE 'I' TO FPAG-GERAL */
                        _.Move("I", W_REGISTRO_SIAS_GERAL.FPAG_GERAL);

                        /*" -3356- ELSE */
                    }
                    else
                    {


                        /*" -3357- IF (MOVDEBCE-COD-CONVENIO EQUAL 600128) */

                        if ((MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO == 600128))
                        {

                            /*" -3358- MOVE 'S' TO FPAG-GERAL */
                            _.Move("S", W_REGISTRO_SIAS_GERAL.FPAG_GERAL);

                            /*" -3359- ELSE */
                        }
                        else
                        {


                            /*" -3362- MOVE '?' TO FPAG-GERAL. */
                            _.Move("?", W_REGISTRO_SIAS_GERAL.FPAG_GERAL);
                        }

                    }

                }

            }


            /*" -3363- IF CODOPE-GERAL EQUAL 'SIAS_09504' OR 'SIAS_09515' */

            if (W_REGISTRO_SIAS_GERAL.CODOPE_GERAL.In("SIAS_09504".ToString(), "SIAS_09515".ToString()))
            {

                /*" -3364- MOVE 'D' TO FREC-GERAL */
                _.Move("D", W_REGISTRO_SIAS_GERAL.FREC_GERAL);

                /*" -3365- ELSE */
            }
            else
            {


                /*" -3371- MOVE ' ' TO FREC-GERAL. */
                _.Move(" ", W_REGISTRO_SIAS_GERAL.FREC_GERAL);
            }


            /*" -3372- IF FORNECED-OPT-SIMPLES-FED EQUAL 'S' */

            if (FORNECED.DCLFORNECEDORES.FORNECED_OPT_SIMPLES_FED == "S")
            {

                /*" -3377- MOVE 'X' TO OP-SIMPL-FED-GERAL. */
                _.Move("X", W_REGISTRO_SIAS_GERAL.OP_SIMPL_FED_GERAL);
            }


            /*" -3378- MOVE '0000000000' TO TEL-NUMBER-GERAL. */
            _.Move("0000000000", W_REGISTRO_SIAS_GERAL.TEL_NUMBER_GERAL);

            /*" -3379- MOVE '0000000000' TO FAX-NUMBER-GERAL. */
            _.Move("0000000000", W_REGISTRO_SIAS_GERAL.FAX_NUMBER_GERAL);

            /*" -3379- MOVE 'IBS001' TO ZNIT-TYPE-GERAL. */
            _.Move("IBS001", W_REGISTRO_SIAS_GERAL.ZNIT_TYPE_GERAL);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_EXIT*/

        [StopWatch]
        /*" R3200-MONTA-PRESTADOR */
        private void R3200_MONTA_PRESTADOR(bool isPerform = false)
        {
            /*" -3386- IF W-CHAVE-ORIGEM-CADASTRO EQUAL 'ODS' */

            if (AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO == "ODS")
            {

                /*" -3387- IF OD001-IND-PESSOA EQUAL 'F' */

                if (OD001.DCLOD_PESSOA.OD001_IND_PESSOA == "F")
                {

                    /*" -3388- IF NULL-PF-INSC-PREFEITURA >= 0 */

                    if (NULL_PF_INSC_PREFEITURA >= 0)
                    {

                        /*" -3389- MOVE W-PF-INSC-PREFEITURA TO TAXNUM-INSCRM-GERAL */
                        _.Move(W_PF_INSC_PREFEITURA, W_REGISTRO_SIAS_GERAL.TAXNUM_INSCRM_GERAL);

                        /*" -3390- END-IF */
                    }


                    /*" -3391- IF NULL-PF-INSC-ESTADUAL >= 0 */

                    if (NULL_PF_INSC_ESTADUAL >= 0)
                    {

                        /*" -3392- MOVE W-PF-INSC-ESTADUAL TO TAXNUM-INSCRE-GERAL */
                        _.Move(W_PF_INSC_ESTADUAL, W_REGISTRO_SIAS_GERAL.TAXNUM_INSCRE_GERAL);

                        /*" -3393- END-IF */
                    }


                    /*" -3394- ELSE */
                }
                else
                {


                    /*" -3395- IF OD001-IND-PESSOA EQUAL 'J' */

                    if (OD001.DCLOD_PESSOA.OD001_IND_PESSOA == "J")
                    {

                        /*" -3396- IF NULL-PJ-INSC-PREFEITURA >= 0 */

                        if (NULL_PJ_INSC_PREFEITURA >= 0)
                        {

                            /*" -3397- MOVE W-PJ-INSC-PREFEITURA TO TAXNUM-INSCRM-GERAL */
                            _.Move(W_PJ_INSC_PREFEITURA, W_REGISTRO_SIAS_GERAL.TAXNUM_INSCRM_GERAL);

                            /*" -3398- END-IF */
                        }


                        /*" -3399- IF NULL-PJ-INSC-ESTADUAL >= 0 */

                        if (NULL_PJ_INSC_ESTADUAL >= 0)
                        {

                            /*" -3400- MOVE W-PJ-INSC-ESTADUAL TO TAXNUM-INSCRE-GERAL */
                            _.Move(W_PJ_INSC_ESTADUAL, W_REGISTRO_SIAS_GERAL.TAXNUM_INSCRE_GERAL);

                            /*" -3401- END-IF */
                        }


                        /*" -3402- ELSE */
                    }
                    else
                    {


                        /*" -3403- MOVE ALL '?21' TO TAXNUM-INSCRM-GERAL */
                        _.MoveAll("?21", W_REGISTRO_SIAS_GERAL.TAXNUM_INSCRM_GERAL);

                        /*" -3405- MOVE ALL '?22' TO TAXNUM-INSCRE-GERAL. */
                        _.MoveAll("?22", W_REGISTRO_SIAS_GERAL.TAXNUM_INSCRE_GERAL);
                    }

                }

            }


            /*" -3406- IF W-CHAVE-ORIGEM-CADASTRO EQUAL 'ODS' */

            if (AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO == "ODS")
            {

                /*" -3408- IF TAXNUM-INSCRM-GERAL EQUAL ' ' OR TAXNUM-INSCRE-GERAL EQUAL ' ' */

                if (W_REGISTRO_SIAS_GERAL.TAXNUM_INSCRM_GERAL == " " || W_REGISTRO_SIAS_GERAL.TAXNUM_INSCRE_GERAL == " ")
                {

                    /*" -3409- PERFORM R3210-LE-FORNECEDOR THRU R3210-EXIT */

                    R3210_LE_FORNECEDOR(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R3210_EXIT*/


                    /*" -3411- MOVE FORNECED-INSC-PREFEITURA TO TAXNUM-INSCRM-GERAL */
                    _.Move(FORNECED.DCLFORNECEDORES.FORNECED_INSC_PREFEITURA, W_REGISTRO_SIAS_GERAL.TAXNUM_INSCRM_GERAL);

                    /*" -3413- MOVE FORNECED-INSC-ESTADUAL TO TAXNUM-INSCRE-GERAL */
                    _.Move(FORNECED.DCLFORNECEDORES.FORNECED_INSC_ESTADUAL, W_REGISTRO_SIAS_GERAL.TAXNUM_INSCRE_GERAL);

                    /*" -3414- IF TAXNUM-INSCRM-GERAL EQUAL 0 */

                    if (W_REGISTRO_SIAS_GERAL.TAXNUM_INSCRM_GERAL == 0)
                    {

                        /*" -3415- MOVE ALL '?34' TO TAXNUM-INSCRM-GERAL */
                        _.MoveAll("?34", W_REGISTRO_SIAS_GERAL.TAXNUM_INSCRM_GERAL);

                        /*" -3416- END-IF */
                    }


                    /*" -3417- IF TAXNUM-INSCRE-GERAL EQUAL 0 */

                    if (W_REGISTRO_SIAS_GERAL.TAXNUM_INSCRE_GERAL == 0)
                    {

                        /*" -3418- MOVE ALL '?35' TO TAXNUM-INSCRE-GERAL */
                        _.MoveAll("?35", W_REGISTRO_SIAS_GERAL.TAXNUM_INSCRE_GERAL);

                        /*" -3420- END-IF. */
                    }

                }

            }


            /*" -3421- IF W-CHAVE-ORIGEM-CADASTRO EQUAL 'FORNECEDOR OU LOTERICO' */

            if (AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO == "FORNECEDOR OU LOTERICO")
            {

                /*" -3422- MOVE FORNECED-INSC-PREFEITURA TO TAXNUM-INSCRM-GERAL */
                _.Move(FORNECED.DCLFORNECEDORES.FORNECED_INSC_PREFEITURA, W_REGISTRO_SIAS_GERAL.TAXNUM_INSCRM_GERAL);

                /*" -3424- MOVE FORNECED-INSC-ESTADUAL TO TAXNUM-INSCRE-GERAL. */
                _.Move(FORNECED.DCLFORNECEDORES.FORNECED_INSC_ESTADUAL, W_REGISTRO_SIAS_GERAL.TAXNUM_INSCRE_GERAL);
            }


            /*" -3425- IF W-CHAVE-ORIGEM-CADASTRO EQUAL 'SEM CADASTRO' */

            if (AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO == "SEM CADASTRO")
            {

                /*" -3426- MOVE SPACES TO TAXNUM-INSCRM-GERAL */
                _.Move("", W_REGISTRO_SIAS_GERAL.TAXNUM_INSCRM_GERAL);

                /*" -3426- MOVE SPACES TO TAXNUM-INSCRE-GERAL. */
                _.Move("", W_REGISTRO_SIAS_GERAL.TAXNUM_INSCRE_GERAL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_EXIT*/

        [StopWatch]
        /*" R3210-LE-FORNECEDOR */
        private void R3210_LE_FORNECEDOR(bool isPerform = false)
        {
            /*" -3444- PERFORM R3210_LE_FORNECEDOR_DB_SELECT_1 */

            R3210_LE_FORNECEDOR_DB_SELECT_1();

            /*" -3447- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -3448- DISPLAY 'SISAP15B - ERRO ACESSO FORNECEDORES (2)' */
                _.Display($"SISAP15B - ERRO ACESSO FORNECEDORES (2)");

                /*" -3448- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3210-LE-FORNECEDOR-DB-SELECT-1 */
        public void R3210_LE_FORNECEDOR_DB_SELECT_1()
        {
            /*" -3444- EXEC SQL SELECT F.INSC_PREFEITURA AS 'INSCRICAO MUNICIPAL' , F.INSC_ESTADUAL AS 'INSCRICAO ESTADUAL' , F.OPT_SIMPLES_FED AS 'OPTANTE SIMPLES FERERAL' , F.OPT_SIMPLES_MUN AS 'OPTANTE SIMPLES MUNICIPAL' INTO :FORNECED-INSC-PREFEITURA, :FORNECED-INSC-ESTADUAL, :FORNECED-OPT-SIMPLES-FED, :FORNECED-OPT-SIMPLES-MUN FROM SEGUROS.FORNECEDORES F WHERE COD_FORNECEDOR = :SINISHIS-COD-PREST-SERVICO END-EXEC. */

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
            /*" -3455- MOVE LK-SAP-DES-BAIRRO TO CITY2-FSCL-GERAL */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_DES_BAIRRO, W_REGISTRO_SIAS_GERAL.CITY2_FSCL_GERAL);

            /*" -3456- MOVE LK-SAP-DES-BAIRRO TO CITY2-COR-GERAL */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_DES_BAIRRO, W_REGISTRO_SIAS_GERAL.CITY2_COR_GERAL);

            /*" -3457- MOVE LK-SAP-DES-CIDADE TO CITY1-FSCL-GERAL */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_DES_CIDADE, W_REGISTRO_SIAS_GERAL.CITY1_FSCL_GERAL);

            /*" -3458- MOVE LK-SAP-DES-CIDADE TO CITY1-COR-GERAL */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_DES_CIDADE, W_REGISTRO_SIAS_GERAL.CITY1_COR_GERAL);

            /*" -3459- MOVE LK-SAP-DES-SIGLA-UF TO REGION-FSCL-GERAL */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_DES_SIGLA_UF, W_REGISTRO_SIAS_GERAL.REGION_FSCL_GERAL);

            /*" -3461- MOVE LK-SAP-DES-SIGLA-UF TO REGION-COR-GERAL */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_DES_SIGLA_UF, W_REGISTRO_SIAS_GERAL.REGION_COR_GERAL);

            /*" -3462- IF LK-SAP-NUM-CEP EQUAL ZEROS */

            if (REGISTRO_LINKAGE_SAP.LK_SAP_NUM_CEP == 00)
            {

                /*" -3464- MOVE 99999 TO LK-SAP-NUM-CEP. */
                _.Move(99999, REGISTRO_LINKAGE_SAP.LK_SAP_NUM_CEP);
            }


            /*" -3467- IF LK-SAP-DES-COMPL-CEP(1:1) EQUAL ' ' OR LK-SAP-DES-COMPL-CEP(2:1) EQUAL ' ' OR LK-SAP-DES-COMPL-CEP(3:1) EQUAL ' ' */

            if (REGISTRO_LINKAGE_SAP.LK_SAP_DES_COMPL_CEP.Substring(1, 1) == " " || REGISTRO_LINKAGE_SAP.LK_SAP_DES_COMPL_CEP.Substring(2, 1) == " " || REGISTRO_LINKAGE_SAP.LK_SAP_DES_COMPL_CEP.Substring(3, 1) == " ")
            {

                /*" -3469- MOVE 000 TO LK-SAP-DES-COMPL-CEP. */
                _.Move(000, REGISTRO_LINKAGE_SAP.LK_SAP_DES_COMPL_CEP);
            }


            /*" -3470- MOVE LK-SAP-NUM-CEP TO W-CEP-ALFA-PARTE1 */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_NUM_CEP, AREA_DE_WORK.W_CEP_ALFA.W_CEP_ALFA_PARTE1);

            /*" -3471- MOVE LK-SAP-DES-COMPL-CEP TO W-CEP-ALFA-PARTE2. */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_DES_COMPL_CEP, AREA_DE_WORK.W_CEP_ALFA.W_CEP_ALFA_PARTE2);

            /*" -3472- MOVE W-CEP-ALFA TO POST-CODE1-FSCL-GERAL. */
            _.Move(AREA_DE_WORK.W_CEP_ALFA, W_REGISTRO_SIAS_GERAL.POST_CODE1_FSCL_GERAL);

            /*" -3474- MOVE W-CEP-ALFA TO POST-CODE1-COR-GERAL . */
            _.Move(AREA_DE_WORK.W_CEP_ALFA, W_REGISTRO_SIAS_GERAL.POST_CODE1_COR_GERAL);

            /*" -3475- MOVE LK-SAP-NUM-LOCAL TO HOUSE-NUM1-FSCL-GERAL */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_NUM_LOCAL, W_REGISTRO_SIAS_GERAL.HOUSE_NUM1_FSCL_GERAL);

            /*" -3477- MOVE LK-SAP-NUM-LOCAL TO HOUSE-NUM1-COR-GERAL */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_NUM_LOCAL, W_REGISTRO_SIAS_GERAL.HOUSE_NUM1_COR_GERAL);

            /*" -3478- MOVE LK-SAP-DES-COMPLEMENTO TO HOUSE-NUM2-FSCL-GERAL */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_DES_COMPLEMENTO, W_REGISTRO_SIAS_GERAL.HOUSE_NUM2_FSCL_GERAL);

            /*" -3479- MOVE LK-SAP-DES-COMPLEMENTO TO HOUSE-NUM2-COR-GERAL */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_DES_COMPLEMENTO, W_REGISTRO_SIAS_GERAL.HOUSE_NUM2_COR_GERAL);

            /*" -3480- MOVE LK-SAP-DES-LOGRADOURO TO STREET-FSCL-GERAL */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_DES_LOGRADOURO, W_REGISTRO_SIAS_GERAL.STREET_FSCL_GERAL);

            /*" -3482- MOVE LK-SAP-DES-LOGRADOURO TO STREET-COR-GERAL */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_DES_LOGRADOURO, W_REGISTRO_SIAS_GERAL.STREET_COR_GERAL);

            /*" -3484- MOVE LK-SAP-FAVORECIDO TO NAME-ORG1-GERAL . */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_FAVORECIDO, W_REGISTRO_SIAS_GERAL.NAME_ORG1_GERAL);

            /*" -3485- IF LK-SAP-COD-PROGRAMA EQUAL 'SI5067B' */

            if (REGISTRO_LINKAGE_SAP.LK_SAP_COD_PROGRAMA == "SI5067B")
            {

                /*" -3486- MOVE ' ' TO NATPERS-GERAL */
                _.Move(" ", W_REGISTRO_SIAS_GERAL.NATPERS_GERAL);

                /*" -3487- MOVE 'Z001' TO TITLE-MEDI-GERAL */
                _.Move("Z001", W_REGISTRO_SIAS_GERAL.TITLE_MEDI_GERAL);

                /*" -3489- GO TO R3300-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3300_EXIT*/ //GOTO
                return;
            }


            /*" -3490- IF LK-SAP-COD-PROGRAMA EQUAL 'FI0096B' OR 'SI5071B' */

            if (REGISTRO_LINKAGE_SAP.LK_SAP_COD_PROGRAMA.In("FI0096B", "SI5071B"))
            {

                /*" -3493- MOVE LK-SAP-MENSAGEM-RETORNO TO W-TIPO-E-CPF-CNPJ */
                _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_MENSAGEM_RETORNO, W_TIPO_E_CPF_CNPJ);

                /*" -3494- IF W-SE-EH-PF-PJ EQUAL 'PF' */

                if (W_TIPO_E_CPF_CNPJ.W_SE_EH_PF_PJ == "PF")
                {

                    /*" -3495- MOVE 'X' TO NATPERS-GERAL */
                    _.Move("X", W_REGISTRO_SIAS_GERAL.NATPERS_GERAL);

                    /*" -3496- MOVE W-CPF-CNPJ-MUTUARIO TO W-NUM-CPF-NUM */
                    _.Move(W_TIPO_E_CPF_CNPJ.W_CPF_CNPJ_MUTUARIO, AREA_DE_WORK.W_NUM_CPF_NUM);

                    /*" -3497- MOVE W-NUM-CPF-ALFA TO TAXNUM-CPF-GERAL */
                    _.Move(AREA_DE_WORK.W_NUM_CPF_ALFA, W_REGISTRO_SIAS_GERAL.TAXNUM_CPF_GERAL);

                    /*" -3498- MOVE 'Z003' TO TITLE-MEDI-GERAL */
                    _.Move("Z003", W_REGISTRO_SIAS_GERAL.TITLE_MEDI_GERAL);

                    /*" -3499- ELSE */
                }
                else
                {


                    /*" -3500- MOVE ' ' TO NATPERS-GERAL */
                    _.Move(" ", W_REGISTRO_SIAS_GERAL.NATPERS_GERAL);

                    /*" -3501- MOVE W-CPF-CNPJ-MUTUARIO TO W-NUM-CNPJ-NUM */
                    _.Move(W_TIPO_E_CPF_CNPJ.W_CPF_CNPJ_MUTUARIO, AREA_DE_WORK.W_NUM_CNPJ_NUM);

                    /*" -3502- MOVE W-NUM-CNPJ-ALFA TO TAXNUM-CNPJ-GERAL */
                    _.Move(AREA_DE_WORK.W_NUM_CNPJ_ALFA, W_REGISTRO_SIAS_GERAL.TAXNUM_CNPJ_GERAL);

                    /*" -3503- MOVE '0003' TO TITLE-MEDI-GERAL */
                    _.Move("0003", W_REGISTRO_SIAS_GERAL.TITLE_MEDI_GERAL);

                    /*" -3504- END-IF */
                }


                /*" -3505- MOVE LK-SAP-FAVORECIDO TO NAME-ORG1-GERAL */
                _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_FAVORECIDO, W_REGISTRO_SIAS_GERAL.NAME_ORG1_GERAL);

                /*" -3506- MOVE LK-SAP-FAVORECIDO TO CT0007S-NOME */
                _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_FAVORECIDO, REG_LK_BANCOS.CT0007SW099.CT0007S_NOME);

                /*" -3507- CALL 'CT0007S' USING CT0007SW099 */
                _.Call("CT0007S", REG_LK_BANCOS.CT0007SW099);

                /*" -3508- IF CT0007S-SOBRENOME EQUAL ' ' */

                if (REG_LK_BANCOS.CT0007SW099.CT0007S_SOBRENOME == " ")
                {

                    /*" -3509- MOVE ALL '?A' TO NAME-LAST-GERAL */
                    _.MoveAll("?A", W_REGISTRO_SIAS_GERAL.NAME_LAST_GERAL);

                    /*" -3510- ELSE */
                }
                else
                {


                    /*" -3511- MOVE CT0007S-NOME1 TO NAME-FIRST-GERAL */
                    _.Move(REG_LK_BANCOS.CT0007SW099.CT0007S_NOME1, W_REGISTRO_SIAS_GERAL.NAME_FIRST_GERAL);

                    /*" -3512- MOVE CT0007S-SOBRENOME TO NAME-LAST-GERAL */
                    _.Move(REG_LK_BANCOS.CT0007SW099.CT0007S_SOBRENOME, W_REGISTRO_SIAS_GERAL.NAME_LAST_GERAL);

                    /*" -3513- END-IF */
                }


                /*" -3513- GO TO R3300-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3300_EXIT*/ //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3300_EXIT*/

        [StopWatch]
        /*" R3500-MONTA-ATTR-PAGTO-MOD-AP */
        private void R3500_MONTA_ATTR_PAGTO_MOD_AP(bool isPerform = false)
        {
            /*" -3524- MOVE 'ATR_FTEP' TO ATTR01-GERAL. */
            _.Move("ATR_FTEP", W_REGISTRO_SIAS_GERAL.ATTR01_GERAL);

            /*" -3529- MOVE SINISMES-COD-FONTE TO ATTRVAL01-GERAL. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE, W_REGISTRO_SIAS_GERAL.ATTRVAL01_GERAL);

            /*" -3536- MOVE ZEROS TO LKGE-RAMO-EMISSOR LKGE-MODALIDADE LKGE-PRODUTO LKGE-GRUPO-SUSEP LKGE-RAMO-SUSEP LKGE-SQLCODE. */
            _.Move(0, PARAMETROS_GE.LKGE_RAMO_EMISSOR, PARAMETROS_GE.LKGE_MODALIDADE, PARAMETROS_GE.LKGE_PRODUTO, PARAMETROS_GE.LKGE_GRUPO_SUSEP, PARAMETROS_GE.LKGE_RAMO_SUSEP, PARAMETROS_GE.LKGE_SQLCODE);

            /*" -3539- MOVE SPACES TO LKGE-INIVIGENCIA LKGE-MENSAGEM. */
            _.Move("", PARAMETROS_GE.LKGE_INIVIGENCIA, PARAMETROS_GE.LKGE_MENSAGEM);

            /*" -3541- MOVE SINISMES-RAMO TO LKGE-RAMO-EMISSOR. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO, PARAMETROS_GE.LKGE_RAMO_EMISSOR);

            /*" -3542- IF SINISMES-RAMO EQUAL 48 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO == 48)
            {

                /*" -3544- MOVE SINISMES-COD-PRODUTO TO LKGE-PRODUTO. */
                _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO, PARAMETROS_GE.LKGE_PRODUTO);
            }


            /*" -3556- MOVE HOST-SI-DATA-MOV-ABERTO TO LKGE-INIVIGENCIA. */
            _.Move(HOST_SI_DATA_MOV_ABERTO, PARAMETROS_GE.LKGE_INIVIGENCIA);

            /*" -3558- CALL 'GE0005S' USING PARAMETROS-GE. */
            _.Call("GE0005S", PARAMETROS_GE);

            /*" -3559- IF LKGE-MENSAGEM NOT EQUAL SPACES */

            if (!PARAMETROS_GE.LKGE_MENSAGEM.IsEmpty())
            {

                /*" -3560- DISPLAY 'R1250 - ERRO NO CALL DA SUB-ROTINA GE0005S' */
                _.Display($"R1250 - ERRO NO CALL DA SUB-ROTINA GE0005S");

                /*" -3561- DISPLAY 'ERRO ...... ' LKGE-MENSAGEM */
                _.Display($"ERRO ...... {PARAMETROS_GE.LKGE_MENSAGEM}");

                /*" -3562- DISPLAY 'SQLCODE ... ' LKGE-SQLCODE */
                _.Display($"SQLCODE ... {PARAMETROS_GE.LKGE_SQLCODE}");

                /*" -3563- DISPLAY 'RAMO ...... ' LKGE-RAMO-EMISSOR */
                _.Display($"RAMO ...... {PARAMETROS_GE.LKGE_RAMO_EMISSOR}");

                /*" -3564- DISPLAY 'PRODUTO ... ' LKGE-PRODUTO */
                _.Display($"PRODUTO ... {PARAMETROS_GE.LKGE_PRODUTO}");

                /*" -3565- DISPLAY 'VIGENCIA .. ' LKGE-INIVIGENCIA */
                _.Display($"VIGENCIA .. {PARAMETROS_GE.LKGE_INIVIGENCIA}");

                /*" -3566- MOVE LKGE-SQLCODE TO SQLCODE */
                _.Move(PARAMETROS_GE.LKGE_SQLCODE, DB.SQLCODE);

                /*" -3568- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -3569- MOVE 'ATR_RAMO' TO ATTR02-GERAL. */
            _.Move("ATR_RAMO", W_REGISTRO_SIAS_GERAL.ATTR02_GERAL);

            /*" -3571- MOVE LKGE-RAMO-SUSEP TO ATTRVAL02-GERAL. */
            _.Move(PARAMETROS_GE.LKGE_RAMO_SUSEP, W_REGISTRO_SIAS_GERAL.ATTRVAL02_GERAL);

            /*" -3572- MOVE 'ATR_PROD' TO ATTR03-GERAL. */
            _.Move("ATR_PROD", W_REGISTRO_SIAS_GERAL.ATTR03_GERAL);

            /*" -3573- MOVE 'L000' TO W-PRODUTO-SAP-L000. */
            _.Move("L000", AREA_DE_WORK.W_PRODUTO_SAP.W_PRODUTO_SAP_L000);

            /*" -3574- MOVE SINISMES-COD-PRODUTO TO W-PRODUTO-SAP-PRODUTO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO, AREA_DE_WORK.W_PRODUTO_SAP.W_PRODUTO_SAP_PRODUTO);

            /*" -3576- MOVE W-PRODUTO-SAP TO ATTRVAL03-GERAL. */
            _.Move(AREA_DE_WORK.W_PRODUTO_SAP, W_REGISTRO_SIAS_GERAL.ATTRVAL03_GERAL);

            /*" -3577- MOVE 'ATR_APOL' TO ATTR04-GERAL. */
            _.Move("ATR_APOL", W_REGISTRO_SIAS_GERAL.ATTR04_GERAL);

            /*" -3579- MOVE SINISHIS-NUM-APOLICE TO ATTRVAL04-GERAL. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOLICE, W_REGISTRO_SIAS_GERAL.ATTRVAL04_GERAL);

            /*" -3580- MOVE 'ATR_SNTR' TO ATTR05-GERAL. */
            _.Move("ATR_SNTR", W_REGISTRO_SIAS_GERAL.ATTR05_GERAL);

            /*" -3584- MOVE SINISHIS-NUM-APOL-SINISTRO TO ATTRVAL05-GERAL. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, W_REGISTRO_SIAS_GERAL.ATTRVAL05_GERAL);

            /*" -3587- IF CODOPE-GERAL EQUAL 'SIAS_09005' OR 'SIAS_09011' OR 'SIAS_09012' OR 'SIAS_09013' OR 'SIAS_09024' */

            if (W_REGISTRO_SIAS_GERAL.CODOPE_GERAL.In("SIAS_09005".ToString(), "SIAS_09011".ToString(), "SIAS_09012".ToString(), "SIAS_09013".ToString(), "SIAS_09024".ToString()))
            {

                /*" -3588- MOVE SPACES TO ATTR06-GERAL ATTRVAL06-GERAL */
                _.Move("", W_REGISTRO_SIAS_GERAL.ATTR06_GERAL, W_REGISTRO_SIAS_GERAL.ATTRVAL06_GERAL);

                /*" -3589- GO TO R3500-PULA-CBEN */

                R3500_PULA_CBEN(); //GOTO
                return;

                /*" -3590- ELSE */
            }
            else
            {


                /*" -3601- MOVE 'ATR_CBEN' TO ATTR06-GERAL. */
                _.Move("ATR_CBEN", W_REGISTRO_SIAS_GERAL.ATTR06_GERAL);
            }


            /*" -3602- IF W-CHAVE-ORIGEM-CADASTRO EQUAL 'ODS' */

            if (AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO == "ODS")
            {

                /*" -3603- IF NULL-NUM-CNPJ >= 0 */

                if (NULL_NUM_CNPJ >= 0)
                {

                    /*" -3604- MOVE W-NUM-CNPJ-ALFA TO ATTRVAL06-GERAL */
                    _.Move(AREA_DE_WORK.W_NUM_CNPJ_ALFA, W_REGISTRO_SIAS_GERAL.ATTRVAL06_GERAL);

                    /*" -3605- ELSE */
                }
                else
                {


                    /*" -3606- IF NULL-NUM-CPF >= 0 */

                    if (NULL_NUM_CPF >= 0)
                    {

                        /*" -3607- MOVE W-NUM-CPF-ALFA TO ATTRVAL06-GERAL */
                        _.Move(AREA_DE_WORK.W_NUM_CPF_ALFA, W_REGISTRO_SIAS_GERAL.ATTRVAL06_GERAL);

                        /*" -3608- ELSE */
                    }
                    else
                    {


                        /*" -3610- MOVE ALL '7' TO ATTRVAL06-GERAL. */
                        _.MoveAll("7", W_REGISTRO_SIAS_GERAL.ATTRVAL06_GERAL);
                    }

                }

            }


            /*" -3611- IF W-CHAVE-ORIGEM-CADASTRO EQUAL 'FORNECEDOR OU LOTERICO' */

            if (AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO == "FORNECEDOR OU LOTERICO")
            {

                /*" -3612- IF FORNECED-TIPO-PESSOA EQUAL 'F' */

                if (FORNECED.DCLFORNECEDORES.FORNECED_TIPO_PESSOA == "F")
                {

                    /*" -3613- MOVE W-NUM-CPF-ALFA TO ATTRVAL06-GERAL */
                    _.Move(AREA_DE_WORK.W_NUM_CPF_ALFA, W_REGISTRO_SIAS_GERAL.ATTRVAL06_GERAL);

                    /*" -3614- ELSE */
                }
                else
                {


                    /*" -3616- MOVE W-NUM-CNPJ-ALFA TO ATTRVAL06-GERAL. */
                    _.Move(AREA_DE_WORK.W_NUM_CNPJ_ALFA, W_REGISTRO_SIAS_GERAL.ATTRVAL06_GERAL);
                }

            }


            /*" -3617- IF W-CHAVE-ORIGEM-CADASTRO EQUAL 'SEM CADASTRO' */

            if (AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO == "SEM CADASTRO")
            {

                /*" -3617- MOVE ALL 'X' TO ATTRVAL06-GERAL. */
                _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL06_GERAL);
            }


        }

        [StopWatch]
        /*" R3500-PULA-CBEN */
        private void R3500_PULA_CBEN(bool isPerform = false)
        {
            /*" -3624- MOVE SPACES TO ATTR07-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTR07_GERAL);

            /*" -3628- MOVE SPACES TO ATTRVAL07-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTRVAL07_GERAL);

            /*" -3634- IF CODOPE-GERAL EQUAL 'SIAS_09002' OR 'SIAS_09003' OR 'SIAS_09004' OR 'SIAS_09006' OR 'SIAS_09007' OR 'SIAS_09008' OR 'SIAS_09009' OR 'SIAS_09015' OR 'SIAS_09022' OR 'SIAS_09025' */

            if (W_REGISTRO_SIAS_GERAL.CODOPE_GERAL.In("SIAS_09002".ToString(), "SIAS_09003".ToString(), "SIAS_09004".ToString(), "SIAS_09006".ToString(), "SIAS_09007".ToString(), "SIAS_09008".ToString(), "SIAS_09009".ToString(), "SIAS_09015".ToString(), "SIAS_09022".ToString(), "SIAS_09025".ToString()))
            {

                /*" -3635- MOVE 'ATR_PJUD' TO ATTR07-GERAL */
                _.Move("ATR_PJUD", W_REGISTRO_SIAS_GERAL.ATTR07_GERAL);

                /*" -3636- MOVE 0 TO HOST-COUNT */
                _.Move(0, HOST_COUNT);

                /*" -3637- PERFORM R3010-ACESSA-SCPJUD THRU R3010-EXIT */

                R3010_ACESSA_SCPJUD(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3010_EXIT*/


                /*" -3639- IF HOST-COUNT EQUAL 0 */

                if (HOST_COUNT == 0)
                {

                    /*" -3640- MOVE ALL 'X' TO ATTRVAL07-GERAL */
                    _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL07_GERAL);

                    /*" -3641- ELSE */
                }
                else
                {


                    /*" -3646- MOVE SIPROJUD-COD-PROCESSO-JURID TO ATTRVAL07-GERAL . */
                    _.Move(SIPROJUD.DCLSI_PROCESSO_JURID.SIPROJUD_COD_PROCESSO_JURID, W_REGISTRO_SIAS_GERAL.ATTRVAL07_GERAL);
                }

            }


            /*" -3647- MOVE SPACES TO ATTR08-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTR08_GERAL);

            /*" -3649- MOVE SPACES TO ATTRVAL08-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTRVAL08_GERAL);

            /*" -3655- IF CODOPE-GERAL EQUAL 'SIAS_09002' OR 'SIAS_09003' OR 'SIAS_09004' OR 'SIAS_09006' OR 'SIAS_09007' OR 'SIAS_09008' OR 'SIAS_09009' OR 'SIAS_09015' OR 'SIAS_09022' OR 'SIAS_09025' */

            if (W_REGISTRO_SIAS_GERAL.CODOPE_GERAL.In("SIAS_09002".ToString(), "SIAS_09003".ToString(), "SIAS_09004".ToString(), "SIAS_09006".ToString(), "SIAS_09007".ToString(), "SIAS_09008".ToString(), "SIAS_09009".ToString(), "SIAS_09015".ToString(), "SIAS_09022".ToString(), "SIAS_09025".ToString()))
            {

                /*" -3656- MOVE 'ATR_RJUD' TO ATTR08-GERAL */
                _.Move("ATR_RJUD", W_REGISTRO_SIAS_GERAL.ATTR08_GERAL);

                /*" -3660- MOVE ALL 'X' TO ATTRVAL08-GERAL. */
                _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL08_GERAL);
            }


            /*" -3662- IF CODOPE-GERAL EQUAL 'SIAS_09001' OR 'SIAS_09010' OR 'SIAS_09014' OR 'SIAS_09023' */

            if (W_REGISTRO_SIAS_GERAL.CODOPE_GERAL.In("SIAS_09001".ToString(), "SIAS_09010".ToString(), "SIAS_09014".ToString(), "SIAS_09023".ToString()))
            {

                /*" -3663- MOVE 'ATR_DTAV' TO ATTR09-GERAL */
                _.Move("ATR_DTAV", W_REGISTRO_SIAS_GERAL.ATTR09_GERAL);

                /*" -3664- MOVE W-DATA-AVISO-SIAS(1:4) TO W-DATA-AAAAMMDD-AAAA */
                _.Move(W_DATA_AVISO_SIAS.Substring(1, 4), AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_AAAA);

                /*" -3665- MOVE W-DATA-AVISO-SIAS(6:2) TO W-DATA-AAAAMMDD-MM */
                _.Move(W_DATA_AVISO_SIAS.Substring(6, 2), AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_MM);

                /*" -3666- MOVE W-DATA-AVISO-SIAS(9:2) TO W-DATA-AAAAMMDD-DD */
                _.Move(W_DATA_AVISO_SIAS.Substring(9, 2), AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_DD);

                /*" -3667- MOVE W-DATA-AAAAMMDD TO ATTRVAL09-GERAL */
                _.Move(AREA_DE_WORK.W_DATA_AAAAMMDD, W_REGISTRO_SIAS_GERAL.ATTRVAL09_GERAL);

                /*" -3668- ELSE */
            }
            else
            {


                /*" -3670- MOVE SPACES TO ATTR09-GERAL ATTRVAL09-GERAL. */
                _.Move("", W_REGISTRO_SIAS_GERAL.ATTR09_GERAL, W_REGISTRO_SIAS_GERAL.ATTRVAL09_GERAL);
            }


            /*" -3675- IF CODOPE-GERAL EQUAL 'SIAS_09003' OR 'SIAS_09004' OR 'SIAS_09008' OR 'SIAS_09015' OR 'SIAS_09025' */

            if (W_REGISTRO_SIAS_GERAL.CODOPE_GERAL.In("SIAS_09003".ToString(), "SIAS_09004".ToString(), "SIAS_09008".ToString(), "SIAS_09015".ToString(), "SIAS_09025".ToString()))
            {

                /*" -3676- MOVE 'ATR_PCEF' TO ATTR09-GERAL */
                _.Move("ATR_PCEF", W_REGISTRO_SIAS_GERAL.ATTR09_GERAL);

                /*" -3680- MOVE ALL 'X' TO ATTRVAL09-GERAL . */
                _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL09_GERAL);
            }


            /*" -3682- IF CODOPE-GERAL EQUAL 'SIAS_09001' OR 'SIAS_09010' OR 'SIAS_09014' OR 'SIAS_09023' */

            if (W_REGISTRO_SIAS_GERAL.CODOPE_GERAL.In("SIAS_09001".ToString(), "SIAS_09010".ToString(), "SIAS_09014".ToString(), "SIAS_09023".ToString()))
            {

                /*" -3683- MOVE 'ATR_DTCM' TO ATTR10-GERAL */
                _.Move("ATR_DTCM", W_REGISTRO_SIAS_GERAL.ATTR10_GERAL);

                /*" -3684- MOVE SINISMES-DATA-COMUNICADO(1:4) TO W-DATA-AAAAMMDD-AAAA */
                _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_COMUNICADO.Substring(1, 4), AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_AAAA);

                /*" -3685- MOVE SINISMES-DATA-COMUNICADO(6:2) TO W-DATA-AAAAMMDD-MM */
                _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_COMUNICADO.Substring(6, 2), AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_MM);

                /*" -3686- MOVE SINISMES-DATA-COMUNICADO(9:2) TO W-DATA-AAAAMMDD-DD */
                _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_COMUNICADO.Substring(9, 2), AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_DD);

                /*" -3687- MOVE W-DATA-AAAAMMDD TO ATTRVAL10-GERAL */
                _.Move(AREA_DE_WORK.W_DATA_AAAAMMDD, W_REGISTRO_SIAS_GERAL.ATTRVAL10_GERAL);

                /*" -3688- ELSE */
            }
            else
            {


                /*" -3690- MOVE SPACES TO ATTR10-GERAL ATTRVAL10-GERAL. */
                _.Move("", W_REGISTRO_SIAS_GERAL.ATTR10_GERAL, W_REGISTRO_SIAS_GERAL.ATTRVAL10_GERAL);
            }


            /*" -3695- IF CODOPE-GERAL EQUAL 'SIAS_09003' OR 'SIAS_09004' OR 'SIAS_09008' OR 'SIAS_09015' OR 'SIAS_09025' */

            if (W_REGISTRO_SIAS_GERAL.CODOPE_GERAL.In("SIAS_09003".ToString(), "SIAS_09004".ToString(), "SIAS_09008".ToString(), "SIAS_09015".ToString(), "SIAS_09025".ToString()))
            {

                /*" -3696- MOVE 'ATR_AGRU' TO ATTR10-GERAL */
                _.Move("ATR_AGRU", W_REGISTRO_SIAS_GERAL.ATTR10_GERAL);

                /*" -3697- MOVE ALL 'X' TO ATTRVAL10-GERAL */
                _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL10_GERAL);

                /*" -3698- MOVE 'ATTRVAL10-GERAL' TO W-ATTR-DESTINO */
                _.Move("ATTRVAL10-GERAL", AREA_DE_WORK.W_ATTR_DESTINO);

                /*" -3702- PERFORM R2060-MONTA-AGRUPA-PAGTO-SAP THRU R2060-EXIT. */

                R2060_MONTA_AGRUPA_PAGTO_SAP(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2060_EXIT*/

            }


            /*" -3703- MOVE SPACES TO ATTR11-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTR11_GERAL);

            /*" -3705- MOVE SPACES TO ATTRVAL11-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTRVAL11_GERAL);

            /*" -3710- IF CODOPE-GERAL EQUAL 'SIAS_09003' OR 'SIAS_09004' OR 'SIAS_09008' OR 'SIAS_09015' OR 'SIAS_09025' */

            if (W_REGISTRO_SIAS_GERAL.CODOPE_GERAL.In("SIAS_09003".ToString(), "SIAS_09004".ToString(), "SIAS_09008".ToString(), "SIAS_09015".ToString(), "SIAS_09025".ToString()))
            {

                /*" -3711- MOVE 'ATR_DTCA' TO ATTR11-GERAL */
                _.Move("ATR_DTCA", W_REGISTRO_SIAS_GERAL.ATTR11_GERAL);

                /*" -3715- MOVE ALL 'X' TO ATTRVAL11-GERAL. */
                _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL11_GERAL);
            }


            /*" -3716- MOVE SPACES TO ATTR12-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTR12_GERAL);

            /*" -3718- MOVE SPACES TO ATTRVAL12-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTRVAL12_GERAL);

            /*" -3723- IF CODOPE-GERAL EQUAL 'SIAS_09003' OR 'SIAS_09004' OR 'SIAS_09008' OR 'SIAS_09015' OR 'SIAS_09025' */

            if (W_REGISTRO_SIAS_GERAL.CODOPE_GERAL.In("SIAS_09003".ToString(), "SIAS_09004".ToString(), "SIAS_09008".ToString(), "SIAS_09015".ToString(), "SIAS_09025".ToString()))
            {

                /*" -3724- MOVE 'ATR_DTST' TO ATTR12-GERAL */
                _.Move("ATR_DTST", W_REGISTRO_SIAS_GERAL.ATTR12_GERAL);

                /*" -3726- MOVE ALL 'X' TO ATTRVAL12-GERAL . */
                _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL12_GERAL);
            }


            /*" -3733- IF CODOPE-GERAL EQUAL 'SIAS_09001' OR 'SIAS_09011' OR 'SIAS_09002' OR 'SIAS_09012' OR 'SIAS_09005' OR 'SIAS_09013' OR 'SIAS_09006' OR 'SIAS_09014' OR 'SIAS_09007' OR 'SIAS_09022' OR 'SIAS_09009' OR 'SIAS_09023' OR 'SIAS_09010' OR 'SIAS_09024' */

            if (W_REGISTRO_SIAS_GERAL.CODOPE_GERAL.In("SIAS_09001".ToString(), "SIAS_09011".ToString(), "SIAS_09002".ToString(), "SIAS_09012".ToString(), "SIAS_09005".ToString(), "SIAS_09013".ToString(), "SIAS_09006".ToString(), "SIAS_09014".ToString(), "SIAS_09007".ToString(), "SIAS_09022".ToString(), "SIAS_09009".ToString(), "SIAS_09023".ToString(), "SIAS_09010".ToString(), "SIAS_09024".ToString()))
            {

                /*" -3734- IF MOVDEBCE-COD-CONVENIO EQUAL 43350 */

                if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO == 43350)
                {

                    /*" -3735- MOVE 'ATR_PCEF' TO ATTR12-GERAL */
                    _.Move("ATR_PCEF", W_REGISTRO_SIAS_GERAL.ATTR12_GERAL);

                    /*" -3736- MOVE LK-SAP-COD-DOCUMENTO-SIACC TO ATTRVAL12-GERAL */
                    _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_COD_DOCUMENTO_SIACC, W_REGISTRO_SIAS_GERAL.ATTRVAL12_GERAL);

                    /*" -3737- ELSE */
                }
                else
                {


                    /*" -3738- MOVE 'ATR_PCEF' TO ATTR12-GERAL */
                    _.Move("ATR_PCEF", W_REGISTRO_SIAS_GERAL.ATTR12_GERAL);

                    /*" -3742- MOVE ALL 'X' TO ATTRVAL12-GERAL. */
                    _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL12_GERAL);
                }

            }


            /*" -3743- MOVE SPACES TO ATTR13-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTR13_GERAL);

            /*" -3745- MOVE SPACES TO ATTRVAL13-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTRVAL13_GERAL);

            /*" -3750- IF CODOPE-GERAL EQUAL 'SIAS_09003' OR 'SIAS_09004' OR 'SIAS_09008' OR 'SIAS_09015' OR 'SIAS_09025' */

            if (W_REGISTRO_SIAS_GERAL.CODOPE_GERAL.In("SIAS_09003".ToString(), "SIAS_09004".ToString(), "SIAS_09008".ToString(), "SIAS_09015".ToString(), "SIAS_09025".ToString()))
            {

                /*" -3751- MOVE 'ATR_DTCS' TO ATTR13-GERAL */
                _.Move("ATR_DTCS", W_REGISTRO_SIAS_GERAL.ATTR13_GERAL);

                /*" -3752- MOVE ALL 'X' TO ATTRVAL13-GERAL */
                _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL13_GERAL);

                /*" -3753- ELSE */
            }
            else
            {


                /*" -3754- MOVE 'ATR_AGRU' TO ATTR13-GERAL */
                _.Move("ATR_AGRU", W_REGISTRO_SIAS_GERAL.ATTR13_GERAL);

                /*" -3755- MOVE ALL 'X' TO ATTRVAL13-GERAL */
                _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL13_GERAL);

                /*" -3756- MOVE 'ATTRVAL13-GERAL' TO W-ATTR-DESTINO */
                _.Move("ATTRVAL13-GERAL", AREA_DE_WORK.W_ATTR_DESTINO);

                /*" -3758- PERFORM R2060-MONTA-AGRUPA-PAGTO-SAP THRU R2060-EXIT. */

                R2060_MONTA_AGRUPA_PAGTO_SAP(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2060_EXIT*/

            }


            /*" -3759- IF MOVDEBCE-COD-CONVENIO NOT EQUAL 43350 */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO != 43350)
            {

                /*" -3760- MOVE 'ATR_INF1' TO ATTR14-GERAL */
                _.Move("ATR_INF1", W_REGISTRO_SIAS_GERAL.ATTR14_GERAL);

                /*" -3761- MOVE ALL 'X' TO ATTRVAL14-GERAL */
                _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL14_GERAL);

                /*" -3762- MOVE 'ATR_INF2' TO ATTR15-GERAL */
                _.Move("ATR_INF2", W_REGISTRO_SIAS_GERAL.ATTR15_GERAL);

                /*" -3764- MOVE ALL 'X' TO ATTRVAL15-GERAL . */
                _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL15_GERAL);
            }


            /*" -3765- IF MOVDEBCE-COD-CONVENIO EQUAL 43350 */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO == 43350)
            {

                /*" -3766- MOVE SPACES TO W-USO-EMPRESA-SIACC */
                _.Move("", AREA_DE_WORK.W_LOTE.W_USO_EMPRESA_SIACC);

                /*" -3767- MOVE LK-SAP-USO-EMPRESA-SIACC TO W-USO-EMPRESA-SIACC */
                _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_USO_EMPRESA_SIACC, AREA_DE_WORK.W_LOTE.W_USO_EMPRESA_SIACC);

                /*" -3768- MOVE 'ATR_INF1' TO ATTR14-GERAL */
                _.Move("ATR_INF1", W_REGISTRO_SIAS_GERAL.ATTR14_GERAL);

                /*" -3769- MOVE W-ATTR-14 TO ATTRVAL14-GERAL */
                _.Move(AREA_DE_WORK.W_LOTE.W_USO_EMPRESA_SIACC.W_ATTR_14, W_REGISTRO_SIAS_GERAL.ATTRVAL14_GERAL);

                /*" -3770- MOVE 'ATR_INF2' TO ATTR15-GERAL */
                _.Move("ATR_INF2", W_REGISTRO_SIAS_GERAL.ATTR15_GERAL);

                /*" -3783- MOVE W-ATTR-15 TO ATTRVAL15-GERAL . */
                _.Move(AREA_DE_WORK.W_LOTE.W_USO_EMPRESA_SIACC.W_ATTR_15, W_REGISTRO_SIAS_GERAL.ATTRVAL15_GERAL);
            }


            /*" -3786- MOVE 'ATR_FPAG' TO ATTR16-GERAL . */
            _.Move("ATR_FPAG", W_REGISTRO_SIAS_GERAL.ATTR16_GERAL);

            /*" -3797- IF MOVDEBCE-COD-CONVENIO EQUAL 43350 */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO == 43350)
            {

                /*" -3798- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'IND' */

                if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "IND")
                {

                    /*" -3799- MOVE 'G' TO ATTRVAL16-GERAL */
                    _.Move("G", W_REGISTRO_SIAS_GERAL.ATTRVAL16_GERAL);

                    /*" -3800- ELSE */
                }
                else
                {


                    /*" -3801- MOVE 'O' TO ATTRVAL16-GERAL */
                    _.Move("O", W_REGISTRO_SIAS_GERAL.ATTRVAL16_GERAL);

                    /*" -3802- END-IF */
                }


                /*" -3804- ELSE */
            }
            else
            {


                /*" -3805- IF MOVDEBCE-COD-CONVENIO EQUAL 921286 */

                if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO == 921286)
                {

                    /*" -3806- MOVE '0' TO ATTRVAL16-GERAL */
                    _.Move("0", W_REGISTRO_SIAS_GERAL.ATTRVAL16_GERAL);

                    /*" -3808- ELSE */
                }
                else
                {


                    /*" -3809- IF MOVDEBCE-COD-CONVENIO EQUAL 600119 OR 600120 OR 600123 */

                    if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.In("600119", "600120", "600123"))
                    {

                        /*" -3810- MOVE 'I' TO ATTRVAL16-GERAL */
                        _.Move("I", W_REGISTRO_SIAS_GERAL.ATTRVAL16_GERAL);

                        /*" -3812- ELSE */
                    }
                    else
                    {


                        /*" -3815- IF MOVDEBCE-COD-CONVENIO EQUAL 600128 */

                        if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO == 600128)
                        {

                            /*" -3817- MOVE 'I' TO ATTRVAL16-GERAL */
                            _.Move("I", W_REGISTRO_SIAS_GERAL.ATTRVAL16_GERAL);

                            /*" -3818- ELSE */
                        }
                        else
                        {


                            /*" -3823- MOVE '?' TO ATTRVAL16-GERAL. */
                            _.Move("?", W_REGISTRO_SIAS_GERAL.ATTRVAL16_GERAL);
                        }

                    }

                }

            }


            /*" -3824- MOVE 'ATR_ATRB' TO ATTR17-GERAL. */
            _.Move("ATR_ATRB", W_REGISTRO_SIAS_GERAL.ATTR17_GERAL);

            /*" -3825- MOVE 'SI' TO W-ATTR17-SISTEMA. */
            _.Move("SI", AREA_DE_WORK.W_ATTR17.W_ATTR17_SISTEMA);

            /*" -3826- MOVE SINISHIS-COD-USUARIO TO W-ATTR17-USUARIO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_USUARIO, AREA_DE_WORK.W_ATTR17.W_ATTR17_USUARIO);

            /*" -3828- MOVE W-ATTR17 TO ATTRVAL17-GERAL. */
            _.Move(AREA_DE_WORK.W_ATTR17, W_REGISTRO_SIAS_GERAL.ATTRVAL17_GERAL);

            /*" -3829- MOVE SPACES TO ATTR18-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTR18_GERAL);

            /*" -3833- MOVE SPACES TO ATTRVAL18-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTRVAL18_GERAL);

            /*" -3834- MOVE 'NAO' TO W-CHAVE-ACHOU-NOTA-FISCAL. */
            _.Move("NAO", AREA_DE_WORK.W_CHAVE_ACHOU_NOTA_FISCAL);

            /*" -3835- PERFORM R2030-PEGA-NOTA-FISCAL THRU R2030-EXIT. */

            R2030_PEGA_NOTA_FISCAL(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R2030_EXIT*/


            /*" -3836- IF W-CHAVE-ACHOU-NOTA-FISCAL EQUAL 'SIM' */

            if (AREA_DE_WORK.W_CHAVE_ACHOU_NOTA_FISCAL == "SIM")
            {

                /*" -3837- MOVE 'ATR_NFIS' TO ATTR18-GERAL */
                _.Move("ATR_NFIS", W_REGISTRO_SIAS_GERAL.ATTR18_GERAL);

                /*" -3838- MOVE FIPADOFI-NUM-DOC-FISCAL TO ATTRVAL18-GERAL */
                _.Move(FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_NUM_DOC_FISCAL, W_REGISTRO_SIAS_GERAL.ATTRVAL18_GERAL);

                /*" -3839- ELSE */
            }
            else
            {


                /*" -3840- MOVE 'ATR_NFIS' TO ATTR18-GERAL */
                _.Move("ATR_NFIS", W_REGISTRO_SIAS_GERAL.ATTR18_GERAL);

                /*" -3845- MOVE ALL 'X' TO ATTRVAL18-GERAL. */
                _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL18_GERAL);
            }


            /*" -3848- MOVE 'ATR_DVEN' TO ATTR19-GERAL. */
            _.Move("ATR_DVEN", W_REGISTRO_SIAS_GERAL.ATTR19_GERAL);

            /*" -3850- MOVE MOVDEBCE-DATA-VENCIMENTO(1:4) TO W-DATA-AAAAMMDD-AAAA. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO.Substring(1, 4), AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_AAAA);

            /*" -3852- MOVE MOVDEBCE-DATA-VENCIMENTO(6:2) TO W-DATA-AAAAMMDD-MM. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO.Substring(6, 2), AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_MM);

            /*" -3854- MOVE MOVDEBCE-DATA-VENCIMENTO(9:2) TO W-DATA-AAAAMMDD-DD. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO.Substring(9, 2), AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_DD);

            /*" -3867- MOVE W-DATA-AAAAMMDD TO ATTRVAL19-GERAL. */
            _.Move(AREA_DE_WORK.W_DATA_AAAAMMDD, W_REGISTRO_SIAS_GERAL.ATTRVAL19_GERAL);

            /*" -3868- MOVE 'ATR_CDIJ' TO ATTR20-GERAL */
            _.Move("ATR_CDIJ", W_REGISTRO_SIAS_GERAL.ATTR20_GERAL);

            /*" -3870- MOVE ALL 'X' TO ATTRVAL20-GERAL. */
            _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL20_GERAL);

            /*" -3871- MOVE 'ATR_CDIR' TO ATTR21-GERAL */
            _.Move("ATR_CDIR", W_REGISTRO_SIAS_GERAL.ATTR21_GERAL);

            /*" -3875- MOVE ALL 'X' TO ATTRVAL21-GERAL. */
            _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL21_GERAL);

            /*" -3876- MOVE 'ATR_CDIS' TO ATTR22-GERAL. */
            _.Move("ATR_CDIS", W_REGISTRO_SIAS_GERAL.ATTR22_GERAL);

            /*" -3880- MOVE ALL 'X' TO ATTRVAL22-GERAL. */
            _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL22_GERAL);

            /*" -3881- MOVE 'ATR_CDIN' TO ATTR23-GERAL. */
            _.Move("ATR_CDIN", W_REGISTRO_SIAS_GERAL.ATTR23_GERAL);

            /*" -3885- MOVE ALL 'X' TO ATTRVAL23-GERAL. */
            _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL23_GERAL);

            /*" -3886- MOVE 'ATR_CDPS' TO ATTR24-GERAL. */
            _.Move("ATR_CDPS", W_REGISTRO_SIAS_GERAL.ATTR24_GERAL);

            /*" -3890- MOVE ALL 'X' TO ATTRVAL24-GERAL. */
            _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL24_GERAL);

            /*" -3891- MOVE 'ATR_CDCF' TO ATTR25-GERAL. */
            _.Move("ATR_CDCF", W_REGISTRO_SIAS_GERAL.ATTR25_GERAL);

            /*" -3895- MOVE ALL 'X' TO ATTRVAL25-GERAL. */
            _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL25_GERAL);

            /*" -3896- MOVE 'ATR_CDCS' TO ATTR26-GERAL. */
            _.Move("ATR_CDCS", W_REGISTRO_SIAS_GERAL.ATTR26_GERAL);

            /*" -3901- MOVE ALL 'X' TO ATTRVAL26-GERAL. */
            _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL26_GERAL);

            /*" -3902- MOVE 'ATR_CDIP' TO ATTR27-GERAL. */
            _.Move("ATR_CDIP", W_REGISTRO_SIAS_GERAL.ATTR27_GERAL);

            /*" -3906- MOVE ALL 'X' TO ATTRVAL27-GERAL. */
            _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL27_GERAL);

            /*" -3907- MOVE 'ATR_CDCC' TO ATTR28-GERAL. */
            _.Move("ATR_CDCC", W_REGISTRO_SIAS_GERAL.ATTR28_GERAL);

            /*" -3911- MOVE MOVDEBCE-COD-CONVENIO TO ATTRVAL28-GERAL. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO, W_REGISTRO_SIAS_GERAL.ATTRVAL28_GERAL);

            /*" -3912- MOVE 'ATR_TPCV' TO ATTR29-GERAL. */
            _.Move("ATR_TPCV", W_REGISTRO_SIAS_GERAL.ATTR29_GERAL);

            /*" -3913- IF (MOVDEBCE-COD-CONVENIO EQUAL 43350) */

            if ((MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO == 43350))
            {

                /*" -3914- MOVE 'A' TO ATTRVAL29-GERAL */
                _.Move("A", W_REGISTRO_SIAS_GERAL.ATTRVAL29_GERAL);

                /*" -3915- ELSE */
            }
            else
            {


                /*" -3916- IF (MOVDEBCE-COD-CONVENIO EQUAL 921286) */

                if ((MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO == 921286))
                {

                    /*" -3917- MOVE ALL 'X' TO ATTRVAL29-GERAL */
                    _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL29_GERAL);

                    /*" -3918- ELSE */
                }
                else
                {


                    /*" -3922- MOVE 'B' TO ATTRVAL29-GERAL . */
                    _.Move("B", W_REGISTRO_SIAS_GERAL.ATTRVAL29_GERAL);
                }

            }


            /*" -3926- MOVE 'ATR_COMP' TO ATTR30-GERAL. */
            _.Move("ATR_COMP", W_REGISTRO_SIAS_GERAL.ATTR30_GERAL);

            /*" -3928- MOVE ALL 'X' TO ATTRVAL30-GERAL . */
            _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL30_GERAL);

            /*" -3929- MOVE 'ATR_SERV' TO ATTR31-GERAL. */
            _.Move("ATR_SERV", W_REGISTRO_SIAS_GERAL.ATTR31_GERAL);

            /*" -3931- MOVE ALL 'X' TO ATTRVAL31-GERAL. */
            _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL31_GERAL);

            /*" -3932- MOVE 'NAO' TO W-CHAVE-ACHOU-FORNECEDOR */
            _.Move("NAO", AREA_DE_WORK.W_CHAVE_ACHOU_FORNECEDOR);

            /*" -3933- PERFORM R2040-PEGA-SERVICO THRU R2040-EXIT */

            R2040_PEGA_SERVICO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R2040_EXIT*/


            /*" -3934- IF W-CHAVE-ACHOU-FORNECEDOR EQUAL 'SIM' */

            if (AREA_DE_WORK.W_CHAVE_ACHOU_FORNECEDOR == "SIM")
            {

                /*" -3935- IF FORNECED-COD-SERVICO-ISS EQUAL 20 */

                if (FORNECED.DCLFORNECEDORES.FORNECED_COD_SERVICO_ISS == 20)
                {

                    /*" -3936- MOVE '1709' TO ATTRVAL31-GERAL */
                    _.Move("1709", W_REGISTRO_SIAS_GERAL.ATTRVAL31_GERAL);

                    /*" -3937- ELSE */
                }
                else
                {


                    /*" -3938- IF FORNECED-COD-SERVICO-ISS EQUAL 92 */

                    if (FORNECED.DCLFORNECEDORES.FORNECED_COD_SERVICO_ISS == 92)
                    {

                        /*" -3939- MOVE '0705' TO ATTRVAL31-GERAL */
                        _.Move("0705", W_REGISTRO_SIAS_GERAL.ATTRVAL31_GERAL);

                        /*" -3940- ELSE */
                    }
                    else
                    {


                        /*" -3941- IF FORNECED-COD-SERVICO-ISS EQUAL 93 */

                        if (FORNECED.DCLFORNECEDORES.FORNECED_COD_SERVICO_ISS == 93)
                        {

                            /*" -3942- MOVE '1405' TO ATTRVAL31-GERAL */
                            _.Move("1405", W_REGISTRO_SIAS_GERAL.ATTRVAL31_GERAL);

                            /*" -3943- ELSE */
                        }
                        else
                        {


                            /*" -3945- MOVE '????' TO ATTRVAL31-GERAL . */
                            _.Move("????", W_REGISTRO_SIAS_GERAL.ATTRVAL31_GERAL);
                        }

                    }

                }

            }


            /*" -3946- MOVE SPACES TO ATTR32-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTR32_GERAL);

            /*" -3948- MOVE SPACES TO ATTRVAL32-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTRVAL32_GERAL);

            /*" -3949- IF W-CHAVE-ACHOU-NOTA-FISCAL EQUAL 'SIM' */

            if (AREA_DE_WORK.W_CHAVE_ACHOU_NOTA_FISCAL == "SIM")
            {

                /*" -3950- MOVE 'ATR_SENF' TO ATTR32-GERAL */
                _.Move("ATR_SENF", W_REGISTRO_SIAS_GERAL.ATTR32_GERAL);

                /*" -3951- IF FIPADOFI-SERIE-DOC-FISCAL NOT EQUAL SPACES */

                if (!FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_SERIE_DOC_FISCAL.IsEmpty())
                {

                    /*" -3952- MOVE FIPADOFI-SERIE-DOC-FISCAL(1:5) TO ATTRVAL32-GERAL */
                    _.Move(FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_SERIE_DOC_FISCAL.Substring(1, 5), W_REGISTRO_SIAS_GERAL.ATTRVAL32_GERAL);

                    /*" -3953- ELSE */
                }
                else
                {


                    /*" -3954- MOVE ALL 'X' TO ATTRVAL32-GERAL */
                    _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL32_GERAL);

                    /*" -3955- END-IF */
                }


                /*" -3956- ELSE */
            }
            else
            {


                /*" -3957- MOVE 'ATR_SENF' TO ATTR32-GERAL */
                _.Move("ATR_SENF", W_REGISTRO_SIAS_GERAL.ATTR32_GERAL);

                /*" -3959- MOVE ALL 'X' TO ATTRVAL32-GERAL. */
                _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL32_GERAL);
            }


            /*" -3960- MOVE SPACES TO ATTR33-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTR33_GERAL);

            /*" -3962- MOVE SPACES TO ATTRVAL33-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTRVAL33_GERAL);

            /*" -3963- MOVE 'NAO' TO W-CHAVE-ACHOU-FONTE-IMPOSTO. */
            _.Move("NAO", AREA_DE_WORK.W_CHAVE_ACHOU_FONTE_IMPOSTO);

            /*" -3964- PERFORM R2050-FONTE-RECOLHE-IMPOSTO THRU R2050-EXIT */

            R2050_FONTE_RECOLHE_IMPOSTO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R2050_EXIT*/


            /*" -3965- IF W-CHAVE-ACHOU-FONTE-IMPOSTO EQUAL 'SIM' */

            if (AREA_DE_WORK.W_CHAVE_ACHOU_FONTE_IMPOSTO == "SIM")
            {

                /*" -3966- MOVE 'ATR_FISS' TO ATTR33-GERAL */
                _.Move("ATR_FISS", W_REGISTRO_SIAS_GERAL.ATTR33_GERAL);

                /*" -3967- MOVE CEPFXFIL-FONTE TO ATTRVAL33-GERAL */
                _.Move(CEPFXFIL.DCLCEPFAIXAFILIAL.CEPFXFIL_FONTE, W_REGISTRO_SIAS_GERAL.ATTRVAL33_GERAL);

                /*" -3968- ELSE */
            }
            else
            {


                /*" -3969- MOVE 'ATR_FISS' TO ATTR33-GERAL */
                _.Move("ATR_FISS", W_REGISTRO_SIAS_GERAL.ATTR33_GERAL);

                /*" -3973- MOVE ALL 'X' TO ATTRVAL33-GERAL. */
                _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL33_GERAL);
            }


            /*" -3974- MOVE 'ATR_BPAR' TO ATTR34-GERAL. */
            _.Move("ATR_BPAR", W_REGISTRO_SIAS_GERAL.ATTR34_GERAL);

            /*" -3978- MOVE SPACES TO ATTRVAL34-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTRVAL34_GERAL);

            /*" -3979- MOVE 'ATR_FORN' TO ATTR35-GERAL. */
            _.Move("ATR_FORN", W_REGISTRO_SIAS_GERAL.ATTR35_GERAL);

            /*" -3979- MOVE SPACES TO ATTRVAL35-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTRVAL35_GERAL);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3500_EXIT*/

        [StopWatch]
        /*" R3550-MONTA-CODV-PAGTO-MOD-AP */
        private void R3550_MONTA_CODV_PAGTO_MOD_AP(bool isPerform = false)
        {
            /*" -3990- MOVE SPACES TO COD01-GERAL VALO01-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD01_GERAL, W_REGISTRO_SIAS_GERAL.VALO01_GERAL);

            /*" -3992- MOVE SPACES TO COD02-GERAL VALO02-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD02_GERAL, W_REGISTRO_SIAS_GERAL.VALO02_GERAL);

            /*" -3996- IF CODOPE-GERAL EQUAL 'SIAS_09001' OR 'SIAS_09002' OR 'SIAS_09003' OR 'SIAS_09004' OR 'SIAS_09005' OR 'SIAS_09006' OR 'SIAS_09007' OR 'SIAS_09008' */

            if (W_REGISTRO_SIAS_GERAL.CODOPE_GERAL.In("SIAS_09001".ToString(), "SIAS_09002".ToString(), "SIAS_09003".ToString(), "SIAS_09004".ToString(), "SIAS_09005".ToString(), "SIAS_09006".ToString(), "SIAS_09007".ToString(), "SIAS_09008".ToString()))
            {

                /*" -3997- MOVE 'CV_PGSIN' TO COD01-GERAL */
                _.Move("CV_PGSIN", W_REGISTRO_SIAS_GERAL.COD01_GERAL);

                /*" -3998- MOVE SINISHIS-VAL-OPERACAO TO W-VALOR-GERAL-VALOR */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, AREA_DE_WORK.W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

                /*" -3999- ADD SINISHIS-VAL-OPERACAO TO W-TOTAL-VALORES */
                AREA_DE_WORK.W_TOTAL_VALORES.Value = AREA_DE_WORK.W_TOTAL_VALORES + SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO;

                /*" -4000- MOVE W-VALOR-GERAL-X TO VALO01-GERAL */
                _.Move(AREA_DE_WORK.W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO01_GERAL);

                /*" -4001- ADD SINISHIS-VAL-OPERACAO TO W-AC-TOT-INDENIZACOES */
                AREA_DE_WORK.W_AC_TOT_INDENIZACOES.Value = AREA_DE_WORK.W_AC_TOT_INDENIZACOES + SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO;

                /*" -4003- MOVE SPACES TO COD02-GERAL VALO02-GERAL. */
                _.Move("", W_REGISTRO_SIAS_GERAL.COD02_GERAL, W_REGISTRO_SIAS_GERAL.VALO02_GERAL);
            }


            /*" -4005- IF CODOPE-GERAL EQUAL 'SIAS_09009' OR 'SIAS_09010' OR 'SIAS_09013' OR 'SIAS_09015' */

            if (W_REGISTRO_SIAS_GERAL.CODOPE_GERAL.In("SIAS_09009".ToString(), "SIAS_09010".ToString(), "SIAS_09013".ToString(), "SIAS_09015".ToString()))
            {

                /*" -4007- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'HPAG' OR 'HSPAG' OR 'RSHOP' OR 'JBHON' */

                if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO.In("HPAG", "HSPAG", "RSHOP", "JBHON"))
                {

                    /*" -4008- MOVE 'CV_PGHON' TO COD01-GERAL */
                    _.Move("CV_PGHON", W_REGISTRO_SIAS_GERAL.COD01_GERAL);

                    /*" -4009- MOVE SINISHIS-VAL-OPERACAO TO W-VALOR-GERAL-VALOR */
                    _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, AREA_DE_WORK.W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

                    /*" -4010- MOVE W-VALOR-GERAL-X TO VALO01-GERAL */
                    _.Move(AREA_DE_WORK.W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO01_GERAL);

                    /*" -4011- ADD SINISHIS-VAL-OPERACAO TO W-AC-TOT-HONORARIOS */
                    AREA_DE_WORK.W_AC_TOT_HONORARIOS.Value = AREA_DE_WORK.W_AC_TOT_HONORARIOS + SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO;

                    /*" -4012- ADD SINISHIS-VAL-OPERACAO TO W-TOTAL-VALORES */
                    AREA_DE_WORK.W_TOTAL_VALORES.Value = AREA_DE_WORK.W_TOTAL_VALORES + SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO;

                    /*" -4014- MOVE SPACES TO COD02-GERAL VALO02-GERAL. */
                    _.Move("", W_REGISTRO_SIAS_GERAL.COD02_GERAL, W_REGISTRO_SIAS_GERAL.VALO02_GERAL);
                }

            }


            /*" -4016- IF CODOPE-GERAL EQUAL 'SIAS_09022' OR 'SIAS_09023' OR 'SIAS_09024' OR 'SIAS_09025' */

            if (W_REGISTRO_SIAS_GERAL.CODOPE_GERAL.In("SIAS_09022".ToString(), "SIAS_09023".ToString(), "SIAS_09024".ToString(), "SIAS_09025".ToString()))
            {

                /*" -4018- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'DPAG' OR 'DSPAG' OR 'RSDEP' OR 'JBDES' */

                if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO.In("DPAG", "DSPAG", "RSDEP", "JBDES"))
                {

                    /*" -4019- MOVE 'CV_PGDES' TO COD01-GERAL */
                    _.Move("CV_PGDES", W_REGISTRO_SIAS_GERAL.COD01_GERAL);

                    /*" -4020- MOVE SINISHIS-VAL-OPERACAO TO W-VALOR-GERAL-VALOR */
                    _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, AREA_DE_WORK.W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

                    /*" -4021- MOVE W-VALOR-GERAL-X TO VALO01-GERAL */
                    _.Move(AREA_DE_WORK.W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO01_GERAL);

                    /*" -4022- ADD SINISHIS-VAL-OPERACAO TO W-AC-TOT-HONORARIOS */
                    AREA_DE_WORK.W_AC_TOT_HONORARIOS.Value = AREA_DE_WORK.W_AC_TOT_HONORARIOS + SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO;

                    /*" -4023- ADD SINISHIS-VAL-OPERACAO TO W-TOTAL-VALORES */
                    AREA_DE_WORK.W_TOTAL_VALORES.Value = AREA_DE_WORK.W_TOTAL_VALORES + SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO;

                    /*" -4025- MOVE SPACES TO COD02-GERAL VALO02-GERAL. */
                    _.Move("", W_REGISTRO_SIAS_GERAL.COD02_GERAL, W_REGISTRO_SIAS_GERAL.VALO02_GERAL);
                }

            }


            /*" -4026- IF CODOPE-GERAL EQUAL 'SIAS_09014' */

            if (W_REGISTRO_SIAS_GERAL.CODOPE_GERAL == "SIAS_09014")
            {

                /*" -4027- MOVE 'CV_PGHON' TO COD01-GERAL */
                _.Move("CV_PGHON", W_REGISTRO_SIAS_GERAL.COD01_GERAL);

                /*" -4028- MOVE 'CV_PGDES' TO COD02-GERAL */
                _.Move("CV_PGDES", W_REGISTRO_SIAS_GERAL.COD02_GERAL);

                /*" -4029- MOVE 0 TO W-VALOR-GERAL-VALOR */
                _.Move(0, AREA_DE_WORK.W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

                /*" -4030- MOVE W-VALOR-GERAL-X TO VALO01-GERAL VALO02-GERAL */
                _.Move(AREA_DE_WORK.W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO01_GERAL, W_REGISTRO_SIAS_GERAL.VALO02_GERAL);

                /*" -4032- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'HPAG' OR 'HSPAG' OR 'RSHOP' OR 'JBHON' */

                if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO.In("HPAG", "HSPAG", "RSHOP", "JBHON"))
                {

                    /*" -4033- MOVE SINISHIS-VAL-OPERACAO TO W-VALOR-GERAL-VALOR */
                    _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, AREA_DE_WORK.W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

                    /*" -4034- MOVE W-VALOR-GERAL-X TO VALO01-GERAL */
                    _.Move(AREA_DE_WORK.W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO01_GERAL);

                    /*" -4035- ELSE */
                }
                else
                {


                    /*" -4037- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'DPAG' OR 'DSPAG' OR 'RSDEP' OR 'JBDES' */

                    if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO.In("DPAG", "DSPAG", "RSDEP", "JBDES"))
                    {

                        /*" -4038- MOVE SINISHIS-VAL-OPERACAO TO W-VALOR-GERAL-VALOR */
                        _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, AREA_DE_WORK.W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

                        /*" -4040- MOVE W-VALOR-GERAL-X TO VALO02-GERAL. */
                        _.Move(AREA_DE_WORK.W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO02_GERAL);
                    }

                }

            }


            /*" -4041- IF CODOPE-GERAL EQUAL 'SIAS_09011' */

            if (W_REGISTRO_SIAS_GERAL.CODOPE_GERAL == "SIAS_09011")
            {

                /*" -4042- MOVE SPACES TO COD01-GERAL */
                _.Move("", W_REGISTRO_SIAS_GERAL.COD01_GERAL);

                /*" -4043- MOVE SPACES TO VALO01-GERAL */
                _.Move("", W_REGISTRO_SIAS_GERAL.VALO01_GERAL);

                /*" -4044- MOVE 'CV_PGDES' TO COD02-GERAL */
                _.Move("CV_PGDES", W_REGISTRO_SIAS_GERAL.COD02_GERAL);

                /*" -4045- MOVE 0 TO W-VALOR-GERAL-VALOR */
                _.Move(0, AREA_DE_WORK.W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

                /*" -4046- MOVE W-VALOR-GERAL-X TO VALO02-GERAL */
                _.Move(AREA_DE_WORK.W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO02_GERAL);

                /*" -4048- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'HPAG' OR 'HSPAG' OR 'RSHOP' OR 'JBHON' */

                if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO.In("HPAG", "HSPAG", "RSHOP", "JBHON"))
                {

                    /*" -4049- MOVE SINISHIS-VAL-OPERACAO TO W-VALOR-GERAL-VALOR */
                    _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, AREA_DE_WORK.W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

                    /*" -4050- MOVE W-VALOR-GERAL-X TO VALO01-GERAL */
                    _.Move(AREA_DE_WORK.W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO01_GERAL);

                    /*" -4051- ELSE */
                }
                else
                {


                    /*" -4053- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'DPAG' OR 'DSPAG' OR 'RSDEP' OR 'JBDES' */

                    if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO.In("DPAG", "DSPAG", "RSDEP", "JBDES"))
                    {

                        /*" -4054- MOVE SINISHIS-VAL-OPERACAO TO W-VALOR-GERAL-VALOR */
                        _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, AREA_DE_WORK.W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

                        /*" -4056- MOVE W-VALOR-GERAL-X TO VALO02-GERAL. */
                        _.Move(AREA_DE_WORK.W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO02_GERAL);
                    }

                }

            }


            /*" -4057- IF CODOPE-GERAL EQUAL 'SIAS_09012' */

            if (W_REGISTRO_SIAS_GERAL.CODOPE_GERAL == "SIAS_09012")
            {

                /*" -4058- MOVE 'CV_PGHON' TO COD01-GERAL */
                _.Move("CV_PGHON", W_REGISTRO_SIAS_GERAL.COD01_GERAL);

                /*" -4059- MOVE 0 TO W-VALOR-GERAL-VALOR */
                _.Move(0, AREA_DE_WORK.W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

                /*" -4060- MOVE W-VALOR-GERAL-X TO VALO01-GERAL */
                _.Move(AREA_DE_WORK.W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO01_GERAL);

                /*" -4061- MOVE SPACES TO COD02-GERAL */
                _.Move("", W_REGISTRO_SIAS_GERAL.COD02_GERAL);

                /*" -4062- MOVE SPACES TO VALO02-GERAL */
                _.Move("", W_REGISTRO_SIAS_GERAL.VALO02_GERAL);

                /*" -4064- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'HPAG' OR 'HSPAG' OR 'RSHOP' OR 'JBHON' */

                if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO.In("HPAG", "HSPAG", "RSHOP", "JBHON"))
                {

                    /*" -4065- MOVE SINISHIS-VAL-OPERACAO TO W-VALOR-GERAL-VALOR */
                    _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, AREA_DE_WORK.W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

                    /*" -4066- MOVE W-VALOR-GERAL-X TO VALO01-GERAL */
                    _.Move(AREA_DE_WORK.W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO01_GERAL);

                    /*" -4067- ELSE */
                }
                else
                {


                    /*" -4069- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'DPAG' OR 'DSPAG' OR 'RSDEP' OR 'JBDES' */

                    if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO.In("DPAG", "DSPAG", "RSDEP", "JBDES"))
                    {

                        /*" -4070- MOVE SINISHIS-VAL-OPERACAO TO W-VALOR-GERAL-VALOR */
                        _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, AREA_DE_WORK.W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

                        /*" -4074- MOVE W-VALOR-GERAL-X TO VALO02-GERAL. */
                        _.Move(AREA_DE_WORK.W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO02_GERAL);
                    }

                }

            }


            /*" -4075- MOVE SPACES TO COD03-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD03_GERAL);

            /*" -4077- MOVE SPACES TO VALO03-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.VALO03_GERAL);

            /*" -4078- MOVE SPACES TO COD04-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD04_GERAL);

            /*" -4080- MOVE SPACES TO VALO04-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.VALO04_GERAL);

            /*" -4081- MOVE SPACES TO COD05-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD05_GERAL);

            /*" -4087- MOVE SPACES TO VALO05-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.VALO05_GERAL);

            /*" -4098- PERFORM R3005-LIMPA-OS-COD-E-VALOR THRU R3005-EXIT. */

            R3005_LIMPA_OS_COD_E_VALOR(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R3005_EXIT*/


            /*" -4101- IF SINISHIS-COD-OPERACAO EQUAL 4291 OR W-CHAVE-EH-PRESTADOR EQUAL 'NAO' */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO == 4291 || AREA_DE_WORK.W_CHAVE_EH_PRESTADOR == "NAO")
            {

                /*" -4107- GO TO R3550-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3550_EXIT*/ //GOTO
                return;
            }


            /*" -4108- MOVE 'NAO' TO W-CHAVE-TEM-IMPOSTOS. */
            _.Move("NAO", AREA_DE_WORK.W_CHAVE_TEM_IMPOSTOS);

            /*" -4110- MOVE 'NAO' TO WFIM-IMPOSTOS . */
            _.Move("NAO", AREA_DE_WORK.WFIM_IMPOSTOS);

            /*" -4111- PERFORM R4000-DECLARE-IMPOSTOS THRU R4000-EXIT. */

            R4000_DECLARE_IMPOSTOS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_EXIT*/


            /*" -4128- PERFORM R4001-FETCH-IMPOSTOS THRU R4001-EXIT. */

            R4001_FETCH_IMPOSTOS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R4001_EXIT*/


            /*" -4129- PERFORM R4010-PROCESSA-IMPOSTOS THRU R4010-EXIT UNTIL WFIM-IMPOSTOS EQUAL 'SIM' . */

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
            /*" -4140- MOVE 'ATR_CRED' TO ATTR01-GERAL. */
            _.Move("ATR_CRED", W_REGISTRO_SIAS_GERAL.ATTR01_GERAL);

            /*" -4145- MOVE ALL 'X' TO ATTRVAL01-GERAL. */
            _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL01_GERAL);

            /*" -4152- MOVE ZEROS TO LKGE-RAMO-EMISSOR LKGE-MODALIDADE LKGE-PRODUTO LKGE-GRUPO-SUSEP LKGE-RAMO-SUSEP LKGE-SQLCODE. */
            _.Move(0, PARAMETROS_GE.LKGE_RAMO_EMISSOR, PARAMETROS_GE.LKGE_MODALIDADE, PARAMETROS_GE.LKGE_PRODUTO, PARAMETROS_GE.LKGE_GRUPO_SUSEP, PARAMETROS_GE.LKGE_RAMO_SUSEP, PARAMETROS_GE.LKGE_SQLCODE);

            /*" -4155- MOVE SPACES TO LKGE-INIVIGENCIA LKGE-MENSAGEM. */
            _.Move("", PARAMETROS_GE.LKGE_INIVIGENCIA, PARAMETROS_GE.LKGE_MENSAGEM);

            /*" -4157- MOVE SINISMES-RAMO TO LKGE-RAMO-EMISSOR. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO, PARAMETROS_GE.LKGE_RAMO_EMISSOR);

            /*" -4158- IF SINISMES-RAMO EQUAL 48 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO == 48)
            {

                /*" -4160- MOVE SINISMES-COD-PRODUTO TO LKGE-PRODUTO. */
                _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO, PARAMETROS_GE.LKGE_PRODUTO);
            }


            /*" -4163- MOVE HOST-SI-DATA-MOV-ABERTO TO LKGE-INIVIGENCIA. */
            _.Move(HOST_SI_DATA_MOV_ABERTO, PARAMETROS_GE.LKGE_INIVIGENCIA);

            /*" -4166- CALL 'GE0005S' USING PARAMETROS-GE. */
            _.Call("GE0005S", PARAMETROS_GE);

            /*" -4167- IF LKGE-MENSAGEM NOT EQUAL SPACES */

            if (!PARAMETROS_GE.LKGE_MENSAGEM.IsEmpty())
            {

                /*" -4168- DISPLAY 'R1250 - ERRO NO CALL DA SUB-ROTINA GE0005S' */
                _.Display($"R1250 - ERRO NO CALL DA SUB-ROTINA GE0005S");

                /*" -4169- DISPLAY 'ERRO ...... ' LKGE-MENSAGEM */
                _.Display($"ERRO ...... {PARAMETROS_GE.LKGE_MENSAGEM}");

                /*" -4170- DISPLAY 'SQLCODE ... ' LKGE-SQLCODE */
                _.Display($"SQLCODE ... {PARAMETROS_GE.LKGE_SQLCODE}");

                /*" -4171- DISPLAY 'RAMO ...... ' LKGE-RAMO-EMISSOR */
                _.Display($"RAMO ...... {PARAMETROS_GE.LKGE_RAMO_EMISSOR}");

                /*" -4172- DISPLAY 'PRODUTO ... ' LKGE-PRODUTO */
                _.Display($"PRODUTO ... {PARAMETROS_GE.LKGE_PRODUTO}");

                /*" -4173- DISPLAY 'VIGENCIA .. ' LKGE-INIVIGENCIA */
                _.Display($"VIGENCIA .. {PARAMETROS_GE.LKGE_INIVIGENCIA}");

                /*" -4174- MOVE LKGE-SQLCODE TO SQLCODE */
                _.Move(PARAMETROS_GE.LKGE_SQLCODE, DB.SQLCODE);

                /*" -4176- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -4177- MOVE 'ATR_PROP' TO ATTR02-GERAL. */
            _.Move("ATR_PROP", W_REGISTRO_SIAS_GERAL.ATTR02_GERAL);

            /*" -4179- MOVE ALL 'X' TO ATTRVAL02-GERAL. */
            _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL02_GERAL);

            /*" -4180- MOVE 'ATR_CANA' TO ATTR03-GERAL. */
            _.Move("ATR_CANA", W_REGISTRO_SIAS_GERAL.ATTR03_GERAL);

            /*" -4182- MOVE ALL 'X' TO ATTRVAL03-GERAL. */
            _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL03_GERAL);

            /*" -4183- MOVE 'ATR_NNUM' TO ATTR04-GERAL. */
            _.Move("ATR_NNUM", W_REGISTRO_SIAS_GERAL.ATTR04_GERAL);

            /*" -4185- MOVE ALL 'X' TO ATTRVAL04-GERAL. */
            _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL04_GERAL);

            /*" -4186- MOVE 'ATR_DTCR' TO ATTR05-GERAL. */
            _.Move("ATR_DTCR", W_REGISTRO_SIAS_GERAL.ATTR05_GERAL);

            /*" -4188- MOVE ALL 'X' TO ATTRVAL05-GERAL. */
            _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL05_GERAL);

            /*" -4189- MOVE 'ATR_CDCC' TO ATTR06-GERAL. */
            _.Move("ATR_CDCC", W_REGISTRO_SIAS_GERAL.ATTR06_GERAL);

            /*" -4191- MOVE MOVDEBCE-COD-CONVENIO TO ATTRVAL06-GERAL. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO, W_REGISTRO_SIAS_GERAL.ATTRVAL06_GERAL);

            /*" -4192- MOVE 'ATR_CODU' TO ATTR07-GERAL. */
            _.Move("ATR_CODU", W_REGISTRO_SIAS_GERAL.ATTR07_GERAL);

            /*" -4194- MOVE 'AUTO' TO ATTRVAL07-GERAL. */
            _.Move("AUTO", W_REGISTRO_SIAS_GERAL.ATTRVAL07_GERAL);

            /*" -4195- MOVE 'ATR_APOL' TO ATTR08-GERAL. */
            _.Move("ATR_APOL", W_REGISTRO_SIAS_GERAL.ATTR08_GERAL);

            /*" -4197- MOVE SINISHIS-NUM-APOLICE TO ATTRVAL08-GERAL. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOLICE, W_REGISTRO_SIAS_GERAL.ATTRVAL08_GERAL);

            /*" -4198- MOVE 'ATR_NEND' TO ATTR09-GERAL. */
            _.Move("ATR_NEND", W_REGISTRO_SIAS_GERAL.ATTR09_GERAL);

            /*" -4200- MOVE ALL 'X' TO ATTRVAL09-GERAL. */
            _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL09_GERAL);

            /*" -4201- MOVE 'ATR_PARC' TO ATTR10-GERAL. */
            _.Move("ATR_PARC", W_REGISTRO_SIAS_GERAL.ATTR10_GERAL);

            /*" -4203- MOVE ALL 'X' TO ATTRVAL10-GERAL. */
            _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL10_GERAL);

            /*" -4204- MOVE 'ATR_TPCV' TO ATTR11-GERAL. */
            _.Move("ATR_TPCV", W_REGISTRO_SIAS_GERAL.ATTR11_GERAL);

            /*" -4205- IF MOVDEBCE-COD-CONVENIO EQUAL 43350 */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO == 43350)
            {

                /*" -4206- MOVE 'A' TO ATTRVAL11-GERAL */
                _.Move("A", W_REGISTRO_SIAS_GERAL.ATTRVAL11_GERAL);

                /*" -4207- ELSE */
            }
            else
            {


                /*" -4208- IF MOVDEBCE-COD-CONVENIO EQUAL 600119 OR 600123 */

                if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.In("600119", "600123"))
                {

                    /*" -4209- MOVE 'B' TO ATTRVAL11-GERAL */
                    _.Move("B", W_REGISTRO_SIAS_GERAL.ATTRVAL11_GERAL);

                    /*" -4210- ELSE */
                }
                else
                {


                    /*" -4212- MOVE ALL 'X' TO ATTRVAL11-GERAL . */
                    _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL11_GERAL);
                }

            }


            /*" -4213- MOVE 'ATR_COMP' TO ATTR12-GERAL. */
            _.Move("ATR_COMP", W_REGISTRO_SIAS_GERAL.ATTR12_GERAL);

            /*" -4214- IF ATTRVAL11-GERAL EQUAL 'A' */

            if (W_REGISTRO_SIAS_GERAL.ATTRVAL11_GERAL == "A")
            {

                /*" -4215- MOVE '0' TO ATTRVAL12-GERAL */
                _.Move("0", W_REGISTRO_SIAS_GERAL.ATTRVAL12_GERAL);

                /*" -4216- ELSE */
            }
            else
            {


                /*" -4218- MOVE ALL 'X' TO ATTRVAL12-GERAL . */
                _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL12_GERAL);
            }


            /*" -4219- MOVE 'ATR_FTEP' TO ATTR13-GERAL. */
            _.Move("ATR_FTEP", W_REGISTRO_SIAS_GERAL.ATTR13_GERAL);

            /*" -4221- MOVE SINISMES-COD-FONTE TO ATTRVAL13-GERAL. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE, W_REGISTRO_SIAS_GERAL.ATTRVAL13_GERAL);

            /*" -4222- MOVE 'ATR_PROD' TO ATTR14-GERAL. */
            _.Move("ATR_PROD", W_REGISTRO_SIAS_GERAL.ATTR14_GERAL);

            /*" -4223- MOVE 'L000' TO W-PRODUTO-SAP-L000. */
            _.Move("L000", AREA_DE_WORK.W_PRODUTO_SAP.W_PRODUTO_SAP_L000);

            /*" -4224- MOVE SINISMES-COD-PRODUTO TO W-PRODUTO-SAP-PRODUTO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO, AREA_DE_WORK.W_PRODUTO_SAP.W_PRODUTO_SAP_PRODUTO);

            /*" -4226- MOVE W-PRODUTO-SAP TO ATTRVAL14-GERAL. */
            _.Move(AREA_DE_WORK.W_PRODUTO_SAP, W_REGISTRO_SIAS_GERAL.ATTRVAL14_GERAL);

            /*" -4227- MOVE 'ATR_RAMO' TO ATTR15-GERAL. */
            _.Move("ATR_RAMO", W_REGISTRO_SIAS_GERAL.ATTR15_GERAL);

            /*" -4231- MOVE LKGE-RAMO-SUSEP TO ATTRVAL15-GERAL. */
            _.Move(PARAMETROS_GE.LKGE_RAMO_SUSEP, W_REGISTRO_SIAS_GERAL.ATTRVAL15_GERAL);

            /*" -4232- MOVE 'ATR_FREC' TO ATTR16-GERAL. */
            _.Move("ATR_FREC", W_REGISTRO_SIAS_GERAL.ATTR16_GERAL);

            /*" -4234- MOVE 'D' TO ATTRVAL16-GERAL. */
            _.Move("D", W_REGISTRO_SIAS_GERAL.ATTRVAL16_GERAL);

            /*" -4235- MOVE 'ATR_DVEN' TO ATTR17-GERAL. */
            _.Move("ATR_DVEN", W_REGISTRO_SIAS_GERAL.ATTR17_GERAL);

            /*" -4237- MOVE MOVDEBCE-DATA-VENCIMENTO(1:4) TO W-DATA-AAAAMMDD-AAAA. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO.Substring(1, 4), AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_AAAA);

            /*" -4239- MOVE MOVDEBCE-DATA-VENCIMENTO(6:2) TO W-DATA-AAAAMMDD-MM. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO.Substring(6, 2), AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_MM);

            /*" -4241- MOVE MOVDEBCE-DATA-VENCIMENTO(9:2) TO W-DATA-AAAAMMDD-DD. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO.Substring(9, 2), AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_DD);

            /*" -4243- MOVE W-DATA-AAAAMMDD TO ATTRVAL17-GERAL. */
            _.Move(AREA_DE_WORK.W_DATA_AAAAMMDD, W_REGISTRO_SIAS_GERAL.ATTRVAL17_GERAL);

            /*" -4244- MOVE SPACES TO ATTR18-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTR18_GERAL);

            /*" -4246- MOVE SPACES TO ATTRVAL18-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTRVAL18_GERAL);

            /*" -4247- MOVE 'ATR_ACCT' TO ATTR19-GERAL. */
            _.Move("ATR_ACCT", W_REGISTRO_SIAS_GERAL.ATTR19_GERAL);

            /*" -4251- MOVE SINISHIS-NUM-APOL-SINISTRO TO ATTRVAL19-GERAL. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, W_REGISTRO_SIAS_GERAL.ATTRVAL19_GERAL);

            /*" -4252- MOVE 'ATR_SNTR' TO ATTR20-GERAL. */
            _.Move("ATR_SNTR", W_REGISTRO_SIAS_GERAL.ATTR20_GERAL);

            /*" -4254- MOVE SINISHIS-NUM-APOL-SINISTRO TO ATTRVAL20-GERAL. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, W_REGISTRO_SIAS_GERAL.ATTRVAL20_GERAL);

            /*" -4255- MOVE SPACES TO ATTR21-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTR21_GERAL);

            /*" -4257- MOVE SPACES TO ATTRVAL21-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTRVAL21_GERAL);

            /*" -4258- MOVE SPACES TO ATTR22-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTR22_GERAL);

            /*" -4260- MOVE SPACES TO ATTRVAL22-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTRVAL22_GERAL);

            /*" -4261- MOVE SPACES TO ATTR23-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTR23_GERAL);

            /*" -4263- MOVE SPACES TO ATTRVAL23-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTRVAL23_GERAL);

            /*" -4264- MOVE SPACES TO ATTR24-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTR24_GERAL);

            /*" -4266- MOVE SPACES TO ATTRVAL24-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTRVAL24_GERAL);

            /*" -4267- MOVE SPACES TO ATTR25-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTR25_GERAL);

            /*" -4269- MOVE SPACES TO ATTRVAL25-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTRVAL25_GERAL);

            /*" -4270- MOVE SPACES TO ATTR26-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTR26_GERAL);

            /*" -4272- MOVE SPACES TO ATTRVAL26-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTRVAL26_GERAL);

            /*" -4273- MOVE SPACES TO ATTR27-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTR27_GERAL);

            /*" -4275- MOVE SPACES TO ATTRVAL27-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTRVAL27_GERAL);

            /*" -4276- MOVE SPACES TO ATTR28-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTR28_GERAL);

            /*" -4278- MOVE SPACES TO ATTRVAL28-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTRVAL28_GERAL);

            /*" -4279- MOVE SPACES TO ATTR29-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTR29_GERAL);

            /*" -4281- MOVE SPACES TO ATTRVAL29-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTRVAL29_GERAL);

            /*" -4282- MOVE SPACES TO ATTR30-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTR30_GERAL);

            /*" -4284- MOVE SPACES TO ATTRVAL30-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTRVAL30_GERAL);

            /*" -4285- MOVE SPACES TO ATTR31-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTR31_GERAL);

            /*" -4287- MOVE SPACES TO ATTRVAL31-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.ATTRVAL31_GERAL);

            /*" -4288- MOVE 'ATR_TPAR' TO ATTR32-GERAL. */
            _.Move("ATR_TPAR", W_REGISTRO_SIAS_GERAL.ATTR32_GERAL);

            /*" -4290- MOVE ALL 'X' TO ATTRVAL32-GERAL. */
            _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL32_GERAL);

            /*" -4291- MOVE 'ATR_IDCC' TO ATTR33-GERAL. */
            _.Move("ATR_IDCC", W_REGISTRO_SIAS_GERAL.ATTR33_GERAL);

            /*" -4293- MOVE ALL ' ' TO ATTRVAL33-GERAL. */
            _.MoveAll(" ", W_REGISTRO_SIAS_GERAL.ATTRVAL33_GERAL);

            /*" -4294- MOVE 'ATR_IDBC' TO ATTR34-GERAL. */
            _.Move("ATR_IDBC", W_REGISTRO_SIAS_GERAL.ATTR34_GERAL);

            /*" -4296- MOVE ALL ' ' TO ATTRVAL34-GERAL. */
            _.MoveAll(" ", W_REGISTRO_SIAS_GERAL.ATTRVAL34_GERAL);

            /*" -4297- MOVE 'ATR_PNEG' TO ATTR35-GERAL. */
            _.Move("ATR_PNEG", W_REGISTRO_SIAS_GERAL.ATTR35_GERAL);

            /*" -4297- MOVE ALL ' ' TO ATTRVAL35-GERAL. */
            _.MoveAll(" ", W_REGISTRO_SIAS_GERAL.ATTRVAL35_GERAL);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3700_EXIT*/

        [StopWatch]
        /*" R3750-MONTA-CODV-RECEB-MOD-CA */
        private void R3750_MONTA_CODV_RECEB_MOD_CA(bool isPerform = false)
        {
            /*" -4307- MOVE SPACES TO COD01-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD01_GERAL);

            /*" -4309- MOVE SPACES TO VALO01-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.VALO01_GERAL);

            /*" -4310- MOVE 'CV_AVISO' TO COD01-GERAL */
            _.Move("CV_AVISO", W_REGISTRO_SIAS_GERAL.COD01_GERAL);

            /*" -4311- MOVE SINISHIS-VAL-OPERACAO TO W-VALOR-GERAL-VALOR */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, AREA_DE_WORK.W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

            /*" -4312- ADD SINISHIS-VAL-OPERACAO TO W-TOTAL-VALORES */
            AREA_DE_WORK.W_TOTAL_VALORES.Value = AREA_DE_WORK.W_TOTAL_VALORES + SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO;

            /*" -4314- MOVE W-VALOR-GERAL-X TO VALO01-GERAL */
            _.Move(AREA_DE_WORK.W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO01_GERAL);

            /*" -4315- MOVE SPACES TO COD02-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD02_GERAL);

            /*" -4316- MOVE SPACES TO VALO02-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.VALO02_GERAL);

            /*" -4317- MOVE SPACES TO COD03-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD03_GERAL);

            /*" -4318- MOVE SPACES TO VALO03-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.VALO03_GERAL);

            /*" -4319- MOVE SPACES TO COD04-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD04_GERAL);

            /*" -4320- MOVE SPACES TO VALO04-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.VALO04_GERAL);

            /*" -4321- MOVE SPACES TO COD05-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD05_GERAL);

            /*" -4322- MOVE SPACES TO VALO05-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.VALO05_GERAL);

            /*" -4323- MOVE SPACES TO COD06-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD06_GERAL);

            /*" -4324- MOVE SPACES TO VALO06-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.VALO06_GERAL);

            /*" -4325- MOVE SPACES TO COD07-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD07_GERAL);

            /*" -4326- MOVE SPACES TO VALO07-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.VALO07_GERAL);

            /*" -4327- MOVE SPACES TO COD08-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD08_GERAL);

            /*" -4328- MOVE SPACES TO VALO08-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.VALO08_GERAL);

            /*" -4329- MOVE SPACES TO COD09-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD09_GERAL);

            /*" -4330- MOVE SPACES TO VALO09-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.VALO09_GERAL);

            /*" -4331- MOVE SPACES TO COD010-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD010_GERAL);

            /*" -4332- MOVE SPACES TO VALO010-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.VALO010_GERAL);

            /*" -4333- MOVE SPACES TO COD011-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD011_GERAL);

            /*" -4334- MOVE SPACES TO VALO011-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.VALO011_GERAL);

            /*" -4335- MOVE SPACES TO COD012-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD012_GERAL);

            /*" -4336- MOVE SPACES TO VALO012-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.VALO012_GERAL);

            /*" -4337- MOVE SPACES TO COD013-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD013_GERAL);

            /*" -4338- MOVE SPACES TO VALO013-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.VALO013_GERAL);

            /*" -4339- MOVE SPACES TO COD014-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD014_GERAL);

            /*" -4340- MOVE SPACES TO VALO014-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.VALO014_GERAL);

            /*" -4341- MOVE SPACES TO COD015-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD015_GERAL);

            /*" -4342- MOVE SPACES TO VALO015-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.VALO015_GERAL);

            /*" -4343- MOVE SPACES TO COD016-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD016_GERAL);

            /*" -4344- MOVE SPACES TO VALO016-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.VALO016_GERAL);

            /*" -4345- MOVE SPACES TO COD017-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD017_GERAL);

            /*" -4346- MOVE SPACES TO VALO017-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.VALO017_GERAL);

            /*" -4347- MOVE SPACES TO COD018-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD018_GERAL);

            /*" -4348- MOVE SPACES TO VALO018-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.VALO018_GERAL);

            /*" -4349- MOVE SPACES TO COD019-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD019_GERAL);

            /*" -4350- MOVE SPACES TO VALO019-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.VALO019_GERAL);

            /*" -4351- MOVE SPACES TO COD021-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD021_GERAL);

            /*" -4352- MOVE SPACES TO VALO021-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.VALO021_GERAL);

            /*" -4353- MOVE SPACES TO COD022-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD022_GERAL);

            /*" -4354- MOVE SPACES TO VALO022-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.VALO022_GERAL);

            /*" -4355- MOVE SPACES TO COD023-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD023_GERAL);

            /*" -4356- MOVE SPACES TO VALO023-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.VALO023_GERAL);

            /*" -4357- MOVE SPACES TO COD024-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD024_GERAL);

            /*" -4358- MOVE SPACES TO VALO024-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.VALO024_GERAL);

            /*" -4359- MOVE SPACES TO COD025-GERAL */
            _.Move("", W_REGISTRO_SIAS_GERAL.COD025_GERAL);

            /*" -4359- MOVE SPACES TO VALO025-GERAL. */
            _.Move("", W_REGISTRO_SIAS_GERAL.VALO025_GERAL);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3750_EXIT*/

        [StopWatch]
        /*" R4000-DECLARE-IMPOSTOS */
        private void R4000_DECLARE_IMPOSTOS(bool isPerform = false)
        {
            /*" -4366- INITIALIZE DCLSI-PAGA-DOC-FISCAL */
            _.Initialize(
                SIPADOFI.DCLSI_PAGA_DOC_FISCAL
            );

            /*" -4367- INITIALIZE DCLGE-TP-LANC-DOCF */
            _.Initialize(
                GETPLADO.DCLGE_TP_LANC_DOCF
            );

            /*" -4368- INITIALIZE DCLFI-PAGA-DOCF-LANC */
            _.Initialize(
                FIPADOLA.DCLFI_PAGA_DOCF_LANC
            );

            /*" -4369- INITIALIZE DCLGE-TIPO-IMPOSTO */
            _.Initialize(
                GETIPIMP.DCLGE_TIPO_IMPOSTO
            );

            /*" -4370- INITIALIZE DCLFI-PAGA-DOCF-IMP. */
            _.Initialize(
                FIPADOIM.DCLFI_PAGA_DOCF_IMP
            );

            /*" -4375- INITIALIZE DCLFI-PAGA-DOC-FISCAL. */
            _.Initialize(
                FIPADOFI.DCLFI_PAGA_DOC_FISCAL
            );

            /*" -4415- PERFORM R4000_DECLARE_IMPOSTOS_DB_DECLARE_1 */

            R4000_DECLARE_IMPOSTOS_DB_DECLARE_1();

            /*" -4417- PERFORM R4000_DECLARE_IMPOSTOS_DB_OPEN_1 */

            R4000_DECLARE_IMPOSTOS_DB_OPEN_1();

            /*" -4420- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -4421- DISPLAY 'SISAP15B - ERRO CURSOR IMPOSTOS' */
                _.Display($"SISAP15B - ERRO CURSOR IMPOSTOS");

                /*" -4421- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4000-DECLARE-IMPOSTOS-DB-OPEN-1 */
        public void R4000_DECLARE_IMPOSTOS_DB_OPEN_1()
        {
            /*" -4417- EXEC SQL OPEN IMPOSTOS END-EXEC. */

            IMPOSTOS.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_EXIT*/

        [StopWatch]
        /*" R4001-FETCH-IMPOSTOS */
        private void R4001_FETCH_IMPOSTOS(bool isPerform = false)
        {
            /*" -4442- PERFORM R4001_FETCH_IMPOSTOS_DB_FETCH_1 */

            R4001_FETCH_IMPOSTOS_DB_FETCH_1();

            /*" -4445- IF SQLCODE EQUAL 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -4450- MOVE 'SIM' TO W-CHAVE-TEM-IMPOSTOS. */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_TEM_IMPOSTOS);
            }


            /*" -4451- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -4451- PERFORM R4001_FETCH_IMPOSTOS_DB_CLOSE_1 */

                R4001_FETCH_IMPOSTOS_DB_CLOSE_1();

                /*" -4453- MOVE 'SIM' TO WFIM-IMPOSTOS */
                _.Move("SIM", AREA_DE_WORK.WFIM_IMPOSTOS);

                /*" -4455- GO TO R4001-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R4001_EXIT*/ //GOTO
                return;
            }


            /*" -4456- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -4457- DISPLAY 'SISAP15B - ERRO NO FETCH CURSOR IMPOSTOS' */
                _.Display($"SISAP15B - ERRO NO FETCH CURSOR IMPOSTOS");

                /*" -4457- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4001-FETCH-IMPOSTOS-DB-FETCH-1 */
        public void R4001_FETCH_IMPOSTOS_DB_FETCH_1()
        {
            /*" -4442- EXEC SQL FETCH IMPOSTOS INTO :SINISHIS-NUM-APOL-SINISTRO, :SINISHIS-OCORR-HISTORICO, :SINISHIS-COD-OPERACAO, :SIPADOFI-NUM-DOCF-INTERNO, :FIPADOLA-COD-TP-LANCDOCF, :GETPLADO-ABREV-LANCDOCF, :FIPADOLA-VALOR-LANCAMENTO, :GETIPIMP-COD-IMP-INTERNO, :GETIPIMP-SIGLA-IMP, :FIPADOIM-ALIQ-TRIBUTACAO, :FIPADOIM-VALOR-IMPOSTO, :FIPADOFI-NUM-DOC-FISCAL:NULL-NUM-DOC-FISCAL, :FIPADOFI-SERIE-DOC-FISCAL:NULL-SERIE-DOC-FISCAL, :FIPADOFI-DATA-EMISSAO-DOC:NULL-DATA-EMISSAO-DOC END-EXEC. */

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
                _.Move(IMPOSTOS.FIPADOFI_NUM_DOC_FISCAL, FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_NUM_DOC_FISCAL);
                _.Move(IMPOSTOS.NULL_NUM_DOC_FISCAL, NULL_NUM_DOC_FISCAL);
                _.Move(IMPOSTOS.FIPADOFI_SERIE_DOC_FISCAL, FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_SERIE_DOC_FISCAL);
                _.Move(IMPOSTOS.NULL_SERIE_DOC_FISCAL, NULL_SERIE_DOC_FISCAL);
                _.Move(IMPOSTOS.FIPADOFI_DATA_EMISSAO_DOC, FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_DATA_EMISSAO_DOC);
                _.Move(IMPOSTOS.NULL_DATA_EMISSAO_DOC, NULL_DATA_EMISSAO_DOC);
            }

        }

        [StopWatch]
        /*" R4001-FETCH-IMPOSTOS-DB-CLOSE-1 */
        public void R4001_FETCH_IMPOSTOS_DB_CLOSE_1()
        {
            /*" -4451- EXEC SQL CLOSE IMPOSTOS END-EXEC */

            IMPOSTOS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4001_EXIT*/

        [StopWatch]
        /*" R4010-PROCESSA-IMPOSTOS */
        private void R4010_PROCESSA_IMPOSTOS(bool isPerform = false)
        {
            /*" -4475- IF GETIPIMP-COD-IMP-INTERNO EQUAL 1 */

            if (GETIPIMP.DCLGE_TIPO_IMPOSTO.GETIPIMP_COD_IMP_INTERNO == 1)
            {

                /*" -4477- IF W-CHAVE-TIPO-PESSOA-PF-PJ EQUAL 'PF' */

                if (AREA_DE_WORK.W_CHAVE_TIPO_PESSOA_PF_PJ == "PF")
                {

                    /*" -4478- MOVE 'S1' TO ATTRVAL21-GERAL */
                    _.Move("S1", W_REGISTRO_SIAS_GERAL.ATTRVAL21_GERAL);

                    /*" -4479- ELSE */
                }
                else
                {


                    /*" -4480- IF W-CHAVE-TIPO-PESSOA-PF-PJ EQUAL 'PJ' */

                    if (AREA_DE_WORK.W_CHAVE_TIPO_PESSOA_PF_PJ == "PJ")
                    {

                        /*" -4481- IF FIPADOIM-ALIQ-TRIBUTACAO EQUAL 1,00000 */

                        if (FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_ALIQ_TRIBUTACAO == 1.00000)
                        {

                            /*" -4482- MOVE 'J2' TO ATTRVAL20-GERAL */
                            _.Move("J2", W_REGISTRO_SIAS_GERAL.ATTRVAL20_GERAL);

                            /*" -4484- ELSE */
                        }
                        else
                        {


                            /*" -4485- MOVE 'J1' TO ATTRVAL20-GERAL */
                            _.Move("J1", W_REGISTRO_SIAS_GERAL.ATTRVAL20_GERAL);

                            /*" -4486- END-IF */
                        }


                        /*" -4488- ELSE */
                    }
                    else
                    {


                        /*" -4490- MOVE ALL '?34?' TO ATTRVAL20-GERAL */
                        _.MoveAll("?34?", W_REGISTRO_SIAS_GERAL.ATTRVAL20_GERAL);

                        /*" -4492- MOVE ALL '?34?' TO ATTRVAL21-GERAL. */
                        _.MoveAll("?34?", W_REGISTRO_SIAS_GERAL.ATTRVAL21_GERAL);
                    }

                }

            }


            /*" -4493- IF GETIPIMP-COD-IMP-INTERNO EQUAL 1 */

            if (GETIPIMP.DCLGE_TIPO_IMPOSTO.GETIPIMP_COD_IMP_INTERNO == 1)
            {

                /*" -4494- MOVE FIPADOLA-VALOR-LANCAMENTO TO W-VALOR-GERAL-VALOR */
                _.Move(FIPADOLA.DCLFI_PAGA_DOCF_LANC.FIPADOLA_VALOR_LANCAMENTO, AREA_DE_WORK.W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

                /*" -4495- ADD FIPADOLA-VALOR-LANCAMENTO TO W-TOTAL-VALORES */
                AREA_DE_WORK.W_TOTAL_VALORES.Value = AREA_DE_WORK.W_TOTAL_VALORES + FIPADOLA.DCLFI_PAGA_DOCF_LANC.FIPADOLA_VALOR_LANCAMENTO;

                /*" -4496- IF W-CHAVE-TIPO-PESSOA-PF-PJ EQUAL 'PF' */

                if (AREA_DE_WORK.W_CHAVE_TIPO_PESSOA_PF_PJ == "PF")
                {

                    /*" -4497- MOVE 'CV_IRFBS' TO COD06-GERAL */
                    _.Move("CV_IRFBS", W_REGISTRO_SIAS_GERAL.COD06_GERAL);

                    /*" -4498- MOVE W-VALOR-GERAL-X TO VALO06-GERAL */
                    _.Move(AREA_DE_WORK.W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO06_GERAL);

                    /*" -4499- ELSE */
                }
                else
                {


                    /*" -4500- IF W-CHAVE-TIPO-PESSOA-PF-PJ EQUAL 'PJ' */

                    if (AREA_DE_WORK.W_CHAVE_TIPO_PESSOA_PF_PJ == "PJ")
                    {

                        /*" -4501- MOVE 'CV_IRJBS' TO COD018-GERAL */
                        _.Move("CV_IRJBS", W_REGISTRO_SIAS_GERAL.COD018_GERAL);

                        /*" -4502- MOVE W-VALOR-GERAL-X TO VALO018-GERAL */
                        _.Move(AREA_DE_WORK.W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO018_GERAL);

                        /*" -4503- ELSE */
                    }
                    else
                    {


                        /*" -4504- MOVE ALL '?35?' TO COD06-GERAL VALO06-GERAL */
                        _.MoveAll("?35?", W_REGISTRO_SIAS_GERAL.COD06_GERAL, W_REGISTRO_SIAS_GERAL.VALO06_GERAL);

                        /*" -4509- MOVE ALL '?36?' TO COD018-GERAL VALO018-GERAL. */
                        _.MoveAll("?36?", W_REGISTRO_SIAS_GERAL.COD018_GERAL, W_REGISTRO_SIAS_GERAL.VALO018_GERAL);
                    }

                }

            }


            /*" -4512- MOVE 'ATR_CDIN' TO ATTR23-GERAL . */
            _.Move("ATR_CDIN", W_REGISTRO_SIAS_GERAL.ATTR23_GERAL);

            /*" -4513- IF GETIPIMP-COD-IMP-INTERNO EQUAL 2 */

            if (GETIPIMP.DCLGE_TIPO_IMPOSTO.GETIPIMP_COD_IMP_INTERNO == 2)
            {

                /*" -4514- IF W-CHAVE-TIPO-PESSOA-PF-PJ EQUAL 'PF' */

                if (AREA_DE_WORK.W_CHAVE_TIPO_PESSOA_PF_PJ == "PF")
                {

                    /*" -4515- MOVE 'M1' TO ATTRVAL23-GERAL */
                    _.Move("M1", W_REGISTRO_SIAS_GERAL.ATTRVAL23_GERAL);

                    /*" -4516- ELSE */
                }
                else
                {


                    /*" -4517- IF W-CHAVE-TIPO-PESSOA-PF-PJ EQUAL 'PJ' */

                    if (AREA_DE_WORK.W_CHAVE_TIPO_PESSOA_PF_PJ == "PJ")
                    {

                        /*" -4518- MOVE 'N1' TO ATTRVAL23-GERAL */
                        _.Move("N1", W_REGISTRO_SIAS_GERAL.ATTRVAL23_GERAL);

                        /*" -4519- ELSE */
                    }
                    else
                    {


                        /*" -4522- MOVE ALL '?35?' TO ATTRVAL23-GERAL. */
                        _.MoveAll("?35?", W_REGISTRO_SIAS_GERAL.ATTRVAL23_GERAL);
                    }

                }

            }


            /*" -4523- IF GETIPIMP-COD-IMP-INTERNO EQUAL 2 */

            if (GETIPIMP.DCLGE_TIPO_IMPOSTO.GETIPIMP_COD_IMP_INTERNO == 2)
            {

                /*" -4524- MOVE 'CV_INSBS' TO COD010-GERAL */
                _.Move("CV_INSBS", W_REGISTRO_SIAS_GERAL.COD010_GERAL);

                /*" -4525- MOVE FIPADOLA-VALOR-LANCAMENTO TO W-VALOR-GERAL-VALOR */
                _.Move(FIPADOLA.DCLFI_PAGA_DOCF_LANC.FIPADOLA_VALOR_LANCAMENTO, AREA_DE_WORK.W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

                /*" -4526- ADD FIPADOLA-VALOR-LANCAMENTO TO W-TOTAL-VALORES */
                AREA_DE_WORK.W_TOTAL_VALORES.Value = AREA_DE_WORK.W_TOTAL_VALORES + FIPADOLA.DCLFI_PAGA_DOCF_LANC.FIPADOLA_VALOR_LANCAMENTO;

                /*" -4531- MOVE W-VALOR-GERAL-X TO VALO010-GERAL . */
                _.Move(AREA_DE_WORK.W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO010_GERAL);
            }


            /*" -4532- IF GETIPIMP-COD-IMP-INTERNO EQUAL 3 */

            if (GETIPIMP.DCLGE_TIPO_IMPOSTO.GETIPIMP_COD_IMP_INTERNO == 3)
            {

                /*" -4533- MOVE 'ATR_CDIS' TO ATTR22-GERAL */
                _.Move("ATR_CDIS", W_REGISTRO_SIAS_GERAL.ATTR22_GERAL);

                /*" -4534- IF FIPADOIM-ALIQ-TRIBUTACAO EQUAL 0 */

                if (FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_ALIQ_TRIBUTACAO == 0)
                {

                    /*" -4535- MOVE ALL 'X' TO ATTRVAL22-GERAL */
                    _.MoveAll("X", W_REGISTRO_SIAS_GERAL.ATTRVAL22_GERAL);

                    /*" -4536- ELSE */
                }
                else
                {


                    /*" -4537- IF FIPADOIM-ALIQ-TRIBUTACAO EQUAL 2 */

                    if (FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_ALIQ_TRIBUTACAO == 2)
                    {

                        /*" -4538- MOVE 'D1' TO ATTRVAL22-GERAL */
                        _.Move("D1", W_REGISTRO_SIAS_GERAL.ATTRVAL22_GERAL);

                        /*" -4539- ELSE */
                    }
                    else
                    {


                        /*" -4540- IF FIPADOIM-ALIQ-TRIBUTACAO EQUAL 2,5 */

                        if (FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_ALIQ_TRIBUTACAO == 2.5)
                        {

                            /*" -4541- MOVE 'D2' TO ATTRVAL22-GERAL */
                            _.Move("D2", W_REGISTRO_SIAS_GERAL.ATTRVAL22_GERAL);

                            /*" -4542- ELSE */
                        }
                        else
                        {


                            /*" -4543- IF FIPADOIM-ALIQ-TRIBUTACAO EQUAL 3 */

                            if (FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_ALIQ_TRIBUTACAO == 3)
                            {

                                /*" -4544- MOVE 'D3' TO ATTRVAL22-GERAL */
                                _.Move("D3", W_REGISTRO_SIAS_GERAL.ATTRVAL22_GERAL);

                                /*" -4545- ELSE */
                            }
                            else
                            {


                                /*" -4546- IF FIPADOIM-ALIQ-TRIBUTACAO EQUAL 5 */

                                if (FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_ALIQ_TRIBUTACAO == 5)
                                {

                                    /*" -4547- MOVE 'D4' TO ATTRVAL22-GERAL */
                                    _.Move("D4", W_REGISTRO_SIAS_GERAL.ATTRVAL22_GERAL);

                                    /*" -4548- ELSE */
                                }
                                else
                                {


                                    /*" -4550- MOVE ALL '?37?' TO ATTRVAL22-GERAL. */
                                    _.MoveAll("?37?", W_REGISTRO_SIAS_GERAL.ATTRVAL22_GERAL);
                                }

                            }

                        }

                    }

                }

            }


            /*" -4551- IF GETIPIMP-COD-IMP-INTERNO EQUAL 3 */

            if (GETIPIMP.DCLGE_TIPO_IMPOSTO.GETIPIMP_COD_IMP_INTERNO == 3)
            {

                /*" -4552- MOVE 'CV_ISSBS' TO COD08-GERAL */
                _.Move("CV_ISSBS", W_REGISTRO_SIAS_GERAL.COD08_GERAL);

                /*" -4553- MOVE FIPADOLA-VALOR-LANCAMENTO TO W-VALOR-GERAL-VALOR */
                _.Move(FIPADOLA.DCLFI_PAGA_DOCF_LANC.FIPADOLA_VALOR_LANCAMENTO, AREA_DE_WORK.W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

                /*" -4554- ADD FIPADOLA-VALOR-LANCAMENTO TO W-TOTAL-VALORES */
                AREA_DE_WORK.W_TOTAL_VALORES.Value = AREA_DE_WORK.W_TOTAL_VALORES + FIPADOLA.DCLFI_PAGA_DOCF_LANC.FIPADOLA_VALOR_LANCAMENTO;

                /*" -4560- MOVE W-VALOR-GERAL-X TO VALO08-GERAL . */
                _.Move(AREA_DE_WORK.W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO08_GERAL);
            }


            /*" -4561- IF GETIPIMP-COD-IMP-INTERNO EQUAL 7 */

            if (GETIPIMP.DCLGE_TIPO_IMPOSTO.GETIPIMP_COD_IMP_INTERNO == 7)
            {

                /*" -4562- MOVE 'ATR_CDCS' TO ATTR26-GERAL */
                _.Move("ATR_CDCS", W_REGISTRO_SIAS_GERAL.ATTR26_GERAL);

                /*" -4563- IF FIPADOIM-VALOR-IMPOSTO EQUAL 0 */

                if (FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_VALOR_IMPOSTO == 0)
                {

                    /*" -4564- MOVE 'I1' TO ATTRVAL26-GERAL */
                    _.Move("I1", W_REGISTRO_SIAS_GERAL.ATTRVAL26_GERAL);

                    /*" -4565- ELSE */
                }
                else
                {


                    /*" -4567- MOVE 'I2' TO ATTRVAL26-GERAL. */
                    _.Move("I2", W_REGISTRO_SIAS_GERAL.ATTRVAL26_GERAL);
                }

            }


            /*" -4568- IF GETIPIMP-COD-IMP-INTERNO EQUAL 7 */

            if (GETIPIMP.DCLGE_TIPO_IMPOSTO.GETIPIMP_COD_IMP_INTERNO == 7)
            {

                /*" -4569- MOVE 'CV_CSLBS' TO COD016-GERAL */
                _.Move("CV_CSLBS", W_REGISTRO_SIAS_GERAL.COD016_GERAL);

                /*" -4570- MOVE FIPADOLA-VALOR-LANCAMENTO TO W-VALOR-GERAL-VALOR */
                _.Move(FIPADOLA.DCLFI_PAGA_DOCF_LANC.FIPADOLA_VALOR_LANCAMENTO, AREA_DE_WORK.W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

                /*" -4571- ADD FIPADOLA-VALOR-LANCAMENTO TO W-TOTAL-VALORES */
                AREA_DE_WORK.W_TOTAL_VALORES.Value = AREA_DE_WORK.W_TOTAL_VALORES + FIPADOLA.DCLFI_PAGA_DOCF_LANC.FIPADOLA_VALOR_LANCAMENTO;

                /*" -4576- MOVE W-VALOR-GERAL-X TO VALO016-GERAL . */
                _.Move(AREA_DE_WORK.W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO016_GERAL);
            }


            /*" -4577- IF GETIPIMP-COD-IMP-INTERNO EQUAL 8 */

            if (GETIPIMP.DCLGE_TIPO_IMPOSTO.GETIPIMP_COD_IMP_INTERNO == 8)
            {

                /*" -4578- MOVE 'ATR_CDCF' TO ATTR25-GERAL */
                _.Move("ATR_CDCF", W_REGISTRO_SIAS_GERAL.ATTR25_GERAL);

                /*" -4579- IF FIPADOIM-VALOR-IMPOSTO EQUAL 0 */

                if (FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_VALOR_IMPOSTO == 0)
                {

                    /*" -4580- MOVE 'I6' TO ATTRVAL25-GERAL */
                    _.Move("I6", W_REGISTRO_SIAS_GERAL.ATTRVAL25_GERAL);

                    /*" -4581- ELSE */
                }
                else
                {


                    /*" -4583- MOVE 'I5' TO ATTRVAL25-GERAL. */
                    _.Move("I5", W_REGISTRO_SIAS_GERAL.ATTRVAL25_GERAL);
                }

            }


            /*" -4584- IF GETIPIMP-COD-IMP-INTERNO EQUAL 8 */

            if (GETIPIMP.DCLGE_TIPO_IMPOSTO.GETIPIMP_COD_IMP_INTERNO == 8)
            {

                /*" -4585- MOVE 'CV_COFBS' TO COD014-GERAL */
                _.Move("CV_COFBS", W_REGISTRO_SIAS_GERAL.COD014_GERAL);

                /*" -4586- MOVE FIPADOLA-VALOR-LANCAMENTO TO W-VALOR-GERAL-VALOR */
                _.Move(FIPADOLA.DCLFI_PAGA_DOCF_LANC.FIPADOLA_VALOR_LANCAMENTO, AREA_DE_WORK.W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

                /*" -4587- ADD FIPADOLA-VALOR-LANCAMENTO TO W-TOTAL-VALORES */
                AREA_DE_WORK.W_TOTAL_VALORES.Value = AREA_DE_WORK.W_TOTAL_VALORES + FIPADOLA.DCLFI_PAGA_DOCF_LANC.FIPADOLA_VALOR_LANCAMENTO;

                /*" -4592- MOVE W-VALOR-GERAL-X TO VALO014-GERAL . */
                _.Move(AREA_DE_WORK.W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO014_GERAL);
            }


            /*" -4593- IF GETIPIMP-COD-IMP-INTERNO EQUAL 9 */

            if (GETIPIMP.DCLGE_TIPO_IMPOSTO.GETIPIMP_COD_IMP_INTERNO == 9)
            {

                /*" -4594- MOVE 'ATR_CDPS' TO ATTR24-GERAL */
                _.Move("ATR_CDPS", W_REGISTRO_SIAS_GERAL.ATTR24_GERAL);

                /*" -4595- IF FIPADOIM-VALOR-IMPOSTO EQUAL 0 */

                if (FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_VALOR_IMPOSTO == 0)
                {

                    /*" -4596- MOVE 'I4' TO ATTRVAL24-GERAL */
                    _.Move("I4", W_REGISTRO_SIAS_GERAL.ATTRVAL24_GERAL);

                    /*" -4597- ELSE */
                }
                else
                {


                    /*" -4599- MOVE 'I3' TO ATTRVAL24-GERAL. */
                    _.Move("I3", W_REGISTRO_SIAS_GERAL.ATTRVAL24_GERAL);
                }

            }


            /*" -4600- IF GETIPIMP-COD-IMP-INTERNO EQUAL 9 */

            if (GETIPIMP.DCLGE_TIPO_IMPOSTO.GETIPIMP_COD_IMP_INTERNO == 9)
            {

                /*" -4601- MOVE 'CV_PISBS' TO COD012-GERAL */
                _.Move("CV_PISBS", W_REGISTRO_SIAS_GERAL.COD012_GERAL);

                /*" -4602- MOVE FIPADOLA-VALOR-LANCAMENTO TO W-VALOR-GERAL-VALOR */
                _.Move(FIPADOLA.DCLFI_PAGA_DOCF_LANC.FIPADOLA_VALOR_LANCAMENTO, AREA_DE_WORK.W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

                /*" -4603- ADD FIPADOLA-VALOR-LANCAMENTO TO W-TOTAL-VALORES */
                AREA_DE_WORK.W_TOTAL_VALORES.Value = AREA_DE_WORK.W_TOTAL_VALORES + FIPADOLA.DCLFI_PAGA_DOCF_LANC.FIPADOLA_VALOR_LANCAMENTO;

                /*" -4609- MOVE W-VALOR-GERAL-X TO VALO012-GERAL . */
                _.Move(AREA_DE_WORK.W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO012_GERAL);
            }


            /*" -4609- PERFORM R4001-FETCH-IMPOSTOS THRU R4001-EXIT. */

            R4001_FETCH_IMPOSTOS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R4001_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4010_EXIT*/

        [StopWatch]
        /*" R4020-MANDA-IMP-CALCULADO */
        private void R4020_MANDA_IMP_CALCULADO(bool isPerform = false)
        {
            /*" -4626- IF GETIPIMP-COD-IMP-INTERNO EQUAL 1 */

            if (GETIPIMP.DCLGE_TIPO_IMPOSTO.GETIPIMP_COD_IMP_INTERNO == 1)
            {

                /*" -4627- MOVE FIPADOIM-VALOR-IMPOSTO TO W-VALOR-GERAL-VALOR */
                _.Move(FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_VALOR_IMPOSTO, AREA_DE_WORK.W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

                /*" -4628- ADD FIPADOIM-VALOR-IMPOSTO TO W-TOTAL-VALORES */
                AREA_DE_WORK.W_TOTAL_VALORES.Value = AREA_DE_WORK.W_TOTAL_VALORES + FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_VALOR_IMPOSTO;

                /*" -4629- IF W-CHAVE-TIPO-PESSOA-PF-PJ EQUAL 'PF' */

                if (AREA_DE_WORK.W_CHAVE_TIPO_PESSOA_PF_PJ == "PF")
                {

                    /*" -4630- MOVE 'CV_IRFRT' TO COD07-GERAL */
                    _.Move("CV_IRFRT", W_REGISTRO_SIAS_GERAL.COD07_GERAL);

                    /*" -4631- MOVE W-VALOR-GERAL-X TO VALO07-GERAL */
                    _.Move(AREA_DE_WORK.W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO07_GERAL);

                    /*" -4632- ELSE */
                }
                else
                {


                    /*" -4633- IF W-CHAVE-TIPO-PESSOA-PF-PJ EQUAL 'PJ' */

                    if (AREA_DE_WORK.W_CHAVE_TIPO_PESSOA_PF_PJ == "PJ")
                    {

                        /*" -4634- MOVE 'CV_IRJRT' TO COD019-GERAL */
                        _.Move("CV_IRJRT", W_REGISTRO_SIAS_GERAL.COD019_GERAL);

                        /*" -4635- MOVE W-VALOR-GERAL-X TO VALO019-GERAL */
                        _.Move(AREA_DE_WORK.W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO019_GERAL);

                        /*" -4636- ELSE */
                    }
                    else
                    {


                        /*" -4637- MOVE ALL '?37?' TO COD07-GERAL VALO07-GERAL */
                        _.MoveAll("?37?", W_REGISTRO_SIAS_GERAL.COD07_GERAL, W_REGISTRO_SIAS_GERAL.VALO07_GERAL);

                        /*" -4641- MOVE ALL '?38?' TO COD019-GERAL VALO019-GERAL. */
                        _.MoveAll("?38?", W_REGISTRO_SIAS_GERAL.COD019_GERAL, W_REGISTRO_SIAS_GERAL.VALO019_GERAL);
                    }

                }

            }


            /*" -4642- IF GETIPIMP-COD-IMP-INTERNO EQUAL 2 */

            if (GETIPIMP.DCLGE_TIPO_IMPOSTO.GETIPIMP_COD_IMP_INTERNO == 2)
            {

                /*" -4643- MOVE 'CV_INSRT' TO COD011-GERAL */
                _.Move("CV_INSRT", W_REGISTRO_SIAS_GERAL.COD011_GERAL);

                /*" -4644- MOVE FIPADOIM-VALOR-IMPOSTO TO W-VALOR-GERAL-VALOR */
                _.Move(FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_VALOR_IMPOSTO, AREA_DE_WORK.W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

                /*" -4645- ADD FIPADOIM-VALOR-IMPOSTO TO W-TOTAL-VALORES */
                AREA_DE_WORK.W_TOTAL_VALORES.Value = AREA_DE_WORK.W_TOTAL_VALORES + FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_VALOR_IMPOSTO;

                /*" -4649- MOVE W-VALOR-GERAL-X TO VALO011-GERAL . */
                _.Move(AREA_DE_WORK.W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO011_GERAL);
            }


            /*" -4650- IF GETIPIMP-COD-IMP-INTERNO EQUAL 3 */

            if (GETIPIMP.DCLGE_TIPO_IMPOSTO.GETIPIMP_COD_IMP_INTERNO == 3)
            {

                /*" -4651- MOVE 'CV_ISSRT' TO COD09-GERAL */
                _.Move("CV_ISSRT", W_REGISTRO_SIAS_GERAL.COD09_GERAL);

                /*" -4652- MOVE FIPADOIM-VALOR-IMPOSTO TO W-VALOR-GERAL-VALOR */
                _.Move(FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_VALOR_IMPOSTO, AREA_DE_WORK.W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

                /*" -4653- ADD FIPADOIM-VALOR-IMPOSTO TO W-TOTAL-VALORES */
                AREA_DE_WORK.W_TOTAL_VALORES.Value = AREA_DE_WORK.W_TOTAL_VALORES + FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_VALOR_IMPOSTO;

                /*" -4657- MOVE W-VALOR-GERAL-X TO VALO09-GERAL . */
                _.Move(AREA_DE_WORK.W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO09_GERAL);
            }


            /*" -4658- IF GETIPIMP-COD-IMP-INTERNO EQUAL 7 */

            if (GETIPIMP.DCLGE_TIPO_IMPOSTO.GETIPIMP_COD_IMP_INTERNO == 7)
            {

                /*" -4659- MOVE 'CV_CSLRT' TO COD017-GERAL */
                _.Move("CV_CSLRT", W_REGISTRO_SIAS_GERAL.COD017_GERAL);

                /*" -4660- MOVE FIPADOIM-VALOR-IMPOSTO TO W-VALOR-GERAL-VALOR */
                _.Move(FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_VALOR_IMPOSTO, AREA_DE_WORK.W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

                /*" -4661- ADD FIPADOIM-VALOR-IMPOSTO TO W-TOTAL-VALORES */
                AREA_DE_WORK.W_TOTAL_VALORES.Value = AREA_DE_WORK.W_TOTAL_VALORES + FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_VALOR_IMPOSTO;

                /*" -4665- MOVE W-VALOR-GERAL-X TO VALO017-GERAL . */
                _.Move(AREA_DE_WORK.W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO017_GERAL);
            }


            /*" -4666- IF GETIPIMP-COD-IMP-INTERNO EQUAL 8 */

            if (GETIPIMP.DCLGE_TIPO_IMPOSTO.GETIPIMP_COD_IMP_INTERNO == 8)
            {

                /*" -4667- MOVE 'CV_COFRT' TO COD015-GERAL */
                _.Move("CV_COFRT", W_REGISTRO_SIAS_GERAL.COD015_GERAL);

                /*" -4668- MOVE FIPADOIM-VALOR-IMPOSTO TO W-VALOR-GERAL-VALOR */
                _.Move(FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_VALOR_IMPOSTO, AREA_DE_WORK.W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

                /*" -4669- ADD FIPADOIM-VALOR-IMPOSTO TO W-TOTAL-VALORES */
                AREA_DE_WORK.W_TOTAL_VALORES.Value = AREA_DE_WORK.W_TOTAL_VALORES + FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_VALOR_IMPOSTO;

                /*" -4673- MOVE W-VALOR-GERAL-X TO VALO015-GERAL . */
                _.Move(AREA_DE_WORK.W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO015_GERAL);
            }


            /*" -4674- IF GETIPIMP-COD-IMP-INTERNO EQUAL 9 */

            if (GETIPIMP.DCLGE_TIPO_IMPOSTO.GETIPIMP_COD_IMP_INTERNO == 9)
            {

                /*" -4675- MOVE 'CV_PISRT' TO COD013-GERAL */
                _.Move("CV_PISRT", W_REGISTRO_SIAS_GERAL.COD013_GERAL);

                /*" -4676- MOVE FIPADOIM-VALOR-IMPOSTO TO W-VALOR-GERAL-VALOR */
                _.Move(FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_VALOR_IMPOSTO, AREA_DE_WORK.W_VALOR_GERAL_X.W_VALOR_GERAL_VALOR);

                /*" -4677- ADD FIPADOIM-VALOR-IMPOSTO TO W-TOTAL-VALORES */
                AREA_DE_WORK.W_TOTAL_VALORES.Value = AREA_DE_WORK.W_TOTAL_VALORES + FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_VALOR_IMPOSTO;

                /*" -4677- MOVE W-VALOR-GERAL-X TO VALO013-GERAL . */
                _.Move(AREA_DE_WORK.W_VALOR_GERAL_X, W_REGISTRO_SIAS_GERAL.VALO013_GERAL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4020_EXIT*/

        [StopWatch]
        /*" R2000-CADASTRAIS-ODS */
        private void R2000_CADASTRAIS_ODS(bool isPerform = false)
        {
            /*" -4779- PERFORM R2000_CADASTRAIS_ODS_DB_SELECT_1 */

            R2000_CADASTRAIS_ODS_DB_SELECT_1();

            /*" -4782- IF SQLCODE EQUAL 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -4783- DISPLAY 'GE368-NUM-PESSOA = ' GE368-NUM-PESSOA */
                _.Display($"GE368-NUM-PESSOA = {GE368.DCLGE_LEG_PESS_EVENTO.GE368_NUM_PESSOA}");

                /*" -4785- MOVE 'ODS' TO W-CHAVE-ORIGEM-CADASTRO. */
                _.Move("ODS", AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO);
            }


            /*" -4786- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -4787- DISPLAY 'SISAP15B - ERRO ACESSO BASE ODS' */
                _.Display($"SISAP15B - ERRO ACESSO BASE ODS");

                /*" -4788- DISPLAY 'SINISTRO ........ ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO ........ {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -4789- DISPLAY 'OCORRHIST ....... ' SINISHIS-OCORR-HISTORICO */
                _.Display($"OCORRHIST ....... {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}");

                /*" -4791- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -4792- IF OD001-IND-PESSOA EQUAL 'F' */

            if (OD001.DCLOD_PESSOA.OD001_IND_PESSOA == "F")
            {

                /*" -4793- MOVE 'PF' TO W-CHAVE-TIPO-PESSOA-PF-PJ */
                _.Move("PF", AREA_DE_WORK.W_CHAVE_TIPO_PESSOA_PF_PJ);

                /*" -4794- ELSE */
            }
            else
            {


                /*" -4795- IF OD001-IND-PESSOA EQUAL 'J' */

                if (OD001.DCLOD_PESSOA.OD001_IND_PESSOA == "J")
                {

                    /*" -4796- MOVE 'PJ' TO W-CHAVE-TIPO-PESSOA-PF-PJ */
                    _.Move("PJ", AREA_DE_WORK.W_CHAVE_TIPO_PESSOA_PF_PJ);

                    /*" -4797- ELSE */
                }
                else
                {


                    /*" -4799- MOVE '??' TO W-CHAVE-TIPO-PESSOA-PF-PJ. */
                    _.Move("??", AREA_DE_WORK.W_CHAVE_TIPO_PESSOA_PF_PJ);
                }

            }


            /*" -4800- MOVE W-NUMERO-CPF-BASE TO W-NUM-CPF-ALFA. */
            _.Move(W_NUMERO_CPF_BASE, AREA_DE_WORK.W_NUM_CPF_ALFA);

            /*" -4802- MOVE W-NUMERO-CNPJ-BASE TO W-NUM-CNPJ-ALFA. */
            _.Move(W_NUMERO_CNPJ_BASE, AREA_DE_WORK.W_NUM_CNPJ_ALFA);

            /*" -4810- IF OD007-COD-CEP(1:1) NOT NUMERIC OR OD007-COD-CEP(2:1) NOT NUMERIC OR OD007-COD-CEP(3:1) NOT NUMERIC OR OD007-COD-CEP(4:1) NOT NUMERIC OR OD007-COD-CEP(5:1) NOT NUMERIC OR OD007-COD-CEP(6:1) NOT NUMERIC OR OD007-COD-CEP(7:1) NOT NUMERIC OR OD007-COD-CEP(8:1) NOT NUMERIC */

            if (!OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_CEP.Substring(1, 1).IsNumeric() || !OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_CEP.Substring(2, 1).IsNumeric() || !OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_CEP.Substring(3, 1).IsNumeric() || !OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_CEP.Substring(4, 1).IsNumeric() || !OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_CEP.Substring(5, 1).IsNumeric() || !OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_CEP.Substring(6, 1).IsNumeric() || !OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_CEP.Substring(7, 1).IsNumeric() || !OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_CEP.Substring(8, 1).IsNumeric())
            {

                /*" -4811- MOVE 99999999 TO OD007-COD-CEP */
                _.Move(99999999, OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_CEP);

                /*" -4812- ELSE */
            }
            else
            {


                /*" -4813- MOVE OD007-COD-CEP TO W-CEP-NUM */
                _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_CEP, AREA_DE_WORK.W_CEP_NUM);

                /*" -4814- MOVE W-CEP-NUMERICO-PARTE1 TO W-CEP-ALFA-PARTE1 */
                _.Move(AREA_DE_WORK.W_CEP_NUMERICO.W_CEP_NUMERICO_PARTE1, AREA_DE_WORK.W_CEP_ALFA.W_CEP_ALFA_PARTE1);

                /*" -4814- MOVE W-CEP-NUMERICO-PARTE2 TO W-CEP-ALFA-PARTE2. */
                _.Move(AREA_DE_WORK.W_CEP_NUMERICO.W_CEP_NUMERICO_PARTE2, AREA_DE_WORK.W_CEP_ALFA.W_CEP_ALFA_PARTE2);
            }


        }

        [StopWatch]
        /*" R2000-CADASTRAIS-ODS-DB-SELECT-1 */
        public void R2000_CADASTRAIS_ODS_DB_SELECT_1()
        {
            /*" -4779- EXEC SQL SELECT H.NUM_APOL_SINISTRO AS 'NUM SINISTRO' , H.OCORR_HISTORICO AS 'OCORRHIST' , H.COD_OPERACAO AS 'OPERACAO' , OPE.FUNCAO_OPERACAO AS 'FUNCAO OPERACAO' , SUBSTR(OPE.DES_OPERACAO,1,30) AS 'NOME OPERACAO' , LEGPES.NUM_OCORR_MOVTO AS 'NUM_OCORR_MOVTO' , LEGPES.NUM_PESSOA AS 'NUM. PESSOA' , PE.IND_PESSOA AS 'TIPO PESSOA' , DIGITS(DECIMAL(PF.NUM_CPF,9,0)) ||DIGITS(DECIMAL(PF.NUM_DV_CPF,2,0)) AS 'CPF DO FAVORECIDO' , SUBSTR(PF.NOM_PESSOA,1,100) AS 'NOME_FAVORECIDO' , 0 AS 'INSCRICAO MUNICIPAL' , 0 AS 'INSCRICAO ESTADUAL' , PF.NUM_INSC_SOCIAL AS 'INSCRICAO SOCIAL' , PF.NUM_DV_INSC_SOCIAL AS 'DV INSCRICAO SOCIAL' , DIGITS(DECIMAL(PJ.NUM_CNPJ,8,0)) ||DIGITS(DECIMAL(PJ.NUM_FILIAL,4,0)) ||DIGITS(DECIMAL(PJ.NUM_DV_CNPJ,2,0)) AS 'CNPJ DO FAVORECIDO' , SUBSTR(PJ.NOM_RAZAO_SOCIAL,1,100) AS 'RAZAO SOCIAL' , PJ.NUM_INSC_MUNICIPAL AS 'INSCRICAO MUNICIPAL' , PJ.NUM_INSC_ESTADUAL AS 'INSCRICAO ESTADUAL' , 0 AS 'INSCRICAO SOCIAL' , 0 AS 'DV INSCRICAO SOCIAL' , PESEND.NOM_LOGRADOURO AS 'LOGRADOURO' , PESEND.DES_NUM_IMOVEL AS 'NUM IMOVEL' , PESEND.DES_COMPL_ENDERECO AS 'COMPLEMENTO' , PESEND.NOM_BAIRRO AS 'BAIRRO' , PESEND.NOM_CIDADE AS 'CIDADE' , PESEND.COD_CEP AS 'CEP' , PESEND.COD_UF AS 'UF' INTO :SINISHIS-NUM-APOL-SINISTRO, :SINISHIS-OCORR-HISTORICO, :SINISHIS-COD-OPERACAO, :GEOPERAC-FUNCAO-OPERACAO, :GEOPERAC-DES-OPERACAO, :GE368-NUM-OCORR-MOVTO, :GE368-NUM-PESSOA, :OD001-IND-PESSOA, :W-NUMERO-CPF-BASE:NULL-NUM-CPF, :OD002-NOM-PESSOA:NULL-NOM-PESSOA, :W-PF-INSC-PREFEITURA:NULL-PF-INSC-PREFEITURA, :W-PF-INSC-ESTADUAL:NULL-PF-INSC-ESTADUAL, :W-PF-NUM-INSC-SOCIAL:NULL-PF-NUM-INSC-SOCIAL, :W-PF-NUM-DV-INSC-SOCIAL:NULL-PF-NUM-DV-INSC-SOCIAL, :W-NUMERO-CNPJ-BASE:NULL-NUM-CNPJ, :OD003-NOM-RAZAO-SOCIAL:NULL-NOM-RAZAO-SOCIAL, :W-PJ-INSC-PREFEITURA:NULL-PJ-INSC-PREFEITURA, :W-PJ-INSC-ESTADUAL:NULL-PJ-INSC-ESTADUAL, :W-PJ-NUM-INSC-SOCIAL:NULL-PJ-NUM-INSC-SOCIAL, :W-PJ-NUM-DV-INSC-SOCIAL:NULL-PJ-NUM-DV-INSC-SOCIAL, :OD007-NOM-LOGRADOURO:NULL-NOM-LOGRADOURO, :OD007-DES-NUM-IMOVEL:NULL-DES-NUM-IMOVEL, :OD007-DES-COMPL-ENDERECO:NULL-DES-COMPL-ENDERECO, :OD007-NOM-BAIRRO:NULL-NOM-BAIRRO, :OD007-NOM-CIDADE:NULL-NOM-CIDADE, :OD007-COD-CEP:NULL-COD-CEP, :OD007-COD-UF:NULL-COD-UF FROM SEGUROS.SINISTRO_HISTORICO H, SEGUROS.GE_OPERACAO OPE, SEGUROS.SI_PESS_SINISTRO SIPES, SEGUROS.GE_LEG_PESS_EVENTO LEGPES LEFT JOIN ODS.OD_PESSOA PE ON PE.NUM_PESSOA = LEGPES.NUM_PESSOA LEFT JOIN ODS.OD_PESSOA_FISICA PF ON PF.NUM_PESSOA = LEGPES.NUM_PESSOA LEFT JOIN ODS.OD_PESSOA_JURIDICA PJ ON PJ.NUM_PESSOA = LEGPES.NUM_PESSOA LEFT JOIN ODS.OD_PESSOA_ENDERECO PESEND ON PESEND.NUM_PESSOA = LEGPES.NUM_PESSOA AND PESEND.SEQ_ENDERECO = LEGPES.SEQ_ENTIDADE WHERE SIPES.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND SIPES.OCORR_HISTORICO = H.OCORR_HISTORICO AND SIPES.COD_OPERACAO = H.COD_OPERACAO AND LEGPES.NUM_OCORR_MOVTO = SIPES.NUM_OCORR_MOVTO AND LEGPES.IND_ENTIDADE = 1 AND OPE.IDE_SISTEMA = 'SI' AND OPE.COD_OPERACAO = H.COD_OPERACAO AND H.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND H.OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND H.COD_PREST_SERVICO <> 891733 AND H.NOME_FAVORECIDO <> 'CAIXA SEGURADORA S A' END-EXEC. */

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
                _.Move(executed_1.OD002_NOM_PESSOA, DCLOD_PESSOA_FISICA.OD002_NOM_PESSOA);
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
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_EXIT*/

        [StopWatch]
        /*" R2010-CADASTRAIS-LOTERICO */
        private void R2010_CADASTRAIS_LOTERICO(bool isPerform = false)
        {
            /*" -4826- IF SINISHIS-COD-OPERACAO NOT EQUAL 1070 AND 1071 AND 1072 AND 1073 AND 1074 AND 1170 AND 1171 AND 1172 AND 1173 AND 1174 AND 1030 AND 1040 AND 4000 */

            if (!SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.In("1070", "1071", "1072", "1073", "1074", "1170", "1171", "1172", "1173", "1174", "1030", "1040", "4000"))
            {

                /*" -4830- GO TO R2010-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2010_EXIT*/ //GOTO
                return;
            }


            /*" -4840- PERFORM R2010_CADASTRAIS_LOTERICO_DB_SELECT_1 */

            R2010_CADASTRAIS_LOTERICO_DB_SELECT_1();

            /*" -4843- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -4845- GO TO R2010-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2010_EXIT*/ //GOTO
                return;
            }


            /*" -4846- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -4847- DISPLAY 'SISAP15B - ERRO ACESSO SINI_LOTERICO01 - 1' */
                _.Display($"SISAP15B - ERRO ACESSO SINI_LOTERICO01 - 1");

                /*" -4851- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -4888- PERFORM R2010_CADASTRAIS_LOTERICO_DB_SELECT_2 */

            R2010_CADASTRAIS_LOTERICO_DB_SELECT_2();

            /*" -4891- IF SQLCODE EQUAL 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -4892- MOVE FORNECED-CGCCPF TO W-NUM-CPF-NUM */
                _.Move(FORNECED.DCLFORNECEDORES.FORNECED_CGCCPF, AREA_DE_WORK.W_NUM_CPF_NUM);

                /*" -4893- MOVE FORNECED-CGCCPF TO W-NUM-CNPJ-NUM */
                _.Move(FORNECED.DCLFORNECEDORES.FORNECED_CGCCPF, AREA_DE_WORK.W_NUM_CNPJ_NUM);

                /*" -4895- MOVE 'FORNECEDOR OU LOTERICO' TO W-CHAVE-ORIGEM-CADASTRO. */
                _.Move("FORNECEDOR OU LOTERICO", AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO);
            }


            /*" -4896- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -4897- DISPLAY 'SISAP15B - ERRO ACESSO SINI_LOTERICO01 - 2' */
                _.Display($"SISAP15B - ERRO ACESSO SINI_LOTERICO01 - 2");

                /*" -4899- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -4900- IF FORNECED-TIPO-PESSOA EQUAL 'F' */

            if (FORNECED.DCLFORNECEDORES.FORNECED_TIPO_PESSOA == "F")
            {

                /*" -4901- MOVE 'PF' TO W-CHAVE-TIPO-PESSOA-PF-PJ */
                _.Move("PF", AREA_DE_WORK.W_CHAVE_TIPO_PESSOA_PF_PJ);

                /*" -4902- ELSE */
            }
            else
            {


                /*" -4903- IF FORNECED-TIPO-PESSOA EQUAL 'J' */

                if (FORNECED.DCLFORNECEDORES.FORNECED_TIPO_PESSOA == "J")
                {

                    /*" -4904- MOVE 'PJ' TO W-CHAVE-TIPO-PESSOA-PF-PJ */
                    _.Move("PJ", AREA_DE_WORK.W_CHAVE_TIPO_PESSOA_PF_PJ);

                    /*" -4905- ELSE */
                }
                else
                {


                    /*" -4907- MOVE '??' TO W-CHAVE-TIPO-PESSOA-PF-PJ. */
                    _.Move("??", AREA_DE_WORK.W_CHAVE_TIPO_PESSOA_PF_PJ);
                }

            }


            /*" -4908- MOVE FORNECED-CEP TO W-CEP-NUM . */
            _.Move(FORNECED.DCLFORNECEDORES.FORNECED_CEP, AREA_DE_WORK.W_CEP_NUM);

            /*" -4909- MOVE W-CEP-NUMERICO-PARTE1 TO W-CEP-ALFA-PARTE1 . */
            _.Move(AREA_DE_WORK.W_CEP_NUMERICO.W_CEP_NUMERICO_PARTE1, AREA_DE_WORK.W_CEP_ALFA.W_CEP_ALFA_PARTE1);

            /*" -4909- MOVE W-CEP-NUMERICO-PARTE2 TO W-CEP-ALFA-PARTE2 . */
            _.Move(AREA_DE_WORK.W_CEP_NUMERICO.W_CEP_NUMERICO_PARTE2, AREA_DE_WORK.W_CEP_ALFA.W_CEP_ALFA_PARTE2);

        }

        [StopWatch]
        /*" R2010-CADASTRAIS-LOTERICO-DB-SELECT-1 */
        public void R2010_CADASTRAIS_LOTERICO_DB_SELECT_1()
        {
            /*" -4840- EXEC SQL SELECT X.NUM_APOL_SINISTRO INTO :SINILT01-NUM-APOL-SINISTRO FROM SEGUROS.SINI_LOTERICO01 X, SEGUROS.SINISTRO_HISTORICO H WHERE H.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND H.OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND H.COD_OPERACAO = :SINISHIS-COD-OPERACAO AND H.COD_PREST_SERVICO = 0 AND X.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO END-EXEC. */

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
            /*" -4888- EXEC SQL SELECT CLI.NOME_RAZAO AS 'NOME DO LOTERICO' , CLI.TIPO_PESSOA AS 'TIPO PESSOA' , CASE CLI.TIPO_PESSOA WHEN 'F' THEN 'PESSOA FISICA  ' WHEN 'J' THEN 'PESSOA JURIDICA' END AS 'TIPO DE PESSOA' , CLI.CGCCPF AS 'CPF / CNPJ DO FAVORECIDO' , LOT.ENDERECO , LOT.BAIRRO , LOT.CIDADE , LOT.CEP , LOT.SIGLA_UF INTO :FORNECED-NOME-FORNECEDOR, :FORNECED-TIPO-PESSOA, :W-NOME-TIPO-PESSOA, :FORNECED-CGCCPF, :FORNECED-ENDERECO, :FORNECED-BAIRRO, :FORNECED-CIDADE, :FORNECED-CEP, :FORNECED-SIGLA-UF FROM SEGUROS.SINI_LOTERICO01 X, SEGUROS.LOTERICO01 LOT, SEGUROS.CLIENTES CLI WHERE X.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND LOT.COD_CLIENTE = X.COD_CLIENTE AND CLI.COD_CLIENTE = X.COD_CLIENTE AND LOT.TIMESTAMP = (SELECT MAX(ZZ.TIMESTAMP) FROM SEGUROS.SINI_LOTERICO01 XX, SEGUROS.LOTERICO01 ZZ WHERE XX.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND ZZ.COD_CLIENTE = XX.COD_CLIENTE ) END-EXEC. */

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
            /*" -4986- PERFORM R2020_CADASTRAIS_FORNECED_DB_SELECT_1 */

            R2020_CADASTRAIS_FORNECED_DB_SELECT_1();

            /*" -4989- IF SQLCODE EQUAL 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -4990- MOVE FORNECED-CGCCPF TO W-NUM-CPF-NUM */
                _.Move(FORNECED.DCLFORNECEDORES.FORNECED_CGCCPF, AREA_DE_WORK.W_NUM_CPF_NUM);

                /*" -4991- MOVE FORNECED-CGCCPF TO W-NUM-CNPJ-NUM */
                _.Move(FORNECED.DCLFORNECEDORES.FORNECED_CGCCPF, AREA_DE_WORK.W_NUM_CNPJ_NUM);

                /*" -4993- MOVE 'FORNECEDOR OU LOTERICO' TO W-CHAVE-ORIGEM-CADASTRO. */
                _.Move("FORNECEDOR OU LOTERICO", AREA_DE_WORK.W_CHAVE_ORIGEM_CADASTRO);
            }


            /*" -4994- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -4995- DISPLAY 'SISAP15B - ERRO ACESSO FORNECEDORES' */
                _.Display($"SISAP15B - ERRO ACESSO FORNECEDORES");

                /*" -4997- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -4998- IF FORNECED-TIPO-PESSOA EQUAL 'F' */

            if (FORNECED.DCLFORNECEDORES.FORNECED_TIPO_PESSOA == "F")
            {

                /*" -4999- MOVE 'PF' TO W-CHAVE-TIPO-PESSOA-PF-PJ */
                _.Move("PF", AREA_DE_WORK.W_CHAVE_TIPO_PESSOA_PF_PJ);

                /*" -5000- ELSE */
            }
            else
            {


                /*" -5001- IF FORNECED-TIPO-PESSOA EQUAL 'J' */

                if (FORNECED.DCLFORNECEDORES.FORNECED_TIPO_PESSOA == "J")
                {

                    /*" -5002- MOVE 'PJ' TO W-CHAVE-TIPO-PESSOA-PF-PJ */
                    _.Move("PJ", AREA_DE_WORK.W_CHAVE_TIPO_PESSOA_PF_PJ);

                    /*" -5003- ELSE */
                }
                else
                {


                    /*" -5005- MOVE '??' TO W-CHAVE-TIPO-PESSOA-PF-PJ. */
                    _.Move("??", AREA_DE_WORK.W_CHAVE_TIPO_PESSOA_PF_PJ);
                }

            }


            /*" -5006- MOVE FORNECED-CEP TO W-CEP-NUM . */
            _.Move(FORNECED.DCLFORNECEDORES.FORNECED_CEP, AREA_DE_WORK.W_CEP_NUM);

            /*" -5007- MOVE W-CEP-NUMERICO-PARTE1 TO W-CEP-ALFA-PARTE1 . */
            _.Move(AREA_DE_WORK.W_CEP_NUMERICO.W_CEP_NUMERICO_PARTE1, AREA_DE_WORK.W_CEP_ALFA.W_CEP_ALFA_PARTE1);

            /*" -5007- MOVE W-CEP-NUMERICO-PARTE2 TO W-CEP-ALFA-PARTE2 . */
            _.Move(AREA_DE_WORK.W_CEP_NUMERICO.W_CEP_NUMERICO_PARTE2, AREA_DE_WORK.W_CEP_ALFA.W_CEP_ALFA_PARTE2);

        }

        [StopWatch]
        /*" R2020-CADASTRAIS-FORNECED-DB-SELECT-1 */
        public void R2020_CADASTRAIS_FORNECED_DB_SELECT_1()
        {
            /*" -4986- EXEC SQL SELECT H.NUM_APOL_SINISTRO AS 'NUM SINISTRO' , H.OCORR_HISTORICO AS 'OCORRHIST' , H.COD_OPERACAO AS 'OPERACAO' , OPE.FUNCAO_OPERACAO AS 'FUNCAO OPERACAO' , SUBSTR(OPE.DES_OPERACAO,1,30) AS 'NOME OPERACAO' , F.TIPO_PESSOA AS 'TIPO PESSOA' , CASE F.TIPO_PESSOA WHEN 'F' THEN 'PESSOA FISICA  ' WHEN 'J' THEN 'PESSOA JURIDICA' END AS 'TIPO DE PESSOA' , F.CGCCPF AS 'CPF / CNPJ DO FAVORECIDO' , F.NOME_FORNECEDOR AS 'NOME FORNECEDOR' , F.INSC_PREFEITURA AS 'INSCRICAO MUNICIPAL' , F.INSC_ESTADUAL AS 'INSCRICAO ESTADUAL' , F.OPT_SIMPLES_FED AS 'OPTANTE SIMPLES FERERAL' , F.OPT_SIMPLES_MUN AS 'OPTANTE SIMPLES MUNICIPAL' , F.ENDERECO AS 'LOGRAD. + NUM IMOVEL + COMPL' , F.BAIRRO AS 'BAIRRO' , F.CIDADE AS 'CIDADE' , F.CEP AS 'CEP' , F.SIGLA_UF AS 'UF' INTO :SINISHIS-NUM-APOL-SINISTRO, :SINISHIS-OCORR-HISTORICO, :SINISHIS-COD-OPERACAO, :GEOPERAC-FUNCAO-OPERACAO, :GEOPERAC-DES-OPERACAO, :FORNECED-TIPO-PESSOA, :W-NOME-TIPO-PESSOA, :FORNECED-CGCCPF, :FORNECED-NOME-FORNECEDOR, :FORNECED-INSC-PREFEITURA, :FORNECED-INSC-ESTADUAL, :FORNECED-OPT-SIMPLES-FED, :FORNECED-OPT-SIMPLES-MUN, :FORNECED-ENDERECO, :FORNECED-BAIRRO, :FORNECED-CIDADE, :FORNECED-CEP, :FORNECED-SIGLA-UF FROM SEGUROS.SINISTRO_HISTORICO H, SEGUROS.GE_OPERACAO OPE, SEGUROS.FORNECEDORES F WHERE NOT EXISTS (SELECT 1 FROM SEGUROS.SI_PESS_SINISTRO SIPES WHERE SIPES.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND SIPES.OCORR_HISTORICO = H.OCORR_HISTORICO AND SIPES.COD_OPERACAO = H.COD_OPERACAO) AND OPE.IDE_SISTEMA = 'SI' AND OPE.COD_OPERACAO = H.COD_OPERACAO AND H.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND H.OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND H.COD_OPERACAO = :SINISHIS-COD-OPERACAO AND H.COD_PREST_SERVICO <> 0 AND F.COD_FORNECEDOR = H.COD_PREST_SERVICO AND F.CGCCPF <> 80000000000 END-EXEC. */

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
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2020_EXIT*/

        [StopWatch]
        /*" R2030-PEGA-NOTA-FISCAL */
        private void R2030_PEGA_NOTA_FISCAL(bool isPerform = false)
        {
            /*" -5027- PERFORM R2030_PEGA_NOTA_FISCAL_DB_SELECT_1 */

            R2030_PEGA_NOTA_FISCAL_DB_SELECT_1();

            /*" -5030- IF SQLCODE EQUAL 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -5031- IF W-CHAVE-EH-PRESTADOR EQUAL 'SIM' */

                if (AREA_DE_WORK.W_CHAVE_EH_PRESTADOR == "SIM")
                {

                    /*" -5032- MOVE 'SIM' TO W-CHAVE-ACHOU-NOTA-FISCAL */
                    _.Move("SIM", AREA_DE_WORK.W_CHAVE_ACHOU_NOTA_FISCAL);

                    /*" -5033- ELSE */
                }
                else
                {


                    /*" -5035- MOVE 'NAO' TO W-CHAVE-ACHOU-NOTA-FISCAL . */
                    _.Move("NAO", AREA_DE_WORK.W_CHAVE_ACHOU_NOTA_FISCAL);
                }

            }


            /*" -5036- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -5037- DISPLAY 'SISAP15B - ERRO ACESSO FI_PAGA_DOC_FISCAL' */
                _.Display($"SISAP15B - ERRO ACESSO FI_PAGA_DOC_FISCAL");

                /*" -5037- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2030-PEGA-NOTA-FISCAL-DB-SELECT-1 */
        public void R2030_PEGA_NOTA_FISCAL_DB_SELECT_1()
        {
            /*" -5027- EXEC SQL SELECT NUM_DOC_FISCAL, SERIE_DOC_FISCAL INTO :FIPADOFI-NUM-DOC-FISCAL, :FIPADOFI-SERIE-DOC-FISCAL FROM SEGUROS.SI_PAGA_DOC_FISCAL X, SEGUROS.FI_PAGA_DOC_FISCAL Y WHERE X.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND X.OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND X.COD_OPERACAO = :SINISHIS-COD-OPERACAO AND Y.NUM_DOCF_INTERNO = X.NUM_DOCF_INTERNO END-EXEC. */

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
                _.Move(executed_1.FIPADOFI_SERIE_DOC_FISCAL, FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_SERIE_DOC_FISCAL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2030_EXIT*/

        [StopWatch]
        /*" R2040-PEGA-SERVICO */
        private void R2040_PEGA_SERVICO(bool isPerform = false)
        {
            /*" -5055- PERFORM R2040_PEGA_SERVICO_DB_SELECT_1 */

            R2040_PEGA_SERVICO_DB_SELECT_1();

            /*" -5058- IF SQLCODE EQUAL 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -5059- IF W-CHAVE-EH-PRESTADOR EQUAL 'SIM' */

                if (AREA_DE_WORK.W_CHAVE_EH_PRESTADOR == "SIM")
                {

                    /*" -5060- MOVE 'SIM' TO W-CHAVE-ACHOU-FORNECEDOR */
                    _.Move("SIM", AREA_DE_WORK.W_CHAVE_ACHOU_FORNECEDOR);

                    /*" -5061- ELSE */
                }
                else
                {


                    /*" -5063- MOVE 'NAO' TO W-CHAVE-ACHOU-FORNECEDOR. */
                    _.Move("NAO", AREA_DE_WORK.W_CHAVE_ACHOU_FORNECEDOR);
                }

            }


            /*" -5064- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -5065- DISPLAY 'SISAP15B - ERRO ACESSO FORNECEDORES (12)' */
                _.Display($"SISAP15B - ERRO ACESSO FORNECEDORES (12)");

                /*" -5065- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2040-PEGA-SERVICO-DB-SELECT-1 */
        public void R2040_PEGA_SERVICO_DB_SELECT_1()
        {
            /*" -5055- EXEC SQL SELECT CEP, COD_SERVICO_ISS INTO :FORNECED-CEP, :FORNECED-COD-SERVICO-ISS FROM SEGUROS.SINISTRO_HISTORICO H, SEGUROS.FORNECEDORES F WHERE H.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND H.OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND H.COD_OPERACAO = :SINISHIS-COD-OPERACAO AND F.COD_FORNECEDOR = H.COD_PREST_SERVICO END-EXEC. */

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
            /*" -5073- MOVE 0 TO CEPFXFIL-FONTE . */
            _.Move(0, CEPFXFIL.DCLCEPFAIXAFILIAL.CEPFXFIL_FONTE);

            /*" -5085- PERFORM R2050_FONTE_RECOLHE_IMPOSTO_DB_SELECT_1 */

            R2050_FONTE_RECOLHE_IMPOSTO_DB_SELECT_1();

            /*" -5089- MOVE 'NAO' TO W-CHAVE-ACHOU-FONTE-IMPOSTO . */
            _.Move("NAO", AREA_DE_WORK.W_CHAVE_ACHOU_FONTE_IMPOSTO);

            /*" -5090- IF SQLCODE EQUAL 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -5091- IF CEPFXFIL-FONTE NOT EQUAL 0 */

                if (CEPFXFIL.DCLCEPFAIXAFILIAL.CEPFXFIL_FONTE != 0)
                {

                    /*" -5092- IF W-CHAVE-EH-PRESTADOR EQUAL 'SIM' */

                    if (AREA_DE_WORK.W_CHAVE_EH_PRESTADOR == "SIM")
                    {

                        /*" -5094- MOVE 'SIM' TO W-CHAVE-ACHOU-FONTE-IMPOSTO. */
                        _.Move("SIM", AREA_DE_WORK.W_CHAVE_ACHOU_FONTE_IMPOSTO);
                    }

                }

            }


            /*" -5095- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -5096- DISPLAY 'SISAP15B - ERRO ACESSO CEPFAIXAFILIAL' */
                _.Display($"SISAP15B - ERRO ACESSO CEPFAIXAFILIAL");

                /*" -5097- DISPLAY 'CEP PESQUISADO = ' FORNECED-CEP */
                _.Display($"CEP PESQUISADO = {FORNECED.DCLFORNECEDORES.FORNECED_CEP}");

                /*" -5097- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2050-FONTE-RECOLHE-IMPOSTO-DB-SELECT-1 */
        public void R2050_FONTE_RECOLHE_IMPOSTO_DB_SELECT_1()
        {
            /*" -5085- EXEC SQL SELECT VALUE(MIN(FONTE),0) INTO :CEPFXFIL-FONTE FROM SEGUROS.CEPFAIXAFILIAL A WHERE A.DATA_INI_VIGENCIA <= :SISTEMAS-DATA-MOV-ABERTO AND A.DATA_TER_VIGENCIA = '9999-12-31' AND A.CEP_INICIAL <= :FORNECED-CEP AND A.CEP_FINAL >= :FORNECED-CEP AND A.COD_EMPRESA = ( SELECT B.COD_EMPRESA FROM SEGUROS.PRODUTO B WHERE B.COD_PRODUTO = :SINISMES-COD-PRODUTO) END-EXEC. */

            var r2050_FONTE_RECOLHE_IMPOSTO_DB_SELECT_1_Query1 = new R2050_FONTE_RECOLHE_IMPOSTO_DB_SELECT_1_Query1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                SINISMES_COD_PRODUTO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO.ToString(),
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
            /*" -5113- IF NULL-NOM-PROGRAMA < 0 */

            if (NULL_NOM_PROGRAMA < 0)
            {

                /*" -5123- GO TO R2060-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2060_EXIT*/ //GOTO
                return;
            }


            /*" -5124- IF SINISHIS-NOM-PROGRAMA EQUAL 'FI0095B' OR 'SI5070B' */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOM_PROGRAMA.In("FI0095B", "SI5070B"))
            {

                /*" -5135- GO TO R2060-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2060_EXIT*/ //GOTO
                return;
            }


            /*" -5136- IF SINISHIS-NOM-PROGRAMA EQUAL 'SI5066B' */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOM_PROGRAMA == "SI5066B")
            {

                /*" -5138- IF W-ATTR-DESTINO EQUAL 'ATTRVAL10-GERAL' */

                if (AREA_DE_WORK.W_ATTR_DESTINO == "ATTRVAL10-GERAL")
                {

                    /*" -5140- MOVE 'SI5066B REPASSE MATC' TO ATTRVAL10-GERAL */
                    _.Move("SI5066B REPASSE MATC", W_REGISTRO_SIAS_GERAL.ATTRVAL10_GERAL);

                    /*" -5141- END-IF */
                }


                /*" -5143- IF W-ATTR-DESTINO EQUAL 'ATTRVAL13-GERAL' */

                if (AREA_DE_WORK.W_ATTR_DESTINO == "ATTRVAL13-GERAL")
                {

                    /*" -5145- MOVE 'SI5066B REPASSE MATC' TO ATTRVAL13-GERAL */
                    _.Move("SI5066B REPASSE MATC", W_REGISTRO_SIAS_GERAL.ATTRVAL13_GERAL);

                    /*" -5146- END-IF */
                }


                /*" -5161- GO TO R2060-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2060_EXIT*/ //GOTO
                return;
            }


            /*" -5162- IF SINISHIS-NOM-PROGRAMA EQUAL 'FI0005B' */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOM_PROGRAMA == "FI0005B")
            {

                /*" -5164- IF W-ATTR-DESTINO EQUAL 'ATTRVAL10-GERAL' */

                if (AREA_DE_WORK.W_ATTR_DESTINO == "ATTRVAL10-GERAL")
                {

                    /*" -5166- MOVE 'FI0005B IND HAB CRED' TO ATTRVAL10-GERAL */
                    _.Move("FI0005B IND HAB CRED", W_REGISTRO_SIAS_GERAL.ATTRVAL10_GERAL);

                    /*" -5167- END-IF */
                }


                /*" -5169- IF W-ATTR-DESTINO EQUAL 'ATTRVAL13-GERAL' */

                if (AREA_DE_WORK.W_ATTR_DESTINO == "ATTRVAL13-GERAL")
                {

                    /*" -5171- MOVE 'FI0005B IND HAB CRED' TO ATTRVAL13-GERAL */
                    _.Move("FI0005B IND HAB CRED", W_REGISTRO_SIAS_GERAL.ATTRVAL13_GERAL);

                    /*" -5172- END-IF */
                }


                /*" -5182- GO TO R2060-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2060_EXIT*/ //GOTO
                return;
            }


            /*" -5183- IF SINISHIS-NOM-PROGRAMA EQUAL 'SI5022B' */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOM_PROGRAMA == "SI5022B")
            {

                /*" -5185- IF W-ATTR-DESTINO EQUAL 'ATTRVAL10-GERAL' */

                if (AREA_DE_WORK.W_ATTR_DESTINO == "ATTRVAL10-GERAL")
                {

                    /*" -5187- MOVE 'SI5022B IND HAB CC L' TO ATTRVAL10-GERAL */
                    _.Move("SI5022B IND HAB CC L", W_REGISTRO_SIAS_GERAL.ATTRVAL10_GERAL);

                    /*" -5188- END-IF */
                }


                /*" -5190- IF W-ATTR-DESTINO EQUAL 'ATTRVAL13-GERAL' */

                if (AREA_DE_WORK.W_ATTR_DESTINO == "ATTRVAL13-GERAL")
                {

                    /*" -5192- MOVE 'SI5022B IND HAB CC L' TO ATTRVAL13-GERAL */
                    _.Move("SI5022B IND HAB CC L", W_REGISTRO_SIAS_GERAL.ATTRVAL13_GERAL);

                    /*" -5193- END-IF */
                }


                /*" -5202- GO TO R2060-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2060_EXIT*/ //GOTO
                return;
            }


            /*" -5203- IF SINISHIS-NOM-PROGRAMA EQUAL 'SI5033B' */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOM_PROGRAMA == "SI5033B")
            {

                /*" -5205- IF W-ATTR-DESTINO EQUAL 'ATTRVAL10-GERAL' */

                if (AREA_DE_WORK.W_ATTR_DESTINO == "ATTRVAL10-GERAL")
                {

                    /*" -5207- MOVE 'SI5033B REPASSE CRED' TO ATTRVAL10-GERAL */
                    _.Move("SI5033B REPASSE CRED", W_REGISTRO_SIAS_GERAL.ATTRVAL10_GERAL);

                    /*" -5208- END-IF */
                }


                /*" -5210- IF W-ATTR-DESTINO EQUAL 'ATTRVAL13-GERAL' */

                if (AREA_DE_WORK.W_ATTR_DESTINO == "ATTRVAL13-GERAL")
                {

                    /*" -5212- MOVE 'SI5033B REPASSE CRED' TO ATTRVAL13-GERAL */
                    _.Move("SI5033B REPASSE CRED", W_REGISTRO_SIAS_GERAL.ATTRVAL13_GERAL);

                    /*" -5213- END-IF */
                }


                /*" -5222- GO TO R2060-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2060_EXIT*/ //GOTO
                return;
            }


            /*" -5223- IF SINISHIS-NOM-PROGRAMA EQUAL 'SI5038B' */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOM_PROGRAMA == "SI5038B")
            {

                /*" -5225- IF W-ATTR-DESTINO EQUAL 'ATTRVAL10-GERAL' */

                if (AREA_DE_WORK.W_ATTR_DESTINO == "ATTRVAL10-GERAL")
                {

                    /*" -5227- MOVE 'SI5038B INDHAB CXCON' TO ATTRVAL10-GERAL */
                    _.Move("SI5038B INDHAB CXCON", W_REGISTRO_SIAS_GERAL.ATTRVAL10_GERAL);

                    /*" -5228- END-IF */
                }


                /*" -5230- IF W-ATTR-DESTINO EQUAL 'ATTRVAL13-GERAL' */

                if (AREA_DE_WORK.W_ATTR_DESTINO == "ATTRVAL13-GERAL")
                {

                    /*" -5232- MOVE 'SI5038B INDHAB CXCON' TO ATTRVAL13-GERAL */
                    _.Move("SI5038B INDHAB CXCON", W_REGISTRO_SIAS_GERAL.ATTRVAL13_GERAL);

                    /*" -5233- END-IF */
                }


                /*" -5242- GO TO R2060-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2060_EXIT*/ //GOTO
                return;
            }


            /*" -5243- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'JBIND' */

            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "JBIND")
            {

                /*" -5244- PERFORM R7777-ACESSA-TIMESTAMP THRU R7777-EXIT */

                R7777_ACESSA_TIMESTAMP(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R7777_EXIT*/


                /*" -5245- MOVE 'JURID IND  ' TO W-AGRUPADOR-LEGENDA */
                _.Move("JURID IND  ", AREA_DE_WORK.W_AGRUPADOR_1.W_AGRUPADOR_LEGENDA);

                /*" -5246- IF W-ATTR-DESTINO EQUAL 'ATTRVAL10-GERAL' */

                if (AREA_DE_WORK.W_ATTR_DESTINO == "ATTRVAL10-GERAL")
                {

                    /*" -5247- MOVE W-AGRUPADOR-1 TO ATTRVAL10-GERAL */
                    _.Move(AREA_DE_WORK.W_AGRUPADOR_1, W_REGISTRO_SIAS_GERAL.ATTRVAL10_GERAL);

                    /*" -5248- END-IF */
                }


                /*" -5249- IF W-ATTR-DESTINO EQUAL 'ATTRVAL13-GERAL' */

                if (AREA_DE_WORK.W_ATTR_DESTINO == "ATTRVAL13-GERAL")
                {

                    /*" -5250- MOVE W-AGRUPADOR-1 TO ATTRVAL13-GERAL */
                    _.Move(AREA_DE_WORK.W_AGRUPADOR_1, W_REGISTRO_SIAS_GERAL.ATTRVAL13_GERAL);

                    /*" -5251- END-IF */
                }


                /*" -5255- GO TO R2060-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2060_EXIT*/ //GOTO
                return;
            }


            /*" -5256- IF GEOPERAC-FUNCAO-OPERACAO EQUAL 'JBDP' */

            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO == "JBDP")
            {

                /*" -5257- IF SINISHIS-COD-OPERACAO EQUAL 8111 */

                if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO == 8111)
                {

                    /*" -5258- PERFORM R7777-ACESSA-TIMESTAMP THRU R7777-EXIT */

                    R7777_ACESSA_TIMESTAMP(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R7777_EXIT*/


                    /*" -5259- MOVE 'JUR TUTELA ' TO W-AGRUPADOR-LEGENDA */
                    _.Move("JUR TUTELA ", AREA_DE_WORK.W_AGRUPADOR_1.W_AGRUPADOR_LEGENDA);

                    /*" -5260- IF W-ATTR-DESTINO EQUAL 'ATTRVAL10-GERAL' */

                    if (AREA_DE_WORK.W_ATTR_DESTINO == "ATTRVAL10-GERAL")
                    {

                        /*" -5261- MOVE W-AGRUPADOR-1 TO ATTRVAL10-GERAL */
                        _.Move(AREA_DE_WORK.W_AGRUPADOR_1, W_REGISTRO_SIAS_GERAL.ATTRVAL10_GERAL);

                        /*" -5262- END-IF */
                    }


                    /*" -5263- IF W-ATTR-DESTINO EQUAL 'ATTRVAL13-GERAL' */

                    if (AREA_DE_WORK.W_ATTR_DESTINO == "ATTRVAL13-GERAL")
                    {

                        /*" -5264- MOVE W-AGRUPADOR-1 TO ATTRVAL13-GERAL */
                        _.Move(AREA_DE_WORK.W_AGRUPADOR_1, W_REGISTRO_SIAS_GERAL.ATTRVAL13_GERAL);

                        /*" -5265- END-IF */
                    }


                    /*" -5266- GO TO R2060-EXIT */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2060_EXIT*/ //GOTO
                    return;

                    /*" -5267- ELSE */
                }
                else
                {


                    /*" -5268- PERFORM R7777-ACESSA-TIMESTAMP THRU R7777-EXIT */

                    R7777_ACESSA_TIMESTAMP(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R7777_EXIT*/


                    /*" -5269- MOVE 'JUR DEPOSI ' TO W-AGRUPADOR-LEGENDA */
                    _.Move("JUR DEPOSI ", AREA_DE_WORK.W_AGRUPADOR_1.W_AGRUPADOR_LEGENDA);

                    /*" -5270- IF W-ATTR-DESTINO EQUAL 'ATTRVAL10-GERAL' */

                    if (AREA_DE_WORK.W_ATTR_DESTINO == "ATTRVAL10-GERAL")
                    {

                        /*" -5271- MOVE W-AGRUPADOR-1 TO ATTRVAL10-GERAL */
                        _.Move(AREA_DE_WORK.W_AGRUPADOR_1, W_REGISTRO_SIAS_GERAL.ATTRVAL10_GERAL);

                        /*" -5272- END-IF */
                    }


                    /*" -5273- IF W-ATTR-DESTINO EQUAL 'ATTRVAL13-GERAL' */

                    if (AREA_DE_WORK.W_ATTR_DESTINO == "ATTRVAL13-GERAL")
                    {

                        /*" -5274- MOVE W-AGRUPADOR-1 TO ATTRVAL13-GERAL */
                        _.Move(AREA_DE_WORK.W_AGRUPADOR_1, W_REGISTRO_SIAS_GERAL.ATTRVAL13_GERAL);

                        /*" -5275- END-IF */
                    }


                    /*" -5280- GO TO R2060-EXIT. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2060_EXIT*/ //GOTO
                    return;
                }

            }


            /*" -5282- IF GEOPERAC-FUNCAO-OPERACAO EQUAL ( 'IND' OR 'LIB' )AND (SINISMES-RAMO EQUAL 31 OR 53 OR 20) */

            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO.In("IND", "LIB") && (SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO.In("31", "53", "20")))
            {

                /*" -5283- PERFORM R7777-ACESSA-TIMESTAMP THRU R7777-EXIT */

                R7777_ACESSA_TIMESTAMP(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R7777_EXIT*/


                /*" -5284- MOVE 'AUTOMOVEL  ' TO W-AGRUPADOR-LEGENDA */
                _.Move("AUTOMOVEL  ", AREA_DE_WORK.W_AGRUPADOR_1.W_AGRUPADOR_LEGENDA);

                /*" -5285- IF W-ATTR-DESTINO EQUAL 'ATTRVAL10-GERAL' */

                if (AREA_DE_WORK.W_ATTR_DESTINO == "ATTRVAL10-GERAL")
                {

                    /*" -5286- MOVE W-AGRUPADOR-1 TO ATTRVAL10-GERAL */
                    _.Move(AREA_DE_WORK.W_AGRUPADOR_1, W_REGISTRO_SIAS_GERAL.ATTRVAL10_GERAL);

                    /*" -5287- END-IF */
                }


                /*" -5288- IF W-ATTR-DESTINO EQUAL 'ATTRVAL13-GERAL' */

                if (AREA_DE_WORK.W_ATTR_DESTINO == "ATTRVAL13-GERAL")
                {

                    /*" -5289- MOVE W-AGRUPADOR-1 TO ATTRVAL13-GERAL */
                    _.Move(AREA_DE_WORK.W_AGRUPADOR_1, W_REGISTRO_SIAS_GERAL.ATTRVAL13_GERAL);

                    /*" -5290- END-IF */
                }


                /*" -5290- GO TO R2060-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2060_EXIT*/ //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2060_EXIT*/

        [StopWatch]
        /*" R7777-ACESSA-TIMESTAMP */
        private void R7777_ACESSA_TIMESTAMP(bool isPerform = false)
        {
            /*" -5301- PERFORM R7777_ACESSA_TIMESTAMP_DB_SELECT_1 */

            R7777_ACESSA_TIMESTAMP_DB_SELECT_1();

            /*" -5304- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -5305- DISPLAY 'SISAP02B - ERRO NO ACESSO TIMESTAMP - R7777' */
                _.Display($"SISAP02B - ERRO NO ACESSO TIMESTAMP - R7777");

                /*" -5307- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -5308- MOVE HOST-CURRENT-TIMESTAMP(18:9) TO W-AGRUPADOR-MINUTO-SSSSSS. */
            _.Move(HOST_CURRENT_TIMESTAMP.Substring(18, 9), AREA_DE_WORK.W_AGRUPADOR_1.W_AGRUPADOR_MINUTO_SSSSSS);

        }

        [StopWatch]
        /*" R7777-ACESSA-TIMESTAMP-DB-SELECT-1 */
        public void R7777_ACESSA_TIMESTAMP_DB_SELECT_1()
        {
            /*" -5301- EXEC SQL SELECT CURRENT TIMESTAMP INTO :HOST-CURRENT-TIMESTAMP FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'FI' WITH UR END-EXEC. */

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
        /*" RXXXX-ROTINA-RETORNO */
        private void RXXXX_ROTINA_RETORNO(bool isPerform = false)
        {
            /*" -5317- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: RXXXX_EXIT*/
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_CLOSE_ARQUIVOS*/
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_EXIT*/

        [StopWatch]
        /*" R19000-GE0300B-GRAVA-CONTROLES */
        private void R19000_GE0300B_GRAVA_CONTROLES(bool isPerform = false)
        {
            /*" -5341- INITIALIZE REGISTRO-LINKAGE-GE0300B. */
            _.Initialize(
                REGISTRO_LINKAGE_GE0300B
            );

            /*" -5343- MOVE MOVDEBCE-NUM-APOLICE TO LK-GE0300B-NUM-APOLICE . */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE, REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NUM_APOLICE);

            /*" -5345- MOVE MOVDEBCE-NUM-ENDOSSO TO LK-GE0300B-NUM-ENDOSSO . */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO, REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NUM_ENDOSSO);

            /*" -5347- MOVE MOVDEBCE-NUM-PARCELA TO LK-GE0300B-NUM-PARCELA . */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA, REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NUM_PARCELA);

            /*" -5349- MOVE MOVDEBCE-COD-CONVENIO TO LK-GE0300B-COD-CONVENIO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO, REGISTRO_LINKAGE_GE0300B.LK_GE0300B_COD_CONVENIO);

            /*" -5351- MOVE MOVDEBCE-NSAS TO LK-GE0300B-NSAS. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS, REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NSAS);

            /*" -5352- MOVE 1 TO LK-GE0300B-FUNCAO */
            _.Move(1, REGISTRO_LINKAGE_GE0300B.LK_GE0300B_FUNCAO);

            /*" -5353- MOVE W-IDLG-SIAS-SINISTRO TO LK-GE0300B-IDLG */
            _.Move(AREA_DE_WORK.W_IDLG_SIAS_SINISTRO, REGISTRO_LINKAGE_GE0300B.LK_GE0300B_IDLG);

            /*" -5354- MOVE HOST-SI-DATA-MOV-ABERTO TO LK-GE0300B-DATA-MOV-ABERTO */
            _.Move(HOST_SI_DATA_MOV_ABERTO, REGISTRO_LINKAGE_GE0300B.LK_GE0300B_DATA_MOV_ABERTO);

            /*" -5364- MOVE 'SI' TO LK-GE0300B-IDE-SISTEMA */
            _.Move("SI", REGISTRO_LINKAGE_GE0300B.LK_GE0300B_IDE_SISTEMA);

            /*" -5366- MOVE 4 TO LK-GE0300B-NUM-ESTRUTURA */
            _.Move(4, REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NUM_ESTRUTURA);

            /*" -5367- MOVE MOVDEBCE-NUM-APOLICE TO LK-GE0300B-NUM-APOLICE . */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE, REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NUM_APOLICE);

            /*" -5368- MOVE MOVDEBCE-NUM-ENDOSSO TO LK-GE0300B-NUM-ENDOSSO . */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO, REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NUM_ENDOSSO);

            /*" -5369- MOVE MOVDEBCE-NUM-PARCELA TO LK-GE0300B-NUM-PARCELA . */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA, REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NUM_PARCELA);

            /*" -5370- MOVE MOVDEBCE-COD-CONVENIO TO LK-GE0300B-COD-CONVENIO . */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO, REGISTRO_LINKAGE_GE0300B.LK_GE0300B_COD_CONVENIO);

            /*" -5374- MOVE MOVDEBCE-NSAS TO LK-GE0300B-NSAS . */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS, REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NSAS);

            /*" -5379- MOVE LK-SAP-CHR-USO-EMPRESA TO LK-GE0300B-CHR-USO-EMPRESA. */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_CHR_USO_EMPRESA, REGISTRO_LINKAGE_GE0300B.LK_GE0300B_CHR_USO_EMPRESA);

            /*" -5381- MOVE W-REGISTRO-SIAS-GERAL TO LK-GE0300B-REGISTRO . */
            _.Move(W_REGISTRO_SIAS_GERAL, REGISTRO_LINKAGE_GE0300B.LK_GE0300B_REGISTRO);

            /*" -5387- CALL 'GE0300B' USING REGISTRO-LINKAGE-GE0300B. */
            _.Call("GE0300B", REGISTRO_LINKAGE_GE0300B);

            /*" -5388- IF LK-GE0300B-COD-RETORNO NOT EQUAL '0' */

            if (REGISTRO_LINKAGE_GE0300B.LK_GE0300B_COD_RETORNO != "0")
            {

                /*" -5389- DISPLAY ' ' */
                _.Display($" ");

                /*" -5390- DISPLAY ' ' */
                _.Display($" ");

                /*" -5391- DISPLAY '************************************************' */
                _.Display($"************************************************");

                /*" -5392- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -5393- DISPLAY '*            PROGRAMA - SISAP15B               *' */
                _.Display($"*            PROGRAMA - SISAP15B               *");

                /*" -5394- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -5395- DISPLAY '*   ERRO NA EXECUCAO DO CALL DA GE0330B        *' */
                _.Display($"*   ERRO NA EXECUCAO DO CALL DA GE0330B        *");

                /*" -5396- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -5397- DISPLAY '************************************************' */
                _.Display($"************************************************");

                /*" -5398- DISPLAY ' ' */
                _.Display($" ");

                /*" -5399- DISPLAY '=> LK-GE0300B-MENSAGEM .. ' LK-GE0300B-MENSAGEM */
                _.Display($"=> LK-GE0300B-MENSAGEM .. {REGISTRO_LINKAGE_GE0300B.LK_GE0300B_MENSAGEM}");

                /*" -5400- DISPLAY ' ' */
                _.Display($" ");

                /*" -5401- MOVE '1' TO LK-SAP-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE_SAP.LK_SAP_COD_RETORNO);

                /*" -5402- MOVE LK-GE0300B-MENSAGEM TO LK-SAP-MENSAGEM-RETORNO */
                _.Move(REGISTRO_LINKAGE_GE0300B.LK_GE0300B_MENSAGEM, REGISTRO_LINKAGE_SAP.LK_SAP_MENSAGEM_RETORNO);

                /*" -5402- GOBACK. */

                throw new GoBack();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R19000_EXIT*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO */
        private void R9999_00_ROT_ERRO(bool isPerform = false)
        {
            /*" -5415- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -5417- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -5420- DISPLAY 'SISAP15B - RETORNO PELA ROTINA DE ERRO ' */
            _.Display($"SISAP15B - RETORNO PELA ROTINA DE ERRO ");

            /*" -5420- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -5424- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -5425- MOVE '1' TO LK-SAP-COD-RETORNO. */
            _.Move("1", REGISTRO_LINKAGE_SAP.LK_SAP_COD_RETORNO);

            /*" -5428- MOVE 'PROBLEMA NA SISAP15B - VEJA DISPLAYS' TO LK-SAP-MENSAGEM-RETORNO. */
            _.Move("PROBLEMA NA SISAP15B - VEJA DISPLAYS", REGISTRO_LINKAGE_SAP.LK_SAP_MENSAGEM_RETORNO);

            /*" -5428- GOBACK. */

            throw new GoBack();

        }

        [StopWatch]
        /*" R8888-DISPLAY-FETCH */
        private void R8888_DISPLAY_FETCH(bool isPerform = false)
        {
            /*" -5434- DISPLAY ' => DISPLAY DO FETCH DO DECLARE PRINCIPAL' */
            _.Display($" => DO FETCH DO DECLARE PRINCIPAL");

            /*" -5436- DISPLAY 'W-NOME-QUERY ..................... ' W-NOME-QUERY */
            _.Display($"W-NOME-QUERY ..................... {W_NOME_QUERY}");

            /*" -5438- DISPLAY 'SINISHIS-TIPO-REGISTRO ........... ' SINISHIS-TIPO-REGISTRO */
            _.Display($"SINISHIS-TIPO-REGISTRO ........... {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_TIPO_REGISTRO}");

            /*" -5440- DISPLAY 'W-NOME-TIPO-SEGURO ............... ' W-NOME-TIPO-SEGURO */
            _.Display($"W-NOME-TIPO-SEGURO ............... {W_NOME_TIPO_SEGURO}");

            /*" -5442- DISPLAY 'SINISHIS-NUM-APOL-SINISTRO ....... ' SINISHIS-NUM-APOL-SINISTRO */
            _.Display($"SINISHIS-NUM-APOL-SINISTRO ....... {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

            /*" -5444- DISPLAY 'SINISHIS-OCORR-HISTORICO ......... ' SINISHIS-OCORR-HISTORICO */
            _.Display($"SINISHIS-OCORR-HISTORICO ......... {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}");

            /*" -5446- DISPLAY 'SINISHIS-COD-OPERACAO  ........... ' SINISHIS-COD-OPERACAO */
            _.Display($"SINISHIS-COD-OPERACAO  ........... {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO}");

            /*" -5448- DISPLAY 'SINISHIS-NOME-FAVORECIDO ......... ' SINISHIS-NOME-FAVORECIDO */
            _.Display($"SINISHIS-NOME-FAVORECIDO ......... {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO}");

            /*" -5450- DISPLAY 'GEOPERAC-FUNCAO-OPERACAO ......... ' GEOPERAC-FUNCAO-OPERACAO */
            _.Display($"GEOPERAC-FUNCAO-OPERACAO ......... {GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO}");

            /*" -5452- DISPLAY 'GEOPERAC-DES-OPERACAO  ............ ' GEOPERAC-DES-OPERACAO */
            _.Display($"GEOPERAC-DES-OPERACAO  ............ {GEOPERAC.DCLGE_OPERACAO.GEOPERAC_DES_OPERACAO}");

            /*" -5454- DISPLAY 'W-ANO-OPERACIONAL-MOVIMENTO ....... ' W-ANO-OPERACIONAL-MOVIMENTO */
            _.Display($"W-ANO-OPERACIONAL-MOVIMENTO ....... {W_ANO_OPERACIONAL_MOVIMENTO}");

            /*" -5456- DISPLAY 'W-ANO-CONTABIL-MOVIMENTO  ......... ' W-ANO-CONTABIL-MOVIMENTO */
            _.Display($"W-ANO-CONTABIL-MOVIMENTO  ......... {W_ANO_CONTABIL_MOVIMENTO}");

            /*" -5458- DISPLAY 'SINISHIS-VAL-OPERACAO  ............ ' SINISHIS-VAL-OPERACAO */
            _.Display($"SINISHIS-VAL-OPERACAO  ............ {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO}");

            /*" -5460- DISPLAY 'MOVDEBCE-VLR-CREDITO  ............. ' MOVDEBCE-VLR-CREDITO */
            _.Display($"MOVDEBCE-VLR-CREDITO  ............. {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_CREDITO}");

            /*" -5462- DISPLAY 'MOVDEBCE-VALOR-DEBITO  ............ ' MOVDEBCE-VALOR-DEBITO */
            _.Display($"MOVDEBCE-VALOR-DEBITO  ............ {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO}");

            /*" -5464- DISPLAY 'SINISHIS-DATA-MOVIMENTO  .......... ' SINISHIS-DATA-MOVIMENTO */
            _.Display($"SINISHIS-DATA-MOVIMENTO  .......... {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO}");

            /*" -5466- DISPLAY 'SINISHIS-COD-PREST-SERVICO ........ ' SINISHIS-COD-PREST-SERVICO */
            _.Display($"SINISHIS-COD-PREST-SERVICO ........ {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO}");

            /*" -5468- DISPLAY 'SINISHIS-SIT-CONTABIL  ............ ' SINISHIS-SIT-CONTABIL */
            _.Display($"SINISHIS-SIT-CONTABIL  ............ {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL}");

            /*" -5470- DISPLAY 'W-NOME-FORMA-PAGAMENTO  ............ ' W-NOME-FORMA-PAGAMENTO */
            _.Display($"W-NOME-FORMA-PAGAMENTO  ............ {W_NOME_FORMA_PAGAMENTO}");

            /*" -5472- DISPLAY 'SINISHIS-NOM-PROGRAMA  ............. ' SINISHIS-NOM-PROGRAMA */
            _.Display($"SINISHIS-NOM-PROGRAMA  ............. {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOM_PROGRAMA}");

            /*" -5474- DISPLAY 'SINISMES-RAMO  ..................... ' SINISMES-RAMO */
            _.Display($"SINISMES-RAMO  ..................... {SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO}");

            /*" -5476- DISPLAY 'SINISMES-COD-FONTE ................. ' SINISMES-COD-FONTE */
            _.Display($"SINISMES-COD-FONTE ................. {SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE}");

            /*" -5478- DISPLAY 'W-DATA-AVISO-SIAS  ................. ' W-DATA-AVISO-SIAS */
            _.Display($"W-DATA-AVISO-SIAS  ................. {W_DATA_AVISO_SIAS}");

            /*" -5480- DISPLAY 'SINISMES-DATA-COMUNICADO  .......... ' SINISMES-DATA-COMUNICADO */
            _.Display($"SINISMES-DATA-COMUNICADO  .......... {SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_COMUNICADO}");

            /*" -5482- DISPLAY 'SINISMES-COD-PRODUTO  .............. ' SINISMES-COD-PRODUTO */
            _.Display($"SINISMES-COD-PRODUTO  .............. {SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO}");

            /*" -5484- DISPLAY 'PRODUTO-DESCR-PRODUTO  ............. ' PRODUTO-DESCR-PRODUTO */
            _.Display($"PRODUTO-DESCR-PRODUTO  ............. {PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO}");

            /*" -5486- DISPLAY 'CHEQUEMI-NUM-CHEQUE-INTERNO ........ ' CHEQUEMI-NUM-CHEQUE-INTERNO */
            _.Display($"CHEQUEMI-NUM-CHEQUE-INTERNO ........ {CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NUM_CHEQUE_INTERNO}");

            /*" -5488- DISPLAY 'MOVDEBCE-NUM-APOLICE  .............. ' MOVDEBCE-NUM-APOLICE */
            _.Display($"MOVDEBCE-NUM-APOLICE  .............. {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE}");

            /*" -5490- DISPLAY 'MOVDEBCE-NUM-ENDOSSO  .............. ' MOVDEBCE-NUM-ENDOSSO */
            _.Display($"MOVDEBCE-NUM-ENDOSSO  .............. {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO}");

            /*" -5492- DISPLAY 'MOVDEBCE-NUM-PARCELA  .............. ' MOVDEBCE-NUM-PARCELA */
            _.Display($"MOVDEBCE-NUM-PARCELA  .............. {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA}");

            /*" -5494- DISPLAY 'MOVDEBCE-SITUACAO-COBRANCA  ........ ' MOVDEBCE-SITUACAO-COBRANCA */
            _.Display($"MOVDEBCE-SITUACAO-COBRANCA  ........ {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA}");

            /*" -5496- DISPLAY 'W-NOME-SITUACAO-COBRANCA  .......... ' W-NOME-SITUACAO-COBRANCA */
            _.Display($"W-NOME-SITUACAO-COBRANCA  .......... {W_NOME_SITUACAO_COBRANCA}");

            /*" -5498- DISPLAY 'MOVDEBCE-DATA-VENCIMENTO  .......... ' MOVDEBCE-DATA-VENCIMENTO */
            _.Display($"MOVDEBCE-DATA-VENCIMENTO  .......... {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO}");

            /*" -5500- DISPLAY 'MOVDEBCE-DATA-MOVIMENTO ............ ' MOVDEBCE-DATA-MOVIMENTO */
            _.Display($"MOVDEBCE-DATA-MOVIMENTO ............ {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO}");

            /*" -5502- DISPLAY 'MOVDEBCE-COD-AGENCIA-DEB ........... ' MOVDEBCE-COD-AGENCIA-DEB */
            _.Display($"MOVDEBCE-COD-AGENCIA-DEB ........... {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB}");

            /*" -5504- DISPLAY 'MOVDEBCE-OPER-CONTA-DEB  ........... ' MOVDEBCE-OPER-CONTA-DEB */
            _.Display($"MOVDEBCE-OPER-CONTA-DEB  ........... {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB}");

            /*" -5506- DISPLAY 'MOVDEBCE-NUM-CONTA-DEB  ............ ' MOVDEBCE-NUM-CONTA-DEB */
            _.Display($"MOVDEBCE-NUM-CONTA-DEB  ............ {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB}");

            /*" -5508- DISPLAY 'MOVDEBCE-DIG-CONTA-DEB  ............ ' MOVDEBCE-DIG-CONTA-DEB */
            _.Display($"MOVDEBCE-DIG-CONTA-DEB  ............ {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB}");

            /*" -5510- DISPLAY 'MOVDEBCE-COD-CONVENIO  ............. ' MOVDEBCE-COD-CONVENIO */
            _.Display($"MOVDEBCE-COD-CONVENIO  ............. {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO}");

            /*" -5512- DISPLAY 'MOVDEBCE-DATA-ENVIO  ............... ' MOVDEBCE-DATA-ENVIO */
            _.Display($"MOVDEBCE-DATA-ENVIO  ............... {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_ENVIO}");

            /*" -5514- DISPLAY 'MOVDEBCE-NSAS  ..................... ' MOVDEBCE-NSAS */
            _.Display($"MOVDEBCE-NSAS  ..................... {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS}");

            /*" -5516- DISPLAY 'MOVDEBCE-NUM-REQUISICAO  ........... ' MOVDEBCE-NUM-REQUISICAO */
            _.Display($"MOVDEBCE-NUM-REQUISICAO  ........... {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO}");

            /*" -5518- DISPLAY 'GE369-COD-AGENCIA .................. ' GE369-COD-AGENCIA */
            _.Display($"GE369-COD-AGENCIA .................. {GE369.DCLGE_MOVTO_CONTA.GE369_COD_AGENCIA}");

            /*" -5520- DISPLAY 'NULL-COD-AGENCIA  .................. ' NULL-COD-AGENCIA */
            _.Display($"NULL-COD-AGENCIA  .................. {NULL_COD_AGENCIA}");

            /*" -5522- DISPLAY 'GE369-COD-BANCO  ................... ' GE369-COD-BANCO */
            _.Display($"GE369-COD-BANCO  ................... {GE369.DCLGE_MOVTO_CONTA.GE369_COD_BANCO}");

            /*" -5524- DISPLAY 'NULL-COD-BANCO  .................... ' NULL-COD-BANCO */
            _.Display($"NULL-COD-BANCO  .................... {NULL_COD_BANCO}");

            /*" -5526- DISPLAY 'GE369-NUM-CONTA-CNB ................ ' GE369-NUM-CONTA-CNB */
            _.Display($"GE369-NUM-CONTA-CNB ................ {GE369.DCLGE_MOVTO_CONTA.GE369_NUM_CONTA_CNB}");

            /*" -5528- DISPLAY 'NULL-NUM-CONTA-CNB ................. ' NULL-NUM-CONTA-CNB */
            _.Display($"NULL-NUM-CONTA-CNB ................. {NULL_NUM_CONTA_CNB}");

            /*" -5530- DISPLAY 'GE369-NUM-DV-CONTA-CNB ............. ' GE369-NUM-DV-CONTA-CNB */
            _.Display($"GE369-NUM-DV-CONTA-CNB ............. {GE369.DCLGE_MOVTO_CONTA.GE369_NUM_DV_CONTA_CNB}");

            /*" -5532- DISPLAY 'NULL-NUM-DV-CONTA-CNB .............. ' NULL-NUM-DV-CONTA-CNB */
            _.Display($"NULL-NUM-DV-CONTA-CNB .............. {NULL_NUM_DV_CONTA_CNB}");

            /*" -5534- DISPLAY 'GE369-IND-CONTA-BANCARIA ........... ' GE369-IND-CONTA-BANCARIA */
            _.Display($"GE369-IND-CONTA-BANCARIA ........... {GE369.DCLGE_MOVTO_CONTA.GE369_IND_CONTA_BANCARIA}");

            /*" -5535- DISPLAY 'NULL-IND-CONTA-BANCARIA ............ ' NULL-IND-CONTA-BANCARIA . */
            _.Display($"NULL-IND-CONTA-BANCARIA ............ {NULL_IND_CONTA_BANCARIA}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8888_EXIT*/

        [StopWatch]
        /*" R8889-DISPLAY-IMPOSTOS */
        private void R8889_DISPLAY_IMPOSTOS(bool isPerform = false)
        {
            /*" -5543- DISPLAY 'SINISHIS-NUM-APOL-SINISTRO .......... ' SINISHIS-NUM-APOL-SINISTRO */
            _.Display($"SINISHIS-NUM-APOL-SINISTRO .......... {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

            /*" -5545- DISPLAY 'SINISHIS-OCORR-HISTORICO   .......... ' SINISHIS-OCORR-HISTORICO */
            _.Display($"SINISHIS-OCORR-HISTORICO   .......... {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}");

            /*" -5547- DISPLAY 'SINISHIS-COD-OPERACAO  .......... ' SINISHIS-COD-OPERACAO */
            _.Display($"SINISHIS-COD-OPERACAO  .......... {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO}");

            /*" -5549- DISPLAY 'SIPADOFI-NUM-DOCF-INTERNO .......... ' SIPADOFI-NUM-DOCF-INTERNO */
            _.Display($"SIPADOFI-NUM-DOCF-INTERNO .......... {SIPADOFI.DCLSI_PAGA_DOC_FISCAL.SIPADOFI_NUM_DOCF_INTERNO}");

            /*" -5551- DISPLAY 'FIPADOLA-COD-TP-LANCDOCF .......... ' FIPADOLA-COD-TP-LANCDOCF */
            _.Display($"FIPADOLA-COD-TP-LANCDOCF .......... {FIPADOLA.DCLFI_PAGA_DOCF_LANC.FIPADOLA_COD_TP_LANCDOCF}");

            /*" -5553- DISPLAY 'GETPLADO-ABREV-LANCDOCF .......... ' GETPLADO-ABREV-LANCDOCF */
            _.Display($"GETPLADO-ABREV-LANCDOCF .......... {GETPLADO.DCLGE_TP_LANC_DOCF.GETPLADO_ABREV_LANCDOCF}");

            /*" -5555- DISPLAY 'FIPADOLA-VALOR-LANCAMENTO .......... ' FIPADOLA-VALOR-LANCAMENTO */
            _.Display($"FIPADOLA-VALOR-LANCAMENTO .......... {FIPADOLA.DCLFI_PAGA_DOCF_LANC.FIPADOLA_VALOR_LANCAMENTO}");

            /*" -5557- DISPLAY 'GETIPIMP-COD-IMP-INTERNO .......... ' GETIPIMP-COD-IMP-INTERNO */
            _.Display($"GETIPIMP-COD-IMP-INTERNO .......... {GETIPIMP.DCLGE_TIPO_IMPOSTO.GETIPIMP_COD_IMP_INTERNO}");

            /*" -5559- DISPLAY 'GETIPIMP-SIGLA-IMP .......... ' GETIPIMP-SIGLA-IMP */
            _.Display($"GETIPIMP-SIGLA-IMP .......... {GETIPIMP.DCLGE_TIPO_IMPOSTO.GETIPIMP_SIGLA_IMP}");

            /*" -5561- DISPLAY 'FIPADOIM-ALIQ-TRIBUTACAO .......... ' FIPADOIM-ALIQ-TRIBUTACAO */
            _.Display($"FIPADOIM-ALIQ-TRIBUTACAO .......... {FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_ALIQ_TRIBUTACAO}");

            /*" -5562- DISPLAY 'FIPADOIM-VALOR-IMPOSTO  .......... ' FIPADOIM-VALOR-IMPOSTO . */
            _.Display($"FIPADOIM-VALOR-IMPOSTO  .......... {FIPADOIM.DCLFI_PAGA_DOCF_IMP.FIPADOIM_VALOR_IMPOSTO}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8889_EXIT*/
    }
}