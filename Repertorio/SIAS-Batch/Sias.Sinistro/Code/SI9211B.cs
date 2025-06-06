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
using Sias.Sinistro.DB2.SI9211B;

namespace Code
{
    public class SI9211B
    {
        public bool IsCall { get; set; }

        public SI9211B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SINISTROS                          *      */
        /*"      *   PROGRAMA ...............  SI9211B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  BRSEG                              *      */
        /*"      *   PROGRAMADOR.............  BRSEG                              *      */
        /*"      *   DATA CODIFICACAO .......  ABRIL/2011                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  GERA ARQUIVO DE RETORNO DE         *      */
        /*"      *                             PAGAMENTOS DE SINISTRO DE AUTO     *      */
        /*"      *                             SULAMERICA                         *      */
        /*"      *                            (COPIA PROGRAMA SI9111B)            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"SAS01 *   VERSAO PROJAUTO (SULAMERICA) - BRSEG 30/05/2011              *      */
        /*"SAS01 *   - TRATA STA-PROCESSAMENTO 'P'                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   NO   VERSAO    DATA       PROGRAMADOR           ALTERACAO    *      */
        /*"      *                                                                *      */
        /*"      *   1.     1.0    01/04/2003  HEIDER                             *      */
        /*"      *                                                                *      */
        /*"      *   2.     2.0    13/08/2009  PATRICIA SALES        PROCURE V.02 *      */
        /*"      *                                                                *      */
        /*"      *   FOI RETIRADO DO PROGRAMA O CAMPO DET-FILLER, POIS O BOOK     *      */
        /*"      *   LBVCMOSI FOI ATUALIZADO EM PRODUCAO EM 25/06/2009 EXCLUINDO  *      */
        /*"      *   ESTE CAMPO.                                                  *      */
        /*"      *                                                                *      */
        /*"      *   3.     3.0    20/08/2009  PATRICIA SALES        PROCURE V.03 *      */
        /*"      *                                                                *      */
        /*"      *   A PARTIR DESTA DATA ESTA SENDO EXCLUIDO DO DECLARE PRINCIPAL *      */
        /*"      *   AS OCORRENCIAS COM VALOR ZERADO TENDO EM VISTA QUE NAO E GERA*      */
        /*"      *   DO CHEQUE INTERNO.                                           *      */
        /*"      *                                                                *      */
        /*"      *   4.     4.0    06/04/2010  alcione araujo        PROCURE V.04 *      */
        /*"      *                                                                *      */
        /*"      *   5.     5.0    08/09/2010 16:54   CELIA SILVA     CADMUS 47310*      */
        /*"      *          INCLUIDO EXISTS NO CURSOR PRINCIPAL                   *      */
        /*"      *                                                                *      */
        /*"      *   INSERIDO UM CONDICAO TEMPORARIA PARA TRATAR ABEND DO SINISTRO*      */
        /*"      *   1003100063370.                                                      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO CADMUS 24207 :  AGOSTO/2009 - BRSEG                *      */
        /*"      *   PROJETO SINISTRO JUDICIAL/RESSARCIMENTO                      *      */
        /*"      *   - INLCLUIDOS NO ARQUIVO RETORNO OS NOVOS CAMPOS DE SINISTRO  *      */
        /*"      *     JUDICIAL E RESSARCIMENTO (VER C24207).                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *    ALTERACAO CADMUS 1234  :  JANEIRO/2010 - BRSEG              *      */
        /*"      * 1- REMO��O DAS SEGUINTES CONSIST�NCIAS EFETUADAS SOBRE A DATA  *      */
        /*"      *    DE EMISSAO DO CHEQUE:                                       *      */
        /*"      *                                                                *      */
        /*"      * A) O PROGRAMA N�O CANCELARA MAIS QUANDO A DATA DE EMISSAO FOR  *      */
        /*"      *    NULA.                                                       *      */
        /*"      * B) O PROGRAMA IRA PROCESSAR NORMALMENTE OS SINISTROS C/ DATAS  *      */
        /*"      *    DE EMISSAO DO CHEQUE PREENCHIDAS COM '9999-12-31'.          *      */
        /*"      *                                                                *      */
        /*"      * 2- QUANDO O TIPO DE PAGTO FOR IGUAL A '1' E O NUMERO DO CHEQUE *      */
        /*"      *    EXTERNO FOR IGUAL A ZEROS SERA FORMATO NESTE CAMPO O        *      */
        /*"      *    N�MERO DO CHEQUE INTERNO.                                   *      */
        /*"      *                                                                *      */
        /*"      *       PROCURAR POR AC0111                                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   6.     6.0    21/01/2011 11:08   OLIVEIRA     CADMUS ABEND   *      */
        /*"      *          INCLUIDO TRATAMENTO SQLCODE = 100                     *      */
        /*"      *                                                                *      */
        /*"      *   ROTINA R11000-ACESSA-CHEQUE-EXTERNO           PROCURE: ALTS  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   PROJAUTO - 10/04/2011 - VANDO - VER: PRJ.01                  *      */
        /*"      *                           ATENDIMENTO AO NOVO CONVENIO         *      */
        /*"      *                           AUTO SULAMERICA.                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   CAD67086 - 22/03/2011 - COREON - PROCURAR POR CORE01         *      */
        /*"      *                           P/ OS PAGAMENTOS ATRAVES DE CREDITO  *      */
        /*"      *                           EM C/C RETORNADOS COM SUCESSO        *      */
        /*"      *                           FORMATAR A DATA NEGOCIADA COM A DATA *      */
        /*"      *                           DE VENCIMENTO DA TABELA MOVDEBCE.    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   CADMUS 78133 - 18/01/2013 - GUILHERME CORREIA                *      */
        /*"      *                                                                *      */
        /*"      *   PARA OS ESTORNOS FEITOS VIA SIAS MANUALMENTE O PROGRAMA ESTA *      */
        /*"      *   SE COMPORTANDO COMO SE HOUVESSE CANCELAMENTO, POR ISSO QUANDO*      */
        /*"      *   HA UM ESTORNO O PROGRAMA ESTA GERANDO ARQUIVO DE PAGAMENTO E *      */
        /*"      *   ATUALIZANDO A STA-PROCESSAMENTO PARA 5.                      *      */
        /*"      *                                                                *      */
        /*"      *   FOI FEITO UM AJUSTE PARA VERIFICAR SE FOI FEITO UM ESTORNO   *      */
        /*"      *   CASO TENHA SIDO FEITO A STA-PROCESSAMENTO FICA COM O VALOR 3 *      */
        /*"      *   CASO NAO TENHA, O PROGRAMA PERMANECE COMO ESTA.              *      */
        /*"      *                                                                *      */
        /*"      *                                        PROCURAR V.05           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ABEND  103002- 12/09/2014 - DIEGO DIAS                       *      */
        /*"      *                                                                *      */
        /*"      *   AJUSTE NA BUSCA DE INFORMA��ES NAT TABELA DE MOVTO_DEBITOCC  *      */
        /*"      *   PARA CORRIGIR DUPLICIDADE OCASIONADA POR GRAVACAO NO EM8005B *      */
        /*"      *   POR PARTE DO EF MOVIMENTANDO CONTRATO PARA CAMPO NUM_CARTAO  *      */
        /*"      *   CASO : CHEQUE = 7790120 *                                           */
        /*"      *----------------------------------------------------------------*      */
        /*"V.06  *   27/03/2015 ALTERADO POR LISIANE PARA ATENDER CADMUS 112976   *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"V.07  *  -10/04/2015 ALTERADO POR: DIEGO DIAS.         CADMUS 106574   *      */
        /*"      *                                                                *      */
        /*"      * RECOMANDO DE PAGAMENTO: ENVIAR CASOS QUE FORAM RECOMANDADOS    *      */
        /*"      * PARA PAGAMENTO, PELA APLIC. SIZMA - PARA CASOS DE 'PT' AUTO    *      */
        /*"      * ONDE O RETORNO COM SUCESSO NAO ESTA SENDO ENVIADO PARA SULAMERI*      */
        /*"      *-CA, QUANDO RETORNADO COM STA-PROCESSAMENTO = 'R'               *      */
        /*"      *                                                   VERSAO: V.07 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 08 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 29/06/2015 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.08         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.09  *   VERSAO 09 - CADMUS 138499                                    *      */
        /*"      *               - ALTERACAO NA REGRA DA BAIXA DE INDENIZACAO DE  *      */
        /*"      *  SINISTRO 'OP 1001'. ANTES ERA GERADO A BAIXA NO MOMENTO DE    *      */
        /*"      *  ENVIO PARA O SAP, GERANDO DIFERENCA NO CONTABIL E FINANCEIRO  *      */
        /*"      *  PARA OS CASOS QUE VOLTAVAM COM INSUCESSO, VISTO QUE JA CONSTA-*      */
        /*"      *  VAM COMO PAGOS, ASSIM ERA NECESSARIO GERAR ESTORNO P/ SAS.    *      */
        /*"      *  AGORA PASSA A ENVIAR P/ PGTO COM A OPERACAO CORRETA 1081      *      */
        /*"      *  E GERA 1001 SOMENTE NO RETORNO COM SUCESSO DE PAGAMENTO DO    *      */
        /*"      *  BANCO, RETIRANDO A NECESSIDADE DE GERAR ESTORNO PARA CASOS    *      */
        /*"      *  COM INSUCESSO.   (EXCETO CHEQUE)                              *      */
        /*"      *  - GERA OPERACAO  1001 - BAIXA DE PAGTO DE INDENIZACAO(PGTO OK)*      */
        /*"      *                                                                *      */
        /*"      *   EM 31/08/2016 - DIEGO DIAS                                   *      */
        /*"      *                                       PROCURE POR V.09         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.10  *   VERSAO 10 - CADMUS 150314                                    *      */
        /*"      *               - AJUSTE DA RESERVA NEGATIVA                     *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/06/2017 - RILDO SICO                                   *      */
        /*"      *                                       PROCURE POR V.10         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.11  *   VERSAO 11     - PROJETO REINF                                *      */
        /*"V.11  *                   INCLUIR OS CAMPOS DO REINF NO ARQUIVO DE     *      */
        /*"V.11  *                   RETORNO                                      *      */
        /*"V.11  *   EM 21/02/2018 - DOUGLAS ARAUJO - ATOS                        *      */
        /*"V.11  *                                                                *      */
        /*"V.11  *                                       PROCURE POR V.11         *      */
        /*"v.11  *----------------------------------------------------------------*      */
        /*"V.12  *   VERSAO 12     - ABEND 168226                                 *      */
        /*"      *                   CORRIGIR GRAVACAO DO COD_OPERACAO NA TABELA  *      */
        /*"      *                   SINI_CHEQUE, O MESMO EST� COM OPERACAO 112   *      */
        /*"      *                   INDEVIDO. EXEMPLO: SINI: 1105300172048 OCOR:4*      */
        /*"      *   EM 28/07/2018 - DIEGO DIAS / INDRA                           *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.12         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.13  *   VERSAO 13     - ABEND 409390 e 409684                        *      */
        /*"      *                 - CORRIGIR GRAVACAO DA OP 1001, SERA FEITA     *      */
        /*"      *                   PELA APLICACAO SICP100B, BEM COMO AJUSTE DO  *      */
        /*"      *                   PENDENTE.                                    *      */
        /*"      *   EM 25/07/2022 - HERVAL SOUZA.                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _CSPAGSIN { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis CSPAGSIN
        {
            get
            {
                _.Move(REG_SCMOVSIN, _CSPAGSIN); VarBasis.RedefinePassValue(REG_SCMOVSIN, _CSPAGSIN, REG_SCMOVSIN); return _CSPAGSIN;
            }
        }
        /*"01       REG-SCMOVSIN.*/
        public SI9211B_REG_SCMOVSIN REG_SCMOVSIN { get; set; } = new SI9211B_REG_SCMOVSIN();
        public class SI9211B_REG_SCMOVSIN : VarBasis
        {
            /*"  05     SCMOVSIN-HEADER.*/
            public SI9211B_SCMOVSIN_HEADER SCMOVSIN_HEADER { get; set; } = new SI9211B_SCMOVSIN_HEADER();
            public class SI9211B_SCMOVSIN_HEADER : VarBasis
            {
                /*"    10   HDR-TIPO-REGISTRO           PIC  X(001).*/
                public StringBasis HDR_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10   HDR-NOME-ARQUIVO            PIC  X(008).*/
                public StringBasis HDR_NOME_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"    10   HDR-NOME-CONVENIADA         PIC  X(030).*/
                public StringBasis HDR_NOME_CONVENIADA { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"    10   HDR-COD-ORIGEM-ARQUIVO      PIC  9(004).*/
                public IntBasis HDR_COD_ORIGEM_ARQUIVO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10   HDR-DT-GERACAO              PIC  X(010).*/
                public StringBasis HDR_DT_GERACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10   HDR-NUM-SEQ-ARQUIVO         PIC  9(006).*/
                public IntBasis HDR_NUM_SEQ_ARQUIVO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10   HDR-IND-PROCESSAMENTO       PIC  X(001).*/
                public StringBasis HDR_IND_PROCESSAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10   HDR-MENSAGEM-RETORNO        PIC  X(100).*/
                public StringBasis HDR_MENSAGEM_RETORNO { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
                /*"    10   HDR-RUBRICA-ARQUIVO         PIC  X(010).*/
                public StringBasis HDR_RUBRICA_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10   HDR-FILLER                  PIC  X(1569).*/
                public StringBasis HDR_FILLER { get; set; } = new StringBasis(new PIC("X", "1569", "X(1569)."), @"");
                /*"    10   HDR-NUM-SEQ-REGISTRO        PIC  9(006).*/
                public IntBasis HDR_NUM_SEQ_REGISTRO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"  05     SCMOVSIN-DADOS              REDEFINES   SCMOVSIN-HEADER.*/
            }
            private _REDEF_SI9211B_SCMOVSIN_DADOS _scmovsin_dados { get; set; }
            public _REDEF_SI9211B_SCMOVSIN_DADOS SCMOVSIN_DADOS
            {
                get { _scmovsin_dados = new _REDEF_SI9211B_SCMOVSIN_DADOS(); _.Move(SCMOVSIN_HEADER, _scmovsin_dados); VarBasis.RedefinePassValue(SCMOVSIN_HEADER, _scmovsin_dados, SCMOVSIN_HEADER); _scmovsin_dados.ValueChanged += () => { _.Move(_scmovsin_dados, SCMOVSIN_HEADER); }; return _scmovsin_dados; }
                set { VarBasis.RedefinePassValue(value, _scmovsin_dados, SCMOVSIN_HEADER); }
            }  //Redefines
            public class _REDEF_SI9211B_SCMOVSIN_DADOS : VarBasis
            {
                /*"    10   DET-TIPO-REGISTRO           PIC  X(001).*/
                public StringBasis DET_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10   DET-NUM-SINISTRO-CXSEG      PIC  9(013).*/
                public IntBasis DET_NUM_SINISTRO_CXSEG { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    10   DET-COD-OPERACAO            PIC  9(004).*/
                public IntBasis DET_COD_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10   DET-NUM-OCORR-HISTORICO     PIC  9(004).*/
                public IntBasis DET_NUM_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10   DET-NUM-SINISTRO-VC         PIC  X(030).*/
                public StringBasis DET_NUM_SINISTRO_VC { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"    10   DET-NUM-EXPEDIENTE-VC       PIC  9(002).*/
                public IntBasis DET_NUM_EXPEDIENTE_VC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10   DET-NUM-APOLICE             PIC  9(013).*/
                public IntBasis DET_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    10   DET-NUM-ENDOSSO             PIC  9(009).*/
                public IntBasis DET_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10   DET-NUM-ITEM                PIC  9(009).*/
                public IntBasis DET_NUM_ITEM { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10   DET-COD-RAMO                PIC  9(004).*/
                public IntBasis DET_COD_RAMO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10   DET-COD-COBERTURA           PIC  9(004).*/
                public IntBasis DET_COD_COBERTURA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10   DET-COD-CAUSA               PIC  9(002).*/
                public IntBasis DET_COD_CAUSA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10   DET-FONTE-SINISTRO          PIC  9(003).*/
                public IntBasis DET_FONTE_SINISTRO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10   DET-NUM-PROTOCOLO-SINI      PIC  9(009).*/
                public IntBasis DET_NUM_PROTOCOLO_SINI { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10   DET-DT-COMUNICADO           PIC  X(010).*/
                public StringBasis DET_DT_COMUNICADO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10   DET-DT-OCORRENCIA           PIC  X(010).*/
                public StringBasis DET_DT_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10   DET-HORA-OCORRENCIA         PIC  X(008).*/
                public StringBasis DET_HORA_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"    10   DET-DT-MOVIMENTO            PIC  X(010).*/
                public StringBasis DET_DT_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10   DET-IND-TIPO-FAVORECIDO     PIC  X(001).*/
                public StringBasis DET_IND_TIPO_FAVORECIDO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10   DET-VAL-TOTAL-MOVIMENTO     PIC  9(013)V99.*/
                public DoubleBasis DET_VAL_TOTAL_MOVIMENTO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10   DET-VAL-PECAS               PIC  9(013)V99.*/
                public DoubleBasis DET_VAL_PECAS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10   DET-VAL-MAO-OBRA            PIC  9(013)V99.*/
                public DoubleBasis DET_VAL_MAO_OBRA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10   DET-VAL-PARCELA-PEND        PIC  9(013)V99.*/
                public DoubleBasis DET_VAL_PARCELA_PEND { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10   DET-QTD-PARCELA-PEND        PIC  9(002).*/
                public IntBasis DET_QTD_PARCELA_PEND { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10   DET-VAL-DESC-PARCELA-PEND   PIC  9(013)V99.*/
                public DoubleBasis DET_VAL_DESC_PARCELA_PEND { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10   DET-DT-NEGOCIADA-PAGTO      PIC  X(010).*/
                public StringBasis DET_DT_NEGOCIADA_PAGTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10   DET-VAL-IRRF                PIC  9(013)V99.*/
                public DoubleBasis DET_VAL_IRRF { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10   DET-VAL-ISS                 PIC  9(013)V99.*/
                public DoubleBasis DET_VAL_ISS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10   DET-VAL-INSS                PIC  9(013)V99.*/
                public DoubleBasis DET_VAL_INSS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10   DET-VAL-LIQUIDO-PAGO        PIC  9(013)V99.*/
                public DoubleBasis DET_VAL_LIQUIDO_PAGO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10   DET-CNPJ-CPF-FAVORECIDO     PIC  9(015).*/
                public IntBasis DET_CNPJ_CPF_FAVORECIDO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"    10   DET-NOME-FAVORECIDO         PIC  X(040).*/
                public StringBasis DET_NOME_FAVORECIDO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    10   DET-IND-TIPO-DOC-FISCAL     PIC  X(001).*/
                public StringBasis DET_IND_TIPO_DOC_FISCAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10   DET-NUM-DOC-FISCAL          PIC  9(009).*/
                public IntBasis DET_NUM_DOC_FISCAL { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10   DET-SERIE-DOC-FISCAL        PIC  X(006).*/
                public StringBasis DET_SERIE_DOC_FISCAL { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
                /*"    10   DET-DT-EMISSAO-DOC          PIC  X(010).*/
                public StringBasis DET_DT_EMISSAO_DOC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10   DET-ENDERECO                PIC  X(080).*/
                public StringBasis DET_ENDERECO { get; set; } = new StringBasis(new PIC("X", "80", "X(080)."), @"");
                /*"    10   DET-NOM-BAIRRO              PIC  X(040).*/
                public StringBasis DET_NOM_BAIRRO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    10   DET-NOM-CIDADE              PIC  X(060).*/
                public StringBasis DET_NOM_CIDADE { get; set; } = new StringBasis(new PIC("X", "60", "X(060)."), @"");
                /*"    10   DET-NOM-SIGLA-UF            PIC  X(002).*/
                public StringBasis DET_NOM_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    10   DET-CEP.*/
                public SI9211B_DET_CEP DET_CEP { get; set; } = new SI9211B_DET_CEP();
                public class SI9211B_DET_CEP : VarBasis
                {
                    /*"         15  DET-NUM-CEP             PIC  9(008).*/
                    public IntBasis DET_NUM_CEP { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"    10   DET-NUM-DDD                 PIC  9(002).*/

                    public SI9211B_DET_CEP()
                    {
                        DET_NUM_CEP.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis DET_NUM_DDD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10   DET-NUM-TELEFONE            PIC  9(008).*/
                public IntBasis DET_NUM_TELEFONE { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    10   DET-IND-FORMA-PAGTO         PIC  X(001).*/
                public StringBasis DET_IND_FORMA_PAGTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10   DET-NUM-IDENTIFICADOR-PAGTO PIC  9(015).*/
                public IntBasis DET_NUM_IDENTIFICADOR_PAGTO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"    10   DET-NUM-CHEQUE-INTERNO      PIC  9(009).*/
                public IntBasis DET_NUM_CHEQUE_INTERNO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10   DET-NUM-OP-VC               PIC  9(015).*/
                public IntBasis DET_NUM_OP_VC { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"    10   DET-NUM-OP-CXSEG            PIC  9(009).*/
                public IntBasis DET_NUM_OP_CXSEG { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10   DET-COD-BANCO               PIC  9(003).*/
                public IntBasis DET_COD_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10   DET-COD-AGENCIA             PIC  9(004).*/
                public IntBasis DET_COD_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10   DET-COD-OPERACAO-CONTA-CEF  PIC  9(004).*/
                public IntBasis DET_COD_OPERACAO_CONTA_CEF { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10   DET-NUM-CONTA-BANCARIA      PIC  X(015).*/
                public StringBasis DET_NUM_CONTA_BANCARIA { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                /*"    10   DET-DV-CONTA                PIC  X(001).*/
                public StringBasis DET_DV_CONTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10   DET-IND-PROCESSAMENTO       PIC  X(001).*/
                public StringBasis DET_IND_PROCESSAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10   DET-MENSAGEM-RETORNO        PIC  X(100).*/
                public StringBasis DET_MENSAGEM_RETORNO { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
                /*"    10   DET-COD-FAVORECIDO          PIC  9(009).*/
                public IntBasis DET_COD_FAVORECIDO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10   DET-TIPO-PESSOA             PIC  X(001).*/
                public StringBasis DET_TIPO_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10   DET-VAL-PISPASEP            PIC  9(010)V99.*/
                public DoubleBasis DET_VAL_PISPASEP { get; set; } = new DoubleBasis(new PIC("9", "10", "9(010)V99."), 2);
                /*"    10   DET-VAL-COFINS              PIC  9(010)V99.*/
                public DoubleBasis DET_VAL_COFINS { get; set; } = new DoubleBasis(new PIC("9", "10", "9(010)V99."), 2);
                /*"    10   DET-VAL-CSLL                PIC  9(010)V99.*/
                public DoubleBasis DET_VAL_CSLL { get; set; } = new DoubleBasis(new PIC("9", "10", "9(010)V99."), 2);
                /*"    10   DET-SERIE-CHEQUE            PIC  X(003).*/
                public StringBasis DET_SERIE_CHEQUE { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"    10   DET-IDENT-PAGTO-EDITADO     PIC  X(019).*/
                public StringBasis DET_IDENT_PAGTO_EDITADO { get; set; } = new StringBasis(new PIC("X", "19", "X(019)."), @"");
                /*"    10   DET-MARCA-MODELO            PIC  X(090).*/
                public StringBasis DET_MARCA_MODELO { get; set; } = new StringBasis(new PIC("X", "90", "X(090)."), @"");
                /*"    10   DET-PLACA                   PIC  X(007).*/
                public StringBasis DET_PLACA { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
                /*"    10   DET-CHASSIS                 PIC  X(020).*/
                public StringBasis DET_CHASSIS { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"    10   DET-ANO-VEICULO             PIC  9(004).*/
                public IntBasis DET_ANO_VEICULO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10   DET-CIRCULAR-200.*/
                public SI9211B_DET_CIRCULAR_200 DET_CIRCULAR_200 { get; set; } = new SI9211B_DET_CIRCULAR_200();
                public class SI9211B_DET_CIRCULAR_200 : VarBasis
                {
                    /*"      15 DET-NATUREZA-DOCTO          PIC  X(020).*/
                    public StringBasis DET_NATUREZA_DOCTO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                    /*"      15 DET-NUM-IDENTIDADE          PIC  X(015).*/
                    public StringBasis DET_NUM_IDENTIDADE { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                    /*"      15 DET-ORGAO-EXPEDIDOR         PIC  X(005).*/
                    public StringBasis DET_ORGAO_EXPEDIDOR { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                    /*"      15 DET-DATA-EXPEDICAO          PIC  X(010).*/
                    public StringBasis DET_DATA_EXPEDICAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                    /*"      15 DET-UF-EXPEDIDORA           PIC  X(002).*/
                    public StringBasis DET_UF_EXPEDIDORA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"      15 DET-ATIVIDADE-PRINCIPAL     PIC  9(004).*/
                    public IntBasis DET_ATIVIDADE_PRINCIPAL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"    10   DET-CIRCULAR-255.*/

                    public SI9211B_DET_CIRCULAR_200()
                    {
                        DET_NATUREZA_DOCTO.ValueChanged += OnValueChanged;
                        DET_NUM_IDENTIDADE.ValueChanged += OnValueChanged;
                        DET_ORGAO_EXPEDIDOR.ValueChanged += OnValueChanged;
                        DET_DATA_EXPEDICAO.ValueChanged += OnValueChanged;
                        DET_UF_EXPEDIDORA.ValueChanged += OnValueChanged;
                        DET_ATIVIDADE_PRINCIPAL.ValueChanged += OnValueChanged;
                    }

                }
                public SI9211B_DET_CIRCULAR_255 DET_CIRCULAR_255 { get; set; } = new SI9211B_DET_CIRCULAR_255();
                public class SI9211B_DET_CIRCULAR_255 : VarBasis
                {
                    /*"      15 DET-DATA-ULT-DOCTO          PIC  X(010).*/
                    public StringBasis DET_DATA_ULT_DOCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                    /*"    10   DET-NUM-RESSARC             PIC  9(009).*/

                    public SI9211B_DET_CIRCULAR_255()
                    {
                        DET_DATA_ULT_DOCTO.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis DET_NUM_RESSARC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10   DET-IND-PESSOA-ACORDO       PIC  X(001).*/
                public StringBasis DET_IND_PESSOA_ACORDO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10   DET-NUM-CPFCGC-ACORDO       PIC  9(015).*/
                public IntBasis DET_NUM_CPFCGC_ACORDO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"    10   DET-NOM-RESP-ACORDO         PIC  X(040).*/
                public StringBasis DET_NOM_RESP_ACORDO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    10   DET-STA-ACORDO              PIC  X(001).*/
                public StringBasis DET_STA_ACORDO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10   DET-DTH-INDENIZACAO         PIC  X(010).*/
                public StringBasis DET_DTH_INDENIZACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10   DET-VLR-INDENIZACAO         PIC  9(013)V99.*/
                public DoubleBasis DET_VLR_INDENIZACAO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10   DET-VLR-PART-TERCEIROS      PIC  9(013)V99.*/
                public DoubleBasis DET_VLR_PART_TERCEIROS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10   DET-VLR-DIVIDA              PIC  9(013)V99.*/
                public DoubleBasis DET_VLR_DIVIDA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10   DET-PCT-DESCONTO            PIC  9(003)V9(04).*/
                public DoubleBasis DET_PCT_DESCONTO { get; set; } = new DoubleBasis(new PIC("9", "3", "9(003)V9(04)."), 4);
                /*"    10   DET-VLR-TOTAL-DESCONTO      PIC  9(013)V99.*/
                public DoubleBasis DET_VLR_TOTAL_DESCONTO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10   DET-VLR-TOTAL-ACORDO        PIC  9(013)V99.*/
                public DoubleBasis DET_VLR_TOTAL_ACORDO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10   DET-COD-MOEDA-ACORDO        PIC  9(004).*/
                public IntBasis DET_COD_MOEDA_ACORDO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10   DET-DTH-ACORDO              PIC  X(010).*/
                public StringBasis DET_DTH_ACORDO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10   DET-QTD-PARCELAS-ACORDO     PIC  9(004).*/
                public IntBasis DET_QTD_PARCELAS_ACORDO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10   DET-NUM-PARCELA-ACORDO      PIC  9(004).*/
                public IntBasis DET_NUM_PARCELA_ACORDO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10   DET-COD-AGENCIA-CEDENT      PIC  9(004).*/
                public IntBasis DET_COD_AGENCIA_CEDENT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10   DET-NUM-CEDENTE             PIC  9(013).*/
                public IntBasis DET_NUM_CEDENTE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    10   DET-NUM-CEDENTE-DV          PIC  X(001).*/
                public StringBasis DET_NUM_CEDENTE_DV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10   DET-DTH-VENCIMENTO          PIC  X(010).*/
                public StringBasis DET_DTH_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10   DET-NUM-NOSSO-TITULO        PIC  9(018).*/
                public IntBasis DET_NUM_NOSSO_TITULO { get; set; } = new IntBasis(new PIC("9", "18", "9(018)."));
                /*"    10   DET-VLR-TITULO              PIC  9(013)V99.*/
                public DoubleBasis DET_VLR_TITULO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10   DET-NUM-CPFCGC-RECLAMANTE   PIC  9(015).*/
                public IntBasis DET_NUM_CPFCGC_RECLAMANTE { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"    10   DET-NOM-RECLAMANTE          PIC  X(040).*/
                public StringBasis DET_NOM_RECLAMANTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    10   DET-VLR-RECLAMADO           PIC  9(013)V99.*/
                public DoubleBasis DET_VLR_RECLAMADO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10   DET-VLR-PROVISIONADO        PIC  9(013)V99.*/
                public DoubleBasis DET_VLR_PROVISIONADO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10   DET-NUM-IDENT-CONV          PIC  9(015).*/
                public IntBasis DET_NUM_IDENT_CONV { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"    10   DET-NUM-IDENT-PAGTO         PIC  9(015).*/
                public IntBasis DET_NUM_IDENT_PAGTO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"    10   DET-COD-IDLG                PIC  X(040).*/
                public StringBasis DET_COD_IDLG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    10   DET-CFOP                    PIC  9(015).*/
                public IntBasis DET_CFOP { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"    10   DET-CEST                    PIC  9(012).*/
                public IntBasis DET_CEST { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"    10   DET-INSC-EST                PIC  9(015).*/
                public IntBasis DET_INSC_EST { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"    10   DET-NCM                     PIC  9(012).*/
                public IntBasis DET_NCM { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"    10   DET-CNPJ-FILIAL             PIC  9(018).*/
                public IntBasis DET_CNPJ_FILIAL { get; set; } = new IntBasis(new PIC("9", "18", "9(018)."));
                /*"    10   DET-IND-RET-IMP             PIC  X(001).*/
                public StringBasis DET_IND_RET_IMP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10   DET-COD-IMP-LIM             PIC  9(002).*/
                public IntBasis DET_COD_IMP_LIM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10   DET-COD-PROC-PJDT           PIC  X(021).*/
                public StringBasis DET_COD_PROC_PJDT { get; set; } = new StringBasis(new PIC("X", "21", "X(021)."), @"");
                /*"    10   DET-VLR-RET-PRINC           PIC  9(016).*/
                public IntBasis DET_VLR_RET_PRINC { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
                /*"    10   DET-COD-PIS                 PIC  9(014).*/
                public IntBasis DET_COD_PIS { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                /*"    10   DET-COD-CPF                 PIC  9(015).*/
                public IntBasis DET_COD_CPF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"    10   DET-NOME                    PIC  X(060).*/
                public StringBasis DET_NOME { get; set; } = new StringBasis(new PIC("X", "60", "X(060)."), @"");
                /*"    10   DET-DATA-NASC               PIC  X(010).*/
                public StringBasis DET_DATA_NASC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10   DET-CBO                     PIC  X(006).*/
                public StringBasis DET_CBO { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
                /*"    10   DET-NACIONALIDADE           PIC  X(060).*/
                public StringBasis DET_NACIONALIDADE { get; set; } = new StringBasis(new PIC("X", "60", "X(060)."), @"");
                /*"    10   DET-PAIS-NASC               PIC  X(060).*/
                public StringBasis DET_PAIS_NASC { get; set; } = new StringBasis(new PIC("X", "60", "X(060)."), @"");
                /*"    10   DET-NUM-SEQ-REGISTRO        PIC  9(006).*/
                public IntBasis DET_NUM_SEQ_REGISTRO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"  05     SCMOVSIN-TRAILLER           REDEFINES   SCMOVSIN-HEADER.*/

                public _REDEF_SI9211B_SCMOVSIN_DADOS()
                {
                    DET_TIPO_REGISTRO.ValueChanged += OnValueChanged;
                    DET_NUM_SINISTRO_CXSEG.ValueChanged += OnValueChanged;
                    DET_COD_OPERACAO.ValueChanged += OnValueChanged;
                    DET_NUM_OCORR_HISTORICO.ValueChanged += OnValueChanged;
                    DET_NUM_SINISTRO_VC.ValueChanged += OnValueChanged;
                    DET_NUM_EXPEDIENTE_VC.ValueChanged += OnValueChanged;
                    DET_NUM_APOLICE.ValueChanged += OnValueChanged;
                    DET_NUM_ENDOSSO.ValueChanged += OnValueChanged;
                    DET_NUM_ITEM.ValueChanged += OnValueChanged;
                    DET_COD_RAMO.ValueChanged += OnValueChanged;
                    DET_COD_COBERTURA.ValueChanged += OnValueChanged;
                    DET_COD_CAUSA.ValueChanged += OnValueChanged;
                    DET_FONTE_SINISTRO.ValueChanged += OnValueChanged;
                    DET_NUM_PROTOCOLO_SINI.ValueChanged += OnValueChanged;
                    DET_DT_COMUNICADO.ValueChanged += OnValueChanged;
                    DET_DT_OCORRENCIA.ValueChanged += OnValueChanged;
                    DET_HORA_OCORRENCIA.ValueChanged += OnValueChanged;
                    DET_DT_MOVIMENTO.ValueChanged += OnValueChanged;
                    DET_IND_TIPO_FAVORECIDO.ValueChanged += OnValueChanged;
                    DET_VAL_TOTAL_MOVIMENTO.ValueChanged += OnValueChanged;
                    DET_VAL_PECAS.ValueChanged += OnValueChanged;
                    DET_VAL_MAO_OBRA.ValueChanged += OnValueChanged;
                    DET_VAL_PARCELA_PEND.ValueChanged += OnValueChanged;
                    DET_QTD_PARCELA_PEND.ValueChanged += OnValueChanged;
                    DET_VAL_DESC_PARCELA_PEND.ValueChanged += OnValueChanged;
                    DET_DT_NEGOCIADA_PAGTO.ValueChanged += OnValueChanged;
                    DET_VAL_IRRF.ValueChanged += OnValueChanged;
                    DET_VAL_ISS.ValueChanged += OnValueChanged;
                    DET_VAL_INSS.ValueChanged += OnValueChanged;
                    DET_VAL_LIQUIDO_PAGO.ValueChanged += OnValueChanged;
                    DET_CNPJ_CPF_FAVORECIDO.ValueChanged += OnValueChanged;
                    DET_NOME_FAVORECIDO.ValueChanged += OnValueChanged;
                    DET_IND_TIPO_DOC_FISCAL.ValueChanged += OnValueChanged;
                    DET_NUM_DOC_FISCAL.ValueChanged += OnValueChanged;
                    DET_SERIE_DOC_FISCAL.ValueChanged += OnValueChanged;
                    DET_DT_EMISSAO_DOC.ValueChanged += OnValueChanged;
                    DET_ENDERECO.ValueChanged += OnValueChanged;
                    DET_NOM_BAIRRO.ValueChanged += OnValueChanged;
                    DET_NOM_CIDADE.ValueChanged += OnValueChanged;
                    DET_NOM_SIGLA_UF.ValueChanged += OnValueChanged;
                    DET_CEP.ValueChanged += OnValueChanged;
                    DET_NUM_DDD.ValueChanged += OnValueChanged;
                    DET_NUM_TELEFONE.ValueChanged += OnValueChanged;
                    DET_IND_FORMA_PAGTO.ValueChanged += OnValueChanged;
                    DET_NUM_IDENTIFICADOR_PAGTO.ValueChanged += OnValueChanged;
                    DET_NUM_CHEQUE_INTERNO.ValueChanged += OnValueChanged;
                    DET_NUM_OP_VC.ValueChanged += OnValueChanged;
                    DET_NUM_OP_CXSEG.ValueChanged += OnValueChanged;
                    DET_COD_BANCO.ValueChanged += OnValueChanged;
                    DET_COD_AGENCIA.ValueChanged += OnValueChanged;
                    DET_COD_OPERACAO_CONTA_CEF.ValueChanged += OnValueChanged;
                    DET_NUM_CONTA_BANCARIA.ValueChanged += OnValueChanged;
                    DET_DV_CONTA.ValueChanged += OnValueChanged;
                    DET_IND_PROCESSAMENTO.ValueChanged += OnValueChanged;
                    DET_MENSAGEM_RETORNO.ValueChanged += OnValueChanged;
                    DET_COD_FAVORECIDO.ValueChanged += OnValueChanged;
                    DET_TIPO_PESSOA.ValueChanged += OnValueChanged;
                    DET_VAL_PISPASEP.ValueChanged += OnValueChanged;
                    DET_VAL_COFINS.ValueChanged += OnValueChanged;
                    DET_VAL_CSLL.ValueChanged += OnValueChanged;
                    DET_SERIE_CHEQUE.ValueChanged += OnValueChanged;
                    DET_IDENT_PAGTO_EDITADO.ValueChanged += OnValueChanged;
                    DET_MARCA_MODELO.ValueChanged += OnValueChanged;
                    DET_PLACA.ValueChanged += OnValueChanged;
                    DET_CHASSIS.ValueChanged += OnValueChanged;
                    DET_ANO_VEICULO.ValueChanged += OnValueChanged;
                    DET_CIRCULAR_200.ValueChanged += OnValueChanged;
                    DET_CIRCULAR_255.ValueChanged += OnValueChanged;
                    DET_NUM_RESSARC.ValueChanged += OnValueChanged;
                    DET_IND_PESSOA_ACORDO.ValueChanged += OnValueChanged;
                    DET_NUM_CPFCGC_ACORDO.ValueChanged += OnValueChanged;
                    DET_NOM_RESP_ACORDO.ValueChanged += OnValueChanged;
                    DET_STA_ACORDO.ValueChanged += OnValueChanged;
                    DET_DTH_INDENIZACAO.ValueChanged += OnValueChanged;
                    DET_VLR_INDENIZACAO.ValueChanged += OnValueChanged;
                    DET_VLR_PART_TERCEIROS.ValueChanged += OnValueChanged;
                    DET_VLR_DIVIDA.ValueChanged += OnValueChanged;
                    DET_PCT_DESCONTO.ValueChanged += OnValueChanged;
                    DET_VLR_TOTAL_DESCONTO.ValueChanged += OnValueChanged;
                    DET_VLR_TOTAL_ACORDO.ValueChanged += OnValueChanged;
                    DET_COD_MOEDA_ACORDO.ValueChanged += OnValueChanged;
                    DET_DTH_ACORDO.ValueChanged += OnValueChanged;
                    DET_QTD_PARCELAS_ACORDO.ValueChanged += OnValueChanged;
                    DET_NUM_PARCELA_ACORDO.ValueChanged += OnValueChanged;
                    DET_COD_AGENCIA_CEDENT.ValueChanged += OnValueChanged;
                    DET_NUM_CEDENTE.ValueChanged += OnValueChanged;
                    DET_NUM_CEDENTE_DV.ValueChanged += OnValueChanged;
                    DET_DTH_VENCIMENTO.ValueChanged += OnValueChanged;
                    DET_NUM_NOSSO_TITULO.ValueChanged += OnValueChanged;
                    DET_VLR_TITULO.ValueChanged += OnValueChanged;
                    DET_NUM_CPFCGC_RECLAMANTE.ValueChanged += OnValueChanged;
                    DET_NOM_RECLAMANTE.ValueChanged += OnValueChanged;
                    DET_VLR_RECLAMADO.ValueChanged += OnValueChanged;
                    DET_VLR_PROVISIONADO.ValueChanged += OnValueChanged;
                    DET_NUM_IDENT_CONV.ValueChanged += OnValueChanged;
                    DET_NUM_IDENT_PAGTO.ValueChanged += OnValueChanged;
                    DET_COD_IDLG.ValueChanged += OnValueChanged;
                    DET_CFOP.ValueChanged += OnValueChanged;
                    DET_CEST.ValueChanged += OnValueChanged;
                    DET_INSC_EST.ValueChanged += OnValueChanged;
                    DET_NCM.ValueChanged += OnValueChanged;
                    DET_CNPJ_FILIAL.ValueChanged += OnValueChanged;
                    DET_IND_RET_IMP.ValueChanged += OnValueChanged;
                    DET_COD_IMP_LIM.ValueChanged += OnValueChanged;
                    DET_COD_PROC_PJDT.ValueChanged += OnValueChanged;
                    DET_VLR_RET_PRINC.ValueChanged += OnValueChanged;
                    DET_COD_PIS.ValueChanged += OnValueChanged;
                    DET_COD_CPF.ValueChanged += OnValueChanged;
                    DET_NOME.ValueChanged += OnValueChanged;
                    DET_DATA_NASC.ValueChanged += OnValueChanged;
                    DET_CBO.ValueChanged += OnValueChanged;
                    DET_NACIONALIDADE.ValueChanged += OnValueChanged;
                    DET_PAIS_NASC.ValueChanged += OnValueChanged;
                    DET_NUM_SEQ_REGISTRO.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_SI9211B_SCMOVSIN_TRAILLER _scmovsin_trailler { get; set; }
            public _REDEF_SI9211B_SCMOVSIN_TRAILLER SCMOVSIN_TRAILLER
            {
                get { _scmovsin_trailler = new _REDEF_SI9211B_SCMOVSIN_TRAILLER(); _.Move(SCMOVSIN_HEADER, _scmovsin_trailler); VarBasis.RedefinePassValue(SCMOVSIN_HEADER, _scmovsin_trailler, SCMOVSIN_HEADER); _scmovsin_trailler.ValueChanged += () => { _.Move(_scmovsin_trailler, SCMOVSIN_HEADER); }; return _scmovsin_trailler; }
                set { VarBasis.RedefinePassValue(value, _scmovsin_trailler, SCMOVSIN_HEADER); }
            }  //Redefines
            public class _REDEF_SI9211B_SCMOVSIN_TRAILLER : VarBasis
            {
                /*"    10   TRL-TIPO-REGISTRO           PIC  X(001).*/
                public StringBasis TRL_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10   TRL-COD-ORIGEM-ARQUIVO      PIC  9(004).*/
                public IntBasis TRL_COD_ORIGEM_ARQUIVO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10   TRL-QTD-REGISTROS           PIC  9(006).*/
                public IntBasis TRL_QTD_REGISTROS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10   TRL-IND-PROCESSAMENTO       PIC  X(001).*/
                public StringBasis TRL_IND_PROCESSAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10   TRL-MENSAGEM-RETORNO        PIC  X(100).*/
                public StringBasis TRL_MENSAGEM_RETORNO { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
                /*"    10   TRL-FILLER                  PIC  X(1627).*/
                public StringBasis TRL_FILLER { get; set; } = new StringBasis(new PIC("X", "1627", "X(1627)."), @"");
                /*"    10   TRL-NUM-SEQ-REGISTRO        PIC  9(006).*/
                public IntBasis TRL_NUM_SEQ_REGISTRO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));

                public _REDEF_SI9211B_SCMOVSIN_TRAILLER()
                {
                    TRL_TIPO_REGISTRO.ValueChanged += OnValueChanged;
                    TRL_COD_ORIGEM_ARQUIVO.ValueChanged += OnValueChanged;
                    TRL_QTD_REGISTROS.ValueChanged += OnValueChanged;
                    TRL_IND_PROCESSAMENTO.ValueChanged += OnValueChanged;
                    TRL_MENSAGEM_RETORNO.ValueChanged += OnValueChanged;
                    TRL_FILLER.ValueChanged += OnValueChanged;
                    TRL_NUM_SEQ_REGISTRO.ValueChanged += OnValueChanged;
                }

            }
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis I01_CAU { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"01       HOST-VAL-RESERVA       PIC S9(013)V99 VALUE +0 COMP-3.*/
        public DoubleBasis HOST_VAL_RESERVA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01       HOST-COUNT                  PIC S9(004) VALUE +0 COMP.*/
        public IntBasis HOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01       HOST-ANO-MOV-ABERTO         PIC S9(004) VALUE +0 COMP.*/
        public IntBasis HOST_ANO_MOV_ABERTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01       HOST-MES-MOV-ABERTO         PIC S9(004) VALUE +0 COMP.*/
        public IntBasis HOST_MES_MOV_ABERTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01       HOST-DATA-30                PIC  X(010).*/
        public StringBasis HOST_DATA_30 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01       IND-DTEMIS                  PIC S9(004) VALUE +0 COMP.*/
        public IntBasis IND_DTEMIS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01       IND-DATA-EMISSAO       PIC S9(004) VALUE +0 COMP.*/
        public IntBasis IND_DATA_EMISSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01       IND-DATA-MOV           PIC S9(004) VALUE +0 COMP.*/
        public IntBasis IND_DATA_MOV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01       IND-COD-RETORNO-CEF    PIC S9(004) VALUE +0 COMP.*/
        public IntBasis IND_COD_RETORNO_CEF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01       WFIM-SIARDEVC               PIC  X(001) VALUE SPACES.*/
        public StringBasis WFIM_SIARDEVC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01       WS-ESTORNO                  PIC  X(001) VALUE SPACES.*/
        public StringBasis WS_ESTORNO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01       WS-PERDA-TOTAL              PIC  X(003) VALUE SPACES.*/
        public StringBasis WS_PERDA_TOTAL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"01       AC-L-SIARDEVC               PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_L_SIARDEVC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-L-SIARDEVC-R             PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_L_SIARDEVC_R { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       CT-L-INDENIZA               PIC  9(009) VALUE ZEROS.*/
        public IntBasis CT_L_INDENIZA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       CT-P-INDENIZA               PIC  9(009) VALUE ZEROS.*/
        public IntBasis CT_P_INDENIZA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-L-SINISHIS               PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_L_SINISHIS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-L-SINISHIS-H             PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_L_SINISHIS_H { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-L-SINIPESS               PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_L_SINIPESS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-L-SINICHEQ               PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_L_SINICHEQ { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-L-MVTODEBT               PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_L_MVTODEBT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-L-GEMVTOCT               PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_L_GEMVTOCT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-L-PGTODOCF               PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_L_PGTODOCF { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-L-SEM-PGTODOCF           PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_L_SEM_PGTODOCF { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-L-MVTODEBSAP             PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_L_MVTODEBSAP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-G-CSPAGSIN-R             PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_G_CSPAGSIN_R { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-G-CSPAGSIN               PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_G_CSPAGSIN { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-I-GEARDETA               PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_I_GEARDETA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-I-SIARVRCZ               PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_I_SIARVRCZ { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-I-SIARREVC               PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_I_SIARREVC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-I-SINISHIS               PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_I_SINISHIS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-I-GEMVTOCT               PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_I_GEMVTOCT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-U-GEARDETA               PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_U_GEARDETA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-U-SIARDEVC               PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_U_SIARDEVC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-U-OPERACAO               PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_U_OPERACAO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-U-SINIPESS               PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_U_SINIPESS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-U-SINICHEQ               PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_U_SINICHEQ { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-U-MVTODEBT               PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_U_MVTODEBT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-U-MVTODEBSAP             PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_U_MVTODEBSAP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-U-PGTODOCF               PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_U_PGTODOCF { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-D-GEMVTOCT               PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_D_GEMVTOCT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AUX-COD-OPERACAO            PIC  S9(9)  USAGE COMP.*/
        public IntBasis AUX_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01       WS-QT-SEM-RETORNO           PIC  9(009) VALUE ZEROS.*/
        public IntBasis WS_QT_SEM_RETORNO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01  WS-ENCONTROU               PIC X(003)      VALUE SPACES.*/

        public SelectorBasis WS_ENCONTROU { get; set; } = new SelectorBasis("003", "SPACES")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 SIM-ENCONTROU                           VALUE 'SIM'. */
							new SelectorItemBasis("SIM_ENCONTROU", "SIM"),
							/*" 88 NAO-ENCONTROU                           VALUE 'NAO'. */
							new SelectorItemBasis("NAO_ENCONTROU", "NAO")
                }
        };

        /*"01       WS-IDENT-PAGTO-EDITADO.*/
        public SI9211B_WS_IDENT_PAGTO_EDITADO WS_IDENT_PAGTO_EDITADO { get; set; } = new SI9211B_WS_IDENT_PAGTO_EDITADO();
        public class SI9211B_WS_IDENT_PAGTO_EDITADO : VarBasis
        {
            /*"  05     WS-CHEQUE-EXTERNO           PIC  ZZZ999999.*/
            public IntBasis WS_CHEQUE_EXTERNO { get; set; } = new IntBasis(new PIC("9", "9", "ZZZ999999."));
            /*"  05     WS-SEPARADOR                PIC  X(001) VALUE SPACE.*/
            public StringBasis WS_SEPARADOR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05     WS-CHEQUE-INTERNO           PIC  9(009) VALUE ZEROS.*/
            public IntBasis WS_CHEQUE_INTERNO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"01      WS-CAUSA.*/
        }
        public SI9211B_WS_CAUSA WS_CAUSA { get; set; } = new SI9211B_WS_CAUSA();
        public class SI9211B_WS_CAUSA : VarBasis
        {
            /*"  05    WS-COD-RAMO    PIC      9(004).*/
            public IntBasis WS_COD_RAMO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05    WS-COD-CAUSA   PIC      9(004).*/
            public IntBasis WS_COD_CAUSA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"01     TAB-CAUSA                       VALUE    ZEROS.*/
        }
        public SI9211B_TAB_CAUSA TAB_CAUSA { get; set; } = new SI9211B_TAB_CAUSA();
        public class SI9211B_TAB_CAUSA : VarBasis
        {
            /*"  05   TB-CAUSA       OCCURS   101 INDEXED BY   I01-CAU.*/
            public ListBasis<SI9211B_TB_CAUSA> TB_CAUSA { get; set; } = new ListBasis<SI9211B_TB_CAUSA>(101);
            public class SI9211B_TB_CAUSA : VarBasis
            {
                /*"    10 TB-CAU-CHV     PIC      9(008).*/
                public IntBasis TB_CAU_CHV { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    10 TB-CAU-GRP     PIC      X(002).*/
                public StringBasis TB_CAU_GRP { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"01  WS-VERSAO-06          PIC   X(060) VALUE     'SI9211B - VERSAO: V.06 - 20150707 16:58HS '.*/
            }
        }
        public StringBasis WS_VERSAO_06 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"SI9211B - VERSAO: V.06 - 20150707 16:58HS ");
        /*"01  WS-VERSAO-07          PIC   X(060) VALUE     'SI9211B - VERSAO: V6.0 - 21112011 11:21HS '.*/
        public StringBasis WS_VERSAO_07 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"SI9211B - VERSAO: V6.0 - 21112011 11:21HS ");
        /*"01  WS-VERSAO             PIC   X(060) VALUE     'SI9211B - VERSAO: V.13 - 25/07/2022'.*/
        public StringBasis WS_VERSAO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"SI9211B - VERSAO: V.13 - 25/07/2022");
        /*"01          WABEND.*/
        public SI9211B_WABEND WABEND { get; set; } = new SI9211B_WABEND();
        public class SI9211B_WABEND : VarBasis
        {
            /*"  05     FILLER                      PIC  X(010) VALUE           ' SI9211B'.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SI9211B");
            /*"  05     FILLER                      PIC  X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"  05     WNR-EXEC-SQL                PIC  X(004) VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"  05     FILLER                      PIC  X(013) VALUE           ' *** SQLCODE '.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"  05     WSQLCODE                    PIC  ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
        }


        public Copies.LBSI1001 LBSI1001 { get; set; } = new Copies.LBSI1001();
        public Copies.RSGEWDTA RSGEWDTA { get; set; } = new Copies.RSGEWDTA();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.GEARDETA GEARDETA { get; set; } = new Dclgens.GEARDETA();
        public Dclgens.SIARVRCZ SIARVRCZ { get; set; } = new Dclgens.SIARVRCZ();
        public Dclgens.SIARDEVC SIARDEVC { get; set; } = new Dclgens.SIARDEVC();
        public Dclgens.SIARREVC SIARREVC { get; set; } = new Dclgens.SIARREVC();
        public Dclgens.SIERRO SIERRO { get; set; } = new Dclgens.SIERRO();
        public Dclgens.LOTECHEQ LOTECHEQ { get; set; } = new Dclgens.LOTECHEQ();
        public Dclgens.SINISCAU SINISCAU { get; set; } = new Dclgens.SINISCAU();
        public Dclgens.MOVDEBCE MOVDEBCE { get; set; } = new Dclgens.MOVDEBCE();
        public Dclgens.CHEQUEMI CHEQUEMI { get; set; } = new Dclgens.CHEQUEMI();
        public Dclgens.SISINCHE SISINCHE { get; set; } = new Dclgens.SISINCHE();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.SI175 SI175 { get; set; } = new Dclgens.SI175();
        public Dclgens.GE094 GE094 { get; set; } = new Dclgens.GE094();
        public Dclgens.GE369 GE369 { get; set; } = new Dclgens.GE369();
        public Dclgens.SIPADOFI SIPADOFI { get; set; } = new Dclgens.SIPADOFI();
        public SI9211B_C01_SIARDEVC C01_SIARDEVC { get; set; } = new SI9211B_C01_SIARDEVC();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string CSPAGSIN_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                CSPAGSIN.SetFile(CSPAGSIN_FILE_NAME_P);

                /*" -320- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -321- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -322- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -322- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -330- MOVE '0000' TO WNR-EXEC-SQL */
            _.Move("0000", WABEND.WNR_EXEC_SQL);

            /*" -332- PERFORM R0100-00-LE-SISTEMAS */

            R0100_00_LE_SISTEMAS_SECTION();

            /*" -334- OPEN OUTPUT CSPAGSIN */
            CSPAGSIN.Open(REG_SCMOVSIN);

            /*" -334- MOVE FUNCTION CURRENT-DATE TO WS-CURRENT-DATE */
            _.Move(_.CurrentDate(), RSGEWDTA.RSS_WORK_DATAS.WS_CURRENT_DATE);

            /*" -334- MOVE FUNCTION WHEN-COMPILED TO WS-WHEN-COMPILED */
            _.Move(_.WhenCompiled(), RSGEWDTA.RSS_WORK_DATAS.WS_WHEN_COMPILED);

            /*" -334- STRING WS-WHEN-ANO '-' WS-WHEN-MES '-' WS-WHEN-DIA ' ' WS-WHEN-HORA ':' WS-WHEN-MIN ':' WS-WHEN-SEG ',' WS-WHEN-DECSEG DELIMITED BY SIZE INTO WS-COMPILED-EDIT */
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

            /*" -336- STRING WS-CDTE-ANO '-' WS-CDTE-MES '-' WS-CDTE-DIA ' ' WS-CDTE-HORA ':' WS-CDTE-MIN ':' WS-CDTE-SEG ',' WS-CDTE-DECSEG DELIMITED BY SIZE INTO WS-CURRENT-EDIT */
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

            /*" -337- MOVE SPACES TO WFIM-SIARDEVC */
            _.Move("", WFIM_SIARDEVC);

            /*" -338- PERFORM R0900-00-DECLARA-SIARDEVC */

            R0900_00_DECLARA_SIARDEVC_SECTION();

            /*" -340- PERFORM R0910-00-LE-SIARDEVC */

            R0910_00_LE_SIARDEVC_SECTION();

            /*" -341- IF WFIM-SIARDEVC EQUAL 'S' */

            if (WFIM_SIARDEVC == "S")
            {

                /*" -343- GO TO R0000-10-FINALIZA. */

                R0000_10_FINALIZA(); //GOTO
                return;
            }


            /*" -345- PERFORM R0500-00-GERA-HEADER */

            R0500_00_GERA_HEADER_SECTION();

            /*" -348- PERFORM R1000-00-PROCESSA-SIARDEVC UNTIL WFIM-SIARDEVC EQUAL 'S' */

            while (!(WFIM_SIARDEVC == "S"))
            {

                R1000_00_PROCESSA_SIARDEVC_SECTION();
            }

            /*" -350- PERFORM R0600-00-GERA-TRAILLER */

            R0600_00_GERA_TRAILLER_SECTION();

            /*" -351- ADD AC-G-CSPAGSIN TO GEARDETA-QTD-REG-PROCESSADO */
            GEARDETA.DCLGE_AR_DETALHE.GEARDETA_QTD_REG_PROCESSADO.Value = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_QTD_REG_PROCESSADO + AC_G_CSPAGSIN;

            /*" -351- PERFORM R0700-00-ALTERA-GEARDETA. */

            R0700_00_ALTERA_GEARDETA_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0000_10_FINALIZA */

            R0000_10_FINALIZA();

        }

        [StopWatch]
        /*" R0000-10-FINALIZA */
        private void R0000_10_FINALIZA(bool isPerform = false)
        {
            /*" -356- DISPLAY '********************************' */
            _.Display($"********************************");

            /*" -357- DISPLAY '*     SI9211B - FIM NORMAL     *' */
            _.Display($"*     SI9211B - FIM NORMAL     *");

            /*" -358- DISPLAY '********************************' */
            _.Display($"********************************");

            /*" -359- DISPLAY 'LIDOS       - SIARDEVC   ' AC-L-SIARDEVC */
            _.Display($"LIDOS       - SIARDEVC   {AC_L_SIARDEVC}");

            /*" -360- DISPLAY '            - SIARDEVC-R ' AC-L-SIARDEVC-R */
            _.Display($"            - SIARDEVC-R {AC_L_SIARDEVC_R}");

            /*" -361- DISPLAY '            - SINI-HIST  ' AC-L-SINISHIS */
            _.Display($"            - SINI-HIST  {AC_L_SINISHIS}");

            /*" -362- DISPLAY '            - CHECA-SI-H ' AC-L-SINISHIS-H */
            _.Display($"            - CHECA-SI-H {AC_L_SINISHIS_H}");

            /*" -363- DISPLAY '            - SINI-PESS  ' AC-L-SINIPESS */
            _.Display($"            - SINI-PESS  {AC_L_SINIPESS}");

            /*" -364- DISPLAY '            - SINI-CHEQ  ' AC-L-SINICHEQ */
            _.Display($"            - SINI-CHEQ  {AC_L_SINICHEQ}");

            /*" -365- DISPLAY '            - MOVTO-DEB  ' AC-L-MVTODEBT */
            _.Display($"            - MOVTO-DEB  {AC_L_MVTODEBT}");

            /*" -366- DISPLAY '            - PGTO-DOCF  ' AC-L-PGTODOCF */
            _.Display($"            - PGTO-DOCF  {AC_L_PGTODOCF}");

            /*" -367- DISPLAY '            - SEM-PGTO-DOCF ' AC-L-SEM-PGTODOCF */
            _.Display($"            - SEM-PGTO-DOCF {AC_L_SEM_PGTODOCF}");

            /*" -368- DISPLAY '            - MOVTO-DEB-SAP ' AC-L-MVTODEBSAP */
            _.Display($"            - MOVTO-DEB-SAP {AC_L_MVTODEBSAP}");

            /*" -369- DISPLAY '            - GE-MOVTO-CT ' AC-L-GEMVTOCT */
            _.Display($"            - GE-MOVTO-CT {AC_L_GEMVTOCT}");

            /*" -370- DISPLAY 'DELETADOS   - GE-MOVTO-CT ' AC-D-GEMVTOCT */
            _.Display($"DELETADOS   - GE-MOVTO-CT {AC_D_GEMVTOCT}");

            /*" -371- DISPLAY 'ALTERADOS   - SIARDEVC   ' AC-U-SIARDEVC */
            _.Display($"ALTERADOS   - SIARDEVC   {AC_U_SIARDEVC}");

            /*" -372- DISPLAY '            - GEARDETA   ' AC-U-GEARDETA */
            _.Display($"            - GEARDETA   {AC_U_GEARDETA}");

            /*" -373- DISPLAY '            - OPERACAO   ' AC-U-OPERACAO */
            _.Display($"            - OPERACAO   {AC_U_OPERACAO}");

            /*" -374- DISPLAY '            - SINI-PESS  ' AC-U-SINIPESS */
            _.Display($"            - SINI-PESS  {AC_U_SINIPESS}");

            /*" -375- DISPLAY '            - SINI-CHEQ  ' AC-U-SINICHEQ */
            _.Display($"            - SINI-CHEQ  {AC_U_SINICHEQ}");

            /*" -376- DISPLAY '            - MOVTO-DEB  ' AC-U-MVTODEBT */
            _.Display($"            - MOVTO-DEB  {AC_U_MVTODEBT}");

            /*" -377- DISPLAY '            - PGTO-DOCF  ' AC-U-PGTODOCF */
            _.Display($"            - PGTO-DOCF  {AC_U_PGTODOCF}");

            /*" -378- DISPLAY '            - MOVTO-DEB-SAP ' AC-U-MVTODEBSAP */
            _.Display($"            - MOVTO-DEB-SAP {AC_U_MVTODEBSAP}");

            /*" -379- DISPLAY 'INSERIDOS   - GEARDETA   ' AC-I-GEARDETA */
            _.Display($"INSERIDOS   - GEARDETA   {AC_I_GEARDETA}");

            /*" -380- DISPLAY '            - SIARVRCZ   ' AC-I-SIARVRCZ */
            _.Display($"            - SIARVRCZ   {AC_I_SIARVRCZ}");

            /*" -381- DISPLAY '            - SIARREVC   ' AC-I-SIARREVC */
            _.Display($"            - SIARREVC   {AC_I_SIARREVC}");

            /*" -382- DISPLAY '            - SINI-HIST  ' AC-I-SINISHIS */
            _.Display($"            - SINI-HIST  {AC_I_SINISHIS}");

            /*" -383- DISPLAY '            - GE-MOVTO-CT ' AC-I-GEMVTOCT */
            _.Display($"            - GE-MOVTO-CT {AC_I_GEMVTOCT}");

            /*" -384- DISPLAY 'GRAVADOS    - CSPAGSIN   ' AC-G-CSPAGSIN */
            _.Display($"GRAVADOS    - CSPAGSIN   {AC_G_CSPAGSIN}");

            /*" -385- DISPLAY '            - CSPAGSIN-R ' AC-G-CSPAGSIN-R */
            _.Display($"            - CSPAGSIN-R {AC_G_CSPAGSIN_R}");

            /*" -386- DISPLAY 'SEM RETORNO APOS 30 DIAS ' WS-QT-SEM-RETORNO */
            _.Display($"SEM RETORNO APOS 30 DIAS {WS_QT_SEM_RETORNO}");

            /*" -387- DISPLAY ' ' */
            _.Display($" ");

            /*" -388- DISPLAY 'INDENIZACAO - LIDOS      ' CT-L-INDENIZA */
            _.Display($"INDENIZACAO - LIDOS      {CT_L_INDENIZA}");

            /*" -390- DISPLAY 'INDENIZACAO - PROCESSADO ' CT-P-INDENIZA */
            _.Display($"INDENIZACAO - PROCESSADO {CT_P_INDENIZA}");

            /*" -392- CLOSE CSPAGSIN */
            CSPAGSIN.Close();

            /*" -394- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -394- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0100-00-LE-SISTEMAS-SECTION */
        private void R0100_00_LE_SISTEMAS_SECTION()
        {
            /*" -402- MOVE '0100' TO WNR-EXEC-SQL */
            _.Move("0100", WABEND.WNR_EXEC_SQL);

            /*" -413- PERFORM R0100_00_LE_SISTEMAS_DB_SELECT_1 */

            R0100_00_LE_SISTEMAS_DB_SELECT_1();

            /*" -416- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -417- DISPLAY 'ERRO NO SELECT SISTEMAS' */
                _.Display($"ERRO NO SELECT SISTEMAS");

                /*" -419- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -420- DISPLAY WS-VERSAO */
            _.Display(WS_VERSAO);

            /*" -422- DISPLAY ' CATALOGADO EM: ' WS-WHEN-COMPILED. */
            _.Display($" CATALOGADO EM: {RSGEWDTA.RSS_WORK_DATAS.WS_WHEN_COMPILED}");

            /*" -424- DISPLAY 'DATA DO SISTEMA DE SINISTRO -' ' ' SISTEMAS-DATA-MOV-ABERTO */

            $"DATA DO SISTEMA DE SINISTRO - {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}"
            .Display();

            /*" -424- DISPLAY 'HOST-DATA-30: ' HOST-DATA-30. */
            _.Display($"HOST-DATA-30: {HOST_DATA_30}");

        }

        [StopWatch]
        /*" R0100-00-LE-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_LE_SISTEMAS_DB_SELECT_1()
        {
            /*" -413- EXEC SQL SELECT DATA_MOV_ABERTO, YEAR(DATA_MOV_ABERTO), MONTH(DATA_MOV_ABERTO), (DATA_MOV_ABERTO - 30 DAYS) INTO :SISTEMAS-DATA-MOV-ABERTO, :HOST-ANO-MOV-ABERTO, :HOST-MES-MOV-ABERTO, :HOST-DATA-30 FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' END-EXEC */

            var r0100_00_LE_SISTEMAS_DB_SELECT_1_Query1 = new R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1.Execute(r0100_00_LE_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.HOST_ANO_MOV_ABERTO, HOST_ANO_MOV_ABERTO);
                _.Move(executed_1.HOST_MES_MOV_ABERTO, HOST_MES_MOV_ABERTO);
                _.Move(executed_1.HOST_DATA_30, HOST_DATA_30);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_00_EXIT*/

        [StopWatch]
        /*" R0500-00-GERA-HEADER-SECTION */
        private void R0500_00_GERA_HEADER_SECTION()
        {
            /*" -434- MOVE '0500' TO WNR-EXEC-SQL */
            _.Move("0500", WABEND.WNR_EXEC_SQL);

            /*" -435- MOVE 'CSPAGSIN' TO GEARDETA-NOM-ARQUIVO */
            _.Move("CSPAGSIN", GEARDETA.DCLGE_AR_DETALHE.GEARDETA_NOM_ARQUIVO);

            /*" -436- PERFORM R0510-00-MAX-GEARDETA */

            R0510_00_MAX_GEARDETA_SECTION();

            /*" -437- ADD 1 TO GEARDETA-SEQ-GERACAO */
            GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO.Value = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO + 1;

            /*" -438- MOVE 0 TO GEARDETA-QTD-REG-PROCESSADO */
            _.Move(0, GEARDETA.DCLGE_AR_DETALHE.GEARDETA_QTD_REG_PROCESSADO);

            /*" -440- PERFORM R0520-00-INCLUI-GEARDETA */

            R0520_00_INCLUI_GEARDETA_SECTION();

            /*" -442- INITIALIZE REG-SCMOVSIN */
            _.Initialize(
                REG_SCMOVSIN
            );

            /*" -444- MOVE '1' TO HDR-TIPO-REGISTRO */
            _.Move("1", REG_SCMOVSIN.SCMOVSIN_HEADER.HDR_TIPO_REGISTRO);

            /*" -445- MOVE 'CADENA' TO HDR-NOME-ARQUIVO */
            _.Move("CADENA", REG_SCMOVSIN.SCMOVSIN_HEADER.HDR_NOME_ARQUIVO);

            /*" -446- MOVE 'SULAMERICA' TO HDR-NOME-CONVENIADA */
            _.Move("SULAMERICA", REG_SCMOVSIN.SCMOVSIN_HEADER.HDR_NOME_CONVENIADA);

            /*" -449- MOVE 5118 TO HDR-COD-ORIGEM-ARQUIVO */
            _.Move(5118, REG_SCMOVSIN.SCMOVSIN_HEADER.HDR_COD_ORIGEM_ARQUIVO);

            /*" -451- MOVE SISTEMAS-DATA-MOV-ABERTO TO HDR-DT-GERACAO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, REG_SCMOVSIN.SCMOVSIN_HEADER.HDR_DT_GERACAO);

            /*" -453- MOVE GEARDETA-SEQ-GERACAO TO HDR-NUM-SEQ-ARQUIVO */
            _.Move(GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO, REG_SCMOVSIN.SCMOVSIN_HEADER.HDR_NUM_SEQ_ARQUIVO);

            /*" -454- MOVE '1' TO HDR-IND-PROCESSAMENTO */
            _.Move("1", REG_SCMOVSIN.SCMOVSIN_HEADER.HDR_IND_PROCESSAMENTO);

            /*" -455- MOVE 'PAGAMENTO' TO HDR-RUBRICA-ARQUIVO */
            _.Move("PAGAMENTO", REG_SCMOVSIN.SCMOVSIN_HEADER.HDR_RUBRICA_ARQUIVO);

            /*" -457- MOVE SPACES TO HDR-MENSAGEM-RETORNO HDR-FILLER */
            _.Move("", REG_SCMOVSIN.SCMOVSIN_HEADER.HDR_MENSAGEM_RETORNO, REG_SCMOVSIN.SCMOVSIN_HEADER.HDR_FILLER);

            /*" -458- ADD 1 TO AC-G-CSPAGSIN */
            AC_G_CSPAGSIN.Value = AC_G_CSPAGSIN + 1;

            /*" -461- MOVE AC-G-CSPAGSIN TO HDR-NUM-SEQ-REGISTRO */
            _.Move(AC_G_CSPAGSIN, REG_SCMOVSIN.SCMOVSIN_HEADER.HDR_NUM_SEQ_REGISTRO);

            /*" -463- WRITE REG-SCMOVSIN. */
            CSPAGSIN.Write(REG_SCMOVSIN.GetMoveValues().ToString());

            /*" -464- MOVE '1' TO SIARVRCZ-TIPO-REGISTRO */
            _.Move("1", SIARVRCZ.DCLSI_AR_VERA_CRUZ.SIARVRCZ_TIPO_REGISTRO);

            /*" -465- MOVE AC-G-CSPAGSIN TO SIARVRCZ-SEQ-REGISTRO */
            _.Move(AC_G_CSPAGSIN, SIARVRCZ.DCLSI_AR_VERA_CRUZ.SIARVRCZ_SEQ_REGISTRO);

            /*" -466- MOVE '1' TO SIARVRCZ-STA-PROCESSAMENTO */
            _.Move("1", SIARVRCZ.DCLSI_AR_VERA_CRUZ.SIARVRCZ_STA_PROCESSAMENTO);

            /*" -466- PERFORM R0530-00-INCLUI-SIARVRCZ. */

            R0530_00_INCLUI_SIARVRCZ_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_00_EXIT*/

        [StopWatch]
        /*" R0510-00-MAX-GEARDETA-SECTION */
        private void R0510_00_MAX_GEARDETA_SECTION()
        {
            /*" -476- MOVE '0510' TO WNR-EXEC-SQL */
            _.Move("0510", WABEND.WNR_EXEC_SQL);

            /*" -481- PERFORM R0510_00_MAX_GEARDETA_DB_SELECT_1 */

            R0510_00_MAX_GEARDETA_DB_SELECT_1();

            /*" -484- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -486- DISPLAY 'ERRO MAX GE_AR_DETALHE' ' ' GEARDETA-NOM-ARQUIVO */

                $"ERRO MAX GE_AR_DETALHE {GEARDETA.DCLGE_AR_DETALHE.GEARDETA_NOM_ARQUIVO}"
                .Display();

                /*" -486- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0510-00-MAX-GEARDETA-DB-SELECT-1 */
        public void R0510_00_MAX_GEARDETA_DB_SELECT_1()
        {
            /*" -481- EXEC SQL SELECT VALUE(MAX(SEQ_GERACAO),0) INTO :GEARDETA-SEQ-GERACAO FROM SEGUROS.GE_AR_DETALHE WHERE NOM_ARQUIVO = :GEARDETA-NOM-ARQUIVO END-EXEC. */

            var r0510_00_MAX_GEARDETA_DB_SELECT_1_Query1 = new R0510_00_MAX_GEARDETA_DB_SELECT_1_Query1()
            {
                GEARDETA_NOM_ARQUIVO = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_NOM_ARQUIVO.ToString(),
            };

            var executed_1 = R0510_00_MAX_GEARDETA_DB_SELECT_1_Query1.Execute(r0510_00_MAX_GEARDETA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GEARDETA_SEQ_GERACAO, GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_00_EXIT*/

        [StopWatch]
        /*" R0520-00-INCLUI-GEARDETA-SECTION */
        private void R0520_00_INCLUI_GEARDETA_SECTION()
        {
            /*" -496- MOVE '0520' TO WNR-EXEC-SQL. */
            _.Move("0520", WABEND.WNR_EXEC_SQL);

            /*" -526- PERFORM R0520_00_INCLUI_GEARDETA_DB_INSERT_1 */

            R0520_00_INCLUI_GEARDETA_DB_INSERT_1();

            /*" -529- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -532- DISPLAY 'PROBLEMAS NO INSERT GE_AR_DETALHE' ' ' GEARDETA-NOM-ARQUIVO ' ' GEARDETA-SEQ-GERACAO */

                $"PROBLEMAS NO INSERT GE_AR_DETALHE {GEARDETA.DCLGE_AR_DETALHE.GEARDETA_NOM_ARQUIVO} {GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO}"
                .Display();

                /*" -534- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -534- ADD 1 TO AC-I-GEARDETA. */
            AC_I_GEARDETA.Value = AC_I_GEARDETA + 1;

        }

        [StopWatch]
        /*" R0520-00-INCLUI-GEARDETA-DB-INSERT-1 */
        public void R0520_00_INCLUI_GEARDETA_DB_INSERT_1()
        {
            /*" -526- EXEC SQL INSERT INTO SEGUROS.GE_AR_DETALHE (NOM_ARQUIVO, SEQ_GERACAO, DTH_ANO_REFERENCIA, DTH_MES_REFERENCIA, DTH_MOVIMENTO, DTH_GERACAO, DTH_RECEPCAO, IND_MEIO_ENVIO, STA_ENVIO_RECEPCAO, COD_TIPO_ARQUIVO, QTD_REG_PROCESSADO, QTD_REG_REJEITADOS, QTD_REG_ACEITOS, DTH_TIMESTAMP) VALUES (:GEARDETA-NOM-ARQUIVO, :GEARDETA-SEQ-GERACAO, :HOST-ANO-MOV-ABERTO, :HOST-MES-MOV-ABERTO, :SISTEMAS-DATA-MOV-ABERTO, :SISTEMAS-DATA-MOV-ABERTO, :SISTEMAS-DATA-MOV-ABERTO, 'E' , 'E' , 'TXT' , :GEARDETA-QTD-REG-PROCESSADO, 0, 0, CURRENT TIMESTAMP) END-EXEC. */

            var r0520_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1 = new R0520_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1()
            {
                GEARDETA_NOM_ARQUIVO = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_NOM_ARQUIVO.ToString(),
                GEARDETA_SEQ_GERACAO = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO.ToString(),
                HOST_ANO_MOV_ABERTO = HOST_ANO_MOV_ABERTO.ToString(),
                HOST_MES_MOV_ABERTO = HOST_MES_MOV_ABERTO.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                GEARDETA_QTD_REG_PROCESSADO = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_QTD_REG_PROCESSADO.ToString(),
            };

            R0520_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1.Execute(r0520_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0520_00_EXIT*/

        [StopWatch]
        /*" R0530-00-INCLUI-SIARVRCZ-SECTION */
        private void R0530_00_INCLUI_SIARVRCZ_SECTION()
        {
            /*" -544- MOVE '0530' TO WNR-EXEC-SQL. */
            _.Move("0530", WABEND.WNR_EXEC_SQL);

            /*" -558- PERFORM R0530_00_INCLUI_SIARVRCZ_DB_INSERT_1 */

            R0530_00_INCLUI_SIARVRCZ_DB_INSERT_1();

            /*" -561- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -566- DISPLAY 'PROBLEMAS NO INSERT SI_AR_VERA_CRUZ' ' ' GEARDETA-NOM-ARQUIVO ' ' GEARDETA-SEQ-GERACAO ' ' SIARVRCZ-TIPO-REGISTRO ' ' SIARVRCZ-SEQ-REGISTRO */

                $"PROBLEMAS NO INSERT SI_AR_VERA_CRUZ {GEARDETA.DCLGE_AR_DETALHE.GEARDETA_NOM_ARQUIVO} {GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO} {SIARVRCZ.DCLSI_AR_VERA_CRUZ.SIARVRCZ_TIPO_REGISTRO} {SIARVRCZ.DCLSI_AR_VERA_CRUZ.SIARVRCZ_SEQ_REGISTRO}"
                .Display();

                /*" -568- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -568- ADD 1 TO AC-I-SIARVRCZ. */
            AC_I_SIARVRCZ.Value = AC_I_SIARVRCZ + 1;

        }

        [StopWatch]
        /*" R0530-00-INCLUI-SIARVRCZ-DB-INSERT-1 */
        public void R0530_00_INCLUI_SIARVRCZ_DB_INSERT_1()
        {
            /*" -558- EXEC SQL INSERT INTO SEGUROS.SI_AR_VERA_CRUZ (NOM_ARQUIVO, SEQ_GERACAO, TIPO_REGISTRO, SEQ_REGISTRO, STA_PROCESSAMENTO, COD_ERRO) VALUES (:GEARDETA-NOM-ARQUIVO, :GEARDETA-SEQ-GERACAO, :SIARVRCZ-TIPO-REGISTRO, :SIARVRCZ-SEQ-REGISTRO, :SIARVRCZ-STA-PROCESSAMENTO, NULL) END-EXEC. */

            var r0530_00_INCLUI_SIARVRCZ_DB_INSERT_1_Insert1 = new R0530_00_INCLUI_SIARVRCZ_DB_INSERT_1_Insert1()
            {
                GEARDETA_NOM_ARQUIVO = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_NOM_ARQUIVO.ToString(),
                GEARDETA_SEQ_GERACAO = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO.ToString(),
                SIARVRCZ_TIPO_REGISTRO = SIARVRCZ.DCLSI_AR_VERA_CRUZ.SIARVRCZ_TIPO_REGISTRO.ToString(),
                SIARVRCZ_SEQ_REGISTRO = SIARVRCZ.DCLSI_AR_VERA_CRUZ.SIARVRCZ_SEQ_REGISTRO.ToString(),
                SIARVRCZ_STA_PROCESSAMENTO = SIARVRCZ.DCLSI_AR_VERA_CRUZ.SIARVRCZ_STA_PROCESSAMENTO.ToString(),
            };

            R0530_00_INCLUI_SIARVRCZ_DB_INSERT_1_Insert1.Execute(r0530_00_INCLUI_SIARVRCZ_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0530_00_EXIT*/

        [StopWatch]
        /*" R0600-00-GERA-TRAILLER-SECTION */
        private void R0600_00_GERA_TRAILLER_SECTION()
        {
            /*" -578- MOVE '0600' TO WNR-EXEC-SQL */
            _.Move("0600", WABEND.WNR_EXEC_SQL);

            /*" -580- INITIALIZE REG-SCMOVSIN */
            _.Initialize(
                REG_SCMOVSIN
            );

            /*" -581- MOVE '3' TO TRL-TIPO-REGISTRO */
            _.Move("3", REG_SCMOVSIN.SCMOVSIN_TRAILLER.TRL_TIPO_REGISTRO);

            /*" -583- MOVE 5631 TO TRL-COD-ORIGEM-ARQUIVO */
            _.Move(5631, REG_SCMOVSIN.SCMOVSIN_TRAILLER.TRL_COD_ORIGEM_ARQUIVO);

            /*" -584- MOVE '1' TO TRL-IND-PROCESSAMENTO */
            _.Move("1", REG_SCMOVSIN.SCMOVSIN_TRAILLER.TRL_IND_PROCESSAMENTO);

            /*" -587- MOVE SPACES TO TRL-MENSAGEM-RETORNO TRL-FILLER */
            _.Move("", REG_SCMOVSIN.SCMOVSIN_TRAILLER.TRL_MENSAGEM_RETORNO);
            _.Move("", REG_SCMOVSIN.SCMOVSIN_TRAILLER.TRL_FILLER);


            /*" -588- ADD 1 TO AC-G-CSPAGSIN */
            AC_G_CSPAGSIN.Value = AC_G_CSPAGSIN + 1;

            /*" -592- MOVE AC-G-CSPAGSIN TO TRL-QTD-REGISTROS TRL-NUM-SEQ-REGISTRO */
            _.Move(AC_G_CSPAGSIN, REG_SCMOVSIN.SCMOVSIN_TRAILLER.TRL_QTD_REGISTROS);
            _.Move(AC_G_CSPAGSIN, REG_SCMOVSIN.SCMOVSIN_TRAILLER.TRL_NUM_SEQ_REGISTRO);


            /*" -594- WRITE REG-SCMOVSIN. */
            CSPAGSIN.Write(REG_SCMOVSIN.GetMoveValues().ToString());

            /*" -595- MOVE '3' TO SIARVRCZ-TIPO-REGISTRO */
            _.Move("3", SIARVRCZ.DCLSI_AR_VERA_CRUZ.SIARVRCZ_TIPO_REGISTRO);

            /*" -596- MOVE AC-G-CSPAGSIN TO SIARVRCZ-SEQ-REGISTRO */
            _.Move(AC_G_CSPAGSIN, SIARVRCZ.DCLSI_AR_VERA_CRUZ.SIARVRCZ_SEQ_REGISTRO);

            /*" -597- MOVE '1' TO SIARVRCZ-STA-PROCESSAMENTO */
            _.Move("1", SIARVRCZ.DCLSI_AR_VERA_CRUZ.SIARVRCZ_STA_PROCESSAMENTO);

            /*" -597- PERFORM R0530-00-INCLUI-SIARVRCZ. */

            R0530_00_INCLUI_SIARVRCZ_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_00_EXIT*/

        [StopWatch]
        /*" R0700-00-ALTERA-GEARDETA-SECTION */
        private void R0700_00_ALTERA_GEARDETA_SECTION()
        {
            /*" -607- MOVE '0700' TO WNR-EXEC-SQL. */
            _.Move("0700", WABEND.WNR_EXEC_SQL);

            /*" -613- PERFORM R0700_00_ALTERA_GEARDETA_DB_UPDATE_1 */

            R0700_00_ALTERA_GEARDETA_DB_UPDATE_1();

            /*" -616- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -620- DISPLAY 'PROBLEMAS NO UPDATE GE_AR_DETALHE' ' ' GEARDETA-NOM-ARQUIVO ' ' GEARDETA-SEQ-GERACAO ' ' GEARDETA-QTD-REG-PROCESSADO */

                $"PROBLEMAS NO UPDATE GE_AR_DETALHE {GEARDETA.DCLGE_AR_DETALHE.GEARDETA_NOM_ARQUIVO} {GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO} {GEARDETA.DCLGE_AR_DETALHE.GEARDETA_QTD_REG_PROCESSADO}"
                .Display();

                /*" -622- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -622- ADD 1 TO AC-U-GEARDETA. */
            AC_U_GEARDETA.Value = AC_U_GEARDETA + 1;

        }

        [StopWatch]
        /*" R0700-00-ALTERA-GEARDETA-DB-UPDATE-1 */
        public void R0700_00_ALTERA_GEARDETA_DB_UPDATE_1()
        {
            /*" -613- EXEC SQL UPDATE SEGUROS.GE_AR_DETALHE SET QTD_REG_PROCESSADO = :GEARDETA-QTD-REG-PROCESSADO WHERE NOM_ARQUIVO = :GEARDETA-NOM-ARQUIVO AND SEQ_GERACAO = :GEARDETA-SEQ-GERACAO END-EXEC. */

            var r0700_00_ALTERA_GEARDETA_DB_UPDATE_1_Update1 = new R0700_00_ALTERA_GEARDETA_DB_UPDATE_1_Update1()
            {
                GEARDETA_QTD_REG_PROCESSADO = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_QTD_REG_PROCESSADO.ToString(),
                GEARDETA_NOM_ARQUIVO = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_NOM_ARQUIVO.ToString(),
                GEARDETA_SEQ_GERACAO = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO.ToString(),
            };

            R0700_00_ALTERA_GEARDETA_DB_UPDATE_1_Update1.Execute(r0700_00_ALTERA_GEARDETA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_00_EXIT*/

        [StopWatch]
        /*" R0900-00-DECLARA-SIARDEVC-SECTION */
        private void R0900_00_DECLARA_SIARDEVC_SECTION()
        {
            /*" -637- MOVE '0900' TO WNR-EXEC-SQL */
            _.Move("0900", WABEND.WNR_EXEC_SQL);

            /*" -890- PERFORM R0900_00_DECLARA_SIARDEVC_DB_DECLARE_1 */

            R0900_00_DECLARA_SIARDEVC_DB_DECLARE_1();

            /*" -892- PERFORM R0900_00_DECLARA_SIARDEVC_DB_OPEN_1 */

            R0900_00_DECLARA_SIARDEVC_DB_OPEN_1();

            /*" -895- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -896- DISPLAY 'PROBLEMAS NO OPEN SIARDEVC' */
                _.Display($"PROBLEMAS NO OPEN SIARDEVC");

                /*" -897- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -897- END-IF. */
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARA-SIARDEVC-DB-DECLARE-1 */
        public void R0900_00_DECLARA_SIARDEVC_DB_DECLARE_1()
        {
            /*" -890- EXEC SQL DECLARE C01_SIARDEVC CURSOR FOR SELECT V.NOM_ARQUIVO, V.SEQ_GERACAO, V.TIPO_REGISTRO, V.SEQ_REGISTRO, V.COD_OPERACAO, V.OCORR_HISTORICO, V.NUM_SINISTRO_VC, V.NUM_EXPEDIENTE_VC, V.NUM_APOLICE, V.NUM_ENDOSSO, V.NUM_ITEM, V.COD_RAMO, V.COD_COBERTURA, V.COD_CAUSA, V.DATA_COMUNICADO, V.DATA_OCORRENCIA, V.HORA_OCORRENCIA, V.DATA_MOVIMENTO, V.IND_FAVORECIDO, V.VAL_TOT_MOVIMENTO, V.VAL_PECAS, V.VAL_MAO_OBRA, V.VAL_PARCELA_PEND, V.QTD_PARCELA_PEND, V.VAL_DESC_PARC_PEND, V.DATA_NEGOCIADA, V.VAL_IRF, V.VAL_ISS, V.VAL_INSS, V.VAL_LIQUIDO_PAGTO, V.CGCCPF, V.TIPO_PESSOA, V.NOM_FAVORECIDO, V.IND_DOC_FISCAL, V.NUM_DOC_FISCAL, V.SERIE_DOC_FISCAL, V.DATA_EMISSAO, V.DES_ENDERECO, V.NOM_BAIRRO, V.NOM_CIDADE, V.COD_UF, V.NUM_CEP, V.NUM_DDD, V.NUM_TELEFONE, V.IND_FORMA_PAGTO, V.NUM_IDENTIFICADOR, V.NUM_CHEQUE_INTERNO, V.ORDEM_PAGAMENTO_VC, V.ORDEM_PAGAMENTO, V.COD_BANCO, V.COD_AGENCIA, V.OPERACAO_CONTA, V.COD_CONTA, V.DV_CONTA, V.COD_FAVORECIDO, V.NUM_APOL_SINISTRO, V.STA_PROCESSAMENTO, VALUE(V.COD_ERRO, 0), V.VAL_PISPASEP, V.VAL_COFINS, V.VAL_CSLL, VALUE(V.COD_FONTE, 0), VALUE(V.NUM_RESSARC, 0), VALUE(V.IND_PESSOA_ACORDO, ' ' ), VALUE(V.NUM_CPFCGC_ACORDO, 0), VALUE(V.NOM_RESP_ACORDO, ' ' ), VALUE(V.STA_ACORDO, ' ' ), VALUE(V.DTH_INDENIZACAO, DATE( '0001-01-01' )), VALUE(V.VLR_INDENIZACAO, 0), VALUE(V.VLR_PART_TERCEIROS, 0), VALUE(V.VLR_DIVIDA, 0), VALUE(V.PCT_DESCONTO, 0), VALUE(V.VLR_TOTAL_DESCONTO, 0), VALUE(V.VLR_TOTAL_ACORDO, 0), VALUE(V.COD_MOEDA_ACORDO, 0), VALUE(V.DTH_ACORDO, DATE( '0001-01-01' )), VALUE(V.QTD_PARCELAS_ACORDO, 0), VALUE(V.NUM_PARCELA_ACORDO, 0), VALUE(V.COD_AGENCIA_CEDENT, 0), VALUE(V.NUM_CEDENTE, 0), VALUE(V.NUM_CEDENTE_DV, ' ' ), VALUE(V.DTH_VENCIMENTO, DATE( '0001-01-01' )), VALUE(V.NUM_NOSSO_TITULO, 0), VALUE(V.VLR_TITULO, 0), VALUE(V.NUM_CPFCGC_RECLAMANTE, 0), VALUE(V.NOM_RECLAMANTE, ' ' ), VALUE(V.VLR_RECLAMADO, 0), VALUE(V.VLR_PROVISIONADO, 0), VALUE(V.NUM_SINISTRO_CONV, ' ' ), VALUE(V.NUM_IDENT_CONV, 0), VALUE(V.NUM_IDE_COBR_CONV, 0), VALUE(V.COD_CFOP, 0), VALUE(V.COD_CEST, 0), VALUE(V.NUM_INSCR_ESTADUAL, 0), VALUE(V.NUM_NCM, 0), VALUE(V.NUM_CPF_CNPJ_TOMADOR, 0), VALUE(V.IND_ISENCAO_TRIBUTO, 'N' ), VALUE(V.COD_IMPOSTO_LIMINAR, 0), VALUE(V.COD_PROCESSO_ISENCAO, ' ' ), VALUE(V.VLR_RET_N_EFETUADO, 0) FROM SEGUROS.SI_AR_DETALHE_VC V, SEGUROS.SINISTRO_HISTORICO H WHERE V.NOM_ARQUIVO = 'SCMOVSIN' AND V.STA_PROCESSAMENTO IN ( '3' , 'P' ) AND V.STA_RETORNO = '1' AND V.COD_OPERACAO IN (1081, 2009, 2014, 3001) AND H.NUM_APOL_SINISTRO = V.NUM_APOL_SINISTRO AND H.OCORR_HISTORICO = V.OCORR_HISTORICO AND H.COD_OPERACAO = V.COD_OPERACAO AND H.VAL_OPERACAO <> 0 AND EXISTS ( SELECT A.NUM_APOL_SINISTRO,A.OCORR_HISTORICO FROM SEGUROS.SI_SINI_CHEQUE A WHERE A.NUM_APOL_SINISTRO = V.NUM_APOL_SINISTRO AND A.OCORR_HISTORICO = V.OCORR_HISTORICO ) UNION ALL SELECT V.NOM_ARQUIVO, V.SEQ_GERACAO, V.TIPO_REGISTRO, V.SEQ_REGISTRO, V.COD_OPERACAO, V.OCORR_HISTORICO, V.NUM_SINISTRO_VC, V.NUM_EXPEDIENTE_VC, V.NUM_APOLICE, V.NUM_ENDOSSO, V.NUM_ITEM, V.COD_RAMO, V.COD_COBERTURA, V.COD_CAUSA, V.DATA_COMUNICADO, V.DATA_OCORRENCIA, V.HORA_OCORRENCIA, V.DATA_MOVIMENTO, V.IND_FAVORECIDO, V.VAL_TOT_MOVIMENTO, V.VAL_PECAS, V.VAL_MAO_OBRA, V.VAL_PARCELA_PEND, V.QTD_PARCELA_PEND, V.VAL_DESC_PARC_PEND, V.DATA_NEGOCIADA, V.VAL_IRF, V.VAL_ISS, V.VAL_INSS, V.VAL_LIQUIDO_PAGTO, V.CGCCPF, V.TIPO_PESSOA, V.NOM_FAVORECIDO, V.IND_DOC_FISCAL, V.NUM_DOC_FISCAL, V.SERIE_DOC_FISCAL, V.DATA_EMISSAO, V.DES_ENDERECO, V.NOM_BAIRRO, V.NOM_CIDADE, V.COD_UF, V.NUM_CEP, V.NUM_DDD, V.NUM_TELEFONE, V.IND_FORMA_PAGTO, V.NUM_IDENTIFICADOR, V.NUM_CHEQUE_INTERNO, V.ORDEM_PAGAMENTO_VC, V.ORDEM_PAGAMENTO, V.COD_BANCO, V.COD_AGENCIA, V.OPERACAO_CONTA, V.COD_CONTA, V.DV_CONTA, V.COD_FAVORECIDO, V.NUM_APOL_SINISTRO, V.STA_PROCESSAMENTO, VALUE(V.COD_ERRO, 0), V.VAL_PISPASEP, V.VAL_COFINS, V.VAL_CSLL, VALUE(V.COD_FONTE, 0), VALUE(V.NUM_RESSARC, 0), VALUE(V.IND_PESSOA_ACORDO, ' ' ), VALUE(V.NUM_CPFCGC_ACORDO, 0), VALUE(V.NOM_RESP_ACORDO, ' ' ), VALUE(V.STA_ACORDO, ' ' ), VALUE(V.DTH_INDENIZACAO, DATE( '0001-01-01' )), VALUE(V.VLR_INDENIZACAO, 0), VALUE(V.VLR_PART_TERCEIROS, 0), VALUE(V.VLR_DIVIDA, 0), VALUE(V.PCT_DESCONTO, 0), VALUE(V.VLR_TOTAL_DESCONTO, 0), VALUE(V.VLR_TOTAL_ACORDO, 0), VALUE(V.COD_MOEDA_ACORDO, 0), VALUE(V.DTH_ACORDO, DATE( '0001-01-01' )), VALUE(V.QTD_PARCELAS_ACORDO, 0), VALUE(V.NUM_PARCELA_ACORDO, 0), VALUE(V.COD_AGENCIA_CEDENT, 0), VALUE(V.NUM_CEDENTE, 0), VALUE(V.NUM_CEDENTE_DV, ' ' ), VALUE(V.DTH_VENCIMENTO, DATE( '0001-01-01' )), VALUE(V.NUM_NOSSO_TITULO, 0), VALUE(V.VLR_TITULO, 0), VALUE(V.NUM_CPFCGC_RECLAMANTE, 0), VALUE(V.NOM_RECLAMANTE, ' ' ), VALUE(V.VLR_RECLAMADO, 0), VALUE(V.VLR_PROVISIONADO, 0), VALUE(V.NUM_SINISTRO_CONV, ' ' ), VALUE(V.NUM_IDENT_CONV, 0), VALUE(V.NUM_IDE_COBR_CONV, 0), VALUE(V.COD_CFOP, 0), VALUE(V.COD_CEST, 0), VALUE(V.NUM_INSCR_ESTADUAL, 0), VALUE(V.NUM_NCM, 0), VALUE(V.NUM_CPF_CNPJ_TOMADOR, 0), VALUE(V.IND_ISENCAO_TRIBUTO, 'N' ), VALUE(V.COD_IMPOSTO_LIMINAR, 0), VALUE(V.COD_PROCESSO_ISENCAO, ' ' ), VALUE(V.VLR_RET_N_EFETUADO, 0) FROM SEGUROS.SI_AR_DETALHE_VC V, SEGUROS.SINISTRO_HISTORICO H WHERE V.NOM_ARQUIVO = 'SCMOVSIN' AND V.STA_PROCESSAMENTO = 'R' AND V.STA_RETORNO = '1' AND V.COD_OPERACAO IN (1081, 2009, 2014, 3001) AND H.NUM_APOL_SINISTRO = V.NUM_APOL_SINISTRO AND H.OCORR_HISTORICO = V.OCORR_HISTORICO AND H.COD_OPERACAO = V.COD_OPERACAO AND H.VAL_OPERACAO <> 0 AND EXISTS ( SELECT A.NUM_APOL_SINISTRO,A.OCORR_HISTORICO FROM SEGUROS.SI_SINI_CHEQUE A WHERE A.NUM_APOL_SINISTRO = V.NUM_APOL_SINISTRO AND A.OCORR_HISTORICO = V.OCORR_HISTORICO ) AND EXISTS (SELECT AR.NUM_APOLICE FROM SEGUROS.SI_AR_DETALHE_VC AR WHERE AR.NUM_APOL_SINISTRO = V.NUM_APOL_SINISTRO AND AR.STA_PROCESSAMENTO= 'S' ) ORDER BY 4 END-EXEC. */
            C01_SIARDEVC = new SI9211B_C01_SIARDEVC(false);
            string GetQuery_C01_SIARDEVC()
            {
                var query = @$"SELECT V.NOM_ARQUIVO
							, 
							V.SEQ_GERACAO
							, 
							V.TIPO_REGISTRO
							, 
							V.SEQ_REGISTRO
							, 
							V.COD_OPERACAO
							, 
							V.OCORR_HISTORICO
							, 
							V.NUM_SINISTRO_VC
							, 
							V.NUM_EXPEDIENTE_VC
							, 
							V.NUM_APOLICE
							, 
							V.NUM_ENDOSSO
							, 
							V.NUM_ITEM
							, 
							V.COD_RAMO
							, 
							V.COD_COBERTURA
							, 
							V.COD_CAUSA
							, 
							V.DATA_COMUNICADO
							, 
							V.DATA_OCORRENCIA
							, 
							V.HORA_OCORRENCIA
							, 
							V.DATA_MOVIMENTO
							, 
							V.IND_FAVORECIDO
							, 
							V.VAL_TOT_MOVIMENTO
							, 
							V.VAL_PECAS
							, 
							V.VAL_MAO_OBRA
							, 
							V.VAL_PARCELA_PEND
							, 
							V.QTD_PARCELA_PEND
							, 
							V.VAL_DESC_PARC_PEND
							, 
							V.DATA_NEGOCIADA
							, 
							V.VAL_IRF
							, 
							V.VAL_ISS
							, 
							V.VAL_INSS
							, 
							V.VAL_LIQUIDO_PAGTO
							, 
							V.CGCCPF
							, 
							V.TIPO_PESSOA
							, 
							V.NOM_FAVORECIDO
							, 
							V.IND_DOC_FISCAL
							, 
							V.NUM_DOC_FISCAL
							, 
							V.SERIE_DOC_FISCAL
							, 
							V.DATA_EMISSAO
							, 
							V.DES_ENDERECO
							, 
							V.NOM_BAIRRO
							, 
							V.NOM_CIDADE
							, 
							V.COD_UF
							, 
							V.NUM_CEP
							, 
							V.NUM_DDD
							, 
							V.NUM_TELEFONE
							, 
							V.IND_FORMA_PAGTO
							, 
							V.NUM_IDENTIFICADOR
							, 
							V.NUM_CHEQUE_INTERNO
							, 
							V.ORDEM_PAGAMENTO_VC
							, 
							V.ORDEM_PAGAMENTO
							, 
							V.COD_BANCO
							, 
							V.COD_AGENCIA
							, 
							V.OPERACAO_CONTA
							, 
							V.COD_CONTA
							, 
							V.DV_CONTA
							, 
							V.COD_FAVORECIDO
							, 
							V.NUM_APOL_SINISTRO
							, 
							V.STA_PROCESSAMENTO
							, 
							VALUE(V.COD_ERRO
							, 0)
							, 
							V.VAL_PISPASEP
							, 
							V.VAL_COFINS
							, 
							V.VAL_CSLL
							, 
							VALUE(V.COD_FONTE
							, 0)
							, 
							VALUE(V.NUM_RESSARC
							, 0)
							, 
							VALUE(V.IND_PESSOA_ACORDO
							, ' ' )
							, 
							VALUE(V.NUM_CPFCGC_ACORDO
							, 0)
							, 
							VALUE(V.NOM_RESP_ACORDO
							, ' ' )
							, 
							VALUE(V.STA_ACORDO
							, ' ' )
							, 
							VALUE(V.DTH_INDENIZACAO
							, DATE( '0001-01-01' ))
							, 
							VALUE(V.VLR_INDENIZACAO
							, 0)
							, 
							VALUE(V.VLR_PART_TERCEIROS
							, 0)
							, 
							VALUE(V.VLR_DIVIDA
							, 0)
							, 
							VALUE(V.PCT_DESCONTO
							, 0)
							, 
							VALUE(V.VLR_TOTAL_DESCONTO
							, 0)
							, 
							VALUE(V.VLR_TOTAL_ACORDO
							, 0)
							, 
							VALUE(V.COD_MOEDA_ACORDO
							, 0)
							, 
							VALUE(V.DTH_ACORDO
							, DATE( '0001-01-01' ))
							, 
							VALUE(V.QTD_PARCELAS_ACORDO
							, 0)
							, 
							VALUE(V.NUM_PARCELA_ACORDO
							, 0)
							, 
							VALUE(V.COD_AGENCIA_CEDENT
							, 0)
							, 
							VALUE(V.NUM_CEDENTE
							, 0)
							, 
							VALUE(V.NUM_CEDENTE_DV
							, ' ' )
							, 
							VALUE(V.DTH_VENCIMENTO
							, DATE( '0001-01-01' ))
							, 
							VALUE(V.NUM_NOSSO_TITULO
							, 0)
							, 
							VALUE(V.VLR_TITULO
							, 0)
							, 
							VALUE(V.NUM_CPFCGC_RECLAMANTE
							, 0)
							, 
							VALUE(V.NOM_RECLAMANTE
							, ' ' )
							, 
							VALUE(V.VLR_RECLAMADO
							, 0)
							, 
							VALUE(V.VLR_PROVISIONADO
							, 0)
							, 
							VALUE(V.NUM_SINISTRO_CONV
							, ' ' )
							, 
							VALUE(V.NUM_IDENT_CONV
							, 0)
							, 
							VALUE(V.NUM_IDE_COBR_CONV
							, 0)
							, 
							VALUE(V.COD_CFOP
							, 0)
							, 
							VALUE(V.COD_CEST
							, 0)
							, 
							VALUE(V.NUM_INSCR_ESTADUAL
							, 0)
							, 
							VALUE(V.NUM_NCM
							, 0)
							, 
							VALUE(V.NUM_CPF_CNPJ_TOMADOR
							, 0)
							, 
							VALUE(V.IND_ISENCAO_TRIBUTO
							, 'N' )
							, 
							VALUE(V.COD_IMPOSTO_LIMINAR
							, 0)
							, 
							VALUE(V.COD_PROCESSO_ISENCAO
							, ' ' )
							, 
							VALUE(V.VLR_RET_N_EFETUADO
							, 0) 
							FROM SEGUROS.SI_AR_DETALHE_VC V
							, 
							SEGUROS.SINISTRO_HISTORICO H 
							WHERE V.NOM_ARQUIVO = 'SCMOVSIN' 
							AND V.STA_PROCESSAMENTO IN ( '3'
							, 'P' ) 
							AND V.STA_RETORNO = '1' 
							AND V.COD_OPERACAO IN (1081
							, 2009
							, 2014
							, 3001) 
							AND H.NUM_APOL_SINISTRO = V.NUM_APOL_SINISTRO 
							AND H.OCORR_HISTORICO = V.OCORR_HISTORICO 
							AND H.COD_OPERACAO = V.COD_OPERACAO 
							AND H.VAL_OPERACAO <> 0 
							AND EXISTS 
							( SELECT A.NUM_APOL_SINISTRO
							,A.OCORR_HISTORICO 
							FROM SEGUROS.SI_SINI_CHEQUE A 
							WHERE A.NUM_APOL_SINISTRO = V.NUM_APOL_SINISTRO 
							AND A.OCORR_HISTORICO = V.OCORR_HISTORICO ) 
							UNION ALL 
							SELECT V.NOM_ARQUIVO
							, 
							V.SEQ_GERACAO
							, 
							V.TIPO_REGISTRO
							, 
							V.SEQ_REGISTRO
							, 
							V.COD_OPERACAO
							, 
							V.OCORR_HISTORICO
							, 
							V.NUM_SINISTRO_VC
							, 
							V.NUM_EXPEDIENTE_VC
							, 
							V.NUM_APOLICE
							, 
							V.NUM_ENDOSSO
							, 
							V.NUM_ITEM
							, 
							V.COD_RAMO
							, 
							V.COD_COBERTURA
							, 
							V.COD_CAUSA
							, 
							V.DATA_COMUNICADO
							, 
							V.DATA_OCORRENCIA
							, 
							V.HORA_OCORRENCIA
							, 
							V.DATA_MOVIMENTO
							, 
							V.IND_FAVORECIDO
							, 
							V.VAL_TOT_MOVIMENTO
							, 
							V.VAL_PECAS
							, 
							V.VAL_MAO_OBRA
							, 
							V.VAL_PARCELA_PEND
							, 
							V.QTD_PARCELA_PEND
							, 
							V.VAL_DESC_PARC_PEND
							, 
							V.DATA_NEGOCIADA
							, 
							V.VAL_IRF
							, 
							V.VAL_ISS
							, 
							V.VAL_INSS
							, 
							V.VAL_LIQUIDO_PAGTO
							, 
							V.CGCCPF
							, 
							V.TIPO_PESSOA
							, 
							V.NOM_FAVORECIDO
							, 
							V.IND_DOC_FISCAL
							, 
							V.NUM_DOC_FISCAL
							, 
							V.SERIE_DOC_FISCAL
							, 
							V.DATA_EMISSAO
							, 
							V.DES_ENDERECO
							, 
							V.NOM_BAIRRO
							, 
							V.NOM_CIDADE
							, 
							V.COD_UF
							, 
							V.NUM_CEP
							, 
							V.NUM_DDD
							, 
							V.NUM_TELEFONE
							, 
							V.IND_FORMA_PAGTO
							, 
							V.NUM_IDENTIFICADOR
							, 
							V.NUM_CHEQUE_INTERNO
							, 
							V.ORDEM_PAGAMENTO_VC
							, 
							V.ORDEM_PAGAMENTO
							, 
							V.COD_BANCO
							, 
							V.COD_AGENCIA
							, 
							V.OPERACAO_CONTA
							, 
							V.COD_CONTA
							, 
							V.DV_CONTA
							, 
							V.COD_FAVORECIDO
							, 
							V.NUM_APOL_SINISTRO
							, 
							V.STA_PROCESSAMENTO
							, 
							VALUE(V.COD_ERRO
							, 0)
							, 
							V.VAL_PISPASEP
							, 
							V.VAL_COFINS
							, 
							V.VAL_CSLL
							, 
							VALUE(V.COD_FONTE
							, 0)
							, 
							VALUE(V.NUM_RESSARC
							, 0)
							, 
							VALUE(V.IND_PESSOA_ACORDO
							, ' ' )
							, 
							VALUE(V.NUM_CPFCGC_ACORDO
							, 0)
							, 
							VALUE(V.NOM_RESP_ACORDO
							, ' ' )
							, 
							VALUE(V.STA_ACORDO
							, ' ' )
							, 
							VALUE(V.DTH_INDENIZACAO
							, DATE( '0001-01-01' ))
							, 
							VALUE(V.VLR_INDENIZACAO
							, 0)
							, 
							VALUE(V.VLR_PART_TERCEIROS
							, 0)
							, 
							VALUE(V.VLR_DIVIDA
							, 0)
							, 
							VALUE(V.PCT_DESCONTO
							, 0)
							, 
							VALUE(V.VLR_TOTAL_DESCONTO
							, 0)
							, 
							VALUE(V.VLR_TOTAL_ACORDO
							, 0)
							, 
							VALUE(V.COD_MOEDA_ACORDO
							, 0)
							, 
							VALUE(V.DTH_ACORDO
							, DATE( '0001-01-01' ))
							, 
							VALUE(V.QTD_PARCELAS_ACORDO
							, 0)
							, 
							VALUE(V.NUM_PARCELA_ACORDO
							, 0)
							, 
							VALUE(V.COD_AGENCIA_CEDENT
							, 0)
							, 
							VALUE(V.NUM_CEDENTE
							, 0)
							, 
							VALUE(V.NUM_CEDENTE_DV
							, ' ' )
							, 
							VALUE(V.DTH_VENCIMENTO
							, DATE( '0001-01-01' ))
							, 
							VALUE(V.NUM_NOSSO_TITULO
							, 0)
							, 
							VALUE(V.VLR_TITULO
							, 0)
							, 
							VALUE(V.NUM_CPFCGC_RECLAMANTE
							, 0)
							, 
							VALUE(V.NOM_RECLAMANTE
							, ' ' )
							, 
							VALUE(V.VLR_RECLAMADO
							, 0)
							, 
							VALUE(V.VLR_PROVISIONADO
							, 0)
							, 
							VALUE(V.NUM_SINISTRO_CONV
							, ' ' )
							, 
							VALUE(V.NUM_IDENT_CONV
							, 0)
							, 
							VALUE(V.NUM_IDE_COBR_CONV
							, 0)
							, 
							VALUE(V.COD_CFOP
							, 0)
							, 
							VALUE(V.COD_CEST
							, 0)
							, 
							VALUE(V.NUM_INSCR_ESTADUAL
							, 0)
							, 
							VALUE(V.NUM_NCM
							, 0)
							, 
							VALUE(V.NUM_CPF_CNPJ_TOMADOR
							, 0)
							, 
							VALUE(V.IND_ISENCAO_TRIBUTO
							, 'N' )
							, 
							VALUE(V.COD_IMPOSTO_LIMINAR
							, 0)
							, 
							VALUE(V.COD_PROCESSO_ISENCAO
							, ' ' )
							, 
							VALUE(V.VLR_RET_N_EFETUADO
							, 0) 
							FROM SEGUROS.SI_AR_DETALHE_VC V
							, 
							SEGUROS.SINISTRO_HISTORICO H 
							WHERE V.NOM_ARQUIVO = 'SCMOVSIN' 
							AND V.STA_PROCESSAMENTO = 'R' 
							AND V.STA_RETORNO = '1' 
							AND V.COD_OPERACAO IN (1081
							, 2009
							, 2014
							, 3001) 
							AND H.NUM_APOL_SINISTRO = V.NUM_APOL_SINISTRO 
							AND H.OCORR_HISTORICO = V.OCORR_HISTORICO 
							AND H.COD_OPERACAO = V.COD_OPERACAO 
							AND H.VAL_OPERACAO <> 0 
							AND EXISTS 
							( SELECT A.NUM_APOL_SINISTRO
							,A.OCORR_HISTORICO 
							FROM SEGUROS.SI_SINI_CHEQUE A 
							WHERE A.NUM_APOL_SINISTRO = V.NUM_APOL_SINISTRO 
							AND A.OCORR_HISTORICO = V.OCORR_HISTORICO ) 
							AND EXISTS 
							(SELECT AR.NUM_APOLICE 
							FROM SEGUROS.SI_AR_DETALHE_VC AR 
							WHERE AR.NUM_APOL_SINISTRO = V.NUM_APOL_SINISTRO 
							AND AR.STA_PROCESSAMENTO= 'S' ) 
							ORDER BY 4";

                return query;
            }
            C01_SIARDEVC.GetQueryEvent += GetQuery_C01_SIARDEVC;

        }

        [StopWatch]
        /*" R0900-00-DECLARA-SIARDEVC-DB-OPEN-1 */
        public void R0900_00_DECLARA_SIARDEVC_DB_OPEN_1()
        {
            /*" -892- EXEC SQL OPEN C01_SIARDEVC END-EXEC. */

            C01_SIARDEVC.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_00_EXIT*/

        [StopWatch]
        /*" R0910-00-LE-SIARDEVC-SECTION */
        private void R0910_00_LE_SIARDEVC_SECTION()
        {
            /*" -907- MOVE '0910' TO WNR-EXEC-SQL. */
            _.Move("0910", WABEND.WNR_EXEC_SQL);

            /*" -1008- PERFORM R0910_00_LE_SIARDEVC_DB_FETCH_1 */

            R0910_00_LE_SIARDEVC_DB_FETCH_1();

            /*" -1011- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1013- IF SIARDEVC-COD-OPERACAO EQUAL 1081 OR 1082 OR 1083 OR 1084 */

                if (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_OPERACAO.In("1081", "1082", "1083", "1084"))
                {

                    /*" -1014- ADD 1 TO CT-L-INDENIZA */
                    CT_L_INDENIZA.Value = CT_L_INDENIZA + 1;

                    /*" -1015- END-IF */
                }


                /*" -1016- IF SIARDEVC-STA-PROCESSAMENTO = 'R' */

                if (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO == "R")
                {

                    /*" -1017- ADD 1 TO AC-L-SIARDEVC-R */
                    AC_L_SIARDEVC_R.Value = AC_L_SIARDEVC_R + 1;

                    /*" -1022- DISPLAY 'SINI-RECOMD: ' SIARDEVC-NUM-APOL-SINISTRO ' STA: ' SIARDEVC-STA-PROCESSAMENTO ' FRM-PGTO: ' SIARDEVC-IND-FORMA-PAGTO ' HIST: ' SIARDEVC-OCORR-HISTORICO ' CHQ: ' SIARDEVC-NUM-CHEQUE-INTERNO */

                    $"SINI-RECOMD: {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO} STA: {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO} FRM-PGTO: {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_IND_FORMA_PAGTO} HIST: {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO} CHQ: {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CHEQUE_INTERNO}"
                    .Display();

                    /*" -1023- ELSE */
                }
                else
                {


                    /*" -1024- ADD 1 TO AC-L-SIARDEVC */
                    AC_L_SIARDEVC.Value = AC_L_SIARDEVC + 1;

                    /*" -1025- ELSE */
                }

            }
            else
            {


                /*" -1026- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1027- MOVE 'S' TO WFIM-SIARDEVC */
                    _.Move("S", WFIM_SIARDEVC);

                    /*" -1027- PERFORM R0910_00_LE_SIARDEVC_DB_CLOSE_1 */

                    R0910_00_LE_SIARDEVC_DB_CLOSE_1();

                    /*" -1029- ELSE */
                }
                else
                {


                    /*" -1030- DISPLAY 'PROBLEMAS NO FETCH SIARDEVC' */
                    _.Display($"PROBLEMAS NO FETCH SIARDEVC");

                    /*" -1030- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0910-00-LE-SIARDEVC-DB-FETCH-1 */
        public void R0910_00_LE_SIARDEVC_DB_FETCH_1()
        {
            /*" -1008- EXEC SQL FETCH C01_SIARDEVC INTO :SIARDEVC-NOM-ARQUIVO, :SIARDEVC-SEQ-GERACAO, :SIARDEVC-TIPO-REGISTRO, :SIARDEVC-SEQ-REGISTRO, :SIARDEVC-COD-OPERACAO, :SIARDEVC-OCORR-HISTORICO, :SIARDEVC-NUM-SINISTRO-VC, :SIARDEVC-NUM-EXPEDIENTE-VC, :SIARDEVC-NUM-APOLICE, :SIARDEVC-NUM-ENDOSSO, :SIARDEVC-NUM-ITEM, :SIARDEVC-COD-RAMO, :SIARDEVC-COD-COBERTURA, :SIARDEVC-COD-CAUSA, :SIARDEVC-DATA-COMUNICADO, :SIARDEVC-DATA-OCORRENCIA, :SIARDEVC-HORA-OCORRENCIA, :SIARDEVC-DATA-MOVIMENTO, :SIARDEVC-IND-FAVORECIDO, :SIARDEVC-VAL-TOT-MOVIMENTO, :SIARDEVC-VAL-PECAS, :SIARDEVC-VAL-MAO-OBRA, :SIARDEVC-VAL-PARCELA-PEND, :SIARDEVC-QTD-PARCELA-PEND, :SIARDEVC-VAL-DESC-PARC-PEND, :SIARDEVC-DATA-NEGOCIADA, :SIARDEVC-VAL-IRF, :SIARDEVC-VAL-ISS, :SIARDEVC-VAL-INSS, :SIARDEVC-VAL-LIQUIDO-PAGTO, :SIARDEVC-CGCCPF, :SIARDEVC-TIPO-PESSOA, :SIARDEVC-NOM-FAVORECIDO, :SIARDEVC-IND-DOC-FISCAL, :SIARDEVC-NUM-DOC-FISCAL, :SIARDEVC-SERIE-DOC-FISCAL, :SIARDEVC-DATA-EMISSAO, :SIARDEVC-DES-ENDERECO, :SIARDEVC-NOM-BAIRRO, :SIARDEVC-NOM-CIDADE, :SIARDEVC-COD-UF, :SIARDEVC-NUM-CEP, :SIARDEVC-NUM-DDD, :SIARDEVC-NUM-TELEFONE, :SIARDEVC-IND-FORMA-PAGTO, :SIARDEVC-NUM-IDENTIFICADOR, :SIARDEVC-NUM-CHEQUE-INTERNO, :SIARDEVC-ORDEM-PAGAMENTO-VC, :SIARDEVC-ORDEM-PAGAMENTO, :SIARDEVC-COD-BANCO, :SIARDEVC-COD-AGENCIA, :SIARDEVC-OPERACAO-CONTA, :SIARDEVC-COD-CONTA, :SIARDEVC-DV-CONTA, :SIARDEVC-COD-FAVORECIDO, :SIARDEVC-NUM-APOL-SINISTRO, :SIARDEVC-STA-PROCESSAMENTO, :SIARDEVC-COD-ERRO, :SIARDEVC-VAL-PISPASEP, :SIARDEVC-VAL-COFINS, :SIARDEVC-VAL-CSLL, :SIARDEVC-COD-FONTE, :SIARDEVC-NUM-RESSARC, :SIARDEVC-IND-PESSOA-ACORDO, :SIARDEVC-NUM-CPFCGC-ACORDO, :SIARDEVC-NOM-RESP-ACORDO, :SIARDEVC-STA-ACORDO, :SIARDEVC-DTH-INDENIZACAO, :SIARDEVC-VLR-INDENIZACAO, :SIARDEVC-VLR-PART-TERCEIROS, :SIARDEVC-VLR-DIVIDA, :SIARDEVC-PCT-DESCONTO, :SIARDEVC-VLR-TOTAL-DESCONTO, :SIARDEVC-VLR-TOTAL-ACORDO, :SIARDEVC-COD-MOEDA-ACORDO, :SIARDEVC-DTH-ACORDO, :SIARDEVC-QTD-PARCELAS-ACORDO, :SIARDEVC-NUM-PARCELA-ACORDO, :SIARDEVC-COD-AGENCIA-CEDENT, :SIARDEVC-NUM-CEDENTE, :SIARDEVC-NUM-CEDENTE-DV, :SIARDEVC-DTH-VENCIMENTO, :SIARDEVC-NUM-NOSSO-TITULO, :SIARDEVC-VLR-TITULO, :SIARDEVC-NUM-CPFCGC-RECLAMANTE, :SIARDEVC-NOM-RECLAMANTE, :SIARDEVC-VLR-RECLAMADO, :SIARDEVC-VLR-PROVISIONADO, :SIARDEVC-NUM-SINISTRO-CONV, :SIARDEVC-NUM-IDENT-CONV, :SIARDEVC-NUM-IDE-COBR-CONV, :SIARDEVC-COD-CFOP, :SIARDEVC-COD-CEST, :SIARDEVC-NUM-INSCR-ESTADUAL, :SIARDEVC-NUM-NCM, :SIARDEVC-NUM-CPF-CNPJ-TOMADOR, :SIARDEVC-IND-ISENCAO-TRIBUTO, :SIARDEVC-COD-IMPOSTO-LIMINAR, :SIARDEVC-COD-PROCESSO-ISENCAO, :SIARDEVC-VLR-RET-N-EFETUADO END-EXEC. */

            if (C01_SIARDEVC.Fetch())
            {
                _.Move(C01_SIARDEVC.SIARDEVC_NOM_ARQUIVO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_ARQUIVO);
                _.Move(C01_SIARDEVC.SIARDEVC_SEQ_GERACAO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_GERACAO);
                _.Move(C01_SIARDEVC.SIARDEVC_TIPO_REGISTRO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_REGISTRO);
                _.Move(C01_SIARDEVC.SIARDEVC_SEQ_REGISTRO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_REGISTRO);
                _.Move(C01_SIARDEVC.SIARDEVC_COD_OPERACAO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_OPERACAO);
                _.Move(C01_SIARDEVC.SIARDEVC_OCORR_HISTORICO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO);
                _.Move(C01_SIARDEVC.SIARDEVC_NUM_SINISTRO_VC, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_SINISTRO_VC);
                _.Move(C01_SIARDEVC.SIARDEVC_NUM_EXPEDIENTE_VC, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_EXPEDIENTE_VC);
                _.Move(C01_SIARDEVC.SIARDEVC_NUM_APOLICE, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE);
                _.Move(C01_SIARDEVC.SIARDEVC_NUM_ENDOSSO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_ENDOSSO);
                _.Move(C01_SIARDEVC.SIARDEVC_NUM_ITEM, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_ITEM);
                _.Move(C01_SIARDEVC.SIARDEVC_COD_RAMO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_RAMO);
                _.Move(C01_SIARDEVC.SIARDEVC_COD_COBERTURA, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_COBERTURA);
                _.Move(C01_SIARDEVC.SIARDEVC_COD_CAUSA, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_CAUSA);
                _.Move(C01_SIARDEVC.SIARDEVC_DATA_COMUNICADO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_COMUNICADO);
                _.Move(C01_SIARDEVC.SIARDEVC_DATA_OCORRENCIA, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_OCORRENCIA);
                _.Move(C01_SIARDEVC.SIARDEVC_HORA_OCORRENCIA, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_HORA_OCORRENCIA);
                _.Move(C01_SIARDEVC.SIARDEVC_DATA_MOVIMENTO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_MOVIMENTO);
                _.Move(C01_SIARDEVC.SIARDEVC_IND_FAVORECIDO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_IND_FAVORECIDO);
                _.Move(C01_SIARDEVC.SIARDEVC_VAL_TOT_MOVIMENTO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_TOT_MOVIMENTO);
                _.Move(C01_SIARDEVC.SIARDEVC_VAL_PECAS, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_PECAS);
                _.Move(C01_SIARDEVC.SIARDEVC_VAL_MAO_OBRA, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_MAO_OBRA);
                _.Move(C01_SIARDEVC.SIARDEVC_VAL_PARCELA_PEND, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_PARCELA_PEND);
                _.Move(C01_SIARDEVC.SIARDEVC_QTD_PARCELA_PEND, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_QTD_PARCELA_PEND);
                _.Move(C01_SIARDEVC.SIARDEVC_VAL_DESC_PARC_PEND, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_DESC_PARC_PEND);
                _.Move(C01_SIARDEVC.SIARDEVC_DATA_NEGOCIADA, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_NEGOCIADA);
                _.Move(C01_SIARDEVC.SIARDEVC_VAL_IRF, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_IRF);
                _.Move(C01_SIARDEVC.SIARDEVC_VAL_ISS, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_ISS);
                _.Move(C01_SIARDEVC.SIARDEVC_VAL_INSS, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_INSS);
                _.Move(C01_SIARDEVC.SIARDEVC_VAL_LIQUIDO_PAGTO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_LIQUIDO_PAGTO);
                _.Move(C01_SIARDEVC.SIARDEVC_CGCCPF, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_CGCCPF);
                _.Move(C01_SIARDEVC.SIARDEVC_TIPO_PESSOA, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_PESSOA);
                _.Move(C01_SIARDEVC.SIARDEVC_NOM_FAVORECIDO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_FAVORECIDO);
                _.Move(C01_SIARDEVC.SIARDEVC_IND_DOC_FISCAL, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_IND_DOC_FISCAL);
                _.Move(C01_SIARDEVC.SIARDEVC_NUM_DOC_FISCAL, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_DOC_FISCAL);
                _.Move(C01_SIARDEVC.SIARDEVC_SERIE_DOC_FISCAL, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SERIE_DOC_FISCAL);
                _.Move(C01_SIARDEVC.SIARDEVC_DATA_EMISSAO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_EMISSAO);
                _.Move(C01_SIARDEVC.SIARDEVC_DES_ENDERECO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DES_ENDERECO);
                _.Move(C01_SIARDEVC.SIARDEVC_NOM_BAIRRO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_BAIRRO);
                _.Move(C01_SIARDEVC.SIARDEVC_NOM_CIDADE, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_CIDADE);
                _.Move(C01_SIARDEVC.SIARDEVC_COD_UF, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_UF);
                _.Move(C01_SIARDEVC.SIARDEVC_NUM_CEP, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CEP);
                _.Move(C01_SIARDEVC.SIARDEVC_NUM_DDD, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_DDD);
                _.Move(C01_SIARDEVC.SIARDEVC_NUM_TELEFONE, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_TELEFONE);
                _.Move(C01_SIARDEVC.SIARDEVC_IND_FORMA_PAGTO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_IND_FORMA_PAGTO);
                _.Move(C01_SIARDEVC.SIARDEVC_NUM_IDENTIFICADOR, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_IDENTIFICADOR);
                _.Move(C01_SIARDEVC.SIARDEVC_NUM_CHEQUE_INTERNO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CHEQUE_INTERNO);
                _.Move(C01_SIARDEVC.SIARDEVC_ORDEM_PAGAMENTO_VC, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_ORDEM_PAGAMENTO_VC);
                _.Move(C01_SIARDEVC.SIARDEVC_ORDEM_PAGAMENTO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_ORDEM_PAGAMENTO);
                _.Move(C01_SIARDEVC.SIARDEVC_COD_BANCO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_BANCO);
                _.Move(C01_SIARDEVC.SIARDEVC_COD_AGENCIA, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_AGENCIA);
                _.Move(C01_SIARDEVC.SIARDEVC_OPERACAO_CONTA, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OPERACAO_CONTA);
                _.Move(C01_SIARDEVC.SIARDEVC_COD_CONTA, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_CONTA);
                _.Move(C01_SIARDEVC.SIARDEVC_DV_CONTA, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DV_CONTA);
                _.Move(C01_SIARDEVC.SIARDEVC_COD_FAVORECIDO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_FAVORECIDO);
                _.Move(C01_SIARDEVC.SIARDEVC_NUM_APOL_SINISTRO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO);
                _.Move(C01_SIARDEVC.SIARDEVC_STA_PROCESSAMENTO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO);
                _.Move(C01_SIARDEVC.SIARDEVC_COD_ERRO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO);
                _.Move(C01_SIARDEVC.SIARDEVC_VAL_PISPASEP, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_PISPASEP);
                _.Move(C01_SIARDEVC.SIARDEVC_VAL_COFINS, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_COFINS);
                _.Move(C01_SIARDEVC.SIARDEVC_VAL_CSLL, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_CSLL);
                _.Move(C01_SIARDEVC.SIARDEVC_COD_FONTE, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_FONTE);
                _.Move(C01_SIARDEVC.SIARDEVC_NUM_RESSARC, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_RESSARC);
                _.Move(C01_SIARDEVC.SIARDEVC_IND_PESSOA_ACORDO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_IND_PESSOA_ACORDO);
                _.Move(C01_SIARDEVC.SIARDEVC_NUM_CPFCGC_ACORDO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CPFCGC_ACORDO);
                _.Move(C01_SIARDEVC.SIARDEVC_NOM_RESP_ACORDO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_RESP_ACORDO);
                _.Move(C01_SIARDEVC.SIARDEVC_STA_ACORDO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_ACORDO);
                _.Move(C01_SIARDEVC.SIARDEVC_DTH_INDENIZACAO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DTH_INDENIZACAO);
                _.Move(C01_SIARDEVC.SIARDEVC_VLR_INDENIZACAO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VLR_INDENIZACAO);
                _.Move(C01_SIARDEVC.SIARDEVC_VLR_PART_TERCEIROS, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VLR_PART_TERCEIROS);
                _.Move(C01_SIARDEVC.SIARDEVC_VLR_DIVIDA, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VLR_DIVIDA);
                _.Move(C01_SIARDEVC.SIARDEVC_PCT_DESCONTO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_PCT_DESCONTO);
                _.Move(C01_SIARDEVC.SIARDEVC_VLR_TOTAL_DESCONTO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VLR_TOTAL_DESCONTO);
                _.Move(C01_SIARDEVC.SIARDEVC_VLR_TOTAL_ACORDO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VLR_TOTAL_ACORDO);
                _.Move(C01_SIARDEVC.SIARDEVC_COD_MOEDA_ACORDO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_MOEDA_ACORDO);
                _.Move(C01_SIARDEVC.SIARDEVC_DTH_ACORDO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DTH_ACORDO);
                _.Move(C01_SIARDEVC.SIARDEVC_QTD_PARCELAS_ACORDO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_QTD_PARCELAS_ACORDO);
                _.Move(C01_SIARDEVC.SIARDEVC_NUM_PARCELA_ACORDO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_PARCELA_ACORDO);
                _.Move(C01_SIARDEVC.SIARDEVC_COD_AGENCIA_CEDENT, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_AGENCIA_CEDENT);
                _.Move(C01_SIARDEVC.SIARDEVC_NUM_CEDENTE, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CEDENTE);
                _.Move(C01_SIARDEVC.SIARDEVC_NUM_CEDENTE_DV, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CEDENTE_DV);
                _.Move(C01_SIARDEVC.SIARDEVC_DTH_VENCIMENTO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DTH_VENCIMENTO);
                _.Move(C01_SIARDEVC.SIARDEVC_NUM_NOSSO_TITULO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_NOSSO_TITULO);
                _.Move(C01_SIARDEVC.SIARDEVC_VLR_TITULO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VLR_TITULO);
                _.Move(C01_SIARDEVC.SIARDEVC_NUM_CPFCGC_RECLAMANTE, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CPFCGC_RECLAMANTE);
                _.Move(C01_SIARDEVC.SIARDEVC_NOM_RECLAMANTE, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_RECLAMANTE);
                _.Move(C01_SIARDEVC.SIARDEVC_VLR_RECLAMADO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VLR_RECLAMADO);
                _.Move(C01_SIARDEVC.SIARDEVC_VLR_PROVISIONADO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VLR_PROVISIONADO);
                _.Move(C01_SIARDEVC.SIARDEVC_NUM_SINISTRO_CONV, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_SINISTRO_CONV);
                _.Move(C01_SIARDEVC.SIARDEVC_NUM_IDENT_CONV, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_IDENT_CONV);
                _.Move(C01_SIARDEVC.SIARDEVC_NUM_IDE_COBR_CONV, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_IDE_COBR_CONV);
                _.Move(C01_SIARDEVC.SIARDEVC_COD_CFOP, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_CFOP);
                _.Move(C01_SIARDEVC.SIARDEVC_COD_CEST, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_CEST);
                _.Move(C01_SIARDEVC.SIARDEVC_NUM_INSCR_ESTADUAL, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_INSCR_ESTADUAL);
                _.Move(C01_SIARDEVC.SIARDEVC_NUM_NCM, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_NCM);
                _.Move(C01_SIARDEVC.SIARDEVC_NUM_CPF_CNPJ_TOMADOR, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CPF_CNPJ_TOMADOR);
                _.Move(C01_SIARDEVC.SIARDEVC_IND_ISENCAO_TRIBUTO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_IND_ISENCAO_TRIBUTO);
                _.Move(C01_SIARDEVC.SIARDEVC_COD_IMPOSTO_LIMINAR, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_IMPOSTO_LIMINAR);
                _.Move(C01_SIARDEVC.SIARDEVC_COD_PROCESSO_ISENCAO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_PROCESSO_ISENCAO);
                _.Move(C01_SIARDEVC.SIARDEVC_VLR_RET_N_EFETUADO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VLR_RET_N_EFETUADO);
            }

        }

        [StopWatch]
        /*" R0910-00-LE-SIARDEVC-DB-CLOSE-1 */
        public void R0910_00_LE_SIARDEVC_DB_CLOSE_1()
        {
            /*" -1027- EXEC SQL CLOSE C01_SIARDEVC END-EXEC */

            C01_SIARDEVC.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-SIARDEVC-SECTION */
        private void R1000_00_PROCESSA_SIARDEVC_SECTION()
        {
            /*" -1040- MOVE '1000' TO WNR-EXEC-SQL */
            _.Move("1000", WABEND.WNR_EXEC_SQL);

            /*" -1041- IF SIARDEVC-NUM-CHEQUE-INTERNO EQUAL 0 */

            if (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CHEQUE_INTERNO == 0)
            {

                /*" -1047- DISPLAY 'SULAMERICA SEM NUM CHEQUE INTERNO TAB ' 'SI_AR_DETALAHE_VC' ' SIN ' SIARDEVC-NUM-APOL-SINISTRO ' OCO ' SIARDEVC-OCORR-HISTORICO ' OPE ' SIARDEVC-COD-OPERACAO . */

                $"SULAMERICA SEM NUM CHEQUE INTERNO TAB SI_AR_DETALAHE_VC SIN {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO} OCO {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO} OPE {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_OPERACAO}"
                .Display();
            }


            /*" -1049- PERFORM R10000-LE-CHEQUES-EMITIDOS. */

            R10000_LE_CHEQUES_EMITIDOS_SECTION();

            /*" -1094- MOVE SISINCHE-NUM-CHEQUE-INTERNO TO SIARDEVC-NUM-CHEQUE-INTERNO. */
            _.Move(SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_NUM_CHEQUE_INTERNO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CHEQUE_INTERNO);

            /*" -1095- DISPLAY ' ' */
            _.Display($" ");

            /*" -1104- DISPLAY 'SINIS: ' SIARDEVC-NUM-APOL-SINISTRO ' STA: ' SIARDEVC-STA-PROCESSAMENTO ' PGTO: ' SIARDEVC-IND-FORMA-PAGTO ' OC: ' SIARDEVC-OCORR-HISTORICO ' CHEQ: ' SIARDEVC-NUM-CHEQUE-INTERNO ' DT: ' CHEQUEMI-DATA-MOVIMENTO ' VL: ' SIARDEVC-VAL-LIQUIDO-PAGTO */

            $"SINIS: {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO} STA: {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO} PGTO: {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_IND_FORMA_PAGTO} OC: {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO} CHEQ: {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CHEQUE_INTERNO} DT: {CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_DATA_MOVIMENTO} VL: {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_LIQUIDO_PAGTO}"
            .Display();

            /*" -1105- IF SIARDEVC-STA-PROCESSAMENTO EQUAL 'P' OR 'R' */

            if (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO.In("P", "R"))
            {

                /*" -1106- IF CHEQUEMI-SIT-REGISTRO EQUAL '2' */

                if (CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_SIT_REGISTRO == "2")
                {

                    /*" -1108- PERFORM R1050-00-CHECA-PT */

                    R1050_00_CHECA_PT_SECTION();

                    /*" -1109- IF WS-PERDA-TOTAL EQUAL 'SIM' */

                    if (WS_PERDA_TOTAL == "SIM")
                    {

                        /*" -1110- DISPLAY '... PASSOU AQUI:  � PT ' */
                        _.Display($"... PASSOU AQUI:  � PT ");

                        /*" -1114- PERFORM R1010-00-CHECA-ESTORNO */

                        R1010_00_CHECA_ESTORNO_SECTION();

                        /*" -1115- ELSE */
                    }
                    else
                    {


                        /*" -1118- MOVE '3' TO SIARDEVC-STA-PROCESSAMENTO */
                        _.Move("3", SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO);

                        /*" -1119- GO TO R1000-80-UPDT-SIARDEVC */

                        R1000_80_UPDT_SIARDEVC(); //GOTO
                        return;

                        /*" -1120- END-IF */
                    }


                    /*" -1121- ELSE */
                }
                else
                {


                    /*" -1125- IF CHEQUEMI-DATA-MOVIMENTO GREATER HOST-DATA-30 */

                    if (CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_DATA_MOVIMENTO > HOST_DATA_30)
                    {

                        /*" -1126- GO TO R1000-90-LE-SIARDEVC */

                        R1000_90_LE_SIARDEVC(); //GOTO
                        return;

                        /*" -1130- ELSE */
                    }
                    else
                    {


                        /*" -1131- IF SIARDEVC-IND-FORMA-PAGTO = '3' */

                        if (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_IND_FORMA_PAGTO == "3")
                        {

                            /*" -1132- ADD 1 TO WS-QT-SEM-RETORNO */
                            WS_QT_SEM_RETORNO.Value = WS_QT_SEM_RETORNO + 1;

                            /*" -1133- GO TO R1000-90-LE-SIARDEVC */

                            R1000_90_LE_SIARDEVC(); //GOTO
                            return;

                            /*" -1134- ELSE */
                        }
                        else
                        {


                            /*" -1135- MOVE '6' TO SIARDEVC-STA-PROCESSAMENTO */
                            _.Move("6", SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO);

                            /*" -1136- END-IF */
                        }


                        /*" -1137- END-IF */
                    }


                    /*" -1142- END-IF */
                }


                /*" -1149- END-IF. */
            }


            /*" -1150- IF SIARDEVC-VAL-LIQUIDO-PAGTO EQUAL 0 */

            if (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_LIQUIDO_PAGTO == 0)
            {

                /*" -1164- COMPUTE SIARDEVC-VAL-LIQUIDO-PAGTO = SIARDEVC-VAL-TOT-MOVIMENTO - SIARDEVC-VAL-DESC-PARC-PEND - SIARDEVC-VAL-IRF - SIARDEVC-VAL-ISS - SIARDEVC-VAL-INSS - SIARDEVC-VAL-PISPASEP - SIARDEVC-VAL-COFINS - SIARDEVC-VAL-CSLL. */
                SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_LIQUIDO_PAGTO.Value = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_TOT_MOVIMENTO - SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_DESC_PARC_PEND - SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_IRF - SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_ISS - SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_INSS - SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_PISPASEP - SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_COFINS - SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_CSLL;
            }


            /*" -1165- IF CHEQUEMI-TIPO-PAGAMENTO EQUAL '1' */

            if (CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_TIPO_PAGAMENTO == "1")
            {

                /*" -1166- PERFORM R11000-ACESSA-CHEQUE-EXTERNO */

                R11000_ACESSA_CHEQUE_EXTERNO_SECTION();

                /*" -1167- IF LOTECHEQ-NUM-CHEQUE EQUAL ZEROS */

                if (LOTECHEQ.DCLLOTE_CHEQUES.LOTECHEQ_NUM_CHEQUE == 00)
                {

                    /*" -1168- MOVE SIARDEVC-NUM-CHEQUE-INTERNO TO LOTECHEQ-NUM-CHEQUE */
                    _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CHEQUE_INTERNO, LOTECHEQ.DCLLOTE_CHEQUES.LOTECHEQ_NUM_CHEQUE);

                    /*" -1169- END-IF */
                }


                /*" -1173- MOVE LOTECHEQ-NUM-CHEQUE TO SIARDEVC-NUM-IDENTIFICADOR. */
                _.Move(LOTECHEQ.DCLLOTE_CHEQUES.LOTECHEQ_NUM_CHEQUE, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_IDENTIFICADOR);
            }


            /*" -1175- MOVE '1000' TO WNR-EXEC-SQL */
            _.Move("1000", WABEND.WNR_EXEC_SQL);

            /*" -1176- IF SIARDEVC-COD-ERRO NOT EQUAL ZEROS */

            if (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO != 00)
            {

                /*" -1177- PERFORM R1100-00-LE-SIERRO */

                R1100_00_LE_SIERRO_SECTION();

                /*" -1178- ELSE */
            }
            else
            {


                /*" -1180- MOVE SPACES TO SIERRO-DES-ERRO. */
                _.Move("", SIERRO.DCLSI_ERRO.SIERRO_DES_ERRO);
            }


            /*" -1182- PERFORM R1200-00-GERA-DETALHE */

            R1200_00_GERA_DETALHE_SECTION();

            /*" -1183- MOVE '2' TO SIARREVC-TIPO-REGISTRO-VC */
            _.Move("2", SIARREVC.DCLSI_AR_RETORNO_VC.SIARREVC_TIPO_REGISTRO_VC);

            /*" -1184- MOVE AC-G-CSPAGSIN TO SIARREVC-SEQ-REGISTRO-VC */
            _.Move(AC_G_CSPAGSIN, SIARREVC.DCLSI_AR_RETORNO_VC.SIARREVC_SEQ_REGISTRO_VC);

            /*" -1186- PERFORM R1300-00-INCLUI-SIARREVC */

            R1300_00_INCLUI_SIARREVC_SECTION();

            /*" -1187- IF SIARDEVC-STA-PROCESSAMENTO EQUAL '3' */

            if (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO == "3")
            {

                /*" -1188- MOVE '7' TO SIARDEVC-STA-PROCESSAMENTO */
                _.Move("7", SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO);

                /*" -1188- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R1000_80_UPDT_SIARDEVC */

            R1000_80_UPDT_SIARDEVC();

        }

        [StopWatch]
        /*" R1000-80-UPDT-SIARDEVC */
        private void R1000_80_UPDT_SIARDEVC(bool isPerform = false)
        {
            /*" -1196- DISPLAY '  ATU ' SIARDEVC-STA-PROCESSAMENTO ' CHEQUE ' SIARDEVC-NUM-CHEQUE-INTERNO ' OP ' SIARDEVC-COD-OPERACAO */

            $"  ATU {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO} CHEQUE {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CHEQUE_INTERNO} OP {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_OPERACAO}"
            .Display();

            /*" -1198- PERFORM R1400-00-ALTERA-SIARDEVC. */

            R1400_00_ALTERA_SIARDEVC_SECTION();

            /*" -1202- IF SIARDEVC-COD-OPERACAO EQUAL 1081 OR 1082 OR 1083 OR 1084 */

            if (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_OPERACAO.In("1081", "1082", "1083", "1084"))
            {

                /*" -1203- PERFORM R1450-CHECA-OP-BAIXA */

                R1450_CHECA_OP_BAIXA_SECTION();

                /*" -1204- IF NAO-ENCONTROU */

                if (WS_ENCONTROU["NAO_ENCONTROU"])
                {

                    /*" -1205- GO TO R1000-90-LE-SIARDEVC */

                    R1000_90_LE_SIARDEVC(); //GOTO
                    return;

                    /*" -1206- END-IF */
                }


                /*" -1208- MOVE SIARDEVC-NUM-APOL-SINISTRO TO SINISHIS-NUM-APOL-SINISTRO */
                _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO);

                /*" -1210- MOVE SIARDEVC-OCORR-HISTORICO TO SINISHIS-OCORR-HISTORICO */
                _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO);

                /*" -1212- ADD 1 TO CT-P-INDENIZA */
                CT_P_INDENIZA.Value = CT_P_INDENIZA + 1;

                /*" -1215- COMPUTE SINISHIS-COD-OPERACAO = SIARDEVC-COD-OPERACAO - 80 */
                SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.Value = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_OPERACAO - 80;

                /*" -1216- DISPLAY ' ENTROU NOVA REGRA DE INDENIZACAO' */
                _.Display($" ENTROU NOVA REGRA DE INDENIZACAO");

                /*" -1217- DISPLAY ' DS-SIAS: OP 1001 SERA GRAVADA PELO SICP100B' */
                _.Display($" DS-SIAS: OP 1001 SERA GRAVADA PELO SICP100B");

                /*" -1222- DISPLAY 'SINIST - ' SIARDEVC-NUM-APOL-SINISTRO ' | HIST - ' SINISHIS-OCORR-HISTORICO ' | OP - ' SIARDEVC-COD-OPERACAO ' | OP -S ' SINISHIS-COD-OPERACAO */

                $"SINIST - {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO} | HIST - {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO} | OP - {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_OPERACAO} | OP -S {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO}"
                .Display();

                /*" -1231- PERFORM R1500-00-GERA-OP-BAIXA */

                R1500_00_GERA_OP_BAIXA_SECTION();

                /*" -1234- PERFORM R2200-00-SUM-RESERVA THRU R2200-EXIT */

                R2200_00_SUM_RESERVA_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_EXIT*/


                /*" -1236- IF HOST-VAL-RESERVA < ZEROS */

                if (HOST_VAL_RESERVA < 00)
                {

                    /*" -1242- COMPUTE SINISHIS-VAL-OPERACAO = HOST-VAL-RESERVA * -1 */
                    SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO.Value = HOST_VAL_RESERVA * -1;

                    /*" -1244- MOVE 112 TO SINISHIS-COD-OPERACAO */
                    _.Move(112, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);

                    /*" -1245- MOVE SPACES TO SINISHIS-NOME-FAVORECIDO */
                    _.Move("", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO);

                    /*" -1246- MOVE '0' TO SINISHIS-TIPO-FAVORECIDO */
                    _.Move("0", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_TIPO_FAVORECIDO);

                    /*" -1247- MOVE 0 TO SINISHIS-ORDEM-PAGAMENTO */
                    _.Move(0, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_ORDEM_PAGAMENTO);

                    /*" -1248- DISPLAY ' GRAVA AUMENTO DE RESERVA ' */
                    _.Display($" GRAVA AUMENTO DE RESERVA ");

                    /*" -1249- DISPLAY ' PENDENTE VIRADO???? ' */
                    _.Display($" PENDENTE VIRADO???? ");

                    /*" -1255- DISPLAY ' SINIS ' SIARDEVC-NUM-APOL-SINISTRO ' OCORV ' SIARDEVC-OCORR-HISTORICO ' OCORH ' SINISHIS-OCORR-HISTORICO ' OP ' SINISHIS-COD-OPERACAO ' VL ' SINISHIS-VAL-OPERACAO */

                    $" SINIS {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO} OCORV {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO} OCORH {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO} OP {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO} VL {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO}"
                    .Display();

                    /*" -1257- PERFORM R1520-00-INCLUI-SINIS */

                    R1520_00_INCLUI_SINIS_SECTION();

                    /*" -1260- END-IF */
                }


                /*" -1260- END-IF. */
            }


        }

        [StopWatch]
        /*" R1000-90-LE-SIARDEVC */
        private void R1000_90_LE_SIARDEVC(bool isPerform = false)
        {
            /*" -1266- PERFORM R0910-00-LE-SIARDEVC. */

            R0910_00_LE_SIARDEVC_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_00_EXIT*/

        [StopWatch]
        /*" R1010-00-CHECA-ESTORNO-SECTION */
        private void R1010_00_CHECA_ESTORNO_SECTION()
        {
            /*" -1276- MOVE '1010' TO WNR-EXEC-SQL */
            _.Move("1010", WABEND.WNR_EXEC_SQL);

            /*" -1281- PERFORM R1010_00_CHECA_ESTORNO_DB_SELECT_1 */

            R1010_00_CHECA_ESTORNO_DB_SELECT_1();

            /*" -1284- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1285- DISPLAY 'ERRO SELECT SINISTRO_HISTORICO MAX........' */
                _.Display($"ERRO SELECT SINISTRO_HISTORICO MAX........");

                /*" -1286- DISPLAY 'SINISTRO .......' SIARDEVC-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO .......{SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO}");

                /*" -1287- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1289- ELSE */
            }
            else
            {


                /*" -1295- PERFORM R1010_00_CHECA_ESTORNO_DB_SELECT_2 */

                R1010_00_CHECA_ESTORNO_DB_SELECT_2();

                /*" -1300- IF SQLCODE NOT EQUAL ZEROS AND -811 */

                if (!DB.SQLCODE.In("00", "-811"))
                {

                    /*" -1301- DISPLAY 'ERRO SELECT SINISTRO_HISTORICO............' */
                    _.Display($"ERRO SELECT SINISTRO_HISTORICO............");

                    /*" -1302- DISPLAY 'SINISTRO .......' SIARDEVC-NUM-APOL-SINISTRO */
                    _.Display($"SINISTRO .......{SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO}");

                    /*" -1303- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1309- ELSE */
                }
                else
                {


                    /*" -1310- DISPLAY 'NOME PROGRAMA....: ' SINISHIS-NOM-PROGRAMA */
                    _.Display($"NOME PROGRAMA....: {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOM_PROGRAMA}");

                    /*" -1311- IF SINISHIS-NOM-PROGRAMA EQUAL 'SI66SIV9' */

                    if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOM_PROGRAMA == "SI66SIV9")
                    {

                        /*" -1312- MOVE 3 TO SIARDEVC-STA-PROCESSAMENTO */
                        _.Move(3, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO);

                        /*" -1313- GO TO R1000-80-UPDT-SIARDEVC */

                        R1000_80_UPDT_SIARDEVC(); //GOTO
                        return;

                        /*" -1314- ELSE */
                    }
                    else
                    {


                        /*" -1315- MOVE 5 TO SIARDEVC-STA-PROCESSAMENTO */
                        _.Move(5, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO);

                        /*" -1316- END-IF */
                    }


                    /*" -1316- END-IF. */
                }

            }


        }

        [StopWatch]
        /*" R1010-00-CHECA-ESTORNO-DB-SELECT-1 */
        public void R1010_00_CHECA_ESTORNO_DB_SELECT_1()
        {
            /*" -1281- EXEC SQL SELECT MAX(DATA_MOVIMENTO) INTO :SINISHIS-DATA-MOVIMENTO FROM SEGUROS.SINISTRO_HISTORICO WHERE NUM_APOL_SINISTRO = :SIARDEVC-NUM-APOL-SINISTRO END-EXEC */

            var r1010_00_CHECA_ESTORNO_DB_SELECT_1_Query1 = new R1010_00_CHECA_ESTORNO_DB_SELECT_1_Query1()
            {
                SIARDEVC_NUM_APOL_SINISTRO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R1010_00_CHECA_ESTORNO_DB_SELECT_1_Query1.Execute(r1010_00_CHECA_ESTORNO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISHIS_DATA_MOVIMENTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_99_EXIT*/

        [StopWatch]
        /*" R1010-00-CHECA-ESTORNO-DB-SELECT-2 */
        public void R1010_00_CHECA_ESTORNO_DB_SELECT_2()
        {
            /*" -1295- EXEC SQL SELECT NOM_PROGRAMA INTO :SINISHIS-NOM-PROGRAMA FROM SEGUROS.SINISTRO_HISTORICO WHERE NUM_APOL_SINISTRO = :SIARDEVC-NUM-APOL-SINISTRO AND DATA_MOVIMENTO = :SINISHIS-DATA-MOVIMENTO END-EXEC */

            var r1010_00_CHECA_ESTORNO_DB_SELECT_2_Query1 = new R1010_00_CHECA_ESTORNO_DB_SELECT_2_Query1()
            {
                SIARDEVC_NUM_APOL_SINISTRO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_DATA_MOVIMENTO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO.ToString(),
            };

            var executed_1 = R1010_00_CHECA_ESTORNO_DB_SELECT_2_Query1.Execute(r1010_00_CHECA_ESTORNO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISHIS_NOM_PROGRAMA, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOM_PROGRAMA);
            }


        }

        [StopWatch]
        /*" R1050-00-CHECA-PT-SECTION */
        private void R1050_00_CHECA_PT_SECTION()
        {
            /*" -1326- MOVE '1050' TO WNR-EXEC-SQL */
            _.Move("1050", WABEND.WNR_EXEC_SQL);

            /*" -1339- MOVE 'NAO' TO WS-PERDA-TOTAL. */
            _.Move("NAO", WS_PERDA_TOTAL);

            /*" -1345- IF (SIARDEVC-IND-FAVORECIDO = '1' OR '4' ) AND (SIARDEVC-COD-RAMO = 31) AND (SIARDEVC-COD-COBERTURA = 4) AND (SIARDEVC-COD-OPERACAO = 1081) AND (SIARDEVC-COD-CAUSA = 11 OR 12 OR 13) */

            if ((SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_IND_FAVORECIDO.In("1", "4")) && (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_RAMO == 31) && (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_COBERTURA == 4) && (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_OPERACAO == 1081) && (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_CAUSA.In("11", "12", "13")))
            {

                /*" -1347- PERFORM R1060-00-LE-CAUSA */

                R1060_00_LE_CAUSA_SECTION();

                /*" -1348- IF SINISCAU-GRUPO-CAUSAS = 'PT' */

                if (SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_GRUPO_CAUSAS == "PT")
                {

                    /*" -1350- PERFORM R1070-00-LE-MESTSINI */

                    R1070_00_LE_MESTSINI_SECTION();

                    /*" -1351- IF (SINISMES-COD-PRODUTO NOT EQUAL 3172) */

                    if ((SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO != 3172))
                    {

                        /*" -1351- MOVE 'SIM' TO WS-PERDA-TOTAL. */
                        _.Move("SIM", WS_PERDA_TOTAL);
                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1050_00_EXIT*/

        [StopWatch]
        /*" R1060-00-LE-CAUSA-SECTION */
        private void R1060_00_LE_CAUSA_SECTION()
        {
            /*" -1372- MOVE '1060' TO WNR-EXEC-SQL. */
            _.Move("1060", WABEND.WNR_EXEC_SQL);

            /*" -1373- MOVE SIARDEVC-COD-RAMO TO WS-COD-RAMO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_RAMO, WS_CAUSA.WS_COD_RAMO);

            /*" -1375- MOVE SIARDEVC-COD-CAUSA TO WS-COD-CAUSA */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_CAUSA, WS_CAUSA.WS_COD_CAUSA);

            /*" -1376- SET I01-CAU TO 1 */
            I01_CAU.Value = 1;

            /*" -1377- SEARCH TB-CAUSA AT END */
            void SearchAtEnd0()
            {

                /*" -1378- SET I01-CAU TO 101 */
                I01_CAU.Value = 101;

                /*" -1380- WHEN TB-CAU-CHV (I01-CAU) EQUAL WS-CAUSA OR ZEROS NEXT SENTENCE  END-SEARCH. */
            };

            var mustSearchAtEnd0 = true;
            for (; I01_CAU < TAB_CAUSA.TB_CAUSA.Items.Count; I01_CAU.Value++)
            {

                if (TAB_CAUSA.TB_CAUSA[I01_CAU].TB_CAU_CHV.In(WS_CAUSA.ToString(), "00"))
                {

                    mustSearchAtEnd0 = false;
                    continue;
                }
            }

            if (mustSearchAtEnd0)
                SearchAtEnd0();

            /*" -1383- IF TB-CAU-CHV (I01-CAU) NOT = ZEROS */

            if (TAB_CAUSA.TB_CAUSA[I01_CAU].TB_CAU_CHV != 00)
            {

                /*" -1384- MOVE TB-CAU-GRP (I01-CAU) TO SINISCAU-GRUPO-CAUSAS */
                _.Move(TAB_CAUSA.TB_CAUSA[I01_CAU].TB_CAU_GRP, SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_GRUPO_CAUSAS);

                /*" -1385- GO TO R1060-99-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1060_99_EXIT*/ //GOTO
                return;

                /*" -1387- END-IF. */
            }


            /*" -1393- PERFORM R1060_00_LE_CAUSA_DB_SELECT_1 */

            R1060_00_LE_CAUSA_DB_SELECT_1();

            /*" -1396- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1397- DISPLAY 'ERRO SELECT SINISTRO_CAUSA ...............' */
                _.Display($"ERRO SELECT SINISTRO_CAUSA ...............");

                /*" -1398- DISPLAY 'SINISTRO .......' SIARDEVC-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO .......{SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO}");

                /*" -1399- DISPLAY 'OCORR_HISTORICO.' SIARDEVC-OCORR-HISTORICO */
                _.Display($"OCORR_HISTORICO.{SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO}");

                /*" -1400- DISPLAY 'RAMO............' SIARDEVC-COD-RAMO */
                _.Display($"RAMO............{SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_RAMO}");

                /*" -1401- DISPLAY 'CAUSA...........' SIARDEVC-COD-CAUSA */
                _.Display($"CAUSA...........{SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_CAUSA}");

                /*" -1402- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1404- END-IF. */
            }


            /*" -1404- MOVE SINISCAU-GRUPO-CAUSAS TO TB-CAU-GRP (I01-CAU). */
            _.Move(SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_GRUPO_CAUSAS, TAB_CAUSA.TB_CAUSA[I01_CAU].TB_CAU_GRP);

        }

        [StopWatch]
        /*" R1060-00-LE-CAUSA-DB-SELECT-1 */
        public void R1060_00_LE_CAUSA_DB_SELECT_1()
        {
            /*" -1393- EXEC SQL SELECT GRUPO_CAUSAS INTO :SINISCAU-GRUPO-CAUSAS FROM SEGUROS.SINISTRO_CAUSA WHERE RAMO_EMISSOR = :SIARDEVC-COD-RAMO AND COD_CAUSA = :SIARDEVC-COD-CAUSA END-EXEC. */

            var r1060_00_LE_CAUSA_DB_SELECT_1_Query1 = new R1060_00_LE_CAUSA_DB_SELECT_1_Query1()
            {
                SIARDEVC_COD_CAUSA = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_CAUSA.ToString(),
                SIARDEVC_COD_RAMO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_RAMO.ToString(),
            };

            var executed_1 = R1060_00_LE_CAUSA_DB_SELECT_1_Query1.Execute(r1060_00_LE_CAUSA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISCAU_GRUPO_CAUSAS, SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_GRUPO_CAUSAS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1060_99_EXIT*/

        [StopWatch]
        /*" R1070-00-LE-MESTSINI-SECTION */
        private void R1070_00_LE_MESTSINI_SECTION()
        {
            /*" -1414- MOVE '1070' TO WNR-EXEC-SQL */
            _.Move("1070", WABEND.WNR_EXEC_SQL);

            /*" -1421- PERFORM R1070_00_LE_MESTSINI_DB_SELECT_1 */

            R1070_00_LE_MESTSINI_DB_SELECT_1();

            /*" -1424- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1425- DISPLAY 'ERRO SELECT SINISTRO_MESTRE...............' */
                _.Display($"ERRO SELECT SINISTRO_MESTRE...............");

                /*" -1426- DISPLAY 'SINISTRO ........... ' SIARDEVC-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO ........... {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO}");

                /*" -1427- DISPLAY 'OCORR_HISTORICO..... ' SIARDEVC-OCORR-HISTORICO */
                _.Display($"OCORR_HISTORICO..... {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO}");

                /*" -1428- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1428- END-IF. */
            }


        }

        [StopWatch]
        /*" R1070-00-LE-MESTSINI-DB-SELECT-1 */
        public void R1070_00_LE_MESTSINI_DB_SELECT_1()
        {
            /*" -1421- EXEC SQL SELECT COD_PRODUTO , OCORR_HISTORICO INTO :SINISMES-COD-PRODUTO , :SINISMES-OCORR-HISTORICO FROM SEGUROS.SINISTRO_MESTRE WHERE NUM_APOL_SINISTRO = :SIARDEVC-NUM-APOL-SINISTRO END-EXEC. */

            var r1070_00_LE_MESTSINI_DB_SELECT_1_Query1 = new R1070_00_LE_MESTSINI_DB_SELECT_1_Query1()
            {
                SIARDEVC_NUM_APOL_SINISTRO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R1070_00_LE_MESTSINI_DB_SELECT_1_Query1.Execute(r1070_00_LE_MESTSINI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISMES_COD_PRODUTO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO);
                _.Move(executed_1.SINISMES_OCORR_HISTORICO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_OCORR_HISTORICO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1070_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-LE-SIERRO-SECTION */
        private void R1100_00_LE_SIERRO_SECTION()
        {
            /*" -1439- MOVE '1100' TO WNR-EXEC-SQL */
            _.Move("1100", WABEND.WNR_EXEC_SQL);

            /*" -1444- PERFORM R1100_00_LE_SIERRO_DB_SELECT_1 */

            R1100_00_LE_SIERRO_DB_SELECT_1();

            /*" -1447- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1453- DISPLAY 'ERRO SELECT SI_ERRO' ' ' SIARDEVC-NOM-ARQUIVO ' ' SIARDEVC-SEQ-GERACAO ' ' SIARDEVC-TIPO-REGISTRO ' ' SIARDEVC-SEQ-REGISTRO ' ' SIARDEVC-COD-ERRO */

                $"ERRO SELECT SI_ERRO {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_ARQUIVO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_GERACAO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_REGISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_REGISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO}"
                .Display();

                /*" -1453- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1100-00-LE-SIERRO-DB-SELECT-1 */
        public void R1100_00_LE_SIERRO_DB_SELECT_1()
        {
            /*" -1444- EXEC SQL SELECT DES_ERRO INTO :SIERRO-DES-ERRO FROM SEGUROS.SI_ERRO WHERE COD_ERRO = :SIARDEVC-COD-ERRO END-EXEC. */

            var r1100_00_LE_SIERRO_DB_SELECT_1_Query1 = new R1100_00_LE_SIERRO_DB_SELECT_1_Query1()
            {
                SIARDEVC_COD_ERRO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO.ToString(),
            };

            var executed_1 = R1100_00_LE_SIERRO_DB_SELECT_1_Query1.Execute(r1100_00_LE_SIERRO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SIERRO_DES_ERRO, SIERRO.DCLSI_ERRO.SIERRO_DES_ERRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_00_EXIT*/

        [StopWatch]
        /*" R1200-00-GERA-DETALHE-SECTION */
        private void R1200_00_GERA_DETALHE_SECTION()
        {
            /*" -1463- MOVE '1200' TO WNR-EXEC-SQL */
            _.Move("1200", WABEND.WNR_EXEC_SQL);

            /*" -1465- INITIALIZE REG-SCMOVSIN */
            _.Initialize(
                REG_SCMOVSIN
            );

            /*" -1468- IF SIARDEVC-NUM-APOL-SINISTRO EQUAL ZEROS */

            if (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO == 00)
            {

                /*" -1469- MOVE ZEROS TO DET-NUM-PROTOCOLO-SINI */
                _.Move(0, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NUM_PROTOCOLO_SINI);

                /*" -1470- ELSE */
            }
            else
            {


                /*" -1473- PERFORM R1250-00-LE-SINISMES */

                R1250_00_LE_SINISMES_SECTION();

                /*" -1478- MOVE SINISMES-NUM-PROTOCOLO-SINI TO DET-NUM-PROTOCOLO-SINI. */
                _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_PROTOCOLO_SINI, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NUM_PROTOCOLO_SINI);
            }


            /*" -1481- MOVE SIARDEVC-COD-FONTE TO DET-FONTE-SINISTRO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_FONTE, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_FONTE_SINISTRO);

            /*" -1483- MOVE '2' TO DET-TIPO-REGISTRO */
            _.Move("2", REG_SCMOVSIN.SCMOVSIN_DADOS.DET_TIPO_REGISTRO);

            /*" -1484- ADD 1 TO AC-G-CSPAGSIN */
            AC_G_CSPAGSIN.Value = AC_G_CSPAGSIN + 1;

            /*" -1485- MOVE AC-G-CSPAGSIN TO DET-NUM-SEQ-REGISTRO */
            _.Move(AC_G_CSPAGSIN, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NUM_SEQ_REGISTRO);

            /*" -1487- MOVE SIARDEVC-STA-PROCESSAMENTO TO DET-IND-PROCESSAMENTO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_IND_PROCESSAMENTO);

            /*" -1488- IF SIARDEVC-STA-PROCESSAMENTO = 'R' */

            if (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO == "R")
            {

                /*" -1489- ADD 1 TO AC-G-CSPAGSIN-R. */
                AC_G_CSPAGSIN_R.Value = AC_G_CSPAGSIN_R + 1;
            }


            /*" -1496- MOVE SIERRO-DES-ERRO TO DET-MENSAGEM-RETORNO */
            _.Move(SIERRO.DCLSI_ERRO.SIERRO_DES_ERRO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_MENSAGEM_RETORNO);

            /*" -1498- MOVE SIARDEVC-NUM-APOL-SINISTRO TO DET-NUM-SINISTRO-CXSEG */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NUM_SINISTRO_CXSEG);

            /*" -1500- MOVE SIARDEVC-COD-OPERACAO TO DET-COD-OPERACAO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_OPERACAO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_COD_OPERACAO);

            /*" -1503- MOVE SIARDEVC-OCORR-HISTORICO TO DET-NUM-OCORR-HISTORICO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NUM_OCORR_HISTORICO);

            /*" -1506- MOVE SIARDEVC-NUM-SINISTRO-CONV TO DET-NUM-SINISTRO-VC */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_SINISTRO_CONV, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NUM_SINISTRO_VC);

            /*" -1508- MOVE SIARDEVC-NUM-EXPEDIENTE-VC TO DET-NUM-EXPEDIENTE-VC */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_EXPEDIENTE_VC, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NUM_EXPEDIENTE_VC);

            /*" -1510- MOVE SIARDEVC-NUM-APOLICE TO DET-NUM-APOLICE */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NUM_APOLICE);

            /*" -1512- MOVE SIARDEVC-NUM-ENDOSSO TO DET-NUM-ENDOSSO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_ENDOSSO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NUM_ENDOSSO);

            /*" -1513- MOVE SIARDEVC-NUM-ITEM TO DET-NUM-ITEM */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_ITEM, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NUM_ITEM);

            /*" -1514- MOVE SIARDEVC-COD-RAMO TO DET-COD-RAMO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_RAMO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_COD_RAMO);

            /*" -1516- MOVE SIARDEVC-COD-COBERTURA TO DET-COD-COBERTURA */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_COBERTURA, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_COD_COBERTURA);

            /*" -1518- MOVE SIARDEVC-COD-CAUSA TO DET-COD-CAUSA */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_CAUSA, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_COD_CAUSA);

            /*" -1520- MOVE SIARDEVC-DATA-COMUNICADO TO DET-DT-COMUNICADO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_COMUNICADO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_DT_COMUNICADO);

            /*" -1523- MOVE SIARDEVC-DATA-OCORRENCIA TO DET-DT-OCORRENCIA */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_OCORRENCIA, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_DT_OCORRENCIA);

            /*" -1525- IF SIARDEVC-HORA-OCORRENCIA EQUAL '00:00:00' */

            if (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_HORA_OCORRENCIA == "00:00:00")
            {

                /*" -1526- MOVE SPACES TO DET-HORA-OCORRENCIA */
                _.Move("", REG_SCMOVSIN.SCMOVSIN_DADOS.DET_HORA_OCORRENCIA);

                /*" -1527- ELSE */
            }
            else
            {


                /*" -1530- MOVE SIARDEVC-HORA-OCORRENCIA TO DET-HORA-OCORRENCIA. */
                _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_HORA_OCORRENCIA, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_HORA_OCORRENCIA);
            }


            /*" -1532- MOVE SIARDEVC-DATA-MOVIMENTO TO DET-DT-MOVIMENTO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_MOVIMENTO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_DT_MOVIMENTO);

            /*" -1534- MOVE SIARDEVC-IND-FAVORECIDO TO DET-IND-TIPO-FAVORECIDO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_IND_FAVORECIDO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_IND_TIPO_FAVORECIDO);

            /*" -1536- MOVE SIARDEVC-VAL-TOT-MOVIMENTO TO DET-VAL-TOTAL-MOVIMENTO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_TOT_MOVIMENTO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_VAL_TOTAL_MOVIMENTO);

            /*" -1538- MOVE SIARDEVC-VAL-PECAS TO DET-VAL-PECAS */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_PECAS, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_VAL_PECAS);

            /*" -1540- MOVE SIARDEVC-VAL-MAO-OBRA TO DET-VAL-MAO-OBRA */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_MAO_OBRA, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_VAL_MAO_OBRA);

            /*" -1542- MOVE SIARDEVC-VAL-PARCELA-PEND TO DET-VAL-PARCELA-PEND */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_PARCELA_PEND, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_VAL_PARCELA_PEND);

            /*" -1544- MOVE SIARDEVC-QTD-PARCELA-PEND TO DET-QTD-PARCELA-PEND */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_QTD_PARCELA_PEND, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_QTD_PARCELA_PEND);

            /*" -1547- MOVE SIARDEVC-VAL-DESC-PARC-PEND TO DET-VAL-DESC-PARCELA-PEND */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_DESC_PARC_PEND, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_VAL_DESC_PARCELA_PEND);

            /*" -1548- IF SIARDEVC-IND-FORMA-PAGTO EQUAL '3' */

            if (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_IND_FORMA_PAGTO == "3")
            {

                /*" -1549- PERFORM R1210-00-LE-MOVDEBCE */

                R1210_00_LE_MOVDEBCE_SECTION();

                /*" -1550- IF MOVDEBCE-COD-RETORNO-CEF EQUAL ZEROS */

                if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF == 00)
                {

                    /*" -1552- MOVE MOVDEBCE-DATA-VENCIMENTO TO SIARDEVC-DATA-NEGOCIADA */
                    _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_NEGOCIADA);

                    /*" -1554- END-IF. */
                }

            }


            /*" -1556- IF SIARDEVC-DATA-NEGOCIADA EQUAL '0001-01-01' */

            if (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_NEGOCIADA == "0001-01-01")
            {

                /*" -1557- MOVE SPACES TO DET-DT-NEGOCIADA-PAGTO */
                _.Move("", REG_SCMOVSIN.SCMOVSIN_DADOS.DET_DT_NEGOCIADA_PAGTO);

                /*" -1558- ELSE */
            }
            else
            {


                /*" -1561- MOVE SIARDEVC-DATA-NEGOCIADA TO DET-DT-NEGOCIADA-PAGTO. */
                _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_NEGOCIADA, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_DT_NEGOCIADA_PAGTO);
            }


            /*" -1562- MOVE SIARDEVC-VAL-IRF TO DET-VAL-IRRF */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_IRF, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_VAL_IRRF);

            /*" -1563- MOVE SIARDEVC-VAL-ISS TO DET-VAL-ISS */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_ISS, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_VAL_ISS);

            /*" -1564- MOVE SIARDEVC-VAL-INSS TO DET-VAL-INSS */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_INSS, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_VAL_INSS);

            /*" -1566- MOVE SIARDEVC-VAL-PISPASEP TO DET-VAL-PISPASEP */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_PISPASEP, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_VAL_PISPASEP);

            /*" -1568- MOVE SIARDEVC-VAL-COFINS TO DET-VAL-COFINS */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_COFINS, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_VAL_COFINS);

            /*" -1569- MOVE SIARDEVC-VAL-CSLL TO DET-VAL-CSLL */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_CSLL, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_VAL_CSLL);

            /*" -1571- MOVE SIARDEVC-VAL-LIQUIDO-PAGTO TO DET-VAL-LIQUIDO-PAGO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_LIQUIDO_PAGTO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_VAL_LIQUIDO_PAGO);

            /*" -1572- MOVE SIARDEVC-CGCCPF TO DET-CNPJ-CPF-FAVORECIDO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_CGCCPF, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_CNPJ_CPF_FAVORECIDO);

            /*" -1574- MOVE SIARDEVC-TIPO-PESSOA TO DET-TIPO-PESSOA */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_PESSOA, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_TIPO_PESSOA);

            /*" -1576- MOVE SIARDEVC-NOM-FAVORECIDO TO DET-NOME-FAVORECIDO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_FAVORECIDO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NOME_FAVORECIDO);

            /*" -1578- MOVE SIARDEVC-IND-DOC-FISCAL TO DET-IND-TIPO-DOC-FISCAL */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_IND_DOC_FISCAL, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_IND_TIPO_DOC_FISCAL);

            /*" -1580- MOVE SIARDEVC-NUM-DOC-FISCAL TO DET-NUM-DOC-FISCAL */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_DOC_FISCAL, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NUM_DOC_FISCAL);

            /*" -1583- MOVE SIARDEVC-SERIE-DOC-FISCAL TO DET-SERIE-DOC-FISCAL */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SERIE_DOC_FISCAL, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_SERIE_DOC_FISCAL);

            /*" -1585- IF SIARDEVC-DATA-EMISSAO EQUAL '0001-01-01' */

            if (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_EMISSAO == "0001-01-01")
            {

                /*" -1586- MOVE SPACES TO DET-DT-EMISSAO-DOC */
                _.Move("", REG_SCMOVSIN.SCMOVSIN_DADOS.DET_DT_EMISSAO_DOC);

                /*" -1587- ELSE */
            }
            else
            {


                /*" -1590- MOVE SIARDEVC-DATA-EMISSAO TO DET-DT-EMISSAO-DOC. */
                _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_EMISSAO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_DT_EMISSAO_DOC);
            }


            /*" -1592- MOVE SIARDEVC-DES-ENDERECO TO DET-ENDERECO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DES_ENDERECO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_ENDERECO);

            /*" -1594- MOVE SIARDEVC-NOM-BAIRRO TO DET-NOM-BAIRRO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_BAIRRO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NOM_BAIRRO);

            /*" -1596- MOVE SIARDEVC-NOM-CIDADE TO DET-NOM-CIDADE */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_CIDADE, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NOM_CIDADE);

            /*" -1597- MOVE SIARDEVC-COD-UF TO DET-NOM-SIGLA-UF */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_UF, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NOM_SIGLA_UF);

            /*" -1598- MOVE SIARDEVC-NUM-CEP TO DET-NUM-CEP */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CEP, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_CEP.DET_NUM_CEP);

            /*" -1599- MOVE SIARDEVC-NUM-DDD TO DET-NUM-DDD */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_DDD, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NUM_DDD);

            /*" -1601- MOVE SIARDEVC-NUM-TELEFONE TO DET-NUM-TELEFONE */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_TELEFONE, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NUM_TELEFONE);

            /*" -1604- MOVE SIARDEVC-IND-FORMA-PAGTO TO DET-IND-FORMA-PAGTO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_IND_FORMA_PAGTO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_IND_FORMA_PAGTO);

            /*" -1606- MOVE SIARDEVC-NUM-IDENTIFICADOR TO DET-NUM-IDENTIFICADOR-PAGTO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_IDENTIFICADOR, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NUM_IDENTIFICADOR_PAGTO);

            /*" -1609- MOVE SIARDEVC-NUM-CHEQUE-INTERNO TO DET-NUM-CHEQUE-INTERNO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CHEQUE_INTERNO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NUM_CHEQUE_INTERNO);

            /*" -1611- MOVE SPACES TO WS-IDENT-PAGTO-EDITADO */
            _.Move("", WS_IDENT_PAGTO_EDITADO);

            /*" -1613- IF SIARDEVC-NUM-IDENTIFICADOR NOT EQUAL ZEROS */

            if (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_IDENTIFICADOR != 00)
            {

                /*" -1615- MOVE SIARDEVC-NUM-IDENTIFICADOR TO WS-CHEQUE-EXTERNO */
                _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_IDENTIFICADOR, WS_IDENT_PAGTO_EDITADO.WS_CHEQUE_EXTERNO);

                /*" -1617- MOVE '.' TO WS-SEPARADOR. */
                _.Move(".", WS_IDENT_PAGTO_EDITADO.WS_SEPARADOR);
            }


            /*" -1619- MOVE SIARDEVC-NUM-CHEQUE-INTERNO TO WS-CHEQUE-INTERNO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CHEQUE_INTERNO, WS_IDENT_PAGTO_EDITADO.WS_CHEQUE_INTERNO);

            /*" -1622- MOVE WS-IDENT-PAGTO-EDITADO TO DET-IDENT-PAGTO-EDITADO */
            _.Move(WS_IDENT_PAGTO_EDITADO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_IDENT_PAGTO_EDITADO);

            /*" -1624- MOVE SIARDEVC-ORDEM-PAGAMENTO-VC TO DET-NUM-OP-VC */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_ORDEM_PAGAMENTO_VC, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NUM_OP_VC);

            /*" -1626- MOVE SIARDEVC-ORDEM-PAGAMENTO TO DET-NUM-OP-CXSEG */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_ORDEM_PAGAMENTO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NUM_OP_CXSEG);

            /*" -1628- MOVE SIARDEVC-COD-BANCO TO DET-COD-BANCO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_BANCO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_COD_BANCO);

            /*" -1630- MOVE SIARDEVC-COD-AGENCIA TO DET-COD-AGENCIA */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_AGENCIA, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_COD_AGENCIA);

            /*" -1632- MOVE SIARDEVC-OPERACAO-CONTA TO DET-COD-OPERACAO-CONTA-CEF */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OPERACAO_CONTA, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_COD_OPERACAO_CONTA_CEF);

            /*" -1634- MOVE SIARDEVC-COD-CONTA TO DET-NUM-CONTA-BANCARIA */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_CONTA, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NUM_CONTA_BANCARIA);

            /*" -1636- MOVE SIARDEVC-DV-CONTA TO DET-DV-CONTA */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DV_CONTA, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_DV_CONTA);

            /*" -1638- MOVE SIARDEVC-COD-FAVORECIDO TO DET-COD-FAVORECIDO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_FAVORECIDO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_COD_FAVORECIDO);

            /*" -1640- IF SIARDEVC-NUM-CHEQUE-INTERNO NOT EQUAL ZEROS AND SIARDEVC-IND-FORMA-PAGTO EQUAL '1' */

            if (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CHEQUE_INTERNO != 00 && SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_IND_FORMA_PAGTO == "1")
            {

                /*" -1641- MOVE LOTECHEQ-SERIE-CHEQUE TO DET-SERIE-CHEQUE */
                _.Move(LOTECHEQ.DCLLOTE_CHEQUES.LOTECHEQ_SERIE_CHEQUE, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_SERIE_CHEQUE);

                /*" -1642- ELSE */
            }
            else
            {


                /*" -1646- MOVE SPACES TO DET-SERIE-CHEQUE. */
                _.Move("", REG_SCMOVSIN.SCMOVSIN_DADOS.DET_SERIE_CHEQUE);
            }


            /*" -1648- MOVE SIARDEVC-NUM-RESSARC TO DET-NUM-RESSARC */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_RESSARC, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NUM_RESSARC);

            /*" -1650- MOVE SIARDEVC-IND-PESSOA-ACORDO TO DET-IND-PESSOA-ACORDO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_IND_PESSOA_ACORDO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_IND_PESSOA_ACORDO);

            /*" -1652- MOVE SIARDEVC-NUM-CPFCGC-ACORDO TO DET-NUM-CPFCGC-ACORDO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CPFCGC_ACORDO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NUM_CPFCGC_ACORDO);

            /*" -1654- MOVE SIARDEVC-NOM-RESP-ACORDO TO DET-NOM-RESP-ACORDO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_RESP_ACORDO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NOM_RESP_ACORDO);

            /*" -1656- MOVE SIARDEVC-STA-ACORDO TO DET-STA-ACORDO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_ACORDO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_STA_ACORDO);

            /*" -1658- MOVE SIARDEVC-DTH-INDENIZACAO TO DET-DTH-INDENIZACAO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DTH_INDENIZACAO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_DTH_INDENIZACAO);

            /*" -1660- MOVE SIARDEVC-VLR-INDENIZACAO TO DET-VLR-INDENIZACAO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VLR_INDENIZACAO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_VLR_INDENIZACAO);

            /*" -1662- MOVE SIARDEVC-VLR-PART-TERCEIROS TO DET-VLR-PART-TERCEIROS */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VLR_PART_TERCEIROS, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_VLR_PART_TERCEIROS);

            /*" -1664- MOVE SIARDEVC-VLR-DIVIDA TO DET-VLR-DIVIDA */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VLR_DIVIDA, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_VLR_DIVIDA);

            /*" -1666- MOVE SIARDEVC-PCT-DESCONTO TO DET-PCT-DESCONTO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_PCT_DESCONTO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_PCT_DESCONTO);

            /*" -1668- MOVE SIARDEVC-VLR-TOTAL-DESCONTO TO DET-VLR-TOTAL-DESCONTO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VLR_TOTAL_DESCONTO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_VLR_TOTAL_DESCONTO);

            /*" -1670- MOVE SIARDEVC-VLR-TOTAL-ACORDO TO DET-VLR-TOTAL-ACORDO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VLR_TOTAL_ACORDO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_VLR_TOTAL_ACORDO);

            /*" -1672- MOVE SIARDEVC-COD-MOEDA-ACORDO TO DET-COD-MOEDA-ACORDO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_MOEDA_ACORDO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_COD_MOEDA_ACORDO);

            /*" -1674- MOVE SIARDEVC-DTH-ACORDO TO DET-DTH-ACORDO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DTH_ACORDO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_DTH_ACORDO);

            /*" -1676- MOVE SIARDEVC-QTD-PARCELAS-ACORDO TO DET-QTD-PARCELAS-ACORDO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_QTD_PARCELAS_ACORDO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_QTD_PARCELAS_ACORDO);

            /*" -1678- MOVE SIARDEVC-NUM-PARCELA-ACORDO TO DET-NUM-PARCELA-ACORDO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_PARCELA_ACORDO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NUM_PARCELA_ACORDO);

            /*" -1680- MOVE SIARDEVC-COD-AGENCIA-CEDENT TO DET-COD-AGENCIA-CEDENT */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_AGENCIA_CEDENT, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_COD_AGENCIA_CEDENT);

            /*" -1682- MOVE SIARDEVC-NUM-CEDENTE TO DET-NUM-CEDENTE */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CEDENTE, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NUM_CEDENTE);

            /*" -1684- MOVE SIARDEVC-NUM-CEDENTE-DV TO DET-NUM-CEDENTE-DV */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CEDENTE_DV, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NUM_CEDENTE_DV);

            /*" -1686- MOVE SIARDEVC-DTH-VENCIMENTO TO DET-DTH-VENCIMENTO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DTH_VENCIMENTO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_DTH_VENCIMENTO);

            /*" -1688- MOVE SIARDEVC-NUM-NOSSO-TITULO TO DET-NUM-NOSSO-TITULO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_NOSSO_TITULO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NUM_NOSSO_TITULO);

            /*" -1690- MOVE SIARDEVC-VLR-TITULO TO DET-VLR-TITULO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VLR_TITULO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_VLR_TITULO);

            /*" -1692- MOVE SIARDEVC-NUM-CPFCGC-RECLAMANTE TO DET-NUM-CPFCGC-RECLAMANTE */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CPFCGC_RECLAMANTE, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NUM_CPFCGC_RECLAMANTE);

            /*" -1694- MOVE SIARDEVC-NOM-RECLAMANTE TO DET-NOM-RECLAMANTE */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_RECLAMANTE, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NOM_RECLAMANTE);

            /*" -1696- MOVE SIARDEVC-VLR-RECLAMADO TO DET-VLR-RECLAMADO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VLR_RECLAMADO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_VLR_RECLAMADO);

            /*" -1699- MOVE SIARDEVC-VLR-PROVISIONADO TO DET-VLR-PROVISIONADO. */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VLR_PROVISIONADO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_VLR_PROVISIONADO);

            /*" -1701- MOVE SIARDEVC-NUM-IDENT-CONV TO DET-NUM-IDENT-CONV */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_IDENT_CONV, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NUM_IDENT_CONV);

            /*" -1704- MOVE SIARDEVC-NUM-IDE-COBR-CONV TO DET-NUM-IDENT-PAGTO. */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_IDE_COBR_CONV, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NUM_IDENT_PAGTO);

            /*" -1705- MOVE SIARDEVC-COD-CFOP TO DET-CFOP. */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_CFOP, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_CFOP);

            /*" -1706- MOVE SIARDEVC-COD-CEST TO DET-CEST. */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_CEST, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_CEST);

            /*" -1708- MOVE SIARDEVC-NUM-INSCR-ESTADUAL TO DET-INSC-EST. */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_INSCR_ESTADUAL, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_INSC_EST);

            /*" -1709- MOVE SIARDEVC-NUM-NCM TO DET-NCM. */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_NCM, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NCM);

            /*" -1711- MOVE SIARDEVC-NUM-CPF-CNPJ-TOMADOR TO DET-CNPJ-FILIAL. */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CPF_CNPJ_TOMADOR, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_CNPJ_FILIAL);

            /*" -1713- MOVE SIARDEVC-IND-ISENCAO-TRIBUTO TO DET-IND-RET-IMP. */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_IND_ISENCAO_TRIBUTO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_IND_RET_IMP);

            /*" -1715- MOVE SIARDEVC-COD-IMPOSTO-LIMINAR TO DET-COD-IMP-LIM. */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_IMPOSTO_LIMINAR, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_COD_IMP_LIM);

            /*" -1717- MOVE SIARDEVC-COD-PROCESSO-ISENCAO TO DET-COD-PROC-PJDT. */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_PROCESSO_ISENCAO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_COD_PROC_PJDT);

            /*" -1720- MOVE SIARDEVC-VLR-RET-N-EFETUADO TO DET-VLR-RET-PRINC. */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VLR_RET_N_EFETUADO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_VLR_RET_PRINC);

            /*" -1720- WRITE REG-SCMOVSIN. */
            CSPAGSIN.Write(REG_SCMOVSIN.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_00_EXIT*/

        [StopWatch]
        /*" R1210-00-LE-MOVDEBCE-SECTION */
        private void R1210_00_LE_MOVDEBCE_SECTION()
        {
            /*" -1730- MOVE '1210' TO WNR-EXEC-SQL */
            _.Move("1210", WABEND.WNR_EXEC_SQL);

            /*" -1738- PERFORM R1210_00_LE_MOVDEBCE_DB_SELECT_1 */

            R1210_00_LE_MOVDEBCE_DB_SELECT_1();

            /*" -1741- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1742- DISPLAY 'ERRO NO SELECT MOVDEBCE' */
                _.Display($"ERRO NO SELECT MOVDEBCE");

                /*" -1743- DISPLAY 'CHEQUE = ' SIARDEVC-NUM-CHEQUE-INTERNO */
                _.Display($"CHEQUE = {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CHEQUE_INTERNO}");

                /*" -1744- DISPLAY 'APOL-SINISTRO =' SIARDEVC-NUM-APOL-SINISTRO */
                _.Display($"APOL-SINISTRO ={SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO}");

                /*" -1746- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1747- IF IND-COD-RETORNO-CEF LESS ZEROS */

            if (IND_COD_RETORNO_CEF < 00)
            {

                /*" -1747- MOVE ZEROS TO MOVDEBCE-COD-RETORNO-CEF. */
                _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF);
            }


        }

        [StopWatch]
        /*" R1210-00-LE-MOVDEBCE-DB-SELECT-1 */
        public void R1210_00_LE_MOVDEBCE_DB_SELECT_1()
        {
            /*" -1738- EXEC SQL SELECT COD_RETORNO_CEF , DATA_VENCIMENTO INTO :MOVDEBCE-COD-RETORNO-CEF:IND-COD-RETORNO-CEF, :MOVDEBCE-DATA-VENCIMENTO FROM SEGUROS.MOVTO_DEBITOCC_CEF WHERE NUM_CARTAO = :SIARDEVC-NUM-CHEQUE-INTERNO AND NUM_APOLICE = :SIARDEVC-NUM-APOL-SINISTRO END-EXEC */

            var r1210_00_LE_MOVDEBCE_DB_SELECT_1_Query1 = new R1210_00_LE_MOVDEBCE_DB_SELECT_1_Query1()
            {
                SIARDEVC_NUM_CHEQUE_INTERNO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CHEQUE_INTERNO.ToString(),
                SIARDEVC_NUM_APOL_SINISTRO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R1210_00_LE_MOVDEBCE_DB_SELECT_1_Query1.Execute(r1210_00_LE_MOVDEBCE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVDEBCE_COD_RETORNO_CEF, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF);
                _.Move(executed_1.IND_COD_RETORNO_CEF, IND_COD_RETORNO_CEF);
                _.Move(executed_1.MOVDEBCE_DATA_VENCIMENTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1210_00_EXIT*/

        [StopWatch]
        /*" R1250-00-LE-SINISMES-SECTION */
        private void R1250_00_LE_SINISMES_SECTION()
        {
            /*" -1757- MOVE '1250' TO WNR-EXEC-SQL */
            _.Move("1250", WABEND.WNR_EXEC_SQL);

            /*" -1764- PERFORM R1250_00_LE_SINISMES_DB_SELECT_1 */

            R1250_00_LE_SINISMES_DB_SELECT_1();

            /*" -1767- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1769- MOVE ZEROS TO SINISMES-COD-FONTE SINISMES-NUM-PROTOCOLO-SINI */
                _.Move(0, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_PROTOCOLO_SINI);

                /*" -1770- ELSE */
            }
            else
            {


                /*" -1771- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1777- DISPLAY 'ERRO SELECT SINISTRO_MESTRE' ' ' SIARDEVC-NOM-ARQUIVO ' ' SIARDEVC-SEQ-GERACAO ' ' SIARDEVC-TIPO-REGISTRO ' ' SIARDEVC-SEQ-REGISTRO ' ' SIARDEVC-NUM-APOL-SINISTRO */

                    $"ERRO SELECT SINISTRO_MESTRE {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_ARQUIVO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_GERACAO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_REGISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_REGISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO}"
                    .Display();

                    /*" -1777- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1250-00-LE-SINISMES-DB-SELECT-1 */
        public void R1250_00_LE_SINISMES_DB_SELECT_1()
        {
            /*" -1764- EXEC SQL SELECT COD_FONTE, NUM_PROTOCOLO_SINI INTO :SINISMES-COD-FONTE, :SINISMES-NUM-PROTOCOLO-SINI FROM SEGUROS.SINISTRO_MESTRE WHERE NUM_APOL_SINISTRO = :SIARDEVC-NUM-APOL-SINISTRO END-EXEC. */

            var r1250_00_LE_SINISMES_DB_SELECT_1_Query1 = new R1250_00_LE_SINISMES_DB_SELECT_1_Query1()
            {
                SIARDEVC_NUM_APOL_SINISTRO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R1250_00_LE_SINISMES_DB_SELECT_1_Query1.Execute(r1250_00_LE_SINISMES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISMES_COD_FONTE, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE);
                _.Move(executed_1.SINISMES_NUM_PROTOCOLO_SINI, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_PROTOCOLO_SINI);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1250_00_EXIT*/

        [StopWatch]
        /*" R1300-00-INCLUI-SIARREVC-SECTION */
        private void R1300_00_INCLUI_SIARREVC_SECTION()
        {
            /*" -1786- MOVE '1300' TO WNR-EXEC-SQL. */
            _.Move("1300", WABEND.WNR_EXEC_SQL);

            /*" -1804- PERFORM R1300_00_INCLUI_SIARREVC_DB_INSERT_1 */

            R1300_00_INCLUI_SIARREVC_DB_INSERT_1();

            /*" -1807- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1816- DISPLAY 'PROBLEMAS NO INSERT SI_AR_RETORNO_VC' ' ' GEARDETA-NOM-ARQUIVO ' ' GEARDETA-SEQ-GERACAO ' ' SIARREVC-TIPO-REGISTRO-VC ' ' SIARREVC-SEQ-REGISTRO-VC ' ' SIARDEVC-NOM-ARQUIVO ' ' SIARDEVC-SEQ-GERACAO ' ' SIARDEVC-TIPO-REGISTRO ' ' SIARDEVC-SEQ-REGISTRO */

                $"PROBLEMAS NO INSERT SI_AR_RETORNO_VC {GEARDETA.DCLGE_AR_DETALHE.GEARDETA_NOM_ARQUIVO} {GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO} {SIARREVC.DCLSI_AR_RETORNO_VC.SIARREVC_TIPO_REGISTRO_VC} {SIARREVC.DCLSI_AR_RETORNO_VC.SIARREVC_SEQ_REGISTRO_VC} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_ARQUIVO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_GERACAO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_REGISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_REGISTRO}"
                .Display();

                /*" -1818- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1818- ADD 1 TO AC-I-SIARREVC. */
            AC_I_SIARREVC.Value = AC_I_SIARREVC + 1;

        }

        [StopWatch]
        /*" R1300-00-INCLUI-SIARREVC-DB-INSERT-1 */
        public void R1300_00_INCLUI_SIARREVC_DB_INSERT_1()
        {
            /*" -1804- EXEC SQL INSERT INTO SEGUROS.SI_AR_RETORNO_VC (NOM_ARQUIVO_VC, SEQ_GERACAO_VC, TIPO_REGISTRO_VC, SEQ_REGISTRO_VC, NOM_ARQUIVO, SEQ_GERACAO, TIPO_REGISTRO, NUM_SEQ_REG) VALUES (:GEARDETA-NOM-ARQUIVO, :GEARDETA-SEQ-GERACAO, :SIARREVC-TIPO-REGISTRO-VC, :SIARREVC-SEQ-REGISTRO-VC, :SIARDEVC-NOM-ARQUIVO, :SIARDEVC-SEQ-GERACAO, :SIARDEVC-TIPO-REGISTRO, :SIARDEVC-SEQ-REGISTRO) END-EXEC. */

            var r1300_00_INCLUI_SIARREVC_DB_INSERT_1_Insert1 = new R1300_00_INCLUI_SIARREVC_DB_INSERT_1_Insert1()
            {
                GEARDETA_NOM_ARQUIVO = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_NOM_ARQUIVO.ToString(),
                GEARDETA_SEQ_GERACAO = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO.ToString(),
                SIARREVC_TIPO_REGISTRO_VC = SIARREVC.DCLSI_AR_RETORNO_VC.SIARREVC_TIPO_REGISTRO_VC.ToString(),
                SIARREVC_SEQ_REGISTRO_VC = SIARREVC.DCLSI_AR_RETORNO_VC.SIARREVC_SEQ_REGISTRO_VC.ToString(),
                SIARDEVC_NOM_ARQUIVO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_ARQUIVO.ToString(),
                SIARDEVC_SEQ_GERACAO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_GERACAO.ToString(),
                SIARDEVC_TIPO_REGISTRO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_REGISTRO.ToString(),
                SIARDEVC_SEQ_REGISTRO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_REGISTRO.ToString(),
            };

            R1300_00_INCLUI_SIARREVC_DB_INSERT_1_Insert1.Execute(r1300_00_INCLUI_SIARREVC_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_00_EXIT*/

        [StopWatch]
        /*" R1400-00-ALTERA-SIARDEVC-SECTION */
        private void R1400_00_ALTERA_SIARDEVC_SECTION()
        {
            /*" -1828- MOVE '1400' TO WNR-EXEC-SQL */
            _.Move("1400", WABEND.WNR_EXEC_SQL);

            /*" -1840- PERFORM R1400_00_ALTERA_SIARDEVC_DB_UPDATE_1 */

            R1400_00_ALTERA_SIARDEVC_DB_UPDATE_1();

            /*" -1843- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1848- DISPLAY 'PROBLEMAS NO UPDATE SI_AR_DETALHE_VC' ' ' SIARDEVC-NOM-ARQUIVO ' ' SIARDEVC-SEQ-GERACAO ' ' SIARDEVC-TIPO-REGISTRO ' ' SIARDEVC-SEQ-REGISTRO */

                $"PROBLEMAS NO UPDATE SI_AR_DETALHE_VC {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_ARQUIVO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_GERACAO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_REGISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_REGISTRO}"
                .Display();

                /*" -1850- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1850- ADD 1 TO AC-U-SIARDEVC. */
            AC_U_SIARDEVC.Value = AC_U_SIARDEVC + 1;

        }

        [StopWatch]
        /*" R1400-00-ALTERA-SIARDEVC-DB-UPDATE-1 */
        public void R1400_00_ALTERA_SIARDEVC_DB_UPDATE_1()
        {
            /*" -1840- EXEC SQL UPDATE SEGUROS.SI_AR_DETALHE_VC SET STA_RETORNO = '2' , NUM_IDENTIFICADOR = :SIARDEVC-NUM-IDENTIFICADOR, VAL_LIQUIDO_PAGTO = :SIARDEVC-VAL-LIQUIDO-PAGTO, NUM_CHEQUE_INTERNO = :SIARDEVC-NUM-CHEQUE-INTERNO, STA_PROCESSAMENTO = :SIARDEVC-STA-PROCESSAMENTO WHERE NOM_ARQUIVO = :SIARDEVC-NOM-ARQUIVO AND SEQ_GERACAO = :SIARDEVC-SEQ-GERACAO AND TIPO_REGISTRO = :SIARDEVC-TIPO-REGISTRO AND SEQ_REGISTRO = :SIARDEVC-SEQ-REGISTRO AND STA_RETORNO = '1' END-EXEC. */

            var r1400_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1 = new R1400_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1()
            {
                SIARDEVC_NUM_CHEQUE_INTERNO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CHEQUE_INTERNO.ToString(),
                SIARDEVC_NUM_IDENTIFICADOR = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_IDENTIFICADOR.ToString(),
                SIARDEVC_VAL_LIQUIDO_PAGTO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_LIQUIDO_PAGTO.ToString(),
                SIARDEVC_STA_PROCESSAMENTO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_PROCESSAMENTO.ToString(),
                SIARDEVC_TIPO_REGISTRO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_REGISTRO.ToString(),
                SIARDEVC_SEQ_REGISTRO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_REGISTRO.ToString(),
                SIARDEVC_NOM_ARQUIVO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_ARQUIVO.ToString(),
                SIARDEVC_SEQ_GERACAO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_GERACAO.ToString(),
            };

            R1400_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1.Execute(r1400_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1450-CHECA-OP-BAIXA-SECTION */
        private void R1450_CHECA_OP_BAIXA_SECTION()
        {
            /*" -1859- SET SIM-ENCONTROU TO TRUE. */
            WS_ENCONTROU["SIM_ENCONTROU"] = true;

            /*" -1861- MOVE '1450' TO WNR-EXEC-SQL */
            _.Move("1450", WABEND.WNR_EXEC_SQL);

            /*" -1869- PERFORM R1450_CHECA_OP_BAIXA_DB_SELECT_1 */

            R1450_CHECA_OP_BAIXA_DB_SELECT_1();

            /*" -1872- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1873- DISPLAY 'ERRO R1450-CHECA-OP-BAIXA - SELECT MOVDEBCE' */
                _.Display($"ERRO R1450-CHECA-OP-BAIXA - SELECT MOVDEBCE");

                /*" -1874- DISPLAY 'APOL-SINISTRO =' SIARDEVC-NUM-SINISTRO-VC */
                _.Display($"APOL-SINISTRO ={SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_SINISTRO_VC}");

                /*" -1875- DISPLAY 'COD-OPERACAO  =' SIARDEVC-COD-OPERACAO */
                _.Display($"COD-OPERACAO  ={SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_OPERACAO}");

                /*" -1876- DISPLAY 'OCOR-HISTORIC =' SIARDEVC-OCORR-HISTORICO */
                _.Display($"OCOR-HISTORIC ={SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO}");

                /*" -1878- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1879- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1880- SET NAO-ENCONTROU TO TRUE. */
                WS_ENCONTROU["NAO_ENCONTROU"] = true;
            }


        }

        [StopWatch]
        /*" R1450-CHECA-OP-BAIXA-DB-SELECT-1 */
        public void R1450_CHECA_OP_BAIXA_DB_SELECT_1()
        {
            /*" -1869- EXEC SQL SELECT NUM_ENDOSSO INTO :MOVDEBCE-NUM-ENDOSSO FROM SEGUROS.MOVTO_DEBITOCC_CEF WHERE NUM_APOLICE = :SIARDEVC-NUM-APOL-SINISTRO AND NUM_ENDOSSO = :SIARDEVC-COD-OPERACAO AND NUM_PARCELA = :SIARDEVC-OCORR-HISTORICO END-EXEC */

            var r1450_CHECA_OP_BAIXA_DB_SELECT_1_Query1 = new R1450_CHECA_OP_BAIXA_DB_SELECT_1_Query1()
            {
                SIARDEVC_NUM_APOL_SINISTRO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO.ToString(),
                SIARDEVC_OCORR_HISTORICO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO.ToString(),
                SIARDEVC_COD_OPERACAO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_OPERACAO.ToString(),
            };

            var executed_1 = R1450_CHECA_OP_BAIXA_DB_SELECT_1_Query1.Execute(r1450_CHECA_OP_BAIXA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVDEBCE_NUM_ENDOSSO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1450_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-GERA-OP-BAIXA-SECTION */
        private void R1500_00_GERA_OP_BAIXA_SECTION()
        {
            /*" -1891- PERFORM R1510-00-CONSULTA-SINI. */

            R1510_00_CONSULTA_SINI_SECTION();

            /*" -1892- MOVE SISTEMAS-DATA-MOV-ABERTO TO SINISHIS-DATA-MOVIMENTO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO);

            /*" -1893- MOVE 'SASEGURO' TO SINISHIS-COD-USUARIO */
            _.Move("SASEGURO", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_USUARIO);

            /*" -1894- MOVE SIARDEVC-NUM-APOLICE TO SINISHIS-NUM-APOLICE */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOLICE);

            /*" -1894- MOVE 'SI9211B' TO SINISHIS-NOM-PROGRAMA. */
            _.Move("SI9211B", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOM_PROGRAMA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1510-00-CONSULTA-SINI-SECTION */
        private void R1510_00_CONSULTA_SINI_SECTION()
        {
            /*" -1907- MOVE '1510' TO WNR-EXEC-SQL. */
            _.Move("1510", WABEND.WNR_EXEC_SQL);

            /*" -1948- PERFORM R1510_00_CONSULTA_SINI_DB_SELECT_1 */

            R1510_00_CONSULTA_SINI_DB_SELECT_1();

            /*" -1951- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1956- DISPLAY 'PROBLEMAS NO SELECT BAIXA SINISTRO_HISTORICO' ' ' SIARDEVC-NUM-APOL-SINISTRO ' ' SIARDEVC-OCORR-HISTORICO ' ' SIARDEVC-COD-OPERACAO ' ' SIARDEVC-NUM-CHEQUE-INTERNO */

                $"PROBLEMAS NO SELECT BAIXA SINISTRO_HISTORICO {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_OPERACAO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CHEQUE_INTERNO}"
                .Display();

                /*" -1958- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1958- ADD 1 TO AC-L-SINISHIS. */
            AC_L_SINISHIS.Value = AC_L_SINISHIS + 1;

        }

        [StopWatch]
        /*" R1510-00-CONSULTA-SINI-DB-SELECT-1 */
        public void R1510_00_CONSULTA_SINI_DB_SELECT_1()
        {
            /*" -1948- EXEC SQL SELECT H.NOME_FAVORECIDO , H.VAL_OPERACAO , H.TIPO_FAVORECIDO , H.DATA_NEGOCIADA , H.FONTE_PAGAMENTO , H.COD_PREST_SERVICO , H.COD_SERVICO , H.ORDEM_PAGAMENTO , H.NUM_RECIBO , H.NUM_MOV_SINISTRO , H.SIT_CONTABIL , H.SIT_REGISTRO , H.COD_PRODUTO INTO :SINISHIS-NOME-FAVORECIDO , :SINISHIS-VAL-OPERACAO , :SINISHIS-TIPO-FAVORECIDO , :SINISHIS-DATA-NEGOCIADA , :SINISHIS-FONTE-PAGAMENTO , :SINISHIS-COD-PREST-SERVICO, :SINISHIS-COD-SERVICO , :SINISHIS-ORDEM-PAGAMENTO , :SINISHIS-NUM-RECIBO , :SINISHIS-NUM-MOV-SINISTRO , :SINISHIS-SIT-CONTABIL , :SINISHIS-SIT-REGISTRO , :SINISHIS-COD-PRODUTO FROM SEGUROS.SINISTRO_HISTORICO H WHERE H.NUM_APOL_SINISTRO = :SIARDEVC-NUM-APOL-SINISTRO AND H.OCORR_HISTORICO = :SIARDEVC-OCORR-HISTORICO AND H.COD_OPERACAO = :SIARDEVC-COD-OPERACAO AND NOT EXISTS (SELECT H1.NUM_APOL_SINISTRO FROM SEGUROS.SINISTRO_HISTORICO H1 WHERE H1.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND H1.OCORR_HISTORICO = H.OCORR_HISTORICO AND H1.COD_OPERACAO IN (1091,1191,1050) ) WITH UR END-EXEC. */

            var r1510_00_CONSULTA_SINI_DB_SELECT_1_Query1 = new R1510_00_CONSULTA_SINI_DB_SELECT_1_Query1()
            {
                SIARDEVC_NUM_APOL_SINISTRO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO.ToString(),
                SIARDEVC_OCORR_HISTORICO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO.ToString(),
                SIARDEVC_COD_OPERACAO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_OPERACAO.ToString(),
            };

            var executed_1 = R1510_00_CONSULTA_SINI_DB_SELECT_1_Query1.Execute(r1510_00_CONSULTA_SINI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISHIS_NOME_FAVORECIDO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO);
                _.Move(executed_1.SINISHIS_VAL_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);
                _.Move(executed_1.SINISHIS_TIPO_FAVORECIDO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_TIPO_FAVORECIDO);
                _.Move(executed_1.SINISHIS_DATA_NEGOCIADA, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_NEGOCIADA);
                _.Move(executed_1.SINISHIS_FONTE_PAGAMENTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_FONTE_PAGAMENTO);
                _.Move(executed_1.SINISHIS_COD_PREST_SERVICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO);
                _.Move(executed_1.SINISHIS_COD_SERVICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_SERVICO);
                _.Move(executed_1.SINISHIS_ORDEM_PAGAMENTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_ORDEM_PAGAMENTO);
                _.Move(executed_1.SINISHIS_NUM_RECIBO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_RECIBO);
                _.Move(executed_1.SINISHIS_NUM_MOV_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_MOV_SINISTRO);
                _.Move(executed_1.SINISHIS_SIT_CONTABIL, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL);
                _.Move(executed_1.SINISHIS_SIT_REGISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_REGISTRO);
                _.Move(executed_1.SINISHIS_COD_PRODUTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1510_99_SAIDA*/

        [StopWatch]
        /*" R1520-00-INCLUI-SINIS-SECTION */
        private void R1520_00_INCLUI_SINIS_SECTION()
        {
            /*" -1968- MOVE '1520' TO WNR-EXEC-SQL. */
            _.Move("1520", WABEND.WNR_EXEC_SQL);

            /*" -2020- PERFORM R1520_00_INCLUI_SINIS_DB_INSERT_1 */

            R1520_00_INCLUI_SINIS_DB_INSERT_1();

            /*" -2023- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2024- DISPLAY ' ' SQLCA */
                _.Display($" {DB.SQLCA}");

                /*" -2033- DISPLAY 'PROBLEMAS NO INSERT BAIXA SINISTRO_HISTORICO' ' ' SINISHIS-NUM-APOL-SINISTRO ' ' SINISHIS-OCORR-HISTORICO ' ' SINISHIS-COD-OPERACAO ' ' SINISHIS-SIT-CONTABIL ' ' SINISHIS-SIT-REGISTRO ' ' SIARDEVC-NUM-CHEQUE-INTERNO ' ' SIARDEVC-NUM-APOLICE ' ' SIARDEVC-COD-OPERACAO */

                $"PROBLEMAS NO INSERT BAIXA SINISTRO_HISTORICO {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_REGISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CHEQUE_INTERNO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_OPERACAO}"
                .Display();

                /*" -2035- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2035- ADD 1 TO AC-I-SINISHIS. */
            AC_I_SINISHIS.Value = AC_I_SINISHIS + 1;

        }

        [StopWatch]
        /*" R1520-00-INCLUI-SINIS-DB-INSERT-1 */
        public void R1520_00_INCLUI_SINIS_DB_INSERT_1()
        {
            /*" -2020- EXEC SQL INSERT INTO SEGUROS.SINISTRO_HISTORICO (COD_EMPRESA, TIPO_REGISTRO, NUM_APOL_SINISTRO, OCORR_HISTORICO, COD_OPERACAO, DATA_MOVIMENTO, HORA_OPERACAO, NOME_FAVORECIDO, VAL_OPERACAO, DATA_LIM_CORRECAO, TIPO_FAVORECIDO, DATA_NEGOCIADA, FONTE_PAGAMENTO, COD_PREST_SERVICO, COD_SERVICO, ORDEM_PAGAMENTO, NUM_RECIBO, NUM_MOV_SINISTRO, COD_USUARIO, SIT_CONTABIL, SIT_REGISTRO, TIMESTAMP, NUM_APOLICE, COD_PRODUTO, NOM_PROGRAMA) VALUES (0, '1' , :SINISHIS-NUM-APOL-SINISTRO, :SINISHIS-OCORR-HISTORICO, :SINISHIS-COD-OPERACAO, :SINISHIS-DATA-MOVIMENTO, CURRENT TIME, :SINISHIS-NOME-FAVORECIDO, :SINISHIS-VAL-OPERACAO, :SINISHIS-DATA-NEGOCIADA, :SINISHIS-TIPO-FAVORECIDO, :SINISHIS-DATA-NEGOCIADA, :SINISHIS-FONTE-PAGAMENTO, :SINISHIS-COD-PREST-SERVICO, :SINISHIS-COD-SERVICO, :SINISHIS-ORDEM-PAGAMENTO, :SINISHIS-NUM-RECIBO , :SINISHIS-NUM-MOV-SINISTRO, :SINISHIS-COD-USUARIO, :SINISHIS-SIT-CONTABIL, :SINISHIS-SIT-REGISTRO, CURRENT TIMESTAMP , :SINISHIS-NUM-APOLICE, :SINISHIS-COD-PRODUTO, :SINISHIS-NOM-PROGRAMA) END-EXEC. */

            var r1520_00_INCLUI_SINIS_DB_INSERT_1_Insert1 = new R1520_00_INCLUI_SINIS_DB_INSERT_1_Insert1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
                SINISHIS_COD_OPERACAO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.ToString(),
                SINISHIS_DATA_MOVIMENTO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO.ToString(),
                SINISHIS_NOME_FAVORECIDO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO.ToString(),
                SINISHIS_VAL_OPERACAO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO.ToString(),
                SINISHIS_DATA_NEGOCIADA = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_NEGOCIADA.ToString(),
                SINISHIS_TIPO_FAVORECIDO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_TIPO_FAVORECIDO.ToString(),
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
            };

            R1520_00_INCLUI_SINIS_DB_INSERT_1_Insert1.Execute(r1520_00_INCLUI_SINIS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1520_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-ATUAL-INDENIZ-SECTION */
        private void R1600_00_ATUAL_INDENIZ_SECTION()
        {
            /*" -2050- PERFORM R1610-00-ATUAL-SI-PESS. */

            R1610_00_ATUAL_SI_PESS_SECTION();

            /*" -2052- PERFORM R1620-00-ATUAL-SINI-CHEQ. */

            R1620_00_ATUAL_SINI_CHEQ_SECTION();

            /*" -2054- PERFORM R1630-00-ATUAL-PAGA-DOCFIS */

            R1630_00_ATUAL_PAGA_DOCFIS_SECTION();

            /*" -2056- MOVE SIARDEVC-NUM-APOL-SINISTRO TO MOVDEBCE-NUM-APOLICE */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);

            /*" -2057- MOVE SIARDEVC-COD-OPERACAO TO MOVDEBCE-NUM-ENDOSSO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_OPERACAO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);

            /*" -2061- MOVE SIARDEVC-OCORR-HISTORICO TO MOVDEBCE-NUM-PARCELA */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA);

            /*" -2062- PERFORM R1640-00-ATUAL-MOVTO-CONTA. */

            R1640_00_ATUAL_MOVTO_CONTA_SECTION();

            /*" -2063- IF SIM-ENCONTROU */

            if (WS_ENCONTROU["SIM_ENCONTROU"])
            {

                /*" -2065- GO TO R1600-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2067- PERFORM R1660-00-ATUAL-MOVDEB-SAP. */

            R1660_00_ATUAL_MOVDEB_SAP_SECTION();

            /*" -2067- ADD 1 TO AC-U-OPERACAO. */
            AC_U_OPERACAO.Value = AC_U_OPERACAO + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1610-00-ATUAL-SI-PESS-SECTION */
        private void R1610_00_ATUAL_SI_PESS_SECTION()
        {
            /*" -2076- MOVE '1610' TO WNR-EXEC-SQL. */
            _.Move("1610", WABEND.WNR_EXEC_SQL);

            /*" -2077- MOVE ZEROS TO HOST-COUNT. */
            _.Move(0, HOST_COUNT);

            /*" -2084- PERFORM R1610_00_ATUAL_SI_PESS_DB_SELECT_1 */

            R1610_00_ATUAL_SI_PESS_DB_SELECT_1();

            /*" -2087- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2092- DISPLAY 'PROBLEMAS NO SELECT SI_PESS_SINISTRO' ' ' SIARDEVC-NUM-APOL-SINISTRO ' ' SIARDEVC-OCORR-HISTORICO ' ' SIARDEVC-COD-OPERACAO ' ' SIARDEVC-NUM-CHEQUE-INTERNO */

                $"PROBLEMAS NO SELECT SI_PESS_SINISTRO {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_OPERACAO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CHEQUE_INTERNO}"
                .Display();

                /*" -2094- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2095- ADD 1 TO AC-L-SINIPESS. */
            AC_L_SINIPESS.Value = AC_L_SINIPESS + 1;

            /*" -2096- IF HOST-COUNT EQUAL ZEROS */

            if (HOST_COUNT == 00)
            {

                /*" -2101- DISPLAY 'SINISTRO NAO ENCONTRADO - SI_PESS_SINISTRO' ' ' SIARDEVC-NUM-APOL-SINISTRO ' ' SIARDEVC-OCORR-HISTORICO ' ' SIARDEVC-COD-OPERACAO ' ' SIARDEVC-NUM-CHEQUE-INTERNO */

                $"SINISTRO NAO ENCONTRADO - SI_PESS_SINISTRO {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_OPERACAO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CHEQUE_INTERNO}"
                .Display();

                /*" -2103- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2109- PERFORM R1610_00_ATUAL_SI_PESS_DB_UPDATE_1 */

            R1610_00_ATUAL_SI_PESS_DB_UPDATE_1();

            /*" -2111- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2117- DISPLAY 'PROBLEMAS NO UPDATE SI_PESS_SINISTRO' ' ' SIARDEVC-NUM-APOL-SINISTRO ' ' SIARDEVC-OCORR-HISTORICO ' ' SIARDEVC-COD-OPERACAO ' ' SIARDEVC-NUM-CHEQUE-INTERNO ' S ' SINISHIS-COD-OPERACAO */

                $"PROBLEMAS NO UPDATE SI_PESS_SINISTRO {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_OPERACAO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CHEQUE_INTERNO} S {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO}"
                .Display();

                /*" -2118- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2119- ADD 1 TO AC-U-SINIPESS. */
            AC_U_SINIPESS.Value = AC_U_SINIPESS + 1;

        }

        [StopWatch]
        /*" R1610-00-ATUAL-SI-PESS-DB-SELECT-1 */
        public void R1610_00_ATUAL_SI_PESS_DB_SELECT_1()
        {
            /*" -2084- EXEC SQL SELECT VALUE(COUNT(*), 0) INTO :HOST-COUNT FROM SEGUROS.SI_PESS_SINISTRO WHERE NUM_APOL_SINISTRO = :SIARDEVC-NUM-APOL-SINISTRO AND OCORR_HISTORICO = :SIARDEVC-OCORR-HISTORICO AND COD_OPERACAO = :SIARDEVC-COD-OPERACAO END-EXEC. */

            var r1610_00_ATUAL_SI_PESS_DB_SELECT_1_Query1 = new R1610_00_ATUAL_SI_PESS_DB_SELECT_1_Query1()
            {
                SIARDEVC_NUM_APOL_SINISTRO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO.ToString(),
                SIARDEVC_OCORR_HISTORICO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO.ToString(),
                SIARDEVC_COD_OPERACAO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_OPERACAO.ToString(),
            };

            var executed_1 = R1610_00_ATUAL_SI_PESS_DB_SELECT_1_Query1.Execute(r1610_00_ATUAL_SI_PESS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_COUNT, HOST_COUNT);
            }


        }

        [StopWatch]
        /*" R1610-00-ATUAL-SI-PESS-DB-UPDATE-1 */
        public void R1610_00_ATUAL_SI_PESS_DB_UPDATE_1()
        {
            /*" -2109- EXEC SQL UPDATE SEGUROS.SI_PESS_SINISTRO SET COD_OPERACAO = :SINISHIS-COD-OPERACAO WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND COD_OPERACAO = :SIARDEVC-COD-OPERACAO END-EXEC. */

            var r1610_00_ATUAL_SI_PESS_DB_UPDATE_1_Update1 = new R1610_00_ATUAL_SI_PESS_DB_UPDATE_1_Update1()
            {
                SINISHIS_COD_OPERACAO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.ToString(),
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
                SIARDEVC_COD_OPERACAO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_OPERACAO.ToString(),
            };

            R1610_00_ATUAL_SI_PESS_DB_UPDATE_1_Update1.Execute(r1610_00_ATUAL_SI_PESS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1610_99_SAIDA*/

        [StopWatch]
        /*" R1620-00-ATUAL-SINI-CHEQ-SECTION */
        private void R1620_00_ATUAL_SINI_CHEQ_SECTION()
        {
            /*" -2128- MOVE '1620' TO WNR-EXEC-SQL. */
            _.Move("1620", WABEND.WNR_EXEC_SQL);

            /*" -2129- MOVE ZEROS TO HOST-COUNT. */
            _.Move(0, HOST_COUNT);

            /*" -2136- PERFORM R1620_00_ATUAL_SINI_CHEQ_DB_SELECT_1 */

            R1620_00_ATUAL_SINI_CHEQ_DB_SELECT_1();

            /*" -2139- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2144- DISPLAY 'PROBLEMAS NO SELECT SI_SINI_CHEQUE' ' ' SIARDEVC-NUM-APOL-SINISTRO ' ' SIARDEVC-OCORR-HISTORICO ' ' SIARDEVC-COD-OPERACAO ' ' SIARDEVC-NUM-CHEQUE-INTERNO */

                $"PROBLEMAS NO SELECT SI_SINI_CHEQUE {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_OPERACAO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CHEQUE_INTERNO}"
                .Display();

                /*" -2145- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2147- ADD 1 TO AC-L-SINICHEQ. */
            AC_L_SINICHEQ.Value = AC_L_SINICHEQ + 1;

            /*" -2148- IF HOST-COUNT EQUAL ZEROS */

            if (HOST_COUNT == 00)
            {

                /*" -2153- DISPLAY 'SINISTRO NAO ENCONTRADO - SI_SINI_CHEQUE' ' ' SIARDEVC-NUM-APOL-SINISTRO ' ' SIARDEVC-OCORR-HISTORICO ' ' SIARDEVC-COD-OPERACAO ' ' SIARDEVC-NUM-CHEQUE-INTERNO */

                $"SINISTRO NAO ENCONTRADO - SI_SINI_CHEQUE {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_OPERACAO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CHEQUE_INTERNO}"
                .Display();

                /*" -2155- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2161- PERFORM R1620_00_ATUAL_SINI_CHEQ_DB_UPDATE_1 */

            R1620_00_ATUAL_SINI_CHEQ_DB_UPDATE_1();

            /*" -2164- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2170- DISPLAY 'PROBLEMAS NO UPDATE SI_PESS_SINISTRO' ' ' SIARDEVC-NUM-APOL-SINISTRO ' ' SIARDEVC-OCORR-HISTORICO ' ' SIARDEVC-COD-OPERACAO ' ' SIARDEVC-NUM-CHEQUE-INTERNO ' S ' SINISHIS-COD-OPERACAO */

                $"PROBLEMAS NO UPDATE SI_PESS_SINISTRO {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_OPERACAO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CHEQUE_INTERNO} S {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO}"
                .Display();

                /*" -2171- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2171- ADD 1 TO AC-U-SINICHEQ. */
            AC_U_SINICHEQ.Value = AC_U_SINICHEQ + 1;

        }

        [StopWatch]
        /*" R1620-00-ATUAL-SINI-CHEQ-DB-SELECT-1 */
        public void R1620_00_ATUAL_SINI_CHEQ_DB_SELECT_1()
        {
            /*" -2136- EXEC SQL SELECT VALUE(COUNT(*), 0) INTO :HOST-COUNT FROM SEGUROS.SI_SINI_CHEQUE WHERE NUM_APOL_SINISTRO = :SIARDEVC-NUM-APOL-SINISTRO AND OCORR_HISTORICO = :SIARDEVC-OCORR-HISTORICO AND COD_OPERACAO = :SIARDEVC-COD-OPERACAO END-EXEC. */

            var r1620_00_ATUAL_SINI_CHEQ_DB_SELECT_1_Query1 = new R1620_00_ATUAL_SINI_CHEQ_DB_SELECT_1_Query1()
            {
                SIARDEVC_NUM_APOL_SINISTRO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO.ToString(),
                SIARDEVC_OCORR_HISTORICO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO.ToString(),
                SIARDEVC_COD_OPERACAO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_OPERACAO.ToString(),
            };

            var executed_1 = R1620_00_ATUAL_SINI_CHEQ_DB_SELECT_1_Query1.Execute(r1620_00_ATUAL_SINI_CHEQ_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_COUNT, HOST_COUNT);
            }


        }

        [StopWatch]
        /*" R1620-00-ATUAL-SINI-CHEQ-DB-UPDATE-1 */
        public void R1620_00_ATUAL_SINI_CHEQ_DB_UPDATE_1()
        {
            /*" -2161- EXEC SQL UPDATE SEGUROS.SI_SINI_CHEQUE SET COD_OPERACAO = :SINISHIS-COD-OPERACAO WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND COD_OPERACAO = :SIARDEVC-COD-OPERACAO END-EXEC. */

            var r1620_00_ATUAL_SINI_CHEQ_DB_UPDATE_1_Update1 = new R1620_00_ATUAL_SINI_CHEQ_DB_UPDATE_1_Update1()
            {
                SINISHIS_COD_OPERACAO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.ToString(),
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
                SIARDEVC_COD_OPERACAO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_OPERACAO.ToString(),
            };

            R1620_00_ATUAL_SINI_CHEQ_DB_UPDATE_1_Update1.Execute(r1620_00_ATUAL_SINI_CHEQ_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1620_99_SAIDA*/

        [StopWatch]
        /*" R1630-00-ATUAL-PAGA-DOCFIS-SECTION */
        private void R1630_00_ATUAL_PAGA_DOCFIS_SECTION()
        {
            /*" -2180- MOVE '1630' TO WNR-EXEC-SQL. */
            _.Move("1630", WABEND.WNR_EXEC_SQL);

            /*" -2181- MOVE ZEROS TO HOST-COUNT. */
            _.Move(0, HOST_COUNT);

            /*" -2188- PERFORM R1630_00_ATUAL_PAGA_DOCFIS_DB_SELECT_1 */

            R1630_00_ATUAL_PAGA_DOCFIS_DB_SELECT_1();

            /*" -2191- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2196- DISPLAY 'PROBLEMAS NO SELECT SI_PAGA_DOC_FISCAL' ' ' SIARDEVC-NUM-APOL-SINISTRO ' ' SIARDEVC-OCORR-HISTORICO ' ' SIARDEVC-COD-OPERACAO ' ' SIARDEVC-NUM-CHEQUE-INTERNO */

                $"PROBLEMAS NO SELECT SI_PAGA_DOC_FISCAL {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_OPERACAO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CHEQUE_INTERNO}"
                .Display();

                /*" -2198- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2199- ADD 1 TO AC-L-PGTODOCF */
            AC_L_PGTODOCF.Value = AC_L_PGTODOCF + 1;

            /*" -2200- IF HOST-COUNT EQUAL ZEROS */

            if (HOST_COUNT == 00)
            {

                /*" -2203- IF SIARDEVC-IND-FAVORECIDO = '2' OR (SIARDEVC-IND-FAVORECIDO = '5' AND SIARDEVC-COD-RAMO = 42) */

                if (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_IND_FAVORECIDO == "2" || (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_IND_FAVORECIDO == "5" && SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_RAMO == 42))
                {

                    /*" -2210- DISPLAY 'SINISTRO NAO ENCONTRADO - SI_PAGA_DOC_FISCAL' ' ' SIARDEVC-NUM-APOL-SINISTRO ' ' SIARDEVC-OCORR-HISTORICO ' ' SIARDEVC-COD-OPERACAO ' ' SIARDEVC-COD-RAMO ' ' SIARDEVC-IND-FAVORECIDO ' ' SIARDEVC-NUM-CHEQUE-INTERNO */

                    $"SINISTRO NAO ENCONTRADO - SI_PAGA_DOC_FISCAL {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_OPERACAO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_RAMO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_IND_FAVORECIDO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CHEQUE_INTERNO}"
                    .Display();

                    /*" -2211- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2212- ELSE */
                }
                else
                {


                    /*" -2213- ADD 1 TO AC-L-SEM-PGTODOCF */
                    AC_L_SEM_PGTODOCF.Value = AC_L_SEM_PGTODOCF + 1;

                    /*" -2215- GO TO R1630-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1630_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -2221- PERFORM R1630_00_ATUAL_PAGA_DOCFIS_DB_UPDATE_1 */

            R1630_00_ATUAL_PAGA_DOCFIS_DB_UPDATE_1();

            /*" -2223- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2231- DISPLAY 'PROBLEMAS NO UPDATE SI_PAGA_DOC_FISCAL' ' ' SIARDEVC-NUM-APOL-SINISTRO ' ' SIARDEVC-OCORR-HISTORICO ' ' SIARDEVC-COD-OPERACAO ' ' SIARDEVC-COD-RAMO ' ' SIARDEVC-IND-FAVORECIDO ' ' SIARDEVC-NUM-CHEQUE-INTERNO ' S ' SINISHIS-COD-OPERACAO */

                $"PROBLEMAS NO UPDATE SI_PAGA_DOC_FISCAL {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_OPERACAO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_RAMO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_IND_FAVORECIDO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CHEQUE_INTERNO} S {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO}"
                .Display();

                /*" -2233- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2233- ADD 1 TO AC-U-PGTODOCF. */
            AC_U_PGTODOCF.Value = AC_U_PGTODOCF + 1;

        }

        [StopWatch]
        /*" R1630-00-ATUAL-PAGA-DOCFIS-DB-SELECT-1 */
        public void R1630_00_ATUAL_PAGA_DOCFIS_DB_SELECT_1()
        {
            /*" -2188- EXEC SQL SELECT VALUE(COUNT(*), 0) INTO :HOST-COUNT FROM SEGUROS.SI_PAGA_DOC_FISCAL WHERE NUM_APOL_SINISTRO = :SIARDEVC-NUM-APOL-SINISTRO AND OCORR_HISTORICO = :SIARDEVC-OCORR-HISTORICO AND COD_OPERACAO = :SIARDEVC-COD-OPERACAO END-EXEC. */

            var r1630_00_ATUAL_PAGA_DOCFIS_DB_SELECT_1_Query1 = new R1630_00_ATUAL_PAGA_DOCFIS_DB_SELECT_1_Query1()
            {
                SIARDEVC_NUM_APOL_SINISTRO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO.ToString(),
                SIARDEVC_OCORR_HISTORICO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO.ToString(),
                SIARDEVC_COD_OPERACAO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_OPERACAO.ToString(),
            };

            var executed_1 = R1630_00_ATUAL_PAGA_DOCFIS_DB_SELECT_1_Query1.Execute(r1630_00_ATUAL_PAGA_DOCFIS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_COUNT, HOST_COUNT);
            }


        }

        [StopWatch]
        /*" R1630-00-ATUAL-PAGA-DOCFIS-DB-UPDATE-1 */
        public void R1630_00_ATUAL_PAGA_DOCFIS_DB_UPDATE_1()
        {
            /*" -2221- EXEC SQL UPDATE SEGUROS.SI_PAGA_DOC_FISCAL SET COD_OPERACAO = :SINISHIS-COD-OPERACAO WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND COD_OPERACAO = :SIARDEVC-COD-OPERACAO END-EXEC. */

            var r1630_00_ATUAL_PAGA_DOCFIS_DB_UPDATE_1_Update1 = new R1630_00_ATUAL_PAGA_DOCFIS_DB_UPDATE_1_Update1()
            {
                SINISHIS_COD_OPERACAO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.ToString(),
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
                SIARDEVC_COD_OPERACAO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_OPERACAO.ToString(),
            };

            R1630_00_ATUAL_PAGA_DOCFIS_DB_UPDATE_1_Update1.Execute(r1630_00_ATUAL_PAGA_DOCFIS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1630_99_SAIDA*/

        [StopWatch]
        /*" R1640-00-ATUAL-MOVTO-CONTA-SECTION */
        private void R1640_00_ATUAL_MOVTO_CONTA_SECTION()
        {
            /*" -2241- MOVE '1640' TO WNR-EXEC-SQL. */
            _.Move("1640", WABEND.WNR_EXEC_SQL);

            /*" -2242- MOVE ZEROS TO HOST-COUNT. */
            _.Move(0, HOST_COUNT);

            /*" -2244- SET NAO-ENCONTROU TO TRUE. */
            WS_ENCONTROU["NAO_ENCONTROU"] = true;

            /*" -2269- PERFORM R1640_00_ATUAL_MOVTO_CONTA_DB_SELECT_1 */

            R1640_00_ATUAL_MOVTO_CONTA_DB_SELECT_1();

            /*" -2271- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -2276- DISPLAY 'PROBLEMAS NO SELECT GE_MOVTO_CONTA' ' ' MOVDEBCE-NUM-APOLICE ' ' MOVDEBCE-NUM-ENDOSSO ' ' MOVDEBCE-NUM-PARCELA ' ' SIARDEVC-NUM-CHEQUE-INTERNO */

                $"PROBLEMAS NO SELECT GE_MOVTO_CONTA {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE} {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO} {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CHEQUE_INTERNO}"
                .Display();

                /*" -2278- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2279- ADD 1 TO AC-L-GEMVTOCT */
            AC_L_GEMVTOCT.Value = AC_L_GEMVTOCT + 1;

            /*" -2281- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2289- PERFORM R1640_00_ATUAL_MOVTO_CONTA_DB_SELECT_2 */

                R1640_00_ATUAL_MOVTO_CONTA_DB_SELECT_2();

                /*" -2291- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2292- DISPLAY 'PROBLEMAS NO SELECT SINISTRO_HISTORICO' */
                    _.Display($"PROBLEMAS NO SELECT SINISTRO_HISTORICO");

                    /*" -2297- DISPLAY 'MOVTO_DEBITO_CC' ' ' MOVDEBCE-NUM-APOLICE ' ' MOVDEBCE-NUM-ENDOSSO ' ' MOVDEBCE-NUM-PARCELA ' ' SIARDEVC-NUM-CHEQUE-INTERNO */

                    $"MOVTO_DEBITO_CC {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE} {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO} {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CHEQUE_INTERNO}"
                    .Display();

                    /*" -2301- DISPLAY 'SI_AR_DETALHE_VC' ' ' SIARDEVC-NUM-APOL-SINISTRO ' ' SIARDEVC-OCORR-HISTORICO ' ' SIARDEVC-COD-OPERACAO */

                    $"SI_AR_DETALHE_VC {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_OPERACAO}"
                    .Display();

                    /*" -2302- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2303- END-IF */
                }


                /*" -2304- ADD 1 TO AC-L-SINISHIS-H */
                AC_L_SINISHIS_H.Value = AC_L_SINISHIS_H + 1;

                /*" -2305- IF HOST-COUNT EQUAL ZEROS */

                if (HOST_COUNT == 00)
                {

                    /*" -2310- DISPLAY 'SINISTRO NAO ENCONTRADO - SINISTRO_HISTORICO' ' ' MOVDEBCE-NUM-APOLICE ' ' MOVDEBCE-NUM-ENDOSSO ' ' MOVDEBCE-NUM-PARCELA ' ' SIARDEVC-NUM-CHEQUE-INTERNO */

                    $"SINISTRO NAO ENCONTRADO - SINISTRO_HISTORICO {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE} {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO} {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CHEQUE_INTERNO}"
                    .Display();

                    /*" -2311- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2312- END-IF */
                }


                /*" -2314- DISPLAY 'CASOS DE PGTO DE CHEQUE ------------------------ '------>' */
                _.Display($"CASOS DE PGTO DE CHEQUE ------------------------ ------>");

                /*" -2318- DISPLAY 'SINI - ' MOVDEBCE-NUM-APOLICE ' OP - ' MOVDEBCE-NUM-ENDOSSO ' OC - ' MOVDEBCE-NUM-PARCELA ' CH - ' SIARDEVC-NUM-CHEQUE-INTERNO */

                $"SINI - {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE} OP - {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO} OC - {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA} CH - {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CHEQUE_INTERNO}"
                .Display();

                /*" -2320- DISPLAY '------------------------------------------------ '------*' */
                _.Display($"------------------------------------------------ ------*");

                /*" -2321- SET SIM-ENCONTROU TO TRUE */
                WS_ENCONTROU["SIM_ENCONTROU"] = true;

                /*" -2322- GO TO R1640-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1640_99_SAIDA*/ //GOTO
                return;

                /*" -2331- END-IF. */
            }


            /*" -2333- PERFORM R1641-00-DELET-GE-MOVTO-CONT. */

            R1641_00_DELET_GE_MOVTO_CONT_SECTION();

            /*" -2335- PERFORM R1642-00-ATUAL-MOVTO-DEBT. */

            R1642_00_ATUAL_MOVTO_DEBT_SECTION();

            /*" -2335- PERFORM R1643-00-INSERT-GE-MOVTO-CONT. */

            R1643_00_INSERT_GE_MOVTO_CONT_SECTION();

        }

        [StopWatch]
        /*" R1640-00-ATUAL-MOVTO-CONTA-DB-SELECT-1 */
        public void R1640_00_ATUAL_MOVTO_CONTA_DB_SELECT_1()
        {
            /*" -2269- EXEC SQL SELECT NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , COD_CONVENIO , NSAS , COD_AGENCIA , COD_BANCO , NUM_CONTA_CNB , NUM_DV_CONTA_CNB , IND_CONTA_BANCARIA INTO :GE369-NUM-APOLICE , :GE369-NUM-ENDOSSO , :GE369-NUM-PARCELA , :GE369-COD-CONVENIO , :GE369-NSAS , :GE369-COD-AGENCIA , :GE369-COD-BANCO , :GE369-NUM-CONTA-CNB , :GE369-NUM-DV-CONTA-CNB , :GE369-IND-CONTA-BANCARIA FROM SEGUROS.GE_MOVTO_CONTA WHERE NUM_APOLICE = :MOVDEBCE-NUM-APOLICE AND NUM_ENDOSSO = :MOVDEBCE-NUM-ENDOSSO AND NUM_PARCELA = :MOVDEBCE-NUM-PARCELA END-EXEC. */

            var r1640_00_ATUAL_MOVTO_CONTA_DB_SELECT_1_Query1 = new R1640_00_ATUAL_MOVTO_CONTA_DB_SELECT_1_Query1()
            {
                MOVDEBCE_NUM_APOLICE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.ToString(),
                MOVDEBCE_NUM_ENDOSSO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO.ToString(),
                MOVDEBCE_NUM_PARCELA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA.ToString(),
            };

            var executed_1 = R1640_00_ATUAL_MOVTO_CONTA_DB_SELECT_1_Query1.Execute(r1640_00_ATUAL_MOVTO_CONTA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE369_NUM_APOLICE, GE369.DCLGE_MOVTO_CONTA.GE369_NUM_APOLICE);
                _.Move(executed_1.GE369_NUM_ENDOSSO, GE369.DCLGE_MOVTO_CONTA.GE369_NUM_ENDOSSO);
                _.Move(executed_1.GE369_NUM_PARCELA, GE369.DCLGE_MOVTO_CONTA.GE369_NUM_PARCELA);
                _.Move(executed_1.GE369_COD_CONVENIO, GE369.DCLGE_MOVTO_CONTA.GE369_COD_CONVENIO);
                _.Move(executed_1.GE369_NSAS, GE369.DCLGE_MOVTO_CONTA.GE369_NSAS);
                _.Move(executed_1.GE369_COD_AGENCIA, GE369.DCLGE_MOVTO_CONTA.GE369_COD_AGENCIA);
                _.Move(executed_1.GE369_COD_BANCO, GE369.DCLGE_MOVTO_CONTA.GE369_COD_BANCO);
                _.Move(executed_1.GE369_NUM_CONTA_CNB, GE369.DCLGE_MOVTO_CONTA.GE369_NUM_CONTA_CNB);
                _.Move(executed_1.GE369_NUM_DV_CONTA_CNB, GE369.DCLGE_MOVTO_CONTA.GE369_NUM_DV_CONTA_CNB);
                _.Move(executed_1.GE369_IND_CONTA_BANCARIA, GE369.DCLGE_MOVTO_CONTA.GE369_IND_CONTA_BANCARIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1640_99_SAIDA*/

        [StopWatch]
        /*" R1640-00-ATUAL-MOVTO-CONTA-DB-SELECT-2 */
        public void R1640_00_ATUAL_MOVTO_CONTA_DB_SELECT_2()
        {
            /*" -2289- EXEC SQL SELECT VALUE(COUNT(*), 0) INTO :HOST-COUNT FROM SEGUROS.SINISTRO_HISTORICO WHERE NUM_APOL_SINISTRO = :SIARDEVC-NUM-APOL-SINISTRO AND OCORR_HISTORICO = :SIARDEVC-OCORR-HISTORICO AND COD_OPERACAO = :SIARDEVC-COD-OPERACAO AND SIT_CONTABIL = '1' END-EXEC */

            var r1640_00_ATUAL_MOVTO_CONTA_DB_SELECT_2_Query1 = new R1640_00_ATUAL_MOVTO_CONTA_DB_SELECT_2_Query1()
            {
                SIARDEVC_NUM_APOL_SINISTRO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO.ToString(),
                SIARDEVC_OCORR_HISTORICO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO.ToString(),
                SIARDEVC_COD_OPERACAO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_OPERACAO.ToString(),
            };

            var executed_1 = R1640_00_ATUAL_MOVTO_CONTA_DB_SELECT_2_Query1.Execute(r1640_00_ATUAL_MOVTO_CONTA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_COUNT, HOST_COUNT);
            }


        }

        [StopWatch]
        /*" R1641-00-DELET-GE-MOVTO-CONT-SECTION */
        private void R1641_00_DELET_GE_MOVTO_CONT_SECTION()
        {
            /*" -2344- MOVE '1641' TO WNR-EXEC-SQL. */
            _.Move("1641", WABEND.WNR_EXEC_SQL);

            /*" -2349- PERFORM R1641_00_DELET_GE_MOVTO_CONT_DB_DELETE_1 */

            R1641_00_DELET_GE_MOVTO_CONT_DB_DELETE_1();

            /*" -2351- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2356- DISPLAY 'PROBLEMAS NO DELETE SEGUROS.GE_MOVTO_CONTA' ' ' MOVDEBCE-NUM-APOLICE ' ' MOVDEBCE-NUM-ENDOSSO ' ' MOVDEBCE-NUM-PARCELA ' ' SIARDEVC-NUM-CHEQUE-INTERNO */

                $"PROBLEMAS NO DELETE SEGUROS.GE_MOVTO_CONTA {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE} {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO} {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CHEQUE_INTERNO}"
                .Display();

                /*" -2357- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2357- ADD 1 TO AC-D-GEMVTOCT. */
            AC_D_GEMVTOCT.Value = AC_D_GEMVTOCT + 1;

        }

        [StopWatch]
        /*" R1641-00-DELET-GE-MOVTO-CONT-DB-DELETE-1 */
        public void R1641_00_DELET_GE_MOVTO_CONT_DB_DELETE_1()
        {
            /*" -2349- EXEC SQL DELETE FROM SEGUROS.GE_MOVTO_CONTA WHERE NUM_APOLICE = :MOVDEBCE-NUM-APOLICE AND NUM_ENDOSSO = :MOVDEBCE-NUM-ENDOSSO AND NUM_PARCELA = :MOVDEBCE-NUM-PARCELA END-EXEC. */

            var r1641_00_DELET_GE_MOVTO_CONT_DB_DELETE_1_Delete1 = new R1641_00_DELET_GE_MOVTO_CONT_DB_DELETE_1_Delete1()
            {
                MOVDEBCE_NUM_APOLICE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.ToString(),
                MOVDEBCE_NUM_ENDOSSO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO.ToString(),
                MOVDEBCE_NUM_PARCELA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA.ToString(),
            };

            R1641_00_DELET_GE_MOVTO_CONT_DB_DELETE_1_Delete1.Execute(r1641_00_DELET_GE_MOVTO_CONT_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1641_99_SAIDA*/

        [StopWatch]
        /*" R1642-00-ATUAL-MOVTO-DEBT-SECTION */
        private void R1642_00_ATUAL_MOVTO_DEBT_SECTION()
        {
            /*" -2365- MOVE '1642' TO WNR-EXEC-SQL. */
            _.Move("1642", WABEND.WNR_EXEC_SQL);

            /*" -2367- MOVE ZEROS TO HOST-COUNT. */
            _.Move(0, HOST_COUNT);

            /*" -2374- PERFORM R1642_00_ATUAL_MOVTO_DEBT_DB_SELECT_1 */

            R1642_00_ATUAL_MOVTO_DEBT_DB_SELECT_1();

            /*" -2377- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2382- DISPLAY 'PROBLEMAS NO SELECT MOVTO_DEBITOCC_CEF' ' ' MOVDEBCE-NUM-APOLICE ' ' MOVDEBCE-NUM-ENDOSSO ' ' MOVDEBCE-NUM-PARCELA ' ' SIARDEVC-NUM-CHEQUE-INTERNO */

                $"PROBLEMAS NO SELECT MOVTO_DEBITOCC_CEF {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE} {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO} {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CHEQUE_INTERNO}"
                .Display();

                /*" -2383- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2385- ADD 1 TO AC-L-MVTODEBT. */
            AC_L_MVTODEBT.Value = AC_L_MVTODEBT + 1;

            /*" -2386- IF HOST-COUNT NOT EQUAL 1 */

            if (HOST_COUNT != 1)
            {

                /*" -2388- DISPLAY 'SINISTRO NAO ENCONTRADO OU DUPLICADO NA TABELA - ' MOVTO_DEBITOCC_CEF' */
                _.Display($"SINISTRO NAO ENCONTRADO OU DUPLICADO NA TABELA - MOVTO_DEBITOCC_CEF");

                /*" -2393- DISPLAY 'CONT ' HOST-COUNT ' ' MOVDEBCE-NUM-APOLICE ' ' MOVDEBCE-NUM-ENDOSSO ' ' MOVDEBCE-NUM-PARCELA ' ' SIARDEVC-NUM-CHEQUE-INTERNO */

                $"CONT {HOST_COUNT} {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE} {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO} {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CHEQUE_INTERNO}"
                .Display();

                /*" -2395- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2396- IF MOVDEBCE-NUM-ENDOSSO EQUAL 1081 */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO == 1081)
            {

                /*" -2397- MOVE 1001 TO AUX-COD-OPERACAO */
                _.Move(1001, AUX_COD_OPERACAO);

                /*" -2398- ELSE IF MOVDEBCE-NUM-ENDOSSO EQUAL 1082 */
            }
            else

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO == 1082)
            {

                /*" -2399- MOVE 1002 TO AUX-COD-OPERACAO */
                _.Move(1002, AUX_COD_OPERACAO);

                /*" -2400- ELSE IF MOVDEBCE-NUM-ENDOSSO EQUAL 1083 */
            }
            else

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO == 1083)
            {

                /*" -2401- MOVE 1003 TO AUX-COD-OPERACAO */
                _.Move(1003, AUX_COD_OPERACAO);

                /*" -2402- ELSE IF MOVDEBCE-NUM-ENDOSSO EQUAL 1084 */
            }
            else

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO == 1084)
            {

                /*" -2404- MOVE 1004 TO AUX-COD-OPERACAO. */
                _.Move(1004, AUX_COD_OPERACAO);
            }


            /*" -2410- PERFORM R1642_00_ATUAL_MOVTO_DEBT_DB_UPDATE_1 */

            R1642_00_ATUAL_MOVTO_DEBT_DB_UPDATE_1();

            /*" -2412- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2418- DISPLAY 'PROBLEMAS NO UPDATE MOVTO_DEBITOCC_CEF' ' ' MOVDEBCE-NUM-APOLICE ' ' MOVDEBCE-NUM-ENDOSSO ' ' MOVDEBCE-NUM-PARCELA ' ' SIARDEVC-NUM-CHEQUE-INTERNO ' ' AUX-COD-OPERACAO */

                $"PROBLEMAS NO UPDATE MOVTO_DEBITOCC_CEF {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE} {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO} {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CHEQUE_INTERNO} {AUX_COD_OPERACAO}"
                .Display();

                /*" -2419- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2419- ADD 1 TO AC-U-MVTODEBT. */
            AC_U_MVTODEBT.Value = AC_U_MVTODEBT + 1;

        }

        [StopWatch]
        /*" R1642-00-ATUAL-MOVTO-DEBT-DB-SELECT-1 */
        public void R1642_00_ATUAL_MOVTO_DEBT_DB_SELECT_1()
        {
            /*" -2374- EXEC SQL SELECT VALUE(COUNT(*), 0) INTO :HOST-COUNT FROM SEGUROS.MOVTO_DEBITOCC_CEF WHERE NUM_APOLICE = :MOVDEBCE-NUM-APOLICE AND NUM_ENDOSSO = :MOVDEBCE-NUM-ENDOSSO AND NUM_PARCELA = :MOVDEBCE-NUM-PARCELA END-EXEC */

            var r1642_00_ATUAL_MOVTO_DEBT_DB_SELECT_1_Query1 = new R1642_00_ATUAL_MOVTO_DEBT_DB_SELECT_1_Query1()
            {
                MOVDEBCE_NUM_APOLICE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.ToString(),
                MOVDEBCE_NUM_ENDOSSO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO.ToString(),
                MOVDEBCE_NUM_PARCELA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA.ToString(),
            };

            var executed_1 = R1642_00_ATUAL_MOVTO_DEBT_DB_SELECT_1_Query1.Execute(r1642_00_ATUAL_MOVTO_DEBT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_COUNT, HOST_COUNT);
            }


        }

        [StopWatch]
        /*" R1642-00-ATUAL-MOVTO-DEBT-DB-UPDATE-1 */
        public void R1642_00_ATUAL_MOVTO_DEBT_DB_UPDATE_1()
        {
            /*" -2410- EXEC SQL UPDATE SEGUROS.MOVTO_DEBITOCC_CEF SET NUM_ENDOSSO = :AUX-COD-OPERACAO WHERE NUM_APOLICE = :MOVDEBCE-NUM-APOLICE AND NUM_ENDOSSO = :MOVDEBCE-NUM-ENDOSSO AND NUM_PARCELA = :MOVDEBCE-NUM-PARCELA END-EXEC. */

            var r1642_00_ATUAL_MOVTO_DEBT_DB_UPDATE_1_Update1 = new R1642_00_ATUAL_MOVTO_DEBT_DB_UPDATE_1_Update1()
            {
                AUX_COD_OPERACAO = AUX_COD_OPERACAO.ToString(),
                MOVDEBCE_NUM_APOLICE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.ToString(),
                MOVDEBCE_NUM_ENDOSSO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO.ToString(),
                MOVDEBCE_NUM_PARCELA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA.ToString(),
            };

            R1642_00_ATUAL_MOVTO_DEBT_DB_UPDATE_1_Update1.Execute(r1642_00_ATUAL_MOVTO_DEBT_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1642_99_SAIDA*/

        [StopWatch]
        /*" R1643-00-INSERT-GE-MOVTO-CONT-SECTION */
        private void R1643_00_INSERT_GE_MOVTO_CONT_SECTION()
        {
            /*" -2430- MOVE '1643' TO WNR-EXEC-SQL. */
            _.Move("1643", WABEND.WNR_EXEC_SQL);

            /*" -2432- MOVE AUX-COD-OPERACAO TO GE369-NUM-ENDOSSO. */
            _.Move(AUX_COD_OPERACAO, GE369.DCLGE_MOVTO_CONTA.GE369_NUM_ENDOSSO);

            /*" -2454- PERFORM R1643_00_INSERT_GE_MOVTO_CONT_DB_INSERT_1 */

            R1643_00_INSERT_GE_MOVTO_CONT_DB_INSERT_1();

            /*" -2457- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2458- DISPLAY 'ERRO INSERT GE_MOVTO_CONTA ..................' */
                _.Display($"ERRO INSERT GE_MOVTO_CONTA ..................");

                /*" -2459- DISPLAY 'NUM-APOLICE....... ' GE369-NUM-APOLICE */
                _.Display($"NUM-APOLICE....... {GE369.DCLGE_MOVTO_CONTA.GE369_NUM_APOLICE}");

                /*" -2460- DISPLAY 'NUM-ENDOSSO....... ' GE369-NUM-ENDOSSO */
                _.Display($"NUM-ENDOSSO....... {GE369.DCLGE_MOVTO_CONTA.GE369_NUM_ENDOSSO}");

                /*" -2461- DISPLAY 'NUM-PARCELA....... ' GE369-NUM-PARCELA */
                _.Display($"NUM-PARCELA....... {GE369.DCLGE_MOVTO_CONTA.GE369_NUM_PARCELA}");

                /*" -2462- DISPLAY 'COD-CONVENIO...... ' GE369-COD-CONVENIO */
                _.Display($"COD-CONVENIO...... {GE369.DCLGE_MOVTO_CONTA.GE369_COD_CONVENIO}");

                /*" -2463- DISPLAY 'NSAS.............. ' GE369-NSAS */
                _.Display($"NSAS.............. {GE369.DCLGE_MOVTO_CONTA.GE369_NSAS}");

                /*" -2464- DISPLAY 'COD-AGENCIA....... ' GE369-COD-AGENCIA */
                _.Display($"COD-AGENCIA....... {GE369.DCLGE_MOVTO_CONTA.GE369_COD_AGENCIA}");

                /*" -2465- DISPLAY 'COD-BANCO......... ' GE369-COD-BANCO */
                _.Display($"COD-BANCO......... {GE369.DCLGE_MOVTO_CONTA.GE369_COD_BANCO}");

                /*" -2466- DISPLAY 'NUM-CONTA-CNB..... ' GE369-NUM-CONTA-CNB */
                _.Display($"NUM-CONTA-CNB..... {GE369.DCLGE_MOVTO_CONTA.GE369_NUM_CONTA_CNB}");

                /*" -2467- DISPLAY 'NUM-DV-CONT-CNB... ' GE369-NUM-DV-CONTA-CNB */
                _.Display($"NUM-DV-CONT-CNB... {GE369.DCLGE_MOVTO_CONTA.GE369_NUM_DV_CONTA_CNB}");

                /*" -2468- DISPLAY 'IND-CONT-BANC..... ' GE369-IND-CONTA-BANCARIA */
                _.Display($"IND-CONT-BANC..... {GE369.DCLGE_MOVTO_CONTA.GE369_IND_CONTA_BANCARIA}");

                /*" -2469- DISPLAY 'AUX-COD-OPERACAO.. ' AUX-COD-OPERACAO */
                _.Display($"AUX-COD-OPERACAO.. {AUX_COD_OPERACAO}");

                /*" -2470- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2470- ADD 1 TO AC-I-GEMVTOCT. */
            AC_I_GEMVTOCT.Value = AC_I_GEMVTOCT + 1;

        }

        [StopWatch]
        /*" R1643-00-INSERT-GE-MOVTO-CONT-DB-INSERT-1 */
        public void R1643_00_INSERT_GE_MOVTO_CONT_DB_INSERT_1()
        {
            /*" -2454- EXEC SQL INSERT INTO SEGUROS.GE_MOVTO_CONTA ( NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , COD_CONVENIO , NSAS , COD_AGENCIA , COD_BANCO , NUM_CONTA_CNB , NUM_DV_CONTA_CNB , IND_CONTA_BANCARIA ) VALUES (:GE369-NUM-APOLICE , :GE369-NUM-ENDOSSO , :GE369-NUM-PARCELA , :GE369-COD-CONVENIO , :GE369-NSAS , :GE369-COD-AGENCIA , :GE369-COD-BANCO , :GE369-NUM-CONTA-CNB , :GE369-NUM-DV-CONTA-CNB , :GE369-IND-CONTA-BANCARIA) END-EXEC. */

            var r1643_00_INSERT_GE_MOVTO_CONT_DB_INSERT_1_Insert1 = new R1643_00_INSERT_GE_MOVTO_CONT_DB_INSERT_1_Insert1()
            {
                GE369_NUM_APOLICE = GE369.DCLGE_MOVTO_CONTA.GE369_NUM_APOLICE.ToString(),
                GE369_NUM_ENDOSSO = GE369.DCLGE_MOVTO_CONTA.GE369_NUM_ENDOSSO.ToString(),
                GE369_NUM_PARCELA = GE369.DCLGE_MOVTO_CONTA.GE369_NUM_PARCELA.ToString(),
                GE369_COD_CONVENIO = GE369.DCLGE_MOVTO_CONTA.GE369_COD_CONVENIO.ToString(),
                GE369_NSAS = GE369.DCLGE_MOVTO_CONTA.GE369_NSAS.ToString(),
                GE369_COD_AGENCIA = GE369.DCLGE_MOVTO_CONTA.GE369_COD_AGENCIA.ToString(),
                GE369_COD_BANCO = GE369.DCLGE_MOVTO_CONTA.GE369_COD_BANCO.ToString(),
                GE369_NUM_CONTA_CNB = GE369.DCLGE_MOVTO_CONTA.GE369_NUM_CONTA_CNB.ToString(),
                GE369_NUM_DV_CONTA_CNB = GE369.DCLGE_MOVTO_CONTA.GE369_NUM_DV_CONTA_CNB.ToString(),
                GE369_IND_CONTA_BANCARIA = GE369.DCLGE_MOVTO_CONTA.GE369_IND_CONTA_BANCARIA.ToString(),
            };

            R1643_00_INSERT_GE_MOVTO_CONT_DB_INSERT_1_Insert1.Execute(r1643_00_INSERT_GE_MOVTO_CONT_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1643_99_SAIDA*/

        [StopWatch]
        /*" R1660-00-ATUAL-MOVDEB-SAP-SECTION */
        private void R1660_00_ATUAL_MOVDEB_SAP_SECTION()
        {
            /*" -2479- MOVE '1660' TO WNR-EXEC-SQL. */
            _.Move("1660", WABEND.WNR_EXEC_SQL);

            /*" -2481- MOVE ZEROS TO HOST-COUNT. */
            _.Move(0, HOST_COUNT);

            /*" -2488- PERFORM R1660_00_ATUAL_MOVDEB_SAP_DB_SELECT_1 */

            R1660_00_ATUAL_MOVDEB_SAP_DB_SELECT_1();

            /*" -2491- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2496- DISPLAY 'PROBLEMAS NO SELECT GE_MOVDEBCE_SAP' ' ' MOVDEBCE-NUM-APOLICE ' ' MOVDEBCE-NUM-ENDOSSO ' ' MOVDEBCE-NUM-PARCELA ' ' SIARDEVC-NUM-CHEQUE-INTERNO */

                $"PROBLEMAS NO SELECT GE_MOVDEBCE_SAP {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE} {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO} {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CHEQUE_INTERNO}"
                .Display();

                /*" -2497- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2499- ADD 1 TO AC-L-MVTODEBSAP. */
            AC_L_MVTODEBSAP.Value = AC_L_MVTODEBSAP + 1;

            /*" -2500- IF HOST-COUNT EQUAL ZEROS */

            if (HOST_COUNT == 00)
            {

                /*" -2505- DISPLAY 'SINISTRO NAO ENCONTRADO - GE_MOVDEBCE_SAP' ' ' MOVDEBCE-NUM-APOLICE ' ' MOVDEBCE-NUM-ENDOSSO ' ' MOVDEBCE-NUM-PARCELA ' ' SIARDEVC-NUM-CHEQUE-INTERNO */

                $"SINISTRO NAO ENCONTRADO - GE_MOVDEBCE_SAP {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE} {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO} {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CHEQUE_INTERNO}"
                .Display();

                /*" -2507- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2513- PERFORM R1660_00_ATUAL_MOVDEB_SAP_DB_UPDATE_1 */

            R1660_00_ATUAL_MOVDEB_SAP_DB_UPDATE_1();

            /*" -2515- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2520- DISPLAY 'PROBLEMAS NO UPDATE GE_MOVDEBCE_SAP' ' ' MOVDEBCE-NUM-APOLICE ' ' MOVDEBCE-NUM-ENDOSSO ' ' MOVDEBCE-NUM-PARCELA ' ' SIARDEVC-NUM-CHEQUE-INTERNO */

                $"PROBLEMAS NO UPDATE GE_MOVDEBCE_SAP {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE} {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO} {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CHEQUE_INTERNO}"
                .Display();

                /*" -2521- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2521- ADD 1 TO AC-U-MVTODEBSAP. */
            AC_U_MVTODEBSAP.Value = AC_U_MVTODEBSAP + 1;

        }

        [StopWatch]
        /*" R1660-00-ATUAL-MOVDEB-SAP-DB-SELECT-1 */
        public void R1660_00_ATUAL_MOVDEB_SAP_DB_SELECT_1()
        {
            /*" -2488- EXEC SQL SELECT VALUE(COUNT(*), 0) INTO :HOST-COUNT FROM SEGUROS.GE_MOVDEBCE_SAP WHERE NUM_APOLICE = :MOVDEBCE-NUM-APOLICE AND NUM_ENDOSSO = :MOVDEBCE-NUM-ENDOSSO AND NUM_PARCELA = :MOVDEBCE-NUM-PARCELA END-EXEC. */

            var r1660_00_ATUAL_MOVDEB_SAP_DB_SELECT_1_Query1 = new R1660_00_ATUAL_MOVDEB_SAP_DB_SELECT_1_Query1()
            {
                MOVDEBCE_NUM_APOLICE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.ToString(),
                MOVDEBCE_NUM_ENDOSSO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO.ToString(),
                MOVDEBCE_NUM_PARCELA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA.ToString(),
            };

            var executed_1 = R1660_00_ATUAL_MOVDEB_SAP_DB_SELECT_1_Query1.Execute(r1660_00_ATUAL_MOVDEB_SAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_COUNT, HOST_COUNT);
            }


        }

        [StopWatch]
        /*" R1660-00-ATUAL-MOVDEB-SAP-DB-UPDATE-1 */
        public void R1660_00_ATUAL_MOVDEB_SAP_DB_UPDATE_1()
        {
            /*" -2513- EXEC SQL UPDATE SEGUROS.GE_MOVDEBCE_SAP SET NUM_ENDOSSO = :SINISHIS-COD-OPERACAO WHERE NUM_APOLICE = :MOVDEBCE-NUM-APOLICE AND NUM_ENDOSSO = :MOVDEBCE-NUM-ENDOSSO AND NUM_PARCELA = :MOVDEBCE-NUM-PARCELA END-EXEC. */

            var r1660_00_ATUAL_MOVDEB_SAP_DB_UPDATE_1_Update1 = new R1660_00_ATUAL_MOVDEB_SAP_DB_UPDATE_1_Update1()
            {
                SINISHIS_COD_OPERACAO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.ToString(),
                MOVDEBCE_NUM_APOLICE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.ToString(),
                MOVDEBCE_NUM_ENDOSSO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO.ToString(),
                MOVDEBCE_NUM_PARCELA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA.ToString(),
            };

            R1660_00_ATUAL_MOVDEB_SAP_DB_UPDATE_1_Update1.Execute(r1660_00_ATUAL_MOVDEB_SAP_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1660_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-SUM-RESERVA-SECTION */
        private void R2200_00_SUM_RESERVA_SECTION()
        {
            /*" -2533- MOVE '2200' TO WNR-EXEC-SQL */
            _.Move("2200", WABEND.WNR_EXEC_SQL);

            /*" -2535- INITIALIZE SI1001S-PARAMETROS */
            _.Initialize(
                LBSI1001.SI1001S_PARAMETROS
            );

            /*" -2538- MOVE SIARDEVC-NUM-APOL-SINISTRO TO SI1001S-NUM-APOL-SINISTRO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO);

            /*" -2540- CALL 'SI1001S' USING SI1001S-PARAMETROS */
            _.Call("SI1001S", LBSI1001.SI1001S_PARAMETROS);

            /*" -2542- IF SI1001S-ERRO-MENSAGEM NOT EQUAL SPACES */

            if (!LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM.IsEmpty())
            {

                /*" -2548- DISPLAY 'PROBLEMAS NO CALL DA SI1001S ' ' ' SIARDEVC-NUM-APOL-SINISTRO ' ' SIARDEVC-NOM-ARQUIVO ' ' SIARDEVC-SEQ-GERACAO ' ' SIARDEVC-TIPO-REGISTRO ' ' SIARDEVC-SEQ-REGISTRO */

                $"PROBLEMAS NO CALL DA SI1001S  {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_ARQUIVO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_GERACAO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_REGISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_REGISTRO}"
                .Display();

                /*" -2549- DISPLAY 'SQLCODE.... ' SI1001S-ERRO-SQLCODE */
                _.Display($"SQLCODE.... {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_SQLCODE}");

                /*" -2550- DISPLAY 'MENSAGEM... ' SI1001S-ERRO-MENSAGEM */
                _.Display($"MENSAGEM... {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM}");

                /*" -2552- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2553- MOVE SI1001S-VALOR-CALCULADO TO HOST-VAL-RESERVA. */
            _.Move(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_VALOR_CALCULADO, HOST_VAL_RESERVA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_EXIT*/

        [StopWatch]
        /*" R10000-LE-CHEQUES-EMITIDOS-SECTION */
        private void R10000_LE_CHEQUES_EMITIDOS_SECTION()
        {
            /*" -2587- MOVE '1500' TO WNR-EXEC-SQL */
            _.Move("1500", WABEND.WNR_EXEC_SQL);

            /*" -2589- INITIALIZE DCLCHEQUES-EMITIDOS DCLSI-SINI-CHEQUE. */
            _.Initialize(
                CHEQUEMI.DCLCHEQUES_EMITIDOS
                , SISINCHE.DCLSI_SINI_CHEQUE
            );

            /*" -2605- PERFORM R10000_LE_CHEQUES_EMITIDOS_DB_SELECT_1 */

            R10000_LE_CHEQUES_EMITIDOS_DB_SELECT_1();

            /*" -2608- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -2612- DISPLAY 'ERRO JOIN SI_SINI_CHEQUE E CHEQUES_EMITIDOS ' ' SIN ' SIARDEVC-NUM-APOL-SINISTRO ' OCO ' SIARDEVC-OCORR-HISTORICO ' NOM ' SIARDEVC-NOM-FAVORECIDO */

                $"ERRO JOIN SI_SINI_CHEQUE E CHEQUES_EMITIDOS  SIN {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO} OCO {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO} NOM {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_FAVORECIDO}"
                .Display();

                /*" -2614- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2615- IF IND-DATA-EMISSAO LESS 0 */

            if (IND_DATA_EMISSAO < 0)
            {

                /*" -2616- MOVE '0001-01-01' TO CHEQUEMI-DATA-EMISSAO */
                _.Move("0001-01-01", CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_DATA_EMISSAO);

                /*" -2624- MOVE +0 TO IND-DATA-EMISSAO. */
                _.Move(+0, IND_DATA_EMISSAO);
            }


            /*" -2625- IF IND-DATA-MOV LESS ZEROS */

            if (IND_DATA_MOV < 00)
            {

                /*" -2627- MOVE SISTEMAS-DATA-MOV-ABERTO TO CHEQUEMI-DATA-MOVIMENTO */
                _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_DATA_MOVIMENTO);

                /*" -2627- END-IF. */
            }


        }

        [StopWatch]
        /*" R10000-LE-CHEQUES-EMITIDOS-DB-SELECT-1 */
        public void R10000_LE_CHEQUES_EMITIDOS_DB_SELECT_1()
        {
            /*" -2605- EXEC SQL SELECT A.NUM_CHEQUE_INTERNO, B.TIPO_PAGAMENTO, B.DATA_EMISSAO, B.DATA_MOVIMENTO, B.SIT_REGISTRO INTO :SISINCHE-NUM-CHEQUE-INTERNO, :CHEQUEMI-TIPO-PAGAMENTO, :CHEQUEMI-DATA-EMISSAO:IND-DATA-EMISSAO, :CHEQUEMI-DATA-MOVIMENTO:IND-DATA-MOV, :CHEQUEMI-SIT-REGISTRO FROM SEGUROS.SI_SINI_CHEQUE A, SEGUROS.CHEQUES_EMITIDOS B WHERE A.NUM_APOL_SINISTRO = :SIARDEVC-NUM-APOL-SINISTRO AND A.OCORR_HISTORICO = :SIARDEVC-OCORR-HISTORICO AND B.NUM_CHEQUE_INTERNO = A.NUM_CHEQUE_INTERNO END-EXEC. */

            var r10000_LE_CHEQUES_EMITIDOS_DB_SELECT_1_Query1 = new R10000_LE_CHEQUES_EMITIDOS_DB_SELECT_1_Query1()
            {
                SIARDEVC_NUM_APOL_SINISTRO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO.ToString(),
                SIARDEVC_OCORR_HISTORICO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO.ToString(),
            };

            var executed_1 = R10000_LE_CHEQUES_EMITIDOS_DB_SELECT_1_Query1.Execute(r10000_LE_CHEQUES_EMITIDOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISINCHE_NUM_CHEQUE_INTERNO, SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_NUM_CHEQUE_INTERNO);
                _.Move(executed_1.CHEQUEMI_TIPO_PAGAMENTO, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_TIPO_PAGAMENTO);
                _.Move(executed_1.CHEQUEMI_DATA_EMISSAO, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_DATA_EMISSAO);
                _.Move(executed_1.IND_DATA_EMISSAO, IND_DATA_EMISSAO);
                _.Move(executed_1.CHEQUEMI_DATA_MOVIMENTO, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_DATA_MOVIMENTO);
                _.Move(executed_1.IND_DATA_MOV, IND_DATA_MOV);
                _.Move(executed_1.CHEQUEMI_SIT_REGISTRO, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_SIT_REGISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R10000_EXIT*/

        [StopWatch]
        /*" R11000-ACESSA-CHEQUE-EXTERNO-SECTION */
        private void R11000_ACESSA_CHEQUE_EXTERNO_SECTION()
        {
            /*" -2636- MOVE '1500' TO WNR-EXEC-SQL */
            _.Move("1500", WABEND.WNR_EXEC_SQL);

            /*" -2638- INITIALIZE DCLLOTE-CHEQUES. */
            _.Initialize(
                LOTECHEQ.DCLLOTE_CHEQUES
            );

            /*" -2645- PERFORM R11000_ACESSA_CHEQUE_EXTERNO_DB_SELECT_1 */

            R11000_ACESSA_CHEQUE_EXTERNO_DB_SELECT_1();

            /*" -2648- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -2649- IF (SQLCODE EQUAL 100) */

                if ((DB.SQLCODE == 100))
                {

                    /*" -2650- MOVE ZEROS TO LOTECHEQ-NUM-CHEQUE */
                    _.Move(0, LOTECHEQ.DCLLOTE_CHEQUES.LOTECHEQ_NUM_CHEQUE);

                    /*" -2656- MOVE SPACES TO LOTECHEQ-SERIE-CHEQUE */
                    _.Move("", LOTECHEQ.DCLLOTE_CHEQUES.LOTECHEQ_SERIE_CHEQUE);

                    /*" -2657- ELSE */
                }
                else
                {


                    /*" -2662- DISPLAY 'R11000-ERRO ACESSO LOTE_CHEQUE' ' SIN ' SIARDEVC-NUM-APOL-SINISTRO ' OCO ' SIARDEVC-OCORR-HISTORICO ' NOM ' SIARDEVC-NOM-FAVORECIDO ' CHQINT ' SISINCHE-NUM-CHEQUE-INTERNO */

                    $"R11000-ERRO ACESSO LOTE_CHEQUE SIN {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO} OCO {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO} NOM {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_FAVORECIDO} CHQINT {SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_NUM_CHEQUE_INTERNO}"
                    .Display();

                    /*" -2663- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2664- END-IF */
                }


                /*" -2664- END-IF. */
            }


        }

        [StopWatch]
        /*" R11000-ACESSA-CHEQUE-EXTERNO-DB-SELECT-1 */
        public void R11000_ACESSA_CHEQUE_EXTERNO_DB_SELECT_1()
        {
            /*" -2645- EXEC SQL SELECT NUM_CHEQUE , SERIE_CHEQUE INTO :LOTECHEQ-NUM-CHEQUE, :LOTECHEQ-SERIE-CHEQUE FROM SEGUROS.LOTE_CHEQUES WHERE NUM_CHEQUE_INTERNO = :SISINCHE-NUM-CHEQUE-INTERNO END-EXEC. */

            var r11000_ACESSA_CHEQUE_EXTERNO_DB_SELECT_1_Query1 = new R11000_ACESSA_CHEQUE_EXTERNO_DB_SELECT_1_Query1()
            {
                SISINCHE_NUM_CHEQUE_INTERNO = SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_NUM_CHEQUE_INTERNO.ToString(),
            };

            var executed_1 = R11000_ACESSA_CHEQUE_EXTERNO_DB_SELECT_1_Query1.Execute(r11000_ACESSA_CHEQUE_EXTERNO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LOTECHEQ_NUM_CHEQUE, LOTECHEQ.DCLLOTE_CHEQUES.LOTECHEQ_NUM_CHEQUE);
                _.Move(executed_1.LOTECHEQ_SERIE_CHEQUE, LOTECHEQ.DCLLOTE_CHEQUES.LOTECHEQ_SERIE_CHEQUE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R11000_EXIT*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -2673- CLOSE CSPAGSIN */
            CSPAGSIN.Close();

            /*" -2674- DISPLAY '********************************' */
            _.Display($"********************************");

            /*" -2675- DISPLAY '*     SI9211B - CANCELADO      *' */
            _.Display($"*     SI9211B - CANCELADO      *");

            /*" -2677- DISPLAY '********************************' */
            _.Display($"********************************");

            /*" -2678- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -2680- DISPLAY WABEND */
            _.Display(WABEND);

            /*" -2680- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -2684- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -2684- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}