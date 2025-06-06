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
using Sias.VidaEmGrupo.DB2.VP0601B;

namespace Code
{
    public class VP0601B
    {
        public bool IsCall { get; set; }

        public VP0601B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  INTEGRA SISPF E SIAS PARA OS       *      */
        /*"      *                             PRODUTOS DE VIDA PESSOA FISICA     *      */
        /*"      *   ANALISE/PROGRAMACAO.....  LUIZ CARLOS/TERCIO CARVALHO        *      */
        /*"      *   PROGRAMA ...............  VP0601B                            *      */
        /*"      *   DATA ...................  09/08/2009.                        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 92 - D 575149  T 584775                               *      */
        /*"      *             - ACERTAR INSERT'S NA HIS_COBER_PROPOST  E         *      */
        /*"      *             V0COBERPROPVA                                      *      */
        /*"      *   29/04/2024 - HUSNI ALI HUSNI        PROCURE POR V.92         *      */
        /*"JV191 *----------------------------------------------------------------*      */
        /*"JV191 *VERSAO 91: JV1 DEMANDA 259990 - KINKAS 10/09/2020               *      */
        /*"JV191 *           INCLUI/EXCLUI APOLICES E PRODUTOS JV1                *      */
        /*"JV191 *           - PROCURAR POR JV191                                 *      */
        /*"JV191 *----------------------------------------------------------------*      */
        /*"      *   VERSAO 90 - HIST 181423                                      *      */
        /*"      *             - PREPARAR PROGRAMA PARA PROCESSAMENTO DA JV1      *      */
        /*"      *   EM 22/03/2019 - JOÃO ARAÚJO         PROCURE POR JV1          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 89                                                          */
        /*"      * MOTIVO  : ACERTO NA ROTINA DO SELECT PLANOS_VA_VGAP                   */
        /*"      * CADMUS  : 173361                                                      */
        /*"      * DATA    : 27/01/2019                                                  */
        /*"      * NOME    : DIOGO MATHEUS                                               */
        /*"      * MARCADOR: V.89                                                        */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 88                                                          */
        /*"      * MOTIVO  : ACERTO DATA PROXIMA COBRANCA "DTPROXVE"                     */
        /*"      *           APOLICE 107700000067/107700000068                           */
        /*"      *           PRODUTO CESTA DE SERVICOS                                   */
        /*"      * CADMUS  : 151597                                                      */
        /*"      * DATA    : 07/12/2017                                                  */
        /*"      * NOME    : DIOGO MATHEUS                                               */
        /*"      * MARCADOR: V.88                                                        */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 87                                                          */
        /*"      * MOTIVO  : ACERTO DATA PROXIMA COBRANCA NA VG_MOVTO_PRESTAMISTA        */
        /*"      *           APOLICE 107700000067/107700000068                           */
        /*"      *           PRODUTO CESTA DE SERVICOS                                   */
        /*"      * CADMUS  : 151597                                                      */
        /*"      * DATA    : 20/11/2017                                                  */
        /*"      * NOME    : DIOGO MATHEUS                                               */
        /*"      * MARCADOR: V.87                                                        */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 86                                                          */
        /*"      * MOTIVO  : ACERTO DATA PROXIMA COBRANCA NA PROPOSTAS_VA                */
        /*"      *           APOLICE 107700000067/107700000068                           */
        /*"      *           PRODUTO CESTA DE SERVICOS                                   */
        /*"      * CADMUS  : 151597                                                      */
        /*"      * DATA    : 07/11/2017                                                  */
        /*"      * NOME    : DIOGO MATHEUS                                               */
        /*"      * MARCADOR: V.86                                                        */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 85                                                          */
        /*"      * MOTIVO  : AVERBACAO PRESTAMISTA PJ PRODUTO 7732/7733                  */
        /*"      *           APOLICE 107700000067/107700000068                           */
        /*"      *           PRODUTO CESTA DE SERVICOS                                   */
        /*"      * CADMUS  : 151597                                                      */
        /*"      * DATA    : 23/06/2017                                                  */
        /*"      * NOME    : DIOGO MATHEUS                                               */
        /*"      * MARCADOR: V.85                                                        */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 084                                                         */
        /*"      * MOTIVO  : RESTITUICAO DE PREMIO INDEVIDA PARA APOLICE                 */
        /*"      *           107700000056 PRODUTO 7725                                   */
        /*"      * CADMUS  : 153489                                                      */
        /*"      * DATA    : 25/09/2017                                                  */
        /*"      * NOME    : DIOGO MATHEUS                                               */
        /*"      * MARCADOR: V.84                                                        */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 083                                                         */
        /*"      * MOTIVO  : AUMENTAR VALOR DA IMPORTANCIA SEGURADA DAS APOLICES:        */
        /*"      *           107700000011 - 107700000013 - 107700000056                  */
        /*"      * CADMUS  : 150893                                                      */
        /*"      * DATA    : 19/05/2017                                                  */
        /*"      * NOME    : DIOGO MATHEUS                                               */
        /*"      * MARCADOR: V.83                                                        */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 082                                                         */
        /*"      * MOTIVO  : VOLTAR VERSAO ANTERIOR PARA NAO PEGAR ALTERACOES DO         */
        /*"      *           RAMO 37 (NA VERSAO 81)                                      */
        /*"      * CADMUS  : 134954                                                      */
        /*"      * DATA    : 18/04/2016                                                  */
        /*"      * NOME    : DIOGO MATHEUS                                               */
        /*"      * MARCADOR: V.82                                                        */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 80                                                          */
        /*"      * MOTIVO  : ABEND 0C7 POR NAO ENCONTRAR A TAXA DO PLANO DO 7725         */
        /*"      * CADMUS  : 125881                                                      */
        /*"      * DATA    : 20/11/2015                                                  */
        /*"      * NOME    : DIOGO MATHEUS                                               */
        /*"      * MARCADOR: V.80                                                        */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 79                                                          */
        /*"      * MOTIVO  : CODIGO DE PESSOA NAO CADASTRADO NA PESSOA FISICA            */
        /*"      * CADMUS  : 125561                                                      */
        /*"      * DATA    : 18/11/2015                                                  */
        /*"      * NOME    : DIOGO MATHEUS                                               */
        /*"      * MARCADOR: V.79                                                        */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 78                                                          */
        /*"      * MOTIVO  : AVERBACAO PRESTAMISTA PJ PRODUTO 7725                       */
        /*"      *           APOLICE 107700000056                                        */
        /*"      * CADMUS  : 124561                                                      */
        /*"      * DATA    : 29/10/2015                                                  */
        /*"      * NOME    : DIOGO MATHEUS                                               */
        /*"      * MARCADOR: V.78                                                        */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 77                                                          */
        /*"      * MOTIVO  : TRATAR MATRICULA DO VENDEDOR IGUAL 9999999                  */
        /*"      * CADMUS  : 119720                                                      */
        /*"      * DATA    : 30/07/2015                                                  */
        /*"      * NOME    : DIOGO MATHEUS                                               */
        /*"      * MARCADOR: V.77                                                        */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 76                                                          */
        /*"      * MOTIVO  : INCLUIR OPERACAO CDC PRESTAMISTA PRODUTO 7707 TE LIGO       */
        /*"      *           APOLICE 107700000013                                        */
        /*"      * CADMUS  : 104520                                                      */
        /*"      * DATA    : 07/07/2015                                                  */
        /*"      * NOME    : DIOGO MATHEUS                                               */
        /*"      * MARCADOR: V.76                                                        */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 75                                                          */
        /*"      * MOTIVO  : ABEND ROTINA JPSID05 (PROPOSTA SEM O CODIGO DO CLIENTE      */
        /*"      *           CADASTRADA NA TABELA PESSOA_FISICA).                        */
        /*"      *           AGORA SO VAI SELECIONAR PROPOSTAS QUE TENHA O CODIGO        */
        /*"      *           DO CLIENTE CADASTRADA NA TABELA PESSOA_FISICA.              */
        /*"      * CADMUS  : 116561                                                      */
        /*"      * DATA    : 08/06/2015                                                  */
        /*"      * NOME    : DIOGO MATHEUS                                               */
        /*"      * MARCADOR: V.75                                                        */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 74                                                          */
        /*"      * MOTIVO  : ACERTO ROTINA R2247-CALCULO-IDADE                           */
        /*"      * CADMUS  : 106845                                                      */
        /*"      * DATA    : 02/02/2015                                                  */
        /*"      * NOME    : RICARDO PIANOWSKI DE MORAES                                 */
        /*"      * MARCADOR: V.74                                                        */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 73                                                          */
        /*"      * MOTIVO  : INCLUSAO DISPLAY PARA SOLUCAO PROBLEMA PROD. 7713           */
        /*"      * CADMUS  : 106845                                                      */
        /*"      * DATA    : 28/01/2015                                                  */
        /*"      * NOME    : RICARDO PIANOWSKI DE MORAES                                 */
        /*"      * MARCADOR: V.73                                                        */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 72                                                          */
        /*"      * MOTIVO  : REGULARIZACAO PARA PRODUTOS 7713 E 7715 (70 ANOS)           */
        /*"      * CADMUS  : 106845                                                      */
        /*"      * DATA    : 19/01/2015                                                  */
        /*"      * NOME    : RICARDO PIANOWSKI DE MORAES                                 */
        /*"      * MARCADOR: V.72                                                        */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 71                                                          */
        /*"      * MOTIVO  : PARAMETRIZACAO DA IS SUPERIOR                               */
        /*"      * CADMUS  : 91060                                                       */
        /*"      * DATA    : 11/02/2014                                                  */
        /*"      * NOME    : DIOGO MATHEUS                                               */
        /*"      * MARCADOR: V.71                                                        */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 70                                                          */
        /*"      * MOTIVO  : NOVO PRODUTO 7715 - PRESTAMISTA MICROCREDITO BALCAO         */
        /*"      * CADMUS  : 90195                                                       */
        /*"      * DATA    : 02/12/2013                                                  */
        /*"      * NOME    : DIOGO MATHEUS                                               */
        /*"      * MARCADOR: V.70                                                        */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 69                                                          */
        /*"      * MOTIVO  : IS SUPERIOR 300 MIL P/ CPF 031.548.426-83                   */
        /*"      * CADMUS  : 90733                                                       */
        /*"      * DATA    : 02/12/2013                                                  */
        /*"      * NOME    : DIOGO MATHEUS                                               */
        /*"      * MARCADOR: V.67                                                        */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 68                                                          */
        /*"      * MOTIVO  : NOVO PRODUTO 7715 - PRESTAMISTA MICROCREDITO BALCAO         */
        /*"      * CADMUS  : 90195                                                       */
        /*"      * DATA    : 28/11/2013                                                  */
        /*"      * NOME    : GIOVANI CUNHA                                               */
        /*"      * MARCADOR: V.68                                                        */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 67                                                          */
        /*"      * MOTIVO  : IS SUPERIOR 300 MIL P/ CPF 031.548.426-83                   */
        /*"      * CADMUS  : 90733                                                       */
        /*"      * DATA    : 26/11/2013                                                  */
        /*"      * NOME    : DIOGO MATHEUS                                               */
        /*"      * MARCADOR: V.67                                                        */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 66 - CAD 90233                                               */
        /*"      *                                                                *      */
        /*"      *           - ACEITAR IS SUPERIOR A 300.000,00 PARA O CPF        *      */
        /*"      *             323.447.406-00                                  *         */
        /*"      *   EM 20/11/2013 - PATRICIA SALES                               *      */
        /*"      *                                            PROCURE POR V.66    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 65 - CAD 87.036                                              */
        /*"      *                                                                *      */
        /*"      *           - CORRIGIR CRITICA IGUAL'9' QUITACRED PROD 7708             */
        /*"      *                                                                *      */
        /*"      *   EM 25/09/2013 - ALEXANDRE ANDRE                              *      */
        /*"      *                                            PROCURE POR V.65    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 64 - CAD 86.564                                              */
        /*"      *                                                                *      */
        /*"      *           - ACEITAR IS SUPERIOR A 300.000,00 PARA O CPF        *      */
        /*"      *             486.207.186-49                                            */
        /*"      *             PRODUTO: 7708                                             */
        /*"      *                                                                *      */
        /*"      *   EM 26/08/2013 - ALEXANDRE ANDRE                              *      */
        /*"      *                                            PROCURE POR V.64    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 63 - CAD 81.989                                       *      */
        /*"      *                                                                *      */
        /*"      *           - ACEITAR VALIDACAO DE IS PARA O 7713.               *      */
        /*"      *                                                                *      */
        /*"      *   EM 01/07/2013 - PATRICIA SALES                               *      */
        /*"      *                                            PROCURE POR V.63    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 62 - CAD 81.989                                       *      */
        /*"      *                                                                *      */
        /*"      *           - ACEITAR IS SUPERIOR A 300.000,00 PARA O CPF        *      */
        /*"      *             00342082752, 56002424849 E 17815789668.            *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/04/2013 - ROMINA BRANCO                                *      */
        /*"      *                                            PROCURE POR V.62    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 61 - CAD 81.159                                       *      */
        /*"      *                                                                *      */
        /*"      *           ADEQUACOES PROJETO CRESCER - MICROCREDITO                   */
        /*"      *                                                                *      */
        /*"      *   EM 03/04/2013 - DIOGO MATHEUS                                *      */
        /*"      *                                            PROCURE POR V.61    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 60 - CAD 76.196                                       *      */
        /*"      *                                                                *      */
        /*"      *           - PAGAMENTO A VISTA PARA CANAL DE VENDA CERAT        *      */
        /*"      *                                                                *      */
        /*"      *   EM 10/01/2013 - PEDRO SILVERIO                               *      */
        /*"      *                                            PROCURE POR V.60    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 59 - CAD 75.792                                       *      */
        /*"      *                                                                *      */
        /*"      *           - ATUALIZAR AGENCIA DE PAGAMENTO DA PROPOSTA_FIDELIZ *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/11/2012 - ROMINA BRANCO                                *      */
        /*"      *                                            PROCURE POR V.59    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 58 - CAD 70.534                                       *      */
        /*"      *                                                                *      */
        /*"      *              - RETIRAR AS CRITICAS PARA OS PRODUTOS            *      */
        /*"      *                7705 - SEGURO DIVIDA ZERO                       *      */
        /*"      *                7707 - PRESTAMISTA TE LIGO                      *      */
        /*"      *                                                                *      */
        /*"      *              MANTER APENAS AS CRÍTICAS REFERENTES A LIMITE     *      */
        /*"      *              DE IDADE E VALOR DE IS.                           *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/06/2012 - MARCELO NEVES                                *      */
        /*"      *                                            PROCURE POR V.58    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 57 - CAD 68.579                                       *      */
        /*"      *                                                                *      */
        /*"      *              - TRATAMENTO PARA PRODUTO 7708                    *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *   EM 28/05/2012 - MARCO PAIVA (FAST COMPUTER)                  *      */
        /*"      *                                            PROCURE POR V.57    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 56 - CAD 67.453                                       *      */
        /*"      *                                                                *      */
        /*"      *              - RETIRADA DA CRITICA DE DPS                      *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *   EM 12/03/2012 - RILDO SICO                                   *      */
        /*"      *                                            PROCURE POR V.56    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 55 - CAD 66.061                                       *      */
        /*"      *                                                                *      */
        /*"      *              - PASSA PARA R$300.000,00 A IS MAXIMA PARA        *      */
        /*"      *                LIBERACAO AUTOMATICA DO SEGURO.                 *      */
        /*"      *                                                                *      */
        /*"      *   EM 06/02/2012 - TERCIO CARVALHO(FAST COMPUTER)               *      */
        /*"      *                                            PROCURE POR V.55    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 54 - CAD 57.705                                       *      */
        /*"      *                                                                *      */
        /*"      *              - SERA TRATADA NESTA ALTERACAO O REGISTRO TIPO    *      */
        /*"      *                " $ ". REGISTRO ORIUNDO DO AIC, PARA INCLUSAO   *      */
        /*"      *                DO NUMERO CRIADO PARA O CREDMINAS (756) NA      *      */
        /*"      *                TABELA CONVERSAO_SICOB E PROPOSTA_FIDELIZ.      *      */
        /*"      *                PASSARA A RECUPERAR DA RCAPS O NUMERO DO        *      */
        /*"      *                NRMATRVEN DA PROPOSTA_FIDELIZ.                  *      */
        /*"      *                                                                *      */
        /*"      *   EM 13/01/2012 - EDIVALDO GOMES(FAST COMPUTER)                *      */
        /*"      *                                            PROCURE POR V.54    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 53 - CADMUS 64866                                     *      */
        /*"      *                                                                *      */
        /*"      *              - AJUSTE NO ACESSO A PLANOS_VA_VGAP PARA          *      */
        /*"      *                UTILIZAR COMO ARGUMETNO DE PESQUISA A           *      */
        /*"      *                DATA DA PROPOSTA AO INVES DA DATA DE            *      */
        /*"      *                QUITACAO PARA OS PRODUTOS TE LIGO CROT          *      */
        /*"      *                                                                *      */
        /*"      *   EM 28/12/2011 - TERCIO CARVALHO (FAST)                       *      */
        /*"      *                                            PROCURE POR V.53    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 52 - CADMUS 63724                                     *      */
        /*"      *                                                                *      */
        /*"      *              - RETIRAR CRITICA CODIGO DE ERRO 1800             *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/07/2011 - PATRICIA SALES(STEFANINI)                    *      */
        /*"      *                                            PROCURE POR V.52    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 51 - CAD  60.709                                      *      */
        /*"      *                                                                *      */
        /*"      *              - RETIRAR CRITICA CODIGO DE ERRO 1801             *      */
        /*"      *                                                                *      */
        /*"      *   EM 29/08/2011 - JEFFERSON                                    *      */
        /*"      *                                            PROCURE POR V.51    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 50 - CAD  56.854                                      *      */
        /*"      *                                                                *      */
        /*"      *              - RETIRAR CRITICA CODIGO DE ERRO 1800             *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/07/2011 - LOPES         (FAST COMPUTER)                *      */
        /*"      *                                            PROCURE POR V.50    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 49 - CAD  59.412                                      *      */
        /*"      *                                                                *      */
        /*"      *              - TRATAR ABEND 0C7.                               *      */
        /*"      *                                                                *      */
        /*"      *   EM 19/07/2011 - LOPES         (FAST COMPUTER)                *      */
        /*"      *                                            PROCURE POR V.49    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 48 - CAD 201.047                                      *      */
        /*"      *                                                                *      */
        /*"      *              - AJUSTE   DO NOVO CALCULO DO PRESTAMISTA         *      */
        /*"      *                                                                *      */
        /*"      *   EM 03/04/2011 - EDIVALDO GOMES(FAST COMPUTER)                *      */
        /*"      *                                            PROCURE POR V.48    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 47 - CAD 49.184                                       *      */
        /*"      *                                                                *      */
        /*"      *              - TRATAMENTO PARA PRODUTO 7707 (CROTINHO) VENDIDO *      */
        /*"      *                NO CANAL CERAT.                                 *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/10/2010 - EDIVALDO GOMES(FAST COMPUTER)                *      */
        /*"      *                                            PROCURE POR V.47    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 46 - CAD 44.763                                       *      */
        /*"      *                                                                *      */
        /*"      *              - NOVO CALCULO DE PREMIO POR ALIQUIOTAS E NOVAS   *      */
        /*"      *                CRITICAS PARA O PRODUTO 7705.                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/08/2010 - EDIVALDO GOMES(FAST COMPUTER)                *      */
        /*"      *                                            PROCURE POR V.46    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 45 - CAD 41.644                                       *      */
        /*"      *                                                                *      */
        /*"      *              - NAO CRITICAR O ERRO 1800 PARA O CREDIMINAS      *      */
        /*"      *                                                                *      */
        /*"      *   EM 27/04/2010 - MARCO PAIVA    (FAST COMPUTER)               *      */
        /*"      *                                            PROCURE POR V.45    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 44 - CAD 41.441 /41.158                               *      */
        /*"      *                                                                *      */
        /*"      *              - NAO INSERIR NA TABELA RELATORIOS PARA O         *      */
        /*"      *                CREDMINAS.                                      *      */
        /*"      *                                                                *      */
        /*"      *   EM 23/04/2010 - TERCIO FREITAS (FAST COMPUTER)               *      */
        /*"      *                                            PROCURE POR V.44    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 43 - CAD 36.344                                       *      */
        /*"      *                                                                *      */
        /*"      *              - AJUSTE NO PROCESSAMENTO DO ARQUIVO AIC          *      */
        /*"      *                CREDMINAS.                                      *      */
        /*"      *                                                                *      */
        /*"      *   EM 27/01/2010 - MARCO PAIVA (FAST COMPUTER)                  *      */
        /*"      *                                            PROCURE POR V.43    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 42 - CAD 35.719                                       *      */
        /*"      *                                                                *      */
        /*"      *              - AJUSTE NO PROCESSAMENTO DO ARQUIVO AIC          *      */
        /*"      *                CREDMINAS.                                      *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/01/2010 - FAST COMPUTER            PROCURE POR V.42    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 41 - CAD 31.471                                       *      */
        /*"      *                                                                *      */
        /*"      *              - ALTERACAO PARA PROCESSAR AS INFORMACOES         *      */
        /*"      *                PROVENIENTES DO SISTEMA AIC.                    *      */
        /*"      *                                                                *      */
        /*"      *   EM 16/11/2009 - FAST COMPUTER (EDIVALDO)    PROCURE POR V.41 *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 40 - CAD 27.301                                       *      */
        /*"      *               VERSAO DO PROGRAMA PF0601B PARA SEPARACAO DO     *      */
        /*"      *               MOVIMENTO ORIUNDO DO SIVPF.                      *      */
        /*"      *                                                                *      */
        /*"      *   EM 09/08/2009 - FAST COMPUTER            PROCURE POR V.40    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 39 - CAD 27.193                                       *      */
        /*"      *               CORRECAO DOS VALORES DA COLUNA VLCUSTAUXF        *      */
        /*"      *               DA TABELA HIS_COBER_PROPOST                      *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/07/2009 - LEANDRO CORTES  -  FAST COMPUTER             *      */
        /*"      *                                                                *      */
        /*"      *                                      PROCURE POR V.39          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 38 - CAD 24.543                                       *      */
        /*"      *               TRATA APOLICE 107700000013, PRODUTO 7707         *      */
        /*"      *               - PRESTAMISTA GITEL - SEM PLANO                  *      */
        /*"      *                                                                *      */
        /*"      *   EM 15/06/2009 - FAST COMPUTER            PROCURE POR V.38    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 37                                                    *      */
        /*"      *             - CAD 22910                                        *      */
        /*"      *               NOVOS CAMPOS PARA O PRESTAMISTA                  *      */
        /*"      *                                                                *      */
        /*"      *   EM 15/04/2009 - FAST COMPUTER            PROCURE POR V.37    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 36                                                    *      */
        /*"      *             - CAD 23642                                        *      */
        /*"      *                                                                *      */
        /*"      *             - RETIRA O SEGURO PRESTAMISTA DO CPF RECORRENTE    *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/04/2009 - FAST COMPUTER            PROCURE POR V.36    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 35                                                    *      */
        /*"      *             - CAD 17625                                        *      */
        /*"      *               INCLUI CRITICA PARA CPF RECORRENTE               *      */
        /*"      *                                                                *      */
        /*"      *   EM 14/01/2009 - FAST COMPUTER            PROCURE POR V.35    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 34                                                    *      */
        /*"      *             - SSI 24168                                        *      */
        /*"      *               INCLUI CRITICA PARA GRAU DE PARENTESCO GERADO    *      */
        /*"      *               COMO 'ERROPF' PELO PF0600B PARA EVITAR ABEND     *      */
        /*"      *                                                                *      */
        /*"      *   EM 29/12/2008 - LUCIA VIEIRA             PROCURE POR V.34    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 33                                                    *      */
        /*"      *             - CAD 16.415                                       *      */
        /*"      *               FAZER O ACUMULO DE RISCO PELO VALOR DA I.S       *      */
        /*"      *               PARA CANAL GITEL.                                *      */
        /*"      *                                                                *      */
        /*"      *   EM 14/11/2008 - FAST COMPUTER            PROCURE POR V.33    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 32                                                    *      */
        /*"      *             - CAD 15.191                                       *      */
        /*"      *               GERACAO INDEVIDA DE PROPOSTAS_VA PARA            *      */
        /*"      *               PROPOSTAS SEM PAGAMENTO.                         *      */
        /*"      *                                                                *      */
        /*"      *   EM 01/11/2008 - FAST COMPUTER            PROCURE POR V.32    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 31                                                    *      */
        /*"      *             - CAD 13.762                                       *      */
        /*"      *               REVISAO PRODUTOS PU                              *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/09/2008 - FAST COMPUTER            PROCURE POR V.31    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 30                                                    *      */
        /*"      *             - CAD 12.962                                       *      */
        /*"      *               CARREGA 9999-12-31 NA DTPROXVEN DA PROPOSTA_VA   *      */
        /*"      *               PARA PRODUTOS DE PAGAMENTO UNICO, ALEM DE        *      */
        /*"      *               AJUSTAR O ACUMULO DE RISCO PARA O PRODUTO 77     *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/08/2008 - FAST COMPUTER            PROCURE POR V.30    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 29                                                    *      */
        /*"      *             - CAD 11.624                                       *      */
        /*"      *               VENDA DE VIDA MULHER NO CANAL GITEL              *      */
        /*"      *                                                                *      */
        /*"      *   EM 19/07/2008 - FAST COMPUTER            PROCURE POR V.29    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 28                                                    *      */
        /*"      *             - CAD 09.373                                       *      */
        /*"      *               DISPENSA DE DPS PARA VIDA SENIOR                 *      */
        /*"      *                                                                *      */
        /*"      *             - CAD 10.010                                       *      */
        /*"      *               DISPENSA DE DPS PARA VIDA MULHER                 *      */
        /*"      *                                                                *      */
        /*"      *             - CAD 10.559                                       *      */
        /*"      *               PAGAMENTO UNICO COM VIGENCIA DE 36 MESES PARA    *      */
        /*"      *               OS PRODUTOS:                                     *      */
        /*"      *                  . 9333 - VIDA DA GENTE       - 109300001391   *      */
        /*"      *                  . 9334 - VIDA MULHER <=30000 - 109300001392   *      */
        /*"      *                  . 9334 - VIDA MULHER         - 109300001393   *      */
        /*"      *                  . 9332 - MULTIPREMIADO SUPER - 109300001394   *      */
        /*"      *                                                                *      */
        /*"      *             - CAD 11.105                                       *      */
        /*"      *               MUDANCA DE LIMITE DE LIBERACAO AUTOMATICA DE     *      */
        /*"      *               R$30.000,00 PARA R$200.000,00                    *      */
        /*"      *                                                                *      */
        /*"      *   EM 31/05/2008 - FAST COMPUTER            PROCURE POR V.28    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 27 - ATENDE SSI 22074 - VIDA DA GENTE - GITEL         *      */
        /*"      *               PASSOU A TRATAR ERRO 501 QUANDO NAO HOUVER       *      */
        /*"      *               ENDERECO CADASTRADO.                             *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/05/2008 - LUIZ CARLOS - GAROTINHO  PROCURE POR V.27    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 26 - ATENDE SSI 21955 - VIDA DA GENTE - GITEL         *      */
        /*"      *               RETIRAR ERRO 1501 PARA PRODTO VIDA DA GENTE = 11 *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/05/2008 - LUCIA.VIEIRA             PROCURE POR V.26    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 25 - ESPECIFICACOES 036, 039 E 040 DE 2007.           *      */
        /*"      *               VERSAO 11.7.0.                                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 16/04/2008 - MAURICIO LINKE           PROCURE POR V.25    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 24 - CAD 09.135/2008                                  *      */
        /*"      *               TRATA O PRODUTO CANAL GITEL PARA VIDA DA GENTE   *      */
        /*"      *                                                                *      */
        /*"      *   EM 12/04/2008 - FAST COMPUTER            PROCURE POR V.24    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 23- ACRESCENTA ROTINA ESPECIFICA PARA ACESSAR A         *      */
        /*"      *            PLANOS_VA_VGAP PARA O PRESTAMISTA CONSIGNACAO,      *      */
        /*"      *            PRODUTO 77.                                         *      */
        /*"      *                                                                *      */
        /*"      * 15/02/2008 PROCURE POR V.23 - FAST COMPUTER                    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 22- PASSA A NAO CRITICAR DPS E PROFISSAO PARA A APOLICE *      */
        /*"      *            109300000598 (VIDA DA GENTE)                        *      */
        /*"      *                                                                *      */
        /*"      * 12/02/2008 PROCURE POR V.22 - FAST COMPUTER                    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 21- CORRECAO NO ACUMULO DE RISCO PELO VALOR DA I.S      *      */
        /*"      *            MAXIMA DA TABELA PLANOS_VA_VGAP POR PRODUTO E DENTRO*      */
        /*"      *            DA FAIXA ETARIA. -  SSI-20.356                      *      */
        /*"      *                                                                *      */
        /*"      * 01/02/2008 PROCURE POR V.21 - FAST COMPUTER                    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 20- PASSA A NAO CRITICAR DPS E PROFISSAO NA REFORMULACAO*      */
        /*"      *            DO VIDA DA GENTE.                                   *      */
        /*"      *                                                                *      */
        /*"      * 28/12/2007 PROCURE POR V.20 - LUCIA / LUIZ CARLOS              *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 19- PASSA A TRATAR PRODUTO-SIVPF = 77 (PRESTAMISTA)     *      */
        /*"      *                                                                *      */
        /*"      * 27/12/2007 PROCURE POR V.19 - LUCIA / LUIZ CARLOS              *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 18- DESPREZAR COD_PRODUTO_SIVPF IGUAL A 48. TRATA-SE DA *      */
        /*"      *            INTERNALIZACAO DE APOLICE ESPECIFICA DE VIDA.       *      */
        /*"      *                                                                *      */
        /*"      * 27/11/2007 PROCURE POR V.18 - MAURICIO LINKE.                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 17 - PASSA A TORNAR A PROPOSTA COM A SITUACAO         *      */
        /*"      *               IGUAL A 'E' - AGUARDANDO CRIVO -                 *      */
        /*"      *               PARA AS PROPOSTAS NAO DECLINADAS                 *      */
        /*"      *                                                                *      */
        /*"      *   EM 12/09/2007 - FAST COMPUTER            PROCURE POR V.17    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 16 - ACRESCENTAR NO ACESSO A TABELA PROPOSTAS_VA      *      */
        /*"      *               A SITUACAO '0' E '9'                             *      */
        /*"      *                                                                *      */
        /*"      *   EM 31/07/2007 - FAST COMPUTER            PROCURE POR V.16    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 15 - SSI 16.306                                       *      */
        /*"      *                                                                *      */
        /*"      *               INCLUIDA COMO DECLINAVE A PROFISSAO DE           *      */
        /*"      *               DELEGADO DE POLICIA PARA TITULAR E CONJUGE       *      */
        /*"      *                                                                *      */
        /*"      *   EM 19/06/2007 - FAST COMPUTER            PROCURE POR V.15    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 14 - FAZER O ACUMULO DE RISCO PELO VALOR DA I.S       *      */
        /*"      *               MAXIMA DA                                        *      */
        /*"      *               TABELA PLANOS_VA_VGAP POR PRODUTO E DENTRO DA    *      */
        /*"      *               FAIXA ETARIA.                                    *      */
        /*"      *                                                                *      */
        /*"      *             - SE A SOMA DA I.S DOS SEGUROS ATIVOS NO MESMO     *      */
        /*"      *               PRODUTO ULTRAPASSAR O LIMITE, A PROPOSTA         *      */
        /*"      *               SERA DECLINADA AUTOMATICAMENTE   (SSI 10.234)    *      */
        /*"      *                                                                *      */
        /*"      *   EM 29/01/2007 - FAST COMPUTER            PROCURE POR V.14    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 13 - AUMENTADO O LIMITE PARA EMISSAO AUTOMATICA       *      */
        /*"      *               PARA R$50.000,00 PARA VENDAS ELETRONICAS ;       *      */
        /*"      *                                                                *      */
        /*"      *             - DECLINIO AUTOMATICO DE PROPOSTAS CUJA DPS        *      */
        /*"      *               ESTEJA PREENCHIDA COM S NA SEGUNDA POSICAO       *      */
        /*"      *               QUE INDICA APOSENTADO POR INVALIDEZ.             *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/10/2006 - FAST COMPUTER            PROCURE POR V.13    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 12 - RETIRADA O FILTRO DE 50 ANOS DE IDADE            *      */
        /*"      *                                                                *      */
        /*"      *   EM 29/09/2006 - FAST COMPUTER            PROCURE POR V.12    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 11 - RETIRADA A CONSISTENCIA DE CEP                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/09/2006 - FAST COMPUTER            PROCURE POR V.11    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 10 - DIFERENCA DE UM CENTAVO ENTRE A PLANOS E O RCAP  *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/09/2006 - FAST COMPUTER            PROCURE POR V.10    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 09 - ABEND S0C4 - INVASAO DE AREA DO DB2              *      */
        /*"      *                                                                *      */
        /*"      *   EM 15/09/2006 - FAST COMPUTER            PROCURE POR V.09    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 08 - PASSOU A CONSISTIR CEP                           *      */
        /*"      *                                                                *      */
        /*"      *   EM 09/08/2006 - FAST COMPUTER            PROCURE POR V.08    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 07 - PASSOU A TRATAR OS NOVOS SUBGRUPOS DOS PRODUTOS  *      */
        /*"      *               VIDA DA GENTE, MULTIPREMIADO SUPER, SENIOR E     *      */
        /*"      *               VIDA MULHER NA REFORMULACAO DO VIDA.             *      */
        /*"      *                                                                *      */
        /*"      *   EM 28/06/2006 - FAST COMPUTER            PROCURE POR V.07    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 06 - PASSA A TRATAR CRITICA DE CONJUGE APENAS PARA    *      */
        /*"      *               OS SUBGRUPOS COM CARREGA_CONJUGE <> 0            *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/05/2006 - LUCIA VIEIRA             PROCURE POR V.06    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 05 - IMPEDE ABEND POR SQLCODE = -811 NA PESQUISA DA   *      */
        /*"      *               TEBELA SEGUROS_PESSOA_TELEFONE - PARAGRAFO R2230 *      */
        /*"      *                                                                *      */
        /*"      *   EM 24/04/2006 - LUCIA VIEIRA             PROCURE POR V.05    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 04 - PASSA A MELHOR QUALIFICAR A DESCRICAO DA         *      */
        /*"      *               PROFISSAO INSERINDO OU ATUALIZANDO A DESCRICAO   *      */
        /*"      *               DE ACORDO COM O QUE EXISTE NA TABELA PF_CBO      *      */
        /*"      *                                                                *      */
        /*"      *   EM 24/02/2006 - ALEXANDRE BERNARDES      PROCURE POR V.04    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 03 - ALTERADA A ABORDAGEM NA RECUPERACAO DO ENDERECO  *      */
        /*"      *               PASSANDO A RECUPERAR A OCORRENCIA DE ENDERECO    *      */
        /*"      *               A PARTIR DOS DADOS VINDOS NO SIVPF E NAO COM  A  *      */
        /*"      *               OCORRENCIA DE ENDERECO 1 COMO E FEITO HOJE.      *      */
        /*"      *               PASSA TAMBEM A NAO MAIS ALTERAR A TABELA         *      */
        /*"      *               ENDERECOS.                                       *      */
        /*"      *               PASSA TAMBEM A ALIMENTAR A TABELA CLIENTE_EMAIL  *      */
        /*"      *                                                                *      */
        /*"      *   EM 31/01/2006 - FAST COMPUTER            PROCURE POR V.03    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 02 - PASSOU A CRITICAR A FAIXA DE RENDA, IDADE MENOR  *      */
        /*"      *               QUE 50 E LIMITE DE 30000,00 (TRINTA MIL) PARA    *      */
        /*"      *               LIBERAR AS PROPOSTAS AUTOMATICAMENTE.            *      */
        /*"      *                                                                *      */
        /*"      *   EM 17/01/2006 - FAST COMPUTER            PROCURE POR V.02    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01 - PASSOU A TRATAR O NUMERO DO CARTAO DE CREDITO    *      */
        /*"      *               INCLUSIVE COM A CRITICA DA BANDEIRA, ALEM DE     *      */
        /*"      *               CORRIGIR O TIPO DE TELEFONE QUE ESTAVA TRATANDO  *      */
        /*"      *               O TIPO 4 COMO TELEFONE INDEVIDAMENTE.            *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/09/2005 - TERCIO CARVALHO          PROCURE POR V.01    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *  CRITICA PROPOSTAS DE PRODUTOS DE FIDELIZACAO VIDA             *      */
        /*"      *  VISANDO INCLUSAO NA ESTRUTURA DE EMISSAO DO MULTIPREMIADO     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ADEQUACAO PARA TRATAR PROFISSAO OUTROS / SERVIDOR PUBLICO.     *      */
        /*"      * (PROCURAR POR LC0904) SAMUEL - 28/12/2004 - V.10               *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ADEQUACAO PARA NAO GERAR OPCAO_PAG_VIDAZUL, NO CASO DE CARTAO  *      */
        /*"      * DE CREDITO, QUE E GERADO NO PF0600B.                           *      */
        /*"      * (PROCURAR POR LC0904) LUIZ CARLOS - EM 22/09/2002.             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * IMPLEMENTACAO DE CONTROLE CIRCULAR 200 SUSEP - DATA EXPEDICAO  *      */
        /*"      * (PROCURAR POR LC0304) LUIZ CARLOS - EM 16/04/2003.             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * IMPLEMENTACAO DE CONTROLE DE MOVTO CLIENTE           NOV/2001  *      */
        /*"      * (PROCURAR POR EB1101)     ENRICO (PRODEXTER)                   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * IMPLEMENTACAO DA NOVA CODIFICACAO DE ESCRITORIO DE NEGOCIOS    *      */
        /*"      * (PROCURAR POR EB0202) - ENRICO (PRODEXTER)            FEV/2002 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 12 - PASSA A CRITICAR CGCCPF. CRITICA TAMBEM A PROFISSAO       *      */
        /*"      *      OUTROS.                                                   *      */
        /*"      *                                                                *      */
        /*"      *      PROCURE 'TL0301'                                          *      */
        /*"      *                                                                *      */
        /*"      *      TERCIO CARVALHO 04/02/2003                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 12 - PASSA A CRITICAR O CONVENIO CAIXA DO TRABALHADOR.         *      */
        /*"      *                                                                *      */
        /*"      *      PROCURE 'TL0210' OU RCAP-CADASTRADO.                      *      */
        /*"      *                                                                *      */
        /*"      *      TERCIO CARVALHO 30/10/2002                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 11 - PROPOSTAS PENDENTES DE SICOB, SERAO CADASTRADAS AS TABELAS*      */
        /*"      *      PROPOSTAS_VA, OPCAOPAGVA E COBERPROPVA,DEVENDO A MESMA SER*      */
        /*"      *      LIBERADA NA APLICACAO VLN0 - CAMINHO 4-19-1-1.            *      */
        /*"      *      (COD-ERRO 1501 - RCAP NAO ENCONTRADO).                    *      */
        /*"      *                                                                *      */
        /*"      *      PROCURE 'LC0816' OU RCAP-CADASTRADO.                      *      */
        /*"      *                                                                *      */
        /*"      *      LUIZ CARLOS  16/08/2001.                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 10 - PROPOSTAS COM PROBLEMAS NA TABELA PLANOS_VGAP, POSSAM   A *      */
        /*"      *      SER CADASTRADAS NA ESTRUTURA DO MULTPREMIADO, DEVENDO SER *      */
        /*"      *      LIBERADAS NA APLICACAO VLN0 - CAMINHO 4-19-1-1.           *      */
        /*"      *      (COD-ERRO 604 - PLANO NAO CADASTRADO).                    *      */
        /*"      *                                                                *      */
        /*"      *      PROCURE 'LC0813' OU EXISTE-PLANO.                         *      */
        /*"      *                                                                *      */
        /*"      *      LUIZ CARLOS  13/08/2001.                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 09 - PASSOU A TRATAR PROPOSTAS REMOTAS COM SIT-PROPOSTA = 'POV'*      */
        /*"      *      SAO AS PROPOSTAS REMOTAS SEM AS INFORMACOES DO SICOB.     *      */
        /*"      *                                                                *      */
        /*"      *      LUIZ CARLOS  02/08/2001.                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 08 - PASSOU A TRATAR QUALQUER ABEND NA V0CLIENTE, PASSANDO A   *      */
        /*"      *      NAO PROCESSAR A REFERIDA PROPOSTA. PROCURE POR LC0606.    *      */
        /*"      *                                                                *      */
        /*"      *      LUIZ CARLOS  06/06/2001.                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * 07 - POR SOLICITACAO DO USUARIO, AS PROPOSTAS PASSAM A SER GE- *      */
        /*"      *      RADAS COM ERRO 1800 'AGUARDANDO PROPOSTAS ASSINADA', E NAO*      */
        /*"      *      MAIS COM ERRO 1810.   PROCURE POR LC0521.                 *      */
        /*"      *                                                                *      */
        /*"      *      LUIZ CARLOS  21/05/2001.                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * 06 - POR SOLICITACAO DO USUARIO, ACABOU COM A EMISSAO AUTOMATI-*      */
        /*"      *      CA. TODAS AS PROPOSTAS SERAO GERADAS COM ERRO 1810 - PRO  *      */
        /*"      *      POSTA SEM ASSINATURA. PROCURE POR LC0426.                 *      */
        /*"      *                                                                *      */
        /*"      *      LUIZ CARLOS  26/04/2001.                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * 05 - PASSOU A GERAR COMO 'REJ - PROPOSTA REJEITADA', AS PROPOS-*      */
        /*"      *      TAS REMOTAS QUE ESTEJAM FORA DA FAIXA DE NUMERACAO DOS    *      */
        /*"      *      PRODUTOS VIDA.                                            *      */
        /*"      *                                                                *      */
        /*"      *      LUIZ CARLOS  24/04/2001.                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * 04 - PASSOU A CALCULAR O DV DA MATRICULA DO VENDEDOR E ATUALI- *      */
        /*"      *      ZAR A TABELA PROPOSTA_FIDELIZ.   PROCURE POR LC1100.      *      */
        /*"      *                                                                *      */
        /*"      *      LUIZ CARLOS  24/11/2000.                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * 03 - PARA AS PROPOSTAS MANUAIS, PENDENTES DE SICOB, PASSA A    *      */
        /*"      *      GERAR A SIT-PROPOSTA COMO 'POB',SO LIBERANDO A MESMA PARA *      */
        /*"      *      EMISSAO QUANDO O RCAP FOR CADASTRADO.                     *      */
        /*"      *                                PROCURE LC1000.                 *      */
        /*"      *                                                                *      */
        /*"      *      LUIZ CARLOS  09/10/2000.                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * 02 - PASSA A GERAR O NUMERO DA PROPOSTA AUTOMATICA NA          *      */
        /*"      *      V0PROPOSTAVA = NULL.                                      *      */
        /*"      *                                PROCURE LC0900.                 *      */
        /*"      *      LUIZ CARLOS  XX/09/2000.                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * 01 - PASSA A GERAR SIT-PROPOSTA DA PROPOSTA-FIDELIZ COM 'PEN', *      */
        /*"      *      AO INVEZ DE 'ANA', CASO A PROPOSTA TENHA ALGUM ERRO.      *      */
        /*"      *                                PROCURE LC0800.                 *      */
        /*"      *      LUIZ CARLOS  28/08/2000.                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * 00 - PASSA A GERAR SIT-PROPOSTA DA PROPOSTA-FIDELIZ COM 'ANA', *      */
        /*"      *      AO INVEZ DE 'REJ', CASO A PROPOSTA TENHA ALGUM ERRO.      *      */
        /*"      *                                PROCURE LC0600.                 *      */
        /*"      *      LUIZ CARLOS  26/06/2000.                                  *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  WS-NRMATRVEN            PIC  9(07) VALUE ZERO.*/
        public IntBasis WS_NRMATRVEN { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
        /*"77  WS-NUM-PROPOSTA-AZUL    PIC S9(13)V  COMP-3  VALUE ZERO.*/
        public DoubleBasis WS_NUM_PROPOSTA_AZUL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"77  COBERP-IMPMORNATU       PIC S9(13)V9(05) COMP-3  VALUE ZERO.*/
        public DoubleBasis COBERP_IMPMORNATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(05)"), 5);
        /*"01  WS-VALOR-IS         PIC S9(13)V9(2) USAGE COMP-3 VALUE ZERO.*/
        public DoubleBasis WS_VALOR_IS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"01  WS-VALOR-IS-CDC     PIC S9(13)V9(2) USAGE COMP-3 VALUE ZERO.*/
        public DoubleBasis WS_VALOR_IS_CDC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"01  WS-DATA-NASCIMENTO      PIC  X(10) VALUE SPACES.*/
        public StringBasis WS_DATA_NASCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"01  WS-DIAS-ANO             PIC S9(06) USAGE COMP.*/
        public IntBasis WS_DIAS_ANO { get; set; } = new IntBasis(new PIC("S9", "6", "S9(06)"));
        /*"01  WS-SQLCODE              PIC ---9.*/
        public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("9", "4", "---9."));
        /*"01  WS-PROPOSTAS-LIDAS      PIC 9(07) VALUE ZEROS.*/
        public IntBasis WS_PROPOSTAS_LIDAS { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
        /*"01  WS-DT-NASCIMENTO-18     PIC X(10) VALUE SPACES.*/
        public StringBasis WS_DT_NASCIMENTO_18 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"01  WS-TAXAVG               PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis WS_TAXAVG { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"01  WS-VALOR-IS-7725    PIC S9(13)V9(2) USAGE COMP-3 VALUE ZERO.*/
        public DoubleBasis WS_VALOR_IS_7725 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"01  WS-DATA-QUITACAO    PIC X(010) VALUE SPACES.*/
        public StringBasis WS_DATA_QUITACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01  WS-VALOR-IS-ALF     PIC X(255).*/
        public StringBasis WS_VALOR_IS_ALF { get; set; } = new StringBasis(new PIC("X", "255", "X(255)."), @"");
        /*"01  FILLER REDEFINES WS-VALOR-IS-ALF.*/
        private _REDEF_VP0601B_FILLER_0 _filler_0 { get; set; }
        public _REDEF_VP0601B_FILLER_0 FILLER_0
        {
            get { _filler_0 = new _REDEF_VP0601B_FILLER_0(); _.Move(WS_VALOR_IS_ALF, _filler_0); VarBasis.RedefinePassValue(WS_VALOR_IS_ALF, _filler_0, WS_VALOR_IS_ALF); _filler_0.ValueChanged += () => { _.Move(_filler_0, WS_VALOR_IS_ALF); }; return _filler_0; }
            set { VarBasis.RedefinePassValue(value, _filler_0, WS_VALOR_IS_ALF); }
        }  //Redefines
        public class _REDEF_VP0601B_FILLER_0 : VarBasis
        {
            /*"    03 WS-VLR-IS-NUM    PIC 9(13)V99.*/
            public DoubleBasis WS_VLR_IS_NUM { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99."), 2);
            /*"    03 WS-FILLER-CHA    PIC X(240).*/
            public StringBasis WS_FILLER_CHA { get; set; } = new StringBasis(new PIC("X", "240", "X(240)."), @"");
            /*"01  WS-JV1-PROGRAMA                    PIC  X(008) VALUE SPACES.*/

            public _REDEF_VP0601B_FILLER_0()
            {
                WS_VLR_IS_NUM.ValueChanged += OnValueChanged;
                WS_FILLER_CHA.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_JV1_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"01    WS-HORAS.*/
        public VP0601B_WS_HORAS WS_HORAS { get; set; } = new VP0601B_WS_HORAS();
        public class VP0601B_WS_HORAS : VarBasis
        {
            /*"  03  WS-HORA-INI               PIC  X(008).*/
            public StringBasis WS_HORA_INI { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-INI-R REDEFINES WS-HORA-INI.*/
            private _REDEF_VP0601B_WS_HORA_INI_R _ws_hora_ini_r { get; set; }
            public _REDEF_VP0601B_WS_HORA_INI_R WS_HORA_INI_R
            {
                get { _ws_hora_ini_r = new _REDEF_VP0601B_WS_HORA_INI_R(); _.Move(WS_HORA_INI, _ws_hora_ini_r); VarBasis.RedefinePassValue(WS_HORA_INI, _ws_hora_ini_r, WS_HORA_INI); _ws_hora_ini_r.ValueChanged += () => { _.Move(_ws_hora_ini_r, WS_HORA_INI); }; return _ws_hora_ini_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_ini_r, WS_HORA_INI); }
            }  //Redefines
            public class _REDEF_VP0601B_WS_HORA_INI_R : VarBasis
            {
                /*"      05  HI                    PIC  9(002).*/
                public IntBasis HI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  MI                    PIC  9(002).*/
                public IntBasis MI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  SI                    PIC  9(002).*/
                public IntBasis SI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  DI                    PIC  9(002).*/
                public IntBasis DI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03  WS-HORA-FIM               PIC  X(008).*/

                public _REDEF_VP0601B_WS_HORA_INI_R()
                {
                    HI.ValueChanged += OnValueChanged;
                    MI.ValueChanged += OnValueChanged;
                    SI.ValueChanged += OnValueChanged;
                    DI.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_HORA_FIM { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-FIM-R REDEFINES WS-HORA-FIM.*/
            private _REDEF_VP0601B_WS_HORA_FIM_R _ws_hora_fim_r { get; set; }
            public _REDEF_VP0601B_WS_HORA_FIM_R WS_HORA_FIM_R
            {
                get { _ws_hora_fim_r = new _REDEF_VP0601B_WS_HORA_FIM_R(); _.Move(WS_HORA_FIM, _ws_hora_fim_r); VarBasis.RedefinePassValue(WS_HORA_FIM, _ws_hora_fim_r, WS_HORA_FIM); _ws_hora_fim_r.ValueChanged += () => { _.Move(_ws_hora_fim_r, WS_HORA_FIM); }; return _ws_hora_fim_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_fim_r, WS_HORA_FIM); }
            }  //Redefines
            public class _REDEF_VP0601B_WS_HORA_FIM_R : VarBasis
            {
                /*"      05  HF                    PIC  9(002).*/
                public IntBasis HF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  MF                    PIC  9(002).*/
                public IntBasis MF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  SF                    PIC  9(002).*/
                public IntBasis SF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  DF                    PIC  9(002).*/
                public IntBasis DF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03  SIT                       PIC S9(013)V99 COMP-3 VALUE +0.*/

                public _REDEF_VP0601B_WS_HORA_FIM_R()
                {
                    HF.ValueChanged += OnValueChanged;
                    MF.ValueChanged += OnValueChanged;
                    SF.ValueChanged += OnValueChanged;
                    DF.ValueChanged += OnValueChanged;
                }

            }
            public DoubleBasis SIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  SFT                       PIC S9(013)V99 COMP-3 VALUE +0.*/
            public DoubleBasis SFT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  SII                       PIC S9(004)    COMP   VALUE +0.*/
            public IntBasis SII { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  STT-DISP                  PIC --.---.---.---.--9,99.*/
            public DoubleBasis STT_DISP { get; set; } = new DoubleBasis(new PIC("9", "14", "--.---.---.---.--9V99."), 2);
            /*"01  TOTAIS-ROT.*/
        }
        public VP0601B_TOTAIS_ROT TOTAIS_ROT { get; set; } = new VP0601B_TOTAIS_ROT();
        public class VP0601B_TOTAIS_ROT : VarBasis
        {
            /*"    03  FILLER  OCCURS 80 TIMES.*/
            public ListBasis<VP0601B_FILLER_1> FILLER_1 { get; set; } = new ListBasis<VP0601B_FILLER_1>(80);
            public class VP0601B_FILLER_1 : VarBasis
            {
                /*"        05  STT                       PIC S9(013)V99 COMP-3.*/
                public DoubleBasis STT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                /*"        05  SQT                       PIC S9(015)    COMP-3.*/
                public IntBasis SQT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
                /*"01  WHOST-IMPMORNATU-MAX        PIC S9(013)V99 COMP-3 VALUE +0.*/
            }
        }
        public DoubleBasis WHOST_IMPMORNATU_MAX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  WHOST-IMPMORNATU                  PIC S9(013)V99 COMP-3.*/
        public DoubleBasis WHOST_IMPMORNATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  WHOST-PREMIO-1                    PIC S9(013)V99 COMP-3.*/
        public DoubleBasis WHOST_PREMIO_1 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  WHOST-PREMIO-2                    PIC S9(013)V99 COMP-3.*/
        public DoubleBasis WHOST_PREMIO_2 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  WHOST-INFO-COMPL                  PIC  X(050).*/
        public StringBasis WHOST_INFO_COMPL { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
        /*"01  WHOST-PROFISSAO                   PIC  X(020).*/
        public StringBasis WHOST_PROFISSAO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"01  WHOST-NRMATRVEN                   PIC  9(015).*/
        public IntBasis WHOST_NRMATRVEN { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
        /*"01  WHOST-PROFISSAO-CONJUGE           PIC  X(020).*/
        public StringBasis WHOST_PROFISSAO_CONJUGE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"01  WHOST-SIT-PROPOSTA                PIC  X(003).*/
        public StringBasis WHOST_SIT_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"01  WS-DTPROXVEN                      PIC  X(010).*/
        public StringBasis WS_DTPROXVEN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WS-NUM-CONTA-DEBITO.*/
        public VP0601B_WS_NUM_CONTA_DEBITO WS_NUM_CONTA_DEBITO { get; set; } = new VP0601B_WS_NUM_CONTA_DEBITO();
        public class VP0601B_WS_NUM_CONTA_DEBITO : VarBasis
        {
            /*"    03 WS-NUMCTADEB                   PIC 9(09) VALUE ZEROS.*/
            public IntBasis WS_NUMCTADEB { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"    03 WS-DIGCTADEB                   PIC 9(01) VALUE ZEROS.*/
            public IntBasis WS_DIGCTADEB { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
            /*"01  WS-NUM-CONTA-DEBITO2              PIC 9(10) VALUE ZEROS.*/
        }
        public IntBasis WS_NUM_CONTA_DEBITO2 { get; set; } = new IntBasis(new PIC("9", "10", "9(10)"));
        /*"01  WHOST-SIT-ENVIO                   PIC  X(001).*/
        public StringBasis WHOST_SIT_ENVIO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  WHOST-SIT-REGISTRO                PIC  X(001).*/
        public StringBasis WHOST_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  WHOST-OPCAOPAG                    PIC  X(001).*/
        public StringBasis WHOST_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  WHOST-FONTE                       PIC S9(004)      COMP.*/
        public IntBasis WHOST_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-PROPAUTOM                   PIC S9(004)      COMP.*/
        public IntBasis WHOST_PROPAUTOM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-DTPROXVEN                   PIC  X(010).*/
        public StringBasis WHOST_DTPROXVEN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WHOST-DATA-NASCIMENTO-7708        PIC  X(010).*/
        public StringBasis WHOST_DATA_NASCIMENTO_7708 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WHOST-DATA-NASCIMENTO-2           PIC  X(010).*/
        public StringBasis WHOST_DATA_NASCIMENTO_2 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WHOST-PRODUTO-SIVPF               PIC S9(004)      COMP.*/
        public IntBasis WHOST_PRODUTO_SIVPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  PROPVA-NRCERTIF                   PIC S9(15) COMP-3.*/
        public IntBasis PROPVA_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  WS-IMP-SEGUR               PIC S9(13)V99 COMP-3 VALUE +0.*/
        public DoubleBasis WS_IMP_SEGUR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  WS-COUNT                   PIC S9(009) COMP    VALUE +0.*/
        public IntBasis WS_COUNT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  WS-CADASTRO-IS-SUPERIOR    PIC S9(004) COMP    VALUE +0.*/
        public IntBasis WS_CADASTRO_IS_SUPERIOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-NUM-CONTR                    PIC S9(004)      COMP.*/
        public IntBasis VIND_NUM_CONTR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-COD-CORRESP                  PIC S9(004)      COMP.*/
        public IntBasis VIND_COD_CORRESP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-NUM-PRAZO                    PIC S9(004)      COMP.*/
        public IntBasis VIND_NUM_PRAZO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-COD-OPER-CRED                PIC S9(004)      COMP.*/
        public IntBasis VIND_COD_OPER_CRED { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-DTFATUR                      PIC S9(004)      COMP.*/
        public IntBasis VIND_DTFATUR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-AGECTADEB                    PIC S9(004)      COMP.*/
        public IntBasis VIND_AGECTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-OPRCTADEB                    PIC S9(004)      COMP.*/
        public IntBasis VIND_OPRCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-NUMCTADEB                    PIC S9(004)      COMP.*/
        public IntBasis VIND_NUMCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-DIGCTADEB                    PIC S9(004)      COMP.*/
        public IntBasis VIND_DIGCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-CARTAO                       PIC S9(004)      COMP.*/
        public IntBasis VIND_CARTAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-IMPSEGAUXF                   PIC S9(004) VALUE +0 COMP.*/
        public IntBasis VIND_IMPSEGAUXF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-VLCUSTAUXF                   PIC S9(004) VALUE +0 COMP.*/
        public IntBasis VIND_VLCUSTAUXF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-PRMDIT                       PIC S9(004) VALUE +0 COMP.*/
        public IntBasis VIND_PRMDIT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-QTDIT                        PIC S9(004) VALUE +0 COMP.*/
        public IntBasis VIND_QTDIT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-DATA-EXPEDICAO               PIC S9(004) VALUE +0 COMP.*/
        public IntBasis VIND_DATA_EXPEDICAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-DATA-NASCIMENTO              PIC S9(004) VALUE +0 COMP.*/
        public IntBasis VIND_DATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-CGC-CONVENENTE               PIC S9(004)      COMP.*/
        public IntBasis VIND_CGC_CONVENENTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-NOME-CONJUGE                 PIC S9(004)      COMP.*/
        public IntBasis VIND_NOME_CONJUGE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-RENDA-FIXA-IND               PIC S9(004)      COMP.*/
        public IntBasis VIND_RENDA_FIXA_IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-RENDA-FIXA-FAM               PIC S9(004)      COMP.*/
        public IntBasis VIND_RENDA_FIXA_FAM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-DATA-NASC-CONJUGE            PIC S9(004)      COMP.*/
        public IntBasis VIND_DATA_NASC_CONJUGE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-PROFISSAO-CONJUGE            PIC S9(004)      COMP.*/
        public IntBasis VIND_PROFISSAO_CONJUGE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-UF-EXPEDIDORA                PIC S9(004)      COMP.*/
        public IntBasis VIND_UF_EXPEDIDORA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-NOME-RAZAO        PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_NOME_RAZAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-TIPO-PESSOA       PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_TIPO_PESSOA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-IDE-SEXO          PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_IDE_SEXO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-EST-CIVIL         PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_EST_CIVIL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-OCORR-END         PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_OCORR_END { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-ENDERECO          PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-BAIRRO            PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_BAIRRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-CIDADE            PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_CIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-SIGLA-UF          PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_SIGLA_UF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-CEP               PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_CEP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DDD               PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_DDD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-TELEFONE          PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_TELEFONE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-FAX               PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_FAX { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-CGCCPF            PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DTNASC            PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_DTNASC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-CODUSU            PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_CODUSU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-OCORR-END-I      PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis WHOST_OCORR_END_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-OCORR-END-F      PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis WHOST_OCORR_END_F { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WTEM-GECLIMOV                    PIC  X(001)  VALUE  SPACES.*/
        public StringBasis WTEM_GECLIMOV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01  WEXISTE-PRPVA                    PIC  X(003)  VALUE  'NAO'.*/
        public StringBasis WEXISTE_PRPVA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
        /*"01  WEXISTE-COMISSAO                 PIC  X(003)  VALUE  'NAO'.*/
        public StringBasis WEXISTE_COMISSAO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
        /*"01  WHOST-IDADE                      PIC S9(004)          COMP.*/
        public IntBasis WHOST_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-IDADE-2                    PIC S9(004)          COMP.*/
        public IntBasis WHOST_IDADE_2 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  PRVG-CODPRODU                    PIC S9(004)          COMP.*/
        public IntBasis PRVG_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  PRVG-CODPRODU                    PIC S9(004)          COMP.*/
        public IntBasis PRVG_CODPRODU_0 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  PRVG-PERIPGTO                    PIC S9(004)          COMP.*/
        public IntBasis PRVG_PERIPGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  ESTIP-COD-CCT                    PIC S9(015)        COMP-3.*/
        public IntBasis ESTIP_COD_CCT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01  ESTIP-NOME                       PIC  X(040).*/
        public StringBasis ESTIP_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"01  WHOST-DDD                        PIC S9(004)          COMP.*/
        public IntBasis WHOST_DDD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-DDD-RESIDENCIAL            PIC S9(004)          COMP.*/
        public IntBasis WHOST_DDD_RESIDENCIAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-DDD-COMERCIAL              PIC S9(004)          COMP.*/
        public IntBasis WHOST_DDD_COMERCIAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-DDD-CELULAR                PIC S9(004)          COMP.*/
        public IntBasis WHOST_DDD_CELULAR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-DDD-FAX                    PIC S9(004)          COMP.*/
        public IntBasis WHOST_DDD_FAX { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-EMAIL                      PIC  X(040).*/
        public StringBasis WHOST_EMAIL { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"01  WHOST-FONE                       PIC S9(009)          COMP.*/
        public IntBasis WHOST_FONE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  WHOST-FONE-RESIDENCIAL           PIC S9(009)          COMP.*/
        public IntBasis WHOST_FONE_RESIDENCIAL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  WHOST-FONE-COMERCIAL             PIC S9(009)          COMP.*/
        public IntBasis WHOST_FONE_COMERCIAL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  WHOST-FONE-CELULAR               PIC S9(009)          COMP.*/
        public IntBasis WHOST_FONE_CELULAR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  WHOST-FONE-FAX                   PIC S9(009)          COMP.*/
        public IntBasis WHOST_FONE_FAX { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  WHOST-FAX                        PIC S9(009)          COMP.*/
        public IntBasis WHOST_FAX { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  WHOST-TELEX                      PIC S9(009)          COMP.*/
        public IntBasis WHOST_TELEX { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  VGPLAR-NUM-RAMO                  PIC S9(04)    COMP.*/
        public IntBasis VGPLAR_NUM_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VGPLAR-NUM-COBERTURA             PIC S9(04)    COMP.*/
        public IntBasis VGPLAR_NUM_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VGPLAR-QTD-COBERTURA             PIC S9(04)    COMP.*/
        public IntBasis VGPLAR_QTD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VGPLAR-IMPSEGURADA               PIC S9(13)V99 COMP-3.*/
        public DoubleBasis VGPLAR_IMPSEGURADA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  VGPLAR-CUSTO                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis VGPLAR_CUSTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  VGPLAR-PREMIO                    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis VGPLAR_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  VGPLAR-TAXA                      PIC S9(03)V9999 COMP-3.*/
        public DoubleBasis VGPLAR_TAXA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9999"), 4);
        /*"01  VGPLAA-NUM-ACESSORIO             PIC S9(04)    COMP.*/
        public IntBasis VGPLAA_NUM_ACESSORIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VGPLAA-QTD-COBERTURA             PIC S9(04)    COMP.*/
        public IntBasis VGPLAA_QTD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VGPLAA-IMPSEGURADA               PIC S9(13)V99 COMP-3.*/
        public DoubleBasis VGPLAA_IMPSEGURADA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  VGPLAA-CUSTO                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis VGPLAA_CUSTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  VGPLAA-PREMIO                    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis VGPLAA_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  VGPLAA-TAXA                      PIC S9(03)V9999 COMP-3.*/
        public DoubleBasis VGPLAA_TAXA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9999"), 4);
        /*"01  LPARM01                     PIC  9(007).*/
        public IntBasis LPARM01 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
        /*"01  LPARM01-R                   REDEFINES   LPARM01.*/
        private _REDEF_VP0601B_LPARM01_R _lparm01_r { get; set; }
        public _REDEF_VP0601B_LPARM01_R LPARM01_R
        {
            get { _lparm01_r = new _REDEF_VP0601B_LPARM01_R(); _.Move(LPARM01, _lparm01_r); VarBasis.RedefinePassValue(LPARM01, _lparm01_r, LPARM01); _lparm01_r.ValueChanged += () => { _.Move(_lparm01_r, LPARM01); }; return _lparm01_r; }
            set { VarBasis.RedefinePassValue(value, _lparm01_r, LPARM01); }
        }  //Redefines
        public class _REDEF_VP0601B_LPARM01_R : VarBasis
        {
            /*"    05          LPARM01-1       PIC  9(001).*/
            public IntBasis LPARM01_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05          LPARM01-2       PIC  9(001).*/
            public IntBasis LPARM01_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05          LPARM01-3       PIC  9(001).*/
            public IntBasis LPARM01_3 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05          LPARM01-4       PIC  9(001).*/
            public IntBasis LPARM01_4 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05          LPARM01-5       PIC  9(001).*/
            public IntBasis LPARM01_5 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05          LPARM01-6       PIC  9(001).*/
            public IntBasis LPARM01_6 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"01              LPARM03         PIC  9(001).*/

            public _REDEF_VP0601B_LPARM01_R()
            {
                LPARM01_1.ValueChanged += OnValueChanged;
                LPARM01_2.ValueChanged += OnValueChanged;
                LPARM01_3.ValueChanged += OnValueChanged;
                LPARM01_4.ValueChanged += OnValueChanged;
                LPARM01_5.ValueChanged += OnValueChanged;
                LPARM01_6.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis LPARM03 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
        /*"01              LPARM03-R       REDEFINES   LPARM03                                PIC  X(001).*/
        private _REDEF_StringBasis _lparm03_r { get; set; }
        public _REDEF_StringBasis LPARM03_R
        {
            get { _lparm03_r = new _REDEF_StringBasis(new PIC("X", "001", "X(001).")); ; _.Move(LPARM03, _lparm03_r); VarBasis.RedefinePassValue(LPARM03, _lparm03_r, LPARM03); _lparm03_r.ValueChanged += () => { _.Move(_lparm03_r, LPARM03); }; return _lparm03_r; }
            set { VarBasis.RedefinePassValue(value, _lparm03_r, LPARM03); }
        }  //Redefines
        /*"01  W-NUM-CARTAO-CREDITO        PIC  9(016)  VALUE ZEROS.*/
        public IntBasis W_NUM_CARTAO_CREDITO { get; set; } = new IntBasis(new PIC("9", "16", "9(016)"));
        /*"01  W-NRMATRICULA               PIC  9(007)  VALUE ZEROS.*/
        public IntBasis W_NRMATRICULA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"01  FILLER                      REDEFINES   W-NRMATRICULA.*/
        private _REDEF_VP0601B_FILLER_2 _filler_2 { get; set; }
        public _REDEF_VP0601B_FILLER_2 FILLER_2
        {
            get { _filler_2 = new _REDEF_VP0601B_FILLER_2(); _.Move(W_NRMATRICULA, _filler_2); VarBasis.RedefinePassValue(W_NRMATRICULA, _filler_2, W_NRMATRICULA); _filler_2.ValueChanged += () => { _.Move(_filler_2, W_NRMATRICULA); }; return _filler_2; }
            set { VarBasis.RedefinePassValue(value, _filler_2, W_NRMATRICULA); }
        }  //Redefines
        public class _REDEF_VP0601B_FILLER_2 : VarBasis
        {
            /*"    05          W-NRMATRICULA1  PIC  9(006).*/
            public IntBasis W_NRMATRICULA1 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05          W-DV-MATRICULA  PIC  9(001).*/
            public IntBasis W_DV_MATRICULA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"01  WORK-AREA.*/

            public _REDEF_VP0601B_FILLER_2()
            {
                W_NRMATRICULA1.ValueChanged += OnValueChanged;
                W_DV_MATRICULA.ValueChanged += OnValueChanged;
            }

        }
        public VP0601B_WORK_AREA WORK_AREA { get; set; } = new VP0601B_WORK_AREA();
        public class VP0601B_WORK_AREA : VarBasis
        {
            /*"    05  W-NUM-PROPOSTA                PIC 9(014).*/
            public IntBasis W_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    05  FAIXAS  REDEFINES W-NUM-PROPOSTA.*/
            private _REDEF_VP0601B_FAIXAS _faixas { get; set; }
            public _REDEF_VP0601B_FAIXAS FAIXAS
            {
                get { _faixas = new _REDEF_VP0601B_FAIXAS(); _.Move(W_NUM_PROPOSTA, _faixas); VarBasis.RedefinePassValue(W_NUM_PROPOSTA, _faixas, W_NUM_PROPOSTA); _faixas.ValueChanged += () => { _.Move(_faixas, W_NUM_PROPOSTA); }; return _faixas; }
                set { VarBasis.RedefinePassValue(value, _faixas, W_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_VP0601B_FAIXAS : VarBasis
            {
                /*"        07  FILLER                    PIC 9(003).*/
                public IntBasis FILLER_3 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"        07  FAIXA-NUMERACAO           PIC 9(003).*/

                public SelectorBasis FAIXA_NUMERACAO { get; set; } = new SelectorBasis("003")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88 FAIXA-NUMERACAO-MULT       VALUE               848, 850, 845, 846. */
							new SelectorItemBasis("FAIXA_NUMERACAO_MULT", "848,850,845,846"),
							/*" 88 FAIXA-NUMERACAO-BILHETE    VALUE               823, 824, 826, 827, 829, 837, 850, 845, 846. */
							new SelectorItemBasis("FAIXA_NUMERACAO_BILHETE", "823,824,826,827,829,837,850,845,846"),
							/*" 88 FAIXA-NUMERACAO-SENIOR     VALUE               821, 850, 845, 846. */
							new SelectorItemBasis("FAIXA_NUMERACAO_SENIOR", "821,850,845,846"),
							/*" 88 FAIXA-NUMERACAO-EXECUTIVO  VALUE               821, 850, 845, 846. */
							new SelectorItemBasis("FAIXA_NUMERACAO_EXECUTIVO", "821,850,845,846"),
							/*" 88 FAIXA-NUMERACAO-AUTO       VALUE               828, 837, 847, 845, 846. */
							new SelectorItemBasis("FAIXA_NUMERACAO_AUTO", "828,837,847,845,846")
                }
                };

                /*"        07  W-FILLER                  PIC 9(008).*/
                public IntBasis W_FILLER { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    05  CANAL  REDEFINES W-NUM-PROPOSTA.*/

                public _REDEF_VP0601B_FAIXAS()
                {
                    FILLER_3.ValueChanged += OnValueChanged;
                    FAIXA_NUMERACAO.ValueChanged += OnValueChanged;
                    W_FILLER.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_VP0601B_CANAL _canal { get; set; }
            public _REDEF_VP0601B_CANAL CANAL
            {
                get { _canal = new _REDEF_VP0601B_CANAL(); _.Move(W_NUM_PROPOSTA, _canal); VarBasis.RedefinePassValue(W_NUM_PROPOSTA, _canal, W_NUM_PROPOSTA); _canal.ValueChanged += () => { _.Move(_canal, W_NUM_PROPOSTA); }; return _canal; }
                set { VarBasis.RedefinePassValue(value, _canal, W_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_VP0601B_CANAL : VarBasis
            {
                /*"        07  W-CANAL-PROPOSTA          PIC 9(001).*/

                public SelectorBasis W_CANAL_PROPOSTA { get; set; } = new SelectorBasis("001")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88 CANAL-VENDA-PAPEL                    VALUE 0. */
							new SelectorItemBasis("CANAL_VENDA_PAPEL", "0"),
							/*" 88 CANAL-VENDA-CEF                      VALUE 1. */
							new SelectorItemBasis("CANAL_VENDA_CEF", "1"),
							/*" 88 CANAL-SASSE-FILIAL                   VALUE 2. */
							new SelectorItemBasis("CANAL_SASSE_FILIAL", "2"),
							/*" 88 CANAL-CORRETOR                       VALUE 3. */
							new SelectorItemBasis("CANAL_CORRETOR", "3"),
							/*" 88 CANAL-CORREIO                        VALUE 4. */
							new SelectorItemBasis("CANAL_CORREIO", "4"),
							/*" 88 CANAL-GITEL                          VALUE 5. */
							new SelectorItemBasis("CANAL_GITEL", "5"),
							/*" 88 CANAL-INTERNET                       VALUE 7. */
							new SelectorItemBasis("CANAL_INTERNET", "7"),
							/*" 88 CANAL-VENDA-AIC                      VALUE 8. */
							new SelectorItemBasis("CANAL_VENDA_AIC", "8")
                }
                };

                /*"        07  FILLER                    PIC 9(013).*/
                public IntBasis FILLER_4 { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    05  W-ENDERECO                    PIC 9(001).*/

                public _REDEF_VP0601B_CANAL()
                {
                    W_CANAL_PROPOSTA.ValueChanged += OnValueChanged;
                    FILLER_4.ValueChanged += OnValueChanged;
                }

            }

            public SelectorBasis W_ENDERECO { get; set; } = new SelectorBasis("001")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 END-CORRES-CADASTRADO          VALUE 01. */
							new SelectorItemBasis("END_CORRES_CADASTRADO", "01"),
							/*" 88 END-CORRES-N-CADASTRADO        VALUE 02. */
							new SelectorItemBasis("END_CORRES_N_CADASTRADO", "02"),
							/*" 88 DEMAIS-END-CADASTRADO          VALUE 03. */
							new SelectorItemBasis("DEMAIS_END_CADASTRADO", "03"),
							/*" 88 DEMAIS-END-N-CADASTRADO        VALUE 04. */
							new SelectorItemBasis("DEMAIS_END_N_CADASTRADO", "04")
                }
            };

            /*"    05  W-RCAPS                       PIC 9(002).*/

            public SelectorBasis W_RCAPS { get; set; } = new SelectorBasis("002")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 RCAP-CADASTRADO                          VALUE 01. */
							new SelectorItemBasis("RCAP_CADASTRADO", "01")
                }
            };

            /*"    05  W-PLANO                       PIC 9(002).*/

            public SelectorBasis W_PLANO { get; set; } = new SelectorBasis("002")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 EXISTE-PLANO                             VALUE 01. */
							new SelectorItemBasis("EXISTE_PLANO", "01")
                }
            };

            /*"    05  W-NOVO-CALCULO                PIC 9(002).*/

            public SelectorBasis W_NOVO_CALCULO { get; set; } = new SelectorBasis("002")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 NOVO-CALCULO-PREMIO                      VALUE 01. */
							new SelectorItemBasis("NOVO_CALCULO_PREMIO", "01")
                }
            };

            /*"    05  W-COBRANCA                    PIC 9(002).*/

            public SelectorBasis W_COBRANCA { get; set; } = new SelectorBasis("002")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 COBRANCA-EMITIDA                         VALUE 01. */
							new SelectorItemBasis("COBRANCA_EMITIDA", "01")
                }
            };

            /*"    05  W-TP-PRESTAMISTA              PIC 9(002).*/

            public SelectorBasis W_TP_PRESTAMISTA { get; set; } = new SelectorBasis("002")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 PROD-CROTINHO                            VALUE 01. */
							new SelectorItemBasis("PROD_CROTINHO", "01")
                }
            };

            /*"    05  W-ORIGEM-PROPOSTA             PIC 9(002).*/

            public SelectorBasis W_ORIGEM_PROPOSTA { get; set; } = new SelectorBasis("002")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 ORIGEM-SIGPF                             VALUE 01. */
							new SelectorItemBasis("ORIGEM_SIGPF", "01"),
							/*" 88 ORIGEM-CAIXA-PREV                        VALUE 02. */
							new SelectorItemBasis("ORIGEM_CAIXA_PREV", "02"),
							/*" 88 ORIGEM-SIGAT                             VALUE 03. */
							new SelectorItemBasis("ORIGEM_SIGAT", "03"),
							/*" 88 ORIGEM-SASSE                             VALUE 04. */
							new SelectorItemBasis("ORIGEM_SASSE", "04"),
							/*" 88 ORIGEM-CAIXA-CAP                         VALUE 05. */
							new SelectorItemBasis("ORIGEM_CAIXA_CAP", "05"),
							/*" 88 ORIGEM-SIFEC                             VALUE 06. */
							new SelectorItemBasis("ORIGEM_SIFEC", "06"),
							/*" 88 ORIGEM-REMOTA                            VALUE 07. */
							new SelectorItemBasis("ORIGEM_REMOTA", "07"),
							/*" 88 ORIGEM-REMOTA-FILIAL                     VALUE 08. */
							new SelectorItemBasis("ORIGEM_REMOTA_FILIAL", "08"),
							/*" 88 ORIGEM-MANUAL                            VALUE 09. */
							new SelectorItemBasis("ORIGEM_MANUAL", "09")
                }
            };

            /*"    05  W-TRATA-CLIENTE               PIC 9(002).*/

            public SelectorBasis W_TRATA_CLIENTE { get; set; } = new SelectorBasis("002")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 CLIENTE-INSERIDO                         VALUE 01. */
							new SelectorItemBasis("CLIENTE_INSERIDO", "01"),
							/*" 88 CLIENTE-ERRO                             VALUE 02. */
							new SelectorItemBasis("CLIENTE_ERRO", "02")
                }
            };

            /*"    05 WS-CHAVE-ATU VALUE ZEROS.*/
            public VP0601B_WS_CHAVE_ATU WS_CHAVE_ATU { get; set; } = new VP0601B_WS_CHAVE_ATU();
            public class VP0601B_WS_CHAVE_ATU : VarBasis
            {
                /*"       10 WS-ATU-APOLICE             PIC  9(013).*/
                public IntBasis WS_ATU_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"       10 WS-ATU-SUBGRUPO            PIC  9(005).*/
                public IntBasis WS_ATU_SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"    05 WS-CHAVE-ANT VALUE ZEROS.*/
            }
            public VP0601B_WS_CHAVE_ANT WS_CHAVE_ANT { get; set; } = new VP0601B_WS_CHAVE_ANT();
            public class VP0601B_WS_CHAVE_ANT : VarBasis
            {
                /*"       10 WS-ANT-APOLICE             PIC  9(013).*/
                public IntBasis WS_ANT_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"       10 WS-ANT-SUBGRUPO            PIC  9(005).*/
                public IntBasis WS_ANT_SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"    05 WS-LIM-CALCULADO              PIC S9(013)V99 COMP-3.*/
            }
            public DoubleBasis WS_LIM_CALCULADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 WS-VLPREMIOTOT-CCT            PIC S9(013)V99 COMP-3.*/
            public DoubleBasis WS_VLPREMIOTOT_CCT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 WS-JA-E-CLIENTE               PIC  9(001) VALUE 0.*/
            public IntBasis WS_JA_E_CLIENTE { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05 WS-EOR                        PIC  9(001) VALUE 0.*/
            public IntBasis WS_EOR { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05 WS-TEM-ERRO-ASS               PIC  9(001) VALUE 0.*/
            public IntBasis WS_TEM_ERRO_ASS { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05 WS-TEM-ERRO                   PIC  9(001) VALUE 0.*/
            public IntBasis WS_TEM_ERRO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05 WS-TEM-ERRO-1855              PIC  X(003) VALUE 'NAO'.*/
            public StringBasis WS_TEM_ERRO_1855 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05 WS-TEM-ERRO-1807              PIC  X(003) VALUE 'NAO'.*/
            public StringBasis WS_TEM_ERRO_1807 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05 WS-TEM-ERRO-1852              PIC  X(003) VALUE 'NAO'.*/
            public StringBasis WS_TEM_ERRO_1852 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05 WS-FONTE                      PIC  9(005) VALUE 0.*/
            public IntBasis WS_FONTE { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    05 WFIM-AGENCEF                  PIC  X(001) VALUE ' '.*/
            public StringBasis WFIM_AGENCEF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"    05 WFIM-CBO                      PIC  X(001) VALUE ' '.*/
            public StringBasis WFIM_CBO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"    05 WFIM-FONTES                   PIC  X(001) VALUE ' '.*/
            public StringBasis WFIM_FONTES { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"    05 WFIM-VGPLARAMC                PIC  X(001) VALUE ' '.*/
            public StringBasis WFIM_VGPLARAMC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"    05 WFIM-VGPLAACES                PIC  X(001) VALUE ' '.*/
            public StringBasis WFIM_VGPLAACES { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"    05 WS-LIM-PRAZO                  PIC S9(004) COMP.*/
            public IntBasis WS_LIM_PRAZO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05 IND                           PIC  9(005) VALUE 0.*/
            public IntBasis IND { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    05 INDR                          PIC  9      VALUE 0.*/
            public IntBasis INDR { get; set; } = new IntBasis(new PIC("9", "1", "9"));
            /*"    05 WS-IDADE-INICIAL              PIC  9(004) VALUE 0.*/
            public IntBasis WS_IDADE_INICIAL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05 AC-CONTROLE                   PIC  9(006) VALUE 0.*/
            public IntBasis AC_CONTROLE { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05 AC-L-MOVIMENTO                PIC  9(006) VALUE 0.*/
            public IntBasis AC_L_MOVIMENTO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05 AC-I-PROPOSTAVA               PIC  9(006) VALUE 0.*/
            public IntBasis AC_I_PROPOSTAVA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05 AC-I-HISTRAMOCOB              PIC  9(006) VALUE 0.*/
            public IntBasis AC_I_HISTRAMOCOB { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05 AC-I-HISTACESCOB              PIC  9(006) VALUE 0.*/
            public IntBasis AC_I_HISTACESCOB { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05 AC-TOT-RISCO                  PIC  9(013)V99 VALUE 0.*/
            public DoubleBasis AC_TOT_RISCO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05 DATA-SQL1                     PIC  X(010).*/
            public StringBasis DATA_SQL1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05 DATA-SQL  REDEFINES DATA-SQL1.*/
            private _REDEF_VP0601B_DATA_SQL _data_sql { get; set; }
            public _REDEF_VP0601B_DATA_SQL DATA_SQL
            {
                get { _data_sql = new _REDEF_VP0601B_DATA_SQL(); _.Move(DATA_SQL1, _data_sql); VarBasis.RedefinePassValue(DATA_SQL1, _data_sql, DATA_SQL1); _data_sql.ValueChanged += () => { _.Move(_data_sql, DATA_SQL1); }; return _data_sql; }
                set { VarBasis.RedefinePassValue(value, _data_sql, DATA_SQL1); }
            }  //Redefines
            public class _REDEF_VP0601B_DATA_SQL : VarBasis
            {
                /*"       10 ANO-SQL                    PIC  9(004).*/
                public IntBasis ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10 FILLER                     PIC  X(001).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 MES-SQL                    PIC  9(002).*/
                public IntBasis MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 FILLER                     PIC  X(001).*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 DIA-SQL                    PIC  9(002).*/
                public IntBasis DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05 WS-DTNASC.*/

                public _REDEF_VP0601B_DATA_SQL()
                {
                    ANO_SQL.ValueChanged += OnValueChanged;
                    FILLER_5.ValueChanged += OnValueChanged;
                    MES_SQL.ValueChanged += OnValueChanged;
                    FILLER_6.ValueChanged += OnValueChanged;
                    DIA_SQL.ValueChanged += OnValueChanged;
                }

            }
            public VP0601B_WS_DTNASC WS_DTNASC { get; set; } = new VP0601B_WS_DTNASC();
            public class VP0601B_WS_DTNASC : VarBasis
            {
                /*"       10 WS-AA-DTNASC               PIC  9(004).*/
                public IntBasis WS_AA_DTNASC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10 FILLER                     PIC  X(001).*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-MM-DTNASC               PIC  9(002).*/
                public IntBasis WS_MM_DTNASC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 FILLER                     PIC  X(001).*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-DD-DTNASC               PIC  9(002).*/
                public IntBasis WS_DD_DTNASC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05 WS-DTNASC-2.*/
            }
            public VP0601B_WS_DTNASC_2 WS_DTNASC_2 { get; set; } = new VP0601B_WS_DTNASC_2();
            public class VP0601B_WS_DTNASC_2 : VarBasis
            {
                /*"       10 WS-AA-DTNASC-2             PIC  9(004).*/
                public IntBasis WS_AA_DTNASC_2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10 FILLER                     PIC  X(001).*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-MM-DTNASC-2             PIC  9(002).*/
                public IntBasis WS_MM_DTNASC_2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 FILLER                     PIC  X(001).*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-DD-DTNASC-2             PIC  9(002).*/
                public IntBasis WS_DD_DTNASC_2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05 WS-DTPROP.*/
            }
            public VP0601B_WS_DTPROP WS_DTPROP { get; set; } = new VP0601B_WS_DTPROP();
            public class VP0601B_WS_DTPROP : VarBasis
            {
                /*"       10 WS-AA-DTPROP               PIC  9(004).*/
                public IntBasis WS_AA_DTPROP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10 FILLER                     PIC  X(001).*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-MM-DTPROP               PIC  9(002).*/
                public IntBasis WS_MM_DTPROP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 FILLER                     PIC  X(001).*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       10 WS-DD-DTPROP               PIC  9(002).*/
                public IntBasis WS_DD_DTPROP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05 WS-DTINIVIG                   PIC  9(008).*/
            }
            public IntBasis WS_DTINIVIG { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05 WS-DTTERVIG                   PIC  9(008).*/
            public IntBasis WS_DTTERVIG { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05  W-NOM-ORGAO-EXP               PIC X(030).*/
            public StringBasis W_NOM_ORGAO_EXP { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
            /*"    05  FILLER REDEFINES W-NOM-ORGAO-EXP.*/
            private _REDEF_VP0601B_FILLER_13 _filler_13 { get; set; }
            public _REDEF_VP0601B_FILLER_13 FILLER_13
            {
                get { _filler_13 = new _REDEF_VP0601B_FILLER_13(); _.Move(W_NOM_ORGAO_EXP, _filler_13); VarBasis.RedefinePassValue(W_NOM_ORGAO_EXP, _filler_13, W_NOM_ORGAO_EXP); _filler_13.ValueChanged += () => { _.Move(_filler_13, W_NOM_ORGAO_EXP); }; return _filler_13; }
                set { VarBasis.RedefinePassValue(value, _filler_13, W_NOM_ORGAO_EXP); }
            }  //Redefines
            public class _REDEF_VP0601B_FILLER_13 : VarBasis
            {
                /*"        07  W-ORGAO-EXPEDIDOR         PIC X(005).*/
                public StringBasis W_ORGAO_EXPEDIDOR { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                /*"        07  FILLER                    PIC X(025).*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
                /*"    05 DATA-DDMMAA                   PIC  9(008).*/

                public _REDEF_VP0601B_FILLER_13()
                {
                    W_ORGAO_EXPEDIDOR.ValueChanged += OnValueChanged;
                    FILLER_14.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis DATA_DDMMAA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05 DATA-DDMMAA-R REDEFINES DATA-DDMMAA.*/
            private _REDEF_VP0601B_DATA_DDMMAA_R _data_ddmmaa_r { get; set; }
            public _REDEF_VP0601B_DATA_DDMMAA_R DATA_DDMMAA_R
            {
                get { _data_ddmmaa_r = new _REDEF_VP0601B_DATA_DDMMAA_R(); _.Move(DATA_DDMMAA, _data_ddmmaa_r); VarBasis.RedefinePassValue(DATA_DDMMAA, _data_ddmmaa_r, DATA_DDMMAA); _data_ddmmaa_r.ValueChanged += () => { _.Move(_data_ddmmaa_r, DATA_DDMMAA); }; return _data_ddmmaa_r; }
                set { VarBasis.RedefinePassValue(value, _data_ddmmaa_r, DATA_DDMMAA); }
            }  //Redefines
            public class _REDEF_VP0601B_DATA_DDMMAA_R : VarBasis
            {
                /*"       10 DIA-DDMMAA                 PIC  9(002).*/
                public IntBasis DIA_DDMMAA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 MES-DDMMAA                 PIC  9(002).*/
                public IntBasis MES_DDMMAA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 ANO-DDMMAA                 PIC  9(004).*/
                public IntBasis ANO_DDMMAA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05 WS-VLCONJUGE                  PIC  9(013)V99.*/

                public _REDEF_VP0601B_DATA_DDMMAA_R()
                {
                    DIA_DDMMAA.ValueChanged += OnValueChanged;
                    MES_DDMMAA.ValueChanged += OnValueChanged;
                    ANO_DDMMAA.ValueChanged += OnValueChanged;
                }

            }
            public DoubleBasis WS_VLCONJUGE { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"01  WS-TIME.*/
        }
        public VP0601B_WS_TIME WS_TIME { get; set; } = new VP0601B_WS_TIME();
        public class VP0601B_WS_TIME : VarBasis
        {
            /*"    05 WS-TIME-N                     PIC 9(06).*/
            public IntBasis WS_TIME_N { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
            /*"    05 FILLER                        PIC X(02).*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
            /*"01  WS-TIME-EDIT                     PIC 99.99.99.*/
        }
        public IntBasis WS_TIME_EDIT { get; set; } = new IntBasis(new PIC("9", "6", "99.99.99."));
        /*"01         W-GECLIMOV.*/
        public VP0601B_W_GECLIMOV W_GECLIMOV { get; set; } = new VP0601B_W_GECLIMOV();
        public class VP0601B_W_GECLIMOV : VarBasis
        {
            /*"  05       WWORK-COD-CLIENTE      PIC S9(009)    VALUE +0 COMP-4*/
            public IntBasis WWORK_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05       WWORK-TIPO-MOVIMENTO   PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WWORK_TIPO_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05       WWORK-DATA-ULT-MANUTEN PIC  X(010)    VALUE  SPACES.*/
            public StringBasis WWORK_DATA_ULT_MANUTEN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05       WWORK-NOME-RAZAO       PIC  X(040)    VALUE  SPACES.*/
            public StringBasis WWORK_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"  05       WWORK-TIPO-PESSOA      PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WWORK_TIPO_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05       WWORK-IDE-SEXO         PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WWORK_IDE_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05       WWORK-ESTADO-CIVIL     PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WWORK_ESTADO_CIVIL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05       WWORK-OCORR-ENDERECO   PIC S9(004)    VALUE +0 COMP-4*/
            public IntBasis WWORK_OCORR_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05       WWORK-ENDERECO         PIC  X(040)    VALUE  SPACES.*/
            public StringBasis WWORK_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"  05       WWORK-BAIRRO           PIC  X(020)    VALUE  SPACES.*/
            public StringBasis WWORK_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
            /*"  05       WWORK-CIDADE           PIC  X(020)    VALUE  SPACES.*/
            public StringBasis WWORK_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
            /*"  05       WWORK-SIGLA-UF         PIC  X(002)    VALUE  SPACES.*/
            public StringBasis WWORK_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"  05       WWORK-CEP              PIC S9(009)    VALUE +0 COMP-4*/
            public IntBasis WWORK_CEP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05       WWORK-DDD              PIC S9(004)    VALUE +0 COMP-4*/
            public IntBasis WWORK_DDD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05       WWORK-TELEFONE         PIC S9(009)    VALUE +0 COMP-4*/
            public IntBasis WWORK_TELEFONE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05       WWORK-FAX              PIC S9(009)    VALUE +0 COMP-4*/
            public IntBasis WWORK_FAX { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05       WWORK-CGCCPF           PIC S9(015)    VALUE +0 COMP-3*/
            public IntBasis WWORK_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            /*"  05       WWORK-DATA-NASCIMENTO  PIC  X(010)    VALUE  SPACES.*/
            public StringBasis WWORK_DATA_NASCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"01  AREA-ABEND.*/
        }
        public VP0601B_AREA_ABEND AREA_ABEND { get; set; } = new VP0601B_AREA_ABEND();
        public class VP0601B_AREA_ABEND : VarBasis
        {
            /*"    05   WABEND.*/
            public VP0601B_WABEND WABEND { get; set; } = new VP0601B_WABEND();
            public class VP0601B_WABEND : VarBasis
            {
                /*"      10    FILLER                   PIC  X(010) VALUE            'VP0601B  '.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VP0601B  ");
                /*"      10    FILLER                   PIC  X(028) VALUE            ' *** ERRO  EXEC SQL *** '.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL *** ");
                /*"      10    FILLER                   PIC  X(014) VALUE            '    SQLCODE = '.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"      10    WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD1 = '.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"      10    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"      10    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    05      LOCALIZA-ABEND-1.*/
            }
            public VP0601B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new VP0601B_LOCALIZA_ABEND_1();
            public class VP0601B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05      LOCALIZA-ABEND-2.*/
            }
            public VP0601B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new VP0601B_LOCALIZA_ABEND_2();
            public class VP0601B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'COMANDO   = '.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"      10    COMANDO                  PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"    05         WSQLERRO.*/
            }
            public VP0601B_WSQLERRO WSQLERRO { get; set; } = new VP0601B_WSQLERRO();
            public class VP0601B_WSQLERRO : VarBasis
            {
                /*"      10       FILLER               PIC  X(014) VALUE               ' *** SQLERRMC '.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @" *** SQLERRMC ");
                /*"      10       WSQLERRMC            PIC  X(070) VALUE  SPACES.*/
                public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                /*"01           CT0006S-LINKAGE.*/
            }
        }
        public VP0601B_CT0006S_LINKAGE CT0006S_LINKAGE { get; set; } = new VP0601B_CT0006S_LINKAGE();
        public class VP0601B_CT0006S_LINKAGE : VarBasis
        {
            /*"  05         CT0006S-CEP-DESTINO    PIC  9(008).*/
            public IntBasis CT0006S_CEP_DESTINO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05         CT0006S-SIGLA-UF       PIC  X(002).*/
            public StringBasis CT0006S_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05         CT0006S-SQLCODE        PIC  S9(04) COMP.*/
            public IntBasis CT0006S_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05         CT0006S-MENSAGEM       PIC  X(070).*/
            public StringBasis CT0006S_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
            /*"  05         CT0006S-TP-LOGRAD      PIC  X(036).*/
            public StringBasis CT0006S_TP_LOGRAD { get; set; } = new StringBasis(new PIC("X", "36", "X(036)."), @"");
            /*"  05         CT0006S-NOM-LOGRAD     PIC  X(100).*/
            public StringBasis CT0006S_NOM_LOGRAD { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
            /*"  05         CT0006S-BAIRRO         PIC  X(072).*/
            public StringBasis CT0006S_BAIRRO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"  05         CT0006S-CIDADE         PIC  X(072).*/
            public StringBasis CT0006S_CIDADE { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"  05         CT0006S-UNIDADE-OPER   PIC  X(072).*/
            public StringBasis CT0006S_UNIDADE_OPER { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"  05         CT0006S-CENTRALIZ      PIC  X(072).*/
            public StringBasis CT0006S_CENTRALIZ { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"01  TAB-RENDAS.*/
        }
        public VP0601B_TAB_RENDAS TAB_RENDAS { get; set; } = new VP0601B_TAB_RENDAS();
        public class VP0601B_TAB_RENDAS : VarBasis
        {
            /*"    05      TAB-RENDA.*/
            public VP0601B_TAB_RENDA TAB_RENDA { get; set; } = new VP0601B_TAB_RENDA();
            public class VP0601B_TAB_RENDA : VarBasis
            {
                /*"      10    FILLER    OCCURS    5      TIMES.*/
                public ListBasis<VP0601B_FILLER_25> FILLER_25 { get; set; } = new ListBasis<VP0601B_FILLER_25>(5);
                public class VP0601B_FILLER_25 : VarBasis
                {
                    /*"        15  TAB-FAIXA-RENDA          PIC 9(07)V99.*/
                    public DoubleBasis TAB_FAIXA_RENDA { get; set; } = new DoubleBasis(new PIC("9", "7", "9(07)V99."), 2);
                    /*"        15  TAB-LIMIT-MAXIMO         PIC 9(07)V99.*/
                    public DoubleBasis TAB_LIMIT_MAXIMO { get; set; } = new DoubleBasis(new PIC("9", "7", "9(07)V99."), 2);
                    /*"01  TAB-FILIAIS.*/
                }
            }
        }
        public VP0601B_TAB_FILIAIS TAB_FILIAIS { get; set; } = new VP0601B_TAB_FILIAIS();
        public class VP0601B_TAB_FILIAIS : VarBasis
        {
            /*"    05      TAB-FILIAL.*/
            public VP0601B_TAB_FILIAL TAB_FILIAL { get; set; } = new VP0601B_TAB_FILIAL();
            public class VP0601B_TAB_FILIAL : VarBasis
            {
                /*"      10    FILLER    OCCURS    9999   TIMES.*/
                public ListBasis<VP0601B_FILLER_26> FILLER_26 { get; set; } = new ListBasis<VP0601B_FILLER_26>(9999);
                public class VP0601B_FILLER_26 : VarBasis
                {
                    /*"        15  TAB-FONTE                PIC S9(4) COMP.*/
                    public IntBasis TAB_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
                    /*"01  TAB-CBO1.*/
                }
            }
        }
        public VP0601B_TAB_CBO1 TAB_CBO1 { get; set; } = new VP0601B_TAB_CBO1();
        public class VP0601B_TAB_CBO1 : VarBasis
        {
            /*"    05      TAB-CBO.*/
            public VP0601B_TAB_CBO TAB_CBO { get; set; } = new VP0601B_TAB_CBO();
            public class VP0601B_TAB_CBO : VarBasis
            {
                /*"      10    FILLER    OCCURS    999   TIMES.*/
                public ListBasis<VP0601B_FILLER_27> FILLER_27 { get; set; } = new ListBasis<VP0601B_FILLER_27>(999);
                public class VP0601B_FILLER_27 : VarBasis
                {
                    /*"        15  TAB-DESCR-CBO-C          PIC  X(20).*/
                    public StringBasis TAB_DESCR_CBO_C { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
                }
            }
        }


        public Copies.GEJVW002 GEJVW002 { get; set; } = new Copies.GEJVW002();
        public Copies.GEJVWCNT GEJVWCNT { get; set; } = new Copies.GEJVWCNT();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.CONDITEC CONDITEC { get; set; } = new Dclgens.CONDITEC();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.COADSICO COADSICO { get; set; } = new Dclgens.COADSICO();
        public Dclgens.PARVDZUL PARVDZUL { get; set; } = new Dclgens.PARVDZUL();
        public Dclgens.CBHSTZUL CBHSTZUL { get; set; } = new Dclgens.CBHSTZUL();
        public Dclgens.HTCTBPVA HTCTBPVA { get; set; } = new Dclgens.HTCTBPVA();
        public Dclgens.FONTES FONTES { get; set; } = new Dclgens.FONTES();
        public Dclgens.ESTIPULA ESTIPULA { get; set; } = new Dclgens.ESTIPULA();
        public Dclgens.ERPROPAZ ERPROPAZ { get; set; } = new Dclgens.ERPROPAZ();
        public Dclgens.RCAPS RCAPS { get; set; } = new Dclgens.RCAPS();
        public Dclgens.RCAPCOMP RCAPCOMP { get; set; } = new Dclgens.RCAPCOMP();
        public Dclgens.FUNCICEF FUNCICEF { get; set; } = new Dclgens.FUNCICEF();
        public Dclgens.CBO CBO { get; set; } = new Dclgens.CBO();
        public Dclgens.PESSOA PESSOA { get; set; } = new Dclgens.PESSOA();
        public Dclgens.PLVAVGAP PLVAVGAP { get; set; } = new Dclgens.PLVAVGAP();
        public Dclgens.PRODUVG PRODUVG { get; set; } = new Dclgens.PRODUVG();
        public Dclgens.CLIENTE CLIENTE { get; set; } = new Dclgens.CLIENTE();
        public Dclgens.ENDERECO ENDERECO { get; set; } = new Dclgens.ENDERECO();
        public Dclgens.PESENDER PESENDER { get; set; } = new Dclgens.PESENDER();
        public Dclgens.PESFONE PESFONE { get; set; } = new Dclgens.PESFONE();
        public Dclgens.PESEMAIL PESEMAIL { get; set; } = new Dclgens.PESEMAIL();
        public Dclgens.CLIENEMA CLIENEMA { get; set; } = new Dclgens.CLIENEMA();
        public Dclgens.PESFIS PESFIS { get; set; } = new Dclgens.PESFIS();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.PROFIDCO PROFIDCO { get; set; } = new Dclgens.PROFIDCO();
        public Dclgens.PROPSSVD PROPSSVD { get; set; } = new Dclgens.PROPSSVD();
        public Dclgens.MALHACEF MALHACEF { get; set; } = new Dclgens.MALHACEF();
        public Dclgens.AGENCEF AGENCEF { get; set; } = new Dclgens.AGENCEF();
        public Dclgens.PROPVA PROPVA { get; set; } = new Dclgens.PROPVA();
        public Dclgens.COBPRPVA COBPRPVA { get; set; } = new Dclgens.COBPRPVA();
        public Dclgens.OPCPAGVI OPCPAGVI { get; set; } = new Dclgens.OPCPAGVI();
        public Dclgens.NUMOUTRO NUMOUTRO { get; set; } = new Dclgens.NUMOUTRO();
        public Dclgens.GEDOCCLI GEDOCCLI { get; set; } = new Dclgens.GEDOCCLI();
        public Dclgens.GECLIMOV GECLIMOV { get; set; } = new Dclgens.GECLIMOV();
        public Dclgens.PF062 PF062 { get; set; } = new Dclgens.PF062();
        public Dclgens.GE400 GE400 { get; set; } = new Dclgens.GE400();
        public Dclgens.PESSOJUR PESSOJUR { get; set; } = new Dclgens.PESSOJUR();
        public Dclgens.VG096 VG096 { get; set; } = new Dclgens.VG096();
        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public VP0601B_CPROPOSTA CPROPOSTA { get; set; } = new VP0601B_CPROPOSTA();
        public VP0601B_C01_RCAPCOMP C01_RCAPCOMP { get; set; } = new VP0601B_C01_RCAPCOMP();
        public VP0601B_CPESENDER CPESENDER { get; set; } = new VP0601B_CPESENDER();
        public VP0601B_CPESENDERR CPESENDERR { get; set; } = new VP0601B_CPESENDERR();
        public VP0601B_CFONE CFONE { get; set; } = new VP0601B_CFONE();
        public VP0601B_CRISCO CRISCO { get; set; } = new VP0601B_CRISCO();
        public VP0601B_CCLIENTES CCLIENTES { get; set; } = new VP0601B_CCLIENTES();
        public VP0601B_VGPLARAMC VGPLARAMC { get; set; } = new VP0601B_VGPLARAMC();
        public VP0601B_VGPLAACES VGPLAACES { get; set; } = new VP0601B_VGPLAACES();
        public VP0601B_C01_AGENCEF C01_AGENCEF { get; set; } = new VP0601B_C01_AGENCEF();
        public VP0601B_CCBO CCBO { get; set; } = new VP0601B_CCBO();
        public VP0601B_CFONTES CFONTES { get; set; } = new VP0601B_CFONTES();
        public VP0601B_C01_GECLIMOV C01_GECLIMOV { get; set; } = new VP0601B_C01_GECLIMOV();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -1366- DISPLAY ' ' */
            _.Display($" ");

            /*" -1368- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -1376- DISPLAY 'PROGRAMA EM EXECUCAO VP0601B-' 'VERSAO V.92 - DEMANDA 575149 - ' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) '-' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) */

            $"PROGRAMA EM EXECUCAO VP0601B-VERSAO V.92 - DEMANDA 575149 - FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)}-FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}"
            .Display();

            /*" -1378- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -1379- DISPLAY ' ' */
            _.Display($" ");

            /*" -1391- DISPLAY 'INICIOU O PROCESSAMENTO EM  ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"INICIOU O PROCESSAMENTO EM  {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -1392- MOVE 'VP0601B' TO LK-GEJVW002-NOM-PROG-ORIGEM */
            _.Move("VP0601B", GEJVW002.LK_GEJVW002_NOM_PROG_ORIGEM);

            /*" -1393- MOVE 'BATCH' TO LK-GEJVW002-COD-USUARIO-ORIGEM */
            _.Move("BATCH", GEJVW002.LK_GEJVW002_COD_USUARIO_ORIGEM);

            /*" -1393- MOVE 'GEJVS002' TO WS-JV1-PROGRAMA. */
            _.Move("GEJVS002", WS_JV1_PROGRAMA);

            /*" -1394- CALL WS-JV1-PROGRAMA USING LK-GEJVW002-NOM-PROG-ORIGEM LK-GEJVW002-COD-USUARIO-ORIGEM LK-GEJVW002-SIAS-NUM-EMP LK-GEJVW002-SIAS-DTA-INI LK-GEJVW002-SIAS-COD-LIDER LK-GEJVW002-SIAS-COD-CGCCPF LK-GEJVW002-SIAS-COD-EMP-CAP LK-GEJVW002-PREV-NUM-EMP LK-GEJVW002-PREV-DTA-INI LK-GEJVW002-PREV-COD-LIDER LK-GEJVW002-PREV-COD-CGCCPF LK-GEJVW002-PREV-COD-EMP-CAP LK-GEJVW002-JV-NUM-EMP LK-GEJVW002-JV-DTA-INI LK-GEJVW002-JV-COD-LIDER LK-GEJVW002-JV-COD-CGCCPF LK-GEJVW002-JV-COD-EMP-CAP LK-GEJVWCNT-IND-ERRO LK-GEJVWCNT-MENSAGEM-RETORNO LK-GEJVWCNT-NOME-TABELA LK-GEJVWCNT-SQLCODE LK-GEJVWCNT-SQLERRMC. */
            _.Call(WS_JV1_PROGRAMA, GEJVW002, GEJVWCNT);

            /*" -1395- IF LK-GEJVWCNT-IND-ERRO NOT = 0 */

            if (GEJVWCNT.LK_GEJVWCNT_IND_ERRO != 0)
            {

                /*" -1396- DISPLAY 'IND ERRO    = ' LK-GEJVWCNT-IND-ERRO */
                _.Display($"IND ERRO    = {GEJVWCNT.LK_GEJVWCNT_IND_ERRO}");

                /*" -1397- DISPLAY 'MENSAGEM    = ' LK-GEJVWCNT-MENSAGEM-RETORNO */
                _.Display($"MENSAGEM    = {GEJVWCNT.LK_GEJVWCNT_MENSAGEM_RETORNO}");

                /*" -1398- DISPLAY 'TABELA      = ' LK-GEJVWCNT-NOME-TABELA */
                _.Display($"TABELA      = {GEJVWCNT.LK_GEJVWCNT_NOME_TABELA}");

                /*" -1399- DISPLAY 'SQLCODE     = ' LK-GEJVWCNT-SQLCODE */
                _.Display($"SQLCODE     = {GEJVWCNT.LK_GEJVWCNT_SQLCODE}");

                /*" -1400- MOVE LK-GEJVWCNT-SQLCODE TO WSQLCODE */
                _.Move(GEJVWCNT.LK_GEJVWCNT_SQLCODE, AREA_ABEND.WABEND.WSQLCODE);

                /*" -1401- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1407- END-IF */
            }


            /*" -1408- INITIALIZE TAB-RENDAS. */
            _.Initialize(
                TAB_RENDAS
            );

            /*" -1410- INITIALIZE WS-TAXAVG WS-VALOR-IS-7725. */
            _.Initialize(
                WS_TAXAVG
                , WS_VALOR_IS_7725
            );

            /*" -1411- MOVE 500,00 TO TAB-FAIXA-RENDA (1) */
            _.Move(500.00, TAB_RENDAS.TAB_RENDA.FILLER_25[1].TAB_FAIXA_RENDA);

            /*" -1412- MOVE 36000,00 TO TAB-LIMIT-MAXIMO (1) */
            _.Move(36000.00, TAB_RENDAS.TAB_RENDA.FILLER_25[1].TAB_LIMIT_MAXIMO);

            /*" -1413- MOVE 1500,00 TO TAB-FAIXA-RENDA (2) */
            _.Move(1500.00, TAB_RENDAS.TAB_RENDA.FILLER_25[2].TAB_FAIXA_RENDA);

            /*" -1414- MOVE 108000,00 TO TAB-LIMIT-MAXIMO (2) */
            _.Move(108000.00, TAB_RENDAS.TAB_RENDA.FILLER_25[2].TAB_LIMIT_MAXIMO);

            /*" -1415- MOVE 2500,00 TO TAB-FAIXA-RENDA (3) */
            _.Move(2500.00, TAB_RENDAS.TAB_RENDA.FILLER_25[3].TAB_FAIXA_RENDA);

            /*" -1416- MOVE 180000,00 TO TAB-LIMIT-MAXIMO (3) */
            _.Move(180000.00, TAB_RENDAS.TAB_RENDA.FILLER_25[3].TAB_LIMIT_MAXIMO);

            /*" -1417- MOVE 4500,00 TO TAB-FAIXA-RENDA (4) */
            _.Move(4500.00, TAB_RENDAS.TAB_RENDA.FILLER_25[4].TAB_FAIXA_RENDA);

            /*" -1418- MOVE 300000,00 TO TAB-LIMIT-MAXIMO (4) */
            _.Move(300000.00, TAB_RENDAS.TAB_RENDA.FILLER_25[4].TAB_LIMIT_MAXIMO);

            /*" -1419- MOVE 4500,01 TO TAB-FAIXA-RENDA (5) */
            _.Move(4500.01, TAB_RENDAS.TAB_RENDA.FILLER_25[5].TAB_FAIXA_RENDA);

            /*" -1425- MOVE 300000,00 TO TAB-LIMIT-MAXIMO (5). */
            _.Move(300000.00, TAB_RENDAS.TAB_RENDA.FILLER_25[5].TAB_LIMIT_MAXIMO);

            /*" -1427- MOVE '0000-PRINCIPAL                     ' TO PARAGRAFO. */
            _.Move("0000-PRINCIPAL                     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1433- PERFORM R0100-00-INICIALIZA. */

            R0100_00_INICIALIZA_SECTION();

            /*" -1439- MOVE '0001-PRINCIPAL                     ' TO PARAGRAFO. */
            _.Move("0001-PRINCIPAL                     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1440- PERFORM R0900-00-DECLARE-PROPOSTA. */

            R0900_00_DECLARE_PROPOSTA_SECTION();

            /*" -1442- PERFORM R0910-00-FETCH-PROPOSTA. */

            R0910_00_FETCH_PROPOSTA_SECTION();

            /*" -1443- IF WS-EOR = 1 */

            if (WORK_AREA.WS_EOR == 1)
            {

                /*" -1444- DISPLAY '////////////////////////////////////////////////' */
                _.Display($"////////////////////////////////////////////////");

                /*" -1445- DISPLAY '//                TERMINO                     //' */
                _.Display($"//                TERMINO                     //");

                /*" -1446- DISPLAY '//                                            //' */
                _.Display($"//                                            //");

                /*" -1447- DISPLAY '//        ==>    N O R M A L  <==             //' */
                _.Display($"//        ==>    N O R M A L  <==             //");

                /*" -1448- DISPLAY '//                                            //' */
                _.Display($"//                                            //");

                /*" -1449- DISPLAY '//      PROGRAMA =>  VP0601B                  //' */
                _.Display($"//      PROGRAMA =>  VP0601B                  //");

                /*" -1450- DISPLAY '//                                            //' */
                _.Display($"//                                            //");

                /*" -1451- DISPLAY '////////////////////////////////////////////////' */
                _.Display($"////////////////////////////////////////////////");

                /*" -1457- GO TO R0000-00-FINALIZA. */

                R0000_00_FINALIZA(); //GOTO
                return;
            }


            /*" -1460- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WS-EOR = 1. */

            while (!(WORK_AREA.WS_EOR == 1))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -1460- PERFORM R9100-00-UPDATE-NUM-OUTROS. */

            R9100_00_UPDATE_NUM_OUTROS_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0000_00_FINALIZA */

            R0000_00_FINALIZA();

        }

        [StopWatch]
        /*" R0000-00-FINALIZA */
        private void R0000_00_FINALIZA(bool isPerform = false)
        {
            /*" -1465- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1469- DISPLAY ' ' */
            _.Display($" ");

            /*" -1470- DISPLAY '////////////////////////////////////////////////' */
            _.Display($"////////////////////////////////////////////////");

            /*" -1471- DISPLAY '//                                            //' */
            _.Display($"//                                            //");

            /*" -1472- DISPLAY '//      ==> TERMINO NORMAL <==                //' */
            _.Display($"//      ==> TERMINO NORMAL <==                //");

            /*" -1473- DISPLAY '//                                            //' */
            _.Display($"//                                            //");

            /*" -1474- DISPLAY '//      PROGRAMA =>  VP0601B                  //' */
            _.Display($"//      PROGRAMA =>  VP0601B                  //");

            /*" -1475- DISPLAY '//                                            //' */
            _.Display($"//                                            //");

            /*" -1476- DISPLAY '////////////////////////////////////////////////' */
            _.Display($"////////////////////////////////////////////////");

            /*" -1477- DISPLAY 'PROPOSTAS LIDAS = ' WS-PROPOSTAS-LIDAS */
            _.Display($"PROPOSTAS LIDAS = {WS_PROPOSTAS_LIDAS}");

            /*" -1478- DISPLAY 'LIDOS PROPOSTAVA-FIDELIZ  ' AC-L-MOVIMENTO */
            _.Display($"LIDOS PROPOSTAVA-FIDELIZ  {WORK_AREA.AC_L_MOVIMENTO}");

            /*" -1479- DISPLAY 'GRAVADOS PROPOSTAVA       ' AC-I-PROPOSTAVA */
            _.Display($"GRAVADOS PROPOSTAVA       {WORK_AREA.AC_I_PROPOSTAVA}");

            /*" -1480- DISPLAY 'GRAVADOS VG-HIST-RAMO-COB ' AC-I-HISTRAMOCOB */
            _.Display($"GRAVADOS VG-HIST-RAMO-COB {WORK_AREA.AC_I_HISTRAMOCOB}");

            /*" -1481- DISPLAY 'GRAVADOS VG-HIST-ACES-COB ' AC-I-HISTACESCOB */
            _.Display($"GRAVADOS VG-HIST-ACES-COB {WORK_AREA.AC_I_HISTACESCOB}");

            /*" -1483- PERFORM R9900-00-MOSTRA-TOTAIS */

            R9900_00_MOSTRA_TOTAIS_SECTION();

            /*" -1484- MOVE 0 TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -1491- DISPLAY 'VP0601B VERSAO 89 - FIM PROCESSAMENTO EM  ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"VP0601B VERSAO 89 - FIM PROCESSAMENTO EM  {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -1491- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0100-00-INICIALIZA-SECTION */
        private void R0100_00_INICIALIZA_SECTION()
        {
            /*" -1497- INITIALIZE TOTAIS-ROT. */
            _.Initialize(
                TOTAIS_ROT
            );

            /*" -1499- MOVE 'R0100-00-SELECT-SISTEMAS      ' TO PARAGRAFO. */
            _.Move("R0100-00-SELECT-SISTEMAS      ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1500- MOVE 01 TO SII. */
            _.Move(01, WS_HORAS.SII);

            /*" -1501- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1506- PERFORM R0100_00_INICIALIZA_DB_SELECT_1 */

            R0100_00_INICIALIZA_DB_SELECT_1();

            /*" -1509- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1510- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1511- DISPLAY 'PROBLEMAS NO ACESSO  A SISTEMAS ' */
                _.Display($"PROBLEMAS NO ACESSO  A SISTEMAS ");

                /*" -1513- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1515- MOVE 'R0100-00-SELECT-NUM-OUTROS    ' TO PARAGRAFO. */
            _.Move("R0100-00-SELECT-NUM-OUTROS    ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1516- MOVE 02 TO SII. */
            _.Move(02, WS_HORAS.SII);

            /*" -1517- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1521- PERFORM R0100_00_INICIALIZA_DB_SELECT_2 */

            R0100_00_INICIALIZA_DB_SELECT_2();

            /*" -1524- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1525- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1526- DISPLAY 'PROBLEMAS NO ACESSO  A NUMERO OUTROS' */
                _.Display($"PROBLEMAS NO ACESSO  A NUMERO OUTROS");

                /*" -1528- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1530- INITIALIZE TAB-FILIAIS. */
            _.Initialize(
                TAB_FILIAIS
            );

            /*" -1532- PERFORM R6000-00-DECLARE-AGENCEF. */

            R6000_00_DECLARE_AGENCEF_SECTION();

            /*" -1534- PERFORM R6010-00-FETCH-AGENCEF. */

            R6010_00_FETCH_AGENCEF_SECTION();

            /*" -1535- IF WFIM-AGENCEF NOT EQUAL SPACES */

            if (!WORK_AREA.WFIM_AGENCEF.IsEmpty())
            {

                /*" -1536- DISPLAY '0000 - PROBLEMA NO FETCH DA AGENCIACEF' */
                _.Display($"0000 - PROBLEMA NO FETCH DA AGENCIACEF");

                /*" -1538- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1541- PERFORM R6020-00-CARREGA-FILIAL UNTIL WFIM-AGENCEF EQUAL 'S' . */

            while (!(WORK_AREA.WFIM_AGENCEF == "S"))
            {

                R6020_00_CARREGA_FILIAL_SECTION();
            }

            /*" -1543- MOVE ZEROS TO TAB-CBO1. */
            _.Move(0, TAB_CBO1);

            /*" -1545- PERFORM R6100-00-DECLARE-CBO. */

            R6100_00_DECLARE_CBO_SECTION();

            /*" -1547- PERFORM R6110-00-FETCH-CBO. */

            R6110_00_FETCH_CBO_SECTION();

            /*" -1548- IF WFIM-CBO NOT EQUAL SPACES */

            if (!WORK_AREA.WFIM_CBO.IsEmpty())
            {

                /*" -1549- DISPLAY '0100 - PROBLEMA NO FETCH DA CBO         ' */
                _.Display($"0100 - PROBLEMA NO FETCH DA CBO         ");

                /*" -1551- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1552- PERFORM R6120-00-CARREGA-CBO UNTIL WFIM-CBO EQUAL 'S' . */

            while (!(WORK_AREA.WFIM_CBO == "S"))
            {

                R6120_00_CARREGA_CBO_SECTION();
            }

        }

        [StopWatch]
        /*" R0100-00-INICIALIZA-DB-SELECT-1 */
        public void R0100_00_INICIALIZA_DB_SELECT_1()
        {
            /*" -1506- EXEC SQL SELECT DATA_MOV_ABERTO INTO :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'PF' END-EXEC. */

            var r0100_00_INICIALIZA_DB_SELECT_1_Query1 = new R0100_00_INICIALIZA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_INICIALIZA_DB_SELECT_1_Query1.Execute(r0100_00_INICIALIZA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-INICIALIZA-DB-SELECT-2 */
        public void R0100_00_INICIALIZA_DB_SELECT_2()
        {
            /*" -1521- EXEC SQL SELECT NUM_CLIENTE INTO :DCLNUMERO-OUTROS.NUM-CLIENTE FROM SEGUROS.NUMERO_OUTROS END-EXEC. */

            var r0100_00_INICIALIZA_DB_SELECT_2_Query1 = new R0100_00_INICIALIZA_DB_SELECT_2_Query1()
            {
            };

            var executed_1 = R0100_00_INICIALIZA_DB_SELECT_2_Query1.Execute(r0100_00_INICIALIZA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUM_CLIENTE, NUMOUTRO.DCLNUMERO_OUTROS.NUM_CLIENTE);
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-PROPOSTA-SECTION */
        private void R0900_00_DECLARE_PROPOSTA_SECTION()
        {
            /*" -1574- MOVE 'DECLARE CPROPOSTA                  ' TO COMANDO. */
            _.Move("DECLARE CPROPOSTA                  ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1575- MOVE 03 TO SII. */
            _.Move(03, WS_HORAS.SII);

            /*" -1576- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1727- PERFORM R0900_00_DECLARE_PROPOSTA_DB_DECLARE_1 */

            R0900_00_DECLARE_PROPOSTA_DB_DECLARE_1();

            /*" -1730- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1731- MOVE 'OPEN CPROPOSTA                     ' TO COMANDO. */
            _.Move("OPEN CPROPOSTA                     ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1732- MOVE 04 TO SII. */
            _.Move(04, WS_HORAS.SII);

            /*" -1733- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1733- PERFORM R0900_00_DECLARE_PROPOSTA_DB_OPEN_1 */

            R0900_00_DECLARE_PROPOSTA_DB_OPEN_1();

            /*" -1736- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1737- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1738- DISPLAY '*** VP0601B *** ERRO OPEN CPROPOSTA  ' */
                _.Display($"*** VP0601B *** ERRO OPEN CPROPOSTA  ");

                /*" -1738- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-PROPOSTA-DB-DECLARE-1 */
        public void R0900_00_DECLARE_PROPOSTA_DB_DECLARE_1()
        {
            /*" -1727- EXEC SQL DECLARE CPROPOSTA CURSOR FOR SELECT B.NUM_APOLICE, B.COD_SUBGRUPO , B.NUM_IDENTIFICACAO, B.DPS_TITULAR, B.DPS_CONJUGE, B.APOS_INVALIDEZ, B.NUM_CONTR_VINCULO, B.COD_CORRESP_BANC, B.NUM_PRAZO_FIN, B.COD_OPER_CREDITO, C.OPCAO_COBER, C.COD_PLANO, B.COD_USUARIO, C.NUM_PROPOSTA_SIVPF, C.COD_PESSOA, C.NUM_SICOB , C.DATA_PROPOSTA , C.COD_PRODUTO_SIVPF , C.COD_EMPRESA_SIVPF , C.AGECOBR , C.DIA_DEBITO , C.OPCAOPAG , C.AGECTADEB , C.OPRCTADEB , C.NUMCTADEB , C.DIGCTADEB , C.PERC_DESCONTO , C.NRMATRVEN , C.AGECTAVEN , C.OPRCTAVEN , C.NUMCTAVEN , C.DIGCTAVEN , C.CGC_CONVENENTE , C.NOME_CONVENENTE , C.NRMATRCON , C.DTQITBCO , C.VAL_PAGO , C.AGEPGTO , C.VAL_TARIFA , C.VAL_IOF , C.DATA_CREDITO , C.VAL_COMISSAO , C.SIT_PROPOSTA , C.COD_USUARIO , C.CANAL_PROPOSTA , C.NSAS_SIVPF , C.ORIGEM_PROPOSTA , C.TIMESTAMP , C.NSL , C.NSAC_SIVPF , C.NOME_CONJUGE , C.DATA_NASC_CONJUGE , C.PROFISSAO_CONJUGE , C.FAIXA_RENDA_IND , C.FAIXA_RENDA_FAM , A.COD_PRODUTO , A.PERI_PAGAMENTO , A.DESCONTO_ADESAO , A.RAMO , C.NRMATRCON FROM SEGUROS.PRODUTOS_VG A, SEGUROS.PROP_SASSE_VIDA B, SEGUROS.PROPOSTA_FIDELIZ C, SEGUROS.PESSOA_FISICA F WHERE A.ESTR_COBR = 'MULT' AND B.NUM_APOLICE = A.NUM_APOLICE AND B.COD_SUBGRUPO = A.COD_SUBGRUPO AND C.NUM_IDENTIFICACAO = B.NUM_IDENTIFICACAO AND C.SIT_PROPOSTA IN ( 'ENV' , 'POV' , 'DEC' ) AND A.RAMO = 77 AND C.COD_PESSOA = F.COD_PESSOA UNION ALL SELECT B.NUM_APOLICE, B.COD_SUBGRUPO , B.NUM_IDENTIFICACAO, B.DPS_TITULAR, B.DPS_CONJUGE, B.APOS_INVALIDEZ, B.NUM_CONTR_VINCULO, B.COD_CORRESP_BANC, B.NUM_PRAZO_FIN, B.COD_OPER_CREDITO, C.OPCAO_COBER, C.COD_PLANO, B.COD_USUARIO, C.NUM_PROPOSTA_SIVPF, C.COD_PESSOA, C.NUM_SICOB , C.DATA_PROPOSTA , C.COD_PRODUTO_SIVPF , C.COD_EMPRESA_SIVPF , C.AGECOBR , C.DIA_DEBITO , C.OPCAOPAG , C.AGECTADEB , C.OPRCTADEB , C.NUMCTADEB , C.DIGCTADEB , C.PERC_DESCONTO , C.NRMATRVEN , C.AGECTAVEN , C.OPRCTAVEN , C.NUMCTAVEN , C.DIGCTAVEN , C.CGC_CONVENENTE , C.NOME_CONVENENTE , C.NRMATRCON , C.DTQITBCO , C.VAL_PAGO , C.AGEPGTO , C.VAL_TARIFA , C.VAL_IOF , C.DATA_CREDITO , C.VAL_COMISSAO , C.SIT_PROPOSTA , C.COD_USUARIO , C.CANAL_PROPOSTA , C.NSAS_SIVPF , C.ORIGEM_PROPOSTA , C.TIMESTAMP , C.NSL , C.NSAC_SIVPF , C.NOME_CONJUGE , C.DATA_NASC_CONJUGE , C.PROFISSAO_CONJUGE , C.FAIXA_RENDA_IND , C.FAIXA_RENDA_FAM , A.COD_PRODUTO , A.PERI_PAGAMENTO , A.DESCONTO_ADESAO , A.RAMO , C.NRMATRCON FROM SEGUROS.PRODUTOS_VG A, SEGUROS.PROP_SASSE_VIDA B, SEGUROS.PROPOSTA_FIDELIZ C, SEGUROS.PESSOA_JURIDICA J WHERE A.ESTR_COBR = 'MULT' AND B.NUM_APOLICE = A.NUM_APOLICE AND B.COD_SUBGRUPO = A.COD_SUBGRUPO AND C.NUM_IDENTIFICACAO = B.NUM_IDENTIFICACAO AND C.SIT_PROPOSTA IN ( 'ENV' , 'POV' , 'DEC' ) AND A.RAMO = 77 AND A.COD_PRODUTO IN ( 7725, :JVPRD7725 , 7733, :JVPRD7733) AND C.COD_PESSOA = J.COD_PESSOA ORDER BY 14 WITH UR END-EXEC. */
            CPROPOSTA = new VP0601B_CPROPOSTA(true);
            string GetQuery_CPROPOSTA()
            {
                var query = @$"SELECT B.NUM_APOLICE
							, 
							B.COD_SUBGRUPO
							, 
							B.NUM_IDENTIFICACAO
							, 
							B.DPS_TITULAR
							, 
							B.DPS_CONJUGE
							, 
							B.APOS_INVALIDEZ
							, 
							B.NUM_CONTR_VINCULO
							, 
							B.COD_CORRESP_BANC
							, 
							B.NUM_PRAZO_FIN
							, 
							B.COD_OPER_CREDITO
							, 
							C.OPCAO_COBER
							, 
							C.COD_PLANO
							, 
							B.COD_USUARIO
							, 
							C.NUM_PROPOSTA_SIVPF
							, 
							C.COD_PESSOA
							, 
							C.NUM_SICOB
							, 
							C.DATA_PROPOSTA
							, 
							C.COD_PRODUTO_SIVPF
							, 
							C.COD_EMPRESA_SIVPF
							, 
							C.AGECOBR
							, 
							C.DIA_DEBITO
							, 
							C.OPCAOPAG
							, 
							C.AGECTADEB
							, 
							C.OPRCTADEB
							, 
							C.NUMCTADEB
							, 
							C.DIGCTADEB
							, 
							C.PERC_DESCONTO
							, 
							C.NRMATRVEN
							, 
							C.AGECTAVEN
							, 
							C.OPRCTAVEN
							, 
							C.NUMCTAVEN
							, 
							C.DIGCTAVEN
							, 
							C.CGC_CONVENENTE
							, 
							C.NOME_CONVENENTE
							, 
							C.NRMATRCON
							, 
							C.DTQITBCO
							, 
							C.VAL_PAGO
							, 
							C.AGEPGTO
							, 
							C.VAL_TARIFA
							, 
							C.VAL_IOF
							, 
							C.DATA_CREDITO
							, 
							C.VAL_COMISSAO
							, 
							C.SIT_PROPOSTA
							, 
							C.COD_USUARIO
							, 
							C.CANAL_PROPOSTA
							, 
							C.NSAS_SIVPF
							, 
							C.ORIGEM_PROPOSTA
							, 
							C.TIMESTAMP
							, 
							C.NSL
							, 
							C.NSAC_SIVPF
							, 
							C.NOME_CONJUGE
							, 
							C.DATA_NASC_CONJUGE
							, 
							C.PROFISSAO_CONJUGE
							, 
							C.FAIXA_RENDA_IND
							, 
							C.FAIXA_RENDA_FAM
							, 
							A.COD_PRODUTO
							, 
							A.PERI_PAGAMENTO
							, 
							A.DESCONTO_ADESAO
							, 
							A.RAMO
							, 
							C.NRMATRCON 
							FROM SEGUROS.PRODUTOS_VG A
							, 
							SEGUROS.PROP_SASSE_VIDA B
							, 
							SEGUROS.PROPOSTA_FIDELIZ C
							, 
							SEGUROS.PESSOA_FISICA F 
							WHERE A.ESTR_COBR = 'MULT' 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.COD_SUBGRUPO = A.COD_SUBGRUPO 
							AND C.NUM_IDENTIFICACAO = B.NUM_IDENTIFICACAO 
							AND C.SIT_PROPOSTA IN ( 'ENV'
							, 'POV'
							, 'DEC' ) 
							AND A.RAMO = 77 
							AND C.COD_PESSOA = F.COD_PESSOA 
							UNION ALL 
							SELECT B.NUM_APOLICE
							, 
							B.COD_SUBGRUPO
							, 
							B.NUM_IDENTIFICACAO
							, 
							B.DPS_TITULAR
							, 
							B.DPS_CONJUGE
							, 
							B.APOS_INVALIDEZ
							, 
							B.NUM_CONTR_VINCULO
							, 
							B.COD_CORRESP_BANC
							, 
							B.NUM_PRAZO_FIN
							, 
							B.COD_OPER_CREDITO
							, 
							C.OPCAO_COBER
							, 
							C.COD_PLANO
							, 
							B.COD_USUARIO
							, 
							C.NUM_PROPOSTA_SIVPF
							, 
							C.COD_PESSOA
							, 
							C.NUM_SICOB
							, 
							C.DATA_PROPOSTA
							, 
							C.COD_PRODUTO_SIVPF
							, 
							C.COD_EMPRESA_SIVPF
							, 
							C.AGECOBR
							, 
							C.DIA_DEBITO
							, 
							C.OPCAOPAG
							, 
							C.AGECTADEB
							, 
							C.OPRCTADEB
							, 
							C.NUMCTADEB
							, 
							C.DIGCTADEB
							, 
							C.PERC_DESCONTO
							, 
							C.NRMATRVEN
							, 
							C.AGECTAVEN
							, 
							C.OPRCTAVEN
							, 
							C.NUMCTAVEN
							, 
							C.DIGCTAVEN
							, 
							C.CGC_CONVENENTE
							, 
							C.NOME_CONVENENTE
							, 
							C.NRMATRCON
							, 
							C.DTQITBCO
							, 
							C.VAL_PAGO
							, 
							C.AGEPGTO
							, 
							C.VAL_TARIFA
							, 
							C.VAL_IOF
							, 
							C.DATA_CREDITO
							, 
							C.VAL_COMISSAO
							, 
							C.SIT_PROPOSTA
							, 
							C.COD_USUARIO
							, 
							C.CANAL_PROPOSTA
							, 
							C.NSAS_SIVPF
							, 
							C.ORIGEM_PROPOSTA
							, 
							C.TIMESTAMP
							, 
							C.NSL
							, 
							C.NSAC_SIVPF
							, 
							C.NOME_CONJUGE
							, 
							C.DATA_NASC_CONJUGE
							, 
							C.PROFISSAO_CONJUGE
							, 
							C.FAIXA_RENDA_IND
							, 
							C.FAIXA_RENDA_FAM
							, 
							A.COD_PRODUTO
							, 
							A.PERI_PAGAMENTO
							, 
							A.DESCONTO_ADESAO
							, 
							A.RAMO
							, 
							C.NRMATRCON 
							FROM SEGUROS.PRODUTOS_VG A
							, 
							SEGUROS.PROP_SASSE_VIDA B
							, 
							SEGUROS.PROPOSTA_FIDELIZ C
							, 
							SEGUROS.PESSOA_JURIDICA J 
							WHERE A.ESTR_COBR = 'MULT' 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.COD_SUBGRUPO = A.COD_SUBGRUPO 
							AND C.NUM_IDENTIFICACAO = B.NUM_IDENTIFICACAO 
							AND C.SIT_PROPOSTA IN ( 'ENV'
							, 'POV'
							, 'DEC' ) 
							AND A.RAMO = 77 
							AND A.COD_PRODUTO IN ( 7725
							, '{JVBKINCL.JV_PRODUTOS.JVPRD7725}' 
							, 7733
							, '{JVBKINCL.JV_PRODUTOS.JVPRD7733}') 
							AND C.COD_PESSOA = J.COD_PESSOA 
							ORDER BY 14";

                return query;
            }
            CPROPOSTA.GetQueryEvent += GetQuery_CPROPOSTA;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-PROPOSTA-DB-OPEN-1 */
        public void R0900_00_DECLARE_PROPOSTA_DB_OPEN_1()
        {
            /*" -1733- EXEC SQL OPEN CPROPOSTA END-EXEC. */

            CPROPOSTA.Open();

        }

        [StopWatch]
        /*" R1510-00-SELECT-RCAPCOMP-DB-DECLARE-1 */
        public void R1510_00_SELECT_RCAPCOMP_DB_DECLARE_1()
        {
            /*" -3784- EXEC SQL DECLARE C01_RCAPCOMP CURSOR FOR SELECT BCO_AVISO, AGE_AVISO, NUM_AVISO_CREDITO, DATA_MOVIMENTO, DATA_RCAP, COD_OPERACAO FROM SEGUROS.RCAP_COMPLEMENTAR WHERE COD_FONTE = :DCLRCAPS.RCAPS-COD-FONTE AND NUM_RCAP = :DCLRCAPS.RCAPS-NUM-RCAP AND NUM_RCAP_COMPLEMEN = 0 ORDER BY COD_OPERACAO DESC END-EXEC */
            C01_RCAPCOMP = new VP0601B_C01_RCAPCOMP(true);
            string GetQuery_C01_RCAPCOMP()
            {
                var query = @$"SELECT BCO_AVISO
							, 
							AGE_AVISO
							, 
							NUM_AVISO_CREDITO
							, 
							DATA_MOVIMENTO
							, 
							DATA_RCAP
							, 
							COD_OPERACAO 
							FROM SEGUROS.RCAP_COMPLEMENTAR 
							WHERE COD_FONTE = '{RCAPS.DCLRCAPS.RCAPS_COD_FONTE}' 
							AND NUM_RCAP = '{RCAPS.DCLRCAPS.RCAPS_NUM_RCAP}' 
							AND NUM_RCAP_COMPLEMEN = 0 
							ORDER BY COD_OPERACAO DESC";

                return query;
            }
            C01_RCAPCOMP.GetQueryEvent += GetQuery_C01_RCAPCOMP;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-PROPOSTA-SECTION */
        private void R0910_00_FETCH_PROPOSTA_SECTION()
        {
            /*" -1750- MOVE 'R0910-00-FETCH-PROPOSTA     ' TO PARAGRAFO. */
            _.Move("R0910-00-FETCH-PROPOSTA     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1752- MOVE 'FETCH CPROPOSTA             ' TO COMANDO. */
            _.Move("FETCH CPROPOSTA             ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1819- PERFORM R0910_00_FETCH_PROPOSTA_DB_FETCH_1 */

            R0910_00_FETCH_PROPOSTA_DB_FETCH_1();

            /*" -1823- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1824- ADD 1 TO WS-PROPOSTAS-LIDAS */
                WS_PROPOSTAS_LIDAS.Value = WS_PROPOSTAS_LIDAS + 1;

                /*" -1826- END-IF */
            }


            /*" -1827- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1827- PERFORM R0910_00_FETCH_PROPOSTA_DB_CLOSE_1 */

                R0910_00_FETCH_PROPOSTA_DB_CLOSE_1();

                /*" -1829- MOVE 1 TO WS-EOR */
                _.Move(1, WORK_AREA.WS_EOR);

                /*" -1830- GO TO R0910-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                return;

                /*" -1831- ELSE */
            }
            else
            {


                /*" -1833- IF (SQLCODE NOT EQUAL 100) AND (SQLCODE NOT EQUAL 0) */

                if ((DB.SQLCODE != 100) && (DB.SQLCODE != 0))
                {

                    /*" -1835- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1836- MOVE PROPOFID-COD-PRODUTO-SIVPF TO WHOST-PRODUTO-SIVPF */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF, WHOST_PRODUTO_SIVPF);

            /*" -1838- MOVE PROPOFID-NRMATRVEN TO WHOST-NRMATRVEN */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN, WHOST_NRMATRVEN);

            /*" -1842- MOVE PRODUVG-RAMO OF DCLPRODUTOS-VG TO PROPOFID-COD-PRODUTO-SIVPF */
            _.Move(PRODUVG.DCLPRODUTOS_VG.PRODUVG_RAMO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF);

            /*" -1845- MOVE PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO W-NUM-PROPOSTA. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, WORK_AREA.W_NUM_PROPOSTA);

            /*" -1848- MOVE PROPOFID-ORIGEM-PROPOSTA OF DCLPROPOSTA-FIDELIZ TO W-ORIGEM-PROPOSTA. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA, WORK_AREA.W_ORIGEM_PROPOSTA);

            /*" -1850- PERFORM R2211-00-SELECT-PESSOA-FISICA. */

            R2211_00_SELECT_PESSOA_FISICA_SECTION();

            /*" -1852- PERFORM R0911-00-SELECT-RCAPS */

            R0911_00_SELECT_RCAPS_SECTION();

            /*" -1853- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1854- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1855- GO TO R0910-00-FETCH-PROPOSTA */
                    new Task(() => R0910_00_FETCH_PROPOSTA_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -1856- ELSE */
                }
                else
                {


                    /*" -1857- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1858- END-IF */
                }


                /*" -1861- END-IF. */
            }


            /*" -1863- IF RCAPS-AGE-COBRANCA NOT EQUAL PROPOFID-AGECOBR OF DCLPROPOSTA-FIDELIZ */

            if (RCAPS.DCLRCAPS.RCAPS_AGE_COBRANCA != PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR)
            {

                /*" -1865- MOVE RCAPS-AGE-COBRANCA TO PROPOFID-AGECOBR OF DCLPROPOSTA-FIDELIZ */
                _.Move(RCAPS.DCLRCAPS.RCAPS_AGE_COBRANCA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR);

                /*" -1866- PERFORM R0913-00-UPDATE-PROPOFID */

                R0913_00_UPDATE_PROPOFID_SECTION();

                /*" -1868- END-IF. */
            }


            /*" -1869- IF WHOST-PRODUTO-SIVPF = 7708 */

            if (WHOST_PRODUTO_SIVPF == 7708)
            {

                /*" -1871- IF RCAPS-AGE-COBRANCA NOT EQUAL PROPOFID-AGEPGTO OF DCLPROPOSTA-FIDELIZ */

                if (RCAPS.DCLRCAPS.RCAPS_AGE_COBRANCA != PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGEPGTO)
                {

                    /*" -1873- MOVE RCAPS-AGE-COBRANCA TO PROPOFID-AGEPGTO OF DCLPROPOSTA-FIDELIZ */
                    _.Move(RCAPS.DCLRCAPS.RCAPS_AGE_COBRANCA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGEPGTO);

                    /*" -1874- PERFORM R0914-00-UPDATE-AGE-PGTO */

                    R0914_00_UPDATE_AGE_PGTO_SECTION();

                    /*" -1874- END-IF. */
                }

            }


            /*" -0- FLUXCONTROL_PERFORM R0910_CONTINUA */

            R0910_CONTINUA();

        }

        [StopWatch]
        /*" R0910-00-FETCH-PROPOSTA-DB-FETCH-1 */
        public void R0910_00_FETCH_PROPOSTA_DB_FETCH_1()
        {
            /*" -1819- EXEC SQL FETCH CPROPOSTA INTO :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE , :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO , :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-IDENTIFICACAO , :DCLPROP-SASSE-VIDA.PROPSSVD-DPS-TITULAR , :DCLPROP-SASSE-VIDA.PROPSSVD-DPS-CONJUGE , :DCLPROP-SASSE-VIDA.PROPSSVD-APOS-INVALIDEZ , :PROPSSVD-NUM-CONTR-VINCULO :VIND-NUM-CONTR , :PROPSSVD-COD-CORRESP-BANC :VIND-COD-CORRESP , :PROPSSVD-NUM-PRAZO-FIN :VIND-NUM-PRAZO , :PROPSSVD-COD-OPER-CREDITO :VIND-COD-OPER-CRED , :DCLPROPOSTA-FIDELIZ.PROPOFID-OPCAO-COBER , :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PLANO , :DCLPROP-SASSE-VIDA.PROPSSVD-COD-USUARIO , :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF, :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA , :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-SICOB , :DCLPROPOSTA-FIDELIZ.PROPOFID-DATA-PROPOSTA , :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PRODUTO-SIVPF , :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-EMPRESA-SIVPF , :DCLPROPOSTA-FIDELIZ.PROPOFID-AGECOBR , :DCLPROPOSTA-FIDELIZ.PROPOFID-DIA-DEBITO , :DCLPROPOSTA-FIDELIZ.PROPOFID-OPCAOPAG , :DCLPROPOSTA-FIDELIZ.PROPOFID-AGECTADEB , :DCLPROPOSTA-FIDELIZ.PROPOFID-OPRCTADEB , :DCLPROPOSTA-FIDELIZ.PROPOFID-NUMCTADEB , :DCLPROPOSTA-FIDELIZ.PROPOFID-DIGCTADEB , :DCLPROPOSTA-FIDELIZ.PROPOFID-PERC-DESCONTO , :DCLPROPOSTA-FIDELIZ.PROPOFID-NRMATRVEN , :DCLPROPOSTA-FIDELIZ.PROPOFID-AGECTAVEN , :DCLPROPOSTA-FIDELIZ.PROPOFID-OPRCTAVEN , :DCLPROPOSTA-FIDELIZ.PROPOFID-NUMCTAVEN , :DCLPROPOSTA-FIDELIZ.PROPOFID-DIGCTAVEN , :DCLPROPOSTA-FIDELIZ.PROPOFID-CGC-CONVENENTE , :DCLPROPOSTA-FIDELIZ.PROPOFID-NOME-CONVENENTE , :DCLPROPOSTA-FIDELIZ.PROPOFID-NRMATRCON , :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO , :DCLPROPOSTA-FIDELIZ.PROPOFID-VAL-PAGO , :DCLPROPOSTA-FIDELIZ.PROPOFID-AGEPGTO , :DCLPROPOSTA-FIDELIZ.PROPOFID-VAL-TARIFA , :DCLPROPOSTA-FIDELIZ.PROPOFID-VAL-IOF , :DCLPROPOSTA-FIDELIZ.PROPOFID-DATA-CREDITO , :DCLPROPOSTA-FIDELIZ.PROPOFID-VAL-COMISSAO , :DCLPROPOSTA-FIDELIZ.PROPOFID-SIT-PROPOSTA , :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-USUARIO , :DCLPROPOSTA-FIDELIZ.PROPOFID-CANAL-PROPOSTA , :DCLPROPOSTA-FIDELIZ.PROPOFID-NSAS-SIVPF , :DCLPROPOSTA-FIDELIZ.PROPOFID-ORIGEM-PROPOSTA , :DCLPROPOSTA-FIDELIZ.PROPOFID-TIMESTAMP , :DCLPROPOSTA-FIDELIZ.PROPOFID-NSL , :DCLPROPOSTA-FIDELIZ.PROPOFID-NSAC-SIVPF , :DCLPROPOSTA-FIDELIZ.PROPOFID-NOME-CONJUGE :VIND-NOME-CONJUGE , :DCLPROPOSTA-FIDELIZ.PROPOFID-DATA-NASC-CONJUGE :VIND-DATA-NASC-CONJUGE , :DCLPROPOSTA-FIDELIZ.PROPOFID-PROFISSAO-CONJUGE :VIND-PROFISSAO-CONJUGE , :DCLPROPOSTA-FIDELIZ.PROPOFID-FAIXA-RENDA-IND :VIND-RENDA-FIXA-IND , :DCLPROPOSTA-FIDELIZ.PROPOFID-FAIXA-RENDA-FAM :VIND-RENDA-FIXA-FAM , :DCLPRODUTOS-VG.PRODUVG-COD-PRODUTO , :DCLPRODUTOS-VG.PRODUVG-PERI-PAGAMENTO , :DCLPRODUTOS-VG.PRODUVG-DESCONTO-ADESAO , :DCLPRODUTOS-VG.PRODUVG-RAMO , :DCLPROPOSTA-FIDELIZ.PROPOFID-NRMATRCON END-EXEC. */

            if (CPROPOSTA.Fetch())
            {
                _.Move(CPROPOSTA.DCLPROP_SASSE_VIDA_PROPSSVD_NUM_APOLICE, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE);
                _.Move(CPROPOSTA.DCLPROP_SASSE_VIDA_PROPSSVD_COD_SUBGRUPO, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO);
                _.Move(CPROPOSTA.DCLPROP_SASSE_VIDA_PROPSSVD_NUM_IDENTIFICACAO, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_IDENTIFICACAO);
                _.Move(CPROPOSTA.DCLPROP_SASSE_VIDA_PROPSSVD_DPS_TITULAR, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_TITULAR);
                _.Move(CPROPOSTA.DCLPROP_SASSE_VIDA_PROPSSVD_DPS_CONJUGE, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_CONJUGE);
                _.Move(CPROPOSTA.DCLPROP_SASSE_VIDA_PROPSSVD_APOS_INVALIDEZ, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_APOS_INVALIDEZ);
                _.Move(CPROPOSTA.PROPSSVD_NUM_CONTR_VINCULO, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_CONTR_VINCULO);
                _.Move(CPROPOSTA.VIND_NUM_CONTR, VIND_NUM_CONTR);
                _.Move(CPROPOSTA.PROPSSVD_COD_CORRESP_BANC, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_CORRESP_BANC);
                _.Move(CPROPOSTA.VIND_COD_CORRESP, VIND_COD_CORRESP);
                _.Move(CPROPOSTA.PROPSSVD_NUM_PRAZO_FIN, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_PRAZO_FIN);
                _.Move(CPROPOSTA.VIND_NUM_PRAZO, VIND_NUM_PRAZO);
                _.Move(CPROPOSTA.PROPSSVD_COD_OPER_CREDITO, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_OPER_CREDITO);
                _.Move(CPROPOSTA.VIND_COD_OPER_CRED, VIND_COD_OPER_CRED);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_OPCAO_COBER, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PLANO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO);
                _.Move(CPROPOSTA.DCLPROP_SASSE_VIDA_PROPSSVD_COD_USUARIO, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_USUARIO);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_NUM_PROPOSTA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PESSOA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_NUM_SICOB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_DATA_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_COD_PRODUTO_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_COD_EMPRESA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_AGECOBR, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_DIA_DEBITO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIA_DEBITO);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_OPCAOPAG, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAOPAG);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_AGECTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTADEB);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_OPRCTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTADEB);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_NUMCTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTADEB);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_DIGCTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTADEB);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_PERC_DESCONTO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PERC_DESCONTO);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_NRMATRVEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_AGECTAVEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTAVEN);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_OPRCTAVEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTAVEN);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_NUMCTAVEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTAVEN);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_DIGCTAVEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTAVEN);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_CGC_CONVENENTE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CGC_CONVENENTE);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_NOME_CONVENENTE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NOME_CONVENENTE);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_NRMATRCON, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRCON);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_DTQITBCO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_PAGO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_AGEPGTO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGEPGTO);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_TARIFA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_TARIFA);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_IOF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_IOF);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_DATA_CREDITO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_CREDITO);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_VAL_COMISSAO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_COMISSAO);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_SIT_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_COD_USUARIO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_USUARIO);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_CANAL_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CANAL_PROPOSTA);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_NSAS_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAS_SIVPF);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_ORIGEM_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_TIMESTAMP, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_TIMESTAMP);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_NSL, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSL);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_NSAC_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAC_SIVPF);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_NOME_CONJUGE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NOME_CONJUGE);
                _.Move(CPROPOSTA.VIND_NOME_CONJUGE, VIND_NOME_CONJUGE);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_DATA_NASC_CONJUGE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_NASC_CONJUGE);
                _.Move(CPROPOSTA.VIND_DATA_NASC_CONJUGE, VIND_DATA_NASC_CONJUGE);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_PROFISSAO_CONJUGE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PROFISSAO_CONJUGE);
                _.Move(CPROPOSTA.VIND_PROFISSAO_CONJUGE, VIND_PROFISSAO_CONJUGE);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_FAIXA_RENDA_IND, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_IND);
                _.Move(CPROPOSTA.VIND_RENDA_FIXA_IND, VIND_RENDA_FIXA_IND);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_FAIXA_RENDA_FAM, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_FAM);
                _.Move(CPROPOSTA.VIND_RENDA_FIXA_FAM, VIND_RENDA_FIXA_FAM);
                _.Move(CPROPOSTA.DCLPRODUTOS_VG_PRODUVG_COD_PRODUTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO);
                _.Move(CPROPOSTA.DCLPRODUTOS_VG_PRODUVG_PERI_PAGAMENTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO);
                _.Move(CPROPOSTA.DCLPRODUTOS_VG_PRODUVG_DESCONTO_ADESAO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_DESCONTO_ADESAO);
                _.Move(CPROPOSTA.DCLPRODUTOS_VG_PRODUVG_RAMO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_RAMO);
                _.Move(CPROPOSTA.DCLPROPOSTA_FIDELIZ_PROPOFID_NRMATRCON, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRCON);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-PROPOSTA-DB-CLOSE-1 */
        public void R0910_00_FETCH_PROPOSTA_DB_CLOSE_1()
        {
            /*" -1827- EXEC SQL CLOSE CPROPOSTA END-EXEC */

            CPROPOSTA.Close();

        }

        [StopWatch]
        /*" R0910-CONTINUA */
        private void R0910_CONTINUA(bool isPerform = false)
        {
            /*" -1880- ADD 1 TO AC-L-MOVIMENTO AC-CONTROLE. */
            WORK_AREA.AC_L_MOVIMENTO.Value = WORK_AREA.AC_L_MOVIMENTO + 1;
            WORK_AREA.AC_CONTROLE.Value = WORK_AREA.AC_CONTROLE + 1;

            /*" -1881- IF VIND-RENDA-FIXA-IND LESS ZERO */

            if (VIND_RENDA_FIXA_IND < 00)
            {

                /*" -1884- MOVE SPACES TO PROPOFID-FAIXA-RENDA-IND OF DCLPROPOSTA-FIDELIZ. */
                _.Move("", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_IND);
            }


            /*" -1885- IF VIND-RENDA-FIXA-FAM LESS ZERO */

            if (VIND_RENDA_FIXA_FAM < 00)
            {

                /*" -1888- MOVE SPACES TO PROPOFID-FAIXA-RENDA-FAM OF DCLPROPOSTA-FIDELIZ. */
                _.Move("", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_FAM);
            }


            /*" -1889- IF AC-CONTROLE GREATER 99 */

            if (WORK_AREA.AC_CONTROLE > 99)
            {

                /*" -1890- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), WS_TIME);

                /*" -1895- MOVE WS-TIME-N TO WS-TIME-EDIT */
                _.Move(WS_TIME.WS_TIME_N, WS_TIME_EDIT);

                /*" -1897- MOVE ZEROS TO AC-CONTROLE. */
                _.Move(0, WORK_AREA.AC_CONTROLE);
            }


            /*" -1899- MOVE PROPSSVD-NUM-APOLICE OF DCLPROP-SASSE-VIDA TO WS-ATU-APOLICE. */
            _.Move(PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE, WORK_AREA.WS_CHAVE_ATU.WS_ATU_APOLICE);

            /*" -1902- MOVE PROPSSVD-NUM-APOLICE OF DCLPROP-SASSE-VIDA TO WS-ATU-SUBGRUPO. */
            _.Move(PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE, WORK_AREA.WS_CHAVE_ATU.WS_ATU_SUBGRUPO);

            /*" -1904- MOVE ZEROS TO W-NOVO-CALCULO. */
            _.Move(0, WORK_AREA.W_NOVO_CALCULO);

            /*" -1907- IF (PRODUVG-COD-PRODUTO EQUAL 7705 OR JVPRD7705 OR 7715 ) AND PROPOFID-OPCAO-COBER EQUAL SPACES */

            if ((PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.In("7705", JVBKINCL.JV_PRODUTOS.JVPRD7705.ToString(), "7715")) && PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER.IsEmpty())
            {

                /*" -1908- MOVE 1 TO W-NOVO-CALCULO */
                _.Move(1, WORK_AREA.W_NOVO_CALCULO);

                /*" -1908- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R0911-00-SELECT-RCAPS-SECTION */
        private void R0911_00_SELECT_RCAPS_SECTION()
        {
            /*" -1924- MOVE 'R0911-00-SELECT-RCAPS       ' TO PARAGRAFO. */
            _.Move("R0911-00-SELECT-RCAPS       ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1927- MOVE 'SELECT RCAPS FILTRO         ' TO COMANDO. */
            _.Move("SELECT RCAPS FILTRO         ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1929- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO RCAPS-NUM-CERTIFICADO. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO);

            /*" -1931- IF WHOST-PRODUTO-SIVPF = 7708 AND WHOST-NRMATRVEN(1:3) = 756 */

            if (WHOST_PRODUTO_SIVPF == 7708 && WHOST_NRMATRVEN.Substring(1, 3) == 756)
            {

                /*" -1935- MOVE PROPOFID-NRMATRVEN TO RCAPS-NUM-CERTIFICADO. */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN, RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO);
            }


            /*" -1942- PERFORM R0911_00_SELECT_RCAPS_DB_SELECT_1 */

            R0911_00_SELECT_RCAPS_DB_SELECT_1();

            /*" -1944- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1945- DISPLAY 'PROBLEMAS NO SELECT DA RCAPS            ' */
                _.Display($"PROBLEMAS NO SELECT DA RCAPS            ");

                /*" -1946- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0911-00-SELECT-RCAPS-DB-SELECT-1 */
        public void R0911_00_SELECT_RCAPS_DB_SELECT_1()
        {
            /*" -1942- EXEC SQL SELECT NOME_SEGURADO, AGE_COBRANCA INTO :RCAPS-NOME-SEGURADO, :RCAPS-AGE-COBRANCA FROM SEGUROS.RCAPS WHERE NUM_CERTIFICADO = :RCAPS-NUM-CERTIFICADO END-EXEC. */

            var r0911_00_SELECT_RCAPS_DB_SELECT_1_Query1 = new R0911_00_SELECT_RCAPS_DB_SELECT_1_Query1()
            {
                RCAPS_NUM_CERTIFICADO = RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0911_00_SELECT_RCAPS_DB_SELECT_1_Query1.Execute(r0911_00_SELECT_RCAPS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPS_NOME_SEGURADO, RCAPS.DCLRCAPS.RCAPS_NOME_SEGURADO);
                _.Move(executed_1.RCAPS_AGE_COBRANCA, RCAPS.DCLRCAPS.RCAPS_AGE_COBRANCA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0911_99_SAIDA*/

        [StopWatch]
        /*" R0913-00-UPDATE-PROPOFID-SECTION */
        private void R0913_00_UPDATE_PROPOFID_SECTION()
        {
            /*" -1957- MOVE 'R0913-00-UPDATE-PROPOFID    ' TO PARAGRAFO. */
            _.Move("R0913-00-UPDATE-PROPOFID    ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1960- MOVE 'UPDATE PROPOFID R0913       ' TO COMANDO. */
            _.Move("UPDATE PROPOFID R0913       ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1965- PERFORM R0913_00_UPDATE_PROPOFID_DB_UPDATE_1 */

            R0913_00_UPDATE_PROPOFID_DB_UPDATE_1();

            /*" -1968- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1970- DISPLAY 'PROBLEMAS NO UPDATE DA PROPFID  - R0913  ' SQLCODE */
                _.Display($"PROBLEMAS NO UPDATE DA PROPFID  - R0913  {DB.SQLCODE}");

                /*" -1970- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0913-00-UPDATE-PROPOFID-DB-UPDATE-1 */
        public void R0913_00_UPDATE_PROPOFID_DB_UPDATE_1()
        {
            /*" -1965- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET AGECOBR =:DCLPROPOSTA-FIDELIZ.PROPOFID-AGECOBR WHERE NUM_PROPOSTA_SIVPF = :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF END-EXEC. */

            var r0913_00_UPDATE_PROPOFID_DB_UPDATE_1_Update1 = new R0913_00_UPDATE_PROPOFID_DB_UPDATE_1_Update1()
            {
                PROPOFID_AGECOBR = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR.ToString(),
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            R0913_00_UPDATE_PROPOFID_DB_UPDATE_1_Update1.Execute(r0913_00_UPDATE_PROPOFID_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0913_99_SAIDA*/

        [StopWatch]
        /*" R0914-00-UPDATE-AGE-PGTO-SECTION */
        private void R0914_00_UPDATE_AGE_PGTO_SECTION()
        {
            /*" -1978- MOVE 'R0914-00-UPDATE-AGE-PGTO    ' TO PARAGRAFO. */
            _.Move("R0914-00-UPDATE-AGE-PGTO    ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1981- MOVE 'UPDATE AGE PGTO R0914       ' TO COMANDO. */
            _.Move("UPDATE AGE PGTO R0914       ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1986- PERFORM R0914_00_UPDATE_AGE_PGTO_DB_UPDATE_1 */

            R0914_00_UPDATE_AGE_PGTO_DB_UPDATE_1();

            /*" -1989- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1991- DISPLAY 'PROBLEMAS NO UPDATE DA PROPFID  - R0914  ' SQLCODE */
                _.Display($"PROBLEMAS NO UPDATE DA PROPFID  - R0914  {DB.SQLCODE}");

                /*" -1991- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0914-00-UPDATE-AGE-PGTO-DB-UPDATE-1 */
        public void R0914_00_UPDATE_AGE_PGTO_DB_UPDATE_1()
        {
            /*" -1986- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET AGEPGTO =:DCLPROPOSTA-FIDELIZ.PROPOFID-AGEPGTO WHERE NUM_PROPOSTA_SIVPF = :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF END-EXEC. */

            var r0914_00_UPDATE_AGE_PGTO_DB_UPDATE_1_Update1 = new R0914_00_UPDATE_AGE_PGTO_DB_UPDATE_1_Update1()
            {
                PROPOFID_AGEPGTO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGEPGTO.ToString(),
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            R0914_00_UPDATE_AGE_PGTO_DB_UPDATE_1_Update1.Execute(r0914_00_UPDATE_AGE_PGTO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0914_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -2001- MOVE 'R1000-00-PROCESSA-REGISTRO  ' TO PARAGRAFO. */
            _.Move("R1000-00-PROCESSA-REGISTRO  ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2003- MOVE ZERO TO W-COBRANCA. */
            _.Move(0, WORK_AREA.W_COBRANCA);

            /*" -2005- MOVE 'NAO' TO WS-TEM-ERRO-1852. */
            _.Move("NAO", WORK_AREA.WS_TEM_ERRO_1852);

            /*" -2007- PERFORM R2203-00-SELECT-CONDITEC. */

            R2203_00_SELECT_CONDITEC_SECTION();

            /*" -2009- PERFORM R2205-00-SELECT-HISTCOBVA. */

            R2205_00_SELECT_HISTCOBVA_SECTION();

            /*" -2013- MOVE ZEROS TO WS-TEM-ERRO. */
            _.Move(0, WORK_AREA.WS_TEM_ERRO);

            /*" -2015- PERFORM R2200-00-SELECT-PESSOA. */

            R2200_00_SELECT_PESSOA_SECTION();

            /*" -2017- IF PRODUVG-COD-PRODUTO = 7725 OR JVPRD7725 OR 7733 OR JVPRD7733 */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.In("7725", JVBKINCL.JV_PRODUTOS.JVPRD7725.ToString(), "7733", JVBKINCL.JV_PRODUTOS.JVPRD7733.ToString()))
            {

                /*" -2018- PERFORM R2212-00-SELECT-PESSOA-JURID */

                R2212_00_SELECT_PESSOA_JURID_SECTION();

                /*" -2019- ELSE */
            }
            else
            {


                /*" -2020- PERFORM R2210-00-SELECT-PESSOA-FISICA */

                R2210_00_SELECT_PESSOA_FISICA_SECTION();

                /*" -2022- END-IF */
            }


            /*" -2023- PERFORM R2215-00-SELECT-PROPOVA. */

            R2215_00_SELECT_PROPOVA_SECTION();

            /*" -2024- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2025- PERFORM R2220-00-OBTER-ENDERECO-CORRES */

                R2220_00_OBTER_ENDERECO_CORRES_SECTION();

                /*" -2026- ELSE */
            }
            else
            {


                /*" -2027- PERFORM R2222-00-OBTER-ENDERECO-CORRES */

                R2222_00_OBTER_ENDERECO_CORRES_SECTION();

                /*" -2028- END-IF. */
            }


            /*" -2029- IF END-CORRES-N-CADASTRADO */

            if (WORK_AREA.W_ENDERECO["END_CORRES_N_CADASTRADO"])
            {

                /*" -2031- PERFORM R2225-00-OBTER-DEMAIS-ENDERECO */

                R2225_00_OBTER_DEMAIS_ENDERECO_SECTION();

                /*" -2032- IF DEMAIS-END-N-CADASTRADO */

                if (WORK_AREA.W_ENDERECO["DEMAIS_END_N_CADASTRADO"])
                {

                    /*" -2034- IF PRODUVG-COD-PRODUTO OF DCLPRODUTOS-VG NOT EQUAL 7708 */

                    if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO != 7708)
                    {

                        /*" -2035- MOVE 501 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                        _.Move(501, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                        /*" -2037- PERFORM R1100-00-INSERT-ERROSPROPVA. */

                        R1100_00_INSERT_ERROSPROPVA_SECTION();
                    }

                }

            }


            /*" -2039- PERFORM R2230-00-SELECT-PESSOA-FONE. */

            R2230_00_SELECT_PESSOA_FONE_SECTION();

            /*" -2043- IF WHOST-DDD = ZEROS AND WHOST-FONE = ZEROS AND WHOST-FAX = ZEROS AND WHOST-TELEX = ZEROS */

            if (WHOST_DDD == 00 && WHOST_FONE == 00 && WHOST_FAX == 00 && WHOST_TELEX == 00)
            {

                /*" -2044- PERFORM R2232-00-SELECT-PESSOA-FONE */

                R2232_00_SELECT_PESSOA_FONE_SECTION();

                /*" -2045- ELSE */
            }
            else
            {


                /*" -2046- PERFORM R2235-00-UPDATE-PESSOA-FONE */

                R2235_00_UPDATE_PESSOA_FONE_SECTION();

                /*" -2048- END-IF. */
            }


            /*" -2050- PERFORM R2236-00-SELECT-PESSOA-EMAIL. */

            R2236_00_SELECT_PESSOA_EMAIL_SECTION();

            /*" -2054- PERFORM R2240-00-SELECT-PROPFIDC. */

            R2240_00_SELECT_PROPFIDC_SECTION();

            /*" -2055- PERFORM R2300-00-TRATA-CLIENTES. */

            R2300_00_TRATA_CLIENTES_SECTION();

            /*" -2056- IF CLIENTE-ERRO */

            if (WORK_AREA.W_TRATA_CLIENTE["CLIENTE_ERRO"])
            {

                /*" -2061- GO TO R1000-10-SAIDA. */

                R1000_10_SAIDA(); //GOTO
                return;
            }


            /*" -2071- IF CPF OF DCLPESSOA-FISICA = 11111111111 OR 22222222222 OR 33333333333 OR 44444444444 OR 55555555555 OR 66666666666 OR 77777777777 OR 88888888888 OR 99999999999 */

            if (PESFIS.DCLPESSOA_FISICA.CPF.In("11111111111", "22222222222", "33333333333", "44444444444", "55555555555", "66666666666", "77777777777", "88888888888", "99999999999"))
            {

                /*" -2072- MOVE 402 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(402, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -2073- PERFORM R1100-00-INSERT-ERROSPROPVA */

                R1100_00_INSERT_ERROSPROPVA_SECTION();

                /*" -2074- ELSE */
            }
            else
            {


                /*" -2086- IF CPF OF DCLPESSOA-FISICA = 000000000000000 OR 000000000000091 OR 000000000000101 OR 000000000000191 OR 000000000001910 OR 000000000019100 OR 000001910000000 OR 000009100000000 OR 000010000000000 OR 000011000000000 OR 000011111111111 OR 000017500000000 OR 000019100000000 OR 000020000000000 OR 000022222222222 OR 000030000000000 OR 000040000000000 OR 000050000000000 OR 000060000000000 OR 000070000000000 OR 000080000000000 OR 000090000000000 OR 000099000000000 OR 000099900000000 OR 000099990000000 OR 000099999000000 OR 000099999964001 OR 000099999999990 OR 000099999999999 OR 099999999999999 OR 000360306000104 OR 034020354000110 */

                if (PESFIS.DCLPESSOA_FISICA.CPF.In("000000000000000", "000000000000091", "000000000000101", "000000000000191", "000000000001910", "000000000019100", "000001910000000", "000009100000000", "000010000000000", "000011000000000", "000011111111111", "000017500000000", "000019100000000", "000020000000000", "000022222222222", "000030000000000", "000040000000000", "000050000000000", "000060000000000", "000070000000000", "000080000000000", "000090000000000", "000099000000000", "000099900000000", "000099990000000", "000099999000000", "000099999964001", "000099999999990", "000099999999999", "099999999999999", "000360306000104", "034020354000110"))
                {

                    /*" -2087- MOVE 402 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                    _.Move(402, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                    /*" -2088- PERFORM R1100-00-INSERT-ERROSPROPVA */

                    R1100_00_INSERT_ERROSPROPVA_SECTION();

                    /*" -2089- ELSE */
                }
                else
                {


                    /*" -2090- IF CPF OF DCLPESSOA-FISICA LESS 100000 */

                    if (PESFIS.DCLPESSOA_FISICA.CPF < 100000)
                    {

                        /*" -2091- MOVE 402 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                        _.Move(402, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                        /*" -2092- PERFORM R1100-00-INSERT-ERROSPROPVA */

                        R1100_00_INSERT_ERROSPROPVA_SECTION();

                        /*" -2093- END-IF */
                    }


                    /*" -2094- END-IF */
                }


                /*" -2098- END-IF. */
            }


            /*" -2100- IF PROPOFID-COD-PRODUTO-SIVPF = 77 NEXT SENTENCE */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 77)
            {

                /*" -2101- ELSE */
            }
            else
            {


                /*" -2102- PERFORM R2350-00-TRATA-ERRO-1864 */

                R2350_00_TRATA_ERRO_1864_SECTION();

                /*" -2106- END-IF. */
            }


            /*" -2109- IF PRODUVG-COD-PRODUTO NOT = 7705 AND JVPRD7705 AND 7707 AND 7708 AND 7715 */

            if (!PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.In("7705", JVBKINCL.JV_PRODUTOS.JVPRD7705.ToString(), "7707", "7708", "7715"))
            {

                /*" -2110- IF PROPSSVD-APOS-INVALIDEZ EQUAL 'N' */

                if (PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_APOS_INVALIDEZ == "N")
                {

                    /*" -2111- IF COD-CBO OF DCLPESSOA-FISICA GREATER ZEROS */

                    if (PESFIS.DCLPESSOA_FISICA.COD_CBO > 00)
                    {

                        /*" -2113- IF TAB-DESCR-CBO-C(COD-CBO OF DCLPESSOA-FISICA)(1:5) EQUAL 'APOSE' */

                        if (TAB_CBO1.TAB_CBO.FILLER_27[PESFIS.DCLPESSOA_FISICA.COD_CBO].TAB_DESCR_CBO_C.Substring(1, 5) == "APOSE")
                        {

                            /*" -2114- MOVE 1801 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                            _.Move(1801, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                            /*" -2115- PERFORM R1100-00-INSERT-ERROSPROPVA */

                            R1100_00_INSERT_ERROSPROPVA_SECTION();

                            /*" -2116- END-IF */
                        }


                        /*" -2117- END-IF */
                    }


                    /*" -2118- END-IF */
                }


                /*" -2120- END-IF */
            }


            /*" -2123- IF PROPSSVD-APOS-INVALIDEZ = 'S' AND (PRODUVG-COD-PRODUTO = 7705 OR JVPRD7705 OR 7715 ) */

            if (PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_APOS_INVALIDEZ == "S" && (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.In("7705", JVBKINCL.JV_PRODUTOS.JVPRD7705.ToString(), "7715")))
            {

                /*" -2124- MOVE 1870 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1870, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -2125- PERFORM R1100-00-INSERT-ERROSPROPVA */

                R1100_00_INSERT_ERROSPROPVA_SECTION();

                /*" -2127- END-IF */
            }


            /*" -2129- MOVE 'NAO' TO WS-TEM-ERRO-1807 */
            _.Move("NAO", WORK_AREA.WS_TEM_ERRO_1807);

            /*" -2131- IF PROPSSVD-APOS-INVALIDEZ OF DCLPROP-SASSE-VIDA = 'S' AND PRODUVG-COD-PRODUTO OF DCLPRODUTOS-VG EQUAL 7713 */

            if (PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_APOS_INVALIDEZ == "S" && PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO == 7713)
            {

                /*" -2132- MOVE 1807 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1807, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -2133- PERFORM R1100-00-INSERT-ERROSPROPVA */

                R1100_00_INSERT_ERROSPROPVA_SECTION();

                /*" -2135- END-IF. */
            }


            /*" -2138- IF PROPSSVD-APOS-INVALIDEZ = 'S' AND (PRODUVG-COD-PRODUTO NOT = 7705 AND JVPRD7705 AND 7707 AND 7713 ) */

            if (PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_APOS_INVALIDEZ == "S" && (!PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.In("7705", JVBKINCL.JV_PRODUTOS.JVPRD7705.ToString(), "7707", "7713")))
            {

                /*" -2139- MOVE 1807 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1807, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -2140- PERFORM R1100-00-INSERT-ERROSPROPVA */

                R1100_00_INSERT_ERROSPROPVA_SECTION();

                /*" -2141- MOVE 'SIM' TO WS-TEM-ERRO-1807 */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_1807);

                /*" -2142- PERFORM R3700-00-INSERT-RELATORIOS */

                R3700_00_INSERT_RELATORIOS_SECTION();

                /*" -2151- END-IF */
            }


            /*" -2152- IF PROPSSVD-DPS-TITULAR(2:1) = 'S' */

            if (PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_TITULAR.Substring(2, 1) == "S")
            {

                /*" -2153- MOVE 1807 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1807, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -2154- PERFORM R1100-00-INSERT-ERROSPROPVA */

                R1100_00_INSERT_ERROSPROPVA_SECTION();

                /*" -2156- IF PRODUVG-COD-PRODUTO NOT = 7705 AND JVPRD7705 AND 7707 AND 7715 */

                if (!PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.In("7705", JVBKINCL.JV_PRODUTOS.JVPRD7705.ToString(), "7707", "7715"))
                {

                    /*" -2157- MOVE 'SIM' TO WS-TEM-ERRO-1807 */
                    _.Move("SIM", WORK_AREA.WS_TEM_ERRO_1807);

                    /*" -2158- PERFORM R3700-00-INSERT-RELATORIOS */

                    R3700_00_INSERT_RELATORIOS_SECTION();

                    /*" -2159- END-IF */
                }


                /*" -2166- END-IF. */
            }


            /*" -2168- IF PRODUVG-COD-PRODUTO OF DCLPRODUTOS-VG EQUAL 9703 OR 9705 */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.In("9703", "9705"))
            {

                /*" -2176- GO TO R1000-CONSISTE-DPS. */

                R1000_CONSISTE_DPS(); //GOTO
                return;
            }


            /*" -2177- IF PROPOFID-COD-PRODUTO-SIVPF = 7 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 7)
            {

                /*" -2184- GO TO R1000-CONSISTE-CX-TRAB. */

                R1000_CONSISTE_CX_TRAB(); //GOTO
                return;
            }


            /*" -2185- IF PROPOFID-COD-PRODUTO-SIVPF = 77 OR 7708 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF.In("77", "7708"))
            {

                /*" -2186- PERFORM R5634-00-SELECT-SEGUROS-PF-CBO */

                R5634_00_SELECT_SEGUROS_PF_CBO_SECTION();

                /*" -2193- GO TO R1000-CONSISTE-CX-TRAB. */

                R1000_CONSISTE_CX_TRAB(); //GOTO
                return;
            }


            /*" -2197- IF PROPSSVD-NUM-APOLICE = 0109300001391 OR 0109300001392 OR 0109300001394 OR 0109300000598 */

            if (PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.In("0109300001391", "0109300001392", "0109300001394", "0109300000598"))
            {

                /*" -2198- GO TO R1000-CONSISTE-CX-TRAB */

                R1000_CONSISTE_CX_TRAB(); //GOTO
                return;

                /*" -2200- END-IF */
            }


            /*" -2201- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 46 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 46)
            {

                /*" -2202- IF PROPOFID-DATA-PROPOSTA >= '2008-04-17' */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA >= "2008-04-17")
                {

                    /*" -2203- INITIALIZE WHOST-IMPMORNATU */
                    _.Initialize(
                        WHOST_IMPMORNATU
                    );

                    /*" -2204- PERFORM R1401-00-SELECT-PLANOS-VA */

                    R1401_00_SELECT_PLANOS_VA_SECTION();

                    /*" -2205- IF WHOST-IMPMORNATU <= 30000,00 */

                    if (WHOST_IMPMORNATU <= 30000.00)
                    {

                        /*" -2206- GO TO R1000-CONSISTE-CX-TRAB */

                        R1000_CONSISTE_CX_TRAB(); //GOTO
                        return;

                        /*" -2207- END-IF */
                    }


                    /*" -2208- END-IF */
                }


                /*" -2223- END-IF */
            }


            /*" -2225- PERFORM R5634-00-SELECT-SEGUROS-PF-CBO. */

            R5634_00_SELECT_SEGUROS_PF_CBO_SECTION();

            /*" -2227- IF COD-CBO OF DCLPESSOA-FISICA EQUAL ZEROS AND WHOST-PROFISSAO EQUAL SPACES */

            if (PESFIS.DCLPESSOA_FISICA.COD_CBO == 00 && WHOST_PROFISSAO.IsEmpty())
            {

                /*" -2228- MOVE 1811 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1811, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -2229- PERFORM R1100-00-INSERT-ERROSPROPVA */

                R1100_00_INSERT_ERROSPROPVA_SECTION();

                /*" -2230- ELSE */
            }
            else
            {


                /*" -2231- IF WHOST-PROFISSAO EQUAL SPACES */

                if (WHOST_PROFISSAO.IsEmpty())
                {

                    /*" -2233- IF COD-CBO OF DCLPESSOA-FISICA > ZEROS AND COD-CBO OF DCLPESSOA-FISICA < 1000 */

                    if (PESFIS.DCLPESSOA_FISICA.COD_CBO > 00 && PESFIS.DCLPESSOA_FISICA.COD_CBO < 1000)
                    {

                        /*" -2235- MOVE TAB-DESCR-CBO-C (COD-CBO OF DCLPESSOA-FISICA) TO WHOST-PROFISSAO */
                        _.Move(TAB_CBO1.TAB_CBO.FILLER_27[PESFIS.DCLPESSOA_FISICA.COD_CBO].TAB_DESCR_CBO_C, WHOST_PROFISSAO);

                        /*" -2239- ELSE */
                    }
                    else
                    {


                        /*" -2240- MOVE SPACES TO WHOST-PROFISSAO */
                        _.Move("", WHOST_PROFISSAO);

                        /*" -2241- MOVE 1811 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                        _.Move(1811, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                        /*" -2242- PERFORM R1100-00-INSERT-ERROSPROPVA */

                        R1100_00_INSERT_ERROSPROPVA_SECTION();

                        /*" -2243- END-IF */
                    }


                    /*" -2263- IF WHOST-PROFISSAO(1:5) EQUAL 'POLIC' OR 'DELEG' OR 'MILIT' OR 'VIGIA' OR 'VIGIL' OR 'SEGUR' OR 'PILOT' OR 'INSTR' OR 'PARAQ' OR 'MOTOB' OR 'MOTOC' OR 'MOTOQ' OR 'MERGU' OR 'ALPIN' OR 'AGENT' OR 'PERIT' OR 'SERVE' OR 'APOSE' OR 'OUTRO' */

                    if (WHOST_PROFISSAO.Substring(1, 5).In("POLIC", "DELEG", "MILIT", "VIGIA", "VIGIL", "SEGUR", "PILOT", "INSTR", "PARAQ", "MOTOB", "MOTOC", "MOTOQ", "MERGU", "ALPIN", "AGENT", "PERIT", "SERVE", "APOSE", "OUTRO"))
                    {

                        /*" -2264- MOVE 1802 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                        _.Move(1802, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                        /*" -2265- PERFORM R1100-00-INSERT-ERROSPROPVA */

                        R1100_00_INSERT_ERROSPROPVA_SECTION();

                        /*" -2266- END-IF */
                    }


                    /*" -2267- ELSE */
                }
                else
                {


                    /*" -2287- IF WHOST-PROFISSAO(1:5) EQUAL 'POLIC' OR 'DELEG' OR 'MILIT' OR 'VIGIA' OR 'VIGIL' OR 'SEGUR' OR 'PILOT' OR 'INSTR' OR 'PARAQ' OR 'MOTOB' OR 'MOTOC' OR 'MOTOQ' OR 'MERGU' OR 'ALPIN' OR 'AGENT' OR 'PERIT' OR 'SERVE' OR 'APOSE' OR 'OUTRO' */

                    if (WHOST_PROFISSAO.Substring(1, 5).In("POLIC", "DELEG", "MILIT", "VIGIA", "VIGIL", "SEGUR", "PILOT", "INSTR", "PARAQ", "MOTOB", "MOTOC", "MOTOQ", "MERGU", "ALPIN", "AGENT", "PERIT", "SERVE", "APOSE", "OUTRO"))
                    {

                        /*" -2288- MOVE 1802 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                        _.Move(1802, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                        /*" -2288- PERFORM R1100-00-INSERT-ERROSPROPVA. */

                        R1100_00_INSERT_ERROSPROPVA_SECTION();
                    }

                }

            }


            /*" -0- FLUXCONTROL_PERFORM R1000_CONSISTE_DPS */

            R1000_CONSISTE_DPS();

        }

        [StopWatch]
        /*" R1000-CONSISTE-DPS */
        private void R1000_CONSISTE_DPS(bool isPerform = false)
        {
            /*" -2302- IF PROPOFID-COD-PRODUTO-SIVPF = 77 OR 7708 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF.In("77", "7708"))
            {

                /*" -2303- DISPLAY '--------------------------------' */
                _.Display($"--------------------------------");

                /*" -2304- DISPLAY 'ERRO: CONSISTENCIA INDEVIDA DPS ' */
                _.Display($"ERRO: CONSISTENCIA INDEVIDA DPS ");

                /*" -2305- DISPLAY 'ERRO: ' PROPOFID-NUM-PROPOSTA-SIVPF */
                _.Display($"ERRO: {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -2306- DISPLAY '--------------------------------' */
                _.Display($"--------------------------------");

                /*" -2309- GO TO R1000-CONSISTE-CX-TRAB. */

                R1000_CONSISTE_CX_TRAB(); //GOTO
                return;
            }


            /*" -2310- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 7 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 7)
            {

                /*" -2312- IF PROPOFID-DATA-PROPOSTA OF DCLPROPOSTA-FIDELIZ >= '2008-04-17' */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA >= "2008-04-17")
                {

                    /*" -2315- GO TO R1000-CONSISTE-CX-TRAB. */

                    R1000_CONSISTE_CX_TRAB(); //GOTO
                    return;
                }

            }


            /*" -2316- IF PROPOFID-COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ = 46 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 46)
            {

                /*" -2318- IF PROPOFID-DATA-PROPOSTA OF DCLPROPOSTA-FIDELIZ < '2006-07-01' */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA < "2006-07-01")
                {

                    /*" -2321- IF PROPSSVD-DPS-TITULAR OF DCLPROP-SASSE-VIDA EQUAL 'NSNNNNNNNNNNNNNNNNNNNNNNN' NEXT SENTENCE */

                    if (PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_TITULAR == "NSNNNNNNNNNNNNNNNNNNNNNNN")
                    {

                        /*" -2322- ELSE */
                    }
                    else
                    {


                        /*" -2323- MOVE 1803 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                        _.Move(1803, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                        /*" -2324- PERFORM R1100-00-INSERT-ERROSPROPVA */

                        R1100_00_INSERT_ERROSPROPVA_SECTION();

                        /*" -2325- ELSE */
                    }

                }
                else
                {


                    /*" -2328- IF PROPSSVD-DPS-TITULAR OF DCLPROP-SASSE-VIDA EQUAL 'SNNNNNNNNNNNNNNNNNNNNNNNN' NEXT SENTENCE */

                    if (PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_TITULAR == "SNNNNNNNNNNNNNNNNNNNNNNNN")
                    {

                        /*" -2329- ELSE */
                    }
                    else
                    {


                        /*" -2330- MOVE 1803 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                        _.Move(1803, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                        /*" -2331- PERFORM R1100-00-INSERT-ERROSPROPVA */

                        R1100_00_INSERT_ERROSPROPVA_SECTION();

                        /*" -2332- ELSE */
                    }

                }

            }
            else
            {


                /*" -2340- IF PROPSSVD-DPS-TITULAR OF DCLPROP-SASSE-VIDA NOT EQUAL 'SNNNNNN' AND PROPSSVD-DPS-TITULAR OF DCLPROP-SASSE-VIDA NOT EQUAL 'SNNNNNS' AND PROPSSVD-DPS-TITULAR OF DCLPROP-SASSE-VIDA NOT EQUAL 'SNNNNN ' AND PROPSSVD-DPS-TITULAR OF DCLPROP-SASSE-VIDA NOT EQUAL 'SNNNNS ' */

                if (PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_TITULAR != "SNNNNNN" && PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_TITULAR != "SNNNNNS" && PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_TITULAR != "SNNNNN " && PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_TITULAR != "SNNNNS ")
                {

                    /*" -2341- MOVE 1803 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                    _.Move(1803, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                    /*" -2352- PERFORM R1100-00-INSERT-ERROSPROPVA. */

                    R1100_00_INSERT_ERROSPROPVA_SECTION();
                }

            }


            /*" -2353- IF CONDITEC-CARREGA-CONJUGE NOT EQUAL ZEROS */

            if (CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE != 00)
            {

                /*" -2354- IF PROPOFID-COD-PRODUTO-SIVPF NOT EQUAL 46 */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF != 46)
                {

                    /*" -2362- IF PROPSSVD-DPS-CONJUGE OF DCLPROP-SASSE-VIDA NOT EQUAL 'SNNNNNN' AND PROPSSVD-DPS-CONJUGE OF DCLPROP-SASSE-VIDA NOT EQUAL 'SNNNNNS' AND PROPSSVD-DPS-CONJUGE OF DCLPROP-SASSE-VIDA NOT EQUAL 'SNNNNN ' AND PROPSSVD-DPS-CONJUGE OF DCLPROP-SASSE-VIDA NOT EQUAL 'SNNNNS ' */

                    if (PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_CONJUGE != "SNNNNNN" && PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_CONJUGE != "SNNNNNS" && PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_CONJUGE != "SNNNNN " && PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_CONJUGE != "SNNNNS ")
                    {

                        /*" -2363- MOVE 1804 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                        _.Move(1804, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                        /*" -2369- PERFORM R1100-00-INSERT-ERROSPROPVA. */

                        R1100_00_INSERT_ERROSPROPVA_SECTION();
                    }

                }

            }


            /*" -2370- IF CONDITEC-CARREGA-CONJUGE NOT EQUAL ZEROS */

            if (CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE != 00)
            {

                /*" -2371- IF PROPOFID-COD-PRODUTO-SIVPF NOT EQUAL 46 */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF != 46)
                {

                    /*" -2373- IF PROPOFID-NOME-CONJUGE OF DCLPROPOSTA-FIDELIZ NOT EQUAL SPACES */

                    if (!PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NOME_CONJUGE.IsEmpty())
                    {

                        /*" -2375- IF PROPSSVD-DPS-CONJUGE OF DCLPROP-SASSE-VIDA EQUAL SPACES */

                        if (PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_CONJUGE.IsEmpty())
                        {

                            /*" -2376- MOVE 1806 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                            _.Move(1806, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                            /*" -2376- PERFORM R1100-00-INSERT-ERROSPROPVA. */

                            R1100_00_INSERT_ERROSPROPVA_SECTION();
                        }

                    }

                }

            }


        }

        [StopWatch]
        /*" R1000-CONSISTE-CX-TRAB */
        private void R1000_CONSISTE_CX_TRAB(bool isPerform = false)
        {
            /*" -2385- MOVE 'R1000-00-CONSISTE-CX-TRAB   ' TO PARAGRAFO. */
            _.Move("R1000-00-CONSISTE-CX-TRAB   ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2389- IF PROPOFID-CGC-CONVENENTE OF DCLPROPOSTA-FIDELIZ NOT EQUAL ZEROS AND PRODUVG-DESCONTO-ADESAO OF DCLPRODUTOS-VG GREATER ZEROS */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CGC_CONVENENTE != 00 && PRODUVG.DCLPRODUTOS_VG.PRODUVG_DESCONTO_ADESAO > 00)
            {

                /*" -2390- MOVE ZEROS TO VIND-CGC-CONVENENTE */
                _.Move(0, VIND_CGC_CONVENENTE);

                /*" -2391- PERFORM R1200-00-SELECT-ESTIPULANTE */

                R1200_00_SELECT_ESTIPULANTE_SECTION();

                /*" -2392- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2393- MOVE 1702 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                    _.Move(1702, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                    /*" -2394- PERFORM R1100-00-INSERT-ERROSPROPVA */

                    R1100_00_INSERT_ERROSPROPVA_SECTION();

                    /*" -2395- END-IF */
                }


                /*" -2396- ELSE */
            }
            else
            {


                /*" -2401- MOVE -1 TO VIND-CGC-CONVENENTE. */
                _.Move(-1, VIND_CGC_CONVENENTE);
            }


            /*" -2405- MOVE PROPOFID-NRMATRVEN OF DCLPROPOSTA-FIDELIZ TO LPARM01 W-NRMATRICULA WS-NRMATRVEN. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN, LPARM01, W_NRMATRICULA, WS_NRMATRVEN);

            /*" -2408- CALL 'PRODIGCX' USING LPARM01, LPARM03. */
            _.Call("PRODIGCX", LPARM01, LPARM03);

            /*" -2410- IF LPARM01 EQUAL ALL '9' AND WS-NRMATRVEN NOT EQUAL ALL '9' */

            if (LPARM01.All("9") && !WS_NRMATRVEN.All("9"))
            {

                /*" -2411- DISPLAY '*----------------------------------------------*' */
                _.Display($"*----------------------------------------------*");

                /*" -2412- DISPLAY '* VP0601B - PROBLEMAS CALL SUBROTINA PRODIGCX  *' */
                _.Display($"* VP0601B - PROBLEMAS CALL SUBROTINA PRODIGCX  *");

                /*" -2414- DISPLAY '* NUM_PROPOSTA_SIVPF = ' PROPOFID-NUM-PROPOSTA-SIVPF */
                _.Display($"* NUM_PROPOSTA_SIVPF = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -2415- DISPLAY '* NRMATRVEN          = ' PROPOFID-NRMATRVEN */
                _.Display($"* NRMATRVEN          = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN}");

                /*" -2416- DISPLAY '* LPARM01            = ' LPARM01 */
                _.Display($"* LPARM01            = {LPARM01}");

                /*" -2417- DISPLAY '*----------------------------------------------*' */
                _.Display($"*----------------------------------------------*");

                /*" -2419- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2420- IF LPARM03 NOT EQUAL W-DV-MATRICULA */

            if (LPARM03 != FILLER_2.W_DV_MATRICULA)
            {

                /*" -2422- MOVE PROPOFID-NRMATRVEN OF DCLPROPOSTA-FIDELIZ TO W-NRMATRICULA1 */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN, FILLER_2.W_NRMATRICULA1);

                /*" -2423- MOVE LPARM03 TO W-DV-MATRICULA */
                _.Move(LPARM03, FILLER_2.W_DV_MATRICULA);

                /*" -2424- IF WHOST-PRODUTO-SIVPF NOT = 7708 */

                if (WHOST_PRODUTO_SIVPF != 7708)
                {

                    /*" -2426- MOVE W-NRMATRICULA TO PROPOFID-NRMATRVEN OF DCLPROPOSTA-FIDELIZ */
                    _.Move(W_NRMATRICULA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN);

                    /*" -2428- END-IF */
                }


                /*" -2431- MOVE PROPOFID-NRMATRVEN OF DCLPROPOSTA-FIDELIZ TO LPARM01 WS-NRMATRVEN */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN, LPARM01, WS_NRMATRVEN);

                /*" -2434- CALL 'PRODIGCX' USING LPARM01, LPARM03 */
                _.Call("PRODIGCX", LPARM01, LPARM03);

                /*" -2436- IF LPARM01 EQUAL ALL '9' AND WS-NRMATRVEN NOT EQUAL ALL '9' */

                if (LPARM01.All("9") && !WS_NRMATRVEN.All("9"))
                {

                    /*" -2438- DISPLAY '*---------------------------------------------*' */
                    _.Display($"*---------------------------------------------*");

                    /*" -2440- DISPLAY '* VP0601B - PROBLEMAS CALL SUBROTINA PRODIGCX *' */
                    _.Display($"* VP0601B - PROBLEMAS CALL SUBROTINA PRODIGCX *");

                    /*" -2442- DISPLAY '* NUM_PROPOSTA_SIVPF = ' PROPOFID-NUM-PROPOSTA-SIVPF */
                    _.Display($"* NUM_PROPOSTA_SIVPF = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -2443- DISPLAY '* NRMATRVEN          = ' PROPOFID-NRMATRVEN */
                    _.Display($"* NRMATRVEN          = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN}");

                    /*" -2444- DISPLAY '* LPARM01            = ' LPARM01 */
                    _.Display($"* LPARM01            = {LPARM01}");

                    /*" -2446- DISPLAY '*---------------------------------------------*' */
                    _.Display($"*---------------------------------------------*");

                    /*" -2447- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2449- END-IF */
                }


                /*" -2450- MOVE LPARM03 TO W-DV-MATRICULA */
                _.Move(LPARM03, FILLER_2.W_DV_MATRICULA);

                /*" -2451- IF WHOST-PRODUTO-SIVPF NOT = 7708 */

                if (WHOST_PRODUTO_SIVPF != 7708)
                {

                    /*" -2453- MOVE W-NRMATRICULA TO PROPOFID-NRMATRVEN OF DCLPROPOSTA-FIDELIZ */
                    _.Move(W_NRMATRICULA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN);

                    /*" -2455- END-IF. */
                }

            }


            /*" -2456- IF WHOST-PRODUTO-SIVPF NOT = 7708 */

            if (WHOST_PRODUTO_SIVPF != 7708)
            {

                /*" -2457- PERFORM R1300-00-SELECT-FUNCIOCEF */

                R1300_00_SELECT_FUNCIOCEF_SECTION();

                /*" -2458- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2459- IF PROPOFID-ORIGEM-PROPOSTA NOT = 1000 */

                    if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA != 1000)
                    {

                        /*" -2460- MOVE 1302 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                        _.Move(1302, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                        /*" -2461- PERFORM R1100-00-INSERT-ERROSPROPVA */

                        R1100_00_INSERT_ERROSPROPVA_SECTION();

                        /*" -2462- END-IF */
                    }


                    /*" -2463- ELSE */
                }
                else
                {


                    /*" -2467- IF FUNCICEF-TIPO-VINCULO OF DCLFUNCIONARIOS-CEF EQUAL 'EMPREGADO CEF' AND FUNCICEF-SITUACAO OF DCLFUNCIONARIOS-CEF NOT EQUAL '0' */

                    if (FUNCICEF.DCLFUNCIONARIOS_CEF.FUNCICEF_TIPO_VINCULO == "EMPREGADO CEF" && FUNCICEF.DCLFUNCIONARIOS_CEF.FUNCICEF_SITUACAO != "0")
                    {

                        /*" -2468- MOVE 1303 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                        _.Move(1303, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                        /*" -2469- PERFORM R1100-00-INSERT-ERROSPROPVA */

                        R1100_00_INSERT_ERROSPROPVA_SECTION();

                        /*" -2470- END-IF */
                    }


                    /*" -2471- END-IF */
                }


                /*" -2475- END-IF. */
            }


            /*" -2478- MOVE PROPOFID-NUM-SICOB OF DCLPROPOSTA-FIDELIZ TO RCAPS-NUM-TITULO OF DCLRCAPS. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB, RCAPS.DCLRCAPS.RCAPS_NUM_TITULO);

            /*" -2480- MOVE ZERO TO W-RCAPS. */
            _.Move(0, WORK_AREA.W_RCAPS);

            /*" -2482- IF PROPOFID-AGECOBR OF DCLPROPOSTA-FIDELIZ > 0 AND PROPOFID-AGECOBR OF DCLPROPOSTA-FIDELIZ < 10000 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR > 0 && PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR < 10000)
            {

                /*" -2484- MOVE TAB-FONTE (PROPOFID-AGECOBR OF DCLPROPOSTA-FIDELIZ) TO WHOST-FONTE */
                _.Move(TAB_FILIAIS.TAB_FILIAL.FILLER_26[PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR].TAB_FONTE, WHOST_FONTE);

                /*" -2485- ELSE */
            }
            else
            {


                /*" -2488- DISPLAY 'AGENCIA INVALIDA ----> ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ ' ' PROPOFID-AGECOBR OF DCLPROPOSTA-FIDELIZ */

                $"AGENCIA INVALIDA ----> {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF} {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR}"
                .Display();

                /*" -2489- MOVE ZEROS TO WHOST-FONTE */
                _.Move(0, WHOST_FONTE);

                /*" -2491- END-IF. */
            }


            /*" -2493- IF (WHOST-FONTE = ZEROS OR 10) OR (WHOST-FONTE > 99) */

            if ((WHOST_FONTE.In("00", "10")) || (WHOST_FONTE > 99))
            {

                /*" -2495- MOVE 5 TO WHOST-FONTE. */
                _.Move(5, WHOST_FONTE);
            }


            /*" -2497- MOVE WHOST-FONTE TO RCAPS-COD-FONTE OF DCLRCAPS. */
            _.Move(WHOST_FONTE, RCAPS.DCLRCAPS.RCAPS_COD_FONTE);

            /*" -2499- PERFORM R1500-00-SELECT-RCAPS. */

            R1500_00_SELECT_RCAPS_SECTION();

            /*" -2500- IF NOT RCAP-CADASTRADO */

            if (!WORK_AREA.W_RCAPS["RCAP_CADASTRADO"])
            {

                /*" -2510- MOVE ZEROS TO RCAPS-COD-FONTE OF DCLRCAPS RCAPS-NUM-RCAP OF DCLRCAPS RCAPS-VAL-RCAP OF DCLRCAPS RCAPCOMP-BCO-AVISO OF DCLRCAP-COMPLEMENTAR RCAPCOMP-AGE-AVISO OF DCLRCAP-COMPLEMENTAR RCAPCOMP-NUM-AVISO-CREDITO OF DCLRCAP-COMPLEMENTAR RCAPCOMP-DATA-MOVIMENTO OF DCLRCAP-COMPLEMENTAR RCAPCOMP-DATA-RCAP OF DCLRCAP-COMPLEMENTAR */
                _.Move(0, RCAPS.DCLRCAPS.RCAPS_COD_FONTE, RCAPS.DCLRCAPS.RCAPS_NUM_RCAP, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_MOVIMENTO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP);

                /*" -2513- IF PROPOFID-SIT-PROPOSTA OF DCLPROPOSTA-FIDELIZ EQUAL 'POB' NEXT SENTENCE */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA == "POB")
                {

                    /*" -2514- ELSE */
                }
                else
                {


                    /*" -2515- MOVE 1501 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                    _.Move(1501, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                    /*" -2520- IF CANAL-GITEL AND PROPOFID-COD-PRODUTO-SIVPF = 11 OR 46 OR 77 OR 7708 NEXT SENTENCE */

                    if (WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_GITEL"] && PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF.In("11", "46", "77", "7708"))
                    {

                        /*" -2521- ELSE */
                    }
                    else
                    {


                        /*" -2522- PERFORM R1100-00-INSERT-ERROSPROPVA */

                        R1100_00_INSERT_ERROSPROPVA_SECTION();

                        /*" -2523- PERFORM R1600-00-UPDATE-PROPFID */

                        R1600_00_UPDATE_PROPFID_SECTION();

                        /*" -2525- END-IF */
                    }


                    /*" -2526- IF WHOST-SIT-PROPOSTA EQUAL 'REJ' */

                    if (WHOST_SIT_PROPOSTA == "REJ")
                    {

                        /*" -2527- GO TO R1000-10-SAIDA */

                        R1000_10_SAIDA(); //GOTO
                        return;

                        /*" -2529- ELSE NEXT SENTENCE */
                    }
                    else
                    {


                        /*" -2530- ELSE */
                    }

                }

            }
            else
            {


                /*" -2532- PERFORM R1510-00-SELECT-RCAPCOMP. */

                R1510_00_SELECT_RCAPCOMP_SECTION();
            }


            /*" -2533- IF RCAP-CADASTRADO */

            if (WORK_AREA.W_RCAPS["RCAP_CADASTRADO"])
            {

                /*" -2535- IF PROPOFID-DTQITBCO OF DCLPROPOSTA-FIDELIZ = '0001-01-01' OR PROPOFID-DTQITBCO OF DCLPROPOSTA-FIDELIZ = '1900-01-01' */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO == "0001-01-01" || PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO == "1900-01-01")
                {

                    /*" -2538- MOVE RCAPCOMP-DATA-RCAP OF DCLRCAP-COMPLEMENTAR TO PROPOFID-DTQITBCO OF DCLPROPOSTA-FIDELIZ. */
                    _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO);
                }

            }


            /*" -2539- IF CANAL-GITEL */

            if (WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_GITEL"])
            {

                /*" -2542- MOVE PROPOFID-DATA-PROPOSTA OF DCLPROPOSTA-FIDELIZ TO PROPOFID-DTQITBCO OF DCLPROPOSTA-FIDELIZ. */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO);
            }


            /*" -2544- MOVE ZERO TO W-PLANO */
            _.Move(0, WORK_AREA.W_PLANO);

            /*" -2549- MOVE +0 TO VIND-IMPSEGAUXF VIND-VLCUSTAUXF VIND-PRMDIT VIND-QTDIT. */
            _.Move(+0, VIND_IMPSEGAUXF, VIND_VLCUSTAUXF, VIND_PRMDIT, VIND_QTDIT);

            /*" -2550- IF PROPOFID-COD-PLANO OF DCLPROPOSTA-FIDELIZ = ZEROS */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO == 00)
            {

                /*" -2551- IF PROPOFID-OPCAO-COBER OF DCLPROPOSTA-FIDELIZ = SPACES */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER.IsEmpty())
                {

                    /*" -2552- MOVE 1844 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                    _.Move(1844, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                    /*" -2554- PERFORM R1100-00-INSERT-ERROSPROPVA */

                    R1100_00_INSERT_ERROSPROPVA_SECTION();

                    /*" -2555- MOVE 1845 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                    _.Move(1845, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                    /*" -2557- PERFORM R1100-00-INSERT-ERROSPROPVA. */

                    R1100_00_INSERT_ERROSPROPVA_SECTION();
                }

            }


            /*" -2559- MOVE ZEROS TO W-TP-PRESTAMISTA. */
            _.Move(0, WORK_AREA.W_TP_PRESTAMISTA);

            /*" -2562- IF CANAL-GITEL AND PROPOFID-OPRCTADEB OF DCLPROPOSTA-FIDELIZ EQUAL 23 AND PRODUVG-COD-PRODUTO OF DCLPRODUTOS-VG EQUAL 7707 */

            if (WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_GITEL"] && PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTADEB == 23 && PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO == 7707)
            {

                /*" -2563- MOVE 1 TO W-TP-PRESTAMISTA */
                _.Move(1, WORK_AREA.W_TP_PRESTAMISTA);

                /*" -2564- IF PROPOFID-VAL-PAGO NOT EQUAL 6,00 */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO != 6.00)
                {

                    /*" -2566- MOVE 1815 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                    _.Move(1815, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                    /*" -2567- PERFORM R1100-00-INSERT-ERROSPROPVA */

                    R1100_00_INSERT_ERROSPROPVA_SECTION();

                    /*" -2568- END-IF */
                }


                /*" -2570- END-IF. */
            }


            /*" -2571- MOVE ZEROS TO WHOST-IMPMORNATU-MAX. */
            _.Move(0, WHOST_IMPMORNATU_MAX);

            /*" -2572- IF PROPOFID-COD-PRODUTO-SIVPF = 77 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 77)
            {

                /*" -2573- IF NOT PROD-CROTINHO */

                if (!WORK_AREA.W_TP_PRESTAMISTA["PROD_CROTINHO"])
                {

                    /*" -2574- PERFORM R1410-00-SELECT-PLANOS-VA */

                    R1410_00_SELECT_PLANOS_VA_SECTION();

                    /*" -2575- END-IF */
                }


                /*" -2576- ELSE */
            }
            else
            {


                /*" -2577- PERFORM R1400-00-SELECT-PLANOS-VA */

                R1400_00_SELECT_PLANOS_VA_SECTION();

                /*" -2579- END-IF. */
            }


            /*" -2581- IF PRODUVG-COD-PRODUTO = 7705 OR JVPRD7705 OR 7715 */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.In("7705", JVBKINCL.JV_PRODUTOS.JVPRD7705.ToString(), "7715"))
            {

                /*" -2582- MOVE ZEROS TO WS-LIM-PRAZO */
                _.Move(0, WORK_AREA.WS_LIM_PRAZO);

                /*" -2583- IF PROPOFID-COD-PLANO OF DCLPROPOSTA-FIDELIZ LESS 12 */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO < 12)
                {

                    /*" -2584- MOVE 0 TO WS-LIM-PRAZO */
                    _.Move(0, WORK_AREA.WS_LIM_PRAZO);

                    /*" -2585- ELSE */
                }
                else
                {


                    /*" -2587- DIVIDE PROPOFID-COD-PLANO OF DCLPROPOSTA-FIDELIZ BY 12 GIVING WS-LIM-PRAZO */
                    _.Divide(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO, 12, WORK_AREA.WS_LIM_PRAZO);

                    /*" -2588- END-IF */
                }


                /*" -2589- COMPUTE WS-LIM-PRAZO = WS-LIM-PRAZO + WHOST-IDADE */
                WORK_AREA.WS_LIM_PRAZO.Value = WORK_AREA.WS_LIM_PRAZO + WHOST_IDADE;

                /*" -2590- IF WS-LIM-PRAZO GREATER 80 */

                if (WORK_AREA.WS_LIM_PRAZO > 80)
                {

                    /*" -2591- MOVE 1866 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                    _.Move(1866, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                    /*" -2592- PERFORM R1100-00-INSERT-ERROSPROPVA */

                    R1100_00_INSERT_ERROSPROPVA_SECTION();

                    /*" -2594- END-IF */
                }


                /*" -2595- IF WHOST-DATA-NASCIMENTO-2 NOT EQUAL SPACES */

                if (!WHOST_DATA_NASCIMENTO_2.IsEmpty())
                {

                    /*" -2596- MOVE WHOST-DATA-NASCIMENTO-2 TO WS-DTNASC-2 */
                    _.Move(WHOST_DATA_NASCIMENTO_2, WORK_AREA.WS_DTNASC_2);

                    /*" -2598- COMPUTE WHOST-IDADE-2 = WS-AA-DTPROP - WS-AA-DTNASC-2 */
                    WHOST_IDADE_2.Value = WORK_AREA.WS_DTPROP.WS_AA_DTPROP - WORK_AREA.WS_DTNASC_2.WS_AA_DTNASC_2;

                    /*" -2599- IF WS-MM-DTNASC-2 GREATER WS-MM-DTPROP */

                    if (WORK_AREA.WS_DTNASC_2.WS_MM_DTNASC_2 > WORK_AREA.WS_DTPROP.WS_MM_DTPROP)
                    {

                        /*" -2600- SUBTRACT 1 FROM WHOST-IDADE-2 */
                        WHOST_IDADE_2.Value = WHOST_IDADE_2 - 1;

                        /*" -2601- ELSE */
                    }
                    else
                    {


                        /*" -2602- IF WS-MM-DTNASC-2 EQUAL WS-MM-DTPROP */

                        if (WORK_AREA.WS_DTNASC_2.WS_MM_DTNASC_2 == WORK_AREA.WS_DTPROP.WS_MM_DTPROP)
                        {

                            /*" -2603- IF WS-DD-DTNASC-2 GREATER WS-DD-DTPROP */

                            if (WORK_AREA.WS_DTNASC_2.WS_DD_DTNASC_2 > WORK_AREA.WS_DTPROP.WS_DD_DTPROP)
                            {

                                /*" -2604- SUBTRACT 1 FROM WHOST-IDADE-2 */
                                WHOST_IDADE_2.Value = WHOST_IDADE_2 - 1;

                                /*" -2605- END-IF */
                            }


                            /*" -2606- END-IF */
                        }


                        /*" -2608- END-IF */
                    }


                    /*" -2609- IF PRODUVG-COD-PRODUTO = 7705 OR JVPRD7705 */

                    if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.In("7705", JVBKINCL.JV_PRODUTOS.JVPRD7705.ToString()))
                    {

                        /*" -2610- IF WHOST-IDADE-2 GREATER 79 */

                        if (WHOST_IDADE_2 > 79)
                        {

                            /*" -2611- MOVE 1867 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                            _.Move(1867, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                            /*" -2612- PERFORM R1100-00-INSERT-ERROSPROPVA */

                            R1100_00_INSERT_ERROSPROPVA_SECTION();

                            /*" -2613- END-IF */
                        }


                        /*" -2615- END-IF */
                    }


                    /*" -2617- IF PRODUVG-COD-PRODUTO OF DCLPRODUTOS-VG EQUAL 7715 */

                    if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO == 7715)
                    {

                        /*" -2618- IF WHOST-IDADE-2 LESS 18 OR WHOST-IDADE-2 GREATER 70 */

                        if (WHOST_IDADE_2 < 18 || WHOST_IDADE_2 > 70)
                        {

                            /*" -2619- MOVE 1867 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                            _.Move(1867, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                            /*" -2620- PERFORM R1100-00-INSERT-ERROSPROPVA */

                            R1100_00_INSERT_ERROSPROPVA_SECTION();

                            /*" -2621- END-IF */
                        }


                        /*" -2622- END-IF */
                    }


                    /*" -2623- END-IF */
                }


                /*" -2624- END-IF. */
            }


            /*" -2625- IF PRODUVG-COD-PRODUTO OF DCLPRODUTOS-VG EQUAL 7713 */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO == 7713)
            {

                /*" -2626- PERFORM R2247-CALCULO-IDADE */

                R2247_CALCULO_IDADE_SECTION();

                /*" -2627- MOVE WHOST-DATA-NASCIMENTO-2 TO WS-DTNASC-2 */
                _.Move(WHOST_DATA_NASCIMENTO_2, WORK_AREA.WS_DTNASC_2);

                /*" -2629- COMPUTE WHOST-IDADE-2 = WS-AA-DTPROP - WS-AA-DTNASC-2 */
                WHOST_IDADE_2.Value = WORK_AREA.WS_DTPROP.WS_AA_DTPROP - WORK_AREA.WS_DTNASC_2.WS_AA_DTNASC_2;

                /*" -2633- END-IF. */
            }


            /*" -2634- IF NOT EXISTE-PLANO */

            if (!WORK_AREA.W_PLANO["EXISTE_PLANO"])
            {

                /*" -2649- MOVE ZEROS TO IMPMORNATU OF DCLPLANOS-VA-VGAP, IMPMORACID OF DCLPLANOS-VA-VGAP, IMPINVPERM OF DCLPLANOS-VA-VGAP, IMPAMDS OF DCLPLANOS-VA-VGAP, IMPDH OF DCLPLANOS-VA-VGAP, IMPDIT OF DCLPLANOS-VA-VGAP, VLPREMIOTOT OF DCLPLANOS-VA-VGAP, PRMVG OF DCLPLANOS-VA-VGAP, PRMAP OF DCLPLANOS-VA-VGAP, QTTITCAP OF DCLPLANOS-VA-VGAP, VLTITCAP OF DCLPLANOS-VA-VGAP, VLCUSTCAP OF DCLPLANOS-VA-VGAP, IMPSEGCDG OF DCLPLANOS-VA-VGAP, VLCUSTCDG OF DCLPLANOS-VA-VGAP WHOST-IMPMORNATU-MAX */
                _.Move(0, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORACID, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPINVPERM, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPAMDS, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPDH, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPDIT, PLVAVGAP.DCLPLANOS_VA_VGAP.VLPREMIOTOT, PLVAVGAP.DCLPLANOS_VA_VGAP.PRMVG, PLVAVGAP.DCLPLANOS_VA_VGAP.PRMAP, PLVAVGAP.DCLPLANOS_VA_VGAP.QTTITCAP, PLVAVGAP.DCLPLANOS_VA_VGAP.VLTITCAP, PLVAVGAP.DCLPLANOS_VA_VGAP.VLCUSTCAP, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPSEGCDG, PLVAVGAP.DCLPLANOS_VA_VGAP.VLCUSTCDG, WHOST_IMPMORNATU_MAX);

                /*" -2650- IF NOT PROD-CROTINHO */

                if (!WORK_AREA.W_TP_PRESTAMISTA["PROD_CROTINHO"])
                {

                    /*" -2654- MOVE -1 TO VIND-IMPSEGAUXF, VIND-VLCUSTAUXF, VIND-PRMDIT, VIND-QTDIT */
                    _.Move(-1, VIND_IMPSEGAUXF, VIND_VLCUSTAUXF, VIND_PRMDIT, VIND_QTDIT);

                    /*" -2657- IF PRODUVG-COD-PRODUTO NOT = 7725 AND JVPRD7725 AND 7732 AND JVPRD7732 AND 7733 AND JVPRD7733 */

                    if (!PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.In("7725", JVBKINCL.JV_PRODUTOS.JVPRD7725.ToString(), "7732", JVBKINCL.JV_PRODUTOS.JVPRD7732.ToString(), "7733", JVBKINCL.JV_PRODUTOS.JVPRD7733.ToString()))
                    {

                        /*" -2658- MOVE 604 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                        _.Move(604, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                        /*" -2659- PERFORM R1100-00-INSERT-ERROSPROPVA */

                        R1100_00_INSERT_ERROSPROPVA_SECTION();

                        /*" -2660- END-IF */
                    }


                    /*" -2661- END-IF */
                }


                /*" -2663- END-IF */
            }


            /*" -2664- IF EXISTE-PLANO */

            if (WORK_AREA.W_PLANO["EXISTE_PLANO"])
            {

                /*" -2666- DIVIDE VLPREMIOTOT OF DCLPLANOS-VA-VGAP BY 2 GIVING WS-VLPREMIOTOT-CCT */
                _.Divide(PLVAVGAP.DCLPLANOS_VA_VGAP.VLPREMIOTOT, 2, WORK_AREA.WS_VLPREMIOTOT_CCT);

                /*" -2667- ELSE */
            }
            else
            {


                /*" -2668- MOVE ZEROS TO WS-VLPREMIOTOT-CCT */
                _.Move(0, WORK_AREA.WS_VLPREMIOTOT_CCT);

                /*" -2670- END-IF */
            }


            /*" -2673- IF EXISTE-PLANO AND NOVO-CALCULO-PREMIO */

            if (WORK_AREA.W_PLANO["EXISTE_PLANO"] && WORK_AREA.W_NOVO_CALCULO["NOVO_CALCULO_PREMIO"])
            {

                /*" -2674- IF PROPOFID-VAL-PAGO OF DCLPROPOSTA-FIDELIZ > 0 */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO > 0)
                {

                    /*" -2688- MOVE PROPOFID-VAL-PAGO OF DCLPROPOSTA-FIDELIZ TO IMPMORNATU OF DCLPLANOS-VA-VGAP IMPMORACID OF DCLPLANOS-VA-VGAP VLPREMIOTOT OF DCLPLANOS-VA-VGAP */
                    _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORACID, PLVAVGAP.DCLPLANOS_VA_VGAP.VLPREMIOTOT);

                    /*" -2689- ELSE */
                }
                else
                {


                    /*" -2691- MOVE RCAPS-VAL-RCAP OF DCLRCAPS TO VLPREMIOTOT OF DCLPLANOS-VA-VGAP */
                    _.Move(RCAPS.DCLRCAPS.RCAPS_VAL_RCAP, PLVAVGAP.DCLPLANOS_VA_VGAP.VLPREMIOTOT);

                    /*" -2692- END-IF */
                }


                /*" -2695- COMPUTE WS-IMP-SEGUR = VLPREMIOTOT OF DCLPLANOS-VA-VGAP * 100 / TAXAVG OF DCLPLANOS-VA-VGAP */
                WS_IMP_SEGUR.Value = PLVAVGAP.DCLPLANOS_VA_VGAP.VLPREMIOTOT * 100 / PLVAVGAP.DCLPLANOS_VA_VGAP.TAXAVG;

                /*" -2699- MOVE WS-IMP-SEGUR TO IMPMORACID OF DCLPLANOS-VA-VGAP IMPMORNATU OF DCLPLANOS-VA-VGAP */
                _.Move(WS_IMP_SEGUR, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORACID, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU);

                /*" -2703- MOVE VLPREMIOTOT OF DCLPLANOS-VA-VGAP TO PRMVG OF DCLPLANOS-VA-VGAP WS-VLPREMIOTOT-CCT */
                _.Move(PLVAVGAP.DCLPLANOS_VA_VGAP.VLPREMIOTOT, PLVAVGAP.DCLPLANOS_VA_VGAP.PRMVG, WORK_AREA.WS_VLPREMIOTOT_CCT);

                /*" -2705- IF PROPOFID-DATA-CREDITO EQUAL '0001-01-01' OR PROPOFID-DATA-CREDITO EQUAL '1901-01-01' */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_CREDITO == "0001-01-01" || PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_CREDITO == "1901-01-01")
                {

                    /*" -2706- IF NOT EXISTE-PLANO */

                    if (!WORK_AREA.W_PLANO["EXISTE_PLANO"])
                    {

                        /*" -2708- IF NOT RCAP-CADASTRADO NEXT SENTENCE */

                        if (!WORK_AREA.W_RCAPS["RCAP_CADASTRADO"])
                        {

                            /*" -2709- END-IF */
                        }


                        /*" -2711- END-IF */
                    }


                    /*" -2712- IF PROPOFID-VAL-PAGO EQUAL ZEROS */

                    if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO == 00)
                    {

                        /*" -2713- IF EXISTE-PLANO */

                        if (WORK_AREA.W_PLANO["EXISTE_PLANO"])
                        {

                            /*" -2715- MOVE VLPREMIOTOT OF DCLPLANOS-VA-VGAP TO PROPOFID-VAL-PAGO OF DCLPROPOSTA-FIDELIZ */
                            _.Move(PLVAVGAP.DCLPLANOS_VA_VGAP.VLPREMIOTOT, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO);

                            /*" -2716- ELSE */
                        }
                        else
                        {


                            /*" -2718- MOVE RCAPS-VAL-RCAP OF DCLRCAPS TO PROPOFID-VAL-PAGO OF DCLPROPOSTA-FIDELIZ */
                            _.Move(RCAPS.DCLRCAPS.RCAPS_VAL_RCAP, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO);

                            /*" -2719- END-IF */
                        }


                        /*" -2721- END-IF */
                    }


                    /*" -2722- IF NOT PROD-CROTINHO */

                    if (!WORK_AREA.W_TP_PRESTAMISTA["PROD_CROTINHO"])
                    {

                        /*" -2724- PERFORM R1700-00-UPDATE-PRP-FIDELIZ. */

                        R1700_00_UPDATE_PRP_FIDELIZ_SECTION();
                    }

                }

            }


            /*" -2727- COMPUTE WHOST-PREMIO-1 = VLPREMIOTOT OF DCLPLANOS-VA-VGAP - 1. */
            WHOST_PREMIO_1.Value = PLVAVGAP.DCLPLANOS_VA_VGAP.VLPREMIOTOT - 1;

            /*" -2730- COMPUTE WHOST-PREMIO-2 = VLPREMIOTOT OF DCLPLANOS-VA-VGAP + 1. */
            WHOST_PREMIO_2.Value = PLVAVGAP.DCLPLANOS_VA_VGAP.VLPREMIOTOT + 1;

            /*" -2731- IF NOT CANAL-SASSE-FILIAL */

            if (!WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_SASSE_FILIAL"])
            {

                /*" -2732- IF PROPOFID-ORIGEM-PROPOSTA NOT EQUAL 80 */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA != 80)
                {

                    /*" -2733- IF RCAP-CADASTRADO */

                    if (WORK_AREA.W_RCAPS["RCAP_CADASTRADO"])
                    {

                        /*" -2734- IF EXISTE-PLANO */

                        if (WORK_AREA.W_PLANO["EXISTE_PLANO"])
                        {

                            /*" -2742- IF (RCAPS-VAL-RCAP OF DCLRCAPS NOT EQUAL VLPREMIOTOT OF DCLPLANOS-VA-VGAP) AND (RCAPS-VAL-RCAP OF DCLRCAPS NOT EQUAL WS-VLPREMIOTOT-CCT) AND ((RCAPS-VAL-RCAP OF DCLRCAPS LESS WHOST-PREMIO-1 ) OR (RCAPS-VAL-RCAP OF DCLRCAPS GREATER WHOST-PREMIO-2 )) */

                            if ((RCAPS.DCLRCAPS.RCAPS_VAL_RCAP != PLVAVGAP.DCLPLANOS_VA_VGAP.VLPREMIOTOT) && (RCAPS.DCLRCAPS.RCAPS_VAL_RCAP != WORK_AREA.WS_VLPREMIOTOT_CCT) && ((RCAPS.DCLRCAPS.RCAPS_VAL_RCAP < WHOST_PREMIO_1) || (RCAPS.DCLRCAPS.RCAPS_VAL_RCAP > WHOST_PREMIO_2)))
                            {

                                /*" -2743- MOVE 1817 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                                _.Move(1817, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                                /*" -2750- PERFORM R1100-00-INSERT-ERROSPROPVA. */

                                R1100_00_INSERT_ERROSPROPVA_SECTION();
                            }

                        }

                    }

                }

            }


            /*" -2751- INITIALIZE WS-NUM-PROPOSTA-AZUL. */
            _.Initialize(
                WS_NUM_PROPOSTA_AZUL
            );

            /*" -2754- MOVE PROPOFID-NUM-SICOB OF DCLPROPOSTA-FIDELIZ TO WS-NUM-PROPOSTA-AZUL. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB, WS_NUM_PROPOSTA_AZUL);

            /*" -2760- PERFORM R1000_CONSISTE_CX_TRAB_DB_SELECT_1 */

            R1000_CONSISTE_CX_TRAB_DB_SELECT_1();

            /*" -2763- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -2764- MOVE 913 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(913, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -2765- PERFORM R1100-00-INSERT-ERROSPROPVA */

                R1100_00_INSERT_ERROSPROPVA_SECTION();

                /*" -2775- END-IF. */
            }


            /*" -2777- IF WHOST-IMPMORNATU-MAX GREATER ZEROS */

            if (WHOST_IMPMORNATU_MAX > 00)
            {

                /*" -2778- PERFORM R2241-00-SELECT-ACUM-RISCO */

                R2241_00_SELECT_ACUM_RISCO_SECTION();

                /*" -2779- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 77 */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 77)
                {

                    /*" -2783- DISPLAY 'RISCO 77 ----> ' ' ' PROPOFID-NUM-PROPOSTA-SIVPF ' ' WHOST-IMPMORNATU-MAX ' ' AC-TOT-RISCO */

                    $"RISCO 77 ---->  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF} {WHOST_IMPMORNATU_MAX} {WORK_AREA.AC_TOT_RISCO}"
                    .Display();

                    /*" -2784- END-IF */
                }


                /*" -2785- IF PROPOFID-COD-PRODUTO-SIVPF NOT EQUAL 77 */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF != 77)
                {

                    /*" -2786- IF AC-TOT-RISCO GREATER WHOST-IMPMORNATU-MAX */

                    if (WORK_AREA.AC_TOT_RISCO > WHOST_IMPMORNATU_MAX)
                    {

                        /*" -2787- MOVE 1852 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                        _.Move(1852, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                        /*" -2788- PERFORM R1100-00-INSERT-ERROSPROPVA */

                        R1100_00_INSERT_ERROSPROPVA_SECTION();

                        /*" -2790- DISPLAY 'REJ 1852 -->' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                        _.Display($"REJ 1852 -->{PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                        /*" -2791- MOVE 'SIM' TO WS-TEM-ERRO-1852 */
                        _.Move("SIM", WORK_AREA.WS_TEM_ERRO_1852);

                        /*" -2794- PERFORM R3700-00-INSERT-RELATORIOS. */

                        R3700_00_INSERT_RELATORIOS_SECTION();
                    }

                }

            }


            /*" -2795- IF PRODUVG-COD-PRODUTO OF DCLPRODUTOS-VG EQUAL 7713 */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO == 7713)
            {

                /*" -2796- PERFORM R2245-VALIDAR-IMPORTANCIA */

                R2245_VALIDAR_IMPORTANCIA_SECTION();

                /*" -2797- PERFORM R2246-CALCULO-IS-7713 */

                R2246_CALCULO_IS_7713_SECTION();

                /*" -2799- END-IF. */
            }


            /*" -2800- IF PRODUVG-COD-PRODUTO OF DCLPRODUTOS-VG EQUAL 7715 */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO == 7715)
            {

                /*" -2801- PERFORM R2248-CALCULO-IS-7715 */

                R2248_CALCULO_IS_7715_SECTION();

                /*" -2803- END-IF. */
            }


            /*" -2804- IF PRODUVG-COD-PRODUTO = 7725 OR JVPRD7725 */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.In("7725", JVBKINCL.JV_PRODUTOS.JVPRD7725.ToString()))
            {

                /*" -2805- PERFORM R2249-CALCULO-IS-7725 */

                R2249_CALCULO_IS_7725_SECTION();

                /*" -2814- END-IF. */
            }


            /*" -2816- MOVE 'NAO' TO WS-TEM-ERRO-1855 */
            _.Move("NAO", WORK_AREA.WS_TEM_ERRO_1855);

            /*" -2818- IF FAIXA-RENDA-IND NOT EQUAL SPACES AND NOT PROD-CROTINHO */

            if (!PROPVA.DCLPROPOSTAS_VA.FAIXA_RENDA_IND.IsEmpty() && !WORK_AREA.W_TP_PRESTAMISTA["PROD_CROTINHO"])
            {

                /*" -2819- MOVE FAIXA-RENDA-IND TO INDR */
                _.Move(PROPVA.DCLPROPOSTAS_VA.FAIXA_RENDA_IND, WORK_AREA.INDR);

                /*" -2821- IF INDR > 0 AND INDR < 6 */

                if (WORK_AREA.INDR > 0 && WORK_AREA.INDR < 6)
                {

                    /*" -2833- IF IMPMORNATU OF DCLPLANOS-VA-VGAP GREATER TAB-LIMIT-MAXIMO(INDR) AND (PRODUVG-COD-PRODUTO NOT = 7705 AND JVPRD7705 AND 7715 ) */

                    if (PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU > TAB_RENDAS.TAB_RENDA.FILLER_25[WORK_AREA.INDR].TAB_LIMIT_MAXIMO && (!PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.In("7705", JVBKINCL.JV_PRODUTOS.JVPRD7705.ToString(), "7715")))
                    {

                        /*" -2834- MOVE PRODUVG-COD-PRODUTO TO GE400-COD-PRODUTO */
                        _.Move(PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO, GE400.DCLGE_IS_SUPERIOR.GE400_COD_PRODUTO);

                        /*" -2835- MOVE PROPSSVD-NUM-APOLICE TO GE400-NUM-APOLICE */
                        _.Move(PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE, GE400.DCLGE_IS_SUPERIOR.GE400_NUM_APOLICE);

                        /*" -2837- MOVE CPF OF DCLPESSOA-FISICA TO GE400-NUM-CPF */
                        _.Move(PESFIS.DCLPESSOA_FISICA.CPF, GE400.DCLGE_IS_SUPERIOR.GE400_NUM_CPF);

                        /*" -2844- PERFORM R1111-00-TRATAR-VR-IS-SUPERIOR */

                        R1111_00_TRATAR_VR_IS_SUPERIOR_SECTION();

                        /*" -2858- IF WS-CADASTRO-IS-SUPERIOR = ZEROS */

                        if (WS_CADASTRO_IS_SUPERIOR == 00)
                        {

                            /*" -2859- MOVE 1855 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                            _.Move(1855, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                            /*" -2860- PERFORM R1100-00-INSERT-ERROSPROPVA */

                            R1100_00_INSERT_ERROSPROPVA_SECTION();

                            /*" -2861- MOVE 'SIM' TO WS-TEM-ERRO-1855 */
                            _.Move("SIM", WORK_AREA.WS_TEM_ERRO_1855);

                            /*" -2863- PERFORM R3700-00-INSERT-RELATORIOS. */

                            R3700_00_INSERT_RELATORIOS_SECTION();
                        }

                    }

                }

            }


            /*" -2865- IF CANAL-SASSE-FILIAL AND EXISTE-PLANO */

            if (WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_SASSE_FILIAL"] && WORK_AREA.W_PLANO["EXISTE_PLANO"])
            {

                /*" -2871- COMPUTE COBERP-IMPMORNATU = PROPOFID-VAL-PAGO / ((TAXAVG OF DCLPLANOS-VA-VGAP / 100) * COD-PLANO OF DCLPLANOS-VA-VGAP) */
                COBERP_IMPMORNATU.Value = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO / ((PLVAVGAP.DCLPLANOS_VA_VGAP.TAXAVG / 100f) * PLVAVGAP.DCLPLANOS_VA_VGAP.COD_PLANO);

                /*" -2880- IF COBERP-IMPMORNATU GREATER FAIXA-SAL-FIM OF DCLPLANOS-VA-VGAP */

                if (COBERP_IMPMORNATU > PLVAVGAP.DCLPLANOS_VA_VGAP.FAIXA_SAL_FIM)
                {

                    /*" -2881- MOVE PRODUVG-COD-PRODUTO TO GE400-COD-PRODUTO */
                    _.Move(PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO, GE400.DCLGE_IS_SUPERIOR.GE400_COD_PRODUTO);

                    /*" -2882- MOVE PROPSSVD-NUM-APOLICE TO GE400-NUM-APOLICE */
                    _.Move(PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE, GE400.DCLGE_IS_SUPERIOR.GE400_NUM_APOLICE);

                    /*" -2884- MOVE CPF OF DCLPESSOA-FISICA TO GE400-NUM-CPF */
                    _.Move(PESFIS.DCLPESSOA_FISICA.CPF, GE400.DCLGE_IS_SUPERIOR.GE400_NUM_CPF);

                    /*" -2891- PERFORM R1111-00-TRATAR-VR-IS-SUPERIOR */

                    R1111_00_TRATAR_VR_IS_SUPERIOR_SECTION();

                    /*" -2905- IF WS-CADASTRO-IS-SUPERIOR = ZEROS */

                    if (WS_CADASTRO_IS_SUPERIOR == 00)
                    {

                        /*" -2906- MOVE 1855 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                        _.Move(1855, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                        /*" -2907- PERFORM R1100-00-INSERT-ERROSPROPVA */

                        R1100_00_INSERT_ERROSPROPVA_SECTION();

                        /*" -2908- MOVE 'SIM' TO WS-TEM-ERRO-1855 */
                        _.Move("SIM", WORK_AREA.WS_TEM_ERRO_1855);

                        /*" -2917- PERFORM R3700-00-INSERT-RELATORIOS. */

                        R3700_00_INSERT_RELATORIOS_SECTION();
                    }

                }

            }


            /*" -2918- IF WS-TEM-ERRO EQUAL ZEROS */

            if (WORK_AREA.WS_TEM_ERRO == 00)
            {

                /*" -2919- MOVE ZEROS TO WS-TEM-ERRO-ASS */
                _.Move(0, WORK_AREA.WS_TEM_ERRO_ASS);

                /*" -2920- ELSE */
            }
            else
            {


                /*" -2921- MOVE 1 TO WS-TEM-ERRO-ASS */
                _.Move(1, WORK_AREA.WS_TEM_ERRO_ASS);

                /*" -2936- END-IF */
            }


            /*" -2937- IF WS-TEM-ERRO-ASS EQUAL ZEROS */

            if (WORK_AREA.WS_TEM_ERRO_ASS == 00)
            {

                /*" -2938- MOVE ZEROS TO WS-TEM-ERRO */
                _.Move(0, WORK_AREA.WS_TEM_ERRO);

                /*" -2948- END-IF */
            }


            /*" -2950- PERFORM R5632-00-SELECT-PROPOSTAVA. */

            R5632_00_SELECT_PROPOSTAVA_SECTION();

            /*" -2951- IF WEXISTE-PRPVA EQUAL 'SIM' */

            if (WEXISTE_PRPVA == "SIM")
            {

                /*" -2953- IF SIT-REGISTRO OF DCLPROPOSTAS-VA EQUAL '0' OR '1' OR '3' OR '7' OR '8' */

                if (PROPVA.DCLPROPOSTAS_VA.SIT_REGISTRO.In("0", "1", "3", "7", "8"))
                {

                    /*" -2954- PERFORM R5633-00-UPDATE-PRP-FIDELIZ */

                    R5633_00_UPDATE_PRP_FIDELIZ_SECTION();

                    /*" -2966- GO TO R1000-10-SAIDA. */

                    R1000_10_SAIDA(); //GOTO
                    return;
                }

            }


            /*" -2968- PERFORM R2400-00-TRATA-ENDERECOS. */

            R2400_00_TRATA_ENDERECOS_SECTION();

            /*" -2969- IF WHOST-EMAIL NOT EQUAL SPACES */

            if (!WHOST_EMAIL.IsEmpty())
            {

                /*" -2971- PERFORM R2500-00-TRATA-EMAIL. */

                R2500_00_TRATA_EMAIL_SECTION();
            }


            /*" -2972- IF WWORK-TIPO-MOVIMENTO NOT EQUAL SPACES */

            if (!W_GECLIMOV.WWORK_TIPO_MOVIMENTO.IsEmpty())
            {

                /*" -2975- PERFORM R9300-00-TRATA-MOVTO-CLIENTE. */

                R9300_00_TRATA_MOVTO_CLIENTE_SECTION();
            }


            /*" -2976- IF PROPOFID-NRMATRCON = 19 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRCON == 19)
            {

                /*" -2977- PERFORM R4000-CALCULO-IS-7707-CDC */

                R4000_CALCULO_IS_7707_CDC_SECTION();

                /*" -2982- END-IF */
            }


            /*" -2983- IF WEXISTE-PRPVA EQUAL 'NAO' */

            if (WEXISTE_PRPVA == "NAO")
            {

                /*" -2984- PERFORM R3000-00-INSERT-PROPOSTAVA */

                R3000_00_INSERT_PROPOSTAVA_SECTION();

                /*" -2985- ELSE */
            }
            else
            {


                /*" -2986- PERFORM R5635-00-UPDATE-PROPOSTAVA */

                R5635_00_UPDATE_PROPOSTAVA_SECTION();

                /*" -2988- END-IF */
            }


            /*" -2990- PERFORM R3100-00-INSERT-COBERPROPVA */

            R3100_00_INSERT_COBERPROPVA_SECTION();

            /*" -2992- PERFORM R3110-00-DECLARE-VGPLARAMCOB */

            R3110_00_DECLARE_VGPLARAMCOB_SECTION();

            /*" -2994- PERFORM R3150-00-DECLARE-VGPLAACES */

            R3150_00_DECLARE_VGPLAACES_SECTION();

            /*" -2997- MOVE CEP OF DCLPESSOA-ENDERECO TO CT0006S-CEP-DESTINO */
            _.Move(PESENDER.DCLPESSOA_ENDERECO.CEP, CT0006S_LINKAGE.CT0006S_CEP_DESTINO);

            /*" -3000- MOVE SIGLA-UF OF DCLPESSOA-ENDERECO TO CT0006S-SIGLA-UF */
            _.Move(PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF, CT0006S_LINKAGE.CT0006S_SIGLA_UF);

            /*" -3003- MOVE SPACES TO CT0006S-MENSAGEM. */
            _.Move("", CT0006S_LINKAGE.CT0006S_MENSAGEM);

            /*" -3006- MOVE ZEROS TO CT0006S-SQLCODE. */
            _.Move(0, CT0006S_LINKAGE.CT0006S_SQLCODE);

            /*" -3030- CALL 'CT0006S' USING CT0006S-LINKAGE. */
            _.Call("CT0006S", CT0006S_LINKAGE);

            /*" -3031- IF PROPOFID-OPCAOPAG OF DCLPROPOSTA-FIDELIZ EQUAL 3 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAOPAG == 3)
            {

                /*" -3032- PERFORM R1250-00-SELECT-OPCAOPAGVA */

                R1250_00_SELECT_OPCAOPAGVA_SECTION();

                /*" -3033- IF OPCPAGVI-NUM-CARTAO-CREDITO EQUAL ZEROS */

                if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO == 00)
                {

                    /*" -3034- MOVE 1853 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                    _.Move(1853, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                    /*" -3035- PERFORM R1100-00-INSERT-ERROSPROPVA */

                    R1100_00_INSERT_ERROSPROPVA_SECTION();

                    /*" -3036- ELSE */
                }
                else
                {


                    /*" -3038- MOVE OPCPAGVI-NUM-CARTAO-CREDITO TO W-NUM-CARTAO-CREDITO */
                    _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO, W_NUM_CARTAO_CREDITO);

                    /*" -3047- IF W-NUM-CARTAO-CREDITO (1:6) = 400236 OR 400636 OR 400770 OR 400970 OR 401370 OR 403236 OR 432989 OR 433589 OR 434389 OR 510447 OR 518767 OR 539016 OR 539017 OR 539018 OR 544816 OR 544817 OR 544818 OR 548826 OR 548827 OR 549316 OR 549317 OR 549318 OR 554932 OR 557768 */

                    if (W_NUM_CARTAO_CREDITO.Substring(1, 6).In("400236", "400636", "400770", "400970", "401370", "403236", "432989", "433589", "434389", "510447", "518767", "539016", "539017", "539018", "544816", "544817", "544818", "548826", "548827", "549316", "549317", "549318", "554932", "557768"))
                    {

                        /*" -3048- IF OPCPAGVI-NUM-CONTA-DEBITO EQUAL ZEROES */

                        if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO == 00)
                        {

                            /*" -3049- MOVE 1854 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                            _.Move(1854, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                            /*" -3050- PERFORM R1100-00-INSERT-ERROSPROPVA */

                            R1100_00_INSERT_ERROSPROPVA_SECTION();

                            /*" -3051- END-IF */
                        }


                        /*" -3052- ELSE */
                    }
                    else
                    {


                        /*" -3053- MOVE 1853 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                        _.Move(1853, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                        /*" -3054- PERFORM R1100-00-INSERT-ERROSPROPVA */

                        R1100_00_INSERT_ERROSPROPVA_SECTION();

                        /*" -3055- END-IF */
                    }


                    /*" -3056- END-IF */
                }


                /*" -3062- END-IF. */
            }


            /*" -3063- IF PROPOFID-OPCAOPAG OF DCLPROPOSTA-FIDELIZ NOT EQUAL 3 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAOPAG != 3)
            {

                /*" -3065- PERFORM R3200-00-INSERT-OPCAOPAGVA. */

                R3200_00_INSERT_OPCAOPAGVA_SECTION();
            }


            /*" -3066- IF RCAP-CADASTRADO */

            if (WORK_AREA.W_RCAPS["RCAP_CADASTRADO"])
            {

                /*" -3068- IF COBRANCA-EMITIDA NEXT SENTENCE */

                if (WORK_AREA.W_COBRANCA["COBRANCA_EMITIDA"])
                {

                    /*" -3069- ELSE */
                }
                else
                {


                    /*" -3070- PERFORM R3300-00-INSERT-COMISICOBVA */

                    R3300_00_INSERT_COMISICOBVA_SECTION();

                    /*" -3071- IF WEXISTE-COMISSAO EQUAL 'NAO' */

                    if (WEXISTE_COMISSAO == "NAO")
                    {

                        /*" -3072- PERFORM R3400-00-INSERT-PARCELVA */

                        R3400_00_INSERT_PARCELVA_SECTION();

                        /*" -3073- PERFORM R3500-00-INSERT-HISTCOBVA */

                        R3500_00_INSERT_HISTCOBVA_SECTION();

                        /*" -3075- PERFORM R3600-00-INSERT-HISTCONTABILVA. */

                        R3600_00_INSERT_HISTCONTABILVA_SECTION();
                    }

                }

            }


            /*" -3077- IF PROPOFID-NSAS-SIVPF OF DCLPROPOSTA-FIDELIZ EQUAL 01 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAS_SIVPF == 01)
            {

                /*" -3079- PERFORM R3700-00-INSERT-RELATORIOS. */

                R3700_00_INSERT_RELATORIOS_SECTION();
            }


            /*" -3081- IF PROPOFID-SIT-PROPOSTA OF DCLPROPOSTA-FIDELIZ EQUAL 'DEC' */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA == "DEC")
            {

                /*" -3082- MOVE 1846 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1846, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -3083- PERFORM R1100-00-INSERT-ERROSPROPVA */

                R1100_00_INSERT_ERROSPROPVA_SECTION();

                /*" -3085- PERFORM R3700-00-INSERT-RELATORIOS. */

                R3700_00_INSERT_RELATORIOS_SECTION();
            }


            /*" -3085- PERFORM R1600-00-UPDATE-PROPFID. */

            R1600_00_UPDATE_PROPFID_SECTION();

        }

        [StopWatch]
        /*" R1000-CONSISTE-CX-TRAB-DB-SELECT-1 */
        public void R1000_CONSISTE_CX_TRAB_DB_SELECT_1()
        {
            /*" -2760- EXEC SQL SELECT NUM_PROPOSTA_AZUL INTO :WS-NUM-PROPOSTA-AZUL FROM SEGUROS.BENEF_PROP_AZUL WHERE NUM_PROPOSTA_AZUL = :WS-NUM-PROPOSTA-AZUL AND GRAU_PARENTESCO = 'ERROPF' END-EXEC. */

            var r1000_CONSISTE_CX_TRAB_DB_SELECT_1_Query1 = new R1000_CONSISTE_CX_TRAB_DB_SELECT_1_Query1()
            {
                WS_NUM_PROPOSTA_AZUL = WS_NUM_PROPOSTA_AZUL.ToString(),
            };

            var executed_1 = R1000_CONSISTE_CX_TRAB_DB_SELECT_1_Query1.Execute(r1000_CONSISTE_CX_TRAB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_NUM_PROPOSTA_AZUL, WS_NUM_PROPOSTA_AZUL);
            }


        }

        [StopWatch]
        /*" R1000-10-SAIDA */
        private void R1000_10_SAIDA(bool isPerform = false)
        {
            /*" -3089- PERFORM R0910-00-FETCH-PROPOSTA. */

            R0910_00_FETCH_PROPOSTA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-INSERT-ERROSPROPVA-SECTION */
        private void R1100_00_INSERT_ERROSPROPVA_SECTION()
        {
            /*" -3110- IF PRODUVG-COD-PRODUTO = 7705 OR JVPRD7705 OR 7707 OR 7715 AND (COD-ERRO OF DCLERROS-PROP-VIDAZUL NOT EQUAL 1855 AND 1867 AND 1005 AND 1006) NEXT SENTENCE */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.In("7705", JVBKINCL.JV_PRODUTOS.JVPRD7705.ToString(), "7707", "7715") && (!ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO.In("1855", "1867", "1005", "1006")))
            {

                /*" -3111- ELSE */
            }
            else
            {


                /*" -3112- MOVE 1 TO WS-TEM-ERRO */
                _.Move(1, WORK_AREA.WS_TEM_ERRO);

                /*" -3113- MOVE '1100-00-INSERT-ERROSPROPVA   ' TO PARAGRAFO */
                _.Move("1100-00-INSERT-ERROSPROPVA   ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

                /*" -3114- MOVE 05 TO SII */
                _.Move(05, WS_HORAS.SII);

                /*" -3115- PERFORM R9000-00-INICIO */

                R9000_00_INICIO_SECTION();

                /*" -3123- PERFORM R1100_00_INSERT_ERROSPROPVA_DB_INSERT_1 */

                R1100_00_INSERT_ERROSPROPVA_DB_INSERT_1();

                /*" -3126- PERFORM R9100-00-TERMINO */

                R9100_00_TERMINO_SECTION();

                /*" -3127- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -3128- DISPLAY '-- INSERT NA TABELA ERROS_PROP_VIDAZUL---' */
                    _.Display($"-- INSERT NA TABELA ERROS_PROP_VIDAZUL---");

                    /*" -3130- DISPLAY 'NUM-PROPOSTA-SIVPF = ' PROPOFID-NUM-PROPOSTA-SIVPF */
                    _.Display($"NUM-PROPOSTA-SIVPF = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -3132- DISPLAY 'COD-ERRO           = ' COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                    _.Display($"COD-ERRO           = {ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO}");

                    /*" -3133- DISPLAY '-----------------------------------------' . */
                    _.Display($"-----------------------------------------");
                }

            }


            /*" -3135- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL -803 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
            {

                /*" -3136- DISPLAY 'PROBLEMAS NO INSERT A ERROS-PROP-VIDAZUL' */
                _.Display($"PROBLEMAS NO INSERT A ERROS-PROP-VIDAZUL");

                /*" -3136- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1100-00-INSERT-ERROSPROPVA-DB-INSERT-1 */
        public void R1100_00_INSERT_ERROSPROPVA_DB_INSERT_1()
        {
            /*" -3123- EXEC SQL INSERT INTO SEGUROS.ERROS_PROP_VIDAZUL VALUES ( :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF, :DCLERROS-PROP-VIDAZUL.COD-ERRO ) END-EXEC */

            var r1100_00_INSERT_ERROSPROPVA_DB_INSERT_1_Insert1 = new R1100_00_INSERT_ERROSPROPVA_DB_INSERT_1_Insert1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
                COD_ERRO = ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO.ToString(),
            };

            R1100_00_INSERT_ERROSPROPVA_DB_INSERT_1_Insert1.Execute(r1100_00_INSERT_ERROSPROPVA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1111-00-TRATAR-VR-IS-SUPERIOR-SECTION */
        private void R1111_00_TRATAR_VR_IS_SUPERIOR_SECTION()
        {
            /*" -3144- MOVE 'R1111-00-TRATAR-VR-IS-SUPERIOR' TO PARAGRAFO */
            _.Move("R1111-00-TRATAR-VR-IS-SUPERIOR", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3146- MOVE ZEROS TO WS-CADASTRO-IS-SUPERIOR */
            _.Move(0, WS_CADASTRO_IS_SUPERIOR);

            /*" -3156- PERFORM R1111_00_TRATAR_VR_IS_SUPERIOR_DB_SELECT_1 */

            R1111_00_TRATAR_VR_IS_SUPERIOR_DB_SELECT_1();

            /*" -3160- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -3161- DISPLAY 'PROBLEMAS NO SELECT GE_IS_SUPERIOR' */
                _.Display($"PROBLEMAS NO SELECT GE_IS_SUPERIOR");

                /*" -3162- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3162- END-IF. */
            }


        }

        [StopWatch]
        /*" R1111-00-TRATAR-VR-IS-SUPERIOR-DB-SELECT-1 */
        public void R1111_00_TRATAR_VR_IS_SUPERIOR_DB_SELECT_1()
        {
            /*" -3156- EXEC SQL SELECT COUNT (*) INTO :WS-CADASTRO-IS-SUPERIOR FROM SEGUROS.GE_IS_SUPERIOR T1 WHERE NUM_APOLICE = :GE400-NUM-APOLICE AND COD_PRODUTO = :GE400-COD-PRODUTO AND NUM_CPF = :GE400-NUM-CPF AND STA_IS_SUPERIOR = 'A' WITH UR END-EXEC */

            var r1111_00_TRATAR_VR_IS_SUPERIOR_DB_SELECT_1_Query1 = new R1111_00_TRATAR_VR_IS_SUPERIOR_DB_SELECT_1_Query1()
            {
                GE400_NUM_APOLICE = GE400.DCLGE_IS_SUPERIOR.GE400_NUM_APOLICE.ToString(),
                GE400_COD_PRODUTO = GE400.DCLGE_IS_SUPERIOR.GE400_COD_PRODUTO.ToString(),
                GE400_NUM_CPF = GE400.DCLGE_IS_SUPERIOR.GE400_NUM_CPF.ToString(),
            };

            var executed_1 = R1111_00_TRATAR_VR_IS_SUPERIOR_DB_SELECT_1_Query1.Execute(r1111_00_TRATAR_VR_IS_SUPERIOR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_CADASTRO_IS_SUPERIOR, WS_CADASTRO_IS_SUPERIOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1111_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-SELECT-ESTIPULANTE-SECTION */
        private void R1200_00_SELECT_ESTIPULANTE_SECTION()
        {
            /*" -3170- MOVE '1200-00-SELECT-ESTIPULANTE   ' TO PARAGRAFO. */
            _.Move("1200-00-SELECT-ESTIPULANTE   ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3171- MOVE 06 TO SII. */
            _.Move(06, WS_HORAS.SII);

            /*" -3172- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -3179- PERFORM R1200_00_SELECT_ESTIPULANTE_DB_SELECT_1 */

            R1200_00_SELECT_ESTIPULANTE_DB_SELECT_1();

            /*" -3182- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -3183- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -3184- DISPLAY 'PROBLEMAS NO SELECT A ESTIPULANTE       ' */
                _.Display($"PROBLEMAS NO SELECT A ESTIPULANTE       ");

                /*" -3184- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1200-00-SELECT-ESTIPULANTE-DB-SELECT-1 */
        public void R1200_00_SELECT_ESTIPULANTE_DB_SELECT_1()
        {
            /*" -3179- EXEC SQL SELECT NOME_ESTIPULANTE INTO :DCLESTIPULANTE.ESTIPULA-NOME-ESTIPULANTE FROM SEGUROS.ESTIPULANTE WHERE COD_CCT = :DCLPROPOSTA-FIDELIZ.PROPOFID-CGC-CONVENENTE AND DATA_TERVIGENCIA = '9999-12-31' END-EXEC. */

            var r1200_00_SELECT_ESTIPULANTE_DB_SELECT_1_Query1 = new R1200_00_SELECT_ESTIPULANTE_DB_SELECT_1_Query1()
            {
                PROPOFID_CGC_CONVENENTE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CGC_CONVENENTE.ToString(),
            };

            var executed_1 = R1200_00_SELECT_ESTIPULANTE_DB_SELECT_1_Query1.Execute(r1200_00_SELECT_ESTIPULANTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ESTIPULA_NOME_ESTIPULANTE, ESTIPULA.DCLESTIPULANTE.ESTIPULA_NOME_ESTIPULANTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1250-00-SELECT-OPCAOPAGVA-SECTION */
        private void R1250_00_SELECT_OPCAOPAGVA_SECTION()
        {
            /*" -3194- MOVE '1250-00-SELECT-OPCAOPAGVA   ' TO PARAGRAFO. */
            _.Move("1250-00-SELECT-OPCAOPAGVA   ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3195- MOVE 07 TO SII. */
            _.Move(07, WS_HORAS.SII);

            /*" -3196- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -3212- PERFORM R1250_00_SELECT_OPCAOPAGVA_DB_SELECT_1 */

            R1250_00_SELECT_OPCAOPAGVA_DB_SELECT_1();

            /*" -3215- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -3216- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -3217- DISPLAY 'PROBLEMAS NO SELECT A OPCAOPAGVA       ' */
                _.Display($"PROBLEMAS NO SELECT A OPCAOPAGVA       ");

                /*" -3219- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3220- IF VIND-AGECTADEB LESS +0 */

            if (VIND_AGECTADEB < +0)
            {

                /*" -3222- MOVE ZEROS TO OPCPAGVI-COD-AGENCIA-DEBITO. */
                _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO);
            }


            /*" -3223- IF VIND-OPRCTADEB LESS +0 */

            if (VIND_OPRCTADEB < +0)
            {

                /*" -3225- MOVE ZEROS TO OPCPAGVI-OPE-CONTA-DEBITO. */
                _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO);
            }


            /*" -3226- IF VIND-NUMCTADEB LESS +0 */

            if (VIND_NUMCTADEB < +0)
            {

                /*" -3228- MOVE ZEROS TO OPCPAGVI-NUM-CONTA-DEBITO. */
                _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO);
            }


            /*" -3229- IF VIND-DIGCTADEB LESS +0 */

            if (VIND_DIGCTADEB < +0)
            {

                /*" -3231- MOVE ZEROS TO OPCPAGVI-DIG-CONTA-DEBITO. */
                _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO);
            }


            /*" -3232- IF VIND-CARTAO LESS +0 */

            if (VIND_CARTAO < +0)
            {

                /*" -3233- MOVE ZEROS TO OPCPAGVI-NUM-CARTAO-CREDITO. */
                _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO);
            }


        }

        [StopWatch]
        /*" R1250-00-SELECT-OPCAOPAGVA-DB-SELECT-1 */
        public void R1250_00_SELECT_OPCAOPAGVA_DB_SELECT_1()
        {
            /*" -3212- EXEC SQL SELECT COD_AGENCIA_DEBITO, OPE_CONTA_DEBITO, NUM_CONTA_DEBITO, DIG_CONTA_DEBITO, NUM_CARTAO_CREDITO INTO :OPCPAGVI-COD-AGENCIA-DEBITO:VIND-AGECTADEB , :OPCPAGVI-OPE-CONTA-DEBITO :VIND-OPRCTADEB , :OPCPAGVI-NUM-CONTA-DEBITO :VIND-NUMCTADEB , :OPCPAGVI-DIG-CONTA-DEBITO :VIND-DIGCTADEB , :OPCPAGVI-NUM-CARTAO-CREDITO:VIND-CARTAO FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO = :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF AND DATA_TERVIGENCIA = '9999-12-31' END-EXEC. */

            var r1250_00_SELECT_OPCAOPAGVA_DB_SELECT_1_Query1 = new R1250_00_SELECT_OPCAOPAGVA_DB_SELECT_1_Query1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = R1250_00_SELECT_OPCAOPAGVA_DB_SELECT_1_Query1.Execute(r1250_00_SELECT_OPCAOPAGVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OPCPAGVI_COD_AGENCIA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO);
                _.Move(executed_1.VIND_AGECTADEB, VIND_AGECTADEB);
                _.Move(executed_1.OPCPAGVI_OPE_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO);
                _.Move(executed_1.VIND_OPRCTADEB, VIND_OPRCTADEB);
                _.Move(executed_1.OPCPAGVI_NUM_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO);
                _.Move(executed_1.VIND_NUMCTADEB, VIND_NUMCTADEB);
                _.Move(executed_1.OPCPAGVI_DIG_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO);
                _.Move(executed_1.VIND_DIGCTADEB, VIND_DIGCTADEB);
                _.Move(executed_1.OPCPAGVI_NUM_CARTAO_CREDITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO);
                _.Move(executed_1.VIND_CARTAO, VIND_CARTAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1250_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-SELECT-FUNCIOCEF-SECTION */
        private void R1300_00_SELECT_FUNCIOCEF_SECTION()
        {
            /*" -3242- MOVE '1300-00-SELECT-FUNCIOCEF     ' TO PARAGRAFO. */
            _.Move("1300-00-SELECT-FUNCIOCEF     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3243- MOVE 08 TO SII. */
            _.Move(08, WS_HORAS.SII);

            /*" -3244- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -3250- PERFORM R1300_00_SELECT_FUNCIOCEF_DB_SELECT_1 */

            R1300_00_SELECT_FUNCIOCEF_DB_SELECT_1();

            /*" -3253- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -3254- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -3255- DISPLAY 'PROBLEMAS NO SELECT A FUNCIOCEF         ' */
                _.Display($"PROBLEMAS NO SELECT A FUNCIOCEF         ");

                /*" -3255- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1300-00-SELECT-FUNCIOCEF-DB-SELECT-1 */
        public void R1300_00_SELECT_FUNCIOCEF_DB_SELECT_1()
        {
            /*" -3250- EXEC SQL SELECT NOME_FUNCIONARIO INTO :DCLFUNCIONARIOS-CEF.FUNCICEF-NOME-FUNCIONARIO FROM SEGUROS.FUNCIONARIOS_CEF WHERE NUM_MATRICULA = :DCLPROPOSTA-FIDELIZ.PROPOFID-NRMATRVEN END-EXEC. */

            var r1300_00_SELECT_FUNCIOCEF_DB_SELECT_1_Query1 = new R1300_00_SELECT_FUNCIOCEF_DB_SELECT_1_Query1()
            {
                PROPOFID_NRMATRVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN.ToString(),
            };

            var executed_1 = R1300_00_SELECT_FUNCIOCEF_DB_SELECT_1_Query1.Execute(r1300_00_SELECT_FUNCIOCEF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FUNCICEF_NOME_FUNCIONARIO, FUNCICEF.DCLFUNCIONARIOS_CEF.FUNCICEF_NOME_FUNCIONARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-SELECT-PLANOS-VA-SECTION */
        private void R1400_00_SELECT_PLANOS_VA_SECTION()
        {
            /*" -3265- MOVE '1400-00-SELECT-PLANOS-VA     ' TO PARAGRAFO. */
            _.Move("1400-00-SELECT-PLANOS-VA     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3266- MOVE DATA-NASCIMENTO OF DCLPESSOA-FISICA TO WS-DTNASC. */
            _.Move(PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO, WORK_AREA.WS_DTNASC);

            /*" -3269- MOVE PROPOFID-DATA-PROPOSTA OF DCLPROPOSTA-FIDELIZ TO WS-DTPROP. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA, WORK_AREA.WS_DTPROP);

            /*" -3272- COMPUTE WHOST-IDADE = WS-AA-DTPROP - WS-AA-DTNASC. */
            WHOST_IDADE.Value = WORK_AREA.WS_DTPROP.WS_AA_DTPROP - WORK_AREA.WS_DTNASC.WS_AA_DTNASC;

            /*" -3273- IF WS-MM-DTNASC GREATER WS-MM-DTPROP */

            if (WORK_AREA.WS_DTNASC.WS_MM_DTNASC > WORK_AREA.WS_DTPROP.WS_MM_DTPROP)
            {

                /*" -3274- SUBTRACT 1 FROM WHOST-IDADE */
                WHOST_IDADE.Value = WHOST_IDADE - 1;

                /*" -3275- ELSE */
            }
            else
            {


                /*" -3276- IF WS-MM-DTNASC EQUAL WS-MM-DTPROP */

                if (WORK_AREA.WS_DTNASC.WS_MM_DTNASC == WORK_AREA.WS_DTPROP.WS_MM_DTPROP)
                {

                    /*" -3277- IF WS-DD-DTNASC GREATER WS-DD-DTPROP */

                    if (WORK_AREA.WS_DTNASC.WS_DD_DTNASC > WORK_AREA.WS_DTPROP.WS_DD_DTPROP)
                    {

                        /*" -3279- SUBTRACT 1 FROM WHOST-IDADE. */
                        WHOST_IDADE.Value = WHOST_IDADE - 1;
                    }

                }

            }


            /*" -3281- MOVE '1400-00-SELECT-PLANOS-VA-VGAP' TO PARAGRAFO. */
            _.Move("1400-00-SELECT-PLANOS-VA-VGAP", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3282- MOVE 09 TO SII. */
            _.Move(09, WS_HORAS.SII);

            /*" -3283- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -3333- PERFORM R1400_00_SELECT_PLANOS_VA_DB_SELECT_1 */

            R1400_00_SELECT_PLANOS_VA_DB_SELECT_1();

            /*" -3336- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -3337- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3338- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -3340- DISPLAY 'VP0601B - PROBLEMAS NO SELECT PLANOS_VA_VGAP' SQLCODE */
                    _.Display($"VP0601B - PROBLEMAS NO SELECT PLANOS_VA_VGAP{DB.SQLCODE}");

                    /*" -3342- DISPLAY '          PROPOSTA PROCESSADA...............' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          PROPOSTA PROCESSADA...............{PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -3343- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3345- ELSE NEXT SENTENCE */
                }
                else
                {


                    /*" -3346- ELSE */
                }

            }
            else
            {


                /*" -3348- MOVE 1 TO W-PLANO. */
                _.Move(1, WORK_AREA.W_PLANO);
            }


            /*" -3350- MOVE '1400-01-SELECT-PLANOS-VA-VGAP' TO PARAGRAFO. */
            _.Move("1400-01-SELECT-PLANOS-VA-VGAP", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3351- MOVE 09 TO SII. */
            _.Move(09, WS_HORAS.SII);

            /*" -3352- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -3366- PERFORM R1400_00_SELECT_PLANOS_VA_DB_SELECT_2 */

            R1400_00_SELECT_PLANOS_VA_DB_SELECT_2();

            /*" -3367- PERFORM R9100-00-TERMINO. */

            R9100_00_TERMINO_SECTION();

        }

        [StopWatch]
        /*" R1400-00-SELECT-PLANOS-VA-DB-SELECT-1 */
        public void R1400_00_SELECT_PLANOS_VA_DB_SELECT_1()
        {
            /*" -3333- EXEC SQL SELECT IMPMORNATU, IMPMORACID, IMPINVPERM, IMPAMDS, IMPDH, IMPDIT, VLPREMIOTOT, PRMVG, PRMAP, QTTITCAP, VLTITCAP, VLCUSTCAP, IMPSEGCDG, VLCUSTCDG, IMPSEGAUXF, VLCUSTAUXF, PRMDIT, QTDIT INTO :DCLPLANOS-VA-VGAP.IMPMORNATU, :DCLPLANOS-VA-VGAP.IMPMORACID, :DCLPLANOS-VA-VGAP.IMPINVPERM, :DCLPLANOS-VA-VGAP.IMPAMDS, :DCLPLANOS-VA-VGAP.IMPDH, :DCLPLANOS-VA-VGAP.IMPDIT, :DCLPLANOS-VA-VGAP.VLPREMIOTOT, :DCLPLANOS-VA-VGAP.PRMVG, :DCLPLANOS-VA-VGAP.PRMAP, :DCLPLANOS-VA-VGAP.QTTITCAP, :DCLPLANOS-VA-VGAP.VLTITCAP, :DCLPLANOS-VA-VGAP.VLCUSTCAP, :DCLPLANOS-VA-VGAP.IMPSEGCDG, :DCLPLANOS-VA-VGAP.VLCUSTCDG, :DCLPLANOS-VA-VGAP.IMPSEGAUXF, :DCLPLANOS-VA-VGAP.VLCUSTAUXF, :DCLPLANOS-VA-VGAP.PRMDIT, :DCLPLANOS-VA-VGAP.QTDIT FROM SEGUROS.PLANOS_VA_VGAP WHERE NUM_APOLICE = :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE AND CODSUBES = :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO AND OPCAO_COBER = :DCLPROPOSTA-FIDELIZ.PROPOFID-OPCAO-COBER AND DTINIVIG <= :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO AND DTTERVIG >= :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO AND IDADE_INICIAL <= :WHOST-IDADE AND IDADE_FINAL >= :WHOST-IDADE END-EXEC. */

            var r1400_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1 = new R1400_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1()
            {
                PROPSSVD_COD_SUBGRUPO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.ToString(),
                PROPOFID_OPCAO_COBER = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER.ToString(),
                PROPSSVD_NUM_APOLICE = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.ToString(),
                PROPOFID_DTQITBCO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.ToString(),
                WHOST_IDADE = WHOST_IDADE.ToString(),
            };

            var executed_1 = R1400_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1.Execute(r1400_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.IMPMORNATU, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU);
                _.Move(executed_1.IMPMORACID, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORACID);
                _.Move(executed_1.IMPINVPERM, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPINVPERM);
                _.Move(executed_1.IMPAMDS, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPAMDS);
                _.Move(executed_1.IMPDH, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPDH);
                _.Move(executed_1.IMPDIT, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPDIT);
                _.Move(executed_1.VLPREMIOTOT, PLVAVGAP.DCLPLANOS_VA_VGAP.VLPREMIOTOT);
                _.Move(executed_1.PRMVG, PLVAVGAP.DCLPLANOS_VA_VGAP.PRMVG);
                _.Move(executed_1.PRMAP, PLVAVGAP.DCLPLANOS_VA_VGAP.PRMAP);
                _.Move(executed_1.QTTITCAP, PLVAVGAP.DCLPLANOS_VA_VGAP.QTTITCAP);
                _.Move(executed_1.VLTITCAP, PLVAVGAP.DCLPLANOS_VA_VGAP.VLTITCAP);
                _.Move(executed_1.VLCUSTCAP, PLVAVGAP.DCLPLANOS_VA_VGAP.VLCUSTCAP);
                _.Move(executed_1.IMPSEGCDG, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPSEGCDG);
                _.Move(executed_1.VLCUSTCDG, PLVAVGAP.DCLPLANOS_VA_VGAP.VLCUSTCDG);
                _.Move(executed_1.IMPSEGAUXF, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPSEGAUXF);
                _.Move(executed_1.VLCUSTAUXF, PLVAVGAP.DCLPLANOS_VA_VGAP.VLCUSTAUXF);
                _.Move(executed_1.PRMDIT, PLVAVGAP.DCLPLANOS_VA_VGAP.PRMDIT);
                _.Move(executed_1.QTDIT, PLVAVGAP.DCLPLANOS_VA_VGAP.QTDIT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-SELECT-PLANOS-VA-DB-SELECT-2 */
        public void R1400_00_SELECT_PLANOS_VA_DB_SELECT_2()
        {
            /*" -3366- EXEC SQL SELECT VALUE (MAX(IMPMORNATU),0) INTO :WHOST-IMPMORNATU-MAX FROM SEGUROS.PLANOS_VA_VGAP WHERE NUM_APOLICE = :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE AND CODSUBES = :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO AND DTINIVIG <= :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO AND DTTERVIG >= :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO AND IDADE_INICIAL <= :WHOST-IDADE AND IDADE_FINAL >= :WHOST-IDADE END-EXEC. */

            var r1400_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1 = new R1400_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1()
            {
                PROPSSVD_COD_SUBGRUPO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.ToString(),
                PROPSSVD_NUM_APOLICE = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.ToString(),
                PROPOFID_DTQITBCO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.ToString(),
                WHOST_IDADE = WHOST_IDADE.ToString(),
            };

            var executed_1 = R1400_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1.Execute(r1400_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_IMPMORNATU_MAX, WHOST_IMPMORNATU_MAX);
            }


        }

        [StopWatch]
        /*" R1401-00-SELECT-PLANOS-VA-SECTION */
        private void R1401_00_SELECT_PLANOS_VA_SECTION()
        {
            /*" -3378- MOVE '1401-00-SELECT-PLANOS-VA     ' TO PARAGRAFO. */
            _.Move("1401-00-SELECT-PLANOS-VA     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3379- MOVE DATA-NASCIMENTO OF DCLPESSOA-FISICA TO WS-DTNASC. */
            _.Move(PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO, WORK_AREA.WS_DTNASC);

            /*" -3382- MOVE PROPOFID-DATA-PROPOSTA OF DCLPROPOSTA-FIDELIZ TO WS-DTPROP. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA, WORK_AREA.WS_DTPROP);

            /*" -3385- COMPUTE WHOST-IDADE = WS-AA-DTPROP - WS-AA-DTNASC. */
            WHOST_IDADE.Value = WORK_AREA.WS_DTPROP.WS_AA_DTPROP - WORK_AREA.WS_DTNASC.WS_AA_DTNASC;

            /*" -3386- IF WS-MM-DTNASC GREATER WS-MM-DTPROP */

            if (WORK_AREA.WS_DTNASC.WS_MM_DTNASC > WORK_AREA.WS_DTPROP.WS_MM_DTPROP)
            {

                /*" -3387- SUBTRACT 1 FROM WHOST-IDADE */
                WHOST_IDADE.Value = WHOST_IDADE - 1;

                /*" -3388- ELSE */
            }
            else
            {


                /*" -3389- IF WS-MM-DTNASC EQUAL WS-MM-DTPROP */

                if (WORK_AREA.WS_DTNASC.WS_MM_DTNASC == WORK_AREA.WS_DTPROP.WS_MM_DTPROP)
                {

                    /*" -3390- IF WS-DD-DTNASC GREATER WS-DD-DTPROP */

                    if (WORK_AREA.WS_DTNASC.WS_DD_DTNASC > WORK_AREA.WS_DTPROP.WS_DD_DTPROP)
                    {

                        /*" -3392- SUBTRACT 1 FROM WHOST-IDADE. */
                        WHOST_IDADE.Value = WHOST_IDADE - 1;
                    }

                }

            }


            /*" -3394- MOVE '1401-00-SELECT-PLANOS-VA-VGAP' TO PARAGRAFO. */
            _.Move("1401-00-SELECT-PLANOS-VA-VGAP", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3395- MOVE 77 TO SII. */
            _.Move(77, WS_HORAS.SII);

            /*" -3396- PERFORM R9000-00-INICIO. */

            R9000_00_INICIO_SECTION();

            /*" -3412- PERFORM R1401_00_SELECT_PLANOS_VA_DB_SELECT_1 */

            R1401_00_SELECT_PLANOS_VA_DB_SELECT_1();

            /*" -3415- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -3416- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3417- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -3419- DISPLAY 'VP0601B - PROBLEMAS NO SELECT PLANOS_VA_VGAP' SQLCODE */
                    _.Display($"VP0601B - PROBLEMAS NO SELECT PLANOS_VA_VGAP{DB.SQLCODE}");

                    /*" -3421- DISPLAY 'R1401  -  PROPOSTA PROCESSADA...............' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"R1401  -  PROPOSTA PROCESSADA...............{PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -3422- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3423- ELSE */
                }
                else
                {


                    /*" -3429- DISPLAY 'R1401 NAO ENCONTROU PLANOS-VA-VGAP ' PROPSSVD-NUM-APOLICE ' ' PROPSSVD-COD-SUBGRUPO ' ' PROPOFID-OPCAO-COBER ' ' PROPOFID-DTQITBCO ' ' WHOST-IDADE. */

                    $"R1401 NAO ENCONTROU PLANOS-VA-VGAP {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE} {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO} {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER} {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO} {WHOST_IDADE}"
                    .Display();
                }

            }


        }

        [StopWatch]
        /*" R1401-00-SELECT-PLANOS-VA-DB-SELECT-1 */
        public void R1401_00_SELECT_PLANOS_VA_DB_SELECT_1()
        {
            /*" -3412- EXEC SQL SELECT VALUE (IMPMORNATU,0) INTO :WHOST-IMPMORNATU FROM SEGUROS.PLANOS_VA_VGAP WHERE NUM_APOLICE = :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE AND CODSUBES = :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO AND OPCAO_COBER = :DCLPROPOSTA-FIDELIZ.PROPOFID-OPCAO-COBER AND DTINIVIG <= :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO AND DTTERVIG >= :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO AND IDADE_INICIAL <= :WHOST-IDADE AND IDADE_FINAL >= :WHOST-IDADE END-EXEC. */

            var r1401_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1 = new R1401_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1()
            {
                PROPSSVD_COD_SUBGRUPO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.ToString(),
                PROPOFID_OPCAO_COBER = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER.ToString(),
                PROPSSVD_NUM_APOLICE = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.ToString(),
                PROPOFID_DTQITBCO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.ToString(),
                WHOST_IDADE = WHOST_IDADE.ToString(),
            };

            var executed_1 = R1401_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1.Execute(r1401_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_IMPMORNATU, WHOST_IMPMORNATU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1401_99_SAIDA*/

        [StopWatch]
        /*" R1410-00-SELECT-PLANOS-VA-SECTION */
        private void R1410_00_SELECT_PLANOS_VA_SECTION()
        {
            /*" -3438- MOVE '1410-00-SELECT-PLANOS-VA     ' TO PARAGRAFO. */
            _.Move("1410-00-SELECT-PLANOS-VA     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3439- MOVE DATA-NASCIMENTO OF DCLPESSOA-FISICA TO WS-DTNASC. */
            _.Move(PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO, WORK_AREA.WS_DTNASC);

            /*" -3442- MOVE PROPOFID-DATA-PROPOSTA OF DCLPROPOSTA-FIDELIZ TO WS-DTPROP. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA, WORK_AREA.WS_DTPROP);

            /*" -3445- COMPUTE WHOST-IDADE = WS-AA-DTPROP - WS-AA-DTNASC. */
            WHOST_IDADE.Value = WORK_AREA.WS_DTPROP.WS_AA_DTPROP - WORK_AREA.WS_DTNASC.WS_AA_DTNASC;

            /*" -3446- IF WS-MM-DTNASC GREATER WS-MM-DTPROP */

            if (WORK_AREA.WS_DTNASC.WS_MM_DTNASC > WORK_AREA.WS_DTPROP.WS_MM_DTPROP)
            {

                /*" -3447- SUBTRACT 1 FROM WHOST-IDADE */
                WHOST_IDADE.Value = WHOST_IDADE - 1;

                /*" -3448- ELSE */
            }
            else
            {


                /*" -3449- IF WS-MM-DTNASC EQUAL WS-MM-DTPROP */

                if (WORK_AREA.WS_DTNASC.WS_MM_DTNASC == WORK_AREA.WS_DTPROP.WS_MM_DTPROP)
                {

                    /*" -3450- IF WS-DD-DTNASC GREATER WS-DD-DTPROP */

                    if (WORK_AREA.WS_DTNASC.WS_DD_DTNASC > WORK_AREA.WS_DTPROP.WS_DD_DTPROP)
                    {

                        /*" -3452- SUBTRACT 1 FROM WHOST-IDADE. */
                        WHOST_IDADE.Value = WHOST_IDADE - 1;
                    }

                }

            }


            /*" -3454- IF WHOST-IDADE GREATER 65 AND CANAL-SASSE-FILIAL */

            if (WHOST_IDADE > 65 && WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_SASSE_FILIAL"])
            {

                /*" -3455- MOVE WHOST-DATA-NASCIMENTO-7708 TO WS-DTNASC */
                _.Move(WHOST_DATA_NASCIMENTO_7708, WORK_AREA.WS_DTNASC);

                /*" -3458- COMPUTE WHOST-IDADE = WS-AA-DTPROP - WS-AA-DTNASC */
                WHOST_IDADE.Value = WORK_AREA.WS_DTPROP.WS_AA_DTPROP - WORK_AREA.WS_DTNASC.WS_AA_DTNASC;

                /*" -3459- IF WS-MM-DTNASC GREATER WS-MM-DTPROP */

                if (WORK_AREA.WS_DTNASC.WS_MM_DTNASC > WORK_AREA.WS_DTPROP.WS_MM_DTPROP)
                {

                    /*" -3460- SUBTRACT 1 FROM WHOST-IDADE */
                    WHOST_IDADE.Value = WHOST_IDADE - 1;

                    /*" -3461- ELSE */
                }
                else
                {


                    /*" -3462- IF WS-MM-DTNASC EQUAL WS-MM-DTPROP */

                    if (WORK_AREA.WS_DTNASC.WS_MM_DTNASC == WORK_AREA.WS_DTPROP.WS_MM_DTPROP)
                    {

                        /*" -3463- IF WS-DD-DTNASC GREATER WS-DD-DTPROP */

                        if (WORK_AREA.WS_DTNASC.WS_DD_DTNASC > WORK_AREA.WS_DTPROP.WS_DD_DTPROP)
                        {

                            /*" -3465- SUBTRACT 1 FROM WHOST-IDADE. */
                            WHOST_IDADE.Value = WHOST_IDADE - 1;
                        }

                    }

                }

            }


            /*" -3466- IF NOVO-CALCULO-PREMIO */

            if (WORK_AREA.W_NOVO_CALCULO["NOVO_CALCULO_PREMIO"])
            {

                /*" -3467- PERFORM R1420-00-SELECT-PLANOS-VA */

                R1420_00_SELECT_PLANOS_VA_SECTION();

                /*" -3470- GO TO R1410-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1410_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3472- MOVE '1410-00-SELECT-PLANOS-VA-VGAP' TO PARAGRAFO. */
            _.Move("1410-00-SELECT-PLANOS-VA-VGAP", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3473- MOVE 09 TO SII. */
            _.Move(09, WS_HORAS.SII);

            /*" -3474- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -3536- PERFORM R1410_00_SELECT_PLANOS_VA_DB_SELECT_1 */

            R1410_00_SELECT_PLANOS_VA_DB_SELECT_1();

            /*" -3539- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -3540- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3541- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -3543- DISPLAY 'VP0601B - ERRO NO SELECT PLANOS_VA_VGAP2 ' SQLCODE */
                    _.Display($"VP0601B - ERRO NO SELECT PLANOS_VA_VGAP2 {DB.SQLCODE}");

                    /*" -3545- DISPLAY '          PROPOSTA PROCESSADA...............' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          PROPOSTA PROCESSADA...............{PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -3546- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3548- ELSE NEXT SENTENCE */
                }
                else
                {


                    /*" -3549- ELSE */
                }

            }
            else
            {


                /*" -3551- MOVE 1 TO W-PLANO. */
                _.Move(1, WORK_AREA.W_PLANO);
            }


            /*" -3553- MOVE '1410-01-SELECT-PLANOS-VA-VGAP' TO PARAGRAFO. */
            _.Move("1410-01-SELECT-PLANOS-VA-VGAP", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3554- MOVE 09 TO SII. */
            _.Move(09, WS_HORAS.SII);

            /*" -3555- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -3573- PERFORM R1410_00_SELECT_PLANOS_VA_DB_SELECT_2 */

            R1410_00_SELECT_PLANOS_VA_DB_SELECT_2();

            /*" -3574- PERFORM R9100-00-TERMINO. */

            R9100_00_TERMINO_SECTION();

        }

        [StopWatch]
        /*" R1410-00-SELECT-PLANOS-VA-DB-SELECT-1 */
        public void R1410_00_SELECT_PLANOS_VA_DB_SELECT_1()
        {
            /*" -3536- EXEC SQL SELECT IMPMORNATU, IMPMORACID, IMPINVPERM, IMPAMDS, IMPDH, IMPDIT, VLPREMIOTOT, PRMVG, PRMAP, TAXAVG, COD_PLANO, QTTITCAP, VLTITCAP, VLCUSTCAP, IMPSEGCDG, VLCUSTCDG, IMPSEGAUXF, VLCUSTAUXF, PRMDIT, QTDIT, FAIXA_SAL_FIM INTO :DCLPLANOS-VA-VGAP.IMPMORNATU, :DCLPLANOS-VA-VGAP.IMPMORACID, :DCLPLANOS-VA-VGAP.IMPINVPERM, :DCLPLANOS-VA-VGAP.IMPAMDS, :DCLPLANOS-VA-VGAP.IMPDH, :DCLPLANOS-VA-VGAP.IMPDIT, :DCLPLANOS-VA-VGAP.VLPREMIOTOT, :DCLPLANOS-VA-VGAP.PRMVG, :DCLPLANOS-VA-VGAP.PRMAP, :DCLPLANOS-VA-VGAP.TAXAVG, :DCLPLANOS-VA-VGAP.COD-PLANO, :DCLPLANOS-VA-VGAP.QTTITCAP, :DCLPLANOS-VA-VGAP.VLTITCAP, :DCLPLANOS-VA-VGAP.VLCUSTCAP, :DCLPLANOS-VA-VGAP.IMPSEGCDG, :DCLPLANOS-VA-VGAP.VLCUSTCDG, :DCLPLANOS-VA-VGAP.IMPSEGAUXF, :DCLPLANOS-VA-VGAP.VLCUSTAUXF, :DCLPLANOS-VA-VGAP.PRMDIT, :DCLPLANOS-VA-VGAP.QTDIT, :DCLPLANOS-VA-VGAP.FAIXA-SAL-FIM FROM SEGUROS.PLANOS_VA_VGAP WHERE NUM_APOLICE = :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE AND CODSUBES = :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO AND COD_PLANO = :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PLANO AND OPCAO_COBER = :DCLPROPOSTA-FIDELIZ.PROPOFID-OPCAO-COBER AND DTINIVIG <= :DCLPROPOSTA-FIDELIZ.PROPOFID-DATA-PROPOSTA AND DTTERVIG >= :DCLPROPOSTA-FIDELIZ.PROPOFID-DATA-PROPOSTA AND IDADE_INICIAL <= :WHOST-IDADE AND IDADE_FINAL >= :WHOST-IDADE END-EXEC. */

            var r1410_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1 = new R1410_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1()
            {
                PROPOFID_DATA_PROPOSTA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA.ToString(),
                PROPSSVD_COD_SUBGRUPO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.ToString(),
                PROPOFID_OPCAO_COBER = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER.ToString(),
                PROPSSVD_NUM_APOLICE = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.ToString(),
                PROPOFID_COD_PLANO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO.ToString(),
                WHOST_IDADE = WHOST_IDADE.ToString(),
            };

            var executed_1 = R1410_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1.Execute(r1410_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.IMPMORNATU, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU);
                _.Move(executed_1.IMPMORACID, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORACID);
                _.Move(executed_1.IMPINVPERM, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPINVPERM);
                _.Move(executed_1.IMPAMDS, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPAMDS);
                _.Move(executed_1.IMPDH, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPDH);
                _.Move(executed_1.IMPDIT, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPDIT);
                _.Move(executed_1.VLPREMIOTOT, PLVAVGAP.DCLPLANOS_VA_VGAP.VLPREMIOTOT);
                _.Move(executed_1.PRMVG, PLVAVGAP.DCLPLANOS_VA_VGAP.PRMVG);
                _.Move(executed_1.PRMAP, PLVAVGAP.DCLPLANOS_VA_VGAP.PRMAP);
                _.Move(executed_1.TAXAVG, PLVAVGAP.DCLPLANOS_VA_VGAP.TAXAVG);
                _.Move(executed_1.COD_PLANO, PLVAVGAP.DCLPLANOS_VA_VGAP.COD_PLANO);
                _.Move(executed_1.QTTITCAP, PLVAVGAP.DCLPLANOS_VA_VGAP.QTTITCAP);
                _.Move(executed_1.VLTITCAP, PLVAVGAP.DCLPLANOS_VA_VGAP.VLTITCAP);
                _.Move(executed_1.VLCUSTCAP, PLVAVGAP.DCLPLANOS_VA_VGAP.VLCUSTCAP);
                _.Move(executed_1.IMPSEGCDG, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPSEGCDG);
                _.Move(executed_1.VLCUSTCDG, PLVAVGAP.DCLPLANOS_VA_VGAP.VLCUSTCDG);
                _.Move(executed_1.IMPSEGAUXF, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPSEGAUXF);
                _.Move(executed_1.VLCUSTAUXF, PLVAVGAP.DCLPLANOS_VA_VGAP.VLCUSTAUXF);
                _.Move(executed_1.PRMDIT, PLVAVGAP.DCLPLANOS_VA_VGAP.PRMDIT);
                _.Move(executed_1.QTDIT, PLVAVGAP.DCLPLANOS_VA_VGAP.QTDIT);
                _.Move(executed_1.FAIXA_SAL_FIM, PLVAVGAP.DCLPLANOS_VA_VGAP.FAIXA_SAL_FIM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1410_99_SAIDA*/

        [StopWatch]
        /*" R1410-00-SELECT-PLANOS-VA-DB-SELECT-2 */
        public void R1410_00_SELECT_PLANOS_VA_DB_SELECT_2()
        {
            /*" -3573- EXEC SQL SELECT VALUE (MAX(IMPMORNATU),0) INTO :WHOST-IMPMORNATU-MAX FROM SEGUROS.PLANOS_VA_VGAP WHERE NUM_APOLICE = :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE AND CODSUBES = :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO AND COD_PLANO = :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PLANO AND OPCAO_COBER = :DCLPROPOSTA-FIDELIZ.PROPOFID-OPCAO-COBER AND DTINIVIG <= :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO AND DTTERVIG >= :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO AND IDADE_INICIAL <= :WHOST-IDADE AND IDADE_FINAL >= :WHOST-IDADE END-EXEC. */

            var r1410_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1 = new R1410_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1()
            {
                PROPSSVD_COD_SUBGRUPO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.ToString(),
                PROPOFID_OPCAO_COBER = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER.ToString(),
                PROPSSVD_NUM_APOLICE = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.ToString(),
                PROPOFID_COD_PLANO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO.ToString(),
                PROPOFID_DTQITBCO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.ToString(),
                WHOST_IDADE = WHOST_IDADE.ToString(),
            };

            var executed_1 = R1410_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1.Execute(r1410_00_SELECT_PLANOS_VA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_IMPMORNATU_MAX, WHOST_IMPMORNATU_MAX);
            }


        }

        [StopWatch]
        /*" R1420-00-SELECT-PLANOS-VA-SECTION */
        private void R1420_00_SELECT_PLANOS_VA_SECTION()
        {
            /*" -3584- MOVE '1420-00-SELECT-PLANOS-VA     ' TO PARAGRAFO. */
            _.Move("1420-00-SELECT-PLANOS-VA     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3585- MOVE 09 TO SII. */
            _.Move(09, WS_HORAS.SII);

            /*" -3586- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -3643- PERFORM R1420_00_SELECT_PLANOS_VA_DB_SELECT_1 */

            R1420_00_SELECT_PLANOS_VA_DB_SELECT_1();

            /*" -3646- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -3647- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3648- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -3650- DISPLAY 'VP0601B - ERRO NO SELECT PLANOS_VA_VGAP3 ' SQLCODE */
                    _.Display($"VP0601B - ERRO NO SELECT PLANOS_VA_VGAP3 {DB.SQLCODE}");

                    /*" -3652- DISPLAY '          PROPOSTA PROCESSADA...............' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          PROPOSTA PROCESSADA...............{PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -3653- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3654- ELSE */
                }
                else
                {


                    /*" -3656- MOVE ZEROS TO WHOST-IMPMORNATU-MAX */
                    _.Move(0, WHOST_IMPMORNATU_MAX);

                    /*" -3657- ELSE */
                }

            }
            else
            {


                /*" -3658- MOVE 1 TO W-PLANO */
                _.Move(1, WORK_AREA.W_PLANO);

                /*" -3659- MOVE ZEROS TO WHOST-IMPMORNATU-MAX. */
                _.Move(0, WHOST_IMPMORNATU_MAX);
            }


        }

        [StopWatch]
        /*" R1420-00-SELECT-PLANOS-VA-DB-SELECT-1 */
        public void R1420_00_SELECT_PLANOS_VA_DB_SELECT_1()
        {
            /*" -3643- EXEC SQL SELECT IMPMORNATU, IMPMORACID, IMPINVPERM, IMPAMDS, IMPDH, IMPDIT, 0.0 VLPREMIOTOT, PRMVG, PRMAP, TAXAVG, COD_PLANO, QTTITCAP, VLTITCAP, VLCUSTCAP, IMPSEGCDG, VLCUSTCDG, IMPSEGAUXF, VLCUSTAUXF, PRMDIT, QTDIT, FAIXA_SAL_FIM INTO :DCLPLANOS-VA-VGAP.IMPMORNATU, :DCLPLANOS-VA-VGAP.IMPMORACID, :DCLPLANOS-VA-VGAP.IMPINVPERM, :DCLPLANOS-VA-VGAP.IMPAMDS, :DCLPLANOS-VA-VGAP.IMPDH, :DCLPLANOS-VA-VGAP.IMPDIT, :DCLPLANOS-VA-VGAP.VLPREMIOTOT, :DCLPLANOS-VA-VGAP.PRMVG, :DCLPLANOS-VA-VGAP.PRMAP, :DCLPLANOS-VA-VGAP.TAXAVG, :DCLPLANOS-VA-VGAP.COD-PLANO, :DCLPLANOS-VA-VGAP.QTTITCAP, :DCLPLANOS-VA-VGAP.VLTITCAP, :DCLPLANOS-VA-VGAP.VLCUSTCAP, :DCLPLANOS-VA-VGAP.IMPSEGCDG, :DCLPLANOS-VA-VGAP.VLCUSTCDG, :DCLPLANOS-VA-VGAP.IMPSEGAUXF, :DCLPLANOS-VA-VGAP.VLCUSTAUXF, :DCLPLANOS-VA-VGAP.PRMDIT, :DCLPLANOS-VA-VGAP.QTDIT, :DCLPLANOS-VA-VGAP.FAIXA-SAL-FIM FROM SEGUROS.PLANOS_VA_VGAP WHERE NUM_APOLICE = :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE AND CODSUBES = :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO AND COD_PLANO = :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PLANO AND OPCAO_COBER = ' ' AND DTINIVIG <= :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO AND DTTERVIG >= :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO AND IDADE_INICIAL <= :WHOST-IDADE AND IDADE_FINAL >= :WHOST-IDADE END-EXEC. */

            var r1420_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1 = new R1420_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1()
            {
                PROPSSVD_COD_SUBGRUPO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.ToString(),
                PROPSSVD_NUM_APOLICE = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.ToString(),
                PROPOFID_COD_PLANO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO.ToString(),
                PROPOFID_DTQITBCO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.ToString(),
                WHOST_IDADE = WHOST_IDADE.ToString(),
            };

            var executed_1 = R1420_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1.Execute(r1420_00_SELECT_PLANOS_VA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.IMPMORNATU, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU);
                _.Move(executed_1.IMPMORACID, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORACID);
                _.Move(executed_1.IMPINVPERM, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPINVPERM);
                _.Move(executed_1.IMPAMDS, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPAMDS);
                _.Move(executed_1.IMPDH, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPDH);
                _.Move(executed_1.IMPDIT, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPDIT);
                _.Move(executed_1.VLPREMIOTOT, PLVAVGAP.DCLPLANOS_VA_VGAP.VLPREMIOTOT);
                _.Move(executed_1.PRMVG, PLVAVGAP.DCLPLANOS_VA_VGAP.PRMVG);
                _.Move(executed_1.PRMAP, PLVAVGAP.DCLPLANOS_VA_VGAP.PRMAP);
                _.Move(executed_1.TAXAVG, PLVAVGAP.DCLPLANOS_VA_VGAP.TAXAVG);
                _.Move(executed_1.COD_PLANO, PLVAVGAP.DCLPLANOS_VA_VGAP.COD_PLANO);
                _.Move(executed_1.QTTITCAP, PLVAVGAP.DCLPLANOS_VA_VGAP.QTTITCAP);
                _.Move(executed_1.VLTITCAP, PLVAVGAP.DCLPLANOS_VA_VGAP.VLTITCAP);
                _.Move(executed_1.VLCUSTCAP, PLVAVGAP.DCLPLANOS_VA_VGAP.VLCUSTCAP);
                _.Move(executed_1.IMPSEGCDG, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPSEGCDG);
                _.Move(executed_1.VLCUSTCDG, PLVAVGAP.DCLPLANOS_VA_VGAP.VLCUSTCDG);
                _.Move(executed_1.IMPSEGAUXF, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPSEGAUXF);
                _.Move(executed_1.VLCUSTAUXF, PLVAVGAP.DCLPLANOS_VA_VGAP.VLCUSTAUXF);
                _.Move(executed_1.PRMDIT, PLVAVGAP.DCLPLANOS_VA_VGAP.PRMDIT);
                _.Move(executed_1.QTDIT, PLVAVGAP.DCLPLANOS_VA_VGAP.QTDIT);
                _.Move(executed_1.FAIXA_SAL_FIM, PLVAVGAP.DCLPLANOS_VA_VGAP.FAIXA_SAL_FIM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1420_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-SELECT-RCAPS-SECTION */
        private void R1500_00_SELECT_RCAPS_SECTION()
        {
            /*" -3669- MOVE '1500-00-SELECT-RCAPS         ' TO PARAGRAFO. */
            _.Move("1500-00-SELECT-RCAPS         ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3670- MOVE 10 TO SII. */
            _.Move(10, WS_HORAS.SII);

            /*" -3671- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -3681- PERFORM R1500_00_SELECT_RCAPS_DB_SELECT_1 */

            R1500_00_SELECT_RCAPS_DB_SELECT_1();

            /*" -3684- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -3686- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3689- PERFORM R1505-00-SELECT-RCAPS */

                R1505_00_SELECT_RCAPS_SECTION();

                /*" -3690- ELSE */
            }
            else
            {


                /*" -3690- MOVE 1 TO W-RCAPS. */
                _.Move(1, WORK_AREA.W_RCAPS);
            }


        }

        [StopWatch]
        /*" R1500-00-SELECT-RCAPS-DB-SELECT-1 */
        public void R1500_00_SELECT_RCAPS_DB_SELECT_1()
        {
            /*" -3681- EXEC SQL SELECT COD_FONTE, NUM_RCAP, VAL_RCAP INTO :DCLRCAPS.RCAPS-COD-FONTE, :DCLRCAPS.RCAPS-NUM-RCAP, :DCLRCAPS.RCAPS-VAL-RCAP FROM SEGUROS.RCAPS WHERE NUM_TITULO =:DCLRCAPS.RCAPS-NUM-TITULO AND COD_FONTE =:DCLRCAPS.RCAPS-COD-FONTE END-EXEC. */

            var r1500_00_SELECT_RCAPS_DB_SELECT_1_Query1 = new R1500_00_SELECT_RCAPS_DB_SELECT_1_Query1()
            {
                RCAPS_NUM_TITULO = RCAPS.DCLRCAPS.RCAPS_NUM_TITULO.ToString(),
                RCAPS_COD_FONTE = RCAPS.DCLRCAPS.RCAPS_COD_FONTE.ToString(),
            };

            var executed_1 = R1500_00_SELECT_RCAPS_DB_SELECT_1_Query1.Execute(r1500_00_SELECT_RCAPS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPS_COD_FONTE, RCAPS.DCLRCAPS.RCAPS_COD_FONTE);
                _.Move(executed_1.RCAPS_NUM_RCAP, RCAPS.DCLRCAPS.RCAPS_NUM_RCAP);
                _.Move(executed_1.RCAPS_VAL_RCAP, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1505-00-SELECT-RCAPS-SECTION */
        private void R1505_00_SELECT_RCAPS_SECTION()
        {
            /*" -3699- MOVE '1505-00-SELECT-RCAPS         ' TO PARAGRAFO. */
            _.Move("1505-00-SELECT-RCAPS         ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3700- MOVE 10 TO SII. */
            _.Move(10, WS_HORAS.SII);

            /*" -3701- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -3710- PERFORM R1505_00_SELECT_RCAPS_DB_SELECT_1 */

            R1505_00_SELECT_RCAPS_DB_SELECT_1();

            /*" -3713- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -3714- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3715- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -3716- DISPLAY 'VP0601B - PROBLEMAS NO ACESSO A RCAP' */
                    _.Display($"VP0601B - PROBLEMAS NO ACESSO A RCAP");

                    /*" -3718- DISPLAY '          NUMERO DO TITULO......... ' RCAPS-NUM-TITULO OF DCLRCAPS */
                    _.Display($"          NUMERO DO TITULO......... {RCAPS.DCLRCAPS.RCAPS_NUM_TITULO}");

                    /*" -3720- DISPLAY '          SQLCODE.................. ' SQLCODE */
                    _.Display($"          SQLCODE.................. {DB.SQLCODE}");

                    /*" -3721- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3723- ELSE NEXT SENTENCE */
                }
                else
                {


                    /*" -3724- ELSE */
                }

            }
            else
            {


                /*" -3724- MOVE 1 TO W-RCAPS. */
                _.Move(1, WORK_AREA.W_RCAPS);
            }


        }

        [StopWatch]
        /*" R1505-00-SELECT-RCAPS-DB-SELECT-1 */
        public void R1505_00_SELECT_RCAPS_DB_SELECT_1()
        {
            /*" -3710- EXEC SQL SELECT COD_FONTE, NUM_RCAP, VAL_RCAP INTO :DCLRCAPS.RCAPS-COD-FONTE, :DCLRCAPS.RCAPS-NUM-RCAP, :DCLRCAPS.RCAPS-VAL-RCAP FROM SEGUROS.RCAPS WHERE NUM_TITULO =:DCLRCAPS.RCAPS-NUM-TITULO END-EXEC. */

            var r1505_00_SELECT_RCAPS_DB_SELECT_1_Query1 = new R1505_00_SELECT_RCAPS_DB_SELECT_1_Query1()
            {
                RCAPS_NUM_TITULO = RCAPS.DCLRCAPS.RCAPS_NUM_TITULO.ToString(),
            };

            var executed_1 = R1505_00_SELECT_RCAPS_DB_SELECT_1_Query1.Execute(r1505_00_SELECT_RCAPS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPS_COD_FONTE, RCAPS.DCLRCAPS.RCAPS_COD_FONTE);
                _.Move(executed_1.RCAPS_NUM_RCAP, RCAPS.DCLRCAPS.RCAPS_NUM_RCAP);
                _.Move(executed_1.RCAPS_VAL_RCAP, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1505_99_SAIDA*/

        [StopWatch]
        /*" R1510-00-SELECT-RCAPCOMP-SECTION */
        private void R1510_00_SELECT_RCAPCOMP_SECTION()
        {
            /*" -3734- MOVE '1510-00-SELECT-RCAP COMP     ' TO PARAGRAFO. */
            _.Move("1510-00-SELECT-RCAP COMP     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3735- MOVE 11 TO SII. */
            _.Move(11, WS_HORAS.SII);

            /*" -3736- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -3752- PERFORM R1510_00_SELECT_RCAPCOMP_DB_SELECT_1 */

            R1510_00_SELECT_RCAPCOMP_DB_SELECT_1();

            /*" -3755- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -3757- IF SQLCODE EQUAL ZEROS NEXT SENTENCE */

            if (DB.SQLCODE == 00)
            {

                /*" -3758- ELSE */
            }
            else
            {


                /*" -3760- IF SQLCODE NOT EQUAL 100 AND SQLCODE NOT EQUAL -811 */

                if (DB.SQLCODE != 100 && DB.SQLCODE != -811)
                {

                    /*" -3761- DISPLAY 'VP0601B - PROBLEMAS NO ACESSO A RCAPCOMP' */
                    _.Display($"VP0601B - PROBLEMAS NO ACESSO A RCAPCOMP");

                    /*" -3763- DISPLAY '          CODIGO DA FONTE.............. ' RCAPS-COD-FONTE OF DCLRCAPS */
                    _.Display($"          CODIGO DA FONTE.............. {RCAPS.DCLRCAPS.RCAPS_COD_FONTE}");

                    /*" -3765- DISPLAY '          NUMERO DO RCAP............... ' RCAPS-NUM-RCAP OF DCLRCAPS */
                    _.Display($"          NUMERO DO RCAP............... {RCAPS.DCLRCAPS.RCAPS_NUM_RCAP}");

                    /*" -3767- DISPLAY '          SQLCODE...................... ' SQLCODE */
                    _.Display($"          SQLCODE...................... {DB.SQLCODE}");

                    /*" -3768- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3769- ELSE */
                }
                else
                {


                    /*" -3784- PERFORM R1510_00_SELECT_RCAPCOMP_DB_DECLARE_1 */

                    R1510_00_SELECT_RCAPCOMP_DB_DECLARE_1();

                    /*" -3787- MOVE 12 TO SII */
                    _.Move(12, WS_HORAS.SII);

                    /*" -3788- PERFORM R9000-00-INICIO */

                    R9000_00_INICIO_SECTION();

                    /*" -3788- PERFORM R1510_00_SELECT_RCAPCOMP_DB_OPEN_1 */

                    R1510_00_SELECT_RCAPCOMP_DB_OPEN_1();

                    /*" -3791- PERFORM R9100-00-TERMINO */

                    R9100_00_TERMINO_SECTION();

                    /*" -3792- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -3793- DISPLAY 'VP0601B - PROBLEMAS NO OPEN DA RCAPCOMP' */
                        _.Display($"VP0601B - PROBLEMAS NO OPEN DA RCAPCOMP");

                        /*" -3795- DISPLAY '          CODIGO DA FONTE.............. ' RCAPS-COD-FONTE OF DCLRCAPS */
                        _.Display($"          CODIGO DA FONTE.............. {RCAPS.DCLRCAPS.RCAPS_COD_FONTE}");

                        /*" -3797- DISPLAY '          NUMERO DO RCAP............... ' RCAPS-NUM-RCAP OF DCLRCAPS */
                        _.Display($"          NUMERO DO RCAP............... {RCAPS.DCLRCAPS.RCAPS_NUM_RCAP}");

                        /*" -3799- DISPLAY '          SQLCODE...................... ' SQLCODE */
                        _.Display($"          SQLCODE...................... {DB.SQLCODE}");

                        /*" -3800- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -3802- END-IF */
                    }


                    /*" -3803- MOVE 13 TO SII */
                    _.Move(13, WS_HORAS.SII);

                    /*" -3804- PERFORM R9000-00-INICIO */

                    R9000_00_INICIO_SECTION();

                    /*" -3815- PERFORM R1510_00_SELECT_RCAPCOMP_DB_FETCH_1 */

                    R1510_00_SELECT_RCAPCOMP_DB_FETCH_1();

                    /*" -3818- PERFORM R9100-00-TERMINO */

                    R9100_00_TERMINO_SECTION();

                    /*" -3819- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -3820- DISPLAY 'VP0601B - ERRO, RCAPCOMP NAO CADASTRADO' */
                        _.Display($"VP0601B - ERRO, RCAPCOMP NAO CADASTRADO");

                        /*" -3822- DISPLAY '          CODIGO DA FONTE.............. ' RCAPS-COD-FONTE OF DCLRCAPS */
                        _.Display($"          CODIGO DA FONTE.............. {RCAPS.DCLRCAPS.RCAPS_COD_FONTE}");

                        /*" -3824- DISPLAY '          NUMERO DO RCAP............... ' RCAPS-NUM-RCAP OF DCLRCAPS */
                        _.Display($"          NUMERO DO RCAP............... {RCAPS.DCLRCAPS.RCAPS_NUM_RCAP}");

                        /*" -3826- DISPLAY '          SQLCODE...................... ' SQLCODE */
                        _.Display($"          SQLCODE...................... {DB.SQLCODE}");

                        /*" -3827- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -3829- END-IF */
                    }


                    /*" -3829- PERFORM R1510_00_SELECT_RCAPCOMP_DB_CLOSE_1 */

                    R1510_00_SELECT_RCAPCOMP_DB_CLOSE_1();

                    /*" -3832- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -3833- DISPLAY 'VP0601B - PROBLEMAS NO CLOSE DA RCAPCOMP' */
                        _.Display($"VP0601B - PROBLEMAS NO CLOSE DA RCAPCOMP");

                        /*" -3835- DISPLAY '          CODIGO DA FONTE.............. ' RCAPS-COD-FONTE OF DCLRCAPS */
                        _.Display($"          CODIGO DA FONTE.............. {RCAPS.DCLRCAPS.RCAPS_COD_FONTE}");

                        /*" -3837- DISPLAY '          NUMERO DO RCAP............... ' RCAPS-NUM-RCAP OF DCLRCAPS */
                        _.Display($"          NUMERO DO RCAP............... {RCAPS.DCLRCAPS.RCAPS_NUM_RCAP}");

                        /*" -3839- DISPLAY '          SQLCODE...................... ' SQLCODE */
                        _.Display($"          SQLCODE...................... {DB.SQLCODE}");

                        /*" -3839- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


        }

        [StopWatch]
        /*" R1510-00-SELECT-RCAPCOMP-DB-SELECT-1 */
        public void R1510_00_SELECT_RCAPCOMP_DB_SELECT_1()
        {
            /*" -3752- EXEC SQL SELECT BCO_AVISO, AGE_AVISO, NUM_AVISO_CREDITO, DATA_MOVIMENTO, DATA_RCAP INTO :DCLRCAP-COMPLEMENTAR.RCAPCOMP-BCO-AVISO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-AGE-AVISO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-NUM-AVISO-CREDITO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-DATA-MOVIMENTO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-DATA-RCAP FROM SEGUROS.RCAP_COMPLEMENTAR WHERE COD_FONTE = :DCLRCAPS.RCAPS-COD-FONTE AND NUM_RCAP = :DCLRCAPS.RCAPS-NUM-RCAP AND NUM_RCAP_COMPLEMEN = 0 AND COD_OPERACAO BETWEEN 100 AND 199 END-EXEC. */

            var r1510_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1 = new R1510_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1()
            {
                RCAPS_COD_FONTE = RCAPS.DCLRCAPS.RCAPS_COD_FONTE.ToString(),
                RCAPS_NUM_RCAP = RCAPS.DCLRCAPS.RCAPS_NUM_RCAP.ToString(),
            };

            var executed_1 = R1510_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1.Execute(r1510_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPCOMP_BCO_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO);
                _.Move(executed_1.RCAPCOMP_AGE_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO);
                _.Move(executed_1.RCAPCOMP_NUM_AVISO_CREDITO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO);
                _.Move(executed_1.RCAPCOMP_DATA_MOVIMENTO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_MOVIMENTO);
                _.Move(executed_1.RCAPCOMP_DATA_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP);
            }


        }

        [StopWatch]
        /*" R1510-00-SELECT-RCAPCOMP-DB-OPEN-1 */
        public void R1510_00_SELECT_RCAPCOMP_DB_OPEN_1()
        {
            /*" -3788- EXEC SQL OPEN C01_RCAPCOMP END-EXEC */

            C01_RCAPCOMP.Open();

        }

        [StopWatch]
        /*" R2222-00-OBTER-ENDERECO-CORRES-DB-DECLARE-1 */
        public void R2222_00_OBTER_ENDERECO_CORRES_DB_DECLARE_1()
        {
            /*" -4280- EXEC SQL DECLARE CPESENDER CURSOR FOR SELECT OCORR_ENDERECO, ENDERECO, BAIRRO, CIDADE, CEP, SIGLA_UF FROM SEGUROS.PESSOA_ENDERECO WHERE COD_PESSOA = :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA AND TIPO_ENDER = 2 ORDER BY OCORR_ENDERECO DESC END-EXEC. */
            CPESENDER = new VP0601B_CPESENDER(true);
            string GetQuery_CPESENDER()
            {
                var query = @$"SELECT OCORR_ENDERECO
							, 
							ENDERECO
							, 
							BAIRRO
							, 
							CIDADE
							, 
							CEP
							, 
							SIGLA_UF 
							FROM SEGUROS.PESSOA_ENDERECO 
							WHERE COD_PESSOA = 
							'{PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA}' 
							AND TIPO_ENDER = 2 
							ORDER BY OCORR_ENDERECO DESC";

                return query;
            }
            CPESENDER.GetQueryEvent += GetQuery_CPESENDER;

        }

        [StopWatch]
        /*" R1510-00-SELECT-RCAPCOMP-DB-FETCH-1 */
        public void R1510_00_SELECT_RCAPCOMP_DB_FETCH_1()
        {
            /*" -3815- EXEC SQL FETCH C01_RCAPCOMP INTO :DCLRCAP-COMPLEMENTAR.RCAPCOMP-BCO-AVISO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-AGE-AVISO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-NUM-AVISO-CREDITO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-DATA-MOVIMENTO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-DATA-RCAP, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-COD-OPERACAO END-EXEC */

            if (C01_RCAPCOMP.Fetch())
            {
                _.Move(C01_RCAPCOMP.DCLRCAP_COMPLEMENTAR_RCAPCOMP_BCO_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO);
                _.Move(C01_RCAPCOMP.DCLRCAP_COMPLEMENTAR_RCAPCOMP_AGE_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO);
                _.Move(C01_RCAPCOMP.DCLRCAP_COMPLEMENTAR_RCAPCOMP_NUM_AVISO_CREDITO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO);
                _.Move(C01_RCAPCOMP.DCLRCAP_COMPLEMENTAR_RCAPCOMP_DATA_MOVIMENTO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_MOVIMENTO);
                _.Move(C01_RCAPCOMP.DCLRCAP_COMPLEMENTAR_RCAPCOMP_DATA_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP);
                _.Move(C01_RCAPCOMP.DCLRCAP_COMPLEMENTAR_RCAPCOMP_COD_OPERACAO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_OPERACAO);
            }

        }

        [StopWatch]
        /*" R1510-00-SELECT-RCAPCOMP-DB-CLOSE-1 */
        public void R1510_00_SELECT_RCAPCOMP_DB_CLOSE_1()
        {
            /*" -3829- EXEC SQL CLOSE C01_RCAPCOMP END-EXEC */

            C01_RCAPCOMP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1510_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-UPDATE-PROPFID-SECTION */
        private void R1600_00_UPDATE_PROPFID_SECTION()
        {
            /*" -3851- MOVE '1600-00-UPDATE-PROPFID       ' TO PARAGRAFO. */
            _.Move("1600-00-UPDATE-PROPFID       ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3858- IF WS-TEM-ERRO-1855 EQUAL 'SIM' OR WS-TEM-ERRO-1807 EQUAL 'SIM' OR WS-TEM-ERRO-1852 EQUAL 'SIM' OR PROPOFID-NSAS-SIVPF OF DCLPROPOSTA-FIDELIZ EQUAL 01 OR PROPOFID-SIT-PROPOSTA OF DCLPROPOSTA-FIDELIZ EQUAL 'DEC' */

            if (WORK_AREA.WS_TEM_ERRO_1855 == "SIM" || WORK_AREA.WS_TEM_ERRO_1807 == "SIM" || WORK_AREA.WS_TEM_ERRO_1852 == "SIM" || PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAS_SIVPF == 01 || PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA == "DEC")
            {

                /*" -3859- MOVE 'REJ' TO WHOST-SIT-PROPOSTA */
                _.Move("REJ", WHOST_SIT_PROPOSTA);

                /*" -3860- MOVE 'S' TO WHOST-SIT-ENVIO */
                _.Move("S", WHOST_SIT_ENVIO);

                /*" -3861- ELSE */
            }
            else
            {


                /*" -3862- IF WS-TEM-ERRO EQUAL ZEROS */

                if (WORK_AREA.WS_TEM_ERRO == 00)
                {

                    /*" -3863- MOVE 'PAI' TO WHOST-SIT-PROPOSTA */
                    _.Move("PAI", WHOST_SIT_PROPOSTA);

                    /*" -3864- MOVE ' ' TO WHOST-SIT-ENVIO */
                    _.Move(" ", WHOST_SIT_ENVIO);

                    /*" -3865- ELSE */
                }
                else
                {


                    /*" -3866- MOVE 'S' TO WHOST-SIT-ENVIO */
                    _.Move("S", WHOST_SIT_ENVIO);

                    /*" -3867- IF RCAP-CADASTRADO */

                    if (WORK_AREA.W_RCAPS["RCAP_CADASTRADO"])
                    {

                        /*" -3868- MOVE 'PEN' TO WHOST-SIT-PROPOSTA */
                        _.Move("PEN", WHOST_SIT_PROPOSTA);

                        /*" -3869- ELSE */
                    }
                    else
                    {


                        /*" -3871- MOVE 'POB' TO WHOST-SIT-PROPOSTA. */
                        _.Move("POB", WHOST_SIT_PROPOSTA);
                    }

                }

            }


            /*" -3873- IF PRODUVG-COD-PRODUTO = 7732 OR JVPRD7732 OR 7733 OR JVPRD7733 */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.In("7732", JVBKINCL.JV_PRODUTOS.JVPRD7732.ToString(), "7733", JVBKINCL.JV_PRODUTOS.JVPRD7733.ToString()))
            {

                /*" -3874- IF WS-TEM-ERRO EQUAL ZEROS */

                if (WORK_AREA.WS_TEM_ERRO == 00)
                {

                    /*" -3875- MOVE 'PAI' TO WHOST-SIT-PROPOSTA */
                    _.Move("PAI", WHOST_SIT_PROPOSTA);

                    /*" -3876- MOVE ' ' TO WHOST-SIT-ENVIO */
                    _.Move(" ", WHOST_SIT_ENVIO);

                    /*" -3877- ELSE */
                }
                else
                {


                    /*" -3878- MOVE 'S' TO WHOST-SIT-ENVIO */
                    _.Move("S", WHOST_SIT_ENVIO);

                    /*" -3879- IF RCAP-CADASTRADO */

                    if (WORK_AREA.W_RCAPS["RCAP_CADASTRADO"])
                    {

                        /*" -3880- MOVE 'PEN' TO WHOST-SIT-PROPOSTA */
                        _.Move("PEN", WHOST_SIT_PROPOSTA);

                        /*" -3881- ELSE */
                    }
                    else
                    {


                        /*" -3882- MOVE 'POB' TO WHOST-SIT-PROPOSTA */
                        _.Move("POB", WHOST_SIT_PROPOSTA);

                        /*" -3889- END-IF. */
                    }

                }

            }


            /*" -3892- MOVE PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO W-NUM-PROPOSTA. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, WORK_AREA.W_NUM_PROPOSTA);

            /*" -3905- MOVE PROPOFID-ORIGEM-PROPOSTA OF DCLPROPOSTA-FIDELIZ TO W-ORIGEM-PROPOSTA. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA, WORK_AREA.W_ORIGEM_PROPOSTA);

            /*" -3906- MOVE 14 TO SII */
            _.Move(14, WS_HORAS.SII);

            /*" -3907- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -3915- PERFORM R1600_00_UPDATE_PROPFID_DB_UPDATE_1 */

            R1600_00_UPDATE_PROPFID_DB_UPDATE_1();

            /*" -3918- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -3919- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3920- DISPLAY 'PROBLEMAS NO UPDATE DA PROPFID      ' */
                _.Display($"PROBLEMAS NO UPDATE DA PROPFID      ");

                /*" -3920- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1600-00-UPDATE-PROPFID-DB-UPDATE-1 */
        public void R1600_00_UPDATE_PROPFID_DB_UPDATE_1()
        {
            /*" -3915- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET SIT_PROPOSTA = :WHOST-SIT-PROPOSTA, SITUACAO_ENVIO = :WHOST-SIT-ENVIO, NRMATRVEN = :DCLPROPOSTA-FIDELIZ.PROPOFID-NRMATRVEN, COD_USUARIO = 'VP0601B' WHERE NUM_PROPOSTA_SIVPF = :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF END-EXEC. */

            var r1600_00_UPDATE_PROPFID_DB_UPDATE_1_Update1 = new R1600_00_UPDATE_PROPFID_DB_UPDATE_1_Update1()
            {
                PROPOFID_NRMATRVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN.ToString(),
                WHOST_SIT_PROPOSTA = WHOST_SIT_PROPOSTA.ToString(),
                WHOST_SIT_ENVIO = WHOST_SIT_ENVIO.ToString(),
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            R1600_00_UPDATE_PROPFID_DB_UPDATE_1_Update1.Execute(r1600_00_UPDATE_PROPFID_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1700-00-UPDATE-PRP-FIDELIZ-SECTION */
        private void R1700_00_UPDATE_PRP_FIDELIZ_SECTION()
        {
            /*" -3933- MOVE '1700-00-UPDATE-PRP-FIDELIZ   ' TO PARAGRAFO. */
            _.Move("1700-00-UPDATE-PRP-FIDELIZ   ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3934- MOVE 15 TO SII */
            _.Move(15, WS_HORAS.SII);

            /*" -3935- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -3946- PERFORM R1700_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1 */

            R1700_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1();

            /*" -3949- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -3950- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3951- DISPLAY 'VP0601B - PROPOSTA-FIDELIZ NAO FOI ATUALIZADA   ' */
                _.Display($"VP0601B - PROPOSTA-FIDELIZ NAO FOI ATUALIZADA   ");

                /*" -3952- DISPLAY '          SERA ATUALIZADA NO PF0002B.           ' */
                _.Display($"          SERA ATUALIZADA NO PF0002B.           ");

                /*" -3961- DISPLAY '          NUM PROPOSTA........................  ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ '          DTQITBCO / DATA-RCAP................  ' RCAPCOMP-DATA-RCAP '          DATA CREDITO / DATA MOVIMENTO RCAP..  ' RCAPCOMP-DATA-MOVIMENTO '          VALOR PAGO..........................  ' PROPOFID-VAL-PAGO '          SQLCODE.............................  ' SQLCODE. */

                $"          NUM PROPOSTA........................  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}          DTQITBCO / DATA-RCAP................  {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP}          DATA CREDITO / DATA MOVIMENTO RCAP..  {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_MOVIMENTO}          VALOR PAGO..........................  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO}          SQLCODE.............................  {DB.SQLCODE}"
                .Display();
            }


        }

        [StopWatch]
        /*" R1700-00-UPDATE-PRP-FIDELIZ-DB-UPDATE-1 */
        public void R1700_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1()
        {
            /*" -3946- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET DTQITBCO = :DCLRCAP-COMPLEMENTAR.RCAPCOMP-DATA-RCAP, DATA_CREDITO = :DCLRCAP-COMPLEMENTAR.RCAPCOMP-DATA-MOVIMENTO, VAL_PAGO = :DCLPROPOSTA-FIDELIZ.PROPOFID-VAL-PAGO WHERE NUM_PROPOSTA_SIVPF = :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF AND SIT_PROPOSTA IN ( 'ENV' , 'POV' , 'DEC' ) END-EXEC. */

            var r1700_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1 = new R1700_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1()
            {
                RCAPCOMP_DATA_MOVIMENTO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_MOVIMENTO.ToString(),
                RCAPCOMP_DATA_RCAP = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP.ToString(),
                PROPOFID_VAL_PAGO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO.ToString(),
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            R1700_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1.Execute(r1700_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/

        [StopWatch]
        /*" R2203-00-SELECT-CONDITEC-SECTION */
        private void R2203_00_SELECT_CONDITEC_SECTION()
        {
            /*" -3972- MOVE '2203-00-SELECT-CONDITEC      ' TO PARAGRAFO. */
            _.Move("2203-00-SELECT-CONDITEC      ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3974- MOVE 'SELECT SEGUROS.CONDICOES_TECNICAS' TO COMANDO. */
            _.Move("SELECT SEGUROS.CONDICOES_TECNICAS", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3975- MOVE 16 TO SII */
            _.Move(16, WS_HORAS.SII);

            /*" -3976- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -3984- PERFORM R2203_00_SELECT_CONDITEC_DB_SELECT_1 */

            R2203_00_SELECT_CONDITEC_DB_SELECT_1();

            /*" -3987- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -3988- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3989- DISPLAY 'ERRO SELECT NA TABELA CONDICOES_TECNICAS' */
                _.Display($"ERRO SELECT NA TABELA CONDICOES_TECNICAS");

                /*" -3990- DISPLAY 'NUM_APOLICE  = ' PROPSSVD-NUM-APOLICE */
                _.Display($"NUM_APOLICE  = {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE}");

                /*" -3991- DISPLAY 'COD_SUBGRUPO = ' PROPSSVD-COD-SUBGRUPO */
                _.Display($"COD_SUBGRUPO = {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO}");

                /*" -3992- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2203-00-SELECT-CONDITEC-DB-SELECT-1 */
        public void R2203_00_SELECT_CONDITEC_DB_SELECT_1()
        {
            /*" -3984- EXEC SQL SELECT CARREGA_CONJUGE INTO :CONDITEC-CARREGA-CONJUGE FROM SEGUROS.CONDICOES_TECNICAS WHERE NUM_APOLICE = :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE AND COD_SUBGRUPO = :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO END-EXEC. */

            var r2203_00_SELECT_CONDITEC_DB_SELECT_1_Query1 = new R2203_00_SELECT_CONDITEC_DB_SELECT_1_Query1()
            {
                PROPSSVD_COD_SUBGRUPO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.ToString(),
                PROPSSVD_NUM_APOLICE = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.ToString(),
            };

            var executed_1 = R2203_00_SELECT_CONDITEC_DB_SELECT_1_Query1.Execute(r2203_00_SELECT_CONDITEC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONDITEC_CARREGA_CONJUGE, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2203_99_SAIDA*/

        [StopWatch]
        /*" R2205-00-SELECT-HISTCOBVA-SECTION */
        private void R2205_00_SELECT_HISTCOBVA_SECTION()
        {
            /*" -4001- MOVE '2205-00-SELECT-HISTCOBVA     ' TO PARAGRAFO. */
            _.Move("2205-00-SELECT-HISTCOBVA     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4003- MOVE 'SELECT SEGUROS.COBER_HIST_VIDAZUL' TO COMANDO. */
            _.Move("SELECT SEGUROS.COBER_HIST_VIDAZUL", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4006- MOVE PROPOFID-NUM-SICOB OF DCLPROPOSTA-FIDELIZ TO NUM-TITULO OF DCLCOBER-HIST-VIDAZUL. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB, CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_TITULO);

            /*" -4007- MOVE 17 TO SII */
            _.Move(17, WS_HORAS.SII);

            /*" -4008- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -4014- PERFORM R2205_00_SELECT_HISTCOBVA_DB_SELECT_1 */

            R2205_00_SELECT_HISTCOBVA_DB_SELECT_1();

            /*" -4017- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -4018- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -4018- MOVE 1 TO W-COBRANCA. */
                _.Move(1, WORK_AREA.W_COBRANCA);
            }


        }

        [StopWatch]
        /*" R2205-00-SELECT-HISTCOBVA-DB-SELECT-1 */
        public void R2205_00_SELECT_HISTCOBVA_DB_SELECT_1()
        {
            /*" -4014- EXEC SQL SELECT NUM_TITULO INTO :DCLCOBER-HIST-VIDAZUL.NUM-TITULO FROM SEGUROS.COBER_HIST_VIDAZUL WHERE NUM_TITULO = :DCLCOBER-HIST-VIDAZUL.NUM-TITULO END-EXEC. */

            var r2205_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1 = new R2205_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1()
            {
                NUM_TITULO = CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_TITULO.ToString(),
            };

            var executed_1 = R2205_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1.Execute(r2205_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUM_TITULO, CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_TITULO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2205_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-SELECT-PESSOA-SECTION */
        private void R2200_00_SELECT_PESSOA_SECTION()
        {
            /*" -4026- MOVE '2200-00-SELECT-PESSOA        ' TO PARAGRAFO. */
            _.Move("2200-00-SELECT-PESSOA        ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4029- MOVE 'SELECT SEGUROS.PESSOA        ' TO COMANDO. */
            _.Move("SELECT SEGUROS.PESSOA        ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4030- MOVE 18 TO SII */
            _.Move(18, WS_HORAS.SII);

            /*" -4031- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -4039- PERFORM R2200_00_SELECT_PESSOA_DB_SELECT_1 */

            R2200_00_SELECT_PESSOA_DB_SELECT_1();

            /*" -4041- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -4042- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4043- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4044- DISPLAY 'PESSOA FISICA NAO CADASTRADA ' */
                    _.Display($"PESSOA FISICA NAO CADASTRADA ");

                    /*" -4045- DISPLAY 'COD_PESSOA = ' PROPOFID-COD-PESSOA */
                    _.Display($"COD_PESSOA = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA}");

                    /*" -4046- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4047- ELSE */
                }
                else
                {


                    /*" -4048- DISPLAY 'PROBLEMAS ACESSO PESSOA FISICA ' */
                    _.Display($"PROBLEMAS ACESSO PESSOA FISICA ");

                    /*" -4049- DISPLAY 'COD_PESSOA = ' PROPOFID-COD-PESSOA */
                    _.Display($"COD_PESSOA = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA}");

                    /*" -4049- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2200-00-SELECT-PESSOA-DB-SELECT-1 */
        public void R2200_00_SELECT_PESSOA_DB_SELECT_1()
        {
            /*" -4039- EXEC SQL SELECT NOME_PESSOA, TIPO_PESSOA INTO :DCLPESSOA.PESSOA-NOME-PESSOA ,:DCLPESSOA.PESSOA-TIPO-PESSOA FROM SEGUROS.PESSOA WHERE COD_PESSOA = :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA END-EXEC. */

            var r2200_00_SELECT_PESSOA_DB_SELECT_1_Query1 = new R2200_00_SELECT_PESSOA_DB_SELECT_1_Query1()
            {
                PROPOFID_COD_PESSOA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.ToString(),
            };

            var executed_1 = R2200_00_SELECT_PESSOA_DB_SELECT_1_Query1.Execute(r2200_00_SELECT_PESSOA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PESSOA_NOME_PESSOA, PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA);
                _.Move(executed_1.PESSOA_TIPO_PESSOA, PESSOA.DCLPESSOA.PESSOA_TIPO_PESSOA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2210-00-SELECT-PESSOA-FISICA-SECTION */
        private void R2210_00_SELECT_PESSOA_FISICA_SECTION()
        {
            /*" -4058- MOVE '2210-00-SELECT-PESSOA-FISICA ' TO PARAGRAFO. */
            _.Move("2210-00-SELECT-PESSOA-FISICA ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4061- MOVE 'SELECT SEGUROS.PESSOA_FISICA ' TO COMANDO. */
            _.Move("SELECT SEGUROS.PESSOA_FISICA ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4062- MOVE 19 TO SII */
            _.Move(19, WS_HORAS.SII);

            /*" -4063- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -4092- PERFORM R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1 */

            R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1();

            /*" -4094- MOVE SQLCODE TO WS-SQLCODE */
            _.Move(DB.SQLCODE, WS_SQLCODE);

            /*" -4095- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -4096- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4097- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4098- DISPLAY '-------------------------------' */
                    _.Display($"-------------------------------");

                    /*" -4099- DISPLAY 'PESSOA FISICA NAO CADASTRADA2' */
                    _.Display($"PESSOA FISICA NAO CADASTRADA2");

                    /*" -4100- DISPLAY 'SQLCODE      = ' WS-SQLCODE */
                    _.Display($"SQLCODE      = {WS_SQLCODE}");

                    /*" -4101- DISPLAY 'COD_PESSOA   = ' PROPOFID-COD-PESSOA */
                    _.Display($"COD_PESSOA   = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA}");

                    /*" -4102- DISPLAY 'NUM-PROPOSTA = ' PROPOFID-NUM-PROPOSTA-SIVPF */
                    _.Display($"NUM-PROPOSTA = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -4103- DISPLAY '-------------------------------' */
                    _.Display($"-------------------------------");

                    /*" -4104- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4105- ELSE */
                }
                else
                {


                    /*" -4106- DISPLAY 'PROBLEMAS ACESSO PESSOA FISICA ' */
                    _.Display($"PROBLEMAS ACESSO PESSOA FISICA ");

                    /*" -4107- DISPLAY 'SQLCODE = ' WS-SQLCODE */
                    _.Display($"SQLCODE = {WS_SQLCODE}");

                    /*" -4108- DISPLAY 'COD_PESSOA = ' PROPOFID-COD-PESSOA */
                    _.Display($"COD_PESSOA = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA}");

                    /*" -4108- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2210-00-SELECT-PESSOA-FISICA-DB-SELECT-1 */
        public void R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1()
        {
            /*" -4092- EXEC SQL SELECT CPF, DATA_NASCIMENTO, DATA_NASCIMENTO - :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PLANO MONTHS, DATA_NASCIMENTO - 2 DAYS, SEXO, COD_CBO, ESTADO_CIVIL, ORGAO_EXPEDIDOR, NUM_IDENTIDADE, DATA_EXPEDICAO, UF_EXPEDIDORA INTO :DCLPESSOA-FISICA.CPF, :DCLPESSOA-FISICA.DATA-NASCIMENTO, :WHOST-DATA-NASCIMENTO-7708, :WHOST-DATA-NASCIMENTO-2, :DCLPESSOA-FISICA.SEXO, :DCLPESSOA-FISICA.COD-CBO, :DCLPESSOA-FISICA.ESTADO-CIVIL, :DCLPESSOA-FISICA.ORGAO-EXPEDIDOR, :DCLPESSOA-FISICA.NUM-IDENTIDADE, :DCLPESSOA-FISICA.DATA-EXPEDICAO :VIND-DATA-EXPEDICAO, :DCLPESSOA-FISICA.UF-EXPEDIDORA :VIND-UF-EXPEDIDORA FROM SEGUROS.PESSOA_FISICA WHERE COD_PESSOA = :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA END-EXEC. */

            var r2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1 = new R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1()
            {
                PROPOFID_COD_PESSOA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.ToString(),
                PROPOFID_COD_PLANO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO.ToString(),
            };

            var executed_1 = R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1.Execute(r2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CPF, PESFIS.DCLPESSOA_FISICA.CPF);
                _.Move(executed_1.DATA_NASCIMENTO, PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO);
                _.Move(executed_1.WHOST_DATA_NASCIMENTO_7708, WHOST_DATA_NASCIMENTO_7708);
                _.Move(executed_1.WHOST_DATA_NASCIMENTO_2, WHOST_DATA_NASCIMENTO_2);
                _.Move(executed_1.SEXO, PESFIS.DCLPESSOA_FISICA.SEXO);
                _.Move(executed_1.COD_CBO, PESFIS.DCLPESSOA_FISICA.COD_CBO);
                _.Move(executed_1.ESTADO_CIVIL, PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL);
                _.Move(executed_1.ORGAO_EXPEDIDOR, PESFIS.DCLPESSOA_FISICA.ORGAO_EXPEDIDOR);
                _.Move(executed_1.NUM_IDENTIDADE, PESFIS.DCLPESSOA_FISICA.NUM_IDENTIDADE);
                _.Move(executed_1.DATA_EXPEDICAO, PESFIS.DCLPESSOA_FISICA.DATA_EXPEDICAO);
                _.Move(executed_1.VIND_DATA_EXPEDICAO, VIND_DATA_EXPEDICAO);
                _.Move(executed_1.UF_EXPEDIDORA, PESFIS.DCLPESSOA_FISICA.UF_EXPEDIDORA);
                _.Move(executed_1.VIND_UF_EXPEDIDORA, VIND_UF_EXPEDIDORA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2210_99_SAIDA*/

        [StopWatch]
        /*" R2211-00-SELECT-PESSOA-FISICA-SECTION */
        private void R2211_00_SELECT_PESSOA_FISICA_SECTION()
        {
            /*" -4118- MOVE '2211-00-SELECT-PESSOA-FISICA ' TO PARAGRAFO. */
            _.Move("2211-00-SELECT-PESSOA-FISICA ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4119- MOVE ZEROS TO CPF OF DCLPESSOA-FISICA */
            _.Move(0, PESFIS.DCLPESSOA_FISICA.CPF);

            /*" -4121- MOVE 19 TO SII */
            _.Move(19, WS_HORAS.SII);

            /*" -4123- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -4129- PERFORM R2211_00_SELECT_PESSOA_FISICA_DB_SELECT_1 */

            R2211_00_SELECT_PESSOA_FISICA_DB_SELECT_1();

            /*" -4133- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -4134- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -4135- MOVE ZEROS TO CPF OF DCLPESSOA-FISICA */
                _.Move(0, PESFIS.DCLPESSOA_FISICA.CPF);

                /*" -4136- ELSE */
            }
            else
            {


                /*" -4137- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -4138- DISPLAY '--------------------------------------------' */
                    _.Display($"--------------------------------------------");

                    /*" -4139- DISPLAY 'ERRO NO ACESSO A TABELA SEGUROS.PESSOA_FISICA' */
                    _.Display($"ERRO NO ACESSO A TABELA SEGUROS.PESSOA_FISICA");

                    /*" -4140- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, WS_SQLCODE);

                    /*" -4141- DISPLAY 'SQLCODE = ' WS-SQLCODE */
                    _.Display($"SQLCODE = {WS_SQLCODE}");

                    /*" -4143- DISPLAY 'COD-PESSOA  = ' PROPOFID-COD-PESSOA OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"COD-PESSOA  = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA}");

                    /*" -4145- DISPLAY 'COD_PRODUTO = ' PRODUVG-COD-PRODUTO OF DCLPRODUTOS-VG */
                    _.Display($"COD_PRODUTO = {PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO}");

                    /*" -4147- DISPLAY 'NUM_APOLICE = ' PROPSSVD-NUM-APOLICE OF DCLPROP-SASSE-VIDA */
                    _.Display($"NUM_APOLICE = {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE}");

                    /*" -4148- DISPLAY '--------------------------------------------' */
                    _.Display($"--------------------------------------------");

                    /*" -4149- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4150- END-IF */
                }


                /*" -4150- END-IF. */
            }


        }

        [StopWatch]
        /*" R2211-00-SELECT-PESSOA-FISICA-DB-SELECT-1 */
        public void R2211_00_SELECT_PESSOA_FISICA_DB_SELECT_1()
        {
            /*" -4129- EXEC SQL SELECT CPF INTO :DCLPESSOA-FISICA.CPF FROM SEGUROS.PESSOA_FISICA WHERE COD_PESSOA = :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA END-EXEC. */

            var r2211_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1 = new R2211_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1()
            {
                PROPOFID_COD_PESSOA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.ToString(),
            };

            var executed_1 = R2211_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1.Execute(r2211_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CPF, PESFIS.DCLPESSOA_FISICA.CPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2211_99_SAIDA*/

        [StopWatch]
        /*" R2212-00-SELECT-PESSOA-JURID-SECTION */
        private void R2212_00_SELECT_PESSOA_JURID_SECTION()
        {
            /*" -4158- MOVE '2212-00-SELECT-PESSOA-JURID' TO PARAGRAFO. */
            _.Move("2212-00-SELECT-PESSOA-JURID", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4164- PERFORM R2212_00_SELECT_PESSOA_JURID_DB_SELECT_1 */

            R2212_00_SELECT_PESSOA_JURID_DB_SELECT_1();

            /*" -4167- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4168- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4169- DISPLAY 'PESSOA JURIDICA NAO CADASTRADA' */
                    _.Display($"PESSOA JURIDICA NAO CADASTRADA");

                    /*" -4170- DISPLAY 'SQLCODE = ' WS-SQLCODE */
                    _.Display($"SQLCODE = {WS_SQLCODE}");

                    /*" -4171- DISPLAY 'COD_PESSOA = ' PROPOFID-COD-PESSOA */
                    _.Display($"COD_PESSOA = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA}");

                    /*" -4172- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4173- ELSE */
                }
                else
                {


                    /*" -4174- DISPLAY 'PROBLEMAS ACESSO PESSOA JURIDICA' */
                    _.Display($"PROBLEMAS ACESSO PESSOA JURIDICA");

                    /*" -4175- DISPLAY 'SQLCODE = ' WS-SQLCODE */
                    _.Display($"SQLCODE = {WS_SQLCODE}");

                    /*" -4176- DISPLAY 'COD_PESSOA = ' PROPOFID-COD-PESSOA */
                    _.Display($"COD_PESSOA = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA}");

                    /*" -4177- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4178- END-IF */
                }


                /*" -4181- END-IF. */
            }


            /*" -4185- PERFORM R2212_00_SELECT_PESSOA_JURID_DB_SELECT_2 */

            R2212_00_SELECT_PESSOA_JURID_DB_SELECT_2();

            /*" -4188- MOVE PESSOJUR-CGC TO CPF OF DCLPESSOA-FISICA. */
            _.Move(PESSOJUR.DCLPESSOA_JURIDICA.PESSOJUR_CGC, PESFIS.DCLPESSOA_FISICA.CPF);

            /*" -4189- MOVE WS-DT-NASCIMENTO-18 TO DATA-NASCIMENTO OF DCLPESSOA-FISICA. */
            _.Move(WS_DT_NASCIMENTO_18, PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO);

        }

        [StopWatch]
        /*" R2212-00-SELECT-PESSOA-JURID-DB-SELECT-1 */
        public void R2212_00_SELECT_PESSOA_JURID_DB_SELECT_1()
        {
            /*" -4164- EXEC SQL SELECT CGC, NOME_FANTASIA INTO :PESSOJUR-CGC, :PESSOJUR-NOME-FANTASIA FROM SEGUROS.PESSOA_JURIDICA WHERE COD_PESSOA = :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA END-EXEC. */

            var r2212_00_SELECT_PESSOA_JURID_DB_SELECT_1_Query1 = new R2212_00_SELECT_PESSOA_JURID_DB_SELECT_1_Query1()
            {
                PROPOFID_COD_PESSOA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.ToString(),
            };

            var executed_1 = R2212_00_SELECT_PESSOA_JURID_DB_SELECT_1_Query1.Execute(r2212_00_SELECT_PESSOA_JURID_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PESSOJUR_CGC, PESSOJUR.DCLPESSOA_JURIDICA.PESSOJUR_CGC);
                _.Move(executed_1.PESSOJUR_NOME_FANTASIA, PESSOJUR.DCLPESSOA_JURIDICA.PESSOJUR_NOME_FANTASIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2212_99_SAIDA*/

        [StopWatch]
        /*" R2212-00-SELECT-PESSOA-JURID-DB-SELECT-2 */
        public void R2212_00_SELECT_PESSOA_JURID_DB_SELECT_2()
        {
            /*" -4185- EXEC SQL SELECT CURRENT DATE - 18 YEAR INTO :WS-DT-NASCIMENTO-18 FROM SYSIBM.SYSDUMMY1 END-EXEC. */

            /*-- linha suprimida por comandos abaixo EXEC SQL
            /*--SELECT CURRENT DATE - 18 YEAR
            /*--INTO :WS-DT-NASCIMENTO-18
            /*--FROM SYSIBM.SYSDUMMY1
            /*--END-EXEC.
            /*-- */

            _.Move(_.CurrentDate(), WS_DT_NASCIMENTO_18);

        }

        [StopWatch]
        /*" R2215-00-SELECT-PROPOVA-SECTION */
        private void R2215_00_SELECT_PROPOVA_SECTION()
        {
            /*" -4197- MOVE '2215-00-SELECT-PROPOVA       ' TO PARAGRAFO. */
            _.Move("2215-00-SELECT-PROPOVA       ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4200- MOVE 'SELECT SEGUROS.PROPOSTAS_VA  ' TO COMANDO. */
            _.Move("SELECT SEGUROS.PROPOSTAS_VA  ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4201- MOVE 20 TO SII */
            _.Move(20, WS_HORAS.SII);

            /*" -4202- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -4208- PERFORM R2215_00_SELECT_PROPOVA_DB_SELECT_1 */

            R2215_00_SELECT_PROPOVA_DB_SELECT_1();

            /*" -4210- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -4211- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4213- IF SQLCODE EQUAL 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -4214- ELSE */
                }
                else
                {


                    /*" -4215- DISPLAY 'PROBLEMAS ACESSO PROPOSTAS_VA  ' */
                    _.Display($"PROBLEMAS ACESSO PROPOSTAS_VA  ");

                    /*" -4216- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2215-00-SELECT-PROPOVA-DB-SELECT-1 */
        public void R2215_00_SELECT_PROPOVA_DB_SELECT_1()
        {
            /*" -4208- EXEC SQL SELECT OCOREND INTO :DCLPROPOSTAS-VA.OCOREND FROM SEGUROS.PROPOSTAS_VA WHERE NUM_CERTIFICADO = :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF END-EXEC. */

            var r2215_00_SELECT_PROPOVA_DB_SELECT_1_Query1 = new R2215_00_SELECT_PROPOVA_DB_SELECT_1_Query1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = R2215_00_SELECT_PROPOVA_DB_SELECT_1_Query1.Execute(r2215_00_SELECT_PROPOVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OCOREND, PROPVA.DCLPROPOSTAS_VA.OCOREND);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2215_99_SAIDA*/

        [StopWatch]
        /*" R2220-00-OBTER-ENDERECO-CORRES-SECTION */
        private void R2220_00_OBTER_ENDERECO_CORRES_SECTION()
        {
            /*" -4224- MOVE '2220-00-SELECT-PESSOA-ENDER  ' TO PARAGRAFO. */
            _.Move("2220-00-SELECT-PESSOA-ENDER  ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4227- MOVE 'SELECT  PESSOA_ENDERECO ' TO COMANDO. */
            _.Move("SELECT  PESSOA_ENDERECO ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4228- MOVE 21 TO SII */
            _.Move(21, WS_HORAS.SII);

            /*" -4229- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -4247- PERFORM R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1 */

            R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1();

            /*" -4249- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -4250- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4251- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4252- MOVE 2 TO W-ENDERECO */
                    _.Move(2, WORK_AREA.W_ENDERECO);

                    /*" -4253- GO TO R2220-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2220_99_SAIDA*/ //GOTO
                    return;

                    /*" -4254- ELSE */
                }
                else
                {


                    /*" -4255- DISPLAY 'PROBLEMAS ACESSO PESSOA ENDER  ' */
                    _.Display($"PROBLEMAS ACESSO PESSOA ENDER  ");

                    /*" -4257- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -4258- MOVE 1 TO W-ENDERECO. */
            _.Move(1, WORK_AREA.W_ENDERECO);

        }

        [StopWatch]
        /*" R2220-00-OBTER-ENDERECO-CORRES-DB-SELECT-1 */
        public void R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1()
        {
            /*" -4247- EXEC SQL SELECT OCORR_ENDERECO, ENDERECO, BAIRRO, CIDADE, CEP, SIGLA_UF INTO :DCLPESSOA-ENDERECO.OCORR-ENDERECO, :DCLPESSOA-ENDERECO.ENDERECO, :DCLPESSOA-ENDERECO.BAIRRO, :DCLPESSOA-ENDERECO.CIDADE, :DCLPESSOA-ENDERECO.CEP, :DCLPESSOA-ENDERECO.SIGLA-UF FROM SEGUROS.PESSOA_ENDERECO WHERE COD_PESSOA = :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA AND OCORR_ENDERECO = :DCLPROPOSTAS-VA.OCOREND END-EXEC. */

            var r2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1 = new R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1()
            {
                PROPOFID_COD_PESSOA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.ToString(),
                OCOREND = PROPVA.DCLPROPOSTAS_VA.OCOREND.ToString(),
            };

            var executed_1 = R2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1.Execute(r2220_00_OBTER_ENDERECO_CORRES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OCORR_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO);
                _.Move(executed_1.ENDERECO, PESENDER.DCLPESSOA_ENDERECO.ENDERECO);
                _.Move(executed_1.BAIRRO, PESENDER.DCLPESSOA_ENDERECO.BAIRRO);
                _.Move(executed_1.CIDADE, PESENDER.DCLPESSOA_ENDERECO.CIDADE);
                _.Move(executed_1.CEP, PESENDER.DCLPESSOA_ENDERECO.CEP);
                _.Move(executed_1.SIGLA_UF, PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2220_99_SAIDA*/

        [StopWatch]
        /*" R2222-00-OBTER-ENDERECO-CORRES-SECTION */
        private void R2222_00_OBTER_ENDERECO_CORRES_SECTION()
        {
            /*" -4265- MOVE '2222-00-SELECT-PESSOA-ENDER  ' TO PARAGRAFO. */
            _.Move("2222-00-SELECT-PESSOA-ENDER  ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4268- MOVE 'DECLARE PESSOA_ENDERECO CORRESPONDENCIA' TO COMANDO. */
            _.Move("DECLARE PESSOA_ENDERECO CORRESPONDENCIA", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4280- PERFORM R2222_00_OBTER_ENDERECO_CORRES_DB_DECLARE_1 */

            R2222_00_OBTER_ENDERECO_CORRES_DB_DECLARE_1();

            /*" -4283- MOVE 22 TO SII */
            _.Move(22, WS_HORAS.SII);

            /*" -4286- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -4286- PERFORM R2222_00_OBTER_ENDERECO_CORRES_DB_OPEN_1 */

            R2222_00_OBTER_ENDERECO_CORRES_DB_OPEN_1();

            /*" -4288- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -4289- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4290- MOVE 2 TO W-ENDERECO */
                _.Move(2, WORK_AREA.W_ENDERECO);

                /*" -4291- GO TO R2222-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2222_99_SAIDA*/ //GOTO
                return;

                /*" -4292- ELSE */
            }
            else
            {


                /*" -4293- MOVE 'FETCH CPESENDER              ' TO COMANDO */
                _.Move("FETCH CPESENDER              ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -4301- PERFORM R2222_00_OBTER_ENDERECO_CORRES_DB_FETCH_1 */

                R2222_00_OBTER_ENDERECO_CORRES_DB_FETCH_1();

                /*" -4303- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -4304- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -4304- PERFORM R2222_00_OBTER_ENDERECO_CORRES_DB_CLOSE_1 */

                        R2222_00_OBTER_ENDERECO_CORRES_DB_CLOSE_1();

                        /*" -4306- MOVE 2 TO W-ENDERECO */
                        _.Move(2, WORK_AREA.W_ENDERECO);

                        /*" -4307- GO TO R2222-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2222_99_SAIDA*/ //GOTO
                        return;

                        /*" -4308- ELSE */
                    }
                    else
                    {


                        /*" -4309- DISPLAY 'PROBLEMAS FETCH ENDERECOS      ' */
                        _.Display($"PROBLEMAS FETCH ENDERECOS      ");

                        /*" -4311- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -4311- PERFORM R2222_00_OBTER_ENDERECO_CORRES_DB_CLOSE_2 */

            R2222_00_OBTER_ENDERECO_CORRES_DB_CLOSE_2();

            /*" -4314- MOVE 1 TO W-ENDERECO. */
            _.Move(1, WORK_AREA.W_ENDERECO);

        }

        [StopWatch]
        /*" R2222-00-OBTER-ENDERECO-CORRES-DB-OPEN-1 */
        public void R2222_00_OBTER_ENDERECO_CORRES_DB_OPEN_1()
        {
            /*" -4286- EXEC SQL OPEN CPESENDER END-EXEC. */

            CPESENDER.Open();

        }

        [StopWatch]
        /*" R2225-00-OBTER-DEMAIS-ENDERECO-DB-DECLARE-1 */
        public void R2225_00_OBTER_DEMAIS_ENDERECO_DB_DECLARE_1()
        {
            /*" -4336- EXEC SQL DECLARE CPESENDERR CURSOR FOR SELECT OCORR_ENDERECO, ENDERECO, BAIRRO, CIDADE, CEP, SIGLA_UF FROM SEGUROS.PESSOA_ENDERECO WHERE COD_PESSOA = :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA ORDER BY OCORR_ENDERECO DESC END-EXEC. */
            CPESENDERR = new VP0601B_CPESENDERR(true);
            string GetQuery_CPESENDERR()
            {
                var query = @$"SELECT OCORR_ENDERECO
							, 
							ENDERECO
							, 
							BAIRRO
							, 
							CIDADE
							, 
							CEP
							, 
							SIGLA_UF 
							FROM SEGUROS.PESSOA_ENDERECO 
							WHERE COD_PESSOA = 
							'{PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA}' 
							ORDER BY OCORR_ENDERECO DESC";

                return query;
            }
            CPESENDERR.GetQueryEvent += GetQuery_CPESENDERR;

        }

        [StopWatch]
        /*" R2222-00-OBTER-ENDERECO-CORRES-DB-FETCH-1 */
        public void R2222_00_OBTER_ENDERECO_CORRES_DB_FETCH_1()
        {
            /*" -4301- EXEC SQL FETCH CPESENDER INTO :DCLPESSOA-ENDERECO.OCORR-ENDERECO, :DCLPESSOA-ENDERECO.ENDERECO, :DCLPESSOA-ENDERECO.BAIRRO, :DCLPESSOA-ENDERECO.CIDADE, :DCLPESSOA-ENDERECO.CEP, :DCLPESSOA-ENDERECO.SIGLA-UF END-EXEC */

            if (CPESENDER.Fetch())
            {
                _.Move(CPESENDER.DCLPESSOA_ENDERECO_OCORR_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO);
                _.Move(CPESENDER.DCLPESSOA_ENDERECO_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.ENDERECO);
                _.Move(CPESENDER.DCLPESSOA_ENDERECO_BAIRRO, PESENDER.DCLPESSOA_ENDERECO.BAIRRO);
                _.Move(CPESENDER.DCLPESSOA_ENDERECO_CIDADE, PESENDER.DCLPESSOA_ENDERECO.CIDADE);
                _.Move(CPESENDER.DCLPESSOA_ENDERECO_CEP, PESENDER.DCLPESSOA_ENDERECO.CEP);
                _.Move(CPESENDER.DCLPESSOA_ENDERECO_SIGLA_UF, PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF);
            }

        }

        [StopWatch]
        /*" R2222-00-OBTER-ENDERECO-CORRES-DB-CLOSE-1 */
        public void R2222_00_OBTER_ENDERECO_CORRES_DB_CLOSE_1()
        {
            /*" -4304- EXEC SQL CLOSE CPESENDER END-EXEC */

            CPESENDER.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2222_99_SAIDA*/

        [StopWatch]
        /*" R2222-00-OBTER-ENDERECO-CORRES-DB-CLOSE-2 */
        public void R2222_00_OBTER_ENDERECO_CORRES_DB_CLOSE_2()
        {
            /*" -4311- EXEC SQL CLOSE CPESENDER END-EXEC. */

            CPESENDER.Close();

        }

        [StopWatch]
        /*" R2225-00-OBTER-DEMAIS-ENDERECO-SECTION */
        private void R2225_00_OBTER_DEMAIS_ENDERECO_SECTION()
        {
            /*" -4322- MOVE '2225-00-OBTER-OUTRO-ENDERECO ' TO PARAGRAFO. */
            _.Move("2225-00-OBTER-OUTRO-ENDERECO ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4325- MOVE 'DECLARE PESSOA_ENDERECO - OUTRO ENDERECO' TO COMANDO. */
            _.Move("DECLARE PESSOA_ENDERECO - OUTRO ENDERECO", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4336- PERFORM R2225_00_OBTER_DEMAIS_ENDERECO_DB_DECLARE_1 */

            R2225_00_OBTER_DEMAIS_ENDERECO_DB_DECLARE_1();

            /*" -4339- MOVE 23 TO SII */
            _.Move(23, WS_HORAS.SII);

            /*" -4340- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -4340- PERFORM R2225_00_OBTER_DEMAIS_ENDERECO_DB_OPEN_1 */

            R2225_00_OBTER_DEMAIS_ENDERECO_DB_OPEN_1();

            /*" -4342- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -4343- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4344- MOVE 4 TO W-ENDERECO */
                _.Move(4, WORK_AREA.W_ENDERECO);

                /*" -4345- GO TO R2225-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2225_99_SAIDA*/ //GOTO
                return;

                /*" -4346- ELSE */
            }
            else
            {


                /*" -4347- MOVE 'FETCH CPESENDERR             ' TO COMANDO */
                _.Move("FETCH CPESENDERR             ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -4355- PERFORM R2225_00_OBTER_DEMAIS_ENDERECO_DB_FETCH_1 */

                R2225_00_OBTER_DEMAIS_ENDERECO_DB_FETCH_1();

                /*" -4357- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -4358- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -4358- PERFORM R2225_00_OBTER_DEMAIS_ENDERECO_DB_CLOSE_1 */

                        R2225_00_OBTER_DEMAIS_ENDERECO_DB_CLOSE_1();

                        /*" -4360- MOVE 4 TO W-ENDERECO */
                        _.Move(4, WORK_AREA.W_ENDERECO);

                        /*" -4361- GO TO R2225-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2225_99_SAIDA*/ //GOTO
                        return;

                        /*" -4362- ELSE */
                    }
                    else
                    {


                        /*" -4363- DISPLAY 'PROBLEMAS FETCH ENDERECOS      ' */
                        _.Display($"PROBLEMAS FETCH ENDERECOS      ");

                        /*" -4365- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -4365- PERFORM R2225_00_OBTER_DEMAIS_ENDERECO_DB_CLOSE_2 */

            R2225_00_OBTER_DEMAIS_ENDERECO_DB_CLOSE_2();

            /*" -4368- MOVE 3 TO W-ENDERECO. */
            _.Move(3, WORK_AREA.W_ENDERECO);

        }

        [StopWatch]
        /*" R2225-00-OBTER-DEMAIS-ENDERECO-DB-OPEN-1 */
        public void R2225_00_OBTER_DEMAIS_ENDERECO_DB_OPEN_1()
        {
            /*" -4340- EXEC SQL OPEN CPESENDERR END-EXEC. */

            CPESENDERR.Open();

        }

        [StopWatch]
        /*" R2232-00-SELECT-PESSOA-FONE-DB-DECLARE-1 */
        public void R2232_00_SELECT_PESSOA_FONE_DB_DECLARE_1()
        {
            /*" -4549- EXEC SQL DECLARE CFONE CURSOR FOR SELECT TIPO_FONE, DDD, NUM_FONE FROM SEGUROS.PESSOA_TELEFONE WHERE COD_PESSOA = :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA ORDER BY TIPO_FONE END-EXEC. */
            CFONE = new VP0601B_CFONE(true);
            string GetQuery_CFONE()
            {
                var query = @$"SELECT TIPO_FONE
							, 
							DDD
							, 
							NUM_FONE 
							FROM SEGUROS.PESSOA_TELEFONE 
							WHERE COD_PESSOA = 
							'{PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA}' 
							ORDER BY TIPO_FONE";

                return query;
            }
            CFONE.GetQueryEvent += GetQuery_CFONE;

        }

        [StopWatch]
        /*" R2225-00-OBTER-DEMAIS-ENDERECO-DB-FETCH-1 */
        public void R2225_00_OBTER_DEMAIS_ENDERECO_DB_FETCH_1()
        {
            /*" -4355- EXEC SQL FETCH CPESENDERR INTO :DCLPESSOA-ENDERECO.OCORR-ENDERECO, :DCLPESSOA-ENDERECO.ENDERECO, :DCLPESSOA-ENDERECO.BAIRRO, :DCLPESSOA-ENDERECO.CIDADE, :DCLPESSOA-ENDERECO.CEP, :DCLPESSOA-ENDERECO.SIGLA-UF END-EXEC */

            if (CPESENDERR.Fetch())
            {
                _.Move(CPESENDERR.DCLPESSOA_ENDERECO_OCORR_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO);
                _.Move(CPESENDERR.DCLPESSOA_ENDERECO_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.ENDERECO);
                _.Move(CPESENDERR.DCLPESSOA_ENDERECO_BAIRRO, PESENDER.DCLPESSOA_ENDERECO.BAIRRO);
                _.Move(CPESENDERR.DCLPESSOA_ENDERECO_CIDADE, PESENDER.DCLPESSOA_ENDERECO.CIDADE);
                _.Move(CPESENDERR.DCLPESSOA_ENDERECO_CEP, PESENDER.DCLPESSOA_ENDERECO.CEP);
                _.Move(CPESENDERR.DCLPESSOA_ENDERECO_SIGLA_UF, PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF);
            }

        }

        [StopWatch]
        /*" R2225-00-OBTER-DEMAIS-ENDERECO-DB-CLOSE-1 */
        public void R2225_00_OBTER_DEMAIS_ENDERECO_DB_CLOSE_1()
        {
            /*" -4358- EXEC SQL CLOSE CPESENDERR END-EXEC */

            CPESENDERR.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2225_99_SAIDA*/

        [StopWatch]
        /*" R2225-00-OBTER-DEMAIS-ENDERECO-DB-CLOSE-2 */
        public void R2225_00_OBTER_DEMAIS_ENDERECO_DB_CLOSE_2()
        {
            /*" -4365- EXEC SQL CLOSE CPESENDERR END-EXEC. */

            CPESENDERR.Close();

        }

        [StopWatch]
        /*" R2230-00-SELECT-PESSOA-FONE-SECTION */
        private void R2230_00_SELECT_PESSOA_FONE_SECTION()
        {
            /*" -4381- MOVE '2230-00-SELECT-PESSOA-FONE   ' TO PARAGRAFO. */
            _.Move("2230-00-SELECT-PESSOA-FONE   ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4384- MOVE 'SELECT PESSOA_TELEFONE 1' TO COMANDO. */
            _.Move("SELECT PESSOA_TELEFONE 1", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4385- MOVE 24 TO SII */
            _.Move(24, WS_HORAS.SII);

            /*" -4386- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -4396- PERFORM R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1 */

            R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1();

            /*" -4399- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -4400- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4401- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4403- MOVE ZEROS TO WHOST-DDD-RESIDENCIAL WHOST-FONE-RESIDENCIAL */
                    _.Move(0, WHOST_DDD_RESIDENCIAL, WHOST_FONE_RESIDENCIAL);

                    /*" -4404- ELSE */
                }
                else
                {


                    /*" -4406- IF SQLCODE EQUAL -811 NEXT SENTENCE */

                    if (DB.SQLCODE == -811)
                    {

                        /*" -4407- ELSE */
                    }
                    else
                    {


                        /*" -4408- DISPLAY 'PROBLEMAS NO SELECT  PESSOA TELEFONE 1' */
                        _.Display($"PROBLEMAS NO SELECT  PESSOA TELEFONE 1");

                        /*" -4410- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -4413- MOVE 'SELECT PESSOA_TELEFONE 2' TO COMANDO. */
            _.Move("SELECT PESSOA_TELEFONE 2", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4414- MOVE 25 TO SII */
            _.Move(25, WS_HORAS.SII);

            /*" -4415- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -4425- PERFORM R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2 */

            R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2();

            /*" -4428- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -4429- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4430- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4432- MOVE ZEROS TO WHOST-DDD-COMERCIAL WHOST-FONE-COMERCIAL */
                    _.Move(0, WHOST_DDD_COMERCIAL, WHOST_FONE_COMERCIAL);

                    /*" -4433- ELSE */
                }
                else
                {


                    /*" -4435- IF SQLCODE EQUAL -811 NEXT SENTENCE */

                    if (DB.SQLCODE == -811)
                    {

                        /*" -4436- ELSE */
                    }
                    else
                    {


                        /*" -4437- DISPLAY 'PROBLEMAS NO SELECT  PESSOA TELEFONE 2' */
                        _.Display($"PROBLEMAS NO SELECT  PESSOA TELEFONE 2");

                        /*" -4439- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -4442- MOVE 'SELECT PESSOA_TELEFONE 3' TO COMANDO. */
            _.Move("SELECT PESSOA_TELEFONE 3", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4443- MOVE 26 TO SII */
            _.Move(26, WS_HORAS.SII);

            /*" -4444- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -4454- PERFORM R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3 */

            R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3();

            /*" -4457- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -4458- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4459- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4461- MOVE ZEROS TO WHOST-DDD-CELULAR WHOST-FONE-CELULAR */
                    _.Move(0, WHOST_DDD_CELULAR, WHOST_FONE_CELULAR);

                    /*" -4462- ELSE */
                }
                else
                {


                    /*" -4464- IF SQLCODE EQUAL -811 NEXT SENTENCE */

                    if (DB.SQLCODE == -811)
                    {

                        /*" -4465- ELSE */
                    }
                    else
                    {


                        /*" -4466- DISPLAY 'PROBLEMAS NO SELECT  PESSOA TELEFONE 3' */
                        _.Display($"PROBLEMAS NO SELECT  PESSOA TELEFONE 3");

                        /*" -4468- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -4471- MOVE 'SELECT PESSOA_TELEFONE 4' TO COMANDO. */
            _.Move("SELECT PESSOA_TELEFONE 4", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4472- MOVE 27 TO SII */
            _.Move(27, WS_HORAS.SII);

            /*" -4473- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -4483- PERFORM R2230_00_SELECT_PESSOA_FONE_DB_SELECT_4 */

            R2230_00_SELECT_PESSOA_FONE_DB_SELECT_4();

            /*" -4486- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -4487- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4488- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4490- MOVE ZEROS TO WHOST-DDD-FAX WHOST-FONE-FAX */
                    _.Move(0, WHOST_DDD_FAX, WHOST_FONE_FAX);

                    /*" -4491- ELSE */
                }
                else
                {


                    /*" -4493- IF SQLCODE EQUAL -811 NEXT SENTENCE */

                    if (DB.SQLCODE == -811)
                    {

                        /*" -4494- ELSE */
                    }
                    else
                    {


                        /*" -4495- DISPLAY 'PROBLEMAS NO SELECT  PESSOA TELEFONE 4' */
                        _.Display($"PROBLEMAS NO SELECT  PESSOA TELEFONE 4");

                        /*" -4497- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -4498- IF WHOST-DDD-RESIDENCIAL > 0 */

            if (WHOST_DDD_RESIDENCIAL > 0)
            {

                /*" -4499- MOVE WHOST-DDD-RESIDENCIAL TO WHOST-DDD */
                _.Move(WHOST_DDD_RESIDENCIAL, WHOST_DDD);

                /*" -4500- ELSE */
            }
            else
            {


                /*" -4501- IF WHOST-DDD-COMERCIAL > 0 */

                if (WHOST_DDD_COMERCIAL > 0)
                {

                    /*" -4502- MOVE WHOST-DDD-COMERCIAL TO WHOST-DDD */
                    _.Move(WHOST_DDD_COMERCIAL, WHOST_DDD);

                    /*" -4503- ELSE */
                }
                else
                {


                    /*" -4504- IF WHOST-DDD-CELULAR > 0 */

                    if (WHOST_DDD_CELULAR > 0)
                    {

                        /*" -4505- MOVE WHOST-DDD-CELULAR TO WHOST-DDD */
                        _.Move(WHOST_DDD_CELULAR, WHOST_DDD);

                        /*" -4506- ELSE */
                    }
                    else
                    {


                        /*" -4507- IF WHOST-DDD-FAX > 0 */

                        if (WHOST_DDD_FAX > 0)
                        {

                            /*" -4508- MOVE WHOST-DDD-FAX TO WHOST-DDD */
                            _.Move(WHOST_DDD_FAX, WHOST_DDD);

                            /*" -4509- ELSE */
                        }
                        else
                        {


                            /*" -4510- MOVE ZEROS TO WHOST-DDD */
                            _.Move(0, WHOST_DDD);

                            /*" -4511- END-IF */
                        }


                        /*" -4512- END-IF */
                    }


                    /*" -4513- END-IF */
                }


                /*" -4515- END-IF. */
            }


            /*" -4516- IF WHOST-FONE-COMERCIAL > 0 */

            if (WHOST_FONE_COMERCIAL > 0)
            {

                /*" -4517- MOVE WHOST-FONE-COMERCIAL TO WHOST-FONE */
                _.Move(WHOST_FONE_COMERCIAL, WHOST_FONE);

                /*" -4518- ELSE */
            }
            else
            {


                /*" -4519- MOVE WHOST-FONE-RESIDENCIAL TO WHOST-FONE */
                _.Move(WHOST_FONE_RESIDENCIAL, WHOST_FONE);

                /*" -4521- END-IF */
            }


            /*" -4523- MOVE WHOST-FONE-CELULAR TO WHOST-TELEX. */
            _.Move(WHOST_FONE_CELULAR, WHOST_TELEX);

            /*" -4524- MOVE WHOST-FONE-FAX TO WHOST-FAX. */
            _.Move(WHOST_FONE_FAX, WHOST_FAX);

        }

        [StopWatch]
        /*" R2230-00-SELECT-PESSOA-FONE-DB-SELECT-1 */
        public void R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1()
        {
            /*" -4396- EXEC SQL SELECT DDD, NUM_FONE INTO :WHOST-DDD-RESIDENCIAL, :WHOST-FONE-RESIDENCIAL FROM SEGUROS.PESSOA_TELEFONE WHERE COD_PESSOA = :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA AND SITUACAO_FONE = 'P' AND TIPO_FONE = 1 END-EXEC. */

            var r2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1 = new R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1()
            {
                PROPOFID_COD_PESSOA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.ToString(),
            };

            var executed_1 = R2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1.Execute(r2230_00_SELECT_PESSOA_FONE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DDD_RESIDENCIAL, WHOST_DDD_RESIDENCIAL);
                _.Move(executed_1.WHOST_FONE_RESIDENCIAL, WHOST_FONE_RESIDENCIAL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2230_99_SAIDA*/

        [StopWatch]
        /*" R2230-00-SELECT-PESSOA-FONE-DB-SELECT-2 */
        public void R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2()
        {
            /*" -4425- EXEC SQL SELECT DDD, NUM_FONE INTO :WHOST-DDD-COMERCIAL, :WHOST-FONE-COMERCIAL FROM SEGUROS.PESSOA_TELEFONE WHERE COD_PESSOA = :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA AND SITUACAO_FONE = 'P' AND TIPO_FONE = 2 END-EXEC. */

            var r2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1 = new R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1()
            {
                PROPOFID_COD_PESSOA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.ToString(),
            };

            var executed_1 = R2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1.Execute(r2230_00_SELECT_PESSOA_FONE_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DDD_COMERCIAL, WHOST_DDD_COMERCIAL);
                _.Move(executed_1.WHOST_FONE_COMERCIAL, WHOST_FONE_COMERCIAL);
            }


        }

        [StopWatch]
        /*" R2232-00-SELECT-PESSOA-FONE-SECTION */
        private void R2232_00_SELECT_PESSOA_FONE_SECTION()
        {
            /*" -4532- MOVE '2232-00-SELECT-PESSOA-FONE   ' TO PARAGRAFO. */
            _.Move("2232-00-SELECT-PESSOA-FONE   ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4535- MOVE 'DECLARE CURSOR PESSOA_TELEFONE' TO COMANDO. */
            _.Move("DECLARE CURSOR PESSOA_TELEFONE", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4539- MOVE ZEROS TO WHOST-DDD WHOST-FONE WHOST-FAX. */
            _.Move(0, WHOST_DDD, WHOST_FONE, WHOST_FAX);

            /*" -4540- MOVE 28 TO SII */
            _.Move(28, WS_HORAS.SII);

            /*" -4541- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -4549- PERFORM R2232_00_SELECT_PESSOA_FONE_DB_DECLARE_1 */

            R2232_00_SELECT_PESSOA_FONE_DB_DECLARE_1();

            /*" -4552- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -4552- PERFORM R2232_00_SELECT_PESSOA_FONE_DB_OPEN_1 */

            R2232_00_SELECT_PESSOA_FONE_DB_OPEN_1();

            /*" -4554- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4555- DISPLAY 'PROBLEMAS NO DECLARE PESSOA TELEFONE ' */
                _.Display($"PROBLEMAS NO DECLARE PESSOA TELEFONE ");

                /*" -4555- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM R2232_10_FETCH_PESSOA_FONE */

            R2232_10_FETCH_PESSOA_FONE();

        }

        [StopWatch]
        /*" R2232-00-SELECT-PESSOA-FONE-DB-OPEN-1 */
        public void R2232_00_SELECT_PESSOA_FONE_DB_OPEN_1()
        {
            /*" -4552- EXEC SQL OPEN CFONE END-EXEC. */

            CFONE.Open();

        }

        [StopWatch]
        /*" R2241-00-SELECT-ACUM-RISCO-DB-DECLARE-1 */
        public void R2241_00_SELECT_ACUM_RISCO_DB_DECLARE_1()
        {
            /*" -4724- EXEC SQL DECLARE CRISCO CURSOR FOR SELECT NUM_CERTIFICADO FROM SEGUROS.PROPOSTAS_VA WHERE NUM_APOLICE = :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE AND COD_CLIENTE = :DCLCLIENTES.COD-CLIENTE AND SIT_REGISTRO IN ( '0' , '3' , '6' , '7' , '9' ) END-EXEC. */
            CRISCO = new VP0601B_CRISCO(true);
            string GetQuery_CRISCO()
            {
                var query = @$"SELECT NUM_CERTIFICADO 
							FROM SEGUROS.PROPOSTAS_VA 
							WHERE NUM_APOLICE = 
							'{PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE}' 
							AND COD_CLIENTE = 
							'{CLIENTE.DCLCLIENTES.COD_CLIENTE}' 
							AND SIT_REGISTRO IN ( '0'
							, '3'
							, '6'
							, '7'
							, '9' )";

                return query;
            }
            CRISCO.GetQueryEvent += GetQuery_CRISCO;

        }

        [StopWatch]
        /*" R2230-00-SELECT-PESSOA-FONE-DB-SELECT-3 */
        public void R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3()
        {
            /*" -4454- EXEC SQL SELECT DDD, NUM_FONE INTO :WHOST-DDD-CELULAR, :WHOST-FONE-CELULAR FROM SEGUROS.PESSOA_TELEFONE WHERE COD_PESSOA = :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA AND SITUACAO_FONE = 'P' AND TIPO_FONE = 3 END-EXEC. */

            var r2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1 = new R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1()
            {
                PROPOFID_COD_PESSOA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.ToString(),
            };

            var executed_1 = R2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1.Execute(r2230_00_SELECT_PESSOA_FONE_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DDD_CELULAR, WHOST_DDD_CELULAR);
                _.Move(executed_1.WHOST_FONE_CELULAR, WHOST_FONE_CELULAR);
            }


        }

        [StopWatch]
        /*" R2232-10-FETCH-PESSOA-FONE */
        private void R2232_10_FETCH_PESSOA_FONE(bool isPerform = false)
        {
            /*" -4560- MOVE 'FETCH CFONE                  ' TO COMANDO. */
            _.Move("FETCH CFONE                  ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4565- PERFORM R2232_10_FETCH_PESSOA_FONE_DB_FETCH_1 */

            R2232_10_FETCH_PESSOA_FONE_DB_FETCH_1();

            /*" -4568- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4569- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4569- PERFORM R2232_10_FETCH_PESSOA_FONE_DB_CLOSE_1 */

                    R2232_10_FETCH_PESSOA_FONE_DB_CLOSE_1();

                    /*" -4574- GO TO R2232-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2232_99_SAIDA*/ //GOTO
                    return;

                    /*" -4575- ELSE */
                }
                else
                {


                    /*" -4576- DISPLAY 'PROBLEMAS FETCH ENDERECOS      ' */
                    _.Display($"PROBLEMAS FETCH ENDERECOS      ");

                    /*" -4584- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -4585- IF TIPO-FONE EQUAL 1 OR 2 OR 3 */

            if (PESFONE.DCLPESSOA_TELEFONE.TIPO_FONE.In("1", "2", "3"))
            {

                /*" -4586- MOVE DDD OF DCLPESSOA-TELEFONE TO WHOST-DDD */
                _.Move(PESFONE.DCLPESSOA_TELEFONE.DDD, WHOST_DDD);

                /*" -4587- MOVE NUM-FONE OF DCLPESSOA-TELEFONE TO WHOST-FONE */
                _.Move(PESFONE.DCLPESSOA_TELEFONE.NUM_FONE, WHOST_FONE);

                /*" -4588- ELSE */
            }
            else
            {


                /*" -4590- MOVE NUM-FONE OF DCLPESSOA-TELEFONE TO WHOST-FAX. */
                _.Move(PESFONE.DCLPESSOA_TELEFONE.NUM_FONE, WHOST_FAX);
            }


            /*" -4590- GO TO R2232-10-FETCH-PESSOA-FONE. */
            new Task(() => R2232_10_FETCH_PESSOA_FONE()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R2232-10-FETCH-PESSOA-FONE-DB-FETCH-1 */
        public void R2232_10_FETCH_PESSOA_FONE_DB_FETCH_1()
        {
            /*" -4565- EXEC SQL FETCH CFONE INTO :DCLPESSOA-TELEFONE.TIPO-FONE, :DCLPESSOA-TELEFONE.DDD, :DCLPESSOA-TELEFONE.NUM-FONE END-EXEC. */

            if (CFONE.Fetch())
            {
                _.Move(CFONE.DCLPESSOA_TELEFONE_TIPO_FONE, PESFONE.DCLPESSOA_TELEFONE.TIPO_FONE);
                _.Move(CFONE.DCLPESSOA_TELEFONE_DDD, PESFONE.DCLPESSOA_TELEFONE.DDD);
                _.Move(CFONE.DCLPESSOA_TELEFONE_NUM_FONE, PESFONE.DCLPESSOA_TELEFONE.NUM_FONE);
            }

        }

        [StopWatch]
        /*" R2232-10-FETCH-PESSOA-FONE-DB-CLOSE-1 */
        public void R2232_10_FETCH_PESSOA_FONE_DB_CLOSE_1()
        {
            /*" -4569- EXEC SQL CLOSE CFONE END-EXEC */

            CFONE.Close();

        }

        [StopWatch]
        /*" R2230-00-SELECT-PESSOA-FONE-DB-SELECT-4 */
        public void R2230_00_SELECT_PESSOA_FONE_DB_SELECT_4()
        {
            /*" -4483- EXEC SQL SELECT DDD, NUM_FONE INTO :WHOST-DDD-FAX, :WHOST-FONE-FAX FROM SEGUROS.PESSOA_TELEFONE WHERE COD_PESSOA = :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA AND SITUACAO_FONE = 'P' AND TIPO_FONE = 4 END-EXEC. */

            var r2230_00_SELECT_PESSOA_FONE_DB_SELECT_4_Query1 = new R2230_00_SELECT_PESSOA_FONE_DB_SELECT_4_Query1()
            {
                PROPOFID_COD_PESSOA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.ToString(),
            };

            var executed_1 = R2230_00_SELECT_PESSOA_FONE_DB_SELECT_4_Query1.Execute(r2230_00_SELECT_PESSOA_FONE_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DDD_FAX, WHOST_DDD_FAX);
                _.Move(executed_1.WHOST_FONE_FAX, WHOST_FONE_FAX);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2232_99_SAIDA*/

        [StopWatch]
        /*" R2235-00-UPDATE-PESSOA-FONE-SECTION */
        private void R2235_00_UPDATE_PESSOA_FONE_SECTION()
        {
            /*" -4599- MOVE '2235-00-UPDATE-PESSOA-FONE   ' TO PARAGRAFO. */
            _.Move("2235-00-UPDATE-PESSOA-FONE   ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4602- MOVE 'UPDATE PESSOA_TELEFONE       ' TO COMANDO. */
            _.Move("UPDATE PESSOA_TELEFONE       ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4603- MOVE 29 TO SII */
            _.Move(29, WS_HORAS.SII);

            /*" -4604- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -4609- PERFORM R2235_00_UPDATE_PESSOA_FONE_DB_UPDATE_1 */

            R2235_00_UPDATE_PESSOA_FONE_DB_UPDATE_1();

            /*" -4612- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -4613- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -4614- DISPLAY 'PROBLEMAS NO UPDATE  PESSOA TELEFONE ' */
                _.Display($"PROBLEMAS NO UPDATE  PESSOA TELEFONE ");

                /*" -4614- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2235-00-UPDATE-PESSOA-FONE-DB-UPDATE-1 */
        public void R2235_00_UPDATE_PESSOA_FONE_DB_UPDATE_1()
        {
            /*" -4609- EXEC SQL UPDATE SEGUROS.PESSOA_TELEFONE SET SITUACAO_FONE = 'A' WHERE COD_PESSOA = :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA AND SITUACAO_FONE = 'P' END-EXEC. */

            var r2235_00_UPDATE_PESSOA_FONE_DB_UPDATE_1_Update1 = new R2235_00_UPDATE_PESSOA_FONE_DB_UPDATE_1_Update1()
            {
                PROPOFID_COD_PESSOA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.ToString(),
            };

            R2235_00_UPDATE_PESSOA_FONE_DB_UPDATE_1_Update1.Execute(r2235_00_UPDATE_PESSOA_FONE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2235_99_SAIDA*/

        [StopWatch]
        /*" R2236-00-SELECT-PESSOA-EMAIL-SECTION */
        private void R2236_00_SELECT_PESSOA_EMAIL_SECTION()
        {
            /*" -4623- MOVE '2236-00-SELECT-PESSOA-EMAIL  ' TO PARAGRAFO. */
            _.Move("2236-00-SELECT-PESSOA-EMAIL  ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4626- MOVE 'SELECT PESSOA_EMAIL     ' TO COMANDO. */
            _.Move("SELECT PESSOA_EMAIL     ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4627- MOVE 30 TO SII */
            _.Move(30, WS_HORAS.SII);

            /*" -4628- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -4635- PERFORM R2236_00_SELECT_PESSOA_EMAIL_DB_SELECT_1 */

            R2236_00_SELECT_PESSOA_EMAIL_DB_SELECT_1();

            /*" -4638- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -4639- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4640- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4641- MOVE SPACES TO WHOST-EMAIL */
                    _.Move("", WHOST_EMAIL);

                    /*" -4642- GO TO R2236-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2236_99_SAIDA*/ //GOTO
                    return;

                    /*" -4643- ELSE */
                }
                else
                {


                    /*" -4645- IF SQLCODE EQUAL -811 NEXT SENTENCE */

                    if (DB.SQLCODE == -811)
                    {

                        /*" -4646- ELSE */
                    }
                    else
                    {


                        /*" -4647- DISPLAY 'PROBLEMAS NO SELECT  PESSOA EMAIL' */
                        _.Display($"PROBLEMAS NO SELECT  PESSOA EMAIL");

                        /*" -4649- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -4652- MOVE 'UPDATE PESSOA_EMAIL     ' TO COMANDO. */
            _.Move("UPDATE PESSOA_EMAIL     ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4653- MOVE 31 TO SII */
            _.Move(31, WS_HORAS.SII);

            /*" -4654- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -4659- PERFORM R2236_00_SELECT_PESSOA_EMAIL_DB_UPDATE_1 */

            R2236_00_SELECT_PESSOA_EMAIL_DB_UPDATE_1();

            /*" -4662- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -4663- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4664- DISPLAY 'PROBLEMAS NO UPDATE PESSOA EMAIL' */
                _.Display($"PROBLEMAS NO UPDATE PESSOA EMAIL");

                /*" -4665- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2236-00-SELECT-PESSOA-EMAIL-DB-SELECT-1 */
        public void R2236_00_SELECT_PESSOA_EMAIL_DB_SELECT_1()
        {
            /*" -4635- EXEC SQL SELECT EMAIL INTO :WHOST-EMAIL FROM SEGUROS.PESSOA_EMAIL WHERE COD_PESSOA = :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA AND SITUACAO_EMAIL = 'P' END-EXEC. */

            var r2236_00_SELECT_PESSOA_EMAIL_DB_SELECT_1_Query1 = new R2236_00_SELECT_PESSOA_EMAIL_DB_SELECT_1_Query1()
            {
                PROPOFID_COD_PESSOA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.ToString(),
            };

            var executed_1 = R2236_00_SELECT_PESSOA_EMAIL_DB_SELECT_1_Query1.Execute(r2236_00_SELECT_PESSOA_EMAIL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_EMAIL, WHOST_EMAIL);
            }


        }

        [StopWatch]
        /*" R2236-00-SELECT-PESSOA-EMAIL-DB-UPDATE-1 */
        public void R2236_00_SELECT_PESSOA_EMAIL_DB_UPDATE_1()
        {
            /*" -4659- EXEC SQL UPDATE SEGUROS.PESSOA_EMAIL SET SITUACAO_EMAIL = 'A' WHERE COD_PESSOA = :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA AND SITUACAO_EMAIL = 'P' END-EXEC. */

            var r2236_00_SELECT_PESSOA_EMAIL_DB_UPDATE_1_Update1 = new R2236_00_SELECT_PESSOA_EMAIL_DB_UPDATE_1_Update1()
            {
                PROPOFID_COD_PESSOA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.ToString(),
            };

            R2236_00_SELECT_PESSOA_EMAIL_DB_UPDATE_1_Update1.Execute(r2236_00_SELECT_PESSOA_EMAIL_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2236_99_SAIDA*/

        [StopWatch]
        /*" R2240-00-SELECT-PROPFIDC-SECTION */
        private void R2240_00_SELECT_PROPFIDC_SECTION()
        {
            /*" -4673- MOVE '2240-00-SELECT-PROPFIDC      ' TO PARAGRAFO. */
            _.Move("2240-00-SELECT-PROPFIDC      ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4676- MOVE 'SELECT PROPFIDC               ' TO COMANDO. */
            _.Move("SELECT PROPFIDC               ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4677- MOVE 32 TO SII */
            _.Move(32, WS_HORAS.SII);

            /*" -4678- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -4685- PERFORM R2240_00_SELECT_PROPFIDC_DB_SELECT_1 */

            R2240_00_SELECT_PROPFIDC_DB_SELECT_1();

            /*" -4688- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -4689- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4690- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4692- MOVE SPACES TO PROFIDCO-INFORMACAO-COMPL OF DCLPROP-FIDELIZ-COMP */
                    _.Move("", PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_INFORMACAO_COMPL);

                    /*" -4693- ELSE */
                }
                else
                {


                    /*" -4694- DISPLAY 'PROBLEMAS NO ACESSOA A PROPFIDC ' */
                    _.Display($"PROBLEMAS NO ACESSOA A PROPFIDC ");

                    /*" -4696- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -4697- MOVE PROFIDCO-INFORMACAO-COMPL OF DCLPROP-FIDELIZ-COMP TO WHOST-INFO-COMPL. */
            _.Move(PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_INFORMACAO_COMPL, WHOST_INFO_COMPL);

        }

        [StopWatch]
        /*" R2240-00-SELECT-PROPFIDC-DB-SELECT-1 */
        public void R2240_00_SELECT_PROPFIDC_DB_SELECT_1()
        {
            /*" -4685- EXEC SQL SELECT INFORMACAO_COMPL INTO :DCLPROP-FIDELIZ-COMP.PROFIDCO-INFORMACAO-COMPL FROM SEGUROS.PROP_FIDELIZ_COMP WHERE NUM_IDENTIFICACAO = :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-IDENTIFICACAO AND IND_TP_INFORMACAO = '1' END-EXEC. */

            var r2240_00_SELECT_PROPFIDC_DB_SELECT_1_Query1 = new R2240_00_SELECT_PROPFIDC_DB_SELECT_1_Query1()
            {
                PROPSSVD_NUM_IDENTIFICACAO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_IDENTIFICACAO.ToString(),
            };

            var executed_1 = R2240_00_SELECT_PROPFIDC_DB_SELECT_1_Query1.Execute(r2240_00_SELECT_PROPFIDC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROFIDCO_INFORMACAO_COMPL, PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_INFORMACAO_COMPL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2240_99_SAIDA*/

        [StopWatch]
        /*" R2241-00-SELECT-ACUM-RISCO-SECTION */
        private void R2241_00_SELECT_ACUM_RISCO_SECTION()
        {
            /*" -4708- MOVE '2241-00-SELECT-ACUM-RISCO     ' TO PARAGRAFO. */
            _.Move("2241-00-SELECT-ACUM-RISCO     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4711- MOVE IMPMORNATU OF DCLPLANOS-VA-VGAP TO AC-TOT-RISCO. */
            _.Move(PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU, WORK_AREA.AC_TOT_RISCO);

            /*" -4712- MOVE 'DECLARE CURSOR CRISCO         ' TO COMANDO. */
            _.Move("DECLARE CURSOR CRISCO         ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4724- PERFORM R2241_00_SELECT_ACUM_RISCO_DB_DECLARE_1 */

            R2241_00_SELECT_ACUM_RISCO_DB_DECLARE_1();

            /*" -4727- MOVE 76 TO SII */
            _.Move(76, WS_HORAS.SII);

            /*" -4728- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -4728- PERFORM R2241_00_SELECT_ACUM_RISCO_DB_OPEN_1 */

            R2241_00_SELECT_ACUM_RISCO_DB_OPEN_1();

            /*" -4731- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -4732- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4733- DISPLAY 'VP0601B - PROBLEMAS NO DECLARE PROPOSTAS_VA' */
                _.Display($"VP0601B - PROBLEMAS NO DECLARE PROPOSTAS_VA");

                /*" -4735- DISPLAY '          NUM_APOLICE...........   ' PROPSSVD-NUM-APOLICE OF DCLPROP-SASSE-VIDA */
                _.Display($"          NUM_APOLICE...........   {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE}");

                /*" -4737- DISPLAY '          CODSUBES..............   ' PROPSSVD-COD-SUBGRUPO OF DCLPROP-SASSE-VIDA */
                _.Display($"          CODSUBES..............   {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO}");

                /*" -4739- DISPLAY '          SQLCODE...............   ' SQLCODE */
                _.Display($"          SQLCODE...............   {DB.SQLCODE}");

                /*" -4740- GO TO R2241-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2241_99_SAIDA*/ //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM R2241_10_FETCH */

            R2241_10_FETCH();

        }

        [StopWatch]
        /*" R2241-00-SELECT-ACUM-RISCO-DB-OPEN-1 */
        public void R2241_00_SELECT_ACUM_RISCO_DB_OPEN_1()
        {
            /*" -4728- EXEC SQL OPEN CRISCO END-EXEC. */

            CRISCO.Open();

        }

        [StopWatch]
        /*" R2300-00-TRATA-CLIENTES-DB-DECLARE-1 */
        public void R2300_00_TRATA_CLIENTES_DB_DECLARE_1()
        {
            /*" -5064- EXEC SQL DECLARE CCLIENTES CURSOR FOR SELECT COD_CLIENTE FROM SEGUROS.CLIENTES WHERE CGCCPF = :DCLPESSOA-FISICA.CPF AND DATA_NASCIMENTO = :DCLPESSOA-FISICA.DATA-NASCIMENTO AND NOME_RAZAO <> ' ' ORDER BY COD_CLIENTE DESC END-EXEC. */
            CCLIENTES = new VP0601B_CCLIENTES(true);
            string GetQuery_CCLIENTES()
            {
                var query = @$"SELECT COD_CLIENTE 
							FROM SEGUROS.CLIENTES 
							WHERE CGCCPF = '{PESFIS.DCLPESSOA_FISICA.CPF}' 
							AND DATA_NASCIMENTO = '{PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO}' 
							AND NOME_RAZAO <> ' ' 
							ORDER BY COD_CLIENTE DESC";

                return query;
            }
            CCLIENTES.GetQueryEvent += GetQuery_CCLIENTES;

        }

        [StopWatch]
        /*" R2241-10-FETCH */
        private void R2241_10_FETCH(bool isPerform = false)
        {
            /*" -4744- MOVE 'FETCH  CRISCO                ' TO COMANDO. */
            _.Move("FETCH  CRISCO                ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4747- PERFORM R2241_10_FETCH_DB_FETCH_1 */

            R2241_10_FETCH_DB_FETCH_1();

            /*" -4750- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4751- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4751- PERFORM R2241_10_FETCH_DB_CLOSE_1 */

                    R2241_10_FETCH_DB_CLOSE_1();

                    /*" -4753- GO TO R2241-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2241_99_SAIDA*/ //GOTO
                    return;

                    /*" -4754- ELSE */
                }
                else
                {


                    /*" -4754- PERFORM R2241_10_FETCH_DB_CLOSE_2 */

                    R2241_10_FETCH_DB_CLOSE_2();

                    /*" -4756- DISPLAY 'VP0601B - PROBLEMAS NO FETCH PROPOSTAS_VA' */
                    _.Display($"VP0601B - PROBLEMAS NO FETCH PROPOSTAS_VA");

                    /*" -4758- DISPLAY '          NUM_APOLICE...........   ' PROPSSVD-NUM-APOLICE OF DCLPROP-SASSE-VIDA */
                    _.Display($"          NUM_APOLICE...........   {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE}");

                    /*" -4760- DISPLAY '          CODSUBES..............   ' PROPSSVD-COD-SUBGRUPO OF DCLPROP-SASSE-VIDA */
                    _.Display($"          CODSUBES..............   {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO}");

                    /*" -4762- DISPLAY '          SQLCODE...............   ' SQLCODE */
                    _.Display($"          SQLCODE...............   {DB.SQLCODE}");

                    /*" -4764- GO TO R2241-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2241_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -4765- MOVE 77 TO SII */
            _.Move(77, WS_HORAS.SII);

            /*" -4766- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -4773- PERFORM R2241_10_FETCH_DB_SELECT_1 */

            R2241_10_FETCH_DB_SELECT_1();

            /*" -4776- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -4777- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4778- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4780- MOVE ZEROS TO IMP-MORNATU OF DCLHIS-COBER-PROPOST */
                    _.Move(0, COBPRPVA.DCLHIS_COBER_PROPOST.IMP_MORNATU);

                    /*" -4781- ELSE */
                }
                else
                {


                    /*" -4782- DISPLAY 'VP0601B - PROBLEMAS ACESSO HIS_COBER_PROPOST ' */
                    _.Display($"VP0601B - PROBLEMAS ACESSO HIS_COBER_PROPOST ");

                    /*" -4784- DISPLAY '          NUM_CERTIFICADO.......   ' PROPVA-NRCERTIF */
                    _.Display($"          NUM_CERTIFICADO.......   {PROPVA_NRCERTIF}");

                    /*" -4786- DISPLAY '          SQLCODE...............   ' SQLCODE */
                    _.Display($"          SQLCODE...............   {DB.SQLCODE}");

                    /*" -4788- GO TO R2241-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2241_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -4791- ADD IMP-MORNATU OF DCLHIS-COBER-PROPOST TO AC-TOT-RISCO. */
            WORK_AREA.AC_TOT_RISCO.Value = WORK_AREA.AC_TOT_RISCO + COBPRPVA.DCLHIS_COBER_PROPOST;

            /*" -4791- GO TO R2241-10-FETCH. */
            new Task(() => R2241_10_FETCH()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R2241-10-FETCH-DB-FETCH-1 */
        public void R2241_10_FETCH_DB_FETCH_1()
        {
            /*" -4747- EXEC SQL FETCH CRISCO INTO :PROPVA-NRCERTIF END-EXEC. */

            if (CRISCO.Fetch())
            {
                _.Move(CRISCO.PROPVA_NRCERTIF, PROPVA_NRCERTIF);
            }

        }

        [StopWatch]
        /*" R2241-10-FETCH-DB-CLOSE-1 */
        public void R2241_10_FETCH_DB_CLOSE_1()
        {
            /*" -4751- EXEC SQL CLOSE CRISCO END-EXEC */

            CRISCO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2241_99_SAIDA*/

        [StopWatch]
        /*" R2241-10-FETCH-DB-SELECT-1 */
        public void R2241_10_FETCH_DB_SELECT_1()
        {
            /*" -4773- EXEC SQL SELECT IMP_MORNATU INTO :DCLHIS-COBER-PROPOST.IMP-MORNATU FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :PROPVA-NRCERTIF AND DATA_TERVIGENCIA = '9999-12-31' END-EXEC. */

            var r2241_10_FETCH_DB_SELECT_1_Query1 = new R2241_10_FETCH_DB_SELECT_1_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = R2241_10_FETCH_DB_SELECT_1_Query1.Execute(r2241_10_FETCH_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.IMP_MORNATU, COBPRPVA.DCLHIS_COBER_PROPOST.IMP_MORNATU);
            }


        }

        [StopWatch]
        /*" R2241-10-FETCH-DB-CLOSE-2 */
        public void R2241_10_FETCH_DB_CLOSE_2()
        {
            /*" -4754- EXEC SQL CLOSE CRISCO END-EXEC */

            CRISCO.Close();

        }

        [StopWatch]
        /*" R2245-VALIDAR-IMPORTANCIA-SECTION */
        private void R2245_VALIDAR_IMPORTANCIA_SECTION()
        {
            /*" -4798- MOVE '2245-VALIDAR-IMPORTANCIA     ' TO PARAGRAFO. */
            _.Move("2245-VALIDAR-IMPORTANCIA     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4813- PERFORM R2245_VALIDAR_IMPORTANCIA_DB_SELECT_1 */

            R2245_VALIDAR_IMPORTANCIA_DB_SELECT_1();

            /*" -4816- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -4817- IF PROPOFID-OPCAO-COBER = '1' */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER == "1")
                {

                    /*" -4818- MOVE SPACES TO PROPOFID-OPCAO-COBER */
                    _.Move("", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER);

                    /*" -4833- PERFORM R2245_VALIDAR_IMPORTANCIA_DB_SELECT_2 */

                    R2245_VALIDAR_IMPORTANCIA_DB_SELECT_2();

                    /*" -4835- END-IF */
                }


                /*" -4837- END-IF */
            }


            /*" -4838- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4839- DISPLAY 'VP0601B-ERRO NO SELECT PLANOS_VA_VGAP1 ' SQLCODE */
                _.Display($"VP0601B-ERRO NO SELECT PLANOS_VA_VGAP1 {DB.SQLCODE}");

                /*" -4841- DISPLAY 'NUM_APOLICE   = ' PROPSSVD-NUM-APOLICE OF DCLPROP-SASSE-VIDA */
                _.Display($"NUM_APOLICE   = {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE}");

                /*" -4843- DISPLAY 'CODSUBES      = ' PROPSSVD-COD-SUBGRUPO OF DCLPROP-SASSE-VIDA */
                _.Display($"CODSUBES      = {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO}");

                /*" -4845- DISPLAY 'COD_PLANO     = ' PROPOFID-COD-PLANO OF DCLPROPOSTA-FIDELIZ */
                _.Display($"COD_PLANO     = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO}");

                /*" -4847- DISPLAY 'OPCAO_COBER   = ' PROPOFID-OPCAO-COBER OF DCLPROPOSTA-FIDELIZ */
                _.Display($"OPCAO_COBER   = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER}");

                /*" -4849- DISPLAY 'DTINIVIG      = ' PROPOFID-DTQITBCO OF DCLPROPOSTA-FIDELIZ */
                _.Display($"DTINIVIG      = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO}");

                /*" -4851- DISPLAY 'DTTERVIG      = ' PROPOFID-DTQITBCO OF DCLPROPOSTA-FIDELIZ */
                _.Display($"DTTERVIG      = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO}");

                /*" -4852- DISPLAY 'IDADE_INICIAL = ' WHOST-IDADE-2 */
                _.Display($"IDADE_INICIAL = {WHOST_IDADE_2}");

                /*" -4853- DISPLAY 'IDADE_FINAL   = ' WHOST-IDADE-2 */
                _.Display($"IDADE_FINAL   = {WHOST_IDADE_2}");

                /*" -4854- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4856- END-IF. */
            }


            /*" -4858- IF FAIXA-SAL-FIM OF DCLPLANOS-VA-VGAP > 15000,00 */

            if (PLVAVGAP.DCLPLANOS_VA_VGAP.FAIXA_SAL_FIM > 15000.00)
            {

                /*" -4859- MOVE PRODUVG-COD-PRODUTO TO GE400-COD-PRODUTO */
                _.Move(PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO, GE400.DCLGE_IS_SUPERIOR.GE400_COD_PRODUTO);

                /*" -4860- MOVE PROPSSVD-NUM-APOLICE TO GE400-NUM-APOLICE */
                _.Move(PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE, GE400.DCLGE_IS_SUPERIOR.GE400_NUM_APOLICE);

                /*" -4862- MOVE CPF OF DCLPESSOA-FISICA TO GE400-NUM-CPF */
                _.Move(PESFIS.DCLPESSOA_FISICA.CPF, GE400.DCLGE_IS_SUPERIOR.GE400_NUM_CPF);

                /*" -4869- PERFORM R1111-00-TRATAR-VR-IS-SUPERIOR */

                R1111_00_TRATAR_VR_IS_SUPERIOR_SECTION();

                /*" -4870- IF WS-CADASTRO-IS-SUPERIOR = ZEROS */

                if (WS_CADASTRO_IS_SUPERIOR == 00)
                {

                    /*" -4872- DISPLAY '-------------------------------------------------' */
                    _.Display($"-------------------------------------------------");

                    /*" -4874- DISPLAY 'VALOR DA IMPORTANCIA SEGURADA ACIMA DO PERMITIDO.' */
                    _.Display($"VALOR DA IMPORTANCIA SEGURADA ACIMA DO PERMITIDO.");

                    /*" -4875- DISPLAY 'NUM-APOLICE     = ' GE400-NUM-APOLICE */
                    _.Display($"NUM-APOLICE     = {GE400.DCLGE_IS_SUPERIOR.GE400_NUM_APOLICE}");

                    /*" -4876- DISPLAY 'COD-PRODUTO     = ' GE400-COD-PRODUTO */
                    _.Display($"COD-PRODUTO     = {GE400.DCLGE_IS_SUPERIOR.GE400_COD_PRODUTO}");

                    /*" -4877- DISPLAY 'CPF DO SEGURADO = ' GE400-NUM-CPF */
                    _.Display($"CPF DO SEGURADO = {GE400.DCLGE_IS_SUPERIOR.GE400_NUM_CPF}");

                    /*" -4879- DISPLAY 'VALOR DA IMPORTANCIA SEGURADA = ' FAIXA-SAL-FIM OF DCLPLANOS-VA-VGAP */
                    _.Display($"VALOR DA IMPORTANCIA SEGURADA = {PLVAVGAP.DCLPLANOS_VA_VGAP.FAIXA_SAL_FIM}");

                    /*" -4881- DISPLAY 'PROPOSTA ---------> ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"PROPOSTA ---------> {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -4883- DISPLAY '-------------------------------------------------' */
                    _.Display($"-------------------------------------------------");

                    /*" -4884- MOVE 1855 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                    _.Move(1855, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                    /*" -4885- PERFORM R1100-00-INSERT-ERROSPROPVA */

                    R1100_00_INSERT_ERROSPROPVA_SECTION();

                    /*" -4886- END-IF */
                }


                /*" -4886- END-IF. */
            }


        }

        [StopWatch]
        /*" R2245-VALIDAR-IMPORTANCIA-DB-SELECT-1 */
        public void R2245_VALIDAR_IMPORTANCIA_DB_SELECT_1()
        {
            /*" -4813- EXEC SQL SELECT FAIXA_SAL_FIM, TAXAVG INTO :DCLPLANOS-VA-VGAP.FAIXA-SAL-FIM, :DCLPLANOS-VA-VGAP.TAXAVG FROM SEGUROS.PLANOS_VA_VGAP WHERE NUM_APOLICE = :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE AND CODSUBES = :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO AND COD_PLANO = :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PLANO AND OPCAO_COBER = :DCLPROPOSTA-FIDELIZ.PROPOFID-OPCAO-COBER AND DTINIVIG <= :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO AND DTTERVIG >= :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO AND IDADE_INICIAL <= :WHOST-IDADE-2 AND IDADE_FINAL >= :WHOST-IDADE-2 WITH UR END-EXEC */

            var r2245_VALIDAR_IMPORTANCIA_DB_SELECT_1_Query1 = new R2245_VALIDAR_IMPORTANCIA_DB_SELECT_1_Query1()
            {
                PROPSSVD_COD_SUBGRUPO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.ToString(),
                PROPOFID_OPCAO_COBER = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER.ToString(),
                PROPSSVD_NUM_APOLICE = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.ToString(),
                PROPOFID_COD_PLANO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO.ToString(),
                PROPOFID_DTQITBCO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.ToString(),
                WHOST_IDADE_2 = WHOST_IDADE_2.ToString(),
            };

            var executed_1 = R2245_VALIDAR_IMPORTANCIA_DB_SELECT_1_Query1.Execute(r2245_VALIDAR_IMPORTANCIA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FAIXA_SAL_FIM, PLVAVGAP.DCLPLANOS_VA_VGAP.FAIXA_SAL_FIM);
                _.Move(executed_1.TAXAVG, PLVAVGAP.DCLPLANOS_VA_VGAP.TAXAVG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2245_99_SAIDA*/

        [StopWatch]
        /*" R2245-VALIDAR-IMPORTANCIA-DB-SELECT-2 */
        public void R2245_VALIDAR_IMPORTANCIA_DB_SELECT_2()
        {
            /*" -4833- EXEC SQL SELECT FAIXA_SAL_FIM, TAXAVG INTO :DCLPLANOS-VA-VGAP.FAIXA-SAL-FIM, :DCLPLANOS-VA-VGAP.TAXAVG FROM SEGUROS.PLANOS_VA_VGAP WHERE NUM_APOLICE = :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE AND CODSUBES = :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO AND COD_PLANO = :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PLANO AND OPCAO_COBER = :DCLPROPOSTA-FIDELIZ.PROPOFID-OPCAO-COBER AND DTINIVIG <= :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO AND DTTERVIG >= :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO AND IDADE_INICIAL <= :WHOST-IDADE-2 AND IDADE_FINAL >= :WHOST-IDADE-2 WITH UR END-EXEC */

            var r2245_VALIDAR_IMPORTANCIA_DB_SELECT_2_Query1 = new R2245_VALIDAR_IMPORTANCIA_DB_SELECT_2_Query1()
            {
                PROPSSVD_COD_SUBGRUPO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.ToString(),
                PROPOFID_OPCAO_COBER = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER.ToString(),
                PROPSSVD_NUM_APOLICE = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.ToString(),
                PROPOFID_COD_PLANO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO.ToString(),
                PROPOFID_DTQITBCO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.ToString(),
                WHOST_IDADE_2 = WHOST_IDADE_2.ToString(),
            };

            var executed_1 = R2245_VALIDAR_IMPORTANCIA_DB_SELECT_2_Query1.Execute(r2245_VALIDAR_IMPORTANCIA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FAIXA_SAL_FIM, PLVAVGAP.DCLPLANOS_VA_VGAP.FAIXA_SAL_FIM);
                _.Move(executed_1.TAXAVG, PLVAVGAP.DCLPLANOS_VA_VGAP.TAXAVG);
            }


        }

        [StopWatch]
        /*" R2246-CALCULO-IS-7713-SECTION */
        private void R2246_CALCULO_IS_7713_SECTION()
        {
            /*" -4896- COMPUTE WS-VALOR-IS = (RCAPS-VAL-RCAP OF DCLRCAPS * 100) / TAXAVG OF DCLPLANOS-VA-VGAP. */
            WS_VALOR_IS.Value = (RCAPS.DCLRCAPS.RCAPS_VAL_RCAP * 100) / PLVAVGAP.DCLPLANOS_VA_VGAP.TAXAVG;

            /*" -4898- IF WS-VALOR-IS > 15000,00 */

            if (WS_VALOR_IS > 15000.00)
            {

                /*" -4899- MOVE PRODUVG-COD-PRODUTO TO GE400-COD-PRODUTO */
                _.Move(PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO, GE400.DCLGE_IS_SUPERIOR.GE400_COD_PRODUTO);

                /*" -4900- MOVE PROPSSVD-NUM-APOLICE TO GE400-NUM-APOLICE */
                _.Move(PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE, GE400.DCLGE_IS_SUPERIOR.GE400_NUM_APOLICE);

                /*" -4902- MOVE CPF OF DCLPESSOA-FISICA TO GE400-NUM-CPF */
                _.Move(PESFIS.DCLPESSOA_FISICA.CPF, GE400.DCLGE_IS_SUPERIOR.GE400_NUM_CPF);

                /*" -4909- PERFORM R1111-00-TRATAR-VR-IS-SUPERIOR */

                R1111_00_TRATAR_VR_IS_SUPERIOR_SECTION();

                /*" -4910- IF WS-CADASTRO-IS-SUPERIOR = ZEROS */

                if (WS_CADASTRO_IS_SUPERIOR == 00)
                {

                    /*" -4912- DISPLAY '-------------------------------------------------' */
                    _.Display($"-------------------------------------------------");

                    /*" -4914- DISPLAY 'VALOR DA IMPORTANCIA SEGURADA ACIMA DO PERMITIDO.' */
                    _.Display($"VALOR DA IMPORTANCIA SEGURADA ACIMA DO PERMITIDO.");

                    /*" -4915- DISPLAY 'NUM-APOLICE     = ' GE400-NUM-APOLICE */
                    _.Display($"NUM-APOLICE     = {GE400.DCLGE_IS_SUPERIOR.GE400_NUM_APOLICE}");

                    /*" -4916- DISPLAY 'COD-PRODUTO     = ' GE400-COD-PRODUTO */
                    _.Display($"COD-PRODUTO     = {GE400.DCLGE_IS_SUPERIOR.GE400_COD_PRODUTO}");

                    /*" -4917- DISPLAY 'CPF DO SEGURADO = ' GE400-NUM-CPF */
                    _.Display($"CPF DO SEGURADO = {GE400.DCLGE_IS_SUPERIOR.GE400_NUM_CPF}");

                    /*" -4919- DISPLAY 'VALOR DA IMPORTANCIA SEGURADA = ' WS-VALOR-IS */
                    _.Display($"VALOR DA IMPORTANCIA SEGURADA = {WS_VALOR_IS}");

                    /*" -4921- DISPLAY 'PROPOSTA ---------> ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"PROPOSTA ---------> {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -4923- DISPLAY '-------------------------------------------------' */
                    _.Display($"-------------------------------------------------");

                    /*" -4924- MOVE 1855 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                    _.Move(1855, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                    /*" -4925- PERFORM R1100-00-INSERT-ERROSPROPVA */

                    R1100_00_INSERT_ERROSPROPVA_SECTION();

                    /*" -4926- END-IF */
                }


                /*" -4926- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2246_99_SAIDA*/

        [StopWatch]
        /*" R2248-CALCULO-IS-7715-SECTION */
        private void R2248_CALCULO_IS_7715_SECTION()
        {
            /*" -4934- MOVE 'R2248-CALCULO-IS-7715   ' TO PARAGRAFO. */
            _.Move("R2248-CALCULO-IS-7715   ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4939- MOVE ZEROS TO WS-VALOR-IS */
            _.Move(0, WS_VALOR_IS);

            /*" -4942- COMPUTE WS-VALOR-IS = (RCAPS-VAL-RCAP OF DCLRCAPS * 100) / TAXAVG OF DCLPLANOS-VA-VGAP */
            WS_VALOR_IS.Value = (RCAPS.DCLRCAPS.RCAPS_VAL_RCAP * 100) / PLVAVGAP.DCLPLANOS_VA_VGAP.TAXAVG;

            /*" -4944- IF WS-VALOR-IS < 200,00 OR WS-VALOR-IS > 15000,00 */

            if (WS_VALOR_IS < 200.00 || WS_VALOR_IS > 15000.00)
            {

                /*" -4945- MOVE PRODUVG-COD-PRODUTO TO GE400-COD-PRODUTO */
                _.Move(PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO, GE400.DCLGE_IS_SUPERIOR.GE400_COD_PRODUTO);

                /*" -4946- MOVE PROPSSVD-NUM-APOLICE TO GE400-NUM-APOLICE */
                _.Move(PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE, GE400.DCLGE_IS_SUPERIOR.GE400_NUM_APOLICE);

                /*" -4948- MOVE CPF OF DCLPESSOA-FISICA TO GE400-NUM-CPF */
                _.Move(PESFIS.DCLPESSOA_FISICA.CPF, GE400.DCLGE_IS_SUPERIOR.GE400_NUM_CPF);

                /*" -4950- PERFORM R1111-00-TRATAR-VR-IS-SUPERIOR */

                R1111_00_TRATAR_VR_IS_SUPERIOR_SECTION();

                /*" -4951- IF WS-CADASTRO-IS-SUPERIOR = ZEROS */

                if (WS_CADASTRO_IS_SUPERIOR == 00)
                {

                    /*" -4953- DISPLAY '-------------------------------------------------' */
                    _.Display($"-------------------------------------------------");

                    /*" -4955- DISPLAY 'VALOR DA IMPORTANCIA SEGURADA ACIMA DO PERMITIDO.' */
                    _.Display($"VALOR DA IMPORTANCIA SEGURADA ACIMA DO PERMITIDO.");

                    /*" -4956- DISPLAY 'NUM-APOLICE     = ' GE400-NUM-APOLICE */
                    _.Display($"NUM-APOLICE     = {GE400.DCLGE_IS_SUPERIOR.GE400_NUM_APOLICE}");

                    /*" -4957- DISPLAY 'COD-PRODUTO     = ' GE400-COD-PRODUTO */
                    _.Display($"COD-PRODUTO     = {GE400.DCLGE_IS_SUPERIOR.GE400_COD_PRODUTO}");

                    /*" -4958- DISPLAY 'CPF DO SEGURADO = ' GE400-NUM-CPF */
                    _.Display($"CPF DO SEGURADO = {GE400.DCLGE_IS_SUPERIOR.GE400_NUM_CPF}");

                    /*" -4960- DISPLAY 'VALOR DA IMPORTANCIA SEGURADA = ' WS-VALOR-IS */
                    _.Display($"VALOR DA IMPORTANCIA SEGURADA = {WS_VALOR_IS}");

                    /*" -4962- DISPLAY 'PROPOSTA ---------> ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"PROPOSTA ---------> {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -4964- DISPLAY '-------------------------------------------------' */
                    _.Display($"-------------------------------------------------");

                    /*" -4965- MOVE 1855 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                    _.Move(1855, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                    /*" -4966- PERFORM R1100-00-INSERT-ERROSPROPVA */

                    R1100_00_INSERT_ERROSPROPVA_SECTION();

                    /*" -4967- MOVE 'SIM' TO WS-TEM-ERRO-1855 */
                    _.Move("SIM", WORK_AREA.WS_TEM_ERRO_1855);

                    /*" -4968- PERFORM R3700-00-INSERT-RELATORIOS */

                    R3700_00_INSERT_RELATORIOS_SECTION();

                    /*" -4969- END-IF */
                }


                /*" -4970- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2248_99_SAIDA*/

        [StopWatch]
        /*" R2247-CALCULO-IDADE-SECTION */
        private void R2247_CALCULO_IDADE_SECTION()
        {
            /*" -4976- MOVE 'R2247-CALCULO-IDADE          ' TO PARAGRAFO. */
            _.Move("R2247-CALCULO-IDADE          ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4982- PERFORM R2247_CALCULO_IDADE_DB_SELECT_1 */

            R2247_CALCULO_IDADE_DB_SELECT_1();

            /*" -4985- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4986- DISPLAY '-------------------------------------------' */
                _.Display($"-------------------------------------------");

                /*" -4988- DISPLAY 'VP0601B - ERRO PEGAR IDADE NA SEGUROS.PESSOA_FISICA' */
                _.Display($"VP0601B - ERRO PEGAR IDADE NA SEGUROS.PESSOA_FISICA");

                /*" -4989- DISPLAY 'SQLCODE = ' SQLCODE */
                _.Display($"SQLCODE = {DB.SQLCODE}");

                /*" -4990- DISPLAY 'COD_PESSOA = ' PROPOFID-COD-PESSOA */
                _.Display($"COD_PESSOA = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA}");

                /*" -4991- DISPLAY '-------------------------------------------' */
                _.Display($"-------------------------------------------");

                /*" -4993- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4997- PERFORM R2247_CALCULO_IDADE_DB_SELECT_2 */

            R2247_CALCULO_IDADE_DB_SELECT_2();

            /*" -5005- IF WS-DIAS-ANO > 25550 */

            if (WS_DIAS_ANO > 25550)
            {

                /*" -5006- MOVE 1867 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1867, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -5009- PERFORM R1100-00-INSERT-ERROSPROPVA */

                R1100_00_INSERT_ERROSPROPVA_SECTION();

                /*" -5011- END-IF. */
            }


            /*" -5012- IF WS-DIAS-ANO < 6570 */

            if (WS_DIAS_ANO < 6570)
            {

                /*" -5013- MOVE 1005 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1005, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -5016- PERFORM R1100-00-INSERT-ERROSPROPVA */

                R1100_00_INSERT_ERROSPROPVA_SECTION();

                /*" -5016- END-IF. */
            }


        }

        [StopWatch]
        /*" R2247-CALCULO-IDADE-DB-SELECT-1 */
        public void R2247_CALCULO_IDADE_DB_SELECT_1()
        {
            /*" -4982- EXEC SQL SELECT DATA_NASCIMENTO INTO :WS-DATA-NASCIMENTO FROM SEGUROS.PESSOA_FISICA WHERE COD_PESSOA = :DCLPROPOSTA-FIDELIZ.PROPOFID-COD-PESSOA END-EXEC. */

            var r2247_CALCULO_IDADE_DB_SELECT_1_Query1 = new R2247_CALCULO_IDADE_DB_SELECT_1_Query1()
            {
                PROPOFID_COD_PESSOA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.ToString(),
            };

            var executed_1 = R2247_CALCULO_IDADE_DB_SELECT_1_Query1.Execute(r2247_CALCULO_IDADE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_DATA_NASCIMENTO, WS_DATA_NASCIMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2247_99_SAIDA*/

        [StopWatch]
        /*" R2247-CALCULO-IDADE-DB-SELECT-2 */
        public void R2247_CALCULO_IDADE_DB_SELECT_2()
        {
            /*" -4997- EXEC SQL SELECT DAYS(CURRENT DATE) - DAYS(:WS-DATA-NASCIMENTO) INTO :WS-DIAS-ANO FROM SYSIBM.SYSDUMMY1 END-EXEC. */

            var r2247_CALCULO_IDADE_DB_SELECT_2_Query1 = new R2247_CALCULO_IDADE_DB_SELECT_2_Query1()
            {
                WS_DATA_NASCIMENTO = WS_DATA_NASCIMENTO.ToString(),
            };

            var executed_1 = R2247_CALCULO_IDADE_DB_SELECT_2_Query1.Execute(r2247_CALCULO_IDADE_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_DIAS_ANO, WS_DIAS_ANO);
            }


        }

        [StopWatch]
        /*" R2249-CALCULO-IS-7725-SECTION */
        private void R2249_CALCULO_IS_7725_SECTION()
        {
            /*" -5023- MOVE 'R2249-CALCULO-IS-7725  ' TO PARAGRAFO. */
            _.Move("R2249-CALCULO-IS-7725  ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5025- PERFORM R3101-00-PEGAR-TAXA */

            R3101_00_PEGAR_TAXA_SECTION();

            /*" -5026- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -5027- MOVE 604 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(604, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -5028- PERFORM R1100-00-INSERT-ERROSPROPVA */

                R1100_00_INSERT_ERROSPROPVA_SECTION();

                /*" -5030- END-IF */
            }


            /*" -5031- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -5033- COMPUTE WS-VALOR-IS-7725 = (RCAPS-VAL-RCAP * 100) / WS-TAXAVG */
                WS_VALOR_IS_7725.Value = (RCAPS.DCLRCAPS.RCAPS_VAL_RCAP * 100) / WS_TAXAVG;

                /*" -5036- END-IF */
            }


            /*" -5037- IF WS-VALOR-IS-7725 > 3000000,00 */

            if (WS_VALOR_IS_7725 > 3000000.00)
            {

                /*" -5038- MOVE 1855 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                _.Move(1855, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                /*" -5039- PERFORM R1100-00-INSERT-ERROSPROPVA */

                R1100_00_INSERT_ERROSPROPVA_SECTION();

                /*" -5040- MOVE 'SIM' TO WS-TEM-ERRO-1855 */
                _.Move("SIM", WORK_AREA.WS_TEM_ERRO_1855);

                /*" -5041- PERFORM R3700-00-INSERT-RELATORIOS */

                R3700_00_INSERT_RELATORIOS_SECTION();

                /*" -5041- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2249_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-TRATA-CLIENTES-SECTION */
        private void R2300_00_TRATA_CLIENTES_SECTION()
        {
            /*" -5050- MOVE '2300-00-TRATA-CLIENTES       ' TO PARAGRAFO. */
            _.Move("2300-00-TRATA-CLIENTES       ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5052- MOVE 1 TO W-TRATA-CLIENTE. */
            _.Move(1, WORK_AREA.W_TRATA_CLIENTE);

            /*" -5054- MOVE 0 TO WS-JA-E-CLIENTE. */
            _.Move(0, WORK_AREA.WS_JA_E_CLIENTE);

            /*" -5056- MOVE '2300-00-TRATA-CLIENTE        ' TO PARAGRAFO. */
            _.Move("2300-00-TRATA-CLIENTE        ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5057- MOVE 'DECLARE CURSOR CLIENTES      ' TO COMANDO. */
            _.Move("DECLARE CURSOR CLIENTES      ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5064- PERFORM R2300_00_TRATA_CLIENTES_DB_DECLARE_1 */

            R2300_00_TRATA_CLIENTES_DB_DECLARE_1();

            /*" -5067- MOVE 33 TO SII */
            _.Move(33, WS_HORAS.SII);

            /*" -5068- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -5068- PERFORM R2300_00_TRATA_CLIENTES_DB_OPEN_1 */

            R2300_00_TRATA_CLIENTES_DB_OPEN_1();

            /*" -5071- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -5072- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5073- DISPLAY 'VP0601B - PROBLEMAS NO DECLARE CLIENTES' */
                _.Display($"VP0601B - PROBLEMAS NO DECLARE CLIENTES");

                /*" -5074- DISPLAY 'CGCCPF          = ' CPF OF DCLPESSOA-FISICA */
                _.Display($"CGCCPF          = {PESFIS.DCLPESSOA_FISICA.CPF}");

                /*" -5076- DISPLAY 'DATA_NASCIMENTO = ' DATA-NASCIMENTO OF DCLPESSOA-FISICA */
                _.Display($"DATA_NASCIMENTO = {PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO}");

                /*" -5077- DISPLAY '---------------------------------------' */
                _.Display($"---------------------------------------");

                /*" -5078- DISPLAY '          NUM PROPOSTA..............   ' */
                _.Display($"          NUM PROPOSTA..............   ");

                /*" -5079- DISPLAY '          NUM PROPOSTA..............   ' */
                _.Display($"          NUM PROPOSTA..............   ");

                /*" -5080- DISPLAY '          NUM PROPOSTA..............   ' */
                _.Display($"          NUM PROPOSTA..............   ");

                /*" -5082- DISPLAY '          NUM PROPOSTA..............   ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          NUM PROPOSTA..............   {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -5084- DISPLAY '          COD CLIENTE...............   ' COD-CLIENTE OF DCLCLIENTES */
                _.Display($"          COD CLIENTE...............   {CLIENTE.DCLCLIENTES.COD_CLIENTE}");

                /*" -5086- DISPLAY '          SQLCODE...................   ' SQLCODE */
                _.Display($"          SQLCODE...................   {DB.SQLCODE}");

                /*" -5089- MOVE 2 TO W-TRATA-CLIENTE. */
                _.Move(2, WORK_AREA.W_TRATA_CLIENTE);
            }


            /*" -5090- MOVE 'FETCH CLIENTES               ' TO COMANDO. */
            _.Move("FETCH CLIENTES               ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5093- PERFORM R2300_00_TRATA_CLIENTES_DB_FETCH_1 */

            R2300_00_TRATA_CLIENTES_DB_FETCH_1();

            /*" -5096- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5097- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5097- PERFORM R2300_00_TRATA_CLIENTES_DB_CLOSE_1 */

                    R2300_00_TRATA_CLIENTES_DB_CLOSE_1();

                    /*" -5100- PERFORM R2310-00-INSERT-CLIENTES */

                    R2310_00_INSERT_CLIENTES_SECTION();

                    /*" -5101- IF VIND-DATA-EXPEDICAO EQUAL ZEROS */

                    if (VIND_DATA_EXPEDICAO == 00)
                    {

                        /*" -5102- PERFORM R2315-00-INSERT-GE-DOC */

                        R2315_00_INSERT_GE_DOC_SECTION();

                        /*" -5104- END-IF */
                    }


                    /*" -5105- MOVE 'I' TO WWORK-TIPO-MOVIMENTO */
                    _.Move("I", W_GECLIMOV.WWORK_TIPO_MOVIMENTO);

                    /*" -5106- GO TO R2300-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/ //GOTO
                    return;

                    /*" -5107- ELSE */
                }
                else
                {


                    /*" -5108- DISPLAY 'VP0601B - PROBLEMAS NO FETCH   CLIENTES' */
                    _.Display($"VP0601B - PROBLEMAS NO FETCH   CLIENTES");

                    /*" -5110- DISPLAY '          NUM PROPOSTA..............   ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          NUM PROPOSTA..............   {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -5112- DISPLAY '          COD CLIENTE...............   ' COD-CLIENTE OF DCLCLIENTES */
                    _.Display($"          COD CLIENTE...............   {CLIENTE.DCLCLIENTES.COD_CLIENTE}");

                    /*" -5114- DISPLAY '          SQLCODE...................   ' SQLCODE */
                    _.Display($"          SQLCODE...................   {DB.SQLCODE}");

                    /*" -5117- MOVE 2 TO W-TRATA-CLIENTE. */
                    _.Move(2, WORK_AREA.W_TRATA_CLIENTE);
                }

            }


            /*" -5117- PERFORM R2300_00_TRATA_CLIENTES_DB_CLOSE_2 */

            R2300_00_TRATA_CLIENTES_DB_CLOSE_2();

            /*" -5119- MOVE 1 TO WS-JA-E-CLIENTE. */
            _.Move(1, WORK_AREA.WS_JA_E_CLIENTE);

        }

        [StopWatch]
        /*" R2300-00-TRATA-CLIENTES-DB-OPEN-1 */
        public void R2300_00_TRATA_CLIENTES_DB_OPEN_1()
        {
            /*" -5068- EXEC SQL OPEN CCLIENTES END-EXEC. */

            CCLIENTES.Open();

        }

        [StopWatch]
        /*" R3110-00-DECLARE-VGPLARAMCOB-DB-DECLARE-1 */
        public void R3110_00_DECLARE_VGPLARAMCOB_DB_DECLARE_1()
        {
            /*" -6397- EXEC SQL DECLARE VGPLARAMC CURSOR FOR SELECT NUM_RAMO, NUM_COBERTURA, QTD_COBERTURA, VLR_IMP_SEGURADA, VLR_CUSTO, VLR_PREMIO FROM SEGUROS.VG_PLANO_RAMO_COB WHERE NUM_APOLICE = :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE AND CODSUBES = :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO AND OPCAO_COBER = :DCLPROPOSTA-FIDELIZ.PROPOFID-OPCAO-COBER AND DTINIVIG <= :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO AND DTTERVIG >= :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO AND IDADE_INICIAL <= :WHOST-IDADE AND IDADE_FINAL >= :WHOST-IDADE AND PERIPGTO = :DCLPRODUTOS-VG.PRODUVG-PERI-PAGAMENTO ORDER BY NUM_RAMO, NUM_COBERTURA END-EXEC. */
            VGPLARAMC = new VP0601B_VGPLARAMC(true);
            string GetQuery_VGPLARAMC()
            {
                var query = @$"SELECT NUM_RAMO
							, 
							NUM_COBERTURA
							, 
							QTD_COBERTURA
							, 
							VLR_IMP_SEGURADA
							, 
							VLR_CUSTO
							, 
							VLR_PREMIO 
							FROM SEGUROS.VG_PLANO_RAMO_COB 
							WHERE NUM_APOLICE = 
							'{PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE}' 
							AND CODSUBES = 
							'{PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO}' 
							AND OPCAO_COBER = 
							'{PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER}' 
							AND DTINIVIG <= 
							'{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND DTTERVIG >= 
							'{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND IDADE_INICIAL <= '{WHOST_IDADE}' 
							AND IDADE_FINAL >= '{WHOST_IDADE}' 
							AND PERIPGTO = 
							'{PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO}' 
							ORDER BY NUM_RAMO
							, 
							NUM_COBERTURA";

                return query;
            }
            VGPLARAMC.GetQueryEvent += GetQuery_VGPLARAMC;

        }

        [StopWatch]
        /*" R2300-00-TRATA-CLIENTES-DB-FETCH-1 */
        public void R2300_00_TRATA_CLIENTES_DB_FETCH_1()
        {
            /*" -5093- EXEC SQL FETCH CCLIENTES INTO :DCLCLIENTES.COD-CLIENTE END-EXEC. */

            if (CCLIENTES.Fetch())
            {
                _.Move(CCLIENTES.DCLCLIENTES_COD_CLIENTE, CLIENTE.DCLCLIENTES.COD_CLIENTE);
            }

        }

        [StopWatch]
        /*" R2300-00-TRATA-CLIENTES-DB-CLOSE-1 */
        public void R2300_00_TRATA_CLIENTES_DB_CLOSE_1()
        {
            /*" -5097- EXEC SQL CLOSE CCLIENTES END-EXEC */

            CCLIENTES.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-TRATA-CLIENTES-DB-CLOSE-2 */
        public void R2300_00_TRATA_CLIENTES_DB_CLOSE_2()
        {
            /*" -5117- EXEC SQL CLOSE CCLIENTES END-EXEC. */

            CCLIENTES.Close();

        }

        [StopWatch]
        /*" R2310-00-INSERT-CLIENTES-SECTION */
        private void R2310_00_INSERT_CLIENTES_SECTION()
        {
            /*" -5130- MOVE '2310-00-INSERT-CLIENTES      ' TO PARAGRAFO. */
            _.Move("2310-00-INSERT-CLIENTES      ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5131- ADD 1 TO NUM-CLIENTE OF DCLNUMERO-OUTROS. */
            NUMOUTRO.DCLNUMERO_OUTROS.NUM_CLIENTE.Value = NUMOUTRO.DCLNUMERO_OUTROS.NUM_CLIENTE + 1;

            /*" -5134- MOVE NUM-CLIENTE OF DCLNUMERO-OUTROS TO COD-CLIENTE OF DCLCLIENTES. */
            _.Move(NUMOUTRO.DCLNUMERO_OUTROS.NUM_CLIENTE, CLIENTE.DCLCLIENTES.COD_CLIENTE);

            /*" -5136- MOVE '2310-00-INSERT-CLIENTES      ' TO PARAGRAFO. */
            _.Move("2310-00-INSERT-CLIENTES      ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5137- MOVE 34 TO SII */
            _.Move(34, WS_HORAS.SII);

            /*" -5139- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -5141- IF PRODUVG-COD-PRODUTO = 7725 OR JVPRD7725 OR 7733 OR JVPRD7733 */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.In("7725", JVBKINCL.JV_PRODUTOS.JVPRD7725.ToString(), "7733", JVBKINCL.JV_PRODUTOS.JVPRD7733.ToString()))
            {

                /*" -5143- MOVE WS-DT-NASCIMENTO-18 TO DATA-NASCIMENTO OF DCLCLIENTES */
                _.Move(WS_DT_NASCIMENTO_18, CLIENTE.DCLCLIENTES.DATA_NASCIMENTO);

                /*" -5180- PERFORM R2310_00_INSERT_CLIENTES_DB_INSERT_1 */

                R2310_00_INSERT_CLIENTES_DB_INSERT_1();

                /*" -5182- ELSE */
            }
            else
            {


                /*" -5220- PERFORM R2310_00_INSERT_CLIENTES_DB_INSERT_2 */

                R2310_00_INSERT_CLIENTES_DB_INSERT_2();

                /*" -5223- END-IF */
            }


            /*" -5224- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -5225- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5226- DISPLAY 'VP0601B - PROBLEMAS NO INSERT DA V0CLIENTES' */
                _.Display($"VP0601B - PROBLEMAS NO INSERT DA V0CLIENTES");

                /*" -5227- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_SQLCODE);

                /*" -5228- DISPLAY 'SQLCODE      = ' WS-SQLCODE */
                _.Display($"SQLCODE      = {WS_SQLCODE}");

                /*" -5230- DISPLAY 'NUM PROPOSTA = ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"NUM PROPOSTA = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -5231- DISPLAY 'COD_CLIENTE      = ' COD-CLIENTE OF DCLCLIENTES */
                _.Display($"COD_CLIENTE      = {CLIENTE.DCLCLIENTES.COD_CLIENTE}");

                /*" -5233- DISPLAY 'NOME_RAZAO        = ' PESSOA-NOME-PESSOA OF DCLPESSOA */
                _.Display($"NOME_RAZAO        = {PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA}");

                /*" -5234- DISPLAY 'TIPO_PESSOA       = F' */
                _.Display($"TIPO_PESSOA       = F");

                /*" -5235- DISPLAY 'CGCCPF            = ' CPF OF DCLPESSOA-FISICA */
                _.Display($"CGCCPF            = {PESFIS.DCLPESSOA_FISICA.CPF}");

                /*" -5236- DISPLAY 'SIT_REGISTRO      = 0' */
                _.Display($"SIT_REGISTRO      = 0");

                /*" -5238- DISPLAY 'DATA_NASCIMENTO   = ' DATA-NASCIMENTO OF DCLPESSOA-FISICA */
                _.Display($"DATA_NASCIMENTO   = {PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO}");

                /*" -5239- DISPLAY 'COD_EMPRESA       = 0' */
                _.Display($"COD_EMPRESA       = 0");

                /*" -5240- DISPLAY 'COD_PORTE_EMP     = NULL' */
                _.Display($"COD_PORTE_EMP     = NULL");

                /*" -5241- DISPLAY 'COD_NATUREZA_ATIV = NULL' */
                _.Display($"COD_NATUREZA_ATIV = NULL");

                /*" -5242- DISPLAY 'COD_RAMO_ATIVIDADE= NULL' */
                _.Display($"COD_RAMO_ATIVIDADE= NULL");

                /*" -5243- DISPLAY 'COD_ATIVIDADE     = NULL' */
                _.Display($"COD_ATIVIDADE     = NULL");

                /*" -5244- DISPLAY 'IDE_SEXO          = ' SEXO OF DCLPESSOA-FISICA */
                _.Display($"IDE_SEXO          = {PESFIS.DCLPESSOA_FISICA.SEXO}");

                /*" -5246- DISPLAY 'ESTADO_CIVIL      = ' ESTADO-CIVIL OF DCLPESSOA-FISICA */
                _.Display($"ESTADO_CIVIL      = {PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL}");

                /*" -5247- DISPLAY 'COD_GRD_GRUPO_CBO = NULL' */
                _.Display($"COD_GRD_GRUPO_CBO = NULL");

                /*" -5248- DISPLAY 'COD_SUBGRUPO_CBO  = NULL' */
                _.Display($"COD_SUBGRUPO_CBO  = NULL");

                /*" -5249- DISPLAY 'COD_GRUPO_BASE_CBO= NULL' */
                _.Display($"COD_GRUPO_BASE_CBO= NULL");

                /*" -5250- DISPLAY 'COD_SUBGR_BASE_CBO= NULL' */
                _.Display($"COD_SUBGR_BASE_CBO= NULL");

                /*" -5251- DISPLAY '-------------------------------------------' */
                _.Display($"-------------------------------------------");

                /*" -5251- MOVE 2 TO W-TRATA-CLIENTE. */
                _.Move(2, WORK_AREA.W_TRATA_CLIENTE);
            }


        }

        [StopWatch]
        /*" R2310-00-INSERT-CLIENTES-DB-INSERT-1 */
        public void R2310_00_INSERT_CLIENTES_DB_INSERT_1()
        {
            /*" -5180- EXEC SQL INSERT INTO SEGUROS.CLIENTES (COD_CLIENTE, NOME_RAZAO, TIPO_PESSOA, CGCCPF, SIT_REGISTRO, DATA_NASCIMENTO, COD_EMPRESA, COD_PORTE_EMP, COD_NATUREZA_ATIV, COD_RAMO_ATIVIDADE, COD_ATIVIDADE, IDE_SEXO, ESTADO_CIVIL, COD_GRD_GRUPO_CBO, COD_SUBGRUPO_CBO, COD_GRUPO_BASE_CBO, COD_SUBGR_BASE_CBO) VALUES (:DCLCLIENTES.COD-CLIENTE, :PESSOJUR-NOME-FANTASIA, 'J' , :PESSOJUR-CGC, '0' , :DCLCLIENTES.DATA-NASCIMENTO, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL) END-EXEC */

            var r2310_00_INSERT_CLIENTES_DB_INSERT_1_Insert1 = new R2310_00_INSERT_CLIENTES_DB_INSERT_1_Insert1()
            {
                COD_CLIENTE = CLIENTE.DCLCLIENTES.COD_CLIENTE.ToString(),
                PESSOJUR_NOME_FANTASIA = PESSOJUR.DCLPESSOA_JURIDICA.PESSOJUR_NOME_FANTASIA.ToString(),
                PESSOJUR_CGC = PESSOJUR.DCLPESSOA_JURIDICA.PESSOJUR_CGC.ToString(),
                DATA_NASCIMENTO = CLIENTE.DCLCLIENTES.DATA_NASCIMENTO.ToString(),
            };

            R2310_00_INSERT_CLIENTES_DB_INSERT_1_Insert1.Execute(r2310_00_INSERT_CLIENTES_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2310_99_SAIDA*/

        [StopWatch]
        /*" R2310-00-INSERT-CLIENTES-DB-INSERT-2 */
        public void R2310_00_INSERT_CLIENTES_DB_INSERT_2()
        {
            /*" -5220- EXEC SQL INSERT INTO SEGUROS.CLIENTES (COD_CLIENTE, NOME_RAZAO, TIPO_PESSOA, CGCCPF, SIT_REGISTRO, DATA_NASCIMENTO, COD_EMPRESA, COD_PORTE_EMP, COD_NATUREZA_ATIV, COD_RAMO_ATIVIDADE, COD_ATIVIDADE, IDE_SEXO, ESTADO_CIVIL, COD_GRD_GRUPO_CBO, COD_SUBGRUPO_CBO, COD_GRUPO_BASE_CBO, COD_SUBGR_BASE_CBO) VALUES (:DCLCLIENTES.COD-CLIENTE, :DCLPESSOA.PESSOA-NOME-PESSOA, 'F' , :DCLPESSOA-FISICA.CPF, '0' , :DCLPESSOA-FISICA.DATA-NASCIMENTO :VIND-DATA-NASCIMENTO, 0, NULL, NULL, NULL, NULL, :DCLPESSOA-FISICA.SEXO, :DCLPESSOA-FISICA.ESTADO-CIVIL, NULL, NULL, NULL, NULL) END-EXEC */

            var r2310_00_INSERT_CLIENTES_DB_INSERT_2_Insert1 = new R2310_00_INSERT_CLIENTES_DB_INSERT_2_Insert1()
            {
                COD_CLIENTE = CLIENTE.DCLCLIENTES.COD_CLIENTE.ToString(),
                PESSOA_NOME_PESSOA = PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA.ToString(),
                CPF = PESFIS.DCLPESSOA_FISICA.CPF.ToString(),
                DATA_NASCIMENTO = PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO.ToString(),
                VIND_DATA_NASCIMENTO = VIND_DATA_NASCIMENTO.ToString(),
                SEXO = PESFIS.DCLPESSOA_FISICA.SEXO.ToString(),
                ESTADO_CIVIL = PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL.ToString(),
            };

            R2310_00_INSERT_CLIENTES_DB_INSERT_2_Insert1.Execute(r2310_00_INSERT_CLIENTES_DB_INSERT_2_Insert1);

        }

        [StopWatch]
        /*" R2315-00-INSERT-GE-DOC-SECTION */
        private void R2315_00_INSERT_GE_DOC_SECTION()
        {
            /*" -5263- MOVE '2315-00-INSERT-GE-DOC        ' TO PARAGRAFO. */
            _.Move("2315-00-INSERT-GE-DOC        ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5266- MOVE COD-CLIENTE OF DCLCLIENTES TO GEDOCCLI-COD-CLIENTE. */
            _.Move(CLIENTE.DCLCLIENTES.COD_CLIENTE, GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_CLIENTE);

            /*" -5269- MOVE NUM-IDENTIDADE OF DCLPESSOA-FISICA TO GEDOCCLI-COD-IDENTIFICACAO */
            _.Move(PESFIS.DCLPESSOA_FISICA.NUM_IDENTIDADE, GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_IDENTIFICACAO);

            /*" -5272- MOVE ORGAO-EXPEDIDOR OF DCLPESSOA-FISICA TO W-NOM-ORGAO-EXP */
            _.Move(PESFIS.DCLPESSOA_FISICA.ORGAO_EXPEDIDOR, WORK_AREA.W_NOM_ORGAO_EXP);

            /*" -5275- MOVE W-ORGAO-EXPEDIDOR TO GEDOCCLI-NOM-ORGAO-EXP */
            _.Move(WORK_AREA.FILLER_13.W_ORGAO_EXPEDIDOR, GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_NOM_ORGAO_EXP);

            /*" -5278- MOVE DATA-EXPEDICAO OF DCLPESSOA-FISICA TO GEDOCCLI-DTH-EXPEDICAO. */
            _.Move(PESFIS.DCLPESSOA_FISICA.DATA_EXPEDICAO, GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_DTH_EXPEDICAO);

            /*" -5279- IF VIND-UF-EXPEDIDORA NOT LESS ZEROS */

            if (VIND_UF_EXPEDIDORA >= 00)
            {

                /*" -5282- MOVE UF-EXPEDIDORA OF DCLPESSOA-FISICA TO GEDOCCLI-COD-UF. */
                _.Move(PESFIS.DCLPESSOA_FISICA.UF_EXPEDIDORA, GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_UF);
            }


            /*" -5285- IF PRODUVG-COD-PRODUTO = 7725 OR JVPRD7725 OR 7732 OR JVPRD7732 OR 7733 OR JVPRD7733 */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.In("7725", JVBKINCL.JV_PRODUTOS.JVPRD7725.ToString(), "7732", JVBKINCL.JV_PRODUTOS.JVPRD7732.ToString(), "7733", JVBKINCL.JV_PRODUTOS.JVPRD7733.ToString()))
            {

                /*" -5298- PERFORM R2315_00_INSERT_GE_DOC_DB_INSERT_1 */

                R2315_00_INSERT_GE_DOC_DB_INSERT_1();

                /*" -5300- ELSE */
            }
            else
            {


                /*" -5313- PERFORM R2315_00_INSERT_GE_DOC_DB_INSERT_2 */

                R2315_00_INSERT_GE_DOC_DB_INSERT_2();

                /*" -5316- END-IF */
            }


            /*" -5317- MOVE 35 TO SII */
            _.Move(35, WS_HORAS.SII);

            /*" -5318- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -5320- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -5322- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL -803 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
            {

                /*" -5323- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_SQLCODE);

                /*" -5324- DISPLAY 'VP0601B - PROBLEMAS INSERT GE-DOC-CLIENTE ' */
                _.Display($"VP0601B - PROBLEMAS INSERT GE-DOC-CLIENTE ");

                /*" -5326- DISPLAY '          NUM PROPOSTA....................... ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          NUM PROPOSTA....................... {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -5328- DISPLAY '          COD CLIENTE........................ ' COD-CLIENTE OF DCLCLIENTES */
                _.Display($"          COD CLIENTE........................ {CLIENTE.DCLCLIENTES.COD_CLIENTE}");

                /*" -5330- DISPLAY '          SQLCODE............................ ' WS-SQLCODE */
                _.Display($"          SQLCODE............................ {WS_SQLCODE}");

                /*" -5330- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2315-00-INSERT-GE-DOC-DB-INSERT-1 */
        public void R2315_00_INSERT_GE_DOC_DB_INSERT_1()
        {
            /*" -5298- EXEC SQL INSERT INTO SEGUROS.GE_DOC_CLIENTE (COD_CLIENTE , COD_IDENTIFICACAO , NOM_ORGAO_EXP , DTH_EXPEDICAO , COD_UF) VALUES (:GEDOCCLI-COD-CLIENTE , ' ' , ' ' , '9999-12-31' , ' ' ) END-EXEC */

            var r2315_00_INSERT_GE_DOC_DB_INSERT_1_Insert1 = new R2315_00_INSERT_GE_DOC_DB_INSERT_1_Insert1()
            {
                GEDOCCLI_COD_CLIENTE = GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_CLIENTE.ToString(),
            };

            R2315_00_INSERT_GE_DOC_DB_INSERT_1_Insert1.Execute(r2315_00_INSERT_GE_DOC_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2315_99_SAIDA*/

        [StopWatch]
        /*" R2315-00-INSERT-GE-DOC-DB-INSERT-2 */
        public void R2315_00_INSERT_GE_DOC_DB_INSERT_2()
        {
            /*" -5313- EXEC SQL INSERT INTO SEGUROS.GE_DOC_CLIENTE (COD_CLIENTE , COD_IDENTIFICACAO , NOM_ORGAO_EXP , DTH_EXPEDICAO , COD_UF) VALUES (:GEDOCCLI-COD-CLIENTE , :GEDOCCLI-COD-IDENTIFICACAO, :GEDOCCLI-NOM-ORGAO-EXP , :GEDOCCLI-DTH-EXPEDICAO , :GEDOCCLI-COD-UF:VIND-UF-EXPEDIDORA) END-EXEC */

            var r2315_00_INSERT_GE_DOC_DB_INSERT_2_Insert1 = new R2315_00_INSERT_GE_DOC_DB_INSERT_2_Insert1()
            {
                GEDOCCLI_COD_CLIENTE = GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_CLIENTE.ToString(),
                GEDOCCLI_COD_IDENTIFICACAO = GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_IDENTIFICACAO.ToString(),
                GEDOCCLI_NOM_ORGAO_EXP = GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_NOM_ORGAO_EXP.ToString(),
                GEDOCCLI_DTH_EXPEDICAO = GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_DTH_EXPEDICAO.ToString(),
                GEDOCCLI_COD_UF = GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_UF.ToString(),
                VIND_UF_EXPEDIDORA = VIND_UF_EXPEDIDORA.ToString(),
            };

            R2315_00_INSERT_GE_DOC_DB_INSERT_2_Insert1.Execute(r2315_00_INSERT_GE_DOC_DB_INSERT_2_Insert1);

        }

        [StopWatch]
        /*" R2350-00-TRATA-ERRO-1864-SECTION */
        private void R2350_00_TRATA_ERRO_1864_SECTION()
        {
            /*" -5339- MOVE '2350-00-TRATA-ERRO1864       ' TO PARAGRAFO. */
            _.Move("2350-00-TRATA-ERRO1864       ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5348- PERFORM R2350_00_TRATA_ERRO_1864_DB_SELECT_1 */

            R2350_00_TRATA_ERRO_1864_DB_SELECT_1();

            /*" -5351- IF WS-COUNT GREATER ZEROS */

            if (WS_COUNT > 00)
            {

                /*" -5352- GO TO R2350-ERRO */

                R2350_ERRO(); //GOTO
                return;

                /*" -5354- END-IF. */
            }


            /*" -5371- PERFORM R2350_00_TRATA_ERRO_1864_DB_SELECT_2 */

            R2350_00_TRATA_ERRO_1864_DB_SELECT_2();

            /*" -5374- IF WS-COUNT GREATER ZEROS */

            if (WS_COUNT > 00)
            {

                /*" -5375- GO TO R2350-ERRO */

                R2350_ERRO(); //GOTO
                return;

                /*" -5377- END-IF. */
            }


            /*" -5388- PERFORM R2350_00_TRATA_ERRO_1864_DB_SELECT_3 */

            R2350_00_TRATA_ERRO_1864_DB_SELECT_3();

            /*" -5391- IF WS-COUNT GREATER ZEROS */

            if (WS_COUNT > 00)
            {

                /*" -5392- GO TO R2350-ERRO */

                R2350_ERRO(); //GOTO
                return;

                /*" -5394- END-IF. */
            }


            /*" -5403- PERFORM R2350_00_TRATA_ERRO_1864_DB_SELECT_4 */

            R2350_00_TRATA_ERRO_1864_DB_SELECT_4();

            /*" -5406- IF WS-COUNT GREATER ZEROS */

            if (WS_COUNT > 00)
            {

                /*" -5407- GO TO R2350-ERRO */

                R2350_ERRO(); //GOTO
                return;

                /*" -5409- END-IF. */
            }


            /*" -5421- PERFORM R2350_00_TRATA_ERRO_1864_DB_SELECT_5 */

            R2350_00_TRATA_ERRO_1864_DB_SELECT_5();

            /*" -5424- IF WS-COUNT GREATER ZEROS */

            if (WS_COUNT > 00)
            {

                /*" -5425- GO TO R2350-ERRO */

                R2350_ERRO(); //GOTO
                return;

                /*" -5426- ELSE */
            }
            else
            {


                /*" -5427- GO TO R2350-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2350_99_SAIDA*/ //GOTO
                return;

                /*" -5427- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R2350_ERRO */

            R2350_ERRO();

        }

        [StopWatch]
        /*" R2350-00-TRATA-ERRO-1864-DB-SELECT-1 */
        public void R2350_00_TRATA_ERRO_1864_DB_SELECT_1()
        {
            /*" -5348- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :WS-COUNT FROM SEGUROS.PROPOSTAS_VA A, SEGUROS.SINISTRO_MESTRE B, SEGUROS.CLIENTES C WHERE A.NUM_CERTIFICADO = B.NUM_CERTIFICADO AND A.COD_CLIENTE = C.COD_CLIENTE AND C.CGCCPF = :DCLPESSOA-FISICA.CPF END-EXEC. */

            var r2350_00_TRATA_ERRO_1864_DB_SELECT_1_Query1 = new R2350_00_TRATA_ERRO_1864_DB_SELECT_1_Query1()
            {
                CPF = PESFIS.DCLPESSOA_FISICA.CPF.ToString(),
            };

            var executed_1 = R2350_00_TRATA_ERRO_1864_DB_SELECT_1_Query1.Execute(r2350_00_TRATA_ERRO_1864_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_COUNT, WS_COUNT);
            }


        }

        [StopWatch]
        /*" R2350-ERRO */
        private void R2350_ERRO(bool isPerform = false)
        {
            /*" -5432- MOVE 1864 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
            _.Move(1864, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

            /*" -5432- PERFORM R1100-00-INSERT-ERROSPROPVA. */

            R1100_00_INSERT_ERROSPROPVA_SECTION();

        }

        [StopWatch]
        /*" R2350-00-TRATA-ERRO-1864-DB-SELECT-2 */
        public void R2350_00_TRATA_ERRO_1864_DB_SELECT_2()
        {
            /*" -5371- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :WS-COUNT FROM SEGUROS.SEGURADOSVGAP_HIST A, SEGUROS.SEGURADOS_VGAP B, SEGUROS.CLIENTES C, SEGUROS.PROPOSTAS_VA D WHERE A.NUM_APOLICE = B.NUM_APOLICE AND A.COD_SUBGRUPO = B.COD_SUBGRUPO AND A.NUM_ITEM = B.NUM_ITEM AND D.NUM_APOLICE = B.NUM_APOLICE AND D.COD_SUBGRUPO = B.COD_SUBGRUPO AND D.NUM_CERTIFICADO = B.NUM_CERTIFICADO AND B.TIPO_SEGURADO = '1' AND B.COD_CLIENTE = C.COD_CLIENTE AND C.CGCCPF = :DCLPESSOA-FISICA.CPF AND A.COD_OPERACAO IN (401,403) END-EXEC. */

            var r2350_00_TRATA_ERRO_1864_DB_SELECT_2_Query1 = new R2350_00_TRATA_ERRO_1864_DB_SELECT_2_Query1()
            {
                CPF = PESFIS.DCLPESSOA_FISICA.CPF.ToString(),
            };

            var executed_1 = R2350_00_TRATA_ERRO_1864_DB_SELECT_2_Query1.Execute(r2350_00_TRATA_ERRO_1864_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_COUNT, WS_COUNT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2350_99_SAIDA*/

        [StopWatch]
        /*" R2350-00-TRATA-ERRO-1864-DB-SELECT-3 */
        public void R2350_00_TRATA_ERRO_1864_DB_SELECT_3()
        {
            /*" -5388- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :WS-COUNT FROM SEGUROS.RELATORIOS A, SEGUROS.PROPOSTAS_VA B, SEGUROS.CLIENTES C WHERE A.NUM_CERTIFICADO = B.NUM_CERTIFICADO AND A.COD_USUARIO = 'VA0458B' AND A.COD_RELATORIO IN ( 'VA0469B' ) AND B.COD_CLIENTE = C.COD_CLIENTE AND C.CGCCPF = :DCLPESSOA-FISICA.CPF END-EXEC. */

            var r2350_00_TRATA_ERRO_1864_DB_SELECT_3_Query1 = new R2350_00_TRATA_ERRO_1864_DB_SELECT_3_Query1()
            {
                CPF = PESFIS.DCLPESSOA_FISICA.CPF.ToString(),
            };

            var executed_1 = R2350_00_TRATA_ERRO_1864_DB_SELECT_3_Query1.Execute(r2350_00_TRATA_ERRO_1864_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_COUNT, WS_COUNT);
            }


        }

        [StopWatch]
        /*" R2400-00-TRATA-ENDERECOS-SECTION */
        private void R2400_00_TRATA_ENDERECOS_SECTION()
        {
            /*" -5443- MOVE '2400-00-TRATA-ENDERECO       ' TO PARAGRAFO. */
            _.Move("2400-00-TRATA-ENDERECO       ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5444- MOVE 36 TO SII */
            _.Move(36, WS_HORAS.SII);

            /*" -5445- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -5446- IF WS-JA-E-CLIENTE EQUAL 1 */

            if (WORK_AREA.WS_JA_E_CLIENTE == 1)
            {

                /*" -5447- MOVE 'SELECT SEGUROS.ENDERECOS     ' TO COMANDO */
                _.Move("SELECT SEGUROS.ENDERECOS     ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -5469- PERFORM R2400_00_TRATA_ENDERECOS_DB_SELECT_1 */

                R2400_00_TRATA_ENDERECOS_DB_SELECT_1();

                /*" -5471- PERFORM R9100-00-TERMINO */

                R9100_00_TERMINO_SECTION();

                /*" -5472- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -5473- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -5474- PERFORM R2420-00-INSERT-ENDERECOS */

                        R2420_00_INSERT_ENDERECOS_SECTION();

                        /*" -5475- MOVE 'I' TO WWORK-TIPO-MOVIMENTO */
                        _.Move("I", W_GECLIMOV.WWORK_TIPO_MOVIMENTO);

                        /*" -5476- ELSE */
                    }
                    else
                    {


                        /*" -5478- IF SQLCODE EQUAL -811 NEXT SENTENCE */

                        if (DB.SQLCODE == -811)
                        {

                            /*" -5479- ELSE */
                        }
                        else
                        {


                            /*" -5480- DISPLAY 'PROBLEMAS ACESSO ENDERECOS     ' */
                            _.Display($"PROBLEMAS ACESSO ENDERECOS     ");

                            /*" -5481- GO TO R9999-00-ROT-ERRO */

                            R9999_00_ROT_ERRO_SECTION(); //GOTO
                            return;

                            /*" -5482- END-IF */
                        }


                        /*" -5483- END-IF */
                    }


                    /*" -5486- ELSE NEXT SENTENCE */
                }
                else
                {


                    /*" -5487- ELSE */
                }

            }
            else
            {


                /*" -5488- PERFORM R2420-00-INSERT-ENDERECOS */

                R2420_00_INSERT_ENDERECOS_SECTION();

                /*" -5488- MOVE 'I' TO WWORK-TIPO-MOVIMENTO. */
                _.Move("I", W_GECLIMOV.WWORK_TIPO_MOVIMENTO);
            }


        }

        [StopWatch]
        /*" R2400-00-TRATA-ENDERECOS-DB-SELECT-1 */
        public void R2400_00_TRATA_ENDERECOS_DB_SELECT_1()
        {
            /*" -5469- EXEC SQL SELECT OCORR_ENDERECO, ENDERECO, BAIRRO, CIDADE, SIGLA_UF, CEP INTO :DCLENDERECOS.ENDERECO-OCORR-ENDERECO, :DCLENDERECOS.ENDERECO-ENDERECO, :DCLENDERECOS.ENDERECO-BAIRRO, :DCLENDERECOS.ENDERECO-CIDADE, :DCLENDERECOS.ENDERECO-SIGLA-UF, :DCLENDERECOS.ENDERECO-CEP FROM SEGUROS.ENDERECOS WHERE COD_CLIENTE = :DCLCLIENTES.COD-CLIENTE AND ENDERECO = :DCLPESSOA-ENDERECO.ENDERECO AND BAIRRO = :DCLPESSOA-ENDERECO.BAIRRO AND CIDADE = :DCLPESSOA-ENDERECO.CIDADE AND SIGLA_UF = :DCLPESSOA-ENDERECO.SIGLA-UF AND CEP = :DCLPESSOA-ENDERECO.CEP END-EXEC */

            var r2400_00_TRATA_ENDERECOS_DB_SELECT_1_Query1 = new R2400_00_TRATA_ENDERECOS_DB_SELECT_1_Query1()
            {
                ENDERECO = PESENDER.DCLPESSOA_ENDERECO.ENDERECO.ToString(),
                SIGLA_UF = PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF.ToString(),
                BAIRRO = PESENDER.DCLPESSOA_ENDERECO.BAIRRO.ToString(),
                CIDADE = PESENDER.DCLPESSOA_ENDERECO.CIDADE.ToString(),
                COD_CLIENTE = CLIENTE.DCLCLIENTES.COD_CLIENTE.ToString(),
                CEP = PESENDER.DCLPESSOA_ENDERECO.CEP.ToString(),
            };

            var executed_1 = R2400_00_TRATA_ENDERECOS_DB_SELECT_1_Query1.Execute(r2400_00_TRATA_ENDERECOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDERECO_OCORR_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO);
                _.Move(executed_1.ENDERECO_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO);
                _.Move(executed_1.ENDERECO_BAIRRO, ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO);
                _.Move(executed_1.ENDERECO_CIDADE, ENDERECO.DCLENDERECOS.ENDERECO_CIDADE);
                _.Move(executed_1.ENDERECO_SIGLA_UF, ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF);
                _.Move(executed_1.ENDERECO_CEP, ENDERECO.DCLENDERECOS.ENDERECO_CEP);
            }


        }

        [StopWatch]
        /*" R2350-00-TRATA-ERRO-1864-DB-SELECT-4 */
        public void R2350_00_TRATA_ERRO_1864_DB_SELECT_4()
        {
            /*" -5403- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :WS-COUNT FROM SEGUROS.PROPOSTAS_VA A, SEGUROS.CLIENTES B WHERE A.ACATAMENTO = 'S' AND A.SIT_REGISTRO = '3' AND A.COD_CLIENTE = B.COD_CLIENTE AND B.CGCCPF = :DCLPESSOA-FISICA.CPF END-EXEC. */

            var r2350_00_TRATA_ERRO_1864_DB_SELECT_4_Query1 = new R2350_00_TRATA_ERRO_1864_DB_SELECT_4_Query1()
            {
                CPF = PESFIS.DCLPESSOA_FISICA.CPF.ToString(),
            };

            var executed_1 = R2350_00_TRATA_ERRO_1864_DB_SELECT_4_Query1.Execute(r2350_00_TRATA_ERRO_1864_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_COUNT, WS_COUNT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R2350-00-TRATA-ERRO-1864-DB-SELECT-5 */
        public void R2350_00_TRATA_ERRO_1864_DB_SELECT_5()
        {
            /*" -5421- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :WS-COUNT FROM SEGUROS.PROPOSTAS_VA A, SEGUROS.ERROS_PROP_VIDAZUL B, SEGUROS.CLIENTES C WHERE A.NUM_CERTIFICADO = B.NUM_CERTIFICADO AND A.SIT_REGISTRO = '2' AND B.COD_ERRO IN (1802,1807,1808,1811,2007,2011, 1005,1006,1862) AND A.COD_CLIENTE = C.COD_CLIENTE AND C.CGCCPF = :DCLPESSOA-FISICA.CPF END-EXEC. */

            var r2350_00_TRATA_ERRO_1864_DB_SELECT_5_Query1 = new R2350_00_TRATA_ERRO_1864_DB_SELECT_5_Query1()
            {
                CPF = PESFIS.DCLPESSOA_FISICA.CPF.ToString(),
            };

            var executed_1 = R2350_00_TRATA_ERRO_1864_DB_SELECT_5_Query1.Execute(r2350_00_TRATA_ERRO_1864_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_COUNT, WS_COUNT);
            }


        }

        [StopWatch]
        /*" R2420-00-INSERT-ENDERECOS-SECTION */
        private void R2420_00_INSERT_ENDERECOS_SECTION()
        {
            /*" -5545- MOVE 'SELECT MAX SEGUROS.ENDERECOS   ' TO COMANDO */
            _.Move("SELECT MAX SEGUROS.ENDERECOS   ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5546- MOVE 37 TO SII */
            _.Move(37, WS_HORAS.SII);

            /*" -5547- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -5552- PERFORM R2420_00_INSERT_ENDERECOS_DB_SELECT_1 */

            R2420_00_INSERT_ENDERECOS_DB_SELECT_1();

            /*" -5555- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -5556- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5557- DISPLAY 'PROBLEMAS NO MAX ENDERECOS              ' */
                _.Display($"PROBLEMAS NO MAX ENDERECOS              ");

                /*" -5559- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5562- ADD 1 TO ENDERECO-OCORR-ENDERECO OF DCLENDERECOS. */
            ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO.Value = ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO + 1;

            /*" -5563- MOVE '2420-00-INSERT-ENDERECOS     ' TO PARAGRAFO. */
            _.Move("2420-00-INSERT-ENDERECOS     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5565- MOVE 'INSERT ENDERECOS             ' TO COMANDO. */
            _.Move("INSERT ENDERECOS             ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5566- MOVE 38 TO SII */
            _.Move(38, WS_HORAS.SII);

            /*" -5567- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -5586- PERFORM R2420_00_INSERT_ENDERECOS_DB_INSERT_1 */

            R2420_00_INSERT_ENDERECOS_DB_INSERT_1();

            /*" -5589- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -5590- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5591- DISPLAY 'PROBLEMAS NO INSERT A ENDERECOS         ' */
                _.Display($"PROBLEMAS NO INSERT A ENDERECOS         ");

                /*" -5593- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5595- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL -803 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
            {

                /*" -5596- DISPLAY 'PROBLEMAS NO INSERT A ENDERECOS         ' */
                _.Display($"PROBLEMAS NO INSERT A ENDERECOS         ");

                /*" -5596- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2420-00-INSERT-ENDERECOS-DB-SELECT-1 */
        public void R2420_00_INSERT_ENDERECOS_DB_SELECT_1()
        {
            /*" -5552- EXEC SQL SELECT VALUE (MAX(OCORR_ENDERECO),0) INTO :DCLENDERECOS.ENDERECO-OCORR-ENDERECO FROM SEGUROS.ENDERECOS WHERE COD_CLIENTE = :DCLCLIENTES.COD-CLIENTE END-EXEC */

            var r2420_00_INSERT_ENDERECOS_DB_SELECT_1_Query1 = new R2420_00_INSERT_ENDERECOS_DB_SELECT_1_Query1()
            {
                COD_CLIENTE = CLIENTE.DCLCLIENTES.COD_CLIENTE.ToString(),
            };

            var executed_1 = R2420_00_INSERT_ENDERECOS_DB_SELECT_1_Query1.Execute(r2420_00_INSERT_ENDERECOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDERECO_OCORR_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO);
            }


        }

        [StopWatch]
        /*" R2420-00-INSERT-ENDERECOS-DB-INSERT-1 */
        public void R2420_00_INSERT_ENDERECOS_DB_INSERT_1()
        {
            /*" -5586- EXEC SQL INSERT INTO SEGUROS.ENDERECOS VALUES (:DCLCLIENTES.COD-CLIENTE, 2, :DCLENDERECOS.ENDERECO-OCORR-ENDERECO, :DCLPESSOA-ENDERECO.ENDERECO, :DCLPESSOA-ENDERECO.BAIRRO, :DCLPESSOA-ENDERECO.CIDADE, :DCLPESSOA-ENDERECO.SIGLA-UF, :DCLPESSOA-ENDERECO.CEP, :WHOST-DDD, :WHOST-FONE, :WHOST-FAX, :WHOST-TELEX, '0' , NULL , NULL) END-EXEC. */

            var r2420_00_INSERT_ENDERECOS_DB_INSERT_1_Insert1 = new R2420_00_INSERT_ENDERECOS_DB_INSERT_1_Insert1()
            {
                COD_CLIENTE = CLIENTE.DCLCLIENTES.COD_CLIENTE.ToString(),
                ENDERECO_OCORR_ENDERECO = ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO.ToString(),
                ENDERECO = PESENDER.DCLPESSOA_ENDERECO.ENDERECO.ToString(),
                BAIRRO = PESENDER.DCLPESSOA_ENDERECO.BAIRRO.ToString(),
                CIDADE = PESENDER.DCLPESSOA_ENDERECO.CIDADE.ToString(),
                SIGLA_UF = PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF.ToString(),
                CEP = PESENDER.DCLPESSOA_ENDERECO.CEP.ToString(),
                WHOST_DDD = WHOST_DDD.ToString(),
                WHOST_FONE = WHOST_FONE.ToString(),
                WHOST_FAX = WHOST_FAX.ToString(),
                WHOST_TELEX = WHOST_TELEX.ToString(),
            };

            R2420_00_INSERT_ENDERECOS_DB_INSERT_1_Insert1.Execute(r2420_00_INSERT_ENDERECOS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2420_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-TRATA-EMAIL-SECTION */
        private void R2500_00_TRATA_EMAIL_SECTION()
        {
            /*" -5607- MOVE '2500-00-TRATA-EMAIL          ' TO PARAGRAFO. */
            _.Move("2500-00-TRATA-EMAIL          ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5608- IF WS-JA-E-CLIENTE EQUAL 1 */

            if (WORK_AREA.WS_JA_E_CLIENTE == 1)
            {

                /*" -5609- MOVE 39 TO SII */
                _.Move(39, WS_HORAS.SII);

                /*" -5610- PERFORM R9000-00-INICIO */

                R9000_00_INICIO_SECTION();

                /*" -5611- MOVE 'SELECT SEGUROS.CLIENTE_EMAIL ' TO COMANDO */
                _.Move("SELECT SEGUROS.CLIENTE_EMAIL ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -5616- PERFORM R2500_00_TRATA_EMAIL_DB_SELECT_1 */

                R2500_00_TRATA_EMAIL_DB_SELECT_1();

                /*" -5618- PERFORM R9100-00-TERMINO */

                R9100_00_TERMINO_SECTION();

                /*" -5619- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -5620- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -5621- PERFORM R2520-00-INSERT-EMAIL */

                        R2520_00_INSERT_EMAIL_SECTION();

                        /*" -5622- ELSE */
                    }
                    else
                    {


                        /*" -5623- DISPLAY 'PROBLEMAS ACESSO ENDERECOS     ' */
                        _.Display($"PROBLEMAS ACESSO ENDERECOS     ");

                        /*" -5624- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -5625- END-IF */
                    }


                    /*" -5626- ELSE */
                }
                else
                {


                    /*" -5627- PERFORM R2510-00-ALTERA-EMAIL */

                    R2510_00_ALTERA_EMAIL_SECTION();

                    /*" -5628- ELSE */
                }

            }
            else
            {


                /*" -5629- PERFORM R2520-00-INSERT-EMAIL. */

                R2520_00_INSERT_EMAIL_SECTION();
            }


        }

        [StopWatch]
        /*" R2500-00-TRATA-EMAIL-DB-SELECT-1 */
        public void R2500_00_TRATA_EMAIL_DB_SELECT_1()
        {
            /*" -5616- EXEC SQL SELECT EMAIL INTO :CLIENEMA-EMAIL FROM SEGUROS.CLIENTE_EMAIL WHERE COD_CLIENTE = :DCLCLIENTES.COD-CLIENTE END-EXEC */

            var r2500_00_TRATA_EMAIL_DB_SELECT_1_Query1 = new R2500_00_TRATA_EMAIL_DB_SELECT_1_Query1()
            {
                COD_CLIENTE = CLIENTE.DCLCLIENTES.COD_CLIENTE.ToString(),
            };

            var executed_1 = R2500_00_TRATA_EMAIL_DB_SELECT_1_Query1.Execute(r2500_00_TRATA_EMAIL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENEMA_EMAIL, CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_EMAIL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R2510-00-ALTERA-EMAIL-SECTION */
        private void R2510_00_ALTERA_EMAIL_SECTION()
        {
            /*" -5637- MOVE '2510-00-ALTERA-EMAIL         ' TO PARAGRAFO. */
            _.Move("2510-00-ALTERA-EMAIL         ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5638- MOVE 40 TO SII */
            _.Move(40, WS_HORAS.SII);

            /*" -5639- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -5643- PERFORM R2510_00_ALTERA_EMAIL_DB_UPDATE_1 */

            R2510_00_ALTERA_EMAIL_DB_UPDATE_1();

            /*" -5645- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -5646- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5647- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5648- DISPLAY 'EMAIL NAO CADASTRADO ' */
                    _.Display($"EMAIL NAO CADASTRADO ");

                    /*" -5649- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -5650- ELSE */
                }
                else
                {


                    /*" -5651- DISPLAY 'PROBLEMAS ACESSO ENDERECOS     ' */
                    _.Display($"PROBLEMAS ACESSO ENDERECOS     ");

                    /*" -5652- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2510-00-ALTERA-EMAIL-DB-UPDATE-1 */
        public void R2510_00_ALTERA_EMAIL_DB_UPDATE_1()
        {
            /*" -5643- EXEC SQL UPDATE SEGUROS.CLIENTE_EMAIL SET EMAIL = :WHOST-EMAIL WHERE COD_CLIENTE = :DCLCLIENTES.COD-CLIENTE END-EXEC */

            var r2510_00_ALTERA_EMAIL_DB_UPDATE_1_Update1 = new R2510_00_ALTERA_EMAIL_DB_UPDATE_1_Update1()
            {
                WHOST_EMAIL = WHOST_EMAIL.ToString(),
                COD_CLIENTE = CLIENTE.DCLCLIENTES.COD_CLIENTE.ToString(),
            };

            R2510_00_ALTERA_EMAIL_DB_UPDATE_1_Update1.Execute(r2510_00_ALTERA_EMAIL_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2510_99_SAIDA*/

        [StopWatch]
        /*" R2520-00-INSERT-EMAIL-SECTION */
        private void R2520_00_INSERT_EMAIL_SECTION()
        {
            /*" -5661- MOVE 'SELECT MAX SEGUROS.CLIENTE_EMAIL' TO COMANDO */
            _.Move("SELECT MAX SEGUROS.CLIENTE_EMAIL", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5662- MOVE 41 TO SII */
            _.Move(41, WS_HORAS.SII);

            /*" -5663- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -5668- PERFORM R2520_00_INSERT_EMAIL_DB_SELECT_1 */

            R2520_00_INSERT_EMAIL_DB_SELECT_1();

            /*" -5671- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -5672- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5673- DISPLAY 'PROBLEMAS NO MAX CLEINTE_EMAIL          ' */
                _.Display($"PROBLEMAS NO MAX CLEINTE_EMAIL          ");

                /*" -5675- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5677- ADD 1 TO CLIENEMA-SEQ-EMAIL. */
            CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_SEQ_EMAIL.Value = CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_SEQ_EMAIL + 1;

            /*" -5678- MOVE '2520-00-INSERT-CLIENTE-EMAIL ' TO PARAGRAFO. */
            _.Move("2520-00-INSERT-CLIENTE-EMAIL ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5680- MOVE 'INSERT CLIENTE-EMAIL         ' TO COMANDO. */
            _.Move("INSERT CLIENTE-EMAIL         ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5681- MOVE 42 TO SII */
            _.Move(42, WS_HORAS.SII);

            /*" -5682- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -5688- PERFORM R2520_00_INSERT_EMAIL_DB_INSERT_1 */

            R2520_00_INSERT_EMAIL_DB_INSERT_1();

            /*" -5691- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -5692- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5693- DISPLAY 'PROBLEMAS NO INSERT A ENDERECOS         ' */
                _.Display($"PROBLEMAS NO INSERT A ENDERECOS         ");

                /*" -5694- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2520-00-INSERT-EMAIL-DB-SELECT-1 */
        public void R2520_00_INSERT_EMAIL_DB_SELECT_1()
        {
            /*" -5668- EXEC SQL SELECT VALUE (MAX(SEQ_EMAIL),0) INTO :CLIENEMA-SEQ-EMAIL FROM SEGUROS.CLIENTE_EMAIL WHERE COD_CLIENTE = :DCLCLIENTES.COD-CLIENTE END-EXEC */

            var r2520_00_INSERT_EMAIL_DB_SELECT_1_Query1 = new R2520_00_INSERT_EMAIL_DB_SELECT_1_Query1()
            {
                COD_CLIENTE = CLIENTE.DCLCLIENTES.COD_CLIENTE.ToString(),
            };

            var executed_1 = R2520_00_INSERT_EMAIL_DB_SELECT_1_Query1.Execute(r2520_00_INSERT_EMAIL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENEMA_SEQ_EMAIL, CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_SEQ_EMAIL);
            }


        }

        [StopWatch]
        /*" R2520-00-INSERT-EMAIL-DB-INSERT-1 */
        public void R2520_00_INSERT_EMAIL_DB_INSERT_1()
        {
            /*" -5688- EXEC SQL INSERT INTO SEGUROS.CLIENTE_EMAIL VALUES (:DCLCLIENTES.COD-CLIENTE, :CLIENEMA-SEQ-EMAIL, :WHOST-EMAIL) END-EXEC. */

            var r2520_00_INSERT_EMAIL_DB_INSERT_1_Insert1 = new R2520_00_INSERT_EMAIL_DB_INSERT_1_Insert1()
            {
                COD_CLIENTE = CLIENTE.DCLCLIENTES.COD_CLIENTE.ToString(),
                CLIENEMA_SEQ_EMAIL = CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_SEQ_EMAIL.ToString(),
                WHOST_EMAIL = WHOST_EMAIL.ToString(),
            };

            R2520_00_INSERT_EMAIL_DB_INSERT_1_Insert1.Execute(r2520_00_INSERT_EMAIL_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2520_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-INSERT-PROPOSTAVA-SECTION */
        private void R3000_00_INSERT_PROPOSTAVA_SECTION()
        {
            /*" -5712- MOVE PROPOFID-DTQITBCO OF DCLPROPOSTA-FIDELIZ TO DATA-SQL1. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO, WORK_AREA.DATA_SQL1);

            /*" -5713- IF PROPOFID-DIA-DEBITO OF DCLPROPOSTA-FIDELIZ GREATER ZEROS */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIA_DEBITO > 00)
            {

                /*" -5716- MOVE PROPOFID-DIA-DEBITO OF DCLPROPOSTA-FIDELIZ TO DIA-SQL. */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIA_DEBITO, WORK_AREA.DATA_SQL.DIA_SQL);
            }


            /*" -5719- COMPUTE MES-SQL = MES-SQL + PRODUVG-PERI-PAGAMENTO OF DCLPRODUTOS-VG. */
            WORK_AREA.DATA_SQL.MES_SQL.Value = WORK_AREA.DATA_SQL.MES_SQL + PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO;

            /*" -5720- IF MES-SQL GREATER 12 */

            if (WORK_AREA.DATA_SQL.MES_SQL > 12)
            {

                /*" -5723- COMPUTE MES-SQL = MES-SQL - 12 */
                WORK_AREA.DATA_SQL.MES_SQL.Value = WORK_AREA.DATA_SQL.MES_SQL - 12;

                /*" -5726- COMPUTE ANO-SQL = ANO-SQL + 1. */
                WORK_AREA.DATA_SQL.ANO_SQL.Value = WORK_AREA.DATA_SQL.ANO_SQL + 1;
            }


            /*" -5728- MOVE DATA-SQL1 TO WHOST-DTPROXVEN. */
            _.Move(WORK_AREA.DATA_SQL1, WHOST_DTPROXVEN);

            /*" -5729- IF PROPOFID-DIA-DEBITO OF DCLPROPOSTA-FIDELIZ GREATER ZEROS */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIA_DEBITO > 00)
            {

                /*" -5732- MOVE PROPOFID-DIA-DEBITO OF DCLPROPOSTA-FIDELIZ TO DIA-SQL. */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIA_DEBITO, WORK_AREA.DATA_SQL.DIA_SQL);
            }


            /*" -5733- IF DIA-SQL GREATER 28 */

            if (WORK_AREA.DATA_SQL.DIA_SQL > 28)
            {

                /*" -5735- MOVE 28 TO DIA-SQL. */
                _.Move(28, WORK_AREA.DATA_SQL.DIA_SQL);
            }


            /*" -5736- IF DATA-SQL LESS WHOST-DTPROXVEN */

            if (WORK_AREA.DATA_SQL < WHOST_DTPROXVEN)
            {

                /*" -5737- ADD 1 TO MES-SQL */
                WORK_AREA.DATA_SQL.MES_SQL.Value = WORK_AREA.DATA_SQL.MES_SQL + 1;

                /*" -5738- IF MES-SQL GREATER 12 */

                if (WORK_AREA.DATA_SQL.MES_SQL > 12)
                {

                    /*" -5739- MOVE 1 TO MES-SQL */
                    _.Move(1, WORK_AREA.DATA_SQL.MES_SQL);

                    /*" -5741- ADD 1 TO ANO-SQL. */
                    WORK_AREA.DATA_SQL.ANO_SQL.Value = WORK_AREA.DATA_SQL.ANO_SQL + 1;
                }

            }


            /*" -5758- MOVE DATA-SQL1 TO WHOST-DTPROXVEN. */
            _.Move(WORK_AREA.DATA_SQL1, WHOST_DTPROXVEN);

            /*" -5759- IF CANAL-GITEL */

            if (WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_GITEL"])
            {

                /*" -5760- IF RCAP-CADASTRADO */

                if (WORK_AREA.W_RCAPS["RCAP_CADASTRADO"])
                {

                    /*" -5761- MOVE '0' TO WHOST-SIT-REGISTRO */
                    _.Move("0", WHOST_SIT_REGISTRO);

                    /*" -5762- ELSE */
                }
                else
                {


                    /*" -5763- MOVE '7' TO WHOST-SIT-REGISTRO */
                    _.Move("7", WHOST_SIT_REGISTRO);

                    /*" -5764- END-IF */
                }


                /*" -5766- END-IF. */
            }


            /*" -5773- IF WS-TEM-ERRO-1855 EQUAL 'SIM' OR WS-TEM-ERRO-1807 EQUAL 'SIM' OR WS-TEM-ERRO-1852 EQUAL 'SIM' OR PROPOFID-NSAS-SIVPF OF DCLPROPOSTA-FIDELIZ EQUAL 01 OR PROPOFID-SIT-PROPOSTA OF DCLPROPOSTA-FIDELIZ EQUAL 'DEC' */

            if (WORK_AREA.WS_TEM_ERRO_1855 == "SIM" || WORK_AREA.WS_TEM_ERRO_1807 == "SIM" || WORK_AREA.WS_TEM_ERRO_1852 == "SIM" || PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAS_SIVPF == 01 || PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA == "DEC")
            {

                /*" -5774- MOVE '2' TO WHOST-SIT-REGISTRO */
                _.Move("2", WHOST_SIT_REGISTRO);

                /*" -5775- ELSE */
            }
            else
            {


                /*" -5777- IF WS-TEM-ERRO EQUAL ZEROS */

                if (WORK_AREA.WS_TEM_ERRO == 00)
                {

                    /*" -5778- IF CANAL-VENDA-PAPEL */

                    if (WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_VENDA_PAPEL"])
                    {

                        /*" -5782- IF IMPMORNATU OF DCLPLANOS-VA-VGAP NOT GREATER 300000,00 */

                        if (PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU <= 300000.00)
                        {

                            /*" -5783- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 77 */

                            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 77)
                            {

                                /*" -5784- MOVE '0' TO WHOST-SIT-REGISTRO */
                                _.Move("0", WHOST_SIT_REGISTRO);

                                /*" -5785- ELSE */
                            }
                            else
                            {


                                /*" -5786- MOVE 'E' TO WHOST-SIT-REGISTRO */
                                _.Move("E", WHOST_SIT_REGISTRO);

                                /*" -5787- END-IF */
                            }


                            /*" -5788- ELSE */
                        }
                        else
                        {


                            /*" -5789- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 77 */

                            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 77)
                            {

                                /*" -5790- MOVE '9' TO WHOST-SIT-REGISTRO */
                                _.Move("9", WHOST_SIT_REGISTRO);

                                /*" -5791- ELSE */
                            }
                            else
                            {


                                /*" -5792- MOVE 'E' TO WHOST-SIT-REGISTRO */
                                _.Move("E", WHOST_SIT_REGISTRO);

                                /*" -5793- END-IF */
                            }


                            /*" -5794- END-IF */
                        }


                        /*" -5795- END-IF */
                    }


                    /*" -5798- IF CANAL-VENDA-CEF OR CANAL-SASSE-FILIAL OR CANAL-VENDA-AIC */

                    if (WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_VENDA_CEF"] || WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_SASSE_FILIAL"] || WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_VENDA_AIC"])
                    {

                        /*" -5802- IF IMPMORNATU OF DCLPLANOS-VA-VGAP NOT GREATER 300000,00 */

                        if (PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU <= 300000.00)
                        {

                            /*" -5803- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 77 */

                            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 77)
                            {

                                /*" -5804- MOVE '0' TO WHOST-SIT-REGISTRO */
                                _.Move("0", WHOST_SIT_REGISTRO);

                                /*" -5805- ELSE */
                            }
                            else
                            {


                                /*" -5806- MOVE 'E' TO WHOST-SIT-REGISTRO */
                                _.Move("E", WHOST_SIT_REGISTRO);

                                /*" -5807- END-IF */
                            }


                            /*" -5808- ELSE */
                        }
                        else
                        {


                            /*" -5809- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 77 */

                            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 77)
                            {

                                /*" -5811- IF PRODUVG-COD-PRODUTO = 7705 OR JVPRD7705 OR 7715 */

                                if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.In("7705", JVBKINCL.JV_PRODUTOS.JVPRD7705.ToString(), "7715"))
                                {

                                    /*" -5812- MOVE '0' TO WHOST-SIT-REGISTRO */
                                    _.Move("0", WHOST_SIT_REGISTRO);

                                    /*" -5813- ELSE */
                                }
                                else
                                {


                                    /*" -5814- MOVE '9' TO WHOST-SIT-REGISTRO */
                                    _.Move("9", WHOST_SIT_REGISTRO);

                                    /*" -5815- END-IF */
                                }


                                /*" -5816- ELSE */
                            }
                            else
                            {


                                /*" -5817- MOVE 'E' TO WHOST-SIT-REGISTRO */
                                _.Move("E", WHOST_SIT_REGISTRO);

                                /*" -5818- END-IF */
                            }


                            /*" -5819- END-IF */
                        }


                        /*" -5820- END-IF */
                    }


                    /*" -5821- ELSE */
                }
                else
                {


                    /*" -5822- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 77 */

                    if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 77)
                    {

                        /*" -5823- IF WHOST-PRODUTO-SIVPF EQUAL 7708 */

                        if (WHOST_PRODUTO_SIVPF == 7708)
                        {

                            /*" -5824- MOVE '1' TO WHOST-SIT-REGISTRO */
                            _.Move("1", WHOST_SIT_REGISTRO);

                            /*" -5825- ELSE */
                        }
                        else
                        {


                            /*" -5826- MOVE '9' TO WHOST-SIT-REGISTRO */
                            _.Move("9", WHOST_SIT_REGISTRO);

                            /*" -5827- END-IF */
                        }


                        /*" -5828- ELSE */
                    }
                    else
                    {


                        /*" -5829- MOVE 'E' TO WHOST-SIT-REGISTRO */
                        _.Move("E", WHOST_SIT_REGISTRO);

                        /*" -5830- END-IF */
                    }


                    /*" -5831- END-IF */
                }


                /*" -5833- END-IF. */
            }


            /*" -5835- IF PRODUVG-COD-PRODUTO = 7732 OR JVPRD7732 OR 7733 OR JVPRD7733 */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.In("7732", JVBKINCL.JV_PRODUTOS.JVPRD7732.ToString(), "7733", JVBKINCL.JV_PRODUTOS.JVPRD7733.ToString()))
            {

                /*" -5836- MOVE '0' TO WHOST-SIT-REGISTRO */
                _.Move("0", WHOST_SIT_REGISTRO);

                /*" -5840- END-IF. */
            }


            /*" -5841- IF VIND-PROFISSAO-CONJUGE EQUAL ZEROS */

            if (VIND_PROFISSAO_CONJUGE == 00)
            {

                /*" -5845- IF PROPOFID-PROFISSAO-CONJUGE OF DCLPROPOSTA-FIDELIZ > ZEROS AND PROPOFID-PROFISSAO-CONJUGE OF DCLPROPOSTA-FIDELIZ < 1000 */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PROFISSAO_CONJUGE > 00 && PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PROFISSAO_CONJUGE < 1000)
                {

                    /*" -5848- MOVE TAB-DESCR-CBO-C (PROPOFID-PROFISSAO-CONJUGE OF DCLPROPOSTA-FIDELIZ) TO WHOST-PROFISSAO-CONJUGE */
                    _.Move(TAB_CBO1.TAB_CBO.FILLER_27[PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PROFISSAO_CONJUGE].TAB_DESCR_CBO_C, WHOST_PROFISSAO_CONJUGE);

                    /*" -5852- ELSE */
                }
                else
                {


                    /*" -5853- MOVE SPACES TO WHOST-PROFISSAO-CONJUGE */
                    _.Move("", WHOST_PROFISSAO_CONJUGE);

                    /*" -5854- END-IF */
                }


                /*" -5856- END-IF. */
            }


            /*" -5858- IF PROPOFID-AGECOBR OF DCLPROPOSTA-FIDELIZ > 0 AND PROPOFID-AGECOBR OF DCLPROPOSTA-FIDELIZ < 10000 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR > 0 && PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR < 10000)
            {

                /*" -5860- MOVE TAB-FONTE (PROPOFID-AGECOBR OF DCLPROPOSTA-FIDELIZ) TO WHOST-FONTE */
                _.Move(TAB_FILIAIS.TAB_FILIAL.FILLER_26[PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR].TAB_FONTE, WHOST_FONTE);

                /*" -5861- ELSE */
            }
            else
            {


                /*" -5864- DISPLAY 'AGENCIA INVALIDA ----> ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ ' ' PROPOFID-AGECOBR OF DCLPROPOSTA-FIDELIZ */

                $"AGENCIA INVALIDA ----> {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF} {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR}"
                .Display();

                /*" -5865- MOVE ZEROS TO WHOST-FONTE */
                _.Move(0, WHOST_FONTE);

                /*" -5867- END-IF. */
            }


            /*" -5869- IF (WHOST-FONTE = ZEROS OR 10) OR (WHOST-FONTE > 99) */

            if ((WHOST_FONTE.In("00", "10")) || (WHOST_FONTE > 99))
            {

                /*" -5875- MOVE 5 TO WHOST-FONTE. */
                _.Move(5, WHOST_FONTE);
            }


            /*" -5877- IF PRODUVG-COD-PRODUTO NOT = 7732 AND JVPRD7732 AND 7733 AND JVPRD7733 */

            if (!PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.In("7732", JVBKINCL.JV_PRODUTOS.JVPRD7732.ToString(), "7733", JVBKINCL.JV_PRODUTOS.JVPRD7733.ToString()))
            {

                /*" -5879- IF PRODUVG-PERI-PAGAMENTO = 00 OR PROPOFID-COD-PRODUTO-SIVPF = 77 */

                if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO == 00 || PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 77)
                {

                    /*" -5880- MOVE '9999-12-31' TO WHOST-DTPROXVEN */
                    _.Move("9999-12-31", WHOST_DTPROXVEN);

                    /*" -5881- END-IF */
                }


                /*" -5883- END-IF. */
            }


            /*" -5884- MOVE '3000-00-INSERT-PROPOSTAVA    ' TO PARAGRAFO. */
            _.Move("3000-00-INSERT-PROPOSTAVA    ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5886- MOVE 'INSERT PROPOSTAVA            ' TO COMANDO. */
            _.Move("INSERT PROPOSTAVA            ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5887- IF PROPOFID-ORIGEM-PROPOSTA EQUAL 80 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA == 80)
            {

                /*" -5888- IF WS-TEM-ERRO EQUAL ZEROS */

                if (WORK_AREA.WS_TEM_ERRO == 00)
                {

                    /*" -5889- MOVE '0' TO WHOST-SIT-REGISTRO */
                    _.Move("0", WHOST_SIT_REGISTRO);

                    /*" -5890- ELSE */
                }
                else
                {


                    /*" -5891- MOVE '1' TO WHOST-SIT-REGISTRO */
                    _.Move("1", WHOST_SIT_REGISTRO);

                    /*" -5892- END-IF */
                }


                /*" -5894- END-IF */
            }


            /*" -5897- IF PRODUVG-COD-PRODUTO = 7725 OR JVPRD7725 OR 7732 OR JVPRD7732 OR 7733 OR JVPRD7733 */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.In("7725", JVBKINCL.JV_PRODUTOS.JVPRD7725.ToString(), "7732", JVBKINCL.JV_PRODUTOS.JVPRD7732.ToString(), "7733", JVBKINCL.JV_PRODUTOS.JVPRD7733.ToString()))
            {

                /*" -5898- MOVE 18 TO WHOST-IDADE */
                _.Move(18, WHOST_IDADE);

                /*" -5900- END-IF */
            }


            /*" -5902- IF PRODUVG-COD-PRODUTO = 7732 OR JVPRD7732 OR 7733 OR JVPRD7733 */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.In("7732", JVBKINCL.JV_PRODUTOS.JVPRD7732.ToString(), "7733", JVBKINCL.JV_PRODUTOS.JVPRD7733.ToString()))
            {

                /*" -5906- PERFORM R3000_00_INSERT_PROPOSTAVA_DB_SELECT_1 */

                R3000_00_INSERT_PROPOSTAVA_DB_SELECT_1();

                /*" -5908- MOVE '9999-12-31' TO WHOST-DTPROXVEN */
                _.Move("9999-12-31", WHOST_DTPROXVEN);

                /*" -5911- END-IF */
            }


            /*" -5912- MOVE 43 TO SII */
            _.Move(43, WS_HORAS.SII);

            /*" -5913- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -6042- PERFORM R3000_00_INSERT_PROPOSTAVA_DB_INSERT_1 */

            R3000_00_INSERT_PROPOSTAVA_DB_INSERT_1();

            /*" -6045- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -6047- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL -803 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
            {

                /*" -6048- DISPLAY 'PROBLEMAS NO INSERT PROPOSTAVA ' */
                _.Display($"PROBLEMAS NO INSERT PROPOSTAVA ");

                /*" -6050- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -6052- IF PRODUVG-COD-PRODUTO = 7732 OR JVPRD7732 OR 7733 OR JVPRD7733 */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.In("7732", JVBKINCL.JV_PRODUTOS.JVPRD7732.ToString(), "7733", JVBKINCL.JV_PRODUTOS.JVPRD7733.ToString()))
            {

                /*" -6053- PERFORM R3210-INS-VG-MOVTO-PRET */

                R3210_INS_VG_MOVTO_PRET_SECTION();

                /*" -6055- END-IF. */
            }


            /*" -6055- ADD 1 TO AC-I-PROPOSTAVA. */
            WORK_AREA.AC_I_PROPOSTAVA.Value = WORK_AREA.AC_I_PROPOSTAVA + 1;

        }

        [StopWatch]
        /*" R3000-00-INSERT-PROPOSTAVA-DB-SELECT-1 */
        public void R3000_00_INSERT_PROPOSTAVA_DB_SELECT_1()
        {
            /*" -5906- EXEC SQL SELECT DATE(:PROPOFID-DATA-PROPOSTA) + 1 MONTH INTO : WS-DTPROXVEN FROM SYSIBM.SYSDUMMY1 END-EXEC */

            /*-- linha suprimida por comandos abaixo EXEC SQL
            /*--SELECT DATE(:PROPOFID-DATA-PROPOSTA) + 1 MONTH
            /*--INTO : WS-DTPROXVEN
            /*--FROM SYSIBM.SYSDUMMY1
            /*--END-EXEC
            /*-- */

            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA.ToDateTime().ToString(_.CurrentDateFormat), WS_DTPROXVEN);

        }

        [StopWatch]
        /*" R3000-00-INSERT-PROPOSTAVA-DB-INSERT-1 */
        public void R3000_00_INSERT_PROPOSTAVA_DB_INSERT_1()
        {
            /*" -6042- EXEC SQL INSERT INTO SEGUROS.PROPOSTAS_VA ( NUM_CERTIFICADO , COD_PRODUTO , COD_CLIENTE , OCOREND , COD_FONTE , AGE_COBRANCA , OPCAO_COBERTURA , DATA_QUITACAO , COD_AGE_VENDEDOR , OPE_CONTA_VENDEDOR , NUM_CONTA_VENDEDOR , DIG_CONTA_VENDEDOR , NUM_MATRI_VENDEDOR , COD_OPERACAO , PROFISSAO , DTINCLUS , DATA_MOVIMENTO , SIT_REGISTRO , NUM_APOLICE , COD_SUBGRUPO , OCORR_HISTORICO , NRPRIPARATZ , QTDPARATZ , DTPROXVEN , NUM_PARCELA , DATA_VENCIMENTO , SIT_INTERFACE , DTFENAE , COD_USUARIO , TIMESTAMP , IDADE , IDE_SEXO , ESTADO_CIVIL , OPCAO_MARCADA , SIGLA_CRM , COD_CRM , APOS_INVALIDEZ , ASSINATURA , ACATAMENTO , NOME_ESPOSA , DTNASC_ESPOSA , PROFIS_ESPOSA , DPS_TITULAR , DPS_ESPOSA , NUM_MATRICULA , GRAU_PARENTESCO , DATA_ADMISSAO , NUM_PROPOSTA , EM_ATIVIDADE , LOC_ATIVIDADE , INFO_COMPLEMENTAR , NRMALADIR , NRCERTIFANT , COD_CCT , FAIXA_RENDA_IND , FAIXA_RENDA_FAM , NUM_CONTR_VINCULO , COD_CORRESP_BANC , COD_ORIGEM_PROPOSTA , NUM_PRAZO_FIN , COD_OPER_CREDITO ) VALUES (:DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF , :DCLPRODUTOS-VG.PRODUVG-COD-PRODUTO , :DCLCLIENTES.COD-CLIENTE , :DCLENDERECOS.ENDERECO-OCORR-ENDERECO , :WHOST-FONTE , :DCLPROPOSTA-FIDELIZ.PROPOFID-AGECOBR , :DCLPROPOSTA-FIDELIZ.PROPOFID-OPCAO-COBER , :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO , :DCLPROPOSTA-FIDELIZ.PROPOFID-AGECTAVEN , :DCLPROPOSTA-FIDELIZ.PROPOFID-OPRCTAVEN , :DCLPROPOSTA-FIDELIZ.PROPOFID-NUMCTAVEN , :DCLPROPOSTA-FIDELIZ.PROPOFID-DIGCTAVEN , :DCLPROPOSTA-FIDELIZ.PROPOFID-NRMATRVEN , 106 , :WHOST-PROFISSAO , :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO , :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO , :WHOST-SIT-REGISTRO , :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE , :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO , 1 , 0 , 0 , :WHOST-DTPROXVEN , 1 , :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO , '0' , :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO, 'VP0601B' , CURRENT TIMESTAMP, :WHOST-IDADE, :DCLPESSOA-FISICA.SEXO, :DCLPESSOA-FISICA.ESTADO-CIVIL, NULL, NULL, NULL, :DCLPROP-SASSE-VIDA.PROPSSVD-APOS-INVALIDEZ , ' ' , ' ' , :DCLPROPOSTA-FIDELIZ.PROPOFID-NOME-CONJUGE :VIND-NOME-CONJUGE, :DCLPROPOSTA-FIDELIZ.PROPOFID-DATA-NASC-CONJUGE :VIND-DATA-NASC-CONJUGE, :WHOST-PROFISSAO-CONJUGE :VIND-PROFISSAO-CONJUGE, :DCLPROP-SASSE-VIDA.PROPSSVD-DPS-TITULAR , :DCLPROP-SASSE-VIDA.PROPSSVD-DPS-CONJUGE , NULL, NULL, NULL, NULL, NULL, NULL, :WHOST-INFO-COMPL, NULL, NULL, :DCLPROPOSTA-FIDELIZ.PROPOFID-CGC-CONVENENTE :VIND-CGC-CONVENENTE, :DCLPROPOSTA-FIDELIZ.PROPOFID-FAIXA-RENDA-IND, :DCLPROPOSTA-FIDELIZ.PROPOFID-FAIXA-RENDA-FAM, :PROPSSVD-NUM-CONTR-VINCULO :VIND-NUM-CONTR , :PROPSSVD-COD-CORRESP-BANC :VIND-COD-CORRESP , :DCLPROPOSTA-FIDELIZ.PROPOFID-ORIGEM-PROPOSTA , :PROPSSVD-NUM-PRAZO-FIN :VIND-NUM-PRAZO , :PROPSSVD-COD-OPER-CREDITO :VIND-COD-OPER-CRED ) END-EXEC. */

            var r3000_00_INSERT_PROPOSTAVA_DB_INSERT_1_Insert1 = new R3000_00_INSERT_PROPOSTAVA_DB_INSERT_1_Insert1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
                PRODUVG_COD_PRODUTO = PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.ToString(),
                COD_CLIENTE = CLIENTE.DCLCLIENTES.COD_CLIENTE.ToString(),
                ENDERECO_OCORR_ENDERECO = ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO.ToString(),
                WHOST_FONTE = WHOST_FONTE.ToString(),
                PROPOFID_AGECOBR = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR.ToString(),
                PROPOFID_OPCAO_COBER = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER.ToString(),
                PROPOFID_DTQITBCO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.ToString(),
                PROPOFID_AGECTAVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTAVEN.ToString(),
                PROPOFID_OPRCTAVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTAVEN.ToString(),
                PROPOFID_NUMCTAVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTAVEN.ToString(),
                PROPOFID_DIGCTAVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTAVEN.ToString(),
                PROPOFID_NRMATRVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN.ToString(),
                WHOST_PROFISSAO = WHOST_PROFISSAO.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                WHOST_SIT_REGISTRO = WHOST_SIT_REGISTRO.ToString(),
                PROPSSVD_NUM_APOLICE = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.ToString(),
                PROPSSVD_COD_SUBGRUPO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.ToString(),
                WHOST_DTPROXVEN = WHOST_DTPROXVEN.ToString(),
                WHOST_IDADE = WHOST_IDADE.ToString(),
                SEXO = PESFIS.DCLPESSOA_FISICA.SEXO.ToString(),
                ESTADO_CIVIL = PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL.ToString(),
                PROPSSVD_APOS_INVALIDEZ = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_APOS_INVALIDEZ.ToString(),
                PROPOFID_NOME_CONJUGE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NOME_CONJUGE.ToString(),
                VIND_NOME_CONJUGE = VIND_NOME_CONJUGE.ToString(),
                PROPOFID_DATA_NASC_CONJUGE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_NASC_CONJUGE.ToString(),
                VIND_DATA_NASC_CONJUGE = VIND_DATA_NASC_CONJUGE.ToString(),
                WHOST_PROFISSAO_CONJUGE = WHOST_PROFISSAO_CONJUGE.ToString(),
                VIND_PROFISSAO_CONJUGE = VIND_PROFISSAO_CONJUGE.ToString(),
                PROPSSVD_DPS_TITULAR = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_TITULAR.ToString(),
                PROPSSVD_DPS_CONJUGE = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_CONJUGE.ToString(),
                WHOST_INFO_COMPL = WHOST_INFO_COMPL.ToString(),
                PROPOFID_CGC_CONVENENTE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CGC_CONVENENTE.ToString(),
                VIND_CGC_CONVENENTE = VIND_CGC_CONVENENTE.ToString(),
                PROPOFID_FAIXA_RENDA_IND = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_IND.ToString(),
                PROPOFID_FAIXA_RENDA_FAM = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_FAM.ToString(),
                PROPSSVD_NUM_CONTR_VINCULO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_CONTR_VINCULO.ToString(),
                VIND_NUM_CONTR = VIND_NUM_CONTR.ToString(),
                PROPSSVD_COD_CORRESP_BANC = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_CORRESP_BANC.ToString(),
                VIND_COD_CORRESP = VIND_COD_CORRESP.ToString(),
                PROPOFID_ORIGEM_PROPOSTA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA.ToString(),
                PROPSSVD_NUM_PRAZO_FIN = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_PRAZO_FIN.ToString(),
                VIND_NUM_PRAZO = VIND_NUM_PRAZO.ToString(),
                PROPSSVD_COD_OPER_CREDITO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_OPER_CREDITO.ToString(),
                VIND_COD_OPER_CRED = VIND_COD_OPER_CRED.ToString(),
            };

            R3000_00_INSERT_PROPOSTAVA_DB_INSERT_1_Insert1.Execute(r3000_00_INSERT_PROPOSTAVA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-INSERT-COBERPROPVA-SECTION */
        private void R3100_00_INSERT_COBERPROPVA_SECTION()
        {
            /*" -6063- MOVE '3100-00-INSERT-COBERPROPVA ' TO PARAGRAFO. */
            _.Move("3100-00-INSERT-COBERPROPVA ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6067- MOVE 'INSERT COBERPROPVA         ' TO COMANDO. */
            _.Move("INSERT COBERPROPVA         ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6068- IF CANAL-GITEL */

            if (WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_GITEL"])
            {

                /*" -6069- IF PROPOFID-COD-PRODUTO-SIVPF = 77 */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 77)
                {

                    /*" -6070- IF WHOST-IDADE < 66 */

                    if (WHOST_IDADE < 66)
                    {

                        /*" -6072- COMPUTE COBERP-IMPMORNATU = PROPOFID-VAL-PAGO / 0,01449 */
                        COBERP_IMPMORNATU.Value = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO / 0.01449f;

                        /*" -6073- ELSE */
                    }
                    else
                    {


                        /*" -6075- COMPUTE COBERP-IMPMORNATU = PROPOFID-VAL-PAGO / 0,06600 */
                        COBERP_IMPMORNATU.Value = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO / 0.06600f;

                        /*" -6076- END-IF */
                    }


                    /*" -6077- IF PROD-CROTINHO */

                    if (WORK_AREA.W_TP_PRESTAMISTA["PROD_CROTINHO"])
                    {

                        /*" -6082- MOVE ZEROS TO IMPSEGAUXF OF DCLPLANOS-VA-VGAP VLCUSTAUXF OF DCLPLANOS-VA-VGAP PRMDIT OF DCLPLANOS-VA-VGAP QTDIT OF DCLPLANOS-VA-VGAP */
                        _.Move(0, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPSEGAUXF, PLVAVGAP.DCLPLANOS_VA_VGAP.VLCUSTAUXF, PLVAVGAP.DCLPLANOS_VA_VGAP.PRMDIT, PLVAVGAP.DCLPLANOS_VA_VGAP.QTDIT);

                        /*" -6083- IF PROPOFID-VAL-PAGO EQUAL 6,00 */

                        if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO == 6.00)
                        {

                            /*" -6085- MOVE 200,00 TO COBERP-IMPMORNATU */
                            _.Move(200.00, COBERP_IMPMORNATU);

                            /*" -6087- MOVE 6,00 TO PROPOFID-VAL-PAGO */
                            _.Move(6.00, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO);

                            /*" -6088- END-IF */
                        }


                        /*" -6090- END-IF */
                    }


                    /*" -6091- IF PRODUVG-COD-PRODUTO = 7707 */

                    if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO == 7707)
                    {

                        /*" -6094- COMPUTE COBERP-IMPMORNATU = (PROPOFID-VAL-PAGO * 100) / TAXAVG OF DCLPLANOS-VA-VGAP */
                        COBERP_IMPMORNATU.Value = (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO * 100) / PLVAVGAP.DCLPLANOS_VA_VGAP.TAXAVG;

                        /*" -6096- END-IF */
                    }


                    /*" -6098- MOVE COBERP-IMPMORNATU TO IMPMORNATU OF DCLPLANOS-VA-VGAP */
                    _.Move(COBERP_IMPMORNATU, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU);

                    /*" -6100- MOVE COBERP-IMPMORNATU TO IMPMORACID OF DCLPLANOS-VA-VGAP */
                    _.Move(COBERP_IMPMORNATU, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORACID);

                    /*" -6103- MOVE PROPOFID-VAL-PAGO TO VLPREMIOTOT OF DCLPLANOS-VA-VGAP PRMVG OF DCLPLANOS-VA-VGAP */
                    _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO, PLVAVGAP.DCLPLANOS_VA_VGAP.VLPREMIOTOT, PLVAVGAP.DCLPLANOS_VA_VGAP.PRMVG);

                    /*" -6104- END-IF */
                }


                /*" -6106- END-IF. */
            }


            /*" -6107- IF CANAL-SASSE-FILIAL */

            if (WORK_AREA.CANAL.W_CANAL_PROPOSTA["CANAL_SASSE_FILIAL"])
            {

                /*" -6109- MOVE ZEROS TO IMPMORNATU OF DCLPLANOS-VA-VGAP */
                _.Move(0, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU);

                /*" -6111- MOVE ZEROS TO IMPMORACID OF DCLPLANOS-VA-VGAP */
                _.Move(0, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORACID);

                /*" -6114- MOVE ZEROS TO VLPREMIOTOT OF DCLPLANOS-VA-VGAP PRMVG OF DCLPLANOS-VA-VGAP */
                _.Move(0, PLVAVGAP.DCLPLANOS_VA_VGAP.VLPREMIOTOT, PLVAVGAP.DCLPLANOS_VA_VGAP.PRMVG);

                /*" -6115- IF EXISTE-PLANO */

                if (WORK_AREA.W_PLANO["EXISTE_PLANO"])
                {

                    /*" -6121- COMPUTE COBERP-IMPMORNATU = PROPOFID-VAL-PAGO / ((TAXAVG OF DCLPLANOS-VA-VGAP / 100) * COD-PLANO OF DCLPLANOS-VA-VGAP) */
                    COBERP_IMPMORNATU.Value = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO / ((PLVAVGAP.DCLPLANOS_VA_VGAP.TAXAVG / 100f) * PLVAVGAP.DCLPLANOS_VA_VGAP.COD_PLANO);

                    /*" -6123- MOVE COBERP-IMPMORNATU TO IMPMORNATU OF DCLPLANOS-VA-VGAP */
                    _.Move(COBERP_IMPMORNATU, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU);

                    /*" -6125- MOVE COBERP-IMPMORNATU TO IMPMORACID OF DCLPLANOS-VA-VGAP */
                    _.Move(COBERP_IMPMORNATU, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORACID);

                    /*" -6128- MOVE PROPOFID-VAL-PAGO TO VLPREMIOTOT OF DCLPLANOS-VA-VGAP PRMVG OF DCLPLANOS-VA-VGAP */
                    _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO, PLVAVGAP.DCLPLANOS_VA_VGAP.VLPREMIOTOT, PLVAVGAP.DCLPLANOS_VA_VGAP.PRMVG);

                    /*" -6129- END-IF */
                }


                /*" -6131- END-IF. */
            }


            /*" -6132- IF PRODUVG-COD-PRODUTO OF DCLPRODUTOS-VG EQUAL 7713 */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO == 7713)
            {

                /*" -6133- MOVE WS-VALOR-IS TO IMPMORNATU OF DCLPLANOS-VA-VGAP */
                _.Move(WS_VALOR_IS, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU);

                /*" -6136- MOVE RCAPS-VAL-RCAP OF DCLRCAPS TO VLPREMIOTOT OF DCLPLANOS-VA-VGAP PRMVG OF DCLPLANOS-VA-VGAP */
                _.Move(RCAPS.DCLRCAPS.RCAPS_VAL_RCAP, PLVAVGAP.DCLPLANOS_VA_VGAP.VLPREMIOTOT, PLVAVGAP.DCLPLANOS_VA_VGAP.PRMVG);

                /*" -6137- MOVE WS-VALOR-IS TO IMPMORACID OF DCLPLANOS-VA-VGAP */
                _.Move(WS_VALOR_IS, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORACID);

                /*" -6139- END-IF */
            }


            /*" -6140- IF PRODUVG-COD-PRODUTO = 7725 OR JVPRD7725 */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.In("7725", JVBKINCL.JV_PRODUTOS.JVPRD7725.ToString()))
            {

                /*" -6142- PERFORM R3101-00-PEGAR-TAXA */

                R3101_00_PEGAR_TAXA_SECTION();

                /*" -6145- COMPUTE WS-VALOR-IS-7725 = (RCAPS-VAL-RCAP * 100) / WS-TAXAVG */
                WS_VALOR_IS_7725.Value = (RCAPS.DCLRCAPS.RCAPS_VAL_RCAP * 100) / WS_TAXAVG;

                /*" -6146- MOVE WS-VALOR-IS-7725 TO IMPMORNATU OF DCLPLANOS-VA-VGAP */
                _.Move(WS_VALOR_IS_7725, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU);

                /*" -6149- MOVE RCAPS-VAL-RCAP OF DCLRCAPS TO VLPREMIOTOT OF DCLPLANOS-VA-VGAP PRMVG OF DCLPLANOS-VA-VGAP */
                _.Move(RCAPS.DCLRCAPS.RCAPS_VAL_RCAP, PLVAVGAP.DCLPLANOS_VA_VGAP.VLPREMIOTOT, PLVAVGAP.DCLPLANOS_VA_VGAP.PRMVG);

                /*" -6150- MOVE WS-VALOR-IS-7725 TO IMPMORACID OF DCLPLANOS-VA-VGAP */
                _.Move(WS_VALOR_IS_7725, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORACID);

                /*" -6152- END-IF */
            }


            /*" -6154- IF PRODUVG-COD-PRODUTO = 7732 OR JVPRD7732 OR 7733 OR JVPRD7733 */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.In("7732", JVBKINCL.JV_PRODUTOS.JVPRD7732.ToString(), "7733", JVBKINCL.JV_PRODUTOS.JVPRD7733.ToString()))
            {

                /*" -6155- PERFORM R3100-00-TRATAR-VLR-IS */

                R3100_00_TRATAR_VLR_IS_SECTION();

                /*" -6156- MOVE WS-VLR-IS-NUM TO IMPMORNATU OF DCLPLANOS-VA-VGAP */
                _.Move(FILLER_0.WS_VLR_IS_NUM, PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU);

                /*" -6157- MOVE PROPOFID-VAL-PAGO TO VLPREMIOTOT OF DCLPLANOS-VA-VGAP */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO, PLVAVGAP.DCLPLANOS_VA_VGAP.VLPREMIOTOT);

                /*" -6158- MOVE PROPOFID-VAL-PAGO TO PRMVG OF DCLPLANOS-VA-VGAP */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO, PLVAVGAP.DCLPLANOS_VA_VGAP.PRMVG);

                /*" -6160- END-IF */
            }


            /*" -6161- MOVE 44 TO SII */
            _.Move(44, WS_HORAS.SII);

            /*" -6162- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -6163- IF PROPOFID-NRMATRCON = 19 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRCON == 19)
            {

                /*" -6228- PERFORM R3100_00_INSERT_COBERPROPVA_DB_INSERT_1 */

                R3100_00_INSERT_COBERPROPVA_DB_INSERT_1();

                /*" -6230- ELSE */
            }
            else
            {


                /*" -6295- PERFORM R3100_00_INSERT_COBERPROPVA_DB_INSERT_2 */

                R3100_00_INSERT_COBERPROPVA_DB_INSERT_2();

                /*" -6299- END-IF */
            }


            /*" -6301- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -6303- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL -803 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
            {

                /*" -6304- DISPLAY 'PROBLEMAS NO INSERT COBERPROPVA' */
                _.Display($"PROBLEMAS NO INSERT COBERPROPVA");

                /*" -6304- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3100-00-INSERT-COBERPROPVA-DB-INSERT-1 */
        public void R3100_00_INSERT_COBERPROPVA_DB_INSERT_1()
        {
            /*" -6228- EXEC SQL INSERT INTO SEGUROS.HIS_COBER_PROPOST (NUM_CERTIFICADO , OCORR_HISTORICO , DATA_INIVIGENCIA , DATA_TERVIGENCIA , IMPSEGUR , QUANT_VIDAS , IMPSEGIND , COD_OPERACAO , OPCAO_COBERTURA , IMP_MORNATU , IMPMORACID , IMPINVPERM , IMPAMDS , IMPDH , IMPDIT , VLPREMIO , PRMVG , PRMAP , QTDE_TIT_CAPITALIZ, VAL_TIT_CAPITALIZ , VAL_CUSTO_CAPITALI, IMPSEGCDG , VLCUSTCDG , COD_USUARIO , TIMESTAMP , IMPSEGAUXF , VLCUSTAUXF , PRMDIT , QTMDIT) VALUES (:DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF, 1, :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO, '9999-12-31' , :WS-VALOR-IS-CDC, 0, :WS-VALOR-IS-CDC, 106, :DCLPROPOSTA-FIDELIZ.PROPOFID-OPCAO-COBER, :WS-VALOR-IS-CDC, :WS-VALOR-IS-CDC, :DCLPLANOS-VA-VGAP.IMPINVPERM, :DCLPLANOS-VA-VGAP.IMPAMDS, :DCLPLANOS-VA-VGAP.IMPDH, :DCLPLANOS-VA-VGAP.IMPDIT, :DCLPLANOS-VA-VGAP.VLPREMIOTOT, :DCLPLANOS-VA-VGAP.PRMVG, :DCLPLANOS-VA-VGAP.PRMAP, :DCLPLANOS-VA-VGAP.QTTITCAP, :DCLPLANOS-VA-VGAP.VLTITCAP, :DCLPLANOS-VA-VGAP.VLCUSTCAP, :DCLPLANOS-VA-VGAP.IMPSEGCDG, :DCLPLANOS-VA-VGAP.VLCUSTCDG, 'VP0601B' , CURRENT TIMESTAMP, :DCLPLANOS-VA-VGAP.IMPSEGAUXF :VIND-IMPSEGAUXF, :DCLPLANOS-VA-VGAP.VLCUSTAUXF :VIND-VLCUSTAUXF, :DCLPLANOS-VA-VGAP.PRMDIT :VIND-PRMDIT, :DCLPLANOS-VA-VGAP.QTDIT :VIND-QTDIT) END-EXEC */

            var r3100_00_INSERT_COBERPROPVA_DB_INSERT_1_Insert1 = new R3100_00_INSERT_COBERPROPVA_DB_INSERT_1_Insert1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
                PROPOFID_DTQITBCO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.ToString(),
                WS_VALOR_IS_CDC = WS_VALOR_IS_CDC.ToString(),
                PROPOFID_OPCAO_COBER = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER.ToString(),
                IMPINVPERM = PLVAVGAP.DCLPLANOS_VA_VGAP.IMPINVPERM.ToString(),
                IMPAMDS = PLVAVGAP.DCLPLANOS_VA_VGAP.IMPAMDS.ToString(),
                IMPDH = PLVAVGAP.DCLPLANOS_VA_VGAP.IMPDH.ToString(),
                IMPDIT = PLVAVGAP.DCLPLANOS_VA_VGAP.IMPDIT.ToString(),
                VLPREMIOTOT = PLVAVGAP.DCLPLANOS_VA_VGAP.VLPREMIOTOT.ToString(),
                PRMVG = PLVAVGAP.DCLPLANOS_VA_VGAP.PRMVG.ToString(),
                PRMAP = PLVAVGAP.DCLPLANOS_VA_VGAP.PRMAP.ToString(),
                QTTITCAP = PLVAVGAP.DCLPLANOS_VA_VGAP.QTTITCAP.ToString(),
                VLTITCAP = PLVAVGAP.DCLPLANOS_VA_VGAP.VLTITCAP.ToString(),
                VLCUSTCAP = PLVAVGAP.DCLPLANOS_VA_VGAP.VLCUSTCAP.ToString(),
                IMPSEGCDG = PLVAVGAP.DCLPLANOS_VA_VGAP.IMPSEGCDG.ToString(),
                VLCUSTCDG = PLVAVGAP.DCLPLANOS_VA_VGAP.VLCUSTCDG.ToString(),
                IMPSEGAUXF = PLVAVGAP.DCLPLANOS_VA_VGAP.IMPSEGAUXF.ToString(),
                VIND_IMPSEGAUXF = VIND_IMPSEGAUXF.ToString(),
                VLCUSTAUXF = PLVAVGAP.DCLPLANOS_VA_VGAP.VLCUSTAUXF.ToString(),
                VIND_VLCUSTAUXF = VIND_VLCUSTAUXF.ToString(),
                PRMDIT = PLVAVGAP.DCLPLANOS_VA_VGAP.PRMDIT.ToString(),
                VIND_PRMDIT = VIND_PRMDIT.ToString(),
                QTDIT = PLVAVGAP.DCLPLANOS_VA_VGAP.QTDIT.ToString(),
                VIND_QTDIT = VIND_QTDIT.ToString(),
            };

            R3100_00_INSERT_COBERPROPVA_DB_INSERT_1_Insert1.Execute(r3100_00_INSERT_COBERPROPVA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-INSERT-COBERPROPVA-DB-INSERT-2 */
        public void R3100_00_INSERT_COBERPROPVA_DB_INSERT_2()
        {
            /*" -6295- EXEC SQL INSERT INTO SEGUROS.HIS_COBER_PROPOST (NUM_CERTIFICADO , OCORR_HISTORICO , DATA_INIVIGENCIA , DATA_TERVIGENCIA , IMPSEGUR , QUANT_VIDAS , IMPSEGIND , COD_OPERACAO , OPCAO_COBERTURA , IMP_MORNATU , IMPMORACID , IMPINVPERM , IMPAMDS , IMPDH , IMPDIT , VLPREMIO , PRMVG , PRMAP , QTDE_TIT_CAPITALIZ, VAL_TIT_CAPITALIZ , VAL_CUSTO_CAPITALI, IMPSEGCDG , VLCUSTCDG , COD_USUARIO , TIMESTAMP , IMPSEGAUXF , VLCUSTAUXF , PRMDIT , QTMDIT) VALUES (:DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF, 1, :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO, '9999-12-31' , :DCLPLANOS-VA-VGAP.IMPMORNATU, 0, :DCLPLANOS-VA-VGAP.IMPMORNATU, 106, :DCLPROPOSTA-FIDELIZ.PROPOFID-OPCAO-COBER, :DCLPLANOS-VA-VGAP.IMPMORNATU, :DCLPLANOS-VA-VGAP.IMPMORACID, :DCLPLANOS-VA-VGAP.IMPINVPERM, :DCLPLANOS-VA-VGAP.IMPAMDS, :DCLPLANOS-VA-VGAP.IMPDH, :DCLPLANOS-VA-VGAP.IMPDIT, :DCLPLANOS-VA-VGAP.VLPREMIOTOT, :DCLPLANOS-VA-VGAP.PRMVG, :DCLPLANOS-VA-VGAP.PRMAP, :DCLPLANOS-VA-VGAP.QTTITCAP, :DCLPLANOS-VA-VGAP.VLTITCAP, :DCLPLANOS-VA-VGAP.VLCUSTCAP, :DCLPLANOS-VA-VGAP.IMPSEGCDG, :DCLPLANOS-VA-VGAP.VLCUSTCDG, 'VP0601B' , CURRENT TIMESTAMP, :DCLPLANOS-VA-VGAP.IMPSEGAUXF :VIND-IMPSEGAUXF, :DCLPLANOS-VA-VGAP.VLCUSTAUXF :VIND-VLCUSTAUXF, :DCLPLANOS-VA-VGAP.PRMDIT :VIND-PRMDIT, :DCLPLANOS-VA-VGAP.QTDIT :VIND-QTDIT) END-EXEC */

            var r3100_00_INSERT_COBERPROPVA_DB_INSERT_2_Insert1 = new R3100_00_INSERT_COBERPROPVA_DB_INSERT_2_Insert1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
                PROPOFID_DTQITBCO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.ToString(),
                IMPMORNATU = PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU.ToString(),
                PROPOFID_OPCAO_COBER = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER.ToString(),
                IMPMORACID = PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORACID.ToString(),
                IMPINVPERM = PLVAVGAP.DCLPLANOS_VA_VGAP.IMPINVPERM.ToString(),
                IMPAMDS = PLVAVGAP.DCLPLANOS_VA_VGAP.IMPAMDS.ToString(),
                IMPDH = PLVAVGAP.DCLPLANOS_VA_VGAP.IMPDH.ToString(),
                IMPDIT = PLVAVGAP.DCLPLANOS_VA_VGAP.IMPDIT.ToString(),
                VLPREMIOTOT = PLVAVGAP.DCLPLANOS_VA_VGAP.VLPREMIOTOT.ToString(),
                PRMVG = PLVAVGAP.DCLPLANOS_VA_VGAP.PRMVG.ToString(),
                PRMAP = PLVAVGAP.DCLPLANOS_VA_VGAP.PRMAP.ToString(),
                QTTITCAP = PLVAVGAP.DCLPLANOS_VA_VGAP.QTTITCAP.ToString(),
                VLTITCAP = PLVAVGAP.DCLPLANOS_VA_VGAP.VLTITCAP.ToString(),
                VLCUSTCAP = PLVAVGAP.DCLPLANOS_VA_VGAP.VLCUSTCAP.ToString(),
                IMPSEGCDG = PLVAVGAP.DCLPLANOS_VA_VGAP.IMPSEGCDG.ToString(),
                VLCUSTCDG = PLVAVGAP.DCLPLANOS_VA_VGAP.VLCUSTCDG.ToString(),
                IMPSEGAUXF = PLVAVGAP.DCLPLANOS_VA_VGAP.IMPSEGAUXF.ToString(),
                VIND_IMPSEGAUXF = VIND_IMPSEGAUXF.ToString(),
                VLCUSTAUXF = PLVAVGAP.DCLPLANOS_VA_VGAP.VLCUSTAUXF.ToString(),
                VIND_VLCUSTAUXF = VIND_VLCUSTAUXF.ToString(),
                PRMDIT = PLVAVGAP.DCLPLANOS_VA_VGAP.PRMDIT.ToString(),
                VIND_PRMDIT = VIND_PRMDIT.ToString(),
                QTDIT = PLVAVGAP.DCLPLANOS_VA_VGAP.QTDIT.ToString(),
                VIND_QTDIT = VIND_QTDIT.ToString(),
            };

            R3100_00_INSERT_COBERPROPVA_DB_INSERT_2_Insert1.Execute(r3100_00_INSERT_COBERPROPVA_DB_INSERT_2_Insert1);

        }

        [StopWatch]
        /*" R3100-00-TRATAR-VLR-IS-SECTION */
        private void R3100_00_TRATAR_VLR_IS_SECTION()
        {
            /*" -6312- MOVE 'R3100-00-TRATAR-VLR-IS' TO PARAGRAFO. */
            _.Move("R3100-00-TRATAR-VLR-IS", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6314- PERFORM R2240-00-SELECT-PROPFIDC. */

            R2240_00_SELECT_PROPFIDC_SECTION();

            /*" -6314- MOVE PROFIDCO-INFORMACAO-COMPL TO WS-VALOR-IS-ALF. */
            _.Move(PROFIDCO.DCLPROP_FIDELIZ_COMP.PROFIDCO_INFORMACAO_COMPL, WS_VALOR_IS_ALF);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_VLR_IS*/

        [StopWatch]
        /*" R3101-00-PEGAR-TAXA-SECTION */
        private void R3101_00_PEGAR_TAXA_SECTION()
        {
            /*" -6321- MOVE 'R3101-00-PEGAR-TAXA ' TO PARAGRAFO. */
            _.Move("R3101-00-PEGAR-TAXA ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6335- PERFORM R3101_00_PEGAR_TAXA_DB_SELECT_1 */

            R3101_00_PEGAR_TAXA_DB_SELECT_1();

            /*" -6338- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -6339- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_SQLCODE);

                /*" -6340- DISPLAY '-----------------------------------' */
                _.Display($"-----------------------------------");

                /*" -6341- DISPLAY 'ERRO PEGAR TAXA PARA PRODUTO 7725/' JVPRD7725 */
                _.Display($"ERRO PEGAR TAXA PARA PRODUTO 7725/{JVBKINCL.JV_PRODUTOS.JVPRD7725}");

                /*" -6342- DISPLAY 'SQLCODE = ' WS-SQLCODE */
                _.Display($"SQLCODE = {WS_SQLCODE}");

                /*" -6343- DISPLAY 'NUM_APOLICE = ' PROPSSVD-NUM-APOLICE */
                _.Display($"NUM_APOLICE = {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE}");

                /*" -6344- DISPLAY 'COD_PLANO   = ' PROPOFID-COD-PLANO */
                _.Display($"COD_PLANO   = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO}");

                /*" -6345- DISPLAY 'DTQITBCO    = ' PROPOFID-DTQITBCO */
                _.Display($"DTQITBCO    = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO}");

                /*" -6346- DISPLAY '-----------------------------------' */
                _.Display($"-----------------------------------");

                /*" -6347- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -6349- END-IF. */
            }


            /*" -6350- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -6351- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_SQLCODE);

                /*" -6352- DISPLAY 'ERRO PEGAR TAXA PARA PRODUTO 7725/' JVPRD7725 */
                _.Display($"ERRO PEGAR TAXA PARA PRODUTO 7725/{JVBKINCL.JV_PRODUTOS.JVPRD7725}");

                /*" -6353- DISPLAY 'SQLCODE = ' WS-SQLCODE */
                _.Display($"SQLCODE = {WS_SQLCODE}");

                /*" -6354- DISPLAY 'NUM_APOLICE = ' PROPSSVD-NUM-APOLICE */
                _.Display($"NUM_APOLICE = {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE}");

                /*" -6355- DISPLAY 'COD_PLANO   = ' PROPOFID-COD-PLANO */
                _.Display($"COD_PLANO   = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO}");

                /*" -6356- DISPLAY 'DTQITBCO    = ' PROPOFID-DTQITBCO */
                _.Display($"DTQITBCO    = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO}");

                /*" -6357- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -6357- END-IF. */
            }


        }

        [StopWatch]
        /*" R3101-00-PEGAR-TAXA-DB-SELECT-1 */
        public void R3101_00_PEGAR_TAXA_DB_SELECT_1()
        {
            /*" -6335- EXEC SQL SELECT TAXAVG INTO :WS-TAXAVG FROM SEGUROS.PLANOS_VA_VGAP WHERE NUM_APOLICE = :PROPSSVD-NUM-APOLICE AND CODSUBES = 1 AND COD_PLANO = :PROPOFID-COD-PLANO AND OPCAO_COBER = ' ' AND DTINIVIG <= :PROPOFID-DTQITBCO AND DTTERVIG >= :PROPOFID-DTQITBCO AND IDADE_INICIAL <= 18 AND IDADE_FINAL >= 18 WITH UR END-EXEC. */

            var r3101_00_PEGAR_TAXA_DB_SELECT_1_Query1 = new R3101_00_PEGAR_TAXA_DB_SELECT_1_Query1()
            {
                PROPSSVD_NUM_APOLICE = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.ToString(),
                PROPOFID_COD_PLANO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO.ToString(),
                PROPOFID_DTQITBCO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.ToString(),
            };

            var executed_1 = R3101_00_PEGAR_TAXA_DB_SELECT_1_Query1.Execute(r3101_00_PEGAR_TAXA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_TAXAVG, WS_TAXAVG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R3110-00-DECLARE-VGPLARAMCOB-SECTION */
        private void R3110_00_DECLARE_VGPLARAMCOB_SECTION()
        {
            /*" -6372- MOVE 'DECLARE VGPLARAMC' TO COMANDO. */
            _.Move("DECLARE VGPLARAMC", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6397- PERFORM R3110_00_DECLARE_VGPLARAMCOB_DB_DECLARE_1 */

            R3110_00_DECLARE_VGPLARAMCOB_DB_DECLARE_1();

            /*" -6407- MOVE 'OPEN  VGPLARAMC' TO COMANDO. */
            _.Move("OPEN  VGPLARAMC", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6408- MOVE 45 TO SII */
            _.Move(45, WS_HORAS.SII);

            /*" -6409- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -6409- PERFORM R3110_00_DECLARE_VGPLARAMCOB_DB_OPEN_1 */

            R3110_00_DECLARE_VGPLARAMCOB_DB_OPEN_1();

            /*" -6412- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -6414- MOVE SPACES TO WFIM-VGPLARAMC. */
            _.Move("", WORK_AREA.WFIM_VGPLARAMC);

            /*" -6415- PERFORM R3120-00-FETCH-VGPLARAMC UNTIL WFIM-VGPLARAMC NOT EQUAL SPACES. */

            while (!(!WORK_AREA.WFIM_VGPLARAMC.IsEmpty()))
            {

                R3120_00_FETCH_VGPLARAMC_SECTION();
            }

        }

        [StopWatch]
        /*" R3110-00-DECLARE-VGPLARAMCOB-DB-OPEN-1 */
        public void R3110_00_DECLARE_VGPLARAMCOB_DB_OPEN_1()
        {
            /*" -6409- EXEC SQL OPEN VGPLARAMC END-EXEC. */

            VGPLARAMC.Open();

        }

        [StopWatch]
        /*" R3150-00-DECLARE-VGPLAACES-DB-DECLARE-1 */
        public void R3150_00_DECLARE_VGPLAACES_DB_DECLARE_1()
        {
            /*" -6514- EXEC SQL DECLARE VGPLAACES CURSOR FOR SELECT NUM_ACESSORIO, QTD_COBERTURA, VLR_IMP_SEGURADA, VLR_CUSTO, VLR_PREMIO FROM SEGUROS.VG_PLANO_ACESSORIO WHERE NUM_APOLICE = :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE AND CODSUBES = :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO AND OPCAO_COBER = :DCLPROPOSTA-FIDELIZ.PROPOFID-OPCAO-COBER AND DTINIVIG <= :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO AND DTTERVIG >= :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO AND IDADE_INICIAL <= :WHOST-IDADE AND IDADE_FINAL >= :WHOST-IDADE AND PERIPGTO = :DCLPRODUTOS-VG.PRODUVG-PERI-PAGAMENTO ORDER BY NUM_ACESSORIO END-EXEC. */
            VGPLAACES = new VP0601B_VGPLAACES(true);
            string GetQuery_VGPLAACES()
            {
                var query = @$"SELECT NUM_ACESSORIO
							, 
							QTD_COBERTURA
							, 
							VLR_IMP_SEGURADA
							, 
							VLR_CUSTO
							, 
							VLR_PREMIO 
							FROM SEGUROS.VG_PLANO_ACESSORIO 
							WHERE NUM_APOLICE = 
							'{PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE}' 
							AND CODSUBES = 
							'{PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO}' 
							AND OPCAO_COBER = 
							'{PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER}' 
							AND DTINIVIG <= 
							'{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND DTTERVIG >= 
							'{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND IDADE_INICIAL <= '{WHOST_IDADE}' 
							AND IDADE_FINAL >= '{WHOST_IDADE}' 
							AND PERIPGTO = 
							'{PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO}' 
							ORDER BY NUM_ACESSORIO";

                return query;
            }
            VGPLAACES.GetQueryEvent += GetQuery_VGPLAACES;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3110_99_FIM*/

        [StopWatch]
        /*" R3120-00-FETCH-VGPLARAMC-SECTION */
        private void R3120_00_FETCH_VGPLARAMC_SECTION()
        {
            /*" -6424- MOVE 'R3120-00-FETCH-VG-PLANO-RAMO-COB' TO COMANDO */
            _.Move("R3120-00-FETCH-VG-PLANO-RAMO-COB", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6428- MOVE 'FETCH VGPLARAMC' TO COMANDO. */
            _.Move("FETCH VGPLARAMC", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6429- MOVE 46 TO SII */
            _.Move(46, WS_HORAS.SII);

            /*" -6430- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -6438- PERFORM R3120_00_FETCH_VGPLARAMC_DB_FETCH_1 */

            R3120_00_FETCH_VGPLARAMC_DB_FETCH_1();

            /*" -6441- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -6442- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -6443- MOVE 'S' TO WFIM-VGPLARAMC */
                _.Move("S", WORK_AREA.WFIM_VGPLARAMC);

                /*" -6443- PERFORM R3120_00_FETCH_VGPLARAMC_DB_CLOSE_1 */

                R3120_00_FETCH_VGPLARAMC_DB_CLOSE_1();

                /*" -6446- GO TO R3120-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3120_99_SAIDA*/ //GOTO
                return;
            }


            /*" -6446- PERFORM R3130-00-INSERT-VGHISTRAMCOB. */

            R3130_00_INSERT_VGHISTRAMCOB_SECTION();

        }

        [StopWatch]
        /*" R3120-00-FETCH-VGPLARAMC-DB-FETCH-1 */
        public void R3120_00_FETCH_VGPLARAMC_DB_FETCH_1()
        {
            /*" -6438- EXEC SQL FETCH VGPLARAMC INTO :VGPLAR-NUM-RAMO, :VGPLAR-NUM-COBERTURA, :VGPLAR-QTD-COBERTURA, :VGPLAR-IMPSEGURADA, :VGPLAR-CUSTO, :VGPLAR-PREMIO END-EXEC. */

            if (VGPLARAMC.Fetch())
            {
                _.Move(VGPLARAMC.VGPLAR_NUM_RAMO, VGPLAR_NUM_RAMO);
                _.Move(VGPLARAMC.VGPLAR_NUM_COBERTURA, VGPLAR_NUM_COBERTURA);
                _.Move(VGPLARAMC.VGPLAR_QTD_COBERTURA, VGPLAR_QTD_COBERTURA);
                _.Move(VGPLARAMC.VGPLAR_IMPSEGURADA, VGPLAR_IMPSEGURADA);
                _.Move(VGPLARAMC.VGPLAR_CUSTO, VGPLAR_CUSTO);
                _.Move(VGPLARAMC.VGPLAR_PREMIO, VGPLAR_PREMIO);
            }

        }

        [StopWatch]
        /*" R3120-00-FETCH-VGPLARAMC-DB-CLOSE-1 */
        public void R3120_00_FETCH_VGPLARAMC_DB_CLOSE_1()
        {
            /*" -6443- EXEC SQL CLOSE VGPLARAMC END-EXEC */

            VGPLARAMC.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3120_99_SAIDA*/

        [StopWatch]
        /*" R3130-00-INSERT-VGHISTRAMCOB-SECTION */
        private void R3130_00_INSERT_VGHISTRAMCOB_SECTION()
        {
            /*" -6457- MOVE 'INSERT VG_HIST_RAMO_COB' TO COMANDO. */
            _.Move("INSERT VG_HIST_RAMO_COB", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6458- MOVE 47 TO SII */
            _.Move(47, WS_HORAS.SII);

            /*" -6459- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -6469- PERFORM R3130_00_INSERT_VGHISTRAMCOB_DB_INSERT_1 */

            R3130_00_INSERT_VGHISTRAMCOB_DB_INSERT_1();

            /*" -6472- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -6474- IF SQLCODE NOT EQUAL ZEROES AND SQLCODE NOT EQUAL -803 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
            {

                /*" -6476- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -6476- ADD 1 TO AC-I-HISTRAMOCOB. */
            WORK_AREA.AC_I_HISTRAMOCOB.Value = WORK_AREA.AC_I_HISTRAMOCOB + 1;

        }

        [StopWatch]
        /*" R3130-00-INSERT-VGHISTRAMCOB-DB-INSERT-1 */
        public void R3130_00_INSERT_VGHISTRAMCOB_DB_INSERT_1()
        {
            /*" -6469- EXEC SQL INSERT INTO SEGUROS.VG_HIST_RAMO_COB VALUES (:DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF, 1, :VGPLAR-NUM-RAMO, :VGPLAR-NUM-COBERTURA, :VGPLAR-QTD-COBERTURA, :VGPLAR-IMPSEGURADA, :VGPLAR-CUSTO, :VGPLAR-PREMIO) END-EXEC. */

            var r3130_00_INSERT_VGHISTRAMCOB_DB_INSERT_1_Insert1 = new R3130_00_INSERT_VGHISTRAMCOB_DB_INSERT_1_Insert1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
                VGPLAR_NUM_RAMO = VGPLAR_NUM_RAMO.ToString(),
                VGPLAR_NUM_COBERTURA = VGPLAR_NUM_COBERTURA.ToString(),
                VGPLAR_QTD_COBERTURA = VGPLAR_QTD_COBERTURA.ToString(),
                VGPLAR_IMPSEGURADA = VGPLAR_IMPSEGURADA.ToString(),
                VGPLAR_CUSTO = VGPLAR_CUSTO.ToString(),
                VGPLAR_PREMIO = VGPLAR_PREMIO.ToString(),
            };

            R3130_00_INSERT_VGHISTRAMCOB_DB_INSERT_1_Insert1.Execute(r3130_00_INSERT_VGHISTRAMCOB_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3130_99_FIM*/

        [StopWatch]
        /*" R3150-00-DECLARE-VGPLAACES-SECTION */
        private void R3150_00_DECLARE_VGPLAACES_SECTION()
        {
            /*" -6491- MOVE 'DECLARE VGPLAACES ' TO COMANDO. */
            _.Move("DECLARE VGPLAACES ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6514- PERFORM R3150_00_DECLARE_VGPLAACES_DB_DECLARE_1 */

            R3150_00_DECLARE_VGPLAACES_DB_DECLARE_1();

            /*" -6518- MOVE 'OPEN  VGPLAACES' TO COMANDO. */
            _.Move("OPEN  VGPLAACES", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6519- MOVE 48 TO SII */
            _.Move(48, WS_HORAS.SII);

            /*" -6520- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -6520- PERFORM R3150_00_DECLARE_VGPLAACES_DB_OPEN_1 */

            R3150_00_DECLARE_VGPLAACES_DB_OPEN_1();

            /*" -6523- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -6525- MOVE SPACES TO WFIM-VGPLAACES. */
            _.Move("", WORK_AREA.WFIM_VGPLAACES);

            /*" -6526- PERFORM R3160-00-FETCH-VGPLAACES UNTIL WFIM-VGPLAACES NOT EQUAL SPACES. */

            while (!(!WORK_AREA.WFIM_VGPLAACES.IsEmpty()))
            {

                R3160_00_FETCH_VGPLAACES_SECTION();
            }

        }

        [StopWatch]
        /*" R3150-00-DECLARE-VGPLAACES-DB-OPEN-1 */
        public void R3150_00_DECLARE_VGPLAACES_DB_OPEN_1()
        {
            /*" -6520- EXEC SQL OPEN VGPLAACES END-EXEC. */

            VGPLAACES.Open();

        }

        [StopWatch]
        /*" R6000-00-DECLARE-AGENCEF-DB-DECLARE-1 */
        public void R6000_00_DECLARE_AGENCEF_DB_DECLARE_1()
        {
            /*" -7685- EXEC SQL DECLARE C01_AGENCEF CURSOR FOR SELECT A.COD_AGENCIA, B.COD_FONTE FROM SEGUROS.AGENCIAS_CEF A, SEGUROS.MALHA_CEF B WHERE A.COD_ESCNEG > 99 AND A.COD_ESCNEG = B.COD_SUREG ORDER BY A.COD_AGENCIA END-EXEC. */
            C01_AGENCEF = new VP0601B_C01_AGENCEF(false);
            string GetQuery_C01_AGENCEF()
            {
                var query = @$"SELECT A.COD_AGENCIA
							, 
							B.COD_FONTE 
							FROM SEGUROS.AGENCIAS_CEF A
							, 
							SEGUROS.MALHA_CEF B 
							WHERE A.COD_ESCNEG > 99 
							AND A.COD_ESCNEG = B.COD_SUREG 
							ORDER BY A.COD_AGENCIA";

                return query;
            }
            C01_AGENCEF.GetQueryEvent += GetQuery_C01_AGENCEF;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3150_99_FIM*/

        [StopWatch]
        /*" R3160-00-FETCH-VGPLAACES-SECTION */
        private void R3160_00_FETCH_VGPLAACES_SECTION()
        {
            /*" -6535- MOVE 'R3160-00-FETCH-VG-PLANO-ACESSORIO' TO COMANDO */
            _.Move("R3160-00-FETCH-VG-PLANO-ACESSORIO", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6538- MOVE 'FETCH VGPLAACES' TO COMANDO. */
            _.Move("FETCH VGPLAACES", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6539- MOVE 49 TO SII */
            _.Move(49, WS_HORAS.SII);

            /*" -6540- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -6547- PERFORM R3160_00_FETCH_VGPLAACES_DB_FETCH_1 */

            R3160_00_FETCH_VGPLAACES_DB_FETCH_1();

            /*" -6550- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -6551- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -6552- MOVE 'S' TO WFIM-VGPLAACES */
                _.Move("S", WORK_AREA.WFIM_VGPLAACES);

                /*" -6552- PERFORM R3160_00_FETCH_VGPLAACES_DB_CLOSE_1 */

                R3160_00_FETCH_VGPLAACES_DB_CLOSE_1();

                /*" -6555- GO TO R3160-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3160_99_SAIDA*/ //GOTO
                return;
            }


            /*" -6555- PERFORM R3170-00-INSERT-VGHISACESSCOB. */

            R3170_00_INSERT_VGHISACESSCOB_SECTION();

        }

        [StopWatch]
        /*" R3160-00-FETCH-VGPLAACES-DB-FETCH-1 */
        public void R3160_00_FETCH_VGPLAACES_DB_FETCH_1()
        {
            /*" -6547- EXEC SQL FETCH VGPLAACES INTO :VGPLAA-NUM-ACESSORIO, :VGPLAA-QTD-COBERTURA, :VGPLAA-IMPSEGURADA, :VGPLAA-CUSTO, :VGPLAA-PREMIO END-EXEC. */

            if (VGPLAACES.Fetch())
            {
                _.Move(VGPLAACES.VGPLAA_NUM_ACESSORIO, VGPLAA_NUM_ACESSORIO);
                _.Move(VGPLAACES.VGPLAA_QTD_COBERTURA, VGPLAA_QTD_COBERTURA);
                _.Move(VGPLAACES.VGPLAA_IMPSEGURADA, VGPLAA_IMPSEGURADA);
                _.Move(VGPLAACES.VGPLAA_CUSTO, VGPLAA_CUSTO);
                _.Move(VGPLAACES.VGPLAA_PREMIO, VGPLAA_PREMIO);
            }

        }

        [StopWatch]
        /*" R3160-00-FETCH-VGPLAACES-DB-CLOSE-1 */
        public void R3160_00_FETCH_VGPLAACES_DB_CLOSE_1()
        {
            /*" -6552- EXEC SQL CLOSE VGPLAACES END-EXEC */

            VGPLAACES.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3160_99_SAIDA*/

        [StopWatch]
        /*" R3170-00-INSERT-VGHISACESSCOB-SECTION */
        private void R3170_00_INSERT_VGHISACESSCOB_SECTION()
        {
            /*" -6566- MOVE 'INSERT VG_HIST_ACESS_COB' TO COMANDO. */
            _.Move("INSERT VG_HIST_ACESS_COB", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6567- MOVE 50 TO SII */
            _.Move(50, WS_HORAS.SII);

            /*" -6568- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -6577- PERFORM R3170_00_INSERT_VGHISACESSCOB_DB_INSERT_1 */

            R3170_00_INSERT_VGHISACESSCOB_DB_INSERT_1();

            /*" -6580- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -6582- IF SQLCODE NOT EQUAL ZEROES AND SQLCODE NOT EQUAL -803 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
            {

                /*" -6584- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -6584- ADD 1 TO AC-I-HISTACESCOB. */
            WORK_AREA.AC_I_HISTACESCOB.Value = WORK_AREA.AC_I_HISTACESCOB + 1;

        }

        [StopWatch]
        /*" R3170-00-INSERT-VGHISACESSCOB-DB-INSERT-1 */
        public void R3170_00_INSERT_VGHISACESSCOB_DB_INSERT_1()
        {
            /*" -6577- EXEC SQL INSERT INTO SEGUROS.VG_HIST_ACESS_COB VALUES (:DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF, 1, :VGPLAA-NUM-ACESSORIO, :VGPLAA-QTD-COBERTURA, :VGPLAA-IMPSEGURADA, :VGPLAA-CUSTO, :VGPLAA-PREMIO) END-EXEC. */

            var r3170_00_INSERT_VGHISACESSCOB_DB_INSERT_1_Insert1 = new R3170_00_INSERT_VGHISACESSCOB_DB_INSERT_1_Insert1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
                VGPLAA_NUM_ACESSORIO = VGPLAA_NUM_ACESSORIO.ToString(),
                VGPLAA_QTD_COBERTURA = VGPLAA_QTD_COBERTURA.ToString(),
                VGPLAA_IMPSEGURADA = VGPLAA_IMPSEGURADA.ToString(),
                VGPLAA_CUSTO = VGPLAA_CUSTO.ToString(),
                VGPLAA_PREMIO = VGPLAA_PREMIO.ToString(),
            };

            R3170_00_INSERT_VGHISACESSCOB_DB_INSERT_1_Insert1.Execute(r3170_00_INSERT_VGHISACESSCOB_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3170_99_FIM*/

        [StopWatch]
        /*" R3200-00-INSERT-OPCAOPAGVA-SECTION */
        private void R3200_00_INSERT_OPCAOPAGVA_SECTION()
        {
            /*" -6600- MOVE PROPOFID-OPCAOPAG OF DCLPROPOSTA-FIDELIZ TO WHOST-OPCAOPAG. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAOPAG, WHOST_OPCAOPAG);

            /*" -6601- IF WHOST-OPCAOPAG EQUAL '3' */

            if (WHOST_OPCAOPAG == "3")
            {

                /*" -6605- MOVE -1 TO VIND-AGECTADEB VIND-OPRCTADEB VIND-NUMCTADEB VIND-DIGCTADEB */
                _.Move(-1, VIND_AGECTADEB, VIND_OPRCTADEB, VIND_NUMCTADEB, VIND_DIGCTADEB);

                /*" -6607- MOVE '5' TO WHOST-OPCAOPAG. */
                _.Move("5", WHOST_OPCAOPAG);
            }


            /*" -6608- IF WHOST-OPCAOPAG EQUAL '1' */

            if (WHOST_OPCAOPAG == "1")
            {

                /*" -6612- MOVE +0 TO VIND-AGECTADEB VIND-OPRCTADEB VIND-NUMCTADEB VIND-DIGCTADEB */
                _.Move(+0, VIND_AGECTADEB, VIND_OPRCTADEB, VIND_NUMCTADEB, VIND_DIGCTADEB);

                /*" -6613- IF PROPOFID-OPRCTADEB OF DCLPROPOSTA-FIDELIZ EQUAL 13 */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTADEB == 13)
                {

                    /*" -6614- MOVE '2' TO WHOST-OPCAOPAG */
                    _.Move("2", WHOST_OPCAOPAG);

                    /*" -6615- END-IF */
                }


                /*" -6616- ELSE */
            }
            else
            {


                /*" -6620- MOVE -1 TO VIND-AGECTADEB VIND-OPRCTADEB VIND-NUMCTADEB VIND-DIGCTADEB */
                _.Move(-1, VIND_AGECTADEB, VIND_OPRCTADEB, VIND_NUMCTADEB, VIND_DIGCTADEB);

                /*" -6622- MOVE '3' TO WHOST-OPCAOPAG. */
                _.Move("3", WHOST_OPCAOPAG);
            }


            /*" -6624- IF PRODUVG-COD-PRODUTO = 7732 OR JVPRD7732 OR 7733 OR JVPRD7733 */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.In("7732", JVBKINCL.JV_PRODUTOS.JVPRD7732.ToString(), "7733", JVBKINCL.JV_PRODUTOS.JVPRD7733.ToString()))
            {

                /*" -6625- MOVE '1' TO WHOST-OPCAOPAG */
                _.Move("1", WHOST_OPCAOPAG);

                /*" -6627- END-IF */
            }


            /*" -6629- IF PRODUVG-COD-PRODUTO = 7732 OR JVPRD7732 OR 7733 OR JVPRD7733 */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.In("7732", JVBKINCL.JV_PRODUTOS.JVPRD7732.ToString(), "7733", JVBKINCL.JV_PRODUTOS.JVPRD7733.ToString()))
            {

                /*" -6630- IF PROPOFID-NUMCTADEB > ZEROS */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTADEB > 00)
                {

                    /*" -6631- MOVE 1 TO VIND-NUMCTADEB */
                    _.Move(1, VIND_NUMCTADEB);

                    /*" -6632- END-IF */
                }


                /*" -6633- IF PROPOFID-AGECTADEB > ZEROS */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTADEB > 00)
                {

                    /*" -6634- MOVE 1 TO VIND-AGECTADEB */
                    _.Move(1, VIND_AGECTADEB);

                    /*" -6635- END-IF */
                }


                /*" -6636- IF PROPOFID-OPRCTADEB > ZEROS */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTADEB > 00)
                {

                    /*" -6637- MOVE 1 TO VIND-OPRCTADEB */
                    _.Move(1, VIND_OPRCTADEB);

                    /*" -6638- END-IF */
                }


                /*" -6639- IF PROPOFID-DIGCTADEB > ZEROS */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTADEB > 00)
                {

                    /*" -6640- MOVE 1 TO VIND-DIGCTADEB */
                    _.Move(1, VIND_DIGCTADEB);

                    /*" -6641- END-IF */
                }


                /*" -6643- END-IF */
            }


            /*" -6646- MOVE '3200-00-INSERT-OPCAOPAGVA  ' TO PARAGRAFO. */
            _.Move("3200-00-INSERT-OPCAOPAGVA  ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6647- MOVE 51 TO SII */
            _.Move(51, WS_HORAS.SII);

            /*" -6648- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -6668- PERFORM R3200_00_INSERT_OPCAOPAGVA_DB_INSERT_1 */

            R3200_00_INSERT_OPCAOPAGVA_DB_INSERT_1();

            /*" -6671- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -6673- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL -803 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
            {

                /*" -6674- DISPLAY 'PROBLEMAS NO INSERT OPCAOPAGVA ' */
                _.Display($"PROBLEMAS NO INSERT OPCAOPAGVA ");

                /*" -6674- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3200-00-INSERT-OPCAOPAGVA-DB-INSERT-1 */
        public void R3200_00_INSERT_OPCAOPAGVA_DB_INSERT_1()
        {
            /*" -6668- EXEC SQL INSERT INTO SEGUROS.OPCAO_PAG_VIDAZUL VALUES (:DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF, :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO, '9999-12-31' , :WHOST-OPCAOPAG, :DCLPRODUTOS-VG.PRODUVG-PERI-PAGAMENTO , :DCLPROPOSTA-FIDELIZ.PROPOFID-DIA-DEBITO, 'VP0601B' , CURRENT TIMESTAMP, :DCLPROPOSTA-FIDELIZ.PROPOFID-AGECTADEB :VIND-AGECTADEB, :DCLPROPOSTA-FIDELIZ.PROPOFID-OPRCTADEB :VIND-OPRCTADEB, :DCLPROPOSTA-FIDELIZ.PROPOFID-NUMCTADEB :VIND-NUMCTADEB, :DCLPROPOSTA-FIDELIZ.PROPOFID-DIGCTADEB :VIND-DIGCTADEB, NULL) END-EXEC. */

            var r3200_00_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1 = new R3200_00_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
                PROPOFID_DTQITBCO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.ToString(),
                WHOST_OPCAOPAG = WHOST_OPCAOPAG.ToString(),
                PRODUVG_PERI_PAGAMENTO = PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO.ToString(),
                PROPOFID_DIA_DEBITO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIA_DEBITO.ToString(),
                PROPOFID_AGECTADEB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTADEB.ToString(),
                VIND_AGECTADEB = VIND_AGECTADEB.ToString(),
                PROPOFID_OPRCTADEB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTADEB.ToString(),
                VIND_OPRCTADEB = VIND_OPRCTADEB.ToString(),
                PROPOFID_NUMCTADEB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTADEB.ToString(),
                VIND_NUMCTADEB = VIND_NUMCTADEB.ToString(),
                PROPOFID_DIGCTADEB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTADEB.ToString(),
                VIND_DIGCTADEB = VIND_DIGCTADEB.ToString(),
            };

            R3200_00_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1.Execute(r3200_00_INSERT_OPCAOPAGVA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/

        [StopWatch]
        /*" R3210-INS-VG-MOVTO-PRET-SECTION */
        private void R3210_INS_VG_MOVTO_PRET_SECTION()
        {
            /*" -6682- INITIALIZE VG096-NUM-CONTA-DEBITO */
            _.Initialize(
                VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_NUM_CONTA_DEBITO
            );

            /*" -6686- PERFORM R3210_INS_VG_MOVTO_PRET_DB_SELECT_1 */

            R3210_INS_VG_MOVTO_PRET_DB_SELECT_1();

            /*" -6689- MOVE WS-DTPROXVEN TO VG096-DTA-PROXIMA-COBRANCA */
            _.Move(WS_DTPROXVEN, VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_DTA_PROXIMA_COBRANCA);

            /*" -6690- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO VG096-NUM-CERTIFICADO */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_NUM_CERTIFICADO);

            /*" -6691- MOVE 1 TO VG096-NUM-PARCELA */
            _.Move(1, VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_NUM_PARCELA);

            /*" -6692- MOVE PROPOFID-DATA-PROPOSTA TO VG096-DTA-VENCIMENTO */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA, VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_DTA_VENCIMENTO);

            /*" -6693- MOVE PROPOFID-VAL-PAGO TO VG096-VLR-PARCELA */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO, VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_VLR_PARCELA);

            /*" -6694- MOVE '0' TO VG096-STA-REGISTRO */
            _.Move("0", VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_STA_REGISTRO);

            /*" -6695- MOVE SPACES TO VG096-COD-IDLG */
            _.Move("", VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_COD_IDLG);

            /*" -6696- MOVE ZEROS TO VG096-COD-RETORNO */
            _.Move(0, VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_COD_RETORNO);

            /*" -6697- MOVE SPACES TO VG096-DES-RETORNO */
            _.Move("", VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_DES_RETORNO);

            /*" -6698- MOVE 6088 TO VG096-COD-CONVENIO */
            _.Move(6088, VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_COD_CONVENIO);

            /*" -6699- MOVE 104 TO VG096-NUM-BANCO-DEBITO */
            _.Move(104, VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_NUM_BANCO_DEBITO);

            /*" -6700- MOVE PROPOFID-AGECTADEB TO VG096-NUM-AGENCIA-DEBITO */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTADEB, VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_NUM_AGENCIA_DEBITO);

            /*" -6701- MOVE PROPOFID-NUMCTADEB TO WS-NUMCTADEB */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTADEB, WS_NUM_CONTA_DEBITO.WS_NUMCTADEB);

            /*" -6702- MOVE PROPOFID-DIGCTADEB TO WS-DIGCTADEB */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTADEB, WS_NUM_CONTA_DEBITO.WS_DIGCTADEB);

            /*" -6703- MOVE WS-NUM-CONTA-DEBITO TO WS-NUM-CONTA-DEBITO2 */
            _.Move(WS_NUM_CONTA_DEBITO, WS_NUM_CONTA_DEBITO2);

            /*" -6704- MOVE WS-NUM-CONTA-DEBITO2 TO VG096-NUM-CONTA-DEBITO */
            _.Move(WS_NUM_CONTA_DEBITO2, VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_NUM_CONTA_DEBITO);

            /*" -6706- MOVE 'VP0601B' TO VG096-NOM-PROGRAMA */
            _.Move("VP0601B", VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_NOM_PROGRAMA);

            /*" -6707- IF VG096-NUM-CONTA-DEBITO < 0 */

            if (VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_NUM_CONTA_DEBITO < 0)
            {

                /*" -6709- COMPUTE VG096-NUM-CONTA-DEBITO = VG096-NUM-CONTA-DEBITO * (-1) */
                VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_NUM_CONTA_DEBITO.Value = VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_NUM_CONTA_DEBITO * (-1);

                /*" -6711- END-IF */
            }


            /*" -6744- PERFORM R3210_INS_VG_MOVTO_PRET_DB_INSERT_1 */

            R3210_INS_VG_MOVTO_PRET_DB_INSERT_1();

            /*" -6747- IF SQLCODE NOT EQUAL ZEROS AND -803 */

            if (!DB.SQLCODE.In("00", "-803"))
            {

                /*" -6748- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_SQLCODE);

                /*" -6749- DISPLAY '------------------------------------------------' */
                _.Display($"------------------------------------------------");

                /*" -6752- DISPLAY 'VP0601B - ERRO INSERT VG_MOVTO_PRESTAMISTA SQLCODE = ' WS-SQLCODE */
                _.Display($"VP0601B - ERRO INSERT VG_MOVTO_PRESTAMISTA SQLCODE = {WS_SQLCODE}");

                /*" -6753- DISPLAY 'NUM_CERTIFICADO    = ' VG096-NUM-CERTIFICADO */
                _.Display($"NUM_CERTIFICADO    = {VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_NUM_CERTIFICADO}");

                /*" -6754- DISPLAY 'NUM_PARCELA        = ' VG096-NUM-PARCELA */
                _.Display($"NUM_PARCELA        = {VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_NUM_PARCELA}");

                /*" -6755- DISPLAY 'DTA_VENCIMENTO     = ' VG096-DTA-VENCIMENTO */
                _.Display($"DTA_VENCIMENTO     = {VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_DTA_VENCIMENTO}");

                /*" -6756- DISPLAY 'VLR_PARCELA        = ' VG096-VLR-PARCELA */
                _.Display($"VLR_PARCELA        = {VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_VLR_PARCELA}");

                /*" -6757- DISPLAY 'STA_REGISTRO       = ' VG096-STA-REGISTRO */
                _.Display($"STA_REGISTRO       = {VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_STA_REGISTRO}");

                /*" -6758- DISPLAY 'COD_IDLG           = ' VG096-COD-IDLG */
                _.Display($"COD_IDLG           = {VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_COD_IDLG}");

                /*" -6759- DISPLAY 'COD_RETORNO        = ' VG096-COD-RETORNO */
                _.Display($"COD_RETORNO        = {VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_COD_RETORNO}");

                /*" -6760- DISPLAY 'DES_RETORNO        = ' VG096-DES-RETORNO */
                _.Display($"DES_RETORNO        = {VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_DES_RETORNO}");

                /*" -6761- DISPLAY 'COD_CONVENIO       = ' VG096-COD-CONVENIO */
                _.Display($"COD_CONVENIO       = {VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_COD_CONVENIO}");

                /*" -6762- DISPLAY 'NUM_BANCO_DEBITO   = ' VG096-NUM-BANCO-DEBITO */
                _.Display($"NUM_BANCO_DEBITO   = {VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_NUM_BANCO_DEBITO}");

                /*" -6763- DISPLAY 'NUM_AGENCIA_DEBITO = ' VG096-NUM-AGENCIA-DEBITO */
                _.Display($"NUM_AGENCIA_DEBITO = {VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_NUM_AGENCIA_DEBITO}");

                /*" -6764- DISPLAY 'NUM_CONTA_DEBITO   = ' VG096-NUM-CONTA-DEBITO */
                _.Display($"NUM_CONTA_DEBITO   = {VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_NUM_CONTA_DEBITO}");

                /*" -6765- DISPLAY 'NOM_PROGRAMA       = ' VG096-NOM-PROGRAMA */
                _.Display($"NOM_PROGRAMA       = {VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_NOM_PROGRAMA}");

                /*" -6766- DISPLAY 'DTA_PROXIMA_COBRANCA= ' VG096-DTA-PROXIMA-COBRANCA */
                _.Display($"DTA_PROXIMA_COBRANCA= {VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_DTA_PROXIMA_COBRANCA}");

                /*" -6767- DISPLAY '------------------------------------------------' */
                _.Display($"------------------------------------------------");

                /*" -6768- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -6768- END-IF. */
            }


        }

        [StopWatch]
        /*" R3210-INS-VG-MOVTO-PRET-DB-SELECT-1 */
        public void R3210_INS_VG_MOVTO_PRET_DB_SELECT_1()
        {
            /*" -6686- EXEC SQL SELECT DATE(:PROPOFID-DATA-PROPOSTA) + 1 MONTH INTO : WS-DTPROXVEN FROM SYSIBM.SYSDUMMY1 END-EXEC */

            /*-- linha suprimida por comandos abaixo EXEC SQL
            /*--SELECT DATE(:PROPOFID-DATA-PROPOSTA) + 1 MONTH
            /*--INTO : WS-DTPROXVEN
            /*--FROM SYSIBM.SYSDUMMY1
            /*--END-EXEC
            /*-- */

            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA.ToDateTime().ToString(_.CurrentDateFormat), WS_DTPROXVEN);

        }

        [StopWatch]
        /*" R3210-INS-VG-MOVTO-PRET-DB-INSERT-1 */
        public void R3210_INS_VG_MOVTO_PRET_DB_INSERT_1()
        {
            /*" -6744- EXEC SQL INSERT INTO SEGUROS.VG_MOVTO_PRESTAMISTA ( NUM_CERTIFICADO ,NUM_PARCELA ,DTA_VENCIMENTO ,VLR_PARCELA ,STA_REGISTRO ,COD_IDLG ,COD_RETORNO ,DES_RETORNO ,COD_CONVENIO ,NUM_BANCO_DEBITO ,NUM_AGENCIA_DEBITO ,NUM_CONTA_DEBITO ,NOM_PROGRAMA ,DTH_ATUALIZACAO ,DTA_PROXIMA_COBRANCA) VALUES ( :VG096-NUM-CERTIFICADO ,:VG096-NUM-PARCELA ,:VG096-DTA-VENCIMENTO ,:VG096-VLR-PARCELA ,:VG096-STA-REGISTRO ,:VG096-COD-IDLG ,:VG096-COD-RETORNO ,:VG096-DES-RETORNO ,:VG096-COD-CONVENIO ,:VG096-NUM-BANCO-DEBITO ,:VG096-NUM-AGENCIA-DEBITO ,:VG096-NUM-CONTA-DEBITO ,:VG096-NOM-PROGRAMA , CURRENT TIMESTAMP ,:VG096-DTA-PROXIMA-COBRANCA) END-EXEC. */

            var r3210_INS_VG_MOVTO_PRET_DB_INSERT_1_Insert1 = new R3210_INS_VG_MOVTO_PRET_DB_INSERT_1_Insert1()
            {
                VG096_NUM_CERTIFICADO = VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_NUM_CERTIFICADO.ToString(),
                VG096_NUM_PARCELA = VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_NUM_PARCELA.ToString(),
                VG096_DTA_VENCIMENTO = VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_DTA_VENCIMENTO.ToString(),
                VG096_VLR_PARCELA = VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_VLR_PARCELA.ToString(),
                VG096_STA_REGISTRO = VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_STA_REGISTRO.ToString(),
                VG096_COD_IDLG = VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_COD_IDLG.ToString(),
                VG096_COD_RETORNO = VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_COD_RETORNO.ToString(),
                VG096_DES_RETORNO = VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_DES_RETORNO.ToString(),
                VG096_COD_CONVENIO = VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_COD_CONVENIO.ToString(),
                VG096_NUM_BANCO_DEBITO = VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_NUM_BANCO_DEBITO.ToString(),
                VG096_NUM_AGENCIA_DEBITO = VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_NUM_AGENCIA_DEBITO.ToString(),
                VG096_NUM_CONTA_DEBITO = VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_NUM_CONTA_DEBITO.ToString(),
                VG096_NOM_PROGRAMA = VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_NOM_PROGRAMA.ToString(),
                VG096_DTA_PROXIMA_COBRANCA = VG096.DCLVG_MOVTO_PRESTAMISTA.VG096_DTA_PROXIMA_COBRANCA.ToString(),
            };

            R3210_INS_VG_MOVTO_PRET_DB_INSERT_1_Insert1.Execute(r3210_INS_VG_MOVTO_PRET_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3210_99_SAIDA*/

        [StopWatch]
        /*" R3300-00-INSERT-COMISICOBVA-SECTION */
        private void R3300_00_INSERT_COMISICOBVA_SECTION()
        {
            /*" -6798- MOVE '0' TO SIT-REGISTRO OF DCLCOMISS-ADIAN-SICOB. */
            _.Move("0", COADSICO.DCLCOMISS_ADIAN_SICOB.SIT_REGISTRO);

            /*" -6799- MOVE ' ' TO SIT-FENAE OF DCLCOMISS-ADIAN-SICOB. */
            _.Move(" ", COADSICO.DCLCOMISS_ADIAN_SICOB.SIT_FENAE);

            /*" -6833- MOVE ZEROS TO VAL-COMISSAO-VEN OF DCLCOMISS-ADIAN-SICOB VAL-ADIANTAMENTO OF DCLCOMISS-ADIAN-SICOB ORDEM-PAGAMENTO OF DCLCOMISS-ADIAN-SICOB NUM-ENDOSSO OF DCLCOMISS-ADIAN-SICOB NUM-MATR-GERENTE OF DCLCOMISS-ADIAN-SICOB COD-AGEN-GERENTE OF DCLCOMISS-ADIAN-SICOB OPE-CONTA-GERENTE OF DCLCOMISS-ADIAN-SICOB NUM-CONTA-GERENTE OF DCLCOMISS-ADIAN-SICOB DIG-CONTA-GERENTE OF DCLCOMISS-ADIAN-SICOB VAL-COMIS-GERENTE OF DCLCOMISS-ADIAN-SICOB NUM-MATR-SUN OF DCLCOMISS-ADIAN-SICOB COD-AGEN-SUN OF DCLCOMISS-ADIAN-SICOB OPE-CONTA-SUN OF DCLCOMISS-ADIAN-SICOB NUM-CONTA-SUN OF DCLCOMISS-ADIAN-SICOB DIG-CONTA-SUN OF DCLCOMISS-ADIAN-SICOB VAL-COMIS-SUN OF DCLCOMISS-ADIAN-SICOB. */
            _.Move(0, COADSICO.DCLCOMISS_ADIAN_SICOB.VAL_COMISSAO_VEN, COADSICO.DCLCOMISS_ADIAN_SICOB.VAL_ADIANTAMENTO, COADSICO.DCLCOMISS_ADIAN_SICOB.ORDEM_PAGAMENTO, COADSICO.DCLCOMISS_ADIAN_SICOB.NUM_ENDOSSO, COADSICO.DCLCOMISS_ADIAN_SICOB.NUM_MATR_GERENTE, COADSICO.DCLCOMISS_ADIAN_SICOB.COD_AGEN_GERENTE, COADSICO.DCLCOMISS_ADIAN_SICOB.OPE_CONTA_GERENTE, COADSICO.DCLCOMISS_ADIAN_SICOB.NUM_CONTA_GERENTE, COADSICO.DCLCOMISS_ADIAN_SICOB.DIG_CONTA_GERENTE, COADSICO.DCLCOMISS_ADIAN_SICOB.VAL_COMIS_GERENTE, COADSICO.DCLCOMISS_ADIAN_SICOB.NUM_MATR_SUN, COADSICO.DCLCOMISS_ADIAN_SICOB.COD_AGEN_SUN, COADSICO.DCLCOMISS_ADIAN_SICOB.OPE_CONTA_SUN, COADSICO.DCLCOMISS_ADIAN_SICOB.NUM_CONTA_SUN, COADSICO.DCLCOMISS_ADIAN_SICOB.DIG_CONTA_SUN, COADSICO.DCLCOMISS_ADIAN_SICOB.VAL_COMIS_SUN);

            /*" -6836- MOVE '3300-00-INSERT-COMISICOBVA ' TO PARAGRAFO. */
            _.Move("3300-00-INSERT-COMISICOBVA ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6837- MOVE 52 TO SII */
            _.Move(52, WS_HORAS.SII);

            /*" -6838- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -6874- PERFORM R3300_00_INSERT_COMISICOBVA_DB_INSERT_1 */

            R3300_00_INSERT_COMISICOBVA_DB_INSERT_1();

            /*" -6877- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -6878- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6879- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -6880- MOVE 'SIM' TO WEXISTE-COMISSAO */
                    _.Move("SIM", WEXISTE_COMISSAO);

                    /*" -6881- ELSE */
                }
                else
                {


                    /*" -6882- DISPLAY 'PROBLEMAS NO INSERT COMISICOBVA ' */
                    _.Display($"PROBLEMAS NO INSERT COMISICOBVA ");

                    /*" -6883- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -6884- ELSE */
                }

            }
            else
            {


                /*" -6884- MOVE 'NAO' TO WEXISTE-COMISSAO. */
                _.Move("NAO", WEXISTE_COMISSAO);
            }


        }

        [StopWatch]
        /*" R3300-00-INSERT-COMISICOBVA-DB-INSERT-1 */
        public void R3300_00_INSERT_COMISICOBVA_DB_INSERT_1()
        {
            /*" -6874- EXEC SQL INSERT INTO SEGUROS.COMISS_ADIAN_SICOB VALUES (:DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF, :WHOST-FONTE, :DCLPROPOSTA-FIDELIZ.PROPOFID-AGECOBR , :DCLRCAPS.RCAPS-VAL-RCAP, :DCLCOMISS-ADIAN-SICOB.VAL-ADIANTAMENTO, :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO, :DCLCOMISS-ADIAN-SICOB.SIT-REGISTRO, :DCLPROPOSTA-FIDELIZ.PROPOFID-AGECTAVEN , :DCLPROPOSTA-FIDELIZ.PROPOFID-OPRCTAVEN , :DCLPROPOSTA-FIDELIZ.PROPOFID-NUMCTAVEN , :DCLPROPOSTA-FIDELIZ.PROPOFID-DIGCTAVEN , :DCLPROPOSTA-FIDELIZ.PROPOFID-NRMATRVEN , :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO, CURRENT TIMESTAMP, :DCLCOMISS-ADIAN-SICOB.SIT-FENAE, :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO, :DCLCOMISS-ADIAN-SICOB.VAL-COMISSAO-VEN, :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE, :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO, :DCLCOMISS-ADIAN-SICOB.ORDEM-PAGAMENTO, :DCLCOMISS-ADIAN-SICOB.NUM-ENDOSSO, :DCLCOMISS-ADIAN-SICOB.NUM-MATR-GERENTE, :DCLCOMISS-ADIAN-SICOB.COD-AGEN-GERENTE, :DCLCOMISS-ADIAN-SICOB.OPE-CONTA-GERENTE, :DCLCOMISS-ADIAN-SICOB.NUM-CONTA-GERENTE, :DCLCOMISS-ADIAN-SICOB.DIG-CONTA-GERENTE, :DCLCOMISS-ADIAN-SICOB.VAL-COMIS-GERENTE, :DCLCOMISS-ADIAN-SICOB.NUM-MATR-SUN, :DCLCOMISS-ADIAN-SICOB.COD-AGEN-SUN, :DCLCOMISS-ADIAN-SICOB.OPE-CONTA-SUN, :DCLCOMISS-ADIAN-SICOB.NUM-CONTA-SUN, :DCLCOMISS-ADIAN-SICOB.DIG-CONTA-SUN, :DCLCOMISS-ADIAN-SICOB.VAL-COMIS-SUN) END-EXEC. */

            var r3300_00_INSERT_COMISICOBVA_DB_INSERT_1_Insert1 = new R3300_00_INSERT_COMISICOBVA_DB_INSERT_1_Insert1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
                WHOST_FONTE = WHOST_FONTE.ToString(),
                PROPOFID_AGECOBR = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR.ToString(),
                RCAPS_VAL_RCAP = RCAPS.DCLRCAPS.RCAPS_VAL_RCAP.ToString(),
                VAL_ADIANTAMENTO = COADSICO.DCLCOMISS_ADIAN_SICOB.VAL_ADIANTAMENTO.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                SIT_REGISTRO = COADSICO.DCLCOMISS_ADIAN_SICOB.SIT_REGISTRO.ToString(),
                PROPOFID_AGECTAVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTAVEN.ToString(),
                PROPOFID_OPRCTAVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTAVEN.ToString(),
                PROPOFID_NUMCTAVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTAVEN.ToString(),
                PROPOFID_DIGCTAVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTAVEN.ToString(),
                PROPOFID_NRMATRVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN.ToString(),
                SIT_FENAE = COADSICO.DCLCOMISS_ADIAN_SICOB.SIT_FENAE.ToString(),
                VAL_COMISSAO_VEN = COADSICO.DCLCOMISS_ADIAN_SICOB.VAL_COMISSAO_VEN.ToString(),
                PROPSSVD_NUM_APOLICE = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.ToString(),
                PROPSSVD_COD_SUBGRUPO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.ToString(),
                ORDEM_PAGAMENTO = COADSICO.DCLCOMISS_ADIAN_SICOB.ORDEM_PAGAMENTO.ToString(),
                NUM_ENDOSSO = COADSICO.DCLCOMISS_ADIAN_SICOB.NUM_ENDOSSO.ToString(),
                NUM_MATR_GERENTE = COADSICO.DCLCOMISS_ADIAN_SICOB.NUM_MATR_GERENTE.ToString(),
                COD_AGEN_GERENTE = COADSICO.DCLCOMISS_ADIAN_SICOB.COD_AGEN_GERENTE.ToString(),
                OPE_CONTA_GERENTE = COADSICO.DCLCOMISS_ADIAN_SICOB.OPE_CONTA_GERENTE.ToString(),
                NUM_CONTA_GERENTE = COADSICO.DCLCOMISS_ADIAN_SICOB.NUM_CONTA_GERENTE.ToString(),
                DIG_CONTA_GERENTE = COADSICO.DCLCOMISS_ADIAN_SICOB.DIG_CONTA_GERENTE.ToString(),
                VAL_COMIS_GERENTE = COADSICO.DCLCOMISS_ADIAN_SICOB.VAL_COMIS_GERENTE.ToString(),
                NUM_MATR_SUN = COADSICO.DCLCOMISS_ADIAN_SICOB.NUM_MATR_SUN.ToString(),
                COD_AGEN_SUN = COADSICO.DCLCOMISS_ADIAN_SICOB.COD_AGEN_SUN.ToString(),
                OPE_CONTA_SUN = COADSICO.DCLCOMISS_ADIAN_SICOB.OPE_CONTA_SUN.ToString(),
                NUM_CONTA_SUN = COADSICO.DCLCOMISS_ADIAN_SICOB.NUM_CONTA_SUN.ToString(),
                DIG_CONTA_SUN = COADSICO.DCLCOMISS_ADIAN_SICOB.DIG_CONTA_SUN.ToString(),
                VAL_COMIS_SUN = COADSICO.DCLCOMISS_ADIAN_SICOB.VAL_COMIS_SUN.ToString(),
            };

            R3300_00_INSERT_COMISICOBVA_DB_INSERT_1_Insert1.Execute(r3300_00_INSERT_COMISICOBVA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3300_99_SAIDA*/

        [StopWatch]
        /*" R3400-00-INSERT-PARCELVA-SECTION */
        private void R3400_00_INSERT_PARCELVA_SECTION()
        {
            /*" -6892- MOVE '1' TO SIT-REGISTRO OF DCLPARCELAS-VIDAZUL. */
            _.Move("1", PARVDZUL.DCLPARCELAS_VIDAZUL.SIT_REGISTRO);

            /*" -6893- MOVE 1 TO NUM-PARCELA OF DCLPARCELAS-VIDAZUL. */
            _.Move(1, PARVDZUL.DCLPARCELAS_VIDAZUL.NUM_PARCELA);

            /*" -6897- MOVE ZEROS TO PREMIO-AP OF DCLPARCELAS-VIDAZUL VLMULTA OF DCLPARCELAS-VIDAZUL OCORR-HISTORICO OF DCLPARCELAS-VIDAZUL. */
            _.Move(0, PARVDZUL.DCLPARCELAS_VIDAZUL.PREMIO_AP, PARVDZUL.DCLPARCELAS_VIDAZUL.VLMULTA, PARVDZUL.DCLPARCELAS_VIDAZUL.OCORR_HISTORICO);

            /*" -6901- MOVE '3400-00-INSERT-PARCELVA    ' TO PARAGRAFO. */
            _.Move("3400-00-INSERT-PARCELVA    ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6902- MOVE 53 TO SII */
            _.Move(53, WS_HORAS.SII);

            /*" -6903- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -6916- PERFORM R3400_00_INSERT_PARCELVA_DB_INSERT_1 */

            R3400_00_INSERT_PARCELVA_DB_INSERT_1();

            /*" -6919- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -6921- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL -803 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
            {

                /*" -6922- DISPLAY 'PROBLEMAS NO INSERT PARCELVA    ' */
                _.Display($"PROBLEMAS NO INSERT PARCELVA    ");

                /*" -6923- DISPLAY '-- INSERT NA TABELA PARCELAS_VIDAZUL--' */
                _.Display($"-- INSERT NA TABELA PARCELAS_VIDAZUL--");

                /*" -6925- DISPLAY 'NUM_CERTIFICADO  = ' PROPOFID-NUM-PROPOSTA-SIVPF */
                _.Display($"NUM_CERTIFICADO  = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -6927- DISPLAY 'NUM_PARCELA      = ' NUM-PARCELA OF DCLPARCELAS-VIDAZUL */
                _.Display($"NUM_PARCELA      = {PARVDZUL.DCLPARCELAS_VIDAZUL.NUM_PARCELA}");

                /*" -6928- DISPLAY 'DATA_VENCIMENTO  = ' PROPOFID-DTQITBCO */
                _.Display($"DATA_VENCIMENTO  = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO}");

                /*" -6929- DISPLAY 'PREMIO_VG        = ' RCAPS-VAL-RCAP */
                _.Display($"PREMIO_VG        = {RCAPS.DCLRCAPS.RCAPS_VAL_RCAP}");

                /*" -6931- DISPLAY 'PREMIO_AP        = ' PREMIO-AP OF DCLPARCELAS-VIDAZUL */
                _.Display($"PREMIO_AP        = {PARVDZUL.DCLPARCELAS_VIDAZUL.PREMIO_AP}");

                /*" -6933- DISPLAY 'VLMULTA          = ' VLMULTA OF DCLPARCELAS-VIDAZUL */
                _.Display($"VLMULTA          = {PARVDZUL.DCLPARCELAS_VIDAZUL.VLMULTA}");

                /*" -6934- DISPLAY 'OPCAO_PAGAMENTO  = ' WHOST-OPCAOPAG */
                _.Display($"OPCAO_PAGAMENTO  = {WHOST_OPCAOPAG}");

                /*" -6936- DISPLAY 'SIT_REGISTRO     = ' SIT-REGISTRO OF DCLPARCELAS-VIDAZUL */
                _.Display($"SIT_REGISTRO     = {PARVDZUL.DCLPARCELAS_VIDAZUL.SIT_REGISTRO}");

                /*" -6938- DISPLAY 'OCORR_HISTORICO  = ' OCORR-HISTORICO OF DCLPARCELAS-VIDAZUL */
                _.Display($"OCORR_HISTORICO  = {PARVDZUL.DCLPARCELAS_VIDAZUL.OCORR_HISTORICO}");

                /*" -6939- DISPLAY 'TIMESTAMP        = CURRENT TIMESTAMP' */
                _.Display($"TIMESTAMP        = CURRENT TIMESTAMP");

                /*" -6940- DISPLAY '--------------------------------------' */
                _.Display($"--------------------------------------");

                /*" -6940- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3400-00-INSERT-PARCELVA-DB-INSERT-1 */
        public void R3400_00_INSERT_PARCELVA_DB_INSERT_1()
        {
            /*" -6916- EXEC SQL INSERT INTO SEGUROS.PARCELAS_VIDAZUL VALUES (:DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF, :DCLPARCELAS-VIDAZUL.NUM-PARCELA, :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO, :DCLRCAPS.RCAPS-VAL-RCAP, :DCLPARCELAS-VIDAZUL.PREMIO-AP, :DCLPARCELAS-VIDAZUL.VLMULTA, :WHOST-OPCAOPAG, :DCLPARCELAS-VIDAZUL.SIT-REGISTRO, :DCLPARCELAS-VIDAZUL.OCORR-HISTORICO, CURRENT TIMESTAMP) END-EXEC. */

            var r3400_00_INSERT_PARCELVA_DB_INSERT_1_Insert1 = new R3400_00_INSERT_PARCELVA_DB_INSERT_1_Insert1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
                NUM_PARCELA = PARVDZUL.DCLPARCELAS_VIDAZUL.NUM_PARCELA.ToString(),
                PROPOFID_DTQITBCO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.ToString(),
                RCAPS_VAL_RCAP = RCAPS.DCLRCAPS.RCAPS_VAL_RCAP.ToString(),
                PREMIO_AP = PARVDZUL.DCLPARCELAS_VIDAZUL.PREMIO_AP.ToString(),
                VLMULTA = PARVDZUL.DCLPARCELAS_VIDAZUL.VLMULTA.ToString(),
                WHOST_OPCAOPAG = WHOST_OPCAOPAG.ToString(),
                SIT_REGISTRO = PARVDZUL.DCLPARCELAS_VIDAZUL.SIT_REGISTRO.ToString(),
                OCORR_HISTORICO = PARVDZUL.DCLPARCELAS_VIDAZUL.OCORR_HISTORICO.ToString(),
            };

            R3400_00_INSERT_PARCELVA_DB_INSERT_1_Insert1.Execute(r3400_00_INSERT_PARCELVA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3400_99_SAIDA*/

        [StopWatch]
        /*" R3500-00-INSERT-HISTCOBVA-SECTION */
        private void R3500_00_INSERT_HISTCOBVA_SECTION()
        {
            /*" -6948- MOVE '1' TO SIT-REGISTRO OF DCLCOBER-HIST-VIDAZUL. */
            _.Move("1", CBHSTZUL.DCLCOBER_HIST_VIDAZUL.SIT_REGISTRO);

            /*" -6949- MOVE 201 TO COD-OPERACAO OF DCLCOBER-HIST-VIDAZUL. */
            _.Move(201, CBHSTZUL.DCLCOBER_HIST_VIDAZUL.COD_OPERACAO);

            /*" -6951- MOVE PROPOFID-NUM-SICOB OF DCLPROPOSTA-FIDELIZ TO NUM-TITULO OF DCLCOBER-HIST-VIDAZUL. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB, CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_TITULO);

            /*" -6953- MOVE 1 TO NUM-PARCELA OF DCLCOBER-HIST-VIDAZUL OCORR-HISTORICO OF DCLCOBER-HIST-VIDAZUL. */
            _.Move(1, CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_PARCELA, CBHSTZUL.DCLCOBER_HIST_VIDAZUL.OCORR_HISTORICO);

            /*" -6956- MOVE ZEROS TO COD-DEVOLUCAO OF DCLCOBER-HIST-VIDAZUL NUM-TITULO-COMP OF DCLCOBER-HIST-VIDAZUL. */
            _.Move(0, CBHSTZUL.DCLCOBER_HIST_VIDAZUL.COD_DEVOLUCAO, CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_TITULO_COMP);

            /*" -6963- MOVE '3500-00-INSERT-HISTCOBVA   ' TO PARAGRAFO. */
            _.Move("3500-00-INSERT-HISTCOBVA   ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6965- MOVE PROPOFID-DTQITBCO TO WS-DATA-QUITACAO */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO, WS_DATA_QUITACAO);

            /*" -6966- MOVE 54 TO SII */
            _.Move(54, WS_HORAS.SII);

            /*" -6967- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -6984- PERFORM R3500_00_INSERT_HISTCOBVA_DB_INSERT_1 */

            R3500_00_INSERT_HISTCOBVA_DB_INSERT_1();

            /*" -6987- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -6989- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL -803 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
            {

                /*" -6990- DISPLAY 'PROBLEMAS NO INSERT HISTCOBVA   ' */
                _.Display($"PROBLEMAS NO INSERT HISTCOBVA   ");

                /*" -6990- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3500-00-INSERT-HISTCOBVA-DB-INSERT-1 */
        public void R3500_00_INSERT_HISTCOBVA_DB_INSERT_1()
        {
            /*" -6984- EXEC SQL INSERT INTO SEGUROS.COBER_HIST_VIDAZUL VALUES (:DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF, :DCLPARCELAS-VIDAZUL.NUM-PARCELA, :DCLCOBER-HIST-VIDAZUL.NUM-TITULO, :WS-DATA-QUITACAO, :DCLRCAPS.RCAPS-VAL-RCAP, :WHOST-OPCAOPAG, :DCLCOBER-HIST-VIDAZUL.SIT-REGISTRO, :DCLCOBER-HIST-VIDAZUL.COD-OPERACAO, :DCLCOBER-HIST-VIDAZUL.OCORR-HISTORICO, :DCLCOBER-HIST-VIDAZUL.COD-DEVOLUCAO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-BCO-AVISO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-AGE-AVISO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-NUM-AVISO-CREDITO, :DCLCOBER-HIST-VIDAZUL.NUM-TITULO-COMP) END-EXEC. */

            var r3500_00_INSERT_HISTCOBVA_DB_INSERT_1_Insert1 = new R3500_00_INSERT_HISTCOBVA_DB_INSERT_1_Insert1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
                NUM_PARCELA = PARVDZUL.DCLPARCELAS_VIDAZUL.NUM_PARCELA.ToString(),
                NUM_TITULO = CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_TITULO.ToString(),
                WS_DATA_QUITACAO = WS_DATA_QUITACAO.ToString(),
                RCAPS_VAL_RCAP = RCAPS.DCLRCAPS.RCAPS_VAL_RCAP.ToString(),
                WHOST_OPCAOPAG = WHOST_OPCAOPAG.ToString(),
                SIT_REGISTRO = CBHSTZUL.DCLCOBER_HIST_VIDAZUL.SIT_REGISTRO.ToString(),
                COD_OPERACAO = CBHSTZUL.DCLCOBER_HIST_VIDAZUL.COD_OPERACAO.ToString(),
                OCORR_HISTORICO = CBHSTZUL.DCLCOBER_HIST_VIDAZUL.OCORR_HISTORICO.ToString(),
                COD_DEVOLUCAO = CBHSTZUL.DCLCOBER_HIST_VIDAZUL.COD_DEVOLUCAO.ToString(),
                RCAPCOMP_BCO_AVISO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO.ToString(),
                RCAPCOMP_AGE_AVISO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO.ToString(),
                RCAPCOMP_NUM_AVISO_CREDITO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO.ToString(),
                NUM_TITULO_COMP = CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_TITULO_COMP.ToString(),
            };

            R3500_00_INSERT_HISTCOBVA_DB_INSERT_1_Insert1.Execute(r3500_00_INSERT_HISTCOBVA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3500_99_SAIDA*/

        [StopWatch]
        /*" R3600-00-INSERT-HISTCONTABILVA-SECTION */
        private void R3600_00_INSERT_HISTCONTABILVA_SECTION()
        {
            /*" -6998- MOVE '0' TO SIT-REGISTRO OF DCLHIST-CONT-PARCELVA. */
            _.Move("0", HTCTBPVA.DCLHIST_CONT_PARCELVA.SIT_REGISTRO);

            /*" -7001- MOVE ZEROS TO NUM-ENDOSSO OF DCLHIST-CONT-PARCELVA PREMIO-AP OF DCLHIST-CONT-PARCELVA. */
            _.Move(0, HTCTBPVA.DCLHIST_CONT_PARCELVA.NUM_ENDOSSO, HTCTBPVA.DCLHIST_CONT_PARCELVA.PREMIO_AP);

            /*" -7002- MOVE 201 TO COD-OPERACAO OF DCLHIST-CONT-PARCELVA. */
            _.Move(201, HTCTBPVA.DCLHIST_CONT_PARCELVA.COD_OPERACAO);

            /*" -7003- MOVE SPACES TO DTFATUR OF DCLHIST-CONT-PARCELVA. */
            _.Move("", HTCTBPVA.DCLHIST_CONT_PARCELVA.DTFATUR);

            /*" -7006- MOVE -1 TO VIND-DTFATUR. */
            _.Move(-1, VIND_DTFATUR);

            /*" -7009- MOVE '3600-00-INSERT-HISTCONTABILVA' TO PARAGRAFO. */
            _.Move("3600-00-INSERT-HISTCONTABILVA", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7010- MOVE 55 TO SII */
            _.Move(55, WS_HORAS.SII);

            /*" -7011- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -7029- PERFORM R3600_00_INSERT_HISTCONTABILVA_DB_INSERT_1 */

            R3600_00_INSERT_HISTCONTABILVA_DB_INSERT_1();

            /*" -7032- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -7034- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL -803 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
            {

                /*" -7035- DISPLAY 'PROBLEMAS NO INSERT HISTCONTABILVA ' */
                _.Display($"PROBLEMAS NO INSERT HISTCONTABILVA ");

                /*" -7035- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3600-00-INSERT-HISTCONTABILVA-DB-INSERT-1 */
        public void R3600_00_INSERT_HISTCONTABILVA_DB_INSERT_1()
        {
            /*" -7029- EXEC SQL INSERT INTO SEGUROS.HIST_CONT_PARCELVA VALUES (:DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF, :DCLPARCELAS-VIDAZUL.NUM-PARCELA, :DCLCOBER-HIST-VIDAZUL.NUM-TITULO, :DCLCOBER-HIST-VIDAZUL.OCORR-HISTORICO, :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE, :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO, :WHOST-FONTE, :DCLHIST-CONT-PARCELVA.NUM-ENDOSSO, :DCLRCAPS.RCAPS-VAL-RCAP, :DCLHIST-CONT-PARCELVA.PREMIO-AP, :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO, :DCLHIST-CONT-PARCELVA.SIT-REGISTRO, :DCLHIST-CONT-PARCELVA.COD-OPERACAO, CURRENT TIMESTAMP, :DCLHIST-CONT-PARCELVA.DTFATUR:VIND-DTFATUR) END-EXEC. */

            var r3600_00_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1 = new R3600_00_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
                NUM_PARCELA = PARVDZUL.DCLPARCELAS_VIDAZUL.NUM_PARCELA.ToString(),
                NUM_TITULO = CBHSTZUL.DCLCOBER_HIST_VIDAZUL.NUM_TITULO.ToString(),
                OCORR_HISTORICO = CBHSTZUL.DCLCOBER_HIST_VIDAZUL.OCORR_HISTORICO.ToString(),
                PROPSSVD_NUM_APOLICE = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.ToString(),
                PROPSSVD_COD_SUBGRUPO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.ToString(),
                WHOST_FONTE = WHOST_FONTE.ToString(),
                NUM_ENDOSSO = HTCTBPVA.DCLHIST_CONT_PARCELVA.NUM_ENDOSSO.ToString(),
                RCAPS_VAL_RCAP = RCAPS.DCLRCAPS.RCAPS_VAL_RCAP.ToString(),
                PREMIO_AP = HTCTBPVA.DCLHIST_CONT_PARCELVA.PREMIO_AP.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                SIT_REGISTRO = HTCTBPVA.DCLHIST_CONT_PARCELVA.SIT_REGISTRO.ToString(),
                COD_OPERACAO = HTCTBPVA.DCLHIST_CONT_PARCELVA.COD_OPERACAO.ToString(),
                DTFATUR = HTCTBPVA.DCLHIST_CONT_PARCELVA.DTFATUR.ToString(),
                VIND_DTFATUR = VIND_DTFATUR.ToString(),
            };

            R3600_00_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1.Execute(r3600_00_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3600_99_SAIDA*/

        [StopWatch]
        /*" R3700-00-INSERT-RELATORIOS-SECTION */
        private void R3700_00_INSERT_RELATORIOS_SECTION()
        {
            /*" -7043- MOVE '3700-00-INSERT-RELATORIOS    ' TO PARAGRAFO. */
            _.Move("3700-00-INSERT-RELATORIOS    ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7045- MOVE '3700-00-SELECT-RELATORIOS    ' TO COMANDO. */
            _.Move("3700-00-SELECT-RELATORIOS    ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7046- IF PROPSSVD-NUM-APOLICE = 107700000056 */

            if (PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE == 107700000056)
            {

                /*" -7047- GO TO R3700-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3700_99_SAIDA*/ //GOTO
                return;

                /*" -7049- END-IF */
            }


            /*" -7051- IF PROPSSVD-NUM-APOLICE = 107700000067 OR PROPSSVD-NUM-APOLICE = 107700000068 */

            if (PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE == 107700000067 || PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE == 107700000068)
            {

                /*" -7052- GO TO R3700-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3700_99_SAIDA*/ //GOTO
                return;

                /*" -7054- END-IF */
            }


            /*" -7055- MOVE 56 TO SII */
            _.Move(56, WS_HORAS.SII);

            /*" -7056- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -7063- PERFORM R3700_00_INSERT_RELATORIOS_DB_SELECT_1 */

            R3700_00_INSERT_RELATORIOS_DB_SELECT_1();

            /*" -7066- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -7067- IF SQLCODE NOT EQUAL ZEROES AND 100 AND -811 */

            if (!DB.SQLCODE.In("00", "100", "-811"))
            {

                /*" -7069- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -7070- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -7071- GO TO R3700-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3700_99_SAIDA*/ //GOTO
                return;

                /*" -7072- ELSE */
            }
            else
            {


                /*" -7074- IF SQLCODE EQUAL 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -7075- ELSE */
                }
                else
                {


                    /*" -7076- IF SQLCODE EQUAL -811 */

                    if (DB.SQLCODE == -811)
                    {

                        /*" -7077- MOVE '3700-00-UPDATE-RELATORIOS    ' TO COMANDO */
                        _.Move("3700-00-UPDATE-RELATORIOS    ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

                        /*" -7078- MOVE 57 TO SII */
                        _.Move(57, WS_HORAS.SII);

                        /*" -7079- PERFORM R9000-00-INICIO */

                        R9000_00_INICIO_SECTION();

                        /*" -7086- PERFORM R3700_00_INSERT_RELATORIOS_DB_UPDATE_1 */

                        R3700_00_INSERT_RELATORIOS_DB_UPDATE_1();

                        /*" -7088- PERFORM R9100-00-TERMINO */

                        R9100_00_TERMINO_SECTION();

                        /*" -7089- IF SQLCODE NOT EQUAL ZEROES */

                        if (DB.SQLCODE != 00)
                        {

                            /*" -7091- GO TO R9999-00-ROT-ERRO. */

                            R9999_00_ROT_ERRO_SECTION(); //GOTO
                            return;
                        }

                    }

                }

            }


            /*" -7092- MOVE '3700-00-INSERT-RELATORIOS    ' TO COMANDO */
            _.Move("3700-00-INSERT-RELATORIOS    ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7093- MOVE 58 TO SII */
            _.Move(58, WS_HORAS.SII);

            /*" -7094- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -7137- PERFORM R3700_00_INSERT_RELATORIOS_DB_INSERT_1 */

            R3700_00_INSERT_RELATORIOS_DB_INSERT_1();

            /*" -7140- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -7141- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -7142- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3700-00-INSERT-RELATORIOS-DB-SELECT-1 */
        public void R3700_00_INSERT_RELATORIOS_DB_SELECT_1()
        {
            /*" -7063- EXEC SQL SELECT COD_USUARIO INTO :RELATORI-COD-USUARIO FROM SEGUROS.RELATORIOS WHERE NUM_CERTIFICADO = :PROPOFID-NUM-PROPOSTA-SIVPF AND COD_RELATORIO = 'VA0469B' AND SIT_REGISTRO = '0' END-EXEC */

            var r3700_00_INSERT_RELATORIOS_DB_SELECT_1_Query1 = new R3700_00_INSERT_RELATORIOS_DB_SELECT_1_Query1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = R3700_00_INSERT_RELATORIOS_DB_SELECT_1_Query1.Execute(r3700_00_INSERT_RELATORIOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RELATORI_COD_USUARIO, RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO);
            }


        }

        [StopWatch]
        /*" R3700-00-INSERT-RELATORIOS-DB-UPDATE-1 */
        public void R3700_00_INSERT_RELATORIOS_DB_UPDATE_1()
        {
            /*" -7086- EXEC SQL UPDATE SEGUROS.RELATORIOS SET SIT_REGISTRO = '1' WHERE NUM_CERTIFICADO = :PROPOFID-NUM-PROPOSTA-SIVPF AND COD_RELATORIO = 'VA0469B' AND SIT_REGISTRO = '0' END-EXEC */

            var r3700_00_INSERT_RELATORIOS_DB_UPDATE_1_Update1 = new R3700_00_INSERT_RELATORIOS_DB_UPDATE_1_Update1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            R3700_00_INSERT_RELATORIOS_DB_UPDATE_1_Update1.Execute(r3700_00_INSERT_RELATORIOS_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R3700-00-INSERT-RELATORIOS-DB-INSERT-1 */
        public void R3700_00_INSERT_RELATORIOS_DB_INSERT_1()
        {
            /*" -7137- EXEC SQL INSERT INTO SEGUROS.RELATORIOS VALUES ( 'VP0601B' , :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO, 'VA' , 'VA0469B' , 0, 0, :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO, :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO, :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO, 0, 0, 0, 0, 0, 0, 0, 0, :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE, 0, 1, :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF, 0, :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO, 16, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '0' , ' ' , ' ' , NULL, 0, 0, CURRENT TIMESTAMP) END-EXEC. */

            var r3700_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1 = new R3700_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                PROPSSVD_NUM_APOLICE = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.ToString(),
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
                PROPSSVD_COD_SUBGRUPO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.ToString(),
            };

            R3700_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1.Execute(r3700_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3700_99_SAIDA*/

        [StopWatch]
        /*" R1110-00-INSERT-PROPOSTA-VA-SECTION */
        private void R1110_00_INSERT_PROPOSTA_VA_SECTION()
        {
            /*" -7148- MOVE '1' TO WHOST-SIT-REGISTRO */
            _.Move("1", WHOST_SIT_REGISTRO);

            /*" -7150- MOVE PROPOFID-DTQITBCO OF DCLPROPOSTA-FIDELIZ TO WHOST-DTPROXVEN */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO, WHOST_DTPROXVEN);

            /*" -7153- IF PRODUVG-COD-PRODUTO = 7725 OR JVPRD7725 OR 7732 OR JVPRD7732 OR 7733 OR JVPRD7733 */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.In("7725", JVBKINCL.JV_PRODUTOS.JVPRD7725.ToString(), "7732", JVBKINCL.JV_PRODUTOS.JVPRD7732.ToString(), "7733", JVBKINCL.JV_PRODUTOS.JVPRD7733.ToString()))
            {

                /*" -7154- MOVE 18 TO WHOST-IDADE */
                _.Move(18, WHOST_IDADE);

                /*" -7156- END-IF */
            }


            /*" -7158- IF PRODUVG-COD-PRODUTO = 7732 OR JVPRD7732 OR 7733 OR JVPRD7733 */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.In("7732", JVBKINCL.JV_PRODUTOS.JVPRD7732.ToString(), "7733", JVBKINCL.JV_PRODUTOS.JVPRD7733.ToString()))
            {

                /*" -7162- PERFORM R1110_00_INSERT_PROPOSTA_VA_DB_SELECT_1 */

                R1110_00_INSERT_PROPOSTA_VA_DB_SELECT_1();

                /*" -7164- MOVE '9999-12-31' TO WHOST-DTPROXVEN */
                _.Move("9999-12-31", WHOST_DTPROXVEN);

                /*" -7166- END-IF */
            }


            /*" -7295- PERFORM R1110_00_INSERT_PROPOSTA_VA_DB_INSERT_1 */

            R1110_00_INSERT_PROPOSTA_VA_DB_INSERT_1();

            /*" -7298- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -7300- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL -803 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
            {

                /*" -7301- DISPLAY 'PROBLEMAS NO INSERT PROPOSTAVA ERROS' */
                _.Display($"PROBLEMAS NO INSERT PROPOSTAVA ERROS");

                /*" -7303- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -7305- ADD 1 TO AC-I-PROPOSTAVA. */
            WORK_AREA.AC_I_PROPOSTAVA.Value = WORK_AREA.AC_I_PROPOSTAVA + 1;

            /*" -7307- IF PRODUVG-COD-PRODUTO = 7732 OR JVPRD7732 OR 7733 OR JVPRD7733 */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.In("7732", JVBKINCL.JV_PRODUTOS.JVPRD7732.ToString(), "7733", JVBKINCL.JV_PRODUTOS.JVPRD7733.ToString()))
            {

                /*" -7308- PERFORM R3210-INS-VG-MOVTO-PRET */

                R3210_INS_VG_MOVTO_PRET_SECTION();

                /*" -7308- END-IF. */
            }


        }

        [StopWatch]
        /*" R1110-00-INSERT-PROPOSTA-VA-DB-SELECT-1 */
        public void R1110_00_INSERT_PROPOSTA_VA_DB_SELECT_1()
        {
            /*" -7162- EXEC SQL SELECT DATE(:PROPOFID-DATA-PROPOSTA) + 1 MONTH INTO : WS-DTPROXVEN FROM SYSIBM.SYSDUMMY1 END-EXEC */

            /*-- linha suprimida por comandos abaixo EXEC SQL
            /*--SELECT DATE(:PROPOFID-DATA-PROPOSTA) + 1 MONTH
            /*--INTO : WS-DTPROXVEN
            /*--FROM SYSIBM.SYSDUMMY1
            /*--END-EXEC
            /*-- */

            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA.ToDateTime().ToString(_.CurrentDateFormat), WS_DTPROXVEN);

        }

        [StopWatch]
        /*" R1110-00-INSERT-PROPOSTA-VA-DB-INSERT-1 */
        public void R1110_00_INSERT_PROPOSTA_VA_DB_INSERT_1()
        {
            /*" -7295- EXEC SQL INSERT INTO SEGUROS.PROPOSTAS_VA ( NUM_CERTIFICADO , COD_PRODUTO , COD_CLIENTE , OCOREND , COD_FONTE , AGE_COBRANCA , OPCAO_COBERTURA , DATA_QUITACAO , COD_AGE_VENDEDOR , OPE_CONTA_VENDEDOR , NUM_CONTA_VENDEDOR , DIG_CONTA_VENDEDOR , NUM_MATRI_VENDEDOR , COD_OPERACAO , PROFISSAO , DTINCLUS , DATA_MOVIMENTO , SIT_REGISTRO , NUM_APOLICE , COD_SUBGRUPO , OCORR_HISTORICO , NRPRIPARATZ , QTDPARATZ , DTPROXVEN , NUM_PARCELA , DATA_VENCIMENTO , SIT_INTERFACE , DTFENAE , COD_USUARIO , TIMESTAMP , IDADE , IDE_SEXO , ESTADO_CIVIL , OPCAO_MARCADA , SIGLA_CRM , COD_CRM , APOS_INVALIDEZ , ASSINATURA , ACATAMENTO , NOME_ESPOSA , DTNASC_ESPOSA , PROFIS_ESPOSA , DPS_TITULAR , DPS_ESPOSA , NUM_MATRICULA , GRAU_PARENTESCO , DATA_ADMISSAO , NUM_PROPOSTA , EM_ATIVIDADE , LOC_ATIVIDADE , INFO_COMPLEMENTAR , NRMALADIR , NRCERTIFANT , COD_CCT , FAIXA_RENDA_IND , FAIXA_RENDA_FAM , NUM_CONTR_VINCULO , COD_CORRESP_BANC , COD_ORIGEM_PROPOSTA , NUM_PRAZO_FIN , COD_OPER_CREDITO ) VALUES (:DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF , :DCLPRODUTOS-VG.PRODUVG-COD-PRODUTO , :DCLCLIENTES.COD-CLIENTE , :DCLENDERECOS.ENDERECO-OCORR-ENDERECO , :WHOST-FONTE , :DCLPROPOSTA-FIDELIZ.PROPOFID-AGECOBR , :DCLPROPOSTA-FIDELIZ.PROPOFID-OPCAO-COBER , :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO , :DCLPROPOSTA-FIDELIZ.PROPOFID-AGECTAVEN , :DCLPROPOSTA-FIDELIZ.PROPOFID-OPRCTAVEN , :DCLPROPOSTA-FIDELIZ.PROPOFID-NUMCTAVEN , :DCLPROPOSTA-FIDELIZ.PROPOFID-DIGCTAVEN , :DCLPROPOSTA-FIDELIZ.PROPOFID-NRMATRVEN , 106 , :WHOST-PROFISSAO , :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO , :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO , :WHOST-SIT-REGISTRO , :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE , :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO , 1 , 0 , 0 , :WHOST-DTPROXVEN , 1 , :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO , '0' , :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO, 'VP0601B' , CURRENT TIMESTAMP, :WHOST-IDADE, :DCLPESSOA-FISICA.SEXO, :DCLPESSOA-FISICA.ESTADO-CIVIL, NULL, NULL, NULL, :DCLPROP-SASSE-VIDA.PROPSSVD-APOS-INVALIDEZ , ' ' , ' ' , :DCLPROPOSTA-FIDELIZ.PROPOFID-NOME-CONJUGE :VIND-NOME-CONJUGE, :DCLPROPOSTA-FIDELIZ.PROPOFID-DATA-NASC-CONJUGE :VIND-DATA-NASC-CONJUGE, :WHOST-PROFISSAO-CONJUGE :VIND-PROFISSAO-CONJUGE, :DCLPROP-SASSE-VIDA.PROPSSVD-DPS-TITULAR , :DCLPROP-SASSE-VIDA.PROPSSVD-DPS-CONJUGE , NULL, NULL, NULL, NULL, NULL, NULL, :WHOST-INFO-COMPL, NULL, NULL, :DCLPROPOSTA-FIDELIZ.PROPOFID-CGC-CONVENENTE :VIND-CGC-CONVENENTE, :DCLPROPOSTA-FIDELIZ.PROPOFID-FAIXA-RENDA-IND, :DCLPROPOSTA-FIDELIZ.PROPOFID-FAIXA-RENDA-FAM, :PROPSSVD-NUM-CONTR-VINCULO :VIND-NUM-CONTR , :PROPSSVD-COD-CORRESP-BANC :VIND-COD-CORRESP , :DCLPROPOSTA-FIDELIZ.PROPOFID-ORIGEM-PROPOSTA , :PROPSSVD-NUM-PRAZO-FIN :VIND-NUM-PRAZO , :PROPSSVD-COD-OPER-CREDITO :VIND-COD-OPER-CRED ) END-EXEC. */

            var r1110_00_INSERT_PROPOSTA_VA_DB_INSERT_1_Insert1 = new R1110_00_INSERT_PROPOSTA_VA_DB_INSERT_1_Insert1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
                PRODUVG_COD_PRODUTO = PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.ToString(),
                COD_CLIENTE = CLIENTE.DCLCLIENTES.COD_CLIENTE.ToString(),
                ENDERECO_OCORR_ENDERECO = ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO.ToString(),
                WHOST_FONTE = WHOST_FONTE.ToString(),
                PROPOFID_AGECOBR = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR.ToString(),
                PROPOFID_OPCAO_COBER = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER.ToString(),
                PROPOFID_DTQITBCO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.ToString(),
                PROPOFID_AGECTAVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTAVEN.ToString(),
                PROPOFID_OPRCTAVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTAVEN.ToString(),
                PROPOFID_NUMCTAVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTAVEN.ToString(),
                PROPOFID_DIGCTAVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTAVEN.ToString(),
                PROPOFID_NRMATRVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN.ToString(),
                WHOST_PROFISSAO = WHOST_PROFISSAO.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                WHOST_SIT_REGISTRO = WHOST_SIT_REGISTRO.ToString(),
                PROPSSVD_NUM_APOLICE = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.ToString(),
                PROPSSVD_COD_SUBGRUPO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.ToString(),
                WHOST_DTPROXVEN = WHOST_DTPROXVEN.ToString(),
                WHOST_IDADE = WHOST_IDADE.ToString(),
                SEXO = PESFIS.DCLPESSOA_FISICA.SEXO.ToString(),
                ESTADO_CIVIL = PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL.ToString(),
                PROPSSVD_APOS_INVALIDEZ = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_APOS_INVALIDEZ.ToString(),
                PROPOFID_NOME_CONJUGE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NOME_CONJUGE.ToString(),
                VIND_NOME_CONJUGE = VIND_NOME_CONJUGE.ToString(),
                PROPOFID_DATA_NASC_CONJUGE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_NASC_CONJUGE.ToString(),
                VIND_DATA_NASC_CONJUGE = VIND_DATA_NASC_CONJUGE.ToString(),
                WHOST_PROFISSAO_CONJUGE = WHOST_PROFISSAO_CONJUGE.ToString(),
                VIND_PROFISSAO_CONJUGE = VIND_PROFISSAO_CONJUGE.ToString(),
                PROPSSVD_DPS_TITULAR = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_TITULAR.ToString(),
                PROPSSVD_DPS_CONJUGE = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_CONJUGE.ToString(),
                WHOST_INFO_COMPL = WHOST_INFO_COMPL.ToString(),
                PROPOFID_CGC_CONVENENTE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CGC_CONVENENTE.ToString(),
                VIND_CGC_CONVENENTE = VIND_CGC_CONVENENTE.ToString(),
                PROPOFID_FAIXA_RENDA_IND = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_IND.ToString(),
                PROPOFID_FAIXA_RENDA_FAM = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_FAM.ToString(),
                PROPSSVD_NUM_CONTR_VINCULO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_CONTR_VINCULO.ToString(),
                VIND_NUM_CONTR = VIND_NUM_CONTR.ToString(),
                PROPSSVD_COD_CORRESP_BANC = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_CORRESP_BANC.ToString(),
                VIND_COD_CORRESP = VIND_COD_CORRESP.ToString(),
                PROPOFID_ORIGEM_PROPOSTA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA.ToString(),
                PROPSSVD_NUM_PRAZO_FIN = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_PRAZO_FIN.ToString(),
                VIND_NUM_PRAZO = VIND_NUM_PRAZO.ToString(),
                PROPSSVD_COD_OPER_CREDITO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_OPER_CREDITO.ToString(),
                VIND_COD_OPER_CRED = VIND_COD_OPER_CRED.ToString(),
            };

            R1110_00_INSERT_PROPOSTA_VA_DB_INSERT_1_Insert1.Execute(r1110_00_INSERT_PROPOSTA_VA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_99_SAIDA*/

        [StopWatch]
        /*" R4000-CALCULO-IS-7707-CDC-SECTION */
        private void R4000_CALCULO_IS_7707_CDC_SECTION()
        {
            /*" -7315- MOVE 'R4000-CALCULO-IS-7707-CDC' TO PARAGRAFO. */
            _.Move("R4000-CALCULO-IS-7707-CDC", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7316- MOVE ZEROS TO WS-VALOR-IS */
            _.Move(0, WS_VALOR_IS);

            /*" -7318- MOVE ZEROS TO WS-VALOR-IS-CDC */
            _.Move(0, WS_VALOR_IS_CDC);

            /*" -7321- COMPUTE WS-VALOR-IS = (RCAPS-VAL-RCAP OF DCLRCAPS * 100) / TAXAVG OF DCLPLANOS-VA-VGAP */
            WS_VALOR_IS.Value = (RCAPS.DCLRCAPS.RCAPS_VAL_RCAP * 100) / PLVAVGAP.DCLPLANOS_VA_VGAP.TAXAVG;

            /*" -7324- MOVE WS-VALOR-IS TO WS-VALOR-IS-CDC */
            _.Move(WS_VALOR_IS, WS_VALOR_IS_CDC);

            /*" -7325- IF WS-VALOR-IS > 2000000,00 */

            if (WS_VALOR_IS > 2000000.00)
            {

                /*" -7326- MOVE PRODUVG-COD-PRODUTO TO GE400-COD-PRODUTO */
                _.Move(PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO, GE400.DCLGE_IS_SUPERIOR.GE400_COD_PRODUTO);

                /*" -7327- MOVE PROPSSVD-NUM-APOLICE TO GE400-NUM-APOLICE */
                _.Move(PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE, GE400.DCLGE_IS_SUPERIOR.GE400_NUM_APOLICE);

                /*" -7329- MOVE CPF OF DCLPESSOA-FISICA TO GE400-NUM-CPF */
                _.Move(PESFIS.DCLPESSOA_FISICA.CPF, GE400.DCLGE_IS_SUPERIOR.GE400_NUM_CPF);

                /*" -7331- PERFORM R1111-00-TRATAR-VR-IS-SUPERIOR */

                R1111_00_TRATAR_VR_IS_SUPERIOR_SECTION();

                /*" -7332- IF WS-CADASTRO-IS-SUPERIOR = ZEROS */

                if (WS_CADASTRO_IS_SUPERIOR == 00)
                {

                    /*" -7334- DISPLAY '-------------------------------------------------' */
                    _.Display($"-------------------------------------------------");

                    /*" -7336- DISPLAY 'VALOR DA IMPORTANCIA SEGURADA ACIMA DO PERMITIDO.' */
                    _.Display($"VALOR DA IMPORTANCIA SEGURADA ACIMA DO PERMITIDO.");

                    /*" -7337- DISPLAY 'NUM-APOLICE     = ' GE400-NUM-APOLICE */
                    _.Display($"NUM-APOLICE     = {GE400.DCLGE_IS_SUPERIOR.GE400_NUM_APOLICE}");

                    /*" -7338- DISPLAY 'COD-PRODUTO     = ' GE400-COD-PRODUTO */
                    _.Display($"COD-PRODUTO     = {GE400.DCLGE_IS_SUPERIOR.GE400_COD_PRODUTO}");

                    /*" -7339- DISPLAY 'CPF DO SEGURADO = ' GE400-NUM-CPF */
                    _.Display($"CPF DO SEGURADO = {GE400.DCLGE_IS_SUPERIOR.GE400_NUM_CPF}");

                    /*" -7341- DISPLAY 'VALOR DA IMPORTANCIA SEGURADA = ' WS-VALOR-IS */
                    _.Display($"VALOR DA IMPORTANCIA SEGURADA = {WS_VALOR_IS}");

                    /*" -7343- DISPLAY 'PROPOSTA ---------> ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"PROPOSTA ---------> {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -7345- DISPLAY '-------------------------------------------------' */
                    _.Display($"-------------------------------------------------");

                    /*" -7346- MOVE 1855 TO COD-ERRO OF DCLERROS-PROP-VIDAZUL */
                    _.Move(1855, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

                    /*" -7347- PERFORM R1100-00-INSERT-ERROSPROPVA */

                    R1100_00_INSERT_ERROSPROPVA_SECTION();

                    /*" -7348- MOVE 'SIM' TO WS-TEM-ERRO-1855 */
                    _.Move("SIM", WORK_AREA.WS_TEM_ERRO_1855);

                    /*" -7349- PERFORM R3700-00-INSERT-RELATORIOS */

                    R3700_00_INSERT_RELATORIOS_SECTION();

                    /*" -7350- END-IF */
                }


                /*" -7350- . */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R5632-00-SELECT-PROPOSTAVA-SECTION */
        private void R5632_00_SELECT_PROPOSTAVA_SECTION()
        {
            /*" -7358- MOVE 'R5632-00-SELECT-PROPOSTAVA  ' TO PARAGRAFO. */
            _.Move("R5632-00-SELECT-PROPOSTAVA  ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7362- MOVE 'SELECT SEGUROS.PROPOSTAS-VA  ' TO COMANDO. */
            _.Move("SELECT SEGUROS.PROPOSTAS-VA  ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7365- MOVE PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO NUM-CERTIFICADO OF DCLPROPOSTAS-VA. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO);

            /*" -7366- MOVE 59 TO SII */
            _.Move(59, WS_HORAS.SII);

            /*" -7367- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -7372- PERFORM R5632_00_SELECT_PROPOSTAVA_DB_SELECT_1 */

            R5632_00_SELECT_PROPOSTAVA_DB_SELECT_1();

            /*" -7375- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -7376- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -7380- MOVE 'SIM' TO WEXISTE-PRPVA */
                _.Move("SIM", WEXISTE_PRPVA);

                /*" -7381- ELSE */
            }
            else
            {


                /*" -7381- MOVE 'NAO' TO WEXISTE-PRPVA. */
                _.Move("NAO", WEXISTE_PRPVA);
            }


        }

        [StopWatch]
        /*" R5632-00-SELECT-PROPOSTAVA-DB-SELECT-1 */
        public void R5632_00_SELECT_PROPOSTAVA_DB_SELECT_1()
        {
            /*" -7372- EXEC SQL SELECT SIT_REGISTRO INTO :DCLPROPOSTAS-VA.SIT-REGISTRO FROM SEGUROS.PROPOSTAS_VA WHERE NUM_CERTIFICADO = :DCLPROPOSTAS-VA.NUM-CERTIFICADO END-EXEC. */

            var r5632_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1 = new R5632_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1()
            {
                NUM_CERTIFICADO = PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R5632_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1.Execute(r5632_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SIT_REGISTRO, PROPVA.DCLPROPOSTAS_VA.SIT_REGISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5632_99_SAIDA*/

        [StopWatch]
        /*" R5633-00-UPDATE-PRP-FIDELIZ-SECTION */
        private void R5633_00_UPDATE_PRP_FIDELIZ_SECTION()
        {
            /*" -7394- MOVE 'R5633-00-UPDATE-PRP-FIDELIZ   ' TO PARAGRAFO. */
            _.Move("R5633-00-UPDATE-PRP-FIDELIZ   ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7395- IF SIT-REGISTRO OF DCLPROPOSTAS-VA EQUAL '0' */

            if (PROPVA.DCLPROPOSTAS_VA.SIT_REGISTRO == "0")
            {

                /*" -7396- MOVE 'PAI' TO WHOST-SIT-PROPOSTA */
                _.Move("PAI", WHOST_SIT_PROPOSTA);

                /*" -7397- MOVE ' ' TO WHOST-SIT-ENVIO */
                _.Move(" ", WHOST_SIT_ENVIO);

                /*" -7398- ELSE */
            }
            else
            {


                /*" -7399- MOVE 'S' TO WHOST-SIT-ENVIO */
                _.Move("S", WHOST_SIT_ENVIO);

                /*" -7400- IF NOT RCAP-CADASTRADO */

                if (!WORK_AREA.W_RCAPS["RCAP_CADASTRADO"])
                {

                    /*" -7401- MOVE 'POB' TO WHOST-SIT-PROPOSTA */
                    _.Move("POB", WHOST_SIT_PROPOSTA);

                    /*" -7402- ELSE */
                }
                else
                {


                    /*" -7403- IF SIT-REGISTRO OF DCLPROPOSTAS-VA EQUAL '1' */

                    if (PROPVA.DCLPROPOSTAS_VA.SIT_REGISTRO == "1")
                    {

                        /*" -7404- MOVE 'PEN' TO WHOST-SIT-PROPOSTA */
                        _.Move("PEN", WHOST_SIT_PROPOSTA);

                        /*" -7405- ELSE */
                    }
                    else
                    {


                        /*" -7406- IF SIT-REGISTRO OF DCLPROPOSTAS-VA EQUAL '3' */

                        if (PROPVA.DCLPROPOSTAS_VA.SIT_REGISTRO == "3")
                        {

                            /*" -7407- MOVE 'EMT' TO WHOST-SIT-PROPOSTA */
                            _.Move("EMT", WHOST_SIT_PROPOSTA);

                            /*" -7408- ELSE */
                        }
                        else
                        {


                            /*" -7409- IF SIT-REGISTRO OF DCLPROPOSTAS-VA EQUAL '5' */

                            if (PROPVA.DCLPROPOSTAS_VA.SIT_REGISTRO == "5")
                            {

                                /*" -7410- MOVE 'POB' TO WHOST-SIT-PROPOSTA */
                                _.Move("POB", WHOST_SIT_PROPOSTA);

                                /*" -7411- ELSE */
                            }
                            else
                            {


                                /*" -7413- MOVE 'EMT' TO WHOST-SIT-PROPOSTA. */
                                _.Move("EMT", WHOST_SIT_PROPOSTA);
                            }

                        }

                    }

                }

            }


            /*" -7414- MOVE 60 TO SII */
            _.Move(60, WS_HORAS.SII);

            /*" -7415- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -7421- PERFORM R5633_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1 */

            R5633_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1();

            /*" -7424- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -7425- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7427- DISPLAY 'PROBLEMAS NO UPDATE DA PROPFID  - R5633  ' SQLCODE */
                _.Display($"PROBLEMAS NO UPDATE DA PROPFID  - R5633  {DB.SQLCODE}");

                /*" -7427- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R5633-00-UPDATE-PRP-FIDELIZ-DB-UPDATE-1 */
        public void R5633_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1()
        {
            /*" -7421- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET SIT_PROPOSTA = :WHOST-SIT-PROPOSTA, SITUACAO_ENVIO = :WHOST-SIT-ENVIO WHERE NUM_PROPOSTA_SIVPF = :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF END-EXEC. */

            var r5633_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1 = new R5633_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1()
            {
                WHOST_SIT_PROPOSTA = WHOST_SIT_PROPOSTA.ToString(),
                WHOST_SIT_ENVIO = WHOST_SIT_ENVIO.ToString(),
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            R5633_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1.Execute(r5633_00_UPDATE_PRP_FIDELIZ_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5633_99_SAIDA*/

        [StopWatch]
        /*" R5634-00-SELECT-SEGUROS-PF-CBO-SECTION */
        private void R5634_00_SELECT_SEGUROS_PF_CBO_SECTION()
        {
            /*" -7436- MOVE 'R5634-00-SELECT-SEGUROS-PF-CBO     ' TO PARAGRAFO. */
            _.Move("R5634-00-SELECT-SEGUROS-PF-CBO     ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7440- MOVE 'SELECT SEGUROS.PF_CBO              ' TO COMANDO. */
            _.Move("SELECT SEGUROS.PF_CBO              ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7443- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO PF062-NUM-PROPOSTA-SIVPF */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, PF062.DCLPF_CBO.PF062_NUM_PROPOSTA_SIVPF);

            /*" -7444- MOVE 61 TO SII */
            _.Move(61, WS_HORAS.SII);

            /*" -7445- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -7450- PERFORM R5634_00_SELECT_SEGUROS_PF_CBO_DB_SELECT_1 */

            R5634_00_SELECT_SEGUROS_PF_CBO_DB_SELECT_1();

            /*" -7453- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -7454- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -7455- MOVE PF062-DES-CBO TO WHOST-PROFISSAO */
                _.Move(PF062.DCLPF_CBO.PF062_DES_CBO, WHOST_PROFISSAO);

                /*" -7456- ELSE */
            }
            else
            {


                /*" -7457- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -7458- MOVE SPACES TO WHOST-PROFISSAO */
                    _.Move("", WHOST_PROFISSAO);

                    /*" -7459- ELSE */
                }
                else
                {


                    /*" -7460- DISPLAY 'PROBLEMAS NO ACESSO A PF-CBO ' */
                    _.Display($"PROBLEMAS NO ACESSO A PF-CBO ");

                    /*" -7461- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R5634-00-SELECT-SEGUROS-PF-CBO-DB-SELECT-1 */
        public void R5634_00_SELECT_SEGUROS_PF_CBO_DB_SELECT_1()
        {
            /*" -7450- EXEC SQL SELECT DES_CBO INTO :PF062-DES-CBO FROM SEGUROS.PF_CBO WHERE NUM_PROPOSTA_SIVPF = :PF062-NUM-PROPOSTA-SIVPF END-EXEC. */

            var r5634_00_SELECT_SEGUROS_PF_CBO_DB_SELECT_1_Query1 = new R5634_00_SELECT_SEGUROS_PF_CBO_DB_SELECT_1_Query1()
            {
                PF062_NUM_PROPOSTA_SIVPF = PF062.DCLPF_CBO.PF062_NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = R5634_00_SELECT_SEGUROS_PF_CBO_DB_SELECT_1_Query1.Execute(r5634_00_SELECT_SEGUROS_PF_CBO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PF062_DES_CBO, PF062.DCLPF_CBO.PF062_DES_CBO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5634_99_SAIDA*/

        [StopWatch]
        /*" R5635-00-UPDATE-PROPOSTAVA-SECTION */
        private void R5635_00_UPDATE_PROPOSTAVA_SECTION()
        {
            /*" -7474- MOVE PROPOFID-DTQITBCO OF DCLPROPOSTA-FIDELIZ TO DATA-SQL1. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO, WORK_AREA.DATA_SQL1);

            /*" -7477- COMPUTE MES-SQL = MES-SQL + PRODUVG-PERI-PAGAMENTO OF DCLPRODUTOS-VG. */
            WORK_AREA.DATA_SQL.MES_SQL.Value = WORK_AREA.DATA_SQL.MES_SQL + PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO;

            /*" -7478- IF MES-SQL GREATER 12 */

            if (WORK_AREA.DATA_SQL.MES_SQL > 12)
            {

                /*" -7481- COMPUTE MES-SQL = MES-SQL - 12 */
                WORK_AREA.DATA_SQL.MES_SQL.Value = WORK_AREA.DATA_SQL.MES_SQL - 12;

                /*" -7484- COMPUTE ANO-SQL = ANO-SQL + 1. */
                WORK_AREA.DATA_SQL.ANO_SQL.Value = WORK_AREA.DATA_SQL.ANO_SQL + 1;
            }


            /*" -7486- MOVE DATA-SQL1 TO WHOST-DTPROXVEN. */
            _.Move(WORK_AREA.DATA_SQL1, WHOST_DTPROXVEN);

            /*" -7487- IF PROPOFID-DIA-DEBITO OF DCLPROPOSTA-FIDELIZ GREATER ZEROS */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIA_DEBITO > 00)
            {

                /*" -7490- MOVE PROPOFID-DIA-DEBITO OF DCLPROPOSTA-FIDELIZ TO DIA-SQL. */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIA_DEBITO, WORK_AREA.DATA_SQL.DIA_SQL);
            }


            /*" -7491- IF DIA-SQL GREATER 28 */

            if (WORK_AREA.DATA_SQL.DIA_SQL > 28)
            {

                /*" -7493- MOVE 28 TO DIA-SQL. */
                _.Move(28, WORK_AREA.DATA_SQL.DIA_SQL);
            }


            /*" -7494- IF DATA-SQL LESS WHOST-DTPROXVEN */

            if (WORK_AREA.DATA_SQL < WHOST_DTPROXVEN)
            {

                /*" -7495- ADD 1 TO MES-SQL */
                WORK_AREA.DATA_SQL.MES_SQL.Value = WORK_AREA.DATA_SQL.MES_SQL + 1;

                /*" -7496- IF MES-SQL GREATER 12 */

                if (WORK_AREA.DATA_SQL.MES_SQL > 12)
                {

                    /*" -7497- MOVE 1 TO MES-SQL */
                    _.Move(1, WORK_AREA.DATA_SQL.MES_SQL);

                    /*" -7499- ADD 1 TO ANO-SQL. */
                    WORK_AREA.DATA_SQL.ANO_SQL.Value = WORK_AREA.DATA_SQL.ANO_SQL + 1;
                }

            }


            /*" -7512- MOVE DATA-SQL1 TO WHOST-DTPROXVEN. */
            _.Move(WORK_AREA.DATA_SQL1, WHOST_DTPROXVEN);

            /*" -7519- IF WS-TEM-ERRO-1855 EQUAL 'SIM' OR WS-TEM-ERRO-1807 EQUAL 'SIM' OR WS-TEM-ERRO-1852 EQUAL 'SIM' OR PROPOFID-NSAS-SIVPF OF DCLPROPOSTA-FIDELIZ EQUAL 01 OR PROPOFID-SIT-PROPOSTA OF DCLPROPOSTA-FIDELIZ EQUAL 'DEC' */

            if (WORK_AREA.WS_TEM_ERRO_1855 == "SIM" || WORK_AREA.WS_TEM_ERRO_1807 == "SIM" || WORK_AREA.WS_TEM_ERRO_1852 == "SIM" || PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAS_SIVPF == 01 || PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA == "DEC")
            {

                /*" -7520- MOVE '2' TO WHOST-SIT-REGISTRO */
                _.Move("2", WHOST_SIT_REGISTRO);

                /*" -7521- ELSE */
            }
            else
            {


                /*" -7528- IF WS-TEM-ERRO EQUAL ZEROS AND IMPMORNATU OF DCLPLANOS-VA-VGAP NOT GREATER 300000,00 */

                if (WORK_AREA.WS_TEM_ERRO == 00 && PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU <= 300000.00)
                {

                    /*" -7529- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 77 */

                    if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 77)
                    {

                        /*" -7530- MOVE '0' TO WHOST-SIT-REGISTRO */
                        _.Move("0", WHOST_SIT_REGISTRO);

                        /*" -7531- ELSE */
                    }
                    else
                    {


                        /*" -7532- MOVE 'E' TO WHOST-SIT-REGISTRO */
                        _.Move("E", WHOST_SIT_REGISTRO);

                        /*" -7533- END-IF */
                    }


                    /*" -7534- ELSE */
                }
                else
                {


                    /*" -7535- IF PROPOFID-COD-PRODUTO-SIVPF EQUAL 77 */

                    if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 77)
                    {

                        /*" -7540- IF WS-TEM-ERRO EQUAL ZEROS AND (PRODUVG-COD-PRODUTO = 7705 OR JVPRD7705 OR 7715 ) AND IMPMORNATU OF DCLPLANOS-VA-VGAP GREATER 300000,00 */

                        if (WORK_AREA.WS_TEM_ERRO == 00 && (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.In("7705", JVBKINCL.JV_PRODUTOS.JVPRD7705.ToString(), "7715")) && PLVAVGAP.DCLPLANOS_VA_VGAP.IMPMORNATU > 300000.00)
                        {

                            /*" -7541- MOVE '0' TO WHOST-SIT-REGISTRO */
                            _.Move("0", WHOST_SIT_REGISTRO);

                            /*" -7542- ELSE */
                        }
                        else
                        {


                            /*" -7543- MOVE '9' TO WHOST-SIT-REGISTRO */
                            _.Move("9", WHOST_SIT_REGISTRO);

                            /*" -7544- END-IF */
                        }


                        /*" -7545- ELSE */
                    }
                    else
                    {


                        /*" -7546- MOVE 'E' TO WHOST-SIT-REGISTRO */
                        _.Move("E", WHOST_SIT_REGISTRO);

                        /*" -7547- END-IF */
                    }


                    /*" -7548- END-IF */
                }


                /*" -7552- END-IF. */
            }


            /*" -7553- IF VIND-PROFISSAO-CONJUGE EQUAL ZEROS */

            if (VIND_PROFISSAO_CONJUGE == 00)
            {

                /*" -7557- IF PROPOFID-PROFISSAO-CONJUGE OF DCLPROPOSTA-FIDELIZ > ZEROS AND PROPOFID-PROFISSAO-CONJUGE OF DCLPROPOSTA-FIDELIZ < 1000 */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PROFISSAO_CONJUGE > 00 && PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PROFISSAO_CONJUGE < 1000)
                {

                    /*" -7560- MOVE TAB-DESCR-CBO-C (PROPOFID-PROFISSAO-CONJUGE OF DCLPROPOSTA-FIDELIZ) TO WHOST-PROFISSAO-CONJUGE */
                    _.Move(TAB_CBO1.TAB_CBO.FILLER_27[PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PROFISSAO_CONJUGE].TAB_DESCR_CBO_C, WHOST_PROFISSAO_CONJUGE);

                    /*" -7564- ELSE */
                }
                else
                {


                    /*" -7565- MOVE SPACES TO WHOST-PROFISSAO-CONJUGE */
                    _.Move("", WHOST_PROFISSAO_CONJUGE);

                    /*" -7566- END-IF */
                }


                /*" -7568- END-IF. */
            }


            /*" -7570- IF PROPOFID-AGECOBR OF DCLPROPOSTA-FIDELIZ > 0 AND PROPOFID-AGECOBR OF DCLPROPOSTA-FIDELIZ < 10000 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR > 0 && PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR < 10000)
            {

                /*" -7572- MOVE TAB-FONTE (PROPOFID-AGECOBR OF DCLPROPOSTA-FIDELIZ) TO WHOST-FONTE */
                _.Move(TAB_FILIAIS.TAB_FILIAL.FILLER_26[PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR].TAB_FONTE, WHOST_FONTE);

                /*" -7573- ELSE */
            }
            else
            {


                /*" -7576- DISPLAY 'AGENCIA INVALIDA ----> ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ ' ' PROPOFID-AGECOBR OF DCLPROPOSTA-FIDELIZ */

                $"AGENCIA INVALIDA ----> {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF} {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR}"
                .Display();

                /*" -7577- MOVE ZEROS TO WHOST-FONTE */
                _.Move(0, WHOST_FONTE);

                /*" -7579- END-IF. */
            }


            /*" -7581- IF (WHOST-FONTE = ZEROS OR 10) OR (WHOST-FONTE > 99) */

            if ((WHOST_FONTE.In("00", "10")) || (WHOST_FONTE > 99))
            {

                /*" -7587- MOVE 5 TO WHOST-FONTE. */
                _.Move(5, WHOST_FONTE);
            }


            /*" -7588- MOVE '5635-00-UPDATE-PROPOSTAVA    ' TO PARAGRAFO. */
            _.Move("5635-00-UPDATE-PROPOSTAVA    ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7590- MOVE 'UPDATE PROPOSTAVA            ' TO COMANDO. */
            _.Move("UPDATE PROPOSTAVA            ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7592- IF PRODUVG-COD-PRODUTO = 7732 OR JVPRD7732 OR 7733 OR JVPRD7733 */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.In("7732", JVBKINCL.JV_PRODUTOS.JVPRD7732.ToString(), "7733", JVBKINCL.JV_PRODUTOS.JVPRD7733.ToString()))
            {

                /*" -7596- PERFORM R5635_00_UPDATE_PROPOSTAVA_DB_SELECT_1 */

                R5635_00_UPDATE_PROPOSTAVA_DB_SELECT_1();

                /*" -7598- MOVE '9999-12-31' TO WHOST-DTPROXVEN */
                _.Move("9999-12-31", WHOST_DTPROXVEN);

                /*" -7601- END-IF */
            }


            /*" -7602- MOVE 62 TO SII */
            _.Move(62, WS_HORAS.SII);

            /*" -7603- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -7650- PERFORM R5635_00_UPDATE_PROPOSTAVA_DB_UPDATE_1 */

            R5635_00_UPDATE_PROPOSTAVA_DB_UPDATE_1();

            /*" -7653- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -7654- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7655- DISPLAY 'PROBLEMAS NO UPDATE PROPOSTAVA ' */
                _.Display($"PROBLEMAS NO UPDATE PROPOSTAVA ");

                /*" -7657- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -7659- ADD 1 TO AC-I-PROPOSTAVA. */
            WORK_AREA.AC_I_PROPOSTAVA.Value = WORK_AREA.AC_I_PROPOSTAVA + 1;

            /*" -7661- IF PRODUVG-COD-PRODUTO = 7732 OR JVPRD7732 OR 7733 OR JVPRD7733 */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.In("7732", JVBKINCL.JV_PRODUTOS.JVPRD7732.ToString(), "7733", JVBKINCL.JV_PRODUTOS.JVPRD7733.ToString()))
            {

                /*" -7662- PERFORM R3210-INS-VG-MOVTO-PRET */

                R3210_INS_VG_MOVTO_PRET_SECTION();

                /*" -7663- END-IF. */
            }


        }

        [StopWatch]
        /*" R5635-00-UPDATE-PROPOSTAVA-DB-SELECT-1 */
        public void R5635_00_UPDATE_PROPOSTAVA_DB_SELECT_1()
        {
            /*" -7596- EXEC SQL SELECT DATE(:PROPOFID-DATA-PROPOSTA) + 1 MONTH INTO : WS-DTPROXVEN FROM SYSIBM.SYSDUMMY1 END-EXEC */

            /*-- linha suprimida por comandos abaixo EXEC SQL
            /*--SELECT DATE(:PROPOFID-DATA-PROPOSTA) + 1 MONTH
            /*--INTO : WS-DTPROXVEN
            /*--FROM SYSIBM.SYSDUMMY1
            /*--END-EXEC
            /*-- */

            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA.ToDateTime().ToString(_.CurrentDateFormat), WS_DTPROXVEN);

        }

        [StopWatch]
        /*" R5635-00-UPDATE-PROPOSTAVA-DB-UPDATE-1 */
        public void R5635_00_UPDATE_PROPOSTAVA_DB_UPDATE_1()
        {
            /*" -7650- EXEC SQL UPDATE SEGUROS.PROPOSTAS_VA SET COD_CLIENTE = :DCLCLIENTES.COD-CLIENTE , OCOREND = :DCLENDERECOS.ENDERECO-OCORR-ENDERECO, COD_FONTE = :WHOST-FONTE , PROFISSAO = :WHOST-PROFISSAO , SIT_REGISTRO = :WHOST-SIT-REGISTRO , DTPROXVEN = :WHOST-DTPROXVEN , IDADE = :WHOST-IDADE , NOME_ESPOSA = :DCLPROPOSTA-FIDELIZ.PROPOFID-NOME-CONJUGE :VIND-NOME-CONJUGE , DTNASC_ESPOSA = :DCLPROPOSTA-FIDELIZ.PROPOFID-DATA-NASC-CONJUGE :VIND-DATA-NASC-CONJUGE , PROFIS_ESPOSA = :WHOST-PROFISSAO-CONJUGE :VIND-PROFISSAO-CONJUGE , INFO_COMPLEMENTAR = :WHOST-INFO-COMPL , COD_CCT = :DCLPROPOSTA-FIDELIZ.PROPOFID-CGC-CONVENENTE :VIND-CGC-CONVENENTE , NUM_CONTR_VINCULO = :PROPSSVD-NUM-CONTR-VINCULO :VIND-NUM-CONTR , COD_CORRESP_BANC = :PROPSSVD-COD-CORRESP-BANC :VIND-COD-CORRESP , COD_ORIGEM_PROPOSTA = :PROPOFID-ORIGEM-PROPOSTA , NUM_PRAZO_FIN = :PROPSSVD-NUM-PRAZO-FIN :VIND-NUM-PRAZO , COD_OPER_CREDITO = :PROPSSVD-COD-OPER-CREDITO :VIND-COD-OPER-CRED WHERE NUM_CERTIFICADO = :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF END-EXEC. */

            var r5635_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1 = new R5635_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1()
            {
                PROPOFID_DATA_NASC_CONJUGE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_NASC_CONJUGE.ToString(),
                VIND_DATA_NASC_CONJUGE = VIND_DATA_NASC_CONJUGE.ToString(),
                PROPOFID_CGC_CONVENENTE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CGC_CONVENENTE.ToString(),
                VIND_CGC_CONVENENTE = VIND_CGC_CONVENENTE.ToString(),
                PROPOFID_NOME_CONJUGE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NOME_CONJUGE.ToString(),
                VIND_NOME_CONJUGE = VIND_NOME_CONJUGE.ToString(),
                WHOST_PROFISSAO_CONJUGE = WHOST_PROFISSAO_CONJUGE.ToString(),
                VIND_PROFISSAO_CONJUGE = VIND_PROFISSAO_CONJUGE.ToString(),
                PROPSSVD_COD_OPER_CREDITO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_OPER_CREDITO.ToString(),
                VIND_COD_OPER_CRED = VIND_COD_OPER_CRED.ToString(),
                PROPSSVD_COD_CORRESP_BANC = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_CORRESP_BANC.ToString(),
                VIND_COD_CORRESP = VIND_COD_CORRESP.ToString(),
                PROPSSVD_NUM_CONTR_VINCULO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_CONTR_VINCULO.ToString(),
                VIND_NUM_CONTR = VIND_NUM_CONTR.ToString(),
                PROPSSVD_NUM_PRAZO_FIN = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_PRAZO_FIN.ToString(),
                VIND_NUM_PRAZO = VIND_NUM_PRAZO.ToString(),
                ENDERECO_OCORR_ENDERECO = ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO.ToString(),
                PROPOFID_ORIGEM_PROPOSTA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA.ToString(),
                COD_CLIENTE = CLIENTE.DCLCLIENTES.COD_CLIENTE.ToString(),
                WHOST_SIT_REGISTRO = WHOST_SIT_REGISTRO.ToString(),
                WHOST_INFO_COMPL = WHOST_INFO_COMPL.ToString(),
                WHOST_PROFISSAO = WHOST_PROFISSAO.ToString(),
                WHOST_DTPROXVEN = WHOST_DTPROXVEN.ToString(),
                WHOST_FONTE = WHOST_FONTE.ToString(),
                WHOST_IDADE = WHOST_IDADE.ToString(),
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            R5635_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1.Execute(r5635_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5635_99_SAIDA*/

        [StopWatch]
        /*" R6000-00-DECLARE-AGENCEF-SECTION */
        private void R6000_00_DECLARE_AGENCEF_SECTION()
        {
            /*" -7672- MOVE 'R6000-DECLA-AGENCEF   ' TO PARAGRAFO. */
            _.Move("R6000-DECLA-AGENCEF   ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7676- MOVE 'DECLARE AGENCIACEF   ' TO COMANDO. */
            _.Move("DECLARE AGENCIACEF   ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7685- PERFORM R6000_00_DECLARE_AGENCEF_DB_DECLARE_1 */

            R6000_00_DECLARE_AGENCEF_DB_DECLARE_1();

            /*" -7688- MOVE 63 TO SII */
            _.Move(63, WS_HORAS.SII);

            /*" -7689- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -7689- PERFORM R6000_00_DECLARE_AGENCEF_DB_OPEN_1 */

            R6000_00_DECLARE_AGENCEF_DB_OPEN_1();

            /*" -7692- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -7693- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7694- DISPLAY 'R6000 - PROBLEMAS DECLARE (AGENCEF) ..' */
                _.Display($"R6000 - PROBLEMAS DECLARE (AGENCEF) ..");

                /*" -7695- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -7695- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R6000-00-DECLARE-AGENCEF-DB-OPEN-1 */
        public void R6000_00_DECLARE_AGENCEF_DB_OPEN_1()
        {
            /*" -7689- EXEC SQL OPEN C01_AGENCEF END-EXEC. */

            C01_AGENCEF.Open();

        }

        [StopWatch]
        /*" R6100-00-DECLARE-CBO-DB-DECLARE-1 */
        public void R6100_00_DECLARE_CBO_DB_DECLARE_1()
        {
            /*" -7764- EXEC SQL DECLARE CCBO CURSOR FOR SELECT COD_CBO, DESCR_CBO FROM SEGUROS.CBO ORDER BY COD_CBO END-EXEC. */
            CCBO = new VP0601B_CCBO(false);
            string GetQuery_CCBO()
            {
                var query = @$"SELECT COD_CBO
							, 
							DESCR_CBO 
							FROM SEGUROS.CBO 
							ORDER BY COD_CBO";

                return query;
            }
            CCBO.GetQueryEvent += GetQuery_CCBO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6000_99_SAIDA*/

        [StopWatch]
        /*" R6010-00-FETCH-AGENCEF-SECTION */
        private void R6010_00_FETCH_AGENCEF_SECTION()
        {
            /*" -7705- MOVE 'R6010-FETCH-AGENCEF   ' TO PARAGRAFO. */
            _.Move("R6010-FETCH-AGENCEF   ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7709- MOVE 'FETCH   AGENCIACEF   ' TO COMANDO. */
            _.Move("FETCH   AGENCIACEF   ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7710- MOVE 64 TO SII */
            _.Move(64, WS_HORAS.SII);

            /*" -7711- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -7714- PERFORM R6010_00_FETCH_AGENCEF_DB_FETCH_1 */

            R6010_00_FETCH_AGENCEF_DB_FETCH_1();

            /*" -7717- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -7718- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7719- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -7720- MOVE 'S' TO WFIM-AGENCEF */
                    _.Move("S", WORK_AREA.WFIM_AGENCEF);

                    /*" -7720- PERFORM R6010_00_FETCH_AGENCEF_DB_CLOSE_1 */

                    R6010_00_FETCH_AGENCEF_DB_CLOSE_1();

                    /*" -7722- ELSE */
                }
                else
                {


                    /*" -7722- PERFORM R6010_00_FETCH_AGENCEF_DB_CLOSE_2 */

                    R6010_00_FETCH_AGENCEF_DB_CLOSE_2();

                    /*" -7724- DISPLAY '3100 - (PROBLEMAS NO FETCH AGENCEF) ..' */
                    _.Display($"3100 - (PROBLEMAS NO FETCH AGENCEF) ..");

                    /*" -7725- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -7725- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R6010-00-FETCH-AGENCEF-DB-FETCH-1 */
        public void R6010_00_FETCH_AGENCEF_DB_FETCH_1()
        {
            /*" -7714- EXEC SQL FETCH C01_AGENCEF INTO :DCLAGENCIAS-CEF.COD-AGENCIA, :DCLMALHA-CEF.MALHACEF-COD-FONTE END-EXEC. */

            if (C01_AGENCEF.Fetch())
            {
                _.Move(C01_AGENCEF.DCLAGENCIAS_CEF_COD_AGENCIA, AGENCEF.DCLAGENCIAS_CEF.COD_AGENCIA);
                _.Move(C01_AGENCEF.DCLMALHA_CEF_MALHACEF_COD_FONTE, MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE);
            }

        }

        [StopWatch]
        /*" R6010-00-FETCH-AGENCEF-DB-CLOSE-1 */
        public void R6010_00_FETCH_AGENCEF_DB_CLOSE_1()
        {
            /*" -7720- EXEC SQL CLOSE C01_AGENCEF END-EXEC */

            C01_AGENCEF.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6010_99_SAIDA*/

        [StopWatch]
        /*" R6010-00-FETCH-AGENCEF-DB-CLOSE-2 */
        public void R6010_00_FETCH_AGENCEF_DB_CLOSE_2()
        {
            /*" -7722- EXEC SQL CLOSE C01_AGENCEF END-EXEC */

            C01_AGENCEF.Close();

        }

        [StopWatch]
        /*" R6020-00-CARREGA-FILIAL-SECTION */
        private void R6020_00_CARREGA_FILIAL_SECTION()
        {
            /*" -7735- MOVE 'R6020-CARREGA-FILIAL    ' TO PARAGRAFO. */
            _.Move("R6020-CARREGA-FILIAL    ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7739- MOVE 'CARREGA FILIAL         ' TO COMANDO. */
            _.Move("CARREGA FILIAL         ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7741- IF COD-AGENCIA OF DCLAGENCIAS-CEF > 0 AND COD-AGENCIA OF DCLAGENCIAS-CEF < 10000 */

            if (AGENCEF.DCLAGENCIAS_CEF.COD_AGENCIA > 0 && AGENCEF.DCLAGENCIAS_CEF.COD_AGENCIA < 10000)
            {

                /*" -7743- MOVE MALHACEF-COD-FONTE OF DCLMALHA-CEF TO TAB-FONTE (COD-AGENCIA OF DCLAGENCIAS-CEF) */
                _.Move(MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE, TAB_FILIAIS.TAB_FILIAL.FILLER_26[AGENCEF.DCLAGENCIAS_CEF.COD_AGENCIA].TAB_FONTE);

                /*" -7745- END-IF. */
            }


            /*" -7745- PERFORM R6010-00-FETCH-AGENCEF. */

            R6010_00_FETCH_AGENCEF_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6020_99_SAIDA*/

        [StopWatch]
        /*" R6100-00-DECLARE-CBO-SECTION */
        private void R6100_00_DECLARE_CBO_SECTION()
        {
            /*" -7755- MOVE 'R6100-DECLA-CBO         ' TO PARAGRAFO. */
            _.Move("R6100-DECLA-CBO         ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7759- MOVE 'DECLARE CBO            ' TO COMANDO. */
            _.Move("DECLARE CBO            ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7764- PERFORM R6100_00_DECLARE_CBO_DB_DECLARE_1 */

            R6100_00_DECLARE_CBO_DB_DECLARE_1();

            /*" -7767- MOVE 65 TO SII */
            _.Move(65, WS_HORAS.SII);

            /*" -7768- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -7768- PERFORM R6100_00_DECLARE_CBO_DB_OPEN_1 */

            R6100_00_DECLARE_CBO_DB_OPEN_1();

            /*" -7771- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -7772- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7773- DISPLAY 'R6100 - PROBLEMAS DECLARE (CBO      ) ..' */
                _.Display($"R6100 - PROBLEMAS DECLARE (CBO      ) ..");

                /*" -7774- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -7774- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R6100-00-DECLARE-CBO-DB-OPEN-1 */
        public void R6100_00_DECLARE_CBO_DB_OPEN_1()
        {
            /*" -7768- EXEC SQL OPEN CCBO END-EXEC. */

            CCBO.Open();

        }

        [StopWatch]
        /*" R6200-00-DECLARE-FONTES-DB-DECLARE-1 */
        public void R6200_00_DECLARE_FONTES_DB_DECLARE_1()
        {
            /*" -7842- EXEC SQL DECLARE CFONTES CURSOR FOR SELECT COD_FONTE, ULT_PROP_AUTOMAT FROM SEGUROS.FONTES ORDER BY COD_FONTE END-EXEC. */
            CFONTES = new VP0601B_CFONTES(false);
            string GetQuery_CFONTES()
            {
                var query = @$"SELECT COD_FONTE
							, 
							ULT_PROP_AUTOMAT 
							FROM SEGUROS.FONTES 
							ORDER BY COD_FONTE";

                return query;
            }
            CFONTES.GetQueryEvent += GetQuery_CFONTES;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6100_99_SAIDA*/

        [StopWatch]
        /*" R6110-00-FETCH-CBO-SECTION */
        private void R6110_00_FETCH_CBO_SECTION()
        {
            /*" -7784- MOVE 'R6110-FETCH-CBO         ' TO PARAGRAFO. */
            _.Move("R6110-FETCH-CBO         ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7788- MOVE 'FETCH   CBO            ' TO COMANDO. */
            _.Move("FETCH   CBO            ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7789- MOVE 66 TO SII */
            _.Move(66, WS_HORAS.SII);

            /*" -7790- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -7793- PERFORM R6110_00_FETCH_CBO_DB_FETCH_1 */

            R6110_00_FETCH_CBO_DB_FETCH_1();

            /*" -7796- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -7797- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7798- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -7799- MOVE 'S' TO WFIM-CBO */
                    _.Move("S", WORK_AREA.WFIM_CBO);

                    /*" -7799- PERFORM R6110_00_FETCH_CBO_DB_CLOSE_1 */

                    R6110_00_FETCH_CBO_DB_CLOSE_1();

                    /*" -7801- ELSE */
                }
                else
                {


                    /*" -7801- PERFORM R6110_00_FETCH_CBO_DB_CLOSE_2 */

                    R6110_00_FETCH_CBO_DB_CLOSE_2();

                    /*" -7803- DISPLAY '6110 - (PROBLEMAS NO FETCH CCBO     ) ..' */
                    _.Display($"6110 - (PROBLEMAS NO FETCH CCBO     ) ..");

                    /*" -7804- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -7804- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R6110-00-FETCH-CBO-DB-FETCH-1 */
        public void R6110_00_FETCH_CBO_DB_FETCH_1()
        {
            /*" -7793- EXEC SQL FETCH CCBO INTO :DCLCBO.CBO-COD-CBO, :DCLCBO.CBO-DESCR-CBO END-EXEC. */

            if (CCBO.Fetch())
            {
                _.Move(CCBO.DCLCBO_CBO_COD_CBO, CBO.DCLCBO.CBO_COD_CBO);
                _.Move(CCBO.DCLCBO_CBO_DESCR_CBO, CBO.DCLCBO.CBO_DESCR_CBO);
            }

        }

        [StopWatch]
        /*" R6110-00-FETCH-CBO-DB-CLOSE-1 */
        public void R6110_00_FETCH_CBO_DB_CLOSE_1()
        {
            /*" -7799- EXEC SQL CLOSE CCBO END-EXEC */

            CCBO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6110_99_SAIDA*/

        [StopWatch]
        /*" R6110-00-FETCH-CBO-DB-CLOSE-2 */
        public void R6110_00_FETCH_CBO_DB_CLOSE_2()
        {
            /*" -7801- EXEC SQL CLOSE CCBO END-EXEC */

            CCBO.Close();

        }

        [StopWatch]
        /*" R6120-00-CARREGA-CBO-SECTION */
        private void R6120_00_CARREGA_CBO_SECTION()
        {
            /*" -7814- MOVE 'R6120-CARREGA-CBO       ' TO PARAGRAFO. */
            _.Move("R6120-CARREGA-CBO       ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7818- MOVE 'CARREGA CBO            ' TO COMANDO. */
            _.Move("CARREGA CBO            ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7820- IF CBO-COD-CBO OF DCLCBO > 0 AND CBO-COD-CBO OF DCLCBO < 1000 */

            if (CBO.DCLCBO.CBO_COD_CBO > 0 && CBO.DCLCBO.CBO_COD_CBO < 1000)
            {

                /*" -7822- MOVE CBO-DESCR-CBO OF DCLCBO TO TAB-DESCR-CBO-C (CBO-COD-CBO OF DCLCBO) */
                _.Move(CBO.DCLCBO.CBO_DESCR_CBO, TAB_CBO1.TAB_CBO.FILLER_27[CBO.DCLCBO.CBO_COD_CBO].TAB_DESCR_CBO_C);

                /*" -7824- END-IF. */
            }


            /*" -7824- PERFORM R6110-00-FETCH-CBO. */

            R6110_00_FETCH_CBO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6120_99_SAIDA*/

        [StopWatch]
        /*" R6200-00-DECLARE-FONTES-SECTION */
        private void R6200_00_DECLARE_FONTES_SECTION()
        {
            /*" -7834- MOVE 'R6200-DECLA-FONTES      ' TO PARAGRAFO. */
            _.Move("R6200-DECLA-FONTES      ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7837- MOVE 'DECLARE FONTES         ' TO COMANDO. */
            _.Move("DECLARE FONTES         ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7842- PERFORM R6200_00_DECLARE_FONTES_DB_DECLARE_1 */

            R6200_00_DECLARE_FONTES_DB_DECLARE_1();

            /*" -7845- MOVE 67 TO SII */
            _.Move(67, WS_HORAS.SII);

            /*" -7846- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -7846- PERFORM R6200_00_DECLARE_FONTES_DB_OPEN_1 */

            R6200_00_DECLARE_FONTES_DB_OPEN_1();

            /*" -7849- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -7850- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7851- DISPLAY 'R6200 - PROBLEMAS DECLARE (FONTES   ) ..' */
                _.Display($"R6200 - PROBLEMAS DECLARE (FONTES   ) ..");

                /*" -7852- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -7852- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R6200-00-DECLARE-FONTES-DB-OPEN-1 */
        public void R6200_00_DECLARE_FONTES_DB_OPEN_1()
        {
            /*" -7846- EXEC SQL OPEN CFONTES END-EXEC. */

            CFONTES.Open();

        }

        [StopWatch]
        /*" R9320-00-SELECT-GECLIMOV-DB-DECLARE-1 */
        public void R9320_00_SELECT_GECLIMOV_DB_DECLARE_1()
        {
            /*" -8204- EXEC SQL DECLARE C01_GECLIMOV CURSOR FOR SELECT TIPO_MOVIMENTO , DATA_ULT_MANUTEN , NOME_RAZAO , TIPO_PESSOA , IDE_SEXO , ESTADO_CIVIL , OCORR_ENDERECO , ENDERECO , BAIRRO , CIDADE , SIGLA_UF , CEP , DDD , TELEFONE , FAX , OCORR_HIST , CGCCPF , DATA_NASCIMENTO FROM SEGUROS.GE_CLIENTES_MOVTO WHERE COD_CLIENTE = :GECLIMOV-COD-CLIENTE AND OCORR_ENDERECO BETWEEN :WHOST-OCORR-END-I AND :WHOST-OCORR-END-F ORDER BY OCORR_HIST DESC END-EXEC. */
            C01_GECLIMOV = new VP0601B_C01_GECLIMOV(true);
            string GetQuery_C01_GECLIMOV()
            {
                var query = @$"SELECT TIPO_MOVIMENTO
							, 
							DATA_ULT_MANUTEN
							, 
							NOME_RAZAO
							, 
							TIPO_PESSOA
							, 
							IDE_SEXO
							, 
							ESTADO_CIVIL
							, 
							OCORR_ENDERECO
							, 
							ENDERECO
							, 
							BAIRRO
							, 
							CIDADE
							, 
							SIGLA_UF
							, 
							CEP
							, 
							DDD
							, 
							TELEFONE
							, 
							FAX
							, 
							OCORR_HIST
							, 
							CGCCPF
							, 
							DATA_NASCIMENTO 
							FROM SEGUROS.GE_CLIENTES_MOVTO 
							WHERE COD_CLIENTE = '{GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_CLIENTE}' 
							AND OCORR_ENDERECO BETWEEN '{WHOST_OCORR_END_I}' 
							AND '{WHOST_OCORR_END_F}' 
							ORDER BY OCORR_HIST DESC";

                return query;
            }
            C01_GECLIMOV.GetQueryEvent += GetQuery_C01_GECLIMOV;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6200_99_SAIDA*/

        [StopWatch]
        /*" R6210-00-FETCH-FONTES-SECTION */
        private void R6210_00_FETCH_FONTES_SECTION()
        {
            /*" -7862- MOVE 'R6210-FETCH-FONTES      ' TO PARAGRAFO. */
            _.Move("R6210-FETCH-FONTES      ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7865- MOVE 'FETCH   FONTES         ' TO COMANDO. */
            _.Move("FETCH   FONTES         ", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -7866- MOVE 68 TO SII */
            _.Move(68, WS_HORAS.SII);

            /*" -7867- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -7870- PERFORM R6210_00_FETCH_FONTES_DB_FETCH_1 */

            R6210_00_FETCH_FONTES_DB_FETCH_1();

            /*" -7873- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -7874- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7875- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -7876- MOVE 'S' TO WFIM-FONTES */
                    _.Move("S", WORK_AREA.WFIM_FONTES);

                    /*" -7876- PERFORM R6210_00_FETCH_FONTES_DB_CLOSE_1 */

                    R6210_00_FETCH_FONTES_DB_CLOSE_1();

                    /*" -7878- ELSE */
                }
                else
                {


                    /*" -7878- PERFORM R6210_00_FETCH_FONTES_DB_CLOSE_2 */

                    R6210_00_FETCH_FONTES_DB_CLOSE_2();

                    /*" -7880- DISPLAY '6200 - (PROBLEMAS NO FETCH CFONTES  ) ..' */
                    _.Display($"6200 - (PROBLEMAS NO FETCH CFONTES  ) ..");

                    /*" -7881- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -7881- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R6210-00-FETCH-FONTES-DB-FETCH-1 */
        public void R6210_00_FETCH_FONTES_DB_FETCH_1()
        {
            /*" -7870- EXEC SQL FETCH CFONTES INTO :DCLFONTES.FONTES-COD-FONTE, :DCLFONTES.FONTES-ULT-PROP-AUTOMAT END-EXEC. */

            if (CFONTES.Fetch())
            {
                _.Move(CFONTES.DCLFONTES_FONTES_COD_FONTE, FONTES.DCLFONTES.FONTES_COD_FONTE);
                _.Move(CFONTES.DCLFONTES_FONTES_ULT_PROP_AUTOMAT, FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT);
            }

        }

        [StopWatch]
        /*" R6210-00-FETCH-FONTES-DB-CLOSE-1 */
        public void R6210_00_FETCH_FONTES_DB_CLOSE_1()
        {
            /*" -7876- EXEC SQL CLOSE CFONTES END-EXEC */

            CFONTES.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6210_99_SAIDA*/

        [StopWatch]
        /*" R6210-00-FETCH-FONTES-DB-CLOSE-2 */
        public void R6210_00_FETCH_FONTES_DB_CLOSE_2()
        {
            /*" -7878- EXEC SQL CLOSE CFONTES END-EXEC */

            CFONTES.Close();

        }

        [StopWatch]
        /*" R9100-00-UPDATE-NUM-OUTROS-SECTION */
        private void R9100_00_UPDATE_NUM_OUTROS_SECTION()
        {
            /*" -7911- MOVE '9100-00-UPDATE-NUM-OUTROS    ' TO PARAGRAFO. */
            _.Move("9100-00-UPDATE-NUM-OUTROS    ", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7912- MOVE 69 TO SII */
            _.Move(69, WS_HORAS.SII);

            /*" -7913- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -7917- PERFORM R9100_00_UPDATE_NUM_OUTROS_DB_UPDATE_1 */

            R9100_00_UPDATE_NUM_OUTROS_DB_UPDATE_1();

            /*" -7920- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -7921- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7922- DISPLAY 'PROBLEMAS NO UPDATE DA NUMERO OUTROS' */
                _.Display($"PROBLEMAS NO UPDATE DA NUMERO OUTROS");

                /*" -7922- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R9100-00-UPDATE-NUM-OUTROS-DB-UPDATE-1 */
        public void R9100_00_UPDATE_NUM_OUTROS_DB_UPDATE_1()
        {
            /*" -7917- EXEC SQL UPDATE SEGUROS.NUMERO_OUTROS SET NUM_CLIENTE = :DCLNUMERO-OUTROS.NUM-CLIENTE WHERE 1 = 1 END-EXEC. */

            var r9100_00_UPDATE_NUM_OUTROS_DB_UPDATE_1_Update1 = new R9100_00_UPDATE_NUM_OUTROS_DB_UPDATE_1_Update1()
            {
                NUM_CLIENTE = NUMOUTRO.DCLNUMERO_OUTROS.NUM_CLIENTE.ToString(),
            };

            R9100_00_UPDATE_NUM_OUTROS_DB_UPDATE_1_Update1.Execute(r9100_00_UPDATE_NUM_OUTROS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9100_99_SAIDA*/

        [StopWatch]
        /*" R9300-00-TRATA-MOVTO-CLIENTE-SECTION */
        private void R9300_00_TRATA_MOVTO_CLIENTE_SECTION()
        {
            /*" -7975- MOVE 'R9300-00-TRATA-MOVTO-CLIENTE' TO PARAGRAFO */
            _.Move("R9300-00-TRATA-MOVTO-CLIENTE", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7977- MOVE COD-CLIENTE OF DCLCLIENTES TO WWORK-COD-CLIENTE */
            _.Move(CLIENTE.DCLCLIENTES.COD_CLIENTE, W_GECLIMOV.WWORK_COD_CLIENTE);

            /*" -7979- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO WWORK-DATA-ULT-MANUTEN */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, W_GECLIMOV.WWORK_DATA_ULT_MANUTEN);

            /*" -7981- MOVE PESSOA-NOME-PESSOA OF DCLPESSOA TO WWORK-NOME-RAZAO */
            _.Move(PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA, W_GECLIMOV.WWORK_NOME_RAZAO);

            /*" -7982- MOVE 'F' TO WWORK-TIPO-PESSOA */
            _.Move("F", W_GECLIMOV.WWORK_TIPO_PESSOA);

            /*" -7983- MOVE SPACES TO WWORK-IDE-SEXO */
            _.Move("", W_GECLIMOV.WWORK_IDE_SEXO);

            /*" -7985- MOVE SPACES TO WWORK-ESTADO-CIVIL */
            _.Move("", W_GECLIMOV.WWORK_ESTADO_CIVIL);

            /*" -7988- MOVE ENDERECO-OCORR-ENDERECO OF DCLENDERECOS TO WWORK-OCORR-ENDERECO */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO, W_GECLIMOV.WWORK_OCORR_ENDERECO);

            /*" -7990- MOVE ENDERECO OF DCLPESSOA-ENDERECO TO WWORK-ENDERECO */
            _.Move(PESENDER.DCLPESSOA_ENDERECO.ENDERECO, W_GECLIMOV.WWORK_ENDERECO);

            /*" -7992- MOVE BAIRRO OF DCLPESSOA-ENDERECO TO WWORK-BAIRRO */
            _.Move(PESENDER.DCLPESSOA_ENDERECO.BAIRRO, W_GECLIMOV.WWORK_BAIRRO);

            /*" -7994- MOVE CIDADE OF DCLPESSOA-ENDERECO TO WWORK-CIDADE */
            _.Move(PESENDER.DCLPESSOA_ENDERECO.CIDADE, W_GECLIMOV.WWORK_CIDADE);

            /*" -7996- MOVE SIGLA-UF OF DCLPESSOA-ENDERECO TO WWORK-SIGLA-UF */
            _.Move(PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF, W_GECLIMOV.WWORK_SIGLA_UF);

            /*" -7998- MOVE CEP OF DCLPESSOA-ENDERECO TO WWORK-CEP */
            _.Move(PESENDER.DCLPESSOA_ENDERECO.CEP, W_GECLIMOV.WWORK_CEP);

            /*" -7999- MOVE WHOST-DDD TO WWORK-DDD */
            _.Move(WHOST_DDD, W_GECLIMOV.WWORK_DDD);

            /*" -8000- MOVE WHOST-FONE TO WWORK-TELEFONE */
            _.Move(WHOST_FONE, W_GECLIMOV.WWORK_TELEFONE);

            /*" -8001- MOVE WHOST-FAX TO WWORK-FAX */
            _.Move(WHOST_FAX, W_GECLIMOV.WWORK_FAX);

            /*" -8002- MOVE CPF OF DCLPESSOA-FISICA TO WWORK-CGCCPF */
            _.Move(PESFIS.DCLPESSOA_FISICA.CPF, W_GECLIMOV.WWORK_CGCCPF);

            /*" -8005- MOVE DATA-NASCIMENTO OF DCLPESSOA-FISICA TO WWORK-DATA-NASCIMENTO */
            _.Move(PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO, W_GECLIMOV.WWORK_DATA_NASCIMENTO);

            /*" -8006- MOVE WWORK-COD-CLIENTE TO GECLIMOV-COD-CLIENTE */
            _.Move(W_GECLIMOV.WWORK_COD_CLIENTE, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_CLIENTE);

            /*" -8007- MOVE WWORK-OCORR-ENDERECO TO GECLIMOV-OCORR-ENDERECO */
            _.Move(W_GECLIMOV.WWORK_OCORR_ENDERECO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_ENDERECO);

            /*" -8009- MOVE WWORK-TIPO-MOVIMENTO TO GECLIMOV-TIPO-MOVIMENTO */
            _.Move(W_GECLIMOV.WWORK_TIPO_MOVIMENTO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TIPO_MOVIMENTO);

            /*" -8014- MOVE WWORK-DATA-ULT-MANUTEN TO GECLIMOV-DATA-ULT-MANUTEN */
            _.Move(W_GECLIMOV.WWORK_DATA_ULT_MANUTEN, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DATA_ULT_MANUTEN);

            /*" -8015- PERFORM R9310-00-MAX-GECLIMOV */

            R9310_00_MAX_GECLIMOV_SECTION();

            /*" -8017- ADD 1 TO GECLIMOV-OCORR-HIST */
            GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_HIST.Value = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_HIST + 1;

            /*" -8018- IF GECLIMOV-OCORR-ENDERECO EQUAL ZEROS */

            if (GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_ENDERECO == 00)
            {

                /*" -8019- MOVE 0 TO WHOST-OCORR-END-I */
                _.Move(0, WHOST_OCORR_END_I);

                /*" -8020- MOVE 9999 TO WHOST-OCORR-END-F */
                _.Move(9999, WHOST_OCORR_END_F);

                /*" -8021- ELSE */
            }
            else
            {


                /*" -8024- MOVE GECLIMOV-OCORR-ENDERECO TO WHOST-OCORR-END-I WHOST-OCORR-END-F. */
                _.Move(GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_ENDERECO, WHOST_OCORR_END_I, WHOST_OCORR_END_F);
            }


            /*" -8026- PERFORM R9320-00-SELECT-GECLIMOV. */

            R9320_00_SELECT_GECLIMOV_SECTION();

            /*" -8027- IF WWORK-NOME-RAZAO EQUAL SPACES */

            if (W_GECLIMOV.WWORK_NOME_RAZAO.IsEmpty())
            {

                /*" -8028- MOVE -1 TO VIND-NOME-RAZAO */
                _.Move(-1, VIND_NOME_RAZAO);

                /*" -8029- ELSE */
            }
            else
            {


                /*" -8030- MOVE +0 TO VIND-NOME-RAZAO */
                _.Move(+0, VIND_NOME_RAZAO);

                /*" -8032- MOVE WWORK-NOME-RAZAO TO GECLIMOV-NOME-RAZAO. */
                _.Move(W_GECLIMOV.WWORK_NOME_RAZAO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_NOME_RAZAO);
            }


            /*" -8033- IF WWORK-TIPO-PESSOA EQUAL SPACES */

            if (W_GECLIMOV.WWORK_TIPO_PESSOA.IsEmpty())
            {

                /*" -8034- MOVE -1 TO VIND-TIPO-PESSOA */
                _.Move(-1, VIND_TIPO_PESSOA);

                /*" -8035- ELSE */
            }
            else
            {


                /*" -8036- MOVE +0 TO VIND-TIPO-PESSOA */
                _.Move(+0, VIND_TIPO_PESSOA);

                /*" -8038- MOVE WWORK-TIPO-PESSOA TO GECLIMOV-TIPO-PESSOA. */
                _.Move(W_GECLIMOV.WWORK_TIPO_PESSOA, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TIPO_PESSOA);
            }


            /*" -8039- IF WWORK-IDE-SEXO EQUAL SPACES */

            if (W_GECLIMOV.WWORK_IDE_SEXO.IsEmpty())
            {

                /*" -8040- MOVE -1 TO VIND-IDE-SEXO */
                _.Move(-1, VIND_IDE_SEXO);

                /*" -8041- ELSE */
            }
            else
            {


                /*" -8042- MOVE +0 TO VIND-IDE-SEXO */
                _.Move(+0, VIND_IDE_SEXO);

                /*" -8044- MOVE WWORK-IDE-SEXO TO GECLIMOV-IDE-SEXO. */
                _.Move(W_GECLIMOV.WWORK_IDE_SEXO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_IDE_SEXO);
            }


            /*" -8045- IF WWORK-ESTADO-CIVIL EQUAL SPACES */

            if (W_GECLIMOV.WWORK_ESTADO_CIVIL.IsEmpty())
            {

                /*" -8046- MOVE -1 TO VIND-EST-CIVIL */
                _.Move(-1, VIND_EST_CIVIL);

                /*" -8047- ELSE */
            }
            else
            {


                /*" -8048- MOVE +0 TO VIND-EST-CIVIL */
                _.Move(+0, VIND_EST_CIVIL);

                /*" -8050- MOVE WWORK-ESTADO-CIVIL TO GECLIMOV-ESTADO-CIVIL. */
                _.Move(W_GECLIMOV.WWORK_ESTADO_CIVIL, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_ESTADO_CIVIL);
            }


            /*" -8051- IF WWORK-OCORR-ENDERECO EQUAL ZEROS */

            if (W_GECLIMOV.WWORK_OCORR_ENDERECO == 00)
            {

                /*" -8052- MOVE -1 TO VIND-OCORR-END */
                _.Move(-1, VIND_OCORR_END);

                /*" -8053- ELSE */
            }
            else
            {


                /*" -8055- MOVE +0 TO VIND-OCORR-END. */
                _.Move(+0, VIND_OCORR_END);
            }


            /*" -8056- IF WWORK-ENDERECO EQUAL SPACES */

            if (W_GECLIMOV.WWORK_ENDERECO.IsEmpty())
            {

                /*" -8057- MOVE -1 TO VIND-ENDERECO */
                _.Move(-1, VIND_ENDERECO);

                /*" -8058- ELSE */
            }
            else
            {


                /*" -8059- MOVE +0 TO VIND-ENDERECO */
                _.Move(+0, VIND_ENDERECO);

                /*" -8061- MOVE WWORK-ENDERECO TO GECLIMOV-ENDERECO. */
                _.Move(W_GECLIMOV.WWORK_ENDERECO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_ENDERECO);
            }


            /*" -8062- IF WWORK-BAIRRO EQUAL SPACES */

            if (W_GECLIMOV.WWORK_BAIRRO.IsEmpty())
            {

                /*" -8063- MOVE -1 TO VIND-BAIRRO */
                _.Move(-1, VIND_BAIRRO);

                /*" -8064- ELSE */
            }
            else
            {


                /*" -8065- MOVE +0 TO VIND-BAIRRO */
                _.Move(+0, VIND_BAIRRO);

                /*" -8067- MOVE WWORK-BAIRRO TO GECLIMOV-BAIRRO. */
                _.Move(W_GECLIMOV.WWORK_BAIRRO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_BAIRRO);
            }


            /*" -8068- IF WWORK-CIDADE EQUAL SPACES */

            if (W_GECLIMOV.WWORK_CIDADE.IsEmpty())
            {

                /*" -8069- MOVE -1 TO VIND-CIDADE */
                _.Move(-1, VIND_CIDADE);

                /*" -8070- ELSE */
            }
            else
            {


                /*" -8071- MOVE +0 TO VIND-CIDADE */
                _.Move(+0, VIND_CIDADE);

                /*" -8073- MOVE WWORK-CIDADE TO GECLIMOV-CIDADE. */
                _.Move(W_GECLIMOV.WWORK_CIDADE, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CIDADE);
            }


            /*" -8074- IF WWORK-SIGLA-UF EQUAL SPACES */

            if (W_GECLIMOV.WWORK_SIGLA_UF.IsEmpty())
            {

                /*" -8075- MOVE -1 TO VIND-SIGLA-UF */
                _.Move(-1, VIND_SIGLA_UF);

                /*" -8076- ELSE */
            }
            else
            {


                /*" -8077- MOVE +0 TO VIND-SIGLA-UF */
                _.Move(+0, VIND_SIGLA_UF);

                /*" -8079- MOVE WWORK-SIGLA-UF TO GECLIMOV-SIGLA-UF. */
                _.Move(W_GECLIMOV.WWORK_SIGLA_UF, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_SIGLA_UF);
            }


            /*" -8080- IF WWORK-CEP EQUAL ZEROS */

            if (W_GECLIMOV.WWORK_CEP == 00)
            {

                /*" -8081- MOVE -1 TO VIND-CEP */
                _.Move(-1, VIND_CEP);

                /*" -8082- ELSE */
            }
            else
            {


                /*" -8083- MOVE +0 TO VIND-CEP */
                _.Move(+0, VIND_CEP);

                /*" -8085- MOVE WWORK-CEP TO GECLIMOV-CEP. */
                _.Move(W_GECLIMOV.WWORK_CEP, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CEP);
            }


            /*" -8086- IF WWORK-DDD EQUAL ZEROS */

            if (W_GECLIMOV.WWORK_DDD == 00)
            {

                /*" -8087- MOVE -1 TO VIND-DDD */
                _.Move(-1, VIND_DDD);

                /*" -8088- ELSE */
            }
            else
            {


                /*" -8089- MOVE +0 TO VIND-DDD */
                _.Move(+0, VIND_DDD);

                /*" -8091- MOVE WWORK-DDD TO GECLIMOV-DDD. */
                _.Move(W_GECLIMOV.WWORK_DDD, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DDD);
            }


            /*" -8092- IF WWORK-TELEFONE EQUAL ZEROS */

            if (W_GECLIMOV.WWORK_TELEFONE == 00)
            {

                /*" -8093- MOVE -1 TO VIND-TELEFONE */
                _.Move(-1, VIND_TELEFONE);

                /*" -8094- ELSE */
            }
            else
            {


                /*" -8095- MOVE +0 TO VIND-TELEFONE */
                _.Move(+0, VIND_TELEFONE);

                /*" -8097- MOVE WWORK-TELEFONE TO GECLIMOV-TELEFONE. */
                _.Move(W_GECLIMOV.WWORK_TELEFONE, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TELEFONE);
            }


            /*" -8098- IF WWORK-FAX EQUAL ZEROS */

            if (W_GECLIMOV.WWORK_FAX == 00)
            {

                /*" -8099- MOVE -1 TO VIND-FAX */
                _.Move(-1, VIND_FAX);

                /*" -8100- ELSE */
            }
            else
            {


                /*" -8101- MOVE +0 TO VIND-FAX */
                _.Move(+0, VIND_FAX);

                /*" -8103- MOVE WWORK-FAX TO GECLIMOV-FAX. */
                _.Move(W_GECLIMOV.WWORK_FAX, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_FAX);
            }


            /*" -8104- IF WWORK-CGCCPF EQUAL ZEROS */

            if (W_GECLIMOV.WWORK_CGCCPF == 00)
            {

                /*" -8105- MOVE -1 TO VIND-CGCCPF */
                _.Move(-1, VIND_CGCCPF);

                /*" -8106- ELSE */
            }
            else
            {


                /*" -8107- MOVE +0 TO VIND-CGCCPF */
                _.Move(+0, VIND_CGCCPF);

                /*" -8109- MOVE WWORK-CGCCPF TO GECLIMOV-CGCCPF. */
                _.Move(W_GECLIMOV.WWORK_CGCCPF, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CGCCPF);
            }


            /*" -8110- IF WWORK-DATA-NASCIMENTO EQUAL SPACES */

            if (W_GECLIMOV.WWORK_DATA_NASCIMENTO.IsEmpty())
            {

                /*" -8111- MOVE -1 TO VIND-DTNASC */
                _.Move(-1, VIND_DTNASC);

                /*" -8112- ELSE */
            }
            else
            {


                /*" -8113- MOVE +0 TO VIND-DTNASC */
                _.Move(+0, VIND_DTNASC);

                /*" -8115- MOVE WWORK-DATA-NASCIMENTO TO GECLIMOV-DATA-NASCIMENTO. */
                _.Move(W_GECLIMOV.WWORK_DATA_NASCIMENTO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DATA_NASCIMENTO);
            }


            /*" -8117- MOVE 'VP0601B' TO GECLIMOV-COD-USUARIO */
            _.Move("VP0601B", GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_USUARIO);

            /*" -8118- IF WTEM-GECLIMOV EQUAL 'N' */

            if (WTEM_GECLIMOV == "N")
            {

                /*" -8134- IF VIND-NOME-RAZAO LESS ZEROS AND VIND-TIPO-PESSOA LESS ZEROS AND VIND-IDE-SEXO LESS ZEROS AND VIND-EST-CIVIL LESS ZEROS AND VIND-OCORR-END LESS ZEROS AND VIND-ENDERECO LESS ZEROS AND VIND-BAIRRO LESS ZEROS AND VIND-CIDADE LESS ZEROS AND VIND-SIGLA-UF LESS ZEROS AND VIND-CEP LESS ZEROS AND VIND-DDD LESS ZEROS AND VIND-TELEFONE LESS ZEROS AND VIND-FAX LESS ZEROS AND VIND-CGCCPF LESS ZEROS AND VIND-DTNASC LESS ZEROS NEXT SENTENCE */

                if (VIND_NOME_RAZAO < 00 && VIND_TIPO_PESSOA < 00 && VIND_IDE_SEXO < 00 && VIND_EST_CIVIL < 00 && VIND_OCORR_END < 00 && VIND_ENDERECO < 00 && VIND_BAIRRO < 00 && VIND_CIDADE < 00 && VIND_SIGLA_UF < 00 && VIND_CEP < 00 && VIND_DDD < 00 && VIND_TELEFONE < 00 && VIND_FAX < 00 && VIND_CGCCPF < 00 && VIND_DTNASC < 00)
                {

                    /*" -8135- ELSE */
                }
                else
                {


                    /*" -8136- PERFORM R9400-00-INSERT-GECLIMOV */

                    R9400_00_INSERT_GECLIMOV_SECTION();

                    /*" -8137- ELSE */
                }

            }
            else
            {


                /*" -8137- PERFORM R9450-00-UPDATE-GECLIMOV. */

                R9450_00_UPDATE_GECLIMOV_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9300_99_SAIDA*/

        [StopWatch]
        /*" R9310-00-MAX-GECLIMOV-SECTION */
        private void R9310_00_MAX_GECLIMOV_SECTION()
        {
            /*" -8152- MOVE 'R9310-00-MAX-GECLIMOV' TO PARAGRAFO */
            _.Move("R9310-00-MAX-GECLIMOV", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8153- MOVE 71 TO SII */
            _.Move(71, WS_HORAS.SII);

            /*" -8154- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -8159- PERFORM R9310_00_MAX_GECLIMOV_DB_SELECT_1 */

            R9310_00_MAX_GECLIMOV_DB_SELECT_1();

            /*" -8162- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -8163- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -8164- DISPLAY 'PROBLEMAS NO SELECT MAX (GE_CLIENTES_MOVTO) ' */
                _.Display($"PROBLEMAS NO SELECT MAX (GE_CLIENTES_MOVTO) ");

                /*" -8165- DISPLAY 'CODCLIEN ' GECLIMOV-COD-CLIENTE */
                _.Display($"CODCLIEN {GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_CLIENTE}");

                /*" -8165- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R9310-00-MAX-GECLIMOV-DB-SELECT-1 */
        public void R9310_00_MAX_GECLIMOV_DB_SELECT_1()
        {
            /*" -8159- EXEC SQL SELECT VALUE(MAX(OCORR_HIST), 0) INTO :GECLIMOV-OCORR-HIST FROM SEGUROS.GE_CLIENTES_MOVTO WHERE COD_CLIENTE = :GECLIMOV-COD-CLIENTE END-EXEC. */

            var r9310_00_MAX_GECLIMOV_DB_SELECT_1_Query1 = new R9310_00_MAX_GECLIMOV_DB_SELECT_1_Query1()
            {
                GECLIMOV_COD_CLIENTE = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_CLIENTE.ToString(),
            };

            var executed_1 = R9310_00_MAX_GECLIMOV_DB_SELECT_1_Query1.Execute(r9310_00_MAX_GECLIMOV_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GECLIMOV_OCORR_HIST, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_HIST);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9310_99_SAIDA*/

        [StopWatch]
        /*" R9320-00-SELECT-GECLIMOV-SECTION */
        private void R9320_00_SELECT_GECLIMOV_SECTION()
        {
            /*" -8180- MOVE 'R9320-00-SELECT-GECLIMOV' TO PARAGRAFO */
            _.Move("R9320-00-SELECT-GECLIMOV", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8204- PERFORM R9320_00_SELECT_GECLIMOV_DB_DECLARE_1 */

            R9320_00_SELECT_GECLIMOV_DB_DECLARE_1();

            /*" -8207- MOVE 72 TO SII */
            _.Move(72, WS_HORAS.SII);

            /*" -8208- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -8208- PERFORM R9320_00_SELECT_GECLIMOV_DB_OPEN_1 */

            R9320_00_SELECT_GECLIMOV_DB_OPEN_1();

            /*" -8211- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -8212- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -8213- DISPLAY 'PROBLEMAS NO OPEN (GE_CLIENTES_MOVTO) ... ' */
                _.Display($"PROBLEMAS NO OPEN (GE_CLIENTES_MOVTO) ... ");

                /*" -8214- DISPLAY 'CODCLIEN ' GECLIMOV-COD-CLIENTE */
                _.Display($"CODCLIEN {GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_CLIENTE}");

                /*" -8215- DISPLAY 'OCORR-END-I ' WHOST-OCORR-END-I */
                _.Display($"OCORR-END-I {WHOST_OCORR_END_I}");

                /*" -8216- DISPLAY 'OCORR-END-F ' WHOST-OCORR-END-F */
                _.Display($"OCORR-END-F {WHOST_OCORR_END_F}");

                /*" -8218- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -8219- MOVE 73 TO SII */
            _.Move(73, WS_HORAS.SII);

            /*" -8220- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -8239- PERFORM R9320_00_SELECT_GECLIMOV_DB_FETCH_1 */

            R9320_00_SELECT_GECLIMOV_DB_FETCH_1();

            /*" -8242- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -8243- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -8244- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -8244- PERFORM R9320_00_SELECT_GECLIMOV_DB_CLOSE_1 */

                    R9320_00_SELECT_GECLIMOV_DB_CLOSE_1();

                    /*" -8246- MOVE 'N' TO WTEM-GECLIMOV */
                    _.Move("N", WTEM_GECLIMOV);

                    /*" -8247- ELSE */
                }
                else
                {


                    /*" -8248- DISPLAY 'PROBLEMAS NO FETCH (GE_CLIENTES_MOVTO) ... ' */
                    _.Display($"PROBLEMAS NO FETCH (GE_CLIENTES_MOVTO) ... ");

                    /*" -8249- DISPLAY 'CODCLIEN    ' GECLIMOV-COD-CLIENTE */
                    _.Display($"CODCLIEN    {GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_CLIENTE}");

                    /*" -8250- DISPLAY 'OCORR-END-I ' WHOST-OCORR-END-I */
                    _.Display($"OCORR-END-I {WHOST_OCORR_END_I}");

                    /*" -8251- DISPLAY 'OCORR-END-F ' WHOST-OCORR-END-F */
                    _.Display($"OCORR-END-F {WHOST_OCORR_END_F}");

                    /*" -8252- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -8253- ELSE */
                }

            }
            else
            {


                /*" -8254- MOVE 'S' TO WTEM-GECLIMOV */
                _.Move("S", WTEM_GECLIMOV);

                /*" -8254- PERFORM R9320_00_SELECT_GECLIMOV_DB_CLOSE_2 */

                R9320_00_SELECT_GECLIMOV_DB_CLOSE_2();

                /*" -8255- END-IF. */
            }


        }

        [StopWatch]
        /*" R9320-00-SELECT-GECLIMOV-DB-OPEN-1 */
        public void R9320_00_SELECT_GECLIMOV_DB_OPEN_1()
        {
            /*" -8208- EXEC SQL OPEN C01_GECLIMOV END-EXEC. */

            C01_GECLIMOV.Open();

        }

        [StopWatch]
        /*" R9320-00-SELECT-GECLIMOV-DB-FETCH-1 */
        public void R9320_00_SELECT_GECLIMOV_DB_FETCH_1()
        {
            /*" -8239- EXEC SQL FETCH C01_GECLIMOV INTO :GECLIMOV-TIPO-MOVIMENTO , :GECLIMOV-DATA-ULT-MANUTEN , :GECLIMOV-NOME-RAZAO:VIND-NOME-RAZAO , :GECLIMOV-TIPO-PESSOA:VIND-TIPO-PESSOA , :GECLIMOV-IDE-SEXO:VIND-IDE-SEXO , :GECLIMOV-ESTADO-CIVIL:VIND-EST-CIVIL , :GECLIMOV-OCORR-ENDERECO:VIND-OCORR-END , :GECLIMOV-ENDERECO:VIND-ENDERECO , :GECLIMOV-BAIRRO:VIND-BAIRRO , :GECLIMOV-CIDADE:VIND-CIDADE , :GECLIMOV-SIGLA-UF:VIND-SIGLA-UF , :GECLIMOV-CEP:VIND-CEP , :GECLIMOV-DDD:VIND-DDD , :GECLIMOV-TELEFONE:VIND-TELEFONE , :GECLIMOV-FAX:VIND-FAX , :GECLIMOV-OCORR-HIST , :GECLIMOV-CGCCPF:VIND-CGCCPF , :GECLIMOV-DATA-NASCIMENTO:VIND-DTNASC END-EXEC. */

            if (C01_GECLIMOV.Fetch())
            {
                _.Move(C01_GECLIMOV.GECLIMOV_TIPO_MOVIMENTO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TIPO_MOVIMENTO);
                _.Move(C01_GECLIMOV.GECLIMOV_DATA_ULT_MANUTEN, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DATA_ULT_MANUTEN);
                _.Move(C01_GECLIMOV.GECLIMOV_NOME_RAZAO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_NOME_RAZAO);
                _.Move(C01_GECLIMOV.VIND_NOME_RAZAO, VIND_NOME_RAZAO);
                _.Move(C01_GECLIMOV.GECLIMOV_TIPO_PESSOA, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TIPO_PESSOA);
                _.Move(C01_GECLIMOV.VIND_TIPO_PESSOA, VIND_TIPO_PESSOA);
                _.Move(C01_GECLIMOV.GECLIMOV_IDE_SEXO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_IDE_SEXO);
                _.Move(C01_GECLIMOV.VIND_IDE_SEXO, VIND_IDE_SEXO);
                _.Move(C01_GECLIMOV.GECLIMOV_ESTADO_CIVIL, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_ESTADO_CIVIL);
                _.Move(C01_GECLIMOV.VIND_EST_CIVIL, VIND_EST_CIVIL);
                _.Move(C01_GECLIMOV.GECLIMOV_OCORR_ENDERECO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_ENDERECO);
                _.Move(C01_GECLIMOV.VIND_OCORR_END, VIND_OCORR_END);
                _.Move(C01_GECLIMOV.GECLIMOV_ENDERECO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_ENDERECO);
                _.Move(C01_GECLIMOV.VIND_ENDERECO, VIND_ENDERECO);
                _.Move(C01_GECLIMOV.GECLIMOV_BAIRRO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_BAIRRO);
                _.Move(C01_GECLIMOV.VIND_BAIRRO, VIND_BAIRRO);
                _.Move(C01_GECLIMOV.GECLIMOV_CIDADE, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CIDADE);
                _.Move(C01_GECLIMOV.VIND_CIDADE, VIND_CIDADE);
                _.Move(C01_GECLIMOV.GECLIMOV_SIGLA_UF, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_SIGLA_UF);
                _.Move(C01_GECLIMOV.VIND_SIGLA_UF, VIND_SIGLA_UF);
                _.Move(C01_GECLIMOV.GECLIMOV_CEP, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CEP);
                _.Move(C01_GECLIMOV.VIND_CEP, VIND_CEP);
                _.Move(C01_GECLIMOV.GECLIMOV_DDD, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DDD);
                _.Move(C01_GECLIMOV.VIND_DDD, VIND_DDD);
                _.Move(C01_GECLIMOV.GECLIMOV_TELEFONE, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TELEFONE);
                _.Move(C01_GECLIMOV.VIND_TELEFONE, VIND_TELEFONE);
                _.Move(C01_GECLIMOV.GECLIMOV_FAX, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_FAX);
                _.Move(C01_GECLIMOV.VIND_FAX, VIND_FAX);
                _.Move(C01_GECLIMOV.GECLIMOV_OCORR_HIST, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_HIST);
                _.Move(C01_GECLIMOV.GECLIMOV_CGCCPF, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CGCCPF);
                _.Move(C01_GECLIMOV.VIND_CGCCPF, VIND_CGCCPF);
                _.Move(C01_GECLIMOV.GECLIMOV_DATA_NASCIMENTO, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DATA_NASCIMENTO);
                _.Move(C01_GECLIMOV.VIND_DTNASC, VIND_DTNASC);
            }

        }

        [StopWatch]
        /*" R9320-00-SELECT-GECLIMOV-DB-CLOSE-1 */
        public void R9320_00_SELECT_GECLIMOV_DB_CLOSE_1()
        {
            /*" -8244- EXEC SQL CLOSE C01_GECLIMOV END-EXEC */

            C01_GECLIMOV.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9320_99_SAIDA*/

        [StopWatch]
        /*" R9320-00-SELECT-GECLIMOV-DB-CLOSE-2 */
        public void R9320_00_SELECT_GECLIMOV_DB_CLOSE_2()
        {
            /*" -8254- EXEC SQL CLOSE C01_GECLIMOV END-EXEC */

            C01_GECLIMOV.Close();

        }

        [StopWatch]
        /*" R9400-00-INSERT-GECLIMOV-SECTION */
        private void R9400_00_INSERT_GECLIMOV_SECTION()
        {
            /*" -8267- MOVE 'R9400-00-INSERT-GECLIMOV' TO PARAGRAFO */
            _.Move("R9400-00-INSERT-GECLIMOV", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8271- MOVE 'INSERT GE_CLIENTES_MOVTO' TO COMANDO */
            _.Move("INSERT GE_CLIENTES_MOVTO", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -8272- MOVE 74 TO SII */
            _.Move(74, WS_HORAS.SII);

            /*" -8273- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -8319- PERFORM R9400_00_INSERT_GECLIMOV_DB_INSERT_1 */

            R9400_00_INSERT_GECLIMOV_DB_INSERT_1();

            /*" -8322- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -8324- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL -803 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
            {

                /*" -8325- DISPLAY 'PROBLEMAS NO INSERT (GE_CLIENTES_MOVTO) ... ' */
                _.Display($"PROBLEMAS NO INSERT (GE_CLIENTES_MOVTO) ... ");

                /*" -8326- DISPLAY 'CODCLIEN ' GECLIMOV-COD-CLIENTE */
                _.Display($"CODCLIEN {GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_CLIENTE}");

                /*" -8327- DISPLAY 'OCORHIST ' GECLIMOV-OCORR-HIST */
                _.Display($"OCORHIST {GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_HIST}");

                /*" -8328- DISPLAY 'UF       ' GECLIMOV-SIGLA-UF */
                _.Display($"UF       {GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_SIGLA_UF}");

                /*" -8328- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R9400-00-INSERT-GECLIMOV-DB-INSERT-1 */
        public void R9400_00_INSERT_GECLIMOV_DB_INSERT_1()
        {
            /*" -8319- EXEC SQL INSERT INTO SEGUROS.GE_CLIENTES_MOVTO (COD_CLIENTE , TIPO_MOVIMENTO , DATA_ULT_MANUTEN , NOME_RAZAO , TIPO_PESSOA , IDE_SEXO , ESTADO_CIVIL , OCORR_ENDERECO , ENDERECO , BAIRRO , CIDADE , SIGLA_UF , CEP , DDD , TELEFONE , FAX , OCORR_HIST , CGCCPF , DATA_NASCIMENTO , COD_USUARIO , TIMESTAMP , DES_COMPLEMENTO) VALUES (:GECLIMOV-COD-CLIENTE , :GECLIMOV-TIPO-MOVIMENTO , :GECLIMOV-DATA-ULT-MANUTEN , :GECLIMOV-NOME-RAZAO:VIND-NOME-RAZAO , :GECLIMOV-TIPO-PESSOA:VIND-TIPO-PESSOA , :GECLIMOV-IDE-SEXO:VIND-IDE-SEXO , :GECLIMOV-ESTADO-CIVIL:VIND-EST-CIVIL , :GECLIMOV-OCORR-ENDERECO:VIND-OCORR-END , :GECLIMOV-ENDERECO:VIND-ENDERECO , :GECLIMOV-BAIRRO:VIND-BAIRRO , :GECLIMOV-CIDADE:VIND-CIDADE , :GECLIMOV-SIGLA-UF:VIND-SIGLA-UF , :GECLIMOV-CEP:VIND-CEP , :GECLIMOV-DDD:VIND-DDD , :GECLIMOV-TELEFONE:VIND-TELEFONE , :GECLIMOV-FAX:VIND-FAX , :GECLIMOV-OCORR-HIST , :GECLIMOV-CGCCPF:VIND-CGCCPF , :GECLIMOV-DATA-NASCIMENTO:VIND-DTNASC , :GECLIMOV-COD-USUARIO:VIND-CODUSU , CURRENT TIMESTAMP , NULL) END-EXEC. */

            var r9400_00_INSERT_GECLIMOV_DB_INSERT_1_Insert1 = new R9400_00_INSERT_GECLIMOV_DB_INSERT_1_Insert1()
            {
                GECLIMOV_COD_CLIENTE = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_CLIENTE.ToString(),
                GECLIMOV_TIPO_MOVIMENTO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TIPO_MOVIMENTO.ToString(),
                GECLIMOV_DATA_ULT_MANUTEN = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DATA_ULT_MANUTEN.ToString(),
                GECLIMOV_NOME_RAZAO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_NOME_RAZAO.ToString(),
                VIND_NOME_RAZAO = VIND_NOME_RAZAO.ToString(),
                GECLIMOV_TIPO_PESSOA = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TIPO_PESSOA.ToString(),
                VIND_TIPO_PESSOA = VIND_TIPO_PESSOA.ToString(),
                GECLIMOV_IDE_SEXO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_IDE_SEXO.ToString(),
                VIND_IDE_SEXO = VIND_IDE_SEXO.ToString(),
                GECLIMOV_ESTADO_CIVIL = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_ESTADO_CIVIL.ToString(),
                VIND_EST_CIVIL = VIND_EST_CIVIL.ToString(),
                GECLIMOV_OCORR_ENDERECO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_ENDERECO.ToString(),
                VIND_OCORR_END = VIND_OCORR_END.ToString(),
                GECLIMOV_ENDERECO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_ENDERECO.ToString(),
                VIND_ENDERECO = VIND_ENDERECO.ToString(),
                GECLIMOV_BAIRRO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_BAIRRO.ToString(),
                VIND_BAIRRO = VIND_BAIRRO.ToString(),
                GECLIMOV_CIDADE = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CIDADE.ToString(),
                VIND_CIDADE = VIND_CIDADE.ToString(),
                GECLIMOV_SIGLA_UF = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_SIGLA_UF.ToString(),
                VIND_SIGLA_UF = VIND_SIGLA_UF.ToString(),
                GECLIMOV_CEP = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CEP.ToString(),
                VIND_CEP = VIND_CEP.ToString(),
                GECLIMOV_DDD = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DDD.ToString(),
                VIND_DDD = VIND_DDD.ToString(),
                GECLIMOV_TELEFONE = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TELEFONE.ToString(),
                VIND_TELEFONE = VIND_TELEFONE.ToString(),
                GECLIMOV_FAX = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_FAX.ToString(),
                VIND_FAX = VIND_FAX.ToString(),
                GECLIMOV_OCORR_HIST = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_HIST.ToString(),
                GECLIMOV_CGCCPF = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CGCCPF.ToString(),
                VIND_CGCCPF = VIND_CGCCPF.ToString(),
                GECLIMOV_DATA_NASCIMENTO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DATA_NASCIMENTO.ToString(),
                VIND_DTNASC = VIND_DTNASC.ToString(),
                GECLIMOV_COD_USUARIO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_USUARIO.ToString(),
                VIND_CODUSU = VIND_CODUSU.ToString(),
            };

            R9400_00_INSERT_GECLIMOV_DB_INSERT_1_Insert1.Execute(r9400_00_INSERT_GECLIMOV_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9400_99_SAIDA*/

        [StopWatch]
        /*" R9450-00-UPDATE-GECLIMOV-SECTION */
        private void R9450_00_UPDATE_GECLIMOV_SECTION()
        {
            /*" -8343- MOVE 'R9450-00-UPDATE-GECLIMOV' TO PARAGRAFO */
            _.Move("R9450-00-UPDATE-GECLIMOV", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8344- MOVE 75 TO SII */
            _.Move(75, WS_HORAS.SII);

            /*" -8345- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -8369- PERFORM R9450_00_UPDATE_GECLIMOV_DB_UPDATE_1 */

            R9450_00_UPDATE_GECLIMOV_DB_UPDATE_1();

            /*" -8372- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -8373- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -8374- DISPLAY 'PROBLEMAS NO UPDATE (GE_CLIENTES_MOVTO) ... ' */
                _.Display($"PROBLEMAS NO UPDATE (GE_CLIENTES_MOVTO) ... ");

                /*" -8375- DISPLAY 'CODCLIEN ' GECLIMOV-COD-CLIENTE */
                _.Display($"CODCLIEN {GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_CLIENTE}");

                /*" -8376- DISPLAY 'OCORHIST ' GECLIMOV-OCORR-HIST */
                _.Display($"OCORHIST {GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_HIST}");

                /*" -8376- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R9450-00-UPDATE-GECLIMOV-DB-UPDATE-1 */
        public void R9450_00_UPDATE_GECLIMOV_DB_UPDATE_1()
        {
            /*" -8369- EXEC SQL UPDATE SEGUROS.GE_CLIENTES_MOVTO SET TIPO_MOVIMENTO = :GECLIMOV-TIPO-MOVIMENTO, DATA_ULT_MANUTEN = :GECLIMOV-DATA-ULT-MANUTEN, NOME_RAZAO = :GECLIMOV-NOME-RAZAO:VIND-NOME-RAZAO, TIPO_PESSOA = :GECLIMOV-TIPO-PESSOA:VIND-TIPO-PESSOA, IDE_SEXO = :GECLIMOV-IDE-SEXO:VIND-IDE-SEXO, ESTADO_CIVIL = :GECLIMOV-ESTADO-CIVIL:VIND-EST-CIVIL, OCORR_ENDERECO = :GECLIMOV-OCORR-ENDERECO:VIND-OCORR-END, ENDERECO = :GECLIMOV-ENDERECO:VIND-ENDERECO, BAIRRO = :GECLIMOV-BAIRRO:VIND-BAIRRO, CIDADE = :GECLIMOV-CIDADE:VIND-CIDADE, SIGLA_UF = :GECLIMOV-SIGLA-UF:VIND-SIGLA-UF, CEP = :GECLIMOV-CEP:VIND-CEP , DDD = :GECLIMOV-DDD:VIND-DDD , TELEFONE = :GECLIMOV-TELEFONE:VIND-TELEFONE , FAX = :GECLIMOV-FAX:VIND-FAX , CGCCPF = :GECLIMOV-CGCCPF:VIND-CGCCPF , DATA_NASCIMENTO = :GECLIMOV-DATA-NASCIMENTO:VIND-DTNASC, COD_USUARIO = :GECLIMOV-COD-USUARIO , TIMESTAMP = CURRENT TIMESTAMP WHERE COD_CLIENTE = :GECLIMOV-COD-CLIENTE AND OCORR_HIST = :GECLIMOV-OCORR-HIST END-EXEC. */

            var r9450_00_UPDATE_GECLIMOV_DB_UPDATE_1_Update1 = new R9450_00_UPDATE_GECLIMOV_DB_UPDATE_1_Update1()
            {
                GECLIMOV_OCORR_ENDERECO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_ENDERECO.ToString(),
                VIND_OCORR_END = VIND_OCORR_END.ToString(),
                GECLIMOV_TIPO_PESSOA = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TIPO_PESSOA.ToString(),
                VIND_TIPO_PESSOA = VIND_TIPO_PESSOA.ToString(),
                GECLIMOV_ESTADO_CIVIL = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_ESTADO_CIVIL.ToString(),
                VIND_EST_CIVIL = VIND_EST_CIVIL.ToString(),
                GECLIMOV_DATA_NASCIMENTO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DATA_NASCIMENTO.ToString(),
                VIND_DTNASC = VIND_DTNASC.ToString(),
                GECLIMOV_NOME_RAZAO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_NOME_RAZAO.ToString(),
                VIND_NOME_RAZAO = VIND_NOME_RAZAO.ToString(),
                GECLIMOV_IDE_SEXO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_IDE_SEXO.ToString(),
                VIND_IDE_SEXO = VIND_IDE_SEXO.ToString(),
                GECLIMOV_ENDERECO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_ENDERECO.ToString(),
                VIND_ENDERECO = VIND_ENDERECO.ToString(),
                GECLIMOV_SIGLA_UF = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_SIGLA_UF.ToString(),
                VIND_SIGLA_UF = VIND_SIGLA_UF.ToString(),
                GECLIMOV_TELEFONE = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TELEFONE.ToString(),
                VIND_TELEFONE = VIND_TELEFONE.ToString(),
                GECLIMOV_BAIRRO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_BAIRRO.ToString(),
                VIND_BAIRRO = VIND_BAIRRO.ToString(),
                GECLIMOV_CIDADE = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CIDADE.ToString(),
                VIND_CIDADE = VIND_CIDADE.ToString(),
                GECLIMOV_CGCCPF = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CGCCPF.ToString(),
                VIND_CGCCPF = VIND_CGCCPF.ToString(),
                GECLIMOV_DATA_ULT_MANUTEN = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DATA_ULT_MANUTEN.ToString(),
                GECLIMOV_TIPO_MOVIMENTO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TIPO_MOVIMENTO.ToString(),
                GECLIMOV_CEP = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_CEP.ToString(),
                VIND_CEP = VIND_CEP.ToString(),
                GECLIMOV_DDD = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DDD.ToString(),
                VIND_DDD = VIND_DDD.ToString(),
                GECLIMOV_FAX = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_FAX.ToString(),
                VIND_FAX = VIND_FAX.ToString(),
                GECLIMOV_COD_USUARIO = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_USUARIO.ToString(),
                GECLIMOV_COD_CLIENTE = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_COD_CLIENTE.ToString(),
                GECLIMOV_OCORR_HIST = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_OCORR_HIST.ToString(),
            };

            R9450_00_UPDATE_GECLIMOV_DB_UPDATE_1_Update1.Execute(r9450_00_UPDATE_GECLIMOV_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9450_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-INICIO-SECTION */
        private void R9000_00_INICIO_SECTION()
        {
            /*" -8385- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -8386- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100). */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9100-00-TERMINO-SECTION */
        private void R9100_00_TERMINO_SECTION()
        {
            /*" -8395- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -8396- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -8397- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -8398- ADD SFT TO STT(SII) */
            TOTAIS_ROT.FILLER_1[WS_HORAS.SII].STT.Value = TOTAIS_ROT.FILLER_1[WS_HORAS.SII].STT + WS_HORAS.SFT;

            /*" -8399- ADD 1 TO SQT(SII). */
            TOTAIS_ROT.FILLER_1[WS_HORAS.SII].SQT.Value = TOTAIS_ROT.FILLER_1[WS_HORAS.SII].SQT + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9100_99_SAIDA*/

        [StopWatch]
        /*" R9900-00-MOSTRA-TOTAIS-SECTION */
        private void R9900_00_MOSTRA_TOTAIS_SECTION()
        {
            /*" -8408- DISPLAY ' ' . */
            _.Display($" ");

            /*" -8409- MOVE ZEROS TO SII. */
            _.Move(0, WS_HORAS.SII);

            /*" -0- FLUXCONTROL_PERFORM R9900_10_MOSTRA_TOTAIS */

            R9900_10_MOSTRA_TOTAIS();

        }

        [StopWatch]
        /*" R9900-10-MOSTRA-TOTAIS */
        private void R9900_10_MOSTRA_TOTAIS(bool isPerform = false)
        {
            /*" -8414- ADD 1 TO SII. */
            WS_HORAS.SII.Value = WS_HORAS.SII + 1;

            /*" -8415- IF SII < 79 */

            if (WS_HORAS.SII < 79)
            {

                /*" -8416- MOVE STT(SII) TO STT-DISP */
                _.Move(TOTAIS_ROT.FILLER_1[WS_HORAS.SII].STT, WS_HORAS.STT_DISP);

                /*" -8418- DISPLAY 'PARAGRAFO:' SII ' TOTAL= ' STT-DISP ' QTDE= ' SQT(SII) */

                $"PARAGRAFO:{WS_HORAS.SII} TOTAL= {WS_HORAS.STT_DISP} QTDE= {TOTAIS_ROT.FILLER_1[WS_HORAS.SII]}"
                .Display();

                /*" -8420- GO TO R9900-10-MOSTRA-TOTAIS. */
                new Task(() => R9900_10_MOSTRA_TOTAIS()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -8421- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/

        [StopWatch]
        /*" DISPLAY-PROP-VA-SECTION */
        private void DISPLAY_PROP_VA_SECTION()
        {
            /*" -8427- DISPLAY 'DADOS DO INSERT DA PROPOSTAS_VA ---------------' */
            _.Display($"DADOS DO INSERT DA PROPOSTAS_VA ---------------");

            /*" -8428- DISPLAY 'NUM_CERTIFICADO    = ' PROPOFID-NUM-PROPOSTA-SIVPF */
            _.Display($"NUM_CERTIFICADO    = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

            /*" -8429- DISPLAY 'COD_PRODUTO        = ' PRODUVG-COD-PRODUTO */
            _.Display($"COD_PRODUTO        = {PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO}");

            /*" -8430- DISPLAY 'COD_CLIENTE        = ' COD-CLIENTE OF DCLCLIENTES */
            _.Display($"COD_CLIENTE        = {CLIENTE.DCLCLIENTES.COD_CLIENTE}");

            /*" -8431- DISPLAY 'OCOREND            = ' ENDERECO-OCORR-ENDERECO */
            _.Display($"OCOREND            = {ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO}");

            /*" -8432- DISPLAY 'COD_FONTE          = ' WHOST-FONTE */
            _.Display($"COD_FONTE          = {WHOST_FONTE}");

            /*" -8433- DISPLAY 'AGE_COBRANCA       = ' PROPOFID-AGECOBR */
            _.Display($"AGE_COBRANCA       = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR}");

            /*" -8434- DISPLAY 'OPCAO_COBERTURA    = ' PROPOFID-OPCAO-COBER */
            _.Display($"OPCAO_COBERTURA    = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER}");

            /*" -8435- DISPLAY 'DATA_QUITACAO      = ' PROPOFID-DTQITBCO */
            _.Display($"DATA_QUITACAO      = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO}");

            /*" -8436- DISPLAY 'COD_AGE_VENDEDOR   = ' PROPOFID-AGECTAVEN */
            _.Display($"COD_AGE_VENDEDOR   = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTAVEN}");

            /*" -8437- DISPLAY 'OPE_CONTA_VENDEDOR = ' PROPOFID-OPRCTAVEN */
            _.Display($"OPE_CONTA_VENDEDOR = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTAVEN}");

            /*" -8438- DISPLAY 'NUM_CONTA_VENDEDOR = ' PROPOFID-NUMCTAVEN */
            _.Display($"NUM_CONTA_VENDEDOR = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTAVEN}");

            /*" -8439- DISPLAY 'DIG_CONTA_VENDEDOR = ' PROPOFID-DIGCTAVEN */
            _.Display($"DIG_CONTA_VENDEDOR = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTAVEN}");

            /*" -8440- DISPLAY 'NUM_MATRI_VENDEDOR = ' PROPOFID-NRMATRVEN */
            _.Display($"NUM_MATRI_VENDEDOR = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN}");

            /*" -8441- DISPLAY 'COD_OPERACAO       = 106' */
            _.Display($"COD_OPERACAO       = 106");

            /*" -8442- DISPLAY 'PROFISSAO          = ' WHOST-PROFISSAO */
            _.Display($"PROFISSAO          = {WHOST_PROFISSAO}");

            /*" -8443- DISPLAY 'DTINCLUS           = ' SISTEMAS-DATA-MOV-ABERTO */
            _.Display($"DTINCLUS           = {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -8444- DISPLAY 'DATA_MOVIMENTO     = ' SISTEMAS-DATA-MOV-ABERTO */
            _.Display($"DATA_MOVIMENTO     = {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -8445- DISPLAY 'SIT_REGISTRO       = ' WHOST-SIT-REGISTRO */
            _.Display($"SIT_REGISTRO       = {WHOST_SIT_REGISTRO}");

            /*" -8446- DISPLAY 'NUM_APOLICE        = ' PROPSSVD-NUM-APOLICE */
            _.Display($"NUM_APOLICE        = {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE}");

            /*" -8447- DISPLAY 'COD_SUBGRUPO       = ' PROPSSVD-COD-SUBGRUPO */
            _.Display($"COD_SUBGRUPO       = {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO}");

            /*" -8448- DISPLAY 'OCORR_HISTORICO    = 1' */
            _.Display($"OCORR_HISTORICO    = 1");

            /*" -8449- DISPLAY 'NRPRIPARATZ        = 0' */
            _.Display($"NRPRIPARATZ        = 0");

            /*" -8450- DISPLAY 'QTDPARATZ          = 0' */
            _.Display($"QTDPARATZ          = 0");

            /*" -8451- DISPLAY 'DTPROXVEN          = ' WHOST-DTPROXVEN */
            _.Display($"DTPROXVEN          = {WHOST_DTPROXVEN}");

            /*" -8452- DISPLAY 'NUM_PARCELA        = 1' */
            _.Display($"NUM_PARCELA        = 1");

            /*" -8453- DISPLAY 'DATA_VENCIMENTO    = ' PROPOFID-DTQITBCO */
            _.Display($"DATA_VENCIMENTO    = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO}");

            /*" -8454- DISPLAY 'SIT_INTERFACE      = 0' */
            _.Display($"SIT_INTERFACE      = 0");

            /*" -8455- DISPLAY 'DTFENAE            = ' SISTEMAS-DATA-MOV-ABERTO */
            _.Display($"DTFENAE            = {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -8456- DISPLAY 'COD_USUARIO        = VP0601B' */
            _.Display($"COD_USUARIO        = VP0601B");

            /*" -8457- DISPLAY 'TIMESTAMP          = CURRENT TIMESTAMP' */
            _.Display($"TIMESTAMP          = CURRENT TIMESTAMP");

            /*" -8458- DISPLAY 'IDADE              = ' WHOST-IDADE, */
            _.Display($"IDADE              = {WHOST_IDADE}");

            /*" -8459- DISPLAY 'IDE_SEXO           = ' SEXO OF DCLPESSOA-FISICA */
            _.Display($"IDE_SEXO           = {PESFIS.DCLPESSOA_FISICA.SEXO}");

            /*" -8461- DISPLAY 'ESTADO_CIVIL       = ' ESTADO-CIVIL OF DCLPESSOA-FISICA */
            _.Display($"ESTADO_CIVIL       = {PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL}");

            /*" -8462- DISPLAY 'OPCAO_MARCADA      = NULL' */
            _.Display($"OPCAO_MARCADA      = NULL");

            /*" -8463- DISPLAY 'SIGLA_CRM          = NULL' */
            _.Display($"SIGLA_CRM          = NULL");

            /*" -8464- DISPLAY 'COD_CRM            = NULL' */
            _.Display($"COD_CRM            = NULL");

            /*" -8465- DISPLAY 'APOS_INVALIDEZ     = ' PROPSSVD-APOS-INVALIDEZ */
            _.Display($"APOS_INVALIDEZ     = {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_APOS_INVALIDEZ}");

            /*" -8466- DISPLAY 'ASSINATURA         = ' */
            _.Display($"ASSINATURA         = ");

            /*" -8467- DISPLAY 'ACATAMENTO         = ' */
            _.Display($"ACATAMENTO         = ");

            /*" -8468- DISPLAY 'NOME_ESPOSA        = ' PROPOFID-NOME-CONJUGE */
            _.Display($"NOME_ESPOSA        = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NOME_CONJUGE}");

            /*" -8469- DISPLAY 'DTNASC_ESPOSA      = ' PROPOFID-DATA-NASC-CONJUGE */
            _.Display($"DTNASC_ESPOSA      = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_NASC_CONJUGE}");

            /*" -8470- DISPLAY 'PROFIS_ESPOSA      = ' WHOST-PROFISSAO-CONJUGE */
            _.Display($"PROFIS_ESPOSA      = {WHOST_PROFISSAO_CONJUGE}");

            /*" -8471- DISPLAY 'DPS_TITULAR        = ' PROPSSVD-DPS-TITULAR */
            _.Display($"DPS_TITULAR        = {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_TITULAR}");

            /*" -8472- DISPLAY 'DPS_ESPOSA         = ' PROPSSVD-DPS-CONJUGE */
            _.Display($"DPS_ESPOSA         = {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_CONJUGE}");

            /*" -8473- DISPLAY 'NUM_MATRICULA      = NULL' */
            _.Display($"NUM_MATRICULA      = NULL");

            /*" -8474- DISPLAY 'GRAU_PARENTESCO    = NULL' */
            _.Display($"GRAU_PARENTESCO    = NULL");

            /*" -8475- DISPLAY 'DATA_ADMISSAO      = NULL' */
            _.Display($"DATA_ADMISSAO      = NULL");

            /*" -8476- DISPLAY 'NUM_PROPOSTA       = NULL' */
            _.Display($"NUM_PROPOSTA       = NULL");

            /*" -8477- DISPLAY 'EM_ATIVIDADE       = NULL' */
            _.Display($"EM_ATIVIDADE       = NULL");

            /*" -8478- DISPLAY 'LOC_ATIVIDADE      = NULL' */
            _.Display($"LOC_ATIVIDADE      = NULL");

            /*" -8479- DISPLAY 'INFO_COMPLEMENTAR  = ' WHOST-INFO-COMPL */
            _.Display($"INFO_COMPLEMENTAR  = {WHOST_INFO_COMPL}");

            /*" -8480- DISPLAY 'NRMALADIR          = NULL' */
            _.Display($"NRMALADIR          = NULL");

            /*" -8481- DISPLAY 'NRCERTIFANT        = NULL' */
            _.Display($"NRCERTIFANT        = NULL");

            /*" -8482- DISPLAY 'COD_CCT            = ' PROPOFID-CGC-CONVENENTE */
            _.Display($"COD_CCT            = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CGC_CONVENENTE}");

            /*" -8483- DISPLAY 'FAIXA_RENDA_IND    = ' PROPOFID-FAIXA-RENDA-IND */
            _.Display($"FAIXA_RENDA_IND    = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_IND}");

            /*" -8484- DISPLAY 'FAIXA_RENDA_FAM    = ' PROPOFID-FAIXA-RENDA-FAM */
            _.Display($"FAIXA_RENDA_FAM    = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_FAM}");

            /*" -8485- DISPLAY 'NUM_CONTR_VINCULO  = ' PROPSSVD-NUM-CONTR-VINCULO */
            _.Display($"NUM_CONTR_VINCULO  = {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_CONTR_VINCULO}");

            /*" -8486- DISPLAY 'COD_CORRESP_BANC   = ' PROPSSVD-COD-CORRESP-BANC */
            _.Display($"COD_CORRESP_BANC   = {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_CORRESP_BANC}");

            /*" -8487- DISPLAY 'COD_ORIGEM_PROPOSTA= ' PROPOFID-ORIGEM-PROPOSTA */
            _.Display($"COD_ORIGEM_PROPOSTA= {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA}");

            /*" -8488- DISPLAY 'NUM_PRAZO_FIN      = ' PROPSSVD-NUM-PRAZO-FIN */
            _.Display($"NUM_PRAZO_FIN      = {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_PRAZO_FIN}");

            /*" -8489- DISPLAY 'COD_OPER_CREDITO   = ' PROPSSVD-COD-OPER-CREDITO */
            _.Display($"COD_OPER_CREDITO   = {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_OPER_CREDITO}");

            /*" -8490- DISPLAY '-----------------------------------------------' */
            _.Display($"-----------------------------------------------");

            /*" -8490- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: RPROP_VA_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -8500- PERFORM R9900-00-MOSTRA-TOTAIS */

            R9900_00_MOSTRA_TOTAIS_SECTION();

            /*" -8501- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_ABEND.WABEND.WSQLCODE);

            /*" -8502- MOVE SQLCODE TO RETURN-CODE. */
            _.Move(DB.SQLCODE, RETURN_CODE);

            /*" -8503- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], AREA_ABEND.WABEND.WSQLERRD1);

            /*" -8504- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], AREA_ABEND.WABEND.WSQLERRD2);

            /*" -8505- DISPLAY WABEND. */
            _.Display(AREA_ABEND.WABEND);

            /*" -8506- DISPLAY LOCALIZA-ABEND-1. */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1);

            /*" -8508- DISPLAY LOCALIZA-ABEND-2. */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_2);

            /*" -8509- MOVE SQLERRMC TO WSQLERRMC */
            _.Move(DB.SQLERRMC, AREA_ABEND.WSQLERRO.WSQLERRMC);

            /*" -8511- DISPLAY WSQLERRO */
            _.Display(AREA_ABEND.WSQLERRO);

            /*" -8515- DISPLAY 'PROPOSTA ' PROPOFID-NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ. */
            _.Display($"PROPOSTA {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

            /*" -8515- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -8517- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -8521- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -8521- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}