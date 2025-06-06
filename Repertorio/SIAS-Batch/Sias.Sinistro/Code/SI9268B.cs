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
using Sias.Sinistro.DB2.SI9268B;

namespace Code
{
    public class SI9268B
    {
        public bool IsCall { get; set; }

        public SI9268B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SINISTROS                          *      */
        /*"      *   PROGRAMA ...............  SI9268B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  BRSEG                              *      */
        /*"      *   PROGRAMADOR ............  BRSEG                              *      */
        /*"      *   DATA CODIFICACAO .......  ABRIL/2011                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  GERA ARQUIVO DE RETORNO DE         *      */
        /*"      *                             RECEBIMENTOS DE RESSARCIMENTOS     *      */
        /*"      *                             SINISTRO AUTO SULAMERICA           *      */
        /*"      *                            (COPIA DO PROGRAMA SI9168B)         *      */
        /*"      *                                                                *      */
        /*"      *                             SELECIONA SI_AR_DETALHE_VC:        *      */
        /*"      *                             4000-RESSARC. PROVISAO DO PRINCIPAL*      */
        /*"      *                             4001-RESSARC. PROVISAO DOS JUROS   *      */
        /*"      *                             4002-RESSARC. PROVISAO DE CORRECAO *      */
        /*"      *                                                                *      */
        /*"      *                             SELECIONA SINISTRO_HISTORICO:      *      */
        /*"      *                             4100-RESSARC. RECEBIMENTO TOTAL    *      */
        /*"      *                                                                *      */
        /*"      *                             SELECIONA SI_RESSARC_PARCELA:      *      */
        /*"      *                             4100-RESSARC. RECEBIMENTO TOTAL    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   PROJAUTO - 10/04/2011 - VANDO - VER: PRJ.01                  *      */
        /*"      *                           ATENDIMENTO AO NOVO CONVENIO         *      */
        /*"      *                           AUTO SULAMERICA.                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   CAD77048 - 05/12/2012 - VIVIANE VERSAO: V.01                 *      */
        /*"      *                           GERACAO DO HEADER/ TRAILLER MESMO    *      */
        /*"      *   QUANDO O ARQUIVO E GERADO VAZIO.                             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *              02/04/2013 - GUILHERME CORREIA                    *      */
        /*"      *                                                                *      */
        /*"      *          PROGRAMA RECUPERA SINISTROS RETORNADOS PARA A SAS     *      */
        /*"      *          STA_RETORNO = 2                                       *      */
        /*"      *                                                                *      */
        /*"      *                                  PROCURAR   V.02               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 03 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 21/10/2014 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.03         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"V.04  *   VERSAO 04 -   PROJETO SIGCB - CADMUS 140525                  *      */
        /*"      *               - NOVA SOLUCAO PARA REGISTRO DE BOLETO           *      */
        /*"      *   EM 15/12/2016 - DIEGO DIAS                                   *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.04         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 05 -   PROJETO REINF                                  *      */
        /*"      *               - ADEQUAR CAMPOS DA REINF                        *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/02/2018 - DOUGLAS ARAUJO - ATOS                        *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.05         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        /*"      *--------------------------------------                                 */
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
        public SI9268B_REG_SCMOVSIN REG_SCMOVSIN { get; set; } = new SI9268B_REG_SCMOVSIN();
        public class SI9268B_REG_SCMOVSIN : VarBasis
        {
            /*"  05     SCMOVSIN-HEADER.*/
            public SI9268B_SCMOVSIN_HEADER SCMOVSIN_HEADER { get; set; } = new SI9268B_SCMOVSIN_HEADER();
            public class SI9268B_SCMOVSIN_HEADER : VarBasis
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
            private _REDEF_SI9268B_SCMOVSIN_DADOS _scmovsin_dados { get; set; }
            public _REDEF_SI9268B_SCMOVSIN_DADOS SCMOVSIN_DADOS
            {
                get { _scmovsin_dados = new _REDEF_SI9268B_SCMOVSIN_DADOS(); _.Move(SCMOVSIN_HEADER, _scmovsin_dados); VarBasis.RedefinePassValue(SCMOVSIN_HEADER, _scmovsin_dados, SCMOVSIN_HEADER); _scmovsin_dados.ValueChanged += () => { _.Move(_scmovsin_dados, SCMOVSIN_HEADER); }; return _scmovsin_dados; }
                set { VarBasis.RedefinePassValue(value, _scmovsin_dados, SCMOVSIN_HEADER); }
            }  //Redefines
            public class _REDEF_SI9268B_SCMOVSIN_DADOS : VarBasis
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
                public SI9268B_DET_CEP DET_CEP { get; set; } = new SI9268B_DET_CEP();
                public class SI9268B_DET_CEP : VarBasis
                {
                    /*"         15  DET-NUM-CEP             PIC  9(008).*/
                    public IntBasis DET_NUM_CEP { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"    10   DET-NUM-DDD                 PIC  9(002).*/

                    public SI9268B_DET_CEP()
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
                public SI9268B_DET_CIRCULAR_200 DET_CIRCULAR_200 { get; set; } = new SI9268B_DET_CIRCULAR_200();
                public class SI9268B_DET_CIRCULAR_200 : VarBasis
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

                    public SI9268B_DET_CIRCULAR_200()
                    {
                        DET_NATUREZA_DOCTO.ValueChanged += OnValueChanged;
                        DET_NUM_IDENTIDADE.ValueChanged += OnValueChanged;
                        DET_ORGAO_EXPEDIDOR.ValueChanged += OnValueChanged;
                        DET_DATA_EXPEDICAO.ValueChanged += OnValueChanged;
                        DET_UF_EXPEDIDORA.ValueChanged += OnValueChanged;
                        DET_ATIVIDADE_PRINCIPAL.ValueChanged += OnValueChanged;
                    }

                }
                public SI9268B_DET_CIRCULAR_255 DET_CIRCULAR_255 { get; set; } = new SI9268B_DET_CIRCULAR_255();
                public class SI9268B_DET_CIRCULAR_255 : VarBasis
                {
                    /*"      15 DET-DATA-ULT-DOCTO          PIC  X(010).*/
                    public StringBasis DET_DATA_ULT_DOCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                    /*"    10   DET-NUM-RESSARC             PIC  9(009).*/

                    public SI9268B_DET_CIRCULAR_255()
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

                public _REDEF_SI9268B_SCMOVSIN_DADOS()
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
            private _REDEF_SI9268B_SCMOVSIN_TRAILLER _scmovsin_trailler { get; set; }
            public _REDEF_SI9268B_SCMOVSIN_TRAILLER SCMOVSIN_TRAILLER
            {
                get { _scmovsin_trailler = new _REDEF_SI9268B_SCMOVSIN_TRAILLER(); _.Move(SCMOVSIN_HEADER, _scmovsin_trailler); VarBasis.RedefinePassValue(SCMOVSIN_HEADER, _scmovsin_trailler, SCMOVSIN_HEADER); _scmovsin_trailler.ValueChanged += () => { _.Move(_scmovsin_trailler, SCMOVSIN_HEADER); }; return _scmovsin_trailler; }
                set { VarBasis.RedefinePassValue(value, _scmovsin_trailler, SCMOVSIN_HEADER); }
            }  //Redefines
            public class _REDEF_SI9268B_SCMOVSIN_TRAILLER : VarBasis
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

                public _REDEF_SI9268B_SCMOVSIN_TRAILLER()
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
        /*"01       HOST-ANO-MOV-ABERTO         PIC S9(004) VALUE +0 COMP.*/
        public IntBasis HOST_ANO_MOV_ABERTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01       HOST-MES-MOV-ABERTO         PIC S9(004) VALUE +0 COMP.*/
        public IntBasis HOST_MES_MOV_ABERTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01       IND-DATA-EMISSAO       PIC S9(004) VALUE +0 COMP.*/
        public IntBasis IND_DATA_EMISSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01       WFIM-SIARDEVC               PIC  X(001) VALUE SPACES.*/
        public StringBasis WFIM_SIARDEVC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01       AC-L-SIARDEVC               PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_L_SIARDEVC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-G-CSPAGSIN               PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_G_CSPAGSIN { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-C-NOSSO-NUMERO           PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_C_NOSSO_NUMERO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-R-NOSSO-NUMERO           PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_R_NOSSO_NUMERO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-I-GEARDETA               PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_I_GEARDETA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-U-GEARDETA               PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_U_GEARDETA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-I-SIARVRCZ               PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_I_SIARVRCZ { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-I-SIARREVC               PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_I_SIARREVC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-U-SIARDEVC               PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_U_SIARDEVC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       WS-IDENT-PAGTO-EDITADO.*/
        public SI9268B_WS_IDENT_PAGTO_EDITADO WS_IDENT_PAGTO_EDITADO { get; set; } = new SI9268B_WS_IDENT_PAGTO_EDITADO();
        public class SI9268B_WS_IDENT_PAGTO_EDITADO : VarBasis
        {
            /*"  05     WS-CHEQUE-EXTERNO           PIC  ZZZ999999.*/
            public IntBasis WS_CHEQUE_EXTERNO { get; set; } = new IntBasis(new PIC("9", "9", "ZZZ999999."));
            /*"  05     WS-SEPARADOR                PIC  X(001) VALUE SPACE.*/
            public StringBasis WS_SEPARADOR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05     WS-CHEQUE-INTERNO           PIC  9(009) VALUE ZEROS.*/
            public IntBasis WS_CHEQUE_INTERNO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"01          WABEND.*/
        }
        public SI9268B_WABEND WABEND { get; set; } = new SI9268B_WABEND();
        public class SI9268B_WABEND : VarBasis
        {
            /*"  05     FILLER                      PIC  X(010) VALUE           ' SI9268B'.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SI9268B");
            /*"  05     FILLER                      PIC  X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"  05     WNR-EXEC-SQL                PIC  X(004) VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"  05     FILLER                      PIC  X(013) VALUE           ' *** SQLCODE '.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"  05     WSQLCODE                    PIC  ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
        }


        public Copies.LBGE0350 LBGE0350 { get; set; } = new Copies.LBGE0350();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.GEARDETA GEARDETA { get; set; } = new Dclgens.GEARDETA();
        public Dclgens.SIARVRCZ SIARVRCZ { get; set; } = new Dclgens.SIARVRCZ();
        public Dclgens.SIARDEVC SIARDEVC { get; set; } = new Dclgens.SIARDEVC();
        public Dclgens.SIARREVC SIARREVC { get; set; } = new Dclgens.SIARREVC();
        public Dclgens.SI111 SI111 { get; set; } = new Dclgens.SI111();
        public Dclgens.SIERRO SIERRO { get; set; } = new Dclgens.SIERRO();
        public SI9268B_C01_SIARDEVC C01_SIARDEVC { get; set; } = new SI9268B_C01_SIARDEVC();
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

                /*" -157- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -158- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -159- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -159- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -167- MOVE '0000' TO WNR-EXEC-SQL */
            _.Move("0000", WABEND.WNR_EXEC_SQL);

            /*" -168- DISPLAY '-------------------------------' . */
            _.Display($"-------------------------------");

            /*" -169- DISPLAY 'PROGRAMA EM EXECUCAO SI9268B   ' . */
            _.Display($"PROGRAMA EM EXECUCAO SI9268B   ");

            /*" -170- DISPLAY '                               ' . */
            _.Display($"                               ");

            /*" -171- DISPLAY 'VERSAO V.03 NSGD    21/10/2014 ' . */
            _.Display($"VERSAO V.03 NSGD    21/10/2014 ");

            /*" -173- DISPLAY '-------------------------------' . */
            _.Display($"-------------------------------");

            /*" -175- PERFORM R0100-00-LE-SISTEMAS */

            R0100_00_LE_SISTEMAS_SECTION();

            /*" -177- OPEN OUTPUT CSPAGSIN */
            CSPAGSIN.Open(REG_SCMOVSIN);

            /*" -178- MOVE SPACES TO WFIM-SIARDEVC */
            _.Move("", WFIM_SIARDEVC);

            /*" -179- PERFORM R0900-00-DECLARA-SIARDEVC */

            R0900_00_DECLARA_SIARDEVC_SECTION();

            /*" -180- PERFORM R0910-00-LE-SIARDEVC */

            R0910_00_LE_SIARDEVC_SECTION();

            /*" -182- PERFORM R0500-00-GERA-HEADER */

            R0500_00_GERA_HEADER_SECTION();

            /*" -183- IF WFIM-SIARDEVC EQUAL 'S' */

            if (WFIM_SIARDEVC == "S")
            {

                /*" -184- PERFORM R0600-00-GERA-TRAILLER */

                R0600_00_GERA_TRAILLER_SECTION();

                /*" -188- GO TO R0000-10-FINALIZA. */

                R0000_10_FINALIZA(); //GOTO
                return;
            }


            /*" -191- PERFORM R1000-00-PROCESSA-SIARDEVC UNTIL WFIM-SIARDEVC EQUAL 'S' */

            while (!(WFIM_SIARDEVC == "S"))
            {

                R1000_00_PROCESSA_SIARDEVC_SECTION();
            }

            /*" -193- PERFORM R0600-00-GERA-TRAILLER */

            R0600_00_GERA_TRAILLER_SECTION();

            /*" -194- ADD AC-G-CSPAGSIN TO GEARDETA-QTD-REG-PROCESSADO */
            GEARDETA.DCLGE_AR_DETALHE.GEARDETA_QTD_REG_PROCESSADO.Value = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_QTD_REG_PROCESSADO + AC_G_CSPAGSIN;

            /*" -194- PERFORM R0700-00-ALTERA-GEARDETA. */

            R0700_00_ALTERA_GEARDETA_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0000_10_FINALIZA */

            R0000_10_FINALIZA();

        }

        [StopWatch]
        /*" R0000-10-FINALIZA */
        private void R0000_10_FINALIZA(bool isPerform = false)
        {
            /*" -199- DISPLAY '********************************' */
            _.Display($"********************************");

            /*" -200- DISPLAY '*     SI9268B - FIM NORMAL     *' */
            _.Display($"*     SI9268B - FIM NORMAL     *");

            /*" -201- DISPLAY '********************************' */
            _.Display($"********************************");

            /*" -202- DISPLAY 'LIDOS       - SIARDEVC ' AC-L-SIARDEVC */
            _.Display($"LIDOS       - SIARDEVC {AC_L_SIARDEVC}");

            /*" -203- DISPLAY 'ALTERADOS   - SIARDEVC ' AC-U-SIARDEVC */
            _.Display($"ALTERADOS   - SIARDEVC {AC_U_SIARDEVC}");

            /*" -204- DISPLAY '            - GEARDETA ' AC-U-GEARDETA */
            _.Display($"            - GEARDETA {AC_U_GEARDETA}");

            /*" -205- DISPLAY 'INSERIDOS   - GEARDETA ' AC-I-GEARDETA */
            _.Display($"INSERIDOS   - GEARDETA {AC_I_GEARDETA}");

            /*" -206- DISPLAY '            - SIARVRCZ ' AC-I-SIARVRCZ */
            _.Display($"            - SIARVRCZ {AC_I_SIARVRCZ}");

            /*" -207- DISPLAY '            - SIARREVC ' AC-I-SIARREVC */
            _.Display($"            - SIARREVC {AC_I_SIARREVC}");

            /*" -208- DISPLAY 'GRAVADOS    - CSPAGSIN ' AC-G-CSPAGSIN */
            _.Display($"GRAVADOS    - CSPAGSIN {AC_G_CSPAGSIN}");

            /*" -209- DISPLAY '+-----------------------------------------+' */
            _.Display($"+-----------------------------------------+");

            /*" -210- DISPLAY '|            ESTRUTURA   SIGCB            |' */
            _.Display($"|            ESTRUTURA   SIGCB            |");

            /*" -211- DISPLAY '+-----------------------------------------+' */
            _.Display($"+-----------------------------------------+");

            /*" -213- DISPLAY '| CONSULTA GE0350S . ' AC-C-NOSSO-NUMERO '               |' . */

            $"| CONSULTA GE0350S . {AC_C_NOSSO_NUMERO}               |"
            .Display();

            /*" -215- DISPLAY '| RETORNO COM VALOR. ' AC-R-NOSSO-NUMERO */
            _.Display($"| RETORNO COM VALOR. {AC_R_NOSSO_NUMERO}");

            /*" -217- CLOSE CSPAGSIN */
            CSPAGSIN.Close();

            /*" -221- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -221- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0100-00-LE-SISTEMAS-SECTION */
        private void R0100_00_LE_SISTEMAS_SECTION()
        {
            /*" -229- MOVE '0100' TO WNR-EXEC-SQL */
            _.Move("0100", WABEND.WNR_EXEC_SQL);

            /*" -238- PERFORM R0100_00_LE_SISTEMAS_DB_SELECT_1 */

            R0100_00_LE_SISTEMAS_DB_SELECT_1();

            /*" -241- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -242- DISPLAY 'ERRO NO SELECT SISTEMAS' */
                _.Display($"ERRO NO SELECT SISTEMAS");

                /*" -244- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -245- DISPLAY 'DATA DO SISTEMA DE SINISTRO -' ' ' SISTEMAS-DATA-MOV-ABERTO. */

            $"DATA DO SISTEMA DE SINISTRO - {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}"
            .Display();

        }

        [StopWatch]
        /*" R0100-00-LE-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_LE_SISTEMAS_DB_SELECT_1()
        {
            /*" -238- EXEC SQL SELECT DATA_MOV_ABERTO, YEAR(DATA_MOV_ABERTO), MONTH(DATA_MOV_ABERTO) INTO :SISTEMAS-DATA-MOV-ABERTO, :HOST-ANO-MOV-ABERTO, :HOST-MES-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' END-EXEC */

            var r0100_00_LE_SISTEMAS_DB_SELECT_1_Query1 = new R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1.Execute(r0100_00_LE_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.HOST_ANO_MOV_ABERTO, HOST_ANO_MOV_ABERTO);
                _.Move(executed_1.HOST_MES_MOV_ABERTO, HOST_MES_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_00_EXIT*/

        [StopWatch]
        /*" R0500-00-GERA-HEADER-SECTION */
        private void R0500_00_GERA_HEADER_SECTION()
        {
            /*" -255- MOVE '0500' TO WNR-EXEC-SQL */
            _.Move("0500", WABEND.WNR_EXEC_SQL);

            /*" -256- MOVE 'CSPAGSIN' TO GEARDETA-NOM-ARQUIVO */
            _.Move("CSPAGSIN", GEARDETA.DCLGE_AR_DETALHE.GEARDETA_NOM_ARQUIVO);

            /*" -257- PERFORM R0510-00-MAX-GEARDETA */

            R0510_00_MAX_GEARDETA_SECTION();

            /*" -258- ADD 1 TO GEARDETA-SEQ-GERACAO */
            GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO.Value = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO + 1;

            /*" -259- MOVE 0 TO GEARDETA-QTD-REG-PROCESSADO */
            _.Move(0, GEARDETA.DCLGE_AR_DETALHE.GEARDETA_QTD_REG_PROCESSADO);

            /*" -261- PERFORM R0520-00-INCLUI-GEARDETA */

            R0520_00_INCLUI_GEARDETA_SECTION();

            /*" -263- INITIALIZE REG-SCMOVSIN */
            _.Initialize(
                REG_SCMOVSIN
            );

            /*" -265- MOVE '1' TO HDR-TIPO-REGISTRO */
            _.Move("1", REG_SCMOVSIN.SCMOVSIN_HEADER.HDR_TIPO_REGISTRO);

            /*" -266- MOVE 'CADENA' TO HDR-NOME-ARQUIVO */
            _.Move("CADENA", REG_SCMOVSIN.SCMOVSIN_HEADER.HDR_NOME_ARQUIVO);

            /*" -267- MOVE 'SULAMERICA' TO HDR-NOME-CONVENIADA */
            _.Move("SULAMERICA", REG_SCMOVSIN.SCMOVSIN_HEADER.HDR_NOME_CONVENIADA);

            /*" -270- MOVE 5118 TO HDR-COD-ORIGEM-ARQUIVO */
            _.Move(5118, REG_SCMOVSIN.SCMOVSIN_HEADER.HDR_COD_ORIGEM_ARQUIVO);

            /*" -272- MOVE SISTEMAS-DATA-MOV-ABERTO TO HDR-DT-GERACAO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, REG_SCMOVSIN.SCMOVSIN_HEADER.HDR_DT_GERACAO);

            /*" -274- MOVE GEARDETA-SEQ-GERACAO TO HDR-NUM-SEQ-ARQUIVO */
            _.Move(GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO, REG_SCMOVSIN.SCMOVSIN_HEADER.HDR_NUM_SEQ_ARQUIVO);

            /*" -275- MOVE '1' TO HDR-IND-PROCESSAMENTO */
            _.Move("1", REG_SCMOVSIN.SCMOVSIN_HEADER.HDR_IND_PROCESSAMENTO);

            /*" -276- MOVE 'PAGAMENTO' TO HDR-RUBRICA-ARQUIVO */
            _.Move("PAGAMENTO", REG_SCMOVSIN.SCMOVSIN_HEADER.HDR_RUBRICA_ARQUIVO);

            /*" -278- MOVE SPACES TO HDR-MENSAGEM-RETORNO HDR-FILLER */
            _.Move("", REG_SCMOVSIN.SCMOVSIN_HEADER.HDR_MENSAGEM_RETORNO, REG_SCMOVSIN.SCMOVSIN_HEADER.HDR_FILLER);

            /*" -279- ADD 1 TO AC-G-CSPAGSIN */
            AC_G_CSPAGSIN.Value = AC_G_CSPAGSIN + 1;

            /*" -282- MOVE AC-G-CSPAGSIN TO HDR-NUM-SEQ-REGISTRO */
            _.Move(AC_G_CSPAGSIN, REG_SCMOVSIN.SCMOVSIN_HEADER.HDR_NUM_SEQ_REGISTRO);

            /*" -284- WRITE REG-SCMOVSIN. */
            CSPAGSIN.Write(REG_SCMOVSIN.GetMoveValues().ToString());

            /*" -285- MOVE '1' TO SIARVRCZ-TIPO-REGISTRO */
            _.Move("1", SIARVRCZ.DCLSI_AR_VERA_CRUZ.SIARVRCZ_TIPO_REGISTRO);

            /*" -286- MOVE AC-G-CSPAGSIN TO SIARVRCZ-SEQ-REGISTRO */
            _.Move(AC_G_CSPAGSIN, SIARVRCZ.DCLSI_AR_VERA_CRUZ.SIARVRCZ_SEQ_REGISTRO);

            /*" -287- MOVE '1' TO SIARVRCZ-STA-PROCESSAMENTO */
            _.Move("1", SIARVRCZ.DCLSI_AR_VERA_CRUZ.SIARVRCZ_STA_PROCESSAMENTO);

            /*" -287- PERFORM R0530-00-INCLUI-SIARVRCZ. */

            R0530_00_INCLUI_SIARVRCZ_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_00_EXIT*/

        [StopWatch]
        /*" R0510-00-MAX-GEARDETA-SECTION */
        private void R0510_00_MAX_GEARDETA_SECTION()
        {
            /*" -297- MOVE '0510' TO WNR-EXEC-SQL */
            _.Move("0510", WABEND.WNR_EXEC_SQL);

            /*" -302- PERFORM R0510_00_MAX_GEARDETA_DB_SELECT_1 */

            R0510_00_MAX_GEARDETA_DB_SELECT_1();

            /*" -305- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -307- DISPLAY 'ERRO MAX GE_AR_DETALHE' ' ' GEARDETA-NOM-ARQUIVO */

                $"ERRO MAX GE_AR_DETALHE {GEARDETA.DCLGE_AR_DETALHE.GEARDETA_NOM_ARQUIVO}"
                .Display();

                /*" -307- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0510-00-MAX-GEARDETA-DB-SELECT-1 */
        public void R0510_00_MAX_GEARDETA_DB_SELECT_1()
        {
            /*" -302- EXEC SQL SELECT VALUE(MAX(SEQ_GERACAO),0) INTO :GEARDETA-SEQ-GERACAO FROM SEGUROS.GE_AR_DETALHE WHERE NOM_ARQUIVO = :GEARDETA-NOM-ARQUIVO END-EXEC. */

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
            /*" -317- MOVE '0520' TO WNR-EXEC-SQL. */
            _.Move("0520", WABEND.WNR_EXEC_SQL);

            /*" -347- PERFORM R0520_00_INCLUI_GEARDETA_DB_INSERT_1 */

            R0520_00_INCLUI_GEARDETA_DB_INSERT_1();

            /*" -350- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -353- DISPLAY 'PROBLEMAS NO INSERT GE_AR_DETALHE' ' ' GEARDETA-NOM-ARQUIVO ' ' GEARDETA-SEQ-GERACAO */

                $"PROBLEMAS NO INSERT GE_AR_DETALHE {GEARDETA.DCLGE_AR_DETALHE.GEARDETA_NOM_ARQUIVO} {GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO}"
                .Display();

                /*" -355- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -355- ADD 1 TO AC-I-GEARDETA. */
            AC_I_GEARDETA.Value = AC_I_GEARDETA + 1;

        }

        [StopWatch]
        /*" R0520-00-INCLUI-GEARDETA-DB-INSERT-1 */
        public void R0520_00_INCLUI_GEARDETA_DB_INSERT_1()
        {
            /*" -347- EXEC SQL INSERT INTO SEGUROS.GE_AR_DETALHE (NOM_ARQUIVO, SEQ_GERACAO, DTH_ANO_REFERENCIA, DTH_MES_REFERENCIA, DTH_MOVIMENTO, DTH_GERACAO, DTH_RECEPCAO, IND_MEIO_ENVIO, STA_ENVIO_RECEPCAO, COD_TIPO_ARQUIVO, QTD_REG_PROCESSADO, QTD_REG_REJEITADOS, QTD_REG_ACEITOS, DTH_TIMESTAMP) VALUES (:GEARDETA-NOM-ARQUIVO, :GEARDETA-SEQ-GERACAO, :HOST-ANO-MOV-ABERTO, :HOST-MES-MOV-ABERTO, :SISTEMAS-DATA-MOV-ABERTO, :SISTEMAS-DATA-MOV-ABERTO, :SISTEMAS-DATA-MOV-ABERTO, 'E' , 'E' , 'TXT' , :GEARDETA-QTD-REG-PROCESSADO, 0, 0, CURRENT TIMESTAMP) END-EXEC. */

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
            /*" -365- MOVE '0530' TO WNR-EXEC-SQL. */
            _.Move("0530", WABEND.WNR_EXEC_SQL);

            /*" -379- PERFORM R0530_00_INCLUI_SIARVRCZ_DB_INSERT_1 */

            R0530_00_INCLUI_SIARVRCZ_DB_INSERT_1();

            /*" -382- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -387- DISPLAY 'PROBLEMAS NO INSERT SI_AR_VERA_CRUZ' ' ' GEARDETA-NOM-ARQUIVO ' ' GEARDETA-SEQ-GERACAO ' ' SIARVRCZ-TIPO-REGISTRO ' ' SIARVRCZ-SEQ-REGISTRO */

                $"PROBLEMAS NO INSERT SI_AR_VERA_CRUZ {GEARDETA.DCLGE_AR_DETALHE.GEARDETA_NOM_ARQUIVO} {GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO} {SIARVRCZ.DCLSI_AR_VERA_CRUZ.SIARVRCZ_TIPO_REGISTRO} {SIARVRCZ.DCLSI_AR_VERA_CRUZ.SIARVRCZ_SEQ_REGISTRO}"
                .Display();

                /*" -389- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -389- ADD 1 TO AC-I-SIARVRCZ. */
            AC_I_SIARVRCZ.Value = AC_I_SIARVRCZ + 1;

        }

        [StopWatch]
        /*" R0530-00-INCLUI-SIARVRCZ-DB-INSERT-1 */
        public void R0530_00_INCLUI_SIARVRCZ_DB_INSERT_1()
        {
            /*" -379- EXEC SQL INSERT INTO SEGUROS.SI_AR_VERA_CRUZ (NOM_ARQUIVO, SEQ_GERACAO, TIPO_REGISTRO, SEQ_REGISTRO, STA_PROCESSAMENTO, COD_ERRO) VALUES (:GEARDETA-NOM-ARQUIVO, :GEARDETA-SEQ-GERACAO, :SIARVRCZ-TIPO-REGISTRO, :SIARVRCZ-SEQ-REGISTRO, :SIARVRCZ-STA-PROCESSAMENTO, NULL) END-EXEC. */

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
            /*" -399- MOVE '0600' TO WNR-EXEC-SQL */
            _.Move("0600", WABEND.WNR_EXEC_SQL);

            /*" -401- INITIALIZE REG-SCMOVSIN */
            _.Initialize(
                REG_SCMOVSIN
            );

            /*" -402- MOVE '3' TO TRL-TIPO-REGISTRO */
            _.Move("3", REG_SCMOVSIN.SCMOVSIN_TRAILLER.TRL_TIPO_REGISTRO);

            /*" -405- MOVE 5118 TO TRL-COD-ORIGEM-ARQUIVO */
            _.Move(5118, REG_SCMOVSIN.SCMOVSIN_TRAILLER.TRL_COD_ORIGEM_ARQUIVO);

            /*" -406- MOVE '1' TO TRL-IND-PROCESSAMENTO */
            _.Move("1", REG_SCMOVSIN.SCMOVSIN_TRAILLER.TRL_IND_PROCESSAMENTO);

            /*" -409- MOVE SPACES TO TRL-MENSAGEM-RETORNO TRL-FILLER */
            _.Move("", REG_SCMOVSIN.SCMOVSIN_TRAILLER.TRL_MENSAGEM_RETORNO);
            _.Move("", REG_SCMOVSIN.SCMOVSIN_TRAILLER.TRL_FILLER);


            /*" -410- ADD 1 TO AC-G-CSPAGSIN */
            AC_G_CSPAGSIN.Value = AC_G_CSPAGSIN + 1;

            /*" -414- MOVE AC-G-CSPAGSIN TO TRL-QTD-REGISTROS TRL-NUM-SEQ-REGISTRO */
            _.Move(AC_G_CSPAGSIN, REG_SCMOVSIN.SCMOVSIN_TRAILLER.TRL_QTD_REGISTROS);
            _.Move(AC_G_CSPAGSIN, REG_SCMOVSIN.SCMOVSIN_TRAILLER.TRL_NUM_SEQ_REGISTRO);


            /*" -416- WRITE REG-SCMOVSIN. */
            CSPAGSIN.Write(REG_SCMOVSIN.GetMoveValues().ToString());

            /*" -417- MOVE '3' TO SIARVRCZ-TIPO-REGISTRO */
            _.Move("3", SIARVRCZ.DCLSI_AR_VERA_CRUZ.SIARVRCZ_TIPO_REGISTRO);

            /*" -418- MOVE AC-G-CSPAGSIN TO SIARVRCZ-SEQ-REGISTRO */
            _.Move(AC_G_CSPAGSIN, SIARVRCZ.DCLSI_AR_VERA_CRUZ.SIARVRCZ_SEQ_REGISTRO);

            /*" -419- MOVE '1' TO SIARVRCZ-STA-PROCESSAMENTO */
            _.Move("1", SIARVRCZ.DCLSI_AR_VERA_CRUZ.SIARVRCZ_STA_PROCESSAMENTO);

            /*" -419- PERFORM R0530-00-INCLUI-SIARVRCZ. */

            R0530_00_INCLUI_SIARVRCZ_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_00_EXIT*/

        [StopWatch]
        /*" R0700-00-ALTERA-GEARDETA-SECTION */
        private void R0700_00_ALTERA_GEARDETA_SECTION()
        {
            /*" -429- MOVE '0700' TO WNR-EXEC-SQL. */
            _.Move("0700", WABEND.WNR_EXEC_SQL);

            /*" -435- PERFORM R0700_00_ALTERA_GEARDETA_DB_UPDATE_1 */

            R0700_00_ALTERA_GEARDETA_DB_UPDATE_1();

            /*" -438- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -442- DISPLAY 'PROBLEMAS NO UPDATE GE_AR_DETALHE' ' ' GEARDETA-NOM-ARQUIVO ' ' GEARDETA-SEQ-GERACAO ' ' GEARDETA-QTD-REG-PROCESSADO */

                $"PROBLEMAS NO UPDATE GE_AR_DETALHE {GEARDETA.DCLGE_AR_DETALHE.GEARDETA_NOM_ARQUIVO} {GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO} {GEARDETA.DCLGE_AR_DETALHE.GEARDETA_QTD_REG_PROCESSADO}"
                .Display();

                /*" -444- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -444- ADD 1 TO AC-U-GEARDETA. */
            AC_U_GEARDETA.Value = AC_U_GEARDETA + 1;

        }

        [StopWatch]
        /*" R0700-00-ALTERA-GEARDETA-DB-UPDATE-1 */
        public void R0700_00_ALTERA_GEARDETA_DB_UPDATE_1()
        {
            /*" -435- EXEC SQL UPDATE SEGUROS.GE_AR_DETALHE SET QTD_REG_PROCESSADO = :GEARDETA-QTD-REG-PROCESSADO WHERE NOM_ARQUIVO = :GEARDETA-NOM-ARQUIVO AND SEQ_GERACAO = :GEARDETA-SEQ-GERACAO END-EXEC. */

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
            /*" -454- MOVE '0900' TO WNR-EXEC-SQL */
            _.Move("0900", WABEND.WNR_EXEC_SQL);

            /*" -572- PERFORM R0900_00_DECLARA_SIARDEVC_DB_DECLARE_1 */

            R0900_00_DECLARA_SIARDEVC_DB_DECLARE_1();

            /*" -574- PERFORM R0900_00_DECLARA_SIARDEVC_DB_OPEN_1 */

            R0900_00_DECLARA_SIARDEVC_DB_OPEN_1();

            /*" -577- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -578- DISPLAY 'PROBLEMAS NO OPEN SIARDEVC' */
                _.Display($"PROBLEMAS NO OPEN SIARDEVC");

                /*" -578- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARA-SIARDEVC-DB-DECLARE-1 */
        public void R0900_00_DECLARA_SIARDEVC_DB_DECLARE_1()
        {
            /*" -572- EXEC SQL DECLARE C01_SIARDEVC CURSOR FOR SELECT A.NOM_ARQUIVO, A.SEQ_GERACAO, A.TIPO_REGISTRO, A.SEQ_REGISTRO, A.COD_OPERACAO, A.OCORR_HISTORICO, A.NUM_SINISTRO_VC, A.NUM_EXPEDIENTE_VC, A.NUM_APOLICE, A.NUM_ENDOSSO, A.NUM_ITEM, A.COD_RAMO, A.COD_COBERTURA, A.COD_CAUSA, A.DATA_COMUNICADO, A.DATA_OCORRENCIA, A.HORA_OCORRENCIA, A.DATA_MOVIMENTO, A.IND_FAVORECIDO, A.VAL_TOT_MOVIMENTO, A.VAL_PECAS, A.VAL_MAO_OBRA, A.VAL_PARCELA_PEND, A.QTD_PARCELA_PEND, A.VAL_DESC_PARC_PEND, A.DATA_NEGOCIADA, A.VAL_IRF, A.VAL_ISS, A.VAL_INSS, A.VAL_LIQUIDO_PAGTO, A.CGCCPF, A.TIPO_PESSOA, A.NOM_FAVORECIDO, A.IND_DOC_FISCAL, A.NUM_DOC_FISCAL, A.SERIE_DOC_FISCAL, A.DATA_EMISSAO, A.DES_ENDERECO, A.NOM_BAIRRO, A.NOM_CIDADE, A.COD_UF, A.NUM_CEP, A.NUM_DDD, A.NUM_TELEFONE, A.IND_FORMA_PAGTO, A.NUM_IDENTIFICADOR, A.NUM_CHEQUE_INTERNO, A.ORDEM_PAGAMENTO_VC, A.ORDEM_PAGAMENTO, A.COD_BANCO, A.COD_AGENCIA, A.OPERACAO_CONTA, A.COD_CONTA, A.DV_CONTA, A.COD_FAVORECIDO, A.NUM_APOL_SINISTRO, A.STA_PROCESSAMENTO, VALUE(COD_ERRO, 0), A.VAL_PISPASEP, A.VAL_COFINS, A.VAL_CSLL, VALUE(COD_FONTE, 0), B.COD_OPERACAO, B.OCORR_HISTORICO, VALUE(A.NUM_RESSARC, 0), VALUE(A.IND_PESSOA_ACORDO, ' ' ), VALUE(A.NUM_CPFCGC_ACORDO, 0), VALUE(A.NOM_RESP_ACORDO, ' ' ), VALUE(A.STA_ACORDO, ' ' ), VALUE(A.DTH_INDENIZACAO, DATE( '0001-01-01' )), VALUE(A.VLR_INDENIZACAO, 0), VALUE(A.VLR_PART_TERCEIROS, 0), VALUE(A.VLR_DIVIDA, 0), VALUE(A.PCT_DESCONTO, 0), VALUE(A.VLR_TOTAL_DESCONTO, 0), VALUE(A.VLR_TOTAL_ACORDO, 0), VALUE(A.COD_MOEDA_ACORDO, 0), VALUE(A.DTH_ACORDO, DATE( '0001-01-01' )), VALUE(A.QTD_PARCELAS_ACORDO, 0), VALUE(A.NUM_PARCELA_ACORDO, 0), VALUE(A.COD_AGENCIA_CEDENT, 0), VALUE(A.NUM_CEDENTE, 0), VALUE(A.NUM_CEDENTE_DV, ' ' ), VALUE(A.DTH_VENCIMENTO, DATE( '0001-01-01' )), VALUE(A.NUM_NOSSO_TITULO, 0), VALUE(A.VLR_TITULO, 0), VALUE(A.NUM_CPFCGC_RECLAMANTE, 0), VALUE(A.NOM_RECLAMANTE, ' ' ), VALUE(A.VLR_RECLAMADO, 0), VALUE(A.VLR_PROVISIONADO, 0), VALUE(NUM_SINISTRO_CONV, ' ' ), VALUE(NUM_IDENT_CONV, 0), VALUE(NUM_IDE_COBR_CONV, 0), VALUE(A.COD_CFOP, 0), VALUE(A.COD_CEST, 0), VALUE(A.NUM_INSCR_ESTADUAL, 0), VALUE(A.NUM_NCM, 0), VALUE(A.NUM_CPF_CNPJ_TOMADOR, 0), VALUE(A.IND_ISENCAO_TRIBUTO, 'N' ), VALUE(A.COD_IMPOSTO_LIMINAR, 0), VALUE(A.COD_PROCESSO_ISENCAO, ' ' ), VALUE(A.VLR_RET_N_EFETUADO, 0) FROM SEGUROS.SI_AR_DETALHE_VC A, SEGUROS.SINISTRO_HISTORICO B, SEGUROS.SI_RESSARC_PARCELA C WHERE A.NOM_ARQUIVO = 'SCMOVSIN' AND A.STA_PROCESSAMENTO = '1' AND A.STA_RETORNO = '2' AND A.COD_OPERACAO IN (4000, 4001, 4002) AND A.NUM_APOL_SINISTRO = B.NUM_APOL_SINISTRO AND B.COD_OPERACAO = 4100 AND B.NUM_APOL_SINISTRO = C.NUM_APOL_SINISTRO AND B.COD_OPERACAO = C.COD_OPERACAO AND B.OCORR_HISTORICO = C.OCORR_HISTORICO AND A.NUM_RESSARC = C.NUM_RESSARC AND A.NUM_PARCELA_ACORDO = C.NUM_PARCELA ORDER BY SEQ_REGISTRO END-EXEC. */
            C01_SIARDEVC = new SI9268B_C01_SIARDEVC(false);
            string GetQuery_C01_SIARDEVC()
            {
                var query = @$"SELECT A.NOM_ARQUIVO
							, 
							A.SEQ_GERACAO
							, 
							A.TIPO_REGISTRO
							, 
							A.SEQ_REGISTRO
							, 
							A.COD_OPERACAO
							, 
							A.OCORR_HISTORICO
							, 
							A.NUM_SINISTRO_VC
							, 
							A.NUM_EXPEDIENTE_VC
							, 
							A.NUM_APOLICE
							, 
							A.NUM_ENDOSSO
							, 
							A.NUM_ITEM
							, 
							A.COD_RAMO
							, 
							A.COD_COBERTURA
							, 
							A.COD_CAUSA
							, 
							A.DATA_COMUNICADO
							, 
							A.DATA_OCORRENCIA
							, 
							A.HORA_OCORRENCIA
							, 
							A.DATA_MOVIMENTO
							, 
							A.IND_FAVORECIDO
							, 
							A.VAL_TOT_MOVIMENTO
							, 
							A.VAL_PECAS
							, 
							A.VAL_MAO_OBRA
							, 
							A.VAL_PARCELA_PEND
							, 
							A.QTD_PARCELA_PEND
							, 
							A.VAL_DESC_PARC_PEND
							, 
							A.DATA_NEGOCIADA
							, 
							A.VAL_IRF
							, 
							A.VAL_ISS
							, 
							A.VAL_INSS
							, 
							A.VAL_LIQUIDO_PAGTO
							, 
							A.CGCCPF
							, 
							A.TIPO_PESSOA
							, 
							A.NOM_FAVORECIDO
							, 
							A.IND_DOC_FISCAL
							, 
							A.NUM_DOC_FISCAL
							, 
							A.SERIE_DOC_FISCAL
							, 
							A.DATA_EMISSAO
							, 
							A.DES_ENDERECO
							, 
							A.NOM_BAIRRO
							, 
							A.NOM_CIDADE
							, 
							A.COD_UF
							, 
							A.NUM_CEP
							, 
							A.NUM_DDD
							, 
							A.NUM_TELEFONE
							, 
							A.IND_FORMA_PAGTO
							, 
							A.NUM_IDENTIFICADOR
							, 
							A.NUM_CHEQUE_INTERNO
							, 
							A.ORDEM_PAGAMENTO_VC
							, 
							A.ORDEM_PAGAMENTO
							, 
							A.COD_BANCO
							, 
							A.COD_AGENCIA
							, 
							A.OPERACAO_CONTA
							, 
							A.COD_CONTA
							, 
							A.DV_CONTA
							, 
							A.COD_FAVORECIDO
							, 
							A.NUM_APOL_SINISTRO
							, 
							A.STA_PROCESSAMENTO
							, 
							VALUE(COD_ERRO
							, 0)
							, 
							A.VAL_PISPASEP
							, 
							A.VAL_COFINS
							, 
							A.VAL_CSLL
							, 
							VALUE(COD_FONTE
							, 0)
							, 
							B.COD_OPERACAO
							, 
							B.OCORR_HISTORICO
							, 
							VALUE(A.NUM_RESSARC
							, 0)
							, 
							VALUE(A.IND_PESSOA_ACORDO
							, ' ' )
							, 
							VALUE(A.NUM_CPFCGC_ACORDO
							, 0)
							, 
							VALUE(A.NOM_RESP_ACORDO
							, ' ' )
							, 
							VALUE(A.STA_ACORDO
							, ' ' )
							, 
							VALUE(A.DTH_INDENIZACAO
							, DATE( '0001-01-01' ))
							, 
							VALUE(A.VLR_INDENIZACAO
							, 0)
							, 
							VALUE(A.VLR_PART_TERCEIROS
							, 0)
							, 
							VALUE(A.VLR_DIVIDA
							, 0)
							, 
							VALUE(A.PCT_DESCONTO
							, 0)
							, 
							VALUE(A.VLR_TOTAL_DESCONTO
							, 0)
							, 
							VALUE(A.VLR_TOTAL_ACORDO
							, 0)
							, 
							VALUE(A.COD_MOEDA_ACORDO
							, 0)
							, 
							VALUE(A.DTH_ACORDO
							, DATE( '0001-01-01' ))
							, 
							VALUE(A.QTD_PARCELAS_ACORDO
							, 0)
							, 
							VALUE(A.NUM_PARCELA_ACORDO
							, 0)
							, 
							VALUE(A.COD_AGENCIA_CEDENT
							, 0)
							, 
							VALUE(A.NUM_CEDENTE
							, 0)
							, 
							VALUE(A.NUM_CEDENTE_DV
							, ' ' )
							, 
							VALUE(A.DTH_VENCIMENTO
							, DATE( '0001-01-01' ))
							, 
							VALUE(A.NUM_NOSSO_TITULO
							, 0)
							, 
							VALUE(A.VLR_TITULO
							, 0)
							, 
							VALUE(A.NUM_CPFCGC_RECLAMANTE
							, 0)
							, 
							VALUE(A.NOM_RECLAMANTE
							, ' ' )
							, 
							VALUE(A.VLR_RECLAMADO
							, 0)
							, 
							VALUE(A.VLR_PROVISIONADO
							, 0)
							, 
							VALUE(NUM_SINISTRO_CONV
							, ' ' )
							, 
							VALUE(NUM_IDENT_CONV
							, 0)
							, 
							VALUE(NUM_IDE_COBR_CONV
							, 0)
							, 
							VALUE(A.COD_CFOP
							, 0)
							, 
							VALUE(A.COD_CEST
							, 0)
							, 
							VALUE(A.NUM_INSCR_ESTADUAL
							, 0)
							, 
							VALUE(A.NUM_NCM
							, 0)
							, 
							VALUE(A.NUM_CPF_CNPJ_TOMADOR
							, 0)
							, 
							VALUE(A.IND_ISENCAO_TRIBUTO
							, 'N' )
							, 
							VALUE(A.COD_IMPOSTO_LIMINAR
							, 0)
							, 
							VALUE(A.COD_PROCESSO_ISENCAO
							, ' ' )
							, 
							VALUE(A.VLR_RET_N_EFETUADO
							, 0) 
							FROM SEGUROS.SI_AR_DETALHE_VC A
							, 
							SEGUROS.SINISTRO_HISTORICO B
							, 
							SEGUROS.SI_RESSARC_PARCELA C 
							WHERE A.NOM_ARQUIVO = 'SCMOVSIN' 
							AND A.STA_PROCESSAMENTO = '1' 
							AND A.STA_RETORNO = '2' 
							AND A.COD_OPERACAO IN (4000
							, 4001
							, 4002) 
							AND A.NUM_APOL_SINISTRO = B.NUM_APOL_SINISTRO 
							AND B.COD_OPERACAO = 4100 
							AND B.NUM_APOL_SINISTRO = C.NUM_APOL_SINISTRO 
							AND B.COD_OPERACAO = C.COD_OPERACAO 
							AND B.OCORR_HISTORICO = C.OCORR_HISTORICO 
							AND A.NUM_RESSARC = C.NUM_RESSARC 
							AND A.NUM_PARCELA_ACORDO = C.NUM_PARCELA 
							ORDER BY SEQ_REGISTRO";

                return query;
            }
            C01_SIARDEVC.GetQueryEvent += GetQuery_C01_SIARDEVC;

        }

        [StopWatch]
        /*" R0900-00-DECLARA-SIARDEVC-DB-OPEN-1 */
        public void R0900_00_DECLARA_SIARDEVC_DB_OPEN_1()
        {
            /*" -574- EXEC SQL OPEN C01_SIARDEVC END-EXEC. */

            C01_SIARDEVC.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_00_EXIT*/

        [StopWatch]
        /*" R0910-00-LE-SIARDEVC-SECTION */
        private void R0910_00_LE_SIARDEVC_SECTION()
        {
            /*" -588- MOVE '0910' TO WNR-EXEC-SQL. */
            _.Move("0910", WABEND.WNR_EXEC_SQL);

            /*" -691- PERFORM R0910_00_LE_SIARDEVC_DB_FETCH_1 */

            R0910_00_LE_SIARDEVC_DB_FETCH_1();

            /*" -694- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -695- ADD 1 TO AC-L-SIARDEVC */
                AC_L_SIARDEVC.Value = AC_L_SIARDEVC + 1;

                /*" -696- ELSE */
            }
            else
            {


                /*" -697- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -698- MOVE 'S' TO WFIM-SIARDEVC */
                    _.Move("S", WFIM_SIARDEVC);

                    /*" -698- PERFORM R0910_00_LE_SIARDEVC_DB_CLOSE_1 */

                    R0910_00_LE_SIARDEVC_DB_CLOSE_1();

                    /*" -700- ELSE */
                }
                else
                {


                    /*" -701- DISPLAY 'PROBLEMAS NO FETCH SIARDEVC' */
                    _.Display($"PROBLEMAS NO FETCH SIARDEVC");

                    /*" -701- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0910-00-LE-SIARDEVC-DB-FETCH-1 */
        public void R0910_00_LE_SIARDEVC_DB_FETCH_1()
        {
            /*" -691- EXEC SQL FETCH C01_SIARDEVC INTO :SIARDEVC-NOM-ARQUIVO, :SIARDEVC-SEQ-GERACAO, :SIARDEVC-TIPO-REGISTRO, :SIARDEVC-SEQ-REGISTRO, :SIARDEVC-COD-OPERACAO, :SIARDEVC-OCORR-HISTORICO, :SIARDEVC-NUM-SINISTRO-VC, :SIARDEVC-NUM-EXPEDIENTE-VC, :SIARDEVC-NUM-APOLICE, :SIARDEVC-NUM-ENDOSSO, :SIARDEVC-NUM-ITEM, :SIARDEVC-COD-RAMO, :SIARDEVC-COD-COBERTURA, :SIARDEVC-COD-CAUSA, :SIARDEVC-DATA-COMUNICADO, :SIARDEVC-DATA-OCORRENCIA, :SIARDEVC-HORA-OCORRENCIA, :SIARDEVC-DATA-MOVIMENTO, :SIARDEVC-IND-FAVORECIDO, :SIARDEVC-VAL-TOT-MOVIMENTO, :SIARDEVC-VAL-PECAS, :SIARDEVC-VAL-MAO-OBRA, :SIARDEVC-VAL-PARCELA-PEND, :SIARDEVC-QTD-PARCELA-PEND, :SIARDEVC-VAL-DESC-PARC-PEND, :SIARDEVC-DATA-NEGOCIADA, :SIARDEVC-VAL-IRF, :SIARDEVC-VAL-ISS, :SIARDEVC-VAL-INSS, :SIARDEVC-VAL-LIQUIDO-PAGTO, :SIARDEVC-CGCCPF, :SIARDEVC-TIPO-PESSOA, :SIARDEVC-NOM-FAVORECIDO, :SIARDEVC-IND-DOC-FISCAL, :SIARDEVC-NUM-DOC-FISCAL, :SIARDEVC-SERIE-DOC-FISCAL, :SIARDEVC-DATA-EMISSAO, :SIARDEVC-DES-ENDERECO, :SIARDEVC-NOM-BAIRRO, :SIARDEVC-NOM-CIDADE, :SIARDEVC-COD-UF, :SIARDEVC-NUM-CEP, :SIARDEVC-NUM-DDD, :SIARDEVC-NUM-TELEFONE, :SIARDEVC-IND-FORMA-PAGTO, :SIARDEVC-NUM-IDENTIFICADOR, :SIARDEVC-NUM-CHEQUE-INTERNO, :SIARDEVC-ORDEM-PAGAMENTO-VC, :SIARDEVC-ORDEM-PAGAMENTO, :SIARDEVC-COD-BANCO, :SIARDEVC-COD-AGENCIA, :SIARDEVC-OPERACAO-CONTA, :SIARDEVC-COD-CONTA, :SIARDEVC-DV-CONTA, :SIARDEVC-COD-FAVORECIDO, :SIARDEVC-NUM-APOL-SINISTRO, :SIARDEVC-STA-PROCESSAMENTO, :SIARDEVC-COD-ERRO, :SIARDEVC-VAL-PISPASEP, :SIARDEVC-VAL-COFINS, :SIARDEVC-VAL-CSLL, :SIARDEVC-COD-FONTE, :SINISHIS-COD-OPERACAO, :SINISHIS-OCORR-HISTORICO, :SIARDEVC-NUM-RESSARC, :SIARDEVC-IND-PESSOA-ACORDO, :SIARDEVC-NUM-CPFCGC-ACORDO, :SIARDEVC-NOM-RESP-ACORDO, :SIARDEVC-STA-ACORDO, :SIARDEVC-DTH-INDENIZACAO, :SIARDEVC-VLR-INDENIZACAO, :SIARDEVC-VLR-PART-TERCEIROS, :SIARDEVC-VLR-DIVIDA, :SIARDEVC-PCT-DESCONTO, :SIARDEVC-VLR-TOTAL-DESCONTO, :SIARDEVC-VLR-TOTAL-ACORDO, :SIARDEVC-COD-MOEDA-ACORDO, :SIARDEVC-DTH-ACORDO, :SIARDEVC-QTD-PARCELAS-ACORDO, :SIARDEVC-NUM-PARCELA-ACORDO, :SIARDEVC-COD-AGENCIA-CEDENT, :SIARDEVC-NUM-CEDENTE, :SIARDEVC-NUM-CEDENTE-DV, :SIARDEVC-DTH-VENCIMENTO, :SIARDEVC-NUM-NOSSO-TITULO, :SIARDEVC-VLR-TITULO, :SIARDEVC-NUM-CPFCGC-RECLAMANTE, :SIARDEVC-NOM-RECLAMANTE, :SIARDEVC-VLR-RECLAMADO, :SIARDEVC-VLR-PROVISIONADO, :SIARDEVC-NUM-SINISTRO-CONV, :SIARDEVC-NUM-IDENT-CONV, :SIARDEVC-NUM-IDE-COBR-CONV, :SIARDEVC-COD-CFOP, :SIARDEVC-COD-CEST, :SIARDEVC-NUM-INSCR-ESTADUAL, :SIARDEVC-NUM-NCM, :SIARDEVC-NUM-CPF-CNPJ-TOMADOR, :SIARDEVC-IND-ISENCAO-TRIBUTO, :SIARDEVC-COD-IMPOSTO-LIMINAR, :SIARDEVC-COD-PROCESSO-ISENCAO, :SIARDEVC-VLR-RET-N-EFETUADO END-EXEC. */

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
                _.Move(C01_SIARDEVC.SINISHIS_COD_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);
                _.Move(C01_SIARDEVC.SINISHIS_OCORR_HISTORICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO);
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
            /*" -698- EXEC SQL CLOSE C01_SIARDEVC END-EXEC */

            C01_SIARDEVC.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-SIARDEVC-SECTION */
        private void R1000_00_PROCESSA_SIARDEVC_SECTION()
        {
            /*" -711- MOVE '1000' TO WNR-EXEC-SQL */
            _.Move("1000", WABEND.WNR_EXEC_SQL);

            /*" -712- IF SIARDEVC-COD-ERRO NOT EQUAL ZEROS */

            if (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO != 00)
            {

                /*" -713- PERFORM R1100-00-LE-SIERRO */

                R1100_00_LE_SIERRO_SECTION();

                /*" -714- ELSE */
            }
            else
            {


                /*" -716- MOVE SPACES TO SIERRO-DES-ERRO. */
                _.Move("", SIERRO.DCLSI_ERRO.SIERRO_DES_ERRO);
            }


            /*" -718- PERFORM R1200-00-GERA-DETALHE */

            R1200_00_GERA_DETALHE_SECTION();

            /*" -719- MOVE '2' TO SIARREVC-TIPO-REGISTRO-VC */
            _.Move("2", SIARREVC.DCLSI_AR_RETORNO_VC.SIARREVC_TIPO_REGISTRO_VC);

            /*" -720- MOVE AC-G-CSPAGSIN TO SIARREVC-SEQ-REGISTRO-VC */
            _.Move(AC_G_CSPAGSIN, SIARREVC.DCLSI_AR_RETORNO_VC.SIARREVC_SEQ_REGISTRO_VC);

            /*" -722- PERFORM R1300-00-INCLUI-SIARREVC */

            R1300_00_INCLUI_SIARREVC_SECTION();

            /*" -722- PERFORM R1400-00-ALTERA-SIARDEVC. */

            R1400_00_ALTERA_SIARDEVC_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R1000_10_LE_SIARDEVC */

            R1000_10_LE_SIARDEVC();

        }

        [StopWatch]
        /*" R1000-10-LE-SIARDEVC */
        private void R1000_10_LE_SIARDEVC(bool isPerform = false)
        {
            /*" -728- PERFORM R0910-00-LE-SIARDEVC. */

            R0910_00_LE_SIARDEVC_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_00_EXIT*/

        [StopWatch]
        /*" R1100-00-LE-SIERRO-SECTION */
        private void R1100_00_LE_SIERRO_SECTION()
        {
            /*" -738- MOVE '1100' TO WNR-EXEC-SQL */
            _.Move("1100", WABEND.WNR_EXEC_SQL);

            /*" -743- PERFORM R1100_00_LE_SIERRO_DB_SELECT_1 */

            R1100_00_LE_SIERRO_DB_SELECT_1();

            /*" -746- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -752- DISPLAY 'ERRO SELECT SI_ERRO' ' ' SIARDEVC-NOM-ARQUIVO ' ' SIARDEVC-SEQ-GERACAO ' ' SIARDEVC-TIPO-REGISTRO ' ' SIARDEVC-SEQ-REGISTRO ' ' SIARDEVC-COD-ERRO */

                $"ERRO SELECT SI_ERRO {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_ARQUIVO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_GERACAO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_REGISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_REGISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_ERRO}"
                .Display();

                /*" -752- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1100-00-LE-SIERRO-DB-SELECT-1 */
        public void R1100_00_LE_SIERRO_DB_SELECT_1()
        {
            /*" -743- EXEC SQL SELECT DES_ERRO INTO :SIERRO-DES-ERRO FROM SEGUROS.SI_ERRO WHERE COD_ERRO = :SIARDEVC-COD-ERRO END-EXEC. */

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
            /*" -762- MOVE '1200' TO WNR-EXEC-SQL */
            _.Move("1200", WABEND.WNR_EXEC_SQL);

            /*" -764- INITIALIZE REG-SCMOVSIN */
            _.Initialize(
                REG_SCMOVSIN
            );

            /*" -767- IF SIARDEVC-NUM-APOL-SINISTRO EQUAL ZEROS */

            if (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO == 00)
            {

                /*" -768- MOVE ZEROS TO DET-NUM-PROTOCOLO-SINI */
                _.Move(0, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NUM_PROTOCOLO_SINI);

                /*" -769- ELSE */
            }
            else
            {


                /*" -770- PERFORM R1210-00-LE-SINISMES */

                R1210_00_LE_SINISMES_SECTION();

                /*" -775- MOVE SINISMES-NUM-PROTOCOLO-SINI TO DET-NUM-PROTOCOLO-SINI. */
                _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_PROTOCOLO_SINI, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NUM_PROTOCOLO_SINI);
            }


            /*" -778- MOVE SIARDEVC-COD-FONTE TO DET-FONTE-SINISTRO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_FONTE, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_FONTE_SINISTRO);

            /*" -780- MOVE '2' TO DET-TIPO-REGISTRO */
            _.Move("2", REG_SCMOVSIN.SCMOVSIN_DADOS.DET_TIPO_REGISTRO);

            /*" -781- ADD 1 TO AC-G-CSPAGSIN */
            AC_G_CSPAGSIN.Value = AC_G_CSPAGSIN + 1;

            /*" -785- MOVE AC-G-CSPAGSIN TO DET-NUM-SEQ-REGISTRO */
            _.Move(AC_G_CSPAGSIN, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NUM_SEQ_REGISTRO);

            /*" -787- MOVE '3' TO DET-IND-PROCESSAMENTO */
            _.Move("3", REG_SCMOVSIN.SCMOVSIN_DADOS.DET_IND_PROCESSAMENTO);

            /*" -789- MOVE SIERRO-DES-ERRO TO DET-MENSAGEM-RETORNO */
            _.Move(SIERRO.DCLSI_ERRO.SIERRO_DES_ERRO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_MENSAGEM_RETORNO);

            /*" -791- MOVE SIARDEVC-NUM-APOL-SINISTRO TO DET-NUM-SINISTRO-CXSEG */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NUM_SINISTRO_CXSEG);

            /*" -793- MOVE SINISHIS-COD-OPERACAO TO DET-COD-OPERACAO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_COD_OPERACAO);

            /*" -796- MOVE SINISHIS-OCORR-HISTORICO TO DET-NUM-OCORR-HISTORICO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NUM_OCORR_HISTORICO);

            /*" -798- MOVE SIARDEVC-NUM-SINISTRO-CONV TO DET-NUM-SINISTRO-VC */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_SINISTRO_CONV, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NUM_SINISTRO_VC);

            /*" -800- MOVE SIARDEVC-NUM-EXPEDIENTE-VC TO DET-NUM-EXPEDIENTE-VC */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_EXPEDIENTE_VC, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NUM_EXPEDIENTE_VC);

            /*" -802- MOVE SIARDEVC-NUM-APOLICE TO DET-NUM-APOLICE */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOLICE, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NUM_APOLICE);

            /*" -804- MOVE SIARDEVC-NUM-ENDOSSO TO DET-NUM-ENDOSSO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_ENDOSSO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NUM_ENDOSSO);

            /*" -805- MOVE SIARDEVC-NUM-ITEM TO DET-NUM-ITEM */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_ITEM, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NUM_ITEM);

            /*" -806- MOVE SIARDEVC-COD-RAMO TO DET-COD-RAMO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_RAMO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_COD_RAMO);

            /*" -808- MOVE SIARDEVC-COD-COBERTURA TO DET-COD-COBERTURA */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_COBERTURA, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_COD_COBERTURA);

            /*" -810- MOVE SIARDEVC-COD-CAUSA TO DET-COD-CAUSA */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_CAUSA, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_COD_CAUSA);

            /*" -812- MOVE SIARDEVC-DATA-COMUNICADO TO DET-DT-COMUNICADO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_COMUNICADO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_DT_COMUNICADO);

            /*" -815- MOVE SIARDEVC-DATA-OCORRENCIA TO DET-DT-OCORRENCIA */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_OCORRENCIA, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_DT_OCORRENCIA);

            /*" -817- IF SIARDEVC-HORA-OCORRENCIA EQUAL '00:00:00' */

            if (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_HORA_OCORRENCIA == "00:00:00")
            {

                /*" -818- MOVE SPACES TO DET-HORA-OCORRENCIA */
                _.Move("", REG_SCMOVSIN.SCMOVSIN_DADOS.DET_HORA_OCORRENCIA);

                /*" -819- ELSE */
            }
            else
            {


                /*" -822- MOVE SIARDEVC-HORA-OCORRENCIA TO DET-HORA-OCORRENCIA. */
                _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_HORA_OCORRENCIA, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_HORA_OCORRENCIA);
            }


            /*" -824- MOVE SIARDEVC-DATA-MOVIMENTO TO DET-DT-MOVIMENTO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_MOVIMENTO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_DT_MOVIMENTO);

            /*" -826- MOVE SIARDEVC-IND-FAVORECIDO TO DET-IND-TIPO-FAVORECIDO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_IND_FAVORECIDO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_IND_TIPO_FAVORECIDO);

            /*" -828- MOVE SIARDEVC-VAL-TOT-MOVIMENTO TO DET-VAL-TOTAL-MOVIMENTO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_TOT_MOVIMENTO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_VAL_TOTAL_MOVIMENTO);

            /*" -830- MOVE SIARDEVC-VAL-PECAS TO DET-VAL-PECAS */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_PECAS, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_VAL_PECAS);

            /*" -832- MOVE SIARDEVC-VAL-MAO-OBRA TO DET-VAL-MAO-OBRA */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_MAO_OBRA, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_VAL_MAO_OBRA);

            /*" -834- MOVE SIARDEVC-VAL-PARCELA-PEND TO DET-VAL-PARCELA-PEND */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_PARCELA_PEND, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_VAL_PARCELA_PEND);

            /*" -836- MOVE SIARDEVC-QTD-PARCELA-PEND TO DET-QTD-PARCELA-PEND */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_QTD_PARCELA_PEND, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_QTD_PARCELA_PEND);

            /*" -839- MOVE SIARDEVC-VAL-DESC-PARC-PEND TO DET-VAL-DESC-PARCELA-PEND */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_DESC_PARC_PEND, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_VAL_DESC_PARCELA_PEND);

            /*" -841- IF SIARDEVC-DATA-NEGOCIADA EQUAL '0001-01-01' */

            if (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_NEGOCIADA == "0001-01-01")
            {

                /*" -842- MOVE SPACES TO DET-DT-NEGOCIADA-PAGTO */
                _.Move("", REG_SCMOVSIN.SCMOVSIN_DADOS.DET_DT_NEGOCIADA_PAGTO);

                /*" -843- ELSE */
            }
            else
            {


                /*" -846- MOVE SIARDEVC-DATA-NEGOCIADA TO DET-DT-NEGOCIADA-PAGTO. */
                _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_NEGOCIADA, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_DT_NEGOCIADA_PAGTO);
            }


            /*" -847- MOVE SIARDEVC-VAL-IRF TO DET-VAL-IRRF */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_IRF, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_VAL_IRRF);

            /*" -848- MOVE SIARDEVC-VAL-ISS TO DET-VAL-ISS */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_ISS, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_VAL_ISS);

            /*" -849- MOVE SIARDEVC-VAL-INSS TO DET-VAL-INSS */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_INSS, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_VAL_INSS);

            /*" -851- MOVE SIARDEVC-VAL-PISPASEP TO DET-VAL-PISPASEP */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_PISPASEP, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_VAL_PISPASEP);

            /*" -853- MOVE SIARDEVC-VAL-COFINS TO DET-VAL-COFINS */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_COFINS, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_VAL_COFINS);

            /*" -854- MOVE SIARDEVC-VAL-CSLL TO DET-VAL-CSLL */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_CSLL, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_VAL_CSLL);

            /*" -856- MOVE SIARDEVC-VAL-LIQUIDO-PAGTO TO DET-VAL-LIQUIDO-PAGO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VAL_LIQUIDO_PAGTO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_VAL_LIQUIDO_PAGO);

            /*" -857- MOVE SIARDEVC-CGCCPF TO DET-CNPJ-CPF-FAVORECIDO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_CGCCPF, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_CNPJ_CPF_FAVORECIDO);

            /*" -859- MOVE SIARDEVC-TIPO-PESSOA TO DET-TIPO-PESSOA */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_PESSOA, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_TIPO_PESSOA);

            /*" -861- MOVE SIARDEVC-NOM-FAVORECIDO TO DET-NOME-FAVORECIDO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_FAVORECIDO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NOME_FAVORECIDO);

            /*" -863- MOVE SIARDEVC-IND-DOC-FISCAL TO DET-IND-TIPO-DOC-FISCAL */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_IND_DOC_FISCAL, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_IND_TIPO_DOC_FISCAL);

            /*" -865- MOVE SIARDEVC-NUM-DOC-FISCAL TO DET-NUM-DOC-FISCAL */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_DOC_FISCAL, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NUM_DOC_FISCAL);

            /*" -868- MOVE SIARDEVC-SERIE-DOC-FISCAL TO DET-SERIE-DOC-FISCAL */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SERIE_DOC_FISCAL, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_SERIE_DOC_FISCAL);

            /*" -870- IF SIARDEVC-DATA-EMISSAO EQUAL '0001-01-01' */

            if (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_EMISSAO == "0001-01-01")
            {

                /*" -871- MOVE SPACES TO DET-DT-EMISSAO-DOC */
                _.Move("", REG_SCMOVSIN.SCMOVSIN_DADOS.DET_DT_EMISSAO_DOC);

                /*" -872- ELSE */
            }
            else
            {


                /*" -875- MOVE SIARDEVC-DATA-EMISSAO TO DET-DT-EMISSAO-DOC. */
                _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DATA_EMISSAO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_DT_EMISSAO_DOC);
            }


            /*" -877- MOVE SIARDEVC-DES-ENDERECO TO DET-ENDERECO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DES_ENDERECO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_ENDERECO);

            /*" -879- MOVE SIARDEVC-NOM-BAIRRO TO DET-NOM-BAIRRO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_BAIRRO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NOM_BAIRRO);

            /*" -881- MOVE SIARDEVC-NOM-CIDADE TO DET-NOM-CIDADE */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_CIDADE, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NOM_CIDADE);

            /*" -882- MOVE SIARDEVC-COD-UF TO DET-NOM-SIGLA-UF */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_UF, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NOM_SIGLA_UF);

            /*" -883- MOVE SIARDEVC-NUM-CEP TO DET-NUM-CEP */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CEP, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_CEP.DET_NUM_CEP);

            /*" -884- MOVE SIARDEVC-NUM-DDD TO DET-NUM-DDD */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_DDD, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NUM_DDD);

            /*" -886- MOVE SIARDEVC-NUM-TELEFONE TO DET-NUM-TELEFONE */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_TELEFONE, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NUM_TELEFONE);

            /*" -889- MOVE SIARDEVC-IND-FORMA-PAGTO TO DET-IND-FORMA-PAGTO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_IND_FORMA_PAGTO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_IND_FORMA_PAGTO);

            /*" -891- MOVE SIARDEVC-NUM-IDENTIFICADOR TO DET-NUM-IDENTIFICADOR-PAGTO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_IDENTIFICADOR, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NUM_IDENTIFICADOR_PAGTO);

            /*" -894- MOVE SIARDEVC-NUM-CHEQUE-INTERNO TO DET-NUM-CHEQUE-INTERNO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CHEQUE_INTERNO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NUM_CHEQUE_INTERNO);

            /*" -896- MOVE SPACES TO WS-IDENT-PAGTO-EDITADO */
            _.Move("", WS_IDENT_PAGTO_EDITADO);

            /*" -898- IF SIARDEVC-NUM-IDENTIFICADOR NOT EQUAL ZEROS */

            if (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_IDENTIFICADOR != 00)
            {

                /*" -900- MOVE SIARDEVC-NUM-IDENTIFICADOR TO WS-CHEQUE-EXTERNO */
                _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_IDENTIFICADOR, WS_IDENT_PAGTO_EDITADO.WS_CHEQUE_EXTERNO);

                /*" -902- MOVE '.' TO WS-SEPARADOR. */
                _.Move(".", WS_IDENT_PAGTO_EDITADO.WS_SEPARADOR);
            }


            /*" -904- MOVE SIARDEVC-NUM-CHEQUE-INTERNO TO WS-CHEQUE-INTERNO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CHEQUE_INTERNO, WS_IDENT_PAGTO_EDITADO.WS_CHEQUE_INTERNO);

            /*" -907- MOVE WS-IDENT-PAGTO-EDITADO TO DET-IDENT-PAGTO-EDITADO */
            _.Move(WS_IDENT_PAGTO_EDITADO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_IDENT_PAGTO_EDITADO);

            /*" -909- MOVE SIARDEVC-ORDEM-PAGAMENTO-VC TO DET-NUM-OP-VC */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_ORDEM_PAGAMENTO_VC, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NUM_OP_VC);

            /*" -911- MOVE SIARDEVC-ORDEM-PAGAMENTO TO DET-NUM-OP-CXSEG */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_ORDEM_PAGAMENTO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NUM_OP_CXSEG);

            /*" -913- MOVE SIARDEVC-COD-BANCO TO DET-COD-BANCO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_BANCO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_COD_BANCO);

            /*" -915- MOVE SIARDEVC-COD-AGENCIA TO DET-COD-AGENCIA */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_AGENCIA, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_COD_AGENCIA);

            /*" -917- MOVE SIARDEVC-OPERACAO-CONTA TO DET-COD-OPERACAO-CONTA-CEF */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OPERACAO_CONTA, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_COD_OPERACAO_CONTA_CEF);

            /*" -919- MOVE SIARDEVC-COD-CONTA TO DET-NUM-CONTA-BANCARIA */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_CONTA, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NUM_CONTA_BANCARIA);

            /*" -921- MOVE SIARDEVC-DV-CONTA TO DET-DV-CONTA */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DV_CONTA, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_DV_CONTA);

            /*" -923- MOVE SIARDEVC-COD-FAVORECIDO TO DET-COD-FAVORECIDO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_FAVORECIDO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_COD_FAVORECIDO);

            /*" -927- MOVE SPACES TO DET-SERIE-CHEQUE. */
            _.Move("", REG_SCMOVSIN.SCMOVSIN_DADOS.DET_SERIE_CHEQUE);

            /*" -929- MOVE SIARDEVC-NUM-RESSARC TO DET-NUM-RESSARC */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_RESSARC, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NUM_RESSARC);

            /*" -931- MOVE SIARDEVC-IND-PESSOA-ACORDO TO DET-IND-PESSOA-ACORDO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_IND_PESSOA_ACORDO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_IND_PESSOA_ACORDO);

            /*" -933- MOVE SIARDEVC-NUM-CPFCGC-ACORDO TO DET-NUM-CPFCGC-ACORDO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CPFCGC_ACORDO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NUM_CPFCGC_ACORDO);

            /*" -935- MOVE SIARDEVC-NOM-RESP-ACORDO TO DET-NOM-RESP-ACORDO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_RESP_ACORDO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NOM_RESP_ACORDO);

            /*" -937- MOVE SIARDEVC-STA-ACORDO TO DET-STA-ACORDO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_STA_ACORDO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_STA_ACORDO);

            /*" -939- MOVE SIARDEVC-DTH-INDENIZACAO TO DET-DTH-INDENIZACAO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DTH_INDENIZACAO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_DTH_INDENIZACAO);

            /*" -941- MOVE SIARDEVC-VLR-INDENIZACAO TO DET-VLR-INDENIZACAO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VLR_INDENIZACAO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_VLR_INDENIZACAO);

            /*" -943- MOVE SIARDEVC-VLR-PART-TERCEIROS TO DET-VLR-PART-TERCEIROS */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VLR_PART_TERCEIROS, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_VLR_PART_TERCEIROS);

            /*" -945- MOVE SIARDEVC-VLR-DIVIDA TO DET-VLR-DIVIDA */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VLR_DIVIDA, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_VLR_DIVIDA);

            /*" -947- MOVE SIARDEVC-PCT-DESCONTO TO DET-PCT-DESCONTO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_PCT_DESCONTO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_PCT_DESCONTO);

            /*" -949- MOVE SIARDEVC-VLR-TOTAL-DESCONTO TO DET-VLR-TOTAL-DESCONTO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VLR_TOTAL_DESCONTO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_VLR_TOTAL_DESCONTO);

            /*" -951- MOVE SIARDEVC-VLR-TOTAL-ACORDO TO DET-VLR-TOTAL-ACORDO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VLR_TOTAL_ACORDO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_VLR_TOTAL_ACORDO);

            /*" -953- MOVE SIARDEVC-COD-MOEDA-ACORDO TO DET-COD-MOEDA-ACORDO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_MOEDA_ACORDO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_COD_MOEDA_ACORDO);

            /*" -955- MOVE SIARDEVC-DTH-ACORDO TO DET-DTH-ACORDO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DTH_ACORDO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_DTH_ACORDO);

            /*" -957- MOVE SIARDEVC-QTD-PARCELAS-ACORDO TO DET-QTD-PARCELAS-ACORDO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_QTD_PARCELAS_ACORDO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_QTD_PARCELAS_ACORDO);

            /*" -959- MOVE SIARDEVC-NUM-PARCELA-ACORDO TO DET-NUM-PARCELA-ACORDO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_PARCELA_ACORDO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NUM_PARCELA_ACORDO);

            /*" -961- MOVE SIARDEVC-COD-AGENCIA-CEDENT TO DET-COD-AGENCIA-CEDENT */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_AGENCIA_CEDENT, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_COD_AGENCIA_CEDENT);

            /*" -963- MOVE SIARDEVC-NUM-CEDENTE TO DET-NUM-CEDENTE */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CEDENTE, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NUM_CEDENTE);

            /*" -965- MOVE SIARDEVC-NUM-CEDENTE-DV TO DET-NUM-CEDENTE-DV */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CEDENTE_DV, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NUM_CEDENTE_DV);

            /*" -967- MOVE SIARDEVC-DTH-VENCIMENTO TO DET-DTH-VENCIMENTO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DTH_VENCIMENTO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_DTH_VENCIMENTO);

            /*" -970- MOVE SIARDEVC-NUM-NOSSO-TITULO TO DET-NUM-NOSSO-TITULO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_NOSSO_TITULO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NUM_NOSSO_TITULO);

            /*" -971- IF SIARDEVC-NUM-NOSSO-TITULO GREATER ZEROS */

            if (SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_NOSSO_TITULO > 00)
            {

                /*" -972- PERFORM R1210-00-CONSULTA-NN */

                R1210_00_CONSULTA_NN_SECTION();

                /*" -974- MOVE LK-GE350-NOSSO-NUMERO-SAP TO DET-NUM-NOSSO-TITULO . */
                _.Move(LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NOSSO_NUMERO_SAP, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NUM_NOSSO_TITULO);
            }


            /*" -976- MOVE SIARDEVC-VLR-TITULO TO DET-VLR-TITULO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VLR_TITULO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_VLR_TITULO);

            /*" -978- MOVE SIARDEVC-NUM-CPFCGC-RECLAMANTE TO DET-NUM-CPFCGC-RECLAMANTE */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CPFCGC_RECLAMANTE, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NUM_CPFCGC_RECLAMANTE);

            /*" -980- MOVE SIARDEVC-NOM-RECLAMANTE TO DET-NOM-RECLAMANTE */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_RECLAMANTE, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NOM_RECLAMANTE);

            /*" -982- MOVE SIARDEVC-VLR-RECLAMADO TO DET-VLR-RECLAMADO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VLR_RECLAMADO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_VLR_RECLAMADO);

            /*" -985- MOVE SIARDEVC-VLR-PROVISIONADO TO DET-VLR-PROVISIONADO. */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VLR_PROVISIONADO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_VLR_PROVISIONADO);

            /*" -987- MOVE SIARDEVC-NUM-IDENT-CONV TO DET-NUM-IDENT-CONV */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_IDENT_CONV, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NUM_IDENT_CONV);

            /*" -990- MOVE SIARDEVC-NUM-IDE-COBR-CONV TO DET-NUM-IDENT-PAGTO. */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_IDE_COBR_CONV, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NUM_IDENT_PAGTO);

            /*" -991- MOVE SIARDEVC-COD-CFOP TO DET-CFOP. */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_CFOP, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_CFOP);

            /*" -992- MOVE SIARDEVC-COD-CEST TO DET-CEST. */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_CEST, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_CEST);

            /*" -994- MOVE SIARDEVC-NUM-INSCR-ESTADUAL TO DET-INSC-EST. */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_INSCR_ESTADUAL, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_INSC_EST);

            /*" -995- MOVE SIARDEVC-NUM-NCM TO DET-NCM. */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_NCM, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_NCM);

            /*" -997- MOVE SIARDEVC-NUM-CPF-CNPJ-TOMADOR TO DET-CNPJ-FILIAL. */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_CPF_CNPJ_TOMADOR, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_CNPJ_FILIAL);

            /*" -999- MOVE SIARDEVC-IND-ISENCAO-TRIBUTO TO DET-IND-RET-IMP. */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_IND_ISENCAO_TRIBUTO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_IND_RET_IMP);

            /*" -1001- MOVE SIARDEVC-COD-IMPOSTO-LIMINAR TO DET-COD-IMP-LIM. */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_IMPOSTO_LIMINAR, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_COD_IMP_LIM);

            /*" -1003- MOVE SIARDEVC-COD-PROCESSO-ISENCAO TO DET-COD-PROC-PJDT. */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_PROCESSO_ISENCAO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_COD_PROC_PJDT);

            /*" -1007- MOVE SIARDEVC-VLR-RET-N-EFETUADO TO DET-VLR-RET-PRINC. */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_VLR_RET_N_EFETUADO, REG_SCMOVSIN.SCMOVSIN_DADOS.DET_VLR_RET_PRINC);

            /*" -1007- WRITE REG-SCMOVSIN. */
            CSPAGSIN.Write(REG_SCMOVSIN.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_00_EXIT*/

        [StopWatch]
        /*" R1210-00-CONSULTA-NN-SECTION */
        private void R1210_00_CONSULTA_NN_SECTION()
        {
            /*" -1017- MOVE 'R1210-00' TO WNR-EXEC-SQL. */
            _.Move("R1210-00", WABEND.WNR_EXEC_SQL);

            /*" -1019- ADD 01 TO AC-C-NOSSO-NUMERO */
            AC_C_NOSSO_NUMERO.Value = AC_C_NOSSO_NUMERO + 01;

            /*" -1021- INITIALIZE REGISTRO-LINKAGE-GE0350S. */
            _.Initialize(
                LBGE0350.REGISTRO_LINKAGE_GE0350S
            );

            /*" -1022- MOVE 01 TO LK-GE350-COD-FUNCAO */
            _.Move(01, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_FUNCAO);

            /*" -1023- MOVE 'SI9268B' TO LK-GE350-COD-USUARIO */
            _.Move("SI9268B", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_USUARIO);

            /*" -1024- MOVE SIARDEVC-NUM-RESSARC TO LK-GE350-NUM-PROPOSTA */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_RESSARC, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PROPOSTA);

            /*" -1025- MOVE SIARDEVC-NUM-APOL-SINISTRO TO LK-GE350-NUM-APOLICE */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE);

            /*" -1026- MOVE ZEROS TO LK-GE350-NUM-CERTIFICADO */
            _.Move(0, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_CERTIFICADO);

            /*" -1027- MOVE SIARDEVC-NUM-PARCELA-ACORDO TO LK-GE350-NUM-PARCELA */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_PARCELA_ACORDO, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA);

            /*" -1029- MOVE SIARDEVC-COD-OPERACAO TO LK-GE350-NUM-ENDOSSO */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_OPERACAO, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO);

            /*" -1031- CALL 'GE0350S' USING REGISTRO-LINKAGE-GE0350S. */
            _.Call("GE0350S", LBGE0350.REGISTRO_LINKAGE_GE0350S);

            /*" -1032- IF LK-GE350-COD-RETORNO NOT EQUAL '0' AND '3' AND '2' */

            if (!LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO.In("0", "3", "2"))
            {

                /*" -1033- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -1034- DISPLAY '*    R5101-00-CONSULTA-NN               *' */
                _.Display($"*    R5101-00-CONSULTA-NN               *");

                /*" -1035- DISPLAY '*  ERRO NA EXECUCAO DO CALL DA GE0350S  *' */
                _.Display($"*  ERRO NA EXECUCAO DO CALL DA GE0350S  *");

                /*" -1036- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -1037- DISPLAY '=> LK-MENSAGEM ... ' LK-GE350-MENSAGEM */
                _.Display($"=> LK-MENSAGEM ... {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM}");

                /*" -1038- DISPLAY '=> LK-COD-RETORNO. ' LK-GE350-COD-RETORNO */
                _.Display($"=> LK-COD-RETORNO. {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO}");

                /*" -1039- DISPLAY '=> LK-SQLCODE..... ' LK-GE350-SQLCODE */
                _.Display($"=> LK-SQLCODE..... {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_SQLCODE}");

                /*" -1040- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -1041- DISPLAY '----------- DADOS DE SAIDA GE0350S ---------- ' */
                _.Display($"----------- DADOS DE SAIDA GE0350S ---------- ");

                /*" -1042- DISPLAY '=> COD-FUNCAO       . ' LK-GE350-COD-FUNCAO */
                _.Display($"=> COD-FUNCAO       . {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_FUNCAO}");

                /*" -1043- DISPLAY '=> NUM-PROPOSTA     . ' LK-GE350-NUM-PROPOSTA */
                _.Display($"=> NUM-PROPOSTA     . {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PROPOSTA}");

                /*" -1044- DISPLAY '=> NUM-CERTIFICADO  . ' LK-GE350-NUM-CERTIFICADO */
                _.Display($"=> NUM-CERTIFICADO  . {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_CERTIFICADO}");

                /*" -1045- DISPLAY '=> NUM-PARCELA      . ' LK-GE350-NUM-PARCELA */
                _.Display($"=> NUM-PARCELA      . {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA}");

                /*" -1046- DISPLAY '=> NUM-APOLICE      . ' LK-GE350-NUM-APOLICE */
                _.Display($"=> NUM-APOLICE      . {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE}");

                /*" -1047- DISPLAY '=> NUM-ENDOSSO      . ' LK-GE350-NUM-ENDOSSO */
                _.Display($"=> NUM-ENDOSSO      . {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO}");

                /*" -1048- DISPLAY '=> SEQ-CNTRLE-SIGCB . ' LK-GE350-SEQ-CNTRLE-SIGCB */
                _.Display($"=> SEQ-CNTRLE-SIGCB . {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_SEQ_CNTRLE_SIGCB}");

                /*" -1049- DISPLAY '=> NUM-OCORR-MOVTO  . ' LK-GE350-NUM-OCORR-MOVTO */
                _.Display($"=> NUM-OCORR-MOVTO  . {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_OCORR_MOVTO}");

                /*" -1050- DISPLAY '=> NUM-IDLG         . ' LK-GE350-NUM-IDLG */
                _.Display($"=> NUM-IDLG         . {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_IDLG}");

                /*" -1051- DISPLAY '=> COD-PRODUTO      . ' LK-GE350-COD-PRODUTO */
                _.Display($"=> COD-PRODUTO      . {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_PRODUTO}");

                /*" -1052- DISPLAY '=> DTA-MOVIMENTO    . ' LK-GE350-DTA-MOVIMENTO */
                _.Display($"=> DTA-MOVIMENTO    . {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_MOVIMENTO}");

                /*" -1053- DISPLAY '=> DTA-VENCIMENTO   . ' LK-GE350-DTA-VENCIMENTO */
                _.Display($"=> DTA-VENCIMENTO   . {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_VENCIMENTO}");

                /*" -1054- DISPLAY '=> VLR-PREMIO-TOTAL . ' LK-GE350-VLR-PREMIO-TOTAL */
                _.Display($"=> VLR-PREMIO-TOTAL . {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_VLR_PREMIO_TOTAL}");

                /*" -1055- DISPLAY '=> VLR-IOF          . ' LK-GE350-VLR-IOF */
                _.Display($"=> VLR-IOF          . {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_VLR_IOF}");

                /*" -1056- DISPLAY '=> QTD-PARCELA      . ' LK-GE350-QTD-PARCELA */
                _.Display($"=> QTD-PARCELA      . {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_QTD_PARCELA}");

                /*" -1057- DISPLAY '=> QTD-DIAS-CUSTODIA. ' LK-GE350-QTD-DIAS-CUSTODIA */
                _.Display($"=> QTD-DIAS-CUSTODIA. {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_QTD_DIAS_CUSTODIA}");

                /*" -1058- DISPLAY '=> COD-CLIENTE      . ' LK-GE350-COD-CLIENTE */
                _.Display($"=> COD-CLIENTE      . {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_CLIENTE}");

                /*" -1059- DISPLAY '=> COD-CEDENTE-SAP  . ' LK-GE350-COD-CEDENTE-SAP */
                _.Display($"=> COD-CEDENTE-SAP  . {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_CEDENTE_SAP}");

                /*" -1060- DISPLAY '=> NUM-BLTO-INTERNO . ' LK-GE350-NUM-BLTO-INTERNO */
                _.Display($"=> NUM-BLTO-INTERNO . {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_BLTO_INTERNO}");

                /*" -1061- DISPLAY '=> NOSSO-NUMERO-SAP . ' LK-GE350-NOSSO-NUMERO-SAP */
                _.Display($"=> NOSSO-NUMERO-SAP . {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NOSSO_NUMERO_SAP}");

                /*" -1062- DISPLAY '=> COD-LINHA-DGTVEL . ' LK-GE350-COD-LINHA-DGTVEL */
                _.Display($"=> COD-LINHA-DGTVEL . {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_LINHA_DGTVEL}");

                /*" -1063- DISPLAY '=> NUM-TITULO       . ' LK-GE350-NUM-TITULO */
                _.Display($"=> NUM-TITULO       . {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_TITULO}");

                /*" -1064- DISPLAY '=> IDE-SISTEMA      . ' LK-GE350-IDE-SISTEMA */
                _.Display($"=> IDE-SISTEMA      . {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_IDE_SISTEMA}");

                /*" -1065- DISPLAY '=> COD-USUARIO      . ' LK-GE350-COD-USUARIO */
                _.Display($"=> COD-USUARIO      . {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_USUARIO}");

                /*" -1066- DISPLAY '=> COD-SITUACAO     . ' LK-GE350-COD-SITUACAO */
                _.Display($"=> COD-SITUACAO     . {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO}");

                /*" -1067- DISPLAY '=> DTA-VENC-CUSTODIA. ' LK-GE350-DTA-VENC-CUSTODIA */
                _.Display($"=> DTA-VENC-CUSTODIA. {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_VENC_CUSTODIA}");

                /*" -1068- DISPLAY '=> COD-REJEICAO     . ' LK-GE350-COD-REJEICAO */
                _.Display($"=> COD-REJEICAO     . {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_REJEICAO}");

                /*" -1069- DISPLAY '=> COD-RETORNO      . ' LK-GE350-COD-RETORNO */
                _.Display($"=> COD-RETORNO      . {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO}");

                /*" -1070- DISPLAY '-------------------------------------------- ' */
                _.Display($"-------------------------------------------- ");

                /*" -1071- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1072- ELSE */
            }
            else
            {


                /*" -1073- IF LK-GE350-COD-RETORNO EQUAL '3' OR '2' */

                if (LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO.In("3", "2"))
                {

                    /*" -1074- DISPLAY '*****************************************' */
                    _.Display($"*****************************************");

                    /*" -1075- DISPLAY '*    R5101-00-CONSULTA-NN               *' */
                    _.Display($"*    R5101-00-CONSULTA-NN               *");

                    /*" -1076- DISPLAY '*  ERRO NA EXECUCAO DO CALL DA GE0350S  *' */
                    _.Display($"*  ERRO NA EXECUCAO DO CALL DA GE0350S  *");

                    /*" -1077- DISPLAY '*****************************************' */
                    _.Display($"*****************************************");

                    /*" -1078- DISPLAY '=> LK-MENSAGEM ... ' LK-GE350-MENSAGEM */
                    _.Display($"=> LK-MENSAGEM ... {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM}");

                    /*" -1079- DISPLAY '=> LK-COD-RETORNO. ' LK-GE350-COD-RETORNO */
                    _.Display($"=> LK-COD-RETORNO. {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO}");

                    /*" -1080- DISPLAY '=> LK-SQLCODE..... ' LK-GE350-SQLCODE */
                    _.Display($"=> LK-SQLCODE..... {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_SQLCODE}");

                    /*" -1081- DISPLAY '=> NUM-PROPOSTA     . ' LK-GE350-NUM-PROPOSTA */
                    _.Display($"=> NUM-PROPOSTA     . {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PROPOSTA}");

                    /*" -1082- DISPLAY '=> NUM-CERTIFICADO  . ' LK-GE350-NUM-CERTIFICADO */
                    _.Display($"=> NUM-CERTIFICADO  . {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_CERTIFICADO}");

                    /*" -1083- DISPLAY '=> NUM-PARCELA      . ' LK-GE350-NUM-PARCELA */
                    _.Display($"=> NUM-PARCELA      . {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA}");

                    /*" -1084- DISPLAY '=> NUM-APOLICE      . ' LK-GE350-NUM-APOLICE */
                    _.Display($"=> NUM-APOLICE      . {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE}");

                    /*" -1085- DISPLAY '=> NUM-ENDOSSO      . ' LK-GE350-NUM-ENDOSSO */
                    _.Display($"=> NUM-ENDOSSO      . {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO}");

                    /*" -1086- DISPLAY '*****************************************' */
                    _.Display($"*****************************************");

                    /*" -1087- END-IF */
                }


                /*" -1088- END-IF. */
            }


            /*" -1088- ADD 01 TO AC-R-NOSSO-NUMERO. */
            AC_R_NOSSO_NUMERO.Value = AC_R_NOSSO_NUMERO + 01;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1210_99_SAIDA*/

        [StopWatch]
        /*" R1210-00-LE-SINISMES-SECTION */
        private void R1210_00_LE_SINISMES_SECTION()
        {
            /*" -1099- MOVE '1210' TO WNR-EXEC-SQL */
            _.Move("1210", WABEND.WNR_EXEC_SQL);

            /*" -1106- PERFORM R1210_00_LE_SINISMES_DB_SELECT_1 */

            R1210_00_LE_SINISMES_DB_SELECT_1();

            /*" -1109- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1111- MOVE ZEROS TO SINISMES-COD-FONTE SINISMES-NUM-PROTOCOLO-SINI */
                _.Move(0, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_PROTOCOLO_SINI);

                /*" -1112- ELSE */
            }
            else
            {


                /*" -1113- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1119- DISPLAY 'ERRO SELECT SINISTRO_MESTRE' ' ' SIARDEVC-NOM-ARQUIVO ' ' SIARDEVC-SEQ-GERACAO ' ' SIARDEVC-TIPO-REGISTRO ' ' SIARDEVC-SEQ-REGISTRO ' ' SIARDEVC-NUM-APOL-SINISTRO */

                    $"ERRO SELECT SINISTRO_MESTRE {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_ARQUIVO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_GERACAO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_REGISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_REGISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO}"
                    .Display();

                    /*" -1119- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1210-00-LE-SINISMES-DB-SELECT-1 */
        public void R1210_00_LE_SINISMES_DB_SELECT_1()
        {
            /*" -1106- EXEC SQL SELECT COD_FONTE, NUM_PROTOCOLO_SINI INTO :SINISMES-COD-FONTE, :SINISMES-NUM-PROTOCOLO-SINI FROM SEGUROS.SINISTRO_MESTRE WHERE NUM_APOL_SINISTRO = :SIARDEVC-NUM-APOL-SINISTRO END-EXEC. */

            var r1210_00_LE_SINISMES_DB_SELECT_1_Query1 = new R1210_00_LE_SINISMES_DB_SELECT_1_Query1()
            {
                SIARDEVC_NUM_APOL_SINISTRO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R1210_00_LE_SINISMES_DB_SELECT_1_Query1.Execute(r1210_00_LE_SINISMES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISMES_COD_FONTE, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE);
                _.Move(executed_1.SINISMES_NUM_PROTOCOLO_SINI, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_PROTOCOLO_SINI);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1210_00_EXIT*/

        [StopWatch]
        /*" R1300-00-INCLUI-SIARREVC-SECTION */
        private void R1300_00_INCLUI_SIARREVC_SECTION()
        {
            /*" -1129- MOVE '1300' TO WNR-EXEC-SQL. */
            _.Move("1300", WABEND.WNR_EXEC_SQL);

            /*" -1147- PERFORM R1300_00_INCLUI_SIARREVC_DB_INSERT_1 */

            R1300_00_INCLUI_SIARREVC_DB_INSERT_1();

            /*" -1150- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1159- DISPLAY 'PROBLEMAS NO INSERT SI_AR_RETORNO_VC' ' ' GEARDETA-NOM-ARQUIVO ' ' GEARDETA-SEQ-GERACAO ' ' SIARREVC-TIPO-REGISTRO-VC ' ' SIARREVC-SEQ-REGISTRO-VC ' ' SIARDEVC-NOM-ARQUIVO ' ' SIARDEVC-SEQ-GERACAO ' ' SIARDEVC-TIPO-REGISTRO ' ' SIARDEVC-SEQ-REGISTRO */

                $"PROBLEMAS NO INSERT SI_AR_RETORNO_VC {GEARDETA.DCLGE_AR_DETALHE.GEARDETA_NOM_ARQUIVO} {GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO} {SIARREVC.DCLSI_AR_RETORNO_VC.SIARREVC_TIPO_REGISTRO_VC} {SIARREVC.DCLSI_AR_RETORNO_VC.SIARREVC_SEQ_REGISTRO_VC} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_ARQUIVO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_GERACAO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_REGISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_REGISTRO}"
                .Display();

                /*" -1161- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1161- ADD 1 TO AC-I-SIARREVC. */
            AC_I_SIARREVC.Value = AC_I_SIARREVC + 1;

        }

        [StopWatch]
        /*" R1300-00-INCLUI-SIARREVC-DB-INSERT-1 */
        public void R1300_00_INCLUI_SIARREVC_DB_INSERT_1()
        {
            /*" -1147- EXEC SQL INSERT INTO SEGUROS.SI_AR_RETORNO_VC (NOM_ARQUIVO_VC, SEQ_GERACAO_VC, TIPO_REGISTRO_VC, SEQ_REGISTRO_VC, NOM_ARQUIVO, SEQ_GERACAO, TIPO_REGISTRO, NUM_SEQ_REG) VALUES (:GEARDETA-NOM-ARQUIVO, :GEARDETA-SEQ-GERACAO, :SIARREVC-TIPO-REGISTRO-VC, :SIARREVC-SEQ-REGISTRO-VC, :SIARDEVC-NOM-ARQUIVO, :SIARDEVC-SEQ-GERACAO, :SIARDEVC-TIPO-REGISTRO, :SIARDEVC-SEQ-REGISTRO) END-EXEC. */

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
            /*" -1171- MOVE '1400' TO WNR-EXEC-SQL */
            _.Move("1400", WABEND.WNR_EXEC_SQL);

            /*" -1181- PERFORM R1400_00_ALTERA_SIARDEVC_DB_UPDATE_1 */

            R1400_00_ALTERA_SIARDEVC_DB_UPDATE_1();

            /*" -1184- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1189- DISPLAY 'PROBLEMAS NO UPDATE SI_AR_DETALHE_VC' ' ' SIARDEVC-NOM-ARQUIVO ' ' SIARDEVC-SEQ-GERACAO ' ' SIARDEVC-TIPO-REGISTRO ' ' SIARDEVC-SEQ-REGISTRO */

                $"PROBLEMAS NO UPDATE SI_AR_DETALHE_VC {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_ARQUIVO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_GERACAO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_REGISTRO} {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_REGISTRO}"
                .Display();

                /*" -1191- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1191- ADD 1 TO AC-U-SIARDEVC. */
            AC_U_SIARDEVC.Value = AC_U_SIARDEVC + 1;

        }

        [StopWatch]
        /*" R1400-00-ALTERA-SIARDEVC-DB-UPDATE-1 */
        public void R1400_00_ALTERA_SIARDEVC_DB_UPDATE_1()
        {
            /*" -1181- EXEC SQL UPDATE SEGUROS.SI_AR_DETALHE_VC SET STA_RETORNO = '2' , STA_PROCESSAMENTO = '3' , OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO WHERE NOM_ARQUIVO = :SIARDEVC-NOM-ARQUIVO AND SEQ_GERACAO = :SIARDEVC-SEQ-GERACAO AND TIPO_REGISTRO = :SIARDEVC-TIPO-REGISTRO AND SEQ_REGISTRO = :SIARDEVC-SEQ-REGISTRO AND STA_RETORNO = '2' END-EXEC. */

            var r1400_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1 = new R1400_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1()
            {
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
                SIARDEVC_TIPO_REGISTRO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_TIPO_REGISTRO.ToString(),
                SIARDEVC_SEQ_REGISTRO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_REGISTRO.ToString(),
                SIARDEVC_NOM_ARQUIVO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NOM_ARQUIVO.ToString(),
                SIARDEVC_SEQ_GERACAO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_SEQ_GERACAO.ToString(),
            };

            R1400_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1.Execute(r1400_00_ALTERA_SIARDEVC_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1201- CLOSE CSPAGSIN */
            CSPAGSIN.Close();

            /*" -1202- DISPLAY '********************************' */
            _.Display($"********************************");

            /*" -1203- DISPLAY '*     SI9268B - CANCELADO      *' */
            _.Display($"*     SI9268B - CANCELADO      *");

            /*" -1205- DISPLAY '********************************' */
            _.Display($"********************************");

            /*" -1206- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -1208- DISPLAY WABEND */
            _.Display(WABEND);

            /*" -1208- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1212- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1216- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}