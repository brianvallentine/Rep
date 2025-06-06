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
using Sias.Emissao.DB2.EM0202B;

namespace Code
{
    public class EM0202B
    {
        public bool IsCall { get; set; }

        public EM0202B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  EM0202B                            *      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA/PROGRAMADOR....  PROCAS/PROCAS                      *      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  EMITE RECIBOS DE RESTITUICAO       *      */
        /*"      *                             ATUALIZA TABELA DE RELATORIOS      *      */
        /*"      *                             ATUALIZA TABELA DE PEDIDOS         *      */
        /*"      *                             ATUALIZA TABELA DE HISTORICOS      *      */
        /*"      *                             ATUALIZA TABELA DE PARCELAS        *      */
        /*"      *                             ATUALIZA TABELA DE ENDOSSOS        *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACOES                                                    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.23  *   VERSAO 23   - CADMUS 163382                                  *      */
        /*"      *                 TRATAMENTO DO RETORNO DO PROGRAMA GE0540S      *      */
        /*"      *                                                                *      */
        /*"      *   EM 09/05/2018                                                *      */
        /*"      *                                                                *      */
        /*"      *   LISIANE BRAGANCA SOARES             PROCURE POR V.23         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.22  *   VERSAO 22   - ACERTO DA VERSAO 15, (REJEITAR ENDOSSO         *      */
        /*"      *                 COM VENCIMENTO PROGRAMADO) QUE ESTAVA          *      */
        /*"      *                 VALIDANDO ENDOSSO ANTES DO SELECT DO ENDOSSO.  *      */
        /*"      *                 ESTE ERRO ESTAVA RECUSANDO ALGUNS ENDOSSOS     *      */
        /*"      *                 ALEATORIAMENTE (ALGUNS DA DISEF)               *      */
        /*"      *   EM 05/05/2016                                                *      */
        /*"      *                                                                *      */
        /*"      *   LUIZ GUSTAVO LOPES MELO             PROCURE POR V.22         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.21  *   VERSAO 21 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 29/06/2015 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.21         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.20  *  VERSAO 20 - CAD 107522                                        *      */
        /*"      *                                                                *      */
        /*"      *  - INIBIR A GERACAO DE CHEQUES DE ENDOSSOS DE RESTITUICOES DO  *      */
        /*"      *    PRODUTO 1409 - APOLICE 101402541679 - LAR MAIS - RD         *      */
        /*"      *                                                                *      */
        /*"      *  EM 10/12/2014 - GISELLE OLIVEIRA                              *      */
        /*"      *                                           PROCURE POR V.20     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.19  *  VERSAO 19 - CAD 106388                                        *      */
        /*"      *                                                                *      */
        /*"      *  - INIBIR A GERACAO DE CHEQUES DE ENDOSSOS DE RESTITUICOES DO  *      */
        /*"      *    PRODUTO 6802 - APOLICE 0106500000001                        *      */
        /*"      *                                                                *      */
        /*"      *  EM 10/12/2014 - GISELLE OLIVEIRA                              *      */
        /*"      *                                           PROCURE POR V.19     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.18  *  VERSAO 18 - CAD 105241                                        *      */
        /*"      *                                                                *      */
        /*"      *  - GERAR CHEQUE DE ENDOSSOS DE RESTITUICOES DO PRODUTO 6802 -  *      */
        /*"      *    APOLICE 0106500000001                                       *      */
        /*"      *                                                                *      */
        /*"      *  EM 13/11/2014 - GISELLE OLIVEIRA                              *      */
        /*"      *                                           PROCURE POR V.18     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.17  *  VERSAO 17 - CAD 97955                                         *      */
        /*"      *                                                                *      */
        /*"      *  - INIBIR A GERACAO DE CHEQUES DE ENDOSSOS DE RESTITUICOES DO  *      */
        /*"      *    PRODUTO 7716 - APOLICES 0107700000038 E 0107700000040       *      */
        /*"      *                                                                *      */
        /*"      *  EM 19/05/2014 - GISELLE OLIVEIRA                              *      */
        /*"      *                                           PROCURE POR V.17     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.16  *  VERSAO 16 - CAD 10.003                                        *      */
        /*"      *                                                                *      */
        /*"      *             - CONVERSAO DO DB2 PARA A VERSAO 10                *      */
        /*"      *                                                                *      */
        /*"      *  EM 10/09/2013 - ROGERIO PEREIRA                               *      */
        /*"      *                                                                *      */
        /*"      *                                           PROCURE POR V.16     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.15  *   COREON - 04/04/2013 - CADMUS 74582 - AUTO FACIL              *      */
        /*"      *                                                                *      */
        /*"      *   -   PARA ENDOSSOS DE RETITUICAO AUTO FACIL, ONDE O VALOR     *      */
        /*"      *       DA RESTITUICAO DEVERA SER CREDITADA EM CONTA CORRENTE    *      */
        /*"      *       OU COM EMISSAO DE CHEQUE, GERAR A TABELA CBCONDEV.       *      */
        /*"      *                                                                *      */
        /*"      *   -   REJEITAR ENDOSSO COM VENCIMENTO PROGRAMADO.              *      */
        /*"      *                                                                *      */
        /*"      *   PROCURAR POR V.15                                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.14  *   DIEGO DIAS  - 12/05/2013 - CAD 82217 - PROCURAR V.14                */
        /*"      *                                                                       */
        /*"      *       PROCESSAMENTO ESPECIAL PARA AS APOLICE/ENDOSSO ABAIXO           */
        /*"      *       FORCADA A GERACAO DO CHEQUE POR QUE ESTA COM PAGAMENTO          */
        /*"      *       DO CLIENTE INVALIDO. SER� GERADO UM FALSO CHEQUE.               */
        /*"      *                                                                       */
        /*"      *   APOLICE - 1103100161899   ENDOSSO - 1                               */
        /*"      *----------------------------------------------------------------*      */
        /*"V.13  *   ABEND 81201  ...........  EM 10/04/2013                      *      */
        /*"      *                             AO CHAMAR A SUBROTINA GE0540S      *      */
        /*"      *                             O VALOR DO CAMPO WPARM-TEMCONTA    *      */
        /*"      *                             PASSA A VALER 'S' MESMO ELA TENDO  *      */
        /*"      *                             ENTRADO COM O VALOR 'N'.           *      */
        /*"      *                                                                *      */
        /*"      *  GUILHERME CORREIA          PROCURE V.13                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.13  *   VIVIANE FONSECA 04/03/2013            PROCURAR V.13          *      */
        /*"      *                                                                *      */
        /*"      *       PROCESSAMENTO ESPECIAL PARA AS APOLICE/ENDOSSO ABAIXO    *      */
        /*"      *       FORCADA A GERACAO DO CHEQUE PARA ATENDER O CADMUS 79906. *      */
        /*"      *                                                                *      */
        /*"      *   APOLICE - 1103100121720 ENDOSSO - 2                                 */
        /*"      *----------------------------------------------------------------*      */
        /*"V.12  *   ALTERACAO ..............  EM 01/02/2013                      *      */
        /*"      *                             ACERTO NO CABECALHO POIS ALGUNS    *      */
        /*"      *                             CAMPOS ESTAO REPETIDOS GERANDO ERRO*      */
        /*"      *                             NO PROCESSAMENTO FEITO PELA GRAFICA*      */
        /*"      *                             PATRICIA SALES.                    *      */
        /*"      *                             PROCURE V.12                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.11  *   viviane fonseca   - 23/11/2012        PROCURAR V.11          *      */
        /*"      *                                                                *      */
        /*"      *      APOLICE CANCELADA POR EMISSAO INDEVIDA, NOVA APOLICE FOI  *      */
        /*"      *      GERADA, RESTITUICAO NAO DEVE SER CREDITADA.               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.10  *   JEFFERSON OLIV- 16/11/2012            PROCURAR V.10          *      */
        /*"      *                                                                *      */
        /*"      *       NAO EMITIR CHEQUE PARA O PRODUTO 7705 - SIAPX DO EFP     *      */
        /*"      *       E 7712 - MIN. DO EXERCITO. CADMUS 76404                  *      */
        /*"      *       EXISTE O PRODUTO 7705 NO SIAS, TAMBEM - TE LIGO          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.09  *   GUILHERME CORREIA - 09/11/2012        PROCURAR V.09          *      */
        /*"      *                                                                *      */
        /*"      *      APOLICE CANCELADA POR EMISSAO INDEVIDA, NOVA APOLICE FOI  *      */
        /*"      *      GERADA, RESTITUICAO NAO DEVE SER CREDITADA.               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.08  *   JEFFERSON OLIV- 27/09/2012            PROCURAR V.08          *      */
        /*"      *                                                                *      */
        /*"      *       NAO EMITIR CHEQUE PARA OS PRODUTOS 7711 E 1408 DO        *      */
        /*"      *       APORTE CAIXA - CADMUS 74706                              *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.07  *   RILDO SICO    - 10/09/2012            PROCURAR V.07          *      */
        /*"      *                                                                *      */
        /*"      *       PROCESSAMENTO ESPECIAL PARA AS APOLICE/ENDOSSO ABAIXO    *      */
        /*"      *       FORCADA A GERACAO DO CHEQUE PARA ATENDER O CADMUS 73481. *      */
        /*"      *                                                                *      */
        /*"      *   APOLICE - 1103100100698 ENDOSSO - 1                                 */
        /*"      *----------------------------------------------------------------*      */
        /*"V.06  *   COREON - 03/01/2012 - CADMUS 65243 - SAC 1112                *      */
        /*"      *                                                                *      */
        /*"      *       VERIFICAR SE A BASE DE PESSOAS E ODS FOI GERADO PARA     *      */
        /*"      *       PAGAMENTOS COM CREDITO EM CONTA, EVITANDO DUPLICIDADE    *      */
        /*"      *       NO CALL DA GE0540S.                                      *      */
        /*"      *                                                                *      */
        /*"      *   PROCURAR POR V.06                                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.05  *   COREON - 29/12/2011 - CADMUS 65192 - SAC 1108                *      */
        /*"      *                                                                *      */
        /*"      *       ALTERACAO DO SELECT NA TABELA OD_PESS_CONTA_BANC         *      */
        /*"      *                                                                *      */
        /*"      *   PROCURAR POR V.05                                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.04  *   COREON - 09/12/2011 - CADMUS 64154 - SAC 1075                *      */
        /*"      *                                                                *      */
        /*"      *       PARA ENDOSSOS DE RETITUICAO SUL AMERICA, ONDE O VALOR    *      */
        /*"      *       DA RESTITUICAO DEVERA SER CREDITADA EM CONTA CORRENTE    *      */
        /*"      *       OU COM EMISSAO DE CHEQUE, GERAR A TABELA CBCONDEV.       *      */
        /*"      *                                                                *      */
        /*"      *   PROCURAR POR V.04                                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.03  *   HEIDER COELHO - 21/10/2011            PROCURAR V.03          *      */
        /*"      *                                                                *      */
        /*"      *       PROCESSAMENTO ESPECIAL PARA AS APOLICE/ENDOSSO ABAIXO    *      */
        /*"      *       FORCADA A GERACAO DO CHEQUE POR QUE ESTA COM PROBLEMA    *      */
        /*"      *       DE OUVIDORIA E A CONTA CORRENTE DA EMISSAO ESTA INVALIDA *      */
        /*"      *       EM CASO DE DUVIA LER A MOVDEBCC PARA ESTAS APOLICE/ENDOSSO      */
        /*"      *                                                                *      */
        /*"      *   APOLICE - 1003100658239 ENDOSSO - 1                                 */
        /*"      *   APOLICE - 1003100702761 ENDOSSO - 2                                 */
        /*"      *----------------------------------------------------------------*      */
        /*"V.02  *   ALTERACAO ..............  EM 12/09/2008 - CLOVIS - V.02      *      */
        /*"      *                             CADMUS 12850/2008                  *      */
        /*"      *                             ABEND DA ROTINA EM 01/08/2008      *      */
        /*"      *                             ALTERA PARAGRAFO R0800 MUDANDO     *      */
        /*"      *                             SELECT DE V1EMISDIARIA PARA        *      */
        /*"      *                             TABELA EMISSAO_DIARIA BUSCANDO     *      */
        /*"      *                             AS SOLICITACOES PENDENTES SEM A    *      */
        /*"      *                             DATA DO MOVIMENTO.                 *      */
        /*"      *                                                                *      */
        /*"      *                             INIBE O PARAGRAFO R1400 E CRIA     *      */
        /*"      *                             O R1410 BUSCANDO O NOME DO         *      */
        /*"      *                             SEGURADO NA TABELA APOLICE.        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO ..............  EM 17/03/2008                      *      */
        /*"      *                             PROJETO REDUCAO DE CHEQUES         *      */
        /*"      *                             CHAMA SUBROTINA GE0540S PARA       *      */
        /*"      *                             VERIFICAR EXISTENCIA DE CONTA.     *      */
        /*"      *                             SE CONTA VALIDA O SISTEMA GERA     *      */
        /*"      *                             CREDITO EM CONTA CORRENTE POR MEIO *      */
        /*"      *                             DO CONVENIO 900662 E INIBE A       *      */
        /*"      *                             EMISSAO DE CHEQUE.                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 15/10/2010 - CAD 47494/2010 - CIRCULAR 395            *      */
        /*"      *               SUPORTAR O NOVO RAMO DE COMERCIALIZA��O DO       *      */
        /*"      *               HABITACIONAL, FORA DO SFH; SUPORTAR O NOVO       *      */
        /*"      *               RAMO DE COMERCIALIZA��O DO SEGURO GARANTIA       *      */
        /*"      *               CONSTRUTOR - SETOR P�BLICO E PRIVADO E SU-       *      */
        /*"      *               PORTAR NOVOS PRODUTOS QUE SER�O CRIADOS NO       *      */
        /*"      *               RAMO 48 DOS CONTRATOS DO CONS�RCIO.              *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  PROJAUTO - SULAMERICA - BRSEG - 01/06/2011                    *      */
        /*"      *           - INCLUSAO ORGAO 110                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * BARD 19/09/2011 - GERA ARQUIVO EM BRANCO SE NAO HOUVER DADOS   *      */
        /*"      *                   VALIDOS (NAO IMPRIME CARACTERES DE CONTROLE) *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * BARD 27/12/2011 - INCLUI COD.PRODUTO NO INICIO DO REGISTRO DE  *      */
        /*"      *                   SAIDA - CADMUS 64781                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * IMPRESSAO SAM                PRODEXTER(VANDO)     AGOSTO/2002  *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _EM0202M01 { get; set; } = new FileBasis(new PIC("X", "339", "X(339)"));

        public FileBasis EM0202M01
        {
            get
            {
                _.Move(REG_EM0202M01, _EM0202M01); VarBasis.RedefinePassValue(REG_EM0202M01, _EM0202M01, REG_EM0202M01); return _EM0202M01;
            }
        }
        /*"01  REG-EM0202M01               PIC  X(339).*/
        public StringBasis REG_EM0202M01 { get; set; } = new StringBasis(new PIC("X", "339", "X(339)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  FILLER                    PIC X(001) VALUE SPACES.*/

        public SelectorBasis FILLER_0 { get; set; } = new SelectorBasis("001", "SPACES")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88  W88-CONTROLE-ON                    VALUE '0'. */
							new SelectorItemBasis("W88_CONTROLE_ON", "0"),
							/*" 88  W88-CONTROLE-OFF                   VALUE '1'. */
							new SelectorItemBasis("W88_CONTROLE_OFF", "1")
                }
        };

        /*"77          VIND-DTCANCEL     PIC S9(004)      COMP.*/
        public IntBasis VIND_DTCANCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          VIND-CODUSU       PIC S9(004)      COMP.*/
        public IntBasis VIND_CODUSU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1EDIA-CODRELAT   PIC  X(008).*/
        public StringBasis V1EDIA_CODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77          V1EDIA-NUM-APOL   PIC S9(013)      COMP-3.*/
        public IntBasis V1EDIA_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V1EDIA-NRENDOS    PIC S9(009)      COMP.*/
        public IntBasis V1EDIA_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V1EDIA-NRPARCEL   PIC S9(004)      COMP.*/
        public IntBasis V1EDIA_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1EDIA-DTMOVTO    PIC  X(010).*/
        public StringBasis V1EDIA_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V1EDIA-ORGAO      PIC S9(004)      COMP.*/
        public IntBasis V1EDIA_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1EDIA-RAMO       PIC S9(004)      COMP.*/
        public IntBasis V1EDIA_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1EDIA-FONTE      PIC S9(004)      COMP.*/
        public IntBasis V1EDIA_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1EDIA-CONGENER   PIC S9(004)      COMP.*/
        public IntBasis V1EDIA_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1EDIA-CODCORR    PIC S9(009)      COMP.*/
        public IntBasis V1EDIA_CODCORR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V1EDIA-SITUACAO   PIC  X(001).*/
        public StringBasis V1EDIA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V1EDIA-COD-EMP    PIC S9(004)      COMP.*/
        public IntBasis V1EDIA_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1RELA-NUM-APOL   PIC S9(013)      COMP-3.*/
        public IntBasis V1RELA_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V1RELA-NRENDOS    PIC S9(009)      COMP.*/
        public IntBasis V1RELA_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V1RELA-ORGAO      PIC S9(004)      COMP.*/
        public IntBasis V1RELA_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1RELA-RAMO       PIC S9(004)      COMP.*/
        public IntBasis V1RELA_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1RELA-FONTE      PIC S9(004)      COMP.*/
        public IntBasis V1RELA_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1RELA-CODPDT     PIC S9(009)      COMP.*/
        public IntBasis V1RELA_CODPDT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V1APOL-NOME       PIC  X(040).*/
        public StringBasis V1APOL_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77          V1APOL-CODCLIEN   PIC S9(009)      COMP.*/
        public IntBasis V1APOL_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V1ENDO-TIPO-END   PIC  X(001).*/
        public StringBasis V1ENDO_TIPO_END { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V1ENDO-RAMO       PIC S9(004)      COMP.*/
        public IntBasis V1ENDO_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1ENDO-CODPRODU   PIC S9(004)      COMP.*/
        public IntBasis V1ENDO_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1ENDO-OCORREND   PIC S9(004)      COMP.*/
        public IntBasis V1ENDO_OCORREND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1FONT-NOMEFTE    PIC  X(040).*/
        public StringBasis V1FONT_NOMEFTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77          V1FONT-CIDADE     PIC  X(020).*/
        public StringBasis V1FONT_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"77          V1HIST-NUM-APOL   PIC S9(013)      COMP-3.*/
        public IntBasis V1HIST_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V1HIST-NRENDOS    PIC S9(009)      COMP.*/
        public IntBasis V1HIST_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V1HIST-NRPARCEL   PIC S9(004)      COMP.*/
        public IntBasis V1HIST_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1HIST-DACPARC    PIC  X(001).*/
        public StringBasis V1HIST_DACPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V1HIST-DTMOVTO    PIC  X(010).*/
        public StringBasis V1HIST_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V1HIST-OPERACAO   PIC S9(004)      COMP.*/
        public IntBasis V1HIST_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1HIST-OCORHIST   PIC S9(004)      COMP.*/
        public IntBasis V1HIST_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1HIST-PRM-TARIF  PIC S9(13)V99    COMP-3.*/
        public DoubleBasis V1HIST_PRM_TARIF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77          V1HIST-DESCONTO   PIC S9(13)V99    COMP-3.*/
        public DoubleBasis V1HIST_DESCONTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77          V1HIST-VLPRMLIQ   PIC S9(13)V99    COMP-3.*/
        public DoubleBasis V1HIST_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77          V1HIST-VLADIFRA   PIC S9(13)V99    COMP-3.*/
        public DoubleBasis V1HIST_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77          V1HIST-VLCUSEMI   PIC S9(13)V99    COMP-3.*/
        public DoubleBasis V1HIST_VLCUSEMI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77          V1HIST-VLIOCC     PIC S9(13)V99    COMP-3.*/
        public DoubleBasis V1HIST_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77          V1HIST-VLPRMTOT   PIC S9(13)V99    COMP-3.*/
        public DoubleBasis V1HIST_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77          V1HIST-VLPREMIO   PIC S9(13)V99    COMP-3.*/
        public DoubleBasis V1HIST_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77          V1HIST-DTVENCTO   PIC  X(010).*/
        public StringBasis V1HIST_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V1HIST-BCOCOBR    PIC S9(004)      COMP.*/
        public IntBasis V1HIST_BCOCOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1HIST-AGECOBR    PIC S9(004)      COMP.*/
        public IntBasis V1HIST_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1HIST-NRAVISO    PIC S9(009)      COMP.*/
        public IntBasis V1HIST_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V1HIST-NRENDOCA   PIC S9(009)      COMP.*/
        public IntBasis V1HIST_NRENDOCA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V1HIST-SITCONTB   PIC  X(001).*/
        public StringBasis V1HIST_SITCONTB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V1HIST-USUARIO    PIC  X(008).*/
        public StringBasis V1HIST_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77          V1HIST-RNUDOC     PIC S9(009)      COMP.*/
        public IntBasis V1HIST_RNUDOC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V1HIST-DTQITBCO   PIC  X(010).*/
        public StringBasis V1HIST_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V1HIST-EMPRESA    PIC S9(009)      COMP.*/
        public IntBasis V1HIST_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V0HIST-PRM-TARIF  PIC S9(13)V99    COMP-3.*/
        public DoubleBasis V0HIST_PRM_TARIF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77          V0HIST-DESCONTO   PIC S9(13)V99    COMP-3.*/
        public DoubleBasis V0HIST_DESCONTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77          V0HIST-VLPRMLIQ   PIC S9(13)V99    COMP-3.*/
        public DoubleBasis V0HIST_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77          V0HIST-VLADIFRA   PIC S9(13)V99    COMP-3.*/
        public DoubleBasis V0HIST_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77          V0HIST-VLCUSEMI   PIC S9(13)V99    COMP-3.*/
        public DoubleBasis V0HIST_VLCUSEMI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77          V0HIST-VLIOCC     PIC S9(13)V99    COMP-3.*/
        public DoubleBasis V0HIST_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77          V0HIST-VLPRMTOT   PIC S9(13)V99    COMP-3.*/
        public DoubleBasis V0HIST_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77          V2HIST-PRM-TARIF  PIC S9(13)V99    COMP-3.*/
        public DoubleBasis V2HIST_PRM_TARIF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77          V2HIST-DESCONTO   PIC S9(13)V99    COMP-3.*/
        public DoubleBasis V2HIST_DESCONTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77          V2HIST-VLPRMLIQ   PIC S9(13)V99    COMP-3.*/
        public DoubleBasis V2HIST_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77          V2HIST-VLADIFRA   PIC S9(13)V99    COMP-3.*/
        public DoubleBasis V2HIST_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77          V2HIST-VLCUSEMI   PIC S9(13)V99    COMP-3.*/
        public DoubleBasis V2HIST_VLCUSEMI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77          V2HIST-VLIOCC     PIC S9(13)V99    COMP-3.*/
        public DoubleBasis V2HIST_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77          V2HIST-VLPRMTOT   PIC S9(13)V99    COMP-3.*/
        public DoubleBasis V2HIST_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77          V2HIST-VLPREMIO   PIC S9(13)V99    COMP-3.*/
        public DoubleBasis V2HIST_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77          V1PARC-OCORHIST   PIC S9(004)      COMP.*/
        public IntBasis V1PARC_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0CHEQ-TPMOVTO    PIC  X(001).*/
        public StringBasis V0CHEQ_TPMOVTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V0CHEQ-FONTE      PIC S9(004)         COMP.*/
        public IntBasis V0CHEQ_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0CHEQ-NUMDOC     PIC  X(018).*/
        public StringBasis V0CHEQ_NUMDOC { get; set; } = new StringBasis(new PIC("X", "18", "X(018)."), @"");
        /*"77          V0CHEQ-NOMFAV     PIC  X(040).*/
        public StringBasis V0CHEQ_NOMFAV { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77          V0CHEQ-VALCHQ     PIC S9(013)V99      COMP-3.*/
        public DoubleBasis V0CHEQ_VALCHQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V0CHEQ-DTMOVTO    PIC  X(010).*/
        public StringBasis V0CHEQ_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V0CHEQ-DTEMIS     PIC  X(010).*/
        public StringBasis V0CHEQ_DTEMIS { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V0CHEQ-CHQINT     PIC S9(009)         COMP.*/
        public IntBasis V0CHEQ_CHQINT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V0CHEQ-DIGINT     PIC S9(004)         COMP.*/
        public IntBasis V0CHEQ_DIGINT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0CHEQ-SITUACAO   PIC  X(001).*/
        public StringBasis V0CHEQ_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V0CHEQ-TIPPAG     PIC  X(001).*/
        public StringBasis V0CHEQ_TIPPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V0CHEQ-DATCMP     PIC  X(010).*/
        public StringBasis V0CHEQ_DATCMP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V0CHEQ-PRAPAG     PIC  X(020).*/
        public StringBasis V0CHEQ_PRAPAG { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"77          V0CHEQ-NUMREC     PIC S9(009)         COMP.*/
        public IntBasis V0CHEQ_NUMREC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V0CHEQ-OCORHIST   PIC S9(004)         COMP.*/
        public IntBasis V0CHEQ_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0CHEQ-OPERACAO   PIC S9(004)         COMP.*/
        public IntBasis V0CHEQ_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0CHEQ-CODDSA     PIC S9(004)         COMP.*/
        public IntBasis V0CHEQ_CODDSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0CHEQ-VALIRF     PIC S9(013)V99      COMP-3.*/
        public DoubleBasis V0CHEQ_VALIRF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V0CHEQ-VALISS     PIC S9(013)V99      COMP-3.*/
        public DoubleBasis V0CHEQ_VALISS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V0CHEQ-VALIAP     PIC S9(013)V99      COMP-3.*/
        public DoubleBasis V0CHEQ_VALIAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V0CHEQ-CODLAN     PIC S9(004)         COMP.*/
        public IntBasis V0CHEQ_CODLAN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0CHEQ-DATLAN     PIC  X(010).*/
        public StringBasis V0CHEQ_DATLAN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V0CHEQ-EMPRESA    PIC S9(009)         COMP.*/
        public IntBasis V0CHEQ_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V0CHEQ-CODFAV     PIC S9(009)         COMP.*/
        public IntBasis V0CHEQ_CODFAV { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V0CHEQ-VALINSS    PIC S9(013)V99      COMP-3.*/
        public DoubleBasis V0CHEQ_VALINSS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          V0HCHE-CHQINT     PIC S9(009)         COMP.*/
        public IntBasis V0HCHE_CHQINT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V0HCHE-DIGINT     PIC S9(004)         COMP.*/
        public IntBasis V0HCHE_DIGINT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0HCHE-DTMOVTO    PIC  X(010).*/
        public StringBasis V0HCHE_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V0HCHE-HORAOPER   PIC  X(008).*/
        public StringBasis V0HCHE_HORAOPER { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77          V0HCHE-OPERACAO   PIC S9(004)         COMP.*/
        public IntBasis V0HCHE_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0HCHE-EMPRESA    PIC S9(009)         COMP.*/
        public IntBasis V0HCHE_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V1SIST-DTMOVABE     PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V1SIST-DTMOVABE-FI  PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE_FI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V1SIST-HRMOVABE     PIC  X(008).*/
        public StringBasis V1SIST_HRMOVABE { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"01              W.*/
        public EM0202B_W W { get; set; } = new EM0202B_W();
        public class EM0202B_W : VarBasis
        {
            /*"  03            LBWFI01-REGISTRO.*/
            public EM0202B_LBWFI01_REGISTRO LBWFI01_REGISTRO { get; set; } = new EM0202B_LBWFI01_REGISTRO();
            public class EM0202B_LBWFI01_REGISTRO : VarBasis
            {
                /*"    05          FILLER              PIC  X(332)  VALUE               'PRODUTO|ENDOSSO|ORGAO|APOLICE|DATA|SEGURADO|VALOR               '|DESCRICAO-VALOR1|DESCRICAO-VALOR2|LOCAL|CHEQUE'*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "332", "X(332)"), @"PRODUTO|ENDOSSO|ORGAO|APOLICE|DATA|SEGURADO|VALOR               ");
                /*"  03            LBFFI01-REGISTRO.*/
            }
            public EM0202B_LBFFI01_REGISTRO LBFFI01_REGISTRO { get; set; } = new EM0202B_LBFFI01_REGISTRO();
            public class EM0202B_LBFFI01_REGISTRO : VarBasis
            {
                /*"    05          LBFFI01-PRODUTO     PIC  9(004)  VALUE  ZEROS.*/
                public IntBasis LBFFI01_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    05          LBFFI01-SEPARA01    PIC  X(001)  VALUE '|'.*/
                public StringBasis LBFFI01_SEPARA01 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    05          LBFFI01-ENDOSSO     PIC  9(009)  VALUE  ZEROS.*/
                public IntBasis LBFFI01_ENDOSSO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
                /*"    05          LBFFI01-SEPARA02    PIC  X(001)  VALUE '|'.*/
                public StringBasis LBFFI01_SEPARA02 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    05          LBFFI01-ORGAO       PIC  X(040)  VALUE  SPACES.*/
                public StringBasis LBFFI01_ORGAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05          LBFFI01-SEPARA03    PIC  X(001)  VALUE '|'.*/
                public StringBasis LBFFI01_SEPARA03 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    05          LBFFI01-APOLICE     PIC  9(013)  VALUE  ZEROS.*/
                public IntBasis LBFFI01_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
                /*"    05          LBFFI01-SEPARA04    PIC  X(001)  VALUE '|'.*/
                public StringBasis LBFFI01_SEPARA04 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    05          LBFFI01-DATA        PIC  X(010)  VALUE  SPACES.*/
                public StringBasis LBFFI01_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    05          LBFFI01-SEPARA05    PIC  X(001)  VALUE '|'.*/
                public StringBasis LBFFI01_SEPARA05 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    05          LBFFI01-SEGURADO    PIC  X(040)  VALUE  SPACES.*/
                public StringBasis LBFFI01_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05          LBFFI01-SEPARA06    PIC  X(001)  VALUE '|'.*/
                public StringBasis LBFFI01_SEPARA06 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    05          LBFFI01-VALOR       PIC  X(018)  VALUE  SPACES.*/
                public StringBasis LBFFI01_VALOR { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"");
                /*"    05          LBFFI01-SEPARA07    PIC  X(001)  VALUE '|'.*/
                public StringBasis LBFFI01_SEPARA07 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    05          LBFFI01-EXTENSO1    PIC  X(050)  VALUE  SPACES.*/
                public StringBasis LBFFI01_EXTENSO1 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
                /*"    05          LBFFI01-SEPARA08    PIC  X(001)  VALUE '|'.*/
                public StringBasis LBFFI01_SEPARA08 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    05          LBFFI01-EXTENSO2    PIC  X(120)  VALUE  SPACES.*/
                public StringBasis LBFFI01_EXTENSO2 { get; set; } = new StringBasis(new PIC("X", "120", "X(120)"), @"");
                /*"    05          LBFFI01-SEPARA09    PIC  X(001)  VALUE '|'.*/
                public StringBasis LBFFI01_SEPARA09 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    05          LBFFI01-LOCAL       PIC  X(020)  VALUE  SPACES.*/
                public StringBasis LBFFI01_LOCAL { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                /*"  03            LC00.*/
            }
            public EM0202B_LC00 LC00 { get; set; } = new EM0202B_LC00();
            public class EM0202B_LC00 : VarBasis
            {
                /*"    05          LC00-CANAL          PIC  X(002)  VALUE SPACES.*/
                public StringBasis LC00_CANAL { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    05          LC00-LINHA          PIC  X(163)  VALUE SPACES.*/
                public StringBasis LC00_LINHA { get; set; } = new StringBasis(new PIC("X", "163", "X(163)"), @"");
                /*"  03            LC01-01.*/
            }
            public EM0202B_LC01_01 LC01_01 { get; set; } = new EM0202B_LC01_01();
            public class EM0202B_LC01_01 : VarBasis
            {
                /*"    05          LC01-CANAL-1    PIC  X(002) VALUE '11'.*/
                public StringBasis LC01_CANAL_1 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"11");
                /*"    05          FILLER          PIC  X(074) VALUE SPACES.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "74", "X(074)"), @"");
                /*"  03            LC01.*/
            }
            public EM0202B_LC01 LC01 { get; set; } = new EM0202B_LC01();
            public class EM0202B_LC01 : VarBasis
            {
                /*"    05          LC01-CANAL1     PIC  9(001) VALUE 2.*/
                public IntBasis LC01_CANAL1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"), 2);
                /*"    05          LC01-CANAL2     PIC  X(001) VALUE '1'.*/
                public StringBasis LC01_CANAL2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"    05          FILLER          PIC  X(072) VALUE SPACES.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "72", "X(072)"), @"");
                /*"    05          LC01-ENDOSSO    PIC  9(006) VALUE ZEROS.*/
                public IntBasis LC01_ENDOSSO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
                /*"    05          FILLER          PIC  X(003) VALUE SPACES.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"  03            LC02.*/
            }
            public EM0202B_LC02 LC02 { get; set; } = new EM0202B_LC02();
            public class EM0202B_LC02 : VarBasis
            {
                /*"    05          LC02-CANAL1     PIC  9(001) VALUE 2.*/
                public IntBasis LC02_CANAL1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"), 2);
                /*"    05          LC02-CANAL2     PIC  X(001) VALUE '1'.*/
                public StringBasis LC02_CANAL2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"    05          FILLER          PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          LC02-ORGAOEX    PIC  X(048) VALUE SPACES.*/
                public StringBasis LC02_ORGAOEX { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"");
                /*"    05          FILLER          PIC  X(010) VALUE SPACES.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    05          LC02-NUM-APOL   PIC  9(013) VALUE ZEROS.*/
                public IntBasis LC02_NUM_APOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
                /*"    05          FILLER          PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          LC02-DTEMIS     PIC  X(010).*/
                public StringBasis LC02_DTEMIS { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"  03            LC03.*/
            }
            public EM0202B_LC03 LC03 { get; set; } = new EM0202B_LC03();
            public class EM0202B_LC03 : VarBasis
            {
                /*"    05          LC03-CANAL1     PIC  9(001) VALUE 2.*/
                public IntBasis LC03_CANAL1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"), 2);
                /*"    05          LC03-CANAL2     PIC  X(001) VALUE '1'.*/
                public StringBasis LC03_CANAL2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"    05          FILLER          PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          LC03-SEGURADO   PIC  X(040) VALUE SPACES.*/
                public StringBasis LC03_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"  03            LC04.*/
            }
            public EM0202B_LC04 LC04 { get; set; } = new EM0202B_LC04();
            public class EM0202B_LC04 : VarBasis
            {
                /*"    05          LC04-CANAL1     PIC  9(001) VALUE 2.*/
                public IntBasis LC04_CANAL1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"), 2);
                /*"    05          LC04-CANAL2     PIC  X(001) VALUE '1'.*/
                public StringBasis LC04_CANAL2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"    05          FILLER          PIC  X(054) VALUE SPACES.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "54", "X(054)"), @"");
                /*"    05          FILLER          .*/
                public EM0202B_FILLER_10 FILLER_10 { get; set; } = new EM0202B_FILLER_10();
                public class EM0202B_FILLER_10 : VarBasis
                {
                    /*"      07        LC04-VLPRMLIQ   PIC  ZZZ.ZZZ.ZZZ.ZZ9,99                 VALUE '99999999999999'.*/
                    public DoubleBasis LC04_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("9", "12", "ZZZ.ZZZ.ZZZ.ZZ9V99"), 2, 99999999999999);
                    /*"      07        LC04-VLPRMOTN   REDEFINES LC04-VLPRMLIQ                                PIC  ZZZZ.ZZZ.ZZ9,99999.*/
                    private _REDEF_DoubleBasis _lc04_vlprmotn { get; set; }
                    public _REDEF_DoubleBasis LC04_VLPRMOTN
                    {
                        get { _lc04_vlprmotn = new _REDEF_DoubleBasis(new PIC("9", "ZZZZ.ZZZ.ZZ9,99999", "ZZZZ.ZZZ.ZZ9V99999."), 5); ; _.Move(LC04_VLPRMLIQ, _lc04_vlprmotn); VarBasis.RedefinePassValue(LC04_VLPRMLIQ, _lc04_vlprmotn, LC04_VLPRMLIQ); _lc04_vlprmotn.ValueChanged += () => { _.Move(_lc04_vlprmotn, LC04_VLPRMLIQ); }; return _lc04_vlprmotn; }
                        set { VarBasis.RedefinePassValue(value, _lc04_vlprmotn, LC04_VLPRMLIQ); }
                    }  //Redefines
                    /*"    05          FILLER          PIC  X(003) VALUE SPACES.*/
                }
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    05          LC04-EXT1       PIC  X(050) VALUE SPACES.*/
                public StringBasis LC04_EXT1 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
                /*"    05          FILLER          PIC  X(002) VALUE SPACES.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"  03            LC05.*/
            }
            public EM0202B_LC05 LC05 { get; set; } = new EM0202B_LC05();
            public class EM0202B_LC05 : VarBasis
            {
                /*"    05          LC05-CANAL      PIC  X(002) VALUE ' 1'.*/
                public StringBasis LC05_CANAL { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" 1");
                /*"    05          FILLER          PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          LC05-EXT2       PIC  X(120) VALUE SPACES.*/
                public StringBasis LC05_EXT2 { get; set; } = new StringBasis(new PIC("X", "120", "X(120)"), @"");
                /*"    05          FILLER          PIC  X(003) VALUE SPACES.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"  03            LC06.*/
            }
            public EM0202B_LC06 LC06 { get; set; } = new EM0202B_LC06();
            public class EM0202B_LC06 : VarBasis
            {
                /*"    05          LC06-CANAL      PIC  X(002) VALUE ' 1'.*/
                public StringBasis LC06_CANAL { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" 1");
                /*"    05          FILLER          PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          LC06-EXT3       PIC  X(001) VALUE SPACES.*/
                public StringBasis LC06_EXT3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          FILLER          PIC  X(003) VALUE SPACES.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"  03            LC07.*/
            }
            public EM0202B_LC07 LC07 { get; set; } = new EM0202B_LC07();
            public class EM0202B_LC07 : VarBasis
            {
                /*"    05          LC07-CANAL1     PIC  9(001) VALUE 2.*/
                public IntBasis LC07_CANAL1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"), 2);
                /*"    05          LC07-CANAL2     PIC  X(001) VALUE '1'.*/
                public StringBasis LC07_CANAL2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"    05          FILLER          PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05          LC07-LOCAL      PIC  X(020) VALUE SPACES.*/
                public StringBasis LC07_LOCAL { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                /*"  03            WEXTENSO.*/
            }
            public EM0202B_WEXTENSO WEXTENSO { get; set; } = new EM0202B_WEXTENSO();
            public class EM0202B_WEXTENSO : VarBasis
            {
                /*"    05          WEXTENSO1       PIC  X(050) VALUE SPACES.*/
                public StringBasis WEXTENSO1 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
                /*"    05          WEXTENSO2       PIC  X(120) VALUE SPACES.*/
                public StringBasis WEXTENSO2 { get; set; } = new StringBasis(new PIC("X", "120", "X(120)"), @"");
                /*"    05          WEXTENSO3       PIC  X(001) VALUE SPACES.*/
                public StringBasis WEXTENSO3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"  03            WERRO           PIC  S9(009)      VALUE ZEROS.*/
            }
            public IntBasis WERRO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03            WS-CT-CHEQUES   PIC  9(005)      VALUE ZEROS.*/
            public IntBasis WS_CT_CHEQUES { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  03            WS-CT-RECIBOS   PIC  9(005)      VALUE ZEROS.*/
            public IntBasis WS_CT_RECIBOS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  03            WFIM-TRELAT     PIC  X(001)      VALUE  SPACES.*/
            public StringBasis WFIM_TRELAT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03            WFIM-SISTEMA    PIC  X(001)      VALUE  SPACES.*/
            public StringBasis WFIM_SISTEMA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03            WFIM-V1RELATORIOS PIC X(01)      VALUE  SPACES.*/
            public StringBasis WFIM_V1RELATORIOS { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"  03            FLAG-ERRO       PIC X(01)        VALUE  SPACES.*/
            public StringBasis FLAG_ERRO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"  03            IND             PIC 9(001)       VALUE  2.*/
            public IntBasis IND { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"), 2);
            /*"  03            WS-NRSEQ        PIC 9(009)       VALUE ZEROS.*/
            public IntBasis WS_NRSEQ { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03            WS-CT-CBCONCC   PIC  9(005)      VALUE ZEROS.*/
            public IntBasis WS_CT_CBCONCC { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  03            WS-CT-CBCONCH   PIC  9(005)      VALUE ZEROS.*/
            public IntBasis WS_CT_CBCONCH { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  03            WS-GERACHEQUE   PIC  X(001)      VALUE SPACES.*/
            public StringBasis WS_GERACHEQUE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03            WTEM-CB041      PIC  X(001)      VALUE SPACES.*/
            public StringBasis WTEM_CB041 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03            WVALOR          PIC S9(015)V99   COMP-3.*/
            public DoubleBasis WVALOR { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
            /*"  03            WRESPOSTA       PIC  X(004).*/
            public StringBasis WRESPOSTA { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
            /*"  03            WAREA-1.*/
            public EM0202B_WAREA_1 WAREA_1 { get; set; } = new EM0202B_WAREA_1();
            public class EM0202B_WAREA_1 : VarBasis
            {
                /*"    05          WTAM-1          PIC  9(003) VALUE 50.*/
                public IntBasis WTAM_1 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"), 50);
                /*"    05          WAREA-1A        PIC  X(050).*/
                public StringBasis WAREA_1A { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
                /*"  03            WAREA-2.*/
            }
            public EM0202B_WAREA_2 WAREA_2 { get; set; } = new EM0202B_WAREA_2();
            public class EM0202B_WAREA_2 : VarBasis
            {
                /*"    05          WTAM-2          PIC  9(003) VALUE 120.*/
                public IntBasis WTAM_2 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"), 120);
                /*"    05          WAREA-2A        PIC  X(120).*/
                public StringBasis WAREA_2A { get; set; } = new StringBasis(new PIC("X", "120", "X(120)."), @"");
                /*"  03            WAREA-3.*/
            }
            public EM0202B_WAREA_3 WAREA_3 { get; set; } = new EM0202B_WAREA_3();
            public class EM0202B_WAREA_3 : VarBasis
            {
                /*"    05          WTAM-3          PIC  9(003) VALUE 1.*/
                public IntBasis WTAM_3 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"), 1);
                /*"    05          WAREA-3A        PIC  X(001).*/
                public StringBasis WAREA_3A { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"  03            WDATA-HOST.*/
            }
            public EM0202B_WDATA_HOST WDATA_HOST { get; set; } = new EM0202B_WDATA_HOST();
            public class EM0202B_WDATA_HOST : VarBasis
            {
                /*"    05          WDATA-AA-HOST   PIC  9(004).*/
                public IntBasis WDATA_AA_HOST { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05          FILLER          PIC  X(001).*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05          WDATA-MM-HOST   PIC  9(002).*/
                public IntBasis WDATA_MM_HOST { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          FILLER          PIC  X(001).*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05          WDATA-DD-HOST   PIC  9(002).*/
                public IntBasis WDATA_DD_HOST { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WDATA-CABEC.*/
            }
            public EM0202B_WDATA_CABEC WDATA_CABEC { get; set; } = new EM0202B_WDATA_CABEC();
            public class EM0202B_WDATA_CABEC : VarBasis
            {
                /*"    05          WDATA-DD-CABEC  PIC  9(002).*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          WDATA-H1-CABEC  PIC  X(001).*/
                public StringBasis WDATA_H1_CABEC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05          WDATA-MM-CABEC  PIC  9(002).*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          WDATA-H2-CABEC  PIC  X(001).*/
                public StringBasis WDATA_H2_CABEC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05          WDATA-AA-CABEC  PIC  9(004).*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  03            W-NUMDOC.*/
            }
            public EM0202B_W_NUMDOC W_NUMDOC { get; set; } = new EM0202B_W_NUMDOC();
            public class EM0202B_W_NUMDOC : VarBasis
            {
                /*"    05          W-NUM-APOL       PIC  9(010)    VALUE ZEROS.*/
                public IntBasis W_NUM_APOL { get; set; } = new IntBasis(new PIC("9", "10", "9(010)"));
                /*"    05          FILLER           REDEFINES      W-NUM-APOL.*/
                private _REDEF_EM0202B_FILLER_20 _filler_20 { get; set; }
                public _REDEF_EM0202B_FILLER_20 FILLER_20
                {
                    get { _filler_20 = new _REDEF_EM0202B_FILLER_20(); _.Move(W_NUM_APOL, _filler_20); VarBasis.RedefinePassValue(W_NUM_APOL, _filler_20, W_NUM_APOL); _filler_20.ValueChanged += () => { _.Move(_filler_20, W_NUM_APOL); }; return _filler_20; }
                    set { VarBasis.RedefinePassValue(value, _filler_20, W_NUM_APOL); }
                }  //Redefines
                public class _REDEF_EM0202B_FILLER_20 : VarBasis
                {
                    /*"      10        W-RAMO           PIC  9(002).*/
                    public IntBasis W_RAMO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      10        W-NUMAPOL        PIC  9(008).*/
                    public IntBasis W_NUMAPOL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"    05          W-NRENDOS        PIC  9(006)    VALUE  ZEROS.*/

                    public _REDEF_EM0202B_FILLER_20()
                    {
                        W_RAMO.ValueChanged += OnValueChanged;
                        W_NUMAPOL.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis W_NRENDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
                /*"    05          W-RAMO-EMIS      PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis W_RAMO_EMIS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"   03 WABEND.*/
                public EM0202B_WABEND WABEND { get; set; } = new EM0202B_WABEND();
                public class EM0202B_WABEND : VarBasis
                {
                    /*"      05 FILLER                   PIC X(10) VALUE         ' EM0202B  '.*/
                    public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @" EM0202B  ");
                    /*"      05 FILLER                   PIC X(28) VALUE         ' *** ERRO  EXEC SQL  NUMERO '.*/
                    public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "28", "X(28)"), @" *** ERRO  EXEC SQL  NUMERO ");
                    /*"      05 WNR-EXEC-SQL             PIC X(03) VALUE '000'.*/
                    public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"000");
                    /*"      05 FILLER                   PIC X(14) VALUE         '    SQLCODE = '.*/
                    public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"    SQLCODE = ");
                    /*"      05 WSQLCODE                 PIC ZZZZZ999- VALUE ZEROS.*/
                    public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                    /*"  03       WNUMERO             PIC S9(009)      VALUE  +0  COMP.*/
                }
            }
        }
        public IntBasis WNUMERO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"  03       WDIGITO             PIC S9(004)      VALUE  +0  COMP.*/
        public IntBasis WDIGITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"  03       WPARM01-AUX         PIC S9(009) COMP-3 VALUE +0.*/
        public IntBasis WPARM01_AUX { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"  03       WQUOCIENTE          PIC S9(004) COMP-3 VALUE +0.*/
        public IntBasis WQUOCIENTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"  03       WRESTO              PIC S9(004) COMP-3 VALUE +0.*/
        public IntBasis WRESTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"  03       AC-VALOR            PIC  9(007)        VALUE  ZEROS.*/
        public IntBasis AC_VALOR { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"  03       AC-CONVENIO         PIC  9(007)        VALUE  ZEROS.*/
        public IntBasis AC_CONVENIO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"  03       AC-ERRO01           PIC  9(007)        VALUE  ZEROS.*/
        public IntBasis AC_ERRO01 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"  03       AC-ERRO02           PIC  9(007)        VALUE  ZEROS.*/
        public IntBasis AC_ERRO02 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"  03       AC-ERRO03           PIC  9(007)        VALUE  ZEROS.*/
        public IntBasis AC_ERRO03 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"  03       AC-ERRO04           PIC  9(007)        VALUE  ZEROS.*/
        public IntBasis AC_ERRO04 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"  03       AC-ERRO05           PIC  9(007)        VALUE  ZEROS.*/
        public IntBasis AC_ERRO05 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"  03       AC-ERRO06           PIC  9(007)        VALUE  ZEROS.*/
        public IntBasis AC_ERRO06 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"  03       AC-ERRO07           PIC  9(007)        VALUE  ZEROS.*/
        public IntBasis AC_ERRO07 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"  03       AC-ERRO08           PIC  9(007)        VALUE  ZEROS.*/
        public IntBasis AC_ERRO08 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"  03       AC-ERRO09           PIC  9(007)        VALUE  ZEROS.*/
        public IntBasis AC_ERRO09 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"  03       AC-ERRO10           PIC  9(007)        VALUE  ZEROS.*/
        public IntBasis AC_ERRO10 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"  03       AC-ERRO11           PIC  9(007)        VALUE  ZEROS.*/
        public IntBasis AC_ERRO11 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"01 LPARM01X.*/
        public EM0202B_LPARM01X LPARM01X { get; set; } = new EM0202B_LPARM01X();
        public class EM0202B_LPARM01X : VarBasis
        {
            /*"   03 LPARM01                     PIC  9(15).*/
            public IntBasis LPARM01 { get; set; } = new IntBasis(new PIC("9", "15", "9(15)."));
            /*"   03 LPARM01-R REDEFINES LPARM01.*/
            private _REDEF_EM0202B_LPARM01_R _lparm01_r { get; set; }
            public _REDEF_EM0202B_LPARM01_R LPARM01_R
            {
                get { _lparm01_r = new _REDEF_EM0202B_LPARM01_R(); _.Move(LPARM01, _lparm01_r); VarBasis.RedefinePassValue(LPARM01, _lparm01_r, LPARM01); _lparm01_r.ValueChanged += () => { _.Move(_lparm01_r, LPARM01); }; return _lparm01_r; }
                set { VarBasis.RedefinePassValue(value, _lparm01_r, LPARM01); }
            }  //Redefines
            public class _REDEF_EM0202B_LPARM01_R : VarBasis
            {
                /*"      05 LPARM01-1                PIC  9(01).*/
                public IntBasis LPARM01_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"      05 LPARM01-2                PIC  9(01).*/
                public IntBasis LPARM01_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"      05 LPARM01-3                PIC  9(01).*/
                public IntBasis LPARM01_3 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"      05 LPARM01-4                PIC  9(01).*/
                public IntBasis LPARM01_4 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"      05 LPARM01-5                PIC  9(01).*/
                public IntBasis LPARM01_5 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"      05 LPARM01-6                PIC  9(01).*/
                public IntBasis LPARM01_6 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"      05 LPARM01-7                PIC  9(01).*/
                public IntBasis LPARM01_7 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"      05 LPARM01-8                PIC  9(01).*/
                public IntBasis LPARM01_8 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"      05 LPARM01-9                PIC  9(01).*/
                public IntBasis LPARM01_9 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"      05 LPARM01-10               PIC  9(01).*/
                public IntBasis LPARM01_10 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"      05 LPARM01-11               PIC  9(01).*/
                public IntBasis LPARM01_11 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"      05 LPARM01-12               PIC  9(01).*/
                public IntBasis LPARM01_12 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"      05 LPARM01-13               PIC  9(01).*/
                public IntBasis LPARM01_13 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"      05 LPARM01-14               PIC  9(01).*/
                public IntBasis LPARM01_14 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"      05 LPARM01-15               PIC  9(01).*/
                public IntBasis LPARM01_15 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"   03 LPARM02                     PIC S9(04) COMP.*/

                public _REDEF_EM0202B_LPARM01_R()
                {
                    LPARM01_1.ValueChanged += OnValueChanged;
                    LPARM01_2.ValueChanged += OnValueChanged;
                    LPARM01_3.ValueChanged += OnValueChanged;
                    LPARM01_4.ValueChanged += OnValueChanged;
                    LPARM01_5.ValueChanged += OnValueChanged;
                    LPARM01_6.ValueChanged += OnValueChanged;
                    LPARM01_7.ValueChanged += OnValueChanged;
                    LPARM01_8.ValueChanged += OnValueChanged;
                    LPARM01_9.ValueChanged += OnValueChanged;
                    LPARM01_10.ValueChanged += OnValueChanged;
                    LPARM01_11.ValueChanged += OnValueChanged;
                    LPARM01_12.ValueChanged += OnValueChanged;
                    LPARM01_13.ValueChanged += OnValueChanged;
                    LPARM01_14.ValueChanged += OnValueChanged;
                    LPARM01_15.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis LPARM02 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"   03 LPARM03                     PIC  9(01).*/
            public IntBasis LPARM03 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
            /*"   03 LPARM03-R REDEFINES LPARM03 PIC  X(01).*/
            private _REDEF_StringBasis _lparm03_r { get; set; }
            public _REDEF_StringBasis LPARM03_R
            {
                get { _lparm03_r = new _REDEF_StringBasis(new PIC("X", "01", "X(01).")); ; _.Move(LPARM03, _lparm03_r); VarBasis.RedefinePassValue(LPARM03, _lparm03_r, LPARM03); _lparm03_r.ValueChanged += () => { _.Move(_lparm03_r, LPARM03); }; return _lparm03_r; }
                set { VarBasis.RedefinePassValue(value, _lparm03_r, LPARM03); }
            }  //Redefines
            /*"01 WPARAMETROS.*/
        }
        public EM0202B_WPARAMETROS WPARAMETROS { get; set; } = new EM0202B_WPARAMETROS();
        public class EM0202B_WPARAMETROS : VarBasis
        {
            /*"   05 WPARM-PROGRAMA              PIC  X(08).*/
            public StringBasis WPARM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
            /*"   05 WPARM-NUMAPOL               PIC S9(13)     COMP-3.*/
            public IntBasis WPARM_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
            /*"   05 WPARM-NRENDOS               PIC S9(09)     COMP.*/
            public IntBasis WPARM_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"   05 WPARM-NRPARCEL              PIC S9(04)     COMP.*/
            public IntBasis WPARM_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"   05 WPARM-OCORHIST              PIC S9(04)     COMP.*/
            public IntBasis WPARM_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"   05 WPARM-TEMCONTA              PIC  X(01).*/
            public StringBasis WPARM_TEMCONTA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"   05 WPARM-ERRO01                PIC  9(02).*/
            public IntBasis WPARM_ERRO01 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"   05 WPARM-ERRO02                PIC  9(02).*/
            public IntBasis WPARM_ERRO02 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"   05 WPARM-ERRO03                PIC  9(02).*/
            public IntBasis WPARM_ERRO03 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"   05 WPARM-ERRO04                PIC  9(02).*/
            public IntBasis WPARM_ERRO04 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"   05 WPARM-ERRO05                PIC  9(02).*/
            public IntBasis WPARM_ERRO05 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"   05 WPARM-ERRO06                PIC  9(02).*/
            public IntBasis WPARM_ERRO06 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"   05 WPARM-ERRO07                PIC  9(02).*/
            public IntBasis WPARM_ERRO07 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"   05 WPARM-ERRO08                PIC  9(02).*/
            public IntBasis WPARM_ERRO08 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"   05 WPARM-ERRO09                PIC  9(02).*/
            public IntBasis WPARM_ERRO09 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"   05 WPARM-ERRO10                PIC  9(02).*/
            public IntBasis WPARM_ERRO10 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"   05 WPARM-ERRO11                PIC  9(02).*/
            public IntBasis WPARM_ERRO11 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"   05 WPARM-MSG-ERRO              PIC  X(80).*/
            public StringBasis WPARM_MSG_ERRO { get; set; } = new StringBasis(new PIC("X", "80", "X(80)."), @"");
            /*"   05 WPARM-SQLCODE               PIC S9(04) COMP.*/
            public IntBasis WPARM_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        }


        public Dclgens.CBCONDEV CBCONDEV { get; set; } = new Dclgens.CBCONDEV();
        public Dclgens.AGENCCEF AGENCCEF { get; set; } = new Dclgens.AGENCCEF();
        public Dclgens.MALHACEF MALHACEF { get; set; } = new Dclgens.MALHACEF();
        public Dclgens.CB041 CB041 { get; set; } = new Dclgens.CB041();
        public Dclgens.GE368 GE368 { get; set; } = new Dclgens.GE368();
        public Dclgens.OD009 OD009 { get; set; } = new Dclgens.OD009();
        public EM0202B_V1RELATORIOS V1RELATORIOS { get; set; } = new EM0202B_V1RELATORIOS();
        public EM0202B_EMISDIA EMISDIA { get; set; } = new EM0202B_EMISDIA();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string EM0202M01_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                EM0202M01.SetFile(EM0202M01_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM M-000-00-PRINCIPAL-SECTION */

                M_000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" M-000-00-PRINCIPAL-SECTION */
        private void M_000_00_PRINCIPAL_SECTION()
        {
            /*" -660- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -662- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -664- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -667- DISPLAY '----------------------------------------------' */
            _.Display($"----------------------------------------------");

            /*" -668- DISPLAY 'EM0202B - EMITE RECIBOS DE RESTITUICAO' */
            _.Display($"EM0202B - EMITE RECIBOS DE RESTITUICAO");

            /*" -671- DISPLAY 'VERSAO  - V.21 - 29/06/2015 - NSGD        ' */
            _.Display($"VERSAO  - V.21 - 29/06/2015 - NSGD        ");

            /*" -672- DISPLAY '----------------------------------------------' */
            _.Display($"----------------------------------------------");

            /*" -674- DISPLAY ' ' */
            _.Display($" ");

            /*" -676- OPEN OUTPUT EM0202M01 */
            EM0202M01.Open(REG_EM0202M01);

            /*" -678- PERFORM R0100-00-ULTIMO-NUMERO. */

            R0100_00_ULTIMO_NUMERO_SECTION();

            /*" -680- PERFORM R0200-00-SISTEMAS. */

            R0200_00_SISTEMAS_SECTION();

            /*" -682- PERFORM R0300-00-VERIFICA-2VIA. */

            R0300_00_VERIFICA_2VIA_SECTION();

            /*" -683- IF WFIM-SISTEMA NOT EQUAL SPACES */

            if (!W.WFIM_SISTEMA.IsEmpty())
            {

                /*" -684- DISPLAY 'EM0202B - ERRO NO SELECT DA V1SISTEMA (EM)' */
                _.Display($"EM0202B - ERRO NO SELECT DA V1SISTEMA (EM)");

                /*" -688- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -690- PERFORM R0400-00-LER-FINANCEIRO. */

            R0400_00_LER_FINANCEIRO_SECTION();

            /*" -691- IF WFIM-SISTEMA NOT EQUAL SPACES */

            if (!W.WFIM_SISTEMA.IsEmpty())
            {

                /*" -692- DISPLAY 'EM0202B - ERRO NO SELECT DA V1SISTEMA (FI)' */
                _.Display($"EM0202B - ERRO NO SELECT DA V1SISTEMA (FI)");

                /*" -694- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -696- PERFORM R0800-00-DECLARA-TRELAT. */

            R0800_00_DECLARA_TRELAT_SECTION();

            /*" -698- PERFORM R0900-00-LER-TRELAT. */

            R0900_00_LER_TRELAT_SECTION();

            /*" -699- IF WFIM-TRELAT NOT EQUAL SPACES */

            if (!W.WFIM_TRELAT.IsEmpty())
            {

                /*" -700- DISPLAY 'EM0202B - NAO HOUVE EMISSAO DE RECIBOS' */
                _.Display($"EM0202B - NAO HOUVE EMISSAO DE RECIBOS");

                /*" -701- ELSE */
            }
            else
            {


                /*" -703- SET W88-CONTROLE-OFF TO TRUE */
                FILLER_0["W88_CONTROLE_OFF"] = true;

                /*" -705- PERFORM R1000-00-PROCESSA UNTIL WFIM-TRELAT NOT = SPACES */

                while (!(!W.WFIM_TRELAT.IsEmpty()))
                {

                    R1000_00_PROCESSA_SECTION();
                }

                /*" -707- PERFORM R9000-00-ALTERA-SITUACAO */

                R9000_00_ALTERA_SITUACAO_SECTION();

                /*" -708- IF W88-CONTROLE-ON */

                if (FILLER_0["W88_CONTROLE_ON"])
                {

                    /*" -709- MOVE '%%EOF' TO LC00 */
                    _.Move("%%EOF", W.LC00);

                    /*" -710- WRITE REG-EM0202M01 FROM LC00 */
                    _.Move(W.LC00.GetMoveValues(), REG_EM0202M01);

                    EM0202M01.Write(REG_EM0202M01.GetMoveValues().ToString());

                    /*" -711- END-IF */
                }


                /*" -711- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM M_000_90_FIM */

            M_000_90_FIM();

        }

        [StopWatch]
        /*" M-000-90-FIM */
        private void M_000_90_FIM(bool isPerform = false)
        {
            /*" -717- CLOSE EM0202M01. */
            EM0202M01.Close();

            /*" -717- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -721- DISPLAY ' ' */
            _.Display($" ");

            /*" -722- DISPLAY '--------------------------------------------' */
            _.Display($"--------------------------------------------");

            /*" -723- DISPLAY 'CHEQUES RESTITUICAO GERADOS  : ' WS-CT-CHEQUES. */
            _.Display($"CHEQUES RESTITUICAO GERADOS  : {W.WS_CT_CHEQUES}");

            /*" -724- DISPLAY 'RECIBOS RESTITUICAO EMITIDOS : ' WS-CT-RECIBOS. */
            _.Display($"RECIBOS RESTITUICAO EMITIDOS : {W.WS_CT_RECIBOS}");

            /*" -725- DISPLAY ' ' . */
            _.Display($" ");

            /*" -726- DISPLAY 'CBCONDEV (Credito C/C )      : ' WS-CT-CBCONCC. */
            _.Display($"CBCONDEV (Credito C/C )      : {W.WS_CT_CBCONCC}");

            /*" -727- DISPLAY 'CBCONDEV (Cheques )          : ' WS-CT-CBCONCH. */
            _.Display($"CBCONDEV (Cheques )          : {W.WS_CT_CBCONCH}");

            /*" -728- DISPLAY ' ' . */
            _.Display($" ");

            /*" -729- DISPLAY 'ACOMPANHAMENTO GE0540S     ' */
            _.Display($"ACOMPANHAMENTO GE0540S     ");

            /*" -730- DISPLAY ' ' . */
            _.Display($" ");

            /*" -731- DISPLAY 'DESPREZA VALOR               : ' AC-VALOR */
            _.Display($"DESPREZA VALOR               : {AC_VALOR}");

            /*" -732- DISPLAY 'ENVIADOS CREDITO CONTA       : ' AC-CONVENIO */
            _.Display($"ENVIADOS CREDITO CONTA       : {AC_CONVENIO}");

            /*" -733- DISPLAY 'NAO TEM SISTEMA              : ' AC-ERRO01 */
            _.Display($"NAO TEM SISTEMA              : {AC_ERRO01}");

            /*" -734- DISPLAY 'NAO TEM APOLCOBR             : ' AC-ERRO02 */
            _.Display($"NAO TEM APOLCOBR             : {AC_ERRO02}");

            /*" -735- DISPLAY 'NAO TEM APOLICES             : ' AC-ERRO03 */
            _.Display($"NAO TEM APOLICES             : {AC_ERRO03}");

            /*" -736- DISPLAY 'NAO TEM ENDOSSOS             : ' AC-ERRO04 */
            _.Display($"NAO TEM ENDOSSOS             : {AC_ERRO04}");

            /*" -737- DISPLAY 'NAO TEM CLIENTES             : ' AC-ERRO05 */
            _.Display($"NAO TEM CLIENTES             : {AC_ERRO05}");

            /*" -738- DISPLAY 'NAO TEM ENDERECOS            : ' AC-ERRO06 */
            _.Display($"NAO TEM ENDERECOS            : {AC_ERRO06}");

            /*" -739- DISPLAY 'NAO INCLUIU GE0500B          : ' AC-ERRO07 */
            _.Display($"NAO INCLUIU GE0500B          : {AC_ERRO07}");

            /*" -740- DISPLAY 'NAO INCLUIU GE0501B          : ' AC-ERRO08 */
            _.Display($"NAO INCLUIU GE0501B          : {AC_ERRO08}");

            /*" -741- DISPLAY 'NAO INCLUIU GE0502B          : ' AC-ERRO09 */
            _.Display($"NAO INCLUIU GE0502B          : {AC_ERRO09}");

            /*" -742- DISPLAY 'NAO INCLUIU GE0503B          : ' AC-ERRO10 */
            _.Display($"NAO INCLUIU GE0503B          : {AC_ERRO10}");

            /*" -743- DISPLAY 'NAO INCLUIU GE0550B          : ' AC-ERRO11 */
            _.Display($"NAO INCLUIU GE0550B          : {AC_ERRO11}");

            /*" -744- DISPLAY '--------------------------------------------' */
            _.Display($"--------------------------------------------");

            /*" -745- DISPLAY ' ' . */
            _.Display($" ");

            /*" -747- DISPLAY 'EM0202B -  *** FIM NORMAL ***' . */
            _.Display($"EM0202B -  *** FIM NORMAL ***");

            /*" -749- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -749- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-ULTIMO-NUMERO-SECTION */
        private void R0100_00_ULTIMO_NUMERO_SECTION()
        {
            /*" -762- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", W.W_NUMDOC.WABEND.WNR_EXEC_SQL);

            /*" -766- PERFORM R0100_00_ULTIMO_NUMERO_DB_SELECT_1 */

            R0100_00_ULTIMO_NUMERO_DB_SELECT_1();

            /*" -769- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -770- DISPLAY 'EM0202B - ERRO NO ACESSO DA V1CHEQUES' */
                _.Display($"EM0202B - ERRO NO ACESSO DA V1CHEQUES");

                /*" -772- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -772- MOVE V0CHEQ-CHQINT TO WNUMERO. */
            _.Move(V0CHEQ_CHQINT, WNUMERO);

        }

        [StopWatch]
        /*" R0100-00-ULTIMO-NUMERO-DB-SELECT-1 */
        public void R0100_00_ULTIMO_NUMERO_DB_SELECT_1()
        {
            /*" -766- EXEC SQL SELECT VALUE(MAX(CHQINT), 0) INTO :V0CHEQ-CHQINT FROM SEGUROS.V1CHEQUES END-EXEC. */

            var r0100_00_ULTIMO_NUMERO_DB_SELECT_1_Query1 = new R0100_00_ULTIMO_NUMERO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_ULTIMO_NUMERO_DB_SELECT_1_Query1.Execute(r0100_00_ULTIMO_NUMERO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CHEQ_CHQINT, V0CHEQ_CHQINT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-SISTEMAS-SECTION */
        private void R0200_00_SISTEMAS_SECTION()
        {
            /*" -785- MOVE '020' TO WNR-EXEC-SQL. */
            _.Move("020", W.W_NUMDOC.WABEND.WNR_EXEC_SQL);

            /*" -792- PERFORM R0200_00_SISTEMAS_DB_SELECT_1 */

            R0200_00_SISTEMAS_DB_SELECT_1();

            /*" -795- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -796- MOVE 'S' TO WFIM-SISTEMA */
                _.Move("S", W.WFIM_SISTEMA);

                /*" -798- GO TO R0200-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/ //GOTO
                return;
            }


            /*" -799- DISPLAY 'DATA DO MOVIMENTO: ' V1SIST-DTMOVABE */
            _.Display($"DATA DO MOVIMENTO: {V1SIST_DTMOVABE}");

            /*" -801- DISPLAY 'HORA DO MOVIMENTO: ' V1SIST-HRMOVABE */
            _.Display($"HORA DO MOVIMENTO: {V1SIST_HRMOVABE}");

            /*" -802- MOVE V1SIST-DTMOVABE TO WDATA-HOST. */
            _.Move(V1SIST_DTMOVABE, W.WDATA_HOST);

            /*" -803- MOVE WDATA-DD-HOST TO WDATA-DD-CABEC. */
            _.Move(W.WDATA_HOST.WDATA_DD_HOST, W.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -804- MOVE WDATA-MM-HOST TO WDATA-MM-CABEC. */
            _.Move(W.WDATA_HOST.WDATA_MM_HOST, W.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -805- MOVE WDATA-AA-HOST TO WDATA-AA-CABEC. */
            _.Move(W.WDATA_HOST.WDATA_AA_HOST, W.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -806- MOVE '/' TO WDATA-H1-CABEC. */
            _.Move("/", W.WDATA_CABEC.WDATA_H1_CABEC);

            /*" -807- MOVE '/' TO WDATA-H2-CABEC. */
            _.Move("/", W.WDATA_CABEC.WDATA_H2_CABEC);

            /*" -807- MOVE WDATA-CABEC TO LBFFI01-DATA. */
            _.Move(W.WDATA_CABEC, W.LBFFI01_REGISTRO.LBFFI01_DATA);

        }

        [StopWatch]
        /*" R0200-00-SISTEMAS-DB-SELECT-1 */
        public void R0200_00_SISTEMAS_DB_SELECT_1()
        {
            /*" -792- EXEC SQL SELECT DTMOVABE ,CURRENT TIME INTO :V1SIST-DTMOVABE ,:V1SIST-HRMOVABE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'EM' END-EXEC. */

            var r0200_00_SISTEMAS_DB_SELECT_1_Query1 = new R0200_00_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0200_00_SISTEMAS_DB_SELECT_1_Query1.Execute(r0200_00_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
                _.Move(executed_1.V1SIST_HRMOVABE, V1SIST_HRMOVABE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-VERIFICA-2VIA-SECTION */
        private void R0300_00_VERIFICA_2VIA_SECTION()
        {
            /*" -820- PERFORM R0310-00-DECLARE-V1RELATORIOS. */

            R0310_00_DECLARE_V1RELATORIOS_SECTION();

            /*" -822- PERFORM R0320-00-FETCH-V1RELATORIOS. */

            R0320_00_FETCH_V1RELATORIOS_SECTION();

            /*" -823- IF WFIM-V1RELATORIOS = SPACES */

            if (W.WFIM_V1RELATORIOS.IsEmpty())
            {

                /*" -826- PERFORM R0330-00-PROCESSA-REGISTRO UNTIL WFIM-V1RELATORIOS NOT EQUAL SPACES */

                while (!(!W.WFIM_V1RELATORIOS.IsEmpty()))
                {

                    R0330_00_PROCESSA_REGISTRO_SECTION();
                }

                /*" -827- PERFORM R0340-00-DELETE-V0RELATORIOS */

                R0340_00_DELETE_V0RELATORIOS_SECTION();

                /*" -827- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0310-00-DECLARE-V1RELATORIOS-SECTION */
        private void R0310_00_DECLARE_V1RELATORIOS_SECTION()
        {
            /*" -840- MOVE '031' TO WNR-EXEC-SQL. */
            _.Move("031", W.W_NUMDOC.WABEND.WNR_EXEC_SQL);

            /*" -851- PERFORM R0310_00_DECLARE_V1RELATORIOS_DB_DECLARE_1 */

            R0310_00_DECLARE_V1RELATORIOS_DB_DECLARE_1();

            /*" -853- PERFORM R0310_00_DECLARE_V1RELATORIOS_DB_OPEN_1 */

            R0310_00_DECLARE_V1RELATORIOS_DB_OPEN_1();

            /*" -856- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -857- DISPLAY 'EM0202B - ERRO NO OPEN DO CURSOR V1RELATORIOS' */
                _.Display($"EM0202B - ERRO NO OPEN DO CURSOR V1RELATORIOS");

                /*" -857- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0310-00-DECLARE-V1RELATORIOS-DB-DECLARE-1 */
        public void R0310_00_DECLARE_V1RELATORIOS_DB_DECLARE_1()
        {
            /*" -851- EXEC SQL DECLARE V1RELATORIOS CURSOR FOR SELECT NUM_APOLICE ,NRENDOS ,ORGAO ,RAMO ,FONTE ,CODPDT FROM SEGUROS.V1RELATORIOS WHERE CODRELAT = 'EM0202B1' AND DATA_SOLICITACAO = :V1SIST-DTMOVABE AND SITUACAO = '0' END-EXEC. */
            V1RELATORIOS = new EM0202B_V1RELATORIOS(true);
            string GetQuery_V1RELATORIOS()
            {
                var query = @$"SELECT NUM_APOLICE 
							,NRENDOS 
							,ORGAO 
							,RAMO 
							,FONTE 
							,CODPDT 
							FROM SEGUROS.V1RELATORIOS 
							WHERE CODRELAT = 'EM0202B1' 
							AND DATA_SOLICITACAO = '{V1SIST_DTMOVABE}' 
							AND SITUACAO = '0'";

                return query;
            }
            V1RELATORIOS.GetQueryEvent += GetQuery_V1RELATORIOS;

        }

        [StopWatch]
        /*" R0310-00-DECLARE-V1RELATORIOS-DB-OPEN-1 */
        public void R0310_00_DECLARE_V1RELATORIOS_DB_OPEN_1()
        {
            /*" -853- EXEC SQL OPEN V1RELATORIOS END-EXEC. */

            V1RELATORIOS.Open();

        }

        [StopWatch]
        /*" R0800-00-DECLARA-TRELAT-DB-DECLARE-1 */
        public void R0800_00_DECLARA_TRELAT_DB_DECLARE_1()
        {
            /*" -1025- EXEC SQL DECLARE EMISDIA CURSOR FOR SELECT COD_RELATORIO ,NUM_APOLICE ,NUM_ENDOSSO ,COD_FONTE ,ORGAO_EMISSOR ,RAMO_EMISSOR FROM SEGUROS.EMISSAO_DIARIA WHERE COD_RELATORIO IN ( 'EM0202B1' , 'EM0202B2' ) AND SIT_REGISTRO = '0' ORDER BY COD_FONTE ,NUM_APOLICE ,NUM_ENDOSSO END-EXEC. */
            EMISDIA = new EM0202B_EMISDIA(false);
            string GetQuery_EMISDIA()
            {
                var query = @$"SELECT COD_RELATORIO 
							,NUM_APOLICE 
							,NUM_ENDOSSO 
							,COD_FONTE 
							,ORGAO_EMISSOR 
							,RAMO_EMISSOR 
							FROM SEGUROS.EMISSAO_DIARIA 
							WHERE COD_RELATORIO IN ( 'EM0202B1'
							, 'EM0202B2' ) 
							AND SIT_REGISTRO = '0' 
							ORDER BY COD_FONTE 
							,NUM_APOLICE 
							,NUM_ENDOSSO";

                return query;
            }
            EMISDIA.GetQueryEvent += GetQuery_EMISDIA;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/

        [StopWatch]
        /*" R0320-00-FETCH-V1RELATORIOS-SECTION */
        private void R0320_00_FETCH_V1RELATORIOS_SECTION()
        {
            /*" -870- MOVE '032' TO WNR-EXEC-SQL. */
            _.Move("032", W.W_NUMDOC.WABEND.WNR_EXEC_SQL);

            /*" -877- PERFORM R0320_00_FETCH_V1RELATORIOS_DB_FETCH_1 */

            R0320_00_FETCH_V1RELATORIOS_DB_FETCH_1();

            /*" -880- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -881- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -882- MOVE 'S' TO WFIM-V1RELATORIOS */
                    _.Move("S", W.WFIM_V1RELATORIOS);

                    /*" -882- PERFORM R0320_00_FETCH_V1RELATORIOS_DB_CLOSE_1 */

                    R0320_00_FETCH_V1RELATORIOS_DB_CLOSE_1();

                    /*" -884- ELSE */
                }
                else
                {


                    /*" -885- DISPLAY 'EM0202B - ERRO NO FETCH DO CURSOR V1RELATORIOS' */
                    _.Display($"EM0202B - ERRO NO FETCH DO CURSOR V1RELATORIOS");

                    /*" -885- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0320-00-FETCH-V1RELATORIOS-DB-FETCH-1 */
        public void R0320_00_FETCH_V1RELATORIOS_DB_FETCH_1()
        {
            /*" -877- EXEC SQL FETCH V1RELATORIOS INTO :V1RELA-NUM-APOL ,:V1RELA-NRENDOS ,:V1RELA-ORGAO ,:V1RELA-RAMO ,:V1RELA-FONTE ,:V1RELA-CODPDT END-EXEC. */

            if (V1RELATORIOS.Fetch())
            {
                _.Move(V1RELATORIOS.V1RELA_NUM_APOL, V1RELA_NUM_APOL);
                _.Move(V1RELATORIOS.V1RELA_NRENDOS, V1RELA_NRENDOS);
                _.Move(V1RELATORIOS.V1RELA_ORGAO, V1RELA_ORGAO);
                _.Move(V1RELATORIOS.V1RELA_RAMO, V1RELA_RAMO);
                _.Move(V1RELATORIOS.V1RELA_FONTE, V1RELA_FONTE);
                _.Move(V1RELATORIOS.V1RELA_CODPDT, V1RELA_CODPDT);
            }

        }

        [StopWatch]
        /*" R0320-00-FETCH-V1RELATORIOS-DB-CLOSE-1 */
        public void R0320_00_FETCH_V1RELATORIOS_DB_CLOSE_1()
        {
            /*" -882- EXEC SQL CLOSE V1RELATORIOS END-EXEC */

            V1RELATORIOS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0320_99_SAIDA*/

        [StopWatch]
        /*" R0330-00-PROCESSA-REGISTRO-SECTION */
        private void R0330_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -898- MOVE '033' TO WNR-EXEC-SQL. */
            _.Move("033", W.W_NUMDOC.WABEND.WNR_EXEC_SQL);

            /*" -899- MOVE 'EM0202B2' TO V1EDIA-CODRELAT */
            _.Move("EM0202B2", V1EDIA_CODRELAT);

            /*" -900- MOVE V1RELA-NUM-APOL TO V1EDIA-NUM-APOL */
            _.Move(V1RELA_NUM_APOL, V1EDIA_NUM_APOL);

            /*" -901- MOVE V1RELA-NRENDOS TO V1EDIA-NRENDOS */
            _.Move(V1RELA_NRENDOS, V1EDIA_NRENDOS);

            /*" -902- MOVE ZEROS TO V1EDIA-NRPARCEL */
            _.Move(0, V1EDIA_NRPARCEL);

            /*" -903- MOVE V1SIST-DTMOVABE TO V1EDIA-DTMOVTO */
            _.Move(V1SIST_DTMOVABE, V1EDIA_DTMOVTO);

            /*" -904- MOVE V1RELA-ORGAO TO V1EDIA-ORGAO */
            _.Move(V1RELA_ORGAO, V1EDIA_ORGAO);

            /*" -905- MOVE V1RELA-RAMO TO V1EDIA-RAMO */
            _.Move(V1RELA_RAMO, V1EDIA_RAMO);

            /*" -906- MOVE V1RELA-FONTE TO V1EDIA-FONTE */
            _.Move(V1RELA_FONTE, V1EDIA_FONTE);

            /*" -907- MOVE ZEROS TO V1EDIA-CONGENER */
            _.Move(0, V1EDIA_CONGENER);

            /*" -908- MOVE V1RELA-CODPDT TO V1EDIA-CODCORR */
            _.Move(V1RELA_CODPDT, V1EDIA_CODCORR);

            /*" -909- MOVE '0' TO V1EDIA-SITUACAO */
            _.Move("0", V1EDIA_SITUACAO);

            /*" -911- MOVE ZEROS TO V1EDIA-COD-EMP. */
            _.Move(0, V1EDIA_COD_EMP);

            /*" -926- PERFORM R0330_00_PROCESSA_REGISTRO_DB_INSERT_1 */

            R0330_00_PROCESSA_REGISTRO_DB_INSERT_1();

            /*" -929- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -930- DISPLAY 'EM0202B - ERRO NO INSERT DA V0EMISDIARIA' */
                _.Display($"EM0202B - ERRO NO INSERT DA V0EMISDIARIA");

                /*" -932- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -932- PERFORM R0320-00-FETCH-V1RELATORIOS. */

            R0320_00_FETCH_V1RELATORIOS_SECTION();

        }

        [StopWatch]
        /*" R0330-00-PROCESSA-REGISTRO-DB-INSERT-1 */
        public void R0330_00_PROCESSA_REGISTRO_DB_INSERT_1()
        {
            /*" -926- EXEC SQL INSERT INTO SEGUROS.V0EMISDIARIA VALUES (:V1EDIA-CODRELAT , :V1EDIA-NUM-APOL , :V1EDIA-NRENDOS , :V1EDIA-NRPARCEL , :V1EDIA-DTMOVTO , :V1EDIA-ORGAO , :V1EDIA-RAMO , :V1EDIA-FONTE , :V1EDIA-CONGENER , :V1EDIA-CODCORR , :V1EDIA-SITUACAO , :V1EDIA-COD-EMP , CURRENT TIMESTAMP) END-EXEC. */

            var r0330_00_PROCESSA_REGISTRO_DB_INSERT_1_Insert1 = new R0330_00_PROCESSA_REGISTRO_DB_INSERT_1_Insert1()
            {
                V1EDIA_CODRELAT = V1EDIA_CODRELAT.ToString(),
                V1EDIA_NUM_APOL = V1EDIA_NUM_APOL.ToString(),
                V1EDIA_NRENDOS = V1EDIA_NRENDOS.ToString(),
                V1EDIA_NRPARCEL = V1EDIA_NRPARCEL.ToString(),
                V1EDIA_DTMOVTO = V1EDIA_DTMOVTO.ToString(),
                V1EDIA_ORGAO = V1EDIA_ORGAO.ToString(),
                V1EDIA_RAMO = V1EDIA_RAMO.ToString(),
                V1EDIA_FONTE = V1EDIA_FONTE.ToString(),
                V1EDIA_CONGENER = V1EDIA_CONGENER.ToString(),
                V1EDIA_CODCORR = V1EDIA_CODCORR.ToString(),
                V1EDIA_SITUACAO = V1EDIA_SITUACAO.ToString(),
                V1EDIA_COD_EMP = V1EDIA_COD_EMP.ToString(),
            };

            R0330_00_PROCESSA_REGISTRO_DB_INSERT_1_Insert1.Execute(r0330_00_PROCESSA_REGISTRO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0330_99_SAIDA*/

        [StopWatch]
        /*" R0340-00-DELETE-V0RELATORIOS-SECTION */
        private void R0340_00_DELETE_V0RELATORIOS_SECTION()
        {
            /*" -945- MOVE '034' TO WNR-EXEC-SQL. */
            _.Move("034", W.W_NUMDOC.WABEND.WNR_EXEC_SQL);

            /*" -950- PERFORM R0340_00_DELETE_V0RELATORIOS_DB_DELETE_1 */

            R0340_00_DELETE_V0RELATORIOS_DB_DELETE_1();

            /*" -953- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -954- DISPLAY 'EM0202B - ERRO NO DELETE DA V0RELATORIOS' */
                _.Display($"EM0202B - ERRO NO DELETE DA V0RELATORIOS");

                /*" -954- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0340-00-DELETE-V0RELATORIOS-DB-DELETE-1 */
        public void R0340_00_DELETE_V0RELATORIOS_DB_DELETE_1()
        {
            /*" -950- EXEC SQL DELETE FROM SEGUROS.V0RELATORIOS WHERE CODRELAT = 'EM0202B1' AND DATA_SOLICITACAO = :V1SIST-DTMOVABE AND SITUACAO = '0' END-EXEC. */

            var r0340_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1 = new R0340_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1()
            {
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
            };

            R0340_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1.Execute(r0340_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0340_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-LER-FINANCEIRO-SECTION */
        private void R0400_00_LER_FINANCEIRO_SECTION()
        {
            /*" -967- MOVE '040' TO WNR-EXEC-SQL. */
            _.Move("040", W.W_NUMDOC.WABEND.WNR_EXEC_SQL);

            /*" -972- PERFORM R0400_00_LER_FINANCEIRO_DB_SELECT_1 */

            R0400_00_LER_FINANCEIRO_DB_SELECT_1();

            /*" -975- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -977- MOVE 'S' TO WFIM-SISTEMA. */
                _.Move("S", W.WFIM_SISTEMA);
            }


            /*" -977- DISPLAY 'DATA MOVIMENTO FI: ' V1SIST-DTMOVABE-FI. */
            _.Display($"DATA MOVIMENTO FI: {V1SIST_DTMOVABE_FI}");

        }

        [StopWatch]
        /*" R0400-00-LER-FINANCEIRO-DB-SELECT-1 */
        public void R0400_00_LER_FINANCEIRO_DB_SELECT_1()
        {
            /*" -972- EXEC SQL SELECT DTMOVABE INTO :V1SIST-DTMOVABE-FI FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'FI' END-EXEC. */

            var r0400_00_LER_FINANCEIRO_DB_SELECT_1_Query1 = new R0400_00_LER_FINANCEIRO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0400_00_LER_FINANCEIRO_DB_SELECT_1_Query1.Execute(r0400_00_LER_FINANCEIRO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABE_FI, V1SIST_DTMOVABE_FI);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-IMPRIME-CONTROLE-SECTION */
        private void R0500_00_IMPRIME_CONTROLE_SECTION()
        {
            /*" -988- MOVE '%!' TO LC00 */
            _.Move("%!", W.LC00);

            /*" -990- WRITE REG-EM0202M01 FROM LC00 */
            _.Move(W.LC00.GetMoveValues(), REG_EM0202M01);

            EM0202M01.Write(REG_EM0202M01.GetMoveValues().ToString());

            /*" -992- MOVE '(|) SETDBSEP' TO LC00 */
            _.Move("(|) SETDBSEP", W.LC00);

            /*" -994- WRITE REG-EM0202M01 FROM LC00 */
            _.Move(W.LC00.GetMoveValues(), REG_EM0202M01);

            EM0202M01.Write(REG_EM0202M01.GetMoveValues().ToString());

            /*" -996- MOVE '(fi01.dbm) STARTDBM' TO LC00 */
            _.Move("(fi01.dbm) STARTDBM", W.LC00);

            /*" -997- WRITE REG-EM0202M01 FROM LC00 */
            _.Move(W.LC00.GetMoveValues(), REG_EM0202M01);

            EM0202M01.Write(REG_EM0202M01.GetMoveValues().ToString());

            /*" -999- WRITE REG-EM0202M01 FROM LBWFI01-REGISTRO */
            _.Move(W.LBWFI01_REGISTRO.GetMoveValues(), REG_EM0202M01);

            EM0202M01.Write(REG_EM0202M01.GetMoveValues().ToString());

            /*" -999- SET W88-CONTROLE-ON TO TRUE. */
            FILLER_0["W88_CONTROLE_ON"] = true;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_00_EXIT*/

        [StopWatch]
        /*" R0800-00-DECLARA-TRELAT-SECTION */
        private void R0800_00_DECLARA_TRELAT_SECTION()
        {
            /*" -1012- MOVE '080' TO WNR-EXEC-SQL */
            _.Move("080", W.W_NUMDOC.WABEND.WNR_EXEC_SQL);

            /*" -1025- PERFORM R0800_00_DECLARA_TRELAT_DB_DECLARE_1 */

            R0800_00_DECLARA_TRELAT_DB_DECLARE_1();

            /*" -1027- PERFORM R0800_00_DECLARA_TRELAT_DB_OPEN_1 */

            R0800_00_DECLARA_TRELAT_DB_OPEN_1();

            /*" -1030- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1031- DISPLAY 'EM0202B - ERRO NO OPEN DO CURSOR EMISDIA' */
                _.Display($"EM0202B - ERRO NO OPEN DO CURSOR EMISDIA");

                /*" -1031- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0800-00-DECLARA-TRELAT-DB-OPEN-1 */
        public void R0800_00_DECLARA_TRELAT_DB_OPEN_1()
        {
            /*" -1027- EXEC SQL OPEN EMISDIA END-EXEC. */

            EMISDIA.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-LER-TRELAT-SECTION */
        private void R0900_00_LER_TRELAT_SECTION()
        {
            /*" -1043- MOVE '090' TO WNR-EXEC-SQL */
            _.Move("090", W.W_NUMDOC.WABEND.WNR_EXEC_SQL);

            /*" -1045- MOVE SPACE TO WPARM-TEMCONTA */
            _.Move("", WPARAMETROS.WPARM_TEMCONTA);

            /*" -1052- PERFORM R0900_00_LER_TRELAT_DB_FETCH_1 */

            R0900_00_LER_TRELAT_DB_FETCH_1();

            /*" -1055- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1056- MOVE 'S' TO WFIM-TRELAT */
                _.Move("S", W.WFIM_TRELAT);

                /*" -1056- PERFORM R0900_00_LER_TRELAT_DB_CLOSE_1 */

                R0900_00_LER_TRELAT_DB_CLOSE_1();

                /*" -1057- END-IF. */
            }


        }

        [StopWatch]
        /*" R0900-00-LER-TRELAT-DB-FETCH-1 */
        public void R0900_00_LER_TRELAT_DB_FETCH_1()
        {
            /*" -1052- EXEC SQL FETCH EMISDIA INTO :V1EDIA-CODRELAT ,:V1EDIA-NUM-APOL ,:V1EDIA-NRENDOS ,:V1EDIA-FONTE ,:V1EDIA-ORGAO ,:V1EDIA-RAMO END-EXEC. */

            if (EMISDIA.Fetch())
            {
                _.Move(EMISDIA.V1EDIA_CODRELAT, V1EDIA_CODRELAT);
                _.Move(EMISDIA.V1EDIA_NUM_APOL, V1EDIA_NUM_APOL);
                _.Move(EMISDIA.V1EDIA_NRENDOS, V1EDIA_NRENDOS);
                _.Move(EMISDIA.V1EDIA_FONTE, V1EDIA_FONTE);
                _.Move(EMISDIA.V1EDIA_ORGAO, V1EDIA_ORGAO);
                _.Move(EMISDIA.V1EDIA_RAMO, V1EDIA_RAMO);
            }

        }

        [StopWatch]
        /*" R0900-00-LER-TRELAT-DB-CLOSE-1 */
        public void R0900_00_LER_TRELAT_DB_CLOSE_1()
        {
            /*" -1056- EXEC SQL CLOSE EMISDIA END-EXEC */

            EMISDIA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-SECTION */
        private void R1000_00_PROCESSA_SECTION()
        {
            /*" -1093- PERFORM R1100-00-LER-HISTOPARC. */

            R1100_00_LER_HISTOPARC_SECTION();

            /*" -1095- MOVE ' ' TO FLAG-ERRO. */
            _.Move(" ", W.FLAG_ERRO);

            /*" -1097- PERFORM R1200-00-LER-PARCELA. */

            R1200_00_LER_PARCELA_SECTION();

            /*" -1098- IF FLAG-ERRO NOT EQUAL ' ' */

            if (W.FLAG_ERRO != " ")
            {

                /*" -1099- DISPLAY 'EM0202B - ENDOSSO DESPREZADO PARA RESTITUICAO' */
                _.Display($"EM0202B - ENDOSSO DESPREZADO PARA RESTITUICAO");

                /*" -1101- DISPLAY 'APOLICE - ' V1EDIA-NUM-APOL ' ENDOSSO - ' V1EDIA-NRENDOS */

                $"APOLICE - {V1EDIA_NUM_APOL} ENDOSSO - {V1EDIA_NRENDOS}"
                .Display();

                /*" -1103- GO TO R1000-10-LEITURA. */

                R1000_10_LEITURA(); //GOTO
                return;
            }


            /*" -1105- PERFORM R1300-00-LER-ENDOSSO. */

            R1300_00_LER_ENDOSSO_SECTION();

            /*" -1110- PERFORM R1410-00-LER-APOLICE. */

            R1410_00_LER_APOLICE_SECTION();

            /*" -1114- IF (( V1EDIA-ORGAO EQUAL 100 OR 110 ) OR ( V1EDIA-ORGAO EQUAL 10 AND V1ENDO-RAMO EQUAL 53 AND V1ENDO-CODPRODU EQUAL 5302 OR 5303 OR 5304 )) */

            if (((V1EDIA_ORGAO.In("100", "110")) || (V1EDIA_ORGAO == 10 && V1ENDO_RAMO == 53 && V1ENDO_CODPRODU.In("5302", "5303", "5304"))))
            {

                /*" -1115- IF V1HIST-DTVENCTO GREATER V1SIST-DTMOVABE */

                if (V1HIST_DTVENCTO > V1SIST_DTMOVABE)
                {

                    /*" -1116- DISPLAY 'EM0202B - ENDOSSO COM VENCIMENTO PROGRAMADO' */
                    _.Display($"EM0202B - ENDOSSO COM VENCIMENTO PROGRAMADO");

                    /*" -1118- DISPLAY 'APOLICE - ' V1EDIA-NUM-APOL ' ' V1EDIA-NRENDOS */

                    $"APOLICE - {V1EDIA_NUM_APOL} {V1EDIA_NRENDOS}"
                    .Display();

                    /*" -1119- GO TO R1000-10-LEITURA */

                    R1000_10_LEITURA(); //GOTO
                    return;

                    /*" -1120- END-IF */
                }


                /*" -1122- END-IF */
            }


            /*" -1123- IF V1ENDO-TIPO-END NOT EQUAL '3' AND '5' */

            if (!V1ENDO_TIPO_END.In("3", "5"))
            {

                /*" -1124- DISPLAY 'EM0202B - TP.ENDOSSO INVALIDO P/EMISSAO CHEQUES' */
                _.Display($"EM0202B - TP.ENDOSSO INVALIDO P/EMISSAO CHEQUES");

                /*" -1126- DISPLAY 'APOLICE - ' V1EDIA-NUM-APOL ' ENDOSSO - ' V1EDIA-NRENDOS */

                $"APOLICE - {V1EDIA_NUM_APOL} ENDOSSO - {V1EDIA_NRENDOS}"
                .Display();

                /*" -1128- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1129- MOVE V1EDIA-NUM-APOL TO LBFFI01-APOLICE */
            _.Move(V1EDIA_NUM_APOL, W.LBFFI01_REGISTRO.LBFFI01_APOLICE);

            /*" -1130- MOVE V1EDIA-NRENDOS TO LBFFI01-ENDOSSO */
            _.Move(V1EDIA_NRENDOS, W.LBFFI01_REGISTRO.LBFFI01_ENDOSSO);

            /*" -1131- MOVE V1APOL-NOME TO LBFFI01-SEGURADO */
            _.Move(V1APOL_NOME, W.LBFFI01_REGISTRO.LBFFI01_SEGURADO);

            /*" -1132- MOVE V1HIST-VLPRMTOT TO LC04-VLPRMLIQ */
            _.Move(V1HIST_VLPRMTOT, W.LC04.FILLER_10.LC04_VLPRMLIQ);

            /*" -1135- MOVE LC04-VLPRMLIQ TO LBFFI01-VALOR WVALOR */
            _.Move(W.LC04.FILLER_10.LC04_VLPRMLIQ, W.LBFFI01_REGISTRO.LBFFI01_VALOR, W.WVALOR);

            /*" -1141- CALL 'PROEXTE1' USING WVALOR WRESPOSTA WAREA-1 WAREA-2 WAREA-3 */
            _.Call("PROEXTE1", W);

            /*" -1142- IF WRESPOSTA EQUAL 'SIM ' */

            if (W.WRESPOSTA == "SIM ")
            {

                /*" -1143- MOVE WAREA-1A TO WEXTENSO1 */
                _.Move(W.WAREA_1.WAREA_1A, W.WEXTENSO.WEXTENSO1);

                /*" -1144- MOVE WAREA-2A TO WEXTENSO2 */
                _.Move(W.WAREA_2.WAREA_2A, W.WEXTENSO.WEXTENSO2);

                /*" -1145- MOVE WAREA-3A TO WEXTENSO3 */
                _.Move(W.WAREA_3.WAREA_3A, W.WEXTENSO.WEXTENSO3);

                /*" -1146- ELSE */
            }
            else
            {


                /*" -1150- MOVE ALL '-' TO WEXTENSO1 WEXTENSO2 WEXTENSO3. */
                _.MoveAll("-", W.WEXTENSO.WEXTENSO1, W.WEXTENSO.WEXTENSO2, W.WEXTENSO.WEXTENSO3);
            }


            /*" -1151- MOVE WEXTENSO1 TO LBFFI01-EXTENSO1 */
            _.Move(W.WEXTENSO.WEXTENSO1, W.LBFFI01_REGISTRO.LBFFI01_EXTENSO1);

            /*" -1153- MOVE WEXTENSO2 TO LBFFI01-EXTENSO2 */
            _.Move(W.WEXTENSO.WEXTENSO2, W.LBFFI01_REGISTRO.LBFFI01_EXTENSO2);

            /*" -1155- PERFORM R1500-00-LER-FONTE. */

            R1500_00_LER_FONTE_SECTION();

            /*" -1156- IF V1EDIA-CODRELAT = 'EM0202B1' */

            if (V1EDIA_CODRELAT == "EM0202B1")
            {

                /*" -1158- PERFORM R1700-00-AUTORIZA-EMISSAO. */

                R1700_00_AUTORIZA_EMISSAO_SECTION();
            }


            /*" -1159- IF V1EDIA-NUM-APOL = 0104500000273 */

            if (V1EDIA_NUM_APOL == 0104500000273)
            {

                /*" -1159- PERFORM R1700-00-AUTORIZA-EMISSAO. */

                R1700_00_AUTORIZA_EMISSAO_SECTION();
            }


            /*" -0- FLUXCONTROL_PERFORM R1000_10_LEITURA */

            R1000_10_LEITURA();

        }

        [StopWatch]
        /*" R1000-10-LEITURA */
        private void R1000_10_LEITURA(bool isPerform = false)
        {
            /*" -1163- PERFORM R0900-00-LER-TRELAT. */

            R0900_00_LER_TRELAT_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-LER-HISTOPARC-SECTION */
        private void R1100_00_LER_HISTOPARC_SECTION()
        {
            /*" -1176- MOVE '110' TO WNR-EXEC-SQL */
            _.Move("110", W.W_NUMDOC.WABEND.WNR_EXEC_SQL);

            /*" -1209- PERFORM R1100_00_LER_HISTOPARC_DB_SELECT_1 */

            R1100_00_LER_HISTOPARC_DB_SELECT_1();

            /*" -1212- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1213- DISPLAY 'EM0202B - ERRO NO SELECT DA V1HISTOPARC' */
                _.Display($"EM0202B - ERRO NO SELECT DA V1HISTOPARC");

                /*" -1215- DISPLAY 'APOLICE - ' V1EDIA-NUM-APOL ' ENDOSSO - ' V1EDIA-NRENDOS */

                $"APOLICE - {V1EDIA_NUM_APOL} ENDOSSO - {V1EDIA_NRENDOS}"
                .Display();

                /*" -1215- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1100-00-LER-HISTOPARC-DB-SELECT-1 */
        public void R1100_00_LER_HISTOPARC_DB_SELECT_1()
        {
            /*" -1209- EXEC SQL SELECT NUM_APOLICE , NRENDOS , NRPARCEL , DACPARC , DTMOVTO , OPERACAO , OCORHIST , PRM_TARIFARIO, VAL_DESCONTO , VLPRMLIQ , VLADIFRA , VLCUSEMI , VLIOCC , VLPRMTOT , VLPREMIO , DTVENCTO , BCOCOBR , AGECOBR , NRAVISO , NRENDOCA , SITCONTB , COD_USUARIO , RNUDOC , VALUE(DTQITBCO, DATE( '9999-12-31' )), VALUE(COD_EMPRESA, 0) INTO :V1HIST-NUM-APOL , :V1HIST-NRENDOS , :V1HIST-NRPARCEL , :V1HIST-DACPARC , :V1HIST-DTMOVTO , :V1HIST-OPERACAO , :V1HIST-OCORHIST , :V1HIST-PRM-TARIF , :V1HIST-DESCONTO , :V1HIST-VLPRMLIQ , :V1HIST-VLADIFRA , :V1HIST-VLCUSEMI , :V1HIST-VLIOCC , :V1HIST-VLPRMTOT , :V1HIST-VLPREMIO , :V1HIST-DTVENCTO , :V1HIST-BCOCOBR , :V1HIST-AGECOBR , :V1HIST-NRAVISO , :V1HIST-NRENDOCA , :V1HIST-SITCONTB , :V1HIST-USUARIO , :V1HIST-RNUDOC , :V1HIST-DTQITBCO , :V1HIST-EMPRESA FROM SEGUROS.V1HISTOPARC WHERE NUM_APOLICE = :V1EDIA-NUM-APOL AND NRENDOS = :V1EDIA-NRENDOS AND NRPARCEL = 0 AND OPERACAO = 101 END-EXEC. */

            var r1100_00_LER_HISTOPARC_DB_SELECT_1_Query1 = new R1100_00_LER_HISTOPARC_DB_SELECT_1_Query1()
            {
                V1EDIA_NUM_APOL = V1EDIA_NUM_APOL.ToString(),
                V1EDIA_NRENDOS = V1EDIA_NRENDOS.ToString(),
            };

            var executed_1 = R1100_00_LER_HISTOPARC_DB_SELECT_1_Query1.Execute(r1100_00_LER_HISTOPARC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1HIST_NUM_APOL, V1HIST_NUM_APOL);
                _.Move(executed_1.V1HIST_NRENDOS, V1HIST_NRENDOS);
                _.Move(executed_1.V1HIST_NRPARCEL, V1HIST_NRPARCEL);
                _.Move(executed_1.V1HIST_DACPARC, V1HIST_DACPARC);
                _.Move(executed_1.V1HIST_DTMOVTO, V1HIST_DTMOVTO);
                _.Move(executed_1.V1HIST_OPERACAO, V1HIST_OPERACAO);
                _.Move(executed_1.V1HIST_OCORHIST, V1HIST_OCORHIST);
                _.Move(executed_1.V1HIST_PRM_TARIF, V1HIST_PRM_TARIF);
                _.Move(executed_1.V1HIST_DESCONTO, V1HIST_DESCONTO);
                _.Move(executed_1.V1HIST_VLPRMLIQ, V1HIST_VLPRMLIQ);
                _.Move(executed_1.V1HIST_VLADIFRA, V1HIST_VLADIFRA);
                _.Move(executed_1.V1HIST_VLCUSEMI, V1HIST_VLCUSEMI);
                _.Move(executed_1.V1HIST_VLIOCC, V1HIST_VLIOCC);
                _.Move(executed_1.V1HIST_VLPRMTOT, V1HIST_VLPRMTOT);
                _.Move(executed_1.V1HIST_VLPREMIO, V1HIST_VLPREMIO);
                _.Move(executed_1.V1HIST_DTVENCTO, V1HIST_DTVENCTO);
                _.Move(executed_1.V1HIST_BCOCOBR, V1HIST_BCOCOBR);
                _.Move(executed_1.V1HIST_AGECOBR, V1HIST_AGECOBR);
                _.Move(executed_1.V1HIST_NRAVISO, V1HIST_NRAVISO);
                _.Move(executed_1.V1HIST_NRENDOCA, V1HIST_NRENDOCA);
                _.Move(executed_1.V1HIST_SITCONTB, V1HIST_SITCONTB);
                _.Move(executed_1.V1HIST_USUARIO, V1HIST_USUARIO);
                _.Move(executed_1.V1HIST_RNUDOC, V1HIST_RNUDOC);
                _.Move(executed_1.V1HIST_DTQITBCO, V1HIST_DTQITBCO);
                _.Move(executed_1.V1HIST_EMPRESA, V1HIST_EMPRESA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-LER-PARCELA-SECTION */
        private void R1200_00_LER_PARCELA_SECTION()
        {
            /*" -1230- MOVE '120' TO WNR-EXEC-SQL */
            _.Move("120", W.W_NUMDOC.WABEND.WNR_EXEC_SQL);

            /*" -1238- PERFORM R1200_00_LER_PARCELA_DB_SELECT_1 */

            R1200_00_LER_PARCELA_DB_SELECT_1();

            /*" -1244- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1246- IF SQLCODE = 100 AND V1EDIA-CODRELAT = 'EM0202B2' */

                if (DB.SQLCODE == 100 && V1EDIA_CODRELAT == "EM0202B2")
                {

                    /*" -1254- PERFORM R1200_00_LER_PARCELA_DB_SELECT_2 */

                    R1200_00_LER_PARCELA_DB_SELECT_2();

                    /*" -1257- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -1258- DISPLAY 'EM0202B - ERRO NO SELECT DA V1PARCELA' */
                        _.Display($"EM0202B - ERRO NO SELECT DA V1PARCELA");

                        /*" -1260- DISPLAY 'APOLICE - ' V1EDIA-NUM-APOL ' ENDOSSO - ' V1EDIA-NRENDOS */

                        $"APOLICE - {V1EDIA_NUM_APOL} ENDOSSO - {V1EDIA_NRENDOS}"
                        .Display();

                        /*" -1261- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -1263- ELSE NEXT SENTENCE */
                    }
                    else
                    {


                        /*" -1264- ELSE */
                    }

                }
                else
                {


                    /*" -1265- DISPLAY 'EM0202B - ERRO NO SELECT DA V1PARCELA' */
                    _.Display($"EM0202B - ERRO NO SELECT DA V1PARCELA");

                    /*" -1267- DISPLAY 'APOLICE - ' V1EDIA-NUM-APOL ' ENDOSSO - ' V1EDIA-NRENDOS */

                    $"APOLICE - {V1EDIA_NUM_APOL} ENDOSSO - {V1EDIA_NRENDOS}"
                    .Display();

                    /*" -1267- MOVE 'S' TO FLAG-ERRO. */
                    _.Move("S", W.FLAG_ERRO);
                }

            }


        }

        [StopWatch]
        /*" R1200-00-LER-PARCELA-DB-SELECT-1 */
        public void R1200_00_LER_PARCELA_DB_SELECT_1()
        {
            /*" -1238- EXEC SQL SELECT OCORHIST INTO :V1PARC-OCORHIST FROM SEGUROS.V1PARCELA WHERE NUM_APOLICE = :V1EDIA-NUM-APOL AND NRENDOS = :V1EDIA-NRENDOS AND NRPARCEL = 0 AND SITUACAO = '0' END-EXEC. */

            var r1200_00_LER_PARCELA_DB_SELECT_1_Query1 = new R1200_00_LER_PARCELA_DB_SELECT_1_Query1()
            {
                V1EDIA_NUM_APOL = V1EDIA_NUM_APOL.ToString(),
                V1EDIA_NRENDOS = V1EDIA_NRENDOS.ToString(),
            };

            var executed_1 = R1200_00_LER_PARCELA_DB_SELECT_1_Query1.Execute(r1200_00_LER_PARCELA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1PARC_OCORHIST, V1PARC_OCORHIST);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-LER-PARCELA-DB-SELECT-2 */
        public void R1200_00_LER_PARCELA_DB_SELECT_2()
        {
            /*" -1254- EXEC SQL SELECT OCORHIST INTO :V1PARC-OCORHIST FROM SEGUROS.V1PARCELA WHERE NUM_APOLICE = :V1EDIA-NUM-APOL AND NRENDOS = :V1EDIA-NRENDOS AND NRPARCEL = 0 AND SITUACAO = '1' END-EXEC */

            var r1200_00_LER_PARCELA_DB_SELECT_2_Query1 = new R1200_00_LER_PARCELA_DB_SELECT_2_Query1()
            {
                V1EDIA_NUM_APOL = V1EDIA_NUM_APOL.ToString(),
                V1EDIA_NRENDOS = V1EDIA_NRENDOS.ToString(),
            };

            var executed_1 = R1200_00_LER_PARCELA_DB_SELECT_2_Query1.Execute(r1200_00_LER_PARCELA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1PARC_OCORHIST, V1PARC_OCORHIST);
            }


        }

        [StopWatch]
        /*" R1300-00-LER-ENDOSSO-SECTION */
        private void R1300_00_LER_ENDOSSO_SECTION()
        {
            /*" -1280- MOVE '130' TO WNR-EXEC-SQL */
            _.Move("130", W.W_NUMDOC.WABEND.WNR_EXEC_SQL);

            /*" -1292- PERFORM R1300_00_LER_ENDOSSO_DB_SELECT_1 */

            R1300_00_LER_ENDOSSO_DB_SELECT_1();

            /*" -1295- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1296- DISPLAY 'EM0202B - ERRO NO SELECT DA V0ENDOSSO' */
                _.Display($"EM0202B - ERRO NO SELECT DA V0ENDOSSO");

                /*" -1298- DISPLAY 'APOLICE - ' V1EDIA-NUM-APOL ' ENDOSSO - ' V1EDIA-NRENDOS */

                $"APOLICE - {V1EDIA_NUM_APOL} ENDOSSO - {V1EDIA_NRENDOS}"
                .Display();

                /*" -1298- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1300-00-LER-ENDOSSO-DB-SELECT-1 */
        public void R1300_00_LER_ENDOSSO_DB_SELECT_1()
        {
            /*" -1292- EXEC SQL SELECT TIPO_ENDOSSO ,RAMO ,CODPRODU ,OCORR_ENDERECO INTO :V1ENDO-TIPO-END ,:V1ENDO-RAMO ,:V1ENDO-CODPRODU ,:V1ENDO-OCORREND FROM SEGUROS.V0ENDOSSO WHERE NUM_APOLICE = :V1EDIA-NUM-APOL AND NRENDOS = :V1EDIA-NRENDOS END-EXEC. */

            var r1300_00_LER_ENDOSSO_DB_SELECT_1_Query1 = new R1300_00_LER_ENDOSSO_DB_SELECT_1_Query1()
            {
                V1EDIA_NUM_APOL = V1EDIA_NUM_APOL.ToString(),
                V1EDIA_NRENDOS = V1EDIA_NRENDOS.ToString(),
            };

            var executed_1 = R1300_00_LER_ENDOSSO_DB_SELECT_1_Query1.Execute(r1300_00_LER_ENDOSSO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1ENDO_TIPO_END, V1ENDO_TIPO_END);
                _.Move(executed_1.V1ENDO_RAMO, V1ENDO_RAMO);
                _.Move(executed_1.V1ENDO_CODPRODU, V1ENDO_CODPRODU);
                _.Move(executed_1.V1ENDO_OCORREND, V1ENDO_OCORREND);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-LER-APOLICE-SECTION */
        private void R1400_00_LER_APOLICE_SECTION()
        {
            /*" -1310- IF V1EDIA-RAMO NOT EQUAL 72 AND 82 */

            if (!V1EDIA_RAMO.In("72", "82"))
            {

                /*" -1312- MOVE '140' TO WNR-EXEC-SQL */
                _.Move("140", W.W_NUMDOC.WABEND.WNR_EXEC_SQL);

                /*" -1319- PERFORM R1400_00_LER_APOLICE_DB_SELECT_1 */

                R1400_00_LER_APOLICE_DB_SELECT_1();

                /*" -1322- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1323- DISPLAY 'EM0202B - ERRO NO SELECT DA V1APOLICE' */
                    _.Display($"EM0202B - ERRO NO SELECT DA V1APOLICE");

                    /*" -1324- DISPLAY 'APOLICE - ' V1EDIA-NUM-APOL */
                    _.Display($"APOLICE - {V1EDIA_NUM_APOL}");

                    /*" -1325- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1326- END-IF */
                }


                /*" -1327- ELSE */
            }
            else
            {


                /*" -1329- MOVE '141' TO WNR-EXEC-SQL */
                _.Move("141", W.W_NUMDOC.WABEND.WNR_EXEC_SQL);

                /*" -1341- PERFORM R1400_00_LER_APOLICE_DB_SELECT_2 */

                R1400_00_LER_APOLICE_DB_SELECT_2();

                /*" -1344- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1345- DISPLAY 'EM0202B - ERRO NO SELECT DA V0ENDOSSO_BILHETE' */
                    _.Display($"EM0202B - ERRO NO SELECT DA V0ENDOSSO_BILHETE");

                    /*" -1346- DISPLAY 'APOLICE - ' V1EDIA-NUM-APOL */
                    _.Display($"APOLICE - {V1EDIA_NUM_APOL}");

                    /*" -1347- DISPLAY 'ENDOSSO - ' V1EDIA-NRENDOS */
                    _.Display($"ENDOSSO - {V1EDIA_NRENDOS}");

                    /*" -1347- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1400-00-LER-APOLICE-DB-SELECT-1 */
        public void R1400_00_LER_APOLICE_DB_SELECT_1()
        {
            /*" -1319- EXEC SQL SELECT NOME ,CODCLIEN INTO :V1APOL-NOME ,:V1APOL-CODCLIEN FROM SEGUROS.V1APOLICE WHERE NUM_APOLICE = :V1EDIA-NUM-APOL END-EXEC */

            var r1400_00_LER_APOLICE_DB_SELECT_1_Query1 = new R1400_00_LER_APOLICE_DB_SELECT_1_Query1()
            {
                V1EDIA_NUM_APOL = V1EDIA_NUM_APOL.ToString(),
            };

            var executed_1 = R1400_00_LER_APOLICE_DB_SELECT_1_Query1.Execute(r1400_00_LER_APOLICE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1APOL_NOME, V1APOL_NOME);
                _.Move(executed_1.V1APOL_CODCLIEN, V1APOL_CODCLIEN);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-LER-APOLICE-DB-SELECT-2 */
        public void R1400_00_LER_APOLICE_DB_SELECT_2()
        {
            /*" -1341- EXEC SQL SELECT C.NOME_RAZAO ,C.COD_CLIENTE INTO :V1APOL-NOME ,:V1APOL-CODCLIEN FROM SEGUROS.V0BILHETE_ENDOSSO A, SEGUROS.V0BILHETE B, SEGUROS.V0CLIENTE C WHERE A.NUM_APOLICE = :V1EDIA-NUM-APOL AND A.NRENDOS = :V1EDIA-NRENDOS AND B.NUMBIL = A.NUMBIL AND C.COD_CLIENTE = B.CODCLIEN END-EXEC */

            var r1400_00_LER_APOLICE_DB_SELECT_2_Query1 = new R1400_00_LER_APOLICE_DB_SELECT_2_Query1()
            {
                V1EDIA_NUM_APOL = V1EDIA_NUM_APOL.ToString(),
                V1EDIA_NRENDOS = V1EDIA_NRENDOS.ToString(),
            };

            var executed_1 = R1400_00_LER_APOLICE_DB_SELECT_2_Query1.Execute(r1400_00_LER_APOLICE_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1APOL_NOME, V1APOL_NOME);
                _.Move(executed_1.V1APOL_CODCLIEN, V1APOL_CODCLIEN);
            }


        }

        [StopWatch]
        /*" R1410-00-LER-APOLICE-SECTION */
        private void R1410_00_LER_APOLICE_SECTION()
        {
            /*" -1358- MOVE '141' TO WNR-EXEC-SQL. */
            _.Move("141", W.W_NUMDOC.WABEND.WNR_EXEC_SQL);

            /*" -1365- PERFORM R1410_00_LER_APOLICE_DB_SELECT_1 */

            R1410_00_LER_APOLICE_DB_SELECT_1();

            /*" -1368- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1369- DISPLAY 'EM0202B - ERRO NO SELECT DA V1APOLICE' */
                _.Display($"EM0202B - ERRO NO SELECT DA V1APOLICE");

                /*" -1370- DISPLAY 'APOLICE - ' V1EDIA-NUM-APOL */
                _.Display($"APOLICE - {V1EDIA_NUM_APOL}");

                /*" -1370- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1410-00-LER-APOLICE-DB-SELECT-1 */
        public void R1410_00_LER_APOLICE_DB_SELECT_1()
        {
            /*" -1365- EXEC SQL SELECT NOME ,CODCLIEN INTO :V1APOL-NOME ,:V1APOL-CODCLIEN FROM SEGUROS.V1APOLICE WHERE NUM_APOLICE = :V1EDIA-NUM-APOL END-EXEC. */

            var r1410_00_LER_APOLICE_DB_SELECT_1_Query1 = new R1410_00_LER_APOLICE_DB_SELECT_1_Query1()
            {
                V1EDIA_NUM_APOL = V1EDIA_NUM_APOL.ToString(),
            };

            var executed_1 = R1410_00_LER_APOLICE_DB_SELECT_1_Query1.Execute(r1410_00_LER_APOLICE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1APOL_NOME, V1APOL_NOME);
                _.Move(executed_1.V1APOL_CODCLIEN, V1APOL_CODCLIEN);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1410_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-LER-FONTE-SECTION */
        private void R1500_00_LER_FONTE_SECTION()
        {
            /*" -1383- MOVE '150' TO WNR-EXEC-SQL. */
            _.Move("150", W.W_NUMDOC.WABEND.WNR_EXEC_SQL);

            /*" -1388- PERFORM R1500_00_LER_FONTE_DB_SELECT_1 */

            R1500_00_LER_FONTE_DB_SELECT_1();

            /*" -1391- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1392- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1393- MOVE ALL '*' TO V1FONT-NOMEFTE */
                    _.MoveAll("*", V1FONT_NOMEFTE);

                    /*" -1394- ELSE */
                }
                else
                {


                    /*" -1395- DISPLAY 'EM0202B - ERRO NO SELECT DA V1FONTE' */
                    _.Display($"EM0202B - ERRO NO SELECT DA V1FONTE");

                    /*" -1397- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1399- MOVE V1FONT-NOMEFTE TO LBFFI01-ORGAO. */
            _.Move(V1FONT_NOMEFTE, W.LBFFI01_REGISTRO.LBFFI01_ORGAO);

            /*" -1404- PERFORM R1500_00_LER_FONTE_DB_SELECT_2 */

            R1500_00_LER_FONTE_DB_SELECT_2();

            /*" -1407- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1408- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1409- MOVE ALL '*' TO V1FONT-CIDADE */
                    _.MoveAll("*", V1FONT_CIDADE);

                    /*" -1410- ELSE */
                }
                else
                {


                    /*" -1411- DISPLAY 'EM0202B - ERRO NO SELECT DA V1FONTE' */
                    _.Display($"EM0202B - ERRO NO SELECT DA V1FONTE");

                    /*" -1413- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1413- MOVE V1FONT-CIDADE TO LBFFI01-LOCAL. */
            _.Move(V1FONT_CIDADE, W.LBFFI01_REGISTRO.LBFFI01_LOCAL);

        }

        [StopWatch]
        /*" R1500-00-LER-FONTE-DB-SELECT-1 */
        public void R1500_00_LER_FONTE_DB_SELECT_1()
        {
            /*" -1388- EXEC SQL SELECT NOMEFTE INTO :V1FONT-NOMEFTE FROM SEGUROS.V1FONTE WHERE FONTE = :V1EDIA-ORGAO END-EXEC. */

            var r1500_00_LER_FONTE_DB_SELECT_1_Query1 = new R1500_00_LER_FONTE_DB_SELECT_1_Query1()
            {
                V1EDIA_ORGAO = V1EDIA_ORGAO.ToString(),
            };

            var executed_1 = R1500_00_LER_FONTE_DB_SELECT_1_Query1.Execute(r1500_00_LER_FONTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1FONT_NOMEFTE, V1FONT_NOMEFTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-LER-FONTE-DB-SELECT-2 */
        public void R1500_00_LER_FONTE_DB_SELECT_2()
        {
            /*" -1404- EXEC SQL SELECT CIDADE INTO :V1FONT-CIDADE FROM SEGUROS.V1FONTE WHERE FONTE = :V1EDIA-FONTE END-EXEC. */

            var r1500_00_LER_FONTE_DB_SELECT_2_Query1 = new R1500_00_LER_FONTE_DB_SELECT_2_Query1()
            {
                V1EDIA_FONTE = V1EDIA_FONTE.ToString(),
            };

            var executed_1 = R1500_00_LER_FONTE_DB_SELECT_2_Query1.Execute(r1500_00_LER_FONTE_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1FONT_CIDADE, V1FONT_CIDADE);
            }


        }

        [StopWatch]
        /*" R1600-00-IMPRIME-DETALHE-SECTION */
        private void R1600_00_IMPRIME_DETALHE_SECTION()
        {
            /*" -1425- IF W88-CONTROLE-OFF */

            if (FILLER_0["W88_CONTROLE_OFF"])
            {

                /*" -1426- PERFORM R0500-00-IMPRIME-CONTROLE */

                R0500_00_IMPRIME_CONTROLE_SECTION();

                /*" -1428- END-IF */
            }


            /*" -1430- WRITE REG-EM0202M01 FROM LBFFI01-REGISTRO */
            _.Move(W.LBFFI01_REGISTRO.GetMoveValues(), REG_EM0202M01);

            EM0202M01.Write(REG_EM0202M01.GetMoveValues().ToString());

            /*" -1431- ADD 1 TO IND. */
            W.IND.Value = W.IND + 1;

            /*" -1431- ADD 1 TO WS-CT-RECIBOS. */
            W.WS_CT_RECIBOS.Value = W.WS_CT_RECIBOS + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1700-00-AUTORIZA-EMISSAO-SECTION */
        private void R1700_00_AUTORIZA_EMISSAO_SECTION()
        {
            /*" -1467- IF ( V1HIST-NUM-APOL EQUAL 1103100121720 AND V1HIST-NRENDOS EQUAL 2) OR ( V1HIST-NUM-APOL EQUAL 1003100658239 AND V1HIST-NRENDOS EQUAL 1) OR ( V1HIST-NUM-APOL EQUAL 1003100702761 AND V1HIST-NRENDOS EQUAL 2) OR ( V1HIST-NUM-APOL EQUAL 1103100100698 AND V1HIST-NRENDOS EQUAL 1) OR ( V1HIST-NUM-APOL EQUAL 1103100161899 AND V1HIST-NRENDOS EQUAL 1) OR ( V1HIST-NUM-APOL EQUAL 1103100160859) OR ( V1HIST-NUM-APOL EQUAL 1103100154513) */

            if ((V1HIST_NUM_APOL.GetMoveValues().ToInt() == 1103100121720 && V1HIST_NRENDOS == 2) || (V1HIST_NUM_APOL.GetMoveValues().ToInt() == 1003100658239 && V1HIST_NRENDOS == 1) || (V1HIST_NUM_APOL.GetMoveValues().ToInt() == 1003100702761 && V1HIST_NRENDOS == 2) || (V1HIST_NUM_APOL.GetMoveValues().ToInt() == 1103100100698 && V1HIST_NRENDOS == 1) || (V1HIST_NUM_APOL.GetMoveValues().ToInt() == 1103100161899 && V1HIST_NRENDOS == 1) || (V1HIST_NUM_APOL.GetMoveValues().ToInt() == 1103100160859) || (V1HIST_NUM_APOL.GetMoveValues().ToInt() == 1103100154513))
            {

                /*" -1469- GO TO R1700-PULA-GE0540S. */

                R1700_PULA_GE0540S(); //GOTO
                return;
            }


            /*" -1471- MOVE SPACES TO WPARM-TEMCONTA */
            _.Move("", WPARAMETROS.WPARM_TEMCONTA);

            /*" -1472- IF V1HIST-VLPRMTOT NOT GREATER ZEROS */

            if (V1HIST_VLPRMTOT <= 00)
            {

                /*" -1473- ADD 1 TO AC-VALOR */
                AC_VALOR.Value = AC_VALOR + 1;

                /*" -1474- ELSE */
            }
            else
            {


                /*" -1476- PERFORM R2000-00-CHAMA-GE0540S */

                R2000_00_CHAMA_GE0540S_SECTION();

                /*" -1477- MOVE SPACES TO WTEM-CB041 */
                _.Move("", W.WTEM_CB041);

                /*" -1478- MOVE SPACES TO WPARM-TEMCONTA */
                _.Move("", WPARAMETROS.WPARM_TEMCONTA);

                /*" -1479- MOVE V1HIST-NUM-APOL TO CB041-NUM-APOLICE */
                _.Move(V1HIST_NUM_APOL, CB041.DCLCB_PESS_PARCELA.CB041_NUM_APOLICE);

                /*" -1480- MOVE V1HIST-NRENDOS TO CB041-NUM-ENDOSSO */
                _.Move(V1HIST_NRENDOS, CB041.DCLCB_PESS_PARCELA.CB041_NUM_ENDOSSO);

                /*" -1482- MOVE V1HIST-NRPARCEL TO CB041-NUM-PARCELA */
                _.Move(V1HIST_NRPARCEL, CB041.DCLCB_PESS_PARCELA.CB041_NUM_PARCELA);

                /*" -1484- PERFORM R2100-00-VERIFICA-CB041 */

                R2100_00_VERIFICA_CB041_SECTION();

                /*" -1485- IF WTEM-CB041 EQUAL 'S' */

                if (W.WTEM_CB041 == "S")
                {

                    /*" -1486- MOVE 'S' TO WPARM-TEMCONTA */
                    _.Move("S", WPARAMETROS.WPARM_TEMCONTA);

                    /*" -1488- END-IF */
                }


                /*" -1489- IF WPARM-TEMCONTA EQUAL 'S' */

                if (WPARAMETROS.WPARM_TEMCONTA == "S")
                {

                    /*" -1494- ADD 1 TO AC-CONVENIO */
                    AC_CONVENIO.Value = AC_CONVENIO + 1;

                    /*" -1502- IF ( ( V1EDIA-ORGAO EQUAL 110 ) OR ( V1EDIA-ORGAO EQUAL 10 AND V1ENDO-RAMO EQUAL 53 AND V1ENDO-CODPRODU EQUAL 5302 OR 5303 OR 5304 ) ) AND WTEM-CB041 EQUAL 'N' */

                    if (((V1EDIA_ORGAO == 110) || (V1EDIA_ORGAO == 10 && V1ENDO_RAMO == 53 && V1ENDO_CODPRODU.In("5302", "5303", "5304"))) && W.WTEM_CB041 == "N")
                    {

                        /*" -1503- ADD 1 TO WS-CT-CBCONCC */
                        W.WS_CT_CBCONCC.Value = W.WS_CT_CBCONCC + 1;

                        /*" -1504- PERFORM R3000-00-TRATA-CBCONDEV */

                        R3000_00_TRATA_CBCONDEV_SECTION();

                        /*" -1506- END-IF */
                    }


                    /*" -1506- GO TO R1700-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -0- FLUXCONTROL_PERFORM R1700_PULA_GE0540S */

            R1700_PULA_GE0540S();

        }

        [StopWatch]
        /*" R1700-PULA-GE0540S */
        private void R1700_PULA_GE0540S(bool isPerform = false)
        {
            /*" -1542- IF (V1ENDO-RAMO EQUAL 68 OR 61 OR 65) AND V1ENDO-CODPRODU NOT EQUAL 6814 */

            if ((V1ENDO_RAMO.In("68", "61", "65")) && V1ENDO_CODPRODU != 6814)
            {

                /*" -1543- GO TO R1700-10-BAIXA-RESTITUICAO */

                R1700_10_BAIXA_RESTITUICAO(); //GOTO
                return;

                /*" -1545- END-IF. */
            }


            /*" -1549- IF V1ENDO-CODPRODU = 4801 OR 4812 OR 7001 OR 7704 OR 7711 OR 1408 OR 7705 OR 7712 OR 1409 */

            if (V1ENDO_CODPRODU.In("4801", "4812", "7001", "7704", "7711", "1408", "7705", "7712", "1409"))
            {

                /*" -1550- GO TO R1700-10-BAIXA-RESTITUICAO */

                R1700_10_BAIXA_RESTITUICAO(); //GOTO
                return;

                /*" -1552- END-IF. */
            }


            /*" -1555- IF ( V1ENDO-CODPRODU EQUAL 7716 AND (V1HIST-NUM-APOL EQUAL 0107700000038 OR V1HIST-NUM-APOL EQUAL 0107700000040)) */

            if ((V1ENDO_CODPRODU == 7716 && (V1HIST_NUM_APOL == 0107700000038 || V1HIST_NUM_APOL == 0107700000040)))
            {

                /*" -1556- GO TO R1700-10-BAIXA-RESTITUICAO */

                R1700_10_BAIXA_RESTITUICAO(); //GOTO
                return;

                /*" -1558- END-IF. */
            }


            /*" -1563- PERFORM R1710-00-GRAVA-TCHEQUES */

            R1710_00_GRAVA_TCHEQUES_SECTION();

            /*" -1564- IF WS-GERACHEQUE EQUAL 'S' */

            if (W.WS_GERACHEQUE == "S")
            {

                /*" -1570- IF ( ( V1EDIA-ORGAO EQUAL 110 ) OR ( V1EDIA-ORGAO EQUAL 10 AND V1ENDO-RAMO EQUAL 53 AND V1ENDO-CODPRODU EQUAL 5302 OR 5303 OR 5304 ) ) */

                if (((V1EDIA_ORGAO == 110) || (V1EDIA_ORGAO == 10 && V1ENDO_RAMO == 53 && V1ENDO_CODPRODU.In("5302", "5303", "5304"))))
                {

                    /*" -1571- ADD 1 TO WS-CT-CBCONCH */
                    W.WS_CT_CBCONCH.Value = W.WS_CT_CBCONCH + 1;

                    /*" -1571- PERFORM R3000-00-TRATA-CBCONDEV. */

                    R3000_00_TRATA_CBCONDEV_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R1700-10-BAIXA-RESTITUICAO */
        private void R1700_10_BAIXA_RESTITUICAO(bool isPerform = false)
        {
            /*" -1577- PERFORM R1720-00-SELECT-V0HISTOPARC. */

            R1720_00_SELECT_V0HISTOPARC_SECTION();

            /*" -1578- IF V0HIST-VLPRMTOT NOT EQUAL ZEROS */

            if (V0HIST_VLPRMTOT != 00)
            {

                /*" -1580- MOVE 0802 TO V1HIST-OPERACAO */
                _.Move(0802, V1HIST_OPERACAO);

                /*" -1581- COMPUTE V2HIST-PRM-TARIF = V0HIST-PRM-TARIF * (-1) */
                V2HIST_PRM_TARIF.Value = V0HIST_PRM_TARIF * (-1);

                /*" -1582- COMPUTE V2HIST-DESCONTO = V0HIST-DESCONTO * (-1) */
                V2HIST_DESCONTO.Value = V0HIST_DESCONTO * (-1);

                /*" -1583- COMPUTE V2HIST-VLPRMLIQ = V0HIST-VLPRMLIQ * (-1) */
                V2HIST_VLPRMLIQ.Value = V0HIST_VLPRMLIQ * (-1);

                /*" -1584- COMPUTE V2HIST-VLADIFRA = V0HIST-VLADIFRA * (-1) */
                V2HIST_VLADIFRA.Value = V0HIST_VLADIFRA * (-1);

                /*" -1585- COMPUTE V2HIST-VLCUSEMI = V0HIST-VLCUSEMI * (-1) */
                V2HIST_VLCUSEMI.Value = V0HIST_VLCUSEMI * (-1);

                /*" -1586- COMPUTE V2HIST-VLIOCC = V0HIST-VLIOCC * (-1) */
                V2HIST_VLIOCC.Value = V0HIST_VLIOCC * (-1);

                /*" -1588- COMPUTE V2HIST-VLPRMTOT = V0HIST-VLPRMTOT * (-1) */
                V2HIST_VLPRMTOT.Value = V0HIST_VLPRMTOT * (-1);

                /*" -1590- MOVE ZEROS TO V2HIST-VLPREMIO */
                _.Move(0, V2HIST_VLPREMIO);

                /*" -1592- PERFORM R1730-00-INSERT-V0HISTOPARC. */

                R1730_00_INSERT_V0HISTOPARC_SECTION();
            }


            /*" -1593- MOVE 0290 TO V1HIST-OPERACAO. */
            _.Move(0290, V1HIST_OPERACAO);

            /*" -1594- MOVE V1HIST-PRM-TARIF TO V2HIST-PRM-TARIF. */
            _.Move(V1HIST_PRM_TARIF, V2HIST_PRM_TARIF);

            /*" -1595- MOVE V1HIST-DESCONTO TO V2HIST-DESCONTO. */
            _.Move(V1HIST_DESCONTO, V2HIST_DESCONTO);

            /*" -1596- MOVE V1HIST-VLPRMLIQ TO V2HIST-VLPRMLIQ. */
            _.Move(V1HIST_VLPRMLIQ, V2HIST_VLPRMLIQ);

            /*" -1597- MOVE V1HIST-VLADIFRA TO V2HIST-VLADIFRA. */
            _.Move(V1HIST_VLADIFRA, V2HIST_VLADIFRA);

            /*" -1598- MOVE V1HIST-VLCUSEMI TO V2HIST-VLCUSEMI. */
            _.Move(V1HIST_VLCUSEMI, V2HIST_VLCUSEMI);

            /*" -1599- MOVE V1HIST-VLIOCC TO V2HIST-VLIOCC. */
            _.Move(V1HIST_VLIOCC, V2HIST_VLIOCC);

            /*" -1600- MOVE V1HIST-VLPRMTOT TO V2HIST-VLPRMTOT. */
            _.Move(V1HIST_VLPRMTOT, V2HIST_VLPRMTOT);

            /*" -1601- MOVE V1HIST-VLPRMTOT TO V2HIST-VLPREMIO. */
            _.Move(V1HIST_VLPRMTOT, V2HIST_VLPREMIO);

            /*" -1603- MOVE V1ENDO-CODPRODU TO LBFFI01-PRODUTO. */
            _.Move(V1ENDO_CODPRODU, W.LBFFI01_REGISTRO.LBFFI01_PRODUTO);

            /*" -1604- PERFORM R1730-00-INSERT-V0HISTOPARC. */

            R1730_00_INSERT_V0HISTOPARC_SECTION();

            /*" -1605- PERFORM R1740-00-UPDATE-V0PARCELA. */

            R1740_00_UPDATE_V0PARCELA_SECTION();

            /*" -1607- PERFORM R1750-00-UPDATE-V0ENDOSSO. */

            R1750_00_UPDATE_V0ENDOSSO_SECTION();

            /*" -1607- PERFORM R1600-00-IMPRIME-DETALHE. */

            R1600_00_IMPRIME_DETALHE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/

        [StopWatch]
        /*" R1710-00-GRAVA-TCHEQUES-SECTION */
        private void R1710_00_GRAVA_TCHEQUES_SECTION()
        {
            /*" -1620- MOVE '171' TO WNR-EXEC-SQL */
            _.Move("171", W.W_NUMDOC.WABEND.WNR_EXEC_SQL);

            /*" -1628- MOVE ZEROS TO V0CHEQ-CHQINT. */
            _.Move(0, V0CHEQ_CHQINT);

            /*" -1630- IF V1HIST-VLPRMLIQ EQUAL ZEROS OR V1HIST-VLPRMLIQ < ZEROS */

            if (V1HIST_VLPRMLIQ == 00 || V1HIST_VLPRMLIQ < 00)
            {

                /*" -1631- MOVE 'N' TO WS-GERACHEQUE */
                _.Move("N", W.WS_GERACHEQUE);

                /*" -1633- GO TO R1710-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1710_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1634- MOVE 'S' TO WS-GERACHEQUE */
            _.Move("S", W.WS_GERACHEQUE);

            /*" -1635- MOVE '3' TO V0CHEQ-TPMOVTO */
            _.Move("3", V0CHEQ_TPMOVTO);

            /*" -1636- MOVE V1EDIA-ORGAO TO V0CHEQ-FONTE */
            _.Move(V1EDIA_ORGAO, V0CHEQ_FONTE);

            /*" -1637- MOVE V1EDIA-NUM-APOL TO W-NUM-APOL */
            _.Move(V1EDIA_NUM_APOL, W.W_NUMDOC.W_NUM_APOL);

            /*" -1638- MOVE V1EDIA-NRENDOS TO W-NRENDOS */
            _.Move(V1EDIA_NRENDOS, W.W_NUMDOC.W_NRENDOS);

            /*" -1639- MOVE V1EDIA-RAMO TO W-RAMO-EMIS */
            _.Move(V1EDIA_RAMO, W.W_NUMDOC.W_RAMO_EMIS);

            /*" -1641- MOVE W-NUMDOC TO V0CHEQ-NUMDOC */
            _.Move(W.W_NUMDOC, V0CHEQ_NUMDOC);

            /*" -1642- IF V1EDIA-NUM-APOL = 6501000001 AND V1EDIA-NRENDOS = 201688 */

            if (V1EDIA_NUM_APOL == 6501000001 && V1EDIA_NRENDOS == 201688)
            {

                /*" -1644- MOVE 'FUNCEF FUND ECONOMIARIOS FEDERAIS' TO V0CHEQ-NOMFAV */
                _.Move("FUNCEF FUND ECONOMIARIOS FEDERAIS", V0CHEQ_NOMFAV);

                /*" -1645- ELSE */
            }
            else
            {


                /*" -1647- MOVE V1APOL-NOME TO V0CHEQ-NOMFAV. */
                _.Move(V1APOL_NOME, V0CHEQ_NOMFAV);
            }


            /*" -1649- MOVE V1HIST-VLPRMTOT TO V0CHEQ-VALCHQ */
            _.Move(V1HIST_VLPRMTOT, V0CHEQ_VALCHQ);

            /*" -1651- MOVE V1SIST-DTMOVABE-FI TO V0CHEQ-DTMOVTO */
            _.Move(V1SIST_DTMOVABE_FI, V0CHEQ_DTMOVTO);

            /*" -1653- PERFORM R1715-00-CALCULA-DIGITO */

            R1715_00_CALCULA_DIGITO_SECTION();

            /*" -1654- MOVE WNUMERO TO V0CHEQ-CHQINT */
            _.Move(WNUMERO, V0CHEQ_CHQINT);

            /*" -1655- MOVE WDIGITO TO V0CHEQ-DIGINT */
            _.Move(WDIGITO, V0CHEQ_DIGINT);

            /*" -1656- MOVE '0' TO V0CHEQ-SITUACAO */
            _.Move("0", V0CHEQ_SITUACAO);

            /*" -1657- MOVE '1' TO V0CHEQ-TIPPAG */
            _.Move("1", V0CHEQ_TIPPAG);

            /*" -1658- MOVE V1SIST-DTMOVABE TO V0CHEQ-DATCMP */
            _.Move(V1SIST_DTMOVABE, V0CHEQ_DATCMP);

            /*" -1660- MOVE V1FONT-CIDADE TO V0CHEQ-PRAPAG */
            _.Move(V1FONT_CIDADE, V0CHEQ_PRAPAG);

            /*" -1661- MOVE V1EDIA-NRENDOS TO V0CHEQ-NUMREC */
            _.Move(V1EDIA_NRENDOS, V0CHEQ_NUMREC);

            /*" -1662- MOVE 1 TO V0CHEQ-OCORHIST */
            _.Move(1, V0CHEQ_OCORHIST);

            /*" -1663- MOVE 0101 TO V0CHEQ-OPERACAO */
            _.Move(0101, V0CHEQ_OPERACAO);

            /*" -1664- MOVE 1204 TO V0CHEQ-CODDSA */
            _.Move(1204, V0CHEQ_CODDSA);

            /*" -1665- MOVE ZEROS TO V0CHEQ-VALIRF */
            _.Move(0, V0CHEQ_VALIRF);

            /*" -1666- MOVE ZEROS TO V0CHEQ-VALISS */
            _.Move(0, V0CHEQ_VALISS);

            /*" -1667- MOVE ZEROS TO V0CHEQ-VALIAP */
            _.Move(0, V0CHEQ_VALIAP);

            /*" -1668- MOVE ZEROS TO V0CHEQ-CODLAN */
            _.Move(0, V0CHEQ_CODLAN);

            /*" -1669- MOVE V1SIST-DTMOVABE-FI TO V0CHEQ-DATLAN */
            _.Move(V1SIST_DTMOVABE_FI, V0CHEQ_DATLAN);

            /*" -1670- MOVE ZEROS TO V0CHEQ-EMPRESA */
            _.Move(0, V0CHEQ_EMPRESA);

            /*" -1671- MOVE ZEROS TO V0CHEQ-CODFAV. */
            _.Move(0, V0CHEQ_CODFAV);

            /*" -1673- MOVE ZEROS TO V0CHEQ-VALINSS. */
            _.Move(0, V0CHEQ_VALINSS);

            /*" -1701- PERFORM R1710_00_GRAVA_TCHEQUES_DB_INSERT_1 */

            R1710_00_GRAVA_TCHEQUES_DB_INSERT_1();

            /*" -1704- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1705- DISPLAY 'EM0202B - ERRO NO INSERT DA V0CHEQUES' */
                _.Display($"EM0202B - ERRO NO INSERT DA V0CHEQUES");

                /*" -1706- DISPLAY 'CHEQUE ' V0CHEQ-CHQINT */
                _.Display($"CHEQUE {V0CHEQ_CHQINT}");

                /*" -1707- DISPLAY 'DIGITO ' V0CHEQ-DIGINT */
                _.Display($"DIGITO {V0CHEQ_DIGINT}");

                /*" -1708- DISPLAY 'TIPO   ' V0CHEQ-TPMOVTO */
                _.Display($"TIPO   {V0CHEQ_TPMOVTO}");

                /*" -1710- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1712- MOVE '17B' TO WNR-EXEC-SQL. */
            _.Move("17B", W.W_NUMDOC.WABEND.WNR_EXEC_SQL);

            /*" -1713- MOVE WNUMERO TO V0HCHE-CHQINT */
            _.Move(WNUMERO, V0HCHE_CHQINT);

            /*" -1714- MOVE WDIGITO TO V0HCHE-DIGINT */
            _.Move(WDIGITO, V0HCHE_DIGINT);

            /*" -1716- MOVE V1SIST-DTMOVABE-FI TO V0HCHE-DTMOVTO */
            _.Move(V1SIST_DTMOVABE_FI, V0HCHE_DTMOVTO);

            /*" -1717- MOVE 0101 TO V0HCHE-OPERACAO */
            _.Move(0101, V0HCHE_OPERACAO);

            /*" -1719- MOVE ZEROS TO V0HCHE-EMPRESA */
            _.Move(0, V0HCHE_EMPRESA);

            /*" -1729- PERFORM R1710_00_GRAVA_TCHEQUES_DB_INSERT_2 */

            R1710_00_GRAVA_TCHEQUES_DB_INSERT_2();

            /*" -1732- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1733- DISPLAY 'EM0202B - ERRO NO INSERT DA V0HISTCHEQ' */
                _.Display($"EM0202B - ERRO NO INSERT DA V0HISTCHEQ");

                /*" -1734- DISPLAY 'CHEQUE   ' V0HCHE-CHQINT */
                _.Display($"CHEQUE   {V0HCHE_CHQINT}");

                /*" -1735- DISPLAY 'DIGITO   ' V0HCHE-DIGINT */
                _.Display($"DIGITO   {V0HCHE_DIGINT}");

                /*" -1736- DISPLAY 'DATA     ' V0HCHE-DTMOVTO */
                _.Display($"DATA     {V0HCHE_DTMOVTO}");

                /*" -1737- DISPLAY 'OPERACAO ' V0HCHE-OPERACAO */
                _.Display($"OPERACAO {V0HCHE_OPERACAO}");

                /*" -1739- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1739- ADD 1 TO WS-CT-CHEQUES. */
            W.WS_CT_CHEQUES.Value = W.WS_CT_CHEQUES + 1;

        }

        [StopWatch]
        /*" R1710-00-GRAVA-TCHEQUES-DB-INSERT-1 */
        public void R1710_00_GRAVA_TCHEQUES_DB_INSERT_1()
        {
            /*" -1701- EXEC SQL INSERT INTO SEGUROS.V0CHEQUES VALUES (:V0CHEQ-TPMOVTO , :V0CHEQ-FONTE , :V0CHEQ-NUMDOC , :V0CHEQ-NOMFAV , :V0CHEQ-VALCHQ , :V0CHEQ-DTMOVTO , NULL , :V0CHEQ-CHQINT , :V0CHEQ-DIGINT , :V0CHEQ-SITUACAO, :V0CHEQ-TIPPAG , :V0CHEQ-DATCMP , :V0CHEQ-PRAPAG , :V0CHEQ-NUMREC , :V0CHEQ-OCORHIST, :V0CHEQ-OPERACAO, :V0CHEQ-CODDSA , :V0CHEQ-VALIRF , :V0CHEQ-VALISS , :V0CHEQ-VALIAP , :V0CHEQ-CODLAN , :V0CHEQ-DATLAN , :V0CHEQ-EMPRESA , CURRENT TIMESTAMP, :V0CHEQ-CODFAV , :V0CHEQ-VALINSS) END-EXEC. */

            var r1710_00_GRAVA_TCHEQUES_DB_INSERT_1_Insert1 = new R1710_00_GRAVA_TCHEQUES_DB_INSERT_1_Insert1()
            {
                V0CHEQ_TPMOVTO = V0CHEQ_TPMOVTO.ToString(),
                V0CHEQ_FONTE = V0CHEQ_FONTE.ToString(),
                V0CHEQ_NUMDOC = V0CHEQ_NUMDOC.ToString(),
                V0CHEQ_NOMFAV = V0CHEQ_NOMFAV.ToString(),
                V0CHEQ_VALCHQ = V0CHEQ_VALCHQ.ToString(),
                V0CHEQ_DTMOVTO = V0CHEQ_DTMOVTO.ToString(),
                V0CHEQ_CHQINT = V0CHEQ_CHQINT.ToString(),
                V0CHEQ_DIGINT = V0CHEQ_DIGINT.ToString(),
                V0CHEQ_SITUACAO = V0CHEQ_SITUACAO.ToString(),
                V0CHEQ_TIPPAG = V0CHEQ_TIPPAG.ToString(),
                V0CHEQ_DATCMP = V0CHEQ_DATCMP.ToString(),
                V0CHEQ_PRAPAG = V0CHEQ_PRAPAG.ToString(),
                V0CHEQ_NUMREC = V0CHEQ_NUMREC.ToString(),
                V0CHEQ_OCORHIST = V0CHEQ_OCORHIST.ToString(),
                V0CHEQ_OPERACAO = V0CHEQ_OPERACAO.ToString(),
                V0CHEQ_CODDSA = V0CHEQ_CODDSA.ToString(),
                V0CHEQ_VALIRF = V0CHEQ_VALIRF.ToString(),
                V0CHEQ_VALISS = V0CHEQ_VALISS.ToString(),
                V0CHEQ_VALIAP = V0CHEQ_VALIAP.ToString(),
                V0CHEQ_CODLAN = V0CHEQ_CODLAN.ToString(),
                V0CHEQ_DATLAN = V0CHEQ_DATLAN.ToString(),
                V0CHEQ_EMPRESA = V0CHEQ_EMPRESA.ToString(),
                V0CHEQ_CODFAV = V0CHEQ_CODFAV.ToString(),
                V0CHEQ_VALINSS = V0CHEQ_VALINSS.ToString(),
            };

            R1710_00_GRAVA_TCHEQUES_DB_INSERT_1_Insert1.Execute(r1710_00_GRAVA_TCHEQUES_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1710_99_SAIDA*/

        [StopWatch]
        /*" R1710-00-GRAVA-TCHEQUES-DB-INSERT-2 */
        public void R1710_00_GRAVA_TCHEQUES_DB_INSERT_2()
        {
            /*" -1729- EXEC SQL INSERT INTO SEGUROS.V0HISTCHEQ VALUES (:V0HCHE-CHQINT , :V0HCHE-DIGINT , :V0HCHE-DTMOVTO , CURRENT TIME , :V0HCHE-OPERACAO, :V0HCHE-EMPRESA , CURRENT TIMESTAMP, NULL) END-EXEC. */

            var r1710_00_GRAVA_TCHEQUES_DB_INSERT_2_Insert1 = new R1710_00_GRAVA_TCHEQUES_DB_INSERT_2_Insert1()
            {
                V0HCHE_CHQINT = V0HCHE_CHQINT.ToString(),
                V0HCHE_DIGINT = V0HCHE_DIGINT.ToString(),
                V0HCHE_DTMOVTO = V0HCHE_DTMOVTO.ToString(),
                V0HCHE_OPERACAO = V0HCHE_OPERACAO.ToString(),
                V0HCHE_EMPRESA = V0HCHE_EMPRESA.ToString(),
            };

            R1710_00_GRAVA_TCHEQUES_DB_INSERT_2_Insert1.Execute(r1710_00_GRAVA_TCHEQUES_DB_INSERT_2_Insert1);

        }

        [StopWatch]
        /*" R1715-00-CALCULA-DIGITO-SECTION */
        private void R1715_00_CALCULA_DIGITO_SECTION()
        {
            /*" -1752- MOVE '17A' TO WNR-EXEC-SQL. */
            _.Move("17A", W.W_NUMDOC.WABEND.WNR_EXEC_SQL);

            /*" -1753- ADD 1 TO WNUMERO */
            WNUMERO.Value = WNUMERO + 1;

            /*" -1755- MOVE WNUMERO TO LPARM01 */
            _.Move(WNUMERO, LPARM01X.LPARM01);

            /*" -1771- COMPUTE WPARM01-AUX = LPARM01-1 * 8 + LPARM01-2 * 7 + LPARM01-3 * 6 + LPARM01-4 * 5 + LPARM01-5 * 4 + LPARM01-6 * 3 + LPARM01-7 * 2 + LPARM01-8 * 9 + LPARM01-9 * 8 + LPARM01-10 * 7 + LPARM01-11 * 6 + LPARM01-12 * 5 + LPARM01-13 * 4 + LPARM01-14 * 3 + LPARM01-15 * 2. */
            WPARM01_AUX.Value = LPARM01X.LPARM01_R.LPARM01_1 * 8 + LPARM01X.LPARM01_R.LPARM01_2 * 7 + LPARM01X.LPARM01_R.LPARM01_3 * 6 + LPARM01X.LPARM01_R.LPARM01_4 * 5 + LPARM01X.LPARM01_R.LPARM01_5 * 4 + LPARM01X.LPARM01_R.LPARM01_6 * 3 + LPARM01X.LPARM01_R.LPARM01_7 * 2 + LPARM01X.LPARM01_R.LPARM01_8 * 9 + LPARM01X.LPARM01_R.LPARM01_9 * 8 + LPARM01X.LPARM01_R.LPARM01_10 * 7 + LPARM01X.LPARM01_R.LPARM01_11 * 6 + LPARM01X.LPARM01_R.LPARM01_12 * 5 + LPARM01X.LPARM01_R.LPARM01_13 * 4 + LPARM01X.LPARM01_R.LPARM01_14 * 3 + LPARM01X.LPARM01_R.LPARM01_15 * 2;

            /*" -1774- DIVIDE WPARM01-AUX BY 11 GIVING WQUOCIENTE REMAINDER WRESTO */
            _.Divide(WPARM01_AUX, 11, WQUOCIENTE, WRESTO);

            /*" -1775- IF WRESTO EQUAL 1 */

            if (WRESTO == 1)
            {

                /*" -1776- MOVE 0 TO LPARM03 */
                _.Move(0, LPARM01X.LPARM03);

                /*" -1777- ELSE */
            }
            else
            {


                /*" -1778- IF WRESTO EQUAL ZEROS */

                if (WRESTO == 00)
                {

                    /*" -1779- MOVE 1 TO LPARM03 */
                    _.Move(1, LPARM01X.LPARM03);

                    /*" -1780- ELSE */
                }
                else
                {


                    /*" -1783- SUBTRACT WRESTO FROM 11 GIVING LPARM03. */
                    LPARM01X.LPARM03.Value = 11 - WRESTO;
                }

            }


            /*" -1783- MOVE LPARM03 TO WDIGITO. */
            _.Move(LPARM01X.LPARM03, WDIGITO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1715_99_SAIDA*/

        [StopWatch]
        /*" R1720-00-SELECT-V0HISTOPARC-SECTION */
        private void R1720_00_SELECT_V0HISTOPARC_SECTION()
        {
            /*" -1796- MOVE '172' TO WNR-EXEC-SQL. */
            _.Move("172", W.W_NUMDOC.WABEND.WNR_EXEC_SQL);

            /*" -1816- PERFORM R1720_00_SELECT_V0HISTOPARC_DB_SELECT_1 */

            R1720_00_SELECT_V0HISTOPARC_DB_SELECT_1();

            /*" -1819- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1820- DISPLAY 'EM0202B - ERRO NO ACESSO DA V1HISTOPARC' */
                _.Display($"EM0202B - ERRO NO ACESSO DA V1HISTOPARC");

                /*" -1820- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1720-00-SELECT-V0HISTOPARC-DB-SELECT-1 */
        public void R1720_00_SELECT_V0HISTOPARC_DB_SELECT_1()
        {
            /*" -1816- EXEC SQL SELECT VALUE(SUM(PRM_TARIFARIO), 0), VALUE(SUM(VAL_DESCONTO), 0), VALUE(SUM(VLPRMLIQ), 0), VALUE(SUM(VLADIFRA), 0), VALUE(SUM(VLCUSEMI), 0), VALUE(SUM(VLIOCC), 0), VALUE(SUM(VLPRMTOT), 0) INTO :V0HIST-PRM-TARIF , :V0HIST-DESCONTO , :V0HIST-VLPRMLIQ , :V0HIST-VLADIFRA , :V0HIST-VLCUSEMI , :V0HIST-VLIOCC , :V0HIST-VLPRMTOT FROM SEGUROS.V1HISTOPARC WHERE NUM_APOLICE = :V1HIST-NUM-APOL AND NRENDOS = :V1HIST-NRENDOS AND NRPARCEL = :V1HIST-NRPARCEL AND OPERACAO = 0801 END-EXEC. */

            var r1720_00_SELECT_V0HISTOPARC_DB_SELECT_1_Query1 = new R1720_00_SELECT_V0HISTOPARC_DB_SELECT_1_Query1()
            {
                V1HIST_NUM_APOL = V1HIST_NUM_APOL.ToString(),
                V1HIST_NRPARCEL = V1HIST_NRPARCEL.ToString(),
                V1HIST_NRENDOS = V1HIST_NRENDOS.ToString(),
            };

            var executed_1 = R1720_00_SELECT_V0HISTOPARC_DB_SELECT_1_Query1.Execute(r1720_00_SELECT_V0HISTOPARC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HIST_PRM_TARIF, V0HIST_PRM_TARIF);
                _.Move(executed_1.V0HIST_DESCONTO, V0HIST_DESCONTO);
                _.Move(executed_1.V0HIST_VLPRMLIQ, V0HIST_VLPRMLIQ);
                _.Move(executed_1.V0HIST_VLADIFRA, V0HIST_VLADIFRA);
                _.Move(executed_1.V0HIST_VLCUSEMI, V0HIST_VLCUSEMI);
                _.Move(executed_1.V0HIST_VLIOCC, V0HIST_VLIOCC);
                _.Move(executed_1.V0HIST_VLPRMTOT, V0HIST_VLPRMTOT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1720_99_SAIDA*/

        [StopWatch]
        /*" R1730-00-INSERT-V0HISTOPARC-SECTION */
        private void R1730_00_INSERT_V0HISTOPARC_SECTION()
        {
            /*" -1833- MOVE '173' TO WNR-EXEC-SQL */
            _.Move("173", W.W_NUMDOC.WABEND.WNR_EXEC_SQL);

            /*" -1834- MOVE V1SIST-DTMOVABE-FI TO V1HIST-DTMOVTO. */
            _.Move(V1SIST_DTMOVABE_FI, V1HIST_DTMOVTO);

            /*" -1835- ADD 1 TO V1PARC-OCORHIST. */
            V1PARC_OCORHIST.Value = V1PARC_OCORHIST + 1;

            /*" -1836- MOVE V1PARC-OCORHIST TO V1HIST-OCORHIST. */
            _.Move(V1PARC_OCORHIST, V1HIST_OCORHIST);

            /*" -1837- MOVE 'EM0202B' TO V1HIST-USUARIO. */
            _.Move("EM0202B", V1HIST_USUARIO);

            /*" -1838- MOVE V1SIST-DTMOVABE-FI TO V1HIST-DTQITBCO. */
            _.Move(V1SIST_DTMOVABE_FI, V1HIST_DTQITBCO);

            /*" -1839- MOVE ZEROS TO V1HIST-BCOCOBR. */
            _.Move(0, V1HIST_BCOCOBR);

            /*" -1840- MOVE ZEROS TO V1HIST-AGECOBR. */
            _.Move(0, V1HIST_AGECOBR);

            /*" -1841- MOVE ZEROS TO V1HIST-NRAVISO. */
            _.Move(0, V1HIST_NRAVISO);

            /*" -1842- MOVE ZEROS TO V1HIST-NRENDOCA. */
            _.Move(0, V1HIST_NRENDOCA);

            /*" -1843- MOVE '0' TO V1HIST-SITCONTB. */
            _.Move("0", V1HIST_SITCONTB);

            /*" -1845- MOVE ZEROS TO V1HIST-RNUDOC. */
            _.Move(0, V1HIST_RNUDOC);

            /*" -1874- PERFORM R1730_00_INSERT_V0HISTOPARC_DB_INSERT_1 */

            R1730_00_INSERT_V0HISTOPARC_DB_INSERT_1();

            /*" -1877- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1879- DISPLAY 'EM0202B - ERRO NO INSERT DA V0HISTOPARC' V1HIST-NUM-APOL ' ' V1HIST-NRENDOS */

                $"EM0202B - ERRO NO INSERT DA V0HISTOPARC{V1HIST_NUM_APOL} {V1HIST_NRENDOS}"
                .Display();

                /*" -1879- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1730-00-INSERT-V0HISTOPARC-DB-INSERT-1 */
        public void R1730_00_INSERT_V0HISTOPARC_DB_INSERT_1()
        {
            /*" -1874- EXEC SQL INSERT INTO SEGUROS.V0HISTOPARC VALUES (:V1HIST-NUM-APOL , :V1HIST-NRENDOS , :V1HIST-NRPARCEL , :V1HIST-DACPARC , :V1HIST-DTMOVTO , :V1HIST-OPERACAO , CURRENT TIME , :V1HIST-OCORHIST , :V2HIST-PRM-TARIF , :V2HIST-DESCONTO , :V2HIST-VLPRMLIQ , :V2HIST-VLADIFRA , :V2HIST-VLCUSEMI , :V2HIST-VLIOCC , :V2HIST-VLPRMTOT , :V2HIST-VLPREMIO , :V1HIST-DTVENCTO , :V1HIST-BCOCOBR , :V1HIST-AGECOBR , :V1HIST-NRAVISO , :V1HIST-NRENDOCA , :V1HIST-SITCONTB , :V1HIST-USUARIO , :V1HIST-RNUDOC , :V1HIST-DTQITBCO , :V1HIST-EMPRESA , CURRENT TIMESTAMP) END-EXEC. */

            var r1730_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1 = new R1730_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1()
            {
                V1HIST_NUM_APOL = V1HIST_NUM_APOL.ToString(),
                V1HIST_NRENDOS = V1HIST_NRENDOS.ToString(),
                V1HIST_NRPARCEL = V1HIST_NRPARCEL.ToString(),
                V1HIST_DACPARC = V1HIST_DACPARC.ToString(),
                V1HIST_DTMOVTO = V1HIST_DTMOVTO.ToString(),
                V1HIST_OPERACAO = V1HIST_OPERACAO.ToString(),
                V1HIST_OCORHIST = V1HIST_OCORHIST.ToString(),
                V2HIST_PRM_TARIF = V2HIST_PRM_TARIF.ToString(),
                V2HIST_DESCONTO = V2HIST_DESCONTO.ToString(),
                V2HIST_VLPRMLIQ = V2HIST_VLPRMLIQ.ToString(),
                V2HIST_VLADIFRA = V2HIST_VLADIFRA.ToString(),
                V2HIST_VLCUSEMI = V2HIST_VLCUSEMI.ToString(),
                V2HIST_VLIOCC = V2HIST_VLIOCC.ToString(),
                V2HIST_VLPRMTOT = V2HIST_VLPRMTOT.ToString(),
                V2HIST_VLPREMIO = V2HIST_VLPREMIO.ToString(),
                V1HIST_DTVENCTO = V1HIST_DTVENCTO.ToString(),
                V1HIST_BCOCOBR = V1HIST_BCOCOBR.ToString(),
                V1HIST_AGECOBR = V1HIST_AGECOBR.ToString(),
                V1HIST_NRAVISO = V1HIST_NRAVISO.ToString(),
                V1HIST_NRENDOCA = V1HIST_NRENDOCA.ToString(),
                V1HIST_SITCONTB = V1HIST_SITCONTB.ToString(),
                V1HIST_USUARIO = V1HIST_USUARIO.ToString(),
                V1HIST_RNUDOC = V1HIST_RNUDOC.ToString(),
                V1HIST_DTQITBCO = V1HIST_DTQITBCO.ToString(),
                V1HIST_EMPRESA = V1HIST_EMPRESA.ToString(),
            };

            R1730_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1.Execute(r1730_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1730_99_SAIDA*/

        [StopWatch]
        /*" R1740-00-UPDATE-V0PARCELA-SECTION */
        private void R1740_00_UPDATE_V0PARCELA_SECTION()
        {
            /*" -1892- MOVE '174' TO WNR-EXEC-SQL */
            _.Move("174", W.W_NUMDOC.WABEND.WNR_EXEC_SQL);

            /*" -1900- PERFORM R1740_00_UPDATE_V0PARCELA_DB_UPDATE_1 */

            R1740_00_UPDATE_V0PARCELA_DB_UPDATE_1();

            /*" -1903- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1905- DISPLAY 'EM0202B - ERRO NO UPDATE DA V0PARCELA' V1HIST-NUM-APOL ' ' V1HIST-NRENDOS */

                $"EM0202B - ERRO NO UPDATE DA V0PARCELA{V1HIST_NUM_APOL} {V1HIST_NRENDOS}"
                .Display();

                /*" -1905- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1740-00-UPDATE-V0PARCELA-DB-UPDATE-1 */
        public void R1740_00_UPDATE_V0PARCELA_DB_UPDATE_1()
        {
            /*" -1900- EXEC SQL UPDATE SEGUROS.V0PARCELA SET OCORHIST = :V1PARC-OCORHIST, SITUACAO = '1' WHERE NUM_APOLICE = :V1HIST-NUM-APOL AND NRENDOS = :V1HIST-NRENDOS AND NRPARCEL = :V1HIST-NRPARCEL AND SITUACAO = '0' END-EXEC. */

            var r1740_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1 = new R1740_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1()
            {
                V1PARC_OCORHIST = V1PARC_OCORHIST.ToString(),
                V1HIST_NUM_APOL = V1HIST_NUM_APOL.ToString(),
                V1HIST_NRPARCEL = V1HIST_NRPARCEL.ToString(),
                V1HIST_NRENDOS = V1HIST_NRENDOS.ToString(),
            };

            R1740_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1.Execute(r1740_00_UPDATE_V0PARCELA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1740_99_SAIDA*/

        [StopWatch]
        /*" R1750-00-UPDATE-V0ENDOSSO-SECTION */
        private void R1750_00_UPDATE_V0ENDOSSO_SECTION()
        {
            /*" -1918- MOVE '175' TO WNR-EXEC-SQL */
            _.Move("175", W.W_NUMDOC.WABEND.WNR_EXEC_SQL);

            /*" -1923- PERFORM R1750_00_UPDATE_V0ENDOSSO_DB_UPDATE_1 */

            R1750_00_UPDATE_V0ENDOSSO_DB_UPDATE_1();

            /*" -1926- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1928- DISPLAY 'EM0202B - ERRO NO UPDATE DA V0ENDOSSO' V1HIST-NUM-APOL ' ' V1HIST-NRENDOS */

                $"EM0202B - ERRO NO UPDATE DA V0ENDOSSO{V1HIST_NUM_APOL} {V1HIST_NRENDOS}"
                .Display();

                /*" -1928- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1750-00-UPDATE-V0ENDOSSO-DB-UPDATE-1 */
        public void R1750_00_UPDATE_V0ENDOSSO_DB_UPDATE_1()
        {
            /*" -1923- EXEC SQL UPDATE SEGUROS.V0ENDOSSO SET SITUACAO = '1' WHERE NUM_APOLICE = :V1HIST-NUM-APOL AND NRENDOS = :V1HIST-NRENDOS END-EXEC. */

            var r1750_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1 = new R1750_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1()
            {
                V1HIST_NUM_APOL = V1HIST_NUM_APOL.ToString(),
                V1HIST_NRENDOS = V1HIST_NRENDOS.ToString(),
            };

            R1750_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1.Execute(r1750_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1750_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-CHAMA-GE0540S-SECTION */
        private void R2000_00_CHAMA_GE0540S_SECTION()
        {
            /*" -1941- MOVE '200' TO WNR-EXEC-SQL */
            _.Move("200", W.W_NUMDOC.WABEND.WNR_EXEC_SQL);

            /*" -1942- MOVE 'EM0202B' TO WPARM-PROGRAMA */
            _.Move("EM0202B", WPARAMETROS.WPARM_PROGRAMA);

            /*" -1944- MOVE SPACES TO WPARM-TEMCONTA WPARM-MSG-ERRO */
            _.Move("", WPARAMETROS.WPARM_TEMCONTA, WPARAMETROS.WPARM_MSG_ERRO);

            /*" -1957- MOVE ZEROS TO WPARM-ERRO01 WPARM-ERRO02 WPARM-ERRO03 WPARM-ERRO04 WPARM-ERRO05 WPARM-ERRO06 WPARM-ERRO07 WPARM-ERRO08 WPARM-ERRO09 WPARM-ERRO10 WPARM-ERRO11 WPARM-SQLCODE */
            _.Move(0, WPARAMETROS.WPARM_ERRO01, WPARAMETROS.WPARM_ERRO02, WPARAMETROS.WPARM_ERRO03, WPARAMETROS.WPARM_ERRO04, WPARAMETROS.WPARM_ERRO05, WPARAMETROS.WPARM_ERRO06, WPARAMETROS.WPARM_ERRO07, WPARAMETROS.WPARM_ERRO08, WPARAMETROS.WPARM_ERRO09, WPARAMETROS.WPARM_ERRO10, WPARAMETROS.WPARM_ERRO11, WPARAMETROS.WPARM_SQLCODE);

            /*" -1958- MOVE V1HIST-NUM-APOL TO WPARM-NUMAPOL. */
            _.Move(V1HIST_NUM_APOL, WPARAMETROS.WPARM_NUMAPOL);

            /*" -1959- MOVE V1HIST-NRENDOS TO WPARM-NRENDOS. */
            _.Move(V1HIST_NRENDOS, WPARAMETROS.WPARM_NRENDOS);

            /*" -1960- MOVE V1HIST-NRPARCEL TO WPARM-NRPARCEL. */
            _.Move(V1HIST_NRPARCEL, WPARAMETROS.WPARM_NRPARCEL);

            /*" -1962- MOVE V1HIST-OCORHIST TO WPARM-OCORHIST. */
            _.Move(V1HIST_OCORHIST, WPARAMETROS.WPARM_OCORHIST);

            /*" -1963- MOVE SPACES TO WTEM-CB041 */
            _.Move("", W.WTEM_CB041);

            /*" -1964- MOVE V1HIST-NUM-APOL TO CB041-NUM-APOLICE */
            _.Move(V1HIST_NUM_APOL, CB041.DCLCB_PESS_PARCELA.CB041_NUM_APOLICE);

            /*" -1965- MOVE V1HIST-NRENDOS TO CB041-NUM-ENDOSSO */
            _.Move(V1HIST_NRENDOS, CB041.DCLCB_PESS_PARCELA.CB041_NUM_ENDOSSO);

            /*" -1967- MOVE V1HIST-NRPARCEL TO CB041-NUM-PARCELA */
            _.Move(V1HIST_NRPARCEL, CB041.DCLCB_PESS_PARCELA.CB041_NUM_PARCELA);

            /*" -1969- PERFORM R2100-00-VERIFICA-CB041 */

            R2100_00_VERIFICA_CB041_SECTION();

            /*" -1970- IF WTEM-CB041 EQUAL 'S' */

            if (W.WTEM_CB041 == "S")
            {

                /*" -1971- MOVE 'S' TO WPARM-TEMCONTA */
                _.Move("S", WPARAMETROS.WPARM_TEMCONTA);

                /*" -1973- GO TO R2000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1980- MOVE '200' TO WNR-EXEC-SQL */
            _.Move("200", W.W_NUMDOC.WABEND.WNR_EXEC_SQL);

            /*" -1982- DISPLAY 'CHAMANDO GE0540S' */
            _.Display($"CHAMANDO GE0540S");

            /*" -1984- CALL 'GE0540S' USING WPARAMETROS. */
            _.Call("GE0540S", WPARAMETROS);

            /*" -1985- DISPLAY 'RETORNO GE0540S ... ' */
            _.Display($"RETORNO GE0540S ... ");

            /*" -1988- DISPLAY 'WPARM-TEMCONTA ' WPARM-TEMCONTA */
            _.Display($"WPARM-TEMCONTA {WPARAMETROS.WPARM_TEMCONTA}");

            /*" -1989- ADD WPARM-ERRO01 TO AC-ERRO01. */
            AC_ERRO01.Value = AC_ERRO01 + WPARAMETROS.WPARM_ERRO01;

            /*" -1990- ADD WPARM-ERRO02 TO AC-ERRO02. */
            AC_ERRO02.Value = AC_ERRO02 + WPARAMETROS.WPARM_ERRO02;

            /*" -1991- ADD WPARM-ERRO03 TO AC-ERRO03. */
            AC_ERRO03.Value = AC_ERRO03 + WPARAMETROS.WPARM_ERRO03;

            /*" -1992- ADD WPARM-ERRO04 TO AC-ERRO04. */
            AC_ERRO04.Value = AC_ERRO04 + WPARAMETROS.WPARM_ERRO04;

            /*" -1993- ADD WPARM-ERRO05 TO AC-ERRO05. */
            AC_ERRO05.Value = AC_ERRO05 + WPARAMETROS.WPARM_ERRO05;

            /*" -1994- ADD WPARM-ERRO06 TO AC-ERRO06. */
            AC_ERRO06.Value = AC_ERRO06 + WPARAMETROS.WPARM_ERRO06;

            /*" -1995- ADD WPARM-ERRO07 TO AC-ERRO07. */
            AC_ERRO07.Value = AC_ERRO07 + WPARAMETROS.WPARM_ERRO07;

            /*" -1996- ADD WPARM-ERRO08 TO AC-ERRO08. */
            AC_ERRO08.Value = AC_ERRO08 + WPARAMETROS.WPARM_ERRO08;

            /*" -1997- ADD WPARM-ERRO09 TO AC-ERRO09. */
            AC_ERRO09.Value = AC_ERRO09 + WPARAMETROS.WPARM_ERRO09;

            /*" -1998- ADD WPARM-ERRO10 TO AC-ERRO10. */
            AC_ERRO10.Value = AC_ERRO10 + WPARAMETROS.WPARM_ERRO10;

            /*" -2000- ADD WPARM-ERRO11 TO AC-ERRO11. */
            AC_ERRO11.Value = AC_ERRO11 + WPARAMETROS.WPARM_ERRO11;

            /*" -2002- IF WPARM-TEMCONTA = 'N' */

            if (WPARAMETROS.WPARM_TEMCONTA == "N")
            {

                /*" -2003- DISPLAY 'EM0202B - PROBLEMA PROGRAMA GE0540S' */
                _.Display($"EM0202B - PROBLEMA PROGRAMA GE0540S");

                /*" -2004- DISPLAY 'APOLICE  ' WPARM-NUMAPOL */
                _.Display($"APOLICE  {WPARAMETROS.WPARM_NUMAPOL}");

                /*" -2005- DISPLAY 'ENDOSSO  ' WPARM-NRENDOS */
                _.Display($"ENDOSSO  {WPARAMETROS.WPARM_NRENDOS}");

                /*" -2006- DISPLAY 'PARCELA  ' WPARM-NRPARCEL */
                _.Display($"PARCELA  {WPARAMETROS.WPARM_NRPARCEL}");

                /*" -2007- DISPLAY 'OCORR    ' WPARM-OCORHIST */
                _.Display($"OCORR    {WPARAMETROS.WPARM_OCORHIST}");

                /*" -2008- DISPLAY 'MENSAGEM ' WPARM-MSG-ERRO */
                _.Display($"MENSAGEM {WPARAMETROS.WPARM_MSG_ERRO}");

                /*" -2010- DISPLAY 'SQLCODE  ' WPARM-SQLCODE */
                _.Display($"SQLCODE  {WPARAMETROS.WPARM_SQLCODE}");

                /*" -2011- MOVE WPARM-SQLCODE TO SQLCODE */
                _.Move(WPARAMETROS.WPARM_SQLCODE, DB.SQLCODE);

                /*" -2014- MOVE ZEROS TO SQLERRD(1) SQLERRD(2) */
                _.Move(0, DB.SQLERRD[2]);
                _.Move(0, DB.SQLERRD[1]);

                /*" -2015- IF WPARM-ERRO01 > 0 */

                if (WPARAMETROS.WPARM_ERRO01 > 0)
                {

                    /*" -2016- DISPLAY 'ERRO NA LEITURA TABELA .SISTEMAS NO GE0540S' */
                    _.Display($"ERRO NA LEITURA TABELA .SISTEMAS NO GE0540S");

                    /*" -2018- END-IF */
                }


                /*" -2019- IF WPARM-ERRO03 > 0 */

                if (WPARAMETROS.WPARM_ERRO03 > 0)
                {

                    /*" -2020- DISPLAY 'ERRO NA LEITURA TABELA .APOLICES NO GE0540S' */
                    _.Display($"ERRO NA LEITURA TABELA .APOLICES NO GE0540S");

                    /*" -2022- END-IF */
                }


                /*" -2023- IF WPARM-ERRO04 > 0 */

                if (WPARAMETROS.WPARM_ERRO04 > 0)
                {

                    /*" -2024- DISPLAY 'ERRO NA LEITURA TABELA .ENDOSSOS NO GE0540S' */
                    _.Display($"ERRO NA LEITURA TABELA .ENDOSSOS NO GE0540S");

                    /*" -2026- END-IF */
                }


                /*" -2027- IF WPARM-ERRO05 > 0 */

                if (WPARAMETROS.WPARM_ERRO05 > 0)
                {

                    /*" -2028- DISPLAY 'ERRO NA LEITURA TABELA .CLIENTES NO GE0540S' */
                    _.Display($"ERRO NA LEITURA TABELA .CLIENTES NO GE0540S");

                    /*" -2030- END-IF */
                }


                /*" -2031- IF WPARM-ERRO06 > 0 */

                if (WPARAMETROS.WPARM_ERRO06 > 0)
                {

                    /*" -2032- DISPLAY 'ERRO NA LEITURA TABELA .ENDERECOS NO GE0540S' */
                    _.Display($"ERRO NA LEITURA TABELA .ENDERECOS NO GE0540S");

                    /*" -2034- END-IF */
                }


                /*" -2035- IF WPARM-ERRO07 > 0 */

                if (WPARAMETROS.WPARM_ERRO07 > 0)
                {

                    /*" -2036- DISPLAY 'ERRO NA CHAMADA DO PROGRAMA GE0500B' */
                    _.Display($"ERRO NA CHAMADA DO PROGRAMA GE0500B");

                    /*" -2038- END-IF */
                }


                /*" -2039- IF WPARM-ERRO08 > 0 */

                if (WPARAMETROS.WPARM_ERRO08 > 0)
                {

                    /*" -2040- DISPLAY 'ERRO NA CHAMADA DO PROGRAMA GE0501B' */
                    _.Display($"ERRO NA CHAMADA DO PROGRAMA GE0501B");

                    /*" -2042- END-IF */
                }


                /*" -2043- IF WPARM-ERRO09 > 0 */

                if (WPARAMETROS.WPARM_ERRO09 > 0)
                {

                    /*" -2044- DISPLAY 'ERRO NA CHAMADA DO PROGRAMA GE0502B' */
                    _.Display($"ERRO NA CHAMADA DO PROGRAMA GE0502B");

                    /*" -2046- END-IF */
                }


                /*" -2047- IF WPARM-ERRO10 > 0 */

                if (WPARAMETROS.WPARM_ERRO10 > 0)
                {

                    /*" -2048- DISPLAY 'ERRO NA CHAMADA DO PROGRAMA GE0503B' */
                    _.Display($"ERRO NA CHAMADA DO PROGRAMA GE0503B");

                    /*" -2050- END-IF */
                }


                /*" -2051- IF WPARM-ERRO11 > 0 */

                if (WPARAMETROS.WPARM_ERRO11 > 0)
                {

                    /*" -2052- DISPLAY 'ERRO NA CHAMADA DO PROGRAMA GE0550B' */
                    _.Display($"ERRO NA CHAMADA DO PROGRAMA GE0550B");

                    /*" -2054- END-IF */
                }


                /*" -2055- IF WPARM-SQLCODE NOT = 0 AND 100 */

                if (!WPARAMETROS.WPARM_SQLCODE.In("0", "100"))
                {

                    /*" -2056- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2057- END-IF */
                }


                /*" -2057- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-VERIFICA-CB041-SECTION */
        private void R2100_00_VERIFICA_CB041_SECTION()
        {
            /*" -2068- MOVE '210' TO WNR-EXEC-SQL. */
            _.Move("210", W.W_NUMDOC.WABEND.WNR_EXEC_SQL);

            /*" -2081- PERFORM R2100_00_VERIFICA_CB041_DB_SELECT_1 */

            R2100_00_VERIFICA_CB041_DB_SELECT_1();

            /*" -2084- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2085- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2086- MOVE 'N' TO WTEM-CB041 */
                    _.Move("N", W.WTEM_CB041);

                    /*" -2087- ELSE */
                }
                else
                {


                    /*" -2088- DISPLAY 'R2100-00 - PROBLEMAS NO SELECT CB041' */
                    _.Display($"R2100-00 - PROBLEMAS NO SELECT CB041");

                    /*" -2089- DISPLAY 'NUM-APOLICE = ' CB041-NUM-APOLICE */
                    _.Display($"NUM-APOLICE = {CB041.DCLCB_PESS_PARCELA.CB041_NUM_APOLICE}");

                    /*" -2090- DISPLAY 'NUM_ENDOSSO = ' CB041-NUM-ENDOSSO */
                    _.Display($"NUM_ENDOSSO = {CB041.DCLCB_PESS_PARCELA.CB041_NUM_ENDOSSO}");

                    /*" -2091- DISPLAY 'NUM_PARCELA = ' CB041-NUM-PARCELA */
                    _.Display($"NUM_PARCELA = {CB041.DCLCB_PESS_PARCELA.CB041_NUM_PARCELA}");

                    /*" -2092- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2093- ELSE */
                }

            }
            else
            {


                /*" -2093- MOVE 'S' TO WTEM-CB041. */
                _.Move("S", W.WTEM_CB041);
            }


        }

        [StopWatch]
        /*" R2100-00-VERIFICA-CB041-DB-SELECT-1 */
        public void R2100_00_VERIFICA_CB041_DB_SELECT_1()
        {
            /*" -2081- EXEC SQL SELECT A.NUM_OCORR_MOVTO INTO :CB041-NUM-OCORR-MOVTO FROM SEGUROS.CB_PESS_PARCELA A WHERE A.NUM_APOLICE = :CB041-NUM-APOLICE AND A.NUM_ENDOSSO = :CB041-NUM-ENDOSSO AND A.NUM_PARCELA = :CB041-NUM-PARCELA AND A.NUM_OCORR_MOVTO = ( SELECT MAX(B.NUM_OCORR_MOVTO) FROM SEGUROS.CB_PESS_PARCELA B WHERE A.NUM_APOLICE = B.NUM_APOLICE AND A.NUM_ENDOSSO = B.NUM_ENDOSSO AND A.NUM_PARCELA = B.NUM_PARCELA ) END-EXEC. */

            var r2100_00_VERIFICA_CB041_DB_SELECT_1_Query1 = new R2100_00_VERIFICA_CB041_DB_SELECT_1_Query1()
            {
                CB041_NUM_APOLICE = CB041.DCLCB_PESS_PARCELA.CB041_NUM_APOLICE.ToString(),
                CB041_NUM_ENDOSSO = CB041.DCLCB_PESS_PARCELA.CB041_NUM_ENDOSSO.ToString(),
                CB041_NUM_PARCELA = CB041.DCLCB_PESS_PARCELA.CB041_NUM_PARCELA.ToString(),
            };

            var executed_1 = R2100_00_VERIFICA_CB041_DB_SELECT_1_Query1.Execute(r2100_00_VERIFICA_CB041_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CB041_NUM_OCORR_MOVTO, CB041.DCLCB_PESS_PARCELA.CB041_NUM_OCORR_MOVTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-TRATA-CBCONDEV-SECTION */
        private void R3000_00_TRATA_CBCONDEV_SECTION()
        {
            /*" -2104- MOVE '300' TO WNR-EXEC-SQL. */
            _.Move("300", W.W_NUMDOC.WABEND.WNR_EXEC_SQL);

            /*" -2105- IF WPARM-TEMCONTA EQUAL 'S' */

            if (WPARAMETROS.WPARM_TEMCONTA == "S")
            {

                /*" -2106- PERFORM R3010-00-MAX-OCOR-CBCONDEV */

                R3010_00_MAX_OCOR_CBCONDEV_SECTION();

                /*" -2107- PERFORM R3020-00-SELECT-CB041 */

                R3020_00_SELECT_CB041_SECTION();

                /*" -2108- PERFORM R3030-00-SELECT-GE368 */

                R3030_00_SELECT_GE368_SECTION();

                /*" -2110- PERFORM R3040-00-SELECT-OD009 */

                R3040_00_SELECT_OD009_SECTION();

                /*" -2111- MOVE CB041-NUM-OCORR-MOVTO TO CBCONDEV-NUM-CHEQUE-INTERNO */
                _.Move(CB041.DCLCB_PESS_PARCELA.CB041_NUM_OCORR_MOVTO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_CHEQUE_INTERNO);

                /*" -2112- MOVE ZEROS TO CBCONDEV-DIG-CHEQUE-INTERNO */
                _.Move(0, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DIG_CHEQUE_INTERNO);

                /*" -2114- MOVE 'Z' TO CBCONDEV-TIPO-MOVIMENTO */
                _.Move("Z", CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_TIPO_MOVIMENTO);

                /*" -2115- PERFORM R3100-00-MONTA-CBCONDEV */

                R3100_00_MONTA_CBCONDEV_SECTION();

                /*" -2116- PERFORM R3110-00-INSERT-CBCONDEV */

                R3110_00_INSERT_CBCONDEV_SECTION();

                /*" -2117- ELSE */
            }
            else
            {


                /*" -2118- MOVE WNUMERO TO CBCONDEV-NUM-CHEQUE-INTERNO */
                _.Move(WNUMERO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_CHEQUE_INTERNO);

                /*" -2119- MOVE WDIGITO TO CBCONDEV-DIG-CHEQUE-INTERNO */
                _.Move(WDIGITO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DIG_CHEQUE_INTERNO);

                /*" -2121- MOVE '8' TO CBCONDEV-TIPO-MOVIMENTO */
                _.Move("8", CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_TIPO_MOVIMENTO);

                /*" -2122- PERFORM R3100-00-MONTA-CBCONDEV */

                R3100_00_MONTA_CBCONDEV_SECTION();

                /*" -2122- PERFORM R3110-00-INSERT-CBCONDEV. */

                R3110_00_INSERT_CBCONDEV_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3010-00-MAX-OCOR-CBCONDEV-SECTION */
        private void R3010_00_MAX_OCOR_CBCONDEV_SECTION()
        {
            /*" -2133- MOVE '301' TO WNR-EXEC-SQL. */
            _.Move("301", W.W_NUMDOC.WABEND.WNR_EXEC_SQL);

            /*" -2139- PERFORM R3010_00_MAX_OCOR_CBCONDEV_DB_SELECT_1 */

            R3010_00_MAX_OCOR_CBCONDEV_DB_SELECT_1();

            /*" -2142- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2143- DISPLAY 'R3010 - ERRO NO SELECT DA CBCONDEV' */
                _.Display($"R3010 - ERRO NO SELECT DA CBCONDEV");

                /*" -2145- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2147- MOVE CBCONDEV-NUM-SEQUENCIA TO WS-NRSEQ */
            _.Move(CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_SEQUENCIA, W.WS_NRSEQ);

            /*" -2147- ADD 1 TO WS-NRSEQ. */
            W.WS_NRSEQ.Value = W.WS_NRSEQ + 1;

        }

        [StopWatch]
        /*" R3010-00-MAX-OCOR-CBCONDEV-DB-SELECT-1 */
        public void R3010_00_MAX_OCOR_CBCONDEV_DB_SELECT_1()
        {
            /*" -2139- EXEC SQL SELECT VALUE ( MAX ( NUM_SEQUENCIA ) , 0 ) INTO :CBCONDEV-NUM-SEQUENCIA FROM SEGUROS.CB_CONTR_DEVPREMIO WHERE DATA_MOVIMENTO = :V1SIST-DTMOVABE WITH UR END-EXEC. */

            var r3010_00_MAX_OCOR_CBCONDEV_DB_SELECT_1_Query1 = new R3010_00_MAX_OCOR_CBCONDEV_DB_SELECT_1_Query1()
            {
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
            };

            var executed_1 = R3010_00_MAX_OCOR_CBCONDEV_DB_SELECT_1_Query1.Execute(r3010_00_MAX_OCOR_CBCONDEV_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CBCONDEV_NUM_SEQUENCIA, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_SEQUENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3010_99_SAIDA*/

        [StopWatch]
        /*" R3020-00-SELECT-CB041-SECTION */
        private void R3020_00_SELECT_CB041_SECTION()
        {
            /*" -2158- MOVE '302' TO WNR-EXEC-SQL. */
            _.Move("302", W.W_NUMDOC.WABEND.WNR_EXEC_SQL);

            /*" -2171- PERFORM R3020_00_SELECT_CB041_DB_SELECT_1 */

            R3020_00_SELECT_CB041_DB_SELECT_1();

            /*" -2174- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2175- DISPLAY 'R3020-00 - PROBLEMAS NO SELECT CB041' */
                _.Display($"R3020-00 - PROBLEMAS NO SELECT CB041");

                /*" -2176- DISPLAY 'NUM-APOLICE   =   ' V1EDIA-NUM-APOL */
                _.Display($"NUM-APOLICE   =   {V1EDIA_NUM_APOL}");

                /*" -2177- DISPLAY 'NUM_ENDOSSO   =   ' V1EDIA-NRENDOS */
                _.Display($"NUM_ENDOSSO   =   {V1EDIA_NRENDOS}");

                /*" -2178- DISPLAY 'NUM_PARCELA   =   ' V1HIST-NRPARCEL */
                _.Display($"NUM_PARCELA   =   {V1HIST_NRPARCEL}");

                /*" -2178- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3020-00-SELECT-CB041-DB-SELECT-1 */
        public void R3020_00_SELECT_CB041_DB_SELECT_1()
        {
            /*" -2171- EXEC SQL SELECT A.NUM_OCORR_MOVTO INTO :CB041-NUM-OCORR-MOVTO FROM SEGUROS.CB_PESS_PARCELA A WHERE A.NUM_APOLICE = :V1EDIA-NUM-APOL AND A.NUM_ENDOSSO = :V1EDIA-NRENDOS AND A.NUM_PARCELA = :V1HIST-NRPARCEL AND A.NUM_OCORR_MOVTO = ( SELECT MAX(B.NUM_OCORR_MOVTO) FROM SEGUROS.CB_PESS_PARCELA B WHERE A.NUM_APOLICE = B.NUM_APOLICE AND A.NUM_ENDOSSO = B.NUM_ENDOSSO AND A.NUM_PARCELA = B.NUM_PARCELA ) END-EXEC. */

            var r3020_00_SELECT_CB041_DB_SELECT_1_Query1 = new R3020_00_SELECT_CB041_DB_SELECT_1_Query1()
            {
                V1EDIA_NUM_APOL = V1EDIA_NUM_APOL.ToString(),
                V1HIST_NRPARCEL = V1HIST_NRPARCEL.ToString(),
                V1EDIA_NRENDOS = V1EDIA_NRENDOS.ToString(),
            };

            var executed_1 = R3020_00_SELECT_CB041_DB_SELECT_1_Query1.Execute(r3020_00_SELECT_CB041_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CB041_NUM_OCORR_MOVTO, CB041.DCLCB_PESS_PARCELA.CB041_NUM_OCORR_MOVTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3020_99_SAIDA*/

        [StopWatch]
        /*" R3030-00-SELECT-GE368-SECTION */
        private void R3030_00_SELECT_GE368_SECTION()
        {
            /*" -2191- MOVE '303' TO WNR-EXEC-SQL. */
            _.Move("303", W.W_NUMDOC.WABEND.WNR_EXEC_SQL);

            /*" -2197- PERFORM R3030_00_SELECT_GE368_DB_SELECT_1 */

            R3030_00_SELECT_GE368_DB_SELECT_1();

            /*" -2200- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2201- DISPLAY 'R3030-00 - PROBLEMAS NO SELECT GE368' */
                _.Display($"R3030-00 - PROBLEMAS NO SELECT GE368");

                /*" -2202- DISPLAY 'NUM-APOLICE     = ' V1EDIA-NUM-APOL */
                _.Display($"NUM-APOLICE     = {V1EDIA_NUM_APOL}");

                /*" -2203- DISPLAY 'NUM_ENDOSSO     = ' V1EDIA-NRENDOS */
                _.Display($"NUM_ENDOSSO     = {V1EDIA_NRENDOS}");

                /*" -2204- DISPLAY 'NUM_PARCELA     = ' V1HIST-NRPARCEL */
                _.Display($"NUM_PARCELA     = {V1HIST_NRPARCEL}");

                /*" -2205- DISPLAY 'NUM_OCORR_MOVTO = ' CB041-NUM-OCORR-MOVTO */
                _.Display($"NUM_OCORR_MOVTO = {CB041.DCLCB_PESS_PARCELA.CB041_NUM_OCORR_MOVTO}");

                /*" -2205- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3030-00-SELECT-GE368-DB-SELECT-1 */
        public void R3030_00_SELECT_GE368_DB_SELECT_1()
        {
            /*" -2197- EXEC SQL SELECT DISTINCT NUM_PESSOA INTO :GE368-NUM-PESSOA FROM SEGUROS.GE_LEG_PESS_EVENTO WHERE NUM_OCORR_MOVTO = :CB041-NUM-OCORR-MOVTO ORDER BY NUM_PESSOA END-EXEC. */

            var r3030_00_SELECT_GE368_DB_SELECT_1_Query1 = new R3030_00_SELECT_GE368_DB_SELECT_1_Query1()
            {
                CB041_NUM_OCORR_MOVTO = CB041.DCLCB_PESS_PARCELA.CB041_NUM_OCORR_MOVTO.ToString(),
            };

            var executed_1 = R3030_00_SELECT_GE368_DB_SELECT_1_Query1.Execute(r3030_00_SELECT_GE368_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE368_NUM_PESSOA, GE368.DCLGE_LEG_PESS_EVENTO.GE368_NUM_PESSOA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3030_99_SAIDA*/

        [StopWatch]
        /*" R3040-00-SELECT-OD009-SECTION */
        private void R3040_00_SELECT_OD009_SECTION()
        {
            /*" -2218- MOVE '304' TO WNR-EXEC-SQL. */
            _.Move("304", W.W_NUMDOC.WABEND.WNR_EXEC_SQL);

            /*" -2236- PERFORM R3040_00_SELECT_OD009_DB_SELECT_1 */

            R3040_00_SELECT_OD009_DB_SELECT_1();

            /*" -2239- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2240- DISPLAY 'R3040-00 - PROBLEMAS NO SELECT OD009' */
                _.Display($"R3040-00 - PROBLEMAS NO SELECT OD009");

                /*" -2241- DISPLAY 'NUM-APOLICE     = ' V1EDIA-NUM-APOL */
                _.Display($"NUM-APOLICE     = {V1EDIA_NUM_APOL}");

                /*" -2242- DISPLAY 'NUM_ENDOSSO     = ' V1EDIA-NRENDOS */
                _.Display($"NUM_ENDOSSO     = {V1EDIA_NRENDOS}");

                /*" -2243- DISPLAY 'NUM_PARCELA     = ' V1HIST-NRPARCEL */
                _.Display($"NUM_PARCELA     = {V1HIST_NRPARCEL}");

                /*" -2244- DISPLAY 'NUM_PESSOA      = ' GE368-NUM-PESSOA */
                _.Display($"NUM_PESSOA      = {GE368.DCLGE_LEG_PESS_EVENTO.GE368_NUM_PESSOA}");

                /*" -2244- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3040-00-SELECT-OD009-DB-SELECT-1 */
        public void R3040_00_SELECT_OD009_DB_SELECT_1()
        {
            /*" -2236- EXEC SQL SELECT VALUE(T1.COD_BANCO, 0), VALUE(T1.COD_AGENCIA, 0), VALUE(T1.NUM_OPERACAO_CONTA, 0), VALUE(T1.NUM_CONTA, 0) , VALUE(T1.NUM_DV_CONTA, ' ' ) INTO :OD009-COD-BANCO, :OD009-COD-AGENCIA, :OD009-NUM-OPERACAO-CONTA, :OD009-NUM-CONTA, :OD009-NUM-DV-CONTA FROM ODS.OD_PESS_CONTA_BANC T1 WHERE T1.NUM_PESSOA = :GE368-NUM-PESSOA AND T1.STA_CONTA = 'A' AND T1.SEQ_CONTA_BANCARIA = (SELECT MAX(T2.SEQ_CONTA_BANCARIA) FROM ODS.OD_PESS_CONTA_BANC T2 WHERE T2.NUM_PESSOA = T1.NUM_PESSOA) END-EXEC. */

            var r3040_00_SELECT_OD009_DB_SELECT_1_Query1 = new R3040_00_SELECT_OD009_DB_SELECT_1_Query1()
            {
                GE368_NUM_PESSOA = GE368.DCLGE_LEG_PESS_EVENTO.GE368_NUM_PESSOA.ToString(),
            };

            var executed_1 = R3040_00_SELECT_OD009_DB_SELECT_1_Query1.Execute(r3040_00_SELECT_OD009_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OD009_COD_BANCO, OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_BANCO);
                _.Move(executed_1.OD009_COD_AGENCIA, OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_AGENCIA);
                _.Move(executed_1.OD009_NUM_OPERACAO_CONTA, OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_OPERACAO_CONTA);
                _.Move(executed_1.OD009_NUM_CONTA, OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_CONTA);
                _.Move(executed_1.OD009_NUM_DV_CONTA, OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_DV_CONTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3040_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-MONTA-CBCONDEV-SECTION */
        private void R3100_00_MONTA_CBCONDEV_SECTION()
        {
            /*" -2257- MOVE '310' TO WNR-EXEC-SQL. */
            _.Move("310", W.W_NUMDOC.WABEND.WNR_EXEC_SQL);

            /*" -2259- PERFORM R3105-00-SELECT-AGENCCEF */

            R3105_00_SELECT_AGENCCEF_SECTION();

            /*" -2260- IF CBCONDEV-TIPO-MOVIMENTO EQUAL 'Z' */

            if (CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_TIPO_MOVIMENTO == "Z")
            {

                /*" -2262- MOVE '0' TO CBCONDEV-SIT-REGISTRO */
                _.Move("0", CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_SIT_REGISTRO);

                /*" -2263- ELSE */
            }
            else
            {


                /*" -2264- IF WPARM-TEMCONTA NOT EQUAL 'S' */

                if (WPARAMETROS.WPARM_TEMCONTA != "S")
                {

                    /*" -2266- MOVE '2' TO CBCONDEV-SIT-REGISTRO */
                    _.Move("2", CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_SIT_REGISTRO);

                    /*" -2267- ELSE */
                }
                else
                {


                    /*" -2270- MOVE '0' TO CBCONDEV-SIT-REGISTRO. */
                    _.Move("0", CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_SIT_REGISTRO);
                }

            }


            /*" -2272- MOVE ZEROS TO CBCONDEV-COD-EMPRESA */
            _.Move(0, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_EMPRESA);

            /*" -2275- MOVE V1SIST-DTMOVABE TO CBCONDEV-DATA-MOVIMENTO */
            _.Move(V1SIST_DTMOVABE, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DATA_MOVIMENTO);

            /*" -2277- MOVE WS-NRSEQ TO CBCONDEV-NUM-SEQUENCIA */
            _.Move(W.WS_NRSEQ, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_SEQUENCIA);

            /*" -2279- MOVE ZEROS TO CBCONDEV-NUM-TITULO */
            _.Move(0, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_TITULO);

            /*" -2281- MOVE V1EDIA-FONTE TO CBCONDEV-COD-FONTE */
            _.Move(V1EDIA_FONTE, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_FONTE);

            /*" -2283- MOVE ZEROS TO CBCONDEV-NUM-RCAP */
            _.Move(0, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_RCAP);

            /*" -2285- MOVE ZEROS TO CBCONDEV-NUM-RCAP-COMPLEMEN */
            _.Move(0, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_RCAP_COMPLEMEN);

            /*" -2287- MOVE V1EDIA-NUM-APOL TO CBCONDEV-NUM-APOLICE */
            _.Move(V1EDIA_NUM_APOL, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_APOLICE);

            /*" -2289- MOVE V1EDIA-NRENDOS TO CBCONDEV-NUM-ENDOSSO */
            _.Move(V1EDIA_NRENDOS, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_ENDOSSO);

            /*" -2291- MOVE V1HIST-NRPARCEL TO CBCONDEV-NUM-PARCELA */
            _.Move(V1HIST_NRPARCEL, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_PARCELA);

            /*" -2293- MOVE ZEROS TO CBCONDEV-COD-SUBGRUPO */
            _.Move(0, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_SUBGRUPO);

            /*" -2295- MOVE ZEROS TO CBCONDEV-NUM-CERTIFICADO */
            _.Move(0, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_CERTIFICADO);

            /*" -2297- MOVE V1SIST-DTMOVABE TO CBCONDEV-DATA-OCORRENCIA */
            _.Move(V1SIST_DTMOVABE, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DATA_OCORRENCIA);

            /*" -2299- MOVE V1SIST-HRMOVABE TO CBCONDEV-HORA-OPERACAO */
            _.Move(V1SIST_HRMOVABE, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_HORA_OPERACAO);

            /*" -2301- MOVE ZEROS TO CBCONDEV-NUM-MATRICULA */
            _.Move(0, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_MATRICULA);

            /*" -2303- MOVE V1ENDO-RAMO TO CBCONDEV-RAMO-EMISSOR */
            _.Move(V1ENDO_RAMO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_RAMO_EMISSOR);

            /*" -2305- MOVE V1ENDO-CODPRODU TO CBCONDEV-COD-PRODUTO */
            _.Move(V1ENDO_CODPRODU, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_PRODUTO);

            /*" -2307- MOVE MALHACEF-COD-FONTE TO CBCONDEV-COD-FILIAL */
            _.Move(MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_FILIAL);

            /*" -2309- MOVE AGENCCEF-COD-ESCNEG TO CBCONDEV-COD-ESCNEG */
            _.Move(AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_ESCNEG, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_ESCNEG);

            /*" -2311- MOVE V1HIST-AGECOBR TO CBCONDEV-AGE-COBRANCA */
            _.Move(V1HIST_AGECOBR, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_AGE_COBRANCA);

            /*" -2314- MOVE '9' TO CBCONDEV-TIPO-FAVORECIDO */
            _.Move("9", CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_TIPO_FAVORECIDO);

            /*" -2315- IF WPARM-TEMCONTA EQUAL 'S' */

            if (WPARAMETROS.WPARM_TEMCONTA == "S")
            {

                /*" -2317- MOVE GE368-NUM-PESSOA TO CBCONDEV-COD-FAVORECIDO */
                _.Move(GE368.DCLGE_LEG_PESS_EVENTO.GE368_NUM_PESSOA, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_FAVORECIDO);

                /*" -2318- ELSE */
            }
            else
            {


                /*" -2321- MOVE V1APOL-CODCLIEN TO CBCONDEV-COD-FAVORECIDO. */
                _.Move(V1APOL_CODCLIEN, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_FAVORECIDO);
            }


            /*" -2323- MOVE ZEROS TO CBCONDEV-COD-ENDERECO */
            _.Move(0, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_ENDERECO);

            /*" -2326- MOVE V1ENDO-OCORREND TO CBCONDEV-OCORR-ENDERECO */
            _.Move(V1ENDO_OCORREND, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_OCORR_ENDERECO);

            /*" -2327- IF WPARM-TEMCONTA EQUAL 'S' */

            if (WPARAMETROS.WPARM_TEMCONTA == "S")
            {

                /*" -2329- MOVE OD009-COD-AGENCIA TO CBCONDEV-COD-AGENCIA */
                _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_AGENCIA, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_AGENCIA);

                /*" -2331- MOVE OD009-NUM-OPERACAO-CONTA TO CBCONDEV-OPERACAO-CONTA */
                _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_OPERACAO_CONTA, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_OPERACAO_CONTA);

                /*" -2333- MOVE OD009-NUM-CONTA TO CBCONDEV-NUM-CONTA */
                _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_CONTA, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_CONTA);

                /*" -2335- MOVE OD009-NUM-DV-CONTA TO CBCONDEV-DIG-CONTA */
                _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_DV_CONTA, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DIG_CONTA);

                /*" -2336- ELSE */
            }
            else
            {


                /*" -2342- MOVE ZEROS TO CBCONDEV-COD-AGENCIA CBCONDEV-OPERACAO-CONTA CBCONDEV-NUM-CONTA CBCONDEV-DIG-CONTA. */
                _.Move(0, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_AGENCIA, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_OPERACAO_CONTA, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_CONTA, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DIG_CONTA);
            }


            /*" -2344- MOVE V1HIST-DTQITBCO TO CBCONDEV-DATA-QUITACAO */
            _.Move(V1HIST_DTQITBCO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DATA_QUITACAO);

            /*" -2346- MOVE V1HIST-VLPRMTOT TO CBCONDEV-VAL-TITULO */
            _.Move(V1HIST_VLPRMTOT, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_VAL_TITULO);

            /*" -2348- MOVE V1HIST-VLPRMTOT TO CBCONDEV-VAL-OPERACAO */
            _.Move(V1HIST_VLPRMTOT, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_VAL_OPERACAO);

            /*" -2350- MOVE ZEROS TO CBCONDEV-VAL-DESCONTO */
            _.Move(0, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_VAL_DESCONTO);

            /*" -2352- MOVE 1204 TO CBCONDEV-COD-DESPESA */
            _.Move(1204, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_DESPESA);

            /*" -2355- MOVE 150 TO CBCONDEV-COD-DEVOLUCAO */
            _.Move(150, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_DEVOLUCAO);

            /*" -2356- IF CBCONDEV-TIPO-MOVIMENTO EQUAL 'Z' */

            if (CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_TIPO_MOVIMENTO == "Z")
            {

                /*" -2358- MOVE 0003 TO CBCONDEV-COD-SISTEMA */
                _.Move(0003, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_SISTEMA);

                /*" -2359- ELSE */
            }
            else
            {


                /*" -2362- MOVE 0001 TO CBCONDEV-COD-SISTEMA. */
                _.Move(0001, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_SISTEMA);
            }


            /*" -2364- MOVE 'EM0202B' TO CBCONDEV-COD-USU-SOLICITA */
            _.Move("EM0202B", CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_USU_SOLICITA);

            /*" -2366- MOVE SPACES TO CBCONDEV-DATA-CANCELAMENTO */
            _.Move("", CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DATA_CANCELAMENTO);

            /*" -2369- MOVE SPACES TO CBCONDEV-COD-USU-CANCELA */
            _.Move("", CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_USU_CANCELA);

            /*" -2370- MOVE -1 TO VIND-DTCANCEL */
            _.Move(-1, VIND_DTCANCEL);

            /*" -2370- MOVE -1 TO VIND-CODUSU. */
            _.Move(-1, VIND_CODUSU);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R3105-00-SELECT-AGENCCEF-SECTION */
        private void R3105_00_SELECT_AGENCCEF_SECTION()
        {
            /*" -2380- MOVE '315' TO WNR-EXEC-SQL. */
            _.Move("315", W.W_NUMDOC.WABEND.WNR_EXEC_SQL);

            /*" -2389- PERFORM R3105_00_SELECT_AGENCCEF_DB_SELECT_1 */

            R3105_00_SELECT_AGENCCEF_DB_SELECT_1();

            /*" -2392- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2393- DISPLAY 'EM0202B-R3105-PROBLEMAS NO SELECT AGENCCEF' */
                _.Display($"EM0202B-R3105-PROBLEMAS NO SELECT AGENCCEF");

                /*" -2394- DISPLAY 'NUM-APOLICE ' V1EDIA-NUM-APOL */
                _.Display($"NUM-APOLICE {V1EDIA_NUM_APOL}");

                /*" -2395- DISPLAY 'NUM_ENDOSSO ' V1EDIA-NRENDOS */
                _.Display($"NUM_ENDOSSO {V1EDIA_NRENDOS}");

                /*" -2396- DISPLAY 'NUM_PARCELA ' V1HIST-NRPARCEL */
                _.Display($"NUM_PARCELA {V1HIST_NRPARCEL}");

                /*" -2397- DISPLAY 'AGENCIA     ' V1HIST-AGECOBR */
                _.Display($"AGENCIA     {V1HIST_AGECOBR}");

                /*" -2397- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3105-00-SELECT-AGENCCEF-DB-SELECT-1 */
        public void R3105_00_SELECT_AGENCCEF_DB_SELECT_1()
        {
            /*" -2389- EXEC SQL SELECT A.COD_ESCNEG , B.COD_FONTE INTO :AGENCCEF-COD-ESCNEG , :MALHACEF-COD-FONTE FROM SEGUROS.AGENCIAS_CEF A , SEGUROS.MALHA_CEF B WHERE A.COD_AGENCIA = :V1HIST-AGECOBR AND A.COD_SUREG = B.COD_SUREG END-EXEC. */

            var r3105_00_SELECT_AGENCCEF_DB_SELECT_1_Query1 = new R3105_00_SELECT_AGENCCEF_DB_SELECT_1_Query1()
            {
                V1HIST_AGECOBR = V1HIST_AGECOBR.ToString(),
            };

            var executed_1 = R3105_00_SELECT_AGENCCEF_DB_SELECT_1_Query1.Execute(r3105_00_SELECT_AGENCCEF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.AGENCCEF_COD_ESCNEG, AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_ESCNEG);
                _.Move(executed_1.MALHACEF_COD_FONTE, MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3105_99_SAIDA*/

        [StopWatch]
        /*" R3110-00-INSERT-CBCONDEV-SECTION */
        private void R3110_00_INSERT_CBCONDEV_SECTION()
        {
            /*" -2408- MOVE '311' TO WNR-EXEC-SQL. */
            _.Move("311", W.W_NUMDOC.WABEND.WNR_EXEC_SQL);

            /*" -2496- PERFORM R3110_00_INSERT_CBCONDEV_DB_INSERT_1 */

            R3110_00_INSERT_CBCONDEV_DB_INSERT_1();

            /*" -2499- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2500- DISPLAY 'R3110-00 - PROBLEMAS NO INSERT CBCONDEV' */
                _.Display($"R3110-00 - PROBLEMAS NO INSERT CBCONDEV");

                /*" -2501- DISPLAY 'NUM-APOLICE = ' CBCONDEV-NUM-APOLICE */
                _.Display($"NUM-APOLICE = {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_APOLICE}");

                /*" -2502- DISPLAY 'NUM-ENDOSSO = ' CBCONDEV-NUM-ENDOSSO */
                _.Display($"NUM-ENDOSSO = {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_ENDOSSO}");

                /*" -2503- DISPLAY 'NUM-PARCELA = ' CBCONDEV-NUM-PARCELA */
                _.Display($"NUM-PARCELA = {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_PARCELA}");

                /*" -2503- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3110-00-INSERT-CBCONDEV-DB-INSERT-1 */
        public void R3110_00_INSERT_CBCONDEV_DB_INSERT_1()
        {
            /*" -2496- EXEC SQL INSERT INTO SEGUROS.CB_CONTR_DEVPREMIO ( COD_EMPRESA , TIPO_MOVIMENTO , NUM_CHEQUE_INTERNO , DIG_CHEQUE_INTERNO , DATA_MOVIMENTO , NUM_SEQUENCIA , NUM_TITULO , COD_FONTE , NUM_RCAP , NUM_RCAP_COMPLEMEN , NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , COD_SUBGRUPO , NUM_CERTIFICADO , DATA_OCORRENCIA , HORA_OPERACAO , NUM_MATRICULA , RAMO_EMISSOR , COD_PRODUTO , COD_FILIAL , COD_ESCNEG , AGE_COBRANCA , TIPO_FAVORECIDO , COD_FAVORECIDO , COD_ENDERECO , OCORR_ENDERECO , COD_AGENCIA , OPERACAO_CONTA , NUM_CONTA , DIG_CONTA , SIT_REGISTRO , DATA_QUITACAO , VAL_TITULO , VAL_DESCONTO , VAL_OPERACAO , COD_DESPESA , COD_DEVOLUCAO , COD_SISTEMA , COD_USU_SOLICITA , TIMESTAMP , DATA_CANCELAMENTO , COD_USU_CANCELA ) VALUES ( :CBCONDEV-COD-EMPRESA , :CBCONDEV-TIPO-MOVIMENTO , :CBCONDEV-NUM-CHEQUE-INTERNO , :CBCONDEV-DIG-CHEQUE-INTERNO , :CBCONDEV-DATA-MOVIMENTO , :CBCONDEV-NUM-SEQUENCIA , :CBCONDEV-NUM-TITULO , :CBCONDEV-COD-FONTE , :CBCONDEV-NUM-RCAP , :CBCONDEV-NUM-RCAP-COMPLEMEN , :CBCONDEV-NUM-APOLICE , :CBCONDEV-NUM-ENDOSSO , :CBCONDEV-NUM-PARCELA , :CBCONDEV-COD-SUBGRUPO , :CBCONDEV-NUM-CERTIFICADO , :CBCONDEV-DATA-OCORRENCIA , :CBCONDEV-HORA-OPERACAO , :CBCONDEV-NUM-MATRICULA , :CBCONDEV-RAMO-EMISSOR , :CBCONDEV-COD-PRODUTO , :CBCONDEV-COD-FILIAL , :CBCONDEV-COD-ESCNEG , :CBCONDEV-AGE-COBRANCA , :CBCONDEV-TIPO-FAVORECIDO , :CBCONDEV-COD-FAVORECIDO , :CBCONDEV-COD-ENDERECO , :CBCONDEV-OCORR-ENDERECO , :CBCONDEV-COD-AGENCIA , :CBCONDEV-OPERACAO-CONTA , :CBCONDEV-NUM-CONTA , :CBCONDEV-DIG-CONTA , :CBCONDEV-SIT-REGISTRO , :CBCONDEV-DATA-QUITACAO , :CBCONDEV-VAL-TITULO , :CBCONDEV-VAL-DESCONTO , :CBCONDEV-VAL-OPERACAO , :CBCONDEV-COD-DESPESA , :CBCONDEV-COD-DEVOLUCAO , :CBCONDEV-COD-SISTEMA , :CBCONDEV-COD-USU-SOLICITA , CURRENT TIMESTAMP , :CBCONDEV-DATA-CANCELAMENTO:VIND-DTCANCEL , :CBCONDEV-COD-USU-CANCELA:VIND-CODUSU ) END-EXEC. */

            var r3110_00_INSERT_CBCONDEV_DB_INSERT_1_Insert1 = new R3110_00_INSERT_CBCONDEV_DB_INSERT_1_Insert1()
            {
                CBCONDEV_COD_EMPRESA = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_EMPRESA.ToString(),
                CBCONDEV_TIPO_MOVIMENTO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_TIPO_MOVIMENTO.ToString(),
                CBCONDEV_NUM_CHEQUE_INTERNO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_CHEQUE_INTERNO.ToString(),
                CBCONDEV_DIG_CHEQUE_INTERNO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DIG_CHEQUE_INTERNO.ToString(),
                CBCONDEV_DATA_MOVIMENTO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DATA_MOVIMENTO.ToString(),
                CBCONDEV_NUM_SEQUENCIA = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_SEQUENCIA.ToString(),
                CBCONDEV_NUM_TITULO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_TITULO.ToString(),
                CBCONDEV_COD_FONTE = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_FONTE.ToString(),
                CBCONDEV_NUM_RCAP = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_RCAP.ToString(),
                CBCONDEV_NUM_RCAP_COMPLEMEN = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_RCAP_COMPLEMEN.ToString(),
                CBCONDEV_NUM_APOLICE = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_APOLICE.ToString(),
                CBCONDEV_NUM_ENDOSSO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_ENDOSSO.ToString(),
                CBCONDEV_NUM_PARCELA = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_PARCELA.ToString(),
                CBCONDEV_COD_SUBGRUPO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_SUBGRUPO.ToString(),
                CBCONDEV_NUM_CERTIFICADO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_CERTIFICADO.ToString(),
                CBCONDEV_DATA_OCORRENCIA = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DATA_OCORRENCIA.ToString(),
                CBCONDEV_HORA_OPERACAO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_HORA_OPERACAO.ToString(),
                CBCONDEV_NUM_MATRICULA = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_MATRICULA.ToString(),
                CBCONDEV_RAMO_EMISSOR = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_RAMO_EMISSOR.ToString(),
                CBCONDEV_COD_PRODUTO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_PRODUTO.ToString(),
                CBCONDEV_COD_FILIAL = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_FILIAL.ToString(),
                CBCONDEV_COD_ESCNEG = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_ESCNEG.ToString(),
                CBCONDEV_AGE_COBRANCA = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_AGE_COBRANCA.ToString(),
                CBCONDEV_TIPO_FAVORECIDO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_TIPO_FAVORECIDO.ToString(),
                CBCONDEV_COD_FAVORECIDO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_FAVORECIDO.ToString(),
                CBCONDEV_COD_ENDERECO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_ENDERECO.ToString(),
                CBCONDEV_OCORR_ENDERECO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_OCORR_ENDERECO.ToString(),
                CBCONDEV_COD_AGENCIA = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_AGENCIA.ToString(),
                CBCONDEV_OPERACAO_CONTA = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_OPERACAO_CONTA.ToString(),
                CBCONDEV_NUM_CONTA = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_CONTA.ToString(),
                CBCONDEV_DIG_CONTA = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DIG_CONTA.ToString(),
                CBCONDEV_SIT_REGISTRO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_SIT_REGISTRO.ToString(),
                CBCONDEV_DATA_QUITACAO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DATA_QUITACAO.ToString(),
                CBCONDEV_VAL_TITULO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_VAL_TITULO.ToString(),
                CBCONDEV_VAL_DESCONTO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_VAL_DESCONTO.ToString(),
                CBCONDEV_VAL_OPERACAO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_VAL_OPERACAO.ToString(),
                CBCONDEV_COD_DESPESA = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_DESPESA.ToString(),
                CBCONDEV_COD_DEVOLUCAO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_DEVOLUCAO.ToString(),
                CBCONDEV_COD_SISTEMA = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_SISTEMA.ToString(),
                CBCONDEV_COD_USU_SOLICITA = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_USU_SOLICITA.ToString(),
                CBCONDEV_DATA_CANCELAMENTO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DATA_CANCELAMENTO.ToString(),
                VIND_DTCANCEL = VIND_DTCANCEL.ToString(),
                CBCONDEV_COD_USU_CANCELA = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_USU_CANCELA.ToString(),
                VIND_CODUSU = VIND_CODUSU.ToString(),
            };

            R3110_00_INSERT_CBCONDEV_DB_INSERT_1_Insert1.Execute(r3110_00_INSERT_CBCONDEV_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3110_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-ALTERA-SITUACAO-SECTION */
        private void R9000_00_ALTERA_SITUACAO_SECTION()
        {
            /*" -2516- MOVE '900' TO WNR-EXEC-SQL. */
            _.Move("900", W.W_NUMDOC.WABEND.WNR_EXEC_SQL);

            /*" -2521- PERFORM R9000_00_ALTERA_SITUACAO_DB_UPDATE_1 */

            R9000_00_ALTERA_SITUACAO_DB_UPDATE_1();

            /*" -2524- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2525- DISPLAY 'EM0202B - ERRO NO UPDATE DA V0EMISDIARIA' */
                _.Display($"EM0202B - ERRO NO UPDATE DA V0EMISDIARIA");

                /*" -2525- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R9000-00-ALTERA-SITUACAO-DB-UPDATE-1 */
        public void R9000_00_ALTERA_SITUACAO_DB_UPDATE_1()
        {
            /*" -2521- EXEC SQL UPDATE SEGUROS.EMISSAO_DIARIA SET SIT_REGISTRO = '1' WHERE COD_RELATORIO IN ( 'EM0202B1' , 'EM0202B2' ) AND SIT_REGISTRO = '0' END-EXEC. */

            var r9000_00_ALTERA_SITUACAO_DB_UPDATE_1_Update1 = new R9000_00_ALTERA_SITUACAO_DB_UPDATE_1_Update1()
            {
            };

            R9000_00_ALTERA_SITUACAO_DB_UPDATE_1_Update1.Execute(r9000_00_ALTERA_SITUACAO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -2537- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2538- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, W.W_NUMDOC.WABEND.WSQLCODE);

                /*" -2540- DISPLAY WABEND */
                _.Display(W.W_NUMDOC.WABEND);

                /*" -2541- MOVE SQLERRD(1) TO WSQLCODE */
                _.Move(DB.SQLERRD[1], W.W_NUMDOC.WABEND.WSQLCODE);

                /*" -2543- DISPLAY ' SQLERRD(1) = ' WSQLCODE */
                _.Display($" SQLERRD(1) = {W.W_NUMDOC.WABEND.WSQLCODE}");

                /*" -2544- MOVE SQLERRD(2) TO WSQLCODE */
                _.Move(DB.SQLERRD[2], W.W_NUMDOC.WABEND.WSQLCODE);

                /*" -2546- DISPLAY ' SQLERRD(2) = ' WSQLCODE */
                _.Display($" SQLERRD(2) = {W.W_NUMDOC.WABEND.WSQLCODE}");

                /*" -2547- MOVE SQLCODE TO WERRO */
                _.Move(DB.SQLCODE, W.WERRO);

                /*" -2548- ELSE */
            }
            else
            {


                /*" -2550- MOVE -999 TO WERRO. */
                _.Move(-999, W.WERRO);
            }


            /*" -2552- CLOSE EM0202M01 */
            EM0202M01.Close();

            /*" -2552- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -2553- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -2557- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -2557- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}