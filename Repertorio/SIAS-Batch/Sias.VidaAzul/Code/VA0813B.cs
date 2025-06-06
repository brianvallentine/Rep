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
using Sias.VidaAzul.DB2.VA0813B;

namespace Code
{
    public class VA0813B
    {
        public bool IsCall { get; set; }

        public VA0813B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"MONIT *<20/05/2016> AS <15:17:45>-<KINKAS> INCLUS�O MONITORAMENTO             */
        /*"      ******************************************************************      */
        /*"      *      RETORNO DOS LANCAMENTOS DE DEBITO EM CONTA FEBRABAN       *      */
        /*"      *           CONVENIOS 6081 GLOBAL , 6088 MULTIPREMIADO,          *      */
        /*"      *                                                                *      */
        /*"      *                     6153 PREFERENCIAL VIDA                     *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *  DESCRICAO SUMARIA                             21.10.97        *      */
        /*"      *                                                                *      */
        /*"      *         O PROGRAMA LE O MOVIMENTO DE RETORNO DOS LANCAMENTOS   *      */
        /*"      *     DE DEBITO DE SEGURO E EFETUA A QUITACAO OU A GERACAO DO    *      */
        /*"      *     RETORNO DO DEBITO NAO EFETUADO.                            *      */
        /*"      *                                                                *      */
        /*"      *         AS PARCELAS NAO DEBITADAS POR CONTA NAO CADASTRADA OU  *      */
        /*"      *     POR QUALQUER MOTIVO QUE GERE O CANCELAMENTO DO DEBITO      *      */
        /*"      *     IRAO FORCAR A MUDANCA DA OPCAO DE PAGAMENTO DO SEGURO DE   *      */
        /*"      *     DEBITO EM CONTA PARA CARNE, NAO GERANDO O CANCELAMENTO DO  *      */
        /*"      *     SEGURO.                                                    *      */
        /*"      *                                                                *      */
        /*"      *         CASO A PARCELA TENHA SIDO PAGA, EH GERADA A TABELA     *      */
        /*"      *     V0REPASSECDG INDICANDO QUE DEVE SER FEITO O REPASSE.       *      */
        /*"      *                                                                *      */
        /*"      *         E GERADO O ARQUIVO RETERR COM O RETORNO QUE APRESENTE  *      */
        /*"      *     INCONSISTENCIA NA ATUALIZACAO, PARA EMISSAO DE RELATORIO,  *      */
        /*"      *     CONTENDO A MENSAGEM DE ERRO.                               *      */
        /*"      *                                                                *      */
        /*"      *                                    ALEXANDRE FONSECA           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO ..............  GILSON PINTO DA SILVA - 31/01/2024 *      */
        /*"      *   VERSAO 89               - INCLUIR A COLUNA STA_DEPOSITO_TER  *      */
        /*"      *                             NA TABELA AVISO_CREDITO PARA FAZER *      */
        /*"      *                             A CONCILIACAO DOS AVISOS DE CREDITO*      */
        /*"      *                             MANUAL COM O DEPOSITO DE TERCEIRO  *      */
        /*"      *                             (DT) NO MCP-ZE.                    *      */
        /*"      *                           - ESTA COLUNA ASSUME COMO DEFAULT O  *      */
        /*"      *                             DOMINIO 'P' (CREDITO NAO CONSUMIDO)*      */
        /*"      *                             E SOMENTE OS PROGRAMAS DO SISTEMA  *      */
        /*"      *                             "ZE" EH QUE ATUALIZARAO A MESMA.   *      */
        /*"      *                           - JAZZ - DEMANDA - 569880            *      */
        /*"      *                                    TAREFA  - 569478            *      */
        /*"      *                           - PROCURAR POR V.89                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 88 - DEMANDA 280.598                                  *      */
        /*"      *             - AJUSTES NA REGRA DA REGUA DE COBRANCA            *      */
        /*"      *                                                                *      */
        /*"      *   EM 10/11/2021 - FRANK CARVALHO                               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.88         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 87 - DEMANDA 278.146                                  *      */
        /*"      *             - ALTERACAO DA REGRA DA REGUA DE COBRANCA          *      */
        /*"      *             - UTILIZAR O CAMPO MOTIVO DE COMPENSACAO PARA      *      */
        /*"      *               MANTER OU NAO O REGISTRO EM REGUA DE COBRANCA.   *      */
        /*"      *                                                                *      */
        /*"      *   EM 23/03/2021 - FRANK CARVALHO                               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.87         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.86  *VERSAO V.86-DEMANDA 281754-KINKAS 29/03/2021-ESTIPULANTE FENAE  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 85 - DEMANDA 220882                                   *      */
        /*"      *             - VOC_ADEQUACAO DA NOVA REGUA DE COBRANCA          *      */
        /*"      *               PARA DEBITO EM CONTA.                            *      */
        /*"      *                                                                *      */
        /*"      *               EM CASO DE INSUFICIENCIA DE FUNDOS O SAP         *      */
        /*"      *               PASSA A RECOMANDAR O DEBITO E DISPONILIZAR DOIS  *      */
        /*"      *               ARQUIVOS DE RETORNO ARQH.                        *      */
        /*"      *                                                                *      */
        /*"      *               NO PRIMEIRO ARQH, OCORRENDO INSUFICIENCIA DE     *      */
        /*"      *               FUNDOS COBER_HIST_VIDAZUL FICA COM SITUACAO:     *      */
        /*"      *               "AGUARD. RECOMANDO SAP".                         *      */
        /*"      *                                                                *      */
        /*"      *               NO SEGUNDO RETORNO ARQH A SITUACAO DA COBRANCA   *      */
        /*"      *               E ALTERADA DEFINITIVAMENTE EM FUNCAO DO CODIGO   *      */
        /*"      *               DE RETORNO SAP.                                  *      */
        /*"      *                                                                *      */
        /*"      *   EM 12/12/2019 - TERCIO CARVALHO                              *      */
        /*"      *   EM 10/12/2020 - FRANK CARVALHO (AJUSTES E TESTES INTEGRADOS) *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.85         *      */
        /*"JV184#*----------------------------------------------------------------*      */
        /*"JV184#*VERSAO 84: JV1 DEMANDA 262179 - KINKAS 28/10/2020               *      */
        /*"JV184#*           TROCA REFERENCIAS PRODUTOS JV1 POR JVPRDXXXX         *      */
        /*"JV184#*           - PROCURAR POR JV184                                 *      */
        /*"JV183 *----------------------------------------------------------------*      */
        /*"JV183 *VERSAO 83: JV1 DEMANDA 259990 - KINKAS 10/09/2020               *      */
        /*"JV183 *           INCLUI/EXCLUI APOLICES E PRODUTOS JV1                *      */
        /*"JV183 *           - PROCURAR POR JV183                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 82 - ABEND 229994                                     *      */
        /*"      *             - NAO ATUALIZAR O TIMESTAMP DA TABELA V0PARCELVA   *      */
        /*"      *               PARA QUE FIQUE ARMAZENADA A DATA DA GERACAO DA   *      */
        /*"      *               PARCELA ATE QUE TENHA UM CAMPO ESPECIFICO PARA   *      */
        /*"      *               ARMAZENAR ESTA INFORMACAO.                       *      */
        /*"      *                                                                *      */
        /*"      *   EM 15/01/2019 - FRANK CARVALHO                               *      */
        /*"      *                                       PROCURE POR V.82         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"JV183 *   VERSAO 81 - ABEND 188993                                     *      */
        /*"      *             - DEVIDO AO ERRO -531, IDENTIFIQUEI QUE NAO E      *      */
        /*"      *               NECESSARIA A ATUALIZACAO DO NUMERO DO TITULO E   *      */
        /*"      *               OPCAO DE PAGAMENTO DA COBER_HIST_VIDAZUL.        *      */
        /*"      *                                                                *      */
        /*"      *   EM 06/11/2019 - CLAUDETE RADEL                               *      */
        /*"      *                                       PROCURE POR V.81         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 80 - HIST 181.573                                     *      */
        /*"      *             - PREPARAR PROGRAMA PARA PROCESSAMENTO DA JV1      *      */
        /*"      *                                                                *      */
        /*"      *   EM 17/01/2019 - HUSNI ALI HUSNI                              *      */
        /*"      *                                       PROCURE POR JV101        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 79 - CAD 151.828                                      *      */
        /*"      *             - ALTERAR A ORDEM DE BUSCA DE PARCELAS PARA EFETUAR*      */
        /*"      *               A BAIXA. HAVIA INCOSISTENCIA NA BAIXA DA PARCELA *      */
        /*"      *               QUANDO O CLIENTE POSSUIA MAIS DE UMA PARCELA COM *      */
        /*"      *               VENCIMENTO NO MESMO DIA.                         *      */
        /*"      *                                                                *      */
        /*"      *   EM 23/06/2017 - FRANK CARVALHO                               *      */
        /*"      *                                        PROCURE POR V.79        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 78 - CAD 151.094                                      *      */
        /*"      *             - CORRECAO NA LEITURA DA TABELA DE RAMO-CONJ PARA  *      */
        /*"      *               PEGAR AS APOLICES QUE FAZEM DIVISAO DE PREMIO    *      */
        /*"      *               POR RAMO CONFORME CIRCULAR SUSEP 395.            *      */
        /*"      *             - PEGAR O VALOR DA DIT DA TABELA HIS-COBER-PROPOST *      */
        /*"      *               ATUALIZADO PARA COMPOR O RAMO 90 DA CIRCULAR     *      */
        /*"      *               SUSEP 395.                                       *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/02/2017 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                        PROCURE POR V.78        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 77 - FGV-2                                            *      */
        /*"      *                                                                *      */
        /*"      *             - AJUSTE PARA MELHORIA DE DESEMPENHO DO PROGRAMA.  *      */
        /*"      *               FOI INCLUIDO O NUMERO DO CERTIFICADO NO CURSOR   *      */
        /*"      *               PARA QUE O DB2 USE O INDICE E NAO PRECISE FAZER  *      */
        /*"      *               SORT INTERNO.                                    *      */
        /*"      *                                                                *      */
        /*"      *   EM 29/03/2017 - KINKAS                                       *      */
        /*"      *                                        PROCURE POR V.77        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 76 - CAD 148.444 - ABEND                              *      */
        /*"      *                                                                *      */
        /*"      *             - ERRO -811 NA TABELA TERMO_ADESAO POR ENCONTRAR   *      */
        /*"      *               DUAS LINHAS PARA APOLICE/SUBGRUPO. PEGAR O QUE   *      */
        /*"      *               TIVER MAIOR NUM_TERMO PARA N�O ABENDAR O PROGRAMA*      */
        /*"      *                                                                *      */
        /*"      *   EM 22/02/2017 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                        PROCURE POR V.76        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 75 - CAD 147.164 - ABEND                              *      */
        /*"      *                                                                *      */
        /*"      *             - NAO ALTERAR O NUMERO DO TITULO QUANDO OCORRER A  *      */
        /*"      *               MIGRACAO DE DEBITO EM CONTA PARA BOLETO QUANDO O *      */
        /*"      *               STATUS DA PROPOSTA FOR '4 - CANCELADA'.          *      */
        /*"      *               POIS AO MUDAR O TITULO E SE EXISTIR ESTORNO NA   *      */
        /*"      *               TABELA VG_PESS_PARCELA, O PROGRAMA LANCA O ERRO  *      */
        /*"      *               -531. A SPBSC060 DEVE SER REVISTA PARA NAO LANCAR*      */
        /*"      *               ESTORNO QUANDO HA PARCELAS PENDENTES DE RETORNO  *      */
        /*"      *               DO SAP.                                          *      */
        /*"      *                                                                *      */
        /*"      *   EM 14/02/2017 - LUIGI CONTE                                  *      */
        /*"      *                                        PROCURE POR V.75        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 74 - CAD 146.450                                      *      */
        /*"      *                                                                *      */
        /*"      *             - INCLUIR TRATAMENTO SQLCODE -803 NO INSERT DA     *      */
        /*"      *               SEGUROS.V0AVISOS_SALDOS                          *      */
        /*"      *                                                                *      */
        /*"      *   EM 10/02/2017 - LUIGI E MAURO                                *      */
        /*"      *                                        PROCURE POR V.74        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 73 - FGV-2                                            *      */
        /*"      *                                                                *      */
        /*"      *             - AJUSTAR O PROGRAMA A FIM DE PERMITIR O PARALELIS-*      */
        /*"      *               MO DOS JOBS JPVAD00 E JPCSD01                    *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/02/2017 - CLAUDETE RADEL                               *      */
        /*"      *                                        PROCURE POR V.73        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 72 - CAD 136.658 - ABEND                              *      */
        /*"      *                                                                *      */
        /*"      *             - NAO ALTERAR O NUMERO DO TITULO QUANDO OCORRER A  *      */
        /*"      *               MIGRACAO DE DEBITO EM CONTA PARA BOLETO QUANDO O *      */
        /*"      *               STATUS DA PROPOSTA FOR '4 - CANCELADA'.          *      */
        /*"      *               POIS AO MUDAR O TITULO E SE EXISTIR ESTORNO NA   *      */
        /*"      *               TABELA VG_PESS_PARCELA, O PROGRAMA LANCA O ERRO  *      */
        /*"      *               -531. A SPBSC060 DEVE SER REVISTA PARA NAO LANCAR*      */
        /*"      *               ESTORNO QUANDO HA PARCELAS PENDENTES DE RETORNO  *      */
        /*"      *               DO SAP.                                          *      */
        /*"      *                                                                *      */
        /*"      *   EM 19/05/2016 - CLAUDETE RADEL                               *      */
        /*"      *                                        PROCURE POR V.72        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 71 - CAD 125.925                                      *      */
        /*"      *                                                                *      */
        /*"      *             - ALTERACAO NA COBRANCA QUANTO A MIGRACAO DE DEBITO*      */
        /*"      *               EM CONTA PARA BOLETO PARA PRODUTOS VIDA INFORMADO*      */
        /*"      *               NAO DEIXA MIGRAR PARA BOLETO                     *      */
        /*"      *                                                                *      */
        /*"      *   EM 16/02/2016 - THIAGO BLAIER                                *      */
        /*"      *                                        PROCURE POR V.71        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 70 - CAD 127.384                                      *      */
        /*"      *                                                                *      */
        /*"      *             - RETIRADA DE DISPLAY SOLICITADO PELA PRODUCAO     *      */
        /*"      *                                                                *      */
        /*"      *   EM 12/01/2016 - THIAGO BLAIER                                *      */
        /*"      *                                                                *      */
        /*"      *                                        PROCURE POR V.70        *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 69 - CAD 122.275                                      *      */
        /*"      *                                                                *      */
        /*"      *             - DESATIVAR AUXILIO ALIMENTACAO NO SIAS.           *      */
        /*"      *                                                                *      */
        /*"      *   EM 21/09/2015 - MARCUS VALERIO (ALTRAN)                      *      */
        /*"      *                                                                *      */
        /*"      *                                        PROCURE POR V.69        *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 68   - CADMUS 119203. (VERSAO COMENTADA)              *      */
        /*"      *                                                                *      */
        /*"      *   AJUSTE NO NR. TITULO QUANDO A FORMA DE PAGAMENTO MUDA DE     *      */
        /*"      *   DEBITO EM CONTA PARA BOLETO.                                 *      */
        /*"      *   EM 03/11/2015 - LUIGI CONTE (INDRA COMPANY)                  *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.68         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 67 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   AJUSTE LAYOUT ARQUIVO MOVIMENTO (RETDEB)                     *      */
        /*"      *   EM 21/12/2014 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.67         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 66 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/12/2014 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.66         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 65 - CADMUS 99249                                     *      */
        /*"      *                                                                *      */
        /*"      *      - NAO DEIXAR MIGRAR AUTOMATICAMENTE A FORMA DE PAGAMENTO  *      */
        /*"      *        DE DEBITO EM CONTA PARA BOLETO PARA OS PRODUTOS 9329 E  *      */
        /*"      *        8205 EMPRESARIAL GLOBAL                                 *      */
        /*"      *   EM 11/11/2014 - THIAGO BLAIER                                *      */
        /*"      *                                            PROCURE POR V.65    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 64 - CADMUS 96745                                     *      */
        /*"      *                                                                *      */
        /*"      *      - POPULAR INFORMACOES BANCARIAS NO SIAS PARA PRODUTOS DE  *      */
        /*"      *        BALCAO INDEPENDENTEMENTE DE FORMA DE PAGAMENTO          *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/09/2014 - RIBAMAR MARQUES                              *      */
        /*"      *                                            PROCURE POR V.64    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 63 -CADMUS 101217                                     *      */
        /*"      *                                                                *      */
        /*"      *             - RESSEGURO                                        *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/08/2014 - LUIZ GUSTAVO DE OLIVEIRA                     *      */
        /*"      *                                            PROCURE POR V.63    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 62 -CADMUS 99380                                      *      */
        /*"      *                                                                *      */
        /*"      *             - INCLUIR SIT_REGISTRO 5 NO SELECT V0HISTCOBVA     *      */
        /*"      *                                                                *      */
        /*"      *   EM 17/06/2014 - BRICE HO                                     *      */
        /*"      *                                            PROCURE POR V.62    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 61 -CADMUS 90985                                      *      */
        /*"      *                                                                *      */
        /*"      *             - RETIRA DISPLAY.                                  *      */
        /*"      *                                                                *      */
        /*"      *   EM 04/12/2013 - CLOVIS                                       *      */
        /*"      *                                            PROCURE POR V.61    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 60 -CADMUS 90985                                      *      */
        /*"      *                                                                *      */
        /*"      *             - VA0813B - PROBLEMAS NO SELECT NSAS V0HISTCONT    *      */
        /*"      *               SQL SQLCODE = 811-                               *      */
        /*"      *               R0036-00-ACESSO-NSAS                             *      */
        /*"      *               CERTIFICADO 000010000133615 PARCELA 0245         *      */
        /*"      *               NSAS = 27065    -   NSL = 0009                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 03/12/2013 - CLOVIS                                       *      */
        /*"      *                                            PROCURE POR V.60    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 59 - CAD 85.017                                       *      */
        /*"      *                                                                *      */
        /*"      *             - DIVISAO DO VALOR DIT CONFORME CADASTRADO NA CIRC *      */
        /*"      *               SUSEP 395 NO RAMO 90 E MODALIDADE 05             *      */
        /*"      *                                                                *      */
        /*"      *   EM 12/11/2013 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                            PROCURE POR V.59    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *    VERSAO 58 - CAD 10.003                                      *      */
        /*"      *                                                                *      */
        /*"      *               - CONVERSAO DO DB2 PARA A VERSAO 10              *      */
        /*"      *                                                                *      */
        /*"      *    EM 30/09/2013 -  ROGERIO PEREIRA                            *      */
        /*"      *                                                                *      */
        /*"      *                                             PROCURE POR V.58   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 57 - CAD 85042                                        *      */
        /*"      *                                                                *      */
        /*"      *              - CORRECAO DE QUERY ERRO DE PRODUTO CARTESIANO    *      */
        /*"      *                                                                *      */
        /*"      *   EM 01/08/2013 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.57    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 56 - CAD 74.015                                       *      */
        /*"      *                                                                *      */
        /*"      *              - AJUSTE NO TAMANHO DA TABELA INTERNA DE PRODUTOS.*      */
        /*"      *                                                                *      */
        /*"      *   EM 10/09/2012 - AUGUSTO ANASTACIO   (FAST COMPUTER)          *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.56    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 55 - CAD 69.198                                       *      */
        /*"      *                                                                *      */
        /*"      *               - RETIRAR DISPLAYS                               *      */
        /*"      *                                                                *      */
        /*"      *   EM 27/04/2012 - EDIVALDO GOMES      (FAST COMPUTER)          *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.55    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 54 - CAD 61.042                                       *      */
        /*"      *                                                                *      */
        /*"      *               - INCLUSAO DA APOLICE 109300001819 EM            *      */
        /*"      *                 EM SUBSTITUICAO DA  109300001670 EM FUNCAO     *      */
        /*"      *                 DE ESTOURO NA COLUNA COD_SUBGUPO DA TABELA     *      */
        /*"      *                 SEGUROS.SUBGRUPOS_VGAP.                        *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/08/2011 - ALESSANDRO G. RAMOS (FAST COMPUTER)          *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.54    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 53 - CAD 57.911                                       *      */
        /*"      *                                                                *      */
        /*"      *              - NAO PERMITE ATUALIZACAO DE DATA QUITACAO PARA   *      */
        /*"      *                MOVIMENTOS COM ORIGEM 1004 - PAR.               *      */
        /*"      *                                                                *      */
        /*"      *   EM 16/06/2011 - EDIVALDO GOMES (FAST COMPUTER)               *      */
        /*"      *                                          PROCURE POR V.53      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 52 - CAD 201.053                                      *      */
        /*"      *                                                                *      */
        /*"      *              - CORRIGE VALORES NEGATIVOS                       *      */
        /*"      *                                                                *      */
        /*"      *   EM 04/05/2011 - LEANDRO CORTES (FAST COMPUTER)               *      */
        /*"      *                                          PROCURE POR V.52      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 51 - CAD 53.241                                       *      */
        /*"      *                                                                *      */
        /*"      *              - CANCELA PROPOSTA QUANDO RETORNO DE COBRANCA DO  *      */
        /*"      *                CANAL CERAT FOR DIFERENTE DE ZERO.              *      */
        /*"      *                                                                *      */
        /*"      *   EM 04/03/2011 - EDIVALDO GOMES (FAST COMPUTER)               *      */
        /*"      *                                          PROCURE POR V.51      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 50 - CAD 54.079                                       *      */
        /*"      *                                                                *      */
        /*"      *              - CORRECAO DO ABEND SQLCODE = -180                *      */
        /*"      *                                                                *      */
        /*"      *   EM 09/03/2011 - MARCO PAIVA (FAST COMPUTER)                  *      */
        /*"      *                                            PROCURE POR V.50    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 49 - CAD 48.762                                       *      */
        /*"      *                                                                *      */
        /*"      *              - CIRCULAR SUSEP 395                              *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/11/2010 - MARCO PAIVA (FAST COMPUTER)                  *      */
        /*"      *                                          PROCURE POR V.49      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 48 - CAD 51.170                                       *      */
        /*"      *                                                                *      */
        /*"      *              - AJUSTE NO TAMANHO DA TABELA INTERNA DE PRODUTOS.*      */
        /*"      *                                                                *      */
        /*"      *   EM 08/12/2010 - MARCO PAIVA (FAST COMPUTER)                  *      */
        /*"      *                                          PROCURE POR V.48      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 47 - CAD 42.678                                       *      */
        /*"      *                                                                *      */
        /*"      *               - REPASSE DE COMISSIONAMENTO DAS VENDAS DO       *      */
        /*"      *                 CANAL CORRESPONDENTE BANCARIO PARA AS NOVAS    *      */
        /*"      *                 APOLICES 108210624684 (AP) E 109300001694 (VG) *      */
        /*"      *                                                                *      */
        /*"      *   EM 07/06/2010 - FAST COMPUTER - EDIVALDO GOMES               *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.47    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 46 - CADMUS 42.095                                    *      */
        /*"      *               - CORRIGE ABEND -803 NA TABELA                   *      */
        /*"      *                 SEGUROS.OPCAO_PAG_VIDAZUL.                     *      */
        /*"      *                                                                *      */
        /*"      *   EM 06/05/2010 - EDIVALDO GOMES (FAST COMPUTER)               *      */
        /*"      *                                            PROCURE POR V.46    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 45 - CADMUS 39.385 - ALTERAR A DATA DE ENCERRAMENTO   *      */
        /*"      *               DA VIGENCIA NA TABELA V0OPCAOPAGVA.              *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/03/2010 - TERCIO FREITAS (FAST COMPUTER)               *      */
        /*"      *                                            PROCURE POR V.45    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 44 - CADMUS 37.849 - CORRECAO DO ABEND OCORRIDO       *      */
        /*"      *               SQLCODE  =  -811  NA TABELA  V0HISTCOBVA         *      */
        /*"      *                                                                *      */
        /*"      *   EM 24/02/2010 - EDIVALDO GOMES (FAST COMPUTER)               *      */
        /*"      *                                            PROCURE POR V.44    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 43 - CADMUS 35.742                                    *      */
        /*"      *             - TRATA NOVO CODIGO DE PRODUTO EMPRESARIAL         *      */
        /*"      *               PARA APOLICE 109300000959 E AJUSTA REGRAS PARA   *      */
        /*"      *               APOLICE 109300001670.                            *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/01/2010 - EDIVALDO GOMES (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.43    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 42 - CADMUS 30.905 - CORRECAO DO ABEND OCORRIDO       *      */
        /*"      *               SQLCODE  =  100   NA TABELA  V0FITASASSE         *      */
        /*"      *                                                                *      */
        /*"      *   EM 10/10/2009 - MARCO PAIVA(FAST COMPUTER)                   *      */
        /*"      *                                            PROCURE POR V.42    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 41 - CADMUS 26.974 - CORRECAO DO ABEND OCORRIDO       *      */
        /*"      *               SQLCODE  =  -811  NA TABELA  V0COBERPROPVA       *      */
        /*"      *                                                                *      */
        /*"      *   EM 14/07/2009 - FAST COMPUTER            PROCURE POR V.41    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 40 - CADMUS 25.506                                    *      */
        /*"      *                                                                *      */
        /*"      *   ALTERACAO ..............  - RETIRADA DO PAGAMENTO DE         *      */
        /*"      *                               COMISSAO NAS PARCELAS 2 E 3      *      */
        /*"      *                               PARA OS PRODUTOS:                *      */
        /*"      *                                 . MULTPREMIADO SUPER           *      */
        /*"      *                                 . VIDA MULHER                  *      */
        /*"      *                                 . EMPRESA GLOBAL               *      */
        /*"      *                                                                *      */
        /*"      *   FAST COMPUTER          -    19/06/2009            V.40       *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 39                                                    *      */
        /*"      *   ALTERACAO ..............  - INCLUSAO DO CALCULO DE COMIS-    *      */
        /*"      *                               SAO DOS PRODUTOS CACB  EMPRE-    *      */
        /*"      *                               SARIAL CAD 17867                 *      */
        /*"      *   FAST COMPUTER          -    28/01/2009            V.39       *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 38                                                    *      */
        /*"      *   ALTERACAO ..............  - INCLUSAO DO CALCULO DE COMIS-    *      */
        /*"      *                               SAO DOS PRODUTOS CACB E COPESP   *      */
        /*"      *                               CAD 19097/2008                   *      */
        /*"      *   FAST COMPUTER          -    05/01/2009            V.38       *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 37                                                    *      */
        /*"      *   ALTERACAO ..............  - ALTERACAO TARIFA SICOV DE        *      */
        /*"      *                               (0,60 POR DOCTO PARA 0,80)       *      */
        /*"      *                               NA TABELA AVISO DE CREDITO.      *      */
        /*"      *                               SSI 22819/2008                   *      */
        /*"      *             CLOVIS       -    15/12/2008            V.37       *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 36                                                    *      */
        /*"      *   CADMUS 18013 - -811 NA V0HISTCOBVA                           *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      * 01/12/2009  - FAST COMPUTER             PROCURE POR V.36       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 35                                                    *      */
        /*"      *   CADMUS 17763 - -803 NA R1000-00-QUITA-PARCELA.               *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      * 24/11/2008  - FAST COMPUTER             PROCURE POR V.35       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 34                                                    *      */
        /*"      *   CADMUS 17262 - -803 NA R0400-00-GERA-COMISSAO.               *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      * 17/10/2008  - FAST COMPUTER             PROCURE POR V.34       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 33                                                    *      */
        /*"      *   CADMUS 16014 - ELIMINACAO DE DUPLICIDADE DE COMISSAO  NA     *      */
        /*"      *                  V0FUNDOCOMISVA                                *      */
        /*"      *                                                                *      */
        /*"      * 17/10/2008  - FAST COMPUTER             PROCURE POR V.33       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 32                                                    *      */
        /*"      *   CADMUS 15134 - CORRECAO DE ABEND  (SQLCODE = -811) NA TABELA *      */
        /*"      *                  V0HISTCOBVA                                   *      */
        /*"      *                                                                *      */
        /*"      * 26/09/2008  - FAST COMPUTER             PROCURE POR V.32       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 31                                                    *      */
        /*"      * PROJETO FGV (ALTERACOES)     (WELLINGTON VERAS (POLITEC))      *      */
        /*"      *                                                                *      */
        /*"      * 16/09/2008   INIBIR O COMANDO DISPLAY               - WV0908   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 30 - CADMUS 12.422 - CORRECAO DE ABEND                *      */
        /*"      *               SQLCODE = -803 NA TABELA V0COMISSAO              *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/07/2008 - FAST COMPUTER            PROCURE POR V.30    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 29 - CADMUS 6602 - CORRECAO DO ABEND OCORRIDO         *      */
        /*"      *               SQLCODE = -811 NA TABELA V0COBERPROPVA           *      */
        /*"      *                                                                *      */
        /*"      *   EM 04/12/2007 - FAST COMPUTER            PROCURE POR V.29    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 28 - INCLUIDA O PARAGRAFO R0400 PARA ATENDER A SSI    *      */
        /*"      *               17.578/2007.                                     *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/10/2007 - FAST COMPUTER            PROCURE POR V.28    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 27 - RETIRADO O ABEND -803 - CADMUS 4801.             *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/08/2007 - FAST COMPUTER            PROCURE POR V.27    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 26 - PASSA A GRAVAR A DATA_MOV_ABERTO AO INVES DA     *      */
        /*"      *               DATA DE VENCIMENTO NA V0HISTCONTABILVA.          *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/05/2007 - FAST COMPUTER            PROCURE POR V.26    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 25 - RETIRADO O ABEND PARA DUPLICIDADE NA V0HISTCOBVA *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *   EM 11/01/2007 - FAST COMPUTER            PROCURE POR V.25    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 24 - PASSOU A GERAR AQUIVO PARA AUDITORIA PARA        *      */
        /*"      *               ATENDER A SSI 12.887 DE JANEIRO DE 2007.         *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/01/2007 - FAST COMPUTER            PROCURE POR V.24    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 23 - PASSOU A RECUPERAR LANCAMENTO POR NSAS E NSL     *      */
        /*"      *               PARA EVITAR DIFERENCA NA BAIXA DOS RETORNOS.     *      */
        /*"      *                                                                *      */
        /*"      *   EM 10/10/2006 - FAST COMPUTER            PROCURE POR V.23    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *     ALTERACAO 022                                                     */
        /*"      *              EM 16/07/2004- FREDERICO FONSECA (FF0704)         *      */
        /*"      *                             GERA A FUNDOCOMISVA PARA AS PARCE- *      */
        /*"      *                             LAS BAIXADAS NO PRODUTO CAIXA VIDA *      */
        /*"      *                             EMPRESARIAL (COD_PRODUTO_EMP = 16) *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *     ALTERACAO 021                                                     */
        /*"      *              EM 30/06/2003- MANOEL MESSIAS   (MM0603)          *      */
        /*"      *                               NAO MUDAR A OPCAO DE PAGAMENTO   *      */
        /*"      *                               PARA A APOLICE VIDA DA GENTE     *      */
        /*"      *                               109300000598.                    *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *     ALTERACAO 020                                                     */
        /*"      *              EM 16/01/2003- TERCIO CARVALHO  (TL0301)          *      */
        /*"      *                               ALTERADA A RECUPERACAO DA        *      */
        /*"      *                               PARCELA COM SITUACAO '3' PARA    *      */
        /*"      *                               MINIMIZAR AS FALHAS DE PERDA     *      */
        /*"      *                               DE REGISTRO QUE VEM OCORRENDO.   *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *     ALTERACAO 019                                                     */
        /*"      *              EM 18/07/2002- MESSIAS          (MM0702)          *      */
        /*"      *                               NAO PERMITIR A ATUALIZACAO DA    *      */
        /*"      *                               SITUACAO DA V0PROPOSTAVA QUANDO  *      */
        /*"      *                               FOR EMPRESARIAL OU ESPECIFICA.   *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *     ALTERACAO 018                                                     */
        /*"      *              EM 20/02/2002- CLOVIS           (CL0202)          *      */
        /*"      *                               CADASTRAMENTO AUTOMATICO DA      *      */
        /*"      *                               TARIFA SICOV (0,60 POR DOCTO)    *      */
        /*"      *                               NA TABELA AVISO DE CREDITO.      *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *     ALTERACAO 017                                                     */
        /*"      *              EM 23/11/2001- CLOVIS           (CL1101)          *      */
        /*"      *         1) ALTERACAO DO NUMERO DE AVISO.                       *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *     ALTERACAO 016                                                     */
        /*"      *              EM 06/11/2001-FREDERICO FONSECA (FF1101)          *      */
        /*"      *         1) GERA NA V0HISTCONTABILVA O VALOR DO DEBITO, NAO O   *      */
        /*"      *            VALOR DA V0PARCELVA.                                *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *     ALTERACAO 015                                                     */
        /*"      *              EM 16/02/2001-MANOEL MESSIAS    (MM1602)          *      */
        /*"      *         1) DA DISPLAY DO REGISTRO QUANDO EH DESVIADO PARA UMA  *      */
        /*"      *            NOVA LEITURA (R0020-00-NEXT).                       *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *     ALTERACAO 014                                                     */
        /*"      *              EM 04/12/2000-TERCIO CARVALHO   (TL0012)          *      */
        /*"      *         1) PASSA A NAO MAIS TRATAR OS CODIGOS DE RETORNO 97,   *      */
        /*"      *            98 E 99 QUE SERAO TRATADOS NO VA1813B QUE RODA      *      */
        /*"      *            ANTES DESTE.                                        *      */
        /*"      *                                                                *      */
        /*"      *         2) PASSA A NAO MAIS UTILIZAR A FUNCAO DB2 MIN PARA     *      */
        /*"      *            RECUPERACAO DA PARCELA A SER BAIXADA E SIM          *      */
        /*"      *            MONTAR CURSOR PARA MELHORIA DE PERFORMANCE.         *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *     ALTERACAO 013                                                     */
        /*"      *              EM 08/12/99 - TERCIO CARVALHO   (TL9912)          *      */
        /*"      *         1) TORNA A SITUACAO DA PROPOSTA = '6' CASO A PARCELA   *      */
        /*"      *            TENHA SIDO REJEITADA;                               *      */
        /*"      *                                                                *      */
        /*"      *         2) PASSA A NAO MAIS SUBTRAIR DA V0PROPOSTA.QTDPARATZ   *      */
        /*"      *            QUANDO A SITUACAO DA HISTCOBVA DIFERENTE DE ' ' E 0.*      */
        /*"      *                                                                *      */
        /*"      *         3) ATUALIZA SEMPRE A OPCAOPAG PARA A MAIS ATUAL PARA   *      */
        /*"      *            AS TABELAS PARCELVA E HISTCOBVA.                    *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *     ALTERACAO 012                                                     */
        /*"      *              EM 26/10/99 - TERCIO CARVALHO   (TL9910)          *      */
        /*"      *         QUANDO DA BAIXA DE PARCELA CORRENTE PARA SEGUROS COM   *      */
        /*"      *         SITUACAO '6' - COBERTURA SUSPENSA, PASSA A REGULARIZAR *      */
        /*"      *         A COBRANCA TORNANDO A SITUACAO DA PROPOSTAVA = '3',    *      */
        /*"      *         QTDPARATZ=0 E PRIPARATZ=0;                             *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *     ALTERACAO 011                                                     */
        /*"      *              EM 29/09/99 - FREDERICO FONSECA                   *      */
        /*"      *         PASSA A BAIXAR A PARCELA DE CAPITALIZACAO PARA OS PRO- *      */
        /*"      *         DUTOS DO VIDAZUL.                                      *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *     ALTERACAO 010                                              *      */
        /*"      *              EM 29/09/99 - LUIZ CARLOS       (LC2909)          *      */
        /*"      *         PASSA A GERAR O PREMIO DA V0HISTCONTABILVA, LIQUIDO DE *      */
        /*"      *         SAF, CDG E CAPITALIZACAO.                              *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *     ALTERACAO 009                                              *      */
        /*"      *              EM 09/09/99 - TERCIO CARVALHO   (TL9909)          *      */
        /*"      *         PASSA A TRATAR OS CODIGOS DE RETORNO 97, 98 E 99       *      */
        /*"      *      (ESTORNO DE LANCAMENTO)                                   *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *     ALTERACAO 008                                              *      */
        /*"      *              EM 15/07/99 - TERCIO CARVALHO   (TL9907)          *      */
        /*"      *         PASSA A NAO MAIS TRATAR POR PRODUTO E SIM POR          *      */
        /*"      *      APOLICE E SUBGRUPO.                                       *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *     ALTERACAO 007                                              *      */
        /*"      *              EM 13/05/99 - MANOEL MESSIAS    (MM0599)          *      */
        /*"      *         QUANDO DA MUDANCA DE OPCAO DE PAGAMENTO (V0OPCAOPAGVA),*      */
        /*"      *      ATUALIZAR TAMBEM, A OPCAO DE PAGAMENTO (OPCAOPAG) DAS TA- *      */
        /*"      *      BELAS V0PARCELVA E V0HISTCOBVA.                           *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *     ALTERACAO 006                                              *      */
        /*"      *              EM 03/03/99 - MANOEL MESSIAS    (MM0399)          *      */
        /*"      *         CRIADO SORT INTERNO PARA PRIORIZAR DEBITOS EFETUADOS   *      */
        /*"      *     (CODIGO DE RETORNO 00).                                    *      */
        /*"      *     O ACESSO PRINCIPAL PARA A TABELA V0HISTCONTAVA SERA POR    *      */
        /*"      *     CERTIFICADO.                                               *      */
        /*"      *     QUITAR SEMPRE A MENOR PARCELA EM COBRANCA.                 *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *     ALTERACAO 005                                              *      */
        /*"      *              EM 30/12/98 - TERCIO CARVALHO   (TL9812)          *      */
        /*"      *         ESTAVA FAZENDO ACESSO NA V0HISTCONTAVA COM NSAC IS NULL*      */
        /*"      *         OCORRE QUE A CEF ESTA RECOMANDANDO LANCAMENTOS QUE EM  *      */
        /*"      *         EM PRINCIPIO ESTAVAM COM CODIGO DE RETORNO 02 - CONTA  *      */
        /*"      *         NAO CADASTRADA OU 04 - OUTRAS RESTRICOES COM CODIGO    *      */
        /*"      *         DE RETORNO 00 - DEBITO EFETUADO.                       *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *     ALTERACAO 004                                              *      */
        /*"      *              EM 16/09/98 - CONSEDA 4                           *      */
        /*"      *         RECONVERSAO ANO 2000                                   *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *     ALTERACAO 003                                                     */
        /*"      *              EM 14/09/98 - CLOVIS            (CL0998)          *      */
        /*"      *         INCLUSAO DO AVISO DE CREDITO                           *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *     ALTERACAO 002                                                     */
        /*"      *              EM 08/04/98 - TERCIO CARVALHO   (TL0498)          *      */
        /*"      *         ESTAVA FAZENDO ACESSO NA V0OPCAOPAGVA COM DTTERVIG     *      */
        /*"      *     = 1999-12-31. FOI ALTERADO PARA IN 1999-12-31 E 9999-12-31.*      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *     ALTERACAO 001*                                                    */
        /*"      *              EM 31/03/98 - FREDERICO FONSECA (FF0398)          *      */
        /*"      *         ESTAVA GERANDO O REPASSE DA COBERTURA AUXILIO FUNERAL  *      */
        /*"      *     PARA QUALQUER PRODUTO. OS UNICOS PRODUTOS HOJE QUE POSSUEM *      */
        /*"      *     TAL COBERTURA SAO O PREFERENCIAL VIDA (801) E O PREFEREN-  *      */
        /*"      *     CIAL VIDA PLUS (802).                                      *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *   ALTERACAO ..............  - INCLUSAO CONTROLE DESPESAS CEF   *      */
        /*"      *             CLOVIS       - 17/08/2000     (CL0800)             *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        public FileBasis _RETDEB { get; set; } = new FileBasis(new PIC("X", "150", "X(150)"));

        public FileBasis RETDEB
        {
            get
            {
                _.Move(RETDEB_RECORD, _RETDEB); VarBasis.RedefinePassValue(RETDEB_RECORD, _RETDEB, RETDEB_RECORD); return _RETDEB;
            }
        }
        public FileBasis _RETERR { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis RETERR
        {
            get
            {
                _.Move(RETERR_RECORD, _RETERR); VarBasis.RedefinePassValue(RETERR_RECORD, _RETERR, RETERR_RECORD); return _RETERR;
            }
        }
        public FileBasis _MAUDIT { get; set; } = new FileBasis(new PIC("X", "250", "X(250)"));

        public FileBasis MAUDIT
        {
            get
            {
                _.Move(MAUDIT_RECORD, _MAUDIT); VarBasis.RedefinePassValue(MAUDIT_RECORD, _MAUDIT, MAUDIT_RECORD); return _MAUDIT;
            }
        }
        public SortBasis<VA0813B_SVA_CADASTRAMENTO> SVADEB { get; set; } = new SortBasis<VA0813B_SVA_CADASTRAMENTO>(new VA0813B_SVA_CADASTRAMENTO());
        /*"01         RETDEB-RECORD       PIC X(150).*/
        public StringBasis RETDEB_RECORD { get; set; } = new StringBasis(new PIC("X", "150", "X(150)."), @"");
        /*"01         RET-HEADER.*/
        public VA0813B_RET_HEADER RET_HEADER { get; set; } = new VA0813B_RET_HEADER();
        public class VA0813B_RET_HEADER : VarBasis
        {
            /*"      05   RA-COD-REG          PIC X(001).*/
            public StringBasis RA_COD_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"      05   RA-COD-REMESSA      PIC 9(001).*/
            public IntBasis RA_COD_REMESSA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"      05   RA-COD-CONVENIO     PIC 9(004).*/
            public IntBasis RA_COD_CONVENIO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"      05   FILLER              PIC X(016).*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)."), @"");
            /*"      05   RA-NOME-EMPRESA     PIC X(020).*/
            public StringBasis RA_NOME_EMPRESA { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"      05   RA-COD-BANCO        PIC 9(003).*/
            public IntBasis RA_COD_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"      05   RA-NOME-BANCO       PIC X(020).*/
            public StringBasis RA_NOME_BANCO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"      05   RA-DATA-GERACAO.*/
            public VA0813B_RA_DATA_GERACAO RA_DATA_GERACAO { get; set; } = new VA0813B_RA_DATA_GERACAO();
            public class VA0813B_RA_DATA_GERACAO : VarBasis
            {
                /*"       10  RA-AA-GER           PIC X(004).*/
                public StringBasis RA_AA_GER { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"       10  RA-MM-GER           PIC X(002).*/
                public StringBasis RA_MM_GER { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"       10  RA-DD-GER           PIC X(002).*/
                public StringBasis RA_DD_GER { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"      05   RA-NSA              PIC 9(006).*/
            }
            public IntBasis RA_NSA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"      05   RA-VERSAO-LAYOUT    PIC 9(002).*/
            public IntBasis RA_VERSAO_LAYOUT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"      05   RA-SERVICO          PIC X(017).*/
            public StringBasis RA_SERVICO { get; set; } = new StringBasis(new PIC("X", "17", "X(017)."), @"");
            /*"      05   RA-RESERVADO        PIC X(052).*/
            public StringBasis RA_RESERVADO { get; set; } = new StringBasis(new PIC("X", "52", "X(052)."), @"");
            /*"01         RET-CADASTRAMENTO.*/
        }
        public VA0813B_RET_CADASTRAMENTO RET_CADASTRAMENTO { get; set; } = new VA0813B_RET_CADASTRAMENTO();
        public class VA0813B_RET_CADASTRAMENTO : VarBasis
        {
            /*"    05   RF-COD-REG          PIC X(001).*/
            public StringBasis RF_COD_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05   RF-IDENT-CLI-EMPRESA.*/
            public VA0813B_RF_IDENT_CLI_EMPRESA RF_IDENT_CLI_EMPRESA { get; set; } = new VA0813B_RF_IDENT_CLI_EMPRESA();
            public class VA0813B_RF_IDENT_CLI_EMPRESA : VarBasis
            {
                /*"       10  RF-IDENTIF-CLI      PIC 9(015).*/
                public IntBasis RF_IDENTIF_CLI { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"       10  RF-IDENTIF-CLI-R REDEFINES           RF-IDENTIF-CLI.*/
                private _REDEF_VA0813B_RF_IDENTIF_CLI_R _rf_identif_cli_r { get; set; }
                public _REDEF_VA0813B_RF_IDENTIF_CLI_R RF_IDENTIF_CLI_R
                {
                    get { _rf_identif_cli_r = new _REDEF_VA0813B_RF_IDENTIF_CLI_R(); _.Move(RF_IDENTIF_CLI, _rf_identif_cli_r); VarBasis.RedefinePassValue(RF_IDENTIF_CLI, _rf_identif_cli_r, RF_IDENTIF_CLI); _rf_identif_cli_r.ValueChanged += () => { _.Move(_rf_identif_cli_r, RF_IDENTIF_CLI); }; return _rf_identif_cli_r; }
                    set { VarBasis.RedefinePassValue(value, _rf_identif_cli_r, RF_IDENTIF_CLI); }
                }  //Redefines
                public class _REDEF_VA0813B_RF_IDENTIF_CLI_R : VarBasis
                {
                    /*"           15 FILLER           PIC X(015).*/
                    public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                    /*"       10  RF-IDENTIF-NSA      PIC 9(005).*/

                    public _REDEF_VA0813B_RF_IDENTIF_CLI_R()
                    {
                        FILLER_1.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis RF_IDENTIF_NSA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"       10  FILLER              PIC X(005).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                /*"    05 RF-AGECTADEB            PIC 9(004).*/
            }
            public IntBasis RF_AGECTADEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05 RF-IDENT-CLI-BANCO.*/
            public VA0813B_RF_IDENT_CLI_BANCO RF_IDENT_CLI_BANCO { get; set; } = new VA0813B_RF_IDENT_CLI_BANCO();
            public class VA0813B_RF_IDENT_CLI_BANCO : VarBasis
            {
                /*"       10  RF-COD-OPRCTADEB    PIC 9(004).*/
                public IntBasis RF_COD_OPRCTADEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10  RF-NUM-NUMCTADEB    PIC 9(012).*/
                public IntBasis RF_NUM_NUMCTADEB { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"       10  RF-DIG-NUMCTADEB    PIC 9(001).*/
                public IntBasis RF_DIG_NUMCTADEB { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"       10  FILLER              PIC X(002).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    05 RF-DATA-REAL.*/
            }
            public VA0813B_RF_DATA_REAL RF_DATA_REAL { get; set; } = new VA0813B_RF_DATA_REAL();
            public class VA0813B_RF_DATA_REAL : VarBasis
            {
                /*"       10  RF-ANO-REAL         PIC 9(004).*/
                public IntBasis RF_ANO_REAL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10  RF-MES-REAL         PIC 9(002).*/
                public IntBasis RF_MES_REAL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10  RF-DIA-REAL         PIC 9(002).*/
                public IntBasis RF_DIA_REAL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05 RF-VLPRMTOT             PIC 9(013)V99.*/
            }
            public DoubleBasis RF_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    05 RF-COD-RETORNO          PIC 9(002).*/
            public IntBasis RF_COD_RETORNO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05 RF-USO-EMPRESA.*/
            public VA0813B_RF_USO_EMPRESA RF_USO_EMPRESA { get; set; } = new VA0813B_RF_USO_EMPRESA();
            public class VA0813B_RF_USO_EMPRESA : VarBasis
            {
                /*"       10  RF-NSA              PIC 9(003).*/
                public IntBasis RF_NSA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"       10  RF-NSL              PIC 9(008).*/
                public IntBasis RF_NSL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"       10  FILLER              PIC X(049).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "49", "X(049)."), @"");
                /*"    05 RF-PROC-ADVERT          PIC X(002).*/
            }
            public StringBasis RF_PROC_ADVERT { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"    05 RF-NIVE-ADVERT          PIC X(002).*/
            public StringBasis RF_NIVE_ADVERT { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"    05 RF-MOTI-COMPEN          PIC X(002).*/
            public StringBasis RF_MOTI_COMPEN { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"    05 RF-RESERVADO            PIC X(009).*/
            public StringBasis RF_RESERVADO { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
            /*"    05 RF-COD-MOVIMENTO        PIC 9(001).*/
            public IntBasis RF_COD_MOVIMENTO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"01  RET-TRAILLER.*/
        }
        public VA0813B_RET_TRAILLER RET_TRAILLER { get; set; } = new VA0813B_RET_TRAILLER();
        public class VA0813B_RET_TRAILLER : VarBasis
        {
            /*"    05 RZ-COD-REG              PIC X(001).*/
            public StringBasis RZ_COD_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05 RZ-QTDE-REGISTROS       PIC 9(006).*/
            public IntBasis RZ_QTDE_REGISTROS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05 RZ-TOT-DEB-CRUZ         PIC 9(015)V99.*/
            public DoubleBasis RZ_TOT_DEB_CRUZ { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99."), 2);
            /*"    05 RZ-TOT-CRED-CRUZ        PIC 9(015)V99.*/
            public DoubleBasis RZ_TOT_CRED_CRUZ { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99."), 2);
            /*"    05 RZ-RESERVADO            PIC X(109).*/
            public StringBasis RZ_RESERVADO { get; set; } = new StringBasis(new PIC("X", "109", "X(109)."), @"");
            /*"01  RETERR-RECORD.*/
        }
        public VA0813B_RETERR_RECORD RETERR_RECORD { get; set; } = new VA0813B_RETERR_RECORD();
        public class VA0813B_RETERR_RECORD : VarBasis
        {
            /*"    05 RETERR-REGISTRO   PIC X(150).*/
            public StringBasis RETERR_REGISTRO { get; set; } = new StringBasis(new PIC("X", "150", "X(150)."), @"");
            /*"    05 RETERR-MENSAGEM   PIC X(070).*/
            public StringBasis RETERR_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
            /*"01  SVA-CADASTRAMENTO.*/
        }
        public VA0813B_SVA_CADASTRAMENTO SVA_CADASTRAMENTO { get; set; } = new VA0813B_SVA_CADASTRAMENTO();
        public class VA0813B_SVA_CADASTRAMENTO : VarBasis
        {
            /*"    05 SF-COD-REG        PIC X(001).*/
            public StringBasis SF_COD_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05 SF-IDENT-CLI-EMPRESA.*/
            public VA0813B_SF_IDENT_CLI_EMPRESA SF_IDENT_CLI_EMPRESA { get; set; } = new VA0813B_SF_IDENT_CLI_EMPRESA();
            public class VA0813B_SF_IDENT_CLI_EMPRESA : VarBasis
            {
                /*"       10 SF-IDENTIF-CLI PIC 9(015).*/
                public IntBasis SF_IDENTIF_CLI { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"       10 SF-IDENTIF-CLI-R REDEFINES          SF-IDENTIF-CLI.*/
                private _REDEF_VA0813B_SF_IDENTIF_CLI_R _sf_identif_cli_r { get; set; }
                public _REDEF_VA0813B_SF_IDENTIF_CLI_R SF_IDENTIF_CLI_R
                {
                    get { _sf_identif_cli_r = new _REDEF_VA0813B_SF_IDENTIF_CLI_R(); _.Move(SF_IDENTIF_CLI, _sf_identif_cli_r); VarBasis.RedefinePassValue(SF_IDENTIF_CLI, _sf_identif_cli_r, SF_IDENTIF_CLI); _sf_identif_cli_r.ValueChanged += () => { _.Move(_sf_identif_cli_r, SF_IDENTIF_CLI); }; return _sf_identif_cli_r; }
                    set { VarBasis.RedefinePassValue(value, _sf_identif_cli_r, SF_IDENTIF_CLI); }
                }  //Redefines
                public class _REDEF_VA0813B_SF_IDENTIF_CLI_R : VarBasis
                {
                    /*"          15 FILLER      PIC X(015).*/
                    public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                    /*"       10 SF-IDENTIF-NSA PIC 9(005).*/

                    public _REDEF_VA0813B_SF_IDENTIF_CLI_R()
                    {
                        FILLER_5.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis SF_IDENTIF_NSA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"       10 FILLER         PIC X(005).*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                /*"    05 SF-AGENCIA        PIC 9(004).*/
            }
            public IntBasis SF_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05 SF-IDENT-CLI-BANCO.*/
            public VA0813B_SF_IDENT_CLI_BANCO SF_IDENT_CLI_BANCO { get; set; } = new VA0813B_SF_IDENT_CLI_BANCO();
            public class VA0813B_SF_IDENT_CLI_BANCO : VarBasis
            {
                /*"       10 SF-COD-OPERACAO PIC 9(004).*/
                public IntBasis SF_COD_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10 SF-NUM-CONTA   PIC 9(012).*/
                public IntBasis SF_NUM_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"       10 SF-DIG-CONTA   PIC 9(001).*/
                public IntBasis SF_DIG_CONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"       10 FILLER         PIC X(002).*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    05 SF-DATA-REAL.*/
            }
            public VA0813B_SF_DATA_REAL SF_DATA_REAL { get; set; } = new VA0813B_SF_DATA_REAL();
            public class VA0813B_SF_DATA_REAL : VarBasis
            {
                /*"       10 SF-ANO-REAL    PIC 9(004).*/
                public IntBasis SF_ANO_REAL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10 SF-MES-REAL    PIC 9(002).*/
                public IntBasis SF_MES_REAL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 SF-DIA-REAL    PIC 9(002).*/
                public IntBasis SF_DIA_REAL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05 SF-VALOR          PIC 9(013)V99.*/
            }
            public DoubleBasis SF_VALOR { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    05 SF-COD-RETORNO    PIC 9(002).*/
            public IntBasis SF_COD_RETORNO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05 SF-USO-EMPRESA.*/
            public VA0813B_SF_USO_EMPRESA SF_USO_EMPRESA { get; set; } = new VA0813B_SF_USO_EMPRESA();
            public class VA0813B_SF_USO_EMPRESA : VarBasis
            {
                /*"       10 SF-NSA         PIC 9(003).*/
                public IntBasis SF_NSA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"       10 SF-NSL         PIC 9(008).*/
                public IntBasis SF_NSL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"       10 FILLER         PIC X(047).*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "47", "X(047)."), @"");
                /*"    05 SF-RESERVADO      PIC X(017).*/
            }
            public StringBasis SF_RESERVADO { get; set; } = new StringBasis(new PIC("X", "17", "X(017)."), @"");
            /*"    05 SF-COD-MOVIMENTO  PIC 9(001).*/
            public IntBasis SF_COD_MOVIMENTO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"01         MAUDIT-RECORD       PIC X(250).*/
        }
        public StringBasis MAUDIT_RECORD { get; set; } = new StringBasis(new PIC("X", "250", "X(250)."), @"");
        /*"01         MAUDIT-REC.*/
        public VA0813B_MAUDIT_REC MAUDIT_REC { get; set; } = new VA0813B_MAUDIT_REC();
        public class VA0813B_MAUDIT_REC : VarBasis
        {
            /*"    05     MA-NUM-CERTIFICADO  PIC 9(015).*/
            public IntBasis MA_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05     MA-FILLER01         PIC X(001).*/
            public StringBasis MA_FILLER01 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05     MA-NUM-PARCELA      PIC 9(004).*/
            public IntBasis MA_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05     MA-FILLER02         PIC X(001).*/
            public StringBasis MA_FILLER02 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05     MA-DATA-VENCIMENTO  PIC X(010).*/
            public StringBasis MA_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05     MA-FILLER03         PIC X(001).*/
            public StringBasis MA_FILLER03 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05     MA-DATA-MOVIMENTO   PIC X(010).*/
            public StringBasis MA_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05     MA-FILLER04         PIC X(001).*/
            public StringBasis MA_FILLER04 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05     MA-DATA-BAIXA       PIC X(010).*/
            public StringBasis MA_DATA_BAIXA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05     MA-FILLER05         PIC X(001).*/
            public StringBasis MA_FILLER05 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05     MA-DATA-NASCIMENTO  PIC X(010).*/
            public StringBasis MA_DATA_NASCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05     MA-FILLER06         PIC X(001).*/
            public StringBasis MA_FILLER06 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05     MA-CGCCPF           PIC 9(015).*/
            public IntBasis MA_CGCCPF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05     MA-FILLER07         PIC X(001).*/
            public StringBasis MA_FILLER07 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05     MA-VLR-ESPERADO     PIC 9(013)V99.*/
            public DoubleBasis MA_VLR_ESPERADO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    05     MA-FILLER08         PIC X(001).*/
            public StringBasis MA_FILLER08 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05     MA-VLR-RECEBIDO     PIC 9(013)V99.*/
            public DoubleBasis MA_VLR_RECEBIDO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    05     MA-FILLER09         PIC X(001).*/
            public StringBasis MA_FILLER09 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05     MA-VLR-BAIXADO      PIC 9(013)V99.*/
            public DoubleBasis MA_VLR_BAIXADO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    05     MA-FILLER10         PIC X(001).*/
            public StringBasis MA_FILLER10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05     MA-TXT-DES-OPERACAO PIC X(020).*/
            public StringBasis MA_TXT_DES_OPERACAO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"    05     MA-FILLER11         PIC X(001).*/
            public StringBasis MA_FILLER11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05     MA-NUM-TITULO       PIC 9(015).*/
            public IntBasis MA_NUM_TITULO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05     MA-FILLER12         PIC X(001).*/
            public StringBasis MA_FILLER12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05     MA-OPCAO-PAG        PIC X(015).*/
            public StringBasis MA_OPCAO_PAG { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
            /*"    05     MA-FILLER13         PIC X(001).*/
            public StringBasis MA_FILLER13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05     MA-OPCAO-PAG-ORIG   PIC X(015).*/
            public StringBasis MA_OPCAO_PAG_ORIG { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
            /*"    05     MA-FILLER14         PIC X(001).*/
            public StringBasis MA_FILLER14 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05     MA-PONTO-DE-VENDA   PIC 9(004).*/
            public IntBasis MA_PONTO_DE_VENDA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05     MA-FILLER15         PIC X(001).*/
            public StringBasis MA_FILLER15 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05     MA-FILIAL           PIC 9(004).*/
            public IntBasis MA_FILIAL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05     MA-FILLER16         PIC X(001).*/
            public StringBasis MA_FILLER16 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05     MA-PRODUTO          PIC 9(004).*/
            public IntBasis MA_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05     MA-FILLER17         PIC X(001).*/
            public StringBasis MA_FILLER17 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05     MA-CONVENIO         PIC 9(004).*/
            public IntBasis MA_CONVENIO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05     MA-FILLER18         PIC X(001).*/
            public StringBasis MA_FILLER18 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05     MA-SIT-REGISTRO     PIC X(001).*/
            public StringBasis MA_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05     MA-FILLER19         PIC X(001).*/
            public StringBasis MA_FILLER19 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05     MA-NSAS             PIC 9(005).*/
            public IntBasis MA_NSAS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"    05     MA-FILLER20         PIC X(001).*/
            public StringBasis MA_FILLER20 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05     MA-NSR              PIC 9(008).*/
            public IntBasis MA_NSR { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05     FILLER              PIC X(016).*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis SORT_FILE_SIZE { get; set; } = new IntBasis(new PIC("S9", "08", "S9(08)"));
        /*"*/
        public IntBasis WS_PRD { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis WS_TIP { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis WS_SIT { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"01    V0COMI-NUMAPOL            PIC S9(013)    COMP-3.*/
        public IntBasis V0COMI_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01    V0COMI-NRENDOS            PIC S9(009)    COMP.*/
        public IntBasis V0COMI_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01    V0COMI-NRCERTIF           PIC S9(015)    COMP-3.*/
        public IntBasis V0COMI_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01    V0COMI-DIGCERT            PIC  X(001).*/
        public StringBasis V0COMI_DIGCERT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01    V0COMI-IDTPSEGU           PIC  X(001).*/
        public StringBasis V0COMI_IDTPSEGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01    V0COMI-NRPARCEL           PIC S9(004)    COMP.*/
        public IntBasis V0COMI_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01    V0COMI-OPERACAO           PIC S9(004)    COMP.*/
        public IntBasis V0COMI_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01    V0COMI-CODPDT             PIC S9(009)    COMP.*/
        public IntBasis V0COMI_CODPDT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01    V0COMI-RAMOFR             PIC S9(004)    COMP.*/
        public IntBasis V0COMI_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01    V0COMI-MODALIFR           PIC S9(004)    COMP.*/
        public IntBasis V0COMI_MODALIFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01    V0COMI-OCORHIST           PIC S9(004)    COMP.*/
        public IntBasis V0COMI_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01    V0COMI-FONTE              PIC S9(004)    COMP.*/
        public IntBasis V0COMI_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01    V0COMI-CODCLIEN           PIC S9(009)    COMP.*/
        public IntBasis V0COMI_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01    V0COMI-VLCOMIS            PIC S9(013)V99 COMP-3.*/
        public DoubleBasis V0COMI_VLCOMIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01    V0COMI-DATCLO             PIC  X(010).*/
        public StringBasis V0COMI_DATCLO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01    V0COMI-NUMREC             PIC S9(009)    COMP.*/
        public IntBasis V0COMI_NUMREC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01    V0COMI-VALBAS             PIC S9(013)V99 COMP-3.*/
        public DoubleBasis V0COMI_VALBAS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01    V0COMI-TIPCOM             PIC  X(001).*/
        public StringBasis V0COMI_TIPCOM { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01    V0COMI-QTPARCEL           PIC S9(004)    COMP.*/
        public IntBasis V0COMI_QTPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01    V0COMI-PCCOMCOR           PIC S9(003)V99 COMP-3.*/
        public DoubleBasis V0COMI_PCCOMCOR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"01    V0COMI-PCDESCON           PIC S9(003)V99 COMP-3.*/
        public DoubleBasis V0COMI_PCDESCON { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"01    V0COMI-CODSUBES           PIC S9(004)    COMP.*/
        public IntBasis V0COMI_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01    V0COMI-HORAOPER           PIC  X(008).*/
        public StringBasis V0COMI_HORAOPER { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"01    V0COMI-DTMOVTO            PIC  X(010).*/
        public StringBasis V0COMI_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01    V0COMI-DATSEL             PIC  X(010).*/
        public StringBasis V0COMI_DATSEL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01    V0COMI-CODEMP             PIC S9(009)    COMP.*/
        public IntBasis V0COMI_CODEMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01    V0COMI-CODPRP             PIC S9(009)    COMP.*/
        public IntBasis V0COMI_CODPRP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01    V0COMI-NUMBIL             PIC S9(015)    COMP-3.*/
        public IntBasis V0COMI_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01    V0COMI-VLVARMON           PIC S9(013)V99 COMP-3.*/
        public DoubleBasis V0COMI_VLVARMON { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01    V0COMI-DTQITBCO           PIC  X(010).*/
        public StringBasis V0COMI_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01    V0COMI-COUNT              PIC S9(004)    COMP.*/
        public IntBasis V0COMI_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-DATSEL                      PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_DATSEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-CODPRP                      PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_CODPRP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-NUMBIL                      PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-VLVARMON                    PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_VLVARMON { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-DTQITBCO                    PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_DTQITBCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-RISCO                       PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_RISCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-TEM-SAF                     PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_TEM_SAF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-TEM-CDG                     PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_TEM_CDG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-DTMOVTO                     PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_DTMOVTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  WHOST-SITUACAO                   PIC  X(01).*/
        public StringBasis WHOST_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  WHOST-NRCERTIF                   PIC S9(15)  COMP-3 VALUE +0*/
        public IntBasis WHOST_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  WHOST-GRUPO-SUSEP                PIC S9(004)      COMP.*/
        public IntBasis WHOST_GRUPO_SUSEP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-COD-RAMO                   PIC S9(004)      COMP.*/
        public IntBasis WHOST_COD_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-PREMIO-CONJ                PIC S9(013)V99   COMP-3.*/
        public DoubleBasis WHOST_PREMIO_CONJ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  WHOST-TAXA-RAMO                  PIC S9(003)V9(4) COMP-3.*/
        public DoubleBasis WHOST_TAXA_RAMO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"01  WHOST-PERC-CDG                   PIC S9(003)V9(4) COMP-3.*/
        public DoubleBasis WHOST_PERC_CDG { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"01  WHOST-PERC-DIT                   PIC S9(003)V9(4) COMP-3.*/
        public DoubleBasis WHOST_PERC_DIT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"01  WHOST-OPCAO-COBER                PIC  X(001).*/
        public StringBasis WHOST_OPCAO_COBER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  WHOST-DTVENCTO                   PIC  X(010).*/
        public StringBasis WHOST_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WHOST-DTVENCTO1                  PIC  X(010).*/
        public StringBasis WHOST_DTVENCTO1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WHOST-ANO-VENC                   PIC S9(004) COMP.*/
        public IntBasis WHOST_ANO_VENC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-ANO-NASC                   PIC S9(004) COMP.*/
        public IntBasis WHOST_ANO_NASC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-IDADE                      PIC S9(004) COMP.*/
        public IntBasis WHOST_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-PERCENT                    PIC S9(003)V9(4) COMP-3.*/
        public DoubleBasis WHOST_PERCENT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"01  WHOST-IMPSEG                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis WHOST_IMPSEG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  WHOST-ORIGEM-PROPOSTA            PIC S9(4)     COMP.*/
        public IntBasis WHOST_ORIGEM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  WHOST-AGECTADEB-FID              PIC S9(4)     COMP.*/
        public IntBasis WHOST_AGECTADEB_FID { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  WHOST-OPRCTADEB-FID              PIC S9(4)     COMP.*/
        public IntBasis WHOST_OPRCTADEB_FID { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  WHOST-NUMCTADEB-FID              PIC S9(13)    COMP-3.*/
        public IntBasis WHOST_NUMCTADEB_FID { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  WHOST-DIGCTADEB-FID              PIC S9(4)     COMP.*/
        public IntBasis WHOST_DIGCTADEB_FID { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  V0SIST-DTMOVABE                  PIC X(10).*/
        public StringBasis V0SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0SIST-DTMOVABE-1                PIC X(10).*/
        public StringBasis V0SIST_DTMOVABE_1 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0SIST-DTMOVABE-A1               PIC X(10).*/
        public StringBasis V0SIST_DTMOVABE_A1 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0FITA-DATA-GERACAO              PIC X(10).*/
        public StringBasis V0FITA_DATA_GERACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0SIST-DTCURR                    PIC X(10).*/
        public StringBasis V0SIST_DTCURR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  VIND-DTNASC                      PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_DTNASC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*" 01  WHOST-RF-NSL                     PIC 9(009).*/
        public IntBasis WHOST_RF_NSL { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
        /*" 01  WHOST-NOVO-NRTIT                 PIC S9(13)    COMP-3.*/
        public IntBasis WHOST_NOVO_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  W-NUMR-TITULO                    PIC  9(013)   VALUE ZEROS.*/
        public IntBasis W_NUMR_TITULO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
        /*"01  FILLER                           REDEFINES    W-NUMR-TITULO.*/
        private _REDEF_VA0813B_FILLER_10 _filler_10 { get; set; }
        public _REDEF_VA0813B_FILLER_10 FILLER_10
        {
            get { _filler_10 = new _REDEF_VA0813B_FILLER_10(); _.Move(W_NUMR_TITULO, _filler_10); VarBasis.RedefinePassValue(W_NUMR_TITULO, _filler_10, W_NUMR_TITULO); _filler_10.ValueChanged += () => { _.Move(_filler_10, W_NUMR_TITULO); }; return _filler_10; }
            set { VarBasis.RedefinePassValue(value, _filler_10, W_NUMR_TITULO); }
        }  //Redefines
        public class _REDEF_VA0813B_FILLER_10 : VarBasis
        {
            /*"  05    WTITL-ZEROS                  PIC  9(002).*/
            public IntBasis WTITL_ZEROS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05    WTITL-SEQUENCIA              PIC  9(010).*/
            public IntBasis WTITL_SEQUENCIA { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"  05    WTITL-DIGITO                 PIC  9(001).*/
            public IntBasis WTITL_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"01  DPARM01X.*/

            public _REDEF_VA0813B_FILLER_10()
            {
                WTITL_ZEROS.ValueChanged += OnValueChanged;
                WTITL_SEQUENCIA.ValueChanged += OnValueChanged;
                WTITL_DIGITO.ValueChanged += OnValueChanged;
            }

        }
        public VA0813B_DPARM01X DPARM01X { get; set; } = new VA0813B_DPARM01X();
        public class VA0813B_DPARM01X : VarBasis
        {
            /*"  05  DPARM01                        PIC  9(010).*/
            public IntBasis DPARM01 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"  05  DPARM01-R                      REDEFINES   DPARM01.*/
            private _REDEF_VA0813B_DPARM01_R _dparm01_r { get; set; }
            public _REDEF_VA0813B_DPARM01_R DPARM01_R
            {
                get { _dparm01_r = new _REDEF_VA0813B_DPARM01_R(); _.Move(DPARM01, _dparm01_r); VarBasis.RedefinePassValue(DPARM01, _dparm01_r, DPARM01); _dparm01_r.ValueChanged += () => { _.Move(_dparm01_r, DPARM01); }; return _dparm01_r; }
                set { VarBasis.RedefinePassValue(value, _dparm01_r, DPARM01); }
            }  //Redefines
            public class _REDEF_VA0813B_DPARM01_R : VarBasis
            {
                /*"    10  DPARM01-1                    PIC  9(001).*/
                public IntBasis DPARM01_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10  DPARM01-2                    PIC  9(001).*/
                public IntBasis DPARM01_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10  DPARM01-3                    PIC  9(001).*/
                public IntBasis DPARM01_3 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10  DPARM01-4                    PIC  9(001).*/
                public IntBasis DPARM01_4 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10  DPARM01-5                    PIC  9(001).*/
                public IntBasis DPARM01_5 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10  DPARM01-6                    PIC  9(001).*/
                public IntBasis DPARM01_6 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10  DPARM01-7                    PIC  9(001).*/
                public IntBasis DPARM01_7 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10  DPARM01-8                    PIC  9(001).*/
                public IntBasis DPARM01_8 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10  DPARM01-9                    PIC  9(001).*/
                public IntBasis DPARM01_9 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10  DPARM01-10                   PIC  9(001).*/
                public IntBasis DPARM01_10 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  05  DPARM01-D1                     PIC  9(001).*/

                public _REDEF_VA0813B_DPARM01_R()
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
            /*"  05  DPARM01-RC                     PIC S9(004) COMP VALUE +0.*/
            public IntBasis DPARM01_RC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01  V0FTCF-DTRET                     PIC X(10).*/
        }
        public StringBasis V0FTCF_DTRET { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0FTCF-DTRET2                    PIC X(10).*/
        public StringBasis V0FTCF_DTRET2 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0FTCF-NSAC                      PIC S9(04)    COMP.*/
        public IntBasis V0FTCF_NSAC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0FTCF-NSAC1                     PIC S9(04)    COMP.*/
        public IntBasis V0FTCF_NSAC1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0FTCF-QTLANCDB                  PIC S9(09)    COMP.*/
        public IntBasis V0FTCF_QTLANCDB { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  V0FTCF-QTREG                     PIC S9(09)    COMP.*/
        public IntBasis V0FTCF_QTREG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  V0FTCF-QTDBEFET                  PIC S9(09)    COMP.*/
        public IntBasis V0FTCF_QTDBEFET { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  V0FTCF-TOTDBEFET                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0FTCF_TOTDBEFET { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0FTCF-TOTDBNEFET                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0FTCF_TOTDBNEFET { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0FTCF-VERSAO                    PIC S9(04)    COMP.*/
        public IntBasis V0FTCF_VERSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0FUND-VLCOMISVG                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0FUND_VLCOMISVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0FUND-VLCOMISAP                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0FUND_VLCOMISAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0HCTVA-PRMVG                    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0HCTVA_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0HCTVA-PRMAP                    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0HCTVA_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0HCTVA-VLCOBADIC                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0HCTVA_VLCOBADIC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0CAPI-NRPARCEL                  PIC S9(04)    COMP.*/
        public IntBasis V0CAPI_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0PRVG-RISCO                     PIC  X(01).*/
        public StringBasis V0PRVG_RISCO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0PRVG-TEM-SAF                   PIC  X(01).*/
        public StringBasis V0PRVG_TEM_SAF { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0PRVG-TEM-CDG                   PIC  X(01).*/
        public StringBasis V0PRVG_TEM_CDG { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0PRVG-ORIG-PRODU                PIC  X(10).*/
        public StringBasis V0PRVG_ORIG_PRODU { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0PRVG-CUSTOCAP-TOTAL            PIC  X(01).*/
        public StringBasis V0PRVG_CUSTOCAP_TOTAL { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0PRVG-OPCAOPAG                  PIC  X(01).*/
        public StringBasis V0PRVG_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0PRVG-RAMO                      PIC S9(004)   COMP.*/
        public IntBasis V0PRVG_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  V0HCTA-AGECTADEB                 PIC S9(04)    COMP.*/
        public IntBasis V0HCTA_AGECTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0HCTA-CODRET                    PIC S9(04)    COMP.*/
        public IntBasis V0HCTA_CODRET { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0HCTA-DIGCTADEB                 PIC S9(04)    COMP.*/
        public IntBasis V0HCTA_DIGCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0HCTA-NUMCTADEB                 PIC S9(13)    COMP-3.*/
        public IntBasis V0HCTA_NUMCTADEB { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  V0HCTA-NRCERTIF                  PIC S9(15)    COMP-3.*/
        public IntBasis V0HCTA_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  V0HCTA-NRPARCEL                  PIC S9(04)    COMP.*/
        public IntBasis V0HCTA_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0HCTA-NSAS                      PIC S9(04)    COMP.*/
        public IntBasis V0HCTA_NSAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  WHOST-NSAS                       PIC S9(04)    COMP.*/
        public IntBasis WHOST_NSAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0HCTA-NSL                       PIC S9(09)    COMP.*/
        public IntBasis V0HCTA_NSL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  V0HCTA-OPCAOPAG                  PIC  X(01).*/
        public StringBasis V0HCTA_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0HCTA-OPRCTADEB                 PIC S9(04)    COMP.*/
        public IntBasis V0HCTA_OPRCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0HCTA-OCORHISTCTA               PIC S9(04)    COMP.*/
        public IntBasis V0HCTA_OCORHISTCTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0HCTA-SITUACAO                  PIC  X(01).*/
        public StringBasis V0HCTA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0HCTA-VLPRMTOT                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0HCTA_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0HCTA-OCORHISTCOB               PIC S9(04)    COMP.*/
        public IntBasis V0HCTA_OCORHISTCOB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0HCTA-CODCONV                   PIC S9(04)    COMP.*/
        public IntBasis V0HCTA_CODCONV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0HCTB-CODOPER                   PIC S9(04)    COMP.*/
        public IntBasis V0HCTB_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0PARC-DTVENCTO                  PIC  X(10).*/
        public StringBasis V0PARC_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0PARC-OPCAOPAG                  PIC  X(01).*/
        public StringBasis V0PARC_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0PARC-PRMAP                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0PARC_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0PARC-PRMVG                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0PARC_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0PARC-PRMTOT                    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0PARC_PRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0PARC-PRMTOTVG                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0PARC_PRMTOTVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0RCDG-DTREFER                   PIC  X(10).*/
        public StringBasis V0RCDG_DTREFER { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0RCDG-SITUACAO                  PIC  X(01).*/
        public StringBasis V0RCDG_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0RSAF-DTREFER                   PIC  X(10).*/
        public StringBasis V0RSAF_DTREFER { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0RSAF-SITUACAO                  PIC  X(01).*/
        public StringBasis V0RSAF_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0PROP-CODCLIEN                  PIC S9(09)    COMP.*/
        public IntBasis V0PROP_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  V0PROP-DTVENCTO                  PIC  X(10).*/
        public StringBasis V0PROP_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0PROP-OCORHIST                  PIC S9(04)    COMP.*/
        public IntBasis V0PROP_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0PROP-CODSUBES                  PIC S9(04)    COMP.*/
        public IntBasis V0PROP_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0PROP-CODPRODU                  PIC S9(04)    COMP.*/
        public IntBasis V0PROP_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0PROP-FONTE                     PIC S9(04)    COMP.*/
        public IntBasis V0PROP_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0PROP-DTQITBCO                  PIC  X(10).*/
        public StringBasis V0PROP_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0PROP-AGECOBR                   PIC S9(04)    COMP.*/
        public IntBasis V0PROP_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0PROP-OPCAO-COBER               PIC  X(01).*/
        public StringBasis V0PROP_OPCAO_COBER { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0PROP-NRPARCE                   PIC S9(04)    COMP.*/
        public IntBasis V0PROP_NRPARCE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0PROP-NUM-APOLICE               PIC S9(13)    COMP-3.*/
        public IntBasis V0PROP_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  V0PROP-NRMATRFUN                 PIC S9(15)    COMP-3.*/
        public IntBasis V0PROP_NRMATRFUN { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  V0PROP-INRMATRFUN                PIC S9(04)    COMP.*/
        public IntBasis V0PROP_INRMATRFUN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0PROP-QTDPARATZ                 PIC S9(04)    COMP.*/
        public IntBasis V0PROP_QTDPARATZ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0PROP-SITUACAO                  PIC  X(01).*/
        public StringBasis V0PROP_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0APOL-MODALIDA                  PIC S9(004)   VALUE +0 COMP*/
        public IntBasis V0APOL_MODALIDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  V0COBP-VLPREMIO                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBP_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0COBP-PRMVG                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBP_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0COBP-PRMAP                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBP_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0COBP-PRMDIT                    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBP_PRMDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0COBP-VLCUSTCDG                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBP_VLCUSTCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0COBP-VLCUSTAUXF                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBP_VLCUSTAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0COBP-IMPSEGCDG                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBP_IMPSEGCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0COBP-IMPSEGAUXF                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBP_IMPSEGAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0COBP-VLCUSTAUXF-I              PIC S9(04)    COMP.*/
        public IntBasis V0COBP_VLCUSTAUXF_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0COBP-IMPSEGAUXF-I              PIC S9(04)    COMP.*/
        public IntBasis V0COBP_IMPSEGAUXF_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0COBP-VLCUSTCAP                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBP_VLCUSTCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0COBP-QTTITCAP                  PIC S9(04)    COMP.*/
        public IntBasis V0COBP_QTTITCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0COBP-IMPMORNATU                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBP_IMPMORNATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0COBP-IMPMORACID                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBP_IMPMORACID { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0COBP-IMPDIT                    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBP_IMPDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0COBP-QUANT-VIDAS               PIC S9(09)    COMP.*/
        public IntBasis V0COBP_QUANT_VIDAS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  V0COBP-IMPINVPERM                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBP_IMPINVPERM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0COBP-IMPDH                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBP_IMPDH { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0CDGC-VLCUSTCDG                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0CDGC_VLCUSTCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0SAFC-VLCUSTSAF                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0SAFC_VLCUSTSAF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0HCOB-DTALTOPC                  PIC  X(10).*/
        public StringBasis V0HCOB_DTALTOPC { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0HCOB-DTVENCTO                  PIC  X(10).*/
        public StringBasis V0HCOB_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0HCOB-NRTIT                     PIC S9(13)    COMP-3.*/
        public IntBasis V0HCOB_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  V0HCOB-OCORHIST                  PIC S9(04)    COMP.*/
        public IntBasis V0HCOB_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0HCOB-SITUACAO                  PIC  X(01).*/
        public StringBasis V0HCOB_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0HCOB-VLPRMTOT                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0HCOB_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0HCOB-OPCAOPAG                  PIC  X(01).*/
        public StringBasis V0HCOB_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0OPCP-DIADEB                    PIC S9(04)    COMP.*/
        public IntBasis V0OPCP_DIADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0OPCP-OPCAOPAG                  PIC  X(01).*/
        public StringBasis V0OPCP_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0OPCP-PERIPGTO                  PIC S9(04)    COMP.*/
        public IntBasis V0OPCP_PERIPGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0OPCP-DTINIVIG                  PIC  X(10).*/
        public StringBasis V0OPCP_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0OPCP-AGECTADEB                 PIC S9(4)     COMP.*/
        public IntBasis V0OPCP_AGECTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  V0OPCP-OPRCTADEB                 PIC S9(4)     COMP.*/
        public IntBasis V0OPCP_OPRCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  V0OPCP-NUMCTADEB                 PIC S9(13)    COMP-3.*/
        public IntBasis V0OPCP_NUMCTADEB { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  V0OPCP-DIGCTADEB                 PIC S9(4)     COMP.*/
        public IntBasis V0OPCP_DIGCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-AGECTADEB                   PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_AGECTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-OPRCTADEB                   PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_OPRCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-NUMCTADEB                   PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_NUMCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-DIGCTADEB                   PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_DIGCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0DIFP-CODOPER                   PIC S9(04)    COMP.*/
        public IntBasis V0DIFP_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0DIFP-NRPARCEL                  PIC S9(04)    COMP.*/
        public IntBasis V0DIFP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0DIFP-PRMDEVVG                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0DIFP_PRMDEVVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0DIFP-PRMDEVAP                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0DIFP_PRMDEVAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0DIFP-PRMPAGVG                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0DIFP_PRMPAGVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0DIFP-PRMPAGAP                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0DIFP_PRMPAGAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0DIFP-PRMDIFVG                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0DIFP_PRMDIFVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0DIFP-PRMDIFAP                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0DIFP_PRMDIFAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0AVIS-BCOAVISO                  PIC S9(04)    COMP VALUE +0*/
        public IntBasis V0AVIS_BCOAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0AVIS-AGEAVISO                  PIC S9(04)    COMP VALUE +0*/
        public IntBasis V0AVIS_AGEAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0AVIS-NRAVISO                   PIC S9(09)    COMP VALUE +0*/
        public IntBasis V0AVIS_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  V0AVIS-NRSEQ                     PIC S9(04)    COMP.*/
        public IntBasis V0AVIS_NRSEQ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0AVIS-DTMOVTO                   PIC X(10).*/
        public StringBasis V0AVIS_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0AVIS-OPERACAO                  PIC S9(04)    COMP.*/
        public IntBasis V0AVIS_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0AVIS-TIPAVI                    PIC X(01).*/
        public StringBasis V0AVIS_TIPAVI { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0AVIS-DTAVISO                   PIC X(10).*/
        public StringBasis V0AVIS_DTAVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0AVIS-VLIOCC                    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0AVIS_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0AVIS-VLDESPES                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0AVIS_VLDESPES { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0AVIS-PRECED                    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0AVIS_PRECED { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0AVIS-VLPRMLIQ                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0AVIS_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0AVIS-VLPRMTOT                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0AVIS_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0AVIS-SITCONTB                  PIC X(01).*/
        public StringBasis V0AVIS_SITCONTB { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0AVIS-CODEMP                    PIC S9(09)    COMP.*/
        public IntBasis V0AVIS_CODEMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  V0AVIS-ORIGAVISO                 PIC S9(04)    COMP.*/
        public IntBasis V0AVIS_ORIGAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0AVIS-VALADT                    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0AVIS_VALADT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0AVIS-SITDEPTER                 PIC  X(01).*/
        public StringBasis V0AVIS_SITDEPTER { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  VIND-CODEMP                      PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_CODEMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-ORIGAVISO                   PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_ORIGAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-VALADT                      PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_VALADT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0SALD-CODEMP                    PIC S9(09)    COMP.*/
        public IntBasis V0SALD_CODEMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  V0SALD-BCOAVISO                  PIC S9(04)    COMP.*/
        public IntBasis V0SALD_BCOAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0SALD-AGEAVISO                  PIC S9(04)    COMP.*/
        public IntBasis V0SALD_AGEAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0SALD-TIPSGU                    PIC X(01).*/
        public StringBasis V0SALD_TIPSGU { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0SALD-NRAVISO                   PIC S9(09)    COMP.*/
        public IntBasis V0SALD_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  V0SALD-DTAVISO                   PIC X(10).*/
        public StringBasis V0SALD_DTAVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0SALD-DTMOVTO                   PIC X(10).*/
        public StringBasis V0SALD_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0SALD-SDOATU                    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0SALD_SDOATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0SALD-SITUACAO                  PIC X(01).*/
        public StringBasis V0SALD_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0BANC-NRTIT                     PIC S9(013) VALUE +0 COMP-3*/
        public IntBasis V0BANC_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01    WSHOST-CODPRODU           PIC S9(004)    COMP.*/
        public IntBasis WSHOST_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01    WSHOST-VLPRMTOT           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis WSHOST_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01    WS-QUOCIENTE              PIC S9(007)     COMP-3.*/
        public IntBasis WS_QUOCIENTE { get; set; } = new IntBasis(new PIC("S9", "7", "S9(007)"));
        /*"01    WS-RESTO                  PIC S9(007)     COMP-3.*/
        public IntBasis WS_RESTO { get; set; } = new IntBasis(new PIC("S9", "7", "S9(007)"));
        /*"01    WS-VLPRMTOT               PIC S9(013)V99  COMP-3.*/
        public DoubleBasis WS_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01    WSHOST-VLTARIFA           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis WSHOST_VLTARIFA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01    WSHOST-VLBALCAO           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis WSHOST_VLBALCAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01    WSHOST-VLIOCC             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis WSHOST_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01    WSHOST-VLDESCON           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis WSHOST_VLDESCON { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01    WSHOST-SITUACAO           PIC  X(001).*/
        public StringBasis WSHOST_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01    WHOST-CODCONV             PIC S9(09)      COMP.*/
        public IntBasis WHOST_CODCONV { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01    WS-PREMIO-TOTAL           PIC S9(13)V99 COMP-3  VALUE ZERO*/
        public DoubleBasis WS_PREMIO_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01    WS-PREMIO-TOTAL-AC        PIC S9(13)V99 COMP-3  VALUE ZERO*/
        public DoubleBasis WS_PREMIO_TOTAL_AC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01    WS-IMP-SEGURADA           PIC S9(13)V99 COMP-3  VALUE ZERO*/
        public DoubleBasis WS_IMP_SEGURADA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01    WHOST-CODSUBES            PIC S9(04)      COMP.*/
        public IntBasis WHOST_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01    WS-PREMIO-TOTAL-DIT       PIC S9(13)V99 COMP-3  VALUE ZERO*/
        public DoubleBasis WS_PREMIO_TOTAL_DIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01    WHOST-VLR-FIXO-DIT        PIC S9(004)V9(02) COMP-3.*/
        public DoubleBasis WHOST_VLR_FIXO_DIT { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(02)"), 2);
        /*"01    V0PROD-CODPRODU           PIC S9(004)    VALUE +0   COMP.*/
        public IntBasis V0PROD_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01    V0DPCF-CODEMP             PIC S9(009)     COMP.*/
        public IntBasis V0DPCF_CODEMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01    V0DPCF-ANOREF             PIC S9(004)     COMP.*/
        public IntBasis V0DPCF_ANOREF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01    V0DPCF-MESREF             PIC S9(004)     COMP.*/
        public IntBasis V0DPCF_MESREF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01    V0DPCF-BCOAVISO           PIC S9(004)     COMP.*/
        public IntBasis V0DPCF_BCOAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01    V0DPCF-AGEAVISO           PIC S9(004)     COMP.*/
        public IntBasis V0DPCF_AGEAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01    V0DPCF-NRAVISO            PIC S9(009)     COMP.*/
        public IntBasis V0DPCF_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01    V0DPCF-CODPRODU           PIC S9(004)     COMP.*/
        public IntBasis V0DPCF_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01    V0DPCF-TIPOREG            PIC  X(001).*/
        public StringBasis V0DPCF_TIPOREG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01    V0DPCF-SITUACAO           PIC  X(001).*/
        public StringBasis V0DPCF_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01    V0DPCF-TIPOCOB            PIC  X(001).*/
        public StringBasis V0DPCF_TIPOCOB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01    V0DPCF-DTMOVTO            PIC  X(010).*/
        public StringBasis V0DPCF_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01    V0DPCF-DTAVISO            PIC  X(010).*/
        public StringBasis V0DPCF_DTAVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01    V0DPCF-QTDREG             PIC S9(009)     COMP.*/
        public IntBasis V0DPCF_QTDREG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01    V0DPCF-VLPRMTOT           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01    V0DPCF-VLPRMLIQ           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01    V0DPCF-VLTARIFA           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLTARIFA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01    V0DPCF-VLBALCAO           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLBALCAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01    V0DPCF-VLIOCC             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01    V0DPCF-VLDESCON           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLDESCON { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01    V0DPCF-VLJUROS            PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLJUROS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01    V0DPCF-VLMULTA            PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLMULTA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01    WAUX-FLAG                 PIC X(001) VALUE  'S'.*/
        public StringBasis WAUX_FLAG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"S");
        /*"01    VIND-CODRET               PIC S9(04) COMP VALUE +0.*/
        public IntBasis VIND_CODRET { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  FILLER.*/
        public VA0813B_FILLER_11 FILLER_11 { get; set; } = new VA0813B_FILLER_11();
        public class VA0813B_FILLER_11 : VarBasis
        {
            /*"    03 W01-I                   PIC 9(009).*/
            public IntBasis W01_I { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    03 W01-R-AUX REDEFINES W01-I                                PIC 9(009).*/
            private _REDEF_IntBasis _w01_r_aux { get; set; }
            public _REDEF_IntBasis W01_R_AUX
            {
                get { _w01_r_aux = new _REDEF_IntBasis(new PIC("9", "009", "9(009).")); ; _.Move(W01_I, _w01_r_aux); VarBasis.RedefinePassValue(W01_I, _w01_r_aux, W01_I); _w01_r_aux.ValueChanged += () => { _.Move(_w01_r_aux, W01_I); }; return _w01_r_aux; }
                set { VarBasis.RedefinePassValue(value, _w01_r_aux, W01_I); }
            }  //Redefines
            /*"    03 W01-INPUT-I             PIC 9(003).*/
            public IntBasis W01_INPUT_I { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"    03 W01-SEG-INPUT-ANT       PIC S9(08)V9(4).*/
            public DoubleBasis W01_SEG_INPUT_ANT { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V9(4)."), 4);
            /*"    03 W01-OUTPUT-I            PIC 9(003).*/
            public IntBasis W01_OUTPUT_I { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"    03 W01-SEG-OUTPUT-ANT      PIC S9(08)V9(4).*/
            public DoubleBasis W01_SEG_OUTPUT_ANT { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V9(4)."), 4);
            /*"    03 W01-SEG-INI             PIC S9(08)V9(4).*/
            public DoubleBasis W01_SEG_INI { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V9(4)."), 4);
            /*"    03 W01-SEG-FIN             PIC S9(08)V9(4).*/
            public DoubleBasis W01_SEG_FIN { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V9(4)."), 4);
            /*"    03 W01-QTD-ACC-OK          PIC 9(008).*/
            public IntBasis W01_QTD_ACC_OK { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    03 W01-QTD-ACC-NOK         PIC 9(008).*/
            public IntBasis W01_QTD_ACC_NOK { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    03 W01-TOT-ACC-OK-ED       PIC ZZ.ZZZ.ZZ9.*/
            public IntBasis W01_TOT_ACC_OK_ED { get; set; } = new IntBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9."));
            /*"    03 W01-TOT-ACC-NOK-ED      PIC ZZ.ZZZ.ZZ9.*/
            public IntBasis W01_TOT_ACC_NOK_ED { get; set; } = new IntBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9."));
            /*"    03 W01-TOT-TIME-ED         PIC ZZZ.ZZ9,9999-.*/
            public DoubleBasis W01_TOT_TIME_ED { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V9999-."), 5);
            /*"    03      W01-CURRENT-DATE.*/
            public VA0813B_W01_CURRENT_DATE W01_CURRENT_DATE { get; set; } = new VA0813B_W01_CURRENT_DATE();
            public class VA0813B_W01_CURRENT_DATE : VarBasis
            {
                /*"      10    W01-CDTE-ANO       PIC  9(004).*/
                public IntBasis W01_CDTE_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10    W01-CDTE-MES       PIC  9(002).*/
                public IntBasis W01_CDTE_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    W01-CDTE-DIA       PIC  9(002).*/
                public IntBasis W01_CDTE_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    W01-CDTE-HORA      PIC  9(002).*/
                public IntBasis W01_CDTE_HORA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    W01-CDTE-MIN       PIC  9(002).*/
                public IntBasis W01_CDTE_MIN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    W01-CDTE-SEG       PIC  9(002).*/
                public IntBasis W01_CDTE_SEG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    W01-CDTE-DECSEG    PIC  9(002).*/
                public IntBasis W01_CDTE_DECSEG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    W01-CDTE-GREEN     PIC  X(001).*/
                public StringBasis W01_CDTE_GREEN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10    W01-CDTE-GHORA     PIC  9(002).*/
                public IntBasis W01_CDTE_GHORA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    W01-CDTE-GMIN      PIC  9(002).*/
                public IntBasis W01_CDTE_GMIN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03 W01-LIM-OCOR            PIC 9(009)      VALUE  94.*/
            }
            public IntBasis W01_LIM_OCOR { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"), 94);
            /*"    03 W01-TABELA-TOTAIS.*/
            public VA0813B_W01_TABELA_TOTAIS W01_TABELA_TOTAIS { get; set; } = new VA0813B_W01_TABELA_TOTAIS();
            public class VA0813B_W01_TABELA_TOTAIS : VarBasis
            {
                /*"       05 W01-TOT-ACC-OK       PIC 9(008)      OCCURS 94.*/
                public ListBasis<IntBasis, Int64> W01_TOT_ACC_OK { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "8", "9(008)"), 94);
                /*"       05 W01-TOT-ACC-NOK      PIC 9(008)      OCCURS 94.*/
                public ListBasis<IntBasis, Int64> W01_TOT_ACC_NOK { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "8", "9(008)"), 94);
                /*"       05 W01-TOT-TIME         PIC S9(08)V9(4) OCCURS 94.*/
                public ListBasis<DoubleBasis, double> W01_TOT_TIME { get; set; } = new ListBasis<DoubleBasis, double>(new PIC("S9", "8", "S9(08)V9(4)"), 94);
                /*"    03 W01-TABELA-TEXTO.*/
            }
            public VA0813B_W01_TABELA_TEXTO W01_TABELA_TEXTO { get; set; } = new VA0813B_W01_TABELA_TEXTO();
            public class VA0813B_W01_TABELA_TEXTO : VarBasis
            {
                /*"       05 W01-TAB-TEXTO                        OCCURS 94.*/
                public ListBasis<VA0813B_W01_TAB_TEXTO> W01_TAB_TEXTO { get; set; } = new ListBasis<VA0813B_W01_TAB_TEXTO>(94);
                public class VA0813B_W01_TAB_TEXTO : VarBasis
                {
                    /*"          10 W01-ORDEM         PIC X(002).*/
                    public StringBasis W01_ORDEM { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"          10 W01-TEXTO         PIC X(034).*/
                    public StringBasis W01_TEXTO { get; set; } = new StringBasis(new PIC("X", "34", "X(034)."), @"");
                    /*"01  WORK-TAB-RAMO-CONJ.*/
                }
            }
        }
        public VA0813B_WORK_TAB_RAMO_CONJ WORK_TAB_RAMO_CONJ { get; set; } = new VA0813B_WORK_TAB_RAMO_CONJ();
        public class VA0813B_WORK_TAB_RAMO_CONJ : VarBasis
        {
            /*"    05  N5WORK-TAB-RAMO-CONJ    OCCURS 30 TIMES.*/
            public ListBasis<VA0813B_N5WORK_TAB_RAMO_CONJ> N5WORK_TAB_RAMO_CONJ { get; set; } = new ListBasis<VA0813B_N5WORK_TAB_RAMO_CONJ>(30);
            public class VA0813B_N5WORK_TAB_RAMO_CONJ : VarBasis
            {
                /*"      10  TB-GRUPO-SUSEP              PIC S9(004) COMP.*/
                public IntBasis TB_GRUPO_SUSEP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"      10  TB-RAMO-CONJ                PIC S9(004) COMP.*/
                public IntBasis TB_RAMO_CONJ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"      10  TB-TAXA-RAMO-CONJ           PIC S9(003)V9(4) COMP-3.*/
                public DoubleBasis TB_TAXA_RAMO_CONJ { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
                /*"01  WORK-RAMO-CONJ.*/
            }
        }
        public VA0813B_WORK_RAMO_CONJ WORK_RAMO_CONJ { get; set; } = new VA0813B_WORK_RAMO_CONJ();
        public class VA0813B_WORK_RAMO_CONJ : VarBasis
        {
            /*"    05  WS-GRUPO-SUSEP-ANT            PIC S9(004) COMP.*/
            public IntBasis WS_GRUPO_SUSEP_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05  WS-RAMO-CONJ-ANT              PIC S9(004) COMP.*/
            public IntBasis WS_RAMO_CONJ_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05  WS-IND                        PIC S9(004) COMP.*/
            public IntBasis WS_IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05  WS-IND1                       PIC S9(004) COMP.*/
            public IntBasis WS_IND1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05  WHOST-VLR-PERC-PREMIO         PIC S9(003)V9(04) COMP-3.*/
            public DoubleBasis WHOST_VLR_PERC_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(04)"), 4);
            /*"    05  WHOST-VLR-PERC-PREMIO-TOT     PIC S9(003)V9(04) COMP-3.*/
            public DoubleBasis WHOST_VLR_PERC_PREMIO_TOT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(04)"), 4);
            /*"    05  WS-SALVA                      PIC  X(020).*/
            public StringBasis WS_SALVA { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"01  WORK-AREA.*/
        }
        public VA0813B_WORK_AREA WORK_AREA { get; set; } = new VA0813B_WORK_AREA();
        public class VA0813B_WORK_AREA : VarBasis
        {
            /*"    05 AC-LIDOS                      PIC 9(7) VALUE 0.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(7)"));
            /*"    05 AC-CONTA                      PIC 9(7) VALUE 0.*/
            public IntBasis AC_CONTA { get; set; } = new IntBasis(new PIC("9", "7", "9(7)"));
            /*"    05      WS-AREA-VERSAO.*/
            public VA0813B_WS_AREA_VERSAO WS_AREA_VERSAO { get; set; } = new VA0813B_WS_AREA_VERSAO();
            public class VA0813B_WS_AREA_VERSAO : VarBasis
            {
                /*"      10    WS-VERSAO                PIC  X(006) VALUE ' V.69 '.*/
                public StringBasis WS_VERSAO { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @" V.69 ");
                /*"      10    WS-CADMUS                PIC  X(006) VALUE '122275'.*/
                public StringBasis WS_CADMUS { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"122275");
                /*"    05      DATA-SQL.*/
            }
            public VA0813B_DATA_SQL DATA_SQL { get; set; } = new VA0813B_DATA_SQL();
            public class VA0813B_DATA_SQL : VarBasis
            {
                /*"      10    ANO-SQL                  PIC  9(004).*/
                public IntBasis ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10    FILLER                   PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10    MES-SQL                  PIC  9(002).*/
                public IntBasis MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    FILLER                   PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10    DIA-SQL                  PIC  9(002).*/
                public IntBasis DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05 WS-TIME                       PIC  X(008).*/
            }
            public StringBasis WS_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05 WS-DATA-INV.*/
            public VA0813B_WS_DATA_INV WS_DATA_INV { get; set; } = new VA0813B_WS_DATA_INV();
            public class VA0813B_WS_DATA_INV : VarBasis
            {
                /*"      10 WS-ANO-INV                  PIC  9(004).*/
                public IntBasis WS_ANO_INV { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10 WS-MES-INV                  PIC  9(002).*/
                public IntBasis WS_MES_INV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10 WS-DIA-INV                  PIC  9(002).*/
                public IntBasis WS_DIA_INV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05      WS-EOF                   PIC  9(001) VALUE 0.*/
            }
            public IntBasis WS_EOF { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05      WS-NAO-ACHEI             PIC  9(001) VALUE 0.*/
            public IntBasis WS_NAO_ACHEI { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05      WS-CODCONV               PIC  9(004).*/
            public IntBasis WS_CODCONV { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05 AC-INSERIDOS              PIC  9(9)      VALUE  0.*/
            public IntBasis AC_INSERIDOS { get; set; } = new IntBasis(new PIC("9", "9", "9(9)"));
            /*"    05 AC-COMISSAO               PIC  9(9)      VALUE  0.*/
            public IntBasis AC_COMISSAO { get; set; } = new IntBasis(new PIC("9", "9", "9(9)"));
            /*"    05 WS-REGISTROS              PIC  9(9)      VALUE  0.*/
            public IntBasis WS_REGISTROS { get; set; } = new IntBasis(new PIC("9", "9", "9(9)"));
            /*"    05 WS-QTDBEFET               PIC  9(9)      VALUE  0.*/
            public IntBasis WS_QTDBEFET { get; set; } = new IntBasis(new PIC("9", "9", "9(9)"));
            /*"    05 WS-ACG-TOTDBEFET          PIC  9(13)V99  VALUE  0.*/
            public DoubleBasis WS_ACG_TOTDBEFET { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
            /*"    05 WS-ACG-TOTDBNEFET         PIC  9(13)V99  VALUE  0.*/
            public DoubleBasis WS_ACG_TOTDBNEFET { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
            /*"    05 WS-DIFERENCA              PIC  9(13)V99  VALUE  0.*/
            public DoubleBasis WS_DIFERENCA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
            /*"    05 WS-PC-VG                  PIC  9(03)V9(7) VALUE  0.*/
            public DoubleBasis WS_PC_VG { get; set; } = new DoubleBasis(new PIC("9", "3", "9(03)V9(7)"), 7);
            /*"    05 WS-PCT-COB-VG             PIC  9(03)V9(7) VALUE  0.*/
            public DoubleBasis WS_PCT_COB_VG { get; set; } = new DoubleBasis(new PIC("9", "3", "9(03)V9(7)"), 7);
            /*"    05 WS-PCT-COB-AP             PIC  9(03)V9(7) VALUE  0.*/
            public DoubleBasis WS_PCT_COB_AP { get; set; } = new DoubleBasis(new PIC("9", "3", "9(03)V9(7)"), 7);
            /*"    05 AUX-NSAC                  PIC  9(005).*/
            public IntBasis AUX_NSAC { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"    05 AUX-CONVENIO              PIC  9(004).*/
            public IntBasis AUX_CONVENIO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05 LD-PRODUTO                PIC  9(007)    VALUE  ZEROS.*/
            public IntBasis LD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    05 AUX-VLPRMTOT              PIC  9(13)V99  VALUE  0.*/
            public DoubleBasis AUX_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
            /*"    05 AUX-VLDESPES              PIC  9(13)V99  VALUE  0.*/
            public DoubleBasis AUX_VLDESPES { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
            /*"    05 WS-NRAVISO                PIC  9(009)    VALUE  0.*/
            public IntBasis WS_NRAVISO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05 FILLER                    REDEFINES      WS-NRAVISO.*/
            private _REDEF_VA0813B_FILLER_14 _filler_14 { get; set; }
            public _REDEF_VA0813B_FILLER_14 FILLER_14
            {
                get { _filler_14 = new _REDEF_VA0813B_FILLER_14(); _.Move(WS_NRAVISO, _filler_14); VarBasis.RedefinePassValue(WS_NRAVISO, _filler_14, WS_NRAVISO); _filler_14.ValueChanged += () => { _.Move(_filler_14, WS_NRAVISO); }; return _filler_14; }
                set { VarBasis.RedefinePassValue(value, _filler_14, WS_NRAVISO); }
            }  //Redefines
            public class _REDEF_VA0813B_FILLER_14 : VarBasis
            {
                /*"      10 WS-AGEAVISO             PIC  9(004).*/
                public IntBasis WS_AGEAVISO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10 WS-NSAC                 PIC  9(005).*/
                public IntBasis WS_NSAC { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"    05       WS-SUBS           PIC  9(005)    VALUE ZEROS.*/

                public _REDEF_VA0813B_FILLER_14()
                {
                    WS_AGEAVISO.ValueChanged += OnValueChanged;
                    WS_NSAC.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_SUBS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    05       WS-SUBS1          PIC  9(005)    VALUE ZEROS.*/
            public IntBasis WS_SUBS1 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    05       WS-SUBS2          PIC  9(005)    VALUE ZEROS.*/
            public IntBasis WS_SUBS2 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    05       WFIM-PRODUTO      PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_PRODUTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05       WFIM-VGRAMOCOMP   PIC  X(003)    VALUE ' '.*/
            public StringBasis WFIM_VGRAMOCOMP { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ");
            /*"    05       WFIM-TAB-RAMO     PIC  X(003)    VALUE ' '.*/
            public StringBasis WFIM_TAB_RAMO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ");
            /*"    05       WS-PROD-BALCAO    PIC  X(003)    VALUE ' '.*/
            public StringBasis WS_PROD_BALCAO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ");
            /*"    05       WDATA-REL         PIC  X(010)    VALUE SPACES.*/
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    05       FILLER            REDEFINES      WDATA-REL.*/
            private _REDEF_VA0813B_FILLER_15 _filler_15 { get; set; }
            public _REDEF_VA0813B_FILLER_15 FILLER_15
            {
                get { _filler_15 = new _REDEF_VA0813B_FILLER_15(); _.Move(WDATA_REL, _filler_15); VarBasis.RedefinePassValue(WDATA_REL, _filler_15, WDATA_REL); _filler_15.ValueChanged += () => { _.Move(_filler_15, WDATA_REL); }; return _filler_15; }
                set { VarBasis.RedefinePassValue(value, _filler_15, WDATA_REL); }
            }  //Redefines
            public class _REDEF_VA0813B_FILLER_15 : VarBasis
            {
                /*"      10     WDAT-REL-ANO      PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10     FILLER            PIC  X(001).*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10     WDAT-REL-MES      PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     FILLER            PIC  X(001).*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10     WDAT-REL-DIA      PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05  WS-RESULT             PIC  9(006)    VALUE   ZEROS.*/

                public _REDEF_VA0813B_FILLER_15()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_16.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_17.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_RESULT { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05  AUX-ANO   PIC  9(004)    VALUE   ZEROS.*/
            public IntBasis AUX_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05  FILLER    REDEFINES      AUX-ANO.*/
            private _REDEF_VA0813B_FILLER_18 _filler_18 { get; set; }
            public _REDEF_VA0813B_FILLER_18 FILLER_18
            {
                get { _filler_18 = new _REDEF_VA0813B_FILLER_18(); _.Move(AUX_ANO, _filler_18); VarBasis.RedefinePassValue(AUX_ANO, _filler_18, AUX_ANO); _filler_18.ValueChanged += () => { _.Move(_filler_18, AUX_ANO); }; return _filler_18; }
                set { VarBasis.RedefinePassValue(value, _filler_18, AUX_ANO); }
            }  //Redefines
            public class _REDEF_VA0813B_FILLER_18 : VarBasis
            {
                /*"          10 AUX-ANO1           PIC  9(002).*/
                public IntBasis AUX_ANO1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"          10 AUX-ANO2           PIC  9(002).*/
                public IntBasis AUX_ANO2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05 WSQLCODE3                     PIC S9(009) COMP.*/

                public _REDEF_VA0813B_FILLER_18()
                {
                    AUX_ANO1.ValueChanged += OnValueChanged;
                    AUX_ANO2.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    05      WABEND.*/
            public VA0813B_WABEND WABEND { get; set; } = new VA0813B_WABEND();
            public class VA0813B_WABEND : VarBasis
            {
                /*"      10    FILLER                   PIC  X(010) VALUE            'VA0813B  '.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VA0813B  ");
                /*"      10    FILLER                   PIC  X(028) VALUE            ' *** ERRO  EXEC SQL ***'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL ***");
                /*"      10    FILLER                   PIC  X(014) VALUE            '    SQLCODE = '.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"      10    WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD1 = '.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"      10    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"      10    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    05      LOCALIZA-ABEND-1.*/
            }
            public VA0813B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new VA0813B_LOCALIZA_ABEND_1();
            public class VA0813B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05      LOCALIZA-ABEND-2.*/
            }
            public VA0813B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new VA0813B_LOCALIZA_ABEND_2();
            public class VA0813B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'COMANDO   = '.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"      10    COMANDO                  PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"01  AUX-TABELAS.*/
            }
        }
        public VA0813B_AUX_TABELAS AUX_TABELAS { get; set; } = new VA0813B_AUX_TABELAS();
        public class VA0813B_AUX_TABELAS : VarBasis
        {
            /*"  03          WTABG-VALORES.*/
            public VA0813B_WTABG_VALORES WTABG_VALORES { get; set; } = new VA0813B_WTABG_VALORES();
            public class VA0813B_WTABG_VALORES : VarBasis
            {
                /*"    05        WTABG-OCORREPRD     OCCURS       2000  TIMES                                  INDEXED      BY    WS-PRD.*/
                public ListBasis<VA0813B_WTABG_OCORREPRD> WTABG_OCORREPRD { get; set; } = new ListBasis<VA0813B_WTABG_OCORREPRD>(2000);
                public class VA0813B_WTABG_OCORREPRD : VarBasis
                {
                    /*"      10      WTABG-CODPRODU      PIC S9(004)        COMP.*/
                    public IntBasis WTABG_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                    /*"      10      WTABG-OCORRETIP     OCCURS       003   TIMES                                  INDEXED      BY    WS-TIP.*/
                    public ListBasis<VA0813B_WTABG_OCORRETIP> WTABG_OCORRETIP { get; set; } = new ListBasis<VA0813B_WTABG_OCORRETIP>(003);
                    public class VA0813B_WTABG_OCORRETIP : VarBasis
                    {
                        /*"        15    WTABG-TIPO          PIC  X(001).*/
                        public StringBasis WTABG_TIPO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                        /*"        15    WTABG-OCORRESIT     OCCURS       002   TIMES                                  INDEXED      BY    WS-SIT.*/
                        public ListBasis<VA0813B_WTABG_OCORRESIT> WTABG_OCORRESIT { get; set; } = new ListBasis<VA0813B_WTABG_OCORRESIT>(002);
                        public class VA0813B_WTABG_OCORRESIT : VarBasis
                        {
                            /*"          20  WTABG-SITUACAO      PIC  X(001).*/
                            public StringBasis WTABG_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                            /*"          20  WTABG-QTDE          PIC S9(009)        COMP.*/
                            public IntBasis WTABG_QTDE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                            /*"          20  WTABG-VLPRMTOT      PIC S9(013)V99     COMP-3.*/
                            public DoubleBasis WTABG_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                            /*"          20  WTABG-VLTARIFA      PIC S9(013)V99     COMP-3.*/
                            public DoubleBasis WTABG_VLTARIFA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                            /*"          20  WTABG-VLBALCAO      PIC S9(013)V99     COMP-3.*/
                            public DoubleBasis WTABG_VLBALCAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                            /*"          20  WTABG-VLIOCC        PIC S9(013)V99     COMP-3.*/
                            public DoubleBasis WTABG_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                            /*"          20  WTABG-VLDESCON      PIC S9(013)V99     COMP-3.*/
                            public DoubleBasis WTABG_VLDESCON { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                        }
                    }
                }
            }
        }


        public Dclgens.PARAGEEM PARAGEEM { get; set; } = new Dclgens.PARAGEEM();
        public Dclgens.TERMOADE TERMOADE { get; set; } = new Dclgens.TERMOADE();
        public Dclgens.SUBGVGAP SUBGVGAP { get; set; } = new Dclgens.SUBGVGAP();
        public Dclgens.VGPROSIA VGPROSIA { get; set; } = new Dclgens.VGPROSIA();
        public Dclgens.VGFOLLOW VGFOLLOW { get; set; } = new Dclgens.VGFOLLOW();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.VG080 VG080 { get; set; } = new Dclgens.VG080();
        public Dclgens.VG081 VG081 { get; set; } = new Dclgens.VG081();
        public Dclgens.VG082 VG082 { get; set; } = new Dclgens.VG082();
        public Dclgens.CONDITEC CONDITEC { get; set; } = new Dclgens.CONDITEC();
        public Dclgens.VGCOBSUB VGCOBSUB { get; set; } = new Dclgens.VGCOBSUB();
        public Dclgens.VGCOBSUH VGCOBSUH { get; set; } = new Dclgens.VGCOBSUH();
        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public VA0813B_CHCONTA2 CHCONTA2 { get; set; } = new VA0813B_CHCONTA2();
        public VA0813B_CHCONTA3 CHCONTA3 { get; set; } = new VA0813B_CHCONTA3();
        public VA0813B_V0PRODUTO V0PRODUTO { get; set; } = new VA0813B_V0PRODUTO();
        public VA0813B_CVGRAMOCOMP CVGRAMOCOMP { get; set; } = new VA0813B_CVGRAMOCOMP();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string RETDEB_FILE_NAME_P, string RETERR_FILE_NAME_P, string MAUDIT_FILE_NAME_P, string SVADEB_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                RETDEB.SetFile(RETDEB_FILE_NAME_P);
                RETERR.SetFile(RETERR_FILE_NAME_P);
                MAUDIT.SetFile(MAUDIT_FILE_NAME_P);
                SVADEB.SetFile(SVADEB_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM M-0000-PRINCIPAL-SECTION */

                M_0000_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-SECTION */
        private void M_0000_PRINCIPAL_SECTION()
        {
            /*" -1472- DISPLAY ' ' */
            _.Display($" ");

            /*" -1474- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -1481- DISPLAY 'PROGRAMA VA0813B - VERSAO V.88 - DEMANDA 280.598 - ' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) '-' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) */

            $"PROGRAMA VA0813B - VERSAO V.88 - DEMANDA 280.598 - FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)}-FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}"
            .Display();

            /*" -1483- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -1484- DISPLAY ' ' */
            _.Display($" ");

            /*" -1491- DISPLAY 'INICIOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"INICIOU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -1494- DISPLAY '   ' */
            _.Display($"   ");

            /*" -1497- INITIALIZE W01-TABELA-TOTAIS */
            _.Initialize(
                FILLER_11.W01_TABELA_TOTAIS
            );

            /*" -1498- MOVE 01 TO W01-I */
            _.Move(01, FILLER_11.W01_I);

            /*" -1499- MOVE 'SORT' TO W01-TEXTO(W01-I) */
            _.Move("SORT", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -1503- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -1505- MOVE +200000 TO SORT-FILE-SIZE. */
            _.Move(+200000, SORT_FILE_SIZE);

            /*" -1513- SORT SVADEB ON ASCENDING KEY SF-COD-REG SF-IDENTIF-CLI SF-COD-RETORNO SF-IDENTIF-NSA SF-NSL USING RETDEB GIVING RETDEB. */
            RETDEB.AllLines = RETDEB.SortFile("SF-COD-REG,SF-IDENTIF-CLI,SF-COD-RETORNO,SF-IDENTIF-NSA,SF-NSL", SVADEB.FileLayout);

            /*" -1517- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -1521- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -1522- OPEN INPUT RETDEB. */
            RETDEB.Open(RETDEB_RECORD);

            /*" -1523- OPEN OUTPUT RETERR. */
            RETERR.Open(RETERR_RECORD);

            /*" -1527- OPEN OUTPUT MAUDIT. */
            MAUDIT.Open(MAUDIT_RECORD);

            /*" -1528- MOVE '0001-INICIO  ' TO PARAGRAFO. */
            _.Move("0001-INICIO  ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1538- MOVE 'LOCK TSPACE' TO COMANDO. */
            _.Move("LOCK TSPACE", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1540- EXEC SQL LOCK TABLE SEGUROS.PARCELAS_VIDAZUL IN EXCLUSIVE MODE END-EXEC. */

            /* EXEC SQL LOCK TABLE SEGUROS.PARCELAS_VIDAZUL IN EXCLUSIVE MODE END-EXEC. */

            /*" -1544- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -1548- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -1549- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1550- DISPLAY 'PROBLEMAS NO LOCK TABLE' */
                _.Display($"PROBLEMAS NO LOCK TABLE");

                /*" -1551- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1556- END-IF. */
            }


            /*" -1557- MOVE '0001-INICIO  ' TO PARAGRAFO. */
            _.Move("0001-INICIO  ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1567- MOVE 'SELECT V1SISTEMA' TO COMANDO. */
            _.Move("SELECT V1SISTEMA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1579- PERFORM M_0000_PRINCIPAL_DB_SELECT_1 */

            M_0000_PRINCIPAL_DB_SELECT_1();

            /*" -1583- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -1587- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -1588- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1589- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1590- DISPLAY 'SISTEMA NAO ENCONTRADO' */
                    _.Display($"SISTEMA NAO ENCONTRADO");

                    /*" -1591- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1592- ELSE */
                }
                else
                {


                    /*" -1593- DISPLAY 'PROBLEMAS NO ACESSO A SISTEMAS' */
                    _.Display($"PROBLEMAS NO ACESSO A SISTEMAS");

                    /*" -1594- END-IF */
                }


                /*" -1596- END-IF. */
            }


            /*" -1598- PERFORM R0050-00-INICIO. */

            R0050_00_INICIO_SECTION();

            /*" -1599- READ RETDEB AT END */
            try
            {
                RETDEB.Read(() =>
                {

                    /*" -1600- DISPLAY '*** VA0813B *** MOVIMENTO RETORNO VAZIO' */
                    _.Display($"*** VA0813B *** MOVIMENTO RETORNO VAZIO");

                    /*" -1602- GO TO R0001-00-FIM-NORMAL. */

                    R0001_00_FIM_NORMAL(); //GOTO
                    return;
                });

                _.Move(RETDEB.Value, RETDEB_RECORD);
                _.Move(RETDEB.Value, RET_HEADER);
                _.Move(RETDEB.Value, RET_CADASTRAMENTO);
                _.Move(RETDEB.Value, RET_TRAILLER);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -1603- IF RA-COD-REG NOT EQUAL 'A' */

            if (RET_HEADER.RA_COD_REG != "A")
            {

                /*" -1604- DISPLAY '*** VA0813B *** FITA SEM HEADER' */
                _.Display($"*** VA0813B *** FITA SEM HEADER");

                /*" -1606- GO TO R0001-00-FIM-ANORMAL. */

                R0001_00_FIM_ANORMAL(); //GOTO
                return;
            }


            /*" -1611- MOVE RA-COD-CONVENIO TO WS-CODCONV WHOST-CODCONV. */
            _.Move(RET_HEADER.RA_COD_CONVENIO, WORK_AREA.WS_CODCONV, WHOST_CODCONV);

            /*" -1612- IF WS-CODCONV NOT EQUAL 6081 AND 6088 AND 6132 AND 6153 */

            if (!WORK_AREA.WS_CODCONV.In("6081", "6088", "6132", "6153"))
            {

                /*" -1614- GO TO R0001-00-FIM-NORMAL. */

                R0001_00_FIM_NORMAL(); //GOTO
                return;
            }


            /*" -1616- MOVE RA-NSA TO V0FTCF-NSAC. */
            _.Move(RET_HEADER.RA_NSA, V0FTCF_NSAC);

            /*" -1617- MOVE WS-CODCONV TO AUX-CONVENIO */
            _.Move(WORK_AREA.WS_CODCONV, WORK_AREA.AUX_CONVENIO);

            /*" -1619- MOVE RA-NSA TO AUX-NSAC. */
            _.Move(RET_HEADER.RA_NSA, WORK_AREA.AUX_NSAC);

            /*" -1620- IF WS-CODCONV = 6081 */

            if (WORK_AREA.WS_CODCONV == 6081)
            {

                /*" -1622- ADD 19000 TO V0FTCF-NSAC. */
                V0FTCF_NSAC.Value = V0FTCF_NSAC + 19000;
            }


            /*" -1623- IF WS-CODCONV = 6088 */

            if (WORK_AREA.WS_CODCONV == 6088)
            {

                /*" -1625- ADD 23000 TO V0FTCF-NSAC. */
                V0FTCF_NSAC.Value = V0FTCF_NSAC + 23000;
            }


            /*" -1626- IF WS-CODCONV = 6132 */

            if (WORK_AREA.WS_CODCONV == 6132)
            {

                /*" -1628- ADD 28000 TO V0FTCF-NSAC. */
                V0FTCF_NSAC.Value = V0FTCF_NSAC + 28000;
            }


            /*" -1629- IF WS-CODCONV = 6153 */

            if (WORK_AREA.WS_CODCONV == 6153)
            {

                /*" -1631- ADD 30000 TO V0FTCF-NSAC. */
                V0FTCF_NSAC.Value = V0FTCF_NSAC + 30000;
            }


            /*" -1632- MOVE RA-DATA-GERACAO TO WS-DATA-INV. */
            _.Move(RET_HEADER.RA_DATA_GERACAO, WORK_AREA.WS_DATA_INV);

            /*" -1633- MOVE WS-ANO-INV TO ANO-SQL. */
            _.Move(WORK_AREA.WS_DATA_INV.WS_ANO_INV, WORK_AREA.DATA_SQL.ANO_SQL);

            /*" -1634- MOVE WS-MES-INV TO MES-SQL. */
            _.Move(WORK_AREA.WS_DATA_INV.WS_MES_INV, WORK_AREA.DATA_SQL.MES_SQL);

            /*" -1636- MOVE WS-DIA-INV TO DIA-SQL. */
            _.Move(WORK_AREA.WS_DATA_INV.WS_DIA_INV, WORK_AREA.DATA_SQL.DIA_SQL);

            /*" -1637- MOVE DATA-SQL TO V0FTCF-DTRET. */
            _.Move(WORK_AREA.DATA_SQL, V0FTCF_DTRET);

            /*" -1638- MOVE DATA-SQL TO V0FTCF-DTRET2. */
            _.Move(WORK_AREA.DATA_SQL, V0FTCF_DTRET2);

            /*" -1640- MOVE RA-VERSAO-LAYOUT TO V0FTCF-VERSAO. */
            _.Move(RET_HEADER.RA_VERSAO_LAYOUT, V0FTCF_VERSAO);

            /*" -1642- WRITE RETERR-RECORD FROM RETDEB-RECORD. */
            _.Move(RETDEB_RECORD.GetMoveValues(), RETERR_RECORD);

            RETERR.Write(RETERR_RECORD.GetMoveValues().ToString());

            /*" -1643- IF WS-CODCONV EQUAL 6088 */

            if (WORK_AREA.WS_CODCONV == 6088)
            {

                /*" -1645- PERFORM R0090-00-MONTA-AVISO. */

                R0090_00_MONTA_AVISO_SECTION();
            }


            /*" -1646- READ RETDEB AT END */
            try
            {
                RETDEB.Read(() =>
                {

                    /*" -1647- DISPLAY '*** VA0813B *** FITA SEM MOVIMENTO ' */
                    _.Display($"*** VA0813B *** FITA SEM MOVIMENTO ");

                    /*" -1649- GO TO R0001-00-FIM-NORMAL. */

                    R0001_00_FIM_NORMAL(); //GOTO
                    return;
                });

                _.Move(RETDEB.Value, RETDEB_RECORD);
                _.Move(RETDEB.Value, RET_HEADER);
                _.Move(RETDEB.Value, RET_CADASTRAMENTO);
                _.Move(RETDEB.Value, RET_TRAILLER);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -1650- IF RA-COD-REG NOT EQUAL 'F' AND 'Z' */

            if (!RET_HEADER.RA_COD_REG.In("F", "Z"))
            {

                /*" -1651- MOVE RETDEB-RECORD TO RETERR-REGISTRO */
                _.Move(RETDEB?.Value, RETERR_RECORD.RETERR_REGISTRO);

                /*" -1652- MOVE 'COD REGISTRO NAO ESPERADO' TO RETERR-MENSAGEM */
                _.Move("COD REGISTRO NAO ESPERADO", RETERR_RECORD.RETERR_MENSAGEM);

                /*" -1653- WRITE RETERR-RECORD */
                RETERR.Write(RETERR_RECORD.GetMoveValues().ToString());

                /*" -1655- GO TO R0001-00-FIM-ANORMAL. */

                R0001_00_FIM_ANORMAL(); //GOTO
                return;
            }


            /*" -1656- IF RA-COD-REG EQUAL 'Z' */

            if (RET_HEADER.RA_COD_REG == "Z")
            {

                /*" -1657- MOVE RETDEB-RECORD TO RETERR-REGISTRO */
                _.Move(RETDEB?.Value, RETERR_RECORD.RETERR_REGISTRO);

                /*" -1658- MOVE 'NAO HA RETORNO DE DEBITO' TO RETERR-MENSAGEM */
                _.Move("NAO HA RETORNO DE DEBITO", RETERR_RECORD.RETERR_MENSAGEM);

                /*" -1659- WRITE RETERR-RECORD */
                RETERR.Write(RETERR_RECORD.GetMoveValues().ToString());

                /*" -1661- GO TO R0001-00-FIM-NORMAL. */

                R0001_00_FIM_NORMAL(); //GOTO
                return;
            }


            /*" -1666- MOVE V0FTCF-NSAC TO WS-NSAC */
            _.Move(V0FTCF_NSAC, WORK_AREA.FILLER_14.WS_NSAC);

            /*" -1670- PERFORM R0020-00-PROCESSA UNTIL WS-EOF = 1 OR RA-COD-REG NOT EQUAL 'F' . */

            while (!(WORK_AREA.WS_EOF == 1 || RET_HEADER.RA_COD_REG != "F"))
            {

                R0020_00_PROCESSA_SECTION();
            }

            /*" -1671- IF WS-EOF = 1 */

            if (WORK_AREA.WS_EOF == 1)
            {

                /*" -1672- DISPLAY '*** VA0813B *** FITA SEM TRAILLER' */
                _.Display($"*** VA0813B *** FITA SEM TRAILLER");

                /*" -1673- GO TO R0001-00-FIM-ANORMAL */

                R0001_00_FIM_ANORMAL(); //GOTO
                return;

                /*" -1674- ELSE */
            }
            else
            {


                /*" -1675- IF RA-COD-REG NOT EQUAL 'Z' */

                if (RET_HEADER.RA_COD_REG != "Z")
                {

                    /*" -1676- MOVE RETDEB-RECORD TO RETERR-REGISTRO */
                    _.Move(RETDEB?.Value, RETERR_RECORD.RETERR_REGISTRO);

                    /*" -1677- MOVE 'COD REGISTRO NAO ESPERADO' TO RETERR-MENSAGEM */
                    _.Move("COD REGISTRO NAO ESPERADO", RETERR_RECORD.RETERR_MENSAGEM);

                    /*" -1678- WRITE RETERR-RECORD */
                    RETERR.Write(RETERR_RECORD.GetMoveValues().ToString());

                    /*" -1680- GO TO R0001-00-FIM-ANORMAL. */

                    R0001_00_FIM_ANORMAL(); //GOTO
                    return;
                }

            }


            /*" -1682- WRITE RETERR-RECORD FROM RETDEB-RECORD. */
            _.Move(RETDEB_RECORD.GetMoveValues(), RETERR_RECORD);

            RETERR.Write(RETERR_RECORD.GetMoveValues().ToString());

            /*" -1684- DISPLAY '*** VA0813B *** LANCAMENTOS RETORNADOS ' WS-REGISTROS. */
            _.Display($"*** VA0813B *** LANCAMENTOS RETORNADOS {WORK_AREA.WS_REGISTROS}");

            /*" -1686- DISPLAY '*** VA0813B *** DEBITOS RETORNADOS     ' RZ-TOT-DEB-CRUZ. */
            _.Display($"*** VA0813B *** DEBITOS RETORNADOS     {RET_TRAILLER.RZ_TOT_DEB_CRUZ}");

            /*" -1688- DISPLAY '*** VA0813B *** DEBITOS EFETUADOS      ' WS-ACG-TOTDBEFET. */
            _.Display($"*** VA0813B *** DEBITOS EFETUADOS      {WORK_AREA.WS_ACG_TOTDBEFET}");

            /*" -1690- DISPLAY '*** VA0813B *** DEBITOS NAO EFET       ' WS-ACG-TOTDBNEFET. */
            _.Display($"*** VA0813B *** DEBITOS NAO EFET       {WORK_AREA.WS_ACG_TOTDBNEFET}");

            /*" -1692- DISPLAY '*** VA0813B *** INSERIDOS FUNDOCOMISVA ' AC-INSERIDOS. */
            _.Display($"*** VA0813B *** INSERIDOS FUNDOCOMISVA {WORK_AREA.AC_INSERIDOS}");

            /*" -1695- DISPLAY '*** VA0813B *** INSERIDOS COMISSAO     ' AC-COMISSAO. */
            _.Display($"*** VA0813B *** INSERIDOS COMISSAO     {WORK_AREA.AC_COMISSAO}");

            /*" -1696- IF WS-REGISTROS GREATER ZEROES */

            if (WORK_AREA.WS_REGISTROS > 00)
            {

                /*" -1699- PERFORM R0050-00-GERA-FITACEF. */

                R0050_00_GERA_FITACEF_SECTION();
            }


            /*" -1701- IF WS-CODCONV EQUAL 6088 AND AUX-VLPRMTOT NOT EQUAL ZEROS */

            if (WORK_AREA.WS_CODCONV == 6088 && WORK_AREA.AUX_VLPRMTOT != 00)
            {

                /*" -1701- PERFORM R0100-00-INSERT-AVISOS. */

                R0100_00_INSERT_AVISOS_SECTION();
            }


            /*" -0- FLUXCONTROL_PERFORM R0001_00_FIM_NORMAL */

            R0001_00_FIM_NORMAL();

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-SELECT-1 */
        public void M_0000_PRINCIPAL_DB_SELECT_1()
        {
            /*" -1579- EXEC SQL SELECT DTMOVABE , DTMOVABE - 1 DAY, DTMOVABE + 1 DAY, CURRENT DATE INTO :V0SIST-DTMOVABE , :V0SIST-DTMOVABE-1, :V0SIST-DTMOVABE-A1, :V0SIST-DTCURR FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VA' WITH UR END-EXEC. */

            var m_0000_PRINCIPAL_DB_SELECT_1_Query1 = new M_0000_PRINCIPAL_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_0000_PRINCIPAL_DB_SELECT_1_Query1.Execute(m_0000_PRINCIPAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SIST_DTMOVABE, V0SIST_DTMOVABE);
                _.Move(executed_1.V0SIST_DTMOVABE_1, V0SIST_DTMOVABE_1);
                _.Move(executed_1.V0SIST_DTMOVABE_A1, V0SIST_DTMOVABE_A1);
                _.Move(executed_1.V0SIST_DTCURR, V0SIST_DTCURR);
            }


        }

        [StopWatch]
        /*" R0001-00-FIM-NORMAL */
        private void R0001_00_FIM_NORMAL(bool isPerform = false)
        {
            /*" -1706- MOVE 03 TO W01-I */
            _.Move(03, FILLER_11.W01_I);

            /*" -1707- MOVE 'COMMIT WORK' TO W01-TEXTO(W01-I) */
            _.Move("COMMIT WORK", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -1711- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -1711- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1715- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -1719- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -1720- CLOSE RETDEB. */
            RETDEB.Close();

            /*" -1721- CLOSE RETERR. */
            RETERR.Close();

            /*" -1723- CLOSE MAUDIT. */
            MAUDIT.Close();

            /*" -1724- DISPLAY '*** VA0813B *** TERMINO NORMAL' . */
            _.Display($"*** VA0813B *** TERMINO NORMAL");

            /*" -1727- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1731- PERFORM R8920-MOSTRA-TOTALIZADORES THRU R8920-MOSTRA-TOTALIZ-EXIT */

            R8920_MOSTRA_TOTALIZADORES_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8920_MOSTRA_TOTALIZ_EXIT*/


            /*" -1733- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -1733- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0001-00-FIM-ANORMAL */
        private void R0001_00_FIM_ANORMAL(bool isPerform = false)
        {
            /*" -1738- DISPLAY '*** VA0813B *** PROCESSAMENTO TERMINOU COM ERRO' . */
            _.Display($"*** VA0813B *** PROCESSAMENTO TERMINOU COM ERRO");

            /*" -1742- DISPLAY '*** VA0813B *** VIDE ARQUIVO RETERR COM MSG' . */
            _.Display($"*** VA0813B *** VIDE ARQUIVO RETERR COM MSG");

            /*" -1743- MOVE 04 TO W01-I */
            _.Move(04, FILLER_11.W01_I);

            /*" -1744- MOVE 'ROLLBACK WORK' TO W01-TEXTO(W01-I) */
            _.Move("ROLLBACK WORK", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -1748- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -1748- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1752- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -1756- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -1757- CLOSE RETDEB. */
            RETDEB.Close();

            /*" -1758- CLOSE RETERR. */
            RETERR.Close();

            /*" -1761- CLOSE MAUDIT. */
            MAUDIT.Close();

            /*" -1765- PERFORM R8920-MOSTRA-TOTALIZADORES THRU R8920-MOSTRA-TOTALIZ-EXIT */

            R8920_MOSTRA_TOTALIZADORES_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8920_MOSTRA_TOTALIZ_EXIT*/


            /*" -1767- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -1767- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0020-00-PROCESSA-SECTION */
        private void R0020_00_PROCESSA_SECTION()
        {
            /*" -1775- MOVE '0020-PROCESSA' TO PARAGRAFO. */
            _.Move("0020-PROCESSA", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1777- MOVE 'S' TO WAUX-FLAG. */
            _.Move("S", WAUX_FLAG);

            /*" -1778- ADD 1 TO AC-LIDOS AC-CONTA. */
            WORK_AREA.AC_LIDOS.Value = WORK_AREA.AC_LIDOS + 1;
            WORK_AREA.AC_CONTA.Value = WORK_AREA.AC_CONTA + 1;

            /*" -1779- IF AC-CONTA > 999 */

            if (WORK_AREA.AC_CONTA > 999)
            {

                /*" -1780- MOVE ZEROS TO AC-CONTA */
                _.Move(0, WORK_AREA.AC_CONTA);

                /*" -1781- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), WORK_AREA.WS_TIME);

                /*" -1784- DISPLAY 'LIDOS ' AC-LIDOS ' ' WS-TIME. */

                $"LIDOS {WORK_AREA.AC_LIDOS} {WORK_AREA.WS_TIME}"
                .Display();
            }


            /*" -1792- IF RF-VLPRMTOT EQUAL ZEROS OR RF-COD-RETORNO EQUAL 96 */

            if (RET_CADASTRAMENTO.RF_VLPRMTOT == 00 || RET_CADASTRAMENTO.RF_COD_RETORNO == 96)
            {

                /*" -1794- GO TO R0020-00-NEXT. */

                R0020_00_NEXT(); //GOTO
                return;
            }


            /*" -1798- MOVE 0 TO WS-NAO-ACHEI. */
            _.Move(0, WORK_AREA.WS_NAO_ACHEI);

            /*" -1801- IF RF-COD-RETORNO EQUAL 97 OR 98 OR 99 */

            if (RET_CADASTRAMENTO.RF_COD_RETORNO.In("97", "98", "99"))
            {

                /*" -1809- GO TO R0020-00-NEXT. */

                R0020_00_NEXT(); //GOTO
                return;
            }


            /*" -1812- IF RF-COD-RETORNO EQUAL ZEROS AND RF-COD-MOVIMENTO EQUAL ZEROS AND WS-CODCONV EQUAL 6088 */

            if (RET_CADASTRAMENTO.RF_COD_RETORNO == 00 && RET_CADASTRAMENTO.RF_COD_MOVIMENTO == 00 && WORK_AREA.WS_CODCONV == 6088)
            {

                /*" -1815- PERFORM R8000-00-TRATA-DESPESAS. */

                R8000_00_TRATA_DESPESAS_SECTION();
            }


            /*" -1816- IF RF-VLPRMTOT GREATER ZEROES */

            if (RET_CADASTRAMENTO.RF_VLPRMTOT > 00)
            {

                /*" -1817- IF RF-IDENTIF-CLI-R NUMERIC */

                if (RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_IDENTIF_CLI_R.IsNumeric())
                {

                    /*" -1819- IF RF-IDENTIF-CLI > 0 */

                    if (RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_IDENTIF_CLI > 0)
                    {

                        /*" -1820- PERFORM R0036-00-ACESSO-NSAS */

                        R0036_00_ACESSO_NSAS_SECTION();

                        /*" -1821- IF WS-NAO-ACHEI = 1 */

                        if (WORK_AREA.WS_NAO_ACHEI == 1)
                        {

                            /*" -1823- MOVE 0 TO WS-NAO-ACHEI */
                            _.Move(0, WORK_AREA.WS_NAO_ACHEI);

                            /*" -1824- PERFORM R0030-00-ACESSO-CERTIF */

                            R0030_00_ACESSO_CERTIF_SECTION();

                            /*" -1825- IF WS-NAO-ACHEI = 1 */

                            if (WORK_AREA.WS_NAO_ACHEI == 1)
                            {

                                /*" -1826- MOVE 0 TO WS-NAO-ACHEI */
                                _.Move(0, WORK_AREA.WS_NAO_ACHEI);

                                /*" -1827- PERFORM R0035-00-ACESSO-NUMCTADEB */

                                R0035_00_ACESSO_NUMCTADEB_SECTION();

                                /*" -1829- ELSE NEXT SENTENCE */
                            }
                            else
                            {


                                /*" -1831- ELSE NEXT SENTENCE */
                            }

                        }
                        else
                        {


                            /*" -1832- ELSE */
                        }

                    }
                    else
                    {


                        /*" -1833- PERFORM R0035-00-ACESSO-NUMCTADEB */

                        R0035_00_ACESSO_NUMCTADEB_SECTION();

                        /*" -1834- ELSE */
                    }

                }
                else
                {


                    /*" -1835- PERFORM R0035-00-ACESSO-NUMCTADEB */

                    R0035_00_ACESSO_NUMCTADEB_SECTION();

                    /*" -1836- ELSE */
                }

            }
            else
            {


                /*" -1838- MOVE 1 TO WS-NAO-ACHEI. */
                _.Move(1, WORK_AREA.WS_NAO_ACHEI);
            }


            /*" -1841- IF WS-NAO-ACHEI NOT EQUAL 0 */

            if (WORK_AREA.WS_NAO_ACHEI != 0)
            {

                /*" -1843- GO TO R0020-00-NEXT. */

                R0020_00_NEXT(); //GOTO
                return;
            }


            /*" -1844- MOVE RF-VLPRMTOT TO V0HCTA-VLPRMTOT. */
            _.Move(RET_CADASTRAMENTO.RF_VLPRMTOT, V0HCTA_VLPRMTOT);

            /*" -1846- MOVE RF-COD-RETORNO TO V0HCTA-CODRET. */
            _.Move(RET_CADASTRAMENTO.RF_COD_RETORNO, V0HCTA_CODRET);

            /*" -1847- MOVE '0020-PROCESSA' TO PARAGRAFO. */
            _.Move("0020-PROCESSA", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1852- MOVE 'SELECT V0PARCELVA' TO COMANDO. */
            _.Move("SELECT V0PARCELVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1853- MOVE 05 TO W01-I */
            _.Move(05, FILLER_11.W01_I);

            /*" -1854- MOVE 'SELECT V0PARCELVA' TO W01-TEXTO(W01-I) */
            _.Move("SELECT V0PARCELVA", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -1858- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -1873- PERFORM R0020_00_PROCESSA_DB_SELECT_1 */

            R0020_00_PROCESSA_DB_SELECT_1();

            /*" -1877- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -1883- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -1884- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1886- DISPLAY 'VA0813B - PROBLEMAS NO ACESSO A V0PARCELAVA ' V0HCTA-NRCERTIF ' ' V0HCTA-NRPARCEL */

                $"VA0813B - PROBLEMAS NO ACESSO A V0PARCELAVA {V0HCTA_NRCERTIF} {V0HCTA_NRPARCEL}"
                .Display();

                /*" -1888- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1890- MOVE 'SELECT V0HISTCOBVA' TO COMANDO. */
            _.Move("SELECT V0HISTCOBVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1894- MOVE RF-VLPRMTOT TO WS-VLPRMTOT. */
            _.Move(RET_CADASTRAMENTO.RF_VLPRMTOT, WS_VLPRMTOT);

            /*" -1895- MOVE 06 TO W01-I */
            _.Move(06, FILLER_11.W01_I);

            /*" -1896- MOVE 'SELECT V0HISTCOBVA' TO W01-TEXTO(W01-I) */
            _.Move("SELECT V0HISTCOBVA", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -1900- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -1919- PERFORM R0020_00_PROCESSA_DB_SELECT_2 */

            R0020_00_PROCESSA_DB_SELECT_2();

            /*" -1923- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -1929- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -1930- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1931- IF SQLCODE EQUAL -811 */

                if (DB.SQLCODE == -811)
                {

                    /*" -1932- PERFORM R0040-00-SEL-V0HISTCOBVA */

                    R0040_00_SEL_V0HISTCOBVA_SECTION();

                    /*" -1933- ELSE */
                }
                else
                {


                    /*" -1935- DISPLAY 'VA0813B - PROBLEMAS NO ACESSO A V0HISTCOBVA ' V0HCTA-NRCERTIF ' ' V0HCTA-NRPARCEL */

                    $"VA0813B - PROBLEMAS NO ACESSO A V0HISTCOBVA {V0HCTA_NRCERTIF} {V0HCTA_NRPARCEL}"
                    .Display();

                    /*" -1936- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1937- END-IF */
                }


                /*" -1939- END-IF. */
            }


            /*" -1944- MOVE 'SELECT V0OPCAOPAGVA' TO COMANDO. */
            _.Move("SELECT V0OPCAOPAGVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1945- MOVE 07 TO W01-I */
            _.Move(07, FILLER_11.W01_I);

            /*" -1947- MOVE 'SELECT V0OPCAOPAGVA' TO W01-TEXTO(W01-I) */
            _.Move("SELECT V0OPCAOPAGVA", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -1951- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -1962- PERFORM R0020_00_PROCESSA_DB_SELECT_3 */

            R0020_00_PROCESSA_DB_SELECT_3();

            /*" -1966- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -1972- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -1973- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1975- DISPLAY 'VA0813B - PROBLEMAS NO ACESSO A V0OPCAOPAGVA' V0HCTA-NRCERTIF ' ' V0HCTA-NRPARCEL */

                $"VA0813B - PROBLEMAS NO ACESSO A V0OPCAOPAGVA{V0HCTA_NRCERTIF} {V0HCTA_NRPARCEL}"
                .Display();

                /*" -1977- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1979- MOVE 0 TO V0HCTA-OCORHISTCOB. */
            _.Move(0, V0HCTA_OCORHISTCOB);

            /*" -1984- MOVE 'SELECT V0PROPOSTAVA' TO COMANDO. */
            _.Move("SELECT V0PROPOSTAVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1985- MOVE 08 TO W01-I */
            _.Move(08, FILLER_11.W01_I);

            /*" -1987- MOVE 'SELECT V0PROPOSTAVA' TO W01-TEXTO(W01-I) */
            _.Move("SELECT V0PROPOSTAVA", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -1991- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -2044- PERFORM R0020_00_PROCESSA_DB_SELECT_4 */

            R0020_00_PROCESSA_DB_SELECT_4();

            /*" -2048- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -2052- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -2053- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2055- DISPLAY 'VA0813B - PROBLEMAS NO ACESSO A V0PROPOSTAVA' V0HCTA-NRCERTIF ' ' V0HCTA-NRPARCEL */

                $"VA0813B - PROBLEMAS NO ACESSO A V0PROPOSTAVA{V0HCTA_NRCERTIF} {V0HCTA_NRPARCEL}"
                .Display();

                /*" -2064- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2065- MOVE 'N' TO WS-PROD-BALCAO */
            _.Move("N", WORK_AREA.WS_PROD_BALCAO);

            /*" -2075- IF V0PROP-CODPRODU EQUAL 9314 OR 9353 OR 9352 OR 9351 OR 9320 OR 9321 OR 9332 OR 9359 OR 9360 OR 9361 OR 9327 OR 9328 OR 9334 OR 9356 OR 9357 OR 9358 OR 9329 OR JVPROD(9314) OR JVPROD(9353) OR JVPROD(9352) OR JVPROD(9351) OR JVPROD(9320) OR JVPROD(9321) OR JVPROD(9332) OR JVPROD(9359) OR JVPROD(9360) OR JVPROD(9361) OR JVPROD(9327) OR JVPROD(9328) OR JVPROD(9334) OR JVPROD(9356) OR JVPROD(9357) OR JVPROD(9358) OR JVPROD(9329) */

            if (V0PROP_CODPRODU.In("9314", "9353", "9352", "9351", "9320", "9321", "9332", "9359", "9360", "9361", "9327", "9328", "9334", "9356", "9357", "9358", "9329", JVBKINCL.FILLER.JVPROD[9314].ToString(), JVBKINCL.FILLER.JVPROD[9353].ToString(), JVBKINCL.FILLER.JVPROD[9352].ToString(), JVBKINCL.FILLER.JVPROD[9351].ToString(), JVBKINCL.FILLER.JVPROD[9320].ToString(), JVBKINCL.FILLER.JVPROD[9321].ToString(), JVBKINCL.FILLER.JVPROD[9332].ToString(), JVBKINCL.FILLER.JVPROD[9359].ToString(), JVBKINCL.FILLER.JVPROD[9360].ToString(), JVBKINCL.FILLER.JVPROD[9361].ToString(), JVBKINCL.FILLER.JVPROD[9327].ToString(), JVBKINCL.FILLER.JVPROD[9328].ToString(), JVBKINCL.FILLER.JVPROD[9334].ToString(), JVBKINCL.FILLER.JVPROD[9356].ToString(), JVBKINCL.FILLER.JVPROD[9357].ToString(), JVBKINCL.FILLER.JVPROD[9358].ToString(), JVBKINCL.FILLER.JVPROD[9329].ToString()))
            {

                /*" -2076- MOVE 'S' TO WS-PROD-BALCAO */
                _.Move("S", WORK_AREA.WS_PROD_BALCAO);

                /*" -2080- END-IF */
            }


            /*" -2081- IF V0PROP-INRMATRFUN LESS 0 */

            if (V0PROP_INRMATRFUN < 0)
            {

                /*" -2083- MOVE 0 TO V0PROP-NRMATRFUN. */
                _.Move(0, V0PROP_NRMATRFUN);
            }


            /*" -2084- IF VIND-TEM-SAF LESS 0 */

            if (VIND_TEM_SAF < 0)
            {

                /*" -2086- MOVE 'N' TO V0PRVG-TEM-SAF. */
                _.Move("N", V0PRVG_TEM_SAF);
            }


            /*" -2087- IF VIND-TEM-CDG LESS 0 */

            if (VIND_TEM_CDG < 0)
            {

                /*" -2089- MOVE 'N' TO V0PRVG-TEM-CDG. */
                _.Move("N", V0PRVG_TEM_CDG);
            }


            /*" -2090- IF VIND-RISCO LESS 0 */

            if (VIND_RISCO < 0)
            {

                /*" -2095- MOVE '1' TO V0PRVG-RISCO. */
                _.Move("1", V0PRVG_RISCO);
            }


            /*" -2098- MOVE 'SELECT FIDELIZ' TO COMANDO. */
            _.Move("SELECT FIDELIZ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -2104- MOVE ZEROS TO WHOST-ORIGEM-PROPOSTA. */
            _.Move(0, WHOST_ORIGEM_PROPOSTA);

            /*" -2105- MOVE 09 TO W01-I */
            _.Move(09, FILLER_11.W01_I);

            /*" -2107- MOVE 'SELECT PROPOSTA_FIDELIZ' TO W01-TEXTO(W01-I) */
            _.Move("SELECT PROPOSTA_FIDELIZ", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -2111- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -2125- PERFORM R0020_00_PROCESSA_DB_SELECT_5 */

            R0020_00_PROCESSA_DB_SELECT_5();

            /*" -2129- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -2135- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -2136- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2137- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2138- MOVE ZEROS TO WHOST-ORIGEM-PROPOSTA */
                    _.Move(0, WHOST_ORIGEM_PROPOSTA);

                    /*" -2139- ELSE */
                }
                else
                {


                    /*" -2141- DISPLAY 'VA0813B - PROBLEMAS NO ACESSO A PROPFIDELIZ' V0HCTA-NRCERTIF ' ' V0HCTA-NRPARCEL */

                    $"VA0813B - PROBLEMAS NO ACESSO A PROPFIDELIZ{V0HCTA_NRCERTIF} {V0HCTA_NRPARCEL}"
                    .Display();

                    /*" -2142- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2143- END-IF */
                }


                /*" -2145- END-IF. */
            }


            /*" -2150- DISPLAY 'CERTIFICADO = ' V0HCTA-NRCERTIF ' PARCELA ' V0HCTA-NRPARCEL ' V0HCOB-SITUACAO = ' V0HCOB-SITUACAO ' V0HCTA-SITUACAO = ' V0HCTA-SITUACAO ' RF-COD-RETORNO = ' RF-COD-RETORNO ' RF-MOTI-COMPEN = ' RF-MOTI-COMPEN ' V0HCTA-CODRET = ' V0HCTA-CODRET */

            $"CERTIFICADO = {V0HCTA_NRCERTIF} PARCELA {V0HCTA_NRPARCEL} V0HCOB-SITUACAO = {V0HCOB_SITUACAO} V0HCTA-SITUACAO = {V0HCTA_SITUACAO} RF-COD-RETORNO = {RET_CADASTRAMENTO.RF_COD_RETORNO} RF-MOTI-COMPEN = {RET_CADASTRAMENTO.RF_MOTI_COMPEN} V0HCTA-CODRET = {V0HCTA_CODRET}"
            .Display();

            /*" -2151- IF (RF-COD-RETORNO EQUAL 00) */

            if ((RET_CADASTRAMENTO.RF_COD_RETORNO == 00))
            {

                /*" -2152- PERFORM R1000-00-QUITA-PARCELA */

                R1000_00_QUITA_PARCELA_SECTION();

                /*" -2153- ELSE */
            }
            else
            {


                /*" -2154- PERFORM R2000-00-REJEITA-PARCELA */

                R2000_00_REJEITA_PARCELA_SECTION();

                /*" -2156- END-IF. */
            }


            /*" -2157- IF (RF-COD-RETORNO EQUAL 97 OR 98 OR 99) */

            if ((RET_CADASTRAMENTO.RF_COD_RETORNO.In("97", "98", "99")))
            {

                /*" -2162- PERFORM R0023-00-ATUALIZA-ESTORNO */

                R0023_00_ATUALIZA_ESTORNO_SECTION();

                /*" -2163- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2167- MOVE 'UPDATE V0HISTCONTAVA 01' TO COMANDO */
                    _.Move("UPDATE V0HISTCONTAVA 01", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

                    /*" -2168- MOVE 10 TO W01-I */
                    _.Move(10, FILLER_11.W01_I);

                    /*" -2170- MOVE 'UPDATE V0HISTCONTAVA' TO W01-TEXTO(W01-I) */
                    _.Move("UPDATE V0HISTCONTAVA", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

                    /*" -2174- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

                    R8900_TOTALIZA_INICIO_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


                    /*" -2185- PERFORM R0020_00_PROCESSA_DB_UPDATE_1 */

                    R0020_00_PROCESSA_DB_UPDATE_1();

                    /*" -2189- MOVE 1 TO W01-QTD-ACC-OK */
                    _.Move(1, FILLER_11.W01_QTD_ACC_OK);

                    /*" -2193- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

                    R8910_TOTALIZA_FINAL_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


                    /*" -2194- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -2196- DISPLAY 'VA0813B - PROBLEMAS NO UPDATE01 V0HISTCONTAVA' V0HCTA-NRCERTIF ' ' V0HCTA-NRPARCEL */

                        $"VA0813B - PROBLEMAS NO UPDATE01 V0HISTCONTAVA{V0HCTA_NRCERTIF} {V0HCTA_NRPARCEL}"
                        .Display();

                        /*" -2197- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -2198- END-IF */
                    }


                    /*" -2199- END-IF */
                }


                /*" -2200- ELSE */
            }
            else
            {


                /*" -2201- MOVE 'UPDATE V0HISTCONTAVA 02' TO COMANDO */
                _.Move("UPDATE V0HISTCONTAVA 02", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

                /*" -2202- DISPLAY COMANDO */
                _.Display(WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

                /*" -2208- DISPLAY ' V0HCOB-SITUACAO = ' V0HCOB-SITUACAO ' V0HCTA-SITUACAO = ' V0HCTA-SITUACAO ' RF-COD-RETORNO = ' RF-COD-RETORNO ' RF-MOTI-COMPEN = ' RF-MOTI-COMPEN ' V0HCTA-CODRET = ' V0HCTA-CODRET */

                $" V0HCOB-SITUACAO = {V0HCOB_SITUACAO} V0HCTA-SITUACAO = {V0HCTA_SITUACAO} RF-COD-RETORNO = {RET_CADASTRAMENTO.RF_COD_RETORNO} RF-MOTI-COMPEN = {RET_CADASTRAMENTO.RF_MOTI_COMPEN} V0HCTA-CODRET = {V0HCTA_CODRET}"
                .Display();

                /*" -2209- MOVE 11 TO W01-I */
                _.Move(11, FILLER_11.W01_I);

                /*" -2211- MOVE 'UPDATE V0HISTCONTAVA' TO W01-TEXTO(W01-I) */
                _.Move("UPDATE V0HISTCONTAVA", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

                /*" -2215- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

                R8900_TOTALIZA_INICIO_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


                /*" -2226- PERFORM R0020_00_PROCESSA_DB_UPDATE_2 */

                R0020_00_PROCESSA_DB_UPDATE_2();

                /*" -2230- MOVE 1 TO W01-QTD-ACC-OK */
                _.Move(1, FILLER_11.W01_QTD_ACC_OK);

                /*" -2234- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

                R8910_TOTALIZA_FINAL_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


                /*" -2235- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2237- DISPLAY 'VA0813B - PROBLEMAS NO UPDATE02 V0HISTCONTAVA' V0HCTA-NRCERTIF ' ' V0HCTA-NRPARCEL */

                    $"VA0813B - PROBLEMAS NO UPDATE02 V0HISTCONTAVA{V0HCTA_NRCERTIF} {V0HCTA_NRPARCEL}"
                    .Display();

                    /*" -2239- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2245- MOVE 'UPDATE V0PARCELVA' TO COMANDO. */
            _.Move("UPDATE V0PARCELVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -2246- MOVE 12 TO W01-I */
            _.Move(12, FILLER_11.W01_I);

            /*" -2247- MOVE 'UPDATE V0PARCELVA' TO W01-TEXTO(W01-I) */
            _.Move("UPDATE V0PARCELVA", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -2251- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -2260- PERFORM R0020_00_PROCESSA_DB_UPDATE_3 */

            R0020_00_PROCESSA_DB_UPDATE_3();

            /*" -2264- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -2268- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -2269- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2271- DISPLAY 'VA0813B - PROBLEMAS NO UPDATE   V0PARCELVA   ' V0HCTA-NRCERTIF ' ' V0HCTA-NRPARCEL */

                $"VA0813B - PROBLEMAS NO UPDATE   V0PARCELVA   {V0HCTA_NRCERTIF} {V0HCTA_NRPARCEL}"
                .Display();

                /*" -2272- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2274- END-IF */
            }


            /*" -2278- MOVE 'UPDATE V0HISTCOBVA 3' TO COMANDO. */
            _.Move("UPDATE V0HISTCOBVA 3", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -2279- MOVE 54 TO W01-I */
            _.Move(54, FILLER_11.W01_I);

            /*" -2280- MOVE 'UPDATE V0HISTCOBVA 3' TO W01-TEXTO(W01-I) */
            _.Move("UPDATE V0HISTCOBVA 3", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -2284- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -2295- PERFORM R0020_00_PROCESSA_DB_UPDATE_4 */

            R0020_00_PROCESSA_DB_UPDATE_4();

            /*" -2299- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -2303- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -2304- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2308- DISPLAY 'VA0813B - ERRO NO UPDATE 3 V0HISTCOBVA  ' V0HCTA-NRCERTIF ' ' V0HCTA-NRPARCEL ' ' V0HCOB-NRTIT */

                $"VA0813B - ERRO NO UPDATE 3 V0HISTCOBVA  {V0HCTA_NRCERTIF} {V0HCTA_NRPARCEL} {V0HCOB_NRTIT}"
                .Display();

                /*" -2309- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2311- END-IF */
            }


            /*" -2313- ADD 1 TO WS-REGISTROS. */
            WORK_AREA.WS_REGISTROS.Value = WORK_AREA.WS_REGISTROS + 1;

            /*" -2314- MOVE RF-IDENTIF-CLI TO VGFOLLOW-NUM-CERTIFICADO. */
            _.Move(RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_IDENTIF_CLI, VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_CERTIFICADO);

            /*" -2315- MOVE RF-IDENTIF-NSA TO VGFOLLOW-NUM-NOSSA-FITA. */
            _.Move(RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_IDENTIF_NSA, VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_NOSSA_FITA);

            /*" -2317- MOVE RF-NSL TO VGFOLLOW-NUM-LANCAMENTO. */
            _.Move(RET_CADASTRAMENTO.RF_USO_EMPRESA.RF_NSL, VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_LANCAMENTO);

            /*" -2317- PERFORM R8800-00-UPDATE-FOLLOWUP. */

            R8800_00_UPDATE_FOLLOWUP_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0020_00_NEXT */

            R0020_00_NEXT();

        }

        [StopWatch]
        /*" R0020-00-PROCESSA-DB-SELECT-1 */
        public void R0020_00_PROCESSA_DB_SELECT_1()
        {
            /*" -1873- EXEC SQL SELECT PRMVG, PRMAP, PRMVG + PRMAP, OPCAOOPAG, DTVENCTO INTO :V0PARC-PRMVG, :V0PARC-PRMAP, :V0PARC-PRMTOT, :V0PARC-OPCAOPAG, :V0PARC-DTVENCTO FROM SEGUROS.V0PARCELVA WHERE NRCERTIF = :V0HCTA-NRCERTIF AND NRPARCEL = :V0HCTA-NRPARCEL WITH UR END-EXEC. */

            var r0020_00_PROCESSA_DB_SELECT_1_Query1 = new R0020_00_PROCESSA_DB_SELECT_1_Query1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0HCTA_NRPARCEL = V0HCTA_NRPARCEL.ToString(),
            };

            var executed_1 = R0020_00_PROCESSA_DB_SELECT_1_Query1.Execute(r0020_00_PROCESSA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PARC_PRMVG, V0PARC_PRMVG);
                _.Move(executed_1.V0PARC_PRMAP, V0PARC_PRMAP);
                _.Move(executed_1.V0PARC_PRMTOT, V0PARC_PRMTOT);
                _.Move(executed_1.V0PARC_OPCAOPAG, V0PARC_OPCAOPAG);
                _.Move(executed_1.V0PARC_DTVENCTO, V0PARC_DTVENCTO);
            }


        }

        [StopWatch]
        /*" R0020-00-NEXT */
        private void R0020_00_NEXT(bool isPerform = false)
        {
            /*" -2321- READ RETDEB AT END */
            try
            {
                RETDEB.Read(() =>
                {

                    /*" -2321- MOVE 1 TO WS-EOF. */
                    _.Move(1, WORK_AREA.WS_EOF);
                });

                _.Move(RETDEB.Value, RETDEB_RECORD);
                _.Move(RETDEB.Value, RET_HEADER);
                _.Move(RETDEB.Value, RET_CADASTRAMENTO);
                _.Move(RETDEB.Value, RET_TRAILLER);

            }
            catch (GoToException ex)
            {
                return;
            }
        }

        [StopWatch]
        /*" R0020-00-PROCESSA-DB-SELECT-2 */
        public void R0020_00_PROCESSA_DB_SELECT_2()
        {
            /*" -1919- EXEC SQL SELECT NRTIT, OCORHIST, DTVENCTO, SITUACAO, VLPRMTOT, OPCAOPAG, DTVENCTO - 1 DAY INTO :V0HCOB-NRTIT, :V0HCOB-OCORHIST, :V0HCOB-DTVENCTO, :V0HCOB-SITUACAO, :V0HCOB-VLPRMTOT, :V0HCOB-OPCAOPAG, :V0HCOB-DTALTOPC FROM SEGUROS.V0HISTCOBVA WHERE NRCERTIF = :V0HCTA-NRCERTIF AND NRPARCEL = :V0HCTA-NRPARCEL WITH UR END-EXEC. */

            var r0020_00_PROCESSA_DB_SELECT_2_Query1 = new R0020_00_PROCESSA_DB_SELECT_2_Query1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0HCTA_NRPARCEL = V0HCTA_NRPARCEL.ToString(),
            };

            var executed_1 = R0020_00_PROCESSA_DB_SELECT_2_Query1.Execute(r0020_00_PROCESSA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HCOB_NRTIT, V0HCOB_NRTIT);
                _.Move(executed_1.V0HCOB_OCORHIST, V0HCOB_OCORHIST);
                _.Move(executed_1.V0HCOB_DTVENCTO, V0HCOB_DTVENCTO);
                _.Move(executed_1.V0HCOB_SITUACAO, V0HCOB_SITUACAO);
                _.Move(executed_1.V0HCOB_VLPRMTOT, V0HCOB_VLPRMTOT);
                _.Move(executed_1.V0HCOB_OPCAOPAG, V0HCOB_OPCAOPAG);
                _.Move(executed_1.V0HCOB_DTALTOPC, V0HCOB_DTALTOPC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_99_SAIDA*/

        [StopWatch]
        /*" R0020-00-PROCESSA-DB-SELECT-3 */
        public void R0020_00_PROCESSA_DB_SELECT_3()
        {
            /*" -1962- EXEC SQL SELECT PERIPGTO, DIA_DEBITO, OPCAOPAG INTO :V0OPCP-PERIPGTO, :V0OPCP-DIADEB, :V0OPCP-OPCAOPAG FROM SEGUROS.V0OPCAOPAGVA WHERE NRCERTIF = :V0HCTA-NRCERTIF AND DTTERVIG = '9999-12-31' WITH UR END-EXEC. */

            var r0020_00_PROCESSA_DB_SELECT_3_Query1 = new R0020_00_PROCESSA_DB_SELECT_3_Query1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
            };

            var executed_1 = R0020_00_PROCESSA_DB_SELECT_3_Query1.Execute(r0020_00_PROCESSA_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0OPCP_PERIPGTO, V0OPCP_PERIPGTO);
                _.Move(executed_1.V0OPCP_DIADEB, V0OPCP_DIADEB);
                _.Move(executed_1.V0OPCP_OPCAOPAG, V0OPCP_OPCAOPAG);
            }


        }

        [StopWatch]
        /*" R0020-00-PROCESSA-DB-UPDATE-1 */
        public void R0020_00_PROCESSA_DB_UPDATE_1()
        {
            /*" -2185- EXEC SQL UPDATE SEGUROS.V0HISTCONTAVA SET SITUACAO = :V0HCTA-SITUACAO, NSAC = :V0FTCF-NSAC, CODRET = :V0HCTA-CODRET, OCORHIST = :V0HCTA-OCORHISTCOB, CODUSU = 'VA0813B' , TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :V0HCTA-NRCERTIF AND NRPARCEL = :V0HCTA-NRPARCEL AND OCORRHISTCTA = :V0HCTA-OCORHISTCTA END-EXEC */

            var r0020_00_PROCESSA_DB_UPDATE_1_Update1 = new R0020_00_PROCESSA_DB_UPDATE_1_Update1()
            {
                V0HCTA_OCORHISTCOB = V0HCTA_OCORHISTCOB.ToString(),
                V0HCTA_SITUACAO = V0HCTA_SITUACAO.ToString(),
                V0HCTA_CODRET = V0HCTA_CODRET.ToString(),
                V0FTCF_NSAC = V0FTCF_NSAC.ToString(),
                V0HCTA_OCORHISTCTA = V0HCTA_OCORHISTCTA.ToString(),
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0HCTA_NRPARCEL = V0HCTA_NRPARCEL.ToString(),
            };

            R0020_00_PROCESSA_DB_UPDATE_1_Update1.Execute(r0020_00_PROCESSA_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R0023-00-ATUALIZA-ESTORNO-SECTION */
        private void R0023_00_ATUALIZA_ESTORNO_SECTION()
        {
            /*" -2331- IF RF-COD-RETORNO EQUAL 97 OR 98 */

            if (RET_CADASTRAMENTO.RF_COD_RETORNO.In("97", "98"))
            {

                /*" -2332- MOVE '8' TO WHOST-SITUACAO */
                _.Move("8", WHOST_SITUACAO);

                /*" -2333- ELSE */
            }
            else
            {


                /*" -2335- MOVE '7' TO WHOST-SITUACAO. */
                _.Move("7", WHOST_SITUACAO);
            }


            /*" -2341- MOVE 'UPDATE V0HISTCONTAVA 03' TO COMANDO */
            _.Move("UPDATE V0HISTCONTAVA 03", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -2342- MOVE 13 TO W01-I */
            _.Move(13, FILLER_11.W01_I);

            /*" -2344- MOVE 'UPDATE V0HISTCONTAVA' TO W01-TEXTO(W01-I) */
            _.Move("UPDATE V0HISTCONTAVA", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -2348- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -2360- PERFORM R0023_00_ATUALIZA_ESTORNO_DB_UPDATE_1 */

            R0023_00_ATUALIZA_ESTORNO_DB_UPDATE_1();

            /*" -2364- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -2370- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -2371- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2372- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -2374- DISPLAY 'VA0813B - PROBLEMAS NO UPDATE03 V0HISTCONTAVA' V0HCTA-NRCERTIF ' ' V0HCTA-NRPARCEL */

                    $"VA0813B - PROBLEMAS NO UPDATE03 V0HISTCONTAVA{V0HCTA_NRCERTIF} {V0HCTA_NRPARCEL}"
                    .Display();

                    /*" -2374- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0023-00-ATUALIZA-ESTORNO-DB-UPDATE-1 */
        public void R0023_00_ATUALIZA_ESTORNO_DB_UPDATE_1()
        {
            /*" -2360- EXEC SQL UPDATE SEGUROS.V0HISTCONTAVA SET SITUACAO = :WHOST-SITUACAO, NSAC = :V0FTCF-NSAC, CODRET = :V0HCTA-CODRET, OCORHIST = :V0HCTA-OCORHISTCOB, TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :V0HCTA-NRCERTIF AND NRPARCEL = :V0HCTA-NRPARCEL AND OCORRHISTCTA >= 0 AND NSAC IS NULL END-EXEC. */

            var r0023_00_ATUALIZA_ESTORNO_DB_UPDATE_1_Update1 = new R0023_00_ATUALIZA_ESTORNO_DB_UPDATE_1_Update1()
            {
                V0HCTA_OCORHISTCOB = V0HCTA_OCORHISTCOB.ToString(),
                WHOST_SITUACAO = WHOST_SITUACAO.ToString(),
                V0HCTA_CODRET = V0HCTA_CODRET.ToString(),
                V0FTCF_NSAC = V0FTCF_NSAC.ToString(),
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0HCTA_NRPARCEL = V0HCTA_NRPARCEL.ToString(),
            };

            R0023_00_ATUALIZA_ESTORNO_DB_UPDATE_1_Update1.Execute(r0023_00_ATUALIZA_ESTORNO_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R0020-00-PROCESSA-DB-UPDATE-2 */
        public void R0020_00_PROCESSA_DB_UPDATE_2()
        {
            /*" -2226- EXEC SQL UPDATE SEGUROS.V0HISTCONTAVA SET SITUACAO = :V0HCTA-SITUACAO, NSAC = :V0FTCF-NSAC, CODRET = :V0HCTA-CODRET, OCORHIST = :V0HCTA-OCORHISTCOB, CODUSU = 'VA0813B' , TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :V0HCTA-NRCERTIF AND NRPARCEL = :V0HCTA-NRPARCEL AND OCORRHISTCTA = :V0HCTA-OCORHISTCTA END-EXEC */

            var r0020_00_PROCESSA_DB_UPDATE_2_Update1 = new R0020_00_PROCESSA_DB_UPDATE_2_Update1()
            {
                V0HCTA_OCORHISTCOB = V0HCTA_OCORHISTCOB.ToString(),
                V0HCTA_SITUACAO = V0HCTA_SITUACAO.ToString(),
                V0HCTA_CODRET = V0HCTA_CODRET.ToString(),
                V0FTCF_NSAC = V0FTCF_NSAC.ToString(),
                V0HCTA_OCORHISTCTA = V0HCTA_OCORHISTCTA.ToString(),
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0HCTA_NRPARCEL = V0HCTA_NRPARCEL.ToString(),
            };

            R0020_00_PROCESSA_DB_UPDATE_2_Update1.Execute(r0020_00_PROCESSA_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R0020-00-PROCESSA-DB-SELECT-4 */
        public void R0020_00_PROCESSA_DB_SELECT_4()
        {
            /*" -2044- EXEC SQL SELECT A.CODCLIEN, A.NUM_APOLICE, A.CODSUBES, A.FONTE, A.DTQITBCO, A.AGECOBR, A.OPCAO_COBER, A.DTVENCTO, A.OCORHIST, A.QTDPARATZ, A.SITUACAO, A.NUM_MATRICULA, A.CODPRODU, A.NRPARCE, B.TEM_SAF, B.TEM_CDG, B.RISCO, B.OPCAOPAG, B.CUSTOCAP_TOTAL, VALUE(B.ORIG_PRODU, ' ' ), C.RAMO, C.MODALIDA INTO :V0PROP-CODCLIEN, :V0PROP-NUM-APOLICE, :V0PROP-CODSUBES, :V0PROP-FONTE, :V0PROP-DTQITBCO, :V0PROP-AGECOBR, :V0PROP-OPCAO-COBER, :V0PROP-DTVENCTO, :V0PROP-OCORHIST, :V0PROP-QTDPARATZ, :V0PROP-SITUACAO, :V0PROP-NRMATRFUN:V0PROP-INRMATRFUN, :V0PROP-CODPRODU, :V0PROP-NRPARCE, :V0PRVG-TEM-SAF:VIND-TEM-SAF, :V0PRVG-TEM-CDG:VIND-TEM-CDG, :V0PRVG-RISCO:VIND-RISCO, :V0PRVG-OPCAOPAG, :V0PRVG-CUSTOCAP-TOTAL, :V0PRVG-ORIG-PRODU, :V0PRVG-RAMO, :V0APOL-MODALIDA FROM SEGUROS.V0PROPOSTAVA A, SEGUROS.V0PRODUTOSVG B, SEGUROS.V0APOLICE C WHERE A.NRCERTIF = :V0HCTA-NRCERTIF AND B.NUM_APOLICE = A.NUM_APOLICE AND B.CODSUBES = A.CODSUBES AND B.NUM_APOLICE = C.NUM_APOLICE WITH UR END-EXEC. */

            var r0020_00_PROCESSA_DB_SELECT_4_Query1 = new R0020_00_PROCESSA_DB_SELECT_4_Query1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
            };

            var executed_1 = R0020_00_PROCESSA_DB_SELECT_4_Query1.Execute(r0020_00_PROCESSA_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PROP_CODCLIEN, V0PROP_CODCLIEN);
                _.Move(executed_1.V0PROP_NUM_APOLICE, V0PROP_NUM_APOLICE);
                _.Move(executed_1.V0PROP_CODSUBES, V0PROP_CODSUBES);
                _.Move(executed_1.V0PROP_FONTE, V0PROP_FONTE);
                _.Move(executed_1.V0PROP_DTQITBCO, V0PROP_DTQITBCO);
                _.Move(executed_1.V0PROP_AGECOBR, V0PROP_AGECOBR);
                _.Move(executed_1.V0PROP_OPCAO_COBER, V0PROP_OPCAO_COBER);
                _.Move(executed_1.V0PROP_DTVENCTO, V0PROP_DTVENCTO);
                _.Move(executed_1.V0PROP_OCORHIST, V0PROP_OCORHIST);
                _.Move(executed_1.V0PROP_QTDPARATZ, V0PROP_QTDPARATZ);
                _.Move(executed_1.V0PROP_SITUACAO, V0PROP_SITUACAO);
                _.Move(executed_1.V0PROP_NRMATRFUN, V0PROP_NRMATRFUN);
                _.Move(executed_1.V0PROP_INRMATRFUN, V0PROP_INRMATRFUN);
                _.Move(executed_1.V0PROP_CODPRODU, V0PROP_CODPRODU);
                _.Move(executed_1.V0PROP_NRPARCE, V0PROP_NRPARCE);
                _.Move(executed_1.V0PRVG_TEM_SAF, V0PRVG_TEM_SAF);
                _.Move(executed_1.VIND_TEM_SAF, VIND_TEM_SAF);
                _.Move(executed_1.V0PRVG_TEM_CDG, V0PRVG_TEM_CDG);
                _.Move(executed_1.VIND_TEM_CDG, VIND_TEM_CDG);
                _.Move(executed_1.V0PRVG_RISCO, V0PRVG_RISCO);
                _.Move(executed_1.VIND_RISCO, VIND_RISCO);
                _.Move(executed_1.V0PRVG_OPCAOPAG, V0PRVG_OPCAOPAG);
                _.Move(executed_1.V0PRVG_CUSTOCAP_TOTAL, V0PRVG_CUSTOCAP_TOTAL);
                _.Move(executed_1.V0PRVG_ORIG_PRODU, V0PRVG_ORIG_PRODU);
                _.Move(executed_1.V0PRVG_RAMO, V0PRVG_RAMO);
                _.Move(executed_1.V0APOL_MODALIDA, V0APOL_MODALIDA);
            }


        }

        [StopWatch]
        /*" R0020-00-PROCESSA-DB-UPDATE-3 */
        public void R0020_00_PROCESSA_DB_UPDATE_3()
        {
            /*" -2260- EXEC SQL UPDATE SEGUROS.V0PARCELVA SET SITUACAO = :V0HCTA-SITUACAO, PRMVG = :V0PARC-PRMVG, PRMAP = :V0PARC-PRMAP, OPCAOOPAG = :V0PARC-OPCAOPAG WHERE NRCERTIF = :V0HCTA-NRCERTIF AND NRPARCEL = :V0HCTA-NRPARCEL END-EXEC. */

            var r0020_00_PROCESSA_DB_UPDATE_3_Update1 = new R0020_00_PROCESSA_DB_UPDATE_3_Update1()
            {
                V0HCTA_SITUACAO = V0HCTA_SITUACAO.ToString(),
                V0PARC_OPCAOPAG = V0PARC_OPCAOPAG.ToString(),
                V0PARC_PRMVG = V0PARC_PRMVG.ToString(),
                V0PARC_PRMAP = V0PARC_PRMAP.ToString(),
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0HCTA_NRPARCEL = V0HCTA_NRPARCEL.ToString(),
            };

            R0020_00_PROCESSA_DB_UPDATE_3_Update1.Execute(r0020_00_PROCESSA_DB_UPDATE_3_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0023_99_SAIDA*/

        [StopWatch]
        /*" R0020-00-PROCESSA-DB-UPDATE-4 */
        public void R0020_00_PROCESSA_DB_UPDATE_4()
        {
            /*" -2295- EXEC SQL UPDATE SEGUROS.V0HISTCOBVA SET SITUACAO = :V0HCTA-SITUACAO, VLPRMTOT = :V0HCTA-VLPRMTOT, OCORHIST = :V0HCOB-OCORHIST, BCOAVISO = :V0AVIS-BCOAVISO, AGEAVISO = :V0AVIS-AGEAVISO, NRAVISO = :V0AVIS-NRAVISO WHERE NRCERTIF = :V0HCTA-NRCERTIF AND NRPARCEL = :V0HCTA-NRPARCEL AND NRTIT = :V0HCOB-NRTIT END-EXEC */

            var r0020_00_PROCESSA_DB_UPDATE_4_Update1 = new R0020_00_PROCESSA_DB_UPDATE_4_Update1()
            {
                V0HCTA_SITUACAO = V0HCTA_SITUACAO.ToString(),
                V0HCTA_VLPRMTOT = V0HCTA_VLPRMTOT.ToString(),
                V0HCOB_OCORHIST = V0HCOB_OCORHIST.ToString(),
                V0AVIS_BCOAVISO = V0AVIS_BCOAVISO.ToString(),
                V0AVIS_AGEAVISO = V0AVIS_AGEAVISO.ToString(),
                V0AVIS_NRAVISO = V0AVIS_NRAVISO.ToString(),
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0HCTA_NRPARCEL = V0HCTA_NRPARCEL.ToString(),
                V0HCOB_NRTIT = V0HCOB_NRTIT.ToString(),
            };

            R0020_00_PROCESSA_DB_UPDATE_4_Update1.Execute(r0020_00_PROCESSA_DB_UPDATE_4_Update1);

        }

        [StopWatch]
        /*" R0020-00-PROCESSA-DB-SELECT-5 */
        public void R0020_00_PROCESSA_DB_SELECT_5()
        {
            /*" -2125- EXEC SQL SELECT ORIGEM_PROPOSTA, AGECTADEB, OPRCTADEB, NUMCTADEB, DIGCTADEB INTO :WHOST-ORIGEM-PROPOSTA, :WHOST-AGECTADEB-FID, :WHOST-OPRCTADEB-FID, :WHOST-NUMCTADEB-FID, :WHOST-DIGCTADEB-FID FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_PROPOSTA_SIVPF = :V0HCTA-NRCERTIF WITH UR END-EXEC. */

            var r0020_00_PROCESSA_DB_SELECT_5_Query1 = new R0020_00_PROCESSA_DB_SELECT_5_Query1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
            };

            var executed_1 = R0020_00_PROCESSA_DB_SELECT_5_Query1.Execute(r0020_00_PROCESSA_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_ORIGEM_PROPOSTA, WHOST_ORIGEM_PROPOSTA);
                _.Move(executed_1.WHOST_AGECTADEB_FID, WHOST_AGECTADEB_FID);
                _.Move(executed_1.WHOST_OPRCTADEB_FID, WHOST_OPRCTADEB_FID);
                _.Move(executed_1.WHOST_NUMCTADEB_FID, WHOST_NUMCTADEB_FID);
                _.Move(executed_1.WHOST_DIGCTADEB_FID, WHOST_DIGCTADEB_FID);
            }


        }

        [StopWatch]
        /*" R0030-00-ACESSO-CERTIF-SECTION */
        private void R0030_00_ACESSO_CERTIF_SECTION()
        {
            /*" -2384- MOVE 'R0030-00-ACESSO-CERTIF' TO PARAGRAFO. */
            _.Move("R0030-00-ACESSO-CERTIF", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2387- MOVE 'SELECT MIN V0HISTCONTAVA' TO COMANDO. */
            _.Move("SELECT MIN V0HISTCONTAVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -2388- MOVE RF-IDENTIF-CLI TO V0HCTA-NRCERTIF. */
            _.Move(RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_IDENTIF_CLI, V0HCTA_NRCERTIF);

            /*" -2389- MOVE RF-VLPRMTOT TO V0HCTA-VLPRMTOT. */
            _.Move(RET_CADASTRAMENTO.RF_VLPRMTOT, V0HCTA_VLPRMTOT);

            /*" -2390- MOVE RF-AGECTADEB TO V0HCTA-AGECTADEB. */
            _.Move(RET_CADASTRAMENTO.RF_AGECTADEB, V0HCTA_AGECTADEB);

            /*" -2391- MOVE RF-COD-OPRCTADEB TO V0HCTA-OPRCTADEB. */
            _.Move(RET_CADASTRAMENTO.RF_IDENT_CLI_BANCO.RF_COD_OPRCTADEB, V0HCTA_OPRCTADEB);

            /*" -2394- MOVE RF-NUM-NUMCTADEB TO V0HCTA-NUMCTADEB. */
            _.Move(RET_CADASTRAMENTO.RF_IDENT_CLI_BANCO.RF_NUM_NUMCTADEB, V0HCTA_NUMCTADEB);

            /*" -2407- PERFORM R0030_00_ACESSO_CERTIF_DB_DECLARE_1 */

            R0030_00_ACESSO_CERTIF_DB_DECLARE_1();

            /*" -2412- MOVE 14 TO W01-I */
            _.Move(14, FILLER_11.W01_I);

            /*" -2413- MOVE 'OPEN CHCONTA2' TO W01-TEXTO(W01-I) */
            _.Move("OPEN CHCONTA2", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -2417- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -2417- PERFORM R0030_00_ACESSO_CERTIF_DB_OPEN_1 */

            R0030_00_ACESSO_CERTIF_DB_OPEN_1();

            /*" -2421- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -2426- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -2427- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2429- DISPLAY 'VA0813B - PROBLEMAS NO OPEN     CHCONTA2     ' V0HCTA-NRCERTIF ' ' V0HCTA-NRPARCEL */

                $"VA0813B - PROBLEMAS NO OPEN     CHCONTA2     {V0HCTA_NRCERTIF} {V0HCTA_NRPARCEL}"
                .Display();

                /*" -2435- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2436- MOVE 15 TO W01-I */
            _.Move(15, FILLER_11.W01_I);

            /*" -2437- MOVE 'FETCH CHCONTA2' TO W01-TEXTO(W01-I) */
            _.Move("FETCH CHCONTA2", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -2441- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -2447- PERFORM R0030_00_ACESSO_CERTIF_DB_FETCH_1 */

            R0030_00_ACESSO_CERTIF_DB_FETCH_1();

            /*" -2451- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -2457- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -2458- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2459- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2462- MOVE 'PARCELA NAO ENCONTRADA' TO RETERR-MENSAGEM */
                    _.Move("PARCELA NAO ENCONTRADA", RETERR_RECORD.RETERR_MENSAGEM);

                    /*" -2463- MOVE 16 TO W01-I */
                    _.Move(16, FILLER_11.W01_I);

                    /*" -2464- MOVE 'CLOSE CHCONTA2' TO W01-TEXTO(W01-I) */
                    _.Move("CLOSE CHCONTA2", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

                    /*" -2468- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

                    R8900_TOTALIZA_INICIO_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


                    /*" -2468- PERFORM R0030_00_ACESSO_CERTIF_DB_CLOSE_1 */

                    R0030_00_ACESSO_CERTIF_DB_CLOSE_1();

                    /*" -2472- MOVE 1 TO W01-QTD-ACC-OK */
                    _.Move(1, FILLER_11.W01_QTD_ACC_OK);

                    /*" -2476- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

                    R8910_TOTALIZA_FINAL_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


                    /*" -2477- MOVE 1 TO WS-NAO-ACHEI */
                    _.Move(1, WORK_AREA.WS_NAO_ACHEI);

                    /*" -2478- GO TO R0030-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0030_99_SAIDA*/ //GOTO
                    return;

                    /*" -2479- ELSE */
                }
                else
                {


                    /*" -2481- DISPLAY 'VA0813B - PROBLEMAS NO FETCH    CHCONTA2     ' V0HCTA-NRCERTIF ' ' V0HCTA-NRPARCEL */

                    $"VA0813B - PROBLEMAS NO FETCH    CHCONTA2     {V0HCTA_NRCERTIF} {V0HCTA_NRPARCEL}"
                    .Display();

                    /*" -2485- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2486- MOVE 17 TO W01-I */
            _.Move(17, FILLER_11.W01_I);

            /*" -2487- MOVE 'CLOSE CHCONTA2' TO W01-TEXTO(W01-I) */
            _.Move("CLOSE CHCONTA2", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -2491- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -2491- PERFORM R0030_00_ACESSO_CERTIF_DB_CLOSE_2 */

            R0030_00_ACESSO_CERTIF_DB_CLOSE_2();

            /*" -2495- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -2500- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -2501- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2503- DISPLAY 'VA0813B - PROBLEMAS NO CLOSE    CHCONTA2     ' V0HCTA-NRCERTIF ' ' V0HCTA-NRPARCEL */

                $"VA0813B - PROBLEMAS NO CLOSE    CHCONTA2     {V0HCTA_NRCERTIF} {V0HCTA_NRPARCEL}"
                .Display();

                /*" -2503- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0030-00-ACESSO-CERTIF-DB-DECLARE-1 */
        public void R0030_00_ACESSO_CERTIF_DB_DECLARE_1()
        {
            /*" -2407- EXEC SQL DECLARE CHCONTA2 CURSOR FOR SELECT NRCERTIF, NRPARCEL, OCORRHISTCTA, VALUE(NSAS, 0), VALUE(NSL, 0) FROM SEGUROS.V0HISTCONTAVA WHERE NRCERTIF = :V0HCTA-NRCERTIF AND TIPLANC = '1' AND SITUACAO = '3' ORDER BY NRCERTIF, NRPARCEL, OCORRHISTCTA WITH UR END-EXEC. */
            CHCONTA2 = new VA0813B_CHCONTA2(true);
            string GetQuery_CHCONTA2()
            {
                var query = @$"SELECT NRCERTIF
							, 
							NRPARCEL
							, 
							OCORRHISTCTA
							, 
							VALUE(NSAS
							, 0)
							, 
							VALUE(NSL
							, 0) 
							FROM SEGUROS.V0HISTCONTAVA 
							WHERE NRCERTIF = '{V0HCTA_NRCERTIF}' 
							AND TIPLANC = '1' 
							AND SITUACAO = '3' 
							ORDER BY NRCERTIF
							, NRPARCEL
							, OCORRHISTCTA";

                return query;
            }
            CHCONTA2.GetQueryEvent += GetQuery_CHCONTA2;

        }

        [StopWatch]
        /*" R0030-00-ACESSO-CERTIF-DB-OPEN-1 */
        public void R0030_00_ACESSO_CERTIF_DB_OPEN_1()
        {
            /*" -2417- EXEC SQL OPEN CHCONTA2 END-EXEC. */

            CHCONTA2.Open();

        }

        [StopWatch]
        /*" R0035-00-ACESSO-NUMCTADEB-DB-DECLARE-1 */
        public void R0035_00_ACESSO_NUMCTADEB_DB_DECLARE_1()
        {
            /*" -2562- EXEC SQL DECLARE CHCONTA3 CURSOR FOR SELECT NRCERTIF, NRPARCEL, OCORRHISTCTA FROM SEGUROS.V0HISTCONTAVA WHERE AGECTADEB = :V0HCTA-AGECTADEB AND OPRCTADEB = :V0HCTA-OPRCTADEB AND NUMCTADEB = :V0HCTA-NUMCTADEB AND CODCONV = :WHOST-CODCONV AND NSAS = :V0HCTA-NSAS AND VLPRMTOT = :V0HCTA-VLPRMTOT AND TIPLANC = '1' AND SITUACAO = '3' ORDER BY NRCERTIF, NRPARCEL, OCORRHISTCTA WITH UR END-EXEC. */
            CHCONTA3 = new VA0813B_CHCONTA3(true);
            string GetQuery_CHCONTA3()
            {
                var query = @$"SELECT NRCERTIF
							, 
							NRPARCEL
							, 
							OCORRHISTCTA 
							FROM SEGUROS.V0HISTCONTAVA 
							WHERE AGECTADEB = '{V0HCTA_AGECTADEB}' 
							AND OPRCTADEB = '{V0HCTA_OPRCTADEB}' 
							AND NUMCTADEB = '{V0HCTA_NUMCTADEB}' 
							AND CODCONV = '{WHOST_CODCONV}' 
							AND NSAS = '{V0HCTA_NSAS}' 
							AND VLPRMTOT = '{V0HCTA_VLPRMTOT}' 
							AND TIPLANC = '1' 
							AND SITUACAO = '3' 
							ORDER BY NRCERTIF
							, NRPARCEL
							, OCORRHISTCTA";

                return query;
            }
            CHCONTA3.GetQueryEvent += GetQuery_CHCONTA3;

        }

        [StopWatch]
        /*" R0030-00-ACESSO-CERTIF-DB-FETCH-1 */
        public void R0030_00_ACESSO_CERTIF_DB_FETCH_1()
        {
            /*" -2447- EXEC SQL FETCH CHCONTA2 INTO :V0HCTA-NRCERTIF, :V0HCTA-NRPARCEL, :V0HCTA-OCORHISTCTA, :V0HCTA-NSAS, :V0HCTA-NSL END-EXEC. */

            if (CHCONTA2.Fetch())
            {
                _.Move(CHCONTA2.V0HCTA_NRCERTIF, V0HCTA_NRCERTIF);
                _.Move(CHCONTA2.V0HCTA_NRPARCEL, V0HCTA_NRPARCEL);
                _.Move(CHCONTA2.V0HCTA_OCORHISTCTA, V0HCTA_OCORHISTCTA);
                _.Move(CHCONTA2.V0HCTA_NSAS, V0HCTA_NSAS);
                _.Move(CHCONTA2.V0HCTA_NSL, V0HCTA_NSL);
            }

        }

        [StopWatch]
        /*" R0030-00-ACESSO-CERTIF-DB-CLOSE-1 */
        public void R0030_00_ACESSO_CERTIF_DB_CLOSE_1()
        {
            /*" -2468- EXEC SQL CLOSE CHCONTA2 END-EXEC */

            CHCONTA2.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0030_99_SAIDA*/

        [StopWatch]
        /*" R0030-00-ACESSO-CERTIF-DB-CLOSE-2 */
        public void R0030_00_ACESSO_CERTIF_DB_CLOSE_2()
        {
            /*" -2491- EXEC SQL CLOSE CHCONTA2 END-EXEC. */

            CHCONTA2.Close();

        }

        [StopWatch]
        /*" R0035-00-ACESSO-NUMCTADEB-SECTION */
        private void R0035_00_ACESSO_NUMCTADEB_SECTION()
        {
            /*" -2512- MOVE 'R0035-00-ACESSO-NUMCTADEB' TO PARAGRAFO. */
            _.Move("R0035-00-ACESSO-NUMCTADEB", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2515- MOVE 'SELECT MIN V0HISTCONTAVA' TO COMANDO. */
            _.Move("SELECT MIN V0HISTCONTAVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -2516- MOVE RF-AGECTADEB TO V0HCTA-AGECTADEB. */
            _.Move(RET_CADASTRAMENTO.RF_AGECTADEB, V0HCTA_AGECTADEB);

            /*" -2517- MOVE RF-COD-OPRCTADEB TO V0HCTA-OPRCTADEB. */
            _.Move(RET_CADASTRAMENTO.RF_IDENT_CLI_BANCO.RF_COD_OPRCTADEB, V0HCTA_OPRCTADEB);

            /*" -2518- MOVE RF-NUM-NUMCTADEB TO V0HCTA-NUMCTADEB. */
            _.Move(RET_CADASTRAMENTO.RF_IDENT_CLI_BANCO.RF_NUM_NUMCTADEB, V0HCTA_NUMCTADEB);

            /*" -2520- MOVE RF-VLPRMTOT TO V0HCTA-VLPRMTOT. */
            _.Move(RET_CADASTRAMENTO.RF_VLPRMTOT, V0HCTA_VLPRMTOT);

            /*" -2525- MOVE RF-NSA TO V0HCTA-NSAS. */
            _.Move(RET_CADASTRAMENTO.RF_USO_EMPRESA.RF_NSA, V0HCTA_NSAS);

            /*" -2526- IF RF-IDENTIF-NSA NOT NUMERIC */

            if (!RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_IDENTIF_NSA.IsNumeric())
            {

                /*" -2527- IF WS-CODCONV EQUAL 6081 */

                if (WORK_AREA.WS_CODCONV == 6081)
                {

                    /*" -2528- ADD 19000 TO V0HCTA-NSAS */
                    V0HCTA_NSAS.Value = V0HCTA_NSAS + 19000;

                    /*" -2530- END-IF */
                }


                /*" -2531- IF WS-CODCONV EQUAL 6088 */

                if (WORK_AREA.WS_CODCONV == 6088)
                {

                    /*" -2532- ADD 23000 TO V0HCTA-NSAS */
                    V0HCTA_NSAS.Value = V0HCTA_NSAS + 23000;

                    /*" -2534- END-IF */
                }


                /*" -2535- IF WS-CODCONV EQUAL 6132 */

                if (WORK_AREA.WS_CODCONV == 6132)
                {

                    /*" -2536- ADD 28000 TO V0HCTA-NSAS */
                    V0HCTA_NSAS.Value = V0HCTA_NSAS + 28000;

                    /*" -2538- END-IF */
                }


                /*" -2539- IF WS-CODCONV EQUAL 6153 */

                if (WORK_AREA.WS_CODCONV == 6153)
                {

                    /*" -2540- ADD 30000 TO V0HCTA-NSAS */
                    V0HCTA_NSAS.Value = V0HCTA_NSAS + 30000;

                    /*" -2541- END-IF */
                }


                /*" -2542- ELSE */
            }
            else
            {


                /*" -2544- MOVE RF-IDENTIF-NSA TO V0HCTA-NSAS. */
                _.Move(RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_IDENTIF_NSA, V0HCTA_NSAS);
            }


            /*" -2547- MOVE RF-NSL TO V0HCTA-NSL. */
            _.Move(RET_CADASTRAMENTO.RF_USO_EMPRESA.RF_NSL, V0HCTA_NSL);

            /*" -2562- PERFORM R0035_00_ACESSO_NUMCTADEB_DB_DECLARE_1 */

            R0035_00_ACESSO_NUMCTADEB_DB_DECLARE_1();

            /*" -2567- MOVE 18 TO W01-I */
            _.Move(18, FILLER_11.W01_I);

            /*" -2568- MOVE 'OPEN CHCONTA3' TO W01-TEXTO(W01-I) */
            _.Move("OPEN CHCONTA3", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -2572- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -2572- PERFORM R0035_00_ACESSO_NUMCTADEB_DB_OPEN_1 */

            R0035_00_ACESSO_NUMCTADEB_DB_OPEN_1();

            /*" -2576- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -2581- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -2582- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2589- DISPLAY 'VA0813B - PROBLEMAS NO OPEN     CHCONTA3     ' ' ' V0HCTA-AGECTADEB ' ' V0HCTA-OPRCTADEB ' ' V0HCTA-NUMCTADEB ' ' WHOST-CODCONV ' ' V0HCTA-NSAS ' ' V0HCTA-VLPRMTOT */

                $"VA0813B - PROBLEMAS NO OPEN     CHCONTA3      {V0HCTA_AGECTADEB} {V0HCTA_OPRCTADEB} {V0HCTA_NUMCTADEB} {WHOST_CODCONV} {V0HCTA_NSAS} {V0HCTA_VLPRMTOT}"
                .Display();

                /*" -2595- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2596- MOVE 19 TO W01-I */
            _.Move(19, FILLER_11.W01_I);

            /*" -2597- MOVE 'FETCH CHCONTA3' TO W01-TEXTO(W01-I) */
            _.Move("FETCH CHCONTA3", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -2601- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -2605- PERFORM R0035_00_ACESSO_NUMCTADEB_DB_FETCH_1 */

            R0035_00_ACESSO_NUMCTADEB_DB_FETCH_1();

            /*" -2609- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -2615- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -2616- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2617- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2620- MOVE 'PARCELA NAO ENCONTRADA' TO RETERR-MENSAGEM */
                    _.Move("PARCELA NAO ENCONTRADA", RETERR_RECORD.RETERR_MENSAGEM);

                    /*" -2621- MOVE 20 TO W01-I */
                    _.Move(20, FILLER_11.W01_I);

                    /*" -2623- MOVE 'CLOSE CHCONTA3' TO W01-TEXTO(W01-I) */
                    _.Move("CLOSE CHCONTA3", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

                    /*" -2627- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

                    R8900_TOTALIZA_INICIO_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


                    /*" -2627- PERFORM R0035_00_ACESSO_NUMCTADEB_DB_CLOSE_1 */

                    R0035_00_ACESSO_NUMCTADEB_DB_CLOSE_1();

                    /*" -2631- MOVE 1 TO W01-QTD-ACC-OK */
                    _.Move(1, FILLER_11.W01_QTD_ACC_OK);

                    /*" -2635- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

                    R8910_TOTALIZA_FINAL_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


                    /*" -2636- MOVE 1 TO WS-NAO-ACHEI */
                    _.Move(1, WORK_AREA.WS_NAO_ACHEI);

                    /*" -2637- GO TO R0035-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0035_99_SAIDA*/ //GOTO
                    return;

                    /*" -2638- ELSE */
                }
                else
                {


                    /*" -2645- DISPLAY 'VA0813B - PROBLEMAS NO FETCH    CHCONTA3     ' ' ' V0HCTA-AGECTADEB ' ' V0HCTA-OPRCTADEB ' ' V0HCTA-NUMCTADEB ' ' WHOST-CODCONV ' ' V0HCTA-NSAS ' ' V0HCTA-VLPRMTOT */

                    $"VA0813B - PROBLEMAS NO FETCH    CHCONTA3      {V0HCTA_AGECTADEB} {V0HCTA_OPRCTADEB} {V0HCTA_NUMCTADEB} {WHOST_CODCONV} {V0HCTA_NSAS} {V0HCTA_VLPRMTOT}"
                    .Display();

                    /*" -2649- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2650- MOVE 21 TO W01-I */
            _.Move(21, FILLER_11.W01_I);

            /*" -2651- MOVE 'CLOSE CHCONTA3' TO W01-TEXTO(W01-I) */
            _.Move("CLOSE CHCONTA3", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -2655- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -2655- PERFORM R0035_00_ACESSO_NUMCTADEB_DB_CLOSE_2 */

            R0035_00_ACESSO_NUMCTADEB_DB_CLOSE_2();

            /*" -2659- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -2664- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -2665- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2667- DISPLAY 'VA0813B - PROBLEMAS NO CLOSE    CHCONTA3     ' V0HCTA-NRCERTIF ' ' V0HCTA-NRPARCEL */

                $"VA0813B - PROBLEMAS NO CLOSE    CHCONTA3     {V0HCTA_NRCERTIF} {V0HCTA_NRPARCEL}"
                .Display();

                /*" -2667- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0035-00-ACESSO-NUMCTADEB-DB-OPEN-1 */
        public void R0035_00_ACESSO_NUMCTADEB_DB_OPEN_1()
        {
            /*" -2572- EXEC SQL OPEN CHCONTA3 END-EXEC. */

            CHCONTA3.Open();

        }

        [StopWatch]
        /*" R0200-00-DECLARE-V0PRODUTO-DB-DECLARE-1 */
        public void R0200_00_DECLARE_V0PRODUTO_DB_DECLARE_1()
        {
            /*" -5764- EXEC SQL DECLARE V0PRODUTO CURSOR FOR SELECT CODPRODU FROM SEGUROS.V0PRODUTO WHERE COD_EMPRESA IN ( 0, 10, 11 ) ORDER BY CODPRODU WITH UR END-EXEC. */
            V0PRODUTO = new VA0813B_V0PRODUTO(false);
            string GetQuery_V0PRODUTO()
            {
                var query = @$"SELECT CODPRODU 
							FROM SEGUROS.V0PRODUTO 
							WHERE COD_EMPRESA IN ( 0
							, 10
							, 11 ) 
							ORDER BY CODPRODU";

                return query;
            }
            V0PRODUTO.GetQueryEvent += GetQuery_V0PRODUTO;

        }

        [StopWatch]
        /*" R0035-00-ACESSO-NUMCTADEB-DB-FETCH-1 */
        public void R0035_00_ACESSO_NUMCTADEB_DB_FETCH_1()
        {
            /*" -2605- EXEC SQL FETCH CHCONTA3 INTO :V0HCTA-NRCERTIF, :V0HCTA-NRPARCEL, :V0HCTA-OCORHISTCTA END-EXEC. */

            if (CHCONTA3.Fetch())
            {
                _.Move(CHCONTA3.V0HCTA_NRCERTIF, V0HCTA_NRCERTIF);
                _.Move(CHCONTA3.V0HCTA_NRPARCEL, V0HCTA_NRPARCEL);
                _.Move(CHCONTA3.V0HCTA_OCORHISTCTA, V0HCTA_OCORHISTCTA);
            }

        }

        [StopWatch]
        /*" R0035-00-ACESSO-NUMCTADEB-DB-CLOSE-1 */
        public void R0035_00_ACESSO_NUMCTADEB_DB_CLOSE_1()
        {
            /*" -2627- EXEC SQL CLOSE CHCONTA3 END-EXEC */

            CHCONTA3.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0035_99_SAIDA*/

        [StopWatch]
        /*" R0035-00-ACESSO-NUMCTADEB-DB-CLOSE-2 */
        public void R0035_00_ACESSO_NUMCTADEB_DB_CLOSE_2()
        {
            /*" -2655- EXEC SQL CLOSE CHCONTA3 END-EXEC. */

            CHCONTA3.Close();

        }

        [StopWatch]
        /*" R0036-00-ACESSO-NSAS-SECTION */
        private void R0036_00_ACESSO_NSAS_SECTION()
        {
            /*" -2713- MOVE 'R0036-00-ACESSO-NSAS     ' TO PARAGRAFO. */
            _.Move("R0036-00-ACESSO-NSAS     ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2716- MOVE 'SELECT V0HISTCONTAVA NSAS' TO COMANDO. */
            _.Move("SELECT V0HISTCONTAVA NSAS", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -2717- MOVE RF-IDENTIF-NSA TO V0HCTA-NSAS. */
            _.Move(RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_IDENTIF_NSA, V0HCTA_NSAS);

            /*" -2718- MOVE RF-NSL TO V0HCTA-NSL. */
            _.Move(RET_CADASTRAMENTO.RF_USO_EMPRESA.RF_NSL, V0HCTA_NSL);

            /*" -2719- MOVE RF-NSL TO WHOST-RF-NSL. */
            _.Move(RET_CADASTRAMENTO.RF_USO_EMPRESA.RF_NSL, WHOST_RF_NSL);

            /*" -2721- MOVE WHOST-RF-NSL TO V0HCTA-NSL. */
            _.Move(WHOST_RF_NSL, V0HCTA_NSL);

            /*" -2726- MOVE WS-CODCONV TO V0HCTA-CODCONV. */
            _.Move(WORK_AREA.WS_CODCONV, V0HCTA_CODCONV);

            /*" -2727- MOVE 22 TO W01-I */
            _.Move(22, FILLER_11.W01_I);

            /*" -2729- MOVE 'SELECT V0HISTCONTAVA' TO W01-TEXTO(W01-I) */
            _.Move("SELECT V0HISTCONTAVA", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -2733- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -2746- PERFORM R0036_00_ACESSO_NSAS_DB_SELECT_1 */

            R0036_00_ACESSO_NSAS_DB_SELECT_1();

            /*" -2750- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -2756- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -2757- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2758- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2759- MOVE 'PARCELA NAO ENCONTRADA' TO RETERR-MENSAGEM */
                    _.Move("PARCELA NAO ENCONTRADA", RETERR_RECORD.RETERR_MENSAGEM);

                    /*" -2760- MOVE 1 TO WS-NAO-ACHEI */
                    _.Move(1, WORK_AREA.WS_NAO_ACHEI);

                    /*" -2761- GO TO R0036-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0036_99_SAIDA*/ //GOTO
                    return;

                    /*" -2762- ELSE */
                }
                else
                {


                    /*" -2764- DISPLAY 'VA0813B - PROBLEMAS NO SELECT NSAS V0HISTCONT' V0HCTA-NSAS ' ' V0HCTA-NSL */

                    $"VA0813B - PROBLEMAS NO SELECT NSAS V0HISTCONT{V0HCTA_NSAS} {V0HCTA_NSL}"
                    .Display();

                    /*" -2765- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0036-00-ACESSO-NSAS-DB-SELECT-1 */
        public void R0036_00_ACESSO_NSAS_DB_SELECT_1()
        {
            /*" -2746- EXEC SQL SELECT NRCERTIF, NRPARCEL, OCORRHISTCTA INTO :V0HCTA-NRCERTIF, :V0HCTA-NRPARCEL, :V0HCTA-OCORHISTCTA FROM SEGUROS.V0HISTCONTAVA WHERE NSAS = :V0HCTA-NSAS AND NSL = :V0HCTA-NSL AND TIPLANC = '1' AND CODCONV = :V0HCTA-CODCONV WITH UR END-EXEC. */

            var r0036_00_ACESSO_NSAS_DB_SELECT_1_Query1 = new R0036_00_ACESSO_NSAS_DB_SELECT_1_Query1()
            {
                V0HCTA_CODCONV = V0HCTA_CODCONV.ToString(),
                V0HCTA_NSAS = V0HCTA_NSAS.ToString(),
                V0HCTA_NSL = V0HCTA_NSL.ToString(),
            };

            var executed_1 = R0036_00_ACESSO_NSAS_DB_SELECT_1_Query1.Execute(r0036_00_ACESSO_NSAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HCTA_NRCERTIF, V0HCTA_NRCERTIF);
                _.Move(executed_1.V0HCTA_NRPARCEL, V0HCTA_NRPARCEL);
                _.Move(executed_1.V0HCTA_OCORHISTCTA, V0HCTA_OCORHISTCTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0036_99_SAIDA*/

        [StopWatch]
        /*" R0040-00-SEL-V0HISTCOBVA-SECTION */
        private void R0040_00_SEL_V0HISTCOBVA_SECTION()
        {
            /*" -2774- MOVE 'R0040-00-SEL-V0HISTCOBVA' TO PARAGRAFO. */
            _.Move("R0040-00-SEL-V0HISTCOBVA", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2778- MOVE 'SELECT V0HISTCOBVA AA' TO COMANDO */
            _.Move("SELECT V0HISTCOBVA AA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -2779- MOVE 23 TO W01-I */
            _.Move(23, FILLER_11.W01_I);

            /*" -2780- MOVE 'SELECT V0HISTCOBVA' TO W01-TEXTO(W01-I) */
            _.Move("SELECT V0HISTCOBVA", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -2784- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -2805- PERFORM R0040_00_SEL_V0HISTCOBVA_DB_SELECT_1 */

            R0040_00_SEL_V0HISTCOBVA_DB_SELECT_1();

            /*" -2809- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -2819- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -2820- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2821- IF SQLCODE EQUAL -811 */

                if (DB.SQLCODE == -811)
                {

                    /*" -2822- PERFORM R0041-00-SEL-V0HISTCOBVA */

                    R0041_00_SEL_V0HISTCOBVA_SECTION();

                    /*" -2823- ELSE */
                }
                else
                {


                    /*" -2825- DISPLAY 'VA0813B - PROBLEMAS NO SELECT AA V0HISTCOBVA ' V0HCTA-NRCERTIF ' ' V0HCTA-NRPARCEL */

                    $"VA0813B - PROBLEMAS NO SELECT AA V0HISTCOBVA {V0HCTA_NRCERTIF} {V0HCTA_NRPARCEL}"
                    .Display();

                    /*" -2826- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2827- END-IF */
                }


                /*" -2827- END-IF. */
            }


        }

        [StopWatch]
        /*" R0040-00-SEL-V0HISTCOBVA-DB-SELECT-1 */
        public void R0040_00_SEL_V0HISTCOBVA_DB_SELECT_1()
        {
            /*" -2805- EXEC SQL SELECT NRTIT, OCORHIST, DTVENCTO, SITUACAO, VLPRMTOT, OPCAOPAG, DTVENCTO - 1 DAY INTO :V0HCOB-NRTIT, :V0HCOB-OCORHIST, :V0HCOB-DTVENCTO, :V0HCOB-SITUACAO, :V0HCOB-VLPRMTOT, :V0HCOB-OPCAOPAG, :V0HCOB-DTALTOPC FROM SEGUROS.V0HISTCOBVA WHERE NRCERTIF = :V0HCTA-NRCERTIF AND NRPARCEL = :V0HCTA-NRPARCEL AND SITUACAO IN ( '0' , ' ' , '5' ) WITH UR END-EXEC. */

            var r0040_00_SEL_V0HISTCOBVA_DB_SELECT_1_Query1 = new R0040_00_SEL_V0HISTCOBVA_DB_SELECT_1_Query1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0HCTA_NRPARCEL = V0HCTA_NRPARCEL.ToString(),
            };

            var executed_1 = R0040_00_SEL_V0HISTCOBVA_DB_SELECT_1_Query1.Execute(r0040_00_SEL_V0HISTCOBVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HCOB_NRTIT, V0HCOB_NRTIT);
                _.Move(executed_1.V0HCOB_OCORHIST, V0HCOB_OCORHIST);
                _.Move(executed_1.V0HCOB_DTVENCTO, V0HCOB_DTVENCTO);
                _.Move(executed_1.V0HCOB_SITUACAO, V0HCOB_SITUACAO);
                _.Move(executed_1.V0HCOB_VLPRMTOT, V0HCOB_VLPRMTOT);
                _.Move(executed_1.V0HCOB_OPCAOPAG, V0HCOB_OPCAOPAG);
                _.Move(executed_1.V0HCOB_DTALTOPC, V0HCOB_DTALTOPC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0040_99_SAIDA*/

        [StopWatch]
        /*" R0041-00-SEL-V0HISTCOBVA-SECTION */
        private void R0041_00_SEL_V0HISTCOBVA_SECTION()
        {
            /*" -2837- MOVE 'R0041-00-SEL-V0HISTCOBVA' TO PARAGRAFO. */
            _.Move("R0041-00-SEL-V0HISTCOBVA", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2841- MOVE 'SELECT V0HISTCOBVA BB' TO COMANDO */
            _.Move("SELECT V0HISTCOBVA BB", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -2842- MOVE 24 TO W01-I */
            _.Move(24, FILLER_11.W01_I);

            /*" -2843- MOVE 'SELECT V0HISTCOBVA' TO W01-TEXTO(W01-I) */
            _.Move("SELECT V0HISTCOBVA", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -2847- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -2869- PERFORM R0041_00_SEL_V0HISTCOBVA_DB_SELECT_1 */

            R0041_00_SEL_V0HISTCOBVA_DB_SELECT_1();

            /*" -2873- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -2878- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -2879- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2880- IF SQLCODE EQUAL -811 */

                if (DB.SQLCODE == -811)
                {

                    /*" -2881- PERFORM R0042-00-SEL-V0HISTCOBVA */

                    R0042_00_SEL_V0HISTCOBVA_SECTION();

                    /*" -2882- ELSE */
                }
                else
                {


                    /*" -2884- DISPLAY 'VA0813B - PROBLEMAS NO SELECT BB V0HISTCOBVA ' V0HCTA-NRCERTIF ' ' V0HCTA-NRPARCEL */

                    $"VA0813B - PROBLEMAS NO SELECT BB V0HISTCOBVA {V0HCTA_NRCERTIF} {V0HCTA_NRPARCEL}"
                    .Display();

                    /*" -2885- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2886- END-IF */
                }


                /*" -2886- END-IF. */
            }


        }

        [StopWatch]
        /*" R0041-00-SEL-V0HISTCOBVA-DB-SELECT-1 */
        public void R0041_00_SEL_V0HISTCOBVA_DB_SELECT_1()
        {
            /*" -2869- EXEC SQL SELECT NRTIT, OCORHIST, DTVENCTO, SITUACAO, VLPRMTOT, OPCAOPAG, DTVENCTO - 1 DAY INTO :V0HCOB-NRTIT, :V0HCOB-OCORHIST, :V0HCOB-DTVENCTO, :V0HCOB-SITUACAO, :V0HCOB-VLPRMTOT, :V0HCOB-OPCAOPAG, :V0HCOB-DTALTOPC FROM SEGUROS.V0HISTCOBVA WHERE NRCERTIF = :V0HCTA-NRCERTIF AND NRPARCEL = :V0HCTA-NRPARCEL AND SITUACAO IN ( '0' , ' ' , '5' ) AND VLPRMTOT = :WS-VLPRMTOT WITH UR END-EXEC. */

            var r0041_00_SEL_V0HISTCOBVA_DB_SELECT_1_Query1 = new R0041_00_SEL_V0HISTCOBVA_DB_SELECT_1_Query1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0HCTA_NRPARCEL = V0HCTA_NRPARCEL.ToString(),
                WS_VLPRMTOT = WS_VLPRMTOT.ToString(),
            };

            var executed_1 = R0041_00_SEL_V0HISTCOBVA_DB_SELECT_1_Query1.Execute(r0041_00_SEL_V0HISTCOBVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HCOB_NRTIT, V0HCOB_NRTIT);
                _.Move(executed_1.V0HCOB_OCORHIST, V0HCOB_OCORHIST);
                _.Move(executed_1.V0HCOB_DTVENCTO, V0HCOB_DTVENCTO);
                _.Move(executed_1.V0HCOB_SITUACAO, V0HCOB_SITUACAO);
                _.Move(executed_1.V0HCOB_VLPRMTOT, V0HCOB_VLPRMTOT);
                _.Move(executed_1.V0HCOB_OPCAOPAG, V0HCOB_OPCAOPAG);
                _.Move(executed_1.V0HCOB_DTALTOPC, V0HCOB_DTALTOPC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0041_99_SAIDA*/

        [StopWatch]
        /*" R0042-00-SEL-V0HISTCOBVA-SECTION */
        private void R0042_00_SEL_V0HISTCOBVA_SECTION()
        {
            /*" -2896- MOVE 'R0042-00-SEL-V0HISTCOBVA' TO PARAGRAFO. */
            _.Move("R0042-00-SEL-V0HISTCOBVA", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2900- MOVE 'SELECT MIN OCORHIST  ' TO COMANDO */
            _.Move("SELECT MIN OCORHIST  ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -2901- MOVE 25 TO W01-I */
            _.Move(25, FILLER_11.W01_I);

            /*" -2902- MOVE 'SELECT V0HISTCOBVA' TO W01-TEXTO(W01-I) */
            _.Move("SELECT V0HISTCOBVA", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -2906- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -2916- PERFORM R0042_00_SEL_V0HISTCOBVA_DB_SELECT_1 */

            R0042_00_SEL_V0HISTCOBVA_DB_SELECT_1();

            /*" -2920- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -2925- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -2929- MOVE 'SELECT V0HISTCOBVA CC' TO COMANDO */
            _.Move("SELECT V0HISTCOBVA CC", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -2930- MOVE 26 TO W01-I */
            _.Move(26, FILLER_11.W01_I);

            /*" -2931- MOVE 'SELECT V0HISTCOBVA' TO W01-TEXTO(W01-I) */
            _.Move("SELECT V0HISTCOBVA", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -2935- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -2960- PERFORM R0042_00_SEL_V0HISTCOBVA_DB_SELECT_2 */

            R0042_00_SEL_V0HISTCOBVA_DB_SELECT_2();

            /*" -2964- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -2969- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -2970- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2974- DISPLAY 'VA0813B - PROBLEMAS NO SELECT CC V0HISTCOBVA ' V0HCTA-NRCERTIF ' ' V0HCTA-NRPARCEL WS-VLPRMTOT ' ' V0HCOB-OCORHIST ' ' */

                $"VA0813B - PROBLEMAS NO SELECT CC V0HISTCOBVA {V0HCTA_NRCERTIF} {V0HCTA_NRPARCEL}{WS_VLPRMTOT} {V0HCOB_OCORHIST} "
                .Display();

                /*" -2975- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2975- END-IF. */
            }


        }

        [StopWatch]
        /*" R0042-00-SEL-V0HISTCOBVA-DB-SELECT-1 */
        public void R0042_00_SEL_V0HISTCOBVA_DB_SELECT_1()
        {
            /*" -2916- EXEC SQL SELECT VALUE(MIN(OCORHIST),0) INTO :V0HCOB-OCORHIST FROM SEGUROS.V0HISTCOBVA WHERE NRCERTIF = :V0HCTA-NRCERTIF AND NRPARCEL = :V0HCTA-NRPARCEL AND SITUACAO IN ( '0' , ' ' , '5' ) AND VLPRMTOT = :WS-VLPRMTOT WITH UR END-EXEC. */

            var r0042_00_SEL_V0HISTCOBVA_DB_SELECT_1_Query1 = new R0042_00_SEL_V0HISTCOBVA_DB_SELECT_1_Query1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0HCTA_NRPARCEL = V0HCTA_NRPARCEL.ToString(),
                WS_VLPRMTOT = WS_VLPRMTOT.ToString(),
            };

            var executed_1 = R0042_00_SEL_V0HISTCOBVA_DB_SELECT_1_Query1.Execute(r0042_00_SEL_V0HISTCOBVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HCOB_OCORHIST, V0HCOB_OCORHIST);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0042_99_SAIDA*/

        [StopWatch]
        /*" R0042-00-SEL-V0HISTCOBVA-DB-SELECT-2 */
        public void R0042_00_SEL_V0HISTCOBVA_DB_SELECT_2()
        {
            /*" -2960- EXEC SQL SELECT NRTIT, OCORHIST, DTVENCTO, SITUACAO, VLPRMTOT, OPCAOPAG, DTVENCTO - 1 DAY INTO :V0HCOB-NRTIT, :V0HCOB-OCORHIST, :V0HCOB-DTVENCTO, :V0HCOB-SITUACAO, :V0HCOB-VLPRMTOT, :V0HCOB-OPCAOPAG, :V0HCOB-DTALTOPC FROM SEGUROS.V0HISTCOBVA WHERE NRCERTIF = :V0HCTA-NRCERTIF AND NRPARCEL = :V0HCTA-NRPARCEL AND SITUACAO IN ( '0' , ' ' , '5' ) AND VLPRMTOT = :WS-VLPRMTOT AND OCORHIST = :V0HCOB-OCORHIST ORDER BY NRTIT FETCH FIRST 1 ROW ONLY WITH UR END-EXEC. */

            var r0042_00_SEL_V0HISTCOBVA_DB_SELECT_2_Query1 = new R0042_00_SEL_V0HISTCOBVA_DB_SELECT_2_Query1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0HCTA_NRPARCEL = V0HCTA_NRPARCEL.ToString(),
                V0HCOB_OCORHIST = V0HCOB_OCORHIST.ToString(),
                WS_VLPRMTOT = WS_VLPRMTOT.ToString(),
            };

            var executed_1 = R0042_00_SEL_V0HISTCOBVA_DB_SELECT_2_Query1.Execute(r0042_00_SEL_V0HISTCOBVA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HCOB_NRTIT, V0HCOB_NRTIT);
                _.Move(executed_1.V0HCOB_OCORHIST, V0HCOB_OCORHIST);
                _.Move(executed_1.V0HCOB_DTVENCTO, V0HCOB_DTVENCTO);
                _.Move(executed_1.V0HCOB_SITUACAO, V0HCOB_SITUACAO);
                _.Move(executed_1.V0HCOB_VLPRMTOT, V0HCOB_VLPRMTOT);
                _.Move(executed_1.V0HCOB_OPCAOPAG, V0HCOB_OPCAOPAG);
                _.Move(executed_1.V0HCOB_DTALTOPC, V0HCOB_DTALTOPC);
            }


        }

        [StopWatch]
        /*" R0050-00-GERA-FITACEF-SECTION */
        private void R0050_00_GERA_FITACEF_SECTION()
        {
            /*" -2984- MOVE '0050-GERA-FITACEF' TO PARAGRAFO. */
            _.Move("0050-GERA-FITACEF", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2990- MOVE 'SELECT V0FITACEF' TO COMANDO. */
            _.Move("SELECT V0FITACEF", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -2991- MOVE 27 TO W01-I */
            _.Move(27, FILLER_11.W01_I);

            /*" -2992- MOVE 'SELECT V0FITACEF' TO W01-TEXTO(W01-I) */
            _.Move("SELECT V0FITACEF", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -2996- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -3002- PERFORM R0050_00_GERA_FITACEF_DB_SELECT_1 */

            R0050_00_GERA_FITACEF_DB_SELECT_1();

            /*" -3006- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -3011- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -3012- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3013- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3014- PERFORM R0055-00-INSERT-FITACEF */

                    R0055_00_INSERT_FITACEF_SECTION();

                    /*" -3015- GO TO R0050-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/ //GOTO
                    return;

                    /*" -3016- ELSE */
                }
                else
                {


                    /*" -3018- DISPLAY 'VA0813B - PROBLEMAS NO SELECT DA V0FITACEF   ' V0FTCF-NSAC */
                    _.Display($"VA0813B - PROBLEMAS NO SELECT DA V0FITACEF   {V0FTCF_NSAC}");

                    /*" -3019- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3020- END-IF */
                }


                /*" -3022- END-IF. */
            }


            /*" -3022- PERFORM R0053-00-UPDATE-FITACEF. */

            R0053_00_UPDATE_FITACEF_SECTION();

        }

        [StopWatch]
        /*" R0050-00-GERA-FITACEF-DB-SELECT-1 */
        public void R0050_00_GERA_FITACEF_DB_SELECT_1()
        {
            /*" -3002- EXEC SQL SELECT DATA_GERACAO INTO :V0FTCF-DTRET FROM SEGUROS.V0FITACEF WHERE NSAC = :V0FTCF-NSAC WITH UR END-EXEC. */

            var r0050_00_GERA_FITACEF_DB_SELECT_1_Query1 = new R0050_00_GERA_FITACEF_DB_SELECT_1_Query1()
            {
                V0FTCF_NSAC = V0FTCF_NSAC.ToString(),
            };

            var executed_1 = R0050_00_GERA_FITACEF_DB_SELECT_1_Query1.Execute(r0050_00_GERA_FITACEF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0FTCF_DTRET, V0FTCF_DTRET);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0051_99_SAIDA*/

        [StopWatch]
        /*" R0053-00-UPDATE-FITACEF-SECTION */
        private void R0053_00_UPDATE_FITACEF_SECTION()
        {
            /*" -3032- MOVE 'R0053-00-UPDATE-FITACEF' TO PARAGRAFO. */
            _.Move("R0053-00-UPDATE-FITACEF", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3035- MOVE 'UPDATE V0FITACEF' TO COMANDO. */
            _.Move("UPDATE V0FITACEF", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -3036- MOVE WS-REGISTROS TO V0FTCF-QTLANCDB. */
            _.Move(WORK_AREA.WS_REGISTROS, V0FTCF_QTLANCDB);

            /*" -3037- MOVE WS-QTDBEFET TO V0FTCF-QTDBEFET. */
            _.Move(WORK_AREA.WS_QTDBEFET, V0FTCF_QTDBEFET);

            /*" -3038- MOVE WS-ACG-TOTDBEFET TO V0FTCF-TOTDBEFET. */
            _.Move(WORK_AREA.WS_ACG_TOTDBEFET, V0FTCF_TOTDBEFET);

            /*" -3043- MOVE WS-ACG-TOTDBNEFET TO V0FTCF-TOTDBNEFET. */
            _.Move(WORK_AREA.WS_ACG_TOTDBNEFET, V0FTCF_TOTDBNEFET);

            /*" -3044- MOVE 28 TO W01-I */
            _.Move(28, FILLER_11.W01_I);

            /*" -3045- MOVE 'UPDATE V0FITACEF' TO W01-TEXTO(W01-I) */
            _.Move("UPDATE V0FITACEF", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -3049- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -3057- PERFORM R0053_00_UPDATE_FITACEF_DB_UPDATE_1 */

            R0053_00_UPDATE_FITACEF_DB_UPDATE_1();

            /*" -3061- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -3067- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -3068- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -3070- DISPLAY 'VA0813B - PROBLEMAS NO UPDATE DA V0FITACEF   ' V0FTCF-NSAC */
                _.Display($"VA0813B - PROBLEMAS NO UPDATE DA V0FITACEF   {V0FTCF_NSAC}");

                /*" -3071- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3071- END-IF. */
            }


        }

        [StopWatch]
        /*" R0053-00-UPDATE-FITACEF-DB-UPDATE-1 */
        public void R0053_00_UPDATE_FITACEF_DB_UPDATE_1()
        {
            /*" -3057- EXEC SQL UPDATE SEGUROS.V0FITACEF SET DATA_GERACAO = :V0FTCF-DTRET2, QTDE_LANC_DEB_RET = :V0FTCF-QTLANCDB, TOT_DEB_EFET = :V0FTCF-TOTDBEFET, TOT_DEB_NAO_EFET = :V0FTCF-TOTDBNEFET, QTDE_DEB_EFET = :V0FTCF-QTDBEFET WHERE NSAC = :V0FTCF-NSAC END-EXEC. */

            var r0053_00_UPDATE_FITACEF_DB_UPDATE_1_Update1 = new R0053_00_UPDATE_FITACEF_DB_UPDATE_1_Update1()
            {
                V0FTCF_TOTDBNEFET = V0FTCF_TOTDBNEFET.ToString(),
                V0FTCF_TOTDBEFET = V0FTCF_TOTDBEFET.ToString(),
                V0FTCF_QTLANCDB = V0FTCF_QTLANCDB.ToString(),
                V0FTCF_QTDBEFET = V0FTCF_QTDBEFET.ToString(),
                V0FTCF_DTRET2 = V0FTCF_DTRET2.ToString(),
                V0FTCF_NSAC = V0FTCF_NSAC.ToString(),
            };

            R0053_00_UPDATE_FITACEF_DB_UPDATE_1_Update1.Execute(r0053_00_UPDATE_FITACEF_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0053_99_SAIDA*/

        [StopWatch]
        /*" R0055-00-INSERT-FITACEF-SECTION */
        private void R0055_00_INSERT_FITACEF_SECTION()
        {
            /*" -3081- MOVE 'R0055-00-INSERT-FITACEF' TO PARAGRAFO. */
            _.Move("R0055-00-INSERT-FITACEF", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3084- MOVE 'INSERT V0FITACEF' TO COMANDO. */
            _.Move("INSERT V0FITACEF", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -3085- MOVE RZ-QTDE-REGISTROS TO V0FTCF-QTREG. */
            _.Move(RET_TRAILLER.RZ_QTDE_REGISTROS, V0FTCF_QTREG);

            /*" -3086- MOVE WS-REGISTROS TO V0FTCF-QTLANCDB. */
            _.Move(WORK_AREA.WS_REGISTROS, V0FTCF_QTLANCDB);

            /*" -3087- MOVE WS-QTDBEFET TO V0FTCF-QTDBEFET. */
            _.Move(WORK_AREA.WS_QTDBEFET, V0FTCF_QTDBEFET);

            /*" -3088- MOVE WS-ACG-TOTDBEFET TO V0FTCF-TOTDBEFET. */
            _.Move(WORK_AREA.WS_ACG_TOTDBEFET, V0FTCF_TOTDBEFET);

            /*" -3093- MOVE WS-ACG-TOTDBNEFET TO V0FTCF-TOTDBNEFET. */
            _.Move(WORK_AREA.WS_ACG_TOTDBNEFET, V0FTCF_TOTDBNEFET);

            /*" -3094- MOVE 29 TO W01-I */
            _.Move(29, FILLER_11.W01_I);

            /*" -3095- MOVE 'INSERT V0FITACEF' TO W01-TEXTO(W01-I) */
            _.Move("INSERT V0FITACEF", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -3099- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -3113- PERFORM R0055_00_INSERT_FITACEF_DB_INSERT_1 */

            R0055_00_INSERT_FITACEF_DB_INSERT_1();

            /*" -3117- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -3123- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -3124- IF SQLCODE NOT EQUAL ZEROS AND -803 */

            if (!DB.SQLCODE.In("00", "-803"))
            {

                /*" -3126- DISPLAY 'VA0813B - PROBLEMAS NO INSERT DA V0FITACEF   ' V0FTCF-NSAC */
                _.Display($"VA0813B - PROBLEMAS NO INSERT DA V0FITACEF   {V0FTCF_NSAC}");

                /*" -3127- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3127- END-IF. */
            }


        }

        [StopWatch]
        /*" R0055-00-INSERT-FITACEF-DB-INSERT-1 */
        public void R0055_00_INSERT_FITACEF_DB_INSERT_1()
        {
            /*" -3113- EXEC SQL INSERT INTO SEGUROS.V0FITACEF VALUES (:V0FTCF-NSAC, :V0FTCF-DTRET, :V0FTCF-VERSAO, :V0FTCF-QTREG, :V0FTCF-QTLANCDB, :V0FTCF-TOTDBEFET, :V0FTCF-TOTDBNEFET, 0, 0, 0, :V0FTCF-QTDBEFET, 0) END-EXEC. */

            var r0055_00_INSERT_FITACEF_DB_INSERT_1_Insert1 = new R0055_00_INSERT_FITACEF_DB_INSERT_1_Insert1()
            {
                V0FTCF_NSAC = V0FTCF_NSAC.ToString(),
                V0FTCF_DTRET = V0FTCF_DTRET.ToString(),
                V0FTCF_VERSAO = V0FTCF_VERSAO.ToString(),
                V0FTCF_QTREG = V0FTCF_QTREG.ToString(),
                V0FTCF_QTLANCDB = V0FTCF_QTLANCDB.ToString(),
                V0FTCF_TOTDBEFET = V0FTCF_TOTDBEFET.ToString(),
                V0FTCF_TOTDBNEFET = V0FTCF_TOTDBNEFET.ToString(),
                V0FTCF_QTDBEFET = V0FTCF_QTDBEFET.ToString(),
            };

            R0055_00_INSERT_FITACEF_DB_INSERT_1_Insert1.Execute(r0055_00_INSERT_FITACEF_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0055_99_SAIDA*/

        [StopWatch]
        /*" R0090-00-MONTA-AVISO-SECTION */
        private void R0090_00_MONTA_AVISO_SECTION()
        {
            /*" -3137- MOVE 'R0090-00-MONTA-AVISO   ' TO PARAGRAFO. */
            _.Move("R0090-00-MONTA-AVISO   ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3141- MOVE 'MONTA AVISO       ' TO COMANDO. */
            _.Move("MONTA AVISO       ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -3142- MOVE 104 TO V0AVIS-BCOAVISO */
            _.Move(104, V0AVIS_BCOAVISO);

            /*" -3144- MOVE 7004 TO V0AVIS-AGEAVISO */
            _.Move(7004, V0AVIS_AGEAVISO);

            /*" -3151- MOVE 2 TO V0AVIS-ORIGAVISO */
            _.Move(2, V0AVIS_ORIGAVISO);

            /*" -3152- MOVE AUX-CONVENIO TO WS-AGEAVISO */
            _.Move(WORK_AREA.AUX_CONVENIO, WORK_AREA.FILLER_14.WS_AGEAVISO);

            /*" -3154- MOVE AUX-NSAC TO WS-NSAC. */
            _.Move(WORK_AREA.AUX_NSAC, WORK_AREA.FILLER_14.WS_NSAC);

            /*" -3155- MOVE WS-NRAVISO TO V0AVIS-NRAVISO */
            _.Move(WORK_AREA.WS_NRAVISO, V0AVIS_NRAVISO);

            /*" -3156- MOVE 1 TO V0AVIS-NRSEQ */
            _.Move(1, V0AVIS_NRSEQ);

            /*" -3157- MOVE V0SIST-DTMOVABE TO V0AVIS-DTMOVTO */
            _.Move(V0SIST_DTMOVABE, V0AVIS_DTMOVTO);

            /*" -3158- MOVE 100 TO V0AVIS-OPERACAO */
            _.Move(100, V0AVIS_OPERACAO);

            /*" -3159- MOVE 'C' TO V0AVIS-TIPAVI */
            _.Move("C", V0AVIS_TIPAVI);

            /*" -3160- MOVE V0FTCF-DTRET TO V0AVIS-DTAVISO */
            _.Move(V0FTCF_DTRET, V0AVIS_DTAVISO);

            /*" -3161- MOVE ZEROS TO V0AVIS-VLIOCC */
            _.Move(0, V0AVIS_VLIOCC);

            /*" -3162- MOVE ZEROS TO V0AVIS-VLDESPES */
            _.Move(0, V0AVIS_VLDESPES);

            /*" -3163- MOVE ZEROS TO V0AVIS-PRECED */
            _.Move(0, V0AVIS_PRECED);

            /*" -3164- MOVE '0' TO V0AVIS-SITCONTB */
            _.Move("0", V0AVIS_SITCONTB);

            /*" -3165- MOVE ZEROS TO V0AVIS-CODEMP */
            _.Move(0, V0AVIS_CODEMP);

            /*" -3167- MOVE ZEROS TO V0AVIS-VALADT. */
            _.Move(0, V0AVIS_VALADT);

            /*" -3168- MOVE ZEROS TO AUX-VLPRMTOT AUX-VLDESPES. */
            _.Move(0, WORK_AREA.AUX_VLPRMTOT, WORK_AREA.AUX_VLDESPES);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0090_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-INSERT-AVISOS-SECTION */
        private void R0100_00_INSERT_AVISOS_SECTION()
        {
            /*" -3178- MOVE 'R0100-00-INSERT-AVISOS ' TO PARAGRAFO. */
            _.Move("R0100-00-INSERT-AVISOS ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3184- MOVE 'INSERT V0AVISOCRED' TO COMANDO. */
            _.Move("INSERT V0AVISOCRED", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -3185- MOVE AUX-VLPRMTOT TO V0AVIS-VLPRMTOT. */
            _.Move(WORK_AREA.AUX_VLPRMTOT, V0AVIS_VLPRMTOT);

            /*" -3187- MOVE AUX-VLDESPES TO V0AVIS-VLDESPES. */
            _.Move(WORK_AREA.AUX_VLDESPES, V0AVIS_VLDESPES);

            /*" -3190- COMPUTE V0AVIS-VLPRMLIQ EQUAL V0AVIS-VLPRMTOT - V0AVIS-VLDESPES. */
            V0AVIS_VLPRMLIQ.Value = V0AVIS_VLPRMTOT - V0AVIS_VLDESPES;

            /*" -3194- MOVE ZEROS TO VIND-CODEMP VIND-ORIGAVISO VIND-VALADT. */
            _.Move(0, VIND_CODEMP, VIND_ORIGAVISO, VIND_VALADT);

            /*" -3198- MOVE 'P' TO V0AVIS-SITDEPTER. */
            _.Move("P", V0AVIS_SITDEPTER);

            /*" -3199- MOVE 30 TO W01-I. */
            _.Move(30, FILLER_11.W01_I);

            /*" -3201- MOVE 'INSERT V0AVISOCRED' TO W01-TEXTO(W01-I). */
            _.Move("INSERT V0AVISOCRED", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -3206- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT. */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -3227- PERFORM R0100_00_INSERT_AVISOS_DB_INSERT_1 */

            R0100_00_INSERT_AVISOS_DB_INSERT_1();

            /*" -3233- MOVE 1 TO W01-QTD-ACC-OK. */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -3238- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT. */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -3239- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -3242- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -3243- GO TO R0100-00-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_00_SAIDA*/ //GOTO
                    return;

                    /*" -3244- ELSE */
                }
                else
                {


                    /*" -3248- DISPLAY 'VA0813B - PROBLEMAS NO INSERT DA V0AVISOCRED ' V0AVIS-BCOAVISO ' ' V0AVIS-AGEAVISO ' ' V0AVIS-NRAVISO */

                    $"VA0813B - PROBLEMAS NO INSERT DA V0AVISOCRED {V0AVIS_BCOAVISO} {V0AVIS_AGEAVISO} {V0AVIS_NRAVISO}"
                    .Display();

                    /*" -3250- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3251- MOVE V0AVIS-CODEMP TO V0SALD-CODEMP */
            _.Move(V0AVIS_CODEMP, V0SALD_CODEMP);

            /*" -3252- MOVE V0AVIS-BCOAVISO TO V0SALD-BCOAVISO */
            _.Move(V0AVIS_BCOAVISO, V0SALD_BCOAVISO);

            /*" -3253- MOVE V0AVIS-AGEAVISO TO V0SALD-AGEAVISO */
            _.Move(V0AVIS_AGEAVISO, V0SALD_AGEAVISO);

            /*" -3254- MOVE '1' TO V0SALD-TIPSGU */
            _.Move("1", V0SALD_TIPSGU);

            /*" -3255- MOVE V0AVIS-NRAVISO TO V0SALD-NRAVISO */
            _.Move(V0AVIS_NRAVISO, V0SALD_NRAVISO);

            /*" -3256- MOVE V0AVIS-DTAVISO TO V0SALD-DTAVISO */
            _.Move(V0AVIS_DTAVISO, V0SALD_DTAVISO);

            /*" -3257- MOVE V0AVIS-DTMOVTO TO V0SALD-DTMOVTO */
            _.Move(V0AVIS_DTMOVTO, V0SALD_DTMOVTO);

            /*" -3258- MOVE ZEROS TO V0SALD-SDOATU */
            _.Move(0, V0SALD_SDOATU);

            /*" -3260- MOVE '0' TO V0SALD-SITUACAO. */
            _.Move("0", V0SALD_SITUACAO);

            /*" -3266- MOVE 'INSERT V0AVISOS_SALDO' TO COMANDO. */
            _.Move("INSERT V0AVISOS_SALDO", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -3268- MOVE 31 TO W01-I. */
            _.Move(31, FILLER_11.W01_I);

            /*" -3271- MOVE 'INSERT V0AVISOS_SALDOS' TO W01-TEXTO(W01-I), */
            _.Move("INSERT V0AVISOS_SALDOS", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -3276- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT. */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -3288- PERFORM R0100_00_INSERT_AVISOS_DB_INSERT_2 */

            R0100_00_INSERT_AVISOS_DB_INSERT_2();

            /*" -3294- MOVE 1 TO W01-QTD-ACC-OK. */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -3298- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT. */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -3299- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -3300- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -3301- GO TO R0100-00-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_00_SAIDA*/ //GOTO
                    return;

                    /*" -3302- ELSE */
                }
                else
                {


                    /*" -3306- DISPLAY 'VA0813B - PROBLEMAS NO INSERT DA V0AVISOS_SAL' V0AVIS-BCOAVISO ' ' V0AVIS-AGEAVISO ' ' V0AVIS-NRAVISO */

                    $"VA0813B - PROBLEMAS NO INSERT DA V0AVISOS_SAL{V0AVIS_BCOAVISO} {V0AVIS_AGEAVISO} {V0AVIS_NRAVISO}"
                    .Display();

                    /*" -3307- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3308- END-IF */
                }


                /*" -3310- END-IF. */
            }


            /*" -3312- SET WS-PRD TO 1. */
            WS_PRD.Value = 1;

            /*" -3312- PERFORM R8500-00-GRAVA-DESPESAS 2000 TIMES. */

            for (int i = 0; i < 2000; i++)
            {

                R8500_00_GRAVA_DESPESAS_SECTION();

            }

        }

        [StopWatch]
        /*" R0100-00-INSERT-AVISOS-DB-INSERT-1 */
        public void R0100_00_INSERT_AVISOS_DB_INSERT_1()
        {
            /*" -3227- EXEC SQL INSERT INTO SEGUROS.V0AVISOCRED VALUES (:V0AVIS-BCOAVISO , :V0AVIS-AGEAVISO , :V0AVIS-NRAVISO , :V0AVIS-NRSEQ , :V0AVIS-DTMOVTO , :V0AVIS-OPERACAO , :V0AVIS-TIPAVI , :V0AVIS-DTAVISO , :V0AVIS-VLIOCC , :V0AVIS-VLDESPES , :V0AVIS-PRECED , :V0AVIS-VLPRMLIQ , :V0AVIS-VLPRMTOT , :V0AVIS-SITCONTB , :V0AVIS-CODEMP:VIND-CODEMP , CURRENT TIMESTAMP , :V0AVIS-ORIGAVISO:VIND-ORIGAVISO , :V0AVIS-VALADT:VIND-VALADT , :V0AVIS-SITDEPTER) END-EXEC. */

            var r0100_00_INSERT_AVISOS_DB_INSERT_1_Insert1 = new R0100_00_INSERT_AVISOS_DB_INSERT_1_Insert1()
            {
                V0AVIS_BCOAVISO = V0AVIS_BCOAVISO.ToString(),
                V0AVIS_AGEAVISO = V0AVIS_AGEAVISO.ToString(),
                V0AVIS_NRAVISO = V0AVIS_NRAVISO.ToString(),
                V0AVIS_NRSEQ = V0AVIS_NRSEQ.ToString(),
                V0AVIS_DTMOVTO = V0AVIS_DTMOVTO.ToString(),
                V0AVIS_OPERACAO = V0AVIS_OPERACAO.ToString(),
                V0AVIS_TIPAVI = V0AVIS_TIPAVI.ToString(),
                V0AVIS_DTAVISO = V0AVIS_DTAVISO.ToString(),
                V0AVIS_VLIOCC = V0AVIS_VLIOCC.ToString(),
                V0AVIS_VLDESPES = V0AVIS_VLDESPES.ToString(),
                V0AVIS_PRECED = V0AVIS_PRECED.ToString(),
                V0AVIS_VLPRMLIQ = V0AVIS_VLPRMLIQ.ToString(),
                V0AVIS_VLPRMTOT = V0AVIS_VLPRMTOT.ToString(),
                V0AVIS_SITCONTB = V0AVIS_SITCONTB.ToString(),
                V0AVIS_CODEMP = V0AVIS_CODEMP.ToString(),
                VIND_CODEMP = VIND_CODEMP.ToString(),
                V0AVIS_ORIGAVISO = V0AVIS_ORIGAVISO.ToString(),
                VIND_ORIGAVISO = VIND_ORIGAVISO.ToString(),
                V0AVIS_VALADT = V0AVIS_VALADT.ToString(),
                VIND_VALADT = VIND_VALADT.ToString(),
                V0AVIS_SITDEPTER = V0AVIS_SITDEPTER.ToString(),
            };

            R0100_00_INSERT_AVISOS_DB_INSERT_1_Insert1.Execute(r0100_00_INSERT_AVISOS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_00_SAIDA*/

        [StopWatch]
        /*" R0100-00-INSERT-AVISOS-DB-INSERT-2 */
        public void R0100_00_INSERT_AVISOS_DB_INSERT_2()
        {
            /*" -3288- EXEC SQL INSERT INTO SEGUROS.V0AVISOS_SALDOS VALUES (:V0SALD-CODEMP , :V0SALD-BCOAVISO , :V0SALD-AGEAVISO , :V0SALD-TIPSGU , :V0SALD-NRAVISO , :V0SALD-DTAVISO , :V0SALD-DTMOVTO , :V0SALD-SDOATU , :V0SALD-SITUACAO , CURRENT TIMESTAMP) END-EXEC. */

            var r0100_00_INSERT_AVISOS_DB_INSERT_2_Insert1 = new R0100_00_INSERT_AVISOS_DB_INSERT_2_Insert1()
            {
                V0SALD_CODEMP = V0SALD_CODEMP.ToString(),
                V0SALD_BCOAVISO = V0SALD_BCOAVISO.ToString(),
                V0SALD_AGEAVISO = V0SALD_AGEAVISO.ToString(),
                V0SALD_TIPSGU = V0SALD_TIPSGU.ToString(),
                V0SALD_NRAVISO = V0SALD_NRAVISO.ToString(),
                V0SALD_DTAVISO = V0SALD_DTAVISO.ToString(),
                V0SALD_DTMOVTO = V0SALD_DTMOVTO.ToString(),
                V0SALD_SDOATU = V0SALD_SDOATU.ToString(),
                V0SALD_SITUACAO = V0SALD_SITUACAO.ToString(),
            };

            R0100_00_INSERT_AVISOS_DB_INSERT_2_Insert1.Execute(r0100_00_INSERT_AVISOS_DB_INSERT_2_Insert1);

        }

        [StopWatch]
        /*" R1000-00-QUITA-PARCELA-SECTION */
        private void R1000_00_QUITA_PARCELA_SECTION()
        {
            /*" -3326- MOVE 'R1000-00-QUITA-PARCELA' TO PARAGRAFO. */
            _.Move("R1000-00-QUITA-PARCELA", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3327- ADD 1 TO WS-QTDBEFET. */
            WORK_AREA.WS_QTDBEFET.Value = WORK_AREA.WS_QTDBEFET + 1;

            /*" -3329- MOVE '1' TO V0HCTA-SITUACAO. */
            _.Move("1", V0HCTA_SITUACAO);

            /*" -3330- COMPUTE V0HCOB-OCORHIST = V0HCOB-OCORHIST + 1. */
            V0HCOB_OCORHIST.Value = V0HCOB_OCORHIST + 1;

            /*" -3332- MOVE V0HCOB-OCORHIST TO V0HCTA-OCORHISTCOB. */
            _.Move(V0HCOB_OCORHIST, V0HCTA_OCORHISTCOB);

            /*" -3336- MOVE V0OPCP-OPCAOPAG TO V0HCTA-OPCAOPAG V0HCOB-OPCAOPAG V0PARC-OPCAOPAG. */
            _.Move(V0OPCP_OPCAOPAG, V0HCTA_OPCAOPAG, V0HCOB_OPCAOPAG, V0PARC_OPCAOPAG);

            /*" -3342- MOVE 'SELECT V0COBERPROPVA' TO COMANDO. */
            _.Move("SELECT V0COBERPROPVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -3343- MOVE 32 TO W01-I */
            _.Move(32, FILLER_11.W01_I);

            /*" -3345- MOVE 'SELECT V0COBERPROPVA' TO W01-TEXTO(W01-I) */
            _.Move("SELECT V0COBERPROPVA", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -3349- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -3387- PERFORM R1000_00_QUITA_PARCELA_DB_SELECT_1 */

            R1000_00_QUITA_PARCELA_DB_SELECT_1();

            /*" -3391- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -3403- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -3404- IF (SQLCODE NOT EQUAL ZEROES) */

            if ((DB.SQLCODE != 00))
            {

                /*" -3408- MOVE 'SELECT V0COBERPROPVA 1 ' TO COMANDO */
                _.Move("SELECT V0COBERPROPVA 1 ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

                /*" -3409- MOVE 33 TO W01-I */
                _.Move(33, FILLER_11.W01_I);

                /*" -3411- MOVE 'SELECT V0COBERPROPVA' TO W01-TEXTO(W01-I) */
                _.Move("SELECT V0COBERPROPVA", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

                /*" -3415- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

                R8900_TOTALIZA_INICIO_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


                /*" -3440- PERFORM R1000_00_QUITA_PARCELA_DB_SELECT_2 */

                R1000_00_QUITA_PARCELA_DB_SELECT_2();

                /*" -3444- END-IF. */
            }


            /*" -3445- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -3450- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -3451- IF (SQLCODE NOT EQUAL ZEROES) */

            if ((DB.SQLCODE != 00))
            {

                /*" -3455- MOVE 'SELECT V0COBERPROPVA 2 ' TO COMANDO */
                _.Move("SELECT V0COBERPROPVA 2 ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

                /*" -3456- MOVE 34 TO W01-I */
                _.Move(34, FILLER_11.W01_I);

                /*" -3458- MOVE 'SELECT V0COBERPROPVA' TO W01-TEXTO(W01-I) */
                _.Move("SELECT V0COBERPROPVA", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

                /*" -3462- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

                R8900_TOTALIZA_INICIO_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


                /*" -3488- PERFORM R1000_00_QUITA_PARCELA_DB_SELECT_3 */

                R1000_00_QUITA_PARCELA_DB_SELECT_3();

                /*" -3492- END-IF. */
            }


            /*" -3493- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -3498- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -3499- IF (SQLCODE NOT EQUAL ZEROES) */

            if ((DB.SQLCODE != 00))
            {

                /*" -3503- MOVE 'SELECT V0COBERPROPVA 3 ' TO COMANDO */
                _.Move("SELECT V0COBERPROPVA 3 ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

                /*" -3504- MOVE 35 TO W01-I */
                _.Move(35, FILLER_11.W01_I);

                /*" -3506- MOVE 'SELECT V0COBERPROPVA' TO W01-TEXTO(W01-I) */
                _.Move("SELECT V0COBERPROPVA", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

                /*" -3510- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

                R8900_TOTALIZA_INICIO_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


                /*" -3535- PERFORM R1000_00_QUITA_PARCELA_DB_SELECT_4 */

                R1000_00_QUITA_PARCELA_DB_SELECT_4();

                /*" -3539- END-IF. */
            }


            /*" -3540- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -3545- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -3546- IF (SQLCODE NOT EQUAL ZEROES) */

            if ((DB.SQLCODE != 00))
            {

                /*" -3550- DISPLAY 'VA0813B - PROBLEMAS NO SELECT 1  V0COBERPROPV' V0HCTA-NRCERTIF ' ' V0PARC-DTVENCTO ' ' V0PROP-OCORHIST */

                $"VA0813B - PROBLEMAS NO SELECT 1  V0COBERPROPV{V0HCTA_NRCERTIF} {V0PARC_DTVENCTO} {V0PROP_OCORHIST}"
                .Display();

                /*" -3551- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3559- END-IF. */
            }


            /*" -3560- IF V0COBP-VLCUSTAUXF-I < ZEROS */

            if (V0COBP_VLCUSTAUXF_I < 00)
            {

                /*" -3561- MOVE ZEROS TO V0COBP-IMPSEGAUXF */
                _.Move(0, V0COBP_IMPSEGAUXF);

                /*" -3562- MOVE ZEROS TO V0COBP-VLCUSTAUXF */
                _.Move(0, V0COBP_VLCUSTAUXF);

                /*" -3564- END-IF. */
            }


            /*" -3566- MOVE 0 TO WS-DIFERENCA. */
            _.Move(0, WORK_AREA.WS_DIFERENCA);

            /*" -3567- IF V0HCOB-SITUACAO EQUAL '1' */

            if (V0HCOB_SITUACAO == "1")
            {

                /*" -3568- MOVE 204 TO V0HCTB-CODOPER */
                _.Move(204, V0HCTB_CODOPER);

                /*" -3569- MOVE 601 TO V0DIFP-CODOPER */
                _.Move(601, V0DIFP_CODOPER);

                /*" -3570- MOVE V0HCTA-VLPRMTOT TO WS-DIFERENCA */
                _.Move(V0HCTA_VLPRMTOT, WORK_AREA.WS_DIFERENCA);

                /*" -3572- MOVE 0 TO V0DIFP-PRMDEVVG V0DIFP-PRMDEVAP */
                _.Move(0, V0DIFP_PRMDEVVG, V0DIFP_PRMDEVAP);

                /*" -3580- ELSE */
            }
            else
            {


                /*" -3581- IF V0HCTA-VLPRMTOT EQUAL V0HCOB-VLPRMTOT */

                if (V0HCTA_VLPRMTOT == V0HCOB_VLPRMTOT)
                {

                    /*" -3582- MOVE 202 TO V0HCTB-CODOPER */
                    _.Move(202, V0HCTB_CODOPER);

                    /*" -3583- ELSE */
                }
                else
                {


                    /*" -3584- MOVE V0PARC-PRMVG TO V0DIFP-PRMDEVVG */
                    _.Move(V0PARC_PRMVG, V0DIFP_PRMDEVVG);

                    /*" -3585- MOVE V0PARC-PRMAP TO V0DIFP-PRMDEVAP */
                    _.Move(V0PARC_PRMAP, V0DIFP_PRMDEVAP);

                    /*" -3586- IF V0HCTA-VLPRMTOT LESS V0HCOB-VLPRMTOT */

                    if (V0HCTA_VLPRMTOT < V0HCOB_VLPRMTOT)
                    {

                        /*" -3587- MOVE 206 TO V0HCTB-CODOPER */
                        _.Move(206, V0HCTB_CODOPER);

                        /*" -3588- MOVE 401 TO V0DIFP-CODOPER */
                        _.Move(401, V0DIFP_CODOPER);

                        /*" -3590- COMPUTE WS-DIFERENCA = V0HCOB-VLPRMTOT - V0HCTA-VLPRMTOT */
                        WORK_AREA.WS_DIFERENCA.Value = V0HCOB_VLPRMTOT - V0HCTA_VLPRMTOT;

                        /*" -3591- ELSE */
                    }
                    else
                    {


                        /*" -3592- MOVE 207 TO V0HCTB-CODOPER */
                        _.Move(207, V0HCTB_CODOPER);

                        /*" -3593- MOVE 602 TO V0DIFP-CODOPER */
                        _.Move(602, V0DIFP_CODOPER);

                        /*" -3596- COMPUTE WS-DIFERENCA = V0HCTA-VLPRMTOT - V0HCOB-VLPRMTOT. */
                        WORK_AREA.WS_DIFERENCA.Value = V0HCTA_VLPRMTOT - V0HCOB_VLPRMTOT;
                    }

                }

            }


            /*" -3597- IF WS-DIFERENCA NOT EQUAL 0 */

            if (WORK_AREA.WS_DIFERENCA != 0)
            {

                /*" -3598- IF V0HCOB-VLPRMTOT GREATER 0 */

                if (V0HCOB_VLPRMTOT > 0)
                {

                    /*" -3599- COMPUTE WS-PC-VG = V0PARC-PRMVG / V0HCOB-VLPRMTOT */
                    WORK_AREA.WS_PC_VG.Value = V0PARC_PRMVG / V0HCOB_VLPRMTOT;

                    /*" -3600- COMPUTE V0DIFP-PRMPAGVG = V0HCTA-VLPRMTOT * WS-PC-VG */
                    V0DIFP_PRMPAGVG.Value = V0HCTA_VLPRMTOT * WORK_AREA.WS_PC_VG;

                    /*" -3602- COMPUTE V0DIFP-PRMPAGAP = V0HCTA-VLPRMTOT - V0DIFP-PRMPAGVG */
                    V0DIFP_PRMPAGAP.Value = V0HCTA_VLPRMTOT - V0DIFP_PRMPAGVG;

                    /*" -3603- MOVE V0DIFP-PRMPAGVG TO V0PARC-PRMVG */
                    _.Move(V0DIFP_PRMPAGVG, V0PARC_PRMVG);

                    /*" -3604- MOVE V0DIFP-PRMPAGAP TO V0PARC-PRMAP */
                    _.Move(V0DIFP_PRMPAGAP, V0PARC_PRMAP);

                    /*" -3605- COMPUTE V0DIFP-PRMDIFVG = WS-DIFERENCA * WS-PC-VG */
                    V0DIFP_PRMDIFVG.Value = WORK_AREA.WS_DIFERENCA * WORK_AREA.WS_PC_VG;

                    /*" -3607- COMPUTE V0DIFP-PRMDIFAP = WS-DIFERENCA - V0DIFP-PRMDIFVG */
                    V0DIFP_PRMDIFAP.Value = WORK_AREA.WS_DIFERENCA - V0DIFP_PRMDIFVG;

                    /*" -3608- ELSE */
                }
                else
                {


                    /*" -3611- MOVE V0HCTA-VLPRMTOT TO V0DIFP-PRMPAGVG V0DIFP-PRMDIFVG V0PARC-PRMVG */
                    _.Move(V0HCTA_VLPRMTOT, V0DIFP_PRMPAGVG, V0DIFP_PRMDIFVG, V0PARC_PRMVG);

                    /*" -3615- MOVE 0 TO V0DIFP-PRMPAGAP V0DIFP-PRMDIFAP V0PARC-PRMAP. */
                    _.Move(0, V0DIFP_PRMPAGAP, V0DIFP_PRMDIFAP, V0PARC_PRMAP);
                }

            }


            /*" -3616- IF WS-DIFERENCA NOT EQUAL 0 */

            if (WORK_AREA.WS_DIFERENCA != 0)
            {

                /*" -3617- IF V0PARC-PRMAP LESS ZEROS */

                if (V0PARC_PRMAP < 00)
                {

                    /*" -3618- COMPUTE V0PARC-PRMTOTVG = V0PARC-PRMVG + V0PARC-PRMAP */
                    V0PARC_PRMTOTVG.Value = V0PARC_PRMVG + V0PARC_PRMAP;

                    /*" -3620- IF V0PARC-PRMTOTVG LESS ZEROS NEXT SENTENCE */

                    if (V0PARC_PRMTOTVG < 00)
                    {

                        /*" -3621- ELSE */
                    }
                    else
                    {


                        /*" -3622- MOVE V0PARC-PRMTOTVG TO V0PARC-PRMVG */
                        _.Move(V0PARC_PRMTOTVG, V0PARC_PRMVG);

                        /*" -3624- MOVE ZEROS TO V0PARC-PRMAP. */
                        _.Move(0, V0PARC_PRMAP);
                    }

                }

            }


            /*" -3625- IF WS-DIFERENCA NOT EQUAL 0 */

            if (WORK_AREA.WS_DIFERENCA != 0)
            {

                /*" -3626- IF V0DIFP-PRMPAGAP LESS ZEROS */

                if (V0DIFP_PRMPAGAP < 00)
                {

                    /*" -3628- COMPUTE V0PARC-PRMTOTVG = V0DIFP-PRMPAGVG + V0DIFP-PRMPAGAP */
                    V0PARC_PRMTOTVG.Value = V0DIFP_PRMPAGVG + V0DIFP_PRMPAGAP;

                    /*" -3630- IF V0PARC-PRMTOTVG LESS ZEROS NEXT SENTENCE */

                    if (V0PARC_PRMTOTVG < 00)
                    {

                        /*" -3631- ELSE */
                    }
                    else
                    {


                        /*" -3632- MOVE V0PARC-PRMTOTVG TO V0DIFP-PRMPAGVG */
                        _.Move(V0PARC_PRMTOTVG, V0DIFP_PRMPAGVG);

                        /*" -3634- MOVE ZEROS TO V0DIFP-PRMPAGAP. */
                        _.Move(0, V0DIFP_PRMPAGAP);
                    }

                }

            }


            /*" -3635- IF WS-DIFERENCA NOT EQUAL 0 */

            if (WORK_AREA.WS_DIFERENCA != 0)
            {

                /*" -3636- IF V0DIFP-PRMDIFAP LESS ZEROS */

                if (V0DIFP_PRMDIFAP < 00)
                {

                    /*" -3638- COMPUTE V0PARC-PRMTOTVG = V0DIFP-PRMDIFVG + V0DIFP-PRMDIFAP */
                    V0PARC_PRMTOTVG.Value = V0DIFP_PRMDIFVG + V0DIFP_PRMDIFAP;

                    /*" -3640- IF V0PARC-PRMTOTVG LESS ZEROS NEXT SENTENCE */

                    if (V0PARC_PRMTOTVG < 00)
                    {

                        /*" -3641- ELSE */
                    }
                    else
                    {


                        /*" -3642- MOVE V0PARC-PRMTOTVG TO V0DIFP-PRMDIFVG */
                        _.Move(V0PARC_PRMTOTVG, V0DIFP_PRMDIFVG);

                        /*" -3649- MOVE ZEROS TO V0DIFP-PRMDIFAP. */
                        _.Move(0, V0DIFP_PRMDIFAP);
                    }

                }

            }


            /*" -3650- IF V0PRVG-TEM-SAF = 'N' */

            if (V0PRVG_TEM_SAF == "N")
            {

                /*" -3652- MOVE ZEROS TO V0COBP-VLCUSTAUXF. */
                _.Move(0, V0COBP_VLCUSTAUXF);
            }


            /*" -3653- IF V0PRVG-TEM-CDG = 'N' */

            if (V0PRVG_TEM_CDG == "N")
            {

                /*" -3655- MOVE ZEROS TO V0COBP-VLCUSTCDG. */
                _.Move(0, V0COBP_VLCUSTCDG);
            }


            /*" -3656- IF V0PRVG-CUSTOCAP-TOTAL = 'N' */

            if (V0PRVG_CUSTOCAP_TOTAL == "N")
            {

                /*" -3659- COMPUTE V0COBP-VLCUSTCAP = V0COBP-VLCUSTCAP * V0COBP-QTTITCAP. */
                V0COBP_VLCUSTCAP.Value = V0COBP_VLCUSTCAP * V0COBP_QTTITCAP;
            }


            /*" -3669- COMPUTE V0HCTVA-VLCOBADIC = V0COBP-VLCUSTCDG + V0COBP-VLCUSTAUXF + V0COBP-VLCUSTCAP. */
            V0HCTVA_VLCOBADIC.Value = V0COBP_VLCUSTCDG + V0COBP_VLCUSTAUXF + V0COBP_VLCUSTCAP;

            /*" -3670- IF V0SIST-DTMOVABE NOT GREATER '2001-09-30' */

            if (V0SIST_DTMOVABE <= "2001-09-30")
            {

                /*" -3672- COMPUTE V0HCTVA-PRMVG = V0PARC-PRMVG - V0HCTVA-VLCOBADIC */
                V0HCTVA_PRMVG.Value = V0PARC_PRMVG - V0HCTVA_VLCOBADIC;

                /*" -3673- ELSE */
            }
            else
            {


                /*" -3675- MOVE V0PARC-PRMVG TO V0HCTVA-PRMVG. */
                _.Move(V0PARC_PRMVG, V0HCTVA_PRMVG);
            }


            /*" -3676- IF V0COBP-PRMVG > ZEROS */

            if (V0COBP_PRMVG > 00)
            {

                /*" -3677- COMPUTE WS-PCT-COB-VG = V0COBP-PRMVG / V0COBP-VLPREMIO */
                WORK_AREA.WS_PCT_COB_VG.Value = V0COBP_PRMVG / V0COBP_VLPREMIO;

                /*" -3679- COMPUTE V0HCTVA-PRMVG ROUNDED = V0HCTA-VLPRMTOT * WS-PCT-COB-VG */
                V0HCTVA_PRMVG.Value = V0HCTA_VLPRMTOT * WORK_AREA.WS_PCT_COB_VG;

                /*" -3680- COMPUTE V0HCTVA-PRMAP = V0HCTA-VLPRMTOT - V0HCTVA-PRMVG */
                V0HCTVA_PRMAP.Value = V0HCTA_VLPRMTOT - V0HCTVA_PRMVG;

                /*" -3681- ELSE */
            }
            else
            {


                /*" -3682- MOVE ZEROS TO V0HCTVA-PRMVG */
                _.Move(0, V0HCTVA_PRMVG);

                /*" -3690- MOVE V0HCTA-VLPRMTOT TO V0HCTVA-PRMAP. */
                _.Move(V0HCTA_VLPRMTOT, V0HCTVA_PRMAP);
            }


            /*" -3694- MOVE 'INSERT V0HISTCONTABILVA' TO COMANDO. */
            _.Move("INSERT V0HISTCONTABILVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -3695- MOVE 36 TO W01-I */
            _.Move(36, FILLER_11.W01_I);

            /*" -3697- MOVE 'INSERT V0HISTCONTABILVA' TO W01-TEXTO(W01-I) */
            _.Move("INSERT V0HISTCONTABILVA", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -3701- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -3719- PERFORM R1000_00_QUITA_PARCELA_DB_INSERT_1 */

            R1000_00_QUITA_PARCELA_DB_INSERT_1();

            /*" -3723- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -3728- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -3730- IF SQLCODE NOT EQUAL ZEROES AND SQLCODE NOT EQUAL -803 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -803)
            {

                /*" -3732- DISPLAY 'VA0813B - PROBLEMAS NO INSERT V0HISTCONTABILV' V0HCTA-NRCERTIF ' ' */

                $"VA0813B - PROBLEMAS NO INSERT V0HISTCONTABILV{V0HCTA_NRCERTIF} "
                .Display();

                /*" -3733- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3734- ELSE */
            }
            else
            {


                /*" -3735- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -3736- MOVE 'N' TO WAUX-FLAG */
                    _.Move("N", WAUX_FLAG);

                    /*" -3738- END-IF */
                }


                /*" -3740- IF V0HCTB-CODOPER > 199 AND V0HCTB-CODOPER < 300 */

                if (V0HCTB_CODOPER > 199 && V0HCTB_CODOPER < 300)
                {

                    /*" -3741- PERFORM R0300-00-GERA-FUNDOCOMISVA */

                    R0300_00_GERA_FUNDOCOMISVA_SECTION();

                    /*" -3742- PERFORM R0400-00-GERA-COMISSAO */

                    R0400_00_GERA_COMISSAO_SECTION();

                    /*" -3743- END-IF */
                }


                /*" -3745- END-IF. */
            }


            /*" -3749- MOVE 'SELECT CLIENTES     ' TO COMANDO. */
            _.Move("SELECT CLIENTES     ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -3750- MOVE 37 TO W01-I */
            _.Move(37, FILLER_11.W01_I);

            /*" -3751- MOVE 'SELECT CLIENTES' TO W01-TEXTO(W01-I) */
            _.Move("SELECT CLIENTES", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -3755- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -3765- PERFORM R1000_00_QUITA_PARCELA_DB_SELECT_5 */

            R1000_00_QUITA_PARCELA_DB_SELECT_5();

            /*" -3769- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -3773- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -3774- IF (SQLCODE NOT EQUAL ZEROES) */

            if ((DB.SQLCODE != 00))
            {

                /*" -3781- DISPLAY 'VA0813B - PROBLEMAS NO SELECT CLIENTES       ' V0HCTA-NRCERTIF ' ' V0HCTA-NRPARCEL ' ' V0HCOB-NRTIT ' ' V0PROP-CODCLIEN ' ' WHOST-CODCONV ' ' V0HCTA-NSAS */

                $"VA0813B - PROBLEMAS NO SELECT CLIENTES       {V0HCTA_NRCERTIF} {V0HCTA_NRPARCEL} {V0HCOB_NRTIT} {V0PROP_CODCLIEN} {WHOST_CODCONV} {V0HCTA_NSAS}"
                .Display();

                /*" -3782- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3784- END-IF. */
            }


            /*" -3785- IF (VIND-DATSEL < ZEROS) */

            if ((VIND_DATSEL < 00))
            {

                /*" -3786- MOVE '1900-01-01' TO CLIENTES-DATA-NASCIMENTO */
                _.Move("1900-01-01", CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO);

                /*" -3852- END-IF. */
            }


            /*" -3853- IF (CLIENTES-TIPO-PESSOA EQUAL 'J' ) */

            if ((CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA == "J"))
            {

                /*" -3854- MOVE ZEROS TO WHOST-IDADE */
                _.Move(0, WHOST_IDADE);

                /*" -3855- ELSE */
            }
            else
            {


                /*" -3856- MOVE V0PROP-DTQITBCO(1:4) TO WHOST-ANO-VENC */
                _.Move(V0PROP_DTQITBCO.Substring(1, 4), WHOST_ANO_VENC);

                /*" -3857- MOVE CLIENTES-DATA-NASCIMENTO(1:4) TO WHOST-ANO-NASC */
                _.Move(CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO.Substring(1, 4), WHOST_ANO_NASC);

                /*" -3859- COMPUTE WHOST-IDADE = WHOST-ANO-VENC - WHOST-ANO-NASC */
                WHOST_IDADE.Value = WHOST_ANO_VENC - WHOST_ANO_NASC;

                /*" -3860- IF (CLIENTES-DATA-NASCIMENTO(6:5) > V0PROP-DTQITBCO(6:5)) */

                if ((CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO.Substring(6, 5) > V0PROP_DTQITBCO.Substring(6, 5)))
                {

                    /*" -3861- COMPUTE WHOST-IDADE = WHOST-IDADE - 1 */
                    WHOST_IDADE.Value = WHOST_IDADE - 1;

                    /*" -3862- END-IF */
                }


                /*" -3864- END-IF. */
            }


            /*" -3866- INITIALIZE WORK-TAB-RAMO-CONJ */
            _.Initialize(
                WORK_TAB_RAMO_CONJ
            );

            /*" -3871- MOVE ZEROS TO WS-IND WS-IND1 WHOST-VLR-PERC-PREMIO-TOT WS-PREMIO-TOTAL-AC */
            _.Move(0, WORK_RAMO_CONJ.WS_IND, WORK_RAMO_CONJ.WS_IND1, WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO_TOT, WS_PREMIO_TOTAL_AC);

            /*" -3873- COMPUTE WS-PREMIO-TOTAL = V0HCTVA-PRMVG + V0HCTVA-PRMAP */
            WS_PREMIO_TOTAL.Value = V0HCTVA_PRMVG + V0HCTVA_PRMAP;

            /*" -3874- IF (WS-PREMIO-TOTAL > V0COBP-PRMDIT) */

            if ((WS_PREMIO_TOTAL > V0COBP_PRMDIT))
            {

                /*" -3875- MOVE V0COBP-PRMDIT TO WHOST-VLR-FIXO-DIT */
                _.Move(V0COBP_PRMDIT, WHOST_VLR_FIXO_DIT);

                /*" -3876- ELSE */
            }
            else
            {


                /*" -3877- MOVE RETDEB-RECORD TO RETERR-REGISTRO */
                _.Move(RETDEB?.Value, RETERR_RECORD.RETERR_REGISTRO);

                /*" -3878- MOVE 'VALOR DIT > VALOR PREMIO ' TO RETERR-MENSAGEM */
                _.Move("VALOR DIT > VALOR PREMIO ", RETERR_RECORD.RETERR_MENSAGEM);

                /*" -3879- WRITE RETERR-RECORD */
                RETERR.Write(RETERR_RECORD.GetMoveValues().ToString());

                /*" -3880- MOVE ZEROS TO WHOST-VLR-FIXO-DIT */
                _.Move(0, WHOST_VLR_FIXO_DIT);

                /*" -3882- END-IF. */
            }


            /*" -3883- PERFORM R6900-00-DECLARE-VGRAMOCOMP */

            R6900_00_DECLARE_VGRAMOCOMP_SECTION();

            /*" -3884- PERFORM R6910-00-FETCH-VGRAMOCOMP */

            R6910_00_FETCH_VGRAMOCOMP_SECTION();

            /*" -3887- PERFORM R7000-00-PROCESSA-VGRAMOCOMP UNTIL WFIM-VGRAMOCOMP EQUAL 'SIM' . */

            while (!(WORK_AREA.WFIM_VGRAMOCOMP == "SIM"))
            {

                R7000_00_PROCESSA_VGRAMOCOMP_SECTION();
            }

            /*" -3888- IF (WS-IND > ZEROS) */

            if ((WORK_RAMO_CONJ.WS_IND > 00))
            {

                /*" -3889- IF (V0PRVG-RAMO NOT EQUAL TB-RAMO-CONJ (WS-IND)) */

                if ((V0PRVG_RAMO != WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND].TB_RAMO_CONJ))
                {

                    /*" -3891- MOVE N5WORK-TAB-RAMO-CONJ(WS-IND) TO WS-SALVA */
                    _.Move(WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND], WORK_RAMO_CONJ.WS_SALVA);

                    /*" -3894- PERFORM VARYING WS-IND1 FROM 1 BY 1 UNTIL TB-RAMO-CONJ (WS-IND1) EQUAL V0PRVG-RAMO OR WS-IND1 EQUAL WS-IND */

                    for (WORK_RAMO_CONJ.WS_IND1.Value = 1; !(WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND1].TB_RAMO_CONJ == V0PRVG_RAMO || WORK_RAMO_CONJ.WS_IND1 == WORK_RAMO_CONJ.WS_IND); WORK_RAMO_CONJ.WS_IND1.Value += 1)
                    {

                        /*" -3896- END-PERFORM */
                    }

                    /*" -3898- MOVE N5WORK-TAB-RAMO-CONJ(WS-IND1) TO N5WORK-TAB-RAMO-CONJ(WS-IND) */
                    _.Move(WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND1], WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND]);

                    /*" -3899- MOVE WS-SALVA TO N5WORK-TAB-RAMO-CONJ(WS-IND1) */
                    _.Move(WORK_RAMO_CONJ.WS_SALVA, WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND1]);

                    /*" -3900- END-IF */
                }


                /*" -3902- END-IF. */
            }


            /*" -3903- MOVE 'NAO' TO WFIM-TAB-RAMO */
            _.Move("NAO", WORK_AREA.WFIM_TAB_RAMO);

            /*" -3904- MOVE ZEROS TO WS-IND1 */
            _.Move(0, WORK_RAMO_CONJ.WS_IND1);

            /*" -3907- COMPUTE WS-PREMIO-TOTAL-DIT = WS-PREMIO-TOTAL - WHOST-VLR-FIXO-DIT */
            WS_PREMIO_TOTAL_DIT.Value = WS_PREMIO_TOTAL - WHOST_VLR_FIXO_DIT;

            /*" -3955- PERFORM R7200-00-INSERT-VGHISTCONT UNTIL WFIM-TAB-RAMO EQUAL 'SIM' . */

            while (!(WORK_AREA.WFIM_TAB_RAMO == "SIM"))
            {

                R7200_00_INSERT_VGHISTCONT_SECTION();
            }

            /*" -3956- IF (V0HCOB-SITUACAO EQUAL ' ' OR '0' OR '5' OR 'A' ) */

            if ((V0HCOB_SITUACAO.In(" ", "0", "5", "A")))
            {

                /*" -3967- MOVE 'UPDATE V0HISTCOBVA 2' TO COMANDO */
                _.Move("UPDATE V0HISTCOBVA 2", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

                /*" -3968- MOVE 39 TO W01-I */
                _.Move(39, FILLER_11.W01_I);

                /*" -3970- MOVE 'UPDATE V0HISTCOBVA' TO W01-TEXTO(W01-I) */
                _.Move("UPDATE V0HISTCOBVA", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

                /*" -3974- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

                R8900_TOTALIZA_INICIO_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


                /*" -3987- PERFORM R1000_00_QUITA_PARCELA_DB_UPDATE_1 */

                R1000_00_QUITA_PARCELA_DB_UPDATE_1();

                /*" -3991- MOVE 1 TO W01-QTD-ACC-OK */
                _.Move(1, FILLER_11.W01_QTD_ACC_OK);

                /*" -3995- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

                R8910_TOTALIZA_FINAL_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


                /*" -3996- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -4000- DISPLAY 'VA0813B - ERRO NO UPDATE 2 V0HISTCOBVA  ' V0HCTA-NRCERTIF ' ' V0HCTA-NRPARCEL ' ' V0HCOB-NRTIT */

                    $"VA0813B - ERRO NO UPDATE 2 V0HISTCOBVA  {V0HCTA_NRCERTIF} {V0HCTA_NRPARCEL} {V0HCOB_NRTIT}"
                    .Display();

                    /*" -4001- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4003- END-IF */
                }


                /*" -4006- MOVE 'UPDATE V0DIFPARCELVA' TO COMANDO */
                _.Move("UPDATE V0DIFPARCELVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

                /*" -4007- MOVE 40 TO W01-I */
                _.Move(40, FILLER_11.W01_I);

                /*" -4009- MOVE 'UPDATE V0DIFPARCELVA' TO W01-TEXTO(W01-I) */
                _.Move("UPDATE V0DIFPARCELVA", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

                /*" -4013- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

                R8900_TOTALIZA_INICIO_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


                /*" -4018- PERFORM R1000_00_QUITA_PARCELA_DB_UPDATE_2 */

                R1000_00_QUITA_PARCELA_DB_UPDATE_2();

                /*" -4022- MOVE 1 TO W01-QTD-ACC-OK */
                _.Move(1, FILLER_11.W01_QTD_ACC_OK);

                /*" -4026- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

                R8910_TOTALIZA_FINAL_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


                /*" -4027- IF SQLCODE NOT EQUAL ZEROES AND 100 */

                if (!DB.SQLCODE.In("00", "100"))
                {

                    /*" -4031- DISPLAY 'VA0813B - ERRO NO UPDATE   V0DIFPARCELVA' V0HCTA-NRCERTIF ' ' V0HCTA-NRPARCEL ' ' V0HCOB-NRTIT */

                    $"VA0813B - ERRO NO UPDATE   V0DIFPARCELVA{V0HCTA_NRCERTIF} {V0HCTA_NRPARCEL} {V0HCOB_NRTIT}"
                    .Display();

                    /*" -4032- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4034- END-IF */
                }


                /*" -4035- IF V0PROP-QTDPARATZ GREATER 0 */

                if (V0PROP_QTDPARATZ > 0)
                {

                    /*" -4036- SUBTRACT 1 FROM V0PROP-QTDPARATZ */
                    V0PROP_QTDPARATZ.Value = V0PROP_QTDPARATZ - 1;

                    /*" -4040- MOVE 'UPDATE V0PROPOSTAVA 1' TO COMANDO */
                    _.Move("UPDATE V0PROPOSTAVA 1", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

                    /*" -4041- MOVE 41 TO W01-I */
                    _.Move(41, FILLER_11.W01_I);

                    /*" -4042- MOVE 'UPDATE V0PROPOSTAVA' TO W01-TEXTO(W01-I) */
                    _.Move("UPDATE V0PROPOSTAVA", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

                    /*" -4046- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

                    R8900_TOTALIZA_INICIO_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


                    /*" -4050- PERFORM R1000_00_QUITA_PARCELA_DB_UPDATE_3 */

                    R1000_00_QUITA_PARCELA_DB_UPDATE_3();

                    /*" -4054- MOVE 1 TO W01-QTD-ACC-OK */
                    _.Move(1, FILLER_11.W01_QTD_ACC_OK);

                    /*" -4058- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

                    R8910_TOTALIZA_FINAL_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


                    /*" -4059- IF SQLCODE NOT EQUAL ZEROES */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -4063- DISPLAY 'VA0813B - ERRO UPDATE 1 V0PROPOSTAVA ' V0HCTA-NRCERTIF ' ' V0HCTA-NRPARCEL ' ' V0HCOB-NRTIT */

                        $"VA0813B - ERRO UPDATE 1 V0PROPOSTAVA {V0HCTA_NRCERTIF} {V0HCTA_NRPARCEL} {V0HCOB_NRTIT}"
                        .Display();

                        /*" -4064- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -4065- END-IF */
                    }


                    /*" -4066- END-IF */
                }


                /*" -4068- END-IF. */
            }


            /*" -4069- IF (V0PROP-SITUACAO EQUAL '8' ) */

            if ((V0PROP_SITUACAO == "8"))
            {

                /*" -4072- MOVE 'UPDATE V0PROPOSTAVA 2' TO COMANDO */
                _.Move("UPDATE V0PROPOSTAVA 2", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

                /*" -4073- MOVE 42 TO W01-I */
                _.Move(42, FILLER_11.W01_I);

                /*" -4075- MOVE 'UPDATE V0PROPOSTAVA' TO W01-TEXTO(W01-I) */
                _.Move("UPDATE V0PROPOSTAVA", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

                /*" -4079- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

                R8900_TOTALIZA_INICIO_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


                /*" -4088- PERFORM R1000_00_QUITA_PARCELA_DB_UPDATE_4 */

                R1000_00_QUITA_PARCELA_DB_UPDATE_4();

                /*" -4092- MOVE 1 TO W01-QTD-ACC-OK */
                _.Move(1, FILLER_11.W01_QTD_ACC_OK);

                /*" -4096- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

                R8910_TOTALIZA_FINAL_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


                /*" -4097- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -4101- DISPLAY 'VA0813B - PROBLEMAS NO UPDATE 2 V0PROPOSTAVA ' V0HCTA-NRCERTIF ' ' V0HCTA-NRPARCEL ' ' V0HCOB-NRTIT */

                    $"VA0813B - PROBLEMAS NO UPDATE 2 V0PROPOSTAVA {V0HCTA_NRCERTIF} {V0HCTA_NRPARCEL} {V0HCOB_NRTIT}"
                    .Display();

                    /*" -4102- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4103- END-IF */
                }


                /*" -4105- END-IF. */
            }


            /*" -4107- IF (V0PROP-SITUACAO EQUAL '6' ) AND (V0PROP-NRPARCE EQUAL V0HCTA-NRPARCEL) */

            if ((V0PROP_SITUACAO == "6") && (V0PROP_NRPARCE == V0HCTA_NRPARCEL))
            {

                /*" -4110- MOVE 'UPDATE V0PROPOSTAVA 3' TO COMANDO */
                _.Move("UPDATE V0PROPOSTAVA 3", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

                /*" -4111- MOVE 43 TO W01-I */
                _.Move(43, FILLER_11.W01_I);

                /*" -4113- MOVE 'UPDATE V0PROPOSTAVA' TO W01-TEXTO(W01-I) */
                _.Move("UPDATE V0PROPOSTAVA", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

                /*" -4117- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

                R8900_TOTALIZA_INICIO_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


                /*" -4123- PERFORM R1000_00_QUITA_PARCELA_DB_UPDATE_5 */

                R1000_00_QUITA_PARCELA_DB_UPDATE_5();

                /*" -4127- MOVE 1 TO W01-QTD-ACC-OK */
                _.Move(1, FILLER_11.W01_QTD_ACC_OK);

                /*" -4131- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

                R8910_TOTALIZA_FINAL_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


                /*" -4132- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -4136- DISPLAY 'VA0813B - PROBLEMAS UPDATE 3 V0PROPOSTAVA ' V0HCTA-NRCERTIF ' ' V0HCTA-NRPARCEL ' ' V0HCOB-NRTIT */

                    $"VA0813B - PROBLEMAS UPDATE 3 V0PROPOSTAVA {V0HCTA_NRCERTIF} {V0HCTA_NRPARCEL} {V0HCOB_NRTIT}"
                    .Display();

                    /*" -4137- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4138- END-IF */
                }


                /*" -4140- END-IF. */
            }


            /*" -4143- MOVE 'SELECT V0CDGCOBER' TO COMANDO. */
            _.Move("SELECT V0CDGCOBER", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -4144- MOVE 44 TO W01-I */
            _.Move(44, FILLER_11.W01_I);

            /*" -4145- MOVE 'SELECT V0CDGCOBER' TO W01-TEXTO(W01-I) */
            _.Move("SELECT V0CDGCOBER", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -4149- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -4156- PERFORM R1000_00_QUITA_PARCELA_DB_SELECT_6 */

            R1000_00_QUITA_PARCELA_DB_SELECT_6();

            /*" -4160- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -4165- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -4166- IF (SQLCODE EQUAL ZEROES) */

            if ((DB.SQLCODE == 00))
            {

                /*" -4167- IF V0PRVG-TEM-CDG = 'S' */

                if (V0PRVG_TEM_CDG == "S")
                {

                    /*" -4168- PERFORM R1100-00-REPASSA-CDG */

                    R1100_00_REPASSA_CDG_SECTION();

                    /*" -4170- ELSE NEXT SENTENCE */
                }
                else
                {


                    /*" -4171- END-IF */
                }


                /*" -4172- ELSE */
            }
            else
            {


                /*" -4173- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -4178- DISPLAY 'VA0813B - PROBLEMAS NO SELECT V0CDGCOBER     ' V0HCTA-NRCERTIF ' ' V0HCTA-NRPARCEL ' ' V0HCOB-NRTIT V0PROP-CODCLIEN */

                    $"VA0813B - PROBLEMAS NO SELECT V0CDGCOBER     {V0HCTA_NRCERTIF} {V0HCTA_NRPARCEL} {V0HCOB_NRTIT}{V0PROP_CODCLIEN}"
                    .Display();

                    /*" -4179- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4180- ELSE */
                }
                else
                {


                    /*" -4183- IF (V0PRVG-TEM-CDG = 'S' ) AND (V0COBP-VLCUSTCDG > ZEROS) AND (V0PROP-SITUACAO = '3' OR '6' ) */

                    if ((V0PRVG_TEM_CDG == "S") && (V0COBP_VLCUSTCDG > 00) && (V0PROP_SITUACAO.In("3", "6")))
                    {

                        /*" -4184- PERFORM R1099-00-INCLUI-CDG */

                        R1099_00_INCLUI_CDG_SECTION();

                        /*" -4185- END-IF */
                    }


                    /*" -4186- END-IF */
                }


                /*" -4188- END-IF. */
            }


            /*" -4191- MOVE 'SELECT V0SAFCOBER' TO COMANDO. */
            _.Move("SELECT V0SAFCOBER", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -4192- MOVE 45 TO W01-I */
            _.Move(45, FILLER_11.W01_I);

            /*" -4193- MOVE 'SELECT V0SAFCOBER' TO W01-TEXTO(W01-I) */
            _.Move("SELECT V0SAFCOBER", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -4197- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -4204- PERFORM R1000_00_QUITA_PARCELA_DB_SELECT_7 */

            R1000_00_QUITA_PARCELA_DB_SELECT_7();

            /*" -4208- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -4213- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -4214- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -4215- IF V0PRVG-TEM-SAF = 'S' */

                if (V0PRVG_TEM_SAF == "S")
                {

                    /*" -4216- PERFORM R1200-00-REPASSA-SAF */

                    R1200_00_REPASSA_SAF_SECTION();

                    /*" -4218- ELSE NEXT SENTENCE */
                }
                else
                {


                    /*" -4219- ELSE */
                }

            }
            else
            {


                /*" -4220- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -4225- DISPLAY 'VA0813B - PROBLEMAS NO SELECT V0CDGCOBER     ' V0HCTA-NRCERTIF ' ' V0HCTA-NRPARCEL ' ' V0HCOB-NRTIT V0PROP-CODCLIEN */

                    $"VA0813B - PROBLEMAS NO SELECT V0CDGCOBER     {V0HCTA_NRCERTIF} {V0HCTA_NRPARCEL} {V0HCOB_NRTIT}{V0PROP_CODCLIEN}"
                    .Display();

                    /*" -4226- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4227- ELSE */
                }
                else
                {


                    /*" -4230- IF V0PRVG-TEM-SAF = 'S' AND V0COBP-VLCUSTAUXF > ZEROS AND V0PROP-SITUACAO = '3' OR '6' */

                    if (V0PRVG_TEM_SAF == "S" && V0COBP_VLCUSTAUXF > 00 && V0PROP_SITUACAO.In("3", "6"))
                    {

                        /*" -4232- PERFORM R1199-00-INCLUI-SAF. */

                        R1199_00_INCLUI_SAF_SECTION();
                    }

                }

            }


            /*" -4233- IF WS-DIFERENCA NOT EQUAL 0 */

            if (WORK_AREA.WS_DIFERENCA != 0)
            {

                /*" -4234- PERFORM R1050-00-GRAVA-DIFERENCA */

                R1050_00_GRAVA_DIFERENCA_SECTION();

                /*" -4236- END-IF. */
            }


            /*" -4238- MOVE 'R1000-00-QUITA-PARCELA' TO PARAGRAFO. */
            _.Move("R1000-00-QUITA-PARCELA", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4241- MOVE 'UPDATE V0FITASASSE' TO COMANDO. */
            _.Move("UPDATE V0FITASASSE", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -4245- MOVE RF-IDENTIF-NSA TO WHOST-NSAS */
            _.Move(RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_IDENTIF_NSA, WHOST_NSAS);

            /*" -4246- MOVE 46 TO W01-I */
            _.Move(46, FILLER_11.W01_I);

            /*" -4247- MOVE 'UPDATE V0FITASASSE' TO W01-TEXTO(W01-I) */
            _.Move("UPDATE V0FITASASSE", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -4251- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -4259- PERFORM R1000_00_QUITA_PARCELA_DB_UPDATE_6 */

            R1000_00_QUITA_PARCELA_DB_UPDATE_6();

            /*" -4263- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -4268- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -4269- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -4277- DISPLAY 'VA0813B - PROBLEMAS NO UPDATE V0FITASASSE    ' V0HCTA-NRCERTIF ' ' V0HCTA-NRPARCEL ' ' V0HCOB-NRTIT ' ' V0PROP-CODCLIEN ' ' WHOST-CODCONV ' ' WHOST-NSAS ' ' V0HCTA-NSAS */

                $"VA0813B - PROBLEMAS NO UPDATE V0FITASASSE    {V0HCTA_NRCERTIF} {V0HCTA_NRPARCEL} {V0HCOB_NRTIT} {V0PROP_CODCLIEN} {WHOST_CODCONV} {WHOST_NSAS} {V0HCTA_NSAS}"
                .Display();

                /*" -4278- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4280- END-IF. */
            }


            /*" -4282- ADD V0HCTA-VLPRMTOT TO WS-ACG-TOTDBEFET. */
            WORK_AREA.WS_ACG_TOTDBEFET.Value = WORK_AREA.WS_ACG_TOTDBEFET + V0HCTA_VLPRMTOT;

            /*" -4284- COMPUTE V0CAPI-NRPARCEL = V0HCTA-NRPARCEL - 1. */
            V0CAPI_NRPARCEL.Value = V0HCTA_NRPARCEL - 1;

            /*" -4287- MOVE 'UPDATE V0PARCELCAPVG' TO COMANDO. */
            _.Move("UPDATE V0PARCELCAPVG", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -4288- MOVE 47 TO W01-I */
            _.Move(47, FILLER_11.W01_I);

            /*" -4290- MOVE 'UPDATE V0PARCELCAPVG' TO W01-TEXTO(W01-I) */
            _.Move("UPDATE V0PARCELCAPVG", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -4294- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -4301- PERFORM R1000_00_QUITA_PARCELA_DB_UPDATE_7 */

            R1000_00_QUITA_PARCELA_DB_UPDATE_7();

            /*" -4305- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -4310- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -4311- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -4313- IF SQLCODE = 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -4314- ELSE */
                }
                else
                {


                    /*" -4316- DISPLAY '*** VA0813B - ERRO UPDATE V0PARCELCAPVG ' V0HCTA-NRCERTIF ' ' V0CAPI-NRPARCEL ' ' SQLCODE */

                    $"*** VA0813B - ERRO UPDATE V0PARCELCAPVG {V0HCTA_NRCERTIF} {V0CAPI_NRPARCEL} {DB.SQLCODE}"
                    .Display();

                    /*" -4317- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4318- END-IF */
                }


                /*" -4320- END-IF. */
            }


            /*" -4321- IF V0HCTA-NSAS EQUAL ZEROS */

            if (V0HCTA_NSAS == 00)
            {

                /*" -4322- MOVE RF-IDENTIF-NSA TO V0HCTA-NSAS */
                _.Move(RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_IDENTIF_NSA, V0HCTA_NSAS);

                /*" -4324- END-IF. */
            }


            /*" -4328- MOVE 'SELECT V0FITASASSE  ' TO COMANDO. */
            _.Move("SELECT V0FITASASSE  ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -4329- MOVE 48 TO W01-I */
            _.Move(48, FILLER_11.W01_I);

            /*" -4330- MOVE 'SELECT V0FITASASSE' TO W01-TEXTO(W01-I) */
            _.Move("SELECT V0FITASASSE", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -4334- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -4341- PERFORM R1000_00_QUITA_PARCELA_DB_SELECT_8 */

            R1000_00_QUITA_PARCELA_DB_SELECT_8();

            /*" -4345- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -4350- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -4351- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -4359- DISPLAY 'VA0813B - PROBLEMAS NO SELECT V0FITASASSE    ' V0HCTA-NRCERTIF ' ' V0HCTA-NRPARCEL ' ' V0HCOB-NRTIT ' ' V0PROP-CODCLIEN ' ' WHOST-CODCONV ' ' WHOST-NSAS ' ' V0HCTA-NSAS */

                $"VA0813B - PROBLEMAS NO SELECT V0FITASASSE    {V0HCTA_NRCERTIF} {V0HCTA_NRPARCEL} {V0HCOB_NRTIT} {V0PROP_CODCLIEN} {WHOST_CODCONV} {WHOST_NSAS} {V0HCTA_NSAS}"
                .Display();

                /*" -4360- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4362- END-IF. */
            }


            /*" -4364- MOVE V0HCTA-NRCERTIF TO MA-NUM-CERTIFICADO */
            _.Move(V0HCTA_NRCERTIF, MAUDIT_REC.MA_NUM_CERTIFICADO);

            /*" -4366- MOVE V0HCTA-NRPARCEL TO MA-NUM-PARCELA */
            _.Move(V0HCTA_NRPARCEL, MAUDIT_REC.MA_NUM_PARCELA);

            /*" -4368- MOVE V0PARC-DTVENCTO TO MA-DATA-VENCIMENTO */
            _.Move(V0PARC_DTVENCTO, MAUDIT_REC.MA_DATA_VENCIMENTO);

            /*" -4370- MOVE V0FITA-DATA-GERACAO TO MA-DATA-MOVIMENTO */
            _.Move(V0FITA_DATA_GERACAO, MAUDIT_REC.MA_DATA_MOVIMENTO);

            /*" -4372- MOVE V0SIST-DTCURR TO MA-DATA-BAIXA */
            _.Move(V0SIST_DTCURR, MAUDIT_REC.MA_DATA_BAIXA);

            /*" -4374- MOVE CLIENTES-DATA-NASCIMENTO TO MA-DATA-NASCIMENTO */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO, MAUDIT_REC.MA_DATA_NASCIMENTO);

            /*" -4376- MOVE CLIENTES-CGCCPF TO MA-CGCCPF. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, MAUDIT_REC.MA_CGCCPF);

            /*" -4378- MOVE V0HCOB-VLPRMTOT TO MA-VLR-ESPERADO */
            _.Move(V0HCOB_VLPRMTOT, MAUDIT_REC.MA_VLR_ESPERADO);

            /*" -4380- MOVE V0HCTA-VLPRMTOT TO MA-VLR-RECEBIDO */
            _.Move(V0HCTA_VLPRMTOT, MAUDIT_REC.MA_VLR_RECEBIDO);

            /*" -4383- COMPUTE MA-VLR-BAIXADO = V0HCTVA-PRMVG + V0HCTVA-PRMAP */
            MAUDIT_REC.MA_VLR_BAIXADO.Value = V0HCTVA_PRMVG + V0HCTVA_PRMAP;

            /*" -4384- IF V0HCTB-CODOPER = 204 */

            if (V0HCTB_CODOPER == 204)
            {

                /*" -4386- MOVE 'BAIXA EM DUPLICIDADE' TO MA-TXT-DES-OPERACAO */
                _.Move("BAIXA EM DUPLICIDADE", MAUDIT_REC.MA_TXT_DES_OPERACAO);

                /*" -4387- ELSE */
            }
            else
            {


                /*" -4388- IF V0HCTB-CODOPER = 202 */

                if (V0HCTB_CODOPER == 202)
                {

                    /*" -4390- MOVE 'BAIXA NORMAL        ' TO MA-TXT-DES-OPERACAO */
                    _.Move("BAIXA NORMAL        ", MAUDIT_REC.MA_TXT_DES_OPERACAO);

                    /*" -4391- ELSE */
                }
                else
                {


                    /*" -4392- IF V0HCTB-CODOPER = 202 */

                    if (V0HCTB_CODOPER == 202)
                    {

                        /*" -4394- MOVE 'BAIXA NORMAL        ' TO MA-TXT-DES-OPERACAO */
                        _.Move("BAIXA NORMAL        ", MAUDIT_REC.MA_TXT_DES_OPERACAO);

                        /*" -4395- ELSE */
                    }
                    else
                    {


                        /*" -4396- IF V0HCTB-CODOPER = 206 */

                        if (V0HCTB_CODOPER == 206)
                        {

                            /*" -4398- MOVE 'BAIXA A MENOR       ' TO MA-TXT-DES-OPERACAO */
                            _.Move("BAIXA A MENOR       ", MAUDIT_REC.MA_TXT_DES_OPERACAO);

                            /*" -4399- ELSE */
                        }
                        else
                        {


                            /*" -4400- IF V0HCTB-CODOPER = 207 */

                            if (V0HCTB_CODOPER == 207)
                            {

                                /*" -4403- MOVE 'BAIXA A MAIOR       ' TO MA-TXT-DES-OPERACAO. */
                                _.Move("BAIXA A MAIOR       ", MAUDIT_REC.MA_TXT_DES_OPERACAO);
                            }

                        }

                    }

                }

            }


            /*" -4405- MOVE V0HCOB-NRTIT TO MA-NUM-TITULO */
            _.Move(V0HCOB_NRTIT, MAUDIT_REC.MA_NUM_TITULO);

            /*" -4406- IF V0OPCP-OPCAOPAG = '1' */

            if (V0OPCP_OPCAOPAG == "1")
            {

                /*" -4408- MOVE 'CONTA CORRENTE' TO MA-OPCAO-PAG */
                _.Move("CONTA CORRENTE", MAUDIT_REC.MA_OPCAO_PAG);

                /*" -4409- ELSE */
            }
            else
            {


                /*" -4410- IF V0OPCP-OPCAOPAG = '2' */

                if (V0OPCP_OPCAOPAG == "2")
                {

                    /*" -4412- MOVE 'CONTA POUPANCA' TO MA-OPCAO-PAG */
                    _.Move("CONTA POUPANCA", MAUDIT_REC.MA_OPCAO_PAG);

                    /*" -4413- ELSE */
                }
                else
                {


                    /*" -4414- IF V0OPCP-OPCAOPAG = '3' */

                    if (V0OPCP_OPCAOPAG == "3")
                    {

                        /*" -4416- MOVE 'BOLETO        ' TO MA-OPCAO-PAG */
                        _.Move("BOLETO        ", MAUDIT_REC.MA_OPCAO_PAG);

                        /*" -4417- ELSE */
                    }
                    else
                    {


                        /*" -4418- IF V0OPCP-OPCAOPAG = '4' */

                        if (V0OPCP_OPCAOPAG == "4")
                        {

                            /*" -4420- MOVE 'AVERBACAO     ' TO MA-OPCAO-PAG */
                            _.Move("AVERBACAO     ", MAUDIT_REC.MA_OPCAO_PAG);

                            /*" -4421- ELSE */
                        }
                        else
                        {


                            /*" -4422- IF V0OPCP-OPCAOPAG = '5' */

                            if (V0OPCP_OPCAOPAG == "5")
                            {

                                /*" -4424- MOVE 'CARTAO        ' TO MA-OPCAO-PAG */
                                _.Move("CARTAO        ", MAUDIT_REC.MA_OPCAO_PAG);

                                /*" -4425- ELSE */
                            }
                            else
                            {


                                /*" -4428- MOVE 'OUTROS        ' TO MA-OPCAO-PAG. */
                                _.Move("OUTROS        ", MAUDIT_REC.MA_OPCAO_PAG);
                            }

                        }

                    }

                }

            }


            /*" -4429- IF V0HCOB-OPCAOPAG = '1' */

            if (V0HCOB_OPCAOPAG == "1")
            {

                /*" -4431- MOVE 'CONTA CORRENTE' TO MA-OPCAO-PAG-ORIG */
                _.Move("CONTA CORRENTE", MAUDIT_REC.MA_OPCAO_PAG_ORIG);

                /*" -4432- ELSE */
            }
            else
            {


                /*" -4433- IF V0HCOB-OPCAOPAG = '2' */

                if (V0HCOB_OPCAOPAG == "2")
                {

                    /*" -4435- MOVE 'CONTA POUPANCA' TO MA-OPCAO-PAG-ORIG */
                    _.Move("CONTA POUPANCA", MAUDIT_REC.MA_OPCAO_PAG_ORIG);

                    /*" -4436- ELSE */
                }
                else
                {


                    /*" -4437- IF V0HCOB-OPCAOPAG = '3' */

                    if (V0HCOB_OPCAOPAG == "3")
                    {

                        /*" -4439- MOVE 'BOLETO        ' TO MA-OPCAO-PAG-ORIG */
                        _.Move("BOLETO        ", MAUDIT_REC.MA_OPCAO_PAG_ORIG);

                        /*" -4440- ELSE */
                    }
                    else
                    {


                        /*" -4441- IF V0HCOB-OPCAOPAG = '4' */

                        if (V0HCOB_OPCAOPAG == "4")
                        {

                            /*" -4443- MOVE 'AVERBACAO     ' TO MA-OPCAO-PAG-ORIG */
                            _.Move("AVERBACAO     ", MAUDIT_REC.MA_OPCAO_PAG_ORIG);

                            /*" -4444- ELSE */
                        }
                        else
                        {


                            /*" -4445- IF V0HCOB-OPCAOPAG = '5' */

                            if (V0HCOB_OPCAOPAG == "5")
                            {

                                /*" -4447- MOVE 'CARTAO        ' TO MA-OPCAO-PAG-ORIG */
                                _.Move("CARTAO        ", MAUDIT_REC.MA_OPCAO_PAG_ORIG);

                                /*" -4448- ELSE */
                            }
                            else
                            {


                                /*" -4451- MOVE 'OUTROS        ' TO MA-OPCAO-PAG-ORIG. */
                                _.Move("OUTROS        ", MAUDIT_REC.MA_OPCAO_PAG_ORIG);
                            }

                        }

                    }

                }

            }


            /*" -4454- MOVE V0PROP-AGECOBR TO MA-PONTO-DE-VENDA. */
            _.Move(V0PROP_AGECOBR, MAUDIT_REC.MA_PONTO_DE_VENDA);

            /*" -4457- MOVE V0PROP-FONTE TO MA-FILIAL. */
            _.Move(V0PROP_FONTE, MAUDIT_REC.MA_FILIAL);

            /*" -4460- MOVE V0PROP-CODPRODU TO MA-PRODUTO. */
            _.Move(V0PROP_CODPRODU, MAUDIT_REC.MA_PRODUTO);

            /*" -4463- MOVE WHOST-CODCONV TO MA-CONVENIO. */
            _.Move(WHOST_CODCONV, MAUDIT_REC.MA_CONVENIO);

            /*" -4466- MOVE V0PROP-SITUACAO TO MA-SIT-REGISTRO. */
            _.Move(V0PROP_SITUACAO, MAUDIT_REC.MA_SIT_REGISTRO);

            /*" -4469- MOVE RF-IDENTIF-NSA TO MA-NSAS. */
            _.Move(RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_IDENTIF_NSA, MAUDIT_REC.MA_NSAS);

            /*" -4472- MOVE RF-IDENTIF-NSA TO MA-NSR. */
            _.Move(RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_IDENTIF_NSA, MAUDIT_REC.MA_NSR);

            /*" -4479- MOVE ';' TO MA-FILLER01, MA-FILLER02, MA-FILLER03, MA-FILLER04, MA-FILLER05, MA-FILLER06, MA-FILLER07, MA-FILLER08, MA-FILLER09, MA-FILLER10, MA-FILLER11, MA-FILLER12, MA-FILLER13, MA-FILLER14, MA-FILLER15, MA-FILLER16, MA-FILLER17, MA-FILLER18, MA-FILLER19, MA-FILLER20. */
            _.Move(";", MAUDIT_REC.MA_FILLER01, MAUDIT_REC.MA_FILLER02, MAUDIT_REC.MA_FILLER03, MAUDIT_REC.MA_FILLER04, MAUDIT_REC.MA_FILLER05, MAUDIT_REC.MA_FILLER06, MAUDIT_REC.MA_FILLER07, MAUDIT_REC.MA_FILLER08, MAUDIT_REC.MA_FILLER09, MAUDIT_REC.MA_FILLER10, MAUDIT_REC.MA_FILLER11, MAUDIT_REC.MA_FILLER12, MAUDIT_REC.MA_FILLER13, MAUDIT_REC.MA_FILLER14, MAUDIT_REC.MA_FILLER15, MAUDIT_REC.MA_FILLER16, MAUDIT_REC.MA_FILLER17, MAUDIT_REC.MA_FILLER18, MAUDIT_REC.MA_FILLER19, MAUDIT_REC.MA_FILLER20);

            /*" -4479- WRITE MAUDIT-RECORD. */
            MAUDIT.Write(MAUDIT_RECORD.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" R1000-00-QUITA-PARCELA-DB-SELECT-1 */
        public void R1000_00_QUITA_PARCELA_DB_SELECT_1()
        {
            /*" -3387- EXEC SQL SELECT PRMVG, PRMAP, PRMVG + PRMAP, IMPMORNATU, IMPMORACID, IMPDIT, QUANT_VIDAS, IMPINVPERM, IMPDH, VLCUSTCDG, VLCUSTAUXF, IMPSEGCDC, IMPSEGAUXF, VLCUSTCAP, QTTITCAP , VALUE(PRMDIT, 0) INTO :V0COBP-PRMVG, :V0COBP-PRMAP, :V0COBP-VLPREMIO, :V0COBP-IMPMORNATU, :V0COBP-IMPMORACID, :V0COBP-IMPDIT, :V0COBP-QUANT-VIDAS, :V0COBP-IMPINVPERM, :V0COBP-IMPDH, :V0COBP-VLCUSTCDG, :V0COBP-VLCUSTAUXF:V0COBP-VLCUSTAUXF-I, :V0COBP-IMPSEGCDG, :V0COBP-IMPSEGAUXF:V0COBP-IMPSEGAUXF-I, :V0COBP-VLCUSTCAP, :V0COBP-QTTITCAP, :V0COBP-PRMDIT FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :V0HCTA-NRCERTIF AND DTINIVIG <= :V0PARC-DTVENCTO AND DTTERVIG >= :V0PARC-DTVENCTO WITH UR END-EXEC. */

            var r1000_00_QUITA_PARCELA_DB_SELECT_1_Query1 = new R1000_00_QUITA_PARCELA_DB_SELECT_1_Query1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0PARC_DTVENCTO = V0PARC_DTVENCTO.ToString(),
            };

            var executed_1 = R1000_00_QUITA_PARCELA_DB_SELECT_1_Query1.Execute(r1000_00_QUITA_PARCELA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBP_PRMVG, V0COBP_PRMVG);
                _.Move(executed_1.V0COBP_PRMAP, V0COBP_PRMAP);
                _.Move(executed_1.V0COBP_VLPREMIO, V0COBP_VLPREMIO);
                _.Move(executed_1.V0COBP_IMPMORNATU, V0COBP_IMPMORNATU);
                _.Move(executed_1.V0COBP_IMPMORACID, V0COBP_IMPMORACID);
                _.Move(executed_1.V0COBP_IMPDIT, V0COBP_IMPDIT);
                _.Move(executed_1.V0COBP_QUANT_VIDAS, V0COBP_QUANT_VIDAS);
                _.Move(executed_1.V0COBP_IMPINVPERM, V0COBP_IMPINVPERM);
                _.Move(executed_1.V0COBP_IMPDH, V0COBP_IMPDH);
                _.Move(executed_1.V0COBP_VLCUSTCDG, V0COBP_VLCUSTCDG);
                _.Move(executed_1.V0COBP_VLCUSTAUXF, V0COBP_VLCUSTAUXF);
                _.Move(executed_1.V0COBP_VLCUSTAUXF_I, V0COBP_VLCUSTAUXF_I);
                _.Move(executed_1.V0COBP_IMPSEGCDG, V0COBP_IMPSEGCDG);
                _.Move(executed_1.V0COBP_IMPSEGAUXF, V0COBP_IMPSEGAUXF);
                _.Move(executed_1.V0COBP_IMPSEGAUXF_I, V0COBP_IMPSEGAUXF_I);
                _.Move(executed_1.V0COBP_VLCUSTCAP, V0COBP_VLCUSTCAP);
                _.Move(executed_1.V0COBP_QTTITCAP, V0COBP_QTTITCAP);
                _.Move(executed_1.V0COBP_PRMDIT, V0COBP_PRMDIT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-QUITA-PARCELA-DB-SELECT-2 */
        public void R1000_00_QUITA_PARCELA_DB_SELECT_2()
        {
            /*" -3440- EXEC SQL SELECT PRMVG, PRMAP, PRMVG + PRMAP, VLCUSTCDG, VLCUSTAUXF, IMPSEGCDC, IMPSEGAUXF, VLCUSTCAP, QTTITCAP, VALUE(PRMDIT, 0) INTO :V0COBP-PRMVG, :V0COBP-PRMAP, :V0COBP-VLPREMIO, :V0COBP-VLCUSTCDG, :V0COBP-VLCUSTAUXF:V0COBP-VLCUSTAUXF-I, :V0COBP-IMPSEGCDG, :V0COBP-IMPSEGAUXF:V0COBP-IMPSEGAUXF-I, :V0COBP-VLCUSTCAP, :V0COBP-QTTITCAP, :V0COBP-PRMDIT FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF =:V0HCTA-NRCERTIF AND DTTERVIG = '9999-12-31' WITH UR END-EXEC */

            var r1000_00_QUITA_PARCELA_DB_SELECT_2_Query1 = new R1000_00_QUITA_PARCELA_DB_SELECT_2_Query1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
            };

            var executed_1 = R1000_00_QUITA_PARCELA_DB_SELECT_2_Query1.Execute(r1000_00_QUITA_PARCELA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBP_PRMVG, V0COBP_PRMVG);
                _.Move(executed_1.V0COBP_PRMAP, V0COBP_PRMAP);
                _.Move(executed_1.V0COBP_VLPREMIO, V0COBP_VLPREMIO);
                _.Move(executed_1.V0COBP_VLCUSTCDG, V0COBP_VLCUSTCDG);
                _.Move(executed_1.V0COBP_VLCUSTAUXF, V0COBP_VLCUSTAUXF);
                _.Move(executed_1.V0COBP_VLCUSTAUXF_I, V0COBP_VLCUSTAUXF_I);
                _.Move(executed_1.V0COBP_IMPSEGCDG, V0COBP_IMPSEGCDG);
                _.Move(executed_1.V0COBP_IMPSEGAUXF, V0COBP_IMPSEGAUXF);
                _.Move(executed_1.V0COBP_IMPSEGAUXF_I, V0COBP_IMPSEGAUXF_I);
                _.Move(executed_1.V0COBP_VLCUSTCAP, V0COBP_VLCUSTCAP);
                _.Move(executed_1.V0COBP_QTTITCAP, V0COBP_QTTITCAP);
                _.Move(executed_1.V0COBP_PRMDIT, V0COBP_PRMDIT);
            }


        }

        [StopWatch]
        /*" R0060-00-GERA-NOVO-NRTIT-SECTION */
        private void R0060_00_GERA_NOVO_NRTIT_SECTION()
        {
            /*" -4491- MOVE 'R0060-00-GERA-NOVO-NRTIT' TO PARAGRAFO. */
            _.Move("R0060-00-GERA-NOVO-NRTIT", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4492- MOVE 49 TO W01-I */
            _.Move(49, FILLER_11.W01_I);

            /*" -4493- MOVE 'SELECT V0BANCO' TO W01-TEXTO(W01-I) */
            _.Move("SELECT V0BANCO", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -4497- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -4503- PERFORM R0060_00_GERA_NOVO_NRTIT_DB_SELECT_1 */

            R0060_00_GERA_NOVO_NRTIT_DB_SELECT_1();

            /*" -4507- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -4512- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -4513- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4514- DISPLAY 'PROBLEMAS NA V0BANCO' */
                _.Display($"PROBLEMAS NA V0BANCO");

                /*" -4515- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4517- END-IF */
            }


            /*" -4518- MOVE V0BANC-NRTIT TO W-NUMR-TITULO */
            _.Move(V0BANC_NRTIT, W_NUMR_TITULO);

            /*" -4520- ADD 1 TO WTITL-SEQUENCIA */
            FILLER_10.WTITL_SEQUENCIA.Value = FILLER_10.WTITL_SEQUENCIA + 1;

            /*" -4524- MOVE WTITL-SEQUENCIA TO DPARM01 */
            _.Move(FILLER_10.WTITL_SEQUENCIA, DPARM01X.DPARM01);

            /*" -4525- MOVE 50 TO W01-I */
            _.Move(50, FILLER_11.W01_I);

            /*" -4526- MOVE 'CALL PROTIT01 (1)' TO W01-TEXTO(W01-I) */
            _.Move("CALL PROTIT01 (1)", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -4530- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -4533- CALL 'PROTIT01' USING DPARM01X */
            _.Call("PROTIT01", DPARM01X);

            /*" -4534- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -4539- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -4540- IF DPARM01-RC NOT EQUAL +0 */

            if (DPARM01X.DPARM01_RC != +0)
            {

                /*" -4541- DISPLAY 'ERRO CHAMADA PROTIT01' */
                _.Display($"ERRO CHAMADA PROTIT01");

                /*" -4542- DISPLAY 'CERTIFICADO     ' V0HCTA-NRCERTIF */
                _.Display($"CERTIFICADO     {V0HCTA_NRCERTIF}");

                /*" -4543- DISPLAY 'AREA            ' DPARM01X */
                _.Display($"AREA            {DPARM01X}");

                /*" -4544- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4546- END-IF */
            }


            /*" -4547- MOVE DPARM01-D1 TO WTITL-DIGITO */
            _.Move(DPARM01X.DPARM01_D1, FILLER_10.WTITL_DIGITO);

            /*" -4551- MOVE W-NUMR-TITULO TO V0BANC-NRTIT */
            _.Move(W_NUMR_TITULO, V0BANC_NRTIT);

            /*" -4552- MOVE 51 TO W01-I */
            _.Move(51, FILLER_11.W01_I);

            /*" -4553- MOVE 'UPDATE V0BANCO' TO W01-TEXTO(W01-I) */
            _.Move("UPDATE V0BANCO", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -4557- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -4561- PERFORM R0060_00_GERA_NOVO_NRTIT_DB_UPDATE_1 */

            R0060_00_GERA_NOVO_NRTIT_DB_UPDATE_1();

            /*" -4565- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -4570- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -4571- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -4572- DISPLAY 'ERRO UPDATE V0BANCO 104' */
                _.Display($"ERRO UPDATE V0BANCO 104");

                /*" -4573- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4573- END-IF. */
            }


        }

        [StopWatch]
        /*" R0060-00-GERA-NOVO-NRTIT-DB-SELECT-1 */
        public void R0060_00_GERA_NOVO_NRTIT_DB_SELECT_1()
        {
            /*" -4503- EXEC SQL SELECT NRTIT INTO :V0BANC-NRTIT FROM SEGUROS.V0BANCO WHERE BANCO = 104 WITH UR END-EXEC */

            var r0060_00_GERA_NOVO_NRTIT_DB_SELECT_1_Query1 = new R0060_00_GERA_NOVO_NRTIT_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0060_00_GERA_NOVO_NRTIT_DB_SELECT_1_Query1.Execute(r0060_00_GERA_NOVO_NRTIT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0BANC_NRTIT, V0BANC_NRTIT);
            }


        }

        [StopWatch]
        /*" R0060-00-GERA-NOVO-NRTIT-DB-UPDATE-1 */
        public void R0060_00_GERA_NOVO_NRTIT_DB_UPDATE_1()
        {
            /*" -4561- EXEC SQL UPDATE SEGUROS.V0BANCO SET NRTIT = :V0BANC-NRTIT WHERE BANCO = 104 END-EXEC */

            var r0060_00_GERA_NOVO_NRTIT_DB_UPDATE_1_Update1 = new R0060_00_GERA_NOVO_NRTIT_DB_UPDATE_1_Update1()
            {
                V0BANC_NRTIT = V0BANC_NRTIT.ToString(),
            };

            R0060_00_GERA_NOVO_NRTIT_DB_UPDATE_1_Update1.Execute(r0060_00_GERA_NOVO_NRTIT_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1000-00-QUITA-PARCELA-DB-INSERT-1 */
        public void R1000_00_QUITA_PARCELA_DB_INSERT_1()
        {
            /*" -3719- EXEC SQL INSERT INTO SEGUROS.V0HISTCONTABILVA VALUES (:V0HCTA-NRCERTIF, :V0HCTA-NRPARCEL, :V0HCOB-NRTIT, :V0HCOB-OCORHIST, :V0PROP-NUM-APOLICE, :V0PROP-CODSUBES, :V0PROP-FONTE, 0, :V0HCTVA-PRMVG, :V0HCTVA-PRMAP, :V0SIST-DTMOVABE, '0' , :V0HCTB-CODOPER, CURRENT TIMESTAMP, NULL) END-EXEC. */

            var r1000_00_QUITA_PARCELA_DB_INSERT_1_Insert1 = new R1000_00_QUITA_PARCELA_DB_INSERT_1_Insert1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0HCTA_NRPARCEL = V0HCTA_NRPARCEL.ToString(),
                V0HCOB_NRTIT = V0HCOB_NRTIT.ToString(),
                V0HCOB_OCORHIST = V0HCOB_OCORHIST.ToString(),
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
                V0PROP_CODSUBES = V0PROP_CODSUBES.ToString(),
                V0PROP_FONTE = V0PROP_FONTE.ToString(),
                V0HCTVA_PRMVG = V0HCTVA_PRMVG.ToString(),
                V0HCTVA_PRMAP = V0HCTVA_PRMAP.ToString(),
                V0SIST_DTMOVABE = V0SIST_DTMOVABE.ToString(),
                V0HCTB_CODOPER = V0HCTB_CODOPER.ToString(),
            };

            R1000_00_QUITA_PARCELA_DB_INSERT_1_Insert1.Execute(r1000_00_QUITA_PARCELA_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R1000-00-QUITA-PARCELA-DB-SELECT-3 */
        public void R1000_00_QUITA_PARCELA_DB_SELECT_3()
        {
            /*" -3488- EXEC SQL SELECT PRMVG, PRMAP, PRMVG + PRMAP, VLCUSTCDG, VLCUSTAUXF, IMPSEGCDC, IMPSEGAUXF, VLCUSTCAP, QTTITCAP, VALUE(PRMDIT, 0) INTO :V0COBP-PRMVG, :V0COBP-PRMAP, :V0COBP-VLPREMIO, :V0COBP-VLCUSTCDG, :V0COBP-VLCUSTAUXF:V0COBP-VLCUSTAUXF-I, :V0COBP-IMPSEGCDG, :V0COBP-IMPSEGAUXF:V0COBP-IMPSEGAUXF-I, :V0COBP-VLCUSTCAP, :V0COBP-QTTITCAP, :V0COBP-PRMDIT FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF =:V0HCTA-NRCERTIF AND DTINIVIG <= :V0PROP-DTVENCTO AND DTTERVIG >= :V0PROP-DTVENCTO WITH UR END-EXEC */

            var r1000_00_QUITA_PARCELA_DB_SELECT_3_Query1 = new R1000_00_QUITA_PARCELA_DB_SELECT_3_Query1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0PROP_DTVENCTO = V0PROP_DTVENCTO.ToString(),
            };

            var executed_1 = R1000_00_QUITA_PARCELA_DB_SELECT_3_Query1.Execute(r1000_00_QUITA_PARCELA_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBP_PRMVG, V0COBP_PRMVG);
                _.Move(executed_1.V0COBP_PRMAP, V0COBP_PRMAP);
                _.Move(executed_1.V0COBP_VLPREMIO, V0COBP_VLPREMIO);
                _.Move(executed_1.V0COBP_VLCUSTCDG, V0COBP_VLCUSTCDG);
                _.Move(executed_1.V0COBP_VLCUSTAUXF, V0COBP_VLCUSTAUXF);
                _.Move(executed_1.V0COBP_VLCUSTAUXF_I, V0COBP_VLCUSTAUXF_I);
                _.Move(executed_1.V0COBP_IMPSEGCDG, V0COBP_IMPSEGCDG);
                _.Move(executed_1.V0COBP_IMPSEGAUXF, V0COBP_IMPSEGAUXF);
                _.Move(executed_1.V0COBP_IMPSEGAUXF_I, V0COBP_IMPSEGAUXF_I);
                _.Move(executed_1.V0COBP_VLCUSTCAP, V0COBP_VLCUSTCAP);
                _.Move(executed_1.V0COBP_QTTITCAP, V0COBP_QTTITCAP);
                _.Move(executed_1.V0COBP_PRMDIT, V0COBP_PRMDIT);
            }


        }

        [StopWatch]
        /*" R1000-00-QUITA-PARCELA-DB-UPDATE-1 */
        public void R1000_00_QUITA_PARCELA_DB_UPDATE_1()
        {
            /*" -3987- EXEC SQL UPDATE SEGUROS.V0HISTCOBVA SET SITUACAO = :V0HCTA-SITUACAO, VLPRMTOT = :V0HCTA-VLPRMTOT, OCORHIST = :V0HCOB-OCORHIST, BCOAVISO = :V0AVIS-BCOAVISO, AGEAVISO = :V0AVIS-AGEAVISO, NRAVISO = :V0AVIS-NRAVISO WHERE NRCERTIF = :V0HCTA-NRCERTIF AND NRPARCEL = :V0HCTA-NRPARCEL AND NRTIT = :V0HCOB-NRTIT END-EXEC */

            var r1000_00_QUITA_PARCELA_DB_UPDATE_1_Update1 = new R1000_00_QUITA_PARCELA_DB_UPDATE_1_Update1()
            {
                V0HCTA_SITUACAO = V0HCTA_SITUACAO.ToString(),
                V0HCTA_VLPRMTOT = V0HCTA_VLPRMTOT.ToString(),
                V0HCOB_OCORHIST = V0HCOB_OCORHIST.ToString(),
                V0AVIS_BCOAVISO = V0AVIS_BCOAVISO.ToString(),
                V0AVIS_AGEAVISO = V0AVIS_AGEAVISO.ToString(),
                V0AVIS_NRAVISO = V0AVIS_NRAVISO.ToString(),
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0HCTA_NRPARCEL = V0HCTA_NRPARCEL.ToString(),
                V0HCOB_NRTIT = V0HCOB_NRTIT.ToString(),
            };

            R1000_00_QUITA_PARCELA_DB_UPDATE_1_Update1.Execute(r1000_00_QUITA_PARCELA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0060_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-QUITA-PARCELA-DB-UPDATE-2 */
        public void R1000_00_QUITA_PARCELA_DB_UPDATE_2()
        {
            /*" -4018- EXEC SQL UPDATE SEGUROS.V0DIFPARCELVA SET SITUACAO = '1' WHERE NRCERTIF = :V0HCTA-NRCERTIF AND NRPARCEL = :V0HCTA-NRPARCEL END-EXEC */

            var r1000_00_QUITA_PARCELA_DB_UPDATE_2_Update1 = new R1000_00_QUITA_PARCELA_DB_UPDATE_2_Update1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0HCTA_NRPARCEL = V0HCTA_NRPARCEL.ToString(),
            };

            R1000_00_QUITA_PARCELA_DB_UPDATE_2_Update1.Execute(r1000_00_QUITA_PARCELA_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R1000-00-QUITA-PARCELA-DB-SELECT-4 */
        public void R1000_00_QUITA_PARCELA_DB_SELECT_4()
        {
            /*" -3535- EXEC SQL SELECT PRMVG, PRMAP, PRMVG + PRMAP, VLCUSTCDG, VLCUSTAUXF, IMPSEGCDC, IMPSEGAUXF, VLCUSTCAP, QTTITCAP, VALUE(PRMDIT, 0) INTO :V0COBP-PRMVG, :V0COBP-PRMAP, :V0COBP-VLPREMIO, :V0COBP-VLCUSTCDG, :V0COBP-VLCUSTAUXF:V0COBP-VLCUSTAUXF-I, :V0COBP-IMPSEGCDG, :V0COBP-IMPSEGAUXF:V0COBP-IMPSEGAUXF-I, :V0COBP-VLCUSTCAP, :V0COBP-QTTITCAP, :V0COBP-PRMDIT FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF =:V0HCTA-NRCERTIF AND OCORHIST = :V0PROP-OCORHIST WITH UR END-EXEC */

            var r1000_00_QUITA_PARCELA_DB_SELECT_4_Query1 = new R1000_00_QUITA_PARCELA_DB_SELECT_4_Query1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0PROP_OCORHIST = V0PROP_OCORHIST.ToString(),
            };

            var executed_1 = R1000_00_QUITA_PARCELA_DB_SELECT_4_Query1.Execute(r1000_00_QUITA_PARCELA_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBP_PRMVG, V0COBP_PRMVG);
                _.Move(executed_1.V0COBP_PRMAP, V0COBP_PRMAP);
                _.Move(executed_1.V0COBP_VLPREMIO, V0COBP_VLPREMIO);
                _.Move(executed_1.V0COBP_VLCUSTCDG, V0COBP_VLCUSTCDG);
                _.Move(executed_1.V0COBP_VLCUSTAUXF, V0COBP_VLCUSTAUXF);
                _.Move(executed_1.V0COBP_VLCUSTAUXF_I, V0COBP_VLCUSTAUXF_I);
                _.Move(executed_1.V0COBP_IMPSEGCDG, V0COBP_IMPSEGCDG);
                _.Move(executed_1.V0COBP_IMPSEGAUXF, V0COBP_IMPSEGAUXF);
                _.Move(executed_1.V0COBP_IMPSEGAUXF_I, V0COBP_IMPSEGAUXF_I);
                _.Move(executed_1.V0COBP_VLCUSTCAP, V0COBP_VLCUSTCAP);
                _.Move(executed_1.V0COBP_QTTITCAP, V0COBP_QTTITCAP);
                _.Move(executed_1.V0COBP_PRMDIT, V0COBP_PRMDIT);
            }


        }

        [StopWatch]
        /*" R1000-00-QUITA-PARCELA-DB-UPDATE-3 */
        public void R1000_00_QUITA_PARCELA_DB_UPDATE_3()
        {
            /*" -4050- EXEC SQL UPDATE SEGUROS.V0PROPOSTAVA SET QTDPARATZ = :V0PROP-QTDPARATZ WHERE NRCERTIF = :V0HCTA-NRCERTIF END-EXEC */

            var r1000_00_QUITA_PARCELA_DB_UPDATE_3_Update1 = new R1000_00_QUITA_PARCELA_DB_UPDATE_3_Update1()
            {
                V0PROP_QTDPARATZ = V0PROP_QTDPARATZ.ToString(),
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
            };

            R1000_00_QUITA_PARCELA_DB_UPDATE_3_Update1.Execute(r1000_00_QUITA_PARCELA_DB_UPDATE_3_Update1);

        }

        [StopWatch]
        /*" R1050-00-GRAVA-DIFERENCA-SECTION */
        private void R1050_00_GRAVA_DIFERENCA_SECTION()
        {
            /*" -4587- MOVE 'R1050-00-GRAVA-DIFERENCA' TO PARAGRAFO. */
            _.Move("R1050-00-GRAVA-DIFERENCA", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4587- MOVE V0HCTA-NRPARCEL TO V0DIFP-NRPARCEL. */
            _.Move(V0HCTA_NRPARCEL, V0DIFP_NRPARCEL);

            /*" -0- FLUXCONTROL_PERFORM R1050_00_LOOP */

            R1050_00_LOOP();

        }

        [StopWatch]
        /*" R1000-00-QUITA-PARCELA-DB-UPDATE-4 */
        public void R1000_00_QUITA_PARCELA_DB_UPDATE_4()
        {
            /*" -4088- EXEC SQL UPDATE SEGUROS.V0PROPOSTAVA SET SITUACAO = '0' , DTQITBCO = CASE WHEN :WHOST-ORIGEM-PROPOSTA = 1004 THEN DTQITBCO ELSE :V0PARC-DTVENCTO END WHERE NRCERTIF = :V0HCTA-NRCERTIF END-EXEC */

            var r1000_00_QUITA_PARCELA_DB_UPDATE_4_Update1 = new R1000_00_QUITA_PARCELA_DB_UPDATE_4_Update1()
            {
                WHOST_ORIGEM_PROPOSTA = WHOST_ORIGEM_PROPOSTA.ToString(),
                V0PARC_DTVENCTO = V0PARC_DTVENCTO.ToString(),
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
            };

            R1000_00_QUITA_PARCELA_DB_UPDATE_4_Update1.Execute(r1000_00_QUITA_PARCELA_DB_UPDATE_4_Update1);

        }

        [StopWatch]
        /*" R1000-00-QUITA-PARCELA-DB-SELECT-5 */
        public void R1000_00_QUITA_PARCELA_DB_SELECT_5()
        {
            /*" -3765- EXEC SQL SELECT DATA_NASCIMENTO, CGCCPF, TIPO_PESSOA INTO :CLIENTES-DATA-NASCIMENTO :VIND-DATSEL, :CLIENTES-CGCCPF, :CLIENTES-TIPO-PESSOA FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :V0PROP-CODCLIEN WITH UR END-EXEC. */

            var r1000_00_QUITA_PARCELA_DB_SELECT_5_Query1 = new R1000_00_QUITA_PARCELA_DB_SELECT_5_Query1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
            };

            var executed_1 = R1000_00_QUITA_PARCELA_DB_SELECT_5_Query1.Execute(r1000_00_QUITA_PARCELA_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_DATA_NASCIMENTO, CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO);
                _.Move(executed_1.VIND_DATSEL, VIND_DATSEL);
                _.Move(executed_1.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
                _.Move(executed_1.CLIENTES_TIPO_PESSOA, CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA);
            }


        }

        [StopWatch]
        /*" R1000-00-QUITA-PARCELA-DB-UPDATE-5 */
        public void R1000_00_QUITA_PARCELA_DB_UPDATE_5()
        {
            /*" -4123- EXEC SQL UPDATE SEGUROS.V0PROPOSTAVA SET SITUACAO = '3' , NRPRIPARATZ = 0 , QTDPARATZ = 0 WHERE NRCERTIF = :V0HCTA-NRCERTIF END-EXEC */

            var r1000_00_QUITA_PARCELA_DB_UPDATE_5_Update1 = new R1000_00_QUITA_PARCELA_DB_UPDATE_5_Update1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
            };

            R1000_00_QUITA_PARCELA_DB_UPDATE_5_Update1.Execute(r1000_00_QUITA_PARCELA_DB_UPDATE_5_Update1);

        }

        [StopWatch]
        /*" R1050-00-LOOP */
        private void R1050_00_LOOP(bool isPerform = false)
        {
            /*" -4596- MOVE 'INSERT V0DIFPARCELVA' TO COMANDO. */
            _.Move("INSERT V0DIFPARCELVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -4597- MOVE 52 TO W01-I */
            _.Move(52, FILLER_11.W01_I);

            /*" -4599- MOVE 'INSERT V0DIFPARCELVA' TO W01-TEXTO(W01-I) */
            _.Move("INSERT V0DIFPARCELVA", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -4603- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -4618- PERFORM R1050_00_LOOP_DB_INSERT_1 */

            R1050_00_LOOP_DB_INSERT_1();

            /*" -4622- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -4627- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -4628- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -4630- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -4635- ADD 10 TO V0DIFP-CODOPER */
                    V0DIFP_CODOPER.Value = V0DIFP_CODOPER + 10;

                    /*" -4636- MOVE 53 TO W01-I */
                    _.Move(53, FILLER_11.W01_I);

                    /*" -4638- MOVE 'SELECT V0PARCELVA' TO W01-TEXTO(W01-I) */
                    _.Move("SELECT V0PARCELVA", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

                    /*" -4651- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

                    R8900_TOTALIZA_INICIO_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


                    /*" -4652- MOVE 1 TO W01-QTD-ACC-OK */
                    _.Move(1, FILLER_11.W01_QTD_ACC_OK);

                    /*" -4659- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

                    R8910_TOTALIZA_FINAL_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


                    /*" -4660- GO TO R1050-00-LOOP */
                    new Task(() => R1050_00_LOOP()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -4661- ELSE */
                }
                else
                {


                    /*" -4668- DISPLAY 'VA0813B - PROBLEMAS NO INSERT V0DIFPARCELVA  ' V0HCTA-NRCERTIF ' ' V0HCTA-NRPARCEL ' ' V0HCOB-NRTIT ' ' V0PROP-CODCLIEN ' ' WHOST-CODCONV ' ' V0HCTA-NSAS */

                    $"VA0813B - PROBLEMAS NO INSERT V0DIFPARCELVA  {V0HCTA_NRCERTIF} {V0HCTA_NRPARCEL} {V0HCOB_NRTIT} {V0PROP_CODCLIEN} {WHOST_CODCONV} {V0HCTA_NSAS}"
                    .Display();

                    /*" -4668- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1050-00-LOOP-DB-INSERT-1 */
        public void R1050_00_LOOP_DB_INSERT_1()
        {
            /*" -4618- EXEC SQL INSERT INTO SEGUROS.V0DIFPARCELVA VALUES (:V0HCTA-NRCERTIF, 9999, :V0DIFP-NRPARCEL, :V0DIFP-CODOPER, :V0PARC-DTVENCTO, :V0DIFP-PRMDEVVG, :V0DIFP-PRMDEVAP, :V0DIFP-PRMPAGVG, :V0DIFP-PRMPAGAP, :V0DIFP-PRMDIFVG, :V0DIFP-PRMDIFAP, 0, ' ' ) END-EXEC. */

            var r1050_00_LOOP_DB_INSERT_1_Insert1 = new R1050_00_LOOP_DB_INSERT_1_Insert1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0DIFP_NRPARCEL = V0DIFP_NRPARCEL.ToString(),
                V0DIFP_CODOPER = V0DIFP_CODOPER.ToString(),
                V0PARC_DTVENCTO = V0PARC_DTVENCTO.ToString(),
                V0DIFP_PRMDEVVG = V0DIFP_PRMDEVVG.ToString(),
                V0DIFP_PRMDEVAP = V0DIFP_PRMDEVAP.ToString(),
                V0DIFP_PRMPAGVG = V0DIFP_PRMPAGVG.ToString(),
                V0DIFP_PRMPAGAP = V0DIFP_PRMPAGAP.ToString(),
                V0DIFP_PRMDIFVG = V0DIFP_PRMDIFVG.ToString(),
                V0DIFP_PRMDIFAP = V0DIFP_PRMDIFAP.ToString(),
            };

            R1050_00_LOOP_DB_INSERT_1_Insert1.Execute(r1050_00_LOOP_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R1000-00-QUITA-PARCELA-DB-SELECT-6 */
        public void R1000_00_QUITA_PARCELA_DB_SELECT_6()
        {
            /*" -4156- EXEC SQL SELECT VLCUSTCDG INTO :V0CDGC-VLCUSTCDG FROM SEGUROS.V0CDGCOBER WHERE CODCLIEN = :V0PROP-CODCLIEN AND DTTERVIG = '9999-12-31' WITH UR END-EXEC. */

            var r1000_00_QUITA_PARCELA_DB_SELECT_6_Query1 = new R1000_00_QUITA_PARCELA_DB_SELECT_6_Query1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
            };

            var executed_1 = R1000_00_QUITA_PARCELA_DB_SELECT_6_Query1.Execute(r1000_00_QUITA_PARCELA_DB_SELECT_6_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CDGC_VLCUSTCDG, V0CDGC_VLCUSTCDG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1050_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-QUITA-PARCELA-DB-UPDATE-6 */
        public void R1000_00_QUITA_PARCELA_DB_UPDATE_6()
        {
            /*" -4259- EXEC SQL UPDATE SEGUROS.V0FITASASSE SET TOT_DEB_EFET = TOT_DEB_EFET + :V0HCTA-VLPRMTOT, QTDE_LANC_DEB_RET = QTDE_LANC_DEB_RET + 1 WHERE COD_CONVENIO = :WHOST-CODCONV AND NSAS = :WHOST-NSAS END-EXEC. */

            var r1000_00_QUITA_PARCELA_DB_UPDATE_6_Update1 = new R1000_00_QUITA_PARCELA_DB_UPDATE_6_Update1()
            {
                V0HCTA_VLPRMTOT = V0HCTA_VLPRMTOT.ToString(),
                WHOST_CODCONV = WHOST_CODCONV.ToString(),
                WHOST_NSAS = WHOST_NSAS.ToString(),
            };

            R1000_00_QUITA_PARCELA_DB_UPDATE_6_Update1.Execute(r1000_00_QUITA_PARCELA_DB_UPDATE_6_Update1);

        }

        [StopWatch]
        /*" R1000-00-QUITA-PARCELA-DB-SELECT-7 */
        public void R1000_00_QUITA_PARCELA_DB_SELECT_7()
        {
            /*" -4204- EXEC SQL SELECT VLCUSTAUX INTO :V0SAFC-VLCUSTSAF FROM SEGUROS.V0SAFCOBER WHERE CODCLIEN = :V0PROP-CODCLIEN AND DTTERVIG = '9999-12-31' WITH UR END-EXEC. */

            var r1000_00_QUITA_PARCELA_DB_SELECT_7_Query1 = new R1000_00_QUITA_PARCELA_DB_SELECT_7_Query1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
            };

            var executed_1 = R1000_00_QUITA_PARCELA_DB_SELECT_7_Query1.Execute(r1000_00_QUITA_PARCELA_DB_SELECT_7_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SAFC_VLCUSTSAF, V0SAFC_VLCUSTSAF);
            }


        }

        [StopWatch]
        /*" R1000-00-QUITA-PARCELA-DB-UPDATE-7 */
        public void R1000_00_QUITA_PARCELA_DB_UPDATE_7()
        {
            /*" -4301- EXEC SQL UPDATE SEGUROS.V0PARCELCAPVG SET SITPARCEL = '1' , TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :V0HCTA-NRCERTIF AND NRPARCEL = :V0CAPI-NRPARCEL AND SITPARCEL = '3' END-EXEC. */

            var r1000_00_QUITA_PARCELA_DB_UPDATE_7_Update1 = new R1000_00_QUITA_PARCELA_DB_UPDATE_7_Update1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0CAPI_NRPARCEL = V0CAPI_NRPARCEL.ToString(),
            };

            R1000_00_QUITA_PARCELA_DB_UPDATE_7_Update1.Execute(r1000_00_QUITA_PARCELA_DB_UPDATE_7_Update1);

        }

        [StopWatch]
        /*" R1099-00-INCLUI-CDG-SECTION */
        private void R1099_00_INCLUI_CDG_SECTION()
        {
            /*" -4679- MOVE 'R1099-00-INCLUI-CDG' TO PARAGRAFO. */
            _.Move("R1099-00-INCLUI-CDG", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4681- IF V0COBP-VLCUSTCDG > ZEROS NEXT SENTENCE */

            if (V0COBP_VLCUSTCDG > 00)
            {

                /*" -4682- ELSE */
            }
            else
            {


                /*" -4686- GO TO R1099-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1099_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4687- MOVE V0PARC-DTVENCTO TO DATA-SQL. */
            _.Move(V0PARC_DTVENCTO, WORK_AREA.DATA_SQL);

            /*" -4689- MOVE 01 TO DIA-SQL. */
            _.Move(01, WORK_AREA.DATA_SQL.DIA_SQL);

            /*" -4690- IF V0PRVG-RISCO = '1' */

            if (V0PRVG_RISCO == "1")
            {

                /*" -4691- ADD V0OPCP-PERIPGTO TO MES-SQL */
                WORK_AREA.DATA_SQL.MES_SQL.Value = WORK_AREA.DATA_SQL.MES_SQL + V0OPCP_PERIPGTO;

                /*" -4692- IF MES-SQL > 12 */

                if (WORK_AREA.DATA_SQL.MES_SQL > 12)
                {

                    /*" -4693- COMPUTE MES-SQL = MES-SQL - 12 */
                    WORK_AREA.DATA_SQL.MES_SQL.Value = WORK_AREA.DATA_SQL.MES_SQL - 12;

                    /*" -4695- ADD 1 TO ANO-SQL. */
                    WORK_AREA.DATA_SQL.ANO_SQL.Value = WORK_AREA.DATA_SQL.ANO_SQL + 1;
                }

            }


            /*" -4697- MOVE DATA-SQL TO V0RCDG-DTREFER. */
            _.Move(WORK_AREA.DATA_SQL, V0RCDG_DTREFER);

            /*" -4703- MOVE 'INSERT V0CDGCOBER  ' TO COMANDO. */
            _.Move("INSERT V0CDGCOBER  ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -4704- MOVE 54 TO W01-I */
            _.Move(54, FILLER_11.W01_I);

            /*" -4705- MOVE 'INSERT V0CDGCOBER' TO W01-TEXTO(W01-I) */
            _.Move("INSERT V0CDGCOBER", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -4709- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -4721- PERFORM R1099_00_INCLUI_CDG_DB_INSERT_1 */

            R1099_00_INCLUI_CDG_DB_INSERT_1();

            /*" -4725- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -4730- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -4731- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -4738- DISPLAY 'VA0813B - PROBLEMAS NO INSERT V0CDGCOBER     ' V0HCTA-NRCERTIF ' ' V0HCTA-NRPARCEL ' ' V0HCOB-NRTIT ' ' V0PROP-CODCLIEN ' ' WHOST-CODCONV ' ' V0HCTA-NSAS */

                $"VA0813B - PROBLEMAS NO INSERT V0CDGCOBER     {V0HCTA_NRCERTIF} {V0HCTA_NRPARCEL} {V0HCOB_NRTIT} {V0PROP_CODCLIEN} {WHOST_CODCONV} {V0HCTA_NSAS}"
                .Display();

                /*" -4740- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4742- MOVE V0COBP-VLCUSTCDG TO V0CDGC-VLCUSTCDG. */
            _.Move(V0COBP_VLCUSTCDG, V0CDGC_VLCUSTCDG);

            /*" -4742- PERFORM R1100-00-REPASSA-CDG. */

            R1100_00_REPASSA_CDG_SECTION();

        }

        [StopWatch]
        /*" R1099-00-INCLUI-CDG-DB-INSERT-1 */
        public void R1099_00_INCLUI_CDG_DB_INSERT_1()
        {
            /*" -4721- EXEC SQL INSERT INTO SEGUROS.V0CDGCOBER VALUES (:V0PROP-CODCLIEN, :V0RCDG-DTREFER, '9999-12-31' , :V0COBP-IMPSEGCDG, :V0COBP-VLCUSTCDG, :V0HCTA-NRCERTIF, 0, '0' , 'VA0813B' , CURRENT TIMESTAMP) END-EXEC. */

            var r1099_00_INCLUI_CDG_DB_INSERT_1_Insert1 = new R1099_00_INCLUI_CDG_DB_INSERT_1_Insert1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0RCDG_DTREFER = V0RCDG_DTREFER.ToString(),
                V0COBP_IMPSEGCDG = V0COBP_IMPSEGCDG.ToString(),
                V0COBP_VLCUSTCDG = V0COBP_VLCUSTCDG.ToString(),
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
            };

            R1099_00_INCLUI_CDG_DB_INSERT_1_Insert1.Execute(r1099_00_INCLUI_CDG_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R1000-00-QUITA-PARCELA-DB-SELECT-8 */
        public void R1000_00_QUITA_PARCELA_DB_SELECT_8()
        {
            /*" -4341- EXEC SQL SELECT DATA_GERACAO INTO :V0FITA-DATA-GERACAO FROM SEGUROS.V0FITASASSE WHERE COD_CONVENIO = :WHOST-CODCONV AND NSAS = :V0HCTA-NSAS WITH UR END-EXEC. */

            var r1000_00_QUITA_PARCELA_DB_SELECT_8_Query1 = new R1000_00_QUITA_PARCELA_DB_SELECT_8_Query1()
            {
                WHOST_CODCONV = WHOST_CODCONV.ToString(),
                V0HCTA_NSAS = V0HCTA_NSAS.ToString(),
            };

            var executed_1 = R1000_00_QUITA_PARCELA_DB_SELECT_8_Query1.Execute(r1000_00_QUITA_PARCELA_DB_SELECT_8_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0FITA_DATA_GERACAO, V0FITA_DATA_GERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1099_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-REPASSA-CDG-SECTION */
        private void R1100_00_REPASSA_CDG_SECTION()
        {
            /*" -4753- MOVE 'R1100-00-REPASSA-CDG' TO PARAGRAFO. */
            _.Move("R1100-00-REPASSA-CDG", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4755- IF V0COBP-VLCUSTCDG > ZEROS NEXT SENTENCE */

            if (V0COBP_VLCUSTCDG > 00)
            {

                /*" -4756- ELSE */
            }
            else
            {


                /*" -4760- GO TO R1100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4761- MOVE V0PARC-DTVENCTO TO DATA-SQL. */
            _.Move(V0PARC_DTVENCTO, WORK_AREA.DATA_SQL);

            /*" -4763- MOVE 01 TO DIA-SQL. */
            _.Move(01, WORK_AREA.DATA_SQL.DIA_SQL);

            /*" -4764- IF V0PRVG-RISCO = '1' */

            if (V0PRVG_RISCO == "1")
            {

                /*" -4765- ADD V0OPCP-PERIPGTO TO MES-SQL */
                WORK_AREA.DATA_SQL.MES_SQL.Value = WORK_AREA.DATA_SQL.MES_SQL + V0OPCP_PERIPGTO;

                /*" -4766- IF MES-SQL > 12 */

                if (WORK_AREA.DATA_SQL.MES_SQL > 12)
                {

                    /*" -4767- COMPUTE MES-SQL = MES-SQL - 12 */
                    WORK_AREA.DATA_SQL.MES_SQL.Value = WORK_AREA.DATA_SQL.MES_SQL - 12;

                    /*" -4769- ADD 1 TO ANO-SQL. */
                    WORK_AREA.DATA_SQL.ANO_SQL.Value = WORK_AREA.DATA_SQL.ANO_SQL + 1;
                }

            }


            /*" -4771- MOVE DATA-SQL TO V0RCDG-DTREFER. */
            _.Move(WORK_AREA.DATA_SQL, V0RCDG_DTREFER);

            /*" -4777- MOVE 'SELECT V0REPASSECDG' TO COMANDO. */
            _.Move("SELECT V0REPASSECDG", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -4778- MOVE 55 TO W01-I */
            _.Move(55, FILLER_11.W01_I);

            /*" -4780- MOVE 'SELECT V0REPASSECDG' TO W01-TEXTO(W01-I) */
            _.Move("SELECT V0REPASSECDG", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -4784- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -4791- PERFORM R1100_00_REPASSA_CDG_DB_SELECT_1 */

            R1100_00_REPASSA_CDG_DB_SELECT_1();

            /*" -4795- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -4800- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -4801- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -4802- GO TO R1100-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/ //GOTO
                return;

                /*" -4804- END-IF. */
            }


            /*" -4806- IF SQLCODE EQUAL 100 NEXT SENTENCE */

            if (DB.SQLCODE == 100)
            {

                /*" -4807- ELSE */
            }
            else
            {


                /*" -4814- DISPLAY 'VA0813B - PROBLEMAS NO SELECT V0REPASSECDG ' V0HCTA-NRCERTIF ' ' V0HCTA-NRPARCEL ' ' V0HCOB-NRTIT ' ' V0PROP-CODCLIEN ' ' WHOST-CODCONV ' ' V0HCTA-NSAS */

                $"VA0813B - PROBLEMAS NO SELECT V0REPASSECDG {V0HCTA_NRCERTIF} {V0HCTA_NRPARCEL} {V0HCOB_NRTIT} {V0PROP_CODCLIEN} {WHOST_CODCONV} {V0HCTA_NSAS}"
                .Display();

                /*" -4815- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4817- END-IF. */
            }


            /*" -4823- MOVE 'INSERT V0REPASSECDG' TO COMANDO. */
            _.Move("INSERT V0REPASSECDG", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -4824- MOVE 56 TO W01-I */
            _.Move(56, FILLER_11.W01_I);

            /*" -4826- MOVE 'INSERT V0REPASSECDG' TO W01-TEXTO(W01-I) */
            _.Move("INSERT V0REPASSECDG", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -4830- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -4840- PERFORM R1100_00_REPASSA_CDG_DB_INSERT_1 */

            R1100_00_REPASSA_CDG_DB_INSERT_1();

            /*" -4844- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -4849- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -4850- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -4857- DISPLAY 'VA0813B - PROBLEMAS NO INSERT V0REPASSECDG   ' V0HCTA-NRCERTIF ' ' V0HCTA-NRPARCEL ' ' V0HCOB-NRTIT ' ' V0PROP-CODCLIEN ' ' WHOST-CODCONV ' ' V0HCTA-NSAS */

                $"VA0813B - PROBLEMAS NO INSERT V0REPASSECDG   {V0HCTA_NRCERTIF} {V0HCTA_NRPARCEL} {V0HCOB_NRTIT} {V0PROP_CODCLIEN} {WHOST_CODCONV} {V0HCTA_NSAS}"
                .Display();

                /*" -4857- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1100-00-REPASSA-CDG-DB-SELECT-1 */
        public void R1100_00_REPASSA_CDG_DB_SELECT_1()
        {
            /*" -4791- EXEC SQL SELECT SITUACAO INTO :V0RCDG-SITUACAO FROM SEGUROS.V0REPASSECDG WHERE CODCLIEN = :V0PROP-CODCLIEN AND DTREFER = :V0RCDG-DTREFER WITH UR END-EXEC. */

            var r1100_00_REPASSA_CDG_DB_SELECT_1_Query1 = new R1100_00_REPASSA_CDG_DB_SELECT_1_Query1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0RCDG_DTREFER = V0RCDG_DTREFER.ToString(),
            };

            var executed_1 = R1100_00_REPASSA_CDG_DB_SELECT_1_Query1.Execute(r1100_00_REPASSA_CDG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RCDG_SITUACAO, V0RCDG_SITUACAO);
            }


        }

        [StopWatch]
        /*" R1100-00-REPASSA-CDG-DB-INSERT-1 */
        public void R1100_00_REPASSA_CDG_DB_INSERT_1()
        {
            /*" -4840- EXEC SQL INSERT INTO SEGUROS.V0REPASSECDG VALUES (:V0PROP-CODCLIEN, :V0RCDG-DTREFER, :V0CDGC-VLCUSTCDG, :V0HCTA-NRCERTIF, :V0HCTA-NRPARCEL, '0' , :V0SIST-DTMOVABE, CURRENT TIMESTAMP) END-EXEC. */

            var r1100_00_REPASSA_CDG_DB_INSERT_1_Insert1 = new R1100_00_REPASSA_CDG_DB_INSERT_1_Insert1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0RCDG_DTREFER = V0RCDG_DTREFER.ToString(),
                V0CDGC_VLCUSTCDG = V0CDGC_VLCUSTCDG.ToString(),
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0HCTA_NRPARCEL = V0HCTA_NRPARCEL.ToString(),
                V0SIST_DTMOVABE = V0SIST_DTMOVABE.ToString(),
            };

            R1100_00_REPASSA_CDG_DB_INSERT_1_Insert1.Execute(r1100_00_REPASSA_CDG_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1199-00-INCLUI-SAF-SECTION */
        private void R1199_00_INCLUI_SAF_SECTION()
        {
            /*" -4868- MOVE 'R1199-00-INCLUI-SAF' TO PARAGRAFO. */
            _.Move("R1199-00-INCLUI-SAF", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4870- IF V0COBP-VLCUSTAUXF > ZEROS NEXT SENTENCE */

            if (V0COBP_VLCUSTAUXF > 00)
            {

                /*" -4871- ELSE */
            }
            else
            {


                /*" -4875- GO TO R1199-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1199_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4876- MOVE V0PARC-DTVENCTO TO DATA-SQL. */
            _.Move(V0PARC_DTVENCTO, WORK_AREA.DATA_SQL);

            /*" -4878- MOVE 01 TO DIA-SQL. */
            _.Move(01, WORK_AREA.DATA_SQL.DIA_SQL);

            /*" -4879- IF V0PRVG-RISCO = '1' */

            if (V0PRVG_RISCO == "1")
            {

                /*" -4880- ADD V0OPCP-PERIPGTO TO MES-SQL */
                WORK_AREA.DATA_SQL.MES_SQL.Value = WORK_AREA.DATA_SQL.MES_SQL + V0OPCP_PERIPGTO;

                /*" -4881- IF MES-SQL > 12 */

                if (WORK_AREA.DATA_SQL.MES_SQL > 12)
                {

                    /*" -4882- COMPUTE MES-SQL = MES-SQL - 12 */
                    WORK_AREA.DATA_SQL.MES_SQL.Value = WORK_AREA.DATA_SQL.MES_SQL - 12;

                    /*" -4884- ADD 1 TO ANO-SQL. */
                    WORK_AREA.DATA_SQL.ANO_SQL.Value = WORK_AREA.DATA_SQL.ANO_SQL + 1;
                }

            }


            /*" -4886- MOVE DATA-SQL TO V0RSAF-DTREFER. */
            _.Move(WORK_AREA.DATA_SQL, V0RSAF_DTREFER);

            /*" -4892- MOVE 'INSERT V0SAFCOBER' TO COMANDO. */
            _.Move("INSERT V0SAFCOBER", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -4893- MOVE 57 TO W01-I */
            _.Move(57, FILLER_11.W01_I);

            /*" -4894- MOVE 'INSERT V0SAFCOBER' TO W01-TEXTO(W01-I) */
            _.Move("INSERT V0SAFCOBER", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -4898- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -4910- PERFORM R1199_00_INCLUI_SAF_DB_INSERT_1 */

            R1199_00_INCLUI_SAF_DB_INSERT_1();

            /*" -4914- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -4919- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -4920- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -4927- DISPLAY 'VA0813B - PROBLEMAS NO INSERT V0SAFCOBER     ' V0HCTA-NRCERTIF ' ' V0HCTA-NRPARCEL ' ' V0HCOB-NRTIT ' ' V0PROP-CODCLIEN ' ' WHOST-CODCONV ' ' V0HCTA-NSAS */

                $"VA0813B - PROBLEMAS NO INSERT V0SAFCOBER     {V0HCTA_NRCERTIF} {V0HCTA_NRPARCEL} {V0HCOB_NRTIT} {V0PROP_CODCLIEN} {WHOST_CODCONV} {V0HCTA_NSAS}"
                .Display();

                /*" -4929- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4931- MOVE V0COBP-VLCUSTAUXF TO V0SAFC-VLCUSTSAF. */
            _.Move(V0COBP_VLCUSTAUXF, V0SAFC_VLCUSTSAF);

            /*" -4937- MOVE 'SELECT V0HISTREPSAF - 102' TO COMANDO. */
            _.Move("SELECT V0HISTREPSAF - 102", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -4938- MOVE 58 TO W01-I */
            _.Move(58, FILLER_11.W01_I);

            /*" -4940- MOVE 'SELECT V0HISTREPSAF' TO W01-TEXTO(W01-I) */
            _.Move("SELECT V0HISTREPSAF", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -4944- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -4952- PERFORM R1199_00_INCLUI_SAF_DB_SELECT_1 */

            R1199_00_INCLUI_SAF_DB_SELECT_1();

            /*" -4956- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -4961- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -4962- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -4964- GO TO R1199-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1199_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4966- IF SQLCODE EQUAL 100 NEXT SENTENCE */

            if (DB.SQLCODE == 100)
            {

                /*" -4967- ELSE */
            }
            else
            {


                /*" -4974- DISPLAY 'VA0813B - PROBLEMAS NO SELECT V0HISTREPSAF   ' V0HCTA-NRCERTIF ' ' V0HCTA-NRPARCEL ' ' V0HCOB-NRTIT ' ' V0PROP-CODCLIEN ' ' WHOST-CODCONV ' ' V0HCTA-NSAS */

                $"VA0813B - PROBLEMAS NO SELECT V0HISTREPSAF   {V0HCTA_NRCERTIF} {V0HCTA_NRPARCEL} {V0HCOB_NRTIT} {V0PROP_CODCLIEN} {WHOST_CODCONV} {V0HCTA_NSAS}"
                .Display();

                /*" -4976- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4982- MOVE 'INSERT V0HISTREPSAF - 102' TO COMANDO. */
            _.Move("INSERT V0HISTREPSAF - 102", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -4983- MOVE 59 TO W01-I */
            _.Move(59, FILLER_11.W01_I);

            /*" -4985- MOVE 'INSERT V0HISTREPSAF' TO W01-TEXTO(W01-I) */
            _.Move("INSERT V0HISTREPSAF", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -4989- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -5005- PERFORM R1199_00_INCLUI_SAF_DB_INSERT_2 */

            R1199_00_INCLUI_SAF_DB_INSERT_2();

            /*" -5009- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -5014- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -5015- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -5022- DISPLAY 'VA0813B - PROBLEMAS NO INSERT V0HISTREPSAV102' V0HCTA-NRCERTIF ' ' V0HCTA-NRPARCEL ' ' V0HCOB-NRTIT ' ' V0PROP-CODCLIEN ' ' WHOST-CODCONV ' ' V0HCTA-NSAS */

                $"VA0813B - PROBLEMAS NO INSERT V0HISTREPSAV102{V0HCTA_NRCERTIF} {V0HCTA_NRPARCEL} {V0HCOB_NRTIT} {V0PROP_CODCLIEN} {WHOST_CODCONV} {V0HCTA_NSAS}"
                .Display();

                /*" -5024- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5024- PERFORM R1200-00-REPASSA-SAF. */

            R1200_00_REPASSA_SAF_SECTION();

        }

        [StopWatch]
        /*" R1199-00-INCLUI-SAF-DB-INSERT-1 */
        public void R1199_00_INCLUI_SAF_DB_INSERT_1()
        {
            /*" -4910- EXEC SQL INSERT INTO SEGUROS.V0SAFCOBER VALUES (:V0PROP-CODCLIEN, :V0RSAF-DTREFER, '9999-12-31' , :V0COBP-IMPSEGAUXF, :V0COBP-VLCUSTAUXF, :V0HCTA-NRCERTIF, 0, '0' , 'VA0813B' , CURRENT TIMESTAMP) END-EXEC. */

            var r1199_00_INCLUI_SAF_DB_INSERT_1_Insert1 = new R1199_00_INCLUI_SAF_DB_INSERT_1_Insert1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0RSAF_DTREFER = V0RSAF_DTREFER.ToString(),
                V0COBP_IMPSEGAUXF = V0COBP_IMPSEGAUXF.ToString(),
                V0COBP_VLCUSTAUXF = V0COBP_VLCUSTAUXF.ToString(),
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
            };

            R1199_00_INCLUI_SAF_DB_INSERT_1_Insert1.Execute(r1199_00_INCLUI_SAF_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R1199-00-INCLUI-SAF-DB-SELECT-1 */
        public void R1199_00_INCLUI_SAF_DB_SELECT_1()
        {
            /*" -4952- EXEC SQL SELECT SITUACAO INTO :V0RSAF-SITUACAO FROM SEGUROS.V0HISTREPSAF WHERE CODCLIEN = :V0PROP-CODCLIEN AND DTREF = :V0RSAF-DTREFER AND CODOPER = 102 WITH UR END-EXEC. */

            var r1199_00_INCLUI_SAF_DB_SELECT_1_Query1 = new R1199_00_INCLUI_SAF_DB_SELECT_1_Query1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0RSAF_DTREFER = V0RSAF_DTREFER.ToString(),
            };

            var executed_1 = R1199_00_INCLUI_SAF_DB_SELECT_1_Query1.Execute(r1199_00_INCLUI_SAF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RSAF_SITUACAO, V0RSAF_SITUACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1199_99_SAIDA*/

        [StopWatch]
        /*" R1199-00-INCLUI-SAF-DB-INSERT-2 */
        public void R1199_00_INCLUI_SAF_DB_INSERT_2()
        {
            /*" -5005- EXEC SQL INSERT INTO SEGUROS.V0HISTREPSAF VALUES (:V0PROP-CODCLIEN, :V0RSAF-DTREFER, :V0HCTA-NRCERTIF, :V0HCTA-NRPARCEL, :V0PROP-NRMATRFUN, :V0SAFC-VLCUSTSAF, 102, '0' , '0' , 0, 0, 'VA0813B' , CURRENT TIMESTAMP, :V0PARC-DTVENCTO:VIND-DTMOVTO) END-EXEC. */

            var r1199_00_INCLUI_SAF_DB_INSERT_2_Insert1 = new R1199_00_INCLUI_SAF_DB_INSERT_2_Insert1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0RSAF_DTREFER = V0RSAF_DTREFER.ToString(),
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0HCTA_NRPARCEL = V0HCTA_NRPARCEL.ToString(),
                V0PROP_NRMATRFUN = V0PROP_NRMATRFUN.ToString(),
                V0SAFC_VLCUSTSAF = V0SAFC_VLCUSTSAF.ToString(),
                V0PARC_DTVENCTO = V0PARC_DTVENCTO.ToString(),
                VIND_DTMOVTO = VIND_DTMOVTO.ToString(),
            };

            R1199_00_INCLUI_SAF_DB_INSERT_2_Insert1.Execute(r1199_00_INCLUI_SAF_DB_INSERT_2_Insert1);

        }

        [StopWatch]
        /*" R1200-00-REPASSA-SAF-SECTION */
        private void R1200_00_REPASSA_SAF_SECTION()
        {
            /*" -5035- MOVE 'R1200-00-REPASSA-SAF' TO PARAGRAFO. */
            _.Move("R1200-00-REPASSA-SAF", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5037- IF V0COBP-VLCUSTAUXF > ZEROS NEXT SENTENCE */

            if (V0COBP_VLCUSTAUXF > 00)
            {

                /*" -5038- ELSE */
            }
            else
            {


                /*" -5042- GO TO R1200-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/ //GOTO
                return;
            }


            /*" -5043- MOVE V0PARC-DTVENCTO TO DATA-SQL. */
            _.Move(V0PARC_DTVENCTO, WORK_AREA.DATA_SQL);

            /*" -5045- MOVE 01 TO DIA-SQL. */
            _.Move(01, WORK_AREA.DATA_SQL.DIA_SQL);

            /*" -5046- IF V0PRVG-RISCO = '1' */

            if (V0PRVG_RISCO == "1")
            {

                /*" -5047- ADD V0OPCP-PERIPGTO TO MES-SQL */
                WORK_AREA.DATA_SQL.MES_SQL.Value = WORK_AREA.DATA_SQL.MES_SQL + V0OPCP_PERIPGTO;

                /*" -5048- IF MES-SQL > 12 */

                if (WORK_AREA.DATA_SQL.MES_SQL > 12)
                {

                    /*" -5049- COMPUTE MES-SQL = MES-SQL - 12 */
                    WORK_AREA.DATA_SQL.MES_SQL.Value = WORK_AREA.DATA_SQL.MES_SQL - 12;

                    /*" -5051- ADD 1 TO ANO-SQL. */
                    WORK_AREA.DATA_SQL.ANO_SQL.Value = WORK_AREA.DATA_SQL.ANO_SQL + 1;
                }

            }


            /*" -5053- MOVE DATA-SQL TO V0RSAF-DTREFER. */
            _.Move(WORK_AREA.DATA_SQL, V0RSAF_DTREFER);

            /*" -5059- MOVE 'SELECT V0HISTREPSAF' TO COMANDO. */
            _.Move("SELECT V0HISTREPSAF", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -5060- MOVE 60 TO W01-I */
            _.Move(60, FILLER_11.W01_I);

            /*" -5062- MOVE 'SELECT V0HISTREPSAF' TO W01-TEXTO(W01-I) */
            _.Move("SELECT V0HISTREPSAF", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -5066- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -5074- PERFORM R1200_00_REPASSA_SAF_DB_SELECT_1 */

            R1200_00_REPASSA_SAF_DB_SELECT_1();

            /*" -5078- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -5083- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -5084- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -5086- GO TO R1200-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/ //GOTO
                return;
            }


            /*" -5088- IF SQLCODE EQUAL 100 NEXT SENTENCE */

            if (DB.SQLCODE == 100)
            {

                /*" -5089- ELSE */
            }
            else
            {


                /*" -5096- DISPLAY 'VA0813B - PROBLEMAS NO SELECT V0HISTREPSAF 1 ' V0HCTA-NRCERTIF ' ' V0HCTA-NRPARCEL ' ' V0HCOB-NRTIT ' ' V0PROP-CODCLIEN ' ' WHOST-CODCONV ' ' V0HCTA-NSAS */

                $"VA0813B - PROBLEMAS NO SELECT V0HISTREPSAF 1 {V0HCTA_NRCERTIF} {V0HCTA_NRPARCEL} {V0HCOB_NRTIT} {V0PROP_CODCLIEN} {WHOST_CODCONV} {V0HCTA_NSAS}"
                .Display();

                /*" -5098- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5104- MOVE 'INSERT V0HISTREPSAF' TO COMANDO. */
            _.Move("INSERT V0HISTREPSAF", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -5105- MOVE 61 TO W01-I */
            _.Move(61, FILLER_11.W01_I);

            /*" -5107- MOVE 'INSERT V0HISTREPSAF' TO W01-TEXTO(W01-I) */
            _.Move("INSERT V0HISTREPSAF", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -5111- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -5127- PERFORM R1200_00_REPASSA_SAF_DB_INSERT_1 */

            R1200_00_REPASSA_SAF_DB_INSERT_1();

            /*" -5131- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -5136- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -5137- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -5144- DISPLAY 'VA0813B - PROBLEMAS NO INSERT V0HISTREPSAF 1 ' V0HCTA-NRCERTIF ' ' V0HCTA-NRPARCEL ' ' V0HCOB-NRTIT ' ' V0PROP-CODCLIEN ' ' WHOST-CODCONV ' ' V0HCTA-NSAS */

                $"VA0813B - PROBLEMAS NO INSERT V0HISTREPSAF 1 {V0HCTA_NRCERTIF} {V0HCTA_NRPARCEL} {V0HCOB_NRTIT} {V0PROP_CODCLIEN} {WHOST_CODCONV} {V0HCTA_NSAS}"
                .Display();

                /*" -5144- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1200-00-REPASSA-SAF-DB-SELECT-1 */
        public void R1200_00_REPASSA_SAF_DB_SELECT_1()
        {
            /*" -5074- EXEC SQL SELECT SITUACAO INTO :V0RSAF-SITUACAO FROM SEGUROS.V0HISTREPSAF WHERE CODCLIEN = :V0PROP-CODCLIEN AND DTREF = :V0RSAF-DTREFER AND CODOPER = 1100 WITH UR END-EXEC. */

            var r1200_00_REPASSA_SAF_DB_SELECT_1_Query1 = new R1200_00_REPASSA_SAF_DB_SELECT_1_Query1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0RSAF_DTREFER = V0RSAF_DTREFER.ToString(),
            };

            var executed_1 = R1200_00_REPASSA_SAF_DB_SELECT_1_Query1.Execute(r1200_00_REPASSA_SAF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RSAF_SITUACAO, V0RSAF_SITUACAO);
            }


        }

        [StopWatch]
        /*" R1200-00-REPASSA-SAF-DB-INSERT-1 */
        public void R1200_00_REPASSA_SAF_DB_INSERT_1()
        {
            /*" -5127- EXEC SQL INSERT INTO SEGUROS.V0HISTREPSAF VALUES (:V0PROP-CODCLIEN, :V0RSAF-DTREFER, :V0HCTA-NRCERTIF, :V0HCTA-NRPARCEL, :V0PROP-NRMATRFUN, :V0SAFC-VLCUSTSAF, 1100, '0' , '0' , 0, 0, 'VA0813B' , CURRENT TIMESTAMP, :V0PARC-DTVENCTO:VIND-DTMOVTO) END-EXEC. */

            var r1200_00_REPASSA_SAF_DB_INSERT_1_Insert1 = new R1200_00_REPASSA_SAF_DB_INSERT_1_Insert1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0RSAF_DTREFER = V0RSAF_DTREFER.ToString(),
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0HCTA_NRPARCEL = V0HCTA_NRPARCEL.ToString(),
                V0PROP_NRMATRFUN = V0PROP_NRMATRFUN.ToString(),
                V0SAFC_VLCUSTSAF = V0SAFC_VLCUSTSAF.ToString(),
                V0PARC_DTVENCTO = V0PARC_DTVENCTO.ToString(),
                VIND_DTMOVTO = VIND_DTMOVTO.ToString(),
            };

            R1200_00_REPASSA_SAF_DB_INSERT_1_Insert1.Execute(r1200_00_REPASSA_SAF_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-REJEITA-PARCELA-SECTION */
        private void R2000_00_REJEITA_PARCELA_SECTION()
        {
            /*" -5154- MOVE 'R2000-00-REJEITA-PARCELA' TO PARAGRAFO. */
            _.Move("R2000-00-REJEITA-PARCELA", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5157- DISPLAY PARAGRAFO */
            _.Display(WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5158- MOVE 62 TO W01-I */
            _.Move(62, FILLER_11.W01_I);

            /*" -5160- MOVE 'SELECT V0HISTCONTAVA' TO W01-TEXTO(W01-I) */
            _.Move("SELECT V0HISTCONTAVA", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -5164- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -5172- PERFORM R2000_00_REJEITA_PARCELA_DB_SELECT_1 */

            R2000_00_REJEITA_PARCELA_DB_SELECT_1();

            /*" -5176- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -5181- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -5182- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -5184- IF VIND-CODRET NOT LESS +0 AND V0HCTA-CODRET GREATER ZEROS */

                if (VIND_CODRET >= +0 && V0HCTA_CODRET > 00)
                {

                    /*" -5185- MOVE 'N' TO WAUX-FLAG */
                    _.Move("N", WAUX_FLAG);

                    /*" -5186- END-IF */
                }


                /*" -5195- END-IF. */
            }


            /*" -5198- DISPLAY 'V0HCOB-SITUACAO = ' V0HCOB-SITUACAO ' V0HCTA-CODRET = ' V0HCTA-CODRET ' RF-COD-RETORNO = ' RF-COD-RETORNO */

            $"V0HCOB-SITUACAO = {V0HCOB_SITUACAO} V0HCTA-CODRET = {V0HCTA_CODRET} RF-COD-RETORNO = {RET_CADASTRAMENTO.RF_COD_RETORNO}"
            .Display();

            /*" -5199- IF V0HCOB-SITUACAO NOT EQUAL '1' */

            if (V0HCOB_SITUACAO != "1")
            {

                /*" -5202- IF RF-COD-RETORNO EQUAL 01 AND RF-MOTI-COMPEN EQUAL 00 */

                if (RET_CADASTRAMENTO.RF_COD_RETORNO == 01 && RET_CADASTRAMENTO.RF_MOTI_COMPEN == 00)
                {

                    /*" -5203- MOVE 'A' TO V0HCTA-SITUACAO */
                    _.Move("A", V0HCTA_SITUACAO);

                    /*" -5204- ELSE */
                }
                else
                {


                    /*" -5205- MOVE ' ' TO V0HCTA-SITUACAO */
                    _.Move(" ", V0HCTA_SITUACAO);

                    /*" -5206- END-IF */
                }


                /*" -5207- ELSE */
            }
            else
            {


                /*" -5208- MOVE '1' TO V0HCTA-SITUACAO */
                _.Move("1", V0HCTA_SITUACAO);

                /*" -5215- END-IF */
            }


            /*" -5247- IF V0PROP-CODPRODU = 9103 OR 9304 OR 9307 OR 9309 OR 917 OR 9310 OR JVPRD9310 OR 9312 OR 9314 OR JVPRD9314 OR 9318 OR 9319 OR 9320 OR JVPRD9320 OR 9321 OR JVPRD9321 OR 9332 OR JVPRD9332 OR 9333 OR 9351 OR JVPRD9351 OR 9352 OR JVPRD9352 OR 9353 OR JVPRD9353 OR 9359 OR JVPRD9359 OR 9360 OR JVPRD9360 OR 9361 OR JVPRD9361 OR 9701 OR 9702 OR 9703 OR 9704 OR 9705 OR 9707 OR 9327 OR JVPRD9327 OR 9328 OR JVPRD9328 OR 9334 OR JVPRD9334 OR 9356 OR JVPRD9356 OR 9357 OR JVPRD9357 OR 9358 OR JVPRD9358 */

            if (V0PROP_CODPRODU.In("9103", "9304", "9307", "9309", "917", "9310", JVBKINCL.JV_PRODUTOS.JVPRD9310.ToString(), "9312", "9314", JVBKINCL.JV_PRODUTOS.JVPRD9314.ToString(), "9318", "9319", "9320", JVBKINCL.JV_PRODUTOS.JVPRD9320.ToString(), "9321", JVBKINCL.JV_PRODUTOS.JVPRD9321.ToString(), "9332", JVBKINCL.JV_PRODUTOS.JVPRD9332.ToString(), "9333", "9351", JVBKINCL.JV_PRODUTOS.JVPRD9351.ToString(), "9352", JVBKINCL.JV_PRODUTOS.JVPRD9352.ToString(), "9353", JVBKINCL.JV_PRODUTOS.JVPRD9353.ToString(), "9359", JVBKINCL.JV_PRODUTOS.JVPRD9359.ToString(), "9360", JVBKINCL.JV_PRODUTOS.JVPRD9360.ToString(), "9361", JVBKINCL.JV_PRODUTOS.JVPRD9361.ToString(), "9701", "9702", "9703", "9704", "9705", "9707", "9327", JVBKINCL.JV_PRODUTOS.JVPRD9327.ToString(), "9328", JVBKINCL.JV_PRODUTOS.JVPRD9328.ToString(), "9334", JVBKINCL.JV_PRODUTOS.JVPRD9334.ToString(), "9356", JVBKINCL.JV_PRODUTOS.JVPRD9356.ToString(), "9357", JVBKINCL.JV_PRODUTOS.JVPRD9357.ToString(), "9358", JVBKINCL.JV_PRODUTOS.JVPRD9358.ToString()))
            {

                /*" -5248- GO TO R2000-CONTINUA */

                R2000_CONTINUA(); //GOTO
                return;

                /*" -5250- END-IF */
            }


            /*" -5259- IF V0HCTA-CODRET NOT EQUAL 01 AND 18 AND 97 AND 98 AND 99 AND V0PROP-SITUACAO NOT EQUAL '8' */

            if (!V0HCTA_CODRET.In("01", "18", "97", "98", "99") && V0PROP_SITUACAO != "8")
            {

                /*" -5262- IF V0PRVG-ORIG-PRODU EQUAL 'GLOBAL' AND ( V0PROP-CODPRODU EQUAL 9329 OR 8205 OR JVPROD(9329) OR JVPROD(8205) ) */

                if (V0PRVG_ORIG_PRODU == "GLOBAL" && (V0PROP_CODPRODU.In("9329", "8205", JVBKINCL.FILLER.JVPROD[9329].ToString(), JVBKINCL.FILLER.JVPROD[8205].ToString())))
                {

                    /*" -5263- CONTINUE */

                    /*" -5264- ELSE */
                }
                else
                {


                    /*" -5265- PERFORM R2100-00-MUDA-OPCAOPAG */

                    R2100_00_MUDA_OPCAOPAG_SECTION();

                    /*" -5265- END-IF. */
                }

            }


            /*" -0- FLUXCONTROL_PERFORM R2000_CONTINUA */

            R2000_CONTINUA();

        }

        [StopWatch]
        /*" R2000-00-REJEITA-PARCELA-DB-SELECT-1 */
        public void R2000_00_REJEITA_PARCELA_DB_SELECT_1()
        {
            /*" -5172- EXEC SQL SELECT CODRET INTO :V0HCTA-CODRET:VIND-CODRET FROM SEGUROS.V0HISTCONTAVA WHERE CODCONV = :WHOST-CODCONV AND NSAS = :V0HCTA-NSAS AND NSL = :V0HCTA-NSL WITH UR END-EXEC. */

            var r2000_00_REJEITA_PARCELA_DB_SELECT_1_Query1 = new R2000_00_REJEITA_PARCELA_DB_SELECT_1_Query1()
            {
                WHOST_CODCONV = WHOST_CODCONV.ToString(),
                V0HCTA_NSAS = V0HCTA_NSAS.ToString(),
                V0HCTA_NSL = V0HCTA_NSL.ToString(),
            };

            var executed_1 = R2000_00_REJEITA_PARCELA_DB_SELECT_1_Query1.Execute(r2000_00_REJEITA_PARCELA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HCTA_CODRET, V0HCTA_CODRET);
                _.Move(executed_1.VIND_CODRET, VIND_CODRET);
            }


        }

        [StopWatch]
        /*" R2000-CONTINUA */
        private void R2000_CONTINUA(bool isPerform = false)
        {
            /*" -5273- MOVE V0OPCP-OPCAOPAG TO V0HCTA-OPCAOPAG V0HCOB-OPCAOPAG V0PARC-OPCAOPAG. */
            _.Move(V0OPCP_OPCAOPAG, V0HCTA_OPCAOPAG, V0HCOB_OPCAOPAG, V0PARC_OPCAOPAG);

            /*" -5274- MOVE '2000-REJEITA-PARCELA' TO PARAGRAFO. */
            _.Move("2000-REJEITA-PARCELA", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5278- MOVE 'UPDATE V0FITASASSE' TO COMANDO. */
            _.Move("UPDATE V0FITASASSE", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -5280- MOVE RF-IDENTIF-NSA TO WHOST-NSAS */
            _.Move(RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_IDENTIF_NSA, WHOST_NSAS);

            /*" -5284- IF WAUX-FLAG NOT EQUAL 'N' */

            if (WAUX_FLAG != "N")
            {

                /*" -5285- MOVE 63 TO W01-I */
                _.Move(63, FILLER_11.W01_I);

                /*" -5287- MOVE 'UPDATE V0FITASASSE' TO W01-TEXTO(W01-I) */
                _.Move("UPDATE V0FITASASSE", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

                /*" -5291- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

                R8900_TOTALIZA_INICIO_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


                /*" -5300- PERFORM R2000_CONTINUA_DB_UPDATE_1 */

                R2000_CONTINUA_DB_UPDATE_1();

                /*" -5304- MOVE 1 TO W01-QTD-ACC-OK */
                _.Move(1, FILLER_11.W01_QTD_ACC_OK);

                /*" -5309- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

                R8910_TOTALIZA_FINAL_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


                /*" -5310- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -5318- DISPLAY 'VA0813B - PROBLEMAS NO UPDATE V0FITASASSE    ' V0HCTA-NRCERTIF ' ' V0HCTA-NRPARCEL ' ' V0HCOB-NRTIT ' ' V0PROP-CODCLIEN ' ' WHOST-CODCONV ' ' WHOST-NSAS ' ' V0HCTA-NSAS */

                    $"VA0813B - PROBLEMAS NO UPDATE V0FITASASSE    {V0HCTA_NRCERTIF} {V0HCTA_NRPARCEL} {V0HCOB_NRTIT} {V0PROP_CODCLIEN} {WHOST_CODCONV} {WHOST_NSAS} {V0HCTA_NSAS}"
                    .Display();

                    /*" -5319- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -5321- END-IF. */
                }

            }


            /*" -5323- ADD V0HCTA-VLPRMTOT TO WS-ACG-TOTDBNEFET. */
            WORK_AREA.WS_ACG_TOTDBNEFET.Value = WORK_AREA.WS_ACG_TOTDBNEFET + V0HCTA_VLPRMTOT;

            /*" -5324- IF V0HCOB-SITUACAO NOT EQUAL '1' */

            if (V0HCOB_SITUACAO != "1")
            {

                /*" -5326- IF V0HCOB-SITUACAO EQUAL '2' OR RF-COD-RETORNO EQUAL 97 OR 98 OR 99 */

                if (V0HCOB_SITUACAO == "2" || RET_CADASTRAMENTO.RF_COD_RETORNO.In("97", "98", "99"))
                {

                    /*" -5328- MOVE '2' TO V0HCTA-SITUACAO. */
                    _.Move("2", V0HCTA_SITUACAO);
                }

            }


            /*" -5329- IF V0PROP-SITUACAO EQUAL '8' */

            if (V0PROP_SITUACAO == "8")
            {

                /*" -5331- MOVE '2' TO V0HCTA-SITUACAO */
                _.Move("2", V0HCTA_SITUACAO);

                /*" -5336- MOVE 'UPDATE V0PROPOSTAVA' TO COMANDO */
                _.Move("UPDATE V0PROPOSTAVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

                /*" -5337- MOVE 64 TO W01-I */
                _.Move(64, FILLER_11.W01_I);

                /*" -5339- MOVE 'UPDATE V0PROPOSTAVA' TO W01-TEXTO(W01-I) */
                _.Move("UPDATE V0PROPOSTAVA", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

                /*" -5343- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

                R8900_TOTALIZA_INICIO_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


                /*" -5347- PERFORM R2000_CONTINUA_DB_UPDATE_2 */

                R2000_CONTINUA_DB_UPDATE_2();

                /*" -5351- MOVE 1 TO W01-QTD-ACC-OK */
                _.Move(1, FILLER_11.W01_QTD_ACC_OK);

                /*" -5356- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

                R8910_TOTALIZA_FINAL_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


                /*" -5357- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -5364- DISPLAY 'VA0813B - PROBLEMAS UPDATE V0PROPOSTAVA 2' V0HCTA-NRCERTIF ' ' V0HCTA-NRPARCEL ' ' V0HCOB-NRTIT ' ' V0PROP-CODCLIEN ' ' WHOST-CODCONV ' ' V0HCTA-NSAS */

                    $"VA0813B - PROBLEMAS UPDATE V0PROPOSTAVA 2{V0HCTA_NRCERTIF} {V0HCTA_NRPARCEL} {V0HCOB_NRTIT} {V0PROP_CODCLIEN} {WHOST_CODCONV} {V0HCTA_NSAS}"
                    .Display();

                    /*" -5365- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -5367- END-IF */
                }


                /*" -5372- MOVE 'UPDATE V0HISTCONTABILVA' TO COMANDO */
                _.Move("UPDATE V0HISTCONTABILVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

                /*" -5373- MOVE 65 TO W01-I */
                _.Move(65, FILLER_11.W01_I);

                /*" -5375- MOVE 'UPDATE V0HISTCONTABILVA' TO W01-TEXTO(W01-I) */
                _.Move("UPDATE V0HISTCONTABILVA", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

                /*" -5379- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

                R8900_TOTALIZA_INICIO_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


                /*" -5386- PERFORM R2000_CONTINUA_DB_UPDATE_3 */

                R2000_CONTINUA_DB_UPDATE_3();

                /*" -5390- MOVE 1 TO W01-QTD-ACC-OK */
                _.Move(1, FILLER_11.W01_QTD_ACC_OK);

                /*" -5395- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

                R8910_TOTALIZA_FINAL_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


                /*" -5396- IF SQLCODE NOT EQUAL ZEROS AND 100 */

                if (!DB.SQLCODE.In("00", "100"))
                {

                    /*" -5403- DISPLAY 'VA0813B - PROBLEMAS UPDATE V0HISTCONTABILVA' V0HCTA-NRCERTIF ' ' V0HCTA-NRPARCEL ' ' V0HCOB-NRTIT ' ' V0PROP-CODCLIEN ' ' WHOST-CODCONV ' ' V0HCTA-NSAS */

                    $"VA0813B - PROBLEMAS UPDATE V0HISTCONTABILVA{V0HCTA_NRCERTIF} {V0HCTA_NRPARCEL} {V0HCOB_NRTIT} {V0PROP_CODCLIEN} {WHOST_CODCONV} {V0HCTA_NSAS}"
                    .Display();

                    /*" -5404- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -5406- END-IF. */
                }

            }


            /*" -5421- MOVE 'UPDATE V0HISTCOBVA 3' TO COMANDO. */
            _.Move("UPDATE V0HISTCOBVA 3", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -5422- MOVE 66 TO W01-I */
            _.Move(66, FILLER_11.W01_I);

            /*" -5423- MOVE 'UPDATE V0HISTCOBVA' TO W01-TEXTO(W01-I) */
            _.Move("UPDATE V0HISTCOBVA", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -5427- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -5437- PERFORM R2000_CONTINUA_DB_UPDATE_4 */

            R2000_CONTINUA_DB_UPDATE_4();

            /*" -5441- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -5446- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -5447- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -5454- DISPLAY 'VA0813B - PROBLEMAS NO UPDATE V0HISTCOBVA DD ' V0HCTA-NRCERTIF ' ' V0HCTA-NRPARCEL ' ' V0HCOB-NRTIT ' ' V0PROP-CODCLIEN ' ' WHOST-CODCONV ' ' V0HCTA-NSAS */

                $"VA0813B - PROBLEMAS NO UPDATE V0HISTCOBVA DD {V0HCTA_NRCERTIF} {V0HCTA_NRPARCEL} {V0HCOB_NRTIT} {V0PROP_CODCLIEN} {WHOST_CODCONV} {V0HCTA_NSAS}"
                .Display();

                /*" -5456- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5457- IF V0PRVG-ORIG-PRODU EQUAL 'EMPRE' OR 'ESPEC' */

            if (V0PRVG_ORIG_PRODU.In("EMPRE", "ESPEC"))
            {

                /*" -5459- GO TO R2000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -5460- IF V0PROP-SITUACAO EQUAL '3' */

            if (V0PROP_SITUACAO == "3")
            {

                /*" -5469- MOVE 'UPDATE V0PROPOSTAVA 4' TO COMANDO */
                _.Move("UPDATE V0PROPOSTAVA 4", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

                /*" -5472- IF V0PRVG-ORIG-PRODU EQUAL 'GLOBAL' AND ( V0PROP-CODPRODU EQUAL 9329 OR 8205 OR JVPROD(9329) OR JVPROD(8205) ) */

                if (V0PRVG_ORIG_PRODU == "GLOBAL" && (V0PROP_CODPRODU.In("9329", "8205", JVBKINCL.FILLER.JVPROD[9329].ToString(), JVBKINCL.FILLER.JVPROD[8205].ToString())))
                {

                    /*" -5473- CONTINUE */

                    /*" -5476- ELSE */
                }
                else
                {


                    /*" -5477- MOVE 67 TO W01-I */
                    _.Move(67, FILLER_11.W01_I);

                    /*" -5479- MOVE 'UPDATE V0PROPOSTAVA' TO W01-TEXTO(W01-I) */
                    _.Move("UPDATE V0PROPOSTAVA", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

                    /*" -5483- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

                    R8900_TOTALIZA_INICIO_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


                    /*" -5487- PERFORM R2000_CONTINUA_DB_UPDATE_5 */

                    R2000_CONTINUA_DB_UPDATE_5();

                    /*" -5491- MOVE 1 TO W01-QTD-ACC-OK */
                    _.Move(1, FILLER_11.W01_QTD_ACC_OK);

                    /*" -5495- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

                    R8910_TOTALIZA_FINAL_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


                    /*" -5496- IF SQLCODE NOT EQUAL ZEROES */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -5503- DISPLAY 'VA0813B - PROBLEMAS NO INSERT V0PROPOSTAVA 6 ' V0HCTA-NRCERTIF ' ' V0HCTA-NRPARCEL ' ' V0HCOB-NRTIT ' ' V0PROP-CODCLIEN ' ' WHOST-CODCONV ' ' V0HCTA-NSAS */

                        $"VA0813B - PROBLEMAS NO INSERT V0PROPOSTAVA 6 {V0HCTA_NRCERTIF} {V0HCTA_NRPARCEL} {V0HCOB_NRTIT} {V0PROP_CODCLIEN} {WHOST_CODCONV} {V0HCTA_NSAS}"
                        .Display();

                        /*" -5504- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -5504- END-IF. */
                    }

                }

            }


        }

        [StopWatch]
        /*" R2000-CONTINUA-DB-UPDATE-1 */
        public void R2000_CONTINUA_DB_UPDATE_1()
        {
            /*" -5300- EXEC SQL UPDATE SEGUROS.V0FITASASSE SET TOT_DEB_NAO_EFET = TOT_DEB_NAO_EFET + :V0HCTA-VLPRMTOT, QTDE_LANC_DEB_RET = QTDE_LANC_DEB_RET + 1 WHERE COD_CONVENIO = :WHOST-CODCONV AND NSAS = :WHOST-NSAS END-EXEC */

            var r2000_CONTINUA_DB_UPDATE_1_Update1 = new R2000_CONTINUA_DB_UPDATE_1_Update1()
            {
                V0HCTA_VLPRMTOT = V0HCTA_VLPRMTOT.ToString(),
                WHOST_CODCONV = WHOST_CODCONV.ToString(),
                WHOST_NSAS = WHOST_NSAS.ToString(),
            };

            R2000_CONTINUA_DB_UPDATE_1_Update1.Execute(r2000_CONTINUA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2000-CONTINUA-DB-UPDATE-2 */
        public void R2000_CONTINUA_DB_UPDATE_2()
        {
            /*" -5347- EXEC SQL UPDATE SEGUROS.V0PROPOSTAVA SET SITUACAO = '2' WHERE NRCERTIF = :V0HCTA-NRCERTIF END-EXEC */

            var r2000_CONTINUA_DB_UPDATE_2_Update1 = new R2000_CONTINUA_DB_UPDATE_2_Update1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
            };

            R2000_CONTINUA_DB_UPDATE_2_Update1.Execute(r2000_CONTINUA_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R2100-00-MUDA-OPCAOPAG-SECTION */
        private void R2100_00_MUDA_OPCAOPAG_SECTION()
        {
            /*" -5519- MOVE 'R2100-00-MUDA-OPCAOPAG' TO PARAGRAFO. */
            _.Move("R2100-00-MUDA-OPCAOPAG", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5520- IF V0PRVG-OPCAOPAG = '3' */

            if (V0PRVG_OPCAOPAG == "3")
            {

                /*" -5522- GO TO R2100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -5523- IF V0PROP-NUM-APOLICE = 109300000598 */

            if (V0PROP_NUM_APOLICE == 109300000598)
            {

                /*" -5525- GO TO R2100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -5529- MOVE '3' TO V0HCTA-OPCAOPAG V0HCOB-OPCAOPAG V0PARC-OPCAOPAG. */
            _.Move("3", V0HCTA_OPCAOPAG, V0HCOB_OPCAOPAG, V0PARC_OPCAOPAG);

            /*" -5530- IF V0OPCP-OPCAOPAG = '3' */

            if (V0OPCP_OPCAOPAG == "3")
            {

                /*" -5532- GO TO R2100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -5535- MOVE 'UPDATE V0OPCAOPAGVA' TO COMANDO. */
            _.Move("UPDATE V0OPCAOPAGVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -5540- MOVE V0SIST-DTMOVABE TO V0OPCP-DTINIVIG */
            _.Move(V0SIST_DTMOVABE, V0OPCP_DTINIVIG);

            /*" -5541- MOVE 68 TO W01-I */
            _.Move(68, FILLER_11.W01_I);

            /*" -5543- MOVE 'UPDATE V0OPCAOPAGVA' TO W01-TEXTO(W01-I) */
            _.Move("UPDATE V0OPCAOPAGVA", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -5547- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -5556- PERFORM R2100_00_MUDA_OPCAOPAG_DB_UPDATE_1 */

            R2100_00_MUDA_OPCAOPAG_DB_UPDATE_1();

            /*" -5560- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -5565- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -5568- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -5569- MOVE 69 TO W01-I */
                _.Move(69, FILLER_11.W01_I);

                /*" -5571- MOVE 'UPDATE V0OPCAOPAGVA' TO W01-TEXTO(W01-I) */
                _.Move("UPDATE V0OPCAOPAGVA", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

                /*" -5575- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

                R8900_TOTALIZA_INICIO_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


                /*" -5583- PERFORM R2100_00_MUDA_OPCAOPAG_DB_UPDATE_2 */

                R2100_00_MUDA_OPCAOPAG_DB_UPDATE_2();

                /*" -5587- MOVE 1 TO W01-QTD-ACC-OK */
                _.Move(1, FILLER_11.W01_QTD_ACC_OK);

                /*" -5591- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

                R8910_TOTALIZA_FINAL_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


                /*" -5592- MOVE V0SIST-DTMOVABE-A1 TO V0OPCP-DTINIVIG */
                _.Move(V0SIST_DTMOVABE_A1, V0OPCP_DTINIVIG);

                /*" -5594- END-IF. */
            }


            /*" -5595- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -5601- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5602- GO TO R2100-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/ //GOTO
                    return;

                    /*" -5603- ELSE */
                }
                else
                {


                    /*" -5610- DISPLAY 'VA0813B - PROBLEMAS NO UPDATE V0OPCAOPAGVA M ' V0HCTA-NRCERTIF ' ' V0HCTA-NRPARCEL ' ' V0HCOB-NRTIT ' ' V0PROP-CODCLIEN ' ' WHOST-CODCONV ' ' V0HCTA-NSAS */

                    $"VA0813B - PROBLEMAS NO UPDATE V0OPCAOPAGVA M {V0HCTA_NRCERTIF} {V0HCTA_NRPARCEL} {V0HCOB_NRTIT} {V0PROP_CODCLIEN} {WHOST_CODCONV} {V0HCTA_NSAS}"
                    .Display();

                    /*" -5612- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -5621- MOVE 'INSERT V0OPCAOPAGVA' TO COMANDO. */
            _.Move("INSERT V0OPCAOPAGVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -5623- IF WS-PROD-BALCAO = 'S' */

            if (WORK_AREA.WS_PROD_BALCAO == "S")
            {

                /*" -5624- MOVE WHOST-AGECTADEB-FID TO V0OPCP-AGECTADEB */
                _.Move(WHOST_AGECTADEB_FID, V0OPCP_AGECTADEB);

                /*" -5625- MOVE WHOST-OPRCTADEB-FID TO V0OPCP-OPRCTADEB */
                _.Move(WHOST_OPRCTADEB_FID, V0OPCP_OPRCTADEB);

                /*" -5626- MOVE WHOST-NUMCTADEB-FID TO V0OPCP-NUMCTADEB */
                _.Move(WHOST_NUMCTADEB_FID, V0OPCP_NUMCTADEB);

                /*" -5627- MOVE WHOST-DIGCTADEB-FID TO V0OPCP-DIGCTADEB */
                _.Move(WHOST_DIGCTADEB_FID, V0OPCP_DIGCTADEB);

                /*" -5631- MOVE +0 TO VIND-AGECTADEB VIND-OPRCTADEB VIND-NUMCTADEB VIND-DIGCTADEB */
                _.Move(+0, VIND_AGECTADEB, VIND_OPRCTADEB, VIND_NUMCTADEB, VIND_DIGCTADEB);

                /*" -5632- ELSE */
            }
            else
            {


                /*" -5636- MOVE ZEROS TO V0OPCP-AGECTADEB V0OPCP-OPRCTADEB V0OPCP-NUMCTADEB V0OPCP-DIGCTADEB */
                _.Move(0, V0OPCP_AGECTADEB, V0OPCP_OPRCTADEB, V0OPCP_NUMCTADEB, V0OPCP_DIGCTADEB);

                /*" -5640- MOVE -1 TO VIND-AGECTADEB VIND-OPRCTADEB VIND-NUMCTADEB VIND-DIGCTADEB */
                _.Move(-1, VIND_AGECTADEB, VIND_OPRCTADEB, VIND_NUMCTADEB, VIND_DIGCTADEB);

                /*" -5643- END-IF. */
            }


            /*" -5648- MOVE '3' TO V0OPCP-OPCAOPAG. */
            _.Move("3", V0OPCP_OPCAOPAG);

            /*" -5649- MOVE 70 TO W01-I */
            _.Move(70, FILLER_11.W01_I);

            /*" -5651- MOVE 'INSERT V0OPCAOPAGVA' TO W01-TEXTO(W01-I) */
            _.Move("INSERT V0OPCAOPAGVA", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -5655- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -5683- PERFORM R2100_00_MUDA_OPCAOPAG_DB_INSERT_1 */

            R2100_00_MUDA_OPCAOPAG_DB_INSERT_1();

            /*" -5687- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -5692- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -5693- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -5700- DISPLAY 'VA0813B - PROBLEMAS NO INSERT V0OPCAOPAGVA   ' V0HCTA-NRCERTIF ' ' V0HCTA-NRPARCEL ' ' V0HCOB-NRTIT ' ' V0PROP-CODCLIEN ' ' WHOST-CODCONV ' ' V0HCTA-NSAS */

                $"VA0813B - PROBLEMAS NO INSERT V0OPCAOPAGVA   {V0HCTA_NRCERTIF} {V0HCTA_NRPARCEL} {V0HCOB_NRTIT} {V0PROP_CODCLIEN} {WHOST_CODCONV} {V0HCTA_NSAS}"
                .Display();

                /*" -5700- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2100-00-MUDA-OPCAOPAG-DB-UPDATE-1 */
        public void R2100_00_MUDA_OPCAOPAG_DB_UPDATE_1()
        {
            /*" -5556- EXEC SQL UPDATE SEGUROS.V0OPCAOPAGVA SET DTTERVIG = :V0SIST-DTMOVABE-1, TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :V0HCTA-NRCERTIF AND DTTERVIG = '9999-12-31' AND DTINIVIG <= :V0HCOB-DTALTOPC END-EXEC. */

            var r2100_00_MUDA_OPCAOPAG_DB_UPDATE_1_Update1 = new R2100_00_MUDA_OPCAOPAG_DB_UPDATE_1_Update1()
            {
                V0SIST_DTMOVABE_1 = V0SIST_DTMOVABE_1.ToString(),
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0HCOB_DTALTOPC = V0HCOB_DTALTOPC.ToString(),
            };

            R2100_00_MUDA_OPCAOPAG_DB_UPDATE_1_Update1.Execute(r2100_00_MUDA_OPCAOPAG_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R2000-CONTINUA-DB-UPDATE-3 */
        public void R2000_CONTINUA_DB_UPDATE_3()
        {
            /*" -5386- EXEC SQL UPDATE SEGUROS.V0HISTCONTABILVA SET SITUACAO = '2' WHERE NRCERTIF = :V0HCTA-NRCERTIF AND NRPARCEL = :V0HCTA-NRPARCEL AND NRTIT = :V0HCOB-NRTIT AND OCOORHIST = :V0HCOB-OCORHIST END-EXEC */

            var r2000_CONTINUA_DB_UPDATE_3_Update1 = new R2000_CONTINUA_DB_UPDATE_3_Update1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0HCTA_NRPARCEL = V0HCTA_NRPARCEL.ToString(),
                V0HCOB_OCORHIST = V0HCOB_OCORHIST.ToString(),
                V0HCOB_NRTIT = V0HCOB_NRTIT.ToString(),
            };

            R2000_CONTINUA_DB_UPDATE_3_Update1.Execute(r2000_CONTINUA_DB_UPDATE_3_Update1);

        }

        [StopWatch]
        /*" R2100-00-MUDA-OPCAOPAG-DB-INSERT-1 */
        public void R2100_00_MUDA_OPCAOPAG_DB_INSERT_1()
        {
            /*" -5683- EXEC SQL INSERT INTO SEGUROS.V0OPCAOPAGVA (NRCERTIF, DTINIVIG, DTTERVIG, OPCAOPAG, PERIPGTO, DIA_DEBITO, CODUSU, TIMESTAMP, AGECTADEB, OPRCTADEB, NUMCTADEB, DIGCTADEB) VALUES (:V0HCTA-NRCERTIF, :V0OPCP-DTINIVIG, '9999-12-31' , :V0OPCP-OPCAOPAG, :V0OPCP-PERIPGTO, :V0OPCP-DIADEB, 'VA0813B' , CURRENT TIMESTAMP, :V0OPCP-AGECTADEB:VIND-AGECTADEB, :V0OPCP-OPRCTADEB:VIND-OPRCTADEB, :V0OPCP-NUMCTADEB:VIND-NUMCTADEB, :V0OPCP-DIGCTADEB:VIND-DIGCTADEB) END-EXEC. */

            var r2100_00_MUDA_OPCAOPAG_DB_INSERT_1_Insert1 = new R2100_00_MUDA_OPCAOPAG_DB_INSERT_1_Insert1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0OPCP_DTINIVIG = V0OPCP_DTINIVIG.ToString(),
                V0OPCP_OPCAOPAG = V0OPCP_OPCAOPAG.ToString(),
                V0OPCP_PERIPGTO = V0OPCP_PERIPGTO.ToString(),
                V0OPCP_DIADEB = V0OPCP_DIADEB.ToString(),
                V0OPCP_AGECTADEB = V0OPCP_AGECTADEB.ToString(),
                VIND_AGECTADEB = VIND_AGECTADEB.ToString(),
                V0OPCP_OPRCTADEB = V0OPCP_OPRCTADEB.ToString(),
                VIND_OPRCTADEB = VIND_OPRCTADEB.ToString(),
                V0OPCP_NUMCTADEB = V0OPCP_NUMCTADEB.ToString(),
                VIND_NUMCTADEB = VIND_NUMCTADEB.ToString(),
                V0OPCP_DIGCTADEB = V0OPCP_DIGCTADEB.ToString(),
                VIND_DIGCTADEB = VIND_DIGCTADEB.ToString(),
            };

            R2100_00_MUDA_OPCAOPAG_DB_INSERT_1_Insert1.Execute(r2100_00_MUDA_OPCAOPAG_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R2100-00-MUDA-OPCAOPAG-DB-UPDATE-2 */
        public void R2100_00_MUDA_OPCAOPAG_DB_UPDATE_2()
        {
            /*" -5583- EXEC SQL UPDATE SEGUROS.V0OPCAOPAGVA SET DTTERVIG = :V0SIST-DTMOVABE, TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :V0HCTA-NRCERTIF AND DTTERVIG = '9999-12-31' AND DTINIVIG <= :V0HCOB-DTALTOPC END-EXEC */

            var r2100_00_MUDA_OPCAOPAG_DB_UPDATE_2_Update1 = new R2100_00_MUDA_OPCAOPAG_DB_UPDATE_2_Update1()
            {
                V0SIST_DTMOVABE = V0SIST_DTMOVABE.ToString(),
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0HCOB_DTALTOPC = V0HCOB_DTALTOPC.ToString(),
            };

            R2100_00_MUDA_OPCAOPAG_DB_UPDATE_2_Update1.Execute(r2100_00_MUDA_OPCAOPAG_DB_UPDATE_2_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2000-CONTINUA-DB-UPDATE-4 */
        public void R2000_CONTINUA_DB_UPDATE_4()
        {
            /*" -5437- EXEC SQL UPDATE SEGUROS.V0HISTCOBVA SET SITUACAO = :V0HCTA-SITUACAO, VLPRMTOT = :V0HCTA-VLPRMTOT, OCORHIST = :V0HCOB-OCORHIST WHERE NRCERTIF = :V0HCTA-NRCERTIF AND NRPARCEL = :V0HCTA-NRPARCEL AND NRTIT = :V0HCOB-NRTIT END-EXEC. */

            var r2000_CONTINUA_DB_UPDATE_4_Update1 = new R2000_CONTINUA_DB_UPDATE_4_Update1()
            {
                V0HCTA_SITUACAO = V0HCTA_SITUACAO.ToString(),
                V0HCTA_VLPRMTOT = V0HCTA_VLPRMTOT.ToString(),
                V0HCOB_OCORHIST = V0HCOB_OCORHIST.ToString(),
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0HCTA_NRPARCEL = V0HCTA_NRPARCEL.ToString(),
                V0HCOB_NRTIT = V0HCOB_NRTIT.ToString(),
            };

            R2000_CONTINUA_DB_UPDATE_4_Update1.Execute(r2000_CONTINUA_DB_UPDATE_4_Update1);

        }

        [StopWatch]
        /*" R0050-00-INICIO-SECTION */
        private void R0050_00_INICIO_SECTION()
        {
            /*" -5722- MOVE 'R0050-INICIO            ' TO PARAGRAFO. */
            _.Move("R0050-INICIO            ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5723- SET WS-PRD TO 1. */
            WS_PRD.Value = 1;

            /*" -5726- MOVE ZEROS TO V0PROD-CODPRODU. */
            _.Move(0, V0PROD_CODPRODU);

            /*" -5729- PERFORM R0220-00-MOVE-DADOS. */

            R0220_00_MOVE_DADOS_SECTION();

            /*" -5730- MOVE 1 TO LD-PRODUTO */
            _.Move(1, WORK_AREA.LD_PRODUTO);

            /*" -5731- MOVE SPACES TO WFIM-PRODUTO */
            _.Move("", WORK_AREA.WFIM_PRODUTO);

            /*" -5733- PERFORM R0200-00-DECLARE-V0PRODUTO. */

            R0200_00_DECLARE_V0PRODUTO_SECTION();

            /*" -5737- PERFORM R0210-00-FETCH-V0PRODUTO UNTIL WFIM-PRODUTO NOT EQUAL SPACES. */

            while (!(!WORK_AREA.WFIM_PRODUTO.IsEmpty()))
            {

                R0210_00_FETCH_V0PRODUTO_SECTION();
            }

            /*" -5741- MOVE 9999 TO V0PROD-CODPRODU. */
            _.Move(9999, V0PROD_CODPRODU);

            /*" -5742- PERFORM R0220-00-MOVE-DADOS UNTIL WS-SUBS GREATER 2000. */

            while (!(WORK_AREA.WS_SUBS > 2000))
            {

                R0220_00_MOVE_DADOS_SECTION();
            }

        }

        [StopWatch]
        /*" R2000-CONTINUA-DB-UPDATE-5 */
        public void R2000_CONTINUA_DB_UPDATE_5()
        {
            /*" -5487- EXEC SQL UPDATE SEGUROS.V0PROPOSTAVA SET SITUACAO = '6' WHERE NRCERTIF = :V0HCTA-NRCERTIF END-EXEC */

            var r2000_CONTINUA_DB_UPDATE_5_Update1 = new R2000_CONTINUA_DB_UPDATE_5_Update1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
            };

            R2000_CONTINUA_DB_UPDATE_5_Update1.Execute(r2000_CONTINUA_DB_UPDATE_5_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-DECLARE-V0PRODUTO-SECTION */
        private void R0200_00_DECLARE_V0PRODUTO_SECTION()
        {
            /*" -5755- MOVE 'R0200-DECLARE-V0PRODUTO ' TO PARAGRAFO. */
            _.Move("R0200-DECLARE-V0PRODUTO ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5764- PERFORM R0200_00_DECLARE_V0PRODUTO_DB_DECLARE_1 */

            R0200_00_DECLARE_V0PRODUTO_DB_DECLARE_1();

            /*" -5774- PERFORM R0200_00_DECLARE_V0PRODUTO_DB_OPEN_1 */

            R0200_00_DECLARE_V0PRODUTO_DB_OPEN_1();

            /*" -5778- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -5784- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -5785- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5792- DISPLAY 'VA0813B - PROBLEMAS NO DECLARE V0PRODUTO     ' V0HCTA-NRCERTIF ' ' V0HCTA-NRPARCEL ' ' V0HCOB-NRTIT ' ' V0PROP-CODCLIEN ' ' WHOST-CODCONV ' ' V0HCTA-NSAS */

                $"VA0813B - PROBLEMAS NO DECLARE V0PRODUTO     {V0HCTA_NRCERTIF} {V0HCTA_NRPARCEL} {V0HCOB_NRTIT} {V0PROP_CODCLIEN} {WHOST_CODCONV} {V0HCTA_NSAS}"
                .Display();

                /*" -5792- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0200-00-DECLARE-V0PRODUTO-DB-OPEN-1 */
        public void R0200_00_DECLARE_V0PRODUTO_DB_OPEN_1()
        {
            /*" -5774- EXEC SQL OPEN V0PRODUTO END-EXEC. */

            V0PRODUTO.Open();

        }

        [StopWatch]
        /*" R6900-00-DECLARE-VGRAMOCOMP-DB-DECLARE-1 */
        public void R6900_00_DECLARE_VGRAMOCOMP_DB_DECLARE_1()
        {
            /*" -6692- EXEC SQL DECLARE CVGRAMOCOMP CURSOR FOR SELECT DISTINCT B.NUM_APOLICE , B.COD_SUBGRUPO , B.COD_GRUPO_SUSEP , B.RAMO_EMISSOR , B.COD_MODALIDADE , B.DTH_INI_VIGENCIA , B.COD_OPCAO_COBERTURA , B.NUM_IDADE_INICIAL , B.NUM_IDADE_FINAL , B.VLR_PERC_PREMIO , B.COD_USUARIO , B.DTH_ATUALIZACAO FROM SEGUROS.VG_PARAM_RAMO_CONJ A, SEGUROS.VG_PARAM_RAMO_COMP B WHERE A.NUM_APOLICE = :V0PROP-NUM-APOLICE AND A.COD_SUBGRUPO = :WHOST-CODSUBES AND A.DTH_INI_VIGENCIA <= :V0PARC-DTVENCTO AND A.DTH_TER_VIGENCIA >= :V0PARC-DTVENCTO AND B.NUM_APOLICE = A.NUM_APOLICE AND B.COD_SUBGRUPO = A.COD_SUBGRUPO AND B.RAMO_EMISSOR = A.RAMO_EMISSOR AND B.DTH_INI_VIGENCIA = A.DTH_INI_VIGENCIA AND B.NUM_IDADE_INICIAL <= :WHOST-IDADE AND B.NUM_IDADE_FINAL >= :WHOST-IDADE AND B.COD_OPCAO_COBERTURA = :WHOST-OPCAO-COBER ORDER BY B.NUM_APOLICE , B.COD_SUBGRUPO , B.COD_GRUPO_SUSEP , B.RAMO_EMISSOR , B.COD_MODALIDADE , B.DTH_INI_VIGENCIA , B.COD_OPCAO_COBERTURA , B.NUM_IDADE_INICIAL , B.NUM_IDADE_FINAL , B.VLR_PERC_PREMIO , B.COD_USUARIO , B.DTH_ATUALIZACAO WITH UR END-EXEC. */
            CVGRAMOCOMP = new VA0813B_CVGRAMOCOMP(true);
            string GetQuery_CVGRAMOCOMP()
            {
                var query = @$"SELECT DISTINCT B.NUM_APOLICE
							, 
							B.COD_SUBGRUPO
							, 
							B.COD_GRUPO_SUSEP
							, 
							B.RAMO_EMISSOR
							, 
							B.COD_MODALIDADE
							, 
							B.DTH_INI_VIGENCIA
							, 
							B.COD_OPCAO_COBERTURA
							, 
							B.NUM_IDADE_INICIAL
							, 
							B.NUM_IDADE_FINAL
							, 
							B.VLR_PERC_PREMIO
							, 
							B.COD_USUARIO
							, 
							B.DTH_ATUALIZACAO 
							FROM SEGUROS.VG_PARAM_RAMO_CONJ A
							, 
							SEGUROS.VG_PARAM_RAMO_COMP B 
							WHERE A.NUM_APOLICE = '{V0PROP_NUM_APOLICE}' 
							AND A.COD_SUBGRUPO = '{WHOST_CODSUBES}' 
							AND A.DTH_INI_VIGENCIA <= '{V0PARC_DTVENCTO}' 
							AND A.DTH_TER_VIGENCIA >= '{V0PARC_DTVENCTO}' 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.COD_SUBGRUPO = A.COD_SUBGRUPO 
							AND B.RAMO_EMISSOR = A.RAMO_EMISSOR 
							AND B.DTH_INI_VIGENCIA = A.DTH_INI_VIGENCIA 
							AND B.NUM_IDADE_INICIAL <= '{WHOST_IDADE}' 
							AND B.NUM_IDADE_FINAL >= '{WHOST_IDADE}' 
							AND B.COD_OPCAO_COBERTURA = '{WHOST_OPCAO_COBER}' 
							ORDER BY B.NUM_APOLICE
							, 
							B.COD_SUBGRUPO
							, 
							B.COD_GRUPO_SUSEP
							, 
							B.RAMO_EMISSOR
							, 
							B.COD_MODALIDADE
							, 
							B.DTH_INI_VIGENCIA
							, 
							B.COD_OPCAO_COBERTURA
							, 
							B.NUM_IDADE_INICIAL
							, 
							B.NUM_IDADE_FINAL
							, 
							B.VLR_PERC_PREMIO
							, 
							B.COD_USUARIO
							, 
							B.DTH_ATUALIZACAO";

                return query;
            }
            CVGRAMOCOMP.GetQueryEvent += GetQuery_CVGRAMOCOMP;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-FETCH-V0PRODUTO-SECTION */
        private void R0210_00_FETCH_V0PRODUTO_SECTION()
        {
            /*" -5813- MOVE 'R0210-FETCH-V0PRODUTO   ' TO PARAGRAFO. */
            _.Move("R0210-FETCH-V0PRODUTO   ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5815- PERFORM R0210_00_FETCH_V0PRODUTO_DB_FETCH_1 */

            R0210_00_FETCH_V0PRODUTO_DB_FETCH_1();

            /*" -5819- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -5825- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -5834- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -5834- PERFORM R0210_00_FETCH_V0PRODUTO_DB_CLOSE_1 */

                R0210_00_FETCH_V0PRODUTO_DB_CLOSE_1();

                /*" -5838- MOVE 1 TO W01-QTD-ACC-OK */
                _.Move(1, FILLER_11.W01_QTD_ACC_OK);

                /*" -5842- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

                R8910_TOTALIZA_FINAL_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


                /*" -5843- MOVE 'S' TO WFIM-PRODUTO */
                _.Move("S", WORK_AREA.WFIM_PRODUTO);

                /*" -5845- GO TO R0210-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/ //GOTO
                return;
            }


            /*" -5846- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5847- DISPLAY 'R0210-00 - PROBLEMAS FETCH (V0PRODUTO)   ' */
                _.Display($"R0210-00 - PROBLEMAS FETCH (V0PRODUTO)   ");

                /*" -5850- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5852- ADD 1 TO LD-PRODUTO. */
            WORK_AREA.LD_PRODUTO.Value = WORK_AREA.LD_PRODUTO + 1;

            /*" -5855- IF LD-PRODUTO GREATER 2000 */

            if (WORK_AREA.LD_PRODUTO > 2000)
            {

                /*" -5856- MOVE 74 TO W01-I */
                _.Move(74, FILLER_11.W01_I);

                /*" -5857- MOVE 'CLOSE V0PRODUTO' TO W01-TEXTO(W01-I) */
                _.Move("CLOSE V0PRODUTO", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

                /*" -5861- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

                R8900_TOTALIZA_INICIO_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


                /*" -5861- PERFORM R0210_00_FETCH_V0PRODUTO_DB_CLOSE_2 */

                R0210_00_FETCH_V0PRODUTO_DB_CLOSE_2();

                /*" -5865- MOVE 1 TO W01-QTD-ACC-OK */
                _.Move(1, FILLER_11.W01_QTD_ACC_OK);

                /*" -5869- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

                R8910_TOTALIZA_FINAL_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


                /*" -5870- DISPLAY 'R0210-00 - ESTOURO TABELA INTERNA PRODUTO' */
                _.Display($"R0210-00 - ESTOURO TABELA INTERNA PRODUTO");

                /*" -5873- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5873- PERFORM R0220-00-MOVE-DADOS. */

            R0220_00_MOVE_DADOS_SECTION();

        }

        [StopWatch]
        /*" R0210-00-FETCH-V0PRODUTO-DB-FETCH-1 */
        public void R0210_00_FETCH_V0PRODUTO_DB_FETCH_1()
        {
            /*" -5815- EXEC SQL FETCH V0PRODUTO INTO :V0PROD-CODPRODU END-EXEC. */

            if (V0PRODUTO.Fetch())
            {
                _.Move(V0PRODUTO.V0PROD_CODPRODU, V0PROD_CODPRODU);
            }

        }

        [StopWatch]
        /*" R0210-00-FETCH-V0PRODUTO-DB-CLOSE-1 */
        public void R0210_00_FETCH_V0PRODUTO_DB_CLOSE_1()
        {
            /*" -5834- EXEC SQL CLOSE V0PRODUTO END-EXEC */

            V0PRODUTO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-FETCH-V0PRODUTO-DB-CLOSE-2 */
        public void R0210_00_FETCH_V0PRODUTO_DB_CLOSE_2()
        {
            /*" -5861- EXEC SQL CLOSE V0PRODUTO END-EXEC */

            V0PRODUTO.Close();

        }

        [StopWatch]
        /*" R0220-00-MOVE-DADOS-SECTION */
        private void R0220_00_MOVE_DADOS_SECTION()
        {
            /*" -5886- MOVE 'R0220-MOVE-DADOS        ' TO PARAGRAFO. */
            _.Move("R0220-MOVE-DADOS        ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5890- MOVE V0PROD-CODPRODU TO WTABG-CODPRODU(WS-PRD). */
            _.Move(V0PROD_CODPRODU, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_CODPRODU);

            /*" -5891- SET WS-TIP TO 1 */
            WS_TIP.Value = 1;

            /*" -5894- PERFORM R0250-00-MOVE-TIPO 03 TIMES. */

            for (int i = 0; i < 3; i++)
            {

                R0250_00_MOVE_TIPO_SECTION();

            }

            /*" -5895- SET WS-PRD UP BY 1. */
            WS_PRD.Value += 1;

            /*" -5895- SET WS-SUBS TO WS-PRD. */
            WORK_AREA.WS_SUBS.Value = WS_PRD;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_99_SAIDA*/

        [StopWatch]
        /*" R0250-00-MOVE-TIPO-SECTION */
        private void R0250_00_MOVE_TIPO_SECTION()
        {
            /*" -5908- MOVE 'R0250-MOVE-TIPO         ' TO PARAGRAFO. */
            _.Move("R0250-MOVE-TIPO         ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5913- SET WS-SUBS1 TO WS-TIP. */
            WORK_AREA.WS_SUBS1.Value = WS_TIP;

            /*" -5914- IF WS-SUBS1 EQUAL 1 */

            if (WORK_AREA.WS_SUBS1 == 1)
            {

                /*" -5916- MOVE 'A' TO WTABG-TIPO(WS-PRD WS-TIP) */
                _.Move("A", AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_TIPO);

                /*" -5920- ELSE */
            }
            else
            {


                /*" -5921- IF WS-SUBS1 EQUAL 2 */

                if (WORK_AREA.WS_SUBS1 == 2)
                {

                    /*" -5923- MOVE 'M' TO WTABG-TIPO(WS-PRD WS-TIP) */
                    _.Move("M", AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_TIPO);

                    /*" -5927- ELSE */
                }
                else
                {


                    /*" -5931- MOVE 'D' TO WTABG-TIPO(WS-PRD WS-TIP). */
                    _.Move("D", AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_TIPO);
                }

            }


            /*" -5932- SET WS-SIT TO 1 */
            WS_SIT.Value = 1;

            /*" -5935- PERFORM R0260-00-MOVE-SITUACAO 02 TIMES. */

            for (int i = 0; i < 2; i++)
            {

                R0260_00_MOVE_SITUACAO_SECTION();

            }

            /*" -5935- SET WS-TIP UP BY 1. */
            WS_TIP.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_99_SAIDA*/

        [StopWatch]
        /*" R0260-00-MOVE-SITUACAO-SECTION */
        private void R0260_00_MOVE_SITUACAO_SECTION()
        {
            /*" -5948- MOVE 'R0260-MOVE-SITUACAO     ' TO PARAGRAFO. */
            _.Move("R0260-MOVE-SITUACAO     ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5957- MOVE ZEROS TO WTABG-QTDE(WS-PRD WS-TIP WS-SIT) WTABG-VLPRMTOT(WS-PRD WS-TIP WS-SIT) WTABG-VLTARIFA(WS-PRD WS-TIP WS-SIT) WTABG-VLBALCAO(WS-PRD WS-TIP WS-SIT) WTABG-VLIOCC(WS-PRD WS-TIP WS-SIT) WTABG-VLDESCON(WS-PRD WS-TIP WS-SIT). */
            _.Move(0, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_QTDE, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLPRMTOT, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLTARIFA, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLBALCAO, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLIOCC, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLDESCON);

            /*" -5962- SET WS-SUBS2 TO WS-SIT. */
            WORK_AREA.WS_SUBS2.Value = WS_SIT;

            /*" -5963- IF WS-SUBS2 EQUAL 1 */

            if (WORK_AREA.WS_SUBS2 == 1)
            {

                /*" -5965- MOVE '0' TO WTABG-SITUACAO(WS-PRD WS-TIP WS-SIT) */
                _.Move("0", AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_SITUACAO);

                /*" -5969- ELSE */
            }
            else
            {


                /*" -5973- MOVE '2' TO WTABG-SITUACAO(WS-PRD WS-TIP WS-SIT). */
                _.Move("2", AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_SITUACAO);
            }


            /*" -5973- SET WS-SIT UP BY 1. */
            WS_SIT.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0260_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-GERA-FUNDOCOMISVA-SECTION */
        private void R0300_00_GERA_FUNDOCOMISVA_SECTION()
        {
            /*" -5984- MOVE 'R0300-GERA-FUNDOCOMISVA ' TO PARAGRAFO. */
            _.Move("R0300-GERA-FUNDOCOMISVA ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5989- MOVE 'SELECT VG_PRODUTO_SIAS - VERIF ' TO COMANDO. */
            _.Move("SELECT VG_PRODUTO_SIAS - VERIF ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -5990- MOVE 75 TO W01-I */
            _.Move(75, FILLER_11.W01_I);

            /*" -5992- MOVE 'SELECT VG_PRODUTO_SIAS' TO W01-TEXTO(W01-I) */
            _.Move("SELECT VG_PRODUTO_SIAS", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -5996- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -6009- PERFORM R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_1 */

            R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_1();

            /*" -6013- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -6018- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -6019- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6020- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -6021- GO TO R0300-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/ //GOTO
                    return;

                    /*" -6022- ELSE */
                }
                else
                {


                    /*" -6030- DISPLAY 'VA0813B - PROBLEMAS NO SELECT VG_PRODUTO_SIAS' V0HCTA-NRCERTIF ' ' V0HCTA-NRPARCEL ' ' V0HCOB-NRTIT ' ' V0PROP-CODCLIEN ' ' WHOST-CODCONV ' ' V0HCTA-NSAS ' ' V0PROP-NUM-APOLICE ' ' */

                    $"VA0813B - PROBLEMAS NO SELECT VG_PRODUTO_SIAS{V0HCTA_NRCERTIF} {V0HCTA_NRPARCEL} {V0HCOB_NRTIT} {V0PROP_CODCLIEN} {WHOST_CODCONV} {V0HCTA_NSAS} {V0PROP_NUM_APOLICE} "
                    .Display();

                    /*" -6032- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -6037- MOVE 'SELECT SUBGRUPOS_VGAP   ' TO COMANDO. */
            _.Move("SELECT SUBGRUPOS_VGAP   ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -6038- MOVE 76 TO W01-I */
            _.Move(76, FILLER_11.W01_I);

            /*" -6039- MOVE 'SELECT V0SUBGRUPO' TO W01-TEXTO(W01-I) */
            _.Move("SELECT V0SUBGRUPO", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -6043- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -6054- PERFORM R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_2 */

            R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_2();

            /*" -6058- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -6063- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -6064- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6066- DISPLAY 'SUBGRUPO NAO ENCONTRADO ' V0PROP-NUM-APOLICE ' ' V0PROP-CODSUBES */

                $"SUBGRUPO NAO ENCONTRADO {V0PROP_NUM_APOLICE} {V0PROP_CODSUBES}"
                .Display();

                /*" -6068- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -6069- IF V0PROP-CODCLIEN NOT EQUAL SUBGVGAP-COD-CLIENTE */

            if (V0PROP_CODCLIEN != SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_CLIENTE)
            {

                /*" -6071- GO TO R0300-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/ //GOTO
                return;
            }


            /*" -6076- MOVE 'SELECT TERMO_ADESAO    ' TO COMANDO. */
            _.Move("SELECT TERMO_ADESAO    ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -6077- MOVE 77 TO W01-I */
            _.Move(77, FILLER_11.W01_I);

            /*" -6079- MOVE 'SELECT TERMO_ADESAO' TO W01-TEXTO(W01-I) */
            _.Move("SELECT TERMO_ADESAO", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -6083- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -6096- PERFORM R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_3 */

            R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_3();

            /*" -6100- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -6105- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -6106- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6107- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -6108- GO TO R0300-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/ //GOTO
                    return;

                    /*" -6109- ELSE */
                }
                else
                {


                    /*" -6118- DISPLAY 'VA0813B - PROBLEMAS NO SELECT TERMO_ADESAO   ' V0HCTA-NRCERTIF ' ' V0HCTA-NRPARCEL ' ' V0HCOB-NRTIT ' ' V0PROP-CODCLIEN ' ' WHOST-CODCONV ' ' V0HCTA-NSAS ' ' V0PROP-NUM-APOLICE ' ' V0PROP-CODSUBES */

                    $"VA0813B - PROBLEMAS NO SELECT TERMO_ADESAO   {V0HCTA_NRCERTIF} {V0HCTA_NRPARCEL} {V0HCOB_NRTIT} {V0PROP_CODCLIEN} {WHOST_CODCONV} {V0HCTA_NSAS} {V0PROP_NUM_APOLICE} {V0PROP_CODSUBES}"
                    .Display();

                    /*" -6120- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -6125- MOVE 'SELECT V0FUNDOCOMISVA  -       ' TO COMANDO. */
            _.Move("SELECT V0FUNDOCOMISVA  -       ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -6126- MOVE 78 TO W01-I */
            _.Move(78, FILLER_11.W01_I);

            /*" -6128- MOVE 'SELECT V0FUNDOCOMISVA' TO W01-TEXTO(W01-I) */
            _.Move("SELECT V0FUNDOCOMISVA", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -6132- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -6139- PERFORM R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_4 */

            R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_4();

            /*" -6143- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -6148- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -6149- IF SQLCODE EQUAL ZEROS OR -811 */

            if (DB.SQLCODE.In("00", "-811"))
            {

                /*" -6150- GO TO R0300-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/ //GOTO
                return;

                /*" -6151- ELSE */
            }
            else
            {


                /*" -6153- IF SQLCODE EQUAL 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -6154- ELSE */
                }
                else
                {


                    /*" -6162- DISPLAY 'VA0813B - PROBLEMAS NO INSERT V0REPASSECDG   ' V0HCTA-NRCERTIF ' ' V0HCTA-NRPARCEL ' ' V0HCOB-NRTIT ' ' V0PROP-CODCLIEN ' ' WHOST-CODCONV ' ' V0HCTA-NSAS ' ' TERMOADE-NUM-TERMO */

                    $"VA0813B - PROBLEMAS NO INSERT V0REPASSECDG   {V0HCTA_NRCERTIF} {V0HCTA_NRPARCEL} {V0HCOB_NRTIT} {V0PROP_CODCLIEN} {WHOST_CODCONV} {V0HCTA_NSAS} {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}"
                    .Display();

                    /*" -6164- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -6169- MOVE 'SELECT VG_PRODUTO_SIAS ' TO COMANDO. */
            _.Move("SELECT VG_PRODUTO_SIAS ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -6170- MOVE 79 TO W01-I */
            _.Move(79, FILLER_11.W01_I);

            /*" -6172- MOVE 'SELECT VG_PRODUTO_SIAS' TO W01-TEXTO(W01-I) */
            _.Move("SELECT VG_PRODUTO_SIAS", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -6176- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -6189- PERFORM R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_5 */

            R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_5();

            /*" -6193- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -6198- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -6199- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6200- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -6201- GO TO R0300-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/ //GOTO
                    return;

                    /*" -6202- ELSE */
                }
                else
                {


                    /*" -6211- DISPLAY 'VA0813B - PROBLEMAS NO SELECT VG_PRODUTO_SIA1' V0HCTA-NRCERTIF ' ' V0HCTA-NRPARCEL ' ' V0HCOB-NRTIT ' ' V0PROP-CODCLIEN ' ' WHOST-CODCONV ' ' V0HCTA-NSAS ' ' V0PROP-NUM-APOLICE ' ' VGPROSIA-NUM-PERIODO-PAG */

                    $"VA0813B - PROBLEMAS NO SELECT VG_PRODUTO_SIA1{V0HCTA_NRCERTIF} {V0HCTA_NRPARCEL} {V0HCOB_NRTIT} {V0PROP_CODCLIEN} {WHOST_CODCONV} {V0HCTA_NSAS} {V0PROP_NUM_APOLICE} {VGPROSIA.DCLVG_PRODUTO_SIAS.VGPROSIA_NUM_PERIODO_PAG}"
                    .Display();

                    /*" -6213- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -6218- MOVE 'SELECT PARM_AGENCI_EMP ' TO COMANDO. */
            _.Move("SELECT PARM_AGENCI_EMP ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -6219- MOVE 80 TO W01-I */
            _.Move(80, FILLER_11.W01_I);

            /*" -6221- MOVE 'SELECT PARM_AGENCI_EMP' TO W01-TEXTO(W01-I) */
            _.Move("SELECT PARM_AGENCI_EMP", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -6225- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -6234- PERFORM R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_6 */

            R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_6();

            /*" -6238- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -6243- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -6244- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6246- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -6247- GO TO R0300-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/ //GOTO
                    return;

                    /*" -6248- ELSE */
                }
                else
                {


                    /*" -6258- DISPLAY 'VA0813B - PROBLEMAS NO SELECT PARM_AGENCI_EMP' V0HCTA-NRCERTIF ' ' V0HCTA-NRPARCEL ' ' V0HCOB-NRTIT ' ' V0PROP-CODCLIEN ' ' WHOST-CODCONV ' ' V0HCTA-NSAS ' ' V0PROP-NUM-APOLICE ' ' VGPROSIA-NUM-PERIODO-PAG ' ' V0HCOB-DTVENCTO */

                    $"VA0813B - PROBLEMAS NO SELECT PARM_AGENCI_EMP{V0HCTA_NRCERTIF} {V0HCTA_NRPARCEL} {V0HCOB_NRTIT} {V0PROP_CODCLIEN} {WHOST_CODCONV} {V0HCTA_NSAS} {V0PROP_NUM_APOLICE} {VGPROSIA.DCLVG_PRODUTO_SIAS.VGPROSIA_NUM_PERIODO_PAG} {V0HCOB_DTVENCTO}"
                    .Display();

                    /*" -6260- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -6263- MOVE 'INSERT V0FUNDOCOMISVA' TO COMANDO. */
            _.Move("INSERT V0FUNDOCOMISVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -6265- COMPUTE V0FUND-VLCOMISVG ROUNDED = (V0HCTVA-PRMVG * PARAGEEM-PCCOMVEN) / 100. */
            V0FUND_VLCOMISVG.Value = (V0HCTVA_PRMVG * PARAGEEM.DCLPARM_AGENCI_EMP.PARAGEEM_PCCOMVEN) / 100f;

            /*" -6270- COMPUTE V0FUND-VLCOMISAP ROUNDED = (V0HCTVA-PRMAP * PARAGEEM-PCCOMVEN) / 100. */
            V0FUND_VLCOMISAP.Value = (V0HCTVA_PRMAP * PARAGEEM.DCLPARM_AGENCI_EMP.PARAGEEM_PCCOMVEN) / 100f;

            /*" -6271- MOVE 81 TO W01-I */
            _.Move(81, FILLER_11.W01_I);

            /*" -6273- MOVE 'INSERT V0FUNDOCOMISVA' TO W01-TEXTO(W01-I) */
            _.Move("INSERT V0FUNDOCOMISVA", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -6277- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -6331- PERFORM R0300_00_GERA_FUNDOCOMISVA_DB_INSERT_1 */

            R0300_00_GERA_FUNDOCOMISVA_DB_INSERT_1();

            /*" -6335- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -6340- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -6341- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -6348- DISPLAY 'VA0813B - PROBLEMAS NO INSERT V0FUNDOCOMISVA ' V0HCTA-NRCERTIF ' ' V0HCTA-NRPARCEL ' ' V0HCOB-NRTIT ' ' V0PROP-CODCLIEN ' ' WHOST-CODCONV ' ' V0HCTA-NSAS */

                $"VA0813B - PROBLEMAS NO INSERT V0FUNDOCOMISVA {V0HCTA_NRCERTIF} {V0HCTA_NRPARCEL} {V0HCOB_NRTIT} {V0PROP_CODCLIEN} {WHOST_CODCONV} {V0HCTA_NSAS}"
                .Display();

                /*" -6350- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -6350- ADD 1 TO AC-INSERIDOS. */
            WORK_AREA.AC_INSERIDOS.Value = WORK_AREA.AC_INSERIDOS + 1;

        }

        [StopWatch]
        /*" R0300-00-GERA-FUNDOCOMISVA-DB-SELECT-1 */
        public void R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_1()
        {
            /*" -6009- EXEC SQL SELECT COD_PRODUTO INTO :VGPROSIA-COD-PRODUTO FROM SEGUROS.VG_PRODUTO_SIAS WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE AND NUM_PERIODO_PAG = 1 AND (COD_PRODUTO_EMP = 16 OR :V0PRVG-ORIG-PRODU = 'GLOBAL' OR NUM_APOLICE IN (109300000959, 109300001694, 108210624684)) WITH UR END-EXEC. */

            var r0300_00_GERA_FUNDOCOMISVA_DB_SELECT_1_Query1 = new R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_1_Query1()
            {
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
                V0PRVG_ORIG_PRODU = V0PRVG_ORIG_PRODU.ToString(),
            };

            var executed_1 = R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_1_Query1.Execute(r0300_00_GERA_FUNDOCOMISVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VGPROSIA_COD_PRODUTO, VGPROSIA.DCLVG_PRODUTO_SIAS.VGPROSIA_COD_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-GERA-FUNDOCOMISVA-DB-SELECT-2 */
        public void R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_2()
        {
            /*" -6054- EXEC SQL SELECT PERI_FATURAMENTO, COD_FONTE, COD_CLIENTE INTO :VGPROSIA-NUM-PERIODO-PAG, :SUBGVGAP-COD-FONTE, :SUBGVGAP-COD-CLIENTE FROM SEGUROS.V0SUBGRUPO WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE AND COD_SUBGRUPO = :V0PROP-CODSUBES WITH UR END-EXEC. */

            var r0300_00_GERA_FUNDOCOMISVA_DB_SELECT_2_Query1 = new R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_2_Query1()
            {
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
                V0PROP_CODSUBES = V0PROP_CODSUBES.ToString(),
            };

            var executed_1 = R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_2_Query1.Execute(r0300_00_GERA_FUNDOCOMISVA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VGPROSIA_NUM_PERIODO_PAG, VGPROSIA.DCLVG_PRODUTO_SIAS.VGPROSIA_NUM_PERIODO_PAG);
                _.Move(executed_1.SUBGVGAP_COD_FONTE, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_FONTE);
                _.Move(executed_1.SUBGVGAP_COD_CLIENTE, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_CLIENTE);
            }


        }

        [StopWatch]
        /*" R0400-00-GERA-COMISSAO-SECTION */
        private void R0400_00_GERA_COMISSAO_SECTION()
        {
            /*" -6360- MOVE 'R0400-00-GERA-COMISSAO   ' TO PARAGRAFO. */
            _.Move("R0400-00-GERA-COMISSAO   ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6362- IF V0PROP-DTQITBCO GREATER '2007-08-31' NEXT SENTENCE */

            if (V0PROP_DTQITBCO > "2007-08-31")
            {

                /*" -6363- ELSE */
            }
            else
            {


                /*" -6365- GO TO R0400-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/ //GOTO
                return;
            }


            /*" -6367- MOVE ZEROS TO V0COMI-PCCOMCOR. */
            _.Move(0, V0COMI_PCCOMCOR);

            /*" -6375- IF V0PROP-CODPRODU EQUAL 9320 OR JVPROD(9320) OR V0PROP-CODPRODU EQUAL 9327 OR JVPROD(9327) OR V0PROP-CODPRODU EQUAL 9329 OR JVPROD(9329) OR V0PROP-CODPRODU EQUAL 9335 OR V0PROP-CODPRODU EQUAL 9336 OR V0PROP-CODPRODU EQUAL 9337 OR V0PROP-CODPRODU EQUAL 9338 OR V0PROP-CODPRODU EQUAL 9331 */

            if (V0PROP_CODPRODU.In("9320", JVBKINCL.FILLER.JVPROD[9320].ToString()) || V0PROP_CODPRODU.In("9327", JVBKINCL.FILLER.JVPROD[9327].ToString()) || V0PROP_CODPRODU.In("9329", JVBKINCL.FILLER.JVPROD[9329].ToString()) || V0PROP_CODPRODU == 9335 || V0PROP_CODPRODU == 9336 || V0PROP_CODPRODU == 9337 || V0PROP_CODPRODU == 9338 || V0PROP_CODPRODU == 9331)
            {

                /*" -6376- MOVE 93 TO V0COMI-RAMOFR */
                _.Move(93, V0COMI_RAMOFR);

                /*" -6377- ELSE */
            }
            else
            {


                /*" -6379- IF V0PROP-CODPRODU EQUAL 8205 OR JVPROD(8205) OR V0PROP-CODPRODU EQUAL 8207 */

                if (V0PROP_CODPRODU.In("8205", JVBKINCL.FILLER.JVPROD[8205].ToString()) || V0PROP_CODPRODU == 8207)
                {

                    /*" -6380- MOVE 82 TO V0COMI-RAMOFR */
                    _.Move(82, V0COMI_RAMOFR);

                    /*" -6381- ELSE */
                }
                else
                {


                    /*" -6383- GO TO R0400-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -6389- IF V0PROP-CODPRODU EQUAL 9335 OR V0PROP-CODPRODU EQUAL 9336 OR V0PROP-CODPRODU EQUAL 9337 OR V0PROP-CODPRODU EQUAL 9338 OR V0PROP-CODPRODU EQUAL 9331 OR V0PROP-CODPRODU EQUAL 8207 */

            if (V0PROP_CODPRODU == 9335 || V0PROP_CODPRODU == 9336 || V0PROP_CODPRODU == 9337 || V0PROP_CODPRODU == 9338 || V0PROP_CODPRODU == 9331 || V0PROP_CODPRODU == 8207)
            {

                /*" -6395- IF V0PROP-CODPRODU EQUAL 9335 OR V0PROP-CODPRODU EQUAL 9338 OR (V0PROP-CODPRODU EQUAL 9331 AND V0OPCP-PERIPGTO EQUAL 12) OR (V0PROP-CODPRODU EQUAL 8207 AND V0OPCP-PERIPGTO EQUAL 12) */

                if (V0PROP_CODPRODU == 9335 || V0PROP_CODPRODU == 9338 || (V0PROP_CODPRODU == 9331 && V0OPCP_PERIPGTO == 12) || (V0PROP_CODPRODU == 8207 && V0OPCP_PERIPGTO == 12))
                {

                    /*" -6396- IF V0HCTA-NRPARCEL EQUAL 1 */

                    if (V0HCTA_NRPARCEL == 1)
                    {

                        /*" -6397- MOVE 17 TO V0COMI-PCCOMCOR */
                        _.Move(17, V0COMI_PCCOMCOR);

                        /*" -6398- ELSE */
                    }
                    else
                    {


                        /*" -6399- MOVE 2,5 TO V0COMI-PCCOMCOR */
                        _.Move(2.5, V0COMI_PCCOMCOR);

                        /*" -6400- END-IF */
                    }


                    /*" -6401- END-IF */
                }


                /*" -6407- IF V0PROP-CODPRODU EQUAL 9336 OR V0PROP-CODPRODU EQUAL 9337 OR (V0PROP-CODPRODU EQUAL 9331 AND V0OPCP-PERIPGTO EQUAL 1) OR (V0PROP-CODPRODU EQUAL 8207 AND V0OPCP-PERIPGTO EQUAL 1) */

                if (V0PROP_CODPRODU == 9336 || V0PROP_CODPRODU == 9337 || (V0PROP_CODPRODU == 9331 && V0OPCP_PERIPGTO == 1) || (V0PROP_CODPRODU == 8207 && V0OPCP_PERIPGTO == 1))
                {

                    /*" -6408- IF V0HCTA-NRPARCEL EQUAL 1 OR 2 */

                    if (V0HCTA_NRPARCEL.In("1", "2"))
                    {

                        /*" -6409- MOVE 75 TO V0COMI-PCCOMCOR */
                        _.Move(75, V0COMI_PCCOMCOR);

                        /*" -6410- ELSE */
                    }
                    else
                    {


                        /*" -6411- IF V0HCTA-NRPARCEL EQUAL 3 */

                        if (V0HCTA_NRPARCEL == 3)
                        {

                            /*" -6412- MOVE 50 TO V0COMI-PCCOMCOR */
                            _.Move(50, V0COMI_PCCOMCOR);

                            /*" -6413- ELSE */
                        }
                        else
                        {


                            /*" -6417- DIVIDE V0HCTA-NRPARCEL BY 12 GIVING WS-QUOCIENTE REMAINDER WS-RESTO END-DIVIDE */
                            _.Divide(V0HCTA_NRPARCEL, 12, WS_QUOCIENTE, WS_RESTO);

                            /*" -6418- IF WS-RESTO = 1 */

                            if (WS_RESTO == 1)
                            {

                                /*" -6419- MOVE 30 TO V0COMI-PCCOMCOR */
                                _.Move(30, V0COMI_PCCOMCOR);

                                /*" -6420- ELSE */
                            }
                            else
                            {


                                /*" -6421- GO TO R0400-99-SAIDA */
                                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/ //GOTO
                                return;

                                /*" -6422- END-IF */
                            }


                            /*" -6423- END-IF */
                        }


                        /*" -6424- END-IF */
                    }


                    /*" -6425- END-IF */
                }


                /*" -6426- ELSE */
            }
            else
            {


                /*" -6430- IF V0PROP-CODPRODU EQUAL 9329 OR JVPROD(9329) AND V0PROP-NUM-APOLICE EQUAL 109300001694 OR (V0PROP-CODPRODU EQUAL 8205 OR JVPROD(8205) AND V0PROP-NUM-APOLICE EQUAL 108210624684) */

                if (V0PROP_CODPRODU.In("9329", JVBKINCL.FILLER.JVPROD[9329].ToString()) && V0PROP_NUM_APOLICE == 109300001694 || (V0PROP_CODPRODU.In("8205", JVBKINCL.FILLER.JVPROD[8205].ToString()) && V0PROP_NUM_APOLICE == 108210624684))
                {

                    /*" -6431- IF V0HCTA-NRPARCEL EQUAL 2 */

                    if (V0HCTA_NRPARCEL == 2)
                    {

                        /*" -6432- MOVE 80 TO V0COMI-PCCOMCOR */
                        _.Move(80, V0COMI_PCCOMCOR);

                        /*" -6433- ELSE */
                    }
                    else
                    {


                        /*" -6434- IF V0HCTA-NRPARCEL EQUAL 3 */

                        if (V0HCTA_NRPARCEL == 3)
                        {

                            /*" -6435- MOVE 50 TO V0COMI-PCCOMCOR */
                            _.Move(50, V0COMI_PCCOMCOR);

                            /*" -6436- ELSE */
                        }
                        else
                        {


                            /*" -6440- DIVIDE V0HCTA-NRPARCEL BY 12 GIVING WS-QUOCIENTE REMAINDER WS-RESTO END-DIVIDE */
                            _.Divide(V0HCTA_NRPARCEL, 12, WS_QUOCIENTE, WS_RESTO);

                            /*" -6441- IF WS-RESTO = 1 */

                            if (WS_RESTO == 1)
                            {

                                /*" -6442- MOVE 30 TO V0COMI-PCCOMCOR */
                                _.Move(30, V0COMI_PCCOMCOR);

                                /*" -6443- ELSE */
                            }
                            else
                            {


                                /*" -6444- GO TO R0400-99-SAIDA */
                                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/ //GOTO
                                return;

                                /*" -6445- END-IF */
                            }


                            /*" -6446- END-IF */
                        }


                        /*" -6447- END-IF */
                    }


                    /*" -6448- ELSE */
                }
                else
                {


                    /*" -6449- IF V0PROP-DTQITBCO LESS '2009-07-01' */

                    if (V0PROP_DTQITBCO < "2009-07-01")
                    {

                        /*" -6450- IF V0HCTA-NRPARCEL EQUAL 2 */

                        if (V0HCTA_NRPARCEL == 2)
                        {

                            /*" -6451- MOVE 80 TO V0COMI-PCCOMCOR */
                            _.Move(80, V0COMI_PCCOMCOR);

                            /*" -6452- ELSE */
                        }
                        else
                        {


                            /*" -6453- IF V0HCTA-NRPARCEL EQUAL 3 */

                            if (V0HCTA_NRPARCEL == 3)
                            {

                                /*" -6454- MOVE 50 TO V0COMI-PCCOMCOR */
                                _.Move(50, V0COMI_PCCOMCOR);

                                /*" -6455- ELSE */
                            }
                            else
                            {


                                /*" -6456- GO TO R0400-99-SAIDA */
                                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/ //GOTO
                                return;

                                /*" -6457- END-IF */
                            }


                            /*" -6458- END-IF */
                        }


                        /*" -6459- END-IF */
                    }


                    /*" -6460- END-IF */
                }


                /*" -6462- END-IF. */
            }


            /*" -6465- COMPUTE V0COMI-VALBAS = V0HCTVA-PRMVG + V0HCTVA-PRMAP */
            V0COMI_VALBAS.Value = V0HCTVA_PRMVG + V0HCTVA_PRMAP;

            /*" -6469- COMPUTE V0COMI-VLCOMIS = V0COMI-VALBAS * V0COMI-PCCOMCOR / 100. */
            V0COMI_VLCOMIS.Value = V0COMI_VALBAS * V0COMI_PCCOMCOR / 100f;

            /*" -6470- MOVE V0PROP-NUM-APOLICE TO V0COMI-NUMAPOL */
            _.Move(V0PROP_NUM_APOLICE, V0COMI_NUMAPOL);

            /*" -6471- MOVE ZEROS TO V0COMI-NRENDOS */
            _.Move(0, V0COMI_NRENDOS);

            /*" -6472- MOVE V0HCTA-NRCERTIF TO V0COMI-NRCERTIF */
            _.Move(V0HCTA_NRCERTIF, V0COMI_NRCERTIF);

            /*" -6473- MOVE SPACES TO V0COMI-DIGCERT */
            _.Move("", V0COMI_DIGCERT);

            /*" -6474- MOVE '1' TO V0COMI-IDTPSEGU */
            _.Move("1", V0COMI_IDTPSEGU);

            /*" -6475- MOVE V0HCTA-NRPARCEL TO V0COMI-NRPARCEL */
            _.Move(V0HCTA_NRPARCEL, V0COMI_NRPARCEL);

            /*" -6477- MOVE 1101 TO V0COMI-OPERACAO */
            _.Move(1101, V0COMI_OPERACAO);

            /*" -6481- IF V0PROP-CODPRODU EQUAL 9335 OR V0PROP-CODPRODU EQUAL 9336 OR V0PROP-CODPRODU EQUAL 9337 OR V0PROP-CODPRODU EQUAL 9338 */

            if (V0PROP_CODPRODU == 9335 || V0PROP_CODPRODU == 9336 || V0PROP_CODPRODU == 9337 || V0PROP_CODPRODU == 9338)
            {

                /*" -6482- MOVE 7005 TO V0COMI-CODPDT */
                _.Move(7005, V0COMI_CODPDT);

                /*" -6483- ELSE */
            }
            else
            {


                /*" -6487- IF V0PROP-CODPRODU EQUAL 9329 OR JVPROD(9329) AND V0PROP-NUM-APOLICE EQUAL 109300001694 OR (V0PROP-CODPRODU EQUAL 8205 OR JVPROD(8205) AND V0PROP-NUM-APOLICE EQUAL 108210624684) */

                if (V0PROP_CODPRODU.In("9329", JVBKINCL.FILLER.JVPROD[9329].ToString()) && V0PROP_NUM_APOLICE == 109300001694 || (V0PROP_CODPRODU.In("8205", JVBKINCL.FILLER.JVPROD[8205].ToString()) && V0PROP_NUM_APOLICE == 108210624684))
                {

                    /*" -6488- MOVE 24121 TO V0COMI-CODPDT */
                    _.Move(24121, V0COMI_CODPDT);

                    /*" -6489- ELSE */
                }
                else
                {


                    /*" -6490- MOVE 23914 TO V0COMI-CODPDT */
                    _.Move(23914, V0COMI_CODPDT);

                    /*" -6491- END-IF */
                }


                /*" -6494- END-IF. */
            }


            /*" -6495- MOVE V0APOL-MODALIDA TO V0COMI-MODALIFR */
            _.Move(V0APOL_MODALIDA, V0COMI_MODALIFR);

            /*" -6496- MOVE 1 TO V0COMI-OCORHIST */
            _.Move(1, V0COMI_OCORHIST);

            /*" -6497- MOVE V0PROP-FONTE TO V0COMI-FONTE */
            _.Move(V0PROP_FONTE, V0COMI_FONTE);

            /*" -6498- MOVE V0PROP-CODCLIEN TO V0COMI-CODCLIEN */
            _.Move(V0PROP_CODCLIEN, V0COMI_CODCLIEN);

            /*" -6499- MOVE V0SIST-DTMOVABE TO V0COMI-DATCLO */
            _.Move(V0SIST_DTMOVABE, V0COMI_DATCLO);

            /*" -6500- MOVE ZEROS TO V0COMI-NUMREC */
            _.Move(0, V0COMI_NUMREC);

            /*" -6501- MOVE '1' TO V0COMI-TIPCOM */
            _.Move("1", V0COMI_TIPCOM);

            /*" -6503- MOVE ZEROS TO V0COMI-QTPARCEL V0COMI-PCDESCON */
            _.Move(0, V0COMI_QTPARCEL, V0COMI_PCDESCON);

            /*" -6504- MOVE V0PROP-CODSUBES TO V0COMI-CODSUBES */
            _.Move(V0PROP_CODSUBES, V0COMI_CODSUBES);

            /*" -6505- MOVE SPACES TO V0COMI-DTMOVTO */
            _.Move("", V0COMI_DTMOVTO);

            /*" -6506- MOVE V0SIST-DTMOVABE TO V0COMI-DATSEL */
            _.Move(V0SIST_DTMOVABE, V0COMI_DATSEL);

            /*" -6510- MOVE ZEROS TO V0COMI-CODEMP V0COMI-CODPRP V0COMI-NUMBIL V0COMI-VLVARMON */
            _.Move(0, V0COMI_CODEMP, V0COMI_CODPRP, V0COMI_NUMBIL, V0COMI_VLVARMON);

            /*" -6512- MOVE V0SIST-DTMOVABE TO V0COMI-DTQITBCO. */
            _.Move(V0SIST_DTMOVABE, V0COMI_DTQITBCO);

            /*" -6513- MOVE -1 TO VIND-DTMOVTO */
            _.Move(-1, VIND_DTMOVTO);

            /*" -6514- MOVE ZEROS TO VIND-DATSEL */
            _.Move(0, VIND_DATSEL);

            /*" -6515- MOVE ZEROS TO VIND-CODEMP */
            _.Move(0, VIND_CODEMP);

            /*" -6516- MOVE -1 TO VIND-CODPRP */
            _.Move(-1, VIND_CODPRP);

            /*" -6517- MOVE -1 TO VIND-NUMBIL */
            _.Move(-1, VIND_NUMBIL);

            /*" -6518- MOVE -1 TO VIND-VLVARMON */
            _.Move(-1, VIND_VLVARMON);

            /*" -6520- MOVE ZEROS TO VIND-DTQITBCO. */
            _.Move(0, VIND_DTQITBCO);

            /*" -6521- IF V0COMI-VLCOMIS NOT GREATER ZEROS */

            if (V0COMI_VLCOMIS <= 00)
            {

                /*" -6521- GO TO R0400-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/ //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM R0400_00_INSERT_COMISSAO */

            R0400_00_INSERT_COMISSAO();

        }

        [StopWatch]
        /*" R0300-00-GERA-FUNDOCOMISVA-DB-SELECT-3 */
        public void R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_3()
        {
            /*" -6096- EXEC SQL SELECT NUM_TERMO, COD_AGENCIA_OP, NUM_MATRICULA_VEN INTO :TERMOADE-NUM-TERMO, :TERMOADE-COD-AGENCIA-OP, :TERMOADE-NUM-MATRICULA-VEN FROM SEGUROS.TERMO_ADESAO WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE AND COD_SUBGRUPO = :V0PROP-CODSUBES ORDER BY NUM_TERMO DESC FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0300_00_GERA_FUNDOCOMISVA_DB_SELECT_3_Query1 = new R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_3_Query1()
            {
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
                V0PROP_CODSUBES = V0PROP_CODSUBES.ToString(),
            };

            var executed_1 = R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_3_Query1.Execute(r0300_00_GERA_FUNDOCOMISVA_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.TERMOADE_NUM_TERMO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO);
                _.Move(executed_1.TERMOADE_COD_AGENCIA_OP, TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_AGENCIA_OP);
                _.Move(executed_1.TERMOADE_NUM_MATRICULA_VEN, TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_MATRICULA_VEN);
            }


        }

        [StopWatch]
        /*" R0400-00-INSERT-COMISSAO */
        private void R0400_00_INSERT_COMISSAO(bool isPerform = false)
        {
            /*" -6530- MOVE 'INSERT V0COMISSAO              ' TO COMANDO. */
            _.Move("INSERT V0COMISSAO              ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -6531- MOVE 82 TO W01-I */
            _.Move(82, FILLER_11.W01_I);

            /*" -6532- MOVE 'INSERT V0COMISSAO' TO W01-TEXTO(W01-I) */
            _.Move("INSERT V0COMISSAO", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -6536- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -6570- PERFORM R0400_00_INSERT_COMISSAO_DB_INSERT_1 */

            R0400_00_INSERT_COMISSAO_DB_INSERT_1();

            /*" -6574- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -6579- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -6583- IF SQLCODE EQUAL -803 NEXT SENTENCE */

            if (DB.SQLCODE == -803)
            {

                /*" -6584- ELSE */
            }
            else
            {


                /*" -6585- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -6592- DISPLAY 'VA0813B - PROBLEMAS NO INSERT V0COMISSAO     ' V0HCTA-NRCERTIF ' ' V0HCTA-NRPARCEL ' ' V0HCOB-NRTIT ' ' V0PROP-CODCLIEN ' ' WHOST-CODCONV ' ' V0HCTA-NSAS */

                    $"VA0813B - PROBLEMAS NO INSERT V0COMISSAO     {V0HCTA_NRCERTIF} {V0HCTA_NRPARCEL} {V0HCOB_NRTIT} {V0PROP_CODCLIEN} {WHOST_CODCONV} {V0HCTA_NSAS}"
                    .Display();

                    /*" -6593- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -6594- ELSE */
                }
                else
                {


                    /*" -6595- ADD 1 TO AC-COMISSAO */
                    WORK_AREA.AC_COMISSAO.Value = WORK_AREA.AC_COMISSAO + 1;

                    /*" -6596- END-IF */
                }


                /*" -6596- END-IF. */
            }


        }

        [StopWatch]
        /*" R0400-00-INSERT-COMISSAO-DB-INSERT-1 */
        public void R0400_00_INSERT_COMISSAO_DB_INSERT_1()
        {
            /*" -6570- EXEC SQL INSERT INTO SEGUROS.V0COMISSAO VALUES (:V0COMI-NUMAPOL , :V0COMI-NRENDOS , :V0COMI-NRCERTIF , :V0COMI-DIGCERT , :V0COMI-IDTPSEGU , :V0COMI-NRPARCEL , :V0COMI-OPERACAO , :V0COMI-CODPDT , :V0COMI-RAMOFR , :V0COMI-MODALIFR , :V0COMI-OCORHIST , :V0COMI-FONTE , :V0COMI-CODCLIEN , :V0COMI-VLCOMIS , :V0COMI-DATCLO , :V0COMI-NUMREC , :V0COMI-VALBAS , :V0COMI-TIPCOM , :V0COMI-QTPARCEL , :V0COMI-PCCOMCOR , :V0COMI-PCDESCON , :V0COMI-CODSUBES , CURRENT TIME , :V0COMI-DTMOVTO:VIND-DTMOVTO , :V0COMI-DATSEL:VIND-DATSEL , :V0COMI-CODEMP:VIND-CODEMP , :V0COMI-CODPRP:VIND-CODPRP , CURRENT TIMESTAMP , :V0COMI-NUMBIL:VIND-NUMBIL , :V0COMI-VLVARMON:VIND-VLVARMON , :V0COMI-DTQITBCO:VIND-DTQITBCO) END-EXEC. */

            var r0400_00_INSERT_COMISSAO_DB_INSERT_1_Insert1 = new R0400_00_INSERT_COMISSAO_DB_INSERT_1_Insert1()
            {
                V0COMI_NUMAPOL = V0COMI_NUMAPOL.ToString(),
                V0COMI_NRENDOS = V0COMI_NRENDOS.ToString(),
                V0COMI_NRCERTIF = V0COMI_NRCERTIF.ToString(),
                V0COMI_DIGCERT = V0COMI_DIGCERT.ToString(),
                V0COMI_IDTPSEGU = V0COMI_IDTPSEGU.ToString(),
                V0COMI_NRPARCEL = V0COMI_NRPARCEL.ToString(),
                V0COMI_OPERACAO = V0COMI_OPERACAO.ToString(),
                V0COMI_CODPDT = V0COMI_CODPDT.ToString(),
                V0COMI_RAMOFR = V0COMI_RAMOFR.ToString(),
                V0COMI_MODALIFR = V0COMI_MODALIFR.ToString(),
                V0COMI_OCORHIST = V0COMI_OCORHIST.ToString(),
                V0COMI_FONTE = V0COMI_FONTE.ToString(),
                V0COMI_CODCLIEN = V0COMI_CODCLIEN.ToString(),
                V0COMI_VLCOMIS = V0COMI_VLCOMIS.ToString(),
                V0COMI_DATCLO = V0COMI_DATCLO.ToString(),
                V0COMI_NUMREC = V0COMI_NUMREC.ToString(),
                V0COMI_VALBAS = V0COMI_VALBAS.ToString(),
                V0COMI_TIPCOM = V0COMI_TIPCOM.ToString(),
                V0COMI_QTPARCEL = V0COMI_QTPARCEL.ToString(),
                V0COMI_PCCOMCOR = V0COMI_PCCOMCOR.ToString(),
                V0COMI_PCDESCON = V0COMI_PCDESCON.ToString(),
                V0COMI_CODSUBES = V0COMI_CODSUBES.ToString(),
                V0COMI_DTMOVTO = V0COMI_DTMOVTO.ToString(),
                VIND_DTMOVTO = VIND_DTMOVTO.ToString(),
                V0COMI_DATSEL = V0COMI_DATSEL.ToString(),
                VIND_DATSEL = VIND_DATSEL.ToString(),
                V0COMI_CODEMP = V0COMI_CODEMP.ToString(),
                VIND_CODEMP = VIND_CODEMP.ToString(),
                V0COMI_CODPRP = V0COMI_CODPRP.ToString(),
                VIND_CODPRP = VIND_CODPRP.ToString(),
                V0COMI_NUMBIL = V0COMI_NUMBIL.ToString(),
                VIND_NUMBIL = VIND_NUMBIL.ToString(),
                V0COMI_VLVARMON = V0COMI_VLVARMON.ToString(),
                VIND_VLVARMON = VIND_VLVARMON.ToString(),
                V0COMI_DTQITBCO = V0COMI_DTQITBCO.ToString(),
                VIND_DTQITBCO = VIND_DTQITBCO.ToString(),
            };

            R0400_00_INSERT_COMISSAO_DB_INSERT_1_Insert1.Execute(r0400_00_INSERT_COMISSAO_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R0300-00-GERA-FUNDOCOMISVA-DB-INSERT-1 */
        public void R0300_00_GERA_FUNDOCOMISVA_DB_INSERT_1()
        {
            /*" -6331- EXEC SQL INSERT INTO SEGUROS.V0FUNDOCOMISVA (CODPRODU , NRCERTIF , NRPROPAZ , NUM_TERMO, SITUACAO , CODOPER , FONTE , AGENCIA , CODCLIEN , NRMATRVEN, VLBASVG , VALBASAP , VLCOMISVG, VLCOMISAP, DTQITBCO , PCCOMIND , PCCOMGER , PCCOMSUP , DTMOVTO , COD_USUARIO, TIMESTAMP, NUM_APOLICE, COD_SUBGRUPO, NUM_ENDOSSO, NUM_TITULO, NUM_PARCELA) VALUES (:VGPROSIA-COD-PRODUTO, 0, 0, :TERMOADE-NUM-TERMO, '0' , 1101, :SUBGVGAP-COD-FONTE, :TERMOADE-COD-AGENCIA-OP, :SUBGVGAP-COD-CLIENTE, :TERMOADE-NUM-MATRICULA-VEN, :V0HCTVA-PRMVG, :V0HCTVA-PRMAP, :V0FUND-VLCOMISVG, :V0FUND-VLCOMISAP, :V0HCOB-DTVENCTO, :PARAGEEM-PCCOMVEN, 0, 0, :V0SIST-DTMOVABE, 'VA0813B' , CURRENT TIMESTAMP, :V0PROP-NUM-APOLICE, :V0PROP-CODSUBES, 0, :V0HCOB-NRTIT, :V0HCTA-NRPARCEL) END-EXEC. */

            var r0300_00_GERA_FUNDOCOMISVA_DB_INSERT_1_Insert1 = new R0300_00_GERA_FUNDOCOMISVA_DB_INSERT_1_Insert1()
            {
                VGPROSIA_COD_PRODUTO = VGPROSIA.DCLVG_PRODUTO_SIAS.VGPROSIA_COD_PRODUTO.ToString(),
                TERMOADE_NUM_TERMO = TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO.ToString(),
                SUBGVGAP_COD_FONTE = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_FONTE.ToString(),
                TERMOADE_COD_AGENCIA_OP = TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_AGENCIA_OP.ToString(),
                SUBGVGAP_COD_CLIENTE = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_CLIENTE.ToString(),
                TERMOADE_NUM_MATRICULA_VEN = TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_MATRICULA_VEN.ToString(),
                V0HCTVA_PRMVG = V0HCTVA_PRMVG.ToString(),
                V0HCTVA_PRMAP = V0HCTVA_PRMAP.ToString(),
                V0FUND_VLCOMISVG = V0FUND_VLCOMISVG.ToString(),
                V0FUND_VLCOMISAP = V0FUND_VLCOMISAP.ToString(),
                V0HCOB_DTVENCTO = V0HCOB_DTVENCTO.ToString(),
                PARAGEEM_PCCOMVEN = PARAGEEM.DCLPARM_AGENCI_EMP.PARAGEEM_PCCOMVEN.ToString(),
                V0SIST_DTMOVABE = V0SIST_DTMOVABE.ToString(),
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
                V0PROP_CODSUBES = V0PROP_CODSUBES.ToString(),
                V0HCOB_NRTIT = V0HCOB_NRTIT.ToString(),
                V0HCTA_NRPARCEL = V0HCTA_NRPARCEL.ToString(),
            };

            R0300_00_GERA_FUNDOCOMISVA_DB_INSERT_1_Insert1.Execute(r0300_00_GERA_FUNDOCOMISVA_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R0300-00-GERA-FUNDOCOMISVA-DB-SELECT-4 */
        public void R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_4()
        {
            /*" -6139- EXEC SQL SELECT NRCERTIF INTO :WHOST-NRCERTIF FROM SEGUROS.V0FUNDOCOMISVA WHERE NUM_TERMO = :TERMOADE-NUM-TERMO AND NUM_PARCELA = :V0HCTA-NRPARCEL WITH UR END-EXEC. */

            var r0300_00_GERA_FUNDOCOMISVA_DB_SELECT_4_Query1 = new R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_4_Query1()
            {
                TERMOADE_NUM_TERMO = TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO.ToString(),
                V0HCTA_NRPARCEL = V0HCTA_NRPARCEL.ToString(),
            };

            var executed_1 = R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_4_Query1.Execute(r0300_00_GERA_FUNDOCOMISVA_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_NRCERTIF, WHOST_NRCERTIF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-GERA-FUNDOCOMISVA-DB-SELECT-5 */
        public void R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_5()
        {
            /*" -6189- EXEC SQL SELECT COD_PRODUTO INTO :VGPROSIA-COD-PRODUTO FROM SEGUROS.VG_PRODUTO_SIAS WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE AND NUM_PERIODO_PAG = :VGPROSIA-NUM-PERIODO-PAG AND (COD_PRODUTO_EMP = 16 OR :V0PRVG-ORIG-PRODU = 'GLOBAL' OR NUM_APOLICE IN (109300000959, 109300001694, 108210624684)) WITH UR END-EXEC. */

            var r0300_00_GERA_FUNDOCOMISVA_DB_SELECT_5_Query1 = new R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_5_Query1()
            {
                VGPROSIA_NUM_PERIODO_PAG = VGPROSIA.DCLVG_PRODUTO_SIAS.VGPROSIA_NUM_PERIODO_PAG.ToString(),
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
                V0PRVG_ORIG_PRODU = V0PRVG_ORIG_PRODU.ToString(),
            };

            var executed_1 = R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_5_Query1.Execute(r0300_00_GERA_FUNDOCOMISVA_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VGPROSIA_COD_PRODUTO, VGPROSIA.DCLVG_PRODUTO_SIAS.VGPROSIA_COD_PRODUTO);
            }


        }

        [StopWatch]
        /*" M-0500-00-CALCULA-BISSEXTO */
        private void M_0500_00_CALCULA_BISSEXTO(bool isPerform = false)
        {
            /*" -6606- MOVE '0500-00-CALCULA-BISSEXTO' TO PARAGRAFO. */
            _.Move("0500-00-CALCULA-BISSEXTO", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6608- MOVE WHOST-DTVENCTO(1:4) TO AUX-ANO. */
            _.Move(WHOST_DTVENCTO.Substring(1, 4), WORK_AREA.AUX_ANO);

            /*" -6609- IF AUX-ANO2 EQUAL ZEROS */

            if (WORK_AREA.FILLER_18.AUX_ANO2 == 00)
            {

                /*" -6611- DIVIDE AUX-ANO BY 400 GIVING WS-RESULT REMAINDER WS-RESTO */
                _.Divide(WORK_AREA.AUX_ANO, 400, WORK_AREA.WS_RESULT, WS_RESTO);

                /*" -6612- ELSE */
            }
            else
            {


                /*" -6614- DIVIDE AUX-ANO BY 4 GIVING WS-RESULT REMAINDER WS-RESTO */
                _.Divide(WORK_AREA.AUX_ANO, 4, WORK_AREA.WS_RESULT, WS_RESTO);

                /*" -6615- END-IF. */
            }


            /*" -6616- IF WS-RESTO EQUAL ZEROS */

            if (WS_RESTO == 00)
            {

                /*" -6617- MOVE 29 TO WHOST-DTVENCTO(9:2) */
                _.MoveAtPosition(29, WHOST_DTVENCTO, 9, 2);

                /*" -6618- ELSE */
            }
            else
            {


                /*" -6619- MOVE 28 TO WHOST-DTVENCTO(9:2) */
                _.MoveAtPosition(28, WHOST_DTVENCTO, 9, 2);

                /*" -6619- END-IF. */
            }


        }

        [StopWatch]
        /*" R0300-00-GERA-FUNDOCOMISVA-DB-SELECT-6 */
        public void R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_6()
        {
            /*" -6234- EXEC SQL SELECT PCCOMVEN INTO :PARAGEEM-PCCOMVEN FROM SEGUROS.PARM_AGENCI_EMP WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE AND PERI_PAGAMENTO = :VGPROSIA-NUM-PERIODO-PAG AND DATA_INIVIGENCIA <= :V0HCOB-DTVENCTO AND DATA_TERVIGENCIA >= :V0HCOB-DTVENCTO WITH UR END-EXEC. */

            var r0300_00_GERA_FUNDOCOMISVA_DB_SELECT_6_Query1 = new R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_6_Query1()
            {
                VGPROSIA_NUM_PERIODO_PAG = VGPROSIA.DCLVG_PRODUTO_SIAS.VGPROSIA_NUM_PERIODO_PAG.ToString(),
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
                V0HCOB_DTVENCTO = V0HCOB_DTVENCTO.ToString(),
            };

            var executed_1 = R0300_00_GERA_FUNDOCOMISVA_DB_SELECT_6_Query1.Execute(r0300_00_GERA_FUNDOCOMISVA_DB_SELECT_6_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARAGEEM_PCCOMVEN, PARAGEEM.DCLPARM_AGENCI_EMP.PARAGEEM_PCCOMVEN);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0500_99_SAIDA*/

        [StopWatch]
        /*" R6900-00-DECLARE-VGRAMOCOMP-SECTION */
        private void R6900_00_DECLARE_VGRAMOCOMP_SECTION()
        {
            /*" -6628- MOVE '6900-00-DECLARE-CURSOR       ' TO PARAGRAFO. */
            _.Move("6900-00-DECLARE-CURSOR       ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6630- MOVE 'DECLARE   CVGRAMOCOMP' TO COMANDO. */
            _.Move("DECLARE   CVGRAMOCOMP", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -6632- MOVE 'NAO' TO WFIM-VGRAMOCOMP */
            _.Move("NAO", WORK_AREA.WFIM_VGRAMOCOMP);

            /*" -6639- IF (V0PROP-NUM-APOLICE EQUAL 109300000559 OR 109300000709 OR 109300001311 OR 109300001392 OR 109300001393 OR 3009300000559 OR 109300000709 OR 3009300001559 OR 109300001311 OR 109300001392 OR 109300001393 ) */

            if ((V0PROP_NUM_APOLICE.In("109300000559", "109300000709", "109300001311", "109300001392", "109300001393", "3009300000559", "109300000709", "3009300001559", "109300001311", "109300001392", "109300001393")))
            {

                /*" -6640- MOVE V0PROP-OPCAO-COBER TO WHOST-OPCAO-COBER */
                _.Move(V0PROP_OPCAO_COBER, WHOST_OPCAO_COBER);

                /*" -6641- PERFORM R6920-00-SELECT-HISCOBPR */

                R6920_00_SELECT_HISCOBPR_SECTION();

                /*" -6642- ELSE */
            }
            else
            {


                /*" -6643- MOVE ' ' TO WHOST-OPCAO-COBER */
                _.Move(" ", WHOST_OPCAO_COBER);

                /*" -6645- END-IF */
            }


            /*" -6646- IF (V0PRVG-ORIG-PRODU EQUAL 'GLOBAL' ) */

            if ((V0PRVG_ORIG_PRODU == "GLOBAL"))
            {

                /*" -6647- MOVE ZEROS TO WHOST-CODSUBES */
                _.Move(0, WHOST_CODSUBES);

                /*" -6648- ELSE */
            }
            else
            {


                /*" -6649- MOVE V0PROP-CODSUBES TO WHOST-CODSUBES */
                _.Move(V0PROP_CODSUBES, WHOST_CODSUBES);

                /*" -6651- END-IF */
            }


            /*" -6692- PERFORM R6900_00_DECLARE_VGRAMOCOMP_DB_DECLARE_1 */

            R6900_00_DECLARE_VGRAMOCOMP_DB_DECLARE_1();

            /*" -6696- MOVE 83 TO W01-I */
            _.Move(83, FILLER_11.W01_I);

            /*" -6697- MOVE 'OPEN CVGRAMOCOMP' TO W01-TEXTO(W01-I) */
            _.Move("OPEN CVGRAMOCOMP", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -6701- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -6701- PERFORM R6900_00_DECLARE_VGRAMOCOMP_DB_OPEN_1 */

            R6900_00_DECLARE_VGRAMOCOMP_DB_OPEN_1();

            /*" -6705- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -6710- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -6711- IF (SQLCODE NOT EQUAL ZEROES) */

            if ((DB.SQLCODE != 00))
            {

                /*" -6712- DISPLAY '6900 - (PROBLEMAS NO DECLARE CVGRAMOCOMP) ..' */
                _.Display($"6900 - (PROBLEMAS NO DECLARE CVGRAMOCOMP) ..");

                /*" -6713- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -6714- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -6715- END-IF. */
            }


        }

        [StopWatch]
        /*" R6900-00-DECLARE-VGRAMOCOMP-DB-OPEN-1 */
        public void R6900_00_DECLARE_VGRAMOCOMP_DB_OPEN_1()
        {
            /*" -6701- EXEC SQL OPEN CVGRAMOCOMP END-EXEC. */

            CVGRAMOCOMP.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6900_99_SAIDA*/

        [StopWatch]
        /*" R6910-00-FETCH-VGRAMOCOMP-SECTION */
        private void R6910_00_FETCH_VGRAMOCOMP_SECTION()
        {
            /*" -6723- MOVE '6910-00-FETCH-CURSOR         ' TO PARAGRAFO. */
            _.Move("6910-00-FETCH-CURSOR         ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6726- MOVE 'FETCH     CVGRAMOCOMP' TO COMANDO. */
            _.Move("FETCH     CVGRAMOCOMP", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -6727- MOVE 84 TO W01-I */
            _.Move(84, FILLER_11.W01_I);

            /*" -6728- MOVE 'FETCH CVGRAMOCOMP' TO W01-TEXTO(W01-I) */
            _.Move("FETCH CVGRAMOCOMP", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -6732- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -6745- PERFORM R6910_00_FETCH_VGRAMOCOMP_DB_FETCH_1 */

            R6910_00_FETCH_VGRAMOCOMP_DB_FETCH_1();

            /*" -6749- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -6753- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -6754- IF (SQLCODE NOT EQUAL ZEROES) */

            if ((DB.SQLCODE != 00))
            {

                /*" -6755- IF (SQLCODE EQUAL 100) */

                if ((DB.SQLCODE == 100))
                {

                    /*" -6758- MOVE 'SIM' TO WFIM-VGRAMOCOMP */
                    _.Move("SIM", WORK_AREA.WFIM_VGRAMOCOMP);

                    /*" -6759- MOVE 85 TO W01-I */
                    _.Move(85, FILLER_11.W01_I);

                    /*" -6761- MOVE 'CLOSE CVGRAMOCOMP' TO W01-TEXTO(W01-I) */
                    _.Move("CLOSE CVGRAMOCOMP", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

                    /*" -6765- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

                    R8900_TOTALIZA_INICIO_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


                    /*" -6765- PERFORM R6910_00_FETCH_VGRAMOCOMP_DB_CLOSE_1 */

                    R6910_00_FETCH_VGRAMOCOMP_DB_CLOSE_1();

                    /*" -6769- MOVE 1 TO W01-QTD-ACC-OK */
                    _.Move(1, FILLER_11.W01_QTD_ACC_OK);

                    /*" -6772- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

                    R8910_TOTALIZA_FINAL_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


                    /*" -6773- ELSE */
                }
                else
                {


                    /*" -6774- DISPLAY '6910 - (PROBLEMAS NO FETCH CVGRAMOCOMP) ..' */
                    _.Display($"6910 - (PROBLEMAS NO FETCH CVGRAMOCOMP) ..");

                    /*" -6775- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -6776- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -6777- END-IF */
                }


                /*" -6779- END-IF. */
            }


            /*" -6792- IF (VG081-RAMO-EMISSOR EQUAL 90) AND (VG081-COD-MODALIDADE EQUAL 5) */

            if ((VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR == 90) && (VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_MODALIDADE == 5))
            {

                /*" -6793- GO TO R6910-00-FETCH-VGRAMOCOMP */
                new Task(() => R6910_00_FETCH_VGRAMOCOMP_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -6794- END-IF. */
            }


        }

        [StopWatch]
        /*" R6910-00-FETCH-VGRAMOCOMP-DB-FETCH-1 */
        public void R6910_00_FETCH_VGRAMOCOMP_DB_FETCH_1()
        {
            /*" -6745- EXEC SQL FETCH CVGRAMOCOMP INTO :VG081-NUM-APOLICE , :VG081-COD-SUBGRUPO , :VG081-COD-GRUPO-SUSEP , :VG081-RAMO-EMISSOR , :VG081-COD-MODALIDADE , :VG081-DTH-INI-VIGENCIA , :VG081-COD-OPCAO-COBERTURA , :VG081-NUM-IDADE-INICIAL , :VG081-NUM-IDADE-FINAL , :VG081-VLR-PERC-PREMIO , :VG081-COD-USUARIO , :VG081-DTH-ATUALIZACAO END-EXEC */

            if (CVGRAMOCOMP.Fetch())
            {
                _.Move(CVGRAMOCOMP.VG081_NUM_APOLICE, VG081.DCLVG_PARAM_RAMO_COMP.VG081_NUM_APOLICE);
                _.Move(CVGRAMOCOMP.VG081_COD_SUBGRUPO, VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_SUBGRUPO);
                _.Move(CVGRAMOCOMP.VG081_COD_GRUPO_SUSEP, VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_GRUPO_SUSEP);
                _.Move(CVGRAMOCOMP.VG081_RAMO_EMISSOR, VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR);
                _.Move(CVGRAMOCOMP.VG081_COD_MODALIDADE, VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_MODALIDADE);
                _.Move(CVGRAMOCOMP.VG081_DTH_INI_VIGENCIA, VG081.DCLVG_PARAM_RAMO_COMP.VG081_DTH_INI_VIGENCIA);
                _.Move(CVGRAMOCOMP.VG081_COD_OPCAO_COBERTURA, VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_OPCAO_COBERTURA);
                _.Move(CVGRAMOCOMP.VG081_NUM_IDADE_INICIAL, VG081.DCLVG_PARAM_RAMO_COMP.VG081_NUM_IDADE_INICIAL);
                _.Move(CVGRAMOCOMP.VG081_NUM_IDADE_FINAL, VG081.DCLVG_PARAM_RAMO_COMP.VG081_NUM_IDADE_FINAL);
                _.Move(CVGRAMOCOMP.VG081_VLR_PERC_PREMIO, VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO);
                _.Move(CVGRAMOCOMP.VG081_COD_USUARIO, VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_USUARIO);
                _.Move(CVGRAMOCOMP.VG081_DTH_ATUALIZACAO, VG081.DCLVG_PARAM_RAMO_COMP.VG081_DTH_ATUALIZACAO);
            }

        }

        [StopWatch]
        /*" R6910-00-FETCH-VGRAMOCOMP-DB-CLOSE-1 */
        public void R6910_00_FETCH_VGRAMOCOMP_DB_CLOSE_1()
        {
            /*" -6765- EXEC SQL CLOSE CVGRAMOCOMP END-EXEC */

            CVGRAMOCOMP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6910_99_SAIDA*/

        [StopWatch]
        /*" R6920-00-SELECT-HISCOBPR-SECTION */
        private void R6920_00_SELECT_HISCOBPR_SECTION()
        {
            /*" -6802- MOVE 'R6920-00-SELECT-HISCOBPR' TO PARAGRAFO. */
            _.Move("R6920-00-SELECT-HISCOBPR", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6807- MOVE 'SELECT COBERPROPVA' TO COMANDO. */
            _.Move("SELECT COBERPROPVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -6808- MOVE 86 TO W01-I */
            _.Move(86, FILLER_11.W01_I);

            /*" -6810- MOVE 'SELECT V0COBERPROPVA' TO W01-TEXTO(W01-I) */
            _.Move("SELECT V0COBERPROPVA", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -6814- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -6823- PERFORM R6920_00_SELECT_HISCOBPR_DB_SELECT_1 */

            R6920_00_SELECT_HISCOBPR_DB_SELECT_1();

            /*" -6827- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -6832- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -6833- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -6837- DISPLAY 'VA0813B - PROBLEMAS NO SELECT HISCOBPR' V0HCTA-NRCERTIF ' ' V0PARC-DTVENCTO ' ' V0PROP-OCORHIST */

                $"VA0813B - PROBLEMAS NO SELECT HISCOBPR{V0HCTA_NRCERTIF} {V0PARC_DTVENCTO} {V0PROP_OCORHIST}"
                .Display();

                /*" -6838- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R6920-00-SELECT-HISCOBPR-DB-SELECT-1 */
        public void R6920_00_SELECT_HISCOBPR_DB_SELECT_1()
        {
            /*" -6823- EXEC SQL SELECT IMPMORNATU, IMPMORACID INTO :V0COBP-IMPMORNATU, :V0COBP-IMPMORACID FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :V0HCTA-NRCERTIF AND OCORHIST = 1 WITH UR END-EXEC. */

            var r6920_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 = new R6920_00_SELECT_HISCOBPR_DB_SELECT_1_Query1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
            };

            var executed_1 = R6920_00_SELECT_HISCOBPR_DB_SELECT_1_Query1.Execute(r6920_00_SELECT_HISCOBPR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBP_IMPMORNATU, V0COBP_IMPMORNATU);
                _.Move(executed_1.V0COBP_IMPMORACID, V0COBP_IMPMORACID);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6920_99_SAIDA*/

        [StopWatch]
        /*" R7000-00-PROCESSA-VGRAMOCOMP-SECTION */
        private void R7000_00_PROCESSA_VGRAMOCOMP_SECTION()
        {
            /*" -6847- MOVE '7000-00-PROCESSA-VGRAMOCOMP  ' TO PARAGRAFO. */
            _.Move("7000-00-PROCESSA-VGRAMOCOMP  ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6849- MOVE 'PROCESSA  CVGRAMOCOMP' TO COMANDO. */
            _.Move("PROCESSA  CVGRAMOCOMP", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -6850- MOVE VG081-COD-GRUPO-SUSEP TO WS-GRUPO-SUSEP-ANT */
            _.Move(VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_GRUPO_SUSEP, WORK_RAMO_CONJ.WS_GRUPO_SUSEP_ANT);

            /*" -6852- MOVE VG081-RAMO-EMISSOR TO WS-RAMO-CONJ-ANT */
            _.Move(VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR, WORK_RAMO_CONJ.WS_RAMO_CONJ_ANT);

            /*" -6855- MOVE ZEROS TO WHOST-TAXA-RAMO WHOST-VLR-PERC-PREMIO */
            _.Move(0, WHOST_TAXA_RAMO, WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO);

            /*" -6856- IF (V0PRVG-ORIG-PRODU(1:4) EQUAL 'ESPE' ) */

            if ((V0PRVG_ORIG_PRODU.Substring(1, 4) == "ESPE"))
            {

                /*" -6857- MOVE V0PROP-CODSUBES TO CONDITEC-COD-SUBGRUPO */
                _.Move(V0PROP_CODSUBES, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_COD_SUBGRUPO);

                /*" -6858- PERFORM R7170-00-SELECT-CONDITEC */

                R7170_00_SELECT_CONDITEC_SECTION();

                /*" -6864- PERFORM R7150-00-PROCESSA-REGISTRO UNTIL WFIM-VGRAMOCOMP EQUAL 'SIM' OR VG081-COD-GRUPO-SUSEP NOT EQUAL WS-GRUPO-SUSEP-ANT OR VG081-RAMO-EMISSOR NOT EQUAL WS-RAMO-CONJ-ANT */

                while (!(WORK_AREA.WFIM_VGRAMOCOMP == "SIM" || VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_GRUPO_SUSEP != WORK_RAMO_CONJ.WS_GRUPO_SUSEP_ANT || VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR != WORK_RAMO_CONJ.WS_RAMO_CONJ_ANT))
                {

                    R7150_00_PROCESSA_REGISTRO_SECTION();
                }

                /*" -6865- ELSE */
            }
            else
            {


                /*" -6866- IF (V0PRVG-ORIG-PRODU EQUAL 'GLOBAL' ) */

                if ((V0PRVG_ORIG_PRODU == "GLOBAL"))
                {

                    /*" -6867- MOVE V0PROP-CODSUBES TO CONDITEC-COD-SUBGRUPO */
                    _.Move(V0PROP_CODSUBES, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_COD_SUBGRUPO);

                    /*" -6868- PERFORM R7170-00-SELECT-CONDITEC */

                    R7170_00_SELECT_CONDITEC_SECTION();

                    /*" -6874- PERFORM R7180-00-PROCESSA-GLOBAL UNTIL WFIM-VGRAMOCOMP EQUAL 'SIM' OR VG081-COD-GRUPO-SUSEP NOT EQUAL WS-GRUPO-SUSEP-ANT OR VG081-RAMO-EMISSOR NOT EQUAL WS-RAMO-CONJ-ANT */

                    while (!(WORK_AREA.WFIM_VGRAMOCOMP == "SIM" || VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_GRUPO_SUSEP != WORK_RAMO_CONJ.WS_GRUPO_SUSEP_ANT || VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR != WORK_RAMO_CONJ.WS_RAMO_CONJ_ANT))
                    {

                        R7180_00_PROCESSA_GLOBAL_SECTION();
                    }

                    /*" -6875- ELSE */
                }
                else
                {


                    /*" -6881- PERFORM R7100-00-PROCESSA-REGISTRO UNTIL WFIM-VGRAMOCOMP EQUAL 'SIM' OR VG081-COD-GRUPO-SUSEP NOT EQUAL WS-GRUPO-SUSEP-ANT OR VG081-RAMO-EMISSOR NOT EQUAL WS-RAMO-CONJ-ANT */

                    while (!(WORK_AREA.WFIM_VGRAMOCOMP == "SIM" || VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_GRUPO_SUSEP != WORK_RAMO_CONJ.WS_GRUPO_SUSEP_ANT || VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR != WORK_RAMO_CONJ.WS_RAMO_CONJ_ANT))
                    {

                        R7100_00_PROCESSA_REGISTRO_SECTION();
                    }

                    /*" -6882- END-IF */
                }


                /*" -6884- END-IF. */
            }


            /*" -6886- ADD 1 TO WS-IND */
            WORK_RAMO_CONJ.WS_IND.Value = WORK_RAMO_CONJ.WS_IND + 1;

            /*" -6887- MOVE WS-GRUPO-SUSEP-ANT TO TB-GRUPO-SUSEP(WS-IND). */
            _.Move(WORK_RAMO_CONJ.WS_GRUPO_SUSEP_ANT, WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND].TB_GRUPO_SUSEP);

            /*" -6888- MOVE WS-RAMO-CONJ-ANT TO TB-RAMO-CONJ(WS-IND). */
            _.Move(WORK_RAMO_CONJ.WS_RAMO_CONJ_ANT, WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND].TB_RAMO_CONJ);

            /*" -6888- MOVE WHOST-VLR-PERC-PREMIO TO TB-TAXA-RAMO-CONJ(WS-IND). */
            _.Move(WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO, WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND].TB_TAXA_RAMO_CONJ);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7000_99_SAIDA*/

        [StopWatch]
        /*" R7100-00-PROCESSA-REGISTRO-SECTION */
        private void R7100_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -6897- MOVE '7100-00-PROCESSA-REGISTRO    ' TO PARAGRAFO. */
            _.Move("7100-00-PROCESSA-REGISTRO    ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6899- MOVE 'PROCESSAR CVGRAMOCOMP' TO COMANDO. */
            _.Move("PROCESSAR CVGRAMOCOMP", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -6902- IF (V0PROP-NUM-APOLICE = 109300000550) AND (WS-RAMO-CONJ-ANT = 84) */

            if ((V0PROP_NUM_APOLICE == 109300000550) && (WORK_RAMO_CONJ.WS_RAMO_CONJ_ANT == 84))
            {

                /*" -6903- IF (V0COBP-IMPMORNATU > ZEROS) */

                if ((V0COBP_IMPMORNATU > 00))
                {

                    /*" -6905- DIVIDE V0COBP-IMPSEGCDG BY V0COBP-IMPMORNATU GIVING WHOST-PERC-CDG */
                    _.Divide(V0COBP_IMPSEGCDG, V0COBP_IMPMORNATU, WHOST_PERC_CDG);

                    /*" -6906- ELSE */
                }
                else
                {


                    /*" -6907- IF (V0COBP-IMPMORACID > ZEROS) */

                    if ((V0COBP_IMPMORACID > 00))
                    {

                        /*" -6909- DIVIDE V0COBP-IMPSEGCDG BY V0COBP-IMPMORACID GIVING WHOST-PERC-CDG */
                        _.Divide(V0COBP_IMPSEGCDG, V0COBP_IMPMORACID, WHOST_PERC_CDG);

                        /*" -6910- ELSE */
                    }
                    else
                    {


                        /*" -6911- MOVE ZEROS TO WHOST-PERC-CDG */
                        _.Move(0, WHOST_PERC_CDG);

                        /*" -6912- END-IF */
                    }


                    /*" -6913- END-IF */
                }


                /*" -6915- COMPUTE VG081-VLR-PERC-PREMIO = VG081-VLR-PERC-PREMIO * WHOST-PERC-CDG */
                VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO.Value = VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO * WHOST_PERC_CDG;

                /*" -6917- END-IF. */
            }


            /*" -6918- IF (WS-RAMO-CONJ-ANT EQUAL 82) */

            if ((WORK_RAMO_CONJ.WS_RAMO_CONJ_ANT == 82))
            {

                /*" -6919- IF (V0COBP-IMPMORNATU > ZEROS) */

                if ((V0COBP_IMPMORNATU > 00))
                {

                    /*" -6921- DIVIDE V0COBP-IMPDIT BY V0COBP-IMPMORNATU GIVING WHOST-PERC-DIT */
                    _.Divide(V0COBP_IMPDIT, V0COBP_IMPMORNATU, WHOST_PERC_DIT);

                    /*" -6922- ELSE */
                }
                else
                {


                    /*" -6923- IF (V0COBP-IMPMORACID > ZEROS) */

                    if ((V0COBP_IMPMORACID > 00))
                    {

                        /*" -6925- DIVIDE V0COBP-IMPDIT BY V0COBP-IMPMORACID GIVING WHOST-PERC-DIT */
                        _.Divide(V0COBP_IMPDIT, V0COBP_IMPMORACID, WHOST_PERC_DIT);

                        /*" -6926- ELSE */
                    }
                    else
                    {


                        /*" -6927- MOVE ZEROS TO WHOST-PERC-DIT */
                        _.Move(0, WHOST_PERC_DIT);

                        /*" -6928- END-IF */
                    }


                    /*" -6929- END-IF */
                }


                /*" -6931- COMPUTE VG081-VLR-PERC-PREMIO = VG081-VLR-PERC-PREMIO * WHOST-PERC-DIT */
                VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO.Value = VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO * WHOST_PERC_DIT;

                /*" -6933- END-IF. */
            }


            /*" -6936- ADD VG081-VLR-PERC-PREMIO TO WHOST-VLR-PERC-PREMIO WHOST-VLR-PERC-PREMIO-TOT. */
            WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO.Value = WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO + VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO;
            WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO_TOT.Value = WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO_TOT + VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO;

            /*" -6937- PERFORM R6910-00-FETCH-VGRAMOCOMP. */

            R6910_00_FETCH_VGRAMOCOMP_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7100_99_SAIDA*/

        [StopWatch]
        /*" R7150-00-PROCESSA-REGISTRO-SECTION */
        private void R7150_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -6949- MOVE '7150-00-PROCESSA-REGISTRO    ' TO PARAGRAFO. */
            _.Move("7150-00-PROCESSA-REGISTRO    ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6951- IF VG081-RAMO-EMISSOR = 29 AND VG081-COD-MODALIDADE = 1001 */

            if (VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR == 29 && VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_MODALIDADE == 1001)
            {

                /*" -6952- MOVE 03 TO VGCOBSUB-COD-COBERTURA */
                _.Move(03, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA);

                /*" -6953- PERFORM R7160-00-LEITURA-VGCOBSUB */

                R7160_00_LEITURA_VGCOBSUB_SECTION();

                /*" -6956- COMPUTE VGCOBSUB-IMP-SEGURADA-IX = VGCOBSUB-IMP-SEGURADA-IX * V0COBP-QUANT-VIDAS */
                VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX.Value = VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX * V0COBP_QUANT_VIDAS;

                /*" -6957- IF V0COBP-IMPMORNATU > 0 */

                if (V0COBP_IMPMORNATU > 0)
                {

                    /*" -6960- DIVIDE VGCOBSUB-IMP-SEGURADA-IX BY V0COBP-IMPMORNATU GIVING WHOST-PERCENT */
                    _.Divide(VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX, V0COBP_IMPMORNATU, WHOST_PERCENT);

                    /*" -6961- ELSE */
                }
                else
                {


                    /*" -6962- IF V0COBP-IMPMORACID > 0 */

                    if (V0COBP_IMPMORACID > 0)
                    {

                        /*" -6965- DIVIDE VGCOBSUB-IMP-SEGURADA-IX BY V0COBP-IMPMORACID GIVING WHOST-PERCENT */
                        _.Divide(VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX, V0COBP_IMPMORACID, WHOST_PERCENT);

                        /*" -6966- ELSE */
                    }
                    else
                    {


                        /*" -6967- MOVE ZEROS TO WHOST-PERCENT */
                        _.Move(0, WHOST_PERCENT);

                        /*" -6968- END-IF */
                    }


                    /*" -6969- END-IF */
                }


                /*" -6971- COMPUTE VG081-VLR-PERC-PREMIO = VG081-VLR-PERC-PREMIO * WHOST-PERCENT */
                VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO.Value = VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO * WHOST_PERCENT;

                /*" -6973- END-IF. */
            }


            /*" -6975- IF VG081-RAMO-EMISSOR = 90 AND VG081-COD-MODALIDADE = 1001 */

            if (VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR == 90 && VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_MODALIDADE == 1001)
            {

                /*" -6976- MOVE 05 TO VGCOBSUB-COD-COBERTURA */
                _.Move(05, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA);

                /*" -6977- PERFORM R7160-00-LEITURA-VGCOBSUB */

                R7160_00_LEITURA_VGCOBSUB_SECTION();

                /*" -6980- COMPUTE VGCOBSUB-IMP-SEGURADA-IX = VGCOBSUB-IMP-SEGURADA-IX * V0COBP-QUANT-VIDAS */
                VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX.Value = VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX * V0COBP_QUANT_VIDAS;

                /*" -6981- IF V0COBP-IMPMORNATU > 0 */

                if (V0COBP_IMPMORNATU > 0)
                {

                    /*" -6984- DIVIDE VGCOBSUB-IMP-SEGURADA-IX BY V0COBP-IMPMORNATU GIVING WHOST-PERCENT */
                    _.Divide(VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX, V0COBP_IMPMORNATU, WHOST_PERCENT);

                    /*" -6985- ELSE */
                }
                else
                {


                    /*" -6986- IF V0COBP-IMPMORACID > 0 */

                    if (V0COBP_IMPMORACID > 0)
                    {

                        /*" -6989- DIVIDE VGCOBSUB-IMP-SEGURADA-IX BY V0COBP-IMPMORACID GIVING WHOST-PERCENT */
                        _.Divide(VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX, V0COBP_IMPMORACID, WHOST_PERCENT);

                        /*" -6990- ELSE */
                    }
                    else
                    {


                        /*" -6991- MOVE ZEROS TO WHOST-PERCENT */
                        _.Move(0, WHOST_PERCENT);

                        /*" -6992- END-IF */
                    }


                    /*" -6993- END-IF */
                }


                /*" -6995- COMPUTE VG081-VLR-PERC-PREMIO = VG081-VLR-PERC-PREMIO * WHOST-PERCENT */
                VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO.Value = VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO * WHOST_PERCENT;

                /*" -6999- END-IF. */
            }


            /*" -7001- IF VG081-RAMO-EMISSOR = 82 AND VG081-COD-MODALIDADE = 1009 */

            if (VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR == 82 && VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_MODALIDADE == 1009)
            {

                /*" -7002- IF V0COBP-IMPMORNATU > 0 */

                if (V0COBP_IMPMORNATU > 0)
                {

                    /*" -7005- DIVIDE V0COBP-IMPDIT BY V0COBP-IMPMORNATU GIVING WHOST-PERCENT */
                    _.Divide(V0COBP_IMPDIT, V0COBP_IMPMORNATU, WHOST_PERCENT);

                    /*" -7006- ELSE */
                }
                else
                {


                    /*" -7007- IF V0COBP-IMPMORACID > 0 */

                    if (V0COBP_IMPMORACID > 0)
                    {

                        /*" -7010- DIVIDE V0COBP-IMPDIT BY V0COBP-IMPMORACID GIVING WHOST-PERCENT */
                        _.Divide(V0COBP_IMPDIT, V0COBP_IMPMORACID, WHOST_PERCENT);

                        /*" -7011- ELSE */
                    }
                    else
                    {


                        /*" -7012- MOVE ZEROS TO WHOST-PERCENT */
                        _.Move(0, WHOST_PERCENT);

                        /*" -7013- END-IF */
                    }


                    /*" -7014- END-IF */
                }


                /*" -7016- COMPUTE VG081-VLR-PERC-PREMIO = VG081-VLR-PERC-PREMIO * WHOST-PERCENT */
                VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO.Value = VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO * WHOST_PERCENT;

                /*" -7018- END-IF. */
            }


            /*" -7020- IF VG081-RAMO-EMISSOR = 84 AND VG081-COD-MODALIDADE = 1001 */

            if (VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR == 84 && VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_MODALIDADE == 1001)
            {

                /*" -7021- MOVE 06 TO VGCOBSUB-COD-COBERTURA */
                _.Move(06, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA);

                /*" -7022- PERFORM R7160-00-LEITURA-VGCOBSUB */

                R7160_00_LEITURA_VGCOBSUB_SECTION();

                /*" -7025- COMPUTE VGCOBSUB-IMP-SEGURADA-IX = VGCOBSUB-IMP-SEGURADA-IX * V0COBP-QUANT-VIDAS */
                VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX.Value = VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX * V0COBP_QUANT_VIDAS;

                /*" -7026- IF V0COBP-IMPMORNATU > 0 */

                if (V0COBP_IMPMORNATU > 0)
                {

                    /*" -7029- DIVIDE VGCOBSUB-IMP-SEGURADA-IX BY V0COBP-IMPMORNATU GIVING WHOST-PERCENT */
                    _.Divide(VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX, V0COBP_IMPMORNATU, WHOST_PERCENT);

                    /*" -7030- ELSE */
                }
                else
                {


                    /*" -7031- IF V0COBP-IMPMORACID > 0 */

                    if (V0COBP_IMPMORACID > 0)
                    {

                        /*" -7034- DIVIDE VGCOBSUB-IMP-SEGURADA-IX BY V0COBP-IMPMORACID GIVING WHOST-PERCENT */
                        _.Divide(VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX, V0COBP_IMPMORACID, WHOST_PERCENT);

                        /*" -7035- ELSE */
                    }
                    else
                    {


                        /*" -7036- MOVE ZEROS TO WHOST-PERCENT */
                        _.Move(0, WHOST_PERCENT);

                        /*" -7037- END-IF */
                    }


                    /*" -7038- END-IF */
                }


                /*" -7040- COMPUTE VG081-VLR-PERC-PREMIO = VG081-VLR-PERC-PREMIO * WHOST-PERCENT */
                VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO.Value = VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO * WHOST_PERCENT;

                /*" -7042- END-IF. */
            }


            /*" -7044- IF VG081-RAMO-EMISSOR = 84 AND VG081-COD-MODALIDADE = 1002 */

            if (VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR == 84 && VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_MODALIDADE == 1002)
            {

                /*" -7045- MOVE 22 TO VGCOBSUB-COD-COBERTURA */
                _.Move(22, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA);

                /*" -7047- PERFORM R7160-00-LEITURA-VGCOBSUB */

                R7160_00_LEITURA_VGCOBSUB_SECTION();

                /*" -7048- IF V0COBP-IMPMORNATU > 0 */

                if (V0COBP_IMPMORNATU > 0)
                {

                    /*" -7051- COMPUTE WS-IMP-SEGURADA = V0COBP-IMPMORNATU / V0COBP-QUANT-VIDAS * 0,30 */
                    WS_IMP_SEGURADA.Value = V0COBP_IMPMORNATU / V0COBP_QUANT_VIDAS * 0.30;

                    /*" -7053- IF VGCOBSUB-IMP-SEGURADA-IX > WS-IMP-SEGURADA */

                    if (VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX > WS_IMP_SEGURADA)
                    {

                        /*" -7055- MOVE WS-IMP-SEGURADA TO VGCOBSUB-IMP-SEGURADA-IX */
                        _.Move(WS_IMP_SEGURADA, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX);

                        /*" -7057- END-IF */
                    }


                    /*" -7061- COMPUTE VGCOBSUB-IMP-SEGURADA-IX = VGCOBSUB-IMP-SEGURADA-IX * V0COBP-QUANT-VIDAS */
                    VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX.Value = VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX * V0COBP_QUANT_VIDAS;

                    /*" -7064- DIVIDE VGCOBSUB-IMP-SEGURADA-IX BY V0COBP-IMPMORNATU GIVING WHOST-PERCENT */
                    _.Divide(VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX, V0COBP_IMPMORNATU, WHOST_PERCENT);

                    /*" -7065- ELSE */
                }
                else
                {


                    /*" -7066- IF V0COBP-IMPMORACID > 0 */

                    if (V0COBP_IMPMORACID > 0)
                    {

                        /*" -7069- COMPUTE WS-IMP-SEGURADA = V0COBP-IMPMORACID / V0COBP-QUANT-VIDAS * 0,30 */
                        WS_IMP_SEGURADA.Value = V0COBP_IMPMORACID / V0COBP_QUANT_VIDAS * 0.30;

                        /*" -7071- IF VGCOBSUB-IMP-SEGURADA-IX > WS-IMP-SEGURADA */

                        if (VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX > WS_IMP_SEGURADA)
                        {

                            /*" -7073- MOVE WS-IMP-SEGURADA TO VGCOBSUB-IMP-SEGURADA-IX */
                            _.Move(WS_IMP_SEGURADA, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX);

                            /*" -7075- END-IF */
                        }


                        /*" -7078- COMPUTE VGCOBSUB-IMP-SEGURADA-IX = VGCOBSUB-IMP-SEGURADA-IX * V0COBP-QUANT-VIDAS */
                        VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX.Value = VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX * V0COBP_QUANT_VIDAS;

                        /*" -7081- DIVIDE VGCOBSUB-IMP-SEGURADA-IX BY V0COBP-IMPMORACID GIVING WHOST-PERCENT */
                        _.Divide(VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX, V0COBP_IMPMORACID, WHOST_PERCENT);

                        /*" -7082- ELSE */
                    }
                    else
                    {


                        /*" -7083- MOVE ZEROS TO WHOST-PERCENT */
                        _.Move(0, WHOST_PERCENT);

                        /*" -7084- END-IF */
                    }


                    /*" -7085- END-IF */
                }


                /*" -7087- COMPUTE VG081-VLR-PERC-PREMIO = VG081-VLR-PERC-PREMIO * WHOST-PERCENT */
                VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO.Value = VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO * WHOST_PERCENT;

                /*" -7089- END-IF. */
            }


            /*" -7091- IF VG081-RAMO-EMISSOR = 84 AND VG081-COD-MODALIDADE = 1003 */

            if (VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR == 84 && VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_MODALIDADE == 1003)
            {

                /*" -7092- MOVE 11 TO VGCOBSUB-COD-COBERTURA */
                _.Move(11, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA);

                /*" -7093- PERFORM R7160-00-LEITURA-VGCOBSUB */

                R7160_00_LEITURA_VGCOBSUB_SECTION();

                /*" -7096- COMPUTE VGCOBSUB-IMP-SEGURADA-IX = VGCOBSUB-IMP-SEGURADA-IX * V0COBP-QUANT-VIDAS */
                VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX.Value = VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX * V0COBP_QUANT_VIDAS;

                /*" -7097- IF V0COBP-IMPMORNATU > 0 */

                if (V0COBP_IMPMORNATU > 0)
                {

                    /*" -7100- DIVIDE VGCOBSUB-IMP-SEGURADA-IX BY V0COBP-IMPMORNATU GIVING WHOST-PERCENT */
                    _.Divide(VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX, V0COBP_IMPMORNATU, WHOST_PERCENT);

                    /*" -7101- ELSE */
                }
                else
                {


                    /*" -7102- IF V0COBP-IMPMORACID > 0 */

                    if (V0COBP_IMPMORACID > 0)
                    {

                        /*" -7105- DIVIDE VGCOBSUB-IMP-SEGURADA-IX BY V0COBP-IMPMORACID GIVING WHOST-PERCENT */
                        _.Divide(VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX, V0COBP_IMPMORACID, WHOST_PERCENT);

                        /*" -7106- ELSE */
                    }
                    else
                    {


                        /*" -7107- MOVE ZEROS TO WHOST-PERCENT */
                        _.Move(0, WHOST_PERCENT);

                        /*" -7108- END-IF */
                    }


                    /*" -7109- END-IF */
                }


                /*" -7111- COMPUTE VG081-VLR-PERC-PREMIO = VG081-VLR-PERC-PREMIO * WHOST-PERCENT */
                VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO.Value = VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO * WHOST_PERCENT;

                /*" -7113- END-IF. */
            }


            /*" -7115- IF VG081-RAMO-EMISSOR = 93 AND VG081-COD-MODALIDADE = 1002 */

            if (VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR == 93 && VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_MODALIDADE == 1002)
            {

                /*" -7116- IF V0COBP-IMPMORNATU > 0 */

                if (V0COBP_IMPMORNATU > 0)
                {

                    /*" -7119- COMPUTE WHOST-IMPSEG = V0COBP-IMPMORNATU * CONDITEC-CARREGA-CONJUGE / 100 */
                    WHOST_IMPSEG.Value = V0COBP_IMPMORNATU * CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE / 100f;

                    /*" -7122- DIVIDE WHOST-IMPSEG BY V0COBP-IMPMORNATU GIVING WHOST-PERCENT */
                    _.Divide(WHOST_IMPSEG, V0COBP_IMPMORNATU, WHOST_PERCENT);

                    /*" -7123- ELSE */
                }
                else
                {


                    /*" -7124- IF V0COBP-IMPMORACID > 0 */

                    if (V0COBP_IMPMORACID > 0)
                    {

                        /*" -7127- COMPUTE WHOST-IMPSEG = V0COBP-IMPMORACID * CONDITEC-CARREGA-CONJUGE / 100 */
                        WHOST_IMPSEG.Value = V0COBP_IMPMORACID * CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE / 100f;

                        /*" -7130- DIVIDE WHOST-IMPSEG BY V0COBP-IMPMORACID GIVING WHOST-PERCENT */
                        _.Divide(WHOST_IMPSEG, V0COBP_IMPMORACID, WHOST_PERCENT);

                        /*" -7131- ELSE */
                    }
                    else
                    {


                        /*" -7132- MOVE ZEROS TO WHOST-PERCENT */
                        _.Move(0, WHOST_PERCENT);

                        /*" -7133- END-IF */
                    }


                    /*" -7134- END-IF */
                }


                /*" -7136- COMPUTE VG081-VLR-PERC-PREMIO = VG081-VLR-PERC-PREMIO * WHOST-PERCENT */
                VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO.Value = VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO * WHOST_PERCENT;

                /*" -7138- END-IF. */
            }


            /*" -7140- IF VG081-RAMO-EMISSOR = 93 AND VG081-COD-MODALIDADE = 1003 */

            if (VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR == 93 && VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_MODALIDADE == 1003)
            {

                /*" -7141- IF V0COBP-IMPMORNATU > 0 */

                if (V0COBP_IMPMORNATU > 0)
                {

                    /*" -7144- COMPUTE WHOST-IMPSEG = V0COBP-IMPMORNATU * CONDITEC-CARREGA-CONJUGE / 100 */
                    WHOST_IMPSEG.Value = V0COBP_IMPMORNATU * CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE / 100f;

                    /*" -7147- DIVIDE WHOST-IMPSEG BY V0COBP-IMPMORNATU GIVING WHOST-PERCENT */
                    _.Divide(WHOST_IMPSEG, V0COBP_IMPMORNATU, WHOST_PERCENT);

                    /*" -7148- ELSE */
                }
                else
                {


                    /*" -7149- IF V0COBP-IMPMORACID > 0 */

                    if (V0COBP_IMPMORACID > 0)
                    {

                        /*" -7152- COMPUTE WHOST-IMPSEG = V0COBP-IMPMORACID * CONDITEC-CARREGA-CONJUGE / 100 */
                        WHOST_IMPSEG.Value = V0COBP_IMPMORACID * CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE / 100f;

                        /*" -7155- DIVIDE WHOST-IMPSEG BY V0COBP-IMPMORACID GIVING WHOST-PERCENT */
                        _.Divide(WHOST_IMPSEG, V0COBP_IMPMORACID, WHOST_PERCENT);

                        /*" -7156- ELSE */
                    }
                    else
                    {


                        /*" -7157- MOVE ZEROS TO WHOST-PERCENT */
                        _.Move(0, WHOST_PERCENT);

                        /*" -7158- END-IF */
                    }


                    /*" -7159- END-IF */
                }


                /*" -7161- COMPUTE VG081-VLR-PERC-PREMIO = VG081-VLR-PERC-PREMIO * WHOST-PERCENT */
                VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO.Value = VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO * WHOST_PERCENT;

                /*" -7163- END-IF. */
            }


            /*" -7165- IF VG081-RAMO-EMISSOR = 93 AND VG081-COD-MODALIDADE = 1004 */

            if (VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR == 93 && VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_MODALIDADE == 1004)
            {

                /*" -7166- IF V0COBP-IMPMORNATU > 0 */

                if (V0COBP_IMPMORNATU > 0)
                {

                    /*" -7169- COMPUTE WHOST-IMPSEG = V0COBP-IMPMORNATU * CONDITEC-CARREGA-FILHOS / 100 */
                    WHOST_IMPSEG.Value = V0COBP_IMPMORNATU * CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_FILHOS / 100f;

                    /*" -7172- DIVIDE WHOST-IMPSEG BY V0COBP-IMPMORNATU GIVING WHOST-PERCENT */
                    _.Divide(WHOST_IMPSEG, V0COBP_IMPMORNATU, WHOST_PERCENT);

                    /*" -7173- ELSE */
                }
                else
                {


                    /*" -7174- IF V0COBP-IMPMORACID > 0 */

                    if (V0COBP_IMPMORACID > 0)
                    {

                        /*" -7177- COMPUTE WHOST-IMPSEG = V0COBP-IMPMORACID * CONDITEC-CARREGA-FILHOS / 100 */
                        WHOST_IMPSEG.Value = V0COBP_IMPMORACID * CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_FILHOS / 100f;

                        /*" -7180- DIVIDE WHOST-IMPSEG BY V0COBP-IMPMORACID GIVING WHOST-PERCENT */
                        _.Divide(WHOST_IMPSEG, V0COBP_IMPMORACID, WHOST_PERCENT);

                        /*" -7181- ELSE */
                    }
                    else
                    {


                        /*" -7182- MOVE ZEROS TO WHOST-PERCENT */
                        _.Move(0, WHOST_PERCENT);

                        /*" -7183- END-IF */
                    }


                    /*" -7184- END-IF */
                }


                /*" -7186- COMPUTE VG081-VLR-PERC-PREMIO = VG081-VLR-PERC-PREMIO * WHOST-PERCENT */
                VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO.Value = VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO * WHOST_PERCENT;

                /*" -7188- END-IF. */
            }


            /*" -7190- IF VG081-RAMO-EMISSOR = 93 AND VG081-COD-MODALIDADE = 1005 */

            if (VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR == 93 && VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_MODALIDADE == 1005)
            {

                /*" -7191- IF V0COBP-IMPMORNATU > 0 */

                if (V0COBP_IMPMORNATU > 0)
                {

                    /*" -7194- COMPUTE WHOST-IMPSEG = V0COBP-IMPMORNATU * CONDITEC-CARREGA-CONJUGE / 100 */
                    WHOST_IMPSEG.Value = V0COBP_IMPMORNATU * CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE / 100f;

                    /*" -7197- DIVIDE WHOST-IMPSEG BY V0COBP-IMPMORNATU GIVING WHOST-PERCENT */
                    _.Divide(WHOST_IMPSEG, V0COBP_IMPMORNATU, WHOST_PERCENT);

                    /*" -7198- ELSE */
                }
                else
                {


                    /*" -7199- IF V0COBP-IMPMORACID > 0 */

                    if (V0COBP_IMPMORACID > 0)
                    {

                        /*" -7202- COMPUTE WHOST-IMPSEG = V0COBP-IMPMORACID * CONDITEC-CARREGA-CONJUGE / 100 */
                        WHOST_IMPSEG.Value = V0COBP_IMPMORACID * CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE / 100f;

                        /*" -7205- DIVIDE WHOST-IMPSEG BY V0COBP-IMPMORACID GIVING WHOST-PERCENT */
                        _.Divide(WHOST_IMPSEG, V0COBP_IMPMORACID, WHOST_PERCENT);

                        /*" -7206- ELSE */
                    }
                    else
                    {


                        /*" -7207- MOVE ZEROS TO WHOST-PERCENT */
                        _.Move(0, WHOST_PERCENT);

                        /*" -7208- END-IF */
                    }


                    /*" -7209- END-IF */
                }


                /*" -7211- COMPUTE VG081-VLR-PERC-PREMIO = VG081-VLR-PERC-PREMIO * WHOST-PERCENT */
                VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO.Value = VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO * WHOST_PERCENT;

                /*" -7215- END-IF. */
            }


            /*" -7217- IF VG081-RAMO-EMISSOR = 82 AND VG081-COD-MODALIDADE = 1002 */

            if (VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR == 82 && VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_MODALIDADE == 1002)
            {

                /*" -7218- IF V0COBP-IMPMORNATU > 0 */

                if (V0COBP_IMPMORNATU > 0)
                {

                    /*" -7221- DIVIDE V0COBP-IMPINVPERM BY V0COBP-IMPMORNATU GIVING WHOST-PERCENT */
                    _.Divide(V0COBP_IMPINVPERM, V0COBP_IMPMORNATU, WHOST_PERCENT);

                    /*" -7222- ELSE */
                }
                else
                {


                    /*" -7223- IF V0COBP-IMPMORACID > 0 */

                    if (V0COBP_IMPMORACID > 0)
                    {

                        /*" -7226- DIVIDE V0COBP-IMPINVPERM BY V0COBP-IMPMORACID GIVING WHOST-PERCENT */
                        _.Divide(V0COBP_IMPINVPERM, V0COBP_IMPMORACID, WHOST_PERCENT);

                        /*" -7227- ELSE */
                    }
                    else
                    {


                        /*" -7228- MOVE ZEROS TO WHOST-PERCENT */
                        _.Move(0, WHOST_PERCENT);

                        /*" -7229- END-IF */
                    }


                    /*" -7230- END-IF */
                }


                /*" -7232- COMPUTE VG081-VLR-PERC-PREMIO = VG081-VLR-PERC-PREMIO * WHOST-PERCENT */
                VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO.Value = VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO * WHOST_PERCENT;

                /*" -7234- END-IF. */
            }


            /*" -7236- IF VG081-RAMO-EMISSOR = 82 AND VG081-COD-MODALIDADE = 1003 */

            if (VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR == 82 && VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_MODALIDADE == 1003)
            {

                /*" -7237- IF V0COBP-IMPMORNATU > 0 */

                if (V0COBP_IMPMORNATU > 0)
                {

                    /*" -7240- COMPUTE WHOST-IMPSEG = V0COBP-IMPMORNATU * CONDITEC-GARAN-ADIC-IEA / 100 */
                    WHOST_IMPSEG.Value = V0COBP_IMPMORNATU * CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_GARAN_ADIC_IEA / 100f;

                    /*" -7243- DIVIDE WHOST-IMPSEG BY V0COBP-IMPMORNATU GIVING WHOST-PERCENT */
                    _.Divide(WHOST_IMPSEG, V0COBP_IMPMORNATU, WHOST_PERCENT);

                    /*" -7244- ELSE */
                }
                else
                {


                    /*" -7245- IF V0COBP-IMPMORACID > 0 */

                    if (V0COBP_IMPMORACID > 0)
                    {

                        /*" -7248- COMPUTE WHOST-IMPSEG = V0COBP-IMPMORACID * CONDITEC-GARAN-ADIC-IEA / 100 */
                        WHOST_IMPSEG.Value = V0COBP_IMPMORACID * CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_GARAN_ADIC_IEA / 100f;

                        /*" -7251- DIVIDE WHOST-IMPSEG BY V0COBP-IMPMORACID GIVING WHOST-PERCENT */
                        _.Divide(WHOST_IMPSEG, V0COBP_IMPMORACID, WHOST_PERCENT);

                        /*" -7252- ELSE */
                    }
                    else
                    {


                        /*" -7253- MOVE ZEROS TO WHOST-PERCENT */
                        _.Move(0, WHOST_PERCENT);

                        /*" -7254- END-IF */
                    }


                    /*" -7255- END-IF */
                }


                /*" -7257- COMPUTE VG081-VLR-PERC-PREMIO = VG081-VLR-PERC-PREMIO * WHOST-PERCENT */
                VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO.Value = VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO * WHOST_PERCENT;

                /*" -7259- END-IF. */
            }


            /*" -7261- IF VG081-RAMO-EMISSOR = 82 AND VG081-COD-MODALIDADE = 1004 */

            if (VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR == 82 && VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_MODALIDADE == 1004)
            {

                /*" -7262- IF V0COBP-IMPMORNATU > 0 */

                if (V0COBP_IMPMORNATU > 0)
                {

                    /*" -7265- DIVIDE V0COBP-IMPINVPERM BY V0COBP-IMPMORNATU GIVING WHOST-PERCENT */
                    _.Divide(V0COBP_IMPINVPERM, V0COBP_IMPMORNATU, WHOST_PERCENT);

                    /*" -7266- ELSE */
                }
                else
                {


                    /*" -7267- IF V0COBP-IMPMORACID > 0 */

                    if (V0COBP_IMPMORACID > 0)
                    {

                        /*" -7270- DIVIDE V0COBP-IMPINVPERM BY V0COBP-IMPMORACID GIVING WHOST-PERCENT */
                        _.Divide(V0COBP_IMPINVPERM, V0COBP_IMPMORACID, WHOST_PERCENT);

                        /*" -7271- ELSE */
                    }
                    else
                    {


                        /*" -7272- MOVE ZEROS TO WHOST-PERCENT */
                        _.Move(0, WHOST_PERCENT);

                        /*" -7273- END-IF */
                    }


                    /*" -7274- END-IF */
                }


                /*" -7276- COMPUTE VG081-VLR-PERC-PREMIO = VG081-VLR-PERC-PREMIO * WHOST-PERCENT */
                VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO.Value = VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO * WHOST_PERCENT;

                /*" -7278- END-IF. */
            }


            /*" -7280- IF VG081-RAMO-EMISSOR = 82 AND VG081-COD-MODALIDADE = 1005 */

            if (VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR == 82 && VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_MODALIDADE == 1005)
            {

                /*" -7281- IF V0COBP-IMPMORNATU > 0 */

                if (V0COBP_IMPMORNATU > 0)
                {

                    /*" -7284- COMPUTE WHOST-IMPSEG = V0COBP-IMPMORNATU * CONDITEC-CARREGA-CONJUGE / 100 */
                    WHOST_IMPSEG.Value = V0COBP_IMPMORNATU * CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE / 100f;

                    /*" -7287- DIVIDE WHOST-IMPSEG BY V0COBP-IMPMORNATU GIVING WHOST-PERCENT */
                    _.Divide(WHOST_IMPSEG, V0COBP_IMPMORNATU, WHOST_PERCENT);

                    /*" -7288- ELSE */
                }
                else
                {


                    /*" -7289- IF V0COBP-IMPMORACID > 0 */

                    if (V0COBP_IMPMORACID > 0)
                    {

                        /*" -7292- COMPUTE WHOST-IMPSEG = V0COBP-IMPMORACID * CONDITEC-CARREGA-CONJUGE / 100 */
                        WHOST_IMPSEG.Value = V0COBP_IMPMORACID * CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE / 100f;

                        /*" -7295- DIVIDE WHOST-IMPSEG BY V0COBP-IMPMORACID GIVING WHOST-PERCENT */
                        _.Divide(WHOST_IMPSEG, V0COBP_IMPMORACID, WHOST_PERCENT);

                        /*" -7296- ELSE */
                    }
                    else
                    {


                        /*" -7297- MOVE ZEROS TO WHOST-PERCENT */
                        _.Move(0, WHOST_PERCENT);

                        /*" -7298- END-IF */
                    }


                    /*" -7299- END-IF */
                }


                /*" -7301- COMPUTE VG081-VLR-PERC-PREMIO = VG081-VLR-PERC-PREMIO * WHOST-PERCENT */
                VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO.Value = VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO * WHOST_PERCENT;

                /*" -7303- END-IF. */
            }


            /*" -7305- IF VG081-RAMO-EMISSOR = 82 AND VG081-COD-MODALIDADE = 1006 */

            if (VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR == 82 && VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_MODALIDADE == 1006)
            {

                /*" -7306- IF V0COBP-IMPMORNATU > 0 */

                if (V0COBP_IMPMORNATU > 0)
                {

                    /*" -7309- COMPUTE WHOST-IMPSEG = V0COBP-IMPMORNATU * CONDITEC-CARREGA-CONJUGE / 100 */
                    WHOST_IMPSEG.Value = V0COBP_IMPMORNATU * CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE / 100f;

                    /*" -7312- DIVIDE WHOST-IMPSEG BY V0COBP-IMPMORNATU GIVING WHOST-PERCENT */
                    _.Divide(WHOST_IMPSEG, V0COBP_IMPMORNATU, WHOST_PERCENT);

                    /*" -7313- ELSE */
                }
                else
                {


                    /*" -7314- IF V0COBP-IMPMORACID > 0 */

                    if (V0COBP_IMPMORACID > 0)
                    {

                        /*" -7317- COMPUTE WHOST-IMPSEG = V0COBP-IMPMORACID * CONDITEC-CARREGA-CONJUGE / 100 */
                        WHOST_IMPSEG.Value = V0COBP_IMPMORACID * CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE / 100f;

                        /*" -7320- DIVIDE WHOST-IMPSEG BY V0COBP-IMPMORACID GIVING WHOST-PERCENT */
                        _.Divide(WHOST_IMPSEG, V0COBP_IMPMORACID, WHOST_PERCENT);

                        /*" -7321- ELSE */
                    }
                    else
                    {


                        /*" -7322- MOVE ZEROS TO WHOST-PERCENT */
                        _.Move(0, WHOST_PERCENT);

                        /*" -7323- END-IF */
                    }


                    /*" -7324- END-IF */
                }


                /*" -7326- COMPUTE VG081-VLR-PERC-PREMIO = VG081-VLR-PERC-PREMIO * WHOST-PERCENT */
                VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO.Value = VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO * WHOST_PERCENT;

                /*" -7328- END-IF. */
            }


            /*" -7330- IF VG081-RAMO-EMISSOR = 82 AND VG081-COD-MODALIDADE = 1007 */

            if (VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR == 82 && VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_MODALIDADE == 1007)
            {

                /*" -7331- IF V0COBP-IMPMORNATU > 0 */

                if (V0COBP_IMPMORNATU > 0)
                {

                    /*" -7334- COMPUTE WHOST-IMPSEG = V0COBP-IMPMORNATU * CONDITEC-CARREGA-CONJUGE / 100 */
                    WHOST_IMPSEG.Value = V0COBP_IMPMORNATU * CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE / 100f;

                    /*" -7337- DIVIDE WHOST-IMPSEG BY V0COBP-IMPMORNATU GIVING WHOST-PERCENT */
                    _.Divide(WHOST_IMPSEG, V0COBP_IMPMORNATU, WHOST_PERCENT);

                    /*" -7338- ELSE */
                }
                else
                {


                    /*" -7339- IF V0COBP-IMPMORACID > 0 */

                    if (V0COBP_IMPMORACID > 0)
                    {

                        /*" -7342- COMPUTE WHOST-IMPSEG = V0COBP-IMPMORACID * CONDITEC-CARREGA-CONJUGE / 100 */
                        WHOST_IMPSEG.Value = V0COBP_IMPMORACID * CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE / 100f;

                        /*" -7345- DIVIDE WHOST-IMPSEG BY V0COBP-IMPMORACID GIVING WHOST-PERCENT */
                        _.Divide(WHOST_IMPSEG, V0COBP_IMPMORACID, WHOST_PERCENT);

                        /*" -7346- ELSE */
                    }
                    else
                    {


                        /*" -7347- MOVE ZEROS TO WHOST-PERCENT */
                        _.Move(0, WHOST_PERCENT);

                        /*" -7348- END-IF */
                    }


                    /*" -7349- END-IF */
                }


                /*" -7351- COMPUTE VG081-VLR-PERC-PREMIO = VG081-VLR-PERC-PREMIO * WHOST-PERCENT */
                VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO.Value = VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO * WHOST_PERCENT;

                /*" -7353- END-IF. */
            }


            /*" -7355- IF VG081-RAMO-EMISSOR = 82 AND VG081-COD-MODALIDADE = 1008 */

            if (VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR == 82 && VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_MODALIDADE == 1008)
            {

                /*" -7356- IF V0COBP-IMPMORNATU > 0 */

                if (V0COBP_IMPMORNATU > 0)
                {

                    /*" -7359- DIVIDE V0COBP-IMPDH BY V0COBP-IMPMORNATU GIVING WHOST-PERCENT */
                    _.Divide(V0COBP_IMPDH, V0COBP_IMPMORNATU, WHOST_PERCENT);

                    /*" -7360- ELSE */
                }
                else
                {


                    /*" -7361- IF V0COBP-IMPMORACID > 0 */

                    if (V0COBP_IMPMORACID > 0)
                    {

                        /*" -7364- DIVIDE V0COBP-IMPDH BY V0COBP-IMPMORACID GIVING WHOST-PERCENT */
                        _.Divide(V0COBP_IMPDH, V0COBP_IMPMORACID, WHOST_PERCENT);

                        /*" -7365- ELSE */
                    }
                    else
                    {


                        /*" -7366- MOVE ZEROS TO WHOST-PERCENT */
                        _.Move(0, WHOST_PERCENT);

                        /*" -7367- END-IF */
                    }


                    /*" -7368- END-IF */
                }


                /*" -7370- COMPUTE VG081-VLR-PERC-PREMIO = VG081-VLR-PERC-PREMIO * WHOST-PERCENT */
                VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO.Value = VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO * WHOST_PERCENT;

                /*" -7372- END-IF. */
            }


            /*" -7374- IF VG081-RAMO-EMISSOR = 90 AND VG081-COD-MODALIDADE = 1002 */

            if (VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR == 90 && VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_MODALIDADE == 1002)
            {

                /*" -7375- IF V0COBP-IMPMORNATU > 0 */

                if (V0COBP_IMPMORNATU > 0)
                {

                    /*" -7378- COMPUTE WHOST-IMPSEG = V0COBP-IMPMORNATU * CONDITEC-TAXA-AP-DH / 100 */
                    WHOST_IMPSEG.Value = V0COBP_IMPMORNATU * CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_DH / 100f;

                    /*" -7381- DIVIDE WHOST-IMPSEG BY V0COBP-IMPMORNATU GIVING WHOST-PERCENT */
                    _.Divide(WHOST_IMPSEG, V0COBP_IMPMORNATU, WHOST_PERCENT);

                    /*" -7382- ELSE */
                }
                else
                {


                    /*" -7383- IF V0COBP-IMPMORACID > 0 */

                    if (V0COBP_IMPMORACID > 0)
                    {

                        /*" -7386- COMPUTE WHOST-IMPSEG = V0COBP-IMPMORACID * CONDITEC-TAXA-AP-DH / 100 */
                        WHOST_IMPSEG.Value = V0COBP_IMPMORACID * CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_DH / 100f;

                        /*" -7389- DIVIDE WHOST-IMPSEG BY V0COBP-IMPMORACID GIVING WHOST-PERCENT */
                        _.Divide(WHOST_IMPSEG, V0COBP_IMPMORACID, WHOST_PERCENT);

                        /*" -7390- ELSE */
                    }
                    else
                    {


                        /*" -7391- MOVE ZEROS TO WHOST-PERCENT */
                        _.Move(0, WHOST_PERCENT);

                        /*" -7392- END-IF */
                    }


                    /*" -7393- END-IF */
                }


                /*" -7395- COMPUTE VG081-VLR-PERC-PREMIO = VG081-VLR-PERC-PREMIO * WHOST-PERCENT */
                VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO.Value = VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO * WHOST_PERCENT;

                /*" -7399- END-IF. */
            }


            /*" -7403- ADD VG081-VLR-PERC-PREMIO TO WHOST-VLR-PERC-PREMIO WHOST-VLR-PERC-PREMIO-TOT */
            WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO.Value = WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO + VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO;
            WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO_TOT.Value = WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO_TOT + VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO;

            /*" -7404- PERFORM R6910-00-FETCH-VGRAMOCOMP. */

            R6910_00_FETCH_VGRAMOCOMP_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7150_99_SAIDA*/

        [StopWatch]
        /*" R7160-00-LEITURA-VGCOBSUB-SECTION */
        private void R7160_00_LEITURA_VGCOBSUB_SECTION()
        {
            /*" -7414- MOVE 'R2310-LEITURA-VGCOBSUB ' TO PARAGRAFO. */
            _.Move("R2310-LEITURA-VGCOBSUB ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7426- MOVE 'R2310 ' TO COMANDO. */
            _.Move("R2310 ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -7427- MOVE 87 TO W01-I */
            _.Move(87, FILLER_11.W01_I);

            /*" -7429- MOVE 'SELECT VG_COBERTURAS_SUBG' TO W01-TEXTO(W01-I) */
            _.Move("SELECT VG_COBERTURAS_SUBG", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -7433- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -7472- PERFORM R7160_00_LEITURA_VGCOBSUB_DB_SELECT_1 */

            R7160_00_LEITURA_VGCOBSUB_DB_SELECT_1();

            /*" -7476- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -7481- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -7482- IF SQLCODE NOT EQUAL ZEROES AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -7483- DISPLAY '*** VA0813B *** ERRO SELECT VGCOBSUB ' */
                _.Display($"*** VA0813B *** ERRO SELECT VGCOBSUB ");

                /*" -7486- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -7487- DISPLAY 'NUM-APOLICE     = ' V0PROP-NUM-APOLICE */
            _.Display($"NUM-APOLICE     = {V0PROP_NUM_APOLICE}");

            /*" -7488- DISPLAY 'CODSUBES        = ' V0PROP-CODSUBES */
            _.Display($"CODSUBES        = {V0PROP_CODSUBES}");

            /*" -7489- DISPLAY 'COD-COBERTURA   = ' VGCOBSUB-COD-COBERTURA */
            _.Display($"COD-COBERTURA   = {VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA}");

            /*" -7490- DISPLAY 'DTQITBCO        = ' V0PROP-DTQITBCO */
            _.Display($"DTQITBCO        = {V0PROP_DTQITBCO}");

            /*" -7492- DISPLAY 'IMP-SEGURADA-IX = ' VGCOBSUB-IMP-SEGURADA-IX. */
            _.Display($"IMP-SEGURADA-IX = {VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX}");

        }

        [StopWatch]
        /*" R7160-00-LEITURA-VGCOBSUB-DB-SELECT-1 */
        public void R7160_00_LEITURA_VGCOBSUB_DB_SELECT_1()
        {
            /*" -7472- EXEC SQL SELECT T1.IMP_SEGURADA_IX INTO :VGCOBSUB-IMP-SEGURADA-IX FROM SEGUROS.VG_COBERTURAS_SUBG T1 LEFT JOIN SEGUROS.VG_COBER_SUBG_HIST T2 ON (T2.NUM_APOLICE = T1.NUM_APOLICE AND T2.COD_SUBGRUPO = T1.COD_SUBGRUPO AND T2.COD_COBERTURA = T1.COD_COBERTURA) WHERE T1.NUM_APOLICE = :V0PROP-NUM-APOLICE AND T1.COD_SUBGRUPO = :V0PROP-CODSUBES AND T1.COD_COBERTURA = :VGCOBSUB-COD-COBERTURA AND ((T1.SIT_COBERTURA = '0' ) OR (T1.SIT_COBERTURA = '1' AND T1.NUM_APOLICE = T2.NUM_APOLICE AND T1.COD_SUBGRUPO = T2.COD_SUBGRUPO AND T1.COD_COBERTURA = T2.COD_COBERTURA AND T2.DATA_TERVIGENCIA > :V0PROP-DTQITBCO AND T2.DATA_TERVIGENCIA = (SELECT MAX(T3.DATA_TERVIGENCIA) FROM SEGUROS.VG_COBER_SUBG_HIST T3 WHERE T3.NUM_APOLICE = T1.NUM_APOLICE AND T3.COD_COBERTURA = T1.COD_COBERTURA AND T3.COD_SUBGRUPO = T1.COD_SUBGRUPO AND T3.DATA_TERVIGENCIA <> '9999-12-31' ) AND NOT EXISTS (SELECT T4.COD_COBERTURA FROM SEGUROS.VG_COBER_SUBG_HIST T4 WHERE T4.NUM_APOLICE = T1.NUM_APOLICE AND T4.COD_SUBGRUPO = T1.COD_SUBGRUPO AND T4.COD_COBERTURA = 22 AND T1.COD_COBERTURA = 01 AND ((T4.DATA_TERVIGENCIA = '9999-12-31' ) OR (T4.DATA_TERVIGENCIA >= T2.DATA_TERVIGENCIA))))) WITH UR END-EXEC. */

            var r7160_00_LEITURA_VGCOBSUB_DB_SELECT_1_Query1 = new R7160_00_LEITURA_VGCOBSUB_DB_SELECT_1_Query1()
            {
                VGCOBSUB_COD_COBERTURA = VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA.ToString(),
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
                V0PROP_CODSUBES = V0PROP_CODSUBES.ToString(),
                V0PROP_DTQITBCO = V0PROP_DTQITBCO.ToString(),
            };

            var executed_1 = R7160_00_LEITURA_VGCOBSUB_DB_SELECT_1_Query1.Execute(r7160_00_LEITURA_VGCOBSUB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VGCOBSUB_IMP_SEGURADA_IX, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7160_99_SAIDA*/

        [StopWatch]
        /*" R7170-00-SELECT-CONDITEC-SECTION */
        private void R7170_00_SELECT_CONDITEC_SECTION()
        {
            /*" -7501- MOVE 'R7170-SELECT-CONDITEC  ' TO PARAGRAFO. */
            _.Move("R7170-SELECT-CONDITEC  ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7506- MOVE 'R7170 ' TO COMANDO. */
            _.Move("R7170 ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -7507- MOVE 88 TO W01-I */
            _.Move(88, FILLER_11.W01_I);

            /*" -7509- MOVE 'SELECT CONDICOES_TECNICAS' TO W01-TEXTO(W01-I) */
            _.Move("SELECT CONDICOES_TECNICAS", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -7513- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -7542- PERFORM R7170_00_SELECT_CONDITEC_DB_SELECT_1 */

            R7170_00_SELECT_CONDITEC_DB_SELECT_1();

            /*" -7546- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -7551- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -7552- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7553- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -7555- IF CONDITEC-COD-SUBGRUPO EQUAL 0 AND V0PRVG-ORIG-PRODU(1:4) EQUAL 'ESPE' */

                    if (CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_COD_SUBGRUPO == 0 && V0PRVG_ORIG_PRODU.Substring(1, 4) == "ESPE")
                    {

                        /*" -7556- MOVE 1 TO CONDITEC-COD-SUBGRUPO */
                        _.Move(1, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_COD_SUBGRUPO);

                        /*" -7557- GO TO R7170-00-SELECT-CONDITEC */
                        new Task(() => R7170_00_SELECT_CONDITEC_SECTION()).RunSynchronously(); //GOTO
                        return;//Recursividade detectada, cuidado...

                        /*" -7558- ELSE */
                    }
                    else
                    {


                        /*" -7570- MOVE ZEROS TO CONDITEC-TAXA-AP-MORACID CONDITEC-TAXA-AP-INVPERM CONDITEC-TAXA-AP-AMDS CONDITEC-TAXA-AP-DH CONDITEC-TAXA-AP-DIT CONDITEC-TAXA-AP CONDITEC-CARREGA-PRINCIPAL CONDITEC-CARREGA-CONJUGE CONDITEC-CARREGA-FILHOS CONDITEC-GARAN-ADIC-IEA CONDITEC-GARAN-ADIC-IPA CONDITEC-GARAN-ADIC-IPD */
                        _.Move(0, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_MORACID, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_INVPERM, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_AMDS, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_DH, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_DIT, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_PRINCIPAL, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_FILHOS, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_GARAN_ADIC_IEA, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_GARAN_ADIC_IPA, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_GARAN_ADIC_IPD);

                        /*" -7571- END-IF */
                    }


                    /*" -7572- ELSE */
                }
                else
                {


                    /*" -7573- DISPLAY '*** VA7010B *** ERRO SELECT CONDITEC ' */
                    _.Display($"*** VA7010B *** ERRO SELECT CONDITEC ");

                    /*" -7574- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -7575- END-IF */
                }


                /*" -7576- END-IF. */
            }


        }

        [StopWatch]
        /*" R7170-00-SELECT-CONDITEC-DB-SELECT-1 */
        public void R7170_00_SELECT_CONDITEC_DB_SELECT_1()
        {
            /*" -7542- EXEC SQL SELECT TAXA_AP_MORACID, TAXA_AP_INVPERM, TAXA_AP_AMDS, TAXA_AP_DH, TAXA_AP_DIT, TAXA_AP, CARREGA_PRINCIPAL, CARREGA_CONJUGE, CARREGA_FILHOS, GARAN_ADIC_IEA, GARAN_ADIC_IPA, GARAN_ADIC_IPD INTO :CONDITEC-TAXA-AP-MORACID , :CONDITEC-TAXA-AP-INVPERM , :CONDITEC-TAXA-AP-AMDS , :CONDITEC-TAXA-AP-DH , :CONDITEC-TAXA-AP-DIT , :CONDITEC-TAXA-AP , :CONDITEC-CARREGA-PRINCIPAL, :CONDITEC-CARREGA-CONJUGE , :CONDITEC-CARREGA-FILHOS , :CONDITEC-GARAN-ADIC-IEA , :CONDITEC-GARAN-ADIC-IPA , :CONDITEC-GARAN-ADIC-IPD FROM SEGUROS.CONDICOES_TECNICAS WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE AND COD_SUBGRUPO = :CONDITEC-COD-SUBGRUPO WITH UR END-EXEC. */

            var r7170_00_SELECT_CONDITEC_DB_SELECT_1_Query1 = new R7170_00_SELECT_CONDITEC_DB_SELECT_1_Query1()
            {
                CONDITEC_COD_SUBGRUPO = CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_COD_SUBGRUPO.ToString(),
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
            };

            var executed_1 = R7170_00_SELECT_CONDITEC_DB_SELECT_1_Query1.Execute(r7170_00_SELECT_CONDITEC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONDITEC_TAXA_AP_MORACID, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_MORACID);
                _.Move(executed_1.CONDITEC_TAXA_AP_INVPERM, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_INVPERM);
                _.Move(executed_1.CONDITEC_TAXA_AP_AMDS, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_AMDS);
                _.Move(executed_1.CONDITEC_TAXA_AP_DH, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_DH);
                _.Move(executed_1.CONDITEC_TAXA_AP_DIT, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_DIT);
                _.Move(executed_1.CONDITEC_TAXA_AP, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP);
                _.Move(executed_1.CONDITEC_CARREGA_PRINCIPAL, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_PRINCIPAL);
                _.Move(executed_1.CONDITEC_CARREGA_CONJUGE, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE);
                _.Move(executed_1.CONDITEC_CARREGA_FILHOS, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_FILHOS);
                _.Move(executed_1.CONDITEC_GARAN_ADIC_IEA, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_GARAN_ADIC_IEA);
                _.Move(executed_1.CONDITEC_GARAN_ADIC_IPA, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_GARAN_ADIC_IPA);
                _.Move(executed_1.CONDITEC_GARAN_ADIC_IPD, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_GARAN_ADIC_IPD);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7170_99_SAIDA*/

        [StopWatch]
        /*" R7180-00-PROCESSA-GLOBAL-SECTION */
        private void R7180_00_PROCESSA_GLOBAL_SECTION()
        {
            /*" -7589- MOVE '7180-00-PROCESSA-GLOBAL      ' TO PARAGRAFO. */
            _.Move("7180-00-PROCESSA-GLOBAL      ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7591- IF VG081-RAMO-EMISSOR = 82 AND VG081-COD-MODALIDADE = 1002 */

            if (VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR == 82 && VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_MODALIDADE == 1002)
            {

                /*" -7592- IF V0COBP-IMPMORNATU > 0 */

                if (V0COBP_IMPMORNATU > 0)
                {

                    /*" -7595- COMPUTE WHOST-IMPSEG = V0COBP-IMPMORNATU * CONDITEC-TAXA-AP-DH / 100 */
                    WHOST_IMPSEG.Value = V0COBP_IMPMORNATU * CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_DH / 100f;

                    /*" -7598- DIVIDE WHOST-IMPSEG BY V0COBP-IMPMORNATU GIVING WHOST-PERCENT */
                    _.Divide(WHOST_IMPSEG, V0COBP_IMPMORNATU, WHOST_PERCENT);

                    /*" -7599- ELSE */
                }
                else
                {


                    /*" -7600- IF V0COBP-IMPMORACID > 0 */

                    if (V0COBP_IMPMORACID > 0)
                    {

                        /*" -7603- COMPUTE WHOST-IMPSEG = V0COBP-IMPMORACID * CONDITEC-TAXA-AP-DH / 100 */
                        WHOST_IMPSEG.Value = V0COBP_IMPMORACID * CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_TAXA_AP_DH / 100f;

                        /*" -7606- DIVIDE WHOST-IMPSEG BY V0COBP-IMPMORACID GIVING WHOST-PERCENT */
                        _.Divide(WHOST_IMPSEG, V0COBP_IMPMORACID, WHOST_PERCENT);

                        /*" -7607- ELSE */
                    }
                    else
                    {


                        /*" -7608- MOVE ZEROS TO WHOST-PERCENT */
                        _.Move(0, WHOST_PERCENT);

                        /*" -7609- END-IF */
                    }


                    /*" -7611- END-IF */
                }


                /*" -7613- COMPUTE VG081-VLR-PERC-PREMIO = VG081-VLR-PERC-PREMIO * WHOST-PERCENT */
                VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO.Value = VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO * WHOST_PERCENT;

                /*" -7615- END-IF. */
            }


            /*" -7617- IF VG081-RAMO-EMISSOR = 84 AND VG081-COD-MODALIDADE = 1001 */

            if (VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR == 84 && VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_MODALIDADE == 1001)
            {

                /*" -7618- IF V0COBP-IMPMORNATU > 0 */

                if (V0COBP_IMPMORNATU > 0)
                {

                    /*" -7620- COMPUTE WHOST-IMPSEG = V0COBP-IMPMORNATU * 0,30 */
                    WHOST_IMPSEG.Value = V0COBP_IMPMORNATU * 0.30;

                    /*" -7623- DIVIDE WHOST-IMPSEG BY V0COBP-IMPMORNATU GIVING WHOST-PERCENT */
                    _.Divide(WHOST_IMPSEG, V0COBP_IMPMORNATU, WHOST_PERCENT);

                    /*" -7624- ELSE */
                }
                else
                {


                    /*" -7625- IF V0COBP-IMPMORACID > 0 */

                    if (V0COBP_IMPMORACID > 0)
                    {

                        /*" -7627- COMPUTE WHOST-IMPSEG = V0COBP-IMPMORACID * 0,30 */
                        WHOST_IMPSEG.Value = V0COBP_IMPMORACID * 0.30;

                        /*" -7630- DIVIDE WHOST-IMPSEG BY V0COBP-IMPMORACID GIVING WHOST-PERCENT */
                        _.Divide(WHOST_IMPSEG, V0COBP_IMPMORACID, WHOST_PERCENT);

                        /*" -7631- ELSE */
                    }
                    else
                    {


                        /*" -7632- MOVE ZEROS TO WHOST-PERCENT */
                        _.Move(0, WHOST_PERCENT);

                        /*" -7633- END-IF */
                    }


                    /*" -7634- END-IF */
                }


                /*" -7636- COMPUTE VG081-VLR-PERC-PREMIO = VG081-VLR-PERC-PREMIO * WHOST-PERCENT */
                VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO.Value = VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO * WHOST_PERCENT;

                /*" -7638- END-IF. */
            }


            /*" -7640- IF VG081-RAMO-EMISSOR = 90 AND VG081-COD-MODALIDADE = 1001 */

            if (VG081.DCLVG_PARAM_RAMO_COMP.VG081_RAMO_EMISSOR == 90 && VG081.DCLVG_PARAM_RAMO_COMP.VG081_COD_MODALIDADE == 1001)
            {

                /*" -7641- IF V0COBP-IMPMORNATU > 0 */

                if (V0COBP_IMPMORNATU > 0)
                {

                    /*" -7643- COMPUTE WHOST-IMPSEG = 1000 * V0COBP-QUANT-VIDAS */
                    WHOST_IMPSEG.Value = 1000 * V0COBP_QUANT_VIDAS;

                    /*" -7646- DIVIDE WHOST-IMPSEG BY V0COBP-IMPMORNATU GIVING WHOST-PERCENT */
                    _.Divide(WHOST_IMPSEG, V0COBP_IMPMORNATU, WHOST_PERCENT);

                    /*" -7647- ELSE */
                }
                else
                {


                    /*" -7648- IF V0COBP-IMPMORACID > 0 */

                    if (V0COBP_IMPMORACID > 0)
                    {

                        /*" -7650- COMPUTE WHOST-IMPSEG = 1000 * V0COBP-QUANT-VIDAS */
                        WHOST_IMPSEG.Value = 1000 * V0COBP_QUANT_VIDAS;

                        /*" -7653- DIVIDE WHOST-IMPSEG BY V0COBP-IMPMORACID GIVING WHOST-PERCENT */
                        _.Divide(WHOST_IMPSEG, V0COBP_IMPMORACID, WHOST_PERCENT);

                        /*" -7654- ELSE */
                    }
                    else
                    {


                        /*" -7655- MOVE ZEROS TO WHOST-PERCENT */
                        _.Move(0, WHOST_PERCENT);

                        /*" -7656- END-IF */
                    }


                    /*" -7657- END-IF */
                }


                /*" -7659- COMPUTE VG081-VLR-PERC-PREMIO = VG081-VLR-PERC-PREMIO * WHOST-PERCENT */
                VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO.Value = VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO * WHOST_PERCENT;

                /*" -7661- END-IF. */
            }


            /*" -7665- ADD VG081-VLR-PERC-PREMIO TO WHOST-VLR-PERC-PREMIO WHOST-VLR-PERC-PREMIO-TOT */
            WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO.Value = WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO + VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO;
            WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO_TOT.Value = WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO_TOT + VG081.DCLVG_PARAM_RAMO_COMP.VG081_VLR_PERC_PREMIO;

            /*" -7666- PERFORM R6910-00-FETCH-VGRAMOCOMP. */

            R6910_00_FETCH_VGRAMOCOMP_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7180_99_SAIDA*/

        [StopWatch]
        /*" R7200-00-INSERT-VGHISTCONT-SECTION */
        private void R7200_00_INSERT_VGHISTCONT_SECTION()
        {
            /*" -7676- MOVE '7200-00-INSERT-VGHISTCONT  ' TO PARAGRAFO. */
            _.Move("7200-00-INSERT-VGHISTCONT  ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7678- MOVE 'INSERT VGHISTCONT    ' TO COMANDO. */
            _.Move("INSERT VGHISTCONT    ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -7680- ADD 1 TO WS-IND1. */
            WORK_RAMO_CONJ.WS_IND1.Value = WORK_RAMO_CONJ.WS_IND1 + 1;

            /*" -7682- IF (WS-IND1 > 30) OR (TB-GRUPO-SUSEP (WS-IND1) EQUAL ZEROS) */

            if ((WORK_RAMO_CONJ.WS_IND1 > 30) || (WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND1].TB_GRUPO_SUSEP == 00))
            {

                /*" -7683- MOVE 'SIM' TO WFIM-TAB-RAMO */
                _.Move("SIM", WORK_AREA.WFIM_TAB_RAMO);

                /*" -7684- GO TO R7200-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R7200_99_SAIDA*/ //GOTO
                return;

                /*" -7686- END-IF. */
            }


            /*" -7688- INITIALIZE DCLVG-HIST-CONT-COBER */
            _.Initialize(
                VG082.DCLVG_HIST_CONT_COBER
            );

            /*" -7689- MOVE TB-GRUPO-SUSEP (WS-IND1) TO WHOST-GRUPO-SUSEP */
            _.Move(WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND1].TB_GRUPO_SUSEP, WHOST_GRUPO_SUSEP);

            /*" -7690- MOVE TB-RAMO-CONJ (WS-IND1) TO WHOST-COD-RAMO */
            _.Move(WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND1].TB_RAMO_CONJ, WHOST_COD_RAMO);

            /*" -7692- MOVE TB-TAXA-RAMO-CONJ (WS-IND1) TO WHOST-TAXA-RAMO */
            _.Move(WORK_TAB_RAMO_CONJ.N5WORK_TAB_RAMO_CONJ[WORK_RAMO_CONJ.WS_IND1].TB_TAXA_RAMO_CONJ, WHOST_TAXA_RAMO);

            /*" -7696- COMPUTE WHOST-PREMIO-CONJ ROUNDED = WS-PREMIO-TOTAL-DIT * WHOST-TAXA-RAMO / WHOST-VLR-PERC-PREMIO-TOT */
            WHOST_PREMIO_CONJ.Value = WS_PREMIO_TOTAL_DIT * WHOST_TAXA_RAMO / WORK_RAMO_CONJ.WHOST_VLR_PERC_PREMIO_TOT;

            /*" -7697- IF (WS-IND1 EQUAL WS-IND) */

            if ((WORK_RAMO_CONJ.WS_IND1 == WORK_RAMO_CONJ.WS_IND))
            {

                /*" -7699- COMPUTE WHOST-PREMIO-CONJ = WS-PREMIO-TOTAL-DIT - WS-PREMIO-TOTAL-AC */
                WHOST_PREMIO_CONJ.Value = WS_PREMIO_TOTAL_DIT - WS_PREMIO_TOTAL_AC;

                /*" -7700- ELSE */
            }
            else
            {


                /*" -7701- ADD WHOST-PREMIO-CONJ TO WS-PREMIO-TOTAL-AC */
                WS_PREMIO_TOTAL_AC.Value = WS_PREMIO_TOTAL_AC + WHOST_PREMIO_CONJ;

                /*" -7703- END-IF */
            }


            /*" -7704- IF (WHOST-COD-RAMO EQUAL 90) */

            if ((WHOST_COD_RAMO == 90))
            {

                /*" -7706- COMPUTE WHOST-PREMIO-CONJ = WHOST-PREMIO-CONJ + WHOST-VLR-FIXO-DIT */
                WHOST_PREMIO_CONJ.Value = WHOST_PREMIO_CONJ + WHOST_VLR_FIXO_DIT;

                /*" -7708- END-IF */
            }


            /*" -7710- IF (WHOST-PREMIO-CONJ > ZEROS) */

            if ((WHOST_PREMIO_CONJ > 00))
            {

                /*" -7711- MOVE 89 TO W01-I */
                _.Move(89, FILLER_11.W01_I);

                /*" -7713- MOVE 'INSERT VG_HIST_CONT_COBER' TO W01-TEXTO(W01-I) */
                _.Move("INSERT VG_HIST_CONT_COBER", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

                /*" -7717- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

                R8900_TOTALIZA_INICIO_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


                /*" -7741- PERFORM R7200_00_INSERT_VGHISTCONT_DB_INSERT_1 */

                R7200_00_INSERT_VGHISTCONT_DB_INSERT_1();

                /*" -7745- MOVE 1 TO W01-QTD-ACC-OK */
                _.Move(1, FILLER_11.W01_QTD_ACC_OK);

                /*" -7750- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

                R8910_TOTALIZA_FINAL_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


                /*" -7751- IF (SQLCODE NOT EQUAL ZEROS AND -803) */

                if ((!DB.SQLCODE.In("00", "-803")))
                {

                    /*" -7752- DISPLAY 'PROBLEMAS NO INSERT VGHISTCONT     ' */
                    _.Display($"PROBLEMAS NO INSERT VGHISTCONT     ");

                    /*" -7753- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -7754- END-IF */
                }


                /*" -7755- END-IF. */
            }


        }

        [StopWatch]
        /*" R7200-00-INSERT-VGHISTCONT-DB-INSERT-1 */
        public void R7200_00_INSERT_VGHISTCONT_DB_INSERT_1()
        {
            /*" -7741- EXEC SQL INSERT INTO SEGUROS.VG_HIST_CONT_COBER (NUM_CERTIFICADO , NUM_PARCELA , NUM_TITULO , OCORR_HISTORICO , COD_GRUPO_SUSEP , RAMO_EMISSOR , COD_MODALIDADE , COD_COBERTURA , VLR_PREMIO_RAMO , COD_USUARIO , DTH_ATUALIZACAO ) VALUES (:V0HCTA-NRCERTIF, :V0HCTA-NRPARCEL, :V0HCOB-NRTIT, :V0HCOB-OCORHIST, :WHOST-GRUPO-SUSEP , :WHOST-COD-RAMO , :VG082-COD-MODALIDADE, :VG082-COD-COBERTURA, :WHOST-PREMIO-CONJ, 'VA0813B' , CURRENT TIMESTAMP ) END-EXEC */

            var r7200_00_INSERT_VGHISTCONT_DB_INSERT_1_Insert1 = new R7200_00_INSERT_VGHISTCONT_DB_INSERT_1_Insert1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0HCTA_NRPARCEL = V0HCTA_NRPARCEL.ToString(),
                V0HCOB_NRTIT = V0HCOB_NRTIT.ToString(),
                V0HCOB_OCORHIST = V0HCOB_OCORHIST.ToString(),
                WHOST_GRUPO_SUSEP = WHOST_GRUPO_SUSEP.ToString(),
                WHOST_COD_RAMO = WHOST_COD_RAMO.ToString(),
                VG082_COD_MODALIDADE = VG082.DCLVG_HIST_CONT_COBER.VG082_COD_MODALIDADE.ToString(),
                VG082_COD_COBERTURA = VG082.DCLVG_HIST_CONT_COBER.VG082_COD_COBERTURA.ToString(),
                WHOST_PREMIO_CONJ = WHOST_PREMIO_CONJ.ToString(),
            };

            R7200_00_INSERT_VGHISTCONT_DB_INSERT_1_Insert1.Execute(r7200_00_INSERT_VGHISTCONT_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7200_99_SAIDA*/

        [StopWatch]
        /*" R8000-00-TRATA-DESPESAS-SECTION */
        private void R8000_00_TRATA_DESPESAS_SECTION()
        {
            /*" -7765- MOVE 'R8000-TRATA-DESPESAS    ' TO PARAGRAFO. */
            _.Move("R8000-TRATA-DESPESAS    ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7768- PERFORM R8010-00-VER-PRODUTO. */

            R8010_00_VER_PRODUTO_SECTION();

            /*" -7769- MOVE RF-VLPRMTOT TO WSHOST-VLPRMTOT */
            _.Move(RET_CADASTRAMENTO.RF_VLPRMTOT, WSHOST_VLPRMTOT);

            /*" -7770- MOVE V0PROP-CODPRODU TO WSHOST-CODPRODU */
            _.Move(V0PROP_CODPRODU, WSHOST_CODPRODU);

            /*" -7774- MOVE ZEROS TO WSHOST-VLTARIFA WSHOST-VLBALCAO WSHOST-VLIOCC WSHOST-VLDESCON */
            _.Move(0, WSHOST_VLTARIFA, WSHOST_VLBALCAO, WSHOST_VLIOCC, WSHOST_VLDESCON);

            /*" -7777- MOVE '0' TO WSHOST-SITUACAO. */
            _.Move("0", WSHOST_SITUACAO);

            /*" -7780- MOVE 0,80 TO WSHOST-VLTARIFA. */
            _.Move(0.80, WSHOST_VLTARIFA);

            /*" -7781- SET WS-PRD TO 1 */
            WS_PRD.Value = 1;

            /*" -7782- SEARCH WTABG-OCORREPRD */
            for (; WS_PRD < AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD.Items.Count; WS_PRD.Value++)
            {

                /*" -7784- WHEN WSHOST-CODPRODU EQUAL WTABG-CODPRODU(WS-PRD) */

                if (WSHOST_CODPRODU == AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_CODPRODU)
                {


                    /*" -7784- PERFORM R8050-00-VERIFICA-TIPO  END-SEARCH. */

                    R8050_00_VERIFICA_TIPO_SECTION();
                    break;
                }
            }


            /*" -7790- ADD WSHOST-VLPRMTOT TO AUX-VLPRMTOT. */
            WORK_AREA.AUX_VLPRMTOT.Value = WORK_AREA.AUX_VLPRMTOT + WSHOST_VLPRMTOT;

            /*" -7791- ADD WSHOST-VLTARIFA TO AUX-VLDESPES. */
            WORK_AREA.AUX_VLDESPES.Value = WORK_AREA.AUX_VLDESPES + WSHOST_VLTARIFA;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/

        [StopWatch]
        /*" R8010-00-VER-PRODUTO-SECTION */
        private void R8010_00_VER_PRODUTO_SECTION()
        {
            /*" -7803- MOVE 'R8010-VER-PRODUTO       ' TO PARAGRAFO. */
            _.Move("R8010-VER-PRODUTO       ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7807- MOVE RF-IDENTIF-CLI TO V0HCTA-NRCERTIF. */
            _.Move(RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_IDENTIF_CLI, V0HCTA_NRCERTIF);

            /*" -7808- MOVE 90 TO W01-I */
            _.Move(90, FILLER_11.W01_I);

            /*" -7810- MOVE 'SELECT V0PROPOSTAVA' TO W01-TEXTO(W01-I) */
            _.Move("SELECT V0PROPOSTAVA", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -7814- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -7823- PERFORM R8010_00_VER_PRODUTO_DB_SELECT_1 */

            R8010_00_VER_PRODUTO_DB_SELECT_1();

            /*" -7827- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -7833- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -7834- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -7835- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -7836- MOVE ZEROS TO V0PROP-CODPRODU */
                    _.Move(0, V0PROP_CODPRODU);

                    /*" -7837- ELSE */
                }
                else
                {


                    /*" -7844- DISPLAY 'VA0813B - PROBLEMAS NO SELECT V0PROPOSTAVA XY' V0HCTA-NRCERTIF ' ' V0HCTA-NRPARCEL ' ' V0HCOB-NRTIT ' ' V0PROP-CODCLIEN ' ' WHOST-CODCONV ' ' V0HCTA-NSAS */

                    $"VA0813B - PROBLEMAS NO SELECT V0PROPOSTAVA XY{V0HCTA_NRCERTIF} {V0HCTA_NRPARCEL} {V0HCOB_NRTIT} {V0PROP_CODCLIEN} {WHOST_CODCONV} {V0HCTA_NSAS}"
                    .Display();

                    /*" -7844- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R8010-00-VER-PRODUTO-DB-SELECT-1 */
        public void R8010_00_VER_PRODUTO_DB_SELECT_1()
        {
            /*" -7823- EXEC SQL SELECT A.CODPRODU INTO :V0PROP-CODPRODU FROM SEGUROS.V0PROPOSTAVA A, SEGUROS.V0PRODUTOSVG B WHERE A.NRCERTIF = :V0HCTA-NRCERTIF AND B.NUM_APOLICE = A.NUM_APOLICE AND B.CODSUBES = A.CODSUBES WITH UR END-EXEC. */

            var r8010_00_VER_PRODUTO_DB_SELECT_1_Query1 = new R8010_00_VER_PRODUTO_DB_SELECT_1_Query1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
            };

            var executed_1 = R8010_00_VER_PRODUTO_DB_SELECT_1_Query1.Execute(r8010_00_VER_PRODUTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PROP_CODPRODU, V0PROP_CODPRODU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8010_99_SAIDA*/

        [StopWatch]
        /*" R8050-00-VERIFICA-TIPO-SECTION */
        private void R8050_00_VERIFICA_TIPO_SECTION()
        {
            /*" -7856- MOVE 'R8050-VERIFICA-TIPO     ' TO PARAGRAFO. */
            _.Move("R8050-VERIFICA-TIPO     ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7861- SET WS-TIP TO 3. */
            WS_TIP.Value = 3;

            /*" -7862- IF WSHOST-SITUACAO EQUAL '0' */

            if (WSHOST_SITUACAO == "0")
            {

                /*" -7863- SET WS-SIT TO 1 */
                WS_SIT.Value = 1;

                /*" -7867- ELSE */
            }
            else
            {


                /*" -7870- SET WS-SIT TO 2. */
                WS_SIT.Value = 2;
            }


            /*" -7873- ADD 1 TO WTABG-QTDE(WS-PRD WS-TIP WS-SIT). */
            AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_QTDE.Value = AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_QTDE + 1;

            /*" -7876- ADD WSHOST-VLPRMTOT TO WTABG-VLPRMTOT(WS-PRD WS-TIP WS-SIT). */
            AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLPRMTOT.Value = AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLPRMTOT + WSHOST_VLPRMTOT;

            /*" -7879- ADD WSHOST-VLTARIFA TO WTABG-VLTARIFA(WS-PRD WS-TIP WS-SIT). */
            AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLTARIFA.Value = AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLTARIFA + WSHOST_VLTARIFA;

            /*" -7882- ADD WSHOST-VLBALCAO TO WTABG-VLBALCAO(WS-PRD WS-TIP WS-SIT). */
            AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLBALCAO.Value = AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLBALCAO + WSHOST_VLBALCAO;

            /*" -7885- ADD WSHOST-VLIOCC TO WTABG-VLIOCC(WS-PRD WS-TIP WS-SIT). */
            AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLIOCC.Value = AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLIOCC + WSHOST_VLIOCC;

            /*" -7886- ADD WSHOST-VLDESCON TO WTABG-VLDESCON(WS-PRD WS-TIP WS-SIT). */
            AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLDESCON.Value = AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLDESCON + WSHOST_VLDESCON;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8050_99_SAIDA*/

        [StopWatch]
        /*" R8500-00-GRAVA-DESPESAS-SECTION */
        private void R8500_00_GRAVA_DESPESAS_SECTION()
        {
            /*" -7899- MOVE 'R8500-GRAVA-DESPESAS    ' TO PARAGRAFO. */
            _.Move("R8500-GRAVA-DESPESAS    ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7900- IF WTABG-CODPRODU(WS-PRD) EQUAL 9999 */

            if (AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_CODPRODU == 9999)
            {

                /*" -7901- SET WS-PRD UP BY 1 */
                WS_PRD.Value += 1;

                /*" -7904- GO TO R8500-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8500_99_SAIDA*/ //GOTO
                return;
            }


            /*" -7907- MOVE WTABG-CODPRODU(WS-PRD) TO V0DPCF-CODPRODU. */
            _.Move(AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_CODPRODU, V0DPCF_CODPRODU);

            /*" -7908- MOVE ZEROS TO V0DPCF-CODEMP */
            _.Move(0, V0DPCF_CODEMP);

            /*" -7909- MOVE V0AVIS-BCOAVISO TO V0DPCF-BCOAVISO */
            _.Move(V0AVIS_BCOAVISO, V0DPCF_BCOAVISO);

            /*" -7910- MOVE V0AVIS-AGEAVISO TO V0DPCF-AGEAVISO */
            _.Move(V0AVIS_AGEAVISO, V0DPCF_AGEAVISO);

            /*" -7911- MOVE V0AVIS-NRAVISO TO V0DPCF-NRAVISO */
            _.Move(V0AVIS_NRAVISO, V0DPCF_NRAVISO);

            /*" -7912- MOVE '1' TO V0DPCF-TIPOCOB */
            _.Move("1", V0DPCF_TIPOCOB);

            /*" -7913- MOVE V0AVIS-DTMOVTO TO V0DPCF-DTMOVTO */
            _.Move(V0AVIS_DTMOVTO, V0DPCF_DTMOVTO);

            /*" -7914- MOVE V0AVIS-DTAVISO TO V0DPCF-DTAVISO */
            _.Move(V0AVIS_DTAVISO, V0DPCF_DTAVISO);

            /*" -7917- MOVE ZEROS TO V0DPCF-VLJUROS V0DPCF-VLMULTA. */
            _.Move(0, V0DPCF_VLJUROS, V0DPCF_VLMULTA);

            /*" -7918- MOVE V0AVIS-DTAVISO TO WDATA-REL */
            _.Move(V0AVIS_DTAVISO, WORK_AREA.WDATA_REL);

            /*" -7919- MOVE WDAT-REL-ANO TO V0DPCF-ANOREF */
            _.Move(WORK_AREA.FILLER_15.WDAT_REL_ANO, V0DPCF_ANOREF);

            /*" -7922- MOVE WDAT-REL-MES TO V0DPCF-MESREF. */
            _.Move(WORK_AREA.FILLER_15.WDAT_REL_MES, V0DPCF_MESREF);

            /*" -7923- SET WS-TIP TO 1 */
            WS_TIP.Value = 1;

            /*" -7926- PERFORM R8550-00-GRAVA-TIPO 03 TIMES. */

            for (int i = 0; i < 3; i++)
            {

                R8550_00_GRAVA_TIPO_SECTION();

            }

            /*" -7926- SET WS-PRD UP BY 1. */
            WS_PRD.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8500_99_SAIDA*/

        [StopWatch]
        /*" R8550-00-GRAVA-TIPO-SECTION */
        private void R8550_00_GRAVA_TIPO_SECTION()
        {
            /*" -7939- MOVE 'R8550-GRAVA-TIPO        ' TO PARAGRAFO. */
            _.Move("R8550-GRAVA-TIPO        ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7943- MOVE WTABG-TIPO(WS-PRD WS-TIP) TO V0DPCF-TIPOREG. */
            _.Move(AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_TIPO, V0DPCF_TIPOREG);

            /*" -7944- SET WS-SIT TO 1 */
            WS_SIT.Value = 1;

            /*" -7947- PERFORM R8600-00-GRAVA-REGISTRO 02 TIMES. */

            for (int i = 0; i < 2; i++)
            {

                R8600_00_GRAVA_REGISTRO_SECTION();

            }

            /*" -7947- SET WS-TIP UP BY 1. */
            WS_TIP.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8550_99_SAIDA*/

        [StopWatch]
        /*" R8600-00-GRAVA-REGISTRO-SECTION */
        private void R8600_00_GRAVA_REGISTRO_SECTION()
        {
            /*" -7960- MOVE 'R8600-GRAVA-REGISTRO    ' TO PARAGRAFO. */
            _.Move("R8600-GRAVA-REGISTRO    ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -7962- MOVE WTABG-SITUACAO(WS-PRD WS-TIP WS-SIT) TO V0DPCF-SITUACAO. */
            _.Move(AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_SITUACAO, V0DPCF_SITUACAO);

            /*" -7964- MOVE WTABG-QTDE(WS-PRD WS-TIP WS-SIT) TO V0DPCF-QTDREG. */
            _.Move(AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_QTDE, V0DPCF_QTDREG);

            /*" -7966- MOVE WTABG-VLPRMTOT(WS-PRD WS-TIP WS-SIT) TO V0DPCF-VLPRMTOT. */
            _.Move(AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLPRMTOT, V0DPCF_VLPRMTOT);

            /*" -7968- MOVE WTABG-VLTARIFA(WS-PRD WS-TIP WS-SIT) TO V0DPCF-VLTARIFA. */
            _.Move(AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLTARIFA, V0DPCF_VLTARIFA);

            /*" -7970- MOVE WTABG-VLBALCAO(WS-PRD WS-TIP WS-SIT) TO V0DPCF-VLBALCAO. */
            _.Move(AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLBALCAO, V0DPCF_VLBALCAO);

            /*" -7972- MOVE WTABG-VLIOCC(WS-PRD WS-TIP WS-SIT) TO V0DPCF-VLIOCC. */
            _.Move(AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLIOCC, V0DPCF_VLIOCC);

            /*" -7976- MOVE WTABG-VLDESCON(WS-PRD WS-TIP WS-SIT) TO V0DPCF-VLDESCON. */
            _.Move(AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLDESCON, V0DPCF_VLDESCON);

            /*" -7983- COMPUTE V0DPCF-VLPRMLIQ EQUAL (V0DPCF-VLPRMTOT - V0DPCF-VLTARIFA - V0DPCF-VLBALCAO - V0DPCF-VLIOCC - V0DPCF-VLDESCON - V0DPCF-VLJUROS - V0DPCF-VLMULTA). */
            V0DPCF_VLPRMLIQ.Value = (V0DPCF_VLPRMTOT - V0DPCF_VLTARIFA - V0DPCF_VLBALCAO - V0DPCF_VLIOCC - V0DPCF_VLDESCON - V0DPCF_VLJUROS - V0DPCF_VLMULTA);

            /*" -7988- IF V0DPCF-QTDREG EQUAL ZEROS AND V0DPCF-VLPRMTOT EQUAL ZEROS AND V0DPCF-VLPRMLIQ EQUAL ZEROS AND V0DPCF-VLTARIFA EQUAL ZEROS AND V0DPCF-VLBALCAO EQUAL ZEROS */

            if (V0DPCF_QTDREG == 00 && V0DPCF_VLPRMTOT == 00 && V0DPCF_VLPRMLIQ == 00 && V0DPCF_VLTARIFA == 00 && V0DPCF_VLBALCAO == 00)
            {

                /*" -7989- SET WS-SIT UP BY 1 */
                WS_SIT.Value += 1;

                /*" -7992- GO TO R8600-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8600_99_SAIDA*/ //GOTO
                return;
            }


            /*" -7995- PERFORM R8700-00-INSERT-DESPESAS. */

            R8700_00_INSERT_DESPESAS_SECTION();

            /*" -8004- MOVE ZEROS TO WTABG-QTDE(WS-PRD WS-TIP WS-SIT) WTABG-VLPRMTOT(WS-PRD WS-TIP WS-SIT) WTABG-VLTARIFA(WS-PRD WS-TIP WS-SIT) WTABG-VLBALCAO(WS-PRD WS-TIP WS-SIT) WTABG-VLIOCC(WS-PRD WS-TIP WS-SIT) WTABG-VLDESCON(WS-PRD WS-TIP WS-SIT). */
            _.Move(0, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_QTDE, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLPRMTOT, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLTARIFA, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLBALCAO, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLIOCC, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLDESCON);

            /*" -8004- SET WS-SIT UP BY 1. */
            WS_SIT.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8600_99_SAIDA*/

        [StopWatch]
        /*" R8700-00-INSERT-DESPESAS-SECTION */
        private void R8700_00_INSERT_DESPESAS_SECTION()
        {
            /*" -8019- MOVE 'R8700-INSERT-DESPESAS   ' TO PARAGRAFO. */
            _.Move("R8700-INSERT-DESPESAS   ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8020- MOVE 91 TO W01-I */
            _.Move(91, FILLER_11.W01_I);

            /*" -8022- MOVE 'INSERT CONTROL_DESPES_CEF' TO W01-TEXTO(W01-I) */
            _.Move("INSERT CONTROL_DESPES_CEF", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -8026- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -8051- PERFORM R8700_00_INSERT_DESPESAS_DB_INSERT_1 */

            R8700_00_INSERT_DESPESAS_DB_INSERT_1();

            /*" -8055- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -8061- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -8062- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -8069- DISPLAY 'VA0813B - PROBLEMAS NO INSERT CONTROL_DESP_CE' V0HCTA-NRCERTIF ' ' V0HCTA-NRPARCEL ' ' V0HCOB-NRTIT ' ' V0PROP-CODCLIEN ' ' WHOST-CODCONV ' ' V0HCTA-NSAS */

                $"VA0813B - PROBLEMAS NO INSERT CONTROL_DESP_CE{V0HCTA_NRCERTIF} {V0HCTA_NRPARCEL} {V0HCOB_NRTIT} {V0PROP_CODCLIEN} {WHOST_CODCONV} {V0HCTA_NSAS}"
                .Display();

                /*" -8069- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R8700-00-INSERT-DESPESAS-DB-INSERT-1 */
        public void R8700_00_INSERT_DESPESAS_DB_INSERT_1()
        {
            /*" -8051- EXEC SQL INSERT INTO SEGUROS.CONTROL_DESPES_CEF VALUES (:V0DPCF-CODEMP , :V0DPCF-ANOREF , :V0DPCF-MESREF , :V0DPCF-BCOAVISO , :V0DPCF-AGEAVISO , :V0DPCF-NRAVISO , :V0DPCF-CODPRODU , :V0DPCF-TIPOREG , :V0DPCF-SITUACAO , :V0DPCF-TIPOCOB , :V0DPCF-DTMOVTO , :V0DPCF-DTAVISO , :V0DPCF-QTDREG , :V0DPCF-VLPRMTOT , :V0DPCF-VLPRMLIQ , :V0DPCF-VLTARIFA , :V0DPCF-VLBALCAO , :V0DPCF-VLIOCC , :V0DPCF-VLDESCON , :V0DPCF-VLJUROS , :V0DPCF-VLMULTA , CURRENT TIMESTAMP) END-EXEC. */

            var r8700_00_INSERT_DESPESAS_DB_INSERT_1_Insert1 = new R8700_00_INSERT_DESPESAS_DB_INSERT_1_Insert1()
            {
                V0DPCF_CODEMP = V0DPCF_CODEMP.ToString(),
                V0DPCF_ANOREF = V0DPCF_ANOREF.ToString(),
                V0DPCF_MESREF = V0DPCF_MESREF.ToString(),
                V0DPCF_BCOAVISO = V0DPCF_BCOAVISO.ToString(),
                V0DPCF_AGEAVISO = V0DPCF_AGEAVISO.ToString(),
                V0DPCF_NRAVISO = V0DPCF_NRAVISO.ToString(),
                V0DPCF_CODPRODU = V0DPCF_CODPRODU.ToString(),
                V0DPCF_TIPOREG = V0DPCF_TIPOREG.ToString(),
                V0DPCF_SITUACAO = V0DPCF_SITUACAO.ToString(),
                V0DPCF_TIPOCOB = V0DPCF_TIPOCOB.ToString(),
                V0DPCF_DTMOVTO = V0DPCF_DTMOVTO.ToString(),
                V0DPCF_DTAVISO = V0DPCF_DTAVISO.ToString(),
                V0DPCF_QTDREG = V0DPCF_QTDREG.ToString(),
                V0DPCF_VLPRMTOT = V0DPCF_VLPRMTOT.ToString(),
                V0DPCF_VLPRMLIQ = V0DPCF_VLPRMLIQ.ToString(),
                V0DPCF_VLTARIFA = V0DPCF_VLTARIFA.ToString(),
                V0DPCF_VLBALCAO = V0DPCF_VLBALCAO.ToString(),
                V0DPCF_VLIOCC = V0DPCF_VLIOCC.ToString(),
                V0DPCF_VLDESCON = V0DPCF_VLDESCON.ToString(),
                V0DPCF_VLJUROS = V0DPCF_VLJUROS.ToString(),
                V0DPCF_VLMULTA = V0DPCF_VLMULTA.ToString(),
            };

            R8700_00_INSERT_DESPESAS_DB_INSERT_1_Insert1.Execute(r8700_00_INSERT_DESPESAS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8700_99_SAIDA*/

        [StopWatch]
        /*" R8800-00-UPDATE-FOLLOWUP-SECTION */
        private void R8800_00_UPDATE_FOLLOWUP_SECTION()
        {
            /*" -8081- MOVE 'R8800-UPDATE-FOLLOWUP   ' TO PARAGRAFO. */
            _.Move("R8800-UPDATE-FOLLOWUP   ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -8082- MOVE 92 TO W01-I */
            _.Move(92, FILLER_11.W01_I);

            /*" -8084- MOVE 'UPDATE VG_FOLLOW_UP' TO W01-TEXTO(W01-I) */
            _.Move("UPDATE VG_FOLLOW_UP", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -8088- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -8100- PERFORM R8800_00_UPDATE_FOLLOWUP_DB_UPDATE_1 */

            R8800_00_UPDATE_FOLLOWUP_DB_UPDATE_1();

            /*" -8104- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -8109- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -8110- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -8116- IF SQLCODE EQUAL 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -8117- ELSE */
                }
                else
                {


                    /*" -8127- DISPLAY 'VA0813B - PROBLEMAS NO UPDATE VG_FOLLOW_UP   ' V0HCTA-NRCERTIF ' ' V0HCTA-NRPARCEL ' ' V0HCOB-NRTIT ' ' V0PROP-CODCLIEN ' ' WHOST-CODCONV ' ' V0HCTA-NSAS ' ' VGFOLLOW-NUM-CERTIFICADO ' ' VGFOLLOW-NUM-NOSSA-FITA ' ' VGFOLLOW-NUM-LANCAMENTO */

                    $"VA0813B - PROBLEMAS NO UPDATE VG_FOLLOW_UP   {V0HCTA_NRCERTIF} {V0HCTA_NRPARCEL} {V0HCOB_NRTIT} {V0PROP_CODCLIEN} {WHOST_CODCONV} {V0HCTA_NSAS} {VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_CERTIFICADO} {VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_NOSSA_FITA} {VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_LANCAMENTO}"
                    .Display();

                    /*" -8127- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R8800-00-UPDATE-FOLLOWUP-DB-UPDATE-1 */
        public void R8800_00_UPDATE_FOLLOWUP_DB_UPDATE_1()
        {
            /*" -8100- EXEC SQL UPDATE SEGUROS.VG_FOLLOW_UP SET NUM_PARCELA_USADA = :V0HCTA-NRPARCEL, STA_PROCESSAMENTO = 'P' , COD_USUARIO = 'VA0813B' , DTH_ATUALIZACAO = CURRENT TIMESTAMP WHERE NUM_CERTIFICADO = :VGFOLLOW-NUM-CERTIFICADO AND NUM_NOSSA_FITA = :VGFOLLOW-NUM-NOSSA-FITA AND NUM_LANCAMENTO = :VGFOLLOW-NUM-LANCAMENTO END-EXEC. */

            var r8800_00_UPDATE_FOLLOWUP_DB_UPDATE_1_Update1 = new R8800_00_UPDATE_FOLLOWUP_DB_UPDATE_1_Update1()
            {
                V0HCTA_NRPARCEL = V0HCTA_NRPARCEL.ToString(),
                VGFOLLOW_NUM_CERTIFICADO = VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_CERTIFICADO.ToString(),
                VGFOLLOW_NUM_NOSSA_FITA = VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_NOSSA_FITA.ToString(),
                VGFOLLOW_NUM_LANCAMENTO = VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_LANCAMENTO.ToString(),
            };

            R8800_00_UPDATE_FOLLOWUP_DB_UPDATE_1_Update1.Execute(r8800_00_UPDATE_FOLLOWUP_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8800_99_SAIDA*/

        [StopWatch]
        /*" R8900-TOTALIZA-INICIO-SECTION */
        private void R8900_TOTALIZA_INICIO_SECTION()
        {
            /*" -8143- INITIALIZE W01-QTD-ACC-OK W01-QTD-ACC-NOK */
            _.Initialize(
                FILLER_11.W01_QTD_ACC_OK
                , FILLER_11.W01_QTD_ACC_NOK
            );

            /*" -8144- MOVE FUNCTION CURRENT-DATE TO W01-CURRENT-DATE */
            _.Move(_.CurrentDate(), FILLER_11.W01_CURRENT_DATE);

            /*" -8147- COMPUTE W01-SEG-INI = (W01-CDTE-HORA * 60 * 60) + (W01-CDTE-MIN * 60) + W01-CDTE-SEG + (W01-CDTE-DECSEG / 100) */
            FILLER_11.W01_SEG_INI.Value = (FILLER_11.W01_CURRENT_DATE.W01_CDTE_HORA * 60 * 60) + (FILLER_11.W01_CURRENT_DATE.W01_CDTE_MIN * 60) + FILLER_11.W01_CURRENT_DATE.W01_CDTE_SEG + (FILLER_11.W01_CURRENT_DATE.W01_CDTE_DECSEG / 100f);

            /*" -8147- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/

        [StopWatch]
        /*" R8910-TOTALIZA-FINAL-SECTION */
        private void R8910_TOTALIZA_FINAL_SECTION()
        {
            /*" -8155- ADD W01-QTD-ACC-OK TO W01-TOT-ACC-OK(W01-I) */
            FILLER_11.W01_TABELA_TOTAIS.W01_TOT_ACC_OK[FILLER_11.W01_I].Value = FILLER_11.W01_TABELA_TOTAIS.W01_TOT_ACC_OK[FILLER_11.W01_I] + FILLER_11.W01_QTD_ACC_OK;

            /*" -8158- ADD W01-QTD-ACC-NOK TO W01-TOT-ACC-NOK(W01-I) */
            FILLER_11.W01_TABELA_TOTAIS.W01_TOT_ACC_NOK[FILLER_11.W01_I].Value = FILLER_11.W01_TABELA_TOTAIS.W01_TOT_ACC_NOK[FILLER_11.W01_I] + FILLER_11.W01_QTD_ACC_NOK;

            /*" -8159- MOVE FUNCTION CURRENT-DATE TO W01-CURRENT-DATE */
            _.Move(_.CurrentDate(), FILLER_11.W01_CURRENT_DATE);

            /*" -8162- COMPUTE W01-SEG-FIN = (W01-CDTE-HORA * 60 * 60) + (W01-CDTE-MIN * 60) + W01-CDTE-SEG + (W01-CDTE-DECSEG / 100) */
            FILLER_11.W01_SEG_FIN.Value = (FILLER_11.W01_CURRENT_DATE.W01_CDTE_HORA * 60 * 60) + (FILLER_11.W01_CURRENT_DATE.W01_CDTE_MIN * 60) + FILLER_11.W01_CURRENT_DATE.W01_CDTE_SEG + (FILLER_11.W01_CURRENT_DATE.W01_CDTE_DECSEG / 100f);

            /*" -8163- SUBTRACT W01-SEG-INI FROM W01-SEG-FIN */
            FILLER_11.W01_SEG_FIN.Value = FILLER_11.W01_SEG_FIN - FILLER_11.W01_SEG_INI;

            /*" -8164- ADD W01-SEG-FIN TO W01-TOT-TIME(W01-I) */
            FILLER_11.W01_TABELA_TOTAIS.W01_TOT_TIME[FILLER_11.W01_I].Value = FILLER_11.W01_TABELA_TOTAIS.W01_TOT_TIME[FILLER_11.W01_I] + FILLER_11.W01_SEG_FIN;

            /*" -8164- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/

        [StopWatch]
        /*" R8920-MOSTRA-TOTALIZADORES-SECTION */
        private void R8920_MOSTRA_TOTALIZADORES_SECTION()
        {
            /*" -8175- DISPLAY ' ' */
            _.Display($" ");

            /*" -8176- DISPLAY '--> R8920-MOSTRA-TOTALIZADORES:' */
            _.Display($"--> R8920-MOSTRA-TOTALIZADORES:");

            /*" -8178- DISPLAY '==================================================' '===============================' */
            _.Display($"=================================================================================");

            /*" -8180- DISPLAY '      TOTALIZACAO                                 ' 'EXECUTADOS' */
            _.Display($"      TOTALIZACAO                                 EXECUTADOS");

            /*" -8182- DISPLAY '   TOTAIS                               QTD OK   T' 'EMPO(SEG)           OC' */
            _.Display($"   TOTAIS                               QTD OK   TEMPO(SEG)           OC");

            /*" -8184- DISPLAY '----------------------------------- ---------- ---' '----------   -----------' */
            _.Display($"----------------------------------- ---------- -------------   -----------");

            /*" -8186- DISPLAY 'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX   00.000.000   0' '0.000.000   (000000000)' */
            _.Display($"XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX   00.000.000   00.000.000   (000000000)");

            /*" -8189- DISPLAY '==================================================' '===============================' */
            _.Display($"=================================================================================");

            /*" -8191- PERFORM VARYING W01-I FROM 1 BY 1 UNTIL W01-I > W01-LIM-OCOR */

            for (FILLER_11.W01_I.Value = 1; !(FILLER_11.W01_I > FILLER_11.W01_LIM_OCOR); FILLER_11.W01_I.Value += 1)
            {

                /*" -8192-  EVALUATE TRUE  */

                /*" -8193-  WHEN W01-TEXTO(W01-I) NOT = LOW-VALUES AND SPACES  */

                /*" -8193- IF W01-TEXTO(W01-I) NOT = LOW-VALUES AND SPACES */

                if (FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO != "")
                {

                    /*" -8194- MOVE W01-TOT-ACC-OK(W01-I) TO W01-TOT-ACC-OK-ED */
                    _.Move(FILLER_11.W01_TABELA_TOTAIS.W01_TOT_ACC_OK[FILLER_11.W01_I], FILLER_11.W01_TOT_ACC_OK_ED);

                    /*" -8195- MOVE W01-TOT-TIME(W01-I) TO W01-TOT-TIME-ED */
                    _.Move(FILLER_11.W01_TABELA_TOTAIS.W01_TOT_TIME[FILLER_11.W01_I], FILLER_11.W01_TOT_TIME_ED);

                    /*" -8199- DISPLAY W01-TEXTO(W01-I) '  ' W01-TOT-ACC-OK-ED ' ' W01-TOT-TIME-ED '  (' W01-I ')' */

                    $"{FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I]}  {FILLER_11.W01_TOT_ACC_OK_ED} {FILLER_11.W01_TOT_TIME_ED}  ({FILLER_11.W01_I})"
                    .Display();

                    /*" -8200-  END-EVALUATE  */

                    /*" -8200- END-IF */
                }


                /*" -8202- END-PERFORM */
            }

            /*" -8204- DISPLAY '==================================================' '===============================' */
            _.Display($"=================================================================================");

            /*" -8205- DISPLAY ' ' */
            _.Display($" ");

            /*" -8205- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8920_MOSTRA_TOTALIZ_EXIT*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -8216- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WORK_AREA.WABEND.WSQLCODE);

            /*" -8217- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], WORK_AREA.WABEND.WSQLERRD1);

            /*" -8218- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], WORK_AREA.WABEND.WSQLERRD2);

            /*" -8219- DISPLAY WABEND. */
            _.Display(WORK_AREA.WABEND);

            /*" -8220- DISPLAY LOCALIZA-ABEND-1. */
            _.Display(WORK_AREA.LOCALIZA_ABEND_1);

            /*" -8222- DISPLAY LOCALIZA-ABEND-2. */
            _.Display(WORK_AREA.LOCALIZA_ABEND_2);

            /*" -8223- CLOSE RETDEB. */
            RETDEB.Close();

            /*" -8224- CLOSE RETERR. */
            RETERR.Close();

            /*" -8228- CLOSE MAUDIT. */
            MAUDIT.Close();

            /*" -8229- MOVE 93 TO W01-I */
            _.Move(93, FILLER_11.W01_I);

            /*" -8230- MOVE 'ROLLBACK WORK' TO W01-TEXTO(W01-I) */
            _.Move("ROLLBACK WORK", FILLER_11.W01_TABELA_TEXTO.W01_TAB_TEXTO[FILLER_11.W01_I].W01_TEXTO);

            /*" -8234- PERFORM R8900-TOTALIZA-INICIO THRU R8900-TOTALIZA-INICIO-EXIT */

            R8900_TOTALIZA_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_TOTALIZA_INICIO_EXIT*/


            /*" -8234- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -8238- MOVE 1 TO W01-QTD-ACC-OK */
            _.Move(1, FILLER_11.W01_QTD_ACC_OK);

            /*" -8242- PERFORM R8910-TOTALIZA-FINAL THRU R8910-TOTALIZA-FINAL-EXIT */

            R8910_TOTALIZA_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8910_TOTALIZA_FINAL_EXIT*/


            /*" -8243- DISPLAY 'CERTIFICADO ' V0HCTA-NRCERTIF. */
            _.Display($"CERTIFICADO {V0HCTA_NRCERTIF}");

            /*" -8244- DISPLAY 'PARCELA     ' V0HCTA-NRPARCEL. */
            _.Display($"PARCELA     {V0HCTA_NRPARCEL}");

            /*" -8247- DISPLAY 'LIDOS       ' AC-LIDOS. */
            _.Display($"LIDOS       {WORK_AREA.AC_LIDOS}");

            /*" -8251- PERFORM R8920-MOSTRA-TOTALIZADORES THRU R8920-MOSTRA-TOTALIZ-EXIT */

            R8920_MOSTRA_TOTALIZADORES_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8920_MOSTRA_TOTALIZ_EXIT*/


            /*" -8253- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -8253- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}