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
using Sias.VidaAzul.DB2.VA0469B;

namespace Code
{
    public class VA0469B
    {
        public bool IsCall { get; set; }

        public VA0469B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-----------------------------------------*                             */
        /*"      ******************************************************************      */
        /*"      *                    OBJETIVO DO PROGRAMA                        *      */
        /*"      ******************************************************************      */
        /*"      *     CALCULAR A DEVOLUCAO DE PREMIOS PRO-RATA A PARTIR DA TABE- *      */
        /*"      *  LA RELATORIOS. AJUSTAR O PREMIO COM O INDICE CADASTRADO NA    *      */
        /*"      *  TABELA VG_INDICE.                                             *      */
        /*"      ******************************************************************      */
        /*"V.63  *   VERSAO 63  - DEMANDA RITM0002669 - PASSA A TRATAR A SITUACAO *      */
        /*"      *                IGUAL A 8 - CANCELADA NA HIST_LANC_CTA.         *      */
        /*"      *                                                                *      */
        /*"      *   EM 10/10/2024 - FELIPE LARA CARVALHO       PROCURE POR V.63  *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"V.62  *   VERSAO 62  - INCIDENTE OPTI-341 - CORRECAO DO ABEND 0C7      *      */
        /*"      *                GERADO POR NAO HAVER VALOR NA VARIAVEL TESTADA  *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/09/2024 - ROGER PIRES DOS SANTOS     PROCURE POR V.62  *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"V.61  *   VERSAO 61  - INCIDENTE 602039 - USUARIO ESTA CONSEGUINDO FAZER      */
        /*"      *                DEVOLUCAO DE CARTAO DE CREDITO UTILIZANDO CONTA *      */
        /*"      *                CORRENTE SEM A REJEICAO DA CIELO. REALIZEI A    *      */
        /*"      *                CORRECAO DA VLNRA PARA QUE ISSO NAO ACONTECA.   *      */
        /*"      *                                                                *      */
        /*"      *   EM 10/09/2024 - ELIERMES OLIVEIRA   PROCURE POR V.61         *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"V.60  *   VERSAO 60  - INCIDENTE 574638 - ALTERA NUM-COPIAS DE O PARA  *      */
        /*"      *                6 QUANDO OPCAO-PAG FOR CARTAO DE CREDITO, POIS  *      */
        /*"      *                SE TRATA DE DEVOLUCAO REALIZADA PELO SALESFORCE *      */
        /*"      *                                                                *      */
        /*"      *   EM 27/02/2024 - ELIERMES OLIVEIRA   PROCURE POR V.60         *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"V.59  *   VERSAO 59  - DEMANDA 568541 - REALIZACAO DE CORRECAO         *      */
        /*"      *                MONETARIA E JUROS PARA DEVOLUCAO DE DEMAIS      *      */
        /*"      *                PARCELAS.                                       *      */
        /*"      *                                                                *      */
        /*"      *   EM 07/02/2024 - FELIPE LARA         PROCURE POR V.59         *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"V.58  *  VERSAO 58  - DEMANDA 562286                                   *      */
        /*"      *             - PERMITIR RESSARCIMENTO RESIDUAL                  *      */
        /*"      *                                                                *      */
        /*"      *  EM 02/02/2024 - ROGER PIRES DOS SANTOS                        *      */
        /*"      *                                        PROCURE POR V.58        *      */
        /*"      ******************************************************************      */
        /*"V.57  *   VERSAO 57  - DEMANDA 496862 - CHARGEBACK NO CARTAO CIELO     *      */
        /*"      *              - CRIACAO DO NUM-COPIAS 6: ESTORNO DE PARCELA     *      */
        /*"      *                MANUAL NO SIAS, COM OPCAO-PAG EM CARTAO CREDITO,*      */
        /*"      *                GERANDO EVENTO 9022 NA MOVTO_DEBITOCC_CEF E SE  *      */
        /*"      *                FOR O CASO, DEVOLVE CORRECAO EM CONTA CORRENTE  *      */
        /*"      *                NO EVENTO 6090 OU 1313                          *      */
        /*"      *              - CRIACAO DO NUM-COPIAS 7:                               */
        /*"      *                1) RESTITUICAO DE CARTAO DE CREDITO EM CONTA OU *      */
        /*"      *                CARTAO, POR REJEICAO DO SAP/CIELO A RESTITUICAO *      */
        /*"      *                ENVIADA ANTERIOMENTE. (S9022 OU N9022).         *      */
        /*"      *                2) RESTITUICAO DE CORRECAO MONETARIA EM CONTA   *      */
        /*"      *                ORIUNDA DE RESTITUICAO CARTAO CREDITO NAO PAGA  *      */
        /*"      *                POR REJEICAO DO SAP OU FALTA DA CONTA DO CLIENTE*      */
        /*"      *                NO MOMENTO DA PRIMEIRA SOLICITACAO (R6090)      *      */
        /*"      *              - CRIACAO DO NUM-COPIAS 8: REALIZAR ESTORNO DE    *      */
        /*"      *                PARCELAS QUE RECEBEU COMANDO DE CHARGEBACK DA   *      */
        /*"      *                OPERADORA DO CARTAO DE CREDITO, GERANDO EVENTO  *      */
        /*"      *                9022 NA MOVTO_DEBITOCC_CEF, SEM CALCULO DE CORRE*      */
        /*"      *                CAO DO PREMIO A SER DEVOLVIDO                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 27/12/2023 - ELIERMES OLIVEIRA   PROCURE POR V.57         *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"V.56  *  VERSAO 56  - DEMANDA   470428                                 *      */
        /*"      *             - NAO PERMITE A INCLUSAO DE RESSARCIMENTO          *      */
        /*"      *               PARA PARCELAS JA EXISTENTES NA HIST_LANC_CTA     *      */
        /*"      *                                                                *      */
        /*"      *  EM 23/08/2023 - FELIPE LARA                                   *      */
        /*"      *                                        PROCURE POR V.56        *      */
        /*"      ******************************************************************      */
        /*"V.55  *  VERSAO 55  - INCIDENTE 513798                                 *      */
        /*"      *             - CORRECAO PARA GRAVACAO DE DADOS BANCARIOS NA     *      */
        /*"      *               MOVTO_DEBITOCC_CEF                               *      */
        /*"      *                                                                *      */
        /*"      *  EM 09/08/2023 - ELIERMES OLIVEIRA                             *      */
        /*"      *                                        PROCURE POR V.55        *      */
        /*"      ******************************************************************      */
        /*"V.54  *  VERSAO 54  - INCIDENTE 513798                                 *      */
        /*"      *             - CORRECAO PARA GRAVACAO DE DADOS BANCARIOS NA     *      */
        /*"      *               MOVTO_DEBITOCC_CEF                               *      */
        /*"      *                                                                *      */
        /*"      *  EM 13/07/2023 - ELIERMES OLIVEIRA                             *      */
        /*"      *                                        PROCURE POR V.54        *      */
        /*"      ******************************************************************      */
        /*"V.53  *  VERSAO 53  - DEMANDA   507.850                                *      */
        /*"      *             - AJUSTE UPDATE   SEGUROS.PARCELAS_VIDAZUL         *      */
        /*"      *                                                                *      */
        /*"      *  EM 28/06/2023 - FELIPE LARA                                   *      */
        /*"      *                                        PROCURE POR V.53        *      */
        /*"      ******************************************************************      */
        /*"V.52  *  VERSAO 52  - DEMANDA   507.850                                *      */
        /*"      *             - TRATA UPDATE DA SEGUROS.COBER_HIST_VIDAZUL       *      */
        /*"      *                                                                *      */
        /*"      *  EM 20/06/2023 - FELIPE LARA                                   *      */
        /*"      *                                        PROCURE POR V.52        *      */
        /*"      ******************************************************************      */
        /*"V.51  *  VERSAO 51  - DEMANDA   482.713                                       */
        /*"      *             - RETIRAR A ALTERA��O DE STATUS DE "CANCELADA" NA  *      */
        /*"      *               PARCELAS_VIDAZUL MANTENDO O STATUS DE "PAGA"     *      */
        /*"      *             - RETIRAR A ALTERA��O DE STATUS DE "DEVOLVIDA" NA  *      */
        /*"      *               COBER_HIST_VIDAZUL MANTENDO O STATUS DE "PAGA"   *      */
        /*"      *             - O STATUS DE AMBAS AS TABELAS SER� ALTERADA PARA  *      */
        /*"      *               "DEVOLVIDA" EM AMBAS AS TABELAS EM CASO DE       *      */
        /*"      *               SUCESSO NA DEVOLUCAO DOS PREMIOS.                *      */
        /*"      *                                                                *      */
        /*"      *  EM 12/05/2023 - FELIPE LARA                                   *      */
        /*"      *                                        PROCURE POR V.51        *      */
        /*"      ******************************************************************      */
        /*"V.50  *  VERSAO 50  - INCIDENTE 495.311                                *      */
        /*"      *             - CORRECAO DO ERRO -420 OCORRIDO EM PRODUCAO       *      */
        /*"      *                                                                *      */
        /*"      *  EM 10/05/2023 - ELIERMES OLIVEIRA                             *      */
        /*"      *                                        PROCURE POR V.50        *      */
        /*"      ******************************************************************      */
        /*"V.49  *  VERSAO 49  - DEMANDA 479.439                                  *      */
        /*"      *             - PEGAR O VALOR DO PREMIO DA PARCELAS_VIDAZUL E NAO*      */
        /*"      *               MAIS DA COBER_HIST_VIDAZUL, POIS O VALOR DA      *      */
        /*"      *               ULTIMA TABELA EH SOMADO A CORRECAO E EM CASO DE  *      */
        /*"      *               MAIS DE UMA DEVOLUCAO POR MOTIVO DE ERRO O SIAS  *      */
        /*"      *               ESTA SOMANDO CORRECAO SOBRE CORRECAO             *      */
        /*"      *                                                                *      */
        /*"      *  EM 05/05/2023 - ELIERMES OLIVEIRA                             *      */
        /*"      *                                        PROCURE POR V.49        *      */
        /*"      ******************************************************************      */
        /*"V.48  *  VERSAO 48  - DEMANDA 478.584                                  *      */
        /*"      *             - CORRECAO DO VALOR DO PREMIO NA COBER_HIST        *      */
        /*"      *               QUE ESTAVA FICANDO ZERADO NO RETORNO DA SPBVG011 *      */
        /*"      *                                                                *      */
        /*"      *  EM 12/04/2023 - TERCIO CARVALHO                               *      */
        /*"      *                                        PROCURE POR V.48        *      */
        /*"      ******************************************************************      */
        /*"V.47  *  VERSAO 47  - DEMANDA 478.584                                  *      */
        /*"      *             - ABEND -305 NA R1050.                             *      */
        /*"      *                                                                *      */
        /*"      *  EM 06/04/2023 - TERCIO CARVALHO                               *      */
        /*"      *                                        PROCURE POR V.47        *      */
        /*"      ******************************************************************      */
        /*"V.46  *  VERSAO 46  - DEMANDA 478.584                                  *      */
        /*"      *             - AJUSTE NA PASSAGEM DE PARAMETRO                  *      */
        /*"      *                                                                *      */
        /*"      *  EM 05/04/2023 - TERCIO CARVALHO                               *      */
        /*"      *                                        PROCURE POR V.46        *      */
        /*"      ******************************************************************      */
        /*"V.45  *  VERSAO 45  - DEMANDA 478.584                                  *      */
        /*"      *             - CALCULO DE JUROS PRORATA PARA AS PROPOSTAS       *      */
        /*"      *               DECLINADAS.                                      *      */
        /*"      *                                                                *      */
        /*"      *  EM 23/03/2023 - TERCIO CARVALHO                               *      */
        /*"      *                                        PROCURE POR V.45        *      */
        /*"      ******************************************************************      */
        /*"V.44  *  VERSAO 44  - DEMANDA 402.982                                  *      */
        /*"      *             - CORRIGIR CALCULO DE CORRECAO PARA QUE APENAS A   *      */
        /*"      *               AS DEVOLUCOES DE PRIMEIRA PARCELA SEJAM CORRIGIDA*      */
        /*"      *                                                                *      */
        /*"      *  EM 07/03/2023 - ELIERMES OLIVEIRA                             *      */
        /*"      *                                        PROCURE POR V.44        *      */
        /*"      ******************************************************************      */
        /*"V.43  *  VERSAO 43  - INCIDENTE 474413                                 *      */
        /*"      *             - CORRIGIR COD_CONVENINO DE 6090 PARA 609000       *      */
        /*"      *                                                                *      */
        /*"      *  EM 06/03/2023 - ELIERMES OLIVEIRA                             *      */
        /*"      *                                        PROCURE POR V.43        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.42  *  VERSAO 42  - DEMANDA 402.982                                  *      */
        /*"      *             - REALIZAR EXCLUSAO LOGICA DAS CRITICAS PENDENTES  *      */
        /*"      *               CADASTRADAS PARA DECLINIO DA PROPOSTA            *      */
        /*"      *                                                                *      */
        /*"      *  EM 17/02/2023 - ELIERMES OLIVEIRA                             *      */
        /*"      *                                        PROCURE POR V.42        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.41  *  VERSAO 41  - DEMANDA 455.132                                  *      */
        /*"      *             - CHAMA SUBROTINA SPBVG011 PARA REALIZAR CALCULO DE*      */
        /*"      *               ATUALIZACAO MONETARIA AO VALOR DEVOLVIDO DO      *      */
        /*"      *               PREMIO (PRO-RATA) ENTRE A DATA DE RECEBIMENTO E A*      */
        /*"      *               DATA DO DIA DE PROCESSAMENTO, GRAVANDO OS VALORES*      */
        /*"      *               GERADOS NA TABELA MOVTO_DEBITOCC_CEF             *      */
        /*"      *                                                                *      */
        /*"      *  EM 19/01/2023 - ELIERMES OLIVEIRA                             *      */
        /*"      *                                        PROCURE POR V.41        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 40  - DEMANDA 251270 / 2019230 (FABRICA)              *      */
        /*"      *              - ESTORNO AUTOMATICO DE CARTAO DE CREDITO         *      */
        /*"      *                                                                *      */
        /*"      *   EM 01/11/2019 - TERCIO CARVALHO / FRANK CARVALHO / CLAUDETE  *      */
        /*"      *                                       PROCURE POR V.40         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 39 - ABEND 182731                                     *      */
        /*"      *             - RETIRAR O BANCO 332 CADASTRADO PELA CENTRAL ATE  *      */
        /*"      *               QUE ELES DEFINAM QUAL E O BANCO CORRETO.         *      */
        /*"      *                                                                *      */
        /*"      *   EM 28/05/2020 - CLAUDETE RADEL                               *      */
        /*"      *                                           PROCURE POR V.39     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 38 - JAZZ 999999  -                                   *      */
        /*"      *               - AUMENTO DE OCORRENCIAS NA TABELA INTERNA       *      */
        /*"      *                 IGPM.                                          *      */
        /*"      *                                                                *      */
        /*"      *   EM 03/01/2020 - CANETTA                                      *      */
        /*"      *                                           PROCURE POR V.38     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 37  -  DEMANDA 214252.                                *      */
        /*"      *              -  MUDAR A DATA DE VENCIMENTO PARA D+2 E NAO D+5. *      */
        /*"      *              -  NAO USAR A CURRENT DATE, POIS O PROCESSAMENTO  *      */
        /*"      *                 ESTA OCORRENDO DE MADRUGADA, POR ISSO, A DATA  *      */
        /*"      *                 E UM DIA A MAIS QUE A DATA DE MOVIMENTO.       *      */
        /*"      *                                                                *      */
        /*"      *   EM 01/11/2019 - CLAUDETE                                     *      */
        /*"      *                                       PROCURE POR V.37         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 36  -  DEVOLUCAO DE PREMIO SEM BAIXA DO RCAP.         *      */
        /*"      *              -  BAIXA RCAP PENDENTE QUANDO FOR O CASO.         *      */
        /*"      *                                                                *      */
        /*"      *   EM 09/01/2019 - CLOVIS                                       *      */
        /*"      *                                       PROCURE POR V.36         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 35  -  ABEND 142.577                                  *      */
        /*"      *              -  DEVIDO A DADOS INCORRETOS NA BASE FOI REALIZADO*      */
        /*"      *                 UMA NOVA CONSULTA PARA VERIFICAR SE HOUVE      *      */
        /*"      *                 CANCELAMENTO E APOS UMA REABILITACAO.          *      */
        /*"      *                                                                *      */
        /*"      *   EM 28/09/2016 - FRANK CARVALHO                               *      */
        /*"      *                                       PROCURE POR V.35         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 34  -  ABEND 142.273                                  *      */
        /*"      *              -  VERIFICAR SE APOS O CANCELAMENTO DO SEGURO     *      */
        /*"      *                 HOUVE ALGUMA REABILITACAO. PARA EVITAR O ABEND *      */
        /*"      *                 DE MAIS DE UMA SOLITACAO DE CANCELAMENTO.      *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/09/2016 - FRANK CARVALHO                               *      */
        /*"      *                                       PROCURE POR V.34         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 33  -  CADMUS 140.583                                        */
        /*"      *              -  MANTER O CODIGO DE DEVOLUCAO PREENCHIDO COM O  *      */
        /*"      *                 MOTIVO DO CANCELAMENTO DO SEGURO QUANDO E REA- *      */
        /*"      *                 LIZADO UMA RESTITUICAO APOS O CANCELAMENTO.    *      */
        /*"      *                                                                *      */
        /*"      *   EM 13/09/2016 - FRANK CARVALHO                               *      */
        /*"      *                                       PROCURE POR V.33         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 032                                                  *      */
        /*"      * MOTIVO  : NAO ENVIAR CARTA DE RECUSA PARA O CLIENTE, QUANDO FOR*      */
        /*"      *           PRODUTOS DA DISEF                      *                    */
        /*"      * CADMUS  : 135627                                               *      */
        /*"      * DATA    : 02/06/2016                                           *      */
        /*"      * NOME    : DIOGO MATHEUS                                        *      */
        /*"      * MARCADOR: V.32                                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 31  -  CORRECAO ATUALIZ IGPM                          *      */
        /*"      *              -  RE-ESTRUTURACAO                                       */
        /*"      *                                                                *      */
        /*"      *   EM 02/01/2016 - MIRIAM I. HECK                               *      */
        /*"      *                                       PROCURE POR V.31         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 30  -  RETORNO PARA VERSAO V.27                       *      */
        /*"      *                                                                *      */
        /*"      *   EM 16/12/2015 - MIRIAM I. HECK                               *      */
        /*"      *                                       PROCURE POR V.30         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 29  -  ABEND  124813.                                 *      */
        /*"      *                 TRATAR ABEND -811                              *      */
        /*"      *                 RAGRAFO = R2610-00-SELECT-HIST_CONT_PARC              */
        /*"      *   EM 30/10/2015 - THIAGO BLAIER                                *      */
        /*"      *                                       PROCURE POR V.29         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 28  -  CADMUS 103960.                                 *      */
        /*"      *                 CALCULAR PRO-RATA SOMENTE PARA OS SEGUROS      *      */
        /*"      *                 ANUAIS.                                        *      */
        /*"      *   EM 18/09/2015 - ROGERIO LAMAS                                *      */
        /*"      *                                       PROCURE POR V.28         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 27  -  CADMUS 122623                                  *      */
        /*"      *                 DATA DE DECLINIO N�O PODE SER ALTERADA.        *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/09/2015 - ROGERIO LAMAS                                *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.27         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 26  -  NSGD - CADMUS 103659.                          *      */
        /*"      *              -  NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 06/03/2015 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.26         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 25 - CAD 105.276                                      *      */
        /*"      *                                                                *      */
        /*"      *             - GUARDAR DATA DE DECLINIO NA PROPOSTAS_VA         *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/12/2014 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.25         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 24     -   CAD 87.342   -                             *      */
        /*"      *                                                                *      */
        /*"      *                 - TRATAR SQLCODE -811 PARA A TABELA            *      */
        /*"      *   COBER_HIST_VIDAZUL, POIS NO RESSARCIMENTO PARA PARCELAS QUE  *      */
        /*"      *   FORAM GERADOS COBRANCAS EM ATRASO, HAVER� MAIS DE UM REGISTRO*      */
        /*"      *   NESTA TABELA PARA O NUMERO DA PARCELA INFORMADA.             *      */
        /*"      *                                                                *      */
        /*"      *   EM 14/11/2013 - FRANK CARVALHO (INDRA COMPANY)               *      */
        /*"      *                                           PROCURE POR V.24     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.23  *  VERSAO...: V.23                                               *      */
        /*"      *  CADMUS...: 68048           PROGRAMADOR: CLOVIS                *      */
        /*"      *  DATA ....: 28/11/2012                                         *      */
        /*"      *  DESCRICAO: LIBERA DEVOLU��O PARA TODAS OP��ES DE PAGTO.       *      */
        /*"      *             OBEDECE A SOLICITA��O EFETUADA PELO PGM ON-LINE    *      */
        /*"      *             VLN8A.                                             *      */
        /*"      *                                                                *      */
        /*"      *  NUM-COPIAS = 0 --> DEVOLUCAO PRO-RATA                         *      */
        /*"      *  NUM-COPIAS = 1 --> DEVOLUCAO POR CHEQUE                       *      */
        /*"      *  NUM-COPIAS = 2 --> DEVOLUCAO CREDITO EM CONTA CEF (104)       *      */
        /*"      *  NUM-COPIAS = 3 --> DEVOLUCAO CREDITO EM CONTA OUTROS BANCOS   *      */
        /*"      *  NUM-COPIAS = 4 --> SEM VALOR A DEVOLVER                       *      */
        /*"V.40  *  NUM-COPIAS = 5 --> ESTORNO AUTOMATICO DE CARTAO DE CREDITO    *      */
        /*"V.57  *  NUM-COPIAS = 6 --> RESTITUICAO/ESTORNO MANUAL CARTAO CREDITO  *      */
        /*"V.57  *                     COM OU SEM CORRECAO MONETARIA              *      */
        /*"V.57  *                     (DEVOLVE CORRECAO EM CONTA CORRENTE)       *      */
        /*"V.57  *  NUM-COPIAS = 7 --> RESTITUICAO DE CORRECAO MONETARIA EM CONTA *      */
        /*"V.57  *                     CORRETE ORIUNDA DE RESTITUICAO/ESTORNO EM  *      */
        /*"V.57  *                     CARTAO DE CREDITO NAO PAGA POR FALTA DE    *      */
        /*"V.57  *                     CADASTRAMENTO DE CONTA OU REJEICAO DO SAP  *      */
        /*"V.57  *  NUM-COPIAS = 8 --> RESTITUICAO DE PARCELA EM CARTAO CREDITO   *      */
        /*"V.57  *                     DEVIDO A COMANDO DE CHARGEBACK ENVIADO PELA*      */
        /*"V.57  *                     OPERADORA                                  *      */
        /*"      *                                                                *      */
        /*"      *  NUM-ORDEM = RECEBE O VALOR A DEVOLVER                         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 22 - CAD 65.190   -                                   *      */
        /*"      *               - TRATAR O ABEND                                 *      */
        /*"      *                                                                *      */
        /*"      *   EM 29/12/2011 - ALESSANDRO G. RAMOS (FAST COMPUTER)          *      */
        /*"      *                                           PROCURE POR V.22     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 21 - CAD 48.792   -                                   *      */
        /*"      *               - AJUSTAR O PROGRAMA PARA GRAVAR NA TABELA       *      */
        /*"      *                 SEGUROS.HIST_LANC_CTA O CODIGO DO BANCO E A    *      */
        /*"      *                 CONTA.                                         *      */
        /*"      *                                                                *      */
        /*"      *   EM 14/01/2011 - MARCO PAIVA (FAST COMPUTER)                  *      */
        /*"      *                                           PROCURE POR V.21     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 20 - CAD 37.182   -                                   *      */
        /*"      *               - GARANTE PARCELA PAGA PARA EFETUAR DEVOLUCAO    *      */
        /*"      *                 DE PREMIO.                                     *      */
        /*"      *                                                                *      */
        /*"      *   EM 17/02/2010 - EDIVALDO GOMES                               *      */
        /*"      *                                           PROCURE POR V.20     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 19 - CAD 35.035   -                                   *      */
        /*"      *               - AUMENTO DE OCORRENCIAS NA TABELA INTERNA       *      */
        /*"      *                 IGPM.                                          *      */
        /*"      *                                                                *      */
        /*"      *   EM 06/01/2010 - TERCIO FREITAS                               *      */
        /*"      *                                           PROCURE POR V.18     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 18 - CADMUS 27144 - O PROGRAMA ESTA INSERINDO         *      */
        /*"      *               INDEVIDAMENTE NA TABELA HIST_CONT_PARCELVA       *      */
        /*"      *               PARA OPCAO CHEQUE.                               *      */
        /*"      *                                                                *      */
        /*"      *   EM 17/07/2009 - TERCIO(FAST COMPUTER)   PROCURE POR V.18     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 17 - CADMUS 25935 - PROJETO REDUCAO DE CHEQUES        *      */
        /*"      *               AJUSTE NA SITUACAO DA V0HISTCOBVA.               *      */
        /*"      *                                                                *      */
        /*"      *   EM 28/04/2009 - TERCIO(FAST COMPUTER)   PROCURE POR V.17     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 16 - CADMUS 14198 - PROJETO REDUCAO DE CHEQUES        *      */
        /*"      *               AJUSTE NA SITUACAO DA V0HISTCOBVA.               *      */
        /*"      *                                                                *      */
        /*"      *   EM 28/04/2009 - TERCIO(FAST COMPUTER)   PROCURE POR V.16     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 15 - CADMUS 14198 - PROJETO REDUCAO DE CHEQUES        *      */
        /*"      *               PASSA A NAO MAIS SOLICITAR A IMPRESSAO DE CHEQUES*      */
        /*"      *               PASSA A GERAR ARQUIVO CONTENDO OS DADOS          *      */
        /*"      *               DE CADASTRO, SEGURO E COBRANCA A SER DISPONIBILI-*      */
        /*"      *               ZADOS PARA A GERAR LOCALIZAR O DOMICILIO BANCARIO*      */
        /*"      *                                                                *      */
        /*"      *   EM 28/04/2009 - TERCIO(FAST COMPUTER)   PROCURE POR V.15     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 14 - CADMUS 18452- NAO DEIXAR ABENDAR QUANDO O        *      */
        /*"      *               SQLCODE = -811 NA V0HISTCOBVA.                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 11/12/2008 - MARCO(FAST)             PROCURE POR V.14     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 13 - CADMUS 6338 - NAO DEIXAR ABENDAR QUANDO A        *      */
        /*"      *               OPCAO DE PAGAMENTO FOR IGUAL A ZERO.             *      */
        /*"      *                                                                *      */
        /*"      *   EM 13/11/2007 - MARCO(FAST)             PROCURE POR V.13     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 12 - AJUSTADA A SITUACAO DA COBER_HIST_VIDAZUL        *      */
        /*"      *               PARA DEVOLVIDO (7) QUANDO DEBITO EM CONTA        *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/06/2007 - TERCIO(FAST)             PROCURE POR V.12    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 11 - RETIRA A CRITICA DA DATA-QUITACAO < '2006-07-01  *      */
        /*"      *               E DA PARCELA = 1                                 *      */
        /*"      *                                                                *      */
        /*"      *   EM 12/04/2007 - MARCO (FAST)             PROCURE POR V.11    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 10 - PASSA A RECECER O VALOR A SER DEVOLVIDO DE       *      */
        /*"      *               DEMAIS PARCELAS NA COLUNA NUM_ORDEM              *      */
        /*"      *                                                                *      */
        /*"      *   EM 03/04/2007 - FAST COMPUTER            PROCURE POR V.10    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 09 - INCREMENTA A OCORRENCIA DE HISTORICO PARA        *      */
        /*"      *               INSERIR NA HIST_LANC_CTA.                        *      */
        /*"      *                                                                *      */
        /*"      *   EM 02/03/2007 - FAST COMPUTER            PROCURE POR V.09    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 08 - O NUMERO DA PARCELA NO INSERT DA RELATORIOS      *      */
        /*"      *               ESTAVA FIXO EM 1. PASSA A PEGAR O NUMERO DA PAR- *      */
        /*"      *               CELA LIDA NO CURSOR PRINCIPAL.                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 01/03/2007 - FAST COMPUTER            PROCURE POR V.08    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 07 - SE O INDICE DE REAJUSTE DA TABELA DE IGPM FOR    *      */
        /*"      *               ZERO NAO ENTRA NO TOTAL DE INDICES ACUMULADOS    *      */
        /*"      *               PARA O PERIODO.                                  *      */
        /*"      *                                                                *      */
        /*"      *   EM 27/02/2007 - FAST COMPUTER            PROCURE POR V.07    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 06 - NAO ABENDAR QUANDO SQLCODE = 100 NO PARAGRAFO    *      */
        /*"      *               R2500-00-INSERT-RELATORIOS                       *      */
        /*"      *                                                                *      */
        /*"      *   EM 27/02/2007 - LUCIA VIEIRA             PROCURE POR V.06    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 05 - ACRESCENTA NA CONDICAO WHERE NA ATUALIZACAO NA   *      */
        /*"      *               RELATORIOS NUM_PARCELA DA TABELA RELATORIO.      *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/02/2007 - MARCO PAIVA              PROCURE POR V.05    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 04 - ATUALIZA O TIMESTAMP DA PARCELVA                 *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/12/2006 - FAST COMPUTER            PROCURE POR V.04    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 03 - RETIRADO O FILTRO DE INDICE MENOR OU IGUAL A ZERO*      */
        /*"      *                                                                *      */
        /*"      *   EM 01/12/2006 - FAST COMPUTER            PROCURE POR V.03    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO   *    DATA    *    AUTOR     *       HISTORICO       *      */
        /*"      *            *            *              *                       *      */
        /*"      *     02     *  21/08/06  * LUCIA VIEIRA * ABEND -803 VER V.02   *      */
        /*"      *     01     *  14/06/06  * FAST COMPUTER*                       *      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        public FileBasis _ARQCHEQ { get; set; } = new FileBasis(new PIC("X", "200", "X(200)"));

        public FileBasis ARQCHEQ
        {
            get
            {
                _.Move(REG_CHEQ, _ARQCHEQ); VarBasis.RedefinePassValue(REG_CHEQ, _ARQCHEQ, REG_CHEQ); return _ARQCHEQ;
            }
        }
        /*"01  REG-CHEQ                    PIC X(0200).*/
        public StringBasis REG_CHEQ { get; set; } = new StringBasis(new PIC("X", "200", "X(0200)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  W-RETURN-CODE               PIC  9(006)      VALUE  0.*/
        public IntBasis W_RETURN_CODE { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"77  VIND-AGE                    PIC S9(004) COMP VALUE +0.*/
        public IntBasis VIND_AGE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-OPE                    PIC S9(004) COMP VALUE +0.*/
        public IntBasis VIND_OPE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-CTA                    PIC S9(004) COMP VALUE +0.*/
        public IntBasis VIND_CTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-DIG                    PIC S9(004) COMP VALUE +0.*/
        public IntBasis VIND_DIG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-BANCO                  PIC S9(004) COMP VALUE +0.*/
        public IntBasis VIND_BANCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-DTA-DECLINIO           PIC S9(004) COMP VALUE +0.*/
        public IntBasis VIND_DTA_DECLINIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-NULL01                 PIC S9(004) COMP VALUE +0.*/
        public IntBasis VIND_NULL01 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-NULL02                 PIC S9(004) COMP VALUE +0.*/
        public IntBasis VIND_NULL02 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-DTENV                  PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_DTENV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-DTRET                  PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_DTRET { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-CODRET                 PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_CODRET { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-NREQ                   PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_NREQ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-SEQUEN                 PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_SEQUEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-NLOTE                  PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_NLOTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-DTCRED                 PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_DTCRED { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-STATUS                 PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_STATUS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-VLCRED                 PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_VLCRED { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-CCRE                   PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_CCRE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-OPC-PAG-ADESAO         PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_OPC_PAG_ADESAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-COD-MOEDA              PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_COD_MOEDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-PCT-INDICE             PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_PCT_INDICE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-VLR-ORIGINAL           PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_VLR_ORIGINAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-VLR-PRORATA            PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_VLR_PRORATA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-VLR-JUROS              PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_VLR_JUROS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-VLR-MULTA              PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_VLR_MULTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-DTA-ORIGINAL           PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_DTA_ORIGINAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-COD-IDLG               PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_COD_IDLG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WS-COD-CONVENIO             PIC S9(004) COMP VALUE +0.*/
        public IntBasis WS_COD_CONVENIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-DTMOVTO                PIC S9(004) COMP VALUE +0.*/
        public IntBasis VIND_DTMOVTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-ESTR-COBR              PIC S9(004) COMP VALUE +0.*/
        public IntBasis VIND_ESTR_COBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-ORIG-PRODU             PIC S9(004) COMP VALUE +0.*/
        public IntBasis VIND_ORIG_PRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-TEM-SAF                PIC S9(004) COMP VALUE +0.*/
        public IntBasis VIND_TEM_SAF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-TEM-IGPM               PIC S9(004) COMP VALUE +0.*/
        public IntBasis VIND_TEM_IGPM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-TEM-CDG                PIC S9(004) COMP VALUE +0.*/
        public IntBasis VIND_TEM_CDG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WS-VALOR-COM-CORR           PIC  X(001) VALUE 'N'.*/
        public StringBasis WS_VALOR_COM_CORR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"77  WS-QTD-CORRECAO             PIC S9(004) COMP VALUE +0.*/
        public IntBasis WS_QTD_CORRECAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WS-VL-PRM-TEMP              PIC S9(13)V99 VALUE ZEROS COMP-3*/
        public DoubleBasis WS_VL_PRM_TEMP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  WS-OCORR-HISTORICOCTA       PIC S9(004) VALUE +0 COMP.*/
        public IntBasis WS_OCORR_HISTORICOCTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WS-PRM-TOTAL-ANT            PIC S9(13)V99 VALUE ZEROS COMP-3*/
        public DoubleBasis WS_PRM_TOTAL_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  WHOST-DATA-PESQ      PIC  X(10).*/
        public StringBasis WHOST_DATA_PESQ { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  WHOST-DATA-CRED      PIC  X(10).*/
        public StringBasis WHOST_DATA_CRED { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  WHOST-DT-CRED-INI    PIC  X(10).*/
        public StringBasis WHOST_DT_CRED_INI { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  WS-DTFATUR           PIC  X(10).*/
        public StringBasis WS_DTFATUR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  WHOST-DT-INI         PIC  9(08).*/
        public IntBasis WHOST_DT_INI { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
        /*"77  WHOST-DT-FIM         PIC  9(08).*/
        public IntBasis WHOST_DT_FIM { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
        /*"77  WDTA-DECLINIO        PIC  X(10).*/
        public StringBasis WDTA_DECLINIO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  WQTD-HIST-CONT       PIC S9(004) VALUE +0 COMP.*/
        public IntBasis WQTD_HIST_CONT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WQTD-QTD             PIC S9(004) VALUE +0 COMP.*/
        public IntBasis WQTD_QTD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WQTDIAS              PIC S9(004) VALUE +0 COMP.*/
        public IntBasis WQTDIAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WDIAS-DECLINIO       PIC S9(004) VALUE +0 COMP.*/
        public IntBasis WDIAS_DECLINIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WS-NSAS-ERRO         PIC S9(004) VALUE +0 COMP.*/
        public IntBasis WS_NSAS_ERRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WDATA-DECLINIO       PIC  X(010) VALUE SPACES.*/
        public StringBasis WDATA_DECLINIO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77  WHOST-PREMIO         PIC S9(13)V99 VALUE ZEROES COMP-3.*/
        public DoubleBasis WHOST_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  WHOST-PREMIO1        PIC S9(13)V99 VALUE ZEROES COMP-3.*/
        public DoubleBasis WHOST_PREMIO1 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  WHOST-PREM-NEW       PIC S9(13)V99 VALUE ZEROES COMP-3.*/
        public DoubleBasis WHOST_PREM_NEW { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  WHOST-NEW-PRM        PIC S9(13)V99 VALUE ZEROES COMP-3.*/
        public DoubleBasis WHOST_NEW_PRM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  WHOST-PRM-VG         PIC S9(13)V99 VALUE ZEROES COMP-3.*/
        public DoubleBasis WHOST_PRM_VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  WHOST-PRM-AP         PIC S9(13)V99 VALUE ZEROES COMP-3.*/
        public DoubleBasis WHOST_PRM_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  WHOST-JUROS          PIC S9(13)V99 VALUE ZEROES COMP-3.*/
        public DoubleBasis WHOST_JUROS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  V1SIST-DTHOJE               PIC  X(10).*/
        public StringBasis V1SIST_DTHOJE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  WORK-AREA.*/
        public VA0469B_WORK_AREA WORK_AREA { get; set; } = new VA0469B_WORK_AREA();
        public class VA0469B_WORK_AREA : VarBasis
        {
            /*"    05      WS-OPC-PAGTO        PIC  X(001) VALUE 'S'.*/
            public StringBasis WS_OPC_PAGTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"S");
            /*"    05      WULTDIA             PIC  9(002) VALUE ZEROES.*/
            public IntBasis WULTDIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"    05      WDIAS-AUX           PIC  9(004) VALUE ZEROES.*/
            public IntBasis WDIAS_AUX { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05      WINI-MES            PIC  9(002) VALUE ZEROES.*/
            public IntBasis WINI_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"    05      WDATA-INI.*/
            public VA0469B_WDATA_INI WDATA_INI { get; set; } = new VA0469B_WDATA_INI();
            public class VA0469B_WDATA_INI : VarBasis
            {
                /*"      10    WANO-INI            PIC  9(004) VALUE ZEROES.*/
                public IntBasis WANO_INI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"      10    FILLER              PIC  X(001).*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10    WMES-INI            PIC  9(002) VALUE ZEROES.*/
                public IntBasis WMES_INI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"      10    FILLER              PIC  X(001).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10    WDIA-INI            PIC  9(002) VALUE ZEROES.*/
                public IntBasis WDIA_INI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05      IND1                PIC  9(003) VALUE ZEROS.*/
            }
            public IntBasis IND1 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"    05      IND2                PIC  9(003) VALUE ZEROS.*/
            public IntBasis IND2 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"    05      IND4                PIC  9(003) VALUE ZEROS.*/
            public IntBasis IND4 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"    05      MOEDA               PIC  9(003) VALUE ZEROS.*/
            public IntBasis MOEDA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"    05      AA-ATU              PIC  9(004) VALUE ZEROS.*/
            public IntBasis AA_ATU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05      AA-INI              PIC  9(004) VALUE ZEROS.*/
            public IntBasis AA_INI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05      MM-INI              PIC  9(004) VALUE ZEROS.*/
            public IntBasis MM_INI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05      AA-MOE              PIC  9(004) VALUE ZEROS.*/
            public IntBasis AA_MOE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05      WS-IGPM-ACUM        PIC S9(6)V9(9) VALUE ZEROS                                            COMP-3.*/
            public DoubleBasis WS_IGPM_ACUM { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(6)V9(9)"), 9);
            /*"    05      WMOEDA-ANT          PIC  9(004) VALUE ZEROS.*/
            public IntBasis WMOEDA_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05      WVAL-VENDA          PIC S9(006)V9(09) COMP-3.*/
            public DoubleBasis WVAL_VENDA { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(09)"), 9);
            /*"    05      WPRM-TOTAL          PIC S9(13)V99 VALUE ZEROS                                            COMP-3.*/
            public DoubleBasis WPRM_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05      WPRM-VG             PIC S9(13)V99 VALUE ZEROS                                            COMP-3.*/
            public DoubleBasis WPRM_VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05      WPRM-AP             PIC S9(13)V99 VALUE ZEROS                                            COMP-3.*/
            public DoubleBasis WPRM_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05      WJUROS              PIC S9(13)V99 VALUE ZEROS                                            COMP-3.*/
            public DoubleBasis WJUROS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05      APOLICE-ATU         PIC  9(15) VALUE ZEROES.*/
            public IntBasis APOLICE_ATU { get; set; } = new IntBasis(new PIC("9", "15", "9(15)"));
            /*"    05      SUBGRUPO-ATU        PIC  9(04) VALUE ZEROES.*/
            public IntBasis SUBGRUPO_ATU { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
            /*"    05      APOLICE-ANT         PIC  9(15) VALUE ZEROES.*/
            public IntBasis APOLICE_ANT { get; set; } = new IntBasis(new PIC("9", "15", "9(15)"));
            /*"    05      SUBGRUPO-ANT        PIC  9(04) VALUE ZEROES.*/
            public IntBasis SUBGRUPO_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
            /*"    05      WS-RETORNO-SAP      PIC  X(01) VALUE SPACE.*/

            public SelectorBasis WS_RETORNO_SAP { get; set; } = new SelectorBasis("01", "SPACE")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88   WS-SIM-RETORNOU-SAP            VALUE 'S'. */
							new SelectorItemBasis("WS_SIM_RETORNOU_SAP", "S"),
							/*" 88   WS-NAO-RETORNOU-SAP            VALUE 'N'. */
							new SelectorItemBasis("WS_NAO_RETORNOU_SAP", "N")
                }
            };

            /*"    05      W04DTSQL.*/
            public VA0469B_W04DTSQL W04DTSQL { get; set; } = new VA0469B_W04DTSQL();
            public class VA0469B_W04DTSQL : VarBasis
            {
                /*"      10    W04AASQL            PIC 9(004).*/
                public IntBasis W04AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10    W04T1SQL            PIC X(001).*/
                public StringBasis W04T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10    W04MMSQL            PIC 9(002).*/
                public IntBasis W04MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    W04T2SQL            PIC X(001).*/
                public StringBasis W04T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10    W04DDSQL            PIC 9(002).*/
                public IntBasis W04DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05      WS-DATA-AUX         PIC X(010).*/
            }
            public StringBasis WS_DATA_AUX { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05      PARM-PROSOMU1.*/
            public VA0469B_PARM_PROSOMU1 PARM_PROSOMU1 { get; set; } = new VA0469B_PARM_PROSOMU1();
            public class VA0469B_PARM_PROSOMU1 : VarBasis
            {
                /*"      10    SU1-DATA1.*/
                public VA0469B_SU1_DATA1 SU1_DATA1 { get; set; } = new VA0469B_SU1_DATA1();
                public class VA0469B_SU1_DATA1 : VarBasis
                {
                    /*"        15  SU1-DD1             PIC 99.*/
                    public IntBasis SU1_DD1 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"        15  SU1-MM1             PIC 99.*/
                    public IntBasis SU1_MM1 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"        15  SU1-AA1             PIC 9999.*/
                    public IntBasis SU1_AA1 { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
                    /*"      10    SU1-NRDIAS          PIC S9(5) COMP-3.*/
                }
                public IntBasis SU1_NRDIAS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(5)"));
                /*"      10    SU1-DATA2.*/
                public VA0469B_SU1_DATA2 SU1_DATA2 { get; set; } = new VA0469B_SU1_DATA2();
                public class VA0469B_SU1_DATA2 : VarBasis
                {
                    /*"        15  SU1-DD2             PIC 99.*/
                    public IntBasis SU1_DD2 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"        15  SU1-MM2             PIC 99.*/
                    public IntBasis SU1_MM2 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"        15  SU1-AA2             PIC 9999.*/
                    public IntBasis SU1_AA2 { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
                    /*"    05      DATA-SQL.*/
                }
            }
            public VA0469B_DATA_SQL DATA_SQL { get; set; } = new VA0469B_DATA_SQL();
            public class VA0469B_DATA_SQL : VarBasis
            {
                /*"      10    ANO-SQL             PIC  9(004).*/
                public IntBasis ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10    FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10    MES-SQL             PIC  9(002).*/
                public IntBasis MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10    DIA-SQL             PIC  9(002).*/
                public IntBasis DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05      WS-DT8-AMD.*/
            }
            public VA0469B_WS_DT8_AMD WS_DT8_AMD { get; set; } = new VA0469B_WS_DT8_AMD();
            public class VA0469B_WS_DT8_AMD : VarBasis
            {
                /*"      10    WS-ANO-AMD             PIC  9(004).*/
                public IntBasis WS_ANO_AMD { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10    WS-MES-AMD             PIC  9(002).*/
                public IntBasis WS_MES_AMD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    WS-DIA-AMD             PIC  9(002).*/
                public IntBasis WS_DIA_AMD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05      DATA-INI.*/
            }
            public VA0469B_DATA_INI DATA_INI { get; set; } = new VA0469B_DATA_INI();
            public class VA0469B_DATA_INI : VarBasis
            {
                /*"      10    ANO-INI             PIC  9(004).*/
                public IntBasis ANO_INI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10    FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10    MES-INI             PIC  9(002).*/
                public IntBasis MES_INI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10    DIA-INI             PIC  9(002).*/
                public IntBasis DIA_INI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05      DATA-INI-R  REDEFINES DATA-INI.*/
            }
            private _REDEF_VA0469B_DATA_INI_R _data_ini_r { get; set; }
            public _REDEF_VA0469B_DATA_INI_R DATA_INI_R
            {
                get { _data_ini_r = new _REDEF_VA0469B_DATA_INI_R(); _.Move(DATA_INI, _data_ini_r); VarBasis.RedefinePassValue(DATA_INI, _data_ini_r, DATA_INI); _data_ini_r.ValueChanged += () => { _.Move(_data_ini_r, DATA_INI); }; return _data_ini_r; }
                set { VarBasis.RedefinePassValue(value, _data_ini_r, DATA_INI); }
            }  //Redefines
            public class _REDEF_VA0469B_DATA_INI_R : VarBasis
            {
                /*"      10    AAMM-INI            PIC  X(007).*/
                public StringBasis AAMM_INI { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
                /*"      10    REST-INI            PIC  X(003).*/
                public StringBasis REST_INI { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"    05      DATA-INI-DEC.*/

                public _REDEF_VA0469B_DATA_INI_R()
                {
                    AAMM_INI.ValueChanged += OnValueChanged;
                    REST_INI.ValueChanged += OnValueChanged;
                }

            }
            public VA0469B_DATA_INI_DEC DATA_INI_DEC { get; set; } = new VA0469B_DATA_INI_DEC();
            public class VA0469B_DATA_INI_DEC : VarBasis
            {
                /*"      10    ANO-INI-DEC         PIC  9(004).*/
                public IntBasis ANO_INI_DEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10    FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10    MES-INI-DEC         PIC  9(002).*/
                public IntBasis MES_INI_DEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10    DIA-INI-DEC         PIC  9(002).*/
                public IntBasis DIA_INI_DEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05      DATA-INI-R  REDEFINES DATA-INI-DEC.*/
            }
            private _REDEF_VA0469B_DATA_INI_R_0 _data_ini_r_0 { get; set; }
            public _REDEF_VA0469B_DATA_INI_R_0 DATA_INI_R_0
            {
                get { _data_ini_r_0 = new _REDEF_VA0469B_DATA_INI_R_0(); _.Move(DATA_INI_DEC, _data_ini_r_0); VarBasis.RedefinePassValue(DATA_INI_DEC, _data_ini_r_0, DATA_INI_DEC); _data_ini_r_0.ValueChanged += () => { _.Move(_data_ini_r_0, DATA_INI_DEC); }; return _data_ini_r_0; }
                set { VarBasis.RedefinePassValue(value, _data_ini_r_0, DATA_INI_DEC); }
            }  //Redefines
            public class _REDEF_VA0469B_DATA_INI_R_0 : VarBasis
            {
                /*"      10    AAMM-INI-DEC        PIC  X(007).*/
                public StringBasis AAMM_INI_DEC { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
                /*"      10    REST-INI-DEC        PIC  X(003).*/
                public StringBasis REST_INI_DEC { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"    05      DATA-FIM.*/

                public _REDEF_VA0469B_DATA_INI_R_0()
                {
                    AAMM_INI_DEC.ValueChanged += OnValueChanged;
                    REST_INI_DEC.ValueChanged += OnValueChanged;
                }

            }
            public VA0469B_DATA_FIM DATA_FIM { get; set; } = new VA0469B_DATA_FIM();
            public class VA0469B_DATA_FIM : VarBasis
            {
                /*"      10    ANO-FIM             PIC  9(004).*/
                public IntBasis ANO_FIM { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10    FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10    MES-FIM             PIC  9(002).*/
                public IntBasis MES_FIM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10    DIA-FIM             PIC  9(002).*/
                public IntBasis DIA_FIM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05      DATA-FIM-R  REDEFINES DATA-FIM.*/
            }
            private _REDEF_VA0469B_DATA_FIM_R _data_fim_r { get; set; }
            public _REDEF_VA0469B_DATA_FIM_R DATA_FIM_R
            {
                get { _data_fim_r = new _REDEF_VA0469B_DATA_FIM_R(); _.Move(DATA_FIM, _data_fim_r); VarBasis.RedefinePassValue(DATA_FIM, _data_fim_r, DATA_FIM); _data_fim_r.ValueChanged += () => { _.Move(_data_fim_r, DATA_FIM); }; return _data_fim_r; }
                set { VarBasis.RedefinePassValue(value, _data_fim_r, DATA_FIM); }
            }  //Redefines
            public class _REDEF_VA0469B_DATA_FIM_R : VarBasis
            {
                /*"      10    AAMM-FIM            PIC  X(007).*/
                public StringBasis AAMM_FIM { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
                /*"      10    REST-FIM            PIC  X(003).*/
                public StringBasis REST_FIM { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"    05      WFIM-RELATORIOS     PIC  X(001)  VALUE  ' '.*/

                public _REDEF_VA0469B_DATA_FIM_R()
                {
                    AAMM_FIM.ValueChanged += OnValueChanged;
                    REST_FIM.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WFIM_RELATORIOS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"    05      WFIM-SISTEMAS       PIC  X(001)  VALUE  ' '.*/
            public StringBasis WFIM_SISTEMAS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"    05      WFIM-MOEDACOT       PIC  X(001)  VALUE  ' '.*/
            public StringBasis WFIM_MOEDACOT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"    05      WTEM-ALCADA         PIC  X(001)  VALUE  'N'.*/
            public StringBasis WTEM_ALCADA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"01          ACUMULADORES.*/
        }
        public VA0469B_ACUMULADORES ACUMULADORES { get; set; } = new VA0469B_ACUMULADORES();
        public class VA0469B_ACUMULADORES : VarBasis
        {
            /*"    05      AC-LIDOS            PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05      AC-GRAVA            PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_GRAVA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05      AC-I-HISLANCT       PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_I_HISLANCT { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05      AC-I-HISCONPA       PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_I_HISCONPA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05      AC-I-RELATORI       PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_I_RELATORI { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05      AC-I-MOVDEBCE       PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_I_MOVDEBCE { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05      AC-U-COBHISVI       PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_U_COBHISVI { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05      AC-U-PARCEVID       PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_U_PARCEVID { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05      AC-U-PROPOVA        PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_U_PROPOVA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05      AC-R-PROPOVA        PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_R_PROPOVA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05      AC-R-DTQITBCO       PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_R_DTQITBCO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05      AC-R-PARCEVID       PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_R_PARCEVID { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05      AC-R-HISCOBPA       PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_R_HISCOBPA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05      AC-R-OPCPAGVI       PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_R_OPCPAGVI { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05      AC-R-COBHISVI       PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_R_COBHISVI { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05      AC-D-CARTAO-CREDITO PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_D_CARTAO_CREDITO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05      AC-I-MOVDEB-EV9021  PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_I_MOVDEB_EV9021 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05      AC-I-MOVDEB-EV9022  PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_I_MOVDEB_EV9022 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05      AC-I-MOVDEB-CORRECAO PIC 9(006) VALUE ZEROS.*/
            public IntBasis AC_I_MOVDEB_CORRECAO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05      AC-U-MOVDEB-CORRECAO PIC 9(006) VALUE ZEROS.*/
            public IntBasis AC_U_MOVDEB_CORRECAO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05      AC-U-HISLANCT       PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_U_HISLANCT { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05      AC-U-MOVDEBCE       PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_U_MOVDEBCE { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"01          REG-CABEC-01.*/
        }
        public VA0469B_REG_CABEC_01 REG_CABEC_01 { get; set; } = new VA0469B_REG_CABEC_01();
        public class VA0469B_REG_CABEC_01 : VarBasis
        {
            /*"  10        FILLER              PIC  X(010) VALUE 'VA0469B'.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VA0469B");
            /*"  10        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        FILLER              PIC  X(050) VALUE           'DEVOLUCOES COM OPCAO DE PAGAMENTO CHEQUE'.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"DEVOLUCOES COM OPCAO DE PAGAMENTO CHEQUE");
            /*"  10        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        FILLER              PIC  X(010) VALUE 'DATA:'.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DATA:");
            /*"  10        REG-CABEC-01-DATA   PIC  X(010).*/
            public StringBasis REG_CABEC_01_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  10        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"01          REG-CABEC-02.*/
        }
        public VA0469B_REG_CABEC_02 REG_CABEC_02 { get; set; } = new VA0469B_REG_CABEC_02();
        public class VA0469B_REG_CABEC_02 : VarBasis
        {
            /*"  10        FILLER              PIC  X(011) VALUE 'CERTIFICADO'.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"CERTIFICADO");
            /*"  10        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        FILLER              PIC  X(007) VALUE 'PARCELA'.*/
            public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"PARCELA");
            /*"  10        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        FILLER              PIC  X(006) VALUE 'PREMIO'.*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"PREMIO");
            /*"  10        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        FILLER              PIC  X(007) VALUE 'USUARIO'.*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"USUARIO");
            /*"  10        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"01          REG-SAIDA.*/
        }
        public VA0469B_REG_SAIDA REG_SAIDA { get; set; } = new VA0469B_REG_SAIDA();
        public class VA0469B_REG_SAIDA : VarBasis
        {
            /*"  10        SAI-NRCERTIF        PIC  9(015).*/
            public IntBasis SAI_NRCERTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"  10        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        SAI-NRPARCEL        PIC  9(005).*/
            public IntBasis SAI_NRPARCEL { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"  10        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        SAI-VLPREMIO        PIC  9999999999999,99.*/
            public DoubleBasis SAI_VLPREMIO { get; set; } = new DoubleBasis(new PIC("9", "13", "9999999999999V99."), 2);
            /*"  10        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        SAI-USUARIO         PIC  X(008).*/
            public StringBasis SAI_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  10        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"01          TABELA-ULTIMOS-DIAS.*/
        }
        public VA0469B_TABELA_ULTIMOS_DIAS TABELA_ULTIMOS_DIAS { get; set; } = new VA0469B_TABELA_ULTIMOS_DIAS();
        public class VA0469B_TABELA_ULTIMOS_DIAS : VarBasis
        {
            /*"  10        FILLER              PIC  X(024)            VALUE '312831303130313130313031'.*/
            public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"312831303130313130313031");
            /*"01          TB-ULTIMOS-DIAS     REDEFINES            TABELA-ULTIMOS-DIAS.*/
        }
        private _REDEF_VA0469B_TB_ULTIMOS_DIAS _tb_ultimos_dias { get; set; }
        public _REDEF_VA0469B_TB_ULTIMOS_DIAS TB_ULTIMOS_DIAS
        {
            get { _tb_ultimos_dias = new _REDEF_VA0469B_TB_ULTIMOS_DIAS(); _.Move(TABELA_ULTIMOS_DIAS, _tb_ultimos_dias); VarBasis.RedefinePassValue(TABELA_ULTIMOS_DIAS, _tb_ultimos_dias, TABELA_ULTIMOS_DIAS); _tb_ultimos_dias.ValueChanged += () => { _.Move(_tb_ultimos_dias, TABELA_ULTIMOS_DIAS); }; return _tb_ultimos_dias; }
            set { VarBasis.RedefinePassValue(value, _tb_ultimos_dias, TABELA_ULTIMOS_DIAS); }
        }  //Redefines
        public class _REDEF_VA0469B_TB_ULTIMOS_DIAS : VarBasis
        {
            /*"  10        TB-DIA-MESES        OCCURS 12.*/
            public ListBasis<VA0469B_TB_DIA_MESES> TB_DIA_MESES { get; set; } = new ListBasis<VA0469B_TB_DIA_MESES>(12);
            public class VA0469B_TB_DIA_MESES : VarBasis
            {
                /*"    15      TB-ULT-DIA          PIC 9(002).*/
                public IntBasis TB_ULT_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"01  WABEND.*/

                public VA0469B_TB_DIA_MESES()
                {
                    TB_ULT_DIA.ValueChanged += OnValueChanged;
                }

            }

            public _REDEF_VA0469B_TB_ULTIMOS_DIAS()
            {
                TB_DIA_MESES.ValueChanged += OnValueChanged;
            }

        }
        public VA0469B_WABEND WABEND { get; set; } = new VA0469B_WABEND();
        public class VA0469B_WABEND : VarBasis
        {
            /*"    05    FILLER                   PIC  X(010) VALUE          'VA0469B  '.*/
            public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VA0469B  ");
            /*"    05    FILLER                   PIC  X(028) VALUE          ' *** ERRO  EXEC SQL *** '.*/
            public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL *** ");
            /*"    05    FILLER                   PIC  X(014) VALUE          '    SQLCODE = '.*/
            public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
            /*"    05    WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"    05    FILLER                   PIC  X(014)   VALUE          '   SQLERRD1 = '.*/
            public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
            /*"    05    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"    05    FILLER                   PIC  X(014)   VALUE          '   SQLERRD2 = '.*/
            public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"    05    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"    05    FILLER                   PIC  X(014)   VALUE             '   SQLERRD2 = '.*/
            public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"    05      LOCALIZA-ABEND-1.*/
            public VA0469B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new VA0469B_LOCALIZA_ABEND_1();
            public class VA0469B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"      10    FILLER                  PIC  X(012)   VALUE            'PARAGRAFO = '.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"      10    PARAGRAFO               PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05      LOCALIZA-ABEND-2.*/
            }
            public VA0469B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new VA0469B_LOCALIZA_ABEND_2();
            public class VA0469B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"       10    FILLER                  PIC  X(012)   VALUE             'COMANDO   = '.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"       10    COMANDO                 PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"    05         WSQLERRO.*/
            }
            public VA0469B_WSQLERRO WSQLERRO { get; set; } = new VA0469B_WSQLERRO();
            public class VA0469B_WSQLERRO : VarBasis
            {
                /*"      10       FILLER               PIC  X(014) VALUE              ' *** SQLERRMC '.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @" *** SQLERRMC ");
                /*"      10       WSQLERRMC            PIC  X(070) VALUE  SPACES.*/
                public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
            }
        }


        public Copies.SPVG001V SPVG001V { get; set; } = new Copies.SPVG001V();
        public Copies.SPVG001W SPVG001W { get; set; } = new Copies.SPVG001W();
        public Copies.SPVG011W SPVG011W { get; set; } = new Copies.SPVG011W();
        public Copies.SPVG011V SPVG011V { get; set; } = new Copies.SPVG011V();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.CONVEVG CONVEVG { get; set; } = new Dclgens.CONVEVG();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.OPCPAGVI OPCPAGVI { get; set; } = new Dclgens.OPCPAGVI();
        public Dclgens.PARCEVID PARCEVID { get; set; } = new Dclgens.PARCEVID();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.COBHISVI COBHISVI { get; set; } = new Dclgens.COBHISVI();
        public Dclgens.VG077 VG077 { get; set; } = new Dclgens.VG077();
        public Dclgens.HISLANCT HISLANCT { get; set; } = new Dclgens.HISLANCT();
        public Dclgens.VG078 VG078 { get; set; } = new Dclgens.VG078();
        public Dclgens.MOEDACOT MOEDACOT { get; set; } = new Dclgens.MOEDACOT();
        public Dclgens.HISCONPA HISCONPA { get; set; } = new Dclgens.HISCONPA();
        public Dclgens.USUFILSE USUFILSE { get; set; } = new Dclgens.USUFILSE();
        public Dclgens.MOVIMVGA MOVIMVGA { get; set; } = new Dclgens.MOVIMVGA();
        public Dclgens.RCAPS RCAPS { get; set; } = new Dclgens.RCAPS();
        public Dclgens.RCAPCOMP RCAPCOMP { get; set; } = new Dclgens.RCAPCOMP();
        public Dclgens.AVISOSAL AVISOSAL { get; set; } = new Dclgens.AVISOSAL();
        public Dclgens.MOVDEBCE MOVDEBCE { get; set; } = new Dclgens.MOVDEBCE();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.GE408 GE408 { get; set; } = new Dclgens.GE408();
        public VA0469B_TRELAT TRELAT { get; set; } = new VA0469B_TRELAT();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string ARQCHEQ_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                ARQCHEQ.SetFile(ARQCHEQ_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -913- MOVE 'R0000-00-PRINCIPAL' TO PARAGRAFO. */
            _.Move("R0000-00-PRINCIPAL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -914- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -917- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -920- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -923- DISPLAY ' ' */
            _.Display($" ");

            /*" -924- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -925- DISPLAY '  VA0469B -  PROCESSAR DEVOLUCOES SOLICITADAS AOS  ' */
            _.Display($"  VA0469B -  PROCESSAR DEVOLUCOES SOLICITADAS AOS  ");

            /*" -926- DISPLAY '                        SEGURADOS.' */
            _.Display($"                        SEGURADOS.");

            /*" -927- DISPLAY ' ' */
            _.Display($" ");

            /*" -951- DISPLAY 'VERSAO V.63 - DEMANDA RITM0002669 - 10/10/2024 >> ' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) ' AS ' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) */

            $"VERSAO V.63 - DEMANDA RITM0002669 - 10/10/2024 >> FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)} AS FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}"
            .Display();

            /*" -952- DISPLAY ' ' */
            _.Display($" ");

            /*" -953- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -955- DISPLAY ' ' */
            _.Display($" ");

            /*" -957- PERFORM R0100-00-SELECT-SISTEMAS. */

            R0100_00_SELECT_SISTEMAS_SECTION();

            /*" -959- DISPLAY 'DATA DO CREDITO: ' WHOST-DATA-CRED */
            _.Display($"DATA DO CREDITO: {WHOST_DATA_CRED}");

            /*" -960- OPEN OUTPUT ARQCHEQ */
            ARQCHEQ.Open(REG_CHEQ);

            /*" -961- WRITE REG-CHEQ FROM REG-CABEC-01. */
            _.Move(REG_CABEC_01.GetMoveValues(), REG_CHEQ);

            ARQCHEQ.Write(REG_CHEQ.GetMoveValues().ToString());

            /*" -962- WRITE REG-CHEQ FROM REG-CABEC-02. */
            _.Move(REG_CABEC_02.GetMoveValues(), REG_CHEQ);

            ARQCHEQ.Write(REG_CHEQ.GetMoveValues().ToString());

            /*" -964- ADD 2 TO AC-GRAVA. */
            ACUMULADORES.AC_GRAVA.Value = ACUMULADORES.AC_GRAVA + 2;

            /*" -965- IF WFIM-SISTEMAS NOT EQUAL SPACES */

            if (!WORK_AREA.WFIM_SISTEMAS.IsEmpty())
            {

                /*" -966- DISPLAY '*** PROBLEMAS NA SISTEMAS' */
                _.Display($"*** PROBLEMAS NA SISTEMAS");

                /*" -967- MOVE 9 TO RETURN-CODE */
                _.Move(9, RETURN_CODE);

                /*" -968- STOP RUN */

                throw new GoBack();   // => STOP RUN.

                /*" -979- END-IF. */
            }


            /*" -981- PERFORM R0900-00-DECLARE-RELATORIOS. */

            R0900_00_DECLARE_RELATORIOS_SECTION();

            /*" -983- PERFORM R0910-00-FETCH-RELATORIOS. */

            R0910_00_FETCH_RELATORIOS_SECTION();

            /*" -984- IF WFIM-RELATORIOS EQUAL 'S' */

            if (WORK_AREA.WFIM_RELATORIOS == "S")
            {

                /*" -985- PERFORM R9800-00-ENCERRA-SEM-SOLIC */

                R9800_00_ENCERRA_SEM_SOLIC_SECTION();

                /*" -987- MOVE ZEROS TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -989- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -990- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WFIM-RELATORIOS EQUAL 'S' . */

            while (!(WORK_AREA.WFIM_RELATORIOS == "S"))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -997- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -1003- DISPLAY ' ' */
            _.Display($" ");

            /*" -1003- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1005- DISPLAY ' PROCESSO EXECUTAR COM COMMIT           ' */
            _.Display($" PROCESSO EXECUTAR COM COMMIT           ");

            /*" -1007- DISPLAY ' PROCESSO EXECUTAR COM COMMIT           ' */
            _.Display($" PROCESSO EXECUTAR COM COMMIT           ");

            /*" -1008- DISPLAY ' ' */
            _.Display($" ");

            /*" -1009- DISPLAY '------------------------------------------' */
            _.Display($"------------------------------------------");

            /*" -1010- DISPLAY '           ESTATISTICA DO VA0469B         ' */
            _.Display($"           ESTATISTICA DO VA0469B         ");

            /*" -1011- DISPLAY '------------------------------------------' */
            _.Display($"------------------------------------------");

            /*" -1012- DISPLAY 'LIDOS RELATORIOS...... ' AC-LIDOS. */
            _.Display($"LIDOS RELATORIOS...... {ACUMULADORES.AC_LIDOS}");

            /*" -1013- DISPLAY 'GRAVADOS ARQCHEQ...... ' AC-GRAVA. */
            _.Display($"GRAVADOS ARQCHEQ...... {ACUMULADORES.AC_GRAVA}");

            /*" -1014- DISPLAY 'INSERIDOS HISLANCT.... ' AC-I-HISLANCT */
            _.Display($"INSERIDOS HISLANCT.... {ACUMULADORES.AC_I_HISLANCT}");

            /*" -1015- DISPLAY 'INSERIDOS HISCONPA.... ' AC-I-HISCONPA */
            _.Display($"INSERIDOS HISCONPA.... {ACUMULADORES.AC_I_HISCONPA}");

            /*" -1016- DISPLAY 'INSERIDOS RELATORI.... ' AC-I-RELATORI */
            _.Display($"INSERIDOS RELATORI.... {ACUMULADORES.AC_I_RELATORI}");

            /*" -1017- DISPLAY 'INSERIDOS MOVDEBCE.... ' AC-I-MOVDEBCE */
            _.Display($"INSERIDOS MOVDEBCE.... {ACUMULADORES.AC_I_MOVDEBCE}");

            /*" -1018- DISPLAY 'INSERIDOS EVENTO 9021. ' AC-I-MOVDEB-EV9021 */
            _.Display($"INSERIDOS EVENTO 9021. {ACUMULADORES.AC_I_MOVDEB_EV9021}");

            /*" -1019- DISPLAY 'INSERIDOS EVENTO 9022. ' AC-I-MOVDEB-EV9022 */
            _.Display($"INSERIDOS EVENTO 9022. {ACUMULADORES.AC_I_MOVDEB_EV9022}");

            /*" -1020- DISPLAY 'INS. ESTORNO CORRECAO. ' AC-I-MOVDEB-CORRECAO */
            _.Display($"INS. ESTORNO CORRECAO. {ACUMULADORES.AC_I_MOVDEB_CORRECAO}");

            /*" -1021- DISPLAY 'ALTERADOS HISLANCT.... ' AC-U-HISLANCT */
            _.Display($"ALTERADOS HISLANCT.... {ACUMULADORES.AC_U_HISLANCT}");

            /*" -1022- DISPLAY 'ALTERADOS MOVDEBCE.... ' AC-U-MOVDEBCE */
            _.Display($"ALTERADOS MOVDEBCE.... {ACUMULADORES.AC_U_MOVDEBCE}");

            /*" -1023- DISPLAY 'UPDT. ESTORNO CORRECAO ' AC-U-MOVDEB-CORRECAO */
            _.Display($"UPDT. ESTORNO CORRECAO {ACUMULADORES.AC_U_MOVDEB_CORRECAO}");

            /*" -1024- DISPLAY 'DESPREZADOS CARTAO.... ' AC-D-CARTAO-CREDITO */
            _.Display($"DESPREZADOS CARTAO.... {ACUMULADORES.AC_D_CARTAO_CREDITO}");

            /*" -1025- DISPLAY '------------------------------------------' */
            _.Display($"------------------------------------------");

            /*" -1026- DISPLAY '          VA0469B - TERMINO NORMAL        ' */
            _.Display($"          VA0469B - TERMINO NORMAL        ");

            /*" -1029- DISPLAY '------------------------------------------' */
            _.Display($"------------------------------------------");

            /*" -1031- CLOSE ARQCHEQ. */
            ARQCHEQ.Close();

            /*" -1031- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-SECTION */
        private void R0100_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -1039- MOVE 'R0100-00-SELECT-SISTEMAS' TO PARAGRAFO. */
            _.Move("R0100-00-SELECT-SISTEMAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1041- MOVE 'SELECT SEGUROS.SISTEMAS' TO COMANDO. */
            _.Move("SELECT SEGUROS.SISTEMAS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1048- PERFORM R0100_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -1051- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1052- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1053- DISPLAY 'VA0469B - SISTEMA VA NAO ESTA CADASTRADO' */
                    _.Display($"VA0469B - SISTEMA VA NAO ESTA CADASTRADO");

                    /*" -1054- MOVE 'S' TO WFIM-SISTEMAS */
                    _.Move("S", WORK_AREA.WFIM_SISTEMAS);

                    /*" -1055- GO TO R0100-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                    return;

                    /*" -1056- ELSE */
                }
                else
                {


                    /*" -1057- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1058- END-IF */
                }


                /*" -1060- END-IF */
            }


            /*" -1061- MOVE SISTEMAS-DATA-MOV-ABERTO (9:2) TO WS-DATA-AUX (1:2). */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2), WORK_AREA.WS_DATA_AUX, 1, 2);

            /*" -1062- MOVE SISTEMAS-DATA-MOV-ABERTO (6:2) TO WS-DATA-AUX (4:2). */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2), WORK_AREA.WS_DATA_AUX, 4, 2);

            /*" -1063- MOVE SISTEMAS-DATA-MOV-ABERTO (1:4) TO WS-DATA-AUX (7:4). */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4), WORK_AREA.WS_DATA_AUX, 7, 4);

            /*" -1064- MOVE '/' TO WS-DATA-AUX (3:1). */
            _.MoveAtPosition("/", WORK_AREA.WS_DATA_AUX, 3, 1);

            /*" -1066- MOVE '/' TO WS-DATA-AUX (6:1). */
            _.MoveAtPosition("/", WORK_AREA.WS_DATA_AUX, 6, 1);

            /*" -1067- MOVE V1SIST-DTHOJE (9:2) TO REG-CABEC-01-DATA (1:2) */
            _.MoveAtPosition(V1SIST_DTHOJE.Substring(9, 2), REG_CABEC_01.REG_CABEC_01_DATA, 1, 2);

            /*" -1068- MOVE V1SIST-DTHOJE (6:2) TO REG-CABEC-01-DATA (4:2) */
            _.MoveAtPosition(V1SIST_DTHOJE.Substring(6, 2), REG_CABEC_01.REG_CABEC_01_DATA, 4, 2);

            /*" -1069- MOVE V1SIST-DTHOJE (1:4) TO REG-CABEC-01-DATA (7:4) */
            _.MoveAtPosition(V1SIST_DTHOJE.Substring(1, 4), REG_CABEC_01.REG_CABEC_01_DATA, 7, 4);

            /*" -1076- MOVE '/' TO REG-CABEC-01-DATA(6:1) */
            _.MoveAtPosition("/", REG_CABEC_01.REG_CABEC_01_DATA, 6, 1);

            /*" -1076- MOVE '/' TO REG-CABEC-01-DATA(3:1) */
            _.MoveAtPosition("/", REG_CABEC_01.REG_CABEC_01_DATA, 3, 1);

            /*" -1077- MOVE SISTEMAS-DATA-MOV-ABERTO TO W04DTSQL. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WORK_AREA.W04DTSQL);

            /*" -1078- MOVE W04DDSQL TO SU1-DD1. */
            _.Move(WORK_AREA.W04DTSQL.W04DDSQL, WORK_AREA.PARM_PROSOMU1.SU1_DATA1.SU1_DD1);

            /*" -1079- MOVE W04MMSQL TO SU1-MM1. */
            _.Move(WORK_AREA.W04DTSQL.W04MMSQL, WORK_AREA.PARM_PROSOMU1.SU1_DATA1.SU1_MM1);

            /*" -1080- MOVE W04AASQL TO SU1-AA1. */
            _.Move(WORK_AREA.W04DTSQL.W04AASQL, WORK_AREA.PARM_PROSOMU1.SU1_DATA1.SU1_AA1);

            /*" -1083- MOVE ZEROES TO SU1-DATA2. */
            _.Move(0, WORK_AREA.PARM_PROSOMU1.SU1_DATA2);

            /*" -1085- PERFORM R0200-00-DIAS-UTEIS THRU R0200-99-SAIDA 2 TIMES. */

            R0200_00_DIAS_UTEIS_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/


            /*" -1086- MOVE SU1-DD2 TO W04DDSQL. */
            _.Move(WORK_AREA.PARM_PROSOMU1.SU1_DATA2.SU1_DD2, WORK_AREA.W04DTSQL.W04DDSQL);

            /*" -1087- MOVE SU1-MM2 TO W04MMSQL. */
            _.Move(WORK_AREA.PARM_PROSOMU1.SU1_DATA2.SU1_MM2, WORK_AREA.W04DTSQL.W04MMSQL);

            /*" -1089- MOVE SU1-AA2 TO W04AASQL. */
            _.Move(WORK_AREA.PARM_PROSOMU1.SU1_DATA2.SU1_AA2, WORK_AREA.W04DTSQL.W04AASQL);

            /*" -1090- MOVE W04DTSQL TO DATA-SQL. */
            _.Move(WORK_AREA.W04DTSQL, WORK_AREA.DATA_SQL);

            /*" -1091- MOVE DATA-SQL TO WHOST-DATA-CRED. */
            _.Move(WORK_AREA.DATA_SQL, WHOST_DATA_CRED);

            /*" -1091- MOVE WHOST-DATA-CRED TO DATA-FIM. */
            _.Move(WHOST_DATA_CRED, WORK_AREA.DATA_FIM);

        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -1048- EXEC SQL SELECT DATA_MOV_ABERTO, CURRENT DATE INTO :SISTEMAS-DATA-MOV-ABERTO, :V1SIST-DTHOJE FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VA' END-EXEC. */

            var r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 = new R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.V1SIST_DTHOJE, V1SIST_DTHOJE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-DIAS-UTEIS-SECTION */
        private void R0200_00_DIAS_UTEIS_SECTION()
        {
            /*" -1102- MOVE 'R0200-00-DIAS-UTEIS' TO PARAGRAFO. */
            _.Move("R0200-00-DIAS-UTEIS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1103- MOVE +1 TO SU1-NRDIAS. */
            _.Move(+1, WORK_AREA.PARM_PROSOMU1.SU1_NRDIAS);

            /*" -1105- CALL 'PROSOCU1' USING PARM-PROSOMU1. */
            _.Call("PROSOCU1", WORK_AREA.PARM_PROSOMU1);

            /*" -1105- MOVE SU1-DATA2 TO SU1-DATA1. */
            _.Move(WORK_AREA.PARM_PROSOMU1.SU1_DATA2, WORK_AREA.PARM_PROSOMU1.SU1_DATA1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-RELATORIOS-SECTION */
        private void R0900_00_DECLARE_RELATORIOS_SECTION()
        {
            /*" -1115- MOVE 'R0900-00-DECLARE-RELATORIOS' TO PARAGRAFO. */
            _.Move("R0900-00-DECLARE-RELATORIOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1117- MOVE 'DECLARE TRELAT' TO COMANDO. */
            _.Move("DECLARE TRELAT", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1142- PERFORM R0900_00_DECLARE_RELATORIOS_DB_DECLARE_1 */

            R0900_00_DECLARE_RELATORIOS_DB_DECLARE_1();

            /*" -1144- PERFORM R0900_00_DECLARE_RELATORIOS_DB_OPEN_1 */

            R0900_00_DECLARE_RELATORIOS_DB_OPEN_1();

            /*" -1147- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1148- DISPLAY 'VA0469B - PROBLEMAS NO OPEN   DA RELATORIOS' */
                _.Display($"VA0469B - PROBLEMAS NO OPEN   DA RELATORIOS");

                /*" -1148- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-RELATORIOS-DB-DECLARE-1 */
        public void R0900_00_DECLARE_RELATORIOS_DB_DECLARE_1()
        {
            /*" -1142- EXEC SQL DECLARE TRELAT CURSOR FOR SELECT NUM_APOLICE, NUM_ENDOSSO, COD_SUBGRUPO, COD_USUARIO, COD_OPERACAO, NUM_CERTIFICADO, NUM_PARCELA, SIT_REGISTRO, NUM_ORDEM, QUANTIDADE, MES_REFERENCIA, ANO_REFERENCIA, ORGAO_EMISSOR, NUM_SINISTRO, NUM_COPIAS, DATA_SOLICITACAO, NUM_APOL_LIDER FROM SEGUROS.RELATORIOS WHERE COD_RELATORIO = 'VA0469B' AND SIT_REGISTRO = '0' ORDER BY NUM_APOLICE , COD_SUBGRUPO END-EXEC. */
            TRELAT = new VA0469B_TRELAT(false);
            string GetQuery_TRELAT()
            {
                var query = @$"SELECT NUM_APOLICE
							, 
							NUM_ENDOSSO
							, 
							COD_SUBGRUPO
							, 
							COD_USUARIO
							, 
							COD_OPERACAO
							, 
							NUM_CERTIFICADO
							, 
							NUM_PARCELA
							, 
							SIT_REGISTRO
							, 
							NUM_ORDEM
							, 
							QUANTIDADE
							, 
							MES_REFERENCIA
							, 
							ANO_REFERENCIA
							, 
							ORGAO_EMISSOR
							, 
							NUM_SINISTRO
							, 
							NUM_COPIAS
							, 
							DATA_SOLICITACAO
							, 
							NUM_APOL_LIDER 
							FROM SEGUROS.RELATORIOS 
							WHERE COD_RELATORIO = 'VA0469B' 
							AND SIT_REGISTRO = '0' 
							ORDER BY NUM_APOLICE
							, 
							COD_SUBGRUPO";

                return query;
            }
            TRELAT.GetQueryEvent += GetQuery_TRELAT;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-RELATORIOS-DB-OPEN-1 */
        public void R0900_00_DECLARE_RELATORIOS_DB_OPEN_1()
        {
            /*" -1144- EXEC SQL OPEN TRELAT END-EXEC. */

            TRELAT.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-RELATORIOS-SECTION */
        private void R0910_00_FETCH_RELATORIOS_SECTION()
        {
            /*" -1158- MOVE 'R0910-00-FETCH-RELATORIOS' TO PARAGRAFO. */
            _.Move("R0910-00-FETCH-RELATORIOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1160- MOVE 'FETCH TRELAT' TO COMANDO. */
            _.Move("FETCH TRELAT", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1179- PERFORM R0910_00_FETCH_RELATORIOS_DB_FETCH_1 */

            R0910_00_FETCH_RELATORIOS_DB_FETCH_1();

            /*" -1182- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1183- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1185- MOVE 'S' TO WFIM-RELATORIOS */
                    _.Move("S", WORK_AREA.WFIM_RELATORIOS);

                    /*" -1185- PERFORM R0910_00_FETCH_RELATORIOS_DB_CLOSE_1 */

                    R0910_00_FETCH_RELATORIOS_DB_CLOSE_1();

                    /*" -1187- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -1188- DISPLAY 'VA0469B - PROBLEMAS NO CLOSE  DA RELATORIOS' */
                        _.Display($"VA0469B - PROBLEMAS NO CLOSE  DA RELATORIOS");

                        /*" -1189- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -1190- END-IF */
                    }


                    /*" -1191- GO TO R0910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                    return;

                    /*" -1192- ELSE */
                }
                else
                {


                    /*" -1193- DISPLAY 'VA0469B - PROBLEMAS NO FETCH  DA RELATORIOS' */
                    _.Display($"VA0469B - PROBLEMAS NO FETCH  DA RELATORIOS");

                    /*" -1195- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1197- ADD 1 TO AC-LIDOS. */
            ACUMULADORES.AC_LIDOS.Value = ACUMULADORES.AC_LIDOS + 1;

            /*" -1200- MOVE RELATORI-NUM-APOLICE TO APOLICE-ATU. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE, WORK_AREA.APOLICE_ATU);

            /*" -1201- MOVE RELATORI-COD-SUBGRUPO TO SUBGRUPO-ATU. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO, WORK_AREA.SUBGRUPO_ATU);

        }

        [StopWatch]
        /*" R0910-00-FETCH-RELATORIOS-DB-FETCH-1 */
        public void R0910_00_FETCH_RELATORIOS_DB_FETCH_1()
        {
            /*" -1179- EXEC SQL FETCH TRELAT INTO :RELATORI-NUM-APOLICE, :RELATORI-NUM-ENDOSSO, :RELATORI-COD-SUBGRUPO, :RELATORI-COD-USUARIO, :RELATORI-COD-OPERACAO, :RELATORI-NUM-CERTIFICADO, :RELATORI-NUM-PARCELA, :RELATORI-SIT-REGISTRO, :RELATORI-NUM-ORDEM, :RELATORI-QUANTIDADE, :RELATORI-MES-REFERENCIA, :RELATORI-ANO-REFERENCIA, :RELATORI-ORGAO-EMISSOR, :RELATORI-NUM-SINISTRO, :RELATORI-NUM-COPIAS, :RELATORI-DATA-SOLICITACAO, :RELATORI-NUM-APOL-LIDER END-EXEC. */

            if (TRELAT.Fetch())
            {
                _.Move(TRELAT.RELATORI_NUM_APOLICE, RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE);
                _.Move(TRELAT.RELATORI_NUM_ENDOSSO, RELATORI.DCLRELATORIOS.RELATORI_NUM_ENDOSSO);
                _.Move(TRELAT.RELATORI_COD_SUBGRUPO, RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO);
                _.Move(TRELAT.RELATORI_COD_USUARIO, RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO);
                _.Move(TRELAT.RELATORI_COD_OPERACAO, RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO);
                _.Move(TRELAT.RELATORI_NUM_CERTIFICADO, RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO);
                _.Move(TRELAT.RELATORI_NUM_PARCELA, RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA);
                _.Move(TRELAT.RELATORI_SIT_REGISTRO, RELATORI.DCLRELATORIOS.RELATORI_SIT_REGISTRO);
                _.Move(TRELAT.RELATORI_NUM_ORDEM, RELATORI.DCLRELATORIOS.RELATORI_NUM_ORDEM);
                _.Move(TRELAT.RELATORI_QUANTIDADE, RELATORI.DCLRELATORIOS.RELATORI_QUANTIDADE);
                _.Move(TRELAT.RELATORI_MES_REFERENCIA, RELATORI.DCLRELATORIOS.RELATORI_MES_REFERENCIA);
                _.Move(TRELAT.RELATORI_ANO_REFERENCIA, RELATORI.DCLRELATORIOS.RELATORI_ANO_REFERENCIA);
                _.Move(TRELAT.RELATORI_ORGAO_EMISSOR, RELATORI.DCLRELATORIOS.RELATORI_ORGAO_EMISSOR);
                _.Move(TRELAT.RELATORI_NUM_SINISTRO, RELATORI.DCLRELATORIOS.RELATORI_NUM_SINISTRO);
                _.Move(TRELAT.RELATORI_NUM_COPIAS, RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS);
                _.Move(TRELAT.RELATORI_DATA_SOLICITACAO, RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO);
                _.Move(TRELAT.RELATORI_NUM_APOL_LIDER, RELATORI.DCLRELATORIOS.RELATORI_NUM_APOL_LIDER);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-RELATORIOS-DB-CLOSE-1 */
        public void R0910_00_FETCH_RELATORIOS_DB_CLOSE_1()
        {
            /*" -1185- EXEC SQL CLOSE TRELAT END-EXEC */

            TRELAT.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -1211- MOVE 'R1000-00-PROCESSA-REGISTRO' TO PARAGRAFO. */
            _.Move("R1000-00-PROCESSA-REGISTRO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1212- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1213- DISPLAY 'CERTIFICADO.......   ' RELATORI-NUM-CERTIFICADO */
            _.Display($"CERTIFICADO.......   {RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO}");

            /*" -1215- DISPLAY 'RELATORI-NUM-PARCELA ' RELATORI-NUM-PARCELA */
            _.Display($"RELATORI-NUM-PARCELA {RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA}");

            /*" -1217- PERFORM R1005-00-LER-HISTLANCTA */

            R1005_00_LER_HISTLANCTA_SECTION();

            /*" -1219- IF SQLCODE EQUAL ZEROS AND RELATORI-NUM-COPIAS NOT EQUAL 7 */

            if (DB.SQLCODE == 00 && RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS != 7)
            {

                /*" -1220- MOVE 'D' TO RELATORI-SIT-REGISTRO */
                _.Move("D", RELATORI.DCLRELATORIOS.RELATORI_SIT_REGISTRO);

                /*" -1221- PERFORM R1010-00-UPDATE-RELATORI */

                R1010_00_UPDATE_RELATORI_SECTION();

                /*" -1223- DISPLAY 'JA EXISTE RESSARCIMENTO. CERTIF: ' RELATORI-NUM-CERTIFICADO ' PARCEL: ' RELATORI-NUM-PARCELA */

                $"JA EXISTE RESSARCIMENTO. CERTIF: {RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO} PARCEL: {RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA}"
                .Display();

                /*" -1224- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -1226- END-IF */
            }


            /*" -1227- IF RELATORI-QUANTIDADE EQUAL 332 */

            if (RELATORI.DCLRELATORIOS.RELATORI_QUANTIDADE == 332)
            {

                /*" -1229- DISPLAY 'IGNORADO: ' RELATORI-NUM-CERTIFICADO ' / ' RELATORI-NUM-PARCELA */

                $"IGNORADO: {RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO} / {RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA}"
                .Display();

                /*" -1230- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -1232- END-IF */
            }


            /*" -1235- INITIALIZE WS-RETORNO-SAP DCLCOBER-HIST-VIDAZUL */
            _.Initialize(
                WORK_AREA.WS_RETORNO_SAP
                , COBHISVI.DCLCOBER_HIST_VIDAZUL
            );

            /*" -1237- PERFORM R1140-00-SELECT-PROPOFID. */

            R1140_00_SELECT_PROPOFID_SECTION();

            /*" -1239- PERFORM R1150-00-SELECT-OPCAOPAGVA. */

            R1150_00_SELECT_OPCAOPAGVA_SECTION();

            /*" -1240- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1241- ADD 1 TO AC-R-OPCPAGVI */
                ACUMULADORES.AC_R_OPCPAGVI.Value = ACUMULADORES.AC_R_OPCPAGVI + 1;

                /*" -1242- MOVE 'O' TO RELATORI-SIT-REGISTRO */
                _.Move("O", RELATORI.DCLRELATORIOS.RELATORI_SIT_REGISTRO);

                /*" -1243- PERFORM R1010-00-UPDATE-RELATORI */

                R1010_00_UPDATE_RELATORI_SECTION();

                /*" -1244- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -1246- END-IF */
            }


            /*" -1247- INITIALIZE DCLGE-RETORNO-CA-CIELO. */
            _.Initialize(
                GE408.DCLGE_RETORNO_CA_CIELO
            );

            /*" -1251- IF (RELATORI-NUM-PARCELA EQUAL 1 AND (PROPOFID-OPCAOPAG EQUAL '3' )) OR (RELATORI-NUM-PARCELA > 1 AND OPCPAGVI-OPCAO-PAGAMENTO EQUAL '5' ) */

            if ((RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA == 1 && (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAOPAG == "3")) || (RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA > 1 && OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO == "5"))
            {

                /*" -1252- IF RELATORI-NUM-COPIAS EQUAL 6 OR 8 */

                if (RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS.In("6", "8"))
                {

                    /*" -1253- PERFORM R3505-00-SELECT-GE408-SIT0 */

                    R3505_00_SELECT_GE408_SIT0_SECTION();

                    /*" -1254- ELSE */
                }
                else
                {


                    /*" -1255- PERFORM R3405-00-SELECT-GE408 */

                    R3405_00_SELECT_GE408_SECTION();

                    /*" -1256- END-IF */
                }


                /*" -1257- IF WS-NAO-RETORNOU-SAP */

                if (WORK_AREA.WS_RETORNO_SAP["WS_NAO_RETORNOU_SAP"])
                {

                    /*" -1258- DISPLAY 'CARTAO CIELO - RETORNO DO SAP NAO ENCONTRADO' */
                    _.Display($"CARTAO CIELO - RETORNO DO SAP NAO ENCONTRADO");

                    /*" -1259- DISPLAY 'NUM_CERTIFICADO = ' RELATORI-NUM-CERTIFICADO */
                    _.Display($"NUM_CERTIFICADO = {RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO}");

                    /*" -1260- DISPLAY 'NUM-PARCELA = ' RELATORI-NUM-PARCELA */
                    _.Display($"NUM-PARCELA = {RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA}");

                    /*" -1261- ADD 1 TO AC-D-CARTAO-CREDITO */
                    ACUMULADORES.AC_D_CARTAO_CREDITO.Value = ACUMULADORES.AC_D_CARTAO_CREDITO + 1;

                    /*" -1262- GO TO R1000-10-NEXT */

                    R1000_10_NEXT(); //GOTO
                    return;

                    /*" -1263- END-IF */
                }


                /*" -1264- ELSE */
            }
            else
            {


                /*" -1265- PERFORM R1110-00-SELECT-HISLANCT */

                R1110_00_SELECT_HISLANCT_SECTION();

                /*" -1266- IF WQTD-QTD GREATER ZEROS */

                if (WQTD_QTD > 00)
                {

                    /*" -1267- GO TO R1000-10-NEXT */

                    R1000_10_NEXT(); //GOTO
                    return;

                    /*" -1268- END-IF */
                }


                /*" -1277- END-IF */
            }


            /*" -1279- PERFORM R1050-00-SELECT-PROPOSTAVA. */

            R1050_00_SELECT_PROPOSTAVA_SECTION();

            /*" -1280- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1284- DISPLAY 'DESPREZADO PROPOVA S  ---->' ' ' RELATORI-NUM-CERTIFICADO ' ' RELATORI-NUM-PARCELA ' ' PROPOVA-DATA-QUITACAO */

                $"DESPREZADO PROPOVA S  ----> {RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO} {RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA} {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO}"
                .Display();

                /*" -1285- ADD 1 TO AC-R-PROPOVA */
                ACUMULADORES.AC_R_PROPOVA.Value = ACUMULADORES.AC_R_PROPOVA + 1;

                /*" -1286- MOVE 'P' TO RELATORI-SIT-REGISTRO */
                _.Move("P", RELATORI.DCLRELATORIOS.RELATORI_SIT_REGISTRO);

                /*" -1287- PERFORM R1010-00-UPDATE-RELATORI */

                R1010_00_UPDATE_RELATORI_SECTION();

                /*" -1288- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -1290- END-IF. */
            }


            /*" -1292- PERFORM R1130-00-SELECT-PARCELVA. */

            R1130_00_SELECT_PARCELVA_SECTION();

            /*" -1293- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1294- ADD 1 TO AC-R-PARCEVID */
                ACUMULADORES.AC_R_PARCEVID.Value = ACUMULADORES.AC_R_PARCEVID + 1;

                /*" -1295- MOVE 'A' TO RELATORI-SIT-REGISTRO */
                _.Move("A", RELATORI.DCLRELATORIOS.RELATORI_SIT_REGISTRO);

                /*" -1296- PERFORM R1010-00-UPDATE-RELATORI */

                R1010_00_UPDATE_RELATORI_SECTION();

                /*" -1297- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -1299- END-IF. */
            }


            /*" -1301- PERFORM R1100-00-SELECT-HISTCOBVA. */

            R1100_00_SELECT_HISTCOBVA_SECTION();

            /*" -1302- IF SQLCODE NOT EQUAL ZEROS AND -811 */

            if (!DB.SQLCODE.In("00", "-811"))
            {

                /*" -1303- ADD 1 TO AC-R-HISCOBPA */
                ACUMULADORES.AC_R_HISCOBPA.Value = ACUMULADORES.AC_R_HISCOBPA + 1;

                /*" -1304- MOVE 'H' TO RELATORI-SIT-REGISTRO */
                _.Move("H", RELATORI.DCLRELATORIOS.RELATORI_SIT_REGISTRO);

                /*" -1305- PERFORM R1010-00-UPDATE-RELATORI */

                R1010_00_UPDATE_RELATORI_SECTION();

                /*" -1306- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -1308- END-IF. */
            }


            /*" -1312- PERFORM R2600-00-SELECT-HISTCONTABILVA. */

            R2600_00_SELECT_HISTCONTABILVA_SECTION();

            /*" -1313- IF RELATORI-NUM-ORDEM GREATER ZEROS */

            if (RELATORI.DCLRELATORIOS.RELATORI_NUM_ORDEM > 00)
            {

                /*" -1314- MOVE RELATORI-NUM-ORDEM TO WHOST-PREMIO */
                _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_ORDEM, WHOST_PREMIO);

                /*" -1316- DIVIDE WHOST-PREMIO BY 100 GIVING WHOST-PREMIO */
                _.Divide(WHOST_PREMIO, 100, WHOST_PREMIO);

                /*" -1318- MOVE WHOST-PREMIO TO PARCEVID-PREMIO-VG COBHISVI-PRM-TOTAL */
                _.Move(WHOST_PREMIO, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_VG, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_PRM_TOTAL);

                /*" -1320- MOVE ZEROS TO PARCEVID-PREMIO-AP */
                _.Move(0, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_AP);

                /*" -1323- IF (RELATORI-NUM-COPIAS EQUAL 6 OR 8) AND (GE408-VLR-COBRANCA > ZEROS) AND (GE408-VLR-COBRANCA < PARCEVID-PREMIO-VG) */

                if ((RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS.In("6", "8")) && (GE408.DCLGE_RETORNO_CA_CIELO.GE408_VLR_COBRANCA > 00) && (GE408.DCLGE_RETORNO_CA_CIELO.GE408_VLR_COBRANCA < PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_VG))
                {

                    /*" -1324- DISPLAY 'VALOR DA RELATORIO > VLR-COBRADO ' */
                    _.Display($"VALOR DA RELATORIO > VLR-COBRADO ");

                    /*" -1325- DISPLAY 'VLR-RELAT   > ' COBHISVI-PRM-TOTAL */
                    _.Display($"VLR-RELAT   > {COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_PRM_TOTAL}");

                    /*" -1326- DISPLAY 'VLR-COBRADO > ' GE408-VLR-COBRANCA */
                    _.Display($"VLR-COBRADO > {GE408.DCLGE_RETORNO_CA_CIELO.GE408_VLR_COBRANCA}");

                    /*" -1328- MOVE GE408-VLR-COBRANCA TO PARCEVID-PREMIO-VG COBHISVI-PRM-TOTAL */
                    _.Move(GE408.DCLGE_RETORNO_CA_CIELO.GE408_VLR_COBRANCA, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_VG, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_PRM_TOTAL);

                    /*" -1329- END-IF */
                }


                /*" -1331- END-IF. */
            }


            /*" -1344- MOVE ZEROES TO IND1 IND2 IND4 AA-ATU AA-INI MM-INI AA-MOE WS-IGPM-ACUM WPRM-TOTAL WPRM-VG WPRM-AP. */
            _.Move(0, WORK_AREA.IND1, WORK_AREA.IND2, WORK_AREA.IND4, WORK_AREA.AA_ATU, WORK_AREA.AA_INI, WORK_AREA.MM_INI, WORK_AREA.AA_MOE, WORK_AREA.WS_IGPM_ACUM, WORK_AREA.WPRM_TOTAL, WORK_AREA.WPRM_VG, WORK_AREA.WPRM_AP);

            /*" -1345- INITIALIZE LK-VG011-E-TRACE LK-VG011-E-COD-USUARIO LK-VG011-E-NOM-PROGRAMA LK-VG011-E-TIPO-ACAO LK-VG011-E-COD-PRODUTO LK-VG011-E-DTA-INI-CALCULO LK-VG011-E-DTA-FIM-CALCULO LK-VG011-E-DTA-DECLINIO LK-VG011-E-VL-ORIGINAL LK-VG011-E-NUM-APOLICE LK-VG011-E-COD-SUBGRUPO LK-VG011-E-QTD-DIA-PGMNTO LK-VG011-S-COD-MOEDA LK-VG011-S-PC-INDICE LK-VG011-S-VL-JUROS LK-VG011-S-VL-MULTA LK-VG011-S-VL-CORRIGIDO LK-VG011-S-DTA-FIM-PGMNTO LK-VG011-IND-ERRO LK-VG011-MSG-ERRO LK-VG011-NOM-TABELA LK-VG011-SQLCODE LK-VG011-SQLERRMC */
            _.Initialize(
                SPVG011W.LK_VG011_E_TRACE
                , SPVG011W.LK_VG011_E_COD_USUARIO
                , SPVG011W.LK_VG011_E_NOM_PROGRAMA
                , SPVG011W.LK_VG011_E_TIPO_ACAO
                , SPVG011W.LK_VG011_E_COD_PRODUTO
                , SPVG011W.LK_VG011_E_DTA_INI_CALCULO
                , SPVG011W.LK_VG011_E_DTA_FIM_CALCULO
                , SPVG011W.LK_VG011_E_DTA_DECLINIO
                , SPVG011W.LK_VG011_E_VL_ORIGINAL
                , SPVG011W.LK_VG011_E_NUM_APOLICE
                , SPVG011W.LK_VG011_E_COD_SUBGRUPO
                , SPVG011W.LK_VG011_E_QTD_DIA_PGMNTO
                , SPVG011W.LK_VG011_S_COD_MOEDA
                , SPVG011W.LK_VG011_S_PC_INDICE
                , SPVG011W.LK_VG011_S_VL_JUROS
                , SPVG011W.LK_VG011_S_VL_MULTA
                , SPVG011W.LK_VG011_S_VL_CORRIGIDO
                , SPVG011W.LK_VG011_S_DTA_FIM_PGMNTO
                , SPVG011W.LK_VG011_IND_ERRO
                , SPVG011W.LK_VG011_MSG_ERRO
                , SPVG011W.LK_VG011_NOM_TABELA
                , SPVG011W.LK_VG011_SQLCODE
                , SPVG011W.LK_VG011_SQLERRMC
            );

            /*" -1347- MOVE 'N' TO WS-VALOR-COM-CORR */
            _.Move("N", WS_VALOR_COM_CORR);

            /*" -1349- MOVE '0001-01-01' TO DATA-INI-DEC */
            _.Move("0001-01-01", WORK_AREA.DATA_INI_DEC);

            /*" -1350- IF PROPOVA-SIT-REGISTRO = '4' */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO == "4")
            {

                /*" -1352- PERFORM R2020-00-VER-CANCELAMENTO */

                R2020_00_VER_CANCELAMENTO_SECTION();

                /*" -1353- IF SQLCODE EQUAL +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -1356- MOVE PARCEVID-DATA-VENCIMENTO TO DATA-INI WDATA-INI DATA-FIM */
                    _.Move(PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_DATA_VENCIMENTO, WORK_AREA.DATA_INI, WORK_AREA.WDATA_INI, WORK_AREA.DATA_FIM);

                    /*" -1357- ELSE */
                }
                else
                {


                    /*" -1359- MOVE MOVIMVGA-DATA-OPERACAO TO DATA-INI WDATA-INI */
                    _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_OPERACAO, WORK_AREA.DATA_INI, WORK_AREA.WDATA_INI);

                    /*" -1360- MOVE SISTEMAS-DATA-MOV-ABERTO TO DATA-FIM */
                    _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WORK_AREA.DATA_FIM);

                    /*" -1361- END-IF */
                }


                /*" -1362- ELSE */
            }
            else
            {


                /*" -1363- IF PROPOVA-SIT-REGISTRO = '2' */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO == "2")
                {

                    /*" -1364- MOVE SISTEMAS-DATA-MOV-ABERTO TO DATA-FIM */
                    _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WORK_AREA.DATA_FIM);

                    /*" -1366- MOVE PROPOVA-DATA-QUITACAO TO DATA-INI WDATA-INI */
                    _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO, WORK_AREA.DATA_INI, WORK_AREA.WDATA_INI);

                    /*" -1367- IF WDIAS-DECLINIO GREATER 10 */

                    if (WDIAS_DECLINIO > 10)
                    {

                        /*" -1368- MOVE WDTA-DECLINIO TO DATA-INI-DEC */
                        _.Move(WDTA_DECLINIO, WORK_AREA.DATA_INI_DEC);

                        /*" -1370- DISPLAY 'CERTIFICADO ' RELATORI-NUM-CERTIFICADO ' ' 'DATA DECLINIO ' WDATA-DECLINIO */

                        $"CERTIFICADO {RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO} DATA DECLINIO {WDATA_DECLINIO}"
                        .Display();

                        /*" -1371- END-IF */
                    }


                    /*" -1372- ELSE */
                }
                else
                {


                    /*" -1375- MOVE PARCEVID-DATA-VENCIMENTO TO DATA-INI WDATA-INI DATA-FIM */
                    _.Move(PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_DATA_VENCIMENTO, WORK_AREA.DATA_INI, WORK_AREA.WDATA_INI, WORK_AREA.DATA_FIM);

                    /*" -1376- END-IF */
                }


                /*" -1378- END-IF */
            }


            /*" -1382- DISPLAY 'DATA-INI ' DATA-INI ' DATA-FIM ' DATA-FIM ' SIT-REGISTRO ' PROPOVA-SIT-REGISTRO */

            $"DATA-INI {WORK_AREA.DATA_INI} DATA-FIM {WORK_AREA.DATA_FIM} SIT-REGISTRO {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO}"
            .Display();

            /*" -1384- IF RELATORI-NUM-COPIAS EQUAL 7 AND DATA-INI EQUAL DATA-FIM */

            if (RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS == 7 && WORK_AREA.DATA_INI == WORK_AREA.DATA_FIM)
            {

                /*" -1387- DISPLAY 'ERRO - PGMNTO CORRECAO COM DT-INI = DT-FIM ' ' - CERTIFICADO >> ' RELATORI-NUM-CERTIFICADO ' NUM-COPIAS >> ' RELATORI-NUM-COPIAS */

                $"ERRO - PGMNTO CORRECAO COM DT-INI = DT-FIM  - CERTIFICADO >> {RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO} NUM-COPIAS >> {RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS}"
                .Display();

                /*" -1388- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1390- END-IF */
            }


            /*" -1393- IF RELATORI-NUM-PARCELA EQUAL 1 OR RELATORI-NUM-COPIAS EQUAL ZEROS */

            if (RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA == 1 || RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS == 00)
            {

                /*" -1395- IF PROPOFID-OPCAOPAG EQUAL '3' AND RELATORI-NUM-COPIAS EQUAL 5 */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAOPAG == "3" && RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS == 5)
                {

                    /*" -1396- MOVE COBHISVI-PRM-TOTAL TO WPRM-TOTAL */
                    _.Move(COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_PRM_TOTAL, WORK_AREA.WPRM_TOTAL);

                    /*" -1398- MOVE WPRM-TOTAL TO WHOST-NEW-PRM */
                    _.Move(WORK_AREA.WPRM_TOTAL, WHOST_NEW_PRM);

                    /*" -1399- MOVE PARCEVID-PREMIO-VG TO WPRM-VG */
                    _.Move(PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_VG, WORK_AREA.WPRM_VG);

                    /*" -1400- MOVE WPRM-VG TO WHOST-PRM-VG */
                    _.Move(WORK_AREA.WPRM_VG, WHOST_PRM_VG);

                    /*" -1401- MOVE PARCEVID-PREMIO-AP TO WPRM-AP */
                    _.Move(PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_AP, WORK_AREA.WPRM_AP);

                    /*" -1402- MOVE WPRM-AP TO WHOST-PRM-AP */
                    _.Move(WORK_AREA.WPRM_AP, WHOST_PRM_AP);

                    /*" -1404- ELSE */
                }
                else
                {


                    /*" -1409- IF ((RELATORI-NUM-COPIAS EQUAL 0) AND (DATA-INI NOT EQUAL DATA-FIM)) OR ((RELATORI-NUM-COPIAS EQUAL 6 OR 7) AND (DATA-INI NOT EQUAL DATA-FIM) AND (WQTD-HIST-CONT > ZEROS )) */

                    if (((RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS == 0) && (WORK_AREA.DATA_INI != WORK_AREA.DATA_FIM)) || ((RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS.In("6", "7")) && (WORK_AREA.DATA_INI != WORK_AREA.DATA_FIM) && (WQTD_HIST_CONT > 00)))
                    {

                        /*" -1411- PERFORM R6000-00-CALCULA-VL-ATUALIZADO */

                        R6000_00_CALCULA_VL_ATUALIZADO_SECTION();

                        /*" -1412- IF LK-VG011-E-VL-ORIGINAL < LK-VG011-S-VL-CORRIGIDO */

                        if (SPVG011W.LK_VG011_E_VL_ORIGINAL < SPVG011W.LK_VG011_S_VL_CORRIGIDO)
                        {

                            /*" -1413- MOVE 'S' TO WS-VALOR-COM-CORR */
                            _.Move("S", WS_VALOR_COM_CORR);

                            /*" -1414- ELSE */
                        }
                        else
                        {


                            /*" -1415- MOVE 'N' TO WS-VALOR-COM-CORR */
                            _.Move("N", WS_VALOR_COM_CORR);

                            /*" -1417- END-IF */
                        }


                        /*" -1420- MOVE LK-VG011-S-VL-CORRIGIDO TO WPRM-TOTAL WHOST-NEW-PRM */
                        _.Move(SPVG011W.LK_VG011_S_VL_CORRIGIDO, WORK_AREA.WPRM_TOTAL, WHOST_NEW_PRM);

                        /*" -1422- MOVE LK-VG011-S-VL-JUROS TO WHOST-JUROS */
                        _.Move(SPVG011W.LK_VG011_S_VL_JUROS, WHOST_JUROS);

                        /*" -1424- COMPUTE WPRM-VG = PARCEVID-PREMIO-VG * LK-VG011-S-PC-INDICE */
                        WORK_AREA.WPRM_VG.Value = PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_VG * SPVG011W.LK_VG011_S_PC_INDICE;

                        /*" -1426- MOVE WPRM-VG TO WHOST-PRM-VG */
                        _.Move(WORK_AREA.WPRM_VG, WHOST_PRM_VG);

                        /*" -1427- IF PARCEVID-PREMIO-AP > ZEROS */

                        if (PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_AP > 00)
                        {

                            /*" -1428- COMPUTE WPRM-AP = WPRM-TOTAL - WPRM-VG */
                            WORK_AREA.WPRM_AP.Value = WORK_AREA.WPRM_TOTAL - WORK_AREA.WPRM_VG;

                            /*" -1429- MOVE WPRM-AP TO WHOST-PRM-AP */
                            _.Move(WORK_AREA.WPRM_AP, WHOST_PRM_AP);

                            /*" -1430- ELSE */
                        }
                        else
                        {


                            /*" -1432- MOVE ZEROS TO WPRM-AP WHOST-PRM-AP */
                            _.Move(0, WORK_AREA.WPRM_AP, WHOST_PRM_AP);

                            /*" -1433- END-IF */
                        }


                        /*" -1434- ELSE */
                    }
                    else
                    {


                        /*" -1435- MOVE COBHISVI-PRM-TOTAL TO WPRM-TOTAL */
                        _.Move(COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_PRM_TOTAL, WORK_AREA.WPRM_TOTAL);

                        /*" -1438- MOVE WPRM-TOTAL TO WHOST-NEW-PRM LK-VG011-E-VL-ORIGINAL */
                        _.Move(WORK_AREA.WPRM_TOTAL, WHOST_NEW_PRM, SPVG011W.LK_VG011_E_VL_ORIGINAL);

                        /*" -1439- MOVE PARCEVID-PREMIO-VG TO WPRM-VG */
                        _.Move(PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_VG, WORK_AREA.WPRM_VG);

                        /*" -1440- MOVE WPRM-VG TO WHOST-PRM-VG */
                        _.Move(WORK_AREA.WPRM_VG, WHOST_PRM_VG);

                        /*" -1441- MOVE PARCEVID-PREMIO-AP TO WPRM-AP */
                        _.Move(PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_AP, WORK_AREA.WPRM_AP);

                        /*" -1442- MOVE WPRM-AP TO WHOST-PRM-AP */
                        _.Move(WORK_AREA.WPRM_AP, WHOST_PRM_AP);

                        /*" -1443- END-IF */
                    }


                    /*" -1444- END-IF */
                }


                /*" -1445- ELSE */
            }
            else
            {


                /*" -1448- IF ((RELATORI-NUM-COPIAS EQUAL 6 OR 7) AND (DATA-INI NOT EQUAL DATA-FIM) AND (WQTD-HIST-CONT > ZEROS )) */

                if (((RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS.In("6", "7")) && (WORK_AREA.DATA_INI != WORK_AREA.DATA_FIM) && (WQTD_HIST_CONT > 00)))
                {

                    /*" -1450- PERFORM R6000-00-CALCULA-VL-ATUALIZADO */

                    R6000_00_CALCULA_VL_ATUALIZADO_SECTION();

                    /*" -1451- IF LK-VG011-E-VL-ORIGINAL < LK-VG011-S-VL-CORRIGIDO */

                    if (SPVG011W.LK_VG011_E_VL_ORIGINAL < SPVG011W.LK_VG011_S_VL_CORRIGIDO)
                    {

                        /*" -1452- MOVE 'S' TO WS-VALOR-COM-CORR */
                        _.Move("S", WS_VALOR_COM_CORR);

                        /*" -1453- ELSE */
                    }
                    else
                    {


                        /*" -1454- MOVE 'N' TO WS-VALOR-COM-CORR */
                        _.Move("N", WS_VALOR_COM_CORR);

                        /*" -1456- END-IF */
                    }


                    /*" -1459- MOVE LK-VG011-S-VL-CORRIGIDO TO WPRM-TOTAL WHOST-NEW-PRM */
                    _.Move(SPVG011W.LK_VG011_S_VL_CORRIGIDO, WORK_AREA.WPRM_TOTAL, WHOST_NEW_PRM);

                    /*" -1461- MOVE LK-VG011-S-VL-JUROS TO WHOST-JUROS */
                    _.Move(SPVG011W.LK_VG011_S_VL_JUROS, WHOST_JUROS);

                    /*" -1463- COMPUTE WPRM-VG = PARCEVID-PREMIO-VG * LK-VG011-S-PC-INDICE */
                    WORK_AREA.WPRM_VG.Value = PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_VG * SPVG011W.LK_VG011_S_PC_INDICE;

                    /*" -1465- MOVE WPRM-VG TO WHOST-PRM-VG */
                    _.Move(WORK_AREA.WPRM_VG, WHOST_PRM_VG);

                    /*" -1466- IF PARCEVID-PREMIO-AP > ZEROS */

                    if (PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_AP > 00)
                    {

                        /*" -1467- COMPUTE WPRM-AP = WPRM-TOTAL - WPRM-VG */
                        WORK_AREA.WPRM_AP.Value = WORK_AREA.WPRM_TOTAL - WORK_AREA.WPRM_VG;

                        /*" -1468- MOVE WPRM-AP TO WHOST-PRM-AP */
                        _.Move(WORK_AREA.WPRM_AP, WHOST_PRM_AP);

                        /*" -1469- ELSE */
                    }
                    else
                    {


                        /*" -1471- MOVE ZEROS TO WPRM-AP WHOST-PRM-AP */
                        _.Move(0, WORK_AREA.WPRM_AP, WHOST_PRM_AP);

                        /*" -1472- END-IF */
                    }


                    /*" -1473- ELSE */
                }
                else
                {


                    /*" -1474- MOVE COBHISVI-PRM-TOTAL TO WPRM-TOTAL */
                    _.Move(COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_PRM_TOTAL, WORK_AREA.WPRM_TOTAL);

                    /*" -1477- MOVE WPRM-TOTAL TO WHOST-NEW-PRM LK-VG011-E-VL-ORIGINAL */
                    _.Move(WORK_AREA.WPRM_TOTAL, WHOST_NEW_PRM, SPVG011W.LK_VG011_E_VL_ORIGINAL);

                    /*" -1478- MOVE PARCEVID-PREMIO-VG TO WPRM-VG */
                    _.Move(PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_VG, WORK_AREA.WPRM_VG);

                    /*" -1479- MOVE WPRM-VG TO WHOST-PRM-VG */
                    _.Move(WORK_AREA.WPRM_VG, WHOST_PRM_VG);

                    /*" -1480- MOVE PARCEVID-PREMIO-AP TO WPRM-AP */
                    _.Move(PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_AP, WORK_AREA.WPRM_AP);

                    /*" -1481- MOVE WPRM-AP TO WHOST-PRM-AP */
                    _.Move(WORK_AREA.WPRM_AP, WHOST_PRM_AP);

                    /*" -1482- END-IF */
                }


                /*" -1535- END-IF */
            }


            /*" -1536- IF RELATORI-NUM-COPIAS EQUAL 2 OR 3 OR 5 */

            if (RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS.In("2", "3", "5"))
            {

                /*" -1537- IF WQTD-HIST-CONT GREATER ZEROS */

                if (WQTD_HIST_CONT > 00)
                {

                    /*" -1538- PERFORM R2100-00-PROCESSA-HISTLANCCTA */

                    R2100_00_PROCESSA_HISTLANCCTA_SECTION();

                    /*" -1539- PERFORM R2150-00-INSERT-HISTLANCCTA */

                    R2150_00_INSERT_HISTLANCCTA_SECTION();

                    /*" -1540- END-IF */
                }


                /*" -1542- END-IF */
            }


            /*" -1543- IF RELATORI-NUM-COPIAS EQUAL 6 OR 8 */

            if (RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS.In("6", "8"))
            {

                /*" -1544- IF WQTD-HIST-CONT GREATER ZEROS */

                if (WQTD_HIST_CONT > 00)
                {

                    /*" -1545- IF WS-VALOR-COM-CORR EQUAL 'N' */

                    if (WS_VALOR_COM_CORR == "N")
                    {

                        /*" -1546- PERFORM R2100-00-PROCESSA-HISTLANCCTA */

                        R2100_00_PROCESSA_HISTLANCCTA_SECTION();

                        /*" -1547- PERFORM R2150-00-INSERT-HISTLANCCTA */

                        R2150_00_INSERT_HISTLANCCTA_SECTION();

                        /*" -1548- ELSE */
                    }
                    else
                    {


                        /*" -1549- MOVE WHOST-NEW-PRM TO WS-VL-PRM-TEMP */
                        _.Move(WHOST_NEW_PRM, WS_VL_PRM_TEMP);

                        /*" -1550- MOVE LK-VG011-E-VL-ORIGINAL TO WHOST-NEW-PRM */
                        _.Move(SPVG011W.LK_VG011_E_VL_ORIGINAL, WHOST_NEW_PRM);

                        /*" -1551- PERFORM R2100-00-PROCESSA-HISTLANCCTA */

                        R2100_00_PROCESSA_HISTLANCCTA_SECTION();

                        /*" -1553- PERFORM R2150-00-INSERT-HISTLANCCTA */

                        R2150_00_INSERT_HISTLANCCTA_SECTION();

                        /*" -1554- IF OPCPAGVI-NUM-CONTA-DEBITO > ZEROS */

                        if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO > 00)
                        {

                            /*" -1555- MOVE '0' TO HISLANCT-SIT-REGISTRO */
                            _.Move("0", HISLANCT.DCLHIST_LANC_CTA.HISLANCT_SIT_REGISTRO);

                            /*" -1556- ELSE */
                        }
                        else
                        {


                            /*" -1557- MOVE ' ' TO HISLANCT-SIT-REGISTRO */
                            _.Move(" ", HISLANCT.DCLHIST_LANC_CTA.HISLANCT_SIT_REGISTRO);

                            /*" -1558- MOVE ZEROS TO VIND-CODRET */
                            _.Move(0, VIND_CODRET);

                            /*" -1559- MOVE 02 TO HISLANCT-CODRET */
                            _.Move(02, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_CODRET);

                            /*" -1561- END-IF */
                        }


                        /*" -1563- PERFORM R1125-00-SELECT-HISLANCT */

                        R1125_00_SELECT_HISLANCT_SECTION();

                        /*" -1565- IF WS-PRM-TOTAL-ANT > ZEROS AND LK-VG011-S-VL-JUROS > WS-PRM-TOTAL-ANT */

                        if (WS_PRM_TOTAL_ANT > 00 && SPVG011W.LK_VG011_S_VL_JUROS > WS_PRM_TOTAL_ANT)
                        {

                            /*" -1568- COMPUTE LK-VG011-S-VL-JUROS = LK-VG011-S-VL-JUROS - WS-PRM-TOTAL-ANT */
                            SPVG011W.LK_VG011_S_VL_JUROS.Value = SPVG011W.LK_VG011_S_VL_JUROS - WS_PRM_TOTAL_ANT;

                            /*" -1570- END-IF */
                        }


                        /*" -1571- IF LK-VG011-S-VL-JUROS > ZEROS */

                        if (SPVG011W.LK_VG011_S_VL_JUROS > 00)
                        {

                            /*" -1572- MOVE LK-VG011-S-VL-JUROS TO WHOST-NEW-PRM */
                            _.Move(SPVG011W.LK_VG011_S_VL_JUROS, WHOST_NEW_PRM);

                            /*" -1573- MOVE 6090 TO CONVEVG-COD-NAOACEITE */
                            _.Move(6090, CONVEVG.DCLCONVENIOS_VG.CONVEVG_COD_NAOACEITE);

                            /*" -1574- PERFORM R2150-00-INSERT-HISTLANCCTA */

                            R2150_00_INSERT_HISTLANCCTA_SECTION();

                            /*" -1576- END-IF */
                        }


                        /*" -1577- MOVE WS-VL-PRM-TEMP TO WHOST-NEW-PRM */
                        _.Move(WS_VL_PRM_TEMP, WHOST_NEW_PRM);

                        /*" -1578- END-IF */
                    }


                    /*" -1579- ELSE */
                }
                else
                {


                    /*" -1580- PERFORM R2100-00-PROCESSA-HISTLANCCTA */

                    R2100_00_PROCESSA_HISTLANCCTA_SECTION();

                    /*" -1581- PERFORM R2150-00-INSERT-HISTLANCCTA */

                    R2150_00_INSERT_HISTLANCCTA_SECTION();

                    /*" -1582- MOVE ZEROS TO LK-VG011-S-VL-JUROS */
                    _.Move(0, SPVG011W.LK_VG011_S_VL_JUROS);

                    /*" -1583- MOVE 'N' TO WS-VALOR-COM-CORR */
                    _.Move("N", WS_VALOR_COM_CORR);

                    /*" -1584- MOVE LK-VG011-E-VL-ORIGINAL TO WHOST-NEW-PRM */
                    _.Move(SPVG011W.LK_VG011_E_VL_ORIGINAL, WHOST_NEW_PRM);

                    /*" -1585- END-IF */
                }


                /*" -1587- END-IF */
            }


            /*" -1588- IF RELATORI-NUM-COPIAS EQUAL 7 */

            if (RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS == 7)
            {

                /*" -1591- IF (RELATORI-NUM-APOL-LIDER(1:5) NOT EQUAL 'R6090' ) AND (RELATORI-NUM-APOL-LIDER(1:5) NOT EQUAL 'S9022' ) AND (RELATORI-NUM-APOL-LIDER(1:5) NOT EQUAL 'N9022' ) */

                if ((RELATORI.DCLRELATORIOS.RELATORI_NUM_APOL_LIDER.Substring(1, 5) != "R6090") && (RELATORI.DCLRELATORIOS.RELATORI_NUM_APOL_LIDER.Substring(1, 5) != "S9022") && (RELATORI.DCLRELATORIOS.RELATORI_NUM_APOL_LIDER.Substring(1, 5) != "N9022"))
                {

                    /*" -1595- DISPLAY 'ERRO - TIPO RESTITUICAO NAO GERADA ' ' - CERTIFICADO >> ' RELATORI-NUM-CERTIFICADO ' NUM-COPIAS >> ' RELATORI-NUM-COPIAS ' NUM-APOL-LIDER >> ' RELATORI-NUM-APOL-LIDER */

                    $"ERRO - TIPO RESTITUICAO NAO GERADA  - CERTIFICADO >> {RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO} NUM-COPIAS >> {RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS} NUM-APOL-LIDER >> {RELATORI.DCLRELATORIOS.RELATORI_NUM_APOL_LIDER}"
                    .Display();

                    /*" -1596- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1603- END-IF */
                }


                /*" -1604- IF (RELATORI-NUM-APOL-LIDER(1:5) EQUAL 'R6090' ) */

                if ((RELATORI.DCLRELATORIOS.RELATORI_NUM_APOL_LIDER.Substring(1, 5) == "R6090"))
                {

                    /*" -1608- MOVE LK-VG011-S-VL-JUROS TO WHOST-NEW-PRM WHOST-PREMIO WHOST-JUROS */
                    _.Move(SPVG011W.LK_VG011_S_VL_JUROS, WHOST_NEW_PRM, WHOST_PREMIO, WHOST_JUROS);

                    /*" -1610- PERFORM R2100-00-PROCESSA-HISTLANCCTA */

                    R2100_00_PROCESSA_HISTLANCCTA_SECTION();

                    /*" -1611- IF OPCPAGVI-NUM-CONTA-DEBITO EQUAL ZEROS */

                    if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO == 00)
                    {

                        /*" -1614- DISPLAY 'ERRO - PGMNTO CORRECAO SEM CONTA  ' ' - CERTIFICADO >> ' RELATORI-NUM-CERTIFICADO ' NUM-COPIAS >> ' RELATORI-NUM-COPIAS */

                        $"ERRO - PGMNTO CORRECAO SEM CONTA   - CERTIFICADO >> {RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO} NUM-COPIAS >> {RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS}"
                        .Display();

                        /*" -1615- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -1617- END-IF */
                    }


                    /*" -1619- MOVE '0' TO HISLANCT-SIT-REGISTRO */
                    _.Move("0", HISLANCT.DCLHIST_LANC_CTA.HISLANCT_SIT_REGISTRO);

                    /*" -1620- MOVE 6090 TO CONVEVG-COD-NAOACEITE */
                    _.Move(6090, CONVEVG.DCLCONVENIOS_VG.CONVEVG_COD_NAOACEITE);

                    /*" -1621- PERFORM R2150-00-INSERT-HISTLANCCTA */

                    R2150_00_INSERT_HISTLANCCTA_SECTION();

                    /*" -1623- PERFORM R3540-00-DEVOLVE-CORRECAO-CRTO */

                    R3540_00_DEVOLVE_CORRECAO_CRTO_SECTION();

                    /*" -1625- PERFORM R2200-00-UPDATE-PARCELVA */

                    R2200_00_UPDATE_PARCELVA_SECTION();

                    /*" -1626- DISPLAY 'PULAR PARA R1000-05-CONTINUA' */
                    _.Display($"PULAR PARA R1000-05-CONTINUA");

                    /*" -1628- DISPLAY 'REENVIO DE CORRECAO EM CONTA  R6090' */
                    _.Display($"REENVIO DE CORRECAO EM CONTA  R6090");

                    /*" -1629- GO TO R1000-05-CONTINUA */

                    R1000_05_CONTINUA(); //GOTO
                    return;

                    /*" -1636- END-IF */
                }


                /*" -1637- IF (RELATORI-NUM-APOL-LIDER(1:5) EQUAL 'S9022' ) */

                if ((RELATORI.DCLRELATORIOS.RELATORI_NUM_APOL_LIDER.Substring(1, 5) == "S9022"))
                {

                    /*" -1640- COMPUTE WHOST-NEW-PRM = LK-VG011-E-VL-ORIGINAL + LK-VG011-S-VL-JUROS */
                    WHOST_NEW_PRM.Value = SPVG011W.LK_VG011_E_VL_ORIGINAL + SPVG011W.LK_VG011_S_VL_JUROS;

                    /*" -1642- MOVE LK-VG011-S-VL-JUROS TO WHOST-JUROS */
                    _.Move(SPVG011W.LK_VG011_S_VL_JUROS, WHOST_JUROS);

                    /*" -1645- MOVE WHOST-NEW-PRM TO WHOST-PREMIO LK-VG011-S-VL-JUROS */
                    _.Move(WHOST_NEW_PRM, WHOST_PREMIO, SPVG011W.LK_VG011_S_VL_JUROS);

                    /*" -1647- PERFORM R2100-00-PROCESSA-HISTLANCCTA */

                    R2100_00_PROCESSA_HISTLANCCTA_SECTION();

                    /*" -1648- IF OPCPAGVI-NUM-CONTA-DEBITO EQUAL ZEROS */

                    if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO == 00)
                    {

                        /*" -1651- DISPLAY 'ERRO - PGMNTO CORRECAO SEM CONTA  ' ' - CERTIFICADO >> ' RELATORI-NUM-CERTIFICADO ' NUM-COPIAS >> ' RELATORI-NUM-COPIAS */

                        $"ERRO - PGMNTO CORRECAO SEM CONTA   - CERTIFICADO >> {RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO} NUM-COPIAS >> {RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS}"
                        .Display();

                        /*" -1652- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -1654- END-IF */
                    }


                    /*" -1656- MOVE '0' TO HISLANCT-SIT-REGISTRO */
                    _.Move("0", HISLANCT.DCLHIST_LANC_CTA.HISLANCT_SIT_REGISTRO);

                    /*" -1657- MOVE 6090 TO CONVEVG-COD-NAOACEITE */
                    _.Move(6090, CONVEVG.DCLCONVENIOS_VG.CONVEVG_COD_NAOACEITE);

                    /*" -1658- PERFORM R2150-00-INSERT-HISTLANCCTA */

                    R2150_00_INSERT_HISTLANCCTA_SECTION();

                    /*" -1660- PERFORM R3540-00-DEVOLVE-CORRECAO-CRTO */

                    R3540_00_DEVOLVE_CORRECAO_CRTO_SECTION();

                    /*" -1662- PERFORM R2200-00-UPDATE-PARCELVA */

                    R2200_00_UPDATE_PARCELVA_SECTION();

                    /*" -1663- DISPLAY 'PULAR PARA R1000-06-CONTINUA' */
                    _.Display($"PULAR PARA R1000-06-CONTINUA");

                    /*" -1665- DISPLAY 'REENVIO DE CARTAO EM CONTA S9022' */
                    _.Display($"REENVIO DE CARTAO EM CONTA S9022");

                    /*" -1666- GO TO R1000-05-CONTINUA */

                    R1000_05_CONTINUA(); //GOTO
                    return;

                    /*" -1673- END-IF */
                }


                /*" -1674- IF (RELATORI-NUM-APOL-LIDER(1:5) EQUAL 'N9022' ) */

                if ((RELATORI.DCLRELATORIOS.RELATORI_NUM_APOL_LIDER.Substring(1, 5) == "N9022"))
                {

                    /*" -1675- IF WS-VALOR-COM-CORR EQUAL 'N' */

                    if (WS_VALOR_COM_CORR == "N")
                    {

                        /*" -1676- PERFORM R2100-00-PROCESSA-HISTLANCCTA */

                        R2100_00_PROCESSA_HISTLANCCTA_SECTION();

                        /*" -1677- PERFORM R2150-00-INSERT-HISTLANCCTA */

                        R2150_00_INSERT_HISTLANCCTA_SECTION();

                        /*" -1678- ELSE */
                    }
                    else
                    {


                        /*" -1679- MOVE WHOST-NEW-PRM TO WS-VL-PRM-TEMP */
                        _.Move(WHOST_NEW_PRM, WS_VL_PRM_TEMP);

                        /*" -1680- MOVE LK-VG011-E-VL-ORIGINAL TO WHOST-NEW-PRM */
                        _.Move(SPVG011W.LK_VG011_E_VL_ORIGINAL, WHOST_NEW_PRM);

                        /*" -1681- PERFORM R2100-00-PROCESSA-HISTLANCCTA */

                        R2100_00_PROCESSA_HISTLANCCTA_SECTION();

                        /*" -1683- PERFORM R2150-00-INSERT-HISTLANCCTA */

                        R2150_00_INSERT_HISTLANCCTA_SECTION();

                        /*" -1684- IF OPCPAGVI-NUM-CONTA-DEBITO > ZEROS */

                        if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO > 00)
                        {

                            /*" -1685- MOVE '0' TO HISLANCT-SIT-REGISTRO */
                            _.Move("0", HISLANCT.DCLHIST_LANC_CTA.HISLANCT_SIT_REGISTRO);

                            /*" -1686- ELSE */
                        }
                        else
                        {


                            /*" -1687- MOVE ' ' TO HISLANCT-SIT-REGISTRO */
                            _.Move(" ", HISLANCT.DCLHIST_LANC_CTA.HISLANCT_SIT_REGISTRO);

                            /*" -1688- MOVE ZEROS TO VIND-CODRET */
                            _.Move(0, VIND_CODRET);

                            /*" -1689- MOVE 02 TO HISLANCT-CODRET */
                            _.Move(02, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_CODRET);

                            /*" -1691- END-IF */
                        }


                        /*" -1693- PERFORM R1125-00-SELECT-HISLANCT */

                        R1125_00_SELECT_HISLANCT_SECTION();

                        /*" -1695- IF WS-PRM-TOTAL-ANT > ZEROS AND LK-VG011-S-VL-JUROS > WS-PRM-TOTAL-ANT */

                        if (WS_PRM_TOTAL_ANT > 00 && SPVG011W.LK_VG011_S_VL_JUROS > WS_PRM_TOTAL_ANT)
                        {

                            /*" -1698- COMPUTE LK-VG011-S-VL-JUROS = LK-VG011-S-VL-JUROS - WS-PRM-TOTAL-ANT */
                            SPVG011W.LK_VG011_S_VL_JUROS.Value = SPVG011W.LK_VG011_S_VL_JUROS - WS_PRM_TOTAL_ANT;

                            /*" -1700- END-IF */
                        }


                        /*" -1701- IF LK-VG011-S-VL-JUROS > ZEROS */

                        if (SPVG011W.LK_VG011_S_VL_JUROS > 00)
                        {

                            /*" -1702- MOVE LK-VG011-S-VL-JUROS TO WHOST-NEW-PRM */
                            _.Move(SPVG011W.LK_VG011_S_VL_JUROS, WHOST_NEW_PRM);

                            /*" -1703- MOVE 6090 TO CONVEVG-COD-NAOACEITE */
                            _.Move(6090, CONVEVG.DCLCONVENIOS_VG.CONVEVG_COD_NAOACEITE);

                            /*" -1704- PERFORM R2150-00-INSERT-HISTLANCCTA */

                            R2150_00_INSERT_HISTLANCCTA_SECTION();

                            /*" -1706- END-IF */
                        }


                        /*" -1707- MOVE WS-VL-PRM-TEMP TO WHOST-NEW-PRM */
                        _.Move(WS_VL_PRM_TEMP, WHOST_NEW_PRM);

                        /*" -1708- END-IF */
                    }


                    /*" -1709- END-IF */
                }


                /*" -1711- END-IF */
            }


            /*" -1713- PERFORM R2000-00-UPDATE-HISTCOBVA. */

            R2000_00_UPDATE_HISTCOBVA_SECTION();

            /*" -1714- IF WS-OPC-PAGTO EQUAL 'N' */

            if (WORK_AREA.WS_OPC_PAGTO == "N")
            {

                /*" -1715- ADD 1 TO AC-R-COBHISVI */
                ACUMULADORES.AC_R_COBHISVI.Value = ACUMULADORES.AC_R_COBHISVI + 1;

                /*" -1716- MOVE 'I' TO RELATORI-SIT-REGISTRO */
                _.Move("I", RELATORI.DCLRELATORIOS.RELATORI_SIT_REGISTRO);

                /*" -1717- PERFORM R1010-00-UPDATE-RELATORI */

                R1010_00_UPDATE_RELATORI_SECTION();

                /*" -1718- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -1720- END-IF. */
            }


            /*" -1721- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1722- ADD 1 TO AC-R-COBHISVI */
                ACUMULADORES.AC_R_COBHISVI.Value = ACUMULADORES.AC_R_COBHISVI + 1;

                /*" -1723- MOVE 'J' TO RELATORI-SIT-REGISTRO */
                _.Move("J", RELATORI.DCLRELATORIOS.RELATORI_SIT_REGISTRO);

                /*" -1724- PERFORM R1010-00-UPDATE-RELATORI */

                R1010_00_UPDATE_RELATORI_SECTION();

                /*" -1725- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -1734- END-IF */
            }


            /*" -1735- IF RELATORI-NUM-COPIAS EQUAL ZEROS */

            if (RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS == 00)
            {

                /*" -1736- IF WQTD-HIST-CONT GREATER ZEROS */

                if (WQTD_HIST_CONT > 00)
                {

                    /*" -1737- PERFORM R2100-00-PROCESSA-HISTLANCCTA */

                    R2100_00_PROCESSA_HISTLANCCTA_SECTION();

                    /*" -1738- PERFORM R2150-00-INSERT-HISTLANCCTA */

                    R2150_00_INSERT_HISTLANCCTA_SECTION();

                    /*" -1739- END-IF */
                }


                /*" -1741- END-IF */
            }


            /*" -1743- PERFORM R2200-00-UPDATE-PARCELVA. */

            R2200_00_UPDATE_PARCELVA_SECTION();

            /*" -1745- PERFORM R2250-00-SELECT-PROPOSTAVA. */

            R2250_00_SELECT_PROPOSTAVA_SECTION();

            /*" -1747- IF PROPOVA-SIT-REGISTRO = '3' OR '6' OR '4' NEXT SENTENCE */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO.In("3", "6", "4"))
            {

                /*" -1748- ELSE */
            }
            else
            {


                /*" -1749- PERFORM R2300-00-UPDATE-PROPOSTAVA */

                R2300_00_UPDATE_PROPOSTAVA_SECTION();

                /*" -1751- END-IF. */
            }


            /*" -1754- IF OPCPAGVI-OPCAO-PAGAMENTO = '3' AND WTEM-ALCADA = 'S' AND WQTD-HIST-CONT GREATER ZEROS */

            if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO == "3" && WORK_AREA.WTEM_ALCADA == "S" && WQTD_HIST_CONT > 00)
            {

                /*" -1755- PERFORM R2400-00-INSERT-HISTCONTABILVA */

                R2400_00_INSERT_HISTCONTABILVA_SECTION();

                /*" -1759- END-IF */
            }


            /*" -1763- IF PROPOVA-COD-PRODUTO NOT EQUAL 7701 AND 7703 AND 7705 AND 7707 AND 7708 AND 7713 AND 7715 AND 7725 AND 3707 AND 3708 */

            if (!PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO.In("7701", "7703", "7705", "7707", "7708", "7713", "7715", "7725", "3707", "3708"))
            {

                /*" -1766- IF RELATORI-NUM-PARCELA EQUAL 1 AND PROPOVA-SIT-REGISTRO EQUAL '2' AND WQTD-HIST-CONT GREATER ZEROS */

                if (RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA == 1 && PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO == "2" && WQTD_HIST_CONT > 00)
                {

                    /*" -1767- PERFORM R2500-00-INSERT-RELATORIOS */

                    R2500_00_INSERT_RELATORIOS_SECTION();

                    /*" -1768- END-IF */
                }


                /*" -1770- END-IF. */
            }


            /*" -1772- MOVE '1' TO RELATORI-SIT-REGISTRO */
            _.Move("1", RELATORI.DCLRELATORIOS.RELATORI_SIT_REGISTRO);

            /*" -1774- PERFORM R1010-00-UPDATE-RELATORI. */

            R1010_00_UPDATE_RELATORI_SECTION();

            /*" -1775- IF RELATORI-NUM-PARCELA EQUAL 1 */

            if (RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA == 1)
            {

                /*" -1778- IF (PROPOFID-OPCAOPAG EQUAL '3' ) AND (RELATORI-NUM-COPIAS EQUAL 5 OR 6 OR 7 OR 8) */

                if ((PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAOPAG == "3") && (RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS.In("5", "6", "7", "8")))
                {

                    /*" -1779- EVALUATE RELATORI-NUM-COPIAS */
                    switch (RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS.Value)
                    {

                        /*" -1780- WHEN 5 */
                        case 5:

                            /*" -1781- PERFORM R3400-00-DEVOLVE-CARTAO-9021 */

                            R3400_00_DEVOLVE_CARTAO_9021_SECTION();

                            /*" -1782- WHEN 6 */
                            break;
                        case 6:

                        /*" -1783- WHEN 7 */
                        case 7:

                            /*" -1784- WHEN 8 */
                            break;
                        case 8:

                            /*" -1785- IF WS-VALOR-COM-CORR EQUAL 'S' */

                            if (WS_VALOR_COM_CORR == "S")
                            {

                                /*" -1786- PERFORM R3500-00-DEVOLVE-CARTAO-9022 */

                                R3500_00_DEVOLVE_CARTAO_9022_SECTION();

                                /*" -1787- PERFORM R3540-00-DEVOLVE-CORRECAO-CRTO */

                                R3540_00_DEVOLVE_CORRECAO_CRTO_SECTION();

                                /*" -1788- ELSE */
                            }
                            else
                            {


                                /*" -1789- PERFORM R3500-00-DEVOLVE-CARTAO-9022 */

                                R3500_00_DEVOLVE_CARTAO_9022_SECTION();

                                /*" -1790- END-IF */
                            }


                            /*" -1791- WHEN OTHER */
                            break;
                        default:

                            /*" -1795- DISPLAY 'NUM-COPIAS DESCONHECIDA P/ DECLINIO 1 ' RELATORI-NUM-COPIAS ' ' RELATORI-NUM-CERTIFICADO ' ' RELATORI-NUM-PARCELA */

                            $"NUM-COPIAS DESCONHECIDA P/ DECLINIO 1 {RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS} {RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO} {RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA}"
                            .Display();

                            /*" -1796- IF RELATORI-NUM-COPIAS EQUAL 2 */

                            if (RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS == 2)
                            {

                                /*" -1797- GO TO R1000-05-CONTINUA */

                                R1000_05_CONTINUA(); //GOTO
                                return;

                                /*" -1798- END-IF */
                            }


                            /*" -1799- GO TO R9999-00-ROT-ERRO */

                            R9999_00_ROT_ERRO_SECTION(); //GOTO
                            return;

                            /*" -1800- END-EVALUATE */
                            break;
                    }


                    /*" -1801- ELSE */
                }
                else
                {


                    /*" -1802- PERFORM R3100-00-VERIFICA-RCAPS */

                    R3100_00_VERIFICA_RCAPS_SECTION();

                    /*" -1803- PERFORM R3440-00-GRAVA-MOVTO-DEBCC-CEF */

                    R3440_00_GRAVA_MOVTO_DEBCC_CEF_SECTION();

                    /*" -1804- END-IF */
                }


                /*" -1805- ELSE */
            }
            else
            {


                /*" -1807- IF OPCPAGVI-OPCAO-PAGAMENTO EQUAL '5' */

                if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO == "5")
                {

                    /*" -1808- EVALUATE RELATORI-NUM-COPIAS */
                    switch (RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS.Value)
                    {

                        /*" -1809- WHEN 5 */
                        case 5:

                            /*" -1810- PERFORM R3400-00-DEVOLVE-CARTAO-9021 */

                            R3400_00_DEVOLVE_CARTAO_9021_SECTION();

                            /*" -1811- WHEN 6 */
                            break;
                        case 6:

                        /*" -1812- WHEN 7 */
                        case 7:

                            /*" -1813- WHEN 8 */
                            break;
                        case 8:

                            /*" -1814- IF WS-VALOR-COM-CORR EQUAL 'S' */

                            if (WS_VALOR_COM_CORR == "S")
                            {

                                /*" -1815- PERFORM R3500-00-DEVOLVE-CARTAO-9022 */

                                R3500_00_DEVOLVE_CARTAO_9022_SECTION();

                                /*" -1816- PERFORM R3540-00-DEVOLVE-CORRECAO-CRTO */

                                R3540_00_DEVOLVE_CORRECAO_CRTO_SECTION();

                                /*" -1817- ELSE */
                            }
                            else
                            {


                                /*" -1818- PERFORM R3500-00-DEVOLVE-CARTAO-9022 */

                                R3500_00_DEVOLVE_CARTAO_9022_SECTION();

                                /*" -1819- END-IF */
                            }


                            /*" -1820- WHEN OTHER */
                            break;
                        default:

                            /*" -1824- DISPLAY 'NUM-COPIAS DESCONHECIDA P/ DECLINIO 2 ' RELATORI-NUM-COPIAS ' ' RELATORI-NUM-CERTIFICADO ' ' RELATORI-NUM-PARCELA */

                            $"NUM-COPIAS DESCONHECIDA P/ DECLINIO 2 {RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS} {RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO} {RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA}"
                            .Display();

                            /*" -1825- IF RELATORI-NUM-COPIAS EQUAL 2 */

                            if (RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS == 2)
                            {

                                /*" -1826- GO TO R1000-05-CONTINUA */

                                R1000_05_CONTINUA(); //GOTO
                                return;

                                /*" -1827- END-IF */
                            }


                            /*" -1828- GO TO R9999-00-ROT-ERRO */

                            R9999_00_ROT_ERRO_SECTION(); //GOTO
                            return;

                            /*" -1829- END-EVALUATE */
                            break;
                    }


                    /*" -1830- END-IF */
                }


                /*" -1833- END-IF */
            }


            /*" -1834- IF PROPOVA-SIT-REGISTRO EQUAL '2' */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO == "2")
            {

                /*" -1835- PERFORM R2860-00-DELETE-VGCRITICA */

                R2860_00_DELETE_VGCRITICA_SECTION();

                /*" -1836- END-IF */
            }


            /*" -1836- . */

            /*" -0- FLUXCONTROL_PERFORM R1000_05_CONTINUA */

            R1000_05_CONTINUA();

        }

        [StopWatch]
        /*" R1000-05-CONTINUA */
        private void R1000_05_CONTINUA(bool isPerform = false)
        {
            /*" -1842- MOVE '1' TO RELATORI-SIT-REGISTRO */
            _.Move("1", RELATORI.DCLRELATORIOS.RELATORI_SIT_REGISTRO);

            /*" -1843- PERFORM R1010-00-UPDATE-RELATORI */

            R1010_00_UPDATE_RELATORI_SECTION();

            /*" -1843- . */

        }

        [StopWatch]
        /*" R1000-10-NEXT */
        private void R1000_10_NEXT(bool isPerform = false)
        {
            /*" -1847- PERFORM R0910-00-FETCH-RELATORIOS. */

            R0910_00_FETCH_RELATORIOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1005-00-LER-HISTLANCTA-SECTION */
        private void R1005_00_LER_HISTLANCTA_SECTION()
        {
            /*" -1858- MOVE 'R1005-00-LER-HISTLANCTA  ' TO PARAGRAFO */
            _.Move("R1005-00-LER-HISTLANCTA  ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1859- MOVE 'SELECT HIST_LANC_CTA   ' TO COMANDO */
            _.Move("SELECT HIST_LANC_CTA   ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1861- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1872- PERFORM R1005_00_LER_HISTLANCTA_DB_SELECT_1 */

            R1005_00_LER_HISTLANCTA_DB_SELECT_1();

            /*" -1875-  EVALUATE SQLCODE  */

            /*" -1876-  WHEN ZEROS  */

            /*" -1877-  WHEN 100  */

            /*" -1877- IF   SQLCODE EQUALS ZEROS OR  100 */

            if (DB.SQLCODE.In("00", "100"))
            {

                /*" -1878- CONTINUE */

                /*" -1879-  WHEN OTHER  */

                /*" -1879- ELSE */
            }
            else
            {


                /*" -1880- DISPLAY 'R2022 (ERRO SELECT HIST_LANC_CTA   )' */
                _.Display($"R2022 (ERRO SELECT HIST_LANC_CTA   )");

                /*" -1881- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1883-  END-EVALUATE  */

                /*" -1883- END-IF */
            }


            /*" -1883- . */

        }

        [StopWatch]
        /*" R1005-00-LER-HISTLANCTA-DB-SELECT-1 */
        public void R1005_00_LER_HISTLANCTA_DB_SELECT_1()
        {
            /*" -1872- EXEC SQL SELECT NUM_CERTIFICADO INTO :HISLANCT-NUM-CERTIFICADO FROM SEGUROS.HIST_LANC_CTA WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO AND NUM_PARCELA = :RELATORI-NUM-PARCELA AND CODCONV = 6090 AND SIT_REGISTRO NOT IN ( ' ' , '1' , '2' , '8' ) FETCH FIRST 1 ROW ONLY WITH UR END-EXEC */

            var r1005_00_LER_HISTLANCTA_DB_SELECT_1_Query1 = new R1005_00_LER_HISTLANCTA_DB_SELECT_1_Query1()
            {
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
                RELATORI_NUM_PARCELA = RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA.ToString(),
            };

            var executed_1 = R1005_00_LER_HISTLANCTA_DB_SELECT_1_Query1.Execute(r1005_00_LER_HISTLANCTA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISLANCT_NUM_CERTIFICADO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1005_99_SAIDA*/

        [StopWatch]
        /*" R1010-00-UPDATE-RELATORI-SECTION */
        private void R1010_00_UPDATE_RELATORI_SECTION()
        {
            /*" -1892- MOVE 'R1010-00-UPDATE-RELATORI' TO PARAGRAFO. */
            _.Move("R1010-00-UPDATE-RELATORI", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1893- MOVE 'UPDATE SEGUROS.RELATORIOS' TO COMANDO. */
            _.Move("UPDATE SEGUROS.RELATORIOS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1895- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1902- PERFORM R1010_00_UPDATE_RELATORI_DB_UPDATE_1 */

            R1010_00_UPDATE_RELATORI_DB_UPDATE_1();

            /*" -1905- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1907- IF SQLCODE = 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -1908- ELSE */
                }
                else
                {


                    /*" -1908- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1010-00-UPDATE-RELATORI-DB-UPDATE-1 */
        public void R1010_00_UPDATE_RELATORI_DB_UPDATE_1()
        {
            /*" -1902- EXEC SQL UPDATE SEGUROS.RELATORIOS SET SIT_REGISTRO = :RELATORI-SIT-REGISTRO WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO AND COD_RELATORIO = 'VA0469B' AND SIT_REGISTRO = '0' AND NUM_PARCELA = :RELATORI-NUM-PARCELA END-EXEC. */

            var r1010_00_UPDATE_RELATORI_DB_UPDATE_1_Update1 = new R1010_00_UPDATE_RELATORI_DB_UPDATE_1_Update1()
            {
                RELATORI_SIT_REGISTRO = RELATORI.DCLRELATORIOS.RELATORI_SIT_REGISTRO.ToString(),
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
                RELATORI_NUM_PARCELA = RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA.ToString(),
            };

            R1010_00_UPDATE_RELATORI_DB_UPDATE_1_Update1.Execute(r1010_00_UPDATE_RELATORI_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_99_SAIDA*/

        [StopWatch]
        /*" R1050-00-SELECT-PROPOSTAVA-SECTION */
        private void R1050_00_SELECT_PROPOSTAVA_SECTION()
        {
            /*" -1920- MOVE 'R1050-00-SELECT-PROPOSTAVA' TO PARAGRAFO. */
            _.Move("R1050-00-SELECT-PROPOSTAVA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1921- MOVE 'SELECT SEGUROS.PROPOSTA_VA' TO COMANDO. */
            _.Move("SELECT SEGUROS.PROPOSTA_VA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1923- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1937- PERFORM R1050_00_SELECT_PROPOSTAVA_DB_SELECT_1 */

            R1050_00_SELECT_PROPOSTAVA_DB_SELECT_1();

            /*" -1940- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1942- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1944- IF VIND-DTA-DECLINIO = -1 OR PROPOVA-DTA-DECLINIO = '0001-01-01' */

            if (VIND_DTA_DECLINIO == -1 || PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTA_DECLINIO == "0001-01-01")
            {

                /*" -1945- MOVE RELATORI-DATA-SOLICITACAO TO WDTA-DECLINIO */
                _.Move(RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO, WDTA_DECLINIO);

                /*" -1946- ELSE */
            }
            else
            {


                /*" -1947- MOVE PROPOVA-DTA-DECLINIO TO WDTA-DECLINIO */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTA_DECLINIO, WDTA_DECLINIO);

                /*" -1948- END-IF */
            }


            /*" -1950- . */

            /*" -1951- MOVE 'R1050-01-SELECT-SYSDUMMY1 ' TO PARAGRAFO. */
            _.Move("R1050-01-SELECT-SYSDUMMY1 ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1957- PERFORM R1050_00_SELECT_PROPOSTAVA_DB_SELECT_2 */

            R1050_00_SELECT_PROPOSTAVA_DB_SELECT_2();

            /*" -1960- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1960- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1050-00-SELECT-PROPOSTAVA-DB-SELECT-1 */
        public void R1050_00_SELECT_PROPOSTAVA_DB_SELECT_1()
        {
            /*" -1937- EXEC SQL SELECT COD_FONTE, DATA_QUITACAO, SIT_REGISTRO, DTA_DECLINIO, COD_PRODUTO INTO :PROPOVA-COD-FONTE, :PROPOVA-DATA-QUITACAO, :PROPOVA-SIT-REGISTRO, :PROPOVA-DTA-DECLINIO:VIND-DTA-DECLINIO, :PROPOVA-COD-PRODUTO FROM SEGUROS.PROPOSTAS_VA WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO WITH UR END-EXEC. */

            var r1050_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1 = new R1050_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1()
            {
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1050_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1.Execute(r1050_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOVA_COD_FONTE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_FONTE);
                _.Move(executed_1.PROPOVA_DATA_QUITACAO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO);
                _.Move(executed_1.PROPOVA_SIT_REGISTRO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);
                _.Move(executed_1.PROPOVA_DTA_DECLINIO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTA_DECLINIO);
                _.Move(executed_1.VIND_DTA_DECLINIO, VIND_DTA_DECLINIO);
                _.Move(executed_1.PROPOVA_COD_PRODUTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1050_99_SAIDA*/

        [StopWatch]
        /*" R1050-00-SELECT-PROPOSTAVA-DB-SELECT-2 */
        public void R1050_00_SELECT_PROPOSTAVA_DB_SELECT_2()
        {
            /*" -1957- EXEC SQL SELECT DAYS(:SISTEMAS-DATA-MOV-ABERTO) - DAYS(:WDTA-DECLINIO) INTO :WDIAS-DECLINIO FROM SYSIBM.SYSDUMMY1 WITH UR END-EXEC. */

            /*-- linha suprimida por comandos abaixo EXEC SQL
            /*--SELECT DAYS(:SISTEMAS-DATA-MOV-ABERTO) -
            /*--DAYS(:WDTA-DECLINIO)
            /*--INTO :WDIAS-DECLINIO
            /*--FROM SYSIBM.SYSDUMMY1
            /*--WITH UR
            /*--END-EXEC.
            /*-- */

            _.Move((SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToDateTime() - WDTA_DECLINIO.ToDateTime()).Days.ToString(), WDIAS_DECLINIO);

        }

        [StopWatch]
        /*" R1100-00-SELECT-HISTCOBVA-SECTION */
        private void R1100_00_SELECT_HISTCOBVA_SECTION()
        {
            /*" -1970- MOVE 'R1100-00-SELECT-HISTCOBVA' TO PARAGRAFO. */
            _.Move("R1100-00-SELECT-HISTCOBVA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1971- MOVE 'SELECT SEGUROS.COBER_HIST_VIDAZUL' TO COMANDO. */
            _.Move("SELECT SEGUROS.COBER_HIST_VIDAZUL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1973- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1989- PERFORM R1100_00_SELECT_HISTCOBVA_DB_SELECT_1 */

            R1100_00_SELECT_HISTCOBVA_DB_SELECT_1();

            /*" -1992- IF SQLCODE NOT EQUAL ZEROS AND 100 AND -811 */

            if (!DB.SQLCODE.In("00", "100", "-811"))
            {

                /*" -1993- DISPLAY 'R1100-ERRO CONSULTA TABELA COBER_HIST_VIDAZUL' */
                _.Display($"R1100-ERRO CONSULTA TABELA COBER_HIST_VIDAZUL");

                /*" -1994- DISPLAY 'NUM-CERTIFICADO = ' RELATORI-NUM-CERTIFICADO */
                _.Display($"NUM-CERTIFICADO = {RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO}");

                /*" -1995- DISPLAY 'NUM-PARCELA     = ' RELATORI-NUM-PARCELA */
                _.Display($"NUM-PARCELA     = {RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA}");

                /*" -1996- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1997- END-IF */
            }


            /*" -1997- . */

        }

        [StopWatch]
        /*" R1100-00-SELECT-HISTCOBVA-DB-SELECT-1 */
        public void R1100_00_SELECT_HISTCOBVA_DB_SELECT_1()
        {
            /*" -1989- EXEC SQL SELECT NUM_TITULO, DATA_VENCIMENTO, SIT_REGISTRO, OCORR_HISTORICO, COD_DEVOLUCAO INTO :COBHISVI-NUM-TITULO, :COBHISVI-DATA-VENCIMENTO, :COBHISVI-SIT-REGISTRO, :COBHISVI-OCORR-HISTORICO, :COBHISVI-COD-DEVOLUCAO FROM SEGUROS.COBER_HIST_VIDAZUL WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO AND NUM_PARCELA = :RELATORI-NUM-PARCELA END-EXEC. */

            var r1100_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1 = new R1100_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1()
            {
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
                RELATORI_NUM_PARCELA = RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA.ToString(),
            };

            var executed_1 = R1100_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1.Execute(r1100_00_SELECT_HISTCOBVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COBHISVI_NUM_TITULO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_TITULO);
                _.Move(executed_1.COBHISVI_DATA_VENCIMENTO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_DATA_VENCIMENTO);
                _.Move(executed_1.COBHISVI_SIT_REGISTRO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_SIT_REGISTRO);
                _.Move(executed_1.COBHISVI_OCORR_HISTORICO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_OCORR_HISTORICO);
                _.Move(executed_1.COBHISVI_COD_DEVOLUCAO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_COD_DEVOLUCAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1110-00-SELECT-HISLANCT-SECTION */
        private void R1110_00_SELECT_HISLANCT_SECTION()
        {
            /*" -2009- MOVE 'R1100-00-SELECT-HISLANCT' TO PARAGRAFO. */
            _.Move("R1100-00-SELECT-HISLANCT", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2010- MOVE 'SELECT SEGUROS.HIST_LANC_CTA' TO COMANDO. */
            _.Move("SELECT SEGUROS.HIST_LANC_CTA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2012- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2014- MOVE ZEROS TO WQTD-QTD. */
            _.Move(0, WQTD_QTD);

            /*" -2021- PERFORM R1110_00_SELECT_HISLANCT_DB_SELECT_1 */

            R1110_00_SELECT_HISLANCT_DB_SELECT_1();

            /*" -2024- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -2024- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1110-00-SELECT-HISLANCT-DB-SELECT-1 */
        public void R1110_00_SELECT_HISLANCT_DB_SELECT_1()
        {
            /*" -2021- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :WQTD-QTD FROM SEGUROS.HIST_LANC_CTA WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO AND NUM_PARCELA = :RELATORI-NUM-PARCELA AND SIT_REGISTRO = '3' END-EXEC. */

            var r1110_00_SELECT_HISLANCT_DB_SELECT_1_Query1 = new R1110_00_SELECT_HISLANCT_DB_SELECT_1_Query1()
            {
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
                RELATORI_NUM_PARCELA = RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA.ToString(),
            };

            var executed_1 = R1110_00_SELECT_HISLANCT_DB_SELECT_1_Query1.Execute(r1110_00_SELECT_HISLANCT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WQTD_QTD, WQTD_QTD);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_99_SAIDA*/

        [StopWatch]
        /*" R1120-00-SELECT-HISLANCT-SECTION */
        private void R1120_00_SELECT_HISLANCT_SECTION()
        {
            /*" -2034- MOVE 'R1120-00-SELECT-HISLANCT' TO PARAGRAFO. */
            _.Move("R1120-00-SELECT-HISLANCT", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2035- MOVE 'SELECT SEGUROS.HIST_LANC_CTA' TO COMANDO. */
            _.Move("SELECT SEGUROS.HIST_LANC_CTA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2037- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2039- MOVE ZEROS TO WS-OCORR-HISTORICOCTA. */
            _.Move(0, WS_OCORR_HISTORICOCTA);

            /*" -2050- PERFORM R1120_00_SELECT_HISLANCT_DB_SELECT_1 */

            R1120_00_SELECT_HISLANCT_DB_SELECT_1();

            /*" -2053- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -2054- DISPLAY 'R1120-ERRO CONSULTA TABELA HIST_LANC_CTA' */
                _.Display($"R1120-ERRO CONSULTA TABELA HIST_LANC_CTA");

                /*" -2055- DISPLAY 'NUM-CERTIFICADO = ' RELATORI-NUM-CERTIFICADO */
                _.Display($"NUM-CERTIFICADO = {RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO}");

                /*" -2056- DISPLAY 'NUM-PARCELA     = ' RELATORI-NUM-PARCELA */
                _.Display($"NUM-PARCELA     = {RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA}");

                /*" -2057- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2058- END-IF */
            }


            /*" -2058- . */

        }

        [StopWatch]
        /*" R1120-00-SELECT-HISLANCT-DB-SELECT-1 */
        public void R1120_00_SELECT_HISLANCT_DB_SELECT_1()
        {
            /*" -2050- EXEC SQL SELECT VALUE(MAX(OCORR_HISTORICOCTA),0) INTO :WS-OCORR-HISTORICOCTA FROM SEGUROS.HIST_LANC_CTA WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO AND NUM_PARCELA = :RELATORI-NUM-PARCELA AND SIT_REGISTRO = ' ' AND TIPLANC = '2' AND CODCONV = :WS-COD-CONVENIO AND (NSAS IS NULL OR NSAS = 0) END-EXEC. */

            var r1120_00_SELECT_HISLANCT_DB_SELECT_1_Query1 = new R1120_00_SELECT_HISLANCT_DB_SELECT_1_Query1()
            {
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
                RELATORI_NUM_PARCELA = RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA.ToString(),
                WS_COD_CONVENIO = WS_COD_CONVENIO.ToString(),
            };

            var executed_1 = R1120_00_SELECT_HISLANCT_DB_SELECT_1_Query1.Execute(r1120_00_SELECT_HISLANCT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_OCORR_HISTORICOCTA, WS_OCORR_HISTORICOCTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1120_99_SAIDA*/

        [StopWatch]
        /*" R1125-00-SELECT-HISLANCT-SECTION */
        private void R1125_00_SELECT_HISLANCT_SECTION()
        {
            /*" -2070- MOVE 'R1125-00-SELECT-HISLANCT' TO PARAGRAFO. */
            _.Move("R1125-00-SELECT-HISLANCT", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2071- MOVE 'SELECT SEGUROS.HIST_LANC_CTA' TO COMANDO. */
            _.Move("SELECT SEGUROS.HIST_LANC_CTA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2073- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2075- MOVE ZEROS TO WS-PRM-TOTAL-ANT. */
            _.Move(0, WS_PRM_TOTAL_ANT);

            /*" -2085- PERFORM R1125_00_SELECT_HISLANCT_DB_SELECT_1 */

            R1125_00_SELECT_HISLANCT_DB_SELECT_1();

            /*" -2088- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -2089- DISPLAY 'R1125-ERRO CONSULTA TABELA HIST_LANC_CTA' */
                _.Display($"R1125-ERRO CONSULTA TABELA HIST_LANC_CTA");

                /*" -2090- DISPLAY 'NUM-CERTIFICADO = ' RELATORI-NUM-CERTIFICADO */
                _.Display($"NUM-CERTIFICADO = {RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO}");

                /*" -2091- DISPLAY 'NUM-PARCELA     = ' RELATORI-NUM-PARCELA */
                _.Display($"NUM-PARCELA     = {RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA}");

                /*" -2092- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2093- END-IF */
            }


            /*" -2093- . */

        }

        [StopWatch]
        /*" R1125-00-SELECT-HISLANCT-DB-SELECT-1 */
        public void R1125_00_SELECT_HISLANCT_DB_SELECT_1()
        {
            /*" -2085- EXEC SQL SELECT VALUE(PRM_TOTAL,0) INTO :WS-PRM-TOTAL-ANT FROM SEGUROS.HIST_LANC_CTA WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO AND NUM_PARCELA = :RELATORI-NUM-PARCELA AND TIPLANC = '2' AND CODCONV = 6090 AND SIT_REGISTRO NOT IN ( ' ' , '2' , '8' , 'A' ) WITH UR END-EXEC. */

            var r1125_00_SELECT_HISLANCT_DB_SELECT_1_Query1 = new R1125_00_SELECT_HISLANCT_DB_SELECT_1_Query1()
            {
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
                RELATORI_NUM_PARCELA = RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA.ToString(),
            };

            var executed_1 = R1125_00_SELECT_HISLANCT_DB_SELECT_1_Query1.Execute(r1125_00_SELECT_HISLANCT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_PRM_TOTAL_ANT, WS_PRM_TOTAL_ANT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1125_99_SAIDA*/

        [StopWatch]
        /*" R1130-00-SELECT-PARCELVA-SECTION */
        private void R1130_00_SELECT_PARCELVA_SECTION()
        {
            /*" -2104- MOVE 'R1130-00-SELECT-PARCELVA' TO PARAGRAFO. */
            _.Move("R1130-00-SELECT-PARCELVA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2105- MOVE 'SELECT SEGUROS.PARCELAS_VIDAZUL' TO COMANDO. */
            _.Move("SELECT SEGUROS.PARCELAS_VIDAZUL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2107- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2121- PERFORM R1130_00_SELECT_PARCELVA_DB_SELECT_1 */

            R1130_00_SELECT_PARCELVA_DB_SELECT_1();

            /*" -2125- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -2126- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2128- END-IF */
            }


            /*" -2129- IF PARCEVID-OCORR-HISTORICO EQUAL ZEROS */

            if (PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_OCORR_HISTORICO == 00)
            {

                /*" -2130- MOVE 1 TO PARCEVID-OCORR-HISTORICO */
                _.Move(1, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_OCORR_HISTORICO);

                /*" -2132- END-IF */
            }


            /*" -2133- MOVE COBHISVI-PRM-TOTAL TO WHOST-PREMIO1 */
            _.Move(COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_PRM_TOTAL, WHOST_PREMIO1);

            /*" -2133- . */

        }

        [StopWatch]
        /*" R1130-00-SELECT-PARCELVA-DB-SELECT-1 */
        public void R1130_00_SELECT_PARCELVA_DB_SELECT_1()
        {
            /*" -2121- EXEC SQL SELECT DATA_VENCIMENTO, PREMIO_VG, PREMIO_AP, OCORR_HISTORICO, PREMIO_VG + PREMIO_AP INTO :PARCEVID-DATA-VENCIMENTO, :PARCEVID-PREMIO-VG, :PARCEVID-PREMIO-AP, :PARCEVID-OCORR-HISTORICO, :COBHISVI-PRM-TOTAL FROM SEGUROS.PARCELAS_VIDAZUL WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO AND NUM_PARCELA = :RELATORI-NUM-PARCELA END-EXEC. */

            var r1130_00_SELECT_PARCELVA_DB_SELECT_1_Query1 = new R1130_00_SELECT_PARCELVA_DB_SELECT_1_Query1()
            {
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
                RELATORI_NUM_PARCELA = RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA.ToString(),
            };

            var executed_1 = R1130_00_SELECT_PARCELVA_DB_SELECT_1_Query1.Execute(r1130_00_SELECT_PARCELVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARCEVID_DATA_VENCIMENTO, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_DATA_VENCIMENTO);
                _.Move(executed_1.PARCEVID_PREMIO_VG, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_VG);
                _.Move(executed_1.PARCEVID_PREMIO_AP, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_PREMIO_AP);
                _.Move(executed_1.PARCEVID_OCORR_HISTORICO, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_OCORR_HISTORICO);
                _.Move(executed_1.COBHISVI_PRM_TOTAL, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_PRM_TOTAL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1130_99_SAIDA*/

        [StopWatch]
        /*" R1140-00-SELECT-PROPOFID-SECTION */
        private void R1140_00_SELECT_PROPOFID_SECTION()
        {
            /*" -2142- MOVE 'R1140-00-SELECT-PROPOFID  ' TO PARAGRAFO. */
            _.Move("R1140-00-SELECT-PROPOFID  ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2143- MOVE 'SELECT SEGUROS.PROPOSTA_FIDELIZ ' TO COMANDO. */
            _.Move("SELECT SEGUROS.PROPOSTA_FIDELIZ ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2145- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2147- INITIALIZE DCLPROPOSTA-FIDELIZ */
            _.Initialize(
                PROPOFID.DCLPROPOSTA_FIDELIZ
            );

            /*" -2153- PERFORM R1140_00_SELECT_PROPOFID_DB_SELECT_1 */

            R1140_00_SELECT_PROPOFID_DB_SELECT_1();

            /*" -2156-  EVALUATE SQLCODE  */

            /*" -2157-  WHEN ZEROS  */

            /*" -2157- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2158- CONTINUE */

                /*" -2159-  WHEN +100  */

                /*" -2159- ELSE IF   SQLCODE EQUALS  +100 */
            }
            else

            if (DB.SQLCODE == +100)
            {

                /*" -2160- MOVE '0' TO PROPOFID-OPCAOPAG */
                _.Move("0", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAOPAG);

                /*" -2161-  WHEN OTHER  */

                /*" -2161- ELSE */
            }
            else
            {


                /*" -2162- DISPLAY 'R1140 - FALHA NO SELECT DA PROPOSTA_FIDELIZ' */
                _.Display($"R1140 - FALHA NO SELECT DA PROPOSTA_FIDELIZ");

                /*" -2163- DISPLAY 'CERTIFICADO = ' RELATORI-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO = {RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO}");

                /*" -2164- DISPLAY 'SQLCODE     = ' SQLCODE */
                _.Display($"SQLCODE     = {DB.SQLCODE}");

                /*" -2165- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2167-  END-EVALUATE  */

                /*" -2167- END-IF */
            }


            /*" -2167- . */

        }

        [StopWatch]
        /*" R1140-00-SELECT-PROPOFID-DB-SELECT-1 */
        public void R1140_00_SELECT_PROPOFID_DB_SELECT_1()
        {
            /*" -2153- EXEC SQL SELECT OPCAOPAG INTO :PROPOFID-OPCAOPAG FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_PROPOSTA_SIVPF = :RELATORI-NUM-CERTIFICADO WITH UR END-EXEC. */

            var r1140_00_SELECT_PROPOFID_DB_SELECT_1_Query1 = new R1140_00_SELECT_PROPOFID_DB_SELECT_1_Query1()
            {
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1140_00_SELECT_PROPOFID_DB_SELECT_1_Query1.Execute(r1140_00_SELECT_PROPOFID_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOFID_OPCAOPAG, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAOPAG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1140_99_SAIDA*/

        [StopWatch]
        /*" R1150-00-SELECT-OPCAOPAGVA-SECTION */
        private void R1150_00_SELECT_OPCAOPAGVA_SECTION()
        {
            /*" -2176- MOVE 'R1150-00-SELECT-OPCAOPAGVA' TO PARAGRAFO. */
            _.Move("R1150-00-SELECT-OPCAOPAGVA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2177- MOVE 'SELECT SEGUROS.OPCAO_PAG_VIDAZUL' TO COMANDO. */
            _.Move("SELECT SEGUROS.OPCAO_PAG_VIDAZUL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2179- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2193- PERFORM R1150_00_SELECT_OPCAOPAGVA_DB_SELECT_1 */

            R1150_00_SELECT_OPCAOPAGVA_DB_SELECT_1();

            /*" -2196- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -2197- DISPLAY 'R1150 - FALHA NA CONSULTA DA OPCAO_PAG_VIDAZUL' */
                _.Display($"R1150 - FALHA NA CONSULTA DA OPCAO_PAG_VIDAZUL");

                /*" -2198- DISPLAY 'CERTIFICADO = ' RELATORI-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO = {RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO}");

                /*" -2199- DISPLAY 'SQLCODE     = ' SQLCODE */
                _.Display($"SQLCODE     = {DB.SQLCODE}");

                /*" -2200- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2202- END-IF */
            }


            /*" -2203- IF VIND-AGE LESS ZEROES */

            if (VIND_AGE < 00)
            {

                /*" -2204- MOVE ZEROES TO OPCPAGVI-COD-AGENCIA-DEBITO */
                _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO);

                /*" -2206- END-IF */
            }


            /*" -2207- IF VIND-OPE LESS ZEROES */

            if (VIND_OPE < 00)
            {

                /*" -2208- MOVE ZEROES TO OPCPAGVI-OPE-CONTA-DEBITO */
                _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO);

                /*" -2210- END-IF */
            }


            /*" -2211- IF VIND-CTA LESS ZEROES */

            if (VIND_CTA < 00)
            {

                /*" -2212- MOVE ZEROES TO OPCPAGVI-NUM-CONTA-DEBITO */
                _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO);

                /*" -2214- END-IF */
            }


            /*" -2215- IF VIND-DIG LESS ZEROES */

            if (VIND_DIG < 00)
            {

                /*" -2216- MOVE ZEROES TO OPCPAGVI-DIG-CONTA-DEBITO */
                _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO);

                /*" -2222- END-IF */
            }


            /*" -2223- IF RELATORI-NUM-COPIAS EQUAL 1 */

            if (RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS == 1)
            {

                /*" -2224- MOVE '0' TO HISLANCT-SIT-REGISTRO */
                _.Move("0", HISLANCT.DCLHIST_LANC_CTA.HISLANCT_SIT_REGISTRO);

                /*" -2225- MOVE '3' TO HISLANCT-TIPLANC */
                _.Move("3", HISLANCT.DCLHIST_LANC_CTA.HISLANCT_TIPLANC);

                /*" -2226- MOVE RELATORI-NUM-CERTIFICADO TO SAI-NRCERTIF */
                _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO, REG_SAIDA.SAI_NRCERTIF);

                /*" -2227- MOVE RELATORI-NUM-PARCELA TO SAI-NRPARCEL */
                _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA, REG_SAIDA.SAI_NRPARCEL);

                /*" -2228- MOVE COBHISVI-PRM-TOTAL TO SAI-VLPREMIO */
                _.Move(COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_PRM_TOTAL, REG_SAIDA.SAI_VLPREMIO);

                /*" -2229- MOVE RELATORI-COD-USUARIO TO SAI-USUARIO */
                _.Move(RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO, REG_SAIDA.SAI_USUARIO);

                /*" -2230- WRITE REG-CHEQ FROM REG-SAIDA */
                _.Move(REG_SAIDA.GetMoveValues(), REG_CHEQ);

                ARQCHEQ.Write(REG_CHEQ.GetMoveValues().ToString());

                /*" -2231- ADD 1 TO AC-GRAVA */
                ACUMULADORES.AC_GRAVA.Value = ACUMULADORES.AC_GRAVA + 1;

                /*" -2235- ELSE */
            }
            else
            {


                /*" -2236- IF RELATORI-NUM-COPIAS EQUAL 2 OR 3 */

                if (RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS.In("2", "3"))
                {

                    /*" -2237- MOVE '0' TO HISLANCT-SIT-REGISTRO */
                    _.Move("0", HISLANCT.DCLHIST_LANC_CTA.HISLANCT_SIT_REGISTRO);

                    /*" -2238- MOVE '2' TO HISLANCT-TIPLANC */
                    _.Move("2", HISLANCT.DCLHIST_LANC_CTA.HISLANCT_TIPLANC);

                    /*" -2242- ELSE */
                }
                else
                {


                    /*" -2243- IF RELATORI-NUM-COPIAS EQUAL ZEROS */

                    if (RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS == 00)
                    {

                        /*" -2244- IF OPCPAGVI-OPCAO-PAGAMENTO EQUAL '1' OR '2' OR '5' */

                        if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO.In("1", "2", "5"))
                        {

                            /*" -2245- MOVE '0' TO HISLANCT-SIT-REGISTRO */
                            _.Move("0", HISLANCT.DCLHIST_LANC_CTA.HISLANCT_SIT_REGISTRO);

                            /*" -2247- MOVE '2' TO HISLANCT-TIPLANC */
                            _.Move("2", HISLANCT.DCLHIST_LANC_CTA.HISLANCT_TIPLANC);

                            /*" -2248- IF OPCPAGVI-OPCAO-PAGAMENTO EQUAL '5' */

                            if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO == "5")
                            {

                                /*" -2249- MOVE 6 TO RELATORI-NUM-COPIAS */
                                _.Move(6, RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS);

                                /*" -2251- DISPLAY 'NUM-COPIA ALTERADA DE 0 PARA 6 >> ' RELATORI-NUM-CERTIFICADO */
                                _.Display($"NUM-COPIA ALTERADA DE 0 PARA 6 >> {RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO}");

                                /*" -2253- END-IF */
                            }


                            /*" -2254- ELSE */
                        }
                        else
                        {


                            /*" -2255- IF OPCPAGVI-OPCAO-PAGAMENTO EQUAL '3' */

                            if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO == "3")
                            {

                                /*" -2256- IF RELATORI-QUANTIDADE > 0 */

                                if (RELATORI.DCLRELATORIOS.RELATORI_QUANTIDADE > 0)
                                {

                                    /*" -2257- MOVE '0' TO HISLANCT-SIT-REGISTRO */
                                    _.Move("0", HISLANCT.DCLHIST_LANC_CTA.HISLANCT_SIT_REGISTRO);

                                    /*" -2258- MOVE '2' TO HISLANCT-TIPLANC */
                                    _.Move("2", HISLANCT.DCLHIST_LANC_CTA.HISLANCT_TIPLANC);

                                    /*" -2259- ELSE */
                                }
                                else
                                {


                                    /*" -2260- MOVE '0' TO HISLANCT-SIT-REGISTRO */
                                    _.Move("0", HISLANCT.DCLHIST_LANC_CTA.HISLANCT_SIT_REGISTRO);

                                    /*" -2261- MOVE '3' TO HISLANCT-TIPLANC */
                                    _.Move("3", HISLANCT.DCLHIST_LANC_CTA.HISLANCT_TIPLANC);

                                    /*" -2262- MOVE RELATORI-NUM-CERTIFICADO TO SAI-NRCERTIF */
                                    _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO, REG_SAIDA.SAI_NRCERTIF);

                                    /*" -2263- MOVE RELATORI-NUM-PARCELA TO SAI-NRPARCEL */
                                    _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA, REG_SAIDA.SAI_NRPARCEL);

                                    /*" -2264- MOVE COBHISVI-PRM-TOTAL TO SAI-VLPREMIO */
                                    _.Move(COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_PRM_TOTAL, REG_SAIDA.SAI_VLPREMIO);

                                    /*" -2265- MOVE RELATORI-COD-USUARIO TO SAI-USUARIO */
                                    _.Move(RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO, REG_SAIDA.SAI_USUARIO);

                                    /*" -2266- IF WQTD-HIST-CONT GREATER ZEROS */

                                    if (WQTD_HIST_CONT > 00)
                                    {

                                        /*" -2267- WRITE REG-CHEQ FROM REG-SAIDA */
                                        _.Move(REG_SAIDA.GetMoveValues(), REG_CHEQ);

                                        ARQCHEQ.Write(REG_CHEQ.GetMoveValues().ToString());

                                        /*" -2268- ADD 1 TO AC-GRAVA */
                                        ACUMULADORES.AC_GRAVA.Value = ACUMULADORES.AC_GRAVA + 1;

                                        /*" -2269- END-IF */
                                    }


                                    /*" -2270- END-IF */
                                }


                                /*" -2271- END-IF */
                            }


                            /*" -2272- END-IF */
                        }


                        /*" -2273- END-IF */
                    }


                    /*" -2274- END-IF */
                }


                /*" -2283- END-IF. */
            }


            /*" -2284- IF RELATORI-NUM-COPIAS EQUAL 1 */

            if (RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS == 1)
            {

                /*" -2285- MOVE '0' TO HISLANCT-SIT-REGISTRO */
                _.Move("0", HISLANCT.DCLHIST_LANC_CTA.HISLANCT_SIT_REGISTRO);

                /*" -2286- MOVE '3' TO HISLANCT-TIPLANC */
                _.Move("3", HISLANCT.DCLHIST_LANC_CTA.HISLANCT_TIPLANC);

                /*" -2287- MOVE RELATORI-NUM-CERTIFICADO TO SAI-NRCERTIF */
                _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO, REG_SAIDA.SAI_NRCERTIF);

                /*" -2288- MOVE RELATORI-NUM-PARCELA TO SAI-NRPARCEL */
                _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA, REG_SAIDA.SAI_NRPARCEL);

                /*" -2289- MOVE COBHISVI-PRM-TOTAL TO SAI-VLPREMIO */
                _.Move(COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_PRM_TOTAL, REG_SAIDA.SAI_VLPREMIO);

                /*" -2290- MOVE RELATORI-COD-USUARIO TO SAI-USUARIO */
                _.Move(RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO, REG_SAIDA.SAI_USUARIO);

                /*" -2291- WRITE REG-CHEQ FROM REG-SAIDA */
                _.Move(REG_SAIDA.GetMoveValues(), REG_CHEQ);

                ARQCHEQ.Write(REG_CHEQ.GetMoveValues().ToString());

                /*" -2292- ADD 1 TO AC-GRAVA */
                ACUMULADORES.AC_GRAVA.Value = ACUMULADORES.AC_GRAVA + 1;

                /*" -2301- ELSE */
            }
            else
            {


                /*" -2302- IF RELATORI-NUM-COPIAS EQUAL 2 OR 3 OR 5 OR 6 OR 7 OR 8 */

                if (RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS.In("2", "3", "5", "6", "7", "8"))
                {

                    /*" -2303- MOVE '0' TO HISLANCT-SIT-REGISTRO */
                    _.Move("0", HISLANCT.DCLHIST_LANC_CTA.HISLANCT_SIT_REGISTRO);

                    /*" -2304- MOVE '2' TO HISLANCT-TIPLANC */
                    _.Move("2", HISLANCT.DCLHIST_LANC_CTA.HISLANCT_TIPLANC);

                    /*" -2308- ELSE */
                }
                else
                {


                    /*" -2309- IF RELATORI-NUM-COPIAS EQUAL ZEROS */

                    if (RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS == 00)
                    {

                        /*" -2310- IF OPCPAGVI-OPCAO-PAGAMENTO EQUAL '1' OR '2' OR '5' */

                        if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO.In("1", "2", "5"))
                        {

                            /*" -2311- MOVE '0' TO HISLANCT-SIT-REGISTRO */
                            _.Move("0", HISLANCT.DCLHIST_LANC_CTA.HISLANCT_SIT_REGISTRO);

                            /*" -2312- MOVE '2' TO HISLANCT-TIPLANC */
                            _.Move("2", HISLANCT.DCLHIST_LANC_CTA.HISLANCT_TIPLANC);

                            /*" -2313- ELSE */
                        }
                        else
                        {


                            /*" -2314- IF OPCPAGVI-OPCAO-PAGAMENTO EQUAL '3' */

                            if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO == "3")
                            {

                                /*" -2315- IF RELATORI-QUANTIDADE > 0 */

                                if (RELATORI.DCLRELATORIOS.RELATORI_QUANTIDADE > 0)
                                {

                                    /*" -2316- MOVE '0' TO HISLANCT-SIT-REGISTRO */
                                    _.Move("0", HISLANCT.DCLHIST_LANC_CTA.HISLANCT_SIT_REGISTRO);

                                    /*" -2317- MOVE '2' TO HISLANCT-TIPLANC */
                                    _.Move("2", HISLANCT.DCLHIST_LANC_CTA.HISLANCT_TIPLANC);

                                    /*" -2318- ELSE */
                                }
                                else
                                {


                                    /*" -2319- MOVE '0' TO HISLANCT-SIT-REGISTRO */
                                    _.Move("0", HISLANCT.DCLHIST_LANC_CTA.HISLANCT_SIT_REGISTRO);

                                    /*" -2320- MOVE '3' TO HISLANCT-TIPLANC */
                                    _.Move("3", HISLANCT.DCLHIST_LANC_CTA.HISLANCT_TIPLANC);

                                    /*" -2322- MOVE RELATORI-NUM-CERTIFICADO TO SAI-NRCERTIF */
                                    _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO, REG_SAIDA.SAI_NRCERTIF);

                                    /*" -2324- MOVE RELATORI-NUM-PARCELA TO SAI-NRPARCEL */
                                    _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA, REG_SAIDA.SAI_NRPARCEL);

                                    /*" -2326- MOVE COBHISVI-PRM-TOTAL TO SAI-VLPREMIO */
                                    _.Move(COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_PRM_TOTAL, REG_SAIDA.SAI_VLPREMIO);

                                    /*" -2328- MOVE RELATORI-COD-USUARIO TO SAI-USUARIO */
                                    _.Move(RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO, REG_SAIDA.SAI_USUARIO);

                                    /*" -2329- IF WQTD-HIST-CONT GREATER ZEROS */

                                    if (WQTD_HIST_CONT > 00)
                                    {

                                        /*" -2330- WRITE REG-CHEQ FROM REG-SAIDA */
                                        _.Move(REG_SAIDA.GetMoveValues(), REG_CHEQ);

                                        ARQCHEQ.Write(REG_CHEQ.GetMoveValues().ToString());

                                        /*" -2331- ADD 1 TO AC-GRAVA */
                                        ACUMULADORES.AC_GRAVA.Value = ACUMULADORES.AC_GRAVA + 1;

                                        /*" -2332- END-IF */
                                    }


                                    /*" -2333- END-IF */
                                }


                                /*" -2334- END-IF */
                            }


                            /*" -2335- END-IF */
                        }


                        /*" -2336- END-IF */
                    }


                    /*" -2337- END-IF */
                }


                /*" -2339- END-IF */
            }


            /*" -2339- . */

        }

        [StopWatch]
        /*" R1150-00-SELECT-OPCAOPAGVA-DB-SELECT-1 */
        public void R1150_00_SELECT_OPCAOPAGVA_DB_SELECT_1()
        {
            /*" -2193- EXEC SQL SELECT OPCAO_PAGAMENTO, COD_AGENCIA_DEBITO, OPE_CONTA_DEBITO, NUM_CONTA_DEBITO, DIG_CONTA_DEBITO INTO :OPCPAGVI-OPCAO-PAGAMENTO, :OPCPAGVI-COD-AGENCIA-DEBITO:VIND-AGE, :OPCPAGVI-OPE-CONTA-DEBITO:VIND-OPE, :OPCPAGVI-NUM-CONTA-DEBITO:VIND-CTA, :OPCPAGVI-DIG-CONTA-DEBITO:VIND-DIG FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO AND DATA_TERVIGENCIA = '9999-12-31' END-EXEC. */

            var r1150_00_SELECT_OPCAOPAGVA_DB_SELECT_1_Query1 = new R1150_00_SELECT_OPCAOPAGVA_DB_SELECT_1_Query1()
            {
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1150_00_SELECT_OPCAOPAGVA_DB_SELECT_1_Query1.Execute(r1150_00_SELECT_OPCAOPAGVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OPCPAGVI_OPCAO_PAGAMENTO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO);
                _.Move(executed_1.OPCPAGVI_COD_AGENCIA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO);
                _.Move(executed_1.VIND_AGE, VIND_AGE);
                _.Move(executed_1.OPCPAGVI_OPE_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO);
                _.Move(executed_1.VIND_OPE, VIND_OPE);
                _.Move(executed_1.OPCPAGVI_NUM_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO);
                _.Move(executed_1.VIND_CTA, VIND_CTA);
                _.Move(executed_1.OPCPAGVI_DIG_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO);
                _.Move(executed_1.VIND_DIG, VIND_DIG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1150_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-UPDATE-HISTCOBVA-SECTION */
        private void R2000_00_UPDATE_HISTCOBVA_SECTION()
        {
            /*" -2523- MOVE 'R2000-00-UPDATE-HISTCOBVA' TO PARAGRAFO. */
            _.Move("R2000-00-UPDATE-HISTCOBVA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2524- MOVE 'UPDATE SEGUROS.COBER_HIST_VIDAZUL' TO COMANDO. */
            _.Move("UPDATE SEGUROS.COBER_HIST_VIDAZUL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2526- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2529- MOVE 'S' TO WS-OPC-PAGTO. */
            _.Move("S", WORK_AREA.WS_OPC_PAGTO);

            /*" -2531- MOVE 501 TO COBHISVI-COD-OPERACAO. */
            _.Move(501, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_COD_OPERACAO);

            /*" -2535- IF (RELATORI-NUM-PARCELA EQUAL 1 AND (PROPOFID-OPCAOPAG EQUAL '1' OR '3' )) */

            if ((RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA == 1 && (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAOPAG.In("1", "3"))))
            {

                /*" -2536- CONTINUE */

                /*" -2537- ELSE */
            }
            else
            {


                /*" -2540- IF RELATORI-NUM-PARCELA EQUAL 1 AND PROPOFID-OPCAOPAG EQUAL '2' */

                if (RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA == 1 && PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAOPAG == "2")
                {

                    /*" -2541- PERFORM R2010-00-SELECT-USUFILSE */

                    R2010_00_SELECT_USUFILSE_SECTION();

                    /*" -2542- IF SQLCODE EQUAL ZEROS */

                    if (DB.SQLCODE == 00)
                    {

                        /*" -2543- MOVE '4' TO COBHISVI-SIT-REGISTRO */
                        _.Move("4", COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_SIT_REGISTRO);

                        /*" -2545- ELSE */
                    }
                    else
                    {


                        /*" -2546- MOVE '2' TO COBHISVI-SIT-REGISTRO */
                        _.Move("2", COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_SIT_REGISTRO);

                        /*" -2547- END-IF */
                    }


                    /*" -2549- COMPUTE COBHISVI-OCORR-HISTORICO = COBHISVI-OCORR-HISTORICO + 1 */
                    COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_OCORR_HISTORICO.Value = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_OCORR_HISTORICO + 1;

                    /*" -2550- ELSE */
                }
                else
                {


                    /*" -2553- IF OPCPAGVI-OPCAO-PAGAMENTO EQUAL '1' OR '2' OR '5' */

                    if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO.In("1", "2", "5"))
                    {

                        /*" -2554- CONTINUE */

                        /*" -2555- ELSE */
                    }
                    else
                    {


                        /*" -2558- IF OPCPAGVI-OPCAO-PAGAMENTO EQUAL '3' */

                        if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO == "3")
                        {

                            /*" -2559- PERFORM R2010-00-SELECT-USUFILSE */

                            R2010_00_SELECT_USUFILSE_SECTION();

                            /*" -2560- IF SQLCODE EQUAL ZEROS */

                            if (DB.SQLCODE == 00)
                            {

                                /*" -2561- MOVE '4' TO COBHISVI-SIT-REGISTRO */
                                _.Move("4", COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_SIT_REGISTRO);

                                /*" -2563- ELSE */
                            }
                            else
                            {


                                /*" -2564- MOVE '2' TO COBHISVI-SIT-REGISTRO */
                                _.Move("2", COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_SIT_REGISTRO);

                                /*" -2565- END-IF */
                            }


                            /*" -2567- COMPUTE COBHISVI-OCORR-HISTORICO = COBHISVI-OCORR-HISTORICO + 1 */
                            COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_OCORR_HISTORICO.Value = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_OCORR_HISTORICO + 1;

                            /*" -2568- ELSE */
                        }
                        else
                        {


                            /*" -2569- MOVE 'N' TO WS-OPC-PAGTO */
                            _.Move("N", WORK_AREA.WS_OPC_PAGTO);

                            /*" -2570- GO TO R2000-99-SAIDA */
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/ //GOTO
                            return;

                            /*" -2571- END-IF */
                        }


                        /*" -2572- END-IF */
                    }


                    /*" -2573- END-IF */
                }


                /*" -2585- END-IF */
            }


            /*" -2587- MOVE ZEROS TO SQLCODE. */
            _.Move(0, DB.SQLCODE);

            /*" -2588- IF OPCPAGVI-OPCAO-PAGAMENTO EQUAL '3' */

            if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO == "3")
            {

                /*" -2599- PERFORM R2000_00_UPDATE_HISTCOBVA_DB_UPDATE_1 */

                R2000_00_UPDATE_HISTCOBVA_DB_UPDATE_1();

                /*" -2603- IF SQLCODE NOT EQUAL ZEROS AND 100 */

                if (!DB.SQLCODE.In("00", "100"))
                {

                    /*" -2604- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2607- END-IF */
                }


                /*" -2608- ADD 1 TO AC-U-COBHISVI */
                ACUMULADORES.AC_U_COBHISVI.Value = ACUMULADORES.AC_U_COBHISVI + 1;

                /*" -2609- END-IF */
            }


            /*" -2609- . */

        }

        [StopWatch]
        /*" R2000-00-UPDATE-HISTCOBVA-DB-UPDATE-1 */
        public void R2000_00_UPDATE_HISTCOBVA_DB_UPDATE_1()
        {
            /*" -2599- EXEC SQL UPDATE SEGUROS.COBER_HIST_VIDAZUL SET DATA_VENCIMENTO = :WHOST-DATA-CRED, PRM_TOTAL = :WHOST-NEW-PRM, SIT_REGISTRO = :COBHISVI-SIT-REGISTRO, COD_OPERACAO = :COBHISVI-COD-OPERACAO, OCORR_HISTORICO = :COBHISVI-OCORR-HISTORICO, COD_DEVOLUCAO = :RELATORI-COD-OPERACAO WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO AND NUM_PARCELA = :RELATORI-NUM-PARCELA END-EXEC */

            var r2000_00_UPDATE_HISTCOBVA_DB_UPDATE_1_Update1 = new R2000_00_UPDATE_HISTCOBVA_DB_UPDATE_1_Update1()
            {
                COBHISVI_OCORR_HISTORICO = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_OCORR_HISTORICO.ToString(),
                COBHISVI_SIT_REGISTRO = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_SIT_REGISTRO.ToString(),
                COBHISVI_COD_OPERACAO = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_COD_OPERACAO.ToString(),
                RELATORI_COD_OPERACAO = RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO.ToString(),
                WHOST_DATA_CRED = WHOST_DATA_CRED.ToString(),
                WHOST_NEW_PRM = WHOST_NEW_PRM.ToString(),
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
                RELATORI_NUM_PARCELA = RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA.ToString(),
            };

            R2000_00_UPDATE_HISTCOBVA_DB_UPDATE_1_Update1.Execute(r2000_00_UPDATE_HISTCOBVA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2010-00-SELECT-USUFILSE-SECTION */
        private void R2010_00_SELECT_USUFILSE_SECTION()
        {
            /*" -2620- MOVE 'R2010-00-SELECT-USUFILSE' TO PARAGRAFO. */
            _.Move("R2010-00-SELECT-USUFILSE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2621- MOVE 'SELECT SEGUROS.USU_FIL_SENHA' TO COMANDO. */
            _.Move("SELECT SEGUROS.USU_FIL_SENHA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2623- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2625- MOVE 'S' TO WTEM-ALCADA. */
            _.Move("S", WORK_AREA.WTEM_ALCADA);

            /*" -2633- PERFORM R2010_00_SELECT_USUFILSE_DB_SELECT_1 */

            R2010_00_SELECT_USUFILSE_DB_SELECT_1();

            /*" -2636- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2637- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2638- MOVE 'N' TO WTEM-ALCADA */
                    _.Move("N", WORK_AREA.WTEM_ALCADA);

                    /*" -2639- ELSE */
                }
                else
                {


                    /*" -2643- DISPLAY 'R2010 (ERRO SELECT USUFILSE) ' RELATORI-NUM-APOLICE ' ' RELATORI-COD-SUBGRUPO ' ' RELATORI-NUM-CERTIFICADO */

                    $"R2010 (ERRO SELECT USUFILSE) {RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE} {RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO} {RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO}"
                    .Display();

                    /*" -2643- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2010-00-SELECT-USUFILSE-DB-SELECT-1 */
        public void R2010_00_SELECT_USUFILSE_DB_SELECT_1()
        {
            /*" -2633- EXEC SQL SELECT COD_CO INTO :USUFILSE-COD-CO FROM SEGUROS.USU_FIL_SENHA WHERE CODUSU = :RELATORI-COD-USUARIO AND NIVEL_AUTORIZACAO = 'S' AND TIPO_FUNCAO = 'DEVOLUCAO EM CHEQUE' AND SITUACAO = ' ' END-EXEC. */

            var r2010_00_SELECT_USUFILSE_DB_SELECT_1_Query1 = new R2010_00_SELECT_USUFILSE_DB_SELECT_1_Query1()
            {
                RELATORI_COD_USUARIO = RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO.ToString(),
            };

            var executed_1 = R2010_00_SELECT_USUFILSE_DB_SELECT_1_Query1.Execute(r2010_00_SELECT_USUFILSE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.USUFILSE_COD_CO, USUFILSE.DCLUSU_FIL_SENHA.USUFILSE_COD_CO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2010_99_SAIDA*/

        [StopWatch]
        /*" R2020-00-VER-CANCELAMENTO-SECTION */
        private void R2020_00_VER_CANCELAMENTO_SECTION()
        {
            /*" -2653- MOVE 'R2020-00-VER-CANCELAMENTO' TO PARAGRAFO */
            _.Move("R2020-00-VER-CANCELAMENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2654- MOVE 'SELECT MOVIMENTO_VGAP' TO COMANDO */
            _.Move("SELECT MOVIMENTO_VGAP", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2656- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2677- PERFORM R2020_00_VER_CANCELAMENTO_DB_SELECT_1 */

            R2020_00_VER_CANCELAMENTO_DB_SELECT_1();

            /*" -2680-  EVALUATE SQLCODE  */

            /*" -2681-  WHEN ZEROS  */

            /*" -2681- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2682- MOVE COBHISVI-COD-DEVOLUCAO TO RELATORI-COD-OPERACAO */
                _.Move(COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_COD_DEVOLUCAO, RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO);

                /*" -2683-  WHEN +100  */

                /*" -2683- ELSE IF   SQLCODE EQUALS  +100 */
            }
            else

            if (DB.SQLCODE == +100)
            {

                /*" -2684- DISPLAY 'ATENCAO: NAO ENCONTROU DATA DE CANCELAMENTO' */
                _.Display($"ATENCAO: NAO ENCONTROU DATA DE CANCELAMENTO");

                /*" -2686- DISPLAY 'ATENCAO: NAO ENCONTROU DATA DE CANCELAMENTO' */
                _.Display($"ATENCAO: NAO ENCONTROU DATA DE CANCELAMENTO");

                /*" -2687-  WHEN -811  */

                /*" -2687- ELSE IF   SQLCODE EQUALS  -811 */
            }
            else

            if (DB.SQLCODE == -811)
            {

                /*" -2688- PERFORM R2021-00-VER-CANCELAMENTO */

                R2021_00_VER_CANCELAMENTO_SECTION();

                /*" -2689-  WHEN OTHER  */

                /*" -2689- ELSE */
            }
            else
            {


                /*" -2690- DISPLAY 'R2020 (ERRO SELECT MOVIMENTO_VGAP)' */
                _.Display($"R2020 (ERRO SELECT MOVIMENTO_VGAP)");

                /*" -2691- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2693-  END-EVALUATE  */

                /*" -2693- END-IF */
            }


            /*" -2693- . */

        }

        [StopWatch]
        /*" R2020-00-VER-CANCELAMENTO-DB-SELECT-1 */
        public void R2020_00_VER_CANCELAMENTO_DB_SELECT_1()
        {
            /*" -2677- EXEC SQL SELECT T1.NUM_CERTIFICADO , T1.COD_OPERACAO , T1.DATA_OPERACAO INTO :MOVIMVGA-NUM-CERTIFICADO , :MOVIMVGA-COD-OPERACAO, :MOVIMVGA-DATA-OPERACAO FROM SEGUROS.MOVIMENTO_VGAP T1, SEGUROS.SEGURADOS_VGAP T2 WHERE T1.NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO AND T1.COD_OPERACAO BETWEEN 0400 AND 0499 AND T1.NUM_CERTIFICADO = T2.NUM_CERTIFICADO AND NOT EXISTS ( SELECT T3.NUM_APOLICE, T3.NUM_ITEM FROM SEGUROS.SEGURADOSVGAP_HIST T3 WHERE T3.NUM_APOLICE = T2.NUM_APOLICE AND T3.NUM_ITEM = T2.NUM_ITEM AND T3.COD_OPERACAO BETWEEN 0500 AND 0599 AND T3.DATA_OPERACAO > T1.DATA_OPERACAO ) WITH UR END-EXEC */

            var r2020_00_VER_CANCELAMENTO_DB_SELECT_1_Query1 = new R2020_00_VER_CANCELAMENTO_DB_SELECT_1_Query1()
            {
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R2020_00_VER_CANCELAMENTO_DB_SELECT_1_Query1.Execute(r2020_00_VER_CANCELAMENTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVIMVGA_NUM_CERTIFICADO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO);
                _.Move(executed_1.MOVIMVGA_COD_OPERACAO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO);
                _.Move(executed_1.MOVIMVGA_DATA_OPERACAO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_OPERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2020_99_SAIDA*/

        [StopWatch]
        /*" R2021-00-VER-CANCELAMENTO-SECTION */
        private void R2021_00_VER_CANCELAMENTO_SECTION()
        {
            /*" -2703- MOVE 'R2021-00-VER-CANCELAMENTO' TO PARAGRAFO */
            _.Move("R2021-00-VER-CANCELAMENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2704- MOVE 'SELECT MOVIMENTO_VGAP 2' TO COMANDO */
            _.Move("SELECT MOVIMENTO_VGAP 2", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2706- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2724- PERFORM R2021_00_VER_CANCELAMENTO_DB_SELECT_1 */

            R2021_00_VER_CANCELAMENTO_DB_SELECT_1();

            /*" -2727-  EVALUATE SQLCODE  */

            /*" -2728-  WHEN ZEROS  */

            /*" -2728- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2729- MOVE COBHISVI-COD-DEVOLUCAO TO RELATORI-COD-OPERACAO */
                _.Move(COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_COD_DEVOLUCAO, RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO);

                /*" -2730-  WHEN -811  */

                /*" -2730- ELSE IF   SQLCODE EQUALS  -811 */
            }
            else

            if (DB.SQLCODE == -811)
            {

                /*" -2731- PERFORM R2022-00-VER-CANCELAMENTO */

                R2022_00_VER_CANCELAMENTO_SECTION();

                /*" -2732-  WHEN OTHER  */

                /*" -2732- ELSE */
            }
            else
            {


                /*" -2733- DISPLAY 'R2021 (ERRO SELECT MOVIMENTO_VGAP 2)' */
                _.Display($"R2021 (ERRO SELECT MOVIMENTO_VGAP 2)");

                /*" -2734- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2736-  END-EVALUATE  */

                /*" -2736- END-IF */
            }


            /*" -2736- . */

        }

        [StopWatch]
        /*" R2021-00-VER-CANCELAMENTO-DB-SELECT-1 */
        public void R2021_00_VER_CANCELAMENTO_DB_SELECT_1()
        {
            /*" -2724- EXEC SQL SELECT T1.NUM_CERTIFICADO , T1.COD_OPERACAO , T1.DATA_OPERACAO INTO :MOVIMVGA-NUM-CERTIFICADO , :MOVIMVGA-COD-OPERACAO , :MOVIMVGA-DATA-OPERACAO FROM SEGUROS.MOVIMENTO_VGAP T1 WHERE T1.NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO AND T1.COD_OPERACAO BETWEEN 0400 AND 0499 AND NOT EXISTS ( SELECT T2.NUM_CERTIFICADO FROM SEGUROS.MOVIMENTO_VGAP T2 WHERE T2.NUM_CERTIFICADO = T1.NUM_CERTIFICADO AND T2.COD_OPERACAO BETWEEN 0500 AND 0599 AND T2.DATA_OPERACAO > T1.DATA_OPERACAO ) WITH UR END-EXEC */

            var r2021_00_VER_CANCELAMENTO_DB_SELECT_1_Query1 = new R2021_00_VER_CANCELAMENTO_DB_SELECT_1_Query1()
            {
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R2021_00_VER_CANCELAMENTO_DB_SELECT_1_Query1.Execute(r2021_00_VER_CANCELAMENTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVIMVGA_NUM_CERTIFICADO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO);
                _.Move(executed_1.MOVIMVGA_COD_OPERACAO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO);
                _.Move(executed_1.MOVIMVGA_DATA_OPERACAO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_OPERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2021_99_SAIDA*/

        [StopWatch]
        /*" R2022-00-VER-CANCELAMENTO-SECTION */
        private void R2022_00_VER_CANCELAMENTO_SECTION()
        {
            /*" -2746- MOVE 'R2022-00-VER-CANCELAMENTO' TO PARAGRAFO */
            _.Move("R2022-00-VER-CANCELAMENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2747- MOVE 'SELECT MOVIMENTO_VGAP 3' TO COMANDO */
            _.Move("SELECT MOVIMENTO_VGAP 3", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2749- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2762- PERFORM R2022_00_VER_CANCELAMENTO_DB_SELECT_1 */

            R2022_00_VER_CANCELAMENTO_DB_SELECT_1();

            /*" -2765-  EVALUATE SQLCODE  */

            /*" -2766-  WHEN ZEROS  */

            /*" -2766- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2767- MOVE COBHISVI-COD-DEVOLUCAO TO RELATORI-COD-OPERACAO */
                _.Move(COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_COD_DEVOLUCAO, RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO);

                /*" -2768-  WHEN OTHER  */

                /*" -2768- ELSE */
            }
            else
            {


                /*" -2769- DISPLAY 'R2022 (ERRO SELECT MOVIMENTO_VGAP 3)' */
                _.Display($"R2022 (ERRO SELECT MOVIMENTO_VGAP 3)");

                /*" -2770- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2772-  END-EVALUATE  */

                /*" -2772- END-IF */
            }


            /*" -2772- . */

        }

        [StopWatch]
        /*" R2022-00-VER-CANCELAMENTO-DB-SELECT-1 */
        public void R2022_00_VER_CANCELAMENTO_DB_SELECT_1()
        {
            /*" -2762- EXEC SQL SELECT T1.NUM_CERTIFICADO , T1.COD_OPERACAO , T1.DATA_OPERACAO INTO :MOVIMVGA-NUM-CERTIFICADO , :MOVIMVGA-COD-OPERACAO , :MOVIMVGA-DATA-OPERACAO FROM SEGUROS.MOVIMENTO_VGAP T1 WHERE T1.NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO AND T1.COD_OPERACAO BETWEEN 0400 AND 0499 ORDER BY T1.DATA_OPERACAO DESC FETCH FIRST 1 ROW ONLY WITH UR END-EXEC */

            var r2022_00_VER_CANCELAMENTO_DB_SELECT_1_Query1 = new R2022_00_VER_CANCELAMENTO_DB_SELECT_1_Query1()
            {
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R2022_00_VER_CANCELAMENTO_DB_SELECT_1_Query1.Execute(r2022_00_VER_CANCELAMENTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVIMVGA_NUM_CERTIFICADO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO);
                _.Move(executed_1.MOVIMVGA_COD_OPERACAO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO);
                _.Move(executed_1.MOVIMVGA_DATA_OPERACAO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_OPERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2022_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-PROCESSA-HISTLANCCTA-SECTION */
        private void R2100_00_PROCESSA_HISTLANCCTA_SECTION()
        {
            /*" -2782- MOVE 'R2100-00-PROCESSA-HISTLANCCTA' TO PARAGRAFO. */
            _.Move("R2100-00-PROCESSA-HISTLANCCTA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2783- IF RELATORI-NUM-COPIAS EQUAL 6 OR 7 OR 8 */

            if (RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS.In("6", "7", "8"))
            {

                /*" -2784- IF RELATORI-NUM-COPIAS EQUAL 7 */

                if (RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS == 7)
                {

                    /*" -2785- IF ( RELATORI-NUM-APOL-LIDER(1:5) EQUAL 'R6090' ) */

                    if ((RELATORI.DCLRELATORIOS.RELATORI_NUM_APOL_LIDER.Substring(1, 5) == "R6090"))
                    {

                        /*" -2786- MOVE 6090 TO WS-COD-CONVENIO */
                        _.Move(6090, WS_COD_CONVENIO);

                        /*" -2787- ELSE */
                    }
                    else
                    {


                        /*" -2788- MOVE 9022 TO WS-COD-CONVENIO */
                        _.Move(9022, WS_COD_CONVENIO);

                        /*" -2789- END-IF */
                    }


                    /*" -2790- ELSE */
                }
                else
                {


                    /*" -2791- MOVE 9022 TO WS-COD-CONVENIO */
                    _.Move(9022, WS_COD_CONVENIO);

                    /*" -2793- END-IF */
                }


                /*" -2795- PERFORM R1120-00-SELECT-HISLANCT */

                R1120_00_SELECT_HISLANCT_SECTION();

                /*" -2796- IF WS-OCORR-HISTORICOCTA NOT EQUAL ZEROS */

                if (WS_OCORR_HISTORICOCTA != 00)
                {

                    /*" -2797- PERFORM R2170-00-UPDATE-HISTLANCCTA */

                    R2170_00_UPDATE_HISTLANCCTA_SECTION();

                    /*" -2799- END-IF */
                }


                /*" -2800- IF ( RELATORI-NUM-APOL-LIDER(1:5) EQUAL 'S9022' ) */

                if ((RELATORI.DCLRELATORIOS.RELATORI_NUM_APOL_LIDER.Substring(1, 5) == "S9022"))
                {

                    /*" -2801- MOVE 6090 TO WS-COD-CONVENIO */
                    _.Move(6090, WS_COD_CONVENIO);

                    /*" -2802- END-IF */
                }


                /*" -2804- END-IF */
            }


            /*" -2806- MOVE ZEROS TO VIND-BANCO. */
            _.Move(0, VIND_BANCO);

            /*" -2807- MOVE 'SELECT SEGUROS.CONVENIOS_VG' TO COMANDO. */
            _.Move("SELECT SEGUROS.CONVENIOS_VG", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2810- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2816- PERFORM R2100_00_PROCESSA_HISTLANCCTA_DB_SELECT_1 */

            R2100_00_PROCESSA_HISTLANCCTA_DB_SELECT_1();

            /*" -2819-  EVALUATE SQLCODE  */

            /*" -2820-  WHEN ZEROS  */

            /*" -2820- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2821- CONTINUE */

                /*" -2822-  WHEN +100  */

                /*" -2822- ELSE IF   SQLCODE EQUALS  +100 */
            }
            else

            if (DB.SQLCODE == +100)
            {

                /*" -2823- MOVE 6090 TO CONVEVG-COD-NAOACEITE */
                _.Move(6090, CONVEVG.DCLCONVENIOS_VG.CONVEVG_COD_NAOACEITE);

                /*" -2824-  WHEN OTHER  */

                /*" -2824- ELSE */
            }
            else
            {


                /*" -2827- DISPLAY 'R2100 (ERRO SELECT CONVENIOS_VG) ' RELATORI-NUM-APOLICE ' ' RELATORI-COD-SUBGRUPO */

                $"R2100 (ERRO SELECT CONVENIOS_VG) {RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE} {RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO}"
                .Display();

                /*" -2828- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2830-  END-EVALUATE  */

                /*" -2830- END-IF */
            }


            /*" -2832- IF RELATORI-NUM-PARCELA EQUAL 1 AND PROPOFID-OPCAOPAG EQUAL '3' */

            if (RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA == 1 && PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAOPAG == "3")
            {

                /*" -2833- IF RELATORI-NUM-COPIAS EQUAL 5 */

                if (RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS == 5)
                {

                    /*" -2834- MOVE 9021 TO CONVEVG-COD-NAOACEITE */
                    _.Move(9021, CONVEVG.DCLCONVENIOS_VG.CONVEVG_COD_NAOACEITE);

                    /*" -2835- ELSE */
                }
                else
                {


                    /*" -2836- MOVE 9022 TO CONVEVG-COD-NAOACEITE */
                    _.Move(9022, CONVEVG.DCLCONVENIOS_VG.CONVEVG_COD_NAOACEITE);

                    /*" -2837- END-IF */
                }


                /*" -2838- ELSE */
            }
            else
            {


                /*" -2840- IF RELATORI-NUM-PARCELA > 1 AND OPCPAGVI-OPCAO-PAGAMENTO EQUAL '5' */

                if (RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA > 1 && OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO == "5")
                {

                    /*" -2841- IF RELATORI-NUM-COPIAS EQUAL 5 */

                    if (RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS == 5)
                    {

                        /*" -2842- MOVE 9021 TO CONVEVG-COD-NAOACEITE */
                        _.Move(9021, CONVEVG.DCLCONVENIOS_VG.CONVEVG_COD_NAOACEITE);

                        /*" -2843- ELSE */
                    }
                    else
                    {


                        /*" -2844- MOVE 9022 TO CONVEVG-COD-NAOACEITE */
                        _.Move(9022, CONVEVG.DCLCONVENIOS_VG.CONVEVG_COD_NAOACEITE);

                        /*" -2845- END-IF */
                    }


                    /*" -2846- END-IF */
                }


                /*" -2850- END-IF */
            }


            /*" -2852- MOVE 'INSERT SEGUROS.HIST_LANC_CTA' TO COMANDO. */
            _.Move("INSERT SEGUROS.HIST_LANC_CTA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2856- IF RELATORI-QUANTIDADE > 0 AND RELATORI-MES-REFERENCIA > 0 AND RELATORI-NUM-SINISTRO > 0 */

            if (RELATORI.DCLRELATORIOS.RELATORI_QUANTIDADE > 0 && RELATORI.DCLRELATORIOS.RELATORI_MES_REFERENCIA > 0 && RELATORI.DCLRELATORIOS.RELATORI_NUM_SINISTRO > 0)
            {

                /*" -2858- MOVE RELATORI-QUANTIDADE TO HISLANCT-COD-BANCO */
                _.Move(RELATORI.DCLRELATORIOS.RELATORI_QUANTIDADE, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_COD_BANCO);

                /*" -2860- MOVE RELATORI-MES-REFERENCIA TO OPCPAGVI-COD-AGENCIA-DEBITO */
                _.Move(RELATORI.DCLRELATORIOS.RELATORI_MES_REFERENCIA, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO);

                /*" -2862- MOVE RELATORI-ANO-REFERENCIA TO OPCPAGVI-OPE-CONTA-DEBITO */
                _.Move(RELATORI.DCLRELATORIOS.RELATORI_ANO_REFERENCIA, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO);

                /*" -2865- MOVE RELATORI-ORGAO-EMISSOR TO OPCPAGVI-DIG-CONTA-DEBITO */
                _.Move(RELATORI.DCLRELATORIOS.RELATORI_ORGAO_EMISSOR, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO);

                /*" -2867- MOVE RELATORI-NUM-SINISTRO TO OPCPAGVI-NUM-CONTA-DEBITO */
                _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_SINISTRO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO);

                /*" -2869- END-IF. */
            }


            /*" -2870- IF RELATORI-QUANTIDADE > 0 */

            if (RELATORI.DCLRELATORIOS.RELATORI_QUANTIDADE > 0)
            {

                /*" -2872- MOVE RELATORI-QUANTIDADE TO HISLANCT-COD-BANCO */
                _.Move(RELATORI.DCLRELATORIOS.RELATORI_QUANTIDADE, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_COD_BANCO);

                /*" -2874- END-IF. */
            }


            /*" -2875- IF RELATORI-QUANTIDADE EQUAL ZEROS */

            if (RELATORI.DCLRELATORIOS.RELATORI_QUANTIDADE == 00)
            {

                /*" -2876- MOVE -1 TO VIND-BANCO */
                _.Move(-1, VIND_BANCO);

                /*" -2878- END-IF. */
            }


            /*" -2879- MOVE -1 TO VIND-CODRET */
            _.Move(-1, VIND_CODRET);

            /*" -2880- MOVE ZEROS TO HISLANCT-CODRET */
            _.Move(0, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_CODRET);

            /*" -2880- . */

        }

        [StopWatch]
        /*" R2100-00-PROCESSA-HISTLANCCTA-DB-SELECT-1 */
        public void R2100_00_PROCESSA_HISTLANCCTA_DB_SELECT_1()
        {
            /*" -2816- EXEC SQL SELECT COD_NAOACEITE INTO :CONVEVG-COD-NAOACEITE FROM SEGUROS.CONVENIOS_VG WHERE NUM_APOLICE = :RELATORI-NUM-APOLICE AND CODSUBES = :RELATORI-COD-SUBGRUPO END-EXEC */

            var r2100_00_PROCESSA_HISTLANCCTA_DB_SELECT_1_Query1 = new R2100_00_PROCESSA_HISTLANCCTA_DB_SELECT_1_Query1()
            {
                RELATORI_COD_SUBGRUPO = RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO.ToString(),
                RELATORI_NUM_APOLICE = RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE.ToString(),
            };

            var executed_1 = R2100_00_PROCESSA_HISTLANCCTA_DB_SELECT_1_Query1.Execute(r2100_00_PROCESSA_HISTLANCCTA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONVEVG_COD_NAOACEITE, CONVEVG.DCLCONVENIOS_VG.CONVEVG_COD_NAOACEITE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2150-00-INSERT-HISTLANCCTA-SECTION */
        private void R2150_00_INSERT_HISTLANCCTA_SECTION()
        {
            /*" -2886- MOVE 'R2150-00-INSERT-HISTLANCCTA' TO PARAGRAFO. */
            _.Move("R2150-00-INSERT-HISTLANCCTA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -0- FLUXCONTROL_PERFORM R2150_05_INSERT_HISTLANCCTA */

            R2150_05_INSERT_HISTLANCCTA();

        }

        [StopWatch]
        /*" R2150-05-INSERT-HISTLANCCTA */
        private void R2150_05_INSERT_HISTLANCCTA(bool isPerform = false)
        {
            /*" -2890- MOVE 'INSERT SEGUROS.HIST_LANC_CTA' TO COMANDO. */
            _.Move("INSERT SEGUROS.HIST_LANC_CTA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2892- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2894- ADD 1 TO PARCEVID-OCORR-HISTORICO. */
            PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_OCORR_HISTORICO.Value = PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_OCORR_HISTORICO + 1;

            /*" -2939- PERFORM R2150_05_INSERT_HISTLANCCTA_DB_INSERT_1 */

            R2150_05_INSERT_HISTLANCCTA_DB_INSERT_1();

            /*" -2942- IF (SQLCODE NOT EQUAL ZEROES AND -803) */

            if ((!DB.SQLCODE.In("00", "-803")))
            {

                /*" -2943- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.WSQLCODE);

                /*" -2945- DISPLAY 'ERRO R2150 - INSERT DA HIST_LANC_CTA SQLCODE = ' WSQLCODE */
                _.Display($"ERRO R2150 - INSERT DA HIST_LANC_CTA SQLCODE = {WABEND.WSQLCODE}");

                /*" -2946- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2948- END-IF. */
            }


            /*" -2949- IF (SQLCODE EQUAL -803) */

            if ((DB.SQLCODE == -803))
            {

                /*" -2953- DISPLAY 'ERRO -803 HIST_LANC_CTA ' RELATORI-NUM-CERTIFICADO ' >> ' RELATORI-NUM-PARCELA ' >> ' PARCEVID-OCORR-HISTORICO */

                $"ERRO -803 HIST_LANC_CTA {RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO} >> {RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA} >> {PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_OCORR_HISTORICO}"
                .Display();

                /*" -2954- IF PARCEVID-OCORR-HISTORICO > 30 */

                if (PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_OCORR_HISTORICO > 30)
                {

                    /*" -2956- DISPLAY 'ERRO R2150 - INSERT HIST_LANC_CTA SQLCODE = ' WSQLCODE */
                    _.Display($"ERRO R2150 - INSERT HIST_LANC_CTA SQLCODE = {WABEND.WSQLCODE}");

                    /*" -2957- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2958- ELSE */
                }
                else
                {


                    /*" -2959- GO TO R2150-05-INSERT-HISTLANCCTA */
                    new Task(() => R2150_05_INSERT_HISTLANCCTA()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -2960- END-IF */
                }


                /*" -2961- ELSE */
            }
            else
            {


                /*" -2962- IF (SQLCODE EQUAL ZEROS) */

                if ((DB.SQLCODE == 00))
                {

                    /*" -2963- ADD 1 TO AC-I-HISLANCT */
                    ACUMULADORES.AC_I_HISLANCT.Value = ACUMULADORES.AC_I_HISLANCT + 1;

                    /*" -2964- END-IF */
                }


                /*" -2965- END-IF */
            }


            /*" -2965- . */

        }

        [StopWatch]
        /*" R2150-05-INSERT-HISTLANCCTA-DB-INSERT-1 */
        public void R2150_05_INSERT_HISTLANCCTA_DB_INSERT_1()
        {
            /*" -2939- EXEC SQL INSERT INTO SEGUROS.HIST_LANC_CTA (NUM_CERTIFICADO, NUM_PARCELA, OCORR_HISTORICOCTA, COD_AGENCIA_DEBITO, OPE_CONTA_DEBITO, NUM_CONTA_DEBITO, DIG_CONTA_DEBITO, DATA_VENCIMENTO, PRM_TOTAL, SIT_REGISTRO, TIPLANC, TIMESTAMP, OCORR_HISTORICO, CODCONV, NSAS, NSL, NSAC, CODRET, COD_USUARIO, NUM_CARTAO_CREDITO, COD_BANCO) VALUES (:RELATORI-NUM-CERTIFICADO, :RELATORI-NUM-PARCELA, :PARCEVID-OCORR-HISTORICO, :OPCPAGVI-COD-AGENCIA-DEBITO, :OPCPAGVI-OPE-CONTA-DEBITO, :OPCPAGVI-NUM-CONTA-DEBITO, :OPCPAGVI-DIG-CONTA-DEBITO, :WHOST-DATA-CRED, :WHOST-NEW-PRM, :HISLANCT-SIT-REGISTRO, :HISLANCT-TIPLANC, CURRENT TIMESTAMP, 1, :CONVEVG-COD-NAOACEITE, NULL, NULL, NULL, :HISLANCT-CODRET :VIND-CODRET, :RELATORI-COD-USUARIO, 0, :HISLANCT-COD-BANCO:VIND-BANCO) END-EXEC. */

            var r2150_05_INSERT_HISTLANCCTA_DB_INSERT_1_Insert1 = new R2150_05_INSERT_HISTLANCCTA_DB_INSERT_1_Insert1()
            {
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
                RELATORI_NUM_PARCELA = RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA.ToString(),
                PARCEVID_OCORR_HISTORICO = PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_OCORR_HISTORICO.ToString(),
                OPCPAGVI_COD_AGENCIA_DEBITO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO.ToString(),
                OPCPAGVI_OPE_CONTA_DEBITO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO.ToString(),
                OPCPAGVI_NUM_CONTA_DEBITO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO.ToString(),
                OPCPAGVI_DIG_CONTA_DEBITO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO.ToString(),
                WHOST_DATA_CRED = WHOST_DATA_CRED.ToString(),
                WHOST_NEW_PRM = WHOST_NEW_PRM.ToString(),
                HISLANCT_SIT_REGISTRO = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_SIT_REGISTRO.ToString(),
                HISLANCT_TIPLANC = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_TIPLANC.ToString(),
                CONVEVG_COD_NAOACEITE = CONVEVG.DCLCONVENIOS_VG.CONVEVG_COD_NAOACEITE.ToString(),
                HISLANCT_CODRET = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_CODRET.ToString(),
                VIND_CODRET = VIND_CODRET.ToString(),
                RELATORI_COD_USUARIO = RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO.ToString(),
                HISLANCT_COD_BANCO = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_COD_BANCO.ToString(),
                VIND_BANCO = VIND_BANCO.ToString(),
            };

            R2150_05_INSERT_HISTLANCCTA_DB_INSERT_1_Insert1.Execute(r2150_05_INSERT_HISTLANCCTA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2150_99_SAIDA*/

        [StopWatch]
        /*" R2170-00-UPDATE-HISTLANCCTA-SECTION */
        private void R2170_00_UPDATE_HISTLANCCTA_SECTION()
        {
            /*" -2973- MOVE 'R2170-00-UPDATE-HISTLANCCTA' TO PARAGRAFO. */
            _.Move("R2170-00-UPDATE-HISTLANCCTA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2974- MOVE 'UPDATE SEGUROS.HIST_LANC_CTA' TO COMANDO. */
            _.Move("UPDATE SEGUROS.HIST_LANC_CTA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2976- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2987- PERFORM R2170_00_UPDATE_HISTLANCCTA_DB_UPDATE_1 */

            R2170_00_UPDATE_HISTLANCCTA_DB_UPDATE_1();

            /*" -2990- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -2992- DISPLAY 'UPDATE DA HIST_LANC_CTA SQLCODE = ' WSQLCODE */
            _.Display($"UPDATE DA HIST_LANC_CTA SQLCODE = {WABEND.WSQLCODE}");

            /*" -2993- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -2994- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.WSQLCODE);

                /*" -2996- DISPLAY 'ERRO R2170 - UPDATE DA HIST_LANC_CTA SQLCODE = ' WSQLCODE */
                _.Display($"ERRO R2170 - UPDATE DA HIST_LANC_CTA SQLCODE = {WABEND.WSQLCODE}");

                /*" -2997- DISPLAY 'NUM-CERTIFICADO....: ' RELATORI-NUM-CERTIFICADO */
                _.Display($"NUM-CERTIFICADO....: {RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO}");

                /*" -2998- DISPLAY 'NUM-PARCELA........: ' RELATORI-NUM-PARCELA */
                _.Display($"NUM-PARCELA........: {RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA}");

                /*" -2999- DISPLAY 'COD-CONVENIO.......: ' WS-COD-CONVENIO */
                _.Display($"COD-CONVENIO.......: {WS_COD_CONVENIO}");

                /*" -3000- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3001- ELSE */
            }
            else
            {


                /*" -3002- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -3003- ADD 1 TO AC-U-HISLANCT */
                    ACUMULADORES.AC_U_HISLANCT.Value = ACUMULADORES.AC_U_HISLANCT + 1;

                    /*" -3004- END-IF */
                }


                /*" -3005- END-IF */
            }


            /*" -3005- . */

        }

        [StopWatch]
        /*" R2170-00-UPDATE-HISTLANCCTA-DB-UPDATE-1 */
        public void R2170_00_UPDATE_HISTLANCCTA_DB_UPDATE_1()
        {
            /*" -2987- EXEC SQL UPDATE SEGUROS.HIST_LANC_CTA SET SIT_REGISTRO = '2' , TIMESTAMP = CURRENT_TIMESTAMP, COD_USUARIO = 'VA0469B' , CODRET = 2 WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO AND NUM_PARCELA = :RELATORI-NUM-PARCELA AND TIPLANC = '2' AND SIT_REGISTRO = ' ' AND CODCONV = :WS-COD-CONVENIO END-EXEC. */

            var r2170_00_UPDATE_HISTLANCCTA_DB_UPDATE_1_Update1 = new R2170_00_UPDATE_HISTLANCCTA_DB_UPDATE_1_Update1()
            {
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
                RELATORI_NUM_PARCELA = RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA.ToString(),
                WS_COD_CONVENIO = WS_COD_CONVENIO.ToString(),
            };

            R2170_00_UPDATE_HISTLANCCTA_DB_UPDATE_1_Update1.Execute(r2170_00_UPDATE_HISTLANCCTA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2170_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-UPDATE-PARCELVA-SECTION */
        private void R2200_00_UPDATE_PARCELVA_SECTION()
        {
            /*" -3016- MOVE 'R2200-00-UPDATE-PARCELVA' TO PARAGRAFO. */
            _.Move("R2200-00-UPDATE-PARCELVA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3017- MOVE 'UPDATE SEGUROS.PARCELAS_VIDAZUL' TO COMANDO. */
            _.Move("UPDATE SEGUROS.PARCELAS_VIDAZUL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3022- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3030- PERFORM R2200_00_UPDATE_PARCELVA_DB_UPDATE_1 */

            R2200_00_UPDATE_PARCELVA_DB_UPDATE_1();

            /*" -3034- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -3036- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3036- ADD 1 TO AC-U-PARCEVID. */
            ACUMULADORES.AC_U_PARCEVID.Value = ACUMULADORES.AC_U_PARCEVID + 1;

        }

        [StopWatch]
        /*" R2200-00-UPDATE-PARCELVA-DB-UPDATE-1 */
        public void R2200_00_UPDATE_PARCELVA_DB_UPDATE_1()
        {
            /*" -3030- EXEC SQL UPDATE SEGUROS.PARCELAS_VIDAZUL SET VLMULTA = :WHOST-JUROS, OCORR_HISTORICO = :PARCEVID-OCORR-HISTORICO WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO AND NUM_PARCELA = :RELATORI-NUM-PARCELA END-EXEC. */

            var r2200_00_UPDATE_PARCELVA_DB_UPDATE_1_Update1 = new R2200_00_UPDATE_PARCELVA_DB_UPDATE_1_Update1()
            {
                PARCEVID_OCORR_HISTORICO = PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_OCORR_HISTORICO.ToString(),
                WHOST_JUROS = WHOST_JUROS.ToString(),
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
                RELATORI_NUM_PARCELA = RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA.ToString(),
            };

            R2200_00_UPDATE_PARCELVA_DB_UPDATE_1_Update1.Execute(r2200_00_UPDATE_PARCELVA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2250-00-SELECT-PROPOSTAVA-SECTION */
        private void R2250_00_SELECT_PROPOSTAVA_SECTION()
        {
            /*" -3046- MOVE 'R2250-00-SELECT-PROPOSTAVA' TO PARAGRAFO. */
            _.Move("R2250-00-SELECT-PROPOSTAVA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3047- MOVE 'SELECT SEGUROS.PROPOSTAS_VA' TO COMANDO. */
            _.Move("SELECT SEGUROS.PROPOSTAS_VA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3049- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3056- PERFORM R2250_00_SELECT_PROPOSTAVA_DB_SELECT_1 */

            R2250_00_SELECT_PROPOSTAVA_DB_SELECT_1();

            /*" -3059- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3059- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2250-00-SELECT-PROPOSTAVA-DB-SELECT-1 */
        public void R2250_00_SELECT_PROPOSTAVA_DB_SELECT_1()
        {
            /*" -3056- EXEC SQL SELECT SIT_REGISTRO, COD_PRODUTO INTO :PROPOVA-SIT-REGISTRO, :PROPOVA-COD-PRODUTO FROM SEGUROS.PROPOSTAS_VA WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO END-EXEC. */

            var r2250_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1 = new R2250_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1()
            {
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R2250_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1.Execute(r2250_00_SELECT_PROPOSTAVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOVA_SIT_REGISTRO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);
                _.Move(executed_1.PROPOVA_COD_PRODUTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2250_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-UPDATE-PROPOSTAVA-SECTION */
        private void R2300_00_UPDATE_PROPOSTAVA_SECTION()
        {
            /*" -3069- MOVE 'R2300-00-UPDATE-PROPOSTAVA' TO PARAGRAFO. */
            _.Move("R2300-00-UPDATE-PROPOSTAVA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3071- MOVE 'UPDATE SEGUROS.PROPOSTAS_VA' TO COMANDO. */
            _.Move("UPDATE SEGUROS.PROPOSTAS_VA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3072- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3073- IF RELATORI-NUM-PARCELA = 1 */

            if (RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA == 1)
            {

                /*" -3077- MOVE '2' TO PROPOVA-SIT-REGISTRO */
                _.Move("2", PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);

                /*" -3087- PERFORM R2300_00_UPDATE_PROPOSTAVA_DB_UPDATE_1 */

                R2300_00_UPDATE_PROPOSTAVA_DB_UPDATE_1();

                /*" -3091- IF SQLCODE NOT EQUAL ZEROS AND 100 */

                if (!DB.SQLCODE.In("00", "100"))
                {

                    /*" -3092- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3093- END-IF */
                }


                /*" -3093- ADD 1 TO AC-U-PROPOVA. */
                ACUMULADORES.AC_U_PROPOVA.Value = ACUMULADORES.AC_U_PROPOVA + 1;
            }


        }

        [StopWatch]
        /*" R2300-00-UPDATE-PROPOSTAVA-DB-UPDATE-1 */
        public void R2300_00_UPDATE_PROPOSTAVA_DB_UPDATE_1()
        {
            /*" -3087- EXEC SQL UPDATE SEGUROS.PROPOSTAS_VA SET SIT_REGISTRO = :PROPOVA-SIT-REGISTRO, TIMESTAMP = CURRENT TIMESTAMP, DATA_MOVIMENTO = :SISTEMAS-DATA-MOV-ABERTO, DTA_DECLINIO = :WDTA-DECLINIO, COD_USUARIO = :RELATORI-COD-USUARIO WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO END-EXEC */

            var r2300_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1 = new R2300_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                PROPOVA_SIT_REGISTRO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO.ToString(),
                RELATORI_COD_USUARIO = RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO.ToString(),
                WDTA_DECLINIO = WDTA_DECLINIO.ToString(),
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
            };

            R2300_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1.Execute(r2300_00_UPDATE_PROPOSTAVA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R2400-00-INSERT-HISTCONTABILVA-SECTION */
        private void R2400_00_INSERT_HISTCONTABILVA_SECTION()
        {
            /*" -3103- MOVE 'R2400-00-INSERT-HISTCONTABILVA' TO PARAGRAFO. */
            _.Move("R2400-00-INSERT-HISTCONTABILVA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3104- MOVE 'INSERT SEGUROS.HIST_CONT_PARCELVA' TO COMANDO. */
            _.Move("INSERT SEGUROS.HIST_CONT_PARCELVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3106- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3139- PERFORM R2400_00_INSERT_HISTCONTABILVA_DB_INSERT_1 */

            R2400_00_INSERT_HISTCONTABILVA_DB_INSERT_1();

            /*" -3143- IF SQLCODE NOT EQUAL ZEROS AND -803 */

            if (!DB.SQLCODE.In("00", "-803"))
            {

                /*" -3144- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.WSQLCODE);

                /*" -3146- DISPLAY 'ERRO - INSERT HIST_CONT_PARCELVA SQLCODE = ' WSQLCODE */
                _.Display($"ERRO - INSERT HIST_CONT_PARCELVA SQLCODE = {WABEND.WSQLCODE}");

                /*" -3148- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3148- ADD 1 TO AC-I-HISCONPA. */
            ACUMULADORES.AC_I_HISCONPA.Value = ACUMULADORES.AC_I_HISCONPA + 1;

        }

        [StopWatch]
        /*" R2400-00-INSERT-HISTCONTABILVA-DB-INSERT-1 */
        public void R2400_00_INSERT_HISTCONTABILVA_DB_INSERT_1()
        {
            /*" -3139- EXEC SQL INSERT INTO SEGUROS.HIST_CONT_PARCELVA (NUM_CERTIFICADO, NUM_PARCELA, NUM_TITULO, OCORR_HISTORICO, NUM_APOLICE, COD_SUBGRUPO, COD_FONTE, NUM_ENDOSSO, PREMIO_VG, PREMIO_AP, DATA_MOVIMENTO, SIT_REGISTRO, COD_OPERACAO, TIMESTAMP, DTFATUR) VALUES (:RELATORI-NUM-CERTIFICADO, :RELATORI-NUM-PARCELA, :COBHISVI-NUM-TITULO, :COBHISVI-OCORR-HISTORICO, :RELATORI-NUM-APOLICE, :RELATORI-COD-SUBGRUPO, :PROPOVA-COD-FONTE, 0, :WHOST-PRM-VG, :WHOST-PRM-AP, :WHOST-DATA-CRED, '0' , :COBHISVI-COD-OPERACAO, CURRENT TIMESTAMP, NULL) END-EXEC. */

            var r2400_00_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1 = new R2400_00_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1()
            {
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
                RELATORI_NUM_PARCELA = RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA.ToString(),
                COBHISVI_NUM_TITULO = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_TITULO.ToString(),
                COBHISVI_OCORR_HISTORICO = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_OCORR_HISTORICO.ToString(),
                RELATORI_NUM_APOLICE = RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE.ToString(),
                RELATORI_COD_SUBGRUPO = RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO.ToString(),
                PROPOVA_COD_FONTE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_FONTE.ToString(),
                WHOST_PRM_VG = WHOST_PRM_VG.ToString(),
                WHOST_PRM_AP = WHOST_PRM_AP.ToString(),
                WHOST_DATA_CRED = WHOST_DATA_CRED.ToString(),
                COBHISVI_COD_OPERACAO = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_COD_OPERACAO.ToString(),
            };

            R2400_00_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1.Execute(r2400_00_INSERT_HISTCONTABILVA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-INSERT-RELATORIOS-SECTION */
        private void R2500_00_INSERT_RELATORIOS_SECTION()
        {
            /*" -3158- MOVE 'R2500-00-INSERT-RELATORIOS' TO PARAGRAFO. */
            _.Move("R2500-00-INSERT-RELATORIOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3159- MOVE 'INSERT SEGUROS.RELATORIOS' TO COMANDO. */
            _.Move("INSERT SEGUROS.RELATORIOS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3161- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3205- PERFORM R2500_00_INSERT_RELATORIOS_DB_INSERT_1 */

            R2500_00_INSERT_RELATORIOS_DB_INSERT_1();

            /*" -3208- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -3209- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -3210- GO TO R2500-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/ //GOTO
                    return;

                    /*" -3211- ELSE */
                }
                else
                {


                    /*" -3212- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3213- END-IF */
                }


                /*" -3215- END-IF. */
            }


            /*" -3215- ADD 1 TO AC-I-RELATORI. */
            ACUMULADORES.AC_I_RELATORI.Value = ACUMULADORES.AC_I_RELATORI + 1;

        }

        [StopWatch]
        /*" R2500-00-INSERT-RELATORIOS-DB-INSERT-1 */
        public void R2500_00_INSERT_RELATORIOS_DB_INSERT_1()
        {
            /*" -3205- EXEC SQL INSERT INTO SEGUROS.RELATORIOS VALUES ( 'VA0469B' , :SISTEMAS-DATA-MOV-ABERTO , 'VA' , 'VA0512B' , 0, 0, :SISTEMAS-DATA-MOV-ABERTO , :SISTEMAS-DATA-MOV-ABERTO , :SISTEMAS-DATA-MOV-ABERTO , 0, 0, 0, 0, 0, 0, 0, 0, :RELATORI-NUM-APOLICE, 0, :RELATORI-NUM-PARCELA, :RELATORI-NUM-CERTIFICADO, 0, :RELATORI-COD-SUBGRUPO , 0, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '0' , ' ' , ' ' , NULL, 0, 0, CURRENT TIMESTAMP) END-EXEC. */

            var r2500_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1 = new R2500_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                RELATORI_NUM_APOLICE = RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE.ToString(),
                RELATORI_NUM_PARCELA = RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA.ToString(),
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
                RELATORI_COD_SUBGRUPO = RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO.ToString(),
            };

            R2500_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1.Execute(r2500_00_INSERT_RELATORIOS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R2600-00-SELECT-HISTCONTABILVA-SECTION */
        private void R2600_00_SELECT_HISTCONTABILVA_SECTION()
        {
            /*" -3224- MOVE 'R2600-00-SELECT-HISTCONTABILVA' TO PARAGRAFO. */
            _.Move("R2600-00-SELECT-HISTCONTABILVA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3225- MOVE 'SELECT SEGUROS.HIST_CONT_PARCELVA' TO COMANDO. */
            _.Move("SELECT SEGUROS.HIST_CONT_PARCELVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3227- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3229- MOVE ZEROS TO WQTD-HIST-CONT. */
            _.Move(0, WQTD_HIST_CONT);

            /*" -3241- PERFORM R2600_00_SELECT_HISTCONTABILVA_DB_SELECT_1 */

            R2600_00_SELECT_HISTCONTABILVA_DB_SELECT_1();

        }

        [StopWatch]
        /*" R2600-00-SELECT-HISTCONTABILVA-DB-SELECT-1 */
        public void R2600_00_SELECT_HISTCONTABILVA_DB_SELECT_1()
        {
            /*" -3241- EXEC SQL SELECT VALUE(COD_OPERACAO, 0), VALUE(DTFATUR, '0001-01-01' ) INTO :WQTD-HIST-CONT, :WS-DTFATUR FROM SEGUROS.HIST_CONT_PARCELVA WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO AND NUM_PARCELA = :RELATORI-NUM-PARCELA AND COD_OPERACAO BETWEEN 200 AND 299 WITH UR END-EXEC. */

            var r2600_00_SELECT_HISTCONTABILVA_DB_SELECT_1_Query1 = new R2600_00_SELECT_HISTCONTABILVA_DB_SELECT_1_Query1()
            {
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
                RELATORI_NUM_PARCELA = RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA.ToString(),
            };

            var executed_1 = R2600_00_SELECT_HISTCONTABILVA_DB_SELECT_1_Query1.Execute(r2600_00_SELECT_HISTCONTABILVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WQTD_HIST_CONT, WQTD_HIST_CONT);
                _.Move(executed_1.WS_DTFATUR, WS_DTFATUR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2600_99_SAIDA*/

        [StopWatch]
        /*" R2860-00-DELETE-VGCRITICA-SECTION */
        private void R2860_00_DELETE_VGCRITICA_SECTION()
        {
            /*" -3254- MOVE 'R2860-00-DELETE-VGCRITICA' TO PARAGRAFO. */
            _.Move("R2860-00-DELETE-VGCRITICA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3255- MOVE 'CHAMAR SPBVG001 P/ EXCLUIR CRITICA' TO COMANDO. */
            _.Move("CHAMAR SPBVG001 P/ EXCLUIR CRITICA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3257- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3259- INITIALIZE LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Initialize(
                SPVG001W.LK_VG001_TRACE
                , SPVG001W.LK_VG001_TIPO_ACAO
                , SPVG001W.LK_VG001_NUM_CERTIFICADO
                , SPVG001W.LK_VG001_SEQ_CRITICA
                , SPVG001W.LK_VG001_IND_TP_PROPOSTA
                , SPVG001W.LK_VG001_NUM_CPF_CNPJ
                , SPVG001W.LK_VG001_COD_MSG_CRITICA
                , SPVG001W.LK_VG001_COD_USUARIO
                , SPVG001W.LK_VG001_NOM_PROGRAMA
                , SPVG001W.LK_VG001_STA_CRITICA
                , SPVG001W.LK_VG001_DES_COMPLEMENTAR
                , SPVG001W.LK_VG001_S_NUM_CERTIFICADO
                , SPVG001W.LK_VG001_S_SEQ_CRITICA
                , SPVG001W.LK_VG001_S_IND_TP_PROPOSTA
                , SPVG001W.LK_VG001_S_COD_MSG_CRITICA
                , SPVG001W.LK_VG001_S_DES_MSG_CRITICA
                , SPVG001W.LK_VG001_S_DES_ABREV_MSG_CRIT
                , SPVG001W.LK_VG001_S_NUM_CPF_CNPJ
                , SPVG001W.LK_VG001_S_NUM_PROPOSTA
                , SPVG001W.LK_VG001_S_VLR_IS
                , SPVG001W.LK_VG001_S_VLR_PREMIO
                , SPVG001W.LK_VG001_S_DTA_OCORRENCIA
                , SPVG001W.LK_VG001_S_DTA_RCAP
                , SPVG001W.LK_VG001_S_STA_CRITICA
                , SPVG001W.LK_VG001_S_DES_STA_CRITICA
                , SPVG001W.LK_VG001_S_DES_COMPLEMENTAR
                , SPVG001W.LK_VG001_S_COD_USUARIO
                , SPVG001W.LK_VG001_S_NOM_PROGRAMA
                , SPVG001W.LK_VG001_S_DTH_CADASTRAMENTO
                , SPVG001W.LK_VG001_S_STA_PARA
                , SPVG001W.LK_VG001_IND_ERRO
                , SPVG001W.LK_VG001_MSG_ERRO
                , SPVG001W.LK_VG001_NOM_TABELA
                , SPVG001W.LK_VG001_SQLCODE
                , SPVG001W.LK_VG001_SQLERRMC
            );

            /*" -3260- MOVE 'N' TO LK-VG001-TRACE */
            _.Move("N", SPVG001W.LK_VG001_TRACE);

            /*" -3261- MOVE 08 TO LK-VG001-TIPO-ACAO */
            _.Move(08, SPVG001W.LK_VG001_TIPO_ACAO);

            /*" -3262- MOVE RELATORI-NUM-CERTIFICADO TO LK-VG001-NUM-CERTIFICADO */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO, SPVG001W.LK_VG001_NUM_CERTIFICADO);

            /*" -3263- MOVE 0 TO LK-VG001-COD-MSG-CRITICA */
            _.Move(0, SPVG001W.LK_VG001_COD_MSG_CRITICA);

            /*" -3264- MOVE 1 TO LK-VG001-SEQ-CRITICA */
            _.Move(1, SPVG001W.LK_VG001_SEQ_CRITICA);

            /*" -3265- MOVE 'VA' TO LK-VG001-IND-TP-PROPOSTA */
            _.Move("VA", SPVG001W.LK_VG001_IND_TP_PROPOSTA);

            /*" -3266- MOVE 0 TO LK-VG001-NUM-CPF-CNPJ */
            _.Move(0, SPVG001W.LK_VG001_NUM_CPF_CNPJ);

            /*" -3267- MOVE 'BATCH' TO LK-VG001-COD-USUARIO */
            _.Move("BATCH", SPVG001W.LK_VG001_COD_USUARIO);

            /*" -3268- MOVE 'VA0469B' TO LK-VG001-NOM-PROGRAMA */
            _.Move("VA0469B", SPVG001W.LK_VG001_NOM_PROGRAMA);

            /*" -3269- MOVE 'SPBVG001' TO VG001-PROGRAMA */
            _.Move("SPBVG001", SPVG001V.VG001_PROGRAMA);

            /*" -3270- MOVE '9' TO LK-VG001-STA-CRITICA */
            _.Move("9", SPVG001W.LK_VG001_STA_CRITICA);

            /*" -3271- MOVE 50 TO LK-VG001-DES-COMPLEMENTAR-L */
            _.Move(50, SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_L);

            /*" -3274- MOVE 'EXCLUSAO LOGICA DE ERRO DA PROPOSTA PARA DECLINIO' TO LK-VG001-DES-COMPLEMENTAR-T */
            _.Move("EXCLUSAO LOGICA DE ERRO DA PROPOSTA PARA DECLINIO", SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_T);

            /*" -3276- CALL VG001-PROGRAMA USING LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG001W);

            /*" -3277- IF LK-VG001-IND-ERRO NOT EQUAL ZEROS AND +1 */

            if (!SPVG001W.LK_VG001_IND_ERRO.In("00", "+1"))
            {

                /*" -3278- DISPLAY '*------------------------------------------*' */
                _.Display($"*------------------------------------------*");

                /*" -3279- DISPLAY '* R2860-PROBLEMAS CALL SUBROTINA SPBVG001  *' */
                _.Display($"* R2860-PROBLEMAS CALL SUBROTINA SPBVG001  *");

                /*" -3280- DISPLAY '*------------------------------------------*' */
                _.Display($"*------------------------------------------*");

                /*" -3281- DISPLAY '* NUM-CERTIF..: ' LK-VG001-NUM-CERTIFICADO */
                _.Display($"* NUM-CERTIF..: {SPVG001W.LK_VG001_NUM_CERTIFICADO}");

                /*" -3282- DISPLAY '* IND-ERRO....: ' LK-VG001-IND-ERRO */
                _.Display($"* IND-ERRO....: {SPVG001W.LK_VG001_IND_ERRO}");

                /*" -3283- DISPLAY '* MSG-ERRO....: ' LK-VG001-MSG-ERRO */
                _.Display($"* MSG-ERRO....: {SPVG001W.LK_VG001_MSG_ERRO}");

                /*" -3284- DISPLAY '* NOM-TABELA..: ' LK-VG001-NOM-TABELA */
                _.Display($"* NOM-TABELA..: {SPVG001W.LK_VG001_NOM_TABELA}");

                /*" -3285- DISPLAY '* SQLCODE.....: ' LK-VG001-SQLCODE */
                _.Display($"* SQLCODE.....: {SPVG001W.LK_VG001_SQLCODE}");

                /*" -3286- DISPLAY '* SQLERRMC....: ' LK-VG001-SQLERRMC */
                _.Display($"* SQLERRMC....: {SPVG001W.LK_VG001_SQLERRMC}");

                /*" -3288- DISPLAY '*------------------------------------------*' */
                _.Display($"*------------------------------------------*");

                /*" -3289- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3290- END-IF */
            }


            /*" -3290- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2860_99_SAIDA*/

        [StopWatch]
        /*" R3040-00-CONTA-DIAS-SECTION */
        private void R3040_00_CONTA_DIAS_SECTION()
        {
            /*" -3299- MOVE 'R1040-00-CONTA-DIAS' TO PARAGRAFO. */
            _.Move("R1040-00-CONTA-DIAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3300- IF RELATORI-NUM-PARCELA EQUAL 1 */

            if (RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA == 1)
            {

                /*" -3306- PERFORM R3040_00_CONTA_DIAS_DB_SELECT_1 */

                R3040_00_CONTA_DIAS_DB_SELECT_1();

                /*" -3309- IF SQLCODE NOT EQUAL ZEROS AND 100 */

                if (!DB.SQLCODE.In("00", "100"))
                {

                    /*" -3310- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3311- END-IF */
                }


                /*" -3312- ELSE */
            }
            else
            {


                /*" -3318- PERFORM R3040_00_CONTA_DIAS_DB_SELECT_2 */

                R3040_00_CONTA_DIAS_DB_SELECT_2();

                /*" -3321- IF SQLCODE NOT EQUAL ZEROS AND 100 */

                if (!DB.SQLCODE.In("00", "100"))
                {

                    /*" -3322- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3323- END-IF */
                }


                /*" -3323- END-IF. */
            }


        }

        [StopWatch]
        /*" R3040-00-CONTA-DIAS-DB-SELECT-1 */
        public void R3040_00_CONTA_DIAS_DB_SELECT_1()
        {
            /*" -3306- EXEC SQL SELECT DAYS (:WHOST-DATA-CRED) - DAYS (:PROPOVA-DATA-QUITACAO) INTO :WQTDIAS FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VA' END-EXEC */

            var r3040_00_CONTA_DIAS_DB_SELECT_1_Query1 = new R3040_00_CONTA_DIAS_DB_SELECT_1_Query1()
            {
                PROPOVA_DATA_QUITACAO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO.ToString(),
                WHOST_DATA_CRED = WHOST_DATA_CRED.ToString(),
            };

            var executed_1 = R3040_00_CONTA_DIAS_DB_SELECT_1_Query1.Execute(r3040_00_CONTA_DIAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WQTDIAS, WQTDIAS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3040_99_SAIDA*/

        [StopWatch]
        /*" R3040-00-CONTA-DIAS-DB-SELECT-2 */
        public void R3040_00_CONTA_DIAS_DB_SELECT_2()
        {
            /*" -3318- EXEC SQL SELECT DAYS (:WHOST-DATA-CRED) - DAYS (:PARCEVID-DATA-VENCIMENTO) INTO :WQTDIAS FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VA' END-EXEC */

            var r3040_00_CONTA_DIAS_DB_SELECT_2_Query1 = new R3040_00_CONTA_DIAS_DB_SELECT_2_Query1()
            {
                PARCEVID_DATA_VENCIMENTO = PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_DATA_VENCIMENTO.ToString(),
                WHOST_DATA_CRED = WHOST_DATA_CRED.ToString(),
            };

            var executed_1 = R3040_00_CONTA_DIAS_DB_SELECT_2_Query1.Execute(r3040_00_CONTA_DIAS_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WQTDIAS, WQTDIAS);
            }


        }

        [StopWatch]
        /*" R3100-00-VERIFICA-RCAPS-SECTION */
        private void R3100_00_VERIFICA_RCAPS_SECTION()
        {
            /*" -3334- MOVE 'R3100-00-VERIFICA-RCAPS       ' TO PARAGRAFO. */
            _.Move("R3100-00-VERIFICA-RCAPS       ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3335- MOVE 'R3100-00-VERIFICA-RCAPS          ' TO COMANDO. */
            _.Move("R3100-00-VERIFICA-RCAPS          ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3337- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3339- PERFORM R3150-00-SELECT-RCAPS. */

            R3150_00_SELECT_RCAPS_SECTION();

            /*" -3340- IF RCAPS-NUM-RCAP NOT EQUAL ZEROS */

            if (RCAPS.DCLRCAPS.RCAPS_NUM_RCAP != 00)
            {

                /*" -3340- PERFORM R3200-00-MONTA-RCAP. */

                R3200_00_MONTA_RCAP_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R3150-00-SELECT-RCAPS-SECTION */
        private void R3150_00_SELECT_RCAPS_SECTION()
        {
            /*" -3352- MOVE 'R3150-00-SELECT-RCAPS         ' TO PARAGRAFO. */
            _.Move("R3150-00-SELECT-RCAPS         ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3353- MOVE 'SELECT SEGUROS.RCAPS             ' TO COMANDO. */
            _.Move("SELECT SEGUROS.RCAPS             ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3355- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3378- PERFORM R3150_00_SELECT_RCAPS_DB_SELECT_1 */

            R3150_00_SELECT_RCAPS_DB_SELECT_1();

            /*" -3381- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3383- MOVE ZEROS TO RCAPS-NUM-RCAP */
                _.Move(0, RCAPS.DCLRCAPS.RCAPS_NUM_RCAP);

                /*" -3384- ELSE */
            }
            else
            {


                /*" -3385- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -3386- DISPLAY 'R3150-00 - PROBLEMAS SELECT  (RCAPS   )   ' */
                    _.Display($"R3150-00 - PROBLEMAS SELECT  (RCAPS   )   ");

                    /*" -3387- DISPLAY ' CERTIFICADO    = ' RELATORI-NUM-CERTIFICADO */
                    _.Display($" CERTIFICADO    = {RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO}");

                    /*" -3387- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R3150-00-SELECT-RCAPS-DB-SELECT-1 */
        public void R3150_00_SELECT_RCAPS_DB_SELECT_1()
        {
            /*" -3378- EXEC SQL SELECT COD_FONTE ,NUM_RCAP ,VAL_RCAP ,VAL_RCAP_PRINCIPAL ,DATA_CADASTRAMENTO ,DATA_MOVIMENTO ,NUM_TITULO ,NUM_CERTIFICADO INTO :RCAPS-COD-FONTE ,:RCAPS-NUM-RCAP ,:RCAPS-VAL-RCAP ,:RCAPS-VAL-RCAP-PRINCIPAL ,:RCAPS-DATA-CADASTRAMENTO ,:RCAPS-DATA-MOVIMENTO ,:RCAPS-NUM-TITULO:VIND-NULL01 ,:RCAPS-NUM-CERTIFICADO:VIND-NULL02 FROM SEGUROS.RCAPS WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO AND SIT_REGISTRO = '0' AND COD_OPERACAO IN (100,110) FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r3150_00_SELECT_RCAPS_DB_SELECT_1_Query1 = new R3150_00_SELECT_RCAPS_DB_SELECT_1_Query1()
            {
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R3150_00_SELECT_RCAPS_DB_SELECT_1_Query1.Execute(r3150_00_SELECT_RCAPS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPS_COD_FONTE, RCAPS.DCLRCAPS.RCAPS_COD_FONTE);
                _.Move(executed_1.RCAPS_NUM_RCAP, RCAPS.DCLRCAPS.RCAPS_NUM_RCAP);
                _.Move(executed_1.RCAPS_VAL_RCAP, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP);
                _.Move(executed_1.RCAPS_VAL_RCAP_PRINCIPAL, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP_PRINCIPAL);
                _.Move(executed_1.RCAPS_DATA_CADASTRAMENTO, RCAPS.DCLRCAPS.RCAPS_DATA_CADASTRAMENTO);
                _.Move(executed_1.RCAPS_DATA_MOVIMENTO, RCAPS.DCLRCAPS.RCAPS_DATA_MOVIMENTO);
                _.Move(executed_1.RCAPS_NUM_TITULO, RCAPS.DCLRCAPS.RCAPS_NUM_TITULO);
                _.Move(executed_1.VIND_NULL01, VIND_NULL01);
                _.Move(executed_1.RCAPS_NUM_CERTIFICADO, RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO);
                _.Move(executed_1.VIND_NULL02, VIND_NULL02);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3150_99_SAIDA*/

        [StopWatch]
        /*" R3200-00-MONTA-RCAP-SECTION */
        private void R3200_00_MONTA_RCAP_SECTION()
        {
            /*" -3399- MOVE 'R3200-00-MONTA-RCAP           ' TO PARAGRAFO. */
            _.Move("R3200-00-MONTA-RCAP           ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3400- MOVE 'R3200-00-MONTA-RCAP              ' TO COMANDO. */
            _.Move("R3200-00-MONTA-RCAP              ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3402- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3404- MOVE RCAPS-COD-FONTE TO RCAPCOMP-COD-FONTE. */
            _.Move(RCAPS.DCLRCAPS.RCAPS_COD_FONTE, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_FONTE);

            /*" -3407- MOVE RCAPS-NUM-RCAP TO RCAPCOMP-NUM-RCAP. */
            _.Move(RCAPS.DCLRCAPS.RCAPS_NUM_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP);

            /*" -3409- PERFORM R3250-00-SELECT-RCAPCOMP. */

            R3250_00_SELECT_RCAPCOMP_SECTION();

            /*" -3410- IF RCAPCOMP-NUM-RCAP EQUAL ZEROS */

            if (RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP == 00)
            {

                /*" -3416- GO TO R3200-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3422- PERFORM R3310-00-UPDATE-RCAPCOMP. */

            R3310_00_UPDATE_RCAPCOMP_SECTION();

            /*" -3424- MOVE 210 TO RCAPCOMP-COD-OPERACAO. */
            _.Move(210, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_OPERACAO);

            /*" -3426- MOVE '0' TO RCAPCOMP-SIT-REGISTRO. */
            _.Move("0", RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_SIT_REGISTRO);

            /*" -3428- MOVE '0' TO RCAPCOMP-SIT-CONTABIL. */
            _.Move("0", RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_SIT_CONTABIL);

            /*" -3430- MOVE SISTEMAS-DATA-MOV-ABERTO TO RCAPCOMP-DATA-MOVIMENTO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_MOVIMENTO);

            /*" -3432- MOVE ZEROS TO RCAPCOMP-COD-EMPRESA. */
            _.Move(0, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_EMPRESA);

            /*" -3435- MOVE ZEROS TO VIND-NULL01. */
            _.Move(0, VIND_NULL01);

            /*" -3438- PERFORM R3320-00-INSERT-RCAPCOMP. */

            R3320_00_INSERT_RCAPCOMP_SECTION();

            /*" -3440- MOVE RELATORI-NUM-APOLICE TO RCAPS-NUM-APOLICE. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE, RCAPS.DCLRCAPS.RCAPS_NUM_APOLICE);

            /*" -3442- MOVE RELATORI-NUM-ENDOSSO TO RCAPS-NUM-ENDOSSO. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_ENDOSSO, RCAPS.DCLRCAPS.RCAPS_NUM_ENDOSSO);

            /*" -3445- MOVE RELATORI-NUM-PARCELA TO RCAPS-NUM-PARCELA. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA, RCAPS.DCLRCAPS.RCAPS_NUM_PARCELA);

            /*" -3448- PERFORM R3330-00-UPDATE-RCAP. */

            R3330_00_UPDATE_RCAP_SECTION();

            /*" -3448- PERFORM R5000-00-UPDATE-AVISOSAL. */

            R5000_00_UPDATE_AVISOSAL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/

        [StopWatch]
        /*" R3250-00-SELECT-RCAPCOMP-SECTION */
        private void R3250_00_SELECT_RCAPCOMP_SECTION()
        {
            /*" -3460- MOVE 'R3250-00-SELECT-RCAPCOMP      ' TO PARAGRAFO. */
            _.Move("R3250-00-SELECT-RCAPCOMP      ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3461- MOVE 'SELECT SEGUROS.RCAP_COMPLEMENTAR ' TO COMANDO. */
            _.Move("SELECT SEGUROS.RCAP_COMPLEMENTAR ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3463- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3492- PERFORM R3250_00_SELECT_RCAPCOMP_DB_SELECT_1 */

            R3250_00_SELECT_RCAPCOMP_DB_SELECT_1();

            /*" -3496- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3498- MOVE ZEROS TO RCAPCOMP-NUM-RCAP */
                _.Move(0, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP);

                /*" -3499- ELSE */
            }
            else
            {


                /*" -3500- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -3501- DISPLAY 'R3250-00 - PROBLEMAS SELECT  (RCAPS   )   ' */
                    _.Display($"R3250-00 - PROBLEMAS SELECT  (RCAPS   )   ");

                    /*" -3502- DISPLAY ' FONTE          = ' RCAPCOMP-COD-FONTE */
                    _.Display($" FONTE          = {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_FONTE}");

                    /*" -3503- DISPLAY ' NRRCAP         = ' RCAPCOMP-NUM-RCAP */
                    _.Display($" NRRCAP         = {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP}");

                    /*" -3503- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R3250-00-SELECT-RCAPCOMP-DB-SELECT-1 */
        public void R3250_00_SELECT_RCAPCOMP_DB_SELECT_1()
        {
            /*" -3492- EXEC SQL SELECT COD_FONTE ,NUM_RCAP ,NUM_RCAP_COMPLEMEN ,COD_OPERACAO ,BCO_AVISO ,AGE_AVISO ,NUM_AVISO_CREDITO ,VAL_RCAP ,DATA_RCAP ,DATA_CADASTRAMENTO INTO :RCAPCOMP-COD-FONTE ,:RCAPCOMP-NUM-RCAP ,:RCAPCOMP-NUM-RCAP-COMPLEMEN ,:RCAPCOMP-COD-OPERACAO ,:RCAPCOMP-BCO-AVISO ,:RCAPCOMP-AGE-AVISO ,:RCAPCOMP-NUM-AVISO-CREDITO ,:RCAPCOMP-VAL-RCAP ,:RCAPCOMP-DATA-RCAP ,:RCAPCOMP-DATA-CADASTRAMENTO FROM SEGUROS.RCAP_COMPLEMENTAR WHERE NUM_RCAP = :RCAPCOMP-NUM-RCAP AND COD_FONTE = :RCAPCOMP-COD-FONTE AND SIT_REGISTRO = '0' AND NUM_RCAP_COMPLEMEN = 0 FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r3250_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1 = new R3250_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1()
            {
                RCAPCOMP_COD_FONTE = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_FONTE.ToString(),
                RCAPCOMP_NUM_RCAP = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP.ToString(),
            };

            var executed_1 = R3250_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1.Execute(r3250_00_SELECT_RCAPCOMP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPCOMP_COD_FONTE, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_FONTE);
                _.Move(executed_1.RCAPCOMP_NUM_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP);
                _.Move(executed_1.RCAPCOMP_NUM_RCAP_COMPLEMEN, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP_COMPLEMEN);
                _.Move(executed_1.RCAPCOMP_COD_OPERACAO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_OPERACAO);
                _.Move(executed_1.RCAPCOMP_BCO_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO);
                _.Move(executed_1.RCAPCOMP_AGE_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO);
                _.Move(executed_1.RCAPCOMP_NUM_AVISO_CREDITO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO);
                _.Move(executed_1.RCAPCOMP_VAL_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP);
                _.Move(executed_1.RCAPCOMP_DATA_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP);
                _.Move(executed_1.RCAPCOMP_DATA_CADASTRAMENTO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_CADASTRAMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3250_99_SAIDA*/

        [StopWatch]
        /*" R3310-00-UPDATE-RCAPCOMP-SECTION */
        private void R3310_00_UPDATE_RCAPCOMP_SECTION()
        {
            /*" -3515- MOVE 'R3310-00-UPDATE-RCAPCOMP      ' TO PARAGRAFO. */
            _.Move("R3310-00-UPDATE-RCAPCOMP      ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3516- MOVE 'UPDATE SEGUROS.RCAP_COMPLEMENTAR ' TO COMANDO. */
            _.Move("UPDATE SEGUROS.RCAP_COMPLEMENTAR ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3518- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3523- PERFORM R3310_00_UPDATE_RCAPCOMP_DB_UPDATE_1 */

            R3310_00_UPDATE_RCAPCOMP_DB_UPDATE_1();

            /*" -3527- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -3528- DISPLAY 'R3310-00 - PROBLEMAS UPDATE (RCAPCOMP)' */
                _.Display($"R3310-00 - PROBLEMAS UPDATE (RCAPCOMP)");

                /*" -3529- DISPLAY 'NUM-RCAP        = ' RCAPCOMP-NUM-RCAP */
                _.Display($"NUM-RCAP        = {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP}");

                /*" -3530- DISPLAY 'COD-FONTE       = ' RCAPCOMP-COD-FONTE */
                _.Display($"COD-FONTE       = {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_FONTE}");

                /*" -3530- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3310-00-UPDATE-RCAPCOMP-DB-UPDATE-1 */
        public void R3310_00_UPDATE_RCAPCOMP_DB_UPDATE_1()
        {
            /*" -3523- EXEC SQL UPDATE SEGUROS.RCAP_COMPLEMENTAR SET SIT_REGISTRO = '1' WHERE NUM_RCAP = :RCAPCOMP-NUM-RCAP AND COD_FONTE = :RCAPCOMP-COD-FONTE END-EXEC. */

            var r3310_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1 = new R3310_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1()
            {
                RCAPCOMP_COD_FONTE = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_FONTE.ToString(),
                RCAPCOMP_NUM_RCAP = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP.ToString(),
            };

            R3310_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1.Execute(r3310_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3310_99_SAIDA*/

        [StopWatch]
        /*" R3320-00-INSERT-RCAPCOMP-SECTION */
        private void R3320_00_INSERT_RCAPCOMP_SECTION()
        {
            /*" -3542- MOVE 'R3320-00-INSERT-RCAPCOMP      ' TO PARAGRAFO. */
            _.Move("R3320-00-INSERT-RCAPCOMP      ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3543- MOVE 'INSERT SEGUROS.RCAP_COMPLEMENTAR ' TO COMANDO. */
            _.Move("INSERT SEGUROS.RCAP_COMPLEMENTAR ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3545- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3580- PERFORM R3320_00_INSERT_RCAPCOMP_DB_INSERT_1 */

            R3320_00_INSERT_RCAPCOMP_DB_INSERT_1();

            /*" -3584- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3585- DISPLAY 'R3320-00 - PROBLEMAS NO INSERT(RCAPCOMP)   ' */
                _.Display($"R3320-00 - PROBLEMAS NO INSERT(RCAPCOMP)   ");

                /*" -3586- DISPLAY 'COD-FONTE       = ' RCAPCOMP-COD-FONTE */
                _.Display($"COD-FONTE       = {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_FONTE}");

                /*" -3587- DISPLAY 'NUM-RCAP        = ' RCAPCOMP-NUM-RCAP */
                _.Display($"NUM-RCAP        = {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP}");

                /*" -3587- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3320-00-INSERT-RCAPCOMP-DB-INSERT-1 */
        public void R3320_00_INSERT_RCAPCOMP_DB_INSERT_1()
        {
            /*" -3580- EXEC SQL INSERT INTO SEGUROS.RCAP_COMPLEMENTAR (COD_FONTE , NUM_RCAP , NUM_RCAP_COMPLEMEN , COD_OPERACAO , DATA_MOVIMENTO , HORA_OPERACAO , SIT_REGISTRO , BCO_AVISO , AGE_AVISO , NUM_AVISO_CREDITO , VAL_RCAP , DATA_RCAP , DATA_CADASTRAMENTO , SIT_CONTABIL , COD_EMPRESA , TIMESTAMP) VALUES (:RCAPCOMP-COD-FONTE , :RCAPCOMP-NUM-RCAP , :RCAPCOMP-NUM-RCAP-COMPLEMEN , :RCAPCOMP-COD-OPERACAO , :RCAPCOMP-DATA-MOVIMENTO , CURRENT TIME , :RCAPCOMP-SIT-REGISTRO , :RCAPCOMP-BCO-AVISO , :RCAPCOMP-AGE-AVISO , :RCAPCOMP-NUM-AVISO-CREDITO , :RCAPCOMP-VAL-RCAP , :RCAPCOMP-DATA-RCAP , :RCAPCOMP-DATA-CADASTRAMENTO , :RCAPCOMP-SIT-CONTABIL , :RCAPCOMP-COD-EMPRESA:VIND-NULL01 , CURRENT TIMESTAMP) END-EXEC. */

            var r3320_00_INSERT_RCAPCOMP_DB_INSERT_1_Insert1 = new R3320_00_INSERT_RCAPCOMP_DB_INSERT_1_Insert1()
            {
                RCAPCOMP_COD_FONTE = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_FONTE.ToString(),
                RCAPCOMP_NUM_RCAP = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP.ToString(),
                RCAPCOMP_NUM_RCAP_COMPLEMEN = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP_COMPLEMEN.ToString(),
                RCAPCOMP_COD_OPERACAO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_OPERACAO.ToString(),
                RCAPCOMP_DATA_MOVIMENTO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_MOVIMENTO.ToString(),
                RCAPCOMP_SIT_REGISTRO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_SIT_REGISTRO.ToString(),
                RCAPCOMP_BCO_AVISO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO.ToString(),
                RCAPCOMP_AGE_AVISO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO.ToString(),
                RCAPCOMP_NUM_AVISO_CREDITO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO.ToString(),
                RCAPCOMP_VAL_RCAP = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP.ToString(),
                RCAPCOMP_DATA_RCAP = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP.ToString(),
                RCAPCOMP_DATA_CADASTRAMENTO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_CADASTRAMENTO.ToString(),
                RCAPCOMP_SIT_CONTABIL = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_SIT_CONTABIL.ToString(),
                RCAPCOMP_COD_EMPRESA = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_EMPRESA.ToString(),
                VIND_NULL01 = VIND_NULL01.ToString(),
            };

            R3320_00_INSERT_RCAPCOMP_DB_INSERT_1_Insert1.Execute(r3320_00_INSERT_RCAPCOMP_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3320_99_SAIDA*/

        [StopWatch]
        /*" R3330-00-UPDATE-RCAP-SECTION */
        private void R3330_00_UPDATE_RCAP_SECTION()
        {
            /*" -3599- MOVE 'R3330-00-UPDATE-RCAP          ' TO PARAGRAFO. */
            _.Move("R3330-00-UPDATE-RCAP          ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3600- MOVE 'UPDATE SEGUROS.RCAPS             ' TO COMANDO. */
            _.Move("UPDATE SEGUROS.RCAPS             ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3602- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3611- PERFORM R3330_00_UPDATE_RCAP_DB_UPDATE_1 */

            R3330_00_UPDATE_RCAP_DB_UPDATE_1();

            /*" -3615- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -3616- DISPLAY 'R3330-00 - PROBLEMAS UPDATE (RCAPS)   ' */
                _.Display($"R3330-00 - PROBLEMAS UPDATE (RCAPS)   ");

                /*" -3617- DISPLAY 'COD-FONTE       = ' RCAPCOMP-COD-FONTE */
                _.Display($"COD-FONTE       = {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_FONTE}");

                /*" -3618- DISPLAY 'NUM-RCAP        = ' RCAPCOMP-NUM-RCAP */
                _.Display($"NUM-RCAP        = {RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP}");

                /*" -3618- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3330-00-UPDATE-RCAP-DB-UPDATE-1 */
        public void R3330_00_UPDATE_RCAP_DB_UPDATE_1()
        {
            /*" -3611- EXEC SQL UPDATE SEGUROS.RCAPS SET SIT_REGISTRO = '1' ,COD_OPERACAO = 210 ,NUM_APOLICE = :RCAPS-NUM-APOLICE ,NUM_ENDOSSO = :RCAPS-NUM-ENDOSSO ,NUM_PARCELA = :RCAPS-NUM-PARCELA WHERE NUM_RCAP = :RCAPCOMP-NUM-RCAP AND COD_FONTE = :RCAPCOMP-COD-FONTE END-EXEC. */

            var r3330_00_UPDATE_RCAP_DB_UPDATE_1_Update1 = new R3330_00_UPDATE_RCAP_DB_UPDATE_1_Update1()
            {
                RCAPS_NUM_APOLICE = RCAPS.DCLRCAPS.RCAPS_NUM_APOLICE.ToString(),
                RCAPS_NUM_ENDOSSO = RCAPS.DCLRCAPS.RCAPS_NUM_ENDOSSO.ToString(),
                RCAPS_NUM_PARCELA = RCAPS.DCLRCAPS.RCAPS_NUM_PARCELA.ToString(),
                RCAPCOMP_COD_FONTE = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_FONTE.ToString(),
                RCAPCOMP_NUM_RCAP = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_RCAP.ToString(),
            };

            R3330_00_UPDATE_RCAP_DB_UPDATE_1_Update1.Execute(r3330_00_UPDATE_RCAP_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3330_99_SAIDA*/

        [StopWatch]
        /*" R3400-00-DEVOLVE-CARTAO-9021-SECTION */
        private void R3400_00_DEVOLVE_CARTAO_9021_SECTION()
        {
            /*" -3632- MOVE 'R3400-00-DEVOLVE-CARTAO-9021  ' TO PARAGRAFO. */
            _.Move("R3400-00-DEVOLVE-CARTAO-9021  ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3633- MOVE 'R3400-00-DEVOLVE-CARTAO-9021  ' TO COMANDO. */
            _.Move("R3400-00-DEVOLVE-CARTAO-9021  ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3635- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3636- MOVE 9021 TO CONVEVG-COD-NAOACEITE */
            _.Move(9021, CONVEVG.DCLCONVENIOS_VG.CONVEVG_COD_NAOACEITE);

            /*" -3637- MOVE RELATORI-NUM-CERTIFICADO TO MOVDEBCE-NUM-CARTAO */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO);

            /*" -3638- MOVE 0 TO MOVDEBCE-COD-EMPRESA */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_EMPRESA);

            /*" -3639- MOVE COBHISVI-NUM-TITULO TO MOVDEBCE-NUM-APOLICE */
            _.Move(COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_TITULO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);

            /*" -3640- MOVE 0 TO MOVDEBCE-NUM-ENDOSSO */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);

            /*" -3641- MOVE RELATORI-NUM-PARCELA TO MOVDEBCE-NUM-PARCELA */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA);

            /*" -3642- MOVE ' ' TO MOVDEBCE-SITUACAO-COBRANCA */
            _.Move(" ", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);

            /*" -3644- MOVE WHOST-DATA-CRED TO MOVDEBCE-DATA-VENCIMENTO */
            _.Move(WHOST_DATA_CRED, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO);

            /*" -3647- MOVE WHOST-NEW-PRM TO MOVDEBCE-VALOR-DEBITO */
            _.Move(WHOST_NEW_PRM, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO);

            /*" -3648- MOVE SISTEMAS-DATA-MOV-ABERTO TO MOVDEBCE-DATA-MOVIMENTO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO);

            /*" -3649- MOVE 0 TO MOVDEBCE-DIA-DEBITO */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIA_DEBITO);

            /*" -3650- MOVE 0 TO MOVDEBCE-COD-AGENCIA-DEB */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB);

            /*" -3651- MOVE 0 TO MOVDEBCE-NUM-CONTA-DEB */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB);

            /*" -3652- MOVE CONVEVG-COD-NAOACEITE TO MOVDEBCE-COD-CONVENIO */
            _.Move(CONVEVG.DCLCONVENIOS_VG.CONVEVG_COD_NAOACEITE, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);

            /*" -3653- MOVE ZEROS TO MOVDEBCE-NSAS */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS);

            /*" -3655- MOVE 'VA0469B' TO MOVDEBCE-COD-USUARIO */
            _.Move("VA0469B", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_USUARIO);

            /*" -3657- MOVE RELATORI-NUM-CERTIFICADO TO MOVDEBCE-NUM-CERTIFICADO */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CERTIFICADO);

            /*" -3658- MOVE LK-VG011-S-COD-MOEDA TO MOVDEBCE-COD-MOEDA */
            _.Move(SPVG011W.LK_VG011_S_COD_MOEDA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_MOEDA);

            /*" -3659- MOVE LK-VG011-S-PC-INDICE TO MOVDEBCE-PCT-INDICE */
            _.Move(SPVG011W.LK_VG011_S_PC_INDICE, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_PCT_INDICE);

            /*" -3660- MOVE LK-VG011-E-VL-ORIGINAL TO MOVDEBCE-VLR-ORIGINAL */
            _.Move(SPVG011W.LK_VG011_E_VL_ORIGINAL, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_ORIGINAL);

            /*" -3661- MOVE LK-VG011-S-VL-CORRIGIDO TO MOVDEBCE-VLR-PRORATA */
            _.Move(SPVG011W.LK_VG011_S_VL_CORRIGIDO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_PRORATA);

            /*" -3662- MOVE LK-VG011-S-VL-JUROS TO MOVDEBCE-VLR-JUROS */
            _.Move(SPVG011W.LK_VG011_S_VL_JUROS, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_JUROS);

            /*" -3663- MOVE LK-VG011-S-VL-MULTA TO MOVDEBCE-VLR-MULTA */
            _.Move(SPVG011W.LK_VG011_S_VL_MULTA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_MULTA);

            /*" -3664- MOVE LK-VG011-S-DTA-FIM-PGMNTO TO MOVDEBCE-DTA-ORIGINAL */
            _.Move(SPVG011W.LK_VG011_S_DTA_FIM_PGMNTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DTA_ORIGINAL);

            /*" -3666- MOVE SPACES TO MOVDEBCE-COD-IDLG */
            _.Move("", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_IDLG);

            /*" -3676- MOVE -1 TO VIND-DTENV VIND-DTRET VIND-CODRET VIND-NREQ VIND-SEQUEN VIND-NLOTE VIND-STATUS VIND-VLCRED VIND-DTCRED VIND-COD-IDLG */
            _.Move(-1, VIND_DTENV, VIND_DTRET, VIND_CODRET, VIND_NREQ, VIND_SEQUEN, VIND_NLOTE, VIND_STATUS, VIND_VLCRED, VIND_DTCRED, VIND_COD_IDLG);

            /*" -3677- IF LK-VG011-S-COD-MOEDA > ZEROS */

            if (SPVG011W.LK_VG011_S_COD_MOEDA > 00)
            {

                /*" -3684- MOVE ZEROS TO VIND-COD-MOEDA VIND-PCT-INDICE VIND-VLR-ORIGINAL VIND-VLR-PRORATA VIND-VLR-JUROS VIND-VLR-MULTA VIND-DTA-ORIGINAL */
                _.Move(0, VIND_COD_MOEDA, VIND_PCT_INDICE, VIND_VLR_ORIGINAL, VIND_VLR_PRORATA, VIND_VLR_JUROS, VIND_VLR_MULTA, VIND_DTA_ORIGINAL);

                /*" -3685- ELSE */
            }
            else
            {


                /*" -3692- MOVE -1 TO VIND-COD-MOEDA VIND-PCT-INDICE VIND-VLR-ORIGINAL VIND-VLR-PRORATA VIND-VLR-JUROS VIND-VLR-MULTA VIND-DTA-ORIGINAL */
                _.Move(-1, VIND_COD_MOEDA, VIND_PCT_INDICE, VIND_VLR_ORIGINAL, VIND_VLR_PRORATA, VIND_VLR_JUROS, VIND_VLR_MULTA, VIND_DTA_ORIGINAL);

                /*" -3694- END-IF */
            }


            /*" -3695- PERFORM R3410-00-INSERT-MOVTO-DEBITOCC */

            R3410_00_INSERT_MOVTO_DEBITOCC_SECTION();

            /*" -3695- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3400_99_SAIDA*/

        [StopWatch]
        /*" R3405-00-SELECT-GE408-SECTION */
        private void R3405_00_SELECT_GE408_SECTION()
        {
            /*" -3704- MOVE 'R3405-00-SELECT-GE408         ' TO PARAGRAFO. */
            _.Move("R3405-00-SELECT-GE408         ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3706- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3708- MOVE 'SELECT SEGUROS.GE_RETORNO_CA_CIEL' TO COMANDO. */
            _.Move("SELECT SEGUROS.GE_RETORNO_CA_CIEL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3728- PERFORM R3405_00_SELECT_GE408_DB_SELECT_1 */

            R3405_00_SELECT_GE408_DB_SELECT_1();

            /*" -3731-  EVALUATE SQLCODE  */

            /*" -3732-  WHEN ZEROS  */

            /*" -3732- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -3733- SET WS-SIM-RETORNOU-SAP TO TRUE */
                WORK_AREA.WS_RETORNO_SAP["WS_SIM_RETORNOU_SAP"] = true;

                /*" -3734-  WHEN +100  */

                /*" -3734- ELSE IF   SQLCODE EQUALS  +100 */
            }
            else

            if (DB.SQLCODE == +100)
            {

                /*" -3735- SET WS-NAO-RETORNOU-SAP TO TRUE */
                WORK_AREA.WS_RETORNO_SAP["WS_NAO_RETORNOU_SAP"] = true;

                /*" -3736-  WHEN OTHER  */

                /*" -3736- ELSE */
            }
            else
            {


                /*" -3737- DISPLAY 'R3250-00 - PROBLEMAS SELECT (GE408   )   ' */
                _.Display($"R3250-00 - PROBLEMAS SELECT (GE408   )   ");

                /*" -3738- DISPLAY 'NUM_CERTIFICADO = ' RELATORI-NUM-CERTIFICADO */
                _.Display($"NUM_CERTIFICADO = {RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO}");

                /*" -3739- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3741-  END-EVALUATE  */

                /*" -3741- END-IF */
            }


            /*" -3741- . */

        }

        [StopWatch]
        /*" R3405-00-SELECT-GE408-DB-SELECT-1 */
        public void R3405_00_SELECT_GE408_DB_SELECT_1()
        {
            /*" -3728- EXEC SQL SELECT T2.NUM_CERTIFICADO INTO :GE408-NUM-CERTIFICADO FROM SEGUROS.GE_CONTROLE_CARTAO_CIELO T1 , SEGUROS.GE_RETORNO_CA_CIELO T2 , SEGUROS.PARCELAS_VIDAZUL T3 WHERE T1.NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO AND T1.NUM_PARCELA = :RELATORI-NUM-PARCELA AND T1.COD_TP_PAGAMENTO IN ( '01' , '02' ) AND T1.NUM_PROPOSTA = T2.NUM_PROPOSTA AND T1.NUM_CERTIFICADO = T2.NUM_CERTIFICADO AND T1.NUM_PARCELA = T2.NUM_PARCELA AND T1.SEQ_CONTROL_CARTAO = T2.SEQ_CONTROL_CARTAO AND T2.COD_MOVIMENTO = '03' AND T2.COD_RETORNO = ' CC' AND T1.NUM_CERTIFICADO = T3.NUM_CERTIFICADO AND T1.NUM_PARCELA = T3.NUM_PARCELA AND T3.SIT_REGISTRO IN ( '1' , '2' ) FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC */

            var r3405_00_SELECT_GE408_DB_SELECT_1_Query1 = new R3405_00_SELECT_GE408_DB_SELECT_1_Query1()
            {
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
                RELATORI_NUM_PARCELA = RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA.ToString(),
            };

            var executed_1 = R3405_00_SELECT_GE408_DB_SELECT_1_Query1.Execute(r3405_00_SELECT_GE408_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE408_NUM_CERTIFICADO, GE408.DCLGE_RETORNO_CA_CIELO.GE408_NUM_CERTIFICADO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3405_99_SAIDA*/

        [StopWatch]
        /*" R3410-00-INSERT-MOVTO-DEBITOCC-SECTION */
        private void R3410_00_INSERT_MOVTO_DEBITOCC_SECTION()
        {
            /*" -3751- MOVE 'R3410-00-INSERT-MOVTO-DEBITOCC' TO PARAGRAFO */
            _.Move("R3410-00-INSERT-MOVTO-DEBITOCC", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3752- MOVE 'INSERE COBRANCA MOVTO_DEBITOCC_CEF' TO COMANDO */
            _.Move("INSERE COBRANCA MOVTO_DEBITOCC_CEF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3754- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3755- MOVE ZEROS TO WS-NSAS-ERRO */
            _.Move(0, WS_NSAS_ERRO);

            /*" -3755- . */

            /*" -0- FLUXCONTROL_PERFORM R3410_05_INSERT_MOVIMENTO */

            R3410_05_INSERT_MOVIMENTO();

        }

        [StopWatch]
        /*" R3410-05-INSERT-MOVIMENTO */
        private void R3410_05_INSERT_MOVIMENTO(bool isPerform = false)
        {
            /*" -3834- PERFORM R3410_05_INSERT_MOVIMENTO_DB_INSERT_1 */

            R3410_05_INSERT_MOVIMENTO_DB_INSERT_1();

            /*" -3837- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3838- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -3839- IF MOVDEBCE-COD-CONVENIO EQUAL 609000 OR 1313 */

                    if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.In("609000", "1313"))
                    {

                        /*" -3840- PERFORM R3420-00-UPDATE-MOVTO-DEBITOCC */

                        R3420_00_UPDATE_MOVTO_DEBITOCC_SECTION();

                        /*" -3841- GO TO R3410-05-INSERT-MOVIMENTO */
                        new Task(() => R3410_05_INSERT_MOVIMENTO()).RunSynchronously(); //GOTO
                        return;//Recursividade detectada, cuidado...

                        /*" -3842- END-IF */
                    }


                    /*" -3843- ELSE */
                }
                else
                {


                    /*" -3844- DISPLAY 'ERRO R3410-00-INSERT-MOVTO-DEBITOCC' */
                    _.Display($"ERRO R3410-00-INSERT-MOVTO-DEBITOCC");

                    /*" -3846- DISPLAY 'CERTIF: ' MOVDEBCE-NUM-APOLICE '  ' 'PARCEL: ' MOVDEBCE-NUM-PARCELA */

                    $"CERTIF: {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE}  PARCEL: {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA}"
                    .Display();

                    /*" -3847- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3848- END-IF */
                }


                /*" -3849- ELSE */
            }
            else
            {


                /*" -3850- ADD 1 TO AC-I-MOVDEBCE */
                ACUMULADORES.AC_I_MOVDEBCE.Value = ACUMULADORES.AC_I_MOVDEBCE + 1;

                /*" -3851- END-IF */
            }


            /*" -3851- . */

        }

        [StopWatch]
        /*" R3410-05-INSERT-MOVIMENTO-DB-INSERT-1 */
        public void R3410_05_INSERT_MOVIMENTO_DB_INSERT_1()
        {
            /*" -3834- EXEC SQL INSERT INTO SEGUROS.MOVTO_DEBITOCC_CEF ( COD_EMPRESA , NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , SITUACAO_COBRANCA , DATA_VENCIMENTO , VALOR_DEBITO , DATA_MOVIMENTO , TIMESTAMP , DIA_DEBITO , COD_AGENCIA_DEB , OPER_CONTA_DEB , NUM_CONTA_DEB , DIG_CONTA_DEB , COD_CONVENIO , DATA_ENVIO , DATA_RETORNO , COD_RETORNO_CEF , NSAS , COD_USUARIO , NUM_REQUISICAO , NUM_CARTAO , SEQUENCIA , NUM_LOTE , DTCREDITO , STATUS_CARTAO , VLR_CREDITO , NUM_CERTIFICADO, COD_MOEDA , PCT_INDICE , VLR_ORIGINAL , VLR_PRORATA , VLR_JUROS , VLR_MULTA , DTA_ORIGINAL , COD_IDLG ) VALUES ( :MOVDEBCE-COD-EMPRESA , :MOVDEBCE-NUM-APOLICE , :MOVDEBCE-NUM-ENDOSSO , :MOVDEBCE-NUM-PARCELA , :MOVDEBCE-SITUACAO-COBRANCA , :MOVDEBCE-DATA-VENCIMENTO , :MOVDEBCE-VALOR-DEBITO, :MOVDEBCE-DATA-MOVIMENTO , CURRENT TIMESTAMP , :MOVDEBCE-DIA-DEBITO , :MOVDEBCE-COD-AGENCIA-DEB , :MOVDEBCE-OPER-CONTA-DEB , :MOVDEBCE-NUM-CONTA-DEB , :MOVDEBCE-DIG-CONTA-DEB , :MOVDEBCE-COD-CONVENIO , :MOVDEBCE-DATA-ENVIO:VIND-DTENV , :MOVDEBCE-DATA-RETORNO:VIND-DTRET , :MOVDEBCE-COD-RETORNO-CEF:VIND-CODRET , :MOVDEBCE-NSAS , :MOVDEBCE-COD-USUARIO , :MOVDEBCE-NUM-REQUISICAO:VIND-NREQ , :MOVDEBCE-NUM-CARTAO:VIND-CCRE , :MOVDEBCE-SEQUENCIA:VIND-SEQUEN , :MOVDEBCE-NUM-LOTE:VIND-NLOTE , :MOVDEBCE-DTCREDITO:VIND-DTCRED , :MOVDEBCE-STATUS-CARTAO:VIND-STATUS , :MOVDEBCE-VLR-CREDITO:VIND-VLCRED , :MOVDEBCE-NUM-CERTIFICADO , :MOVDEBCE-COD-MOEDA :VIND-COD-MOEDA , :MOVDEBCE-PCT-INDICE :VIND-PCT-INDICE , :MOVDEBCE-VLR-ORIGINAL :VIND-VLR-ORIGINAL , :MOVDEBCE-VLR-PRORATA :VIND-VLR-PRORATA , :MOVDEBCE-VLR-JUROS :VIND-VLR-JUROS , :MOVDEBCE-VLR-MULTA :VIND-VLR-MULTA , :MOVDEBCE-DTA-ORIGINAL :VIND-DTA-ORIGINAL , :MOVDEBCE-COD-IDLG :VIND-COD-IDLG) END-EXEC */

            var r3410_05_INSERT_MOVIMENTO_DB_INSERT_1_Insert1 = new R3410_05_INSERT_MOVIMENTO_DB_INSERT_1_Insert1()
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
                VIND_CCRE = VIND_CCRE.ToString(),
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
                MOVDEBCE_NUM_CERTIFICADO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CERTIFICADO.ToString(),
                MOVDEBCE_COD_MOEDA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_MOEDA.ToString(),
                VIND_COD_MOEDA = VIND_COD_MOEDA.ToString(),
                MOVDEBCE_PCT_INDICE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_PCT_INDICE.ToString(),
                VIND_PCT_INDICE = VIND_PCT_INDICE.ToString(),
                MOVDEBCE_VLR_ORIGINAL = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_ORIGINAL.ToString(),
                VIND_VLR_ORIGINAL = VIND_VLR_ORIGINAL.ToString(),
                MOVDEBCE_VLR_PRORATA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_PRORATA.ToString(),
                VIND_VLR_PRORATA = VIND_VLR_PRORATA.ToString(),
                MOVDEBCE_VLR_JUROS = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_JUROS.ToString(),
                VIND_VLR_JUROS = VIND_VLR_JUROS.ToString(),
                MOVDEBCE_VLR_MULTA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_MULTA.ToString(),
                VIND_VLR_MULTA = VIND_VLR_MULTA.ToString(),
                MOVDEBCE_DTA_ORIGINAL = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DTA_ORIGINAL.ToString(),
                VIND_DTA_ORIGINAL = VIND_DTA_ORIGINAL.ToString(),
                MOVDEBCE_COD_IDLG = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_IDLG.ToString(),
                VIND_COD_IDLG = VIND_COD_IDLG.ToString(),
            };

            R3410_05_INSERT_MOVIMENTO_DB_INSERT_1_Insert1.Execute(r3410_05_INSERT_MOVIMENTO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3410_99_SAIDA*/

        [StopWatch]
        /*" R3420-00-UPDATE-MOVTO-DEBITOCC-SECTION */
        private void R3420_00_UPDATE_MOVTO_DEBITOCC_SECTION()
        {
            /*" -3861- MOVE 'R3420-00-UPDATE-MOVTO-DEBITOCC ' TO PARAGRAFO */
            _.Move("R3420-00-UPDATE-MOVTO-DEBITOCC ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3862- MOVE 'UPDATE SEGUROS.MOVTO_DEBITOCC_CEF ' TO COMANDO */
            _.Move("UPDATE SEGUROS.MOVTO_DEBITOCC_CEF ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3863- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3863- . */

            /*" -0- FLUXCONTROL_PERFORM R3420_50_UPDATE_MOVTO_DEBITOCC */

            R3420_50_UPDATE_MOVTO_DEBITOCC();

        }

        [StopWatch]
        /*" R3420-50-UPDATE-MOVTO-DEBITOCC */
        private void R3420_50_UPDATE_MOVTO_DEBITOCC(bool isPerform = false)
        {
            /*" -3869- COMPUTE WS-NSAS-ERRO = WS-NSAS-ERRO - 1 */
            WS_NSAS_ERRO.Value = WS_NSAS_ERRO - 1;

            /*" -3870- IF WS-NSAS-ERRO < -5 */

            if (WS_NSAS_ERRO < -5)
            {

                /*" -3871- DISPLAY 'R3420-00 - ERRO NO UPDATE (MOVTO_DEBITOCC_CEF)' */
                _.Display($"R3420-00 - ERRO NO UPDATE (MOVTO_DEBITOCC_CEF)");

                /*" -3872- DISPLAY 'MOVDEBCE-NUM-APOLICE... ' MOVDEBCE-NUM-APOLICE */
                _.Display($"MOVDEBCE-NUM-APOLICE... {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE}");

                /*" -3873- DISPLAY 'MOVDEBCE-NUM-ENDOSSO... ' MOVDEBCE-NUM-ENDOSSO */
                _.Display($"MOVDEBCE-NUM-ENDOSSO... {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO}");

                /*" -3874- DISPLAY 'MOVDEBCE-NUM-PARCELA... ' MOVDEBCE-NUM-PARCELA */
                _.Display($"MOVDEBCE-NUM-PARCELA... {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA}");

                /*" -3875- DISPLAY 'MOVDEBCE-COD-CONVENIO.. ' MOVDEBCE-COD-CONVENIO */
                _.Display($"MOVDEBCE-COD-CONVENIO.. {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO}");

                /*" -3877- DISPLAY 'SITUACAO-COBRANCA...... ' MOVDEBCE-SITUACAO-COBRANCA */
                _.Display($"SITUACAO-COBRANCA...... {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA}");

                /*" -3878- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3880- END-IF */
            }


            /*" -3889- PERFORM R3420_50_UPDATE_MOVTO_DEBITOCC_DB_UPDATE_1 */

            R3420_50_UPDATE_MOVTO_DEBITOCC_DB_UPDATE_1();

            /*" -3892- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -3893- PERFORM R3430-00-UPDATE-HIST-LANC-CTA */

                R3430_00_UPDATE_HIST_LANC_CTA_SECTION();

                /*" -3894- ELSE */
            }
            else
            {


                /*" -3895- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -3896- GO TO R3420-50-UPDATE-MOVTO-DEBITOCC */
                    new Task(() => R3420_50_UPDATE_MOVTO_DEBITOCC()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -3897- ELSE */
                }
                else
                {


                    /*" -3898- DISPLAY 'R3420-00 - PROBLEMA UPDATE (MOVTO_DEBITOCC)' */
                    _.Display($"R3420-00 - PROBLEMA UPDATE (MOVTO_DEBITOCC)");

                    /*" -3899- DISPLAY 'MOVDEBCE-NUM-APOLICE.. ' MOVDEBCE-NUM-APOLICE */
                    _.Display($"MOVDEBCE-NUM-APOLICE.. {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE}");

                    /*" -3900- DISPLAY 'MOVDEBCE-NUM-ENDOSSO.. ' MOVDEBCE-NUM-ENDOSSO */
                    _.Display($"MOVDEBCE-NUM-ENDOSSO.. {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO}");

                    /*" -3901- DISPLAY 'MOVDEBCE-NUM-PARCELA.. ' MOVDEBCE-NUM-PARCELA */
                    _.Display($"MOVDEBCE-NUM-PARCELA.. {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA}");

                    /*" -3902- DISPLAY 'MOVDEBCE-COD-CONVENIO. ' MOVDEBCE-COD-CONVENIO */
                    _.Display($"MOVDEBCE-COD-CONVENIO. {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO}");

                    /*" -3904- DISPLAY 'SITUACAO-COBRANCA..... ' MOVDEBCE-SITUACAO-COBRANCA */
                    _.Display($"SITUACAO-COBRANCA..... {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA}");

                    /*" -3905- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3906- END-IF */
                }


                /*" -3907- END-IF */
            }


            /*" -3907- . */

        }

        [StopWatch]
        /*" R3420-50-UPDATE-MOVTO-DEBITOCC-DB-UPDATE-1 */
        public void R3420_50_UPDATE_MOVTO_DEBITOCC_DB_UPDATE_1()
        {
            /*" -3889- EXEC SQL UPDATE SEGUROS.MOVTO_DEBITOCC_CEF SET NSAS = :WS-NSAS-ERRO, SITUACAO_COBRANCA = '6' WHERE NUM_APOLICE = :MOVDEBCE-NUM-APOLICE AND NUM_ENDOSSO = :MOVDEBCE-NUM-ENDOSSO AND NUM_PARCELA = :MOVDEBCE-NUM-PARCELA AND COD_CONVENIO = :MOVDEBCE-COD-CONVENIO AND NSAS = :MOVDEBCE-NSAS END-EXEC */

            var r3420_50_UPDATE_MOVTO_DEBITOCC_DB_UPDATE_1_Update1 = new R3420_50_UPDATE_MOVTO_DEBITOCC_DB_UPDATE_1_Update1()
            {
                WS_NSAS_ERRO = WS_NSAS_ERRO.ToString(),
                MOVDEBCE_COD_CONVENIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.ToString(),
                MOVDEBCE_NUM_APOLICE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.ToString(),
                MOVDEBCE_NUM_ENDOSSO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO.ToString(),
                MOVDEBCE_NUM_PARCELA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA.ToString(),
                MOVDEBCE_NSAS = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS.ToString(),
            };

            R3420_50_UPDATE_MOVTO_DEBITOCC_DB_UPDATE_1_Update1.Execute(r3420_50_UPDATE_MOVTO_DEBITOCC_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3420_99_SAIDA*/

        [StopWatch]
        /*" R3430-00-UPDATE-HIST-LANC-CTA-SECTION */
        private void R3430_00_UPDATE_HIST_LANC_CTA_SECTION()
        {
            /*" -3915- MOVE 'R3430-00-UPDATE-HIST-LANC-CTA ' TO PARAGRAFO. */
            _.Move("R3430-00-UPDATE-HIST-LANC-CTA ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3916- MOVE 'R3430-00-UPDATE-HIST-LANC-CTA ' TO COMANDO. */
            _.Move("R3430-00-UPDATE-HIST-LANC-CTA ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3918- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3927- PERFORM R3430_00_UPDATE_HIST_LANC_CTA_DB_UPDATE_1 */

            R3430_00_UPDATE_HIST_LANC_CTA_DB_UPDATE_1();

            /*" -3930- IF SQLCODE NOT EQUAL ZEROS AND +100 */

            if (!DB.SQLCODE.In("00", "+100"))
            {

                /*" -3931- DISPLAY 'R3430-00 - PROBLEMAS UPDATE (HIST_LANC_CTA)' */
                _.Display($"R3430-00 - PROBLEMAS UPDATE (HIST_LANC_CTA)");

                /*" -3932- DISPLAY 'NUM-CERTIFICADO... ' RELATORI-NUM-CERTIFICADO */
                _.Display($"NUM-CERTIFICADO... {RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO}");

                /*" -3933- DISPLAY 'NUM-PARCELA....... ' RELATORI-NUM-PARCELA */
                _.Display($"NUM-PARCELA....... {RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA}");

                /*" -3934- DISPLAY 'OCORR-HISTORICO... ' PARCEVID-OCORR-HISTORICO */
                _.Display($"OCORR-HISTORICO... {PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_OCORR_HISTORICO}");

                /*" -3935- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3936- END-IF */
            }


            /*" -3936- . */

        }

        [StopWatch]
        /*" R3430-00-UPDATE-HIST-LANC-CTA-DB-UPDATE-1 */
        public void R3430_00_UPDATE_HIST_LANC_CTA_DB_UPDATE_1()
        {
            /*" -3927- EXEC SQL UPDATE SEGUROS.HIST_LANC_CTA SET SIT_REGISTRO = '2' WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO AND NUM_PARCELA = :RELATORI-NUM-PARCELA AND OCORR_HISTORICOCTA < :PARCEVID-OCORR-HISTORICO AND TIPLANC = '2' AND CODCONV = 6090 AND SIT_REGISTRO = '0' END-EXEC */

            var r3430_00_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1 = new R3430_00_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1()
            {
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
                PARCEVID_OCORR_HISTORICO = PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_OCORR_HISTORICO.ToString(),
                RELATORI_NUM_PARCELA = RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA.ToString(),
            };

            R3430_00_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1.Execute(r3430_00_UPDATE_HIST_LANC_CTA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3430_99_SAIDA*/

        [StopWatch]
        /*" R3440-00-GRAVA-MOVTO-DEBCC-CEF-SECTION */
        private void R3440_00_GRAVA_MOVTO_DEBCC_CEF_SECTION()
        {
            /*" -3948- MOVE 'R3440-00-GRAVA-MOVTO-DEBCC-CEF ' TO PARAGRAFO. */
            _.Move("R3440-00-GRAVA-MOVTO-DEBCC-CEF ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3949- MOVE 'R3440-00-GRAVA-MOVTO-DEBCC-CEF ' TO COMANDO. */
            _.Move("R3440-00-GRAVA-MOVTO-DEBCC-CEF ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3951- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3952- MOVE 6090 TO CONVEVG-COD-NAOACEITE */
            _.Move(6090, CONVEVG.DCLCONVENIOS_VG.CONVEVG_COD_NAOACEITE);

            /*" -3953- MOVE RELATORI-NUM-CERTIFICADO TO MOVDEBCE-NUM-CARTAO */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO);

            /*" -3954- MOVE 0 TO MOVDEBCE-COD-EMPRESA */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_EMPRESA);

            /*" -3955- MOVE COBHISVI-NUM-TITULO TO MOVDEBCE-NUM-APOLICE */
            _.Move(COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_TITULO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);

            /*" -3956- MOVE 0 TO MOVDEBCE-NUM-ENDOSSO */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);

            /*" -3957- MOVE RELATORI-NUM-PARCELA TO MOVDEBCE-NUM-PARCELA */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA);

            /*" -3958- MOVE ' ' TO MOVDEBCE-SITUACAO-COBRANCA */
            _.Move(" ", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);

            /*" -3960- MOVE WHOST-DATA-CRED TO MOVDEBCE-DATA-VENCIMENTO */
            _.Move(WHOST_DATA_CRED, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO);

            /*" -3962- MOVE WHOST-NEW-PRM TO MOVDEBCE-VALOR-DEBITO */
            _.Move(WHOST_NEW_PRM, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO);

            /*" -3963- MOVE SISTEMAS-DATA-MOV-ABERTO TO MOVDEBCE-DATA-MOVIMENTO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO);

            /*" -3969- MOVE WHOST-DATA-CRED(1:2) TO MOVDEBCE-DIA-DEBITO */
            _.Move(WHOST_DATA_CRED.Substring(1, 2), MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIA_DEBITO);

            /*" -3970- MOVE OPCPAGVI-COD-AGENCIA-DEBITO TO MOVDEBCE-COD-AGENCIA-DEB */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB);

            /*" -3971- MOVE OPCPAGVI-OPE-CONTA-DEBITO TO MOVDEBCE-OPER-CONTA-DEB */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB);

            /*" -3972- MOVE OPCPAGVI-NUM-CONTA-DEBITO TO MOVDEBCE-NUM-CONTA-DEB */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB);

            /*" -3974- MOVE OPCPAGVI-DIG-CONTA-DEBITO TO MOVDEBCE-DIG-CONTA-DEB */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB);

            /*" -3975- MOVE 609000 TO MOVDEBCE-COD-CONVENIO */
            _.Move(609000, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);

            /*" -3977- MOVE ZEROS TO MOVDEBCE-NSAS */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS);

            /*" -3978- MOVE 'VA0469B' TO MOVDEBCE-COD-USUARIO */
            _.Move("VA0469B", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_USUARIO);

            /*" -3979- MOVE RELATORI-NUM-CERTIFICADO TO MOVDEBCE-NUM-CERTIFICADO */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CERTIFICADO);

            /*" -3980- MOVE LK-VG011-S-COD-MOEDA TO MOVDEBCE-COD-MOEDA */
            _.Move(SPVG011W.LK_VG011_S_COD_MOEDA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_MOEDA);

            /*" -3981- MOVE LK-VG011-S-PC-INDICE TO MOVDEBCE-PCT-INDICE */
            _.Move(SPVG011W.LK_VG011_S_PC_INDICE, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_PCT_INDICE);

            /*" -3982- MOVE LK-VG011-E-VL-ORIGINAL TO MOVDEBCE-VLR-ORIGINAL */
            _.Move(SPVG011W.LK_VG011_E_VL_ORIGINAL, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_ORIGINAL);

            /*" -3983- MOVE LK-VG011-S-VL-CORRIGIDO TO MOVDEBCE-VLR-PRORATA */
            _.Move(SPVG011W.LK_VG011_S_VL_CORRIGIDO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_PRORATA);

            /*" -3984- MOVE LK-VG011-S-VL-JUROS TO MOVDEBCE-VLR-JUROS */
            _.Move(SPVG011W.LK_VG011_S_VL_JUROS, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_JUROS);

            /*" -3985- MOVE LK-VG011-S-VL-MULTA TO MOVDEBCE-VLR-MULTA */
            _.Move(SPVG011W.LK_VG011_S_VL_MULTA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_MULTA);

            /*" -3986- MOVE LK-VG011-S-DTA-FIM-PGMNTO TO MOVDEBCE-DTA-ORIGINAL */
            _.Move(SPVG011W.LK_VG011_S_DTA_FIM_PGMNTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DTA_ORIGINAL);

            /*" -3988- MOVE SPACES TO MOVDEBCE-COD-IDLG */
            _.Move("", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_IDLG);

            /*" -3998- MOVE -1 TO VIND-DTENV VIND-DTRET VIND-CODRET VIND-NREQ VIND-SEQUEN VIND-NLOTE VIND-STATUS VIND-VLCRED VIND-DTCRED VIND-COD-IDLG */
            _.Move(-1, VIND_DTENV, VIND_DTRET, VIND_CODRET, VIND_NREQ, VIND_SEQUEN, VIND_NLOTE, VIND_STATUS, VIND_VLCRED, VIND_DTCRED, VIND_COD_IDLG);

            /*" -3999- IF LK-VG011-S-COD-MOEDA > ZEROS */

            if (SPVG011W.LK_VG011_S_COD_MOEDA > 00)
            {

                /*" -4006- MOVE ZEROS TO VIND-COD-MOEDA VIND-PCT-INDICE VIND-VLR-ORIGINAL VIND-VLR-PRORATA VIND-VLR-JUROS VIND-VLR-MULTA VIND-DTA-ORIGINAL */
                _.Move(0, VIND_COD_MOEDA, VIND_PCT_INDICE, VIND_VLR_ORIGINAL, VIND_VLR_PRORATA, VIND_VLR_JUROS, VIND_VLR_MULTA, VIND_DTA_ORIGINAL);

                /*" -4007- ELSE */
            }
            else
            {


                /*" -4014- MOVE -1 TO VIND-COD-MOEDA VIND-PCT-INDICE VIND-VLR-ORIGINAL VIND-VLR-PRORATA VIND-VLR-JUROS VIND-VLR-MULTA VIND-DTA-ORIGINAL */
                _.Move(-1, VIND_COD_MOEDA, VIND_PCT_INDICE, VIND_VLR_ORIGINAL, VIND_VLR_PRORATA, VIND_VLR_JUROS, VIND_VLR_MULTA, VIND_DTA_ORIGINAL);

                /*" -4016- END-IF */
            }


            /*" -4017- PERFORM R3410-00-INSERT-MOVTO-DEBITOCC */

            R3410_00_INSERT_MOVTO_DEBITOCC_SECTION();

            /*" -4017- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3440_99_SAIDA*/

        [StopWatch]
        /*" R3500-00-DEVOLVE-CARTAO-9022-SECTION */
        private void R3500_00_DEVOLVE_CARTAO_9022_SECTION()
        {
            /*" -4030- MOVE 'R3500-00-DEVOLVE-CARTAO-9022' TO PARAGRAFO. */
            _.Move("R3500-00-DEVOLVE-CARTAO-9022", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4031- MOVE 'R3500-00-DEVOLVE-CARTAO-9022' TO COMANDO. */
            _.Move("R3500-00-DEVOLVE-CARTAO-9022", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4033- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4034- MOVE 9022 TO CONVEVG-COD-NAOACEITE */
            _.Move(9022, CONVEVG.DCLCONVENIOS_VG.CONVEVG_COD_NAOACEITE);

            /*" -4035- MOVE RELATORI-NUM-CERTIFICADO TO MOVDEBCE-NUM-CARTAO */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO);

            /*" -4036- MOVE 0 TO MOVDEBCE-COD-EMPRESA */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_EMPRESA);

            /*" -4037- MOVE COBHISVI-NUM-TITULO TO MOVDEBCE-NUM-APOLICE */
            _.Move(COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_TITULO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);

            /*" -4038- MOVE 0 TO MOVDEBCE-NUM-ENDOSSO */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);

            /*" -4039- MOVE RELATORI-NUM-PARCELA TO MOVDEBCE-NUM-PARCELA */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA);

            /*" -4040- MOVE ' ' TO MOVDEBCE-SITUACAO-COBRANCA */
            _.Move(" ", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);

            /*" -4042- MOVE WHOST-DATA-CRED TO MOVDEBCE-DATA-VENCIMENTO */
            _.Move(WHOST_DATA_CRED, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO);

            /*" -4044- MOVE LK-VG011-E-VL-ORIGINAL TO MOVDEBCE-VALOR-DEBITO */
            _.Move(SPVG011W.LK_VG011_E_VL_ORIGINAL, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO);

            /*" -4045- MOVE SISTEMAS-DATA-MOV-ABERTO TO MOVDEBCE-DATA-MOVIMENTO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO);

            /*" -4046- MOVE 0 TO MOVDEBCE-DIA-DEBITO */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIA_DEBITO);

            /*" -4047- MOVE 0 TO MOVDEBCE-COD-AGENCIA-DEB */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB);

            /*" -4048- MOVE 0 TO MOVDEBCE-NUM-CONTA-DEB */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB);

            /*" -4049- MOVE CONVEVG-COD-NAOACEITE TO MOVDEBCE-COD-CONVENIO */
            _.Move(CONVEVG.DCLCONVENIOS_VG.CONVEVG_COD_NAOACEITE, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);

            /*" -4050- MOVE ZEROS TO MOVDEBCE-NSAS */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS);

            /*" -4052- MOVE 'VA0469B' TO MOVDEBCE-COD-USUARIO */
            _.Move("VA0469B", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_USUARIO);

            /*" -4054- MOVE RELATORI-NUM-CERTIFICADO TO MOVDEBCE-NUM-CERTIFICADO */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CERTIFICADO);

            /*" -4055- MOVE LK-VG011-S-COD-MOEDA TO MOVDEBCE-COD-MOEDA */
            _.Move(SPVG011W.LK_VG011_S_COD_MOEDA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_MOEDA);

            /*" -4056- MOVE LK-VG011-S-PC-INDICE TO MOVDEBCE-PCT-INDICE */
            _.Move(SPVG011W.LK_VG011_S_PC_INDICE, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_PCT_INDICE);

            /*" -4057- MOVE LK-VG011-E-VL-ORIGINAL TO MOVDEBCE-VLR-ORIGINAL */
            _.Move(SPVG011W.LK_VG011_E_VL_ORIGINAL, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_ORIGINAL);

            /*" -4058- MOVE LK-VG011-S-VL-CORRIGIDO TO MOVDEBCE-VLR-PRORATA */
            _.Move(SPVG011W.LK_VG011_S_VL_CORRIGIDO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_PRORATA);

            /*" -4059- MOVE LK-VG011-S-VL-JUROS TO MOVDEBCE-VLR-JUROS */
            _.Move(SPVG011W.LK_VG011_S_VL_JUROS, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_JUROS);

            /*" -4060- MOVE LK-VG011-S-VL-MULTA TO MOVDEBCE-VLR-MULTA */
            _.Move(SPVG011W.LK_VG011_S_VL_MULTA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_MULTA);

            /*" -4061- MOVE LK-VG011-S-DTA-FIM-PGMNTO TO MOVDEBCE-DTA-ORIGINAL */
            _.Move(SPVG011W.LK_VG011_S_DTA_FIM_PGMNTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DTA_ORIGINAL);

            /*" -4063- MOVE SPACES TO MOVDEBCE-COD-IDLG */
            _.Move("", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_IDLG);

            /*" -4073- MOVE -1 TO VIND-DTENV VIND-DTRET VIND-CODRET VIND-NREQ VIND-SEQUEN VIND-NLOTE VIND-STATUS VIND-VLCRED VIND-DTCRED VIND-COD-IDLG */
            _.Move(-1, VIND_DTENV, VIND_DTRET, VIND_CODRET, VIND_NREQ, VIND_SEQUEN, VIND_NLOTE, VIND_STATUS, VIND_VLCRED, VIND_DTCRED, VIND_COD_IDLG);

            /*" -4074- IF LK-VG011-S-COD-MOEDA > ZEROS */

            if (SPVG011W.LK_VG011_S_COD_MOEDA > 00)
            {

                /*" -4081- MOVE ZEROS TO VIND-COD-MOEDA VIND-PCT-INDICE VIND-VLR-ORIGINAL VIND-VLR-PRORATA VIND-VLR-JUROS VIND-VLR-MULTA VIND-DTA-ORIGINAL */
                _.Move(0, VIND_COD_MOEDA, VIND_PCT_INDICE, VIND_VLR_ORIGINAL, VIND_VLR_PRORATA, VIND_VLR_JUROS, VIND_VLR_MULTA, VIND_DTA_ORIGINAL);

                /*" -4082- ELSE */
            }
            else
            {


                /*" -4089- MOVE -1 TO VIND-COD-MOEDA VIND-PCT-INDICE VIND-VLR-ORIGINAL VIND-VLR-PRORATA VIND-VLR-JUROS VIND-VLR-MULTA VIND-DTA-ORIGINAL */
                _.Move(-1, VIND_COD_MOEDA, VIND_PCT_INDICE, VIND_VLR_ORIGINAL, VIND_VLR_PRORATA, VIND_VLR_JUROS, VIND_VLR_MULTA, VIND_DTA_ORIGINAL);

                /*" -4091- END-IF */
            }


            /*" -4093- ADD 1 TO AC-I-MOVDEB-EV9022 */
            ACUMULADORES.AC_I_MOVDEB_EV9022.Value = ACUMULADORES.AC_I_MOVDEB_EV9022 + 1;

            /*" -4095- PERFORM R3410-00-INSERT-MOVTO-DEBITOCC */

            R3410_00_INSERT_MOVTO_DEBITOCC_SECTION();

            /*" -4095- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3500_99_SAIDA*/

        [StopWatch]
        /*" R3505-00-SELECT-GE408-SIT0-SECTION */
        private void R3505_00_SELECT_GE408_SIT0_SECTION()
        {
            /*" -4105- MOVE 'R3505-00-SELECT-GE408-SIT0    ' TO PARAGRAFO. */
            _.Move("R3505-00-SELECT-GE408-SIT0    ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4107- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4109- MOVE 'SELECT SEGUROS.GE_RETORNO_CA_CIEL' TO COMANDO. */
            _.Move("SELECT SEGUROS.GE_RETORNO_CA_CIEL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4131- PERFORM R3505_00_SELECT_GE408_SIT0_DB_SELECT_1 */

            R3505_00_SELECT_GE408_SIT0_DB_SELECT_1();

            /*" -4134-  EVALUATE SQLCODE  */

            /*" -4135-  WHEN ZEROS  */

            /*" -4135- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -4136- SET WS-SIM-RETORNOU-SAP TO TRUE */
                WORK_AREA.WS_RETORNO_SAP["WS_SIM_RETORNOU_SAP"] = true;

                /*" -4137-  WHEN +100  */

                /*" -4137- ELSE IF   SQLCODE EQUALS  +100 */
            }
            else

            if (DB.SQLCODE == +100)
            {

                /*" -4138- SET WS-NAO-RETORNOU-SAP TO TRUE */
                WORK_AREA.WS_RETORNO_SAP["WS_NAO_RETORNOU_SAP"] = true;

                /*" -4139-  WHEN OTHER  */

                /*" -4139- ELSE */
            }
            else
            {


                /*" -4140- DISPLAY 'R3505-00 - PROBLEMAS SELECT (GE408   )   ' */
                _.Display($"R3505-00 - PROBLEMAS SELECT (GE408   )   ");

                /*" -4141- DISPLAY 'NUM_CERTIFICADO = ' RELATORI-NUM-CERTIFICADO */
                _.Display($"NUM_CERTIFICADO = {RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO}");

                /*" -4142- DISPLAY 'NUM-PARCELA = ' RELATORI-NUM-PARCELA */
                _.Display($"NUM-PARCELA = {RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA}");

                /*" -4143- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4145-  END-EVALUATE  */

                /*" -4145- END-IF */
            }


            /*" -4145- . */

        }

        [StopWatch]
        /*" R3505-00-SELECT-GE408-SIT0-DB-SELECT-1 */
        public void R3505_00_SELECT_GE408_SIT0_DB_SELECT_1()
        {
            /*" -4131- EXEC SQL SELECT T2.NUM_CERTIFICADO, T1.VLR_TOT_PREMIO INTO :GE408-NUM-CERTIFICADO, :GE408-VLR-COBRANCA FROM SEGUROS.GE_CONTROLE_CARTAO_CIELO T1 , SEGUROS.GE_RETORNO_CA_CIELO T2 , SEGUROS.PARCELAS_VIDAZUL T3 WHERE T1.NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO AND T1.NUM_PARCELA = :RELATORI-NUM-PARCELA AND T1.COD_TP_PAGAMENTO IN ( '01' , '02' ) AND T1.NUM_PROPOSTA = T2.NUM_PROPOSTA AND T1.NUM_CERTIFICADO = T2.NUM_CERTIFICADO AND T1.NUM_PARCELA = T2.NUM_PARCELA AND T1.SEQ_CONTROL_CARTAO = T2.SEQ_CONTROL_CARTAO AND T2.COD_MOVIMENTO = '03' AND T2.COD_RETORNO = ' CC' AND T1.NUM_CERTIFICADO = T3.NUM_CERTIFICADO AND T1.NUM_PARCELA = T3.NUM_PARCELA AND T3.SIT_REGISTRO IN ( ' ' , '0' , '1' , '2' ) FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC */

            var r3505_00_SELECT_GE408_SIT0_DB_SELECT_1_Query1 = new R3505_00_SELECT_GE408_SIT0_DB_SELECT_1_Query1()
            {
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
                RELATORI_NUM_PARCELA = RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA.ToString(),
            };

            var executed_1 = R3505_00_SELECT_GE408_SIT0_DB_SELECT_1_Query1.Execute(r3505_00_SELECT_GE408_SIT0_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE408_NUM_CERTIFICADO, GE408.DCLGE_RETORNO_CA_CIELO.GE408_NUM_CERTIFICADO);
                _.Move(executed_1.GE408_VLR_COBRANCA, GE408.DCLGE_RETORNO_CA_CIELO.GE408_VLR_COBRANCA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3505_99_SAIDA*/

        [StopWatch]
        /*" R3540-00-DEVOLVE-CORRECAO-CRTO-SECTION */
        private void R3540_00_DEVOLVE_CORRECAO_CRTO_SECTION()
        {
            /*" -4159- MOVE 'R3540-00-DEVOLVE-CORRECAO-CRTO' TO PARAGRAFO. */
            _.Move("R3540-00-DEVOLVE-CORRECAO-CRTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4160- MOVE 'R3540-00-DEVOLVE-CORRECAO-CRTO' TO COMANDO. */
            _.Move("R3540-00-DEVOLVE-CORRECAO-CRTO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4163- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4164- MOVE RELATORI-NUM-CERTIFICADO TO MOVDEBCE-NUM-CARTAO */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO);

            /*" -4165- MOVE 0 TO MOVDEBCE-COD-EMPRESA */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_EMPRESA);

            /*" -4166- MOVE COBHISVI-NUM-TITULO TO MOVDEBCE-NUM-APOLICE */
            _.Move(COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_TITULO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);

            /*" -4167- MOVE 0 TO MOVDEBCE-NUM-ENDOSSO */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);

            /*" -4168- MOVE RELATORI-NUM-PARCELA TO MOVDEBCE-NUM-PARCELA */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA);

            /*" -4170- MOVE WHOST-DATA-CRED TO MOVDEBCE-DATA-VENCIMENTO */
            _.Move(WHOST_DATA_CRED, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO);

            /*" -4172- MOVE LK-VG011-S-VL-JUROS TO MOVDEBCE-VALOR-DEBITO */
            _.Move(SPVG011W.LK_VG011_S_VL_JUROS, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO);

            /*" -4173- MOVE SISTEMAS-DATA-MOV-ABERTO TO MOVDEBCE-DATA-MOVIMENTO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO);

            /*" -4175- MOVE WHOST-DATA-CRED(1:2) TO MOVDEBCE-DIA-DEBITO */
            _.Move(WHOST_DATA_CRED.Substring(1, 2), MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIA_DEBITO);

            /*" -4177- IF RELATORI-MES-REFERENCIA EQUAL ZEROS OR RELATORI-NUM-SINISTRO EQUAL ZEROS */

            if (RELATORI.DCLRELATORIOS.RELATORI_MES_REFERENCIA == 00 || RELATORI.DCLRELATORIOS.RELATORI_NUM_SINISTRO == 00)
            {

                /*" -4181- MOVE ZEROS TO MOVDEBCE-COD-AGENCIA-DEB MOVDEBCE-OPER-CONTA-DEB MOVDEBCE-NUM-CONTA-DEB MOVDEBCE-DIG-CONTA-DEB */
                _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB);

                /*" -4182- MOVE 'R' TO MOVDEBCE-SITUACAO-COBRANCA */
                _.Move("R", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);

                /*" -4183- ELSE */
            }
            else
            {


                /*" -4184- MOVE RELATORI-MES-REFERENCIA TO MOVDEBCE-COD-AGENCIA-DEB */
                _.Move(RELATORI.DCLRELATORIOS.RELATORI_MES_REFERENCIA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB);

                /*" -4185- MOVE RELATORI-ANO-REFERENCIA TO MOVDEBCE-OPER-CONTA-DEB */
                _.Move(RELATORI.DCLRELATORIOS.RELATORI_ANO_REFERENCIA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB);

                /*" -4186- MOVE RELATORI-NUM-SINISTRO TO MOVDEBCE-NUM-CONTA-DEB */
                _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_SINISTRO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB);

                /*" -4187- MOVE RELATORI-ORGAO-EMISSOR TO MOVDEBCE-DIG-CONTA-DEB */
                _.Move(RELATORI.DCLRELATORIOS.RELATORI_ORGAO_EMISSOR, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB);

                /*" -4188- MOVE ' ' TO MOVDEBCE-SITUACAO-COBRANCA */
                _.Move(" ", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);

                /*" -4190- END-IF */
            }


            /*" -4191- MOVE 609000 TO MOVDEBCE-COD-CONVENIO */
            _.Move(609000, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);

            /*" -4193- MOVE ZEROS TO MOVDEBCE-NSAS */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS);

            /*" -4194- MOVE 'VA0469B' TO MOVDEBCE-COD-USUARIO */
            _.Move("VA0469B", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_USUARIO);

            /*" -4195- MOVE RELATORI-NUM-CERTIFICADO TO MOVDEBCE-NUM-CERTIFICADO */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CERTIFICADO);

            /*" -4196- MOVE LK-VG011-S-COD-MOEDA TO MOVDEBCE-COD-MOEDA */
            _.Move(SPVG011W.LK_VG011_S_COD_MOEDA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_MOEDA);

            /*" -4197- MOVE LK-VG011-S-PC-INDICE TO MOVDEBCE-PCT-INDICE */
            _.Move(SPVG011W.LK_VG011_S_PC_INDICE, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_PCT_INDICE);

            /*" -4198- MOVE LK-VG011-E-VL-ORIGINAL TO MOVDEBCE-VLR-ORIGINAL */
            _.Move(SPVG011W.LK_VG011_E_VL_ORIGINAL, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_ORIGINAL);

            /*" -4199- MOVE LK-VG011-S-VL-CORRIGIDO TO MOVDEBCE-VLR-PRORATA */
            _.Move(SPVG011W.LK_VG011_S_VL_CORRIGIDO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_PRORATA);

            /*" -4200- MOVE WHOST-JUROS TO MOVDEBCE-VLR-JUROS */
            _.Move(WHOST_JUROS, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_JUROS);

            /*" -4201- MOVE LK-VG011-S-VL-MULTA TO MOVDEBCE-VLR-MULTA */
            _.Move(SPVG011W.LK_VG011_S_VL_MULTA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_MULTA);

            /*" -4202- MOVE LK-VG011-S-DTA-FIM-PGMNTO TO MOVDEBCE-DTA-ORIGINAL */
            _.Move(SPVG011W.LK_VG011_S_DTA_FIM_PGMNTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DTA_ORIGINAL);

            /*" -4204- MOVE SPACES TO MOVDEBCE-COD-IDLG */
            _.Move("", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_IDLG);

            /*" -4214- MOVE -1 TO VIND-DTENV VIND-DTRET VIND-CODRET VIND-NREQ VIND-SEQUEN VIND-NLOTE VIND-STATUS VIND-VLCRED VIND-DTCRED VIND-COD-IDLG */
            _.Move(-1, VIND_DTENV, VIND_DTRET, VIND_CODRET, VIND_NREQ, VIND_SEQUEN, VIND_NLOTE, VIND_STATUS, VIND_VLCRED, VIND_DTCRED, VIND_COD_IDLG);

            /*" -4215- IF LK-VG011-S-COD-MOEDA > ZEROS */

            if (SPVG011W.LK_VG011_S_COD_MOEDA > 00)
            {

                /*" -4222- MOVE ZEROS TO VIND-COD-MOEDA VIND-PCT-INDICE VIND-VLR-ORIGINAL VIND-VLR-PRORATA VIND-VLR-JUROS VIND-VLR-MULTA VIND-DTA-ORIGINAL */
                _.Move(0, VIND_COD_MOEDA, VIND_PCT_INDICE, VIND_VLR_ORIGINAL, VIND_VLR_PRORATA, VIND_VLR_JUROS, VIND_VLR_MULTA, VIND_DTA_ORIGINAL);

                /*" -4223- ELSE */
            }
            else
            {


                /*" -4230- MOVE -1 TO VIND-COD-MOEDA VIND-PCT-INDICE VIND-VLR-ORIGINAL VIND-VLR-PRORATA VIND-VLR-JUROS VIND-VLR-MULTA VIND-DTA-ORIGINAL */
                _.Move(-1, VIND_COD_MOEDA, VIND_PCT_INDICE, VIND_VLR_ORIGINAL, VIND_VLR_PRORATA, VIND_VLR_JUROS, VIND_VLR_MULTA, VIND_DTA_ORIGINAL);

                /*" -4232- END-IF */
            }


            /*" -4234- PERFORM R3410-00-INSERT-MOVTO-DEBITOCC */

            R3410_00_INSERT_MOVTO_DEBITOCC_SECTION();

            /*" -4235- ADD 1 TO AC-I-MOVDEB-CORRECAO */
            ACUMULADORES.AC_I_MOVDEB_CORRECAO.Value = ACUMULADORES.AC_I_MOVDEB_CORRECAO + 1;

            /*" -4235- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3540_99_SAIDA*/

        [StopWatch]
        /*" R3550-00-ALTERA-SIT-CORRECAO-SECTION */
        private void R3550_00_ALTERA_SIT_CORRECAO_SECTION()
        {
            /*" -4248- MOVE 'R3550-00-ALTERA-SIT-CORRECAO' TO PARAGRAFO. */
            _.Move("R3550-00-ALTERA-SIT-CORRECAO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4250- MOVE 'UPDATE SEGUROS.MOVTO_DEBITOCC_CEF' TO COMANDO. */
            _.Move("UPDATE SEGUROS.MOVTO_DEBITOCC_CEF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4252- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4253- MOVE RELATORI-NUM-CERTIFICADO TO MOVDEBCE-NUM-CARTAO */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO);

            /*" -4254- MOVE COBHISVI-NUM-TITULO TO MOVDEBCE-NUM-APOLICE */
            _.Move(COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_TITULO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);

            /*" -4255- MOVE RELATORI-NUM-PARCELA TO MOVDEBCE-NUM-PARCELA */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA);

            /*" -4257- MOVE WHOST-DATA-CRED TO MOVDEBCE-DATA-VENCIMENTO */
            _.Move(WHOST_DATA_CRED, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO);

            /*" -4259- MOVE LK-VG011-S-VL-JUROS TO MOVDEBCE-VALOR-DEBITO */
            _.Move(SPVG011W.LK_VG011_S_VL_JUROS, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO);

            /*" -4260- MOVE SISTEMAS-DATA-MOV-ABERTO TO MOVDEBCE-DATA-MOVIMENTO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO);

            /*" -4262- MOVE WHOST-DATA-CRED(1:2) TO MOVDEBCE-DIA-DEBITO */
            _.Move(WHOST_DATA_CRED.Substring(1, 2), MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIA_DEBITO);

            /*" -4263- MOVE RELATORI-MES-REFERENCIA TO MOVDEBCE-COD-AGENCIA-DEB */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_MES_REFERENCIA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB);

            /*" -4264- MOVE RELATORI-ANO-REFERENCIA TO MOVDEBCE-OPER-CONTA-DEB */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_ANO_REFERENCIA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB);

            /*" -4265- MOVE RELATORI-NUM-SINISTRO TO MOVDEBCE-NUM-CONTA-DEB */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_SINISTRO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB);

            /*" -4266- MOVE RELATORI-ORGAO-EMISSOR TO MOVDEBCE-DIG-CONTA-DEB */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_ORGAO_EMISSOR, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB);

            /*" -4268- MOVE ' ' TO MOVDEBCE-SITUACAO-COBRANCA */
            _.Move(" ", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);

            /*" -4270- MOVE 609000 TO MOVDEBCE-COD-CONVENIO */
            _.Move(609000, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);

            /*" -4284- PERFORM R3550_00_ALTERA_SIT_CORRECAO_DB_UPDATE_1 */

            R3550_00_ALTERA_SIT_CORRECAO_DB_UPDATE_1();

            /*" -4287- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -4288- DISPLAY 'R3550-00 - PROBLEMAS UPDATE (MOVTO_DEBITOCC_CEF)' */
                _.Display($"R3550-00 - PROBLEMAS UPDATE (MOVTO_DEBITOCC_CEF)");

                /*" -4289- DISPLAY 'NUM_CARTAO  >> ' MOVDEBCE-NUM-CARTAO */
                _.Display($"NUM_CARTAO  >> {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO}");

                /*" -4290- DISPLAY 'NUM_APOLICE >> ' MOVDEBCE-NUM-APOLICE */
                _.Display($"NUM_APOLICE >> {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE}");

                /*" -4291- DISPLAY 'NUM_PARCELA >> ' MOVDEBCE-NUM-PARCELA */
                _.Display($"NUM_PARCELA >> {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA}");

                /*" -4292- DISPLAY 'SQLCODE     >> ' SQLCODE */
                _.Display($"SQLCODE     >> {DB.SQLCODE}");

                /*" -4293- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4295- END-IF */
            }


            /*" -4296- IF (SQLCODE EQUAL +100) */

            if ((DB.SQLCODE == +100))
            {

                /*" -4298- PERFORM R3560-00-CONS-DVLCAO-CORRECAO */

                R3560_00_CONS_DVLCAO_CORRECAO_SECTION();

                /*" -4299- IF WS-QTD-CORRECAO EQUAL ZEROS */

                if (WS_QTD_CORRECAO == 00)
                {

                    /*" -4300- IF LK-VG011-S-VL-JUROS > ZEROS */

                    if (SPVG011W.LK_VG011_S_VL_JUROS > 00)
                    {

                        /*" -4301- PERFORM R3540-00-DEVOLVE-CORRECAO-CRTO */

                        R3540_00_DEVOLVE_CORRECAO_CRTO_SECTION();

                        /*" -4302- ELSE */
                    }
                    else
                    {


                        /*" -4303- DISPLAY 'ERRO - CORRECAO A SER REENVIADA ZERADA  ' */
                        _.Display($"ERRO - CORRECAO A SER REENVIADA ZERADA  ");

                        /*" -4304- DISPLAY 'NUM_CERTIFICADO >> ' MOVDEBCE-NUM-CARTAO */
                        _.Display($"NUM_CERTIFICADO >> {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO}");

                        /*" -4305- DISPLAY 'NUM_PARCELA     >> ' MOVDEBCE-NUM-PARCELA */
                        _.Display($"NUM_PARCELA     >> {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA}");

                        /*" -4306- ADD 1 TO AC-D-CARTAO-CREDITO */
                        ACUMULADORES.AC_D_CARTAO_CREDITO.Value = ACUMULADORES.AC_D_CARTAO_CREDITO + 1;

                        /*" -4307- GO TO R1000-10-NEXT */

                        R1000_10_NEXT(); //GOTO
                        return;

                        /*" -4308- END-IF */
                    }


                    /*" -4309- ELSE */
                }
                else
                {


                    /*" -4310- DISPLAY 'ERRO - CORRECAO JA FOI DEVOLVIDA P/ O CLIENTE' */
                    _.Display($"ERRO - CORRECAO JA FOI DEVOLVIDA P/ O CLIENTE");

                    /*" -4311- DISPLAY 'NUM_CERTIFICADO >> ' MOVDEBCE-NUM-CARTAO */
                    _.Display($"NUM_CERTIFICADO >> {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO}");

                    /*" -4312- DISPLAY 'NUM_PARCELA     >> ' MOVDEBCE-NUM-PARCELA */
                    _.Display($"NUM_PARCELA     >> {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA}");

                    /*" -4313- ADD 1 TO AC-D-CARTAO-CREDITO */
                    ACUMULADORES.AC_D_CARTAO_CREDITO.Value = ACUMULADORES.AC_D_CARTAO_CREDITO + 1;

                    /*" -4314- GO TO R1000-10-NEXT */

                    R1000_10_NEXT(); //GOTO
                    return;

                    /*" -4315- END-IF */
                }


                /*" -4316- ELSE */
            }
            else
            {


                /*" -4317- ADD 1 TO AC-U-MOVDEB-CORRECAO */
                ACUMULADORES.AC_U_MOVDEB_CORRECAO.Value = ACUMULADORES.AC_U_MOVDEB_CORRECAO + 1;

                /*" -4318- END-IF */
            }


            /*" -4318- . */

        }

        [StopWatch]
        /*" R3550-00-ALTERA-SIT-CORRECAO-DB-UPDATE-1 */
        public void R3550_00_ALTERA_SIT_CORRECAO_DB_UPDATE_1()
        {
            /*" -4284- EXEC SQL UPDATE SEGUROS.MOVTO_DEBITOCC_CEF SET COD_AGENCIA_DEB = :MOVDEBCE-COD-AGENCIA-DEB, OPER_CONTA_DEB = :MOVDEBCE-OPER-CONTA-DEB , NUM_CONTA_DEB = :MOVDEBCE-NUM-CONTA-DEB , DIG_CONTA_DEB = :MOVDEBCE-DIG-CONTA-DEB , DIA_DEBITO = :MOVDEBCE-DIA-DEBITO , DATA_MOVIMENTO = :MOVDEBCE-DATA-MOVIMENTO , SITUACAO_COBRANCA = :MOVDEBCE-SITUACAO-COBRANCA, TIMESTAMP = CURRENT_TIMESTAMP WHERE NUM_CARTAO = :MOVDEBCE-NUM-CARTAO AND NUM_APOLICE = :MOVDEBCE-NUM-APOLICE AND NUM_PARCELA = :MOVDEBCE-NUM-PARCELA AND SITUACAO_COBRANCA = 'R' END-EXEC. */

            var r3550_00_ALTERA_SIT_CORRECAO_DB_UPDATE_1_Update1 = new R3550_00_ALTERA_SIT_CORRECAO_DB_UPDATE_1_Update1()
            {
                MOVDEBCE_SITUACAO_COBRANCA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA.ToString(),
                MOVDEBCE_COD_AGENCIA_DEB = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB.ToString(),
                MOVDEBCE_OPER_CONTA_DEB = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB.ToString(),
                MOVDEBCE_DATA_MOVIMENTO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO.ToString(),
                MOVDEBCE_NUM_CONTA_DEB = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB.ToString(),
                MOVDEBCE_DIG_CONTA_DEB = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB.ToString(),
                MOVDEBCE_DIA_DEBITO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIA_DEBITO.ToString(),
                MOVDEBCE_NUM_APOLICE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.ToString(),
                MOVDEBCE_NUM_PARCELA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA.ToString(),
                MOVDEBCE_NUM_CARTAO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO.ToString(),
            };

            R3550_00_ALTERA_SIT_CORRECAO_DB_UPDATE_1_Update1.Execute(r3550_00_ALTERA_SIT_CORRECAO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3550_99_SAIDA*/

        [StopWatch]
        /*" R3560-00-CONS-DVLCAO-CORRECAO-SECTION */
        private void R3560_00_CONS_DVLCAO_CORRECAO_SECTION()
        {
            /*" -4330- MOVE 'R3560-00-CONS-DVLCAO-CORRECAO' TO PARAGRAFO. */
            _.Move("R3560-00-CONS-DVLCAO-CORRECAO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4332- MOVE 'SELECT SEGUROS.MOVTO_DEBITOCC_CEF' TO COMANDO. */
            _.Move("SELECT SEGUROS.MOVTO_DEBITOCC_CEF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4334- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4336- MOVE ZEROS TO WS-QTD-CORRECAO */
            _.Move(0, WS_QTD_CORRECAO);

            /*" -4344- PERFORM R3560_00_CONS_DVLCAO_CORRECAO_DB_SELECT_1 */

            R3560_00_CONS_DVLCAO_CORRECAO_DB_SELECT_1();

            /*" -4347- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -4348- DISPLAY 'R3560-00 - PROBLEMAS SELECT (MOVTO_DEBITOCC_CEF)' */
                _.Display($"R3560-00 - PROBLEMAS SELECT (MOVTO_DEBITOCC_CEF)");

                /*" -4349- DISPLAY 'NUM_CARTAO   >> ' MOVDEBCE-NUM-CARTAO */
                _.Display($"NUM_CARTAO   >> {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO}");

                /*" -4350- DISPLAY 'COD_CONVENIO >> ' MOVDEBCE-COD-CONVENIO */
                _.Display($"COD_CONVENIO >> {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO}");

                /*" -4351- DISPLAY 'NUM_PARCELA  >> ' MOVDEBCE-NUM-PARCELA */
                _.Display($"NUM_PARCELA  >> {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA}");

                /*" -4352- DISPLAY 'SQLCODE      >> ' SQLCODE */
                _.Display($"SQLCODE      >> {DB.SQLCODE}");

                /*" -4353- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4354- END-IF */
            }


            /*" -4354- . */

        }

        [StopWatch]
        /*" R3560-00-CONS-DVLCAO-CORRECAO-DB-SELECT-1 */
        public void R3560_00_CONS_DVLCAO_CORRECAO_DB_SELECT_1()
        {
            /*" -4344- EXEC SQL SELECT COUNT(*) INTO :WS-QTD-CORRECAO FROM SEGUROS.MOVTO_DEBITOCC_CEF WHERE NUM_CARTAO = :MOVDEBCE-NUM-CARTAO AND NUM_PARCELA = :MOVDEBCE-NUM-PARCELA AND COD_CONVENIO = :MOVDEBCE-COD-CONVENIO AND SITUACAO_COBRANCA IN ( ' ' , '0' , '1' , '2' , '5' ) END-EXEC. */

            var r3560_00_CONS_DVLCAO_CORRECAO_DB_SELECT_1_Query1 = new R3560_00_CONS_DVLCAO_CORRECAO_DB_SELECT_1_Query1()
            {
                MOVDEBCE_COD_CONVENIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.ToString(),
                MOVDEBCE_NUM_PARCELA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA.ToString(),
                MOVDEBCE_NUM_CARTAO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO.ToString(),
            };

            var executed_1 = R3560_00_CONS_DVLCAO_CORRECAO_DB_SELECT_1_Query1.Execute(r3560_00_CONS_DVLCAO_CORRECAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_QTD_CORRECAO, WS_QTD_CORRECAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3560_99_SAIDA*/

        [StopWatch]
        /*" R5000-00-UPDATE-AVISOSAL-SECTION */
        private void R5000_00_UPDATE_AVISOSAL_SECTION()
        {
            /*" -4365- MOVE 'R5000-00-UPDATE-AVISOSAL      ' TO PARAGRAFO. */
            _.Move("R5000-00-UPDATE-AVISOSAL      ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4366- MOVE 'UPDATE SEGUROS.AVISOS_SALDOS     ' TO COMANDO. */
            _.Move("UPDATE SEGUROS.AVISOS_SALDOS     ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4368- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4376- PERFORM R5000_00_UPDATE_AVISOSAL_DB_UPDATE_1 */

            R5000_00_UPDATE_AVISOSAL_DB_UPDATE_1();

            /*" -4380- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -4381- DISPLAY 'R5000-00 - PROBLEMAS UPDATE  (AVISOSAL)   ' */
                _.Display($"R5000-00 - PROBLEMAS UPDATE  (AVISOSAL)   ");

                /*" -4381- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R5000-00-UPDATE-AVISOSAL-DB-UPDATE-1 */
        public void R5000_00_UPDATE_AVISOSAL_DB_UPDATE_1()
        {
            /*" -4376- EXEC SQL UPDATE SEGUROS.AVISOS_SALDOS SET SALDO_ATUAL = (SALDO_ATUAL - :RCAPCOMP-VAL-RCAP) WHERE BCO_AVISO = :RCAPCOMP-BCO-AVISO AND AGE_AVISO = :RCAPCOMP-AGE-AVISO AND NUM_AVISO_CREDITO = :RCAPCOMP-NUM-AVISO-CREDITO END-EXEC. */

            var r5000_00_UPDATE_AVISOSAL_DB_UPDATE_1_Update1 = new R5000_00_UPDATE_AVISOSAL_DB_UPDATE_1_Update1()
            {
                RCAPCOMP_VAL_RCAP = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_VAL_RCAP.ToString(),
                RCAPCOMP_NUM_AVISO_CREDITO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO.ToString(),
                RCAPCOMP_BCO_AVISO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO.ToString(),
                RCAPCOMP_AGE_AVISO = RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO.ToString(),
            };

            R5000_00_UPDATE_AVISOSAL_DB_UPDATE_1_Update1.Execute(r5000_00_UPDATE_AVISOSAL_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5000_99_SAIDA*/

        [StopWatch]
        /*" R6000-00-CALCULA-VL-ATUALIZADO-SECTION */
        private void R6000_00_CALCULA_VL_ATUALIZADO_SECTION()
        {
            /*" -4391- MOVE 'R6000-00-CALCULA-VL-ATUALIZADO' TO PARAGRAFO. */
            _.Move("R6000-00-CALCULA-VL-ATUALIZADO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4392- MOVE 'CALCULAR ATUALIZACAO DE VALOR ' TO COMANDO. */
            _.Move("CALCULAR ATUALIZACAO DE VALOR ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4394- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4397- INITIALIZE LK-VG011-E-TRACE LK-VG011-E-COD-USUARIO LK-VG011-E-NOM-PROGRAMA LK-VG011-E-TIPO-ACAO LK-VG011-E-COD-PRODUTO LK-VG011-E-DTA-INI-CALCULO LK-VG011-E-DTA-FIM-CALCULO LK-VG011-E-DTA-DECLINIO LK-VG011-E-VL-ORIGINAL LK-VG011-E-NUM-APOLICE LK-VG011-E-COD-SUBGRUPO LK-VG011-E-QTD-DIA-PGMNTO LK-VG011-S-COD-MOEDA LK-VG011-S-PC-INDICE LK-VG011-S-VL-JUROS LK-VG011-S-VL-MULTA LK-VG011-S-VL-CORRIGIDO LK-VG011-S-DTA-FIM-PGMNTO LK-VG011-IND-ERRO LK-VG011-MSG-ERRO LK-VG011-NOM-TABELA LK-VG011-SQLCODE LK-VG011-SQLERRMC */
            _.Initialize(
                SPVG011W.LK_VG011_E_TRACE
                , SPVG011W.LK_VG011_E_COD_USUARIO
                , SPVG011W.LK_VG011_E_NOM_PROGRAMA
                , SPVG011W.LK_VG011_E_TIPO_ACAO
                , SPVG011W.LK_VG011_E_COD_PRODUTO
                , SPVG011W.LK_VG011_E_DTA_INI_CALCULO
                , SPVG011W.LK_VG011_E_DTA_FIM_CALCULO
                , SPVG011W.LK_VG011_E_DTA_DECLINIO
                , SPVG011W.LK_VG011_E_VL_ORIGINAL
                , SPVG011W.LK_VG011_E_NUM_APOLICE
                , SPVG011W.LK_VG011_E_COD_SUBGRUPO
                , SPVG011W.LK_VG011_E_QTD_DIA_PGMNTO
                , SPVG011W.LK_VG011_S_COD_MOEDA
                , SPVG011W.LK_VG011_S_PC_INDICE
                , SPVG011W.LK_VG011_S_VL_JUROS
                , SPVG011W.LK_VG011_S_VL_MULTA
                , SPVG011W.LK_VG011_S_VL_CORRIGIDO
                , SPVG011W.LK_VG011_S_DTA_FIM_PGMNTO
                , SPVG011W.LK_VG011_IND_ERRO
                , SPVG011W.LK_VG011_MSG_ERRO
                , SPVG011W.LK_VG011_NOM_TABELA
                , SPVG011W.LK_VG011_SQLCODE
                , SPVG011W.LK_VG011_SQLERRMC
            );

            /*" -4398- MOVE 'S' TO LK-VG011-E-TRACE */
            _.Move("S", SPVG011W.LK_VG011_E_TRACE);

            /*" -4399- MOVE 'BATCH' TO LK-VG011-E-COD-USUARIO */
            _.Move("BATCH", SPVG011W.LK_VG011_E_COD_USUARIO);

            /*" -4400- MOVE 'VA0469B' TO LK-VG011-E-NOM-PROGRAMA */
            _.Move("VA0469B", SPVG011W.LK_VG011_E_NOM_PROGRAMA);

            /*" -4401- MOVE 1 TO LK-VG011-E-TIPO-ACAO */
            _.Move(1, SPVG011W.LK_VG011_E_TIPO_ACAO);

            /*" -4402- MOVE PROPOVA-COD-PRODUTO TO LK-VG011-E-COD-PRODUTO */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO, SPVG011W.LK_VG011_E_COD_PRODUTO);

            /*" -4403- MOVE DATA-INI TO LK-VG011-E-DTA-INI-CALCULO */
            _.Move(WORK_AREA.DATA_INI, SPVG011W.LK_VG011_E_DTA_INI_CALCULO);

            /*" -4404- MOVE DATA-FIM TO LK-VG011-E-DTA-FIM-CALCULO */
            _.Move(WORK_AREA.DATA_FIM, SPVG011W.LK_VG011_E_DTA_FIM_CALCULO);

            /*" -4405- MOVE DATA-INI-DEC TO LK-VG011-E-DTA-DECLINIO */
            _.Move(WORK_AREA.DATA_INI_DEC, SPVG011W.LK_VG011_E_DTA_DECLINIO);

            /*" -4406- MOVE COBHISVI-PRM-TOTAL TO LK-VG011-E-VL-ORIGINAL */
            _.Move(COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_PRM_TOTAL, SPVG011W.LK_VG011_E_VL_ORIGINAL);

            /*" -4407- MOVE ZEROS TO LK-VG011-E-NUM-APOLICE */
            _.Move(0, SPVG011W.LK_VG011_E_NUM_APOLICE);

            /*" -4409- MOVE ZEROS TO LK-VG011-E-COD-SUBGRUPO */
            _.Move(0, SPVG011W.LK_VG011_E_COD_SUBGRUPO);

            /*" -4410- MOVE 2 TO LK-VG011-E-QTD-DIA-PGMNTO */
            _.Move(2, SPVG011W.LK_VG011_E_QTD_DIA_PGMNTO);

            /*" -4411- MOVE 99 TO LK-VG011-IND-ERRO */
            _.Move(99, SPVG011W.LK_VG011_IND_ERRO);

            /*" -4413- DISPLAY 'R6000-00-CALCULA-ANTES-CALL' */
            _.Display($"R6000-00-CALCULA-ANTES-CALL");

            /*" -4415- CALL VG011-PROGRAMA USING LK-VG011-E-TRACE LK-VG011-E-COD-USUARIO LK-VG011-E-NOM-PROGRAMA LK-VG011-E-TIPO-ACAO LK-VG011-E-COD-PRODUTO LK-VG011-E-DTA-INI-CALCULO LK-VG011-E-DTA-FIM-CALCULO LK-VG011-E-DTA-DECLINIO LK-VG011-E-VL-ORIGINAL LK-VG011-E-NUM-APOLICE LK-VG011-E-COD-SUBGRUPO LK-VG011-E-QTD-DIA-PGMNTO LK-VG011-S-COD-MOEDA LK-VG011-S-PC-INDICE LK-VG011-S-VL-JUROS LK-VG011-S-VL-MULTA LK-VG011-S-VL-CORRIGIDO LK-VG011-S-DTA-FIM-PGMNTO LK-VG011-IND-ERRO LK-VG011-MSG-ERRO LK-VG011-NOM-TABELA LK-VG011-SQLCODE LK-VG011-SQLERRMC */
            _.Call(SPVG011V.VG011_PROGRAMA, SPVG011W);

            /*" -4416- DISPLAY 'R6000-00-CALCULA-DEPOIS-CALL' */
            _.Display($"R6000-00-CALCULA-DEPOIS-CALL");

            /*" -4418- MOVE RETURN-CODE TO W-RETURN-CODE */
            _.Move(RETURN_CODE, W_RETURN_CODE);

            /*" -4419- IF W-RETURN-CODE NOT EQUAL ZEROS */

            if (W_RETURN_CODE != 00)
            {

                /*" -4420- DISPLAY '*-------------------------------------------*' */
                _.Display($"*-------------------------------------------*");

                /*" -4421- DISPLAY '* R6000 - PROBLEMAS NO CALL DA SUBROTINA    *' */
                _.Display($"* R6000 - PROBLEMAS NO CALL DA SUBROTINA    *");

                /*" -4422- DISPLAY '*-------------------------------------------*' */
                _.Display($"*-------------------------------------------*");

                /*" -4423- DISPLAY '* COD-PRODUTO..: ' LK-VG011-E-COD-PRODUTO */
                _.Display($"* COD-PRODUTO..: {SPVG011W.LK_VG011_E_COD_PRODUTO}");

                /*" -4424- DISPLAY '* DTA-INI-CALC.: ' LK-VG011-E-DTA-INI-CALCULO */
                _.Display($"* DTA-INI-CALC.: {SPVG011W.LK_VG011_E_DTA_INI_CALCULO}");

                /*" -4425- DISPLAY '* DTA-FIM-CALC.: ' LK-VG011-E-DTA-FIM-CALCULO */
                _.Display($"* DTA-FIM-CALC.: {SPVG011W.LK_VG011_E_DTA_FIM_CALCULO}");

                /*" -4426- DISPLAY '* VL-ORIGINAL..: ' LK-VG011-E-VL-ORIGINAL */
                _.Display($"* VL-ORIGINAL..: {SPVG011W.LK_VG011_E_VL_ORIGINAL}");

                /*" -4427- DISPLAY '* IND-ERRO.....: ' LK-VG011-IND-ERRO */
                _.Display($"* IND-ERRO.....: {SPVG011W.LK_VG011_IND_ERRO}");

                /*" -4428- DISPLAY '* MSG-ERRO.....: ' LK-VG011-MSG-ERRO */
                _.Display($"* MSG-ERRO.....: {SPVG011W.LK_VG011_MSG_ERRO}");

                /*" -4429- DISPLAY '* NOM-TABELA...: ' LK-VG011-NOM-TABELA */
                _.Display($"* NOM-TABELA...: {SPVG011W.LK_VG011_NOM_TABELA}");

                /*" -4430- DISPLAY '* SQLCODE......: ' LK-VG011-SQLCODE */
                _.Display($"* SQLCODE......: {SPVG011W.LK_VG011_SQLCODE}");

                /*" -4431- DISPLAY '* SQLERRMC.....: ' LK-VG011-SQLERRMC */
                _.Display($"* SQLERRMC.....: {SPVG011W.LK_VG011_SQLERRMC}");

                /*" -4432- DISPLAY '* RETURN CODE..: ' W-RETURN-CODE */
                _.Display($"* RETURN CODE..: {W_RETURN_CODE}");

                /*" -4434- DISPLAY '*-------------------------------------------*' */
                _.Display($"*-------------------------------------------*");

                /*" -4435- MOVE W-RETURN-CODE TO SQLCODE */
                _.Move(W_RETURN_CODE, DB.SQLCODE);

                /*" -4436- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4438- END-IF */
            }


            /*" -4439- IF LK-VG011-IND-ERRO NOT EQUAL ZEROS */

            if (SPVG011W.LK_VG011_IND_ERRO != 00)
            {

                /*" -4440- DISPLAY '*-------------------------------------------*' */
                _.Display($"*-------------------------------------------*");

                /*" -4441- DISPLAY '* R6000 - PROBLEMAS CALL SUBROTINA SPBVG011 *' */
                _.Display($"* R6000 - PROBLEMAS CALL SUBROTINA SPBVG011 *");

                /*" -4442- DISPLAY '*-------------------------------------------*' */
                _.Display($"*-------------------------------------------*");

                /*" -4443- DISPLAY '* COD-PRODUTO..: ' LK-VG011-E-COD-PRODUTO */
                _.Display($"* COD-PRODUTO..: {SPVG011W.LK_VG011_E_COD_PRODUTO}");

                /*" -4444- DISPLAY '* DTA-INI-CALC.: ' LK-VG011-E-DTA-INI-CALCULO */
                _.Display($"* DTA-INI-CALC.: {SPVG011W.LK_VG011_E_DTA_INI_CALCULO}");

                /*" -4445- DISPLAY '* DTA-FIM-CALC.: ' LK-VG011-E-DTA-FIM-CALCULO */
                _.Display($"* DTA-FIM-CALC.: {SPVG011W.LK_VG011_E_DTA_FIM_CALCULO}");

                /*" -4446- DISPLAY '* VL-ORIGINAL..: ' LK-VG011-E-VL-ORIGINAL */
                _.Display($"* VL-ORIGINAL..: {SPVG011W.LK_VG011_E_VL_ORIGINAL}");

                /*" -4447- DISPLAY '* IND-ERRO.....: ' LK-VG011-IND-ERRO */
                _.Display($"* IND-ERRO.....: {SPVG011W.LK_VG011_IND_ERRO}");

                /*" -4448- DISPLAY '* MSG-ERRO.....: ' LK-VG011-MSG-ERRO */
                _.Display($"* MSG-ERRO.....: {SPVG011W.LK_VG011_MSG_ERRO}");

                /*" -4449- DISPLAY '* NOM-TABELA...: ' LK-VG011-NOM-TABELA */
                _.Display($"* NOM-TABELA...: {SPVG011W.LK_VG011_NOM_TABELA}");

                /*" -4450- DISPLAY '* SQLCODE......: ' LK-VG011-SQLCODE */
                _.Display($"* SQLCODE......: {SPVG011W.LK_VG011_SQLCODE}");

                /*" -4451- DISPLAY '* SQLERRMC.....: ' LK-VG011-SQLERRMC */
                _.Display($"* SQLERRMC.....: {SPVG011W.LK_VG011_SQLERRMC}");

                /*" -4453- DISPLAY '*-------------------------------------------*' */
                _.Display($"*-------------------------------------------*");

                /*" -4454- MOVE LK-VG011-SQLCODE TO SQLCODE */
                _.Move(SPVG011W.LK_VG011_SQLCODE, DB.SQLCODE);

                /*" -4455- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4456- END-IF */
            }


            /*" -4456- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6000_99_SAIDA*/

        [StopWatch]
        /*" R9800-00-ENCERRA-SEM-SOLIC-SECTION */
        private void R9800_00_ENCERRA_SEM_SOLIC_SECTION()
        {
            /*" -4470- MOVE 'R9800-00-ENCERRA-SEM-SOLIC' TO PARAGRAFO. */
            _.Move("R9800-00-ENCERRA-SEM-SOLIC", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4471- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -4472- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -4473- DISPLAY '*   VA0469B - PRODUTOS VIDA EM GRUPO       *' */
            _.Display($"*   VA0469B - PRODUTOS VIDA EM GRUPO       *");

            /*" -4474- DISPLAY '*   -------   ----------------------       *' */
            _.Display($"*   -------   ----------------------       *");

            /*" -4475- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -4476- DISPLAY '*             NENHUMA DEVOLUCAO ENCONTRADA *' */
            _.Display($"*             NENHUMA DEVOLUCAO ENCONTRADA *");

            /*" -4477- DISPLAY '*             NO DIA.                      *' */
            _.Display($"*             NO DIA.                      *");

            /*" -4478- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -4478- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9800_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -4491- DISPLAY 'CERTIFICADO        ' RELATORI-NUM-CERTIFICADO */
            _.Display($"CERTIFICADO        {RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO}");

            /*" -4493- DISPLAY 'PARCELA            ' RELATORI-NUM-PARCELA */
            _.Display($"PARCELA            {RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA}");

            /*" -4495- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -4497- MOVE SQLERRMC TO WSQLERRMC. */
            _.Move(DB.SQLERRMC, WABEND.WSQLERRO.WSQLERRMC);

            /*" -4499- DISPLAY WABEND */
            _.Display(WABEND);

            /*" -4499- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -4501- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -4505- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -4505- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}