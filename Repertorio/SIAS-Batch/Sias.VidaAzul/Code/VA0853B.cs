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
using Sias.VidaAzul.DB2.VA0853B;

namespace Code
{
    public class VA0853B
    {
        public bool IsCall { get; set; }

        public VA0853B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ...............:  VIDAZUL EMPRESA GLOBAL/MULTIPREM   *      */
        /*"      *   PROGRAMA ..............:  VA0853B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ..............:  FONSECA                            *      */
        /*"      *   PROGRAMADOR ...........:  FONSECA                            *      */
        /*"      *   DATA CODIFICACAO ......:  06/10/1997                         *      */
        /*"      ******************************************************************      */
        /*"V.61  *  VERSAO 61  - DEMANDA 455.132                                  *      */
        /*"      *             - FAZ GRAVACAO DE CAMPOS NUM_CERTIFICADO E COD_IDLG*      */
        /*"      *               NA MOVTO_DEBITOCC_CEF                            *      */
        /*"      *                                                                *      */
        /*"      *  EM 17/02/2023 - ELIERMES OLIVEIRA                             *      */
        /*"      *                                        PROCURE POR V.61        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 60 - DEMANDA 327863                                   *      */
        /*"      *               ACERTO NO ANTECIPADO QUE NA RENOVACAO GEROU      *      */
        /*"      *               PARCELA ANUAL, O CORRETO ERA MENSAL              *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/03/2022 - THIAGO BLAIER                                *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.60    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 59 - DEMANDA 278.339                                  *      */
        /*"      *               ATENDE INCIDENTE PRODUCAO - DEMANDA 278187.      *      */
        /*"      *                                                                *      */
        /*"      *               SUSPEITA DE LOOPING.                             *      */
        /*"      *               ATIVAR DISPLAYS PARA MONITORAMENTO.              *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/02/2021 - BRICE HO                                     *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.59    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 58 - DEMANDA 220.882/256.184/250.426                  *      */
        /*"      *               VOC_ADEQUACAO DA NOVA REGUA DE COBRAN�A PARA     *      */
        /*"      *               DEBITO EM CONTA.                                 *      */
        /*"      *                                                                *      */
        /*"      *               PASSA GERAR PROXIMA PARCELA COM 8 DIAS DE        *      */
        /*"      *               ANTECEDENCIA.                                    *      */
        /*"      *                                                                *      */
        /*"      *   EM 12/12/2019 - TERCIO CARVALHO                              *      */
        /*"      *   EM 10/12/2020 - FRANK CARVALHO (AJUSTES E TESTES INTEGRADOS) *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.58    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 57 - INCIDENTE 268.918                                *      */
        /*"      *               CORRIGIR BUSCA DE PARCELA AGUARDANDO O SAP.      *      */
        /*"      *               ERRO -811 PARAGRAFO R1015-00-VER-RETORNO-SICOV   *      */
        /*"      *                                                                *      */
        /*"      *   EM 07/12/2020 - FRANK CARVALHO                               *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.57    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 56 - INCIDENTE 231.852                                *      */
        /*"      *               CORRIGIR COBRANCA DE PARCELAS ATRASADAS DA OPCAO *      */
        /*"      *               DE PAGAMENTO CARTAO DE CREDITO.                  *      */
        /*"      *               ERRO -803 PARAGRAFO R1320-INSERT-MOVTO-DEBITOCC  *      */
        /*"      *                                                                *      */
        /*"      *   EM 29/01/2020 - FRANK CARVALHO                               *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.56    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 55 - INCIDENTE 224.866                                *      */
        /*"      *               PROGRAMA ESTA ATUALIZANDO A DTPROXVEN COM DATA   *      */
        /*"      *               '9999-12-31', COM ISSO REGISTROS COM ERRO NA TAB.*      */
        /*"      *               HIS_COBER_PROPOST NAO ESTAO SAINDO NO RELATORIO. *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/11/2019 - FRANK CARVALHO                               *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.55    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 54 - ABEND 178848/221858                              *      */
        /*"      *               ERRO VARIAVEL INDICADORA DE NULO.                *      */
        /*"      *                                                                       */
        /*"      *   EM 23/10/2019 - CLAUDETE RADEL                               *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.54    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 53 - CIELO - ADEQUA�AO AO CAMPO NUM_CARTAO_CREDITO    *      */
        /*"      *               O NUMERO DO CARTAO DE CREDITO FOI ALTERADO NA    *      */
        /*"      *               TABELA OPCAO_PAG_VIDAZUL PARA CHAR(16), POIS O   *      */
        /*"      *               NUMERO QUE O LEGADO RECEBE ESTA MASCARADO COM "*"*      */
        /*"      *               MOVE ZEROS PARA HISTCONTAVA                      *      */
        /*"      *               MOVE NULOS PARA MOVTO_DEBITOCC_CEF               *      */
        /*"      *                                                                       */
        /*"      *   EM 19/09/2019 - DANIEL MEDINA GOMIDE - MILLENIUM             *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.53    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 52 - DEMANDA 190818                                   *      */
        /*"      *             - ALTERAR A QUANTIDADE DE DIAS PARA CANCELAMENTO DE*      */
        /*"      *               SEGUROS PARA 1 ANO + 10 DIAS UTEIS PARA PRODUTOS *      */
        /*"      *               VIDA EMPRESARIAL, VIDA DA GENTE, VIDA MULHER     *      */
        /*"      *               VIDA MULTIPREMIADO, VIDA AZUL EXECUTIVO          *      */
        /*"      *   EM 02/07/2019 - KINKAS                   PROCURE POR V.52    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 51 - PROJ. CARTAO CREDITO CIELO                       *      */
        /*"      *             - ALTERAR PROGRAMA PARA A COBRANCA VIA CARTAO      *      */
        /*"      *             - UMA VEZ A PARCELA ENVIADA AO SAP, ELA PRECISA DA *      */
        /*"      *               CONFIRMACAO DA CAPTURA NA CIELO, ESTA E ENVIADA  *      */
        /*"      *               VIA ARQ-H EM D+2 NO MAXIMO. CASO A ULTIMA COBRAN-*      */
        /*"      *               NAO RETORNE A CC(CONFIRMACAO CAPTURA), A COBRAN- *      */
        /*"      *               CA DO CLIENTE E INTERROMPIDA.                    *      */
        /*"      *             - CASO RETORNE ALGUM ERRO NA CAPTURA, O CLIENTE E  *      */
        /*"      *               TRATADO COMO INADIMPLENTE E APOS TRES TENTATIVAS *      */
        /*"      *               DE COBRANCA SEM SUCESSO O SEGURO SERA CANCELADO. *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/06/2019 - FRANK CARVALHO                               *      */
        /*"      *                                            PROCURE POR V.51    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 50 - HIST 192.744                                     *      */
        /*"      *             - PREPARAR PROGRAMA PARA PROCESSAMENTO DA JV1      *      */
        /*"      *                                                                *      */
        /*"      *   EM 09/03/2019 - HUSNI ALI HUSNI                              *      */
        /*"      *                                            PROCURE POR JV101   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 49 - HISTORIA 163489                                  *      */
        /*"      *             - ALTERAR A QUANTIDADE DE DIAS PARA CANCELAMENTO DE*      */
        /*"      *               SEGUROS DE 6 DIAS PARA 15 DIAS UTEIS.            *      */
        /*"      *                                                                *      */
        /*"      *   EM 19/07/2018 - RILDO SICO                                   *      */
        /*"      *                                            PROCURE POR V.49    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 48 - 22.024                                           *      */
        /*"      *             - NAO ALTERAR A SITUACAO PARA INTEGRADO QUANDO SE- *      */
        /*"      *               GURADO POSSUIR PARCELAS INADIMPLENTES.           *      */
        /*"      *                                                                *      */
        /*"      *   EM 29/05/2018 - FRANK CARVALHO                               *      */
        /*"      *                                            PROCURE POR V.48    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 47 - 21.520                                           *      */
        /*"      *             - ALTERA VALIDACAO DE PARCELAS COM RETORNO SICOV.  *      */
        /*"      *                                                                *      */
        /*"      *   EM 11/04/2018 - FRANK CARVALHO                               *      */
        /*"      *                                            PROCURE POR V.47    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 46 - HISTORIA 11.173                                  *      */
        /*"      *             - PASSA A GERAR PARCELAS MESMO QUE POSSUA PARCELAS *      */
        /*"      *               PENDENTES DE PAGAMENTO PARA OPCAO-PAG DEBITO EM  *      */
        /*"      *               CONTA E CARTAO DE CREDITO.                       *      */
        /*"      *             - CASO POSSUA PARCELAS EM ABERTO, CHAMA SUBROTINA  *      */
        /*"      *               GE0853S PARA GERACAO DAS PARCELAS NAO PAGAS      *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/02/2018 - ELIERMES                                     *      */
        /*"      *                                            PROCURE POR V.46    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 45 - CADMUS 157.262                                   *      */
        /*"      *             - INSERIR MARCADOR DE IMPRESSAO DE BOLETO NA COLUNA*      */
        /*"      *               COD-DEVOLUCAO=7966 DA TABELA COBER_HIST_VIDAZUL  *      */
        /*"      *               QUE SER� PEGA PELO VA0267B P/ GERAR BOLETO SIGCB *      */
        /*"      *                                                                *      */
        /*"      *   EM 11/01/2018 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                            PROCURE POR V.44    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 44 - CADMUS 157.262                                   *      */
        /*"      *             - INSERIR MARCADOR DE IMPRESSAO DE BOLETO NA COLUNA*      */
        /*"      *               COD-DEVOLUCAO=7966 DA TABELA COBER_HIST_VIDAZUL  *      */
        /*"      *               QUE SER� PEGA PELO VA0267B P/ GERAR BOLETO SIGCB *      */
        /*"      *                                                                *      */
        /*"      *   EM 11/01/2018 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                            PROCURE POR V.44    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 43   - CADMUS 155.688                                 *      */
        /*"      *               - RETIRAR RAMO_EMISSOR 77 DAS GERACOES DE DEMAIS *      */
        /*"      *                 PARCELAS.                                      *      */
        /*"      *   EM 21/11/2017 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                       PROCURE POR V.43         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 42   - CADMUS 140.778                                 *      */
        /*"      *               - ANTECIPAR EM 03 DIAS A GERACAO DA PARCELA PARA *      */
        /*"      *                 SOLICITAR NN AO SAP POR MEIO DE ARQ-A (EM8100B)*      */
        /*"      *   EM 12/12/2016 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                       PROCURE POR V.42         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 41   - CADMUS 140.778                                 *      */
        /*"      *               - ANTECIPAR EM 02 DIAS A GERACAO DA PARCELA PARA *      */
        /*"      *                 SOLICITAR NN AO SAP POR MEIO DE ARQ-A (EM8100B)*      */
        /*"      *   EM 12/12/2016 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                       PROCURE POR V.41         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 40 - ABEND 135553                                     *      */
        /*"      *             - CORRECAO DO ABEND (SQLCODE = -803) OCORRIDO NA   *      */
        /*"      *               TABELA SEGUROS.MOVTO_DEBITOCC_CEF                *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/04/2016 - THIAGO BLAIER                                *      */
        /*"      *                                              PROCURE POR V.40  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 39 - CAD 114.834                                      *      */
        /*"      *             - AP�S GERACAO DE PARCELA COM PAGAMENTO EM CARTAO  *      */
        /*"      *               CREDITO, VERIFICA SE AS DUAS PARCELAS ANTERIORES *      */
        /*"      *               EST�O EM ATRASO DE PAGAMENTO, CASO POSITIVO, PRE-*      */
        /*"      *               PARA NOVA COBRANCA PARA O CB0082B, ENVIANDO-AS   *      */
        /*"      *               PARA COBRANCA NO SAP JUNTAMENTE COM A PARCELA    *      */
        /*"      *               GERADA.                                          *      */
        /*"      *                                                                *      */
        /*"      *   EM 16/03/2016 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                              PROCURE POR V.39  *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 38  -  NSGD - CADMUS 103659.                          *      */
        /*"      *              -  NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/06/2015 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                              PROCURE POR V.38  *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 37                                                    *      */
        /*"      *             - CAD 113.766                                      *      */
        /*"      *             - PERMITIR QUE O PROGRAMA GERE PARCELAS PARA A     *      */
        /*"      *               OPCAO DE PAGAMENTO CARTAO DE CREDITO, MESMO QUE  *      */
        /*"      *               EXISTA PARCELA PENDENTE DE RETORNO DO SAP NA     *      */
        /*"      *               TABELA HIST_LANC_CTA.                            *      */
        /*"      *             - NOVA REGRA SOLICITADA PARA OPCAO DE PAGAMENTO DE *      */
        /*"      *               CARTAO DE CREDITO DEVIDO QUE A BAIXA EFETIVA DAS *      */
        /*"      *               PARCELAS NA BASE, ACONTECE SOMENTE NA DATA DE    *      */
        /*"      *               CREDITO, QUE PODE ACONTECER 30, 40 DIAS APOS     *      */
        /*"      *               GERAR A PARCELA, IMPOSSIBILITANDO A COBRANCA DO  *      */
        /*"      *               PROXIMO MES.                                     *      */
        /*"      *                                                                *      */
        /*"      *   EM 29/04/2015 - FRANK CARVALHO (INDRA COMPANY)               *      */
        /*"      *                                              PROCURE POR V.37  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 36                                                    *      */
        /*"      *             - ABE 112.856                                      *      */
        /*"      *             - PERMITIR O SQLCODE +100 QUANDO A FORMA DE PAGA-  *      */
        /*"      *               MENTO FOR BOLETO E NAO EXISTIR A PARCELA NA TABE-*      */
        /*"      *               LA HIST_LANC_CTA.                                *      */
        /*"      *                                                                *      */
        /*"      *   EM 24/03/2015 - FRANK CARVALHO (INDRA COMPANY)               *      */
        /*"      *                                              PROCURE POR V.36  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 35                                                    *      */
        /*"      *             - CAD  95.290                                      *      */
        /*"      *             - INCREMENTAR NOVOS CAMPOS NO RELATORIO EMITIDO    *      */
        /*"      *               PELO PROGRAMA PARA QUE O OPERACIONAL CONSIGA     *      */
        /*"      *               EXTRAIR O MAXIMO DE INFORMACOES E ATUE NOS       *      */
        /*"      *               PROBLEMAS APONTADOS NO RELATORIO.                *      */
        /*"      *                                                                *      */
        /*"      *   EM 19/11/2014 - FRANK CARVALHO (INDRA COMPANY)               *      */
        /*"      *                                              PROCURE POR V.35  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 34                                                    *      */
        /*"      *             - CAD  94.968                                      *      */
        /*"      *             - RETIRAR SOMATORIO DE VLCUSTCAP AO PREMIO-VG      *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/11/2014 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                              PROCURE POR V.34  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 33 - CAD 101.606                                      *      */
        /*"      *          CORRECAO DO ABEND (SQLCODE = -180) OCORRIDO DURANTE   *      */
        /*"      *          CALCULO DE DTPROXVEN.                                 *      */
        /*"      *                                                                *      */
        /*"      *   EM 12/08/2014 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.33         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO : 32 - CAD 86.679                                       *      */
        /*"      * MOTIVO : JUDICIAL-PAGAMENTO CERTIFICADO EM JUIZO - GERAR PARCE-*      */
        /*"      *          LA CANCELADA PARA CERTIFICADO 84821639561.            *      */
        /*"      * TABELAS: V0PROPOSTAVA                                          *      */
        /*"      *          V0PARCELVA                                            *      */
        /*"      *          V0HISTCOBVA                                           *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/09/2013 - CARLA VILELA                                 *      */
        /*"      *                                       PROCURE POR V.32         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 31 - CAD 83.131                                       *      */
        /*"      *          CORRECAO DO ABEND (SQLCODE = -803) OCORRIDO NA TABELA *      */
        /*"      *          SEGUROS.V0HISTCOBVA.                                  *      */
        /*"      *                                                                *      */
        /*"      *   EM 31/05/2013 - MARCO PAIVA     (FAST COMPUTER)              *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.31         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 30 - CAD 81.107                                       *      */
        /*"      *                       AJUSTES NO RELATORIO GERADO. INCLUSAO    *      */
        /*"      *                       DO VALOR DA PARCELA.                     *      */
        /*"      *                                                                *      */
        /*"      *   EM 12/04/2013 - LUIZ MARQUES    (FAST COMPUTER)              *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.30         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 29 - CAD 80.381                                       *      */
        /*"      *                       ABEND R4500-00 ACESSO A                  *      */
        /*"      *                       COBER_HIST_VIDAZUL                       *      */
        /*"      *                                                                *      */
        /*"      *   EM 15/03/2013 - TERCIO CARVALHO (FAST COMPUTER)              *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.29         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 28 - CAD 75.954                                       *      */
        /*"      *                       GERAR ARQUIVO DE PROPOSTAS DESPREZADAS   *      */
        /*"      *                       PELO PROGRAMA.                           *      */
        /*"      *                                                                *      */
        /*"      *   EM 28/02/2013 - GABRIEL LOURENCO(FAST COMPUTER)              *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.28         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 27 - CAD 67.348                                       *      */
        /*"      *                       AJUSTADO PARA NAO INSERIR PARCELA        *      */
        /*"      *                       COM CODIGO DE OPERACAO 113 PARA          *      */
        /*"      *                       EVITAR ENVIO ENDEVID DE CERTICADO        *      */
        /*"      *                                                                *      */
        /*"      *   EM 28/03/2012 - ROGERIO PEREIRA (FAST COMPUTER)              *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.27         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 26 - CAD 62.923                                       *      */
        /*"      *               - AJUSTAR O PROGRAMA PARA TRATAR                 *      */
        /*"      *              INCONSISTENCIA NA GERACAO DE PARCELAS             *      */
        /*"      *                                                                *      */
        /*"      *   EM 13/03/2012 - CLAUDIO FREITAS (FAST COMPUTER)              *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.26         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 25 - CAD 48.792                                       *      */
        /*"      *               - AJUSTAR O PROGRAMA PARA GRAVAR NA TABELA       *      */
        /*"      *                 SEGUROS.HIST_LANC_CTA O CODIGO DO BANCO        *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/04/2011 - MARCO PAIVA (FAST COMPUTER)                  *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.25         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 24 - CAD 56.304                                       *      */
        /*"      *               - TRATAR SQLCODE = 100 NO ACESSO A TABELA        *      */
        /*"      *                 SEGUROS.V0OPCAOPAGVA                           *      */
        /*"      *                                                                *      */
        /*"      *   EM 06/05/2011 - MARCO PAIVA (FAST COMPUTER)                  *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.24         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 23 - CAD 55.709                                       *      */
        /*"      *               - TRATAR -811 NO ACESSO A TABELA                 *      */
        /*"      *                 SEGUROS.V0HISTCOBVA                            *      */
        /*"      *                                                                *      */
        /*"      *   EM 25/04/2011 - MARCO PAIVA (FAST COMPUTER)                  *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.23         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 22 - CAD 55.632                                       *      */
        /*"      *               - TRATAR -811 NO ACESSO A TABELA                 *      */
        /*"      *                 SEGUROS.V0HISTCOBVA                            *      */
        /*"      *                                                                *      */
        /*"      *   EM 19/04/2011 - MARCO PAIVA (FAST COMPUTER)                  *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.22         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 21 - CAD 48.877                                       *      */
        /*"      *               - TRATAR -811 NO ACESSO A TABELA                 *      */
        /*"      *                 SEGUROS.V0HISTCONTAVA.                         *      */
        /*"      *                                                                *      */
        /*"      *   EM 13/10/2010 - TERCIO FREITAS (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.21         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO 020         1-  CORRECAO DE GERACAO DE PARCELA IN- *      */
        /*"      *                             DEVIDA.                            *      */
        /*"      *                                                                *      */
        /*"      *   02/08/2010               .CADMUS 45.549                      *      */
        /*"      *   --> MARCO  (FAST COMPUTER)                                   *      */
        /*"      *                                          PROCURAR  POR (V.20)  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO 019         1-  CORRECAO DE ABEND, TRATAMENTO  DE  *      */
        /*"      *                             CODIGO DE RETORNO SQLCODE -803.    *      */
        /*"      *                                                                *      */
        /*"      *   08/03/2010               .CADMUS 38.577                      *      */
        /*"      *   --> MARCOS (FAST COMPUTER)                                   *      */
        /*"      *                                          PROCURAR  POR (V.19)  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   ALTERACAO..............:  ABEND NA GERACAO DE PARCELAS DO    *      */
        /*"      *                             SEGURADO. ONDE AGORA PASSA A NAO   *      */
        /*"      *                             MAIS ABENDAR.                      *      */
        /*"      *                                                                *      */
        /*"      *   DESENVOLVEDOR..........:  LEANDRO CORTES ( FAST COMPUTER )   *      */
        /*"      *                                                                *      */
        /*"      *   DATA MODIFICACAO.......:  07/04/2009                         *      */
        /*"      *                                                                *      */
        /*"      *   CADMUS  22.777                         PROCURAR  POR V.18    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   ALTERACAO..............:  ALTERACAO DA DATA DE GERACAO DAS   *      */
        /*"      *                             PARCELAS EM CARTAO DE CREDITO,     *      */
        /*"      *                             E PASSA A CONTEMPLAR UM PERIODO    *      */
        /*"      *                             MAIOR DE TEMPO ENTRE AS PARCELAS.  *      */
        /*"      *                                                                *      */
        /*"      *   DESENVOLVEDOR..........:  FAST COMPUTER                      *      */
        /*"      *                                                                *      */
        /*"      *   DATA MODIFICACAO.......:  16/03/2009                         *      */
        /*"      *                                                                *      */
        /*"      *   .CADMUS  21.858                        PROCURAR  POR V.17    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO 016         1-  CORRECAO DE ABEND, TRATAMENTO  DE  *      */
        /*"      *                             CODIGO DE RETORNO SQLCODE -811.    *      */
        /*"      *                                                                *      */
        /*"      *   27/02/2009               .CADMUS 21.378                      *      */
        /*"      *   --> FAST                                                     *      */
        /*"      *                                          PROCURAR  POR (V.16)  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO 015         1-  CORRECAO DE ABEND, TRATAMENTO  DE  *      */
        /*"      *                             CODIGO DE RETORNO SQLCODE -811.    *      */
        /*"      *   26/02/2009                                                   *      */
        /*"      *   --> FAST                                                     *      */
        /*"      *                                          PROCURAR  POR (V.15)  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO 014         1-  FILTRA PRODUTOS PU.                *      */
        /*"      *   24/09/2008                                                   *      */
        /*"      *   --> FAST                                                     *      */
        /*"      *                                          PROCURAR  POR (V.14)  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO 013         1-  FILTRA EMPRESA GLOBAL.             *      */
        /*"      *   04/09/2006                                                   *      */
        /*"      *   --> FAST                                                     *      */
        /*"      *                                          PROCURAR  POR (V.13)  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO 012         1-  CORRECAO DO ABEND, TIRAR A CONSIDE *      */
        /*"      *   08/08/2006                RACAO DO VALOR DO ATRIBUTO V0HICB- *      */
        /*"      *   --> MARCO ANTONIO         OCORHIST FEITO PELA V.11 E SELECIO-*      */
        /*"      *                             NAR APENAS 01 REGISTRO.            *      */
        /*"      *                                          PROCURAR  POR (V.12)  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO 011                                                *      */
        /*"      *   03/08/2006            1 - PASSA A SELECIONAR REGISTRO   NA   *      */
        /*"      *                             SEGUROS.V0COBERPROPVA LEVANDO EM   *      */
        /*"      *                             CONSIDERACAO O VALOR DO ATRIBUTO   *      */
        /*"      *                             V0HICB-OCORHIST.                   *      */
        /*"      *                                         LUCIA VIEIRA   (V.11)  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO 010                                                *      */
        /*"      *   10/11/2005            1 - DESPREZA OS REGISTROS DAS APOLICES *      */
        /*"      *                             ESPECIFICA ONDE O CAMPO ORIG_PRODU *      */
        /*"      *                             FOR 'ESPE1' OU 'ESPE2' OR 'ESPE3'  *      */
        /*"      *                                         TERCIO CARVALHO(TC1011)*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO 009                                                *      */
        /*"      *   09/09/2005            1 - INCLUSAO DO TIPO DE COBRANCA       *      */
        /*"      *                             CARTAO DE CREDITO                  *      */
        /*"      *                                        TERCIO          (TL0905)*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO 008                                                *      */
        /*"      *   11/08/2003            1 - DESPREZA OS REGISTROS DAS APOLICES *      */
        /*"      *                             DO EXECUTIVO A PEDIDO DO SR CESAR  *      */
        /*"      *                             E DA SRA SANY (DIMAR)              *      */
        /*"      *                                         FRED           (FF0803)*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO 007                                                *      */
        /*"      *   25/02/2002            1 - DESPREZA OS REGISTROS DAS APOLICES *      */
        /*"      *                             ESPECIFICA E EMPRESARIAL, ONDE, O  *      */
        /*"      *                             CAMPO ORIG_PRODU FOR 'EMPRE' OU    *      */
        /*"      *                             'ESPEC'                            *      */
        /*"      *                                         MESSIAS        (MM0202)*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO 006                                                *      */
        /*"      *   31/10/2000            1 - O PROGRAMA NAO GERA MAIS PARCELAS  *      */
        /*"      *                             DE CAPITALIZACAO PARA A ICATU DOS  *      */
        /*"      *                             TITULOS QUE FORAM MIGRADOS PARA A  *      */
        /*"      *                             CAIXA CAPITALIZACAO.               *      */
        /*"      *                                         FRED/MESSIAS   (MM1000)*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO 005                                                *      */
        /*"      *   03/10/2000            1 - O PROGRAMA PASSA A NAO MAIS        *      */
        /*"      *                             GERAR PARCELAS SEM ANTES VERIFIACAR*      */
        /*"      *                             SE HA AJUSTE DE IGPM PARA A MESMA  *      */
        /*"      *                                               TERCIO   (TL0010)*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO 004                                                *      */
        /*"      *   25/07/2000            1 - CORRIGIDO O ACESSO A COBERPROPVA   *      */
        /*"      *                             PARA RECUPERACAO DOS PREMIOS A SER *      */
        /*"      *                             COBRADOS NA PARCELA.               *      */
        /*"      *                             O PROGRAMA VINHA SOMANDO UM FIXO   *      */
        /*"      *                             NA DATA AUXLIAR QUE RECUPERAVA OS  *      */
        /*"      *                             DADOS.                             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO 003                                                *      */
        /*"      *   14/03/2000            1 - PASSA A COMITAR REGISTRO A REGISTRO*      */
        /*"      *                         2 - EVITA SELECIONAR SEGURADOS INADIM- *      */
        /*"      *                             PLENTES QUE NAO FORAM PEGOS PELO   *      */
        /*"      *                             PROGRAMA DE COBRANCA EM ATRASO.    *      */
        /*"      *                                               MESSIAS  (MM1403)*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO 002                                                *      */
        /*"      *  ALTERACAO A SER LIBERADA NO FUTURO >>> A T E N C A O <<<<     *      */
        /*"      *   23/09/1999                PARA OS PRODUTOS QUE OFERECEM CAPI-*      */
        /*"      *                             TALIZACAO, SERA GERADA CONCOMITAN- *      */
        /*"      *                             TEMENTE AA PARCELA DE COBRANCA, A  *      */
        /*"      *                             PARCELA DE CAPITALIZACAO.          *      */
        /*"      *                                               MESSIAS  (MM2309)*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO 001                                                *      */
        /*"      *   24/06/1999                TERCIO                             *      */
        /*"      *                             PASSA NAO MAIS TRATAR PRODUTO.     *      */
        /*"      *                             PROCURE TL9906                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * SISTEMAS                            V1SISTEMA         INPUT    *      */
        /*"      * PROPOSTAS VA                        CPROPVA      INPUT    *           */
        /*"      * COBERTURAS PROPOSTA VA              V0COBERPROPVA     INPUT    *      */
        /*"      * PARCELAS VA                         V0PARCELVA        I-O      *      */
        /*"      * HISTORICO DEBITO CONTA VA           V0HISTCONTAVA     OUTPUT   *      */
        /*"      * HISTORICO COBRANCA VA               V0HISTCOBVA       OUTPUT   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"1     ******************************************************************      */
        #endregion


        #region VARIABLES

        public FileBasis _ARQSAIDA { get; set; } = new FileBasis(new PIC("X", "280", "X(280)"));

        public FileBasis ARQSAIDA
        {
            get
            {
                _.Move(REG_SAIDA, _ARQSAIDA); VarBasis.RedefinePassValue(REG_SAIDA, _ARQSAIDA, REG_SAIDA); return _ARQSAIDA;
            }
        }
        /*"01  REG-SAIDA                 PIC X(0280).*/
        public StringBasis REG_SAIDA { get; set; } = new StringBasis(new PIC("X", "280", "X(0280)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis I01 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"77         WSHOST-DIA-UTIL     PIC X(010)       VALUE SPACES.*/
        public StringBasis WSHOST_DIA_UTIL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77         VIND-DTMOVTO        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_DTMOVTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-ESTR-COBR      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_ESTR_COBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-ORIG-PRODU     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_ORIG_PRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-TEM-SAF        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_TEM_SAF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-TEM-IGPM       PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_TEM_IGPM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-TEM-CDG        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_TEM_CDG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DTENV          PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_DTENV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DTRET          PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_DTRET { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-CODRET         PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_CODRET { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-NREQ           PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_NREQ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-SEQUEN         PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_SEQUEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-NLOTE          PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_NLOTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DTCRED         PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_DTCRED { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-STATUS         PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_STATUS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-VLCRED         PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_VLCRED { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-CCRE           PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_CCRE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-IDLG           PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_IDLG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0MOVF-COUNT        PIC S9(009)    COMP.*/
        public IntBasis V0MOVF_COUNT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         WHOST-VLPREMIO-REL  PIC S9(013)V99 COMP-3 VALUE +0.*/
        public DoubleBasis WHOST_VLPREMIO_REL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-VLPREMIO      PIC S9(013)V99 COMP-3 VALUE +0.*/
        public DoubleBasis WHOST_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-PRMVG         PIC S9(013)V99 COMP-3 VALUE +0.*/
        public DoubleBasis WHOST_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-PRMAP         PIC S9(013)V99 COMP-3 VALUE +0.*/
        public DoubleBasis WHOST_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-NRPARCEL      PIC S9(004)    COMP   VALUE +0.*/
        public IntBasis WHOST_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-PARCELCAP     PIC S9(004)    COMP   VALUE +0.*/
        public IntBasis WHOST_PARCELCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         DESCON-PERC         PIC S9(003)V9999 COMP-3.*/
        public DoubleBasis DESCON_PERC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9999"), 4);
        /*"77         DESCON-PRMVG        PIC S9(013)V99 COMP-3 VALUE +0.*/
        public DoubleBasis DESCON_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         DESCON-PRMAP        PIC S9(013)V99 COMP-3 VALUE +0.*/
        public DoubleBasis DESCON_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        WS-NOME-CURSOR       PIC  X(008)    VALUE SPACES.*/
        public StringBasis WS_NOME_CURSOR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"77        WFIM-CGERARAT        PIC  X(001)    VALUE 'N'.*/
        public StringBasis WFIM_CGERARAT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"77        WS-NUM-PARCELA-ATZ   PIC S9(004) COMP VALUE +0.*/
        public IntBasis WS_NUM_PARCELA_ATZ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        WS-QTD-SIT-01        PIC  9(006)    VALUE  ZEROS.*/
        public IntBasis WS_QTD_SIT_01 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"77        WS-QTD-SIT-02        PIC  9(006)    VALUE  ZEROS.*/
        public IntBasis WS_QTD_SIT_02 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"77        WS-QTD-SIT-03        PIC  9(006)    VALUE  ZEROS.*/
        public IntBasis WS_QTD_SIT_03 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"77        WS-QTD-SIT-04        PIC  9(006)    VALUE  ZEROS.*/
        public IntBasis WS_QTD_SIT_04 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"77        WS-QTD-SIT-05        PIC  9(006)    VALUE  ZEROS.*/
        public IntBasis WS_QTD_SIT_05 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"77        WS-QTD-SIT-06        PIC  9(006)    VALUE  ZEROS.*/
        public IntBasis WS_QTD_SIT_06 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"77        WS-QTD-SIT-07        PIC  9(006)    VALUE  ZEROS.*/
        public IntBasis WS_QTD_SIT_07 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"77        WS-QTD-SIT-08        PIC  9(006)    VALUE  ZEROS.*/
        public IntBasis WS_QTD_SIT_08 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"77        WS-QTD-SIT-09        PIC  9(006)    VALUE  ZEROS.*/
        public IntBasis WS_QTD_SIT_09 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"77        WS-QTD-SIT-10        PIC  9(006)    VALUE  ZEROS.*/
        public IntBasis WS_QTD_SIT_10 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"77        WS-QTD-SIT-11        PIC  9(006)    VALUE  ZEROS.*/
        public IntBasis WS_QTD_SIT_11 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"77        WS-QTD-SIT-12        PIC  9(006)    VALUE  ZEROS.*/
        public IntBasis WS_QTD_SIT_12 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"77        WS-NUM-ERRO          PIC  9(003)    VALUE  ZEROS.*/
        public IntBasis WS_NUM_ERRO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
        /*"77        WS-SEQ-OCORRENCIA    PIC  9(006)    VALUE  ZEROS.*/
        public IntBasis WS_SEQ_OCORRENCIA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"77        WS-TIPO-MENSAGEM     PIC  X(001).*/
        public StringBasis WS_TIPO_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77        WS-MSG-DESCRICAO     PIC  X(080).*/
        public StringBasis WS_MSG_DESCRICAO { get; set; } = new StringBasis(new PIC("X", "80", "X(080)."), @"");
        /*"77        WS-SEM-PERDAO        PIC  X(003)    VALUE 'NAO'.*/
        public StringBasis WS_SEM_PERDAO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
        /*"77        WFIM-CPARCATZ        PIC  X(003)    VALUE 'N'.*/
        public StringBasis WFIM_CPARCATZ { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"N");
        /*"77        WS-GEROU-PARC-CARTAO PIC  X(003)    VALUE 'NAO'.*/
        public StringBasis WS_GEROU_PARC_CARTAO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
        /*"77        WS-NUM-PARC-CARTAO   PIC S9(004) COMP VALUE +0.*/
        public IntBasis WS_NUM_PARC_CARTAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        WS-ATZ-NUM-TITULO    PIC S9(13)V USAGE COMP-3 VALUE +0*/
        public DoubleBasis WS_ATZ_NUM_TITULO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"77        WS-ATZ-NUM-PARCELA   PIC S9(4) USAGE COMP VALUE +0.*/
        public IntBasis WS_ATZ_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"77        WS-ATZ-DT-VENCIMENTO PIC X(10) VALUE SPACES.*/
        public StringBasis WS_ATZ_DT_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77        WS-ATZ-VLR-DEBITO    PIC S9(13)V9(2) USAGE COMP-3                                   VALUE +0.*/
        public DoubleBasis WS_ATZ_VLR_DEBITO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77        V0HIST-OCORRHISTCTA  PIC S9(4) USAGE COMP VALUE +0.*/
        public IntBasis V0HIST_OCORRHISTCTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"77        WS-ATZ-COD-RETORNO   PIC S9(4) USAGE COMP VALUE +0.*/
        public IntBasis WS_ATZ_COD_RETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"77        WS-ATZ-COD-MOTIVO    PIC  X(2) VALUE SPACES.*/
        public StringBasis WS_ATZ_COD_MOTIVO { get; set; } = new StringBasis(new PIC("X", "2", "X(2)"), @"");
        /*"77        WS-ATZ-OCORR-HISTCTA PIC S9(4) USAGE COMP VALUE +0.*/
        public IntBasis WS_ATZ_OCORR_HISTCTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"77        V0PARC-CODOPER       PIC S9(4) USAGE COMP VALUE +0.*/
        public IntBasis V0PARC_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"77        WS-NUM-PARCELA-PEND  PIC S9(4) VALUE +0 COMP.*/
        public IntBasis WS_NUM_PARCELA_PEND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"77         WHOST-VLPREMIO-W    PIC S9(013)V99 COMP-3 VALUE +0.*/
        public DoubleBasis WHOST_VLPREMIO_W { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-PRMVG-W       PIC S9(013)V99 COMP-3 VALUE +0.*/
        public DoubleBasis WHOST_PRMVG_W { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-PRMAP-W       PIC S9(013)V99 COMP-3 VALUE +0.*/
        public DoubleBasis WHOST_PRMAP_W { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77        WS-ERRO-AO-GERAR     PIC  X(003)    VALUE 'NAO'.*/
        public StringBasis WS_ERRO_AO_GERAR { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
        /*"77         V1SIST-DT-18D-UTIL        PIC  X(010).*/
        public StringBasis V1SIST_DT_18D_UTIL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SIST-DT-15D-UTIL        PIC  X(010).*/
        public StringBasis V1SIST_DT_15D_UTIL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SIST-DT-08D-UTIL        PIC  X(010).*/
        public StringBasis V1SIST_DT_08D_UTIL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SIST-DTMOVABE           PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SIST-DTHOJE             PIC  X(010).*/
        public StringBasis V1SIST_DTHOJE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SIST-DTVENFIM-6D-UTIL   PIC  X(010).*/
        public StringBasis V1SIST_DTVENFIM_6D_UTIL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SIST-DTVENFIM-CN-GE853S PIC  X(010).*/
        public StringBasis V1SIST_DTVENFIM_CN_GE853S { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SIST-DTVENFIM-1Y-GE853S PIC  X(010).*/
        public StringBasis V1SIST_DTVENFIM_1Y_GE853S { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WS-QTD-PARC-ATRZ          PIC S9(013) VALUE +0 COMP-3*/
        public IntBasis WS_QTD_PARC_ATRZ { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         WHOST-MIN-DTPROXVEN       PIC  X(010).*/
        public StringBasis WHOST_MIN_DTPROXVEN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0BANC-NRTIT        PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0BANC_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0SEGV-NUM-ITEM     PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0SEGV_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0SEGV-SITUACAO     PIC  X(001).*/
        public StringBasis V0SEGV_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0HIST-OCORHIST     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0HIST_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HIST-CODOPER      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0HIST_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HIST-DTMOVTO-1YEAR PIC  X(010).*/
        public StringBasis V0HIST_DTMOVTO_1YEAR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0PROP-NUM-APOLICE  PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0PROP_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0PROP-CODSUBES     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PROP_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PROP-NRCERTIF     PIC S9(015)      VALUE +0 COMP-3.*/
        public IntBasis V0PROP_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0PROP-CODPRODU     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PROP_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PROP-NRPARCEL     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PROP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PROP-SITUACAO     PIC  X(001).*/
        public StringBasis V0PROP_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0PROP-DTVENCTO     PIC  X(010).*/
        public StringBasis V0PROP_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0PROP-DTPROXVEN    PIC  X(010).*/
        public StringBasis V0PROP_DTPROXVEN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0PROP-DTQITBCO     PIC  X(010).*/
        public StringBasis V0PROP_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0PROP-QTDPARATZ    PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PROP_QTDPARATZ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PROP-CODCLIEN     PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0PROP_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0PROP-NRPRIPARATZ  PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PROP_NRPRIPARATZ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PROP-NRMATRFUN    PIC S9(015)      VALUE +0 COMP-3.*/
        public IntBasis V0PROP_NRMATRFUN { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0PROP-INRMATRFUN   PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PROP_INRMATRFUN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PROP-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0PROP_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V0PROP-DTMINVEN     PIC  X(010).*/
        public StringBasis V0PROP_DTMINVEN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0PROP-DTQITBCO-1YEAR PIC  X(010).*/
        public StringBasis V0PROP_DTQITBCO_1YEAR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0PROP-CODOPER      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PROP_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PROP-DTADMISSAO   PIC  X(010).*/
        public StringBasis V0PROP_DTADMISSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0RCDG-DTREFER      PIC  X(10).*/
        public StringBasis V0RCDG_DTREFER { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77         V0RCDG-SITUACAO     PIC  X(01).*/
        public StringBasis V0RCDG_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77         V0CDGC-VLCUSTCDG    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0CDGC_VLCUSTCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77         V0PRDVG-ORIG-PRODU         PIC  X(10).*/
        public StringBasis V0PRDVG_ORIG_PRODU { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77         V0PRDVG-ESTR-COBR          PIC  X(10).*/
        public StringBasis V0PRDVG_ESTR_COBR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77         V0PRDVG-COBERADIC-PREMIO   PIC  X(01).*/
        public StringBasis V0PRDVG_COBERADIC_PREMIO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77         V0PRDVG-CUSTOCAP-TOTAL     PIC  X(01).*/
        public StringBasis V0PRDVG_CUSTOCAP_TOTAL { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77         V0PRDVG-TEM-SAF            PIC  X(01).*/
        public StringBasis V0PRDVG_TEM_SAF { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77         V0PRDVG-TEM-CDG            PIC  X(01).*/
        public StringBasis V0PRDVG_TEM_CDG { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77         V0PRDVG-TEM-IGPM           PIC  X(01).*/
        public StringBasis V0PRDVG_TEM_IGPM { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77         V0PRDVG-OPCAOCAP           PIC S9(004) COMP.*/
        public IntBasis V0PRDVG_OPCAOCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PRDVG-CODPRODAZ          PIC  X(003).*/
        public StringBasis V0PRDVG_CODPRODAZ { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"77         V0PRDVG-OPCAOPAG           PIC  X(001).*/
        public StringBasis V0PRDVG_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0PRDVG-PERIPGTO           PIC S9(004) COMP.*/
        public IntBasis V0PRDVG_PERIPGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PRDVG-NOMPRODU           PIC  X(030).*/
        public StringBasis V0PRDVG_NOMPRODU { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
        /*"77         V0RSAF-DTREFER      PIC  X(10).*/
        public StringBasis V0RSAF_DTREFER { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77         V0RSAF-SITUACAO     PIC  X(01).*/
        public StringBasis V0RSAF_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77         V0RSAF-CODOPER      PIC S9(04) COMP.*/
        public IntBasis V0RSAF_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77         V0SAFC-VLCUSTSAF    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0SAFC_VLCUSTSAF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77         V0OPCP-OPCAOPAG     PIC  X(001).*/
        public StringBasis V0OPCP_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0OPCP-PERIPGTO     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0OPCP_PERIPGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0OPCP-DIA-DEBITO   PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0OPCP_DIA_DEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0OPCP-AGECTADEB    PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0OPCP_AGECTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0OPCP-OPRCTADEB    PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0OPCP_OPRCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0OPCP-NUMCTADEB    PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0OPCP_NUMCTADEB { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0OPCP-DIGCTADEB    PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0OPCP_DIGCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0OPCP-CARTAO-CRED  PIC  X(016)      VALUE SPACES.*/
        public StringBasis V0OPCP_CARTAO_CRED { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"");
        /*"77         V0COBP-DTINIVIG-1   PIC  X(010).*/
        public StringBasis V0COBP_DTINIVIG_1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0COBP-DTINIVIG     PIC  X(010).*/
        public StringBasis V0COBP_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0COBP-VLPREMIO     PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COBP_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0COBP-PRMVG        PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COBP_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0COBP-PRMAP        PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COBP_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0COBP-VLCUSTCAP    PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COBP_VLCUSTCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0COBP-VLCUSTCDG    PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COBP_VLCUSTCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0COBP-VLCUSTAUXF   PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COBP_VLCUSTAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0COBP-IVLCUSTAUXF  PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0COBP_IVLCUSTAUXF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COBP-CODOPER      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0COBP_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COBP-QTTITCAP     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0COBP_QTTITCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WS-TIPO-PROCESSAMENTO PIC S9(004)     VALUE +0 COMP.*/
        public IntBasis WS_TIPO_PROCESSAMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PARC-OCORHIST       PIC S9(004)     VALUE +0 COMP.*/
        public IntBasis V0PARC_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PARC-PRMTOTANT      PIC S9(013)V99  VALUE +0 COMP-3*/
        public DoubleBasis V0PARC_PRMTOTANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0PARC-SITUACAO       PIC  X(001).*/
        public StringBasis V0PARC_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0PARC-SITUACAO1      PIC  X(001).*/
        public StringBasis V0PARC_SITUACAO1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0PARC-DTVENCTO       PIC  X(010).*/
        public StringBasis V0PARC_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0DIFP-NRPARCEL     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0DIFP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0DIFP-CODOPER      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0DIFP_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V3DIFP-CODOPER      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V3DIFP_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0DIFP-VLPRMTOT     PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0DIFP_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0DIFP-PRMDIFVG     PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0DIFP_PRMDIFVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0DIFP-PRMDIFAP     PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0DIFP_PRMDIFAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         HOST-CODCONV        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis HOST_CODCONV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0CONV-CODCONV      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0CONV_CODCONV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0CONV-CCRED        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0CONV_CCRED { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         W-FIM-ERROS         PIC X(003)       VALUE SPACES.*/
        public StringBasis W_FIM_ERROS { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"77         V0HICB-OCORHIST      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0HICB_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HICB-DTVENCTO      PIC  X(010).*/
        public StringBasis V0HICB_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0HICB-VLPRMTOT      PIC S9(013)V99   VALUE +0 COMP-3*/
        public DoubleBasis V0HICB_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0HICB-SITUACAO      PIC  X(001).*/
        public StringBasis V0HICB_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0HICB-CODOPER       PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0HICB_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HICB-OPCAO-PGTO    PIC  X(001).*/
        public StringBasis V0HICB_OPCAO_PGTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0HICB-CODDEVOLV     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0HICB_CODDEVOLV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WS-SEM-RETORNO-SICOV PIC  X(001).*/
        public StringBasis WS_SEM_RETORNO_SICOV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0RELA-NRPARCEL     PIC S9(004) COMP.*/
        public IntBasis V0RELA_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0RELA-NRTIT        PIC S9(013) COMP-3.*/
        public IntBasis V0RELA_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0RELA-DTVENCTO     PIC  X(010).*/
        public StringBasis V0RELA_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0RELA-CODRELAT     PIC  X(010).*/
        public StringBasis V0RELA_CODRELAT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0HCTA-NSAS         PIC S9(004) COMP.*/
        public IntBasis V0HCTA_NSAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HCTA-NSL          PIC S9(009) COMP.*/
        public IntBasis V0HCTA_NSL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HCTA-SITUACAO     PIC  X(001).*/
        public StringBasis V0HCTA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01       WDATA-SQL           PIC  X(010).*/
        public StringBasis WDATA_SQL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01       FILLER              REDEFINES    WDATA-SQL.*/
        private _REDEF_VA0853B_FILLER_0 _filler_0 { get; set; }
        public _REDEF_VA0853B_FILLER_0 FILLER_0
        {
            get { _filler_0 = new _REDEF_VA0853B_FILLER_0(); _.Move(WDATA_SQL, _filler_0); VarBasis.RedefinePassValue(WDATA_SQL, _filler_0, WDATA_SQL); _filler_0.ValueChanged += () => { _.Move(_filler_0, WDATA_SQL); }; return _filler_0; }
            set { VarBasis.RedefinePassValue(value, _filler_0, WDATA_SQL); }
        }  //Redefines
        public class _REDEF_VA0853B_FILLER_0 : VarBasis
        {
            /*"    10   WANO-SQL            PIC  9(004).*/
            public IntBasis WANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    10   FILLER              PIC  X(001).*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    10   WMES-SQL            PIC  9(002).*/
            public IntBasis WMES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    10   FILLER              PIC  X(001).*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    10   WDIA-SQL            PIC  9(002).*/
            public IntBasis WDIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"01  W-TAB-ERRO.*/

            public _REDEF_VA0853B_FILLER_0()
            {
                WANO_SQL.ValueChanged += OnValueChanged;
                FILLER_1.ValueChanged += OnValueChanged;
                WMES_SQL.ValueChanged += OnValueChanged;
                FILLER_2.ValueChanged += OnValueChanged;
                WDIA_SQL.ValueChanged += OnValueChanged;
            }

        }
        public VA0853B_W_TAB_ERRO W_TAB_ERRO { get; set; } = new VA0853B_W_TAB_ERRO();
        public class VA0853B_W_TAB_ERRO : VarBasis
        {
            /*"   10 W-TAB-ERRO-REG   OCCURS 999  TIMES INDEXED BY I01.*/
            public ListBasis<VA0853B_W_TAB_ERRO_REG> W_TAB_ERRO_REG { get; set; } = new ListBasis<VA0853B_W_TAB_ERRO_REG>(999);
            public class VA0853B_W_TAB_ERRO_REG : VarBasis
            {
                /*"      15 W-TB-DESC-ERRO         PIC  X(150).*/
                public StringBasis W_TB_DESC_ERRO { get; set; } = new StringBasis(new PIC("X", "150", "X(150)."), @"");
                /*"01  DCLPF-DET-ARQ-PROPOSTA.*/
            }
        }
        public VA0853B_DCLPF_DET_ARQ_PROPOSTA DCLPF_DET_ARQ_PROPOSTA { get; set; } = new VA0853B_DCLPF_DET_ARQ_PROPOSTA();
        public class VA0853B_DCLPF_DET_ARQ_PROPOSTA : VarBasis
        {
            /*"    10 PF088-NUM-CAMPO-PROPOSTA        PIC S9(9) USAGE COMP.*/
            public IntBasis PF088_NUM_CAMPO_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
            /*"    10 PF088-NOM-DET-ARQ-PROPOSTA      PIC X(50).*/
            public StringBasis PF088_NOM_DET_ARQ_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "50", "X(50)."), @"");
            /*"    10 PF088-DES-DET-ARQ-PROPOSTA.*/
            public VA0853B_PF088_DES_DET_ARQ_PROPOSTA PF088_DES_DET_ARQ_PROPOSTA { get; set; } = new VA0853B_PF088_DES_DET_ARQ_PROPOSTA();
            public class VA0853B_PF088_DES_DET_ARQ_PROPOSTA : VarBasis
            {
                /*"       49 PF088-DET-ARQ-PROPOSTA-LEN   PIC S9(4) USAGE COMP.*/
                public IntBasis PF088_DET_ARQ_PROPOSTA_LEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
                /*"       49 PF088-DET-ARQ-PROPOSTA-TEXT  PIC X(200).*/
                public StringBasis PF088_DET_ARQ_PROPOSTA_TEXT { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");
                /*"01  DCLPF-PROC-PROPOSTA-HIST.*/
            }
        }
        public VA0853B_DCLPF_PROC_PROPOSTA_HIST DCLPF_PROC_PROPOSTA_HIST { get; set; } = new VA0853B_DCLPF_PROC_PROPOSTA_HIST();
        public class VA0853B_DCLPF_PROC_PROPOSTA_HIST : VarBasis
        {
            /*"    10 PF090-SIGLA-ARQUIVO        PIC X(8).*/
            public StringBasis PF090_SIGLA_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
            /*"    10 PF090-SISTEMA-ORIGEM       PIC S9(4) USAGE COMP.*/
            public IntBasis PF090_SISTEMA_ORIGEM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    10 PF090-NSAS-SIVPF           PIC S9(9) USAGE COMP.*/
            public IntBasis PF090_NSAS_SIVPF { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
            /*"    10 PF090-NUM-PROPOSTA         PIC S9(15)V USAGE COMP-3.*/
            public DoubleBasis PF090_NUM_PROPOSTA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
            /*"    10 PF090-SEQ-OCORRENCIA       PIC S9(4) USAGE COMP.*/
            public IntBasis PF090_SEQ_OCORRENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    10 PF090-SEQ-OCORR-HIST       PIC S9(4) USAGE COMP.*/
            public IntBasis PF090_SEQ_OCORR_HIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    10 PF090-STA-PROCESSAMENTO    PIC X(1).*/
            public StringBasis PF090_STA_PROCESSAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
            /*"    10 PF090-COD-USUARIO          PIC X(10).*/
            public StringBasis PF090_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    10 PF090-DTH-ATUALIZACAO      PIC X(26).*/
            public StringBasis PF090_DTH_ATUALIZACAO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
            /*"01          REG-CABEC-01.*/
        }
        public VA0853B_REG_CABEC_01 REG_CABEC_01 { get; set; } = new VA0853B_REG_CABEC_01();
        public class VA0853B_REG_CABEC_01 : VarBasis
        {
            /*"   10        FILLER              PIC  X(010) VALUE 'VA0853B'.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VA0853B");
            /*"   10        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"   10        FILLER              PIC  X(051) VALUE            'RELAT�RIO DI�RIO DE PARCELAS GERADAS NO SIAS'.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"RELAT�RIO DI�RIO DE PARCELAS GERADAS NO SIAS");
            /*"   10        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"   10        FILLER              PIC  X(006) VALUE 'DATA:'.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"DATA:");
            /*"   10        REG-CABEC-01-DATA   PIC  X(010).*/
            public StringBasis REG_CABEC_01_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"   10        FILLER              PIC  X(004) VALUE ' AS '.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @" AS ");
            /*"   10        REG-CABEC-01-HORA   PIC  X(008).*/
            public StringBasis REG_CABEC_01_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"   10        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"01          REG-CABEC-02.*/
        }
        public VA0853B_REG_CABEC_02 REG_CABEC_02 { get; set; } = new VA0853B_REG_CABEC_02();
        public class VA0853B_REG_CABEC_02 : VarBasis
        {
            /*"   10        FILLER            PIC  X(007) VALUE 'APOLICE'.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"APOLICE");
            /*"   10        FILLER            PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"   10        FILLER            PIC  X(008) VALUE 'SUBGRUPO'.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"SUBGRUPO");
            /*"   10        FILLER            PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"   10        FILLER            PIC  X(014)                               VALUE 'CODIGO PRODUTO'.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"CODIGO PRODUTO");
            /*"   10        FILLER            PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"   10        FILLER            PIC  X(015)                               VALUE 'NOME DO PRODUTO'.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"NOME DO PRODUTO");
            /*"   10        FILLER            PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"   10        FILLER            PIC  X(011) VALUE 'CERTIFICADO'.*/
            public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"CERTIFICADO");
            /*"   10        FILLER            PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"   10        FILLER            PIC  X(020)                               VALUE 'SITUACAO CERTIFICADO'.*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"SITUACAO CERTIFICADO");
            /*"   10        FILLER            PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"   10        FILLER            PIC  X(018)                               VALUE 'PERIODICIDADE PGTO'.*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"PERIODICIDADE PGTO");
            /*"   10        FILLER            PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"   10        FILLER            PIC  X(011) VALUE 'OPCAO PGTO'.*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"OPCAO PGTO");
            /*"   10        FILLER            PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"   10        FILLER            PIC  X(007) VALUE 'PARCELA'.*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"PARCELA");
            /*"   10        FILLER            PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"   10        FILLER            PIC  X(015)                               VALUE 'DATA VENCIMENTO'.*/
            public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"DATA VENCIMENTO");
            /*"   10        FILLER            PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"   10        FILLER            PIC  X(012)                               VALUE 'VALOR PREMIO'.*/
            public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"VALOR PREMIO");
            /*"   10        FILLER            PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"   10        FILLER            PIC  X(011) VALUE 'SIT PARCELA'.*/
            public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"SIT PARCELA");
            /*"   10        FILLER            PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"   10        FILLER            PIC  X(015)                               VALUE 'OPCAO PGTO PARC'.*/
            public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"OPCAO PGTO PARC");
            /*"   10        FILLER            PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"   10        FILLER            PIC  X(013) VALUE 'TIPO MENSAGEM'*/
            public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"TIPO MENSAGEM");
            /*"   10        FILLER            PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"   10        FILLER            PIC  X(009) VALUE 'DESCRICAO'.*/
            public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"DESCRICAO");
            /*"   10        FILLER            PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"01         REG-DET.*/
        }
        public VA0853B_REG_DET REG_DET { get; set; } = new VA0853B_REG_DET();
        public class VA0853B_REG_DET : VarBasis
        {
            /*"  10        REG-SAI-NUM-APOLICE PIC  9(013).*/
            public IntBasis REG_SAI_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"  10        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        REG-SAI-CD-SUBGRUPO PIC  9(004).*/
            public IntBasis REG_SAI_CD_SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  10        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        REG-SAI-CD-PRODUTO  PIC  9(004).*/
            public IntBasis REG_SAI_CD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  10        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        REG-SAI-NOME-PROD   PIC  X(020) VALUE SPACES.*/
            public StringBasis REG_SAI_NOME_PROD { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
            /*"  10        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        REG-SAI-NRCERTIF    PIC  9(015).*/
            public IntBasis REG_SAI_NRCERTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"  10        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        REG-SAI-SIT-REG-CRT PIC  X(018) VALUE SPACES.*/
            public StringBasis REG_SAI_SIT_REG_CRT { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"");
            /*"  10        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        REG-SAI-PERI-PGTO   PIC  X(012) VALUE SPACES.*/
            public StringBasis REG_SAI_PERI_PGTO { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"");
            /*"  10        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        REG-SAI-OPCAO-PGTO  PIC  X(012) VALUE SPACES.*/
            public StringBasis REG_SAI_OPCAO_PGTO { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"");
            /*"  10        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        REG-SAI-NRPARCEL    PIC  9(005).*/
            public IntBasis REG_SAI_NRPARCEL { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"  10        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        REG-SAI-DT-VENC     PIC  X(010) VALUE SPACES.*/
            public StringBasis REG_SAI_DT_VENC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  10        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        REG-SAI-PRM-INT     PIC  ZZZZZZZZZZZZ9.*/
            public IntBasis REG_SAI_PRM_INT { get; set; } = new IntBasis(new PIC("9", "13", "ZZZZZZZZZZZZ9."));
            /*"  10        FILLER              PIC  X(001) VALUE '.'.*/
            public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
            /*"  10        REG-SAI-PRM-DEC     PIC  9(002).*/
            public IntBasis REG_SAI_PRM_DEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  10        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        REG-SAI-SIT-REG-PAR PIC  X(018) VALUE SPACES.*/
            public StringBasis REG_SAI_SIT_REG_PAR { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"");
            /*"  10        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        REG-SAI-OP-PGTO-PAR PIC  X(013) VALUE SPACES.*/
            public StringBasis REG_SAI_OP_PGTO_PAR { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"");
            /*"  10        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        REG-TIPO-MENSAGEM   PIC  X(012) VALUE SPACES.*/
            public StringBasis REG_TIPO_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"");
            /*"  10        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        REG-SAI-DESCRICAO   PIC  X(092) VALUE SPACES.*/
            public StringBasis REG_SAI_DESCRICAO { get; set; } = new StringBasis(new PIC("X", "92", "X(092)"), @"");
            /*"  10        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"01  WS-NUM-PARCELA              PIC S9(004)   VALUE +0 COMP.*/
        }
        public IntBasis WS_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WPRI-PARCELA                PIC  9(001)   VALUE ZEROS.*/
        public IntBasis WPRI_PARCELA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"01  W-IGPM-CADASTRADO           PIC  X(001)   VALUE SPACES.*/
        public StringBasis W_IGPM_CADASTRADO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01  W-TITULO-CED                PIC  9(013)   VALUE ZEROS.*/
        public IntBasis W_TITULO_CED { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
        /*"01  W-TITULO                    PIC S9(013)   VALUE +0 COMP-3.*/
        public IntBasis W_TITULO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01  WS-NUMERO-TITULO            PIC S9(013)   VALUE +0 COMP-3.*/
        public IntBasis WS_NUMERO_TITULO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01  WS-COD-IDLG                 PIC  X(040)   VALUE SPACES.*/
        public StringBasis WS_COD_IDLG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
        /*"01  WS-COD-IDLG-ADESAO          PIC  X(040)   VALUE SPACES.*/
        public StringBasis WS_COD_IDLG_ADESAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
        /*"01  FILLER                      REDEFINES    WS-COD-IDLG-ADESAO.*/
        private _REDEF_VA0853B_FILLER_56 _filler_56 { get; set; }
        public _REDEF_VA0853B_FILLER_56 FILLER_56
        {
            get { _filler_56 = new _REDEF_VA0853B_FILLER_56(); _.Move(WS_COD_IDLG_ADESAO, _filler_56); VarBasis.RedefinePassValue(WS_COD_IDLG_ADESAO, _filler_56, WS_COD_IDLG_ADESAO); _filler_56.ValueChanged += () => { _.Move(_filler_56, WS_COD_IDLG_ADESAO); }; return _filler_56; }
            set { VarBasis.RedefinePassValue(value, _filler_56, WS_COD_IDLG_ADESAO); }
        }  //Redefines
        public class _REDEF_VA0853B_FILLER_56 : VarBasis
        {
            /*"  05    WS-IDLG-FIXO            PIC  X(15).*/
            public StringBasis WS_IDLG_FIXO { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
            /*"  05    WS-IDLG-NUM-CERTIFICADO PIC  ZZZZZZZZZZZZ99.*/
            public IntBasis WS_IDLG_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("9", "14", "ZZZZZZZZZZZZ99."));
            /*"  05    WS-IDLG-ESPACOS         PIC  X(11).*/
            public StringBasis WS_IDLG_ESPACOS { get; set; } = new StringBasis(new PIC("X", "11", "X(11)."), @"");
            /*"01  W-NUMR-TITULO               PIC  9(013)   VALUE ZEROS.*/

            public _REDEF_VA0853B_FILLER_56()
            {
                WS_IDLG_FIXO.ValueChanged += OnValueChanged;
                WS_IDLG_NUM_CERTIFICADO.ValueChanged += OnValueChanged;
                WS_IDLG_ESPACOS.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis W_NUMR_TITULO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
        /*"01  FILLER                      REDEFINES    W-NUMR-TITULO.*/
        private _REDEF_VA0853B_FILLER_57 _filler_57 { get; set; }
        public _REDEF_VA0853B_FILLER_57 FILLER_57
        {
            get { _filler_57 = new _REDEF_VA0853B_FILLER_57(); _.Move(W_NUMR_TITULO, _filler_57); VarBasis.RedefinePassValue(W_NUMR_TITULO, _filler_57, W_NUMR_TITULO); _filler_57.ValueChanged += () => { _.Move(_filler_57, W_NUMR_TITULO); }; return _filler_57; }
            set { VarBasis.RedefinePassValue(value, _filler_57, W_NUMR_TITULO); }
        }  //Redefines
        public class _REDEF_VA0853B_FILLER_57 : VarBasis
        {
            /*"  05    WTITL-ZEROS             PIC  9(002).*/
            public IntBasis WTITL_ZEROS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05    WTITL-SEQUENCIA         PIC  9(010).*/
            public IntBasis WTITL_SEQUENCIA { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"  05    WTITL-DIGITO            PIC  9(001).*/
            public IntBasis WTITL_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"01  TABELA-ULTIMOS-DIAS.*/

            public _REDEF_VA0853B_FILLER_57()
            {
                WTITL_ZEROS.ValueChanged += OnValueChanged;
                WTITL_SEQUENCIA.ValueChanged += OnValueChanged;
                WTITL_DIGITO.ValueChanged += OnValueChanged;
            }

        }
        public VA0853B_TABELA_ULTIMOS_DIAS TABELA_ULTIMOS_DIAS { get; set; } = new VA0853B_TABELA_ULTIMOS_DIAS();
        public class VA0853B_TABELA_ULTIMOS_DIAS : VarBasis
        {
            /*"    05 FILLER                   PIC  X(024)  VALUE                                '312831303130313130313031'.*/
            public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"312831303130313130313031");
            /*"01  TAB-ULTIMOS-DIAS  REDEFINES TABELA-ULTIMOS-DIAS.*/
        }
        private _REDEF_VA0853B_TAB_ULTIMOS_DIAS _tab_ultimos_dias { get; set; }
        public _REDEF_VA0853B_TAB_ULTIMOS_DIAS TAB_ULTIMOS_DIAS
        {
            get { _tab_ultimos_dias = new _REDEF_VA0853B_TAB_ULTIMOS_DIAS(); _.Move(TABELA_ULTIMOS_DIAS, _tab_ultimos_dias); VarBasis.RedefinePassValue(TABELA_ULTIMOS_DIAS, _tab_ultimos_dias, TABELA_ULTIMOS_DIAS); _tab_ultimos_dias.ValueChanged += () => { _.Move(_tab_ultimos_dias, TABELA_ULTIMOS_DIAS); }; return _tab_ultimos_dias; }
            set { VarBasis.RedefinePassValue(value, _tab_ultimos_dias, TABELA_ULTIMOS_DIAS); }
        }  //Redefines
        public class _REDEF_VA0853B_TAB_ULTIMOS_DIAS : VarBasis
        {
            /*"    05 TAB-DIA-MESES            OCCURS 12.*/
            public ListBasis<VA0853B_TAB_DIA_MESES> TAB_DIA_MESES { get; set; } = new ListBasis<VA0853B_TAB_DIA_MESES>(12);
            public class VA0853B_TAB_DIA_MESES : VarBasis
            {
                /*"      07 TAB-DIA-MES            PIC  9(002).*/
                public IntBasis TAB_DIA_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"01  W-VLPREMIO                  PIC  9(013)V99 VALUE ZEROS.*/

                public VA0853B_TAB_DIA_MESES()
                {
                    TAB_DIA_MES.ValueChanged += OnValueChanged;
                }

            }

            public _REDEF_VA0853B_TAB_ULTIMOS_DIAS()
            {
                TAB_DIA_MESES.ValueChanged += OnValueChanged;
            }

        }
        public DoubleBasis W_VLPREMIO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
        /*"01  FILLER                      REDEFINES    W-VLPREMIO.*/
        private _REDEF_VA0853B_FILLER_59 _filler_59 { get; set; }
        public _REDEF_VA0853B_FILLER_59 FILLER_59
        {
            get { _filler_59 = new _REDEF_VA0853B_FILLER_59(); _.Move(W_VLPREMIO, _filler_59); VarBasis.RedefinePassValue(W_VLPREMIO, _filler_59, W_VLPREMIO); _filler_59.ValueChanged += () => { _.Move(_filler_59, W_VLPREMIO); }; return _filler_59; }
            set { VarBasis.RedefinePassValue(value, _filler_59, W_VLPREMIO); }
        }  //Redefines
        public class _REDEF_VA0853B_FILLER_59 : VarBasis
        {
            /*"  05    WVPRM-INTEIRO           PIC  9(013).*/
            public IntBasis WVPRM_INTEIRO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"  05    WVPRM-DECIMAL           PIC  9(002).*/
            public IntBasis WVPRM_DECIMAL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"01              DPARM01X.*/

            public _REDEF_VA0853B_FILLER_59()
            {
                WVPRM_INTEIRO.ValueChanged += OnValueChanged;
                WVPRM_DECIMAL.ValueChanged += OnValueChanged;
            }

        }
        public VA0853B_DPARM01X DPARM01X { get; set; } = new VA0853B_DPARM01X();
        public class VA0853B_DPARM01X : VarBasis
        {
            /*"  05            DPARM01           PIC  9(010).*/
            public IntBasis DPARM01 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"  05            DPARM01-R         REDEFINES   DPARM01.*/
            private _REDEF_VA0853B_DPARM01_R _dparm01_r { get; set; }
            public _REDEF_VA0853B_DPARM01_R DPARM01_R
            {
                get { _dparm01_r = new _REDEF_VA0853B_DPARM01_R(); _.Move(DPARM01, _dparm01_r); VarBasis.RedefinePassValue(DPARM01, _dparm01_r, DPARM01); _dparm01_r.ValueChanged += () => { _.Move(_dparm01_r, DPARM01); }; return _dparm01_r; }
                set { VarBasis.RedefinePassValue(value, _dparm01_r, DPARM01); }
            }  //Redefines
            public class _REDEF_VA0853B_DPARM01_R : VarBasis
            {
                /*"    10          DPARM01-1         PIC  9(001).*/
                public IntBasis DPARM01_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10          DPARM01-2         PIC  9(001).*/
                public IntBasis DPARM01_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10          DPARM01-3         PIC  9(001).*/
                public IntBasis DPARM01_3 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10          DPARM01-4         PIC  9(001).*/
                public IntBasis DPARM01_4 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10          DPARM01-5         PIC  9(001).*/
                public IntBasis DPARM01_5 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10          DPARM01-6         PIC  9(001).*/
                public IntBasis DPARM01_6 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10          DPARM01-7         PIC  9(001).*/
                public IntBasis DPARM01_7 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10          DPARM01-8         PIC  9(001).*/
                public IntBasis DPARM01_8 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10          DPARM01-9         PIC  9(001).*/
                public IntBasis DPARM01_9 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10          DPARM01-10        PIC  9(001).*/
                public IntBasis DPARM01_10 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  05            DPARM01-D1        PIC  9(001).*/

                public _REDEF_VA0853B_DPARM01_R()
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
            /*"  05            DPARM01-RC        PIC S9(004) COMP VALUE +0.*/
            public IntBasis DPARM01_RC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01           AREA-DE-WORK.*/
        }
        public VA0853B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VA0853B_AREA_DE_WORK();
        public class VA0853B_AREA_DE_WORK : VarBasis
        {
            /*"  05         WSL-SQLCODE       PIC  X(010)    VALUE SPACES.*/
            public StringBasis WSL_SQLCODE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         W-SIT-REG-CERT    PIC  X(018)    VALUE SPACES.*/
            public StringBasis W_SIT_REG_CERT { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"");
            /*"  05         W-PER-PAG-CERT    PIC  X(015)    VALUE SPACES.*/
            public StringBasis W_PER_PAG_CERT { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
            /*"  05         W-OPC-PAG-CERT    PIC  X(015)    VALUE SPACES.*/
            public StringBasis W_OPC_PAG_CERT { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
            /*"  05         W-SIT-REG-PARC    PIC  X(020)    VALUE SPACES.*/
            public StringBasis W_SIT_REG_PARC { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
            /*"  05         W-OPC-PAG-PARC    PIC  X(020)    VALUE SPACES.*/
            public StringBasis W_OPC_PAG_PARC { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
            /*"  05         WS-QTD-TP-MSG-S   PIC  9(009)    VALUE  ZEROS.*/
            public IntBasis WS_QTD_TP_MSG_S { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WS-QTD-TP-MSG-C   PIC  9(009)    VALUE  ZEROS.*/
            public IntBasis WS_QTD_TP_MSG_C { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WS-QTD-TP-MSG-E   PIC  9(009)    VALUE  ZEROS.*/
            public IntBasis WS_QTD_TP_MSG_E { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WS-QTD-TP-MSG-A   PIC  9(009)    VALUE  ZEROS.*/
            public IntBasis WS_QTD_TP_MSG_A { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WS-QTD-TP-MSG-I   PIC  9(009)    VALUE  ZEROS.*/
            public IntBasis WS_QTD_TP_MSG_I { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WACC-LIDOS        PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis WACC_LIDOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WACC-CONTA        PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis WACC_CONTA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WACC-GRAVADOS     PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis WACC_GRAVADOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WACC-GRAV-ATRZ    PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis WACC_GRAV_ATRZ { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WACC-ATRZ-BOL     PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis WACC_ATRZ_BOL { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WACC-ATRZ-CONTA   PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis WACC_ATRZ_CONTA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WACC-ATRZ-CARTAO  PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis WACC_ATRZ_CARTAO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WACC-GRAV-BOL     PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis WACC_GRAV_BOL { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WACC-GRAV-CONTA   PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis WACC_GRAV_CONTA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WACC-GRAV-CARTAO  PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis WACC_GRAV_CARTAO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WACC-GRAV-CANC    PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis WACC_GRAV_CANC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WACC-ERRO-ATRZ    PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis WACC_ERRO_ATRZ { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WANO-BISSEXTO     PIC  9(004).*/
            public IntBasis WANO_BISSEXTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         WACC-COMMIT       PIC  9(004)       VALUE  ZEROS.*/
            public IntBasis WACC_COMMIT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         WFIM-CPROPVA    PIC X(001)  VALUE SPACES.*/
            public StringBasis WFIM_CPROPVA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-CDIFPAR    PIC X(001)  VALUE SPACES.*/
            public StringBasis WFIM_CDIFPAR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WREGULARIZOU    PIC X(001)  VALUE SPACES.*/
            public StringBasis WREGULARIZOU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WS-FLAG-PROX-LER PIC 9(001) VALUE ZEROS.*/
            public IntBasis WS_FLAG_PROX_LER { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  05         WS-TIME         PIC X(008).*/
            public StringBasis WS_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  05         WNSAS           PIC 9(005).*/
            public IntBasis WNSAS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"  05         WDATA-SISTEMA.*/
            public VA0853B_WDATA_SISTEMA WDATA_SISTEMA { get; set; } = new VA0853B_WDATA_SISTEMA();
            public class VA0853B_WDATA_SISTEMA : VarBasis
            {
                /*"    10       WDATA-SIS-ANO     PIC  9(004).*/
                public IntBasis WDATA_SIS_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-SIS-MES     PIC  9(002).*/
                public IntBasis WDATA_SIS_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-SIS-DIA     PIC  9(002).*/
                public IntBasis WDATA_SIS_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDATA-PRIMEIRA.*/
            }
            public VA0853B_WDATA_PRIMEIRA WDATA_PRIMEIRA { get; set; } = new VA0853B_WDATA_PRIMEIRA();
            public class VA0853B_WDATA_PRIMEIRA : VarBasis
            {
                /*"    10       WDATA-PRI-ANO     PIC  9(004).*/
                public IntBasis WDATA_PRI_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-PRI-MES     PIC  9(002).*/
                public IntBasis WDATA_PRI_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-PRI-DIA     PIC  9(002).*/
                public IntBasis WDATA_PRI_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDATA-VIGENCIA.*/
            }
            public VA0853B_WDATA_VIGENCIA WDATA_VIGENCIA { get; set; } = new VA0853B_WDATA_VIGENCIA();
            public class VA0853B_WDATA_VIGENCIA : VarBasis
            {
                /*"    10       WDATA-VIG-ANO     PIC  9(004).*/
                public IntBasis WDATA_VIG_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-VIG-MES     PIC  9(002).*/
                public IntBasis WDATA_VIG_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-VIG-DIA     PIC  9(002).*/
                public IntBasis WDATA_VIG_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDATA-VIGENCIA1.*/
            }
            public VA0853B_WDATA_VIGENCIA1 WDATA_VIGENCIA1 { get; set; } = new VA0853B_WDATA_VIGENCIA1();
            public class VA0853B_WDATA_VIGENCIA1 : VarBasis
            {
                /*"    10       WDATA-VIG-ANO1    PIC  9(004).*/
                public IntBasis WDATA_VIG_ANO1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-VIG-MES1    PIC  9(002).*/
                public IntBasis WDATA_VIG_MES1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-VIG-DIA1    PIC  9(002).*/
                public IntBasis WDATA_VIG_DIA1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDATA-VENCIMENTO.*/
            }
            public VA0853B_WDATA_VENCIMENTO WDATA_VENCIMENTO { get; set; } = new VA0853B_WDATA_VENCIMENTO();
            public class VA0853B_WDATA_VENCIMENTO : VarBasis
            {
                /*"    10       WDATA-VCT-ANO     PIC  9(004).*/
                public IntBasis WDATA_VCT_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-VCT-MES     PIC  9(002).*/
                public IntBasis WDATA_VCT_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-VCT-DIA     PIC  9(002).*/
                public IntBasis WDATA_VCT_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         W01DTSQL.*/
            }
            public VA0853B_W01DTSQL W01DTSQL { get; set; } = new VA0853B_W01DTSQL();
            public class VA0853B_W01DTSQL : VarBasis
            {
                /*"    10       W01AASQL          PIC 9(004).*/
                public IntBasis W01AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       W01T1SQL          PIC X(001).*/
                public StringBasis W01T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       W01MMSQL          PIC 9(002).*/
                public IntBasis W01MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       W01T2SQL          PIC X(001).*/
                public StringBasis W01T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       W01DDSQL          PIC 9(002).*/
                public IntBasis W01DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05   PARM-PROSOMU1.*/
            }
            public VA0853B_PARM_PROSOMU1 PARM_PROSOMU1 { get; set; } = new VA0853B_PARM_PROSOMU1();
            public class VA0853B_PARM_PROSOMU1 : VarBasis
            {
                /*"    10   SU1-DATA1.*/
                public VA0853B_SU1_DATA1 SU1_DATA1 { get; set; } = new VA0853B_SU1_DATA1();
                public class VA0853B_SU1_DATA1 : VarBasis
                {
                    /*"      15   SU1-DD1                   PIC 99.*/
                    public IntBasis SU1_DD1 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"      15   SU1-MM1                   PIC 99.*/
                    public IntBasis SU1_MM1 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"      15   SU1-AA1                   PIC 9999.*/
                    public IntBasis SU1_AA1 { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
                    /*"    10   SU1-NRDIAS                  PIC S9(5) COMP-3.*/
                }
                public IntBasis SU1_NRDIAS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(5)"));
                /*"    10   SU1-DATA2.*/
                public VA0853B_SU1_DATA2 SU1_DATA2 { get; set; } = new VA0853B_SU1_DATA2();
                public class VA0853B_SU1_DATA2 : VarBasis
                {
                    /*"      15   SU1-DD2                   PIC 99.*/
                    public IntBasis SU1_DD2 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"      15   SU1-MM2                   PIC 99.*/
                    public IntBasis SU1_MM2 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"      15   SU1-AA2                   PIC 9999.*/
                    public IntBasis SU1_AA2 { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
                    /*"  05   WTAB-DATAS-UTEIS.*/
                }
            }
            public VA0853B_WTAB_DATAS_UTEIS WTAB_DATAS_UTEIS { get; set; } = new VA0853B_WTAB_DATAS_UTEIS();
            public class VA0853B_WTAB_DATAS_UTEIS : VarBasis
            {
                /*"    10 WTAB-DATATR OCCURS 15         PIC X(010).*/
                public ListBasis<StringBasis, string> WTAB_DATATR { get; set; } = new ListBasis<StringBasis, string>(new PIC("9", "10", "X(010)."), 15);
                /*"  05          WDATA-MINVEN.*/
            }
            public VA0853B_WDATA_MINVEN WDATA_MINVEN { get; set; } = new VA0853B_WDATA_MINVEN();
            public class VA0853B_WDATA_MINVEN : VarBasis
            {
                /*"    10        WDATA-SAVEN      PIC 9(004).*/
                public IntBasis WDATA_SAVEN { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        WDATA-SAVEN-R    REDEFINES              WDATA-SAVEN.*/
                private _REDEF_VA0853B_WDATA_SAVEN_R _wdata_saven_r { get; set; }
                public _REDEF_VA0853B_WDATA_SAVEN_R WDATA_SAVEN_R
                {
                    get { _wdata_saven_r = new _REDEF_VA0853B_WDATA_SAVEN_R(); _.Move(WDATA_SAVEN, _wdata_saven_r); VarBasis.RedefinePassValue(WDATA_SAVEN, _wdata_saven_r, WDATA_SAVEN); _wdata_saven_r.ValueChanged += () => { _.Move(_wdata_saven_r, WDATA_SAVEN); }; return _wdata_saven_r; }
                    set { VarBasis.RedefinePassValue(value, _wdata_saven_r, WDATA_SAVEN); }
                }  //Redefines
                public class _REDEF_VA0853B_WDATA_SAVEN_R : VarBasis
                {
                    /*"      15      WDATA-AAVEN      PIC 9(004).*/
                    public IntBasis WDATA_AAVEN { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"    10        WDATA-T1VEN      PIC X(001).*/

                    public _REDEF_VA0853B_WDATA_SAVEN_R()
                    {
                        WDATA_AAVEN.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis WDATA_T1VEN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        WDATA-MMVEN      PIC 9(002).*/
                public IntBasis WDATA_MMVEN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10        WDATA-T2VEN      PIC X(001).*/
                public StringBasis WDATA_T2VEN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        WDATA-DDVEN      PIC 9(002).*/
                public IntBasis WDATA_DDVEN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05          WDATA-CORRENTE   PIC X(010).*/
            }
            public StringBasis WDATA_CORRENTE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05          WDATA-MINATR.*/
            public VA0853B_WDATA_MINATR WDATA_MINATR { get; set; } = new VA0853B_WDATA_MINATR();
            public class VA0853B_WDATA_MINATR : VarBasis
            {
                /*"    10        WDATA-SAATR      PIC 9(004).*/
                public IntBasis WDATA_SAATR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        WDATA-SAATR-R    REDEFINES              WDATA-SAATR.*/
                private _REDEF_VA0853B_WDATA_SAATR_R _wdata_saatr_r { get; set; }
                public _REDEF_VA0853B_WDATA_SAATR_R WDATA_SAATR_R
                {
                    get { _wdata_saatr_r = new _REDEF_VA0853B_WDATA_SAATR_R(); _.Move(WDATA_SAATR, _wdata_saatr_r); VarBasis.RedefinePassValue(WDATA_SAATR, _wdata_saatr_r, WDATA_SAATR); _wdata_saatr_r.ValueChanged += () => { _.Move(_wdata_saatr_r, WDATA_SAATR); }; return _wdata_saatr_r; }
                    set { VarBasis.RedefinePassValue(value, _wdata_saatr_r, WDATA_SAATR); }
                }  //Redefines
                public class _REDEF_VA0853B_WDATA_SAATR_R : VarBasis
                {
                    /*"      15      WDATA-AAATR      PIC 9(004).*/
                    public IntBasis WDATA_AAATR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"    10        WDATA-T1ATR      PIC X(001).*/

                    public _REDEF_VA0853B_WDATA_SAATR_R()
                    {
                        WDATA_AAATR.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis WDATA_T1ATR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        WDATA-MMATR      PIC 9(002).*/
                public IntBasis WDATA_MMATR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10        WDATA-T2ATR      PIC X(001).*/
                public StringBasis WDATA_T2ATR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        WDATA-DDATR      PIC 9(002).*/
                public IntBasis WDATA_DDATR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05          WIND-DATA        PIC 9(002).*/
            }
            public IntBasis WIND_DATA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05        WABEND.*/
            public VA0853B_WABEND WABEND { get; set; } = new VA0853B_WABEND();
            public class VA0853B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(008) VALUE           'VA0853B '.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"VA0853B ");
                /*"    10      FILLER              PIC  X(025) VALUE           '*** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"*** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL        PIC  X(005) VALUE '00000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"00000");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"  05        WSQLERRO.*/
            }
            public VA0853B_WSQLERRO WSQLERRO { get; set; } = new VA0853B_WSQLERRO();
            public class VA0853B_WSQLERRO : VarBasis
            {
                /*"    10      FILLER              PIC  X(014) VALUE           ' *** SQLERRMC '.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @" *** SQLERRMC ");
                /*"    10      WSQLERRMC           PIC  X(070) VALUE  SPACES.*/
                public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                /*"01           GE0006S-LINKAGE.*/
            }
        }
        public VA0853B_GE0006S_LINKAGE GE0006S_LINKAGE { get; set; } = new VA0853B_GE0006S_LINKAGE();
        public class VA0853B_GE0006S_LINKAGE : VarBasis
        {
            /*"  05         GE0006S-DATA-DESTINO    PIC  X(010).*/
            public StringBasis GE0006S_DATA_DESTINO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05         GE0006S-QTDDIAS         PIC  9(004).*/
            public IntBasis GE0006S_QTDDIAS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         GE0006S-MENSAGEM        PIC  X(070).*/
            public StringBasis GE0006S_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
            /*"01  REGISTRO-LINKAGE-GE0853S.*/
        }
        public VA0853B_REGISTRO_LINKAGE_GE0853S REGISTRO_LINKAGE_GE0853S { get; set; } = new VA0853B_REGISTRO_LINKAGE_GE0853S();
        public class VA0853B_REGISTRO_LINKAGE_GE0853S : VarBasis
        {
            /*"    10 LK-GE853-NUM-CERTIFICADO   PIC S9(15)V COMP-3.*/
            public DoubleBasis LK_GE853_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
            /*"    10 LK-GE853-NUM-PARCELA       PIC S9(04)  COMP.*/
            public IntBasis LK_GE853_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    10 LK-GE853-VLR-PREMIO        PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_GE853_VLR_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10 LK-GE853-SIT-CERTIFICADO   PIC  X(01).*/
            public StringBasis LK_GE853_SIT_CERTIFICADO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    10 LK-GE853-SIT-PARCELA       PIC  X(01).*/
            public StringBasis LK_GE853_SIT_PARCELA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    10 LK-GE853-OPC-PAG-PARCELA   PIC S9(04)  COMP.*/
            public IntBasis LK_GE853_OPC_PAG_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    10 LK-GE853-DT-CORRENTE       PIC  X(10).*/
            public StringBasis LK_GE853_DT_CORRENTE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    10 LK-GE853-DT-CORRENTE-18D   PIC  X(10).*/
            public StringBasis LK_GE853_DT_CORRENTE_18D { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    10 LK-GE853-DT-MOVIMENTO      PIC  X(10).*/
            public StringBasis LK_GE853_DT_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    10 LK-GE853-DT-MOVIMENTO-1Y   PIC  X(10).*/
            public StringBasis LK_GE853_DT_MOVIMENTO_1Y { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    10 LK-GE853-COD-REJEICAO      PIC  X(10).*/
            public StringBasis LK_GE853_COD_REJEICAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    10 LK-GE853-COD-RETORNO       PIC  X(01).*/
            public StringBasis LK_GE853_COD_RETORNO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    10 LK-GE853-NUM-ERRO          PIC S9(04)  COMP.*/
            public IntBasis LK_GE853_NUM_ERRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    10 LK-GE853-MENSAGEM.*/
            public VA0853B_LK_GE853_MENSAGEM LK_GE853_MENSAGEM { get; set; } = new VA0853B_LK_GE853_MENSAGEM();
            public class VA0853B_LK_GE853_MENSAGEM : VarBasis
            {
                /*"       20 LK-GE853-SQLCODE        PIC -ZZ9.*/
                public IntBasis LK_GE853_SQLCODE { get; set; } = new IntBasis(new PIC("9", "3", "-ZZ9."));
                /*"       20 FILLER                  PIC X(01).*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       20 LK-GE853-MSG-RETORNO    PIC X(75).*/
                public StringBasis LK_GE853_MSG_RETORNO { get; set; } = new StringBasis(new PIC("X", "75", "X(75)."), @"");
                /*"01  LK-PARAMETROS.*/
            }
        }
        public VA0853B_LK_PARAMETROS LK_PARAMETROS { get; set; } = new VA0853B_LK_PARAMETROS();
        public class VA0853B_LK_PARAMETROS : VarBasis
        {
            /*"  04  FILLER                  PIC X(002).*/
            public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  04  LK-OPERACAO             PIC X(008).*/
            public StringBasis LK_OPERACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  04  FILLER                  PIC X(001).*/
            public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  04  LK-NUM-CERTIFICADO      PIC 9(015).*/
            public IntBasis LK_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"  04  FILLER                  PIC X(001).*/
            public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  04  LK-DT-PROCESSAMENTO     PIC X(010).*/
            public StringBasis LK_DT_PROCESSAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  04  FILLER                  PIC X(001).*/
            public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        }


        public Dclgens.MOVDEBCE MOVDEBCE { get; set; } = new Dclgens.MOVDEBCE();
        public Dclgens.CALENDAR CALENDAR { get; set; } = new Dclgens.CALENDAR();
        public Dclgens.CEDENTE CEDENTE { get; set; } = new Dclgens.CEDENTE();
        public Dclgens.ARQSIVPF ARQSIVPF { get; set; } = new Dclgens.ARQSIVPF();
        public Dclgens.GE408 GE408 { get; set; } = new Dclgens.GE408();
        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.PF087 PF087 { get; set; } = new Dclgens.PF087();
        public Dclgens.PF089 PF089 { get; set; } = new Dclgens.PF089();
        public VA0853B_ERROPROC ERROPROC { get; set; } = new VA0853B_ERROPROC();
        public VA0853B_CPARCATZ CPARCATZ { get; set; } = new VA0853B_CPARCATZ();
        public VA0853B_CDIFPAR CDIFPAR { get; set; } = new VA0853B_CDIFPAR();
        public VA0853B_CGERARAT CGERARAT { get; set; } = new VA0853B_CGERARAT();

        public VA0853B_CPROPVAL CPROPVAL { get; set; } = new VA0853B_CPROPVAL(true);
        string GetQuery_CPROPVAL()
        {
            var query = @$"SELECT 1
							, A.NUM_APOLICE
							, A.CODSUBES
							, A.NRCERTIF
							, A.CODPRODU
							, A.CODCLIEN
							, A.NRPARCE
							, A.SITUACAO
							, A.DTQITBCO
							, A.DTVENCTO
							, A.DTPROXVEN
							, A.NRPRIPARATZ
							, A.QTDPARATZ
							, VALUE(A.NUM_MATRICULA
							, 0)
							, A.TIMESTAMP
							, A.DTQITBCO + 1 MONTH
							, A.DTQITBCO + 1 YEAR
							, A.CODOPER
							, VALUE(A.DATA_ADMISSAO
							, '2001-01-01')
							, VALUE(D.ESTR_COBR
							, ' ')
							, VALUE(D.ORIG_PRODU
							, ' ')
							, VALUE(D.TEM_SAF
							, 'N')
							, VALUE(D.TEM_CDG
							, 'N')
							, VALUE(D.TEM_IGPM
							, 'N')
							, D.CODPRODAZ
							, D.OPCAOCAP
							, D.COBERADIC_PREMIO
							, D.CUSTOCAP_TOTAL
							, D.OPCAOPAG
							, D.PERIPGTO
							, D.NOMPRODU
							, VALUE(E.OPCAOPAG
							, ' ')
							, VALUE(E.PERIPGTO
							, 0)
							, VALUE(E.DIA_DEBITO
							, 0)
							, VALUE(E.AGECTADEB
							, 0)
							, VALUE(E.OPRCTADEB
							, 0)
							, VALUE(E.NUMCTADEB
							, 0)
							, VALUE(E.DIGCTADEB
							, 0)
							, E.NUM_CARTAO_CREDITO
							FROM SEGUROS.V0PROPOSTAVA A
							JOIN SEGUROS.APOLICES B ON B.NUM_APOLICE = A.NUM_APOLICE
							JOIN SEGUROS.V0PRODUTOSVG D ON D.NUM_APOLICE = A.NUM_APOLICE AND D.CODSUBES = A.CODSUBES
							LEFT JOIN SEGUROS.V0OPCAOPAGVA E ON E.NRCERTIF = A.NRCERTIF AND E.DTINIVIG <= A.DTPROXVEN AND E.DTTERVIG >= A.DTPROXVEN WHERE A.NRCERTIF = '{V0PROP_NRCERTIF}' AND A.DTPROXVEN <= '{V1SIST_DT_18D_UTIL}' AND A.SITUACAO IN ('3'
							,'6') AND B.RAMO_EMISSOR <> 77 AND D.ESTR_COBR = 'MULT' AND D.ORIG_PRODU NOT IN ('EMPRE'
							,'ESPEC'
							,'ESPE1'
							, 'GLOBAL') ORDER BY A.NUM_APOLICE
							, A.CODSUBES
							, A.NRCERTIF";

            return query;
        }


        public VA0853B_CPROPVAG CPROPVAG { get; set; } = new VA0853B_CPROPVAG(true);
        string GetQuery_CPROPVAG()
        {
            var query = @$"SELECT 1
							, A.NUM_APOLICE
							, A.CODSUBES
							, A.NRCERTIF
							, A.CODPRODU
							, A.CODCLIEN
							, A.NRPARCE
							, A.SITUACAO
							, A.DTQITBCO
							, A.DTVENCTO
							, A.DTPROXVEN
							, A.NRPRIPARATZ
							, A.QTDPARATZ
							, VALUE(A.NUM_MATRICULA
							, 0)
							, A.TIMESTAMP
							, A.DTQITBCO + 1 MONTH
							, A.DTQITBCO + 1 YEAR
							, A.CODOPER
							, VALUE(A.DATA_ADMISSAO
							, '2001-01-01')
							, VALUE(D.ESTR_COBR
							, ' ')
							, VALUE(D.ORIG_PRODU
							, ' ')
							, VALUE(D.TEM_SAF
							, 'N')
							, VALUE(D.TEM_CDG
							, 'N')
							, VALUE(D.TEM_IGPM
							, 'N')
							, D.CODPRODAZ
							, D.OPCAOCAP
							, D.COBERADIC_PREMIO
							, D.CUSTOCAP_TOTAL
							, D.OPCAOPAG
							, D.PERIPGTO
							, D.NOMPRODU
							, VALUE(E.OPCAOPAG
							, ' ')
							, VALUE(E.PERIPGTO
							, 0)
							, VALUE(E.DIA_DEBITO
							, 0)
							, VALUE(E.AGECTADEB
							, 0)
							, VALUE(E.OPRCTADEB
							, 0)
							, VALUE(E.NUMCTADEB
							, 0)
							, VALUE(E.DIGCTADEB
							, 0)
							, E.NUM_CARTAO_CREDITO
							FROM SEGUROS.V0PROPOSTAVA A
							JOIN SEGUROS.APOLICES B ON B.NUM_APOLICE = A.NUM_APOLICE
							JOIN SEGUROS.V0PRODUTOSVG D ON D.NUM_APOLICE = A.NUM_APOLICE AND D.CODSUBES = A.CODSUBES
							LEFT JOIN SEGUROS.V0OPCAOPAGVA E ON E.NRCERTIF = A.NRCERTIF AND E.DTINIVIG <= A.DTPROXVEN AND E.DTTERVIG >= A.DTPROXVEN WHERE A.DTPROXVEN BETWEEN '{WHOST_MIN_DTPROXVEN}' AND '{V1SIST_DT_18D_UTIL}' AND A.SITUACAO IN ('3'
							,'6') AND B.RAMO_EMISSOR <> 77 AND D.ESTR_COBR = 'MULT' AND D.ORIG_PRODU NOT IN ('EMPRE'
							,'ESPEC'
							,'ESPE1'
							, 'GLOBAL') UNION SELECT 2
							, A.NUM_APOLICE
							, A.CODSUBES
							, A.NRCERTIF
							, A.CODPRODU
							, A.CODCLIEN
							, A.NRPARCE
							, A.SITUACAO
							, A.DTQITBCO
							, A.DTVENCTO
							, A.DTPROXVEN
							, A.NRPRIPARATZ
							, A.QTDPARATZ
							, VALUE(A.NUM_MATRICULA
							, 0)
							, A.TIMESTAMP
							, A.DTQITBCO + 1 MONTH
							, A.DTQITBCO + 1 YEAR
							, A.CODOPER
							, VALUE(A.DATA_ADMISSAO
							, '2001-01-01')
							, VALUE(D.ESTR_COBR
							, ' ')
							, VALUE(D.ORIG_PRODU
							, ' ')
							, VALUE(D.TEM_SAF
							, 'N')
							, VALUE(D.TEM_CDG
							, 'N')
							, VALUE(D.TEM_IGPM
							, 'N')
							, D.CODPRODAZ
							, D.OPCAOCAP
							, D.COBERADIC_PREMIO
							, D.CUSTOCAP_TOTAL
							, D.OPCAOPAG
							, D.PERIPGTO
							, D.NOMPRODU
							, ' '
							, 0
							, 0
							, 0
							, 0
							, 0
							, 0
							, '0000000000000000'
							FROM SEGUROS.V0PRODUTOSVG D
							JOIN SEGUROS.V0PROPOSTAVA A ON A.NUM_APOLICE = D.NUM_APOLICE AND A.CODSUBES = D.CODSUBES AND A.SITUACAO IN ('3'
							,'6')
							JOIN SEGUROS.V0HISTCOBVA B ON B.NRCERTIF = A.NRCERTIF AND B.NRPARCEL = A.NRPARCE WHERE D.ESTR_COBR = 'MULT' AND D.ORIG_PRODU NOT IN ('EMPRE'
							,'ESPEC'
							,'ESPE1'
							, 'GLOBAL') AND D.PERIPGTO > 1 AND A.DTPROXVEN > '{V1SIST_DT_18D_UTIL}' AND A.SITUACAO IN ('3'
							,'6') AND A.DTVENCTO < '{V1SIST_DTVENFIM_6D_UTIL}' AND B.SITUACAO IN ('0'
							,' '
							,'5'
							,X'00')";

            return query;
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(VA0853B_LK_PARAMETROS VA0853B_LK_PARAMETROS_P, string ARQSAIDA_FILE_NAME_P) //PROCEDURE DIVISION USING 
        /*LK_PARAMETROS*/
        {
            try
            {
                this.LK_PARAMETROS = VA0853B_LK_PARAMETROS_P;
                ARQSAIDA.SetFile(ARQSAIDA_FILE_NAME_P);
                InitializeGetQuery();

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LK_PARAMETROS, CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        public void InitializeGetQuery()
        {
            CPROPVAL.GetQueryEvent += GetQuery_CPROPVAL;
            CPROPVAG.GetQueryEvent += GetQuery_CPROPVAG;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -1445- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1446- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1447- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -1455- PERFORM R0100-00-INICIALIZA-PGM. */

            R0100_00_INICIALIZA_PGM_SECTION();

            /*" -1457- IF (LK-NUM-CERTIFICADO IS NUMERIC) AND (LK-NUM-CERTIFICADO > ZEROS) */

            if ((LK_PARAMETROS.LK_NUM_CERTIFICADO.IsNumeric()) && (LK_PARAMETROS.LK_NUM_CERTIFICADO > 00))
            {

                /*" -1458- PERFORM R0151-00-DECLARE-CRSR-LINK */

                R0151_00_DECLARE_CRSR_LINK_SECTION();

                /*" -1459- ELSE */
            }
            else
            {


                /*" -1460- PERFORM R0152-00-DECLARE-CRSR-GERAL */

                R0152_00_DECLARE_CRSR_GERAL_SECTION();

                /*" -1462- END-IF. */
            }


            /*" -1463- IF (WFIM-CPROPVA NOT EQUAL SPACES) */

            if ((!AREA_DE_WORK.WFIM_CPROPVA.IsEmpty()))
            {

                /*" -1464- DISPLAY '*** VA0853B *** NENHUMA PROPOSTA A PROCESSAR' */
                _.Display($"*** VA0853B *** NENHUMA PROPOSTA A PROCESSAR");

                /*" -1465- MOVE 'A' TO WS-TIPO-MENSAGEM */
                _.Move("A", WS_TIPO_MENSAGEM);

                /*" -1466- MOVE '10001' TO WNR-EXEC-SQL */
                _.Move("10001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -1467- MOVE 301 TO WS-NUM-ERRO */
                _.Move(301, WS_NUM_ERRO);

                /*" -1469- MOVE 'NENHUM CERTIFICADO P/ GERACAO DE PARCELAS NO DIA' TO WS-MSG-DESCRICAO */
                _.Move("NENHUM CERTIFICADO P/ GERACAO DE PARCELAS NO DIA", WS_MSG_DESCRICAO);

                /*" -1470- PERFORM R6000-00-GRAVAR-RELAT-SAIDA */

                R6000_00_GRAVAR_RELAT_SAIDA_SECTION();

                /*" -1471- ELSE */
            }
            else
            {


                /*" -1473- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WFIM-CPROPVA NOT EQUAL SPACES */

                while (!(!AREA_DE_WORK.WFIM_CPROPVA.IsEmpty()))
                {

                    R1000_00_PROCESSA_REGISTRO_SECTION();
                }

                /*" -1475- END-IF. */
            }


            /*" -1477- PERFORM R9000-00-FINALIZA-PGM. */

            R9000_00_FINALIZA_PGM_SECTION();

            /*" -1478- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-INICIALIZA-PGM-SECTION */
        private void R0100_00_INICIALIZA_PGM_SECTION()
        {
            /*" -1487- MOVE 'R0100' TO WNR-EXEC-SQL */
            _.Move("R0100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1489- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1493- INITIALIZE V0HICB-OPCAO-PGTO REG-DET V0PROP-NUM-APOLICE. */
            _.Initialize(
                V0HICB_OPCAO_PGTO
                , REG_DET
                , V0PROP_NUM_APOLICE
            );

            /*" -1495- IF (LK-NUM-CERTIFICADO IS NOT NUMERIC) OR (LK-NUM-CERTIFICADO EQUAL ZEROS) */

            if ((!LK_PARAMETROS.LK_NUM_CERTIFICADO.IsNumeric()) || (LK_PARAMETROS.LK_NUM_CERTIFICADO == 00))
            {

                /*" -1496- MOVE ZEROS TO LK-NUM-CERTIFICADO */
                _.Move(0, LK_PARAMETROS.LK_NUM_CERTIFICADO);

                /*" -1498- END-IF. */
            }


            /*" -1499- IF (LK-OPERACAO NOT EQUAL 'COMMIT' AND 'ROLLBACK' ) */

            if ((!LK_PARAMETROS.LK_OPERACAO.In("COMMIT", "ROLLBACK")))
            {

                /*" -1500- MOVE 'COMMIT' TO LK-OPERACAO */
                _.Move("COMMIT", LK_PARAMETROS.LK_OPERACAO);

                /*" -1502- END-IF. */
            }


            /*" -1503- IF (LK-DT-PROCESSAMENTO EQUAL SPACES) */

            if ((LK_PARAMETROS.LK_DT_PROCESSAMENTO.IsEmpty()))
            {

                /*" -1504- MOVE '0001-01-01' TO LK-DT-PROCESSAMENTO */
                _.Move("0001-01-01", LK_PARAMETROS.LK_DT_PROCESSAMENTO);

                /*" -1506- END-IF. */
            }


            /*" -1507- DISPLAY ' ' */
            _.Display($" ");

            /*" -1508- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -1509- DISPLAY '          PROGRAMA EM EXECUCAO VA0853B          ' */
            _.Display($"          PROGRAMA EM EXECUCAO VA0853B          ");

            /*" -1510- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -1511- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -1512- DISPLAY 'VERSAO V.60: ' FUNCTION WHEN-COMPILED ' - 327863' */

            $"VERSAO V.60: FUNCTION{_.WhenCompiled()} - 327863"
            .Display();

            /*" -1513- DISPLAY ' ' */
            _.Display($" ");

            /*" -1520- DISPLAY 'INICIOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"INICIOU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -1521- DISPLAY '                               ' */
            _.Display($"                               ");

            /*" -1522- DISPLAY '------------------------------------------------' . */
            _.Display($"------------------------------------------------");

            /*" -1523- DISPLAY '--------------  LINKAGE  ENTRADA ---------------' . */
            _.Display($"--------------  LINKAGE  ENTRADA ---------------");

            /*" -1524- DISPLAY '------------------------------------------------' . */
            _.Display($"------------------------------------------------");

            /*" -1525- DISPLAY 'OPERACAO <' LK-OPERACAO '>' */

            $"OPERACAO <{LK_PARAMETROS.LK_OPERACAO}>"
            .Display();

            /*" -1526- DISPLAY 'NUM-CERTIFICADO <' LK-NUM-CERTIFICADO '>' */

            $"NUM-CERTIFICADO <{LK_PARAMETROS.LK_NUM_CERTIFICADO}>"
            .Display();

            /*" -1527- DISPLAY 'DT-PROCESSAMENTO <' LK-DT-PROCESSAMENTO '>' */

            $"DT-PROCESSAMENTO <{LK_PARAMETROS.LK_DT_PROCESSAMENTO}>"
            .Display();

            /*" -1528- DISPLAY '------------------------------------------------' . */
            _.Display($"------------------------------------------------");

            /*" -1530- DISPLAY ' ' */
            _.Display($" ");

            /*" -1537- STRING FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) DELIMITED BY SIZE INTO REG-CABEC-01-HORA END-STRING. */
            #region STRING
            var spl1 = _.CurrentDate("HH") + ":" + _.CurrentDate("mm") + ":" + _.CurrentDate("ss");
            _.Move(spl1, REG_CABEC_01.REG_CABEC_01_HORA);
            #endregion

            /*" -1538- IF (LK-DT-PROCESSAMENTO EQUAL '0001-01-01' ) */

            if ((LK_PARAMETROS.LK_DT_PROCESSAMENTO == "0001-01-01"))
            {

                /*" -1556- PERFORM R0100_00_INICIALIZA_PGM_DB_SELECT_1 */

                R0100_00_INICIALIZA_PGM_DB_SELECT_1();

                /*" -1560- ELSE */
            }
            else
            {


                /*" -1581- PERFORM R0100_00_INICIALIZA_PGM_DB_SELECT_2 */

                R0100_00_INICIALIZA_PGM_DB_SELECT_2();

                /*" -1585- END-IF. */
            }


            /*" -1586- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1587- DISPLAY 'ERRO SELECT V1SISTEMA VA' */
                _.Display($"ERRO SELECT V1SISTEMA VA");

                /*" -1588- MOVE 'X' TO WS-TIPO-MENSAGEM */
                _.Move("X", WS_TIPO_MENSAGEM);

                /*" -1589- MOVE '10101' TO WNR-EXEC-SQL */
                _.Move("10101", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -1591- MOVE 'ERRO NA CONSULTA DA TABELA V1SISTEMA' TO WS-MSG-DESCRICAO */
                _.Move("ERRO NA CONSULTA DA TABELA V1SISTEMA", WS_MSG_DESCRICAO);

                /*" -1592- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1594- END-IF. */
            }


            /*" -1596- PERFORM R0110-00-GERAR-TAB-ERROS. */

            R0110_00_GERAR_TAB_ERROS_SECTION();

            /*" -1598- PERFORM R8100-00-GERAR-ARQSIVPF. */

            R8100_00_GERAR_ARQSIVPF_SECTION();

            /*" -1599- MOVE '0' TO WS-TIPO-MENSAGEM */
            _.Move("0", WS_TIPO_MENSAGEM);

            /*" -1601- PERFORM R8200-00-GERAR-CNTRLE-PROC. */

            R8200_00_GERAR_CNTRLE_PROC_SECTION();

            /*" -1602- MOVE V1SIST-DTHOJE (9:2) TO REG-CABEC-01-DATA (1:2) */
            _.MoveAtPosition(V1SIST_DTHOJE.Substring(9, 2), REG_CABEC_01.REG_CABEC_01_DATA, 1, 2);

            /*" -1603- MOVE V1SIST-DTHOJE (6:2) TO REG-CABEC-01-DATA (4:2) */
            _.MoveAtPosition(V1SIST_DTHOJE.Substring(6, 2), REG_CABEC_01.REG_CABEC_01_DATA, 4, 2);

            /*" -1604- MOVE V1SIST-DTHOJE (1:4) TO REG-CABEC-01-DATA (7:4) */
            _.MoveAtPosition(V1SIST_DTHOJE.Substring(1, 4), REG_CABEC_01.REG_CABEC_01_DATA, 7, 4);

            /*" -1607- MOVE '/' TO REG-CABEC-01-DATA(6:1) */
            _.MoveAtPosition("/", REG_CABEC_01.REG_CABEC_01_DATA, 6, 1);

            /*" -1607- MOVE '/' TO REG-CABEC-01-DATA(3:1) */
            _.MoveAtPosition("/", REG_CABEC_01.REG_CABEC_01_DATA, 3, 1);

            /*" -1608- MOVE V1SIST-DTMOVABE TO WDATA-SQL. */
            _.Move(V1SIST_DTMOVABE, WDATA_SQL);

            /*" -1609- MOVE 8 TO GE0006S-QTDDIAS. */
            _.Move(8, GE0006S_LINKAGE.GE0006S_QTDDIAS);

            /*" -1610- PERFORM R0220-00-VALIDA-DIA-UTIL. */

            R0220_00_VALIDA_DIA_UTIL_SECTION();

            /*" -1612- MOVE WDATA-SQL TO V1SIST-DT-08D-UTIL. */
            _.Move(WDATA_SQL, V1SIST_DT_08D_UTIL);

            /*" -1613- MOVE V1SIST-DT-15D-UTIL TO WDATA-SQL. */
            _.Move(V1SIST_DT_15D_UTIL, WDATA_SQL);

            /*" -1614- MOVE 1 TO GE0006S-QTDDIAS. */
            _.Move(1, GE0006S_LINKAGE.GE0006S_QTDDIAS);

            /*" -1615- PERFORM R0220-00-VALIDA-DIA-UTIL. */

            R0220_00_VALIDA_DIA_UTIL_SECTION();

            /*" -1617- MOVE WDATA-SQL TO V1SIST-DT-15D-UTIL. */
            _.Move(WDATA_SQL, V1SIST_DT_15D_UTIL);

            /*" -1618- MOVE V1SIST-DT-18D-UTIL TO WDATA-SQL. */
            _.Move(V1SIST_DT_18D_UTIL, WDATA_SQL);

            /*" -1619- MOVE 1 TO GE0006S-QTDDIAS. */
            _.Move(1, GE0006S_LINKAGE.GE0006S_QTDDIAS);

            /*" -1620- PERFORM R0220-00-VALIDA-DIA-UTIL. */

            R0220_00_VALIDA_DIA_UTIL_SECTION();

            /*" -1622- MOVE WDATA-SQL TO V1SIST-DT-18D-UTIL. */
            _.Move(WDATA_SQL, V1SIST_DT_18D_UTIL);

            /*" -1624- MOVE '2000-01-01' TO WHOST-MIN-DTPROXVEN. */
            _.Move("2000-01-01", WHOST_MIN_DTPROXVEN);

            /*" -1625- DISPLAY ' ' */
            _.Display($" ");

            /*" -1626- DISPLAY '---------------------------------------' */
            _.Display($"---------------------------------------");

            /*" -1627- DISPLAY 'DATA P/ GERACAO DE PARCELAS ADIMPLENTES' . */
            _.Display($"DATA P/ GERACAO DE PARCELAS ADIMPLENTES");

            /*" -1628- DISPLAY '---------------------------------------' */
            _.Display($"---------------------------------------");

            /*" -1629- DISPLAY 'V1SIST-DTMOVABE........ ' V1SIST-DTMOVABE */
            _.Display($"V1SIST-DTMOVABE........ {V1SIST_DTMOVABE}");

            /*" -1630- DISPLAY 'V1SIST-DT-08D-UTIL..... ' V1SIST-DT-08D-UTIL */
            _.Display($"V1SIST-DT-08D-UTIL..... {V1SIST_DT_08D_UTIL}");

            /*" -1631- DISPLAY 'V1SIST-DT-15D-UTIL..... ' V1SIST-DT-15D-UTIL */
            _.Display($"V1SIST-DT-15D-UTIL..... {V1SIST_DT_15D_UTIL}");

            /*" -1632- DISPLAY 'V1SIST-DT-18D-UTIL..... ' V1SIST-DT-18D-UTIL */
            _.Display($"V1SIST-DT-18D-UTIL..... {V1SIST_DT_18D_UTIL}");

            /*" -1633- DISPLAY 'V1SIST-DTHOJE.......... ' V1SIST-DTHOJE */
            _.Display($"V1SIST-DTHOJE.......... {V1SIST_DTHOJE}");

            /*" -1634- DISPLAY '---------------------------------------' . */
            _.Display($"---------------------------------------");

            /*" -1636- DISPLAY ' ' */
            _.Display($" ");

            /*" -1638- PERFORM R0217-00-GERAR-DATA-ATRASO. */

            R0217_00_GERAR_DATA_ATRASO_SECTION();

            /*" -1640- OPEN OUTPUT ARQSAIDA */
            ARQSAIDA.Open(REG_SAIDA);

            /*" -1641- WRITE REG-SAIDA FROM REG-CABEC-01. */
            _.Move(REG_CABEC_01.GetMoveValues(), REG_SAIDA);

            ARQSAIDA.Write(REG_SAIDA.GetMoveValues().ToString());

            /*" -1643- WRITE REG-SAIDA FROM REG-CABEC-02. */
            _.Move(REG_CABEC_02.GetMoveValues(), REG_SAIDA);

            ARQSAIDA.Write(REG_SAIDA.GetMoveValues().ToString());

            /*" -1644- IF (LK-OPERACAO EQUAL 'COMMIT' ) */

            if ((LK_PARAMETROS.LK_OPERACAO == "COMMIT"))
            {

                /*" -1644- EXEC SQL COMMIT WORK END-EXEC */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -1645- END-IF. */
            }


        }

        [StopWatch]
        /*" R0100-00-INICIALIZA-PGM-DB-SELECT-1 */
        public void R0100_00_INICIALIZA_PGM_DB_SELECT_1()
        {
            /*" -1556- EXEC SQL SELECT DATA_MOV_ABERTO , DATA_MOV_ABERTO + 14 DAYS , DATA_MOV_ABERTO + 17 DAYS , CURRENT DATE , CURRENT DATE , CURRENT DATE - 18 DAYS , DATE(DATA_MOV_ABERTO) - 1 YEAR INTO :V1SIST-DTMOVABE , :V1SIST-DT-15D-UTIL , :V1SIST-DT-18D-UTIL , :V1SIST-DTHOJE , :V1SIST-DTVENFIM-6D-UTIL, :V1SIST-DTVENFIM-CN-GE853S, :V1SIST-DTVENFIM-1Y-GE853S FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VA' WITH UR END-EXEC */

            var r0100_00_INICIALIZA_PGM_DB_SELECT_1_Query1 = new R0100_00_INICIALIZA_PGM_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_INICIALIZA_PGM_DB_SELECT_1_Query1.Execute(r0100_00_INICIALIZA_PGM_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
                _.Move(executed_1.V1SIST_DT_15D_UTIL, V1SIST_DT_15D_UTIL);
                _.Move(executed_1.V1SIST_DT_18D_UTIL, V1SIST_DT_18D_UTIL);
                _.Move(executed_1.V1SIST_DTHOJE, V1SIST_DTHOJE);
                _.Move(executed_1.V1SIST_DTVENFIM_6D_UTIL, V1SIST_DTVENFIM_6D_UTIL);
                _.Move(executed_1.V1SIST_DTVENFIM_CN_GE853S, V1SIST_DTVENFIM_CN_GE853S);
                _.Move(executed_1.V1SIST_DTVENFIM_1Y_GE853S, V1SIST_DTVENFIM_1Y_GE853S);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-INICIALIZA-PGM-DB-SELECT-2 */
        public void R0100_00_INICIALIZA_PGM_DB_SELECT_2()
        {
            /*" -1581- EXEC SQL SELECT DATE(:LK-DT-PROCESSAMENTO) , DATE(:LK-DT-PROCESSAMENTO) + 14 DAYS , DATE(:LK-DT-PROCESSAMENTO) + 17 DAYS , DATE(:LK-DT-PROCESSAMENTO) , DATE(:LK-DT-PROCESSAMENTO) , DATE(:LK-DT-PROCESSAMENTO) - 18 DAYS , DATE(:LK-DT-PROCESSAMENTO) - 1 YEAR INTO :V1SIST-DTMOVABE , :V1SIST-DT-15D-UTIL , :V1SIST-DT-18D-UTIL , :V1SIST-DTHOJE , :V1SIST-DTVENFIM-6D-UTIL, :V1SIST-DTVENFIM-CN-GE853S, :V1SIST-DTVENFIM-1Y-GE853S FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VA' WITH UR END-EXEC */

            var r0100_00_INICIALIZA_PGM_DB_SELECT_2_Query1 = new R0100_00_INICIALIZA_PGM_DB_SELECT_2_Query1()
            {
                LK_DT_PROCESSAMENTO = LK_PARAMETROS.LK_DT_PROCESSAMENTO.ToString(),
            };

            var executed_1 = R0100_00_INICIALIZA_PGM_DB_SELECT_2_Query1.Execute(r0100_00_INICIALIZA_PGM_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
                _.Move(executed_1.V1SIST_DT_15D_UTIL, V1SIST_DT_15D_UTIL);
                _.Move(executed_1.V1SIST_DT_18D_UTIL, V1SIST_DT_18D_UTIL);
                _.Move(executed_1.V1SIST_DTHOJE, V1SIST_DTHOJE);
                _.Move(executed_1.V1SIST_DTVENFIM_6D_UTIL, V1SIST_DTVENFIM_6D_UTIL);
                _.Move(executed_1.V1SIST_DTVENFIM_CN_GE853S, V1SIST_DTVENFIM_CN_GE853S);
                _.Move(executed_1.V1SIST_DTVENFIM_1Y_GE853S, V1SIST_DTVENFIM_1Y_GE853S);
            }


        }

        [StopWatch]
        /*" R0110-00-GERAR-TAB-ERROS-SECTION */
        private void R0110_00_GERAR_TAB_ERROS_SECTION()
        {
            /*" -1656- SET I01 TO 1. */
            I01.Value = 1;

            /*" -1658- PERFORM R0111-00-DECLARE-ERRO-PROC. */

            R0111_00_DECLARE_ERRO_PROC_SECTION();

            /*" -1660- PERFORM R0112-00-FETCH-ERRO-PROC. */

            R0112_00_FETCH_ERRO_PROC_SECTION();

            /*" -1661- IF (W-FIM-ERROS NOT EQUAL SPACES) */

            if ((!W_FIM_ERROS.IsEmpty()))
            {

                /*" -1662- DISPLAY 'R0010 - PROBLEMA NO FETCH ERRO-PROC ' SQLCODE */
                _.Display($"R0010 - PROBLEMA NO FETCH ERRO-PROC {DB.SQLCODE}");

                /*" -1663- MOVE 'X' TO WS-TIPO-MENSAGEM */
                _.Move("X", WS_TIPO_MENSAGEM);

                /*" -1664- MOVE '10111' TO WNR-EXEC-SQL */
                _.Move("10111", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -1666- MOVE 'PROBLEMA NO FETCH ERRO-PROC' TO WS-MSG-DESCRICAO */
                _.Move("PROBLEMA NO FETCH ERRO-PROC", WS_MSG_DESCRICAO);

                /*" -1667- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1669- END-IF. */
            }


            /*" -1670- PERFORM R0113-00-CARREGA-ERRO-PROC UNTIL W-FIM-ERROS EQUAL 'SIM' . */

            while (!(W_FIM_ERROS == "SIM"))
            {

                R0113_00_CARREGA_ERRO_PROC_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0110_SAIDA*/

        [StopWatch]
        /*" R0111-00-DECLARE-ERRO-PROC-SECTION */
        private void R0111_00_DECLARE_ERRO_PROC_SECTION()
        {
            /*" -1685- PERFORM R0111_00_DECLARE_ERRO_PROC_DB_DECLARE_1 */

            R0111_00_DECLARE_ERRO_PROC_DB_DECLARE_1();

            /*" -1687- PERFORM R0111_00_DECLARE_ERRO_PROC_DB_OPEN_1 */

            R0111_00_DECLARE_ERRO_PROC_DB_OPEN_1();

            /*" -1690- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1691- DISPLAY 'ERRO SELECT V1SISTEMA VA' */
                _.Display($"ERRO SELECT V1SISTEMA VA");

                /*" -1692- MOVE 'X' TO WS-TIPO-MENSAGEM */
                _.Move("X", WS_TIPO_MENSAGEM);

                /*" -1693- MOVE '10112' TO WNR-EXEC-SQL */
                _.Move("10112", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -1695- MOVE 'ERRO NA CONSULTA DA TABELA PF_ERRO_PROC_PROPOSTA' TO WS-MSG-DESCRICAO */
                _.Move("ERRO NA CONSULTA DA TABELA PF_ERRO_PROC_PROPOSTA", WS_MSG_DESCRICAO);

                /*" -1696- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1696- END-IF. */
            }


        }

        [StopWatch]
        /*" R0111-00-DECLARE-ERRO-PROC-DB-DECLARE-1 */
        public void R0111_00_DECLARE_ERRO_PROC_DB_DECLARE_1()
        {
            /*" -1685- EXEC SQL DECLARE ERROPROC CURSOR FOR SELECT NUM_ERRO_PROPOSTA, DES_ERRO_PROPOSTA FROM SEGUROS.PF_ERRO_PROC_PROPOSTA ORDER BY NUM_ERRO_PROPOSTA END-EXEC. */
            ERROPROC = new VA0853B_ERROPROC(false);
            string GetQuery_ERROPROC()
            {
                var query = @$"SELECT NUM_ERRO_PROPOSTA
							, 
							DES_ERRO_PROPOSTA 
							FROM SEGUROS.PF_ERRO_PROC_PROPOSTA 
							ORDER BY NUM_ERRO_PROPOSTA";

                return query;
            }
            ERROPROC.GetQueryEvent += GetQuery_ERROPROC;

        }

        [StopWatch]
        /*" R0111-00-DECLARE-ERRO-PROC-DB-OPEN-1 */
        public void R0111_00_DECLARE_ERRO_PROC_DB_OPEN_1()
        {
            /*" -1687- EXEC SQL OPEN ERROPROC END-EXEC. */

            ERROPROC.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0111_SAIDA*/

        [StopWatch]
        /*" R0112-00-FETCH-ERRO-PROC-SECTION */
        private void R0112_00_FETCH_ERRO_PROC_SECTION()
        {
            /*" -1710- PERFORM R0112_00_FETCH_ERRO_PROC_DB_FETCH_1 */

            R0112_00_FETCH_ERRO_PROC_DB_FETCH_1();

            /*" -1713- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1714- IF (SQLCODE EQUAL +100) */

                if ((DB.SQLCODE == +100))
                {

                    /*" -1715- MOVE 'SIM' TO W-FIM-ERROS */
                    _.Move("SIM", W_FIM_ERROS);

                    /*" -1715- PERFORM R0112_00_FETCH_ERRO_PROC_DB_CLOSE_1 */

                    R0112_00_FETCH_ERRO_PROC_DB_CLOSE_1();

                    /*" -1717- ELSE */
                }
                else
                {


                    /*" -1718- DISPLAY 'ERRO SELECT V1SISTEMA VA' */
                    _.Display($"ERRO SELECT V1SISTEMA VA");

                    /*" -1719- MOVE 'X' TO WS-TIPO-MENSAGEM */
                    _.Move("X", WS_TIPO_MENSAGEM);

                    /*" -1720- MOVE '10113' TO WNR-EXEC-SQL */
                    _.Move("10113", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -1722- MOVE 'ERRO NO FETCH DO CURSOR ERROPROC' TO WS-MSG-DESCRICAO */
                    _.Move("ERRO NO FETCH DO CURSOR ERROPROC", WS_MSG_DESCRICAO);

                    /*" -1723- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1724- END-IF */
                }


                /*" -1724- END-IF. */
            }


        }

        [StopWatch]
        /*" R0112-00-FETCH-ERRO-PROC-DB-FETCH-1 */
        public void R0112_00_FETCH_ERRO_PROC_DB_FETCH_1()
        {
            /*" -1710- EXEC SQL FETCH ERROPROC INTO :PF089-NUM-ERRO-PROPOSTA, :PF089-DES-ERRO-PROPOSTA END-EXEC. */

            if (ERROPROC.Fetch())
            {
                _.Move(ERROPROC.PF089_NUM_ERRO_PROPOSTA, PF089.DCLPF_ERRO_PROC_PROPOSTA.PF089_NUM_ERRO_PROPOSTA);
                _.Move(ERROPROC.PF089_DES_ERRO_PROPOSTA, PF089.DCLPF_ERRO_PROC_PROPOSTA.PF089_DES_ERRO_PROPOSTA);
            }

        }

        [StopWatch]
        /*" R0112-00-FETCH-ERRO-PROC-DB-CLOSE-1 */
        public void R0112_00_FETCH_ERRO_PROC_DB_CLOSE_1()
        {
            /*" -1715- EXEC SQL CLOSE ERROPROC END-EXEC */

            ERROPROC.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0112_SAIDA*/

        [StopWatch]
        /*" R0113-00-CARREGA-ERRO-PROC-SECTION */
        private void R0113_00_CARREGA_ERRO_PROC_SECTION()
        {
            /*" -1734- MOVE 'R0113' TO WNR-EXEC-SQL */
            _.Move("R0113", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1737- MOVE SPACES TO W-TB-DESC-ERRO (PF089-NUM-ERRO-PROPOSTA). */
            _.Move("", W_TAB_ERRO.W_TAB_ERRO_REG[PF089.DCLPF_ERRO_PROC_PROPOSTA.PF089_NUM_ERRO_PROPOSTA].W_TB_DESC_ERRO);

            /*" -1741- MOVE PF089-DES-ERRO-PROPOSTA-TEXT (1:PF089-DES-ERRO-PROPOSTA-LEN) TO W-TB-DESC-ERRO (PF089-NUM-ERRO-PROPOSTA). */
            _.Move(PF089.DCLPF_ERRO_PROC_PROPOSTA.PF089_DES_ERRO_PROPOSTA.PF089_DES_ERRO_PROPOSTA_TEXT.Substring(1, PF089.DCLPF_ERRO_PROC_PROPOSTA.PF089_DES_ERRO_PROPOSTA.PF089_DES_ERRO_PROPOSTA_LEN), W_TAB_ERRO.W_TAB_ERRO_REG[PF089.DCLPF_ERRO_PROC_PROPOSTA.PF089_NUM_ERRO_PROPOSTA].W_TB_DESC_ERRO);

            /*" -1743- SET I01 UP BY 1. */
            I01.Value += 1;

            /*" -1743- PERFORM R0112-00-FETCH-ERRO-PROC. */

            R0112_00_FETCH_ERRO_PROC_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0113_SAIDA*/

        [StopWatch]
        /*" R0151-00-DECLARE-CRSR-LINK-SECTION */
        private void R0151_00_DECLARE_CRSR_LINK_SECTION()
        {
            /*" -1752- MOVE 'R0151' TO WNR-EXEC-SQL */
            _.Move("R0151", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1754- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1756- MOVE 'CPROPVAL' TO WS-NOME-CURSOR */
            _.Move("CPROPVAL", WS_NOME_CURSOR);

            /*" -1758- MOVE LK-NUM-CERTIFICADO TO V0PROP-NRCERTIF. */
            _.Move(LK_PARAMETROS.LK_NUM_CERTIFICADO, V0PROP_NRCERTIF);

            /*" -1759- DISPLAY ' ' */
            _.Display($" ");

            /*" -1767- DISPLAY 'VA0853B *** ABRINDO CURSOR LINKAGE...' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"VA0853B *** ABRINDO CURSOR LINKAGE...{_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -1767- PERFORM R0151_00_DECLARE_CRSR_LINK_DB_OPEN_1 */

            R0151_00_DECLARE_CRSR_LINK_DB_OPEN_1();

            /*" -1770- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1771- DISPLAY 'PROBLEMAS NO OPEN (CPROPVAL ) ... ' */
                _.Display($"PROBLEMAS NO OPEN (CPROPVAL ) ... ");

                /*" -1772- MOVE 'F' TO WS-TIPO-MENSAGEM */
                _.Move("F", WS_TIPO_MENSAGEM);

                /*" -1773- MOVE '11511' TO WNR-EXEC-SQL */
                _.Move("11511", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -1775- MOVE 'ERRO NA ABERTURA DO CURSOR  CPROPVAL ' TO WS-MSG-DESCRICAO */
                _.Move("ERRO NA ABERTURA DO CURSOR  CPROPVAL ", WS_MSG_DESCRICAO);

                /*" -1776- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1778- END-IF. */
            }


            /*" -1786- DISPLAY 'VA0853B *** PROCESSANDO CURSOR LINKAGE...' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"VA0853B *** PROCESSANDO CURSOR LINKAGE...{_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -1786- PERFORM R0900-00-FETCH-CPROPVAL. */

            R0900_00_FETCH_CPROPVAL_SECTION();

        }

        [StopWatch]
        /*" R0151-00-DECLARE-CRSR-LINK-DB-OPEN-1 */
        public void R0151_00_DECLARE_CRSR_LINK_DB_OPEN_1()
        {
            /*" -1767- EXEC SQL OPEN CPROPVAL END-EXEC. */

            CPROPVAL.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0151_99_SAIDA*/

        [StopWatch]
        /*" R0152-00-DECLARE-CRSR-GERAL-SECTION */
        private void R0152_00_DECLARE_CRSR_GERAL_SECTION()
        {
            /*" -1795- MOVE 'R0152' TO WNR-EXEC-SQL */
            _.Move("R0152", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1797- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1799- MOVE 'CPROPVAG' TO WS-NOME-CURSOR */
            _.Move("CPROPVAG", WS_NOME_CURSOR);

            /*" -1807- DISPLAY 'VA0853B *** ABRINDO CURSOR GERAL...' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"VA0853B *** ABRINDO CURSOR GERAL...{_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -1807- PERFORM R0152_00_DECLARE_CRSR_GERAL_DB_OPEN_1 */

            R0152_00_DECLARE_CRSR_GERAL_DB_OPEN_1();

            /*" -1810- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1811- DISPLAY 'PROBLEMAS NO OPEN (CPROPVAG  ) ... ' */
                _.Display($"PROBLEMAS NO OPEN (CPROPVAG  ) ... ");

                /*" -1812- MOVE 'F' TO WS-TIPO-MENSAGEM */
                _.Move("F", WS_TIPO_MENSAGEM);

                /*" -1813- MOVE '11521' TO WNR-EXEC-SQL */
                _.Move("11521", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -1815- MOVE 'ERRO NA ABERTURA DO CURSOR  CPROPVAG' TO WS-MSG-DESCRICAO */
                _.Move("ERRO NA ABERTURA DO CURSOR  CPROPVAG", WS_MSG_DESCRICAO);

                /*" -1816- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1818- END-IF. */
            }


            /*" -1826- DISPLAY 'VA0853B *** PROCESSANDO CURSOR GERAL...' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"VA0853B *** PROCESSANDO CURSOR GERAL...{_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -1826- PERFORM R0950-00-FETCH-CPROPVAG. */

            R0950_00_FETCH_CPROPVAG_SECTION();

        }

        [StopWatch]
        /*" R0152-00-DECLARE-CRSR-GERAL-DB-OPEN-1 */
        public void R0152_00_DECLARE_CRSR_GERAL_DB_OPEN_1()
        {
            /*" -1807- EXEC SQL OPEN CPROPVAG END-EXEC. */

            CPROPVAG.Open();

        }

        [StopWatch]
        /*" R1100-00-REENVIAR-PARC-ATRASO-DB-DECLARE-1 */
        public void R1100_00_REENVIAR_PARC_ATRASO_DB_DECLARE_1()
        {
            /*" -2802- EXEC SQL DECLARE CPARCATZ CURSOR FOR SELECT B.NUM_APOLICE , B.NUM_PARCELA , B.DATA_VENCIMENTO , B.VALOR_DEBITO , VALUE(B.COD_RETORNO_CEF, 0) , VALUE(B.STATUS_CARTAO, ' ' ) , C.OCORR_HISTORICOCTA FROM SEGUROS.COBER_HIST_VIDAZUL A, SEGUROS.MOVTO_DEBITOCC_CEF B, SEGUROS.HIST_LANC_CTA C WHERE A.NUM_CERTIFICADO = :V0PROP-NRCERTIF AND A.NUM_PARCELA < :V0PROP-NRPARCEL AND A.NUM_PARCELA >= :WS-NUM-PARCELA-PEND AND A.OPCAO_PAGAMENTO = '5' AND A.SIT_REGISTRO IN ( ' ' , '0' , X'00' ) AND A.NUM_TITULO = B.NUM_APOLICE AND A.NUM_PARCELA = B.NUM_PARCELA AND B.COD_CONVENIO = :HOST-CODCONV AND B.SITUACAO_COBRANCA = '3' AND B.VALOR_DEBITO > 0 AND B.NSAS = (SELECT MAX(T1.NSAS) FROM SEGUROS.MOVTO_DEBITOCC_CEF T1 WHERE T1.NUM_APOLICE = B.NUM_APOLICE AND T1.NUM_PARCELA = B.NUM_PARCELA ) AND A.NUM_CERTIFICADO = C.NUM_CERTIFICADO AND A.NUM_PARCELA = C.NUM_PARCELA AND C.TIPLANC = '1' AND C.NSAS = B.NSAS WITH UR END-EXEC. */
            CPARCATZ = new VA0853B_CPARCATZ(true);
            string GetQuery_CPARCATZ()
            {
                var query = @$"SELECT B.NUM_APOLICE 
							, B.NUM_PARCELA 
							, B.DATA_VENCIMENTO 
							, B.VALOR_DEBITO 
							, VALUE(B.COD_RETORNO_CEF
							, 0) 
							, VALUE(B.STATUS_CARTAO
							, ' ' ) 
							, C.OCORR_HISTORICOCTA 
							FROM SEGUROS.COBER_HIST_VIDAZUL A
							, 
							SEGUROS.MOVTO_DEBITOCC_CEF B
							, 
							SEGUROS.HIST_LANC_CTA C 
							WHERE A.NUM_CERTIFICADO = '{V0PROP_NRCERTIF}' 
							AND A.NUM_PARCELA < '{V0PROP_NRPARCEL}' 
							AND A.NUM_PARCELA >= '{WS_NUM_PARCELA_PEND}' 
							AND A.OPCAO_PAGAMENTO = '5' 
							AND A.SIT_REGISTRO IN ( ' '
							, '0'
							, X'00' ) 
							AND A.NUM_TITULO = B.NUM_APOLICE 
							AND A.NUM_PARCELA = B.NUM_PARCELA 
							AND B.COD_CONVENIO = '{HOST_CODCONV}' 
							AND B.SITUACAO_COBRANCA = '3' 
							AND B.VALOR_DEBITO > 0 
							AND B.NSAS = 
							(SELECT MAX(T1.NSAS) 
							FROM SEGUROS.MOVTO_DEBITOCC_CEF T1 
							WHERE T1.NUM_APOLICE = B.NUM_APOLICE 
							AND T1.NUM_PARCELA = B.NUM_PARCELA 
							) 
							AND A.NUM_CERTIFICADO = C.NUM_CERTIFICADO 
							AND A.NUM_PARCELA = C.NUM_PARCELA 
							AND C.TIPLANC = '1' 
							AND C.NSAS = B.NSAS";

                return query;
            }
            CPARCATZ.GetQueryEvent += GetQuery_CPARCATZ;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0152_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-SOMA-DIAS-SECTION */
        private void R0210_00_SOMA_DIAS_SECTION()
        {
            /*" -1837- MOVE 'R0210' TO WNR-EXEC-SQL */
            _.Move("R0210", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1839- MOVE +1 TO SU1-NRDIAS. */
            _.Move(+1, AREA_DE_WORK.PARM_PROSOMU1.SU1_NRDIAS);

            /*" -1841- CALL 'PROSOCU1' USING PARM-PROSOMU1. */
            _.Call("PROSOCU1", AREA_DE_WORK.PARM_PROSOMU1);

            /*" -1841- MOVE SU1-DATA2 TO SU1-DATA1. */
            _.Move(AREA_DE_WORK.PARM_PROSOMU1.SU1_DATA2, AREA_DE_WORK.PARM_PROSOMU1.SU1_DATA1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/

        [StopWatch]
        /*" R0215-00-SOMA-DIAS-SECTION */
        private void R0215_00_SOMA_DIAS_SECTION()
        {
            /*" -1851- MOVE 'R0215' TO WNR-EXEC-SQL */
            _.Move("R0215", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1853- MOVE +1 TO SU1-NRDIAS. */
            _.Move(+1, AREA_DE_WORK.PARM_PROSOMU1.SU1_NRDIAS);

            /*" -1855- CALL 'PROSOCU1' USING PARM-PROSOMU1. */
            _.Call("PROSOCU1", AREA_DE_WORK.PARM_PROSOMU1);

            /*" -1856- MOVE SU1-DATA2 TO SU1-DATA1. */
            _.Move(AREA_DE_WORK.PARM_PROSOMU1.SU1_DATA2, AREA_DE_WORK.PARM_PROSOMU1.SU1_DATA1);

            /*" -1857- MOVE SU1-DD2 TO WDATA-DDATR. */
            _.Move(AREA_DE_WORK.PARM_PROSOMU1.SU1_DATA2.SU1_DD2, AREA_DE_WORK.WDATA_MINATR.WDATA_DDATR);

            /*" -1858- MOVE SU1-MM2 TO WDATA-MMATR. */
            _.Move(AREA_DE_WORK.PARM_PROSOMU1.SU1_DATA2.SU1_MM2, AREA_DE_WORK.WDATA_MINATR.WDATA_MMATR);

            /*" -1860- MOVE SU1-AA2 TO WDATA-AAATR. */
            _.Move(AREA_DE_WORK.PARM_PROSOMU1.SU1_DATA2.SU1_AA2, AREA_DE_WORK.WDATA_MINATR.WDATA_SAATR_R.WDATA_AAATR);

            /*" -1861- COMPUTE WIND-DATA = WIND-DATA + 1. */
            AREA_DE_WORK.WIND_DATA.Value = AREA_DE_WORK.WIND_DATA + 1;

            /*" -1861- MOVE WDATA-MINATR TO WTAB-DATATR (WIND-DATA). */
            _.Move(AREA_DE_WORK.WDATA_MINATR, AREA_DE_WORK.WTAB_DATAS_UTEIS.WTAB_DATATR[AREA_DE_WORK.WIND_DATA]);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0215_99_SAIDA*/

        [StopWatch]
        /*" R0217-00-GERAR-DATA-ATRASO-SECTION */
        private void R0217_00_GERAR_DATA_ATRASO_SECTION()
        {
            /*" -1871- MOVE 'R0217' TO WNR-EXEC-SQL */
            _.Move("R0217", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1873- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1879- MOVE V1SIST-DTVENFIM-6D-UTIL TO WDATA-CORRENTE. */
            _.Move(V1SIST_DTVENFIM_6D_UTIL, AREA_DE_WORK.WDATA_CORRENTE);

            /*" -1880- MOVE V1SIST-DTVENFIM-6D-UTIL TO WDATA-MINVEN. */
            _.Move(V1SIST_DTVENFIM_6D_UTIL, AREA_DE_WORK.WDATA_MINVEN);

            /*" -1881- MOVE WDATA-DDVEN TO SU1-DD1. */
            _.Move(AREA_DE_WORK.WDATA_MINVEN.WDATA_DDVEN, AREA_DE_WORK.PARM_PROSOMU1.SU1_DATA1.SU1_DD1);

            /*" -1882- MOVE WDATA-MMVEN TO SU1-MM1. */
            _.Move(AREA_DE_WORK.WDATA_MINVEN.WDATA_MMVEN, AREA_DE_WORK.PARM_PROSOMU1.SU1_DATA1.SU1_MM1);

            /*" -1883- MOVE WDATA-AAVEN TO SU1-AA1. */
            _.Move(AREA_DE_WORK.WDATA_MINVEN.WDATA_SAVEN_R.WDATA_AAVEN, AREA_DE_WORK.PARM_PROSOMU1.SU1_DATA1.SU1_AA1);

            /*" -1884- MOVE ZEROES TO SU1-DATA2. */
            _.Move(0, AREA_DE_WORK.PARM_PROSOMU1.SU1_DATA2);

            /*" -1885- PERFORM R0210-00-SOMA-DIAS 6 TIMES. */

            for (int i = 0; i < 6; i++)
            {

                R0210_00_SOMA_DIAS_SECTION();

            }

            /*" -1886- MOVE SU1-DD2 TO WDATA-DDVEN. */
            _.Move(AREA_DE_WORK.PARM_PROSOMU1.SU1_DATA2.SU1_DD2, AREA_DE_WORK.WDATA_MINVEN.WDATA_DDVEN);

            /*" -1888- MOVE SU1-MM2 TO WDATA-MMVEN. */
            _.Move(AREA_DE_WORK.PARM_PROSOMU1.SU1_DATA2.SU1_MM2, AREA_DE_WORK.WDATA_MINVEN.WDATA_MMVEN);

            /*" -1894- MOVE WDATA-MINVEN TO V1SIST-DTVENFIM-6D-UTIL. */
            _.Move(AREA_DE_WORK.WDATA_MINVEN, V1SIST_DTVENFIM_6D_UTIL);

            /*" -1895- MOVE V1SIST-DTVENFIM-CN-GE853S TO WDATA-MINATR. */
            _.Move(V1SIST_DTVENFIM_CN_GE853S, AREA_DE_WORK.WDATA_MINATR);

            /*" -1896- MOVE WDATA-DDATR TO SU1-DD1. */
            _.Move(AREA_DE_WORK.WDATA_MINATR.WDATA_DDATR, AREA_DE_WORK.PARM_PROSOMU1.SU1_DATA1.SU1_DD1);

            /*" -1897- MOVE WDATA-MMATR TO SU1-MM1. */
            _.Move(AREA_DE_WORK.WDATA_MINATR.WDATA_MMATR, AREA_DE_WORK.PARM_PROSOMU1.SU1_DATA1.SU1_MM1);

            /*" -1898- MOVE WDATA-AAATR TO SU1-AA1. */
            _.Move(AREA_DE_WORK.WDATA_MINATR.WDATA_SAATR_R.WDATA_AAATR, AREA_DE_WORK.PARM_PROSOMU1.SU1_DATA1.SU1_AA1);

            /*" -1899- MOVE ZEROES TO SU1-DATA2. */
            _.Move(0, AREA_DE_WORK.PARM_PROSOMU1.SU1_DATA2);

            /*" -1901- MOVE 0 TO WIND-DATA. */
            _.Move(0, AREA_DE_WORK.WIND_DATA);

            /*" -1904- PERFORM R0215-00-SOMA-DIAS UNTIL WDATA-MINATR NOT LESS WDATA-CORRENTE. */

            while (!(AREA_DE_WORK.WDATA_MINATR >= AREA_DE_WORK.WDATA_CORRENTE))
            {

                R0215_00_SOMA_DIAS_SECTION();
            }

            /*" -1905- IF WDATA-MINATR > WDATA-CORRENTE */

            if (AREA_DE_WORK.WDATA_MINATR > AREA_DE_WORK.WDATA_CORRENTE)
            {

                /*" -1906- COMPUTE WIND-DATA = WIND-DATA - 1 */
                AREA_DE_WORK.WIND_DATA.Value = AREA_DE_WORK.WIND_DATA - 1;

                /*" -1908- END-IF. */
            }


            /*" -1924- IF V0PROP-CODPRODU EQUAL 9360 OR 9321 OR 9319 OR 9355 OR 9328 OR 9357 OR JVPROD(9360) OR JVPROD(9328) OR JVPROD(9321) OR JVPROD(9357) OR 8208 OR 8209 OR 9323 OR 9324 OR 9325 OR 9326 OR 9343 OR 9344 OR 9352 OR 9360 OR 9705 OR 9713 OR 9715 OR JVPROD(8209) OR JVPROD(9343) OR JVPROD(9352) OR JVPROD(9360) */

            if (V0PROP_CODPRODU.In("9360", "9321", "9319", "9355", "9328", "9357", JVBKINCL.FILLER.JVPROD[9360].ToString(), JVBKINCL.FILLER.JVPROD[9328].ToString(), JVBKINCL.FILLER.JVPROD[9321].ToString(), JVBKINCL.FILLER.JVPROD[9357].ToString(), "8208", "8209", "9323", "9324", "9325", "9326", "9343", "9344", "9352", "9360", "9705", "9713", "9715", JVBKINCL.FILLER.JVPROD[8209].ToString(), JVBKINCL.FILLER.JVPROD[9343].ToString(), JVBKINCL.FILLER.JVPROD[9352].ToString(), JVBKINCL.FILLER.JVPROD[9360].ToString()))
            {

                /*" -1925- COMPUTE WIND-DATA = WIND-DATA - 10 */
                AREA_DE_WORK.WIND_DATA.Value = AREA_DE_WORK.WIND_DATA - 10;

                /*" -1926- ELSE */
            }
            else
            {


                /*" -1927- COMPUTE WIND-DATA = WIND-DATA - 6 */
                AREA_DE_WORK.WIND_DATA.Value = AREA_DE_WORK.WIND_DATA - 6;

                /*" -1929- END-IF */
            }


            /*" -1931- MOVE WTAB-DATATR (WIND-DATA) TO WDATA-MINATR. */
            _.Move(AREA_DE_WORK.WTAB_DATAS_UTEIS.WTAB_DATATR[AREA_DE_WORK.WIND_DATA], AREA_DE_WORK.WDATA_MINATR);

            /*" -1933- MOVE WDATA-MINATR TO V1SIST-DTVENFIM-CN-GE853S. */
            _.Move(AREA_DE_WORK.WDATA_MINATR, V1SIST_DTVENFIM_CN_GE853S);

            /*" -1934- DISPLAY '---------------------------------------' */
            _.Display($"---------------------------------------");

            /*" -1935- DISPLAY 'DATA PARA GERACAO DE PARCELAS EM ATRASO' . */
            _.Display($"DATA PARA GERACAO DE PARCELAS EM ATRASO");

            /*" -1936- DISPLAY '---------------------------------------' */
            _.Display($"---------------------------------------");

            /*" -1937- DISPLAY 'DT ATUAL............... ' WDATA-CORRENTE. */
            _.Display($"DT ATUAL............... {AREA_DE_WORK.WDATA_CORRENTE}");

            /*" -1938- DISPLAY 'DT MINIMA P/ COBRANCA.. ' V1SIST-DTVENFIM-6D-UTIL */
            _.Display($"DT MINIMA P/ COBRANCA.. {V1SIST_DTVENFIM_6D_UTIL}");

            /*" -1939- DISPLAY 'DT LIMITE P/ CANCELAR.. ' V1SIST-DTVENFIM-1Y-GE853S */
            _.Display($"DT LIMITE P/ CANCELAR.. {V1SIST_DTVENFIM_1Y_GE853S}");

            /*" -1940- DISPLAY 'DT MINIMA P/ ATRASO.... ' V1SIST-DTVENFIM-CN-GE853S */
            _.Display($"DT MINIMA P/ ATRASO.... {V1SIST_DTVENFIM_CN_GE853S}");

            /*" -1940- DISPLAY '---------------------------------------' . */
            _.Display($"---------------------------------------");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0217_99_SAIDA*/

        [StopWatch]
        /*" R0220-00-VALIDA-DIA-UTIL-SECTION */
        private void R0220_00_VALIDA_DIA_UTIL_SECTION()
        {
            /*" -1950- MOVE 'R0220' TO WNR-EXEC-SQL. */
            _.Move("R0220", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1952- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1954- MOVE WDATA-SQL TO GE0006S-DATA-DESTINO. */
            _.Move(WDATA_SQL, GE0006S_LINKAGE.GE0006S_DATA_DESTINO);

            /*" -1956- MOVE SPACES TO GE0006S-MENSAGEM. */
            _.Move("", GE0006S_LINKAGE.GE0006S_MENSAGEM);

            /*" -1958- CALL 'GE0006S' USING GE0006S-LINKAGE. */
            _.Call("GE0006S", GE0006S_LINKAGE);

            /*" -1959- IF GE0006S-MENSAGEM EQUAL SPACES */

            if (GE0006S_LINKAGE.GE0006S_MENSAGEM.IsEmpty())
            {

                /*" -1960- MOVE GE0006S-DATA-DESTINO TO WDATA-SQL */
                _.Move(GE0006S_LINKAGE.GE0006S_DATA_DESTINO, WDATA_SQL);

                /*" -1961- ELSE */
            }
            else
            {


                /*" -1962- DISPLAY 'PROBLEMA NA ROTINA GE0006S' */
                _.Display($"PROBLEMA NA ROTINA GE0006S");

                /*" -1963- DISPLAY 'MENSAGEM -->' GE0006S-MENSAGEM */
                _.Display($"MENSAGEM -->{GE0006S_LINKAGE.GE0006S_MENSAGEM}");

                /*" -1964- MOVE 'F' TO WS-TIPO-MENSAGEM */
                _.Move("F", WS_TIPO_MENSAGEM);

                /*" -1965- MOVE '10221' TO WNR-EXEC-SQL */
                _.Move("10221", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -1967- MOVE 'PROBLEMA NA CHAMADA DA SUBROTINA GE0006S' TO WS-MSG-DESCRICAO */
                _.Move("PROBLEMA NA CHAMADA DA SUBROTINA GE0006S", WS_MSG_DESCRICAO);

                /*" -1968- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1968- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-FETCH-CPROPVAL-SECTION */
        private void R0900_00_FETCH_CPROPVAL_SECTION()
        {
            /*" -1978- MOVE '19000' TO WNR-EXEC-SQL. */
            _.Move("19000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2019- PERFORM R0900_00_FETCH_CPROPVAL_DB_FETCH_1 */

            R0900_00_FETCH_CPROPVAL_DB_FETCH_1();

            /*" -2022- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -2023- IF (SQLCODE EQUAL +100) */

                if ((DB.SQLCODE == +100))
                {

                    /*" -2023- PERFORM R0900_00_FETCH_CPROPVAL_DB_CLOSE_1 */

                    R0900_00_FETCH_CPROPVAL_DB_CLOSE_1();

                    /*" -2025- MOVE 'S' TO WFIM-CPROPVA */
                    _.Move("S", AREA_DE_WORK.WFIM_CPROPVA);

                    /*" -2026- GO TO R0900-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/ //GOTO
                    return;

                    /*" -2027- ELSE */
                }
                else
                {


                    /*" -2028- DISPLAY 'R0910-00 (ERRO -  FETCH CPROPVAL )...' */
                    _.Display($"R0910-00 (ERRO -  FETCH CPROPVAL )...");

                    /*" -2029- MOVE 'F' TO WS-TIPO-MENSAGEM */
                    _.Move("F", WS_TIPO_MENSAGEM);

                    /*" -2030- MOVE '19100' TO WNR-EXEC-SQL */
                    _.Move("19100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -2032- MOVE 'ERRO NA CONSULTA DO CURSOR CPROPVAL' TO WS-MSG-DESCRICAO */
                    _.Move("ERRO NA CONSULTA DO CURSOR CPROPVAL", WS_MSG_DESCRICAO);

                    /*" -2033- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2034- END-IF */
                }


                /*" -2036- END-IF. */
            }


            /*" -2040- ADD 1 TO WACC-LIDOS WACC-CONTA WACC-COMMIT. */
            AREA_DE_WORK.WACC_LIDOS.Value = AREA_DE_WORK.WACC_LIDOS + 1;
            AREA_DE_WORK.WACC_CONTA.Value = AREA_DE_WORK.WACC_CONTA + 1;
            AREA_DE_WORK.WACC_COMMIT.Value = AREA_DE_WORK.WACC_COMMIT + 1;

            /*" -2041- IF (WACC-CONTA > 9999) */

            if ((AREA_DE_WORK.WACC_CONTA > 9999))
            {

                /*" -2043- MOVE 1 TO WACC-CONTA */
                _.Move(1, AREA_DE_WORK.WACC_CONTA);

                /*" -2044- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_TIME);

                /*" -2046- DISPLAY 'LIDOS CPROPVAL ........ ' ' ' WACC-LIDOS ' ' V0PROP-NRCERTIF ' ' WS-TIME */

                $"LIDOS CPROPVAL ........  {AREA_DE_WORK.WACC_LIDOS} {V0PROP_NRCERTIF} {AREA_DE_WORK.WS_TIME}"
                .Display();

                /*" -2046- END-IF. */
            }


        }

        [StopWatch]
        /*" R0900-00-FETCH-CPROPVAL-DB-FETCH-1 */
        public void R0900_00_FETCH_CPROPVAL_DB_FETCH_1()
        {
            /*" -2019- EXEC SQL FETCH CPROPVAL INTO :WS-TIPO-PROCESSAMENTO, :V0PROP-NUM-APOLICE, :V0PROP-CODSUBES, :V0PROP-NRCERTIF, :V0PROP-CODPRODU, :V0PROP-CODCLIEN, :V0PROP-NRPARCEL, :V0PROP-SITUACAO, :V0PROP-DTQITBCO, :V0PROP-DTVENCTO, :V0PROP-DTPROXVEN, :V0PROP-NRPRIPARATZ, :V0PROP-QTDPARATZ, :V0PROP-NRMATRFUN, :V0PROP-TIMESTAMP, :V0PROP-DTMINVEN, :V0PROP-DTQITBCO-1YEAR, :V0PROP-CODOPER, :V0PROP-DTADMISSAO, :V0PRDVG-ESTR-COBR, :V0PRDVG-ORIG-PRODU, :V0PRDVG-TEM-SAF, :V0PRDVG-TEM-CDG, :V0PRDVG-TEM-IGPM, :V0PRDVG-CODPRODAZ, :V0PRDVG-OPCAOCAP, :V0PRDVG-COBERADIC-PREMIO, :V0PRDVG-CUSTOCAP-TOTAL, :V0PRDVG-OPCAOPAG, :V0PRDVG-PERIPGTO, :V0PRDVG-NOMPRODU, :V0OPCP-OPCAOPAG, :V0OPCP-PERIPGTO, :V0OPCP-DIA-DEBITO, :V0OPCP-AGECTADEB, :V0OPCP-OPRCTADEB, :V0OPCP-NUMCTADEB, :V0OPCP-DIGCTADEB, :V0OPCP-CARTAO-CRED:VIND-CCRE END-EXEC. */

            if (CPROPVAL.Fetch())
            {
                _.Move(CPROPVAL.WS_TIPO_PROCESSAMENTO, WS_TIPO_PROCESSAMENTO);
                _.Move(CPROPVAL.V0PROP_NUM_APOLICE, V0PROP_NUM_APOLICE);
                _.Move(CPROPVAL.V0PROP_CODSUBES, V0PROP_CODSUBES);
                _.Move(CPROPVAL.V0PROP_NRCERTIF, V0PROP_NRCERTIF);
                _.Move(CPROPVAL.V0PROP_CODPRODU, V0PROP_CODPRODU);
                _.Move(CPROPVAL.V0PROP_CODCLIEN, V0PROP_CODCLIEN);
                _.Move(CPROPVAL.V0PROP_NRPARCEL, V0PROP_NRPARCEL);
                _.Move(CPROPVAL.V0PROP_SITUACAO, V0PROP_SITUACAO);
                _.Move(CPROPVAL.V0PROP_DTQITBCO, V0PROP_DTQITBCO);
                _.Move(CPROPVAL.V0PROP_DTVENCTO, V0PROP_DTVENCTO);
                _.Move(CPROPVAL.V0PROP_DTPROXVEN, V0PROP_DTPROXVEN);
                _.Move(CPROPVAL.V0PROP_NRPRIPARATZ, V0PROP_NRPRIPARATZ);
                _.Move(CPROPVAL.V0PROP_QTDPARATZ, V0PROP_QTDPARATZ);
                _.Move(CPROPVAL.V0PROP_NRMATRFUN, V0PROP_NRMATRFUN);
                _.Move(CPROPVAL.V0PROP_TIMESTAMP, V0PROP_TIMESTAMP);
                _.Move(CPROPVAL.V0PROP_DTMINVEN, V0PROP_DTMINVEN);
                _.Move(CPROPVAL.V0PROP_DTQITBCO_1YEAR, V0PROP_DTQITBCO_1YEAR);
                _.Move(CPROPVAL.V0PROP_CODOPER, V0PROP_CODOPER);
                _.Move(CPROPVAL.V0PROP_DTADMISSAO, V0PROP_DTADMISSAO);
                _.Move(CPROPVAL.V0PRDVG_ESTR_COBR, V0PRDVG_ESTR_COBR);
                _.Move(CPROPVAL.V0PRDVG_ORIG_PRODU, V0PRDVG_ORIG_PRODU);
                _.Move(CPROPVAL.V0PRDVG_TEM_SAF, V0PRDVG_TEM_SAF);
                _.Move(CPROPVAL.V0PRDVG_TEM_CDG, V0PRDVG_TEM_CDG);
                _.Move(CPROPVAL.V0PRDVG_TEM_IGPM, V0PRDVG_TEM_IGPM);
                _.Move(CPROPVAL.V0PRDVG_CODPRODAZ, V0PRDVG_CODPRODAZ);
                _.Move(CPROPVAL.V0PRDVG_OPCAOCAP, V0PRDVG_OPCAOCAP);
                _.Move(CPROPVAL.V0PRDVG_COBERADIC_PREMIO, V0PRDVG_COBERADIC_PREMIO);
                _.Move(CPROPVAL.V0PRDVG_CUSTOCAP_TOTAL, V0PRDVG_CUSTOCAP_TOTAL);
                _.Move(CPROPVAL.V0PRDVG_OPCAOPAG, V0PRDVG_OPCAOPAG);
                _.Move(CPROPVAL.V0PRDVG_PERIPGTO, V0PRDVG_PERIPGTO);
                _.Move(CPROPVAL.V0PRDVG_NOMPRODU, V0PRDVG_NOMPRODU);
                _.Move(CPROPVAL.V0OPCP_OPCAOPAG, V0OPCP_OPCAOPAG);
                _.Move(CPROPVAL.V0OPCP_PERIPGTO, V0OPCP_PERIPGTO);
                _.Move(CPROPVAL.V0OPCP_DIA_DEBITO, V0OPCP_DIA_DEBITO);
                _.Move(CPROPVAL.V0OPCP_AGECTADEB, V0OPCP_AGECTADEB);
                _.Move(CPROPVAL.V0OPCP_OPRCTADEB, V0OPCP_OPRCTADEB);
                _.Move(CPROPVAL.V0OPCP_NUMCTADEB, V0OPCP_NUMCTADEB);
                _.Move(CPROPVAL.V0OPCP_DIGCTADEB, V0OPCP_DIGCTADEB);
                _.Move(CPROPVAL.V0OPCP_CARTAO_CRED, V0OPCP_CARTAO_CRED);
                _.Move(CPROPVAL.VIND_CCRE, VIND_CCRE);
            }

        }

        [StopWatch]
        /*" R0900-00-FETCH-CPROPVAL-DB-CLOSE-1 */
        public void R0900_00_FETCH_CPROPVAL_DB_CLOSE_1()
        {
            /*" -2023- EXEC SQL CLOSE CPROPVAL END-EXEC */

            CPROPVAL.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0950-00-FETCH-CPROPVAG-SECTION */
        private void R0950_00_FETCH_CPROPVAG_SECTION()
        {
            /*" -2056- MOVE 'R9500' TO WNR-EXEC-SQL. */
            _.Move("R9500", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2058- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2099- PERFORM R0950_00_FETCH_CPROPVAG_DB_FETCH_1 */

            R0950_00_FETCH_CPROPVAG_DB_FETCH_1();

            /*" -2102- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -2103- IF (SQLCODE EQUAL +100) */

                if ((DB.SQLCODE == +100))
                {

                    /*" -2103- PERFORM R0950_00_FETCH_CPROPVAG_DB_CLOSE_1 */

                    R0950_00_FETCH_CPROPVAG_DB_CLOSE_1();

                    /*" -2105- MOVE 'S' TO WFIM-CPROPVA */
                    _.Move("S", AREA_DE_WORK.WFIM_CPROPVA);

                    /*" -2106- GO TO R0950-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0950_99_SAIDA*/ //GOTO
                    return;

                    /*" -2107- ELSE */
                }
                else
                {


                    /*" -2108- DISPLAY 'R0950-00 (ERRO -  FETCH CPROPVAG )...' */
                    _.Display($"R0950-00 (ERRO -  FETCH CPROPVAG )...");

                    /*" -2109- MOVE 'F' TO WS-TIPO-MENSAGEM */
                    _.Move("F", WS_TIPO_MENSAGEM);

                    /*" -2110- MOVE '19500' TO WNR-EXEC-SQL */
                    _.Move("19500", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -2112- MOVE 'ERRO NA CONSULTA DO CURSOR CPROPVAG' TO WS-MSG-DESCRICAO */
                    _.Move("ERRO NA CONSULTA DO CURSOR CPROPVAG", WS_MSG_DESCRICAO);

                    /*" -2113- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2114- END-IF */
                }


                /*" -2116- END-IF. */
            }


            /*" -2120- ADD 1 TO WACC-LIDOS WACC-CONTA WACC-COMMIT. */
            AREA_DE_WORK.WACC_LIDOS.Value = AREA_DE_WORK.WACC_LIDOS + 1;
            AREA_DE_WORK.WACC_CONTA.Value = AREA_DE_WORK.WACC_CONTA + 1;
            AREA_DE_WORK.WACC_COMMIT.Value = AREA_DE_WORK.WACC_COMMIT + 1;

            /*" -2121- IF (WACC-CONTA > 9999) */

            if ((AREA_DE_WORK.WACC_CONTA > 9999))
            {

                /*" -2123- MOVE 1 TO WACC-CONTA */
                _.Move(1, AREA_DE_WORK.WACC_CONTA);

                /*" -2124- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_TIME);

                /*" -2126- DISPLAY 'LIDOS CPROPVAG ........ ' ' ' WACC-LIDOS ' ' V0PROP-NRCERTIF ' ' WS-TIME */

                $"LIDOS CPROPVAG ........  {AREA_DE_WORK.WACC_LIDOS} {V0PROP_NRCERTIF} {AREA_DE_WORK.WS_TIME}"
                .Display();

                /*" -2126- END-IF. */
            }


        }

        [StopWatch]
        /*" R0950-00-FETCH-CPROPVAG-DB-FETCH-1 */
        public void R0950_00_FETCH_CPROPVAG_DB_FETCH_1()
        {
            /*" -2099- EXEC SQL FETCH CPROPVAG INTO :WS-TIPO-PROCESSAMENTO, :V0PROP-NUM-APOLICE, :V0PROP-CODSUBES, :V0PROP-NRCERTIF, :V0PROP-CODPRODU, :V0PROP-CODCLIEN, :V0PROP-NRPARCEL, :V0PROP-SITUACAO, :V0PROP-DTQITBCO, :V0PROP-DTVENCTO, :V0PROP-DTPROXVEN, :V0PROP-NRPRIPARATZ, :V0PROP-QTDPARATZ, :V0PROP-NRMATRFUN, :V0PROP-TIMESTAMP, :V0PROP-DTMINVEN, :V0PROP-DTQITBCO-1YEAR, :V0PROP-CODOPER, :V0PROP-DTADMISSAO, :V0PRDVG-ESTR-COBR, :V0PRDVG-ORIG-PRODU, :V0PRDVG-TEM-SAF, :V0PRDVG-TEM-CDG, :V0PRDVG-TEM-IGPM, :V0PRDVG-CODPRODAZ, :V0PRDVG-OPCAOCAP, :V0PRDVG-COBERADIC-PREMIO, :V0PRDVG-CUSTOCAP-TOTAL, :V0PRDVG-OPCAOPAG, :V0PRDVG-PERIPGTO, :V0PRDVG-NOMPRODU, :V0OPCP-OPCAOPAG, :V0OPCP-PERIPGTO, :V0OPCP-DIA-DEBITO, :V0OPCP-AGECTADEB, :V0OPCP-OPRCTADEB, :V0OPCP-NUMCTADEB, :V0OPCP-DIGCTADEB, :V0OPCP-CARTAO-CRED:VIND-CCRE END-EXEC. */

            if (CPROPVAG.Fetch())
            {
                _.Move(CPROPVAG.WS_TIPO_PROCESSAMENTO, WS_TIPO_PROCESSAMENTO);
                _.Move(CPROPVAG.V0PROP_NUM_APOLICE, V0PROP_NUM_APOLICE);
                _.Move(CPROPVAG.V0PROP_CODSUBES, V0PROP_CODSUBES);
                _.Move(CPROPVAG.V0PROP_NRCERTIF, V0PROP_NRCERTIF);
                _.Move(CPROPVAG.V0PROP_CODPRODU, V0PROP_CODPRODU);
                _.Move(CPROPVAG.V0PROP_CODCLIEN, V0PROP_CODCLIEN);
                _.Move(CPROPVAG.V0PROP_NRPARCEL, V0PROP_NRPARCEL);
                _.Move(CPROPVAG.V0PROP_SITUACAO, V0PROP_SITUACAO);
                _.Move(CPROPVAG.V0PROP_DTQITBCO, V0PROP_DTQITBCO);
                _.Move(CPROPVAG.V0PROP_DTVENCTO, V0PROP_DTVENCTO);
                _.Move(CPROPVAG.V0PROP_DTPROXVEN, V0PROP_DTPROXVEN);
                _.Move(CPROPVAG.V0PROP_NRPRIPARATZ, V0PROP_NRPRIPARATZ);
                _.Move(CPROPVAG.V0PROP_QTDPARATZ, V0PROP_QTDPARATZ);
                _.Move(CPROPVAG.V0PROP_NRMATRFUN, V0PROP_NRMATRFUN);
                _.Move(CPROPVAG.V0PROP_TIMESTAMP, V0PROP_TIMESTAMP);
                _.Move(CPROPVAG.V0PROP_DTMINVEN, V0PROP_DTMINVEN);
                _.Move(CPROPVAG.V0PROP_DTQITBCO_1YEAR, V0PROP_DTQITBCO_1YEAR);
                _.Move(CPROPVAG.V0PROP_CODOPER, V0PROP_CODOPER);
                _.Move(CPROPVAG.V0PROP_DTADMISSAO, V0PROP_DTADMISSAO);
                _.Move(CPROPVAG.V0PRDVG_ESTR_COBR, V0PRDVG_ESTR_COBR);
                _.Move(CPROPVAG.V0PRDVG_ORIG_PRODU, V0PRDVG_ORIG_PRODU);
                _.Move(CPROPVAG.V0PRDVG_TEM_SAF, V0PRDVG_TEM_SAF);
                _.Move(CPROPVAG.V0PRDVG_TEM_CDG, V0PRDVG_TEM_CDG);
                _.Move(CPROPVAG.V0PRDVG_TEM_IGPM, V0PRDVG_TEM_IGPM);
                _.Move(CPROPVAG.V0PRDVG_CODPRODAZ, V0PRDVG_CODPRODAZ);
                _.Move(CPROPVAG.V0PRDVG_OPCAOCAP, V0PRDVG_OPCAOCAP);
                _.Move(CPROPVAG.V0PRDVG_COBERADIC_PREMIO, V0PRDVG_COBERADIC_PREMIO);
                _.Move(CPROPVAG.V0PRDVG_CUSTOCAP_TOTAL, V0PRDVG_CUSTOCAP_TOTAL);
                _.Move(CPROPVAG.V0PRDVG_OPCAOPAG, V0PRDVG_OPCAOPAG);
                _.Move(CPROPVAG.V0PRDVG_PERIPGTO, V0PRDVG_PERIPGTO);
                _.Move(CPROPVAG.V0PRDVG_NOMPRODU, V0PRDVG_NOMPRODU);
                _.Move(CPROPVAG.V0OPCP_OPCAOPAG, V0OPCP_OPCAOPAG);
                _.Move(CPROPVAG.V0OPCP_PERIPGTO, V0OPCP_PERIPGTO);
                _.Move(CPROPVAG.V0OPCP_DIA_DEBITO, V0OPCP_DIA_DEBITO);
                _.Move(CPROPVAG.V0OPCP_AGECTADEB, V0OPCP_AGECTADEB);
                _.Move(CPROPVAG.V0OPCP_OPRCTADEB, V0OPCP_OPRCTADEB);
                _.Move(CPROPVAG.V0OPCP_NUMCTADEB, V0OPCP_NUMCTADEB);
                _.Move(CPROPVAG.V0OPCP_DIGCTADEB, V0OPCP_DIGCTADEB);
                _.Move(CPROPVAG.V0OPCP_CARTAO_CRED, V0OPCP_CARTAO_CRED);
                _.Move(CPROPVAG.VIND_CCRE, VIND_CCRE);
            }

        }

        [StopWatch]
        /*" R0950-00-FETCH-CPROPVAG-DB-CLOSE-1 */
        public void R0950_00_FETCH_CPROPVAG_DB_CLOSE_1()
        {
            /*" -2103- EXEC SQL CLOSE CPROPVAG END-EXEC */

            CPROPVAG.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0950_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -2137- MOVE 'R1000' TO WNR-EXEC-SQL */
            _.Move("R1000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2139- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2143- INITIALIZE REGISTRO-LINKAGE-GE0853S */
            _.Initialize(
                REGISTRO_LINKAGE_GE0853S
            );

            /*" -2144- IF WS-TIPO-PROCESSAMENTO EQUAL 1 */

            if (WS_TIPO_PROCESSAMENTO == 1)
            {

                /*" -2148- IF V0OPCP-OPCAOPAG NOT EQUAL '3' AND V0PROP-DTPROXVEN > V1SIST-DT-08D-UTIL */

                if (V0OPCP_OPCAOPAG != "3" && V0PROP_DTPROXVEN > V1SIST_DT_08D_UTIL)
                {

                    /*" -2149- ADD 1 TO WS-QTD-SIT-01 */
                    WS_QTD_SIT_01.Value = WS_QTD_SIT_01 + 1;

                    /*" -2150- GO TO R1000-90-LEITURA */

                    R1000_90_LEITURA(); //GOTO
                    return;

                    /*" -2151- END-IF */
                }


                /*" -2152- ELSE */
            }
            else
            {


                /*" -2154- PERFORM R1018-00-CONS-OPCAOPAGVA */

                R1018_00_CONS_OPCAOPAGVA_SECTION();

                /*" -2155- IF (WS-TIPO-MENSAGEM EQUAL SPACES) */

                if ((WS_TIPO_MENSAGEM.IsEmpty()))
                {

                    /*" -2156- PERFORM R2000-00-CANCELAR-ANUAL */

                    R2000_00_CANCELAR_ANUAL_SECTION();

                    /*" -2157- ADD 1 TO WS-QTD-SIT-02 */
                    WS_QTD_SIT_02.Value = WS_QTD_SIT_02 + 1;

                    /*" -2159- END-IF */
                }


                /*" -2160- GO TO R1000-90-LEITURA */

                R1000_90_LEITURA(); //GOTO
                return;

                /*" -2162- END-IF. */
            }


            /*" -2163- IF (V0OPCP-OPCAOPAG EQUAL ' ' ) */

            if ((V0OPCP_OPCAOPAG == " "))
            {

                /*" -2164- DISPLAY 'R1000-00 OPCAOPAG NAO ENCONTRADA' */
                _.Display($"R1000-00 OPCAOPAG NAO ENCONTRADA");

                /*" -2166- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF ' ' V0PROP-DTPROXVEN */

                $"CERTIF: {V0PROP_NRCERTIF} {V0PROP_DTPROXVEN}"
                .Display();

                /*" -2167- MOVE 'E' TO WS-TIPO-MENSAGEM */
                _.Move("E", WS_TIPO_MENSAGEM);

                /*" -2168- MOVE '10003' TO WNR-EXEC-SQL */
                _.Move("10003", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -2169- MOVE 302 TO WS-NUM-ERRO */
                _.Move(302, WS_NUM_ERRO);

                /*" -2171- MOVE 'PARC. NAO GERADA - OPCAO-PAG INVALIDA' TO WS-MSG-DESCRICAO */
                _.Move("PARC. NAO GERADA - OPCAO-PAG INVALIDA", WS_MSG_DESCRICAO);

                /*" -2172- PERFORM R6000-00-GRAVAR-RELAT-SAIDA */

                R6000_00_GRAVAR_RELAT_SAIDA_SECTION();

                /*" -2173- GO TO R1000-90-LEITURA */

                R1000_90_LEITURA(); //GOTO
                return;

                /*" -2175- END-IF. */
            }


            /*" -2177- IF (V0OPCP-PERIPGTO NOT EQUAL 1 AND 2 AND 3 AND 4 AND 6 AND 12) */

            if ((!V0OPCP_PERIPGTO.In("1", "2", "3", "4", "6", "12")))
            {

                /*" -2178- IF (V0OPCP-PERIPGTO EQUAL ZEROS) */

                if ((V0OPCP_PERIPGTO == 00))
                {

                    /*" -2179- DISPLAY 'V0PROP-NRCERTIF = ' V0PROP-NRCERTIF */
                    _.Display($"V0PROP-NRCERTIF = {V0PROP_NRCERTIF}");

                    /*" -2180- ADD 1 TO WS-QTD-SIT-07 */
                    WS_QTD_SIT_07.Value = WS_QTD_SIT_07 + 1;

                    /*" -2181- GO TO R1000-90-LEITURA */

                    R1000_90_LEITURA(); //GOTO
                    return;

                    /*" -2182- ELSE */
                }
                else
                {


                    /*" -2183- MOVE 'E' TO WS-TIPO-MENSAGEM */
                    _.Move("E", WS_TIPO_MENSAGEM);

                    /*" -2184- MOVE '10002' TO WNR-EXEC-SQL */
                    _.Move("10002", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -2185- MOVE 303 TO WS-NUM-ERRO */
                    _.Move(303, WS_NUM_ERRO);

                    /*" -2187- MOVE 'CERTIF. DESPREZADO - PERIODO DE PGTO INVALIDO' TO WS-MSG-DESCRICAO */
                    _.Move("CERTIF. DESPREZADO - PERIODO DE PGTO INVALIDO", WS_MSG_DESCRICAO);

                    /*" -2188- PERFORM R6000-00-GRAVAR-RELAT-SAIDA */

                    R6000_00_GRAVAR_RELAT_SAIDA_SECTION();

                    /*" -2189- GO TO R1000-90-LEITURA */

                    R1000_90_LEITURA(); //GOTO
                    return;

                    /*" -2190- END-IF */
                }


                /*" -2192- END-IF. */
            }


            /*" -2195- IF (V0PROP-NUM-APOLICE = 93010000890) AND (V0PROP-CODSUBES NOT = 17 ) AND (V0PROP-DTPROXVEN > '2001-09-30' ) */

            if ((V0PROP_NUM_APOLICE == 93010000890) && (V0PROP_CODSUBES != 17) && (V0PROP_DTPROXVEN > "2001-09-30"))
            {

                /*" -2196- ADD 1 TO WS-QTD-SIT-04 */
                WS_QTD_SIT_04.Value = WS_QTD_SIT_04 + 1;

                /*" -2197- GO TO R1000-90-LEITURA */

                R1000_90_LEITURA(); //GOTO
                return;

                /*" -2199- END-IF. */
            }


            /*" -2200- IF (V0OPCP-OPCAOPAG EQUAL '4' ) */

            if ((V0OPCP_OPCAOPAG == "4"))
            {

                /*" -2201- ADD 1 TO WS-QTD-SIT-03 */
                WS_QTD_SIT_03.Value = WS_QTD_SIT_03 + 1;

                /*" -2202- GO TO R1000-90-LEITURA */

                R1000_90_LEITURA(); //GOTO
                return;

                /*" -2204- END-IF. */
            }


            /*" -2206- PERFORM R1017-00-CONS-HISTCOBVA. */

            R1017_00_CONS_HISTCOBVA_SECTION();

            /*" -2207- IF (WS-TIPO-MENSAGEM NOT EQUAL SPACES) */

            if ((!WS_TIPO_MENSAGEM.IsEmpty()))
            {

                /*" -2208- GO TO R1000-90-LEITURA */

                R1000_90_LEITURA(); //GOTO
                return;

                /*" -2210- END-IF. */
            }


            /*" -2213- IF (V0HICB-DTVENCTO > V0PROP-DTPROXVEN) AND (V0HICB-VLPRMTOT > ZEROS) AND (V0HICB-SITUACAO = ' ' OR '0' OR '5' OR X'00' ) */

            if ((V0HICB_DTVENCTO > V0PROP_DTPROXVEN) && (V0HICB_VLPRMTOT > 00) && (V0HICB_SITUACAO.In(" ", "0", "5", "00")))
            {

                /*" -2214- MOVE 'E' TO WS-TIPO-MENSAGEM */
                _.Move("E", WS_TIPO_MENSAGEM);

                /*" -2215- MOVE 329 TO WS-NUM-ERRO */
                _.Move(329, WS_NUM_ERRO);

                /*" -2216- MOVE '10015' TO WNR-EXEC-SQL */
                _.Move("10015", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -2218- MOVE 'DT-VENCIMENTO ULTIMA PARC > QUE DT-PROX-VENCIMENTO' TO WS-MSG-DESCRICAO */
                _.Move("DT-VENCIMENTO ULTIMA PARC > QUE DT-PROX-VENCIMENTO", WS_MSG_DESCRICAO);

                /*" -2219- PERFORM R6000-00-GRAVAR-RELAT-SAIDA */

                R6000_00_GRAVAR_RELAT_SAIDA_SECTION();

                /*" -2221- END-IF. */
            }


            /*" -2222- IF (V0OPCP-OPCAOPAG NOT EQUAL '3' ) */

            if ((V0OPCP_OPCAOPAG != "3"))
            {

                /*" -2224- PERFORM R1015-00-VER-RETORNO-SICOV */

                R1015_00_VER_RETORNO_SICOV_SECTION();

                /*" -2225- IF (WS-TIPO-MENSAGEM NOT EQUAL SPACES) */

                if ((!WS_TIPO_MENSAGEM.IsEmpty()))
                {

                    /*" -2226- GO TO R1000-90-LEITURA */

                    R1000_90_LEITURA(); //GOTO
                    return;

                    /*" -2227- END-IF */
                }


                /*" -2229- END-IF */
            }


            /*" -2231- PERFORM R1016-00-CONS-SEGURAVG. */

            R1016_00_CONS_SEGURAVG_SECTION();

            /*" -2232- IF (WS-TIPO-MENSAGEM NOT EQUAL SPACES) */

            if ((!WS_TIPO_MENSAGEM.IsEmpty()))
            {

                /*" -2233- GO TO R1000-90-LEITURA */

                R1000_90_LEITURA(); //GOTO
                return;

                /*" -2235- END-IF. */
            }


            /*" -2237- PERFORM R7000-GERAR-PARC-ATRASO */

            R7000_GERAR_PARC_ATRASO_SECTION();

            /*" -2238- IF (WS-FLAG-PROX-LER EQUAL 1) */

            if ((AREA_DE_WORK.WS_FLAG_PROX_LER == 1))
            {

                /*" -2239- GO TO R1000-90-LEITURA */

                R1000_90_LEITURA(); //GOTO
                return;

                /*" -2241- END-IF */
            }


            /*" -2243- MOVE V0PROP-DTQITBCO TO WDATA-PRIMEIRA. */
            _.Move(V0PROP_DTQITBCO, AREA_DE_WORK.WDATA_PRIMEIRA);

            /*" -2244- IF (WDATA-PRI-DIA < 16) */

            if ((AREA_DE_WORK.WDATA_PRIMEIRA.WDATA_PRI_DIA < 16))
            {

                /*" -2245- MOVE 01 TO WDATA-PRI-DIA */
                _.Move(01, AREA_DE_WORK.WDATA_PRIMEIRA.WDATA_PRI_DIA);

                /*" -2246- ELSE */
            }
            else
            {


                /*" -2247- MOVE 15 TO WDATA-PRI-DIA */
                _.Move(15, AREA_DE_WORK.WDATA_PRIMEIRA.WDATA_PRI_DIA);

                /*" -2249- END-IF */
            }


            /*" -2251- PERFORM R1050-00-CONSULTA-CONVENIOVG */

            R1050_00_CONSULTA_CONVENIOVG_SECTION();

            /*" -2253- MOVE V0PROP-DTPROXVEN TO WDATA-SISTEMA. */
            _.Move(V0PROP_DTPROXVEN, AREA_DE_WORK.WDATA_SISTEMA);

            /*" -2256- MOVE 'NAO' TO WS-GEROU-PARC-CARTAO WS-ERRO-AO-GERAR WS-SEM-PERDAO */
            _.Move("NAO", WS_GEROU_PARC_CARTAO, WS_ERRO_AO_GERAR, WS_SEM_PERDAO);

            /*" -2258- MOVE SPACES TO V0RELA-CODRELAT */
            _.Move("", V0RELA_CODRELAT);

            /*" -2259- IF (V0OPCP-OPCAOPAG EQUAL '3' ) */

            if ((V0OPCP_OPCAOPAG == "3"))
            {

                /*" -2262- PERFORM R1200-00-GERA-PARCELAS UNTIL V0PROP-DTPROXVEN > V1SIST-DT-18D-UTIL OR WS-ERRO-AO-GERAR EQUAL 'SIM' */

                while (!(V0PROP_DTPROXVEN > V1SIST_DT_18D_UTIL || WS_ERRO_AO_GERAR == "SIM"))
                {

                    R1200_00_GERA_PARCELAS_SECTION();
                }

                /*" -2263- ELSE */
            }
            else
            {


                /*" -2267- PERFORM R1200-00-GERA-PARCELAS UNTIL V0PROP-DTPROXVEN > V1SIST-DT-08D-UTIL OR WS-ERRO-AO-GERAR EQUAL 'SIM' */

                while (!(V0PROP_DTPROXVEN > V1SIST_DT_08D_UTIL || WS_ERRO_AO_GERAR == "SIM"))
                {

                    R1200_00_GERA_PARCELAS_SECTION();
                }

                /*" -2269- END-IF */
            }


            /*" -2270- IF WS-SEM-PERDAO EQUAL 'SIM' */

            if (WS_SEM_PERDAO == "SIM")
            {

                /*" -2272- PERFORM R8230-00-UPDATE-RELATORIOS THRU R8230-99-SAIDA */

                R8230_00_UPDATE_RELATORIOS_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8230_99_SAIDA*/


                /*" -2274- END-IF */
            }


            /*" -2276- PERFORM R1020-00-UPDATE-V0PROPOSTAVA. */

            R1020_00_UPDATE_V0PROPOSTAVA_SECTION();

            /*" -2277- IF (WS-GEROU-PARC-CARTAO EQUAL 'SIM' ) */

            if ((WS_GEROU_PARC_CARTAO == "SIM"))
            {

                /*" -2278- PERFORM R1100-00-REENVIAR-PARC-ATRASO */

                R1100_00_REENVIAR_PARC_ATRASO_SECTION();

                /*" -2278- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R1000_90_LEITURA */

            R1000_90_LEITURA();

        }

        [StopWatch]
        /*" R1000-90-LEITURA */
        private void R1000_90_LEITURA(bool isPerform = false)
        {
            /*" -2283- IF (WS-NOME-CURSOR EQUAL 'CPROPVAL' ) */

            if ((WS_NOME_CURSOR == "CPROPVAL"))
            {

                /*" -2284- PERFORM R0900-00-FETCH-CPROPVAL */

                R0900_00_FETCH_CPROPVAL_SECTION();

                /*" -2285- ELSE */
            }
            else
            {


                /*" -2286- IF (LK-OPERACAO EQUAL 'COMMIT' ) */

                if ((LK_PARAMETROS.LK_OPERACAO == "COMMIT"))
                {

                    /*" -2286- EXEC SQL COMMIT WORK END-EXEC */

                    DatabaseConnection.Instance.CommitTransaction();

                    /*" -2289- END-IF */
                }


                /*" -2290- PERFORM R0950-00-FETCH-CPROPVAG */

                R0950_00_FETCH_CPROPVAG_SECTION();

                /*" -2290- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1015-00-VER-RETORNO-SICOV-SECTION */
        private void R1015_00_VER_RETORNO_SICOV_SECTION()
        {
            /*" -2305- MOVE 'R1015' TO WNR-EXEC-SQL. */
            _.Move("R1015", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2307- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2309- MOVE SPACES TO WS-TIPO-MENSAGEM WS-COD-IDLG */
            _.Move("", WS_TIPO_MENSAGEM, WS_COD_IDLG);

            /*" -2313- MOVE ZEROS TO VIND-IDLG */
            _.Move(0, VIND_IDLG);

            /*" -2318- IF (V0OPCP-OPCAOPAG EQUAL '1' OR '2' ) */

            if ((V0OPCP_OPCAOPAG.In("1", "2")))
            {

                /*" -2331- PERFORM R1015_00_VER_RETORNO_SICOV_DB_SELECT_1 */

                R1015_00_VER_RETORNO_SICOV_DB_SELECT_1();

                /*" -2335- IF (SQLCODE EQUAL ZEROS) */

                if ((DB.SQLCODE == 00))
                {

                    /*" -2338- IF (V0HCTA-SITUACAO EQUAL '3' OR V0HCTA-SITUACAO EQUAL 'A' ) AND (V0HCTA-NSAS > ZEROS) */

                    if ((V0HCTA_SITUACAO == "3" || V0HCTA_SITUACAO == "A") && (V0HCTA_NSAS > 00))
                    {

                        /*" -2339- MOVE 'E' TO WS-TIPO-MENSAGEM */
                        _.Move("E", WS_TIPO_MENSAGEM);

                        /*" -2340- MOVE '10151' TO WNR-EXEC-SQL */
                        _.Move("10151", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                        /*" -2341- MOVE 306 TO WS-NUM-ERRO */
                        _.Move(306, WS_NUM_ERRO);

                        /*" -2343- MOVE 'POSSUI PARCELA SEM RETORNO COBRANCA SICOV' TO WS-MSG-DESCRICAO */
                        _.Move("POSSUI PARCELA SEM RETORNO COBRANCA SICOV", WS_MSG_DESCRICAO);

                        /*" -2344- PERFORM R6000-00-GRAVAR-RELAT-SAIDA */

                        R6000_00_GRAVAR_RELAT_SAIDA_SECTION();

                        /*" -2345- ELSE */
                    }
                    else
                    {


                        /*" -2351- IF (V0HCTA-SITUACAO EQUAL ' ' OR '0' ) AND (V0HCTA-NSAS = ZEROS) */

                        if ((V0HCTA_SITUACAO.In(" ", "0")) && (V0HCTA_NSAS == 00))
                        {

                            /*" -2352- MOVE 'E' TO WS-TIPO-MENSAGEM */
                            _.Move("E", WS_TIPO_MENSAGEM);

                            /*" -2353- MOVE '10152' TO WNR-EXEC-SQL */
                            _.Move("10152", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                            /*" -2354- MOVE 321 TO WS-NUM-ERRO */
                            _.Move(321, WS_NUM_ERRO);

                            /*" -2356- MOVE 'AGUARDANDO DATA PARA ENVIO COBRANCA SICOV' TO WS-MSG-DESCRICAO */
                            _.Move("AGUARDANDO DATA PARA ENVIO COBRANCA SICOV", WS_MSG_DESCRICAO);

                            /*" -2357- PERFORM R6000-00-GRAVAR-RELAT-SAIDA */

                            R6000_00_GRAVAR_RELAT_SAIDA_SECTION();

                            /*" -2358- END-IF */
                        }


                        /*" -2359- END-IF */
                    }


                    /*" -2360- ELSE */
                }
                else
                {


                    /*" -2361- IF (SQLCODE NOT EQUAL +100) */

                    if ((DB.SQLCODE != +100))
                    {

                        /*" -2362- MOVE 'F' TO WS-TIPO-MENSAGEM */
                        _.Move("F", WS_TIPO_MENSAGEM);

                        /*" -2363- MOVE '10153' TO WNR-EXEC-SQL */
                        _.Move("10153", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                        /*" -2365- MOVE 'ERRO NA CONSULTA DA TABELA V0HISTCONTAVA ' TO WS-MSG-DESCRICAO */
                        _.Move("ERRO NA CONSULTA DA TABELA V0HISTCONTAVA ", WS_MSG_DESCRICAO);

                        /*" -2366- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -2367- END-IF */
                    }


                    /*" -2369- END-IF */
                }


                /*" -2372- IF (V0OPCP-AGECTADEB EQUAL ZEROS) OR (V0OPCP-OPRCTADEB EQUAL ZEROS) OR (V0OPCP-NUMCTADEB EQUAL ZEROS) */

                if ((V0OPCP_AGECTADEB == 00) || (V0OPCP_OPRCTADEB == 00) || (V0OPCP_NUMCTADEB == 00))
                {

                    /*" -2373- MOVE 'E' TO WS-TIPO-MENSAGEM */
                    _.Move("E", WS_TIPO_MENSAGEM);

                    /*" -2374- MOVE '10154' TO WNR-EXEC-SQL */
                    _.Move("10154", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -2375- MOVE 308 TO WS-NUM-ERRO */
                    _.Move(308, WS_NUM_ERRO);

                    /*" -2377- MOVE 'SEGURADO NAO POSSUI CONTA-CORRENTE P/ DEBITOR' TO WS-MSG-DESCRICAO */
                    _.Move("SEGURADO NAO POSSUI CONTA-CORRENTE P/ DEBITOR", WS_MSG_DESCRICAO);

                    /*" -2378- PERFORM R6000-00-GRAVAR-RELAT-SAIDA */

                    R6000_00_GRAVAR_RELAT_SAIDA_SECTION();

                    /*" -2379- END-IF */
                }


                /*" -2384- END-IF. */
            }


            /*" -2385- IF (V0OPCP-OPCAOPAG EQUAL '5' ) */

            if ((V0OPCP_OPCAOPAG == "5"))
            {

                /*" -2406- PERFORM R1015_00_VER_RETORNO_SICOV_DB_SELECT_2 */

                R1015_00_VER_RETORNO_SICOV_DB_SELECT_2();

                /*" -2409-  EVALUATE SQLCODE  */

                /*" -2410-  WHEN ZEROS  */

                /*" -2411-  WHEN -811  */

                /*" -2412-  WHEN +445  */

                /*" -2412- IF   SQLCODE EQUALS ZEROS  OR  -811 OR  +445 */

                if (DB.SQLCODE.In("00", "-811", "+445"))
                {

                    /*" -2413- IF V0PROP-NRPARCEL EQUAL 1 */

                    if (V0PROP_NRPARCEL == 1)
                    {

                        /*" -2415- MOVE 'C000FRONTONLINE' TO WS-IDLG-FIXO */
                        _.Move("C000FRONTONLINE", FILLER_56.WS_IDLG_FIXO);

                        /*" -2417- MOVE V0PROP-NRCERTIF TO WS-IDLG-NUM-CERTIFICADO */
                        _.Move(V0PROP_NRCERTIF, FILLER_56.WS_IDLG_NUM_CERTIFICADO);

                        /*" -2419- MOVE SPACES TO WS-IDLG-ESPACOS */
                        _.Move("", FILLER_56.WS_IDLG_ESPACOS);

                        /*" -2421- MOVE WS-COD-IDLG-ADESAO TO WS-COD-IDLG */
                        _.Move(WS_COD_IDLG_ADESAO, WS_COD_IDLG);

                        /*" -2422- END-IF */
                    }


                    /*" -2423- IF V0PROP-NRPARCEL EQUAL 1 */

                    if (V0PROP_NRPARCEL == 1)
                    {

                        /*" -2424- CONTINUE */

                        /*" -2425- ELSE */
                    }
                    else
                    {


                        /*" -2427- IF VIND-IDLG LESS ZEROS OR SQLCODE EQUAL +445 */

                        if (VIND_IDLG < 00 || DB.SQLCODE == +445)
                        {

                            /*" -2428- MOVE SPACES TO WS-COD-IDLG */
                            _.Move("", WS_COD_IDLG);

                            /*" -2429- END-IF */
                        }


                        /*" -2430- END-IF */
                    }


                    /*" -2431- PERFORM R1025-00-VER-RETORNO-CARTAO */

                    R1025_00_VER_RETORNO_CARTAO_SECTION();

                    /*" -2432-  WHEN +100  */

                    /*" -2432- ELSE IF   SQLCODE EQUALS  +100 */
                }
                else

                if (DB.SQLCODE == +100)
                {

                    /*" -2433- CONTINUE */

                    /*" -2434-  WHEN OTHER  */

                    /*" -2434- ELSE */
                }
                else
                {


                    /*" -2435- DISPLAY 'R1015-00 (ERRO - CONSULTA V0HISTCONTAVA)' */
                    _.Display($"R1015-00 (ERRO - CONSULTA V0HISTCONTAVA)");

                    /*" -2436- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF */
                    _.Display($"CERTIF: {V0PROP_NRCERTIF}");

                    /*" -2437- DISPLAY 'PARCEL: ' V0PROP-NRPARCEL */
                    _.Display($"PARCEL: {V0PROP_NRPARCEL}");

                    /*" -2438- MOVE 'F' TO WS-TIPO-MENSAGEM */
                    _.Move("F", WS_TIPO_MENSAGEM);

                    /*" -2439- MOVE '10151' TO WNR-EXEC-SQL */
                    _.Move("10151", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -2441- MOVE 'ERRO NA CONSULTA DA TABELA V0HISTCONTAVA' TO WS-MSG-DESCRICAO */
                    _.Move("ERRO NA CONSULTA DA TABELA V0HISTCONTAVA", WS_MSG_DESCRICAO);

                    /*" -2442- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2452-  END-EVALUATE  */

                    /*" -2452- END-IF */
                }


                /*" -2452- END-IF. */
            }


        }

        [StopWatch]
        /*" R1015-00-VER-RETORNO-SICOV-DB-SELECT-1 */
        public void R1015_00_VER_RETORNO_SICOV_DB_SELECT_1()
        {
            /*" -2331- EXEC SQL SELECT VALUE(NSAS, 0), VALUE(SITUACAO, ' ' ) INTO :V0HCTA-NSAS, :V0HCTA-SITUACAO FROM SEGUROS.V0HISTCONTAVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND NRPARCEL = :V0PROP-NRPARCEL AND SITUACAO IN ( ' ' , '0' , '3' , 'A' ) AND TIPLANC = '1' FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC */

            var r1015_00_VER_RETORNO_SICOV_DB_SELECT_1_Query1 = new R1015_00_VER_RETORNO_SICOV_DB_SELECT_1_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
            };

            var executed_1 = R1015_00_VER_RETORNO_SICOV_DB_SELECT_1_Query1.Execute(r1015_00_VER_RETORNO_SICOV_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HCTA_NSAS, V0HCTA_NSAS);
                _.Move(executed_1.V0HCTA_SITUACAO, V0HCTA_SITUACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1015_99_SAIDA*/

        [StopWatch]
        /*" R1015-00-VER-RETORNO-SICOV-DB-SELECT-2 */
        public void R1015_00_VER_RETORNO_SICOV_DB_SELECT_2()
        {
            /*" -2406- EXEC SQL SELECT VALUE(NSAS, 0) , VALUE(NSL, 0) , CAST(REPEAT( '0' , (6 - LENGTH(LTRIM(REPLACE( DIGITS(CODCONV), '0' , ' ' ))))) || LTRIM(CHAR(CODCONV)) AS VARCHAR(6)) || CAST(REPEAT( '0' , (6 - LENGTH(LTRIM(REPLACE( DIGITS(NSAS), '0' , ' ' ))))) || LTRIM(CHAR(NSAS)) AS VARCHAR(6)) || CAST(REPEAT( '0' , (9 - LENGTH(LTRIM(REPLACE( DIGITS(NSL), '0' , ' ' ))))) || LTRIM(CHAR(NSL)) AS VARCHAR(9)) INTO :V0HCTA-NSAS , :V0HCTA-NSL , :WS-COD-IDLG:VIND-IDLG FROM SEGUROS.V0HISTCONTAVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND NRPARCEL = :V0PROP-NRPARCEL AND SITUACAO IN ( '3' , 'A' ) WITH UR END-EXEC */

            var r1015_00_VER_RETORNO_SICOV_DB_SELECT_2_Query1 = new R1015_00_VER_RETORNO_SICOV_DB_SELECT_2_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
            };

            var executed_1 = R1015_00_VER_RETORNO_SICOV_DB_SELECT_2_Query1.Execute(r1015_00_VER_RETORNO_SICOV_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HCTA_NSAS, V0HCTA_NSAS);
                _.Move(executed_1.V0HCTA_NSL, V0HCTA_NSL);
                _.Move(executed_1.WS_COD_IDLG, WS_COD_IDLG);
                _.Move(executed_1.VIND_IDLG, VIND_IDLG);
            }


        }

        [StopWatch]
        /*" R1016-00-CONS-SEGURAVG-SECTION */
        private void R1016_00_CONS_SEGURAVG_SECTION()
        {
            /*" -2462- MOVE 'R1016' TO WNR-EXEC-SQL. */
            _.Move("R1016", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2464- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2466- MOVE SPACES TO WS-TIPO-MENSAGEM */
            _.Move("", WS_TIPO_MENSAGEM);

            /*" -2473- PERFORM R1016_00_CONS_SEGURAVG_DB_SELECT_1 */

            R1016_00_CONS_SEGURAVG_DB_SELECT_1();

            /*" -2476- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -2477- IF (SQLCODE EQUAL +100) */

                if ((DB.SQLCODE == +100))
                {

                    /*" -2478- MOVE 'E' TO WS-TIPO-MENSAGEM */
                    _.Move("E", WS_TIPO_MENSAGEM);

                    /*" -2479- MOVE '10004' TO WNR-EXEC-SQL */
                    _.Move("10004", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -2480- MOVE 304 TO WS-NUM-ERRO */
                    _.Move(304, WS_NUM_ERRO);

                    /*" -2482- MOVE 'PARCELA NAO GERADA - SEGURADO NAO INTEGRADO' TO WS-MSG-DESCRICAO */
                    _.Move("PARCELA NAO GERADA - SEGURADO NAO INTEGRADO", WS_MSG_DESCRICAO);

                    /*" -2483- PERFORM R6000-00-GRAVAR-RELAT-SAIDA */

                    R6000_00_GRAVAR_RELAT_SAIDA_SECTION();

                    /*" -2484- ELSE */
                }
                else
                {


                    /*" -2485- MOVE 'F' TO WS-TIPO-MENSAGEM */
                    _.Move("F", WS_TIPO_MENSAGEM);

                    /*" -2486- MOVE '10005' TO WNR-EXEC-SQL */
                    _.Move("10005", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -2488- MOVE 'ERRO NA CONSULTA DA TABELA V0SEGURAVG' TO WS-MSG-DESCRICAO */
                    _.Move("ERRO NA CONSULTA DA TABELA V0SEGURAVG", WS_MSG_DESCRICAO);

                    /*" -2489- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2490- END-IF */
                }


                /*" -2492- END-IF. */
            }


            /*" -2493- IF (V0SEGV-SITUACAO EQUAL '2' ) */

            if ((V0SEGV_SITUACAO == "2"))
            {

                /*" -2494- MOVE 'E' TO WS-TIPO-MENSAGEM */
                _.Move("E", WS_TIPO_MENSAGEM);

                /*" -2495- MOVE '10006' TO WNR-EXEC-SQL */
                _.Move("10006", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -2496- MOVE 305 TO WS-NUM-ERRO */
                _.Move(305, WS_NUM_ERRO);

                /*" -2498- MOVE 'PARCELA NAO GERADA - SEGURADO SITUACAO CANCELADO' TO WS-MSG-DESCRICAO */
                _.Move("PARCELA NAO GERADA - SEGURADO SITUACAO CANCELADO", WS_MSG_DESCRICAO);

                /*" -2499- PERFORM R6000-00-GRAVAR-RELAT-SAIDA */

                R6000_00_GRAVAR_RELAT_SAIDA_SECTION();

                /*" -2499- END-IF. */
            }


        }

        [StopWatch]
        /*" R1016-00-CONS-SEGURAVG-DB-SELECT-1 */
        public void R1016_00_CONS_SEGURAVG_DB_SELECT_1()
        {
            /*" -2473- EXEC SQL SELECT SIT_REGISTRO INTO :V0SEGV-SITUACAO FROM SEGUROS.V0SEGURAVG WHERE NUM_CERTIFICADO = :V0PROP-NRCERTIF AND TIPO_SEGURADO = '1' WITH UR END-EXEC. */

            var r1016_00_CONS_SEGURAVG_DB_SELECT_1_Query1 = new R1016_00_CONS_SEGURAVG_DB_SELECT_1_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R1016_00_CONS_SEGURAVG_DB_SELECT_1_Query1.Execute(r1016_00_CONS_SEGURAVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SEGV_SITUACAO, V0SEGV_SITUACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1016_99_SAIDA*/

        [StopWatch]
        /*" R1017-00-CONS-HISTCOBVA-SECTION */
        private void R1017_00_CONS_HISTCOBVA_SECTION()
        {
            /*" -2509- MOVE 'R1017' TO WNR-EXEC-SQL. */
            _.Move("R1017", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2511- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2512- MOVE ZEROS TO V0HICB-VLPRMTOT */
            _.Move(0, V0HICB_VLPRMTOT);

            /*" -2514- MOVE SPACES TO WS-TIPO-MENSAGEM */
            _.Move("", WS_TIPO_MENSAGEM);

            /*" -2531- PERFORM R1017_00_CONS_HISTCOBVA_DB_SELECT_1 */

            R1017_00_CONS_HISTCOBVA_DB_SELECT_1();

            /*" -2535- MOVE V0HICB-VLPRMTOT TO WHOST-VLPREMIO-W */
            _.Move(V0HICB_VLPRMTOT, WHOST_VLPREMIO_W);

            /*" -2536- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -2537- IF (SQLCODE EQUAL +100) */

                if ((DB.SQLCODE == +100))
                {

                    /*" -2539- DISPLAY ' ERRO ACESSO PARCELA CORRENTE - HISTCOBVA ' V0PROP-NRCERTIF ' ' V0PROP-NRPARCEL ' ' SQLCODE */

                    $" ERRO ACESSO PARCELA CORRENTE - HISTCOBVA {V0PROP_NRCERTIF} {V0PROP_NRPARCEL} {DB.SQLCODE}"
                    .Display();

                    /*" -2540- MOVE 'E' TO WS-TIPO-MENSAGEM */
                    _.Move("E", WS_TIPO_MENSAGEM);

                    /*" -2541- MOVE '10016' TO WNR-EXEC-SQL */
                    _.Move("10016", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -2542- MOVE 330 TO WS-NUM-ERRO */
                    _.Move(330, WS_NUM_ERRO);

                    /*" -2544- MOVE 'NAO EXISTE A PARCELA INFORMADA NA PROPOSTA' TO WS-MSG-DESCRICAO */
                    _.Move("NAO EXISTE A PARCELA INFORMADA NA PROPOSTA", WS_MSG_DESCRICAO);

                    /*" -2545- PERFORM R6000-00-GRAVAR-RELAT-SAIDA */

                    R6000_00_GRAVAR_RELAT_SAIDA_SECTION();

                    /*" -2546- ELSE */
                }
                else
                {


                    /*" -2548- DISPLAY ' ERRO ACESSO PARCELA CORRENTE - HISTCOBVA ' V0PROP-NRCERTIF ' ' V0PROP-NRPARCEL ' ' SQLCODE */

                    $" ERRO ACESSO PARCELA CORRENTE - HISTCOBVA {V0PROP_NRCERTIF} {V0PROP_NRPARCEL} {DB.SQLCODE}"
                    .Display();

                    /*" -2549- MOVE 'F' TO WS-TIPO-MENSAGEM */
                    _.Move("F", WS_TIPO_MENSAGEM);

                    /*" -2550- MOVE '10017' TO WNR-EXEC-SQL */
                    _.Move("10017", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -2552- MOVE 'ERRO NA CONSULTA DA TABELA V0HISTCOBVA' TO WS-MSG-DESCRICAO */
                    _.Move("ERRO NA CONSULTA DA TABELA V0HISTCOBVA", WS_MSG_DESCRICAO);

                    /*" -2553- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2554- END-IF */
                }


                /*" -2554- END-IF. */
            }


        }

        [StopWatch]
        /*" R1017-00-CONS-HISTCOBVA-DB-SELECT-1 */
        public void R1017_00_CONS_HISTCOBVA_DB_SELECT_1()
        {
            /*" -2531- EXEC SQL SELECT VALUE(DTVENCTO , '0001-01-01' ), VALUE(VLPRMTOT , 0), VALUE(SITUACAO , '0' ), VALUE(NRTIT, 0), VALUE(OPCAOPAG, ' ' ) INTO :V0HICB-DTVENCTO, :V0HICB-VLPRMTOT, :V0HICB-SITUACAO, :WS-NUMERO-TITULO, :V0HICB-OPCAO-PGTO FROM SEGUROS.V0HISTCOBVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND NRPARCEL = :V0PROP-NRPARCEL ORDER BY NRTIT FETCH FIRST 1 ROW ONLY WITH UR END-EXEC. */

            var r1017_00_CONS_HISTCOBVA_DB_SELECT_1_Query1 = new R1017_00_CONS_HISTCOBVA_DB_SELECT_1_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
            };

            var executed_1 = R1017_00_CONS_HISTCOBVA_DB_SELECT_1_Query1.Execute(r1017_00_CONS_HISTCOBVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HICB_DTVENCTO, V0HICB_DTVENCTO);
                _.Move(executed_1.V0HICB_VLPRMTOT, V0HICB_VLPRMTOT);
                _.Move(executed_1.V0HICB_SITUACAO, V0HICB_SITUACAO);
                _.Move(executed_1.WS_NUMERO_TITULO, WS_NUMERO_TITULO);
                _.Move(executed_1.V0HICB_OPCAO_PGTO, V0HICB_OPCAO_PGTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1017_99_SAIDA*/

        [StopWatch]
        /*" R1018-00-CONS-OPCAOPAGVA-SECTION */
        private void R1018_00_CONS_OPCAOPAGVA_SECTION()
        {
            /*" -2564- MOVE 'R1018' TO WNR-EXEC-SQL. */
            _.Move("R1018", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2566- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2568- MOVE SPACES TO WS-TIPO-MENSAGEM */
            _.Move("", WS_TIPO_MENSAGEM);

            /*" -2593- PERFORM R1018_00_CONS_OPCAOPAGVA_DB_SELECT_1 */

            R1018_00_CONS_OPCAOPAGVA_DB_SELECT_1();

            /*" -2596- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -2597- IF (SQLCODE EQUAL +100) */

                if ((DB.SQLCODE == +100))
                {

                    /*" -2599- DISPLAY ' ERRO ACESSO PARCELA CORRENTE - V0OPCAOPAGVA' V0PROP-NRCERTIF ' ' V0PROP-DTPROXVEN ' ' SQLCODE */

                    $" ERRO ACESSO PARCELA CORRENTE - V0OPCAOPAGVA{V0PROP_NRCERTIF} {V0PROP_DTPROXVEN} {DB.SQLCODE}"
                    .Display();

                    /*" -2600- MOVE 'E' TO WS-TIPO-MENSAGEM */
                    _.Move("E", WS_TIPO_MENSAGEM);

                    /*" -2601- MOVE '10181' TO WNR-EXEC-SQL */
                    _.Move("10181", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -2602- MOVE 330 TO WS-NUM-ERRO */
                    _.Move(330, WS_NUM_ERRO);

                    /*" -2604- MOVE 'NAO EXISTE A PARCELA INFORMADA NA PROPOSTA' TO WS-MSG-DESCRICAO */
                    _.Move("NAO EXISTE A PARCELA INFORMADA NA PROPOSTA", WS_MSG_DESCRICAO);

                    /*" -2605- PERFORM R6000-00-GRAVAR-RELAT-SAIDA */

                    R6000_00_GRAVAR_RELAT_SAIDA_SECTION();

                    /*" -2606- ELSE */
                }
                else
                {


                    /*" -2608- DISPLAY ' ERRO ACESSO PARCELA CORRENTE - V0OPCAOPAGVA' V0PROP-NRCERTIF ' ' V0PROP-DTPROXVEN ' ' SQLCODE */

                    $" ERRO ACESSO PARCELA CORRENTE - V0OPCAOPAGVA{V0PROP_NRCERTIF} {V0PROP_DTPROXVEN} {DB.SQLCODE}"
                    .Display();

                    /*" -2609- MOVE 'F' TO WS-TIPO-MENSAGEM */
                    _.Move("F", WS_TIPO_MENSAGEM);

                    /*" -2610- MOVE '10182' TO WNR-EXEC-SQL */
                    _.Move("10182", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -2612- MOVE 'ERRO NA CONSULTA DA TABELA V0HISTCOBVA' TO WS-MSG-DESCRICAO */
                    _.Move("ERRO NA CONSULTA DA TABELA V0HISTCOBVA", WS_MSG_DESCRICAO);

                    /*" -2613- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2614- END-IF */
                }


                /*" -2616- END-IF. */
            }


            /*" -2617- IF VIND-CCRE < ZEROS */

            if (VIND_CCRE < 00)
            {

                /*" -2619- IF V0OPCP-OPCAOPAG NOT = '5' OR V0OPCP-CARTAO-CRED NOT NUMERIC */

                if (V0OPCP_OPCAOPAG != "5" || !V0OPCP_CARTAO_CRED.IsNumeric())
                {

                    /*" -2620- MOVE ZEROS TO V0OPCP-CARTAO-CRED */
                    _.Move(0, V0OPCP_CARTAO_CRED);

                    /*" -2621- END-IF */
                }


                /*" -2621- END-IF. */
            }


        }

        [StopWatch]
        /*" R1018-00-CONS-OPCAOPAGVA-DB-SELECT-1 */
        public void R1018_00_CONS_OPCAOPAGVA_DB_SELECT_1()
        {
            /*" -2593- EXEC SQL SELECT VALUE(OPCAOPAG , ' ' ), VALUE(PERIPGTO, 0), VALUE(DIA_DEBITO, 0), VALUE(AGECTADEB, 0), VALUE(OPRCTADEB, 0), VALUE(NUMCTADEB, 0), VALUE(DIGCTADEB, 0), NUM_CARTAO_CREDITO INTO :V0OPCP-OPCAOPAG, :V0OPCP-PERIPGTO, :V0OPCP-DIA-DEBITO, :V0OPCP-AGECTADEB, :V0OPCP-OPRCTADEB, :V0OPCP-NUMCTADEB, :V0OPCP-DIGCTADEB, :V0OPCP-CARTAO-CRED:VIND-CCRE FROM SEGUROS.V0OPCAOPAGVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND DTINIVIG <= :V0PROP-DTPROXVEN AND DTTERVIG >= :V0PROP-DTPROXVEN FETCH FIRST 1 ROW ONLY WITH UR END-EXEC */

            var r1018_00_CONS_OPCAOPAGVA_DB_SELECT_1_Query1 = new R1018_00_CONS_OPCAOPAGVA_DB_SELECT_1_Query1()
            {
                V0PROP_DTPROXVEN = V0PROP_DTPROXVEN.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R1018_00_CONS_OPCAOPAGVA_DB_SELECT_1_Query1.Execute(r1018_00_CONS_OPCAOPAGVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0OPCP_OPCAOPAG, V0OPCP_OPCAOPAG);
                _.Move(executed_1.V0OPCP_PERIPGTO, V0OPCP_PERIPGTO);
                _.Move(executed_1.V0OPCP_DIA_DEBITO, V0OPCP_DIA_DEBITO);
                _.Move(executed_1.V0OPCP_AGECTADEB, V0OPCP_AGECTADEB);
                _.Move(executed_1.V0OPCP_OPRCTADEB, V0OPCP_OPRCTADEB);
                _.Move(executed_1.V0OPCP_NUMCTADEB, V0OPCP_NUMCTADEB);
                _.Move(executed_1.V0OPCP_DIGCTADEB, V0OPCP_DIGCTADEB);
                _.Move(executed_1.V0OPCP_CARTAO_CRED, V0OPCP_CARTAO_CRED);
                _.Move(executed_1.VIND_CCRE, VIND_CCRE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1018_99_SAIDA*/

        [StopWatch]
        /*" R1020-00-UPDATE-V0PROPOSTAVA-SECTION */
        private void R1020_00_UPDATE_V0PROPOSTAVA_SECTION()
        {
            /*" -2631- MOVE 'R1020' TO WNR-EXEC-SQL. */
            _.Move("R1020", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2633- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2643- PERFORM R1020_00_UPDATE_V0PROPOSTAVA_DB_UPDATE_1 */

            R1020_00_UPDATE_V0PROPOSTAVA_DB_UPDATE_1();

            /*" -2646- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -2647- DISPLAY 'R1000-00 (ERRO - UPDATE CPROPVA   )' */
                _.Display($"R1000-00 (ERRO - UPDATE CPROPVA   )");

                /*" -2648- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF */
                _.Display($"CERTIF: {V0PROP_NRCERTIF}");

                /*" -2649- MOVE 'F' TO WS-TIPO-MENSAGEM */
                _.Move("F", WS_TIPO_MENSAGEM);

                /*" -2650- MOVE '10014' TO WNR-EXEC-SQL */
                _.Move("10014", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -2652- MOVE 'ERRO NA ALTERACAO DA TABELA V0PROPOSTAVA' TO WS-MSG-DESCRICAO */
                _.Move("ERRO NA ALTERACAO DA TABELA V0PROPOSTAVA", WS_MSG_DESCRICAO);

                /*" -2653- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2653- END-IF. */
            }


        }

        [StopWatch]
        /*" R1020-00-UPDATE-V0PROPOSTAVA-DB-UPDATE-1 */
        public void R1020_00_UPDATE_V0PROPOSTAVA_DB_UPDATE_1()
        {
            /*" -2643- EXEC SQL UPDATE SEGUROS.V0PROPOSTAVA SET NRPARCE = :V0PROP-NRPARCEL, SITUACAO = :V0PROP-SITUACAO, DTVENCTO = :V0PROP-DTVENCTO, DTPROXVEN = :V0PROP-DTPROXVEN, NRPRIPARATZ = :V0PROP-NRPRIPARATZ, QTDPARATZ = :V0PROP-QTDPARATZ, TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :V0PROP-NRCERTIF END-EXEC. */

            var r1020_00_UPDATE_V0PROPOSTAVA_DB_UPDATE_1_Update1 = new R1020_00_UPDATE_V0PROPOSTAVA_DB_UPDATE_1_Update1()
            {
                V0PROP_NRPRIPARATZ = V0PROP_NRPRIPARATZ.ToString(),
                V0PROP_DTPROXVEN = V0PROP_DTPROXVEN.ToString(),
                V0PROP_QTDPARATZ = V0PROP_QTDPARATZ.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
                V0PROP_SITUACAO = V0PROP_SITUACAO.ToString(),
                V0PROP_DTVENCTO = V0PROP_DTVENCTO.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            R1020_00_UPDATE_V0PROPOSTAVA_DB_UPDATE_1_Update1.Execute(r1020_00_UPDATE_V0PROPOSTAVA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1020_99_SAIDA*/

        [StopWatch]
        /*" R1025-00-VER-RETORNO-CARTAO-SECTION */
        private void R1025_00_VER_RETORNO_CARTAO_SECTION()
        {
            /*" -2662- MOVE 'R1025' TO WNR-EXEC-SQL */
            _.Move("R1025", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2664- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2668- INITIALIZE DCLGE-RETORNO-CA-CIELO */
            _.Initialize(
                GE408.DCLGE_RETORNO_CA_CIELO
            );

            /*" -2683- PERFORM R1025_00_VER_RETORNO_CARTAO_DB_SELECT_1 */

            R1025_00_VER_RETORNO_CARTAO_DB_SELECT_1();

            /*" -2686-  EVALUATE SQLCODE  */

            /*" -2687-  WHEN ZEROS  */

            /*" -2687- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2688- CONTINUE */

                /*" -2689-  WHEN +100  */

                /*" -2689- ELSE IF   SQLCODE EQUALS  +100 */
            }
            else

            if (DB.SQLCODE == +100)
            {

                /*" -2690- MOVE '0001-01-01' TO GE408-DTA-CREDITO */
                _.Move("0001-01-01", GE408.DCLGE_RETORNO_CA_CIELO.GE408_DTA_CREDITO);

                /*" -2691-  WHEN OTHER  */

                /*" -2691- ELSE */
            }
            else
            {


                /*" -2692- DISPLAY 'R1025-00 (ERRO - CONSULTA CARTAO CIELO)' */
                _.Display($"R1025-00 (ERRO - CONSULTA CARTAO CIELO)");

                /*" -2693- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF */
                _.Display($"CERTIF: {V0PROP_NRCERTIF}");

                /*" -2694- DISPLAY 'PARCEL: ' V0PROP-NRPARCEL */
                _.Display($"PARCEL: {V0PROP_NRPARCEL}");

                /*" -2695- DISPLAY 'TITULO: ' WS-NUMERO-TITULO */
                _.Display($"TITULO: {WS_NUMERO_TITULO}");

                /*" -2696- DISPLAY 'NSL   : ' V0HCTA-NSL */
                _.Display($"NSL   : {V0HCTA_NSL}");

                /*" -2697- MOVE 'F' TO WS-TIPO-MENSAGEM */
                _.Move("F", WS_TIPO_MENSAGEM);

                /*" -2698- MOVE '10155' TO WNR-EXEC-SQL */
                _.Move("10155", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -2700- MOVE 'ERRO NA CONSULTA DA TABELA GE_RETORNO_CA_CIELO' TO WS-MSG-DESCRICAO */
                _.Move("ERRO NA CONSULTA DA TABELA GE_RETORNO_CA_CIELO", WS_MSG_DESCRICAO);

                /*" -2701- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2703-  END-EVALUATE  */

                /*" -2703- END-IF */
            }


            /*" -2704- IF (GE408-DTA-CREDITO EQUAL '0001-01-01' ) */

            if ((GE408.DCLGE_RETORNO_CA_CIELO.GE408_DTA_CREDITO == "0001-01-01"))
            {

                /*" -2705- MOVE 'E' TO WS-TIPO-MENSAGEM */
                _.Move("E", WS_TIPO_MENSAGEM);

                /*" -2706- MOVE '10156' TO WNR-EXEC-SQL */
                _.Move("10156", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -2707- MOVE 307 TO WS-NUM-ERRO */
                _.Move(307, WS_NUM_ERRO);

                /*" -2709- MOVE 'ULTIMA PARC. CARTAO-CRED NAO FOI CAPTURADA-CIELO' TO WS-MSG-DESCRICAO */
                _.Move("ULTIMA PARC. CARTAO-CRED NAO FOI CAPTURADA-CIELO", WS_MSG_DESCRICAO);

                /*" -2710- PERFORM R6000-00-GRAVAR-RELAT-SAIDA */

                R6000_00_GRAVAR_RELAT_SAIDA_SECTION();

                /*" -2711- END-IF. */
            }


        }

        [StopWatch]
        /*" R1025-00-VER-RETORNO-CARTAO-DB-SELECT-1 */
        public void R1025_00_VER_RETORNO_CARTAO_DB_SELECT_1()
        {
            /*" -2683- EXEC SQL SELECT VALUE(T2.DTA_CREDITO, '0001-01-01' ) INTO :GE408-DTA-CREDITO FROM SEGUROS.GE_CONTROLE_CARTAO_CIELO T1 LEFT JOIN SEGUROS.GE_RETORNO_CA_CIELO T2 ON T1.NUM_CERTIFICADO = T2.NUM_CERTIFICADO AND T1.NUM_PARCELA = T2.NUM_PARCELA AND T1.SEQ_CONTROL_CARTAO = T2.SEQ_CONTROL_CARTAO AND T2.COD_MOVIMENTO = '03' AND T2.COD_RETORNO = ' CC' WHERE T1.NUM_CERTIFICADO = :V0PROP-NRCERTIF AND T1.NUM_PARCELA = :V0PROP-NRPARCEL AND T1.COD_IDLG = :WS-COD-IDLG AND T1.COD_TP_PAGAMENTO IN ( '01' , '02' ) WITH UR END-EXEC */

            var r1025_00_VER_RETORNO_CARTAO_DB_SELECT_1_Query1 = new R1025_00_VER_RETORNO_CARTAO_DB_SELECT_1_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
                WS_COD_IDLG = WS_COD_IDLG.ToString(),
            };

            var executed_1 = R1025_00_VER_RETORNO_CARTAO_DB_SELECT_1_Query1.Execute(r1025_00_VER_RETORNO_CARTAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE408_DTA_CREDITO, GE408.DCLGE_RETORNO_CA_CIELO.GE408_DTA_CREDITO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1025_99_SAIDA*/

        [StopWatch]
        /*" R1050-00-CONSULTA-CONVENIOVG-SECTION */
        private void R1050_00_CONSULTA_CONVENIOVG_SECTION()
        {
            /*" -2719- MOVE 'R1050' TO WNR-EXEC-SQL. */
            _.Move("R1050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2721- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2722- MOVE 0 TO V0CONV-CCRED */
            _.Move(0, V0CONV_CCRED);

            /*" -2724- MOVE 0 TO V0CONV-CODCONV */
            _.Move(0, V0CONV_CODCONV);

            /*" -2733- PERFORM R1050_00_CONSULTA_CONVENIOVG_DB_SELECT_1 */

            R1050_00_CONSULTA_CONVENIOVG_DB_SELECT_1();

            /*" -2736- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -2737- DISPLAY 'R1050-00 (ERRO - SELECT V0CONVENIOSVG)' */
                _.Display($"R1050-00 (ERRO - SELECT V0CONVENIOSVG)");

                /*" -2740- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF '  ' 'APOL...: ' V0PROP-NUM-APOLICE 'SUBGRUP: ' V0PROP-CODSUBES */

                $"CERTIF: {V0PROP_NRCERTIF}  APOL...: {V0PROP_NUM_APOLICE}SUBGRUP: {V0PROP_CODSUBES}"
                .Display();

                /*" -2741- MOVE 'F' TO WS-TIPO-MENSAGEM */
                _.Move("F", WS_TIPO_MENSAGEM);

                /*" -2742- MOVE '10500' TO WNR-EXEC-SQL */
                _.Move("10500", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -2744- MOVE 'ERRO NA CONSULTA DA TABELA V0CONVENIOSVG' TO WS-MSG-DESCRICAO */
                _.Move("ERRO NA CONSULTA DA TABELA V0CONVENIOSVG", WS_MSG_DESCRICAO);

                /*" -2745- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2745- END-IF. */
            }


        }

        [StopWatch]
        /*" R1050-00-CONSULTA-CONVENIOVG-DB-SELECT-1 */
        public void R1050_00_CONSULTA_CONVENIOVG_DB_SELECT_1()
        {
            /*" -2733- EXEC SQL SELECT COD_SEGURO, COD_CONV_CARTAO INTO :V0CONV-CODCONV, :V0CONV-CCRED FROM SEGUROS.V0CONVENIOSVG WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE AND CODSUBES = :V0PROP-CODSUBES WITH UR END-EXEC. */

            var r1050_00_CONSULTA_CONVENIOVG_DB_SELECT_1_Query1 = new R1050_00_CONSULTA_CONVENIOVG_DB_SELECT_1_Query1()
            {
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
                V0PROP_CODSUBES = V0PROP_CODSUBES.ToString(),
            };

            var executed_1 = R1050_00_CONSULTA_CONVENIOVG_DB_SELECT_1_Query1.Execute(r1050_00_CONSULTA_CONVENIOVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CONV_CODCONV, V0CONV_CODCONV);
                _.Move(executed_1.V0CONV_CCRED, V0CONV_CCRED);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1050_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-REENVIAR-PARC-ATRASO-SECTION */
        private void R1100_00_REENVIAR_PARC_ATRASO_SECTION()
        {
            /*" -2756- MOVE 'R1100' TO WNR-EXEC-SQL. */
            _.Move("R1100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2758- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2765- PERFORM R1105-00-MIN-PARCELA-PEND */

            R1105_00_MIN_PARCELA_PEND_SECTION();

            /*" -2802- PERFORM R1100_00_REENVIAR_PARC_ATRASO_DB_DECLARE_1 */

            R1100_00_REENVIAR_PARC_ATRASO_DB_DECLARE_1();

            /*" -2805- MOVE 'N' TO WFIM-CPARCATZ */
            _.Move("N", WFIM_CPARCATZ);

            /*" -2807- MOVE 120 TO V0PARC-CODOPER */
            _.Move(120, V0PARC_CODOPER);

            /*" -2807- PERFORM R1100_00_REENVIAR_PARC_ATRASO_DB_OPEN_1 */

            R1100_00_REENVIAR_PARC_ATRASO_DB_OPEN_1();

            /*" -2810- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -2811- DISPLAY 'PROBLEMAS NO OPEN (CPARCATZ) ... ' */
                _.Display($"PROBLEMAS NO OPEN (CPARCATZ) ... ");

                /*" -2812- MOVE 'F' TO WS-TIPO-MENSAGEM */
                _.Move("F", WS_TIPO_MENSAGEM);

                /*" -2813- MOVE '11000' TO WNR-EXEC-SQL */
                _.Move("11000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -2815- MOVE 'ERRO NA ABERTURA DO CURSOR CPARCATZ' TO WS-MSG-DESCRICAO */
                _.Move("ERRO NA ABERTURA DO CURSOR CPARCATZ", WS_MSG_DESCRICAO);

                /*" -2816- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2818- END-IF. */
            }


            /*" -2820- PERFORM R1110-00-FETCH-CPARCATZ. */

            R1110_00_FETCH_CPARCATZ_SECTION();

            /*" -2823- PERFORM R1120-00-PROC-CPARCATZ UNTIL WFIM-CPARCATZ EQUAL 'S' */

            while (!(WFIM_CPARCATZ == "S"))
            {

                R1120_00_PROC_CPARCATZ_SECTION();
            }

            /*" -2824- . */

        }

        [StopWatch]
        /*" R1100-00-REENVIAR-PARC-ATRASO-DB-OPEN-1 */
        public void R1100_00_REENVIAR_PARC_ATRASO_DB_OPEN_1()
        {
            /*" -2807- EXEC SQL OPEN CPARCATZ END-EXEC. */

            CPARCATZ.Open();

        }

        [StopWatch]
        /*" R1500-00-TRATA-V0DIFPARCELVA-DB-DECLARE-1 */
        public void R1500_00_TRATA_V0DIFPARCELVA_DB_DECLARE_1()
        {
            /*" -4280- EXEC SQL DECLARE CDIFPAR CURSOR FOR SELECT NRPARCEL, CODOPER, PRMDIFVG + PRMDIFAP, PRMDIFVG, PRMDIFAP FROM SEGUROS.V0DIFPARCELVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND DTVENCTO <= :V0PROP-DTVENCTO AND SITUACAO = ' ' FOR UPDATE OF NRPARCEL, CODOPER END-EXEC. */
            CDIFPAR = new VA0853B_CDIFPAR(true);
            string GetQuery_CDIFPAR()
            {
                var query = @$"SELECT NRPARCEL
							, 
							CODOPER
							, 
							PRMDIFVG + PRMDIFAP
							, 
							PRMDIFVG
							, 
							PRMDIFAP 
							FROM SEGUROS.V0DIFPARCELVA 
							WHERE NRCERTIF = '{V0PROP_NRCERTIF}' 
							AND DTVENCTO <= '{V0PROP_DTVENCTO}' 
							AND SITUACAO = ' '";

                return query;
            }
            CDIFPAR.GetQueryEvent += GetQuery_CDIFPAR;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1105-00-MIN-PARCELA-PEND-SECTION */
        private void R1105_00_MIN_PARCELA_PEND_SECTION()
        {
            /*" -2832- MOVE 'R1105' TO WNR-EXEC-SQL */
            _.Move("R1105", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2834- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2841- PERFORM R1105_00_MIN_PARCELA_PEND_DB_SELECT_1 */

            R1105_00_MIN_PARCELA_PEND_DB_SELECT_1();

            /*" -2844- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -2845- MOVE 'F' TO WS-TIPO-MENSAGEM */
                _.Move("F", WS_TIPO_MENSAGEM);

                /*" -2846- MOVE '21105' TO WNR-EXEC-SQL */
                _.Move("21105", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -2848- MOVE 'ERRO AO BUSCAR MENOR PARCELA ATRASADA - COBER-HIST' TO WS-MSG-DESCRICAO */
                _.Move("ERRO AO BUSCAR MENOR PARCELA ATRASADA - COBER-HIST", WS_MSG_DESCRICAO);

                /*" -2849- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2851- END-IF */
            }


            /*" -2851- . */

        }

        [StopWatch]
        /*" R1105-00-MIN-PARCELA-PEND-DB-SELECT-1 */
        public void R1105_00_MIN_PARCELA_PEND_DB_SELECT_1()
        {
            /*" -2841- EXEC SQL SELECT VALUE(MIN(NUM_PARCELA),0) INTO :WS-NUM-PARCELA-PEND FROM SEGUROS.COBER_HIST_VIDAZUL WHERE NUM_CERTIFICADO = :V0PROP-NRCERTIF AND SIT_REGISTRO IN ( ' ' , '0' , X'00' ) WITH UR END-EXEC */

            var r1105_00_MIN_PARCELA_PEND_DB_SELECT_1_Query1 = new R1105_00_MIN_PARCELA_PEND_DB_SELECT_1_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R1105_00_MIN_PARCELA_PEND_DB_SELECT_1_Query1.Execute(r1105_00_MIN_PARCELA_PEND_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_NUM_PARCELA_PEND, WS_NUM_PARCELA_PEND);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1105_99_SAIDA*/

        [StopWatch]
        /*" R1110-00-FETCH-CPARCATZ-SECTION */
        private void R1110_00_FETCH_CPARCATZ_SECTION()
        {
            /*" -2860- MOVE 'R1110' TO WNR-EXEC-SQL. */
            _.Move("R1110", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2862- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2871- PERFORM R1110_00_FETCH_CPARCATZ_DB_FETCH_1 */

            R1110_00_FETCH_CPARCATZ_DB_FETCH_1();

            /*" -2874- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -2875- IF (SQLCODE EQUAL +100) */

                if ((DB.SQLCODE == +100))
                {

                    /*" -2875- PERFORM R1110_00_FETCH_CPARCATZ_DB_CLOSE_1 */

                    R1110_00_FETCH_CPARCATZ_DB_CLOSE_1();

                    /*" -2878- MOVE 'S' TO WFIM-CPARCATZ */
                    _.Move("S", WFIM_CPARCATZ);

                    /*" -2879- ELSE */
                }
                else
                {


                    /*" -2880- DISPLAY 'R1110-00 (ERRO - FETCH CPARCATZ)...' */
                    _.Display($"R1110-00 (ERRO - FETCH CPARCATZ)...");

                    /*" -2881- MOVE 'F' TO WS-TIPO-MENSAGEM */
                    _.Move("F", WS_TIPO_MENSAGEM);

                    /*" -2882- MOVE '11100' TO WNR-EXEC-SQL */
                    _.Move("11100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -2884- MOVE 'ERRO NO FECHAMENTO DO CURSOR CPARCATZ' TO WS-MSG-DESCRICAO */
                    _.Move("ERRO NO FECHAMENTO DO CURSOR CPARCATZ", WS_MSG_DESCRICAO);

                    /*" -2885- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2886- END-IF */
                }


                /*" -2887- END-IF. */
            }


        }

        [StopWatch]
        /*" R1110-00-FETCH-CPARCATZ-DB-FETCH-1 */
        public void R1110_00_FETCH_CPARCATZ_DB_FETCH_1()
        {
            /*" -2871- EXEC SQL FETCH CPARCATZ INTO :WS-ATZ-NUM-TITULO, :WS-ATZ-NUM-PARCELA, :WS-ATZ-DT-VENCIMENTO, :WS-ATZ-VLR-DEBITO, :WS-ATZ-COD-RETORNO, :WS-ATZ-COD-MOTIVO, :WS-ATZ-OCORR-HISTCTA END-EXEC. */

            if (CPARCATZ.Fetch())
            {
                _.Move(CPARCATZ.WS_ATZ_NUM_TITULO, WS_ATZ_NUM_TITULO);
                _.Move(CPARCATZ.WS_ATZ_NUM_PARCELA, WS_ATZ_NUM_PARCELA);
                _.Move(CPARCATZ.WS_ATZ_DT_VENCIMENTO, WS_ATZ_DT_VENCIMENTO);
                _.Move(CPARCATZ.WS_ATZ_VLR_DEBITO, WS_ATZ_VLR_DEBITO);
                _.Move(CPARCATZ.WS_ATZ_COD_RETORNO, WS_ATZ_COD_RETORNO);
                _.Move(CPARCATZ.WS_ATZ_COD_MOTIVO, WS_ATZ_COD_MOTIVO);
                _.Move(CPARCATZ.WS_ATZ_OCORR_HISTCTA, WS_ATZ_OCORR_HISTCTA);
            }

        }

        [StopWatch]
        /*" R1110-00-FETCH-CPARCATZ-DB-CLOSE-1 */
        public void R1110_00_FETCH_CPARCATZ_DB_CLOSE_1()
        {
            /*" -2875- EXEC SQL CLOSE CPARCATZ END-EXEC */

            CPARCATZ.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_99_SAIDA*/

        [StopWatch]
        /*" R1120-00-PROC-CPARCATZ-SECTION */
        private void R1120_00_PROC_CPARCATZ_SECTION()
        {
            /*" -2896- MOVE 'R1120' TO WNR-EXEC-SQL */
            _.Move("R1120", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2901- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2902- MOVE WS-ATZ-NUM-PARCELA TO V0PROP-NRPARCEL */
            _.Move(WS_ATZ_NUM_PARCELA, V0PROP_NRPARCEL);

            /*" -2904- COMPUTE V0HIST-OCORRHISTCTA = WS-ATZ-OCORR-HISTCTA + 1 */
            V0HIST_OCORRHISTCTA.Value = WS_ATZ_OCORR_HISTCTA + 1;

            /*" -2906- PERFORM R1130-00-INS-MOVTO-PARC-ATZ */

            R1130_00_INS_MOVTO_PARC_ATZ_SECTION();

            /*" -2907- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -2908- DISPLAY 'R1140-00 (ERRO - INSERT V0MOVDEBCC)' */
                _.Display($"R1140-00 (ERRO - INSERT V0MOVDEBCC)");

                /*" -2912- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF '  ' ' TITULO: ' WS-ATZ-NUM-TITULO ' PARCEL: ' WS-ATZ-NUM-PARCELA ' SQLCODE ' SQLCODE */

                $"CERTIF: {V0PROP_NRCERTIF}   TITULO: {WS_ATZ_NUM_TITULO} PARCEL: {WS_ATZ_NUM_PARCELA} SQLCODE {DB.SQLCODE}"
                .Display();

                /*" -2913- ELSE */
            }
            else
            {


                /*" -2914- PERFORM R1300-00-GERA-DEBITO */

                R1300_00_GERA_DEBITO_SECTION();

                /*" -2915- PERFORM R1140-00-UPD-PARC-ATZ */

                R1140_00_UPD_PARC_ATZ_SECTION();

                /*" -2916- MOVE 'I' TO WS-TIPO-MENSAGEM */
                _.Move("I", WS_TIPO_MENSAGEM);

                /*" -2917- MOVE '11201' TO WNR-EXEC-SQL */
                _.Move("11201", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -2918- MOVE 313 TO WS-NUM-ERRO */
                _.Move(313, WS_NUM_ERRO);

                /*" -2920- MOVE 'PARC. DEBITO CARTAO CRED. RECOMANDADA P/ COBRANCA' TO WS-MSG-DESCRICAO */
                _.Move("PARC. DEBITO CARTAO CRED. RECOMANDADA P/ COBRANCA", WS_MSG_DESCRICAO);

                /*" -2921- PERFORM R6000-00-GRAVAR-RELAT-SAIDA */

                R6000_00_GRAVAR_RELAT_SAIDA_SECTION();

                /*" -2922- ADD 1 TO WACC-ATRZ-CARTAO */
                AREA_DE_WORK.WACC_ATRZ_CARTAO.Value = AREA_DE_WORK.WACC_ATRZ_CARTAO + 1;

                /*" -2924- END-IF. */
            }


            /*" -2925- PERFORM R1110-00-FETCH-CPARCATZ. */

            R1110_00_FETCH_CPARCATZ_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1120_99_SAIDA*/

        [StopWatch]
        /*" R1130-00-INS-MOVTO-PARC-ATZ-SECTION */
        private void R1130_00_INS_MOVTO_PARC_ATZ_SECTION()
        {
            /*" -2934- MOVE 'R1130' TO WNR-EXEC-SQL. */
            _.Move("R1130", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2936- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2948- MOVE 152 TO MOVDEBCE-DIG-CONTA-DEB. */
            _.Move(152, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB);

            /*" -2949- MOVE 0 TO MOVDEBCE-COD-EMPRESA */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_EMPRESA);

            /*" -2950- MOVE WS-ATZ-NUM-TITULO TO MOVDEBCE-NUM-APOLICE */
            _.Move(WS_ATZ_NUM_TITULO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);

            /*" -2951- MOVE 0 TO MOVDEBCE-NUM-ENDOSSO */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);

            /*" -2952- MOVE WS-ATZ-NUM-PARCELA TO MOVDEBCE-NUM-PARCELA */
            _.Move(WS_ATZ_NUM_PARCELA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA);

            /*" -2954- MOVE ' ' TO MOVDEBCE-SITUACAO-COBRANCA */
            _.Move(" ", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);

            /*" -2955- MOVE V0HICB-DTVENCTO TO MOVDEBCE-DATA-VENCIMENTO */
            _.Move(V0HICB_DTVENCTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO);

            /*" -2956- MOVE WS-ATZ-VLR-DEBITO TO MOVDEBCE-VALOR-DEBITO */
            _.Move(WS_ATZ_VLR_DEBITO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO);

            /*" -2957- MOVE V1SIST-DTMOVABE TO MOVDEBCE-DATA-MOVIMENTO */
            _.Move(V1SIST_DTMOVABE, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO);

            /*" -2958- MOVE 0 TO MOVDEBCE-DIA-DEBITO */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIA_DEBITO);

            /*" -2959- MOVE 0 TO MOVDEBCE-COD-AGENCIA-DEB */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB);

            /*" -2961- MOVE 0 TO MOVDEBCE-NUM-CONTA-DEB */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB);

            /*" -2962- MOVE HOST-CODCONV TO MOVDEBCE-COD-CONVENIO */
            _.Move(HOST_CODCONV, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);

            /*" -2963- MOVE ZEROES TO MOVDEBCE-NSAS */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS);

            /*" -2965- MOVE 'VA0853B' TO MOVDEBCE-COD-USUARIO */
            _.Move("VA0853B", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_USUARIO);

            /*" -2968- MOVE V0PROP-NRCERTIF TO MOVDEBCE-NUM-CERTIFICADO */
            _.Move(V0PROP_NRCERTIF, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CERTIFICADO);

            /*" -2980- MOVE -1 TO VIND-DTENV VIND-DTRET VIND-VLCRED VIND-CODRET VIND-NREQ VIND-SEQUEN VIND-NLOTE VIND-DTCRED VIND-STATUS VIND-VLCRED VIND-CCRE */
            _.Move(-1, VIND_DTENV, VIND_DTRET, VIND_VLCRED, VIND_CODRET, VIND_NREQ, VIND_SEQUEN, VIND_NLOTE, VIND_DTCRED, VIND_STATUS, VIND_VLCRED, VIND_CCRE);

            /*" -2981- PERFORM R1320-INSERT-MOVTO-DEBITOCC. */

            R1320_INSERT_MOVTO_DEBITOCC_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1130_99_SAIDA*/

        [StopWatch]
        /*" R1140-00-UPD-PARC-ATZ-SECTION */
        private void R1140_00_UPD_PARC_ATZ_SECTION()
        {
            /*" -2990- MOVE 'R1140' TO WNR-EXEC-SQL. */
            _.Move("R1140", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2992- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2994- COMPUTE V0PARC-CODOPER = V0PARC-CODOPER + 1 */
            V0PARC_CODOPER.Value = V0PARC_CODOPER + 1;

            /*" -3001- PERFORM R1140_00_UPD_PARC_ATZ_DB_UPDATE_1 */

            R1140_00_UPD_PARC_ATZ_DB_UPDATE_1();

            /*" -3004- IF (SQLCODE NOT EQUAL ZEROES AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -3005- DISPLAY 'ERRO - UPDATE PARCEVID' */
                _.Display($"ERRO - UPDATE PARCEVID");

                /*" -3006- DISPLAY ' CERTIFICADO ' V0PROP-NRCERTIF */
                _.Display($" CERTIFICADO {V0PROP_NRCERTIF}");

                /*" -3007- DISPLAY ' PARCELA ' WS-ATZ-NUM-PARCELA */
                _.Display($" PARCELA {WS_ATZ_NUM_PARCELA}");

                /*" -3008- MOVE 'F' TO WS-TIPO-MENSAGEM */
                _.Move("F", WS_TIPO_MENSAGEM);

                /*" -3009- MOVE '11400' TO WNR-EXEC-SQL */
                _.Move("11400", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -3011- MOVE 'ERRO NA ALTERACAO DA TABELA PARCEVID' TO WS-MSG-DESCRICAO */
                _.Move("ERRO NA ALTERACAO DA TABELA PARCEVID", WS_MSG_DESCRICAO);

                /*" -3012- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3014- END-IF. */
            }


            /*" -3022- PERFORM R1140_00_UPD_PARC_ATZ_DB_UPDATE_2 */

            R1140_00_UPD_PARC_ATZ_DB_UPDATE_2();

            /*" -3025- IF (SQLCODE NOT EQUAL ZEROES AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -3026- DISPLAY 'ERRO - UPDATE PARCEVID' */
                _.Display($"ERRO - UPDATE PARCEVID");

                /*" -3027- DISPLAY ' CERTIFICADO ' V0PROP-NRCERTIF */
                _.Display($" CERTIFICADO {V0PROP_NRCERTIF}");

                /*" -3028- DISPLAY ' PARCELA ' WS-ATZ-NUM-PARCELA */
                _.Display($" PARCELA {WS_ATZ_NUM_PARCELA}");

                /*" -3029- MOVE 'F' TO WS-TIPO-MENSAGEM */
                _.Move("F", WS_TIPO_MENSAGEM);

                /*" -3030- MOVE '11401' TO WNR-EXEC-SQL */
                _.Move("11401", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -3032- MOVE 'ERRO NA ALTERACAO DA TABELA PARCEVID' TO WS-MSG-DESCRICAO */
                _.Move("ERRO NA ALTERACAO DA TABELA PARCEVID", WS_MSG_DESCRICAO);

                /*" -3033- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3034- END-IF. */
            }


        }

        [StopWatch]
        /*" R1140-00-UPD-PARC-ATZ-DB-UPDATE-1 */
        public void R1140_00_UPD_PARC_ATZ_DB_UPDATE_1()
        {
            /*" -3001- EXEC SQL UPDATE SEGUROS.PARCELAS_VIDAZUL SET SIT_REGISTRO = ' ' , OCORR_HISTORICO = :V0HIST-OCORRHISTCTA, TIMESTAMP = CURRENT_TIMESTAMP WHERE NUM_CERTIFICADO = :V0PROP-NRCERTIF AND NUM_PARCELA = :WS-ATZ-NUM-PARCELA END-EXEC. */

            var r1140_00_UPD_PARC_ATZ_DB_UPDATE_1_Update1 = new R1140_00_UPD_PARC_ATZ_DB_UPDATE_1_Update1()
            {
                V0HIST_OCORRHISTCTA = V0HIST_OCORRHISTCTA.ToString(),
                WS_ATZ_NUM_PARCELA = WS_ATZ_NUM_PARCELA.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            R1140_00_UPD_PARC_ATZ_DB_UPDATE_1_Update1.Execute(r1140_00_UPD_PARC_ATZ_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1140_99_SAIDA*/

        [StopWatch]
        /*" R1140-00-UPD-PARC-ATZ-DB-UPDATE-2 */
        public void R1140_00_UPD_PARC_ATZ_DB_UPDATE_2()
        {
            /*" -3022- EXEC SQL UPDATE SEGUROS.COBER_HIST_VIDAZUL SET SIT_REGISTRO = '0' , COD_OPERACAO = :V0PARC-CODOPER, OCORR_HISTORICO = :V0HIST-OCORRHISTCTA, COD_DEVOLUCAO = '0' WHERE NUM_CERTIFICADO = :V0PROP-NRCERTIF AND NUM_PARCELA = :WS-ATZ-NUM-PARCELA END-EXEC. */

            var r1140_00_UPD_PARC_ATZ_DB_UPDATE_2_Update1 = new R1140_00_UPD_PARC_ATZ_DB_UPDATE_2_Update1()
            {
                V0HIST_OCORRHISTCTA = V0HIST_OCORRHISTCTA.ToString(),
                V0PARC_CODOPER = V0PARC_CODOPER.ToString(),
                WS_ATZ_NUM_PARCELA = WS_ATZ_NUM_PARCELA.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            R1140_00_UPD_PARC_ATZ_DB_UPDATE_2_Update1.Execute(r1140_00_UPD_PARC_ATZ_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R1200-00-GERA-PARCELAS-SECTION */
        private void R1200_00_GERA_PARCELAS_SECTION()
        {
            /*" -3044- MOVE 'R1200' TO WNR-EXEC-SQL */
            _.Move("R1200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3046- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3047- IF (V0PROP-NRPARCEL EQUAL 1) */

            if ((V0PROP_NRPARCEL == 1))
            {

                /*" -3049- IF (V0PROP-CODOPER > 99 ) AND (V0PROP-CODOPER < 200) */

                if ((V0PROP_CODOPER > 99) && (V0PROP_CODOPER < 200))
                {

                    /*" -3050- MOVE V0PROP-DTQITBCO TO V0PROP-DTVENCTO */
                    _.Move(V0PROP_DTQITBCO, V0PROP_DTVENCTO);

                    /*" -3051- MOVE 1 TO WPRI-PARCELA */
                    _.Move(1, WPRI_PARCELA);

                    /*" -3052- END-IF */
                }


                /*" -3054- END-IF */
            }


            /*" -3056- MOVE V0PROP-DTVENCTO TO WDATA-VIGENCIA */
            _.Move(V0PROP_DTVENCTO, AREA_DE_WORK.WDATA_VIGENCIA);

            /*" -3058- COMPUTE WDATA-VIG-MES = WDATA-VIG-MES + V0OPCP-PERIPGTO */
            AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_MES.Value = AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_MES + V0OPCP_PERIPGTO;

            /*" -3059- IF WDATA-VIG-MES > 12 */

            if (AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_MES > 12)
            {

                /*" -3060- COMPUTE WDATA-VIG-MES = WDATA-VIG-MES - 12 */
                AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_MES.Value = AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_MES - 12;

                /*" -3061- COMPUTE WDATA-VIG-ANO = WDATA-VIG-ANO + 1 */
                AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_ANO.Value = AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_ANO + 1;

                /*" -3063- END-IF */
            }


            /*" -3064- MOVE WDATA-VIGENCIA TO WDATA-VIGENCIA1 */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA, AREA_DE_WORK.WDATA_VIGENCIA1);

            /*" -3066- MOVE V0OPCP-DIA-DEBITO TO WDATA-VIG-DIA1 */
            _.Move(V0OPCP_DIA_DEBITO, AREA_DE_WORK.WDATA_VIGENCIA1.WDATA_VIG_DIA1);

            /*" -3067- IF (WDATA-VIGENCIA1 < WDATA-VIGENCIA) */

            if ((AREA_DE_WORK.WDATA_VIGENCIA1 < AREA_DE_WORK.WDATA_VIGENCIA))
            {

                /*" -3068- ADD 1 TO WDATA-VIG-MES */
                AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_MES.Value = AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_MES + 1;

                /*" -3069- IF (WDATA-VIG-MES > 12) */

                if ((AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_MES > 12))
                {

                    /*" -3070- MOVE 1 TO WDATA-VIG-MES */
                    _.Move(1, AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_MES);

                    /*" -3071- ADD 1 TO WDATA-VIG-ANO */
                    AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_ANO.Value = AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_ANO + 1;

                    /*" -3072- END-IF */
                }


                /*" -3074- END-IF */
            }


            /*" -3075- IF (V0OPCP-DIA-DEBITO NOT LESS 31) */

            if ((V0OPCP_DIA_DEBITO >= 31))
            {

                /*" -3076- MOVE TAB-DIA-MES(WDATA-VIG-MES) TO WDATA-VIG-DIA */
                _.Move(TAB_ULTIMOS_DIAS.TAB_DIA_MESES[AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_MES].TAB_DIA_MES, AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_DIA);

                /*" -3077- ELSE */
            }
            else
            {


                /*" -3078- MOVE V0OPCP-DIA-DEBITO TO WDATA-VIG-DIA */
                _.Move(V0OPCP_DIA_DEBITO, AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_DIA);

                /*" -3080- END-IF */
            }


            /*" -3081- IF (WDATA-VIG-DIA EQUAL ZEROS) */

            if ((AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_DIA == 00))
            {

                /*" -3082- MOVE 01 TO WDATA-VIG-DIA */
                _.Move(01, AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_DIA);

                /*" -3084- END-IF */
            }


            /*" -3086- IF (WDATA-VIG-MES = 02) AND (WDATA-VIG-DIA > 28) */

            if ((AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_MES == 02) && (AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_DIA > 28))
            {

                /*" -3087- MOVE 28 TO WDATA-VIG-DIA */
                _.Move(28, AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_DIA);

                /*" -3089- END-IF */
            }


            /*" -3092- MOVE WDATA-VIGENCIA TO V0COBP-DTINIVIG V0PROP-DTPROXVEN */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA, V0COBP_DTINIVIG, V0PROP_DTPROXVEN);

            /*" -3094- PERFORM R1210-00-CONSULTA-COBERPROPVA */

            R1210_00_CONSULTA_COBERPROPVA_SECTION();

            /*" -3096- IF (WS-TIPO-MENSAGEM EQUAL 'E' ) */

            if ((WS_TIPO_MENSAGEM == "E"))
            {

                /*" -3097- MOVE 'SIM' TO WS-ERRO-AO-GERAR */
                _.Move("SIM", WS_ERRO_AO_GERAR);

                /*" -3098- GO TO R1200-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/ //GOTO
                return;

                /*" -3100- END-IF */
            }


            /*" -3101- IF (V0PRDVG-OPCAOCAP EQUAL 1) */

            if ((V0PRDVG_OPCAOCAP == 1))
            {

                /*" -3103- COMPUTE V0COBP-VLCUSTCAP = V0COBP-VLCUSTCAP * V0COBP-QTTITCAP */
                V0COBP_VLCUSTCAP.Value = V0COBP_VLCUSTCAP * V0COBP_QTTITCAP;

                /*" -3104- COMPUTE V0COBP-VLCUSTCAP = 1,28 * V0COBP-QTTITCAP */
                V0COBP_VLCUSTCAP.Value = 1.28 * V0COBP_QTTITCAP;

                /*" -3106- END-IF */
            }


            /*" -3108- MOVE ZEROS TO V0PARC-PRMTOTANT */
            _.Move(0, V0PARC_PRMTOTANT);

            /*" -3117- PERFORM R1200_00_GERA_PARCELAS_DB_SELECT_1 */

            R1200_00_GERA_PARCELAS_DB_SELECT_1();

            /*" -3120- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -3121- IF (SQLCODE EQUAL +100) */

                if ((DB.SQLCODE == +100))
                {

                    /*" -3122- IF (V0PROP-NRPARCEL EQUAL 0) */

                    if ((V0PROP_NRPARCEL == 0))
                    {

                        /*" -3123- MOVE 1 TO V0PARC-PRMTOTANT */
                        _.Move(1, V0PARC_PRMTOTANT);

                        /*" -3124- ELSE */
                    }
                    else
                    {


                        /*" -3126- IF (V0PRDVG-CODPRODAZ EQUAL 'TRD' OR 'MST' OR 'EXC' OR 'SNR' OR 'PRM' OR 'MCE' ) */

                        if ((V0PRDVG_CODPRODAZ.In("TRD", "MST", "EXC", "SNR", "PRM", "MCE")))
                        {

                            /*" -3127- MOVE 1 TO V0PARC-PRMTOTANT */
                            _.Move(1, V0PARC_PRMTOTANT);

                            /*" -3128- END-IF */
                        }


                        /*" -3129- END-IF */
                    }


                    /*" -3130- ELSE */
                }
                else
                {


                    /*" -3131- DISPLAY 'R1200-00 (ERRO - SELECT V0PARCELVA)' */
                    _.Display($"R1200-00 (ERRO - SELECT V0PARCELVA)");

                    /*" -3134- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF '  ' 'PARCEL: ' V0PROP-NRPARCEL */

                    $"CERTIF: {V0PROP_NRCERTIF}  PARCEL: {V0PROP_NRPARCEL}"
                    .Display();

                    /*" -3135- MOVE 'SIM' TO WS-ERRO-AO-GERAR */
                    _.Move("SIM", WS_ERRO_AO_GERAR);

                    /*" -3136- GO TO R1200-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/ //GOTO
                    return;

                    /*" -3137- END-IF */
                }


                /*" -3139- END-IF */
            }


            /*" -3140- MOVE V0PROP-NRPARCEL TO V0RELA-NRPARCEL */
            _.Move(V0PROP_NRPARCEL, V0RELA_NRPARCEL);

            /*" -3141- COMPUTE V0PROP-NRPARCEL = V0PROP-NRPARCEL + 1 */
            V0PROP_NRPARCEL.Value = V0PROP_NRPARCEL + 1;

            /*" -3143- COMPUTE WHOST-PARCELCAP = V0PROP-NRPARCEL - 1 */
            WHOST_PARCELCAP.Value = V0PROP_NRPARCEL - 1;

            /*" -3150- MOVE ZEROS TO DESCON-PRMVG DESCON-PRMAP */
            _.Move(0, DESCON_PRMVG, DESCON_PRMAP);

            /*" -3160- PERFORM R1200_00_GERA_PARCELAS_DB_SELECT_2 */

            R1200_00_GERA_PARCELAS_DB_SELECT_2();

            /*" -3163- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -3164- IF (SQLCODE EQUAL +100) */

                if ((DB.SQLCODE == +100))
                {

                    /*" -3165- MOVE 0,00 TO DESCON-PERC */
                    _.Move(0.00, DESCON_PERC);

                    /*" -3166- ELSE */
                }
                else
                {


                    /*" -3167- DISPLAY 'R1200-00 (ERRO - SELECT VG_PARCELAS_DESCON)' */
                    _.Display($"R1200-00 (ERRO - SELECT VG_PARCELAS_DESCON)");

                    /*" -3171- DISPLAY 'APOL  : ' V0PROP-NUM-APOLICE ' ' V0PROP-CODSUBES ' ' V0PROP-NRPARCEL ' ' V0PROP-DTADMISSAO */

                    $"APOL  : {V0PROP_NUM_APOLICE} {V0PROP_CODSUBES} {V0PROP_NRPARCEL} {V0PROP_DTADMISSAO}"
                    .Display();

                    /*" -3172- MOVE 'F' TO WS-TIPO-MENSAGEM */
                    _.Move("F", WS_TIPO_MENSAGEM);

                    /*" -3173- MOVE '12004' TO WNR-EXEC-SQL */
                    _.Move("12004", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -3175- MOVE 'ERRO NA CONSULTA DA TABELA VG_PARCELAS_DESCON' TO WS-MSG-DESCRICAO */
                    _.Move("ERRO NA CONSULTA DA TABELA VG_PARCELAS_DESCON", WS_MSG_DESCRICAO);

                    /*" -3176- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3177- END-IF */
                }


                /*" -3178- ELSE */
            }
            else
            {


                /*" -3179- IF (DESCON-PERC > ZEROS) */

                if ((DESCON_PERC > 00))
                {

                    /*" -3180- COMPUTE DESCON-PRMVG = V0COBP-PRMVG * DESCON-PERC */
                    DESCON_PRMVG.Value = V0COBP_PRMVG * DESCON_PERC;

                    /*" -3181- COMPUTE DESCON-PRMAP = V0COBP-PRMAP * DESCON-PERC */
                    DESCON_PRMAP.Value = V0COBP_PRMAP * DESCON_PERC;

                    /*" -3184- IF (DESCON-PRMVG > ZEROS) OR (DESCON-PRMAP > ZEROS) */

                    if ((DESCON_PRMVG > 00) || (DESCON_PRMAP > 00))
                    {

                        /*" -3199- PERFORM R1200_00_GERA_PARCELAS_DB_INSERT_1 */

                        R1200_00_GERA_PARCELAS_DB_INSERT_1();

                        /*" -3202- IF (SQLCODE NOT EQUAL ZEROS) */

                        if ((DB.SQLCODE != 00))
                        {

                            /*" -3203- DISPLAY 'R1200-00 (ERRO-INSERT V0DIFPARCELVA)' */
                            _.Display($"R1200-00 (ERRO-INSERT V0DIFPARCELVA)");

                            /*" -3204- DISPLAY 'CERTIF. : ' V0PROP-NRCERTIF */
                            _.Display($"CERTIF. : {V0PROP_NRCERTIF}");

                            /*" -3205- DISPLAY 'PARCELA : ' V0PROP-NRPARCEL */
                            _.Display($"PARCELA : {V0PROP_NRPARCEL}");

                            /*" -3206- MOVE 'F' TO WS-TIPO-MENSAGEM */
                            _.Move("F", WS_TIPO_MENSAGEM);

                            /*" -3207- MOVE '12005' TO WNR-EXEC-SQL */
                            _.Move("12005", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                            /*" -3209- MOVE 'ERRO NA CONSULTA TABELA V0DIFPARCELVA ' TO WS-MSG-DESCRICAO */
                            _.Move("ERRO NA CONSULTA TABELA V0DIFPARCELVA ", WS_MSG_DESCRICAO);

                            /*" -3210- GO TO R9999-00-ROT-ERRO */

                            R9999_00_ROT_ERRO_SECTION(); //GOTO
                            return;

                            /*" -3211- END-IF */
                        }


                        /*" -3212- END-IF */
                    }


                    /*" -3213- END-IF */
                }


                /*" -3215- END-IF */
            }


            /*" -3217- MOVE V0PROP-DTPROXVEN TO V0PROP-DTVENCTO */
            _.Move(V0PROP_DTPROXVEN, V0PROP_DTVENCTO);

            /*" -3218- IF (V0OPCP-OPCAOPAG EQUAL '3' ) */

            if ((V0OPCP_OPCAOPAG == "3"))
            {

                /*" -3219- MOVE 0 TO V0PARC-OCORHIST */
                _.Move(0, V0PARC_OCORHIST);

                /*" -3220- ELSE */
            }
            else
            {


                /*" -3221- MOVE 1 TO V0PARC-OCORHIST */
                _.Move(1, V0PARC_OCORHIST);

                /*" -3223- END-IF */
            }


            /*" -3232- PERFORM R1500-00-TRATA-V0DIFPARCELVA */

            R1500_00_TRATA_V0DIFPARCELVA_SECTION();

            /*" -3233- IF (WHOST-VLPREMIO EQUAL ZEROS) */

            if ((WHOST_VLPREMIO == 00))
            {

                /*" -3238- PERFORM R1200_00_GERA_PARCELAS_DB_UPDATE_1 */

                R1200_00_GERA_PARCELAS_DB_UPDATE_1();

                /*" -3241- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -3242- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -3243- MOVE '2' TO V0PARC-SITUACAO */
                        _.Move("2", V0PARC_SITUACAO);

                        /*" -3244- ELSE */
                    }
                    else
                    {


                        /*" -3245- DISPLAY 'R1221-00 (ERRO - UPDATE V0DIFPARCELVA)' */
                        _.Display($"R1221-00 (ERRO - UPDATE V0DIFPARCELVA)");

                        /*" -3246- DISPLAY 'CERTIF. : ' V0PROP-NRCERTIF */
                        _.Display($"CERTIF. : {V0PROP_NRCERTIF}");

                        /*" -3247- DISPLAY 'PARCELA : ' V0PROP-NRPARCEL */
                        _.Display($"PARCELA : {V0PROP_NRPARCEL}");

                        /*" -3248- MOVE 'F' TO WS-TIPO-MENSAGEM */
                        _.Move("F", WS_TIPO_MENSAGEM);

                        /*" -3249- MOVE '12006' TO WNR-EXEC-SQL */
                        _.Move("12006", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                        /*" -3251- MOVE 'ERRO NA ALTERACAO TABELA V0DIFPARCELVA ' TO WS-MSG-DESCRICAO */
                        _.Move("ERRO NA ALTERACAO TABELA V0DIFPARCELVA ", WS_MSG_DESCRICAO);

                        /*" -3252- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -3253- END-IF */
                    }


                    /*" -3254- ELSE */
                }
                else
                {


                    /*" -3255- MOVE '1' TO V0PARC-SITUACAO */
                    _.Move("1", V0PARC_SITUACAO);

                    /*" -3257- END-IF */
                }


                /*" -3267- ELSE */
            }
            else
            {


                /*" -3268- IF (WHOST-VLPREMIO < ZEROS) */

                if ((WHOST_VLPREMIO < 00))
                {

                    /*" -3273- PERFORM R1200_00_GERA_PARCELAS_DB_UPDATE_2 */

                    R1200_00_GERA_PARCELAS_DB_UPDATE_2();

                    /*" -3276- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

                    if ((!DB.SQLCODE.In("00", "+100")))
                    {

                        /*" -3277- DISPLAY 'R1222-00 (ERRO - UPDATE V0DIFPARCELVA)' */
                        _.Display($"R1222-00 (ERRO - UPDATE V0DIFPARCELVA)");

                        /*" -3278- DISPLAY 'CERTIF. : ' V0PROP-NRCERTIF */
                        _.Display($"CERTIF. : {V0PROP_NRCERTIF}");

                        /*" -3279- DISPLAY 'PARCELA : ' V0PROP-NRPARCEL */
                        _.Display($"PARCELA : {V0PROP_NRPARCEL}");

                        /*" -3280- MOVE 'F' TO WS-TIPO-MENSAGEM */
                        _.Move("F", WS_TIPO_MENSAGEM);

                        /*" -3281- MOVE '12007' TO WNR-EXEC-SQL */
                        _.Move("12007", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                        /*" -3283- MOVE 'ERRO NA ALTERACAO TABELA V0DIFPARCELVA ' TO WS-MSG-DESCRICAO */
                        _.Move("ERRO NA ALTERACAO TABELA V0DIFPARCELVA ", WS_MSG_DESCRICAO);

                        /*" -3284- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -3286- END-IF */
                    }


                    /*" -3287- IF (WHOST-PRMVG < ZEROS) */

                    if ((WHOST_PRMVG < 00))
                    {

                        /*" -3288- COMPUTE WHOST-PRMVG = WHOST-PRMVG * -1 */
                        WHOST_PRMVG.Value = WHOST_PRMVG * -1;

                        /*" -3290- END-IF */
                    }


                    /*" -3291- IF (WHOST-PRMAP < ZEROS) */

                    if ((WHOST_PRMAP < 00))
                    {

                        /*" -3292- COMPUTE WHOST-PRMAP = WHOST-PRMAP * -1 */
                        WHOST_PRMAP.Value = WHOST_PRMAP * -1;

                        /*" -3294- END-IF */
                    }


                    /*" -3309- PERFORM R1200_00_GERA_PARCELAS_DB_INSERT_2 */

                    R1200_00_GERA_PARCELAS_DB_INSERT_2();

                    /*" -3312- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -3313- DISPLAY 'R1223-00 (ERRO - INSERT V0DIFPARCELVA)' */
                        _.Display($"R1223-00 (ERRO - INSERT V0DIFPARCELVA)");

                        /*" -3314- DISPLAY 'CERTIF. : ' V0PROP-NRCERTIF */
                        _.Display($"CERTIF. : {V0PROP_NRCERTIF}");

                        /*" -3315- DISPLAY 'PARCELA : ' V0PROP-NRPARCEL */
                        _.Display($"PARCELA : {V0PROP_NRPARCEL}");

                        /*" -3316- MOVE 'F' TO WS-TIPO-MENSAGEM */
                        _.Move("F", WS_TIPO_MENSAGEM);

                        /*" -3317- MOVE '12008' TO WNR-EXEC-SQL */
                        _.Move("12008", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                        /*" -3319- MOVE 'ERRO NA INCLUSAO DA TABELA V0DIFPARCELVA ' TO WS-MSG-DESCRICAO */
                        _.Move("ERRO NA INCLUSAO DA TABELA V0DIFPARCELVA ", WS_MSG_DESCRICAO);

                        /*" -3320- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -3322- END-IF */
                    }


                    /*" -3324- MOVE '1' TO V0PARC-SITUACAO */
                    _.Move("1", V0PARC_SITUACAO);

                    /*" -3334- ELSE */
                }
                else
                {


                    /*" -3335- MOVE ' ' TO V0PARC-SITUACAO */
                    _.Move(" ", V0PARC_SITUACAO);

                    /*" -3336- END-IF */
                }


                /*" -3342- END-IF */
            }


            /*" -3343- IF (WHOST-VLPREMIO < ZEROS) */

            if ((WHOST_VLPREMIO < 00))
            {

                /*" -3347- MOVE ZEROS TO WHOST-PRMVG-W WHOST-PRMAP-W WHOST-VLPREMIO-W WHOST-VLPREMIO */
                _.Move(0, WHOST_PRMVG_W, WHOST_PRMAP_W, WHOST_VLPREMIO_W, WHOST_VLPREMIO);

                /*" -3348- ELSE */
            }
            else
            {


                /*" -3349- MOVE WHOST-PRMVG TO WHOST-PRMVG-W */
                _.Move(WHOST_PRMVG, WHOST_PRMVG_W);

                /*" -3350- MOVE WHOST-PRMAP TO WHOST-PRMAP-W */
                _.Move(WHOST_PRMAP, WHOST_PRMAP_W);

                /*" -3351- MOVE WHOST-VLPREMIO TO WHOST-VLPREMIO-W */
                _.Move(WHOST_VLPREMIO, WHOST_VLPREMIO_W);

                /*" -3359- END-IF */
            }


            /*" -3362- PERFORM R8220-00-SELECT-RELATORI THRU R8220-99-SAIDA */

            R8220_00_SELECT_RELATORI_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8220_99_SAIDA*/


            /*" -3363- IF V0RELA-CODRELAT EQUAL 'PERDAO' */

            if (V0RELA_CODRELAT == "PERDAO")
            {

                /*" -3364- CONTINUE */

                /*" -3365- ELSE */
            }
            else
            {


                /*" -3366- IF (V0PARC-SITUACAO EQUAL ' ' ) */

                if ((V0PARC_SITUACAO == " "))
                {

                    /*" -3367- IF (V0PROP-DTVENCTO < V1SIST-DTMOVABE) */

                    if ((V0PROP_DTVENCTO < V1SIST_DTMOVABE))
                    {

                        /*" -3368- MOVE '2' TO V0PARC-SITUACAO */
                        _.Move("2", V0PARC_SITUACAO);

                        /*" -3369- END-IF */
                    }


                    /*" -3370- END-IF */
                }


                /*" -3372- END-IF */
            }


            /*" -3373- IF (V0PROP-NRCERTIF EQUAL 84821639561) */

            if ((V0PROP_NRCERTIF == 84821639561))
            {

                /*" -3374- MOVE '2' TO V0PARC-SITUACAO */
                _.Move("2", V0PARC_SITUACAO);

                /*" -3376- END-IF */
            }


            /*" -3389- PERFORM R1200_00_GERA_PARCELAS_DB_INSERT_3 */

            R1200_00_GERA_PARCELAS_DB_INSERT_3();

            /*" -3392- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -3395- DISPLAY 'PARCELA DUPLICADA ==> ' 'CERTIF: ' V0PROP-NRCERTIF '  ' 'PARCEL: ' V0PROP-NRPARCEL */

                $"PARCELA DUPLICADA ==> CERTIF: {V0PROP_NRCERTIF}  PARCEL: {V0PROP_NRPARCEL}"
                .Display();

                /*" -3396- MOVE 'E' TO WS-TIPO-MENSAGEM */
                _.Move("E", WS_TIPO_MENSAGEM);

                /*" -3397- MOVE '12018' TO WNR-EXEC-SQL */
                _.Move("12018", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -3398- MOVE 310 TO WS-NUM-ERRO */
                _.Move(310, WS_NUM_ERRO);

                /*" -3400- MOVE 'PARC. NAO GERADA - CERTIF. COM PARCELA DUPLICADA' TO WS-MSG-DESCRICAO */
                _.Move("PARC. NAO GERADA - CERTIF. COM PARCELA DUPLICADA", WS_MSG_DESCRICAO);

                /*" -3401- PERFORM R6000-00-GRAVAR-RELAT-SAIDA */

                R6000_00_GRAVAR_RELAT_SAIDA_SECTION();

                /*" -3402- GO TO R1200-00-PROXIMA */

                R1200_00_PROXIMA(); //GOTO
                return;

                /*" -3404- END-IF */
            }


            /*" -3411- PERFORM R1400-00-GERA-HIST-COBRANCA */

            R1400_00_GERA_HIST_COBRANCA_SECTION();

            /*" -3413- IF (V0PARC-SITUACAO EQUAL ' ' ) AND (V0OPCP-OPCAOPAG EQUAL '5' ) */

            if ((V0PARC_SITUACAO == " ") && (V0OPCP_OPCAOPAG == "5"))
            {

                /*" -3415- PERFORM R1310-00-DEBITO-CARTAO */

                R1310_00_DEBITO_CARTAO_SECTION();

                /*" -3416- IF (WS-GEROU-PARC-CARTAO EQUAL 'NAO' ) */

                if ((WS_GEROU_PARC_CARTAO == "NAO"))
                {

                    /*" -3417- MOVE V0PROP-NRPARCEL TO WS-NUM-PARC-CARTAO */
                    _.Move(V0PROP_NRPARCEL, WS_NUM_PARC_CARTAO);

                    /*" -3418- END-IF */
                }


                /*" -3419- MOVE 'SIM' TO WS-GEROU-PARC-CARTAO */
                _.Move("SIM", WS_GEROU_PARC_CARTAO);

                /*" -3421- END-IF */
            }


            /*" -3422- IF (V0PARC-SITUACAO EQUAL '2' ) */

            if ((V0PARC_SITUACAO == "2"))
            {

                /*" -3423- GO TO R1200-00-GRAVADOS */

                R1200_00_GRAVADOS(); //GOTO
                return;

                /*" -3428- END-IF */
            }


            /*" -3434- PERFORM R1200_00_GERA_PARCELAS_DB_SELECT_3 */

            R1200_00_GERA_PARCELAS_DB_SELECT_3();

            /*" -3437- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -3438- DISPLAY 'R1200-00 (ERRO - SELECT V0MOVFDCAPVA)' */
                _.Display($"R1200-00 (ERRO - SELECT V0MOVFDCAPVA)");

                /*" -3439- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF ' ' */

                $"CERTIF: {V0PROP_NRCERTIF} "
                .Display();

                /*" -3440- MOVE 'F' TO WS-TIPO-MENSAGEM */
                _.Move("F", WS_TIPO_MENSAGEM);

                /*" -3441- MOVE '12008' TO WNR-EXEC-SQL */
                _.Move("12008", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -3443- MOVE 'ERRO NA CONSULTA DA TABELA V0MOVFDCAPVA ' TO WS-MSG-DESCRICAO */
                _.Move("ERRO NA CONSULTA DA TABELA V0MOVFDCAPVA ", WS_MSG_DESCRICAO);

                /*" -3444- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3446- END-IF */
            }


            /*" -3447- IF (V0MOVF-COUNT EQUAL ZEROES) */

            if ((V0MOVF_COUNT == 00))
            {

                /*" -3451- IF (V0PROP-NUM-APOLICE EQUAL 97010000889) AND (V0PROP-CODSUBES EQUAL 1 OR 1948 OR 1951) AND (V0COBP-VLCUSTCAP > ZEROES) */

                if ((V0PROP_NUM_APOLICE == 97010000889) && (V0PROP_CODSUBES.In("1", "1948", "1951")) && (V0COBP_VLCUSTCAP > 00))
                {

                    /*" -3463- PERFORM R1200_00_GERA_PARCELAS_DB_INSERT_4 */

                    R1200_00_GERA_PARCELAS_DB_INSERT_4();

                    /*" -3466- IF SQLCODE NOT EQUAL ZEROES AND -803 */

                    if (!DB.SQLCODE.In("00", "-803"))
                    {

                        /*" -3467- DISPLAY 'R1200 (ERRO INSERT V0PARCELCAPVG)' */
                        _.Display($"R1200 (ERRO INSERT V0PARCELCAPVG)");

                        /*" -3468- DISPLAY 'CERTIF: - ' V0PROP-NRCERTIF */
                        _.Display($"CERTIF: - {V0PROP_NRCERTIF}");

                        /*" -3469- DISPLAY 'PARCEL: - ' WHOST-PARCELCAP */
                        _.Display($"PARCEL: - {WHOST_PARCELCAP}");

                        /*" -3470- MOVE 'F' TO WS-TIPO-MENSAGEM */
                        _.Move("F", WS_TIPO_MENSAGEM);

                        /*" -3471- MOVE '12009' TO WNR-EXEC-SQL */
                        _.Move("12009", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                        /*" -3473- MOVE 'ERRO NA INCLUSAO DA TABELA V0PARCELCAPVG ' TO WS-MSG-DESCRICAO */
                        _.Move("ERRO NA INCLUSAO DA TABELA V0PARCELCAPVG ", WS_MSG_DESCRICAO);

                        /*" -3474- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -3475- END-IF */
                    }


                    /*" -3476- END-IF */
                }


                /*" -3478- END-IF */
            }


            /*" -3479- IF (V0PARC-SITUACAO EQUAL '1' ) */

            if ((V0PARC_SITUACAO == "1"))
            {

                /*" -3480- PERFORM R1600-00-VERIFICA-REPASSE */

                R1600_00_VERIFICA_REPASSE_SECTION();

                /*" -3480- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R1200_00_GRAVADOS */

            R1200_00_GRAVADOS();

        }

        [StopWatch]
        /*" R1200-00-GERA-PARCELAS-DB-SELECT-1 */
        public void R1200_00_GERA_PARCELAS_DB_SELECT_1()
        {
            /*" -3117- EXEC SQL SELECT VLPRMTOT INTO :V0PARC-PRMTOTANT FROM SEGUROS.V0HISTCOBVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND DTVENCTO >= :V0COBP-DTINIVIG-1 AND CODOPER IN (112,113) FETCH FIRST 1 ROW ONLY WITH UR END-EXEC */

            var r1200_00_GERA_PARCELAS_DB_SELECT_1_Query1 = new R1200_00_GERA_PARCELAS_DB_SELECT_1_Query1()
            {
                V0COBP_DTINIVIG_1 = V0COBP_DTINIVIG_1.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R1200_00_GERA_PARCELAS_DB_SELECT_1_Query1.Execute(r1200_00_GERA_PARCELAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PARC_PRMTOTANT, V0PARC_PRMTOTANT);
            }


        }

        [StopWatch]
        /*" R1200-00-GRAVADOS */
        private void R1200_00_GRAVADOS(bool isPerform = false)
        {
            /*" -3485- ADD 1 TO WACC-GRAVADOS. */
            AREA_DE_WORK.WACC_GRAVADOS.Value = AREA_DE_WORK.WACC_GRAVADOS + 1;

            /*" -3486- EVALUATE V0OPCP-OPCAOPAG */
            switch (V0OPCP_OPCAOPAG.Value.Trim())
            {

                /*" -3487- WHEN '3' */
                case "3":

                    /*" -3488- ADD 1 TO WACC-GRAV-BOL */
                    AREA_DE_WORK.WACC_GRAV_BOL.Value = AREA_DE_WORK.WACC_GRAV_BOL + 1;

                    /*" -3489- WHEN '5' */
                    break;
                case "5":

                    /*" -3490- ADD 1 TO WACC-GRAV-CARTAO */
                    AREA_DE_WORK.WACC_GRAV_CARTAO.Value = AREA_DE_WORK.WACC_GRAV_CARTAO + 1;

                    /*" -3491- WHEN OTHER */
                    break;
                default:

                    /*" -3492- ADD 1 TO WACC-GRAV-CONTA */
                    AREA_DE_WORK.WACC_GRAV_CONTA.Value = AREA_DE_WORK.WACC_GRAV_CONTA + 1;

                    /*" -3494- END-EVALUATE. */
                    break;
            }


            /*" -3495- MOVE 'S' TO WS-TIPO-MENSAGEM */
            _.Move("S", WS_TIPO_MENSAGEM);

            /*" -3496- MOVE '12010' TO WNR-EXEC-SQL */
            _.Move("12010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3497- MOVE 312 TO WS-NUM-ERRO */
            _.Move(312, WS_NUM_ERRO);

            /*" -3499- MOVE 'PARCELA ADIMPLENTE GERADA COM SUCESSO NO SIAS' TO WS-MSG-DESCRICAO */
            _.Move("PARCELA ADIMPLENTE GERADA COM SUCESSO NO SIAS", WS_MSG_DESCRICAO);

            /*" -3499- PERFORM R6000-00-GRAVAR-RELAT-SAIDA. */

            R6000_00_GRAVAR_RELAT_SAIDA_SECTION();

        }

        [StopWatch]
        /*" R1200-00-GERA-PARCELAS-DB-INSERT-1 */
        public void R1200_00_GERA_PARCELAS_DB_INSERT_1()
        {
            /*" -3199- EXEC SQL INSERT INTO SEGUROS.V0DIFPARCELVA VALUES (:V0PROP-NRCERTIF, 9999, :V0PROP-NRPARCEL, 680, :V0PROP-DTPROXVEN, 0.00, 0.00, 0.00, 0.00, :DESCON-PRMVG, :DESCON-PRMAP, 0.00, ' ' ) END-EXEC */

            var r1200_00_GERA_PARCELAS_DB_INSERT_1_Insert1 = new R1200_00_GERA_PARCELAS_DB_INSERT_1_Insert1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
                V0PROP_DTPROXVEN = V0PROP_DTPROXVEN.ToString(),
                DESCON_PRMVG = DESCON_PRMVG.ToString(),
                DESCON_PRMAP = DESCON_PRMAP.ToString(),
            };

            R1200_00_GERA_PARCELAS_DB_INSERT_1_Insert1.Execute(r1200_00_GERA_PARCELAS_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R1200-00-GERA-PARCELAS-DB-UPDATE-1 */
        public void R1200_00_GERA_PARCELAS_DB_UPDATE_1()
        {
            /*" -3238- EXEC SQL UPDATE SEGUROS.V0DIFPARCELVA SET SITUACAO = '1' WHERE NRCERTIF = :V0PROP-NRCERTIF AND NRPARCEL = :V0PROP-NRPARCEL END-EXEC */

            var r1200_00_GERA_PARCELAS_DB_UPDATE_1_Update1 = new R1200_00_GERA_PARCELAS_DB_UPDATE_1_Update1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
            };

            R1200_00_GERA_PARCELAS_DB_UPDATE_1_Update1.Execute(r1200_00_GERA_PARCELAS_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1200-00-GERA-PARCELAS-DB-SELECT-2 */
        public void R1200_00_GERA_PARCELAS_DB_SELECT_2()
        {
            /*" -3160- EXEC SQL SELECT PCT_PARCELA_DESC INTO :DESCON-PERC FROM SEGUROS.VG_PARCELAS_DESCON WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE AND COD_SUBGRUPO = :V0PROP-CODSUBES AND NUM_PARCELA_DESC = :V0PROP-NRPARCEL AND DT_INIVIG_PARCDESC <= :V0PROP-DTADMISSAO AND DT_TERVIG_PARCDESC >= :V0PROP-DTADMISSAO WITH UR END-EXEC */

            var r1200_00_GERA_PARCELAS_DB_SELECT_2_Query1 = new R1200_00_GERA_PARCELAS_DB_SELECT_2_Query1()
            {
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
                V0PROP_DTADMISSAO = V0PROP_DTADMISSAO.ToString(),
                V0PROP_CODSUBES = V0PROP_CODSUBES.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
            };

            var executed_1 = R1200_00_GERA_PARCELAS_DB_SELECT_2_Query1.Execute(r1200_00_GERA_PARCELAS_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.DESCON_PERC, DESCON_PERC);
            }


        }

        [StopWatch]
        /*" R1200-00-GERA-PARCELAS-DB-UPDATE-2 */
        public void R1200_00_GERA_PARCELAS_DB_UPDATE_2()
        {
            /*" -3273- EXEC SQL UPDATE SEGUROS.V0DIFPARCELVA SET SITUACAO = '1' WHERE NRCERTIF = :V0PROP-NRCERTIF AND NRPARCEL = :V0PROP-NRPARCEL END-EXEC */

            var r1200_00_GERA_PARCELAS_DB_UPDATE_2_Update1 = new R1200_00_GERA_PARCELAS_DB_UPDATE_2_Update1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
            };

            R1200_00_GERA_PARCELAS_DB_UPDATE_2_Update1.Execute(r1200_00_GERA_PARCELAS_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R1200-00-GERA-PARCELAS-DB-INSERT-2 */
        public void R1200_00_GERA_PARCELAS_DB_INSERT_2()
        {
            /*" -3309- EXEC SQL INSERT INTO SEGUROS.V0DIFPARCELVA VALUES (:V0PROP-NRCERTIF, 9999, :V0PROP-NRPARCEL, 601, :V0PROP-DTVENCTO, 0.00, 0.00, 0.00, 0.00, :WHOST-PRMVG, :WHOST-PRMAP, 0.00, ' ' ) END-EXEC */

            var r1200_00_GERA_PARCELAS_DB_INSERT_2_Insert1 = new R1200_00_GERA_PARCELAS_DB_INSERT_2_Insert1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
                V0PROP_DTVENCTO = V0PROP_DTVENCTO.ToString(),
                WHOST_PRMVG = WHOST_PRMVG.ToString(),
                WHOST_PRMAP = WHOST_PRMAP.ToString(),
            };

            R1200_00_GERA_PARCELAS_DB_INSERT_2_Insert1.Execute(r1200_00_GERA_PARCELAS_DB_INSERT_2_Insert1);

        }

        [StopWatch]
        /*" R1200-00-PROXIMA */
        private void R1200_00_PROXIMA(bool isPerform = false)
        {
            /*" -3505- MOVE V0PROP-DTVENCTO TO WDATA-SISTEMA */
            _.Move(V0PROP_DTVENCTO, AREA_DE_WORK.WDATA_SISTEMA);

            /*" -3507- ADD V0OPCP-PERIPGTO TO WDATA-SIS-MES. */
            AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES.Value = AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES + V0OPCP_PERIPGTO;

            /*" -3508- IF (WDATA-SIS-MES > 12) */

            if ((AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES > 12))
            {

                /*" -3509- COMPUTE WDATA-SIS-MES = WDATA-SIS-MES - 12 */
                AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES.Value = AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES - 12;

                /*" -3510- COMPUTE WDATA-SIS-ANO = WDATA-SIS-ANO + 01 */
                AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_ANO.Value = AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_ANO + 01;

                /*" -3512- END-IF */
            }


            /*" -3514- IF (WDATA-SIS-MES = 02) AND (WDATA-SIS-DIA > 28) */

            if ((AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES == 02) && (AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_DIA > 28))
            {

                /*" -3515- MOVE 28 TO WDATA-SIS-DIA */
                _.Move(28, AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_DIA);

                /*" -3517- END-IF. */
            }


            /*" -3517- MOVE WDATA-SISTEMA TO V0PROP-DTPROXVEN. */
            _.Move(AREA_DE_WORK.WDATA_SISTEMA, V0PROP_DTPROXVEN);

        }

        [StopWatch]
        /*" R1200-00-GERA-PARCELAS-DB-INSERT-3 */
        public void R1200_00_GERA_PARCELAS_DB_INSERT_3()
        {
            /*" -3389- EXEC SQL INSERT INTO SEGUROS.V0PARCELVA VALUES (:V0PROP-NRCERTIF, :V0PROP-NRPARCEL, :V0PROP-DTVENCTO, :WHOST-PRMVG-W, :WHOST-PRMAP-W, 0, :V0OPCP-OPCAOPAG, :V0PARC-SITUACAO, :V0PARC-OCORHIST, CURRENT TIMESTAMP) END-EXEC */

            var r1200_00_GERA_PARCELAS_DB_INSERT_3_Insert1 = new R1200_00_GERA_PARCELAS_DB_INSERT_3_Insert1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
                V0PROP_DTVENCTO = V0PROP_DTVENCTO.ToString(),
                WHOST_PRMVG_W = WHOST_PRMVG_W.ToString(),
                WHOST_PRMAP_W = WHOST_PRMAP_W.ToString(),
                V0OPCP_OPCAOPAG = V0OPCP_OPCAOPAG.ToString(),
                V0PARC_SITUACAO = V0PARC_SITUACAO.ToString(),
                V0PARC_OCORHIST = V0PARC_OCORHIST.ToString(),
            };

            R1200_00_GERA_PARCELAS_DB_INSERT_3_Insert1.Execute(r1200_00_GERA_PARCELAS_DB_INSERT_3_Insert1);

        }

        [StopWatch]
        /*" R1200-00-GERA-PARCELAS-DB-SELECT-3 */
        public void R1200_00_GERA_PARCELAS_DB_SELECT_3()
        {
            /*" -3434- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :V0MOVF-COUNT FROM SEGUROS.V0MOVFDCAPVA WHERE NRCERTIF = :V0PROP-NRCERTIF WITH UR END-EXEC */

            var r1200_00_GERA_PARCELAS_DB_SELECT_3_Query1 = new R1200_00_GERA_PARCELAS_DB_SELECT_3_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R1200_00_GERA_PARCELAS_DB_SELECT_3_Query1.Execute(r1200_00_GERA_PARCELAS_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0MOVF_COUNT, V0MOVF_COUNT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-GERA-PARCELAS-DB-INSERT-4 */
        public void R1200_00_GERA_PARCELAS_DB_INSERT_4()
        {
            /*" -3463- EXEC SQL INSERT INTO SEGUROS.V0PARCELCAPVG VALUES (:V0PROP-NRCERTIF, :WHOST-PARCELCAP, :V0PROP-DTVENCTO, :V0COBP-VLCUSTCAP, :V0COBP-VLCUSTCAP, '3' , '0' , 0, 0, CURRENT TIMESTAMP) END-EXEC */

            var r1200_00_GERA_PARCELAS_DB_INSERT_4_Insert1 = new R1200_00_GERA_PARCELAS_DB_INSERT_4_Insert1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                WHOST_PARCELCAP = WHOST_PARCELCAP.ToString(),
                V0PROP_DTVENCTO = V0PROP_DTVENCTO.ToString(),
                V0COBP_VLCUSTCAP = V0COBP_VLCUSTCAP.ToString(),
            };

            R1200_00_GERA_PARCELAS_DB_INSERT_4_Insert1.Execute(r1200_00_GERA_PARCELAS_DB_INSERT_4_Insert1);

        }

        [StopWatch]
        /*" R1210-00-CONSULTA-COBERPROPVA-SECTION */
        private void R1210_00_CONSULTA_COBERPROPVA_SECTION()
        {
            /*" -3527- MOVE 'R1210' TO WNR-EXEC-SQL. */
            _.Move("R1210", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3529- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3531- MOVE SPACES TO WS-TIPO-MENSAGEM */
            _.Move("", WS_TIPO_MENSAGEM);

            /*" -3555- PERFORM R1210_00_CONSULTA_COBERPROPVA_DB_SELECT_1 */

            R1210_00_CONSULTA_COBERPROPVA_DB_SELECT_1();

            /*" -3558- IF (SQLCODE NOT EQUAL ZEROS AND -811) */

            if ((!DB.SQLCODE.In("00", "-811")))
            {

                /*" -3559- IF (SQLCODE EQUAL +100) */

                if ((DB.SQLCODE == +100))
                {

                    /*" -3560- DISPLAY 'R1210-00-AUSENCIA DE COBERTURA P/DATA VCTO' */
                    _.Display($"R1210-00-AUSENCIA DE COBERTURA P/DATA VCTO");

                    /*" -3562- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF ' ' WDATA-VIGENCIA */

                    $"CERTIF: {V0PROP_NRCERTIF} {AREA_DE_WORK.WDATA_VIGENCIA}"
                    .Display();

                    /*" -3586- PERFORM R1210_00_CONSULTA_COBERPROPVA_DB_SELECT_2 */

                    R1210_00_CONSULTA_COBERPROPVA_DB_SELECT_2();

                    /*" -3589- IF (SQLCODE NOT EQUAL ZEROS AND -811 AND +100) */

                    if ((!DB.SQLCODE.In("00", "-811", "+100")))
                    {

                        /*" -3590- DISPLAY 'R1210-00 (ERRO - SELECT V0COBERPROPVA)' */
                        _.Display($"R1210-00 (ERRO - SELECT V0COBERPROPVA)");

                        /*" -3591- DISPLAY 'R1210-00 DATA CORRENTE - ULT OCORHIST ' */
                        _.Display($"R1210-00 DATA CORRENTE - ULT OCORHIST ");

                        /*" -3593- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF ' ' WDATA-VIGENCIA */

                        $"CERTIF: {V0PROP_NRCERTIF} {AREA_DE_WORK.WDATA_VIGENCIA}"
                        .Display();

                        /*" -3594- MOVE 'F' TO WS-TIPO-MENSAGEM */
                        _.Move("F", WS_TIPO_MENSAGEM);

                        /*" -3595- MOVE '12100' TO WNR-EXEC-SQL */
                        _.Move("12100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                        /*" -3597- MOVE 'ERRO NA CONSULTA DA TABELA V0COBERPROPVA' TO WS-MSG-DESCRICAO */
                        _.Move("ERRO NA CONSULTA DA TABELA V0COBERPROPVA", WS_MSG_DESCRICAO);

                        /*" -3598- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -3600- END-IF */
                    }


                    /*" -3601- IF (SQLCODE EQUAL +100) */

                    if ((DB.SQLCODE == +100))
                    {

                        /*" -3602- DISPLAY 'R1200-00 (ERRO - SELECT V0COBERPROPVA)' */
                        _.Display($"R1200-00 (ERRO - SELECT V0COBERPROPVA)");

                        /*" -3604- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF ' ' WDATA-VIGENCIA */

                        $"CERTIF: {V0PROP_NRCERTIF} {AREA_DE_WORK.WDATA_VIGENCIA}"
                        .Display();

                        /*" -3605- MOVE 'E' TO WS-TIPO-MENSAGEM */
                        _.Move("E", WS_TIPO_MENSAGEM);

                        /*" -3606- MOVE '12101' TO WNR-EXEC-SQL */
                        _.Move("12101", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                        /*" -3607- MOVE 311 TO WS-NUM-ERRO */
                        _.Move(311, WS_NUM_ERRO);

                        /*" -3609- MOVE 'PARC. NAO GERADA - VLR PARC. NAO ENCONTRADO' TO WS-MSG-DESCRICAO */
                        _.Move("PARC. NAO GERADA - VLR PARC. NAO ENCONTRADO", WS_MSG_DESCRICAO);

                        /*" -3610- PERFORM R6000-00-GRAVAR-RELAT-SAIDA */

                        R6000_00_GRAVAR_RELAT_SAIDA_SECTION();

                        /*" -3611- END-IF */
                    }


                    /*" -3612- ELSE */
                }
                else
                {


                    /*" -3613- DISPLAY 'R1210-00 (ERRO - SELECT V0COBERPROPVA)' */
                    _.Display($"R1210-00 (ERRO - SELECT V0COBERPROPVA)");

                    /*" -3614- DISPLAY 'CERTIF:            ' V0PROP-NRCERTIF ' ' */

                    $"CERTIF:            {V0PROP_NRCERTIF} "
                    .Display();

                    /*" -3615- DISPLAY 'DATA TERVIGENCIA = ' V0COBP-DTINIVIG */
                    _.Display($"DATA TERVIGENCIA = {V0COBP_DTINIVIG}");

                    /*" -3616- MOVE 'F' TO WS-TIPO-MENSAGEM */
                    _.Move("F", WS_TIPO_MENSAGEM);

                    /*" -3617- MOVE '12102' TO WNR-EXEC-SQL */
                    _.Move("12102", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -3619- MOVE 'ERRO NA CONSULTA DA TABELA V0COBERPROPVA' TO WS-MSG-DESCRICAO */
                    _.Move("ERRO NA CONSULTA DA TABELA V0COBERPROPVA", WS_MSG_DESCRICAO);

                    /*" -3620- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3621- END-IF */
                }


                /*" -3623- END-IF. */
            }


            /*" -3624- IF V0COBP-IVLCUSTAUXF LESS 0 */

            if (V0COBP_IVLCUSTAUXF < 0)
            {

                /*" -3625- MOVE 0 TO V0COBP-VLCUSTAUXF */
                _.Move(0, V0COBP_VLCUSTAUXF);

                /*" -3625- END-IF. */
            }


        }

        [StopWatch]
        /*" R1210-00-CONSULTA-COBERPROPVA-DB-SELECT-1 */
        public void R1210_00_CONSULTA_COBERPROPVA_DB_SELECT_1()
        {
            /*" -3555- EXEC SQL SELECT VLPREMIO, PRMVG, PRMAP, QTTITCAP, VLCUSTCAP, VLCUSTCDG, VLCUSTAUXF, CODOPER, VALUE(DTINIVIG, '0001-01-01' ) INTO :V0COBP-VLPREMIO, :V0COBP-PRMVG, :V0COBP-PRMAP, :V0COBP-QTTITCAP, :V0COBP-VLCUSTCAP, :V0COBP-VLCUSTCDG, :V0COBP-VLCUSTAUXF:V0COBP-IVLCUSTAUXF, :V0COBP-CODOPER, :V0COBP-DTINIVIG-1 FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND DTINIVIG <= :V0COBP-DTINIVIG AND DTTERVIG >= :V0COBP-DTINIVIG WITH UR END-EXEC. */

            var r1210_00_CONSULTA_COBERPROPVA_DB_SELECT_1_Query1 = new R1210_00_CONSULTA_COBERPROPVA_DB_SELECT_1_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0COBP_DTINIVIG = V0COBP_DTINIVIG.ToString(),
            };

            var executed_1 = R1210_00_CONSULTA_COBERPROPVA_DB_SELECT_1_Query1.Execute(r1210_00_CONSULTA_COBERPROPVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBP_VLPREMIO, V0COBP_VLPREMIO);
                _.Move(executed_1.V0COBP_PRMVG, V0COBP_PRMVG);
                _.Move(executed_1.V0COBP_PRMAP, V0COBP_PRMAP);
                _.Move(executed_1.V0COBP_QTTITCAP, V0COBP_QTTITCAP);
                _.Move(executed_1.V0COBP_VLCUSTCAP, V0COBP_VLCUSTCAP);
                _.Move(executed_1.V0COBP_VLCUSTCDG, V0COBP_VLCUSTCDG);
                _.Move(executed_1.V0COBP_VLCUSTAUXF, V0COBP_VLCUSTAUXF);
                _.Move(executed_1.V0COBP_IVLCUSTAUXF, V0COBP_IVLCUSTAUXF);
                _.Move(executed_1.V0COBP_CODOPER, V0COBP_CODOPER);
                _.Move(executed_1.V0COBP_DTINIVIG_1, V0COBP_DTINIVIG_1);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1210_99_SAIDA*/

        [StopWatch]
        /*" R1210-00-CONSULTA-COBERPROPVA-DB-SELECT-2 */
        public void R1210_00_CONSULTA_COBERPROPVA_DB_SELECT_2()
        {
            /*" -3586- EXEC SQL SELECT VLPREMIO, PRMVG, PRMAP, QTTITCAP, VLCUSTCAP, VLCUSTCDG, VLCUSTAUXF, CODOPER, VALUE(DTINIVIG, '0001-01-01' ) INTO :V0COBP-VLPREMIO, :V0COBP-PRMVG, :V0COBP-PRMAP, :V0COBP-QTTITCAP, :V0COBP-VLCUSTCAP, :V0COBP-VLCUSTCDG, :V0COBP-VLCUSTAUXF:V0COBP-IVLCUSTAUXF, :V0COBP-CODOPER, :V0COBP-DTINIVIG-1 FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND DTTERVIG = '9999-12-31' FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC */

            var r1210_00_CONSULTA_COBERPROPVA_DB_SELECT_2_Query1 = new R1210_00_CONSULTA_COBERPROPVA_DB_SELECT_2_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R1210_00_CONSULTA_COBERPROPVA_DB_SELECT_2_Query1.Execute(r1210_00_CONSULTA_COBERPROPVA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBP_VLPREMIO, V0COBP_VLPREMIO);
                _.Move(executed_1.V0COBP_PRMVG, V0COBP_PRMVG);
                _.Move(executed_1.V0COBP_PRMAP, V0COBP_PRMAP);
                _.Move(executed_1.V0COBP_QTTITCAP, V0COBP_QTTITCAP);
                _.Move(executed_1.V0COBP_VLCUSTCAP, V0COBP_VLCUSTCAP);
                _.Move(executed_1.V0COBP_VLCUSTCDG, V0COBP_VLCUSTCDG);
                _.Move(executed_1.V0COBP_VLCUSTAUXF, V0COBP_VLCUSTAUXF);
                _.Move(executed_1.V0COBP_IVLCUSTAUXF, V0COBP_IVLCUSTAUXF);
                _.Move(executed_1.V0COBP_CODOPER, V0COBP_CODOPER);
                _.Move(executed_1.V0COBP_DTINIVIG_1, V0COBP_DTINIVIG_1);
            }


        }

        [StopWatch]
        /*" R1300-00-GERA-DEBITO-SECTION */
        private void R1300_00_GERA_DEBITO_SECTION()
        {
            /*" -3637- MOVE 'R1300' TO WNR-EXEC-SQL. */
            _.Move("R1300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3639- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3640- IF (V0OPCP-OPCAOPAG EQUAL '1' OR '2' ) */

            if ((V0OPCP_OPCAOPAG.In("1", "2")))
            {

                /*" -3641- MOVE V0CONV-CODCONV TO HOST-CODCONV */
                _.Move(V0CONV_CODCONV, HOST_CODCONV);

                /*" -3643- MOVE ZEROS TO V0OPCP-CARTAO-CRED VIND-CCRE */
                _.Move(0, V0OPCP_CARTAO_CRED, VIND_CCRE);

                /*" -3645- END-IF */
            }


            /*" -3646- IF (V0OPCP-OPCAOPAG EQUAL '5' ) */

            if ((V0OPCP_OPCAOPAG == "5"))
            {

                /*" -3647- MOVE V0CONV-CCRED TO HOST-CODCONV */
                _.Move(V0CONV_CCRED, HOST_CODCONV);

                /*" -3654- MOVE ZEROS TO VIND-CCRE V0OPCP-CARTAO-CRED V0OPCP-AGECTADEB V0OPCP-OPRCTADEB V0OPCP-NUMCTADEB V0OPCP-DIGCTADEB. */
                _.Move(0, VIND_CCRE, V0OPCP_CARTAO_CRED, V0OPCP_AGECTADEB, V0OPCP_OPRCTADEB, V0OPCP_NUMCTADEB, V0OPCP_DIGCTADEB);
            }


            /*" -3697- PERFORM R1300_00_GERA_DEBITO_DB_INSERT_1 */

            R1300_00_GERA_DEBITO_DB_INSERT_1();

            /*" -3700- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -3701- DISPLAY 'R1300-00 (ERRO - INSERT V0HISTCONTAVA)' */
                _.Display($"R1300-00 (ERRO - INSERT V0HISTCONTAVA)");

                /*" -3703- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF ' PARCEL: ' V0PROP-NRPARCEL */

                $"CERTIF: {V0PROP_NRCERTIF} PARCEL: {V0PROP_NRPARCEL}"
                .Display();

                /*" -3704- MOVE 'F' TO WS-TIPO-MENSAGEM */
                _.Move("F", WS_TIPO_MENSAGEM);

                /*" -3705- MOVE '13000' TO WNR-EXEC-SQL */
                _.Move("13000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -3707- MOVE 'ERRO NA INCLUSAO DA TABELA V0HISTCONTAVA ' TO WS-MSG-DESCRICAO */
                _.Move("ERRO NA INCLUSAO DA TABELA V0HISTCONTAVA ", WS_MSG_DESCRICAO);

                /*" -3708- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3708- END-IF. */
            }


        }

        [StopWatch]
        /*" R1300-00-GERA-DEBITO-DB-INSERT-1 */
        public void R1300_00_GERA_DEBITO_DB_INSERT_1()
        {
            /*" -3697- EXEC SQL INSERT INTO SEGUROS.V0HISTCONTAVA (NRCERTIF , NRPARCEL , OCORRHISTCTA , AGECTADEB , OPRCTADEB , NUMCTADEB , DIGCTADEB , DTVENCTO , VLPRMTOT , SITUACAO , TIPLANC , TIMESTAMP , OCORHIST , CODCONV , NSAS , NSL , NSAC , CODRET , CODUSU , NUM_CARTAO_CREDITO) VALUES (:V0PROP-NRCERTIF, :V0PROP-NRPARCEL, :V0HIST-OCORRHISTCTA, :V0OPCP-AGECTADEB, :V0OPCP-OPRCTADEB, :V0OPCP-NUMCTADEB, :V0OPCP-DIGCTADEB, :V0HICB-DTVENCTO, :WHOST-VLPREMIO-W, '0' , '1' , CURRENT TIMESTAMP, 0, :HOST-CODCONV, NULL, NULL, NULL, NULL, 'VA0853B' , :V0OPCP-CARTAO-CRED:VIND-CCRE) END-EXEC. */

            var r1300_00_GERA_DEBITO_DB_INSERT_1_Insert1 = new R1300_00_GERA_DEBITO_DB_INSERT_1_Insert1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
                V0HIST_OCORRHISTCTA = V0HIST_OCORRHISTCTA.ToString(),
                V0OPCP_AGECTADEB = V0OPCP_AGECTADEB.ToString(),
                V0OPCP_OPRCTADEB = V0OPCP_OPRCTADEB.ToString(),
                V0OPCP_NUMCTADEB = V0OPCP_NUMCTADEB.ToString(),
                V0OPCP_DIGCTADEB = V0OPCP_DIGCTADEB.ToString(),
                V0HICB_DTVENCTO = V0HICB_DTVENCTO.ToString(),
                WHOST_VLPREMIO_W = WHOST_VLPREMIO_W.ToString(),
                HOST_CODCONV = HOST_CODCONV.ToString(),
                V0OPCP_CARTAO_CRED = V0OPCP_CARTAO_CRED.ToString(),
                VIND_CCRE = VIND_CCRE.ToString(),
            };

            R1300_00_GERA_DEBITO_DB_INSERT_1_Insert1.Execute(r1300_00_GERA_DEBITO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1310-00-DEBITO-CARTAO-SECTION */
        private void R1310_00_DEBITO_CARTAO_SECTION()
        {
            /*" -3719- MOVE 'R1310' TO WNR-EXEC-SQL. */
            _.Move("R1310", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3723- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3724- IF (WHOST-VLPREMIO < ZEROS) */

            if ((WHOST_VLPREMIO < 00))
            {

                /*" -3725- COMPUTE WHOST-VLPREMIO-W = WHOST-VLPREMIO * (-1) */
                WHOST_VLPREMIO_W.Value = WHOST_VLPREMIO * (-1);

                /*" -3726- MOVE 352 TO MOVDEBCE-DIG-CONTA-DEB */
                _.Move(352, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB);

                /*" -3727- ELSE */
            }
            else
            {


                /*" -3728- MOVE 152 TO MOVDEBCE-DIG-CONTA-DEB */
                _.Move(152, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB);

                /*" -3730- END-IF. */
            }


            /*" -3732- IF (V0PROP-CODPRODU EQUAL 9320 OR JVPROD(9320) ) */

            if ((V0PROP_CODPRODU.In("9320", JVBKINCL.FILLER.JVPROD[9320].ToString())))
            {

                /*" -3733- MOVE 0005 TO MOVDEBCE-OPER-CONTA-DEB */
                _.Move(0005, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB);

                /*" -3734- ELSE */
            }
            else
            {


                /*" -3735- IF (V0PROP-CODPRODU EQUAL 9703) */

                if ((V0PROP_CODPRODU == 9703))
                {

                    /*" -3736- MOVE 0006 TO MOVDEBCE-OPER-CONTA-DEB */
                    _.Move(0006, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB);

                    /*" -3737- ELSE */
                }
                else
                {


                    /*" -3738- IF (V0PROP-CODPRODU EQUAL 9318) */

                    if ((V0PROP_CODPRODU == 9318))
                    {

                        /*" -3739- MOVE 0008 TO MOVDEBCE-OPER-CONTA-DEB */
                        _.Move(0008, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB);

                        /*" -3740- END-IF */
                    }


                    /*" -3741- END-IF */
                }


                /*" -3743- END-IF. */
            }


            /*" -3745- MOVE 0 TO MOVDEBCE-COD-EMPRESA */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_EMPRESA);

            /*" -3746- MOVE W-TITULO TO MOVDEBCE-NUM-APOLICE */
            _.Move(W_TITULO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);

            /*" -3747- MOVE 0 TO MOVDEBCE-NUM-ENDOSSO */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);

            /*" -3748- MOVE V0PROP-NRPARCEL TO MOVDEBCE-NUM-PARCELA */
            _.Move(V0PROP_NRPARCEL, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA);

            /*" -3749- MOVE ' ' TO MOVDEBCE-SITUACAO-COBRANCA */
            _.Move(" ", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);

            /*" -3750- MOVE V0HICB-DTVENCTO TO MOVDEBCE-DATA-VENCIMENTO */
            _.Move(V0HICB_DTVENCTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO);

            /*" -3751- MOVE WHOST-VLPREMIO-W TO MOVDEBCE-VALOR-DEBITO */
            _.Move(WHOST_VLPREMIO_W, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO);

            /*" -3752- MOVE V1SIST-DTMOVABE TO MOVDEBCE-DATA-MOVIMENTO */
            _.Move(V1SIST_DTMOVABE, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO);

            /*" -3753- MOVE 0 TO MOVDEBCE-DIA-DEBITO */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIA_DEBITO);

            /*" -3754- MOVE 0 TO MOVDEBCE-COD-AGENCIA-DEB */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB);

            /*" -3755- MOVE 0 TO MOVDEBCE-NUM-CONTA-DEB */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB);

            /*" -3757- MOVE HOST-CODCONV TO MOVDEBCE-COD-CONVENIO */
            _.Move(HOST_CODCONV, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);

            /*" -3758- MOVE ZEROES TO MOVDEBCE-NSAS */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS);

            /*" -3760- MOVE 'VA0853B' TO MOVDEBCE-COD-USUARIO */
            _.Move("VA0853B", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_USUARIO);

            /*" -3763- MOVE V0PROP-NRCERTIF TO MOVDEBCE-NUM-CERTIFICADO */
            _.Move(V0PROP_NRCERTIF, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CERTIFICADO);

            /*" -3774- MOVE -1 TO VIND-DTENV VIND-DTRET VIND-CODRET VIND-NREQ VIND-SEQUEN VIND-NLOTE VIND-DTCRED VIND-STATUS VIND-VLCRED VIND-CCRE */
            _.Move(-1, VIND_DTENV, VIND_DTRET, VIND_CODRET, VIND_NREQ, VIND_SEQUEN, VIND_NLOTE, VIND_DTCRED, VIND_STATUS, VIND_VLCRED, VIND_CCRE);

            /*" -3776- PERFORM R1320-INSERT-MOVTO-DEBITOCC */

            R1320_INSERT_MOVTO_DEBITOCC_SECTION();

            /*" -3777- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -3778- DISPLAY 'R1310-00 (ERRO - INSERT V0MOVDEBCC)' */
                _.Display($"R1310-00 (ERRO - INSERT V0MOVDEBCC)");

                /*" -3780- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF '  ' 'PARCEL: ' V0PROP-NRPARCEL */

                $"CERTIF: {V0PROP_NRCERTIF}  PARCEL: {V0PROP_NRPARCEL}"
                .Display();

                /*" -3781- MOVE 'F' TO WS-TIPO-MENSAGEM */
                _.Move("F", WS_TIPO_MENSAGEM);

                /*" -3782- MOVE '13100' TO WNR-EXEC-SQL */
                _.Move("13100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -3784- MOVE 'ERRO NA INCLUSAO DA TABELA V0MOVDEBCC ' TO WS-MSG-DESCRICAO */
                _.Move("ERRO NA INCLUSAO DA TABELA V0MOVDEBCC ", WS_MSG_DESCRICAO);

                /*" -3785- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3786- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1310_99_SAIDA*/

        [StopWatch]
        /*" R1320-INSERT-MOVTO-DEBITOCC-SECTION */
        private void R1320_INSERT_MOVTO_DEBITOCC_SECTION()
        {
            /*" -3795- MOVE 'R1320' TO WNR-EXEC-SQL */
            _.Move("R1320", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3797- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3857- PERFORM R1320_INSERT_MOVTO_DEBITOCC_DB_INSERT_1 */

            R1320_INSERT_MOVTO_DEBITOCC_DB_INSERT_1();

            /*" -3860- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3861- DISPLAY 'ERRO R1320-INSERT-MOVTO-DEBITOCC' */
                _.Display($"ERRO R1320-INSERT-MOVTO-DEBITOCC");

                /*" -3863- DISPLAY 'CERTIF: ' MOVDEBCE-NUM-APOLICE '  ' 'PARCEL: ' MOVDEBCE-NUM-PARCELA */

                $"CERTIF: {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE}  PARCEL: {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA}"
                .Display();

                /*" -3864- MOVE 'F' TO WS-TIPO-MENSAGEM */
                _.Move("F", WS_TIPO_MENSAGEM);

                /*" -3865- MOVE '13200' TO WNR-EXEC-SQL */
                _.Move("13200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -3867- MOVE 'ERRO NA INCLUSAO DA TABELA MOVTO_DEBITOCC_CEF ' TO WS-MSG-DESCRICAO */
                _.Move("ERRO NA INCLUSAO DA TABELA MOVTO_DEBITOCC_CEF ", WS_MSG_DESCRICAO);

                /*" -3868- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3868- END-IF. */
            }


        }

        [StopWatch]
        /*" R1320-INSERT-MOVTO-DEBITOCC-DB-INSERT-1 */
        public void R1320_INSERT_MOVTO_DEBITOCC_DB_INSERT_1()
        {
            /*" -3857- EXEC SQL INSERT INTO SEGUROS.MOVTO_DEBITOCC_CEF ( COD_EMPRESA , NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , SITUACAO_COBRANCA , DATA_VENCIMENTO , VALOR_DEBITO , DATA_MOVIMENTO , TIMESTAMP , DIA_DEBITO , COD_AGENCIA_DEB , OPER_CONTA_DEB , NUM_CONTA_DEB , DIG_CONTA_DEB , COD_CONVENIO , DATA_ENVIO , DATA_RETORNO , COD_RETORNO_CEF , NSAS , COD_USUARIO , NUM_REQUISICAO , NUM_CARTAO , SEQUENCIA , NUM_LOTE , DTCREDITO , STATUS_CARTAO , VLR_CREDITO , NUM_CERTIFICADO) VALUES ( :MOVDEBCE-COD-EMPRESA , :MOVDEBCE-NUM-APOLICE , :MOVDEBCE-NUM-ENDOSSO , :MOVDEBCE-NUM-PARCELA , :MOVDEBCE-SITUACAO-COBRANCA , :MOVDEBCE-DATA-VENCIMENTO , :MOVDEBCE-VALOR-DEBITO , :MOVDEBCE-DATA-MOVIMENTO , CURRENT TIMESTAMP , :MOVDEBCE-DIA-DEBITO , :MOVDEBCE-COD-AGENCIA-DEB , :MOVDEBCE-OPER-CONTA-DEB , :MOVDEBCE-NUM-CONTA-DEB , :MOVDEBCE-DIG-CONTA-DEB , :MOVDEBCE-COD-CONVENIO , :MOVDEBCE-DATA-ENVIO:VIND-DTENV , :MOVDEBCE-DATA-RETORNO:VIND-DTRET , :MOVDEBCE-COD-RETORNO-CEF:VIND-CODRET , :MOVDEBCE-NSAS , :MOVDEBCE-COD-USUARIO , :MOVDEBCE-NUM-REQUISICAO:VIND-NREQ , :MOVDEBCE-NUM-CARTAO:VIND-CCRE , :MOVDEBCE-SEQUENCIA:VIND-SEQUEN , :MOVDEBCE-NUM-LOTE:VIND-NLOTE , :MOVDEBCE-DTCREDITO:VIND-DTCRED , :MOVDEBCE-STATUS-CARTAO:VIND-STATUS , :MOVDEBCE-VLR-CREDITO:VIND-VLCRED , :MOVDEBCE-NUM-CERTIFICADO ) END-EXEC */

            var r1320_INSERT_MOVTO_DEBITOCC_DB_INSERT_1_Insert1 = new R1320_INSERT_MOVTO_DEBITOCC_DB_INSERT_1_Insert1()
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
            };

            R1320_INSERT_MOVTO_DEBITOCC_DB_INSERT_1_Insert1.Execute(r1320_INSERT_MOVTO_DEBITOCC_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1320_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-GERA-HIST-COBRANCA-SECTION */
        private void R1400_00_GERA_HIST_COBRANCA_SECTION()
        {
            /*" -3880- MOVE 'R1400' TO WNR-EXEC-SQL. */
            _.Move("R1400", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3882- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3884- MOVE V0PROP-DTVENCTO TO V0HICB-DTVENCTO */
            _.Move(V0PROP_DTVENCTO, V0HICB_DTVENCTO);

            /*" -3885- IF (V0PARC-SITUACAO EQUAL SPACES) */

            if ((V0PARC_SITUACAO.IsEmpty()))
            {

                /*" -3887- IF (V0OPCP-OPCAOPAG NOT EQUAL '3' ) */

                if ((V0OPCP_OPCAOPAG != "3"))
                {

                    /*" -3889- IF (V0PROP-DTVENCTO < V1SIST-DTVENFIM-6D-UTIL) */

                    if ((V0PROP_DTVENCTO < V1SIST_DTVENFIM_6D_UTIL))
                    {

                        /*" -3890- MOVE V1SIST-DTVENFIM-6D-UTIL TO V0HICB-DTVENCTO */
                        _.Move(V1SIST_DTVENFIM_6D_UTIL, V0HICB_DTVENCTO);

                        /*" -3891- END-IF */
                    }


                    /*" -3892- MOVE 1 TO V0HIST-OCORRHISTCTA */
                    _.Move(1, V0HIST_OCORRHISTCTA);

                    /*" -3893- PERFORM R1300-00-GERA-DEBITO */

                    R1300_00_GERA_DEBITO_SECTION();

                    /*" -3894- ELSE */
                }
                else
                {


                    /*" -3895- IF (V0PROP-DTVENCTO < V1SIST-DT-18D-UTIL) */

                    if ((V0PROP_DTVENCTO < V1SIST_DT_18D_UTIL))
                    {

                        /*" -3896- MOVE V1SIST-DT-18D-UTIL TO V0HICB-DTVENCTO */
                        _.Move(V1SIST_DT_18D_UTIL, V0HICB_DTVENCTO);

                        /*" -3897- END-IF */
                    }


                    /*" -3899- END-IF. */
                }

            }


            /*" -3900- IF V0OPCP-OPCAOPAG EQUAL '3' */

            if (V0OPCP_OPCAOPAG == "3")
            {

                /*" -3901- MOVE '5' TO V0HICB-SITUACAO */
                _.Move("5", V0HICB_SITUACAO);

                /*" -3902- ELSE */
            }
            else
            {


                /*" -3903- MOVE '0' TO V0HICB-SITUACAO */
                _.Move("0", V0HICB_SITUACAO);

                /*" -3905- END-IF */
            }


            /*" -3907- MOVE 000 TO V0HICB-CODOPER. */
            _.Move(000, V0HICB_CODOPER);

            /*" -3908- IF V0PROP-NRPARCEL = 2 */

            if (V0PROP_NRPARCEL == 2)
            {

                /*" -3909- MOVE 111 TO V0HICB-CODOPER */
                _.Move(111, V0HICB_CODOPER);

                /*" -3911- END-IF. */
            }


            /*" -3913- MOVE 'N' TO WREGULARIZOU */
            _.Move("N", AREA_DE_WORK.WREGULARIZOU);

            /*" -3915- IF (V0PROP-SITUACAO EQUAL '6' ) AND (WS-QTD-PARC-ATRZ EQUAL ZEROS) */

            if ((V0PROP_SITUACAO == "6") && (WS_QTD_PARC_ATRZ == 00))
            {

                /*" -3916- MOVE 'S' TO WREGULARIZOU */
                _.Move("S", AREA_DE_WORK.WREGULARIZOU);

                /*" -3917- MOVE '3' TO V0PROP-SITUACAO */
                _.Move("3", V0PROP_SITUACAO);

                /*" -3919- MOVE 0 TO V0PROP-NRPRIPARATZ V0PROP-QTDPARATZ */
                _.Move(0, V0PROP_NRPRIPARATZ, V0PROP_QTDPARATZ);

                /*" -3920- MOVE 115 TO V0HICB-CODOPER */
                _.Move(115, V0HICB_CODOPER);

                /*" -3921- PERFORM R4500-00-SOLIC-RELAT */

                R4500_00_SOLIC_RELAT_SECTION();

                /*" -3923- END-IF. */
            }


            /*" -3924- IF (V0PARC-PRMTOTANT EQUAL ZEROS) */

            if ((V0PARC_PRMTOTANT == 00))
            {

                /*" -3925- MOVE '5' TO V0HICB-SITUACAO */
                _.Move("5", V0HICB_SITUACAO);

                /*" -3926- IF V0COBP-CODOPER = 820 */

                if (V0COBP_CODOPER == 820)
                {

                    /*" -3927- MOVE 114 TO V0HICB-CODOPER */
                    _.Move(114, V0HICB_CODOPER);

                    /*" -3929- END-IF */
                }


                /*" -3930- IF V0COBP-CODOPER = 895 */

                if (V0COBP_CODOPER == 895)
                {

                    /*" -3931- MOVE 113 TO V0HICB-CODOPER */
                    _.Move(113, V0HICB_CODOPER);

                    /*" -3932- ELSE */
                }
                else
                {


                    /*" -3933- IF V0OPCP-OPCAOPAG EQUAL '1' OR '2' OR '5' */

                    if (V0OPCP_OPCAOPAG.In("1", "2", "5"))
                    {

                        /*" -3934- MOVE '0' TO V0HICB-SITUACAO */
                        _.Move("0", V0HICB_SITUACAO);

                        /*" -3935- END-IF */
                    }


                    /*" -3936- END-IF */
                }


                /*" -3938- END-IF. */
            }


            /*" -3940- IF V0PROP-NRPARCEL EQUAL 6 AND V0PRDVG-TEM-CDG EQUAL 'S' */

            if (V0PROP_NRPARCEL == 6 && V0PRDVG_TEM_CDG == "S")
            {

                /*" -3941- MOVE '5' TO V0HICB-SITUACAO */
                _.Move("5", V0HICB_SITUACAO);

                /*" -3942- MOVE 112 TO V0HICB-CODOPER */
                _.Move(112, V0HICB_CODOPER);

                /*" -3944- END-IF. */
            }


            /*" -3945- IF V0PARC-SITUACAO EQUAL '1' */

            if (V0PARC_SITUACAO == "1")
            {

                /*" -3946- MOVE '1' TO V0HICB-SITUACAO */
                _.Move("1", V0HICB_SITUACAO);

                /*" -3947- MOVE 000 TO V0HICB-CODOPER */
                _.Move(000, V0HICB_CODOPER);

                /*" -3949- END-IF. */
            }


            /*" -3950- IF V0PARC-SITUACAO EQUAL '2' */

            if (V0PARC_SITUACAO == "2")
            {

                /*" -3951- MOVE '2' TO V0HICB-SITUACAO */
                _.Move("2", V0HICB_SITUACAO);

                /*" -3952- MOVE 000 TO V0HICB-CODOPER */
                _.Move(000, V0HICB_CODOPER);

                /*" -3954- END-IF. */
            }


            /*" -3956- PERFORM R1415-00-SEL-TITULO. */

            R1415_00_SEL_TITULO_SECTION();

            /*" -3957- IF (V0PROP-NRCERTIF EQUAL 84821639561) */

            if ((V0PROP_NRCERTIF == 84821639561))
            {

                /*" -3958- MOVE '2' TO V0HICB-SITUACAO */
                _.Move("2", V0HICB_SITUACAO);

                /*" -3960- END-IF */
            }


            /*" -3962- IF (V0OPCP-OPCAOPAG EQUAL '3' ) AND (V0HICB-SITUACAO EQUAL '5' ) */

            if ((V0OPCP_OPCAOPAG == "3") && (V0HICB_SITUACAO == "5"))
            {

                /*" -3963- MOVE 7996 TO V0HICB-CODDEVOLV */
                _.Move(7996, V0HICB_CODDEVOLV);

                /*" -3964- ELSE */
            }
            else
            {


                /*" -3965- MOVE 0 TO V0HICB-CODDEVOLV */
                _.Move(0, V0HICB_CODDEVOLV);

                /*" -3967- END-IF. */
            }


            /*" -3969- MOVE V0OPCP-OPCAOPAG TO V0HICB-OPCAO-PGTO */
            _.Move(V0OPCP_OPCAOPAG, V0HICB_OPCAO_PGTO);

            /*" -3987- PERFORM R1400_00_GERA_HIST_COBRANCA_DB_INSERT_1 */

            R1400_00_GERA_HIST_COBRANCA_DB_INSERT_1();

            /*" -3990- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -3991- DISPLAY 'R1400-00 (ERRO - INSERT V0HISTCOBVA)' */
                _.Display($"R1400-00 (ERRO - INSERT V0HISTCOBVA)");

                /*" -3994- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF '  ' 'PARCEL: ' V0PROP-NRPARCEL '  ' 'NRTIT : ' W-TITULO */

                $"CERTIF: {V0PROP_NRCERTIF}  PARCEL: {V0PROP_NRPARCEL}  NRTIT : {W_TITULO}"
                .Display();

                /*" -3995- MOVE 'F' TO WS-TIPO-MENSAGEM */
                _.Move("F", WS_TIPO_MENSAGEM);

                /*" -3996- MOVE '14000' TO WNR-EXEC-SQL */
                _.Move("14000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -3998- MOVE 'ERRO NA INCLUSAO DA TABELA V0HISTCOBVA ' TO WS-MSG-DESCRICAO */
                _.Move("ERRO NA INCLUSAO DA TABELA V0HISTCOBVA ", WS_MSG_DESCRICAO);

                /*" -3999- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3999- END-IF. */
            }


        }

        [StopWatch]
        /*" R1400-00-GERA-HIST-COBRANCA-DB-INSERT-1 */
        public void R1400_00_GERA_HIST_COBRANCA_DB_INSERT_1()
        {
            /*" -3987- EXEC SQL INSERT INTO SEGUROS.V0HISTCOBVA VALUES (:V0PROP-NRCERTIF, :V0PROP-NRPARCEL, :W-TITULO, :V0HICB-DTVENCTO, :WHOST-VLPREMIO-W, :V0OPCP-OPCAOPAG, :V0HICB-SITUACAO, :V0HICB-CODOPER, 0, :V0HICB-CODDEVOLV, 0, 0, 0, 0) END-EXEC. */

            var r1400_00_GERA_HIST_COBRANCA_DB_INSERT_1_Insert1 = new R1400_00_GERA_HIST_COBRANCA_DB_INSERT_1_Insert1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
                W_TITULO = W_TITULO.ToString(),
                V0HICB_DTVENCTO = V0HICB_DTVENCTO.ToString(),
                WHOST_VLPREMIO_W = WHOST_VLPREMIO_W.ToString(),
                V0OPCP_OPCAOPAG = V0OPCP_OPCAOPAG.ToString(),
                V0HICB_SITUACAO = V0HICB_SITUACAO.ToString(),
                V0HICB_CODOPER = V0HICB_CODOPER.ToString(),
                V0HICB_CODDEVOLV = V0HICB_CODDEVOLV.ToString(),
            };

            R1400_00_GERA_HIST_COBRANCA_DB_INSERT_1_Insert1.Execute(r1400_00_GERA_HIST_COBRANCA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1410-00-GERA-HIST-COBRANCA-SECTION */
        private void R1410_00_GERA_HIST_COBRANCA_SECTION()
        {
            /*" -4008- MOVE 'R1410' TO WNR-EXEC-SQL. */
            _.Move("R1410", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4010- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4019- PERFORM R1410_00_GERA_HIST_COBRANCA_DB_SELECT_1 */

            R1410_00_GERA_HIST_COBRANCA_DB_SELECT_1();

            /*" -4022- IF (SQLCODE NOT EQUAL ZEROES) */

            if ((DB.SQLCODE != 00))
            {

                /*" -4023- DISPLAY 'PROBLEMA NO ACESSO A V0PARCELVA ' */
                _.Display($"PROBLEMA NO ACESSO A V0PARCELVA ");

                /*" -4024- DISPLAY 'CERTIFICADO ' V0PROP-NRCERTIF */
                _.Display($"CERTIFICADO {V0PROP_NRCERTIF}");

                /*" -4025- DISPLAY 'PARCELA     ' V0RELA-NRPARCEL */
                _.Display($"PARCELA     {V0RELA_NRPARCEL}");

                /*" -4026- MOVE 'F' TO WS-TIPO-MENSAGEM */
                _.Move("F", WS_TIPO_MENSAGEM);

                /*" -4027- MOVE '14150' TO WNR-EXEC-SQL */
                _.Move("14150", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -4029- MOVE 'ERRO NA CONSULTA DA TABELA V0PARCELVA ' TO WS-MSG-DESCRICAO */
                _.Move("ERRO NA CONSULTA DA TABELA V0PARCELVA ", WS_MSG_DESCRICAO);

                /*" -4030- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4032- END-IF. */
            }


            /*" -4034- PERFORM R1415-00-SEL-TITULO. */

            R1415_00_SEL_TITULO_SECTION();

            /*" -4035- IF (V0PROP-NRCERTIF EQUAL 84821639561) */

            if ((V0PROP_NRCERTIF == 84821639561))
            {

                /*" -4036- MOVE '2' TO V0PARC-SITUACAO1 */
                _.Move("2", V0PARC_SITUACAO1);

                /*" -4038- END-IF */
            }


            /*" -4054- PERFORM R1410_00_GERA_HIST_COBRANCA_DB_INSERT_1 */

            R1410_00_GERA_HIST_COBRANCA_DB_INSERT_1();

            /*" -4057- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -4058- DISPLAY 'R1411-00 (ERRO - INSERT V0HISTCOBVA)' */
                _.Display($"R1411-00 (ERRO - INSERT V0HISTCOBVA)");

                /*" -4061- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF '  ' 'PARCEL: ' V0PROP-NRPARCEL '  ' 'NRTIT : ' W-TITULO */

                $"CERTIF: {V0PROP_NRCERTIF}  PARCEL: {V0PROP_NRPARCEL}  NRTIT : {W_TITULO}"
                .Display();

                /*" -4062- MOVE 'F' TO WS-TIPO-MENSAGEM */
                _.Move("F", WS_TIPO_MENSAGEM);

                /*" -4063- MOVE '14110' TO WNR-EXEC-SQL */
                _.Move("14110", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -4065- MOVE 'ERRO NA INCLUSAO DA TABELA V0HISTCOBVA ' TO WS-MSG-DESCRICAO */
                _.Move("ERRO NA INCLUSAO DA TABELA V0HISTCOBVA ", WS_MSG_DESCRICAO);

                /*" -4066- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4068- END-IF. */
            }


            /*" -4079- PERFORM R1410_00_GERA_HIST_COBRANCA_DB_SELECT_2 */

            R1410_00_GERA_HIST_COBRANCA_DB_SELECT_2();

            /*" -4082- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -4083- DISPLAY 'PROBLEMA NO ACESSO A V0HISTCOBVA' */
                _.Display($"PROBLEMA NO ACESSO A V0HISTCOBVA");

                /*" -4084- DISPLAY 'CERTIFICADO ' V0PROP-NRCERTIF */
                _.Display($"CERTIFICADO {V0PROP_NRCERTIF}");

                /*" -4085- DISPLAY 'PARCELA     ' V0RELA-NRPARCEL */
                _.Display($"PARCELA     {V0RELA_NRPARCEL}");

                /*" -4086- MOVE 'F' TO WS-TIPO-MENSAGEM */
                _.Move("F", WS_TIPO_MENSAGEM);

                /*" -4087- MOVE '14113' TO WNR-EXEC-SQL */
                _.Move("14113", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -4089- MOVE 'ERRO NA CONSULTA DA TABELA V0HISTCOBVA ' TO WS-MSG-DESCRICAO */
                _.Move("ERRO NA CONSULTA DA TABELA V0HISTCOBVA ", WS_MSG_DESCRICAO);

                /*" -4090- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4092- END-IF. */
            }


            /*" -4098- PERFORM R1410_00_GERA_HIST_COBRANCA_DB_UPDATE_1 */

            R1410_00_GERA_HIST_COBRANCA_DB_UPDATE_1();

            /*" -4101- IF SQLCODE NOT EQUAL ZEROES AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -4102- DISPLAY 'PROBLEMA UPDATE PARCEVID        ' */
                _.Display($"PROBLEMA UPDATE PARCEVID        ");

                /*" -4103- DISPLAY 'CERTIFICADO ' V0PROP-NRCERTIF */
                _.Display($"CERTIFICADO {V0PROP_NRCERTIF}");

                /*" -4104- DISPLAY 'PARCELA     ' V0RELA-NRPARCEL */
                _.Display($"PARCELA     {V0RELA_NRPARCEL}");

                /*" -4105- MOVE 'F' TO WS-TIPO-MENSAGEM */
                _.Move("F", WS_TIPO_MENSAGEM);

                /*" -4106- MOVE '14114' TO WNR-EXEC-SQL */
                _.Move("14114", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -4108- MOVE 'ERRO NA ALTERACAO DA TABELA PARCELAS_VIDAZUL ' TO WS-MSG-DESCRICAO */
                _.Move("ERRO NA ALTERACAO DA TABELA PARCELAS_VIDAZUL ", WS_MSG_DESCRICAO);

                /*" -4109- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4111- END-IF. */
            }


            /*" -4117- PERFORM R1410_00_GERA_HIST_COBRANCA_DB_UPDATE_2 */

            R1410_00_GERA_HIST_COBRANCA_DB_UPDATE_2();

            /*" -4120- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -4121- DISPLAY 'PROBLEMA UPDATE COBHISVI        ' */
                _.Display($"PROBLEMA UPDATE COBHISVI        ");

                /*" -4122- DISPLAY 'CERTIFICADO ' V0PROP-NRCERTIF */
                _.Display($"CERTIFICADO {V0PROP_NRCERTIF}");

                /*" -4123- DISPLAY 'PARCELA     ' V0RELA-NRPARCEL */
                _.Display($"PARCELA     {V0RELA_NRPARCEL}");

                /*" -4124- MOVE 'F' TO WS-TIPO-MENSAGEM */
                _.Move("F", WS_TIPO_MENSAGEM);

                /*" -4125- MOVE '14115' TO WNR-EXEC-SQL */
                _.Move("14115", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -4127- MOVE 'ERRO NA ALTERACAO DA TABELA COBER_HIST_VIDAZUL ' TO WS-MSG-DESCRICAO */
                _.Move("ERRO NA ALTERACAO DA TABELA COBER_HIST_VIDAZUL ", WS_MSG_DESCRICAO);

                /*" -4128- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4130- END-IF. */
            }


            /*" -4136- PERFORM R1410_00_GERA_HIST_COBRANCA_DB_UPDATE_3 */

            R1410_00_GERA_HIST_COBRANCA_DB_UPDATE_3();

            /*" -4139- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -4140- CONTINUE */

                /*" -4141- ELSE */
            }
            else
            {


                /*" -4143- IF SQLCODE EQUAL 100 AND V0OPCP-OPCAOPAG EQUAL '3' */

                if (DB.SQLCODE == 100 && V0OPCP_OPCAOPAG == "3")
                {

                    /*" -4144- CONTINUE */

                    /*" -4145- ELSE */
                }
                else
                {


                    /*" -4146- DISPLAY 'PROBLEMA UPDATE HISLANCT        ' */
                    _.Display($"PROBLEMA UPDATE HISLANCT        ");

                    /*" -4147- DISPLAY 'CERTIFICADO ' V0PROP-NRCERTIF */
                    _.Display($"CERTIFICADO {V0PROP_NRCERTIF}");

                    /*" -4148- DISPLAY 'PARCELA     ' V0RELA-NRPARCEL */
                    _.Display($"PARCELA     {V0RELA_NRPARCEL}");

                    /*" -4149- MOVE 'F' TO WS-TIPO-MENSAGEM */
                    _.Move("F", WS_TIPO_MENSAGEM);

                    /*" -4150- MOVE '14116' TO WNR-EXEC-SQL */
                    _.Move("14116", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -4152- MOVE 'ERRO NA ALTERACAO DA TABELA HIST_LANC_CTA ' TO WS-MSG-DESCRICAO */
                    _.Move("ERRO NA ALTERACAO DA TABELA HIST_LANC_CTA ", WS_MSG_DESCRICAO);

                    /*" -4153- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4154- END-IF */
                }


                /*" -4154- END-IF. */
            }


        }

        [StopWatch]
        /*" R1410-00-GERA-HIST-COBRANCA-DB-SELECT-1 */
        public void R1410_00_GERA_HIST_COBRANCA_DB_SELECT_1()
        {
            /*" -4019- EXEC SQL SELECT SITUACAO, DTVENCTO INTO :V0PARC-SITUACAO1, :V0PARC-DTVENCTO FROM SEGUROS.V0PARCELVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND NRPARCEL = :V0RELA-NRPARCEL WITH UR END-EXEC. */

            var r1410_00_GERA_HIST_COBRANCA_DB_SELECT_1_Query1 = new R1410_00_GERA_HIST_COBRANCA_DB_SELECT_1_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0RELA_NRPARCEL = V0RELA_NRPARCEL.ToString(),
            };

            var executed_1 = R1410_00_GERA_HIST_COBRANCA_DB_SELECT_1_Query1.Execute(r1410_00_GERA_HIST_COBRANCA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PARC_SITUACAO1, V0PARC_SITUACAO1);
                _.Move(executed_1.V0PARC_DTVENCTO, V0PARC_DTVENCTO);
            }


        }

        [StopWatch]
        /*" R1410-00-GERA-HIST-COBRANCA-DB-INSERT-1 */
        public void R1410_00_GERA_HIST_COBRANCA_DB_INSERT_1()
        {
            /*" -4054- EXEC SQL INSERT INTO SEGUROS.V0HISTCOBVA VALUES (:V0PROP-NRCERTIF, :V0RELA-NRPARCEL, :W-TITULO, :V0PARC-DTVENCTO, :WHOST-VLPREMIO-W, :V0OPCP-OPCAOPAG, :V0PARC-SITUACAO1, :V0HICB-CODOPER, 0, 0, 0, 0, 0, 0) END-EXEC. */

            var r1410_00_GERA_HIST_COBRANCA_DB_INSERT_1_Insert1 = new R1410_00_GERA_HIST_COBRANCA_DB_INSERT_1_Insert1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0RELA_NRPARCEL = V0RELA_NRPARCEL.ToString(),
                W_TITULO = W_TITULO.ToString(),
                V0PARC_DTVENCTO = V0PARC_DTVENCTO.ToString(),
                WHOST_VLPREMIO_W = WHOST_VLPREMIO_W.ToString(),
                V0OPCP_OPCAOPAG = V0OPCP_OPCAOPAG.ToString(),
                V0PARC_SITUACAO1 = V0PARC_SITUACAO1.ToString(),
                V0HICB_CODOPER = V0HICB_CODOPER.ToString(),
            };

            R1410_00_GERA_HIST_COBRANCA_DB_INSERT_1_Insert1.Execute(r1410_00_GERA_HIST_COBRANCA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1410_99_SAIDA*/

        [StopWatch]
        /*" R1410-00-GERA-HIST-COBRANCA-DB-UPDATE-1 */
        public void R1410_00_GERA_HIST_COBRANCA_DB_UPDATE_1()
        {
            /*" -4098- EXEC SQL UPDATE SEGUROS.PARCELAS_VIDAZUL SET SIT_REGISTRO = '2' WHERE NUM_CERTIFICADO = :V0PROP-NRCERTIF AND NUM_PARCELA = :V0RELA-NRPARCEL AND SIT_REGISTRO <> '1' END-EXEC. */

            var r1410_00_GERA_HIST_COBRANCA_DB_UPDATE_1_Update1 = new R1410_00_GERA_HIST_COBRANCA_DB_UPDATE_1_Update1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0RELA_NRPARCEL = V0RELA_NRPARCEL.ToString(),
            };

            R1410_00_GERA_HIST_COBRANCA_DB_UPDATE_1_Update1.Execute(r1410_00_GERA_HIST_COBRANCA_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1410-00-GERA-HIST-COBRANCA-DB-SELECT-2 */
        public void R1410_00_GERA_HIST_COBRANCA_DB_SELECT_2()
        {
            /*" -4079- EXEC SQL SELECT NRTIT, DTVENCTO INTO :V0RELA-NRTIT, :V0RELA-DTVENCTO FROM SEGUROS.V0HISTCOBVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND NRPARCEL = :V0RELA-NRPARCEL ORDER BY NRTIT FETCH FIRST 1 ROW ONLY WITH UR END-EXEC. */

            var r1410_00_GERA_HIST_COBRANCA_DB_SELECT_2_Query1 = new R1410_00_GERA_HIST_COBRANCA_DB_SELECT_2_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0RELA_NRPARCEL = V0RELA_NRPARCEL.ToString(),
            };

            var executed_1 = R1410_00_GERA_HIST_COBRANCA_DB_SELECT_2_Query1.Execute(r1410_00_GERA_HIST_COBRANCA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RELA_NRTIT, V0RELA_NRTIT);
                _.Move(executed_1.V0RELA_DTVENCTO, V0RELA_DTVENCTO);
            }


        }

        [StopWatch]
        /*" R1410-00-GERA-HIST-COBRANCA-DB-UPDATE-2 */
        public void R1410_00_GERA_HIST_COBRANCA_DB_UPDATE_2()
        {
            /*" -4117- EXEC SQL UPDATE SEGUROS.COBER_HIST_VIDAZUL SET SIT_REGISTRO = '2' WHERE NUM_CERTIFICADO = :V0PROP-NRCERTIF AND NUM_PARCELA = :V0RELA-NRPARCEL AND SIT_REGISTRO <> '1' END-EXEC. */

            var r1410_00_GERA_HIST_COBRANCA_DB_UPDATE_2_Update1 = new R1410_00_GERA_HIST_COBRANCA_DB_UPDATE_2_Update1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0RELA_NRPARCEL = V0RELA_NRPARCEL.ToString(),
            };

            R1410_00_GERA_HIST_COBRANCA_DB_UPDATE_2_Update1.Execute(r1410_00_GERA_HIST_COBRANCA_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R1415-00-SEL-TITULO-SECTION */
        private void R1415_00_SEL_TITULO_SECTION()
        {
            /*" -4163- MOVE 'R1415' TO WNR-EXEC-SQL. */
            _.Move("R1415", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4165- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4166- IF V0OPCP-OPCAOPAG EQUAL '1' OR '2' OR '5' */

            if (V0OPCP_OPCAOPAG.In("1", "2", "5"))
            {

                /*" -4170- PERFORM R1415_00_SEL_TITULO_DB_UPDATE_1 */

                R1415_00_SEL_TITULO_DB_UPDATE_1();

                /*" -4173- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -4174- DISPLAY 'ERRO UPDATE CEDENTE 36' */
                    _.Display($"ERRO UPDATE CEDENTE 36");

                    /*" -4175- MOVE 'F' TO WS-TIPO-MENSAGEM */
                    _.Move("F", WS_TIPO_MENSAGEM);

                    /*" -4176- MOVE '14150' TO WNR-EXEC-SQL */
                    _.Move("14150", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -4178- MOVE 'ERRO NA ALTERACAO DA TABELA CEDENTE ' TO WS-MSG-DESCRICAO */
                    _.Move("ERRO NA ALTERACAO DA TABELA CEDENTE ", WS_MSG_DESCRICAO);

                    /*" -4179- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4181- END-IF */
                }


                /*" -4187- PERFORM R1415_00_SEL_TITULO_DB_SELECT_1 */

                R1415_00_SEL_TITULO_DB_SELECT_1();

                /*" -4190- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -4191- DISPLAY 'PROBLEMAS NO SELECT DA CEDENTE' */
                    _.Display($"PROBLEMAS NO SELECT DA CEDENTE");

                    /*" -4192- MOVE 'F' TO WS-TIPO-MENSAGEM */
                    _.Move("F", WS_TIPO_MENSAGEM);

                    /*" -4193- MOVE '14151' TO WNR-EXEC-SQL */
                    _.Move("14151", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -4195- MOVE 'ERRO NA CONSULTA DA TABELA CEDENTE ' TO WS-MSG-DESCRICAO */
                    _.Move("ERRO NA CONSULTA DA TABELA CEDENTE ", WS_MSG_DESCRICAO);

                    /*" -4196- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4197- END-IF */
                }


                /*" -4199- MOVE CEDENTE-NUM-TITULO TO W-TITULO */
                _.Move(CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO, W_TITULO);

                /*" -4201- ELSE */
            }
            else
            {


                /*" -4207- PERFORM R1415_00_SEL_TITULO_DB_SELECT_2 */

                R1415_00_SEL_TITULO_DB_SELECT_2();

                /*" -4210- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -4211- DISPLAY 'PROBLEMAS NA V0BANCO' */
                    _.Display($"PROBLEMAS NA V0BANCO");

                    /*" -4212- MOVE 'F' TO WS-TIPO-MENSAGEM */
                    _.Move("F", WS_TIPO_MENSAGEM);

                    /*" -4213- MOVE '14152' TO WNR-EXEC-SQL */
                    _.Move("14152", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -4215- MOVE 'ERRO NA CONSULTA DA TABELA V0BANCO ' TO WS-MSG-DESCRICAO */
                    _.Move("ERRO NA CONSULTA DA TABELA V0BANCO ", WS_MSG_DESCRICAO);

                    /*" -4216- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4218- END-IF */
                }


                /*" -4219- MOVE V0BANC-NRTIT TO W-NUMR-TITULO */
                _.Move(V0BANC_NRTIT, W_NUMR_TITULO);

                /*" -4221- ADD 1 TO WTITL-SEQUENCIA */
                FILLER_57.WTITL_SEQUENCIA.Value = FILLER_57.WTITL_SEQUENCIA + 1;

                /*" -4223- MOVE WTITL-SEQUENCIA TO DPARM01 */
                _.Move(FILLER_57.WTITL_SEQUENCIA, DPARM01X.DPARM01);

                /*" -4225- CALL 'PROTIT01' USING DPARM01X */
                _.Call("PROTIT01", DPARM01X);

                /*" -4226- IF DPARM01-RC NOT EQUAL +0 */

                if (DPARM01X.DPARM01_RC != +0)
                {

                    /*" -4227- DISPLAY 'ERRO CHAMADA PROTIT01' */
                    _.Display($"ERRO CHAMADA PROTIT01");

                    /*" -4228- DISPLAY 'CERTIFICADO     ' V0PROP-NRCERTIF */
                    _.Display($"CERTIFICADO     {V0PROP_NRCERTIF}");

                    /*" -4229- DISPLAY 'AREA            ' DPARM01X */
                    _.Display($"AREA            {DPARM01X}");

                    /*" -4230- MOVE 'F' TO WS-TIPO-MENSAGEM */
                    _.Move("F", WS_TIPO_MENSAGEM);

                    /*" -4231- MOVE '14153' TO WNR-EXEC-SQL */
                    _.Move("14153", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -4233- MOVE 'ERRO NA CHAMADA DA SUBROTINA PROTIT01 ' TO WS-MSG-DESCRICAO */
                    _.Move("ERRO NA CHAMADA DA SUBROTINA PROTIT01 ", WS_MSG_DESCRICAO);

                    /*" -4234- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4236- END-IF */
                }


                /*" -4237- MOVE DPARM01-D1 TO WTITL-DIGITO */
                _.Move(DPARM01X.DPARM01_D1, FILLER_57.WTITL_DIGITO);

                /*" -4238- MOVE W-NUMR-TITULO TO V0BANC-NRTIT */
                _.Move(W_NUMR_TITULO, V0BANC_NRTIT);

                /*" -4240- MOVE W-NUMR-TITULO TO W-TITULO */
                _.Move(W_NUMR_TITULO, W_TITULO);

                /*" -4244- PERFORM R1415_00_SEL_TITULO_DB_UPDATE_2 */

                R1415_00_SEL_TITULO_DB_UPDATE_2();

                /*" -4247- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -4248- DISPLAY 'ERRO UPDATE V0BANCO 104' */
                    _.Display($"ERRO UPDATE V0BANCO 104");

                    /*" -4249- MOVE 'F' TO WS-TIPO-MENSAGEM */
                    _.Move("F", WS_TIPO_MENSAGEM);

                    /*" -4250- MOVE '14154' TO WNR-EXEC-SQL */
                    _.Move("14154", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -4252- MOVE 'ERRO NA ALTERACAO DA TABELA V0BANCO ' TO WS-MSG-DESCRICAO */
                    _.Move("ERRO NA ALTERACAO DA TABELA V0BANCO ", WS_MSG_DESCRICAO);

                    /*" -4253- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4254- END-IF */
                }


                /*" -4255- END-IF. */
            }


        }

        [StopWatch]
        /*" R1415-00-SEL-TITULO-DB-UPDATE-1 */
        public void R1415_00_SEL_TITULO_DB_UPDATE_1()
        {
            /*" -4170- EXEC SQL UPDATE SEGUROS.CEDENTE SET NUM_TITULO = NUM_TITULO + 1 WHERE COD_CEDENTE = 36 END-EXEC */

            var r1415_00_SEL_TITULO_DB_UPDATE_1_Update1 = new R1415_00_SEL_TITULO_DB_UPDATE_1_Update1()
            {
            };

            R1415_00_SEL_TITULO_DB_UPDATE_1_Update1.Execute(r1415_00_SEL_TITULO_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1415-00-SEL-TITULO-DB-SELECT-1 */
        public void R1415_00_SEL_TITULO_DB_SELECT_1()
        {
            /*" -4187- EXEC SQL SELECT NUM_TITULO INTO :CEDENTE-NUM-TITULO FROM SEGUROS.CEDENTE WHERE COD_CEDENTE = 36 WITH UR END-EXEC */

            var r1415_00_SEL_TITULO_DB_SELECT_1_Query1 = new R1415_00_SEL_TITULO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R1415_00_SEL_TITULO_DB_SELECT_1_Query1.Execute(r1415_00_SEL_TITULO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CEDENTE_NUM_TITULO, CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO);
            }


        }

        [StopWatch]
        /*" R1410-00-GERA-HIST-COBRANCA-DB-UPDATE-3 */
        public void R1410_00_GERA_HIST_COBRANCA_DB_UPDATE_3()
        {
            /*" -4136- EXEC SQL UPDATE SEGUROS.HIST_LANC_CTA SET SIT_REGISTRO = '2' WHERE NUM_CERTIFICADO = :V0PROP-NRCERTIF AND NUM_PARCELA = :V0RELA-NRPARCEL AND SIT_REGISTRO <> '1' END-EXEC. */

            var r1410_00_GERA_HIST_COBRANCA_DB_UPDATE_3_Update1 = new R1410_00_GERA_HIST_COBRANCA_DB_UPDATE_3_Update1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0RELA_NRPARCEL = V0RELA_NRPARCEL.ToString(),
            };

            R1410_00_GERA_HIST_COBRANCA_DB_UPDATE_3_Update1.Execute(r1410_00_GERA_HIST_COBRANCA_DB_UPDATE_3_Update1);

        }

        [StopWatch]
        /*" R1415-00-SEL-TITULO-DB-SELECT-2 */
        public void R1415_00_SEL_TITULO_DB_SELECT_2()
        {
            /*" -4207- EXEC SQL SELECT NRTIT INTO :V0BANC-NRTIT FROM SEGUROS.V0BANCO WHERE BANCO = 104 WITH UR END-EXEC */

            var r1415_00_SEL_TITULO_DB_SELECT_2_Query1 = new R1415_00_SEL_TITULO_DB_SELECT_2_Query1()
            {
            };

            var executed_1 = R1415_00_SEL_TITULO_DB_SELECT_2_Query1.Execute(r1415_00_SEL_TITULO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0BANC_NRTIT, V0BANC_NRTIT);
            }


        }

        [StopWatch]
        /*" R1415-00-SEL-TITULO-DB-UPDATE-2 */
        public void R1415_00_SEL_TITULO_DB_UPDATE_2()
        {
            /*" -4244- EXEC SQL UPDATE SEGUROS.V0BANCO SET NRTIT = :V0BANC-NRTIT WHERE BANCO = 104 END-EXEC */

            var r1415_00_SEL_TITULO_DB_UPDATE_2_Update1 = new R1415_00_SEL_TITULO_DB_UPDATE_2_Update1()
            {
                V0BANC_NRTIT = V0BANC_NRTIT.ToString(),
            };

            R1415_00_SEL_TITULO_DB_UPDATE_2_Update1.Execute(r1415_00_SEL_TITULO_DB_UPDATE_2_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1415_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-TRATA-V0DIFPARCELVA-SECTION */
        private void R1500_00_TRATA_V0DIFPARCELVA_SECTION()
        {
            /*" -4265- MOVE 'R1500' TO WNR-EXEC-SQL. */
            _.Move("R1500", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4267- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4280- PERFORM R1500_00_TRATA_V0DIFPARCELVA_DB_DECLARE_1 */

            R1500_00_TRATA_V0DIFPARCELVA_DB_DECLARE_1();

            /*" -4282- PERFORM R1500_00_TRATA_V0DIFPARCELVA_DB_OPEN_1 */

            R1500_00_TRATA_V0DIFPARCELVA_DB_OPEN_1();

            /*" -4285- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4286- DISPLAY 'PROBLEMAS NO OPEN (CDIFPAR   ) ... ' */
                _.Display($"PROBLEMAS NO OPEN (CDIFPAR   ) ... ");

                /*" -4287- MOVE 'F' TO WS-TIPO-MENSAGEM */
                _.Move("F", WS_TIPO_MENSAGEM);

                /*" -4288- MOVE '15000' TO WNR-EXEC-SQL */
                _.Move("15000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -4290- MOVE 'ERRO NA CONSULTA DA TABELA V0DIFPARCELVA ' TO WS-MSG-DESCRICAO */
                _.Move("ERRO NA CONSULTA DA TABELA V0DIFPARCELVA ", WS_MSG_DESCRICAO);

                /*" -4291- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4293- END-IF. */
            }


            /*" -4294- MOVE SPACES TO WFIM-CDIFPAR. */
            _.Move("", AREA_DE_WORK.WFIM_CDIFPAR);

            /*" -4295- MOVE V0COBP-VLPREMIO TO WHOST-VLPREMIO. */
            _.Move(V0COBP_VLPREMIO, WHOST_VLPREMIO);

            /*" -4296- MOVE V0COBP-PRMVG TO WHOST-PRMVG. */
            _.Move(V0COBP_PRMVG, WHOST_PRMVG);

            /*" -4298- MOVE V0COBP-PRMAP TO WHOST-PRMAP. */
            _.Move(V0COBP_PRMAP, WHOST_PRMAP);

            /*" -4300- PERFORM R1510-00-FETCH-CDIFPAR. */

            R1510_00_FETCH_CDIFPAR_SECTION();

            /*" -4301- IF WFIM-CDIFPAR NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_CDIFPAR.IsEmpty())
            {

                /*" -4302- GO TO R1500-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/ //GOTO
                return;

                /*" -4302- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R1500_10_LOOP_CDIFPAR */

            R1500_10_LOOP_CDIFPAR();

        }

        [StopWatch]
        /*" R1500-00-TRATA-V0DIFPARCELVA-DB-OPEN-1 */
        public void R1500_00_TRATA_V0DIFPARCELVA_DB_OPEN_1()
        {
            /*" -4282- EXEC SQL OPEN CDIFPAR END-EXEC. */

            CDIFPAR.Open();

        }

        [StopWatch]
        /*" R7000-GERAR-PARC-ATRASO-DB-DECLARE-1 */
        public void R7000_GERAR_PARC_ATRASO_DB_DECLARE_1()
        {
            /*" -4945- EXEC SQL DECLARE CGERARAT CURSOR FOR SELECT NUM_PARCELA FROM SEGUROS.PARCELAS_VIDAZUL WHERE NUM_CERTIFICADO = :V0PROP-NRCERTIF AND SIT_REGISTRO IN ( ' ' , '0' , X'00' ) ORDER BY NUM_PARCELA DESC WITH UR END-EXEC. */
            CGERARAT = new VA0853B_CGERARAT(true);
            string GetQuery_CGERARAT()
            {
                var query = @$"SELECT NUM_PARCELA 
							FROM SEGUROS.PARCELAS_VIDAZUL 
							WHERE NUM_CERTIFICADO = '{V0PROP_NRCERTIF}' 
							AND SIT_REGISTRO IN ( ' '
							, '0'
							, X'00' ) 
							ORDER BY NUM_PARCELA DESC";

                return query;
            }
            CGERARAT.GetQueryEvent += GetQuery_CGERARAT;

        }

        [StopWatch]
        /*" R1500-10-LOOP-CDIFPAR */
        private void R1500_10_LOOP_CDIFPAR(bool isPerform = false)
        {
            /*" -4308- IF (V0DIFP-CODOPER > 599) AND (V0DIFP-CODOPER < 700) */

            if ((V0DIFP_CODOPER > 599) && (V0DIFP_CODOPER < 700))
            {

                /*" -4309- IF V0COBP-PRMVG > ZEROS */

                if (V0COBP_PRMVG > 00)
                {

                    /*" -4310- COMPUTE WHOST-PRMVG = WHOST-PRMVG - V0DIFP-PRMDIFVG */
                    WHOST_PRMVG.Value = WHOST_PRMVG - V0DIFP_PRMDIFVG;

                    /*" -4312- END-IF */
                }


                /*" -4313- IF V0COBP-PRMAP > ZEROS */

                if (V0COBP_PRMAP > 00)
                {

                    /*" -4314- COMPUTE WHOST-PRMAP = WHOST-PRMAP - V0DIFP-PRMDIFAP */
                    WHOST_PRMAP.Value = WHOST_PRMAP - V0DIFP_PRMDIFAP;

                    /*" -4316- END-IF */
                }


                /*" -4317- COMPUTE WHOST-VLPREMIO = WHOST-PRMVG + WHOST-PRMAP */
                WHOST_VLPREMIO.Value = WHOST_PRMVG + WHOST_PRMAP;

                /*" -4319- END-IF. */
            }


            /*" -4321- IF (V0DIFP-CODOPER > 399) AND (V0DIFP-CODOPER < 500) */

            if ((V0DIFP_CODOPER > 399) && (V0DIFP_CODOPER < 500))
            {

                /*" -4322- COMPUTE WHOST-PRMVG = WHOST-PRMVG + V0DIFP-PRMDIFVG */
                WHOST_PRMVG.Value = WHOST_PRMVG + V0DIFP_PRMDIFVG;

                /*" -4323- COMPUTE WHOST-PRMAP = WHOST-PRMAP + V0DIFP-PRMDIFAP */
                WHOST_PRMAP.Value = WHOST_PRMAP + V0DIFP_PRMDIFAP;

                /*" -4324- COMPUTE WHOST-VLPREMIO = WHOST-PRMVG + WHOST-PRMAP */
                WHOST_VLPREMIO.Value = WHOST_PRMVG + WHOST_PRMAP;

                /*" -4326- END-IF. */
            }


            /*" -4326- MOVE V0DIFP-CODOPER TO V3DIFP-CODOPER. */
            _.Move(V0DIFP_CODOPER, V3DIFP_CODOPER);

        }

        [StopWatch]
        /*" R1500-10-UPDATE */
        private void R1500_10_UPDATE(bool isPerform = false)
        {
            /*" -4335- PERFORM R1500_10_UPDATE_DB_UPDATE_1 */

            R1500_10_UPDATE_DB_UPDATE_1();

            /*" -4338- IF (SQLCODE EQUAL -803) */

            if ((DB.SQLCODE == -803))
            {

                /*" -4339- COMPUTE V3DIFP-CODOPER = V0DIFP-CODOPER + 10 */
                V3DIFP_CODOPER.Value = V0DIFP_CODOPER + 10;

                /*" -4340- GO TO R1500-10-UPDATE */
                new Task(() => R1500_10_UPDATE()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -4341- ELSE */
            }
            else
            {


                /*" -4342- IF (SQLCODE NOT EQUAL ZEROS) */

                if ((DB.SQLCODE != 00))
                {

                    /*" -4343- DISPLAY 'R1500-00 (ERRO - UPDATE CDIFPAR   )' */
                    _.Display($"R1500-00 (ERRO - UPDATE CDIFPAR   )");

                    /*" -4344- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF */
                    _.Display($"CERTIF: {V0PROP_NRCERTIF}");

                    /*" -4345- MOVE 'F' TO WS-TIPO-MENSAGEM */
                    _.Move("F", WS_TIPO_MENSAGEM);

                    /*" -4346- MOVE '15001' TO WNR-EXEC-SQL */
                    _.Move("15001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -4348- MOVE 'ERRO NA ALTERACAO DA TABELA CDIFPAR ' TO WS-MSG-DESCRICAO */
                    _.Move("ERRO NA ALTERACAO DA TABELA CDIFPAR ", WS_MSG_DESCRICAO);

                    /*" -4349- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4350- END-IF */
                }


                /*" -4350- END-IF. */
            }


        }

        [StopWatch]
        /*" R1500-10-UPDATE-DB-UPDATE-1 */
        public void R1500_10_UPDATE_DB_UPDATE_1()
        {
            /*" -4335- EXEC SQL UPDATE SEGUROS.V0DIFPARCELVA SET NRPARCEL = :V0PROP-NRPARCEL, CODOPER = :V3DIFP-CODOPER WHERE CURRENT OF CDIFPAR END-EXEC. */

            var r1500_10_UPDATE_DB_UPDATE_1_Update1 = new R1500_10_UPDATE_DB_UPDATE_1_Update1(CDIFPAR)
            {
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
                V3DIFP_CODOPER = V3DIFP_CODOPER.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_DTVENCTO = V0PROP_DTVENCTO.ToString(),
            };

            R1500_10_UPDATE_DB_UPDATE_1_Update1.Execute(r1500_10_UPDATE_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1500-20-LE-CDIFPAR */
        private void R1500_20_LE_CDIFPAR(bool isPerform = false)
        {
            /*" -4356- PERFORM R1510-00-FETCH-CDIFPAR. */

            R1510_00_FETCH_CDIFPAR_SECTION();

            /*" -4357- IF (WFIM-CDIFPAR EQUAL SPACES) */

            if ((AREA_DE_WORK.WFIM_CDIFPAR.IsEmpty()))
            {

                /*" -4358- GO TO R1500-10-LOOP-CDIFPAR */

                R1500_10_LOOP_CDIFPAR(); //GOTO
                return;

                /*" -4358- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1510-00-FETCH-CDIFPAR-SECTION */
        private void R1510_00_FETCH_CDIFPAR_SECTION()
        {
            /*" -4367- MOVE 'R1510' TO WNR-EXEC-SQL. */
            _.Move("R1510", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4369- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4375- PERFORM R1510_00_FETCH_CDIFPAR_DB_FETCH_1 */

            R1510_00_FETCH_CDIFPAR_DB_FETCH_1();

            /*" -4378- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -4379- IF SQLCODE EQUAL +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -4379- PERFORM R1510_00_FETCH_CDIFPAR_DB_CLOSE_1 */

                    R1510_00_FETCH_CDIFPAR_DB_CLOSE_1();

                    /*" -4381- MOVE 'S' TO WFIM-CDIFPAR */
                    _.Move("S", AREA_DE_WORK.WFIM_CDIFPAR);

                    /*" -4382- ELSE */
                }
                else
                {


                    /*" -4383- DISPLAY 'R1510-00 (ERRO -  FETCH CDIFPAR   )...' */
                    _.Display($"R1510-00 (ERRO -  FETCH CDIFPAR   )...");

                    /*" -4384- MOVE 'F' TO WS-TIPO-MENSAGEM */
                    _.Move("F", WS_TIPO_MENSAGEM);

                    /*" -4385- MOVE '15101' TO WNR-EXEC-SQL */
                    _.Move("15101", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -4387- MOVE 'ERRO NA CONSULTA DA TABELA CDIFPAR ' TO WS-MSG-DESCRICAO */
                    _.Move("ERRO NA CONSULTA DA TABELA CDIFPAR ", WS_MSG_DESCRICAO);

                    /*" -4388- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4389- END-IF */
                }


                /*" -4389- END-IF. */
            }


        }

        [StopWatch]
        /*" R1510-00-FETCH-CDIFPAR-DB-FETCH-1 */
        public void R1510_00_FETCH_CDIFPAR_DB_FETCH_1()
        {
            /*" -4375- EXEC SQL FETCH CDIFPAR INTO :V0DIFP-NRPARCEL, :V0DIFP-CODOPER, :V0DIFP-VLPRMTOT, :V0DIFP-PRMDIFVG, :V0DIFP-PRMDIFAP END-EXEC. */

            if (CDIFPAR.Fetch())
            {
                _.Move(CDIFPAR.V0DIFP_NRPARCEL, V0DIFP_NRPARCEL);
                _.Move(CDIFPAR.V0DIFP_CODOPER, V0DIFP_CODOPER);
                _.Move(CDIFPAR.V0DIFP_VLPRMTOT, V0DIFP_VLPRMTOT);
                _.Move(CDIFPAR.V0DIFP_PRMDIFVG, V0DIFP_PRMDIFVG);
                _.Move(CDIFPAR.V0DIFP_PRMDIFAP, V0DIFP_PRMDIFAP);
            }

        }

        [StopWatch]
        /*" R1510-00-FETCH-CDIFPAR-DB-CLOSE-1 */
        public void R1510_00_FETCH_CDIFPAR_DB_CLOSE_1()
        {
            /*" -4379- EXEC SQL CLOSE CDIFPAR END-EXEC */

            CDIFPAR.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1510_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-VERIFICA-REPASSE-SECTION */
        private void R1600_00_VERIFICA_REPASSE_SECTION()
        {
            /*" -4400- MOVE 'R1600' TO WNR-EXEC-SQL. */
            _.Move("R1600", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4402- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4408- PERFORM R1600_00_VERIFICA_REPASSE_DB_UPDATE_1 */

            R1600_00_VERIFICA_REPASSE_DB_UPDATE_1();

            /*" -4411- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -4413- DISPLAY 'ERRO UPDATE SEGUROS.V0DIFPARCELVA - SQLCODE = ' SQLCODE */
                _.Display($"ERRO UPDATE SEGUROS.V0DIFPARCELVA - SQLCODE = {DB.SQLCODE}");

                /*" -4414- MOVE 'F' TO WS-TIPO-MENSAGEM */
                _.Move("F", WS_TIPO_MENSAGEM);

                /*" -4415- MOVE '16000' TO WNR-EXEC-SQL */
                _.Move("16000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -4417- MOVE 'ERRO NA ALTERACAO DA TABELA V0DIFPARCELVA ' TO WS-MSG-DESCRICAO */
                _.Move("ERRO NA ALTERACAO DA TABELA V0DIFPARCELVA ", WS_MSG_DESCRICAO);

                /*" -4418- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4420- END-IF. */
            }


            /*" -4427- PERFORM R1600_00_VERIFICA_REPASSE_DB_SELECT_1 */

            R1600_00_VERIFICA_REPASSE_DB_SELECT_1();

            /*" -4430- IF (SQLCODE EQUAL ZEROES) */

            if ((DB.SQLCODE == 00))
            {

                /*" -4431- PERFORM R1650-00-REPASSA-CDG */

                R1650_00_REPASSA_CDG_SECTION();

                /*" -4432- ELSE */
            }
            else
            {


                /*" -4433- IF (SQLCODE NOT EQUAL ZEROES AND +100) */

                if ((!DB.SQLCODE.In("00", "+100")))
                {

                    /*" -4434- MOVE 'F' TO WS-TIPO-MENSAGEM */
                    _.Move("F", WS_TIPO_MENSAGEM);

                    /*" -4435- MOVE '16001' TO WNR-EXEC-SQL */
                    _.Move("16001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -4437- MOVE 'ERRO NA CONSULTA DA TABELA V0CDGCOBER' TO WS-MSG-DESCRICAO */
                    _.Move("ERRO NA CONSULTA DA TABELA V0CDGCOBER", WS_MSG_DESCRICAO);

                    /*" -4438- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4439- END-IF */
                }


                /*" -4441- END-IF. */
            }


            /*" -4448- PERFORM R1600_00_VERIFICA_REPASSE_DB_SELECT_2 */

            R1600_00_VERIFICA_REPASSE_DB_SELECT_2();

            /*" -4451- IF (SQLCODE EQUAL ZEROES) */

            if ((DB.SQLCODE == 00))
            {

                /*" -4452- IF (V0PRDVG-TEM-SAF = 'S' ) */

                if ((V0PRDVG_TEM_SAF == "S"))
                {

                    /*" -4453- PERFORM R1670-00-REPASSA-SAF */

                    R1670_00_REPASSA_SAF_SECTION();

                    /*" -4454- END-IF */
                }


                /*" -4455- ELSE */
            }
            else
            {


                /*" -4456- IF (SQLCODE NOT EQUAL ZEROES AND +100) */

                if ((!DB.SQLCODE.In("00", "+100")))
                {

                    /*" -4457- MOVE 'F' TO WS-TIPO-MENSAGEM */
                    _.Move("F", WS_TIPO_MENSAGEM);

                    /*" -4458- MOVE '16001' TO WNR-EXEC-SQL */
                    _.Move("16001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -4460- MOVE 'ERRO NA CONSULTA DA TABELA V0SAFCOBER' TO WS-MSG-DESCRICAO */
                    _.Move("ERRO NA CONSULTA DA TABELA V0SAFCOBER", WS_MSG_DESCRICAO);

                    /*" -4461- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4462- END-IF */
                }


                /*" -4462- END-IF. */
            }


        }

        [StopWatch]
        /*" R1600-00-VERIFICA-REPASSE-DB-UPDATE-1 */
        public void R1600_00_VERIFICA_REPASSE_DB_UPDATE_1()
        {
            /*" -4408- EXEC SQL UPDATE SEGUROS.V0DIFPARCELVA SET SITUACAO = '1' WHERE NRCERTIF = :V0PROP-NRCERTIF AND NRPARCEL = :V0PROP-NRPARCEL AND SITUACAO = ' ' END-EXEC. */

            var r1600_00_VERIFICA_REPASSE_DB_UPDATE_1_Update1 = new R1600_00_VERIFICA_REPASSE_DB_UPDATE_1_Update1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
            };

            R1600_00_VERIFICA_REPASSE_DB_UPDATE_1_Update1.Execute(r1600_00_VERIFICA_REPASSE_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1600-00-VERIFICA-REPASSE-DB-SELECT-1 */
        public void R1600_00_VERIFICA_REPASSE_DB_SELECT_1()
        {
            /*" -4427- EXEC SQL SELECT VLCUSTCDG INTO :V0CDGC-VLCUSTCDG FROM SEGUROS.V0CDGCOBER WHERE CODCLIEN = :V0PROP-CODCLIEN AND DTTERVIG IN ( '1999-12-31' , '9999-12-31' ) WITH UR END-EXEC. */

            var r1600_00_VERIFICA_REPASSE_DB_SELECT_1_Query1 = new R1600_00_VERIFICA_REPASSE_DB_SELECT_1_Query1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
            };

            var executed_1 = R1600_00_VERIFICA_REPASSE_DB_SELECT_1_Query1.Execute(r1600_00_VERIFICA_REPASSE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CDGC_VLCUSTCDG, V0CDGC_VLCUSTCDG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-VERIFICA-REPASSE-DB-SELECT-2 */
        public void R1600_00_VERIFICA_REPASSE_DB_SELECT_2()
        {
            /*" -4448- EXEC SQL SELECT VLCUSTAUX INTO :V0SAFC-VLCUSTSAF FROM SEGUROS.V0SAFCOBER WHERE CODCLIEN = :V0PROP-CODCLIEN AND DTTERVIG IN ( '1999-12-31' , '9999-12-31' ) WITH UR END-EXEC. */

            var r1600_00_VERIFICA_REPASSE_DB_SELECT_2_Query1 = new R1600_00_VERIFICA_REPASSE_DB_SELECT_2_Query1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
            };

            var executed_1 = R1600_00_VERIFICA_REPASSE_DB_SELECT_2_Query1.Execute(r1600_00_VERIFICA_REPASSE_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SAFC_VLCUSTSAF, V0SAFC_VLCUSTSAF);
            }


        }

        [StopWatch]
        /*" R1650-00-REPASSA-CDG-SECTION */
        private void R1650_00_REPASSA_CDG_SECTION()
        {
            /*" -4471- MOVE 'R1650' TO WNR-EXEC-SQL. */
            _.Move("R1650", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4473- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4474- MOVE V0PROP-DTVENCTO TO WDATA-SISTEMA. */
            _.Move(V0PROP_DTVENCTO, AREA_DE_WORK.WDATA_SISTEMA);

            /*" -4476- MOVE 01 TO WDATA-SIS-DIA. */
            _.Move(01, AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_DIA);

            /*" -4478- ADD V0OPCP-PERIPGTO TO WDATA-SIS-MES. */
            AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES.Value = AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES + V0OPCP_PERIPGTO;

            /*" -4479- IF WDATA-SIS-MES > 12 */

            if (AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES > 12)
            {

                /*" -4480- COMPUTE WDATA-SIS-MES = WDATA-SIS-MES - 12 */
                AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES.Value = AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES - 12;

                /*" -4481- ADD 1 TO WDATA-SIS-ANO */
                AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_ANO.Value = AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_ANO + 1;

                /*" -4483- END-IF. */
            }


            /*" -4485- MOVE WDATA-SISTEMA TO V0RCDG-DTREFER. */
            _.Move(AREA_DE_WORK.WDATA_SISTEMA, V0RCDG_DTREFER);

            /*" -4492- PERFORM R1650_00_REPASSA_CDG_DB_SELECT_1 */

            R1650_00_REPASSA_CDG_DB_SELECT_1();

            /*" -4495- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -4496- GO TO R1650-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1650_99_SAIDA*/ //GOTO
                return;

                /*" -4497- ELSE */
            }
            else
            {


                /*" -4499- IF SQLCODE NOT EQUAL ZEROES AND SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
                {

                    /*" -4500- MOVE 'F' TO WS-TIPO-MENSAGEM */
                    _.Move("F", WS_TIPO_MENSAGEM);

                    /*" -4501- MOVE '16501' TO WNR-EXEC-SQL */
                    _.Move("16501", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -4503- MOVE 'ERRO NA CONSULTA DA TABELA V0REPASSECDG' TO WS-MSG-DESCRICAO */
                    _.Move("ERRO NA CONSULTA DA TABELA V0REPASSECDG", WS_MSG_DESCRICAO);

                    /*" -4504- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4505- END-IF */
                }


                /*" -4507- END-IF. */
            }


            /*" -4518- PERFORM R1650_00_REPASSA_CDG_DB_INSERT_1 */

            R1650_00_REPASSA_CDG_DB_INSERT_1();

            /*" -4521- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -4522- MOVE 'F' TO WS-TIPO-MENSAGEM */
                _.Move("F", WS_TIPO_MENSAGEM);

                /*" -4523- MOVE '16502' TO WNR-EXEC-SQL */
                _.Move("16502", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -4525- MOVE 'ERRO NA INCLUSAO DA TABELA V0REPASSECDG' TO WS-MSG-DESCRICAO */
                _.Move("ERRO NA INCLUSAO DA TABELA V0REPASSECDG", WS_MSG_DESCRICAO);

                /*" -4526- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4526- END-IF. */
            }


        }

        [StopWatch]
        /*" R1650-00-REPASSA-CDG-DB-SELECT-1 */
        public void R1650_00_REPASSA_CDG_DB_SELECT_1()
        {
            /*" -4492- EXEC SQL SELECT SITUACAO INTO :V0RCDG-SITUACAO FROM SEGUROS.V0REPASSECDG WHERE CODCLIEN = :V0PROP-CODCLIEN AND DTREFER = :V0RCDG-DTREFER WITH UR END-EXEC. */

            var r1650_00_REPASSA_CDG_DB_SELECT_1_Query1 = new R1650_00_REPASSA_CDG_DB_SELECT_1_Query1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0RCDG_DTREFER = V0RCDG_DTREFER.ToString(),
            };

            var executed_1 = R1650_00_REPASSA_CDG_DB_SELECT_1_Query1.Execute(r1650_00_REPASSA_CDG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RCDG_SITUACAO, V0RCDG_SITUACAO);
            }


        }

        [StopWatch]
        /*" R1650-00-REPASSA-CDG-DB-INSERT-1 */
        public void R1650_00_REPASSA_CDG_DB_INSERT_1()
        {
            /*" -4518- EXEC SQL INSERT INTO SEGUROS.V0REPASSECDG VALUES (:V0PROP-CODCLIEN, :V0RCDG-DTREFER, :V0CDGC-VLCUSTCDG, :V0PROP-NRCERTIF, :V0PROP-NRPARCEL, '0' , :V1SIST-DTMOVABE, CURRENT TIMESTAMP) END-EXEC. */

            var r1650_00_REPASSA_CDG_DB_INSERT_1_Insert1 = new R1650_00_REPASSA_CDG_DB_INSERT_1_Insert1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0RCDG_DTREFER = V0RCDG_DTREFER.ToString(),
                V0CDGC_VLCUSTCDG = V0CDGC_VLCUSTCDG.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
            };

            R1650_00_REPASSA_CDG_DB_INSERT_1_Insert1.Execute(r1650_00_REPASSA_CDG_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1650_99_SAIDA*/

        [StopWatch]
        /*" R1670-00-REPASSA-SAF-SECTION */
        private void R1670_00_REPASSA_SAF_SECTION()
        {
            /*" -4535- MOVE 'R1670' TO WNR-EXEC-SQL. */
            _.Move("R1670", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4537- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4538- MOVE V0PROP-DTVENCTO TO WDATA-SISTEMA. */
            _.Move(V0PROP_DTVENCTO, AREA_DE_WORK.WDATA_SISTEMA);

            /*" -4540- MOVE 01 TO WDATA-SIS-DIA. */
            _.Move(01, AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_DIA);

            /*" -4542- ADD V0OPCP-PERIPGTO TO WDATA-SIS-MES. */
            AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES.Value = AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES + V0OPCP_PERIPGTO;

            /*" -4543- IF WDATA-SIS-MES > 12 */

            if (AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES > 12)
            {

                /*" -4544- COMPUTE WDATA-SIS-MES = WDATA-SIS-MES - 12 */
                AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES.Value = AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES - 12;

                /*" -4545- ADD 1 TO WDATA-SIS-ANO */
                AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_ANO.Value = AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_ANO + 1;

                /*" -4547- END-IF. */
            }


            /*" -4549- MOVE WDATA-SISTEMA TO V0RSAF-DTREFER. */
            _.Move(AREA_DE_WORK.WDATA_SISTEMA, V0RSAF_DTREFER);

            /*" -4556- PERFORM R1670_00_REPASSA_SAF_DB_SELECT_1 */

            R1670_00_REPASSA_SAF_DB_SELECT_1();

            /*" -4559- IF (SQLCODE EQUAL ZEROES OR -811) */

            if ((DB.SQLCODE.In("00", "-811")))
            {

                /*" -4560- GO TO R1670-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1670_99_SAIDA*/ //GOTO
                return;

                /*" -4561- ELSE */
            }
            else
            {


                /*" -4562- IF (SQLCODE NOT EQUAL ZEROES AND +100) */

                if ((!DB.SQLCODE.In("00", "+100")))
                {

                    /*" -4563- MOVE 'F' TO WS-TIPO-MENSAGEM */
                    _.Move("F", WS_TIPO_MENSAGEM);

                    /*" -4564- MOVE '16700' TO WNR-EXEC-SQL */
                    _.Move("16700", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -4566- MOVE 'ERRO NA CONSULTA DA TABELA V0HISTREPSAF' TO WS-MSG-DESCRICAO */
                    _.Move("ERRO NA CONSULTA DA TABELA V0HISTREPSAF", WS_MSG_DESCRICAO);

                    /*" -4567- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4568- END-IF */
                }


                /*" -4570- END-IF. */
            }


            /*" -4571- IF WREGULARIZOU EQUAL 'S' */

            if (AREA_DE_WORK.WREGULARIZOU == "S")
            {

                /*" -4572- MOVE 501 TO V0RSAF-CODOPER */
                _.Move(501, V0RSAF_CODOPER);

                /*" -4573- PERFORM R1675-00-INSERT-V0HISTREPSAF */

                R1675_00_INSERT_V0HISTREPSAF_SECTION();

                /*" -4575- END-IF. */
            }


            /*" -4576- MOVE 1100 TO V0RSAF-CODOPER. */
            _.Move(1100, V0RSAF_CODOPER);

            /*" -4576- PERFORM R1675-00-INSERT-V0HISTREPSAF. */

            R1675_00_INSERT_V0HISTREPSAF_SECTION();

        }

        [StopWatch]
        /*" R1670-00-REPASSA-SAF-DB-SELECT-1 */
        public void R1670_00_REPASSA_SAF_DB_SELECT_1()
        {
            /*" -4556- EXEC SQL SELECT SITUACAO INTO :V0RSAF-SITUACAO FROM SEGUROS.V0HISTREPSAF WHERE CODCLIEN = :V0PROP-CODCLIEN AND DTREF = :V0RSAF-DTREFER WITH UR END-EXEC. */

            var r1670_00_REPASSA_SAF_DB_SELECT_1_Query1 = new R1670_00_REPASSA_SAF_DB_SELECT_1_Query1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0RSAF_DTREFER = V0RSAF_DTREFER.ToString(),
            };

            var executed_1 = R1670_00_REPASSA_SAF_DB_SELECT_1_Query1.Execute(r1670_00_REPASSA_SAF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RSAF_SITUACAO, V0RSAF_SITUACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1670_99_SAIDA*/

        [StopWatch]
        /*" R1675-00-INSERT-V0HISTREPSAF-SECTION */
        private void R1675_00_INSERT_V0HISTREPSAF_SECTION()
        {
            /*" -4585- MOVE 'R1675' TO WNR-EXEC-SQL. */
            _.Move("R1675", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4587- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4604- PERFORM R1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1 */

            R1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1();

            /*" -4607- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -4608- MOVE 'F' TO WS-TIPO-MENSAGEM */
                _.Move("F", WS_TIPO_MENSAGEM);

                /*" -4609- MOVE '16750' TO WNR-EXEC-SQL */
                _.Move("16750", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -4611- MOVE 'ERRO NA INCLUSAO DA TABELA V0HISTREPSAF' TO WS-MSG-DESCRICAO */
                _.Move("ERRO NA INCLUSAO DA TABELA V0HISTREPSAF", WS_MSG_DESCRICAO);

                /*" -4612- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4612- END-IF. */
            }


        }

        [StopWatch]
        /*" R1675-00-INSERT-V0HISTREPSAF-DB-INSERT-1 */
        public void R1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1()
        {
            /*" -4604- EXEC SQL INSERT INTO SEGUROS.V0HISTREPSAF VALUES (:V0PROP-CODCLIEN, :V0RSAF-DTREFER, :V0PROP-NRCERTIF, :V0PROP-NRPARCEL, :V0PROP-NRMATRFUN, :V0SAFC-VLCUSTSAF, :V0RSAF-CODOPER, '0' , '0' , 0, 0, 'VA0853B' , CURRENT TIMESTAMP, :V0PROP-DTVENCTO:VIND-DTMOVTO) END-EXEC. */

            var r1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1_Insert1 = new R1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1_Insert1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0RSAF_DTREFER = V0RSAF_DTREFER.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
                V0PROP_NRMATRFUN = V0PROP_NRMATRFUN.ToString(),
                V0SAFC_VLCUSTSAF = V0SAFC_VLCUSTSAF.ToString(),
                V0RSAF_CODOPER = V0RSAF_CODOPER.ToString(),
                V0PROP_DTVENCTO = V0PROP_DTVENCTO.ToString(),
                VIND_DTMOVTO = VIND_DTMOVTO.ToString(),
            };

            R1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1_Insert1.Execute(r1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1675_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-CANCELAR-ANUAL-SECTION */
        private void R2000_00_CANCELAR_ANUAL_SECTION()
        {
            /*" -4624- MOVE 'R2000' TO WNR-EXEC-SQL */
            _.Move("R2000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4626- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4627- IF (V0OPCP-OPCAOPAG NOT EQUAL '3' ) */

            if ((V0OPCP_OPCAOPAG != "3"))
            {

                /*" -4629- PERFORM R1015-00-VER-RETORNO-SICOV */

                R1015_00_VER_RETORNO_SICOV_SECTION();

                /*" -4630- IF (WS-TIPO-MENSAGEM NOT EQUAL SPACES) */

                if ((!WS_TIPO_MENSAGEM.IsEmpty()))
                {

                    /*" -4631- GO TO R2000-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/ //GOTO
                    return;

                    /*" -4632- END-IF */
                }


                /*" -4634- END-IF */
            }


            /*" -4636- INITIALIZE REGISTRO-LINKAGE-GE0853S. */
            _.Initialize(
                REGISTRO_LINKAGE_GE0853S
            );

            /*" -4637- MOVE V0PROP-NRCERTIF TO LK-GE853-NUM-CERTIFICADO */
            _.Move(V0PROP_NRCERTIF, REGISTRO_LINKAGE_GE0853S.LK_GE853_NUM_CERTIFICADO);

            /*" -4639- MOVE V0PROP-NRPARCEL TO LK-GE853-NUM-PARCELA */
            _.Move(V0PROP_NRPARCEL, REGISTRO_LINKAGE_GE0853S.LK_GE853_NUM_PARCELA);

            /*" -4639- PERFORM R7210-00-CHAMAR-GE0853S. */

            R7210_00_CHAMAR_GE0853S_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R4500-00-SOLIC-RELAT-SECTION */
        private void R4500_00_SOLIC_RELAT_SECTION()
        {
            /*" -4651- MOVE 'R4500' TO WNR-EXEC-SQL. */
            _.Move("R4500", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4653- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4664- PERFORM R4500_00_SOLIC_RELAT_DB_SELECT_1 */

            R4500_00_SOLIC_RELAT_DB_SELECT_1();

            /*" -4667- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -4668- IF SQLCODE EQUAL +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -4669- PERFORM R1410-00-GERA-HIST-COBRANCA */

                    R1410_00_GERA_HIST_COBRANCA_SECTION();

                    /*" -4670- ELSE */
                }
                else
                {


                    /*" -4671- DISPLAY 'PROBLEMA NO ACESSO A V0HISTCOBVA' */
                    _.Display($"PROBLEMA NO ACESSO A V0HISTCOBVA");

                    /*" -4672- DISPLAY 'CERTIFICADO ' V0PROP-NRCERTIF */
                    _.Display($"CERTIFICADO {V0PROP_NRCERTIF}");

                    /*" -4673- DISPLAY 'PARCELA     ' V0RELA-NRPARCEL */
                    _.Display($"PARCELA     {V0RELA_NRPARCEL}");

                    /*" -4674- MOVE 'F' TO WS-TIPO-MENSAGEM */
                    _.Move("F", WS_TIPO_MENSAGEM);

                    /*" -4675- MOVE '14500' TO WNR-EXEC-SQL */
                    _.Move("14500", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -4677- MOVE 'ERRO NA CONSULTA DA TABELA V0HISTCOBVA' TO WS-MSG-DESCRICAO */
                    _.Move("ERRO NA CONSULTA DA TABELA V0HISTCOBVA", WS_MSG_DESCRICAO);

                    /*" -4678- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4679- END-IF */
                }


                /*" -4681- END-IF. */
            }


            /*" -4724- PERFORM R4500_00_SOLIC_RELAT_DB_INSERT_1 */

            R4500_00_SOLIC_RELAT_DB_INSERT_1();

            /*" -4727- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -4728- MOVE 'F' TO WS-TIPO-MENSAGEM */
                _.Move("F", WS_TIPO_MENSAGEM);

                /*" -4729- MOVE '14501' TO WNR-EXEC-SQL */
                _.Move("14501", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -4731- MOVE 'ERRO NA INCLUSAO DA TABELA V0RELATORIOS' TO WS-MSG-DESCRICAO */
                _.Move("ERRO NA INCLUSAO DA TABELA V0RELATORIOS", WS_MSG_DESCRICAO);

                /*" -4732- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4732- END-IF. */
            }


        }

        [StopWatch]
        /*" R4500-00-SOLIC-RELAT-DB-SELECT-1 */
        public void R4500_00_SOLIC_RELAT_DB_SELECT_1()
        {
            /*" -4664- EXEC SQL SELECT NRTIT, DTVENCTO INTO :V0RELA-NRTIT, :V0RELA-DTVENCTO FROM SEGUROS.V0HISTCOBVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND NRPARCEL = :V0RELA-NRPARCEL ORDER BY NRTIT FETCH FIRST 1 ROW ONLY WITH UR END-EXEC. */

            var r4500_00_SOLIC_RELAT_DB_SELECT_1_Query1 = new R4500_00_SOLIC_RELAT_DB_SELECT_1_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0RELA_NRPARCEL = V0RELA_NRPARCEL.ToString(),
            };

            var executed_1 = R4500_00_SOLIC_RELAT_DB_SELECT_1_Query1.Execute(r4500_00_SOLIC_RELAT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RELA_NRTIT, V0RELA_NRTIT);
                _.Move(executed_1.V0RELA_DTVENCTO, V0RELA_DTVENCTO);
            }


        }

        [StopWatch]
        /*" R4500-00-SOLIC-RELAT-DB-INSERT-1 */
        public void R4500_00_SOLIC_RELAT_DB_INSERT_1()
        {
            /*" -4724- EXEC SQL INSERT INTO SEGUROS.V0RELATORIOS VALUES ( 'VA0851B' , CURRENT DATE, 'VA' , 'VA0433B' , 0, 0, CURRENT DATE, CURRENT DATE, :V0RELA-DTVENCTO, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, :V0RELA-NRPARCEL, :V0PROP-NRCERTIF, :V0RELA-NRTIT, 0, 0, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '0' , ' ' , ' ' , NULL, 0, 0, CURRENT TIMESTAMP) END-EXEC. */

            var r4500_00_SOLIC_RELAT_DB_INSERT_1_Insert1 = new R4500_00_SOLIC_RELAT_DB_INSERT_1_Insert1()
            {
                V0RELA_DTVENCTO = V0RELA_DTVENCTO.ToString(),
                V0RELA_NRPARCEL = V0RELA_NRPARCEL.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0RELA_NRTIT = V0RELA_NRTIT.ToString(),
            };

            R4500_00_SOLIC_RELAT_DB_INSERT_1_Insert1.Execute(r4500_00_SOLIC_RELAT_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4500_00_SAIDA*/

        [StopWatch]
        /*" R5000-00-BUSCA-VLPREMIO-SECTION */
        private void R5000_00_BUSCA_VLPREMIO_SECTION()
        {
            /*" -4751- PERFORM R5000_00_BUSCA_VLPREMIO_DB_SELECT_1 */

            R5000_00_BUSCA_VLPREMIO_DB_SELECT_1();

            /*" -4754- IF (SQLCODE NOT EQUAL ZEROS AND -811) */

            if ((!DB.SQLCODE.In("00", "-811")))
            {

                /*" -4756- IF (SQLCODE EQUAL +100) */

                if ((DB.SQLCODE == +100))
                {

                    /*" -4763- PERFORM R5000_00_BUSCA_VLPREMIO_DB_SELECT_2 */

                    R5000_00_BUSCA_VLPREMIO_DB_SELECT_2();

                    /*" -4766- IF (SQLCODE NOT EQUAL ZEROS AND -811) */

                    if ((!DB.SQLCODE.In("00", "-811")))
                    {

                        /*" -4767- MOVE ZEROS TO WHOST-VLPREMIO-REL */
                        _.Move(0, WHOST_VLPREMIO_REL);

                        /*" -4768- END-IF */
                    }


                    /*" -4769- ELSE */
                }
                else
                {


                    /*" -4770- MOVE ZEROS TO WHOST-VLPREMIO-REL */
                    _.Move(0, WHOST_VLPREMIO_REL);

                    /*" -4771- END-IF */
                }


                /*" -4773- END-IF. */
            }


            /*" -4774- MOVE WHOST-VLPREMIO-REL TO W-VLPREMIO. */
            _.Move(WHOST_VLPREMIO_REL, W_VLPREMIO);

        }

        [StopWatch]
        /*" R5000-00-BUSCA-VLPREMIO-DB-SELECT-1 */
        public void R5000_00_BUSCA_VLPREMIO_DB_SELECT_1()
        {
            /*" -4751- EXEC SQL SELECT VLPREMIO INTO :WHOST-VLPREMIO-REL FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND DTINIVIG <= :V0PROP-DTVENCTO AND DTTERVIG >= :V0PROP-DTVENCTO WITH UR END-EXEC. */

            var r5000_00_BUSCA_VLPREMIO_DB_SELECT_1_Query1 = new R5000_00_BUSCA_VLPREMIO_DB_SELECT_1_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_DTVENCTO = V0PROP_DTVENCTO.ToString(),
            };

            var executed_1 = R5000_00_BUSCA_VLPREMIO_DB_SELECT_1_Query1.Execute(r5000_00_BUSCA_VLPREMIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_VLPREMIO_REL, WHOST_VLPREMIO_REL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5000_00_SAIDA*/

        [StopWatch]
        /*" R5000-00-BUSCA-VLPREMIO-DB-SELECT-2 */
        public void R5000_00_BUSCA_VLPREMIO_DB_SELECT_2()
        {
            /*" -4763- EXEC SQL SELECT VLPREMIO INTO :WHOST-VLPREMIO-REL FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND DTTERVIG = '9999-12-31' WITH UR END-EXEC */

            var r5000_00_BUSCA_VLPREMIO_DB_SELECT_2_Query1 = new R5000_00_BUSCA_VLPREMIO_DB_SELECT_2_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R5000_00_BUSCA_VLPREMIO_DB_SELECT_2_Query1.Execute(r5000_00_BUSCA_VLPREMIO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_VLPREMIO_REL, WHOST_VLPREMIO_REL);
            }


        }

        [StopWatch]
        /*" R6000-00-GRAVAR-RELAT-SAIDA-SECTION */
        private void R6000_00_GRAVAR_RELAT_SAIDA_SECTION()
        {
            /*" -4784- IF (V0PROP-NUM-APOLICE EQUAL ZEROS) */

            if ((V0PROP_NUM_APOLICE == 00))
            {

                /*" -4785- GO TO R6000-50-CONTINUA */

                R6000_50_CONTINUA(); //GOTO
                return;

                /*" -4787- END-IF. */
            }


            /*" -4788- MOVE V0PROP-NUM-APOLICE TO REG-SAI-NUM-APOLICE */
            _.Move(V0PROP_NUM_APOLICE, REG_DET.REG_SAI_NUM_APOLICE);

            /*" -4789- MOVE V0PROP-CODSUBES TO REG-SAI-CD-SUBGRUPO */
            _.Move(V0PROP_CODSUBES, REG_DET.REG_SAI_CD_SUBGRUPO);

            /*" -4790- MOVE V0PROP-CODPRODU TO REG-SAI-CD-PRODUTO */
            _.Move(V0PROP_CODPRODU, REG_DET.REG_SAI_CD_PRODUTO);

            /*" -4791- MOVE V0PROP-NRCERTIF TO REG-SAI-NRCERTIF */
            _.Move(V0PROP_NRCERTIF, REG_DET.REG_SAI_NRCERTIF);

            /*" -4793- MOVE V0PRDVG-NOMPRODU TO REG-SAI-NOME-PROD */
            _.Move(V0PRDVG_NOMPRODU, REG_DET.REG_SAI_NOME_PROD);

            /*" -4794- EVALUATE V0OPCP-PERIPGTO */
            switch (V0OPCP_PERIPGTO.Value)
            {

                /*" -4794- WHEN 0 */
                case 0:

                    /*" -4794- MOVE 'A VISTA'       TO REG-SAI-PERI-PGTO */
                    _.Move("A VISTA", REG_DET.REG_SAI_PERI_PGTO);

                    /*" -4795- WHEN 1 */
                    break;
                case 1:

                    /*" -4795- MOVE 'MENSAL'        TO REG-SAI-PERI-PGTO */
                    _.Move("MENSAL", REG_DET.REG_SAI_PERI_PGTO);

                    /*" -4796- WHEN 2 */
                    break;
                case 2:

                    /*" -4796- MOVE 'BIMESTRAL'     TO REG-SAI-PERI-PGTO */
                    _.Move("BIMESTRAL", REG_DET.REG_SAI_PERI_PGTO);

                    /*" -4797- WHEN 3 */
                    break;
                case 3:

                    /*" -4797- MOVE 'TRIMESTRAL'    TO REG-SAI-PERI-PGTO */
                    _.Move("TRIMESTRAL", REG_DET.REG_SAI_PERI_PGTO);

                    /*" -4798- WHEN 4 */
                    break;
                case 4:

                    /*" -4798- MOVE 'QUADRIMESTRAL' TO REG-SAI-PERI-PGTO */
                    _.Move("QUADRIMESTRAL", REG_DET.REG_SAI_PERI_PGTO);

                    /*" -4799- WHEN 6 */
                    break;
                case 6:

                    /*" -4799- MOVE 'SEMESTRAL'     TO REG-SAI-PERI-PGTO */
                    _.Move("SEMESTRAL", REG_DET.REG_SAI_PERI_PGTO);

                    /*" -4800- WHEN 12 */
                    break;
                case 12:

                    /*" -4800- MOVE 'ANUAL'         TO REG-SAI-PERI-PGTO */
                    _.Move("ANUAL", REG_DET.REG_SAI_PERI_PGTO);

                    /*" -4801- WHEN OTHER */
                    break;
                default:

                    /*" -4801- MOVE 'OUTROS'        TO REG-SAI-PERI-PGTO */
                    _.Move("OUTROS", REG_DET.REG_SAI_PERI_PGTO);

                    /*" -4805- EVALUATE V0PROP-SITUACAO */
                    switch (V0PROP_SITUACAO.Value.Trim())
                    {

                        /*" -4805- WHEN '0' */
                        case "0":

                            /*" -4805- MOVE 'PENDENTE INTEGRAR'  TO W-SIT-REG-CERT */
                            _.Move("PENDENTE INTEGRAR", AREA_DE_WORK.W_SIT_REG_CERT);

                            /*" -4806- WHEN '1' */
                            break;
                        case "1":

                            /*" -4806- MOVE 'EM CRITICA'         TO W-SIT-REG-CERT */
                            _.Move("EM CRITICA", AREA_DE_WORK.W_SIT_REG_CERT);

                            /*" -4807- WHEN '2' */
                            break;
                        case "2":

                            /*" -4807- MOVE 'FALTA RCAP'         TO W-SIT-REG-CERT */
                            _.Move("FALTA RCAP", AREA_DE_WORK.W_SIT_REG_CERT);

                            /*" -4808- WHEN '3' */
                            break;
                        case "3":

                            /*" -4808- MOVE 'INTEGRADA'          TO W-SIT-REG-CERT */
                            _.Move("INTEGRADA", AREA_DE_WORK.W_SIT_REG_CERT);

                            /*" -4809- WHEN '4' */
                            break;
                        case "4":

                            /*" -4809- MOVE 'RCAP INDEVIDO'      TO W-SIT-REG-CERT */
                            _.Move("RCAP INDEVIDO", AREA_DE_WORK.W_SIT_REG_CERT);

                            /*" -4810- WHEN '5' */
                            break;
                        case "5":

                            /*" -4810- MOVE 'A DEBITAR'          TO W-SIT-REG-CERT */
                            _.Move("A DEBITAR", AREA_DE_WORK.W_SIT_REG_CERT);

                            /*" -4811- WHEN '6' */
                            break;
                        case "6":

                            /*" -4811- MOVE 'DEBITO ENVIADO'     TO W-SIT-REG-CERT */
                            _.Move("DEBITO ENVIADO", AREA_DE_WORK.W_SIT_REG_CERT);

                            /*" -4812- WHEN '7' */
                            break;
                        case "7":

                            /*" -4812- MOVE 'NAO EMITIDO'        TO W-SIT-REG-CERT */
                            _.Move("NAO EMITIDO", AREA_DE_WORK.W_SIT_REG_CERT);

                            /*" -4813- WHEN '8' */
                            break;
                        case "8":

                            /*" -4813- MOVE 'BILHETE CANCELADO'  TO W-SIT-REG-CERT */
                            _.Move("BILHETE CANCELADO", AREA_DE_WORK.W_SIT_REG_CERT);

                            /*" -4814- WHEN '9' */
                            break;
                        case "9":

                            /*" -4814- MOVE 'BILHETE EMITIDO'    TO W-SIT-REG-CERT */
                            _.Move("BILHETE EMITIDO", AREA_DE_WORK.W_SIT_REG_CERT);

                            /*" -4815- WHEN '*' */
                            break;
                        case "*":

                            /*" -4815- MOVE 'BILHETE NAO RENOV'  TO W-SIT-REG-CERT */
                            _.Move("BILHETE NAO RENOV", AREA_DE_WORK.W_SIT_REG_CERT);

                            /*" -4816- WHEN 'L' */
                            break;
                        case "L":

                            /*" -4816- MOVE 'PENDENTE INTEGRAR'  TO W-SIT-REG-CERT */
                            _.Move("PENDENTE INTEGRAR", AREA_DE_WORK.W_SIT_REG_CERT);

                            /*" -4817- WHEN 'F' */
                            break;
                        case "F":

                            /*" -4817- MOVE 'AGUARDANDO PAGTO'   TO W-SIT-REG-CERT */
                            _.Move("AGUARDANDO PAGTO", AREA_DE_WORK.W_SIT_REG_CERT);

                            /*" -4818- WHEN 'C' */
                            break;
                        case "C":

                            /*" -4818- MOVE 'EXTRA REDE'         TO W-SIT-REG-CERT */
                            _.Move("EXTRA REDE", AREA_DE_WORK.W_SIT_REG_CERT);

                            /*" -4819- WHEN OTHER */
                            break;
                        default:

                            /*" -4819- MOVE 'OUTROS'             TO W-SIT-REG-CERT */
                            _.Move("OUTROS", AREA_DE_WORK.W_SIT_REG_CERT);

                            /*" -4824- MOVE W-SIT-REG-CERT TO REG-SAI-SIT-REG-CRT */
                            _.Move(AREA_DE_WORK.W_SIT_REG_CERT, REG_DET.REG_SAI_SIT_REG_CRT);

                            /*" -4825- EVALUATE V0OPCP-OPCAOPAG */
                            switch (V0OPCP_OPCAOPAG.Value.Trim())
                            {

                                /*" -4825- WHEN '1' */
                                case "1":

                                    /*" -4825- MOVE 'DEBITO CONTA'       TO W-OPC-PAG-CERT */
                                    _.Move("DEBITO CONTA", AREA_DE_WORK.W_OPC_PAG_CERT);

                                    /*" -4826- WHEN '2' */
                                    break;
                                case "2":

                                    /*" -4826- MOVE 'DEBITO POUP'        TO W-OPC-PAG-CERT */
                                    _.Move("DEBITO POUP", AREA_DE_WORK.W_OPC_PAG_CERT);

                                    /*" -4827- WHEN '3' */
                                    break;
                                case "3":

                                    /*" -4827- MOVE 'BOLETO IMPR'        TO W-OPC-PAG-CERT */
                                    _.Move("BOLETO IMPR", AREA_DE_WORK.W_OPC_PAG_CERT);

                                    /*" -4828- WHEN '4' */
                                    break;
                                case "4":

                                    /*" -4828- MOVE 'DEBITO AVERB'       TO W-OPC-PAG-CERT */
                                    _.Move("DEBITO AVERB", AREA_DE_WORK.W_OPC_PAG_CERT);

                                    /*" -4829- WHEN '5' */
                                    break;
                                case "5":

                                    /*" -4829- MOVE 'CARTAO CRED'        TO W-OPC-PAG-CERT */
                                    _.Move("CARTAO CRED", AREA_DE_WORK.W_OPC_PAG_CERT);

                                    /*" -4830- WHEN OTHER */
                                    break;
                                default:

                                    /*" -4830- MOVE 'OUTROS'             TO W-OPC-PAG-CERT */
                                    _.Move("OUTROS", AREA_DE_WORK.W_OPC_PAG_CERT);

                                    /*" -4835- MOVE W-OPC-PAG-CERT TO REG-SAI-OPCAO-PGTO */
                                    _.Move(AREA_DE_WORK.W_OPC_PAG_CERT, REG_DET.REG_SAI_OPCAO_PGTO);

                                    /*" -4836- IF (LK-GE853-NUM-PARCELA EQUAL ZEROS) */

                                    if ((REGISTRO_LINKAGE_GE0853S.LK_GE853_NUM_PARCELA == 00))
                                    {

                                        /*" -4837- MOVE V0PROP-NRPARCEL TO REG-SAI-NRPARCEL */
                                        _.Move(V0PROP_NRPARCEL, REG_DET.REG_SAI_NRPARCEL);

                                        /*" -4839- MOVE V0HICB-DTVENCTO TO REG-SAI-DT-VENC */
                                        _.Move(V0HICB_DTVENCTO, REG_DET.REG_SAI_DT_VENC);

                                        /*" -4840- IF (WHOST-VLPREMIO-W NOT EQUAL ZEROS) */

                                        if ((WHOST_VLPREMIO_W != 00))
                                        {

                                            /*" -4841- MOVE WHOST-VLPREMIO-W TO W-VLPREMIO */
                                            _.Move(WHOST_VLPREMIO_W, W_VLPREMIO);

                                            /*" -4842- ELSE */
                                        }
                                        else
                                        {


                                            /*" -4843- PERFORM R5000-00-BUSCA-VLPREMIO */

                                            R5000_00_BUSCA_VLPREMIO_SECTION();

                                            /*" -4844- END-IF */
                                        }


                                        /*" -4845- ELSE */
                                    }
                                    else
                                    {


                                        /*" -4846- MOVE LK-GE853-NUM-PARCELA TO REG-SAI-NRPARCEL */
                                        _.Move(REGISTRO_LINKAGE_GE0853S.LK_GE853_NUM_PARCELA, REG_DET.REG_SAI_NRPARCEL);

                                        /*" -4847- MOVE LK-GE853-DT-CORRENTE TO REG-SAI-DT-VENC */
                                        _.Move(REGISTRO_LINKAGE_GE0853S.LK_GE853_DT_CORRENTE, REG_DET.REG_SAI_DT_VENC);

                                        /*" -4848- MOVE LK-GE853-SIT-PARCELA TO V0HICB-SITUACAO */
                                        _.Move(REGISTRO_LINKAGE_GE0853S.LK_GE853_SIT_PARCELA, V0HICB_SITUACAO);

                                        /*" -4850- MOVE LK-GE853-OPC-PAG-PARCELA TO V0HICB-OPCAO-PGTO */
                                        _.Move(REGISTRO_LINKAGE_GE0853S.LK_GE853_OPC_PAG_PARCELA, V0HICB_OPCAO_PGTO);

                                        /*" -4851- IF (LK-GE853-VLR-PREMIO > ZEROS) */

                                        if ((REGISTRO_LINKAGE_GE0853S.LK_GE853_VLR_PREMIO > 00))
                                        {

                                            /*" -4852- MOVE LK-GE853-VLR-PREMIO TO W-VLPREMIO */
                                            _.Move(REGISTRO_LINKAGE_GE0853S.LK_GE853_VLR_PREMIO, W_VLPREMIO);

                                            /*" -4853- ELSE */
                                        }
                                        else
                                        {


                                            /*" -4854- IF (WHOST-VLPREMIO-W NOT EQUAL ZEROS) */

                                            if ((WHOST_VLPREMIO_W != 00))
                                            {

                                                /*" -4855- MOVE WHOST-VLPREMIO-W TO W-VLPREMIO */
                                                _.Move(WHOST_VLPREMIO_W, W_VLPREMIO);

                                                /*" -4856- ELSE */
                                            }
                                            else
                                            {


                                                /*" -4857- PERFORM R5000-00-BUSCA-VLPREMIO */

                                                R5000_00_BUSCA_VLPREMIO_SECTION();

                                                /*" -4858- END-IF */
                                            }


                                            /*" -4859- END-IF */
                                        }


                                        /*" -4861- END-IF. */
                                    }


                                    /*" -4862- MOVE WVPRM-INTEIRO TO REG-SAI-PRM-INT */
                                    _.Move(FILLER_59.WVPRM_INTEIRO, REG_DET.REG_SAI_PRM_INT);

                                    /*" -4864- MOVE WVPRM-DECIMAL TO REG-SAI-PRM-DEC */
                                    _.Move(FILLER_59.WVPRM_DECIMAL, REG_DET.REG_SAI_PRM_DEC);

                                    /*" -4865- EVALUATE V0HICB-SITUACAO */
                                    switch (V0HICB_SITUACAO.Value.Trim())
                                    {

                                        /*" -4865- WHEN ' ' */
                                        case " ":

                                            /*" -4865- MOVE 'NAO PAGA'         TO REG-SAI-SIT-REG-PAR */
                                            _.Move("NAO PAGA", REG_DET.REG_SAI_SIT_REG_PAR);

                                            /*" -4866- WHEN '0' */
                                            break;
                                        case "0":

                                            /*" -4866- MOVE 'PENDENTE'         TO REG-SAI-SIT-REG-PAR */
                                            _.Move("PENDENTE", REG_DET.REG_SAI_SIT_REG_PAR);

                                            /*" -4867- WHEN '1' */
                                            break;
                                        case "1":

                                            /*" -4867- MOVE 'PAGO'             TO REG-SAI-SIT-REG-PAR */
                                            _.Move("PAGO", REG_DET.REG_SAI_SIT_REG_PAR);

                                            /*" -4868- WHEN '2' */
                                            break;
                                        case "2":

                                            /*" -4868- MOVE 'CANCELADO'        TO REG-SAI-SIT-REG-PAR */
                                            _.Move("CANCELADO", REG_DET.REG_SAI_SIT_REG_PAR);

                                            /*" -4869- WHEN '4' */
                                            break;
                                        case "4":

                                            /*" -4869- MOVE 'GERAR RELATORIO'  TO REG-SAI-SIT-REG-PAR */
                                            _.Move("GERAR RELATORIO", REG_DET.REG_SAI_SIT_REG_PAR);

                                            /*" -4870- WHEN '5' */
                                            break;
                                        case "5":

                                            /*" -4870- MOVE 'IMPRIMIR CORRESP' TO REG-SAI-SIT-REG-PAR */
                                            _.Move("IMPRIMIR CORRESP", REG_DET.REG_SAI_SIT_REG_PAR);

                                            /*" -4871- WHEN '6' */
                                            break;
                                        case "6":

                                            /*" -4871- MOVE 'PENDENTE IDENT.'  TO REG-SAI-SIT-REG-PAR */
                                            _.Move("PENDENTE IDENT.", REG_DET.REG_SAI_SIT_REG_PAR);

                                            /*" -4872- WHEN '7' */
                                            break;
                                        case "7":

                                            /*" -4872- MOVE 'ESTORNADO'        TO REG-SAI-SIT-REG-PAR */
                                            _.Move("ESTORNADO", REG_DET.REG_SAI_SIT_REG_PAR);

                                            /*" -4873- WHEN '8' */
                                            break;
                                        case "8":

                                            /*" -4873- MOVE 'SUBSTITUIDA'      TO REG-SAI-SIT-REG-PAR */
                                            _.Move("SUBSTITUIDA", REG_DET.REG_SAI_SIT_REG_PAR);

                                            /*" -4874- WHEN OTHER */
                                            break;
                                        default:

                                            /*" -4874- MOVE 'OUTROS'          TO REG-SAI-SIT-REG-PAR */
                                            _.Move("OUTROS", REG_DET.REG_SAI_SIT_REG_PAR);

                                            /*" -4878- EVALUATE V0HICB-OPCAO-PGTO */
                                            switch (V0HICB_OPCAO_PGTO.Value.Trim())
                                            {

                                                /*" -4878- WHEN   '1' */
                                                case "1":

                                                    /*" -4878- MOVE 'DEBITO CONTA' TO REG-SAI-OP-PGTO-PAR */
                                                    _.Move("DEBITO CONTA", REG_DET.REG_SAI_OP_PGTO_PAR);

                                                    /*" -4879- WHEN   '2' */
                                                    break;
                                                case "2":

                                                    /*" -4879- MOVE 'DEBITO POUP'  TO REG-SAI-OP-PGTO-PAR */
                                                    _.Move("DEBITO POUP", REG_DET.REG_SAI_OP_PGTO_PAR);

                                                    /*" -4880- WHEN   '3' */
                                                    break;
                                                case "3":

                                                    /*" -4880- MOVE 'BOLETO IMPR'  TO REG-SAI-OP-PGTO-PAR */
                                                    _.Move("BOLETO IMPR", REG_DET.REG_SAI_OP_PGTO_PAR);

                                                    /*" -4881- WHEN   '5' */
                                                    break;
                                                case "5":

                                                    /*" -4881- MOVE 'CARTAO CRED'  TO REG-SAI-OP-PGTO-PAR */
                                                    _.Move("CARTAO CRED", REG_DET.REG_SAI_OP_PGTO_PAR);

                                                    /*" -4882- WHEN OTHER */
                                                    break;
                                                default:

                                                    /*" -4882- MOVE 'OUTROS'       TO REG-SAI-OP-PGTO-PAR */
                                                    _.Move("OUTROS", REG_DET.REG_SAI_OP_PGTO_PAR);

                                                    /*" -0- FLUXCONTROL_PERFORM R6000_50_CONTINUA */

                                                    R6000_50_CONTINUA();

                                                    break;
                                            }

                                            break;
                                    }

                                    break;
                            }

                            break;
                    }
                    break;
            }

        }

        [StopWatch]
        /*" R6000-50-CONTINUA */
        private void R6000_50_CONTINUA(bool isPerform = false)
        {
            /*" -4888- EVALUATE WS-TIPO-MENSAGEM */
            switch (WS_TIPO_MENSAGEM.Value.Trim())
            {

                /*" -4889- WHEN 'F' */
                case "F":

                    /*" -4890- MOVE 'ABEND FATAL' TO REG-TIPO-MENSAGEM */
                    _.Move("ABEND FATAL", REG_DET.REG_TIPO_MENSAGEM);

                    /*" -4891- WHEN 'E' */
                    break;
                case "E":

                    /*" -4892- MOVE 'ERRO CERTIF.' TO REG-TIPO-MENSAGEM */
                    _.Move("ERRO CERTIF.", REG_DET.REG_TIPO_MENSAGEM);

                    /*" -4893- WHEN 'A' */
                    break;
                case "A":

                /*" -4894- WHEN 'W' */
                case "W":

                    /*" -4895- MOVE 'ALERTA' TO REG-TIPO-MENSAGEM */
                    _.Move("ALERTA", REG_DET.REG_TIPO_MENSAGEM);

                    /*" -4896- WHEN 'S' */
                    break;
                case "S":

                    /*" -4897- MOVE 'SUCESSO' TO REG-TIPO-MENSAGEM */
                    _.Move("SUCESSO", REG_DET.REG_TIPO_MENSAGEM);

                    /*" -4898- WHEN 'C' */
                    break;
                case "C":

                    /*" -4899- MOVE 'CANCELAMENTO' TO REG-TIPO-MENSAGEM */
                    _.Move("CANCELAMENTO", REG_DET.REG_TIPO_MENSAGEM);

                    /*" -4900- WHEN 'I' */
                    break;
                case "I":

                    /*" -4901- MOVE 'INFORMACAO' TO REG-TIPO-MENSAGEM */
                    _.Move("INFORMACAO", REG_DET.REG_TIPO_MENSAGEM);

                    /*" -4902- WHEN '0' */
                    break;
                case "0":

                /*" -4903- WHEN '9' */
                case "9":

                    /*" -4904- MOVE 'PROCESSAMENTO' TO REG-TIPO-MENSAGEM */
                    _.Move("PROCESSAMENTO", REG_DET.REG_TIPO_MENSAGEM);

                    /*" -4905- WHEN OTHER */
                    break;
                default:

                    /*" -4906- MOVE 'DESCONHECIDO' TO REG-TIPO-MENSAGEM */
                    _.Move("DESCONHECIDO", REG_DET.REG_TIPO_MENSAGEM);

                    /*" -4908- END-EVALUATE. */
                    break;
            }


            /*" -4910- MOVE SPACES TO REG-SAI-DESCRICAO */
            _.Move("", REG_DET.REG_SAI_DESCRICAO);

            /*" -4911- IF (WS-TIPO-MENSAGEM NOT EQUAL 'F' ) */

            if ((WS_TIPO_MENSAGEM != "F"))
            {

                /*" -4912- MOVE W-TB-DESC-ERRO(WS-NUM-ERRO) TO WS-MSG-DESCRICAO */
                _.Move(W_TAB_ERRO.W_TAB_ERRO_REG[WS_NUM_ERRO].W_TB_DESC_ERRO, WS_MSG_DESCRICAO);

                /*" -4914- END-IF */
            }


            /*" -4919- STRING WNR-EXEC-SQL '-' WS-MSG-DESCRICAO DELIMITED BY SIZE INTO REG-SAI-DESCRICAO END-STRING */
            #region STRING
            var spl2 = AREA_DE_WORK.WABEND.WNR_EXEC_SQL.GetMoveValues();
            spl2 += "-";
            var spl3 = WS_MSG_DESCRICAO.GetMoveValues();
            var results4 = spl2 + spl3;
            _.Move(results4, REG_DET.REG_SAI_DESCRICAO);
            #endregion

            /*" -4921- PERFORM R8200-00-GERAR-CNTRLE-PROC. */

            R8200_00_GERAR_CNTRLE_PROC_SECTION();

            /*" -4921- WRITE REG-SAIDA FROM REG-DET. */
            _.Move(REG_DET.GetMoveValues(), REG_SAIDA);

            ARQSAIDA.Write(REG_SAIDA.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6000_99_SAIDA*/

        [StopWatch]
        /*" R7000-GERAR-PARC-ATRASO-SECTION */
        private void R7000_GERAR_PARC_ATRASO_SECTION()
        {
            /*" -4931- MOVE 'R7000' TO WNR-EXEC-SQL */
            _.Move("R7000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4933- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4935- MOVE ZEROS TO WS-FLAG-PROX-LER WS-QTD-PARC-ATRZ */
            _.Move(0, AREA_DE_WORK.WS_FLAG_PROX_LER, WS_QTD_PARC_ATRZ);

            /*" -4937- MOVE 'N' TO WFIM-CGERARAT */
            _.Move("N", WFIM_CGERARAT);

            /*" -4945- PERFORM R7000_GERAR_PARC_ATRASO_DB_DECLARE_1 */

            R7000_GERAR_PARC_ATRASO_DB_DECLARE_1();

            /*" -4947- PERFORM R7000_GERAR_PARC_ATRASO_DB_OPEN_1 */

            R7000_GERAR_PARC_ATRASO_DB_OPEN_1();

            /*" -4950- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -4951- DISPLAY 'PROBLEMAS NO OPEN (CGERARAT) ... ' */
                _.Display($"PROBLEMAS NO OPEN (CGERARAT) ... ");

                /*" -4952- MOVE 'F' TO WS-TIPO-MENSAGEM */
                _.Move("F", WS_TIPO_MENSAGEM);

                /*" -4953- MOVE '17000' TO WNR-EXEC-SQL */
                _.Move("17000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -4955- MOVE 'ERRO NA CONSULTA DA TABELA PARCELAS_VIDAZUL' TO WS-MSG-DESCRICAO */
                _.Move("ERRO NA CONSULTA DA TABELA PARCELAS_VIDAZUL", WS_MSG_DESCRICAO);

                /*" -4956- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4958- END-IF. */
            }


            /*" -4960- PERFORM R7100-00-FETCH-CGERARAT. */

            R7100_00_FETCH_CGERARAT_SECTION();

            /*" -4961- IF (WFIM-CGERARAT EQUAL 'N' ) */

            if ((WFIM_CGERARAT == "N"))
            {

                /*" -4964- PERFORM R7200-00-PROCESSA-CGERARAT UNTIL WFIM-CGERARAT EQUAL 'S' */

                while (!(WFIM_CGERARAT == "S"))
                {

                    R7200_00_PROCESSA_CGERARAT_SECTION();
                }

                /*" -4965- IF (LK-GE853-COD-RETORNO EQUAL 'C' ) */

                if ((REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO == "C"))
                {

                    /*" -4966- ADD 1 TO WS-QTD-SIT-05 */
                    WS_QTD_SIT_05.Value = WS_QTD_SIT_05 + 1;

                    /*" -4967- MOVE 1 TO WS-FLAG-PROX-LER */
                    _.Move(1, AREA_DE_WORK.WS_FLAG_PROX_LER);

                    /*" -4968- ELSE */
                }
                else
                {


                    /*" -4969- IF (V0OPCP-OPCAOPAG EQUAL '3' ) */

                    if ((V0OPCP_OPCAOPAG == "3"))
                    {

                        /*" -4970- ADD 1 TO WS-QTD-SIT-06 */
                        WS_QTD_SIT_06.Value = WS_QTD_SIT_06 + 1;

                        /*" -4971- MOVE 1 TO WS-FLAG-PROX-LER */
                        _.Move(1, AREA_DE_WORK.WS_FLAG_PROX_LER);

                        /*" -4972- ELSE */
                    }
                    else
                    {


                        /*" -4973- MOVE '6' TO V0PROP-SITUACAO */
                        _.Move("6", V0PROP_SITUACAO);

                        /*" -4975- MOVE WS-QTD-PARC-ATRZ TO V0PROP-QTDPARATZ */
                        _.Move(WS_QTD_PARC_ATRZ, V0PROP_QTDPARATZ);

                        /*" -4976- INITIALIZE REGISTRO-LINKAGE-GE0853S */
                        _.Initialize(
                            REGISTRO_LINKAGE_GE0853S
                        );

                        /*" -4977- END-IF */
                    }


                    /*" -4978- END-IF */
                }


                /*" -4978- END-IF. */
            }


        }

        [StopWatch]
        /*" R7000-GERAR-PARC-ATRASO-DB-OPEN-1 */
        public void R7000_GERAR_PARC_ATRASO_DB_OPEN_1()
        {
            /*" -4947- EXEC SQL OPEN CGERARAT END-EXEC. */

            CGERARAT.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7000_99_SAIDA*/

        [StopWatch]
        /*" R7100-00-FETCH-CGERARAT-SECTION */
        private void R7100_00_FETCH_CGERARAT_SECTION()
        {
            /*" -4988- MOVE 'R7100' TO WNR-EXEC-SQL. */
            _.Move("R7100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4990- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4992- PERFORM R7100_00_FETCH_CGERARAT_DB_FETCH_1 */

            R7100_00_FETCH_CGERARAT_DB_FETCH_1();

            /*" -4995- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -4996- IF (SQLCODE EQUAL +100) */

                if ((DB.SQLCODE == +100))
                {

                    /*" -4996- PERFORM R7100_00_FETCH_CGERARAT_DB_CLOSE_1 */

                    R7100_00_FETCH_CGERARAT_DB_CLOSE_1();

                    /*" -4998- MOVE 'S' TO WFIM-CGERARAT */
                    _.Move("S", WFIM_CGERARAT);

                    /*" -4999- ELSE */
                }
                else
                {


                    /*" -5000- DISPLAY 'R7100-00 (ERRO - FETCH CGERARAT)...' */
                    _.Display($"R7100-00 (ERRO - FETCH CGERARAT)...");

                    /*" -5001- MOVE 'F' TO WS-TIPO-MENSAGEM */
                    _.Move("F", WS_TIPO_MENSAGEM);

                    /*" -5002- MOVE '17100' TO WNR-EXEC-SQL */
                    _.Move("17100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -5004- MOVE 'ERRO NA CONSULTA DA TABELA CGERARAT' TO WS-MSG-DESCRICAO */
                    _.Move("ERRO NA CONSULTA DA TABELA CGERARAT", WS_MSG_DESCRICAO);

                    /*" -5005- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -5006- END-IF */
                }


                /*" -5006- END-IF. */
            }


        }

        [StopWatch]
        /*" R7100-00-FETCH-CGERARAT-DB-FETCH-1 */
        public void R7100_00_FETCH_CGERARAT_DB_FETCH_1()
        {
            /*" -4992- EXEC SQL FETCH CGERARAT INTO :WS-NUM-PARCELA-ATZ END-EXEC. */

            if (CGERARAT.Fetch())
            {
                _.Move(CGERARAT.WS_NUM_PARCELA_ATZ, WS_NUM_PARCELA_ATZ);
            }

        }

        [StopWatch]
        /*" R7100-00-FETCH-CGERARAT-DB-CLOSE-1 */
        public void R7100_00_FETCH_CGERARAT_DB_CLOSE_1()
        {
            /*" -4996- EXEC SQL CLOSE CGERARAT END-EXEC */

            CGERARAT.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7100_99_SAIDA*/

        [StopWatch]
        /*" R7200-00-PROCESSA-CGERARAT-SECTION */
        private void R7200_00_PROCESSA_CGERARAT_SECTION()
        {
            /*" -5017- MOVE 'R7200' TO WNR-EXEC-SQL */
            _.Move("R7200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5019- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5021- INITIALIZE REGISTRO-LINKAGE-GE0853S */
            _.Initialize(
                REGISTRO_LINKAGE_GE0853S
            );

            /*" -5022- MOVE V0PROP-NRCERTIF TO LK-GE853-NUM-CERTIFICADO */
            _.Move(V0PROP_NRCERTIF, REGISTRO_LINKAGE_GE0853S.LK_GE853_NUM_CERTIFICADO);

            /*" -5024- MOVE WS-NUM-PARCELA-ATZ TO LK-GE853-NUM-PARCELA */
            _.Move(WS_NUM_PARCELA_ATZ, REGISTRO_LINKAGE_GE0853S.LK_GE853_NUM_PARCELA);

            /*" -5026- PERFORM R7210-00-CHAMAR-GE0853S */

            R7210_00_CHAMAR_GE0853S_SECTION();

            /*" -5027- IF (LK-GE853-COD-RETORNO EQUAL 'C' ) */

            if ((REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO == "C"))
            {

                /*" -5027- PERFORM R7200_00_PROCESSA_CGERARAT_DB_CLOSE_1 */

                R7200_00_PROCESSA_CGERARAT_DB_CLOSE_1();

                /*" -5029- MOVE 'S' TO WFIM-CGERARAT */
                _.Move("S", WFIM_CGERARAT);

                /*" -5030- ELSE */
            }
            else
            {


                /*" -5031- PERFORM R7100-00-FETCH-CGERARAT */

                R7100_00_FETCH_CGERARAT_SECTION();

                /*" -5031- END-IF. */
            }


        }

        [StopWatch]
        /*" R7200-00-PROCESSA-CGERARAT-DB-CLOSE-1 */
        public void R7200_00_PROCESSA_CGERARAT_DB_CLOSE_1()
        {
            /*" -5027- EXEC SQL CLOSE CGERARAT END-EXEC */

            CGERARAT.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7200_99_SAIDA*/

        [StopWatch]
        /*" R7210-00-CHAMAR-GE0853S-SECTION */
        private void R7210_00_CHAMAR_GE0853S_SECTION()
        {
            /*" -5042- MOVE 'R7210' TO WNR-EXEC-SQL */
            _.Move("R7210", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5044- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5045- IF (V0OPCP-OPCAOPAG NOT EQUAL '3' ) */

            if ((V0OPCP_OPCAOPAG != "3"))
            {

                /*" -5046- MOVE V1SIST-DTVENFIM-6D-UTIL TO LK-GE853-DT-CORRENTE */
                _.Move(V1SIST_DTVENFIM_6D_UTIL, REGISTRO_LINKAGE_GE0853S.LK_GE853_DT_CORRENTE);

                /*" -5047- ELSE */
            }
            else
            {


                /*" -5048- MOVE V1SIST-DT-18D-UTIL TO LK-GE853-DT-CORRENTE */
                _.Move(V1SIST_DT_18D_UTIL, REGISTRO_LINKAGE_GE0853S.LK_GE853_DT_CORRENTE);

                /*" -5050- END-IF */
            }


            /*" -5051- MOVE V1SIST-DTVENFIM-CN-GE853S TO LK-GE853-DT-CORRENTE-18D */
            _.Move(V1SIST_DTVENFIM_CN_GE853S, REGISTRO_LINKAGE_GE0853S.LK_GE853_DT_CORRENTE_18D);

            /*" -5052- MOVE V1SIST-DTMOVABE TO LK-GE853-DT-MOVIMENTO */
            _.Move(V1SIST_DTMOVABE, REGISTRO_LINKAGE_GE0853S.LK_GE853_DT_MOVIMENTO);

            /*" -5054- MOVE V1SIST-DTVENFIM-1Y-GE853S TO LK-GE853-DT-MOVIMENTO-1Y */
            _.Move(V1SIST_DTVENFIM_1Y_GE853S, REGISTRO_LINKAGE_GE0853S.LK_GE853_DT_MOVIMENTO_1Y);

            /*" -5056- CALL 'GE0853S' USING REGISTRO-LINKAGE-GE0853S. */
            _.Call("GE0853S", REGISTRO_LINKAGE_GE0853S);

            /*" -5057- MOVE LK-GE853-COD-REJEICAO TO WNR-EXEC-SQL */
            _.Move(REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_REJEICAO, AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5058- MOVE LK-GE853-COD-RETORNO TO WS-TIPO-MENSAGEM */
            _.Move(REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO, WS_TIPO_MENSAGEM);

            /*" -5060- MOVE LK-GE853-NUM-ERRO TO WS-NUM-ERRO */
            _.Move(REGISTRO_LINKAGE_GE0853S.LK_GE853_NUM_ERRO, WS_NUM_ERRO);

            /*" -5061- MOVE LK-GE853-MSG-RETORNO TO WS-MSG-DESCRICAO */
            _.Move(REGISTRO_LINKAGE_GE0853S.LK_GE853_MENSAGEM.LK_GE853_MSG_RETORNO, WS_MSG_DESCRICAO);

            /*" -5063- PERFORM R6000-00-GRAVAR-RELAT-SAIDA. */

            R6000_00_GRAVAR_RELAT_SAIDA_SECTION();

            /*" -5064- EVALUATE LK-GE853-COD-RETORNO */
            switch (REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO.Value.Trim())
            {

                /*" -5065- WHEN 'C' */
                case "C":

                    /*" -5066- ADD 1 TO WACC-GRAV-CANC */
                    AREA_DE_WORK.WACC_GRAV_CANC.Value = AREA_DE_WORK.WACC_GRAV_CANC + 1;

                    /*" -5067- WHEN 'S' */
                    break;
                case "S":

                    /*" -5070- ADD 1 TO WACC-GRAV-ATRZ WS-QTD-PARC-ATRZ */
                    AREA_DE_WORK.WACC_GRAV_ATRZ.Value = AREA_DE_WORK.WACC_GRAV_ATRZ + 1;
                    WS_QTD_PARC_ATRZ.Value = WS_QTD_PARC_ATRZ + 1;

                    /*" -5071- EVALUATE V0OPCP-OPCAOPAG */
                    switch (V0OPCP_OPCAOPAG.Value.Trim())
                    {

                        /*" -5072- WHEN '3' */
                        case "3":

                            /*" -5073- ADD 1 TO WACC-ATRZ-BOL */
                            AREA_DE_WORK.WACC_ATRZ_BOL.Value = AREA_DE_WORK.WACC_ATRZ_BOL + 1;

                            /*" -5074- WHEN '5' */
                            break;
                        case "5":

                            /*" -5075- ADD 1 TO WACC-ATRZ-CARTAO */
                            AREA_DE_WORK.WACC_ATRZ_CARTAO.Value = AREA_DE_WORK.WACC_ATRZ_CARTAO + 1;

                            /*" -5076- WHEN OTHER */
                            break;
                        default:

                            /*" -5077- ADD 1 TO WACC-ATRZ-CONTA */
                            AREA_DE_WORK.WACC_ATRZ_CONTA.Value = AREA_DE_WORK.WACC_ATRZ_CONTA + 1;

                            /*" -5078- END-EVALUATE */
                            break;
                    }


                    /*" -5079- WHEN 'I' */
                    break;
                case "I":

                    /*" -5080- IF LK-GE853-NUM-ERRO EQUAL 325 */

                    if (REGISTRO_LINKAGE_GE0853S.LK_GE853_NUM_ERRO == 325)
                    {

                        /*" -5081- CONTINUE */

                        /*" -5082- ELSE */
                    }
                    else
                    {


                        /*" -5083- ADD 1 TO WACC-ERRO-ATRZ */
                        AREA_DE_WORK.WACC_ERRO_ATRZ.Value = AREA_DE_WORK.WACC_ERRO_ATRZ + 1;

                        /*" -5084- END-IF */
                    }


                    /*" -5085- WHEN 'E' */
                    break;
                case "E":

                    /*" -5086- ADD 1 TO WACC-ERRO-ATRZ */
                    AREA_DE_WORK.WACC_ERRO_ATRZ.Value = AREA_DE_WORK.WACC_ERRO_ATRZ + 1;

                    /*" -5087- WHEN 'F' */
                    break;
                case "F":

                    /*" -5088- ADD 1 TO WACC-ERRO-ATRZ */
                    AREA_DE_WORK.WACC_ERRO_ATRZ.Value = AREA_DE_WORK.WACC_ERRO_ATRZ + 1;

                    /*" -5089- DISPLAY '******************************************' */
                    _.Display($"******************************************");

                    /*" -5090- DISPLAY '*  SUB-ROTINA GE0853S - TERMINO ANORMAL  *' */
                    _.Display($"*  SUB-ROTINA GE0853S - TERMINO ANORMAL  *");

                    /*" -5091- DISPLAY '******************************************' */
                    _.Display($"******************************************");

                    /*" -5092- DISPLAY '*ROTINA DE GERACAO DE PARCELAS EM ATRASO *' */
                    _.Display($"*ROTINA DE GERACAO DE PARCELAS EM ATRASO *");

                    /*" -5093- DISPLAY '*                                        *' */
                    _.Display($"*                                        *");

                    /*" -5094- DISPLAY '*PARAGRAF -> ' LK-GE853-COD-REJEICAO */
                    _.Display($"*PARAGRAF -> {REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_REJEICAO}");

                    /*" -5095- DISPLAY '*MENSAGEM -> ' LK-GE853-MSG-RETORNO */
                    _.Display($"*MENSAGEM -> {REGISTRO_LINKAGE_GE0853S.LK_GE853_MENSAGEM.LK_GE853_MSG_RETORNO}");

                    /*" -5096- DISPLAY '*SQLERRMC -> ' SQLERRMC */
                    _.Display($"*SQLERRMC -> {DB.SQLERRMC}");

                    /*" -5097- DISPLAY '*SQLCODE  -> ' LK-GE853-SQLCODE */
                    _.Display($"*SQLCODE  -> {REGISTRO_LINKAGE_GE0853S.LK_GE853_MENSAGEM.LK_GE853_SQLCODE}");

                    /*" -5098- DISPLAY '*CERTIF.  -> ' LK-GE853-NUM-CERTIFICADO */
                    _.Display($"*CERTIF.  -> {REGISTRO_LINKAGE_GE0853S.LK_GE853_NUM_CERTIFICADO}");

                    /*" -5099- DISPLAY '*' WABEND '*' */

                    $"*{AREA_DE_WORK.WABEND}*"
                    .Display();

                    /*" -5100- DISPLAY '******************************************' */
                    _.Display($"******************************************");

                    /*" -5101- MOVE 'F' TO WS-TIPO-MENSAGEM */
                    _.Move("F", WS_TIPO_MENSAGEM);

                    /*" -5102- MOVE '17200' TO WNR-EXEC-SQL */
                    _.Move("17200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -5104- MOVE 'ERRO NA CHAMADA DA SUBROTINA GE0853S' TO WS-MSG-DESCRICAO */
                    _.Move("ERRO NA CHAMADA DA SUBROTINA GE0853S", WS_MSG_DESCRICAO);

                    /*" -5105- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -5105- END-EVALUATE. */
                    break;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7210_99_SAIDA*/

        [StopWatch]
        /*" R8000-00-OBTER-NSAS-MOVTO-SECTION */
        private void R8000_00_OBTER_NSAS_MOVTO_SECTION()
        {
            /*" -5116- MOVE 'VA0853B' TO ARQSIVPF-SIGLA-ARQUIVO */
            _.Move("VA0853B", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -5118- MOVE '5' TO ARQSIVPF-SISTEMA-ORIGEM */
            _.Move("5", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -5125- PERFORM R8000_00_OBTER_NSAS_MOVTO_DB_SELECT_1 */

            R8000_00_OBTER_NSAS_MOVTO_DB_SELECT_1();

            /*" -5128- IF (SQLCODE EQUAL ZEROS AND +100) */

            if ((DB.SQLCODE.In("00", "+100")))
            {

                /*" -5129- DISPLAY 'R8100-00 (ERRO CONSULTA ARQUIVOS_SIVPF' */
                _.Display($"R8100-00 (ERRO CONSULTA ARQUIVOS_SIVPF");

                /*" -5130- MOVE 'X' TO WS-TIPO-MENSAGEM */
                _.Move("X", WS_TIPO_MENSAGEM);

                /*" -5131- MOVE '18000' TO WNR-EXEC-SQL */
                _.Move("18000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -5133- MOVE 'ERRO NA CONSULTA DA TABELA ARQUIVOS_SIVPF' TO WS-MSG-DESCRICAO */
                _.Move("ERRO NA CONSULTA DA TABELA ARQUIVOS_SIVPF", WS_MSG_DESCRICAO);

                /*" -5134- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -5134- END-IF. */
            }


        }

        [StopWatch]
        /*" R8000-00-OBTER-NSAS-MOVTO-DB-SELECT-1 */
        public void R8000_00_OBTER_NSAS_MOVTO_DB_SELECT_1()
        {
            /*" -5125- EXEC SQL SELECT VALUE(MAX(NSAS_SIVPF),0) + 1 INTO :ARQSIVPF-NSAS-SIVPF FROM SEGUROS.ARQUIVOS_SIVPF WHERE SIGLA_ARQUIVO = :ARQSIVPF-SIGLA-ARQUIVO AND SISTEMA_ORIGEM = :ARQSIVPF-SISTEMA-ORIGEM WITH UR END-EXEC. */

            var r8000_00_OBTER_NSAS_MOVTO_DB_SELECT_1_Query1 = new R8000_00_OBTER_NSAS_MOVTO_DB_SELECT_1_Query1()
            {
                ARQSIVPF_SISTEMA_ORIGEM = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM.ToString(),
                ARQSIVPF_SIGLA_ARQUIVO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO.ToString(),
            };

            var executed_1 = R8000_00_OBTER_NSAS_MOVTO_DB_SELECT_1_Query1.Execute(r8000_00_OBTER_NSAS_MOVTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ARQSIVPF_NSAS_SIVPF, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_SAIDA*/

        [StopWatch]
        /*" R8100-00-GERAR-ARQSIVPF-SECTION */
        private void R8100_00_GERAR_ARQSIVPF_SECTION()
        {
            /*" -5144- PERFORM R8000-00-OBTER-NSAS-MOVTO. */

            R8000_00_OBTER_NSAS_MOVTO_SECTION();

            /*" -5145- MOVE V1SIST-DTHOJE TO ARQSIVPF-DATA-GERACAO */
            _.Move(V1SIST_DTHOJE, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO);

            /*" -5146- MOVE V1SIST-DTMOVABE TO ARQSIVPF-DATA-PROCESSAMENTO */
            _.Move(V1SIST_DTMOVABE, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO);

            /*" -5148- MOVE ZEROS TO ARQSIVPF-QTDE-REG-GER */
            _.Move(0, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER);

            /*" -5157- PERFORM R8100_00_GERAR_ARQSIVPF_DB_INSERT_1 */

            R8100_00_GERAR_ARQSIVPF_DB_INSERT_1();

            /*" -5160- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -5162- DISPLAY 'ERRO NO INSERTE DA TABELA ARQUIVOS_SIVPF ' SQLCODE */
                _.Display($"ERRO NO INSERTE DA TABELA ARQUIVOS_SIVPF {DB.SQLCODE}");

                /*" -5163- MOVE 'X' TO WS-TIPO-MENSAGEM */
                _.Move("X", WS_TIPO_MENSAGEM);

                /*" -5164- MOVE '18100' TO WNR-EXEC-SQL */
                _.Move("18100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -5166- MOVE 'ERRO NO INSERTE DA TABELA ARQUIVOS_SIVPF' TO WS-MSG-DESCRICAO */
                _.Move("ERRO NO INSERTE DA TABELA ARQUIVOS_SIVPF", WS_MSG_DESCRICAO);

                /*" -5167- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -5169- END-IF. */
            }


            /*" -5173- DISPLAY 'ARQUIVOS_SIVPF - SIGLA ' ARQSIVPF-SIGLA-ARQUIVO ' SISTEMA ' ARQSIVPF-SISTEMA-ORIGEM ' NSAS ' ARQSIVPF-NSAS-SIVPF ' GERACAO ' ARQSIVPF-DATA-GERACAO ' PROC ' ARQSIVPF-DATA-PROCESSAMENTO. */

            $"ARQUIVOS_SIVPF - SIGLA {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO} SISTEMA {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM} NSAS {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF} GERACAO {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO} PROC {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO}"
            .Display();

        }

        [StopWatch]
        /*" R8100-00-GERAR-ARQSIVPF-DB-INSERT-1 */
        public void R8100_00_GERAR_ARQSIVPF_DB_INSERT_1()
        {
            /*" -5157- EXEC SQL INSERT INTO SEGUROS.ARQUIVOS_SIVPF VALUES (:ARQSIVPF-SIGLA-ARQUIVO , :ARQSIVPF-SISTEMA-ORIGEM , :ARQSIVPF-NSAS-SIVPF , :ARQSIVPF-DATA-GERACAO , :ARQSIVPF-QTDE-REG-GER , :ARQSIVPF-DATA-PROCESSAMENTO) END-EXEC. */

            var r8100_00_GERAR_ARQSIVPF_DB_INSERT_1_Insert1 = new R8100_00_GERAR_ARQSIVPF_DB_INSERT_1_Insert1()
            {
                ARQSIVPF_SIGLA_ARQUIVO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO.ToString(),
                ARQSIVPF_SISTEMA_ORIGEM = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM.ToString(),
                ARQSIVPF_NSAS_SIVPF = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF.ToString(),
                ARQSIVPF_DATA_GERACAO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO.ToString(),
                ARQSIVPF_QTDE_REG_GER = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER.ToString(),
                ARQSIVPF_DATA_PROCESSAMENTO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO.ToString(),
            };

            R8100_00_GERAR_ARQSIVPF_DB_INSERT_1_Insert1.Execute(r8100_00_GERAR_ARQSIVPF_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8100_SAIDA*/

        [StopWatch]
        /*" R8200-00-GERAR-CNTRLE-PROC-SECTION */
        private void R8200_00_GERAR_CNTRLE_PROC_SECTION()
        {
            /*" -5183- MOVE 'R8200' TO WNR-EXEC-SQL */
            _.Move("R8200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5185- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5186- MOVE 150 TO PF087-DES-CONTEUDO-LEN */
            _.Move(150, PF087.DCLPF_PROC_PROPOSTA.PF087_DES_CONTEUDO.PF087_DES_CONTEUDO_LEN);

            /*" -5188- MOVE REG-DET(46:141) TO PF087-DES-CONTEUDO-TEXT */
            _.Move(REG_DET.Substring(46, 141), PF087.DCLPF_PROC_PROPOSTA.PF087_DES_CONTEUDO.PF087_DES_CONTEUDO_TEXT);

            /*" -5189- EVALUATE WS-TIPO-MENSAGEM */
            switch (WS_TIPO_MENSAGEM.Value.Trim())
            {

                /*" -5190- WHEN 'F' */
                case "F":

                    /*" -5191- MOVE 399 TO WS-NUM-ERRO */
                    _.Move(399, WS_NUM_ERRO);

                    /*" -5192- MOVE 399 TO PF087-NUM-DET-ARQ-PROPOSTA */
                    _.Move(399, PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_DET_ARQ_PROPOSTA);

                    /*" -5193- MOVE 'E' TO PF087-STA-PROCESSAMENTO */
                    _.Move("E", PF087.DCLPF_PROC_PROPOSTA.PF087_STA_PROCESSAMENTO);

                    /*" -5198- STRING 'SQLCODE=' WSL-SQLCODE(5:5) '-' REG-SAI-DESCRICAO DELIMITED BY SIZE INTO PF087-DES-CONTEUDO-TEXT END-STRING */
                    #region STRING
                    var spl4 = "SQLCODE=" + AREA_DE_WORK.WSL_SQLCODE.Substring(5, 5).GetMoveValues();
                    spl4 += "-";
                    var spl5 = REG_DET.REG_SAI_DESCRICAO.GetMoveValues();
                    var results6 = spl4 + spl5;
                    _.Move(results6, PF087.DCLPF_PROC_PROPOSTA.PF087_DES_CONTEUDO.PF087_DES_CONTEUDO_TEXT);
                    #endregion

                    /*" -5199- WHEN 'S' */
                    break;
                case "S":

                    /*" -5200- MOVE 301 TO PF087-NUM-DET-ARQ-PROPOSTA */
                    _.Move(301, PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_DET_ARQ_PROPOSTA);

                    /*" -5201- MOVE 'P' TO PF087-STA-PROCESSAMENTO */
                    _.Move("P", PF087.DCLPF_PROC_PROPOSTA.PF087_STA_PROCESSAMENTO);

                    /*" -5202- ADD 1 TO WS-QTD-TP-MSG-S */
                    AREA_DE_WORK.WS_QTD_TP_MSG_S.Value = AREA_DE_WORK.WS_QTD_TP_MSG_S + 1;

                    /*" -5203- WHEN 'C' */
                    break;
                case "C":

                    /*" -5204- MOVE 305 TO PF087-NUM-DET-ARQ-PROPOSTA */
                    _.Move(305, PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_DET_ARQ_PROPOSTA);

                    /*" -5205- MOVE 'P' TO PF087-STA-PROCESSAMENTO */
                    _.Move("P", PF087.DCLPF_PROC_PROPOSTA.PF087_STA_PROCESSAMENTO);

                    /*" -5206- ADD 1 TO WS-QTD-TP-MSG-C */
                    AREA_DE_WORK.WS_QTD_TP_MSG_C.Value = AREA_DE_WORK.WS_QTD_TP_MSG_C + 1;

                    /*" -5207- WHEN 'E' */
                    break;
                case "E":

                    /*" -5208- MOVE 303 TO PF087-NUM-DET-ARQ-PROPOSTA */
                    _.Move(303, PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_DET_ARQ_PROPOSTA);

                    /*" -5209- MOVE 'E' TO PF087-STA-PROCESSAMENTO */
                    _.Move("E", PF087.DCLPF_PROC_PROPOSTA.PF087_STA_PROCESSAMENTO);

                    /*" -5210- ADD 1 TO WS-QTD-TP-MSG-E */
                    AREA_DE_WORK.WS_QTD_TP_MSG_E.Value = AREA_DE_WORK.WS_QTD_TP_MSG_E + 1;

                    /*" -5211- WHEN 'A' */
                    break;
                case "A":

                    /*" -5212- MOVE 302 TO PF087-NUM-DET-ARQ-PROPOSTA */
                    _.Move(302, PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_DET_ARQ_PROPOSTA);

                    /*" -5213- MOVE 'E' TO PF087-STA-PROCESSAMENTO */
                    _.Move("E", PF087.DCLPF_PROC_PROPOSTA.PF087_STA_PROCESSAMENTO);

                    /*" -5214- ADD 1 TO WS-QTD-TP-MSG-A */
                    AREA_DE_WORK.WS_QTD_TP_MSG_A.Value = AREA_DE_WORK.WS_QTD_TP_MSG_A + 1;

                    /*" -5215- WHEN 'I' */
                    break;
                case "I":

                    /*" -5216- MOVE 304 TO PF087-NUM-DET-ARQ-PROPOSTA */
                    _.Move(304, PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_DET_ARQ_PROPOSTA);

                    /*" -5217- MOVE 'E' TO PF087-STA-PROCESSAMENTO */
                    _.Move("E", PF087.DCLPF_PROC_PROPOSTA.PF087_STA_PROCESSAMENTO);

                    /*" -5218- ADD 1 TO WS-QTD-TP-MSG-I */
                    AREA_DE_WORK.WS_QTD_TP_MSG_I.Value = AREA_DE_WORK.WS_QTD_TP_MSG_I + 1;

                    /*" -5219- WHEN '0' */
                    break;
                case "0":

                    /*" -5220- MOVE 327 TO WS-NUM-ERRO */
                    _.Move(327, WS_NUM_ERRO);

                    /*" -5221- MOVE 300 TO PF087-NUM-DET-ARQ-PROPOSTA */
                    _.Move(300, PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_DET_ARQ_PROPOSTA);

                    /*" -5222- MOVE 'P' TO PF087-STA-PROCESSAMENTO */
                    _.Move("P", PF087.DCLPF_PROC_PROPOSTA.PF087_STA_PROCESSAMENTO);

                    /*" -5223- MOVE 0 TO PF087-DES-CONTEUDO-LEN */
                    _.Move(0, PF087.DCLPF_PROC_PROPOSTA.PF087_DES_CONTEUDO.PF087_DES_CONTEUDO_LEN);

                    /*" -5224- MOVE SPACES TO PF087-DES-CONTEUDO-TEXT */
                    _.Move("", PF087.DCLPF_PROC_PROPOSTA.PF087_DES_CONTEUDO.PF087_DES_CONTEUDO_TEXT);

                    /*" -5225- MOVE ZEROS TO V0PROP-NUM-APOLICE */
                    _.Move(0, V0PROP_NUM_APOLICE);

                    /*" -5226- MOVE ZEROS TO V0PROP-NRCERTIF */
                    _.Move(0, V0PROP_NRCERTIF);

                    /*" -5227- MOVE ZEROS TO REG-SAI-NRPARCEL */
                    _.Move(0, REG_DET.REG_SAI_NRPARCEL);

                    /*" -5228- WHEN '9' */
                    break;
                case "9":

                    /*" -5229- MOVE 328 TO WS-NUM-ERRO */
                    _.Move(328, WS_NUM_ERRO);

                    /*" -5230- MOVE 300 TO PF087-NUM-DET-ARQ-PROPOSTA */
                    _.Move(300, PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_DET_ARQ_PROPOSTA);

                    /*" -5231- MOVE 'P' TO PF087-STA-PROCESSAMENTO */
                    _.Move("P", PF087.DCLPF_PROC_PROPOSTA.PF087_STA_PROCESSAMENTO);

                    /*" -5232- MOVE 0 TO PF087-DES-CONTEUDO-LEN */
                    _.Move(0, PF087.DCLPF_PROC_PROPOSTA.PF087_DES_CONTEUDO.PF087_DES_CONTEUDO_LEN);

                    /*" -5233- MOVE SPACES TO PF087-DES-CONTEUDO-TEXT */
                    _.Move("", PF087.DCLPF_PROC_PROPOSTA.PF087_DES_CONTEUDO.PF087_DES_CONTEUDO_TEXT);

                    /*" -5234- MOVE ZEROS TO V0PROP-NUM-APOLICE */
                    _.Move(0, V0PROP_NUM_APOLICE);

                    /*" -5235- MOVE ZEROS TO V0PROP-NRCERTIF */
                    _.Move(0, V0PROP_NRCERTIF);

                    /*" -5236- MOVE 999 TO REG-SAI-NRPARCEL */
                    _.Move(999, REG_DET.REG_SAI_NRPARCEL);

                    /*" -5238- END-EVALUATE */
                    break;
            }


            /*" -5239- MOVE ARQSIVPF-SIGLA-ARQUIVO TO PF087-SIGLA-ARQUIVO */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO, PF087.DCLPF_PROC_PROPOSTA.PF087_SIGLA_ARQUIVO);

            /*" -5240- MOVE ARQSIVPF-SISTEMA-ORIGEM TO PF087-SISTEMA-ORIGEM */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM, PF087.DCLPF_PROC_PROPOSTA.PF087_SISTEMA_ORIGEM);

            /*" -5241- MOVE ARQSIVPF-NSAS-SIVPF TO PF087-NSAS-SIVPF */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, PF087.DCLPF_PROC_PROPOSTA.PF087_NSAS_SIVPF);

            /*" -5242- MOVE V0PROP-NUM-APOLICE TO PF087-NUM-APOLICE-VINCULADA */
            _.Move(V0PROP_NUM_APOLICE, PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_APOLICE_VINCULADA);

            /*" -5244- MOVE V0PROP-NRCERTIF TO PF087-NUM-PROPOSTA */
            _.Move(V0PROP_NRCERTIF, PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_PROPOSTA);

            /*" -5245- MOVE REG-SAI-NRPARCEL TO PF087-NUM-LINHA-ARQUIVO */
            _.Move(REG_DET.REG_SAI_NRPARCEL, PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_LINHA_ARQUIVO);

            /*" -5247- MOVE WS-NUM-ERRO TO PF087-NUM-ERRO-PROPOSTA */
            _.Move(WS_NUM_ERRO, PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_ERRO_PROPOSTA);

            /*" -5248- MOVE 'VA0853B' TO PF087-COD-USUARIO */
            _.Move("VA0853B", PF087.DCLPF_PROC_PROPOSTA.PF087_COD_USUARIO);

            /*" -5250- MOVE 1 TO PF090-SEQ-OCORR-HIST. */
            _.Move(1, DCLPF_PROC_PROPOSTA_HIST.PF090_SEQ_OCORR_HIST);

            /*" -5250- PERFORM R8210-00-INSERT-CNTRLE-PROC. */

            R8210_00_INSERT_CNTRLE_PROC_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8200_SAIDA*/

        [StopWatch]
        /*" R8210-00-INSERT-CNTRLE-PROC-SECTION */
        private void R8210_00_INSERT_CNTRLE_PROC_SECTION()
        {
            /*" -5278- MOVE 'R8210' TO WNR-EXEC-SQL */
            _.Move("R8210", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5280- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5281- ADD 1 TO WS-SEQ-OCORRENCIA */
            WS_SEQ_OCORRENCIA.Value = WS_SEQ_OCORRENCIA + 1;

            /*" -5283- MOVE WS-SEQ-OCORRENCIA TO PF087-SEQ-OCORRENCIA */
            _.Move(WS_SEQ_OCORRENCIA, PF087.DCLPF_PROC_PROPOSTA.PF087_SEQ_OCORRENCIA);

            /*" -5299- PERFORM R8210_00_INSERT_CNTRLE_PROC_DB_INSERT_1 */

            R8210_00_INSERT_CNTRLE_PROC_DB_INSERT_1();

            /*" -5302- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -5303- IF (SQLCODE EQUAL -803) */

                if ((DB.SQLCODE == -803))
                {

                    /*" -5304- DISPLAY '-- DUPLICIDADE DE CHAVE PF_PROC_PROPOSTA --' */
                    _.Display($"-- DUPLICIDADE DE CHAVE PF_PROC_PROPOSTA --");

                    /*" -5305- DISPLAY 'ARQUIVO       ' PF087-SIGLA-ARQUIVO */
                    _.Display($"ARQUIVO       {PF087.DCLPF_PROC_PROPOSTA.PF087_SIGLA_ARQUIVO}");

                    /*" -5306- DISPLAY 'ORIGEM        ' PF087-SISTEMA-ORIGEM */
                    _.Display($"ORIGEM        {PF087.DCLPF_PROC_PROPOSTA.PF087_SISTEMA_ORIGEM}");

                    /*" -5307- DISPLAY 'SIVPF         ' PF087-NSAS-SIVPF */
                    _.Display($"SIVPF         {PF087.DCLPF_PROC_PROPOSTA.PF087_NSAS_SIVPF}");

                    /*" -5308- DISPLAY 'PROPOSTA      ' PF087-NUM-PROPOSTA */
                    _.Display($"PROPOSTA      {PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_PROPOSTA}");

                    /*" -5309- DISPLAY 'OCORRENCIA    ' PF087-SEQ-OCORRENCIA */
                    _.Display($"OCORRENCIA    {PF087.DCLPF_PROC_PROPOSTA.PF087_SEQ_OCORRENCIA}");

                    /*" -5310- DISPLAY 'ARQ-PROPOSTA  ' PF087-NUM-DET-ARQ-PROPOSTA */
                    _.Display($"ARQ-PROPOSTA  {PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_DET_ARQ_PROPOSTA}");

                    /*" -5311- DISPLAY 'ERRO-PROPOSTA ' PF087-NUM-ERRO-PROPOSTA */
                    _.Display($"ERRO-PROPOSTA {PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_ERRO_PROPOSTA}");

                    /*" -5312- DISPLAY 'VINCULADA     ' PF087-NUM-APOLICE-VINCULADA */
                    _.Display($"VINCULADA     {PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_APOLICE_VINCULADA}");

                    /*" -5313- DISPLAY 'LINHA-ARQUIVO ' PF087-NUM-LINHA-ARQUIVO */
                    _.Display($"LINHA-ARQUIVO {PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_LINHA_ARQUIVO}");

                    /*" -5314- DISPLAY 'CONTEUDO      ' PF087-DES-CONTEUDO */
                    _.Display($"CONTEUDO      {PF087.DCLPF_PROC_PROPOSTA.PF087_DES_CONTEUDO}");

                    /*" -5315- DISPLAY 'PROCESSAMENTO ' PF087-STA-PROCESSAMENTO */
                    _.Display($"PROCESSAMENTO {PF087.DCLPF_PROC_PROPOSTA.PF087_STA_PROCESSAMENTO}");

                    /*" -5316- DISPLAY 'USUARIO       ' PF087-COD-USUARIO */
                    _.Display($"USUARIO       {PF087.DCLPF_PROC_PROPOSTA.PF087_COD_USUARIO}");

                    /*" -5317- DISPLAY '-------------------------------------------' */
                    _.Display($"-------------------------------------------");

                    /*" -5318- END-IF */
                }


                /*" -5319- MOVE 'F' TO WS-TIPO-MENSAGEM */
                _.Move("F", WS_TIPO_MENSAGEM);

                /*" -5320- MOVE '18200' TO WNR-EXEC-SQL */
                _.Move("18200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -5322- MOVE 'ERRO NO INSERTE DA TABELA PF_PROC_PROPOSTA' TO WS-MSG-DESCRICAO */
                _.Move("ERRO NO INSERTE DA TABELA PF_PROC_PROPOSTA", WS_MSG_DESCRICAO);

                /*" -5323- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -5323- END-IF. */
            }


        }

        [StopWatch]
        /*" R8210-00-INSERT-CNTRLE-PROC-DB-INSERT-1 */
        public void R8210_00_INSERT_CNTRLE_PROC_DB_INSERT_1()
        {
            /*" -5299- EXEC SQL INSERT INTO SEGUROS.PF_PROC_PROPOSTA VALUES (:PF087-SIGLA-ARQUIVO , :PF087-SISTEMA-ORIGEM , :PF087-NSAS-SIVPF , :PF087-NUM-PROPOSTA , :PF087-SEQ-OCORRENCIA , :PF087-NUM-DET-ARQ-PROPOSTA , :PF087-NUM-ERRO-PROPOSTA , :PF087-NUM-APOLICE-VINCULADA , :PF087-NUM-LINHA-ARQUIVO , :PF087-DES-CONTEUDO , :PF087-STA-PROCESSAMENTO , :PF087-COD-USUARIO , CURRENT_TIMESTAMP ) END-EXEC. */

            var r8210_00_INSERT_CNTRLE_PROC_DB_INSERT_1_Insert1 = new R8210_00_INSERT_CNTRLE_PROC_DB_INSERT_1_Insert1()
            {
                PF087_SIGLA_ARQUIVO = PF087.DCLPF_PROC_PROPOSTA.PF087_SIGLA_ARQUIVO.ToString(),
                PF087_SISTEMA_ORIGEM = PF087.DCLPF_PROC_PROPOSTA.PF087_SISTEMA_ORIGEM.ToString(),
                PF087_NSAS_SIVPF = PF087.DCLPF_PROC_PROPOSTA.PF087_NSAS_SIVPF.ToString(),
                PF087_NUM_PROPOSTA = PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_PROPOSTA.ToString(),
                PF087_SEQ_OCORRENCIA = PF087.DCLPF_PROC_PROPOSTA.PF087_SEQ_OCORRENCIA.ToString(),
                PF087_NUM_DET_ARQ_PROPOSTA = PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_DET_ARQ_PROPOSTA.ToString(),
                PF087_NUM_ERRO_PROPOSTA = PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_ERRO_PROPOSTA.ToString(),
                PF087_NUM_APOLICE_VINCULADA = PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_APOLICE_VINCULADA.ToString(),
                PF087_NUM_LINHA_ARQUIVO = PF087.DCLPF_PROC_PROPOSTA.PF087_NUM_LINHA_ARQUIVO.ToString(),
                PF087_DES_CONTEUDO = PF087.DCLPF_PROC_PROPOSTA.PF087_DES_CONTEUDO.ToString(),
                PF087_STA_PROCESSAMENTO = PF087.DCLPF_PROC_PROPOSTA.PF087_STA_PROCESSAMENTO.ToString(),
                PF087_COD_USUARIO = PF087.DCLPF_PROC_PROPOSTA.PF087_COD_USUARIO.ToString(),
            };

            R8210_00_INSERT_CNTRLE_PROC_DB_INSERT_1_Insert1.Execute(r8210_00_INSERT_CNTRLE_PROC_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8210_SAIDA*/

        [StopWatch]
        /*" R8220-00-SELECT-RELATORI-SECTION */
        private void R8220_00_SELECT_RELATORI_SECTION()
        {
            /*" -5333- MOVE '8220' TO WNR-EXEC-SQL. */
            _.Move("8220", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5341- PERFORM R8220_00_SELECT_RELATORI_DB_SELECT_1 */

            R8220_00_SELECT_RELATORI_DB_SELECT_1();

            /*" -5344-  EVALUATE SQLCODE  */

            /*" -5345-  WHEN ZEROS  */

            /*" -5345- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -5346- MOVE 'SIM' TO WS-SEM-PERDAO */
                _.Move("SIM", WS_SEM_PERDAO);

                /*" -5347-  WHEN +100  */

                /*" -5347- ELSE IF   SQLCODE EQUALS  +100 */
            }
            else

            if (DB.SQLCODE == +100)
            {

                /*" -5348- CONTINUE */

                /*" -5349-  WHEN OTHER  */

                /*" -5349- ELSE */
            }
            else
            {


                /*" -5350- DISPLAY 'ERRO SELECT RELATORIOS - PERDAO' */
                _.Display($"ERRO SELECT RELATORIOS - PERDAO");

                /*" -5351- DISPLAY 'CERTIFICADO = ' V0PROP-NRCERTIF */
                _.Display($"CERTIFICADO = {V0PROP_NRCERTIF}");

                /*" -5352- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -5354-  END-EVALUATE  */

                /*" -5354- END-IF */
            }


            /*" -5354- . */

        }

        [StopWatch]
        /*" R8220-00-SELECT-RELATORI-DB-SELECT-1 */
        public void R8220_00_SELECT_RELATORI_DB_SELECT_1()
        {
            /*" -5341- EXEC SQL SELECT CODRELAT INTO :V0RELA-CODRELAT FROM SEGUROS.V0RELATORIOS WHERE NRCERTIF = :V0PROP-NRCERTIF AND CODRELAT = 'PERDAO' AND SITUACAO = '0' WITH UR END-EXEC. */

            var r8220_00_SELECT_RELATORI_DB_SELECT_1_Query1 = new R8220_00_SELECT_RELATORI_DB_SELECT_1_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R8220_00_SELECT_RELATORI_DB_SELECT_1_Query1.Execute(r8220_00_SELECT_RELATORI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RELA_CODRELAT, V0RELA_CODRELAT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8220_99_SAIDA*/

        [StopWatch]
        /*" R8230-00-UPDATE-RELATORIOS-SECTION */
        private void R8230_00_UPDATE_RELATORIOS_SECTION()
        {
            /*" -5364- MOVE 'R8230' TO WNR-EXEC-SQL. */
            _.Move("R8230", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5371- PERFORM R8230_00_UPDATE_RELATORIOS_DB_UPDATE_1 */

            R8230_00_UPDATE_RELATORIOS_DB_UPDATE_1();

            /*" -5374-  EVALUATE SQLCODE  */

            /*" -5375-  WHEN ZEROS  */

            /*" -5376-  WHEN +100  */

            /*" -5376- IF   SQLCODE EQUALS ZEROS OR  +100 */

            if (DB.SQLCODE.In("00", "+100"))
            {

                /*" -5377- CONTINUE */

                /*" -5378-  WHEN OTHER  */

                /*" -5378- ELSE */
            }
            else
            {


                /*" -5379- DISPLAY 'R8230-00 (ERRO - UPDATE RELATORIOS   )' */
                _.Display($"R8230-00 (ERRO - UPDATE RELATORIOS   )");

                /*" -5380- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF */
                _.Display($"CERTIF: {V0PROP_NRCERTIF}");

                /*" -5381- MOVE 'X' TO WS-TIPO-MENSAGEM */
                _.Move("X", WS_TIPO_MENSAGEM);

                /*" -5382- MOVE '18101' TO WNR-EXEC-SQL */
                _.Move("18101", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -5384- MOVE 'ERRO NO UPDATE DA TABELA RELATORIOS - PERDAO' TO WS-MSG-DESCRICAO */
                _.Move("ERRO NO UPDATE DA TABELA RELATORIOS - PERDAO", WS_MSG_DESCRICAO);

                /*" -5385- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -5387-  END-EVALUATE  */

                /*" -5387- END-IF */
            }


            /*" -5387- . */

        }

        [StopWatch]
        /*" R8230-00-UPDATE-RELATORIOS-DB-UPDATE-1 */
        public void R8230_00_UPDATE_RELATORIOS_DB_UPDATE_1()
        {
            /*" -5371- EXEC SQL UPDATE SEGUROS.V0RELATORIOS SET SITUACAO = '1' , PERI_FINAL = :V1SIST-DTMOVABE WHERE NRCERTIF = :V0PROP-NRCERTIF AND CODRELAT = 'PERDAO' AND SITUACAO = '0' END-EXEC. */

            var r8230_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1 = new R8230_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1()
            {
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            R8230_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1.Execute(r8230_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8230_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-FINALIZA-PGM-SECTION */
        private void R9000_00_FINALIZA_PGM_SECTION()
        {
            /*" -5397- DISPLAY ' ' */
            _.Display($" ");

            /*" -5398- DISPLAY '--------- QUANTIDADES PROCESSADAS --------------' */
            _.Display($"--------- QUANTIDADES PROCESSADAS --------------");

            /*" -5399- DISPLAY 'CERTIFICADOS LIDOS.............. ' WACC-LIDOS. */
            _.Display($"CERTIFICADOS LIDOS.............. {AREA_DE_WORK.WACC_LIDOS}");

            /*" -5400- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -5401- DISPLAY 'BOLETOS ADIMPLENTES GERADOS..... ' WACC-GRAV-BOL. */
            _.Display($"BOLETOS ADIMPLENTES GERADOS..... {AREA_DE_WORK.WACC_GRAV_BOL}");

            /*" -5402- DISPLAY 'DEB.CONTA ADIMPLENTES GERADOS... ' WACC-GRAV-CONTA */
            _.Display($"DEB.CONTA ADIMPLENTES GERADOS... {AREA_DE_WORK.WACC_GRAV_CONTA}");

            /*" -5403- DISPLAY 'CARTAO CRED ADIMPLENTES GERADOS. ' WACC-GRAV-CARTAO */
            _.Display($"CARTAO CRED ADIMPLENTES GERADOS. {AREA_DE_WORK.WACC_GRAV_CARTAO}");

            /*" -5404- DISPLAY 'PARCELAS ADIMPLENTES GERADAS.... ' WACC-GRAVADOS. */
            _.Display($"PARCELAS ADIMPLENTES GERADAS.... {AREA_DE_WORK.WACC_GRAVADOS}");

            /*" -5405- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -5406- DISPLAY 'BOLETOS INADIMPLENTE GERADOS.... ' WACC-ATRZ-BOL. */
            _.Display($"BOLETOS INADIMPLENTE GERADOS.... {AREA_DE_WORK.WACC_ATRZ_BOL}");

            /*" -5407- DISPLAY 'DEB.CONTA INADIMPLENTE GERADOS.. ' WACC-ATRZ-CONTA */
            _.Display($"DEB.CONTA INADIMPLENTE GERADOS.. {AREA_DE_WORK.WACC_ATRZ_CONTA}");

            /*" -5408- DISPLAY 'CARTAO CRED INADIMPLENTE GERADOS ' WACC-ATRZ-CARTAO */
            _.Display($"CARTAO CRED INADIMPLENTE GERADOS {AREA_DE_WORK.WACC_ATRZ_CARTAO}");

            /*" -5409- DISPLAY 'PARCELAS INADIMPLENTES COM ERRO. ' WACC-ERRO-ATRZ. */
            _.Display($"PARCELAS INADIMPLENTES COM ERRO. {AREA_DE_WORK.WACC_ERRO_ATRZ}");

            /*" -5410- DISPLAY 'PARCELAS INADIMPLENTES GERADA... ' WACC-GRAV-ATRZ. */
            _.Display($"PARCELAS INADIMPLENTES GERADA... {AREA_DE_WORK.WACC_GRAV_ATRZ}");

            /*" -5411- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -5412- DISPLAY 'CERTIFICADOS CANCELADOS......... ' WACC-GRAV-CANC. */
            _.Display($"CERTIFICADOS CANCELADOS......... {AREA_DE_WORK.WACC_GRAV_CANC}");

            /*" -5413- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -5414- DISPLAY 'QTD SAIDA PELA SITUACAO 01...... ' WS-QTD-SIT-01 */
            _.Display($"QTD SAIDA PELA SITUACAO 01...... {WS_QTD_SIT_01}");

            /*" -5415- DISPLAY 'QTD SAIDA PELA SITUACAO 02...... ' WS-QTD-SIT-02 */
            _.Display($"QTD SAIDA PELA SITUACAO 02...... {WS_QTD_SIT_02}");

            /*" -5416- DISPLAY 'QTD SAIDA PELA SITUACAO 03...... ' WS-QTD-SIT-03 */
            _.Display($"QTD SAIDA PELA SITUACAO 03...... {WS_QTD_SIT_03}");

            /*" -5417- DISPLAY 'QTD SAIDA PELA SITUACAO 04...... ' WS-QTD-SIT-04 */
            _.Display($"QTD SAIDA PELA SITUACAO 04...... {WS_QTD_SIT_04}");

            /*" -5418- DISPLAY 'QTD SAIDA PELA SITUACAO 05...... ' WS-QTD-SIT-05 */
            _.Display($"QTD SAIDA PELA SITUACAO 05...... {WS_QTD_SIT_05}");

            /*" -5419- DISPLAY 'QTD SAIDA PELA SITUACAO 06...... ' WS-QTD-SIT-06 */
            _.Display($"QTD SAIDA PELA SITUACAO 06...... {WS_QTD_SIT_06}");

            /*" -5420- DISPLAY 'QTD SAIDA PELA SITUACAO 07...... ' WS-QTD-SIT-07 */
            _.Display($"QTD SAIDA PELA SITUACAO 07...... {WS_QTD_SIT_07}");

            /*" -5421- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -5422- DISPLAY 'QTD TP-MENSAGEM SUCESSO......... ' WS-QTD-TP-MSG-S */
            _.Display($"QTD TP-MENSAGEM SUCESSO......... {AREA_DE_WORK.WS_QTD_TP_MSG_S}");

            /*" -5423- DISPLAY 'QTD TP-MENSAGEM CANCELAMENTO.... ' WS-QTD-TP-MSG-C */
            _.Display($"QTD TP-MENSAGEM CANCELAMENTO.... {AREA_DE_WORK.WS_QTD_TP_MSG_C}");

            /*" -5424- DISPLAY 'QTD TP-MENSAGEM ERRO CERTIF..... ' WS-QTD-TP-MSG-E */
            _.Display($"QTD TP-MENSAGEM ERRO CERTIF..... {AREA_DE_WORK.WS_QTD_TP_MSG_E}");

            /*" -5425- DISPLAY 'QTD TP-MENSAGEM ALERTA.......... ' WS-QTD-TP-MSG-A */
            _.Display($"QTD TP-MENSAGEM ALERTA.......... {AREA_DE_WORK.WS_QTD_TP_MSG_A}");

            /*" -5426- DISPLAY 'QTD TP-MENSAGEM INFORMACAO...... ' WS-QTD-TP-MSG-I */
            _.Display($"QTD TP-MENSAGEM INFORMACAO...... {AREA_DE_WORK.WS_QTD_TP_MSG_I}");

            /*" -5427- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -5428- DISPLAY '*-----------  VA0853B - FIM NORMAL  -----------*' */
            _.Display($"*-----------  VA0853B - FIM NORMAL  -----------*");

            /*" -5430- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -5431- MOVE '9' TO WS-TIPO-MENSAGEM */
            _.Move("9", WS_TIPO_MENSAGEM);

            /*" -5433- PERFORM R8200-00-GERAR-CNTRLE-PROC. */

            R8200_00_GERAR_CNTRLE_PROC_SECTION();

            /*" -5434- IF (LK-OPERACAO EQUAL 'ROLLBACK' ) */

            if ((LK_PARAMETROS.LK_OPERACAO == "ROLLBACK"))
            {

                /*" -5435- DISPLAY 'ROLLBACK FEITO' */
                _.Display($"ROLLBACK FEITO");

                /*" -5435- EXEC SQL ROLLBACK WORK END-EXEC */

                DatabaseConnection.Instance.RollbackTransaction();

                /*" -5437- ELSE */
            }
            else
            {


                /*" -5438- DISPLAY 'COMMIT FEITO ' */
                _.Display($"COMMIT FEITO ");

                /*" -5438- EXEC SQL COMMIT WORK END-EXEC */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -5441- END-IF. */
            }


            /*" -5448- DISPLAY 'FINAL DO PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"FINAL DO PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -5450- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -5452- CLOSE ARQSAIDA. */
            ARQSAIDA.Close();

            /*" -5452- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -5467- MOVE SQLCODE TO WSQLCODE WSL-SQLCODE */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE, AREA_DE_WORK.WSL_SQLCODE);

            /*" -5468- DISPLAY 'CERTIFICADO.: ' V0PROP-NRCERTIF */
            _.Display($"CERTIFICADO.: {V0PROP_NRCERTIF}");

            /*" -5469- DISPLAY 'MENSAGEM....: ' WS-MSG-DESCRICAO */
            _.Display($"MENSAGEM....: {WS_MSG_DESCRICAO}");

            /*" -5470- DISPLAY 'NUM-ERRO....: ' WS-NUM-ERRO. */
            _.Display($"NUM-ERRO....: {WS_NUM_ERRO}");

            /*" -5472- DISPLAY 'TIPO-MENS...: ' WS-TIPO-MENSAGEM */
            _.Display($"TIPO-MENS...: {WS_TIPO_MENSAGEM}");

            /*" -5474- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -5476- MOVE SQLERRMC TO WSQLERRMC. */
            _.Move(DB.SQLERRMC, AREA_DE_WORK.WSQLERRO.WSQLERRMC);

            /*" -5478- DISPLAY WSQLERRO */
            _.Display(AREA_DE_WORK.WSQLERRO);

            /*" -5478- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -5481- IF (WS-TIPO-MENSAGEM NOT EQUAL 'X' ) */

            if ((WS_TIPO_MENSAGEM != "X"))
            {

                /*" -5482- PERFORM R6000-00-GRAVAR-RELAT-SAIDA */

                R6000_00_GRAVAR_RELAT_SAIDA_SECTION();

                /*" -5484- END-IF. */
            }


            /*" -5485- IF (LK-OPERACAO EQUAL 'COMMIT' ) */

            if ((LK_PARAMETROS.LK_OPERACAO == "COMMIT"))
            {

                /*" -5485- EXEC SQL COMMIT WORK END-EXEC */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -5488- END-IF. */
            }


            /*" -5490- CLOSE ARQSAIDA. */
            ARQSAIDA.Close();

            /*" -5492- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -5492- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}