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
using Sias.VidaEmGrupo.DB2.VP0121B;

namespace Code
{
    public class VP0121B
    {
        public bool IsCall { get; set; }

        public VP0121B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *   FUNCAO .................  INTEGRA V0PROPOSTAVA PARA PRODUTO  *      */
        /*"      *                             PRESTAMISTA - COPIA DO VA0118B     *      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA/PROGRAMADOR....  FONSECA/FAST COMPUTER              *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  VP0121B                            *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  09/11/2009                         *      */
        /*"      ******************************************************************      */
        /*"      *                         ALTERACOES                             *      */
        /*"JV181 *----------------------------------------------------------------*      */
        /*"JV181 *VERSAO 81: JV1 DEMANDA 259990 - KINKAS 10/09/2020               *      */
        /*"JV181 *           INCLUI/EXCLUI APOLICES E PRODUTOS JV1                *      */
        /*"JV181 *           - PROCURAR POR JV181                                 *      */
        /*"JV181 *----------------------------------------------------------------*      */
        /*"      *   VERSAO 80 - HISTORIA 250.247                                 *      */
        /*"      *                                                                *      */
        /*"      *             - ALTERACAO DO CODIGO DO PARCEIRO DA CAPITALIZACAO,*      */
        /*"      *               DE CAIXA SEGUROS (01) PARA CAIXA VIDA E          *      */
        /*"      *               PREVIDENCIA (03).                                *      */
        /*"      *                                                                *      */
        /*"      *   EM 24/12/2019 - LUIZ FERNANDO GONÇALVES                      *      */
        /*"      *                                                                *      */
        /*"      *                                        PROCURE POR V.80        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 79 -  JOAO ARAUJO                                            */
        /*"      *               - PREPARAR PROGRAMA PARA PROCESSAMENTO DA JV1    *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/01/2019 - MBRA                                         *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR JV1          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 78                                                          */
        /*"      * MOTIVO  : AVERBACAO PRESTAMISTA PJ PRODUTO 7732/7733                  */
        /*"      *           APOLICE 107700000067/107700000068                           */
        /*"      *           PRODUTO CESTA DE SERVICOS                                   */
        /*"      * CADMUS  : 151597                                                      */
        /*"      * DATA    : 22/08/2017                                                  */
        /*"      * NOME    : DIOGO MATHEUS                                               */
        /*"      * MARCADOR: V.78                                                        */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 77                                                          */
        /*"      * MOTIVO  : RETIRAR PEDIDO DE EMISSAO DE CERTIFICADO AUTOMATICA         */
        /*"      *           PARA O 7705. PARA ESSE PRODUTO EMISSAO DO CERTIFICADO       */
        /*"      *           SERA A PEDIDO VIA SIAS.                                     */
        /*"      * CADMUS  : 148672                                                      */
        /*"      * DATA    : 11/05/2017                                                  */
        /*"      * NOME    : DIOGO MATHEUS                                               */
        /*"      * MARCADOR: V.77                                                        */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 76                                                          */
        /*"      * MOTIVO  : VOLTAR VERSAO ANTERIOR PARA NAO PEGAR ALTERACOES DO         */
        /*"      *           RAMO 37 (NA VERSAO 74/75)                                   */
        /*"      * CADMUS  : 134954                                                      */
        /*"      * DATA    : 11/04/2016                                                  */
        /*"      * NOME    : DIOGO MATHEUS                                               */
        /*"      * MARCADOR: V.76                                                        */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 73                                                          */
        /*"      * MOTIVO  : AVERBACAO PRESTAMISTA PJ PRODUTO 7725                       */
        /*"      *           APOLICE 107700000056                                        */
        /*"      * CADMUS  : 124561                                                      */
        /*"      * DATA    : 29/10/2015                                                  */
        /*"      * NOME    : DIOGO MATHEUS                                               */
        /*"      * MARCADOR: V.73                                                        */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 72                                                          */
        /*"      * MOTIVO  : INCLUIR OPERACAO CDC PRESTAMISTA NO PRODUTO 7707            */
        /*"      *           TE LIGO APOLICE 107700000013                                */
        /*"      * CADMUS  : 104520                                                      */
        /*"      * DATA    : 10/07/2015                                                  */
        /*"      * NOME    : DIOGO MATHEUS                                               */
        /*"      * MARCADOR: V.72                                                        */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 71 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 24/10/2014 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.71         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 70                                                          */
        /*"      * MOTIVO  : DESCONSIDERAR VERSÃO 69 PARA AJUSTE DAS PROPOSTAS COM       */
        /*"      *           BOLETOS DUPLICADOS                                          */
        /*"      * CADMUS  : 93548                                                       */
        /*"      * DATA    : 24/03/2014                                                  */
        /*"      * NOME    : GIOVANI CUNHA                                               */
        /*"      * MARCADOR: V.70                                                        */
        /*"      * VERSAO  : 70                                                          */
        /*"      *----------------------------------------------------------------*      */
        /*"      * MOTIVO  : TRATAMENTO DE ABEND NO UPDATE DA CONVERSAO_SICOB            */
        /*"      *           (BOLETOS DUPLICADOS - DESCONSIDERAR PROPOSTAS)              */
        /*"      * CADMUS  : 95452                                                       */
        /*"      * DATA    : 18/03/2014                                                  */
        /*"      * NOME    : KATIA FERREIRA                                              */
        /*"      * MARCADOR: V.69                                                        */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 68                                                          */
        /*"      * MOTIVO  : PONTUAL - AJUSTE PARA EMISSAO CORRETA DOS CERTIFICADOS      */
        /*"      *           (BOLETOS DUPLICADOS)                                        */
        /*"      * CADMUS  : 93548                                                       */
        /*"      * DATA    : 12/03/2014                                                  */
        /*"      * NOME    : GIOVANI CUNHA                                               */
        /*"      * MARCADOR: V.68                                                        */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 67                                                          */
        /*"      * MOTIVO  : CORRECAO DE NAO EMISSAO INDEVIDA                            */
        /*"      * DATA    : 10/01/2014                                                  */
        /*"      * NOME    : GIOVANI CUNHA                                               */
        /*"      * MARCADOR: V.67                                                        */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 66                                                          */
        /*"      * MOTIVO  : NOVO PRODUTO 7715 - PRESTAMISTA MICROCREDITO BALCAO         */
        /*"      * CADMUS  : 90195                                                       */
        /*"      * DATA    : 16/11/2013                                                  */
        /*"      * NOME    : GIOVANI CUNHA                                               */
        /*"      * MARCADOR: V.66                                                        */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        /*"      *   VERSAO 65 - CAD 81.156                                       *      */
        /*"      *                                                                *      */
        /*"      *             - ADEQUACOES PROJETO CRESCER - MICROCREDITO        *      */
        /*"      *                                                                *      */
        /*"      *   EM 23/04/2013 - ROMINA BRANCO                                *      */
        /*"      *                                            PROCURE POR V.65    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        /*"      *   VERSAO 64 - CAD 70.534                                       *      */
        /*"      *                                                                *      */
        /*"      *             - RETIRAR CRITICAS PARA OS PRODUTOS 7705 E 7707    *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/06/2012 - MARCELO NEVES                                *      */
        /*"      *                                            PROCURE POR V.64    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        /*"      *   VERSAO 63 - CAD 67.453                                       *      */
        /*"      *                                                                *      */
        /*"      *             - A APLICACAO ESTA REALIZANDO CRITICA INDEVIDAMENTE*      */
        /*"      *               DE DPS PARA PRESTAMISTA                          *      */
        /*"      *                                                                *      */
        /*"      *   EM 12/03/2012 - RILDO SICO                                   *      */
        /*"      *                                            PROCURE POR V.63    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        /*"      *   VERSAO 62 - CAD 66.209                                       *      */
        /*"      *                                                                *      */
        /*"      *              -CORRECAO ABEND SQLCODE 100 NO ACESSO             *      */
        /*"      *      Á 1110-VERIFICA-RCAP.                                     *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/01/2012 - CLAUDIO FREITAS      (FAST COMPUTER)         *      */
        /*"      *                                            PROCURE POR V.62    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        /*"      *   VERSAO 61 - CAD 57.705                                       *      */
        /*"      *                                                                *      */
        /*"      *              - SERA TRATADA NESTA ALTERACAO O REGISTRO TIPO    *      */
        /*"      *                " $ ". REGISTRO ORIUNDO DO AIC, PARA INCLUSAO   *      */
        /*"      *                DO NUMERO CRIADO PARA O CREDMINAS (756) NA      *      */
        /*"      *                TABELA CONVERSAO_SICOB E PROPOSTA_FIDELIZ.      *      */
        /*"      *                PASSARA A RECUPERAR DA RCAPS COM O NUMERO       *      */
        /*"      *                NRMATRVEN DA PROPOSTA_FIDELIZ.                  *      */
        /*"      *                                                                *      */
        /*"      *   EM 21/08/2011 - EDIVALDO GOMES(FAST COMPUTER)                *      */
        /*"      *                                            PROCURE POR V.61    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 60                                                    *      */
        /*"      *             - CAD  201.122                                     *      */
        /*"      *               INSERIR COLUNAS NA CLAUSULA INSERT DAS TABELAS   *      */
        /*"      *               HIST_LANC_CTA OU V0HISTCONTAVA.                  *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/07/2011 - LOPES          (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.60             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 59 - CAD 52.318                                       *      */
        /*"      *                                                                *      */
        /*"      *              - AJUSTE NO PROGRAMA PARA EMISSAO INDEVIDA DO     *      */
        /*"      *                PRODUTO 7705.                                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 25/03/2011 - MARCO PAIVA (FAST COMPUTER)                  *      */
        /*"      *                                            PROCURE POR V.59    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 58 - CAD 44.763                                       *      */
        /*"      *                                                                *      */
        /*"      *              - NOVO CALCULO DE PREMIO POR ALIQUOTAS E NOVAS    *      */
        /*"      *                CRITICAS PARA O PRODUTO 7705.                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/08/2010 - EDIVALDO GOMES(FAST COMPUTER)                *      */
        /*"      *                                            PROCURE POR V.58    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 57 - CAD 41.644                                       *      */
        /*"      *               NAO GERAR O ERRO 102 PARA O PRODUTO CREDIMINAS   *      */
        /*"      *                                                                *      */
        /*"      *   EM 27/04/2010 - MARCO PAIVA    (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.57         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 56 - CAD 38.728                                       *      */
        /*"      *               NAO GERAR COMISSAO PARA O AIC.                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 15/03/2010 - TERCIO FREITAS (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.56         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 55 - CAD 31.471                                       *      */
        /*"      *               VERSAO DE PROGRAMA CRIADO A PARTIR DO VA0118B    *      */
        /*"      *               COM A FINALIDADE DE PROCESSAR SOMENTEO O PRODUTO *      */
        /*"      *               PRESTAMISTA.                                     *      */
        /*"      *                                                                *      */
        /*"      *   EM 09/11/2009 - FAST COMPUTER       PROCURE POR V.55         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 54                                                    *      */
        /*"      *             - CAD 28.944                                       *      */
        /*"      *               CRIADA A FUNCIONALIDADE PARA HABILITAR A MODA -  *      */
        /*"      *               LIDADE DE PAGAMENTO DE CARTAO DE CREDITO.        *      */
        /*"      *                                                                *      */
        /*"      *   EM 03/09/2009 - MARCO PAIVA (FAST COMPUTER)                  *      */
        /*"      *                                       PROCURE POR V.54         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 53                                                    *      */
        /*"      *             - CAD 26.612                                       *      */
        /*"      *               PASSA A NAO MAIS SOLICITAR A COMPRA DE TITULOS   *      */
        /*"      *               CAPITALIZACAO.                                   *      */
        /*"      *                                                                *      */
        /*"      *               A FUNCIONALIDADE SERA DESEMPENHADA PELO PROGRAMA *      */
        /*"      *               VA0197B QUE SERA EXECUTADO NA ROTINA JPVAD10     *      */
        /*"      *               QUE SERA EXECUTADA APOS A ROTINA JPFCD00 DA      *      */
        /*"      *               CAIXA CAPITALIZACAO.                             *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/07/2009 - FAST COMPUTER            PROCURE POR V.53    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 52                                                    *      */
        /*"      *             - CAD 24.543                                       *      */
        /*"      *               NAO INCLUIR NA TABELA V0FUNDOCOMISVA  PARA OS    *      */
        /*"      *               CERTIFICADOS QUE FORAM INCLUIDOS MANUALMENTE     *      */
        /*"      *               (RETENCAO)                                       *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/06/2009 - FAST COMPUTER            PROCURE POR V.52    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 51                                                    *      */
        /*"      *             - CAD 25.176                                       *      */
        /*"      *               NAO INCLUIR NA TABELA V0FUNDOCOMISVA  PARA OS    *      */
        /*"      *               CERTIFICADOS QUE FORAM INCLUIDOS MANUALMENTE     *      */
        /*"      *               (RETENCAO)                                       *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/06/2009 - FAST COMPUTER            PROCURE POR V.51    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 50                                                    *      */
        /*"      *             - CAD 24.545                                       *      */
        /*"      *               NOVO PRODUTO PRESTAMISTA 7707                    *      */
        /*"      *                                                                *      */
        /*"      *   EM 21/05/2009 - FAST COMPUTER            PROCURE POR V.50    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 49                                                    *      */
        /*"      *             - CAD 22.910                                       *      */
        /*"      *               NOVO PRODUTO PRESTAMISTA                         *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/04/2009 - FAST COMPUTER            PROCURE POR V.49    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 48                                                    *      */
        /*"      *             - CAD 21.756                                       *      */
        /*"      *               MUDANCA NOS PRODUTOS ACOPLADOS COM CAPITALIZACAO *      */
        /*"      *               PARA ATENDER A CIRCULAR SUSEP                    *      */
        /*"      *               CIRCULAR 365 DE 27 DE MAIO DE 2008               *      */
        /*"      *                                                                *      */
        /*"      *             - FOI INIBIDA A COMPRA PARA O EXCLUSIVO PORQUE A   *      */
        /*"      *               SERIE ATUAL VENCE APENAS EM AGOSTO DE 2009 E     *      */
        /*"      *               O CONSUMO DO PLANO 812 AGORA DEVERA GERAR CUSTO  *      */
        /*"      *               DESNECESSARIO PARA A CAIXA SEGUROS.              *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/03/2009 - FAST COMPUTER            PROCURE POR V.48    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 47                                                    *      */
        /*"      *             - CAD 19.097                                       *      */
        /*"      *               CALCULA A COMISSAO PARA OS PRODUTOS              *      */
        /*"      *               9335 - EXCLUSIVO - COPESP - MENSAL               *      */
        /*"      *               9336 - EXCLUSIVO - COPESP - ANUAL                *      */
        /*"      *               9337 - EXCLUSIVO - CACB   - MENSAL               *      */
        /*"      *               9338 - EXCLUSIVO - CACB   - ANUAL                *      */
        /*"      *                                                                *      */
        /*"      *   EM 07/01/2009 - FAST COMPUTER            PROCURE POR V.47    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 46                                                    *      */
        /*"      *             - CAD 16.695                                       *      */
        /*"      *               TRATA PRODUTO 9335 - EXCLUSIVO - COPESP - MENSAL *      */
        /*"      *               TRATA PRODUTO 9336 - EXCLUSIVO - COPESP - ANUAL  *      */
        /*"      *                                                                *      */
        /*"      *             - CAD 16.697                                       *      */
        /*"      *               TRATA PRODUTO 9337 - EXCLUSIVO - CACB   - MENSAL *      */
        /*"      *               TRATA PRODUTO 9338 - EXCLUSIVO - CACB   - ANUAL  *      */
        /*"      *                                                                *      */
        /*"      *   EM 28/11/2008 - FAST COMPUTER            PROCURE POR V.46    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 45                                                    *      */
        /*"      *             - CAD 16.014                                       *      */
        /*"      *               INCLUSAO EM DUPLICIDADE NA                       *      */
        /*"      *               SEGUROS.FUNDO_COMISSAO_VA                        *      */
        /*"      *                                                                *      */
        /*"      *             - CRITICA INDEVIDA DE DPS PARA VIDA DA GENTE       *      */
        /*"      *                                                                *      */
        /*"      *             - INCLUSAO NA TABELA SEGUROS.ERROS_PROP_VIDAZUL    *      */
        /*"      *               QUANDO A PROPOSTA RETORNA A SITUACAO             *      */
        /*"      *               1 - EM CRITICA, PARA QUE O PROGRAMA VA3118B,     *      */
        /*"      *               NAO RETORNE A SITUACAO PARA 0 - AGUARDANDO       *      */
        /*"      *               EMISSAO E ASSIM SEJA SENSIBILIZADO O RELATORIO   *      */
        /*"      *               VA1466B PARA CORRECAO MANUAL DO PROBLEMA.        *      */
        /*"      *                                                                *      */
        /*"      *   EM 16/10/2008 - FAST COMPUTER            PROCURE POR V.45    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 44                                                    *      */
        /*"      *             - CAD 15.797                                       *      */
        /*"      *               VOLTA A SITUACAO PARA 1 - EM CRITICA PARA        *      */
        /*"      *               PROPOSTAS COM ERRO.                              *      */
        /*"      *                                                                *      */
        /*"      *   EM 09/10/2008 - FAST COMPUTER            PROCURE POR V.44    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * PROJETO FGV (ALTERACOES)     (WELLINGTON VERAS (POLITEC))      *      */
        /*"      *                                                                *      */
        /*"      * 11/08/2008 - INIBIR DISPLAY                         - WV0808   *      */
        /*"      * 08/10/2008 - INIBIR DISPLAY                         - WV1008   *      */
        /*"      * 04/11/2008 - INCLUIR CLAUSULA WITH UR NO SELECT     - WV1108   *      */
        /*"      * 27/11/2008 - INCLUIR WITH UR (SEGUROS.V0SISTEMA)    - WV1108   *      */
        /*"      * 27/11/2008 - INCLUIR WITH UR (SEGUROS.MOVIMENTO_VGAP) WV1108   *      */
        /*"      * 27/11/2008 - RETIRAR WITH UR (SEGUROS.V1RCAPCOMP)   - WV1108   *      */
        /*"      * 27/11/2008 - RETIRAR WITH UR (SEGUROS.V0CONDTEC )   - WV1108   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 43                                                    *      */
        /*"      *             - CAD 15.013                                       *      */
        /*"      *               TRATA -EMISSAO VIDA EXCLUSIVO ECONOMIARIO        *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/09/2008 - FAST COMPUTER            PROCURE POR V.43    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 42                                                    *      */
        /*"      *             - CAD 14.945                                       *      */
        /*"      *               TRATA -501 NO CURSOR PRINCIPAL                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/09/2008 - FAST COMPUTER            PROCURE POR V.42    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 41                                                    *      */
        /*"      *             - CAD 14.717                                       *      */
        /*"      *               TRATA -501 NO CURSOR PRINCIPAL                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/09/2008 - FAST COMPUTER            PROCURE POR V.41    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 40                                                    *      */
        /*"      *             - CAD 14.636                                       *      */
        /*"      *               PASSA A DESPREZAR MOVFDCAP JA EXISTENTE.         *      */
        /*"      *                                                                *      */
        /*"      *   EM 16/09/2008 - FAST COMPUTER            PROCURE POR V.40    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 39                                                    *      */
        /*"      *             - CAD 13.762                                       *      */
        /*"      *               PASSA A TRATAR OS PRODUTOS PU COM PERIODICIDADE  *      */
        /*"      *               DE PAGAMENTO IGUAL A 0.                          *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/09/2008 - FAST COMPUTER            PROCURE POR V.39    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 38                                                    *      */
        /*"      *             - CAD 12.962                                       *      */
        /*"      *               TRATA PROPOSTAS COM DATA DE PROXIMO VENCIMENTO   *      */
        /*"      *               IGUAL A 9999-12-31 PARA NAO CALCULAR A DATA DE   *      */
        /*"      *               PROXIMO VENCIMENTO.                              *      */
        /*"      *                                                                *      */
        /*"      *   EM 12/08/2008 - FAST COMPUTER            PROCURE POR V.38    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 37                                                    *      */
        /*"      *             - CAD 09.373                                       *      */
        /*"      *               DISPENSA DE DPS PARA VIDA SENIOR - 109300000909  *      */
        /*"      *                                                                *      */
        /*"      *             - CAD 10.010                                       *      */
        /*"      *               DISPENSA DE DPS PARA VIDA MULHER - 109300001311  *      */
        /*"      *                                                                *      */
        /*"      *             - CAD 10.559                                       *      */
        /*"      *               PAGAMENTO UNICO COM VIGENCIA DE 36 MESES PARA    *      */
        /*"      *               OS PRODUTOS:                                     *      */
        /*"      *                  . 9318 - VIDA DA GENTE       - 109300001391   *      */
        /*"      *                  . 9327 - VIDA MULHER < 30000 - 109300001392   *      */
        /*"      *                  . 9327 - VIDA MULHER         - 109300001393   *      */
        /*"      *                  . 9309 - MULTIPREMIADO SUPER - 109300001394   *      */
        /*"      *                                                                *      */
        /*"      *   EM 31/05/2008 - FAST COMPUTER            PROCURE POR V.37    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 36 - CAD 10.157/2008                                  *      */
        /*"      *               TRATA O ACESSO A TABELA PARA CANAL GITEL         *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/05/2008 - FAST COMPUTER            PROCURE POR V.36    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 35 - CAD 09.135/2008                                  *      */
        /*"      *               TRATA O PRODUTO CANAL GITEL PARA VIDA DA GENTE   *      */
        /*"      *                                                                *      */
        /*"      *   EM 12/04/2008 - FAST COMPUTER            PROCURE POR V.35    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *  34 - ACESSA A TABELA SEGUROS.PLANOS_VA_VGAP PARA PRODUTO 77   *      */
        /*"      *       PROCURE  V.34                                            *      */
        /*"      *                                                                *      */
        /*"      *              FAST COMPUTER      18/02/2008.                    *      */
        /*"      *                                                                *      */
        /*"      *  33 - CORRECAO DO ABEND OCORRIDO (SQLCODE = -803) NA TABELA DE *      */
        /*"      *       SEGUROS.V0DIFPARCELVA.          PROCURE  V.33            *      */
        /*"      *                                                                *      */
        /*"      *              FAST COMPUTER      30/01/2008.                    *      */
        /*"      *                                                                *      */
        /*"      *  32 - PASSA A NAO MAIS CRITICAR DPS PARA APOLICE VIDA DA GENTE *      */
        /*"      *                                 PROCURE V.32                   *      */
        /*"      *              FAST COMPUTER      21/01/2008.                    *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *  31 - PASSA A NAO MAIS ADIANTAMENTO DE COMISSAO.               *      */
        /*"      *                                 PROCURE V.31                   *      */
        /*"      *              FAST COMPUTER      16/01/2007.                    *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *  30 - PASSA A NAO MAIS ACESSAR FUNDO DE COMISSAO PARA          *      */
        /*"      *       EXCLUSIVO                                                *      */
        /*"      *                                 PROCURE V.30                   *      */
        /*"      *              FAST COMPUTER      16/01/2007.                    *      */
        /*"      *                                                                *      */
        /*"      *  29 - PASSA A DOCUMENTAR ABENDS NAS ROTINAS DE SELECT E UPDATE *      */
        /*"      *                                 PROCURE LV1501                 *      */
        /*"      *              LUCIA VIEIRA       15/01/2007.                    *      */
        /*"      *                                                                *      */
        /*"      *  28 - PASSA A GERAR CERTIFICADOS PARA O KIT EXCLUSIVO          *      */
        /*"      *                                 PROCURE LV0304                 *      */
        /*"      *                                                                *      */
        /*"      *              LUCIA VIEIRA       03/04/2006.                    *      */
        /*"      *  27 - SUSPENDE O ENVIO DO RELATORIO VA52 QUE REFERE-SE AO      *      */
        /*"      *       CERTIFICADO DO PRODUTO VIDA-MULHER 109300000709          *      */
        /*"      *                                 PROCURE AF0510                 *      */
        /*"      *                                                                *      */
        /*"      *              ALEXANDRE FREITAS  28/10/2005.                    *      */
        /*"      *                                                                *      */
        /*"      *  26 - COLOCA A PROPOSTA EM CRITICA QUANDO O DEBITO FOR EM CON  *      */
        /*"      *       TA CORRENTE OU POUPANCA E O NUMERO DA CONTA ESTIVER ZERA *      */
        /*"      *       DA.                                                      *      */
        /*"      *                                 PROCURE MM0404                 *      */
        /*"      *                                                                *      */
        /*"      *                MANOEL MESSIAS   30/04/2004.                    *      */
        /*"      *                                                                *      */
        /*"      *  25 - FOI CRIADO NIVEL 88 PARA CONTROLE DO ACESSO A TABELA     *      */
        /*"      *       PROPOSTA_SIVPF.                                          *      */
        /*"      *                                                                *      */
        /*"      *                                 PROCURE LC0304                 *      */
        /*"      *                                                                *      */
        /*"      *                LUIZ CARLOS      16/04/2003.                    *      */
        /*"      *                                                                *      */
        /*"      *  24 - PASSA A NAO MAIS USAR A V0FATURCONT PARA DEFINIR A DATA  *      */
        /*"      *       DE RFERENCIA E SIM A DATA DO DIA.                        *      */
        /*"      *                                                                *      */
        /*"      *                                 PROCURE TL0301.                *      */
        /*"      *                                                                *      */
        /*"      *                TERCIO CARVALHO  24/01/2003.                    *      */
        /*"      *                                                                *      */
        /*"      *  23 - PASSA A COMPARAR O VALOR DA IMPMORNATU DA COBERPROPVA    *      */
        /*"      *       COM O DA PLANOS_VA_VGAP PARA FILTRAR PROPOSTAS LIBERADAS *      */
        /*"      *       ERRONEAMENTE.                                            *      */
        /*"      *                                 PROCURE TL0204.                *      */
        /*"      *                                                                *      */
        /*"      *                TERCIO CARVALHO  03/12/2001.                    *      */
        /*"      *                                                                *      */
        /*"      *  22 - PASSA GERAR A PRIMEIRA PARCELA PONDERANDO 8 DIAS.        *      */
        /*"      *                                 PROCURE TL0201.                *      */
        /*"      *                                                                *      */
        /*"      *                TERCIO CARVALHO  03/12/2001.                    *      */
        /*"      *                                                                *      */
        /*"      *  21 - PASSA A PROCEDER A BAIXA DO RCAP.                        *      */
        /*"      *                                 PROCURE TL0112.                *      */
        /*"      *                                                                *      */
        /*"      *                TERCIO CARVALHO  03/12/2001.                    *      */
        /*"      *                                                                *      */
        /*"      *  20 - PASSA A ATUALIZAR DTQITBCO, VAL-PAGO, DATA CREDITO E     *      */
        /*"      *       OPCAO-COBER DA PROPOSTA-FIDELIZ.                         *      */
        /*"      *                                 PROCURE LC0817.                *      */
        /*"      *                                                                *      */
        /*"      *                LUIZ CARLOS      17/08/2001.                    *      */
        /*"      *                                                                *      */
        /*"      *  19 - ESTAVA MOVENDO O CODRELAT (VA0420B), QUANDO, DEVERIA MO- *      */
        /*"      *       VER O CODRELAT LIDO DA V0PRODUTOSVG.                     *      */
        /*"      *                                 PROCURE MM1607.                *      */
        /*"      *                                                                *      */
        /*"      *                MANOEL MESSIAS   16/07/2001.                    *      */
        /*"      *                                                                *      */
        /*"      *  18 - CONTROLE DE EMISSAO DE CERTIFICADOS NA NOVA VERSAO.      *      */
        /*"      *                                 PROCURE MM0701.                *      */
        /*"      *                                                                *      */
        /*"      *                MANOEL MESSIAS   09/07/2001.                    *      */
        /*"      *                                                                *      */
        /*"      *  17 - O INICIO DE VIGENCIA DO SEGURO PARA O PRODUTO MULTIPRE-  *      */
        /*"      *       MIADO PASSA A SER A DATA DE QUITACAO DA 1 PARCELA.       *      */
        /*"      *                                 PROCURE FF0012.                *      */
        /*"      *                                                                *      */
        /*"      *                FRED FONSECA     05/12/2000.                    *      */
        /*"      *                                                                *      */
        /*"      *  16 - PASSA A GERAR SIT-PROPOSTA DA PROPOSTA-FIDELIZ COM 'PEN',*      */
        /*"      *       AO INVEZ DE 'ANA', CASO A PROPOSTA TENHA ALGUM ERRO.     *      */
        /*"      *                                 PROCURE LC0800.                *      */
        /*"      *                                                                *      */
        /*"      *                LUIZ CARLOS      28/08/2000.                    *      */
        /*"      *                                                                *      */
        /*"      *  15 - PASSA A NAO MAIS PERMITIR QUE A DTPROXVEN SEJA INFERIOR  *      */
        /*"      *       AO PERIPGTO DA OPCAOPAGVA * 30 DIAS.                     *      */
        /*"      *                                 PROCURE TL0007.                *      */
        /*"      *                                                                *      */
        /*"      *                TERCIO CARVALHO  25/07/2000.                    *      */
        /*"      *                                                                *      */
        /*"      *  14 - PASSA A GERAR SIT-PROPOSTA DA PROPOSTA-FIDELIZ COM 'ANA',*      */
        /*"      *       AO INVEZ DE 'REJ', CASO A PROPOSTA TENHA ALGUM ERRO.     *      */
        /*"      *                                 PROCURE LC0600.                *      */
        /*"      *                                                                *      */
        /*"      *                LUIZ CARLOS      26/06/2000.                    *      */
        /*"      *                                                                *      */
        /*"      *  13 - PASSA A ATUALIZAR AS PROPOSTAS ENVIADAS PELO SIVPF/SIVPF *      */
        /*"      *       COM SITUACAO DE EMITIDA ('EMT').                         *      */
        /*"      *                                 PROCURE LC0100.                *      */
        /*"      *                                                                *      */
        /*"      *                LUIZ CARLOS      21/01/2000.                    *      */
        /*"      *                                                                *      */
        /*"      *  12 - PASSA A DAR O DISPLAY DO PROPOSTA AUTOMATICA E DA FONTE  *      */
        /*"      *       QUANDO ABENDAR NO INSERT DA V0MOVIMENTO.                 *      */
        /*"      *                                 PROCURE MM0612.                *      */
        /*"      *                                                                *      */
        /*"      *                MANOEL MESSIAS   06/12/1999.                    *      */
        /*"      *                                                                *      */
        /*"      *  11 - FOI RETIRADA A COLUNA VLPRMTOT DO ARGUMENTO DE PESQUISA' *      */
        /*"      *       PORQUE O PROGRAMA GERA A DIFERENCA PAGA A MAIOR OU MENOR *      */
        /*"      *       NA DIFPARCELVA.                                          *      */
        /*"      *                                 PROCURE TL9910.                *      */
        /*"      *                                                                *      */
        /*"      *                TERCIO CARVALHO  08/10/1999.                    *      */
        /*"      *                                                                *      */
        /*"      *  10 - PASSA A NAO PROCESSAR SEGUROS QUE AGENCIA DE COBRANCA    *      */
        /*"      *       NAO ESTEJA CADASTRADA.                                 . *      */
        /*"      *                                 PROCURE LC0799.                *      */
        /*"      *                                                                *      */
        /*"      *                LUIZ CARLOS      15/07/1999.                    *      */
        /*"      *                                                                *      */
        /*"      *   9 - PASSA A NAO MAIS TRABALHAR POR PRODUTO E SIM POR         *      */
        /*"      *       APOLICE E SUBGRUPO.                                    . *      */
        /*"      *                                 PROCURE TL9906.                *      */
        /*"      *                                                                *      */
        /*"      *                TERCIO CARVALHO  30/06/1999.                    *      */
        /*"      *                                                                *      */
        /*"      *   8 - ALTERADO ACESSO A V0PLANOSVA PARA USAR A DTMOVTO DA      *      */
        /*"      *       PROPOSTAVA E NAO MAIS A DTQITBCO COMO ANTES.           . *      */
        /*"      *                                 PROCURE TL9904.                *      */
        /*"      *                                                                *      */
        /*"      *                TERCIO CARVALHO  08/04/1999.                    *      */
        /*"      *                                                                *      */
        /*"      *   7 - ALTERADO PARA AJUSTAR A DATA DO VENCIMENTO DA PRIMEIRA   *      */
        /*"      *       PARCELA PARA NAO SER INFERIOR A DTQITBCO.                *      */
        /*"      *                                 PROCURE TL9903.                *      */
        /*"      *                                                                *      */
        /*"      *                TERCIO CARVALHO  08/01/1999.                    *      */
        /*"      *                                                                *      */
        /*"      *   6 - ALTERADO PARA RECUPERAR O CONVENIO SICOV PARA PRIMEIRA   *      */
        /*"      *       PARCELA NA V0HISTCONTAVA. PROCURE TL9901.                *      */
        /*"      *                                                                *      */
        /*"      *                TERCIO CARVALHO  08/01/1999.                    *      */
        /*"      *                                                                *      */
        /*"      *   5 - ALTERADO PARA TRATAR PRODUTO 805 - PREFERENCIAL VIDA     *      */
        /*"      *       PLUS - FENAE CORRETORA.                                  *      */
        /*"      *                                                                *      */
        /*"      *                LUIZ CARLOS      15/10/1998.                    *      */
        /*"      *                                                                *      */
        /*"      *   4 - PASSA A TRATAR OS CONVENIOS CAIXA DO TRABALHADOR, CUJA   *      */
        /*"      *       PRIMEIRA PARCELA POSSUI DESCONTO DE 50%.                 *      */
        /*"      *                                                                *      */
        /*"      *                                 PROCURE MMS                    *      */
        /*"      *                                                                *      */
        /*"      *                    MESSIAS      13/10/1998                     *      */
        /*"      *                                                                *      */
        /*"      *   3 - O INICIO DA SAF E SEU REPASSE, SERA A PARTIR DA INCLUSAO *      */
        /*"      *       DO SEGURO.                                               *      */
        /*"      *                                                                *      */
        /*"      *                LUIZ CARLOS  31/08/1998.                        *      */
        /*"      *                                                                *      */
        /*"      *   2 - O INICIO DA SAF E SEU REPASSE, SERA A PARTIR DA INCLUSAO *      */
        /*"      *       DO SEGURO.                                               *      */
        /*"      *                                                                *      */
        /*"      *                LUIZ CARLOS  31/08/1998.                        *      */
        /*"      *                                                                *      */
        /*"      *   1 - O INICIO DE VIGENCIA DA CDG, SERA IGUAL A 6 (SEIS) MESES *      */
        /*"      *       A CONTAR DA DATA QUITACAO BANCARIA (DTQITBCO). CONTUDO O *      */
        /*"      *       REPASSE (PGTO), SERA FEITO A PARTIR DA INCLUSAO DO SEGU- *      */
        /*"      *       RO.                                                      *      */
        /*"      *                                                                *      */
        /*"      *   0 - PASSA A GERAR O FUNDO DE COMISSOER PARA AS PROPOSTAS     *      */
        /*"      *       ACEITAS CUJO VALOR DE COMISSAO DE ADIANTAMENTO SEJA      *      */
        /*"      *       IGUAL A ZERO.                                            *      */
        /*"      *                                                                *      */
        /*"      *                    FONSECA   27/04/98                          *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  WIND                             PIC S9(04)    COMP VALUE +0*/
        public IntBasis WIND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77         PROD-COD-EMPRESA     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis PROD_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         PROD-COD-PRODUTO     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis PROD_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         PARM-COD-EMPR-CAP    PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis PARM_COD_EMPR_CAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WS-NUM-APOLICE-ANT1      PIC S9(013)    COMP-3 VALUE +0.*/
        public IntBasis WS_NUM_APOLICE_ANT1 { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01  WHOST-VLPREMIO-W         PIC S9(013)V99 COMP-3 VALUE +0.*/
        public DoubleBasis WHOST_VLPREMIO_W { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  WHOST-VLPREMIO           PIC S9(013)V99 COMP-3 VALUE +0.*/
        public DoubleBasis WHOST_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  WHOST-NRMATRVEN                  PIC 9(015).*/
        public IntBasis WHOST_NRMATRVEN { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
        /*"01  CALENDAR-DATA-CALENDARIO         PIC X(010).*/
        public StringBasis CALENDAR_DATA_CALENDARIO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WS-PROPVA-DTPROXVEN              PIC X(010).*/
        public StringBasis WS_PROPVA_DTPROXVEN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WHOST-PROXIMA-DATA               PIC X(010).*/
        public StringBasis WHOST_PROXIMA_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WHOST-DATA-MOVIMENTO             PIC X(010).*/
        public StringBasis WHOST_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  W03-VENCIMENTO                   PIC X(010).*/
        public StringBasis W03_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  CALENDAR-DIA-SEMANA              PIC X(010).*/
        public StringBasis CALENDAR_DIA_SEMANA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  CALENDAR-FERIADO                 PIC X(010).*/
        public StringBasis CALENDAR_FERIADO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WHOST-DTINIVIG                   PIC X(10).*/
        public StringBasis WHOST_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  WHOST-SIT-PROP-FIDELIZ           PIC X(03).*/
        public StringBasis WHOST_SIT_PROP_FIDELIZ { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
        /*"01  WHOST-SITUACAO-ENVIO             PIC X(01).*/
        public StringBasis WHOST_SITUACAO_ENVIO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  VIND-ORIGEM                      PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_ORIGEM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-FAIXA-RENDA                 PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_FAIXA_RENDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-COD-CRM                     PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_COD_CRM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-DTMOVTO                     PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_DTMOVTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-DATSEL                      PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_DATSEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-CODEMP                      PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_CODEMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-CODPRP                      PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_CODPRP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-NUMBIL                      PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-VLVARMON                    PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_VLVARMON { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-DTQITBCO                    PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_DTQITBCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-ESTR-COBR                   PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_ESTR_COBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-ORIG-PRODU                  PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_ORIG_PRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-TEM-SAF                     PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_TEM_SAF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-TEM-CDG                     PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_TEM_CDG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-AGENCIADOR                  PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_AGENCIADOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-CODRELAT                    PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_CODRELAT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  INDAGE                           PIC S9(4) COMP.*/
        public IntBasis INDAGE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  INDOPR                           PIC S9(4) COMP.*/
        public IntBasis INDOPR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  INDNUM                           PIC S9(4) COMP.*/
        public IntBasis INDNUM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  INDDIG                           PIC S9(4) COMP.*/
        public IntBasis INDDIG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  INDCARTAO                        PIC S9(4) COMP.*/
        public IntBasis INDCARTAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-DTENV                       PIC S9(4) VALUE +0 COMP.*/
        public IntBasis VIND_DTENV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-DTRET                       PIC S9(4) VALUE +0 COMP.*/
        public IntBasis VIND_DTRET { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-CODRET                      PIC S9(4) VALUE +0 COMP.*/
        public IntBasis VIND_CODRET { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-NREQ                        PIC S9(4) VALUE +0 COMP.*/
        public IntBasis VIND_NREQ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-SEQUEN                      PIC S9(4) VALUE +0 COMP.*/
        public IntBasis VIND_SEQUEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-NLOTE                       PIC S9(4) VALUE +0 COMP.*/
        public IntBasis VIND_NLOTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-DTCRED                      PIC S9(4) VALUE +0 COMP.*/
        public IntBasis VIND_DTCRED { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-STATUS                      PIC S9(4) VALUE +0 COMP.*/
        public IntBasis VIND_STATUS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-VLCRED                      PIC S9(4) VALUE +0 COMP.*/
        public IntBasis VIND_VLCRED { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  CONDTE-IEA                       PIC S9(005)V9(02) COMP-3.*/
        public DoubleBasis CONDTE_IEA { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(005)V9(02)"), 2);
        /*"01  CONDTE-IPA                       PIC S9(005)V9(02) COMP-3.*/
        public DoubleBasis CONDTE_IPA { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(005)V9(02)"), 2);
        /*"01  DESCON-PERC                      PIC S9(003)V9(04) COMP-3.*/
        public DoubleBasis DESCON_PERC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(04)"), 4);
        /*"01  DESCON-DTINIVIG                  PIC  X(010).*/
        public StringBasis DESCON_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  DESCON-VLPREMIO                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis DESCON_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  DESCON-PRMVG                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis DESCON_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  DESCON-PRMAP                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis DESCON_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  WHOST-COUNT                      PIC S9(4) COMP.*/
        public IntBasis WHOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  SIVPF-NR-PROPOSTA                PIC S9(15) COMP-3.*/
        public IntBasis SIVPF_NR_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  SIVPF-NR-SICOB                   PIC S9(15) COMP-3.*/
        public IntBasis SIVPF_NR_SICOB { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  SIVPF-NR-IDENTIFI                PIC S9(15) COMP-3.*/
        public IntBasis SIVPF_NR_IDENTIFI { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  SIVPF-SIT-PROPOSTA               PIC  X(03).*/
        public StringBasis SIVPF_SIT_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
        /*"01  SIVPF-DTQITBCO                   PIC  X(10).*/
        public StringBasis SIVPF_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  SIVPF-DATA-CREDITO               PIC  X(10).*/
        public StringBasis SIVPF_DATA_CREDITO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  SIVPF-VAL-PAGO                   PIC S9(13)V99 COMP-3.*/
        public DoubleBasis SIVPF_VAL_PAGO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  SIVPF-OPCAO-COBER                PIC  X(01).*/
        public StringBasis SIVPF_OPCAO_COBER { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  SIVPF-COD-PLANO                  PIC S9(04) COMP.*/
        public IntBasis SIVPF_COD_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  CONVER-NUM-SICOB                 PIC S9(15) COMP-3.*/
        public IntBasis CONVER_NUM_SICOB { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  CONVER-NUM-PROPOSTA              PIC S9(15) COMP-3 VALUE +0.*/
        public IntBasis CONVER_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  V0PARC-NRCERTIF                  PIC S9(15) COMP-3.*/
        public IntBasis V0PARC_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  PROPVA-NRCERTIF                  PIC S9(15) COMP-3.*/
        public IntBasis PROPVA_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  PROPVA-NRPROPAZ                  PIC S9(13) COMP-3.*/
        public IntBasis PROPVA_NRPROPAZ { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  PROPVA-CODPRODU                  PIC S9(04) COMP.*/
        public IntBasis PROPVA_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  PROPVA-CODCLIEN                  PIC S9(09) COMP.*/
        public IntBasis PROPVA_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  PROPVA-OCOREND                   PIC S9(04) COMP.*/
        public IntBasis PROPVA_OCOREND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  PROPVA-FONTE                     PIC S9(4) COMP.*/
        public IntBasis PROPVA_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  PROPVA-AGECOBR                   PIC S9(4) COMP.*/
        public IntBasis PROPVA_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  PROPVA-OPCAO-COBER               PIC  X(1).*/
        public StringBasis PROPVA_OPCAO_COBER { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  PROPVA-DTQITBCO                  PIC  X(10).*/
        public StringBasis PROPVA_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PROPVA-DTINICDG                  PIC  X(10).*/
        public StringBasis PROPVA_DTINICDG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PROPVA-DTINISAF                  PIC  X(10).*/
        public StringBasis PROPVA_DTINISAF { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PROPVA-NRMATRVEN                 PIC S9(15) COMP-3.*/
        public IntBasis PROPVA_NRMATRVEN { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  PROPVA-CODOPER                   PIC S9(4) COMP.*/
        public IntBasis PROPVA_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  DIFPAR-CODOPER                   PIC S9(4) COMP.*/
        public IntBasis DIFPAR_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  PROPVA-DTMOVTO                   PIC  X(10).*/
        public StringBasis PROPVA_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PROPVA-DTPROXVEN                 PIC  X(10).*/
        public StringBasis PROPVA_DTPROXVEN { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PROPVA-DTPROXVEN-S               PIC  X(10).*/
        public StringBasis PROPVA_DTPROXVEN_S { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PROPVA-DTVENCTO                  PIC  X(10).*/
        public StringBasis PROPVA_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PROPVA-DTMINVEN                  PIC  X(10).*/
        public StringBasis PROPVA_DTMINVEN { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PROPVA-SITUACAO                  PIC  X(1).*/
        public StringBasis PROPVA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  PROPVA-NUM-APOLICE               PIC S9(13) COMP-3.*/
        public IntBasis PROPVA_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  PROPVA-CODSUBES                  PIC S9(4) COMP.*/
        public IntBasis PROPVA_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  PROPVA-OCORHIST                  PIC S9(4) COMP.*/
        public IntBasis PROPVA_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  PROPVA-NRPARCEL                  PIC S9(4) COMP.*/
        public IntBasis PROPVA_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  PROPVA-SIT-INTERF                PIC  X(1).*/
        public StringBasis PROPVA_SIT_INTERF { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  PROPVA-TIMESTAMP                 PIC  X(26).*/
        public StringBasis PROPVA_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"01  PROPVA-IDADE                     PIC S9(4) COMP.*/
        public IntBasis PROPVA_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  PROPVA-SEXO                      PIC  X(1).*/
        public StringBasis PROPVA_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  PROPVA-EST-CIV                   PIC  X(1).*/
        public StringBasis PROPVA_EST_CIV { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  PROPVA-COD-CRM                   PIC S9(4) COMP.*/
        public IntBasis PROPVA_COD_CRM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  PROPVA-NRMATRFUN                 PIC S9(15) COMP-3.*/
        public IntBasis PROPVA_NRMATRFUN { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  PROPVA-INRMATRFUN                PIC S9(4) COMP.*/
        public IntBasis PROPVA_INRMATRFUN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  PROPVA-NRPROPOS                  PIC S9(09) COMP.*/
        public IntBasis PROPVA_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  PROPVA-INRPROPOS                 PIC S9(04) COMP.*/
        public IntBasis PROPVA_INRPROPOS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  PROPVA-DTADMIS                   PIC  X(10) VALUE SPACES.*/
        public StringBasis PROPVA_DTADMIS { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"01  PROPVA-IDTADMIS                  PIC S9(04) COMP VALUE ZEROS*/
        public IntBasis PROPVA_IDTADMIS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  WPROPVA-DTADMIS                  PIC  X(10).*/
        public StringBasis WPROPVA_DTADMIS { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  WPROPVA-IDTADMIS                 PIC S9(04).*/
        public IntBasis WPROPVA_IDTADMIS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)."));
        /*"01  PROPVA-CODCCT                    PIC S9(15) COMP-3.*/
        public IntBasis PROPVA_CODCCT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  PROPVA-ICODCCT                   PIC S9(4) COMP.*/
        public IntBasis PROPVA_ICODCCT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  PROPVA-CODUSU                    PIC  X(8).*/
        public StringBasis PROPVA_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"01  PROPVA-FAIXA-RENDA-IND           PIC  X(1).*/
        public StringBasis PROPVA_FAIXA_RENDA_IND { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  PROPVA-DATA                      PIC  X(10).*/
        public StringBasis PROPVA_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PROPVA-DPS-TITULAR               PIC  X(30).*/
        public StringBasis PROPVA_DPS_TITULAR { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"01  PROPVA-ORIGEM-PROPOSTA           PIC S9(04)        COMP.*/
        public IntBasis PROPVA_ORIGEM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  PROPVA-COD-OPER-CREDITO          PIC S9(04)        COMP.*/
        public IntBasis PROPVA_COD_OPER_CREDITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  PROPVA-ACATAMENTO                PIC  X(01).*/
        public StringBasis PROPVA_ACATAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  PRODVG-CODPRODAZ                 PIC  X(03).*/
        public StringBasis PRODVG_CODPRODAZ { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
        /*"01  PRODVG-PERIPGTO                  PIC S9(04)        COMP.*/
        public IntBasis PRODVG_PERIPGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  PRODVG-ESTR-COBR                 PIC  X(10).*/
        public StringBasis PRODVG_ESTR_COBR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PRODVG-ORIG-PRODU                PIC  X(10).*/
        public StringBasis PRODVG_ORIG_PRODU { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PRODVG-AGENCIADOR                PIC S9(9)         COMP.*/
        public IntBasis PRODVG_AGENCIADOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01  PRODVG-TEM-SAF                   PIC  X(1).*/
        public StringBasis PRODVG_TEM_SAF { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  PRODVG-TEM-CDG                   PIC  X(1).*/
        public StringBasis PRODVG_TEM_CDG { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  PRODVG-CODRELAT                  PIC  X(8).*/
        public StringBasis PRODVG_CODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"01  PRODVG-RISCO                     PIC  X(1).*/
        public StringBasis PRODVG_RISCO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  PRODVG-COBERADIC-PREMIO          PIC  X(1).*/
        public StringBasis PRODVG_COBERADIC_PREMIO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  PRODVG-DESCONTO-ADESAO           PIC S9(003)V9(05) COMP-3.*/
        public DoubleBasis PRODVG_DESCONTO_ADESAO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(05)"), 5);
        /*"01  PRODVG-SITPLANCEF                PIC  X(001).*/
        public StringBasis PRODVG_SITPLANCEF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  PRODVG-COD-PRODUTO               PIC S9(04)        COMP.*/
        public IntBasis PRODVG_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  PRODVG-ARQ-FDCAP                 PIC S9(04)        COMP.*/
        public IntBasis PRODVG_ARQ_FDCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  WS-IND-ARQFDCAP                  PIC S9(004)       COMP.*/
        public IntBasis WS_IND_ARQFDCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  PRODVG-COD-RUBRICA               PIC S9(004)       COMP.*/
        public IntBasis PRODVG_COD_RUBRICA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WS-IND-RUBRICA                   PIC S9(004)       COMP.*/
        public IntBasis WS_IND_RUBRICA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WS-ATUALIZA-OPCPAGVA             PIC X(003)  VALUE SPACES.*/
        public StringBasis WS_ATUALIZA_OPCPAGVA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"01  PRODVG-CUSTOCAP-TOTAL            PIC  X(001).*/
        public StringBasis PRODVG_CUSTOCAP_TOTAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  PRODVG-CUSTOCAP-TOTAL-9          PIC  9(001).*/
        public IntBasis PRODVG_CUSTOCAP_TOTAL_9 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
        /*"01  OPCAOP-OPCAOPAG                  PIC  X(1).*/
        public StringBasis OPCAOP_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  OPCAOP-PERIPGTO                  PIC S9(4) COMP.*/
        public IntBasis OPCAOP_PERIPGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  OPCAOP-DIA-DEB                   PIC S9(4) COMP.*/
        public IntBasis OPCAOP_DIA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  OPCAOP-AGECTADEB                 PIC S9(4) COMP.*/
        public IntBasis OPCAOP_AGECTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  OPCAOP-OPRCTADEB                 PIC S9(4) COMP.*/
        public IntBasis OPCAOP_OPRCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  OPCAOP-NUMCTADEB                 PIC S9(13) COMP-3.*/
        public IntBasis OPCAOP_NUMCTADEB { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  OPCAOP-DIGCTADEB                 PIC S9(4) COMP.*/
        public IntBasis OPCAOP_DIGCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  OPCAOP-CARTAOCRED                PIC S9(16) COMP-3.*/
        public IntBasis OPCAOP_CARTAOCRED { get; set; } = new IntBasis(new PIC("S9", "16", "S9(16)"));
        /*"01  V0AGCEF-COD-AGCOBR               PIC S9(4) COMP.*/
        public IntBasis V0AGCEF_COD_AGCOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  COBERP-DTINIVIG                  PIC  X(10).*/
        public StringBasis COBERP_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  COBERP-DTTERVIG                  PIC  X(10).*/
        public StringBasis COBERP_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  COBERP-IMPMORNATU                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_IMPMORNATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IMPMORACID                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_IMPMORACID { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IMPINVPERM                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_IMPINVPERM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IMPAMDS                   PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_IMPAMDS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IMPDH                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_IMPDH { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IMPDIT                    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_IMPDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-VLPREMIO                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-PRMVG                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-PRMAP                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-PRMVG-DIF                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_PRMVG_DIF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-PRMAP-DIF                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_PRMAP_DIF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  DIFPAR-PRMVG                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis DIFPAR_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-VLCUSTCAP                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_VLCUSTCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IMPSEGCDG                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_IMPSEGCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-VLCUSTCDG                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_VLCUSTCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IMPSEGAUXF                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_IMPSEGAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-VLCUSTAUXF                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_VLCUSTAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IIMPSEGAUXF               PIC S9(04)    COMP.*/
        public IntBasis COBERP_IIMPSEGAUXF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  COBERP-IVLCUSTAUXF              PIC S9(04)    COMP.*/
        public IntBasis COBERP_IVLCUSTAUXF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  COBERP-QTTITCAP                 PIC S9(04)    COMP.*/
        public IntBasis COBERP_QTTITCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  COBERP-IQTTITCAP                PIC S9(04)    COMP.*/
        public IntBasis COBERP_IQTTITCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0COBER-MINOCOR                 PIC S9(04)    COMP.*/
        public IntBasis V0COBER_MINOCOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  COMISI-VALADT                   PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COMISI_VALADT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  PARCOM-TIPCOM                   PIC  X(01).*/
        public StringBasis PARCOM_TIPCOM { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  FUNDO-PCCOMCOR                  PIC S9(03)V99 COMP-3.*/
        public DoubleBasis FUNDO_PCCOMCOR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V99"), 2);
        /*"01  V1RIND-PCIOF                    PIC S9(03)V99 COMP-3.*/
        public DoubleBasis V1RIND_PCIOF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V99"), 2);
        /*"01  V1RIND-DTINIVIG                 PIC  X(10).*/
        public StringBasis V1RIND_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V1APOL-RAMO                     PIC S9(04)    COMP.*/
        public IntBasis V1APOL_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  FUNDO-PCCOMIND                   PIC S9(03)V99 COMP-3.*/
        public DoubleBasis FUNDO_PCCOMIND { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V99"), 2);
        /*"01  FUNDO-PCCOMGER                   PIC S9(03)V99 COMP-3.*/
        public DoubleBasis FUNDO_PCCOMGER { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V99"), 2);
        /*"01  FUNDO-PCCOMSUP                   PIC S9(03)V99 COMP-3.*/
        public DoubleBasis FUNDO_PCCOMSUP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V99"), 2);
        /*"01  FUNDO-PCCOMTOT                   PIC S9(03)V99 COMP-3.*/
        public DoubleBasis FUNDO_PCCOMTOT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V99"), 2);
        /*"01  FUNDO-VALBASVG                   PIC S9(13)V99 COMP-3.*/
        public DoubleBasis FUNDO_VALBASVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  FUNDO-VALBASAP                   PIC S9(13)V99 COMP-3.*/
        public DoubleBasis FUNDO_VALBASAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  FUNDO-VLCOMISVG                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis FUNDO_VLCOMISVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  FUNDO-VLCOMISAP                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis FUNDO_VLCOMISAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  CLIENT-DTNASC                    PIC  X(10).*/
        public StringBasis CLIENT_DTNASC { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  CLIENT-DTNASC-I                  PIC S9(04) COMP.*/
        public IntBasis CLIENT_DTNASC_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  CLIENT-CGCCPF                    PIC S9(15) COMP-3.*/
        public IntBasis CLIENT_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  CDGCOB-DTINIVIG                  PIC  X(010).*/
        public StringBasis CDGCOB_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  SAFCOB-DTINIVIG                  PIC  X(010).*/
        public StringBasis SAFCOB_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  REPCDG-DTREF                     PIC  X(010).*/
        public StringBasis REPCDG_DTREF { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  REPSAF-DTREF                     PIC  X(010).*/
        public StringBasis REPSAF_DTREF { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  RELATO-CODRELAT                  PIC  X(008).*/
        public StringBasis RELATO_CODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"01  RELATO-NRPARCEL                  PIC S9(004) COMP VALUE +0.*/
        public IntBasis RELATO_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  RELATO-OPERACAO                  PIC S9(004) COMP VALUE +0.*/
        public IntBasis RELATO_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  RELATO-NUM-APOLICE               PIC S9(13) COMP-3.*/
        public IntBasis RELATO_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  RELATO-CODSUBES                  PIC S9(4) COMP.*/
        public IntBasis RELATO_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  CLIROT-DTMOVABE                  PIC  X(010).*/
        public StringBasis CLIROT_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  FONTE-PROPAUTOM                  PIC S9(009) COMP.*/
        public IntBasis FONTE_PROPAUTOM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  APCORR-RAMO                      PIC S9(004) COMP.*/
        public IntBasis APCORR_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  APCORR-DTINIVIG                  PIC  X(010).*/
        public StringBasis APCORR_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  SUBGRU-CODSUBES                  PIC S9(004) COMP.*/
        public IntBasis SUBGRU_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WSISTEMA-DTMOVABE                PIC  X(010).*/
        public StringBasis WSISTEMA_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  SISTEMA-DTMOVABE                 PIC  X(010).*/
        public StringBasis SISTEMA_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  SISTEMA-CURRDATE                 PIC  X(010).*/
        public StringBasis SISTEMA_CURRDATE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  SISTEMA-DTMOVABE2                PIC  X(010).*/
        public StringBasis SISTEMA_DTMOVABE2 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  SISTEMA-DTMOVABE3                PIC  X(010).*/
        public StringBasis SISTEMA_DTMOVABE3 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  MMFAIXA                          PIC S9(004)      COMP.*/
        public IntBasis MMFAIXA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  MFAIXA                           PIC S9(004)      COMP.*/
        public IntBasis MFAIXA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  MAGENCIADOR                      PIC S9(009)      COMP.*/
        public IntBasis MAGENCIADOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  MDTMOVTO                         PIC  X(010).*/
        public StringBasis MDTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  MMDTMOVTO                        PIC  X(010).*/
        public StringBasis MMDTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  MCODOPER                         PIC S9(004)      COMP.*/
        public IntBasis MCODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  MDTREF                           PIC  X(010).*/
        public StringBasis MDTREF { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  MTPBENEF                         PIC  X(001).*/
        public StringBasis MTPBENEF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  MTPINCLUS                        PIC  X(001).*/
        public StringBasis MTPINCLUS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  MNUM-MATRICULA                   PIC S9(015)      COMP-3.*/
        public IntBasis MNUM_MATRICULA { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01  MMNUM-MATRICULA                  PIC S9(015)      COMP-3.*/
        public IntBasis MMNUM_MATRICULA { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01  MAGECOBR                         PIC S9(04)       COMP.*/
        public IntBasis MAGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  MNUM-CTA-CORRENTE                PIC S9(017)      COMP-3.*/
        public IntBasis MNUM_CTA_CORRENTE { get; set; } = new IntBasis(new PIC("S9", "17", "S9(017)"));
        /*"01  MDAC-CTA-CORRENTE                PIC  X(001).*/
        public StringBasis MDAC_CTA_CORRENTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  MTXAPMA                          PIC S9(003)V9(4) COMP-3.*/
        public DoubleBasis MTXAPMA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"01  MTXAPIP                          PIC S9(003)V9(4) COMP-3.*/
        public DoubleBasis MTXAPIP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"01  MTXVG                            PIC S9(003)V9(4) COMP-3.*/
        public DoubleBasis MTXVG { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"01  BENEF-NRBENEF                    PIC S9(04)       COMP.*/
        public IntBasis BENEF_NRBENEF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  BENEF-NOMBENEF                   PIC X(40).*/
        public StringBasis BENEF_NOMBENEF { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"01  BENEF-GRAUPAR                    PIC X(10).*/
        public StringBasis BENEF_GRAUPAR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  BENEF-PCTBENEF                   PIC S9(03)V99    COMP-3.*/
        public DoubleBasis BENEF_PCTBENEF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V99"), 2);
        /*"01  BENEF-DTTERVIG                   PIC X(10).*/
        public StringBasis BENEF_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  BENEF-DTINIVIG                   PIC X(10).*/
        public StringBasis BENEF_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  BENEF-DTTERVIG-I                 PIC S9(04)       COMP.*/
        public IntBasis BENEF_DTTERVIG_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  BANCOS-NRTIT                     PIC S9(013)      COMP-3.*/
        public IntBasis BANCOS_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01  FATURC-DTREF                     PIC  X(010).*/
        public StringBasis FATURC_DTREF { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  PARCEL-OCORHIST                  PIC S9(004)      COMP.*/
        public IntBasis PARCEL_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  HOST-CODCONV                     PIC S9(004)      COMP.*/
        public IntBasis HOST_CODCONV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  CONVEN-CODCONV                   PIC S9(004)      COMP.*/
        public IntBasis CONVEN_CODCONV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  CONVEN-CARTAO                    PIC S9(004)      COMP.*/
        public IntBasis CONVEN_CARTAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  HISTCB-DTVENCTO                  PIC  X(010).*/
        public StringBasis HISTCB_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  HISTCB-SITUACAO                  PIC  X(001).*/
        public StringBasis HISTCB_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  HISTCB-CODOPER                   PIC S9(004)      COMP.*/
        public IntBasis HISTCB_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  V0HCOB-VLPRMTOT                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0HCOB_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01         V1RCAC-FONTE        PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V1RCAC-NRRCAP       PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V1RCAC-NRRCAPCO     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_NRRCAPCO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V1RCAC-OPERACAO     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V1RCAC-HORAOPER     PIC  X(008).*/
        public StringBasis V1RCAC_HORAOPER { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"01         V1RCAC-DTMOVTO      PIC  X(010).*/
        public StringBasis V1RCAC_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V1RCAC-SITUACAO     PIC  X(001).*/
        public StringBasis V1RCAC_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V1RCAC-BCOAVISO     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_BCOAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V1RCAC-AGEAVISO     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_AGEAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V1RCAC-NRAVISO      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V1RCAC-VLRCAP       PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V1RCAC_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V1RCAC-DATARCAP     PIC  X(010).*/
        public StringBasis V1RCAC_DATARCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V1RCAC-DTCADAST     PIC  X(010).*/
        public StringBasis V1RCAC_DTCADAST { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V1RCAC-SITCONTB     PIC  X(001).*/
        public StringBasis V1RCAC_SITCONTB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V1RCAC-COD-EMPRESA  PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V1RCAC-TIMESTAMP    PIC  X(026).*/
        public StringBasis V1RCAC_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"01         V1RCAP-VLRCAP       PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V1RCAP_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V1RCAP-DATARCAP     PIC  X(010)       VALUE  SPACES.*/
        public StringBasis V1RCAP_DATARCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01         V0RCAP-FONTE        PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0RCAP_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0RCAP-NRRCAP       PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0RCAP_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0RCAP-NRTIT        PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V0RCAP_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01         V0RCAP-NRPROPOS     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0RCAP_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0RCAP-NOME         PIC  X(040).*/
        public StringBasis V0RCAP_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"01         V0RCAP-VLRCAP       PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V0RCAP_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V0RCAP-VALPRI       PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V0RCAP_VALPRI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V0RCAP-DTCADAST     PIC  X(010).*/
        public StringBasis V0RCAP_DTCADAST { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0RCAP-DTMOVTO      PIC  X(010).*/
        public StringBasis V0RCAP_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0RCAP-SITUACAO     PIC  X(001).*/
        public StringBasis V0RCAP_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V0RCAP-OPERACAO     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0RCAP_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0RCAP-COD-EMPRESA  PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0RCAP_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0RCAP-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0RCAP_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"01         V0RCAP-NUM-APOL     PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V0RCAP_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01         V0RCAP-NRENDOS      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0RCAP_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0RCAP-NRPARCEL     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0RCAP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V2RCAP-VLRCAP       PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V2RCAP_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  V0FOLHM-COD-CARTA                PIC  X(001).*/
        public StringBasis V0FOLHM_COD_CARTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  V0FOLHM-DTEMICAR                 PIC  X(010).*/
        public StringBasis V0FOLHM_DTEMICAR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  V0FOLH-COD-PRODUTO               PIC S9(004)      COMP.*/
        public IntBasis V0FOLH_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  V0FOLH-NRCERTIF                  PIC S9(015)      COMP-3.*/
        public IntBasis V0FOLH_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01  V0FOLH-COD-CARTA                 PIC  X(001).*/
        public StringBasis V0FOLH_COD_CARTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  V0FOLH-DTEMICAR                  PIC  X(010).*/
        public StringBasis V0FOLH_DTEMICAR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  V0FOLH-DTSOLICIT                 PIC  X(010).*/
        public StringBasis V0FOLH_DTSOLICIT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  V0FOLH-CODUSU                    PIC  X(008).*/
        public StringBasis V0FOLH_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"01  V0FOLH-SITUACAO                  PIC  X(001).*/
        public StringBasis V0FOLH_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  V0FOLH-TIMESTAMP                 PIC  X(026).*/
        public StringBasis V0FOLH_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"01  WS-WORK-AREAS.*/
        public VP0121B_WS_WORK_AREAS WS_WORK_AREAS { get; set; } = new VP0121B_WS_WORK_AREAS();
        public class VP0121B_WS_WORK_AREAS : VarBasis
        {
            /*"    03  W-NUM-PROPOSTA                PIC 9(014).*/
            public IntBasis W_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    03  CANAL  REDEFINES W-NUM-PROPOSTA.*/
            private _REDEF_VP0121B_CANAL _canal { get; set; }
            public _REDEF_VP0121B_CANAL CANAL
            {
                get { _canal = new _REDEF_VP0121B_CANAL(); _.Move(W_NUM_PROPOSTA, _canal); VarBasis.RedefinePassValue(W_NUM_PROPOSTA, _canal, W_NUM_PROPOSTA); _canal.ValueChanged += () => { _.Move(_canal, W_NUM_PROPOSTA); }; return _canal; }
                set { VarBasis.RedefinePassValue(value, _canal, W_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_VP0121B_CANAL : VarBasis
            {
                /*"        07  W-CANAL-PROPOSTA          PIC 9(001).*/

                public SelectorBasis W_CANAL_PROPOSTA { get; set; } = new SelectorBasis("001")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88 CANAL-VENDA-PAPEL                    VALUE 0. */
							new SelectorItemBasis("CANAL_VENDA_PAPEL", "0"),
							/*" 88 CANAL-VENDA-CEF                      VALUE 1. */
							new SelectorItemBasis("CANAL_VENDA_CEF", "1"),
							/*" 88 CANAL-VENDA-SASSE                    VALUE 2. */
							new SelectorItemBasis("CANAL_VENDA_SASSE", "2"),
							/*" 88 CANAL-VENDA-CORRETOR                 VALUE 3. */
							new SelectorItemBasis("CANAL_VENDA_CORRETOR", "3"),
							/*" 88 CANAL-VENDA-ATM                      VALUE 4. */
							new SelectorItemBasis("CANAL_VENDA_ATM", "4"),
							/*" 88 CANAL-VENDA-GITEL                    VALUE 5. */
							new SelectorItemBasis("CANAL_VENDA_GITEL", "5"),
							/*" 88 CANAL-VENDA-INTERNET                 VALUE 7. */
							new SelectorItemBasis("CANAL_VENDA_INTERNET", "7"),
							/*" 88 CANAL-VENDA-INTRANET                 VALUE 8. */
							new SelectorItemBasis("CANAL_VENDA_INTRANET", "8")
                }
                };

                /*"        07  FILLER                    PIC 9(013).*/
                public IntBasis FILLER_0 { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    03  FILLER REDEFINES W-NUM-PROPOSTA.*/

                public _REDEF_VP0121B_CANAL()
                {
                    W_CANAL_PROPOSTA.ValueChanged += OnValueChanged;
                    FILLER_0.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_VP0121B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_VP0121B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_VP0121B_FILLER_1(); _.Move(W_NUM_PROPOSTA, _filler_1); VarBasis.RedefinePassValue(W_NUM_PROPOSTA, _filler_1, W_NUM_PROPOSTA); _filler_1.ValueChanged += () => { _.Move(_filler_1, W_NUM_PROPOSTA); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, W_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_VP0121B_FILLER_1 : VarBasis
            {
                /*"        07  FILLER                    PIC X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-CANAL-PROPOSTA1         PIC 9(004).*/

                public SelectorBasis W_CANAL_PROPOSTA1 { get; set; } = new SelectorBasis("004")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88 PROPOSTA-CACB                      VALUE 9994. */
							new SelectorItemBasis("PROPOSTA_CACB", "9994"),
							/*" 88 PROPOSTA-COPESP                    VALUE 9995. */
							new SelectorItemBasis("PROPOSTA_COPESP", "9995")
                }
                };

                /*"        07  FILLER                    PIC 9(009).*/
                public IntBasis FILLER_3 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    03  PRODVG-CUSTOCAP-TOTAL-A          PIC  X(001).*/

                public _REDEF_VP0121B_FILLER_1()
                {
                    FILLER_2.ValueChanged += OnValueChanged;
                    W_CANAL_PROPOSTA1.ValueChanged += OnValueChanged;
                    FILLER_3.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis PRODVG_CUSTOCAP_TOTAL_A { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    03  PRODVG-CUSTOCAP-TOTAL-N          REDEFINES        PRODVG-CUSTOCAP-TOTAL-A          PIC  9(001).*/
            private _REDEF_IntBasis _prodvg_custocap_total_n { get; set; }
            public _REDEF_IntBasis PRODVG_CUSTOCAP_TOTAL_N
            {
                get { _prodvg_custocap_total_n = new _REDEF_IntBasis(new PIC("9", "001", "9(001).")); ; _.Move(PRODVG_CUSTOCAP_TOTAL_A, _prodvg_custocap_total_n); VarBasis.RedefinePassValue(PRODVG_CUSTOCAP_TOTAL_A, _prodvg_custocap_total_n, PRODVG_CUSTOCAP_TOTAL_A); _prodvg_custocap_total_n.ValueChanged += () => { _.Move(_prodvg_custocap_total_n, PRODVG_CUSTOCAP_TOTAL_A); }; return _prodvg_custocap_total_n; }
                set { VarBasis.RedefinePassValue(value, _prodvg_custocap_total_n, PRODVG_CUSTOCAP_TOTAL_A); }
            }  //Redefines
            /*"    03  WS-CHAVE.*/
            public VP0121B_WS_CHAVE WS_CHAVE { get; set; } = new VP0121B_WS_CHAVE();
            public class VP0121B_WS_CHAVE : VarBasis
            {
                /*"        05 WS-NUM-APOLICE            PIC 9(13).*/
                public IntBasis WS_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
                /*"        05 WS-CODSUBES               PIC 9(04).*/
                public IntBasis WS_CODSUBES { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"    03  WS-CHAVE-ANT.*/
            }
            public VP0121B_WS_CHAVE_ANT WS_CHAVE_ANT { get; set; } = new VP0121B_WS_CHAVE_ANT();
            public class VP0121B_WS_CHAVE_ANT : VarBasis
            {
                /*"        05 WS-NUM-APOLICE-ANT        PIC 9(13)      VALUE ZEROS.*/
                public IntBasis WS_NUM_APOLICE_ANT { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
                /*"        05 WS-CODSUBES-ANT           PIC 9(04)      VALUE ZEROS.*/
                public IntBasis WS_CODSUBES_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"    03  WS-QTDE-ANOS                 PIC 9(02)      VALUE ZEROS.*/
            }
            public IntBasis WS_QTDE_ANOS { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
            /*"    03  WS-COUNT                     PIC 9(02)      VALUE ZEROS.*/
            public IntBasis WS_COUNT { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
            /*"    03  WS-TAXA-VG                   PIC 9(02)V99   VALUE ZEROS.*/
            public DoubleBasis WS_TAXA_VG { get; set; } = new DoubleBasis(new PIC("9", "2", "9(02)V99"), 2);
            /*"    03  WS-TAXA-AP                   PIC 9(02)V99   VALUE ZEROS.*/
            public DoubleBasis WS_TAXA_AP { get; set; } = new DoubleBasis(new PIC("9", "2", "9(02)V99"), 2);
            /*"    03  WS-TAXA-TOT                  PIC 9(02)V99   VALUE ZEROS.*/
            public DoubleBasis WS_TAXA_TOT { get; set; } = new DoubleBasis(new PIC("9", "2", "9(02)V99"), 2);
            /*"    03  WTEM-SIVPF                   PIC 9 VALUE 0.*/
            public IntBasis WTEM_SIVPF { get; set; } = new IntBasis(new PIC("9", "1", "9"));
            /*"    03  WTEM-MOVFEDCA                PIC X(03)     VALUE SPACES.*/
            public StringBasis WTEM_MOVFEDCA { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
            /*"    03  WS-EOF                       PIC 9 VALUE 0.*/
            public IntBasis WS_EOF { get; set; } = new IntBasis(new PIC("9", "1", "9"));
            /*"    03  WS-EOP                       PIC 9 VALUE 0.*/
            public IntBasis WS_EOP { get; set; } = new IntBasis(new PIC("9", "1", "9"));
            /*"    03  WS-EOS                       PIC 9 VALUE 0.*/
            public IntBasis WS_EOS { get; set; } = new IntBasis(new PIC("9", "1", "9"));
            /*"    03  WS-EOF-D                     PIC 9 VALUE 0.*/
            public IntBasis WS_EOF_D { get; set; } = new IntBasis(new PIC("9", "1", "9"));
            /*"    03  WFIM-V1RCAP                  PIC X(001)  VALUE SPACES.*/
            public StringBasis WFIM_V1RCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    03  WTEM-V0RCAP                  PIC X(001)  VALUE SPACES.*/
            public StringBasis WTEM_V0RCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    03  WTEM-ERRO-7705               PIC X(001)  VALUE SPACES.*/
            public StringBasis WTEM_ERRO_7705 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    03  WTEM-ERRO-7715               PIC X(001)  VALUE SPACES.*/
            public StringBasis WTEM_ERRO_7715 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    03  WS-SIT-REGISTRO              PIC X(001).*/
            public StringBasis WS_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    03  WS-RATEIO                    PIC  9(003)V9(5).*/
            public DoubleBasis WS_RATEIO { get; set; } = new DoubleBasis(new PIC("9", "3", "9(003)V9(5)."), 5);
            /*"    03  WS-IND-IOF                   PIC S9(001)V9(4) COMP-3.*/
            public DoubleBasis WS_IND_IOF { get; set; } = new DoubleBasis(new PIC("S9", "1", "S9(001)V9(4)"), 4);
            /*"    03  WS-COD-CARTA                 PIC  X(001).*/
            public StringBasis WS_COD_CARTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    03  WS-CODPRODU-ANT              PIC S9(004)  COMP  VALUE +0*/
            public IntBasis WS_CODPRODU_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    03  W01A0100.*/
            public VP0121B_W01A0100 W01A0100 { get; set; } = new VP0121B_W01A0100();
            public class VP0121B_W01A0100 : VarBasis
            {
                /*"        05 W01N0100                  PIC 9(01).*/
                public IntBasis W01N0100 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"    03  WSQLCODE3                    PIC S9(009) COMP.*/
            }
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    03  WSQLCODE-PLANOS              PIC S9(009) COMP.*/
            public IntBasis WSQLCODE_PLANOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    03 W-DTEMICAR      PIC X(010) VALUE SPACES.*/
            public StringBasis W_DTEMICAR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    03 FILLER  REDEFINES W-DTEMICAR.*/
            private _REDEF_VP0121B_FILLER_4 _filler_4 { get; set; }
            public _REDEF_VP0121B_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_VP0121B_FILLER_4(); _.Move(W_DTEMICAR, _filler_4); VarBasis.RedefinePassValue(W_DTEMICAR, _filler_4, W_DTEMICAR); _filler_4.ValueChanged += () => { _.Move(_filler_4, W_DTEMICAR); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, W_DTEMICAR); }
            }  //Redefines
            public class _REDEF_VP0121B_FILLER_4 : VarBasis
            {
                /*"       05 W-SSEMICAR                 PIC 9(004).*/
                public IntBasis W_SSEMICAR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05 FILLER                     PIC X(001).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05 W-MMEMICAR                 PIC 9(002).*/
                public IntBasis W_MMEMICAR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05 FILLER                     PIC X(001).*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05 W-DDEMICAR                 PIC 9(002).*/
                public IntBasis W_DDEMICAR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03 WS-VIGENCIA.*/

                public _REDEF_VP0121B_FILLER_4()
                {
                    W_SSEMICAR.ValueChanged += OnValueChanged;
                    FILLER_5.ValueChanged += OnValueChanged;
                    W_MMEMICAR.ValueChanged += OnValueChanged;
                    FILLER_6.ValueChanged += OnValueChanged;
                    W_DDEMICAR.ValueChanged += OnValueChanged;
                }

            }
            public VP0121B_WS_VIGENCIA WS_VIGENCIA { get; set; } = new VP0121B_WS_VIGENCIA();
            public class VP0121B_WS_VIGENCIA : VarBasis
            {
                /*"       05  WS-VIG-ANO                PIC 9(004).*/
                public IntBasis WS_VIG_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05  FILLER                    PIC X(001).*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  WS-VIG-MES                PIC 9(002).*/
                public IntBasis WS_VIG_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05  FILLER                    PIC X(001).*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  WS-VIG-DIA                PIC 9(002).*/
                public IntBasis WS_VIG_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03 WS-VIGENCIA1.*/
            }
            public VP0121B_WS_VIGENCIA1 WS_VIGENCIA1 { get; set; } = new VP0121B_WS_VIGENCIA1();
            public class VP0121B_WS_VIGENCIA1 : VarBasis
            {
                /*"       05  WS-VIG-ANO1               PIC 9(004).*/
                public IntBasis WS_VIG_ANO1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05  FILLER                    PIC X(001).*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  WS-VIG-MES1               PIC 9(002).*/
                public IntBasis WS_VIG_MES1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05  FILLER                    PIC X(001).*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  WS-VIG-DIA1               PIC 9(002).*/
                public IntBasis WS_VIG_DIA1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03 W01DTSQL                      PIC X(010).*/
            }
            public StringBasis W01DTSQL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    03 W01DTSQL-R    REDEFINES W01DTSQL.*/
            private _REDEF_VP0121B_W01DTSQL_R _w01dtsql_r { get; set; }
            public _REDEF_VP0121B_W01DTSQL_R W01DTSQL_R
            {
                get { _w01dtsql_r = new _REDEF_VP0121B_W01DTSQL_R(); _.Move(W01DTSQL, _w01dtsql_r); VarBasis.RedefinePassValue(W01DTSQL, _w01dtsql_r, W01DTSQL); _w01dtsql_r.ValueChanged += () => { _.Move(_w01dtsql_r, W01DTSQL); }; return _w01dtsql_r; }
                set { VarBasis.RedefinePassValue(value, _w01dtsql_r, W01DTSQL); }
            }  //Redefines
            public class _REDEF_VP0121B_W01DTSQL_R : VarBasis
            {
                /*"       05  W01AASQL                  PIC 9(004).*/
                public IntBasis W01AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05  W01T1SQL                  PIC X(001).*/
                public StringBasis W01T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  W01MMSQL                  PIC 9(002).*/
                public IntBasis W01MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05  W01T2SQL                  PIC X(001).*/
                public StringBasis W01T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  W01DDSQL                  PIC 9(002).*/
                public IntBasis W01DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03 W02DTSQL.*/

                public _REDEF_VP0121B_W01DTSQL_R()
                {
                    W01AASQL.ValueChanged += OnValueChanged;
                    W01T1SQL.ValueChanged += OnValueChanged;
                    W01MMSQL.ValueChanged += OnValueChanged;
                    W01T2SQL.ValueChanged += OnValueChanged;
                    W01DDSQL.ValueChanged += OnValueChanged;
                }

            }
            public VP0121B_W02DTSQL W02DTSQL { get; set; } = new VP0121B_W02DTSQL();
            public class VP0121B_W02DTSQL : VarBasis
            {
                /*"       05  W02AAMMSQL.*/
                public VP0121B_W02AAMMSQL W02AAMMSQL { get; set; } = new VP0121B_W02AAMMSQL();
                public class VP0121B_W02AAMMSQL : VarBasis
                {
                    /*"           10  W02AASQL              PIC 9(004).*/
                    public IntBasis W02AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"           10  W02T1SQL              PIC X(001).*/
                    public StringBasis W02T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"           10  W02MMSQL              PIC 9(002).*/
                    public IntBasis W02MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"       05  W02T2SQL                  PIC X(001).*/
                }
                public StringBasis W02T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  W02DDSQL                  PIC 9(002).*/
                public IntBasis W02DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03 W03DTSQL.*/
            }
            public VP0121B_W03DTSQL W03DTSQL { get; set; } = new VP0121B_W03DTSQL();
            public class VP0121B_W03DTSQL : VarBasis
            {
                /*"       05  W03AAMMSQL.*/
                public VP0121B_W03AAMMSQL W03AAMMSQL { get; set; } = new VP0121B_W03AAMMSQL();
                public class VP0121B_W03AAMMSQL : VarBasis
                {
                    /*"           10  W03AASQL              PIC 9(004).*/
                    public IntBasis W03AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"           10  W03T1SQL              PIC X(001).*/
                    public StringBasis W03T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"           10  W03MMSQL              PIC 9(002).*/
                    public IntBasis W03MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"       05  W03T2SQL                  PIC X(001).*/
                }
                public StringBasis W03T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  W03DDSQL                  PIC 9(002).*/
                public IntBasis W03DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03 W04DTSQL.*/
            }
            public VP0121B_W04DTSQL W04DTSQL { get; set; } = new VP0121B_W04DTSQL();
            public class VP0121B_W04DTSQL : VarBasis
            {
                /*"       05  W04SASQL                  PIC 9(004).*/
                public IntBasis W04SASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05  W04SASQL-R                REDEFINES           W04SASQL.*/
                private _REDEF_VP0121B_W04SASQL_R _w04sasql_r { get; set; }
                public _REDEF_VP0121B_W04SASQL_R W04SASQL_R
                {
                    get { _w04sasql_r = new _REDEF_VP0121B_W04SASQL_R(); _.Move(W04SASQL, _w04sasql_r); VarBasis.RedefinePassValue(W04SASQL, _w04sasql_r, W04SASQL); _w04sasql_r.ValueChanged += () => { _.Move(_w04sasql_r, W04SASQL); }; return _w04sasql_r; }
                    set { VarBasis.RedefinePassValue(value, _w04sasql_r, W04SASQL); }
                }  //Redefines
                public class _REDEF_VP0121B_W04SASQL_R : VarBasis
                {
                    /*"         10  W04AASQL                PIC 9(004).*/
                    public IntBasis W04AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"       05  W04T1SQL                  PIC X(001).*/

                    public _REDEF_VP0121B_W04SASQL_R()
                    {
                        W04AASQL.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis W04T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  W04MMSQL                  PIC 9(002).*/
                public IntBasis W04MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05  W04T2SQL                  PIC X(001).*/
                public StringBasis W04T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  W04DDSQL                  PIC 9(002).*/
                public IntBasis W04DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03 W05DTSQL.*/
            }
            public VP0121B_W05DTSQL W05DTSQL { get; set; } = new VP0121B_W05DTSQL();
            public class VP0121B_W05DTSQL : VarBasis
            {
                /*"       05  W05AASQL                  PIC 9(004).*/
                public IntBasis W05AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05  W05T1SQL                  PIC X(001).*/
                public StringBasis W05T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  W05MMSQL                  PIC 9(002).*/
                public IntBasis W05MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05  W05T2SQL                  PIC X(001).*/
                public StringBasis W05T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  W05DDSQL                  PIC 9(002).*/
                public IntBasis W05DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03 WS-CONT-BENEF                 PIC  9(004) VALUE 0.*/
            }
            public IntBasis WS_CONT_BENEF { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    03 WS-CTA-CORRENTE-R.*/
            public VP0121B_WS_CTA_CORRENTE_R WS_CTA_CORRENTE_R { get; set; } = new VP0121B_WS_CTA_CORRENTE_R();
            public class VP0121B_WS_CTA_CORRENTE_R : VarBasis
            {
                /*"       05 WS-OPER-SEG                PIC  9(004).*/
                public IntBasis WS_OPER_SEG { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05 WS-CTA-SEG                 PIC  9(012).*/
                public IntBasis WS_CTA_SEG { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"    03  WS-CTA-CORRENTE              REDEFINES        WS-CTA-CORRENTE-R            PIC 9(016).*/
            }
            private _REDEF_IntBasis _ws_cta_corrente { get; set; }
            public _REDEF_IntBasis WS_CTA_CORRENTE
            {
                get { _ws_cta_corrente = new _REDEF_IntBasis(new PIC("9", "016", "9(016).")); ; _.Move(WS_CTA_CORRENTE_R, _ws_cta_corrente); VarBasis.RedefinePassValue(WS_CTA_CORRENTE_R, _ws_cta_corrente, WS_CTA_CORRENTE_R); _ws_cta_corrente.ValueChanged += () => { _.Move(_ws_cta_corrente, WS_CTA_CORRENTE_R); }; return _ws_cta_corrente; }
                set { VarBasis.RedefinePassValue(value, _ws_cta_corrente, WS_CTA_CORRENTE_R); }
            }  //Redefines
            /*"    03 WS-CTA-CORRENTE-VR.*/
            public VP0121B_WS_CTA_CORRENTE_VR WS_CTA_CORRENTE_VR { get; set; } = new VP0121B_WS_CTA_CORRENTE_VR();
            public class VP0121B_WS_CTA_CORRENTE_VR : VarBasis
            {
                /*"       05 WS-OPER                    PIC  9(004).*/
                public IntBasis WS_OPER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05 WS-CTA                     PIC  9(012).*/
                public IntBasis WS_CTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"    03 WS-CTA-CORRENTEV              REDEFINES       WS-CTA-CORRENTE-VR            PIC 9(016).*/
            }
            private _REDEF_IntBasis _ws_cta_correntev { get; set; }
            public _REDEF_IntBasis WS_CTA_CORRENTEV
            {
                get { _ws_cta_correntev = new _REDEF_IntBasis(new PIC("9", "016", "9(016).")); ; _.Move(WS_CTA_CORRENTE_VR, _ws_cta_correntev); VarBasis.RedefinePassValue(WS_CTA_CORRENTE_VR, _ws_cta_correntev, WS_CTA_CORRENTE_VR); _ws_cta_correntev.ValueChanged += () => { _.Move(_ws_cta_correntev, WS_CTA_CORRENTE_VR); }; return _ws_cta_correntev; }
                set { VarBasis.RedefinePassValue(value, _ws_cta_correntev, WS_CTA_CORRENTE_VR); }
            }  //Redefines
            /*"    03 WS-ENCONTROU                  PIC  X(001) VALUE 'S'.*/

            public SelectorBasis WS_ENCONTROU { get; set; } = new SelectorBasis("001", "S")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 ENCONTROU                  VALUE 'S'. */
							new SelectorItemBasis("ENCONTROU", "S"),
							/*" 88 NAO-ENCONTROU              VALUE 'N'. */
							new SelectorItemBasis("NAO_ENCONTROU", "N")
                }
            };

            /*"    03 WS-LEITUA-SIVPF               PIC  X(001) VALUE 'N'.*/

            public SelectorBasis WS_LEITUA_SIVPF { get; set; } = new SelectorBasis("001", "N")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 LEU-SIVPF                  VALUE 'S'. */
							new SelectorItemBasis("LEU_SIVPF", "S"),
							/*" 88 NAO-LEU-SIVPF              VALUE 'N'. */
							new SelectorItemBasis("NAO_LEU_SIVPF", "N")
                }
            };

            /*"    03 WS-ACESSO-CLIENTE             PIC  9(001) VALUE ZERO.*/

            public SelectorBasis WS_ACESSO_CLIENTE { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 ACESSO-CLIENTE-OK                       VALUE 1. */
							new SelectorItemBasis("ACESSO_CLIENTE_OK", "1"),
							/*" 88 ACESSO-CLIENTE-ER                       VALUE 2. */
							new SelectorItemBasis("ACESSO_CLIENTE_ER", "2")
                }
            };

            /*"    03  W-RCAPS                      PIC 9(001).*/

            public SelectorBasis W_RCAPS { get; set; } = new SelectorBasis("001")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 RCAP-CADASTRADO                       VALUE 01. */
							new SelectorItemBasis("RCAP_CADASTRADO", "01")
                }
            };

            /*"    03  W-RCAP-COMP                  PIC 9(001).*/

            public SelectorBasis W_RCAP_COMP { get; set; } = new SelectorBasis("001")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 RCAP-COMP-CADASTRADO                  VALUE 01. */
							new SelectorItemBasis("RCAP_COMP_CADASTRADO", "01")
                }
            };

            /*"    03  W-NOVO-CALCULO                PIC 9(002).*/

            public SelectorBasis W_NOVO_CALCULO { get; set; } = new SelectorBasis("002")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 NOVO-CALCULO-PREMIO                      VALUE 01. */
							new SelectorItemBasis("NOVO_CALCULO_PREMIO", "01")
                }
            };

            /*"    03 UPDATE-SIVPF-SIVPF            PIC  9(006) VALUE  0.*/
            public IntBasis UPDATE_SIVPF_SIVPF { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-LIDOS                      PIC  9(007) VALUE  0.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-INCLUSOES                  PIC  9(007) VALUE  0.*/
            public IntBasis AC_INCLUSOES { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-DESPREZADOS                PIC  9(007) VALUE  0.*/
            public IntBasis AC_DESPREZADOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-DESPR-PRODUVG              PIC  9(007) VALUE  0.*/
            public IntBasis AC_DESPR_PRODUVG { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-DESPR-AGENCCEF             PIC  9(007) VALUE  0.*/
            public IntBasis AC_DESPR_AGENCCEF { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-DESPR-CARTAO               PIC  9(007) VALUE  0.*/
            public IntBasis AC_DESPR_CARTAO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-DESPR-CLIENTE              PIC  9(007) VALUE  0.*/
            public IntBasis AC_DESPR_CLIENTE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-DESPR-CONTA                PIC  9(007) VALUE  0.*/
            public IntBasis AC_DESPR_CONTA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-DESPR-DPS-TIT              PIC  9(007) VALUE  0.*/
            public IntBasis AC_DESPR_DPS_TIT { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-DESPR-FONTE                PIC  9(007) VALUE  0.*/
            public IntBasis AC_DESPR_FONTE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-DESPR-HISCOBPR             PIC  9(007) VALUE  0.*/
            public IntBasis AC_DESPR_HISCOBPR { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-DESPR-IDADE                PIC  9(007) VALUE  0.*/
            public IntBasis AC_DESPR_IDADE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-DESPR-OPCAOPAG             PIC  9(007) VALUE  0.*/
            public IntBasis AC_DESPR_OPCAOPAG { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-DESPR-PARCELVA             PIC  9(007) VALUE  0.*/
            public IntBasis AC_DESPR_PARCELVA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-DESPR-PERIPGTO             PIC  9(007) VALUE  0.*/
            public IntBasis AC_DESPR_PERIPGTO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-DESPR-PLAVAVGA             PIC  9(007) VALUE  0.*/
            public IntBasis AC_DESPR_PLAVAVGA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-DESPR-7705                 PIC  9(007) VALUE  0.*/
            public IntBasis AC_DESPR_7705 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-DESPR-7715                 PIC  9(007) VALUE  0.*/
            public IntBasis AC_DESPR_7715 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03 AC-FOLHETOS                   PIC  9(007) VALUE  ZEROS.*/
            public IntBasis AC_FOLHETOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    03  W-NUMR-TITULO                PIC  9(013)   VALUE ZEROS.*/
            public IntBasis W_NUMR_TITULO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"    03  FILLER                       REDEFINES    W-NUMR-TITULO.*/
            private _REDEF_VP0121B_FILLER_11 _filler_11 { get; set; }
            public _REDEF_VP0121B_FILLER_11 FILLER_11
            {
                get { _filler_11 = new _REDEF_VP0121B_FILLER_11(); _.Move(W_NUMR_TITULO, _filler_11); VarBasis.RedefinePassValue(W_NUMR_TITULO, _filler_11, W_NUMR_TITULO); _filler_11.ValueChanged += () => { _.Move(_filler_11, W_NUMR_TITULO); }; return _filler_11; }
                set { VarBasis.RedefinePassValue(value, _filler_11, W_NUMR_TITULO); }
            }  //Redefines
            public class _REDEF_VP0121B_FILLER_11 : VarBasis
            {
                /*"      05    WTITL-ZEROS              PIC  9(002).*/
                public IntBasis WTITL_ZEROS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05    WTITL-SEQUENCIA          PIC  9(010).*/
                public IntBasis WTITL_SEQUENCIA { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"      05    WTITL-DIGITO             PIC  9(001).*/
                public IntBasis WTITL_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    03              DPARM01X.*/

                public _REDEF_VP0121B_FILLER_11()
                {
                    WTITL_ZEROS.ValueChanged += OnValueChanged;
                    WTITL_SEQUENCIA.ValueChanged += OnValueChanged;
                    WTITL_DIGITO.ValueChanged += OnValueChanged;
                }

            }
            public VP0121B_DPARM01X DPARM01X { get; set; } = new VP0121B_DPARM01X();
            public class VP0121B_DPARM01X : VarBasis
            {
                /*"      05            DPARM01          PIC  9(010).*/
                public IntBasis DPARM01 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"      05            DPARM01-R        REDEFINES   DPARM01.*/
                private _REDEF_VP0121B_DPARM01_R _dparm01_r { get; set; }
                public _REDEF_VP0121B_DPARM01_R DPARM01_R
                {
                    get { _dparm01_r = new _REDEF_VP0121B_DPARM01_R(); _.Move(DPARM01, _dparm01_r); VarBasis.RedefinePassValue(DPARM01, _dparm01_r, DPARM01); _dparm01_r.ValueChanged += () => { _.Move(_dparm01_r, DPARM01); }; return _dparm01_r; }
                    set { VarBasis.RedefinePassValue(value, _dparm01_r, DPARM01); }
                }  //Redefines
                public class _REDEF_VP0121B_DPARM01_R : VarBasis
                {
                    /*"        10          DPARM01-1        PIC  9(001).*/
                    public IntBasis DPARM01_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-2        PIC  9(001).*/
                    public IntBasis DPARM01_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-3        PIC  9(001).*/
                    public IntBasis DPARM01_3 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-4        PIC  9(001).*/
                    public IntBasis DPARM01_4 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-5        PIC  9(001).*/
                    public IntBasis DPARM01_5 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-6        PIC  9(001).*/
                    public IntBasis DPARM01_6 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-7        PIC  9(001).*/
                    public IntBasis DPARM01_7 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-8        PIC  9(001).*/
                    public IntBasis DPARM01_8 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-9        PIC  9(001).*/
                    public IntBasis DPARM01_9 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-10       PIC  9(001).*/
                    public IntBasis DPARM01_10 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      05            DPARM01-D1       PIC  9(001).*/

                    public _REDEF_VP0121B_DPARM01_R()
                    {
                        DPARM01_1.ValueChanged += OnValueChanged;
                        DPARM01_2.ValueChanged += OnValueChanged;
                        DPARM01_3.ValueChanged += OnValueChanged;
                        DPARM01_4.ValueChanged += OnValueChanged;
                        DPARM01_5.ValueChanged += OnValueChanged;
                        DPARM01_6.ValueChanged += OnValueChanged;
                        DPARM01_7.ValueChanged += OnValueChanged;
                        DPARM01_8.ValueChanged += OnValueChanged;
                        DPARM01_9.ValueChanged += OnValueChanged;
                        DPARM01_10.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis DPARM01_D1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"      05            DPARM01-RC       PIC S9(004) COMP VALUE +0.*/
                public IntBasis DPARM01_RC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    03 PARM-PROSOMU1.*/
            }
            public VP0121B_PARM_PROSOMU1 PARM_PROSOMU1 { get; set; } = new VP0121B_PARM_PROSOMU1();
            public class VP0121B_PARM_PROSOMU1 : VarBasis
            {
                /*"      05 SU1-DATA1.*/
                public VP0121B_SU1_DATA1 SU1_DATA1 { get; set; } = new VP0121B_SU1_DATA1();
                public class VP0121B_SU1_DATA1 : VarBasis
                {
                    /*"        10 SU1-DD1                   PIC 99.*/
                    public IntBasis SU1_DD1 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"        10 SU1-MM1                   PIC 99.*/
                    public IntBasis SU1_MM1 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"        10 SU1-AA1                   PIC 9999.*/
                    public IntBasis SU1_AA1 { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
                    /*"      05 SU1-NRDIAS                  PIC S9(5) COMP-3.*/
                }
                public IntBasis SU1_NRDIAS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(5)"));
                /*"      05 SU1-DATA2.*/
                public VP0121B_SU1_DATA2 SU1_DATA2 { get; set; } = new VP0121B_SU1_DATA2();
                public class VP0121B_SU1_DATA2 : VarBasis
                {
                    /*"        10 SU1-DD2                   PIC 99.*/
                    public IntBasis SU1_DD2 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"        10 SU1-MM2                   PIC 99.*/
                    public IntBasis SU1_MM2 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"        10 SU1-AA2                   PIC 9999.*/
                    public IntBasis SU1_AA2 { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
                    /*"01  WS-SQLCODE                    PIC  ---9.*/
                }
            }
        }
        public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("9", "4", "---9."));
        /*"01     WS-NUM-TITULO-X.*/
        public VP0121B_WS_NUM_TITULO_X WS_NUM_TITULO_X { get; set; } = new VP0121B_WS_NUM_TITULO_X();
        public class VP0121B_WS_NUM_TITULO_X : VarBasis
        {
            /*"   05  WS-NUM-PLANO                  PIC  9(003).*/
            public IntBasis WS_NUM_PLANO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"   05  WS-NUM-SERIE                  PIC  9(003).*/
            public IntBasis WS_NUM_SERIE { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"   05  WS-NUM-TITULO                 PIC  9(006).*/
            public IntBasis WS_NUM_TITULO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"01     WS-NUM-TITULO-9               REDEFINES       WS-NUM-TITULO-X               PIC  9(012).*/
        }
        private _REDEF_IntBasis _ws_num_titulo_9 { get; set; }
        public _REDEF_IntBasis WS_NUM_TITULO_9
        {
            get { _ws_num_titulo_9 = new _REDEF_IntBasis(new PIC("9", "012", "9(012).")); ; _.Move(WS_NUM_TITULO_X, _ws_num_titulo_9); VarBasis.RedefinePassValue(WS_NUM_TITULO_X, _ws_num_titulo_9, WS_NUM_TITULO_X); _ws_num_titulo_9.ValueChanged += () => { _.Move(_ws_num_titulo_9, WS_NUM_TITULO_X); }; return _ws_num_titulo_9; }
            set { VarBasis.RedefinePassValue(value, _ws_num_titulo_9, WS_NUM_TITULO_X); }
        }  //Redefines
        /*"01     WS-COMBINACAO                 PIC  X(020).*/
        public StringBasis WS_COMBINACAO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"01     WS-COMBINACAO-R               REDEFINES       WS-COMBINACAO.*/
        private _REDEF_VP0121B_WS_COMBINACAO_R _ws_combinacao_r { get; set; }
        public _REDEF_VP0121B_WS_COMBINACAO_R WS_COMBINACAO_R
        {
            get { _ws_combinacao_r = new _REDEF_VP0121B_WS_COMBINACAO_R(); _.Move(WS_COMBINACAO, _ws_combinacao_r); VarBasis.RedefinePassValue(WS_COMBINACAO, _ws_combinacao_r, WS_COMBINACAO); _ws_combinacao_r.ValueChanged += () => { _.Move(_ws_combinacao_r, WS_COMBINACAO); }; return _ws_combinacao_r; }
            set { VarBasis.RedefinePassValue(value, _ws_combinacao_r, WS_COMBINACAO); }
        }  //Redefines
        public class _REDEF_VP0121B_WS_COMBINACAO_R : VarBasis
        {
            /*"   05  WS-COMB OCCURS 20 TIMES       PIC  X(001).*/
            public ListBasis<StringBasis, string> WS_COMB { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(001)."), 20);
            /*"01     WS-COMBINACAO-9               PIC  9(009).*/

            public _REDEF_VP0121B_WS_COMBINACAO_R()
            {
                WS_COMB.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis WS_COMBINACAO_9 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
        /*"01  WABEND.*/
        public VP0121B_WABEND WABEND { get; set; } = new VP0121B_WABEND();
        public class VP0121B_WABEND : VarBasis
        {
            /*"      10    FILLER                   PIC  X(010) VALUE            'VP0121B  '.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VP0121B  ");
            /*"      10    FILLER                   PIC  X(028) VALUE            ' *** ERRO  EXEC SQL *** '.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL *** ");
            /*"      10    FILLER                   PIC  X(014) VALUE            '    SQLCODE = '.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
            /*"      10    WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD1 = '.*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
            /*"      10    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"      10    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
            public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
            /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
            public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"      10    FILLER                   PIC  X(012)   VALUE            'COMANDO   = '.*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
            /*"      10    COMANDO                  PIC  X(060)   VALUE SPACES.*/
            public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
            /*"01           FC0001S-LINKAGE.*/
        }
        public VP0121B_FC0001S_LINKAGE FC0001S_LINKAGE { get; set; } = new VP0121B_FC0001S_LINKAGE();
        public class VP0121B_FC0001S_LINKAGE : VarBasis
        {
            /*"  05         FC0001S-NUM-PROPOSTA    PIC  S9(015)    COMP-3.*/
            public IntBasis FC0001S_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            /*"  05         FC0001S-VLR-MENSALIDADE PIC  S9(008)V99 COMP-3.*/
            public DoubleBasis FC0001S_VLR_MENSALIDADE { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(008)V99"), 2);
            /*"  05         FC0001S-NUM-PLANO       PIC  S9(004) COMP.*/
            public IntBasis FC0001S_NUM_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05         FC0001S-NUM-SERIE       PIC  S9(004) COMP.*/
            public IntBasis FC0001S_NUM_SERIE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05         FC0001S-NUM-TITULO      PIC  S9(009) COMP.*/
            public IntBasis FC0001S_NUM_TITULO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05         FC0001S-IND-DV          PIC  S9(004) COMP.*/
            public IntBasis FC0001S_IND_DV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05         FC0001S-DTH-INI-VIGENCIA PIC   X(010).*/
            public StringBasis FC0001S_DTH_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05         FC0001S-DTH-FIM-VIGENCIA PIC   X(010).*/
            public StringBasis FC0001S_DTH_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05         FC0001S-DES-COMBINACAO  PIC   X(020).*/
            public StringBasis FC0001S_DES_COMBINACAO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05         FC0001S-SQLCODE         PIC  S9(004) COMP.*/
            public IntBasis FC0001S_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05         FC0001S-COD-RETORNO     PIC  S9(004) COMP.*/
            public IntBasis FC0001S_COD_RETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05         FC0001S-DES-MENSAGEM    PIC   X(070).*/
            public StringBasis FC0001S_DES_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
            /*"01         LK-NUM-PLANO            PIC S9(4)      USAGE COMP.*/
        }
        public IntBasis LK_NUM_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01         LK-NUM-SERIE            PIC S9(4)      USAGE COMP.*/
        public IntBasis LK_NUM_SERIE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01         LK-NUM-TITULO           PIC S9(9)      USAGE COMP.*/
        public IntBasis LK_NUM_TITULO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01         LK-NUM-PROPOSTA         PIC S9(15)V    USAGE COMP-3.*/
        public DoubleBasis LK_NUM_PROPOSTA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"01         LK-QTD-TITULOS          PIC S9(4)      USAGE COMP.*/
        public IntBasis LK_QTD_TITULOS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01         LK-VLR-TITULO           PIC S9(8)V9(2) USAGE COMP-3.*/
        public DoubleBasis LK_VLR_TITULO { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(8)V9(2)"), 2);
        /*"01         LK-EMP-PARCEIRA         PIC S9(4)      USAGE COMP.*/
        public IntBasis LK_EMP_PARCEIRA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01         LK-COD-RAMO             PIC S9(4)      USAGE COMP.*/
        public IntBasis LK_COD_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01         LK-TRACE                PIC X(009).*/

        public SelectorBasis LK_TRACE { get; set; } = new SelectorBasis("009")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88       LK-TRACE-ON             VALUE 'TRACE ON '. */
							new SelectorItemBasis("LK_TRACE_ON", "TRACE ON "),
							/*" 88       LK-TRACE-OFF            VALUE 'TRACE OFF'. */
							new SelectorItemBasis("LK_TRACE_OFF", "TRACE OFF")
                }
        };

        /*"01         LK-OUT-COD-RETORNO     PIC S9(004) COMP.*/
        public IntBasis LK_OUT_COD_RETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         LK-OUT-SQLCODE         PIC S9(004) COMP.*/
        public IntBasis LK_OUT_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         LK-OUT-MENSAGEM        PIC X(070).*/
        public StringBasis LK_OUT_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
        /*"01         LK-OUT-SQLERRMC        PIC X(070).*/
        public StringBasis LK_OUT_SQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
        /*"01         LK-OUT-SQLSTATE        PIC X(005).*/
        public StringBasis LK_OUT_SQLSTATE { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");


        public Dclgens.RCAPS RCAPS { get; set; } = new Dclgens.RCAPS();
        public Dclgens.RCAPCOMP RCAPCOMP { get; set; } = new Dclgens.RCAPCOMP();
        public Dclgens.MOVFEDCA MOVFEDCA { get; set; } = new Dclgens.MOVFEDCA();
        public Dclgens.TITFEDCA TITFEDCA { get; set; } = new Dclgens.TITFEDCA();
        public Dclgens.COMFEDCA COMFEDCA { get; set; } = new Dclgens.COMFEDCA();
        public Dclgens.PARFEDCA PARFEDCA { get; set; } = new Dclgens.PARFEDCA();
        public Dclgens.FCSERIE FCSERIE { get; set; } = new Dclgens.FCSERIE();
        public Dclgens.ERRPROVI ERRPROVI { get; set; } = new Dclgens.ERRPROVI();
        public Dclgens.COMISSOE COMISSOE { get; set; } = new Dclgens.COMISSOE();
        public Dclgens.MOVDEBCE MOVDEBCE { get; set; } = new Dclgens.MOVDEBCE();
        public Dclgens.PARAMRAM PARAMRAM { get; set; } = new Dclgens.PARAMRAM();
        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public VP0121B_CPROPVA CPROPVA { get; set; } = new VP0121B_CPROPVA();
        public VP0121B_V1RCAPCOMP V1RCAPCOMP { get; set; } = new VP0121B_V1RCAPCOMP();
        public VP0121B_CBENEFP CBENEFP { get; set; } = new VP0121B_CBENEFP();
        public VP0121B_C01_RCAPCOMP C01_RCAPCOMP { get; set; } = new VP0121B_C01_RCAPCOMP();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -0- FLUXCONTROL_PERFORM M-0000-PRINCIPAL */

                M_0000_PRINCIPAL();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            return Result;
        }

        [StopWatch]
        /*" M-0000-PRINCIPAL */
        private void M_0000_PRINCIPAL(bool isPerform = false)
        {
            /*" -1336- DISPLAY ' ' */
            _.Display($" ");

            /*" -1338- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -1339- DISPLAY 'PROGRAMA VP0121B' */
            _.Display($"PROGRAMA VP0121B");

            /*" -1346- DISPLAY 'VERSAO V.81 - DEMANDA 259990 - ' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) '-' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) */

            $"VERSAO V.81 - DEMANDA 259990 - FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)}-FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}"
            .Display();

            /*" -1348- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -1350- DISPLAY ' ' */
            _.Display($" ");

            /*" -1358- DISPLAY 'INICIO PROCESSAMENTO EM  ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"INICIO PROCESSAMENTO EM  {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -1359- MOVE '0000-PRINCIPAL' TO PARAGRAFO. */
            _.Move("0000-PRINCIPAL", WABEND.PARAGRAFO);

            /*" -1361- MOVE 'SELECT SISTEMA' TO COMANDO. */
            _.Move("SELECT SISTEMA", WABEND.COMANDO);

            /*" -1373- PERFORM M_0000_PRINCIPAL_DB_SELECT_1 */

            M_0000_PRINCIPAL_DB_SELECT_1();

            /*" -1376- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1378- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -1380- MOVE 'SELECT PARAMRAMO' TO COMANDO. */
            _.Move("SELECT PARAMRAMO", WABEND.COMANDO);

            /*" -1385- PERFORM M_0000_PRINCIPAL_DB_SELECT_2 */

            M_0000_PRINCIPAL_DB_SELECT_2();

            /*" -1388- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1393- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -1394- MOVE SISTEMA-CURRDATE TO W04DTSQL. */
            _.Move(SISTEMA_CURRDATE, WS_WORK_AREAS.W04DTSQL);

            /*" -1395- MOVE W04DDSQL TO SU1-DD1. */
            _.Move(WS_WORK_AREAS.W04DTSQL.W04DDSQL, WS_WORK_AREAS.PARM_PROSOMU1.SU1_DATA1.SU1_DD1);

            /*" -1396- MOVE W04MMSQL TO SU1-MM1. */
            _.Move(WS_WORK_AREAS.W04DTSQL.W04MMSQL, WS_WORK_AREAS.PARM_PROSOMU1.SU1_DATA1.SU1_MM1);

            /*" -1397- MOVE W04AASQL TO SU1-AA1. */
            _.Move(WS_WORK_AREAS.W04DTSQL.W04SASQL_R.W04AASQL, WS_WORK_AREAS.PARM_PROSOMU1.SU1_DATA1.SU1_AA1);

            /*" -1398- MOVE ZEROES TO SU1-DATA2. */
            _.Move(0, WS_WORK_AREAS.PARM_PROSOMU1.SU1_DATA2);

            /*" -1399- PERFORM 0010-SOMA-DIAS THRU 0010-FIM 6 TIMES. */

            M_0010_SOMA_DIAS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0010_FIM*/


            /*" -1400- MOVE SU1-DD2 TO W04DDSQL. */
            _.Move(WS_WORK_AREAS.PARM_PROSOMU1.SU1_DATA2.SU1_DD2, WS_WORK_AREAS.W04DTSQL.W04DDSQL);

            /*" -1401- MOVE SU1-MM2 TO W04MMSQL. */
            _.Move(WS_WORK_AREAS.PARM_PROSOMU1.SU1_DATA2.SU1_MM2, WS_WORK_AREAS.W04DTSQL.W04MMSQL);

            /*" -1404- MOVE SU1-AA2 TO W04AASQL. */
            _.Move(WS_WORK_AREAS.PARM_PROSOMU1.SU1_DATA2.SU1_AA2, WS_WORK_AREAS.W04DTSQL.W04SASQL_R.W04AASQL);

            /*" -1406- MOVE 'SELECT MAX V0SUBGRUPO' TO COMANDO. */
            _.Move("SELECT MAX V0SUBGRUPO", WABEND.COMANDO);

            /*" -1411- PERFORM M_0000_PRINCIPAL_DB_SELECT_3 */

            M_0000_PRINCIPAL_DB_SELECT_3();

            /*" -1414- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1416- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -1418- MOVE 'SELECT V0BANCO' TO COMANDO. */
            _.Move("SELECT V0BANCO", WABEND.COMANDO);

            /*" -1423- PERFORM M_0000_PRINCIPAL_DB_SELECT_4 */

            M_0000_PRINCIPAL_DB_SELECT_4();

            /*" -1426- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1428- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -1430- MOVE BANCOS-NRTIT TO W-NUMR-TITULO. */
            _.Move(BANCOS_NRTIT, WS_WORK_AREAS.W_NUMR_TITULO);

            /*" -1432- MOVE 'DECLARE CPROPVA' TO COMANDO. */
            _.Move("DECLARE CPROPVA", WABEND.COMANDO);

            /*" -1501- PERFORM M_0000_PRINCIPAL_DB_DECLARE_1 */

            M_0000_PRINCIPAL_DB_DECLARE_1();

            /*" -1504- MOVE 'OPEN CPROPVA' TO COMANDO. */
            _.Move("OPEN CPROPVA", WABEND.COMANDO);

            /*" -1504- PERFORM M_0000_PRINCIPAL_DB_OPEN_1 */

            M_0000_PRINCIPAL_DB_OPEN_1();

            /*" -1507- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1509- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -1511- PERFORM 0110-FETCH THRU 0110-FIM. */

            M_0110_FETCH(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/


            /*" -1514- PERFORM 0100-PROCESSA-PROPOSTA THRU 0100-FIM UNTIL WS-EOF = 1. */

            while (!(WS_WORK_AREAS.WS_EOF == 1))
            {

                M_0100_PROCESSA_PROPOSTA(true);

                M_0100_OPCAOPAGVA(true);

                M_0100_NEXT(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0100_FIM*/

            }

            /*" -1516- MOVE 'UPDATE V0BANCO' TO COMANDO. */
            _.Move("UPDATE V0BANCO", WABEND.COMANDO);

            /*" -1521- PERFORM M_0000_PRINCIPAL_DB_UPDATE_1 */

            M_0000_PRINCIPAL_DB_UPDATE_1();

            /*" -1524- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1525- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -1525- PERFORM 0000-TERMINA. */

            M_0000_TERMINA(true);

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-SELECT-1 */
        public void M_0000_PRINCIPAL_DB_SELECT_1()
        {
            /*" -1373- EXEC SQL SELECT DTMOVABE, CURRENT DATE, CURRENT DATE + 8 DAYS, CURRENT DATE + 1 MONTH INTO :SISTEMA-DTMOVABE, :SISTEMA-CURRDATE, :SISTEMA-DTMOVABE2, :SISTEMA-DTMOVABE3 FROM SEGUROS.V0SISTEMA WHERE IDSISTEM = 'VA' WITH UR END-EXEC. */

            var m_0000_PRINCIPAL_DB_SELECT_1_Query1 = new M_0000_PRINCIPAL_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_0000_PRINCIPAL_DB_SELECT_1_Query1.Execute(m_0000_PRINCIPAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMA_DTMOVABE, SISTEMA_DTMOVABE);
                _.Move(executed_1.SISTEMA_CURRDATE, SISTEMA_CURRDATE);
                _.Move(executed_1.SISTEMA_DTMOVABE2, SISTEMA_DTMOVABE2);
                _.Move(executed_1.SISTEMA_DTMOVABE3, SISTEMA_DTMOVABE3);
            }


        }

        [StopWatch]
        /*" M-0000-TERMINA */
        private void M_0000_TERMINA(bool isPerform = false)
        {
            /*" -1531- PERFORM 9000-FINALIZA THRU 9000-FIM. */

            M_9000_FINALIZA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9000_FIM*/


            /*" -1533- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -1533- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-SELECT-2 */
        public void M_0000_PRINCIPAL_DB_SELECT_2()
        {
            /*" -1385- EXEC SQL SELECT NUM_RAMO_PRSTMISTA INTO :PARAMRAM-NUM-RAMO-PRSTMISTA FROM SEGUROS.PARAMETROS_RAMOS WITH UR END-EXEC */

            var m_0000_PRINCIPAL_DB_SELECT_2_Query1 = new M_0000_PRINCIPAL_DB_SELECT_2_Query1()
            {
            };

            var executed_1 = M_0000_PRINCIPAL_DB_SELECT_2_Query1.Execute(m_0000_PRINCIPAL_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARAMRAM_NUM_RAMO_PRSTMISTA, PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_NUM_RAMO_PRSTMISTA);
            }


        }

        [StopWatch]
        /*" M-0010-SOMA-DIAS */
        private void M_0010_SOMA_DIAS(bool isPerform = false)
        {
            /*" -1542- MOVE +1 TO SU1-NRDIAS. */
            _.Move(+1, WS_WORK_AREAS.PARM_PROSOMU1.SU1_NRDIAS);

            /*" -1543- CALL 'PROSOCU1' USING PARM-PROSOMU1. */
            _.Call("PROSOCU1", WS_WORK_AREAS.PARM_PROSOMU1);

            /*" -1543- MOVE SU1-DATA2 TO SU1-DATA1. */
            _.Move(WS_WORK_AREAS.PARM_PROSOMU1.SU1_DATA2, WS_WORK_AREAS.PARM_PROSOMU1.SU1_DATA1);

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-DECLARE-1 */
        public void M_0000_PRINCIPAL_DB_DECLARE_1()
        {
            /*" -1501- EXEC SQL DECLARE CPROPVA CURSOR FOR SELECT NUM_APOLICE, CODSUBES, NRCERTIF, CODPRODU, CODCLIEN, OCOREND, FONTE, AGECOBR, OPCAO_COBER, DTQITBCO, DTQITBCO + 6 MONTHS, DTQITBCO + 1 MONTH, DTPROXVEN, DTQITBCO + 30 DAYS, NRMATRVEN, CODOPER, DTMOVTO, SITUACAO, NUM_APOLICE, CODSUBES, OCORHIST, NRPARCE, SIT_INTERFACE, TIMESTAMP, IDADE, IDE_SEXO, ESTADO_CIVIL, COD_CRM, NUM_MATRICULA, DATA_ADMISSAO, NRPROPOS, COD_CCT, CODUSU, DTVENCTO, FAIXA_RENDA_IND, DATE(TIMESTAMP), VALUE(DPS_TITULAR, '       ' ), COD_ORIGEM_PROPOSTA, ACATAMENTO, VALUE(COD_OPER_CREDITO, 0) FROM SEGUROS.V0PROPOSTAVA A WHERE A.SITUACAO IN ( '0' , '7' ) AND A.NUM_APOLICE BETWEEN 107700000000 AND 107799999999 AND A.NRCERTIF NOT IN ( 84537054344, 84599746247, 84546927298, 10203110003278, 10011110000404, 11688110000619, 10628460000090, 10840460000394, 84613048394) FOR UPDATE OF CODPRODU, CODOPER, DTMOVTO, DTPROXVEN, SITUACAO, CODSUBES, NRPARCE, SIT_INTERFACE, TIMESTAMP, DTVENCTO END-EXEC. */
            CPROPVA = new VP0121B_CPROPVA(false);
            string GetQuery_CPROPVA()
            {
                var query = @$"SELECT NUM_APOLICE
							, 
							CODSUBES
							, 
							NRCERTIF
							, 
							CODPRODU
							, 
							CODCLIEN
							, 
							OCOREND
							, 
							FONTE
							, 
							AGECOBR
							, 
							OPCAO_COBER
							, 
							DTQITBCO
							, 
							DTQITBCO + 6 MONTHS
							, 
							DTQITBCO + 1 MONTH
							, 
							DTPROXVEN
							, 
							DTQITBCO + 30 DAYS
							, 
							NRMATRVEN
							, 
							CODOPER
							, 
							DTMOVTO
							, 
							SITUACAO
							, 
							NUM_APOLICE
							, 
							CODSUBES
							, 
							OCORHIST
							, 
							NRPARCE
							, 
							SIT_INTERFACE
							, 
							TIMESTAMP
							, 
							IDADE
							, 
							IDE_SEXO
							, 
							ESTADO_CIVIL
							, 
							COD_CRM
							, 
							NUM_MATRICULA
							, 
							DATA_ADMISSAO
							, 
							NRPROPOS
							, 
							COD_CCT
							, 
							CODUSU
							, 
							DTVENCTO
							, 
							FAIXA_RENDA_IND
							, 
							DATE(TIMESTAMP)
							, 
							VALUE(DPS_TITULAR
							, ' ' )
							, 
							COD_ORIGEM_PROPOSTA
							, 
							ACATAMENTO
							, 
							VALUE(COD_OPER_CREDITO
							, 0) 
							FROM SEGUROS.V0PROPOSTAVA A 
							WHERE A.SITUACAO IN ( '0'
							, '7' ) 
							AND A.NUM_APOLICE BETWEEN 107700000000 
							AND 107799999999 
							AND A.NRCERTIF NOT IN 
							( 84537054344
							, 
							84599746247
							, 
							84546927298
							, 
							10203110003278
							, 
							10011110000404
							, 
							11688110000619
							, 
							10628460000090
							, 
							10840460000394
							, 
							84613048394)";

                return query;
            }
            CPROPVA.GetQueryEvent += GetQuery_CPROPVA;

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-OPEN-1 */
        public void M_0000_PRINCIPAL_DB_OPEN_1()
        {
            /*" -1504- EXEC SQL OPEN CPROPVA END-EXEC. */

            CPROPVA.Open();

        }

        [StopWatch]
        /*" M-1120-DECLARE-V0RCAPCOMP-DB-DECLARE-1 */
        public void M_1120_DECLARE_V0RCAPCOMP_DB_DECLARE_1()
        {
            /*" -3328- EXEC SQL DECLARE V1RCAPCOMP CURSOR FOR SELECT FONTE , NRRCAP , NRRCAPCO , OPERACAO , DTMOVTO , HORAOPER , SITUACAO , BCOAVISO , AGEAVISO , NRAVISO , VLRCAP , DATARCAP , DTCADAST , SITCONTB FROM SEGUROS.V1RCAPCOMP WHERE FONTE = :V0RCAP-FONTE AND NRRCAP = :V0RCAP-NRRCAP AND OPERACAO >= 100 AND OPERACAO <= 199 AND SITUACAO = '0' END-EXEC. */
            V1RCAPCOMP = new VP0121B_V1RCAPCOMP(true);
            string GetQuery_V1RCAPCOMP()
            {
                var query = @$"SELECT FONTE
							, 
							NRRCAP
							, 
							NRRCAPCO
							, 
							OPERACAO
							, 
							DTMOVTO
							, 
							HORAOPER
							, 
							SITUACAO
							, 
							BCOAVISO
							, 
							AGEAVISO
							, 
							NRAVISO
							, 
							VLRCAP
							, 
							DATARCAP
							, 
							DTCADAST
							, 
							SITCONTB 
							FROM SEGUROS.V1RCAPCOMP 
							WHERE FONTE = '{V0RCAP_FONTE}' 
							AND NRRCAP = '{V0RCAP_NRRCAP}' 
							AND OPERACAO >= 100 
							AND OPERACAO <= 199 
							AND SITUACAO = '0'";

                return query;
            }
            V1RCAPCOMP.GetQueryEvent += GetQuery_V1RCAPCOMP;

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-UPDATE-1 */
        public void M_0000_PRINCIPAL_DB_UPDATE_1()
        {
            /*" -1521- EXEC SQL UPDATE SEGUROS.V0BANCO SET NRTIT = :BANCOS-NRTIT, TIMESTAMP = CURRENT TIMESTAMP WHERE BANCO = 104 END-EXEC. */

            var m_0000_PRINCIPAL_DB_UPDATE_1_Update1 = new M_0000_PRINCIPAL_DB_UPDATE_1_Update1()
            {
                BANCOS_NRTIT = BANCOS_NRTIT.ToString(),
            };

            M_0000_PRINCIPAL_DB_UPDATE_1_Update1.Execute(m_0000_PRINCIPAL_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-SELECT-3 */
        public void M_0000_PRINCIPAL_DB_SELECT_3()
        {
            /*" -1411- EXEC SQL SELECT VALUE(MAX(COD_SUBGRUPO),0) INTO :SUBGRU-CODSUBES FROM SEGUROS.V0SUBGRUPO WHERE NUM_APOLICE = 0109700000024 END-EXEC. */

            var m_0000_PRINCIPAL_DB_SELECT_3_Query1 = new M_0000_PRINCIPAL_DB_SELECT_3_Query1()
            {
            };

            var executed_1 = M_0000_PRINCIPAL_DB_SELECT_3_Query1.Execute(m_0000_PRINCIPAL_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SUBGRU_CODSUBES, SUBGRU_CODSUBES);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0010_FIM*/

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-SELECT-4 */
        public void M_0000_PRINCIPAL_DB_SELECT_4()
        {
            /*" -1423- EXEC SQL SELECT NRTIT INTO :BANCOS-NRTIT FROM SEGUROS.V0BANCO WHERE BANCO = 104 END-EXEC. */

            var m_0000_PRINCIPAL_DB_SELECT_4_Query1 = new M_0000_PRINCIPAL_DB_SELECT_4_Query1()
            {
            };

            var executed_1 = M_0000_PRINCIPAL_DB_SELECT_4_Query1.Execute(m_0000_PRINCIPAL_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.BANCOS_NRTIT, BANCOS_NRTIT);
            }


        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA */
        private void M_0100_PROCESSA_PROPOSTA(bool isPerform = false)
        {
            /*" -1556- MOVE '0100-PROCESSA-PROPOSTA' TO COMANDO. */
            _.Move("0100-PROCESSA-PROPOSTA", WABEND.COMANDO);

            /*" -1558- ADD 1 TO AC-LIDOS. */
            WS_WORK_AREAS.AC_LIDOS.Value = WS_WORK_AREAS.AC_LIDOS + 1;

            /*" -1560- MOVE 'N' TO WS-LEITUA-SIVPF. */
            _.Move("N", WS_WORK_AREAS.WS_LEITUA_SIVPF);

            /*" -1562- MOVE '0100-PROCESSA-PROPOSTA' TO PARAGRAFO. */
            _.Move("0100-PROCESSA-PROPOSTA", WABEND.PARAGRAFO);

            /*" -1565- MOVE 'SELECT V0PRODUTOSVG' TO COMANDO. */
            _.Move("SELECT V0PRODUTOSVG", WABEND.COMANDO);

            /*" -1603- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_1 */

            M_0100_PROCESSA_PROPOSTA_DB_SELECT_1();

            /*" -1606- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1607- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1610- DISPLAY 'NAO ENCONTRADO NA PRODUTOS_VG ' '  NUM_APOLICE = ' PROPVA-NUM-APOLICE '  CODSUBES    = ' PROPVA-CODSUBES */

                    $"NAO ENCONTRADO NA PRODUTOS_VG   NUM_APOLICE = {PROPVA_NUM_APOLICE}  CODSUBES    = {PROPVA_CODSUBES}"
                    .Display();

                    /*" -1611- ADD 1 TO AC-DESPR-PRODUVG */
                    WS_WORK_AREAS.AC_DESPR_PRODUVG.Value = WS_WORK_AREAS.AC_DESPR_PRODUVG + 1;

                    /*" -1612- GO TO 0100-NEXT */

                    M_0100_NEXT(); //GOTO
                    return;

                    /*" -1613- ELSE */
                }
                else
                {


                    /*" -1616- DISPLAY 'PROBLEMAS NO ACESSO A PRODUTOS_VG ' '  NUM_APOLICE = ' PROPVA-NUM-APOLICE '  CODSUBES    = ' PROPVA-CODSUBES */

                    $"PROBLEMAS NO ACESSO A PRODUTOS_VG   NUM_APOLICE = {PROPVA_NUM_APOLICE}  CODSUBES    = {PROPVA_CODSUBES}"
                    .Display();

                    /*" -1617- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -1618- END-IF */
                }


                /*" -1620- END-IF. */
            }


            /*" -1621- IF WS-IND-ARQFDCAP LESS ZEROS */

            if (WS_IND_ARQFDCAP < 00)
            {

                /*" -1622- MOVE ZEROS TO PRODVG-ARQ-FDCAP */
                _.Move(0, PRODVG_ARQ_FDCAP);

                /*" -1624- END-IF. */
            }


            /*" -1625- IF WS-IND-RUBRICA LESS ZEROS */

            if (WS_IND_RUBRICA < 00)
            {

                /*" -1626- MOVE ZEROS TO PRODVG-COD-RUBRICA */
                _.Move(0, PRODVG_COD_RUBRICA);

                /*" -1628- END-IF. */
            }


            /*" -1629- MOVE PRODVG-CUSTOCAP-TOTAL TO PRODVG-CUSTOCAP-TOTAL-A */
            _.Move(PRODVG_CUSTOCAP_TOTAL, WS_WORK_AREAS.PRODVG_CUSTOCAP_TOTAL_A);

            /*" -1636- MOVE PRODVG-CUSTOCAP-TOTAL-N TO PRODVG-CUSTOCAP-TOTAL-9 */
            _.Move(WS_WORK_AREAS.PRODVG_CUSTOCAP_TOTAL_N, PRODVG_CUSTOCAP_TOTAL_9);

            /*" -1638- MOVE PRODVG-COD-PRODUTO TO PROPVA-CODPRODU. */
            _.Move(PRODVG_COD_PRODUTO, PROPVA_CODPRODU);

            /*" -1641- IF PROPVA-NUM-APOLICE EQUAL 107700000011 AND (PROPVA-CODPRODU EQUAL 7705 OR JVPRD7705) AND PROPVA-ACATAMENTO NOT EQUAL 'S' */

            if (PROPVA_NUM_APOLICE == 107700000011 && (PROPVA_CODPRODU.In("7705", JVBKINCL.JV_PRODUTOS.JVPRD7705.ToString())) && PROPVA_ACATAMENTO != "S")
            {

                /*" -1643- MOVE 'SELECT ERROS-PROP' TO COMANDO */
                _.Move("SELECT ERROS-PROP", WABEND.COMANDO);

                /*" -1645- MOVE SPACES TO WTEM-ERRO-7705 */
                _.Move("", WS_WORK_AREAS.WTEM_ERRO_7705);

                /*" -1653- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_2 */

                M_0100_PROCESSA_PROPOSTA_DB_SELECT_2();

                /*" -1656- IF SQLCODE NOT EQUAL ZEROS AND 100 */

                if (!DB.SQLCODE.In("00", "100"))
                {

                    /*" -1657- DISPLAY 'VP0121B - ERRO NO ACESSO ERROS_PROP' */
                    _.Display($"VP0121B - ERRO NO ACESSO ERROS_PROP");

                    /*" -1659- DISPLAY '          CERTIFICADO........... ' PROPVA-NRCERTIF */
                    _.Display($"          CERTIFICADO........... {PROPVA_NRCERTIF}");

                    /*" -1661- DISPLAY '          CODIGO DO CLIENTE..... ' PROPVA-CODCLIEN */
                    _.Display($"          CODIGO DO CLIENTE..... {PROPVA_CODCLIEN}");

                    /*" -1663- DISPLAY '          SQLCODE............... ' SQLCODE */
                    _.Display($"          SQLCODE............... {DB.SQLCODE}");

                    /*" -1664- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -1666- END-IF */
                }


                /*" -1667- IF WTEM-ERRO-7705 NOT EQUAL SPACES */

                if (!WS_WORK_AREAS.WTEM_ERRO_7705.IsEmpty())
                {

                    /*" -1668- ADD 1 TO AC-DESPR-7705 */
                    WS_WORK_AREAS.AC_DESPR_7705.Value = WS_WORK_AREAS.AC_DESPR_7705 + 1;

                    /*" -1669- MOVE '1' TO PROPVA-SITUACAO */
                    _.Move("1", PROPVA_SITUACAO);

                    /*" -1671- GO TO 0100-NEXT. */

                    M_0100_NEXT(); //GOTO
                    return;
                }

            }


            /*" -1673- MOVE ZEROS TO W-NOVO-CALCULO. */
            _.Move(0, WS_WORK_AREAS.W_NOVO_CALCULO);

            /*" -1676- IF PROPVA-NUM-APOLICE EQUAL 107700000011 AND (PROPVA-CODPRODU EQUAL 7705 OR JVPRD7705) AND PROPVA-OPCAO-COBER EQUAL SPACES */

            if (PROPVA_NUM_APOLICE == 107700000011 && (PROPVA_CODPRODU.In("7705", JVBKINCL.JV_PRODUTOS.JVPRD7705.ToString())) && PROPVA_OPCAO_COBER.IsEmpty())
            {

                /*" -1678- MOVE 1 TO W-NOVO-CALCULO. */
                _.Move(1, WS_WORK_AREAS.W_NOVO_CALCULO);
            }


            /*" -1681- IF PROPVA-NUM-APOLICE EQUAL 107700000027 AND PROPVA-CODPRODU EQUAL 7715 AND PROPVA-ACATAMENTO NOT EQUAL 'S' */

            if (PROPVA_NUM_APOLICE == 107700000027 && PROPVA_CODPRODU == 7715 && PROPVA_ACATAMENTO != "S")
            {

                /*" -1683- MOVE 'SELECT ERROS-PROP' TO COMANDO */
                _.Move("SELECT ERROS-PROP", WABEND.COMANDO);

                /*" -1685- MOVE SPACES TO WTEM-ERRO-7715 */
                _.Move("", WS_WORK_AREAS.WTEM_ERRO_7715);

                /*" -1693- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_3 */

                M_0100_PROCESSA_PROPOSTA_DB_SELECT_3();

                /*" -1696- IF SQLCODE NOT EQUAL ZEROS AND 100 */

                if (!DB.SQLCODE.In("00", "100"))
                {

                    /*" -1697- DISPLAY 'VP0121B - ERRO NO ACESSO ERROS_PROP - 7715' */
                    _.Display($"VP0121B - ERRO NO ACESSO ERROS_PROP - 7715");

                    /*" -1699- DISPLAY '          CERTIFICADO........... ' PROPVA-NRCERTIF */
                    _.Display($"          CERTIFICADO........... {PROPVA_NRCERTIF}");

                    /*" -1701- DISPLAY '          CODIGO DO CLIENTE..... ' PROPVA-CODCLIEN */
                    _.Display($"          CODIGO DO CLIENTE..... {PROPVA_CODCLIEN}");

                    /*" -1703- DISPLAY '          SQLCODE............... ' SQLCODE */
                    _.Display($"          SQLCODE............... {DB.SQLCODE}");

                    /*" -1704- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -1706- END-IF */
                }


                /*" -1707- IF WTEM-ERRO-7715 NOT EQUAL SPACES */

                if (!WS_WORK_AREAS.WTEM_ERRO_7715.IsEmpty())
                {

                    /*" -1708- ADD 1 TO AC-DESPR-7715 */
                    WS_WORK_AREAS.AC_DESPR_7715.Value = WS_WORK_AREAS.AC_DESPR_7715 + 1;

                    /*" -1709- MOVE '1' TO PROPVA-SITUACAO */
                    _.Move("1", PROPVA_SITUACAO);

                    /*" -1711- GO TO 0100-NEXT. */

                    M_0100_NEXT(); //GOTO
                    return;
                }

            }


            /*" -1713- MOVE ZEROS TO W-NOVO-CALCULO. */
            _.Move(0, WS_WORK_AREAS.W_NOVO_CALCULO);

            /*" -1716- IF PROPVA-NUM-APOLICE EQUAL 107700000027 AND PROPVA-CODPRODU EQUAL 7715 AND PROPVA-OPCAO-COBER EQUAL SPACES */

            if (PROPVA_NUM_APOLICE == 107700000027 && PROPVA_CODPRODU == 7715 && PROPVA_OPCAO_COBER.IsEmpty())
            {

                /*" -1725- MOVE 1 TO W-NOVO-CALCULO. */
                _.Move(1, WS_WORK_AREAS.W_NOVO_CALCULO);
            }


            /*" -1727- MOVE 'SELECT V0CLIENTE' TO COMANDO */
            _.Move("SELECT V0CLIENTE", WABEND.COMANDO);

            /*" -1730- MOVE ZERO TO WS-ACESSO-CLIENTE */
            _.Move(0, WS_WORK_AREAS.WS_ACESSO_CLIENTE);

            /*" -1736- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_4 */

            M_0100_PROCESSA_PROPOSTA_DB_SELECT_4();

            /*" -1739- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1740- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1741- DISPLAY 'VP0121B - CLIENTE NAO CADASTRADO ' */
                    _.Display($"VP0121B - CLIENTE NAO CADASTRADO ");

                    /*" -1743- DISPLAY '          CERTIFICADO........... ' PROPVA-NRCERTIF */
                    _.Display($"          CERTIFICADO........... {PROPVA_NRCERTIF}");

                    /*" -1745- DISPLAY '          CODIGO DO CLIENTE..... ' PROPVA-CODCLIEN */
                    _.Display($"          CODIGO DO CLIENTE..... {PROPVA_CODCLIEN}");

                    /*" -1746- MOVE 2 TO WS-ACESSO-CLIENTE */
                    _.Move(2, WS_WORK_AREAS.WS_ACESSO_CLIENTE);

                    /*" -1747- ELSE */
                }
                else
                {


                    /*" -1748- DISPLAY 'VP0121B - ERRO NO ACESSO CLIENTE ' */
                    _.Display($"VP0121B - ERRO NO ACESSO CLIENTE ");

                    /*" -1750- DISPLAY '          CERTIFICADO........... ' PROPVA-NRCERTIF */
                    _.Display($"          CERTIFICADO........... {PROPVA_NRCERTIF}");

                    /*" -1752- DISPLAY '          CODIGO DO CLIENTE..... ' PROPVA-CODCLIEN */
                    _.Display($"          CODIGO DO CLIENTE..... {PROPVA_CODCLIEN}");

                    /*" -1754- DISPLAY '          SQLCODE............... ' SQLCODE */
                    _.Display($"          SQLCODE............... {DB.SQLCODE}");

                    /*" -1755- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -1756- ELSE */
                }

            }
            else
            {


                /*" -1757- IF CLIENT-DTNASC-I LESS ZEROES */

                if (CLIENT_DTNASC_I < 00)
                {

                    /*" -1758- DISPLAY 'VP0121B - CLIENTE SEM DATA NASCIMENTO ' */
                    _.Display($"VP0121B - CLIENTE SEM DATA NASCIMENTO ");

                    /*" -1760- DISPLAY '          CERTIFICADO................ ' PROPVA-NRCERTIF */
                    _.Display($"          CERTIFICADO................ {PROPVA_NRCERTIF}");

                    /*" -1762- DISPLAY '          CODIGO DO CLIENTE.......... ' PROPVA-CODCLIEN */
                    _.Display($"          CODIGO DO CLIENTE.......... {PROPVA_CODCLIEN}");

                    /*" -1764- MOVE 2 TO WS-ACESSO-CLIENTE. */
                    _.Move(2, WS_WORK_AREAS.WS_ACESSO_CLIENTE);
                }

            }


            /*" -1765- IF ACESSO-CLIENTE-ER */

            if (WS_WORK_AREAS.WS_ACESSO_CLIENTE["ACESSO_CLIENTE_ER"])
            {

                /*" -1766- ADD 1 TO AC-DESPR-CLIENTE */
                WS_WORK_AREAS.AC_DESPR_CLIENTE.Value = WS_WORK_AREAS.AC_DESPR_CLIENTE + 1;

                /*" -1767- MOVE '1' TO PROPVA-SITUACAO */
                _.Move("1", PROPVA_SITUACAO);

                /*" -1768- GO TO 0100-NEXT */

                M_0100_NEXT(); //GOTO
                return;

                /*" -1770- END-IF */
            }


            /*" -1771- IF PROPVA-FONTE NOT GREATER ZEROS */

            if (PROPVA_FONTE <= 00)
            {

                /*" -1772- DISPLAY ' DESPREZADO FONTE ......... ' PROPVA-NRCERTIF */
                _.Display($" DESPREZADO FONTE ......... {PROPVA_NRCERTIF}");

                /*" -1773- MOVE 0201 TO ERRPROVI-COD-ERRO */
                _.Move(0201, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                /*" -1774- PERFORM 0101-00-INSERT-ERROSPROPVA */

                M_0101_00_INSERT_ERROSPROPVA(true);

                /*" -1776- END-IF */
            }


            /*" -1783- IF PARAMRAM-NUM-RAMO-PRSTMISTA EQUAL V1APOL-RAMO OR (PROPVA-NUM-APOLICE = 109300001294 OR 109300001391 OR 109300001392 OR 109300001311 OR 109300000909 OR 3009300000909 OR 109300000598) */

            if (PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_NUM_RAMO_PRSTMISTA == V1APOL_RAMO || (PROPVA_NUM_APOLICE.In("109300001294", "109300001391", "109300001392", "109300001311", "109300000909", "3009300000909", "109300000598")))
            {

                /*" -1784- CONTINUE */

                /*" -1785- ELSE */
            }
            else
            {


                /*" -1786- IF PROPVA-DPS-TITULAR EQUAL SPACES */

                if (PROPVA_DPS_TITULAR.IsEmpty())
                {

                    /*" -1787- DISPLAY ' DESPREZADO DPS TITULAR ..  ' PROPVA-NRCERTIF */
                    _.Display($" DESPREZADO DPS TITULAR ..  {PROPVA_NRCERTIF}");

                    /*" -1788- MOVE 1803 TO ERRPROVI-COD-ERRO */
                    _.Move(1803, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                    /*" -1789- PERFORM 0101-00-INSERT-ERROSPROPVA */

                    M_0101_00_INSERT_ERROSPROPVA(true);

                    /*" -1790- END-IF */
                }


                /*" -1792- END-IF. */
            }


            /*" -1794- IF PROPVA-INRPROPOS LESS ZEROS OR PROPVA-NRPROPOS EQUAL ZEROS */

            if (PROPVA_INRPROPOS < 00 || PROPVA_NRPROPOS == 00)
            {

                /*" -1795- CONTINUE */

                /*" -1796- ELSE */
            }
            else
            {


                /*" -1798- MOVE 'SELECT V0MOVIMENTO' TO COMANDO */
                _.Move("SELECT V0MOVIMENTO", WABEND.COMANDO);

                /*" -1804- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_5 */

                M_0100_PROCESSA_PROPOSTA_DB_SELECT_5();

                /*" -1807- IF SQLCODE NOT = 000 AND +100 */

                if (!DB.SQLCODE.In("000", "+100"))
                {

                    /*" -1812- DISPLAY 'VP0121B-0100 PROBLEMAS SELECT V0MOVIMENTO' ' COD_FONTE=' PROPVA-FONTE ' NUM_PROPOSTA=' PROPVA-NRPROPOS ' CERTIFICADO=' PROPVA-NRCERTIF ' PROPOSTA=' PROPVA-NRPROPOS */

                    $"VP0121B-0100 PROBLEMAS SELECT V0MOVIMENTO COD_FONTE={PROPVA_FONTE} NUM_PROPOSTA={PROPVA_NRPROPOS} CERTIFICADO={PROPVA_NRCERTIF} PROPOSTA={PROPVA_NRPROPOS}"
                    .Display();

                    /*" -1813- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -1815- END-IF */
                }


                /*" -1816- IF SQLCODE = 000 */

                if (DB.SQLCODE == 000)
                {

                    /*" -1817- DISPLAY 'VP0121B - PROPOSTA JA CADASTRADA' */
                    _.Display($"VP0121B - PROPOSTA JA CADASTRADA");

                    /*" -1819- DISPLAY '          CERTIFICADO.......... ' PROPVA-NRCERTIF */
                    _.Display($"          CERTIFICADO.......... {PROPVA_NRCERTIF}");

                    /*" -1821- DISPLAY '          PROPOSTA............. ' PROPVA-NRPROPOS */
                    _.Display($"          PROPOSTA............. {PROPVA_NRPROPOS}");

                    /*" -1822- MOVE -1 TO PROPVA-INRPROPOS */
                    _.Move(-1, PROPVA_INRPROPOS);

                    /*" -1823- MOVE 0 TO PROPVA-NRPROPOS */
                    _.Move(0, PROPVA_NRPROPOS);

                    /*" -1824- END-IF */
                }


                /*" -1826- END-IF */
            }


            /*" -1827- IF VIND-ESTR-COBR LESS 0 */

            if (VIND_ESTR_COBR < 0)
            {

                /*" -1829- MOVE SPACES TO PRODVG-ESTR-COBR. */
                _.Move("", PRODVG_ESTR_COBR);
            }


            /*" -1830- IF VIND-ORIG-PRODU LESS 0 */

            if (VIND_ORIG_PRODU < 0)
            {

                /*" -1832- MOVE SPACES TO PRODVG-ORIG-PRODU. */
                _.Move("", PRODVG_ORIG_PRODU);
            }


            /*" -1833- IF VIND-AGENCIADOR LESS 0 */

            if (VIND_AGENCIADOR < 0)
            {

                /*" -1835- MOVE +0 TO PRODVG-AGENCIADOR. */
                _.Move(+0, PRODVG_AGENCIADOR);
            }


            /*" -1836- IF VIND-TEM-SAF LESS 0 */

            if (VIND_TEM_SAF < 0)
            {

                /*" -1838- MOVE 'N' TO PRODVG-TEM-SAF. */
                _.Move("N", PRODVG_TEM_SAF);
            }


            /*" -1839- IF VIND-TEM-CDG LESS 0 */

            if (VIND_TEM_CDG < 0)
            {

                /*" -1841- MOVE 'N' TO PRODVG-TEM-CDG. */
                _.Move("N", PRODVG_TEM_CDG);
            }


            /*" -1842- IF VIND-CODRELAT LESS 0 */

            if (VIND_CODRELAT < 0)
            {

                /*" -1844- MOVE '********' TO PRODVG-CODRELAT. */
                _.Move("********", PRODVG_CODRELAT);
            }


            /*" -1846- IF PRODVG-ORIG-PRODU = 'MULT' OR 'CAMP' AND PROPVA-IDADE = 0 */

            if (PRODVG_ORIG_PRODU.In("MULT", "CAMP") && PROPVA_IDADE == 0)
            {

                /*" -1847- DISPLAY ' DESPREZADO IDADE ......... ' PROPVA-NRCERTIF */
                _.Display($" DESPREZADO IDADE ......... {PROPVA_NRCERTIF}");

                /*" -1848- MOVE 1002 TO ERRPROVI-COD-ERRO */
                _.Move(1002, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                /*" -1850- PERFORM 0101-00-INSERT-ERROSPROPVA. */

                M_0101_00_INSERT_ERROSPROPVA(true);
            }


            /*" -1852- IF PRODVG-ORIG-PRODU = 'MULT' OR 'VIDAZUL' AND PROPVA-NUM-APOLICE NOT EQUAL 109300000635 */

            if (PRODVG_ORIG_PRODU.In("MULT", "VIDAZUL") && PROPVA_NUM_APOLICE != 109300000635)
            {

                /*" -1853- IF PROPVA-SITUACAO = '7' */

                if (PROPVA_SITUACAO == "7")
                {

                    /*" -1854- GO TO 0100-OPCAOPAGVA */

                    M_0100_OPCAOPAGVA(); //GOTO
                    return;

                    /*" -1855- END-IF */
                }


                /*" -1856- MOVE 'SELECT V0PARCELVA  ' TO COMANDO */
                _.Move("SELECT V0PARCELVA  ", WABEND.COMANDO);

                /*" -1862- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_6 */

                M_0100_PROCESSA_PROPOSTA_DB_SELECT_6();

                /*" -1864- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -1865- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -1866- DISPLAY ' DESPREZADO PARCELVA ...... ' PROPVA-NRCERTIF */
                        _.Display($" DESPREZADO PARCELVA ...... {PROPVA_NRCERTIF}");

                        /*" -1867- MOVE '1' TO PROPVA-SITUACAO */
                        _.Move("1", PROPVA_SITUACAO);

                        /*" -1868- ADD 1 TO AC-DESPR-PARCELVA */
                        WS_WORK_AREAS.AC_DESPR_PARCELVA.Value = WS_WORK_AREAS.AC_DESPR_PARCELVA + 1;

                        /*" -1869- GO TO 0100-NEXT */

                        M_0100_NEXT(); //GOTO
                        return;

                        /*" -1870- ELSE */
                    }
                    else
                    {


                        /*" -1870- GO TO 9999-ERRO. */

                        M_9999_ERRO(); //GOTO
                        return;
                    }

                }

            }


        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-1 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_1()
        {
            /*" -1603- EXEC SQL SELECT CODPRODAZ, PERIPGTO, ESTR_COBR, ORIG_PRODU, COD_AGENCIADOR, TEM_SAF, TEM_CDG, CODRELAT, COBERADIC_PREMIO, CUSTOCAP_TOTAL, DESCONTO_ADESAO, CODPRODU, VALUE(RISCO, '1' ), SITPLANCEF, ARQ_FDCAP, COD_RUBRICA INTO :PRODVG-CODPRODAZ, :PRODVG-PERIPGTO, :PRODVG-ESTR-COBR :VIND-ESTR-COBR , :PRODVG-ORIG-PRODU:VIND-ORIG-PRODU, :PRODVG-AGENCIADOR:VIND-AGENCIADOR, :PRODVG-TEM-SAF:VIND-TEM-SAF, :PRODVG-TEM-CDG:VIND-TEM-CDG, :PRODVG-CODRELAT:VIND-CODRELAT, :PRODVG-COBERADIC-PREMIO, :PRODVG-CUSTOCAP-TOTAL, :PRODVG-DESCONTO-ADESAO, :PRODVG-COD-PRODUTO, :PRODVG-RISCO, :PRODVG-SITPLANCEF, :PRODVG-ARQ-FDCAP:WS-IND-ARQFDCAP, :PRODVG-COD-RUBRICA:WS-IND-RUBRICA FROM SEGUROS.V0PRODUTOSVG WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE AND CODSUBES = :PROPVA-CODSUBES AND ESTR_EMISS = 'MULT' WITH UR END-EXEC. */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODVG_CODPRODAZ, PRODVG_CODPRODAZ);
                _.Move(executed_1.PRODVG_PERIPGTO, PRODVG_PERIPGTO);
                _.Move(executed_1.PRODVG_ESTR_COBR, PRODVG_ESTR_COBR);
                _.Move(executed_1.VIND_ESTR_COBR, VIND_ESTR_COBR);
                _.Move(executed_1.PRODVG_ORIG_PRODU, PRODVG_ORIG_PRODU);
                _.Move(executed_1.VIND_ORIG_PRODU, VIND_ORIG_PRODU);
                _.Move(executed_1.PRODVG_AGENCIADOR, PRODVG_AGENCIADOR);
                _.Move(executed_1.VIND_AGENCIADOR, VIND_AGENCIADOR);
                _.Move(executed_1.PRODVG_TEM_SAF, PRODVG_TEM_SAF);
                _.Move(executed_1.VIND_TEM_SAF, VIND_TEM_SAF);
                _.Move(executed_1.PRODVG_TEM_CDG, PRODVG_TEM_CDG);
                _.Move(executed_1.VIND_TEM_CDG, VIND_TEM_CDG);
                _.Move(executed_1.PRODVG_CODRELAT, PRODVG_CODRELAT);
                _.Move(executed_1.VIND_CODRELAT, VIND_CODRELAT);
                _.Move(executed_1.PRODVG_COBERADIC_PREMIO, PRODVG_COBERADIC_PREMIO);
                _.Move(executed_1.PRODVG_CUSTOCAP_TOTAL, PRODVG_CUSTOCAP_TOTAL);
                _.Move(executed_1.PRODVG_DESCONTO_ADESAO, PRODVG_DESCONTO_ADESAO);
                _.Move(executed_1.PRODVG_COD_PRODUTO, PRODVG_COD_PRODUTO);
                _.Move(executed_1.PRODVG_RISCO, PRODVG_RISCO);
                _.Move(executed_1.PRODVG_SITPLANCEF, PRODVG_SITPLANCEF);
                _.Move(executed_1.PRODVG_ARQ_FDCAP, PRODVG_ARQ_FDCAP);
                _.Move(executed_1.WS_IND_ARQFDCAP, WS_IND_ARQFDCAP);
                _.Move(executed_1.PRODVG_COD_RUBRICA, PRODVG_COD_RUBRICA);
                _.Move(executed_1.WS_IND_RUBRICA, WS_IND_RUBRICA);
            }


        }

        [StopWatch]
        /*" M-0100-OPCAOPAGVA */
        private void M_0100_OPCAOPAGVA(bool isPerform = false)
        {
            /*" -1876- MOVE 'SELECT V0OPCAOPAGVA' TO COMANDO. */
            _.Move("SELECT V0OPCAOPAGVA", WABEND.COMANDO);

            /*" -1896- PERFORM M_0100_OPCAOPAGVA_DB_SELECT_1 */

            M_0100_OPCAOPAGVA_DB_SELECT_1();

            /*" -1899- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1900- DISPLAY 'ERRO SELECT V0OPCAOPAGVA  SQLCODE  = ' SQLCODE */
                _.Display($"ERRO SELECT V0OPCAOPAGVA  SQLCODE  = {DB.SQLCODE}");

                /*" -1901- DISPLAY 'NRCERTIF = ' PROPVA-NRCERTIF */
                _.Display($"NRCERTIF = {PROPVA_NRCERTIF}");

                /*" -1903- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -1904- IF INDAGE LESS ZEROS */

            if (INDAGE < 00)
            {

                /*" -1906- MOVE ZEROS TO OPCAOP-AGECTADEB. */
                _.Move(0, OPCAOP_AGECTADEB);
            }


            /*" -1907- IF INDOPR LESS ZEROS */

            if (INDOPR < 00)
            {

                /*" -1909- MOVE ZEROS TO OPCAOP-OPRCTADEB. */
                _.Move(0, OPCAOP_OPRCTADEB);
            }


            /*" -1910- IF INDNUM LESS ZEROS */

            if (INDNUM < 00)
            {

                /*" -1912- MOVE ZEROS TO OPCAOP-NUMCTADEB. */
                _.Move(0, OPCAOP_NUMCTADEB);
            }


            /*" -1913- IF INDDIG LESS ZEROS */

            if (INDDIG < 00)
            {

                /*" -1915- MOVE ZEROS TO OPCAOP-DIGCTADEB. */
                _.Move(0, OPCAOP_DIGCTADEB);
            }


            /*" -1916- IF INDCARTAO LESS ZEROS */

            if (INDCARTAO < 00)
            {

                /*" -1918- MOVE ZEROS TO OPCAOP-CARTAOCRED. */
                _.Move(0, OPCAOP_CARTAOCRED);
            }


            /*" -1920- MOVE 'NAO' TO WS-ATUALIZA-OPCPAGVA */
            _.Move("NAO", WS_ATUALIZA_OPCPAGVA);

            /*" -1921- IF OPCAOP-PERIPGTO = 0 */

            if (OPCAOP_PERIPGTO == 0)
            {

                /*" -1923- IF PRODVG-PERIPGTO = 0 NEXT SENTENCE */

                if (PRODVG_PERIPGTO == 0)
                {

                    /*" -1924- ELSE */
                }
                else
                {


                    /*" -1925- MOVE PRODVG-PERIPGTO TO OPCAOP-PERIPGTO */
                    _.Move(PRODVG_PERIPGTO, OPCAOP_PERIPGTO);

                    /*" -1926- MOVE 'SIM' TO WS-ATUALIZA-OPCPAGVA */
                    _.Move("SIM", WS_ATUALIZA_OPCPAGVA);

                    /*" -1927- END-IF */
                }


                /*" -1929- END-IF. */
            }


            /*" -1932- IF OPCAOP-OPCAOPAG = '1' OR '2' OR '3' OR '4' OR '5' NEXT SENTENCE */

            if (OPCAOP_OPCAOPAG.In("1", "2", "3", "4", "5"))
            {

                /*" -1933- ELSE */
            }
            else
            {


                /*" -1934- IF OPCAOP-AGECTADEB EQUAL ZEROS */

                if (OPCAOP_AGECTADEB == 00)
                {

                    /*" -1935- IF OPCAOP-CARTAOCRED EQUAL ZEROS */

                    if (OPCAOP_CARTAOCRED == 00)
                    {

                        /*" -1936- MOVE 'SIM' TO WS-ATUALIZA-OPCPAGVA */
                        _.Move("SIM", WS_ATUALIZA_OPCPAGVA);

                        /*" -1937- MOVE '3' TO OPCAOP-OPCAOPAG */
                        _.Move("3", OPCAOP_OPCAOPAG);

                        /*" -1938- ELSE */
                    }
                    else
                    {


                        /*" -1939- MOVE 'SIM' TO WS-ATUALIZA-OPCPAGVA */
                        _.Move("SIM", WS_ATUALIZA_OPCPAGVA);

                        /*" -1940- MOVE '5' TO OPCAOP-OPCAOPAG */
                        _.Move("5", OPCAOP_OPCAOPAG);

                        /*" -1941- END-IF */
                    }


                    /*" -1942- ELSE */
                }
                else
                {


                    /*" -1943- MOVE 'SIM' TO WS-ATUALIZA-OPCPAGVA */
                    _.Move("SIM", WS_ATUALIZA_OPCPAGVA);

                    /*" -1944- MOVE '1' TO OPCAOP-OPCAOPAG */
                    _.Move("1", OPCAOP_OPCAOPAG);

                    /*" -1945- END-IF */
                }


                /*" -1947- END-IF. */
            }


            /*" -1950- IF OPCAOP-DIA-DEB GREATER 0 AND OPCAOP-DIA-DEB LESS 29 NEXT SENTENCE */

            if (OPCAOP_DIA_DEB > 0 && OPCAOP_DIA_DEB < 29)
            {

                /*" -1951- ELSE */
            }
            else
            {


                /*" -1952- MOVE 'SIM' TO WS-ATUALIZA-OPCPAGVA */
                _.Move("SIM", WS_ATUALIZA_OPCPAGVA);

                /*" -1953- MOVE 10 TO OPCAOP-DIA-DEB */
                _.Move(10, OPCAOP_DIA_DEB);

                /*" -1955- END-IF. */
            }


            /*" -1956- IF WS-ATUALIZA-OPCPAGVA EQUAL 'SIM' */

            if (WS_ATUALIZA_OPCPAGVA == "SIM")
            {

                /*" -1957- MOVE 'UPDATE V0OPCAOPAGVA N' TO COMANDO */
                _.Move("UPDATE V0OPCAOPAGVA N", WABEND.COMANDO);

                /*" -1963- PERFORM M_0100_OPCAOPAGVA_DB_UPDATE_1 */

                M_0100_OPCAOPAGVA_DB_UPDATE_1();

                /*" -1965- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1967- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -1969- IF OPCAOP-OPCAOPAG NOT EQUAL '1' AND '2' AND '3' AND '4' AND '5' */

            if (!OPCAOP_OPCAOPAG.In("1", "2", "3", "4", "5"))
            {

                /*" -1970- MOVE 1601 TO ERRPROVI-COD-ERRO */
                _.Move(1601, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                /*" -1972- PERFORM 0101-00-INSERT-ERROSPROPVA. */

                M_0101_00_INSERT_ERROSPROPVA(true);
            }


            /*" -1974- IF OPCAOP-PERIPGTO NOT EQUAL 0 AND 1 AND 2 AND 3 AND 6 AND 12 */

            if (!OPCAOP_PERIPGTO.In("0", "1", "2", "3", "6", "12"))
            {

                /*" -1975- MOVE 0802 TO ERRPROVI-COD-ERRO */
                _.Move(0802, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                /*" -1977- PERFORM 0101-00-INSERT-ERROSPROPVA. */

                M_0101_00_INSERT_ERROSPROPVA(true);
            }


            /*" -1980- IF OPCAOP-DIA-DEB GREATER 0 AND OPCAOP-DIA-DEB LESS 29 NEXT SENTENCE */

            if (OPCAOP_DIA_DEB > 0 && OPCAOP_DIA_DEB < 29)
            {

                /*" -1981- ELSE */
            }
            else
            {


                /*" -1982- MOVE 0802 TO ERRPROVI-COD-ERRO */
                _.Move(0802, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                /*" -1984- PERFORM 0101-00-INSERT-ERROSPROPVA. */

                M_0101_00_INSERT_ERROSPROPVA(true);
            }


            /*" -1986- IF PROPVA-CODPRODU NOT = 7732 AND JVPRD7732 AND 7733 AND JVPRD7733 */

            if (!PROPVA_CODPRODU.In("7732", JVBKINCL.JV_PRODUTOS.JVPRD7732.ToString(), "7733", JVBKINCL.JV_PRODUTOS.JVPRD7733.ToString()))
            {

                /*" -1990- IF (OPCAOP-OPCAOPAG EQUAL '1' OR '2' ) AND (OPCAOP-AGECTADEB EQUAL ZEROES OR OPCAOP-OPRCTADEB EQUAL ZEROES OR OPCAOP-NUMCTADEB EQUAL ZEROES) */

                if ((OPCAOP_OPCAOPAG.In("1", "2")) && (OPCAOP_AGECTADEB == 00 || OPCAOP_OPRCTADEB == 00 || OPCAOP_NUMCTADEB == 00))
                {

                    /*" -1991- DISPLAY ' DESPREZADO CONTA CORR ...  ' PROPVA-NRCERTIF */
                    _.Display($" DESPREZADO CONTA CORR ...  {PROPVA_NRCERTIF}");

                    /*" -1992- MOVE 0901 TO ERRPROVI-COD-ERRO */
                    _.Move(0901, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                    /*" -1993- PERFORM 0101-00-INSERT-ERROSPROPVA */

                    M_0101_00_INSERT_ERROSPROPVA(true);

                    /*" -1994- END-IF */
                }


                /*" -1996- END-IF. */
            }


            /*" -1998- IF (OPCAOP-OPCAOPAG EQUAL '5' ) AND (OPCAOP-CARTAOCRED EQUAL ZEROES) */

            if ((OPCAOP_OPCAOPAG == "5") && (OPCAOP_CARTAOCRED == 00))
            {

                /*" -1999- DISPLAY ' DESPREZADO CARTAO .......  ' PROPVA-NRCERTIF */
                _.Display($" DESPREZADO CARTAO .......  {PROPVA_NRCERTIF}");

                /*" -2000- MOVE 1853 TO ERRPROVI-COD-ERRO */
                _.Move(1853, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                /*" -2005- PERFORM 0101-00-INSERT-ERROSPROPVA. */

                M_0101_00_INSERT_ERROSPROPVA(true);
            }


            /*" -2007- IF PRODVG-ORIG-PRODU = 'MULT' OR PRODVG-ORIG-PRODU = 'CAMP' */

            if (PRODVG_ORIG_PRODU == "MULT" || PRODVG_ORIG_PRODU == "CAMP")
            {

                /*" -2008- IF PROPVA-AGECOBR = ZEROES */

                if (PROPVA_AGECOBR == 00)
                {

                    /*" -2009- MOVE OPCAOP-AGECTADEB TO PROPVA-AGECOBR */
                    _.Move(OPCAOP_AGECTADEB, PROPVA_AGECOBR);

                    /*" -2010- END-IF */
                }


                /*" -2016- PERFORM M_0100_OPCAOPAGVA_DB_SELECT_2 */

                M_0100_OPCAOPAGVA_DB_SELECT_2();

                /*" -2019- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2020- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -2022- IF PROPVA-ORIGEM-PROPOSTA NOT EQUAL 1000 */

                        if (PROPVA_ORIGEM_PROPOSTA != 1000)
                        {

                            /*" -2023- MOVE 0102 TO ERRPROVI-COD-ERRO */
                            _.Move(0102, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                            /*" -2024- PERFORM 0101-00-INSERT-ERROSPROPVA */

                            M_0101_00_INSERT_ERROSPROPVA(true);

                            /*" -2025- END-IF */
                        }


                        /*" -2026- ELSE */
                    }
                    else
                    {


                        /*" -2028- GO TO 9999-ERRO. */

                        M_9999_ERRO(); //GOTO
                        return;
                    }

                }

            }


            /*" -2043- MOVE ZEROS TO COBERP-IMPMORNATU COBERP-IMPMORACID COBERP-IMPINVPERM COBERP-IMPAMDS COBERP-IMPDH COBERP-IMPDIT COBERP-VLPREMIO COBERP-PRMVG COBERP-PRMAP COBERP-IMPSEGCDG COBERP-VLCUSTCDG COBERP-VLCUSTCAP COBERP-QTTITCAP. */
            _.Move(0, COBERP_IMPMORNATU, COBERP_IMPMORACID, COBERP_IMPINVPERM, COBERP_IMPAMDS, COBERP_IMPDH, COBERP_IMPDIT, COBERP_VLPREMIO, COBERP_PRMVG, COBERP_PRMAP, COBERP_IMPSEGCDG, COBERP_VLCUSTCDG, COBERP_VLCUSTCAP, COBERP_QTTITCAP);

            /*" -2045- IF PROPVA-NUM-APOLICE EQUAL 109300000635 AND PROPVA-CODSUBES EQUAL 1 */

            if (PROPVA_NUM_APOLICE == 109300000635 && PROPVA_CODSUBES == 1)
            {

                /*" -2051- PERFORM M_0100_OPCAOPAGVA_DB_SELECT_3 */

                M_0100_OPCAOPAGVA_DB_SELECT_3();

                /*" -2054- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2056- DISPLAY 'ERRO LEITURA MINIMO OCORHIST CERTIF = ' PROPVA-NRCERTIF */
                    _.Display($"ERRO LEITURA MINIMO OCORHIST CERTIF = {PROPVA_NRCERTIF}");

                    /*" -2057- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -2058- END-IF */
                }


                /*" -2059- MOVE 'SELECT V0COBERPROPVA X1  ' TO COMANDO */
                _.Move("SELECT V0COBERPROPVA X1  ", WABEND.COMANDO);

                /*" -2098- PERFORM M_0100_OPCAOPAGVA_DB_SELECT_4 */

                M_0100_OPCAOPAGVA_DB_SELECT_4();

                /*" -2100- ELSE */
            }
            else
            {


                /*" -2101- MOVE 'SELECT V0COBERPROPVA X2  ' TO COMANDO */
                _.Move("SELECT V0COBERPROPVA X2  ", WABEND.COMANDO);

                /*" -2138- PERFORM M_0100_OPCAOPAGVA_DB_SELECT_5 */

                M_0100_OPCAOPAGVA_DB_SELECT_5();

                /*" -2141- END-IF. */
            }


            /*" -2142- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2143- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -2145- END-IF */
            }


            /*" -2148- IF PROPVA-CODPRODU = 7705 OR JVPRD7705 OR 7707 OR 7708 OR 7715 */

            if (PROPVA_CODPRODU.In("7705", JVBKINCL.JV_PRODUTOS.JVPRD7705.ToString(), "7707", "7708", "7715"))
            {

                /*" -2149- CONTINUE */

                /*" -2150- ELSE */
            }
            else
            {


                /*" -2153- IF COBERP-IMPMORNATU EQUAL 0 OR COBERP-VLPREMIO EQUAL 0 OR COBERP-PRMVG EQUAL 0 */

                if (COBERP_IMPMORNATU == 0 || COBERP_VLPREMIO == 0 || COBERP_PRMVG == 0)
                {

                    /*" -2154- DISPLAY ' DESPREZADO HISCOBPR .....  ' PROPVA-NRCERTIF */
                    _.Display($" DESPREZADO HISCOBPR .....  {PROPVA_NRCERTIF}");

                    /*" -2155- MOVE 0603 TO ERRPROVI-COD-ERRO */
                    _.Move(0603, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                    /*" -2156- PERFORM 0101-00-INSERT-ERROSPROPVA */

                    M_0101_00_INSERT_ERROSPROPVA(true);

                    /*" -2157- END-IF */
                }


                /*" -2159- END-IF */
            }


            /*" -2160- IF PROPVA-INRPROPOS < 0 */

            if (PROPVA_INRPROPOS < 0)
            {

                /*" -2162- MOVE 0 TO PROPVA-NRPROPOS. */
                _.Move(0, PROPVA_NRPROPOS);
            }


            /*" -2163- IF COBERP-IVLCUSTAUXF < 0 */

            if (COBERP_IVLCUSTAUXF < 0)
            {

                /*" -2165- MOVE 0 TO COBERP-VLCUSTAUXF. */
                _.Move(0, COBERP_VLCUSTAUXF);
            }


            /*" -2166- IF COBERP-IIMPSEGAUXF < 0 */

            if (COBERP_IIMPSEGAUXF < 0)
            {

                /*" -2168- MOVE 0 TO COBERP-IMPSEGAUXF. */
                _.Move(0, COBERP_IMPSEGAUXF);
            }


            /*" -2169- IF COBERP-IQTTITCAP < 0 */

            if (COBERP_IQTTITCAP < 0)
            {

                /*" -2171- MOVE 0 TO COBERP-QTTITCAP. */
                _.Move(0, COBERP_QTTITCAP);
            }


            /*" -2172- IF PROPVA-INRMATRFUN < 0 */

            if (PROPVA_INRMATRFUN < 0)
            {

                /*" -2174- MOVE 0 TO PROPVA-NRMATRFUN. */
                _.Move(0, PROPVA_NRMATRFUN);
            }


            /*" -2175- IF PROPVA-ICODCCT < 0 */

            if (PROPVA_ICODCCT < 0)
            {

                /*" -2177- MOVE 0 TO PROPVA-CODCCT. */
                _.Move(0, PROPVA_CODCCT);
            }


            /*" -2178- IF PROPVA-NUM-APOLICE EQUAL 109300000635 */

            if (PROPVA_NUM_APOLICE == 109300000635)
            {

                /*" -2179- MOVE 'SELECT V0HISTCOBVA 1' TO COMANDO */
                _.Move("SELECT V0HISTCOBVA 1", WABEND.COMANDO);

                /*" -2185- PERFORM M_0100_OPCAOPAGVA_DB_SELECT_6 */

                M_0100_OPCAOPAGVA_DB_SELECT_6();

                /*" -2187- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2189- IF SQLCODE EQUAL 100 OR -811 NEXT SENTENCE */

                    if (DB.SQLCODE.In("100", "-811"))
                    {

                        /*" -2190- ELSE */
                    }
                    else
                    {


                        /*" -2191- DISPLAY 'NRCERTIF  = ' PROPVA-NRCERTIF */
                        _.Display($"NRCERTIF  = {PROPVA_NRCERTIF}");

                        /*" -2192- DISPLAY 'NRPARCEL  = ' V0COBER-MINOCOR */
                        _.Display($"NRPARCEL  = {V0COBER_MINOCOR}");

                        /*" -2193- GO TO 9999-ERRO */

                        M_9999_ERRO(); //GOTO
                        return;

                        /*" -2194- END-IF */
                    }


                    /*" -2195- END-IF */
                }


                /*" -2196- ELSE */
            }
            else
            {


                /*" -2197- MOVE 'SELECT V0PARCELVA 2' TO COMANDO */
                _.Move("SELECT V0PARCELVA 2", WABEND.COMANDO);

                /*" -2203- PERFORM M_0100_OPCAOPAGVA_DB_SELECT_7 */

                M_0100_OPCAOPAGVA_DB_SELECT_7();

                /*" -2206- END-IF */
            }


            /*" -2207- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2208- IF SQLCODE = 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2209- MOVE ZEROS TO V0HCOB-VLPRMTOT */
                    _.Move(0, V0HCOB_VLPRMTOT);

                    /*" -2210- ELSE */
                }
                else
                {


                    /*" -2212- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -2214- IF PRODVG-ORIG-PRODU = ( 'MULT' OR 'CAMP' ) AND PROPVA-SITUACAO */

            if (PRODVG_ORIG_PRODU.In("MULT", "CAMP", PROPVA_SITUACAO.ToString()))
            {

                /*" -2215- PERFORM 1000-INTEGRA-MULTIPREMIADO THRU 1000-FIM */

                M_1000_INTEGRA_MULTIPREMIADO(true);

                M_1000_AJUSTA_DTPROXVEN(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1000_FIM*/


                /*" -2216- MOVE PRODVG-CODRELAT TO RELATO-CODRELAT */
                _.Move(PRODVG_CODRELAT, RELATO_CODRELAT);

                /*" -2217- IF WSQLCODE-PLANOS = 100 */

                if (WS_WORK_AREAS.WSQLCODE_PLANOS == 100)
                {

                    /*" -2218- DISPLAY ' DESPREZADO PLAVAVGA .....  ' PROPVA-NRCERTIF */
                    _.Display($" DESPREZADO PLAVAVGA .....  {PROPVA_NRCERTIF}");

                    /*" -2219- MOVE 0604 TO ERRPROVI-COD-ERRO */
                    _.Move(0604, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                    /*" -2221- PERFORM 0101-00-INSERT-ERROSPROPVA. */

                    M_0101_00_INSERT_ERROSPROPVA(true);
                }

            }


            /*" -2223- IF PRODVG-ORIG-PRODU = 'VIDAZUL' AND PROPVA-SITUACAO = '0' */

            if (PRODVG_ORIG_PRODU == "VIDAZUL" && PROPVA_SITUACAO == "0")
            {

                /*" -2224- PERFORM 1100-INTEGRA-VIDAZUL THRU 1100-FIM */

                M_1100_INTEGRA_VIDAZUL(true);

                M_1100_AJUSTA_DTPROXVEN(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1100_FIM*/


                /*" -2225- IF PRODVG-CODPRODAZ = 'EXC' */

                if (PRODVG_CODPRODAZ == "EXC")
                {

                    /*" -2226- MOVE 'VG0420B' TO RELATO-CODRELAT */
                    _.Move("VG0420B", RELATO_CODRELAT);

                    /*" -2227- ELSE */
                }
                else
                {


                    /*" -2228- IF PRODVG-CODPRODAZ = 'SNR' */

                    if (PRODVG_CODPRODAZ == "SNR")
                    {

                        /*" -2229- MOVE 'VG0420B' TO RELATO-CODRELAT */
                        _.Move("VG0420B", RELATO_CODRELAT);

                        /*" -2230- END-IF */
                    }


                    /*" -2231- END-IF */
                }


                /*" -2232- IF WSQLCODE-PLANOS = 100 */

                if (WS_WORK_AREAS.WSQLCODE_PLANOS == 100)
                {

                    /*" -2233- DISPLAY ' DESPREZADO PLAVAVGA .....  ' PROPVA-NRCERTIF */
                    _.Display($" DESPREZADO PLAVAVGA .....  {PROPVA_NRCERTIF}");

                    /*" -2234- MOVE 0604 TO ERRPROVI-COD-ERRO */
                    _.Move(0604, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                    /*" -2235- PERFORM 0101-00-INSERT-ERROSPROPVA */

                    M_0101_00_INSERT_ERROSPROPVA(true);

                    /*" -2236- END-IF */
                }


                /*" -2238- END-IF */
            }


            /*" -2240- IF PRODVG-ORIG-PRODU = ( 'GLOBAL' ) AND PROPVA-SITUACAO = '0' */

            if (PRODVG_ORIG_PRODU == ("GLOBAL") && PROPVA_SITUACAO == "0")
            {

                /*" -2241- PERFORM 2000-INTEGRA-EMPRESA-GLOBAL THRU 2000-FIM */

                M_2000_INTEGRA_EMPRESA_GLOBAL(true);

                M_2000_AJUSTA_DTPROXVEN(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2000_FIM*/


                /*" -2242- MOVE 'VL0420B' TO RELATO-CODRELAT */
                _.Move("VL0420B", RELATO_CODRELAT);

                /*" -2243- IF WSQLCODE-PLANOS = 100 */

                if (WS_WORK_AREAS.WSQLCODE_PLANOS == 100)
                {

                    /*" -2244- DISPLAY ' DESPREZADO PLAVAVGA .....  ' PROPVA-NRCERTIF */
                    _.Display($" DESPREZADO PLAVAVGA .....  {PROPVA_NRCERTIF}");

                    /*" -2245- MOVE 0604 TO ERRPROVI-COD-ERRO */
                    _.Move(0604, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                    /*" -2246- PERFORM 0101-00-INSERT-ERROSPROPVA */

                    M_0101_00_INSERT_ERROSPROPVA(true);

                    /*" -2247- END-IF */
                }


                /*" -2249- END-IF */
            }


            /*" -2252- IF PROPVA-NUM-APOLICE = 109700000027 AND PROPVA-CODSUBES = 1 AND PROPVA-SITUACAO = '0' */

            if (PROPVA_NUM_APOLICE == 109700000027 && PROPVA_CODSUBES == 1 && PROPVA_SITUACAO == "0")
            {

                /*" -2253- PERFORM 3000-INTEGRA-JORNAL-FENAM THRU 3000-FIM */

                M_3000_INTEGRA_JORNAL_FENAM(true);

                M_3000_AJUSTA_DTPROXVEN(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3000_FIM*/


                /*" -2254- MOVE 'VA0424B' TO RELATO-CODRELAT */
                _.Move("VA0424B", RELATO_CODRELAT);

                /*" -2255- IF WSQLCODE-PLANOS = 100 */

                if (WS_WORK_AREAS.WSQLCODE_PLANOS == 100)
                {

                    /*" -2256- DISPLAY ' DESPREZADO PLAVAVGA .....  ' PROPVA-NRCERTIF */
                    _.Display($" DESPREZADO PLAVAVGA .....  {PROPVA_NRCERTIF}");

                    /*" -2257- MOVE 0604 TO ERRPROVI-COD-ERRO */
                    _.Move(0604, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                    /*" -2258- PERFORM 0101-00-INSERT-ERROSPROPVA */

                    M_0101_00_INSERT_ERROSPROPVA(true);

                    /*" -2259- END-IF */
                }


                /*" -2261- END-IF */
            }


            /*" -2263- IF PRODVG-ORIG-PRODU = ( 'AVERB' ) AND PROPVA-SITUACAO = '0' */

            if (PRODVG_ORIG_PRODU == ("AVERB") && PROPVA_SITUACAO == "0")
            {

                /*" -2264- PERFORM 4000-INTEGRA-PREF-VIDA THRU 4000-FIM */

                M_4000_INTEGRA_PREF_VIDA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_4000_FIM*/


                /*" -2265- MOVE PRODVG-CODRELAT TO RELATO-CODRELAT */
                _.Move(PRODVG_CODRELAT, RELATO_CODRELAT);

                /*" -2266- IF WSQLCODE-PLANOS = 100 */

                if (WS_WORK_AREAS.WSQLCODE_PLANOS == 100)
                {

                    /*" -2267- DISPLAY ' DESPREZADO PLAVAVGA .....  ' PROPVA-NRCERTIF */
                    _.Display($" DESPREZADO PLAVAVGA .....  {PROPVA_NRCERTIF}");

                    /*" -2268- MOVE 0604 TO ERRPROVI-COD-ERRO */
                    _.Move(0604, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                    /*" -2269- PERFORM 0101-00-INSERT-ERROSPROPVA */

                    M_0101_00_INSERT_ERROSPROPVA(true);

                    /*" -2270- END-IF */
                }


                /*" -2272- END-IF */
            }


            /*" -2274- IF PRODVG-ORIG-PRODU = 'PAREN' OR 'CEF DEB CC' AND PROPVA-SITUACAO = '0' */

            if (PRODVG_ORIG_PRODU.In("PAREN", "CEF DEB CC") && PROPVA_SITUACAO == "0")
            {

                /*" -2275- PERFORM 5000-INTEGRA-PARENTES-PV THRU 5000-FIM */

                M_5000_INTEGRA_PARENTES_PV(true);

                M_5000_AJUSTA_DTPROXVEN(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5000_FIM*/


                /*" -2276- MOVE PRODVG-CODRELAT TO RELATO-CODRELAT */
                _.Move(PRODVG_CODRELAT, RELATO_CODRELAT);

                /*" -2277- IF WSQLCODE-PLANOS = 100 */

                if (WS_WORK_AREAS.WSQLCODE_PLANOS == 100)
                {

                    /*" -2278- DISPLAY ' DESPREZADO PLAVAVGA .....  ' PROPVA-NRCERTIF */
                    _.Display($" DESPREZADO PLAVAVGA .....  {PROPVA_NRCERTIF}");

                    /*" -2279- MOVE 0604 TO ERRPROVI-COD-ERRO */
                    _.Move(0604, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                    /*" -2280- PERFORM 0101-00-INSERT-ERROSPROPVA */

                    M_0101_00_INSERT_ERROSPROPVA(true);

                    /*" -2281- END-IF */
                }


                /*" -2283- END-IF */
            }


            /*" -2285- IF PRODVG-ORIG-PRODU = 'CAAES' AND PROPVA-SITUACAO = '0' */

            if (PRODVG_ORIG_PRODU == "CAAES" && PROPVA_SITUACAO == "0")
            {

                /*" -2286- PERFORM 5000-INTEGRA-PARENTES-PV THRU 5000-FIM */

                M_5000_INTEGRA_PARENTES_PV(true);

                M_5000_AJUSTA_DTPROXVEN(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5000_FIM*/


                /*" -2287- MOVE '       ' TO RELATO-CODRELAT */
                _.Move("       ", RELATO_CODRELAT);

                /*" -2288- IF WSQLCODE-PLANOS = 100 */

                if (WS_WORK_AREAS.WSQLCODE_PLANOS == 100)
                {

                    /*" -2289- DISPLAY ' DESPREZADO PLAVAVGA .....  ' PROPVA-NRCERTIF */
                    _.Display($" DESPREZADO PLAVAVGA .....  {PROPVA_NRCERTIF}");

                    /*" -2290- MOVE 0604 TO ERRPROVI-COD-ERRO */
                    _.Move(0604, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                    /*" -2291- PERFORM 0101-00-INSERT-ERROSPROPVA */

                    M_0101_00_INSERT_ERROSPROPVA(true);

                    /*" -2292- END-IF */
                }


                /*" -2294- END-IF */
            }


            /*" -2295- IF PROPVA-SITUACAO = '7' */

            if (PROPVA_SITUACAO == "7")
            {

                /*" -2296- PERFORM 8600-PRIMEIRA-COBRANCA THRU 8600-FIM */

                M_8600_PRIMEIRA_COBRANCA(true);

                M_8600_10_CONTINUA(true);

                M_8600_CONTINUA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8600_FIM*/


                /*" -2298- END-IF */
            }


            /*" -2300- IF PROPVA-CODPRODU = 7732 OR JVPRD7732 OR 7733 OR JVPRD7733 */

            if (PROPVA_CODPRODU.In("7732", JVBKINCL.JV_PRODUTOS.JVPRD7732.ToString(), "7733", JVBKINCL.JV_PRODUTOS.JVPRD7733.ToString()))
            {

                /*" -2301- IF PROPVA-SITUACAO = '3' */

                if (PROPVA_SITUACAO == "3")
                {

                    /*" -2302- PERFORM 8600-PRIMEIRA-COBRANCA THRU 8600-FIM */

                    M_8600_PRIMEIRA_COBRANCA(true);

                    M_8600_10_CONTINUA(true);

                    M_8600_CONTINUA(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8600_FIM*/


                    /*" -2303- END-IF */
                }


                /*" -2305- END-IF */
            }


            /*" -2306- IF PROPVA-SITUACAO = '3' */

            if (PROPVA_SITUACAO == "3")
            {

                /*" -2307- IF PROPVA-NUM-APOLICE = 0109300000550 */

                if (PROPVA_NUM_APOLICE == 0109300000550)
                {

                    /*" -2308- IF PROPVA-FAIXA-RENDA-IND NOT LESS '3' */

                    if (PROPVA_FAIXA_RENDA_IND >= "3")
                    {

                        /*" -2309- MOVE '0100-PROCESSA-PROPOSTA' TO PARAGRAFO */
                        _.Move("0100-PROCESSA-PROPOSTA", WABEND.PARAGRAFO);

                        /*" -2310- MOVE 'SELECT COBRANCA_MENS_VGAP' TO COMANDO */
                        _.Move("SELECT COBRANCA_MENS_VGAP", WABEND.COMANDO);

                        /*" -2321- PERFORM M_0100_OPCAOPAGVA_DB_SELECT_8 */

                        M_0100_OPCAOPAGVA_DB_SELECT_8();

                        /*" -2323- IF SQLCODE EQUAL ZEROES */

                        if (DB.SQLCODE == 00)
                        {

                            /*" -2325- MOVE 3 TO RELATO-OPERACAO RELATO-NRPARCEL */
                            _.Move(3, RELATO_OPERACAO, RELATO_NRPARCEL);

                            /*" -2326- PERFORM 0200-SOLICITA-CERTIFICADO THRU 0200-FIM */

                            M_0200_SOLICITA_CERTIFICADO(true);
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0200_FIM*/


                            /*" -2327- PERFORM 1110-VERIFICA-RCAP THRU 1110-FIM */

                            M_1110_VERIFICA_RCAP(true);

                            FINALIZA_1110_FIM(true);
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1110_FIM*/


                            /*" -2328- ELSE */
                        }
                        else
                        {


                            /*" -2329- IF SQLCODE NOT EQUAL 100 */

                            if (DB.SQLCODE != 100)
                            {

                                /*" -2330- GO TO 9999-ERRO */

                                M_9999_ERRO(); //GOTO
                                return;

                                /*" -2331- END-IF */
                            }


                            /*" -2332- MOVE '0100-PROCESSA-PROPOSTA' TO PARAGRAFO */
                            _.Move("0100-PROCESSA-PROPOSTA", WABEND.PARAGRAFO);

                            /*" -2333- MOVE 'SELECT COBRANCA_MENS_VGAP1 ' TO COMANDO */
                            _.Move("SELECT COBRANCA_MENS_VGAP1 ", WABEND.COMANDO);

                            /*" -2344- PERFORM M_0100_OPCAOPAGVA_DB_SELECT_9 */

                            M_0100_OPCAOPAGVA_DB_SELECT_9();

                            /*" -2346- IF SQLCODE EQUAL ZEROES */

                            if (DB.SQLCODE == 00)
                            {

                                /*" -2348- MOVE 2 TO RELATO-OPERACAO RELATO-NRPARCEL */
                                _.Move(2, RELATO_OPERACAO, RELATO_NRPARCEL);

                                /*" -2349- ELSE */
                            }
                            else
                            {


                                /*" -2350- IF SQLCODE NOT EQUAL 100 */

                                if (DB.SQLCODE != 100)
                                {

                                    /*" -2351- GO TO 9999-ERRO */

                                    M_9999_ERRO(); //GOTO
                                    return;

                                    /*" -2352- END-IF */
                                }


                                /*" -2354- MOVE ZEROS TO RELATO-OPERACAO RELATO-NRPARCEL */
                                _.Move(0, RELATO_OPERACAO, RELATO_NRPARCEL);

                                /*" -2355- END-IF */
                            }


                            /*" -2356- PERFORM 0200-SOLICITA-CERTIFICADO THRU 0200-FIM */

                            M_0200_SOLICITA_CERTIFICADO(true);
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0200_FIM*/


                            /*" -2357- PERFORM 1110-VERIFICA-RCAP THRU 1110-FIM */

                            M_1110_VERIFICA_RCAP(true);

                            FINALIZA_1110_FIM(true);
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1110_FIM*/


                            /*" -2358- END-IF */
                        }


                        /*" -2359- END-IF */
                    }


                    /*" -2360- ELSE */
                }
                else
                {


                    /*" -2362- IF PROPVA-CODPRODU NOT = 7705 AND JVPRD7705 AND 7715 */

                    if (!PROPVA_CODPRODU.In("7705", JVBKINCL.JV_PRODUTOS.JVPRD7705.ToString(), "7715"))
                    {

                        /*" -2363- MOVE '0100-PROCESSA-PROPOSTA' TO PARAGRAFO */
                        _.Move("0100-PROCESSA-PROPOSTA", WABEND.PARAGRAFO);

                        /*" -2364- MOVE 'SELECT COBRANCA_MENS_VGAP1 ' TO COMANDO */
                        _.Move("SELECT COBRANCA_MENS_VGAP1 ", WABEND.COMANDO);

                        /*" -2375- PERFORM M_0100_OPCAOPAGVA_DB_SELECT_10 */

                        M_0100_OPCAOPAGVA_DB_SELECT_10();

                        /*" -2377- IF SQLCODE EQUAL ZEROES */

                        if (DB.SQLCODE == 00)
                        {

                            /*" -2379- MOVE 5 TO RELATO-OPERACAO RELATO-NRPARCEL */
                            _.Move(5, RELATO_OPERACAO, RELATO_NRPARCEL);

                            /*" -2380- PERFORM 0200-SOLICITA-CERTIFICADO THRU 0200-FIM */

                            M_0200_SOLICITA_CERTIFICADO(true);
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0200_FIM*/


                            /*" -2381- PERFORM 1110-VERIFICA-RCAP THRU 1110-FIM */

                            M_1110_VERIFICA_RCAP(true);

                            FINALIZA_1110_FIM(true);
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1110_FIM*/


                            /*" -2382- ELSE */
                        }
                        else
                        {


                            /*" -2383- IF SQLCODE NOT EQUAL 100 */

                            if (DB.SQLCODE != 100)
                            {

                                /*" -2384- GO TO 9999-ERRO */

                                M_9999_ERRO(); //GOTO
                                return;

                                /*" -2385- END-IF */
                            }


                            /*" -2386- MOVE '0100-PROCESSA-PROPOSTA' TO PARAGRAFO */
                            _.Move("0100-PROCESSA-PROPOSTA", WABEND.PARAGRAFO);

                            /*" -2387- MOVE 'SELECT COBRANCA_MENS_VGAP1 ' TO COMANDO */
                            _.Move("SELECT COBRANCA_MENS_VGAP1 ", WABEND.COMANDO);

                            /*" -2398- PERFORM M_0100_OPCAOPAGVA_DB_SELECT_11 */

                            M_0100_OPCAOPAGVA_DB_SELECT_11();

                            /*" -2400- IF SQLCODE EQUAL ZEROES */

                            if (DB.SQLCODE == 00)
                            {

                                /*" -2402- MOVE 2 TO RELATO-OPERACAO RELATO-NRPARCEL */
                                _.Move(2, RELATO_OPERACAO, RELATO_NRPARCEL);

                                /*" -2403- ELSE */
                            }
                            else
                            {


                                /*" -2404- IF SQLCODE NOT EQUAL 100 */

                                if (DB.SQLCODE != 100)
                                {

                                    /*" -2405- GO TO 9999-ERRO */

                                    M_9999_ERRO(); //GOTO
                                    return;

                                    /*" -2406- END-IF */
                                }


                                /*" -2408- MOVE ZEROS TO RELATO-OPERACAO RELATO-NRPARCEL */
                                _.Move(0, RELATO_OPERACAO, RELATO_NRPARCEL);

                                /*" -2409- END-IF */
                            }


                            /*" -2410- PERFORM 0200-SOLICITA-CERTIFICADO THRU 0200-FIM */

                            M_0200_SOLICITA_CERTIFICADO(true);
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0200_FIM*/


                            /*" -2412- PERFORM 1110-VERIFICA-RCAP THRU 1110-FIM. */

                            M_1110_VERIFICA_RCAP(true);

                            FINALIZA_1110_FIM(true);
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1110_FIM*/

                        }

                    }

                }

            }


            /*" -2414- IF PROPVA-NUM-APOLICE = 97010000889 AND PROPVA-SITUACAO = '3' */

            if (PROPVA_NUM_APOLICE == 97010000889 && PROPVA_SITUACAO == "3")
            {

                /*" -2415- PERFORM 0300-VERIFICA-CROT THRU 0300-FIM */

                M_0300_VERIFICA_CROT(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0300_FIM*/


                /*" -2422- END-IF. */
            }


            /*" -2423- IF PROPVA-SITUACAO = '3' */

            if (PROPVA_SITUACAO == "3")
            {

                /*" -2424- IF PRODVG-ORIG-PRODU = ( 'MULT' ) */

                if (PRODVG_ORIG_PRODU == ("MULT"))
                {

                    /*" -2425- PERFORM R0397-00-PROXIMO-FOLHETO THRU R0397-FIM */

                    R0397_00_PROXIMO_FOLHETO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0397_FIM*/


                    /*" -2427- PERFORM 0400-GERA-MOV-FOLHETOS THRU 0400-FIM. */

                    M_0400_GERA_MOV_FOLHETOS(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0400_FIM*/

                }

            }


            /*" -2431- IF CANAL-VENDA-GITEL OR PROPOSTA-CACB OR PROPOSTA-COPESP OR PROPVA-DTPROXVEN-S EQUAL '9999-12-31' */

            if (WS_WORK_AREAS.CANAL.W_CANAL_PROPOSTA["CANAL_VENDA_GITEL"] || WS_WORK_AREAS.FILLER_1.W_CANAL_PROPOSTA1["PROPOSTA_CACB"] || WS_WORK_AREAS.FILLER_1.W_CANAL_PROPOSTA1["PROPOSTA_COPESP"] || PROPVA_DTPROXVEN_S == "9999-12-31")
            {

                /*" -2432- MOVE PROPVA-DTPROXVEN-S TO PROPVA-DTPROXVEN */
                _.Move(PROPVA_DTPROXVEN_S, PROPVA_DTPROXVEN);

                /*" -2434- END-IF. */
            }


            /*" -2435- MOVE '0100-PROCESSA-PROPOSTA' TO PARAGRAFO. */
            _.Move("0100-PROCESSA-PROPOSTA", WABEND.PARAGRAFO);

            /*" -2436- MOVE 'UPDATE V0PROPOSTAVA 04' TO COMANDO. */
            _.Move("UPDATE V0PROPOSTAVA 04", WABEND.COMANDO);

            /*" -2438- MOVE WS-PROPVA-DTPROXVEN TO PROPVA-DTPROXVEN */
            _.Move(WS_PROPVA_DTPROXVEN, PROPVA_DTPROXVEN);

            /*" -2450- PERFORM M_0100_OPCAOPAGVA_DB_UPDATE_2 */

            M_0100_OPCAOPAGVA_DB_UPDATE_2();

            /*" -2452- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2453- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -2455- END-IF */
            }


            /*" -2455- ADD 1 TO AC-INCLUSOES. */
            WS_WORK_AREAS.AC_INCLUSOES.Value = WS_WORK_AREAS.AC_INCLUSOES + 1;

        }

        [StopWatch]
        /*" M-0100-OPCAOPAGVA-DB-SELECT-1 */
        public void M_0100_OPCAOPAGVA_DB_SELECT_1()
        {
            /*" -1896- EXEC SQL SELECT OPCAOPAG, PERIPGTO, DIA_DEBITO, AGECTADEB, OPRCTADEB, NUMCTADEB, DIGCTADEB, NUM_CARTAO_CREDITO INTO :OPCAOP-OPCAOPAG, :OPCAOP-PERIPGTO, :OPCAOP-DIA-DEB, :OPCAOP-AGECTADEB:INDAGE, :OPCAOP-OPRCTADEB:INDOPR, :OPCAOP-NUMCTADEB:INDNUM, :OPCAOP-DIGCTADEB:INDDIG, :OPCAOP-CARTAOCRED:INDCARTAO FROM SEGUROS.V0OPCAOPAGVA WHERE NRCERTIF = :PROPVA-NRCERTIF AND DTTERVIG IN ( '1999-12-31' , '9999-12-31' ) END-EXEC. */

            var m_0100_OPCAOPAGVA_DB_SELECT_1_Query1 = new M_0100_OPCAOPAGVA_DB_SELECT_1_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = M_0100_OPCAOPAGVA_DB_SELECT_1_Query1.Execute(m_0100_OPCAOPAGVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OPCAOP_OPCAOPAG, OPCAOP_OPCAOPAG);
                _.Move(executed_1.OPCAOP_PERIPGTO, OPCAOP_PERIPGTO);
                _.Move(executed_1.OPCAOP_DIA_DEB, OPCAOP_DIA_DEB);
                _.Move(executed_1.OPCAOP_AGECTADEB, OPCAOP_AGECTADEB);
                _.Move(executed_1.INDAGE, INDAGE);
                _.Move(executed_1.OPCAOP_OPRCTADEB, OPCAOP_OPRCTADEB);
                _.Move(executed_1.INDOPR, INDOPR);
                _.Move(executed_1.OPCAOP_NUMCTADEB, OPCAOP_NUMCTADEB);
                _.Move(executed_1.INDNUM, INDNUM);
                _.Move(executed_1.OPCAOP_DIGCTADEB, OPCAOP_DIGCTADEB);
                _.Move(executed_1.INDDIG, INDDIG);
                _.Move(executed_1.OPCAOP_CARTAOCRED, OPCAOP_CARTAOCRED);
                _.Move(executed_1.INDCARTAO, INDCARTAO);
            }


        }

        [StopWatch]
        /*" M-0100-OPCAOPAGVA-DB-UPDATE-1 */
        public void M_0100_OPCAOPAGVA_DB_UPDATE_1()
        {
            /*" -1963- EXEC SQL UPDATE SEGUROS.OPCAO_PAG_VIDAZUL SET PERI_PAGAMENTO = :OPCAOP-PERIPGTO, DIA_DEBITO = :OPCAOP-DIA-DEB, OPCAO_PAGAMENTO = :OPCAOP-OPCAOPAG WHERE NUM_CERTIFICADO = :PROPVA-NRCERTIF END-EXEC */

            var m_0100_OPCAOPAGVA_DB_UPDATE_1_Update1 = new M_0100_OPCAOPAGVA_DB_UPDATE_1_Update1()
            {
                OPCAOP_PERIPGTO = OPCAOP_PERIPGTO.ToString(),
                OPCAOP_OPCAOPAG = OPCAOP_OPCAOPAG.ToString(),
                OPCAOP_DIA_DEB = OPCAOP_DIA_DEB.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            M_0100_OPCAOPAGVA_DB_UPDATE_1_Update1.Execute(m_0100_OPCAOPAGVA_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-2 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_2()
        {
            /*" -1653- EXEC SQL SELECT 'S' INTO :WTEM-ERRO-7705 FROM SEGUROS.ERROS_PROP_VIDAZUL WHERE NUM_CERTIFICADO = :PROPVA-NRCERTIF AND COD_ERRO IN (1866,1867,1868,1869,1870) FETCH FIRST 1 ROW ONLY WITH UR END-EXEC */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WTEM_ERRO_7705, WS_WORK_AREAS.WTEM_ERRO_7705);
            }


        }

        [StopWatch]
        /*" M-0100-OPCAOPAGVA-DB-SELECT-2 */
        public void M_0100_OPCAOPAGVA_DB_SELECT_2()
        {
            /*" -2016- EXEC SQL SELECT COD_AGENCIA INTO :V0AGCEF-COD-AGCOBR FROM SEGUROS.V0AGENCIACEF WHERE COD_AGENCIA = :PROPVA-AGECOBR WITH UR END-EXEC */

            var m_0100_OPCAOPAGVA_DB_SELECT_2_Query1 = new M_0100_OPCAOPAGVA_DB_SELECT_2_Query1()
            {
                PROPVA_AGECOBR = PROPVA_AGECOBR.ToString(),
            };

            var executed_1 = M_0100_OPCAOPAGVA_DB_SELECT_2_Query1.Execute(m_0100_OPCAOPAGVA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0AGCEF_COD_AGCOBR, V0AGCEF_COD_AGCOBR);
            }


        }

        [StopWatch]
        /*" M-0100-NEXT */
        private void M_0100_NEXT(bool isPerform = false)
        {
            /*" -2466- IF PROPVA-SITUACAO = '0' AND PRODVG-ORIG-PRODU = 'CEF DEB CC' NEXT SENTENCE */

            if (PROPVA_SITUACAO == "0" && PRODVG_ORIG_PRODU == "CEF DEB CC")
            {

                /*" -2467- ELSE */
            }
            else
            {


                /*" -2468- IF PROPVA-SITUACAO = '0' OR '1' */

                if (PROPVA_SITUACAO.In("0", "1"))
                {

                    /*" -2469- ADD 1 TO AC-DESPREZADOS */
                    WS_WORK_AREAS.AC_DESPREZADOS.Value = WS_WORK_AREAS.AC_DESPREZADOS + 1;

                    /*" -2470- MOVE '0100-PROCESSA-PROPOSTA' TO PARAGRAFO */
                    _.Move("0100-PROCESSA-PROPOSTA", WABEND.PARAGRAFO);

                    /*" -2472- MOVE 'UPDATE V0PROPOSTAVA 05' TO COMANDO */
                    _.Move("UPDATE V0PROPOSTAVA 05", WABEND.COMANDO);

                    /*" -2476- PERFORM M_0100_NEXT_DB_UPDATE_1 */

                    M_0100_NEXT_DB_UPDATE_1();

                    /*" -2478- IF SQLCODE NOT EQUAL ZEROES */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -2480- GO TO 9999-ERRO. */

                        M_9999_ERRO(); //GOTO
                        return;
                    }

                }

            }


            /*" -2481- IF PROPVA-SITUACAO = '3' */

            if (PROPVA_SITUACAO == "3")
            {

                /*" -2482- IF PRODVG-ESTR-COBR EQUAL 'MULT' */

                if (PRODVG_ESTR_COBR == "MULT")
                {

                    /*" -2485- PERFORM R7770-00-PROPOSTAS-SIVPF-SIVPF THRU R7770-FIM. */

                    R7770_00_PROPOSTAS_SIVPF_SIVPF(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R7770_FIM*/

                }

            }


            /*" -2485- PERFORM 0110-FETCH THRU 0110-FIM. */

            M_0110_FETCH(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/


        }

        [StopWatch]
        /*" M-0100-NEXT-DB-UPDATE-1 */
        public void M_0100_NEXT_DB_UPDATE_1()
        {
            /*" -2476- EXEC SQL UPDATE SEGUROS.V0PROPOSTAVA SET SITUACAO = '1' WHERE NRCERTIF = :PROPVA-NRCERTIF END-EXEC */

            var m_0100_NEXT_DB_UPDATE_1_Update1 = new M_0100_NEXT_DB_UPDATE_1_Update1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            M_0100_NEXT_DB_UPDATE_1_Update1.Execute(m_0100_NEXT_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-0100-OPCAOPAGVA-DB-SELECT-3 */
        public void M_0100_OPCAOPAGVA_DB_SELECT_3()
        {
            /*" -2051- EXEC SQL SELECT MIN(OCORHIST) INTO :V0COBER-MINOCOR FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :PROPVA-NRCERTIF WITH UR END-EXEC */

            var m_0100_OPCAOPAGVA_DB_SELECT_3_Query1 = new M_0100_OPCAOPAGVA_DB_SELECT_3_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = M_0100_OPCAOPAGVA_DB_SELECT_3_Query1.Execute(m_0100_OPCAOPAGVA_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBER_MINOCOR, V0COBER_MINOCOR);
            }


        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-3 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_3()
        {
            /*" -1693- EXEC SQL SELECT 'S' INTO :WTEM-ERRO-7715 FROM SEGUROS.ERROS_PROP_VIDAZUL WHERE NUM_CERTIFICADO = :PROPVA-NRCERTIF AND COD_ERRO IN (1866,1867,1868,1869,1870) FETCH FIRST 1 ROW ONLY WITH UR END-EXEC */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WTEM_ERRO_7715, WS_WORK_AREAS.WTEM_ERRO_7715);
            }


        }

        [StopWatch]
        /*" M-0100-OPCAOPAGVA-DB-SELECT-4 */
        public void M_0100_OPCAOPAGVA_DB_SELECT_4()
        {
            /*" -2098- EXEC SQL SELECT DTINIVIG, DTTERVIG, IMPMORNATU, IMPMORACID, IMPINVPERM, IMPAMDS, IMPDH, IMPDIT, VLPREMIO, PRMVG, PRMAP, IMPSEGCDC, VLCUSTCDG, VLCUSTCAP, IMPSEGAUXF, VLCUSTAUXF, QTTITCAP INTO :COBERP-DTINIVIG, :COBERP-DTTERVIG, :COBERP-IMPMORNATU, :COBERP-IMPMORACID, :COBERP-IMPINVPERM, :COBERP-IMPAMDS, :COBERP-IMPDH, :COBERP-IMPDIT, :COBERP-VLPREMIO, :COBERP-PRMVG, :COBERP-PRMAP, :COBERP-IMPSEGCDG, :COBERP-VLCUSTCDG, :COBERP-VLCUSTCAP, :COBERP-IMPSEGAUXF:COBERP-IIMPSEGAUXF, :COBERP-VLCUSTAUXF:COBERP-IVLCUSTAUXF, :COBERP-QTTITCAP:COBERP-IQTTITCAP FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :PROPVA-NRCERTIF AND OCORHIST = :V0COBER-MINOCOR WITH UR END-EXEC */

            var m_0100_OPCAOPAGVA_DB_SELECT_4_Query1 = new M_0100_OPCAOPAGVA_DB_SELECT_4_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                V0COBER_MINOCOR = V0COBER_MINOCOR.ToString(),
            };

            var executed_1 = M_0100_OPCAOPAGVA_DB_SELECT_4_Query1.Execute(m_0100_OPCAOPAGVA_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COBERP_DTINIVIG, COBERP_DTINIVIG);
                _.Move(executed_1.COBERP_DTTERVIG, COBERP_DTTERVIG);
                _.Move(executed_1.COBERP_IMPMORNATU, COBERP_IMPMORNATU);
                _.Move(executed_1.COBERP_IMPMORACID, COBERP_IMPMORACID);
                _.Move(executed_1.COBERP_IMPINVPERM, COBERP_IMPINVPERM);
                _.Move(executed_1.COBERP_IMPAMDS, COBERP_IMPAMDS);
                _.Move(executed_1.COBERP_IMPDH, COBERP_IMPDH);
                _.Move(executed_1.COBERP_IMPDIT, COBERP_IMPDIT);
                _.Move(executed_1.COBERP_VLPREMIO, COBERP_VLPREMIO);
                _.Move(executed_1.COBERP_PRMVG, COBERP_PRMVG);
                _.Move(executed_1.COBERP_PRMAP, COBERP_PRMAP);
                _.Move(executed_1.COBERP_IMPSEGCDG, COBERP_IMPSEGCDG);
                _.Move(executed_1.COBERP_VLCUSTCDG, COBERP_VLCUSTCDG);
                _.Move(executed_1.COBERP_VLCUSTCAP, COBERP_VLCUSTCAP);
                _.Move(executed_1.COBERP_IMPSEGAUXF, COBERP_IMPSEGAUXF);
                _.Move(executed_1.COBERP_IIMPSEGAUXF, COBERP_IIMPSEGAUXF);
                _.Move(executed_1.COBERP_VLCUSTAUXF, COBERP_VLCUSTAUXF);
                _.Move(executed_1.COBERP_IVLCUSTAUXF, COBERP_IVLCUSTAUXF);
                _.Move(executed_1.COBERP_QTTITCAP, COBERP_QTTITCAP);
                _.Move(executed_1.COBERP_IQTTITCAP, COBERP_IQTTITCAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0100_FIM*/

        [StopWatch]
        /*" M-0100-OPCAOPAGVA-DB-SELECT-5 */
        public void M_0100_OPCAOPAGVA_DB_SELECT_5()
        {
            /*" -2138- EXEC SQL SELECT DTINIVIG, IMPMORNATU, IMPMORACID, IMPINVPERM, IMPAMDS, IMPDH, IMPDIT, VLPREMIO, PRMVG, PRMAP, IMPSEGCDC, VLCUSTCDG, VLCUSTCAP, IMPSEGAUXF, VLCUSTAUXF, QTTITCAP INTO :COBERP-DTINIVIG, :COBERP-IMPMORNATU, :COBERP-IMPMORACID, :COBERP-IMPINVPERM, :COBERP-IMPAMDS, :COBERP-IMPDH, :COBERP-IMPDIT, :COBERP-VLPREMIO, :COBERP-PRMVG, :COBERP-PRMAP, :COBERP-IMPSEGCDG, :COBERP-VLCUSTCDG, :COBERP-VLCUSTCAP, :COBERP-IMPSEGAUXF:COBERP-IIMPSEGAUXF, :COBERP-VLCUSTAUXF:COBERP-IVLCUSTAUXF, :COBERP-QTTITCAP:COBERP-IQTTITCAP FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :PROPVA-NRCERTIF AND OCORHIST = :PROPVA-OCORHIST WITH UR END-EXEC */

            var m_0100_OPCAOPAGVA_DB_SELECT_5_Query1 = new M_0100_OPCAOPAGVA_DB_SELECT_5_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                PROPVA_OCORHIST = PROPVA_OCORHIST.ToString(),
            };

            var executed_1 = M_0100_OPCAOPAGVA_DB_SELECT_5_Query1.Execute(m_0100_OPCAOPAGVA_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COBERP_DTINIVIG, COBERP_DTINIVIG);
                _.Move(executed_1.COBERP_IMPMORNATU, COBERP_IMPMORNATU);
                _.Move(executed_1.COBERP_IMPMORACID, COBERP_IMPMORACID);
                _.Move(executed_1.COBERP_IMPINVPERM, COBERP_IMPINVPERM);
                _.Move(executed_1.COBERP_IMPAMDS, COBERP_IMPAMDS);
                _.Move(executed_1.COBERP_IMPDH, COBERP_IMPDH);
                _.Move(executed_1.COBERP_IMPDIT, COBERP_IMPDIT);
                _.Move(executed_1.COBERP_VLPREMIO, COBERP_VLPREMIO);
                _.Move(executed_1.COBERP_PRMVG, COBERP_PRMVG);
                _.Move(executed_1.COBERP_PRMAP, COBERP_PRMAP);
                _.Move(executed_1.COBERP_IMPSEGCDG, COBERP_IMPSEGCDG);
                _.Move(executed_1.COBERP_VLCUSTCDG, COBERP_VLCUSTCDG);
                _.Move(executed_1.COBERP_VLCUSTCAP, COBERP_VLCUSTCAP);
                _.Move(executed_1.COBERP_IMPSEGAUXF, COBERP_IMPSEGAUXF);
                _.Move(executed_1.COBERP_IIMPSEGAUXF, COBERP_IIMPSEGAUXF);
                _.Move(executed_1.COBERP_VLCUSTAUXF, COBERP_VLCUSTAUXF);
                _.Move(executed_1.COBERP_IVLCUSTAUXF, COBERP_IVLCUSTAUXF);
                _.Move(executed_1.COBERP_QTTITCAP, COBERP_QTTITCAP);
                _.Move(executed_1.COBERP_IQTTITCAP, COBERP_IQTTITCAP);
            }


        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-4 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_4()
        {
            /*" -1736- EXEC SQL SELECT DATA_NASCIMENTO INTO :CLIENT-DTNASC:CLIENT-DTNASC-I FROM SEGUROS.V0CLIENTE WHERE COD_CLIENTE = :PROPVA-CODCLIEN WITH UR END-EXEC */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1()
            {
                PROPVA_CODCLIEN = PROPVA_CODCLIEN.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENT_DTNASC, CLIENT_DTNASC);
                _.Move(executed_1.CLIENT_DTNASC_I, CLIENT_DTNASC_I);
            }


        }

        [StopWatch]
        /*" M-0100-OPCAOPAGVA-DB-SELECT-6 */
        public void M_0100_OPCAOPAGVA_DB_SELECT_6()
        {
            /*" -2185- EXEC SQL SELECT VLPRMTOT INTO :V0HCOB-VLPRMTOT FROM SEGUROS.V0HISTCOBVA WHERE NRCERTIF = :PROPVA-NRCERTIF AND NRPARCEL = :V0COBER-MINOCOR END-EXEC */

            var m_0100_OPCAOPAGVA_DB_SELECT_6_Query1 = new M_0100_OPCAOPAGVA_DB_SELECT_6_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                V0COBER_MINOCOR = V0COBER_MINOCOR.ToString(),
            };

            var executed_1 = M_0100_OPCAOPAGVA_DB_SELECT_6_Query1.Execute(m_0100_OPCAOPAGVA_DB_SELECT_6_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HCOB_VLPRMTOT, V0HCOB_VLPRMTOT);
            }


        }

        [StopWatch]
        /*" M-0101-00-INSERT-ERROSPROPVA */
        private void M_0101_00_INSERT_ERROSPROPVA(bool isPerform = false)
        {
            /*" -2492- MOVE '0101-00-INSERT' TO PARAGRAFO. */
            _.Move("0101-00-INSERT", WABEND.PARAGRAFO);

            /*" -2493- MOVE 'INSERT ERRPROVI' TO COMANDO. */
            _.Move("INSERT ERRPROVI", WABEND.COMANDO);

            /*" -2497- IF PROPVA-CODPRODU = 7705 OR JVPRD7705 OR 7707 OR 7715 AND ERRPROVI-COD-ERRO NOT EQUAL 1002 AND 201 AND 603 AND 604 */

            if (PROPVA_CODPRODU.In("7705", JVBKINCL.JV_PRODUTOS.JVPRD7705.ToString(), "7707", "7715") && !ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO.In("1002", "201", "603", "604"))
            {

                /*" -2498- CONTINUE */

                /*" -2500- ELSE */
            }
            else
            {


                /*" -2505- PERFORM M_0101_00_INSERT_ERROSPROPVA_DB_INSERT_1 */

                M_0101_00_INSERT_ERROSPROPVA_DB_INSERT_1();

                /*" -2509- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL -803 */

                if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
                {

                    /*" -2510- DISPLAY 'PROBLEMAS NO INSERT A ERROS-PROP-VIDAZUL' */
                    _.Display($"PROBLEMAS NO INSERT A ERROS-PROP-VIDAZUL");

                    /*" -2511- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -2513- END-IF */
                }


                /*" -2514- MOVE '1' TO PROPVA-SITUACAO */
                _.Move("1", PROPVA_SITUACAO);

                /*" -2515- ADD 1 TO AC-DESPR-FONTE */
                WS_WORK_AREAS.AC_DESPR_FONTE.Value = WS_WORK_AREAS.AC_DESPR_FONTE + 1;

                /*" -2516- GO TO 0100-NEXT */

                M_0100_NEXT(); //GOTO
                return;

                /*" -2517- END-IF */
            }


            /*" -2517- . */

        }

        [StopWatch]
        /*" M-0101-00-INSERT-ERROSPROPVA-DB-INSERT-1 */
        public void M_0101_00_INSERT_ERROSPROPVA_DB_INSERT_1()
        {
            /*" -2505- EXEC SQL INSERT INTO SEGUROS.ERROS_PROP_VIDAZUL VALUES (:PROPVA-NRCERTIF, :ERRPROVI-COD-ERRO) END-EXEC */

            var m_0101_00_INSERT_ERROSPROPVA_DB_INSERT_1_Insert1 = new M_0101_00_INSERT_ERROSPROPVA_DB_INSERT_1_Insert1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                ERRPROVI_COD_ERRO = ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO.ToString(),
            };

            M_0101_00_INSERT_ERROSPROPVA_DB_INSERT_1_Insert1.Execute(m_0101_00_INSERT_ERROSPROPVA_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" M-0100-OPCAOPAGVA-DB-UPDATE-2 */
        public void M_0100_OPCAOPAGVA_DB_UPDATE_2()
        {
            /*" -2450- EXEC SQL UPDATE SEGUROS.V0PROPOSTAVA SET CODPRODU = :PROPVA-CODPRODU, CODOPER = :PROPVA-CODOPER, DTMOVTO = :MDTMOVTO, DTPROXVEN = :PROPVA-DTPROXVEN, SITUACAO = :PROPVA-SITUACAO, CODSUBES = :PROPVA-CODSUBES, NRPARCE = 1, SIT_INTERFACE = '0' , TIMESTAMP = CURRENT TIMESTAMP WHERE CURRENT OF CPROPVA END-EXEC. */

            var m_0100_OPCAOPAGVA_DB_UPDATE_2_Update1 = new M_0100_OPCAOPAGVA_DB_UPDATE_2_Update1(CPROPVA)
            {
                PROPVA_DTPROXVEN = PROPVA_DTPROXVEN.ToString(),
                PROPVA_CODPRODU = PROPVA_CODPRODU.ToString(),
                PROPVA_SITUACAO = PROPVA_SITUACAO.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
                PROPVA_CODOPER = PROPVA_CODOPER.ToString(),
                MDTMOVTO = MDTMOVTO.ToString(),
            };

            M_0100_OPCAOPAGVA_DB_UPDATE_2_Update1.Execute(m_0100_OPCAOPAGVA_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" M-0100-OPCAOPAGVA-DB-SELECT-7 */
        public void M_0100_OPCAOPAGVA_DB_SELECT_7()
        {
            /*" -2203- EXEC SQL SELECT PRMVG + PRMAP INTO :V0HCOB-VLPRMTOT FROM SEGUROS.V0PARCELVA WHERE NRCERTIF = :PROPVA-NRCERTIF AND NRPARCEL = 1 END-EXEC */

            var m_0100_OPCAOPAGVA_DB_SELECT_7_Query1 = new M_0100_OPCAOPAGVA_DB_SELECT_7_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = M_0100_OPCAOPAGVA_DB_SELECT_7_Query1.Execute(m_0100_OPCAOPAGVA_DB_SELECT_7_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HCOB_VLPRMTOT, V0HCOB_VLPRMTOT);
            }


        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-5 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_5()
        {
            /*" -1804- EXEC SQL SELECT NUM_PROPOSTA INTO :PROPVA-NRPROPOS:PROPVA-INRPROPOS FROM SEGUROS.V0MOVIMENTO WHERE COD_FONTE = :PROPVA-FONTE AND NUM_PROPOSTA = :PROPVA-NRPROPOS END-EXEC */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1()
            {
                PROPVA_NRPROPOS = PROPVA_NRPROPOS.ToString(),
                PROPVA_FONTE = PROPVA_FONTE.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPVA_NRPROPOS, PROPVA_NRPROPOS);
                _.Move(executed_1.PROPVA_INRPROPOS, PROPVA_INRPROPOS);
            }


        }

        [StopWatch]
        /*" M-0100-OPCAOPAGVA-DB-SELECT-8 */
        public void M_0100_OPCAOPAGVA_DB_SELECT_8()
        {
            /*" -2321- EXEC SQL SELECT NUM_APOLICE, CODSUBES INTO :RELATO-NUM-APOLICE, :RELATO-CODSUBES FROM SEGUROS.COBRANCA_MENS_VGAP WHERE IDFORM = 'A4' AND NUM_APOLICE = :PROPVA-NUM-APOLICE AND CODSUBES = :PROPVA-CODSUBES AND COD_OPERACAO = 3 WITH UR END-EXEC */

            var m_0100_OPCAOPAGVA_DB_SELECT_8_Query1 = new M_0100_OPCAOPAGVA_DB_SELECT_8_Query1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
            };

            var executed_1 = M_0100_OPCAOPAGVA_DB_SELECT_8_Query1.Execute(m_0100_OPCAOPAGVA_DB_SELECT_8_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RELATO_NUM_APOLICE, RELATO_NUM_APOLICE);
                _.Move(executed_1.RELATO_CODSUBES, RELATO_CODSUBES);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0101_FIM*/

        [StopWatch]
        /*" M-0100-OPCAOPAGVA-DB-SELECT-9 */
        public void M_0100_OPCAOPAGVA_DB_SELECT_9()
        {
            /*" -2344- EXEC SQL SELECT NUM_APOLICE, CODSUBES INTO :RELATO-NUM-APOLICE, :RELATO-CODSUBES FROM SEGUROS.COBRANCA_MENS_VGAP WHERE IDFORM = 'A4' AND NUM_APOLICE = :PROPVA-NUM-APOLICE AND CODSUBES = :PROPVA-CODSUBES AND COD_OPERACAO = 2 WITH UR END-EXEC */

            var m_0100_OPCAOPAGVA_DB_SELECT_9_Query1 = new M_0100_OPCAOPAGVA_DB_SELECT_9_Query1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
            };

            var executed_1 = M_0100_OPCAOPAGVA_DB_SELECT_9_Query1.Execute(m_0100_OPCAOPAGVA_DB_SELECT_9_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RELATO_NUM_APOLICE, RELATO_NUM_APOLICE);
                _.Move(executed_1.RELATO_CODSUBES, RELATO_CODSUBES);
            }


        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-6 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_6()
        {
            /*" -1862- EXEC SQL SELECT NRCERTIF INTO :V0PARC-NRCERTIF FROM SEGUROS.V0PARCELVA WHERE NRCERTIF = :PROPVA-NRCERTIF AND NRPARCEL = 1 END-EXEC */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PARC_NRCERTIF, V0PARC_NRCERTIF);
            }


        }

        [StopWatch]
        /*" M-0100-OPCAOPAGVA-DB-SELECT-10 */
        public void M_0100_OPCAOPAGVA_DB_SELECT_10()
        {
            /*" -2375- EXEC SQL SELECT NUM_APOLICE, CODSUBES INTO :RELATO-NUM-APOLICE, :RELATO-CODSUBES FROM SEGUROS.COBRANCA_MENS_VGAP WHERE IDFORM = 'A4' AND NUM_APOLICE = :PROPVA-NUM-APOLICE AND CODSUBES = :PROPVA-CODSUBES AND COD_OPERACAO = 5 WITH UR END-EXEC */

            var m_0100_OPCAOPAGVA_DB_SELECT_10_Query1 = new M_0100_OPCAOPAGVA_DB_SELECT_10_Query1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
            };

            var executed_1 = M_0100_OPCAOPAGVA_DB_SELECT_10_Query1.Execute(m_0100_OPCAOPAGVA_DB_SELECT_10_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RELATO_NUM_APOLICE, RELATO_NUM_APOLICE);
                _.Move(executed_1.RELATO_CODSUBES, RELATO_CODSUBES);
            }


        }

        [StopWatch]
        /*" M-0110-FETCH */
        private void M_0110_FETCH(bool isPerform = false)
        {
            /*" -2527- MOVE '0110-FETCH' TO PARAGRAFO. */
            _.Move("0110-FETCH", WABEND.PARAGRAFO);

            /*" -2529- MOVE 'FETCH CPROPVA' TO COMANDO. */
            _.Move("FETCH CPROPVA", WABEND.COMANDO);

            /*" -2571- PERFORM M_0110_FETCH_DB_FETCH_1 */

            M_0110_FETCH_DB_FETCH_1();

            /*" -2575- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2576- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2577- MOVE 1 TO WS-EOF */
                    _.Move(1, WS_WORK_AREAS.WS_EOF);

                    /*" -2578- MOVE 'CLOSE CPROPVA' TO COMANDO */
                    _.Move("CLOSE CPROPVA", WABEND.COMANDO);

                    /*" -2578- PERFORM M_0110_FETCH_DB_CLOSE_1 */

                    M_0110_FETCH_DB_CLOSE_1();

                    /*" -2580- GO TO 0110-FIM */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/ //GOTO
                    return;

                    /*" -2581- ELSE */
                }
                else
                {


                    /*" -2583- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -2584- IF VIND-ORIGEM LESS +0 */

            if (VIND_ORIGEM < +0)
            {

                /*" -2586- MOVE ZEROS TO PROPVA-ORIGEM-PROPOSTA */
                _.Move(0, PROPVA_ORIGEM_PROPOSTA);

                /*" -2588- END-IF. */
            }


            /*" -2589- MOVE 'SELECT MOVIMVGA' TO COMANDO. */
            _.Move("SELECT MOVIMVGA", WABEND.COMANDO);

            /*" -2596- PERFORM M_0110_FETCH_DB_SELECT_1 */

            M_0110_FETCH_DB_SELECT_1();

            /*" -2600- IF SQLCODE EQUAL 100 NEXT SENTENCE */

            if (DB.SQLCODE == 100)
            {

                /*" -2601- ELSE */
            }
            else
            {


                /*" -2602- IF SQLCODE EQUAL ZEROS OR -811 */

                if (DB.SQLCODE.In("00", "-811"))
                {

                    /*" -2603- MOVE 'UPDATE PROPOVA ' TO COMANDO */
                    _.Move("UPDATE PROPOVA ", WABEND.COMANDO);

                    /*" -2607- PERFORM M_0110_FETCH_DB_UPDATE_1 */

                    M_0110_FETCH_DB_UPDATE_1();

                    /*" -2609- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -2610- GO TO 9999-ERRO */

                        M_9999_ERRO(); //GOTO
                        return;

                        /*" -2611- END-IF */
                    }


                    /*" -2612- GO TO 0110-FETCH */
                    new Task(() => M_0110_FETCH()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -2613- ELSE */
                }
                else
                {


                    /*" -2615- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -2616- MOVE PROPVA-NRCERTIF TO W-NUM-PROPOSTA. */
            _.Move(PROPVA_NRCERTIF, WS_WORK_AREAS.W_NUM_PROPOSTA);

            /*" -2617- MOVE PROPVA-DTPROXVEN TO PROPVA-DTPROXVEN-S. */
            _.Move(PROPVA_DTPROXVEN, PROPVA_DTPROXVEN_S);

            /*" -2619- MOVE PROPVA-DTPROXVEN TO WS-PROPVA-DTPROXVEN. */
            _.Move(PROPVA_DTPROXVEN, WS_PROPVA_DTPROXVEN);

            /*" -2620- MOVE PROPVA-NUM-APOLICE TO WS-NUM-APOLICE. */
            _.Move(PROPVA_NUM_APOLICE, WS_WORK_AREAS.WS_CHAVE.WS_NUM_APOLICE);

            /*" -2622- MOVE PROPVA-CODSUBES TO WS-CODSUBES. */
            _.Move(PROPVA_CODSUBES, WS_WORK_AREAS.WS_CHAVE.WS_CODSUBES);

            /*" -2623- IF PROPVA-CODOPER EQUAL ZEROS */

            if (PROPVA_CODOPER == 00)
            {

                /*" -2625- MOVE 101 TO PROPVA-CODOPER. */
                _.Move(101, PROPVA_CODOPER);
            }


            /*" -2626- IF VIND-FAIXA-RENDA LESS +0 */

            if (VIND_FAIXA_RENDA < +0)
            {

                /*" -2628- MOVE '0' TO PROPVA-FAIXA-RENDA-IND. */
                _.Move("0", PROPVA_FAIXA_RENDA_IND);
            }


            /*" -2630- PERFORM 1500-SELECT-PRODUTOSVG THRU 1500-FIM. */

            M_1500_SELECT_PRODUTOSVG(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1500_FIM*/


            /*" -2633- IF PRODVG-ORIG-PRODU = 'PAREN' OR 'CEF DEB CC' AND PROPVA-SITUACAO = '0' AND PROPVA-DTPROXVEN = '9999-12-31' */

            if (PRODVG_ORIG_PRODU.In("PAREN", "CEF DEB CC") && PROPVA_SITUACAO == "0" && PROPVA_DTPROXVEN == "9999-12-31")
            {

                /*" -2640- MOVE '7' TO PROPVA-SITUACAO. */
                _.Move("7", PROPVA_SITUACAO);
            }


            /*" -2641- IF PROPVA-SITUACAO = '7' */

            if (PROPVA_SITUACAO == "7")
            {

                /*" -2642- MOVE 0 TO WS-COUNT */
                _.Move(0, WS_WORK_AREAS.WS_COUNT);

                /*" -2643- MOVE PROPVA-DATA TO WHOST-PROXIMA-DATA */
                _.Move(PROPVA_DATA, WHOST_PROXIMA_DATA);

                /*" -2646- PERFORM 0120-00-CALCULA-POSTAGEM THRU 0120-99-SAIDA UNTIL WS-COUNT EQUAL 2 */

                while (!(WS_WORK_AREAS.WS_COUNT == 2))
                {

                    M_0120_00_CALCULA_POSTAGEM(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0120_99_SAIDA*/

                }

                /*" -2648- IF PROPVA-SITUACAO = '0' AND PRODVG-ORIG-PRODU = 'CEF DEB CC' */

                if (PROPVA_SITUACAO == "0" && PRODVG_ORIG_PRODU == "CEF DEB CC")
                {

                    /*" -2650- GO TO 0110-FIM. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/ //GOTO
                    return;
                }

            }


            /*" -2652- MOVE 0 TO WS-COUNT. */
            _.Move(0, WS_WORK_AREAS.WS_COUNT);

            /*" -2654- MOVE PROPVA-DATA TO WHOST-PROXIMA-DATA */
            _.Move(PROPVA_DATA, WHOST_PROXIMA_DATA);

            /*" -2669- PERFORM 0120-00-CALCULA-POSTAGEM THRU 0120-99-SAIDA UNTIL WS-COUNT EQUAL 2. */

            while (!(WS_WORK_AREAS.WS_COUNT == 2))
            {

                M_0120_00_CALCULA_POSTAGEM(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0120_99_SAIDA*/

            }

            /*" -2670- IF PROPVA-NUM-APOLICE NOT EQUAL WS-NUM-APOLICE-ANT1 */

            if (PROPVA_NUM_APOLICE != WS_NUM_APOLICE_ANT1)
            {

                /*" -2671- MOVE PROPVA-NUM-APOLICE TO WS-NUM-APOLICE-ANT1 */
                _.Move(PROPVA_NUM_APOLICE, WS_NUM_APOLICE_ANT1);

                /*" -2673- MOVE 'SELECT V1APOLICE' TO COMANDO */
                _.Move("SELECT V1APOLICE", WABEND.COMANDO);

                /*" -2679- PERFORM M_0110_FETCH_DB_SELECT_2 */

                M_0110_FETCH_DB_SELECT_2();

                /*" -2682- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -2683- DISPLAY 'ERRO SELECT SEGUROS.V0APOLICE ' */
                    _.Display($"ERRO SELECT SEGUROS.V0APOLICE ");

                    /*" -2684- DISPLAY 'APOLICE = ' PROPVA-NUM-APOLICE */
                    _.Display($"APOLICE = {PROPVA_NUM_APOLICE}");

                    /*" -2684- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-0110-FETCH-DB-FETCH-1 */
        public void M_0110_FETCH_DB_FETCH_1()
        {
            /*" -2571- EXEC SQL FETCH CPROPVA INTO :PROPVA-NUM-APOLICE, :PROPVA-CODSUBES, :PROPVA-NRCERTIF, :PROPVA-CODPRODU, :PROPVA-CODCLIEN, :PROPVA-OCOREND, :PROPVA-FONTE, :PROPVA-AGECOBR, :PROPVA-OPCAO-COBER, :PROPVA-DTQITBCO, :PROPVA-DTINICDG, :PROPVA-DTINISAF, :PROPVA-DTPROXVEN, :PROPVA-DTMINVEN, :PROPVA-NRMATRVEN, :PROPVA-CODOPER, :PROPVA-DTMOVTO, :PROPVA-SITUACAO, :PROPVA-NUM-APOLICE, :PROPVA-CODSUBES, :PROPVA-OCORHIST, :PROPVA-NRPARCEL, :PROPVA-SIT-INTERF, :PROPVA-TIMESTAMP, :PROPVA-IDADE, :PROPVA-SEXO, :PROPVA-EST-CIV, :PROPVA-COD-CRM:VIND-COD-CRM, :PROPVA-NRMATRFUN:PROPVA-INRMATRFUN, :PROPVA-DTADMIS:PROPVA-IDTADMIS, :PROPVA-NRPROPOS:PROPVA-INRPROPOS, :PROPVA-CODCCT:PROPVA-ICODCCT, :PROPVA-CODUSU, :PROPVA-DTVENCTO, :PROPVA-FAIXA-RENDA-IND:VIND-FAIXA-RENDA, :PROPVA-DATA, :PROPVA-DPS-TITULAR, :PROPVA-ORIGEM-PROPOSTA:VIND-ORIGEM, :PROPVA-ACATAMENTO, :PROPVA-COD-OPER-CREDITO END-EXEC. */

            if (CPROPVA.Fetch())
            {
                _.Move(CPROPVA.PROPVA_NUM_APOLICE, PROPVA_NUM_APOLICE);
                _.Move(CPROPVA.PROPVA_CODSUBES, PROPVA_CODSUBES);
                _.Move(CPROPVA.PROPVA_NRCERTIF, PROPVA_NRCERTIF);
                _.Move(CPROPVA.PROPVA_CODPRODU, PROPVA_CODPRODU);
                _.Move(CPROPVA.PROPVA_CODCLIEN, PROPVA_CODCLIEN);
                _.Move(CPROPVA.PROPVA_OCOREND, PROPVA_OCOREND);
                _.Move(CPROPVA.PROPVA_FONTE, PROPVA_FONTE);
                _.Move(CPROPVA.PROPVA_AGECOBR, PROPVA_AGECOBR);
                _.Move(CPROPVA.PROPVA_OPCAO_COBER, PROPVA_OPCAO_COBER);
                _.Move(CPROPVA.PROPVA_DTQITBCO, PROPVA_DTQITBCO);
                _.Move(CPROPVA.PROPVA_DTINICDG, PROPVA_DTINICDG);
                _.Move(CPROPVA.PROPVA_DTINISAF, PROPVA_DTINISAF);
                _.Move(CPROPVA.PROPVA_DTPROXVEN, PROPVA_DTPROXVEN);
                _.Move(CPROPVA.PROPVA_DTMINVEN, PROPVA_DTMINVEN);
                _.Move(CPROPVA.PROPVA_NRMATRVEN, PROPVA_NRMATRVEN);
                _.Move(CPROPVA.PROPVA_CODOPER, PROPVA_CODOPER);
                _.Move(CPROPVA.PROPVA_DTMOVTO, PROPVA_DTMOVTO);
                _.Move(CPROPVA.PROPVA_SITUACAO, PROPVA_SITUACAO);
                _.Move(CPROPVA.PROPVA_NUM_APOLICE, PROPVA_NUM_APOLICE);
                _.Move(CPROPVA.PROPVA_CODSUBES, PROPVA_CODSUBES);
                _.Move(CPROPVA.PROPVA_OCORHIST, PROPVA_OCORHIST);
                _.Move(CPROPVA.PROPVA_NRPARCEL, PROPVA_NRPARCEL);
                _.Move(CPROPVA.PROPVA_SIT_INTERF, PROPVA_SIT_INTERF);
                _.Move(CPROPVA.PROPVA_TIMESTAMP, PROPVA_TIMESTAMP);
                _.Move(CPROPVA.PROPVA_IDADE, PROPVA_IDADE);
                _.Move(CPROPVA.PROPVA_SEXO, PROPVA_SEXO);
                _.Move(CPROPVA.PROPVA_EST_CIV, PROPVA_EST_CIV);
                _.Move(CPROPVA.PROPVA_COD_CRM, PROPVA_COD_CRM);
                _.Move(CPROPVA.VIND_COD_CRM, VIND_COD_CRM);
                _.Move(CPROPVA.PROPVA_NRMATRFUN, PROPVA_NRMATRFUN);
                _.Move(CPROPVA.PROPVA_INRMATRFUN, PROPVA_INRMATRFUN);
                _.Move(CPROPVA.PROPVA_DTADMIS, PROPVA_DTADMIS);
                _.Move(CPROPVA.PROPVA_IDTADMIS, PROPVA_IDTADMIS);
                _.Move(CPROPVA.PROPVA_NRPROPOS, PROPVA_NRPROPOS);
                _.Move(CPROPVA.PROPVA_INRPROPOS, PROPVA_INRPROPOS);
                _.Move(CPROPVA.PROPVA_CODCCT, PROPVA_CODCCT);
                _.Move(CPROPVA.PROPVA_ICODCCT, PROPVA_ICODCCT);
                _.Move(CPROPVA.PROPVA_CODUSU, PROPVA_CODUSU);
                _.Move(CPROPVA.PROPVA_DTVENCTO, PROPVA_DTVENCTO);
                _.Move(CPROPVA.PROPVA_FAIXA_RENDA_IND, PROPVA_FAIXA_RENDA_IND);
                _.Move(CPROPVA.VIND_FAIXA_RENDA, VIND_FAIXA_RENDA);
                _.Move(CPROPVA.PROPVA_DATA, PROPVA_DATA);
                _.Move(CPROPVA.PROPVA_DPS_TITULAR, PROPVA_DPS_TITULAR);
                _.Move(CPROPVA.PROPVA_ORIGEM_PROPOSTA, PROPVA_ORIGEM_PROPOSTA);
                _.Move(CPROPVA.VIND_ORIGEM, VIND_ORIGEM);
                _.Move(CPROPVA.PROPVA_ACATAMENTO, PROPVA_ACATAMENTO);
                _.Move(CPROPVA.PROPVA_COD_OPER_CREDITO, PROPVA_COD_OPER_CREDITO);
            }

        }

        [StopWatch]
        /*" M-0110-FETCH-DB-CLOSE-1 */
        public void M_0110_FETCH_DB_CLOSE_1()
        {
            /*" -2578- EXEC SQL CLOSE CPROPVA END-EXEC */

            CPROPVA.Close();

        }

        [StopWatch]
        /*" M-0110-FETCH-DB-SELECT-1 */
        public void M_0110_FETCH_DB_SELECT_1()
        {
            /*" -2596- EXEC SQL SELECT DATA_MOVIMENTO INTO :WHOST-DATA-MOVIMENTO FROM SEGUROS.MOVIMENTO_VGAP WHERE NUM_CERTIFICADO = :PROPVA-NRCERTIF AND COD_OPERACAO = 101 WITH UR END-EXEC. */

            var m_0110_FETCH_DB_SELECT_1_Query1 = new M_0110_FETCH_DB_SELECT_1_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = M_0110_FETCH_DB_SELECT_1_Query1.Execute(m_0110_FETCH_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DATA_MOVIMENTO, WHOST_DATA_MOVIMENTO);
            }


        }

        [StopWatch]
        /*" M-0110-FETCH-DB-UPDATE-1 */
        public void M_0110_FETCH_DB_UPDATE_1()
        {
            /*" -2607- EXEC SQL UPDATE SEGUROS.PROPOSTAS_VA SET SIT_REGISTRO = '3' WHERE NUM_CERTIFICADO = :PROPVA-NRCERTIF END-EXEC */

            var m_0110_FETCH_DB_UPDATE_1_Update1 = new M_0110_FETCH_DB_UPDATE_1_Update1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            M_0110_FETCH_DB_UPDATE_1_Update1.Execute(m_0110_FETCH_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-0100-OPCAOPAGVA-DB-SELECT-11 */
        public void M_0100_OPCAOPAGVA_DB_SELECT_11()
        {
            /*" -2398- EXEC SQL SELECT NUM_APOLICE, CODSUBES INTO :RELATO-NUM-APOLICE, :RELATO-CODSUBES FROM SEGUROS.COBRANCA_MENS_VGAP WHERE IDFORM = 'A4' AND NUM_APOLICE = :PROPVA-NUM-APOLICE AND CODSUBES = :PROPVA-CODSUBES AND COD_OPERACAO = 2 WITH UR END-EXEC */

            var m_0100_OPCAOPAGVA_DB_SELECT_11_Query1 = new M_0100_OPCAOPAGVA_DB_SELECT_11_Query1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
            };

            var executed_1 = M_0100_OPCAOPAGVA_DB_SELECT_11_Query1.Execute(m_0100_OPCAOPAGVA_DB_SELECT_11_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RELATO_NUM_APOLICE, RELATO_NUM_APOLICE);
                _.Move(executed_1.RELATO_CODSUBES, RELATO_CODSUBES);
            }


        }

        [StopWatch]
        /*" M-0110-FETCH-DB-SELECT-2 */
        public void M_0110_FETCH_DB_SELECT_2()
        {
            /*" -2679- EXEC SQL SELECT RAMO INTO :V1APOL-RAMO FROM SEGUROS.V0APOLICE WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE WITH UR END-EXEC */

            var m_0110_FETCH_DB_SELECT_2_Query1 = new M_0110_FETCH_DB_SELECT_2_Query1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
            };

            var executed_1 = M_0110_FETCH_DB_SELECT_2_Query1.Execute(m_0110_FETCH_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1APOL_RAMO, V1APOL_RAMO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/

        [StopWatch]
        /*" M-0120-00-CALCULA-POSTAGEM */
        private void M_0120_00_CALCULA_POSTAGEM(bool isPerform = false)
        {
            /*" -2693- MOVE '0120-00-CALCULA ' TO COMANDO. */
            _.Move("0120-00-CALCULA ", WABEND.COMANDO);

            /*" -2695- PERFORM 0130-00-CALCULA-DIA-UTIL THRU 0130-99-SAIDA. */

            M_0130_00_CALCULA_DIA_UTIL(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0130_99_SAIDA*/


            /*" -2699- IF CALENDAR-DIA-SEMANA EQUAL 'S' OR CALENDAR-DIA-SEMANA EQUAL 'D' OR CALENDAR-FERIADO EQUAL 'N' NEXT SENTENCE */

            if (CALENDAR_DIA_SEMANA == "S" || CALENDAR_DIA_SEMANA == "D" || CALENDAR_FERIADO == "N")
            {

                /*" -2700- ELSE */
            }
            else
            {


                /*" -2701- ADD 1 TO WS-COUNT */
                WS_WORK_AREAS.WS_COUNT.Value = WS_WORK_AREAS.WS_COUNT + 1;

                /*" -2701- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0120_99_SAIDA*/

        [StopWatch]
        /*" M-0130-00-CALCULA-DIA-UTIL */
        private void M_0130_00_CALCULA_DIA_UTIL(bool isPerform = false)
        {
            /*" -2711- MOVE '0130-00-CALCULA ' TO COMANDO. */
            _.Move("0130-00-CALCULA ", WABEND.COMANDO);

            /*" -2727- PERFORM M_0130_00_CALCULA_DIA_UTIL_DB_SELECT_1 */

            M_0130_00_CALCULA_DIA_UTIL_DB_SELECT_1();

            /*" -2730- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2734- DISPLAY 'VP0121B - PROBLEMAS SELECT CALENDARIO' */
                _.Display($"VP0121B - PROBLEMAS SELECT CALENDARIO");

                /*" -2734- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0130-00-CALCULA-DIA-UTIL-DB-SELECT-1 */
        public void M_0130_00_CALCULA_DIA_UTIL_DB_SELECT_1()
        {
            /*" -2727- EXEC SQL SELECT DATA_CALENDARIO, (DATA_CALENDARIO + 1 DAY), DIA_SEMANA, FERIADO INTO :CALENDAR-DATA-CALENDARIO, :WHOST-PROXIMA-DATA, :CALENDAR-DIA-SEMANA, :CALENDAR-FERIADO FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO >= :WHOST-PROXIMA-DATA AND DATA_CALENDARIO <= :WHOST-PROXIMA-DATA WITH UR END-EXEC. */

            var m_0130_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1 = new M_0130_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1()
            {
                WHOST_PROXIMA_DATA = WHOST_PROXIMA_DATA.ToString(),
            };

            var executed_1 = M_0130_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1.Execute(m_0130_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CALENDAR_DATA_CALENDARIO, CALENDAR_DATA_CALENDARIO);
                _.Move(executed_1.WHOST_PROXIMA_DATA, WHOST_PROXIMA_DATA);
                _.Move(executed_1.CALENDAR_DIA_SEMANA, CALENDAR_DIA_SEMANA);
                _.Move(executed_1.CALENDAR_FERIADO, CALENDAR_FERIADO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0130_99_SAIDA*/

        [StopWatch]
        /*" M-0200-SOLICITA-CERTIFICADO */
        private void M_0200_SOLICITA_CERTIFICADO(bool isPerform = false)
        {
            /*" -2745- MOVE '0200-SOLICITA-CERTIFICADO' TO PARAGRAFO. */
            _.Move("0200-SOLICITA-CERTIFICADO", WABEND.PARAGRAFO);

            /*" -2747- MOVE 'INSERT V0RELATORIOS' TO COMANDO. */
            _.Move("INSERT V0RELATORIOS", WABEND.COMANDO);

            /*" -2749- IF PROPVA-NUM-APOLICE EQUAL 109300000709 */

            if (PROPVA_NUM_APOLICE == 109300000709)
            {

                /*" -2750- GO TO 0200-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0200_FIM*/ //GOTO
                return;

                /*" -2753- END-IF */
            }


            /*" -2757- IF PROPVA-NUM-APOLICE EQUAL 107700000011 OR PROPVA-NUM-APOLICE EQUAL 107700000014 OR PROPVA-NUM-APOLICE EQUAL 107700000067 OR PROPVA-NUM-APOLICE EQUAL 107700000068 */

            if (PROPVA_NUM_APOLICE == 107700000011 || PROPVA_NUM_APOLICE == 107700000014 || PROPVA_NUM_APOLICE == 107700000067 || PROPVA_NUM_APOLICE == 107700000068)
            {

                /*" -2758- GO TO 0200-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0200_FIM*/ //GOTO
                return;

                /*" -2763- END-IF */
            }


            /*" -2764- IF PROPVA-NUM-APOLICE EQUAL 107700000024 */

            if (PROPVA_NUM_APOLICE == 107700000024)
            {

                /*" -2765- MOVE '1' TO WS-SIT-REGISTRO */
                _.Move("1", WS_WORK_AREAS.WS_SIT_REGISTRO);

                /*" -2766- ELSE */
            }
            else
            {


                /*" -2767- MOVE '0' TO WS-SIT-REGISTRO */
                _.Move("0", WS_WORK_AREAS.WS_SIT_REGISTRO);

                /*" -2769- END-IF */
            }


            /*" -2812- PERFORM M_0200_SOLICITA_CERTIFICADO_DB_INSERT_1 */

            M_0200_SOLICITA_CERTIFICADO_DB_INSERT_1();

            /*" -2815- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2815- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0200-SOLICITA-CERTIFICADO-DB-INSERT-1 */
        public void M_0200_SOLICITA_CERTIFICADO_DB_INSERT_1()
        {
            /*" -2812- EXEC SQL INSERT INTO SEGUROS.V0RELATORIOS VALUES ( 'VP0121B' , CURRENT DATE, 'VA' , :RELATO-CODRELAT, 0, 0, CURRENT DATE, CURRENT DATE, CURRENT DATE, 0, 0, 0, 0, 0, 0, 0, 0, :PROPVA-NUM-APOLICE, 0, :RELATO-NRPARCEL, :PROPVA-NRCERTIF, 0, :PROPVA-CODSUBES, :RELATO-OPERACAO, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , :WS-SIT-REGISTRO, ' ' , ' ' , NULL, 0, 0, CURRENT TIMESTAMP) END-EXEC. */

            var m_0200_SOLICITA_CERTIFICADO_DB_INSERT_1_Insert1 = new M_0200_SOLICITA_CERTIFICADO_DB_INSERT_1_Insert1()
            {
                RELATO_CODRELAT = RELATO_CODRELAT.ToString(),
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                RELATO_NRPARCEL = RELATO_NRPARCEL.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
                RELATO_OPERACAO = RELATO_OPERACAO.ToString(),
                WS_SIT_REGISTRO = WS_WORK_AREAS.WS_SIT_REGISTRO.ToString(),
            };

            M_0200_SOLICITA_CERTIFICADO_DB_INSERT_1_Insert1.Execute(m_0200_SOLICITA_CERTIFICADO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0200_FIM*/

        [StopWatch]
        /*" M-0300-VERIFICA-CROT */
        private void M_0300_VERIFICA_CROT(bool isPerform = false)
        {
            /*" -2826- MOVE '0300-VERIFICA-CROT' TO PARAGRAFO. */
            _.Move("0300-VERIFICA-CROT", WABEND.PARAGRAFO);

            /*" -2829- MOVE 'SELECT V0CLIENTE' TO COMANDO. */
            _.Move("SELECT V0CLIENTE", WABEND.COMANDO);

            /*" -2835- PERFORM M_0300_VERIFICA_CROT_DB_SELECT_1 */

            M_0300_VERIFICA_CROT_DB_SELECT_1();

            /*" -2838- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2839- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -2841- END-IF */
            }


            /*" -2844- MOVE 'SELECT V1CLIENTE_CROT' TO COMANDO. */
            _.Move("SELECT V1CLIENTE_CROT", WABEND.COMANDO);

            /*" -2849- PERFORM M_0300_VERIFICA_CROT_DB_SELECT_2 */

            M_0300_VERIFICA_CROT_DB_SELECT_2();

            /*" -2852- IF SQLCODE NOT = 000 AND +100 */

            if (!DB.SQLCODE.In("000", "+100"))
            {

                /*" -2854- DISPLAY 'VP0121B-0300 PROBLEMAS SELECT V1CLIENTE_CROT' ' CGCCPF = ' CLIENT-CGCCPF */

                $"VP0121B-0300 PROBLEMAS SELECT V1CLIENTE_CROT CGCCPF = {CLIENT_CGCCPF}"
                .Display();

                /*" -2855- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -2857- END-IF */
            }


            /*" -2858- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2859- PERFORM 0320-UPDATE-CROT THRU 0320-FIM */

                M_0320_UPDATE_CROT(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0320_FIM*/


                /*" -2860- ELSE */
            }
            else
            {


                /*" -2861- PERFORM 0330-INCLUI-CROT THRU 0330-FIM */

                M_0330_INCLUI_CROT(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0330_FIM*/


                /*" -2862- END-IF */
            }


            /*" -2862- . */

        }

        [StopWatch]
        /*" M-0300-VERIFICA-CROT-DB-SELECT-1 */
        public void M_0300_VERIFICA_CROT_DB_SELECT_1()
        {
            /*" -2835- EXEC SQL SELECT CGCCPF INTO :CLIENT-CGCCPF FROM SEGUROS.V0CLIENTE WHERE COD_CLIENTE = :PROPVA-CODCLIEN WITH UR END-EXEC. */

            var m_0300_VERIFICA_CROT_DB_SELECT_1_Query1 = new M_0300_VERIFICA_CROT_DB_SELECT_1_Query1()
            {
                PROPVA_CODCLIEN = PROPVA_CODCLIEN.ToString(),
            };

            var executed_1 = M_0300_VERIFICA_CROT_DB_SELECT_1_Query1.Execute(m_0300_VERIFICA_CROT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENT_CGCCPF, CLIENT_CGCCPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0300_FIM*/

        [StopWatch]
        /*" M-0300-VERIFICA-CROT-DB-SELECT-2 */
        public void M_0300_VERIFICA_CROT_DB_SELECT_2()
        {
            /*" -2849- EXEC SQL SELECT DTMOVABE INTO :CLIROT-DTMOVABE FROM SEGUROS.V1CLIENTE_CROT WHERE CGCCPF = :CLIENT-CGCCPF END-EXEC. */

            var m_0300_VERIFICA_CROT_DB_SELECT_2_Query1 = new M_0300_VERIFICA_CROT_DB_SELECT_2_Query1()
            {
                CLIENT_CGCCPF = CLIENT_CGCCPF.ToString(),
            };

            var executed_1 = M_0300_VERIFICA_CROT_DB_SELECT_2_Query1.Execute(m_0300_VERIFICA_CROT_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIROT_DTMOVABE, CLIROT_DTMOVABE);
            }


        }

        [StopWatch]
        /*" M-0320-UPDATE-CROT */
        private void M_0320_UPDATE_CROT(bool isPerform = false)
        {
            /*" -2872- MOVE '0320-UPDATE-CROT' TO PARAGRAFO. */
            _.Move("0320-UPDATE-CROT", WABEND.PARAGRAFO);

            /*" -2875- MOVE 'UPDATE V0CLIENTE_CROT' TO COMANDO. */
            _.Move("UPDATE V0CLIENTE_CROT", WABEND.COMANDO);

            /*" -2876- IF CLIROT-DTMOVABE < SISTEMA-DTMOVABE */

            if (CLIROT_DTMOVABE < SISTEMA_DTMOVABE)
            {

                /*" -2878- MOVE SISTEMA-DTMOVABE TO CLIROT-DTMOVABE. */
                _.Move(SISTEMA_DTMOVABE, CLIROT_DTMOVABE);
            }


            /*" -2883- PERFORM M_0320_UPDATE_CROT_DB_UPDATE_1 */

            M_0320_UPDATE_CROT_DB_UPDATE_1();

            /*" -2886- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2886- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0320-UPDATE-CROT-DB-UPDATE-1 */
        public void M_0320_UPDATE_CROT_DB_UPDATE_1()
        {
            /*" -2883- EXEC SQL UPDATE SEGUROS.V0CLIENTE_CROT SET BILH_VDAZUL = 'S' , DTMOVABE = :CLIROT-DTMOVABE WHERE CGCCPF = :CLIENT-CGCCPF END-EXEC. */

            var m_0320_UPDATE_CROT_DB_UPDATE_1_Update1 = new M_0320_UPDATE_CROT_DB_UPDATE_1_Update1()
            {
                CLIROT_DTMOVABE = CLIROT_DTMOVABE.ToString(),
                CLIENT_CGCCPF = CLIENT_CGCCPF.ToString(),
            };

            M_0320_UPDATE_CROT_DB_UPDATE_1_Update1.Execute(m_0320_UPDATE_CROT_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0320_FIM*/

        [StopWatch]
        /*" M-0330-INCLUI-CROT */
        private void M_0330_INCLUI_CROT(bool isPerform = false)
        {
            /*" -2897- MOVE '0330-INCLUI-CROT' TO PARAGRAFO. */
            _.Move("0330-INCLUI-CROT", WABEND.PARAGRAFO);

            /*" -2900- MOVE 'INSERT V0CLIENTE_CROT' TO COMANDO. */
            _.Move("INSERT V0CLIENTE_CROT", WABEND.COMANDO);

            /*" -2907- PERFORM M_0330_INCLUI_CROT_DB_INSERT_1 */

            M_0330_INCLUI_CROT_DB_INSERT_1();

            /*" -2910- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2910- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0330-INCLUI-CROT-DB-INSERT-1 */
        public void M_0330_INCLUI_CROT_DB_INSERT_1()
        {
            /*" -2907- EXEC SQL INSERT INTO SEGUROS.V0CLIENTE_CROT VALUES (:CLIENT-CGCCPF, 'N' , 'N' , 'S' , :SISTEMA-DTMOVABE) END-EXEC. */

            var m_0330_INCLUI_CROT_DB_INSERT_1_Insert1 = new M_0330_INCLUI_CROT_DB_INSERT_1_Insert1()
            {
                CLIENT_CGCCPF = CLIENT_CGCCPF.ToString(),
                SISTEMA_DTMOVABE = SISTEMA_DTMOVABE.ToString(),
            };

            M_0330_INCLUI_CROT_DB_INSERT_1_Insert1.Execute(m_0330_INCLUI_CROT_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0330_FIM*/

        [StopWatch]
        /*" R0397-00-PROXIMO-FOLHETO */
        private void R0397_00_PROXIMO_FOLHETO(bool isPerform = false)
        {
            /*" -2924- MOVE 'R0397-00-PROXIMO-FOLHETO' TO PARAGRAFO. */
            _.Move("R0397-00-PROXIMO-FOLHETO", WABEND.PARAGRAFO);

            /*" -2927- MOVE SPACES TO COMANDO. */
            _.Move("", WABEND.COMANDO);

            /*" -2928- IF WS-CHAVE-ANT NOT EQUAL WS-CHAVE */

            if (WS_WORK_AREAS.WS_CHAVE_ANT != WS_WORK_AREAS.WS_CHAVE)
            {

                /*" -2929- PERFORM R0398-00-MAX-V0FOLHETO THRU R0398-FIM */

                R0398_00_MAX_V0FOLHETO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0398_FIM*/


                /*" -2931- PERFORM R0399-00-SELECT-V0FOLHETO THRU R0399-FIM */

                R0399_00_SELECT_V0FOLHETO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0399_FIM*/


                /*" -2932- MOVE PROPVA-NUM-APOLICE TO WS-NUM-APOLICE-ANT */
                _.Move(PROPVA_NUM_APOLICE, WS_WORK_AREAS.WS_CHAVE_ANT.WS_NUM_APOLICE_ANT);

                /*" -2932- MOVE PROPVA-CODSUBES TO WS-CODSUBES-ANT. */
                _.Move(PROPVA_CODSUBES, WS_WORK_AREAS.WS_CHAVE_ANT.WS_CODSUBES_ANT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0397_FIM*/

        [StopWatch]
        /*" R0398-00-MAX-V0FOLHETO */
        private void R0398_00_MAX_V0FOLHETO(bool isPerform = false)
        {
            /*" -2946- MOVE 'R0398-00-MAX-V0FOLHETO' TO PARAGRAFO. */
            _.Move("R0398-00-MAX-V0FOLHETO", WABEND.PARAGRAFO);

            /*" -2948- MOVE 'SELECT MAX V0FOLHETO-INFO' TO COMANDO. */
            _.Move("SELECT MAX V0FOLHETO-INFO", WABEND.COMANDO);

            /*" -2953- PERFORM R0398_00_MAX_V0FOLHETO_DB_SELECT_1 */

            R0398_00_MAX_V0FOLHETO_DB_SELECT_1();

            /*" -2956- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2957- DISPLAY 'VP0121B - PROBLEMAS SELECT MAX VFOLHETO' */
                _.Display($"VP0121B - PROBLEMAS SELECT MAX VFOLHETO");

                /*" -2957- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0398-00-MAX-V0FOLHETO-DB-SELECT-1 */
        public void R0398_00_MAX_V0FOLHETO_DB_SELECT_1()
        {
            /*" -2953- EXEC SQL SELECT MAX(DTEMICAR) INTO :V0FOLHM-DTEMICAR FROM SEGUROS.V0FOLHETO_INFO WHERE SITUACAO = '0' END-EXEC. */

            var r0398_00_MAX_V0FOLHETO_DB_SELECT_1_Query1 = new R0398_00_MAX_V0FOLHETO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0398_00_MAX_V0FOLHETO_DB_SELECT_1_Query1.Execute(r0398_00_MAX_V0FOLHETO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0FOLHM_DTEMICAR, V0FOLHM_DTEMICAR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0398_FIM*/

        [StopWatch]
        /*" R0399-00-SELECT-V0FOLHETO */
        private void R0399_00_SELECT_V0FOLHETO(bool isPerform = false)
        {
            /*" -2967- MOVE 'R0399-00-SELECT-FOLHETO' TO PARAGRAFO. */
            _.Move("R0399-00-SELECT-FOLHETO", WABEND.PARAGRAFO);

            /*" -2969- MOVE 'SELECT V0FOLHETO-INFO' TO COMANDO. */
            _.Move("SELECT V0FOLHETO-INFO", WABEND.COMANDO);

            /*" -2977- PERFORM R0399_00_SELECT_V0FOLHETO_DB_SELECT_1 */

            R0399_00_SELECT_V0FOLHETO_DB_SELECT_1();

            /*" -2980- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2982- IF SQLCODE EQUAL -811 NEXT SENTENCE */

                if (DB.SQLCODE == -811)
                {

                    /*" -2983- ELSE */
                }
                else
                {


                    /*" -2984- DISPLAY 'VG0469B - PROBLEMAS SELECT V0FOLHETO' */
                    _.Display($"VG0469B - PROBLEMAS SELECT V0FOLHETO");

                    /*" -2986- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -2987- MOVE V0FOLH-COD-CARTA TO WS-COD-CARTA */
            _.Move(V0FOLH_COD_CARTA, WS_WORK_AREAS.WS_COD_CARTA);

            /*" -2987- MOVE V0FOLH-DTEMICAR TO W-DTEMICAR. */
            _.Move(V0FOLH_DTEMICAR, WS_WORK_AREAS.W_DTEMICAR);

        }

        [StopWatch]
        /*" R0399-00-SELECT-V0FOLHETO-DB-SELECT-1 */
        public void R0399_00_SELECT_V0FOLHETO_DB_SELECT_1()
        {
            /*" -2977- EXEC SQL SELECT COD_CARTA, DTEMICAR INTO :V0FOLH-COD-CARTA, :V0FOLH-DTEMICAR FROM SEGUROS.V0FOLHETO_INFO WHERE DTEMICAR = :V0FOLHM-DTEMICAR AND SITUACAO = '0' END-EXEC. */

            var r0399_00_SELECT_V0FOLHETO_DB_SELECT_1_Query1 = new R0399_00_SELECT_V0FOLHETO_DB_SELECT_1_Query1()
            {
                V0FOLHM_DTEMICAR = V0FOLHM_DTEMICAR.ToString(),
            };

            var executed_1 = R0399_00_SELECT_V0FOLHETO_DB_SELECT_1_Query1.Execute(r0399_00_SELECT_V0FOLHETO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0FOLH_COD_CARTA, V0FOLH_COD_CARTA);
                _.Move(executed_1.V0FOLH_DTEMICAR, V0FOLH_DTEMICAR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0399_FIM*/

        [StopWatch]
        /*" M-0400-GERA-MOV-FOLHETOS */
        private void M_0400_GERA_MOV_FOLHETOS(bool isPerform = false)
        {
            /*" -3003- MOVE '0400-GERA-MOV-FOLHETOS' TO PARAGRAFO. */
            _.Move("0400-GERA-MOV-FOLHETOS", WABEND.PARAGRAFO);

            /*" -3005- MOVE 'INSERT V0FOLHETO' TO COMANDO. */
            _.Move("INSERT V0FOLHETO", WABEND.COMANDO);

            /*" -3006- MOVE PROPVA-CODPRODU TO V0FOLH-COD-PRODUTO */
            _.Move(PROPVA_CODPRODU, V0FOLH_COD_PRODUTO);

            /*" -3007- MOVE PROPVA-NRCERTIF TO V0FOLH-NRCERTIF */
            _.Move(PROPVA_NRCERTIF, V0FOLH_NRCERTIF);

            /*" -3009- MOVE WS-COD-CARTA TO V0FOLH-COD-CARTA */
            _.Move(WS_WORK_AREAS.WS_COD_CARTA, V0FOLH_COD_CARTA);

            /*" -3011- MOVE SISTEMA-DTMOVABE TO V0FOLH-DTSOLICIT. */
            _.Move(SISTEMA_DTMOVABE, V0FOLH_DTSOLICIT);

            /*" -3012- IF W-DDEMICAR > 20 */

            if (WS_WORK_AREAS.FILLER_4.W_DDEMICAR > 20)
            {

                /*" -3014- COMPUTE W-MMEMICAR = W-MMEMICAR + 1 */
                WS_WORK_AREAS.FILLER_4.W_MMEMICAR.Value = WS_WORK_AREAS.FILLER_4.W_MMEMICAR + 1;

                /*" -3015- IF W-MMEMICAR > 12 */

                if (WS_WORK_AREAS.FILLER_4.W_MMEMICAR > 12)
                {

                    /*" -3016- MOVE 1 TO W-MMEMICAR */
                    _.Move(1, WS_WORK_AREAS.FILLER_4.W_MMEMICAR);

                    /*" -3018- ADD 1 TO W-SSEMICAR. */
                    WS_WORK_AREAS.FILLER_4.W_SSEMICAR.Value = WS_WORK_AREAS.FILLER_4.W_SSEMICAR + 1;
                }

            }


            /*" -3020- MOVE 20 TO W-DDEMICAR. */
            _.Move(20, WS_WORK_AREAS.FILLER_4.W_DDEMICAR);

            /*" -3022- MOVE W-DTEMICAR TO V0FOLH-DTEMICAR */
            _.Move(WS_WORK_AREAS.W_DTEMICAR, V0FOLH_DTEMICAR);

            /*" -3023- MOVE 'VP0121B' TO V0FOLH-CODUSU */
            _.Move("VP0121B", V0FOLH_CODUSU);

            /*" -3025- MOVE '0' TO V0FOLH-SITUACAO. */
            _.Move("0", V0FOLH_SITUACAO);

            /*" -3035- PERFORM M_0400_GERA_MOV_FOLHETOS_DB_INSERT_1 */

            M_0400_GERA_MOV_FOLHETOS_DB_INSERT_1();

            /*" -3038- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3040- IF SQLCODE EQUAL -803 NEXT SENTENCE */

                if (DB.SQLCODE == -803)
                {

                    /*" -3041- ELSE */
                }
                else
                {


                    /*" -3042- DISPLAY 'PROBLEMAS INSERT V0FOLHETO_INFO' */
                    _.Display($"PROBLEMAS INSERT V0FOLHETO_INFO");

                    /*" -3043- DISPLAY 'COD-PRODUTO......... ' V0FOLH-COD-PRODUTO */
                    _.Display($"COD-PRODUTO......... {V0FOLH_COD_PRODUTO}");

                    /*" -3044- DISPLAY 'CERTIFCADO.......... ' V0FOLH-NRCERTIF */
                    _.Display($"CERTIFCADO.......... {V0FOLH_NRCERTIF}");

                    /*" -3045- DISPLAY 'COD-CARTA........... ' V0FOLH-COD-CARTA */
                    _.Display($"COD-CARTA........... {V0FOLH_COD_CARTA}");

                    /*" -3046- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -3047- ELSE */
                }

            }
            else
            {


                /*" -3047- ADD 1 TO AC-FOLHETOS. */
                WS_WORK_AREAS.AC_FOLHETOS.Value = WS_WORK_AREAS.AC_FOLHETOS + 1;
            }


        }

        [StopWatch]
        /*" M-0400-GERA-MOV-FOLHETOS-DB-INSERT-1 */
        public void M_0400_GERA_MOV_FOLHETOS_DB_INSERT_1()
        {
            /*" -3035- EXEC SQL INSERT INTO SEGUROS.V0FOLHETO_INFO VALUES (:V0FOLH-COD-PRODUTO, :V0FOLH-NRCERTIF, :V0FOLH-COD-CARTA, :V0FOLH-DTEMICAR, :V0FOLH-DTSOLICIT, :V0FOLH-CODUSU, :V0FOLH-SITUACAO, CURRENT TIMESTAMP) END-EXEC. */

            var m_0400_GERA_MOV_FOLHETOS_DB_INSERT_1_Insert1 = new M_0400_GERA_MOV_FOLHETOS_DB_INSERT_1_Insert1()
            {
                V0FOLH_COD_PRODUTO = V0FOLH_COD_PRODUTO.ToString(),
                V0FOLH_NRCERTIF = V0FOLH_NRCERTIF.ToString(),
                V0FOLH_COD_CARTA = V0FOLH_COD_CARTA.ToString(),
                V0FOLH_DTEMICAR = V0FOLH_DTEMICAR.ToString(),
                V0FOLH_DTSOLICIT = V0FOLH_DTSOLICIT.ToString(),
                V0FOLH_CODUSU = V0FOLH_CODUSU.ToString(),
                V0FOLH_SITUACAO = V0FOLH_SITUACAO.ToString(),
            };

            M_0400_GERA_MOV_FOLHETOS_DB_INSERT_1_Insert1.Execute(m_0400_GERA_MOV_FOLHETOS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0400_FIM*/

        [StopWatch]
        /*" M-1000-INTEGRA-MULTIPREMIADO */
        private void M_1000_INTEGRA_MULTIPREMIADO(bool isPerform = false)
        {
            /*" -3062- MOVE '1000-INTEGRA-MULT' TO COMANDO. */
            _.Move("1000-INTEGRA-MULT", WABEND.COMANDO);

            /*" -3063- MOVE PROPVA-DTQITBCO TO W01DTSQL. */
            _.Move(PROPVA_DTQITBCO, WS_WORK_AREAS.W01DTSQL);

            /*" -3069- MOVE W01DTSQL TO MDTMOVTO. */
            _.Move(WS_WORK_AREAS.W01DTSQL, MDTMOVTO);

            /*" -3071- IF PROPVA-CODPRODU NOT = 7732 AND JVPRD7732 AND 7733 AND JVPRD7733 */

            if (!PROPVA_CODPRODU.In("7732", JVBKINCL.JV_PRODUTOS.JVPRD7732.ToString(), "7733", JVBKINCL.JV_PRODUTOS.JVPRD7733.ToString()))
            {

                /*" -3072- IF PROPVA-DTPROXVEN < PROPVA-DTMINVEN */

                if (PROPVA_DTPROXVEN < PROPVA_DTMINVEN)
                {

                    /*" -3073- MOVE PROPVA-DTPROXVEN TO W01DTSQL */
                    _.Move(PROPVA_DTPROXVEN, WS_WORK_AREAS.W01DTSQL);

                    /*" -3074- ADD 1 TO W01MMSQL */
                    WS_WORK_AREAS.W01DTSQL_R.W01MMSQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01MMSQL + 1;

                    /*" -3075- IF W01MMSQL > 12 */

                    if (WS_WORK_AREAS.W01DTSQL_R.W01MMSQL > 12)
                    {

                        /*" -3076- MOVE 01 TO W01MMSQL */
                        _.Move(01, WS_WORK_AREAS.W01DTSQL_R.W01MMSQL);

                        /*" -3077- COMPUTE W01AASQL = W01AASQL + 1 */
                        WS_WORK_AREAS.W01DTSQL_R.W01AASQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01AASQL + 1;

                        /*" -3078- END-IF */
                    }


                    /*" -3079- MOVE W01DTSQL TO PROPVA-DTPROXVEN */
                    _.Move(WS_WORK_AREAS.W01DTSQL, PROPVA_DTPROXVEN);

                    /*" -3080- END-IF */
                }


                /*" -3080- END-IF. */
            }


        }

        [StopWatch]
        /*" M-1000-AJUSTA-DTPROXVEN */
        private void M_1000_AJUSTA_DTPROXVEN(bool isPerform = false)
        {
            /*" -3090- IF PROPVA-CODPRODU NOT = 7732 AND JVPRD7732 AND 7733 AND JVPRD7733 */

            if (!PROPVA_CODPRODU.In("7732", JVBKINCL.JV_PRODUTOS.JVPRD7732.ToString(), "7733", JVBKINCL.JV_PRODUTOS.JVPRD7733.ToString()))
            {

                /*" -3091- IF PROPVA-DTPROXVEN < W04DTSQL */

                if (PROPVA_DTPROXVEN < WS_WORK_AREAS.W04DTSQL)
                {

                    /*" -3092- MOVE PROPVA-DTPROXVEN TO W01DTSQL */
                    _.Move(PROPVA_DTPROXVEN, WS_WORK_AREAS.W01DTSQL);

                    /*" -3093- ADD 1 TO W01MMSQL */
                    WS_WORK_AREAS.W01DTSQL_R.W01MMSQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01MMSQL + 1;

                    /*" -3094- IF W01MMSQL > 12 */

                    if (WS_WORK_AREAS.W01DTSQL_R.W01MMSQL > 12)
                    {

                        /*" -3095- MOVE 01 TO W01MMSQL */
                        _.Move(01, WS_WORK_AREAS.W01DTSQL_R.W01MMSQL);

                        /*" -3096- COMPUTE W01AASQL = W01AASQL + 1 */
                        WS_WORK_AREAS.W01DTSQL_R.W01AASQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01AASQL + 1;

                        /*" -3097- END-IF */
                    }


                    /*" -3098- MOVE W01DTSQL TO PROPVA-DTPROXVEN */
                    _.Move(WS_WORK_AREAS.W01DTSQL, PROPVA_DTPROXVEN);

                    /*" -3099- GO TO 1000-AJUSTA-DTPROXVEN */
                    new Task(() => M_1000_AJUSTA_DTPROXVEN()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -3100- END-IF */
                }


                /*" -3101- END-IF */
            }


            /*" -3103- MOVE 0 TO MAGENCIADOR MNUM-MATRICULA. */
            _.Move(0, MAGENCIADOR, MNUM_MATRICULA);

            /*" -3105- MOVE '4' TO MTPINCLUS. */
            _.Move("4", MTPINCLUS);

            /*" -3105- PERFORM 8000-INTEGRA-VG THRU 8000-FIM. */

            M_8000_INTEGRA_VG(true);

            R8000_PROPAUTOM(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8000_FIM*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1000_FIM*/

        [StopWatch]
        /*" M-1100-INTEGRA-VIDAZUL */
        private void M_1100_INTEGRA_VIDAZUL(bool isPerform = false)
        {
            /*" -3120- MOVE '1100-INTEGRA-VID' TO COMANDO. */
            _.Move("1100-INTEGRA-VID", WABEND.COMANDO);

            /*" -3124- MOVE PROPVA-DTQITBCO TO MDTMOVTO WS-VIGENCIA. */
            _.Move(PROPVA_DTQITBCO, MDTMOVTO, WS_WORK_AREAS.WS_VIGENCIA);

            /*" -3125- IF OPCAOP-PERIPGTO GREATER 12 */

            if (OPCAOP_PERIPGTO > 12)
            {

                /*" -3126- COMPUTE WS-QTDE-ANOS = OPCAOP-PERIPGTO / 12 */
                WS_WORK_AREAS.WS_QTDE_ANOS.Value = OPCAOP_PERIPGTO / 12;

                /*" -3127- COMPUTE WS-VIG-ANO = WS-VIG-ANO + WS-QTDE-ANOS */
                WS_WORK_AREAS.WS_VIGENCIA.WS_VIG_ANO.Value = WS_WORK_AREAS.WS_VIGENCIA.WS_VIG_ANO + WS_WORK_AREAS.WS_QTDE_ANOS;

                /*" -3128- ELSE */
            }
            else
            {


                /*" -3129- IF WS-VIG-MES GREATER 12 */

                if (WS_WORK_AREAS.WS_VIGENCIA.WS_VIG_MES > 12)
                {

                    /*" -3130- SUBTRACT 12 FROM WS-VIG-MES */
                    WS_WORK_AREAS.WS_VIGENCIA.WS_VIG_MES.Value = WS_WORK_AREAS.WS_VIGENCIA.WS_VIG_MES - 12;

                    /*" -3131- ADD 1 TO WS-VIG-ANO */
                    WS_WORK_AREAS.WS_VIGENCIA.WS_VIG_ANO.Value = WS_WORK_AREAS.WS_VIGENCIA.WS_VIG_ANO + 1;

                    /*" -3132- END-IF */
                }


                /*" -3134- END-IF. */
            }


            /*" -3135- MOVE WS-VIGENCIA TO WS-VIGENCIA1. */
            _.Move(WS_WORK_AREAS.WS_VIGENCIA, WS_WORK_AREAS.WS_VIGENCIA1);

            /*" -3137- MOVE OPCAOP-DIA-DEB TO WS-VIG-DIA1. */
            _.Move(OPCAOP_DIA_DEB, WS_WORK_AREAS.WS_VIGENCIA1.WS_VIG_DIA1);

            /*" -3138- IF WS-VIGENCIA1 LESS WS-VIGENCIA */

            if (WS_WORK_AREAS.WS_VIGENCIA1 < WS_WORK_AREAS.WS_VIGENCIA)
            {

                /*" -3139- ADD 1 TO WS-VIG-MES */
                WS_WORK_AREAS.WS_VIGENCIA.WS_VIG_MES.Value = WS_WORK_AREAS.WS_VIGENCIA.WS_VIG_MES + 1;

                /*" -3140- IF WS-VIG-MES GREATER 12 */

                if (WS_WORK_AREAS.WS_VIGENCIA.WS_VIG_MES > 12)
                {

                    /*" -3141- MOVE 1 TO WS-VIG-MES */
                    _.Move(1, WS_WORK_AREAS.WS_VIGENCIA.WS_VIG_MES);

                    /*" -3143- ADD 1 TO WS-VIG-ANO. */
                    WS_WORK_AREAS.WS_VIGENCIA.WS_VIG_ANO.Value = WS_WORK_AREAS.WS_VIGENCIA.WS_VIG_ANO + 1;
                }

            }


            /*" -3144- MOVE OPCAOP-DIA-DEB TO WS-VIG-DIA. */
            _.Move(OPCAOP_DIA_DEB, WS_WORK_AREAS.WS_VIGENCIA.WS_VIG_DIA);

            /*" -3149- MOVE WS-VIGENCIA TO PROPVA-DTPROXVEN. */
            _.Move(WS_WORK_AREAS.WS_VIGENCIA, PROPVA_DTPROXVEN);

        }

        [StopWatch]
        /*" M-1100-AJUSTA-DTPROXVEN */
        private void M_1100_AJUSTA_DTPROXVEN(bool isPerform = false)
        {
            /*" -3153- IF PROPVA-DTPROXVEN < W04DTSQL */

            if (PROPVA_DTPROXVEN < WS_WORK_AREAS.W04DTSQL)
            {

                /*" -3154- MOVE PROPVA-DTPROXVEN TO W01DTSQL */
                _.Move(PROPVA_DTPROXVEN, WS_WORK_AREAS.W01DTSQL);

                /*" -3155- ADD 1 TO W01MMSQL */
                WS_WORK_AREAS.W01DTSQL_R.W01MMSQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01MMSQL + 1;

                /*" -3156- IF W01MMSQL > 12 */

                if (WS_WORK_AREAS.W01DTSQL_R.W01MMSQL > 12)
                {

                    /*" -3157- MOVE 01 TO W01MMSQL */
                    _.Move(01, WS_WORK_AREAS.W01DTSQL_R.W01MMSQL);

                    /*" -3158- COMPUTE W01AASQL = W01AASQL + 1 */
                    WS_WORK_AREAS.W01DTSQL_R.W01AASQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01AASQL + 1;

                    /*" -3162- END-IF */
                }


                /*" -3163- MOVE W01DTSQL TO PROPVA-DTPROXVEN */
                _.Move(WS_WORK_AREAS.W01DTSQL, PROPVA_DTPROXVEN);

                /*" -3165- GO TO 1100-AJUSTA-DTPROXVEN. */
                new Task(() => M_1100_AJUSTA_DTPROXVEN()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -3167- MOVE 0 TO MAGENCIADOR MNUM-MATRICULA. */
            _.Move(0, MAGENCIADOR, MNUM_MATRICULA);

            /*" -3169- MOVE '4' TO MTPINCLUS. */
            _.Move("4", MTPINCLUS);

            /*" -3170- PERFORM 8000-INTEGRA-VG THRU 8000-FIM. */

            M_8000_INTEGRA_VG(true);

            R8000_PROPAUTOM(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8000_FIM*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1100_FIM*/

        [StopWatch]
        /*" M-1110-VERIFICA-RCAP */
        private void M_1110_VERIFICA_RCAP(bool isPerform = false)
        {
            /*" -3179- MOVE SPACES TO WFIM-V1RCAP. */
            _.Move("", WS_WORK_AREAS.WFIM_V1RCAP);

            /*" -3181- MOVE PROPVA-NRMATRVEN TO WHOST-NRMATRVEN */
            _.Move(PROPVA_NRMATRVEN, WHOST_NRMATRVEN);

            /*" -3183- IF PROPVA-CODPRODU = 7708 AND WHOST-NRMATRVEN(1:3) = 756 */

            if (PROPVA_CODPRODU == 7708 && WHOST_NRMATRVEN.Substring(1, 3) == 756)
            {

                /*" -3184- MOVE PROPVA-NRMATRVEN TO CONVER-NUM-PROPOSTA */
                _.Move(PROPVA_NRMATRVEN, CONVER_NUM_PROPOSTA);

                /*" -3185- ELSE */
            }
            else
            {


                /*" -3186- MOVE PROPVA-NRCERTIF TO CONVER-NUM-PROPOSTA */
                _.Move(PROPVA_NRCERTIF, CONVER_NUM_PROPOSTA);

                /*" -3188- END-IF. */
            }


            /*" -3190- MOVE 'SELECT COVERSAO SICOB' TO COMANDO. */
            _.Move("SELECT COVERSAO SICOB", WABEND.COMANDO);

            /*" -3196- PERFORM M_1110_VERIFICA_RCAP_DB_SELECT_1 */

            M_1110_VERIFICA_RCAP_DB_SELECT_1();

            /*" -3199- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3200- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3201- MOVE PROPVA-NRCERTIF TO V0RCAP-NRTIT */
                    _.Move(PROPVA_NRCERTIF, V0RCAP_NRTIT);

                    /*" -3202- ELSE */
                }
                else
                {


                    /*" -3203- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -3204- ELSE */
                }

            }
            else
            {


                /*" -3206- MOVE CONVER-NUM-SICOB TO V0RCAP-NRTIT. */
                _.Move(CONVER_NUM_SICOB, V0RCAP_NRTIT);
            }


            /*" -3209- MOVE 'SELECT V0RCAP        ' TO COMANDO. */
            _.Move("SELECT V0RCAP        ", WABEND.COMANDO);

            /*" -3219- PERFORM M_1110_VERIFICA_RCAP_DB_SELECT_2 */

            M_1110_VERIFICA_RCAP_DB_SELECT_2();

            /*" -3222- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3223- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3224- GO TO FINALIZA-1110-FIM */

                    FINALIZA_1110_FIM(); //GOTO
                    return;

                    /*" -3225- ELSE */
                }
                else
                {


                    /*" -3227- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -3230- MOVE 'SELECT V1RCAPCOMP    ' TO COMANDO. */
            _.Move("SELECT V1RCAPCOMP    ", WABEND.COMANDO);

            /*" -3246- PERFORM M_1110_VERIFICA_RCAP_DB_SELECT_3 */

            M_1110_VERIFICA_RCAP_DB_SELECT_3();

            /*" -3249- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3251- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -3253- PERFORM 1120-BAIXA-RCAP THRU 1120-FIM. */

            M_1120_BAIXA_RCAP(true);

            M_1120_DECLARE_V0RCAPCOMP(true);

            M_1120_FETCH_V0RCAPCOMP(true);

            M_1120_UPDATE_V0RCAPCOMP(true);

            M_1120_INSERT_V0RCAPCOMP(true);

            M_1120_UPDATE_V0AVISOSALDO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1120_FIM*/


            /*" -3255- MOVE 'UPDATE V0RCAP        ' TO COMANDO. */
            _.Move("UPDATE V0RCAP        ", WABEND.COMANDO);

            /*" -3265- PERFORM M_1110_VERIFICA_RCAP_DB_UPDATE_1 */

            M_1110_VERIFICA_RCAP_DB_UPDATE_1();

            /*" -3268- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3269- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-1110-VERIFICA-RCAP-DB-SELECT-1 */
        public void M_1110_VERIFICA_RCAP_DB_SELECT_1()
        {
            /*" -3196- EXEC SQL SELECT NUM_SICOB INTO :CONVER-NUM-SICOB FROM SEGUROS.CONVERSAO_SICOB WHERE NUM_PROPOSTA_SIVPF = :CONVER-NUM-PROPOSTA WITH UR END-EXEC. */

            var m_1110_VERIFICA_RCAP_DB_SELECT_1_Query1 = new M_1110_VERIFICA_RCAP_DB_SELECT_1_Query1()
            {
                CONVER_NUM_PROPOSTA = CONVER_NUM_PROPOSTA.ToString(),
            };

            var executed_1 = M_1110_VERIFICA_RCAP_DB_SELECT_1_Query1.Execute(m_1110_VERIFICA_RCAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONVER_NUM_SICOB, CONVER_NUM_SICOB);
            }


        }

        [StopWatch]
        /*" FINALIZA-1110-FIM */
        private void FINALIZA_1110_FIM(bool isPerform = false)
        {
            /*" -3272- IF PROPVA-CODPRODU = 7708 */

            if (PROPVA_CODPRODU == 7708)
            {

                /*" -3275- MOVE 'UPDATE COVERSAO SICOB' TO COMANDO */
                _.Move("UPDATE COVERSAO SICOB", WABEND.COMANDO);

                /*" -3279- PERFORM FINALIZA_1110_FIM_DB_UPDATE_1 */

                FINALIZA_1110_FIM_DB_UPDATE_1();

                /*" -3283- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -3284- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -3286- END-IF */
                }


                /*" -3291- PERFORM FINALIZA_1110_FIM_DB_UPDATE_2 */

                FINALIZA_1110_FIM_DB_UPDATE_2();

                /*" -3294- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -3294- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" FINALIZA-1110-FIM-DB-UPDATE-1 */
        public void FINALIZA_1110_FIM_DB_UPDATE_1()
        {
            /*" -3279- EXEC SQL UPDATE SEGUROS.CONVERSAO_SICOB SET NUM_PROPOSTA_SIVPF = :PROPVA-NRCERTIF WHERE NUM_PROPOSTA_SIVPF = :CONVER-NUM-PROPOSTA END-EXEC */

            var fINALIZA_1110_FIM_DB_UPDATE_1_Update1 = new FINALIZA_1110_FIM_DB_UPDATE_1_Update1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                CONVER_NUM_PROPOSTA = CONVER_NUM_PROPOSTA.ToString(),
            };

            FINALIZA_1110_FIM_DB_UPDATE_1_Update1.Execute(fINALIZA_1110_FIM_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-1110-VERIFICA-RCAP-DB-SELECT-2 */
        public void M_1110_VERIFICA_RCAP_DB_SELECT_2()
        {
            /*" -3219- EXEC SQL SELECT FONTE, NRRCAP INTO :V0RCAP-FONTE, :V0RCAP-NRRCAP FROM SEGUROS.V0RCAP WHERE NRTIT = :V0RCAP-NRTIT AND OPERACAO >= 100 AND OPERACAO <= 199 AND SITUACAO = '0' END-EXEC. */

            var m_1110_VERIFICA_RCAP_DB_SELECT_2_Query1 = new M_1110_VERIFICA_RCAP_DB_SELECT_2_Query1()
            {
                V0RCAP_NRTIT = V0RCAP_NRTIT.ToString(),
            };

            var executed_1 = M_1110_VERIFICA_RCAP_DB_SELECT_2_Query1.Execute(m_1110_VERIFICA_RCAP_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RCAP_FONTE, V0RCAP_FONTE);
                _.Move(executed_1.V0RCAP_NRRCAP, V0RCAP_NRRCAP);
            }


        }

        [StopWatch]
        /*" FINALIZA-1110-FIM-DB-UPDATE-2 */
        public void FINALIZA_1110_FIM_DB_UPDATE_2()
        {
            /*" -3291- EXEC SQL UPDATE SEGUROS.V0RCAP SET NRCERTIF = :PROPVA-NRCERTIF WHERE FONTE = :V0RCAP-FONTE AND NRRCAP = :V0RCAP-NRRCAP END-EXEC */

            var fINALIZA_1110_FIM_DB_UPDATE_2_Update1 = new FINALIZA_1110_FIM_DB_UPDATE_2_Update1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                V0RCAP_NRRCAP = V0RCAP_NRRCAP.ToString(),
                V0RCAP_FONTE = V0RCAP_FONTE.ToString(),
            };

            FINALIZA_1110_FIM_DB_UPDATE_2_Update1.Execute(fINALIZA_1110_FIM_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" M-1110-VERIFICA-RCAP-DB-UPDATE-1 */
        public void M_1110_VERIFICA_RCAP_DB_UPDATE_1()
        {
            /*" -3265- EXEC SQL UPDATE SEGUROS.V0RCAP SET SITUACAO = '1' , OPERACAO = 220 , NUM_APOLICE = :PROPVA-NUM-APOLICE, NRENDOS = 0, NRPARCEL = 0, TIMESTAMP = CURRENT TIMESTAMP WHERE FONTE = :V0RCAP-FONTE AND NRRCAP = :V0RCAP-NRRCAP END-EXEC. */

            var m_1110_VERIFICA_RCAP_DB_UPDATE_1_Update1 = new M_1110_VERIFICA_RCAP_DB_UPDATE_1_Update1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                V0RCAP_NRRCAP = V0RCAP_NRRCAP.ToString(),
                V0RCAP_FONTE = V0RCAP_FONTE.ToString(),
            };

            M_1110_VERIFICA_RCAP_DB_UPDATE_1_Update1.Execute(m_1110_VERIFICA_RCAP_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1110_FIM*/

        [StopWatch]
        /*" M-1110-VERIFICA-RCAP-DB-SELECT-3 */
        public void M_1110_VERIFICA_RCAP_DB_SELECT_3()
        {
            /*" -3246- EXEC SQL SELECT BCOAVISO , AGEAVISO , NRAVISO , DATARCAP INTO :V1RCAC-BCOAVISO , :V1RCAC-AGEAVISO , :V1RCAC-NRAVISO , :V1RCAC-DATARCAP FROM SEGUROS.V1RCAPCOMP WHERE FONTE = :V0RCAP-FONTE AND NRRCAP = :V0RCAP-NRRCAP AND NRRCAPCO = 0 AND OPERACAO >= 100 AND OPERACAO <= 199 AND SITUACAO = '0' END-EXEC. */

            var m_1110_VERIFICA_RCAP_DB_SELECT_3_Query1 = new M_1110_VERIFICA_RCAP_DB_SELECT_3_Query1()
            {
                V0RCAP_NRRCAP = V0RCAP_NRRCAP.ToString(),
                V0RCAP_FONTE = V0RCAP_FONTE.ToString(),
            };

            var executed_1 = M_1110_VERIFICA_RCAP_DB_SELECT_3_Query1.Execute(m_1110_VERIFICA_RCAP_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1RCAC_BCOAVISO, V1RCAC_BCOAVISO);
                _.Move(executed_1.V1RCAC_AGEAVISO, V1RCAC_AGEAVISO);
                _.Move(executed_1.V1RCAC_NRAVISO, V1RCAC_NRAVISO);
                _.Move(executed_1.V1RCAC_DATARCAP, V1RCAC_DATARCAP);
            }


        }

        [StopWatch]
        /*" M-1120-BAIXA-RCAP */
        private void M_1120_BAIXA_RCAP(bool isPerform = false)
        {
            /*" -3304- MOVE 'DECLARE V0RCAPCOMP   ' TO COMANDO. */
            _.Move("DECLARE V0RCAPCOMP   ", WABEND.COMANDO);

        }

        [StopWatch]
        /*" M-1120-DECLARE-V0RCAPCOMP */
        private void M_1120_DECLARE_V0RCAPCOMP(bool isPerform = false)
        {
            /*" -3328- PERFORM M_1120_DECLARE_V0RCAPCOMP_DB_DECLARE_1 */

            M_1120_DECLARE_V0RCAPCOMP_DB_DECLARE_1();

            /*" -3330- PERFORM M_1120_DECLARE_V0RCAPCOMP_DB_OPEN_1 */

            M_1120_DECLARE_V0RCAPCOMP_DB_OPEN_1();

            /*" -3333- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3334- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-1120-DECLARE-V0RCAPCOMP-DB-OPEN-1 */
        public void M_1120_DECLARE_V0RCAPCOMP_DB_OPEN_1()
        {
            /*" -3330- EXEC SQL OPEN V1RCAPCOMP END-EXEC. */

            V1RCAPCOMP.Open();

        }

        [StopWatch]
        /*" M-8100-MONTA-BENEFICIARIOS-DB-DECLARE-1 */
        public void M_8100_MONTA_BENEFICIARIOS_DB_DECLARE_1()
        {
            /*" -5131- EXEC SQL DECLARE CBENEFP CURSOR FOR SELECT NOMBENEF, GRAUPAR, PCTBENEF FROM SEGUROS.V0BENEFPROPAZ WHERE NRPROPAZ = :PROPVA-NRPROPAZ AND AGELOTE = 0 AND DTLOTE = 0 AND NRLOTE = 0 AND NRSEQLOTE = 0 WITH UR END-EXEC. */
            CBENEFP = new VP0121B_CBENEFP(true);
            string GetQuery_CBENEFP()
            {
                var query = @$"SELECT NOMBENEF
							, 
							GRAUPAR
							, 
							PCTBENEF 
							FROM SEGUROS.V0BENEFPROPAZ 
							WHERE NRPROPAZ = '{PROPVA_NRPROPAZ}' 
							AND AGELOTE = 0 
							AND DTLOTE = 0 
							AND NRLOTE = 0 
							AND NRSEQLOTE = 0";

                return query;
            }
            CBENEFP.GetQueryEvent += GetQuery_CBENEFP;

        }

        [StopWatch]
        /*" M-1120-FETCH-V0RCAPCOMP */
        private void M_1120_FETCH_V0RCAPCOMP(bool isPerform = false)
        {
            /*" -3340- MOVE 'FETCH V1VCAPCOMP     ' TO COMANDO. */
            _.Move("FETCH V1VCAPCOMP     ", WABEND.COMANDO);

            /*" -3355- PERFORM M_1120_FETCH_V0RCAPCOMP_DB_FETCH_1 */

            M_1120_FETCH_V0RCAPCOMP_DB_FETCH_1();

            /*" -3358- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3359- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3359- PERFORM M_1120_FETCH_V0RCAPCOMP_DB_CLOSE_1 */

                    M_1120_FETCH_V0RCAPCOMP_DB_CLOSE_1();

                    /*" -3361- GO TO 1120-FIM */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1120_FIM*/ //GOTO
                    return;

                    /*" -3362- ELSE */
                }
                else
                {


                    /*" -3363- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-1120-FETCH-V0RCAPCOMP-DB-FETCH-1 */
        public void M_1120_FETCH_V0RCAPCOMP_DB_FETCH_1()
        {
            /*" -3355- EXEC SQL FETCH V1RCAPCOMP INTO :V1RCAC-FONTE , :V1RCAC-NRRCAP , :V1RCAC-NRRCAPCO , :V1RCAC-OPERACAO , :V1RCAC-DTMOVTO , :V1RCAC-HORAOPER , :V1RCAC-SITUACAO , :V1RCAC-BCOAVISO , :V1RCAC-AGEAVISO , :V1RCAC-NRAVISO , :V1RCAC-VLRCAP , :V1RCAC-DATARCAP , :V1RCAC-DTCADAST , :V1RCAC-SITCONTB END-EXEC. */

            if (V1RCAPCOMP.Fetch())
            {
                _.Move(V1RCAPCOMP.V1RCAC_FONTE, V1RCAC_FONTE);
                _.Move(V1RCAPCOMP.V1RCAC_NRRCAP, V1RCAC_NRRCAP);
                _.Move(V1RCAPCOMP.V1RCAC_NRRCAPCO, V1RCAC_NRRCAPCO);
                _.Move(V1RCAPCOMP.V1RCAC_OPERACAO, V1RCAC_OPERACAO);
                _.Move(V1RCAPCOMP.V1RCAC_DTMOVTO, V1RCAC_DTMOVTO);
                _.Move(V1RCAPCOMP.V1RCAC_HORAOPER, V1RCAC_HORAOPER);
                _.Move(V1RCAPCOMP.V1RCAC_SITUACAO, V1RCAC_SITUACAO);
                _.Move(V1RCAPCOMP.V1RCAC_BCOAVISO, V1RCAC_BCOAVISO);
                _.Move(V1RCAPCOMP.V1RCAC_AGEAVISO, V1RCAC_AGEAVISO);
                _.Move(V1RCAPCOMP.V1RCAC_NRAVISO, V1RCAC_NRAVISO);
                _.Move(V1RCAPCOMP.V1RCAC_VLRCAP, V1RCAC_VLRCAP);
                _.Move(V1RCAPCOMP.V1RCAC_DATARCAP, V1RCAC_DATARCAP);
                _.Move(V1RCAPCOMP.V1RCAC_DTCADAST, V1RCAC_DTCADAST);
                _.Move(V1RCAPCOMP.V1RCAC_SITCONTB, V1RCAC_SITCONTB);
            }

        }

        [StopWatch]
        /*" M-1120-FETCH-V0RCAPCOMP-DB-CLOSE-1 */
        public void M_1120_FETCH_V0RCAPCOMP_DB_CLOSE_1()
        {
            /*" -3359- EXEC SQL CLOSE V1RCAPCOMP END-EXEC */

            V1RCAPCOMP.Close();

        }

        [StopWatch]
        /*" M-1120-UPDATE-V0RCAPCOMP */
        private void M_1120_UPDATE_V0RCAPCOMP(bool isPerform = false)
        {
            /*" -3368- MOVE 'UPDATE V0RCAPCOMP    ' TO COMANDO. */
            _.Move("UPDATE V0RCAPCOMP    ", WABEND.COMANDO);

            /*" -3378- PERFORM M_1120_UPDATE_V0RCAPCOMP_DB_UPDATE_1 */

            M_1120_UPDATE_V0RCAPCOMP_DB_UPDATE_1();

            /*" -3381- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3382- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-1120-UPDATE-V0RCAPCOMP-DB-UPDATE-1 */
        public void M_1120_UPDATE_V0RCAPCOMP_DB_UPDATE_1()
        {
            /*" -3378- EXEC SQL UPDATE SEGUROS.V0RCAPCOMP SET SITUACAO = '1' , TIMESTAMP = CURRENT TIMESTAMP WHERE FONTE = :V1RCAC-FONTE AND NRRCAP = :V1RCAC-NRRCAP AND NRRCAPCO = :V1RCAC-NRRCAPCO AND OPERACAO = :V1RCAC-OPERACAO AND DTMOVTO = :V1RCAC-DTMOVTO AND HORAOPER = :V1RCAC-HORAOPER END-EXEC. */

            var m_1120_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1 = new M_1120_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1()
            {
                V1RCAC_NRRCAPCO = V1RCAC_NRRCAPCO.ToString(),
                V1RCAC_OPERACAO = V1RCAC_OPERACAO.ToString(),
                V1RCAC_HORAOPER = V1RCAC_HORAOPER.ToString(),
                V1RCAC_DTMOVTO = V1RCAC_DTMOVTO.ToString(),
                V1RCAC_NRRCAP = V1RCAC_NRRCAP.ToString(),
                V1RCAC_FONTE = V1RCAC_FONTE.ToString(),
            };

            M_1120_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1.Execute(m_1120_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-1120-INSERT-V0RCAPCOMP */
        private void M_1120_INSERT_V0RCAPCOMP(bool isPerform = false)
        {
            /*" -3387- MOVE 'INSERT V0RCAPCOMP    ' TO COMANDO. */
            _.Move("INSERT V0RCAPCOMP    ", WABEND.COMANDO);

            /*" -3388- MOVE '0' TO V1RCAC-SITCONTB */
            _.Move("0", V1RCAC_SITCONTB);

            /*" -3389- MOVE '0' TO V1RCAC-SITUACAO */
            _.Move("0", V1RCAC_SITUACAO);

            /*" -3391- MOVE 220 TO V1RCAC-OPERACAO */
            _.Move(220, V1RCAC_OPERACAO);

            /*" -3409- PERFORM M_1120_INSERT_V0RCAPCOMP_DB_INSERT_1 */

            M_1120_INSERT_V0RCAPCOMP_DB_INSERT_1();

            /*" -3412- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3413- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-1120-INSERT-V0RCAPCOMP-DB-INSERT-1 */
        public void M_1120_INSERT_V0RCAPCOMP_DB_INSERT_1()
        {
            /*" -3409- EXEC SQL INSERT INTO SEGUROS.V0RCAPCOMP VALUES (:V1RCAC-FONTE , :V1RCAC-NRRCAP , :V1RCAC-NRRCAPCO , :V1RCAC-OPERACAO , :SISTEMA-DTMOVABE , CURRENT TIME, :V1RCAC-SITUACAO , :V1RCAC-BCOAVISO , :V1RCAC-AGEAVISO , :V1RCAC-NRAVISO , :V1RCAC-VLRCAP , :V1RCAC-DATARCAP , :V1RCAC-DTCADAST , :V1RCAC-SITCONTB , :V1RCAC-COD-EMPRESA , CURRENT TIMESTAMP) END-EXEC. */

            var m_1120_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1 = new M_1120_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1()
            {
                V1RCAC_FONTE = V1RCAC_FONTE.ToString(),
                V1RCAC_NRRCAP = V1RCAC_NRRCAP.ToString(),
                V1RCAC_NRRCAPCO = V1RCAC_NRRCAPCO.ToString(),
                V1RCAC_OPERACAO = V1RCAC_OPERACAO.ToString(),
                SISTEMA_DTMOVABE = SISTEMA_DTMOVABE.ToString(),
                V1RCAC_SITUACAO = V1RCAC_SITUACAO.ToString(),
                V1RCAC_BCOAVISO = V1RCAC_BCOAVISO.ToString(),
                V1RCAC_AGEAVISO = V1RCAC_AGEAVISO.ToString(),
                V1RCAC_NRAVISO = V1RCAC_NRAVISO.ToString(),
                V1RCAC_VLRCAP = V1RCAC_VLRCAP.ToString(),
                V1RCAC_DATARCAP = V1RCAC_DATARCAP.ToString(),
                V1RCAC_DTCADAST = V1RCAC_DTCADAST.ToString(),
                V1RCAC_SITCONTB = V1RCAC_SITCONTB.ToString(),
                V1RCAC_COD_EMPRESA = V1RCAC_COD_EMPRESA.ToString(),
            };

            M_1120_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1.Execute(m_1120_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" M-1120-UPDATE-V0AVISOSALDO */
        private void M_1120_UPDATE_V0AVISOSALDO(bool isPerform = false)
        {
            /*" -3418- MOVE 'UPDATE V0AVISOSALDO  ' TO COMANDO. */
            _.Move("UPDATE V0AVISOSALDO  ", WABEND.COMANDO);

            /*" -3425- PERFORM M_1120_UPDATE_V0AVISOSALDO_DB_UPDATE_1 */

            M_1120_UPDATE_V0AVISOSALDO_DB_UPDATE_1();

            /*" -3429- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -3431- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -3431- GO TO 1120-FETCH-V0RCAPCOMP. */

            M_1120_FETCH_V0RCAPCOMP(); //GOTO
            return;

        }

        [StopWatch]
        /*" M-1120-UPDATE-V0AVISOSALDO-DB-UPDATE-1 */
        public void M_1120_UPDATE_V0AVISOSALDO_DB_UPDATE_1()
        {
            /*" -3425- EXEC SQL UPDATE SEGUROS.V0AVISOS_SALDOS SET SDOATU = (SDOATU - :V1RCAC-VLRCAP) WHERE BCOAVISO = :V1RCAC-BCOAVISO AND AGEAVISO = :V1RCAC-AGEAVISO AND NRAVISO = :V1RCAC-NRAVISO END-EXEC. */

            var m_1120_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1 = new M_1120_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1()
            {
                V1RCAC_VLRCAP = V1RCAC_VLRCAP.ToString(),
                V1RCAC_BCOAVISO = V1RCAC_BCOAVISO.ToString(),
                V1RCAC_AGEAVISO = V1RCAC_AGEAVISO.ToString(),
                V1RCAC_NRAVISO = V1RCAC_NRAVISO.ToString(),
            };

            M_1120_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1.Execute(m_1120_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1120_FIM*/

        [StopWatch]
        /*" M-1500-SELECT-PRODUTOSVG */
        private void M_1500_SELECT_PRODUTOSVG(bool isPerform = false)
        {
            /*" -3439- MOVE '1500-SELECT V0PRODUTOSVG' TO COMANDO. */
            _.Move("1500-SELECT V0PRODUTOSVG", WABEND.COMANDO);

            /*" -3472- PERFORM M_1500_SELECT_PRODUTOSVG_DB_SELECT_1 */

            M_1500_SELECT_PRODUTOSVG_DB_SELECT_1();

            /*" -3475- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -3477- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -3478- MOVE PRODVG-CUSTOCAP-TOTAL TO PRODVG-CUSTOCAP-TOTAL-A */
            _.Move(PRODVG_CUSTOCAP_TOTAL, WS_WORK_AREAS.PRODVG_CUSTOCAP_TOTAL_A);

            /*" -3478- MOVE PRODVG-CUSTOCAP-TOTAL-N TO PRODVG-CUSTOCAP-TOTAL-9. */
            _.Move(WS_WORK_AREAS.PRODVG_CUSTOCAP_TOTAL_N, PRODVG_CUSTOCAP_TOTAL_9);

        }

        [StopWatch]
        /*" M-1500-SELECT-PRODUTOSVG-DB-SELECT-1 */
        public void M_1500_SELECT_PRODUTOSVG_DB_SELECT_1()
        {
            /*" -3472- EXEC SQL SELECT CODPRODAZ, ESTR_COBR, ORIG_PRODU, COD_AGENCIADOR, TEM_SAF, TEM_CDG, CODRELAT, COBERADIC_PREMIO, CUSTOCAP_TOTAL, DESCONTO_ADESAO, CODPRODU, VALUE(RISCO, '1' ), SITPLANCEF , ARQ_FDCAP INTO :PRODVG-CODPRODAZ, :PRODVG-ESTR-COBR :VIND-ESTR-COBR , :PRODVG-ORIG-PRODU:VIND-ORIG-PRODU, :PRODVG-AGENCIADOR:VIND-AGENCIADOR, :PRODVG-TEM-SAF:VIND-TEM-SAF, :PRODVG-TEM-CDG:VIND-TEM-CDG, :PRODVG-CODRELAT:VIND-CODRELAT, :PRODVG-COBERADIC-PREMIO, :PRODVG-CUSTOCAP-TOTAL, :PRODVG-DESCONTO-ADESAO, :PRODVG-COD-PRODUTO, :PRODVG-RISCO, :PRODVG-SITPLANCEF, :PRODVG-ARQ-FDCAP:WS-IND-ARQFDCAP FROM SEGUROS.V0PRODUTOSVG WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE AND CODSUBES = :PROPVA-CODSUBES WITH UR END-EXEC. */

            var m_1500_SELECT_PRODUTOSVG_DB_SELECT_1_Query1 = new M_1500_SELECT_PRODUTOSVG_DB_SELECT_1_Query1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
            };

            var executed_1 = M_1500_SELECT_PRODUTOSVG_DB_SELECT_1_Query1.Execute(m_1500_SELECT_PRODUTOSVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODVG_CODPRODAZ, PRODVG_CODPRODAZ);
                _.Move(executed_1.PRODVG_ESTR_COBR, PRODVG_ESTR_COBR);
                _.Move(executed_1.VIND_ESTR_COBR, VIND_ESTR_COBR);
                _.Move(executed_1.PRODVG_ORIG_PRODU, PRODVG_ORIG_PRODU);
                _.Move(executed_1.VIND_ORIG_PRODU, VIND_ORIG_PRODU);
                _.Move(executed_1.PRODVG_AGENCIADOR, PRODVG_AGENCIADOR);
                _.Move(executed_1.VIND_AGENCIADOR, VIND_AGENCIADOR);
                _.Move(executed_1.PRODVG_TEM_SAF, PRODVG_TEM_SAF);
                _.Move(executed_1.VIND_TEM_SAF, VIND_TEM_SAF);
                _.Move(executed_1.PRODVG_TEM_CDG, PRODVG_TEM_CDG);
                _.Move(executed_1.VIND_TEM_CDG, VIND_TEM_CDG);
                _.Move(executed_1.PRODVG_CODRELAT, PRODVG_CODRELAT);
                _.Move(executed_1.VIND_CODRELAT, VIND_CODRELAT);
                _.Move(executed_1.PRODVG_COBERADIC_PREMIO, PRODVG_COBERADIC_PREMIO);
                _.Move(executed_1.PRODVG_CUSTOCAP_TOTAL, PRODVG_CUSTOCAP_TOTAL);
                _.Move(executed_1.PRODVG_DESCONTO_ADESAO, PRODVG_DESCONTO_ADESAO);
                _.Move(executed_1.PRODVG_COD_PRODUTO, PRODVG_COD_PRODUTO);
                _.Move(executed_1.PRODVG_RISCO, PRODVG_RISCO);
                _.Move(executed_1.PRODVG_SITPLANCEF, PRODVG_SITPLANCEF);
                _.Move(executed_1.PRODVG_ARQ_FDCAP, PRODVG_ARQ_FDCAP);
                _.Move(executed_1.WS_IND_ARQFDCAP, WS_IND_ARQFDCAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1500_FIM*/

        [StopWatch]
        /*" M-2000-INTEGRA-EMPRESA-GLOBAL */
        private void M_2000_INTEGRA_EMPRESA_GLOBAL(bool isPerform = false)
        {
            /*" -3494- MOVE '2000-INTERGRA   ' TO COMANDO. */
            _.Move("2000-INTERGRA   ", WABEND.COMANDO);

            /*" -3495- MOVE PROPVA-DTQITBCO TO W01DTSQL. */
            _.Move(PROPVA_DTQITBCO, WS_WORK_AREAS.W01DTSQL);

            /*" -3496- IF W01DDSQL < 16 */

            if (WS_WORK_AREAS.W01DTSQL_R.W01DDSQL < 16)
            {

                /*" -3497- MOVE 01 TO W01DDSQL */
                _.Move(01, WS_WORK_AREAS.W01DTSQL_R.W01DDSQL);

                /*" -3498- ELSE */
            }
            else
            {


                /*" -3500- MOVE 15 TO W01DDSQL. */
                _.Move(15, WS_WORK_AREAS.W01DTSQL_R.W01DDSQL);
            }


            /*" -3501- ADD 1 TO W01MMSQL. */
            WS_WORK_AREAS.W01DTSQL_R.W01MMSQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01MMSQL + 1;

            /*" -3502- IF W01MMSQL > 12 */

            if (WS_WORK_AREAS.W01DTSQL_R.W01MMSQL > 12)
            {

                /*" -3503- MOVE 01 TO W01MMSQL */
                _.Move(01, WS_WORK_AREAS.W01DTSQL_R.W01MMSQL);

                /*" -3505- COMPUTE W01AASQL = W01AASQL + 1. */
                WS_WORK_AREAS.W01DTSQL_R.W01AASQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01AASQL + 1;
            }


            /*" -3511- MOVE W01DTSQL TO MDTMOVTO. */
            _.Move(WS_WORK_AREAS.W01DTSQL, MDTMOVTO);

            /*" -3512- IF PROPVA-DTPROXVEN < PROPVA-DTMINVEN */

            if (PROPVA_DTPROXVEN < PROPVA_DTMINVEN)
            {

                /*" -3513- MOVE PROPVA-DTPROXVEN TO W01DTSQL */
                _.Move(PROPVA_DTPROXVEN, WS_WORK_AREAS.W01DTSQL);

                /*" -3514- ADD 1 TO W01MMSQL */
                WS_WORK_AREAS.W01DTSQL_R.W01MMSQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01MMSQL + 1;

                /*" -3515- IF W01MMSQL > 12 */

                if (WS_WORK_AREAS.W01DTSQL_R.W01MMSQL > 12)
                {

                    /*" -3516- MOVE 01 TO W01MMSQL */
                    _.Move(01, WS_WORK_AREAS.W01DTSQL_R.W01MMSQL);

                    /*" -3517- COMPUTE W01AASQL = W01AASQL + 1 */
                    WS_WORK_AREAS.W01DTSQL_R.W01AASQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01AASQL + 1;

                    /*" -3518- END-IF */
                }


                /*" -3518- MOVE W01DTSQL TO PROPVA-DTPROXVEN. */
                _.Move(WS_WORK_AREAS.W01DTSQL, PROPVA_DTPROXVEN);
            }


        }

        [StopWatch]
        /*" M-2000-AJUSTA-DTPROXVEN */
        private void M_2000_AJUSTA_DTPROXVEN(bool isPerform = false)
        {
            /*" -3527- IF PROPVA-DTPROXVEN < W04DTSQL */

            if (PROPVA_DTPROXVEN < WS_WORK_AREAS.W04DTSQL)
            {

                /*" -3528- MOVE PROPVA-DTPROXVEN TO W01DTSQL */
                _.Move(PROPVA_DTPROXVEN, WS_WORK_AREAS.W01DTSQL);

                /*" -3529- ADD 1 TO W01MMSQL */
                WS_WORK_AREAS.W01DTSQL_R.W01MMSQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01MMSQL + 1;

                /*" -3530- IF W01MMSQL > 12 */

                if (WS_WORK_AREAS.W01DTSQL_R.W01MMSQL > 12)
                {

                    /*" -3531- MOVE 01 TO W01MMSQL */
                    _.Move(01, WS_WORK_AREAS.W01DTSQL_R.W01MMSQL);

                    /*" -3532- COMPUTE W01AASQL = W01AASQL + 1 */
                    WS_WORK_AREAS.W01DTSQL_R.W01AASQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01AASQL + 1;

                    /*" -3533- END-IF */
                }


                /*" -3534- MOVE W01DTSQL TO PROPVA-DTPROXVEN */
                _.Move(WS_WORK_AREAS.W01DTSQL, PROPVA_DTPROXVEN);

                /*" -3536- GO TO 2000-AJUSTA-DTPROXVEN. */
                new Task(() => M_2000_AJUSTA_DTPROXVEN()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -3537- MOVE '2000-INTEGRA-EMPRESA-GLOBAL' TO PARAGRAFO. */
            _.Move("2000-INTEGRA-EMPRESA-GLOBAL", WABEND.PARAGRAFO);

            /*" -3539- MOVE 'INSERT V0SUBGRUPO' TO COMANDO. */
            _.Move("INSERT V0SUBGRUPO", WABEND.COMANDO);

            /*" -3540- COMPUTE SUBGRU-CODSUBES = SUBGRU-CODSUBES + 1. */
            SUBGRU_CODSUBES.Value = SUBGRU_CODSUBES + 1;

            /*" -3542- MOVE SUBGRU-CODSUBES TO PROPVA-CODSUBES. */
            _.Move(SUBGRU_CODSUBES, PROPVA_CODSUBES);

            /*" -3543- MOVE PROPVA-DTQITBCO TO W01DTSQL. */
            _.Move(PROPVA_DTQITBCO, WS_WORK_AREAS.W01DTSQL);

            /*" -3544- MOVE 01 TO W01DDSQL. */
            _.Move(01, WS_WORK_AREAS.W01DTSQL_R.W01DDSQL);

            /*" -3546- MOVE W01DTSQL TO APCORR-DTINIVIG. */
            _.Move(WS_WORK_AREAS.W01DTSQL, APCORR_DTINIVIG);

            /*" -3548- MOVE 81 TO APCORR-RAMO. */
            _.Move(81, APCORR_RAMO);

            /*" -3550- PERFORM 2100-INCLUI-CORRETOR THRU 2100-FIM. */

            M_2100_INCLUI_CORRETOR(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2100_FIM*/


            /*" -3552- MOVE 93 TO APCORR-RAMO. */
            _.Move(93, APCORR_RAMO);

            /*" -3554- PERFORM 2100-INCLUI-CORRETOR THRU 2100-FIM. */

            M_2100_INCLUI_CORRETOR(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2100_FIM*/


            /*" -3555- MOVE '2000-INTEGRA-EMPRESA-GLOBAL' TO PARAGRAFO. */
            _.Move("2000-INTEGRA-EMPRESA-GLOBAL", WABEND.PARAGRAFO);

            /*" -3558- MOVE 'SELECT V0PLANOSVA' TO COMANDO. */
            _.Move("SELECT V0PLANOSVA", WABEND.COMANDO);

            /*" -3574- PERFORM M_2000_AJUSTA_DTPROXVEN_DB_SELECT_1 */

            M_2000_AJUSTA_DTPROXVEN_DB_SELECT_1();

            /*" -3577- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -3579- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -3580- COMPUTE MTXAPIP = MTXAPMA / 2. */
            MTXAPIP.Value = MTXAPMA / 2f;

            /*" -3582- COMPUTE MTXAPMA = MTXAPMA - MTXAPIP. */
            MTXAPMA.Value = MTXAPMA - MTXAPIP;

            /*" -3585- MOVE 'INSERT V0CONDTEC' TO COMANDO. */
            _.Move("INSERT V0CONDTEC", WABEND.COMANDO);

            /*" -3611- PERFORM M_2000_AJUSTA_DTPROXVEN_DB_INSERT_1 */

            M_2000_AJUSTA_DTPROXVEN_DB_INSERT_1();

            /*" -3614- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -3614- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-2000-AJUSTA-DTPROXVEN-DB-SELECT-1 */
        public void M_2000_AJUSTA_DTPROXVEN_DB_SELECT_1()
        {
            /*" -3574- EXEC SQL SELECT TAXAVG, TAXAAP INTO :MTXVG, :MTXAPMA FROM SEGUROS.PLANOS_VA_VGAP WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE AND CODSUBES = :PROPVA-CODSUBES AND OPCAO_COBER = :PROPVA-OPCAO-COBER AND DTINIVIG <= :PROPVA-DTQITBCO AND DTTERVIG >= :PROPVA-DTQITBCO AND IDADE_INICIAL = 0 AND IDADE_FINAL = 0 AND PERIPGTO = :OPCAOP-PERIPGTO AND VLPREMIOTOT = :COBERP-VLPREMIO WITH UR END-EXEC. */

            var m_2000_AJUSTA_DTPROXVEN_DB_SELECT_1_Query1 = new M_2000_AJUSTA_DTPROXVEN_DB_SELECT_1_Query1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                PROPVA_OPCAO_COBER = PROPVA_OPCAO_COBER.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
                PROPVA_DTQITBCO = PROPVA_DTQITBCO.ToString(),
                OPCAOP_PERIPGTO = OPCAOP_PERIPGTO.ToString(),
                COBERP_VLPREMIO = COBERP_VLPREMIO.ToString(),
            };

            var executed_1 = M_2000_AJUSTA_DTPROXVEN_DB_SELECT_1_Query1.Execute(m_2000_AJUSTA_DTPROXVEN_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MTXVG, MTXVG);
                _.Move(executed_1.MTXAPMA, MTXAPMA);
            }


        }

        [StopWatch]
        /*" M-2000-AJUSTA-DTPROXVEN-DB-INSERT-1 */
        public void M_2000_AJUSTA_DTPROXVEN_DB_INSERT_1()
        {
            /*" -3611- EXEC SQL INSERT INTO SEGUROS.V0CONDTEC VALUES (0109700000024, :PROPVA-CODSUBES, 0, 0, 0, :MTXAPMA, :MTXAPIP, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0) END-EXEC. */

            var m_2000_AJUSTA_DTPROXVEN_DB_INSERT_1_Insert1 = new M_2000_AJUSTA_DTPROXVEN_DB_INSERT_1_Insert1()
            {
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
                MTXAPMA = MTXAPMA.ToString(),
                MTXAPIP = MTXAPIP.ToString(),
            };

            M_2000_AJUSTA_DTPROXVEN_DB_INSERT_1_Insert1.Execute(m_2000_AJUSTA_DTPROXVEN_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2000_FIM*/

        [StopWatch]
        /*" M-2100-INCLUI-CORRETOR */
        private void M_2100_INCLUI_CORRETOR(bool isPerform = false)
        {
            /*" -3625- MOVE '2100-INCLUI-CORRETOR' TO PARAGRAFO. */
            _.Move("2100-INCLUI-CORRETOR", WABEND.PARAGRAFO);

            /*" -3627- MOVE 'INSERT V0APOLCORRET' TO COMANDO. */
            _.Move("INSERT V0APOLCORRET", WABEND.COMANDO);

            /*" -3643- PERFORM M_2100_INCLUI_CORRETOR_DB_INSERT_1 */

            M_2100_INCLUI_CORRETOR_DB_INSERT_1();

            /*" -3646- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -3646- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-2100-INCLUI-CORRETOR-DB-INSERT-1 */
        public void M_2100_INCLUI_CORRETOR_DB_INSERT_1()
        {
            /*" -3643- EXEC SQL INSERT INTO SEGUROS.V0APOLCORRET VALUES (0109700000024, :APCORR-RAMO, 0, 17256, :PROPVA-CODSUBES, :APCORR-DTINIVIG, '9999-12-31' , 100.00, 5.00, '1' , '1' , 0, CURRENT TIMESTAMP, 'VP0121B' ) END-EXEC. */

            var m_2100_INCLUI_CORRETOR_DB_INSERT_1_Insert1 = new M_2100_INCLUI_CORRETOR_DB_INSERT_1_Insert1()
            {
                APCORR_RAMO = APCORR_RAMO.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
                APCORR_DTINIVIG = APCORR_DTINIVIG.ToString(),
            };

            M_2100_INCLUI_CORRETOR_DB_INSERT_1_Insert1.Execute(m_2100_INCLUI_CORRETOR_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2100_FIM*/

        [StopWatch]
        /*" M-3000-INTEGRA-JORNAL-FENAM */
        private void M_3000_INTEGRA_JORNAL_FENAM(bool isPerform = false)
        {
            /*" -3661- MOVE '3000-INTEGRA    ' TO COMANDO. */
            _.Move("3000-INTEGRA    ", WABEND.COMANDO);

            /*" -3668- MOVE PROPVA-DTQITBCO TO MDTMOVTO W01DTSQL. */
            _.Move(PROPVA_DTQITBCO, MDTMOVTO, WS_WORK_AREAS.W01DTSQL);

            /*" -3669- MOVE OPCAOP-DIA-DEB TO W01DDSQL. */
            _.Move(OPCAOP_DIA_DEB, WS_WORK_AREAS.W01DTSQL_R.W01DDSQL);

            /*" -3670- ADD 1 TO W01MMSQL. */
            WS_WORK_AREAS.W01DTSQL_R.W01MMSQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01MMSQL + 1;

            /*" -3671- IF W01MMSQL > 12 */

            if (WS_WORK_AREAS.W01DTSQL_R.W01MMSQL > 12)
            {

                /*" -3672- MOVE 01 TO W01MMSQL */
                _.Move(01, WS_WORK_AREAS.W01DTSQL_R.W01MMSQL);

                /*" -3673- COMPUTE W01AASQL = W01AASQL + 1. */
                WS_WORK_AREAS.W01DTSQL_R.W01AASQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01AASQL + 1;
            }


            /*" -3675- MOVE W01DTSQL TO PROPVA-DTPROXVEN. */
            _.Move(WS_WORK_AREAS.W01DTSQL, PROPVA_DTPROXVEN);

            /*" -3676- IF W01DTSQL < PROPVA-DTMINVEN */

            if (WS_WORK_AREAS.W01DTSQL < PROPVA_DTMINVEN)
            {

                /*" -3677- ADD 1 TO W01MMSQL */
                WS_WORK_AREAS.W01DTSQL_R.W01MMSQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01MMSQL + 1;

                /*" -3678- IF W01MMSQL > 12 */

                if (WS_WORK_AREAS.W01DTSQL_R.W01MMSQL > 12)
                {

                    /*" -3679- MOVE 01 TO W01MMSQL */
                    _.Move(01, WS_WORK_AREAS.W01DTSQL_R.W01MMSQL);

                    /*" -3680- COMPUTE W01AASQL = W01AASQL + 1 */
                    WS_WORK_AREAS.W01DTSQL_R.W01AASQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01AASQL + 1;

                    /*" -3681- END-IF */
                }


                /*" -3681- MOVE W01DTSQL TO PROPVA-DTPROXVEN. */
                _.Move(WS_WORK_AREAS.W01DTSQL, PROPVA_DTPROXVEN);
            }


        }

        [StopWatch]
        /*" M-3000-AJUSTA-DTPROXVEN */
        private void M_3000_AJUSTA_DTPROXVEN(bool isPerform = false)
        {
            /*" -3690- IF PROPVA-DTPROXVEN < W04DTSQL */

            if (PROPVA_DTPROXVEN < WS_WORK_AREAS.W04DTSQL)
            {

                /*" -3691- MOVE PROPVA-DTPROXVEN TO W01DTSQL */
                _.Move(PROPVA_DTPROXVEN, WS_WORK_AREAS.W01DTSQL);

                /*" -3692- ADD 1 TO W01MMSQL */
                WS_WORK_AREAS.W01DTSQL_R.W01MMSQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01MMSQL + 1;

                /*" -3693- IF W01MMSQL > 12 */

                if (WS_WORK_AREAS.W01DTSQL_R.W01MMSQL > 12)
                {

                    /*" -3694- MOVE 01 TO W01MMSQL */
                    _.Move(01, WS_WORK_AREAS.W01DTSQL_R.W01MMSQL);

                    /*" -3695- COMPUTE W01AASQL = W01AASQL + 1 */
                    WS_WORK_AREAS.W01DTSQL_R.W01AASQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01AASQL + 1;

                    /*" -3699- END-IF */
                }


                /*" -3700- MOVE W01DTSQL TO PROPVA-DTPROXVEN */
                _.Move(WS_WORK_AREAS.W01DTSQL, PROPVA_DTPROXVEN);

                /*" -3702- GO TO 3000-AJUSTA-DTPROXVEN. */
                new Task(() => M_3000_AJUSTA_DTPROXVEN()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -3704- MOVE 0 TO MAGENCIADOR MNUM-MATRICULA. */
            _.Move(0, MAGENCIADOR, MNUM_MATRICULA);

            /*" -3706- MOVE '1' TO MTPINCLUS. */
            _.Move("1", MTPINCLUS);

            /*" -3706- PERFORM 8000-INTEGRA-VG THRU 8000-FIM. */

            M_8000_INTEGRA_VG(true);

            R8000_PROPAUTOM(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8000_FIM*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3000_FIM*/

        [StopWatch]
        /*" M-4000-INTEGRA-PREF-VIDA */
        private void M_4000_INTEGRA_PREF_VIDA(bool isPerform = false)
        {
            /*" -3719- MOVE '4000-INTEGRA-PRE' TO COMANDO. */
            _.Move("4000-INTEGRA-PRE", WABEND.COMANDO);

            /*" -3720- MOVE PROPVA-DTQITBCO TO MDTMOVTO. */
            _.Move(PROPVA_DTQITBCO, MDTMOVTO);

            /*" -3721- MOVE PROPVA-NRMATRFUN TO MNUM-MATRICULA. */
            _.Move(PROPVA_NRMATRFUN, MNUM_MATRICULA);

            /*" -3723- MOVE '1' TO MTPINCLUS. */
            _.Move("1", MTPINCLUS);

            /*" -3725- MOVE PRODVG-AGENCIADOR TO MAGENCIADOR. */
            _.Move(PRODVG_AGENCIADOR, MAGENCIADOR);

            /*" -3725- PERFORM 8000-INTEGRA-VG THRU 8000-FIM. */

            M_8000_INTEGRA_VG(true);

            R8000_PROPAUTOM(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8000_FIM*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_4000_FIM*/

        [StopWatch]
        /*" M-5000-INTEGRA-PARENTES-PV */
        private void M_5000_INTEGRA_PARENTES_PV(bool isPerform = false)
        {
            /*" -3740- MOVE '5000-INTEGRA-PAR' TO COMANDO. */
            _.Move("5000-INTEGRA-PAR", WABEND.COMANDO);

            /*" -3742- MOVE PROPVA-DTQITBCO TO MDTMOVTO. */
            _.Move(PROPVA_DTQITBCO, MDTMOVTO);

            /*" -3743- IF PRODVG-ORIG-PRODU = 'CEF DEB CC' */

            if (PRODVG_ORIG_PRODU == "CEF DEB CC")
            {

                /*" -3744- MOVE PROPVA-DTVENCTO TO W01DTSQL */
                _.Move(PROPVA_DTVENCTO, WS_WORK_AREAS.W01DTSQL);

                /*" -3745- ELSE */
            }
            else
            {


                /*" -3751- MOVE PROPVA-DTQITBCO TO W01DTSQL. */
                _.Move(PROPVA_DTQITBCO, WS_WORK_AREAS.W01DTSQL);
            }


            /*" -3752- MOVE OPCAOP-DIA-DEB TO W01DDSQL. */
            _.Move(OPCAOP_DIA_DEB, WS_WORK_AREAS.W01DTSQL_R.W01DDSQL);

            /*" -3753- ADD 1 TO W01MMSQL. */
            WS_WORK_AREAS.W01DTSQL_R.W01MMSQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01MMSQL + 1;

            /*" -3754- IF W01MMSQL > 12 */

            if (WS_WORK_AREAS.W01DTSQL_R.W01MMSQL > 12)
            {

                /*" -3755- MOVE 01 TO W01MMSQL */
                _.Move(01, WS_WORK_AREAS.W01DTSQL_R.W01MMSQL);

                /*" -3756- COMPUTE W01AASQL = W01AASQL + 1. */
                WS_WORK_AREAS.W01DTSQL_R.W01AASQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01AASQL + 1;
            }


            /*" -3758- MOVE W01DTSQL TO PROPVA-DTPROXVEN. */
            _.Move(WS_WORK_AREAS.W01DTSQL, PROPVA_DTPROXVEN);

            /*" -3759- IF W01DTSQL < PROPVA-DTMINVEN */

            if (WS_WORK_AREAS.W01DTSQL < PROPVA_DTMINVEN)
            {

                /*" -3760- ADD 1 TO W01MMSQL */
                WS_WORK_AREAS.W01DTSQL_R.W01MMSQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01MMSQL + 1;

                /*" -3761- IF W01MMSQL > 12 */

                if (WS_WORK_AREAS.W01DTSQL_R.W01MMSQL > 12)
                {

                    /*" -3762- MOVE 01 TO W01MMSQL */
                    _.Move(01, WS_WORK_AREAS.W01DTSQL_R.W01MMSQL);

                    /*" -3763- COMPUTE W01AASQL = W01AASQL + 1 */
                    WS_WORK_AREAS.W01DTSQL_R.W01AASQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01AASQL + 1;

                    /*" -3764- END-IF */
                }


                /*" -3764- MOVE W01DTSQL TO PROPVA-DTPROXVEN. */
                _.Move(WS_WORK_AREAS.W01DTSQL, PROPVA_DTPROXVEN);
            }


        }

        [StopWatch]
        /*" M-5000-AJUSTA-DTPROXVEN */
        private void M_5000_AJUSTA_DTPROXVEN(bool isPerform = false)
        {
            /*" -3773- IF PROPVA-DTPROXVEN < W04DTSQL */

            if (PROPVA_DTPROXVEN < WS_WORK_AREAS.W04DTSQL)
            {

                /*" -3774- MOVE PROPVA-DTPROXVEN TO W01DTSQL */
                _.Move(PROPVA_DTPROXVEN, WS_WORK_AREAS.W01DTSQL);

                /*" -3775- ADD 1 TO W01MMSQL */
                WS_WORK_AREAS.W01DTSQL_R.W01MMSQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01MMSQL + 1;

                /*" -3776- IF W01MMSQL > 12 */

                if (WS_WORK_AREAS.W01DTSQL_R.W01MMSQL > 12)
                {

                    /*" -3777- MOVE 01 TO W01MMSQL */
                    _.Move(01, WS_WORK_AREAS.W01DTSQL_R.W01MMSQL);

                    /*" -3778- COMPUTE W01AASQL = W01AASQL + 1 */
                    WS_WORK_AREAS.W01DTSQL_R.W01AASQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01AASQL + 1;

                    /*" -3782- END-IF */
                }


                /*" -3783- MOVE W01DTSQL TO PROPVA-DTPROXVEN */
                _.Move(WS_WORK_AREAS.W01DTSQL, PROPVA_DTPROXVEN);

                /*" -3788- GO TO 5000-AJUSTA-DTPROXVEN. */
                new Task(() => M_5000_AJUSTA_DTPROXVEN()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -3790- IF PROPVA-NRPARCEL = 0 AND PROPVA-CODOPER = 201 */

            if (PROPVA_NRPARCEL == 0 && PROPVA_CODOPER == 201)
            {

                /*" -3791- MOVE PROPVA-DTMOVTO TO W01DTSQL */
                _.Move(PROPVA_DTMOVTO, WS_WORK_AREAS.W01DTSQL);

                /*" -3792- MOVE OPCAOP-DIA-DEB TO W01DDSQL */
                _.Move(OPCAOP_DIA_DEB, WS_WORK_AREAS.W01DTSQL_R.W01DDSQL);

                /*" -3795- MOVE W01DTSQL TO PROPVA-DTPROXVEN. */
                _.Move(WS_WORK_AREAS.W01DTSQL, PROPVA_DTPROXVEN);
            }


            /*" -3796- MOVE PROPVA-NRMATRFUN TO MNUM-MATRICULA. */
            _.Move(PROPVA_NRMATRFUN, MNUM_MATRICULA);

            /*" -3797- MOVE PRODVG-AGENCIADOR TO MAGENCIADOR. */
            _.Move(PRODVG_AGENCIADOR, MAGENCIADOR);

            /*" -3799- MOVE '1' TO MTPINCLUS. */
            _.Move("1", MTPINCLUS);

            /*" -3801- PERFORM 8000-INTEGRA-VG THRU 8000-FIM. */

            M_8000_INTEGRA_VG(true);

            R8000_PROPAUTOM(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8000_FIM*/


            /*" -3803- IF PROPOSTA-CACB OR PROPOSTA-COPESP */

            if (WS_WORK_AREAS.FILLER_1.W_CANAL_PROPOSTA1["PROPOSTA_CACB"] || WS_WORK_AREAS.FILLER_1.W_CANAL_PROPOSTA1["PROPOSTA_COPESP"])
            {

                /*" -3803- PERFORM 5100-GERA-COMISSAO. */

                M_5100_GERA_COMISSAO(true);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5000_FIM*/

        [StopWatch]
        /*" M-5100-GERA-COMISSAO */
        private void M_5100_GERA_COMISSAO(bool isPerform = false)
        {
            /*" -3825- MOVE '5100-GERA-COMISSAO' TO COMANDO. */
            _.Move("5100-GERA-COMISSAO", WABEND.COMANDO);

            /*" -3828- MOVE 93 TO COMISSOE-RAMO-COBERTURA. */
            _.Move(93, COMISSOE.DCLCOMISSOES.COMISSOE_RAMO_COBERTURA);

            /*" -3830- IF PROPVA-CODPRODU EQUAL 9335 OR PROPVA-CODPRODU EQUAL 9338 */

            if (PROPVA_CODPRODU == 9335 || PROPVA_CODPRODU == 9338)
            {

                /*" -3832- MOVE 17 TO COMISSOE-PCT-COM-CORRETOR */
                _.Move(17, COMISSOE.DCLCOMISSOES.COMISSOE_PCT_COM_CORRETOR);

                /*" -3833- ELSE */
            }
            else
            {


                /*" -3835- MOVE 75 TO COMISSOE-PCT-COM-CORRETOR */
                _.Move(75, COMISSOE.DCLCOMISSOES.COMISSOE_PCT_COM_CORRETOR);

                /*" -3837- END-IF. */
            }


            /*" -3840- COMPUTE COMISSOE-VAL-BASICO = COBERP-PRMVG + COBERP-PRMAP. */
            COMISSOE.DCLCOMISSOES.COMISSOE_VAL_BASICO.Value = COBERP_PRMVG + COBERP_PRMAP;

            /*" -3844- COMPUTE COMISSOE-VAL-COMISSAO = COMISSOE-VAL-BASICO * COMISSOE-PCT-COM-CORRETOR / 100. */
            COMISSOE.DCLCOMISSOES.COMISSOE_VAL_COMISSAO.Value = COMISSOE.DCLCOMISSOES.COMISSOE_VAL_BASICO * COMISSOE.DCLCOMISSOES.COMISSOE_PCT_COM_CORRETOR / 100f;

            /*" -3845- MOVE PROPVA-NUM-APOLICE TO COMISSOE-NUM-APOLICE */
            _.Move(PROPVA_NUM_APOLICE, COMISSOE.DCLCOMISSOES.COMISSOE_NUM_APOLICE);

            /*" -3846- MOVE ZEROS TO COMISSOE-NUM-ENDOSSO */
            _.Move(0, COMISSOE.DCLCOMISSOES.COMISSOE_NUM_ENDOSSO);

            /*" -3847- MOVE PROPVA-NRCERTIF TO COMISSOE-NUM-CERTIFICADO */
            _.Move(PROPVA_NRCERTIF, COMISSOE.DCLCOMISSOES.COMISSOE_NUM_CERTIFICADO);

            /*" -3848- MOVE SPACES TO COMISSOE-DAC-CERTIFICADO */
            _.Move("", COMISSOE.DCLCOMISSOES.COMISSOE_DAC_CERTIFICADO);

            /*" -3849- MOVE '1' TO COMISSOE-TIPO-SEGURADO */
            _.Move("1", COMISSOE.DCLCOMISSOES.COMISSOE_TIPO_SEGURADO);

            /*" -3850- MOVE 1 TO COMISSOE-NUM-PARCELA */
            _.Move(1, COMISSOE.DCLCOMISSOES.COMISSOE_NUM_PARCELA);

            /*" -3851- MOVE 1101 TO COMISSOE-COD-OPERACAO */
            _.Move(1101, COMISSOE.DCLCOMISSOES.COMISSOE_COD_OPERACAO);

            /*" -3852- MOVE 7005 TO COMISSOE-COD-PRODUTOR */
            _.Move(7005, COMISSOE.DCLCOMISSOES.COMISSOE_COD_PRODUTOR);

            /*" -3853- MOVE ZEROS TO COMISSOE-MODALI-COBERTURA */
            _.Move(0, COMISSOE.DCLCOMISSOES.COMISSOE_MODALI_COBERTURA);

            /*" -3854- MOVE 1 TO COMISSOE-OCORR-HISTORICO */
            _.Move(1, COMISSOE.DCLCOMISSOES.COMISSOE_OCORR_HISTORICO);

            /*" -3855- MOVE PROPVA-FONTE TO COMISSOE-COD-FONTE */
            _.Move(PROPVA_FONTE, COMISSOE.DCLCOMISSOES.COMISSOE_COD_FONTE);

            /*" -3856- MOVE PROPVA-CODCLIEN TO COMISSOE-COD-CLIENTE */
            _.Move(PROPVA_CODCLIEN, COMISSOE.DCLCOMISSOES.COMISSOE_COD_CLIENTE);

            /*" -3857- MOVE SISTEMA-DTMOVABE TO COMISSOE-DATA-CALCULO */
            _.Move(SISTEMA_DTMOVABE, COMISSOE.DCLCOMISSOES.COMISSOE_DATA_CALCULO);

            /*" -3858- MOVE ZEROS TO COMISSOE-NUM-RECIBO */
            _.Move(0, COMISSOE.DCLCOMISSOES.COMISSOE_NUM_RECIBO);

            /*" -3859- MOVE '1' TO COMISSOE-TIPO-COMISSAO */
            _.Move("1", COMISSOE.DCLCOMISSOES.COMISSOE_TIPO_COMISSAO);

            /*" -3861- MOVE ZEROS TO COMISSOE-QTD-PARCELAS COMISSOE-PCT-DESC-PREMIO */
            _.Move(0, COMISSOE.DCLCOMISSOES.COMISSOE_QTD_PARCELAS, COMISSOE.DCLCOMISSOES.COMISSOE_PCT_DESC_PREMIO);

            /*" -3862- MOVE PROPVA-CODSUBES TO COMISSOE-COD-SUBGRUPO */
            _.Move(PROPVA_CODSUBES, COMISSOE.DCLCOMISSOES.COMISSOE_COD_SUBGRUPO);

            /*" -3863- MOVE SPACES TO COMISSOE-DATA-MOVIMENTO */
            _.Move("", COMISSOE.DCLCOMISSOES.COMISSOE_DATA_MOVIMENTO);

            /*" -3864- MOVE SISTEMA-DTMOVABE TO COMISSOE-DATA-SELECAO */
            _.Move(SISTEMA_DTMOVABE, COMISSOE.DCLCOMISSOES.COMISSOE_DATA_SELECAO);

            /*" -3868- MOVE ZEROS TO COMISSOE-COD-EMPRESA COMISSOE-COD-PREPOSTO COMISSOE-NUM-BILHETE COMISSOE-VAL-VARMON */
            _.Move(0, COMISSOE.DCLCOMISSOES.COMISSOE_COD_EMPRESA, COMISSOE.DCLCOMISSOES.COMISSOE_COD_PREPOSTO, COMISSOE.DCLCOMISSOES.COMISSOE_NUM_BILHETE, COMISSOE.DCLCOMISSOES.COMISSOE_VAL_VARMON);

            /*" -3870- MOVE SISTEMA-DTMOVABE TO COMISSOE-DATA-QUITACAO. */
            _.Move(SISTEMA_DTMOVABE, COMISSOE.DCLCOMISSOES.COMISSOE_DATA_QUITACAO);

            /*" -3871- MOVE -1 TO VIND-DTMOVTO */
            _.Move(-1, VIND_DTMOVTO);

            /*" -3872- MOVE ZEROS TO VIND-DATSEL */
            _.Move(0, VIND_DATSEL);

            /*" -3873- MOVE ZEROS TO VIND-CODEMP */
            _.Move(0, VIND_CODEMP);

            /*" -3874- MOVE -1 TO VIND-CODPRP */
            _.Move(-1, VIND_CODPRP);

            /*" -3875- MOVE -1 TO VIND-NUMBIL */
            _.Move(-1, VIND_NUMBIL);

            /*" -3876- MOVE -1 TO VIND-VLVARMON */
            _.Move(-1, VIND_VLVARMON);

            /*" -3878- MOVE ZEROS TO VIND-DTQITBCO. */
            _.Move(0, VIND_DTQITBCO);

            /*" -3912- PERFORM M_5100_GERA_COMISSAO_DB_INSERT_1 */

            M_5100_GERA_COMISSAO_DB_INSERT_1();

            /*" -3916- IF SQLCODE EQUAL -803 NEXT SENTENCE */

            if (DB.SQLCODE == -803)
            {

                /*" -3917- ELSE */
            }
            else
            {


                /*" -3918- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -3919- DISPLAY '5100 - PROBLEMAS NO INSERT(COMISSAO)' */
                    _.Display($"5100 - PROBLEMAS NO INSERT(COMISSAO)");

                    /*" -3920- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-5100-GERA-COMISSAO-DB-INSERT-1 */
        public void M_5100_GERA_COMISSAO_DB_INSERT_1()
        {
            /*" -3912- EXEC SQL INSERT INTO SEGUROS.COMISSOES VALUES( :COMISSOE-NUM-APOLICE, :COMISSOE-NUM-ENDOSSO, :COMISSOE-NUM-CERTIFICADO, :COMISSOE-DAC-CERTIFICADO, :COMISSOE-TIPO-SEGURADO, :COMISSOE-NUM-PARCELA, :COMISSOE-COD-OPERACAO, :COMISSOE-COD-PRODUTOR, :COMISSOE-RAMO-COBERTURA, :COMISSOE-MODALI-COBERTURA, :COMISSOE-OCORR-HISTORICO, :COMISSOE-COD-FONTE, :COMISSOE-COD-CLIENTE, :COMISSOE-VAL-COMISSAO, :COMISSOE-DATA-CALCULO, :COMISSOE-NUM-RECIBO, :COMISSOE-VAL-BASICO, :COMISSOE-TIPO-COMISSAO, :COMISSOE-QTD-PARCELAS, :COMISSOE-PCT-COM-CORRETOR, :COMISSOE-PCT-DESC-PREMIO, :COMISSOE-COD-SUBGRUPO, CURRENT TIME, :COMISSOE-DATA-MOVIMENTO:VIND-DTMOVTO, :COMISSOE-DATA-SELECAO:VIND-DATSEL, :COMISSOE-COD-EMPRESA:VIND-CODEMP, :COMISSOE-COD-PREPOSTO:VIND-CODPRP, CURRENT TIMESTAMP, :COMISSOE-NUM-BILHETE:VIND-NUMBIL, :COMISSOE-VAL-VARMON:VIND-VLVARMON, :COMISSOE-DATA-QUITACAO:VIND-DTQITBCO) END-EXEC. */

            var m_5100_GERA_COMISSAO_DB_INSERT_1_Insert1 = new M_5100_GERA_COMISSAO_DB_INSERT_1_Insert1()
            {
                COMISSOE_NUM_APOLICE = COMISSOE.DCLCOMISSOES.COMISSOE_NUM_APOLICE.ToString(),
                COMISSOE_NUM_ENDOSSO = COMISSOE.DCLCOMISSOES.COMISSOE_NUM_ENDOSSO.ToString(),
                COMISSOE_NUM_CERTIFICADO = COMISSOE.DCLCOMISSOES.COMISSOE_NUM_CERTIFICADO.ToString(),
                COMISSOE_DAC_CERTIFICADO = COMISSOE.DCLCOMISSOES.COMISSOE_DAC_CERTIFICADO.ToString(),
                COMISSOE_TIPO_SEGURADO = COMISSOE.DCLCOMISSOES.COMISSOE_TIPO_SEGURADO.ToString(),
                COMISSOE_NUM_PARCELA = COMISSOE.DCLCOMISSOES.COMISSOE_NUM_PARCELA.ToString(),
                COMISSOE_COD_OPERACAO = COMISSOE.DCLCOMISSOES.COMISSOE_COD_OPERACAO.ToString(),
                COMISSOE_COD_PRODUTOR = COMISSOE.DCLCOMISSOES.COMISSOE_COD_PRODUTOR.ToString(),
                COMISSOE_RAMO_COBERTURA = COMISSOE.DCLCOMISSOES.COMISSOE_RAMO_COBERTURA.ToString(),
                COMISSOE_MODALI_COBERTURA = COMISSOE.DCLCOMISSOES.COMISSOE_MODALI_COBERTURA.ToString(),
                COMISSOE_OCORR_HISTORICO = COMISSOE.DCLCOMISSOES.COMISSOE_OCORR_HISTORICO.ToString(),
                COMISSOE_COD_FONTE = COMISSOE.DCLCOMISSOES.COMISSOE_COD_FONTE.ToString(),
                COMISSOE_COD_CLIENTE = COMISSOE.DCLCOMISSOES.COMISSOE_COD_CLIENTE.ToString(),
                COMISSOE_VAL_COMISSAO = COMISSOE.DCLCOMISSOES.COMISSOE_VAL_COMISSAO.ToString(),
                COMISSOE_DATA_CALCULO = COMISSOE.DCLCOMISSOES.COMISSOE_DATA_CALCULO.ToString(),
                COMISSOE_NUM_RECIBO = COMISSOE.DCLCOMISSOES.COMISSOE_NUM_RECIBO.ToString(),
                COMISSOE_VAL_BASICO = COMISSOE.DCLCOMISSOES.COMISSOE_VAL_BASICO.ToString(),
                COMISSOE_TIPO_COMISSAO = COMISSOE.DCLCOMISSOES.COMISSOE_TIPO_COMISSAO.ToString(),
                COMISSOE_QTD_PARCELAS = COMISSOE.DCLCOMISSOES.COMISSOE_QTD_PARCELAS.ToString(),
                COMISSOE_PCT_COM_CORRETOR = COMISSOE.DCLCOMISSOES.COMISSOE_PCT_COM_CORRETOR.ToString(),
                COMISSOE_PCT_DESC_PREMIO = COMISSOE.DCLCOMISSOES.COMISSOE_PCT_DESC_PREMIO.ToString(),
                COMISSOE_COD_SUBGRUPO = COMISSOE.DCLCOMISSOES.COMISSOE_COD_SUBGRUPO.ToString(),
                COMISSOE_DATA_MOVIMENTO = COMISSOE.DCLCOMISSOES.COMISSOE_DATA_MOVIMENTO.ToString(),
                VIND_DTMOVTO = VIND_DTMOVTO.ToString(),
                COMISSOE_DATA_SELECAO = COMISSOE.DCLCOMISSOES.COMISSOE_DATA_SELECAO.ToString(),
                VIND_DATSEL = VIND_DATSEL.ToString(),
                COMISSOE_COD_EMPRESA = COMISSOE.DCLCOMISSOES.COMISSOE_COD_EMPRESA.ToString(),
                VIND_CODEMP = VIND_CODEMP.ToString(),
                COMISSOE_COD_PREPOSTO = COMISSOE.DCLCOMISSOES.COMISSOE_COD_PREPOSTO.ToString(),
                VIND_CODPRP = VIND_CODPRP.ToString(),
                COMISSOE_NUM_BILHETE = COMISSOE.DCLCOMISSOES.COMISSOE_NUM_BILHETE.ToString(),
                VIND_NUMBIL = VIND_NUMBIL.ToString(),
                COMISSOE_VAL_VARMON = COMISSOE.DCLCOMISSOES.COMISSOE_VAL_VARMON.ToString(),
                VIND_VLVARMON = VIND_VLVARMON.ToString(),
                COMISSOE_DATA_QUITACAO = COMISSOE.DCLCOMISSOES.COMISSOE_DATA_QUITACAO.ToString(),
                VIND_DTQITBCO = VIND_DTQITBCO.ToString(),
            };

            M_5100_GERA_COMISSAO_DB_INSERT_1_Insert1.Execute(m_5100_GERA_COMISSAO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5100_FIM*/

        [StopWatch]
        /*" M-5500-00-SELECT-EMP-CAP-SECTION */
        private void M_5500_00_SELECT_EMP_CAP_SECTION()
        {
            /*" -3940- PERFORM M_5500_00_SELECT_EMP_CAP_DB_SELECT_1 */

            M_5500_00_SELECT_EMP_CAP_DB_SELECT_1();

            /*" -3943- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3944- DISPLAY 'R1000-00 (ERRO - SELECT PRODUTO )...' */
                _.Display($"R1000-00 (ERRO - SELECT PRODUTO )...");

                /*" -3945- DISPLAY 'PRODUTO: ' PROD-COD-PRODUTO */
                _.Display($"PRODUTO: {PROD_COD_PRODUTO}");

                /*" -3945- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-5500-00-SELECT-EMP-CAP-DB-SELECT-1 */
        public void M_5500_00_SELECT_EMP_CAP_DB_SELECT_1()
        {
            /*" -3940- EXEC SQL SELECT PR.COD_EMPRESA , PG.COD_EMPRESA_CAP INTO :PROD-COD-EMPRESA, :PARM-COD-EMPR-CAP FROM SEGUROS.PRODUTO PR, SEGUROS.PARAMETROS_GERAIS PG WHERE PR.COD_PRODUTO = :PROD-COD-PRODUTO AND PR.COD_EMPRESA = PG.COD_EMPRESA END-EXEC. */

            var m_5500_00_SELECT_EMP_CAP_DB_SELECT_1_Query1 = new M_5500_00_SELECT_EMP_CAP_DB_SELECT_1_Query1()
            {
                PROD_COD_PRODUTO = PROD_COD_PRODUTO.ToString(),
            };

            var executed_1 = M_5500_00_SELECT_EMP_CAP_DB_SELECT_1_Query1.Execute(m_5500_00_SELECT_EMP_CAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROD_COD_EMPRESA, PROD_COD_EMPRESA);
                _.Move(executed_1.PARM_COD_EMPR_CAP, PARM_COD_EMPR_CAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_5500_99_SAIDA*/

        [StopWatch]
        /*" R6000-00-TRATA-FC0001S */
        private void R6000_00_TRATA_FC0001S(bool isPerform = false)
        {
            /*" -3957- MOVE 'R6000-00-TRATA-FC0001S' TO PARAGRAFO. */
            _.Move("R6000-00-TRATA-FC0001S", WABEND.PARAGRAFO);

            /*" -3960- MOVE 'TRATA FC0001S' TO COMANDO. */
            _.Move("TRATA FC0001S", WABEND.COMANDO);

            /*" -3962- PERFORM R6290-00-INSERT-MOVFEDCA THRU R6290-99-SAIDA. */

            R6290_00_INSERT_MOVFEDCA(true);

            R6290_10_INSERT(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R6290_99_SAIDA*/


            /*" -3963- IF WTEM-MOVFEDCA EQUAL 'SIM' */

            if (WS_WORK_AREAS.WTEM_MOVFEDCA == "SIM")
            {

                /*" -3964- GO TO R6000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R6000_99_SAIDA*/ //GOTO
                return;

                /*" -3966- END-IF. */
            }


            /*" -3968- PERFORM R6300-00-INSERT-TITFEDCA THRU R6300-99-SAIDA. */

            R6300_00_INSERT_TITFEDCA(true);

            R6300_00_INSERT(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R6300_99_SAIDA*/


            /*" -3970- PERFORM R6400-00-INSERT-COMFEDCA THRU R6400-99-SAIDA. */

            R6400_00_INSERT_COMFEDCA(true);

            R6400_10_INSERT(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R6400_99_SAIDA*/


            /*" -3970- PERFORM R6500-00-INSERT-PARFEDCA THRU R6500-99-SAIDA. */

            R6500_00_INSERT_PARFEDCA(true);

            R6500_10_INSERT(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R6500_99_SAIDA*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6000_99_SAIDA*/

        [StopWatch]
        /*" R6290-00-INSERT-MOVFEDCA */
        private void R6290_00_INSERT_MOVFEDCA(bool isPerform = false)
        {
            /*" -3980- MOVE 'R6290-00-INSERT-MOVFEDCA' TO PARAGRAFO. */
            _.Move("R6290-00-INSERT-MOVFEDCA", WABEND.PARAGRAFO);

            /*" -3983- MOVE 'INSERE MOVFEDCA' TO COMANDO. */
            _.Move("INSERE MOVFEDCA", WABEND.COMANDO);

            /*" -3986- MOVE 'NAO' TO WTEM-MOVFEDCA. */
            _.Move("NAO", WS_WORK_AREAS.WTEM_MOVFEDCA);

            /*" -3989- MOVE 'SELECT COMUNIC_FED_CAP_VA' TO COMANDO. */
            _.Move("SELECT COMUNIC_FED_CAP_VA", WABEND.COMANDO);

            /*" -3994- PERFORM R6290_00_INSERT_MOVFEDCA_DB_SELECT_1 */

            R6290_00_INSERT_MOVFEDCA_DB_SELECT_1();

            /*" -3997- IF SQLCODE EQUAL ZEROS OR -811 */

            if (DB.SQLCODE.In("00", "-811"))
            {

                /*" -3999- MOVE 'SIM' TO WTEM-MOVFEDCA */
                _.Move("SIM", WS_WORK_AREAS.WTEM_MOVFEDCA);

                /*" -4000- GO TO R6290-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R6290_99_SAIDA*/ //GOTO
                return;

                /*" -4001- ELSE */
            }
            else
            {


                /*" -4003- IF SQLCODE EQUAL 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -4004- ELSE */
                }
                else
                {


                    /*" -4006- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -4008- INITIALIZE FC0001S-LINKAGE */
            _.Initialize(
                FC0001S_LINKAGE
            );

            /*" -4011- MOVE 809 TO FC0001S-NUM-PLANO */
            _.Move(809, FC0001S_LINKAGE.FC0001S_NUM_PLANO);

            /*" -4014- MOVE PROPVA-NRCERTIF TO FC0001S-NUM-PROPOSTA */
            _.Move(PROPVA_NRCERTIF, FC0001S_LINKAGE.FC0001S_NUM_PROPOSTA);

            /*" -4017- MOVE PRODVG-CUSTOCAP-TOTAL-9 TO FC0001S-VLR-MENSALIDADE */
            _.Move(PRODVG_CUSTOCAP_TOTAL_9, FC0001S_LINKAGE.FC0001S_VLR_MENSALIDADE);

            /*" -4019- CALL 'FC0001S' USING FC0001S-LINKAGE. */
            _.Call("FC0001S", FC0001S_LINKAGE);

            /*" -4020- IF FC0001S-COD-RETORNO NOT EQUAL ZEROS */

            if (FC0001S_LINKAGE.FC0001S_COD_RETORNO != 00)
            {

                /*" -4021- MOVE FC0001S-SQLCODE TO WS-SQLCODE */
                _.Move(FC0001S_LINKAGE.FC0001S_SQLCODE, WS_SQLCODE);

                /*" -4035- DISPLAY 'PROBLEMAS NO ACESSO A FC0001S ' ' ' FC0001S-NUM-PROPOSTA ' ' WS-SQLCODE ' ' FC0001S-DES-MENSAGEM ' ' FC0001S-VLR-MENSALIDADE ' ' FC0001S-NUM-PLANO ' ' FC0001S-NUM-SERIE ' ' FC0001S-NUM-TITULO ' ' FC0001S-IND-DV ' ' FC0001S-DTH-INI-VIGENCIA ' ' FC0001S-DTH-FIM-VIGENCIA ' ' FC0001S-DES-COMBINACAO ' ' FC0001S-SQLCODE ' ' FC0001S-COD-RETORNO */

                $"PROBLEMAS NO ACESSO A FC0001S  {FC0001S_LINKAGE.FC0001S_NUM_PROPOSTA} {WS_SQLCODE} {FC0001S_LINKAGE.FC0001S_DES_MENSAGEM} {FC0001S_LINKAGE.FC0001S_VLR_MENSALIDADE} {FC0001S_LINKAGE.FC0001S_NUM_PLANO} {FC0001S_LINKAGE.FC0001S_NUM_SERIE} {FC0001S_LINKAGE.FC0001S_NUM_TITULO} {FC0001S_LINKAGE.FC0001S_IND_DV} {FC0001S_LINKAGE.FC0001S_DTH_INI_VIGENCIA} {FC0001S_LINKAGE.FC0001S_DTH_FIM_VIGENCIA} {FC0001S_LINKAGE.FC0001S_DES_COMBINACAO} {FC0001S_LINKAGE.FC0001S_SQLCODE} {FC0001S_LINKAGE.FC0001S_COD_RETORNO}"
                .Display();

                /*" -4036- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -4038- END-IF. */
            }


            /*" -4040- MOVE FC0001S-NUM-PLANO TO WS-NUM-PLANO */
            _.Move(FC0001S_LINKAGE.FC0001S_NUM_PLANO, WS_NUM_TITULO_X.WS_NUM_PLANO);

            /*" -4042- MOVE FC0001S-NUM-SERIE TO WS-NUM-SERIE */
            _.Move(FC0001S_LINKAGE.FC0001S_NUM_SERIE, WS_NUM_TITULO_X.WS_NUM_SERIE);

            /*" -4044- MOVE FC0001S-NUM-TITULO TO WS-NUM-TITULO */
            _.Move(FC0001S_LINKAGE.FC0001S_NUM_TITULO, WS_NUM_TITULO_X.WS_NUM_TITULO);

            /*" -4046- MOVE WS-NUM-TITULO-9 TO MOVFEDCA-NRTITFDCAP. */
            _.Move(WS_NUM_TITULO_9, MOVFEDCA.DCLMOVIMEN_FED_CAP_VA.MOVFEDCA_NRTITFDCAP);

            /*" -4048- MOVE PRODVG-CUSTOCAP-TOTAL-9 TO MOVFEDCA-VAL-CUSTO-CAPITALI. */
            _.Move(PRODVG_CUSTOCAP_TOTAL_9, MOVFEDCA.DCLMOVIMEN_FED_CAP_VA.MOVFEDCA_VAL_CUSTO_CAPITALI);

        }

        [StopWatch]
        /*" R6290-00-INSERT-MOVFEDCA-DB-SELECT-1 */
        public void R6290_00_INSERT_MOVFEDCA_DB_SELECT_1()
        {
            /*" -3994- EXEC SQL SELECT SITUACAO INTO :COMFEDCA-SITUACAO FROM SEGUROS.COMUNIC_FED_CAP_VA WHERE NUM_CERTIFICADO = :PROPVA-NRCERTIF END-EXEC. */

            var r6290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1 = new R6290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = R6290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1.Execute(r6290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COMFEDCA_SITUACAO, COMFEDCA.DCLCOMUNIC_FED_CAP_VA.COMFEDCA_SITUACAO);
            }


        }

        [StopWatch]
        /*" R6290-10-INSERT */
        private void R6290_10_INSERT(bool isPerform = false)
        {
            /*" -4082- PERFORM R6290_10_INSERT_DB_INSERT_1 */

            R6290_10_INSERT_DB_INSERT_1();

            /*" -4085- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4086- DISPLAY 'R6290 - ERRO NO INSERT DA MOVFEDCA ' */
                _.Display($"R6290 - ERRO NO INSERT DA MOVFEDCA ");

                /*" -4087- DISPLAY 'NRO CERTIFICADO - ' PROPVA-NRCERTIF */
                _.Display($"NRO CERTIFICADO - {PROPVA_NRCERTIF}");

                /*" -4088- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -4088- END-IF. */
            }


        }

        [StopWatch]
        /*" R6290-10-INSERT-DB-INSERT-1 */
        public void R6290_10_INSERT_DB_INSERT_1()
        {
            /*" -4082- EXEC SQL INSERT INTO SEGUROS.MOVIMEN_FED_CAP_VA ( NUM_CERTIFICADO , COD_OPERACAO , COD_FONTE , NUM_PROPOSTA , DTMVFDCAP , NUM_PARCELA , QUANT_TIT_CAPITALI , VAL_CUSTO_CAPITALI , SITUACAO , NRTITFDCAP , NRMSCAP , NUM_SEQUENCIA , TIMESTAMP , CODPRODU ) VALUES ( :PROPVA-NRCERTIF , 1 , :PROPVA-FONTE , 0 , :SISTEMA-DTMOVABE , 0 , 1 , :MOVFEDCA-VAL-CUSTO-CAPITALI , '1' , :MOVFEDCA-NRTITFDCAP , 0 , 0 , CURRENT TIMESTAMP , :PRODVG-COD-PRODUTO ) END-EXEC. */

            var r6290_10_INSERT_DB_INSERT_1_Insert1 = new R6290_10_INSERT_DB_INSERT_1_Insert1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                PROPVA_FONTE = PROPVA_FONTE.ToString(),
                SISTEMA_DTMOVABE = SISTEMA_DTMOVABE.ToString(),
                MOVFEDCA_VAL_CUSTO_CAPITALI = MOVFEDCA.DCLMOVIMEN_FED_CAP_VA.MOVFEDCA_VAL_CUSTO_CAPITALI.ToString(),
                MOVFEDCA_NRTITFDCAP = MOVFEDCA.DCLMOVIMEN_FED_CAP_VA.MOVFEDCA_NRTITFDCAP.ToString(),
                PRODVG_COD_PRODUTO = PRODVG_COD_PRODUTO.ToString(),
            };

            R6290_10_INSERT_DB_INSERT_1_Insert1.Execute(r6290_10_INSERT_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6290_99_SAIDA*/

        [StopWatch]
        /*" R6300-00-INSERT-TITFEDCA */
        private void R6300_00_INSERT_TITFEDCA(bool isPerform = false)
        {
            /*" -4098- MOVE 'R6300-00-INSERT-TITFEDCA' TO PARAGRAFO. */
            _.Move("R6300-00-INSERT-TITFEDCA", WABEND.PARAGRAFO);

            /*" -4101- MOVE 'INSERE TITFEDCA' TO COMANDO. */
            _.Move("INSERE TITFEDCA", WABEND.COMANDO);

            /*" -4103- MOVE FC0001S-DTH-INI-VIGENCIA TO TITFEDCA-DATA-INIVIGENCIA */
            _.Move(FC0001S_LINKAGE.FC0001S_DTH_INI_VIGENCIA, TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_DATA_INIVIGENCIA);

            /*" -4105- MOVE FC0001S-DTH-FIM-VIGENCIA TO TITFEDCA-DATA-TERVIGENCIA */
            _.Move(FC0001S_LINKAGE.FC0001S_DTH_FIM_VIGENCIA, TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_DATA_TERVIGENCIA);

            /*" -4108- MOVE FC0001S-DES-COMBINACAO TO WS-COMBINACAO. */
            _.Move(FC0001S_LINKAGE.FC0001S_DES_COMBINACAO, WS_COMBINACAO);

            /*" -4111- PERFORM R6310-00-TRATA-COMBINACAO THRU R6310-99-SAIDA. */

            R6310_00_TRATA_COMBINACAO(true);

            R6310_10_LOOP(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R6310_99_SAIDA*/


            /*" -4114- MOVE WS-COMBINACAO-9 TO TITFEDCA-NRSORTEIO. */
            _.Move(WS_COMBINACAO_9, TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_NRSORTEIO);

            /*" -4116- MOVE PRODVG-CUSTOCAP-TOTAL-9 TO TITFEDCA-VAL-CUSTO-TITULO. */
            _.Move(PRODVG_CUSTOCAP_TOTAL_9, TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_VAL_CUSTO_TITULO);

        }

        [StopWatch]
        /*" R6300-00-INSERT */
        private void R6300_00_INSERT(bool isPerform = false)
        {
            /*" -4150- PERFORM R6300_00_INSERT_DB_INSERT_1 */

            R6300_00_INSERT_DB_INSERT_1();

            /*" -4153- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4154- DISPLAY '6300 - ERRO NO INSERT DA TITFEDCA ' */
                _.Display($"6300 - ERRO NO INSERT DA TITFEDCA ");

                /*" -4155- DISPLAY 'CERTIF = ' PROPVA-NRCERTIF */
                _.Display($"CERTIF = {PROPVA_NRCERTIF}");

                /*" -4156- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -4156- END-IF. */
            }


        }

        [StopWatch]
        /*" R6300-00-INSERT-DB-INSERT-1 */
        public void R6300_00_INSERT_DB_INSERT_1()
        {
            /*" -4150- EXEC SQL INSERT INTO SEGUROS.TITULOS_FED_CAP_VA ( NRTITFDCAP , NUM_CERTIFICADO , DATA_INIVIGENCIA , DATA_TERVIGENCIA , NRSORTEIO , VAL_CUSTO_TITULO , NRPARCEL , NRMFDCAPF , SITUACAO , SIT_RELAT , DATA_MOVIMENTO , TIMESTAMP , NRMFDCAPR , NRTITREN ) VALUES ( :MOVFEDCA-NRTITFDCAP , :PROPVA-NRCERTIF , :TITFEDCA-DATA-INIVIGENCIA , :TITFEDCA-DATA-TERVIGENCIA , :TITFEDCA-NRSORTEIO , :TITFEDCA-VAL-CUSTO-TITULO , 0 , 0 , '0' , '1' , :SISTEMA-DTMOVABE , CURRENT TIMESTAMP , 0 , 0 ) END-EXEC. */

            var r6300_00_INSERT_DB_INSERT_1_Insert1 = new R6300_00_INSERT_DB_INSERT_1_Insert1()
            {
                MOVFEDCA_NRTITFDCAP = MOVFEDCA.DCLMOVIMEN_FED_CAP_VA.MOVFEDCA_NRTITFDCAP.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                TITFEDCA_DATA_INIVIGENCIA = TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_DATA_INIVIGENCIA.ToString(),
                TITFEDCA_DATA_TERVIGENCIA = TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_DATA_TERVIGENCIA.ToString(),
                TITFEDCA_NRSORTEIO = TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_NRSORTEIO.ToString(),
                TITFEDCA_VAL_CUSTO_TITULO = TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_VAL_CUSTO_TITULO.ToString(),
                SISTEMA_DTMOVABE = SISTEMA_DTMOVABE.ToString(),
            };

            R6300_00_INSERT_DB_INSERT_1_Insert1.Execute(r6300_00_INSERT_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6300_99_SAIDA*/

        [StopWatch]
        /*" R6310-00-TRATA-COMBINACAO */
        private void R6310_00_TRATA_COMBINACAO(bool isPerform = false)
        {
            /*" -4166- MOVE 'R6310-00-TRATA-COMBINACAO' TO PARAGRAFO. */
            _.Move("R6310-00-TRATA-COMBINACAO", WABEND.PARAGRAFO);

            /*" -4169- MOVE 'TRATA COMBINACAO' TO COMANDO. */
            _.Move("TRATA COMBINACAO", WABEND.COMANDO);

            /*" -4170- MOVE ZEROS TO WIND. */
            _.Move(0, WIND);

        }

        [StopWatch]
        /*" R6310-10-LOOP */
        private void R6310_10_LOOP(bool isPerform = false)
        {
            /*" -4175- ADD 1 TO WIND. */
            WIND.Value = WIND + 1;

            /*" -4176- IF WIND GREATER 20 */

            if (WIND > 20)
            {

                /*" -4177- DISPLAY 'PROBLEMAS NO NUMERO DE SORTE' */
                _.Display($"PROBLEMAS NO NUMERO DE SORTE");

                /*" -4178- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -4180- END-IF. */
            }


            /*" -4181- IF WS-COMB(WIND) = ' ' */

            if (WS_COMBINACAO_R.WS_COMB[WIND] == " ")
            {

                /*" -4182- SUBTRACT 1 FROM WIND */
                WIND.Value = WIND - 1;

                /*" -4184- MOVE WS-COMBINACAO(1:WIND) TO WS-COMBINACAO-9 */
                _.Move(WS_COMBINACAO.Substring(1, WIND), WS_COMBINACAO_9);

                /*" -4185- ELSE */
            }
            else
            {


                /*" -4185- GO TO R6310-10-LOOP. */
                new Task(() => R6310_10_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6310_99_SAIDA*/

        [StopWatch]
        /*" R6400-00-INSERT-COMFEDCA */
        private void R6400_00_INSERT_COMFEDCA(bool isPerform = false)
        {
            /*" -4195- MOVE 'R6400-00-INSERT-COMFEDCA' TO PARAGRAFO. */
            _.Move("R6400-00-INSERT-COMFEDCA", WABEND.PARAGRAFO);

            /*" -4197- MOVE 'INSERT COMFEDCA' TO COMANDO. */
            _.Move("INSERT COMFEDCA", WABEND.COMANDO);

        }

        [StopWatch]
        /*" R6400-10-INSERT */
        private void R6400_10_INSERT(bool isPerform = false)
        {
            /*" -4212- PERFORM R6400_10_INSERT_DB_INSERT_1 */

            R6400_10_INSERT_DB_INSERT_1();

            /*" -4215- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4216- DISPLAY 'R6400 - ERRO NO INSERT DA TITFEDCA ' */
                _.Display($"R6400 - ERRO NO INSERT DA TITFEDCA ");

                /*" -4217- DISPLAY 'NRO CERTIFICADO - ' PROPVA-NRCERTIF */
                _.Display($"NRO CERTIFICADO - {PROPVA_NRCERTIF}");

                /*" -4218- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -4218- END-IF. */
            }


        }

        [StopWatch]
        /*" R6400-10-INSERT-DB-INSERT-1 */
        public void R6400_10_INSERT_DB_INSERT_1()
        {
            /*" -4212- EXEC SQL INSERT INTO SEGUROS.COMUNIC_FED_CAP_VA ( NUM_CERTIFICADO , SITUACAO , DATA_MOVIMENTO , TIMESTAMP ) VALUES ( :PROPVA-NRCERTIF , '0' , :SISTEMA-DTMOVABE, CURRENT TIMESTAMP ) END-EXEC. */

            var r6400_10_INSERT_DB_INSERT_1_Insert1 = new R6400_10_INSERT_DB_INSERT_1_Insert1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                SISTEMA_DTMOVABE = SISTEMA_DTMOVABE.ToString(),
            };

            R6400_10_INSERT_DB_INSERT_1_Insert1.Execute(r6400_10_INSERT_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6400_99_SAIDA*/

        [StopWatch]
        /*" R6500-00-INSERT-PARFEDCA */
        private void R6500_00_INSERT_PARFEDCA(bool isPerform = false)
        {
            /*" -4228- MOVE 'R6500-00-INSERT-PARFEDCA' TO PARAGRAFO. */
            _.Move("R6500-00-INSERT-PARFEDCA", WABEND.PARAGRAFO);

            /*" -4231- MOVE 'INSERT PARFEDCA' TO COMANDO. */
            _.Move("INSERT PARFEDCA", WABEND.COMANDO);

        }

        [StopWatch]
        /*" R6500-10-INSERT */
        private void R6500_10_INSERT(bool isPerform = false)
        {
            /*" -4237- MOVE PRODVG-CUSTOCAP-TOTAL-9 TO PARFEDCA-VAL-CUSTO-TITULO. */
            _.Move(PRODVG_CUSTOCAP_TOTAL_9, PARFEDCA.DCLPARCEL_FED_CAP_VA.PARFEDCA_VAL_CUSTO_TITULO);

            /*" -4256- PERFORM R6500_10_INSERT_DB_INSERT_1 */

            R6500_10_INSERT_DB_INSERT_1();

            /*" -4259- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4260- DISPLAY '6500 - ERRO NO INSERT DA COMFEDCA ' */
                _.Display($"6500 - ERRO NO INSERT DA COMFEDCA ");

                /*" -4261- DISPLAY 'CERTIF ' PROPVA-NRCERTIF */
                _.Display($"CERTIF {PROPVA_NRCERTIF}");

                /*" -4262- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -4263- END-IF. */
            }


        }

        [StopWatch]
        /*" R6500-10-INSERT-DB-INSERT-1 */
        public void R6500_10_INSERT_DB_INSERT_1()
        {
            /*" -4256- EXEC SQL INSERT INTO SEGUROS.PARCEL_FED_CAP_VA ( NRTITFDCAP , NUM_PARCELA , VAL_CUSTO_TITULO , DTFATUR , DATA_MOVIMENTO , SITUACAO , NRMFDCAP , TIMESTAMP ) VALUES ( :MOVFEDCA-NRTITFDCAP , 0 , :PARFEDCA-VAL-CUSTO-TITULO , :SISTEMA-DTMOVABE , :SISTEMA-DTMOVABE , '1' , 0 , CURRENT TIMESTAMP ) END-EXEC. */

            var r6500_10_INSERT_DB_INSERT_1_Insert1 = new R6500_10_INSERT_DB_INSERT_1_Insert1()
            {
                MOVFEDCA_NRTITFDCAP = MOVFEDCA.DCLMOVIMEN_FED_CAP_VA.MOVFEDCA_NRTITFDCAP.ToString(),
                PARFEDCA_VAL_CUSTO_TITULO = PARFEDCA.DCLPARCEL_FED_CAP_VA.PARFEDCA_VAL_CUSTO_TITULO.ToString(),
                SISTEMA_DTMOVABE = SISTEMA_DTMOVABE.ToString(),
            };

            R6500_10_INSERT_DB_INSERT_1_Insert1.Execute(r6500_10_INSERT_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6500_99_SAIDA*/

        [StopWatch]
        /*" R7000-00-TRATA-FC0105B */
        private void R7000_00_TRATA_FC0105B(bool isPerform = false)
        {
            /*" -4273- MOVE 'R7000-00-TRATA-FC0105B' TO PARAGRAFO. */
            _.Move("R7000-00-TRATA-FC0105B", WABEND.PARAGRAFO);

            /*" -4276- MOVE 'TRATA FC0105B' TO COMANDO. */
            _.Move("TRATA FC0105B", WABEND.COMANDO);

            /*" -4278- PERFORM R7290-00-INSERT-MOVFEDCA THRU R7290-99-SAIDA. */

            R7290_00_INSERT_MOVFEDCA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R7290_99_SAIDA*/


            /*" -4280- IF (WTEM-MOVFEDCA EQUAL 'SIM' ) OR (LK-OUT-COD-RETORNO NOT EQUAL ZEROS) */

            if ((WS_WORK_AREAS.WTEM_MOVFEDCA == "SIM") || (LK_OUT_COD_RETORNO != 00))
            {

                /*" -4281- GO TO R7000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R7000_99_SAIDA*/ //GOTO
                return;

                /*" -4283- END-IF. */
            }


            /*" -4283- PERFORM R7400-00-INSERT-COMFEDCA THRU R7400-99-SAIDA. */

            R7400_00_INSERT_COMFEDCA(true);

            R7400_10_INSERT(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R7400_99_SAIDA*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7000_99_SAIDA*/

        [StopWatch]
        /*" R7290-00-INSERT-MOVFEDCA */
        private void R7290_00_INSERT_MOVFEDCA(bool isPerform = false)
        {
            /*" -4293- MOVE 'R7290-00-INSERT-MOVFEDCA' TO PARAGRAFO. */
            _.Move("R7290-00-INSERT-MOVFEDCA", WABEND.PARAGRAFO);

            /*" -4296- MOVE 'INSERE MOVFEDCA' TO COMANDO. */
            _.Move("INSERE MOVFEDCA", WABEND.COMANDO);

            /*" -4299- MOVE 'NAO' TO WTEM-MOVFEDCA. */
            _.Move("NAO", WS_WORK_AREAS.WTEM_MOVFEDCA);

            /*" -4302- MOVE 'SELECT COMUNIC_FED_CAP_VA' TO COMANDO. */
            _.Move("SELECT COMUNIC_FED_CAP_VA", WABEND.COMANDO);

            /*" -4307- PERFORM R7290_00_INSERT_MOVFEDCA_DB_SELECT_1 */

            R7290_00_INSERT_MOVFEDCA_DB_SELECT_1();

            /*" -4310- IF SQLCODE EQUAL ZEROS OR -811 */

            if (DB.SQLCODE.In("00", "-811"))
            {

                /*" -4312- MOVE 'SIM' TO WTEM-MOVFEDCA */
                _.Move("SIM", WS_WORK_AREAS.WTEM_MOVFEDCA);

                /*" -4313- GO TO R7290-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R7290_99_SAIDA*/ //GOTO
                return;

                /*" -4314- ELSE */
            }
            else
            {


                /*" -4316- IF SQLCODE EQUAL 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -4317- ELSE */
                }
                else
                {


                    /*" -4319- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -4334- INITIALIZE LK-NUM-PLANO LK-NUM-SERIE LK-NUM-TITULO LK-NUM-PROPOSTA LK-QTD-TITULOS LK-VLR-TITULO LK-EMP-PARCEIRA LK-COD-RAMO LK-TRACE LK-OUT-COD-RETORNO LK-OUT-SQLCODE LK-OUT-MENSAGEM LK-OUT-SQLERRMC LK-OUT-SQLSTATE */
            _.Initialize(
                LK_NUM_PLANO
                , LK_NUM_SERIE
                , LK_NUM_TITULO
                , LK_NUM_PROPOSTA
                , LK_QTD_TITULOS
                , LK_VLR_TITULO
                , LK_EMP_PARCEIRA
                , LK_COD_RAMO
                , LK_TRACE
                , LK_OUT_COD_RETORNO
                , LK_OUT_SQLCODE
                , LK_OUT_MENSAGEM
                , LK_OUT_SQLERRMC
                , LK_OUT_SQLSTATE
            );

            /*" -4337- MOVE PRODVG-COD-RUBRICA TO LK-NUM-PLANO */
            _.Move(PRODVG_COD_RUBRICA, LK_NUM_PLANO);

            /*" -4340- MOVE PROPVA-NRCERTIF TO LK-NUM-PROPOSTA */
            _.Move(PROPVA_NRCERTIF, LK_NUM_PROPOSTA);

            /*" -4343- MOVE COBERP-QTTITCAP TO LK-QTD-TITULOS */
            _.Move(COBERP_QTTITCAP, LK_QTD_TITULOS);

            /*" -4346- MOVE COBERP-VLCUSTCAP TO LK-VLR-TITULO */
            _.Move(COBERP_VLCUSTCAP, LK_VLR_TITULO);

            /*" -4348- MOVE PRODVG-COD-PRODUTO TO PROD-COD-PRODUTO. */
            _.Move(PRODVG_COD_PRODUTO, PROD_COD_PRODUTO);

            /*" -4351- PERFORM 5500-00-SELECT-EMP-CAP. */

            M_5500_00_SELECT_EMP_CAP_SECTION();

            /*" -4353- MOVE PARM-COD-EMPR-CAP TO LK-EMP-PARCEIRA. */
            _.Move(PARM_COD_EMPR_CAP, LK_EMP_PARCEIRA);

            /*" -4356- MOVE PRODVG-COD-PRODUTO TO LK-COD-RAMO */
            _.Move(PRODVG_COD_PRODUTO, LK_COD_RAMO);

            /*" -4359- MOVE 'TRACE OFF' TO LK-TRACE */
            _.Move("TRACE OFF", LK_TRACE);

            /*" -4375- CALL 'FC0105B' USING LK-NUM-PLANO , LK-NUM-SERIE , LK-NUM-TITULO , LK-NUM-PROPOSTA , LK-QTD-TITULOS , LK-VLR-TITULO , LK-EMP-PARCEIRA , LK-COD-RAMO , LK-TRACE , LK-OUT-COD-RETORNO , LK-OUT-SQLCODE , LK-OUT-MENSAGEM , LK-OUT-SQLERRMC , LK-OUT-SQLSTATE . */
            _.Call("FC0105B", LK_NUM_PLANO, LK_NUM_SERIE, LK_NUM_TITULO, LK_NUM_PROPOSTA, LK_QTD_TITULOS, LK_VLR_TITULO, LK_EMP_PARCEIRA, LK_COD_RAMO, LK_TRACE, LK_OUT_COD_RETORNO, LK_OUT_SQLCODE, LK_OUT_MENSAGEM, LK_OUT_SQLERRMC, LK_OUT_SQLSTATE, RCAPS.DCLRCAPS);

            /*" -4376- IF LK-OUT-COD-RETORNO NOT EQUAL ZEROS */

            if (LK_OUT_COD_RETORNO != 00)
            {

                /*" -4377- MOVE LK-OUT-SQLCODE TO WS-SQLCODE */
                _.Move(LK_OUT_SQLCODE, WS_SQLCODE);

                /*" -4393- DISPLAY 'PROBLEMAS NO ACESSO A FC0105B ' ' ' LK-NUM-PLANO ' ' LK-NUM-SERIE ' ' LK-NUM-TITULO ' ' LK-NUM-PROPOSTA ' ' LK-QTD-TITULOS ' ' LK-VLR-TITULO ' ' LK-EMP-PARCEIRA ' ' LK-COD-RAMO ' ' LK-TRACE ' ' LK-OUT-COD-RETORNO ' ' LK-OUT-SQLCODE ' ' LK-OUT-MENSAGEM ' ' LK-OUT-SQLERRMC ' ' LK-OUT-SQLSTATE ' ' WS-SQLCODE */

                $"PROBLEMAS NO ACESSO A FC0105B  {LK_NUM_PLANO} {LK_NUM_SERIE} {LK_NUM_TITULO} {LK_NUM_PROPOSTA} {LK_QTD_TITULOS} {LK_VLR_TITULO} {LK_EMP_PARCEIRA} {LK_COD_RAMO} {LK_TRACE} {LK_OUT_COD_RETORNO} {LK_OUT_SQLCODE} {LK_OUT_MENSAGEM} {LK_OUT_SQLERRMC} {LK_OUT_SQLSTATE} {WS_SQLCODE}"
                .Display();

                /*" -4393- END-IF. */
            }


        }

        [StopWatch]
        /*" R7290-00-INSERT-MOVFEDCA-DB-SELECT-1 */
        public void R7290_00_INSERT_MOVFEDCA_DB_SELECT_1()
        {
            /*" -4307- EXEC SQL SELECT SITUACAO INTO :COMFEDCA-SITUACAO FROM SEGUROS.COMUNIC_FED_CAP_VA WHERE NUM_CERTIFICADO = :PROPVA-NRCERTIF END-EXEC. */

            var r7290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1 = new R7290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = R7290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1.Execute(r7290_00_INSERT_MOVFEDCA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COMFEDCA_SITUACAO, COMFEDCA.DCLCOMUNIC_FED_CAP_VA.COMFEDCA_SITUACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7290_99_SAIDA*/

        [StopWatch]
        /*" R7400-00-INSERT-COMFEDCA */
        private void R7400_00_INSERT_COMFEDCA(bool isPerform = false)
        {
            /*" -4403- MOVE 'R7400-00-INSERT-COMFEDCA' TO PARAGRAFO. */
            _.Move("R7400-00-INSERT-COMFEDCA", WABEND.PARAGRAFO);

            /*" -4403- MOVE 'INSERT COMFEDCA' TO COMANDO. */
            _.Move("INSERT COMFEDCA", WABEND.COMANDO);

        }

        [StopWatch]
        /*" R7400-10-INSERT */
        private void R7400_10_INSERT(bool isPerform = false)
        {
            /*" -4420- PERFORM R7400_10_INSERT_DB_INSERT_1 */

            R7400_10_INSERT_DB_INSERT_1();

            /*" -4423- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4424- DISPLAY 'R7400 - ERRO NO INSERT DA TITFEDCA ' */
                _.Display($"R7400 - ERRO NO INSERT DA TITFEDCA ");

                /*" -4425- DISPLAY 'NRO CERTIFICADO - ' PROPVA-NRCERTIF */
                _.Display($"NRO CERTIFICADO - {PROPVA_NRCERTIF}");

                /*" -4426- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -4426- END-IF. */
            }


        }

        [StopWatch]
        /*" R7400-10-INSERT-DB-INSERT-1 */
        public void R7400_10_INSERT_DB_INSERT_1()
        {
            /*" -4420- EXEC SQL INSERT INTO SEGUROS.COMUNIC_FED_CAP_VA ( NUM_CERTIFICADO , SITUACAO , DATA_MOVIMENTO , TIMESTAMP ) VALUES ( :PROPVA-NRCERTIF , '0' , :SISTEMA-DTMOVABE, CURRENT TIMESTAMP ) END-EXEC. */

            var r7400_10_INSERT_DB_INSERT_1_Insert1 = new R7400_10_INSERT_DB_INSERT_1_Insert1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                SISTEMA_DTMOVABE = SISTEMA_DTMOVABE.ToString(),
            };

            R7400_10_INSERT_DB_INSERT_1_Insert1.Execute(r7400_10_INSERT_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7400_99_SAIDA*/

        [StopWatch]
        /*" M-8000-INTEGRA-VG */
        private void M_8000_INTEGRA_VG(bool isPerform = false)
        {
            /*" -4439- MOVE 101 TO MCODOPER. */
            _.Move(101, MCODOPER);

            /*" -4440- MOVE '8000-INTEGRA-VG       ' TO PARAGRAFO. */
            _.Move("8000-INTEGRA-VG       ", WABEND.PARAGRAFO);

            /*" -4442- MOVE 'SELECT V0CONDTEC' TO COMANDO. */
            _.Move("SELECT V0CONDTEC", WABEND.COMANDO);

            /*" -4450- PERFORM M_8000_INTEGRA_VG_DB_SELECT_1 */

            M_8000_INTEGRA_VG_DB_SELECT_1();

            /*" -4453- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4456- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -4457- MOVE MDTMOVTO TO W02DTSQL. */
            _.Move(MDTMOVTO, WS_WORK_AREAS.W02DTSQL);

            /*" -4458- MOVE SISTEMA-DTMOVABE TO W03DTSQL. */
            _.Move(SISTEMA_DTMOVABE, WS_WORK_AREAS.W03DTSQL);

            /*" -4460- MOVE 01 TO W03DTSQL(9:2). */
            _.MoveAtPosition(01, WS_WORK_AREAS.W03DTSQL, 9, 2);

            /*" -4461- IF W02AAMMSQL > W03AAMMSQL */

            if (WS_WORK_AREAS.W02DTSQL.W02AAMMSQL > WS_WORK_AREAS.W03DTSQL.W03AAMMSQL)
            {

                /*" -4462- MOVE 01 TO W02DDSQL */
                _.Move(01, WS_WORK_AREAS.W02DTSQL.W02DDSQL);

                /*" -4463- MOVE W02DTSQL TO MDTREF */
                _.Move(WS_WORK_AREAS.W02DTSQL, MDTREF);

                /*" -4464- ELSE */
            }
            else
            {


                /*" -4466- MOVE W03DTSQL TO MDTREF. */
                _.Move(WS_WORK_AREAS.W03DTSQL, MDTREF);
            }


            /*" -4468- MOVE 'SELECT V0CLIENTE' TO COMANDO. */
            _.Move("SELECT V0CLIENTE", WABEND.COMANDO);

            /*" -4474- PERFORM M_8000_INTEGRA_VG_DB_SELECT_2 */

            M_8000_INTEGRA_VG_DB_SELECT_2();

            /*" -4477- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4478- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -4480- END-IF */
            }


            /*" -4483- IF PROPVA-CODPRODU NOT = 7725 AND JVPRD7725 AND 7732 AND JVPRD7732 AND 7733 AND JVPRD7733 */

            if (!PROPVA_CODPRODU.In("7725", JVBKINCL.JV_PRODUTOS.JVPRD7725.ToString(), "7732", JVBKINCL.JV_PRODUTOS.JVPRD7732.ToString(), "7733", JVBKINCL.JV_PRODUTOS.JVPRD7733.ToString()))
            {

                /*" -4484- IF CLIENT-DTNASC-I LESS ZEROES */

                if (CLIENT_DTNASC_I < 00)
                {

                    /*" -4485- DISPLAY 'CLIENTE SEM DATA DE NASCIMENTO' */
                    _.Display($"CLIENTE SEM DATA DE NASCIMENTO");

                    /*" -4486- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -4487- END-IF */
                }


                /*" -4489- END-IF */
            }


            /*" -4491- PERFORM 8500-CALC-PROP-AUTOM THRU 8500-FIM. */

            M_8500_CALC_PROP_AUTOM(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8500_FIM*/


            /*" -4495- IF INDAGE < 0 OR INDOPR < 0 OR INDNUM < 0 OR INDDIG < 0 */

            if (INDAGE < 0 || INDOPR < 0 || INDNUM < 0 || INDDIG < 0)
            {

                /*" -4496- MOVE PROPVA-AGECOBR TO MAGECOBR */
                _.Move(PROPVA_AGECOBR, MAGECOBR);

                /*" -4497- MOVE 0 TO MNUM-CTA-CORRENTE */
                _.Move(0, MNUM_CTA_CORRENTE);

                /*" -4498- MOVE ' ' TO MDAC-CTA-CORRENTE */
                _.Move(" ", MDAC_CTA_CORRENTE);

                /*" -4499- ELSE */
            }
            else
            {


                /*" -4500- MOVE OPCAOP-AGECTADEB TO MAGECOBR */
                _.Move(OPCAOP_AGECTADEB, MAGECOBR);

                /*" -4501- MOVE OPCAOP-OPRCTADEB TO WS-OPER-SEG */
                _.Move(OPCAOP_OPRCTADEB, WS_WORK_AREAS.WS_CTA_CORRENTE_R.WS_OPER_SEG);

                /*" -4502- MOVE OPCAOP-NUMCTADEB TO WS-CTA-SEG */
                _.Move(OPCAOP_NUMCTADEB, WS_WORK_AREAS.WS_CTA_CORRENTE_R.WS_CTA_SEG);

                /*" -4503- MOVE WS-CTA-CORRENTE TO MNUM-CTA-CORRENTE */
                _.Move(WS_WORK_AREAS.WS_CTA_CORRENTE, MNUM_CTA_CORRENTE);

                /*" -4504- MOVE OPCAOP-DIGCTADEB TO W01N0100 */
                _.Move(OPCAOP_DIGCTADEB, WS_WORK_AREAS.W01A0100.W01N0100);

                /*" -4506- MOVE W01A0100 TO MDAC-CTA-CORRENTE. */
                _.Move(WS_WORK_AREAS.W01A0100, MDAC_CTA_CORRENTE);
            }


            /*" -4507- MOVE '8000-INTEGRA-VG           ' TO PARAGRAFO. */
            _.Move("8000-INTEGRA-VG           ", WABEND.PARAGRAFO);

            /*" -4510- MOVE 'SELECT V0PLANOSVA' TO COMANDO. */
            _.Move("SELECT V0PLANOSVA", WABEND.COMANDO);

            /*" -4511- IF PROPVA-DTMOVTO < PROPVA-DTQITBCO */

            if (PROPVA_DTMOVTO < PROPVA_DTQITBCO)
            {

                /*" -4512- MOVE PROPVA-DTMOVTO TO WHOST-DTINIVIG */
                _.Move(PROPVA_DTMOVTO, WHOST_DTINIVIG);

                /*" -4513- ELSE */
            }
            else
            {


                /*" -4515- MOVE PROPVA-DTQITBCO TO WHOST-DTINIVIG. */
                _.Move(PROPVA_DTQITBCO, WHOST_DTINIVIG);
            }


            /*" -4517- PERFORM R7771-00-LER-PROP-SIVPF */

            R7771_00_LER_PROP_SIVPF(true);

            /*" -4520- IF PROPVA-CODPRODU NOT = 7725 AND JVPRD7725 AND 7732 AND JVPRD7732 AND 7733 AND JVPRD7733 */

            if (!PROPVA_CODPRODU.In("7725", JVBKINCL.JV_PRODUTOS.JVPRD7725.ToString(), "7732", JVBKINCL.JV_PRODUTOS.JVPRD7732.ToString(), "7733", JVBKINCL.JV_PRODUTOS.JVPRD7733.ToString()))
            {

                /*" -4521- IF PARAMRAM-NUM-RAMO-PRSTMISTA EQUAL V1APOL-RAMO */

                if (PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_NUM_RAMO_PRSTMISTA == V1APOL_RAMO)
                {

                    /*" -4522- IF NOVO-CALCULO-PREMIO */

                    if (WS_WORK_AREAS.W_NOVO_CALCULO["NOVO_CALCULO_PREMIO"])
                    {

                        /*" -4523- IF PROPVA-COD-OPER-CREDITO = 19 */

                        if (PROPVA_COD_OPER_CREDITO == 19)
                        {

                            /*" -4524- MOVE PROPVA-DTQITBCO TO WHOST-DTINIVIG */
                            _.Move(PROPVA_DTQITBCO, WHOST_DTINIVIG);

                            /*" -4525- END-IF */
                        }


                        /*" -4544- PERFORM M_8000_INTEGRA_VG_DB_SELECT_3 */

                        M_8000_INTEGRA_VG_DB_SELECT_3();

                        /*" -4546- ELSE */
                    }
                    else
                    {


                        /*" -4547- IF PROPVA-COD-OPER-CREDITO = 19 */

                        if (PROPVA_COD_OPER_CREDITO == 19)
                        {

                            /*" -4548- MOVE PROPVA-DTQITBCO TO WHOST-DTINIVIG */
                            _.Move(PROPVA_DTQITBCO, WHOST_DTINIVIG);

                            /*" -4549- END-IF */
                        }


                        /*" -4569- PERFORM M_8000_INTEGRA_VG_DB_SELECT_4 */

                        M_8000_INTEGRA_VG_DB_SELECT_4();

                        /*" -4571- END-IF */
                    }


                    /*" -4572- ELSE */
                }
                else
                {


                    /*" -4573- IF PROPVA-COD-OPER-CREDITO = 19 */

                    if (PROPVA_COD_OPER_CREDITO == 19)
                    {

                        /*" -4574- MOVE PROPVA-DTQITBCO TO WHOST-DTINIVIG */
                        _.Move(PROPVA_DTQITBCO, WHOST_DTINIVIG);

                        /*" -4575- END-IF */
                    }


                    /*" -4594- PERFORM M_8000_INTEGRA_VG_DB_SELECT_5 */

                    M_8000_INTEGRA_VG_DB_SELECT_5();

                    /*" -4597- END-IF. */
                }

            }


            /*" -4599- MOVE SQLCODE TO WSQLCODE-PLANOS. */
            _.Move(DB.SQLCODE, WS_WORK_AREAS.WSQLCODE_PLANOS);

            /*" -4600- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -4601- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4602- IF PRODVG-SITPLANCEF EQUAL 'N' */

                    if (PRODVG_SITPLANCEF == "N")
                    {

                        /*" -4605- MOVE 0 TO MFAIXA MTXVG MTXAPMA */
                        _.Move(0, MFAIXA, MTXVG, MTXAPMA);

                        /*" -4606- ELSE */
                    }
                    else
                    {


                        /*" -4617- DISPLAY '8000- PLANO NAO ENCONTRADO *' ' ' PROPVA-NRCERTIF ' ' PROPVA-NUM-APOLICE ' ' PROPVA-CODSUBES ' ' PROPVA-OPCAO-COBER ' ' WHOST-DTINIVIG ' ' CLIENT-DTNASC ' ' PROPVA-IDADE ' ' OPCAOP-PERIPGTO ' ' COBERP-VLPREMIO '****************************' */

                        $"8000- PLANO NAO ENCONTRADO * {PROPVA_NRCERTIF} {PROPVA_NUM_APOLICE} {PROPVA_CODSUBES} {PROPVA_OPCAO_COBER} {WHOST_DTINIVIG} {CLIENT_DTNASC} {PROPVA_IDADE} {OPCAOP_PERIPGTO} {COBERP_VLPREMIO}****************************"
                        .Display();

                        /*" -4618- GO TO 8000-FIM */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8000_FIM*/ //GOTO
                        return;

                        /*" -4619- ELSE */
                    }

                }
                else
                {


                    /*" -4620- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -4621- IF PROPVA-CODPRODU = 7725 OR JVPRD7725 */

            if (PROPVA_CODPRODU.In("7725", JVBKINCL.JV_PRODUTOS.JVPRD7725.ToString()))
            {

                /*" -4622- PERFORM 8001-PEGAR-TAXA-7725 THRU 8001-FIM */

                M_8001_PEGAR_TAXA_7725(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8001_FIM*/


                /*" -4624- END-IF */
            }


            /*" -4626- IF PROPVA-CODPRODU = 7732 OR JVPRD7732 OR 7733 OR JVPRD7733 */

            if (PROPVA_CODPRODU.In("7732", JVBKINCL.JV_PRODUTOS.JVPRD7732.ToString(), "7733", JVBKINCL.JV_PRODUTOS.JVPRD7733.ToString()))
            {

                /*" -4627- INITIALIZE MTXAPMA MTXAPIP MTXVG MMFAIXA */
                _.Initialize(
                    MTXAPMA
                    , MTXAPIP
                    , MTXVG
                    , MMFAIXA
                );

                /*" -4628- ELSE */
            }
            else
            {


                /*" -4629- COMPUTE MTXAPIP = MTXAPMA / 2 */
                MTXAPIP.Value = MTXAPMA / 2f;

                /*" -4631- COMPUTE MTXAPMA = MTXAPMA - MTXAPIP */
                MTXAPMA.Value = MTXAPMA - MTXAPIP;

                /*" -4632- PERFORM 8110-COUNT-BENEFICIARIOS THRU 8110-FIM */

                M_8110_COUNT_BENEFICIARIOS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8110_FIM*/


                /*" -4634- END-IF */
            }


            /*" -4635- IF WHOST-COUNT EQUAL ZEROS */

            if (WHOST_COUNT == 00)
            {

                /*" -4636- MOVE ZEROS TO WS-CONT-BENEF */
                _.Move(0, WS_WORK_AREAS.WS_CONT_BENEF);

                /*" -4637- ELSE */
            }
            else
            {


                /*" -4639- MOVE 1 TO WS-CONT-BENEF. */
                _.Move(1, WS_WORK_AREAS.WS_CONT_BENEF);
            }


            /*" -4640- IF WS-CONT-BENEF EQUAL ZEROS */

            if (WS_WORK_AREAS.WS_CONT_BENEF == 00)
            {

                /*" -4641- MOVE 'S' TO MTPBENEF */
                _.Move("S", MTPBENEF);

                /*" -4642- ELSE */
            }
            else
            {


                /*" -4644- MOVE 'N' TO MTPBENEF. */
                _.Move("N", MTPBENEF);
            }


            /*" -4645- IF COBERP-IMPMORNATU NOT EQUAL 0 */

            if (COBERP_IMPMORNATU != 0)
            {

                /*" -4647- COMPUTE COBERP-IMPMORACID = COBERP-IMPMORACID - COBERP-IMPMORNATU */
                COBERP_IMPMORACID.Value = COBERP_IMPMORACID - COBERP_IMPMORNATU;

                /*" -4649- COMPUTE COBERP-IMPMORACID = COBERP-IMPMORACID - (COBERP-IMPMORNATU * CONDTE-IEA) / 100 */
                COBERP_IMPMORACID.Value = COBERP_IMPMORACID - (COBERP_IMPMORNATU * CONDTE_IEA) / 100f;

                /*" -4652- COMPUTE COBERP-IMPINVPERM = COBERP-IMPINVPERM - (COBERP-IMPMORNATU * CONDTE-IPA) / 100. */
                COBERP_IMPINVPERM.Value = COBERP_IMPINVPERM - (COBERP_IMPMORNATU * CONDTE_IPA) / 100f;
            }


            /*" -4653- IF COBERP-PRMAP EQUAL 0 */

            if (COBERP_PRMAP == 0)
            {

                /*" -4654- COMPUTE COBERP-IMPMORACID = 0 */
                COBERP_IMPMORACID.Value = 0;

                /*" -4654- COMPUTE COBERP-IMPINVPERM = 0. */
                COBERP_IMPINVPERM.Value = 0;
            }


        }

        [StopWatch]
        /*" M-8000-INTEGRA-VG-DB-SELECT-1 */
        public void M_8000_INTEGRA_VG_DB_SELECT_1()
        {
            /*" -4450- EXEC SQL SELECT GARAN_ADIC_IEA, GARAN_ADIC_IPA INTO :CONDTE-IEA, :CONDTE-IPA FROM SEGUROS.V0CONDTEC WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE AND COD_SUBGRUPO = :PROPVA-CODSUBES END-EXEC. */

            var m_8000_INTEGRA_VG_DB_SELECT_1_Query1 = new M_8000_INTEGRA_VG_DB_SELECT_1_Query1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
            };

            var executed_1 = M_8000_INTEGRA_VG_DB_SELECT_1_Query1.Execute(m_8000_INTEGRA_VG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONDTE_IEA, CONDTE_IEA);
                _.Move(executed_1.CONDTE_IPA, CONDTE_IPA);
            }


        }

        [StopWatch]
        /*" R8000-PROPAUTOM */
        private void R8000_PROPAUTOM(bool isPerform = false)
        {
            /*" -4660- IF PROPVA-NUM-APOLICE = 109300000635 AND PROPVA-CODSUBES = 1 */

            if (PROPVA_NUM_APOLICE == 109300000635 && PROPVA_CODSUBES == 1)
            {

                /*" -4661- MOVE COBERP-DTINIVIG TO MMDTMOVTO */
                _.Move(COBERP_DTINIVIG, MMDTMOVTO);

                /*" -4662- MOVE COBERP-DTTERVIG TO WSISTEMA-DTMOVABE */
                _.Move(COBERP_DTTERVIG, WSISTEMA_DTMOVABE);

                /*" -4663- MOVE PROPVA-COD-CRM TO MMNUM-MATRICULA */
                _.Move(PROPVA_COD_CRM, MMNUM_MATRICULA);

                /*" -4664- MOVE V0COBER-MINOCOR TO MMFAIXA */
                _.Move(V0COBER_MINOCOR, MMFAIXA);

                /*" -4665- ELSE */
            }
            else
            {


                /*" -4666- MOVE MDTMOVTO TO MMDTMOVTO */
                _.Move(MDTMOVTO, MMDTMOVTO);

                /*" -4667- MOVE SISTEMA-DTMOVABE TO WSISTEMA-DTMOVABE */
                _.Move(SISTEMA_DTMOVABE, WSISTEMA_DTMOVABE);

                /*" -4668- MOVE MNUM-MATRICULA TO MMNUM-MATRICULA */
                _.Move(MNUM_MATRICULA, MMNUM_MATRICULA);

                /*" -4669- MOVE MFAIXA TO MMFAIXA */
                _.Move(MFAIXA, MMFAIXA);

                /*" -4671- END-IF */
            }


            /*" -4673- MOVE 101 TO MCODOPER. */
            _.Move(101, MCODOPER);

            /*" -4674- MOVE '8000-INTEGRA-VG           ' TO PARAGRAFO. */
            _.Move("8000-INTEGRA-VG           ", WABEND.PARAGRAFO);

            /*" -4677- MOVE 'INSERT V0MOVIMENTO' TO COMANDO. */
            _.Move("INSERT V0MOVIMENTO", WABEND.COMANDO);

            /*" -4679- IF PROPVA-CODPRODU = 7732 OR JVPRD7732 OR 7733 OR JVPRD7733 */

            if (PROPVA_CODPRODU.In("7732", JVBKINCL.JV_PRODUTOS.JVPRD7732.ToString(), "7733", JVBKINCL.JV_PRODUTOS.JVPRD7733.ToString()))
            {

                /*" -4756- PERFORM R8000_PROPAUTOM_DB_INSERT_1 */

                R8000_PROPAUTOM_DB_INSERT_1();

                /*" -4758- ELSE */
            }
            else
            {


                /*" -4835- PERFORM R8000_PROPAUTOM_DB_INSERT_2 */

                R8000_PROPAUTOM_DB_INSERT_2();

                /*" -4839- END-IF */
            }


            /*" -4840- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -4843- IF (SQLCODE EQUAL -803) AND (PROPVA-INRPROPOS LESS 0 OR PROPVA-NRPROPOS EQUAL 0) */

                if ((DB.SQLCODE == -803) && (PROPVA_INRPROPOS < 0 || PROPVA_NRPROPOS == 0))
                {

                    /*" -4844- ADD 1 TO FONTE-PROPAUTOM */
                    FONTE_PROPAUTOM.Value = FONTE_PROPAUTOM + 1;

                    /*" -4845- GO TO R8000-PROPAUTOM */
                    new Task(() => R8000_PROPAUTOM()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -4846- ELSE */
                }
                else
                {


                    /*" -4847- DISPLAY 'R8000-PROPAUTOM (ERRO INSERT V0MOVIMENTO)' */
                    _.Display($"R8000-PROPAUTOM (ERRO INSERT V0MOVIMENTO)");

                    /*" -4848- DISPLAY 'CERTIFICADO      = ' PROPVA-NRCERTIF */
                    _.Display($"CERTIFICADO      = {PROPVA_NRCERTIF}");

                    /*" -4849- DISPLAY 'PROPAUTOM        = ' FONTE-PROPAUTOM */
                    _.Display($"PROPAUTOM        = {FONTE_PROPAUTOM}");

                    /*" -4850- DISPLAY 'FONTE            = ' PROPVA-FONTE */
                    _.Display($"FONTE            = {PROPVA_FONTE}");

                    /*" -4851- DISPLAY 'SISTEMA-DTMOVABE = ' SISTEMA-DTMOVABE */
                    _.Display($"SISTEMA-DTMOVABE = {SISTEMA_DTMOVABE}");

                    /*" -4852- DISPLAY 'WSISTEMA-DTMOVABE= ' WSISTEMA-DTMOVABE */
                    _.Display($"WSISTEMA-DTMOVABE= {WSISTEMA_DTMOVABE}");

                    /*" -4853- DISPLAY 'PROPVA-DTADMIS   = ' PROPVA-DTADMIS */
                    _.Display($"PROPVA-DTADMIS   = {PROPVA_DTADMIS}");

                    /*" -4854- DISPLAY 'PROPVA-IDTADMIS  = ' PROPVA-IDTADMIS */
                    _.Display($"PROPVA-IDTADMIS  = {PROPVA_IDTADMIS}");

                    /*" -4855- DISPLAY 'CLIENT-DTNASC    = ' CLIENT-DTNASC */
                    _.Display($"CLIENT-DTNASC    = {CLIENT_DTNASC}");

                    /*" -4856- DISPLAY 'DATA REFERENCIA  = ' MDTREF */
                    _.Display($"DATA REFERENCIA  = {MDTREF}");

                    /*" -4857- DISPLAY 'MMDTMOVTO        = ' MMDTMOVTO */
                    _.Display($"MMDTMOVTO        = {MMDTMOVTO}");

                    /*" -4858- DISPLAY '--- CAMPOS DE DATA --------------------' */
                    _.Display($"--- CAMPOS DE DATA --------------------");

                    /*" -4859- DISPLAY 'WSISTEMA-DTMOVABE = ' WSISTEMA-DTMOVABE */
                    _.Display($"WSISTEMA-DTMOVABE = {WSISTEMA_DTMOVABE}");

                    /*" -4860- DISPLAY 'SISTEMA-DTMOVABE  = ' SISTEMA-DTMOVABE */
                    _.Display($"SISTEMA-DTMOVABE  = {SISTEMA_DTMOVABE}");

                    /*" -4861- DISPLAY 'PROPVA-IDTADMIS   = ' PROPVA-IDTADMIS */
                    _.Display($"PROPVA-IDTADMIS   = {PROPVA_IDTADMIS}");

                    /*" -4862- DISPLAY 'PROPVA-DTADMIS    = ' PROPVA-DTADMIS */
                    _.Display($"PROPVA-DTADMIS    = {PROPVA_DTADMIS}");

                    /*" -4863- DISPLAY 'CLIENT-DTNASC     = ' CLIENT-DTNASC */
                    _.Display($"CLIENT-DTNASC     = {CLIENT_DTNASC}");

                    /*" -4864- DISPLAY 'MDTREF            = ' MDTREF */
                    _.Display($"MDTREF            = {MDTREF}");

                    /*" -4865- DISPLAY 'MMDTMOVTO         = ' MMDTMOVTO */
                    _.Display($"MMDTMOVTO         = {MMDTMOVTO}");

                    /*" -4866- DISPLAY '---------------------------------------' */
                    _.Display($"---------------------------------------");

                    /*" -4868- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -4870- PERFORM 8100-MONTA-BENEFICIARIOS THRU 8100-FIM. */

            M_8100_MONTA_BENEFICIARIOS(true);

            M_8100_LOOP(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8100_FIM*/


            /*" -4872- MOVE 'UPDATE V0FONTE' TO COMANDO. */
            _.Move("UPDATE V0FONTE", WABEND.COMANDO);

            /*" -4874- IF PROPVA-INRPROPOS LESS 0 OR PROPVA-NRPROPOS EQUAL 0 */

            if (PROPVA_INRPROPOS < 0 || PROPVA_NRPROPOS == 0)
            {

                /*" -4879- PERFORM R8000_PROPAUTOM_DB_UPDATE_1 */

                R8000_PROPAUTOM_DB_UPDATE_1();

                /*" -4881- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -4883- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -4885- IF PRODVG-ORIG-PRODU = 'MULT' OR 'GLOBAL' OR 'VIDAZUL' AND PROPVA-NUM-APOLICE NOT EQUAL 109300000635 */

            if (PRODVG_ORIG_PRODU.In("MULT", "GLOBAL", "VIDAZUL") && PROPVA_NUM_APOLICE != 109300000635)
            {

                /*" -4886- IF PROPVA-CODCCT EQUAL ZEROS */

                if (PROPVA_CODCCT == 00)
                {

                    /*" -4887- MOVE 'UPDATE V0PARCELVA' TO COMANDO */
                    _.Move("UPDATE V0PARCELVA", WABEND.COMANDO);

                    /*" -4894- PERFORM R8000_PROPAUTOM_DB_UPDATE_2 */

                    R8000_PROPAUTOM_DB_UPDATE_2();

                    /*" -4896- IF SQLCODE NOT EQUAL ZEROES */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -4898- GO TO 9999-ERRO. */

                        M_9999_ERRO(); //GOTO
                        return;
                    }

                }

            }


            /*" -4901- IF PRODVG-ORIG-PRODU = 'MULT' OR 'GLOBAL' OR 'VIDAZUL' AND PROPVA-CODCCT EQUAL ZEROS AND COBERP-VLPREMIO = V0HCOB-VLPRMTOT */

            if (PRODVG_ORIG_PRODU.In("MULT", "GLOBAL", "VIDAZUL") && PROPVA_CODCCT == 00 && COBERP_VLPREMIO == V0HCOB_VLPRMTOT)
            {

                /*" -4903- MOVE 'UPDATE V0HISTCONTABILVA' TO COMANDO */
                _.Move("UPDATE V0HISTCONTABILVA", WABEND.COMANDO);

                /*" -4911- PERFORM R8000_PROPAUTOM_DB_UPDATE_3 */

                R8000_PROPAUTOM_DB_UPDATE_3();

                /*" -4914- IF SQLCODE NOT = ZEROS AND SQLCODE NOT = 100 */

                if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
                {

                    /*" -4915- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -4916- END-IF */
                }


                /*" -4917- ELSE */
            }
            else
            {


                /*" -4920- IF PRODVG-ORIG-PRODU = 'MULT' OR 'GLOBAL' AND PROPVA-CODCCT EQUAL ZEROS AND COBERP-VLPREMIO NOT = V0HCOB-VLPRMTOT */

                if (PRODVG_ORIG_PRODU.In("MULT", "GLOBAL") && PROPVA_CODCCT == 00 && COBERP_VLPREMIO != V0HCOB_VLPRMTOT)
                {

                    /*" -4922- PERFORM 8880-ACERTA-DIF-PREMIO THRU 8880-FIM. */

                    M_8880_ACERTA_DIF_PREMIO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8880_FIM*/

                }

            }


            /*" -4923- IF PRODVG-ORIG-PRODU = ( 'CAMP' ) */

            if (PRODVG_ORIG_PRODU == ("CAMP"))
            {

                /*" -4924- MOVE 'SELECT V0HISTCOBVA' TO COMANDO */
                _.Move("SELECT V0HISTCOBVA", WABEND.COMANDO);

                /*" -4930- PERFORM R8000_PROPAUTOM_DB_SELECT_1 */

                R8000_PROPAUTOM_DB_SELECT_1();

                /*" -4932- IF SQLCODE = ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -4934- COMPUTE COBERP-VLPREMIO = COBERP-VLPREMIO * (1 - PRODVG-DESCONTO-ADESAO) */
                    COBERP_VLPREMIO.Value = COBERP_VLPREMIO * (1 - PRODVG_DESCONTO_ADESAO);

                    /*" -4936- COMPUTE COBERP-PRMVG = COBERP-PRMVG * (1 - PRODVG-DESCONTO-ADESAO) */
                    COBERP_PRMVG.Value = COBERP_PRMVG * (1 - PRODVG_DESCONTO_ADESAO);

                    /*" -4937- COMPUTE COBERP-PRMAP = V0HCOB-VLPRMTOT - COBERP-PRMVG */
                    COBERP_PRMAP.Value = V0HCOB_VLPRMTOT - COBERP_PRMVG;

                    /*" -4938- MOVE 'UPDATE V0HISTCONTABILVA' TO COMANDO */
                    _.Move("UPDATE V0HISTCONTABILVA", WABEND.COMANDO);

                    /*" -4946- PERFORM R8000_PROPAUTOM_DB_UPDATE_4 */

                    R8000_PROPAUTOM_DB_UPDATE_4();

                    /*" -4949- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

                    if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
                    {

                        /*" -4950- GO TO 9999-ERRO */

                        M_9999_ERRO(); //GOTO
                        return;

                        /*" -4951- ELSE */
                    }
                    else
                    {


                        /*" -4953- MOVE 'UPDATE V0PARCELVA' TO COMANDO */
                        _.Move("UPDATE V0PARCELVA", WABEND.COMANDO);

                        /*" -4960- PERFORM R8000_PROPAUTOM_DB_UPDATE_5 */

                        R8000_PROPAUTOM_DB_UPDATE_5();

                        /*" -4962- IF SQLCODE NOT EQUAL ZEROES */

                        if (DB.SQLCODE != 00)
                        {

                            /*" -4963- GO TO 9999-ERRO */

                            M_9999_ERRO(); //GOTO
                            return;

                            /*" -4964- END-IF */
                        }


                        /*" -4965- IF COBERP-VLPREMIO NOT = V0HCOB-VLPRMTOT */

                        if (COBERP_VLPREMIO != V0HCOB_VLPRMTOT)
                        {

                            /*" -4966- PERFORM 8880-ACERTA-DIF-PREMIO THRU 8880-FIM */

                            M_8880_ACERTA_DIF_PREMIO(true);
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8880_FIM*/


                            /*" -4967- END-IF */
                        }


                        /*" -4968- ELSE */
                    }

                }
                else
                {


                    /*" -4970- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -4972- IF PRODVG-TEM-CDG = 'S' AND COBERP-VLCUSTCDG NOT EQUAL 0 */

            if (PRODVG_TEM_CDG == "S" && COBERP_VLCUSTCDG != 0)
            {

                /*" -4974- PERFORM 8200-CONCEDE-CDG THRU 8200-FIM. */

                M_8200_CONCEDE_CDG(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8200_FIM*/

            }


            /*" -4976- IF PRODVG-TEM-SAF = 'S' AND COBERP-VLCUSTAUXF GREATER 0 */

            if (PRODVG_TEM_SAF == "S" && COBERP_VLCUSTAUXF > 0)
            {

                /*" -4978- PERFORM 8300-CONCEDE-SAF THRU 8300-FIM. */

                M_8300_CONCEDE_SAF(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8300_FIM*/

            }


            /*" -4979- IF PROPVA-CODOPER EQUAL ZEROS */

            if (PROPVA_CODOPER == 00)
            {

                /*" -4981- MOVE 101 TO PROPVA-CODOPER. */
                _.Move(101, PROPVA_CODOPER);
            }


            /*" -4983- MOVE '3' TO PROPVA-SITUACAO. */
            _.Move("3", PROPVA_SITUACAO);

            /*" -4985- MOVE 'SELECT V0COMISICOBVA' TO COMANDO. */
            _.Move("SELECT V0COMISICOBVA", WABEND.COMANDO);

            /*" -4992- PERFORM R8000_PROPAUTOM_DB_SELECT_2 */

            R8000_PROPAUTOM_DB_SELECT_2();

            /*" -4995- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -4997- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -4998- IF PRODVG-ORIG-PRODU = 'PAREN' OR 'CEF DEB CC' */

            if (PRODVG_ORIG_PRODU.In("PAREN", "CEF DEB CC"))
            {

                /*" -5014- GO TO 8000-FIM. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8000_FIM*/ //GOTO
                return;
            }


            /*" -5015- IF PROPVA-ORIGEM-PROPOSTA NOT EQUAL 12 AND NOT EQUAL 1000 */

            if (!PROPVA_ORIGEM_PROPOSTA.In("12", "1000"))
            {

                /*" -5015- PERFORM 8800-APROPRIA-FUNDO THRU 8800-FIM. */

                M_8800_APROPRIA_FUNDO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8800_FIM*/

            }


        }

        [StopWatch]
        /*" R8000-PROPAUTOM-DB-INSERT-1 */
        public void R8000_PROPAUTOM_DB_INSERT_1()
        {
            /*" -4756- EXEC SQL INSERT INTO SEGUROS.V0MOVIMENTO VALUES (:PROPVA-NUM-APOLICE, :PROPVA-CODSUBES, :PROPVA-FONTE, :FONTE-PROPAUTOM, '1' , :PROPVA-NRCERTIF, ' ' , :MTPINCLUS, :PROPVA-CODCLIEN, :MAGENCIADOR, 0, 0, 0, :MMFAIXA, 'S' , :MTPBENEF, :OPCAOP-PERIPGTO, 12, ' ' , :PROPVA-EST-CIV, :PROPVA-SEXO, 0, ' ' , 1, 1, 104, :MAGECOBR, ' ' , :MMNUM-MATRICULA, :MNUM-CTA-CORRENTE, :MDAC-CTA-CORRENTE, 0, ' ' , '1' , 0, 0, 0, 0, 0, :MTXAPMA, :MTXAPIP, 0, 0, 0, :MTXVG, 0, :COBERP-IMPMORNATU, 0, :COBERP-IMPMORACID, 0, :COBERP-IMPINVPERM, 0, :COBERP-IMPAMDS, 0, :COBERP-IMPDH, 0, :COBERP-IMPDIT, 0, :COBERP-PRMVG, 0, :COBERP-PRMAP, :MCODOPER, :SISTEMA-DTMOVABE, 0, '1' , :PROPVA-CODUSU, :WSISTEMA-DTMOVABE, NULL, NULL, :CLIENT-DTNASC, NULL, :MDTREF, :MMDTMOVTO, NULL, NULL) END-EXEC */

            var r8000_PROPAUTOM_DB_INSERT_1_Insert1 = new R8000_PROPAUTOM_DB_INSERT_1_Insert1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
                PROPVA_FONTE = PROPVA_FONTE.ToString(),
                FONTE_PROPAUTOM = FONTE_PROPAUTOM.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                MTPINCLUS = MTPINCLUS.ToString(),
                PROPVA_CODCLIEN = PROPVA_CODCLIEN.ToString(),
                MAGENCIADOR = MAGENCIADOR.ToString(),
                MMFAIXA = MMFAIXA.ToString(),
                MTPBENEF = MTPBENEF.ToString(),
                OPCAOP_PERIPGTO = OPCAOP_PERIPGTO.ToString(),
                PROPVA_EST_CIV = PROPVA_EST_CIV.ToString(),
                PROPVA_SEXO = PROPVA_SEXO.ToString(),
                MAGECOBR = MAGECOBR.ToString(),
                MMNUM_MATRICULA = MMNUM_MATRICULA.ToString(),
                MNUM_CTA_CORRENTE = MNUM_CTA_CORRENTE.ToString(),
                MDAC_CTA_CORRENTE = MDAC_CTA_CORRENTE.ToString(),
                MTXAPMA = MTXAPMA.ToString(),
                MTXAPIP = MTXAPIP.ToString(),
                MTXVG = MTXVG.ToString(),
                COBERP_IMPMORNATU = COBERP_IMPMORNATU.ToString(),
                COBERP_IMPMORACID = COBERP_IMPMORACID.ToString(),
                COBERP_IMPINVPERM = COBERP_IMPINVPERM.ToString(),
                COBERP_IMPAMDS = COBERP_IMPAMDS.ToString(),
                COBERP_IMPDH = COBERP_IMPDH.ToString(),
                COBERP_IMPDIT = COBERP_IMPDIT.ToString(),
                COBERP_PRMVG = COBERP_PRMVG.ToString(),
                COBERP_PRMAP = COBERP_PRMAP.ToString(),
                MCODOPER = MCODOPER.ToString(),
                SISTEMA_DTMOVABE = SISTEMA_DTMOVABE.ToString(),
                PROPVA_CODUSU = PROPVA_CODUSU.ToString(),
                WSISTEMA_DTMOVABE = WSISTEMA_DTMOVABE.ToString(),
                CLIENT_DTNASC = CLIENT_DTNASC.ToString(),
                MDTREF = MDTREF.ToString(),
                MMDTMOVTO = MMDTMOVTO.ToString(),
            };

            R8000_PROPAUTOM_DB_INSERT_1_Insert1.Execute(r8000_PROPAUTOM_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" M-8000-INTEGRA-VG-DB-SELECT-2 */
        public void M_8000_INTEGRA_VG_DB_SELECT_2()
        {
            /*" -4474- EXEC SQL SELECT DATA_NASCIMENTO INTO :CLIENT-DTNASC:CLIENT-DTNASC-I FROM SEGUROS.V0CLIENTE WHERE COD_CLIENTE = :PROPVA-CODCLIEN WITH UR END-EXEC. */

            var m_8000_INTEGRA_VG_DB_SELECT_2_Query1 = new M_8000_INTEGRA_VG_DB_SELECT_2_Query1()
            {
                PROPVA_CODCLIEN = PROPVA_CODCLIEN.ToString(),
            };

            var executed_1 = M_8000_INTEGRA_VG_DB_SELECT_2_Query1.Execute(m_8000_INTEGRA_VG_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENT_DTNASC, CLIENT_DTNASC);
                _.Move(executed_1.CLIENT_DTNASC_I, CLIENT_DTNASC_I);
            }


        }

        [StopWatch]
        /*" R8000-PROPAUTOM-DB-UPDATE-1 */
        public void R8000_PROPAUTOM_DB_UPDATE_1()
        {
            /*" -4879- EXEC SQL UPDATE SEGUROS.V0FONTE SET PROPAUTOM = :FONTE-PROPAUTOM, TIMESTAMP = CURRENT TIMESTAMP WHERE FONTE = :PROPVA-FONTE END-EXEC */

            var r8000_PROPAUTOM_DB_UPDATE_1_Update1 = new R8000_PROPAUTOM_DB_UPDATE_1_Update1()
            {
                FONTE_PROPAUTOM = FONTE_PROPAUTOM.ToString(),
                PROPVA_FONTE = PROPVA_FONTE.ToString(),
            };

            R8000_PROPAUTOM_DB_UPDATE_1_Update1.Execute(r8000_PROPAUTOM_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R8000-PROPAUTOM-DB-INSERT-2 */
        public void R8000_PROPAUTOM_DB_INSERT_2()
        {
            /*" -4835- EXEC SQL INSERT INTO SEGUROS.V0MOVIMENTO VALUES (:PROPVA-NUM-APOLICE, :PROPVA-CODSUBES, :PROPVA-FONTE, :FONTE-PROPAUTOM, '1' , :PROPVA-NRCERTIF, ' ' , :MTPINCLUS, :PROPVA-CODCLIEN, :MAGENCIADOR, 0, 0, 0, :MMFAIXA, 'S' , :MTPBENEF, :OPCAOP-PERIPGTO, 12, ' ' , :PROPVA-EST-CIV, :PROPVA-SEXO, 0, ' ' , 1, 1, 104, :MAGECOBR, ' ' , :MMNUM-MATRICULA, :MNUM-CTA-CORRENTE, :MDAC-CTA-CORRENTE, 0, ' ' , '1' , 0, 0, 0, 0, 0, :MTXAPMA, :MTXAPIP, 0, 0, 0, :MTXVG, 0, :COBERP-IMPMORNATU, 0, :COBERP-IMPMORACID, 0, :COBERP-IMPINVPERM, 0, :COBERP-IMPAMDS, 0, :COBERP-IMPDH, 0, :COBERP-IMPDIT, 0, :COBERP-PRMVG, 0, :COBERP-PRMAP, :MCODOPER, :SISTEMA-DTMOVABE, 0, '1' , :PROPVA-CODUSU, :WSISTEMA-DTMOVABE, :PROPVA-DTADMIS:PROPVA-IDTADMIS, NULL, :CLIENT-DTNASC, NULL, :MDTREF, :MMDTMOVTO, NULL, NULL) END-EXEC */

            var r8000_PROPAUTOM_DB_INSERT_2_Insert1 = new R8000_PROPAUTOM_DB_INSERT_2_Insert1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
                PROPVA_FONTE = PROPVA_FONTE.ToString(),
                FONTE_PROPAUTOM = FONTE_PROPAUTOM.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                MTPINCLUS = MTPINCLUS.ToString(),
                PROPVA_CODCLIEN = PROPVA_CODCLIEN.ToString(),
                MAGENCIADOR = MAGENCIADOR.ToString(),
                MMFAIXA = MMFAIXA.ToString(),
                MTPBENEF = MTPBENEF.ToString(),
                OPCAOP_PERIPGTO = OPCAOP_PERIPGTO.ToString(),
                PROPVA_EST_CIV = PROPVA_EST_CIV.ToString(),
                PROPVA_SEXO = PROPVA_SEXO.ToString(),
                MAGECOBR = MAGECOBR.ToString(),
                MMNUM_MATRICULA = MMNUM_MATRICULA.ToString(),
                MNUM_CTA_CORRENTE = MNUM_CTA_CORRENTE.ToString(),
                MDAC_CTA_CORRENTE = MDAC_CTA_CORRENTE.ToString(),
                MTXAPMA = MTXAPMA.ToString(),
                MTXAPIP = MTXAPIP.ToString(),
                MTXVG = MTXVG.ToString(),
                COBERP_IMPMORNATU = COBERP_IMPMORNATU.ToString(),
                COBERP_IMPMORACID = COBERP_IMPMORACID.ToString(),
                COBERP_IMPINVPERM = COBERP_IMPINVPERM.ToString(),
                COBERP_IMPAMDS = COBERP_IMPAMDS.ToString(),
                COBERP_IMPDH = COBERP_IMPDH.ToString(),
                COBERP_IMPDIT = COBERP_IMPDIT.ToString(),
                COBERP_PRMVG = COBERP_PRMVG.ToString(),
                COBERP_PRMAP = COBERP_PRMAP.ToString(),
                MCODOPER = MCODOPER.ToString(),
                SISTEMA_DTMOVABE = SISTEMA_DTMOVABE.ToString(),
                PROPVA_CODUSU = PROPVA_CODUSU.ToString(),
                WSISTEMA_DTMOVABE = WSISTEMA_DTMOVABE.ToString(),
                PROPVA_DTADMIS = PROPVA_DTADMIS.ToString(),
                PROPVA_IDTADMIS = PROPVA_IDTADMIS.ToString(),
                CLIENT_DTNASC = CLIENT_DTNASC.ToString(),
                MDTREF = MDTREF.ToString(),
                MMDTMOVTO = MMDTMOVTO.ToString(),
            };

            R8000_PROPAUTOM_DB_INSERT_2_Insert1.Execute(r8000_PROPAUTOM_DB_INSERT_2_Insert1);

        }

        [StopWatch]
        /*" R8000-PROPAUTOM-DB-UPDATE-2 */
        public void R8000_PROPAUTOM_DB_UPDATE_2()
        {
            /*" -4894- EXEC SQL UPDATE SEGUROS.V0PARCELVA SET PRMVG = :COBERP-PRMVG, PRMAP = :COBERP-PRMAP, TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :PROPVA-NRCERTIF AND NRPARCEL = 1 END-EXEC */

            var r8000_PROPAUTOM_DB_UPDATE_2_Update1 = new R8000_PROPAUTOM_DB_UPDATE_2_Update1()
            {
                COBERP_PRMVG = COBERP_PRMVG.ToString(),
                COBERP_PRMAP = COBERP_PRMAP.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            R8000_PROPAUTOM_DB_UPDATE_2_Update1.Execute(r8000_PROPAUTOM_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R8000-PROPAUTOM-DB-SELECT-1 */
        public void R8000_PROPAUTOM_DB_SELECT_1()
        {
            /*" -4930- EXEC SQL SELECT VLPRMTOT INTO :V0HCOB-VLPRMTOT FROM SEGUROS.V0HISTCOBVA WHERE NRCERTIF = :PROPVA-NRCERTIF AND NRPARCEL = 1 END-EXEC */

            var r8000_PROPAUTOM_DB_SELECT_1_Query1 = new R8000_PROPAUTOM_DB_SELECT_1_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = R8000_PROPAUTOM_DB_SELECT_1_Query1.Execute(r8000_PROPAUTOM_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HCOB_VLPRMTOT, V0HCOB_VLPRMTOT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8000_FIM*/

        [StopWatch]
        /*" R8000-PROPAUTOM-DB-UPDATE-3 */
        public void R8000_PROPAUTOM_DB_UPDATE_3()
        {
            /*" -4911- EXEC SQL UPDATE SEGUROS.V0HISTCONTABILVA SET PRMVG = :COBERP-PRMVG, PRMAP = :COBERP-PRMAP, TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :PROPVA-NRCERTIF AND NRPARCEL = 1 AND SITUACAO = '0' END-EXEC */

            var r8000_PROPAUTOM_DB_UPDATE_3_Update1 = new R8000_PROPAUTOM_DB_UPDATE_3_Update1()
            {
                COBERP_PRMVG = COBERP_PRMVG.ToString(),
                COBERP_PRMAP = COBERP_PRMAP.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            R8000_PROPAUTOM_DB_UPDATE_3_Update1.Execute(r8000_PROPAUTOM_DB_UPDATE_3_Update1);

        }

        [StopWatch]
        /*" M-8000-INTEGRA-VG-DB-SELECT-3 */
        public void M_8000_INTEGRA_VG_DB_SELECT_3()
        {
            /*" -4544- EXEC SQL SELECT FAIXA, TAXAVG, TAXAAP INTO :MFAIXA, :MTXVG, :MTXAPMA FROM SEGUROS.PLANOS_VA_VGAP WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE AND CODSUBES = :PROPVA-CODSUBES AND OPCAO_COBER = ' ' AND COD_PLANO = :SIVPF-COD-PLANO AND DTINIVIG <= :WHOST-DTINIVIG AND DTTERVIG >= :WHOST-DTINIVIG AND IDADE_INICIAL <= :PROPVA-IDADE AND IDADE_FINAL >= :PROPVA-IDADE AND PERIPGTO = :OPCAOP-PERIPGTO AND IMPMORNATU = 0 WITH UR END-EXEC */

            var m_8000_INTEGRA_VG_DB_SELECT_3_Query1 = new M_8000_INTEGRA_VG_DB_SELECT_3_Query1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
                SIVPF_COD_PLANO = SIVPF_COD_PLANO.ToString(),
                OPCAOP_PERIPGTO = OPCAOP_PERIPGTO.ToString(),
                WHOST_DTINIVIG = WHOST_DTINIVIG.ToString(),
                PROPVA_IDADE = PROPVA_IDADE.ToString(),
            };

            var executed_1 = M_8000_INTEGRA_VG_DB_SELECT_3_Query1.Execute(m_8000_INTEGRA_VG_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MFAIXA, MFAIXA);
                _.Move(executed_1.MTXVG, MTXVG);
                _.Move(executed_1.MTXAPMA, MTXAPMA);
            }


        }

        [StopWatch]
        /*" R8000-PROPAUTOM-DB-SELECT-2 */
        public void R8000_PROPAUTOM_DB_SELECT_2()
        {
            /*" -4992- EXEC SQL SELECT VALADT INTO :COMISI-VALADT FROM SEGUROS.V0COMISICOBVA WHERE NRCERTIF = :PROPVA-NRCERTIF AND SITUACAO <> '3' WITH UR END-EXEC. */

            var r8000_PROPAUTOM_DB_SELECT_2_Query1 = new R8000_PROPAUTOM_DB_SELECT_2_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = R8000_PROPAUTOM_DB_SELECT_2_Query1.Execute(r8000_PROPAUTOM_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COMISI_VALADT, COMISI_VALADT);
            }


        }

        [StopWatch]
        /*" R8000-PROPAUTOM-DB-UPDATE-4 */
        public void R8000_PROPAUTOM_DB_UPDATE_4()
        {
            /*" -4946- EXEC SQL UPDATE SEGUROS.V0HISTCONTABILVA SET PRMVG = :COBERP-PRMVG, PRMAP = :COBERP-PRMAP, TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :PROPVA-NRCERTIF AND NRPARCEL = 1 AND SITUACAO = '0' END-EXEC */

            var r8000_PROPAUTOM_DB_UPDATE_4_Update1 = new R8000_PROPAUTOM_DB_UPDATE_4_Update1()
            {
                COBERP_PRMVG = COBERP_PRMVG.ToString(),
                COBERP_PRMAP = COBERP_PRMAP.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            R8000_PROPAUTOM_DB_UPDATE_4_Update1.Execute(r8000_PROPAUTOM_DB_UPDATE_4_Update1);

        }

        [StopWatch]
        /*" M-8001-PEGAR-TAXA-7725 */
        private void M_8001_PEGAR_TAXA_7725(bool isPerform = false)
        {
            /*" -5023- MOVE '8001-PEGAR-TAXA-7725' TO PARAGRAFO. */
            _.Move("8001-PEGAR-TAXA-7725", WABEND.PARAGRAFO);

            /*" -5040- PERFORM M_8001_PEGAR_TAXA_7725_DB_SELECT_1 */

            M_8001_PEGAR_TAXA_7725_DB_SELECT_1();

            /*" -5043- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -5044- DISPLAY '------------------------------------------' */
                _.Display($"------------------------------------------");

                /*" -5046- DISPLAY '8001- PLANO NAO ENCONTRADO DO PRODUTO ' PROPVA-CODPRODU */
                _.Display($"8001- PLANO NAO ENCONTRADO DO PRODUTO {PROPVA_CODPRODU}");

                /*" -5047- DISPLAY 'NUM_APOLICE      =    ' PROPVA-NUM-APOLICE */
                _.Display($"NUM_APOLICE      =    {PROPVA_NUM_APOLICE}");

                /*" -5048- DISPLAY 'COD_PLANO        =    ' SIVPF-COD-PLANO */
                _.Display($"COD_PLANO        =    {SIVPF_COD_PLANO}");

                /*" -5049- DISPLAY 'DTINIVIG         =    ' PROPVA-DTQITBCO */
                _.Display($"DTINIVIG         =    {PROPVA_DTQITBCO}");

                /*" -5050- DISPLAY 'NUM-CERTIFICADO  =    ' PROPVA-NRCERTIF */
                _.Display($"NUM-CERTIFICADO  =    {PROPVA_NRCERTIF}");

                /*" -5051- DISPLAY '------------------------------------------' */
                _.Display($"------------------------------------------");

                /*" -5052- GO TO 8000-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8000_FIM*/ //GOTO
                return;

                /*" -5054- END-IF. */
            }


            /*" -5056- MOVE SQLCODE TO WS-SQLCODE */
            _.Move(DB.SQLCODE, WS_SQLCODE);

            /*" -5057- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5058- DISPLAY '------------------------------------------' */
                _.Display($"------------------------------------------");

                /*" -5059- DISPLAY 'ERRO NO ACESSO A SEGUROS.PLANOS_VA_VGAP' */
                _.Display($"ERRO NO ACESSO A SEGUROS.PLANOS_VA_VGAP");

                /*" -5060- DISPLAY 'SQLCODE          =    ' WS-SQLCODE */
                _.Display($"SQLCODE          =    {WS_SQLCODE}");

                /*" -5061- DISPLAY 'NUM_APOLICE      =    ' PROPVA-NUM-APOLICE */
                _.Display($"NUM_APOLICE      =    {PROPVA_NUM_APOLICE}");

                /*" -5062- DISPLAY 'COD_PLANO        =    ' SIVPF-COD-PLANO */
                _.Display($"COD_PLANO        =    {SIVPF_COD_PLANO}");

                /*" -5063- DISPLAY 'DTINIVIG         =    ' PROPVA-DTQITBCO */
                _.Display($"DTINIVIG         =    {PROPVA_DTQITBCO}");

                /*" -5064- DISPLAY 'NUM-CERTIFICADO  =    ' PROPVA-NRCERTIF */
                _.Display($"NUM-CERTIFICADO  =    {PROPVA_NRCERTIF}");

                /*" -5065- DISPLAY '------------------------------------------' */
                _.Display($"------------------------------------------");

                /*" -5066- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -5066- END-IF. */
            }


        }

        [StopWatch]
        /*" M-8001-PEGAR-TAXA-7725-DB-SELECT-1 */
        public void M_8001_PEGAR_TAXA_7725_DB_SELECT_1()
        {
            /*" -5040- EXEC SQL SELECT FAIXA, TAXAVG, TAXAAP INTO :MFAIXA, :MTXVG, :MTXAPMA FROM SEGUROS.PLANOS_VA_VGAP WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE AND CODSUBES = 1 AND OPCAO_COBER = ' ' AND COD_PLANO = :SIVPF-COD-PLANO AND DTINIVIG <= :PROPVA-DTQITBCO AND DTTERVIG >= :PROPVA-DTQITBCO AND IDADE_INICIAL <= 18 AND IDADE_FINAL >= 18 WITH UR END-EXEC. */

            var m_8001_PEGAR_TAXA_7725_DB_SELECT_1_Query1 = new M_8001_PEGAR_TAXA_7725_DB_SELECT_1_Query1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                SIVPF_COD_PLANO = SIVPF_COD_PLANO.ToString(),
                PROPVA_DTQITBCO = PROPVA_DTQITBCO.ToString(),
            };

            var executed_1 = M_8001_PEGAR_TAXA_7725_DB_SELECT_1_Query1.Execute(m_8001_PEGAR_TAXA_7725_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MFAIXA, MFAIXA);
                _.Move(executed_1.MTXVG, MTXVG);
                _.Move(executed_1.MTXAPMA, MTXAPMA);
            }


        }

        [StopWatch]
        /*" R8000-PROPAUTOM-DB-UPDATE-5 */
        public void R8000_PROPAUTOM_DB_UPDATE_5()
        {
            /*" -4960- EXEC SQL UPDATE SEGUROS.V0PARCELVA SET PRMVG = :COBERP-PRMVG, PRMAP = :COBERP-PRMAP, TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :PROPVA-NRCERTIF AND NRPARCEL = 1 END-EXEC */

            var r8000_PROPAUTOM_DB_UPDATE_5_Update1 = new R8000_PROPAUTOM_DB_UPDATE_5_Update1()
            {
                COBERP_PRMVG = COBERP_PRMVG.ToString(),
                COBERP_PRMAP = COBERP_PRMAP.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            R8000_PROPAUTOM_DB_UPDATE_5_Update1.Execute(r8000_PROPAUTOM_DB_UPDATE_5_Update1);

        }

        [StopWatch]
        /*" M-8000-INTEGRA-VG-DB-SELECT-4 */
        public void M_8000_INTEGRA_VG_DB_SELECT_4()
        {
            /*" -4569- EXEC SQL SELECT FAIXA, TAXAVG, TAXAAP INTO :MFAIXA, :MTXVG, :MTXAPMA FROM SEGUROS.PLANOS_VA_VGAP WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE AND CODSUBES = :PROPVA-CODSUBES AND OPCAO_COBER = :PROPVA-OPCAO-COBER AND COD_PLANO = :SIVPF-COD-PLANO AND DTINIVIG <= :WHOST-DTINIVIG AND DTTERVIG >= :WHOST-DTINIVIG AND IDADE_INICIAL <= :PROPVA-IDADE AND IDADE_FINAL >= :PROPVA-IDADE AND PERIPGTO = :OPCAOP-PERIPGTO AND (IMPMORNATU = :COBERP-IMPMORNATU OR IMPMORNATU = 0) WITH UR END-EXEC */

            var m_8000_INTEGRA_VG_DB_SELECT_4_Query1 = new M_8000_INTEGRA_VG_DB_SELECT_4_Query1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                PROPVA_OPCAO_COBER = PROPVA_OPCAO_COBER.ToString(),
                COBERP_IMPMORNATU = COBERP_IMPMORNATU.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
                SIVPF_COD_PLANO = SIVPF_COD_PLANO.ToString(),
                OPCAOP_PERIPGTO = OPCAOP_PERIPGTO.ToString(),
                WHOST_DTINIVIG = WHOST_DTINIVIG.ToString(),
                PROPVA_IDADE = PROPVA_IDADE.ToString(),
            };

            var executed_1 = M_8000_INTEGRA_VG_DB_SELECT_4_Query1.Execute(m_8000_INTEGRA_VG_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MFAIXA, MFAIXA);
                _.Move(executed_1.MTXVG, MTXVG);
                _.Move(executed_1.MTXAPMA, MTXAPMA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8001_FIM*/

        [StopWatch]
        /*" M-8000-INTEGRA-VG-DB-SELECT-5 */
        public void M_8000_INTEGRA_VG_DB_SELECT_5()
        {
            /*" -4594- EXEC SQL SELECT FAIXA, TAXAVG, TAXAAP INTO :MFAIXA, :MTXVG, :MTXAPMA FROM SEGUROS.PLANOS_VA_VGAP WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE AND CODSUBES = :PROPVA-CODSUBES AND OPCAO_COBER = :PROPVA-OPCAO-COBER AND DTINIVIG <= :WHOST-DTINIVIG AND DTTERVIG >= :WHOST-DTINIVIG AND IDADE_INICIAL <= :PROPVA-IDADE AND IDADE_FINAL >= :PROPVA-IDADE AND PERIPGTO = :OPCAOP-PERIPGTO AND IMPMORNATU = :COBERP-IMPMORNATU WITH UR END-EXEC */

            var m_8000_INTEGRA_VG_DB_SELECT_5_Query1 = new M_8000_INTEGRA_VG_DB_SELECT_5_Query1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                PROPVA_OPCAO_COBER = PROPVA_OPCAO_COBER.ToString(),
                COBERP_IMPMORNATU = COBERP_IMPMORNATU.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
                OPCAOP_PERIPGTO = OPCAOP_PERIPGTO.ToString(),
                WHOST_DTINIVIG = WHOST_DTINIVIG.ToString(),
                PROPVA_IDADE = PROPVA_IDADE.ToString(),
            };

            var executed_1 = M_8000_INTEGRA_VG_DB_SELECT_5_Query1.Execute(m_8000_INTEGRA_VG_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MFAIXA, MFAIXA);
                _.Move(executed_1.MTXVG, MTXVG);
                _.Move(executed_1.MTXAPMA, MTXAPMA);
            }


        }

        [StopWatch]
        /*" M-8110-COUNT-BENEFICIARIOS */
        private void M_8110_COUNT_BENEFICIARIOS(bool isPerform = false)
        {
            /*" -5077- MOVE '8110-COUNT-BENEFICIARIOS' TO PARAGRAFO. */
            _.Move("8110-COUNT-BENEFICIARIOS", WABEND.PARAGRAFO);

            /*" -5079- MOVE PROPVA-NRCERTIF TO PROPVA-NRPROPAZ. */
            _.Move(PROPVA_NRCERTIF, PROPVA_NRPROPAZ);

            /*" -5082- MOVE 'SELECT V0BENEPROPAZ' TO COMANDO. */
            _.Move("SELECT V0BENEPROPAZ", WABEND.COMANDO);

            /*" -5092- PERFORM M_8110_COUNT_BENEFICIARIOS_DB_SELECT_1 */

            M_8110_COUNT_BENEFICIARIOS_DB_SELECT_1();

            /*" -5095- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5095- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-8110-COUNT-BENEFICIARIOS-DB-SELECT-1 */
        public void M_8110_COUNT_BENEFICIARIOS_DB_SELECT_1()
        {
            /*" -5092- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :WHOST-COUNT FROM SEGUROS.V0BENEFPROPAZ WHERE NRPROPAZ = :PROPVA-NRPROPAZ AND AGELOTE = 0 AND DTLOTE = 0 AND NRLOTE = 0 AND NRSEQLOTE = 0 WITH UR END-EXEC. */

            var m_8110_COUNT_BENEFICIARIOS_DB_SELECT_1_Query1 = new M_8110_COUNT_BENEFICIARIOS_DB_SELECT_1_Query1()
            {
                PROPVA_NRPROPAZ = PROPVA_NRPROPAZ.ToString(),
            };

            var executed_1 = M_8110_COUNT_BENEFICIARIOS_DB_SELECT_1_Query1.Execute(m_8110_COUNT_BENEFICIARIOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_COUNT, WHOST_COUNT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8110_FIM*/

        [StopWatch]
        /*" M-8100-MONTA-BENEFICIARIOS */
        private void M_8100_MONTA_BENEFICIARIOS(bool isPerform = false)
        {
            /*" -5107- MOVE '8100-MONTA-BENEFICIARIOS' TO PARAGRAFO. */
            _.Move("8100-MONTA-BENEFICIARIOS", WABEND.PARAGRAFO);

            /*" -5108- IF NAO-LEU-SIVPF */

            if (WS_WORK_AREAS.WS_LEITUA_SIVPF["NAO_LEU_SIVPF"])
            {

                /*" -5111- PERFORM R7771-00-LER-PROP-SIVPF THRU R7771-FIM. */

                R7771_00_LER_PROP_SIVPF(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R7771_FIM*/

            }


            /*" -5112- IF WTEM-SIVPF EQUAL 1 */

            if (WS_WORK_AREAS.WTEM_SIVPF == 1)
            {

                /*" -5113- MOVE SIVPF-NR-SICOB TO PROPVA-NRPROPAZ */
                _.Move(SIVPF_NR_SICOB, PROPVA_NRPROPAZ);

                /*" -5114- ELSE */
            }
            else
            {


                /*" -5116- MOVE PROPVA-NRCERTIF TO PROPVA-NRPROPAZ. */
                _.Move(PROPVA_NRCERTIF, PROPVA_NRPROPAZ);
            }


            /*" -5119- MOVE 'DECLARE CBENEFP' TO COMANDO. */
            _.Move("DECLARE CBENEFP", WABEND.COMANDO);

            /*" -5131- PERFORM M_8100_MONTA_BENEFICIARIOS_DB_DECLARE_1 */

            M_8100_MONTA_BENEFICIARIOS_DB_DECLARE_1();

            /*" -5135- MOVE 'OPEN CBENEFP' TO COMANDO. */
            _.Move("OPEN CBENEFP", WABEND.COMANDO);

            /*" -5135- PERFORM M_8100_MONTA_BENEFICIARIOS_DB_OPEN_1 */

            M_8100_MONTA_BENEFICIARIOS_DB_OPEN_1();

            /*" -5138- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5140- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -5140- MOVE ZEROS TO WS-CONT-BENEF. */
            _.Move(0, WS_WORK_AREAS.WS_CONT_BENEF);

        }

        [StopWatch]
        /*" M-8100-MONTA-BENEFICIARIOS-DB-OPEN-1 */
        public void M_8100_MONTA_BENEFICIARIOS_DB_OPEN_1()
        {
            /*" -5135- EXEC SQL OPEN CBENEFP END-EXEC. */

            CBENEFP.Open();

        }

        [StopWatch]
        /*" R7774-00-LER-RCAP-COMP-DB-DECLARE-1 */
        public void R7774_00_LER_RCAP_COMP_DB_DECLARE_1()
        {
            /*" -6597- EXEC SQL DECLARE C01_RCAPCOMP CURSOR FOR SELECT BCO_AVISO, AGE_AVISO, NUM_AVISO_CREDITO, DATA_MOVIMENTO, DATA_RCAP, COD_OPERACAO FROM SEGUROS.RCAP_COMPLEMENTAR WHERE COD_FONTE = :DCLRCAPS.RCAPS-COD-FONTE AND NUM_RCAP = :DCLRCAPS.RCAPS-NUM-RCAP AND NUM_RCAP_COMPLEMEN = 0 ORDER BY COD_OPERACAO DESC WITH UR END-EXEC */
            C01_RCAPCOMP = new VP0121B_C01_RCAPCOMP(true);
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

        [StopWatch]
        /*" M-8100-LOOP */
        private void M_8100_LOOP(bool isPerform = false)
        {
            /*" -5147- MOVE 'FETCH CBENEFP' TO COMANDO. */
            _.Move("FETCH CBENEFP", WABEND.COMANDO);

            /*" -5152- PERFORM M_8100_LOOP_DB_FETCH_1 */

            M_8100_LOOP_DB_FETCH_1();

            /*" -5155- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5156- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5158- MOVE 'CLOSE CBENEFP' TO COMANDO */
                    _.Move("CLOSE CBENEFP", WABEND.COMANDO);

                    /*" -5158- PERFORM M_8100_LOOP_DB_CLOSE_1 */

                    M_8100_LOOP_DB_CLOSE_1();

                    /*" -5160- GO TO 8100-FIM */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8100_FIM*/ //GOTO
                    return;

                    /*" -5161- ELSE */
                }
                else
                {


                    /*" -5163- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -5165- ADD 1 TO WS-CONT-BENEF. */
            WS_WORK_AREAS.WS_CONT_BENEF.Value = WS_WORK_AREAS.WS_CONT_BENEF + 1;

            /*" -5167- MOVE WS-CONT-BENEF TO BENEF-NRBENEF. */
            _.Move(WS_WORK_AREAS.WS_CONT_BENEF, BENEF_NRBENEF);

            /*" -5170- MOVE 'INSERT V0BENEFIPROP' TO COMANDO. */
            _.Move("INSERT V0BENEFIPROP", WABEND.COMANDO);

            /*" -5182- PERFORM M_8100_LOOP_DB_INSERT_1 */

            M_8100_LOOP_DB_INSERT_1();

            /*" -5185- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5187- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -5187- GO TO 8100-LOOP. */
            new Task(() => M_8100_LOOP()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" M-8100-LOOP-DB-FETCH-1 */
        public void M_8100_LOOP_DB_FETCH_1()
        {
            /*" -5152- EXEC SQL FETCH CBENEFP INTO :BENEF-NOMBENEF, :BENEF-GRAUPAR, :BENEF-PCTBENEF END-EXEC. */

            if (CBENEFP.Fetch())
            {
                _.Move(CBENEFP.BENEF_NOMBENEF, BENEF_NOMBENEF);
                _.Move(CBENEFP.BENEF_GRAUPAR, BENEF_GRAUPAR);
                _.Move(CBENEFP.BENEF_PCTBENEF, BENEF_PCTBENEF);
            }

        }

        [StopWatch]
        /*" M-8100-LOOP-DB-CLOSE-1 */
        public void M_8100_LOOP_DB_CLOSE_1()
        {
            /*" -5158- EXEC SQL CLOSE CBENEFP END-EXEC */

            CBENEFP.Close();

        }

        [StopWatch]
        /*" M-8100-LOOP-DB-INSERT-1 */
        public void M_8100_LOOP_DB_INSERT_1()
        {
            /*" -5182- EXEC SQL INSERT INTO SEGUROS.V0BENEFIPROP VALUES (:PROPVA-NUM-APOLICE, :PROPVA-CODSUBES, :PROPVA-FONTE, :FONTE-PROPAUTOM, :BENEF-NRBENEF, :BENEF-NOMBENEF, :BENEF-GRAUPAR, :BENEF-PCTBENEF, 'VP0121B' , NULL) END-EXEC. */

            var m_8100_LOOP_DB_INSERT_1_Insert1 = new M_8100_LOOP_DB_INSERT_1_Insert1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
                PROPVA_FONTE = PROPVA_FONTE.ToString(),
                FONTE_PROPAUTOM = FONTE_PROPAUTOM.ToString(),
                BENEF_NRBENEF = BENEF_NRBENEF.ToString(),
                BENEF_NOMBENEF = BENEF_NOMBENEF.ToString(),
                BENEF_GRAUPAR = BENEF_GRAUPAR.ToString(),
                BENEF_PCTBENEF = BENEF_PCTBENEF.ToString(),
            };

            M_8100_LOOP_DB_INSERT_1_Insert1.Execute(m_8100_LOOP_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8100_FIM*/

        [StopWatch]
        /*" M-8200-CONCEDE-CDG */
        private void M_8200_CONCEDE_CDG(bool isPerform = false)
        {
            /*" -5198- MOVE '8200-CONCEDE-CDG ' TO COMANDO. */
            _.Move("8200-CONCEDE-CDG ", WABEND.COMANDO);

            /*" -5201- MOVE 'SELECT V0CDGCOBER' TO COMANDO. */
            _.Move("SELECT V0CDGCOBER", WABEND.COMANDO);

            /*" -5207- PERFORM M_8200_CONCEDE_CDG_DB_SELECT_1 */

            M_8200_CONCEDE_CDG_DB_SELECT_1();

            /*" -5210- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -5211- IF CDGCOB-DTINIVIG > PROPVA-DTINICDG */

                if (CDGCOB_DTINIVIG > PROPVA_DTINICDG)
                {

                    /*" -5212- PERFORM 8210-ELIMINA-CDG THRU 8210-FIM */

                    M_8210_ELIMINA_CDG(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8210_FIM*/


                    /*" -5213- PERFORM 8220-INCLUI-CDG THRU 8220-FIM */

                    M_8220_INCLUI_CDG(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8220_FIM*/


                    /*" -5214- END-IF */
                }


                /*" -5215- ELSE */
            }
            else
            {


                /*" -5216- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5217- PERFORM 8220-INCLUI-CDG THRU 8220-FIM */

                    M_8220_INCLUI_CDG(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8220_FIM*/


                    /*" -5218- ELSE */
                }
                else
                {


                    /*" -5220- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -5222- MOVE PROPVA-DTQITBCO TO W01DTSQL. */
            _.Move(PROPVA_DTQITBCO, WS_WORK_AREAS.W01DTSQL);

            /*" -5223- IF OPCAOP-PERIPGTO GREATER 12 */

            if (OPCAOP_PERIPGTO > 12)
            {

                /*" -5224- COMPUTE WS-QTDE-ANOS = OPCAOP-PERIPGTO / 12 */
                WS_WORK_AREAS.WS_QTDE_ANOS.Value = OPCAOP_PERIPGTO / 12;

                /*" -5225- COMPUTE W01AASQL = W01AASQL + WS-QTDE-ANOS */
                WS_WORK_AREAS.W01DTSQL_R.W01AASQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01AASQL + WS_WORK_AREAS.WS_QTDE_ANOS;

                /*" -5226- ELSE */
            }
            else
            {


                /*" -5227- ADD OPCAOP-PERIPGTO TO W01MMSQL */
                WS_WORK_AREAS.W01DTSQL_R.W01MMSQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01MMSQL + OPCAOP_PERIPGTO;

                /*" -5228- IF W01MMSQL > 12 */

                if (WS_WORK_AREAS.W01DTSQL_R.W01MMSQL > 12)
                {

                    /*" -5229- COMPUTE W01MMSQL = W01MMSQL - 12 */
                    WS_WORK_AREAS.W01DTSQL_R.W01MMSQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01MMSQL - 12;

                    /*" -5230- COMPUTE W01AASQL = W01AASQL + 1 */
                    WS_WORK_AREAS.W01DTSQL_R.W01AASQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01AASQL + 1;

                    /*" -5231- END-IF */
                }


                /*" -5233- END-IF. */
            }


            /*" -5234- MOVE PROPVA-DTQITBCO TO W01DTSQL. */
            _.Move(PROPVA_DTQITBCO, WS_WORK_AREAS.W01DTSQL);

            /*" -5235- ADD OPCAOP-PERIPGTO TO W01MMSQL. */
            WS_WORK_AREAS.W01DTSQL_R.W01MMSQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01MMSQL + OPCAOP_PERIPGTO;

            /*" -5236- IF W01MMSQL > 12 */

            if (WS_WORK_AREAS.W01DTSQL_R.W01MMSQL > 12)
            {

                /*" -5237- COMPUTE W01MMSQL = W01MMSQL - 12 */
                WS_WORK_AREAS.W01DTSQL_R.W01MMSQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01MMSQL - 12;

                /*" -5239- COMPUTE W01AASQL = W01AASQL + 1. */
                WS_WORK_AREAS.W01DTSQL_R.W01AASQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01AASQL + 1;
            }


            /*" -5240- MOVE 01 TO W01DDSQL. */
            _.Move(01, WS_WORK_AREAS.W01DTSQL_R.W01DDSQL);

            /*" -5242- MOVE W01DTSQL TO REPCDG-DTREF. */
            _.Move(WS_WORK_AREAS.W01DTSQL, REPCDG_DTREF);

            /*" -5243- MOVE '8200-CONCEDE-CDG          ' TO PARAGRAFO. */
            _.Move("8200-CONCEDE-CDG          ", WABEND.PARAGRAFO);

            /*" -5246- MOVE 'SELECT V0REPASSECDG' TO COMANDO. */
            _.Move("SELECT V0REPASSECDG", WABEND.COMANDO);

            /*" -5252- PERFORM M_8200_CONCEDE_CDG_DB_SELECT_2 */

            M_8200_CONCEDE_CDG_DB_SELECT_2();

            /*" -5255- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5256- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5257- PERFORM 8230-INCLUI-REPASSE-CDG THRU 8230-FIM */

                    M_8230_INCLUI_REPASSE_CDG(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8230_FIM*/


                    /*" -5258- ELSE */
                }
                else
                {


                    /*" -5258- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-8200-CONCEDE-CDG-DB-SELECT-1 */
        public void M_8200_CONCEDE_CDG_DB_SELECT_1()
        {
            /*" -5207- EXEC SQL SELECT DTINIVIG INTO :CDGCOB-DTINIVIG FROM SEGUROS.V0CDGCOBER WHERE CODCLIEN = :PROPVA-CODCLIEN AND DTTERVIG = '9999-12-31' END-EXEC. */

            var m_8200_CONCEDE_CDG_DB_SELECT_1_Query1 = new M_8200_CONCEDE_CDG_DB_SELECT_1_Query1()
            {
                PROPVA_CODCLIEN = PROPVA_CODCLIEN.ToString(),
            };

            var executed_1 = M_8200_CONCEDE_CDG_DB_SELECT_1_Query1.Execute(m_8200_CONCEDE_CDG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CDGCOB_DTINIVIG, CDGCOB_DTINIVIG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8200_FIM*/

        [StopWatch]
        /*" M-8200-CONCEDE-CDG-DB-SELECT-2 */
        public void M_8200_CONCEDE_CDG_DB_SELECT_2()
        {
            /*" -5252- EXEC SQL SELECT DTREFER INTO :REPCDG-DTREF FROM SEGUROS.V0REPASSECDG WHERE CODCLIEN = :PROPVA-CODCLIEN AND DTREFER = :REPCDG-DTREF END-EXEC. */

            var m_8200_CONCEDE_CDG_DB_SELECT_2_Query1 = new M_8200_CONCEDE_CDG_DB_SELECT_2_Query1()
            {
                PROPVA_CODCLIEN = PROPVA_CODCLIEN.ToString(),
                REPCDG_DTREF = REPCDG_DTREF.ToString(),
            };

            var executed_1 = M_8200_CONCEDE_CDG_DB_SELECT_2_Query1.Execute(m_8200_CONCEDE_CDG_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.REPCDG_DTREF, REPCDG_DTREF);
            }


        }

        [StopWatch]
        /*" M-8210-ELIMINA-CDG */
        private void M_8210_ELIMINA_CDG(bool isPerform = false)
        {
            /*" -5269- MOVE '8210-ELIMINA-CDG' TO PARAGRAFO. */
            _.Move("8210-ELIMINA-CDG", WABEND.PARAGRAFO);

            /*" -5272- MOVE 'DELETE V0CDGCOBER' TO COMANDO. */
            _.Move("DELETE V0CDGCOBER", WABEND.COMANDO);

            /*" -5275- PERFORM M_8210_ELIMINA_CDG_DB_DELETE_1 */

            M_8210_ELIMINA_CDG_DB_DELETE_1();

            /*" -5278- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5278- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-8210-ELIMINA-CDG-DB-DELETE-1 */
        public void M_8210_ELIMINA_CDG_DB_DELETE_1()
        {
            /*" -5275- EXEC SQL DELETE FROM SEGUROS.V0CDGCOBER WHERE CODCLIEN = :PROPVA-CODCLIEN END-EXEC. */

            var m_8210_ELIMINA_CDG_DB_DELETE_1_Delete1 = new M_8210_ELIMINA_CDG_DB_DELETE_1_Delete1()
            {
                PROPVA_CODCLIEN = PROPVA_CODCLIEN.ToString(),
            };

            M_8210_ELIMINA_CDG_DB_DELETE_1_Delete1.Execute(m_8210_ELIMINA_CDG_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8210_FIM*/

        [StopWatch]
        /*" M-8220-INCLUI-CDG */
        private void M_8220_INCLUI_CDG(bool isPerform = false)
        {
            /*" -5289- MOVE '8220-INCLUI-CDG' TO PARAGRAFO. */
            _.Move("8220-INCLUI-CDG", WABEND.PARAGRAFO);

            /*" -5291- MOVE 'INSERT V0CDGCOBER' TO COMANDO. */
            _.Move("INSERT V0CDGCOBER", WABEND.COMANDO);

            /*" -5303- PERFORM M_8220_INCLUI_CDG_DB_INSERT_1 */

            M_8220_INCLUI_CDG_DB_INSERT_1();

            /*" -5306- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -5306- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-8220-INCLUI-CDG-DB-INSERT-1 */
        public void M_8220_INCLUI_CDG_DB_INSERT_1()
        {
            /*" -5303- EXEC SQL INSERT INTO SEGUROS.V0CDGCOBER VALUES (:PROPVA-CODCLIEN, :PROPVA-DTINICDG, '9999-12-31' , :COBERP-IMPSEGCDG, :COBERP-VLCUSTCDG, :PROPVA-NRCERTIF, :PROPVA-OCORHIST, '0' , 'VP0121B' , CURRENT TIMESTAMP) END-EXEC. */

            var m_8220_INCLUI_CDG_DB_INSERT_1_Insert1 = new M_8220_INCLUI_CDG_DB_INSERT_1_Insert1()
            {
                PROPVA_CODCLIEN = PROPVA_CODCLIEN.ToString(),
                PROPVA_DTINICDG = PROPVA_DTINICDG.ToString(),
                COBERP_IMPSEGCDG = COBERP_IMPSEGCDG.ToString(),
                COBERP_VLCUSTCDG = COBERP_VLCUSTCDG.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                PROPVA_OCORHIST = PROPVA_OCORHIST.ToString(),
            };

            M_8220_INCLUI_CDG_DB_INSERT_1_Insert1.Execute(m_8220_INCLUI_CDG_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8220_FIM*/

        [StopWatch]
        /*" M-8230-INCLUI-REPASSE-CDG */
        private void M_8230_INCLUI_REPASSE_CDG(bool isPerform = false)
        {
            /*" -5317- MOVE '8230-INCLUI-REPASE-CDG' TO PARAGRAFO. */
            _.Move("8230-INCLUI-REPASE-CDG", WABEND.PARAGRAFO);

            /*" -5320- MOVE 'INSERT V0REPASSECDG' TO COMANDO. */
            _.Move("INSERT V0REPASSECDG", WABEND.COMANDO);

            /*" -5330- PERFORM M_8230_INCLUI_REPASSE_CDG_DB_INSERT_1 */

            M_8230_INCLUI_REPASSE_CDG_DB_INSERT_1();

            /*" -5333- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -5333- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-8230-INCLUI-REPASSE-CDG-DB-INSERT-1 */
        public void M_8230_INCLUI_REPASSE_CDG_DB_INSERT_1()
        {
            /*" -5330- EXEC SQL INSERT INTO SEGUROS.V0REPASSECDG VALUES (:PROPVA-CODCLIEN, :REPCDG-DTREF, :COBERP-VLCUSTCDG, :PROPVA-NRCERTIF, 1, '0' , :SISTEMA-DTMOVABE, CURRENT TIMESTAMP) END-EXEC. */

            var m_8230_INCLUI_REPASSE_CDG_DB_INSERT_1_Insert1 = new M_8230_INCLUI_REPASSE_CDG_DB_INSERT_1_Insert1()
            {
                PROPVA_CODCLIEN = PROPVA_CODCLIEN.ToString(),
                REPCDG_DTREF = REPCDG_DTREF.ToString(),
                COBERP_VLCUSTCDG = COBERP_VLCUSTCDG.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                SISTEMA_DTMOVABE = SISTEMA_DTMOVABE.ToString(),
            };

            M_8230_INCLUI_REPASSE_CDG_DB_INSERT_1_Insert1.Execute(m_8230_INCLUI_REPASSE_CDG_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8230_FIM*/

        [StopWatch]
        /*" M-8300-CONCEDE-SAF */
        private void M_8300_CONCEDE_SAF(bool isPerform = false)
        {
            /*" -5346- MOVE '8300-CONCEDE-SAF ' TO COMANDO. */
            _.Move("8300-CONCEDE-SAF ", WABEND.COMANDO);

            /*" -5347- IF PRODVG-RISCO = 'N' */

            if (PRODVG_RISCO == "N")
            {

                /*" -5349- MOVE PROPVA-DTQITBCO TO PROPVA-DTINISAF. */
                _.Move(PROPVA_DTQITBCO, PROPVA_DTINISAF);
            }


            /*" -5352- MOVE 'SELECT V0SAFCOBER' TO COMANDO. */
            _.Move("SELECT V0SAFCOBER", WABEND.COMANDO);

            /*" -5358- PERFORM M_8300_CONCEDE_SAF_DB_SELECT_1 */

            M_8300_CONCEDE_SAF_DB_SELECT_1();

            /*" -5361- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -5362- IF SAFCOB-DTINIVIG > PROPVA-DTINISAF */

                if (SAFCOB_DTINIVIG > PROPVA_DTINISAF)
                {

                    /*" -5363- PERFORM 8310-ELIMINA-SAF THRU 8310-FIM */

                    M_8310_ELIMINA_SAF(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8310_FIM*/


                    /*" -5364- PERFORM 8320-INCLUI-SAF THRU 8320-FIM */

                    M_8320_INCLUI_SAF(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8320_FIM*/


                    /*" -5365- END-IF */
                }


                /*" -5366- ELSE */
            }
            else
            {


                /*" -5367- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5368- PERFORM 8320-INCLUI-SAF THRU 8320-FIM */

                    M_8320_INCLUI_SAF(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8320_FIM*/


                    /*" -5369- ELSE */
                }
                else
                {


                    /*" -5371- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -5377- MOVE PROPVA-DTQITBCO TO W01DTSQL. */
            _.Move(PROPVA_DTQITBCO, WS_WORK_AREAS.W01DTSQL);

            /*" -5378- IF PRODVG-RISCO = '1' */

            if (PRODVG_RISCO == "1")
            {

                /*" -5380- ADD OPCAOP-PERIPGTO TO W01MMSQL. */
                WS_WORK_AREAS.W01DTSQL_R.W01MMSQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01MMSQL + OPCAOP_PERIPGTO;
            }


            /*" -5381- IF W01MMSQL > 12 */

            if (WS_WORK_AREAS.W01DTSQL_R.W01MMSQL > 12)
            {

                /*" -5382- COMPUTE W01MMSQL = W01MMSQL - 12 */
                WS_WORK_AREAS.W01DTSQL_R.W01MMSQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01MMSQL - 12;

                /*" -5384- COMPUTE W01AASQL = W01AASQL + 1. */
                WS_WORK_AREAS.W01DTSQL_R.W01AASQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01AASQL + 1;
            }


            /*" -5385- MOVE 01 TO W01DDSQL. */
            _.Move(01, WS_WORK_AREAS.W01DTSQL_R.W01DDSQL);

            /*" -5387- MOVE W01DTSQL TO REPSAF-DTREF. */
            _.Move(WS_WORK_AREAS.W01DTSQL, REPSAF_DTREF);

            /*" -5388- MOVE '8300-CONCEDE-SAF          ' TO PARAGRAFO. */
            _.Move("8300-CONCEDE-SAF          ", WABEND.PARAGRAFO);

            /*" -5391- MOVE 'SELECT V0HISTREPSAF' TO COMANDO. */
            _.Move("SELECT V0HISTREPSAF", WABEND.COMANDO);

            /*" -5397- PERFORM M_8300_CONCEDE_SAF_DB_SELECT_2 */

            M_8300_CONCEDE_SAF_DB_SELECT_2();

            /*" -5400- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -5401- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5402- PERFORM 8330-INCLUI-REPASSE-SAF THRU 8330-FIM */

                    M_8330_INCLUI_REPASSE_SAF(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8330_FIM*/


                    /*" -5403- ELSE */
                }
                else
                {


                    /*" -5409- IF SQLCODE EQUAL -811 NEXT SENTENCE */

                    if (DB.SQLCODE == -811)
                    {

                        /*" -5410- ELSE */
                    }
                    else
                    {


                        /*" -5410- GO TO 9999-ERRO. */

                        M_9999_ERRO(); //GOTO
                        return;
                    }

                }

            }


        }

        [StopWatch]
        /*" M-8300-CONCEDE-SAF-DB-SELECT-1 */
        public void M_8300_CONCEDE_SAF_DB_SELECT_1()
        {
            /*" -5358- EXEC SQL SELECT DTINIVIG INTO :SAFCOB-DTINIVIG FROM SEGUROS.V0SAFCOBER WHERE CODCLIEN = :PROPVA-CODCLIEN AND DTTERVIG = '9999-12-31' END-EXEC. */

            var m_8300_CONCEDE_SAF_DB_SELECT_1_Query1 = new M_8300_CONCEDE_SAF_DB_SELECT_1_Query1()
            {
                PROPVA_CODCLIEN = PROPVA_CODCLIEN.ToString(),
            };

            var executed_1 = M_8300_CONCEDE_SAF_DB_SELECT_1_Query1.Execute(m_8300_CONCEDE_SAF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SAFCOB_DTINIVIG, SAFCOB_DTINIVIG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8300_FIM*/

        [StopWatch]
        /*" M-8300-CONCEDE-SAF-DB-SELECT-2 */
        public void M_8300_CONCEDE_SAF_DB_SELECT_2()
        {
            /*" -5397- EXEC SQL SELECT DTREF INTO :REPSAF-DTREF FROM SEGUROS.V0HISTREPSAF WHERE CODCLIEN = :PROPVA-CODCLIEN AND DTREF = :REPSAF-DTREF END-EXEC. */

            var m_8300_CONCEDE_SAF_DB_SELECT_2_Query1 = new M_8300_CONCEDE_SAF_DB_SELECT_2_Query1()
            {
                PROPVA_CODCLIEN = PROPVA_CODCLIEN.ToString(),
                REPSAF_DTREF = REPSAF_DTREF.ToString(),
            };

            var executed_1 = M_8300_CONCEDE_SAF_DB_SELECT_2_Query1.Execute(m_8300_CONCEDE_SAF_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.REPSAF_DTREF, REPSAF_DTREF);
            }


        }

        [StopWatch]
        /*" M-8310-ELIMINA-SAF */
        private void M_8310_ELIMINA_SAF(bool isPerform = false)
        {
            /*" -5421- MOVE '8310-ELIMINA-SAF' TO PARAGRAFO. */
            _.Move("8310-ELIMINA-SAF", WABEND.PARAGRAFO);

            /*" -5424- MOVE 'DELETE V0SAFCOBER' TO COMANDO. */
            _.Move("DELETE V0SAFCOBER", WABEND.COMANDO);

            /*" -5427- PERFORM M_8310_ELIMINA_SAF_DB_DELETE_1 */

            M_8310_ELIMINA_SAF_DB_DELETE_1();

            /*" -5430- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5430- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-8310-ELIMINA-SAF-DB-DELETE-1 */
        public void M_8310_ELIMINA_SAF_DB_DELETE_1()
        {
            /*" -5427- EXEC SQL DELETE FROM SEGUROS.V0SAFCOBER WHERE CODCLIEN = :PROPVA-CODCLIEN END-EXEC. */

            var m_8310_ELIMINA_SAF_DB_DELETE_1_Delete1 = new M_8310_ELIMINA_SAF_DB_DELETE_1_Delete1()
            {
                PROPVA_CODCLIEN = PROPVA_CODCLIEN.ToString(),
            };

            M_8310_ELIMINA_SAF_DB_DELETE_1_Delete1.Execute(m_8310_ELIMINA_SAF_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8310_FIM*/

        [StopWatch]
        /*" M-8320-INCLUI-SAF */
        private void M_8320_INCLUI_SAF(bool isPerform = false)
        {
            /*" -5441- MOVE '8320-INCLUI-SAF' TO PARAGRAFO. */
            _.Move("8320-INCLUI-SAF", WABEND.PARAGRAFO);

            /*" -5444- MOVE 'INSERT V0SAFCOBER' TO COMANDO. */
            _.Move("INSERT V0SAFCOBER", WABEND.COMANDO);

            /*" -5456- PERFORM M_8320_INCLUI_SAF_DB_INSERT_1 */

            M_8320_INCLUI_SAF_DB_INSERT_1();

            /*" -5459- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -5461- IF SQLCODE EQUAL -803 NEXT SENTENCE */

                if (DB.SQLCODE == -803)
                {

                    /*" -5462- ELSE */
                }
                else
                {


                    /*" -5462- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-8320-INCLUI-SAF-DB-INSERT-1 */
        public void M_8320_INCLUI_SAF_DB_INSERT_1()
        {
            /*" -5456- EXEC SQL INSERT INTO SEGUROS.V0SAFCOBER VALUES (:PROPVA-CODCLIEN, :PROPVA-DTINISAF, '9999-12-31' , :COBERP-IMPSEGAUXF, :COBERP-VLCUSTAUXF, :PROPVA-NRCERTIF, :PROPVA-OCORHIST, '0' , 'VP0121B' , CURRENT TIMESTAMP) END-EXEC. */

            var m_8320_INCLUI_SAF_DB_INSERT_1_Insert1 = new M_8320_INCLUI_SAF_DB_INSERT_1_Insert1()
            {
                PROPVA_CODCLIEN = PROPVA_CODCLIEN.ToString(),
                PROPVA_DTINISAF = PROPVA_DTINISAF.ToString(),
                COBERP_IMPSEGAUXF = COBERP_IMPSEGAUXF.ToString(),
                COBERP_VLCUSTAUXF = COBERP_VLCUSTAUXF.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                PROPVA_OCORHIST = PROPVA_OCORHIST.ToString(),
            };

            M_8320_INCLUI_SAF_DB_INSERT_1_Insert1.Execute(m_8320_INCLUI_SAF_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8320_FIM*/

        [StopWatch]
        /*" M-8330-INCLUI-REPASSE-SAF */
        private void M_8330_INCLUI_REPASSE_SAF(bool isPerform = false)
        {
            /*" -5473- MOVE '8330-INCLUI-REPASE-SAF' TO PARAGRAFO. */
            _.Move("8330-INCLUI-REPASE-SAF", WABEND.PARAGRAFO);

            /*" -5476- MOVE 'INSERT V0HISTREPSAF INCLUSAO' TO COMANDO. */
            _.Move("INSERT V0HISTREPSAF INCLUSAO", WABEND.COMANDO);

            /*" -5492- PERFORM M_8330_INCLUI_REPASSE_SAF_DB_INSERT_1 */

            M_8330_INCLUI_REPASSE_SAF_DB_INSERT_1();

            /*" -5495- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -5497- IF SQLCODE EQUAL -803 NEXT SENTENCE */

                if (DB.SQLCODE == -803)
                {

                    /*" -5498- ELSE */
                }
                else
                {


                    /*" -5501- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -5504- MOVE 'INSERT V0HISTREPSAF 1100' TO COMANDO. */
            _.Move("INSERT V0HISTREPSAF 1100", WABEND.COMANDO);

            /*" -5520- PERFORM M_8330_INCLUI_REPASSE_SAF_DB_INSERT_2 */

            M_8330_INCLUI_REPASSE_SAF_DB_INSERT_2();

            /*" -5523- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -5525- IF SQLCODE EQUAL -803 NEXT SENTENCE */

                if (DB.SQLCODE == -803)
                {

                    /*" -5526- ELSE */
                }
                else
                {


                    /*" -5526- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-8330-INCLUI-REPASSE-SAF-DB-INSERT-1 */
        public void M_8330_INCLUI_REPASSE_SAF_DB_INSERT_1()
        {
            /*" -5492- EXEC SQL INSERT INTO SEGUROS.V0HISTREPSAF VALUES (:PROPVA-CODCLIEN, :REPSAF-DTREF, :PROPVA-NRCERTIF, 1, :PROPVA-NRMATRFUN, :COBERP-VLCUSTAUXF, :PROPVA-CODOPER, '0' , '0' , 0, 0, 'VP0121B' , CURRENT TIMESTAMP, :PROPVA-DTQITBCO:VIND-DTMOVTO) END-EXEC. */

            var m_8330_INCLUI_REPASSE_SAF_DB_INSERT_1_Insert1 = new M_8330_INCLUI_REPASSE_SAF_DB_INSERT_1_Insert1()
            {
                PROPVA_CODCLIEN = PROPVA_CODCLIEN.ToString(),
                REPSAF_DTREF = REPSAF_DTREF.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                PROPVA_NRMATRFUN = PROPVA_NRMATRFUN.ToString(),
                COBERP_VLCUSTAUXF = COBERP_VLCUSTAUXF.ToString(),
                PROPVA_CODOPER = PROPVA_CODOPER.ToString(),
                PROPVA_DTQITBCO = PROPVA_DTQITBCO.ToString(),
                VIND_DTMOVTO = VIND_DTMOVTO.ToString(),
            };

            M_8330_INCLUI_REPASSE_SAF_DB_INSERT_1_Insert1.Execute(m_8330_INCLUI_REPASSE_SAF_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8330_FIM*/

        [StopWatch]
        /*" M-8330-INCLUI-REPASSE-SAF-DB-INSERT-2 */
        public void M_8330_INCLUI_REPASSE_SAF_DB_INSERT_2()
        {
            /*" -5520- EXEC SQL INSERT INTO SEGUROS.V0HISTREPSAF VALUES (:PROPVA-CODCLIEN, :REPSAF-DTREF, :PROPVA-NRCERTIF, 1, :PROPVA-NRMATRFUN, :COBERP-VLCUSTAUXF, 1100, '0' , '0' , 0, 0, 'VP0121B' , CURRENT TIMESTAMP, :PROPVA-DTQITBCO:VIND-DTMOVTO) END-EXEC. */

            var m_8330_INCLUI_REPASSE_SAF_DB_INSERT_2_Insert1 = new M_8330_INCLUI_REPASSE_SAF_DB_INSERT_2_Insert1()
            {
                PROPVA_CODCLIEN = PROPVA_CODCLIEN.ToString(),
                REPSAF_DTREF = REPSAF_DTREF.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                PROPVA_NRMATRFUN = PROPVA_NRMATRFUN.ToString(),
                COBERP_VLCUSTAUXF = COBERP_VLCUSTAUXF.ToString(),
                PROPVA_DTQITBCO = PROPVA_DTQITBCO.ToString(),
                VIND_DTMOVTO = VIND_DTMOVTO.ToString(),
            };

            M_8330_INCLUI_REPASSE_SAF_DB_INSERT_2_Insert1.Execute(m_8330_INCLUI_REPASSE_SAF_DB_INSERT_2_Insert1);

        }

        [StopWatch]
        /*" M-8400-00-DEBITO-CARTAO */
        private void M_8400_00_DEBITO_CARTAO(bool isPerform = false)
        {
            /*" -5538- MOVE '8400-00-DEBITO-CARTAO' TO PARAGRAFO. */
            _.Move("8400-00-DEBITO-CARTAO", WABEND.PARAGRAFO);

            /*" -5540- MOVE CONVEN-CARTAO TO HOST-CODCONV. */
            _.Move(CONVEN_CARTAO, HOST_CODCONV);

            /*" -5541- IF WHOST-VLPREMIO LESS ZERO */

            if (WHOST_VLPREMIO < 00)
            {

                /*" -5542- COMPUTE WHOST-VLPREMIO-W = WHOST-VLPREMIO * (-1) */
                WHOST_VLPREMIO_W.Value = WHOST_VLPREMIO * (-1);

                /*" -5543- MOVE 352 TO MOVDEBCE-DIG-CONTA-DEB */
                _.Move(352, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB);

                /*" -5544- ELSE */
            }
            else
            {


                /*" -5545- MOVE 152 TO MOVDEBCE-DIG-CONTA-DEB */
                _.Move(152, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB);

                /*" -5548- END-IF. */
            }


            /*" -5550- IF PROPVA-CODPRODU = 9320 OR JVPRD9320 */

            if (PROPVA_CODPRODU.In("9320", JVBKINCL.JV_PRODUTOS.JVPRD9320.ToString()))
            {

                /*" -5551- MOVE 0005 TO MOVDEBCE-OPER-CONTA-DEB */
                _.Move(0005, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB);

                /*" -5552- ELSE */
            }
            else
            {


                /*" -5553- IF PROPVA-CODPRODU EQUAL 9703 */

                if (PROPVA_CODPRODU == 9703)
                {

                    /*" -5554- MOVE 0006 TO MOVDEBCE-OPER-CONTA-DEB */
                    _.Move(0006, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB);

                    /*" -5555- ELSE */
                }
                else
                {


                    /*" -5556- IF PROPVA-CODPRODU EQUAL 9318 */

                    if (PROPVA_CODPRODU == 9318)
                    {

                        /*" -5557- MOVE 0008 TO MOVDEBCE-OPER-CONTA-DEB */
                        _.Move(0008, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB);

                        /*" -5558- END-IF */
                    }


                    /*" -5559- END-IF */
                }


                /*" -5561- END-IF. */
            }


            /*" -5562- MOVE 0 TO MOVDEBCE-COD-EMPRESA */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_EMPRESA);

            /*" -5563- MOVE BANCOS-NRTIT TO MOVDEBCE-NUM-APOLICE */
            _.Move(BANCOS_NRTIT, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);

            /*" -5564- MOVE 0 TO MOVDEBCE-NUM-ENDOSSO */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);

            /*" -5565- MOVE 1 TO MOVDEBCE-NUM-PARCELA */
            _.Move(1, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA);

            /*" -5566- MOVE ' ' TO MOVDEBCE-SITUACAO-COBRANCA */
            _.Move(" ", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);

            /*" -5567- MOVE HISTCB-DTVENCTO TO MOVDEBCE-DATA-VENCIMENTO */
            _.Move(HISTCB_DTVENCTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO);

            /*" -5568- MOVE WHOST-VLPREMIO-W TO MOVDEBCE-VALOR-DEBITO */
            _.Move(WHOST_VLPREMIO_W, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO);

            /*" -5569- MOVE SISTEMA-DTMOVABE TO MOVDEBCE-DATA-MOVIMENTO */
            _.Move(SISTEMA_DTMOVABE, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO);

            /*" -5570- MOVE 0 TO MOVDEBCE-DIA-DEBITO */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIA_DEBITO);

            /*" -5571- MOVE 0 TO MOVDEBCE-COD-AGENCIA-DEB */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB);

            /*" -5573- MOVE 0 TO MOVDEBCE-NUM-CONTA-DEB */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB);

            /*" -5574- MOVE 9019 TO MOVDEBCE-COD-CONVENIO */
            _.Move(9019, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);

            /*" -5575- MOVE ZEROES TO MOVDEBCE-NSAS */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS);

            /*" -5576- MOVE 'VP0121B' TO MOVDEBCE-COD-USUARIO */
            _.Move("VP0121B", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_USUARIO);

            /*" -5577- MOVE OPCAOP-CARTAOCRED TO MOVDEBCE-NUM-CARTAO */
            _.Move(OPCAOP_CARTAOCRED, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO);

            /*" -5587- MOVE -1 TO VIND-DTENV VIND-DTRET VIND-CODRET VIND-NREQ VIND-SEQUEN VIND-NLOTE VIND-DTCRED VIND-STATUS VIND-VLCRED. */
            _.Move(-1, VIND_DTENV, VIND_DTRET, VIND_CODRET, VIND_NREQ, VIND_SEQUEN, VIND_NLOTE, VIND_DTCRED, VIND_STATUS, VIND_VLCRED);

            /*" -5589- MOVE 'INSERT MOVTO_DEBITOCC_CEF' TO COMANDO. */
            _.Move("INSERT MOVTO_DEBITOCC_CEF", WABEND.COMANDO);

            /*" -5646- PERFORM M_8400_00_DEBITO_CARTAO_DB_INSERT_1 */

            M_8400_00_DEBITO_CARTAO_DB_INSERT_1();

            /*" -5648- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5649- DISPLAY '8400-00 (ERRO - INSERT V0MOVDEBCC)' */
                _.Display($"8400-00 (ERRO - INSERT V0MOVDEBCC)");

                /*" -5651- DISPLAY 'CERTIF: ' PROPVA-NRCERTIF '  ' 'PARCEL: ' PROPVA-NRPARCEL */

                $"CERTIF: {PROPVA_NRCERTIF}  PARCEL: {PROPVA_NRPARCEL}"
                .Display();

                /*" -5652- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-8400-00-DEBITO-CARTAO-DB-INSERT-1 */
        public void M_8400_00_DEBITO_CARTAO_DB_INSERT_1()
        {
            /*" -5646- EXEC SQL INSERT INTO SEGUROS.MOVTO_DEBITOCC_CEF ( COD_EMPRESA , NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , SITUACAO_COBRANCA , DATA_VENCIMENTO , VALOR_DEBITO , DATA_MOVIMENTO , TIMESTAMP , DIA_DEBITO , COD_AGENCIA_DEB , OPER_CONTA_DEB , NUM_CONTA_DEB , DIG_CONTA_DEB , COD_CONVENIO , DATA_ENVIO , DATA_RETORNO , COD_RETORNO_CEF , NSAS , COD_USUARIO , NUM_REQUISICAO , NUM_CARTAO , SEQUENCIA , NUM_LOTE , DTCREDITO , STATUS_CARTAO , VLR_CREDITO ) VALUES ( :MOVDEBCE-COD-EMPRESA , :MOVDEBCE-NUM-APOLICE , :MOVDEBCE-NUM-ENDOSSO , :MOVDEBCE-NUM-PARCELA , :MOVDEBCE-SITUACAO-COBRANCA , :MOVDEBCE-DATA-VENCIMENTO , :MOVDEBCE-VALOR-DEBITO , :MOVDEBCE-DATA-MOVIMENTO , CURRENT TIMESTAMP , :MOVDEBCE-DIA-DEBITO , :MOVDEBCE-COD-AGENCIA-DEB , :MOVDEBCE-OPER-CONTA-DEB , :MOVDEBCE-NUM-CONTA-DEB , :MOVDEBCE-DIG-CONTA-DEB , :MOVDEBCE-COD-CONVENIO , :MOVDEBCE-DATA-ENVIO:VIND-DTENV , :MOVDEBCE-DATA-RETORNO:VIND-DTRET , :MOVDEBCE-COD-RETORNO-CEF:VIND-CODRET , :MOVDEBCE-NSAS , :MOVDEBCE-COD-USUARIO , :MOVDEBCE-NUM-REQUISICAO:VIND-NREQ , :MOVDEBCE-NUM-CARTAO , :MOVDEBCE-SEQUENCIA:VIND-SEQUEN , :MOVDEBCE-NUM-LOTE:VIND-NLOTE , :MOVDEBCE-DTCREDITO:VIND-DTCRED , :MOVDEBCE-STATUS-CARTAO:VIND-STATUS , :MOVDEBCE-VLR-CREDITO:VIND-VLCRED ) END-EXEC */

            var m_8400_00_DEBITO_CARTAO_DB_INSERT_1_Insert1 = new M_8400_00_DEBITO_CARTAO_DB_INSERT_1_Insert1()
            {
                MOVDEBCE_COD_EMPRESA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_EMPRESA.ToString(),
                MOVDEBCE_NUM_APOLICE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.ToString(),
                MOVDEBCE_NUM_ENDOSSO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO.ToString(),
                MOVDEBCE_NUM_PARCELA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA.ToString(),
                MOVDEBCE_SITUACAO_COBRANCA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA.ToString(),
                MOVDEBCE_DATA_VENCIMENTO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO.ToString(),
                MOVDEBCE_VALOR_DEBITO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO.ToString(),
                MOVDEBCE_DATA_MOVIMENTO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO.ToString(),
                MOVDEBCE_DIA_DEBITO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIA_DEBITO.ToString(),
                MOVDEBCE_COD_AGENCIA_DEB = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB.ToString(),
                MOVDEBCE_OPER_CONTA_DEB = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB.ToString(),
                MOVDEBCE_NUM_CONTA_DEB = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB.ToString(),
                MOVDEBCE_DIG_CONTA_DEB = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB.ToString(),
                MOVDEBCE_COD_CONVENIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.ToString(),
                MOVDEBCE_DATA_ENVIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_ENVIO.ToString(),
                VIND_DTENV = VIND_DTENV.ToString(),
                MOVDEBCE_DATA_RETORNO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_RETORNO.ToString(),
                VIND_DTRET = VIND_DTRET.ToString(),
                MOVDEBCE_COD_RETORNO_CEF = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF.ToString(),
                VIND_CODRET = VIND_CODRET.ToString(),
                MOVDEBCE_NSAS = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS.ToString(),
                MOVDEBCE_COD_USUARIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_USUARIO.ToString(),
                MOVDEBCE_NUM_REQUISICAO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO.ToString(),
                VIND_NREQ = VIND_NREQ.ToString(),
                MOVDEBCE_NUM_CARTAO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO.ToString(),
                MOVDEBCE_SEQUENCIA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SEQUENCIA.ToString(),
                VIND_SEQUEN = VIND_SEQUEN.ToString(),
                MOVDEBCE_NUM_LOTE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_LOTE.ToString(),
                VIND_NLOTE = VIND_NLOTE.ToString(),
                MOVDEBCE_DTCREDITO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DTCREDITO.ToString(),
                VIND_DTCRED = VIND_DTCRED.ToString(),
                MOVDEBCE_STATUS_CARTAO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_STATUS_CARTAO.ToString(),
                VIND_STATUS = VIND_STATUS.ToString(),
                MOVDEBCE_VLR_CREDITO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_CREDITO.ToString(),
                VIND_VLCRED = VIND_VLCRED.ToString(),
            };

            M_8400_00_DEBITO_CARTAO_DB_INSERT_1_Insert1.Execute(m_8400_00_DEBITO_CARTAO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8400_FIM*/

        [StopWatch]
        /*" M-8500-CALC-PROP-AUTOM */
        private void M_8500_CALC_PROP_AUTOM(bool isPerform = false)
        {
            /*" -5663- MOVE '8500-CALC-PROP  ' TO COMANDO. */
            _.Move("8500-CALC-PROP  ", WABEND.COMANDO);

            /*" -5665- IF PROPVA-INRPROPOS NOT LESS 0 AND PROPVA-NRPROPOS GREATER 0 */

            if (PROPVA_INRPROPOS >= 0 && PROPVA_NRPROPOS > 0)
            {

                /*" -5666- MOVE PROPVA-NRPROPOS TO FONTE-PROPAUTOM */
                _.Move(PROPVA_NRPROPOS, FONTE_PROPAUTOM);

                /*" -5668- GO TO 8500-FIM. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8500_FIM*/ //GOTO
                return;
            }


            /*" -5669- MOVE '8500-CALC-PROP-AUTOM' TO PARAGRAFO. */
            _.Move("8500-CALC-PROP-AUTOM", WABEND.PARAGRAFO);

            /*" -5671- MOVE 'SELECT V0FONTE' TO COMANDO. */
            _.Move("SELECT V0FONTE", WABEND.COMANDO);

            /*" -5676- PERFORM M_8500_CALC_PROP_AUTOM_DB_SELECT_1 */

            M_8500_CALC_PROP_AUTOM_DB_SELECT_1();

            /*" -5679- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5681- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -5681- COMPUTE FONTE-PROPAUTOM = FONTE-PROPAUTOM + 1. */
            FONTE_PROPAUTOM.Value = FONTE_PROPAUTOM + 1;

        }

        [StopWatch]
        /*" M-8500-CALC-PROP-AUTOM-DB-SELECT-1 */
        public void M_8500_CALC_PROP_AUTOM_DB_SELECT_1()
        {
            /*" -5676- EXEC SQL SELECT PROPAUTOM INTO :FONTE-PROPAUTOM FROM SEGUROS.V0FONTE WHERE FONTE = :PROPVA-FONTE END-EXEC. */

            var m_8500_CALC_PROP_AUTOM_DB_SELECT_1_Query1 = new M_8500_CALC_PROP_AUTOM_DB_SELECT_1_Query1()
            {
                PROPVA_FONTE = PROPVA_FONTE.ToString(),
            };

            var executed_1 = M_8500_CALC_PROP_AUTOM_DB_SELECT_1_Query1.Execute(m_8500_CALC_PROP_AUTOM_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FONTE_PROPAUTOM, FONTE_PROPAUTOM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8500_FIM*/

        [StopWatch]
        /*" M-8600-PRIMEIRA-COBRANCA */
        private void M_8600_PRIMEIRA_COBRANCA(bool isPerform = false)
        {
            /*" -5694- MOVE '8600-PRIMEIRA-CO' TO COMANDO. */
            _.Move("8600-PRIMEIRA-CO", WABEND.COMANDO);

            /*" -5697- IF CANAL-VENDA-GITEL OR PROPOSTA-CACB OR PROPOSTA-COPESP */

            if (WS_WORK_AREAS.CANAL.W_CANAL_PROPOSTA["CANAL_VENDA_GITEL"] || WS_WORK_AREAS.FILLER_1.W_CANAL_PROPOSTA1["PROPOSTA_CACB"] || WS_WORK_AREAS.FILLER_1.W_CANAL_PROPOSTA1["PROPOSTA_COPESP"])
            {

                /*" -5698- MOVE PROPVA-DTVENCTO TO HISTCB-DTVENCTO */
                _.Move(PROPVA_DTVENCTO, HISTCB_DTVENCTO);

                /*" -5699- GO TO 8600-10-CONTINUA */

                M_8600_10_CONTINUA(); //GOTO
                return;

                /*" -5701- END-IF. */
            }


            /*" -5703- IF PRODVG-COBERADIC-PREMIO = 'S' NEXT SENTENCE */

            if (PRODVG_COBERADIC_PREMIO == "S")
            {

                /*" -5704- ELSE */
            }
            else
            {


                /*" -5707- IF PRODVG-TEM-SAF = 'S' OR PRODVG-TEM-CDG = 'S' */

                if (PRODVG_TEM_SAF == "S" || PRODVG_TEM_CDG == "S")
                {

                    /*" -5712- COMPUTE COBERP-PRMVG = COBERP-PRMVG + COBERP-VLCUSTCDG + COBERP-VLCUSTCAP + COBERP-VLCUSTAUXF. */
                    COBERP_PRMVG.Value = COBERP_PRMVG + COBERP_VLCUSTCDG + COBERP_VLCUSTCAP + COBERP_VLCUSTAUXF;
                }

            }


            /*" -5713- MOVE SISTEMA-DTMOVABE2 TO W01DTSQL */
            _.Move(SISTEMA_DTMOVABE2, WS_WORK_AREAS.W01DTSQL);

            /*" -5714- MOVE OPCAOP-DIA-DEB TO W01DDSQL */
            _.Move(OPCAOP_DIA_DEB, WS_WORK_AREAS.W01DTSQL_R.W01DDSQL);

            /*" -5715- IF W01DTSQL < SISTEMA-DTMOVABE2 */

            if (WS_WORK_AREAS.W01DTSQL < SISTEMA_DTMOVABE2)
            {

                /*" -5716- ADD 1 TO W01MMSQL */
                WS_WORK_AREAS.W01DTSQL_R.W01MMSQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01MMSQL + 1;

                /*" -5717- IF W01MMSQL > 12 */

                if (WS_WORK_AREAS.W01DTSQL_R.W01MMSQL > 12)
                {

                    /*" -5718- MOVE 01 TO W01MMSQL */
                    _.Move(01, WS_WORK_AREAS.W01DTSQL_R.W01MMSQL);

                    /*" -5720- ADD 1 TO W01AASQL. */
                    WS_WORK_AREAS.W01DTSQL_R.W01AASQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01AASQL + 1;
                }

            }


            /*" -5721- PERFORM UNTIL W01DTSQL NOT LESS PROPVA-DTQITBCO */

            while (!(WS_WORK_AREAS.W01DTSQL >= PROPVA_DTQITBCO))
            {

                /*" -5722- ADD 1 TO W01MMSQL */
                WS_WORK_AREAS.W01DTSQL_R.W01MMSQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01MMSQL + 1;

                /*" -5723- IF W01MMSQL > 12 */

                if (WS_WORK_AREAS.W01DTSQL_R.W01MMSQL > 12)
                {

                    /*" -5724- MOVE 01 TO W01MMSQL */
                    _.Move(01, WS_WORK_AREAS.W01DTSQL_R.W01MMSQL);

                    /*" -5725- ADD 1 TO W01AASQL */
                    WS_WORK_AREAS.W01DTSQL_R.W01AASQL.Value = WS_WORK_AREAS.W01DTSQL_R.W01AASQL + 1;

                    /*" -5726- END-IF */
                }


                /*" -5747- END-PERFORM. */
            }

            /*" -5748- IF W01DTSQL < PROPVA-DTQITBCO */

            if (WS_WORK_AREAS.W01DTSQL < PROPVA_DTQITBCO)
            {

                /*" -5749- MOVE PROPVA-DTQITBCO TO W01DTSQL */
                _.Move(PROPVA_DTQITBCO, WS_WORK_AREAS.W01DTSQL);

                /*" -5750- MOVE OPCAOP-DIA-DEB TO W01DDSQL */
                _.Move(OPCAOP_DIA_DEB, WS_WORK_AREAS.W01DTSQL_R.W01DDSQL);

                /*" -5751- ELSE */
            }
            else
            {


                /*" -5752- IF W01DTSQL = PROPVA-DTQITBCO */

                if (WS_WORK_AREAS.W01DTSQL == PROPVA_DTQITBCO)
                {

                    /*" -5758- PERFORM M_8600_PRIMEIRA_COBRANCA_DB_SELECT_1 */

                    M_8600_PRIMEIRA_COBRANCA_DB_SELECT_1();

                    /*" -5760- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -5761- DISPLAY 'ERRO NO AJUSTE NA DATA DE VENCIMENTO' */
                        _.Display($"ERRO NO AJUSTE NA DATA DE VENCIMENTO");

                        /*" -5762- DISPLAY 'CERTIFICADO = ' PROPVA-NRCERTIF */
                        _.Display($"CERTIFICADO = {PROPVA_NRCERTIF}");

                        /*" -5763- GO TO 9999-ERRO */

                        M_9999_ERRO(); //GOTO
                        return;

                        /*" -5764- ELSE */
                    }
                    else
                    {


                        /*" -5766- MOVE W03-VENCIMENTO TO W01DTSQL. */
                        _.Move(W03_VENCIMENTO, WS_WORK_AREAS.W01DTSQL);
                    }

                }

            }


            /*" -5766- MOVE W01DTSQL TO HISTCB-DTVENCTO. */
            _.Move(WS_WORK_AREAS.W01DTSQL, HISTCB_DTVENCTO);

        }

        [StopWatch]
        /*" M-8600-PRIMEIRA-COBRANCA-DB-SELECT-1 */
        public void M_8600_PRIMEIRA_COBRANCA_DB_SELECT_1()
        {
            /*" -5758- EXEC SQL SELECT DATE(:PROPVA-DTQITBCO) + 5 DAYS INTO :W03-VENCIMENTO FROM SEGUROS.V0SISTEMA WHERE IDSISTEM = 'VA' WITH UR END-EXEC */

            var m_8600_PRIMEIRA_COBRANCA_DB_SELECT_1_Query1 = new M_8600_PRIMEIRA_COBRANCA_DB_SELECT_1_Query1()
            {
                PROPVA_DTQITBCO = PROPVA_DTQITBCO.ToString(),
            };

            var executed_1 = M_8600_PRIMEIRA_COBRANCA_DB_SELECT_1_Query1.Execute(m_8600_PRIMEIRA_COBRANCA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.W03_VENCIMENTO, W03_VENCIMENTO);
            }


        }

        [StopWatch]
        /*" M-8600-10-CONTINUA */
        private void M_8600_10_CONTINUA(bool isPerform = false)
        {
            /*" -5773- MOVE '8600-10-CONTINUA' TO COMANDO. */
            _.Move("8600-10-CONTINUA", WABEND.COMANDO);

            /*" -5774- IF OPCAOP-OPCAOPAG EQUAL '1' OR '2' OR '5' */

            if (OPCAOP_OPCAOPAG.In("1", "2", "5"))
            {

                /*" -5775- MOVE 1 TO PARCEL-OCORHIST */
                _.Move(1, PARCEL_OCORHIST);

                /*" -5776- ELSE */
            }
            else
            {


                /*" -5778- MOVE 0 TO PARCEL-OCORHIST. */
                _.Move(0, PARCEL_OCORHIST);
            }


            /*" -5779- IF PROPVA-IDTADMIS LESS ZEROS */

            if (PROPVA_IDTADMIS < 00)
            {

                /*" -5780- MOVE '1900-01-01' TO DESCON-DTINIVIG */
                _.Move("1900-01-01", DESCON_DTINIVIG);

                /*" -5781- ELSE */
            }
            else
            {


                /*" -5783- MOVE PROPVA-DTADMIS TO DESCON-DTINIVIG. */
                _.Move(PROPVA_DTADMIS, DESCON_DTINIVIG);
            }


            /*" -5784- MOVE '8600-PRIMEIRA-COBRANCA' TO PARAGRAFO. */
            _.Move("8600-PRIMEIRA-COBRANCA", WABEND.PARAGRAFO);

            /*" -5787- MOVE 'SELECT VG_PARCELAS_DESCON ' TO COMANDO. */
            _.Move("SELECT VG_PARCELAS_DESCON ", WABEND.COMANDO);

            /*" -5797- PERFORM M_8600_10_CONTINUA_DB_SELECT_1 */

            M_8600_10_CONTINUA_DB_SELECT_1();

            /*" -5800- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5801- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5802- MOVE 0,00 TO DESCON-PERC */
                    _.Move(0.00, DESCON_PERC);

                    /*" -5803- ELSE */
                }
                else
                {


                    /*" -5805- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -5807- COMPUTE DESCON-VLPREMIO = COBERP-VLPREMIO * (1 - DESCON-PERC). */
            DESCON_VLPREMIO.Value = COBERP_VLPREMIO * (1 - DESCON_PERC);

            /*" -5808- COMPUTE DESCON-PRMVG = COBERP-PRMVG * DESCON-PERC. */
            DESCON_PRMVG.Value = COBERP_PRMVG * DESCON_PERC;

            /*" -5810- COMPUTE DESCON-PRMAP = COBERP-PRMAP * DESCON-PERC. */
            DESCON_PRMAP.Value = COBERP_PRMAP * DESCON_PERC;

            /*" -5811- MOVE DESCON-VLPREMIO TO WHOST-VLPREMIO. */
            _.Move(DESCON_VLPREMIO, WHOST_VLPREMIO);

            /*" -5813- MOVE DESCON-VLPREMIO TO WHOST-VLPREMIO-W. */
            _.Move(DESCON_VLPREMIO, WHOST_VLPREMIO_W);

            /*" -5816- MOVE 'INSERT V0PARCELVA' TO COMANDO. */
            _.Move("INSERT V0PARCELVA", WABEND.COMANDO);

            /*" -5828- PERFORM M_8600_10_CONTINUA_DB_INSERT_1 */

            M_8600_10_CONTINUA_DB_INSERT_1();

            /*" -5832- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5835- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -5836- GO TO 8600-CONTINUA */

                    M_8600_CONTINUA(); //GOTO
                    return;

                    /*" -5837- ELSE */
                }
                else
                {


                    /*" -5838- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -5839- END-IF */
                }


                /*" -5848- END-IF. */
            }


            /*" -5850- ADD 1 TO WTITL-SEQUENCIA. */
            WS_WORK_AREAS.FILLER_11.WTITL_SEQUENCIA.Value = WS_WORK_AREAS.FILLER_11.WTITL_SEQUENCIA + 1;

            /*" -5852- MOVE WTITL-SEQUENCIA TO DPARM01. */
            _.Move(WS_WORK_AREAS.FILLER_11.WTITL_SEQUENCIA, WS_WORK_AREAS.DPARM01X.DPARM01);

            /*" -5854- CALL 'PROTIT01' USING DPARM01X. */
            _.Call("PROTIT01", WS_WORK_AREAS.DPARM01X);

            /*" -5855- IF DPARM01-RC NOT EQUAL +0 */

            if (WS_WORK_AREAS.DPARM01X.DPARM01_RC != +0)
            {

                /*" -5856- DISPLAY 'ERRO CHAMADA PROTIT01' */
                _.Display($"ERRO CHAMADA PROTIT01");

                /*" -5858- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -5860- MOVE DPARM01-D1 TO WTITL-DIGITO. */
            _.Move(WS_WORK_AREAS.DPARM01X.DPARM01_D1, WS_WORK_AREAS.FILLER_11.WTITL_DIGITO);

            /*" -5862- MOVE W-NUMR-TITULO TO BANCOS-NRTIT. */
            _.Move(WS_WORK_AREAS.W_NUMR_TITULO, BANCOS_NRTIT);

            /*" -5863- IF OPCAOP-OPCAOPAG EQUAL '1' OR '2' OR '5' */

            if (OPCAOP_OPCAOPAG.In("1", "2", "5"))
            {

                /*" -5865- PERFORM 8700-GERA-DEBITO THRU 8700-FIM. */

                M_8700_GERA_DEBITO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8700_FIM*/

            }


            /*" -5866- IF OPCAOP-OPCAOPAG = '3' */

            if (OPCAOP_OPCAOPAG == "3")
            {

                /*" -5867- MOVE '5' TO HISTCB-SITUACAO */
                _.Move("5", HISTCB_SITUACAO);

                /*" -5868- ELSE */
            }
            else
            {


                /*" -5884- MOVE '0' TO HISTCB-SITUACAO. */
                _.Move("0", HISTCB_SITUACAO);
            }


            /*" -5885- MOVE '8600-PRIMEIRA-COBRANCA' TO PARAGRAFO. */
            _.Move("8600-PRIMEIRA-COBRANCA", WABEND.PARAGRAFO);

            /*" -5888- MOVE 'INSERT V0HISTCOBVA' TO COMANDO. */
            _.Move("INSERT V0HISTCOBVA", WABEND.COMANDO);

            /*" -5904- PERFORM M_8600_10_CONTINUA_DB_INSERT_2 */

            M_8600_10_CONTINUA_DB_INSERT_2();

            /*" -5907- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5909- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -5911- IF DESCON-PRMVG NOT GREATER ZEROS AND DESCON-PRMAP NOT GREATER ZEROS */

            if (DESCON_PRMVG <= 00 && DESCON_PRMAP <= 00)
            {

                /*" -5913- GO TO 8600-CONTINUA. */

                M_8600_CONTINUA(); //GOTO
                return;
            }


            /*" -5914- MOVE '8600-PRIMEIRA-COBRANCA' TO PARAGRAFO. */
            _.Move("8600-PRIMEIRA-COBRANCA", WABEND.PARAGRAFO);

            /*" -5917- MOVE 'INSERT V0DIFPARCELVA' TO COMANDO. */
            _.Move("INSERT V0DIFPARCELVA", WABEND.COMANDO);

            /*" -5932- PERFORM M_8600_10_CONTINUA_DB_INSERT_3 */

            M_8600_10_CONTINUA_DB_INSERT_3();

            /*" -5935- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5935- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-8600-10-CONTINUA-DB-SELECT-1 */
        public void M_8600_10_CONTINUA_DB_SELECT_1()
        {
            /*" -5797- EXEC SQL SELECT PCT_PARCELA_DESC INTO :DESCON-PERC FROM SEGUROS.VG_PARCELAS_DESCON WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE AND COD_SUBGRUPO = :PROPVA-CODSUBES AND NUM_PARCELA_DESC = 1 AND DT_INIVIG_PARCDESC <= :DESCON-DTINIVIG AND DT_TERVIG_PARCDESC >= :DESCON-DTINIVIG WITH UR END-EXEC. */

            var m_8600_10_CONTINUA_DB_SELECT_1_Query1 = new M_8600_10_CONTINUA_DB_SELECT_1_Query1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
                DESCON_DTINIVIG = DESCON_DTINIVIG.ToString(),
            };

            var executed_1 = M_8600_10_CONTINUA_DB_SELECT_1_Query1.Execute(m_8600_10_CONTINUA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.DESCON_PERC, DESCON_PERC);
            }


        }

        [StopWatch]
        /*" M-8600-10-CONTINUA-DB-INSERT-1 */
        public void M_8600_10_CONTINUA_DB_INSERT_1()
        {
            /*" -5828- EXEC SQL INSERT INTO SEGUROS.V0PARCELVA VALUES (:PROPVA-NRCERTIF, 1, :HISTCB-DTVENCTO, :COBERP-PRMVG, :COBERP-PRMAP, 0, :OPCAOP-OPCAOPAG, ' ' , :PARCEL-OCORHIST, CURRENT TIMESTAMP) END-EXEC. */

            var m_8600_10_CONTINUA_DB_INSERT_1_Insert1 = new M_8600_10_CONTINUA_DB_INSERT_1_Insert1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                HISTCB_DTVENCTO = HISTCB_DTVENCTO.ToString(),
                COBERP_PRMVG = COBERP_PRMVG.ToString(),
                COBERP_PRMAP = COBERP_PRMAP.ToString(),
                OPCAOP_OPCAOPAG = OPCAOP_OPCAOPAG.ToString(),
                PARCEL_OCORHIST = PARCEL_OCORHIST.ToString(),
            };

            M_8600_10_CONTINUA_DB_INSERT_1_Insert1.Execute(m_8600_10_CONTINUA_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" M-8600-CONTINUA */
        private void M_8600_CONTINUA(bool isPerform = false)
        {
            /*" -5942- IF PRODVG-ORIG-PRODU = 'CEF DEB CC' AND NOT PROPOSTA-CACB AND NOT PROPOSTA-COPESP */

            if (PRODVG_ORIG_PRODU == "CEF DEB CC" && !WS_WORK_AREAS.FILLER_1.W_CANAL_PROPOSTA1["PROPOSTA_CACB"] && !WS_WORK_AREAS.FILLER_1.W_CANAL_PROPOSTA1["PROPOSTA_COPESP"])
            {

                /*" -5943- MOVE '0' TO PROPVA-SITUACAO */
                _.Move("0", PROPVA_SITUACAO);

                /*" -5944- ELSE */
            }
            else
            {


                /*" -5946- MOVE '8' TO PROPVA-SITUACAO. */
                _.Move("8", PROPVA_SITUACAO);
            }


            /*" -5948- IF PROPVA-CODPRODU = 7732 OR JVPRD7732 OR 7733 OR JVPRD7733 */

            if (PROPVA_CODPRODU.In("7732", JVBKINCL.JV_PRODUTOS.JVPRD7732.ToString(), "7733", JVBKINCL.JV_PRODUTOS.JVPRD7733.ToString()))
            {

                /*" -5949- MOVE '3' TO PROPVA-SITUACAO */
                _.Move("3", PROPVA_SITUACAO);

                /*" -5950- END-IF */
            }


            /*" -5952- MOVE PROPVA-DTQITBCO TO MDTMOVTO. */
            _.Move(PROPVA_DTQITBCO, MDTMOVTO);

            /*" -5955- IF CANAL-VENDA-GITEL OR PROPOSTA-CACB OR PROPOSTA-COPESP */

            if (WS_WORK_AREAS.CANAL.W_CANAL_PROPOSTA["CANAL_VENDA_GITEL"] || WS_WORK_AREAS.FILLER_1.W_CANAL_PROPOSTA1["PROPOSTA_CACB"] || WS_WORK_AREAS.FILLER_1.W_CANAL_PROPOSTA1["PROPOSTA_COPESP"])
            {

                /*" -5956- GO TO 8600-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8600_FIM*/ //GOTO
                return;

                /*" -5958- END-IF. */
            }


            /*" -5959- MOVE '8600-PRIMEIRA-COBRANCA' TO PARAGRAFO. */
            _.Move("8600-PRIMEIRA-COBRANCA", WABEND.PARAGRAFO);

            /*" -5961- MOVE 'UPDATE V0PROPOSTAVA 05' TO COMANDO. */
            _.Move("UPDATE V0PROPOSTAVA 05", WABEND.COMANDO);

            /*" -5965- PERFORM M_8600_CONTINUA_DB_UPDATE_1 */

            M_8600_CONTINUA_DB_UPDATE_1();

            /*" -5969- IF PROPVA-CODPRODU = 7732 OR JVPRD7732 OR 7733 OR JVPRD7733 */

            if (PROPVA_CODPRODU.In("7732", JVBKINCL.JV_PRODUTOS.JVPRD7732.ToString(), "7733", JVBKINCL.JV_PRODUTOS.JVPRD7733.ToString()))
            {

                /*" -5973- PERFORM M_8600_CONTINUA_DB_UPDATE_2 */

                M_8600_CONTINUA_DB_UPDATE_2();

                /*" -5975- END-IF. */
            }


            /*" -5976- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -5978- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -5980- MOVE HISTCB-DTVENCTO TO W05DTSQL. */
            _.Move(HISTCB_DTVENCTO, WS_WORK_AREAS.W05DTSQL);

            /*" -5982- ADD 1 TO W05MMSQL. */
            WS_WORK_AREAS.W05DTSQL.W05MMSQL.Value = WS_WORK_AREAS.W05DTSQL.W05MMSQL + 1;

            /*" -5983- IF W05MMSQL GREATER 12 */

            if (WS_WORK_AREAS.W05DTSQL.W05MMSQL > 12)
            {

                /*" -5984- MOVE 01 TO W05MMSQL */
                _.Move(01, WS_WORK_AREAS.W05DTSQL.W05MMSQL);

                /*" -5986- ADD 01 TO W05AASQL. */
                WS_WORK_AREAS.W05DTSQL.W05AASQL.Value = WS_WORK_AREAS.W05DTSQL.W05AASQL + 01;
            }


            /*" -5986- MOVE W05DTSQL TO PROPVA-DTPROXVEN. */
            _.Move(WS_WORK_AREAS.W05DTSQL, PROPVA_DTPROXVEN);

        }

        [StopWatch]
        /*" M-8600-CONTINUA-DB-UPDATE-1 */
        public void M_8600_CONTINUA_DB_UPDATE_1()
        {
            /*" -5965- EXEC SQL UPDATE SEGUROS.V0PROPOSTAVA SET DTVENCTO = :HISTCB-DTVENCTO WHERE CURRENT OF CPROPVA END-EXEC. */

            var m_8600_CONTINUA_DB_UPDATE_1_Update1 = new M_8600_CONTINUA_DB_UPDATE_1_Update1(CPROPVA)
            {
                HISTCB_DTVENCTO = HISTCB_DTVENCTO.ToString(),
            };

            M_8600_CONTINUA_DB_UPDATE_1_Update1.Execute(m_8600_CONTINUA_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-8600-10-CONTINUA-DB-INSERT-2 */
        public void M_8600_10_CONTINUA_DB_INSERT_2()
        {
            /*" -5904- EXEC SQL INSERT INTO SEGUROS.V0HISTCOBVA VALUES (:PROPVA-NRCERTIF, 1, :BANCOS-NRTIT, :HISTCB-DTVENCTO, :DESCON-VLPREMIO, :OPCAOP-OPCAOPAG, :HISTCB-SITUACAO, 0, 0, 0, 0, 0, 0, 0) END-EXEC. */

            var m_8600_10_CONTINUA_DB_INSERT_2_Insert1 = new M_8600_10_CONTINUA_DB_INSERT_2_Insert1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                BANCOS_NRTIT = BANCOS_NRTIT.ToString(),
                HISTCB_DTVENCTO = HISTCB_DTVENCTO.ToString(),
                DESCON_VLPREMIO = DESCON_VLPREMIO.ToString(),
                OPCAOP_OPCAOPAG = OPCAOP_OPCAOPAG.ToString(),
                HISTCB_SITUACAO = HISTCB_SITUACAO.ToString(),
            };

            M_8600_10_CONTINUA_DB_INSERT_2_Insert1.Execute(m_8600_10_CONTINUA_DB_INSERT_2_Insert1);

        }

        [StopWatch]
        /*" M-8600-CONTINUA-DB-UPDATE-2 */
        public void M_8600_CONTINUA_DB_UPDATE_2()
        {
            /*" -5973- EXEC SQL UPDATE SEGUROS.V0PROPOSTAVA SET DTVENCTO = :WS-PROPVA-DTPROXVEN WHERE CURRENT OF CPROPVA END-EXEC */

            var m_8600_CONTINUA_DB_UPDATE_2_Update1 = new M_8600_CONTINUA_DB_UPDATE_2_Update1(CPROPVA)
            {
                WS_PROPVA_DTPROXVEN = WS_PROPVA_DTPROXVEN.ToString(),
            };

            M_8600_CONTINUA_DB_UPDATE_2_Update1.Execute(m_8600_CONTINUA_DB_UPDATE_2_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8600_FIM*/

        [StopWatch]
        /*" M-8600-10-CONTINUA-DB-INSERT-3 */
        public void M_8600_10_CONTINUA_DB_INSERT_3()
        {
            /*" -5932- EXEC SQL INSERT INTO SEGUROS.V0DIFPARCELVA VALUES (:PROPVA-NRCERTIF, 1, 1, 680, :HISTCB-DTVENCTO, 0, 0, 0, 0, :DESCON-PRMVG, :DESCON-PRMAP, 0, ' ' ) END-EXEC. */

            var m_8600_10_CONTINUA_DB_INSERT_3_Insert1 = new M_8600_10_CONTINUA_DB_INSERT_3_Insert1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                HISTCB_DTVENCTO = HISTCB_DTVENCTO.ToString(),
                DESCON_PRMVG = DESCON_PRMVG.ToString(),
                DESCON_PRMAP = DESCON_PRMAP.ToString(),
            };

            M_8600_10_CONTINUA_DB_INSERT_3_Insert1.Execute(m_8600_10_CONTINUA_DB_INSERT_3_Insert1);

        }

        [StopWatch]
        /*" M-8700-GERA-DEBITO */
        private void M_8700_GERA_DEBITO(bool isPerform = false)
        {
            /*" -5996- MOVE '8700-GERA-DEBITO' TO PARAGRAFO. */
            _.Move("8700-GERA-DEBITO", WABEND.PARAGRAFO);

            /*" -5999- MOVE 'SELECT V0CONVENIOSVG' TO COMANDO. */
            _.Move("SELECT V0CONVENIOSVG", WABEND.COMANDO);

            /*" -6008- PERFORM M_8700_GERA_DEBITO_DB_SELECT_1 */

            M_8700_GERA_DEBITO_DB_SELECT_1();

            /*" -6011- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6013- DISPLAY '*** PROBLEMAS NO ACESSO A V0CONVSICOV ' PROPVA-CODPRODU */
                _.Display($"*** PROBLEMAS NO ACESSO A V0CONVSICOV {PROPVA_CODPRODU}");

                /*" -6015- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -6016- IF OPCAOP-OPCAOPAG EQUAL '1' OR '2' */

            if (OPCAOP_OPCAOPAG.In("1", "2"))
            {

                /*" -6017- MOVE ZEROS TO OPCAOP-CARTAOCRED */
                _.Move(0, OPCAOP_CARTAOCRED);

                /*" -6019- MOVE CONVEN-CODCONV TO HOST-CODCONV. */
                _.Move(CONVEN_CODCONV, HOST_CODCONV);
            }


            /*" -6020- IF OPCAOP-OPCAOPAG EQUAL '5' */

            if (OPCAOP_OPCAOPAG == "5")
            {

                /*" -6024- MOVE ZEROS TO OPCAOP-AGECTADEB OPCAOP-OPRCTADEB OPCAOP-NUMCTADEB OPCAOP-DIGCTADEB */
                _.Move(0, OPCAOP_AGECTADEB, OPCAOP_OPRCTADEB, OPCAOP_NUMCTADEB, OPCAOP_DIGCTADEB);

                /*" -6026- MOVE CONVEN-CARTAO TO HOST-CODCONV. */
                _.Move(CONVEN_CARTAO, HOST_CODCONV);
            }


            /*" -6075- MOVE 'INSERT V0HISTCONTAVA' TO COMANDO. */
            _.Move("INSERT V0HISTCONTAVA", WABEND.COMANDO);

            /*" -6077- IF PROPVA-CODPRODU NOT = 7732 AND JVPRD7732 AND 7733 AND JVPRD7733 */

            if (!PROPVA_CODPRODU.In("7732", JVBKINCL.JV_PRODUTOS.JVPRD7732.ToString(), "7733", JVBKINCL.JV_PRODUTOS.JVPRD7733.ToString()))
            {

                /*" -6119- PERFORM M_8700_GERA_DEBITO_DB_INSERT_1 */

                M_8700_GERA_DEBITO_DB_INSERT_1();

                /*" -6122- END-IF. */
            }


            /*" -6123- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6173- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -6175- IF OPCAOP-OPCAOPAG EQUAL '5' AND PROPVA-ORIGEM-PROPOSTA EQUAL 12 */

            if (OPCAOP_OPCAOPAG == "5" && PROPVA_ORIGEM_PROPOSTA == 12)
            {

                /*" -6176- PERFORM 8400-00-DEBITO-CARTAO THRU 8400-FIM */

                M_8400_00_DEBITO_CARTAO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8400_FIM*/


                /*" -6176- END-IF. */
            }


        }

        [StopWatch]
        /*" M-8700-GERA-DEBITO-DB-SELECT-1 */
        public void M_8700_GERA_DEBITO_DB_SELECT_1()
        {
            /*" -6008- EXEC SQL SELECT COD_SEGURO, COD_CONV_CARTAO INTO :CONVEN-CODCONV, :CONVEN-CARTAO FROM SEGUROS.V0CONVENIOSVG WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE AND CODSUBES = :PROPVA-CODSUBES WITH UR END-EXEC. */

            var m_8700_GERA_DEBITO_DB_SELECT_1_Query1 = new M_8700_GERA_DEBITO_DB_SELECT_1_Query1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
            };

            var executed_1 = M_8700_GERA_DEBITO_DB_SELECT_1_Query1.Execute(m_8700_GERA_DEBITO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONVEN_CODCONV, CONVEN_CODCONV);
                _.Move(executed_1.CONVEN_CARTAO, CONVEN_CARTAO);
            }


        }

        [StopWatch]
        /*" M-8700-GERA-DEBITO-DB-INSERT-1 */
        public void M_8700_GERA_DEBITO_DB_INSERT_1()
        {
            /*" -6119- EXEC SQL INSERT INTO SEGUROS.V0HISTCONTAVA (NRCERTIF , NRPARCEL , OCORRHISTCTA , AGECTADEB , OPRCTADEB , NUMCTADEB , DIGCTADEB , DTVENCTO , VLPRMTOT , SITUACAO , TIPLANC , TIMESTAMP , OCORHIST , CODCONV , NSAS , NSL , NSAC , CODRET , CODUSU , NUM_CARTAO_CREDITO) VALUES (:PROPVA-NRCERTIF, 1, 1, :OPCAOP-AGECTADEB, :OPCAOP-OPRCTADEB, :OPCAOP-NUMCTADEB, :OPCAOP-DIGCTADEB, :HISTCB-DTVENCTO, :DESCON-VLPREMIO, '0' , '1' , CURRENT TIMESTAMP, 0, :HOST-CODCONV, NULL, NULL, NULL, NULL, NULL, :OPCAOP-CARTAOCRED) END-EXEC */

            var m_8700_GERA_DEBITO_DB_INSERT_1_Insert1 = new M_8700_GERA_DEBITO_DB_INSERT_1_Insert1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                OPCAOP_AGECTADEB = OPCAOP_AGECTADEB.ToString(),
                OPCAOP_OPRCTADEB = OPCAOP_OPRCTADEB.ToString(),
                OPCAOP_NUMCTADEB = OPCAOP_NUMCTADEB.ToString(),
                OPCAOP_DIGCTADEB = OPCAOP_DIGCTADEB.ToString(),
                HISTCB_DTVENCTO = HISTCB_DTVENCTO.ToString(),
                DESCON_VLPREMIO = DESCON_VLPREMIO.ToString(),
                HOST_CODCONV = HOST_CODCONV.ToString(),
                OPCAOP_CARTAOCRED = OPCAOP_CARTAOCRED.ToString(),
            };

            M_8700_GERA_DEBITO_DB_INSERT_1_Insert1.Execute(m_8700_GERA_DEBITO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8700_FIM*/

        [StopWatch]
        /*" M-8800-APROPRIA-FUNDO */
        private void M_8800_APROPRIA_FUNDO(bool isPerform = false)
        {
            /*" -6187- MOVE '8800-APROPRIA-FUNDO' TO PARAGRAFO. */
            _.Move("8800-APROPRIA-FUNDO", WABEND.PARAGRAFO);

            /*" -6190- MOVE 'SELECT V0PARCOMVA 0' TO COMANDO. */
            _.Move("SELECT V0PARCOMVA 0", WABEND.COMANDO);

            /*" -6200- PERFORM M_8800_APROPRIA_FUNDO_DB_SELECT_1 */

            M_8800_APROPRIA_FUNDO_DB_SELECT_1();

            /*" -6202- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -6203- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -6204- MOVE 0 TO FUNDO-PCCOMIND */
                    _.Move(0, FUNDO_PCCOMIND);

                    /*" -6205- ELSE */
                }
                else
                {


                    /*" -6206- DISPLAY 'ERRO SEGUROS.V0PARCOMVA TIPCOM  =  0' */
                    _.Display($"ERRO SEGUROS.V0PARCOMVA TIPCOM  =  0");

                    /*" -6207- DISPLAY 'CODPRODU          = ' PROPVA-CODPRODU */
                    _.Display($"CODPRODU          = {PROPVA_CODPRODU}");

                    /*" -6208- DISPLAY 'OPCAP PERIODO PAG = ' OPCAOP-PERIPGTO */
                    _.Display($"OPCAP PERIODO PAG = {OPCAOP_PERIPGTO}");

                    /*" -6209- DISPLAY 'DT INIVIGENCIA    = ' PROPVA-DTQITBCO */
                    _.Display($"DT INIVIGENCIA    = {PROPVA_DTQITBCO}");

                    /*" -6211- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -6214- MOVE 'SELECT V0PARCOMVA 1' TO COMANDO. */
            _.Move("SELECT V0PARCOMVA 1", WABEND.COMANDO);

            /*" -6224- PERFORM M_8800_APROPRIA_FUNDO_DB_SELECT_2 */

            M_8800_APROPRIA_FUNDO_DB_SELECT_2();

            /*" -6228- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -6229- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -6230- MOVE 0 TO FUNDO-PCCOMGER */
                    _.Move(0, FUNDO_PCCOMGER);

                    /*" -6231- ELSE */
                }
                else
                {


                    /*" -6232- DISPLAY 'ERRO SEGUROS.V0PARCOMVA TIPCOM  =  1' */
                    _.Display($"ERRO SEGUROS.V0PARCOMVA TIPCOM  =  1");

                    /*" -6233- DISPLAY 'CODPRODU          = ' PROPVA-CODPRODU */
                    _.Display($"CODPRODU          = {PROPVA_CODPRODU}");

                    /*" -6234- DISPLAY 'OPCAP PERIODO PAG = ' OPCAOP-PERIPGTO */
                    _.Display($"OPCAP PERIODO PAG = {OPCAOP_PERIPGTO}");

                    /*" -6235- DISPLAY 'DT INIVIGENCIA    = ' PROPVA-DTQITBCO */
                    _.Display($"DT INIVIGENCIA    = {PROPVA_DTQITBCO}");

                    /*" -6237- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -6240- MOVE 'SELECT V0PARCOMVA 2' TO COMANDO. */
            _.Move("SELECT V0PARCOMVA 2", WABEND.COMANDO);

            /*" -6250- PERFORM M_8800_APROPRIA_FUNDO_DB_SELECT_3 */

            M_8800_APROPRIA_FUNDO_DB_SELECT_3();

            /*" -6253- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -6254- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -6255- MOVE 0 TO FUNDO-PCCOMSUP */
                    _.Move(0, FUNDO_PCCOMSUP);

                    /*" -6256- ELSE */
                }
                else
                {


                    /*" -6257- DISPLAY 'ERRO SEGUROS.V0PARCOMVA TIPCOM  =  1' */
                    _.Display($"ERRO SEGUROS.V0PARCOMVA TIPCOM  =  1");

                    /*" -6258- DISPLAY 'CODPRODU          = ' PROPVA-CODPRODU */
                    _.Display($"CODPRODU          = {PROPVA_CODPRODU}");

                    /*" -6259- DISPLAY 'OPCAP PERIODO PAG = ' OPCAOP-PERIPGTO */
                    _.Display($"OPCAP PERIODO PAG = {OPCAOP_PERIPGTO}");

                    /*" -6260- DISPLAY 'DT INIVIGENCIA    = ' PROPVA-DTQITBCO */
                    _.Display($"DT INIVIGENCIA    = {PROPVA_DTQITBCO}");

                    /*" -6262- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -6263- IF PARAMRAM-NUM-RAMO-PRSTMISTA EQUAL V1APOL-RAMO */

            if (PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_NUM_RAMO_PRSTMISTA == V1APOL_RAMO)
            {

                /*" -6264- IF PROPVA-ORIGEM-PROPOSTA = 13 OR 14 */

                if (PROPVA_ORIGEM_PROPOSTA.In("13", "14"))
                {

                    /*" -6265- MOVE 11 TO FUNDO-PCCOMIND */
                    _.Move(11, FUNDO_PCCOMIND);

                    /*" -6266- ELSE */
                }
                else
                {


                    /*" -6267- MOVE 16 TO FUNDO-PCCOMIND */
                    _.Move(16, FUNDO_PCCOMIND);

                    /*" -6268- END-IF */
                }


                /*" -6270- END-IF. */
            }


            /*" -6273- IF FUNDO-PCCOMIND EQUAL ZEROES AND FUNDO-PCCOMGER EQUAL ZEROES AND FUNDO-PCCOMSUP EQUAL ZEROES */

            if (FUNDO_PCCOMIND == 00 && FUNDO_PCCOMGER == 00 && FUNDO_PCCOMSUP == 00)
            {

                /*" -6274- DISPLAY 'PARAMETROS DE COMISSAO NAO ENCONTRADOS ' */
                _.Display($"PARAMETROS DE COMISSAO NAO ENCONTRADOS ");

                /*" -6275- DISPLAY 'CODPRODU          = ' PROPVA-CODPRODU */
                _.Display($"CODPRODU          = {PROPVA_CODPRODU}");

                /*" -6276- DISPLAY 'OPCAP PERIODO PAG = ' OPCAOP-PERIPGTO */
                _.Display($"OPCAP PERIODO PAG = {OPCAOP_PERIPGTO}");

                /*" -6277- DISPLAY 'DT INIVIGENCIA    = ' PROPVA-DTQITBCO */
                _.Display($"DT INIVIGENCIA    = {PROPVA_DTQITBCO}");

                /*" -6279- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -6285- COMPUTE FUNDO-PCCOMTOT = FUNDO-PCCOMIND + FUNDO-PCCOMGER + FUNDO-PCCOMSUP. */
            FUNDO_PCCOMTOT.Value = FUNDO_PCCOMIND + FUNDO_PCCOMGER + FUNDO_PCCOMSUP;

            /*" -6287- MOVE MDTMOVTO TO V1RIND-DTINIVIG */
            _.Move(MDTMOVTO, V1RIND_DTINIVIG);

            /*" -6290- MOVE 'SELECT V1RAMOIND' TO COMANDO */
            _.Move("SELECT V1RAMOIND", WABEND.COMANDO);

            /*" -6298- PERFORM M_8800_APROPRIA_FUNDO_DB_SELECT_4 */

            M_8800_APROPRIA_FUNDO_DB_SELECT_4();

            /*" -6301- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -6302- DISPLAY 'ERRO SELECT SEGUROS.V1RAMOIND ' */
                _.Display($"ERRO SELECT SEGUROS.V1RAMOIND ");

                /*" -6303- DISPLAY 'RAMO     = ' V1APOL-RAMO */
                _.Display($"RAMO     = {V1APOL_RAMO}");

                /*" -6304- DISPLAY 'DTINIVIG = ' V1RIND-DTINIVIG */
                _.Display($"DTINIVIG = {V1RIND_DTINIVIG}");

                /*" -6306- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -6308- COMPUTE WS-IND-IOF ROUNDED = (1 + (V1RIND-PCIOF / 100)) */
            WS_WORK_AREAS.WS_IND_IOF.Value = (1 + (V1RIND_PCIOF / 100f));

            /*" -6309- COMPUTE FUNDO-VALBASVG ROUNDED = COBERP-PRMVG / WS-IND-IOF */
            FUNDO_VALBASVG.Value = COBERP_PRMVG / WS_WORK_AREAS.WS_IND_IOF;

            /*" -6311- COMPUTE FUNDO-VALBASAP ROUNDED = COBERP-PRMAP / WS-IND-IOF */
            FUNDO_VALBASAP.Value = COBERP_PRMAP / WS_WORK_AREAS.WS_IND_IOF;

            /*" -6313- COMPUTE FUNDO-VLCOMISVG ROUNDED = (FUNDO-VALBASVG * FUNDO-PCCOMTOT) / 100. */
            FUNDO_VLCOMISVG.Value = (FUNDO_VALBASVG * FUNDO_PCCOMTOT) / 100f;

            /*" -6316- COMPUTE FUNDO-VLCOMISAP ROUNDED = (FUNDO-VALBASAP * FUNDO-PCCOMTOT) / 100. */
            FUNDO_VLCOMISAP.Value = (FUNDO_VALBASAP * FUNDO_PCCOMTOT) / 100f;

            /*" -6319- MOVE 'INSERT V0FUNDOCOMISVA' TO COMANDO. */
            _.Move("INSERT V0FUNDOCOMISVA", WABEND.COMANDO);

            /*" -6363- PERFORM M_8800_APROPRIA_FUNDO_DB_INSERT_1 */

            M_8800_APROPRIA_FUNDO_DB_INSERT_1();

            /*" -6366- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6366- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-8800-APROPRIA-FUNDO-DB-SELECT-1 */
        public void M_8800_APROPRIA_FUNDO_DB_SELECT_1()
        {
            /*" -6200- EXEC SQL SELECT PCCOMCOR INTO :FUNDO-PCCOMIND FROM SEGUROS.V0PARCOMVA WHERE CODPRODU = :PROPVA-CODPRODU AND PERIPGTO = :OPCAOP-PERIPGTO AND DTINIVIG <= :PROPVA-DTQITBCO AND DTTERVIG >= :PROPVA-DTQITBCO AND TIPCOM = '0' WITH UR END-EXEC. */

            var m_8800_APROPRIA_FUNDO_DB_SELECT_1_Query1 = new M_8800_APROPRIA_FUNDO_DB_SELECT_1_Query1()
            {
                PROPVA_CODPRODU = PROPVA_CODPRODU.ToString(),
                OPCAOP_PERIPGTO = OPCAOP_PERIPGTO.ToString(),
                PROPVA_DTQITBCO = PROPVA_DTQITBCO.ToString(),
            };

            var executed_1 = M_8800_APROPRIA_FUNDO_DB_SELECT_1_Query1.Execute(m_8800_APROPRIA_FUNDO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FUNDO_PCCOMIND, FUNDO_PCCOMIND);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8800_FIM*/

        [StopWatch]
        /*" M-8800-APROPRIA-FUNDO-DB-SELECT-2 */
        public void M_8800_APROPRIA_FUNDO_DB_SELECT_2()
        {
            /*" -6224- EXEC SQL SELECT PCCOMCOR INTO :FUNDO-PCCOMGER FROM SEGUROS.V0PARCOMVA WHERE CODPRODU = :PROPVA-CODPRODU AND PERIPGTO = :OPCAOP-PERIPGTO AND DTINIVIG <= :PROPVA-DTQITBCO AND DTTERVIG >= :PROPVA-DTQITBCO AND TIPCOM = '1' WITH UR END-EXEC. */

            var m_8800_APROPRIA_FUNDO_DB_SELECT_2_Query1 = new M_8800_APROPRIA_FUNDO_DB_SELECT_2_Query1()
            {
                PROPVA_CODPRODU = PROPVA_CODPRODU.ToString(),
                OPCAOP_PERIPGTO = OPCAOP_PERIPGTO.ToString(),
                PROPVA_DTQITBCO = PROPVA_DTQITBCO.ToString(),
            };

            var executed_1 = M_8800_APROPRIA_FUNDO_DB_SELECT_2_Query1.Execute(m_8800_APROPRIA_FUNDO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FUNDO_PCCOMGER, FUNDO_PCCOMGER);
            }


        }

        [StopWatch]
        /*" R7770-00-PROPOSTAS-SIVPF-SIVPF */
        private void R7770_00_PROPOSTAS_SIVPF_SIVPF(bool isPerform = false)
        {
            /*" -6377- MOVE 'R7770-00-PROPOSTAS-SIVPF-SIVPF' TO PARAGRAFO. */
            _.Move("R7770-00-PROPOSTAS-SIVPF-SIVPF", WABEND.PARAGRAFO);

            /*" -6379- MOVE 'R7770-00-PROPOST' TO COMANDO. */
            _.Move("R7770-00-PROPOST", WABEND.COMANDO);

            /*" -6380- IF NAO-LEU-SIVPF */

            if (WS_WORK_AREAS.WS_LEITUA_SIVPF["NAO_LEU_SIVPF"])
            {

                /*" -6383- PERFORM R7771-00-LER-PROP-SIVPF THRU R7771-FIM. */

                R7771_00_LER_PROP_SIVPF(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R7771_FIM*/

            }


            /*" -6384- IF WTEM-SIVPF EQUAL 1 */

            if (WS_WORK_AREAS.WTEM_SIVPF == 1)
            {

                /*" -6387- PERFORM R7772-00-VERIFICA-ATUALIZACOES THRU R7772-FIM */

                R7772_00_VERIFICA_ATUALIZACOES(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R7772_FIM*/


                /*" -6390- PERFORM R7775-00-UPD-PROP-SIVPF-SIVPF THRU R7775-FIM */

                R7775_00_UPD_PROP_SIVPF_SIVPF(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R7775_FIM*/


                /*" -6391- ADD 1 TO UPDATE-SIVPF-SIVPF. */
                WS_WORK_AREAS.UPDATE_SIVPF_SIVPF.Value = WS_WORK_AREAS.UPDATE_SIVPF_SIVPF + 1;
            }


        }

        [StopWatch]
        /*" M-8800-APROPRIA-FUNDO-DB-INSERT-1 */
        public void M_8800_APROPRIA_FUNDO_DB_INSERT_1()
        {
            /*" -6363- EXEC SQL INSERT INTO SEGUROS.V0FUNDOCOMISVA (CODPRODU , NRCERTIF , NRPROPAZ , NUM_TERMO, SITUACAO , CODOPER , FONTE , AGENCIA , CODCLIEN , NRMATRVEN, VLBASVG , VALBASAP , VLCOMISVG, VLCOMISAP, DTQITBCO , PCCOMIND , PCCOMGER , PCCOMSUP , DTMOVTO , COD_USUARIO, TIMESTAMP) VALUES (:PROPVA-CODPRODU, :PROPVA-NRCERTIF, 0, 0, '0' , 1101, :PROPVA-FONTE, :PROPVA-AGECOBR, :PROPVA-CODCLIEN, :PROPVA-NRMATRVEN, :FUNDO-VALBASVG, :FUNDO-VALBASAP, :FUNDO-VLCOMISVG, :FUNDO-VLCOMISAP, :PROPVA-DTQITBCO, :FUNDO-PCCOMIND, :FUNDO-PCCOMGER, :FUNDO-PCCOMSUP, :SISTEMA-DTMOVABE, 'VP0121B' , CURRENT TIMESTAMP) END-EXEC. */

            var m_8800_APROPRIA_FUNDO_DB_INSERT_1_Insert1 = new M_8800_APROPRIA_FUNDO_DB_INSERT_1_Insert1()
            {
                PROPVA_CODPRODU = PROPVA_CODPRODU.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                PROPVA_FONTE = PROPVA_FONTE.ToString(),
                PROPVA_AGECOBR = PROPVA_AGECOBR.ToString(),
                PROPVA_CODCLIEN = PROPVA_CODCLIEN.ToString(),
                PROPVA_NRMATRVEN = PROPVA_NRMATRVEN.ToString(),
                FUNDO_VALBASVG = FUNDO_VALBASVG.ToString(),
                FUNDO_VALBASAP = FUNDO_VALBASAP.ToString(),
                FUNDO_VLCOMISVG = FUNDO_VLCOMISVG.ToString(),
                FUNDO_VLCOMISAP = FUNDO_VLCOMISAP.ToString(),
                PROPVA_DTQITBCO = PROPVA_DTQITBCO.ToString(),
                FUNDO_PCCOMIND = FUNDO_PCCOMIND.ToString(),
                FUNDO_PCCOMGER = FUNDO_PCCOMGER.ToString(),
                FUNDO_PCCOMSUP = FUNDO_PCCOMSUP.ToString(),
                SISTEMA_DTMOVABE = SISTEMA_DTMOVABE.ToString(),
            };

            M_8800_APROPRIA_FUNDO_DB_INSERT_1_Insert1.Execute(m_8800_APROPRIA_FUNDO_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" M-8800-APROPRIA-FUNDO-DB-SELECT-3 */
        public void M_8800_APROPRIA_FUNDO_DB_SELECT_3()
        {
            /*" -6250- EXEC SQL SELECT PCCOMCOR INTO :FUNDO-PCCOMSUP FROM SEGUROS.V0PARCOMVA WHERE CODPRODU = :PROPVA-CODPRODU AND PERIPGTO = :OPCAOP-PERIPGTO AND DTINIVIG <= :PROPVA-DTQITBCO AND DTTERVIG >= :PROPVA-DTQITBCO AND TIPCOM = '2' WITH UR END-EXEC. */

            var m_8800_APROPRIA_FUNDO_DB_SELECT_3_Query1 = new M_8800_APROPRIA_FUNDO_DB_SELECT_3_Query1()
            {
                PROPVA_CODPRODU = PROPVA_CODPRODU.ToString(),
                OPCAOP_PERIPGTO = OPCAOP_PERIPGTO.ToString(),
                PROPVA_DTQITBCO = PROPVA_DTQITBCO.ToString(),
            };

            var executed_1 = M_8800_APROPRIA_FUNDO_DB_SELECT_3_Query1.Execute(m_8800_APROPRIA_FUNDO_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FUNDO_PCCOMSUP, FUNDO_PCCOMSUP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7770_FIM*/

        [StopWatch]
        /*" M-8800-APROPRIA-FUNDO-DB-SELECT-4 */
        public void M_8800_APROPRIA_FUNDO_DB_SELECT_4()
        {
            /*" -6298- EXEC SQL SELECT PCIOF INTO :V1RIND-PCIOF FROM SEGUROS.V1RAMOIND WHERE RAMO = :V1APOL-RAMO AND DTINIVIG <= :V1RIND-DTINIVIG AND DTTERVIG >= :V1RIND-DTINIVIG WITH UR END-EXEC. */

            var m_8800_APROPRIA_FUNDO_DB_SELECT_4_Query1 = new M_8800_APROPRIA_FUNDO_DB_SELECT_4_Query1()
            {
                V1RIND_DTINIVIG = V1RIND_DTINIVIG.ToString(),
                V1APOL_RAMO = V1APOL_RAMO.ToString(),
            };

            var executed_1 = M_8800_APROPRIA_FUNDO_DB_SELECT_4_Query1.Execute(m_8800_APROPRIA_FUNDO_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1RIND_PCIOF, V1RIND_PCIOF);
            }


        }

        [StopWatch]
        /*" R7771-00-LER-PROP-SIVPF */
        private void R7771_00_LER_PROP_SIVPF(bool isPerform = false)
        {
            /*" -6400- MOVE ZEROS TO WTEM-SIVPF. */
            _.Move(0, WS_WORK_AREAS.WTEM_SIVPF);

            /*" -6402- MOVE 'SELECT PROPOSTA-FIDELIZ' TO COMANDO */
            _.Move("SELECT PROPOSTA-FIDELIZ", WABEND.COMANDO);

            /*" -6404- MOVE PROPVA-NRCERTIF TO SIVPF-NR-PROPOSTA. */
            _.Move(PROPVA_NRCERTIF, SIVPF_NR_PROPOSTA);

            /*" -6406- MOVE 'S' TO WS-LEITUA-SIVPF. */
            _.Move("S", WS_WORK_AREAS.WS_LEITUA_SIVPF);

            /*" -6425- PERFORM R7771_00_LER_PROP_SIVPF_DB_SELECT_1 */

            R7771_00_LER_PROP_SIVPF_DB_SELECT_1();

            /*" -6428- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -6429- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -6430- DISPLAY 'ERRO SELECT PROPOSTA_FIDELIZ' */
                    _.Display($"ERRO SELECT PROPOSTA_FIDELIZ");

                    /*" -6431- DISPLAY 'NUM PROPOSTA SIVPF = ' SIVPF-NR-PROPOSTA */
                    _.Display($"NUM PROPOSTA SIVPF = {SIVPF_NR_PROPOSTA}");

                    /*" -6433- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -6434- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -6435- MOVE 1 TO WTEM-SIVPF. */
                _.Move(1, WS_WORK_AREAS.WTEM_SIVPF);
            }


        }

        [StopWatch]
        /*" R7771-00-LER-PROP-SIVPF-DB-SELECT-1 */
        public void R7771_00_LER_PROP_SIVPF_DB_SELECT_1()
        {
            /*" -6425- EXEC SQL SELECT NUM_IDENTIFICACAO, NUM_SICOB, SIT_PROPOSTA, DTQITBCO, VAL_PAGO, DATA_CREDITO, OPCAO_COBER, COD_PLANO INTO :SIVPF-NR-IDENTIFI, :SIVPF-NR-SICOB, :SIVPF-SIT-PROPOSTA, :SIVPF-DTQITBCO, :SIVPF-VAL-PAGO, :SIVPF-DATA-CREDITO, :SIVPF-OPCAO-COBER, :SIVPF-COD-PLANO FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_PROPOSTA_SIVPF = :SIVPF-NR-PROPOSTA END-EXEC. */

            var r7771_00_LER_PROP_SIVPF_DB_SELECT_1_Query1 = new R7771_00_LER_PROP_SIVPF_DB_SELECT_1_Query1()
            {
                SIVPF_NR_PROPOSTA = SIVPF_NR_PROPOSTA.ToString(),
            };

            var executed_1 = R7771_00_LER_PROP_SIVPF_DB_SELECT_1_Query1.Execute(r7771_00_LER_PROP_SIVPF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SIVPF_NR_IDENTIFI, SIVPF_NR_IDENTIFI);
                _.Move(executed_1.SIVPF_NR_SICOB, SIVPF_NR_SICOB);
                _.Move(executed_1.SIVPF_SIT_PROPOSTA, SIVPF_SIT_PROPOSTA);
                _.Move(executed_1.SIVPF_DTQITBCO, SIVPF_DTQITBCO);
                _.Move(executed_1.SIVPF_VAL_PAGO, SIVPF_VAL_PAGO);
                _.Move(executed_1.SIVPF_DATA_CREDITO, SIVPF_DATA_CREDITO);
                _.Move(executed_1.SIVPF_OPCAO_COBER, SIVPF_OPCAO_COBER);
                _.Move(executed_1.SIVPF_COD_PLANO, SIVPF_COD_PLANO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7771_FIM*/

        [StopWatch]
        /*" R7772-00-VERIFICA-ATUALIZACOES */
        private void R7772_00_VERIFICA_ATUALIZACOES(bool isPerform = false)
        {
            /*" -6445- MOVE 'R7772-00-VERIFIC' TO COMANDO. */
            _.Move("R7772-00-VERIFIC", WABEND.COMANDO);

            /*" -6448- MOVE ZERO TO W-RCAPS W-RCAP-COMP. */
            _.Move(0, WS_WORK_AREAS.W_RCAPS, WS_WORK_AREAS.W_RCAP_COMP);

            /*" -6449- IF SIVPF-OPCAO-COBER EQUAL SPACES */

            if (SIVPF_OPCAO_COBER.IsEmpty())
            {

                /*" -6451- MOVE PROPVA-OPCAO-COBER TO SIVPF-OPCAO-COBER. */
                _.Move(PROPVA_OPCAO_COBER, SIVPF_OPCAO_COBER);
            }


            /*" -6452- IF CANAL-VENDA-GITEL */

            if (WS_WORK_AREAS.CANAL.W_CANAL_PROPOSTA["CANAL_VENDA_GITEL"])
            {

                /*" -6453- MOVE PROPVA-DTQITBCO TO SIVPF-DTQITBCO */
                _.Move(PROPVA_DTQITBCO, SIVPF_DTQITBCO);

                /*" -6454- MOVE SISTEMA-DTMOVABE TO SIVPF-DATA-CREDITO */
                _.Move(SISTEMA_DTMOVABE, SIVPF_DATA_CREDITO);

                /*" -6455- MOVE COBERP-VLPREMIO TO SIVPF-VAL-PAGO */
                _.Move(COBERP_VLPREMIO, SIVPF_VAL_PAGO);

                /*" -6456- GO TO R7772-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R7772_FIM*/ //GOTO
                return;

                /*" -6458- END-IF. */
            }


            /*" -6463- IF SIVPF-DTQITBCO EQUAL '0001-01-01' OR SIVPF-DTQITBCO EQUAL '1900-01-01' OR SIVPF-DATA-CREDITO EQUAL '0001-01-01' OR SIVPF-DATA-CREDITO EQUAL '1901-01-01' OR SIVPF-VAL-PAGO EQUAL ZEROS */

            if (SIVPF_DTQITBCO == "0001-01-01" || SIVPF_DTQITBCO == "1900-01-01" || SIVPF_DATA_CREDITO == "0001-01-01" || SIVPF_DATA_CREDITO == "1901-01-01" || SIVPF_VAL_PAGO == 00)
            {

                /*" -6466- MOVE SIVPF-NR-SICOB TO RCAPS-NUM-TITULO OF DCLRCAPS */
                _.Move(SIVPF_NR_SICOB, RCAPS.DCLRCAPS.RCAPS_NUM_TITULO);

                /*" -6469- PERFORM R7773-00-LER-RCAPS THRU R7773-FIM */

                R7773_00_LER_RCAPS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R7773_FIM*/


                /*" -6470- IF NOT RCAP-CADASTRADO */

                if (!WS_WORK_AREAS.W_RCAPS["RCAP_CADASTRADO"])
                {

                    /*" -6471- DISPLAY 'VP0121B - PROBLEMAS NO ACESSO A RCAP' */
                    _.Display($"VP0121B - PROBLEMAS NO ACESSO A RCAP");

                    /*" -6473- DISPLAY '          NUMERO DO TITULO......... ' RCAPS-NUM-TITULO OF DCLRCAPS */
                    _.Display($"          NUMERO DO TITULO......... {RCAPS.DCLRCAPS.RCAPS_NUM_TITULO}");

                    /*" -6475- DISPLAY '          SQLCODE.................. ' SQLCODE */
                    _.Display($"          SQLCODE.................. {DB.SQLCODE}");

                    /*" -6476- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -6478- ELSE */
                }
                else
                {


                    /*" -6481- PERFORM R7774-00-LER-RCAP-COMP THRU R7774-FIM */

                    R7774_00_LER_RCAP_COMP(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R7774_FIM*/


                    /*" -6482- IF NOT RCAP-COMP-CADASTRADO */

                    if (!WS_WORK_AREAS.W_RCAP_COMP["RCAP_COMP_CADASTRADO"])
                    {

                        /*" -6483- DISPLAY 'VP0121B - PROBLEMAS ACESSO RCAP-COMP' */
                        _.Display($"VP0121B - PROBLEMAS ACESSO RCAP-COMP");

                        /*" -6485- DISPLAY '          CODIGO DA FONTE.......... ' RCAPS-COD-FONTE OF DCLRCAPS */
                        _.Display($"          CODIGO DA FONTE.......... {RCAPS.DCLRCAPS.RCAPS_COD_FONTE}");

                        /*" -6487- DISPLAY '          NUM RCAP................. ' RCAPS-NUM-RCAP OF DCLRCAPS */
                        _.Display($"          NUM RCAP................. {RCAPS.DCLRCAPS.RCAPS_NUM_RCAP}");

                        /*" -6489- DISPLAY '          SQLCODE.................. ' SQLCODE */
                        _.Display($"          SQLCODE.................. {DB.SQLCODE}");

                        /*" -6491- GO TO 9999-ERRO. */

                        M_9999_ERRO(); //GOTO
                        return;
                    }

                }

            }


            /*" -6492- IF RCAP-CADASTRADO */

            if (WS_WORK_AREAS.W_RCAPS["RCAP_CADASTRADO"])
            {

                /*" -6493- IF RCAP-COMP-CADASTRADO */

                if (WS_WORK_AREAS.W_RCAP_COMP["RCAP_COMP_CADASTRADO"])
                {

                    /*" -6495- IF SIVPF-DTQITBCO EQUAL '0001-01-01' OR SIVPF-DTQITBCO EQUAL '1900-01-01' */

                    if (SIVPF_DTQITBCO == "0001-01-01" || SIVPF_DTQITBCO == "1900-01-01")
                    {

                        /*" -6497- MOVE RCAPCOMP-DATA-RCAP OF DCLRCAP-COMPLEMENTAR TO SIVPF-DTQITBCO */
                        _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP, SIVPF_DTQITBCO);

                        /*" -6499- END-IF */
                    }


                    /*" -6501- IF SIVPF-DATA-CREDITO EQUAL '0001-01-01' OR SIVPF-DATA-CREDITO EQUAL '1901-01-01' */

                    if (SIVPF_DATA_CREDITO == "0001-01-01" || SIVPF_DATA_CREDITO == "1901-01-01")
                    {

                        /*" -6503- MOVE RCAPCOMP-DATA-MOVIMENTO OF DCLRCAP-COMPLEMENTAR TO SIVPF-DATA-CREDITO */
                        _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_MOVIMENTO, SIVPF_DATA_CREDITO);

                        /*" -6505- END-IF */
                    }


                    /*" -6506- IF SIVPF-VAL-PAGO EQUAL ZEROS */

                    if (SIVPF_VAL_PAGO == 00)
                    {

                        /*" -6507- MOVE RCAPS-VAL-RCAP OF DCLRCAPS TO SIVPF-VAL-PAGO. */
                        _.Move(RCAPS.DCLRCAPS.RCAPS_VAL_RCAP, SIVPF_VAL_PAGO);
                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7772_FIM*/

        [StopWatch]
        /*" R7773-00-LER-RCAPS */
        private void R7773_00_LER_RCAPS(bool isPerform = false)
        {
            /*" -6518- MOVE 'R7773-00-LER-RCAP' TO PARAGRAFO. */
            _.Move("R7773-00-LER-RCAP", WABEND.PARAGRAFO);

            /*" -6521- MOVE 'R7773-00-LER-RCA' TO COMANDO. */
            _.Move("R7773-00-LER-RCA", WABEND.COMANDO);

            /*" -6531- PERFORM R7773_00_LER_RCAPS_DB_SELECT_1 */

            R7773_00_LER_RCAPS_DB_SELECT_1();

            /*" -6534- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -6535- MOVE 1 TO W-RCAPS */
                _.Move(1, WS_WORK_AREAS.W_RCAPS);

                /*" -6536- ELSE */
            }
            else
            {


                /*" -6538- IF SQLCODE EQUAL 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -6539- ELSE */
                }
                else
                {


                    /*" -6540- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -6540- END-IF. */
                }

            }


        }

        [StopWatch]
        /*" R7773-00-LER-RCAPS-DB-SELECT-1 */
        public void R7773_00_LER_RCAPS_DB_SELECT_1()
        {
            /*" -6531- EXEC SQL SELECT COD_FONTE, NUM_RCAP, VAL_RCAP INTO :DCLRCAPS.RCAPS-COD-FONTE, :DCLRCAPS.RCAPS-NUM-RCAP, :DCLRCAPS.RCAPS-VAL-RCAP FROM SEGUROS.RCAPS WHERE NUM_TITULO =:DCLRCAPS.RCAPS-NUM-TITULO WITH UR END-EXEC. */

            var r7773_00_LER_RCAPS_DB_SELECT_1_Query1 = new R7773_00_LER_RCAPS_DB_SELECT_1_Query1()
            {
                RCAPS_NUM_TITULO = RCAPS.DCLRCAPS.RCAPS_NUM_TITULO.ToString(),
            };

            var executed_1 = R7773_00_LER_RCAPS_DB_SELECT_1_Query1.Execute(r7773_00_LER_RCAPS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPS_COD_FONTE, RCAPS.DCLRCAPS.RCAPS_COD_FONTE);
                _.Move(executed_1.RCAPS_NUM_RCAP, RCAPS.DCLRCAPS.RCAPS_NUM_RCAP);
                _.Move(executed_1.RCAPS_VAL_RCAP, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7773_FIM*/

        [StopWatch]
        /*" R7774-00-LER-RCAP-COMP */
        private void R7774_00_LER_RCAP_COMP(bool isPerform = false)
        {
            /*" -6551- MOVE 'R7774-00-LER-RCAP-CONMP' TO PARAGRAFO. */
            _.Move("R7774-00-LER-RCAP-CONMP", WABEND.PARAGRAFO);

            /*" -6554- MOVE 'R7774-00-LER-RCA' TO COMANDO. */
            _.Move("R7774-00-LER-RCA", WABEND.COMANDO);

            /*" -6571- PERFORM R7774_00_LER_RCAP_COMP_DB_SELECT_1 */

            R7774_00_LER_RCAP_COMP_DB_SELECT_1();

            /*" -6574- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -6575- MOVE 1 TO W-RCAP-COMP */
                _.Move(1, WS_WORK_AREAS.W_RCAP_COMP);

                /*" -6576- ELSE */
            }
            else
            {


                /*" -6579- IF SQLCODE NOT EQUAL 100 AND SQLCODE NOT EQUAL -811 */

                if (DB.SQLCODE != 100 && DB.SQLCODE != -811)
                {

                    /*" -6580- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -6581- ELSE */
                }
                else
                {


                    /*" -6597- PERFORM R7774_00_LER_RCAP_COMP_DB_DECLARE_1 */

                    R7774_00_LER_RCAP_COMP_DB_DECLARE_1();

                    /*" -6599- PERFORM R7774_00_LER_RCAP_COMP_DB_OPEN_1 */

                    R7774_00_LER_RCAP_COMP_DB_OPEN_1();

                    /*" -6602- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -6603- DISPLAY 'VP0121B - PROBLEMAS NO OPEN DA RCAPCOMP' */
                        _.Display($"VP0121B - PROBLEMAS NO OPEN DA RCAPCOMP");

                        /*" -6605- DISPLAY '          CODIGO DA FONTE.............. ' RCAPS-COD-FONTE OF DCLRCAPS */
                        _.Display($"          CODIGO DA FONTE.............. {RCAPS.DCLRCAPS.RCAPS_COD_FONTE}");

                        /*" -6607- DISPLAY '          NUMERO DO RCAP............... ' RCAPS-NUM-RCAP OF DCLRCAPS */
                        _.Display($"          NUMERO DO RCAP............... {RCAPS.DCLRCAPS.RCAPS_NUM_RCAP}");

                        /*" -6609- DISPLAY '          SQLCODE...................... ' SQLCODE */
                        _.Display($"          SQLCODE...................... {DB.SQLCODE}");

                        /*" -6610- GO TO 9999-ERRO */

                        M_9999_ERRO(); //GOTO
                        return;

                        /*" -6612- END-IF */
                    }


                    /*" -6623- PERFORM R7774_00_LER_RCAP_COMP_DB_FETCH_1 */

                    R7774_00_LER_RCAP_COMP_DB_FETCH_1();

                    /*" -6626- IF SQLCODE NOT EQUAL ZEROS AND 100 */

                    if (!DB.SQLCODE.In("00", "100"))
                    {

                        /*" -6627- DISPLAY 'VP0121B - PROBLEMAS NO FETCH DA RCAPCOMP' */
                        _.Display($"VP0121B - PROBLEMAS NO FETCH DA RCAPCOMP");

                        /*" -6629- DISPLAY '          CODIGO DA FONTE.............. ' RCAPS-COD-FONTE OF DCLRCAPS */
                        _.Display($"          CODIGO DA FONTE.............. {RCAPS.DCLRCAPS.RCAPS_COD_FONTE}");

                        /*" -6631- DISPLAY '          NUMERO DO RCAP............... ' RCAPS-NUM-RCAP OF DCLRCAPS */
                        _.Display($"          NUMERO DO RCAP............... {RCAPS.DCLRCAPS.RCAPS_NUM_RCAP}");

                        /*" -6633- DISPLAY '          SQLCODE...................... ' SQLCODE */
                        _.Display($"          SQLCODE...................... {DB.SQLCODE}");

                        /*" -6634- GO TO 9999-ERRO */

                        M_9999_ERRO(); //GOTO
                        return;

                        /*" -6636- END-IF */
                    }


                    /*" -6637- IF SQLCODE EQUAL ZEROS */

                    if (DB.SQLCODE == 00)
                    {

                        /*" -6638- MOVE 1 TO W-RCAP-COMP */
                        _.Move(1, WS_WORK_AREAS.W_RCAP_COMP);

                        /*" -6640- END-IF */
                    }


                    /*" -6640- PERFORM R7774_00_LER_RCAP_COMP_DB_CLOSE_1 */

                    R7774_00_LER_RCAP_COMP_DB_CLOSE_1();

                    /*" -6643- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -6644- DISPLAY 'VP0121B - PROBLEMAS NO CLOSE DA RCAPCOMP' */
                        _.Display($"VP0121B - PROBLEMAS NO CLOSE DA RCAPCOMP");

                        /*" -6646- DISPLAY '          CODIGO DA FONTE.............. ' RCAPS-COD-FONTE OF DCLRCAPS */
                        _.Display($"          CODIGO DA FONTE.............. {RCAPS.DCLRCAPS.RCAPS_COD_FONTE}");

                        /*" -6648- DISPLAY '          NUMERO DO RCAP............... ' RCAPS-NUM-RCAP OF DCLRCAPS */
                        _.Display($"          NUMERO DO RCAP............... {RCAPS.DCLRCAPS.RCAPS_NUM_RCAP}");

                        /*" -6650- DISPLAY '          SQLCODE...................... ' SQLCODE */
                        _.Display($"          SQLCODE...................... {DB.SQLCODE}");

                        /*" -6650- GO TO 9999-ERRO. */

                        M_9999_ERRO(); //GOTO
                        return;
                    }

                }

            }


        }

        [StopWatch]
        /*" R7774-00-LER-RCAP-COMP-DB-SELECT-1 */
        public void R7774_00_LER_RCAP_COMP_DB_SELECT_1()
        {
            /*" -6571- EXEC SQL SELECT BCO_AVISO, AGE_AVISO, NUM_AVISO_CREDITO, DATA_MOVIMENTO, DATA_RCAP INTO :DCLRCAP-COMPLEMENTAR.RCAPCOMP-BCO-AVISO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-AGE-AVISO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-NUM-AVISO-CREDITO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-DATA-MOVIMENTO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-DATA-RCAP FROM SEGUROS.RCAP_COMPLEMENTAR WHERE COD_FONTE = :DCLRCAPS.RCAPS-COD-FONTE AND NUM_RCAP = :DCLRCAPS.RCAPS-NUM-RCAP AND NUM_RCAP_COMPLEMEN = 0 AND COD_OPERACAO BETWEEN 100 AND 199 WITH UR END-EXEC. */

            var r7774_00_LER_RCAP_COMP_DB_SELECT_1_Query1 = new R7774_00_LER_RCAP_COMP_DB_SELECT_1_Query1()
            {
                RCAPS_COD_FONTE = RCAPS.DCLRCAPS.RCAPS_COD_FONTE.ToString(),
                RCAPS_NUM_RCAP = RCAPS.DCLRCAPS.RCAPS_NUM_RCAP.ToString(),
            };

            var executed_1 = R7774_00_LER_RCAP_COMP_DB_SELECT_1_Query1.Execute(r7774_00_LER_RCAP_COMP_DB_SELECT_1_Query1);
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
        /*" R7774-00-LER-RCAP-COMP-DB-OPEN-1 */
        public void R7774_00_LER_RCAP_COMP_DB_OPEN_1()
        {
            /*" -6599- EXEC SQL OPEN C01_RCAPCOMP END-EXEC */

            C01_RCAPCOMP.Open();

        }

        [StopWatch]
        /*" R7774-00-LER-RCAP-COMP-DB-FETCH-1 */
        public void R7774_00_LER_RCAP_COMP_DB_FETCH_1()
        {
            /*" -6623- EXEC SQL FETCH C01_RCAPCOMP INTO :DCLRCAP-COMPLEMENTAR.RCAPCOMP-BCO-AVISO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-AGE-AVISO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-NUM-AVISO-CREDITO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-DATA-MOVIMENTO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-DATA-RCAP, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-COD-OPERACAO END-EXEC */

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
        /*" R7774-00-LER-RCAP-COMP-DB-CLOSE-1 */
        public void R7774_00_LER_RCAP_COMP_DB_CLOSE_1()
        {
            /*" -6640- EXEC SQL CLOSE C01_RCAPCOMP END-EXEC */

            C01_RCAPCOMP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7774_FIM*/

        [StopWatch]
        /*" R7775-00-UPD-PROP-SIVPF-SIVPF */
        private void R7775_00_UPD_PROP_SIVPF_SIVPF(bool isPerform = false)
        {
            /*" -6661- MOVE 'R7775-00-UPD-PRO' TO COMANDO. */
            _.Move("R7775-00-UPD-PRO", WABEND.COMANDO);

            /*" -6662- IF PROPVA-SITUACAO = '3' */

            if (PROPVA_SITUACAO == "3")
            {

                /*" -6663- MOVE 'EMT' TO WHOST-SIT-PROP-FIDELIZ */
                _.Move("EMT", WHOST_SIT_PROP_FIDELIZ);

                /*" -6665- ELSE */
            }
            else
            {


                /*" -6667- MOVE 'PEN' TO WHOST-SIT-PROP-FIDELIZ. */
                _.Move("PEN", WHOST_SIT_PROP_FIDELIZ);
            }


            /*" -6669- IF PROPOSTA-CACB OR PROPOSTA-COPESP */

            if (WS_WORK_AREAS.FILLER_1.W_CANAL_PROPOSTA1["PROPOSTA_CACB"] || WS_WORK_AREAS.FILLER_1.W_CANAL_PROPOSTA1["PROPOSTA_COPESP"])
            {

                /*" -6670- MOVE 'N' TO WHOST-SITUACAO-ENVIO */
                _.Move("N", WHOST_SITUACAO_ENVIO);

                /*" -6671- ELSE */
            }
            else
            {


                /*" -6672- MOVE 'S' TO WHOST-SITUACAO-ENVIO */
                _.Move("S", WHOST_SITUACAO_ENVIO);

                /*" -6674- END-IF. */
            }


            /*" -6676- MOVE 'UPDATE PROPOSTA-FIDELIZ' TO COMANDO. */
            _.Move("UPDATE PROPOSTA-FIDELIZ", WABEND.COMANDO);

            /*" -6687- PERFORM R7775_00_UPD_PROP_SIVPF_SIVPF_DB_UPDATE_1 */

            R7775_00_UPD_PROP_SIVPF_SIVPF_DB_UPDATE_1();

            /*" -6690- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -6691- DISPLAY 'ERRO UPDATE PROPOSTA_FIDELIZ' */
                _.Display($"ERRO UPDATE PROPOSTA_FIDELIZ");

                /*" -6692- DISPLAY 'PROPOSTA SIVPF = ' SIVPF-NR-PROPOSTA */
                _.Display($"PROPOSTA SIVPF = {SIVPF_NR_PROPOSTA}");

                /*" -6699- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -6718- IF SIVPF-NR-PROPOSTA EQUAL 27708000280671 OR 27708000338211 OR 27708000355558 OR 27708000359022 OR 27708000361566 OR 27708000291177 OR 27708000576104 OR 27708000605295 OR 27708000639416 OR 27708000460114 OR 27708000477149 OR 27708000490536 OR 27708000567172 OR 27708000483785 OR 27708000523191 OR 27708000541815 OR 27708000579359 OR 27708000595680 OR 27708000615924 */

            if (SIVPF_NR_PROPOSTA.In("27708000280671", "27708000338211", "27708000355558", "27708000359022", "27708000361566", "27708000291177", "27708000576104", "27708000605295", "27708000639416", "27708000460114", "27708000477149", "27708000490536", "27708000567172", "27708000483785", "27708000523191", "27708000541815", "27708000579359", "27708000595680", "27708000615924"))
            {

                /*" -6718- PERFORM R7776-00-ATUALIZA-NUM-SICOB. */

                R7776_00_ATUALIZA_NUM_SICOB(true);
            }


        }

        [StopWatch]
        /*" R7775-00-UPD-PROP-SIVPF-SIVPF-DB-UPDATE-1 */
        public void R7775_00_UPD_PROP_SIVPF_SIVPF_DB_UPDATE_1()
        {
            /*" -6687- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET SIT_PROPOSTA = :WHOST-SIT-PROP-FIDELIZ, SITUACAO_ENVIO = :WHOST-SITUACAO-ENVIO, DTQITBCO = :SIVPF-DTQITBCO, VAL_PAGO = :SIVPF-VAL-PAGO, DATA_CREDITO = :SIVPF-DATA-CREDITO, OPCAO_COBER = :SIVPF-OPCAO-COBER, COD_USUARIO = 'VP0121B' , TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_PROPOSTA_SIVPF = :SIVPF-NR-PROPOSTA END-EXEC. */

            var r7775_00_UPD_PROP_SIVPF_SIVPF_DB_UPDATE_1_Update1 = new R7775_00_UPD_PROP_SIVPF_SIVPF_DB_UPDATE_1_Update1()
            {
                WHOST_SIT_PROP_FIDELIZ = WHOST_SIT_PROP_FIDELIZ.ToString(),
                WHOST_SITUACAO_ENVIO = WHOST_SITUACAO_ENVIO.ToString(),
                SIVPF_DATA_CREDITO = SIVPF_DATA_CREDITO.ToString(),
                SIVPF_OPCAO_COBER = SIVPF_OPCAO_COBER.ToString(),
                SIVPF_DTQITBCO = SIVPF_DTQITBCO.ToString(),
                SIVPF_VAL_PAGO = SIVPF_VAL_PAGO.ToString(),
                SIVPF_NR_PROPOSTA = SIVPF_NR_PROPOSTA.ToString(),
            };

            R7775_00_UPD_PROP_SIVPF_SIVPF_DB_UPDATE_1_Update1.Execute(r7775_00_UPD_PROP_SIVPF_SIVPF_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7775_FIM*/

        [StopWatch]
        /*" R7776-00-ATUALIZA-NUM-SICOB */
        private void R7776_00_ATUALIZA_NUM_SICOB(bool isPerform = false)
        {
            /*" -6731- MOVE 'R7776-00-ATUALIZA-NUM-SICOB' TO PARAGRAFO */
            _.Move("R7776-00-ATUALIZA-NUM-SICOB", WABEND.PARAGRAFO);

            /*" -6732- DISPLAY PARAGRAFO */
            _.Display(WABEND.PARAGRAFO);

            /*" -6733- DISPLAY 'NUM_SICOB          = ' CONVER-NUM-SICOB */
            _.Display($"NUM_SICOB          = {CONVER_NUM_SICOB}");

            /*" -6734- DISPLAY 'NUM_PROPOSTA_SIVPF = ' SIVPF-NR-PROPOSTA */
            _.Display($"NUM_PROPOSTA_SIVPF = {SIVPF_NR_PROPOSTA}");

            /*" -6736- DISPLAY '****************************************' */
            _.Display($"****************************************");

            /*" -6740- PERFORM R7776_00_ATUALIZA_NUM_SICOB_DB_UPDATE_1 */

            R7776_00_ATUALIZA_NUM_SICOB_DB_UPDATE_1();

            /*" -6743- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -6744- DISPLAY 'R7776-00-ATUALIZA-NUM-SICOB' */
                _.Display($"R7776-00-ATUALIZA-NUM-SICOB");

                /*" -6745- DISPLAY 'PROPOSTA SIVPF = ' SIVPF-NR-PROPOSTA */
                _.Display($"PROPOSTA SIVPF = {SIVPF_NR_PROPOSTA}");

                /*" -6746- DISPLAY 'NUM SICOB      = ' CONVER-NUM-SICOB */
                _.Display($"NUM SICOB      = {CONVER_NUM_SICOB}");

                /*" -6747- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R7776-00-ATUALIZA-NUM-SICOB-DB-UPDATE-1 */
        public void R7776_00_ATUALIZA_NUM_SICOB_DB_UPDATE_1()
        {
            /*" -6740- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET NUM_SICOB = :CONVER-NUM-SICOB WHERE NUM_PROPOSTA_SIVPF = :SIVPF-NR-PROPOSTA END-EXEC. */

            var r7776_00_ATUALIZA_NUM_SICOB_DB_UPDATE_1_Update1 = new R7776_00_ATUALIZA_NUM_SICOB_DB_UPDATE_1_Update1()
            {
                CONVER_NUM_SICOB = CONVER_NUM_SICOB.ToString(),
                SIVPF_NR_PROPOSTA = SIVPF_NR_PROPOSTA.ToString(),
            };

            R7776_00_ATUALIZA_NUM_SICOB_DB_UPDATE_1_Update1.Execute(r7776_00_ATUALIZA_NUM_SICOB_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7776_FIM*/

        [StopWatch]
        /*" M-8880-ACERTA-DIF-PREMIO */
        private void M_8880_ACERTA_DIF_PREMIO(bool isPerform = false)
        {
            /*" -6753- IF PROPVA-CODPRODU = 7732 OR JVPRD7732 OR 7733 OR JVPRD7733 */

            if (PROPVA_CODPRODU.In("7732", JVBKINCL.JV_PRODUTOS.JVPRD7732.ToString(), "7733", JVBKINCL.JV_PRODUTOS.JVPRD7733.ToString()))
            {

                /*" -6754- GO TO 8880-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8880_FIM*/ //GOTO
                return;

                /*" -6756- END-IF */
            }


            /*" -6759- MOVE '8880-ACERTA-DIF ' TO COMANDO. */
            _.Move("8880-ACERTA-DIF ", WABEND.COMANDO);

            /*" -6761- MOVE '8880-ACERTA-DIF-PREMIO' TO PARAGRAFO. */
            _.Move("8880-ACERTA-DIF-PREMIO", WABEND.PARAGRAFO);

            /*" -6764- IF COBERP-VLPREMIO EQUAL ZEROS AND (PROPVA-CODPRODU = 7705 OR JVPRD7705 OR 7707 OR 7708 OR 7715) */

            if (COBERP_VLPREMIO == 00 && (PROPVA_CODPRODU.In("7705", JVBKINCL.JV_PRODUTOS.JVPRD7705.ToString(), "7707", "7708", "7715")))
            {

                /*" -6765- CONTINUE */

                /*" -6766- ELSE */
            }
            else
            {


                /*" -6767- COMPUTE WS-TAXA-VG = COBERP-PRMVG / COBERP-VLPREMIO */
                WS_WORK_AREAS.WS_TAXA_VG.Value = COBERP_PRMVG / COBERP_VLPREMIO;

                /*" -6768- COMPUTE WS-TAXA-AP = COBERP-PRMAP / COBERP-VLPREMIO */
                WS_WORK_AREAS.WS_TAXA_AP.Value = COBERP_PRMAP / COBERP_VLPREMIO;

                /*" -6770- END-IF */
            }


            /*" -6771- IF COBERP-VLPREMIO > V0HCOB-VLPRMTOT */

            if (COBERP_VLPREMIO > V0HCOB_VLPRMTOT)
            {

                /*" -6772- MOVE 401 TO DIFPAR-CODOPER */
                _.Move(401, DIFPAR_CODOPER);

                /*" -6773- ELSE */
            }
            else
            {


                /*" -6774- MOVE 601 TO DIFPAR-CODOPER */
                _.Move(601, DIFPAR_CODOPER);

                /*" -6776- END-IF */
            }


            /*" -6778- IF NOT NOVO-CALCULO-PREMIO */

            if (!WS_WORK_AREAS.W_NOVO_CALCULO["NOVO_CALCULO_PREMIO"])
            {

                /*" -6780- COMPUTE COBERP-PRMVG = V0HCOB-VLPRMTOT * WS-TAXA-VG */
                COBERP_PRMVG.Value = V0HCOB_VLPRMTOT * WS_WORK_AREAS.WS_TAXA_VG;

                /*" -6782- COMPUTE COBERP-PRMAP = V0HCOB-VLPRMTOT - COBERP-PRMVG */
                COBERP_PRMAP.Value = V0HCOB_VLPRMTOT - COBERP_PRMVG;

                /*" -6784- END-IF. */
            }


            /*" -6785- IF DIFPAR-CODOPER = 401 */

            if (DIFPAR_CODOPER == 401)
            {

                /*" -6786- COMPUTE DIFPAR-PRMVG = COBERP-VLPREMIO - V0HCOB-VLPRMTOT */
                DIFPAR_PRMVG.Value = COBERP_VLPREMIO - V0HCOB_VLPRMTOT;

                /*" -6788- END-IF */
            }


            /*" -6789- IF DIFPAR-CODOPER = 601 */

            if (DIFPAR_CODOPER == 601)
            {

                /*" -6790- COMPUTE DIFPAR-PRMVG = V0HCOB-VLPRMTOT - COBERP-VLPREMIO */
                DIFPAR_PRMVG.Value = V0HCOB_VLPRMTOT - COBERP_VLPREMIO;

                /*" -6792- END-IF */
            }


            /*" -6795- MOVE 'UPDATE V0PARCELVA' TO COMANDO */
            _.Move("UPDATE V0PARCELVA", WABEND.COMANDO);

            /*" -6802- PERFORM M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_1 */

            M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_1();

            /*" -6805- IF SQLCODE NOT = 000 AND +100 */

            if (!DB.SQLCODE.In("000", "+100"))
            {

                /*" -6809- DISPLAY 'VP0121B-8880 PROBLEMAS UPDATE V0PARCELVA' ' PRMVG=' COBERP-PRMVG ' PRMAP=' COBERP-PRMAP ' NRCERTIF=' PROPVA-NRCERTIF */

                $"VP0121B-8880 PROBLEMAS UPDATE V0PARCELVA PRMVG={COBERP_PRMVG} PRMAP={COBERP_PRMAP} NRCERTIF={PROPVA_NRCERTIF}"
                .Display();

                /*" -6810- GO TO 9999-ERRO */

                M_9999_ERRO(); //GOTO
                return;

                /*" -6812- END-IF */
            }


            /*" -6814- IF SQLCODE = +100 AND PROPVA-NUM-APOLICE EQUAL 109300000635 */

            if (DB.SQLCODE == +100 && PROPVA_NUM_APOLICE == 109300000635)
            {

                /*" -6815- GO TO 8880-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8880_FIM*/ //GOTO
                return;

                /*" -6817- END-IF */
            }


            /*" -6820- MOVE 'INSERT V0DIFPARCELVA' TO COMANDO. */
            _.Move("INSERT V0DIFPARCELVA", WABEND.COMANDO);

            /*" -6835- PERFORM M_8880_ACERTA_DIF_PREMIO_DB_INSERT_1 */

            M_8880_ACERTA_DIF_PREMIO_DB_INSERT_1();

            /*" -6839- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL -803 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
            {

                /*" -6841- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -6844- MOVE 'UPDATE V0HISTCONTABILVA' TO COMANDO. */
            _.Move("UPDATE V0HISTCONTABILVA", WABEND.COMANDO);

            /*" -6852- PERFORM M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_2 */

            M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_2();

            /*" -6856- IF SQLCODE NOT = ZEROS AND SQLCODE NOT = 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -6857- DISPLAY 'ERRO UPDATE V0HISTCONTABILVA' */
                _.Display($"ERRO UPDATE V0HISTCONTABILVA");

                /*" -6858- DISPLAY 'NRCERTIF  = ' PROPVA-NRCERTIF */
                _.Display($"NRCERTIF  = {PROPVA_NRCERTIF}");

                /*" -6858- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-8880-ACERTA-DIF-PREMIO-DB-UPDATE-1 */
        public void M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_1()
        {
            /*" -6802- EXEC SQL UPDATE SEGUROS.V0PARCELVA SET PRMVG = :COBERP-PRMVG, PRMAP = :COBERP-PRMAP, TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :PROPVA-NRCERTIF AND NRPARCEL = 1 END-EXEC */

            var m_8880_ACERTA_DIF_PREMIO_DB_UPDATE_1_Update1 = new M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_1_Update1()
            {
                COBERP_PRMVG = COBERP_PRMVG.ToString(),
                COBERP_PRMAP = COBERP_PRMAP.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_1_Update1.Execute(m_8880_ACERTA_DIF_PREMIO_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-8880-ACERTA-DIF-PREMIO-DB-INSERT-1 */
        public void M_8880_ACERTA_DIF_PREMIO_DB_INSERT_1()
        {
            /*" -6835- EXEC SQL INSERT INTO SEGUROS.V0DIFPARCELVA VALUES (:PROPVA-NRCERTIF, 9999, 1, :DIFPAR-CODOPER, :PROPVA-DTQITBCO, :COBERP-VLPREMIO, 0, :V0HCOB-VLPRMTOT, 0, :DIFPAR-PRMVG, 0, 0, ' ' ) END-EXEC. */

            var m_8880_ACERTA_DIF_PREMIO_DB_INSERT_1_Insert1 = new M_8880_ACERTA_DIF_PREMIO_DB_INSERT_1_Insert1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                DIFPAR_CODOPER = DIFPAR_CODOPER.ToString(),
                PROPVA_DTQITBCO = PROPVA_DTQITBCO.ToString(),
                COBERP_VLPREMIO = COBERP_VLPREMIO.ToString(),
                V0HCOB_VLPRMTOT = V0HCOB_VLPRMTOT.ToString(),
                DIFPAR_PRMVG = DIFPAR_PRMVG.ToString(),
            };

            M_8880_ACERTA_DIF_PREMIO_DB_INSERT_1_Insert1.Execute(m_8880_ACERTA_DIF_PREMIO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8880_FIM*/

        [StopWatch]
        /*" M-8880-ACERTA-DIF-PREMIO-DB-UPDATE-2 */
        public void M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_2()
        {
            /*" -6852- EXEC SQL UPDATE SEGUROS.V0HISTCONTABILVA SET PRMVG = :COBERP-PRMVG, PRMAP = :COBERP-PRMAP, TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :PROPVA-NRCERTIF AND NRPARCEL = 1 AND SITUACAO = '0' END-EXEC. */

            var m_8880_ACERTA_DIF_PREMIO_DB_UPDATE_2_Update1 = new M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_2_Update1()
            {
                COBERP_PRMVG = COBERP_PRMVG.ToString(),
                COBERP_PRMAP = COBERP_PRMAP.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            M_8880_ACERTA_DIF_PREMIO_DB_UPDATE_2_Update1.Execute(m_8880_ACERTA_DIF_PREMIO_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" M-9000-FINALIZA */
        private void M_9000_FINALIZA(bool isPerform = false)
        {
            /*" -6870- MOVE '9000-FINALIZA' TO PARAGRAFO. */
            _.Move("9000-FINALIZA", WABEND.PARAGRAFO);

            /*" -6870- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -6874- DISPLAY ' ' . */
            _.Display($" ");

            /*" -6875- DISPLAY '*** VP0121B *** TERMINO NORMAL' . */
            _.Display($"*** VP0121B *** TERMINO NORMAL");

            /*" -6876- DISPLAY ' ' . */
            _.Display($" ");

            /*" -6877- DISPLAY 'LIDOS ..................... ' AC-LIDOS. */
            _.Display($"LIDOS ..................... {WS_WORK_AREAS.AC_LIDOS}");

            /*" -6878- DISPLAY 'INCLUSOES ................. ' AC-INCLUSOES. */
            _.Display($"INCLUSOES ................. {WS_WORK_AREAS.AC_INCLUSOES}");

            /*" -6879- DISPLAY 'DESPREZADOS ............... ' AC-DESPREZADOS. */
            _.Display($"DESPREZADOS ............... {WS_WORK_AREAS.AC_DESPREZADOS}");

            /*" -6880- DISPLAY 'MOV. EMISSAO FOLHETOS...... ' AC-FOLHETOS. */
            _.Display($"MOV. EMISSAO FOLHETOS...... {WS_WORK_AREAS.AC_FOLHETOS}");

            /*" -6880- DISPLAY 'PROPOSTAS SIVPF EMITIDAS... ' UPDATE-SIVPF-SIVPF. */
            _.Display($"PROPOSTAS SIVPF EMITIDAS... {WS_WORK_AREAS.UPDATE_SIVPF_SIVPF}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9000_FIM*/

        [StopWatch]
        /*" M-9999-ERRO */
        private void M_9999_ERRO(bool isPerform = false)
        {
            /*" -6891- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -6892- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], WABEND.WSQLERRD1);

            /*" -6893- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], WABEND.WSQLERRD2);

            /*" -6894- MOVE SQLCODE TO WSQLCODE3. */
            _.Move(DB.SQLCODE, WS_WORK_AREAS.WSQLCODE3);

            /*" -6896- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -6898- DISPLAY '*** VP0121B *** ROLLBACK EM ANDAMENTO ...' . */
            _.Display($"*** VP0121B *** ROLLBACK EM ANDAMENTO ...");

            /*" -6898- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -6901- MOVE '9999-ERRO' TO PARAGRAFO. */
            _.Move("9999-ERRO", WABEND.PARAGRAFO);

            /*" -6902- MOVE 'ROLLBACK WORK' TO COMANDO. */
            _.Move("ROLLBACK WORK", WABEND.COMANDO);

            /*" -6902- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -6905- DISPLAY ' ' . */
            _.Display($" ");

            /*" -6906- DISPLAY 'LIDOS ................ ' AC-LIDOS. */
            _.Display($"LIDOS ................ {WS_WORK_AREAS.AC_LIDOS}");

            /*" -6907- DISPLAY ' ' . */
            _.Display($" ");

            /*" -6908- DISPLAY 'INCLUSOES ............ ' AC-INCLUSOES. */
            _.Display($"INCLUSOES ............ {WS_WORK_AREAS.AC_INCLUSOES}");

            /*" -6909- DISPLAY ' ' . */
            _.Display($" ");

            /*" -6910- DISPLAY 'DESPREZADOS .......... ' AC-DESPREZADOS. */
            _.Display($"DESPREZADOS .......... {WS_WORK_AREAS.AC_DESPREZADOS}");

            /*" -6912- DISPLAY ' ' */
            _.Display($" ");

            /*" -6913- DISPLAY 'CERTIFICADO... ' PROPVA-NRCERTIF. */
            _.Display($"CERTIFICADO... {PROPVA_NRCERTIF}");

            /*" -6914- DISPLAY 'APOLICE....... ' PROPVA-NUM-APOLICE */
            _.Display($"APOLICE....... {PROPVA_NUM_APOLICE}");

            /*" -6915- DISPLAY 'SUBGRUPO...... ' PROPVA-CODSUBES */
            _.Display($"SUBGRUPO...... {PROPVA_CODSUBES}");

            /*" -6916- DISPLAY 'PROPAUTOM..... ' FONTE-PROPAUTOM. */
            _.Display($"PROPAUTOM..... {FONTE_PROPAUTOM}");

            /*" -6917- DISPLAY 'FONTE......... ' PROPVA-FONTE. */
            _.Display($"FONTE......... {PROPVA_FONTE}");

            /*" -6918- DISPLAY 'TITULO........ ' BANCOS-NRTIT. */
            _.Display($"TITULO........ {BANCOS_NRTIT}");

            /*" -6920- DISPLAY '*** VP0121B *** ERRO DE EXECUCAO' . */
            _.Display($"*** VP0121B *** ERRO DE EXECUCAO");

            /*" -6921- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -6921- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}