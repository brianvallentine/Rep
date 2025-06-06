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
using Sias.VidaEmGrupo.DB2.VG0267B;

namespace Code
{
    public class VG0267B
    {
        public bool IsCall { get; set; }

        public VG0267B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *                    OBJETIVO DO PROGRAMA                        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * EMITE FATURA MENSAL DE PREMIOS PARA AS APOLICES ESPECIFICAS E  *      */
        /*"      * EMPRESARIAL NA NOVA ESTRUTURA DE FATURAMENTO.                  *      */
        /*"      *  V0HISTCOBVA COM SITUACAO = '5' => IMPRIMIR CORRESPONDENCIA    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   OPCAOPAG 1 E 2 =>  DEBITO    EM CONTA    CORRENTE            *      */
        /*"      *   OPCAOPAG     3 =>  DOCUMENTO DE COBRANCA BANCARIA            *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.52  *  VERSAO 52  - JAZZ   582106                                    *      */
        /*"      *             - META 2024 - INCORPORACAO DA EMPRESA XS2 PELA     *      */
        /*"      *               CVP.                                             *      */
        /*"      *                                                                *      */
        /*"      *   EM 21/08/2024 - SERGIO LORETO                                *      */
        /*"      *                                       PROCURE POR V.52         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"JV151 *VERSAO 51: JV1 DEMANDA 259756 - KINKAS 10/10/2020               *      */
        /*"JV151 *           ALTERA FORMULARIOS FASE 2 PARA EMPRESA 11 - JV1      *      */
        /*"JV151 *           - PROCURAR POR JV151                                 *      */
        /*"JV150 *-----------------------------------------------------------------      */
        /*"JV150 *VERSAO 50: JV1 DEMANDA 256312 - KINKAS 10/09/2020                      */
        /*"JV150 *           ALTERA FORMULARIOS PARA EMPRESA 11 - JV1                    */
        /*"JV150 *           - PROCURAR POR JV150                                        */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 49   - DEMANDA 235069                                 *      */
        /*"      *               - PASSAR A GRAVAR NO ARQUIVO 1 O FORM VD32       *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/05/2020 - CANETTA             PROCURE POR V.49         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 48   - DEMANDA 226662                                 *      */
        /*"      *               - CRIAR PARAMENTRO LINKAGE PARA RECEBER DATA     *      */
        /*"      *                 EXTERNA E PERMITIR IMPRESSAO SOMENTE PARA      *      */
        /*"      *                 MENOR O IGUAL A DATA DO PARAMETRO              *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/05/2020 - HUSNI ALI HUSNI                              *      */
        /*"      *                                       PROCURE POR V.48         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 47 - HISTORIA 206622 TAREFA 226808                    *      */
        /*"      *             - POR DETERMINA��O DE mYCON, OS FORMULARIOS CVP    *      */
        /*"      *                   SER�O OS MESMO C�DIGO SEGURADORA.            *      */
        /*"      *   DATA      - 18/12/2019 - HERVAL SOUZA                        *      */
        /*"      *                                        PROCURE POR V.47        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 46 - CADMUS 175348 - INCIDENTE 208060                 *      */
        /*"      *             - ACERTAR TRATAMENTO DE FORMULARIOS QUE SERAO      *      */
        /*"      *             - INSERIDOS NA TABELA GE_OBJECT_ECT                *      */
        /*"      *   DATA      - 09/07/2019 - HUSNI ALI HUSNI                     *      */
        /*"      *                                        PROCURE POR V46         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"JV.01 *   VERSAO 45 - PROJETO JOINT VENTURE (JV)                       *      */
        /*"=     *             - AVALIAR CEDENTE SAP.                             *      */
        /*"=     *             - Historia: 192562.                                *      */
        /*"=     *    EM 06/03/2019 - HERVAL SOUZA                                *      */
        /*"=     *                                        PROCURE POR JV.01       *      */
        /*"JV.01 *----------------------------------------------------------------*      */
        /*"      *   VERSAO 44 -                                                  *      */
        /*"      *             - PREPARAR PROGRAMA PARA PROCESSAMENTO DA FOLHETE. *      */
        /*"      *             -  RIA                                             *      */
        /*"      *   EM 17/02/2019 - JOAO ARAUJO         FIND BY JV1              *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 43 - HIST 181.584                                     *      */
        /*"      *             - PREPARAR PROGRAMA PARA PROCESSAMENTO DA JV1      *      */
        /*"      *                                                                *      */
        /*"      *   EM 21/01/2019 - HUSNI ALI HUSNI                              *      */
        /*"      *                                       PROCURE POR JV101        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 42 - HISTORIA 26733                                   *      */
        /*"      *   EM 10/09/2018 - CLOVIS                           V.42        *      */
        /*"      *                                                                *      */
        /*"      *   1) IDENTIFICAMOS QUE AP�S A ALTERA��O, O SIAS EST� GERANDO   *      */
        /*"      *      INDEVIDAMENTE BOLETOS PARA OS PRODUTOS EMPRESARIAS, NO    *      */
        /*"      *      FORMUL�RIO VD32.                                          *      */
        /*"      *                                                                *      */
        /*"      *   PROCEDIMENTO EFETUADO: AJUSTE NA ROTINA DE QUEBRA            *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 41 - HISTORIA 39828                                   *      */
        /*"      *               BOLETOS DE APOLICE ESPECIFICA = VD32             *      */
        /*"      *               OUTROS PRODUTOS RETORNAM PARA VD02               *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/06/2018 - CLOVIS                           V.41        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 40   - HIST�RIA 11911                                 *      */
        /*"      *                 ENVIAR NUMERO CERTIFICADO NO CAMPO             *      */
        /*"      *                 NUMCONTACONTRATO                               *      */
        /*"      *   EM 15/05/2018 - CLAUDETE RADEL                               *      */
        /*"      *                                       PROCURE POR V.40         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 39 - HISTORIA 12.077                                  *      */
        /*"      *             - DESFAZ ALTERACAO DA VERSAO 37, POR DEIXAR DE  -  *      */
        /*"      *               GERAR BOLETO PARA OS PRODUTOS EMPRESARIAL CITADOS*      */
        /*"      *                                                                *      */
        /*"      *   EM 22/02/2018 - ELIERMES OLIVEIRA                V.39        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 38 - CADMUS 155.525                                   *      */
        /*"      *             - ALTERAR O NOME DO FORMULARIO DE VD02 PARA VD32   *      */
        /*"      *               PARA OS BOLETOS DE APOLICE ESPECIFICA.           *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/12/2017 - ELIERMES OLIVEIRA                V.38        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 37 - CADMUS 153.730                                   *      */
        /*"      *             - CONFORME SOLICITADO NA DEMANDA, OS PRODUTOS EM-  *      */
        /*"      *               PRESARIAIS NAO DEVEM TER O FORMULARIO VD02 IM-   *      */
        /*"      *               PRESSO ATRAVES DESTE PROGRAMA, POIS OS DADOS JA  *      */
        /*"      *               ESTAO GERADOS EM OUTRO PROGRAMA, EMITINDO BOLETO *      */
        /*"      *               DUPLICADO - UM BOLETO PARA CADA GRAFICA (PDF E   *      */
        /*"      *               VIA UNIC).                                       *      */
        /*"      *                                                                *      */
        /*"      *   EM 03/11/2017 - RIBAMAR MARQUES (ALTRAN)         V.37        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 36 - CADMUS 153.098                                   *      */
        /*"      *             - COMPRA DE NN SIGCB ONLINE VIA SERVI�O CICS/SAP   *      */
        /*"      *                                                                *      */
        /*"      *   EM 07/08/2017 - ELIERMES OLIVEIRA                V.36        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 35 - CADMUS 140.778                                   *      */
        /*"      *             - ERRO DE DESLOCAMENTO DO CODIGO CEDENTE NO CALCULO*      */
        /*"      *               DA LINHA DIGITAVEL.                              *      */
        /*"      *                                                                *      */
        /*"      *   EM 23/01/2017 - ELIERMES OLIVEIRA                V.35        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 34 - CADMUS 140.778                                   *      */
        /*"      *             - GRAVAR SITUACAO 'I' NO HISTORICO DO SIGCB, PARA  *      */
        /*"      *               RASTREAR IMPRESSAO DE BOLETO NO CT1100B          *      */
        /*"      *             - QUANDO CALCULO DE IOF FOR ZERO, GERAR SOLICITACAO*      */
        /*"      *               DE NN PARA O SAP COM VALOR 0,01                  *      */
        /*"      *             - SE ENCONTRAR SITUACAO 'R' NO SIGCB E DT-VENCIMENT*      */
        /*"      *               OU VALOR FOI MODIFICADO, RECOMANDA IMPRESSAO BOL *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/01/2017 - ELIERMES OLIVEIRA                V.34        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 33   - CADMUS 140.778                                 *      */
        /*"      *               ALTERACAO NO LIMITE DE IMPRESSAO DE BOLETO DE 15 *      */
        /*"      *               PARA 20 DIAS ANTES DA DATA DE VENCIMENTO DA PARC *      */
        /*"      *                                                                *      */
        /*"      *   EM 17/01/2017 - ELIERMES OLIVEIRA                V.33        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 32   - CADMUS 140.778                                 *      */
        /*"      *               - ACERTO NO PROGRAMA PARA PARAR DE SOLICITAR     *      */
        /*"      *                 NOVO NN PARA O SAP.                            *      */
        /*"      *                                                                *      */
        /*"      *               - DATA E VALOR ESTAVA SEMPRE COM VALORES         *      */
        /*"      *                 DIFERENTES.                                    *      */
        /*"      *   EM 22/12/2016 - THIAGO BLAIER                                *      */
        /*"      *                                       PROCURE POR V.32         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 31   - CADMUS 140.778                                 *      */
        /*"      *               - GERAR NOVA SOLICITACAO DE COMPRA DE NN PARA    *      */
        /*"      *                 PARCELAS QUE TENHA SOFRIDO MUDAN�A DE VALOR OU *      */
        /*"      *                 DE DATA DE VENCIMENTO                          *      */
        /*"      *               - NAO GERAR BOLETO PARA PARCELAS COM DATA DE     *      */
        /*"      *                 VENCIMENTO COM MAIS DE 29 DIAS ATRASO          *      */
        /*"      *   EM 15/12/2016 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                       PROCURE POR V.31         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 30   - CADMUS 140.778                                 *      */
        /*"      *               - ASSUME 0,38% PARA APOLICES QUE NAO TENHAM      *      */
        /*"      *                 PERCENTUAL DE IOF CADASTRADO NO SIAS           *      */
        /*"      *   EM 14/12/2016 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                       PROCURE POR V.30         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 29   - CADMUS 140.778                                 *      */
        /*"      *               - ERRO AO IMPRIMIR BOLETOS COM DT-VENCIMENTO     *      */
        /*"      *                 MENOR QUE DATA-PROCESSAMENTO                   *      */
        /*"      *   EM 13/12/2016 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                       PROCURE POR V.29         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 28   - CADMUS 140.778                                 *      */
        /*"      *               - CONTROLE DE IMPRESSAO DE BOLETO REALIZADO PELO *      */
        /*"      *                 SIGCB                                          *      */
        /*"      *               - SER� GERADO BOLETO APENAS SE O NN REGISTRADO   *      */
        /*"      *                 TIVER SIDO INFORMADO PELO SAP. CASO NEGATIVO   *      */
        /*"      *                 AGUARDA RETORNO DO SAP.                        *      */
        /*"      *   EM 12/12/2016 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                       PROCURE POR V.28         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 27 - CADMUS 142.541                                   *      */
        /*"      *             - CORRECAO: CORRECAO DE ABEND -304 NO CALCULO DE   *      */
        /*"      *               TERMINO DE VIGENCIA.                             *      */
        /*"      *   EM 27/09/2016 - ELIERMES OLIVEIRA             V.27           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 26 - CADMUS 128.293                                   *      */
        /*"      *               - CORRECAO: LIBERAR IMPRESSAS DE BOLETOS EM      *      */
        /*"      *                 ATRASO: OPERACOES 121, 122 E 123.              *      */
        /*"      *   EM 11/02/2016 - MIRIAM HECK (INDRA)           V.26           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 26 - CADMUS 128.293                                   *      */
        /*"      *               - CORRECAO: LIBERAR IMPRESSAS DE BOLETOS EM      *      */
        /*"      *                 ATRASO: OPERACOES 121, 122 E 123.              *      */
        /*"      *   EM 11/02/2016 - MIRIAM HECK (INDRA)           V.26           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 25 - CADMUS 116.938                                   *      */
        /*"      *               - PROJETO UNIC  - AJUSTE FORMULARIO VD02         *      */
        /*"      *                 REF. CALCULO IOF IMPRESSO                      *      */
        /*"      *   EM 20/07/2015 - RIBAMAR MARQUES (STEFANINI)   V.25           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 24 - NSGD - CADMUS 103659.                            *      */
        /*"      *               NOVA SOLUCAO DE GESTAO DE DEPOSITOS              *      */
        /*"      *   EM 26/06/2015 - COREON                        V.24           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 23 - CAD 112534                                       *      */
        /*"      *             - ignorar o produto 77nn, que esta sendo gerado    *      */
        /*"      *               para o formulario vd02 incorretamente, visto que *      */
        /*"      *               este produto pertence a bu op.financeiras.       *      */
        /*"      *   EM 30/03/2015 - Rogerio Lamas de Lima            v.23        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 22 - CAD 106628                                              */
        /*"      *             - ajuste para leitura e geracao da parcela         *      */
        /*"      *               referente ao certificados 10020970935,prod 7701 e       */
        /*"      *               10001829261, prod 9313.                                 */
        /*"      *               DA DISEF                                                */
        /*"      *   EM 22/12/2014 - alexandre andre                  V.22        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 21 - CAD 106596                                              */
        /*"      *             - INIBIR A LEITURA DO CERTIGFICADO 000010020970935 *      */
        /*"      *               DO PRODUTO 7701 DA DISEF                                */
        /*"      *             - CORRECAO DO ABEND -811                                  */
        /*"      *                                                                *      */
        /*"      *   EM 01/12/2014 - alexandre andre                  V.21        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 20 - CAD  95.498  - 98.505                            *      */
        /*"      *             - INSERIR ZEROS A ESQUERDA DO ULTIMO CONJUNTO      *      */
        /*"      *               NUMERICO DO CODIGO DE BARRAS DO BOLETO           *      */
        /*"      *             - ALTERAR ESPECIE DE COB PARA AP                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/09/2014 - ELIERMES OLIVEIRA                V.20        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 19 - CAD  101.524                                     *      */
        /*"      *               CORRECAO NO CALCULO DE PERIODO DO BOLETO         *      */
        /*"      *                                                                *      */
        /*"      *   EM 19/09/2014 - ELIERMES OLIVEIRA                V.19        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 18 - CAD  98423  retirada da trava do produto 9313    *      */
        /*"      *               incluido na versao anterior para evitar o abend  *      */
        /*"      *               -811 na tabela SEGUROS.V0COBERPROPVA             *      */
        /*"      *               ate que fosse feita analise do problema gerador.        */
        /*"      *                                                                *      */
        /*"      *   EM 26/05/2014 - alexandre andre                  V.18        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 17 - CAD  96.474 ABEND                                *      */
        /*"      *               PARA O PRODUTO 9313 CONSIDERAR A OCORHIST DA     *      */
        /*"      *               DA SEGUROS.V0COBERPROPVA                         *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/04/2014 - KATIA FERREIRA                   V.17        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 16 - CAD  94.662                                      *      */
        /*"      *               ALTERACAO NO LIMITE DE IMPRESSAO DE BOLETO DE 13 *      */
        /*"      *               PARA 15 DIAS ANTES DA DATA DE VENCIMENTO DA PARC *      */
        /*"      *                                                                *      */
        /*"      *   EM 07/03/2014 - ELIERMES OLIVEIRA                V.16        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 15 - CAD  88.049                                      *      */
        /*"      *               CORRECAO NO CALCULAR O PERIODO DE VIGENCIA PARA  *      */
        /*"      *               PRODUTOS 7701 E 9313                             *      */
        /*"      *                                                                *      */
        /*"      *   EM 28/01/2014 - TSUGUIRO TOGAWA                  V.15        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 14 - CAD  83.388 - CYRELA                             *      */
        /*"      *               CORRECAO DA VARIAVEL NUM-APOLICE                 *      */
        /*"      *                                                                *      */
        /*"      *   EM 23/10/2013 - ELIERMES OLIVEIRA                V.14        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 13 - CAD  83.388 - CYRELA                             *      */
        /*"      *               CORRECAO PERIODO VIGENCIA DA PARCELA QUANDO      *      */
        /*"      *               APOLICE CADASTRADA NA SEGUROS.VG_VIGENCIA_FATURA *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/10/2013 - ELIERMES OLIVEIRA                V.13        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 12 - CAD  83.388 - CYRELA                             *      */
        /*"      *               PERMITIR EMISSAO DE BOLETO DA APOLICE            *      */
        /*"      *               CYRELA (109300002554) SEM DATA LIMITE.           *      */
        /*"      *                                                                *      */
        /*"      *   EM 06/06/2013 - MARINHO CABRAL                   V.12        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 11 - CAD  81.094 - CYRELA                             *      */
        /*"      *               ANULAR A VERSAO 10 (V.10)                        *      */
        /*"      *                                                                *      */
        /*"      *   EM 04/06/2013 - MARINHO CABRAL                   V.11        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 10 - CAD  81.094 - CYRELA                             *      */
        /*"      *               INIBIR A GERACAO DE FATURA DA APOLICE CYRELA     *      */
        /*"      *               TEMPORARIAMENTE(AGUARDAR CONCLUSAO DA DEMANDA).  *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/05/2013 - MARINHO CABRAL                   V.10        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 09 - CAD  78.188                                      *      */
        /*"      *               AJUSTAR O ACESSO A V0COBERPROPVA. ACESSO PELO    *      */
        /*"      *          VENCIMENTO ORIGINAL DA PARCELA(V0PARCELVA).           *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/11/2012 - LUIZ MARQUES     (FAST COMPUTER)             *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.09             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 08 - CAD  75.978                                      *      */
        /*"      *               AJUSTAR O CALCULO DA DATA DE INICIO DE           *      */
        /*"      *          VIGENCIA PARA IMPRESSAO DO BOLETO.                    *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/11/2012 - EDIVALDO GOMES   (FAST COMPUTER)             *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.08             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   CADMUS 75456 - MUDAR A FORMA DE ACESSO NA TABELA             *      */
        /*"      *   V0COBERPROPVA. SERA EFETUADO PELA DATA DO PROXIMO VENCIMENTO *      */
        /*"      *   E NAO MAIS PELA OCORR-HISTORICO QUE � A PARCELA.             *      */
        /*"      *   JEFFERSON - OUTUBRO/2012 - PROCURAR: V.07                    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   CADMUS 61873 - INCLUIR O COD PRODUTO NO REGISTRO DE IMPRESSAO*      */
        /*"      *   O PRODUTO SERA UTILIZADO NO PORTAL DE IMPRESSAO PARA SEPARAR *      */
        /*"      *   A COBRANCA DE GERACAO DE PDF, POR PRODUTO.                   *      */
        /*"      *   JEFFERSON - OUTUBRO/2011 - PROCURAR: V.06                    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *     05     *  04/09/06  *   FAST       * PROCESSA TAMBEM O     *      */
        /*"      *            *            *              * EMPRESA GLOBAL        *      */
        /*"      *            *            *              * PROCURE V.05          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *     04     *  21/06/06  *   lucia      * Evita ABEND - sqlcode *      */
        /*"      *            *            *              * 100 paragrafo R2450   *      */
        /*"      *            *            *              * PROCURE V.04          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *     03     *  24/04/06  *   TERCIO     * AJUSTA CEP            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *     02     *  27/02/02  *   FREDERICO  * VERSAO PARA ATENDER   *      */
        /*"      *            *            *              * O NOVO FATURAMENTO    *      */
        /*"      *            *            *              * PROCURE V.03          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *     01     *  25/08/97  *   TERCIO     *                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ADEQUACAO PARA A NOVA GERACAO DE IMPRESSAO FAC                 *      */
        /*"      * VERSAO                          PRODEXTER          24/02/2003  *      */
        /*"      * (PROCURAR POR FR0203)                                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   CADMUS 29257 - EVITAR A REJEICAO DE CORRESPONDENCIAS, RECU-  *      */
        /*"      *   PERANDO O CEP NAS BASES DNE DOS CORREIOS PELO ENDERECO.      *      */
        /*"      *   BRSEG - SETEMBRO/2009 - VER: BR.V01                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *--------------------------------------                                 */
        #endregion


        #region VARIABLES

        public FileBasis _RVG0267B { get; set; } = new FileBasis(new PIC("X", "1500", "X(1500)"));

        public FileBasis RVG0267B
        {
            get
            {
                _.Move(RVG0267B_RECORD, _RVG0267B); VarBasis.RedefinePassValue(RVG0267B_RECORD, _RVG0267B, RVG0267B_RECORD); return _RVG0267B;
            }
        }
        public FileBasis _FVG0267B { get; set; } = new FileBasis(new PIC("X", "1500", "X(1500)"));

        public FileBasis FVG0267B
        {
            get
            {
                _.Move(FVG0267B_RECORD, _FVG0267B); VarBasis.RedefinePassValue(FVG0267B_RECORD, _FVG0267B, FVG0267B_RECORD); return _FVG0267B;
            }
        }
        public SortBasis<VG0267B_REG_SVG0267B> SVG0267B { get; set; } = new SortBasis<VG0267B_REG_SVG0267B>(new VG0267B_REG_SVG0267B());
        /*"01            RVG0267B-RECORD     PIC X(1500).*/
        public StringBasis RVG0267B_RECORD { get; set; } = new StringBasis(new PIC("X", "1500", "X(1500)."), @"");
        /*"01            FVG0267B-RECORD     PIC X(1500).*/
        public StringBasis FVG0267B_RECORD { get; set; } = new StringBasis(new PIC("X", "1500", "X(1500)."), @"");
        /*"01            REG-SVG0267B.*/
        public VG0267B_REG_SVG0267B REG_SVG0267B { get; set; } = new VG0267B_REG_SVG0267B();
        public class VG0267B_REG_SVG0267B : VarBasis
        {
            /*"    05        SVA-NRAPOLICE       PIC  9(013).*/
            public IntBasis SVA_NRAPOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"    05        SVA-CODSUBES        PIC  9(005).*/
            public IntBasis SVA_CODSUBES { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"    05        SVA-CODPRODU        PIC  9(004).*/
            public IntBasis SVA_CODPRODU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05        SVA-CEP-G           PIC  9(010).*/
            public IntBasis SVA_CEP_G { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"    05        SVA-NUM-CEP-9       PIC  9(008).*/
            public IntBasis SVA_NUM_CEP_9 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05        SVA-NUM-CEP         REDEFINES              SVA-NUM-CEP-9.*/
            private _REDEF_VG0267B_SVA_NUM_CEP _sva_num_cep { get; set; }
            public _REDEF_VG0267B_SVA_NUM_CEP SVA_NUM_CEP
            {
                get { _sva_num_cep = new _REDEF_VG0267B_SVA_NUM_CEP(); _.Move(SVA_NUM_CEP_9, _sva_num_cep); VarBasis.RedefinePassValue(SVA_NUM_CEP_9, _sva_num_cep, SVA_NUM_CEP_9); _sva_num_cep.ValueChanged += () => { _.Move(_sva_num_cep, SVA_NUM_CEP_9); }; return _sva_num_cep; }
                set { VarBasis.RedefinePassValue(value, _sva_num_cep, SVA_NUM_CEP_9); }
            }  //Redefines
            public class _REDEF_VG0267B_SVA_NUM_CEP : VarBasis
            {
                /*"      15      SVA-CEP             PIC  9(005).*/
                public IntBasis SVA_CEP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"      15      SVA-CEP-COMPL       PIC  9(003).*/
                public IntBasis SVA_CEP_COMPL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    05        SVA-NRCERTIF        PIC  9(015).*/

                public _REDEF_VG0267B_SVA_NUM_CEP()
                {
                    SVA_CEP.ValueChanged += OnValueChanged;
                    SVA_CEP_COMPL.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis SVA_NRCERTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05        SVA-OCORHIST        PIC  9(004).*/
            public IntBasis SVA_OCORHIST { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05        SVA-NRTIT           PIC  9(013).*/
            public IntBasis SVA_NRTIT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"    05        SVA-NRTITCOMP       PIC  9(013).*/
            public IntBasis SVA_NRTITCOMP { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"    05        SVA-NRCNPJ          PIC  9(015).*/
            public IntBasis SVA_NRCNPJ { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05        SVA-NRPARCEL        PIC  9(004).*/
            public IntBasis SVA_NRPARCEL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05        SVA-DTVENCTO        PIC  X(010).*/
            public StringBasis SVA_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05        SVA-DTVENCTO-ORIG   PIC  X(010).*/
            public StringBasis SVA_DTVENCTO_ORIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05        SVA-VLPRMTOT        PIC  9(013)V99.*/
            public DoubleBasis SVA_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    05        SVA-CODOPER         PIC  9(004).*/
            public IntBasis SVA_CODOPER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05        SVA-ENDERECO        PIC  X(072).*/
            public StringBasis SVA_ENDERECO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"    05        SVA-BAIRRO          PIC  X(072).*/
            public StringBasis SVA_BAIRRO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"    05        SVA-CIDADE          PIC  X(072).*/
            public StringBasis SVA_CIDADE { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"    05        SVA-UF              PIC  X(002).*/
            public StringBasis SVA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"    05        SVA-NOME-RAZAO      PIC  X(040).*/
            public StringBasis SVA_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    05        SVA-NOME-CORREIO    PIC  X(046).*/
            public StringBasis SVA_NOME_CORREIO { get; set; } = new StringBasis(new PIC("X", "46", "X(046)."), @"");
            /*"    05        SVA-FONTE           PIC  9(004).*/
            public IntBasis SVA_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05        SVA-AGECOBR         PIC  9(004).*/
            public IntBasis SVA_AGECOBR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05        SVA-DTQITBCO        PIC  X(010).*/
            public StringBasis SVA_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05        SVA-PERIPGTO        PIC  9(004).*/
            public IntBasis SVA_PERIPGTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05        SVA-NN-SIGCB        PIC  X(018).*/
            public StringBasis SVA_NN_SIGCB { get; set; } = new StringBasis(new PIC("X", "18", "X(018)."), @"");
            /*"    05        SVA-LIN-DIGITAVEL   PIC  X(054).*/
            public StringBasis SVA_LIN_DIGITAVEL { get; set; } = new StringBasis(new PIC("X", "54", "X(054)."), @"");
            /*"    05        SVA-DTA-VENC        PIC  X(10).*/
            public StringBasis SVA_DTA_VENC { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05        SVA-VLR-PREMIO      PIC  9(10)V99.*/
            public DoubleBasis SVA_VLR_PREMIO { get; set; } = new DoubleBasis(new PIC("9", "10", "9(10)V99."), 2);
            /*"    05        SVA-VLR-IOF         PIC  9(10)V99.*/
            public DoubleBasis SVA_VLR_IOF { get; set; } = new DoubleBasis(new PIC("9", "10", "9(10)V99."), 2);
            /*"    05        SVA-VLR-LIQUIDO     PIC  9(10)V99.*/
            public DoubleBasis SVA_VLR_LIQUIDO { get; set; } = new DoubleBasis(new PIC("9", "10", "9(10)V99."), 2);
            /*"    05        SVA-COD-CEDENTE     PIC  X(20).*/
            public StringBasis SVA_COD_CEDENTE { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
            /*"    05        SVA-CNTRLE-SIGCB    PIC  9(004).*/
            public IntBasis SVA_CNTRLE_SIGCB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05        SVA-NOMPRODU        PIC  X(30).*/
            public StringBasis SVA_NOMPRODU { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
            /*"    05        SVA-CODCDT          PIC  9(06).*/
            public IntBasis SVA_CODCDT { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
            /*"    05        SVA-TEM-CDG         PIC  X(01).*/
            public StringBasis SVA_TEM_CDG { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05        SVA-ESTR-COBR       PIC  X(10).*/
            public StringBasis SVA_ESTR_COBR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05        SVA-ORIG-PRODU      PIC  X(10).*/
            public StringBasis SVA_ORIG_PRODU { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05        SVA-FORMULARIO      PIC  X(08).*/
            public StringBasis SVA_FORMULARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
            /*"    05        SVA-COD-EMPRESA     PIC  9(004).*/
            public IntBasis SVA_COD_EMPRESA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis SORT_RETURN { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis SORT_FILE_SIZE { get; set; } = new IntBasis(new PIC("S9", "08", "S9(08)"));
        /*"77            VIND-NRCOPIAS       PIC S9(004)    COMP VALUE -1.*/
        public IntBasis VIND_NRCOPIAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), -1);
        /*"77            VIND-NRTITCOMP      PIC S9(004)    COMP VALUE -1.*/
        public IntBasis VIND_NRTITCOMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), -1);
        /*"77            SQL-PCIOF           PIC S9(003)V99 COMP-3.*/
        public DoubleBasis SQL_PCIOF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77            PROPOVA-COD-FONTE   PIC S9(004)    COMP.*/
        public IntBasis PROPOVA_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            WHOST-NRCERTIF       PIC S9(015)    COMP-3.*/
        public IntBasis WHOST_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77            WHOST-NRPARCEL       PIC S9(004)    COMP.*/
        public IntBasis WHOST_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            WHOST-NRTIT          PIC S9(013)    COMP-3.*/
        public IntBasis WHOST_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77            WHOST-NRTITCOMP      PIC S9(013)    COMP-3.*/
        public IntBasis WHOST_NRTITCOMP { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77            WHOST-OCORHIST       PIC S9(004)    COMP.*/
        public IntBasis WHOST_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            WHOST-NRAPOLICE      PIC S9(013)    COMP-3.*/
        public IntBasis WHOST_NRAPOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77            WHOST-CODSUBES       PIC S9(004)    COMP.*/
        public IntBasis WHOST_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            WHOST-CODOPER        PIC S9(004)    COMP.*/
        public IntBasis WHOST_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0COBP-QUANT-VIDAS   PIC S9(009)    COMP.*/
        public IntBasis V0COBP_QUANT_VIDAS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77            V0COBP-IMPSEGUR      PIC S9(013)V99 COMP-3.*/
        public DoubleBasis V0COBP_IMPSEGUR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77            WS-VLR-IOF           PIC S9(010)V99 COMP-3.*/
        public DoubleBasis WS_VLR_IOF { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V99"), 2);
        /*"77            V0COBP-DTINIVIG-PARC PIC  X(010).*/
        public StringBasis V0COBP_DTINIVIG_PARC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77            WS-FLAG-CALC-PARC    PIC  X(003) VALUE 'NAO'.*/
        public StringBasis WS_FLAG_CALC_PARC { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
        /*"77            WS-DTCALC-PARC       PIC  X(010).*/
        public StringBasis WS_DTCALC_PARC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77            WS-DTINIVIG-PARC     PIC  X(010).*/
        public StringBasis WS_DTINIVIG_PARC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77            WS-DTTERVIG-PARC     PIC  X(010).*/
        public StringBasis WS_DTTERVIG_PARC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77            WS-QTD-DIAS-PARC     PIC S9(013)    COMP-3.*/
        public IntBasis WS_QTD_DIAS_PARC { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77            V0COBP-OCORHIST      PIC S9(004)    COMP.*/
        public IntBasis V0COBP_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            WHOST-DATA1          PIC  X(010).*/
        public StringBasis WHOST_DATA1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77            WHOST-DATA2          PIC  X(010).*/
        public StringBasis WHOST_DATA2 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77            V1SIST-DTMOVABE     PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77            V1SIST-DTMOVABE-30  PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE_30 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77            V1SIST-DATA-LIMITE  PIC  X(010).*/
        public StringBasis V1SIST_DATA_LIMITE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77            V1SIST-MESREFER     PIC S9(004)    COMP.*/
        public IntBasis V1SIST_MESREFER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V1SIST-ANOREFER     PIC S9(004)    COMP.*/
        public IntBasis V1SIST_ANOREFER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0PROD-NUM-APOLICE  PIC S9(013)    COMP-3.*/
        public IntBasis V0PROD_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77            V0PROD-CODSUBES     PIC S9(004)    COMP.*/
        public IntBasis V0PROD_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0PROD-CODPRODU     PIC S9(004)    COMP.*/
        public IntBasis V0PROD_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0PROD-NOMPRODU     PIC  X(030).*/
        public StringBasis V0PROD_NOMPRODU { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
        /*"77            V0PROD-CODCDT       PIC S9(004)    COMP.*/
        public IntBasis V0PROD_CODCDT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0PROD-TEM-CDG      PIC  X(001).*/
        public StringBasis V0PROD_TEM_CDG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77            V0PROD-ESTR-COBR    PIC  X(010).*/
        public StringBasis V0PROD_ESTR_COBR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77            V0PROD-ORIG-PRODU   PIC  X(010).*/
        public StringBasis V0PROD_ORIG_PRODU { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77            VIND-TEMCDG         PIC S9(004)    COMP VALUE -1.*/
        public IntBasis VIND_TEMCDG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), -1);
        /*"77            V0PROD-ESTR-COBR-I  PIC S9(004)    COMP.*/
        public IntBasis V0PROD_ESTR_COBR_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0PROD-ORIG-PRODU-I PIC S9(004)    COMP.*/
        public IntBasis V0PROD_ORIG_PRODU_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0CEDE-NOMECED      PIC  X(040).*/
        public StringBasis V0CEDE_NOMECED { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77            V0CEDE-AGENCIA      PIC S9(004)    COMP.*/
        public IntBasis V0CEDE_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0CEDE-OPERACAO     PIC S9(004)    COMP.*/
        public IntBasis V0CEDE_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0CEDE-CONTA        PIC S9(013)    COMP-3.*/
        public IntBasis V0CEDE_CONTA { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77            V0CEDE-DIGCC        PIC S9(004)    COMP.*/
        public IntBasis V0CEDE_DIGCC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0DIFP-NRPARCELDIF  PIC S9(004)    COMP.*/
        public IntBasis V0DIFP_NRPARCELDIF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0DIFP-CODOPER      PIC S9(004)    COMP.*/
        public IntBasis V0DIFP_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0DIFP-DTVENCTO     PIC  X(010).*/
        public StringBasis V0DIFP_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77            V0DIFP-PRMDEV       PIC S9(015)V99 COMP-3.*/
        public DoubleBasis V0DIFP_PRMDEV { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
        /*"77            V0DIFP-PRMPAG       PIC S9(015)V99 COMP-3.*/
        public DoubleBasis V0DIFP_PRMPAG { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
        /*"77            V0DIFP-PRMDIF       PIC S9(015)V99 COMP-3.*/
        public DoubleBasis V0DIFP_PRMDIF { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
        /*"77            V0DIFP-VLMULTA      PIC S9(015)V99 COMP-3.*/
        public DoubleBasis V0DIFP_VLMULTA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V99"), 2);
        /*"77            V0MENS-NUM-APOLICE  PIC S9(013)    COMP-3.*/
        public IntBasis V0MENS_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77            V0MENS-CODSUBES     PIC S9(004)    COMP.*/
        public IntBasis V0MENS_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0MENS-CODOPER      PIC S9(004)    COMP.*/
        public IntBasis V0MENS_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0MENS-JDE          PIC  X(008).*/
        public StringBasis V0MENS_JDE { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77            V0MENS-JDL          PIC  X(008).*/
        public StringBasis V0MENS_JDL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77            V0FAIC-FAIXA        PIC S9(004)    COMP.*/
        public IntBasis V0FAIC_FAIXA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0FAIC-CEPINI       PIC S9(009)    COMP.*/
        public IntBasis V0FAIC_CEPINI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77            V0FAIC-CEPFIM       PIC S9(009)    COMP.*/
        public IntBasis V0FAIC_CEPFIM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77            V0FAIC-DESC-FAIXA   PIC  X(072).*/
        public StringBasis V0FAIC_DESC_FAIXA { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
        /*"77            V0FAIC-CENTRALIZA   PIC  X(072).*/
        public StringBasis V0FAIC_CENTRALIZA { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
        /*"77            V0COBE-IMPMORNATU   PIC S9(013)V99 COMP-3.*/
        public DoubleBasis V0COBE_IMPMORNATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77            V0COBE-VLPREMIO     PIC S9(013)V99 COMP-3.*/
        public DoubleBasis V0COBE_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77            V0COBE-DTINIVIG     PIC  X(010).*/
        public StringBasis V0COBE_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77            V0COBE-IMPSEGCDG    PIC S9(013)V99 COMP-3.*/
        public DoubleBasis V0COBE_IMPSEGCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77            V0PARC-NRCERTIF      PIC S9(015)    COMP-3.*/
        public IntBasis V0PARC_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77            V0PARC-NRPARCEL      PIC S9(004)    COMP.*/
        public IntBasis V0PARC_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0PARC-VLPRMTOT      PIC S9(013)V99 COMP-3.*/
        public DoubleBasis V0PARC_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77            V0PARC-DTVENCTO      PIC  X(010).*/
        public StringBasis V0PARC_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77            V0PARC-DTVENCTO-ORIG PIC  X(010).*/
        public StringBasis V0PARC_DTVENCTO_ORIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77            V0PARC-PRMVG         PIC S9(013)V99 COMP-3.*/
        public DoubleBasis V0PARC_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77            V0PARC-PRMAP         PIC S9(013)V99 COMP-3.*/
        public DoubleBasis V0PARC_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77            V0PARC-VLMULTA       PIC S9(013)V99 COMP-3.*/
        public DoubleBasis V0PARC_VLMULTA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77            V0HIST-NRCERTIF     PIC S9(015)    COMP-3.*/
        public IntBasis V0HIST_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77            V0HIST-OCORHIST     PIC S9(004)    COMP.*/
        public IntBasis V0HIST_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0HIST-NRPARCEL     PIC S9(004)    COMP.*/
        public IntBasis V0HIST_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0HIST-NRTIT        PIC S9(013)    COMP-3.*/
        public IntBasis V0HIST_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77            V0HIST-NRTITCOMP    PIC S9(013)    COMP-3.*/
        public IntBasis V0HIST_NRTITCOMP { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77            V0HIST-DTVENCTO     PIC  X(010).*/
        public StringBasis V0HIST_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77            V0HIST-DTQITBCO     PIC  X(010).*/
        public StringBasis V0HIST_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77            V0HIST-VLPRMTOT     PIC S9(013)V99 COMP-3.*/
        public DoubleBasis V0HIST_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77            V0HIST-CODOPER      PIC S9(004)    COMP.*/
        public IntBasis V0HIST_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0HIST-CODPRODU     PIC S9(004)    COMP.*/
        public IntBasis V0HIST_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0HIST-CDCLIENTE    PIC S9(009)    COMP.*/
        public IntBasis V0HIST_CDCLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77            V0HIST-OPCAOPAG     PIC  X(001).*/
        public StringBasis V0HIST_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77            V0HIST-IDSEXO       PIC  X(001).*/
        public StringBasis V0HIST_IDSEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77            V0HIST-OPCOBERT     PIC  X(001).*/
        public StringBasis V0HIST_OPCOBERT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77            V0HIST-NRAPOLICE    PIC S9(013)    COMP-3.*/
        public IntBasis V0HIST_NRAPOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77            V0HIST-CODSUBES     PIC S9(004)    COMP.*/
        public IntBasis V0HIST_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0HIST-OCOREND      PIC S9(004)    COMP.*/
        public IntBasis V0HIST_OCOREND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0HIST-AGECOBR      PIC S9(004)    COMP.*/
        public IntBasis V0HIST_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0HIST-FONTE        PIC S9(004)    COMP.*/
        public IntBasis V0HIST_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0SUBG-COD-CLIENTE  PIC S9(009)    COMP.*/
        public IntBasis V0SUBG_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77            V0SUBG-OCOREND      PIC S9(004)    COMP.*/
        public IntBasis V0SUBG_OCOREND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0HIST-QTDPARCEL    PIC S9(004)    COMP.*/
        public IntBasis V0HIST_QTDPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0RELA-NRCOPIAS     PIC S9(004)    COMP.*/
        public IntBasis V0RELA_NRCOPIAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0OPCP-PERIPGTO     PIC S9(004)    COMP.*/
        public IntBasis V0OPCP_PERIPGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V0CLIE-NOME-RAZAO   PIC  X(040).*/
        public StringBasis V0CLIE_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77            V0CLIE-CNPJ         PIC S9(015)    COMP-3.*/
        public IntBasis V0CLIE_CNPJ { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77            V0CLIE-NOME-RAZAO-E PIC  X(040).*/
        public StringBasis V0CLIE_NOME_RAZAO_E { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77            V0CLIE-CNPJ-E       PIC S9(015)    COMP-3.*/
        public IntBasis V0CLIE_CNPJ_E { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77            V0ENDE-ENDERECO     PIC  X(072).*/
        public StringBasis V0ENDE_ENDERECO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
        /*"77            V0ENDE-BAIRRO       PIC  X(072).*/
        public StringBasis V0ENDE_BAIRRO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
        /*"77            V0ENDE-CIDADE       PIC  X(072).*/
        public StringBasis V0ENDE_CIDADE { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
        /*"77            V0ENDE-UF           PIC  X(002).*/
        public StringBasis V0ENDE_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"77            V0ENDE-CEP          PIC S9(009)    COMP.*/
        public IntBasis V0ENDE_CEP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77            V0ENDE-ENDERECO-E   PIC  X(040).*/
        public StringBasis V0ENDE_ENDERECO_E { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77            V0ENDE-BAIRRO-E     PIC  X(020).*/
        public StringBasis V0ENDE_BAIRRO_E { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"77            V0ENDE-CIDADE-E     PIC  X(020).*/
        public StringBasis V0ENDE_CIDADE_E { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"77            V0ENDE-UF-E         PIC  X(002).*/
        public StringBasis V0ENDE_UF_E { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"77            V0ENDE-CEP-E        PIC S9(009)    COMP.*/
        public IntBasis V0ENDE_CEP_E { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77            V1MCEF-COD-FONTE    PIC S9(004)    COMP.*/
        public IntBasis V1MCEF_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V1ACEF-COD-AGENCIA  PIC S9(004)    COMP.*/
        public IntBasis V1ACEF_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            V1FONT-NOMEFTE      PIC  X(040).*/
        public StringBasis V1FONT_NOMEFTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77            V1FONT-ENDERFTE     PIC  X(040).*/
        public StringBasis V1FONT_ENDERFTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77            V1FONT-BAIRRO       PIC  X(020).*/
        public StringBasis V1FONT_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"77            V1FONT-CIDADE       PIC  X(020).*/
        public StringBasis V1FONT_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"77            V1FONT-UF           PIC  X(002).*/
        public StringBasis V1FONT_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"77            V1FONT-CEP          PIC S9(009)    COMP.*/
        public IntBasis V1FONT_CEP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77            VIND-COD-PRODUTO    PIC S9(004)    COMP.*/
        public IntBasis VIND_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            WH-DATA-VENCIMENTO  PIC  X(010) VALUE SPACES.*/
        public StringBasis WH_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77            WS-COD-PRODUTO      PIC S9(004) COMP-5 VALUE 0.*/
        public IntBasis WS_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WCOD-PRODUTO-AUX              PIC 9(004)     VALUE ZEROS.*/

        public SelectorBasis WCOD_PRODUTO_AUX { get; set; } = new SelectorBasis("004", "ZEROS")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 PRODUTO-EMPRESARIAL        VALUE 8203 8205 8209 8211 9315                                        9316 9322 9323 9324 9325                                        9326 9329 9343 9365 9706                                        9712 9713 9714 9715                                             7405 7409                                             8529 8543. */
							new SelectorItemBasis("PRODUTO_EMPRESARIAL", "8203 8205 8209 8211 9315 9316 9322 9323 9324 9325 9326 9329 9343 9365 9706 9712 9713 9714 9715 7405 7409 8529 8543")
                }
        };

        /*"01  TAB-MESES-REF.*/
        public VG0267B_TAB_MESES_REF TAB_MESES_REF { get; set; } = new VG0267B_TAB_MESES_REF();
        public class VG0267B_TAB_MESES_REF : VarBasis
        {
            /*"    05 FILLER PIC X(24) VALUE '312831303130313130313031'.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "24", "X(24)"), @"312831303130313130313031");
            /*"01  TAB-MESES-R-REF REDEFINES TAB-MESES-REF.*/
        }
        private _REDEF_VG0267B_TAB_MESES_R_REF _tab_meses_r_ref { get; set; }
        public _REDEF_VG0267B_TAB_MESES_R_REF TAB_MESES_R_REF
        {
            get { _tab_meses_r_ref = new _REDEF_VG0267B_TAB_MESES_R_REF(); _.Move(TAB_MESES_REF, _tab_meses_r_ref); VarBasis.RedefinePassValue(TAB_MESES_REF, _tab_meses_r_ref, TAB_MESES_REF); _tab_meses_r_ref.ValueChanged += () => { _.Move(_tab_meses_r_ref, TAB_MESES_REF); }; return _tab_meses_r_ref; }
            set { VarBasis.RedefinePassValue(value, _tab_meses_r_ref, TAB_MESES_REF); }
        }  //Redefines
        public class _REDEF_VG0267B_TAB_MESES_R_REF : VarBasis
        {
            /*"    05 TAB-ULT-DIAS OCCURS 12.*/
            public ListBasis<VG0267B_TAB_ULT_DIAS> TAB_ULT_DIAS { get; set; } = new ListBasis<VG0267B_TAB_ULT_DIAS>(12);
            public class VG0267B_TAB_ULT_DIAS : VarBasis
            {
                /*"       10 TAB-ULT-DIA-MES PIC 9(2).*/
                public IntBasis TAB_ULT_DIA_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(2)."));
                /*"01  WS-FORM-LINHA                    PIC  X(023) VALUE SPACES.*/

                public VG0267B_TAB_ULT_DIAS()
                {
                    TAB_ULT_DIA_MES.ValueChanged += OnValueChanged;
                }

            }

            public _REDEF_VG0267B_TAB_MESES_R_REF()
            {
                TAB_ULT_DIAS.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_FORM_LINHA { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"");
        /*"01  AREA-DE-WORK.*/
        public VG0267B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VG0267B_AREA_DE_WORK();
        public class VG0267B_AREA_DE_WORK : VarBasis
        {
            /*"    05          WS-SIT-PRODUTO       PIC  9(001)  VALUE 0.*/

            public SelectorBasis WS_SIT_PRODUTO { get; set; } = new SelectorBasis("001", "0")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88        WS-PROD-RUNON                     VALUE 1. */
							new SelectorItemBasis("WS_PROD_RUNON", "1"),
							/*" 88        WS-PROD-RUNOFF                    VALUE 2. */
							new SelectorItemBasis("WS_PROD_RUNOFF", "2")
                }
            };

            /*"    05            LC01-LINHA01.*/
            public VG0267B_LC01_LINHA01 LC01_LINHA01 { get; set; } = new VG0267B_LC01_LINHA01();
            public class VG0267B_LC01_LINHA01 : VarBasis
            {
                /*"      10          FILLER               PIC X(002) VALUE '%!'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"%!");
                /*"    05            LC02-LINHA02.*/
            }
            public VG0267B_LC02_LINHA02 LC02_LINHA02 { get; set; } = new VG0267B_LC02_LINHA02();
            public class VG0267B_LC02_LINHA02 : VarBasis
            {
                /*"      10          LC02-FILLER          PIC X(070) VALUE    '%%DocumentMedia: papel1 595 842 75 white normal'.*/
                public StringBasis LC02_FILLER { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"%%DocumentMedia: papel1 595 842 75 white normal");
                /*"    05            LC03-LINHA03.*/
            }
            public VG0267B_LC03_LINHA03 LC03_LINHA03 { get; set; } = new VG0267B_LC03_LINHA03();
            public class VG0267B_LC03_LINHA03 : VarBasis
            {
                /*"      10          LC03-FILLER          PIC X(070) VALUE    '%%+papel2 595 842 75 blue azul'.*/
                public StringBasis LC03_FILLER { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"%%+papel2 595 842 75 blue azul");
                /*"    05            LC04-LINHA04.*/
            }
            public VG0267B_LC04_LINHA04 LC04_LINHA04 { get; set; } = new VG0267B_LC04_LINHA04();
            public class VG0267B_LC04_LINHA04 : VarBasis
            {
                /*"      10          LC04-FILLER          PIC X(070) VALUE    '%%XRXrequeriments: duplex'.*/
                public StringBasis LC04_FILLER { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"%%XRXrequeriments: duplex");
                /*"    05            LC04-LINHA04-01.*/
            }
            public VG0267B_LC04_LINHA04_01 LC04_LINHA04_01 { get; set; } = new VG0267B_LC04_LINHA04_01();
            public class VG0267B_LC04_LINHA04_01 : VarBasis
            {
                /*"      10          LC04-FILLER-01       PIC X(070) VALUE    '%%XRXrequeriments: simplex'.*/
                public StringBasis LC04_FILLER_01 { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"%%XRXrequeriments: simplex");
                /*"    05            LC05-LINHA05.*/
            }
            public VG0267B_LC05_LINHA05 LC05_LINHA05 { get; set; } = new VG0267B_LC05_LINHA05();
            public class VG0267B_LC05_LINHA05 : VarBasis
            {
                /*"      10          LC05-FILLER          PIC X(070) VALUE    '%%BeginFeature: *Duplex True'.*/
                public StringBasis LC05_FILLER { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"%%BeginFeature: *Duplex True");
                /*"    05            LC05-LINHA05-01.*/
            }
            public VG0267B_LC05_LINHA05_01 LC05_LINHA05_01 { get; set; } = new VG0267B_LC05_LINHA05_01();
            public class VG0267B_LC05_LINHA05_01 : VarBasis
            {
                /*"      10          LC05-FILLER-01       PIC X(070) VALUE    '%%BeginFeature: *Simplex True'.*/
                public StringBasis LC05_FILLER_01 { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"%%BeginFeature: *Simplex True");
                /*"    05            LC06-LINHA06.*/
            }
            public VG0267B_LC06_LINHA06 LC06_LINHA06 { get; set; } = new VG0267B_LC06_LINHA06();
            public class VG0267B_LC06_LINHA06 : VarBasis
            {
                /*"      10          LC06-FILLER          PIC X(070) VALUE    '<</Duplex true>> setpagedevice'.*/
                public StringBasis LC06_FILLER { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"<</Duplex true>> setpagedevice");
                /*"    05            LC06-LINHA06-01.*/
            }
            public VG0267B_LC06_LINHA06_01 LC06_LINHA06_01 { get; set; } = new VG0267B_LC06_LINHA06_01();
            public class VG0267B_LC06_LINHA06_01 : VarBasis
            {
                /*"      10          LC06-FILLER-01       PIC X(070) VALUE    '<</Simplex true>> setpagedevice'.*/
                public StringBasis LC06_FILLER_01 { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"<</Simplex true>> setpagedevice");
                /*"    05            LC07-LINHA07.*/
            }
            public VG0267B_LC07_LINHA07 LC07_LINHA07 { get; set; } = new VG0267B_LC07_LINHA07();
            public class VG0267B_LC07_LINHA07 : VarBasis
            {
                /*"      10          LC07-FILLER          PIC X(070) VALUE    '%%EndFeature'.*/
                public StringBasis LC07_FILLER { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"%%EndFeature");
                /*"    05            LC08-LINHA08.*/
            }
            public VG0267B_LC08_LINHA08 LC08_LINHA08 { get; set; } = new VG0267B_LC08_LINHA08();
            public class VG0267B_LC08_LINHA08 : VarBasis
            {
                /*"      10          LC08-FILLER          PIC X(070) VALUE    '(|) SETDBSEP'.*/
                public StringBasis LC08_FILLER { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"(|) SETDBSEP");
                /*"    05            LC09-LINHA09.*/
            }
            public VG0267B_LC09_LINHA09 LC09_LINHA09 { get; set; } = new VG0267B_LC09_LINHA09();
            public class VG0267B_LC09_LINHA09 : VarBasis
            {
                /*"      10          FILLER               PIC X(001) VALUE '('.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"(");
                /*"      10          LC09-FORM.*/
                public VG0267B_LC09_FORM LC09_FORM { get; set; } = new VG0267B_LC09_FORM();
                public class VG0267B_LC09_FORM : VarBasis
                {
                    /*"        15        LC09-JDE             PIC X(008).*/
                    public StringBasis LC09_JDE { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                    /*"        15        FILLER               PIC X(001) VALUE '.'.*/
                    public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                    /*"        15        FILLER               PIC X(003) VALUE 'DBM'.*/
                    public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"DBM");
                    /*"      10          FILLER               PIC X(002) VALUE ')'.*/
                }
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @")");
                /*"      10          FILLER               PIC X(008) VALUE                                                      'STARTDBM'*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"STARTDBM");
                /*"    05            FILLER     REDEFINES LC09-LINHA09.*/
            }
            private _REDEF_VG0267B_FILLER_7 _filler_7 { get; set; }
            public _REDEF_VG0267B_FILLER_7 FILLER_7
            {
                get { _filler_7 = new _REDEF_VG0267B_FILLER_7(); _.Move(LC09_LINHA09, _filler_7); VarBasis.RedefinePassValue(LC09_LINHA09, _filler_7, LC09_LINHA09); _filler_7.ValueChanged += () => { _.Move(_filler_7, LC09_LINHA09); }; return _filler_7; }
                set { VarBasis.RedefinePassValue(value, _filler_7, LC09_LINHA09); }
            }  //Redefines
            public class _REDEF_VG0267B_FILLER_7 : VarBasis
            {
                /*"      10          LC09-LIN09           PIC X(023).*/
                public StringBasis LC09_LIN09 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)."), @"");
                /*"    05            LC10-LINHA10.*/

                public _REDEF_VG0267B_FILLER_7()
                {
                    LC09_LIN09.ValueChanged += OnValueChanged;
                }

            }
            public VG0267B_LC10_LINHA10 LC10_LINHA10 { get; set; } = new VG0267B_LC10_LINHA10();
            public class VG0267B_LC10_LINHA10 : VarBasis
            {
                /*"       10         FILLER              PIC X(008) VALUE      'PRODUTO|'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"PRODUTO|");
                /*"       10         FILLER              PIC X(051) VALUE      'AGENCIA|APOLICE|ENDOSSO|FATURA|PERIODO|EMISSAO|VENC'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"AGENCIA|APOLICE|ENDOSSO|FATURA|PERIODO|EMISSAO|VENC");
                /*"       10         FILLER              PIC X(051) VALUE      'IMENT|ESTIPULANTE|ENDERE1|CEP1|CIDADE1|EST1|CNPJ1|S'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"IMENT|ESTIPULANTE|ENDERE1|CEP1|CIDADE1|EST1|CNPJ1|S");
                /*"       10         FILLER              PIC X(036) VALUE      'UBESTIPULANTE|ENDERE2|CEP2|CIDADE2|E'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"UBESTIPULANTE|ENDERE2|CEP2|CIDADE2|E");
                /*"       10         FILLER              PIC X(051) VALUE      'ST2|CNPJ2|NVIDAS|CAPITAL|IOF|PREMIO|TEXTO|CODDOC|CO'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"ST2|CNPJ2|NVIDAS|CAPITAL|IOF|PREMIO|TEXTO|CODDOC|CO");
                /*"       10         FILLER              PIC X(051) VALUE      'DCEDENTE|DATAVENC|PARCELA|VALOR|NUMCDBARRA|DTVENCTO'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"DCEDENTE|DATAVENC|PARCELA|VALOR|NUMCDBARRA|DTVENCTO");
                /*"       10         FILLER              PIC X(051) VALUE      '|NCEDENTE|CEDENTE|DTDOCTO|NUMDOCTO|DTPROCESS|NSNUME'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"|NCEDENTE|CEDENTE|DTDOCTO|NUMDOCTO|DTPROCESS|NSNUME");
                /*"       10         FILLER              PIC X(051) VALUE      'RO|VALDOCTO|MENSA1|MENSA2|MENSA3|MENSA4|MENSA5|MENS'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"RO|VALDOCTO|MENSA1|MENSA2|MENSA3|MENSA4|MENSA5|MENS");
                /*"       10         FILLER              PIC X(051) VALUE      'A6|MENSA7|VALCOBRADO|CODBARRA|SUBSCRITOR|CGCCPFSUB|'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"A6|MENSA7|VALCOBRADO|CODBARRA|SUBSCRITOR|CGCCPFSUB|");
                /*"       10         FILLER              PIC X(019) VALUE      'DTPOSTAGEM|NUMOBJET'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"DTPOSTAGEM|NUMOBJET");
                /*"       10         FILLER              PIC X(051) VALUE      'O|DESTINATARIO|ENDERECO|BAIRRO|CIDADE|UF|CEP|REMETE'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"O|DESTINATARIO|ENDERECO|BAIRRO|CIDADE|UF|CEP|REMETE");
                /*"       10         FILLER              PIC X(051) VALUE      'NTE|REMET-ENDERECO|REMET-BAIRRO|REMET-CIDADE|REMET-'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"NTE|REMET_ENDERECO|REMET_BAIRRO|REMET_CIDADE|REMET_");
                /*"       10         FILLER              PIC X(051) VALUE      'UF|REMET-CEP|CODIGO-CIF|POSTNET                    '.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"UF|REMET_CEP|CODIGO_CIF|POSTNET                    ");
                /*"    05            LC11-LINHA11.*/
            }
            public VG0267B_LC11_LINHA11 LC11_LINHA11 { get; set; } = new VG0267B_LC11_LINHA11();
            public class VG0267B_LC11_LINHA11 : VarBasis
            {
                /*"       10         LC11-PRODUTO        PIC 9999.*/
                public IntBasis LC11_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-AGENCIA        PIC 9999.*/
                public IntBasis LC11_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-APOLICE        PIC ZZZZZZZZZZZZZ.*/
                public StringBasis LC11_APOLICE { get; set; } = new StringBasis(new PIC("X", "0", "ZZZZZZZZZZZZZ."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-ENDOSSO        PIC X(009) VALUE '*-*-*-*'*/
                public StringBasis LC11_ENDOSSO { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"*-*-*-*");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-FATURA-SEC     PIC 9(004).*/
                public IntBasis LC11_FATURA_SEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10         LC11-FATURA-MES     PIC 9(002).*/
                public IntBasis LC11_FATURA_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-PERIODO-1-DD   PIC 9(002).*/
                public IntBasis LC11_PERIODO_1_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10         FILLER              PIC X(001) VALUE '/'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"       10         LC11-PERIODO-1-MM   PIC 9(002).*/
                public IntBasis LC11_PERIODO_1_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10         FILLER              PIC X(001) VALUE '/'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"       10         LC11-PERIODO-1-AA   PIC 9(004).*/
                public IntBasis LC11_PERIODO_1_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10         FILLER              PIC X(003) VALUE ' A '.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" A ");
                /*"       10         LC11-PERIODO-2-DD   PIC 9(002).*/
                public IntBasis LC11_PERIODO_2_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10         FILLER              PIC X(001) VALUE '/'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"       10         LC11-PERIODO-2-MM   PIC 9(002).*/
                public IntBasis LC11_PERIODO_2_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10         FILLER              PIC X(001) VALUE '/'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"       10         LC11-PERIODO-2-AA   PIC 9(004).*/
                public IntBasis LC11_PERIODO_2_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-DTEMISSAO      PIC X(010).*/
                public StringBasis LC11_DTEMISSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-DTVENCTO       PIC X(010).*/
                public StringBasis LC11_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-NOME-RAZAO-EST PIC X(040).*/
                public StringBasis LC11_NOME_RAZAO_EST { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-ENDERECO-EST   PIC X(040).*/
                public StringBasis LC11_ENDERECO_EST { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-CEP1-EST       PIC 9(005).*/
                public IntBasis LC11_CEP1_EST { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"       10         FILLER              PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"       10         LC11-CEP2-EST       PIC 9(003).*/
                public IntBasis LC11_CEP2_EST { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-CIDADE-EST     PIC X(020).*/
                public StringBasis LC11_CIDADE_EST { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-UF-EST         PIC X(002).*/
                public StringBasis LC11_UF_EST { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-CNPJ1-EST      PIC 999.999.999.*/
                public IntBasis LC11_CNPJ1_EST { get; set; } = new IntBasis(new PIC("9", "9", "999.999.999."));
                /*"       10         FILLER              PIC X(001) VALUE '/'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"       10         LC11-CNPJ2-EST      PIC 9(004).*/
                public IntBasis LC11_CNPJ2_EST { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10         FILLER              PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"       10         LC11-CNPJ3-EST      PIC 9(002).*/
                public IntBasis LC11_CNPJ3_EST { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-CODSUBES       PIC Z9999.*/
                public IntBasis LC11_CODSUBES { get; set; } = new IntBasis(new PIC("9", "5", "Z9999."));
                /*"       10         FILLER              PIC X(003) VALUE ' - '.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" - ");
                /*"       10         LC02-NOME-RAZAO     PIC X(032).*/
                public StringBasis LC02_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "32", "X(032)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-ENDERECO-SUB   PIC X(040).*/
                public StringBasis LC11_ENDERECO_SUB { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-CEP1-SUB       PIC 9(005).*/
                public IntBasis LC11_CEP1_SUB { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"       10         FILLER              PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"       10         LC11-CEP2-SUB       PIC 9(003).*/
                public IntBasis LC11_CEP2_SUB { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-CIDADE-SUB     PIC X(020).*/
                public StringBasis LC11_CIDADE_SUB { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-UF-SUB         PIC X(002).*/
                public StringBasis LC11_UF_SUB { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC02-NRCNPJ1        PIC 999.999.999.*/
                public IntBasis LC02_NRCNPJ1 { get; set; } = new IntBasis(new PIC("9", "9", "999.999.999."));
                /*"       10         FILLER              PIC X(001) VALUE '/'.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"       10         LC02-NRCNPJ2        PIC 9(004).*/
                public IntBasis LC02_NRCNPJ2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10         FILLER              PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"       10         LC02-DVCNPJ         PIC 9(002).*/
                public IntBasis LC02_DVCNPJ { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-NVIDAS         PIC ZZZ.ZZZ.*/
                public StringBasis LC11_NVIDAS { get; set; } = new StringBasis(new PIC("X", "0", "ZZZ.ZZZ."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-CAPITAL        PIC ZZZ.ZZZ.ZZZ.ZZZ,ZZ.*/
                public StringBasis LC11_CAPITAL { get; set; } = new StringBasis(new PIC("X", "0", "ZZZ.ZZZ.ZZZ.ZZZVZZ."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-IOF            PIC Z.ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LC11_IOF { get; set; } = new DoubleBasis(new PIC("9", "10", "Z.ZZZ.ZZZ.ZZ9V99."), 2);
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-VLPRMTOT       PIC Z.ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LC11_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("9", "10", "Z.ZZZ.ZZZ.ZZ9V99."), 2);
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-TEXTO          PIC X(002) VALUE '  '.*/
                public StringBasis LC11_TEXTO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"  ");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC03-NRTIT          PIC ZZZZZZZZZZZZZZZ99.*/
                public IntBasis LC03_NRTIT { get; set; } = new IntBasis(new PIC("9", "17", "ZZZZZZZZZZZZZZZ99."));
                /*"       10         FILLER              PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"       10         LC03-DVTITULO       PIC 9(001).*/
                public IntBasis LC03_DVTITULO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC03-COD-CEDENTE    PIC X(020) VALUE SPACES.*/
                public StringBasis LC03_COD_CEDENTE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC03-DTVENCTO       PIC X(010).*/
                public StringBasis LC03_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC03-NRPARCEL       PIC ZZ99.*/
                public IntBasis LC03_NRPARCEL { get; set; } = new IntBasis(new PIC("9", "4", "ZZ99."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC03-VLPRMTOT       PIC Z.ZZZ.ZZ9,99.*/
                public DoubleBasis LC03_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("9", "7", "Z.ZZZ.ZZ9V99."), 2);
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC06-LIN-DIGITAVEL  PIC X(054)    VALUE SPACES*/
                public StringBasis LC06_LIN_DIGITAVEL { get; set; } = new StringBasis(new PIC("X", "54", "X(054)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC07-DTVENCTO       PIC X(010).*/
                public StringBasis LC07_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC08-NOMECED        PIC X(040).*/
                public StringBasis LC08_NOMECED { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC08-COD-CEDENTE    PIC X(020) VALUE SPACES.*/
                public StringBasis LC08_COD_CEDENTE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC09-DTEMISSAO      PIC X(010).*/
                public StringBasis LC09_DTEMISSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC09-NRTIT          PIC ZZZZZZZ9999999999.*/
                public IntBasis LC09_NRTIT { get; set; } = new IntBasis(new PIC("9", "17", "ZZZZZZZ9999999999."));
                /*"       10         FILLER              PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"       10         LC09-DVTITULO       PIC 9(001).*/
                public IntBasis LC09_DVTITULO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC09-DTPROCES       PIC X(010).*/
                public StringBasis LC09_DTPROCES { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC09-NRTIT1         PIC ZZZZZZZ9999999999.*/
                public IntBasis LC09_NRTIT1 { get; set; } = new IntBasis(new PIC("9", "17", "ZZZZZZZ9999999999."));
                /*"       10         FILLER              PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"       10         LC09-DVTITULO1      PIC 9(001).*/
                public IntBasis LC09_DVTITULO1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC10-VLPRMTOT       PIC Z.ZZZ.ZZ9,99.*/
                public DoubleBasis LC10_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("9", "7", "Z.ZZZ.ZZ9V99."), 2);
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         MENSA1              PIC X(009) VALUE                                      'APOLICE: '.*/
                public StringBasis MENSA1 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"APOLICE: ");
                /*"       10         LC11-NUM-APOLICE    PIC 9(013).*/
                public IntBasis LC11_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"       10         FILLER              PIC X(011) VALUE                                      ' SUBGRUPO: '.*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @" SUBGRUPO: ");
                /*"       10         LC11-COD-SUBGRUPO   PIC Z9999.*/
                public IntBasis LC11_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "5", "Z9999."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         MENSA2              PIC X(001) VALUE ' '.*/
                public StringBasis MENSA2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         MENSA3              PIC X(013) VALUE                                      'CERTIFICADO: '.*/
                public StringBasis MENSA3 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"CERTIFICADO: ");
                /*"       10         LC13-NRCERTIF       PIC ZZZZZZZZZZZZ99.*/
                public IntBasis LC13_NRCERTIF { get; set; } = new IntBasis(new PIC("9", "14", "ZZZZZZZZZZZZ99."));
                /*"       10         LC13-DVCERTIF       PIC 9(001).*/
                public IntBasis LC13_DVCERTIF { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"       10         FILLER              PIC X(010) VALUE                                      ' PARCELA: '.*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" PARCELA: ");
                /*"       10         LC13-NRPARCEL       PIC ZZ99.*/
                public IntBasis LC13_NRPARCEL { get; set; } = new IntBasis(new PIC("9", "4", "ZZ99."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         MENSA4              PIC X(001) VALUE ' '.*/
                public StringBasis MENSA4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         MENSA5              PIC X(001) VALUE ' '.*/
                public StringBasis MENSA5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         MENSA6              PIC X(001) VALUE ' '.*/
                public StringBasis MENSA6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         MENSA7              PIC X(001) VALUE ' '.*/
                public StringBasis MENSA7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-VALCOBRADO     PIC X(001) VALUE ' '.*/
                public StringBasis LC11_VALCOBRADO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC16-CDBARRA        PIC X(112).*/
                public StringBasis LC16_CDBARRA { get; set; } = new StringBasis(new PIC("X", "112", "X(112)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC14-NOME-RAZAO     PIC X(040).*/
                public StringBasis LC14_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC14-NRCNPJ1        PIC 999.999.999.*/
                public IntBasis LC14_NRCNPJ1 { get; set; } = new IntBasis(new PIC("9", "9", "999.999.999."));
                /*"       10         FILLER              PIC X(001) VALUE '/'.*/
                public StringBasis FILLER_87 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"       10         LC14-NRCNPJ2        PIC 9999.*/
                public IntBasis LC14_NRCNPJ2 { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
                /*"       10         FILLER              PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"       10         LC14-DVCNPJ         PIC 99.*/
                public IntBasis LC14_DVCNPJ { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LE01-DTPOSTAGEM     PIC X(010).*/
                public StringBasis LE01_DTPOSTAGEM { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_90 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LE01-SEQUENCIA      PIC X(007).*/
                public StringBasis LE01_SEQUENCIA { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_91 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LE02-NOME-RAZAO     PIC X(040).*/
                public StringBasis LE02_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_92 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LE03-ENDERECO       PIC X(072).*/
                public StringBasis LE03_ENDERECO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_93 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LE04-BAIRRO         PIC X(072).*/
                public StringBasis LE04_BAIRRO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_94 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LE04-CIDADE         PIC X(072).*/
                public StringBasis LE04_CIDADE { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_95 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LE04-UF             PIC X(002).*/
                public StringBasis LE04_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_96 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LE05-CEP            PIC 99999.*/
                public IntBasis LE05_CEP { get; set; } = new IntBasis(new PIC("9", "5", "99999."));
                /*"       10         FILLER              PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_97 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"       10         LE05-CEP-COMPL      PIC 999.*/
                public IntBasis LE05_CEP_COMPL { get; set; } = new IntBasis(new PIC("9", "3", "999."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_98 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         FILLER              PIC X(014) VALUE                 'CAIXA SEGUROS '.*/
                public StringBasis FILLER_99 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"CAIXA SEGUROS ");
                /*"       10         LE06-REMETENTE-G.*/
                public VG0267B_LE06_REMETENTE_G LE06_REMETENTE_G { get; set; } = new VG0267B_LE06_REMETENTE_G();
                public class VG0267B_LE06_REMETENTE_G : VarBasis
                {
                    /*"         15       LE06-REMETENTE-S    PIC X(007).*/
                    public StringBasis LE06_REMETENTE_S { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
                    /*"         15       LE06-REMETENTE      PIC X(024).*/
                    public StringBasis LE06_REMETENTE { get; set; } = new StringBasis(new PIC("X", "24", "X(024)."), @"");
                    /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                }
                public StringBasis FILLER_100 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LE07-ENDERECO       PIC X(040).*/
                public StringBasis LE07_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_101 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LE08-BAIRRO         PIC X(020).*/
                public StringBasis LE08_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_102 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LE08-CIDADE         PIC X(020).*/
                public StringBasis LE08_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_103 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LE08-UF             PIC X(002).*/
                public StringBasis LE08_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_104 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LE09-CEP            PIC 99999.*/
                public IntBasis LE09_CEP { get; set; } = new IntBasis(new PIC("9", "5", "99999."));
                /*"       10         FILLER              PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_105 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"       10         LE09-CEP-COMPL      PIC 999.*/
                public IntBasis LE09_CEP_COMPL { get; set; } = new IntBasis(new PIC("9", "3", "999."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_106 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LE09-CIF            PIC X(034) VALUE ALL '@'.*/
                public StringBasis LE09_CIF { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"ALL");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_107 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LE09-POSTNET        PIC X(011) VALUE ALL '#'.*/
                public StringBasis LE09_POSTNET { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"ALL");
                /*"    05            LC12-LINHA12.*/
            }
            public VG0267B_LC12_LINHA12 LC12_LINHA12 { get; set; } = new VG0267B_LC12_LINHA12();
            public class VG0267B_LC12_LINHA12 : VarBasis
            {
                /*"      10          LC12-FILLER          PIC X(070) VALUE    '%%EOF'.*/
                public StringBasis LC12_FILLER { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"%%EOF");
                /*"    05            LF01-LINHA01.*/
            }
            public VG0267B_LF01_LINHA01 LF01_LINHA01 { get; set; } = new VG0267B_LF01_LINHA01();
            public class VG0267B_LF01_LINHA01 : VarBasis
            {
                /*"      10          FILLER              PIC X(055) VALUE     '<</MediaColor (blue) /MediaWeight 75/MediaType(azul)>>'.*/
                public StringBasis FILLER_108 { get; set; } = new StringBasis(new PIC("X", "55", "X(055)"), @"<</MediaColor (blue) /MediaWeight 75/MediaType(azul)>>");
                /*"      10          FILLER              PIC X(080) VALUE     'setpagedevice'.*/
                public StringBasis FILLER_109 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"setpagedevice");
                /*"    05            LF02-LINHA02.*/
            }
            public VG0267B_LF02_LINHA02 LF02_LINHA02 { get; set; } = new VG0267B_LF02_LINHA02();
            public class VG0267B_LF02_LINHA02 : VarBasis
            {
                /*"      10          FILLER               PIC X(001) VALUE '('.*/
                public StringBasis FILLER_110 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"(");
                /*"      10          LF02-FORM.*/
                public VG0267B_LF02_FORM LF02_FORM { get; set; } = new VG0267B_LF02_FORM();
                public class VG0267B_LF02_FORM : VarBasis
                {
                    /*"        15        LF02-JDE             PIC X(004).*/
                    public StringBasis LF02_JDE { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                    /*"        15        FILLER               PIC X(001) VALUE '.'.*/
                    public StringBasis FILLER_111 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                    /*"        15        FILLER               PIC X(003) VALUE 'DBM'.*/
                    public StringBasis FILLER_112 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"DBM");
                    /*"      10          FILLER               PIC X(002) VALUE ')'.*/
                }
                public StringBasis FILLER_113 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @")");
                /*"      10          FILLER               PIC X(008) VALUE                                                      'STARTDBM'*/
                public StringBasis FILLER_114 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"STARTDBM");
                /*"    05            LF03-LINHA03.*/
            }
            public VG0267B_LF03_LINHA03 LF03_LINHA03 { get; set; } = new VG0267B_LF03_LINHA03();
            public class VG0267B_LF03_LINHA03 : VarBasis
            {
                /*"      10          FILLER               PIC X(070) VALUE     'LOCALIDADE|FAIXA|OBJETOS|AMARRADO|SEQUENCIA'.*/
                public StringBasis FILLER_115 { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"LOCALIDADE|FAIXA|OBJETOS|AMARRADO|SEQUENCIA");
                /*"    05            LF04-LINHA04.*/
            }
            public VG0267B_LF04_LINHA04 LF04_LINHA04 { get; set; } = new VG0267B_LF04_LINHA04();
            public class VG0267B_LF04_LINHA04 : VarBasis
            {
                /*"      10          LF02-NOME-FAIXA     PIC X(072).*/
                public StringBasis LF02_NOME_FAIXA { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                /*"      10          FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_116 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"      10          LF03-FAIXA1         PIC X(005).*/
                public StringBasis LF03_FAIXA1 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                /*"      10          FILLER              PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_117 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10          LF03-FAIXA1C        PIC X(003).*/
                public StringBasis LF03_FAIXA1C { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"      10          FILLER              PIC X(005) VALUE '  A '.*/
                public StringBasis FILLER_118 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"  A ");
                /*"      10          LF03-FAIXA2         PIC X(005).*/
                public StringBasis LF03_FAIXA2 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                /*"      10          FILLER              PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_119 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10          LF03-FAIXA2C        PIC X(003).*/
                public StringBasis LF03_FAIXA2C { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"      10          FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_120 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"      10          LF04-QTD-OBJ        PIC 9(003).*/
                public IntBasis LF04_QTD_OBJ { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"      10          FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_121 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"      10          LF05-AMARRADO       PIC ZZZ.999.*/
                public IntBasis LF05_AMARRADO { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10          FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_122 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"      10          LF05-SEQ-INICIAL    PIC ZZZ.999.*/
                public IntBasis LF05_SEQ_INICIAL { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10          FILLER              PIC X(001) VALUE '/'.*/
                public StringBasis FILLER_123 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10          LF05-SEQ-FINAL      PIC ZZZ.999.*/
                public IntBasis LF05_SEQ_FINAL { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"    05            LR01-LINHA01.*/
            }
            public VG0267B_LR01_LINHA01 LR01_LINHA01 { get; set; } = new VG0267B_LR01_LINHA01();
            public class VG0267B_LR01_LINHA01 : VarBasis
            {
                /*"      10          FILLER               PIC X(001) VALUE '1'.*/
                public StringBasis FILLER_124 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"    05            LR02-LINHA02.*/
            }
            public VG0267B_LR02_LINHA02 LR02_LINHA02 { get; set; } = new VG0267B_LR02_LINHA02();
            public class VG0267B_LR02_LINHA02 : VarBasis
            {
                /*"      10          FILLER               PIC X(001) VALUE '('.*/
                public StringBasis FILLER_125 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"(");
                /*"      10          LR02-FORM.*/
                public VG0267B_LR02_FORM LR02_FORM { get; set; } = new VG0267B_LR02_FORM();
                public class VG0267B_LR02_FORM : VarBasis
                {
                    /*"        15        LR02-JDE             PIC X(004) VALUE 'CO05'.*/
                    public StringBasis LR02_JDE { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"CO05");
                    /*"        15        FILLER               PIC X(001) VALUE '.'.*/
                    public StringBasis FILLER_126 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                    /*"        15        FILLER               PIC X(003) VALUE 'JDT'.*/
                    public StringBasis FILLER_127 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"JDT");
                    /*"      10          FILLER               PIC X(002) VALUE ')'.*/
                }
                public StringBasis FILLER_128 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @")");
                /*"      10          FILLER               PIC X(008) VALUE     'STARTLM'.*/
                public StringBasis FILLER_129 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"STARTLM");
                /*"    05            LR03-LINHA03.*/
            }
            public VG0267B_LR03_LINHA03 LR03_LINHA03 { get; set; } = new VG0267B_LR03_LINHA03();
            public class VG0267B_LR03_LINHA03 : VarBasis
            {
                /*"      10          LR03-CONTRATO-ECT    PIC X(030) VALUE     '     100134700-5'.*/
                public StringBasis LR03_CONTRATO_ECT { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"     100134700-5");
                /*"    05            LR04-LINHA04.*/
            }
            public VG0267B_LR04_LINHA04 LR04_LINHA04 { get; set; } = new VG0267B_LR04_LINHA04();
            public class VG0267B_LR04_LINHA04 : VarBasis
            {
                /*"      10          LR04-USUARIO         PIC X(030) VALUE     '     CAIXA SEGUROS'.*/
                public StringBasis LR04_USUARIO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"     CAIXA SEGUROS");
                /*"    05            LR05-LINHA05.*/
            }
            public VG0267B_LR05_LINHA05 LR05_LINHA05 { get; set; } = new VG0267B_LR05_LINHA05();
            public class VG0267B_LR05_LINHA05 : VarBasis
            {
                /*"      10          LR05-ENDERECO        PIC X(070) VALUE     '     SCN Q1 BLOCO A - ED. NUMBER ONE - 13 ANDAR'.*/
                public StringBasis LR05_ENDERECO { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"     SCN Q1 BLOCO A - ED. NUMBER ONE - 13 ANDAR");
                /*"    05            LR06-LINHA06.*/
            }
            public VG0267B_LR06_LINHA06 LR06_LINHA06 { get; set; } = new VG0267B_LR06_LINHA06();
            public class VG0267B_LR06_LINHA06 : VarBasis
            {
                /*"      10          LR06-UNID-POSTAGEM   PIC X(030) VALUE     '     DR/BSB/BSA'.*/
                public StringBasis LR06_UNID_POSTAGEM { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"     DR/BSB/BSA");
                /*"    05            LR07-LINHA07.*/
            }
            public VG0267B_LR07_LINHA07 LR07_LINHA07 { get; set; } = new VG0267B_LR07_LINHA07();
            public class VG0267B_LR07_LINHA07 : VarBasis
            {
                /*"      10          FILLER               PIC X(005) VALUE SPACES.*/
                public StringBasis FILLER_130 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"      10          LR02-SEQ             PIC ZZ.ZZ9.*/
                public IntBasis LR02_SEQ { get; set; } = new IntBasis(new PIC("9", "5", "ZZ.ZZ9."));
                /*"      10          FILLER               PIC X(001) VALUE '/'.*/
                public StringBasis FILLER_131 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10          LR02-MES             PIC X(012).*/
                public StringBasis LR02_MES { get; set; } = new StringBasis(new PIC("X", "12", "X(012)."), @"");
                /*"    05            LR08-LINHA08.*/
            }
            public VG0267B_LR08_LINHA08 LR08_LINHA08 { get; set; } = new VG0267B_LR08_LINHA08();
            public class VG0267B_LR08_LINHA08 : VarBasis
            {
                /*"      10          FILLER               PIC X(005) VALUE SPACES.*/
                public StringBasis FILLER_132 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"      10          LR08-TIPO.*/
                public VG0267B_LR08_TIPO LR08_TIPO { get; set; } = new VG0267B_LR08_TIPO();
                public class VG0267B_LR08_TIPO : VarBasis
                {
                    /*"        15        LR08-COD-PRODUTO     PIC 9(004).*/
                    public IntBasis LR08_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"        15        FILLER               PIC X(001) VALUE '-'.*/
                    public StringBasis FILLER_133 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                    /*"        15        LR08-NOME-PRODUTO    PIC X(030).*/
                    public StringBasis LR08_NOME_PRODUTO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                    /*"    05            LR09-LINHA09.*/
                }
            }
            public VG0267B_LR09_LINHA09 LR09_LINHA09 { get; set; } = new VG0267B_LR09_LINHA09();
            public class VG0267B_LR09_LINHA09 : VarBasis
            {
                /*"      10          FILLER               PIC X(005) VALUE SPACES.*/
                public StringBasis FILLER_134 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"      10          LR04-DATA            PIC X(010).*/
                public StringBasis LR04_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    05            LR10-LINHA10-A.*/
            }
            public VG0267B_LR10_LINHA10_A LR10_LINHA10_A { get; set; } = new VG0267B_LR10_LINHA10_A();
            public class VG0267B_LR10_LINHA10_A : VarBasis
            {
                /*"      10          FILLER               PIC X(005) VALUE SPACES.*/
                public StringBasis FILLER_135 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"      10          LR10-NUCLEO          PIC X(030) VALUE                 'BRASILIA(DF)'.*/
                public StringBasis LR10_NUCLEO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"BRASILIA(DF)");
                /*"    05            LR10-LINHA10.*/
            }
            public VG0267B_LR10_LINHA10 LR10_LINHA10 { get; set; } = new VG0267B_LR10_LINHA10();
            public class VG0267B_LR10_LINHA10 : VarBasis
            {
                /*"      10          FILLER               PIC X(005) VALUE SPACES.*/
                public StringBasis FILLER_136 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"      10          LR02-PAGINA          PIC 9(003).*/
                public IntBasis LR02_PAGINA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"      10          FILLER               PIC X(001) VALUE '/'.*/
                public StringBasis FILLER_137 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10          LR02-PAG-FINAL       PIC 9(003).*/
                public IntBasis LR02_PAG_FINAL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    05            LR11-LINHA11.*/
            }
            public VG0267B_LR11_LINHA11 LR11_LINHA11 { get; set; } = new VG0267B_LR11_LINHA11();
            public class VG0267B_LR11_LINHA11 : VarBasis
            {
                /*"      10          FILLER              PIC X(101) VALUE SPACES.*/
                public StringBasis FILLER_138 { get; set; } = new StringBasis(new PIC("X", "101", "X(101)"), @"");
                /*"      10          LR11-GEPES          PIC X(008) VALUE                                                'GEPES - '.*/
                public StringBasis LR11_GEPES { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"GEPES - ");
                /*"      10          LR03-TP-PGTO        PIC X(022) VALUE SPACES.*/
                public StringBasis LR03_TP_PGTO { get; set; } = new StringBasis(new PIC("X", "22", "X(022)"), @"");
                /*"    05            LR12-LINHA12.*/
            }
            public VG0267B_LR12_LINHA12 LR12_LINHA12 { get; set; } = new VG0267B_LR12_LINHA12();
            public class VG0267B_LR12_LINHA12 : VarBasis
            {
                /*"      10          FILLER              PIC X(004) VALUE SPACES.*/
                public StringBasis FILLER_139 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"      10          LR05-CEPI           PIC 9(005).*/
                public IntBasis LR05_CEPI { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"      10          FILLER              PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_140 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10          LR05-COMPL-CEPI     PIC 9(003).*/
                public IntBasis LR05_COMPL_CEPI { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"      10          FILLER              PIC X(007) VALUE SPACES.*/
                public StringBasis FILLER_141 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"      10          LR05-CEPF           PIC 9(005).*/
                public IntBasis LR05_CEPF { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"      10          FILLER              PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_142 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10          LR05-COMPL-CEPF     PIC 9(003).*/
                public IntBasis LR05_COMPL_CEPF { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"      10          FILLER              PIC X(007) VALUE SPACES.*/
                public StringBasis FILLER_143 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"      10          LR05-OBJI           PIC ZZZ.999.*/
                public IntBasis LR05_OBJI { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10          FILLER              PIC X(006) VALUE SPACES.*/
                public StringBasis FILLER_144 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"      10          LR05-OBJF           PIC ZZZ.999.*/
                public IntBasis LR05_OBJF { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10          FILLER              PIC X(005) VALUE SPACES.*/
                public StringBasis FILLER_145 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"      10          LR05-AMARI          PIC ZZZ.999.*/
                public IntBasis LR05_AMARI { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10          FILLER              PIC X(006) VALUE SPACES.*/
                public StringBasis FILLER_146 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"      10          LR05-AMARF          PIC ZZZ.999.*/
                public IntBasis LR05_AMARF { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10          FILLER              PIC X(005) VALUE SPACES.*/
                public StringBasis FILLER_147 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"      10          LR05-QTD-OBJ        PIC ZZZ.999.*/
                public IntBasis LR05_QTD_OBJ { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10          FILLER              PIC X(006) VALUE SPACES.*/
                public StringBasis FILLER_148 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"      10          LR05-QTD-AMAR       PIC ZZZ.999.*/
                public IntBasis LR05_QTD_AMAR { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.999."));
                /*"      10          FILLER              PIC X(004) VALUE SPACES.*/
                public StringBasis FILLER_149 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"      10          LR05-OBS            PIC X(023).*/
                public StringBasis LR05_OBS { get; set; } = new StringBasis(new PIC("X", "23", "X(023)."), @"");
                /*"    05            LR13-LINHA13.*/
            }
            public VG0267B_LR13_LINHA13 LR13_LINHA13 { get; set; } = new VG0267B_LR13_LINHA13();
            public class VG0267B_LR13_LINHA13 : VarBasis
            {
                /*"      10          FILLER              PIC X(001) VALUE '1'.*/
                public StringBasis FILLER_150 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"1");
                /*"    05        WWRK-NSNUMERO       PIC  9(011)    VALUE ZEROS.*/
            }
            public IntBasis WWRK_NSNUMERO { get; set; } = new IntBasis(new PIC("9", "11", "9(011)"));
            /*"    05        FILLER              REDEFINES              WWRK-NSNUMERO.*/
            private _REDEF_VG0267B_FILLER_151 _filler_151 { get; set; }
            public _REDEF_VG0267B_FILLER_151 FILLER_151
            {
                get { _filler_151 = new _REDEF_VG0267B_FILLER_151(); _.Move(WWRK_NSNUMERO, _filler_151); VarBasis.RedefinePassValue(WWRK_NSNUMERO, _filler_151, WWRK_NSNUMERO); _filler_151.ValueChanged += () => { _.Move(_filler_151, WWRK_NSNUMERO); }; return _filler_151; }
                set { VarBasis.RedefinePassValue(value, _filler_151, WWRK_NSNUMERO); }
            }  //Redefines
            public class _REDEF_VG0267B_FILLER_151 : VarBasis
            {
                /*"      10      WWRK-NSNRO          PIC  9(010).*/
                public IntBasis WWRK_NSNRO { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"      10      FILLER              REDEFINES              WWRK-NSNRO.*/
                private _REDEF_VG0267B_FILLER_152 _filler_152 { get; set; }
                public _REDEF_VG0267B_FILLER_152 FILLER_152
                {
                    get { _filler_152 = new _REDEF_VG0267B_FILLER_152(); _.Move(WWRK_NSNRO, _filler_152); VarBasis.RedefinePassValue(WWRK_NSNRO, _filler_152, WWRK_NSNRO); _filler_152.ValueChanged += () => { _.Move(_filler_152, WWRK_NSNRO); }; return _filler_152; }
                    set { VarBasis.RedefinePassValue(value, _filler_152, WWRK_NSNRO); }
                }  //Redefines
                public class _REDEF_VG0267B_FILLER_152 : VarBasis
                {
                    /*"        15    WWRK-NSNRO-1        PIC  9(001).*/
                    public IntBasis WWRK_NSNRO_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    WWRK-NSNRO-2        PIC  9(004).*/
                    public IntBasis WWRK_NSNRO_2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"        15    WWRK-NSNRO-3        PIC  9(005).*/
                    public IntBasis WWRK_NSNRO_3 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                    /*"      10      WWRK-NSNRO-4        PIC  9(001).*/

                    public _REDEF_VG0267B_FILLER_152()
                    {
                        WWRK_NSNRO_1.ValueChanged += OnValueChanged;
                        WWRK_NSNRO_2.ValueChanged += OnValueChanged;
                        WWRK_NSNRO_3.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis WWRK_NSNRO_4 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05   WK-NOSSO-NUMERO          PIC  9(018).*/

                public _REDEF_VG0267B_FILLER_151()
                {
                    WWRK_NSNRO.ValueChanged += OnValueChanged;
                    FILLER_152.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WK_NOSSO_NUMERO { get; set; } = new IntBasis(new PIC("9", "18", "9(018)."));
            /*"    05   WK-NUMERO-R REDEFINES WK-NOSSO-NUMERO.*/
            private _REDEF_VG0267B_WK_NUMERO_R _wk_numero_r { get; set; }
            public _REDEF_VG0267B_WK_NUMERO_R WK_NUMERO_R
            {
                get { _wk_numero_r = new _REDEF_VG0267B_WK_NUMERO_R(); _.Move(WK_NOSSO_NUMERO, _wk_numero_r); VarBasis.RedefinePassValue(WK_NOSSO_NUMERO, _wk_numero_r, WK_NOSSO_NUMERO); _wk_numero_r.ValueChanged += () => { _.Move(_wk_numero_r, WK_NOSSO_NUMERO); }; return _wk_numero_r; }
                set { VarBasis.RedefinePassValue(value, _wk_numero_r, WK_NOSSO_NUMERO); }
            }  //Redefines
            public class _REDEF_VG0267B_WK_NUMERO_R : VarBasis
            {
                /*"      10 WK-NUMERO                PIC  9(017).*/
                public IntBasis WK_NUMERO { get; set; } = new IntBasis(new PIC("9", "17", "9(017)."));
                /*"      10 WK-DIGITO                PIC  9(001).*/
                public IntBasis WK_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05        QUOCIENTE           PIC  9(006)    VALUE  ZEROS.*/

                public _REDEF_VG0267B_WK_NUMERO_R()
                {
                    WK_NUMERO.ValueChanged += OnValueChanged;
                    WK_DIGITO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis QUOCIENTE { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        RESTO               PIC  9(006)    VALUE  ZEROS.*/
            public IntBasis RESTO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        WPARM01-AUX         PIC S9(009)    VALUE +0 COMP-3*/
            public IntBasis WPARM01_AUX { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    05        WPARM91-AUX         PIC S9(009)    VALUE +0 COMP-3*/
            public IntBasis WPARM91_AUX { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    05        WQUOCIENTE          PIC S9(004)    VALUE +0 COMP-3*/
            public IntBasis WQUOCIENTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        WRESTO              PIC S9(004)    VALUE +0 COMP-3*/
            public IntBasis WRESTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        AC-L-PBR0002B       PIC  9(005)    VALUE ZEROS.*/
            public IntBasis AC_L_PBR0002B { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    05        WCALCULO            PIC  9(002)    VALUE ZEROS.*/
            public IntBasis WCALCULO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"    05        FILLER              REDEFINES              WCALCULO.*/
            private _REDEF_VG0267B_FILLER_153 _filler_153 { get; set; }
            public _REDEF_VG0267B_FILLER_153 FILLER_153
            {
                get { _filler_153 = new _REDEF_VG0267B_FILLER_153(); _.Move(WCALCULO, _filler_153); VarBasis.RedefinePassValue(WCALCULO, _filler_153, WCALCULO); _filler_153.ValueChanged += () => { _.Move(_filler_153, WCALCULO); }; return _filler_153; }
                set { VarBasis.RedefinePassValue(value, _filler_153, WCALCULO); }
            }  //Redefines
            public class _REDEF_VG0267B_FILLER_153 : VarBasis
            {
                /*"      10      WCALCUL1            PIC  9(001).*/
                public IntBasis WCALCUL1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"      10      WCALCUL2            PIC  9(001).*/
                public IntBasis WCALCUL2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05        W91-NUMERO          PIC  X(043) VALUE ZEROS.*/

                public _REDEF_VG0267B_FILLER_153()
                {
                    WCALCUL1.ValueChanged += OnValueChanged;
                    WCALCUL2.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W91_NUMERO { get; set; } = new StringBasis(new PIC("X", "43", "X(043)"), @"");
            /*"    05        FILLER              REDEFINES              W91-NUMERO.*/
            private _REDEF_VG0267B_FILLER_154 _filler_154 { get; set; }
            public _REDEF_VG0267B_FILLER_154 FILLER_154
            {
                get { _filler_154 = new _REDEF_VG0267B_FILLER_154(); _.Move(W91_NUMERO, _filler_154); VarBasis.RedefinePassValue(W91_NUMERO, _filler_154, W91_NUMERO); _filler_154.ValueChanged += () => { _.Move(_filler_154, W91_NUMERO); }; return _filler_154; }
                set { VarBasis.RedefinePassValue(value, _filler_154, W91_NUMERO); }
            }  //Redefines
            public class _REDEF_VG0267B_FILLER_154 : VarBasis
            {
                /*"      10      W91-BANCO           PIC  9(003).*/
                public IntBasis W91_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"      10      W91-MOEDA           PIC  9(001).*/
                public IntBasis W91_MOEDA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"      10      W91-VALOR           PIC  9(014).*/
                public IntBasis W91_VALOR { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                /*"      10      W91-NSNUM           PIC  9(010).*/
                public IntBasis W91_NSNUM { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"      10      W91-CDCED           PIC  9(015).*/
                public IntBasis W91_CDCED { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"    05        W91-DIGITO          PIC  9(001)    VALUE ZEROS.*/

                public _REDEF_VG0267B_FILLER_154()
                {
                    W91_BANCO.ValueChanged += OnValueChanged;
                    W91_MOEDA.ValueChanged += OnValueChanged;
                    W91_VALOR.ValueChanged += OnValueChanged;
                    W91_NSNUM.ValueChanged += OnValueChanged;
                    W91_CDCED.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W91_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05        LPARM01X.*/
            public VG0267B_LPARM01X LPARM01X { get; set; } = new VG0267B_LPARM01X();
            public class VG0267B_LPARM01X : VarBasis
            {
                /*"      10      LPARM01             PIC  9(015).*/
                public IntBasis LPARM01 { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"      10      LPARM01-R           REDEFINES              LPARM01.*/
                private _REDEF_VG0267B_LPARM01_R _lparm01_r { get; set; }
                public _REDEF_VG0267B_LPARM01_R LPARM01_R
                {
                    get { _lparm01_r = new _REDEF_VG0267B_LPARM01_R(); _.Move(LPARM01, _lparm01_r); VarBasis.RedefinePassValue(LPARM01, _lparm01_r, LPARM01); _lparm01_r.ValueChanged += () => { _.Move(_lparm01_r, LPARM01); }; return _lparm01_r; }
                    set { VarBasis.RedefinePassValue(value, _lparm01_r, LPARM01); }
                }  //Redefines
                public class _REDEF_VG0267B_LPARM01_R : VarBasis
                {
                    /*"        15    LPARM01-1           PIC  9(001).*/
                    public IntBasis LPARM01_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM01-2           PIC  9(001).*/
                    public IntBasis LPARM01_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM01-3           PIC  9(001).*/
                    public IntBasis LPARM01_3 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM01-4           PIC  9(001).*/
                    public IntBasis LPARM01_4 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM01-5           PIC  9(001).*/
                    public IntBasis LPARM01_5 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM01-6           PIC  9(001).*/
                    public IntBasis LPARM01_6 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM01-7           PIC  9(001).*/
                    public IntBasis LPARM01_7 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM01-8           PIC  9(001).*/
                    public IntBasis LPARM01_8 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM01-9           PIC  9(001).*/
                    public IntBasis LPARM01_9 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM01-10          PIC  9(001).*/
                    public IntBasis LPARM01_10 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM01-11          PIC  9(001).*/
                    public IntBasis LPARM01_11 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM01-12          PIC  9(001).*/
                    public IntBasis LPARM01_12 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM01-13          PIC  9(001).*/
                    public IntBasis LPARM01_13 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM01-14          PIC  9(001).*/
                    public IntBasis LPARM01_14 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM01-15          PIC  9(001).*/
                    public IntBasis LPARM01_15 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"    05        LPARM02             PIC S9(004) COMP.*/

                    public _REDEF_VG0267B_LPARM01_R()
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
            }
            public IntBasis LPARM02 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        LPARM03             PIC  9(001).*/
            public IntBasis LPARM03 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05        LPARM03-R           REDEFINES   LPARM03                                  PIC  X(001).*/
            private _REDEF_StringBasis _lparm03_r { get; set; }
            public _REDEF_StringBasis LPARM03_R
            {
                get { _lparm03_r = new _REDEF_StringBasis(new PIC("X", "001", "X(001).")); ; _.Move(LPARM03, _lparm03_r); VarBasis.RedefinePassValue(LPARM03, _lparm03_r, LPARM03); _lparm03_r.ValueChanged += () => { _.Move(_lparm03_r, LPARM03); }; return _lparm03_r; }
                set { VarBasis.RedefinePassValue(value, _lparm03_r, LPARM03); }
            }  //Redefines
            /*"    05        LPARM91X.*/
            public VG0267B_LPARM91X LPARM91X { get; set; } = new VG0267B_LPARM91X();
            public class VG0267B_LPARM91X : VarBasis
            {
                /*"      10      LPARM91             PIC  X(043).*/
                public StringBasis LPARM91 { get; set; } = new StringBasis(new PIC("X", "43", "X(043)."), @"");
                /*"      10      LPARM91-R           REDEFINES              LPARM91.*/
                private _REDEF_VG0267B_LPARM91_R _lparm91_r { get; set; }
                public _REDEF_VG0267B_LPARM91_R LPARM91_R
                {
                    get { _lparm91_r = new _REDEF_VG0267B_LPARM91_R(); _.Move(LPARM91, _lparm91_r); VarBasis.RedefinePassValue(LPARM91, _lparm91_r, LPARM91); _lparm91_r.ValueChanged += () => { _.Move(_lparm91_r, LPARM91); }; return _lparm91_r; }
                    set { VarBasis.RedefinePassValue(value, _lparm91_r, LPARM91); }
                }  //Redefines
                public class _REDEF_VG0267B_LPARM91_R : VarBasis
                {
                    /*"        15    LPARM91-1           PIC  9(001).*/
                    public IntBasis LPARM91_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-2           PIC  9(001).*/
                    public IntBasis LPARM91_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-3           PIC  9(001).*/
                    public IntBasis LPARM91_3 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-4           PIC  9(001).*/
                    public IntBasis LPARM91_4 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-5           PIC  9(001).*/
                    public IntBasis LPARM91_5 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-6           PIC  9(001).*/
                    public IntBasis LPARM91_6 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-7           PIC  9(001).*/
                    public IntBasis LPARM91_7 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-8           PIC  9(001).*/
                    public IntBasis LPARM91_8 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-9           PIC  9(001).*/
                    public IntBasis LPARM91_9 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-10          PIC  9(001).*/
                    public IntBasis LPARM91_10 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-11          PIC  9(001).*/
                    public IntBasis LPARM91_11 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-12          PIC  9(001).*/
                    public IntBasis LPARM91_12 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-13          PIC  9(001).*/
                    public IntBasis LPARM91_13 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-14          PIC  9(001).*/
                    public IntBasis LPARM91_14 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-15          PIC  9(001).*/
                    public IntBasis LPARM91_15 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-16          PIC  9(001).*/
                    public IntBasis LPARM91_16 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-17          PIC  9(001).*/
                    public IntBasis LPARM91_17 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-18          PIC  9(001).*/
                    public IntBasis LPARM91_18 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-19          PIC  9(001).*/
                    public IntBasis LPARM91_19 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-20          PIC  9(001).*/
                    public IntBasis LPARM91_20 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-21          PIC  9(001).*/
                    public IntBasis LPARM91_21 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-22          PIC  9(001).*/
                    public IntBasis LPARM91_22 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-23          PIC  9(001).*/
                    public IntBasis LPARM91_23 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-24          PIC  9(001).*/
                    public IntBasis LPARM91_24 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-25          PIC  9(001).*/
                    public IntBasis LPARM91_25 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-26          PIC  9(001).*/
                    public IntBasis LPARM91_26 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-27          PIC  9(001).*/
                    public IntBasis LPARM91_27 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-28          PIC  9(001).*/
                    public IntBasis LPARM91_28 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-29          PIC  9(001).*/
                    public IntBasis LPARM91_29 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-30          PIC  9(001).*/
                    public IntBasis LPARM91_30 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-31          PIC  9(001).*/
                    public IntBasis LPARM91_31 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-32          PIC  9(001).*/
                    public IntBasis LPARM91_32 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-33          PIC  9(001).*/
                    public IntBasis LPARM91_33 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-34          PIC  9(001).*/
                    public IntBasis LPARM91_34 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-35          PIC  9(001).*/
                    public IntBasis LPARM91_35 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-36          PIC  9(001).*/
                    public IntBasis LPARM91_36 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-37          PIC  9(001).*/
                    public IntBasis LPARM91_37 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-38          PIC  9(001).*/
                    public IntBasis LPARM91_38 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-39          PIC  9(001).*/
                    public IntBasis LPARM91_39 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-40          PIC  9(001).*/
                    public IntBasis LPARM91_40 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-41          PIC  9(001).*/
                    public IntBasis LPARM91_41 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-42          PIC  9(001).*/
                    public IntBasis LPARM91_42 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    LPARM91-43          PIC  9(001).*/
                    public IntBasis LPARM91_43 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      10      LPARM92             PIC S9(004) COMP.*/

                    public _REDEF_VG0267B_LPARM91_R()
                    {
                        LPARM91_1.ValueChanged += OnValueChanged;
                        LPARM91_2.ValueChanged += OnValueChanged;
                        LPARM91_3.ValueChanged += OnValueChanged;
                        LPARM91_4.ValueChanged += OnValueChanged;
                        LPARM91_5.ValueChanged += OnValueChanged;
                        LPARM91_6.ValueChanged += OnValueChanged;
                        LPARM91_7.ValueChanged += OnValueChanged;
                        LPARM91_8.ValueChanged += OnValueChanged;
                        LPARM91_9.ValueChanged += OnValueChanged;
                        LPARM91_10.ValueChanged += OnValueChanged;
                        LPARM91_11.ValueChanged += OnValueChanged;
                        LPARM91_12.ValueChanged += OnValueChanged;
                        LPARM91_13.ValueChanged += OnValueChanged;
                        LPARM91_14.ValueChanged += OnValueChanged;
                        LPARM91_15.ValueChanged += OnValueChanged;
                        LPARM91_16.ValueChanged += OnValueChanged;
                        LPARM91_17.ValueChanged += OnValueChanged;
                        LPARM91_18.ValueChanged += OnValueChanged;
                        LPARM91_19.ValueChanged += OnValueChanged;
                        LPARM91_20.ValueChanged += OnValueChanged;
                        LPARM91_21.ValueChanged += OnValueChanged;
                        LPARM91_22.ValueChanged += OnValueChanged;
                        LPARM91_23.ValueChanged += OnValueChanged;
                        LPARM91_24.ValueChanged += OnValueChanged;
                        LPARM91_25.ValueChanged += OnValueChanged;
                        LPARM91_26.ValueChanged += OnValueChanged;
                        LPARM91_27.ValueChanged += OnValueChanged;
                        LPARM91_28.ValueChanged += OnValueChanged;
                        LPARM91_29.ValueChanged += OnValueChanged;
                        LPARM91_30.ValueChanged += OnValueChanged;
                        LPARM91_31.ValueChanged += OnValueChanged;
                        LPARM91_32.ValueChanged += OnValueChanged;
                        LPARM91_33.ValueChanged += OnValueChanged;
                        LPARM91_34.ValueChanged += OnValueChanged;
                        LPARM91_35.ValueChanged += OnValueChanged;
                        LPARM91_36.ValueChanged += OnValueChanged;
                        LPARM91_37.ValueChanged += OnValueChanged;
                        LPARM91_38.ValueChanged += OnValueChanged;
                        LPARM91_39.ValueChanged += OnValueChanged;
                        LPARM91_40.ValueChanged += OnValueChanged;
                        LPARM91_41.ValueChanged += OnValueChanged;
                        LPARM91_42.ValueChanged += OnValueChanged;
                        LPARM91_43.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis LPARM92 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"      10      LPARM93             PIC  9(001).*/
                public IntBasis LPARM93 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"      10      LPARM93-R           REDEFINES   LPARM93                                  PIC  X(001).*/
                private _REDEF_StringBasis _lparm93_r { get; set; }
                public _REDEF_StringBasis LPARM93_R
                {
                    get { _lparm93_r = new _REDEF_StringBasis(new PIC("X", "001", "X(001).")); ; _.Move(LPARM93, _lparm93_r); VarBasis.RedefinePassValue(LPARM93, _lparm93_r, LPARM93); _lparm93_r.ValueChanged += () => { _.Move(_lparm93_r, LPARM93); }; return _lparm93_r; }
                    set { VarBasis.RedefinePassValue(value, _lparm93_r, LPARM93); }
                }  //Redefines
                /*"    05        WWRK-NRTIT          PIC  9(011)    VALUE ZEROS.*/
            }
            public IntBasis WWRK_NRTIT { get; set; } = new IntBasis(new PIC("9", "11", "9(011)"));
            /*"    05        FILLER              REDEFINES              WWRK-NRTIT.*/
            private _REDEF_VG0267B_FILLER_155 _filler_155 { get; set; }
            public _REDEF_VG0267B_FILLER_155 FILLER_155
            {
                get { _filler_155 = new _REDEF_VG0267B_FILLER_155(); _.Move(WWRK_NRTIT, _filler_155); VarBasis.RedefinePassValue(WWRK_NRTIT, _filler_155, WWRK_NRTIT); _filler_155.ValueChanged += () => { _.Move(_filler_155, WWRK_NRTIT); }; return _filler_155; }
                set { VarBasis.RedefinePassValue(value, _filler_155, WWRK_NRTIT); }
            }  //Redefines
            public class _REDEF_VG0267B_FILLER_155 : VarBasis
            {
                /*"      10      WWRK-NRTIT-NRO      PIC  9(009).*/
                public IntBasis WWRK_NRTIT_NRO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"      10      WWRK-NRTIT-DG1      PIC  9(001).*/
                public IntBasis WWRK_NRTIT_DG1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"      10      WWRK-NRTIT-DG2      PIC  9(001).*/
                public IntBasis WWRK_NRTIT_DG2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05        WWRK-AGEOPE-CED     PIC  9(005)    VALUE ZEROS.*/

                public _REDEF_VG0267B_FILLER_155()
                {
                    WWRK_NRTIT_NRO.ValueChanged += OnValueChanged;
                    WWRK_NRTIT_DG1.ValueChanged += OnValueChanged;
                    WWRK_NRTIT_DG2.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WWRK_AGEOPE_CED { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    05        FILLER              REDEFINES              WWRK-AGEOPE-CED.*/
            private _REDEF_VG0267B_FILLER_156 _filler_156 { get; set; }
            public _REDEF_VG0267B_FILLER_156 FILLER_156
            {
                get { _filler_156 = new _REDEF_VG0267B_FILLER_156(); _.Move(WWRK_AGEOPE_CED, _filler_156); VarBasis.RedefinePassValue(WWRK_AGEOPE_CED, _filler_156, WWRK_AGEOPE_CED); _filler_156.ValueChanged += () => { _.Move(_filler_156, WWRK_AGEOPE_CED); }; return _filler_156; }
                set { VarBasis.RedefinePassValue(value, _filler_156, WWRK_AGEOPE_CED); }
            }  //Redefines
            public class _REDEF_VG0267B_FILLER_156 : VarBasis
            {
                /*"      10      WWRK-CDAGE          PIC  9(004).*/
                public IntBasis WWRK_CDAGE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      WWRK-OPE            PIC  9(001).*/
                public IntBasis WWRK_OPE { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05        WWRK-OPE-CED        PIC  9(003)    VALUE ZEROS.*/

                public _REDEF_VG0267B_FILLER_156()
                {
                    WWRK_CDAGE.ValueChanged += OnValueChanged;
                    WWRK_OPE.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WWRK_OPE_CED { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"    05        FILLER              REDEFINES              WWRK-OPE-CED.*/
            private _REDEF_VG0267B_FILLER_157 _filler_157 { get; set; }
            public _REDEF_VG0267B_FILLER_157 FILLER_157
            {
                get { _filler_157 = new _REDEF_VG0267B_FILLER_157(); _.Move(WWRK_OPE_CED, _filler_157); VarBasis.RedefinePassValue(WWRK_OPE_CED, _filler_157, WWRK_OPE_CED); _filler_157.ValueChanged += () => { _.Move(_filler_157, WWRK_OPE_CED); }; return _filler_157; }
                set { VarBasis.RedefinePassValue(value, _filler_157, WWRK_OPE_CED); }
            }  //Redefines
            public class _REDEF_VG0267B_FILLER_157 : VarBasis
            {
                /*"      10      WWRK-OPE1           PIC  9(001).*/
                public IntBasis WWRK_OPE1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"      10      WWRK-OPE2           PIC  9(002).*/
                public IntBasis WWRK_OPE2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05        WWRK-CAMPO3         PIC  9(010)    VALUE ZEROS.*/

                public _REDEF_VG0267B_FILLER_157()
                {
                    WWRK_OPE1.ValueChanged += OnValueChanged;
                    WWRK_OPE2.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WWRK_CAMPO3 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)"));
            /*"    05        FILLER              REDEFINES              WWRK-CAMPO3.*/
            private _REDEF_VG0267B_FILLER_158 _filler_158 { get; set; }
            public _REDEF_VG0267B_FILLER_158 FILLER_158
            {
                get { _filler_158 = new _REDEF_VG0267B_FILLER_158(); _.Move(WWRK_CAMPO3, _filler_158); VarBasis.RedefinePassValue(WWRK_CAMPO3, _filler_158, WWRK_CAMPO3); _filler_158.ValueChanged += () => { _.Move(_filler_158, WWRK_CAMPO3); }; return _filler_158; }
                set { VarBasis.RedefinePassValue(value, _filler_158, WWRK_CAMPO3); }
            }  //Redefines
            public class _REDEF_VG0267B_FILLER_158 : VarBasis
            {
                /*"      10      WWRK-2UOPE          PIC  9(002).*/
                public IntBasis WWRK_2UOPE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      WWRK-NCTCD          PIC  9(008).*/
                public IntBasis WWRK_NCTCD { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    05        WWRK-VALOR-FMT      PIC  9(012)V9(002) VALUE ZEROS*/

                public _REDEF_VG0267B_FILLER_158()
                {
                    WWRK_2UOPE.ValueChanged += OnValueChanged;
                    WWRK_NCTCD.ValueChanged += OnValueChanged;
                }

            }
            public DoubleBasis WWRK_VALOR_FMT { get; set; } = new DoubleBasis(new PIC("9", "12", "9(012)V9(002)"), 2);
            /*"    05        WWRK-VALOR          REDEFINES              WWRK-VALOR-FMT      PIC  9(014).*/
            private _REDEF_IntBasis _wwrk_valor { get; set; }
            public _REDEF_IntBasis WWRK_VALOR
            {
                get { _wwrk_valor = new _REDEF_IntBasis(new PIC("9", "014", "9(014).")); ; _.Move(WWRK_VALOR_FMT, _wwrk_valor); VarBasis.RedefinePassValue(WWRK_VALOR_FMT, _wwrk_valor, WWRK_VALOR_FMT); _wwrk_valor.ValueChanged += () => { _.Move(_wwrk_valor, WWRK_VALOR_FMT); }; return _wwrk_valor; }
                set { VarBasis.RedefinePassValue(value, _wwrk_valor, WWRK_VALOR_FMT); }
            }  //Redefines
            /*"    05        WBAR-AREA.*/
            public VG0267B_WBAR_AREA WBAR_AREA { get; set; } = new VG0267B_WBAR_AREA();
            public class VG0267B_WBAR_AREA : VarBasis
            {
                /*"      10      WBAR-CAMPO-1        PIC  9(009)    VALUE ZEROS.*/
                public IntBasis WBAR_CAMPO_1 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
                /*"      10      FILLER              REDEFINES              WBAR-CAMPO-1.*/
                private _REDEF_VG0267B_FILLER_159 _filler_159 { get; set; }
                public _REDEF_VG0267B_FILLER_159 FILLER_159
                {
                    get { _filler_159 = new _REDEF_VG0267B_FILLER_159(); _.Move(WBAR_CAMPO_1, _filler_159); VarBasis.RedefinePassValue(WBAR_CAMPO_1, _filler_159, WBAR_CAMPO_1); _filler_159.ValueChanged += () => { _.Move(_filler_159, WBAR_CAMPO_1); }; return _filler_159; }
                    set { VarBasis.RedefinePassValue(value, _filler_159, WBAR_CAMPO_1); }
                }  //Redefines
                public class _REDEF_VG0267B_FILLER_159 : VarBasis
                {
                    /*"        15    WBAR-BANCO          PIC  9(003).*/
                    public IntBasis WBAR_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                    /*"        15    WBAR-MOEDA          PIC  9(001).*/
                    public IntBasis WBAR_MOEDA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    WBAR-NSNRO-1        PIC  9(001).*/
                    public IntBasis WBAR_NSNRO_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        15    WBAR-NSNRO-2        PIC  9(004).*/
                    public IntBasis WBAR_NSNRO_2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      10      WBAR-DAC-1          PIC  9(001)    VALUE ZEROS.*/

                    public _REDEF_VG0267B_FILLER_159()
                    {
                        WBAR_BANCO.ValueChanged += OnValueChanged;
                        WBAR_MOEDA.ValueChanged += OnValueChanged;
                        WBAR_NSNRO_1.ValueChanged += OnValueChanged;
                        WBAR_NSNRO_2.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis WBAR_DAC_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
                /*"      10      WBAR-CAMPO-2        PIC  9(010)    VALUE ZEROS.*/
                public IntBasis WBAR_CAMPO_2 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)"));
                /*"      10      FILLER              REDEFINES              WBAR-CAMPO-2.*/
                private _REDEF_VG0267B_FILLER_160 _filler_160 { get; set; }
                public _REDEF_VG0267B_FILLER_160 FILLER_160
                {
                    get { _filler_160 = new _REDEF_VG0267B_FILLER_160(); _.Move(WBAR_CAMPO_2, _filler_160); VarBasis.RedefinePassValue(WBAR_CAMPO_2, _filler_160, WBAR_CAMPO_2); _filler_160.ValueChanged += () => { _.Move(_filler_160, WBAR_CAMPO_2); }; return _filler_160; }
                    set { VarBasis.RedefinePassValue(value, _filler_160, WBAR_CAMPO_2); }
                }  //Redefines
                public class _REDEF_VG0267B_FILLER_160 : VarBasis
                {
                    /*"        15    WBAR-NSNRO-3        PIC  9(005).*/
                    public IntBasis WBAR_NSNRO_3 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                    /*"        15    WBAR-CDCED-1        PIC  9(005).*/
                    public IntBasis WBAR_CDCED_1 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                    /*"      10      WBAR-DAC-2          PIC  9(001).*/

                    public _REDEF_VG0267B_FILLER_160()
                    {
                        WBAR_NSNRO_3.ValueChanged += OnValueChanged;
                        WBAR_CDCED_1.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis WBAR_DAC_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"      10      WBAR-CAMPO-3        PIC  9(010)    VALUE ZEROS.*/
                public IntBasis WBAR_CAMPO_3 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)"));
                /*"      10      FILLER              REDEFINES              WBAR-CAMPO-3.*/
                private _REDEF_VG0267B_FILLER_161 _filler_161 { get; set; }
                public _REDEF_VG0267B_FILLER_161 FILLER_161
                {
                    get { _filler_161 = new _REDEF_VG0267B_FILLER_161(); _.Move(WBAR_CAMPO_3, _filler_161); VarBasis.RedefinePassValue(WBAR_CAMPO_3, _filler_161, WBAR_CAMPO_3); _filler_161.ValueChanged += () => { _.Move(_filler_161, WBAR_CAMPO_3); }; return _filler_161; }
                    set { VarBasis.RedefinePassValue(value, _filler_161, WBAR_CAMPO_3); }
                }  //Redefines
                public class _REDEF_VG0267B_FILLER_161 : VarBasis
                {
                    /*"        15    WBAR-CDCED-2        PIC  9(005).*/
                    public IntBasis WBAR_CDCED_2 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                    /*"        15    WBAR-CDCED-3        PIC  9(005).*/
                    public IntBasis WBAR_CDCED_3 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                    /*"      10      WBAR-DAC-3          PIC  9(001)    VALUE ZEROS.*/

                    public _REDEF_VG0267B_FILLER_161()
                    {
                        WBAR_CDCED_2.ValueChanged += OnValueChanged;
                        WBAR_CDCED_3.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis WBAR_DAC_3 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
                /*"      10      WBAR-CAMPO-4        PIC  9(001)    VALUE ZEROS.*/
                public IntBasis WBAR_CAMPO_4 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
                /*"      10      FILLER              REDEFINES              WBAR-CAMPO-4.*/
                private _REDEF_VG0267B_FILLER_162 _filler_162 { get; set; }
                public _REDEF_VG0267B_FILLER_162 FILLER_162
                {
                    get { _filler_162 = new _REDEF_VG0267B_FILLER_162(); _.Move(WBAR_CAMPO_4, _filler_162); VarBasis.RedefinePassValue(WBAR_CAMPO_4, _filler_162, WBAR_CAMPO_4); _filler_162.ValueChanged += () => { _.Move(_filler_162, WBAR_CAMPO_4); }; return _filler_162; }
                    set { VarBasis.RedefinePassValue(value, _filler_162, WBAR_CAMPO_4); }
                }  //Redefines
                public class _REDEF_VG0267B_FILLER_162 : VarBasis
                {
                    /*"        15    WBAR-DIGITO         PIC  9(001).*/
                    public IntBasis WBAR_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      10      WBAR-CAMPO-5        PIC  9(012)V99 VALUE ZEROS.*/

                    public _REDEF_VG0267B_FILLER_162()
                    {
                        WBAR_DIGITO.ValueChanged += OnValueChanged;
                    }

                }
                public DoubleBasis WBAR_CAMPO_5 { get; set; } = new DoubleBasis(new PIC("9", "12", "9(012)V99"), 2);
                /*"      10      FILLER              REDEFINES              WBAR-CAMPO-5.*/
                private _REDEF_VG0267B_FILLER_163 _filler_163 { get; set; }
                public _REDEF_VG0267B_FILLER_163 FILLER_163
                {
                    get { _filler_163 = new _REDEF_VG0267B_FILLER_163(); _.Move(WBAR_CAMPO_5, _filler_163); VarBasis.RedefinePassValue(WBAR_CAMPO_5, _filler_163, WBAR_CAMPO_5); _filler_163.ValueChanged += () => { _.Move(_filler_163, WBAR_CAMPO_5); }; return _filler_163; }
                    set { VarBasis.RedefinePassValue(value, _filler_163, WBAR_CAMPO_5); }
                }  //Redefines
                public class _REDEF_VG0267B_FILLER_163 : VarBasis
                {
                    /*"        15    WBAR-VALOR          PIC  9(014).*/
                    public IntBasis WBAR_VALOR { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                    /*"    05        WWRK-CEDENTE        PIC  9(015)    VALUE ZEROS.*/

                    public _REDEF_VG0267B_FILLER_163()
                    {
                        WBAR_VALOR.ValueChanged += OnValueChanged;
                    }

                }
            }
            public IntBasis WWRK_CEDENTE { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"    05        FILLER              REDEFINES      WWRK-CEDENTE.*/
            private _REDEF_VG0267B_FILLER_164 _filler_164 { get; set; }
            public _REDEF_VG0267B_FILLER_164 FILLER_164
            {
                get { _filler_164 = new _REDEF_VG0267B_FILLER_164(); _.Move(WWRK_CEDENTE, _filler_164); VarBasis.RedefinePassValue(WWRK_CEDENTE, _filler_164, WWRK_CEDENTE); _filler_164.ValueChanged += () => { _.Move(_filler_164, WWRK_CEDENTE); }; return _filler_164; }
                set { VarBasis.RedefinePassValue(value, _filler_164, WWRK_CEDENTE); }
            }  //Redefines
            public class _REDEF_VG0267B_FILLER_164 : VarBasis
            {
                /*"      10      WWRK-CDCED-1        PIC  9(004).*/
                public IntBasis WWRK_CDCED_1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      WWRK-CDCED-2        PIC  9(003).*/
                public IntBasis WWRK_CDCED_2 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"      10      WWRK-CDCED-3        PIC  9(008).*/
                public IntBasis WWRK_CDCED_3 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    05        WSL-SQLCODE         PIC  9(009)    VALUE ZEROS.*/

                public _REDEF_VG0267B_FILLER_164()
                {
                    WWRK_CDCED_1.ValueChanged += OnValueChanged;
                    WWRK_CDCED_2.ValueChanged += OnValueChanged;
                    WWRK_CDCED_3.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05        AC-LINHAS           PIC  9(002)    VALUE 80.*/
            public IntBasis AC_LINHAS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 80);
            /*"    05        WWORK-QTDE01.*/
            public VG0267B_WWORK_QTDE01 WWORK_QTDE01 { get; set; } = new VG0267B_WWORK_QTDE01();
            public class VG0267B_WWORK_QTDE01 : VarBasis
            {
                /*"       10     WWORK-QTDE11        PIC  9(004).*/
                public IntBasis WWORK_QTDE11 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10     WWORK-QTDE12        PIC  9(002).*/
                public IntBasis WWORK_QTDE12 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05        WWORK-QTDE  REDEFINES  WWORK-QTDE01                                  PIC S9(004)V99.*/
            }
            private _REDEF_DoubleBasis _wwork_qtde { get; set; }
            public _REDEF_DoubleBasis WWORK_QTDE
            {
                get { _wwork_qtde = new _REDEF_DoubleBasis(new PIC("S9", "004", "S9(004)V99."), 2); ; _.Move(WWORK_QTDE01, _wwork_qtde); VarBasis.RedefinePassValue(WWORK_QTDE01, _wwork_qtde, WWORK_QTDE01); _wwork_qtde.ValueChanged += () => { _.Move(_wwork_qtde, WWORK_QTDE01); }; return _wwork_qtde; }
                set { VarBasis.RedefinePassValue(value, _wwork_qtde, WWORK_QTDE01); }
            }  //Redefines
            /*"    05        AC-PAGINA           PIC  9(003)    VALUE ZEROS.*/
            public IntBasis AC_PAGINA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"    05        AC-CONTA1           PIC  9(006)    VALUE ZEROS.*/
            public IntBasis AC_CONTA1 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-CONTA-910        PIC  9(006)    VALUE ZEROS.*/
            public IntBasis AC_CONTA_910 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-I-RELATORIOS     PIC S9(005)    COMP-3 VALUE +0*/
            public IntBasis AC_I_RELATORIOS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"    05        WS-IMPMORACID       PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis WS_IMPMORACID { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05        WS-IMPMORESPO       PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis WS_IMPMORESPO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05        WS-VLPRMTOT         PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis WS_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05        WS-VLPREMIO         PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis WS_VLPREMIO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05        WS-VLMULTA          PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis WS_VLMULTA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05        WS-OCORR            PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WS_OCORR { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        WS-AMARRADO         PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WS_AMARRADO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        WS-SEQ              PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WS_SEQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        WS-SEQ-INICIAL      PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WS_SEQ_INICIAL { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-QTD-OBJ          PIC  9(006)    VALUE ZEROS.*/
            public IntBasis AC_QTD_OBJ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        WS-CONTROLE         PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WS_CONTROLE { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        WS-CONTR-AMAR       PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WS_CONTR_AMAR { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        WS-CONTR-OBJ        PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WS_CONTR_OBJ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        WS-CONTR-200        PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WS_CONTR_200 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        WS-CONTR-PRODU      PIC  X(001).*/
            public StringBasis WS_CONTR_PRODU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05        WS-NUM-APOLICE-ANT  PIC  9(013).*/
            public IntBasis WS_NUM_APOLICE_ANT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"    05        WS-CODSUBES-ANT     PIC  9(005).*/
            public IntBasis WS_CODSUBES_ANT { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"    05        WS-JDE-GER          PIC  X(008).*/
            public StringBasis WS_JDE_GER { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05        WS-JDE-ANT          PIC  X(008).*/
            public StringBasis WS_JDE_ANT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05        WS-CEP-G-ANT        PIC  9(010).*/
            public IntBasis WS_CEP_G_ANT { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"    05        WS-NOME-COR-ANT.*/
            public VG0267B_WS_NOME_COR_ANT WS_NOME_COR_ANT { get; set; } = new VG0267B_WS_NOME_COR_ANT();
            public class VG0267B_WS_NOME_COR_ANT : VarBasis
            {
                /*"      10      WS-FAIXA1-ANT       PIC  9(008).*/
                public IntBasis WS_FAIXA1_ANT { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"      10      WS-FAIXA2-ANT       PIC  9(008).*/
                public IntBasis WS_FAIXA2_ANT { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"      10      WS-NOME-ANT         PIC  X(030).*/
                public StringBasis WS_NOME_ANT { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"    05        WS-CHAVE-ATU.*/
            }
            public VG0267B_WS_CHAVE_ATU WS_CHAVE_ATU { get; set; } = new VG0267B_WS_CHAVE_ATU();
            public class VG0267B_WS_CHAVE_ATU : VarBasis
            {
                /*"       10     WS-FORMU-ATU        PIC  X(008).*/
                public StringBasis WS_FORMU_ATU { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"       10     WS-PRODU-ATU        PIC  9(004).*/
                public IntBasis WS_PRODU_ATU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05        WS-CHAVE-ANT.*/
            }
            public VG0267B_WS_CHAVE_ANT WS_CHAVE_ANT { get; set; } = new VG0267B_WS_CHAVE_ANT();
            public class VG0267B_WS_CHAVE_ANT : VarBasis
            {
                /*"       10     WS-FORMU-ANT        PIC  X(008).*/
                public StringBasis WS_FORMU_ANT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"       10     WS-PRODU-ANT        PIC  9(004).*/
                public IntBasis WS_PRODU_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05        WS-CEP-ANT          PIC  9(005).*/
            }
            public IntBasis WS_CEP_ANT { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"    05        WS-COMPL-ANT        PIC  9(003).*/
            public IntBasis WS_COMPL_ANT { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"    05        WS-INF              PIC  9(009).*/
            public IntBasis WS_INF { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    05        WS-SUP              PIC  9(009).*/
            public IntBasis WS_SUP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    05        WS-IND              PIC S9(004)    VALUE +0 COMP.*/
            public IntBasis WS_IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        WIND                PIC S9(004)    VALUE +0 COMP.*/
            public IntBasis WIND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        WIND1               PIC S9(004)    VALUE +0 COMP.*/
            public IntBasis WIND1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        WINDM               PIC S9(004)    VALUE +0 COMP.*/
            public IntBasis WINDM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        WINDH               PIC S9(004)    VALUE +0 COMP.*/
            public IntBasis WINDH { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        IDX-IND1            PIC S9(004)    VALUE +0 COMP.*/
            public IntBasis IDX_IND1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        IDX-IND2            PIC S9(004)    VALUE +0 COMP.*/
            public IntBasis IDX_IND2 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        INF                 PIC S9(009)    COMP.*/
            public IntBasis INF { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    05        SUP                 PIC S9(009)    COMP.*/
            public IntBasis SUP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    05        DEST-NUM-CEP.*/
            public VG0267B_DEST_NUM_CEP DEST_NUM_CEP { get; set; } = new VG0267B_DEST_NUM_CEP();
            public class VG0267B_DEST_NUM_CEP : VarBasis
            {
                /*"      15      DEST-CEP            PIC  9(005)    VALUE ZEROS.*/
                public IntBasis DEST_CEP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
                /*"      15      DEST-CEP-COMPL      PIC  9(003)    VALUE ZEROS.*/
                public IntBasis DEST_CEP_COMPL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
                /*"    05        WS-CNPJ             PIC  9(015).*/
            }
            public IntBasis WS_CNPJ { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05        WS-CNPJ-R           REDEFINES              WS-CNPJ.*/
            private _REDEF_VG0267B_WS_CNPJ_R _ws_cnpj_r { get; set; }
            public _REDEF_VG0267B_WS_CNPJ_R WS_CNPJ_R
            {
                get { _ws_cnpj_r = new _REDEF_VG0267B_WS_CNPJ_R(); _.Move(WS_CNPJ, _ws_cnpj_r); VarBasis.RedefinePassValue(WS_CNPJ, _ws_cnpj_r, WS_CNPJ); _ws_cnpj_r.ValueChanged += () => { _.Move(_ws_cnpj_r, WS_CNPJ); }; return _ws_cnpj_r; }
                set { VarBasis.RedefinePassValue(value, _ws_cnpj_r, WS_CNPJ); }
            }  //Redefines
            public class _REDEF_VG0267B_WS_CNPJ_R : VarBasis
            {
                /*"      10      WS-NRCNPJ1          PIC  9(009).*/
                public IntBasis WS_NRCNPJ1 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"      10      WS-NRCNPJ2          PIC  9(004).*/
                public IntBasis WS_NRCNPJ2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      WS-DVCNPJ           PIC  9(002).*/
                public IntBasis WS_DVCNPJ { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05        WS-DATA-SQL.*/

                public _REDEF_VG0267B_WS_CNPJ_R()
                {
                    WS_NRCNPJ1.ValueChanged += OnValueChanged;
                    WS_NRCNPJ2.ValueChanged += OnValueChanged;
                    WS_DVCNPJ.ValueChanged += OnValueChanged;
                }

            }
            public VG0267B_WS_DATA_SQL WS_DATA_SQL { get; set; } = new VG0267B_WS_DATA_SQL();
            public class VG0267B_WS_DATA_SQL : VarBasis
            {
                /*"      10      WS-ANO-SQL          PIC  9(004).*/
                public IntBasis WS_ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_165 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-MES-SQL          PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WS_MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"      10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_166 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-DIA-SQL          PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WS_DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05        WS-DATA1.*/
            }
            public VG0267B_WS_DATA1 WS_DATA1 { get; set; } = new VG0267B_WS_DATA1();
            public class VG0267B_WS_DATA1 : VarBasis
            {
                /*"      10      WS-ANO1             PIC  9(004).*/
                public IntBasis WS_ANO1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_167 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-MES1             PIC  9(002).*/
                public IntBasis WS_MES1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_168 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-DIA1             PIC  9(002).*/
                public IntBasis WS_DIA1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05        WS-DATA2.*/
            }
            public VG0267B_WS_DATA2 WS_DATA2 { get; set; } = new VG0267B_WS_DATA2();
            public class VG0267B_WS_DATA2 : VarBasis
            {
                /*"      10      WS-ANO2             PIC  9(004).*/
                public IntBasis WS_ANO2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_169 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-MES2             PIC  9(002).*/
                public IntBasis WS_MES2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_170 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-DIA2             PIC  9(002).*/
                public IntBasis WS_DIA2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05        WS-DATA.*/
            }
            public VG0267B_WS_DATA WS_DATA { get; set; } = new VG0267B_WS_DATA();
            public class VG0267B_WS_DATA : VarBasis
            {
                /*"      10      WS-DIA              PIC  9(002).*/
                public IntBasis WS_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_171 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10      WS-MES              PIC  9(002).*/
                public IntBasis WS_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_172 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10      WS-ANO              PIC  9(004).*/
                public IntBasis WS_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05        WS-DTVENCTO-SQL.*/
            }
            public VG0267B_WS_DTVENCTO_SQL WS_DTVENCTO_SQL { get; set; } = new VG0267B_WS_DTVENCTO_SQL();
            public class VG0267B_WS_DTVENCTO_SQL : VarBasis
            {
                /*"      10      WS-ANO-VCT          PIC  9(004).*/
                public IntBasis WS_ANO_VCT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_173 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-MES-VCT          PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WS_MES_VCT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"      10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_174 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-DIA-VCT          PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WS_DIA_VCT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05        WS-CERTIF           PIC  9(015).*/
            }
            public IntBasis WS_CERTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05        WS-CERTIF-R         REDEFINES WS-CERTIF.*/
            private _REDEF_VG0267B_WS_CERTIF_R _ws_certif_r { get; set; }
            public _REDEF_VG0267B_WS_CERTIF_R WS_CERTIF_R
            {
                get { _ws_certif_r = new _REDEF_VG0267B_WS_CERTIF_R(); _.Move(WS_CERTIF, _ws_certif_r); VarBasis.RedefinePassValue(WS_CERTIF, _ws_certif_r, WS_CERTIF); _ws_certif_r.ValueChanged += () => { _.Move(_ws_certif_r, WS_CERTIF); }; return _ws_certif_r; }
                set { VarBasis.RedefinePassValue(value, _ws_certif_r, WS_CERTIF); }
            }  //Redefines
            public class _REDEF_VG0267B_WS_CERTIF_R : VarBasis
            {
                /*"      10      WS-NRCERTIF         PIC  9(014).*/
                public IntBasis WS_NRCERTIF { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                /*"      10      WS-DVCERTIF         PIC  9(001).*/
                public IntBasis WS_DVCERTIF { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05        WS-TITULO           PIC  9(013).*/

                public _REDEF_VG0267B_WS_CERTIF_R()
                {
                    WS_NRCERTIF.ValueChanged += OnValueChanged;
                    WS_DVCERTIF.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_TITULO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"    05        WS-TITULO-R         REDEFINES WS-TITULO.*/
            private _REDEF_VG0267B_WS_TITULO_R _ws_titulo_r { get; set; }
            public _REDEF_VG0267B_WS_TITULO_R WS_TITULO_R
            {
                get { _ws_titulo_r = new _REDEF_VG0267B_WS_TITULO_R(); _.Move(WS_TITULO, _ws_titulo_r); VarBasis.RedefinePassValue(WS_TITULO, _ws_titulo_r, WS_TITULO); _ws_titulo_r.ValueChanged += () => { _.Move(_ws_titulo_r, WS_TITULO); }; return _ws_titulo_r; }
                set { VarBasis.RedefinePassValue(value, _ws_titulo_r, WS_TITULO); }
            }  //Redefines
            public class _REDEF_VG0267B_WS_TITULO_R : VarBasis
            {
                /*"      10      WS-NRTIT            PIC  9(012).*/
                public IntBasis WS_NRTIT { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"      10      WS-DVTITULO         PIC  9(001).*/
                public IntBasis WS_DVTITULO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05        WS-DATA-I.*/

                public _REDEF_VG0267B_WS_TITULO_R()
                {
                    WS_NRTIT.ValueChanged += OnValueChanged;
                    WS_DVTITULO.ValueChanged += OnValueChanged;
                }

            }
            public VG0267B_WS_DATA_I WS_DATA_I { get; set; } = new VG0267B_WS_DATA_I();
            public class VG0267B_WS_DATA_I : VarBasis
            {
                /*"      10      WS-DIA-I            PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WS_DIA_I { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"      10      FILLERB1            PIC  X(001).*/
                public StringBasis FILLERB1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-MES-I            PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WS_MES_I { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"      10      FILLERB2            PIC  X(001).*/
                public StringBasis FILLERB2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-ANO-I            PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WS_ANO_I { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    05        WHORA-CURR          PIC  X(008)    VALUE SPACES.*/
            }
            public StringBasis WHORA_CURR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"    05        WS-NOME-RAZAO.*/
            public VG0267B_WS_NOME_RAZAO WS_NOME_RAZAO { get; set; } = new VG0267B_WS_NOME_RAZAO();
            public class VG0267B_WS_NOME_RAZAO : VarBasis
            {
                /*"      10      WS-LETRA-NOME       OCCURS 41 TIMES                                  PIC  X(001).*/
                public ListBasis<StringBasis, string> WS_LETRA_NOME { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(001)."), 41);
                /*"    05        WS-NUM-CEP-AUX      PIC  9(008).*/
            }
            public IntBasis WS_NUM_CEP_AUX { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05        WS-NUM-CEP-AUX-R    REDEFINES              WS-NUM-CEP-AUX.*/
            private _REDEF_VG0267B_WS_NUM_CEP_AUX_R _ws_num_cep_aux_r { get; set; }
            public _REDEF_VG0267B_WS_NUM_CEP_AUX_R WS_NUM_CEP_AUX_R
            {
                get { _ws_num_cep_aux_r = new _REDEF_VG0267B_WS_NUM_CEP_AUX_R(); _.Move(WS_NUM_CEP_AUX, _ws_num_cep_aux_r); VarBasis.RedefinePassValue(WS_NUM_CEP_AUX, _ws_num_cep_aux_r, WS_NUM_CEP_AUX); _ws_num_cep_aux_r.ValueChanged += () => { _.Move(_ws_num_cep_aux_r, WS_NUM_CEP_AUX); }; return _ws_num_cep_aux_r; }
                set { VarBasis.RedefinePassValue(value, _ws_num_cep_aux_r, WS_NUM_CEP_AUX); }
            }  //Redefines
            public class _REDEF_VG0267B_WS_NUM_CEP_AUX_R : VarBasis
            {
                /*"      10      WS-CEP-AUX          PIC  9(005).*/
                public IntBasis WS_CEP_AUX { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"      10      WS-CEP-COMPL-AUX    PIC  9(003).*/
                public IntBasis WS_CEP_COMPL_AUX { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    05        WS-NUM-CEP-AUX-R1   REDEFINES              WS-NUM-CEP-AUX.*/

                public _REDEF_VG0267B_WS_NUM_CEP_AUX_R()
                {
                    WS_CEP_AUX.ValueChanged += OnValueChanged;
                    WS_CEP_COMPL_AUX.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_VG0267B_WS_NUM_CEP_AUX_R1 _ws_num_cep_aux_r1 { get; set; }
            public _REDEF_VG0267B_WS_NUM_CEP_AUX_R1 WS_NUM_CEP_AUX_R1
            {
                get { _ws_num_cep_aux_r1 = new _REDEF_VG0267B_WS_NUM_CEP_AUX_R1(); _.Move(WS_NUM_CEP_AUX, _ws_num_cep_aux_r1); VarBasis.RedefinePassValue(WS_NUM_CEP_AUX, _ws_num_cep_aux_r1, WS_NUM_CEP_AUX); _ws_num_cep_aux_r1.ValueChanged += () => { _.Move(_ws_num_cep_aux_r1, WS_NUM_CEP_AUX); }; return _ws_num_cep_aux_r1; }
                set { VarBasis.RedefinePassValue(value, _ws_num_cep_aux_r1, WS_NUM_CEP_AUX); }
            }  //Redefines
            public class _REDEF_VG0267B_WS_NUM_CEP_AUX_R1 : VarBasis
            {
                /*"      10      WS-CEP-COMPL-AUX1   PIC  9(003).*/
                public IntBasis WS_CEP_COMPL_AUX1 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"      10      WS-CEP-AUX1         PIC  9(005).*/
                public IntBasis WS_CEP_AUX1 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"    05        WS-CHAVE            PIC  X(021).*/

                public _REDEF_VG0267B_WS_NUM_CEP_AUX_R1()
                {
                    WS_CEP_COMPL_AUX1.ValueChanged += OnValueChanged;
                    WS_CEP_AUX1.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_CHAVE { get; set; } = new StringBasis(new PIC("X", "21", "X(021)."), @"");
            /*"    05        WS-CHAVE-R          REDEFINES              WS-CHAVE.*/
            private _REDEF_VG0267B_WS_CHAVE_R _ws_chave_r { get; set; }
            public _REDEF_VG0267B_WS_CHAVE_R WS_CHAVE_R
            {
                get { _ws_chave_r = new _REDEF_VG0267B_WS_CHAVE_R(); _.Move(WS_CHAVE, _ws_chave_r); VarBasis.RedefinePassValue(WS_CHAVE, _ws_chave_r, WS_CHAVE); _ws_chave_r.ValueChanged += () => { _.Move(_ws_chave_r, WS_CHAVE); }; return _ws_chave_r; }
                set { VarBasis.RedefinePassValue(value, _ws_chave_r, WS_CHAVE); }
            }  //Redefines
            public class _REDEF_VG0267B_WS_CHAVE_R : VarBasis
            {
                /*"      10      WS-NUM-APOLICE      PIC  9(013).*/
                public IntBasis WS_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"      10      WS-CODSUBES         PIC  9(005).*/
                public IntBasis WS_CODSUBES { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"      10      WS-CODOPER          PIC  9(003).*/
                public IntBasis WS_CODOPER { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    05        AC-LIDOS            PIC  9(009)    VALUE ZEROES.*/

                public _REDEF_VG0267B_WS_CHAVE_R()
                {
                    WS_NUM_APOLICE.ValueChanged += OnValueChanged;
                    WS_CODSUBES.ValueChanged += OnValueChanged;
                    WS_CODOPER.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05        AC-CONTA            PIC  9(009)    VALUE ZEROES.*/
            public IntBasis AC_CONTA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05        AC-IMPRESSOS        PIC  9(009)    VALUE ZEROS.*/
            public IntBasis AC_IMPRESSOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05        AC-BOLETOS-ATR      PIC  9(006)    VALUE ZEROS.*/
            public IntBasis AC_BOLETOS_ATR { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        WINSERE-HEA         PIC  X(003)    VALUE 'SIM'.*/
            public StringBasis WINSERE_HEA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"SIM");
            /*"    05        WFIM-V1SISTEMA      PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1SISTEMA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        WFIM-V1AGENCEF      PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1AGENCEF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        WFIM-V0FAIXACEP     PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V0FAIXACEP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        WFIM-V0HISTCOBVA    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V0HISTCOBVA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        WFIM-V0MSGCOBR      PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V0MSGCOBR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        WFIM-V0PARCELVA     PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V0PARCELVA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        WFIM-V0DIFPARCEL    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V0DIFPARCEL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        WFIM-SORT           PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_SORT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        WFIM-TABELA         PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_TABELA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        WTEM-MULTIMSG       PIC  X(001)    VALUE SPACES.*/
            public StringBasis WTEM_MULTIMSG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        WTEM-PRODUTO        PIC  X(001)    VALUE SPACES.*/
            public StringBasis WTEM_PRODUTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05        LK-PROSOMU1.*/
            public VG0267B_LK_PROSOMU1 LK_PROSOMU1 { get; set; } = new VG0267B_LK_PROSOMU1();
            public class VG0267B_LK_PROSOMU1 : VarBasis
            {
                /*"      10      LK-DATA-SOM         PIC  9(008).*/
                public IntBasis LK_DATA_SOM { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"      10      LK-DATA-SOM-R       REDEFINES              LK-DATA-SOM.*/
                private _REDEF_VG0267B_LK_DATA_SOM_R _lk_data_som_r { get; set; }
                public _REDEF_VG0267B_LK_DATA_SOM_R LK_DATA_SOM_R
                {
                    get { _lk_data_som_r = new _REDEF_VG0267B_LK_DATA_SOM_R(); _.Move(LK_DATA_SOM, _lk_data_som_r); VarBasis.RedefinePassValue(LK_DATA_SOM, _lk_data_som_r, LK_DATA_SOM); _lk_data_som_r.ValueChanged += () => { _.Move(_lk_data_som_r, LK_DATA_SOM); }; return _lk_data_som_r; }
                    set { VarBasis.RedefinePassValue(value, _lk_data_som_r, LK_DATA_SOM); }
                }  //Redefines
                public class _REDEF_VG0267B_LK_DATA_SOM_R : VarBasis
                {
                    /*"        15    LK-DIA-SOM          PIC  9(002).*/
                    public IntBasis LK_DIA_SOM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"        15    LK-MES-SOM          PIC  9(002).*/
                    public IntBasis LK_MES_SOM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"        15    LK-ANO-SOM          PIC  9(004).*/
                    public IntBasis LK_ANO_SOM { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      10      LK-QTDIAS           PIC S9(005)    COMP-3 VALUE +1*/

                    public _REDEF_VG0267B_LK_DATA_SOM_R()
                    {
                        LK_DIA_SOM.ValueChanged += OnValueChanged;
                        LK_MES_SOM.ValueChanged += OnValueChanged;
                        LK_ANO_SOM.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis LK_QTDIAS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"), +1);
                /*"      10      LK-DATA-CALC        PIC  9(008).*/
                public IntBasis LK_DATA_CALC { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"      10      LK-DATA-CALC-R      REDEFINES              LK-DATA-CALC.*/
                private _REDEF_VG0267B_LK_DATA_CALC_R _lk_data_calc_r { get; set; }
                public _REDEF_VG0267B_LK_DATA_CALC_R LK_DATA_CALC_R
                {
                    get { _lk_data_calc_r = new _REDEF_VG0267B_LK_DATA_CALC_R(); _.Move(LK_DATA_CALC, _lk_data_calc_r); VarBasis.RedefinePassValue(LK_DATA_CALC, _lk_data_calc_r, LK_DATA_CALC); _lk_data_calc_r.ValueChanged += () => { _.Move(_lk_data_calc_r, LK_DATA_CALC); }; return _lk_data_calc_r; }
                    set { VarBasis.RedefinePassValue(value, _lk_data_calc_r, LK_DATA_CALC); }
                }  //Redefines
                public class _REDEF_VG0267B_LK_DATA_CALC_R : VarBasis
                {
                    /*"        15    LK-DIA-CALC         PIC  9(002).*/
                    public IntBasis LK_DIA_CALC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"        15    LK-MES-CALC         PIC  9(002).*/
                    public IntBasis LK_MES_CALC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"        15    LK-ANO-CALC         PIC  9(004).*/
                    public IntBasis LK_ANO_CALC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"    05      RAMOCOMP-PCT-IOCC-RAMO PIC S9(3)V9(2) USAGE COMP-3.*/

                    public _REDEF_VG0267B_LK_DATA_CALC_R()
                    {
                        LK_DIA_CALC.ValueChanged += OnValueChanged;
                        LK_MES_CALC.ValueChanged += OnValueChanged;
                        LK_ANO_CALC.ValueChanged += OnValueChanged;
                    }

                }
            }
            public DoubleBasis RAMOCOMP_PCT_IOCC_RAMO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
            /*"    05      V0SUBG-IND-IOF         PIC X(001) VALUE SPACES.*/
            public StringBasis V0SUBG_IND_IOF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05      WS-QTD-MUDA-VLR-VENC   PIC  9(006) VALUE ZEROS.*/
            public IntBasis WS_QTD_MUDA_VLR_VENC { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05      WS-QTD-DT-VENC-29      PIC  9(006) VALUE ZEROS.*/
            public IntBasis WS_QTD_DT_VENC_29 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05      WS-QTD-SEM-NN-SIGCB    PIC  9(006) VALUE ZEROS.*/
            public IntBasis WS_QTD_SEM_NN_SIGCB { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05      WS-QTD-CUST-VENCIDA    PIC  9(006) VALUE ZEROS.*/
            public IntBasis WS_QTD_CUST_VENCIDA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05  WS-IDLG-VD                     PIC X(40).*/
            public StringBasis WS_IDLG_VD { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"  05   FILLER REDEFINES    WS-IDLG-VD.*/
            private _REDEF_VG0267B_FILLER_175 _filler_175 { get; set; }
            public _REDEF_VG0267B_FILLER_175 FILLER_175
            {
                get { _filler_175 = new _REDEF_VG0267B_FILLER_175(); _.Move(WS_IDLG_VD, _filler_175); VarBasis.RedefinePassValue(WS_IDLG_VD, _filler_175, WS_IDLG_VD); _filler_175.ValueChanged += () => { _.Move(_filler_175, WS_IDLG_VD); }; return _filler_175; }
                set { VarBasis.RedefinePassValue(value, _filler_175, WS_IDLG_VD); }
            }  //Redefines
            public class _REDEF_VG0267B_FILLER_175 : VarBasis
            {
                /*"     10 WS-IDLG-VD-CERTIF            PIC 9(15).*/
                public IntBasis WS_IDLG_VD_CERTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(15)."));
                /*"     10 WS-IDLG-VD-PARC              PIC 9(04).*/
                public IntBasis WS_IDLG_VD_PARC { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"     10 WS-IDLG-VD-TIT               PIC 9(13).*/
                public IntBasis WS_IDLG_VD_TIT { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
                /*"     10 WS-IDLG-SEQ                  PIC 9(02).*/
                public IntBasis WS_IDLG_SEQ { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"     10 WS-IDLG-FILLER               PIC X(06).*/
                public StringBasis WS_IDLG_FILLER { get; set; } = new StringBasis(new PIC("X", "6", "X(06)."), @"");
                /*"01  WORK-JV1.*/

                public _REDEF_VG0267B_FILLER_175()
                {
                    WS_IDLG_VD_CERTIF.ValueChanged += OnValueChanged;
                    WS_IDLG_VD_PARC.ValueChanged += OnValueChanged;
                    WS_IDLG_VD_TIT.ValueChanged += OnValueChanged;
                    WS_IDLG_SEQ.ValueChanged += OnValueChanged;
                    WS_IDLG_FILLER.ValueChanged += OnValueChanged;
                }

            }
        }
        public VG0267B_WORK_JV1 WORK_JV1 { get; set; } = new VG0267B_WORK_JV1();
        public class VG0267B_WORK_JV1 : VarBasis
        {
            /*" 05 WS-JV1-IND-INI                   PIC S9(004) COMP-5 VALUE +0*/
            public IntBasis WS_JV1_IND_INI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*" 05 WS-JV1-IND-OUT                   PIC S9(004) COMP-5 VALUE +0*/
            public IntBasis WS_JV1_IND_OUT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*" 05 WS-JV1-LGTH-INI                  PIC S9(008) COMP-5 VALUE +0*/
            public IntBasis WS_JV1_LGTH_INI { get; set; } = new IntBasis(new PIC("S9", "8", "S9(008)"));
            /*" 05 WS-JV1-LGTH-OUT                  PIC S9(008) COMP-5 VALUE +0*/
            public IntBasis WS_JV1_LGTH_OUT { get; set; } = new IntBasis(new PIC("S9", "8", "S9(008)"));
            /*"01            TFO-I               PIC  9(004) COMP VALUE 0.*/
        }
        public IntBasis TFO_I { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"01            TAB-FO-QTD          PIC  9(004) COMP VALUE 0.*/
        public IntBasis TAB_FO_QTD { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"01            TAB-FORM-OBJECT.*/
        public VG0267B_TAB_FORM_OBJECT TAB_FORM_OBJECT { get; set; } = new VG0267B_TAB_FORM_OBJECT();
        public class VG0267B_TAB_FORM_OBJECT : VarBasis
        {
            /*"    05        FILLER              OCCURS 20 TIMES.*/
            public ListBasis<VG0267B_FILLER_176> FILLER_176 { get; set; } = new ListBasis<VG0267B_FILLER_176>(20);
            public class VG0267B_FILLER_176 : VarBasis
            {
                /*"      10      TAB-FO-FORMULARIO   PIC  X(008) VALUE SPACES.*/
                public StringBasis TAB_FO_FORMULARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"01            TAB-FILIAL.*/
            }
        }
        public VG0267B_TAB_FILIAL TAB_FILIAL { get; set; } = new VG0267B_TAB_FILIAL();
        public class VG0267B_TAB_FILIAL : VarBasis
        {
            /*"    05        FILLER              OCCURS 19 TIMES.*/
            public ListBasis<VG0267B_FILLER_177> FILLER_177 { get; set; } = new ListBasis<VG0267B_FILLER_177>(19);
            public class VG0267B_FILLER_177 : VarBasis
            {
                /*"      10      TAB-FONTE           PIC  9(04).*/
                public IntBasis TAB_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"      10      TAB-NOMEFTE         PIC  X(40).*/
                public StringBasis TAB_NOMEFTE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"      10      TAB-ENDERFTE        PIC  X(40).*/
                public StringBasis TAB_ENDERFTE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"      10      TAB-BAIRRO          PIC  X(20).*/
                public StringBasis TAB_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
                /*"      10      TAB-CIDADE          PIC  X(20).*/
                public StringBasis TAB_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
                /*"      10      TAB-CEP             PIC  9(08).*/
                public IntBasis TAB_CEP { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                /*"      10      TAB-UF              PIC  X(02).*/
                public StringBasis TAB_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
                /*"01            TABELA-CEP.*/
            }
        }
        public VG0267B_TABELA_CEP TABELA_CEP { get; set; } = new VG0267B_TABELA_CEP();
        public class VG0267B_TABELA_CEP : VarBasis
        {
            /*"    05        CEP                 OCCURS 2000 TIMES.*/
            public ListBasis<VG0267B_CEP> CEP { get; set; } = new ListBasis<VG0267B_CEP>(2000);
            public class VG0267B_CEP : VarBasis
            {
                /*"      10      TAB-FX-CEP-G        PIC  9(004).*/
                public IntBasis TAB_FX_CEP_G { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      TAB-FAIXAS.*/
                public VG0267B_TAB_FAIXAS TAB_FAIXAS { get; set; } = new VG0267B_TAB_FAIXAS();
                public class VG0267B_TAB_FAIXAS : VarBasis
                {
                    /*"        15    TAB-FX-INI          PIC  9(008).*/
                    public IntBasis TAB_FX_INI { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"        15    TAB-FX-FIM          PIC  9(008).*/
                    public IntBasis TAB_FX_FIM { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"        15    TAB-FX-NOME         PIC  X(072).*/
                    public StringBasis TAB_FX_NOME { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                    /*"        15    TAB-FX-CENTR        PIC  X(072).*/
                    public StringBasis TAB_FX_CENTR { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                    /*"01            TABELA-VALORES.*/
                }
            }
        }
        public VG0267B_TABELA_VALORES TABELA_VALORES { get; set; } = new VG0267B_TABELA_VALORES();
        public class VG0267B_TABELA_VALORES : VarBasis
        {
            /*"    05        TAB-VALORES         OCCURS    3 TIMES.*/
            public ListBasis<VG0267B_TAB_VALORES> TAB_VALORES { get; set; } = new ListBasis<VG0267B_TAB_VALORES>(3);
            public class VG0267B_TAB_VALORES : VarBasis
            {
                /*"      10      TAB-VLPRMTOT        PIC  9(013)V99.*/
                public DoubleBasis TAB_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"      10      TAB-VLPREMIO        PIC  9(013)V99.*/
                public DoubleBasis TAB_VLPREMIO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"      10      TAB-VLMULTA         PIC  9(013)V99.*/
                public DoubleBasis TAB_VLMULTA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"01            TABELA-HISTORICO.*/
            }
        }
        public VG0267B_TABELA_HISTORICO TABELA_HISTORICO { get; set; } = new VG0267B_TABELA_HISTORICO();
        public class VG0267B_TABELA_HISTORICO : VarBasis
        {
            /*"    05        TABH                OCCURS   10 TIMES.*/
            public ListBasis<VG0267B_TABH> TABH { get; set; } = new ListBasis<VG0267B_TABH>(10);
            public class VG0267B_TABH : VarBasis
            {
                /*"      10      TABH-DESCRICAO      PIC  X(030).*/
                public StringBasis TABH_DESCRICAO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"      10      TABH-MMREFER        PIC  9(002).*/
                public IntBasis TABH_MMREFER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      TABH-AAREFER        PIC  9(004).*/
                public IntBasis TABH_AAREFER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      TABH-VLPRMTOT       PIC S9(013)V99.*/
                public DoubleBasis TABH_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99."), 2);
                /*"01            TABELA-TOTAIS.*/
            }
        }
        public VG0267B_TABELA_TOTAIS TABELA_TOTAIS { get; set; } = new VG0267B_TABELA_TOTAIS();
        public class VG0267B_TABELA_TOTAIS : VarBasis
        {
            /*"    05        TAB-TOTAIS          OCCURS  2000 TIMES.*/
            public ListBasis<VG0267B_TAB_TOTAIS> TAB_TOTAIS { get; set; } = new ListBasis<VG0267B_TAB_TOTAIS>(2000);
            public class VG0267B_TAB_TOTAIS : VarBasis
            {
                /*"      10      TAB1-OBJI           PIC  9(006).*/
                public IntBasis TAB1_OBJI { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"      10      TAB1-OBJF           PIC  9(006).*/
                public IntBasis TAB1_OBJF { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"      10      TAB1-AMARI          PIC  9(006).*/
                public IntBasis TAB1_AMARI { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"      10      TAB1-AMARF          PIC  9(006).*/
                public IntBasis TAB1_AMARF { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"      10      TAB1-QTD-OBJ        PIC  9(006).*/
                public IntBasis TAB1_QTD_OBJ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"      10      TAB1-QTD-AMAR       PIC  9(006).*/
                public IntBasis TAB1_QTD_AMAR { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"01            TABELA-MSG.*/
            }
        }
        public VG0267B_TABELA_MSG TABELA_MSG { get; set; } = new VG0267B_TABELA_MSG();
        public class VG0267B_TABELA_MSG : VarBasis
        {
            /*"    05        TAB-MSG             OCCURS 3000  TIMES.*/
            public ListBasis<VG0267B_TAB_MSG> TAB_MSG { get; set; } = new ListBasis<VG0267B_TAB_MSG>(3000);
            public class VG0267B_TAB_MSG : VarBasis
            {
                /*"      10      TABJ-CHAVE          PIC  X(021).*/
                public StringBasis TABJ_CHAVE { get; set; } = new StringBasis(new PIC("X", "21", "X(021)."), @"");
                /*"      10      TABJ-CHAVE-R        REDEFINES              TABJ-CHAVE.*/
                private _REDEF_VG0267B_TABJ_CHAVE_R _tabj_chave_r { get; set; }
                public _REDEF_VG0267B_TABJ_CHAVE_R TABJ_CHAVE_R
                {
                    get { _tabj_chave_r = new _REDEF_VG0267B_TABJ_CHAVE_R(); _.Move(TABJ_CHAVE, _tabj_chave_r); VarBasis.RedefinePassValue(TABJ_CHAVE, _tabj_chave_r, TABJ_CHAVE); _tabj_chave_r.ValueChanged += () => { _.Move(_tabj_chave_r, TABJ_CHAVE); }; return _tabj_chave_r; }
                    set { VarBasis.RedefinePassValue(value, _tabj_chave_r, TABJ_CHAVE); }
                }  //Redefines
                public class _REDEF_VG0267B_TABJ_CHAVE_R : VarBasis
                {
                    /*"        15    TABJ-NUM-APOLICE    PIC  9(013).*/
                    public IntBasis TABJ_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                    /*"        15    TABJ-CODSUBES       PIC  9(005).*/
                    public IntBasis TABJ_CODSUBES { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                    /*"        15    TABJ-CODOPER        PIC  9(003).*/
                    public IntBasis TABJ_CODOPER { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                    /*"      10      TABJ-JDE            PIC  X(008).*/

                    public _REDEF_VG0267B_TABJ_CHAVE_R()
                    {
                        TABJ_NUM_APOLICE.ValueChanged += OnValueChanged;
                        TABJ_CODSUBES.ValueChanged += OnValueChanged;
                        TABJ_CODOPER.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis TABJ_JDE { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"      10      TABJ-JDL            PIC  X(008).*/
                public StringBasis TABJ_JDL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"01            TABELA-MESES.*/
            }
        }
        public VG0267B_TABELA_MESES TABELA_MESES { get; set; } = new VG0267B_TABELA_MESES();
        public class VG0267B_TABELA_MESES : VarBasis
        {
            /*"    05        TAB-MESES.*/
            public VG0267B_TAB_MESES TAB_MESES { get; set; } = new VG0267B_TAB_MESES();
            public class VG0267B_TAB_MESES : VarBasis
            {
                /*"      10      FILLER              PIC  X(009)  VALUE '  JANEIRO'*/
                public StringBasis FILLER_178 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"  JANEIRO");
                /*"      10      FILLER              PIC  X(009)  VALUE 'FEVEREIRO'*/
                public StringBasis FILLER_179 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"FEVEREIRO");
                /*"      10      FILLER              PIC  X(009)  VALUE '    MARCO'*/
                public StringBasis FILLER_180 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    MARCO");
                /*"      10      FILLER              PIC  X(009)  VALUE '    ABRIL'*/
                public StringBasis FILLER_181 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    ABRIL");
                /*"      10      FILLER              PIC  X(009)  VALUE '     MAIO'*/
                public StringBasis FILLER_182 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"     MAIO");
                /*"      10      FILLER              PIC  X(009)  VALUE '    JUNHO'*/
                public StringBasis FILLER_183 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    JUNHO");
                /*"      10      FILLER              PIC  X(009)  VALUE '    JULHO'*/
                public StringBasis FILLER_184 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    JULHO");
                /*"      10      FILLER              PIC  X(009)  VALUE '   AGOSTO'*/
                public StringBasis FILLER_185 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"   AGOSTO");
                /*"      10      FILLER              PIC  X(009)  VALUE ' SETEMBRO'*/
                public StringBasis FILLER_186 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" SETEMBRO");
                /*"      10      FILLER              PIC  X(009)  VALUE '  OUTUBRO'*/
                public StringBasis FILLER_187 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"  OUTUBRO");
                /*"      10      FILLER              PIC  X(009)  VALUE ' NOVEMBRO'*/
                public StringBasis FILLER_188 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" NOVEMBRO");
                /*"      10      FILLER              PIC  X(009)  VALUE ' DEZEMBRO'*/
                public StringBasis FILLER_189 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" DEZEMBRO");
                /*"    05        TAB-MESES-R         REDEFINES              TAB-MESES.*/
            }
            private _REDEF_VG0267B_TAB_MESES_R _tab_meses_r { get; set; }
            public _REDEF_VG0267B_TAB_MESES_R TAB_MESES_R
            {
                get { _tab_meses_r = new _REDEF_VG0267B_TAB_MESES_R(); _.Move(TAB_MESES, _tab_meses_r); VarBasis.RedefinePassValue(TAB_MESES, _tab_meses_r, TAB_MESES); _tab_meses_r.ValueChanged += () => { _.Move(_tab_meses_r, TAB_MESES); }; return _tab_meses_r; }
                set { VarBasis.RedefinePassValue(value, _tab_meses_r, TAB_MESES); }
            }  //Redefines
            public class _REDEF_VG0267B_TAB_MESES_R : VarBasis
            {
                /*"      10      TAB-MES             OCCURS 12 TIMES                                  PIC  X(009).*/
                public ListBasis<StringBasis, string> TAB_MES { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "9", "X(009)."), 12);
                /*"01          PARAGRAFO           PIC  X(050).*/

                public _REDEF_VG0267B_TAB_MESES_R()
                {
                    TAB_MES.ValueChanged += OnValueChanged;
                }

            }
        }
        public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
        /*"01          WABEND.*/
        public VG0267B_WABEND WABEND { get; set; } = new VG0267B_WABEND();
        public class VG0267B_WABEND : VarBasis
        {
            /*"      05    FILLER              PIC  X(010) VALUE           ' VG0267B'.*/
            public StringBasis FILLER_190 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VG0267B");
            /*"      05    FILLER              PIC  X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_191 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"      05    WNR-EXEC-SQL        PIC  X(004) VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"      05    FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
            public StringBasis FILLER_192 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"      05    WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            /*"01     LK-PARAM.*/
        }
        public VG0267B_LK_PARAM LK_PARAM { get; set; } = new VG0267B_LK_PARAM();
        public class VG0267B_LK_PARAM : VarBasis
        {
            /*" 05    FILLER                        PIC  X(002).*/
            public StringBasis FILLER_193 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*" 05    LK-P-DATA-VENCIMENTO          PIC  X(010).*/
            public StringBasis LK_P_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        }


        public Copies.LBGE0350 LBGE0350 { get; set; } = new Copies.LBGE0350();
        public Copies.LBGE0355 LBGE0355 { get; set; } = new Copies.LBGE0355();
        public Dclgens.PRODUTO PRODUTO { get; set; } = new Dclgens.PRODUTO();
        public Dclgens.GEOBJECT GEOBJECT { get; set; } = new Dclgens.GEOBJECT();
        public Dclgens.GE101 GE101 { get; set; } = new Dclgens.GE101();
        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public VG0267B_V1AGENCEF V1AGENCEF { get; set; } = new VG0267B_V1AGENCEF();
        public VG0267B_CHISTCOB CHISTCOB { get; set; } = new VG0267B_CHISTCOB();
        public VG0267B_CFAIXACEP CFAIXACEP { get; set; } = new VG0267B_CFAIXACEP();
        public VG0267B_CHISTCOB1 CHISTCOB1 { get; set; } = new VG0267B_CHISTCOB1();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(VG0267B_LK_PARAM VG0267B_LK_PARAM_P, string RVG0267B_FILE_NAME_P, string SVG0267B_FILE_NAME_P, string FVG0267B_FILE_NAME_P) //PROCEDURE DIVISION USING 
        /*LK_PARAM*/
        {
            try
            {
                this.LK_PARAM = VG0267B_LK_PARAM_P;
                RVG0267B.SetFile(RVG0267B_FILE_NAME_P);
                SVG0267B.SetFile(SVG0267B_FILE_NAME_P);
                FVG0267B.SetFile(FVG0267B_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LK_PARAM, CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -1693- MOVE 'R0000-00-PRINCIPAL' TO PARAGRAFO. */
            _.Move("R0000-00-PRINCIPAL", PARAGRAFO);

            /*" -1694- DISPLAY ' ' */
            _.Display($" ");

            /*" -1696- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -1706- DISPLAY 'PROGRAMA VG0267B - VERSAO V.52 ' '- DEMANDA 582106 - 21/08/2024 - ' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) '-' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) */

            $"PROGRAMA VG0267B - VERSAO V.52 - DEMANDA 582106 - 21/08/2024 - FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)}-FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}"
            .Display();

            /*" -1708- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -1718- DISPLAY ' ' */
            _.Display($" ");

            /*" -1719- DISPLAY ' ' */
            _.Display($" ");

            /*" -1726- DISPLAY 'INICIOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"INICIOU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -1727- DISPLAY '                               ' */
            _.Display($"                               ");

            /*" -1730- DISPLAY '------------------------------------------------' . */
            _.Display($"------------------------------------------------");

            /*" -1732- MOVE ZEROS TO TABELA-TOTAIS. */
            _.Move(0, TABELA_TOTAIS);

            /*" -1734- PERFORM R0100-00-SELECT-V1SISTEMA. */

            R0100_00_SELECT_V1SISTEMA_SECTION();

            /*" -1735- IF WFIM-V1SISTEMA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1SISTEMA.IsEmpty())
            {

                /*" -1737- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -1739- INITIALIZE TAB-FILIAL. */
            _.Initialize(
                TAB_FILIAL
            );

            /*" -1741- PERFORM R0101-00-VALIDAR-LINKAGE */

            R0101_00_VALIDAR_LINKAGE_SECTION();

            /*" -1743- PERFORM R0150-00-DECLARE-V1AGENCEF. */

            R0150_00_DECLARE_V1AGENCEF_SECTION();

            /*" -1745- PERFORM R0160-00-FETCH-V1AGENCEF. */

            R0160_00_FETCH_V1AGENCEF_SECTION();

            /*" -1746- IF (WFIM-V1AGENCEF NOT EQUAL SPACES) */

            if ((!AREA_DE_WORK.WFIM_V1AGENCEF.IsEmpty()))
            {

                /*" -1747- DISPLAY 'R0000 - PROBLEMA NO FETCH DA V1AGENCIACEF' */
                _.Display($"R0000 - PROBLEMA NO FETCH DA V1AGENCIACEF");

                /*" -1749- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1754- PERFORM R0170-00-CARREGA-FILIAL VARYING IDX-IND1 FROM 1 BY 1 UNTIL IDX-IND1 > 19 OR WFIM-V1AGENCEF EQUAL 'S' . */

            for (AREA_DE_WORK.IDX_IND1.Value = 1; !(AREA_DE_WORK.IDX_IND1 > 19 || AREA_DE_WORK.WFIM_V1AGENCEF == "S"); AREA_DE_WORK.IDX_IND1.Value += 1)
            {

                R0170_00_CARREGA_FILIAL_SECTION();
            }

            /*" -1756- PERFORM R0300-00-DECLARE-V0HISTCOBVA. */

            R0300_00_DECLARE_V0HISTCOBVA_SECTION();

            /*" -1758- PERFORM R0310-00-FETCH-V0HISTCOBVA. */

            R0310_00_FETCH_V0HISTCOBVA_SECTION();

            /*" -1759- IF (WFIM-V0HISTCOBVA EQUAL 'S' ) */

            if ((AREA_DE_WORK.WFIM_V0HISTCOBVA == "S"))
            {

                /*" -1762- GO TO R9800-00-ENCERRA-SEM-SOLIC. */

                R9800_00_ENCERRA_SEM_SOLIC_SECTION(); //GOTO
                return;
            }


            /*" -1764- PERFORM R0400-00-CARREGA-V0FAIXACEP. */

            R0400_00_CARREGA_V0FAIXACEP_SECTION();

            /*" -1767- MOVE +200000 TO SORT-FILE-SIZE. */
            _.Move(+200000, SORT_FILE_SIZE);

            /*" -1773- SORT SVG0267B ON ASCENDING KEY SVA-FORMULARIO SVA-CODPRODU SVA-CEP-G SVA-NUM-CEP SVA-CODOPER INPUT PROCEDURE R0900-00-SELECIONA THRU R0900-FIM OUTPUT PROCEDURE R1800-00-IMPRIME THRU R1800-FIM. */
            SORT_RETURN.Value = SVG0267B.Sort("SVA-FORMULARIO,SVA-CODPRODU,SVA-CEP-G,SVA-NUM-CEP,SVA-CODOPER", () => R0900_00_SELECIONA_SECTION(), () => R1800_00_IMPRIME_SECTION());

            /*" -1776- IF (SORT-RETURN NOT EQUAL ZEROS) */

            if ((SORT_RETURN != 00))
            {

                /*" -1777- DISPLAY '*** VG0267B *** PROBLEMAS NO SORT ' */
                _.Display($"*** VG0267B *** PROBLEMAS NO SORT ");

                /*" -1778- DISPLAY '*** VG0267B *** SORT-RETURN = ' SORT-RETURN */
                _.Display($"*** VG0267B *** SORT-RETURN = {SORT_RETURN}");

                /*" -1779- MOVE 9 TO RETURN-CODE */
                _.Move(9, RETURN_CODE);

                /*" -1780- STOP RUN */

                throw new GoBack();   // => STOP RUN.

                /*" -1780- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -1786- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -1786- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1789- DISPLAY '---------------- VG0267B ----------------------' */
            _.Display($"---------------- VG0267B ----------------------");

            /*" -1790- DISPLAY 'LIDOS V0HISTCOBVA.....: ' AC-LIDOS. */
            _.Display($"LIDOS V0HISTCOBVA.....: {AREA_DE_WORK.AC_LIDOS}");

            /*" -1791- DISPLAY 'COBRANCAS IMPRESSAS...: ' AC-IMPRESSOS. */
            _.Display($"COBRANCAS IMPRESSAS...: {AREA_DE_WORK.AC_IMPRESSOS}");

            /*" -1792- DISPLAY 'BOLETOS EM ATRASO.....: ' AC-BOLETOS-ATR */
            _.Display($"BOLETOS EM ATRASO.....: {AREA_DE_WORK.AC_BOLETOS_ATR}");

            /*" -1793- DISPLAY 'MUDANCA DE VLR/DT-VENC: ' WS-QTD-MUDA-VLR-VENC */
            _.Display($"MUDANCA DE VLR/DT-VENC: {AREA_DE_WORK.WS_QTD_MUDA_VLR_VENC}");

            /*" -1794- DISPLAY 'QTD DT-VENC < 29 DIAS.: ' WS-QTD-DT-VENC-29 */
            _.Display($"QTD DT-VENC < 29 DIAS.: {AREA_DE_WORK.WS_QTD_DT_VENC_29}");

            /*" -1795- DISPLAY 'AGUARDANDO NN DO SAP..: ' WS-QTD-SEM-NN-SIGCB */
            _.Display($"AGUARDANDO NN DO SAP..: {AREA_DE_WORK.WS_QTD_SEM_NN_SIGCB}");

            /*" -1796- DISPLAY 'QTD CUSTODIA VENCIDA..: ' WS-QTD-CUST-VENCIDA */
            _.Display($"QTD CUSTODIA VENCIDA..: {AREA_DE_WORK.WS_QTD_CUST_VENCIDA}");

            /*" -1797- DISPLAY '-----------------------------------------------' */
            _.Display($"-----------------------------------------------");

            /*" -1798- DISPLAY '---------- VG0267B - TERMINO NORMAL -----------' */
            _.Display($"---------- VG0267B - TERMINO NORMAL -----------");

            /*" -1800- DISPLAY '-----------------------------------------------' */
            _.Display($"-----------------------------------------------");

            /*" -1800- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-SECTION */
        private void R0100_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -1809- MOVE 'R0100-00-SELECT-V1' TO PARAGRAFO. */
            _.Move("R0100-00-SELECT-V1", PARAGRAFO);

            /*" -1811- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", WABEND.WNR_EXEC_SQL);

            /*" -1824- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -1827- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1828- DISPLAY 'VG0267B - SISTEMA FI NAO ESTA CADASTRADO' */
                _.Display($"VG0267B - SISTEMA FI NAO ESTA CADASTRADO");

                /*" -1829- MOVE 'S' TO WFIM-V1SISTEMA */
                _.Move("S", AREA_DE_WORK.WFIM_V1SISTEMA);

                /*" -1831- GO TO R0100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1832- DISPLAY '* DATA LIMITE P/ IMP.: ' V1SIST-DATA-LIMITE */
            _.Display($"* DATA LIMITE P/ IMP.: {V1SIST_DATA_LIMITE}");

            /*" -1833- DISPLAY '* DATA LIMITE MINIMO.: ' V1SIST-DTMOVABE-30 */
            _.Display($"* DATA LIMITE MINIMO.: {V1SIST_DTMOVABE_30}");

            /*" -1833- DISPLAY ' ' . */
            _.Display($" ");

        }

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -1824- EXEC SQL SELECT DTMOVABE, MONTH(DTMOVABE), YEAR(DTMOVABE), DATE(DTMOVABE) + 20 DAYS, DATE(DTMOVABE) - 30 DAYS INTO :V1SIST-DTMOVABE, :V1SIST-MESREFER, :V1SIST-ANOREFER, :V1SIST-DATA-LIMITE, :V1SIST-DTMOVABE-30 FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'FI' END-EXEC. */

            var r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
                _.Move(executed_1.V1SIST_MESREFER, V1SIST_MESREFER);
                _.Move(executed_1.V1SIST_ANOREFER, V1SIST_ANOREFER);
                _.Move(executed_1.V1SIST_DATA_LIMITE, V1SIST_DATA_LIMITE);
                _.Move(executed_1.V1SIST_DTMOVABE_30, V1SIST_DTMOVABE_30);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0101-00-VALIDAR-LINKAGE-SECTION */
        private void R0101_00_VALIDAR_LINKAGE_SECTION()
        {
            /*" -1843- MOVE '011' TO WNR-EXEC-SQL. */
            _.Move("011", WABEND.WNR_EXEC_SQL);

            /*" -1844- IF LK-P-DATA-VENCIMENTO = SPACES */

            if (LK_PARAM.LK_P_DATA_VENCIMENTO.IsEmpty())
            {

                /*" -1845- DISPLAY 'R0101-00 - INFORMAR DATA DE VENCIMENTO ' */
                _.Display($"R0101-00 - INFORMAR DATA DE VENCIMENTO ");

                /*" -1846- DISPLAY '           VIA LINKAGE ' */
                _.Display($"           VIA LINKAGE ");

                /*" -1847- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1848- ELSE */
            }
            else
            {


                /*" -1856- IF NOT ( ( LK-P-DATA-VENCIMENTO(1:4) >= '1900' AND LK-P-DATA-VENCIMENTO(1:4) <= '9999' ) AND ( LK-P-DATA-VENCIMENTO(5:1) = '-' ) AND ( LK-P-DATA-VENCIMENTO(6:2) >= '01' AND LK-P-DATA-VENCIMENTO(6:2) <= '12' ) AND ( LK-P-DATA-VENCIMENTO(8:1) = '-' ) AND ( LK-P-DATA-VENCIMENTO(9:2) >= '01' AND LK-P-DATA-VENCIMENTO(9:2) <= '31' ) ) */

                if (!((LK_PARAM.LK_P_DATA_VENCIMENTO.Substring(1, 4) >= "1900" && LK_PARAM.LK_P_DATA_VENCIMENTO.Substring(1, 4) <= "9999") && (LK_PARAM.LK_P_DATA_VENCIMENTO.Substring(5, 1) == "-") && (LK_PARAM.LK_P_DATA_VENCIMENTO.Substring(6, 2) >= "01" && LK_PARAM.LK_P_DATA_VENCIMENTO.Substring(6, 2) <= "12") && (LK_PARAM.LK_P_DATA_VENCIMENTO.Substring(8, 1) == "-") && (LK_PARAM.LK_P_DATA_VENCIMENTO.Substring(9, 2) >= "01" && LK_PARAM.LK_P_DATA_VENCIMENTO.Substring(9, 2) <= "31")))
                {

                    /*" -1857- DISPLAY 'R0101-00 - DATA DE VENCIMENTO INVALIDA ' */
                    _.Display($"R0101-00 - DATA DE VENCIMENTO INVALIDA ");

                    /*" -1858- DISPLAY '         - ' LK-P-DATA-VENCIMENTO */
                    _.Display($"         - {LK_PARAM.LK_P_DATA_VENCIMENTO}");

                    /*" -1859- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1860- ELSE */
                }
                else
                {


                    /*" -1861- MOVE LK-P-DATA-VENCIMENTO TO WH-DATA-VENCIMENTO */
                    _.Move(LK_PARAM.LK_P_DATA_VENCIMENTO, WH_DATA_VENCIMENTO);

                    /*" -1862- END-IF */
                }


                /*" -1864- END-IF */
            }


            /*" -1866- DISPLAY 'LINKAGE - DATA VENCIMENTO = ' WH-DATA-VENCIMENTO */
            _.Display($"LINKAGE - DATA VENCIMENTO = {WH_DATA_VENCIMENTO}");

            /*" -1866- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0101_99_SAIDA*/

        [StopWatch]
        /*" R0150-00-DECLARE-V1AGENCEF-SECTION */
        private void R0150_00_DECLARE_V1AGENCEF_SECTION()
        {
            /*" -1878- MOVE 'R0150-00-DECLARE-V' TO PARAGRAFO. */
            _.Move("R0150-00-DECLARE-V", PARAGRAFO);

            /*" -1880- MOVE '0150' TO WNR-EXEC-SQL. */
            _.Move("0150", WABEND.WNR_EXEC_SQL);

            /*" -1896- PERFORM R0150_00_DECLARE_V1AGENCEF_DB_DECLARE_1 */

            R0150_00_DECLARE_V1AGENCEF_DB_DECLARE_1();

            /*" -1898- PERFORM R0150_00_DECLARE_V1AGENCEF_DB_OPEN_1 */

            R0150_00_DECLARE_V1AGENCEF_DB_OPEN_1();

            /*" -1901- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1902- DISPLAY 'R0150 - PROBLEMAS DECLARE (V1AGENCEF) ..' */
                _.Display($"R0150 - PROBLEMAS DECLARE (V1AGENCEF) ..");

                /*" -1903- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -1903- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0150-00-DECLARE-V1AGENCEF-DB-DECLARE-1 */
        public void R0150_00_DECLARE_V1AGENCEF_DB_DECLARE_1()
        {
            /*" -1896- EXEC SQL DECLARE V1AGENCEF CURSOR FOR SELECT DISTINCT B.COD_FONTE, C.NOMEFTE, C.ENDERFTE, C.BAIRRO, C.CIDADE, C.CEP, C.ESTADO FROM SEGUROS.V1AGENCIACEF A, SEGUROS.V1MALHACEF B, SEGUROS.V1FONTE C WHERE A.COD_ESCNEG > 99 AND A.COD_ESCNEG = B.COD_SUREG AND B.COD_FONTE = C.FONTE ORDER BY B.COD_FONTE END-EXEC. */
            V1AGENCEF = new VG0267B_V1AGENCEF(false);
            string GetQuery_V1AGENCEF()
            {
                var query = @$"SELECT DISTINCT B.COD_FONTE
							, 
							C.NOMEFTE
							, 
							C.ENDERFTE
							, 
							C.BAIRRO
							, 
							C.CIDADE
							, 
							C.CEP
							, 
							C.ESTADO 
							FROM SEGUROS.V1AGENCIACEF A
							, 
							SEGUROS.V1MALHACEF B
							, 
							SEGUROS.V1FONTE C 
							WHERE A.COD_ESCNEG > 99 
							AND A.COD_ESCNEG = B.COD_SUREG 
							AND B.COD_FONTE = C.FONTE 
							ORDER BY B.COD_FONTE";

                return query;
            }
            V1AGENCEF.GetQueryEvent += GetQuery_V1AGENCEF;

        }

        [StopWatch]
        /*" R0150-00-DECLARE-V1AGENCEF-DB-OPEN-1 */
        public void R0150_00_DECLARE_V1AGENCEF_DB_OPEN_1()
        {
            /*" -1898- EXEC SQL OPEN V1AGENCEF END-EXEC. */

            V1AGENCEF.Open();

        }

        [StopWatch]
        /*" R0300-00-DECLARE-V0HISTCOBVA-DB-DECLARE-1 */
        public void R0300_00_DECLARE_V0HISTCOBVA_DB_DECLARE_1()
        {
            /*" -2013- EXEC SQL DECLARE CHISTCOB CURSOR FOR SELECT A.NRCERTIF, A.NRPARCEL, A.NRTIT, A.DTVENCTO, A.VLPRMTOT, A.CODOPER, A.OPCAOPAG, A.NRTITCOMP, B.CODPRODU, B.OCORHIST, B.CODCLIEN, B.IDE_SEXO, B.OPCAO_COBER, B.NUM_APOLICE, B.CODSUBES, B.OCOREND, B.AGECOBR, B.FONTE, B.DTQITBCO, C.DTVENCTO, B.NRPARCE ,D.COD_EMPRESA FROM SEGUROS.V0HISTCOBVA A, SEGUROS.V0PROPOSTAVA B, SEGUROS.V0PARCELVA C ,SEGUROS.PRODUTO D WHERE A.SITUACAO = '5' AND A.NRCERTIF = B.NRCERTIF AND A.NRCERTIF = C.NRCERTIF AND A.NRPARCEL = C.NRPARCEL AND B.CODPRODU not between 7700 and 7799 --- INFORMACAO RECEBIDA VIA PARAMETRO PARA IMPEDIR --- IMPRESSAO COM DATA DE VENCIMENTO MAIOR. PASSOU --- PERIODO CVP RETIRA OU PARAMS = '9999-12-31' AND A.DTVENCTO <= :WH-DATA-VENCIMENTO AND A.DTVENCTO > :V1SIST-DTMOVABE-30 AND D.COD_PRODUTO = B.CODPRODU END-EXEC. */
            CHISTCOB = new VG0267B_CHISTCOB(true);
            string GetQuery_CHISTCOB()
            {
                var query = @$"SELECT A.NRCERTIF
							, 
							A.NRPARCEL
							, 
							A.NRTIT
							, 
							A.DTVENCTO
							, 
							A.VLPRMTOT
							, 
							A.CODOPER
							, 
							A.OPCAOPAG
							, 
							A.NRTITCOMP
							, 
							B.CODPRODU
							, 
							B.OCORHIST
							, 
							B.CODCLIEN
							, 
							B.IDE_SEXO
							, 
							B.OPCAO_COBER
							, 
							B.NUM_APOLICE
							, 
							B.CODSUBES
							, 
							B.OCOREND
							, 
							B.AGECOBR
							, 
							B.FONTE
							, 
							B.DTQITBCO
							, 
							C.DTVENCTO
							, 
							B.NRPARCE 
							,D.COD_EMPRESA 
							FROM SEGUROS.V0HISTCOBVA A
							, 
							SEGUROS.V0PROPOSTAVA B
							, 
							SEGUROS.V0PARCELVA C 
							,SEGUROS.PRODUTO D 
							WHERE A.SITUACAO = '5' 
							AND A.NRCERTIF = B.NRCERTIF 
							AND A.NRCERTIF = C.NRCERTIF 
							AND A.NRPARCEL = C.NRPARCEL 
							AND B.CODPRODU not between 7700 and 7799 
							--- INFORMACAO RECEBIDA VIA PARAMETRO PARA IMPEDIR 
							--- IMPRESSAO COM DATA DE VENCIMENTO MAIOR. PASSOU 
							--- PERIODO CVP RETIRA OU PARAMS = '9999-12-31' 
							AND A.DTVENCTO <= '{WH_DATA_VENCIMENTO}' 
							AND A.DTVENCTO > '{V1SIST_DTMOVABE_30}' 
							AND D.COD_PRODUTO = B.CODPRODU";

                return query;
            }
            CHISTCOB.GetQueryEvent += GetQuery_CHISTCOB;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_99_SAIDA*/

        [StopWatch]
        /*" R0160-00-FETCH-V1AGENCEF-SECTION */
        private void R0160_00_FETCH_V1AGENCEF_SECTION()
        {
            /*" -1915- MOVE 'R0160-00-FETCH-V1A' TO PARAGRAFO. */
            _.Move("R0160-00-FETCH-V1A", PARAGRAFO);

            /*" -1917- MOVE '0160' TO WNR-EXEC-SQL. */
            _.Move("0160", WABEND.WNR_EXEC_SQL);

            /*" -1926- PERFORM R0160_00_FETCH_V1AGENCEF_DB_FETCH_1 */

            R0160_00_FETCH_V1AGENCEF_DB_FETCH_1();

            /*" -1929- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1930- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1931- MOVE 'S' TO WFIM-V1AGENCEF */
                    _.Move("S", AREA_DE_WORK.WFIM_V1AGENCEF);

                    /*" -1931- PERFORM R0160_00_FETCH_V1AGENCEF_DB_CLOSE_1 */

                    R0160_00_FETCH_V1AGENCEF_DB_CLOSE_1();

                    /*" -1933- ELSE */
                }
                else
                {


                    /*" -1933- PERFORM R0160_00_FETCH_V1AGENCEF_DB_CLOSE_2 */

                    R0160_00_FETCH_V1AGENCEF_DB_CLOSE_2();

                    /*" -1935- DISPLAY 'R0160 - (PROBLEMAS NO FETCH V1AGENCEF) ..' */
                    _.Display($"R0160 - (PROBLEMAS NO FETCH V1AGENCEF) ..");

                    /*" -1936- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -1936- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0160-00-FETCH-V1AGENCEF-DB-FETCH-1 */
        public void R0160_00_FETCH_V1AGENCEF_DB_FETCH_1()
        {
            /*" -1926- EXEC SQL FETCH V1AGENCEF INTO :V1MCEF-COD-FONTE, :V1FONT-NOMEFTE, :V1FONT-ENDERFTE, :V1FONT-BAIRRO, :V1FONT-CIDADE, :V1FONT-CEP, :V1FONT-UF END-EXEC. */

            if (V1AGENCEF.Fetch())
            {
                _.Move(V1AGENCEF.V1MCEF_COD_FONTE, V1MCEF_COD_FONTE);
                _.Move(V1AGENCEF.V1FONT_NOMEFTE, V1FONT_NOMEFTE);
                _.Move(V1AGENCEF.V1FONT_ENDERFTE, V1FONT_ENDERFTE);
                _.Move(V1AGENCEF.V1FONT_BAIRRO, V1FONT_BAIRRO);
                _.Move(V1AGENCEF.V1FONT_CIDADE, V1FONT_CIDADE);
                _.Move(V1AGENCEF.V1FONT_CEP, V1FONT_CEP);
                _.Move(V1AGENCEF.V1FONT_UF, V1FONT_UF);
            }

        }

        [StopWatch]
        /*" R0160-00-FETCH-V1AGENCEF-DB-CLOSE-1 */
        public void R0160_00_FETCH_V1AGENCEF_DB_CLOSE_1()
        {
            /*" -1931- EXEC SQL CLOSE V1AGENCEF END-EXEC */

            V1AGENCEF.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0160_99_SAIDA*/

        [StopWatch]
        /*" R0160-00-FETCH-V1AGENCEF-DB-CLOSE-2 */
        public void R0160_00_FETCH_V1AGENCEF_DB_CLOSE_2()
        {
            /*" -1933- EXEC SQL CLOSE V1AGENCEF END-EXEC */

            V1AGENCEF.Close();

        }

        [StopWatch]
        /*" R0170-00-CARREGA-FILIAL-SECTION */
        private void R0170_00_CARREGA_FILIAL_SECTION()
        {
            /*" -1948- MOVE 'R0170-00-CARREGA-F' TO PARAGRAFO. */
            _.Move("R0170-00-CARREGA-F", PARAGRAFO);

            /*" -1950- MOVE '0170' TO WNR-EXEC-SQL. */
            _.Move("0170", WABEND.WNR_EXEC_SQL);

            /*" -1951- MOVE V1MCEF-COD-FONTE TO TAB-FONTE (IDX-IND1) */
            _.Move(V1MCEF_COD_FONTE, TAB_FILIAL.FILLER_177[AREA_DE_WORK.IDX_IND1].TAB_FONTE);

            /*" -1952- MOVE V1FONT-NOMEFTE TO TAB-NOMEFTE (IDX-IND1) */
            _.Move(V1FONT_NOMEFTE, TAB_FILIAL.FILLER_177[AREA_DE_WORK.IDX_IND1].TAB_NOMEFTE);

            /*" -1953- MOVE V1FONT-ENDERFTE TO TAB-ENDERFTE (IDX-IND1) */
            _.Move(V1FONT_ENDERFTE, TAB_FILIAL.FILLER_177[AREA_DE_WORK.IDX_IND1].TAB_ENDERFTE);

            /*" -1954- MOVE V1FONT-BAIRRO TO TAB-BAIRRO (IDX-IND1) */
            _.Move(V1FONT_BAIRRO, TAB_FILIAL.FILLER_177[AREA_DE_WORK.IDX_IND1].TAB_BAIRRO);

            /*" -1955- MOVE V1FONT-CIDADE TO TAB-CIDADE (IDX-IND1) */
            _.Move(V1FONT_CIDADE, TAB_FILIAL.FILLER_177[AREA_DE_WORK.IDX_IND1].TAB_CIDADE);

            /*" -1956- MOVE V1FONT-CEP TO TAB-CEP (IDX-IND1) */
            _.Move(V1FONT_CEP, TAB_FILIAL.FILLER_177[AREA_DE_WORK.IDX_IND1].TAB_CEP);

            /*" -1958- MOVE V1FONT-UF TO TAB-UF (IDX-IND1) */
            _.Move(V1FONT_UF, TAB_FILIAL.FILLER_177[AREA_DE_WORK.IDX_IND1].TAB_UF);

            /*" -1958- PERFORM R0160-00-FETCH-V1AGENCEF. */

            R0160_00_FETCH_V1AGENCEF_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0170_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-DECLARE-V0HISTCOBVA-SECTION */
        private void R0300_00_DECLARE_V0HISTCOBVA_SECTION()
        {
            /*" -1970- MOVE 'R0300-00-DECLARE-V' TO PARAGRAFO. */
            _.Move("R0300-00-DECLARE-V", PARAGRAFO);

            /*" -1972- MOVE '300' TO WNR-EXEC-SQL. */
            _.Move("300", WABEND.WNR_EXEC_SQL);

            /*" -2013- PERFORM R0300_00_DECLARE_V0HISTCOBVA_DB_DECLARE_1 */

            R0300_00_DECLARE_V0HISTCOBVA_DB_DECLARE_1();

            /*" -2015- PERFORM R0300_00_DECLARE_V0HISTCOBVA_DB_OPEN_1 */

            R0300_00_DECLARE_V0HISTCOBVA_DB_OPEN_1();

        }

        [StopWatch]
        /*" R0300-00-DECLARE-V0HISTCOBVA-DB-OPEN-1 */
        public void R0300_00_DECLARE_V0HISTCOBVA_DB_OPEN_1()
        {
            /*" -2015- EXEC SQL OPEN CHISTCOB END-EXEC. */

            CHISTCOB.Open();

        }

        [StopWatch]
        /*" R0400-00-CARREGA-V0FAIXACEP-DB-DECLARE-1 */
        public void R0400_00_CARREGA_V0FAIXACEP_DB_DECLARE_1()
        {
            /*" -2231- EXEC SQL DECLARE CFAIXACEP CURSOR FOR SELECT FAIXA, CEP_INICIAL, CEP_FINAL, DESCRICAO_FAIXA, CENTRALIZADOR FROM SEGUROS.GE_FAIXA_CEP WHERE DATA_INIVIGENCIA <= :V1SIST-DTMOVABE AND DATA_TERVIGENCIA >= :V1SIST-DTMOVABE ORDER BY FAIXA END-EXEC. */
            CFAIXACEP = new VG0267B_CFAIXACEP(true);
            string GetQuery_CFAIXACEP()
            {
                var query = @$"SELECT FAIXA
							, 
							CEP_INICIAL
							, 
							CEP_FINAL
							, 
							DESCRICAO_FAIXA
							, 
							CENTRALIZADOR 
							FROM SEGUROS.GE_FAIXA_CEP 
							WHERE DATA_INIVIGENCIA <= '{V1SIST_DTMOVABE}' 
							AND DATA_TERVIGENCIA >= '{V1SIST_DTMOVABE}' 
							ORDER BY FAIXA";

                return query;
            }
            CFAIXACEP.GetQueryEvent += GetQuery_CFAIXACEP;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0310-00-FETCH-V0HISTCOBVA-SECTION */
        private void R0310_00_FETCH_V0HISTCOBVA_SECTION()
        {
            /*" -2028- MOVE 'R0310-00-FETCH-V0H' TO PARAGRAFO. */
            _.Move("R0310-00-FETCH-V0H", PARAGRAFO);

            /*" -2030- MOVE '310' TO WNR-EXEC-SQL. */
            _.Move("310", WABEND.WNR_EXEC_SQL);

            /*" -2054- PERFORM R0310_00_FETCH_V0HISTCOBVA_DB_FETCH_1 */

            R0310_00_FETCH_V0HISTCOBVA_DB_FETCH_1();

            /*" -2057- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2058- MOVE 'S' TO WFIM-V0HISTCOBVA */
                _.Move("S", AREA_DE_WORK.WFIM_V0HISTCOBVA);

                /*" -2060- MOVE ZEROS TO AC-CONTA AC-LIDOS */
                _.Move(0, AREA_DE_WORK.AC_CONTA, AREA_DE_WORK.AC_LIDOS);

                /*" -2060- PERFORM R0310_00_FETCH_V0HISTCOBVA_DB_CLOSE_1 */

                R0310_00_FETCH_V0HISTCOBVA_DB_CLOSE_1();

                /*" -2075- GO TO R0310-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2081- IF V0HIST-NRAPOLICE NOT EQUAL 107700000003 AND 107700000006 AND 109300000799 AND 108208503665 AND 108209646968 AND 109300002554 */

            if (!V0HIST_NRAPOLICE.In("107700000003", "107700000006", "109300000799", "108208503665", "108209646968", "109300002554"))
            {

                /*" -2083- IF V0HIST-DTVENCTO GREATER V1SIST-DATA-LIMITE */

                if (V0HIST_DTVENCTO > V1SIST_DATA_LIMITE)
                {

                    /*" -2085- GO TO R0310-00-FETCH-V0HISTCOBVA. */
                    new Task(() => R0310_00_FETCH_V0HISTCOBVA_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...
                }

            }


            /*" -2086- IF (V0HIST-OPCAOPAG EQUAL '3' ) */

            if ((V0HIST_OPCAOPAG == "3"))
            {

                /*" -2087- IF (V0HIST-DTVENCTO < V1SIST-DTMOVABE-30) */

                if ((V0HIST_DTVENCTO < V1SIST_DTMOVABE_30))
                {

                    /*" -2088- ADD 1 TO WS-QTD-DT-VENC-29 */
                    AREA_DE_WORK.WS_QTD_DT_VENC_29.Value = AREA_DE_WORK.WS_QTD_DT_VENC_29 + 1;

                    /*" -2089- GO TO R0310-00-FETCH-V0HISTCOBVA */
                    new Task(() => R0310_00_FETCH_V0HISTCOBVA_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -2090- END-IF */
                }


                /*" -2092- END-IF. */
            }


            /*" -2094- PERFORM R0350-00-SELECT-V0PRODUTOSVG. */

            R0350_00_SELECT_V0PRODUTOSVG_SECTION();

            /*" -2095- IF V0PROD-ESTR-COBR-I < ZEROS */

            if (V0PROD_ESTR_COBR_I < 00)
            {

                /*" -2097- GO TO R0310-00-FETCH-V0HISTCOBVA. */
                new Task(() => R0310_00_FETCH_V0HISTCOBVA_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -2098- IF V0PROD-ORIG-PRODU-I < ZEROS */

            if (V0PROD_ORIG_PRODU_I < 00)
            {

                /*" -2100- GO TO R0310-00-FETCH-V0HISTCOBVA. */
                new Task(() => R0310_00_FETCH_V0HISTCOBVA_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -2101- IF V0PROD-ESTR-COBR NOT = 'MULT' */

            if (V0PROD_ESTR_COBR != "MULT")
            {

                /*" -2103- GO TO R0310-00-FETCH-V0HISTCOBVA. */
                new Task(() => R0310_00_FETCH_V0HISTCOBVA_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -2107- IF V0PROD-ORIG-PRODU NOT = 'EMPRE' AND 'ESPEC' AND 'ESPE1' AND 'GLOBAL' */

            if (!V0PROD_ORIG_PRODU.In("EMPRE", "ESPEC", "ESPE1", "GLOBAL"))
            {

                /*" -2110- IF V0PROD-NUM-APOLICE EQUAL 109300000635 AND V0PROD-CODSUBES EQUAL 1 NEXT SENTENCE */

                if (V0PROD_NUM_APOLICE == 109300000635 && V0PROD_CODSUBES == 1)
                {

                    /*" -2111- ELSE */
                }
                else
                {


                    /*" -2114- IF V0PROD-NUM-APOLICE EQUAL 107700000007 AND V0PROD-CODSUBES EQUAL 2 NEXT SENTENCE */

                    if (V0PROD_NUM_APOLICE == 107700000007 && V0PROD_CODSUBES == 2)
                    {

                        /*" -2115- ELSE */
                    }
                    else
                    {


                        /*" -2117- GO TO R0310-00-FETCH-V0HISTCOBVA. */
                        new Task(() => R0310_00_FETCH_V0HISTCOBVA_SECTION()).RunSynchronously(); //GOTO
                        return;//Recursividade detectada, cuidado...
                    }

                }

            }


            /*" -2118- IF VIND-NRTITCOMP < ZEROS */

            if (VIND_NRTITCOMP < 00)
            {

                /*" -2122- MOVE ZEROS TO V0HIST-NRTITCOMP. */
                _.Move(0, V0HIST_NRTITCOMP);
            }


            /*" -2123- IF V0HIST-OPCAOPAG EQUAL '3' */

            if (V0HIST_OPCAOPAG == "3")
            {

                /*" -2135- IF V0HIST-CODOPER EQUAL ZEROS OR 111 OR 112 OR 113 OR 114 OR 115 OR 121 OR 122 OR 123 OR 301 OR 501 NEXT SENTENCE */

                if (V0HIST_CODOPER.In("00", "111", "112", "113", "114", "115", "121", "122", "123", "301", "501"))
                {

                    /*" -2136- ELSE */
                }
                else
                {


                    /*" -2137- GO TO R0310-00-FETCH-V0HISTCOBVA */
                    new Task(() => R0310_00_FETCH_V0HISTCOBVA_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -2138- ELSE */
                }

            }
            else
            {


                /*" -2142- GO TO R0310-00-FETCH-V0HISTCOBVA. */
                new Task(() => R0310_00_FETCH_V0HISTCOBVA_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -2143- IF V0HIST-OPCAOPAG EQUAL '1' OR '2' */

            if (V0HIST_OPCAOPAG.In("1", "2"))
            {

                /*" -2145- GO TO R0310-00-FETCH-V0HISTCOBVA. */
                new Task(() => R0310_00_FETCH_V0HISTCOBVA_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -2146- IF V0HIST-CODOPER EQUAL 121 OR 122 OR 123 */

            if (V0HIST_CODOPER.In("121", "122", "123"))
            {

                /*" -2147- ADD 1 TO AC-BOLETOS-ATR */
                AREA_DE_WORK.AC_BOLETOS_ATR.Value = AREA_DE_WORK.AC_BOLETOS_ATR + 1;

                /*" -2149- END-IF. */
            }


            /*" -2152- ADD 1 TO AC-CONTA AC-LIDOS. */
            AREA_DE_WORK.AC_CONTA.Value = AREA_DE_WORK.AC_CONTA + 1;
            AREA_DE_WORK.AC_LIDOS.Value = AREA_DE_WORK.AC_LIDOS + 1;

            /*" -2153- IF AC-CONTA > 99 */

            if (AREA_DE_WORK.AC_CONTA > 99)
            {

                /*" -2154- MOVE ZEROS TO AC-CONTA */
                _.Move(0, AREA_DE_WORK.AC_CONTA);

                /*" -2155- ACCEPT WHORA-CURR FROM TIME */
                _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_CURR);

                /*" -2155- DISPLAY '**** LIDOS V0HISTCOBVA ' AC-LIDOS ' ' WHORA-CURR. */

                $"**** LIDOS V0HISTCOBVA {AREA_DE_WORK.AC_LIDOS} {AREA_DE_WORK.WHORA_CURR}"
                .Display();
            }


        }

        [StopWatch]
        /*" R0310-00-FETCH-V0HISTCOBVA-DB-FETCH-1 */
        public void R0310_00_FETCH_V0HISTCOBVA_DB_FETCH_1()
        {
            /*" -2054- EXEC SQL FETCH CHISTCOB INTO :V0HIST-NRCERTIF, :V0HIST-NRPARCEL, :V0HIST-NRTIT, :V0HIST-DTVENCTO, :V0HIST-VLPRMTOT, :V0HIST-CODOPER, :V0HIST-OPCAOPAG, :V0HIST-NRTITCOMP, :V0HIST-CODPRODU, :V0HIST-OCORHIST, :V0HIST-CDCLIENTE, :V0HIST-IDSEXO, :V0HIST-OPCOBERT, :V0HIST-NRAPOLICE, :V0HIST-CODSUBES, :V0HIST-OCOREND, :V0HIST-AGECOBR, :V0HIST-FONTE, :V0HIST-DTQITBCO, :V0PARC-DTVENCTO, :V0HIST-QTDPARCEL ,:PRODUTO-COD-EMPRESA END-EXEC. */

            if (CHISTCOB.Fetch())
            {
                _.Move(CHISTCOB.V0HIST_NRCERTIF, V0HIST_NRCERTIF);
                _.Move(CHISTCOB.V0HIST_NRPARCEL, V0HIST_NRPARCEL);
                _.Move(CHISTCOB.V0HIST_NRTIT, V0HIST_NRTIT);
                _.Move(CHISTCOB.V0HIST_DTVENCTO, V0HIST_DTVENCTO);
                _.Move(CHISTCOB.V0HIST_VLPRMTOT, V0HIST_VLPRMTOT);
                _.Move(CHISTCOB.V0HIST_CODOPER, V0HIST_CODOPER);
                _.Move(CHISTCOB.V0HIST_OPCAOPAG, V0HIST_OPCAOPAG);
                _.Move(CHISTCOB.V0HIST_NRTITCOMP, V0HIST_NRTITCOMP);
                _.Move(CHISTCOB.V0HIST_CODPRODU, V0HIST_CODPRODU);
                _.Move(CHISTCOB.V0HIST_OCORHIST, V0HIST_OCORHIST);
                _.Move(CHISTCOB.V0HIST_CDCLIENTE, V0HIST_CDCLIENTE);
                _.Move(CHISTCOB.V0HIST_IDSEXO, V0HIST_IDSEXO);
                _.Move(CHISTCOB.V0HIST_OPCOBERT, V0HIST_OPCOBERT);
                _.Move(CHISTCOB.V0HIST_NRAPOLICE, V0HIST_NRAPOLICE);
                _.Move(CHISTCOB.V0HIST_CODSUBES, V0HIST_CODSUBES);
                _.Move(CHISTCOB.V0HIST_OCOREND, V0HIST_OCOREND);
                _.Move(CHISTCOB.V0HIST_AGECOBR, V0HIST_AGECOBR);
                _.Move(CHISTCOB.V0HIST_FONTE, V0HIST_FONTE);
                _.Move(CHISTCOB.V0HIST_DTQITBCO, V0HIST_DTQITBCO);
                _.Move(CHISTCOB.V0PARC_DTVENCTO, V0PARC_DTVENCTO);
                _.Move(CHISTCOB.V0HIST_QTDPARCEL, V0HIST_QTDPARCEL);
                _.Move(CHISTCOB.PRODUTO_COD_EMPRESA, PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA);
            }

        }

        [StopWatch]
        /*" R0310-00-FETCH-V0HISTCOBVA-DB-CLOSE-1 */
        public void R0310_00_FETCH_V0HISTCOBVA_DB_CLOSE_1()
        {
            /*" -2060- EXEC SQL CLOSE CHISTCOB END-EXEC */

            CHISTCOB.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/

        [StopWatch]
        /*" R0350-00-SELECT-V0PRODUTOSVG-SECTION */
        private void R0350_00_SELECT_V0PRODUTOSVG_SECTION()
        {
            /*" -2168- MOVE 'R0350-00-SELECT-V0' TO PARAGRAFO. */
            _.Move("R0350-00-SELECT-V0", PARAGRAFO);

            /*" -2170- MOVE '350' TO WNR-EXEC-SQL. */
            _.Move("350", WABEND.WNR_EXEC_SQL);

            /*" -2191- PERFORM R0350_00_SELECT_V0PRODUTOSVG_DB_SELECT_1 */

            R0350_00_SELECT_V0PRODUTOSVG_DB_SELECT_1();

            /*" -2194- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2195- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2196- MOVE SPACES TO V0PROD-ESTR-COBR */
                    _.Move("", V0PROD_ESTR_COBR);

                    /*" -2197- MOVE -1 TO V0PROD-ESTR-COBR-I */
                    _.Move(-1, V0PROD_ESTR_COBR_I);

                    /*" -2198- MOVE SPACES TO V0PROD-ORIG-PRODU */
                    _.Move("", V0PROD_ORIG_PRODU);

                    /*" -2199- MOVE -1 TO V0PROD-ORIG-PRODU-I */
                    _.Move(-1, V0PROD_ORIG_PRODU_I);

                    /*" -2200- ELSE */
                }
                else
                {


                    /*" -2201- DISPLAY 'R0350 - PROBLEMAS NO ACESSO A V0PRODUTOSVG' */
                    _.Display($"R0350 - PROBLEMAS NO ACESSO A V0PRODUTOSVG");

                    /*" -2203- DISPLAY 'NUM_APOLICE - ' V0HIST-NRAPOLICE ' ' 'CODSUBES    - ' V0HIST-CODSUBES */

                    $"NUM_APOLICE - {V0HIST_NRAPOLICE} CODSUBES    - {V0HIST_CODSUBES}"
                    .Display();

                    /*" -2205- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2206- IF VIND-TEMCDG LESS ZEROES */

            if (VIND_TEMCDG < 00)
            {

                /*" -2206- MOVE SPACES TO V0PROD-TEM-CDG. */
                _.Move("", V0PROD_TEM_CDG);
            }


        }

        [StopWatch]
        /*" R0350-00-SELECT-V0PRODUTOSVG-DB-SELECT-1 */
        public void R0350_00_SELECT_V0PRODUTOSVG_DB_SELECT_1()
        {
            /*" -2191- EXEC SQL SELECT NUM_APOLICE ,CODSUBES ,CODPRODU ,NOMPRODU ,CODCDT ,TEM_CDG ,ESTR_COBR ,ORIG_PRODU INTO :V0PROD-NUM-APOLICE ,:V0PROD-CODSUBES ,:V0PROD-CODPRODU ,:V0PROD-NOMPRODU ,:V0PROD-CODCDT ,:V0PROD-TEM-CDG:VIND-TEMCDG ,:V0PROD-ESTR-COBR:V0PROD-ESTR-COBR-I ,:V0PROD-ORIG-PRODU:V0PROD-ORIG-PRODU-I FROM SEGUROS.V0PRODUTOSVG WHERE NUM_APOLICE = :V0HIST-NRAPOLICE AND CODSUBES = :V0HIST-CODSUBES END-EXEC. */

            var r0350_00_SELECT_V0PRODUTOSVG_DB_SELECT_1_Query1 = new R0350_00_SELECT_V0PRODUTOSVG_DB_SELECT_1_Query1()
            {
                V0HIST_NRAPOLICE = V0HIST_NRAPOLICE.ToString(),
                V0HIST_CODSUBES = V0HIST_CODSUBES.ToString(),
            };

            var executed_1 = R0350_00_SELECT_V0PRODUTOSVG_DB_SELECT_1_Query1.Execute(r0350_00_SELECT_V0PRODUTOSVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PROD_NUM_APOLICE, V0PROD_NUM_APOLICE);
                _.Move(executed_1.V0PROD_CODSUBES, V0PROD_CODSUBES);
                _.Move(executed_1.V0PROD_CODPRODU, V0PROD_CODPRODU);
                _.Move(executed_1.V0PROD_NOMPRODU, V0PROD_NOMPRODU);
                _.Move(executed_1.V0PROD_CODCDT, V0PROD_CODCDT);
                _.Move(executed_1.V0PROD_TEM_CDG, V0PROD_TEM_CDG);
                _.Move(executed_1.VIND_TEMCDG, VIND_TEMCDG);
                _.Move(executed_1.V0PROD_ESTR_COBR, V0PROD_ESTR_COBR);
                _.Move(executed_1.V0PROD_ESTR_COBR_I, V0PROD_ESTR_COBR_I);
                _.Move(executed_1.V0PROD_ORIG_PRODU, V0PROD_ORIG_PRODU);
                _.Move(executed_1.V0PROD_ORIG_PRODU_I, V0PROD_ORIG_PRODU_I);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-CARREGA-V0FAIXACEP-SECTION */
        private void R0400_00_CARREGA_V0FAIXACEP_SECTION()
        {
            /*" -2219- MOVE 'R0400-00-CARREGA  ' TO PARAGRAFO. */
            _.Move("R0400-00-CARREGA  ", PARAGRAFO);

            /*" -2221- MOVE '400' TO WNR-EXEC-SQL. */
            _.Move("400", WABEND.WNR_EXEC_SQL);

            /*" -2231- PERFORM R0400_00_CARREGA_V0FAIXACEP_DB_DECLARE_1 */

            R0400_00_CARREGA_V0FAIXACEP_DB_DECLARE_1();

            /*" -2233- PERFORM R0400_00_CARREGA_V0FAIXACEP_DB_OPEN_1 */

            R0400_00_CARREGA_V0FAIXACEP_DB_OPEN_1();

            /*" -2236- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2237- DISPLAY 'VG0267B - PROBLEMAS NA V0FAIXA_CEP' */
                _.Display($"VG0267B - PROBLEMAS NA V0FAIXA_CEP");

                /*" -2239- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2240- PERFORM R0410-00-FETCH-V0FAIXACEP UNTIL WFIM-V0FAIXACEP EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_V0FAIXACEP == "S"))
            {

                R0410_00_FETCH_V0FAIXACEP_SECTION();
            }

        }

        [StopWatch]
        /*" R0400-00-CARREGA-V0FAIXACEP-DB-OPEN-1 */
        public void R0400_00_CARREGA_V0FAIXACEP_DB_OPEN_1()
        {
            /*" -2233- EXEC SQL OPEN CFAIXACEP END-EXEC. */

            CFAIXACEP.Open();

        }

        [StopWatch]
        /*" R2350-00-TRATA-PARCELAS-DB-DECLARE-1 */
        public void R2350_00_TRATA_PARCELAS_DB_DECLARE_1()
        {
            /*" -3735- EXEC SQL DECLARE CHISTCOB1 CURSOR FOR SELECT NRCERTIF, NRPARCEL FROM SEGUROS.V0HISTCOBVA WHERE NRTITCOMP = :WHOST-NRTITCOMP ORDER BY NRPARCEL END-EXEC. */
            CHISTCOB1 = new VG0267B_CHISTCOB1(true);
            string GetQuery_CHISTCOB1()
            {
                var query = @$"SELECT 
							NRCERTIF
							, 
							NRPARCEL 
							FROM SEGUROS.V0HISTCOBVA 
							WHERE NRTITCOMP = '{WHOST_NRTITCOMP}' 
							ORDER BY NRPARCEL";

                return query;
            }
            CHISTCOB1.GetQueryEvent += GetQuery_CHISTCOB1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0410-00-FETCH-V0FAIXACEP-SECTION */
        private void R0410_00_FETCH_V0FAIXACEP_SECTION()
        {
            /*" -2252- MOVE 'R0410-00-FETCH-V0F' TO PARAGRAFO. */
            _.Move("R0410-00-FETCH-V0F", PARAGRAFO);

            /*" -2254- MOVE '410' TO WNR-EXEC-SQL. */
            _.Move("410", WABEND.WNR_EXEC_SQL);

            /*" -2261- PERFORM R0410_00_FETCH_V0FAIXACEP_DB_FETCH_1 */

            R0410_00_FETCH_V0FAIXACEP_DB_FETCH_1();

            /*" -2264- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2265- MOVE 'S' TO WFIM-V0FAIXACEP */
                _.Move("S", AREA_DE_WORK.WFIM_V0FAIXACEP);

                /*" -2267- MOVE ZEROS TO AC-CONTA AC-LIDOS */
                _.Move(0, AREA_DE_WORK.AC_CONTA, AREA_DE_WORK.AC_LIDOS);

                /*" -2267- PERFORM R0410_00_FETCH_V0FAIXACEP_DB_CLOSE_1 */

                R0410_00_FETCH_V0FAIXACEP_DB_CLOSE_1();

                /*" -2271- GO TO R0410-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0410_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2272- MOVE V0FAIC-FAIXA TO TAB-FX-CEP-G (V0FAIC-FAIXA). */
            _.Move(V0FAIC_FAIXA, TABELA_CEP.CEP[V0FAIC_FAIXA].TAB_FX_CEP_G);

            /*" -2273- MOVE V0FAIC-CEPINI TO TAB-FX-INI (V0FAIC-FAIXA). */
            _.Move(V0FAIC_CEPINI, TABELA_CEP.CEP[V0FAIC_FAIXA].TAB_FAIXAS.TAB_FX_INI);

            /*" -2274- MOVE V0FAIC-CEPFIM TO TAB-FX-FIM (V0FAIC-FAIXA). */
            _.Move(V0FAIC_CEPFIM, TABELA_CEP.CEP[V0FAIC_FAIXA].TAB_FAIXAS.TAB_FX_FIM);

            /*" -2275- MOVE V0FAIC-DESC-FAIXA TO TAB-FX-NOME (V0FAIC-FAIXA). */
            _.Move(V0FAIC_DESC_FAIXA, TABELA_CEP.CEP[V0FAIC_FAIXA].TAB_FAIXAS.TAB_FX_NOME);

            /*" -2277- MOVE V0FAIC-CENTRALIZA TO TAB-FX-CENTR (V0FAIC-FAIXA). */
            _.Move(V0FAIC_CENTRALIZA, TABELA_CEP.CEP[V0FAIC_FAIXA].TAB_FAIXAS.TAB_FX_CENTR);

            /*" -2277- GO TO R0410-00-FETCH-V0FAIXACEP. */
            new Task(() => R0410_00_FETCH_V0FAIXACEP_SECTION()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R0410-00-FETCH-V0FAIXACEP-DB-FETCH-1 */
        public void R0410_00_FETCH_V0FAIXACEP_DB_FETCH_1()
        {
            /*" -2261- EXEC SQL FETCH CFAIXACEP INTO :V0FAIC-FAIXA, :V0FAIC-CEPINI, :V0FAIC-CEPFIM, :V0FAIC-DESC-FAIXA, :V0FAIC-CENTRALIZA END-EXEC. */

            if (CFAIXACEP.Fetch())
            {
                _.Move(CFAIXACEP.V0FAIC_FAIXA, V0FAIC_FAIXA);
                _.Move(CFAIXACEP.V0FAIC_CEPINI, V0FAIC_CEPINI);
                _.Move(CFAIXACEP.V0FAIC_CEPFIM, V0FAIC_CEPFIM);
                _.Move(CFAIXACEP.V0FAIC_DESC_FAIXA, V0FAIC_DESC_FAIXA);
                _.Move(CFAIXACEP.V0FAIC_CENTRALIZA, V0FAIC_CENTRALIZA);
            }

        }

        [StopWatch]
        /*" R0410-00-FETCH-V0FAIXACEP-DB-CLOSE-1 */
        public void R0410_00_FETCH_V0FAIXACEP_DB_CLOSE_1()
        {
            /*" -2267- EXEC SQL CLOSE CFAIXACEP END-EXEC */

            CFAIXACEP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0410_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-SELECIONA-SECTION */
        private void R0900_00_SELECIONA_SECTION()
        {
            /*" -2289- MOVE 'R0900-00-SELECIONA' TO PARAGRAFO. */
            _.Move("R0900-00-SELECIONA", PARAGRAFO);

            /*" -2290- PERFORM R1000-00-PROCESSA-INPUT UNTIL WFIM-V0HISTCOBVA EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_V0HISTCOBVA == "S"))
            {

                R1000_00_PROCESSA_INPUT_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_FIM*/

        [StopWatch]
        /*" R1000-00-PROCESSA-INPUT-SECTION */
        private void R1000_00_PROCESSA_INPUT_SECTION()
        {
            /*" -2302- MOVE 'R1000-00-PROCESSA-' TO PARAGRAFO. */
            _.Move("R1000-00-PROCESSA-", PARAGRAFO);

            /*" -2304- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", WABEND.WNR_EXEC_SQL);

            /*" -2307- MOVE V0HIST-NRAPOLICE TO V0MENS-NUM-APOLICE WS-NUM-APOLICE. */
            _.Move(V0HIST_NRAPOLICE, V0MENS_NUM_APOLICE);
            _.Move(V0HIST_NRAPOLICE, AREA_DE_WORK.WS_CHAVE_R.WS_NUM_APOLICE);


            /*" -2310- MOVE V0HIST-CODSUBES TO V0MENS-CODSUBES WS-CODSUBES. */
            _.Move(V0HIST_CODSUBES, V0MENS_CODSUBES);
            _.Move(V0HIST_CODSUBES, AREA_DE_WORK.WS_CHAVE_R.WS_CODSUBES);


            /*" -2313- MOVE V0HIST-CODOPER TO WHOST-CODOPER WS-CODOPER. */
            _.Move(V0HIST_CODOPER, WHOST_CODOPER);
            _.Move(V0HIST_CODOPER, AREA_DE_WORK.WS_CHAVE_R.WS_CODOPER);


            /*" -2315- PERFORM R1010-CONSULTA-CNTRLE-SIGCB. */

            R1010_CONSULTA_CNTRLE_SIGCB_SECTION();

            /*" -2316- IF (SVA-NN-SIGCB EQUAL ZEROS) */

            if ((REG_SVG0267B.SVA_NN_SIGCB == 00))
            {

                /*" -2318- GO TO R1000-10-NEXT. */

                R1000_10_NEXT(); //GOTO
                return;
            }


            /*" -2320- PERFORM R1200-00-SELECT-V0CLIENTE. */

            R1200_00_SELECT_V0CLIENTE_SECTION();

            /*" -2322- PERFORM R1300-00-SELECT-V0ENDERECO. */

            R1300_00_SELECT_V0ENDERECO_SECTION();

            /*" -2324- PERFORM R1500-00-SELECT-V1AGENCEF. */

            R1500_00_SELECT_V1AGENCEF_SECTION();

            /*" -2326- PERFORM R1510-00-SELECT-V0OPCAOPAGVA. */

            R1510_00_SELECT_V0OPCAOPAGVA_SECTION();

            /*" -2327- MOVE V1MCEF-COD-FONTE TO SVA-FONTE. */
            _.Move(V1MCEF_COD_FONTE, REG_SVG0267B.SVA_FONTE);

            /*" -2328- MOVE V0CLIE-NOME-RAZAO TO SVA-NOME-RAZAO. */
            _.Move(V0CLIE_NOME_RAZAO, REG_SVG0267B.SVA_NOME_RAZAO);

            /*" -2329- MOVE V0CLIE-CNPJ TO SVA-NRCNPJ. */
            _.Move(V0CLIE_CNPJ, REG_SVG0267B.SVA_NRCNPJ);

            /*" -2330- MOVE V0ENDE-ENDERECO TO SVA-ENDERECO. */
            _.Move(V0ENDE_ENDERECO, REG_SVG0267B.SVA_ENDERECO);

            /*" -2331- MOVE V0ENDE-BAIRRO TO SVA-BAIRRO. */
            _.Move(V0ENDE_BAIRRO, REG_SVG0267B.SVA_BAIRRO);

            /*" -2332- MOVE V0ENDE-CIDADE TO SVA-CIDADE. */
            _.Move(V0ENDE_CIDADE, REG_SVG0267B.SVA_CIDADE);

            /*" -2333- MOVE V0ENDE-UF TO SVA-UF. */
            _.Move(V0ENDE_UF, REG_SVG0267B.SVA_UF);

            /*" -2334- MOVE V0ENDE-CEP TO WS-NUM-CEP-AUX. */
            _.Move(V0ENDE_CEP, AREA_DE_WORK.WS_NUM_CEP_AUX);

            /*" -2335- MOVE V0HIST-NRCERTIF TO SVA-NRCERTIF. */
            _.Move(V0HIST_NRCERTIF, REG_SVG0267B.SVA_NRCERTIF);

            /*" -2336- MOVE V0HIST-NRTIT TO SVA-NRTIT. */
            _.Move(V0HIST_NRTIT, REG_SVG0267B.SVA_NRTIT);

            /*" -2337- MOVE V0HIST-NRTITCOMP TO SVA-NRTITCOMP. */
            _.Move(V0HIST_NRTITCOMP, REG_SVG0267B.SVA_NRTITCOMP);

            /*" -2338- MOVE V0HIST-NRPARCEL TO SVA-NRPARCEL. */
            _.Move(V0HIST_NRPARCEL, REG_SVG0267B.SVA_NRPARCEL);

            /*" -2340- MOVE V0HIST-DTVENCTO TO SVA-DTVENCTO SVA-DTA-VENC. */
            _.Move(V0HIST_DTVENCTO, REG_SVG0267B.SVA_DTVENCTO, REG_SVG0267B.SVA_DTA_VENC);

            /*" -2342- MOVE V0HIST-VLPRMTOT TO SVA-VLPRMTOT SVA-VLR-PREMIO */
            _.Move(V0HIST_VLPRMTOT, REG_SVG0267B.SVA_VLPRMTOT, REG_SVG0267B.SVA_VLR_PREMIO);

            /*" -2343- MOVE V0PARC-DTVENCTO TO SVA-DTVENCTO-ORIG. */
            _.Move(V0PARC_DTVENCTO, REG_SVG0267B.SVA_DTVENCTO_ORIG);

            /*" -2344- MOVE V0HIST-CODOPER TO SVA-CODOPER. */
            _.Move(V0HIST_CODOPER, REG_SVG0267B.SVA_CODOPER);

            /*" -2345- MOVE V0HIST-OCORHIST TO SVA-OCORHIST. */
            _.Move(V0HIST_OCORHIST, REG_SVG0267B.SVA_OCORHIST);

            /*" -2346- MOVE V0HIST-CODPRODU TO SVA-CODPRODU. */
            _.Move(V0HIST_CODPRODU, REG_SVG0267B.SVA_CODPRODU);

            /*" -2347- MOVE V0HIST-NRAPOLICE TO SVA-NRAPOLICE. */
            _.Move(V0HIST_NRAPOLICE, REG_SVG0267B.SVA_NRAPOLICE);

            /*" -2348- MOVE V0HIST-CODSUBES TO SVA-CODSUBES. */
            _.Move(V0HIST_CODSUBES, REG_SVG0267B.SVA_CODSUBES);

            /*" -2349- MOVE V0HIST-AGECOBR TO SVA-AGECOBR. */
            _.Move(V0HIST_AGECOBR, REG_SVG0267B.SVA_AGECOBR);

            /*" -2350- MOVE V0HIST-DTQITBCO TO SVA-DTQITBCO. */
            _.Move(V0HIST_DTQITBCO, REG_SVG0267B.SVA_DTQITBCO);

            /*" -2351- MOVE V0OPCP-PERIPGTO TO SVA-PERIPGTO. */
            _.Move(V0OPCP_PERIPGTO, REG_SVG0267B.SVA_PERIPGTO);

            /*" -2353- MOVE PRODUTO-COD-EMPRESA TO SVA-COD-EMPRESA. */
            _.Move(PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA, REG_SVG0267B.SVA_COD_EMPRESA);

            /*" -2354- IF WS-CEP-COMPL-AUX1 EQUAL ZEROS */

            if (AREA_DE_WORK.WS_NUM_CEP_AUX_R1.WS_CEP_COMPL_AUX1 == 00)
            {

                /*" -2355- MOVE WS-CEP-COMPL-AUX1 TO SVA-CEP-COMPL */
                _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R1.WS_CEP_COMPL_AUX1, REG_SVG0267B.SVA_NUM_CEP.SVA_CEP_COMPL);

                /*" -2356- MOVE WS-CEP-AUX1 TO SVA-CEP */
                _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R1.WS_CEP_AUX1, REG_SVG0267B.SVA_NUM_CEP.SVA_CEP);

                /*" -2357- ELSE */
            }
            else
            {


                /*" -2358- MOVE WS-CEP-AUX TO SVA-CEP */
                _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_AUX, REG_SVG0267B.SVA_NUM_CEP.SVA_CEP);

                /*" -2360- MOVE WS-CEP-COMPL-AUX TO SVA-CEP-COMPL. */
                _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, REG_SVG0267B.SVA_NUM_CEP.SVA_CEP_COMPL);
            }


            /*" -2361- IF V0ENDE-CEP EQUAL ZEROS */

            if (V0ENDE_CEP == 00)
            {

                /*" -2362- MOVE 01 TO SVA-CEP-G */
                _.Move(01, REG_SVG0267B.SVA_CEP_G);

                /*" -2363- MOVE TAB-FAIXAS (01) TO SVA-NOME-CORREIO */
                _.Move(TABELA_CEP.CEP[01].TAB_FAIXAS, REG_SVG0267B.SVA_NOME_CORREIO);

                /*" -2364- ELSE */
            }
            else
            {


                /*" -2366- PERFORM R1600-00-LOCALIZA-CEP. */

                R1600_00_LOCALIZA_CEP_SECTION();
            }


            /*" -2369- MOVE V0PROD-CODPRODU TO SVA-CODPRODU WS-COD-PRODUTO */
            _.Move(V0PROD_CODPRODU, REG_SVG0267B.SVA_CODPRODU, WS_COD_PRODUTO);

            /*" -2371- INITIALIZE WS-SIT-PRODUTO */
            _.Initialize(
                AREA_DE_WORK.WS_SIT_PRODUTO
            );

            /*" -2373- PERFORM R2325-PRODUTO-RUNOFF */

            R2325_PRODUTO_RUNOFF_SECTION();

            /*" -2374- MOVE V0PROD-NOMPRODU TO SVA-NOMPRODU. */
            _.Move(V0PROD_NOMPRODU, REG_SVG0267B.SVA_NOMPRODU);

            /*" -2375- MOVE V0PROD-CODCDT TO SVA-CODCDT. */
            _.Move(V0PROD_CODCDT, REG_SVG0267B.SVA_CODCDT);

            /*" -2376- MOVE V0PROD-TEM-CDG TO SVA-TEM-CDG. */
            _.Move(V0PROD_TEM_CDG, REG_SVG0267B.SVA_TEM_CDG);

            /*" -2377- MOVE V0PROD-ESTR-COBR TO SVA-ESTR-COBR. */
            _.Move(V0PROD_ESTR_COBR, REG_SVG0267B.SVA_ESTR_COBR);

            /*" -2379- MOVE V0PROD-ORIG-PRODU TO SVA-ORIG-PRODU. */
            _.Move(V0PROD_ORIG_PRODU, REG_SVG0267B.SVA_ORIG_PRODU);

            /*" -2385- IF SVA-ORIG-PRODU EQUAL 'ESPEC' OR 'ESPE1' */

            if (REG_SVG0267B.SVA_ORIG_PRODU.In("ESPEC", "ESPE1"))
            {

                /*" -2386- EVALUATE PRODUTO-COD-EMPRESA */
                switch (PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA.Value)
                {

                    /*" -2387- WHEN 10 */
                    case 10:

                        /*" -2389- WHEN 11 */
                        break;
                    case 11:

                        /*" -2391- MOVE 'VD02' TO SVA-FORMULARIO */
                        _.Move("VD02", REG_SVG0267B.SVA_FORMULARIO);

                        /*" -2392- IF WS-PROD-RUNON */

                        if (AREA_DE_WORK.WS_SIT_PRODUTO["WS_PROD_RUNON"])
                        {

                            /*" -2393- MOVE 'VIDA25' TO SVA-FORMULARIO */
                            _.Move("VIDA25", REG_SVG0267B.SVA_FORMULARIO);

                            /*" -2394- END-IF */
                        }


                        /*" -2395- WHEN OTHER */
                        break;
                    default:

                        /*" -2396- MOVE 'VD02' TO SVA-FORMULARIO */
                        _.Move("VD02", REG_SVG0267B.SVA_FORMULARIO);

                        /*" -2397- END-EVALUATE */
                        break;
                }


                /*" -2401- ELSE */
            }
            else
            {


                /*" -2402- EVALUATE PRODUTO-COD-EMPRESA */
                switch (PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA.Value)
                {

                    /*" -2403- WHEN 10 */
                    case 10:

                        /*" -2405- WHEN 11 */
                        break;
                    case 11:

                        /*" -2407- MOVE 'VD32' TO SVA-FORMULARIO */
                        _.Move("VD32", REG_SVG0267B.SVA_FORMULARIO);

                        /*" -2408- IF WS-PROD-RUNON */

                        if (AREA_DE_WORK.WS_SIT_PRODUTO["WS_PROD_RUNON"])
                        {

                            /*" -2409- MOVE 'VIDA26' TO SVA-FORMULARIO */
                            _.Move("VIDA26", REG_SVG0267B.SVA_FORMULARIO);

                            /*" -2410- END-IF */
                        }


                        /*" -2411- WHEN OTHER */
                        break;
                    default:

                        /*" -2412- MOVE 'VD32' TO SVA-FORMULARIO */
                        _.Move("VD32", REG_SVG0267B.SVA_FORMULARIO);

                        /*" -2414- END-EVALUATE. */
                        break;
                }

            }


            /*" -2414- RELEASE REG-SVG0267B. */
            SVG0267B.Release(REG_SVG0267B);

            /*" -0- FLUXCONTROL_PERFORM R1000_10_NEXT */

            R1000_10_NEXT();

        }

        [StopWatch]
        /*" R1000-10-NEXT */
        private void R1000_10_NEXT(bool isPerform = false)
        {
            /*" -2419- PERFORM R0310-00-FETCH-V0HISTCOBVA. */

            R0310_00_FETCH_V0HISTCOBVA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1010-CONSULTA-CNTRLE-SIGCB-SECTION */
        private void R1010_CONSULTA_CNTRLE_SIGCB_SECTION()
        {
            /*" -2431- MOVE '1010' TO WNR-EXEC-SQL. */
            _.Move("1010", WABEND.WNR_EXEC_SQL);

            /*" -2433- INITIALIZE REGISTRO-LINKAGE-GE0350S. */
            _.Initialize(
                LBGE0350.REGISTRO_LINKAGE_GE0350S
            );

            /*" -2434- MOVE ZEROS TO SVA-NN-SIGCB */
            _.Move(0, REG_SVG0267B.SVA_NN_SIGCB);

            /*" -2436- MOVE ZEROS TO SVA-LIN-DIGITAVEL */
            _.Move(0, REG_SVG0267B.SVA_LIN_DIGITAVEL);

            /*" -2437- MOVE 01 TO LK-GE350-COD-FUNCAO */
            _.Move(01, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_FUNCAO);

            /*" -2438- MOVE V0HIST-NRAPOLICE TO LK-GE350-NUM-APOLICE */
            _.Move(V0HIST_NRAPOLICE, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE);

            /*" -2439- MOVE V0HIST-NRCERTIF TO LK-GE350-NUM-CERTIFICADO */
            _.Move(V0HIST_NRCERTIF, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_CERTIFICADO);

            /*" -2440- MOVE V0HIST-NRPARCEL TO LK-GE350-NUM-PARCELA */
            _.Move(V0HIST_NRPARCEL, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA);

            /*" -2441- MOVE ZEROS TO LK-GE350-NUM-ENDOSSO */
            _.Move(0, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO);

            /*" -2443- MOVE ZEROS TO LK-GE350-NUM-PROPOSTA */
            _.Move(0, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PROPOSTA);

            /*" -2445- CALL 'GE0350S' USING REGISTRO-LINKAGE-GE0350S. */
            _.Call("GE0350S", LBGE0350.REGISTRO_LINKAGE_GE0350S);

            /*" -2446- EVALUATE LK-GE350-COD-RETORNO */
            switch (LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO.Value.Trim())
            {

                /*" -2447- WHEN '0' */
                case "0":

                    /*" -2448- IF (LK-GE350-COD-SITUACAO EQUAL 'H' OR 'O' ) */

                    if ((LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO.In("H", "O")))
                    {

                        /*" -2450- IF (LK-GE350-DTA-VENCIMENTO = V0HIST-DTVENCTO) AND (LK-GE350-VLR-PREMIO-TOTAL = V0HIST-VLPRMTOT) */

                        if ((LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_VENCIMENTO == V0HIST_DTVENCTO) && (LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_VLR_PREMIO_TOTAL == V0HIST_VLPRMTOT))
                        {

                            /*" -2452- MOVE LK-GE350-NOSSO-NUMERO-SAP TO SVA-NN-SIGCB */
                            _.Move(LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NOSSO_NUMERO_SAP, REG_SVG0267B.SVA_NN_SIGCB);

                            /*" -2454- MOVE LK-GE350-COD-LINHA-DGTVEL TO SVA-LIN-DIGITAVEL */
                            _.Move(LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_LINHA_DGTVEL, REG_SVG0267B.SVA_LIN_DIGITAVEL);

                            /*" -2456- MOVE LK-GE350-DTA-VENCIMENTO TO SVA-DTA-VENC */
                            _.Move(LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_VENCIMENTO, REG_SVG0267B.SVA_DTA_VENC);

                            /*" -2458- MOVE LK-GE350-VLR-PREMIO-TOTAL TO SVA-VLR-PREMIO */
                            _.Move(LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_VLR_PREMIO_TOTAL, REG_SVG0267B.SVA_VLR_PREMIO);

                            /*" -2459- MOVE LK-GE350-VLR-IOF TO SVA-VLR-IOF */
                            _.Move(LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_VLR_IOF, REG_SVG0267B.SVA_VLR_IOF);

                            /*" -2461- COMPUTE SVA-VLR-LIQUIDO ROUNDED = SVA-VLR-PREMIO - SVA-VLR-IOF */
                            REG_SVG0267B.SVA_VLR_LIQUIDO.Value = REG_SVG0267B.SVA_VLR_PREMIO - REG_SVG0267B.SVA_VLR_IOF;

                            /*" -2463- MOVE LK-GE350-COD-CEDENTE-SAP TO SVA-COD-CEDENTE */
                            _.Move(LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_CEDENTE_SAP, REG_SVG0267B.SVA_COD_CEDENTE);

                            /*" -2465- MOVE LK-GE350-SEQ-CNTRLE-SIGCB TO SVA-CNTRLE-SIGCB */
                            _.Move(LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_SEQ_CNTRLE_SIGCB, REG_SVG0267B.SVA_CNTRLE_SIGCB);

                            /*" -2466- ELSE */
                        }
                        else
                        {


                            /*" -2467- PERFORM R1020-SOLICITA-NN-SAP-SIGCB */

                            R1020_SOLICITA_NN_SAP_SIGCB_SECTION();

                            /*" -2468- ADD 1 TO WS-QTD-MUDA-VLR-VENC */
                            AREA_DE_WORK.WS_QTD_MUDA_VLR_VENC.Value = AREA_DE_WORK.WS_QTD_MUDA_VLR_VENC + 1;

                            /*" -2469- END-IF */
                        }


                        /*" -2471- END-IF */
                    }


                    /*" -2472- IF (LK-GE350-COD-SITUACAO EQUAL 'R' ) */

                    if ((LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO == "R"))
                    {

                        /*" -2476- IF (LK-GE350-DTA-VENCIMENTO NOT EQUAL V0HIST-DTVENCTO) OR (LK-GE350-VLR-PREMIO-TOTAL NOT EQUAL V0HIST-VLPRMTOT) */

                        if ((LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_VENCIMENTO != V0HIST_DTVENCTO) || (LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_VLR_PREMIO_TOTAL != V0HIST_VLPRMTOT))
                        {

                            /*" -2481- DISPLAY 'NN REJEITADO E RECOMANDADO' ' => CERTIF ' LK-GE350-NUM-CERTIFICADO ' => NRPARCEL ' LK-GE350-NUM-PARCELA ' => VL-PARC  ' V0HIST-VLPRMTOT ' => DTA-VENC ' V0HIST-DTVENCTO */

                            $"NN REJEITADO E RECOMANDADO => CERTIF {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_CERTIFICADO} => NRPARCEL {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA} => VL-PARC  {V0HIST_VLPRMTOT} => DTA-VENC {V0HIST_DTVENCTO}"
                            .Display();

                            /*" -2482- PERFORM R1020-SOLICITA-NN-SAP-SIGCB */

                            R1020_SOLICITA_NN_SAP_SIGCB_SECTION();

                            /*" -2483- ADD 1 TO WS-QTD-MUDA-VLR-VENC */
                            AREA_DE_WORK.WS_QTD_MUDA_VLR_VENC.Value = AREA_DE_WORK.WS_QTD_MUDA_VLR_VENC + 1;

                            /*" -2484- END-IF */
                        }


                        /*" -2485- END-IF */
                    }


                    /*" -2486- WHEN '1' */
                    break;
                case "1":

                    /*" -2487- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -2488- DISPLAY '*****************************************' */
                    _.Display($"*****************************************");

                    /*" -2489- DISPLAY '*    R1010-CONSULTA-CNTRLE-SIGCB        *' */
                    _.Display($"*    R1010-CONSULTA-CNTRLE-SIGCB        *");

                    /*" -2490- DISPLAY '*  ERRO NA EXECUCAO DO CALL DA GE0350S  *' */
                    _.Display($"*  ERRO NA EXECUCAO DO CALL DA GE0350S  *");

                    /*" -2491- DISPLAY '*****************************************' */
                    _.Display($"*****************************************");

                    /*" -2492- DISPLAY '=> APOLICE........ ' LK-GE350-NUM-APOLICE */
                    _.Display($"=> APOLICE........ {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE}");

                    /*" -2493- DISPLAY '=> CERTIF......... ' LK-GE350-NUM-CERTIFICADO */
                    _.Display($"=> CERTIF......... {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_CERTIFICADO}");

                    /*" -2494- DISPLAY '=> NRPARCEL....... ' LK-GE350-NUM-PARCELA */
                    _.Display($"=> NRPARCEL....... {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA}");

                    /*" -2495- DISPLAY '=> DTA-MOVIMENTO.. ' LK-GE350-DTA-MOVIMENTO */
                    _.Display($"=> DTA-MOVIMENTO.. {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_MOVIMENTO}");

                    /*" -2496- DISPLAY '-----------------------------------------' */
                    _.Display($"-----------------------------------------");

                    /*" -2497- DISPLAY '=> LK-MENSAGEM ... ' LK-GE350-MENSAGEM */
                    _.Display($"=> LK-MENSAGEM ... {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM}");

                    /*" -2498- DISPLAY '=> LK-COD-RETORNO. ' LK-GE350-COD-RETORNO */
                    _.Display($"=> LK-COD-RETORNO. {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO}");

                    /*" -2499- DISPLAY '=> LK-SQLCODE..... ' LK-GE350-SQLCODE */
                    _.Display($"=> LK-SQLCODE..... {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_SQLCODE}");

                    /*" -2500- DISPLAY '*****************************************' */
                    _.Display($"*****************************************");

                    /*" -2501- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2502- WHEN '2' */
                    break;
                case "2":

                    /*" -2503- IF (V0HIST-DTVENCTO > V1SIST-DTMOVABE) */

                    if ((V0HIST_DTVENCTO > V1SIST_DTMOVABE))
                    {

                        /*" -2504- PERFORM R1020-SOLICITA-NN-SAP-SIGCB */

                        R1020_SOLICITA_NN_SAP_SIGCB_SECTION();

                        /*" -2505- ADD 1 TO WS-QTD-SEM-NN-SIGCB */
                        AREA_DE_WORK.WS_QTD_SEM_NN_SIGCB.Value = AREA_DE_WORK.WS_QTD_SEM_NN_SIGCB + 1;

                        /*" -2506- ELSE */
                    }
                    else
                    {


                        /*" -2511- DISPLAY 'ERRO - DT-VENC < DT-SISTEMA ' ' => CERTIF ' LK-GE350-NUM-CERTIFICADO ' => NRPARCEL ' LK-GE350-NUM-PARCELA ' => DTA-VENC ' V0HIST-DTVENCTO ' => DTA-SISTEMA ' V1SIST-DTMOVABE */

                        $"ERRO - DT-VENC < DT-SISTEMA  => CERTIF {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_CERTIFICADO} => NRPARCEL {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA} => DTA-VENC {V0HIST_DTVENCTO} => DTA-SISTEMA {V1SIST_DTMOVABE}"
                        .Display();

                        /*" -2512- END-IF */
                    }


                    /*" -2513- WHEN '3' */
                    break;
                case "3":

                    /*" -2516- IF (LK-GE350-DTA-VENCIMENTO NOT EQUAL V0HIST-DTVENCTO) AND (V0HIST-DTVENCTO > V1SIST-DTMOVABE) */

                    if ((LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_VENCIMENTO != V0HIST_DTVENCTO) && (V0HIST_DTVENCTO > V1SIST_DTMOVABE))
                    {

                        /*" -2520- DISPLAY 'CUSTODIA VENCIDA - SOLICITAR NN' ' => CERTIF ' LK-GE350-NUM-CERTIFICADO ' => NRPARCEL ' LK-GE350-NUM-PARCELA ' => DTA-VENC ' LK-GE350-DTA-VENCIMENTO */

                        $"CUSTODIA VENCIDA - SOLICITAR NN => CERTIF {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_CERTIFICADO} => NRPARCEL {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA} => DTA-VENC {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_VENCIMENTO}"
                        .Display();

                        /*" -2521- PERFORM R1020-SOLICITA-NN-SAP-SIGCB */

                        R1020_SOLICITA_NN_SAP_SIGCB_SECTION();

                        /*" -2522- ADD 1 TO WS-QTD-CUST-VENCIDA */
                        AREA_DE_WORK.WS_QTD_CUST_VENCIDA.Value = AREA_DE_WORK.WS_QTD_CUST_VENCIDA + 1;

                        /*" -2523- END-IF */
                    }


                    /*" -2523- END-EVALUATE. */
                    break;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_99_SAIDA*/

        [StopWatch]
        /*" R1020-SOLICITA-NN-SAP-SIGCB-SECTION */
        private void R1020_SOLICITA_NN_SAP_SIGCB_SECTION()
        {
            /*" -2535- MOVE '1020' TO WNR-EXEC-SQL. */
            _.Move("1020", WABEND.WNR_EXEC_SQL);

            /*" -2537- PERFORM R1040-SOLICITA-NN-SAP-CICS. */

            R1040_SOLICITA_NN_SAP_CICS_SECTION();

            /*" -2538- IF (LK-GE350-NOSSO-NUMERO-SAP > ZEROS) */

            if ((LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NOSSO_NUMERO_SAP > 00))
            {

                /*" -2539- MOVE LK-GE350-NOSSO-NUMERO-SAP TO SVA-NN-SIGCB */
                _.Move(LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NOSSO_NUMERO_SAP, REG_SVG0267B.SVA_NN_SIGCB);

                /*" -2540- MOVE LK-GE350-COD-LINHA-DGTVEL TO SVA-LIN-DIGITAVEL */
                _.Move(LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_LINHA_DGTVEL, REG_SVG0267B.SVA_LIN_DIGITAVEL);

                /*" -2541- MOVE LK-GE350-DTA-VENCIMENTO TO SVA-DTA-VENC */
                _.Move(LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_VENCIMENTO, REG_SVG0267B.SVA_DTA_VENC);

                /*" -2542- MOVE LK-GE350-VLR-PREMIO-TOTAL TO SVA-VLR-PREMIO */
                _.Move(LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_VLR_PREMIO_TOTAL, REG_SVG0267B.SVA_VLR_PREMIO);

                /*" -2543- MOVE LK-GE350-VLR-IOF TO SVA-VLR-IOF */
                _.Move(LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_VLR_IOF, REG_SVG0267B.SVA_VLR_IOF);

                /*" -2545- COMPUTE SVA-VLR-LIQUIDO ROUNDED = SVA-VLR-PREMIO - SVA-VLR-IOF */
                REG_SVG0267B.SVA_VLR_LIQUIDO.Value = REG_SVG0267B.SVA_VLR_PREMIO - REG_SVG0267B.SVA_VLR_IOF;

                /*" -2546- MOVE LK-GE350-COD-CEDENTE-SAP TO SVA-COD-CEDENTE */
                _.Move(LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_CEDENTE_SAP, REG_SVG0267B.SVA_COD_CEDENTE);

                /*" -2547- MOVE LK-GE350-SEQ-CNTRLE-SIGCB TO SVA-CNTRLE-SIGCB */
                _.Move(LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_SEQ_CNTRLE_SIGCB, REG_SVG0267B.SVA_CNTRLE_SIGCB);

                /*" -2551- DISPLAY 'COMPRA NN VIA CICS --> ' ' => CERTIF ' LK-GE350-NUM-CERTIFICADO ' => NRPARCEL ' LK-GE350-NUM-PARCELA ' => NN-SAP ' LK-GE350-NOSSO-NUMERO-SAP */

                $"COMPRA NN VIA CICS -->  => CERTIF {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_CERTIFICADO} => NRPARCEL {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA} => NN-SAP {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NOSSO_NUMERO_SAP}"
                .Display();

                /*" -2552- ELSE */
            }
            else
            {


                /*" -2553- PERFORM R1100-SOLICITA-NN-SAP-ARQA */

                R1100_SOLICITA_NN_SAP_ARQA_SECTION();

                /*" -2553- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1020_99_SAIDA*/

        [StopWatch]
        /*" R1040-SOLICITA-NN-SAP-CICS-SECTION */
        private void R1040_SOLICITA_NN_SAP_CICS_SECTION()
        {
            /*" -2566- MOVE '1040' TO WNR-EXEC-SQL. */
            _.Move("1040", WABEND.WNR_EXEC_SQL);

            /*" -2568- COMPUTE WS-IDLG-SEQ = LK-GE350-SEQ-CNTRLE-SIGCB + 1 */
            AREA_DE_WORK.FILLER_175.WS_IDLG_SEQ.Value = LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_SEQ_CNTRLE_SIGCB + 1;

            /*" -2570- INITIALIZE REGISTRO-LINKAGE-GE0350S. */
            _.Initialize(
                LBGE0350.REGISTRO_LINKAGE_GE0350S
            );

            /*" -2572- PERFORM R1050-00-CONSULTA-ENDOSSO-0. */

            R1050_00_CONSULTA_ENDOSSO_0_SECTION();

            /*" -2574- MOVE ZEROS TO RAMOCOMP-PCT-IOCC-RAMO */
            _.Move(0, AREA_DE_WORK.RAMOCOMP_PCT_IOCC_RAMO);

            /*" -2575- MOVE 07 TO LK-GE350-COD-FUNCAO */
            _.Move(07, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_FUNCAO);

            /*" -2576- MOVE V0HIST-NRAPOLICE TO LK-GE350-NUM-APOLICE */
            _.Move(V0HIST_NRAPOLICE, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE);

            /*" -2577- MOVE V0HIST-NRCERTIF TO LK-GE350-NUM-CERTIFICADO */
            _.Move(V0HIST_NRCERTIF, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_CERTIFICADO);

            /*" -2578- MOVE V0HIST-NRPARCEL TO LK-GE350-NUM-PARCELA */
            _.Move(V0HIST_NRPARCEL, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA);

            /*" -2579- MOVE ZEROS TO LK-GE350-NUM-ENDOSSO */
            _.Move(0, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO);

            /*" -2580- MOVE ZEROS TO LK-GE350-NUM-PROPOSTA */
            _.Move(0, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PROPOSTA);

            /*" -2581- MOVE V1SIST-DTMOVABE TO LK-GE350-DTA-MOVIMENTO */
            _.Move(V1SIST_DTMOVABE, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_MOVIMENTO);

            /*" -2582- MOVE ZEROS TO LK-GE350-NUM-OCORR-MOVTO */
            _.Move(0, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_OCORR_MOVTO);

            /*" -2583- MOVE V0HIST-CODPRODU TO LK-GE350-COD-PRODUTO */
            _.Move(V0HIST_CODPRODU, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_PRODUTO);

            /*" -2584- MOVE V0HIST-DTVENCTO TO LK-GE350-DTA-VENCIMENTO */
            _.Move(V0HIST_DTVENCTO, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_VENCIMENTO);

            /*" -2585- MOVE V0HIST-NRTIT TO LK-GE350-NUM-TITULO */
            _.Move(V0HIST_NRTIT, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_TITULO);

            /*" -2586- MOVE V0HIST-QTDPARCEL TO LK-GE350-QTD-PARCELA */
            _.Move(V0HIST_QTDPARCEL, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_QTD_PARCELA);

            /*" -2587- MOVE 29 TO LK-GE350-QTD-DIAS-CUSTODIA */
            _.Move(29, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_QTD_DIAS_CUSTODIA);

            /*" -2588- MOVE V0HIST-CDCLIENTE TO LK-GE350-COD-CLIENTE */
            _.Move(V0HIST_CDCLIENTE, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_CLIENTE);

            /*" -2590- MOVE V0HIST-VLPRMTOT TO LK-GE350-VLR-PREMIO-TOTAL */
            _.Move(V0HIST_VLPRMTOT, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_VLR_PREMIO_TOTAL);

            /*" -2591- MOVE PROPOVA-COD-FONTE TO LK-GE350-COD-FONTE */
            _.Move(PROPOVA_COD_FONTE, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_FONTE);

            /*" -2592- MOVE 'SIAS      ' TO LK-GE350-COD-SISTEMA */
            _.Move("SIAS      ", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SISTEMA);

            /*" -2594- MOVE 'SIAS_09518' TO LK-GE350-COD-EVENTO */
            _.Move("SIAS_09518", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_EVENTO);

            /*" -2595- MOVE V0HIST-NRCERTIF TO LK-GE350-NUM-CONTA-CNTRO */
            _.Move(V0HIST_NRCERTIF, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_CONTA_CNTRO);

            /*" -2596- MOVE 8 TO LK-GE350-COD-CANAL */
            _.Move(8, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_CANAL);

            /*" -2598- MOVE 'R' TO LK-GE350-COD-TP-CONVENIO */
            _.Move("R", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_TP_CONVENIO);

            /*" -2599- MOVE V0HIST-NRCERTIF TO WS-IDLG-VD-CERTIF */
            _.Move(V0HIST_NRCERTIF, AREA_DE_WORK.FILLER_175.WS_IDLG_VD_CERTIF);

            /*" -2600- MOVE V0HIST-NRPARCEL TO WS-IDLG-VD-PARC */
            _.Move(V0HIST_NRPARCEL, AREA_DE_WORK.FILLER_175.WS_IDLG_VD_PARC);

            /*" -2601- MOVE V0HIST-NRTIT TO WS-IDLG-VD-TIT */
            _.Move(V0HIST_NRTIT, AREA_DE_WORK.FILLER_175.WS_IDLG_VD_TIT);

            /*" -2602- MOVE 'VG267O' TO WS-IDLG-FILLER */
            _.Move("VG267O", AREA_DE_WORK.FILLER_175.WS_IDLG_FILLER);

            /*" -2604- MOVE WS-IDLG-VD TO LK-GE350-NUM-IDLG */
            _.Move(AREA_DE_WORK.WS_IDLG_VD, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_IDLG);

            /*" -2606- PERFORM R1060-00-CONSULTA-IOF-BOLETO */

            R1060_00_CONSULTA_IOF_BOLETO_SECTION();

            /*" -2607- MOVE 'VG' TO LK-GE350-IDE-SISTEMA */
            _.Move("VG", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_IDE_SISTEMA);

            /*" -2608- MOVE 'VG0267B' TO LK-GE350-COD-USUARIO */
            _.Move("VG0267B", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_USUARIO);

            /*" -2610- MOVE 'O' TO LK-GE350-COD-SITUACAO */
            _.Move("O", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO);

            /*" -2612- CALL 'GE0350S' USING REGISTRO-LINKAGE-GE0350S. */
            _.Call("GE0350S", LBGE0350.REGISTRO_LINKAGE_GE0350S);

            /*" -2614- IF (LK-GE350-COD-RETORNO NOT EQUAL '0' ) OR (LK-GE350-NOSSO-NUMERO-SAP EQUAL ZEROS) */

            if ((LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO != "0") || (LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NOSSO_NUMERO_SAP == 00))
            {

                /*" -2615- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -2616- DISPLAY '*       R1040-SOLICITA-NN-SAP-CICS      *' */
                _.Display($"*       R1040-SOLICITA-NN-SAP-CICS      *");

                /*" -2617- DISPLAY '*  ERRO NA EXECUCAO DA GE0350S-CICS/SAP *' */
                _.Display($"*  ERRO NA EXECUCAO DA GE0350S-CICS/SAP *");

                /*" -2618- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -2619- DISPLAY '=> APOLICE........ ' LK-GE350-NUM-APOLICE */
                _.Display($"=> APOLICE........ {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE}");

                /*" -2620- DISPLAY '=> CERTIF......... ' LK-GE350-NUM-CERTIFICADO */
                _.Display($"=> CERTIF......... {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_CERTIFICADO}");

                /*" -2621- DISPLAY '=> NRPARCEL....... ' LK-GE350-NUM-PARCELA */
                _.Display($"=> NRPARCEL....... {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA}");

                /*" -2622- DISPLAY '=> SEQ-CNTRLE..... ' LK-GE350-SEQ-CNTRLE-SIGCB */
                _.Display($"=> SEQ-CNTRLE..... {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_SEQ_CNTRLE_SIGCB}");

                /*" -2623- DISPLAY '-----------------------------------------' */
                _.Display($"-----------------------------------------");

                /*" -2624- DISPLAY '=> LK-MENSAGEM ... ' LK-GE350-MENSAGEM */
                _.Display($"=> LK-MENSAGEM ... {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM}");

                /*" -2625- DISPLAY '=> LK-COD-RETORNO. ' LK-GE350-COD-RETORNO */
                _.Display($"=> LK-COD-RETORNO. {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO}");

                /*" -2626- DISPLAY '=> LK-SQLCODE..... ' LK-GE350-SQLCODE */
                _.Display($"=> LK-SQLCODE..... {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_SQLCODE}");

                /*" -2627- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -2627- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1040_99_SAIDA*/

        [StopWatch]
        /*" R1050-00-CONSULTA-ENDOSSO-0-SECTION */
        private void R1050_00_CONSULTA_ENDOSSO_0_SECTION()
        {
            /*" -2639- MOVE '1050' TO WNR-EXEC-SQL. */
            _.Move("1050", WABEND.WNR_EXEC_SQL);

            /*" -2647- PERFORM R1050_00_CONSULTA_ENDOSSO_0_DB_SELECT_1 */

            R1050_00_CONSULTA_ENDOSSO_0_DB_SELECT_1();

            /*" -2650- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -2652- DISPLAY 'R1050-ERRO NO ACESSO A ENDOSSOS 0 ' V0HIST-NRAPOLICE */
                _.Display($"R1050-ERRO NO ACESSO A ENDOSSOS 0 {V0HIST_NRAPOLICE}");

                /*" -2653- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2653- END-IF. */
            }


        }

        [StopWatch]
        /*" R1050-00-CONSULTA-ENDOSSO-0-DB-SELECT-1 */
        public void R1050_00_CONSULTA_ENDOSSO_0_DB_SELECT_1()
        {
            /*" -2647- EXEC SQL SELECT VALUE(COD_FONTE, 10) INTO :PROPOVA-COD-FONTE FROM SEGUROS.ENDOSSOS WHERE NUM_APOLICE = :V0HIST-NRAPOLICE AND NUM_ENDOSSO = 0 FETCH FIRST 1 ROW ONLY WITH UR END-EXEC. */

            var r1050_00_CONSULTA_ENDOSSO_0_DB_SELECT_1_Query1 = new R1050_00_CONSULTA_ENDOSSO_0_DB_SELECT_1_Query1()
            {
                V0HIST_NRAPOLICE = V0HIST_NRAPOLICE.ToString(),
            };

            var executed_1 = R1050_00_CONSULTA_ENDOSSO_0_DB_SELECT_1_Query1.Execute(r1050_00_CONSULTA_ENDOSSO_0_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOVA_COD_FONTE, PROPOVA_COD_FONTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1050_99_SAIDA*/

        [StopWatch]
        /*" R1060-00-CONSULTA-IOF-BOLETO-SECTION */
        private void R1060_00_CONSULTA_IOF_BOLETO_SECTION()
        {
            /*" -2664- MOVE '1060' TO WNR-EXEC-SQL. */
            _.Move("1060", WABEND.WNR_EXEC_SQL);

            /*" -2672- PERFORM R1060_00_CONSULTA_IOF_BOLETO_DB_SELECT_1 */

            R1060_00_CONSULTA_IOF_BOLETO_DB_SELECT_1();

            /*" -2675- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -2676- DISPLAY 'R1060-ERRO NO ACESSO A SUBGRUPOS_VGAP ' */
                _.Display($"R1060-ERRO NO ACESSO A SUBGRUPOS_VGAP ");

                /*" -2677- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2679- END-IF. */
            }


            /*" -2680- IF (V0SUBG-IND-IOF EQUAL 'S' ) */

            if ((AREA_DE_WORK.V0SUBG_IND_IOF == "S"))
            {

                /*" -2681- PERFORM R1070-00-CONSULTA-APOLICE */

                R1070_00_CONSULTA_APOLICE_SECTION();

                /*" -2683- END-IF. */
            }


            /*" -2684- IF (RAMOCOMP-PCT-IOCC-RAMO EQUAL ZEROS) */

            if ((AREA_DE_WORK.RAMOCOMP_PCT_IOCC_RAMO == 00))
            {

                /*" -2687- DISPLAY 'APOLICE SEM PERCENTUAL DE IOF ' LK-GE350-NUM-APOLICE ' - ' LK-GE350-NUM-CERTIFICADO ' - ' */

                $"APOLICE SEM PERCENTUAL DE IOF {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE} - {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_CERTIFICADO} - "
                .Display();

                /*" -2688- MOVE 0,38 TO RAMOCOMP-PCT-IOCC-RAMO */
                _.Move(0.38, AREA_DE_WORK.RAMOCOMP_PCT_IOCC_RAMO);

                /*" -2689- MOVE 'S' TO V0SUBG-IND-IOF */
                _.Move("S", AREA_DE_WORK.V0SUBG_IND_IOF);

                /*" -2691- END-IF. */
            }


            /*" -2693- IF (V0SUBG-IND-IOF EQUAL 'S' ) AND (RAMOCOMP-PCT-IOCC-RAMO > ZEROS) */

            if ((AREA_DE_WORK.V0SUBG_IND_IOF == "S") && (AREA_DE_WORK.RAMOCOMP_PCT_IOCC_RAMO > 00))
            {

                /*" -2695- COMPUTE LK-GE350-VLR-IOF = (V0HIST-VLPRMTOT * RAMOCOMP-PCT-IOCC-RAMO) / 100 */
                LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_VLR_IOF.Value = (V0HIST_VLPRMTOT * AREA_DE_WORK.RAMOCOMP_PCT_IOCC_RAMO) / 100f;

                /*" -2696- ELSE */
            }
            else
            {


                /*" -2697- MOVE ZEROS TO LK-GE350-VLR-IOF */
                _.Move(0, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_VLR_IOF);

                /*" -2699- END-IF. */
            }


            /*" -2700- IF (LK-GE350-VLR-IOF EQUAL ZEROS) */

            if ((LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_VLR_IOF == 00))
            {

                /*" -2701- MOVE 0,01 TO LK-GE350-VLR-IOF */
                _.Move(0.01, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_VLR_IOF);

                /*" -2701- END-IF. */
            }


        }

        [StopWatch]
        /*" R1060-00-CONSULTA-IOF-BOLETO-DB-SELECT-1 */
        public void R1060_00_CONSULTA_IOF_BOLETO_DB_SELECT_1()
        {
            /*" -2672- EXEC SQL SELECT VALUE(IND_IOF, 'S' ) INTO :V0SUBG-IND-IOF FROM SEGUROS.SUBGRUPOS_VGAP WHERE NUM_APOLICE = :V0HIST-NRAPOLICE AND COD_SUBGRUPO = :V0HIST-CODSUBES FETCH FIRST 1 ROW ONLY WITH UR END-EXEC. */

            var r1060_00_CONSULTA_IOF_BOLETO_DB_SELECT_1_Query1 = new R1060_00_CONSULTA_IOF_BOLETO_DB_SELECT_1_Query1()
            {
                V0HIST_NRAPOLICE = V0HIST_NRAPOLICE.ToString(),
                V0HIST_CODSUBES = V0HIST_CODSUBES.ToString(),
            };

            var executed_1 = R1060_00_CONSULTA_IOF_BOLETO_DB_SELECT_1_Query1.Execute(r1060_00_CONSULTA_IOF_BOLETO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SUBG_IND_IOF, AREA_DE_WORK.V0SUBG_IND_IOF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1060_99_SAIDA*/

        [StopWatch]
        /*" R1070-00-CONSULTA-APOLICE-SECTION */
        private void R1070_00_CONSULTA_APOLICE_SECTION()
        {
            /*" -2712- MOVE '1070' TO WNR-EXEC-SQL. */
            _.Move("1070", WABEND.WNR_EXEC_SQL);

            /*" -2723- PERFORM R1070_00_CONSULTA_APOLICE_DB_SELECT_1 */

            R1070_00_CONSULTA_APOLICE_DB_SELECT_1();

            /*" -2726- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -2727- DISPLAY 'R1070-ERRO NO ACESSO A APOLICE/RAMO-COMPL ' */
                _.Display($"R1070-ERRO NO ACESSO A APOLICE/RAMO-COMPL ");

                /*" -2728- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2728- END-IF. */
            }


        }

        [StopWatch]
        /*" R1070-00-CONSULTA-APOLICE-DB-SELECT-1 */
        public void R1070_00_CONSULTA_APOLICE_DB_SELECT_1()
        {
            /*" -2723- EXEC SQL SELECT VALUE(B.PCT_IOCC_RAMO, 0) INTO :RAMOCOMP-PCT-IOCC-RAMO FROM SEGUROS.V0APOLICE A, SEGUROS.RAMO_COMPLEMENTAR B WHERE A.NUM_APOLICE = :V0HIST-NRAPOLICE AND A.RAMO = B.RAMO_EMISSOR AND B.DATA_INIVIGENCIA <= :V1SIST-DTMOVABE AND B.DATA_TERVIGENCIA >= :V1SIST-DTMOVABE FETCH FIRST 1 ROW ONLY WITH UR END-EXEC. */

            var r1070_00_CONSULTA_APOLICE_DB_SELECT_1_Query1 = new R1070_00_CONSULTA_APOLICE_DB_SELECT_1_Query1()
            {
                V0HIST_NRAPOLICE = V0HIST_NRAPOLICE.ToString(),
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
            };

            var executed_1 = R1070_00_CONSULTA_APOLICE_DB_SELECT_1_Query1.Execute(r1070_00_CONSULTA_APOLICE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RAMOCOMP_PCT_IOCC_RAMO, AREA_DE_WORK.RAMOCOMP_PCT_IOCC_RAMO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1070_99_SAIDA*/

        [StopWatch]
        /*" R1100-SOLICITA-NN-SAP-ARQA-SECTION */
        private void R1100_SOLICITA_NN_SAP_ARQA_SECTION()
        {
            /*" -2741- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", WABEND.WNR_EXEC_SQL);

            /*" -2742- INITIALIZE REGISTRO-LINKAGE-GE0350S. */
            _.Initialize(
                LBGE0350.REGISTRO_LINKAGE_GE0350S
            );

            /*" -2744- MOVE ZEROS TO RAMOCOMP-PCT-IOCC-RAMO */
            _.Move(0, AREA_DE_WORK.RAMOCOMP_PCT_IOCC_RAMO);

            /*" -2745- MOVE 02 TO LK-GE350-COD-FUNCAO */
            _.Move(02, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_FUNCAO);

            /*" -2746- MOVE V0HIST-NRAPOLICE TO LK-GE350-NUM-APOLICE */
            _.Move(V0HIST_NRAPOLICE, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE);

            /*" -2747- MOVE V0HIST-NRCERTIF TO LK-GE350-NUM-CERTIFICADO */
            _.Move(V0HIST_NRCERTIF, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_CERTIFICADO);

            /*" -2748- MOVE V0HIST-NRPARCEL TO LK-GE350-NUM-PARCELA */
            _.Move(V0HIST_NRPARCEL, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA);

            /*" -2749- MOVE ZEROS TO LK-GE350-NUM-ENDOSSO */
            _.Move(0, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO);

            /*" -2750- MOVE ZEROS TO LK-GE350-NUM-PROPOSTA */
            _.Move(0, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PROPOSTA);

            /*" -2751- MOVE V1SIST-DTMOVABE TO LK-GE350-DTA-MOVIMENTO */
            _.Move(V1SIST_DTMOVABE, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_MOVIMENTO);

            /*" -2752- MOVE ZEROS TO LK-GE350-NUM-OCORR-MOVTO */
            _.Move(0, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_OCORR_MOVTO);

            /*" -2753- MOVE V0HIST-CODPRODU TO LK-GE350-COD-PRODUTO */
            _.Move(V0HIST_CODPRODU, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_PRODUTO);

            /*" -2754- MOVE V0HIST-DTVENCTO TO LK-GE350-DTA-VENCIMENTO */
            _.Move(V0HIST_DTVENCTO, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_VENCIMENTO);

            /*" -2755- MOVE V0HIST-VLPRMTOT TO LK-GE350-VLR-PREMIO-TOTAL */
            _.Move(V0HIST_VLPRMTOT, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_VLR_PREMIO_TOTAL);

            /*" -2756- MOVE V0HIST-NRTIT TO LK-GE350-NUM-TITULO */
            _.Move(V0HIST_NRTIT, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_TITULO);

            /*" -2757- MOVE V0HIST-QTDPARCEL TO LK-GE350-QTD-PARCELA */
            _.Move(V0HIST_QTDPARCEL, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_QTD_PARCELA);

            /*" -2758- MOVE 29 TO LK-GE350-QTD-DIAS-CUSTODIA */
            _.Move(29, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_QTD_DIAS_CUSTODIA);

            /*" -2760- MOVE V0HIST-CDCLIENTE TO LK-GE350-COD-CLIENTE */
            _.Move(V0HIST_CDCLIENTE, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_CLIENTE);

            /*" -2762- PERFORM R1060-00-CONSULTA-IOF-BOLETO. */

            R1060_00_CONSULTA_IOF_BOLETO_SECTION();

            /*" -2763- MOVE 'VG' TO LK-GE350-IDE-SISTEMA */
            _.Move("VG", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_IDE_SISTEMA);

            /*" -2764- MOVE 'VG0267B' TO LK-GE350-COD-USUARIO */
            _.Move("VG0267B", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_USUARIO);

            /*" -2766- MOVE 'P' TO LK-GE350-COD-SITUACAO */
            _.Move("P", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO);

            /*" -2768- CALL 'GE0350S' USING REGISTRO-LINKAGE-GE0350S. */
            _.Call("GE0350S", LBGE0350.REGISTRO_LINKAGE_GE0350S);

            /*" -2769- IF (LK-GE350-COD-RETORNO NOT EQUAL '0' ) */

            if ((LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO != "0"))
            {

                /*" -2770- DISPLAY ' ' */
                _.Display($" ");

                /*" -2771- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -2772- DISPLAY '*    R1100-SOLICITA-NN-SAP-SIGCB       *' */
                _.Display($"*    R1100-SOLICITA-NN-SAP-SIGCB       *");

                /*" -2773- DISPLAY '*  ERRO NA EXECUCAO DO CALL DA GE0350S  *' */
                _.Display($"*  ERRO NA EXECUCAO DO CALL DA GE0350S  *");

                /*" -2774- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -2775- DISPLAY '=> APOLICE........ ' LK-GE350-NUM-APOLICE */
                _.Display($"=> APOLICE........ {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE}");

                /*" -2776- DISPLAY '=> CERTIF......... ' LK-GE350-NUM-CERTIFICADO */
                _.Display($"=> CERTIF......... {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_CERTIFICADO}");

                /*" -2777- DISPLAY '=> NRPARCEL....... ' LK-GE350-NUM-PARCELA */
                _.Display($"=> NRPARCEL....... {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA}");

                /*" -2778- DISPLAY '=> DTA-MOVIMENTO.. ' LK-GE350-DTA-MOVIMENTO */
                _.Display($"=> DTA-MOVIMENTO.. {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_MOVIMENTO}");

                /*" -2779- DISPLAY '-----------------------------------------' */
                _.Display($"-----------------------------------------");

                /*" -2780- DISPLAY '=> LK-MENSAGEM ... ' LK-GE350-MENSAGEM */
                _.Display($"=> LK-MENSAGEM ... {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM}");

                /*" -2781- DISPLAY '=> LK-COD-RETORNO. ' LK-GE350-COD-RETORNO */
                _.Display($"=> LK-COD-RETORNO. {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO}");

                /*" -2782- DISPLAY '=> LK-SQLCODE..... ' LK-GE350-SQLCODE */
                _.Display($"=> LK-SQLCODE..... {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_SQLCODE}");

                /*" -2783- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -2784- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2784- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-SELECT-V0CLIENTE-SECTION */
        private void R1200_00_SELECT_V0CLIENTE_SECTION()
        {
            /*" -2796- MOVE 'R1200-00-SELECT-V0' TO PARAGRAFO. */
            _.Move("R1200-00-SELECT-V0", PARAGRAFO);

            /*" -2798- MOVE '120' TO WNR-EXEC-SQL. */
            _.Move("120", WABEND.WNR_EXEC_SQL);

            /*" -2805- PERFORM R1200_00_SELECT_V0CLIENTE_DB_SELECT_1 */

            R1200_00_SELECT_V0CLIENTE_DB_SELECT_1();

            /*" -2808- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2809- DISPLAY 'R1200 - PROBLEMAS NO ACESSO A V0CLIENTE' */
                _.Display($"R1200 - PROBLEMAS NO ACESSO A V0CLIENTE");

                /*" -2810- DISPLAY 'CLIENTE           => ' V0HIST-CDCLIENTE */
                _.Display($"CLIENTE           => {V0HIST_CDCLIENTE}");

                /*" -2810- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1200-00-SELECT-V0CLIENTE-DB-SELECT-1 */
        public void R1200_00_SELECT_V0CLIENTE_DB_SELECT_1()
        {
            /*" -2805- EXEC SQL SELECT NOME_RAZAO, CGCCPF INTO :V0CLIE-NOME-RAZAO, :V0CLIE-CNPJ FROM SEGUROS.V0CLIENTE WHERE COD_CLIENTE = :V0HIST-CDCLIENTE END-EXEC. */

            var r1200_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1 = new R1200_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1()
            {
                V0HIST_CDCLIENTE = V0HIST_CDCLIENTE.ToString(),
            };

            var executed_1 = R1200_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1.Execute(r1200_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CLIE_NOME_RAZAO, V0CLIE_NOME_RAZAO);
                _.Move(executed_1.V0CLIE_CNPJ, V0CLIE_CNPJ);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-SELECT-V0ENDERECO-SECTION */
        private void R1300_00_SELECT_V0ENDERECO_SECTION()
        {
            /*" -2822- MOVE 'R1300-00-SELECT-V0' TO PARAGRAFO. */
            _.Move("R1300-00-SELECT-V0", PARAGRAFO);

            /*" -2824- MOVE '130' TO WNR-EXEC-SQL. */
            _.Move("130", WABEND.WNR_EXEC_SQL);

            /*" -2838- PERFORM R1300_00_SELECT_V0ENDERECO_DB_SELECT_1 */

            R1300_00_SELECT_V0ENDERECO_DB_SELECT_1();

            /*" -2841- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2842- DISPLAY 'R1300 - PROBLEMAS NO ACESSO A V0ENDERECOS' */
                _.Display($"R1300 - PROBLEMAS NO ACESSO A V0ENDERECOS");

                /*" -2843- DISPLAY 'CLIENTE           => ' V0HIST-CDCLIENTE */
                _.Display($"CLIENTE           => {V0HIST_CDCLIENTE}");

                /*" -2843- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1300-00-SELECT-V0ENDERECO-DB-SELECT-1 */
        public void R1300_00_SELECT_V0ENDERECO_DB_SELECT_1()
        {
            /*" -2838- EXEC SQL SELECT ENDERECO, BAIRRO, CIDADE, SIGLA_UF, CEP INTO :V0ENDE-ENDERECO, :V0ENDE-BAIRRO, :V0ENDE-CIDADE, :V0ENDE-UF, :V0ENDE-CEP FROM SEGUROS.V0ENDERECOS WHERE COD_CLIENTE = :V0HIST-CDCLIENTE AND OCORR_ENDERECO = :V0HIST-OCOREND END-EXEC. */

            var r1300_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1 = new R1300_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1()
            {
                V0HIST_CDCLIENTE = V0HIST_CDCLIENTE.ToString(),
                V0HIST_OCOREND = V0HIST_OCOREND.ToString(),
            };

            var executed_1 = R1300_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1.Execute(r1300_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ENDE_ENDERECO, V0ENDE_ENDERECO);
                _.Move(executed_1.V0ENDE_BAIRRO, V0ENDE_BAIRRO);
                _.Move(executed_1.V0ENDE_CIDADE, V0ENDE_CIDADE);
                _.Move(executed_1.V0ENDE_UF, V0ENDE_UF);
                _.Move(executed_1.V0ENDE_CEP, V0ENDE_CEP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-SELECT-V1AGENCEF-SECTION */
        private void R1500_00_SELECT_V1AGENCEF_SECTION()
        {
            /*" -2855- MOVE 'R1500-00-SELECT-V1' TO PARAGRAFO. */
            _.Move("R1500-00-SELECT-V1", PARAGRAFO);

            /*" -2857- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", WABEND.WNR_EXEC_SQL);

            /*" -2866- PERFORM R1500_00_SELECT_V1AGENCEF_DB_SELECT_1 */

            R1500_00_SELECT_V1AGENCEF_DB_SELECT_1();

            /*" -2869- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2870- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2871- MOVE V0HIST-FONTE TO V1MCEF-COD-FONTE */
                    _.Move(V0HIST_FONTE, V1MCEF_COD_FONTE);

                    /*" -2872- ELSE */
                }
                else
                {


                    /*" -2873- DISPLAY 'R1500 - PROBLEMAS SELECT V1AGENCEF ..' */
                    _.Display($"R1500 - PROBLEMAS SELECT V1AGENCEF ..");

                    /*" -2874- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -2874- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1500-00-SELECT-V1AGENCEF-DB-SELECT-1 */
        public void R1500_00_SELECT_V1AGENCEF_DB_SELECT_1()
        {
            /*" -2866- EXEC SQL SELECT B.COD_FONTE INTO :V1MCEF-COD-FONTE FROM SEGUROS.V1AGENCIACEF A, SEGUROS.V1MALHACEF B WHERE A.COD_ESCNEG > 99 AND A.COD_ESCNEG < 1000 AND A.COD_ESCNEG = B.COD_SUREG AND A.COD_AGENCIA = :V0HIST-AGECOBR END-EXEC. */

            var r1500_00_SELECT_V1AGENCEF_DB_SELECT_1_Query1 = new R1500_00_SELECT_V1AGENCEF_DB_SELECT_1_Query1()
            {
                V0HIST_AGECOBR = V0HIST_AGECOBR.ToString(),
            };

            var executed_1 = R1500_00_SELECT_V1AGENCEF_DB_SELECT_1_Query1.Execute(r1500_00_SELECT_V1AGENCEF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1MCEF_COD_FONTE, V1MCEF_COD_FONTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1510-00-SELECT-V0OPCAOPAGVA-SECTION */
        private void R1510_00_SELECT_V0OPCAOPAGVA_SECTION()
        {
            /*" -2886- MOVE 'R1510-00-SELECT-V0' TO PARAGRAFO. */
            _.Move("R1510-00-SELECT-V0", PARAGRAFO);

            /*" -2888- MOVE '1510' TO WNR-EXEC-SQL. */
            _.Move("1510", WABEND.WNR_EXEC_SQL);

            /*" -2894- PERFORM R1510_00_SELECT_V0OPCAOPAGVA_DB_SELECT_1 */

            R1510_00_SELECT_V0OPCAOPAGVA_DB_SELECT_1();

            /*" -2897- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2898- DISPLAY 'R1500 - PROBLEMAS SELECT V1AGENCEF ..' */
                _.Display($"R1500 - PROBLEMAS SELECT V1AGENCEF ..");

                /*" -2899- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -2899- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1510-00-SELECT-V0OPCAOPAGVA-DB-SELECT-1 */
        public void R1510_00_SELECT_V0OPCAOPAGVA_DB_SELECT_1()
        {
            /*" -2894- EXEC SQL SELECT PERIPGTO INTO :V0OPCP-PERIPGTO FROM SEGUROS.V0OPCAOPAGVA WHERE NRCERTIF = :V0HIST-NRCERTIF AND DTTERVIG = '9999-12-31' END-EXEC. */

            var r1510_00_SELECT_V0OPCAOPAGVA_DB_SELECT_1_Query1 = new R1510_00_SELECT_V0OPCAOPAGVA_DB_SELECT_1_Query1()
            {
                V0HIST_NRCERTIF = V0HIST_NRCERTIF.ToString(),
            };

            var executed_1 = R1510_00_SELECT_V0OPCAOPAGVA_DB_SELECT_1_Query1.Execute(r1510_00_SELECT_V0OPCAOPAGVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0OPCP_PERIPGTO, V0OPCP_PERIPGTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1510_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-LOCALIZA-CEP-SECTION */
        private void R1600_00_LOCALIZA_CEP_SECTION()
        {
            /*" -2911- MOVE 'R1600-00-LOCALIZA-' TO PARAGRAFO. */
            _.Move("R1600-00-LOCALIZA-", PARAGRAFO);

            /*" -2911- MOVE 1 TO WIND. */
            _.Move(1, AREA_DE_WORK.WIND);

            /*" -0- FLUXCONTROL_PERFORM R1600_10_LOOP */

            R1600_10_LOOP();

        }

        [StopWatch]
        /*" R1600-10-LOOP */
        private void R1600_10_LOOP(bool isPerform = false)
        {
            /*" -2916- IF WIND GREATER 2000 */

            if (AREA_DE_WORK.WIND > 2000)
            {

                /*" -2918- DISPLAY '*** R1600 - CEP NAO ENCONTRADO ' V0ENDE-CEP ' ' V0HIST-NRCERTIF */

                $"*** R1600 - CEP NAO ENCONTRADO {V0ENDE_CEP} {V0HIST_NRCERTIF}"
                .Display();

                /*" -2919- MOVE 01 TO SVA-CEP-G */
                _.Move(01, REG_SVG0267B.SVA_CEP_G);

                /*" -2920- MOVE TAB-FAIXAS (01) TO SVA-NOME-CORREIO */
                _.Move(TABELA_CEP.CEP[01].TAB_FAIXAS, REG_SVG0267B.SVA_NOME_CORREIO);

                /*" -2922- GO TO R1600-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2923- MOVE TAB-FX-FIM (WIND) TO WS-SUP. */
            _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WIND].TAB_FAIXAS.TAB_FX_FIM, AREA_DE_WORK.WS_SUP);

            /*" -2925- MOVE TAB-FX-INI (WIND) TO WS-INF. */
            _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WIND].TAB_FAIXAS.TAB_FX_INI, AREA_DE_WORK.WS_INF);

            /*" -2926- ADD 1 TO WS-SUP. */
            AREA_DE_WORK.WS_SUP.Value = AREA_DE_WORK.WS_SUP + 1;

            /*" -2928- SUBTRACT 1 FROM WS-INF. */
            AREA_DE_WORK.WS_INF.Value = AREA_DE_WORK.WS_INF - 1;

            /*" -2930- IF V0ENDE-CEP GREATER WS-INF AND V0ENDE-CEP LESS WS-SUP */

            if (V0ENDE_CEP > AREA_DE_WORK.WS_INF && V0ENDE_CEP < AREA_DE_WORK.WS_SUP)
            {

                /*" -2931- MOVE TAB-FX-CEP-G (WIND) TO SVA-CEP-G */
                _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WIND].TAB_FX_CEP_G, REG_SVG0267B.SVA_CEP_G);

                /*" -2932- MOVE TAB-FAIXAS (WIND) TO SVA-NOME-CORREIO */
                _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WIND].TAB_FAIXAS, REG_SVG0267B.SVA_NOME_CORREIO);

                /*" -2933- ELSE */
            }
            else
            {


                /*" -2934- ADD 1 TO WIND */
                AREA_DE_WORK.WIND.Value = AREA_DE_WORK.WIND + 1;

                /*" -2934- GO TO R1600-10-LOOP. */
                new Task(() => R1600_10_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1800-00-IMPRIME-SECTION */
        private void R1800_00_IMPRIME_SECTION()
        {
            /*" -2947- MOVE 'R1800-00-IMPRIME  ' TO PARAGRAFO. */
            _.Move("R1800-00-IMPRIME  ", PARAGRAFO);

            /*" -2949- PERFORM R8000-00-OPEN-ARQUIVOS. */

            R8000_00_OPEN_ARQUIVOS_SECTION();

            /*" -2950- MOVE 'CO03.DBM' TO WS-JDE-GER. */
            _.Move("CO03.DBM", AREA_DE_WORK.WS_JDE_GER);

            /*" -2952- MOVE FUNCTION LOWER-CASE(WS-JDE-GER) TO LF02-FORM. */
            _.Move(AREA_DE_WORK.WS_JDE_GER.ToString().ToLower(), AREA_DE_WORK.LF02_LINHA02.LF02_FORM);

            /*" -2953- MOVE 'CO05.JDT' TO WS-JDE-GER. */
            _.Move("CO05.JDT", AREA_DE_WORK.WS_JDE_GER);

            /*" -2955- MOVE FUNCTION LOWER-CASE(WS-JDE-GER) TO LR02-FORM. */
            _.Move(AREA_DE_WORK.WS_JDE_GER.ToString().ToLower(), AREA_DE_WORK.LR02_LINHA02.LR02_FORM);

            /*" -2957- PERFORM R1950-00-LE-SORT. */

            R1950_00_LE_SORT_SECTION();

            /*" -2958- IF WFIM-SORT NOT EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_SORT != "S")
            {

                /*" -2959- WRITE RVG0267B-RECORD FROM LC01-LINHA01 */
                _.Move(AREA_DE_WORK.LC01_LINHA01.GetMoveValues(), RVG0267B_RECORD);

                RVG0267B.Write(RVG0267B_RECORD.GetMoveValues().ToString());

                /*" -2960- WRITE RVG0267B-RECORD FROM LC02-LINHA02 */
                _.Move(AREA_DE_WORK.LC02_LINHA02.GetMoveValues(), RVG0267B_RECORD);

                RVG0267B.Write(RVG0267B_RECORD.GetMoveValues().ToString());

                /*" -2961- WRITE RVG0267B-RECORD FROM LC03-LINHA03 */
                _.Move(AREA_DE_WORK.LC03_LINHA03.GetMoveValues(), RVG0267B_RECORD);

                RVG0267B.Write(RVG0267B_RECORD.GetMoveValues().ToString());

                /*" -2962- WRITE RVG0267B-RECORD FROM LC04-LINHA04 */
                _.Move(AREA_DE_WORK.LC04_LINHA04.GetMoveValues(), RVG0267B_RECORD);

                RVG0267B.Write(RVG0267B_RECORD.GetMoveValues().ToString());

                /*" -2963- WRITE RVG0267B-RECORD FROM LC05-LINHA05 */
                _.Move(AREA_DE_WORK.LC05_LINHA05.GetMoveValues(), RVG0267B_RECORD);

                RVG0267B.Write(RVG0267B_RECORD.GetMoveValues().ToString());

                /*" -2964- WRITE RVG0267B-RECORD FROM LC06-LINHA06 */
                _.Move(AREA_DE_WORK.LC06_LINHA06.GetMoveValues(), RVG0267B_RECORD);

                RVG0267B.Write(RVG0267B_RECORD.GetMoveValues().ToString());

                /*" -2965- WRITE RVG0267B-RECORD FROM LC07-LINHA07 */
                _.Move(AREA_DE_WORK.LC07_LINHA07.GetMoveValues(), RVG0267B_RECORD);

                RVG0267B.Write(RVG0267B_RECORD.GetMoveValues().ToString());

                /*" -2966- WRITE FVG0267B-RECORD FROM LC01-LINHA01 */
                _.Move(AREA_DE_WORK.LC01_LINHA01.GetMoveValues(), FVG0267B_RECORD);

                FVG0267B.Write(FVG0267B_RECORD.GetMoveValues().ToString());

                /*" -2967- WRITE FVG0267B-RECORD FROM LC02-LINHA02 */
                _.Move(AREA_DE_WORK.LC02_LINHA02.GetMoveValues(), FVG0267B_RECORD);

                FVG0267B.Write(FVG0267B_RECORD.GetMoveValues().ToString());

                /*" -2968- WRITE FVG0267B-RECORD FROM LC03-LINHA03 */
                _.Move(AREA_DE_WORK.LC03_LINHA03.GetMoveValues(), FVG0267B_RECORD);

                FVG0267B.Write(FVG0267B_RECORD.GetMoveValues().ToString());

                /*" -2969- WRITE FVG0267B-RECORD FROM LC04-LINHA04-01 */
                _.Move(AREA_DE_WORK.LC04_LINHA04_01.GetMoveValues(), FVG0267B_RECORD);

                FVG0267B.Write(FVG0267B_RECORD.GetMoveValues().ToString());

                /*" -2970- WRITE FVG0267B-RECORD FROM LC05-LINHA05-01 */
                _.Move(AREA_DE_WORK.LC05_LINHA05_01.GetMoveValues(), FVG0267B_RECORD);

                FVG0267B.Write(FVG0267B_RECORD.GetMoveValues().ToString());

                /*" -2971- WRITE FVG0267B-RECORD FROM LC06-LINHA06-01 */
                _.Move(AREA_DE_WORK.LC06_LINHA06_01.GetMoveValues(), FVG0267B_RECORD);

                FVG0267B.Write(FVG0267B_RECORD.GetMoveValues().ToString());

                /*" -2972- WRITE FVG0267B-RECORD FROM LC07-LINHA07 */
                _.Move(AREA_DE_WORK.LC07_LINHA07.GetMoveValues(), FVG0267B_RECORD);

                FVG0267B.Write(FVG0267B_RECORD.GetMoveValues().ToString());

                /*" -2974- WRITE FVG0267B-RECORD FROM LC08-LINHA08. */
                _.Move(AREA_DE_WORK.LC08_LINHA08.GetMoveValues(), FVG0267B_RECORD);

                FVG0267B.Write(FVG0267B_RECORD.GetMoveValues().ToString());
            }


            /*" -2977- PERFORM R2000-00-PROCESSA-OUTPUT UNTIL WFIM-SORT EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_SORT == "S"))
            {

                R2000_00_PROCESSA_OUTPUT_SECTION();
            }

            /*" -2978- WRITE RVG0267B-RECORD FROM LC12-LINHA12. */
            _.Move(AREA_DE_WORK.LC12_LINHA12.GetMoveValues(), RVG0267B_RECORD);

            RVG0267B.Write(RVG0267B_RECORD.GetMoveValues().ToString());

            /*" -2980- WRITE FVG0267B-RECORD FROM LC12-LINHA12. */
            _.Move(AREA_DE_WORK.LC12_LINHA12.GetMoveValues(), FVG0267B_RECORD);

            FVG0267B.Write(FVG0267B_RECORD.GetMoveValues().ToString());

            /*" -2980- PERFORM R9000-00-CLOSE-ARQUIVOS. */

            R9000_00_CLOSE_ARQUIVOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1800_FIM*/

        [StopWatch]
        /*" R1950-00-LE-SORT-SECTION */
        private void R1950_00_LE_SORT_SECTION()
        {
            /*" -2992- MOVE 'R1950-00-LE-SORT  ' TO PARAGRAFO. */
            _.Move("R1950-00-LE-SORT  ", PARAGRAFO);

            /*" -2994- RETURN SVG0267B AT END */
            try
            {
                SVG0267B.Return(REG_SVG0267B, () =>
                {

                    /*" -2995- MOVE 'S' TO WFIM-SORT */
                    _.Move("S", AREA_DE_WORK.WFIM_SORT);

                    /*" -2996- MOVE SPACES TO WS-FORMU-ATU */
                    _.Move("", AREA_DE_WORK.WS_CHAVE_ATU.WS_FORMU_ATU);

                    /*" -2997- MOVE ZEROS TO WS-PRODU-ATU */
                    _.Move(0, AREA_DE_WORK.WS_CHAVE_ATU.WS_PRODU_ATU);

                    /*" -2999- GO TO R1950-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1950_99_SAIDA*/ //GOTO
                    return;

                });
            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -3002- ADD 1 TO AC-LIDOS AC-CONTA. */
            AREA_DE_WORK.AC_LIDOS.Value = AREA_DE_WORK.AC_LIDOS + 1;
            AREA_DE_WORK.AC_CONTA.Value = AREA_DE_WORK.AC_CONTA + 1;

            /*" -3003- IF AC-CONTA GREATER 99 */

            if (AREA_DE_WORK.AC_CONTA > 99)
            {

                /*" -3004- MOVE ZEROS TO AC-CONTA */
                _.Move(0, AREA_DE_WORK.AC_CONTA);

                /*" -3005- ACCEPT WHORA-CURR FROM TIME */
                _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_CURR);

                /*" -3007- DISPLAY '*** LIDOS SORT       ' AC-LIDOS ' ' WHORA-CURR. */

                $"*** LIDOS SORT       {AREA_DE_WORK.AC_LIDOS} {AREA_DE_WORK.WHORA_CURR}"
                .Display();
            }


            /*" -3008- MOVE SVA-FORMULARIO TO WS-FORMU-ATU. */
            _.Move(REG_SVG0267B.SVA_FORMULARIO, AREA_DE_WORK.WS_CHAVE_ATU.WS_FORMU_ATU);

            /*" -3009- MOVE SVA-CODPRODU TO WS-PRODU-ATU. */
            _.Move(REG_SVG0267B.SVA_CODPRODU, AREA_DE_WORK.WS_CHAVE_ATU.WS_PRODU_ATU);

            /*" -3009- MOVE SVA-COD-EMPRESA TO PRODUTO-COD-EMPRESA. */
            _.Move(REG_SVG0267B.SVA_COD_EMPRESA, PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1950_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-PROCESSA-OUTPUT-SECTION */
        private void R2000_00_PROCESSA_OUTPUT_SECTION()
        {
            /*" -3022- MOVE 'R2000-00-PROCESSA-' TO PARAGRAFO. */
            _.Move("R2000-00-PROCESSA-", PARAGRAFO);

            /*" -3023- MOVE SVA-FORMULARIO TO WS-FORMU-ANT. */
            _.Move(REG_SVG0267B.SVA_FORMULARIO, AREA_DE_WORK.WS_CHAVE_ANT.WS_FORMU_ANT);

            /*" -3025- MOVE SVA-CODPRODU TO WS-PRODU-ANT. */
            _.Move(REG_SVG0267B.SVA_CODPRODU, AREA_DE_WORK.WS_CHAVE_ANT.WS_PRODU_ANT);

            /*" -3029- MOVE SVA-NRAPOLICE TO WS-NUM-APOLICE-ANT V0MENS-NUM-APOLICE WHOST-NRAPOLICE. */
            _.Move(REG_SVG0267B.SVA_NRAPOLICE, AREA_DE_WORK.WS_NUM_APOLICE_ANT, V0MENS_NUM_APOLICE, WHOST_NRAPOLICE);

            /*" -3033- MOVE SVA-CODSUBES TO WS-CODSUBES-ANT V0MENS-CODSUBES WHOST-CODSUBES. */
            _.Move(REG_SVG0267B.SVA_CODSUBES, AREA_DE_WORK.WS_CODSUBES_ANT, V0MENS_CODSUBES, WHOST_CODSUBES);

            /*" -3036- PERFORM R2900-00-TRATA-V0RELATORIOS. */

            R2900_00_TRATA_V0RELATORIOS_SECTION();

            /*" -3037- MOVE SVA-CODPRODU TO LR08-COD-PRODUTO. */
            _.Move(REG_SVG0267B.SVA_CODPRODU, AREA_DE_WORK.LR08_LINHA08.LR08_TIPO.LR08_COD_PRODUTO);

            /*" -3039- MOVE SVA-NOMPRODU TO LR08-NOME-PRODUTO. */
            _.Move(REG_SVG0267B.SVA_NOMPRODU, AREA_DE_WORK.LR08_LINHA08.LR08_TIPO.LR08_NOME_PRODUTO);

            /*" -3040- PERFORM R2800-00-SELECT-V0CEDENTE. */

            R2800_00_SELECT_V0CEDENTE_SECTION();

            /*" -3042- MOVE SVA-NOMPRODU TO LR03-TP-PGTO. */
            _.Move(REG_SVG0267B.SVA_NOMPRODU, AREA_DE_WORK.LR11_LINHA11.LR03_TP_PGTO);

            /*" -3047- PERFORM R2010-00-PROCESSA-PRODUTO UNTIL WS-CHAVE-ATU NOT EQUAL WS-CHAVE-ANT OR WFIM-SORT EQUAL 'S' . */

            while (!(AREA_DE_WORK.WS_CHAVE_ATU != AREA_DE_WORK.WS_CHAVE_ANT || AREA_DE_WORK.WFIM_SORT == "S"))
            {

                R2010_00_PROCESSA_PRODUTO_SECTION();
            }

            /*" -3049- MOVE 'C' TO WS-CONTR-PRODU. */
            _.Move("C", AREA_DE_WORK.WS_CONTR_PRODU);

            /*" -3051- PERFORM R3100-00-SEPARA-PRODUTO. */

            R3100_00_SEPARA_PRODUTO_SECTION();

            /*" -3053- PERFORM R3000-00-IMPRIME-LST. */

            R3000_00_IMPRIME_LST_SECTION();

            /*" -3054- WRITE FVG0267B-RECORD FROM LC12-LINHA12. */
            _.Move(AREA_DE_WORK.LC12_LINHA12.GetMoveValues(), FVG0267B_RECORD);

            FVG0267B.Write(FVG0267B_RECORD.GetMoveValues().ToString());

            /*" -3056- WRITE FVG0267B-RECORD FROM LC01-LINHA01. */
            _.Move(AREA_DE_WORK.LC01_LINHA01.GetMoveValues(), FVG0267B_RECORD);

            FVG0267B.Write(FVG0267B_RECORD.GetMoveValues().ToString());

            /*" -3058- MOVE 'R' TO WS-CONTR-PRODU. */
            _.Move("R", AREA_DE_WORK.WS_CONTR_PRODU);

            /*" -3060- PERFORM R3100-00-SEPARA-PRODUTO. */

            R3100_00_SEPARA_PRODUTO_SECTION();

            /*" -3070- MOVE ZEROS TO TABELA-TOTAIS WS-AMARRADO WS-CONTR-AMAR WS-CONTR-OBJ WS-CONTR-200 WS-SEQ AC-QTD-OBJ AC-CONTA1 AC-PAGINA WS-OCORR WIND. */
            _.Move(0, TABELA_TOTAIS, AREA_DE_WORK.WS_AMARRADO, AREA_DE_WORK.WS_CONTR_AMAR, AREA_DE_WORK.WS_CONTR_OBJ, AREA_DE_WORK.WS_CONTR_200, AREA_DE_WORK.WS_SEQ, AREA_DE_WORK.AC_QTD_OBJ, AREA_DE_WORK.AC_CONTA1, AREA_DE_WORK.AC_PAGINA, AREA_DE_WORK.WS_OCORR, AREA_DE_WORK.WIND);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2010-00-PROCESSA-PRODUTO-SECTION */
        private void R2010_00_PROCESSA_PRODUTO_SECTION()
        {
            /*" -3082- MOVE 'R2010-00-PROCESSA-' TO PARAGRAFO. */
            _.Move("R2010-00-PROCESSA-", PARAGRAFO);

            /*" -3083- MOVE SVA-CEP-G TO WS-CEP-G-ANT. */
            _.Move(REG_SVG0267B.SVA_CEP_G, AREA_DE_WORK.WS_CEP_G_ANT);

            /*" -3084- MOVE SVA-NOME-CORREIO TO WS-NOME-COR-ANT. */
            _.Move(REG_SVG0267B.SVA_NOME_CORREIO, AREA_DE_WORK.WS_NOME_COR_ANT);

            /*" -3087- MOVE ZEROS TO WS-CONTR-AMAR WS-CONTR-OBJ. */
            _.Move(0, AREA_DE_WORK.WS_CONTR_AMAR, AREA_DE_WORK.WS_CONTR_OBJ);

            /*" -3088- MOVE TAB-FX-INI (SVA-CEP-G) TO WS-NUM-CEP-AUX. */
            _.Move(TABELA_CEP.CEP[REG_SVG0267B.SVA_CEP_G].TAB_FAIXAS.TAB_FX_INI, AREA_DE_WORK.WS_NUM_CEP_AUX);

            /*" -3089- MOVE WS-CEP-AUX TO LF03-FAIXA1. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_AUX, AREA_DE_WORK.LF04_LINHA04.LF03_FAIXA1);

            /*" -3090- MOVE WS-CEP-COMPL-AUX TO LF03-FAIXA1C. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, AREA_DE_WORK.LF04_LINHA04.LF03_FAIXA1C);

            /*" -3091- MOVE TAB-FX-FIM (SVA-CEP-G) TO WS-NUM-CEP-AUX. */
            _.Move(TABELA_CEP.CEP[REG_SVG0267B.SVA_CEP_G].TAB_FAIXAS.TAB_FX_FIM, AREA_DE_WORK.WS_NUM_CEP_AUX);

            /*" -3092- MOVE WS-CEP-AUX TO LF03-FAIXA2. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_AUX, AREA_DE_WORK.LF04_LINHA04.LF03_FAIXA2);

            /*" -3094- MOVE WS-CEP-COMPL-AUX TO LF03-FAIXA2C. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, AREA_DE_WORK.LF04_LINHA04.LF03_FAIXA2C);

            /*" -3100- PERFORM R2100-00-PROCESSA-CEP UNTIL WS-CHAVE-ATU NOT EQUAL WS-CHAVE-ANT OR SVA-CEP-G NOT EQUAL WS-CEP-G-ANT OR WFIM-SORT EQUAL 'S' . */

            while (!(AREA_DE_WORK.WS_CHAVE_ATU != AREA_DE_WORK.WS_CHAVE_ANT || REG_SVG0267B.SVA_CEP_G != AREA_DE_WORK.WS_CEP_G_ANT || AREA_DE_WORK.WFIM_SORT == "S"))
            {

                R2100_00_PROCESSA_CEP_SECTION();
            }

            /*" -3101- MOVE WS-AMARRADO TO TAB1-AMARF(WS-CEP-G-ANT). */
            _.Move(AREA_DE_WORK.WS_AMARRADO, TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WS_CEP_G_ANT].TAB1_AMARF);

            /*" -3101- MOVE WS-SEQ TO TAB1-OBJF (WS-CEP-G-ANT). */
            _.Move(AREA_DE_WORK.WS_SEQ, TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WS_CEP_G_ANT].TAB1_OBJF);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2010_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-PROCESSA-CEP-SECTION */
        private void R2100_00_PROCESSA_CEP_SECTION()
        {
            /*" -3113- MOVE 'R2100-00-PROCESSA-CEP' TO PARAGRAFO. */
            _.Move("R2100-00-PROCESSA-CEP", PARAGRAFO);

            /*" -3117- MOVE ZEROS TO AC-CONTA1 AC-QTD-OBJ WS-CONTR-200. */
            _.Move(0, AREA_DE_WORK.AC_CONTA1, AREA_DE_WORK.AC_QTD_OBJ, AREA_DE_WORK.WS_CONTR_200);

            /*" -3119- PERFORM R2310-00-IDENTIFICA-MSG. */

            R2310_00_IDENTIFICA_MSG_SECTION();

            /*" -3120- WRITE RVG0267B-RECORD FROM LC08-LINHA08. */
            _.Move(AREA_DE_WORK.LC08_LINHA08.GetMoveValues(), RVG0267B_RECORD);

            RVG0267B.Write(RVG0267B_RECORD.GetMoveValues().ToString());

            /*" -3121- WRITE RVG0267B-RECORD FROM LC09-LINHA09. */
            _.Move(AREA_DE_WORK.LC09_LINHA09.GetMoveValues(), RVG0267B_RECORD);

            RVG0267B.Write(RVG0267B_RECORD.GetMoveValues().ToString());

            /*" -3123- WRITE RVG0267B-RECORD FROM LC10-LINHA10. */
            _.Move(AREA_DE_WORK.LC10_LINHA10.GetMoveValues(), RVG0267B_RECORD);

            RVG0267B.Write(RVG0267B_RECORD.GetMoveValues().ToString());

            /*" -3124- MOVE 'SIM' TO WINSERE-HEA */
            _.Move("SIM", AREA_DE_WORK.WINSERE_HEA);

            /*" -3126- PERFORM VARYING TFO-I FROM 1 BY 1 UNTIL TFO-I > TAB-FO-QTD */

            for (TFO_I.Value = 1; !(TFO_I > TAB_FO_QTD); TFO_I.Value += 1)
            {

                /*" -3127- IF TAB-FO-FORMULARIO(TFO-I) = WS-JDE-GER */

                if (TAB_FORM_OBJECT.FILLER_176[TFO_I].TAB_FO_FORMULARIO == AREA_DE_WORK.WS_JDE_GER)
                {

                    /*" -3128- MOVE 'NAO' TO WINSERE-HEA */
                    _.Move("NAO", AREA_DE_WORK.WINSERE_HEA);

                    /*" -3129- END-IF */
                }


                /*" -3131- END-PERFORM */
            }

            /*" -3132- IF WINSERE-HEA EQUAL 'SIM' */

            if (AREA_DE_WORK.WINSERE_HEA == "SIM")
            {

                /*" -3133- MOVE ZEROS TO GEOBJECT-NUM-CEP */
                _.Move(0, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NUM_CEP);

                /*" -3134- MOVE 'VG0267B' TO GEOBJECT-NOM-PROGRAMA */
                _.Move("VG0267B", GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NOM_PROGRAMA);

                /*" -3135- MOVE 'H' TO GEOBJECT-STA-REGISTRO */
                _.Move("H", GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_STA_REGISTRO);

                /*" -3136- MOVE -1 TO VIND-COD-PRODUTO */
                _.Move(-1, VIND_COD_PRODUTO);

                /*" -3140- MOVE ZEROS TO GEOBJECT-COD-PRODUTO GEOBJECT-NUM-INI-POS-VERSO GEOBJECT-VLR-DECLARADO GEOBJECT-QTD-PESO-GRAMAS */
                _.Move(0, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_PRODUTO, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NUM_INI_POS_VERSO, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_VLR_DECLARADO, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_QTD_PESO_GRAMAS);

                /*" -3142- IF WS-JDE-GER EQUAL 'VD32' OR 'VIDA26' */

                if (AREA_DE_WORK.WS_JDE_GER.In("VD32", "VIDA26"))
                {

                    /*" -3143- MOVE 'I' TO GEOBJECT-COD-IDENT-OBJETO */
                    _.Move("I", GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_IDENT_OBJETO);

                    /*" -3144- ELSE */
                }
                else
                {


                    /*" -3145- MOVE SPACES TO GEOBJECT-COD-IDENT-OBJETO */
                    _.Move("", GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_IDENT_OBJETO);

                    /*" -3146- END-IF */
                }


                /*" -3147- MOVE 4500 TO GEOBJECT-DES-OBJETO-LEN */
                _.Move(4500, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_DES_OBJETO.GEOBJECT_DES_OBJETO_LEN);

                /*" -3148- MOVE LC10-LINHA10 TO GEOBJECT-DES-OBJETO-TEXT */
                _.Move(AREA_DE_WORK.LC10_LINHA10, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_DES_OBJETO.GEOBJECT_DES_OBJETO_TEXT);

                /*" -3149- MOVE WS-JDE-GER TO GEOBJECT-COD-FORMULARIO */
                _.Move(AREA_DE_WORK.WS_JDE_GER, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_FORMULARIO);

                /*" -3150- ADD 1 TO TAB-FO-QTD */
                TAB_FO_QTD.Value = TAB_FO_QTD + 1;

                /*" -3152- MOVE WS-JDE-GER TO TAB-FO-FORMULARIO(TAB-FO-QTD) */
                _.Move(AREA_DE_WORK.WS_JDE_GER, TAB_FORM_OBJECT.FILLER_176[TAB_FO_QTD].TAB_FO_FORMULARIO);

                /*" -3153- PERFORM R9100-00-INSERT-GEOBJECT */

                R9100_00_INSERT_GEOBJECT_SECTION();

                /*" -3155- END-IF */
            }


            /*" -3162- PERFORM R2200-00-PROCESSA-FAC UNTIL WS-CHAVE-ATU NOT EQUAL WS-CHAVE-ANT OR SVA-CEP-G NOT EQUAL WS-CEP-G-ANT OR WFIM-SORT EQUAL 'S' OR AC-CONTA1 > 199. */

            while (!(AREA_DE_WORK.WS_CHAVE_ATU != AREA_DE_WORK.WS_CHAVE_ANT || REG_SVG0267B.SVA_CEP_G != AREA_DE_WORK.WS_CEP_G_ANT || AREA_DE_WORK.WFIM_SORT == "S" || AREA_DE_WORK.AC_CONTA1 > 199))
            {

                R2200_00_PROCESSA_FAC_SECTION();
            }

            /*" -3165- ADD 1 TO WS-AMARRADO TAB1-QTD-AMAR (WS-CEP-G-ANT). */
            AREA_DE_WORK.WS_AMARRADO.Value = AREA_DE_WORK.WS_AMARRADO + 1;
            TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WS_CEP_G_ANT].TAB1_QTD_AMAR.Value = TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WS_CEP_G_ANT].TAB1_QTD_AMAR + 1;

            /*" -3166- IF WS-CONTR-AMAR EQUAL ZEROS */

            if (AREA_DE_WORK.WS_CONTR_AMAR == 00)
            {

                /*" -3167- MOVE 1 TO WS-CONTR-AMAR */
                _.Move(1, AREA_DE_WORK.WS_CONTR_AMAR);

                /*" -3170- MOVE WS-AMARRADO TO TAB1-AMARI (WS-CEP-G-ANT). */
                _.Move(AREA_DE_WORK.WS_AMARRADO, TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WS_CEP_G_ANT].TAB1_AMARI);
            }


            /*" -3171- MOVE WS-AMARRADO TO LF05-AMARRADO. */
            _.Move(AREA_DE_WORK.WS_AMARRADO, AREA_DE_WORK.LF04_LINHA04.LF05_AMARRADO);

            /*" -3172- MOVE AC-QTD-OBJ TO LF04-QTD-OBJ. */
            _.Move(AREA_DE_WORK.AC_QTD_OBJ, AREA_DE_WORK.LF04_LINHA04.LF04_QTD_OBJ);

            /*" -3173- MOVE WS-SEQ-INICIAL TO LF05-SEQ-INICIAL. */
            _.Move(AREA_DE_WORK.WS_SEQ_INICIAL, AREA_DE_WORK.LF04_LINHA04.LF05_SEQ_INICIAL);

            /*" -3177- MOVE WS-SEQ TO LF05-SEQ-FINAL. */
            _.Move(AREA_DE_WORK.WS_SEQ, AREA_DE_WORK.LF04_LINHA04.LF05_SEQ_FINAL);

            /*" -3178- WRITE RVG0267B-RECORD FROM LC12-LINHA12. */
            _.Move(AREA_DE_WORK.LC12_LINHA12.GetMoveValues(), RVG0267B_RECORD);

            RVG0267B.Write(RVG0267B_RECORD.GetMoveValues().ToString());

            /*" -3179- WRITE RVG0267B-RECORD FROM LC01-LINHA01. */
            _.Move(AREA_DE_WORK.LC01_LINHA01.GetMoveValues(), RVG0267B_RECORD);

            RVG0267B.Write(RVG0267B_RECORD.GetMoveValues().ToString());

            /*" -3180- WRITE RVG0267B-RECORD FROM LF01-LINHA01. */
            _.Move(AREA_DE_WORK.LF01_LINHA01.GetMoveValues(), RVG0267B_RECORD);

            RVG0267B.Write(RVG0267B_RECORD.GetMoveValues().ToString());

            /*" -3182- WRITE RVG0267B-RECORD FROM LC08-LINHA08. */
            _.Move(AREA_DE_WORK.LC08_LINHA08.GetMoveValues(), RVG0267B_RECORD);

            RVG0267B.Write(RVG0267B_RECORD.GetMoveValues().ToString());

            /*" -3184- MOVE SPACES TO LF02-NOME-FAIXA. */
            _.Move("", AREA_DE_WORK.LF04_LINHA04.LF02_NOME_FAIXA);

            /*" -3185- IF AC-CONTA1 GREATER 199 */

            if (AREA_DE_WORK.AC_CONTA1 > 199)
            {

                /*" -3187- MOVE TAB-FX-NOME (WS-CEP-G-ANT) TO LF02-NOME-FAIXA */
                _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WS_CEP_G_ANT].TAB_FAIXAS.TAB_FX_NOME, AREA_DE_WORK.LF04_LINHA04.LF02_NOME_FAIXA);

                /*" -3188- ELSE */
            }
            else
            {


                /*" -3191- MOVE TAB-FX-CENTR(WS-CEP-G-ANT) TO LF02-NOME-FAIXA. */
                _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WS_CEP_G_ANT].TAB_FAIXAS.TAB_FX_CENTR, AREA_DE_WORK.LF04_LINHA04.LF02_NOME_FAIXA);
            }


            /*" -3192- WRITE RVG0267B-RECORD FROM LF02-LINHA02. */
            _.Move(AREA_DE_WORK.LF02_LINHA02.GetMoveValues(), RVG0267B_RECORD);

            RVG0267B.Write(RVG0267B_RECORD.GetMoveValues().ToString());

            /*" -3193- WRITE RVG0267B-RECORD FROM LF03-LINHA03. */
            _.Move(AREA_DE_WORK.LF03_LINHA03.GetMoveValues(), RVG0267B_RECORD);

            RVG0267B.Write(RVG0267B_RECORD.GetMoveValues().ToString());

            /*" -3195- WRITE RVG0267B-RECORD FROM LF04-LINHA04. */
            _.Move(AREA_DE_WORK.LF04_LINHA04.GetMoveValues(), RVG0267B_RECORD);

            RVG0267B.Write(RVG0267B_RECORD.GetMoveValues().ToString());

            /*" -3196- WRITE RVG0267B-RECORD FROM LC12-LINHA12 */
            _.Move(AREA_DE_WORK.LC12_LINHA12.GetMoveValues(), RVG0267B_RECORD);

            RVG0267B.Write(RVG0267B_RECORD.GetMoveValues().ToString());

            /*" -3198- WRITE RVG0267B-RECORD FROM LC01-LINHA01. */
            _.Move(AREA_DE_WORK.LC01_LINHA01.GetMoveValues(), RVG0267B_RECORD);

            RVG0267B.Write(RVG0267B_RECORD.GetMoveValues().ToString());

            /*" -3199- MOVE ZEROS TO AC-QTD-OBJ. */
            _.Move(0, AREA_DE_WORK.AC_QTD_OBJ);

            /*" -3199- MOVE 1 TO WS-CONTROLE. */
            _.Move(1, AREA_DE_WORK.WS_CONTROLE);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-PROCESSA-FAC-SECTION */
        private void R2200_00_PROCESSA_FAC_SECTION()
        {
            /*" -3211- MOVE 'R2200-00-PROCESSA-FAC' TO PARAGRAFO. */
            _.Move("R2200-00-PROCESSA-FAC", PARAGRAFO);

            /*" -3213- MOVE SVA-NRAPOLICE TO WHOST-NRAPOLICE. */
            _.Move(REG_SVG0267B.SVA_NRAPOLICE, WHOST_NRAPOLICE);

            /*" -3215- MOVE SVA-CODSUBES TO WHOST-CODSUBES. */
            _.Move(REG_SVG0267B.SVA_CODSUBES, WHOST_CODSUBES);

            /*" -3217- PERFORM R2800-00-SELECT-V0CEDENTE. */

            R2800_00_SELECT_V0CEDENTE_SECTION();

            /*" -3219- MOVE SVA-NRCERTIF TO WS-CERTIF WHOST-NRCERTIF. */
            _.Move(REG_SVG0267B.SVA_NRCERTIF, AREA_DE_WORK.WS_CERTIF, WHOST_NRCERTIF);

            /*" -3220- MOVE SVA-DTVENCTO TO V0HIST-DTVENCTO */
            _.Move(REG_SVG0267B.SVA_DTVENCTO, V0HIST_DTVENCTO);

            /*" -3221- MOVE SVA-PERIPGTO TO V0OPCP-PERIPGTO. */
            _.Move(REG_SVG0267B.SVA_PERIPGTO, V0OPCP_PERIPGTO);

            /*" -3222- MOVE SVA-NRTIT TO WHOST-NRTIT. */
            _.Move(REG_SVG0267B.SVA_NRTIT, WHOST_NRTIT);

            /*" -3223- MOVE SVA-NRPARCEL TO WHOST-NRPARCEL. */
            _.Move(REG_SVG0267B.SVA_NRPARCEL, WHOST_NRPARCEL);

            /*" -3224- MOVE SVA-OCORHIST TO WHOST-OCORHIST. */
            _.Move(REG_SVG0267B.SVA_OCORHIST, WHOST_OCORHIST);

            /*" -3226- MOVE SVA-NRTITCOMP TO WHOST-NRTITCOMP. */
            _.Move(REG_SVG0267B.SVA_NRTITCOMP, WHOST_NRTITCOMP);

            /*" -3230- MOVE SVA-NOME-RAZAO TO LC02-NOME-RAZAO LC14-NOME-RAZAO LE02-NOME-RAZAO. */
            _.Move(REG_SVG0267B.SVA_NOME_RAZAO, AREA_DE_WORK.LC11_LINHA11.LC02_NOME_RAZAO, AREA_DE_WORK.LC11_LINHA11.LC14_NOME_RAZAO, AREA_DE_WORK.LC11_LINHA11.LE02_NOME_RAZAO);

            /*" -3231- MOVE SVA-NRCNPJ TO WS-CNPJ. */
            _.Move(REG_SVG0267B.SVA_NRCNPJ, AREA_DE_WORK.WS_CNPJ);

            /*" -3233- MOVE WS-NRCNPJ1 TO LC02-NRCNPJ1 LC14-NRCNPJ1 */
            _.Move(AREA_DE_WORK.WS_CNPJ_R.WS_NRCNPJ1, AREA_DE_WORK.LC11_LINHA11.LC02_NRCNPJ1, AREA_DE_WORK.LC11_LINHA11.LC14_NRCNPJ1);

            /*" -3235- MOVE WS-NRCNPJ2 TO LC02-NRCNPJ2 LC14-NRCNPJ2 */
            _.Move(AREA_DE_WORK.WS_CNPJ_R.WS_NRCNPJ2, AREA_DE_WORK.LC11_LINHA11.LC02_NRCNPJ2, AREA_DE_WORK.LC11_LINHA11.LC14_NRCNPJ2);

            /*" -3238- MOVE WS-DVCNPJ TO LC02-DVCNPJ LC14-DVCNPJ. */
            _.Move(AREA_DE_WORK.WS_CNPJ_R.WS_DVCNPJ, AREA_DE_WORK.LC11_LINHA11.LC02_DVCNPJ, AREA_DE_WORK.LC11_LINHA11.LC14_DVCNPJ);

            /*" -3240- MOVE SVA-CODPRODU TO LC11-PRODUTO. */
            _.Move(REG_SVG0267B.SVA_CODPRODU, AREA_DE_WORK.LC11_LINHA11.LC11_PRODUTO);

            /*" -3242- MOVE SVA-AGECOBR TO LC11-AGENCIA. */
            _.Move(REG_SVG0267B.SVA_AGECOBR, AREA_DE_WORK.LC11_LINHA11.LC11_AGENCIA);

            /*" -3245- MOVE SVA-NRAPOLICE TO WS-NUM-APOLICE V0MENS-NUM-APOLICE. */
            _.Move(REG_SVG0267B.SVA_NRAPOLICE, AREA_DE_WORK.WS_CHAVE_R.WS_NUM_APOLICE);
            _.Move(REG_SVG0267B.SVA_NRAPOLICE, V0MENS_NUM_APOLICE);


            /*" -3250- MOVE SVA-CODSUBES TO WS-CODSUBES LC11-CODSUBES LC11-COD-SUBGRUPO V0MENS-CODSUBES. */
            _.Move(REG_SVG0267B.SVA_CODSUBES, AREA_DE_WORK.WS_CHAVE_R.WS_CODSUBES);
            _.Move(REG_SVG0267B.SVA_CODSUBES, AREA_DE_WORK.LC11_LINHA11.LC11_CODSUBES);
            _.Move(REG_SVG0267B.SVA_CODSUBES, AREA_DE_WORK.LC11_LINHA11.LC11_COD_SUBGRUPO);
            _.Move(REG_SVG0267B.SVA_CODSUBES, V0MENS_CODSUBES);


            /*" -3253- MOVE SVA-CODOPER TO WS-CODOPER WHOST-CODOPER. */
            _.Move(REG_SVG0267B.SVA_CODOPER, AREA_DE_WORK.WS_CHAVE_R.WS_CODOPER);
            _.Move(REG_SVG0267B.SVA_CODOPER, WHOST_CODOPER);


            /*" -3254- MOVE 1 TO INF. */
            _.Move(1, AREA_DE_WORK.INF);

            /*" -3256- MOVE WINDM TO SUP. */
            _.Move(AREA_DE_WORK.WINDM, AREA_DE_WORK.SUP);

            /*" -3261- PERFORM R2310-00-IDENTIFICA-MSG. */

            R2310_00_IDENTIFICA_MSG_SECTION();

            /*" -3263- IF SVA-CODOPER NOT = 111 AND 112 AND 115 */

            if (!REG_SVG0267B.SVA_CODOPER.In("111", "112", "115"))
            {

                /*" -3264- PERFORM R2320-00-TRATA-MENSAGEM */

                R2320_00_TRATA_MENSAGEM_SECTION();

                /*" -3265- ELSE */
            }
            else
            {


                /*" -3267- IF SVA-CODOPER = 112 AND SVA-TEM-CDG = 'S' */

                if (REG_SVG0267B.SVA_CODOPER == 112 && REG_SVG0267B.SVA_TEM_CDG == "S")
                {

                    /*" -3269- PERFORM R2320-00-TRATA-MENSAGEM. */

                    R2320_00_TRATA_MENSAGEM_SECTION();
                }

            }


            /*" -3270- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3271- GO TO R2200-40-NEXT */

                R2200_40_NEXT(); //GOTO
                return;

                /*" -3273- END-IF. */
            }


            /*" -3274- MOVE SVA-NUM-CEP TO LE05-CEP. */
            _.Move(REG_SVG0267B.SVA_NUM_CEP, AREA_DE_WORK.LC11_LINHA11.LE05_CEP);

            /*" -3275- MOVE SVA-NUM-CEP TO LC11-CEP1-SUB. */
            _.Move(REG_SVG0267B.SVA_NUM_CEP, AREA_DE_WORK.LC11_LINHA11.LC11_CEP1_SUB);

            /*" -3276- MOVE SVA-CEP-COMPL TO LE05-CEP-COMPL. */
            _.Move(REG_SVG0267B.SVA_NUM_CEP.SVA_CEP_COMPL, AREA_DE_WORK.LC11_LINHA11.LE05_CEP_COMPL);

            /*" -3277- MOVE SVA-CEP-COMPL TO LC11-CEP2-SUB. */
            _.Move(REG_SVG0267B.SVA_NUM_CEP.SVA_CEP_COMPL, AREA_DE_WORK.LC11_LINHA11.LC11_CEP2_SUB);

            /*" -3279- MOVE SVA-CIDADE TO LE04-CIDADE LC11-CIDADE-SUB. */
            _.Move(REG_SVG0267B.SVA_CIDADE, AREA_DE_WORK.LC11_LINHA11.LE04_CIDADE, AREA_DE_WORK.LC11_LINHA11.LC11_CIDADE_SUB);

            /*" -3280- MOVE SVA-BAIRRO TO LE04-BAIRRO. */
            _.Move(REG_SVG0267B.SVA_BAIRRO, AREA_DE_WORK.LC11_LINHA11.LE04_BAIRRO);

            /*" -3282- MOVE SVA-UF TO LE04-UF LC11-UF-SUB. */
            _.Move(REG_SVG0267B.SVA_UF, AREA_DE_WORK.LC11_LINHA11.LE04_UF, AREA_DE_WORK.LC11_LINHA11.LC11_UF_SUB);

            /*" -3284- MOVE SVA-ENDERECO TO LE03-ENDERECO LC11-ENDERECO-SUB. */
            _.Move(REG_SVG0267B.SVA_ENDERECO, AREA_DE_WORK.LC11_LINHA11.LE03_ENDERECO, AREA_DE_WORK.LC11_LINHA11.LC11_ENDERECO_SUB);

            /*" -3285- MOVE SVA-DTVENCTO TO WS-DATA-SQL. */
            _.Move(REG_SVG0267B.SVA_DTVENCTO, AREA_DE_WORK.WS_DATA_SQL);

            /*" -3286- MOVE WS-DIA-SQL TO WS-DIA. */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_DIA_SQL, AREA_DE_WORK.WS_DATA.WS_DIA);

            /*" -3287- MOVE WS-MES-SQL TO WS-MES. */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_MES_SQL, AREA_DE_WORK.WS_DATA.WS_MES);

            /*" -3288- MOVE WS-ANO-SQL TO WS-ANO. */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_ANO_SQL, AREA_DE_WORK.WS_DATA.WS_ANO);

            /*" -3291- MOVE WS-DATA TO LC03-DTVENCTO LC07-DTVENCTO LC11-DTVENCTO. */
            _.Move(AREA_DE_WORK.WS_DATA, AREA_DE_WORK.LC11_LINHA11.LC03_DTVENCTO, AREA_DE_WORK.LC11_LINHA11.LC07_DTVENCTO, AREA_DE_WORK.LC11_LINHA11.LC11_DTVENCTO);

            /*" -3292- MOVE WS-NRCERTIF TO LC13-NRCERTIF. */
            _.Move(AREA_DE_WORK.WS_CERTIF_R.WS_NRCERTIF, AREA_DE_WORK.LC11_LINHA11.LC13_NRCERTIF);

            /*" -3293- MOVE WS-DVCERTIF TO LC13-DVCERTIF. */
            _.Move(AREA_DE_WORK.WS_CERTIF_R.WS_DVCERTIF, AREA_DE_WORK.LC11_LINHA11.LC13_DVCERTIF);

            /*" -3295- MOVE SVA-NRPARCEL TO LC03-NRPARCEL LC13-NRPARCEL. */
            _.Move(REG_SVG0267B.SVA_NRPARCEL, AREA_DE_WORK.LC11_LINHA11.LC03_NRPARCEL, AREA_DE_WORK.LC11_LINHA11.LC13_NRPARCEL);

            /*" -3297- MOVE V0CEDE-NOMECED TO LC08-NOMECED. */
            _.Move(V0CEDE_NOMECED, AREA_DE_WORK.LC11_LINHA11.LC08_NOMECED);

            /*" -3299- PERFORM R2250-00-GERA-COD-BARRA */

            R2250_00_GERA_COD_BARRA_SECTION();

            /*" -3300- MOVE SVA-NN-SIGCB TO WK-NOSSO-NUMERO */
            _.Move(REG_SVG0267B.SVA_NN_SIGCB, AREA_DE_WORK.WK_NOSSO_NUMERO);

            /*" -3301- MOVE WK-NUMERO TO LC09-NRTIT1. */
            _.Move(AREA_DE_WORK.WK_NUMERO_R.WK_NUMERO, AREA_DE_WORK.LC11_LINHA11.LC09_NRTIT1);

            /*" -3302- MOVE WK-DIGITO TO LC09-DVTITULO1. */
            _.Move(AREA_DE_WORK.WK_NUMERO_R.WK_DIGITO, AREA_DE_WORK.LC11_LINHA11.LC09_DVTITULO1);

            /*" -3305- MOVE SVA-COD-CEDENTE TO LC03-COD-CEDENTE LC08-COD-CEDENTE */
            _.Move(REG_SVG0267B.SVA_COD_CEDENTE, AREA_DE_WORK.LC11_LINHA11.LC03_COD_CEDENTE, AREA_DE_WORK.LC11_LINHA11.LC08_COD_CEDENTE);

            /*" -3306- MOVE SVA-NRTIT TO WS-TITULO. */
            _.Move(REG_SVG0267B.SVA_NRTIT, AREA_DE_WORK.WS_TITULO);

            /*" -3308- MOVE WS-NRTIT TO LC03-NRTIT LC09-NRTIT */
            _.Move(AREA_DE_WORK.WS_TITULO_R.WS_NRTIT, AREA_DE_WORK.LC11_LINHA11.LC03_NRTIT, AREA_DE_WORK.LC11_LINHA11.LC09_NRTIT);

            /*" -3310- MOVE WS-DVTITULO TO LC03-DVTITULO LC09-DVTITULO */
            _.Move(AREA_DE_WORK.WS_TITULO_R.WS_DVTITULO, AREA_DE_WORK.LC11_LINHA11.LC03_DVTITULO, AREA_DE_WORK.LC11_LINHA11.LC09_DVTITULO);

            /*" -3311- MOVE LK-GE355-OUT-DESENHO-BARRA TO LC16-CDBARRA */
            _.Move(LBGE0355.REGISTRO_LINKAGE_GE0355S.LK_GE355_OUT_DESENHO_BARRA, AREA_DE_WORK.LC11_LINHA11.LC16_CDBARRA);

            /*" -3312- MOVE LK-GE355-OUT-LINHA-DIGITAVEL TO LC06-LIN-DIGITAVEL */
            _.Move(LBGE0355.REGISTRO_LINKAGE_GE0355S.LK_GE355_OUT_LINHA_DIGITAVEL, AREA_DE_WORK.LC11_LINHA11.LC06_LIN_DIGITAVEL);

            /*" -3314- MOVE SVA-VLR-IOF TO LC11-IOF */
            _.Move(REG_SVG0267B.SVA_VLR_IOF, AREA_DE_WORK.LC11_LINHA11.LC11_IOF);

            /*" -3318- MOVE SVA-VLPRMTOT TO LC03-VLPRMTOT LC10-VLPRMTOT LC11-VLPRMTOT. */
            _.Move(REG_SVG0267B.SVA_VLPRMTOT, AREA_DE_WORK.LC11_LINHA11.LC03_VLPRMTOT, AREA_DE_WORK.LC11_LINHA11.LC10_VLPRMTOT, AREA_DE_WORK.LC11_LINHA11.LC11_VLPRMTOT);

            /*" -3319- IF (SVA-VLPRMTOT NOT EQUAL SVA-VLR-PREMIO) */

            if ((REG_SVG0267B.SVA_VLPRMTOT != REG_SVG0267B.SVA_VLR_PREMIO))
            {

                /*" -3321- DISPLAY 'ATENCAO - VALOR DIVERGENTE SIGCB ' SVA-NRCERTIF ' - ' SVA-VLPRMTOT ' - ' SVA-VLR-PREMIO */

                $"ATENCAO - VALOR DIVERGENTE SIGCB {REG_SVG0267B.SVA_NRCERTIF} - {REG_SVG0267B.SVA_VLPRMTOT} - {REG_SVG0267B.SVA_VLR_PREMIO}"
                .Display();

                /*" -3324- END-IF */
            }


            /*" -3329- ADD 1 TO WS-SEQ TAB1-QTD-OBJ (SVA-CEP-G) AC-QTD-OBJ AC-CONTA1. */
            AREA_DE_WORK.WS_SEQ.Value = AREA_DE_WORK.WS_SEQ + 1;
            TABELA_TOTAIS.TAB_TOTAIS[REG_SVG0267B.SVA_CEP_G].TAB1_QTD_OBJ.Value = TABELA_TOTAIS.TAB_TOTAIS[REG_SVG0267B.SVA_CEP_G].TAB1_QTD_OBJ + 1;
            AREA_DE_WORK.AC_QTD_OBJ.Value = AREA_DE_WORK.AC_QTD_OBJ + 1;
            AREA_DE_WORK.AC_CONTA1.Value = AREA_DE_WORK.AC_CONTA1 + 1;

            /*" -3331- MOVE 'XXX.XXX' TO LE01-SEQUENCIA. */
            _.Move("XXX.XXX", AREA_DE_WORK.LC11_LINHA11.LE01_SEQUENCIA);

            /*" -3332- IF WS-CONTR-OBJ EQUAL ZEROS */

            if (AREA_DE_WORK.WS_CONTR_OBJ == 00)
            {

                /*" -3333- MOVE 1 TO WS-CONTR-OBJ */
                _.Move(1, AREA_DE_WORK.WS_CONTR_OBJ);

                /*" -3336- MOVE WS-SEQ TO TAB1-OBJI (SVA-CEP-G). */
                _.Move(AREA_DE_WORK.WS_SEQ, TABELA_TOTAIS.TAB_TOTAIS[REG_SVG0267B.SVA_CEP_G].TAB1_OBJI);
            }


            /*" -3337- IF WS-CONTR-200 EQUAL ZEROS */

            if (AREA_DE_WORK.WS_CONTR_200 == 00)
            {

                /*" -3338- MOVE 1 TO WS-CONTR-200 */
                _.Move(1, AREA_DE_WORK.WS_CONTR_200);

                /*" -3340- MOVE WS-SEQ TO WS-SEQ-INICIAL. */
                _.Move(AREA_DE_WORK.WS_SEQ, AREA_DE_WORK.WS_SEQ_INICIAL);
            }


            /*" -3342- PERFORM R2650-00-BUSCA-FONTE. */

            R2650_00_BUSCA_FONTE_SECTION();

            /*" -3344- PERFORM R2651-00-BUSCA-ESTIPULANTE. */

            R2651_00_BUSCA_ESTIPULANTE_SECTION();

            /*" -3348- PERFORM R2652-00-BUSCA-PARCELA. */

            R2652_00_BUSCA_PARCELA_SECTION();

            /*" -3349- MOVE SVA-NRAPOLICE TO LC11-APOLICE. */
            _.Move(REG_SVG0267B.SVA_NRAPOLICE, AREA_DE_WORK.LC11_LINHA11.LC11_APOLICE);

            /*" -3350- MOVE SVA-NRAPOLICE TO LC11-NUM-APOLICE. */
            _.Move(REG_SVG0267B.SVA_NRAPOLICE, AREA_DE_WORK.LC11_LINHA11.LC11_NUM_APOLICE);

            /*" -3351- MOVE V0CLIE-NOME-RAZAO-E TO LC11-NOME-RAZAO-EST. */
            _.Move(V0CLIE_NOME_RAZAO_E, AREA_DE_WORK.LC11_LINHA11.LC11_NOME_RAZAO_EST);

            /*" -3352- MOVE V0CLIE-CNPJ-E TO WS-CNPJ. */
            _.Move(V0CLIE_CNPJ_E, AREA_DE_WORK.WS_CNPJ);

            /*" -3353- MOVE WS-NRCNPJ1 TO LC11-CNPJ1-EST. */
            _.Move(AREA_DE_WORK.WS_CNPJ_R.WS_NRCNPJ1, AREA_DE_WORK.LC11_LINHA11.LC11_CNPJ1_EST);

            /*" -3354- MOVE WS-NRCNPJ2 TO LC11-CNPJ2-EST. */
            _.Move(AREA_DE_WORK.WS_CNPJ_R.WS_NRCNPJ2, AREA_DE_WORK.LC11_LINHA11.LC11_CNPJ2_EST);

            /*" -3355- MOVE WS-DVCNPJ TO LC11-CNPJ3-EST. */
            _.Move(AREA_DE_WORK.WS_CNPJ_R.WS_DVCNPJ, AREA_DE_WORK.LC11_LINHA11.LC11_CNPJ3_EST);

            /*" -3356- MOVE V0ENDE-ENDERECO-E TO LC11-ENDERECO-EST. */
            _.Move(V0ENDE_ENDERECO_E, AREA_DE_WORK.LC11_LINHA11.LC11_ENDERECO_EST);

            /*" -3357- MOVE V0ENDE-CIDADE-E TO LC11-CIDADE-EST. */
            _.Move(V0ENDE_CIDADE_E, AREA_DE_WORK.LC11_LINHA11.LC11_CIDADE_EST);

            /*" -3358- MOVE V0ENDE-UF-E TO LC11-UF-EST. */
            _.Move(V0ENDE_UF_E, AREA_DE_WORK.LC11_LINHA11.LC11_UF_EST);

            /*" -3359- MOVE V0ENDE-CEP-E TO WS-NUM-CEP-AUX. */
            _.Move(V0ENDE_CEP_E, AREA_DE_WORK.WS_NUM_CEP_AUX);

            /*" -3360- MOVE WS-CEP-AUX TO LC11-CEP1-EST. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_AUX, AREA_DE_WORK.LC11_LINHA11.LC11_CEP1_EST);

            /*" -3361- MOVE WS-CEP-COMPL-AUX TO LC11-CEP2-EST. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, AREA_DE_WORK.LC11_LINHA11.LC11_CEP2_EST);

            /*" -3362- MOVE V0PARC-DTVENCTO-ORIG TO WS-DTVENCTO-SQL. */
            _.Move(V0PARC_DTVENCTO_ORIG, AREA_DE_WORK.WS_DTVENCTO_SQL);

            /*" -3363- MOVE WS-ANO-VCT TO LC11-FATURA-SEC. */
            _.Move(AREA_DE_WORK.WS_DTVENCTO_SQL.WS_ANO_VCT, AREA_DE_WORK.LC11_LINHA11.LC11_FATURA_SEC);

            /*" -3364- MOVE WS-MES-VCT TO LC11-FATURA-MES. */
            _.Move(AREA_DE_WORK.WS_DTVENCTO_SQL.WS_MES_VCT, AREA_DE_WORK.LC11_LINHA11.LC11_FATURA_MES);

            /*" -3365- MOVE V0COBP-DTINIVIG-PARC TO WS-DATA1. */
            _.Move(V0COBP_DTINIVIG_PARC, AREA_DE_WORK.WS_DATA1);

            /*" -3366- MOVE WS-DIA1 TO LC11-PERIODO-1-DD. */
            _.Move(AREA_DE_WORK.WS_DATA1.WS_DIA1, AREA_DE_WORK.LC11_LINHA11.LC11_PERIODO_1_DD);

            /*" -3367- MOVE WS-MES1 TO LC11-PERIODO-1-MM. */
            _.Move(AREA_DE_WORK.WS_DATA1.WS_MES1, AREA_DE_WORK.LC11_LINHA11.LC11_PERIODO_1_MM);

            /*" -3368- MOVE WS-ANO1 TO LC11-PERIODO-1-AA. */
            _.Move(AREA_DE_WORK.WS_DATA1.WS_ANO1, AREA_DE_WORK.LC11_LINHA11.LC11_PERIODO_1_AA);

            /*" -3370- MOVE WS-DATA1 TO WHOST-DATA1. */
            _.Move(AREA_DE_WORK.WS_DATA1, WHOST_DATA1);

            /*" -3372- MOVE SVA-PERIPGTO TO V0OPCP-PERIPGTO. */
            _.Move(REG_SVG0267B.SVA_PERIPGTO, V0OPCP_PERIPGTO);

            /*" -3379- PERFORM R2200_00_PROCESSA_FAC_DB_SELECT_1 */

            R2200_00_PROCESSA_FAC_DB_SELECT_1();

            /*" -3382- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3383- DISPLAY 'ERRO DATA DE TERMINO DE VIGENCIA ' SQLCODE */
                _.Display($"ERRO DATA DE TERMINO DE VIGENCIA {DB.SQLCODE}");

                /*" -3385- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3386- MOVE WHOST-DATA2 TO WS-DATA2. */
            _.Move(WHOST_DATA2, AREA_DE_WORK.WS_DATA2);

            /*" -3387- MOVE WS-DIA2 TO LC11-PERIODO-2-DD. */
            _.Move(AREA_DE_WORK.WS_DATA2.WS_DIA2, AREA_DE_WORK.LC11_LINHA11.LC11_PERIODO_2_DD);

            /*" -3388- MOVE WS-MES2 TO LC11-PERIODO-2-MM. */
            _.Move(AREA_DE_WORK.WS_DATA2.WS_MES2, AREA_DE_WORK.LC11_LINHA11.LC11_PERIODO_2_MM);

            /*" -3390- MOVE WS-ANO2 TO LC11-PERIODO-2-AA. */
            _.Move(AREA_DE_WORK.WS_DATA2.WS_ANO2, AREA_DE_WORK.LC11_LINHA11.LC11_PERIODO_2_AA);

            /*" -3391- MOVE V0COBP-QUANT-VIDAS TO LC11-NVIDAS. */
            _.Move(V0COBP_QUANT_VIDAS, AREA_DE_WORK.LC11_LINHA11.LC11_NVIDAS);

            /*" -3393- MOVE V0COBP-IMPSEGUR TO LC11-CAPITAL. */
            _.Move(V0COBP_IMPSEGUR, AREA_DE_WORK.LC11_LINHA11.LC11_CAPITAL);

            /*" -3395- WRITE RVG0267B-RECORD FROM LC11-LINHA11. */
            _.Move(AREA_DE_WORK.LC11_LINHA11.GetMoveValues(), RVG0267B_RECORD);

            RVG0267B.Write(RVG0267B_RECORD.GetMoveValues().ToString());

            /*" -3396- MOVE SVA-NUM-CEP-9 TO GEOBJECT-NUM-CEP */
            _.Move(REG_SVG0267B.SVA_NUM_CEP_9, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NUM_CEP);

            /*" -3397- MOVE 'VG0267B' TO GEOBJECT-NOM-PROGRAMA */
            _.Move("VG0267B", GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NOM_PROGRAMA);

            /*" -3399- MOVE 'D' TO GEOBJECT-STA-REGISTRO */
            _.Move("D", GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_STA_REGISTRO);

            /*" -3400- MOVE WS-PRODU-ANT TO GEOBJECT-COD-PRODUTO */
            _.Move(AREA_DE_WORK.WS_CHAVE_ANT.WS_PRODU_ANT, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_PRODUTO);

            /*" -3402- MOVE ZEROS TO GEOBJECT-NUM-INI-POS-VERSO GEOBJECT-VLR-DECLARADO */
            _.Move(0, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NUM_INI_POS_VERSO, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_VLR_DECLARADO);

            /*" -3403- MOVE 0 TO VIND-COD-PRODUTO */
            _.Move(0, VIND_COD_PRODUTO);

            /*" -3404- MOVE 4,6 TO GEOBJECT-QTD-PESO-GRAMAS */
            _.Move(4.6, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_QTD_PESO_GRAMAS);

            /*" -3406- IF WS-FORMU-ANT EQUAL 'VD32' OR 'VIDA26' */

            if (AREA_DE_WORK.WS_CHAVE_ANT.WS_FORMU_ANT.In("VD32", "VIDA26"))
            {

                /*" -3407- MOVE 'I' TO GEOBJECT-COD-IDENT-OBJETO */
                _.Move("I", GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_IDENT_OBJETO);

                /*" -3408- ELSE */
            }
            else
            {


                /*" -3409- MOVE SPACES TO GEOBJECT-COD-IDENT-OBJETO */
                _.Move("", GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_IDENT_OBJETO);

                /*" -3410- END-IF */
            }


            /*" -3411- MOVE 4500 TO GEOBJECT-DES-OBJETO-LEN */
            _.Move(4500, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_DES_OBJETO.GEOBJECT_DES_OBJETO_LEN);

            /*" -3423- MOVE LC11-LINHA11 TO GEOBJECT-DES-OBJETO-TEXT. */
            _.Move(AREA_DE_WORK.LC11_LINHA11, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_DES_OBJETO.GEOBJECT_DES_OBJETO_TEXT);

            /*" -3425- MOVE WS-FORMU-ANT TO GEOBJECT-COD-FORMULARIO. */
            _.Move(AREA_DE_WORK.WS_CHAVE_ANT.WS_FORMU_ANT, GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_FORMULARIO);

            /*" -3428- PERFORM R9100-00-INSERT-GEOBJECT. */

            R9100_00_INSERT_GEOBJECT_SECTION();

            /*" -3430- ADD 1 TO AC-IMPRESSOS. */
            AREA_DE_WORK.AC_IMPRESSOS.Value = AREA_DE_WORK.AC_IMPRESSOS + 1;

            /*" -3432- PERFORM R2600-00-UPDATE-V0HISTCOBVA. */

            R2600_00_UPDATE_V0HISTCOBVA_SECTION();

            /*" -3432- PERFORM R5200-GERA-SIT-IMPRESSAO. */

            R5200_GERA_SIT_IMPRESSAO_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R2200_40_NEXT */

            R2200_40_NEXT();

        }

        [StopWatch]
        /*" R2200-00-PROCESSA-FAC-DB-SELECT-1 */
        public void R2200_00_PROCESSA_FAC_DB_SELECT_1()
        {
            /*" -3379- EXEC SQL SELECT DATE(:WHOST-DATA1) + :V0OPCP-PERIPGTO MONTHS - 1 DAY INTO :WHOST-DATA2 FROM SEGUROS.V0SISTEMA WHERE IDSISTEM = 'FI' WITH UR END-EXEC. */

            var r2200_00_PROCESSA_FAC_DB_SELECT_1_Query1 = new R2200_00_PROCESSA_FAC_DB_SELECT_1_Query1()
            {
                V0OPCP_PERIPGTO = V0OPCP_PERIPGTO.ToString(),
                WHOST_DATA1 = WHOST_DATA1.ToString(),
            };

            var executed_1 = R2200_00_PROCESSA_FAC_DB_SELECT_1_Query1.Execute(r2200_00_PROCESSA_FAC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DATA2, WHOST_DATA2);
            }


        }

        [StopWatch]
        /*" R2200-40-NEXT */
        private void R2200_40_NEXT(bool isPerform = false)
        {
            /*" -3436- PERFORM R1950-00-LE-SORT. */

            R1950_00_LE_SORT_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2250-00-GERA-COD-BARRA-SECTION */
        private void R2250_00_GERA_COD_BARRA_SECTION()
        {
            /*" -3447- MOVE '2250' TO WNR-EXEC-SQL. */
            _.Move("2250", WABEND.WNR_EXEC_SQL);

            /*" -3449- INITIALIZE REGISTRO-LINKAGE-GE0355S. */
            _.Initialize(
                LBGE0355.REGISTRO_LINKAGE_GE0355S
            );

            /*" -3450- MOVE 104 TO LK-GE355-IN-BANCO */
            _.Move(104, LBGE0355.REGISTRO_LINKAGE_GE0355S.LK_GE355_IN_BANCO);

            /*" -3451- MOVE 9 TO LK-GE355-IN-MOEDA */
            _.Move(9, LBGE0355.REGISTRO_LINKAGE_GE0355S.LK_GE355_IN_MOEDA);

            /*" -3452- MOVE SVA-VLPRMTOT TO LK-GE355-IN-VLR-BOLETO */
            _.Move(REG_SVG0267B.SVA_VLPRMTOT, LBGE0355.REGISTRO_LINKAGE_GE0355S.LK_GE355_IN_VLR_BOLETO);

            /*" -3457- MOVE SVA-NN-SIGCB TO LK-GE355-IN-NOSSO-NUMERO */
            _.Move(REG_SVG0267B.SVA_NN_SIGCB, LBGE0355.REGISTRO_LINKAGE_GE0355S.LK_GE355_IN_NOSSO_NUMERO);

            /*" -3461- MOVE ZEROS TO WS-JV1-IND-OUT WS-JV1-IND-INI WS-JV1-LGTH-INI WS-JV1-LGTH-OUT. */
            _.Move(0, WORK_JV1.WS_JV1_IND_OUT, WORK_JV1.WS_JV1_IND_INI, WORK_JV1.WS_JV1_LGTH_INI, WORK_JV1.WS_JV1_LGTH_OUT);

            /*" -3464- COMPUTE WS-JV1-LGTH-INI = FUNCTION LENGTH(SVA-COD-CEDENTE). */
            WORK_JV1.WS_JV1_LGTH_INI.Value = REG_SVG0267B.SVA_COD_CEDENTE.Value.Length;

            /*" -3467- COMPUTE WS-JV1-LGTH-OUT = FUNCTION LENGTH(LK-GE355-IN-COD-BENEFICIARIO). */
            WORK_JV1.WS_JV1_LGTH_OUT.Value = LBGE0355.REGISTRO_LINKAGE_GE0355S.LK_GE355_IN_COD_BENEFICIARIO.Value.Length;

            /*" -3470- MOVE SPACES TO LK-GE355-IN-COD-BENEFICIARIO. */
            _.Move("", LBGE0355.REGISTRO_LINKAGE_GE0355S.LK_GE355_IN_COD_BENEFICIARIO);

            /*" -3473- PERFORM VARYING WS-JV1-IND-INI FROM 1 BY 1 UNTIL WS-JV1-IND-INI > WS-JV1-LGTH-INI */

            for (WORK_JV1.WS_JV1_IND_INI.Value = 1; !(WORK_JV1.WS_JV1_IND_INI > WORK_JV1.WS_JV1_LGTH_INI); WORK_JV1.WS_JV1_IND_INI.Value += 1)
            {

                /*" -3475- IF SVA-COD-CEDENTE(WS-JV1-IND-INI:1) NOT = SPACE THEN */

                if (REG_SVG0267B.SVA_COD_CEDENTE.Substring(WORK_JV1.WS_JV1_IND_INI, 1) != " ")
                {

                    /*" -3476- ADD 1 TO WS-JV1-IND-OUT */
                    WORK_JV1.WS_JV1_IND_OUT.Value = WORK_JV1.WS_JV1_IND_OUT + 1;

                    /*" -3477- IF WS-JV1-IND-OUT > WS-JV1-LGTH-OUT */

                    if (WORK_JV1.WS_JV1_IND_OUT > WORK_JV1.WS_JV1_LGTH_OUT)
                    {

                        /*" -3478- DISPLAY '*****************************************' */
                        _.Display($"*****************************************");

                        /*" -3479- DISPLAY '*       R2250-00-GERA-COD-BARRA         *' */
                        _.Display($"*       R2250-00-GERA-COD-BARRA         *");

                        /*" -3480- DISPLAY '*    ERRO NO CEDENTE ENVIADO PELO SAP   *' */
                        _.Display($"*    ERRO NO CEDENTE ENVIADO PELO SAP   *");

                        /*" -3481- DISPLAY '*****************************************' */
                        _.Display($"*****************************************");

                        /*" -3482- DISPLAY '=> COD-CEDENTE... ' '' SVA-COD-CEDENTE '' '' */

                        $"=> COD-CEDENTE... {REG_SVG0267B.SVA_COD_CEDENTE}"
                        .Display();

                        /*" -3483- DISPLAY '*****************************************' */
                        _.Display($"*****************************************");

                        /*" -3484- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -3486- END-IF */
                    }


                    /*" -3488- MOVE SVA-COD-CEDENTE(WS-JV1-IND-INI:1) TO LK-GE355-IN-COD-BENEFICIARIO(WS-JV1-IND-OUT:1) */
                    _.MoveAtPosition(REG_SVG0267B.SVA_COD_CEDENTE.Substring(WORK_JV1.WS_JV1_IND_INI, 1), LBGE0355.REGISTRO_LINKAGE_GE0355S.LK_GE355_IN_COD_BENEFICIARIO, WORK_JV1.WS_JV1_IND_OUT, 1);

                    /*" -3490- END-IF */
                }


                /*" -3492- END-PERFORM. */
            }

            /*" -3494- MOVE LK-GE355-IN-COD-BENEFICIARIO TO SVA-COD-CEDENTE. */
            _.Move(LBGE0355.REGISTRO_LINKAGE_GE0355S.LK_GE355_IN_COD_BENEFICIARIO, REG_SVG0267B.SVA_COD_CEDENTE);

            /*" -3496- MOVE SVA-DTA-VENC TO LK-GE355-IN-DATA-VENCIMENTO */
            _.Move(REG_SVG0267B.SVA_DTA_VENC, LBGE0355.REGISTRO_LINKAGE_GE0355S.LK_GE355_IN_DATA_VENCIMENTO);

            /*" -3498- CALL 'GE0355S' USING REGISTRO-LINKAGE-GE0355S. */
            _.Call("GE0355S", LBGE0355.REGISTRO_LINKAGE_GE0355S);

            /*" -3499- IF (LK-GE355-OUT-COD-RETORNO NOT EQUAL '0' ) */

            if ((LBGE0355.REGISTRO_LINKAGE_GE0355S.LK_GE355_OUT_COD_RETORNO != "0"))
            {

                /*" -3500- DISPLAY ' ' */
                _.Display($" ");

                /*" -3501- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -3502- DISPLAY '*       R2250-00-GERA-COD-BARRA         *' */
                _.Display($"*       R2250-00-GERA-COD-BARRA         *");

                /*" -3503- DISPLAY '*  ERRO NA EXECUCAO DO CALL DA GE0355S  *' */
                _.Display($"*  ERRO NA EXECUCAO DO CALL DA GE0355S  *");

                /*" -3504- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -3505- DISPLAY '=> BANCO......... ' LK-GE355-IN-BANCO */
                _.Display($"=> BANCO......... {LBGE0355.REGISTRO_LINKAGE_GE0355S.LK_GE355_IN_BANCO}");

                /*" -3506- DISPLAY '=> MOEDA......... ' LK-GE355-IN-MOEDA */
                _.Display($"=> MOEDA......... {LBGE0355.REGISTRO_LINKAGE_GE0355S.LK_GE355_IN_MOEDA}");

                /*" -3507- DISPLAY '=> VLR-BOLETO.... ' LK-GE355-IN-VLR-BOLETO */
                _.Display($"=> VLR-BOLETO.... {LBGE0355.REGISTRO_LINKAGE_GE0355S.LK_GE355_IN_VLR_BOLETO}");

                /*" -3508- DISPLAY '=> NOSSO-NUMERO.. ' LK-GE355-IN-NOSSO-NUMERO */
                _.Display($"=> NOSSO-NUMERO.. {LBGE0355.REGISTRO_LINKAGE_GE0355S.LK_GE355_IN_NOSSO_NUMERO}");

                /*" -3509- DISPLAY '=> DTA-VENCIMENTO ' LK-GE355-IN-DATA-VENCIMENTO */
                _.Display($"=> DTA-VENCIMENTO {LBGE0355.REGISTRO_LINKAGE_GE0355S.LK_GE355_IN_DATA_VENCIMENTO}");

                /*" -3510- DISPLAY '=> COD-BENEFIC... ' LK-GE355-IN-COD-BENEFICIARIO */
                _.Display($"=> COD-BENEFIC... {LBGE0355.REGISTRO_LINKAGE_GE0355S.LK_GE355_IN_COD_BENEFICIARIO}");

                /*" -3511- DISPLAY '-----------------------------------------' */
                _.Display($"-----------------------------------------");

                /*" -3512- DISPLAY '=> LK-MENSAGEM .. ' LK-GE355-OUT-MSG-RETORNO */
                _.Display($"=> LK-MENSAGEM .. {LBGE0355.REGISTRO_LINKAGE_GE0355S.LK_GE355_OUT_MENSAGEM.LK_GE355_OUT_MSG_RETORNO}");

                /*" -3513- DISPLAY '=> LK-COD-RETORNO ' LK-GE355-OUT-COD-RETORNO */
                _.Display($"=> LK-COD-RETORNO {LBGE0355.REGISTRO_LINKAGE_GE0355S.LK_GE355_OUT_COD_RETORNO}");

                /*" -3514- DISPLAY '=> LK-SQLCODE.... ' LK-GE355-OUT-SQLCODE */
                _.Display($"=> LK-SQLCODE.... {LBGE0355.REGISTRO_LINKAGE_GE0355S.LK_GE355_OUT_MENSAGEM.LK_GE355_OUT_SQLCODE}");

                /*" -3515- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -3516- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3518- END-IF. */
            }


            /*" -3519- IF (SVA-LIN-DIGITAVEL NOT EQUAL LK-GE355-OUT-LINHA-DIGITAVEL) */

            if ((REG_SVG0267B.SVA_LIN_DIGITAVEL != LBGE0355.REGISTRO_LINKAGE_GE0355S.LK_GE355_OUT_LINHA_DIGITAVEL))
            {

                /*" -3520- DISPLAY 'ERRO - LINHA DIGITAVEL SAP <> DA LD GE0355S ' */
                _.Display($"ERRO - LINHA DIGITAVEL SAP <> DA LD GE0355S ");

                /*" -3521- DISPLAY 'LINHA DIGITAVEL SAP ' SVA-LIN-DIGITAVEL */
                _.Display($"LINHA DIGITAVEL SAP {REG_SVG0267B.SVA_LIN_DIGITAVEL}");

                /*" -3523- DISPLAY 'LINHA DIGITAVEL GE0335S ' LK-GE355-OUT-LINHA-DIGITAVEL */
                _.Display($"LINHA DIGITAVEL GE0335S {LBGE0355.REGISTRO_LINKAGE_GE0355S.LK_GE355_OUT_LINHA_DIGITAVEL}");

                /*" -3524- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2250_99_SAIDA*/

        [StopWatch]
        /*" R2310-00-IDENTIFICA-MSG-SECTION */
        private void R2310_00_IDENTIFICA_MSG_SECTION()
        {
            /*" -3537- MOVE 'R2310-00-IDENTIFICA-MSG' TO PARAGRAFO. */
            _.Move("R2310-00-IDENTIFICA-MSG", PARAGRAFO);

            /*" -3539- MOVE SVA-FORMULARIO TO WS-JDE-GER */
            _.Move(REG_SVG0267B.SVA_FORMULARIO, AREA_DE_WORK.WS_JDE_GER);

            /*" -3540- MOVE SPACES TO LC09-LIN09 */
            _.Move("", AREA_DE_WORK.FILLER_7.LC09_LIN09);

            /*" -3543- MOVE FUNCTION LOWER-CASE(WS-JDE-GER) TO WS-FORM-LINHA */
            _.Move(AREA_DE_WORK.WS_JDE_GER.ToString().ToLower(), WS_FORM_LINHA);

            /*" -3547- STRING '(' WS-FORM-LINHA DELIMITED BY ' ' FUNCTION LOWER-CASE( '.DBM' ) ') STARTDBM' DELIMITED BY SIZE INTO LC09-LIN09. */
            #region STRING
            var spl1 = "(" + WS_FORM_LINHA.GetMoveValues().Split(" ").FirstOrDefault();
            spl1 += ".DBM".ToString().ToLower();
            spl1 += ") STARTDBM";
            spl1 += "(";
            var spl2 = WS_FORM_LINHA.GetMoveValues();
            spl2 += ".DBM".ToString().ToLower();
            spl2 += ") STARTDBM";
            var results3 = spl1 + spl2;
            _.Move(results3, AREA_DE_WORK.FILLER_7.LC09_LIN09);
            #endregion

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2310_99_SAIDA*/

        [StopWatch]
        /*" R2315-00-SELECT-V0MULTIMENS-SECTION */
        private void R2315_00_SELECT_V0MULTIMENS_SECTION()
        {
            /*" -3575- MOVE 'R2315-00-SELECT-V0MULT' TO PARAGRAFO. */
            _.Move("R2315-00-SELECT-V0MULT", PARAGRAFO);

            /*" -3577- MOVE '231' TO WNR-EXEC-SQL */
            _.Move("231", WABEND.WNR_EXEC_SQL);

            /*" -3587- PERFORM R2315_00_SELECT_V0MULTIMENS_DB_SELECT_1 */

            R2315_00_SELECT_V0MULTIMENS_DB_SELECT_1();

            /*" -3590- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3591- DISPLAY 'R2315 - NAO ENCONTRADO NA V0MSGCOBR   ' */
                _.Display($"R2315 - NAO ENCONTRADO NA V0MSGCOBR   ");

                /*" -3592- DISPLAY 'APOLICE     => ' V0MENS-NUM-APOLICE */
                _.Display($"APOLICE     => {V0MENS_NUM_APOLICE}");

                /*" -3593- DISPLAY 'SUBGRUPO    => ' V0MENS-CODSUBES */
                _.Display($"SUBGRUPO    => {V0MENS_CODSUBES}");

                /*" -3594- DISPLAY 'OPERACAO    => ' WHOST-CODOPER */
                _.Display($"OPERACAO    => {WHOST_CODOPER}");

                /*" -3594- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2315-00-SELECT-V0MULTIMENS-DB-SELECT-1 */
        public void R2315_00_SELECT_V0MULTIMENS_DB_SELECT_1()
        {
            /*" -3587- EXEC SQL SELECT JDE, JDL INTO :V0MENS-JDE, :V0MENS-JDL FROM SEGUROS.COBRANCA_MENS_VGAP WHERE IDFORM = 'A4' AND NUM_APOLICE = :V0MENS-NUM-APOLICE AND CODSUBES = :V0MENS-CODSUBES AND COD_OPERACAO = :WHOST-CODOPER END-EXEC. */

            var r2315_00_SELECT_V0MULTIMENS_DB_SELECT_1_Query1 = new R2315_00_SELECT_V0MULTIMENS_DB_SELECT_1_Query1()
            {
                V0MENS_NUM_APOLICE = V0MENS_NUM_APOLICE.ToString(),
                V0MENS_CODSUBES = V0MENS_CODSUBES.ToString(),
                WHOST_CODOPER = WHOST_CODOPER.ToString(),
            };

            var executed_1 = R2315_00_SELECT_V0MULTIMENS_DB_SELECT_1_Query1.Execute(r2315_00_SELECT_V0MULTIMENS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0MENS_JDE, V0MENS_JDE);
                _.Move(executed_1.V0MENS_JDL, V0MENS_JDL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2315_99_SAIDA*/

        [StopWatch]
        /*" R2320-00-TRATA-MENSAGEM-SECTION */
        private void R2320_00_TRATA_MENSAGEM_SECTION()
        {
            /*" -3606- MOVE 'R2320-00-TRATA-MEN' TO PARAGRAFO. */
            _.Move("R2320-00-TRATA-MEN", PARAGRAFO);

            /*" -3609- PERFORM R2340-00-SELECT-V0PARCELVA. */

            R2340_00_SELECT_V0PARCELVA_SECTION();

            /*" -3609- PERFORM R2450-00-SELECT-V0COBERPROPVA. */

            R2450_00_SELECT_V0COBERPROPVA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2320_99_SAIDA*/

        [StopWatch]
        /*" R2325-PRODUTO-RUNOFF-SECTION */
        private void R2325_PRODUTO_RUNOFF_SECTION()
        {
            /*" -3620- MOVE '2325' TO WNR-EXEC-SQL. */
            _.Move("2325", WABEND.WNR_EXEC_SQL);

            /*" -3621- SET WS-IND-PROD TO 1 */
            JVBKINCL.WS_IND_PROD.Value = 1;

            /*" -3623- SEARCH CVPPROD AT END */
            void SearchAtEnd0()
            {

                /*" -3624- SET WS-PROD-RUNON TO TRUE */
                AREA_DE_WORK.WS_SIT_PRODUTO["WS_PROD_RUNON"] = true;

                /*" -3625- WHEN CVPPROD(WS-IND-PROD) EQUAL WS-COD-PRODUTO */
            };

            var mustSearchAtEnd0 = true;
            for (; JVBKINCL.WS_IND_PROD < JVBKINCL.CVP_PRODUTO.CVPPROD.Items.Count; JVBKINCL.WS_IND_PROD.Value++)
            {

                if (JVBKINCL.CVP_PRODUTO.CVPPROD[JVBKINCL.WS_IND_PROD] == WS_COD_PRODUTO)
                {

                    mustSearchAtEnd0 = false;

                    /*" -3626- SET WS-PROD-RUNOFF TO TRUE */
                    AREA_DE_WORK.WS_SIT_PRODUTO["WS_PROD_RUNOFF"] = true;

                    /*" -3628- END-SEARCH */

                    /*" -3628- END-SEARCH. */
                    break;
                }
            }

            if (mustSearchAtEnd0)
                SearchAtEnd0();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2325_99_SAIDA*/

        [StopWatch]
        /*" R2340-00-SELECT-V0PARCELVA-SECTION */
        private void R2340_00_SELECT_V0PARCELVA_SECTION()
        {
            /*" -3639- MOVE 'R2340-00-SELECT-V0' TO PARAGRAFO. */
            _.Move("R2340-00-SELECT-V0", PARAGRAFO);

            /*" -3641- MOVE '234' TO WNR-EXEC-SQL. */
            _.Move("234", WABEND.WNR_EXEC_SQL);

            /*" -3655- PERFORM R2340_00_SELECT_V0PARCELVA_DB_SELECT_1 */

            R2340_00_SELECT_V0PARCELVA_DB_SELECT_1();

            /*" -3658- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3659- DISPLAY 'R2340 - NAO ENCONTRADO NA V0PARCELVA' */
                _.Display($"R2340 - NAO ENCONTRADO NA V0PARCELVA");

                /*" -3660- DISPLAY 'CERTIFICADO => ' WHOST-NRCERTIF */
                _.Display($"CERTIFICADO => {WHOST_NRCERTIF}");

                /*" -3661- DISPLAY 'PARCELA     => ' WHOST-NRPARCEL */
                _.Display($"PARCELA     => {WHOST_NRPARCEL}");

                /*" -3663- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3666- COMPUTE WS-VLPRMTOT = V0PARC-PRMVG + V0PARC-PRMAP. */
            AREA_DE_WORK.WS_VLPRMTOT.Value = V0PARC_PRMVG + V0PARC_PRMAP;

            /*" -3669- COMPUTE WS-VLPREMIO = WS-VLPRMTOT - V0PARC-VLMULTA. */
            AREA_DE_WORK.WS_VLPREMIO.Value = AREA_DE_WORK.WS_VLPRMTOT - V0PARC_VLMULTA;

            /*" -3670- COMPUTE WS-VLMULTA = V0PARC-VLMULTA - 1,50. */
            AREA_DE_WORK.WS_VLMULTA.Value = V0PARC_VLMULTA - 1.50;

        }

        [StopWatch]
        /*" R2340-00-SELECT-V0PARCELVA-DB-SELECT-1 */
        public void R2340_00_SELECT_V0PARCELVA_DB_SELECT_1()
        {
            /*" -3655- EXEC SQL SELECT PRMVG + PRMAP - VLMULTA, DTVENCTO, PRMVG, PRMAP, VLMULTA INTO :V0PARC-VLPRMTOT, :V0PARC-DTVENCTO, :V0PARC-PRMVG, :V0PARC-PRMAP, :V0PARC-VLMULTA FROM SEGUROS.V0PARCELVA WHERE NRCERTIF = :WHOST-NRCERTIF AND NRPARCEL = :WHOST-NRPARCEL END-EXEC. */

            var r2340_00_SELECT_V0PARCELVA_DB_SELECT_1_Query1 = new R2340_00_SELECT_V0PARCELVA_DB_SELECT_1_Query1()
            {
                WHOST_NRCERTIF = WHOST_NRCERTIF.ToString(),
                WHOST_NRPARCEL = WHOST_NRPARCEL.ToString(),
            };

            var executed_1 = R2340_00_SELECT_V0PARCELVA_DB_SELECT_1_Query1.Execute(r2340_00_SELECT_V0PARCELVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PARC_VLPRMTOT, V0PARC_VLPRMTOT);
                _.Move(executed_1.V0PARC_DTVENCTO, V0PARC_DTVENCTO);
                _.Move(executed_1.V0PARC_PRMVG, V0PARC_PRMVG);
                _.Move(executed_1.V0PARC_PRMAP, V0PARC_PRMAP);
                _.Move(executed_1.V0PARC_VLMULTA, V0PARC_VLMULTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2340_99_SAIDA*/

        [StopWatch]
        /*" R2450-00-SELECT-V0COBERPROPVA-SECTION */
        private void R2450_00_SELECT_V0COBERPROPVA_SECTION()
        {
            /*" -3682- MOVE 'R2450-00-SELECT-V0COBERPROPVA' TO PARAGRAFO. */
            _.Move("R2450-00-SELECT-V0COBERPROPVA", PARAGRAFO);

            /*" -3684- MOVE '245' TO WNR-EXEC-SQL. */
            _.Move("245", WABEND.WNR_EXEC_SQL);

            /*" -3686- MOVE SVA-DTVENCTO-ORIG TO V0PARC-DTVENCTO-ORIG. */
            _.Move(REG_SVG0267B.SVA_DTVENCTO_ORIG, V0PARC_DTVENCTO_ORIG);

            /*" -3699- PERFORM R2450_00_SELECT_V0COBERPROPVA_DB_SELECT_1 */

            R2450_00_SELECT_V0COBERPROPVA_DB_SELECT_1();

            /*" -3702- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3703- DISPLAY 'R2450 - NAO ENCONTRADO NA V0COBERPROPVA' */
                _.Display($"R2450 - NAO ENCONTRADO NA V0COBERPROPVA");

                /*" -3704- DISPLAY 'CERTIFICADO => ' WHOST-NRCERTIF */
                _.Display($"CERTIFICADO => {WHOST_NRCERTIF}");

                /*" -3705- DISPLAY 'VENCIMENTO  => ' V0PARC-DTVENCTO */
                _.Display($"VENCIMENTO  => {V0PARC_DTVENCTO}");

                /*" -3706- DISPLAY 'PROX VENCIM => ' V0HIST-DTVENCTO */
                _.Display($"PROX VENCIM => {V0HIST_DTVENCTO}");

                /*" -3707- DISPLAY 'VENC ORIGIN => ' V0PARC-DTVENCTO-ORIG */
                _.Display($"VENC ORIGIN => {V0PARC_DTVENCTO_ORIG}");

                /*" -3708- DISPLAY 'PARCELA     => ' WHOST-NRPARCEL */
                _.Display($"PARCELA     => {WHOST_NRPARCEL}");

                /*" -3710- IF SQLCODE EQUAL 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -3711- ELSE */
                }
                else
                {


                    /*" -3712- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3713- END-IF */
                }


                /*" -3713- END-IF. */
            }


        }

        [StopWatch]
        /*" R2450-00-SELECT-V0COBERPROPVA-DB-SELECT-1 */
        public void R2450_00_SELECT_V0COBERPROPVA_DB_SELECT_1()
        {
            /*" -3699- EXEC SQL SELECT IMPMORNATU, VLPREMIO, DTINIVIG, IMPSEGCDC INTO :V0COBE-IMPMORNATU, :V0COBE-VLPREMIO, :V0COBE-DTINIVIG, :V0COBE-IMPSEGCDG FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :WHOST-NRCERTIF AND DTINIVIG <= :V0PARC-DTVENCTO-ORIG AND DTTERVIG >= :V0PARC-DTVENCTO-ORIG END-EXEC. */

            var r2450_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1 = new R2450_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1()
            {
                V0PARC_DTVENCTO_ORIG = V0PARC_DTVENCTO_ORIG.ToString(),
                WHOST_NRCERTIF = WHOST_NRCERTIF.ToString(),
            };

            var executed_1 = R2450_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1.Execute(r2450_00_SELECT_V0COBERPROPVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBE_IMPMORNATU, V0COBE_IMPMORNATU);
                _.Move(executed_1.V0COBE_VLPREMIO, V0COBE_VLPREMIO);
                _.Move(executed_1.V0COBE_DTINIVIG, V0COBE_DTINIVIG);
                _.Move(executed_1.V0COBE_IMPSEGCDG, V0COBE_IMPSEGCDG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2450_99_SAIDA*/

        [StopWatch]
        /*" R2350-00-TRATA-PARCELAS-SECTION */
        private void R2350_00_TRATA_PARCELAS_SECTION()
        {
            /*" -3725- MOVE 'R2350-00-TRATA-PARCELAS' TO PARAGRAFO. */
            _.Move("R2350-00-TRATA-PARCELAS", PARAGRAFO);

            /*" -3727- MOVE '235' TO WNR-EXEC-SQL. */
            _.Move("235", WABEND.WNR_EXEC_SQL);

            /*" -3735- PERFORM R2350_00_TRATA_PARCELAS_DB_DECLARE_1 */

            R2350_00_TRATA_PARCELAS_DB_DECLARE_1();

            /*" -3737- PERFORM R2350_00_TRATA_PARCELAS_DB_OPEN_1 */

            R2350_00_TRATA_PARCELAS_DB_OPEN_1();

            /*" -3741- MOVE 'N' TO WFIM-V0PARCELVA. */
            _.Move("N", AREA_DE_WORK.WFIM_V0PARCELVA);

            /*" -3743- PERFORM R2355-00-FETCH-PARCELAS. */

            R2355_00_FETCH_PARCELAS_SECTION();

            /*" -3744- IF WFIM-V0PARCELVA EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_V0PARCELVA == "S")
            {

                /*" -3746- GO TO R2350-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2350_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3747- MOVE ZEROS TO WIND1 TABELA-VALORES. */
            _.Move(0, AREA_DE_WORK.WIND1, TABELA_VALORES);

            /*" -0- FLUXCONTROL_PERFORM R2350_10_LOOP_V0HISTCOB */

            R2350_10_LOOP_V0HISTCOB();

        }

        [StopWatch]
        /*" R2350-00-TRATA-PARCELAS-DB-OPEN-1 */
        public void R2350_00_TRATA_PARCELAS_DB_OPEN_1()
        {
            /*" -3737- EXEC SQL OPEN CHISTCOB1 END-EXEC. */

            CHISTCOB1.Open();

        }

        [StopWatch]
        /*" R2350-10-LOOP-V0HISTCOB */
        private void R2350_10_LOOP_V0HISTCOB(bool isPerform = false)
        {
            /*" -3753- MOVE 'R0000-00-PRINCIPAL' TO PARAGRAFO. */
            _.Move("R0000-00-PRINCIPAL", PARAGRAFO);

            /*" -3754- ADD 1 TO WIND1. */
            AREA_DE_WORK.WIND1.Value = AREA_DE_WORK.WIND1 + 1;

            /*" -3756- MOVE '2351' TO WNR-EXEC-SQL. */
            _.Move("2351", WABEND.WNR_EXEC_SQL);

            /*" -3766- PERFORM R2350_10_LOOP_V0HISTCOB_DB_SELECT_1 */

            R2350_10_LOOP_V0HISTCOB_DB_SELECT_1();

            /*" -3769- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3770- DISPLAY 'R2351 - NAO ENCONTRADO NA V0PARCELVA' */
                _.Display($"R2351 - NAO ENCONTRADO NA V0PARCELVA");

                /*" -3771- DISPLAY 'CERTIFICADO => ' WHOST-NRCERTIF */
                _.Display($"CERTIFICADO => {WHOST_NRCERTIF}");

                /*" -3772- DISPLAY 'PARCELA     => ' WHOST-NRPARCEL */
                _.Display($"PARCELA     => {WHOST_NRPARCEL}");

                /*" -3774- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3776- COMPUTE WS-VLPRMTOT = V0PARC-PRMVG + V0PARC-PRMAP. */
            AREA_DE_WORK.WS_VLPRMTOT.Value = V0PARC_PRMVG + V0PARC_PRMAP;

            /*" -3778- MOVE WS-VLPRMTOT TO TAB-VLPRMTOT (WIND1) */
            _.Move(AREA_DE_WORK.WS_VLPRMTOT, TABELA_VALORES.TAB_VALORES[AREA_DE_WORK.WIND1].TAB_VLPRMTOT);

            /*" -3781- COMPUTE TAB-VLPREMIO (WIND1) = WS-VLPRMTOT - V0PARC-VLMULTA. */
            TABELA_VALORES.TAB_VALORES[AREA_DE_WORK.WIND1].TAB_VLPREMIO.Value = AREA_DE_WORK.WS_VLPRMTOT - V0PARC_VLMULTA;

            /*" -3782- IF WIND1 = 3 */

            if (AREA_DE_WORK.WIND1 == 3)
            {

                /*" -3784- COMPUTE TAB-VLMULTA (WIND1) = V0PARC-VLMULTA - 3,00 */
                TABELA_VALORES.TAB_VALORES[AREA_DE_WORK.WIND1].TAB_VLMULTA.Value = V0PARC_VLMULTA - 3.00;

                /*" -3785- ELSE */
            }
            else
            {


                /*" -3788- COMPUTE TAB-VLMULTA (WIND1) = V0PARC-VLMULTA - 1,50. */
                TABELA_VALORES.TAB_VALORES[AREA_DE_WORK.WIND1].TAB_VLMULTA.Value = V0PARC_VLMULTA - 1.50;
            }


            /*" -3790- PERFORM R2355-00-FETCH-PARCELAS. */

            R2355_00_FETCH_PARCELAS_SECTION();

            /*" -3792- IF WFIM-V0PARCELVA EQUAL 'S' NEXT SENTENCE */

            if (AREA_DE_WORK.WFIM_V0PARCELVA == "S")
            {

                /*" -3793- ELSE */
            }
            else
            {


                /*" -3793- GO TO R2350-10-LOOP-V0HISTCOB. */
                new Task(() => R2350_10_LOOP_V0HISTCOB()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }

        [StopWatch]
        /*" R2350-10-LOOP-V0HISTCOB-DB-SELECT-1 */
        public void R2350_10_LOOP_V0HISTCOB_DB_SELECT_1()
        {
            /*" -3766- EXEC SQL SELECT PRMVG, PRMAP, VLMULTA INTO :V0PARC-PRMVG, :V0PARC-PRMAP, :V0PARC-VLMULTA FROM SEGUROS.V0PARCELVA WHERE NRCERTIF = :V0HIST-NRCERTIF AND NRPARCEL = :V0HIST-NRPARCEL END-EXEC. */

            var r2350_10_LOOP_V0HISTCOB_DB_SELECT_1_Query1 = new R2350_10_LOOP_V0HISTCOB_DB_SELECT_1_Query1()
            {
                V0HIST_NRCERTIF = V0HIST_NRCERTIF.ToString(),
                V0HIST_NRPARCEL = V0HIST_NRPARCEL.ToString(),
            };

            var executed_1 = R2350_10_LOOP_V0HISTCOB_DB_SELECT_1_Query1.Execute(r2350_10_LOOP_V0HISTCOB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PARC_PRMVG, V0PARC_PRMVG);
                _.Move(executed_1.V0PARC_PRMAP, V0PARC_PRMAP);
                _.Move(executed_1.V0PARC_VLMULTA, V0PARC_VLMULTA);
            }


        }

        [StopWatch]
        /*" R2350-20-MONTA-LINHAS */
        private void R2350_20_MONTA_LINHAS(bool isPerform = false)
        {
            /*" -3799- MOVE 'R2350-20-MONTA-LINHAS' TO PARAGRAFO. */
            _.Move("R2350-20-MONTA-LINHAS", PARAGRAFO);

            /*" -3800- IF SVA-CODOPER = 122 */

            if (REG_SVG0267B.SVA_CODOPER == 122)
            {

                /*" -3803- COMPUTE WS-VLPREMIO = TAB-VLPREMIO (1) + 1,50 + TAB-VLMULTA (1) */
                AREA_DE_WORK.WS_VLPREMIO.Value = TABELA_VALORES.TAB_VALORES[1].TAB_VLPREMIO.Value + 1.50 + TABELA_VALORES.TAB_VALORES[1].TAB_VLMULTA.Value;

                /*" -3805- COMPUTE WS-VLPREMIO = TAB-VLPREMIO (2) - TAB-VLPREMIO (1) */
                AREA_DE_WORK.WS_VLPREMIO.Value = TABELA_VALORES.TAB_VALORES[2].TAB_VLPREMIO.Value - TABELA_VALORES.TAB_VALORES[1].TAB_VLPREMIO.Value;

                /*" -3806- ELSE */
            }
            else
            {


                /*" -3809- COMPUTE WS-VLPREMIO = TAB-VLPREMIO (2) + 3,00 + TAB-VLMULTA (3) */
                AREA_DE_WORK.WS_VLPREMIO.Value = TABELA_VALORES.TAB_VALORES[2].TAB_VLPREMIO.Value + 3.00 + TABELA_VALORES.TAB_VALORES[3].TAB_VLMULTA.Value;

                /*" -3810- COMPUTE WS-VLPREMIO = TAB-VLPREMIO (3) - TAB-VLPREMIO (2). */
                AREA_DE_WORK.WS_VLPREMIO.Value = TABELA_VALORES.TAB_VALORES[3].TAB_VLPREMIO.Value - TABELA_VALORES.TAB_VALORES[2].TAB_VLPREMIO.Value;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2350_99_SAIDA*/

        [StopWatch]
        /*" R2355-00-FETCH-PARCELAS-SECTION */
        private void R2355_00_FETCH_PARCELAS_SECTION()
        {
            /*" -3822- MOVE 'R2355-00-FETCH-PARCELAS' TO PARAGRAFO. */
            _.Move("R2355-00-FETCH-PARCELAS", PARAGRAFO);

            /*" -3824- MOVE '2355' TO WNR-EXEC-SQL. */
            _.Move("2355", WABEND.WNR_EXEC_SQL);

            /*" -3828- PERFORM R2355_00_FETCH_PARCELAS_DB_FETCH_1 */

            R2355_00_FETCH_PARCELAS_DB_FETCH_1();

            /*" -3831- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3832- MOVE 'S' TO WFIM-V0PARCELVA */
                _.Move("S", AREA_DE_WORK.WFIM_V0PARCELVA);

                /*" -3832- PERFORM R2355_00_FETCH_PARCELAS_DB_CLOSE_1 */

                R2355_00_FETCH_PARCELAS_DB_CLOSE_1();

                /*" -3833- GO TO R2355-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2355_99_SAIDA*/ //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2355-00-FETCH-PARCELAS-DB-FETCH-1 */
        public void R2355_00_FETCH_PARCELAS_DB_FETCH_1()
        {
            /*" -3828- EXEC SQL FETCH CHISTCOB1 INTO :V0HIST-NRCERTIF, :V0HIST-NRPARCEL END-EXEC. */

            if (CHISTCOB1.Fetch())
            {
                _.Move(CHISTCOB1.V0HIST_NRCERTIF, V0HIST_NRCERTIF);
                _.Move(CHISTCOB1.V0HIST_NRPARCEL, V0HIST_NRPARCEL);
            }

        }

        [StopWatch]
        /*" R2355-00-FETCH-PARCELAS-DB-CLOSE-1 */
        public void R2355_00_FETCH_PARCELAS_DB_CLOSE_1()
        {
            /*" -3832- EXEC SQL CLOSE CHISTCOB1 END-EXEC */

            CHISTCOB1.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2355_99_SAIDA*/

        [StopWatch]
        /*" R2400-00-CALCULA-DIGITO-SECTION */
        private void R2400_00_CALCULA_DIGITO_SECTION()
        {
            /*" -3845- MOVE 'R2400-00-CALCULA-DIGITO' TO PARAGRAFO. */
            _.Move("R2400-00-CALCULA-DIGITO", PARAGRAFO);

            /*" -3846- MOVE WK-NUMERO TO LPARM01 */
            _.Move(AREA_DE_WORK.WK_NUMERO_R.WK_NUMERO, AREA_DE_WORK.LPARM01X.LPARM01);

            /*" -3848- MOVE ZEROS TO WPARM01-AUX */
            _.Move(0, AREA_DE_WORK.WPARM01_AUX);

            /*" -3849- COMPUTE WCALCULO = LPARM01-15 * 2 */
            AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.LPARM01X.LPARM01_R.LPARM01_15 * 2;

            /*" -3850- IF WCALCULO GREATER 9 */

            if (AREA_DE_WORK.WCALCULO > 9)
            {

                /*" -3852- COMPUTE WCALCULO = WCALCUL1 + WCALCUL2. */
                AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.FILLER_153.WCALCUL1 + AREA_DE_WORK.FILLER_153.WCALCUL2;
            }


            /*" -3854- ADD WCALCULO TO WPARM01-AUX */
            AREA_DE_WORK.WPARM01_AUX.Value = AREA_DE_WORK.WPARM01_AUX + AREA_DE_WORK.WCALCULO;

            /*" -3855- COMPUTE WCALCULO = LPARM01-14 * 1 */
            AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.LPARM01X.LPARM01_R.LPARM01_14 * 1;

            /*" -3856- IF WCALCULO GREATER 9 */

            if (AREA_DE_WORK.WCALCULO > 9)
            {

                /*" -3858- COMPUTE WCALCULO = WCALCUL1 + WCALCUL2. */
                AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.FILLER_153.WCALCUL1 + AREA_DE_WORK.FILLER_153.WCALCUL2;
            }


            /*" -3860- ADD WCALCULO TO WPARM01-AUX */
            AREA_DE_WORK.WPARM01_AUX.Value = AREA_DE_WORK.WPARM01_AUX + AREA_DE_WORK.WCALCULO;

            /*" -3861- COMPUTE WCALCULO = LPARM01-13 * 2 */
            AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.LPARM01X.LPARM01_R.LPARM01_13 * 2;

            /*" -3862- IF WCALCULO GREATER 9 */

            if (AREA_DE_WORK.WCALCULO > 9)
            {

                /*" -3864- COMPUTE WCALCULO = WCALCUL1 + WCALCUL2. */
                AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.FILLER_153.WCALCUL1 + AREA_DE_WORK.FILLER_153.WCALCUL2;
            }


            /*" -3866- ADD WCALCULO TO WPARM01-AUX */
            AREA_DE_WORK.WPARM01_AUX.Value = AREA_DE_WORK.WPARM01_AUX + AREA_DE_WORK.WCALCULO;

            /*" -3867- COMPUTE WCALCULO = LPARM01-12 * 1 */
            AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.LPARM01X.LPARM01_R.LPARM01_12 * 1;

            /*" -3868- IF WCALCULO GREATER 9 */

            if (AREA_DE_WORK.WCALCULO > 9)
            {

                /*" -3870- COMPUTE WCALCULO = WCALCUL1 + WCALCUL2. */
                AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.FILLER_153.WCALCUL1 + AREA_DE_WORK.FILLER_153.WCALCUL2;
            }


            /*" -3872- ADD WCALCULO TO WPARM01-AUX */
            AREA_DE_WORK.WPARM01_AUX.Value = AREA_DE_WORK.WPARM01_AUX + AREA_DE_WORK.WCALCULO;

            /*" -3873- COMPUTE WCALCULO = LPARM01-11 * 2 */
            AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.LPARM01X.LPARM01_R.LPARM01_11 * 2;

            /*" -3874- IF WCALCULO GREATER 9 */

            if (AREA_DE_WORK.WCALCULO > 9)
            {

                /*" -3876- COMPUTE WCALCULO = WCALCUL1 + WCALCUL2. */
                AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.FILLER_153.WCALCUL1 + AREA_DE_WORK.FILLER_153.WCALCUL2;
            }


            /*" -3878- ADD WCALCULO TO WPARM01-AUX */
            AREA_DE_WORK.WPARM01_AUX.Value = AREA_DE_WORK.WPARM01_AUX + AREA_DE_WORK.WCALCULO;

            /*" -3879- COMPUTE WCALCULO = LPARM01-10 * 1 */
            AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.LPARM01X.LPARM01_R.LPARM01_10 * 1;

            /*" -3880- IF WCALCULO GREATER 9 */

            if (AREA_DE_WORK.WCALCULO > 9)
            {

                /*" -3882- COMPUTE WCALCULO = WCALCUL1 + WCALCUL2. */
                AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.FILLER_153.WCALCUL1 + AREA_DE_WORK.FILLER_153.WCALCUL2;
            }


            /*" -3884- ADD WCALCULO TO WPARM01-AUX */
            AREA_DE_WORK.WPARM01_AUX.Value = AREA_DE_WORK.WPARM01_AUX + AREA_DE_WORK.WCALCULO;

            /*" -3885- COMPUTE WCALCULO = LPARM01-9 * 2 */
            AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.LPARM01X.LPARM01_R.LPARM01_9 * 2;

            /*" -3886- IF WCALCULO GREATER 9 */

            if (AREA_DE_WORK.WCALCULO > 9)
            {

                /*" -3888- COMPUTE WCALCULO = WCALCUL1 + WCALCUL2. */
                AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.FILLER_153.WCALCUL1 + AREA_DE_WORK.FILLER_153.WCALCUL2;
            }


            /*" -3890- ADD WCALCULO TO WPARM01-AUX */
            AREA_DE_WORK.WPARM01_AUX.Value = AREA_DE_WORK.WPARM01_AUX + AREA_DE_WORK.WCALCULO;

            /*" -3891- COMPUTE WCALCULO = LPARM01-8 * 1 */
            AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.LPARM01X.LPARM01_R.LPARM01_8 * 1;

            /*" -3892- IF WCALCULO GREATER 9 */

            if (AREA_DE_WORK.WCALCULO > 9)
            {

                /*" -3894- COMPUTE WCALCULO = WCALCUL1 + WCALCUL2. */
                AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.FILLER_153.WCALCUL1 + AREA_DE_WORK.FILLER_153.WCALCUL2;
            }


            /*" -3896- ADD WCALCULO TO WPARM01-AUX */
            AREA_DE_WORK.WPARM01_AUX.Value = AREA_DE_WORK.WPARM01_AUX + AREA_DE_WORK.WCALCULO;

            /*" -3897- COMPUTE WCALCULO = LPARM01-7 * 2 */
            AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.LPARM01X.LPARM01_R.LPARM01_7 * 2;

            /*" -3898- IF WCALCULO GREATER 9 */

            if (AREA_DE_WORK.WCALCULO > 9)
            {

                /*" -3900- COMPUTE WCALCULO = WCALCUL1 + WCALCUL2. */
                AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.FILLER_153.WCALCUL1 + AREA_DE_WORK.FILLER_153.WCALCUL2;
            }


            /*" -3902- ADD WCALCULO TO WPARM01-AUX */
            AREA_DE_WORK.WPARM01_AUX.Value = AREA_DE_WORK.WPARM01_AUX + AREA_DE_WORK.WCALCULO;

            /*" -3903- COMPUTE WCALCULO = LPARM01-6 * 1 */
            AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.LPARM01X.LPARM01_R.LPARM01_6 * 1;

            /*" -3904- IF WCALCULO GREATER 9 */

            if (AREA_DE_WORK.WCALCULO > 9)
            {

                /*" -3906- COMPUTE WCALCULO = WCALCUL1 + WCALCUL2. */
                AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.FILLER_153.WCALCUL1 + AREA_DE_WORK.FILLER_153.WCALCUL2;
            }


            /*" -3908- ADD WCALCULO TO WPARM01-AUX */
            AREA_DE_WORK.WPARM01_AUX.Value = AREA_DE_WORK.WPARM01_AUX + AREA_DE_WORK.WCALCULO;

            /*" -3909- COMPUTE WCALCULO = LPARM01-5 * 2 */
            AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.LPARM01X.LPARM01_R.LPARM01_5 * 2;

            /*" -3910- IF WCALCULO GREATER 9 */

            if (AREA_DE_WORK.WCALCULO > 9)
            {

                /*" -3912- COMPUTE WCALCULO = WCALCUL1 + WCALCUL2. */
                AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.FILLER_153.WCALCUL1 + AREA_DE_WORK.FILLER_153.WCALCUL2;
            }


            /*" -3914- ADD WCALCULO TO WPARM01-AUX */
            AREA_DE_WORK.WPARM01_AUX.Value = AREA_DE_WORK.WPARM01_AUX + AREA_DE_WORK.WCALCULO;

            /*" -3915- COMPUTE WCALCULO = LPARM01-4 * 1 */
            AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.LPARM01X.LPARM01_R.LPARM01_4 * 1;

            /*" -3916- IF WCALCULO GREATER 9 */

            if (AREA_DE_WORK.WCALCULO > 9)
            {

                /*" -3918- COMPUTE WCALCULO = WCALCUL1 + WCALCUL2. */
                AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.FILLER_153.WCALCUL1 + AREA_DE_WORK.FILLER_153.WCALCUL2;
            }


            /*" -3920- ADD WCALCULO TO WPARM01-AUX */
            AREA_DE_WORK.WPARM01_AUX.Value = AREA_DE_WORK.WPARM01_AUX + AREA_DE_WORK.WCALCULO;

            /*" -3921- COMPUTE WCALCULO = LPARM01-3 * 2 */
            AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.LPARM01X.LPARM01_R.LPARM01_3 * 2;

            /*" -3922- IF WCALCULO GREATER 9 */

            if (AREA_DE_WORK.WCALCULO > 9)
            {

                /*" -3924- COMPUTE WCALCULO = WCALCUL1 + WCALCUL2. */
                AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.FILLER_153.WCALCUL1 + AREA_DE_WORK.FILLER_153.WCALCUL2;
            }


            /*" -3926- ADD WCALCULO TO WPARM01-AUX */
            AREA_DE_WORK.WPARM01_AUX.Value = AREA_DE_WORK.WPARM01_AUX + AREA_DE_WORK.WCALCULO;

            /*" -3927- COMPUTE WCALCULO = LPARM01-2 * 1 */
            AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.LPARM01X.LPARM01_R.LPARM01_2 * 1;

            /*" -3928- IF WCALCULO GREATER 9 */

            if (AREA_DE_WORK.WCALCULO > 9)
            {

                /*" -3930- COMPUTE WCALCULO = WCALCUL1 + WCALCUL2. */
                AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.FILLER_153.WCALCUL1 + AREA_DE_WORK.FILLER_153.WCALCUL2;
            }


            /*" -3932- ADD WCALCULO TO WPARM01-AUX */
            AREA_DE_WORK.WPARM01_AUX.Value = AREA_DE_WORK.WPARM01_AUX + AREA_DE_WORK.WCALCULO;

            /*" -3933- COMPUTE WCALCULO = LPARM01-1 * 2 */
            AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.LPARM01X.LPARM01_R.LPARM01_1 * 2;

            /*" -3934- IF WCALCULO GREATER 9 */

            if (AREA_DE_WORK.WCALCULO > 9)
            {

                /*" -3936- COMPUTE WCALCULO = WCALCUL1 + WCALCUL2. */
                AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.FILLER_153.WCALCUL1 + AREA_DE_WORK.FILLER_153.WCALCUL2;
            }


            /*" -3938- ADD WCALCULO TO WPARM01-AUX */
            AREA_DE_WORK.WPARM01_AUX.Value = AREA_DE_WORK.WPARM01_AUX + AREA_DE_WORK.WCALCULO;

            /*" -3941- DIVIDE WPARM01-AUX BY 10 GIVING WQUOCIENTE REMAINDER WRESTO */
            _.Divide(AREA_DE_WORK.WPARM01_AUX, 10, AREA_DE_WORK.WQUOCIENTE, AREA_DE_WORK.WRESTO);

            /*" -3942- IF WRESTO EQUAL ZEROS */

            if (AREA_DE_WORK.WRESTO == 00)
            {

                /*" -3943- MOVE 0 TO LPARM03 */
                _.Move(0, AREA_DE_WORK.LPARM03);

                /*" -3944- ELSE */
            }
            else
            {


                /*" -3947- SUBTRACT WRESTO FROM 10 GIVING LPARM03. */
                AREA_DE_WORK.LPARM03.Value = 10 - AREA_DE_WORK.WRESTO;
            }


            /*" -3947- MOVE LPARM03 TO WK-DIGITO. */
            _.Move(AREA_DE_WORK.LPARM03, AREA_DE_WORK.WK_NUMERO_R.WK_DIGITO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-CALCULA-DIGITO-11-SECTION */
        private void R2500_00_CALCULA_DIGITO_11_SECTION()
        {
            /*" -3958- MOVE 'R2500-00-CALCULA-DIGITO-11' TO PARAGRAFO. */
            _.Move("R2500-00-CALCULA-DIGITO-11", PARAGRAFO);

            /*" -3959- MOVE W91-NUMERO TO LPARM91 */
            _.Move(AREA_DE_WORK.W91_NUMERO, AREA_DE_WORK.LPARM91X.LPARM91);

            /*" -3961- MOVE ZEROS TO WPARM91-AUX */
            _.Move(0, AREA_DE_WORK.WPARM91_AUX);

            /*" -4003- COMPUTE WPARM91-AUX = LPARM91-1 * 4 + LPARM91-2 * 3 + LPARM91-3 * 2 + LPARM91-4 * 9 + LPARM91-5 * 8 + LPARM91-6 * 7 + LPARM91-7 * 6 + LPARM91-8 * 5 + LPARM91-9 * 4 + LPARM91-10 * 3 + LPARM91-11 * 2 + LPARM91-12 * 9 + LPARM91-13 * 8 + LPARM91-14 * 7 + LPARM91-15 * 6 + LPARM91-16 * 5 + LPARM91-17 * 4 + LPARM91-18 * 3 + LPARM91-19 * 2 + LPARM91-20 * 9 + LPARM91-21 * 8 + LPARM91-22 * 7 + LPARM91-23 * 6 + LPARM91-24 * 5 + LPARM91-25 * 4 + LPARM91-26 * 3 + LPARM91-27 * 2 + LPARM91-28 * 9 + LPARM91-29 * 8 + LPARM91-30 * 7 + LPARM91-31 * 6 + LPARM91-32 * 5 + LPARM91-33 * 4 + LPARM91-34 * 3 + LPARM91-35 * 2 + LPARM91-36 * 9 + LPARM91-37 * 8 + LPARM91-38 * 7 + LPARM91-39 * 6 + LPARM91-40 * 5 + LPARM91-41 * 4 + LPARM91-42 * 3 + LPARM91-43 * 2. */
            AREA_DE_WORK.WPARM91_AUX.Value = AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_1 * 4 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_2 * 3 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_3 * 2 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_4 * 9 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_5 * 8 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_6 * 7 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_7 * 6 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_8 * 5 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_9 * 4 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_10 * 3 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_11 * 2 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_12 * 9 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_13 * 8 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_14 * 7 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_15 * 6 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_16 * 5 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_17 * 4 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_18 * 3 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_19 * 2 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_20 * 9 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_21 * 8 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_22 * 7 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_23 * 6 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_24 * 5 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_25 * 4 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_26 * 3 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_27 * 2 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_28 * 9 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_29 * 8 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_30 * 7 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_31 * 6 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_32 * 5 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_33 * 4 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_34 * 3 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_35 * 2 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_36 * 9 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_37 * 8 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_38 * 7 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_39 * 6 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_40 * 5 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_41 * 4 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_42 * 3 + AREA_DE_WORK.LPARM91X.LPARM91_R.LPARM91_43 * 2;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R2600-00-UPDATE-V0HISTCOBVA-SECTION */
        private void R2600_00_UPDATE_V0HISTCOBVA_SECTION()
        {
            /*" -4016- MOVE 'R2600-00-UPDATE-V0HISTCOBVA' TO PARAGRAFO. */
            _.Move("R2600-00-UPDATE-V0HISTCOBVA", PARAGRAFO);

            /*" -4018- MOVE '260' TO WNR-EXEC-SQL. */
            _.Move("260", WABEND.WNR_EXEC_SQL);

            /*" -4024- PERFORM R2600_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1 */

            R2600_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1();

            /*" -4027- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4028- DISPLAY 'R2600 - NAO ENCONTRADO NA V0HISTCOBVA' */
                _.Display($"R2600 - NAO ENCONTRADO NA V0HISTCOBVA");

                /*" -4029- DISPLAY 'CERTIFICADO => ' WHOST-NRCERTIF */
                _.Display($"CERTIFICADO => {WHOST_NRCERTIF}");

                /*" -4030- DISPLAY 'PARCELA     => ' WHOST-NRPARCEL */
                _.Display($"PARCELA     => {WHOST_NRPARCEL}");

                /*" -4031- DISPLAY 'TITULO      => ' WHOST-NRTIT */
                _.Display($"TITULO      => {WHOST_NRTIT}");

                /*" -4031- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2600-00-UPDATE-V0HISTCOBVA-DB-UPDATE-1 */
        public void R2600_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1()
        {
            /*" -4024- EXEC SQL UPDATE SEGUROS.V0HISTCOBVA SET SITUACAO = '0' WHERE NRCERTIF = :WHOST-NRCERTIF AND NRPARCEL = :WHOST-NRPARCEL AND NRTIT = :WHOST-NRTIT END-EXEC. */

            var r2600_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1_Update1 = new R2600_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1_Update1()
            {
                WHOST_NRCERTIF = WHOST_NRCERTIF.ToString(),
                WHOST_NRPARCEL = WHOST_NRPARCEL.ToString(),
                WHOST_NRTIT = WHOST_NRTIT.ToString(),
            };

            R2600_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1_Update1.Execute(r2600_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2600_99_SAIDA*/

        [StopWatch]
        /*" R2650-00-BUSCA-FONTE-SECTION */
        private void R2650_00_BUSCA_FONTE_SECTION()
        {
            /*" -4043- MOVE '2650' TO WNR-EXEC-SQL */
            _.Move("2650", WABEND.WNR_EXEC_SQL);

            /*" -4043- MOVE ZEROS TO IDX-IND1. */
            _.Move(0, AREA_DE_WORK.IDX_IND1);

            /*" -0- FLUXCONTROL_PERFORM R2650_LOOP */

            R2650_LOOP();

        }

        [StopWatch]
        /*" R2650-LOOP */
        private void R2650_LOOP(bool isPerform = false)
        {
            /*" -4049- ADD 1 TO IDX-IND1. */
            AREA_DE_WORK.IDX_IND1.Value = AREA_DE_WORK.IDX_IND1 + 1;

            /*" -4050- IF IDX-IND1 > 19 */

            if (AREA_DE_WORK.IDX_IND1 > 19)
            {

                /*" -4052- GO TO R2650-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2650_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4053- IF SVA-FONTE = TAB-FONTE (IDX-IND1) */

            if (REG_SVG0267B.SVA_FONTE == TAB_FILIAL.FILLER_177[AREA_DE_WORK.IDX_IND1].TAB_FONTE)
            {

                /*" -4054- IF SVA-FONTE = 10 */

                if (REG_SVG0267B.SVA_FONTE == 10)
                {

                    /*" -4056- MOVE SPACES TO LE06-REMETENTE */
                    _.Move("", AREA_DE_WORK.LC11_LINHA11.LE06_REMETENTE_G.LE06_REMETENTE);

                    /*" -4058- MOVE 'MATRIZ ' TO LE06-REMETENTE-S */
                    _.Move("MATRIZ ", AREA_DE_WORK.LC11_LINHA11.LE06_REMETENTE_G.LE06_REMETENTE_S);

                    /*" -4059- ELSE */
                }
                else
                {


                    /*" -4061- MOVE TAB-NOMEFTE (IDX-IND1) TO LE06-REMETENTE */
                    _.Move(TAB_FILIAL.FILLER_177[AREA_DE_WORK.IDX_IND1].TAB_NOMEFTE, AREA_DE_WORK.LC11_LINHA11.LE06_REMETENTE_G.LE06_REMETENTE);

                    /*" -4063- MOVE 'FILIAL ' TO LE06-REMETENTE-S */
                    _.Move("FILIAL ", AREA_DE_WORK.LC11_LINHA11.LE06_REMETENTE_G.LE06_REMETENTE_S);

                    /*" -4064- END-IF */
                }


                /*" -4066- MOVE TAB-ENDERFTE(IDX-IND1) TO LE07-ENDERECO */
                _.Move(TAB_FILIAL.FILLER_177[AREA_DE_WORK.IDX_IND1].TAB_ENDERFTE, AREA_DE_WORK.LC11_LINHA11.LE07_ENDERECO);

                /*" -4068- MOVE TAB-BAIRRO (IDX-IND1) TO LE08-BAIRRO */
                _.Move(TAB_FILIAL.FILLER_177[AREA_DE_WORK.IDX_IND1].TAB_BAIRRO, AREA_DE_WORK.LC11_LINHA11.LE08_BAIRRO);

                /*" -4070- MOVE TAB-CIDADE (IDX-IND1) TO LE08-CIDADE */
                _.Move(TAB_FILIAL.FILLER_177[AREA_DE_WORK.IDX_IND1].TAB_CIDADE, AREA_DE_WORK.LC11_LINHA11.LE08_CIDADE);

                /*" -4072- MOVE TAB-UF (IDX-IND1) TO LE08-UF */
                _.Move(TAB_FILIAL.FILLER_177[AREA_DE_WORK.IDX_IND1].TAB_UF, AREA_DE_WORK.LC11_LINHA11.LE08_UF);

                /*" -4074- MOVE TAB-CEP (IDX-IND1) TO DEST-NUM-CEP */
                _.Move(TAB_FILIAL.FILLER_177[AREA_DE_WORK.IDX_IND1].TAB_CEP, AREA_DE_WORK.DEST_NUM_CEP);

                /*" -4075- MOVE DEST-CEP TO LE09-CEP */
                _.Move(AREA_DE_WORK.DEST_NUM_CEP.DEST_CEP, AREA_DE_WORK.LC11_LINHA11.LE09_CEP);

                /*" -4076- MOVE DEST-CEP-COMPL TO LE09-CEP-COMPL */
                _.Move(AREA_DE_WORK.DEST_NUM_CEP.DEST_CEP_COMPL, AREA_DE_WORK.LC11_LINHA11.LE09_CEP_COMPL);

                /*" -4077- MOVE ALL '@' TO LE09-CIF */
                _.MoveAll("@", AREA_DE_WORK.LC11_LINHA11.LE09_CIF);

                /*" -4078- MOVE ALL '#' TO LE09-POSTNET */
                _.MoveAll("#", AREA_DE_WORK.LC11_LINHA11.LE09_POSTNET);

                /*" -4080- GO TO R2650-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2650_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4080- GO TO R2650-LOOP. */
            new Task(() => R2650_LOOP()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2650_99_SAIDA*/

        [StopWatch]
        /*" R2651-00-BUSCA-ESTIPULANTE-SECTION */
        private void R2651_00_BUSCA_ESTIPULANTE_SECTION()
        {
            /*" -4090- MOVE 'R2651-00-BUSCA-EST' TO PARAGRAFO. */
            _.Move("R2651-00-BUSCA-EST", PARAGRAFO);

            /*" -4092- MOVE '2651' TO WNR-EXEC-SQL */
            _.Move("2651", WABEND.WNR_EXEC_SQL);

            /*" -4101- PERFORM R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_1 */

            R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_1();

            /*" -4104- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4105- DISPLAY 'R2651 - NAO ENCONTRADO NA V0SUBGRUPO ' */
                _.Display($"R2651 - NAO ENCONTRADO NA V0SUBGRUPO ");

                /*" -4106- DISPLAY 'APOLICE     => ' WHOST-NRAPOLICE */
                _.Display($"APOLICE     => {WHOST_NRAPOLICE}");

                /*" -4109- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4111- MOVE '265A' TO WNR-EXEC-SQL. */
            _.Move("265A", WABEND.WNR_EXEC_SQL);

            /*" -4118- PERFORM R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_2 */

            R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_2();

            /*" -4121- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4122- DISPLAY 'R2651 - PROBLEMAS NO ACESSO A V0CLIENTE  ' */
                _.Display($"R2651 - PROBLEMAS NO ACESSO A V0CLIENTE  ");

                /*" -4123- DISPLAY 'CLIENTE           => ' V0SUBG-COD-CLIENTE */
                _.Display($"CLIENTE           => {V0SUBG_COD_CLIENTE}");

                /*" -4125- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4127- MOVE '265B' TO WNR-EXEC-SQL. */
            _.Move("265B", WABEND.WNR_EXEC_SQL);

            /*" -4141- PERFORM R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_3 */

            R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_3();

            /*" -4144- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4145- DISPLAY 'R2651 - PROBLEMAS NO ACESSO A V0ENDERECOS' */
                _.Display($"R2651 - PROBLEMAS NO ACESSO A V0ENDERECOS");

                /*" -4146- DISPLAY 'CLIENTE           => ' V0SUBG-COD-CLIENTE */
                _.Display($"CLIENTE           => {V0SUBG_COD_CLIENTE}");

                /*" -4146- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2651-00-BUSCA-ESTIPULANTE-DB-SELECT-1 */
        public void R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_1()
        {
            /*" -4101- EXEC SQL SELECT COD_CLIENTE, OCORR_ENDERECO INTO :V0SUBG-COD-CLIENTE, :V0SUBG-OCOREND FROM SEGUROS.V0SUBGRUPO WHERE NUM_APOLICE = :WHOST-NRAPOLICE AND COD_SUBGRUPO = 0 WITH UR END-EXEC. */

            var r2651_00_BUSCA_ESTIPULANTE_DB_SELECT_1_Query1 = new R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_1_Query1()
            {
                WHOST_NRAPOLICE = WHOST_NRAPOLICE.ToString(),
            };

            var executed_1 = R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_1_Query1.Execute(r2651_00_BUSCA_ESTIPULANTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SUBG_COD_CLIENTE, V0SUBG_COD_CLIENTE);
                _.Move(executed_1.V0SUBG_OCOREND, V0SUBG_OCOREND);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2651_99_SAIDA*/

        [StopWatch]
        /*" R2651-00-BUSCA-ESTIPULANTE-DB-SELECT-2 */
        public void R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_2()
        {
            /*" -4118- EXEC SQL SELECT NOME_RAZAO, CGCCPF INTO :V0CLIE-NOME-RAZAO-E, :V0CLIE-CNPJ-E FROM SEGUROS.V0CLIENTE WHERE COD_CLIENTE = :V0SUBG-COD-CLIENTE END-EXEC. */

            var r2651_00_BUSCA_ESTIPULANTE_DB_SELECT_2_Query1 = new R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_2_Query1()
            {
                V0SUBG_COD_CLIENTE = V0SUBG_COD_CLIENTE.ToString(),
            };

            var executed_1 = R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_2_Query1.Execute(r2651_00_BUSCA_ESTIPULANTE_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CLIE_NOME_RAZAO_E, V0CLIE_NOME_RAZAO_E);
                _.Move(executed_1.V0CLIE_CNPJ_E, V0CLIE_CNPJ_E);
            }


        }

        [StopWatch]
        /*" R2652-00-BUSCA-PARCELA-SECTION */
        private void R2652_00_BUSCA_PARCELA_SECTION()
        {
            /*" -4157- MOVE 'R2652-00-BUSCA-PAR' TO PARAGRAFO. */
            _.Move("R2652-00-BUSCA-PAR", PARAGRAFO);

            /*" -4159- MOVE '2652' TO WNR-EXEC-SQL */
            _.Move("2652", WABEND.WNR_EXEC_SQL);

            /*" -4160- MOVE SVA-NRCERTIF TO V0PARC-NRCERTIF. */
            _.Move(REG_SVG0267B.SVA_NRCERTIF, V0PARC_NRCERTIF);

            /*" -4162- MOVE SVA-NRPARCEL TO V0PARC-NRPARCEL. */
            _.Move(REG_SVG0267B.SVA_NRPARCEL, V0PARC_NRPARCEL);

            /*" -4168- PERFORM R2652_00_BUSCA_PARCELA_DB_SELECT_1 */

            R2652_00_BUSCA_PARCELA_DB_SELECT_1();

            /*" -4171- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4172- DISPLAY 'R2652 - NAO ENCONTRADO NA V0PARCELVA ' */
                _.Display($"R2652 - NAO ENCONTRADO NA V0PARCELVA ");

                /*" -4173- DISPLAY 'CERTIFICADO => ' V0PARC-NRCERTIF */
                _.Display($"CERTIFICADO => {V0PARC_NRCERTIF}");

                /*" -4174- DISPLAY 'PARCELA     => ' V0PARC-NRPARCEL */
                _.Display($"PARCELA     => {V0PARC_NRPARCEL}");

                /*" -4177- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4180- MOVE '265F' TO WNR-EXEC-SQL. */
            _.Move("265F", WABEND.WNR_EXEC_SQL);

            /*" -4193- PERFORM R2652_00_BUSCA_PARCELA_DB_SELECT_2 */

            R2652_00_BUSCA_PARCELA_DB_SELECT_2();

            /*" -4196- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4197- DISPLAY 'R2652 - PROBLEMAS NO ACESSO A V0COBERPROPVA ' */
                _.Display($"R2652 - PROBLEMAS NO ACESSO A V0COBERPROPVA ");

                /*" -4198- DISPLAY 'CERTIFICADO       => ' V0PARC-NRCERTIF */
                _.Display($"CERTIFICADO       => {V0PARC_NRCERTIF}");

                /*" -4199- DISPLAY 'PARCELA           => ' V0PARC-NRPARCEL */
                _.Display($"PARCELA           => {V0PARC_NRPARCEL}");

                /*" -4200- DISPLAY 'DTVENCTO          => ' V0HIST-DTVENCTO */
                _.Display($"DTVENCTO          => {V0HIST_DTVENCTO}");

                /*" -4201- DISPLAY 'VENCT ORIGINAL    => ' V0PARC-DTVENCTO-ORIG */
                _.Display($"VENCT ORIGINAL    => {V0PARC_DTVENCTO_ORIG}");

                /*" -4203- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4205- MOVE '265G' TO WNR-EXEC-SQL. */
            _.Move("265G", WABEND.WNR_EXEC_SQL);

            /*" -4206- IF SVA-CODPRODU = 9313 OR 7701 */

            if (REG_SVG0267B.SVA_CODPRODU.In("9313", "7701"))
            {

                /*" -4211- STRING SVA-DTVENCTO-ORIG(1:8) SVA-DTQITBCO(9:2) DELIMITED BY SIZE INTO V0COBP-DTINIVIG-PARC END-STRING */
                #region STRING
                var spl3 = REG_SVG0267B.SVA_DTVENCTO_ORIG.Substring(1, 8).GetMoveValues();
                var spl4 = REG_SVG0267B.SVA_DTQITBCO.Substring(9, 2).GetMoveValues();
                var results5 = spl3 + spl4;
                _.Move(results5, V0COBP_DTINIVIG_PARC);
                #endregion

                /*" -4212- IF V0COBP-DTINIVIG-PARC >= SVA-DTVENCTO-ORIG */

                if (V0COBP_DTINIVIG_PARC >= REG_SVG0267B.SVA_DTVENCTO_ORIG)
                {

                    /*" -4214- PERFORM R2655-00-CALCULA-INIVIGENCIA UNTIL V0COBP-DTINIVIG-PARC < SVA-DTVENCTO-ORIG */

                    while (!(V0COBP_DTINIVIG_PARC < REG_SVG0267B.SVA_DTVENCTO_ORIG))
                    {

                        R2655_00_CALCULA_INIVIGENCIA_SECTION();
                    }

                    /*" -4215- END-IF */
                }


                /*" -4216- ELSE */
            }
            else
            {


                /*" -4217- IF (WHOST-NRAPOLICE EQUAL 109300002554) */

                if ((WHOST_NRAPOLICE == 109300002554))
                {

                    /*" -4229- PERFORM R2652_00_BUSCA_PARCELA_DB_SELECT_3 */

                    R2652_00_BUSCA_PARCELA_DB_SELECT_3();

                    /*" -4232- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -4233- DISPLAY 'R2652-ERRO-CYRELA SEM VG-VIGENCIA-FATURA' */
                        _.Display($"R2652-ERRO-CYRELA SEM VG-VIGENCIA-FATURA");

                        /*" -4234- DISPLAY 'CERTIFICADO = ' V0PARC-NRCERTIF */
                        _.Display($"CERTIFICADO = {V0PARC_NRCERTIF}");

                        /*" -4235- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -4236- END-IF */
                    }


                    /*" -4237- ELSE */
                }
                else
                {


                    /*" -4238- MOVE V0PARC-DTVENCTO-ORIG TO WS-DTCALC-PARC */
                    _.Move(V0PARC_DTVENCTO_ORIG, WS_DTCALC_PARC);

                    /*" -4240- MOVE V0COBP-DTINIVIG-PARC TO WS-DTINIVIG-PARC */
                    _.Move(V0COBP_DTINIVIG_PARC, WS_DTINIVIG_PARC);

                    /*" -4242- MOVE 'NAO' TO WS-FLAG-CALC-PARC */
                    _.Move("NAO", WS_FLAG_CALC_PARC);

                    /*" -4245- PERFORM R2657-00-CALCULA-TERVIGENCIA UNTIL WS-FLAG-CALC-PARC EQUAL 'SIM' */

                    while (!(WS_FLAG_CALC_PARC == "SIM"))
                    {

                        R2657_00_CALCULA_TERVIGENCIA_SECTION();
                    }

                    /*" -4246- MOVE WS-DTINIVIG-PARC TO V0COBP-DTINIVIG-PARC */
                    _.Move(WS_DTINIVIG_PARC, V0COBP_DTINIVIG_PARC);

                    /*" -4247- END-IF */
                }


                /*" -4250- END-IF. */
            }


            /*" -4252- MOVE '265H' TO WNR-EXEC-SQL. */
            _.Move("265H", WABEND.WNR_EXEC_SQL);

            /*" -4259- PERFORM R2652_00_BUSCA_PARCELA_DB_SELECT_4 */

            R2652_00_BUSCA_PARCELA_DB_SELECT_4();

            /*" -4262- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4263- DISPLAY 'R2652 - PROBLEMAS NO ACESSO A V1RAMOIND     ' */
                _.Display($"R2652 - PROBLEMAS NO ACESSO A V1RAMOIND     ");

                /*" -4264- DISPLAY 'RAMO              =>   93' */
                _.Display($"RAMO              =>   93");

                /*" -4265- DISPLAY 'DTVENCTO          => ' V0PARC-DTVENCTO-ORIG */
                _.Display($"DTVENCTO          => {V0PARC_DTVENCTO_ORIG}");

                /*" -4267- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4267- COMPUTE SQL-PCIOF = 1 + (SQL-PCIOF / 100). */
            SQL_PCIOF.Value = 1 + (SQL_PCIOF / 100f);

        }

        [StopWatch]
        /*" R2652-00-BUSCA-PARCELA-DB-SELECT-1 */
        public void R2652_00_BUSCA_PARCELA_DB_SELECT_1()
        {
            /*" -4168- EXEC SQL SELECT DTVENCTO INTO :V0PARC-DTVENCTO-ORIG FROM SEGUROS.V0PARCELVA WHERE NRCERTIF = :V0PARC-NRCERTIF AND NRPARCEL = :V0PARC-NRPARCEL END-EXEC. */

            var r2652_00_BUSCA_PARCELA_DB_SELECT_1_Query1 = new R2652_00_BUSCA_PARCELA_DB_SELECT_1_Query1()
            {
                V0PARC_NRCERTIF = V0PARC_NRCERTIF.ToString(),
                V0PARC_NRPARCEL = V0PARC_NRPARCEL.ToString(),
            };

            var executed_1 = R2652_00_BUSCA_PARCELA_DB_SELECT_1_Query1.Execute(r2652_00_BUSCA_PARCELA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PARC_DTVENCTO_ORIG, V0PARC_DTVENCTO_ORIG);
            }


        }

        [StopWatch]
        /*" R2651-00-BUSCA-ESTIPULANTE-DB-SELECT-3 */
        public void R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_3()
        {
            /*" -4141- EXEC SQL SELECT ENDERECO, BAIRRO, CIDADE, SIGLA_UF, CEP INTO :V0ENDE-ENDERECO-E, :V0ENDE-BAIRRO-E, :V0ENDE-CIDADE-E, :V0ENDE-UF-E, :V0ENDE-CEP-E FROM SEGUROS.V0ENDERECOS WHERE COD_CLIENTE = :V0SUBG-COD-CLIENTE AND OCORR_ENDERECO = :V0SUBG-OCOREND END-EXEC. */

            var r2651_00_BUSCA_ESTIPULANTE_DB_SELECT_3_Query1 = new R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_3_Query1()
            {
                V0SUBG_COD_CLIENTE = V0SUBG_COD_CLIENTE.ToString(),
                V0SUBG_OCOREND = V0SUBG_OCOREND.ToString(),
            };

            var executed_1 = R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_3_Query1.Execute(r2651_00_BUSCA_ESTIPULANTE_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ENDE_ENDERECO_E, V0ENDE_ENDERECO_E);
                _.Move(executed_1.V0ENDE_BAIRRO_E, V0ENDE_BAIRRO_E);
                _.Move(executed_1.V0ENDE_CIDADE_E, V0ENDE_CIDADE_E);
                _.Move(executed_1.V0ENDE_UF_E, V0ENDE_UF_E);
                _.Move(executed_1.V0ENDE_CEP_E, V0ENDE_CEP_E);
            }


        }

        [StopWatch]
        /*" R2652-00-BUSCA-PARCELA-DB-SELECT-2 */
        public void R2652_00_BUSCA_PARCELA_DB_SELECT_2()
        {
            /*" -4193- EXEC SQL SELECT DTINIVIG, QUANT_VIDAS, IMPSEGUR, OCORHIST INTO :V0COBP-DTINIVIG-PARC, :V0COBP-QUANT-VIDAS, :V0COBP-IMPSEGUR, :V0COBP-OCORHIST FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :V0PARC-NRCERTIF AND DTINIVIG <= :V0PARC-DTVENCTO-ORIG AND DTTERVIG >= :V0PARC-DTVENCTO-ORIG END-EXEC. */

            var r2652_00_BUSCA_PARCELA_DB_SELECT_2_Query1 = new R2652_00_BUSCA_PARCELA_DB_SELECT_2_Query1()
            {
                V0PARC_DTVENCTO_ORIG = V0PARC_DTVENCTO_ORIG.ToString(),
                V0PARC_NRCERTIF = V0PARC_NRCERTIF.ToString(),
            };

            var executed_1 = R2652_00_BUSCA_PARCELA_DB_SELECT_2_Query1.Execute(r2652_00_BUSCA_PARCELA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBP_DTINIVIG_PARC, V0COBP_DTINIVIG_PARC);
                _.Move(executed_1.V0COBP_QUANT_VIDAS, V0COBP_QUANT_VIDAS);
                _.Move(executed_1.V0COBP_IMPSEGUR, V0COBP_IMPSEGUR);
                _.Move(executed_1.V0COBP_OCORHIST, V0COBP_OCORHIST);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2652_99_SAIDA*/

        [StopWatch]
        /*" R2652-00-BUSCA-PARCELA-DB-SELECT-3 */
        public void R2652_00_BUSCA_PARCELA_DB_SELECT_3()
        {
            /*" -4229- EXEC SQL SELECT DTA_INI_FATURA INTO :V0COBP-DTINIVIG-PARC FROM SEGUROS.VG_VIGENCIA_FATURA WHERE NUM_APOLICE = :WHOST-NRAPOLICE AND COD_SUBGRUPO = 0 AND SEQ_FATURAMENTO = (SELECT MAX(T1.SEQ_FATURAMENTO) FROM SEGUROS.VG_VIGENCIA_FATURA T1 WHERE T1.NUM_APOLICE = :WHOST-NRAPOLICE AND T1.COD_SUBGRUPO = 0 AND T1.IND_PROCESSAMENTO <> 'NP' ) END-EXEC */

            var r2652_00_BUSCA_PARCELA_DB_SELECT_3_Query1 = new R2652_00_BUSCA_PARCELA_DB_SELECT_3_Query1()
            {
                WHOST_NRAPOLICE = WHOST_NRAPOLICE.ToString(),
            };

            var executed_1 = R2652_00_BUSCA_PARCELA_DB_SELECT_3_Query1.Execute(r2652_00_BUSCA_PARCELA_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBP_DTINIVIG_PARC, V0COBP_DTINIVIG_PARC);
            }


        }

        [StopWatch]
        /*" R2655-00-CALCULA-INIVIGENCIA-SECTION */
        private void R2655_00_CALCULA_INIVIGENCIA_SECTION()
        {
            /*" -4276- MOVE 'R2655-00-CALCULA  ' TO PARAGRAFO. */
            _.Move("R2655-00-CALCULA  ", PARAGRAFO);

            /*" -4278- MOVE '265I' TO WNR-EXEC-SQL. */
            _.Move("265I", WABEND.WNR_EXEC_SQL);

            /*" -4279- IF (V0OPCP-PERIPGTO <= ZEROS) */

            if ((V0OPCP_PERIPGTO <= 00))
            {

                /*" -4280- MOVE 1 TO V0OPCP-PERIPGTO */
                _.Move(1, V0OPCP_PERIPGTO);

                /*" -4282- END-IF */
            }


            /*" -4289- PERFORM R2655_00_CALCULA_INIVIGENCIA_DB_SELECT_1 */

            R2655_00_CALCULA_INIVIGENCIA_DB_SELECT_1();

            /*" -4292- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4293- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4294- END-IF. */
            }


        }

        [StopWatch]
        /*" R2655-00-CALCULA-INIVIGENCIA-DB-SELECT-1 */
        public void R2655_00_CALCULA_INIVIGENCIA_DB_SELECT_1()
        {
            /*" -4289- EXEC SQL SELECT DATE(:V0COBP-DTINIVIG-PARC) - (:V0OPCP-PERIPGTO) MONTHS INTO :V0COBP-DTINIVIG-PARC FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VG' WITH UR END-EXEC */

            var r2655_00_CALCULA_INIVIGENCIA_DB_SELECT_1_Query1 = new R2655_00_CALCULA_INIVIGENCIA_DB_SELECT_1_Query1()
            {
                V0COBP_DTINIVIG_PARC = V0COBP_DTINIVIG_PARC.ToString(),
                V0OPCP_PERIPGTO = V0OPCP_PERIPGTO.ToString(),
            };

            var executed_1 = R2655_00_CALCULA_INIVIGENCIA_DB_SELECT_1_Query1.Execute(r2655_00_CALCULA_INIVIGENCIA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBP_DTINIVIG_PARC, V0COBP_DTINIVIG_PARC);
            }


        }

        [StopWatch]
        /*" R2652-00-BUSCA-PARCELA-DB-SELECT-4 */
        public void R2652_00_BUSCA_PARCELA_DB_SELECT_4()
        {
            /*" -4259- EXEC SQL SELECT PCIOF INTO :SQL-PCIOF FROM SEGUROS.V1RAMOIND WHERE RAMO = 93 AND DTINIVIG <= :V0PARC-DTVENCTO-ORIG AND DTTERVIG >= :V0PARC-DTVENCTO-ORIG END-EXEC. */

            var r2652_00_BUSCA_PARCELA_DB_SELECT_4_Query1 = new R2652_00_BUSCA_PARCELA_DB_SELECT_4_Query1()
            {
                V0PARC_DTVENCTO_ORIG = V0PARC_DTVENCTO_ORIG.ToString(),
            };

            var executed_1 = R2652_00_BUSCA_PARCELA_DB_SELECT_4_Query1.Execute(r2652_00_BUSCA_PARCELA_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SQL_PCIOF, SQL_PCIOF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2655_99_SAIDA*/

        [StopWatch]
        /*" R2657-00-CALCULA-TERVIGENCIA-SECTION */
        private void R2657_00_CALCULA_TERVIGENCIA_SECTION()
        {
            /*" -4302- MOVE 'R2657-00-CALCULA-T' TO PARAGRAFO. */
            _.Move("R2657-00-CALCULA-T", PARAGRAFO);

            /*" -4304- MOVE '267I' TO WNR-EXEC-SQL. */
            _.Move("267I", WABEND.WNR_EXEC_SQL);

            /*" -4305- IF (V0OPCP-PERIPGTO <= ZEROS) */

            if ((V0OPCP_PERIPGTO <= 00))
            {

                /*" -4306- MOVE 1 TO V0OPCP-PERIPGTO */
                _.Move(1, V0OPCP_PERIPGTO);

                /*" -4308- END-IF */
            }


            /*" -4309- IF (V0OPCP-PERIPGTO > 12) */

            if ((V0OPCP_PERIPGTO > 12))
            {

                /*" -4310- MOVE 12 TO V0OPCP-PERIPGTO */
                _.Move(12, V0OPCP_PERIPGTO);

                /*" -4312- END-IF */
            }


            /*" -4324- PERFORM R2657_00_CALCULA_TERVIGENCIA_DB_SELECT_1 */

            R2657_00_CALCULA_TERVIGENCIA_DB_SELECT_1();

            /*" -4327- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4330- DISPLAY 'ERRO CALCULO TERMINO VIGENCIA ' WS-DTINIVIG-PARC ' - ' V0OPCP-PERIPGTO ' - ' WS-DTCALC-PARC */

                $"ERRO CALCULO TERMINO VIGENCIA {WS_DTINIVIG_PARC} - {V0OPCP_PERIPGTO} - {WS_DTCALC_PARC}"
                .Display();

                /*" -4331- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4333- END-IF. */
            }


            /*" -4334- IF (WS-QTD-DIAS-PARC IS NEGATIVE) */

            if ((WS_QTD_DIAS_PARC < 0))
            {

                /*" -4335- MOVE 'NAO' TO WS-FLAG-CALC-PARC */
                _.Move("NAO", WS_FLAG_CALC_PARC);

                /*" -4336- MOVE WS-DTTERVIG-PARC TO WS-DTINIVIG-PARC */
                _.Move(WS_DTTERVIG_PARC, WS_DTINIVIG_PARC);

                /*" -4337- ELSE */
            }
            else
            {


                /*" -4338- MOVE 'SIM' TO WS-FLAG-CALC-PARC */
                _.Move("SIM", WS_FLAG_CALC_PARC);

                /*" -4339- END-IF. */
            }


        }

        [StopWatch]
        /*" R2657-00-CALCULA-TERVIGENCIA-DB-SELECT-1 */
        public void R2657_00_CALCULA_TERVIGENCIA_DB_SELECT_1()
        {
            /*" -4324- EXEC SQL SELECT DATE(:WS-DTINIVIG-PARC) + (:V0OPCP-PERIPGTO) MONTHS, DATE(:WS-DTINIVIG-PARC) + (:V0OPCP-PERIPGTO) MONTHS - 1 DAYS - DATE(:WS-DTCALC-PARC) INTO :WS-DTTERVIG-PARC, :WS-QTD-DIAS-PARC FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VG' WITH UR END-EXEC */

            var r2657_00_CALCULA_TERVIGENCIA_DB_SELECT_1_Query1 = new R2657_00_CALCULA_TERVIGENCIA_DB_SELECT_1_Query1()
            {
                WS_DTINIVIG_PARC = WS_DTINIVIG_PARC.ToString(),
                V0OPCP_PERIPGTO = V0OPCP_PERIPGTO.ToString(),
                WS_DTCALC_PARC = WS_DTCALC_PARC.ToString(),
            };

            var executed_1 = R2657_00_CALCULA_TERVIGENCIA_DB_SELECT_1_Query1.Execute(r2657_00_CALCULA_TERVIGENCIA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_DTTERVIG_PARC, WS_DTTERVIG_PARC);
                _.Move(executed_1.WS_QTD_DIAS_PARC, WS_QTD_DIAS_PARC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2657_99_SAIDA*/

        [StopWatch]
        /*" R2800-00-SELECT-V0CEDENTE-SECTION */
        private void R2800_00_SELECT_V0CEDENTE_SECTION()
        {
            /*" -4350- MOVE 'R2800-00-SELECT-V0CEDENTE' TO PARAGRAFO. */
            _.Move("R2800-00-SELECT-V0CEDENTE", PARAGRAFO);

            /*" -4352- MOVE '280' TO WNR-EXEC-SQL. */
            _.Move("280", WABEND.WNR_EXEC_SQL);

            /*" -4354- MOVE SVA-CODCDT TO V0PROD-CODCDT. */
            _.Move(REG_SVG0267B.SVA_CODCDT, V0PROD_CODCDT);

            /*" -4367- PERFORM R2800_00_SELECT_V0CEDENTE_DB_SELECT_1 */

            R2800_00_SELECT_V0CEDENTE_DB_SELECT_1();

            /*" -4370- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4371- DISPLAY 'R2800 - PROBLEMAS NO ACESSO A V0CEDENTE' */
                _.Display($"R2800 - PROBLEMAS NO ACESSO A V0CEDENTE");

                /*" -4374- DISPLAY 'CODCDT      ' V0PROD-CODCDT 'NUM_APOLICE ' WHOST-NRAPOLICE 'CODSUBES    ' WHOST-CODSUBES */

                $"CODCDT      {V0PROD_CODCDT}NUM_APOLICE {WHOST_NRAPOLICE}CODSUBES    {WHOST_CODSUBES}"
                .Display();

                /*" -4374- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2800-00-SELECT-V0CEDENTE-DB-SELECT-1 */
        public void R2800_00_SELECT_V0CEDENTE_DB_SELECT_1()
        {
            /*" -4367- EXEC SQL SELECT NOMCDT, COD_AGENCIA, OPERACAO_CONTA, NUM_CONTA, DIG_CONTA INTO :V0CEDE-NOMECED, :V0CEDE-AGENCIA, :V0CEDE-OPERACAO, :V0CEDE-CONTA, :V0CEDE-DIGCC FROM SEGUROS.V0CEDENTE WHERE CODCDT = :V0PROD-CODCDT END-EXEC. */

            var r2800_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1 = new R2800_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1()
            {
                V0PROD_CODCDT = V0PROD_CODCDT.ToString(),
            };

            var executed_1 = R2800_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1.Execute(r2800_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CEDE_NOMECED, V0CEDE_NOMECED);
                _.Move(executed_1.V0CEDE_AGENCIA, V0CEDE_AGENCIA);
                _.Move(executed_1.V0CEDE_OPERACAO, V0CEDE_OPERACAO);
                _.Move(executed_1.V0CEDE_CONTA, V0CEDE_CONTA);
                _.Move(executed_1.V0CEDE_DIGCC, V0CEDE_DIGCC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2800_99_SAIDA*/

        [StopWatch]
        /*" R2900-00-TRATA-V0RELATORIOS-SECTION */
        private void R2900_00_TRATA_V0RELATORIOS_SECTION()
        {
            /*" -4386- MOVE 'R2900-00-TRATA-V0RELATORIOS' TO PARAGRAFO. */
            _.Move("R2900-00-TRATA-V0RELATORIOS", PARAGRAFO);

            /*" -4388- PERFORM R2910-00-OBTEM-NUMERACAO. */

            R2910_00_OBTEM_NUMERACAO_SECTION();

            /*" -4390- MOVE V0RELA-NRCOPIAS TO LR02-SEQ. */
            _.Move(V0RELA_NRCOPIAS, AREA_DE_WORK.LR07_LINHA07.LR02_SEQ);

            /*" -4391- MOVE V1SIST-DTMOVABE TO WS-DATA-SQL. */
            _.Move(V1SIST_DTMOVABE, AREA_DE_WORK.WS_DATA_SQL);

            /*" -4392- MOVE WS-DIA-SQL TO WS-DIA. */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_DIA_SQL, AREA_DE_WORK.WS_DATA.WS_DIA);

            /*" -4393- MOVE WS-MES-SQL TO WS-MES. */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_MES_SQL, AREA_DE_WORK.WS_DATA.WS_MES);

            /*" -4394- MOVE WS-ANO-SQL TO WS-ANO. */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_ANO_SQL, AREA_DE_WORK.WS_DATA.WS_ANO);

            /*" -4398- MOVE WS-DATA TO LC09-DTEMISSAO LC11-DTEMISSAO LC09-DTPROCES. */
            _.Move(AREA_DE_WORK.WS_DATA, AREA_DE_WORK.LC11_LINHA11.LC09_DTEMISSAO, AREA_DE_WORK.LC11_LINHA11.LC11_DTEMISSAO, AREA_DE_WORK.LC11_LINHA11.LC09_DTPROCES);

            /*" -4400- MOVE TAB-MES(WS-MES-SQL) TO LR02-MES. */
            _.Move(TABELA_MESES.TAB_MESES_R.TAB_MES[AREA_DE_WORK.WS_DATA_SQL.WS_MES_SQL], AREA_DE_WORK.LR07_LINHA07.LR02_MES);

            /*" -4403- MOVE '/' TO FILLERB1 FILLERB2. */
            _.Move("/", AREA_DE_WORK.WS_DATA_I.FILLERB1, AREA_DE_WORK.WS_DATA_I.FILLERB2);

            /*" -4404- MOVE WS-ANO-SQL TO LK-ANO-CALC. */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_ANO_SQL, AREA_DE_WORK.LK_PROSOMU1.LK_DATA_CALC_R.LK_ANO_CALC);

            /*" -4405- MOVE WS-MES-SQL TO LK-MES-CALC. */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_MES_SQL, AREA_DE_WORK.LK_PROSOMU1.LK_DATA_CALC_R.LK_MES_CALC);

            /*" -4407- MOVE WS-DIA-SQL TO LK-DIA-CALC. */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_DIA_SQL, AREA_DE_WORK.LK_PROSOMU1.LK_DATA_CALC_R.LK_DIA_CALC);

            /*" -4409- PERFORM R2920-00-CALC-DIAS-UTEIS. */

            R2920_00_CALC_DIAS_UTEIS_SECTION();

            /*" -4410- MOVE LK-DIA-CALC TO WS-DIA-I. */
            _.Move(AREA_DE_WORK.LK_PROSOMU1.LK_DATA_CALC_R.LK_DIA_CALC, AREA_DE_WORK.WS_DATA_I.WS_DIA_I);

            /*" -4411- MOVE LK-MES-CALC TO WS-MES-I. */
            _.Move(AREA_DE_WORK.LK_PROSOMU1.LK_DATA_CALC_R.LK_MES_CALC, AREA_DE_WORK.WS_DATA_I.WS_MES_I);

            /*" -4412- MOVE LK-ANO-CALC TO WS-ANO-I. */
            _.Move(AREA_DE_WORK.LK_PROSOMU1.LK_DATA_CALC_R.LK_ANO_CALC, AREA_DE_WORK.WS_DATA_I.WS_ANO_I);

            /*" -4413- MOVE WS-DATA-I TO LR04-DATA. */
            _.Move(AREA_DE_WORK.WS_DATA_I, AREA_DE_WORK.LR09_LINHA09.LR04_DATA);

            /*" -4413- MOVE 'XX/XX/XXXX' TO LE01-DTPOSTAGEM. */
            _.Move("XX/XX/XXXX", AREA_DE_WORK.LC11_LINHA11.LE01_DTPOSTAGEM);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2900_99_SAIDA*/

        [StopWatch]
        /*" R2910-00-OBTEM-NUMERACAO-SECTION */
        private void R2910_00_OBTEM_NUMERACAO_SECTION()
        {
            /*" -4425- MOVE 'R2910-00-OBTEM-NUMERACAO' TO PARAGRAFO. */
            _.Move("R2910-00-OBTEM-NUMERACAO", PARAGRAFO);

            /*" -4427- MOVE '291' TO WNR-EXEC-SQL. */
            _.Move("291", WABEND.WNR_EXEC_SQL);

            /*" -4434- PERFORM R2910_00_OBTEM_NUMERACAO_DB_SELECT_1 */

            R2910_00_OBTEM_NUMERACAO_DB_SELECT_1();

            /*" -4437- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4438- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4439- MOVE ZEROS TO V0RELA-NRCOPIAS */
                    _.Move(0, V0RELA_NRCOPIAS);

                    /*" -4440- ELSE */
                }
                else
                {


                    /*" -4441- DISPLAY 'R2910 - PROBLEMAS SELECT V0RELATORIOS' */
                    _.Display($"R2910 - PROBLEMAS SELECT V0RELATORIOS");

                    /*" -4443- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -4444- IF VIND-NRCOPIAS LESS ZEROS */

            if (VIND_NRCOPIAS < 00)
            {

                /*" -4444- MOVE ZEROS TO V0RELA-NRCOPIAS. */
                _.Move(0, V0RELA_NRCOPIAS);
            }


            /*" -0- FLUXCONTROL_PERFORM R2910_10_INCLUI_RELATORIO */

            R2910_10_INCLUI_RELATORIO();

        }

        [StopWatch]
        /*" R2910-00-OBTEM-NUMERACAO-DB-SELECT-1 */
        public void R2910_00_OBTEM_NUMERACAO_DB_SELECT_1()
        {
            /*" -4434- EXEC SQL SELECT MAX(NRCOPIAS) INTO :V0RELA-NRCOPIAS:VIND-NRCOPIAS FROM SEGUROS.V0RELATORIOS WHERE CODRELAT = 'CARTAECT' AND MES_REFERENCIA = :V1SIST-MESREFER AND ANO_REFERENCIA = :V1SIST-ANOREFER END-EXEC. */

            var r2910_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1 = new R2910_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1()
            {
                V1SIST_MESREFER = V1SIST_MESREFER.ToString(),
                V1SIST_ANOREFER = V1SIST_ANOREFER.ToString(),
            };

            var executed_1 = R2910_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1.Execute(r2910_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RELA_NRCOPIAS, V0RELA_NRCOPIAS);
                _.Move(executed_1.VIND_NRCOPIAS, VIND_NRCOPIAS);
            }


        }

        [StopWatch]
        /*" R2910-10-INCLUI-RELATORIO */
        private void R2910_10_INCLUI_RELATORIO(bool isPerform = false)
        {
            /*" -4450- MOVE 'R0000-00-PRINCIPAL' TO PARAGRAFO. */
            _.Move("R0000-00-PRINCIPAL", PARAGRAFO);

            /*" -4452- MOVE '291' TO WNR-EXEC-SQL. */
            _.Move("291", WABEND.WNR_EXEC_SQL);

            /*" -4454- ADD 1 TO V0RELA-NRCOPIAS. */
            V0RELA_NRCOPIAS.Value = V0RELA_NRCOPIAS + 1;

            /*" -4497- PERFORM R2910_10_INCLUI_RELATORIO_DB_INSERT_1 */

            R2910_10_INCLUI_RELATORIO_DB_INSERT_1();

            /*" -4500- IF SQLCODE EQUAL -803 OR -811 */

            if (DB.SQLCODE.In("-803", "-811"))
            {

                /*" -4501- DISPLAY 'R2910 - (REGISTRO DUPLICADO) ... ' */
                _.Display($"R2910 - (REGISTRO DUPLICADO) ... ");

                /*" -4503- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4504- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4505- DISPLAY 'R2910 - (PROBLEMAS NA INSERCAO RELATORIOS ' */
                _.Display($"R2910 - (PROBLEMAS NA INSERCAO RELATORIOS ");

                /*" -4507- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4507- ADD 1 TO AC-I-RELATORIOS. */
            AREA_DE_WORK.AC_I_RELATORIOS.Value = AREA_DE_WORK.AC_I_RELATORIOS + 1;

        }

        [StopWatch]
        /*" R2910-10-INCLUI-RELATORIO-DB-INSERT-1 */
        public void R2910_10_INCLUI_RELATORIO_DB_INSERT_1()
        {
            /*" -4497- EXEC SQL INSERT INTO SEGUROS.V0RELATORIOS VALUES ( 'EM0600B' , :V1SIST-DTMOVABE, 'EM' , 'CARTAECT' , :V0RELA-NRCOPIAS, 0, :V1SIST-DTMOVABE, :V1SIST-DTMOVABE, :V1SIST-DTMOVABE, :V1SIST-MESREFER, :V1SIST-ANOREFER, 0, 0, 0, 0, 0, 0, :WHOST-NRAPOLICE, 0, 0, 0, 0, :WHOST-CODSUBES, 0, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '0' , ' ' , ' ' , 0, 0, 0, CURRENT TIMESTAMP) END-EXEC. */

            var r2910_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1 = new R2910_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1()
            {
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
                V0RELA_NRCOPIAS = V0RELA_NRCOPIAS.ToString(),
                V1SIST_MESREFER = V1SIST_MESREFER.ToString(),
                V1SIST_ANOREFER = V1SIST_ANOREFER.ToString(),
                WHOST_NRAPOLICE = WHOST_NRAPOLICE.ToString(),
                WHOST_CODSUBES = WHOST_CODSUBES.ToString(),
            };

            R2910_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1.Execute(r2910_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2910_99_SAIDA*/

        [StopWatch]
        /*" R2920-00-CALC-DIAS-UTEIS-SECTION */
        private void R2920_00_CALC_DIAS_UTEIS_SECTION()
        {
            /*" -4519- MOVE 'R2920-00-CALC-DIAS-UTEIS' TO PARAGRAFO. */
            _.Move("R2920-00-CALC-DIAS-UTEIS", PARAGRAFO);

            /*" -4520- MOVE LK-DATA-CALC TO LK-DATA-SOM. */
            _.Move(AREA_DE_WORK.LK_PROSOMU1.LK_DATA_CALC, AREA_DE_WORK.LK_PROSOMU1.LK_DATA_SOM);

            /*" -4520- CALL 'PROSOCU1' USING LK-PROSOMU1. */
            _.Call("PROSOCU1", AREA_DE_WORK.LK_PROSOMU1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2920_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-IMPRIME-LST-SECTION */
        private void R3000_00_IMPRIME_LST_SECTION()
        {
            /*" -4532- MOVE 'R3000-00-IMPRIME-LST' TO PARAGRAFO. */
            _.Move("R3000-00-IMPRIME-LST", PARAGRAFO);

            /*" -4534- MOVE 1 TO WIND. */
            _.Move(1, AREA_DE_WORK.WIND);

            /*" -4534- WRITE FVG0267B-RECORD FROM LR02-LINHA02. */
            _.Move(AREA_DE_WORK.LR02_LINHA02.GetMoveValues(), FVG0267B_RECORD);

            FVG0267B.Write(FVG0267B_RECORD.GetMoveValues().ToString());

            /*" -0- FLUXCONTROL_PERFORM R3000_10_LOOP_OCORR */

            R3000_10_LOOP_OCORR();

        }

        [StopWatch]
        /*" R3000-10-LOOP-OCORR */
        private void R3000_10_LOOP_OCORR(bool isPerform = false)
        {
            /*" -4540- MOVE 'R3000-10-LOOP-OCOR' TO PARAGRAFO. */
            _.Move("R3000-10-LOOP-OCOR", PARAGRAFO);

            /*" -4541- IF WIND GREATER 2000 */

            if (AREA_DE_WORK.WIND > 2000)
            {

                /*" -4542- MOVE 1 TO WIND */
                _.Move(1, AREA_DE_WORK.WIND);

                /*" -4544- GO TO R3000-20-INT. */

                R3000_20_INT(); //GOTO
                return;
            }


            /*" -4545- IF TAB1-QTD-OBJ (WIND) NOT EQUAL ZEROS */

            if (TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_QTD_OBJ != 00)
            {

                /*" -4547- ADD 1 TO WS-OCORR. */
                AREA_DE_WORK.WS_OCORR.Value = AREA_DE_WORK.WS_OCORR + 1;
            }


            /*" -4548- ADD 1 TO WIND. */
            AREA_DE_WORK.WIND.Value = AREA_DE_WORK.WIND + 1;

            /*" -4548- GO TO R3000-10-LOOP-OCORR. */
            new Task(() => R3000_10_LOOP_OCORR()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R3000-20-INT */
        private void R3000_20_INT(bool isPerform = false)
        {
            /*" -4554- MOVE 'R3000-20-INT      ' TO PARAGRAFO. */
            _.Move("R3000-20-INT      ", PARAGRAFO);

            /*" -4555- COMPUTE WWORK-QTDE = (WS-OCORR / 18) */
            AREA_DE_WORK.WWORK_QTDE.Value = (AREA_DE_WORK.WS_OCORR / 18f);

            /*" -4556- IF WWORK-QTDE12 NOT EQUAL ZEROS */

            if (AREA_DE_WORK.WWORK_QTDE01.WWORK_QTDE12 != 00)
            {

                /*" -4558- COMPUTE WWORK-QTDE11 = WWORK-QTDE11 + 1. */
                AREA_DE_WORK.WWORK_QTDE01.WWORK_QTDE11.Value = AREA_DE_WORK.WWORK_QTDE01.WWORK_QTDE11 + 1;
            }


            /*" -4558- MOVE WWORK-QTDE11 TO LR02-PAG-FINAL. */
            _.Move(AREA_DE_WORK.WWORK_QTDE01.WWORK_QTDE11, AREA_DE_WORK.LR10_LINHA10.LR02_PAG_FINAL);

        }

        [StopWatch]
        /*" R3000-30-LOOP-CABEC */
        private void R3000_30_LOOP_CABEC(bool isPerform = false)
        {
            /*" -4565- MOVE 'R3000-30-LOOP     ' TO PARAGRAFO. */
            _.Move("R3000-30-LOOP     ", PARAGRAFO);

            /*" -4566- IF WIND > 2000 */

            if (AREA_DE_WORK.WIND > 2000)
            {

                /*" -4567- MOVE 80 TO AC-LINHAS */
                _.Move(80, AREA_DE_WORK.AC_LINHAS);

                /*" -4569- GO TO R3000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4570- IF TAB1-QTD-OBJ (WIND) = ZEROS */

            if (TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_QTD_OBJ == 00)
            {

                /*" -4571- ADD 1 TO WIND */
                AREA_DE_WORK.WIND.Value = AREA_DE_WORK.WIND + 1;

                /*" -4573- GO TO R3000-30-LOOP-CABEC. */
                new Task(() => R3000_30_LOOP_CABEC()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -4575- ADD 1 TO AC-PAGINA. */
            AREA_DE_WORK.AC_PAGINA.Value = AREA_DE_WORK.AC_PAGINA + 1;

            /*" -4577- MOVE AC-PAGINA TO LR02-PAGINA. */
            _.Move(AREA_DE_WORK.AC_PAGINA, AREA_DE_WORK.LR10_LINHA10.LR02_PAGINA);

            /*" -4578- IF AC-PAGINA GREATER 1 */

            if (AREA_DE_WORK.AC_PAGINA > 1)
            {

                /*" -4580- WRITE FVG0267B-RECORD FROM LR13-LINHA13. */
                _.Move(AREA_DE_WORK.LR13_LINHA13.GetMoveValues(), FVG0267B_RECORD);

                FVG0267B.Write(FVG0267B_RECORD.GetMoveValues().ToString());
            }


            /*" -4582- PERFORM R3010-00-CABECALHOS. */

            R3010_00_CABECALHOS_SECTION();

            /*" -4583- WRITE FVG0267B-RECORD FROM LR10-LINHA10. */
            _.Move(AREA_DE_WORK.LR10_LINHA10.GetMoveValues(), FVG0267B_RECORD);

            FVG0267B.Write(FVG0267B_RECORD.GetMoveValues().ToString());

            /*" -4585- MOVE 1 TO AC-LINHAS. */
            _.Move(1, AREA_DE_WORK.AC_LINHAS);

            /*" -4586- MOVE TAB-FX-INI (WIND) TO WS-NUM-CEP-AUX. */
            _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WIND].TAB_FAIXAS.TAB_FX_INI, AREA_DE_WORK.WS_NUM_CEP_AUX);

            /*" -4587- MOVE WS-CEP-AUX TO LR05-CEPI. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_AUX, AREA_DE_WORK.LR12_LINHA12.LR05_CEPI);

            /*" -4588- MOVE WS-CEP-COMPL-AUX TO LR05-COMPL-CEPI. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, AREA_DE_WORK.LR12_LINHA12.LR05_COMPL_CEPI);

            /*" -4589- MOVE TAB-FX-FIM (WIND) TO WS-NUM-CEP-AUX. */
            _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WIND].TAB_FAIXAS.TAB_FX_FIM, AREA_DE_WORK.WS_NUM_CEP_AUX);

            /*" -4590- MOVE WS-CEP-AUX TO LR05-CEPF. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_AUX, AREA_DE_WORK.LR12_LINHA12.LR05_CEPF);

            /*" -4591- MOVE WS-CEP-COMPL-AUX TO LR05-COMPL-CEPF. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, AREA_DE_WORK.LR12_LINHA12.LR05_COMPL_CEPF);

            /*" -4592- MOVE TAB1-OBJI (WIND) TO LR05-OBJI. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_OBJI, AREA_DE_WORK.LR12_LINHA12.LR05_OBJI);

            /*" -4593- MOVE TAB1-OBJF (WIND) TO LR05-OBJF. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_OBJF, AREA_DE_WORK.LR12_LINHA12.LR05_OBJF);

            /*" -4594- MOVE TAB1-AMARI (WIND) TO LR05-AMARI. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_AMARI, AREA_DE_WORK.LR12_LINHA12.LR05_AMARI);

            /*" -4595- MOVE TAB1-AMARF (WIND) TO LR05-AMARF. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_AMARF, AREA_DE_WORK.LR12_LINHA12.LR05_AMARF);

            /*" -4596- MOVE TAB1-QTD-OBJ (WIND) TO LR05-QTD-OBJ. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_QTD_OBJ, AREA_DE_WORK.LR12_LINHA12.LR05_QTD_OBJ);

            /*" -4597- MOVE TAB1-QTD-AMAR(WIND) TO LR05-QTD-AMAR. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_QTD_AMAR, AREA_DE_WORK.LR12_LINHA12.LR05_QTD_AMAR);

            /*" -4599- MOVE SPACES TO LR05-OBS. */
            _.Move("", AREA_DE_WORK.LR12_LINHA12.LR05_OBS);

            /*" -4599- WRITE FVG0267B-RECORD FROM LR12-LINHA12. */
            _.Move(AREA_DE_WORK.LR12_LINHA12.GetMoveValues(), FVG0267B_RECORD);

            FVG0267B.Write(FVG0267B_RECORD.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" R3000-40-LOOP-DET */
        private void R3000_40_LOOP_DET(bool isPerform = false)
        {
            /*" -4605- MOVE 'R3000-40-PRINCIPAL' TO PARAGRAFO. */
            _.Move("R3000-40-PRINCIPAL", PARAGRAFO);

            /*" -4607- ADD 1 TO WIND. */
            AREA_DE_WORK.WIND.Value = AREA_DE_WORK.WIND + 1;

            /*" -4608- IF WIND > 2000 */

            if (AREA_DE_WORK.WIND > 2000)
            {

                /*" -4609- MOVE 80 TO AC-LINHAS */
                _.Move(80, AREA_DE_WORK.AC_LINHAS);

                /*" -4611- GO TO R3000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4612- IF TAB1-QTD-OBJ (WIND) = ZEROS */

            if (TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_QTD_OBJ == 00)
            {

                /*" -4614- GO TO R3000-40-LOOP-DET. */
                new Task(() => R3000_40_LOOP_DET()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -4615- MOVE TAB-FX-INI (WIND) TO WS-NUM-CEP-AUX. */
            _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WIND].TAB_FAIXAS.TAB_FX_INI, AREA_DE_WORK.WS_NUM_CEP_AUX);

            /*" -4616- MOVE WS-CEP-AUX TO LR05-CEPI. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_AUX, AREA_DE_WORK.LR12_LINHA12.LR05_CEPI);

            /*" -4617- MOVE WS-CEP-COMPL-AUX TO LR05-COMPL-CEPI. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, AREA_DE_WORK.LR12_LINHA12.LR05_COMPL_CEPI);

            /*" -4618- MOVE TAB-FX-FIM (WIND) TO WS-NUM-CEP-AUX. */
            _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WIND].TAB_FAIXAS.TAB_FX_FIM, AREA_DE_WORK.WS_NUM_CEP_AUX);

            /*" -4619- MOVE WS-CEP-AUX TO LR05-CEPF. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_AUX, AREA_DE_WORK.LR12_LINHA12.LR05_CEPF);

            /*" -4620- MOVE WS-CEP-COMPL-AUX TO LR05-COMPL-CEPF. */
            _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, AREA_DE_WORK.LR12_LINHA12.LR05_COMPL_CEPF);

            /*" -4621- MOVE TAB1-OBJI (WIND) TO LR05-OBJI. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_OBJI, AREA_DE_WORK.LR12_LINHA12.LR05_OBJI);

            /*" -4622- MOVE TAB1-OBJF (WIND) TO LR05-OBJF. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_OBJF, AREA_DE_WORK.LR12_LINHA12.LR05_OBJF);

            /*" -4623- MOVE TAB1-AMARI (WIND) TO LR05-AMARI. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_AMARI, AREA_DE_WORK.LR12_LINHA12.LR05_AMARI);

            /*" -4624- MOVE TAB1-AMARF (WIND) TO LR05-AMARF. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_AMARF, AREA_DE_WORK.LR12_LINHA12.LR05_AMARF);

            /*" -4625- MOVE TAB1-QTD-OBJ (WIND) TO LR05-QTD-OBJ. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_QTD_OBJ, AREA_DE_WORK.LR12_LINHA12.LR05_QTD_OBJ);

            /*" -4626- MOVE TAB1-QTD-AMAR(WIND) TO LR05-QTD-AMAR. */
            _.Move(TABELA_TOTAIS.TAB_TOTAIS[AREA_DE_WORK.WIND].TAB1_QTD_AMAR, AREA_DE_WORK.LR12_LINHA12.LR05_QTD_AMAR);

            /*" -4628- MOVE SPACES TO LR05-OBS. */
            _.Move("", AREA_DE_WORK.LR12_LINHA12.LR05_OBS);

            /*" -4629- WRITE FVG0267B-RECORD FROM LR12-LINHA12. */
            _.Move(AREA_DE_WORK.LR12_LINHA12.GetMoveValues(), FVG0267B_RECORD);

            FVG0267B.Write(FVG0267B_RECORD.GetMoveValues().ToString());

            /*" -4631- ADD 1 TO AC-LINHAS. */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 1;

            /*" -4632- IF AC-LINHAS > 17 */

            if (AREA_DE_WORK.AC_LINHAS > 17)
            {

                /*" -4633- ADD 1 TO WIND */
                AREA_DE_WORK.WIND.Value = AREA_DE_WORK.WIND + 1;

                /*" -4634- GO TO R3000-30-LOOP-CABEC */

                R3000_30_LOOP_CABEC(); //GOTO
                return;

                /*" -4635- ELSE */
            }
            else
            {


                /*" -4635- GO TO R3000-40-LOOP-DET. */
                new Task(() => R3000_40_LOOP_DET()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3010-00-CABECALHOS-SECTION */
        private void R3010_00_CABECALHOS_SECTION()
        {
            /*" -4646- MOVE 'R3010-00-CABECALHOS' TO PARAGRAFO. */
            _.Move("R3010-00-CABECALHOS", PARAGRAFO);

            /*" -4647- WRITE FVG0267B-RECORD FROM LR03-LINHA03 */
            _.Move(AREA_DE_WORK.LR03_LINHA03.GetMoveValues(), FVG0267B_RECORD);

            FVG0267B.Write(FVG0267B_RECORD.GetMoveValues().ToString());

            /*" -4648- WRITE FVG0267B-RECORD FROM LR04-LINHA04 */
            _.Move(AREA_DE_WORK.LR04_LINHA04.GetMoveValues(), FVG0267B_RECORD);

            FVG0267B.Write(FVG0267B_RECORD.GetMoveValues().ToString());

            /*" -4649- WRITE FVG0267B-RECORD FROM LR05-LINHA05 */
            _.Move(AREA_DE_WORK.LR05_LINHA05.GetMoveValues(), FVG0267B_RECORD);

            FVG0267B.Write(FVG0267B_RECORD.GetMoveValues().ToString());

            /*" -4650- WRITE FVG0267B-RECORD FROM LR06-LINHA06 */
            _.Move(AREA_DE_WORK.LR06_LINHA06.GetMoveValues(), FVG0267B_RECORD);

            FVG0267B.Write(FVG0267B_RECORD.GetMoveValues().ToString());

            /*" -4651- WRITE FVG0267B-RECORD FROM LR07-LINHA07 */
            _.Move(AREA_DE_WORK.LR07_LINHA07.GetMoveValues(), FVG0267B_RECORD);

            FVG0267B.Write(FVG0267B_RECORD.GetMoveValues().ToString());

            /*" -4652- WRITE FVG0267B-RECORD FROM LR08-LINHA08 */
            _.Move(AREA_DE_WORK.LR08_LINHA08.GetMoveValues(), FVG0267B_RECORD);

            FVG0267B.Write(FVG0267B_RECORD.GetMoveValues().ToString());

            /*" -4653- WRITE FVG0267B-RECORD FROM LR09-LINHA09 */
            _.Move(AREA_DE_WORK.LR09_LINHA09.GetMoveValues(), FVG0267B_RECORD);

            FVG0267B.Write(FVG0267B_RECORD.GetMoveValues().ToString());

            /*" -4653- WRITE FVG0267B-RECORD FROM LR10-LINHA10-A. */
            _.Move(AREA_DE_WORK.LR10_LINHA10_A.GetMoveValues(), FVG0267B_RECORD);

            FVG0267B.Write(FVG0267B_RECORD.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3010_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-SEPARA-PRODUTO-SECTION */
        private void R3100_00_SEPARA_PRODUTO_SECTION()
        {
            /*" -4665- MOVE 'R3100-00-SEPARA-PRODUTO' TO PARAGRAFO. */
            _.Move("R3100-00-SEPARA-PRODUTO", PARAGRAFO);

            /*" -4673- MOVE 999999 TO LF03-FAIXA1 LF03-FAIXA2 LF03-FAIXA1C LF03-FAIXA2C LF05-AMARRADO LF04-QTD-OBJ LF05-SEQ-INICIAL LF05-SEQ-FINAL. */
            _.Move(999999, AREA_DE_WORK.LF04_LINHA04.LF03_FAIXA1, AREA_DE_WORK.LF04_LINHA04.LF03_FAIXA2, AREA_DE_WORK.LF04_LINHA04.LF03_FAIXA1C, AREA_DE_WORK.LF04_LINHA04.LF03_FAIXA2C, AREA_DE_WORK.LF04_LINHA04.LF05_AMARRADO, AREA_DE_WORK.LF04_LINHA04.LF04_QTD_OBJ, AREA_DE_WORK.LF04_LINHA04.LF05_SEQ_INICIAL, AREA_DE_WORK.LF04_LINHA04.LF05_SEQ_FINAL);

            /*" -4675- MOVE LR03-TP-PGTO TO LF02-NOME-FAIXA. */
            _.Move(AREA_DE_WORK.LR11_LINHA11.LR03_TP_PGTO, AREA_DE_WORK.LF04_LINHA04.LF02_NOME_FAIXA);

            /*" -4675- PERFORM R3200-00-FAC-PRODUTO 3 TIMES. */

            for (int i = 0; i < 3; i++)
            {

                R3200_00_FAC_PRODUTO_SECTION();

            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R3200-00-FAC-PRODUTO-SECTION */
        private void R3200_00_FAC_PRODUTO_SECTION()
        {
            /*" -4689- MOVE 'R3200-00-FAC-PRODUTO' TO PARAGRAFO. */
            _.Move("R3200-00-FAC-PRODUTO", PARAGRAFO);

            /*" -4690- IF WS-CONTR-PRODU EQUAL 'C' */

            if (AREA_DE_WORK.WS_CONTR_PRODU == "C")
            {

                /*" -4691- WRITE RVG0267B-RECORD FROM LF01-LINHA01 */
                _.Move(AREA_DE_WORK.LF01_LINHA01.GetMoveValues(), RVG0267B_RECORD);

                RVG0267B.Write(RVG0267B_RECORD.GetMoveValues().ToString());

                /*" -4692- WRITE RVG0267B-RECORD FROM LC08-LINHA08 */
                _.Move(AREA_DE_WORK.LC08_LINHA08.GetMoveValues(), RVG0267B_RECORD);

                RVG0267B.Write(RVG0267B_RECORD.GetMoveValues().ToString());

                /*" -4693- WRITE RVG0267B-RECORD FROM LF02-LINHA02 */
                _.Move(AREA_DE_WORK.LF02_LINHA02.GetMoveValues(), RVG0267B_RECORD);

                RVG0267B.Write(RVG0267B_RECORD.GetMoveValues().ToString());

                /*" -4694- WRITE RVG0267B-RECORD FROM LF03-LINHA03 */
                _.Move(AREA_DE_WORK.LF03_LINHA03.GetMoveValues(), RVG0267B_RECORD);

                RVG0267B.Write(RVG0267B_RECORD.GetMoveValues().ToString());

                /*" -4695- WRITE RVG0267B-RECORD FROM LF04-LINHA04 */
                _.Move(AREA_DE_WORK.LF04_LINHA04.GetMoveValues(), RVG0267B_RECORD);

                RVG0267B.Write(RVG0267B_RECORD.GetMoveValues().ToString());

                /*" -4696- WRITE RVG0267B-RECORD FROM LC12-LINHA12 */
                _.Move(AREA_DE_WORK.LC12_LINHA12.GetMoveValues(), RVG0267B_RECORD);

                RVG0267B.Write(RVG0267B_RECORD.GetMoveValues().ToString());

                /*" -4696- WRITE RVG0267B-RECORD FROM LC01-LINHA01. */
                _.Move(AREA_DE_WORK.LC01_LINHA01.GetMoveValues(), RVG0267B_RECORD);

                RVG0267B.Write(RVG0267B_RECORD.GetMoveValues().ToString());
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/

        [StopWatch]
        /*" R5200-GERA-SIT-IMPRESSAO-SECTION */
        private void R5200_GERA_SIT_IMPRESSAO_SECTION()
        {
            /*" -4707- MOVE '5200' TO WNR-EXEC-SQL. */
            _.Move("5200", WABEND.WNR_EXEC_SQL);

            /*" -4709- INITIALIZE REGISTRO-LINKAGE-GE0350S. */
            _.Initialize(
                LBGE0350.REGISTRO_LINKAGE_GE0350S
            );

            /*" -4710- MOVE 08 TO LK-GE350-COD-FUNCAO */
            _.Move(08, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_FUNCAO);

            /*" -4711- MOVE SVA-NRAPOLICE TO LK-GE350-NUM-APOLICE */
            _.Move(REG_SVG0267B.SVA_NRAPOLICE, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE);

            /*" -4712- MOVE SVA-NRCERTIF TO LK-GE350-NUM-CERTIFICADO */
            _.Move(REG_SVG0267B.SVA_NRCERTIF, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_CERTIFICADO);

            /*" -4713- MOVE SVA-NRPARCEL TO LK-GE350-NUM-PARCELA */
            _.Move(REG_SVG0267B.SVA_NRPARCEL, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA);

            /*" -4714- MOVE ZEROS TO LK-GE350-NUM-ENDOSSO */
            _.Move(0, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO);

            /*" -4715- MOVE ZEROS TO LK-GE350-NUM-PROPOSTA */
            _.Move(0, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PROPOSTA);

            /*" -4717- MOVE SVA-CNTRLE-SIGCB TO LK-GE350-SEQ-CNTRLE-SIGCB */
            _.Move(REG_SVG0267B.SVA_CNTRLE_SIGCB, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_SEQ_CNTRLE_SIGCB);

            /*" -4718- MOVE 'VG' TO LK-GE350-IDE-SISTEMA */
            _.Move("VG", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_IDE_SISTEMA);

            /*" -4719- MOVE 'VG0267B' TO LK-GE350-COD-USUARIO */
            _.Move("VG0267B", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_USUARIO);

            /*" -4721- MOVE 'I' TO LK-GE350-COD-SITUACAO */
            _.Move("I", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO);

            /*" -4723- CALL 'GE0350S' USING REGISTRO-LINKAGE-GE0350S. */
            _.Call("GE0350S", LBGE0350.REGISTRO_LINKAGE_GE0350S);

            /*" -4724- IF (LK-GE350-COD-RETORNO NOT EQUAL '0' ) */

            if ((LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO != "0"))
            {

                /*" -4725- DISPLAY ' ' */
                _.Display($" ");

                /*" -4726- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -4727- DISPLAY '*       R5200-GERA-SIT-IMPRESSAO        *' */
                _.Display($"*       R5200-GERA-SIT-IMPRESSAO        *");

                /*" -4728- DISPLAY '*  ERRO NA EXECUCAO DO CALL DA GE0350S  *' */
                _.Display($"*  ERRO NA EXECUCAO DO CALL DA GE0350S  *");

                /*" -4729- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -4730- DISPLAY '=> APOLICE........ ' LK-GE350-NUM-APOLICE */
                _.Display($"=> APOLICE........ {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE}");

                /*" -4731- DISPLAY '=> CERTIF......... ' LK-GE350-NUM-CERTIFICADO */
                _.Display($"=> CERTIF......... {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_CERTIFICADO}");

                /*" -4732- DISPLAY '=> NRPARCEL....... ' LK-GE350-NUM-PARCELA */
                _.Display($"=> NRPARCEL....... {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA}");

                /*" -4733- DISPLAY '=> SEQ-CNTRLE..... ' LK-GE350-SEQ-CNTRLE-SIGCB */
                _.Display($"=> SEQ-CNTRLE..... {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_SEQ_CNTRLE_SIGCB}");

                /*" -4734- DISPLAY '-----------------------------------------' */
                _.Display($"-----------------------------------------");

                /*" -4735- DISPLAY '=> LK-MENSAGEM ... ' LK-GE350-MENSAGEM */
                _.Display($"=> LK-MENSAGEM ... {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM}");

                /*" -4736- DISPLAY '=> LK-COD-RETORNO. ' LK-GE350-COD-RETORNO */
                _.Display($"=> LK-COD-RETORNO. {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO}");

                /*" -4737- DISPLAY '=> LK-SQLCODE..... ' LK-GE350-SQLCODE */
                _.Display($"=> LK-SQLCODE..... {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_SQLCODE}");

                /*" -4738- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -4739- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4739- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5200_99_SAIDA*/

        [StopWatch]
        /*" R8000-00-OPEN-ARQUIVOS-SECTION */
        private void R8000_00_OPEN_ARQUIVOS_SECTION()
        {
            /*" -4750- MOVE 'R8000-00-OPEN-ARQUIVOS' TO PARAGRAFO. */
            _.Move("R8000-00-OPEN-ARQUIVOS", PARAGRAFO);

            /*" -4751- OPEN OUTPUT RVG0267B FVG0267B. */
            RVG0267B.Open(RVG0267B_RECORD);
            FVG0267B.Open(FVG0267B_RECORD);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-CLOSE-ARQUIVOS-SECTION */
        private void R9000_00_CLOSE_ARQUIVOS_SECTION()
        {
            /*" -4763- MOVE 'R9000-00-CLOSE-ARQUIVOS' TO PARAGRAFO. */
            _.Move("R9000-00-CLOSE-ARQUIVOS", PARAGRAFO);

            /*" -4764- CLOSE RVG0267B FVG0267B. */
            RVG0267B.Close();
            FVG0267B.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9100-00-INSERT-GEOBJECT-SECTION */
        private void R9100_00_INSERT_GEOBJECT_SECTION()
        {
            /*" -4778- MOVE 'R9100-00-INSERT-GEOBJECT' TO PARAGRAFO. */
            _.Move("R9100-00-INSERT-GEOBJECT", PARAGRAFO);

            /*" -4803- PERFORM R9100_00_INSERT_GEOBJECT_DB_INSERT_1 */

            R9100_00_INSERT_GEOBJECT_DB_INSERT_1();

            /*" -4806- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4807- DISPLAY 'R9100-00 (PROBLEMAS NA INSERCAO GEOBJECT)' */
                _.Display($"R9100-00 (PROBLEMAS NA INSERCAO GEOBJECT)");

                /*" -4811- DISPLAY 'CHAVE = ' GEOBJECT-NUM-CEP ' ' GEOBJECT-NOM-PROGRAMA ' ' GEOBJECT-COD-FORMULARIO ' ' GEOBJECT-STA-REGISTRO */

                $"CHAVE = {GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NUM_CEP} {GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NOM_PROGRAMA} {GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_FORMULARIO} {GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_STA_REGISTRO}"
                .Display();

                /*" -4811- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R9100-00-INSERT-GEOBJECT-DB-INSERT-1 */
        public void R9100_00_INSERT_GEOBJECT_DB_INSERT_1()
        {
            /*" -4803- EXEC SQL INSERT INTO SEGUROS.GE_OBJETO_ECT ( NUM_CEP , NOM_PROGRAMA , COD_FORMULARIO , STA_REGISTRO , DTH_TIMESTAMP , COD_PRODUTO , NUM_INI_POS_VERSO , QTD_PESO_GRAMAS , VLR_DECLARADO , COD_IDENT_OBJETO , DES_OBJETO) VALUES (:GEOBJECT-NUM-CEP , :GEOBJECT-NOM-PROGRAMA , :GEOBJECT-COD-FORMULARIO , :GEOBJECT-STA-REGISTRO , CURRENT TIMESTAMP , :GEOBJECT-COD-PRODUTO :VIND-COD-PRODUTO , :GEOBJECT-NUM-INI-POS-VERSO , :GEOBJECT-QTD-PESO-GRAMAS , :GEOBJECT-VLR-DECLARADO , :GEOBJECT-COD-IDENT-OBJETO , :GEOBJECT-DES-OBJETO) END-EXEC. */

            var r9100_00_INSERT_GEOBJECT_DB_INSERT_1_Insert1 = new R9100_00_INSERT_GEOBJECT_DB_INSERT_1_Insert1()
            {
                GEOBJECT_NUM_CEP = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NUM_CEP.ToString(),
                GEOBJECT_NOM_PROGRAMA = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NOM_PROGRAMA.ToString(),
                GEOBJECT_COD_FORMULARIO = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_FORMULARIO.ToString(),
                GEOBJECT_STA_REGISTRO = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_STA_REGISTRO.ToString(),
                GEOBJECT_COD_PRODUTO = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_PRODUTO.ToString(),
                VIND_COD_PRODUTO = VIND_COD_PRODUTO.ToString(),
                GEOBJECT_NUM_INI_POS_VERSO = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_NUM_INI_POS_VERSO.ToString(),
                GEOBJECT_QTD_PESO_GRAMAS = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_QTD_PESO_GRAMAS.ToString(),
                GEOBJECT_VLR_DECLARADO = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_VLR_DECLARADO.ToString(),
                GEOBJECT_COD_IDENT_OBJETO = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_COD_IDENT_OBJETO.ToString(),
                GEOBJECT_DES_OBJETO = GEOBJECT.DCLGE_OBJETO_ECT.GEOBJECT_DES_OBJETO.ToString(),
            };

            R9100_00_INSERT_GEOBJECT_DB_INSERT_1_Insert1.Execute(r9100_00_INSERT_GEOBJECT_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9100_99_SAIDA*/

        [StopWatch]
        /*" R9800-00-ENCERRA-SEM-SOLIC-SECTION */
        private void R9800_00_ENCERRA_SEM_SOLIC_SECTION()
        {
            /*" -4823- MOVE 'R9800-00-ENCERRA- ' TO PARAGRAFO. */
            _.Move("R9800-00-ENCERRA- ", PARAGRAFO);

            /*" -4825- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -4826- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -4827- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -4828- DISPLAY '*   VG0267B - IMPRIME COBRANCA             *' */
            _.Display($"*   VG0267B - IMPRIME COBRANCA             *");

            /*" -4829- DISPLAY '*   -------   ----------------             *' */
            _.Display($"*   -------   ----------------             *");

            /*" -4830- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -4831- DISPLAY '*             NAO EXISTE BOLETO DE         *' */
            _.Display($"*             NAO EXISTE BOLETO DE         *");

            /*" -4832- DISPLAY '*             COBRANCA PARA ESTA DATA      *' */
            _.Display($"*             COBRANCA PARA ESTA DATA      *");

            /*" -4833- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -4835- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

            /*" -4835- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -4844- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -4846- DISPLAY WABEND */
            _.Display(WABEND);

            /*" -4846- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -4848- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -4853- CLOSE RVG0267B FVG0267B. */
            RVG0267B.Close();
            FVG0267B.Close();

            /*" -4855- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -4855- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}